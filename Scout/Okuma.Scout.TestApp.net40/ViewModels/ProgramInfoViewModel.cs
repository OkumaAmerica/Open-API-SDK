using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma.Scout.TestApp.net40.ViewModels
{
    using System.ComponentModel;

    class ProgramInfoViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        private string _assemblyGUID;
        public string AssemblyGUID
        {
            get { return _assemblyGUID; }
            set
            {
                _assemblyGUID = value;
                OnPropertyChanged("AssemblyGUID");
            }
        }

        private string _assemblyTitle;
        public string AssemblyTitle
        {
            get { return _assemblyTitle; }
            set
            {
                _assemblyTitle = value;
                OnPropertyChanged("AssemblyTitle");
            }
        }

        private string _assemblyCopyright;
        public string AssemblyCopyright
        {
            get { return _assemblyCopyright; }
            set
            {
                _assemblyCopyright = value;
                OnPropertyChanged("AssemblyCopyright");
            }
        }

        private string _assemblyCompany;
        public string AssemblyCompany
        {
            get { return _assemblyCompany; }
            set
            {
                _assemblyCompany = value;
                OnPropertyChanged("AssemblyCompany");
            }
        }

        private string _assemblyDescription;
        public string AssemblyDescription
        {
            get { return _assemblyDescription; }
            set
            {
                _assemblyDescription = value;
                OnPropertyChanged("AssemblyDescription");
            }
        }

        private string _assemblyVersion;
        public string AssemblyVersion
        {
            get { return _assemblyVersion; }
            set
            {
                _assemblyVersion = value;
                OnPropertyChanged("AssemblyVersion");
            }
        }

        private DateTime? _assemblyBuildDate;
        public DateTime? AssemblyBuildDate
        {
            get { return _assemblyBuildDate; }
            set
            {
                _assemblyBuildDate = value;
                OnPropertyChanged("AssemblyBuildDate"); 
            }
        }

        private string _scoutDllVersion;
        public string ScoutDllVersion
        {
            get { return _scoutDllVersion; }
            set
            {
                _scoutDllVersion = value;
                OnPropertyChanged("ScoutDllVersion");
            }
        }

        private DateTime? _scoutDllBuildDate;
        public DateTime? ScoutDllBuildDate
        {
            get { return _scoutDllBuildDate; }
            set
            {
                _scoutDllBuildDate = value;
                OnPropertyChanged("ScoutDllBuildDate");
            }
        }

        private Okuma.Scout.Enums.SoftwareArchitecture _executingAssemblyBitness;
        public Okuma.Scout.Enums.SoftwareArchitecture ExecutingAssemblyBitness
        {
            get { return _executingAssemblyBitness; }
            set
            {
                _executingAssemblyBitness = value;
                OnPropertyChanged("ExecutingAssemblyBitness");
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
                        (s) => { ExecuteTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        private DelegateCommand<bool> _setCommand;
        public DelegateCommand<bool> SetCommand
        {
            get
            {
                if (_setCommand == null)
                {
                    _setCommand = new DelegateCommand<bool>(
                        (s) => { ExecuteSet(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _setCommand;
            }
        }

        // Methods

        private void ExecuteTests()
        {
            ErrorMessage = Okuma.Scout.ProgramInfo.ErrorMessage;

            AssemblyGUID = Okuma.Scout.ProgramInfo.AssemblyGuid;
            AssemblyTitle = Okuma.Scout.ProgramInfo.AssemblyTitle;
            AssemblyCopyright = Okuma.Scout.ProgramInfo.AssemblyCopyright;
            AssemblyCompany = Okuma.Scout.ProgramInfo.AssemblyCompany;
            AssemblyDescription = Okuma.Scout.ProgramInfo.AssemblyDescription;

            AssemblyVersion = Okuma.Scout.ProgramInfo.ThisAssemblyVersion;
            AssemblyBuildDate = Okuma.Scout.ProgramInfo.ThisAssemblyBuildDate;

            ScoutDllVersion = Okuma.Scout.ProgramInfo.ScoutDllAssemblyVersion;
            ScoutDllBuildDate = Okuma.Scout.ProgramInfo.ScoutDllBuildDate;

            // Slightly misleading, but this function is found in the Operating System class.
            // It reports the "bitness" of the currently executing program, hence it is under the Program tab.
            ExecutingAssemblyBitness = Okuma.Scout.OS.ProgramBits;
        }

        private void ExecuteSet()
        {
            Okuma.Scout.ProgramInfo.ErrorMessage = ErrorMessage;
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
