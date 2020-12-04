using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System;
    using System.Windows;
    using Okuma.Scout.Enums;
    using Okuma.EasyToolData.Extensions;


    class Workpiece1_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private bool Loaded = false;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.Axes EasyToolData_THINC_Axes;
        Okuma.EasyToolData.THINC.Spindle EasyToolData_THINC_Spindle;
        Okuma.EasyToolData.THINC.Turret EasyToolData_THINC_Turret;

        Okuma.EasyToolData.THINC.Workpiece EasyToolData_THINC_Workpiece;


        // Properties

        public ObservableCollection<Okuma.EasyToolData.Enums.Spindles> Spindles { get; set; }

        private int _spindles_SelectedIndex;
        public int Spindles_SelectedIndex
        {
            get { return _spindles_SelectedIndex; }
            set
            {
                _spindles_SelectedIndex = value;
                OnPropertyChanged(nameof(Spindles_SelectedIndex));

                Spindles_SelectedIndexChanged();
            }
        }

        public ObservableCollection<Okuma.EasyToolData.Enums.Turrets> Turrets { get; set; }
        
        private int _turrets_SelectedIndex;
        public int Turrets_SelectedIndex
        {
            get { return _turrets_SelectedIndex; }
            set
            {
                _turrets_SelectedIndex = value;
                OnPropertyChanged(nameof(Turrets_SelectedIndex));

                Turrets_SelectedIndexChanged();
            }
        }

        private bool _turretsExist = true;
        public bool TurretsExist
        {
            get { return _turretsExist; }
            set { _turretsExist = value; OnPropertyChanged(nameof(TurretsExist)); }
        }

        public ObservableCollection<Okuma.EasyToolData.Enums.Axes> Axes { get; set; }

        private int _axes_SelectedIndex;
        public int Axes_SelectedIndex
        {
            get { return _axes_SelectedIndex; }
            set
            {
                _axes_SelectedIndex = value;
                OnPropertyChanged(nameof(Axes_SelectedIndex));

                Axes_SelectedIndexChanged();
            }
        }

        private string _offset_Response;
        public string Offset_Response
        {
            get { return _offset_Response; }
            set { _offset_Response = value; OnPropertyChanged(nameof(Offset_Response)); }
        }

        private string _offset_Value;
        public string Offset_Value
        {
            get { return _offset_Value; }
            set { _offset_Value = value; OnPropertyChanged(nameof(Offset_Value)); }
        }

        private string _shift_Response;
        public string Shift_Response
        {
            get { return _shift_Response; }
            set { _shift_Response = value; OnPropertyChanged(nameof(Shift_Response)); }
        }

        private string _shift_Value;
        public string Shift_Value
        {
            get { return _shift_Value; }
            set { _shift_Value = value; OnPropertyChanged(nameof(Shift_Value)); }
        }

        private Visibility _zeroShiftUnavailableVisibility = Visibility.Hidden;
        public Visibility ZeroShiftUnavailableVisibility
        {
            get { return _zeroShiftUnavailableVisibility; }
            set { _zeroShiftUnavailableVisibility = value; OnPropertyChanged(nameof(ZeroShiftUnavailableVisibility)); }
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
                        (s) => { Test_ThincWorkpiece(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }


        // Constructor
        public Workpiece1_ViewModel()
        {
            EasyToolData_THINC_Workpiece = new Okuma.EasyToolData.THINC.Workpiece();
            EasyToolData_THINC_Axes = new Okuma.EasyToolData.THINC.Axes();
            EasyToolData_THINC_Spindle = new Okuma.EasyToolData.THINC.Spindle();
            EasyToolData_THINC_Turret = new Okuma.EasyToolData.THINC.Turret();

            Spindles = new ObservableCollection<Okuma.EasyToolData.Enums.Spindles>();
            Turrets = new ObservableCollection<Okuma.EasyToolData.Enums.Turrets>();
            Axes = new ObservableCollection<Okuma.EasyToolData.Enums.Axes>();

            if (Okuma.EasyToolData.Global.MachineType != Okuma.EasyToolData.Enums.BasicMachineType.L)
            {
                ZeroShiftUnavailableVisibility = Visibility.Visible;
                Shift_Response = Okuma.EasyToolData.Enums.ValidatedResponse.INVALID.ToString();
                Shift_Value = @"N/A";
            }
        }

        // Methods

        private void Test_ThincWorkpiece()
        {
            if (!Loaded)
            {
                foreach (Okuma.EasyToolData.Enums.Axes ax in EasyToolData_THINC_Axes.ValidAxes)
                {
                    Axes.Add(ax);
                }

                foreach (Okuma.EasyToolData.Enums.Spindles s in EasyToolData_THINC_Spindle.ValidSpindles)
                {
                    Spindles.Add(s);
                }

                if (EasyToolData_THINC_Turret.ValidTurrets.Count > 0)
                {
                    foreach (Okuma.EasyToolData.Enums.Turrets t in EasyToolData_THINC_Turret.ValidTurrets)
                    {
                        Turrets.Add(t);
                    }

                    if (EasyToolData_THINC_Turret.ValidTurrets.Count == 1 &&
                        EasyToolData_THINC_Turret.ValidTurrets[0] == Okuma.EasyToolData.Enums.Turrets.None)
                    {
                        if (TurretsExist) { TurretsExist = false; }
                    }
                }
                else
                {
                    if (TurretsExist) { TurretsExist = false; }
                }
                
                Loaded = true;
            }

            GetOffset();
        }

        private void Spindles_SelectedIndexChanged()
        {
            if (Loaded)
            {
                GetOffset();
            }
        }

        private void Turrets_SelectedIndexChanged()
        {
            if (Loaded)
            {
                GetOffset();
            }
        }

        private void Axes_SelectedIndexChanged()
        {
            if (Loaded)
            {
                GetOffset();
            }
        }

        private void GetOffset()
        {
            double offset_value = -9.1;
            string f = Global.NumberFormat;


            Okuma.EasyToolData.Enums.ValidatedResponse offset_response =
                Okuma.EasyToolData.Enums.ValidatedResponse.INVALID;
            
            Okuma.EasyToolData.ValidAxisCombo AxisCombo = new Okuma.EasyToolData.ValidAxisCombo();

            if (GetSelectedVAC(out AxisCombo))
            {
                offset_response = EasyToolData_THINC_Workpiece.GetZeroOffset(AxisCombo, out offset_value);
            }

            Offset_Response = offset_response.ToString();
            Offset_Value = offset_value.ToString(f);


            // Shift Values are not valid on Mills
            if (ZeroShiftUnavailableVisibility == Visibility.Hidden)
            {
                double shift_value = -9.2;

                Okuma.EasyToolData.Enums.ValidatedResponse shift_response = Okuma.EasyToolData.Enums.ValidatedResponse.INVALID;

                if (GetSelectedVAC(out AxisCombo))
                {
                    shift_response = EasyToolData_THINC_Workpiece.GetZeroShift(AxisCombo, out shift_value);
                }

                Shift_Response = shift_response.ToString();
                Shift_Value = shift_value.ToString(f);
            }
        }

        // Combine Selected Axis, Spindle, and Turret into a ValidAxisCombo object
        private bool GetSelectedVAC(out Okuma.EasyToolData.ValidAxisCombo vac)
        {
            bool VAC_Values_OK = true;

            Okuma.EasyToolData.ValidAxisCombo AxisCombo = new Okuma.EasyToolData.ValidAxisCombo();

            if (Axes.Count > 0 && Axes_SelectedIndex >= 0)
            {
                AxisCombo.Axis = Axes[Axes_SelectedIndex];
            }
            else { VAC_Values_OK = false; }

            if (Spindles.Count > 0 && Spindles_SelectedIndex >= 0)
            {
                AxisCombo.Spindle = Spindles[Spindles_SelectedIndex];
            }
            else { VAC_Values_OK = false; }

            if (Turrets.Count > 0 && Turrets_SelectedIndex >= 0)
            {
                AxisCombo.Turret = Turrets[Turrets_SelectedIndex];
            }
            else { VAC_Values_OK = false; }

            vac = AxisCombo;
            return VAC_Values_OK;
        }


        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}


