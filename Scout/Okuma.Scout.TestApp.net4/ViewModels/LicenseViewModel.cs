
namespace Okuma.Scout.TestApp.net4.ViewModels
{
    using System;
    using System.ComponentModel;

    class LicenseViewModel : INotifyPropertyChanged
    {

        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties
       

        private Okuma.Scout.LicenseItem _dataApiLathe;
        public Okuma.Scout.LicenseItem DataApiLathe
        {
            get { return _dataApiLathe; }
            set
            {
                _dataApiLathe = value;
                OnPropertyChanged("DataApiLathe");
            }
        }

        private Okuma.Scout.LicenseItem _dataApiMachiningCenter;
        public Okuma.Scout.LicenseItem DataApiMachiningCenter
        {
            get { return _dataApiMachiningCenter; }
            set
            {
                _dataApiMachiningCenter = value;
                OnPropertyChanged("DataApiMachiningCenter");
            }
        }

        private Okuma.Scout.LicenseItem _dataApiGrinder;
        public Okuma.Scout.LicenseItem DataApiGrinder
        {
            get { return _dataApiGrinder; }
            set
            {
                _dataApiGrinder = value;
                OnPropertyChanged("DataApiGrinder");
            }
        }

        private Okuma.Scout.LicenseItem _commandApiLathe;
        public Okuma.Scout.LicenseItem CommandApiLathe
        {
            get { return _commandApiLathe; }
            set
            {
                _commandApiLathe = value;
                OnPropertyChanged("CommandApiLathe");
            }
        }

        private Okuma.Scout.LicenseItem _commandApiMachiningCenter;
        public Okuma.Scout.LicenseItem CommandApiMachiningCenter
        {
            get { return _commandApiMachiningCenter; }
            set
            {
                _commandApiMachiningCenter = value;
                OnPropertyChanged("CommandApiMachiningCenter");
            }
        }

        private Okuma.Scout.LicenseItem _commandApiGrinder;
        public Okuma.Scout.LicenseItem CommandApiGrinder
        {
            get { return _commandApiGrinder; }
            set
            {
                _commandApiGrinder = value;
                OnPropertyChanged("CommandApiGrinder");
            }
        }

        private Okuma.Scout.LicenseItem _p200Control;
        public Okuma.Scout.LicenseItem P200Control
        {
            get { return _p200Control; }
            set
            {
                _p200Control = value;
                OnPropertyChanged("P200Control");
            }
        }

        private Okuma.Scout.LicenseItem _ncCurrentAlarm;
        public Okuma.Scout.LicenseItem NCCurrentAlarm
        {
            get { return _ncCurrentAlarm; }
            set
            {
                _ncCurrentAlarm = value;
                OnPropertyChanged("NCCurrentAlarm");
            }
        }

        private Okuma.Scout.LicenseItem _userTaskIOLathe;
        public Okuma.Scout.LicenseItem UserTaskIOLathe
        {
            get { return _userTaskIOLathe; }
            set
            {
                _userTaskIOLathe = value;
                OnPropertyChanged("UserTaskIOLathe");
            }
        }

        private Okuma.Scout.LicenseItem _userTaskIOMachiningCenter;
        public Okuma.Scout.LicenseItem UserTaskIOMachiningCenter
        {
            get { return _userTaskIOMachiningCenter; }
            set
            {
                _userTaskIOMachiningCenter = value;
                OnPropertyChanged("UserTaskIOMachiningCenter");
            }
        }

        private Okuma.Scout.LicenseItem _userAlarmLathe;
        public Okuma.Scout.LicenseItem UserAlarmLathe
        {
            get { return _userAlarmLathe; }
            set
            {
                _userAlarmLathe = value;
                OnPropertyChanged("UserAlarmLathe");
            }
        }

        private Okuma.Scout.LicenseItem _userAlarmMachiningCenter;
        public Okuma.Scout.LicenseItem UserAlarmMachiningCenter
        {
            get { return _userAlarmMachiningCenter; }
            set
            {
                _userAlarmMachiningCenter = value;
                OnPropertyChanged("UserAlarmMachiningCenter");
            }
        }

        private Okuma.Scout.LicenseItem _toolID;
        public Okuma.Scout.LicenseItem ToolID
        {
            get { return _toolID; }
            set
            {
                _toolID = value;
                OnPropertyChanged("ToolID");
            }
        }

        // Commands

        private DelegateCommand<bool> _executeCommand;
        public DelegateCommand<bool> ExecuteCommand
        {
            get
            {
                if (_executeCommand == null)
                {
                    _executeCommand = new DelegateCommand<bool>(
                        (s) => { ExecuteThincApiLicenseTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Methods

        private void ExecuteThincApiLicenseTests()
        {
            System.Threading.Thread LicenseTestThread = new System.Threading.Thread(new System.Threading.ThreadStart(ThincApiLicenseTests));
            LicenseTestThread.Name = "LicenseTestThread";
            LicenseTestThread.Priority = System.Threading.ThreadPriority.Normal;
            LicenseTestThread.Start();

        }

        /// <summary>
        /// Testing license items can be slow, particularly for items which return 
        /// non valid due to exception throwing and handling overhead.  </summary>
        private void ThincApiLicenseTests()
        {
            DataApiLathe = Okuma.Scout.LicenseChecker.License_DataApi_L;
            DataApiMachiningCenter = Okuma.Scout.LicenseChecker.License_DataApi_MC;
            DataApiGrinder = Okuma.Scout.LicenseChecker.License_DataApi_G;

            CommandApiLathe = Okuma.Scout.LicenseChecker.License_CommandApi_L;
            CommandApiMachiningCenter = Okuma.Scout.LicenseChecker.License_CommandApi_MC;
            CommandApiGrinder = Okuma.Scout.LicenseChecker.License_CommandApi_G;

            P200Control = Okuma.Scout.LicenseChecker.License_ControlTypeP200;

            NCCurrentAlarm = Okuma.Scout.LicenseChecker.License_NcCurrentAlarm;

            UserTaskIOLathe = Okuma.Scout.LicenseChecker.License_UserTaskIO_L;
            UserTaskIOMachiningCenter = Okuma.Scout.LicenseChecker.License_UserTaskIO_MC;

            UserAlarmLathe = Okuma.Scout.LicenseChecker.License_UserAlarm_L;
            UserAlarmMachiningCenter = Okuma.Scout.LicenseChecker.License_UserAlarm_MC;

            ToolID = Okuma.Scout.LicenseChecker.License_ToolID_MC;
        }


        /// <summary>
        /// Return just the date and format as string if the license expires, otherwise return "N/A" </summary>
        /// <param name="expires">Boolean value Okuma.Scout.LicenseItem.Expires </param>
        /// <param name="expireDate">DateTime Okuma.Scout.LicenseItem.ExpiryDate </param>
        /// <returns>type string</returns>
        private static string FormatExpireDate(bool? expires, DateTime expireDate)
        {
            if (expires == true)
            {
                return expireDate.ToString("dd/MM/yyyy");
            }
            else
            {
                return "N/A";
            }
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