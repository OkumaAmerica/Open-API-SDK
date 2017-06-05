

namespace Okuma.Scout.TestApp.net40.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Collections.ObjectModel;

    class RegistryViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties

        private ObservableCollection<Subkeys> _registryKeyCollection;
        public ObservableCollection<Subkeys> RegistryKeyCollection
        {
            get
            {
                if (_registryKeyCollection == null) { _registryKeyCollection = new ObservableCollection<Subkeys>(); }
                return _registryKeyCollection;
            }
            set
            {
                _registryKeyCollection = value;
                OnPropertyChanged("RegistryKeyCollection");
            }
        }

        private int _registryKeyCollectionSelectedIndex;
        public int RegistryKeyCollectionSelectedIndex
        {
            get { return _registryKeyCollectionSelectedIndex; }
            set
            {
                _registryKeyCollectionSelectedIndex = value;
                OnPropertyChanged("RegistryKeyCollectionSelectedIndex");
            }
        }

        private string _key;
        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;
                OnPropertyChanged("Key");
            }
        }

        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        private bool? _exist;
        public bool? Exist
        {
            get { return _exist; }
            set
            {
                _exist = value;
                OnPropertyChanged("Exist");
            }
        }

        private string _data;
        public string Data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged("Data");
            }
        }

        private string _convertedVersion;
        public string ConvertedVersion
        {
            get { return _convertedVersion; }
            set
            {
                _convertedVersion = value;
                OnPropertyChanged("ConvertedVersion");
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
                        (s) => { ExecuteRegistryTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        private DelegateCommand<bool> _getCommand;
        public DelegateCommand<bool> GetCommand
        {
            get
            {
                if (_getCommand == null)
                {
                    _getCommand = new DelegateCommand<bool>(
                        (s) => { GetData(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _getCommand;
            }
        }

        // Constructor

        public RegistryViewModel()
        {
            Key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            Value = "DisplayVersion";
        }

        // Methods

        private void ExecuteRegistryTests()
        {
            // Clear the list before starting
            RegistryKeyCollection.Clear();

            // Get the base key from user input
            string basekey = Key;

            // Initialize results output for Reg.RegistryGetSubKeyNames() 
            string DisplayName = string.Empty;

            // Initialize results output for Reg.RegistryGetLocalMachineValue()
            List<string> SubkeysList = new List<string>();

            // Only modify / add items to the binding list if sub-keys exist under the specified base key
            if (Okuma.Scout.Reg.RegistryGetSubKeyNames(basekey, out SubkeysList))
            {
                // Iterate through the output results
                foreach (string subkey in SubkeysList)
                {
                    // Combine the base key and sub key to check for a value
                    // Do not escape the string literal or extra slashes will be added (for example: @"\\") 
                    string newkey = basekey + "\\" + subkey;

                    // For the purpose of filling the DataGridView, the value "DisplayName" is explicitly specified
                    if (Okuma.Scout.Reg.RegistryGetLocalMachineValue(newkey, "DisplayName", out DisplayName))
                    {
                        // If a Value for "DisplayName" exists under the new key, add it to the binding list
                        RegistryKeyCollection.Add(new Subkeys(DisplayName, subkey));
                    }
                    else
                    {
                        // Otherwise, leave it blank and just add the sub-key
                        RegistryKeyCollection.Add(new Subkeys(string.Empty, subkey));
                    }
                }
            }
        }

        private void GetData()
        {
            string SelectedSubKey = string.Empty;
            string ValueResult = string.Empty;


            if (RegistryKeyCollection.Count > 0)
            {
                // Get the Key value from the selected DGV row (second column = Cells[1])
                SelectedSubKey = RegistryKeyCollection[RegistryKeyCollectionSelectedIndex].Subkey;

                if (!String.IsNullOrEmpty(SelectedSubKey))
                {
                    // The Key is valid
                    Exist = true;

                    // Combine the base key and sub key to check for a value
                    // Do not escape the string literal or extra slashes will be added (for example: @"\\") 
                    string FullKey = Key + "\\" + SelectedSubKey;

                    // Get the DATA from the desired VALUE in the specified KEY
                    if (Okuma.Scout.Reg.RegistryGetLocalMachineValue(FullKey, Value, out ValueResult))
                    {
                        // RegistryGetLocalMachineValue() returned TRUE, meaning data was obtained.
                        Data = ValueResult;

                        // If the registry value is "Version", parse the result to a version number.
                        if (Value == "Version")
                        {
                            ConvertedVersion = Okuma.Scout.Helper.RegDwordIntegerVersionParse(ValueResult).ToString();
                        }
                        else
                        {
                            ConvertedVersion = string.Empty;
                        }
                    }
                    else
                    {
                        // A value was not returned
                        Exist = false; 
                        Data = string.Empty;
                        ConvertedVersion = string.Empty;
                    }
                }
                else
                {
                    // There is no key specified
                    Exist = false;
                    Data = string.Empty;
                    ConvertedVersion = string.Empty;
                }
            }
            else
            {
                // There are no selected rows in the DGV (no key to query)
                Exist = null;
                Data = "nothing selected";
                ConvertedVersion = string.Empty;
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


    /// <summary>
    /// Class for storing information returned from the registry.
    /// Designed specifically for listing the SubKeys under the following key:
    /// "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall" thus it includes "DisplayName".
    /// </summary>
    public class Subkeys : INotifyPropertyChanged
    {
        private string _DisplayName;
        private string _Subkey;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructor for Class SubKeys
        /// </summary>
        /// <param name="displayname"></param>
        /// <param name="subkey"></param>
        public Subkeys(string name, string key)
        {
            _DisplayName = name;
            _Subkey = key;
        }

        [DisplayName("Display Name")]
        public string DisplayName
        {
            get { return _DisplayName; }
            set
            {
                _DisplayName = value;
                this.NotifyPropertyChanged("DisplayName");
            }
        }

        [DisplayName("Key")]
        public string Subkey
        {
            get { return _Subkey; }
            set
            {
                _Subkey = value;
                this.NotifyPropertyChanged("Key");
            }
        }

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }


}
