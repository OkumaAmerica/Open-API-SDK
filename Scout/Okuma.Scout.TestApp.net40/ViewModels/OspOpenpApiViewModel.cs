

namespace Okuma.Scout.TestApp.net40.ViewModels
{ 
    using System.ComponentModel;

    public class OspOpenpApiViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        /// <summary> Used to prevent unnecessary repeat checks of ready status </summary>
        private bool apiHasBeenInitializedOrIsReady = false;

        // Constructor

        public OspOpenpApiViewModel()
        {
            InitializeApiCanExecute = false;
            ApiFunctionsCanExecute = false;
        }


        // Properties

        private bool _initializeApiCanExecute;
        public bool InitializeApiCanExecute
        {
            get { return _initializeApiCanExecute; }
            set
            {
                _initializeApiCanExecute = value;
                OnPropertyChanged("InitializeApiCanExecute");
                InitializeApiCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _apiFunctionsCanExecute;
        public bool ApiFunctionsCanExecute
        {
            get { return _apiFunctionsCanExecute; }
            set
            {
                _apiFunctionsCanExecute = value;
                OnPropertyChanged("ApiFunctionsCanExecute");
                ExecuteApiFunctionsCommand.RaiseCanExecuteChanged();
            }
        }

        private bool? _thinc_API_SpecCodeValid;
        public bool? THINC_API_SpecCodeValid
        {
            get { return _thinc_API_SpecCodeValid; }
            set
            {
                _thinc_API_SpecCodeValid = value;
                OnPropertyChanged("THINC_API_SpecCodeValid");
            }
        }

        private bool? _thinc_API_Installed;
        public bool? THINC_API_Installed
        {
            get { return _thinc_API_Installed; }
            set
            {
                _thinc_API_Installed = value;
                OnPropertyChanged("THINC_API_Installed");
            }
        }

        private string _thinc_API_InstallType;
        public string THINC_API_InstallType
        {
            get { return _thinc_API_InstallType; }
            set
            {
                _thinc_API_InstallType = value;
                OnPropertyChanged("THINC_API_InstallType");
            }
        }

        private string _thinc_API_Version;
        public string THINC_API_Version
        {
            get { return _thinc_API_Version; }
            set
            {
                _thinc_API_Version = value;
                OnPropertyChanged("THINC_API_Version");
            }
        }

        private bool? _latheCommandApi;
        public bool? LatheCommandApi
        {
            get { return _latheCommandApi; }
            set
            {
                _latheCommandApi = value;
                OnPropertyChanged("LatheCommandApi");
            }
        }

        private string _latheCommandApiVersion;
        public string LatheCommandApiVersion
        {
            get { return _latheCommandApiVersion; }
            set
            {
                _latheCommandApiVersion = value;
                OnPropertyChanged("LatheCommandApiVersion");
            }
        }

        private bool? _latheDataApi;
        public bool? LatheDataApi
        {
            get { return _latheDataApi; }
            set
            {
                _latheDataApi = value;
                OnPropertyChanged("LatheDataApi");
            }
        }

        private string _latheDataApiVersion;
        public string LatheDataApiVersion
        {
            get { return _latheDataApiVersion; }
            set
            {
                _latheDataApiVersion = value;
                OnPropertyChanged("LatheDataApiVersion");
            }
        }

        private bool? _machiningCenterCommandApi;
        public bool? MachiningCenterCommandApi
        {
            get { return _machiningCenterCommandApi; }
            set
            {
                _machiningCenterCommandApi = value;
                OnPropertyChanged("MachiningCenterCommandApi");
            }
        }

        private string _machiningCenterCommandApiVersion;
        public string MachiningCenterCommandApiVersion
        {
            get { return _machiningCenterCommandApiVersion; }
            set
            {
                _machiningCenterCommandApiVersion = value;
                OnPropertyChanged("MachiningCenterCommandApiVersion");
            }
        }

        private bool? _machiningCenterDataApi;
        public bool? MachiningCenterDataApi
        {
            get { return _machiningCenterDataApi; }
            set
            {
                _machiningCenterDataApi = value;
                OnPropertyChanged("MachiningCenterDataApi");
            }
        }

        private string _machiningCenterDataApiVersion;
        public string MachiningCenterDataApiVersion
        {
            get { return _machiningCenterDataApiVersion; }
            set
            {
                _machiningCenterDataApiVersion = value;
                OnPropertyChanged("MachiningCenterDataApiVersion");
            }
        }

        private bool? _grinderCommandApi;
        public bool? GrinderCommandApi
        {
            get { return _grinderCommandApi; }
            set
            {
                _grinderCommandApi = value;
                OnPropertyChanged("GrinderCommandApi");
            }
        }

        private string _grinderCommandApiVersion;
        public string GrinderCommandApiVersion
        {
            get { return _grinderCommandApiVersion; }
            set
            {
                _grinderCommandApiVersion = value;
                OnPropertyChanged("GrinderCommandApiVersion");
            }
        }

        private bool? _grinderDataApi;
        public bool? GrinderDataApi
        {
            get { return _grinderDataApi; }
            set
            {
                _grinderDataApi = value;
                OnPropertyChanged("GrinderDataApi");
            }
        }

        private string _grinderDataApiVersion;
        public string GrinderDataApiVersion
        {
            get { return _grinderDataApiVersion; }
            set
            {
                _grinderDataApiVersion = value;
                OnPropertyChanged("GrinderDataApiVersion");
            }
        }

        private bool? _flexNetLibrary;
        public bool? FlexNetLibrary
        {
            get { return _flexNetLibrary; }
            set
            {
                _flexNetLibrary = value;
                OnPropertyChanged("FlexNetLibrary");
            }
        }

        private string _flexNetLibraryVersion;
        public string FlexNetLibraryVersion
        {
            get { return _flexNetLibraryVersion; }
            set
            {
                _flexNetLibraryVersion = value;
                OnPropertyChanged("FlexNetLibraryVersion");
            }
        }

        private string _thinc_API_Ready;
        public string THINC_API_Ready
        {
            get { return _thinc_API_Ready; }
            set
            {
                _thinc_API_Ready = value;
                OnPropertyChanged("THINC_API_Ready");
            }
        }

        private string _thinc_API_Instantiated;
        public string THINC_API_Instantiated
        {
            get { return _thinc_API_Instantiated; }
            set
            {
                _thinc_API_Instantiated = value;
                OnPropertyChanged("THINC_API_Instantiated");
            }
        }

        private string _api_MachineName;
        public string API_MachineName
        {
            get { return _api_MachineName; }
            set
            {
                _api_MachineName = value;
                OnPropertyChanged("API_MachineName");
            }
        }

        private string _api_SerialNumber;
        public string API_SerialNumber
        {
            get { return _api_SerialNumber; }
            set
            {
                _api_SerialNumber = value;
                OnPropertyChanged("API_SerialNumber");
            }
        }

        private string _api_CommonVariable;
        public string API_CommonVariable
        {
            get { return _api_CommonVariable; }
            set
            {
                _api_CommonVariable = value;
                OnPropertyChanged("API_CommonVariable");
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
                        (s) => { ExecuteOspOpenApiTests(); }, 
                        (s) => { return AlwaysExecute; } 
                        );
                }
                return _executeCommand;
            }
        }

