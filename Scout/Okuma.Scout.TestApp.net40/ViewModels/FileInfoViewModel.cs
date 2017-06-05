
namespace Okuma.Scout.TestApp.net40.ViewModels
{
    using System.ComponentModel;

    class FileInfoViewModel : INotifyPropertyChanged
    {

        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties
        
        private bool? _pcNcmExists;
        public bool? PcNcmExists
        {
            get { return _pcNcmExists; }
            set
            {
                _pcNcmExists = value;
                OnPropertyChanged("PcNcmExists");
            }
        }

        private bool? _plcSpecCodeFileExists;
        public bool? PlcSpecCodeFileExists
        {
            get { return _plcSpecCodeFileExists; }
            set
            {
                _plcSpecCodeFileExists = value;
                OnPropertyChanged("PlcSpecCodeFileExists");
            }
        }

        private bool? _ncSpecCodeFileExists;
        public bool? NcSpecCodeFileExists
        {
            get { return _ncSpecCodeFileExists; }
            set
            {
                _ncSpecCodeFileExists = value;
                OnPropertyChanged("NcSpecCodeFileExists");
            }
        }

        private bool? _ncbSpecCodeFileExists;
        public bool? NcbSpecCodeFileExists
        {
            get { return _ncbSpecCodeFileExists; }
            set
            {
                _ncbSpecCodeFileExists = value;
                OnPropertyChanged("NcbSpecCodeFileExists");
            }
        }

        private bool? _thincApiLicenseFileExists;
        public bool? ThincApiLicenseFileExists
        {
            get { return _thincApiLicenseFileExists; }
            set
            {
                _thincApiLicenseFileExists = value;
                OnPropertyChanged("ThincApiLicenseFileExists");
            }
        }

        private bool? _ebiFryExists;
        public bool? EbiFryExists
        {
            get { return _ebiFryExists; }
            set
            {
                _ebiFryExists = value;
                OnPropertyChanged("EbiFryExists");
            }
        }

        private bool? _apiNotifierExists;
        public bool? ApiNotifierExists
        {
            get { return _apiNotifierExists; }
            set
            {
                _apiNotifierExists = value;
                OnPropertyChanged("ApiNotifierExists");
            }
        }

        private bool? _softSwitchExists;
        public bool? SoftSwitchExists
        {
            get { return _softSwitchExists; }
            set
            {
                _softSwitchExists = value;
                OnPropertyChanged("SoftSwitchExists");
            }
        }

        private bool? _dataManagementCardExists;
        public bool? DataManagementCardExists
        {
            get { return _dataManagementCardExists; }
            set
            {
                _dataManagementCardExists = value;
                OnPropertyChanged("DataManagementCardExists");
            }
        }

        private bool? _piodLibExists;
        public bool? PiodLibExists
        {
            get { return _piodLibExists; }
            set
            {
                _piodLibExists = value;
                OnPropertyChanged("PiodLibExists");
            }
        }

        private bool? _ospGestureExists;
        public bool? OspGestureExists
        {
            get { return _ospGestureExists; }
            set
            {
                _ospGestureExists = value;
                OnPropertyChanged("OspGestureExists");
            }
        }

        private bool? _ospTouchExists;
        public bool? OspTouchExists
        {
            get { return _ospTouchExists; }
            set
            {
                _ospTouchExists = value;
                OnPropertyChanged("OspTouchExists");
            }
        }

        private string _thincApiLicenseLastModified;
        public string ThincApiLicenseLastModified
        {
            get { return _thincApiLicenseLastModified; }
            set
            {
                _thincApiLicenseLastModified = value;
                OnPropertyChanged("ThincApiLicenseLastModified");
            }
        }

        private string _ebiFryVersion;
        public string EbiFryVersion
        {
            get { return _ebiFryVersion; }
            set
            {
                _ebiFryVersion = value;
                OnPropertyChanged("EbiFryVersion");
            }
        }

        private string _apiNotifierVersion;
        public string ApiNotifierVersion
        {
            get { return _apiNotifierVersion; }
            set
            {
                _apiNotifierVersion = value;
                OnPropertyChanged("ApiNotifierVersion");
            }
        }
        private string _softSwitchVersion;
        public string SoftSwitchVersion
        {
            get { return _softSwitchVersion; }
            set
            {
                _softSwitchVersion = value;
                OnPropertyChanged("SoftSwitchVersion");
            }
        }

        private string _dataManagementCardLastModified;
        public string DataManagementCardLastModified
        {
            get { return _dataManagementCardLastModified; }
            set
            {
                _dataManagementCardLastModified = value;
                OnPropertyChanged("DataManagementCardLastModified");
            }
        }

        private string _piodLibVersion;
        public string PiodLibVersion
        {
            get { return _piodLibVersion; }
            set
            {
                _piodLibVersion = value;
                OnPropertyChanged("PiodLibVersion");
            }
        }

        private string _ospGestureVersion;
        public string OspGestureVersion
        {
            get { return _ospGestureVersion; }
            set
            {
                _ospGestureVersion = value;
                OnPropertyChanged("OspGestureVersion");
            }
        }

        private string _ospTouchVersion;
        public string OspTouchVersion
        {
            get { return _ospTouchVersion; }
            set
            {
                _ospTouchVersion = value;
                OnPropertyChanged("OspTouchVersion");
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
                        (s) => { ExecuteFileInfoTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Methods

        private void ExecuteFileInfoTests()
        {
            // PC NC Master Control Panel Exist
            PcNcmExists = Okuma.Scout.OspFileInfo.PcNcMasterExists;

            // Spec Code Files Exist
            PlcSpecCodeFileExists = Okuma.Scout.SpecCode.PLC.MachineSpecCodeFileExists;
            NcSpecCodeFileExists = Okuma.Scout.SpecCode.NC.MachineSpecCodeFileExists;
            NcbSpecCodeFileExists = Okuma.Scout.SpecCode.NCB.MachineSpecCodeFileExists;

            // Misc Files Exist
            DataManagementCardExists = Okuma.Scout.OspFileInfo.DMCExists;
            ThincApiLicenseFileExists = Okuma.Scout.OspFileInfo.ThincApiLicenseExists;
            
            ApiNotifierExists = Okuma.Scout.OspFileInfo.ApiNotifierExists; 
            ApiNotifierVersion = Okuma.Scout.OspFileInfo.ApiNotifierVersion;

            EbiFryExists = Okuma.Scout.OspFileInfo.EbyFryExists;
            EbiFryVersion = Okuma.Scout.OspFileInfo.EbiFryVersion;

            SoftSwitchExists = Okuma.Scout.OspFileInfo.SoftSwitchExists;
            SoftSwitchVersion = Okuma.Scout.OspFileInfo.SoftSwitchVersion;

            PiodLibExists = Okuma.Scout.OspFileInfo.PiodLib_Exists;
            PiodLibVersion = Okuma.Scout.OspFileInfo.PiodLib_Version.ToString();

            OspGestureExists = Okuma.Scout.OspFileInfo.OspGesture_Exists;
            OspGestureVersion = Okuma.Scout.OspFileInfo.OspGesture_Version.ToString();
            OspTouchExists = Okuma.Scout.OspFileInfo.OspTouch_Exists;
            OspTouchVersion = Okuma.Scout.OspFileInfo.OspTouch_Version.ToString();

            // Modified
            DataManagementCardLastModified = Okuma.Scout.OspFileInfo.DMCModifiedDate;
            ThincApiLicenseLastModified = Okuma.Scout.OspFileInfo.ThincApiLicenseModifiedDate;
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
