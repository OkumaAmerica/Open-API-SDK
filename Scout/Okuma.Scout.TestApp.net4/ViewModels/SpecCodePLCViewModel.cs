using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma.Scout.TestApp.net4.ViewModels
{
    using System;
    using System.Windows;
    using Microsoft.Win32;
    using System.ComponentModel;

    class SpecCodePLCViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties

        private bool _radMachinePLCFile;
        public bool RadMachinePLCFile
        {
            get { return _radMachinePLCFile; }
            set
            {
                _radMachinePLCFile = value;
                OnPropertyChanged("RadMachinePLCFile");
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

        private bool _radUserPLCFile;
        public bool RadUserPLCFile
        {
            get { return _radUserPLCFile; }
            set
            {
                _radUserPLCFile = value;
                OnPropertyChanged("RadUserPLCFile");
                RadioButton_CheckChanged();
            }
        }

        private bool? _validPLCSpecFileExists;
        public bool? ValidPLCSpecFileExists
        {
            get { return _validPLCSpecFileExists; }
            set
            {
                _validPLCSpecFileExists = value;
                OnPropertyChanged("ValidPLCSpecFileExists");
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

        private string _plcSpecFirstHalf;
        public string PLCSpecFirstHalf
        {
            get { return _plcSpecFirstHalf; }
            set
            {
                _plcSpecFirstHalf = value;
                OnPropertyChanged("PLCSpecFirstHalf");
            }
        }

        private string _plcSpecSecondHalf;
        public string PLCSpecSecondHalf
        {
            get { return _plcSpecSecondHalf; }
            set
            {
                _plcSpecSecondHalf = value;
                OnPropertyChanged("PLCSpecSecondHalf");
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

        private int _plcByteSelectedIndex;
        public int PLCByteSelectedIndex
        {
            get { return _plcByteSelectedIndex; }
            set
            {
                _plcByteSelectedIndex = value;
                OnPropertyChanged("PLCByteSelectedIndex");
                ExecuteNCSpecTests();
            }
        }

        private int _plcBitSelectedIndex;
        public int PLCBitSelectedIndex
        {
            get { return _plcBitSelectedIndex; }
            set
            {
                _plcBitSelectedIndex = value;
                OnPropertyChanged("PLCBitSelectedIndex");
                ExecuteNCSpecTests();
            }
        }

        private bool? _plcSpecBitActive;
        public bool? PLCSpecBitActive
        {
            get { return _plcSpecBitActive; }
            set
            {
                _plcSpecBitActive = value;
                OnPropertyChanged("PLCSpecBitActive");
            }
        }

        private string _plcSpecByteHex;
        public string PLCSpecByteHex
        {
            get { return _plcSpecByteHex; }
            set
            {
                _plcSpecByteHex = value;
                OnPropertyChanged("PLCSpecByteHex");
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

        private DelegateCommand<bool> _selectPLCSpecFileCommand;
        public DelegateCommand<bool> SelectPLCSpecFileCommand
        {
            get
            {
                if (_selectPLCSpecFileCommand == null)
                {
                    _selectPLCSpecFileCommand = new DelegateCommand<bool>(
                        (s) => { ExecuteSelectPLCSpecFile(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _selectPLCSpecFileCommand;
            }
        }

        // Constructor

        public SpecCodePLCViewModel()
        {
            RadMachinePLCFile = true;
        }

        // Methods

        private void ExecuteNCSpecTests()
        {
            ValidPLCSpecFileExists = Okuma.Scout.SpecCode.PLC.MachineSpecCodeFileExists;

            Okuma.Scout.Enums.PLCSpecGroup selectedGroup = Okuma.Scout.Enums.PLCSpecGroup.PLC1MG;

            switch (SelectedSpecGroupIndex)
            {
                case 0: { selectedGroup = Okuma.Scout.Enums.PLCSpecGroup.PLC1MG; break; }
                case 1: { selectedGroup = Okuma.Scout.Enums.PLCSpecGroup.PLC2MG; break; }
                case 2: { selectedGroup = Okuma.Scout.Enums.PLCSpecGroup.PLC3MG; break; }
            }

            PLCSpecFirstHalf = Okuma.Scout.SpecCode.PLC.GroupFirstHalf(selectedGroup);
            PLCSpecSecondHalf = Okuma.Scout.SpecCode.PLC.GroupSecondHalf(selectedGroup);

            int byteNo = PLCByteSelectedIndex + 1;
            int bitNo = PLCBitSelectedIndex;

            PLCSpecByteHex = Okuma.Scout.SpecCode.PLC.Byte(selectedGroup, byteNo);
            PLCSpecBitActive = Okuma.Scout.SpecCode.PLC.Bit(selectedGroup, byteNo, bitNo);
        }

        private void ExecuteSelectPLCSpecFile()
        {
            RadUserPLCFile = ChoosePLCSpecFile();
        }

        /// <summary>
        /// Function called when radio button checked changed event is triggered.
        /// Sets user defined file path and "UseUserDefinedFilePath" properties depending
        /// on the checked state of the radio buttons. </summary>
        private void RadioButton_CheckChanged()
        {
            if (RadUserPLCFile == true)
            {
                Okuma.Scout.SpecCode.PLC.UseUserDefinedFile = true;
                UserFileEnabled = true;

                if (string.IsNullOrEmpty(Okuma.Scout.SpecCode.PLC.UserDefinedFilePath))
                {
                    if (!ChoosePLCSpecFile())
                    {
                        RadUserPLCFile = false;
                        UserFileEnabled = false;
                    }
                }
            }
            else if (RadMachinePLCFile == true)
            {
                Okuma.Scout.SpecCode.PLC.UseUserDefinedFile = false;
                UserFileEnabled = false;
            }
        }


        /// <summary>
        /// Generate open file dialog for selection of user defined spec file
        /// </summary>
        private bool ChoosePLCSpecFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select PLC Spec Code File";
            ofd.InitialDirectory = @"C:\";
            ofd.CustomPlaces.Add(new FileDialogCustomPlace(@"C:\OSP-P\CNS-DAT\"));
            ofd.Filter = "PLC SPEC File (*.CNS)|*.CNS";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;

            Nullable<bool> result = ofd.ShowDialog();

            if (result == true) // User did not cancel
            {
                Okuma.Scout.SpecCode.PLC.UserDefinedFilePath = ofd.FileName;
                Okuma.Scout.SpecCode.PLC.UseUserDefinedFile = true;

                if (!Okuma.Scout.SpecCode.PLC.SpecFileIsValid)
                {
                    // INVALID FILE

                    MessageBox.Show(
                        "The selected Spec Code file is not valid." + Environment.NewLine +
                        "Please choose another file.",
                        "Error Reading File",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error,
                        MessageBoxResult.OK);

                    Okuma.Scout.SpecCode.PLC.UseUserDefinedFile = false;
                    UserDefinedFilePath = string.Empty;

                    Okuma.Scout.SpecCode.PLC.UserDefinedFilePath = string.Empty;
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