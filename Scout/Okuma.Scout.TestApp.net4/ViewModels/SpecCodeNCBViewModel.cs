
namespace Okuma.Scout.TestApp.net4.ViewModels
{
    using System;
    using System.Windows;
    using Microsoft.Win32;
    using System.ComponentModel;

    class SpecCodeNCBViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties

        private bool _radMachineNCBFile;
        public bool RadMachineNCBFile
        {
            get { return _radMachineNCBFile; }
            set
            {
                _radMachineNCBFile = value;
                OnPropertyChanged("RadMachineNCBFile");
                RadioButton_CheckChanged();
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

        private bool _radUserNCBFile;
        public bool RadUserNCBFile
        {
            get { return _radUserNCBFile; }
            set
            {
                _radUserNCBFile = value;
                OnPropertyChanged("RadUserNCBFile");
                RadioButton_CheckChanged();
            }
        }

        private bool? _validNCBSpecFileExists;
        public bool? ValidNCBSpecFileExists
        {
            get { return _validNCBSpecFileExists; }
            set
            {
                _validNCBSpecFileExists = value;
                OnPropertyChanged("ValidNCBSpecFileExists");
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

        private string _serialNumber;
        public string SerialNumber
        {
            get { return _serialNumber; }
            set
            {
                _serialNumber = value;
                OnPropertyChanged("SerialNumber");
            }
        }

        private int _selectedSpecGroupIndex;
        public int SelectedSpecGroupIndex
        {
            get { return _selectedSpecGroupIndex; }
            set
            {
                _selectedSpecGroupIndex = value;
                OnPropertyChanged("SelectedSpecGroupIndex");
            }
        }

        private string _ncBSpecFirstHalf;
        public string NCBSpecFirstHalf
        {
            get { return _ncBSpecFirstHalf; }
            set
            {
                _ncBSpecFirstHalf = value;
                OnPropertyChanged("NCBSpecFirstHalf");
            }
        }

        private string _ncBSpecSecondHalf;
        public string NCBSpecSecondHalf
        {
            get { return _ncBSpecSecondHalf; }
            set
            {
                _ncBSpecSecondHalf = value;
                OnPropertyChanged("NCBSpecSecondHalf");
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

        private int _nCBByteSelectedIndex;
        public int NCBByteSelectedIndex
        {
            get { return _nCBByteSelectedIndex; }
            set
            {
                _nCBByteSelectedIndex = value;
                OnPropertyChanged("NCBByteSelectedIndex");
                ExecuteNCBSpecTests();
            }
        }

        private int _nCBBitSelectedIndex;
        public int NCBBitSelectedIndex
        {
            get { return _nCBBitSelectedIndex; }
            set
            {
                _nCBBitSelectedIndex = value;
                OnPropertyChanged("NCBBitSelectedIndex");
                ExecuteNCBSpecTests();
            }
        }

        private bool? _nCBSpecBitActive;
        public bool? NCBSpecBitActive
        {
            get { return _nCBSpecBitActive; }
            set
            {
                _nCBSpecBitActive = value;
                OnPropertyChanged("NCBSpecBitActive");
            }
        }

        private string _nCBSpecByteHex;
        public string NCBSpecByteHex
        {
            get { return _nCBSpecByteHex; }
            set
            {
                _nCBSpecByteHex = value;
                OnPropertyChanged("NCBSpecByteHex");
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
                        (s) => { ExecuteNCBSpecTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        private DelegateCommand<bool> _selectNCBSpecFileCommand;
        public DelegateCommand<bool> SelectNCBSpecFileCommand
        {
            get
            {
                if (_selectNCBSpecFileCommand == null)
                {
                    _selectNCBSpecFileCommand = new DelegateCommand<bool>(
                        (s) => { ExecuteSelectNCBSpecFile(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _selectNCBSpecFileCommand;
            }
        }

        // Constructor

        public SpecCodeNCBViewModel()
        {
            RadMachineNCBFile = true;
        }

        // Methods

        private void ExecuteNCBSpecTests()
        {
            ValidNCBSpecFileExists = Okuma.Scout.SpecCode.NCB.MachineSpecCodeFileExists;

            MachineType = Okuma.Scout.SpecCode.NCB.machineNameFromFile;
            SerialNumber = Okuma.Scout.SpecCode.NCB.projectNumberFromFile.ToString();

            Okuma.Scout.Enums.NCBSpecGroup selectedGroup = Okuma.Scout.Enums.NCBSpecGroup.NCB1MG;

            switch (SelectedSpecGroupIndex)
            {
                case 0: { selectedGroup = Okuma.Scout.Enums.NCBSpecGroup.NCB1MG; break; }
                case 1: { selectedGroup = Okuma.Scout.Enums.NCBSpecGroup.NCB2MG; break; }
                case 2: { selectedGroup = Okuma.Scout.Enums.NCBSpecGroup.NCB3MG; break; }
                case 3: { selectedGroup = Okuma.Scout.Enums.NCBSpecGroup.NCB4MG; break; }
                case 4: { selectedGroup = Okuma.Scout.Enums.NCBSpecGroup.NCB5MG; break; }
                case 5: { selectedGroup = Okuma.Scout.Enums.NCBSpecGroup.NCB6MG; break; }
                case 6: { selectedGroup = Okuma.Scout.Enums.NCBSpecGroup.NCB7MG; break; }
                case 7: { selectedGroup = Okuma.Scout.Enums.NCBSpecGroup.NCB8MG; break; }
            }

            NCBSpecFirstHalf = Okuma.Scout.SpecCode.NCB.GroupFirstHalf(selectedGroup);
            NCBSpecSecondHalf = Okuma.Scout.SpecCode.NCB.GroupSecondHalf(selectedGroup);

            int byteNo = NCBByteSelectedIndex + 1;
            int bitNo = NCBBitSelectedIndex;

            NCBSpecByteHex = Okuma.Scout.SpecCode.NCB.Byte(selectedGroup, byteNo);
            NCBSpecBitActive = Okuma.Scout.SpecCode.NCB.Bit(selectedGroup, byteNo, bitNo);
        }

        private void ExecuteSelectNCBSpecFile()
        {
            RadUserNCBFile = ChooseNCBSpecFile();
        }

        /// <summary>
        /// Function called when radio button checked changed event is triggered.
        /// Sets user defined file path and "UseUserDefinedFilePath" properties depending
        /// on the checked state of the radio buttons. </summary>
        private void RadioButton_CheckChanged()
        {
            if (RadUserNCBFile == true)
            {
                Okuma.Scout.SpecCode.NCB.UseUserDefinedFile = true;
                UserFileEnabled = true;

                if (string.IsNullOrEmpty(Okuma.Scout.SpecCode.NCB.UserDefinedFilePath))
                {
                    if (!ChooseNCBSpecFile())
                    {
                        RadUserNCBFile = false;
                        UserFileEnabled = false;
                    }
                }
            }
            else if (RadMachineNCBFile == true)
            {
                Okuma.Scout.SpecCode.NCB.UseUserDefinedFile = false;
                UserFileEnabled = false;
            }
        }


        /// <summary>
        /// Generate open file dialog for selection of user defined spec file
        /// </summary>
        private bool ChooseNCBSpecFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select NC-B Spec Code File";
            ofd.InitialDirectory = @"C:\";
            ofd.CustomPlaces.Add(new FileDialogCustomPlace(@"C:\OSP-P\CNS-DAT\"));
            ofd.Filter = "NC B-SPEC File (*.DAT)|*.DAT";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;

            Nullable<bool> result = ofd.ShowDialog();

            if (result == true) // User did not cancel
            {
                Okuma.Scout.SpecCode.NCB.UserDefinedFilePath = ofd.FileName;
                Okuma.Scout.SpecCode.NCB.UseUserDefinedFile = true;

                if (!Okuma.Scout.SpecCode.NCB.SpecFileIsValid)
                {
                    // INVALID FILE

                    MessageBox.Show(
                        "The selected Spec Code file is not valid." + Environment.NewLine +
                        "Please choose another file.",
                        "Error Reading File",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error,
                        MessageBoxResult.OK);

                    Okuma.Scout.SpecCode.NCB.UseUserDefinedFile = false;
                    UserDefinedFilePath = string.Empty;

                    Okuma.Scout.SpecCode.NCB.UserDefinedFilePath = string.Empty;
                    return false;
                }
                else // VALID FILE
                {
                    UserDefinedFilePath = ofd.FileName;
                    return true;
                }
            }
            else // The user canceled
            {
                return false;
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