

namespace EasyToolData_TestApp.ViewModels
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.ComponentModel;
    using System.Windows.Documents;
    using System.Collections.ObjectModel;
    using Okuma.SharedLog;

    class ErrorHandlingViewModel : INotifyPropertyChanged
    {
        //////////////////////////////////
        //  ______ _      _     _     
        //  |  ___(_)    | |   | |    
        //  | |_   _  ___| | __| |___ 
        //  |  _| | |/ _ \ |/ _` / __|
        //  | |   | |  __/ | (_| \__ \
        //  \_|   |_|\___|_|\__,_|___/


        private readonly int MAX_LINES = 2000;

        /// <summary> Log Font </summary>
        private static readonly FontFamily MessageFont = new FontFamily("Consolas");

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;


        public ObservableCollection<Okuma.SharedLog.MessageType> MessageTypeCollection { get; set; }


        /////////////////////////////
        //   _____ _             
        //  /  __ \ |            
        //  | /  \/ |_ ___  _ __ 
        //  | |   | __/ _ \| '__|
        //  | \__/\ || (_) | |   
        //   \____/\__\___/|_| 

        public ErrorHandlingViewModel()
        {
            MessageTypeCollection = new ObservableCollection<MessageType>();

            foreach (Okuma.SharedLog.MessageType type in Enum.GetValues(typeof(MessageType)))
            {
                MessageTypeCollection.Add(type);
            }
            SelectedMessageType = 1;

            GenerateFlowLog();

            // Subscribe to Okuma DLL Messages 
            SubscribeToEasyToolDataErrorHandler();
            
            Verbose = true;
        }



        /////////////////////////////////////////////////////////
        //  ______                          _   _           
        //  | ___ \                        | | (_)          
        //  | |_/ / __ ___  _ __   ___ _ __| |_ _  ___  ___ 
        //  |  __/ '__/ _ \| '_ \ / _ \ '__| __| |/ _ \/ __|
        //  | |  | | | (_) | |_) |  __/ |  | |_| |  __/\__ \
        //  \_|  |_|  \___/| .__/ \___|_|   \__|_|\___||___/
        //                 | |                              
        //                 |_|                               

        private int _selectedMessageType;
        public int SelectedMessageType
        {
            get { return _selectedMessageType; }
            set
            {
                _selectedMessageType = value;
                OnPropertyChanged("SelectedMessageType");
            }
        }

        private FlowDocument _loggingFlowDocument;
        public FlowDocument LoggingFlowDocument
        {
            get { return _loggingFlowDocument; }
            set
            {
                _loggingFlowDocument = value;
                OnPropertyChanged("LoggingFlowDocument");
            }
        }

        private bool _subscribeCanExecute;
        public bool SubscribeCanExecute
        {
            get { return _subscribeCanExecute; }
            set
            {
                _subscribeCanExecute = value;
                OnPropertyChanged("SubscribeCanExecute");
                SubscribeToErrorHandlerCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _unSubscribeCanExecute;
        public bool UnSubscribeCanExecute
        {
            get { return _unSubscribeCanExecute; }
            set
            {
                _unSubscribeCanExecute = value;
                OnPropertyChanged("UnSubscribeCanExecute");
                UnSubscribeFromErrorHandlerCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _subscribedToReporterEvent;
        public bool SubscribedToReportedEvent
        {
            get { return _subscribedToReporterEvent; }
            set
            {
                _subscribedToReporterEvent = value;
                OnPropertyChanged("SubscribedToReportedEvent");
            }
        }

        private bool _verbose;
        public bool Verbose
        {
            get { return _verbose; }
            set
            {
                _verbose = value;
                //Helpers.ErrorHandler.Verbose = value; // Meh.
                //Okuma.EasyToolData.Log. .Message.Verbose = value;
                OnPropertyChanged("Verbose");
            }
        }




        /////////////////////////////////////////////////////////////
        //   _____                                           _     
        //  /  __ \                                         | |    
        //  | /  \/ ___  _ __ ___  _ __ ___   __ _ _ __   __| |___ 
        //  | |    / _ \| '_ ` _ \| '_ ` _ \ / _` | '_ \ / _` / __|
        //  | \__/\ (_) | | | | | | | | | | | (_| | | | | (_| \__ \
        //   \____/\___/|_| |_| |_|_| |_| |_|\__,_|_| |_|\__,_|___/

        private DelegateCommand<bool> _subscribeToErrorHandlerCommand;
        public DelegateCommand<bool> SubscribeToErrorHandlerCommand
        {
            get
            {
                if (_subscribeToErrorHandlerCommand == null)
                {
                    _subscribeToErrorHandlerCommand = new DelegateCommand<bool>(
                        (s) => { SubscribeToEasyToolDataErrorHandler(); },
                        (s) => { return SubscribeCanExecute; }
                        );
                }
                return _subscribeToErrorHandlerCommand;
            }
        }

        private DelegateCommand<bool> _unSubscribeFromErrorHandlerCommand;
        public DelegateCommand<bool> UnSubscribeFromErrorHandlerCommand
        {
            get
            {
                if (_unSubscribeFromErrorHandlerCommand == null)
                {
                    _unSubscribeFromErrorHandlerCommand = new DelegateCommand<bool>(
                        (s) => { UnSubscribeFromEasyToolDataErrorHandler(); },
                        (s) => { return UnSubscribeCanExecute; }
                        );
                }
                return _unSubscribeFromErrorHandlerCommand;
            }
        }

        //private DelegateCommand<bool> _generateInfoCommand;
        //public DelegateCommand<bool> GenerateInfoCommand
        //{
        //    get
        //    {
        //        if (_generateInfoCommand == null)
        //        {
        //            _generateInfoCommand = new DelegateCommand<bool>(
        //                (s) => { Okuma.EasyToolData.Log.TestReporter(MessageType.INFO); },
        //                (s) => { return AlwaysExecute; }
        //                );
        //        }
        //        return _generateInfoCommand;
        //    }
        //}

        //private DelegateCommand<bool> _generateWarningCommand;
        //public DelegateCommand<bool> GenerateWarningCommand
        //{
        //    get
        //    {
        //        if (_generateWarningCommand == null)
        //        {
        //            _generateWarningCommand = new DelegateCommand<bool>(
        //                (s) => { Okuma.EasyToolData.Log.TestReporter(MessageType.WARNING);  },
        //                (s) => { return AlwaysExecute; }
        //                );
        //        }
        //        return _generateWarningCommand;
        //    }
        //}

        //private DelegateCommand<bool> _generateErrorCommand;
        //public DelegateCommand<bool> GenerateErrorCommand
        //{
        //    get
        //    {
        //        if (_generateErrorCommand == null)
        //        {
        //            _generateErrorCommand = new DelegateCommand<bool>(
        //                (s) => { Okuma.EasyToolData.Log.TestReporter(MessageType.STOP_ERROR); },
        //                (s) => { return AlwaysExecute; }
        //                );
        //        }
        //        return _generateErrorCommand;
        //    }
        //}

        //private DelegateCommand<bool> _generateExceptionCommand;
        //public DelegateCommand<bool> GenerateExceptionCommand
        //{
        //    get
        //    {
        //        if (_generateExceptionCommand == null)
        //        {
        //            _generateExceptionCommand = new DelegateCommand<bool>(
        //                (s) => { Okuma.EasyToolData.Log.TestReporter(MessageType.EXCEPTION); },
        //                (s) => { return AlwaysExecute; }
        //                );
        //        }
        //        return _generateExceptionCommand;
        //    }
        //}

        private DelegateCommand<bool> _testMessageCommand;
        public DelegateCommand<bool> TestMessageCommand
        {
            get
            {
                if (_testMessageCommand == null)
                {
                    _testMessageCommand = new DelegateCommand<bool>(
                        (s) => { Okuma.EasyToolData.Log.TestReporter(MessageTypeCollection[SelectedMessageType]); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _testMessageCommand;
            }
        }

        private DelegateCommand<bool> _clearLogCommand;
        public DelegateCommand<bool> ClearLogCommand
        {
            get
            {
                if (_clearLogCommand == null)
                {
                    _clearLogCommand = new DelegateCommand<bool>(
                        (s) => { ClearFlowLog(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _clearLogCommand;
            }
        }
        
        private DelegateCommand<bool> _openLogCommand;
        public DelegateCommand<bool> OpenLogCommand
        {
            get
            {
                if (_openLogCommand == null)
                {
                    _openLogCommand = new DelegateCommand<bool>(
                        (s) => { OpenLogFile(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _openLogCommand;
            }
        }


        /////////////////////////////////////////////////
        //  ___  ___     _   _               _     
        //  |  \/  |    | | | |             | |    
        //  | .  . | ___| |_| |__   ___   __| |___ 
        //  | |\/| |/ _ \ __| '_ \ / _ \ / _` / __|
        //  | |  | |  __/ |_| | | | (_) | (_| \__ \
        //  \_|  |_/\___|\__|_| |_|\___/ \__,_|___/

        /// <summary>
        /// This is the Test Application's error handler.
        /// It handles reporting from Easy Tool Data in addition to any error 
        /// handling in the test application itself. </summary>
        private void Log_MessageEvent(object sender, MessageArg e)
        {
            if (e.MessageType == MessageType.EXCEPTION ||
                e.MessageType == MessageType.STOP_ERROR ||
                e.MessageType == MessageType.WARNING)
            {
                AppendFlowLog(e);
            }
            else if (Verbose)
            {
                AppendFlowLog(e);
            }
        }


        private void SubscribeToEasyToolDataErrorHandler()
        {
            Log.MessageEvent += Log_MessageEvent;
            Okuma.EasyToolData.Log.MessageEvent += Log_MessageEvent;

            // Display the subscription status
            SubscribedToReportedEvent = true;

            // Subscribing multiple times would result in duplicate lines.
            SubscribeCanExecute = false;
            UnSubscribeCanExecute = true;
        }

        private void UnSubscribeFromEasyToolDataErrorHandler()
        {
            Log.MessageEvent -= Log_MessageEvent;
            Okuma.EasyToolData.Log.MessageEvent -= Log_MessageEvent;

            // Display subscription status.
            SubscribedToReportedEvent = false;

            // Allow user to subscribe to the event again.
            SubscribeCanExecute = true;
            UnSubscribeCanExecute = false;
        }


        private void GenerateFlowLog()
        {
            Paragraph myParagraph = new Paragraph();

            // Add some Bold text to the paragraph
            myParagraph.Inlines.Add(new Run("Logging Started " + DateTime.Now));

            // Create a FlowDocument with the paragraph and list.
            LoggingFlowDocument = new FlowDocument();
            LoggingFlowDocument.Blocks.Add(myParagraph);
        }

        private void ClearFlowLog()
        {
            LoggingFlowDocument.Blocks.Clear();

            Paragraph myParagraph = new Paragraph();
            myParagraph.Inlines.Add(new Run("Log Cleared " + DateTime.Now));
            LoggingFlowDocument.Blocks.Add(myParagraph);
        }

        private void AppendFlowLog(MessageArg Result)
        {
            try
            {
                Paragraph p = new Paragraph();

                if (Result.MessageType == MessageType.EXCEPTION)
                {
                    Run when = new Run(DateTime.Now.ToString());
                    p.Inlines.Add(when);
                }

                Run r = new Run(MessageTypeToHeaderString(Result.MessageType))
                {
                    FontWeight = FontWeights.Bold,
                    Foreground = LogTypeToBrush(Result.MessageType)
                };

                p.Inlines.Add(r);

                Run message = new Run(Result.Message)
                {
                    FontFamily = MessageFont
                };

                p.Inlines.Add(message);
                LoggingFlowDocument.Blocks.InsertBefore(LoggingFlowDocument.Blocks.FirstBlock, p);

                if (LoggingFlowDocument.Blocks.Count() > MAX_LINES)
                {
                    LoggingFlowDocument.Blocks.Remove(LoggingFlowDocument.Blocks.ElementAt(MAX_LINES));
                }
            }
            catch
            {
                // DO NOT attempt to log an exception in a method that displays log messages...
            }
        }

        private void OpenLogFile()
        { 
            string filePath = EasyToolData_TestApp.Log.LogFile;
            if (!System.IO.File.Exists(filePath)) { return; }
            System.Diagnostics.Process.Start(filePath);
        }


        private Brush LogTypeToBrush(MessageType Type)
        {
            switch (Type)
            {
                default: return (Brush)App.Current.Resources["White_Bright"];
                case MessageType.DEBUG: return (Brush)App.Current.Resources["White_Dark"];
                case MessageType.EXCEPTION: return (Brush)App.Current.Resources["Magenta_Bright"];
                case MessageType.STOP_ERROR: return (Brush)App.Current.Resources["Red_Bright"];
                case MessageType.INFO: return (Brush)App.Current.Resources["Green_Bright"];
                case MessageType.STATUS: return (Brush)App.Current.Resources["Blue_ExtraBright"];
                case MessageType.TRACE_LOG: return (Brush)App.Current.Resources["Yellow_Bright"];
                case MessageType.WARNING: return (Brush)App.Current.Resources["Orange_Bright"];
            }
        }

        public static string MessageTypeToHeaderString(MessageType Type)
        {
            switch (Type)
            {
                default: return "  Log:  "; // "None"
                case MessageType.DEBUG: return "  Debug:  ";
                case MessageType.EXCEPTION: return "  Exception:  ";
                case MessageType.STOP_ERROR: return "  Error:  ";
                case MessageType.INFO: return "  Info:  ";
                case MessageType.STATUS: return "  Status:  ";
                case MessageType.TRACE_LOG: return "  Trace:  ";
                case MessageType.WARNING: return "  Warning:  ";
            }   
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}

