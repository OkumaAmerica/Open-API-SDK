
namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System;

    class Machine_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.Machine EasyToolData_THINC_Machine;

        // Properties

        private string _displayUnits;
        public string DisplayUnits
        {
            get { return _displayUnits; }
            set { _displayUnits = value; OnPropertyChanged(nameof(DisplayUnits)); }
        }

        private string _td_Mode;
        public string TD_Mode
        {
            get { return _td_Mode; }
            set { _td_Mode = value; OnPropertyChanged(nameof(TD_Mode)); }
        }

        private bool _getUnits;
        public bool GetUnits
        {
            get { return _getUnits; }
            set
            {
                _getUnits = value;
                OnPropertyChanged(nameof(GetUnits));
                Okuma.EasyToolData.Global.UnitsInInch = value;
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
                        (s) => { Test_ThincMachine(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }


        // Constructor
        public Machine_ViewModel()
        {
            EasyToolData_THINC_Machine = new Okuma.EasyToolData.THINC.Machine();
            GetUnits = Okuma.EasyToolData.Global.UnitsInInch; 
        }

        // Methods

        private void Test_ThincMachine()
        {
            Okuma.EasyToolData.Enums.DisplayUnitsEnum units = EasyToolData_THINC_Machine.GetDisplayUnits();
            DisplayUnits = units.ToString();
            TD_Mode = EasyToolData_THINC_Machine.GetTD_Mode().ToString();

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


