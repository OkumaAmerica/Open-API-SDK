using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma.Scout.TestApp.net40.ViewModels
{
    using System.ComponentModel;
    using System.Threading;


    class OperatingSystemViewModel : INotifyPropertyChanged
    {

        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _edition;
        public string Edition
        {
            get { return _edition; }
            set
            {
                _edition = value;
                OnPropertyChanged("Edition");
            }
        }

        private string _servicePack;
        public string ServicePack
        {
            get { return _servicePack; }
            set
            {
                _servicePack = value;
                OnPropertyChanged("ServicePack");
            }
        }

        private string _version;
        public string OSVersion
        {
            get { return _version; }
            set
            {
                _version = value;
                OnPropertyChanged("OSVersion");
            }
        }

        private Okuma.Scout.Enums.ProcessorArchitecture _processorBits;
        public Okuma.Scout.Enums.ProcessorArchitecture ProcessorBits
        {
            get { return _processorBits; }
            set
            {
                _processorBits = value;
                OnPropertyChanged("ProcessorBits");
            }
        }

        private Okuma.Scout.Enums.SoftwareArchitecture _osBits;
        public Okuma.Scout.Enums.SoftwareArchitecture OSBits
        {
            get { return _osBits; }
            set
            {
                _osBits = value;
                OnPropertyChanged("OSBits");
            }
        }

        private string _versionTitle;
        public string VersionTitle
        {
            get { return _versionTitle; }
            set
            {
                _versionTitle = value;
                OnPropertyChanged("VersionTitle");
            }
        }

        private string _versionComment;
        public string VersionComment
        {
            get { return _versionComment; }
            set
            {
                _versionComment = value;
                OnPropertyChanged("VersionComment");
            }
        }

        private string _versionConfigDate;
        public string VersionConfigDate
        {
            get { return _versionConfigDate; }
            set
            {
                _versionConfigDate = value;
                OnPropertyChanged("VersionConfigDate");
            }
        }

        private string _versionConfigVersion;
        public string VersionConfigVersion
        {
            get { return _versionConfigVersion; }
            set
            {
                _versionConfigVersion = value;
                OnPropertyChanged("VersionConfigVersion");
            }
        }

        private string _versionLanguage;
        public string VersionLanguage
        {
            get { return _versionLanguage; }
            set
            {
                _versionLanguage = value;
                OnPropertyChanged("VersionLanguage");
            }
        }

        private string _versionTarget;
        public string VersionTarget
        {
            get { return _versionTarget; }
            set
            {
                _versionTarget = value;
                OnPropertyChanged("VersionTarget");
            }
        }

        private string _envMachineName;
        public string EnvMachineName
        {
            get { return _envMachineName; }
            set
            {
                _envMachineName = value;
                OnPropertyChanged("EnvMachineName");
            }
        }

        private string _envOsVersion;
        public string EnvOsVersion
        {
            get { return _envOsVersion; }
            set
            {
                _envOsVersion = value;
                OnPropertyChanged("EnvOsVersion");
            }
        }

        private int _envProcessorCount;
        public int EnvProcessorCount
        {
            get { return _envProcessorCount; }
            set
            {
                _envProcessorCount = value;
                OnPropertyChanged("EnvProcessorCount");
            }
        }

        private string _envUserName;
        public string EnvUserName
        {
            get { return _envUserName; }
            set
            {
                _envUserName = value;
                OnPropertyChanged("EnvUserName");
            }
        }

        private string _envUserDomain;
        public string EnvUserDomain
        {
            get { return _envUserDomain; }
            set
            {
                _envUserDomain = value;
                OnPropertyChanged("EnvUserDomain");
            }
        }

        private System.Security.Principal.WindowsBuiltInRole _accessLevel;
        public System.Security.Principal.WindowsBuiltInRole AccessLevel
        {
            get { return _accessLevel; }
            set
            {
                _accessLevel = value;
                OnPropertyChanged("AccessLevel");
            }
        }

        private bool? _internetConnection;
        public bool? InternetConnection
        {
            get { return _internetConnection; }
            set
            {
                _internetConnection = value;
                OnPropertyChanged("InternetConnection");
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
                        (s) => { ExecuteOSTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Methods

        private void ExecuteOSTests()
        {
            // The process of gathering Operating System information can take up to a 
            // few seconds. To prevent locking up the User Interface, the retrieval
            // of this information is performed using a thread.
            // Particularly, OS.InternetConnection takes time to obtain a result.
            Thread getOSInfo = new Thread(new ThreadStart(this.OSInfo));
            getOSInfo.Name = "GetApiFileInfoThread";
            getOSInfo.Priority = ThreadPriority.Normal;
            getOSInfo.Start();

        }


        /// <summary>
        /// Using Scout, acquire information about the Operating System.
        /// Runs on a separate thread started by the <see cref="Button_OS_Click"/> method.
        /// </summary>
        private void OSInfo()
        {
            Name = Okuma.Scout.OS.Name;
            Edition = Okuma.Scout.OS.Edition;
            ServicePack = Okuma.Scout.OS.ServicePack;
            OSVersion = Okuma.Scout.OS.Version.ToString();
            ProcessorBits = Okuma.Scout.OS.ProcessorBits;
            OSBits = Okuma.Scout.OS.OSBits;

            VersionTitle = Okuma.Scout.OS.VersionTitle;
            VersionComment = Okuma.Scout.OS.VersionComment;
            VersionConfigDate = Okuma.Scout.OS.VersionConfigDate;
            VersionConfigVersion = Okuma.Scout.OS.VersionConfigVersion;
            VersionLanguage = Okuma.Scout.OS.VersionLanguage;
            VersionTarget =  Okuma.Scout.OS.VersionTarget;

            EnvMachineName = Environment.MachineName;
            EnvOsVersion = Environment.OSVersion.ToString();
            EnvProcessorCount = Environment.ProcessorCount;
            EnvUserName = Environment.UserName;
            EnvUserDomain = Environment.UserDomainName;

            AccessLevel = Okuma.Scout.OS.GetAccessLevel();
            InternetConnection = Okuma.Scout.OS.InternetConnection;
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