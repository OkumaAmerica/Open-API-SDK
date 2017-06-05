
namespace Okuma.Scout.TestApp.net40.ViewModels
{
    using System.ComponentModel;

    class DirectoriesViewModel : INotifyPropertyChanged
    {

        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties

        private bool? _ospDirectory;
        public bool? OspDirectory
        {
            get { return _ospDirectory; }
            set
            {
                _ospDirectory = value;
                OnPropertyChanged("OspDirectory");
            }
        }

        private bool? _cnsDirectory;
        public bool? CnsDirectory
        {
            get { return _cnsDirectory; }
            set
            {
                _cnsDirectory = value;
                OnPropertyChanged("CnsDirectory");
            }
        }

        private bool? _volanteDirectory;
        public bool? VolanteDirectory
        {
            get { return _volanteDirectory; }
            set
            {
                _volanteDirectory = value;
                OnPropertyChanged("VolanteDirectory");
            }
        }

        private bool? _cradDirectory;
        public bool? CradDirectory
        {
            get { return _cradDirectory; }
            set
            {
                _cradDirectory = value;
                OnPropertyChanged("CradDirectory");
            }
        }

        private bool? _okumaDirectory;
        public bool? OkumaDirectory
        {
            get { return _okumaDirectory; }
            set
            {
                _okumaDirectory = value;
                OnPropertyChanged("OkumaDirectory");
            }
        }

        private bool? _pcncmDirectory;
        public bool? PcncmDirectory
        {
            get { return _pcncmDirectory; }
            set
            {
                _pcncmDirectory = value;
                OnPropertyChanged("PcncmDirectory");
            }
        }

        private string _systemDirectory;
        public string SystemDirectory
        {
            get { return _systemDirectory; }
            set
            {
                _systemDirectory = value;
                OnPropertyChanged("SystemDirectory");
            }
        }

        private string _currentDirectory;
        public string CurrentDirectory
        {
            get { return _currentDirectory; }
            set
            {
                _currentDirectory = value;
                OnPropertyChanged("CurrentDirectory");
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
                        (s) => { ExecuteDirectoryTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Methods

        private void ExecuteDirectoryTests()
        {
            OspDirectory = Okuma.Scout.OspFileInfo.DirExists_OSP;
            CnsDirectory = Okuma.Scout.OspFileInfo.DirExists_CNS;
            VolanteDirectory = Okuma.Scout.OspFileInfo.DirExists_VOLANTE;
            CradDirectory = Okuma.Scout.OspFileInfo.DirExists_CRAD;
            OkumaDirectory = Okuma.Scout.OspFileInfo.DirExists_Okuma;
            PcncmDirectory = Okuma.Scout.OspFileInfo.DirExists_PCNCM;

            CurrentDirectory = System.Environment.CurrentDirectory;
            SystemDirectory = System.Environment.SystemDirectory;
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