        private DelegateCommand<bool> _InitializeApiCommand;
        public DelegateCommand<bool> InitializeApiCommand
        {
            get
            {
                if (_InitializeApiCommand == null)
                {
                    _InitializeApiCommand = new DelegateCommand<bool>(
                        (s) => { InitializeApi(); }, 
                        (s) => { return InitializeApiCanExecute; } 
                        );
                }
                return _InitializeApiCommand;
            }
        }

        private DelegateCommand<bool> _executeApiFunctionsCommand;
        public DelegateCommand<bool> ExecuteApiFunctionsCommand
        {
            get
            {
                if (_executeApiFunctionsCommand == null)
                {
                    _executeApiFunctionsCommand = new DelegateCommand<bool>(
                        (s) => { ExecuteApiFunctionsAction(); }, 
                        (s) => { return ApiFunctionsCanExecute; } 
                        );
                }
                return _executeApiFunctionsCommand;
            }
        }










        // Methods

        private void ExecuteOspOpenApiTests()
        {
            // THINC API Install Info
            THINC_API_SpecCodeValid = Okuma.Scout.SpecCode.ThincApiSpec;
            THINC_API_Installed = Okuma.Scout.ThincApi.Installed;
            THINC_API_InstallType = Okuma.Scout.ThincApi.InstallType;

            if (Okuma.Scout.ThincApi.InstallVersion.Result == Okuma.Scout.Enums.ApiVersionCheckResult.VersionRecognized)
            {
                THINC_API_Version = Okuma.Scout.ThincApi.InstallVersion.ApiVersion.ToString();
            }
            else
            {
                THINC_API_Version = Okuma.Scout.ThincApi.InstallVersion.Result.ToString();
            }

            // THINC API Installed Libraries
            LatheCommandApi = Okuma.Scout.ThincApi.GACExist_CommandApi_Lathe;
            LatheDataApi = Okuma.Scout.ThincApi.GACExist_DataApi_Lathe;
            MachiningCenterCommandApi = Okuma.Scout.ThincApi.GACExist_CommandApi_MachiningCenter;
            MachiningCenterDataApi = Okuma.Scout.ThincApi.GACExist_DataApi_MachiningCenter;
            GrinderCommandApi = Okuma.Scout.ThincApi.GACExist_CommandApi_Grinder;
            GrinderDataApi = Okuma.Scout.ThincApi.GACExist_DataApi_Grinder;
            FlexNetLibrary = Okuma.Scout.ThincApi.GACExist_FlexNet;

            // THINC API Installed Library Versions
            LatheCommandApiVersion = Okuma.Scout.ThincApi.CommandApiVersionInGAC_Lathe;
            LatheDataApiVersion = Okuma.Scout.ThincApi.DataApiVersionInGAC_Lathe;
            MachiningCenterCommandApiVersion = Okuma.Scout.ThincApi.CommandApiVersionInGAC_MachiningCenter;
            MachiningCenterDataApiVersion = Okuma.Scout.ThincApi.DataApiVersionInGAC_MachiningCenter;
            GrinderCommandApiVersion = Okuma.Scout.ThincApi.CommandApiVersionInGAC_Grinder;
            GrinderDataApiVersion = Okuma.Scout.ThincApi.DataApiVersionInGAC_Grinder;
            FlexNetLibraryVersion = Okuma.Scout.ThincApi.FlexNetVersionInGAC;

            if (apiHasBeenInitializedOrIsReady == false)
            {
                // Check if the API is available for use
                // Note that accessing this property may result in an attempt to instantiate the
                // API and will not allow the check to be made more than once every 5 seconds.
                // Thus, the property should be temporarily kept in a local variable if it is to be
                // used multiple times in the same scope.
                Okuma.Scout.Enums.ApiStatus status = Okuma.Scout.ThincApi.ApiAvailable;

                switch (status)
                {
                    case Okuma.Scout.Enums.ApiStatus.Ready:
                        {
                            THINC_API_Ready = status.ToString();
                            InitializeApiCanExecute = true;
                            apiHasBeenInitializedOrIsReady = true;
                            break;
                        }

                    case Okuma.Scout.Enums.ApiStatus.NotReady:
                        {
                            THINC_API_Ready = status.ToString();
                            break;
                        }

                    case Okuma.Scout.Enums.ApiStatus.Initialized:
                        {
                            THINC_API_Ready = "Ready";
                            THINC_API_Instantiated = status.ToString();
                            ApiFunctionsCanExecute = true;
                            apiHasBeenInitializedOrIsReady = true;
                            break;
                        }

                    case Okuma.Scout.Enums.ApiStatus.FailedToInitialize:
                        {
                            THINC_API_Ready = status.ToString();
                            break;
                        }

                    case Okuma.Scout.Enums.ApiStatus.FiveSecondTimeOutPeriod:
                        {
                            THINC_API_Ready = status.ToString();
                            break;
                        }
                }
            }

        }

        private void ExecuteApiFunctionsAction()
        {
            /* !! WARNING !! These functions are only to be used in situations where accessing the THINC API
             * via Reflection (http://msdn.microsoft.com/en-us/library/vstudio/f7ykdhsy%28v=vs.110%29.aspx) is necessary.
             * Normally, these same API functions can be accessed in your program by adding the THINC API files as
             * references to your project. That is the recommended method to use the THINC API. 
             * These functions can only be executed once Okuma.Scout.ThincApi.InitAPI() returns "Initialized".
             */
            API_MachineName = Okuma.Scout.ThincApi.MachineName();
            API_SerialNumber = Okuma.Scout.ThincApi.SerialNumber();
            API_CommonVariable = Okuma.Scout.ThincApi.GetCommonVariable(1).ToString();
        }

        private void InitializeApi()
        {
            Okuma.Scout.Enums.ApiStatus status = Okuma.Scout.ThincApi.InitAPI();
            THINC_API_Instantiated = status.ToString();

            if (status == Okuma.Scout.Enums.ApiStatus.Initialized)
            {
                ApiFunctionsCanExecute = true;
                InitializeApiCanExecute = false;
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
