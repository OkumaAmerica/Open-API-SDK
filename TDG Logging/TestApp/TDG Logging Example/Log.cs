
namespace TDG_Logging_Example
{
    using System;

    static class Log
    {
        static tdg.logging.SystemEventLog EventLog;
        static tdg.logging.Enumerations.EventTypesEnum CurrentSyntaxType;

        static Log()
        {
            EventLog = new tdg.logging.SystemEventLog(tdg.logging.Enumerations.LogFileTypes.TXT);           
        }

        public static void WriteEvent( 
                object sender,
                string method,
                tdg.logging.Enumerations.EventTypesEnum type,
                string mesage
                )
        {
            tdg.logging.LoggingEventArgs args = new tdg.logging.LoggingEventArgs();

            args.EventType = type;
            args.Message = mesage;

            if (sender != null) { args.Sender = sender.ToString(); }
            if (method != null) { args.Method = method; }

            SetTextLogSyntax(tdg.logging.Enumerations.EventTypesEnum.INFO);

            EventLog.WriteEvent(args);
        }

        public static void WriteEvent(object sender, string method, Exception ex)
        {
            SetTextLogSyntax(tdg.logging.Enumerations.EventTypesEnum.EXCEPTION);
            EventLog.WriteEvent(ex, null, sender.ToString(), method);
        }

        private static void SetTextLogSyntax(tdg.logging.Enumerations.EventTypesEnum Type)
        {
            if (CurrentSyntaxType != Type)
            {
                string resourceName;
                string syntax;
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();

                switch (Type)
                {
                    default:
                        {
                            resourceName = "TDG_Logging_Example.TextLogSyntax.Default.txt";
                            break;
                        }
                    case tdg.logging.Enumerations.EventTypesEnum.EXCEPTION:
                        {
                            resourceName = "TDG_Logging_Example.TextLogSyntax.Exception.txt";
                            break;
                        }
                    case tdg.logging.Enumerations.EventTypesEnum.INFO:
                        {
                            resourceName = "TDG_Logging_Example.TextLogSyntax.Info.txt";
                            break;
                        }
                }
                
                using (System.IO.Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                {
                    syntax = reader.ReadToEnd();
                }

                if (!string.IsNullOrEmpty(syntax))
                {
                    EventLog.SyntaxOfTextLog = syntax;
                    CurrentSyntaxType = Type;
                }
            }
        }
    }
}
