
namespace Okuma.Scout.TestApp.net4.ViewModels
{
    using System.ComponentModel;
    using System.Threading;


    class CustomApiViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties

        private bool? _capiLatheSpecial;
        public bool? CapiLatheSpecial
        {
            get { return _capiLatheSpecial; }
            set
            {
                _capiLatheSpecial = value;
                OnPropertyChanged("CapiLatheSpecial");
            }
        }

        private string _capiLatheSpecialVersion;
        public string CapiLatheSpecialVersion
        {
            get { return _capiLatheSpecialVersion; }
            set
            {
                _capiLatheSpecialVersion = value;
                OnPropertyChanged("CapiLatheSpecialVersion");
            }
        }

        private bool? _capiLatheCommand;
        public bool? CapiLatheCommand
        {
            get { return _capiLatheCommand; }
            set
            {
                _capiLatheCommand = value;
                OnPropertyChanged("CapiLatheCommand");
            }
        }

        private string _capiLatheCommandVersion;
        public string CapiLatheCommandVersion
        {
            get { return _capiLatheCommandVersion; }
            set
            {
                _capiLatheCommandVersion = value;
                OnPropertyChanged("CapiLatheCommandVersion");
            }
        }

        private bool? _capiLatheData;
        public bool? CapiLatheData
        {
            get { return _capiLatheData; }
            set
            {
                _capiLatheData = value;
                OnPropertyChanged("CapiLatheData");
            }
        }

        private string _capiLatheDataVersion;
        public string CapiLatheDataVersion
        {
            get { return _capiLatheDataVersion; }
            set
            {
                _capiLatheDataVersion = value;
                OnPropertyChanged("CapiLatheDataVersion");
            }
        }

        private bool? _capiMachiningCenterSpecial;
        public bool? CapiMachiningCenterSpecial
        {
            get { return _capiMachiningCenterSpecial; }
            set
            {
                _capiMachiningCenterSpecial = value;
                OnPropertyChanged("CapiMachiningCenterSpecial");
            }
        }

        private string _capiMachiningCenterSpecialVersion;
        public string CapiMachiningCenterSpecialVersion
        {
            get { return _capiMachiningCenterSpecialVersion; }
            set
            {
                _capiMachiningCenterSpecialVersion = value;
                OnPropertyChanged("CapiMachiningCenterSpecialVersion");
            }
        }

        private bool? _capiMachiningCenterCommand;
        public bool? CapiMachiningCenterCommand
        {
            get { return _capiMachiningCenterCommand; }
            set
            {
                _capiMachiningCenterCommand = value;
                OnPropertyChanged("CapiMachiningCenterCommand");
            }
        }

        private string _capiMachiningCenterCommandVersion;
        public string CapiMachiningCenterCommandVersion
        {
            get { return _capiMachiningCenterCommandVersion; }
            set
            {
                _capiMachiningCenterCommandVersion = value;
                OnPropertyChanged("CapiMachiningCenterCommandVersion");
            }
        }

        private bool? _capiMachiningCenterData;
        public bool? CapiMachiningCenterData
        {
            get { return _capiMachiningCenterData; }
            set
            {
                _capiMachiningCenterData = value;
                OnPropertyChanged("CapiMachiningCenterData");
            }
        }

        private string _capiMachiningCenterDataVersion;
        public string CapiMachiningCenterDataVersion
        {
            get { return _capiMachiningCenterDataVersion; }
            set
            {
                _capiMachiningCenterDataVersion = value;
                OnPropertyChanged("CapiMachiningCenterDataVersion");
            }
        }

        private bool? _capiGrinderCommand;
        public bool? CapiGrinderCommand
        {
            get { return _capiGrinderCommand; }
            set
            {
                _capiGrinderCommand = value;
                OnPropertyChanged("CapiGrinderCommand");
            }
        }

        private string _capiGrinderCommandVersion;
        public string CapiGrinderCommandVersion
        {
            get { return _capiGrinderCommandVersion; }
            set
            {
                _capiGrinderCommandVersion = value;
                OnPropertyChanged("CapiGrinderCommandVersion");
            }
        }

        private bool? _capiGrinderData;
        public bool? CapiGrinderData
        {
            get { return _capiGrinderData; }
            set
            {
                _capiGrinderData = value;
                OnPropertyChanged("CapiGrinderData");
            }
        }

