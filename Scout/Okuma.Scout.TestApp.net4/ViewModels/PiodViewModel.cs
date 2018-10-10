

namespace Okuma.Scout.TestApp.net4.ViewModels
{
    using System;
    using System.Windows;
    using Microsoft.Win32;
    using System.ComponentModel;


    class PiodViewModel : INotifyPropertyChanged
    {

        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;


        // Properties

        private bool? _validMachinePiodFileExist;
        public bool? ValidMachinePiodFileExist
        {
            get { return _validMachinePiodFileExist; }
            set
            {
                _validMachinePiodFileExist = value;
                OnPropertyChanged("ValidMachinePiodFileExist");
            }
        }

        private bool _userFileEnabled;
        public bool UserFileEnabled
        {
            get { return _userFileEnabled; }
            set
            {
                _userFileEnabled = value;
                OnPropertyChanged("UserFileEnabled");
            }
        }

        private bool _radMachinePiodFile;
        public bool RadMachinePiodFile
        {
            get { return _radMachinePiodFile; }
            set
            {
                _radMachinePiodFile = value;
                OnPropertyChanged("RadMachinePiodFile");
                RadioButton_PiodFile_CheckChanged();
            }
        }

        private bool _radUserPiodFile;
        public bool RadUserPiodFile
        {
            get { return _radUserPiodFile; }
            set
            {
                _radUserPiodFile = value;
                OnPropertyChanged("RadUserPiodFile");
                RadioButton_PiodFile_CheckChanged();
            }
        }

        private string _control;
        public string Control
        {
            get { return _control; }
            set
            {
                _control = value;
                OnPropertyChanged("Control");
            }
        }

        private string _projectNumber;
        public string ProjectNumber
        {
            get { return _projectNumber; }
            set
            {
                _projectNumber = value;
                OnPropertyChanged("ProjectNumber");
            }
        }

        private string _plcSystem;
        public string PlcSystem
        {
            get { return _plcSystem; }
            set
            {
                _plcSystem = value;
                OnPropertyChanged("PlcSystem");
            }
        }

        private string _machineType;
        public string MachineType
        {
            get { return _machineType; }
            set
            {
                _machineType = value;
                OnPropertyChanged("MachineType");
            }
        }
     
        private string _userDefinedFilePath;
        public string UserDefinedFilePath
        {
            get { return _userDefinedFilePath; }
            set
            {
                _userDefinedFilePath = value;
                OnPropertyChanged("UserDefinedFilePath");
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
                        (s) => { ExecutePiodTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        private DelegateCommand<bool> _selectFileCommand;
        public DelegateCommand<bool> SelectFileCommand
        {
            get
            {
                if (_selectFileCommand == null)
                {
                    _selectFileCommand = new DelegateCommand<bool>(
                        (s) => { ExecuteSelectPiodFile(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _selectFileCommand;
            }
        }


        // Constructor
        public PiodViewModel()
        {
            RadMachinePiodFile = true;
        }


        // Methods

        private void ExecutePiodTests()
        {
            ValidMachinePiodFileExist = Okuma.Scout.PIOD.MachinePiodFileExists;
            Control = Okuma.Scout.PIOD.Control;
            MachineType = Okuma.Scout.PIOD.MachineType;
            PlcSystem = Okuma.Scout.PIOD.PlcSystem;
            ProjectNumber = Okuma.Scout.PIOD.ProjectNumber;
        }

        private void ExecuteSelectPiodFile()
        {
            RadUserPiodFile = ChoosePiodFile();
        }

        /// <summary>
        /// Function called when radio button checked changed event is triggered.
        /// Sets user defined file path and "UseUserDefinedFilePath" properties depending
        /// on the checked state of the radio buttons. </summary>
        private void RadioButton_PiodFile_CheckChanged()
        {
            if (RadUserPiodFile == true)
            {
                Okuma.Scout.PIOD.UseUserDefinedFile = true;
                UserFileEnabled = true;

                if (string.IsNullOrEmpty(Okuma.Scout.PIOD.UserDefinedFilePath))
                {
                    if (!ChoosePiodFile())
                    {
                        RadUserPiodFile = false;
                        UserFileEnabled = false;
                    }
                }
            }
            else if (RadMachinePiodFile == true)
            {
                Okuma.Scout.PIOD.UseUserDefinedFile = false;
                UserFileEnabled = false;
            }
        }

        /// <summary>
        /// Generate open file dialog for selection of user defined spec file
        /// </summary>
        private bool ChoosePiodFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select PIOD File";
            ofd.InitialDirectory = @"C:\";
            ofd.CustomPlaces.Add(new FileDialogCustomPlace(@"C:\OSP-P\CNS-DAT\ENG\"));
            ofd.CustomPlaces.Add(new FileDialogCustomPlace(@"C:\OSP-P\CNS-DAT\JPN\"));
            ofd.Filter = "PIOD File (*.CNS)|*.CNS";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;

            Nullable<bool> result = ofd.ShowDialog();

            if (result == true) // User did not cancel
            {
                // SCOUT must have a path and be set to User Defined File in order to 
                // evaluate the correct PIOD file. 
                Okuma.Scout.PIOD.UserDefinedFilePath = ofd.FileName;
                Okuma.Scout.PIOD.UseUserDefinedFile = true;

                if (!Okuma.Scout.PIOD.PiodFileIsValid) 
                {
                    // INVALID FILE

                    MessageBox.Show(
                        "The selected PIOD file is not valid." + Environment.NewLine +
                        "Please choose another file.",
                        "Error Reading File", 
                        MessageBoxButton.OK, 
                        MessageBoxImage.Error, 
                        MessageBoxResult.OK);

                    Okuma.Scout.PIOD.UseUserDefinedFile = false;
                    UserDefinedFilePath = "";

                    Okuma.Scout.PIOD.UserDefinedFilePath = string.Empty;
                    return false;
                }
                else // VALID FILE
                {
                    UserDefinedFilePath = ofd.FileName;
                    return true;
                }
            } // The user canceled
            return false;
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
