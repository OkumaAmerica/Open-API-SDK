
namespace Okuma.Scout.TestApp.net4.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Threading;

    class OS3ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties

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

        private void ExecuteOSTests()
        {
            VersionTitle = Okuma.Scout.OS.VersionTitle;
            VersionComment = Okuma.Scout.OS.VersionComment;
            VersionConfigDate = Okuma.Scout.OS.VersionConfigDate;
            VersionConfigVersion = Okuma.Scout.OS.VersionConfigVersion;
            VersionLanguage = Okuma.Scout.OS.VersionLanguage;
            VersionTarget = Okuma.Scout.OS.VersionTarget;
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