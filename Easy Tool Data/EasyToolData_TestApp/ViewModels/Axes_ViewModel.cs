
namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System;

    class Axes_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.Axes EasyToolData_THINC_Axes;


        // Properties

        public ObservableCollection<Okuma.EasyToolData.ValidAxisCombo> AxisComboCollection { get; set; }

        public ObservableCollection<Okuma.EasyToolData.Enums.Axes> AxesCollection { get; set; }

        public ObservableCollection<Okuma.EasyToolData.Enums.Axes> AllAxesCollection { get; set; }


        private string _selectedAxis;
        public string SelectedAxis
        {
            get { return _selectedAxis; }
            set
            {
                _selectedAxis = value;
                OnPropertyChanged("SelectedAxis");
            }
        }

        private int _selectedAxisIndex;
        public int SelectedAxisIndex
        {
            get { return _selectedAxisIndex; }
            set
            {
                _selectedAxisIndex = value;
                TestAxisIsValid();
                OnPropertyChanged("SelectedAxisIndex");
            }
        }

        private bool _isValidAxisResult;
        public bool IsValidAxisResult
        {
            get { return _isValidAxisResult; }
            set
            {
                _isValidAxisResult = value;
                OnPropertyChanged("IsValidAxisResult");
            }
        }
 
        private bool _axisCombosValid;
        public bool AxisCombosValid
        {
            get { return _axisCombosValid; }
            set
            {
                _axisCombosValid = value;
                OnPropertyChanged("AxisCombosValid");
            }
        }

        private bool _ymApplicable = true;
        public bool YMApplicable
        {
            get { return _ymApplicable; }
            set
            {
                _ymApplicable = value;
                OnPropertyChanged("YMApplicable");
            }
        }

        private string _yModeActive = @"tbd";
        public string YModeActive
        {
            get { return _yModeActive; }
            set
            {
                _yModeActive = value;
                OnPropertyChanged("YModeActive");
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
                        (s) => { Test_ThincAxes(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }


        // Ctor
        public Axes_ViewModel()
        {
            AxisCombosValid = true;

            EasyToolData_THINC_Axes = new Okuma.EasyToolData.THINC.Axes();

            AllAxesCollection = new ObservableCollection<Okuma.EasyToolData.Enums.Axes>();
            foreach (Okuma.EasyToolData.Enums.Axes ax in Enum.GetValues(typeof(Okuma.EasyToolData.Enums.Axes)))
            {
                AllAxesCollection.Add(ax);
            }
            
            AxesCollection = new ObservableCollection<Okuma.EasyToolData.Enums.Axes>();
            AxisComboCollection = new ObservableCollection<Okuma.EasyToolData.ValidAxisCombo>();
        }


        // Methods

        private void Test_ThincAxes()
        {
            AxesCollection.Clear();

            foreach (Okuma.EasyToolData.Enums.Axes axis in EasyToolData_THINC_Axes.ValidAxes)
            {
                AxesCollection.Add(axis);
            }

            if (Okuma.EasyToolData.Global.MachineType == Okuma.EasyToolData.Enums.BasicMachineType.L)
            {
                AxisComboCollection.Clear();
                foreach (Okuma.EasyToolData.ValidAxisCombo combo in EasyToolData_THINC_Axes.ValidAxisCombinations)
                {
                    AxisComboCollection.Add(combo);
                }
            }
            else
            {   
                // Mill and Grinder have no concept of Axis / Turret / Spindle Combinations
                if (AxisCombosValid) { AxisCombosValid = false; }
            }

            if (AxesCollection.Contains(Okuma.EasyToolData.Enums.Axes.YI))
            {
                YMApplicable = true;

                YModeActive = string.Format(
                    "THINC_Axes.YAxisModeActive()='{0}'",
                    EasyToolData_THINC_Axes.YAxisModeActive());
            }
            else
            {
                YMApplicable = false;
                YModeActive = @"n/a";
            }
        }

        private void TestAxisIsValid()
        {
            if (SelectedAxisIndex >= 0)
            {
                Okuma.EasyToolData.Enums.Axes axis = AllAxesCollection[SelectedAxisIndex];
                SelectedAxis = axis.ToString();

                IsValidAxisResult = EasyToolData_THINC_Axes.IsValidAxis(axis);
            }
        }


        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}


