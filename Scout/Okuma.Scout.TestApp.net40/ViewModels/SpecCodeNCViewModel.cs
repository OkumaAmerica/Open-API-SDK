using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma.Scout.TestApp.net40.ViewModels
{
    using System;
    using System.Windows;
    using Microsoft.Win32;
    using System.ComponentModel;

    class SpecCodeNCViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties

        private bool _radMachineNCFile;
        public bool RadMachineNCFile
        {
            get { return _radMachineNCFile; }
            set
            {
                _radMachineNCFile = value;
                OnPropertyChanged("RadMachineNCFile");
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

        private bool _radUserNCFile;
        public bool RadUserNCFile
        {
            get { return _radUserNCFile; }
            set
            {
                _radUserNCFile = value;
                OnPropertyChanged("RadUserNCFile");
                RadioButton_CheckChanged();
            }
        }

        private bool? _validNCSpecFileExists;
        public bool? ValidNCSpecFileExists
        {
            get { return _validNCSpecFileExists; }
            set
            {
                _validNCSpecFileExists = value;
                OnPropertyChanged("ValidNCSpecFileExists");
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

        private string _ncSpecFirstHalf;
        public string NCSpecFirstHalf
        {
            get { return _ncSpecFirstHalf; }
            set
            {
                _ncSpecFirstHalf = value;
                OnPropertyChanged("NCSpecFirstHalf");
            }
        }

        private string _ncSpecSecondHalf;
        public string NCSpecSecondHalf
        {
            get { return _ncSpecSecondHalf; }
            set
            {
                _ncSpecSecondHalf = value;
                OnPropertyChanged("NCSpecSecondHalf");
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

        private int _nCByteSelectedIndex;
        public int NCByteSelectedIndex
        {
            get { return _nCByteSelectedIndex; }
            set
            {
                _nCByteSelectedIndex = value;
                OnPropertyChanged("NCByteSelectedIndex");
                ExecuteNCSpecTests();
            }
        }

        private int _nCBitSelectedIndex;
        public int NCBitSelectedIndex
        {
            get { return _nCBitSelectedIndex; }
            set
            {
                _nCBitSelectedIndex = value;
                OnPropertyChanged("NCBitSelectedIndex");
                ExecuteNCSpecTests();
            }
        }

        private bool? _nCSpecBitActive;
        public bool? NCSpecBitActive
        {
            get { return _nCSpecBitActive; }
            set
            {
                _nCSpecBitActive = value;
                OnPropertyChanged("NCSpecBitActive");
            }
        }

        private string _nCSpecByteHex;
        public string NCSpecByteHex
        {
            get { return _nCSpecByteHex; }
            set
            {
                _nCSpecByteHex = value;
                OnPropertyChanged("NCSpecByteHex");
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
                        (s) => { ExecuteNCSpecTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        private DelegateCommand<bool> _selectNCSpecFileCommand;
        public DelegateCommand<bool> SelectNCSpecFileCommand
        {
            get
            {
                if (_selectNCSpecFileCommand == null)
                {
                    _selectNCSpecFileCommand = new DelegateCommand<bool>(
                        (s) => { ExecuteSelectNCSpecFile(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _selectNCSpecFileCommand;
            }
        }

        // Constructor

        public SpecCodeNCViewModel()
        {
            RadMachineNCFile = true;
        }

        // Methods

        private void ExecuteNCSpecTests()
        {
            ValidNCSpecFileExists = Okuma.Scout.SpecCode.NC.MachineSpecCodeFileExists;

            MachineType = Okuma.Scout.SpecCode.NC.machineNameFromFile;
            SerialNumber = Okuma.Scout.SpecCode.NC.projectNumberFromFile.ToString();

            Okuma.Scout.Enums.NCSpecGroup selectedGroup = Okuma.Scout.Enums.NCSpecGroup.NC1MG;

            switch (SelectedSpecGroupIndex)
            {
                case 0: { selectedGroup = Okuma.Scout.Enums.NCSpecGroup.NC1MG; break; }
                case 1: { selectedGroup = Okuma.Scout.Enums.NCSpecGroup.NC2MG; break; }
                case 2: { selectedGroup = Okuma.Scout.Enums.NCSpecGroup.NC3MG; break; }
                case 3: { selectedGroup = Okuma.Scout.Enums.NCSpecGroup.NC4MG; break; }
                case 4: { selectedGroup = Okuma.Scout.Enums.NCSpecGroup.NC5MG; break; }
                case 5: { selectedGroup = Okuma.Scout.Enums.NCSpecGroup.NC6MG; break; }
                case 6: { selectedGroup = Okuma.Scout.Enums.NCSpecGroup.NC7MG; break; }
                case 7: { selectedGroup = Okuma.Scout.Enums.NCSpecGroup.NC8MG; break; }
            }

            NCSpecFirstHalf = Okuma.Scout.SpecCode.NC.GroupFirstHalf(selectedGroup);
            NCSpecSecondHalf = Okuma.Scout.SpecCode.NC.GroupSecondHalf(selectedGroup);

            int byteNo = NCByteSelectedIndex + 1;
            int bitNo = NCBitSelectedIndex;

            NCSpecByteHex = Okuma.Scout.SpecCode.NC.Byte(selectedGroup, byteNo);
            NCSpecBitActive = Okuma.Scout.SpecCode.NC.Bit(selectedGroup, byteNo, bitNo);
        }

        private void ExecuteSelectNCSpecFile()
        {
            RadUserNCFile = ChooseNCSpecFile();
        }

        /// <summary>
        /// Function called when radio button checked changed event is triggered.
        /// Sets user defined file path and "UseUserDefinedFilePath" properties depending
        /// on the checked state of the radio buttons. </summary>
        private void RadioButton_CheckChanged()
        {
            if (RadUserNCFile == true)
            {
                Okuma.Scout.SpecCode.NC.UseUserDefinedFile = true;
                UserFileEnabled = true;

                if (string.IsNullOrEmpty(Okuma.Scout.SpecCode.NC.UserDefinedFilePath))
                {
                    if (!ChooseNCSpecFile())
                    {
                        RadUserNCFile = false;
                        UserFileEnabled = false;
                    }
                }
            }
            else if (RadMachineNCFile == true)
            {
                Okuma.Scout.SpecCode.NC.UseUserDefinedFile = false;
                UserFileEnabled = false;
            }
        }


        /// <summary>
        /// Generate open file dialog for selection of user defined spec file
        /// </summary>
        private bool ChooseNCSpecFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select NC Spec Code File";
            ofd.InitialDirectory = @"C:\";
            ofd.CustomPlaces.Add(new FileDialogCustomPlace(@"C:\OSP-P\CNS-DAT\"));
            ofd.Filter = "NCSPEC File (*.DAT)|*.DAT";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;

            Nullable<bool> result = ofd.ShowDialog();

            if (result == true) // User did not cancel
            {
                Okuma.Scout.SpecCode.NC.UserDefinedFilePath = ofd.FileName;
                Okuma.Scout.SpecCode.NC.UseUserDefinedFile = true;

                if (!Okuma.Scout.SpecCode.NC.SpecFileIsValid)
                {
                    // INVALID FILE

                    MessageBox.Show(
                        "The selected Spec Code file is not valid." + Environment.NewLine +
                        "Please choose another file.",
                        "Error Reading File",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error,
                        MessageBoxResult.OK);

                    Okuma.Scout.SpecCode.NC.UseUserDefinedFile = false;
                    UserDefinedFilePath = string.Empty;

                    Okuma.Scout.SpecCode.NC.UserDefinedFilePath = string.Empty;
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