
namespace Okuma.Scout.TestApp.net40.ViewModels
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    using System.ComponentModel;
    using System.Windows.Documents;

    using System.Windows.Controls;
    using System.Windows.Input;


    class ErrorHandlingViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Log Font </summary>
        private FontFamily MessageFont;

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;


        // Constructor

        public ErrorHandlingViewModel()
        { 
            GenerateFlowLog();
            SubscribeToErrorHandler();
            ShowDebuggingInformation = true;
            MessageFont = new FontFamily("Consolas");
        }



        // Properties

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
                        (s) => { SubscribeToErrorHandler(); },
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
                        (s) => { UnSubscribeFromErrorHandler(); },
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
                        (s) => { GenerateInfo(); },
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
                        (s) => { GenerateWarning(); },
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
                        (s) => { GenerateError(); },
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
                        (s) => { GenerateException(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _generateExceptionCommand;
            }
        }



        // Methods

        private void SubscribeToErrorHandler()
        {
            // Subscribe to this event to view diagnostic information from Scout.dll 
            // and handle any exceptions generated by the library.
            // If this event is not subscribed to, SCOUT may generate unhandled 
            // exceptions. Additionally, minor errors / diagnostic information will 
            // be invisible / hidden from the user.
            Okuma.Scout.Error.Reporter += this.HandleScoutErrorInfo;

            // display the status of subscription status
            SubscribedToReportedEvent = true;

            // Subscribing multiple times would result in duplicate lines.
            SubscribeCanExecute = false;
            UnSubscribeCanExecute = true;
        }

        private void UnSubscribeFromErrorHandler()
        {
            // Remember to unsubscribe from this event when Scout functionality
            // is no longer required. As long as the Reporter Event is 
            // subscribed to, Scout.dll will be held in memory and not 
            // garbage collected by the CLR; even if the class which uses
            // Scout functionality loses scope.
            Okuma.Scout.Error.Reporter -= this.HandleScoutErrorInfo;

            // Display subscription status.
            SubscribedToReportedEvent = false;

            // Allow user to subscribe to the event again.
            SubscribeCanExecute = true;
            UnSubscribeCanExecute = false;
        }


        private void GenerateInfo()
        {
            Okuma.Scout.Error.TestReporter(Okuma.Scout.Enums.MessageLevel.Information);
        }

        private void GenerateWarning()
        {
            Okuma.Scout.Error.TestReporter(Okuma.Scout.Enums.MessageLevel.Warning);
        }

        private void GenerateError()
        {
            Okuma.Scout.Error.TestReporter(Okuma.Scout.Enums.MessageLevel.Error);
        }

        private void GenerateException()
        {
            Okuma.Scout.Error.TestReporter(Okuma.Scout.Enums.MessageLevel.Exception);
        }



        /// <summary>
        /// When handling the Reporter event, make sure to distinguish between 
        /// exceptions and information. In the case of an exception, e.Message
        /// will be String.Empty, while in all other cases it will contain the
        /// error information and e.Exception will be null. </summary>
        /// <param name="sender">This value will always be null because the source is a 
        /// static library.</param>
        /// <param name="e">Type 'Okuma.Scout.Error.Args', this value will
        /// contain exception and message information.</param>
        private void HandleScoutErrorInfo(object sender, Okuma.Scout.Error.Args e)
        {
            if (e.Severity == Okuma.Scout.Enums.MessageLevel.Exception)
            {
                this.PostError(e.Severity, e.Exception.ToString());

                if (e.Exception.InnerException != null)
                {
                    this.PostError(e.Severity, e.Exception.InnerException.ToString());
                }

                // At this point Scout.dll has generated an exception and you have
                // the option of handling it gracefully, or throwing it.
                // to throw the exception uncomment the line below.
                // throw e.Exception;
            }
            else
            {
                // This is not an exception, thus e.Exception will be null
                // and all of the relevant debugging information will be held
                // in e.Message
                this.PostError(e.Severity, e.Message.ToString());
            }
        }

        /// <summary>
        /// Some Scout functions in this test application are executed using threading.
        /// Because of this, cross-threading issues may arise when attempting to
        /// perform operations on the main GUI thread. </summary>
        /// <param name="level">level of error severity <c>Okuma.Scout.Enums.MessageLevel</c></param>
        /// <param name="message">If level is other than "Exception", this contains the message to be displayed.</param>
        internal void PostError(Okuma.Scout.Enums.MessageLevel level, string message)
        {
            AppendFlowLog(LoggingFlowDocument, level, message);
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

                if (log.Blocks.Count() > 200)
                {
                    log.Blocks.Remove(log.Blocks.ElementAt(200));
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

