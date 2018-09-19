
namespace Okuma.Scout.TestApp.net4.ViewModels
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.ComponentModel;
    using System.Windows.Documents; 

    class ErrorHandlingViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Log Font </summary>
        private static FontFamily MessageFont = new FontFamily("Consolas");

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;


        // Constructor

        public ErrorHandlingViewModel()
        { 
            GenerateFlowLog();

            // Subscribe to the SCOUT library Error Handler
            SubscribeToScoutErrorHandler();

            // Subscribe to the Test Application Error Handler
            Helpers.ErrorHandler.AppErrorReporterEvent += ReportAppError;

            ShowDebuggingInformation = true;
        }


        //Properties

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

        private bool _showDebuggingInformation;
        public bool ShowDebuggingInformation
        {
            get { return _showDebuggingInformation; }
            set
            {
                _showDebuggingInformation = value;
                Okuma.Scout.Error.ShowDebugInfo = value;
                OnPropertyChanged("ShowDebuggingInformation");
            }
        }




        // Commands

        private DelegateCommand<bool> _subscribeToErrorHandlerCommand;
        public DelegateCommand<bool> SubscribeToErrorHandlerCommand
        {
            get
            {
                if (_subscribeToErrorHandlerCommand == null)
                {
                    _subscribeToErrorHandlerCommand = new DelegateCommand<bool>(
                        (s) => { SubscribeToScoutErrorHandler(); },
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
                        (s) => { UnSubscribeFromScoutErrorHandler(); },
                        (s) => { return UnSubscribeCanExecute; }
                        );
                }
                return _unSubscribeFromErrorHandlerCommand;
            }
        }

        private DelegateCommand<bool> _generateInfoCommand;
        public DelegateCommand<bool> GenerateInfoCommand
        {
            get
            {
                if (_generateInfoCommand == null)
                {
                    _generateInfoCommand = new DelegateCommand<bool>(
                        (s) => { Helpers.ErrorHandler.GenerateInfo(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _generateInfoCommand;
            }
        }

        private DelegateCommand<bool> _generateWarningCommand;
        public DelegateCommand<bool> GenerateWarningCommand
        {
            get
            {
                if (_generateWarningCommand == null)
                {
                    _generateWarningCommand = new DelegateCommand<bool>(
                        (s) => { Helpers.ErrorHandler.GenerateWarning(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _generateWarningCommand;
            }
        }

        private DelegateCommand<bool> _generateErrorCommand;
        public DelegateCommand<bool> GenerateErrorCommand
        {
            get
            {
                if (_generateErrorCommand == null)
                {
                    _generateErrorCommand = new DelegateCommand<bool>(
                        (s) => { Helpers.ErrorHandler.GenerateError(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _generateErrorCommand;
            }
        }

        private DelegateCommand<bool> _generateExceptionCommand;
        public DelegateCommand<bool> GenerateExceptionCommand
        {
            get
            {
                if (_generateExceptionCommand == null)
                {
                    _generateExceptionCommand = new DelegateCommand<bool>(
                        (s) => { Helpers.ErrorHandler.GenerateException(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _generateExceptionCommand;
            }
        }
        

        // Methods

        /// <summary>
        /// This is the Test Application's error handler.
        /// It handles reporting from SCOUT in addition to any error 
        /// handling in the test application itself. </summary>
        /// <param name="sender"> This value will always be null for events that 
        /// come from SCOUT because the source is a static library. </param>
        /// <param name="e"> You may use any custom event arguments you like.
        /// For simplicity, this test app uses Type 'Okuma.Scout.Error.Args' to make
        /// it easy to get exception and message information from SCOUT. </param>
        private void ReportAppError(object sender, Okuma.Scout.Error.Args e)
        {
            if (e.Severity == Okuma.Scout.Enums.MessageLevel.Exception)
            {
                AppendFlowLog(LoggingFlowDocument, e.Severity, e.Exception.ToString());

                if (e.Exception.InnerException != null)
                {
                    AppendFlowLog(LoggingFlowDocument, e.Severity, e.Exception.InnerException.ToString());
                }

                // If you want the application to throw exceptions 
                // for some reason, uncomment the line below.
                // throw e.Exception;
            }
            else
            {
                // This is not an exception, thus e.Exception 
                // will be null and all of the relevant 
                // debugging information will be held in e.Message
                AppendFlowLog(LoggingFlowDocument, e.Severity, e.Message.ToString());
            }
        }


        private void SubscribeToScoutErrorHandler()
        {
            Helpers.ErrorHandler.SubscribeToScoutErrorHandler();

            // Display the subscription status
            SubscribedToReportedEvent = true;

            // Subscribing multiple times would result in duplicate lines.
            SubscribeCanExecute = false;
            UnSubscribeCanExecute = true;
        }

        private void UnSubscribeFromScoutErrorHandler()
        {
            Helpers.ErrorHandler.UnSubscribeFromScoutErrorHandler();

            // Display subscription status.
            SubscribedToReportedEvent = false;

            // Allow user to subscribe to the event again.
            SubscribeCanExecute = true;
            UnSubscribeCanExecute = false;
        }

        private FlowDocument GenerateFlowLog()
        {
            Paragraph myParagraph = new Paragraph();

            // Add some Bold text to the paragraph
            myParagraph.Inlines.Add(new Run("Logging Started " + DateTime.Now));

            // Create a FlowDocument with the paragraph and list.
            LoggingFlowDocument = new FlowDocument();
            LoggingFlowDocument.Blocks.Add(myParagraph);

            return LoggingFlowDocument;
        }

        private FlowDocument AppendFlowLog(FlowDocument log, Okuma.Scout.Enums.MessageLevel level, string msg)
        {
            FlowDocument _log = log;
            try
            {
                Paragraph p = new Paragraph();
                Run when = new Run(DateTime.Now + "    ");
                p.Inlines.Add(when);
                switch (level)
                {
                    default: // Default will be INFO
                        {
                            Run type = new Run("INFO:  ");
                            type.FontWeight = FontWeights.Bold;
                            type.Foreground = Brushes.DarkBlue;
                            p.Inlines.Add(type);
                            break;
                        }
                    case Okuma.Scout.Enums.MessageLevel.Exception:
                        {
                            Run type = new Run("EXCEPTION:  ");
                            type.FontWeight = FontWeights.Bold;
                            type.Foreground = Brushes.Fuchsia;
                            p.Inlines.Add(type);
                            break;
                        }
                    case Okuma.Scout.Enums.MessageLevel.Error:
                        {
                            Run type = new Run("ERROR:  ");
                            type.FontWeight = FontWeights.Bold;
                            type.Foreground = Brushes.Crimson;
                            p.Inlines.Add(type);
                            break;
                        }
                    case Okuma.Scout.Enums.MessageLevel.Warning:
                        {
                            Run type = new Run("WARNING:  ");
                            type.FontWeight = FontWeights.Bold;
                            type.Foreground = Brushes.OrangeRed;
                            p.Inlines.Add(type);
                            break;
                        }
                }

                Run message = new Run(msg);
                message.FontFamily = MessageFont;
                p.Inlines.Add(message);
                _log.Blocks.InsertBefore(_log.Blocks.FirstBlock, p);

                if (log.Blocks.Count() > 2000)
                {
                    log.Blocks.Remove(log.Blocks.ElementAt(2000));
                }
            }
            catch { }

            return _log;
        }
        
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}

