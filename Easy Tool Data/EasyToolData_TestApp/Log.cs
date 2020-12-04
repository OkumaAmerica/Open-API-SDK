using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyToolData_TestApp
{
    using System;
    using System.IO;
    using System.Globalization;
    using System.Diagnostics;
    using Okuma.SharedLog;

    // MODIFIED TO ADD STACKFRAME CAPTURE IN DEBUG 19-2-7

    // ╔═════════════════════════════════════════════════════════════════════╗
    // ║   ______ ____   ______   __                         _               ║
    // ║  /_ __/ / __ \ / ____/  / /   ____   ____ _ ____ _ (_)____   ____ _ ║
    // ║   / /  / / / // / __   / /   / __ \ / __ `// __ `// // __ \ / __ `/ ║
    // ║  / /  / /_/ // /_/ /  / /___/ /_/ // /_/ // /_/ // // / / // /_/ /  ║
    // ║ /_/  /_____/ \____/  /_____/\____/ \__, / \__, //_//_/ /_/ \__, /   ║
    // ║                                   /____/ /____/           /____/    ║
    // ║                                                                     ║
    // ║     APPLICATION ONLY Logging Implementation - Log File Writer       ║
    // ╚═════════════════════════════════════════════════════════════════════╝
    public static partial class Log
    {
        private const bool CONTEXT_AND_CULTURE_SWITCHING = true;

        private static bool FirstMessage = true;

        //private static bool TapiNotAvailalbeShown = false;

        private static Okuma.SharedLog.MessageType CurrentSyntaxType;

        private static Okuma.SharedLog.LoggingCulture CurrentLoggingCulture = Okuma.SharedLog.LoggingCulture.Default;

        private static TDG.logging.SystemEventLog EventLog;

        private static bool IsDebugMode = false;

        private const string ThisFile = @"D:\VS Projects\Git\Easy-Tool-Data\Source\Okuma.EasyToolData\Log.cs";

        public static string LogFile
        {
            get
            {
                if (EventLog == null)
                {
                    return null;
                }
                else
                {
                    return EventLog.LogFileFullPath;
                }
            }
        }


        static Log()
        {
            InitLog();

            // Relies on Project Build - General Setting
            // "Define DEBUG constant" Checked
            #if DEBUG
            {
                IsDebugMode = true;
            }
            #endif
        }

        /// <summary> Necessary after calling Stop() because 'EventLog = null;' </summary>
        public static void InitLog()
        {
            if (EventLog == null)
            {
                EventLog = new TDG.logging.SystemEventLog(TDG.logging.Enumerations.LogFileTypes.TXT)
                {
                    EventTimeFormat = TDG.logging.Enumerations.EventTimeFormatEnum.StandardDateTime,
                    // Bytes. Let's say 5 MB, so 1048576 * 5
                    MaxLogFileSize = 5242880,
                    MaxLogFileRetention = 1
                };

                FirstMessage = true;

                // Clear out old log file if it exists
                if (LogFile != null && File.Exists(LogFile))
                {
                    File.Delete(LogFile);
                }
            }

            // Subscribe To Error Handlers
            //
            // Add lines here to handle messages from all shared logging sources
            // Scout Error Messages, ETD messages, etc.

            Okuma.EasyToolData.Log.MessageEvent += MessageReceiver;
            //Okuma.Scout.Error.ReporterEvent += MessageReceiver; // One Day...

            MessageEvent += MessageReceiver;
        }


        /// <summary> No further messages will be logged until InitLog() is called </summary>
        public static void Stop()
        {
            if (EventLog != null)
            {
                EventLog.Flush();
                System.Threading.Thread.Sleep(200);

                EventLog.ClearLoggingQueues();
                EventLog = null;
            }
        }



        // =============================================
        // Five Ways to log using TDG.logging:
        //   1. LoggingEventArgs
        //   2. List<string> MessageList 
        //   3. Message, (Sender), (EventType)
        //   4. Exception, (Message), (Sender), (Method)
        //   5. Message[], (Sender), (EventType), (Delimiter ";"), (ParamTotalLength 0), (ParamPaddingChar " ")
        //

        private static void MessageReceiver(object sender, Okuma.SharedLog.MessageArg e)
        {
            // Note: The DISPLAY of messages in the GUI is handled in a separate (ViewModel) class.
            // This receiver is strictly for WRITING log messages to file.

            if (EventLog != null)
            {
                if (CONTEXT_AND_CULTURE_SWITCHING)
                {
                    SetTextLogSyntax(e.MessageType);
                }

                if (e.MessageType == Okuma.SharedLog.MessageType.EXCEPTION)
                {
                    if (sender != null)
                    {
                        EventLog.WriteEvent(e.Ex, e.Message, sender.ToString(), e.Method);
                    }
                    else
                    {
                        EventLog.WriteEvent(e.Ex, e.Message, "Unknown Sender", e.Method);
                    }
                }
                else if (e.Log)
                {
                    TDG.logging.LoggingEventArgs args = new TDG.logging.LoggingEventArgs();
                    if (sender != null)
                    {
                        args.Sender = sender.ToString();
                    }
                    else
                    {
                        args.Sender = "Unknown Sender";
                    }

                    if (e.Ex != null)
                    {
                        args.ExceptionMessage = e.Ex.Message;
                        args.ExceptionType = e.Ex.GetType().Name;

                        if (e.Ex.StackTrace != null)
                        {
                            args.StackTrace = e.Ex.StackTrace;
                        }
                    }

                    // args.AssemblyName = ?
                    // args.EventGuid = AUTO
                    // args.EventTime = AUTO

                    args.EventType = e.MessageType.ToLogEventType();

                    args.Message = e.Message;

                    // args.MessageList = HIGH SPEED LOGGING ONLY

                    if (IsDebugMode)
                    {
                        // https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stackframe?view=netframework-4.7.2

                        int skipFrames = 1;
                        bool fNeedFileInfo = true;
                        System.Diagnostics.StackFrame CallStack = new StackFrame(skipFrames, fNeedFileInfo);

                        // Try skipping more frames backwards if nothing found
                        // keep skipping back until your outside of this file.
                        for (int i = 0; i < 10; i++)
                        {
                            if (CallStack.GetFileName() == null || 
                                CallStack.GetFileName() == ThisFile)
                            {
                                skipFrames++;
                                CallStack = new StackFrame(skipFrames, fNeedFileInfo);     
                            }
                        }

                        if (CallStack.GetFileName() != null)
                        {
                            string frames = skipFrames.ToString();
                            
                            args.Method = e.Method + "()" + Environment.NewLine +
                            "     Frame " + frames + GetBuffStr(frames.Length) +
                            "File: " + CallStack.GetFileName() +
                            ", LN: " + CallStack.GetFileLineNumber();
                        }
                        else
                        {
                            args.Method = e.Method + "()" + Environment.NewLine +
                            "               " + "CallStack empty.";
                        }

                    }
                    else
                    {
                        args.Method = e.Method + "()";
                    }

                    // args.ProcessID = ?

                    EventLog.WriteEvent(args);
                }

                if (FirstMessage)
                {
                    EventLog.Flush();
                    FirstMessage = false;
                }
            }
        }

        private static string GetBuffStr(int numLen)
        {
            if (numLen < 1)  return "      = ";
            if (numLen == 1) return "     = ";
            if (numLen == 2) return "    = ";
            if (numLen == 3) return "   = ";

            return "  Δ ";
        }


        private static bool MsgIsTapiNotAvailable(Okuma.SharedLog.MessageArg e)
        {
            if (e.MessageType == Okuma.SharedLog.MessageType.STOP_ERROR)
            {
                if (e.Message == "THINC API Is either Not Installed or Not Ready.")
                {
                    return true;
                }

                if (e.Message == @"THINC APIインストールされていないか、準備ができていません。")
                {
                    return true;
                }
            }

            return false;
        }


        private static void SetTextLogSyntax(Okuma.SharedLog.MessageType Type)
        {
            if (FirstMessage)
            {
                SetTextLogSyntaxNewRun();
            }
            else
            {
                if (CurrentSyntaxType == Type &&
                    CurrentLoggingCulture == AppCultureToLoggingCulture(Properties.Resources.Culture))
                {
                    // If current syntax type and culture hasn't changed, don't do anything.
                    return;
                }
                else
                {
                    // SyntaxOfTextLog needs to change.
                    // Flush queued logging messages to effectively change the syntax:
                    EventLog.Flush();

                    string resourceName = string.Empty;

                    CurrentSyntaxType = Type;
                    CurrentLoggingCulture = AppCultureToLoggingCulture(Properties.Resources.Culture);

                    string syntax = Okuma.SharedLog.Syntax.GetSyntax(CurrentLoggingCulture, CurrentSyntaxType);

                    if (!string.IsNullOrEmpty(syntax))
                    {
                        EventLog.SyntaxOfTextLog = syntax;
                    }
                }
            }
        }

        private static void SetTextLogSyntaxNewRun()
        {
            CurrentLoggingCulture = AppCultureToLoggingCulture(Properties.Resources.Culture);
            string resourceName = string.Empty;

            string syntax = Okuma.SharedLog.Syntax.GetNewRunSyntax(CurrentLoggingCulture);

            if (!string.IsNullOrEmpty(syntax))
            {
                EventLog.SyntaxOfTextLog = syntax;
            }
        }


        public static Okuma.SharedLog.LoggingCulture AppCultureToLoggingCulture(CultureInfo culture)
        {
            if (culture == null) { return Okuma.SharedLog.LoggingCulture.Default; }

            switch (culture.EnglishName)
            {
                default: { return Okuma.SharedLog.LoggingCulture.Default; }
                case "English (United States)": { return Okuma.SharedLog.LoggingCulture.English; }
                case "English": { return Okuma.SharedLog.LoggingCulture.English; }
                case "Japanese (Japan)": { return Okuma.SharedLog.LoggingCulture.Japanese; }
                case "Japanese": { return Okuma.SharedLog.LoggingCulture.Japanese; }
            }
        }

        public static TDG.logging.Enumerations.EventTypesEnum ToLogEventType(this MessageType Type)
        {
            switch (Type)
            {
                default: { return TDG.logging.Enumerations.EventTypesEnum.INFO; }
                case MessageType.DEBUG: { return TDG.logging.Enumerations.EventTypesEnum.DEBUG; }
                case MessageType.EXCEPTION: { return TDG.logging.Enumerations.EventTypesEnum.EXCEPTION; }
                case MessageType.STOP_ERROR: { return TDG.logging.Enumerations.EventTypesEnum.FATAL; }
                case MessageType.INFO: { return TDG.logging.Enumerations.EventTypesEnum.INFO; }
                case MessageType.STATUS: { return TDG.logging.Enumerations.EventTypesEnum.STATUS; }
                case MessageType.TRACE_LOG: { return TDG.logging.Enumerations.EventTypesEnum.TRACE; }
                case MessageType.WARNING: { return TDG.logging.Enumerations.EventTypesEnum.WARNING; }
            }
        }

    }




    //  █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█  //
    //  █       __  _       _        █  //
    //  █      (_  |_ |\ | | \       █  //
    //  █      __) |_ | \| |_/       █  //
    //  █                            █  //
    //  █ App & DLL Common Log Class █  //
    //  █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█  //
    public static partial class Log
    {
        public static event EventHandler<Okuma.SharedLog.MessageArg> MessageEvent;

        internal static void Send(Okuma.SharedLog.MessageArg e, string sender = null)
        {
            EventHandler<Okuma.SharedLog.MessageArg> tempErrorEvent = MessageEvent;

            if (tempErrorEvent != null)
            {
                tempErrorEvent?.Invoke(sender, e);
            }
            else if (e.MessageType == Okuma.SharedLog.MessageType.EXCEPTION)
            {
                throw e.Ex;
            }
        }

        internal static void SendEx(Exception ex, string sender, string method)
        {
            EventHandler<Okuma.SharedLog.MessageArg> tempErrorEvent = MessageEvent;

            string ExceptionDetail = "";
            if (!string.IsNullOrEmpty(ex.Message)) { ExceptionDetail += ex.Message + Environment.NewLine; }
            if (ex.InnerException != null) { ExceptionDetail += ex.InnerException + Environment.NewLine; }
            if (ex.StackTrace != null) { ExceptionDetail += ex.StackTrace; }

            if (tempErrorEvent != null)
            {
                tempErrorEvent?.Invoke(sender,
                    new Okuma.SharedLog.MessageArg(
                            ExceptionDetail,
                            Okuma.SharedLog.MessageType.EXCEPTION,
                            method, ex,
                            log: true, display: true)
                    );
            }
            else
            {
                throw ex;
            }
        }
    }
}