        private string _capiGrinderDataVersion;
        public string CapiGrinderDataVersion
        {
            get { return _capiGrinderDataVersion; }
            set
            {
                _capiGrinderDataVersion = value;
                OnPropertyChanged("CapiGrinderDataVersion");
            }
        }

        private string _capiVersion;
        public string CapiVersion
        {
            get { return _capiVersion; }
            set
            {
                _capiVersion = value;
                OnPropertyChanged("CapiVersion");
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
                        (s) => { ExecuteCustomApiTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Methods

        private void ExecuteCustomApiTests()
        {
            // OSP API Files Exist
            // The process of gathering all API files information can take up to a 
            // few seconds. To prevent locking up the User Interface, the retrieval
            // of this information is performed using a thread.
            Thread getApiFilesInfo = new Thread(new ThreadStart(this.ApiFiles));
            getApiFilesInfo.Name = "GetApiFileInfoThread";
            getApiFilesInfo.Priority = ThreadPriority.Normal;
            getApiFilesInfo.Start();


            Okuma.Scout.VersionInformation ver = Okuma.Scout.ThincApi.CAPIVersion;

            switch (ver.Result)
            {
                case Scout.Enums.ApiVersionCheckResult.MachineTypeNotSupported:
                    {
                        CapiVersion = "N/A";
                        break;
                    }
                case Scout.Enums.ApiVersionCheckResult.MissingApiFiles:
                    {
                        CapiVersion = "CAPI files missing";
                        break;
                    }
                case Scout.Enums.ApiVersionCheckResult.MissingCrossReference:
                    {
                        CapiVersion = "Version Cross Reference missing.";
                        break;
                    }
                case Scout.Enums.ApiVersionCheckResult.UnknownVersion:
                    {
                        CapiVersion = "Unknown CAPI version.";
                        break;
                    }
                case Scout.Enums.ApiVersionCheckResult.VersionRecognized:
                    {
                        CapiVersion = ver.CustomApiVersion;
                        break;
                    }
                default:
                    {
                        CapiVersion = "Error";
                        break;
                    }
            }
        }

        /// <summary>
        /// Using Scout, acquire information related to API files.
        /// Runs on a separate thread started by the <see cref="Button_FileInfo_Click"/> method.
        /// </summary>
        private void ApiFiles()
        {

            // Lathe Files Exist?
            CapiLatheSpecial = Okuma.Scout.OspFileInfo.OspLatheSpecialApi_Exists;
            CapiLatheCommand = Okuma.Scout.OspFileInfo.OspLatheCommandApi_Exists;
            CapiLatheData = Okuma.Scout.OspFileInfo.OspLatheDataApi_Exists;

            // Machining Center Files Exist?
            CapiMachiningCenterSpecial = Okuma.Scout.OspFileInfo.OspMachiningCenterSpecialApi_Exists;
            CapiMachiningCenterCommand = Okuma.Scout.OspFileInfo.OspMachiningCenterCommandApi_Exists;
            CapiMachiningCenterData = Okuma.Scout.OspFileInfo.OspMachiningCenterDataApi_Exists;

            // Grinder Files Exist?
            CapiGrinderCommand = Okuma.Scout.OspFileInfo.OspGrinderCommandApi_Exists;
            CapiGrinderData = Okuma.Scout.OspFileInfo.OspGrinderDataApi_Exists;

            // Lathe File Versions
            CapiLatheSpecialVersion = Okuma.Scout.OspFileInfo.OspLatheSpecialApi_Version;
            CapiLatheCommandVersion = Okuma.Scout.OspFileInfo.OspLatheCommandApi_Version;
            CapiLatheDataVersion = Okuma.Scout.OspFileInfo.OspLatheDataApi_Version;

            // Machining Center File Versions
            CapiMachiningCenterSpecialVersion = Okuma.Scout.OspFileInfo.OspMachiningCenterSpecialApi_Version;
            CapiMachiningCenterCommandVersion = Okuma.Scout.OspFileInfo.OspMachiningCenterCommandApi_Version;
            CapiMachiningCenterDataVersion = Okuma.Scout.OspFileInfo.OspMachiningCenterDataApi_Version;

            // Grinder File Versions
            CapiGrinderCommandVersion = Okuma.Scout.OspFileInfo.OspGrinderCommandApi_Version;
            CapiGrinderDataVersion = Okuma.Scout.OspFileInfo.OspGrinderDataApi_Version;
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
