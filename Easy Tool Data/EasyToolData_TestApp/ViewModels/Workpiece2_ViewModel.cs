using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System;

    using Okuma.EasyToolData.Enums;
    using Okuma.SharedLog;
    using System.Reflection;


    class Workpiece2_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.Workpiece EasyToolData_THINC_Workpiece;
        Okuma.EasyToolData.THINC.Spindle EasyToolData_THINC_Spindle;
        Okuma.EasyToolData.THINC.Turret EasyToolData_THINC_Turret;
        Okuma.EasyToolData.THINC.Axes EasyToolData_THINC_Axes;



        // Properties

        public ObservableCollection<Spindles> ValidSpindlesCollection { get; set; }
        public ObservableCollection<Turrets> ValidTurretsCollection { get; set; }
        public ObservableCollection<Okuma.EasyToolData.Offset_Shift> OffsetsCollection { get; set; }
        public ObservableCollection<Okuma.EasyToolData.Offset_Shift> ZeroShiftsCollection { get; set; }

        private int _spindle_SelectedIndex;
        public int Spindle_SelectedIndex
        {
            get { return _spindle_SelectedIndex; }
            set
            {
                _spindle_SelectedIndex = value;
                OnPropertyChanged(nameof(Spindle_SelectedIndex));

                SpindleCollection_SelectedIndexChanged();
            }
        }

        private int _turret_SelectedIndex;
        public int Turret_SelectedIndex
        {
            get { return _turret_SelectedIndex; }
            set
            {
                _turret_SelectedIndex = value;
                OnPropertyChanged(nameof(Turret_SelectedIndex));

                TurretCollection_SelectedIndexChanged();
            }
        }

        private bool _turretsExist = true;
        public bool TurretsExist
        {
            get { return _turretsExist; }
            set { _turretsExist = value; OnPropertyChanged(nameof(TurretsExist)); }
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
        public Workpiece2_ViewModel()
        {
            EasyToolData_THINC_Workpiece = new Okuma.EasyToolData.THINC.Workpiece();
            EasyToolData_THINC_Spindle = new Okuma.EasyToolData.THINC.Spindle();
            EasyToolData_THINC_Turret = new Okuma.EasyToolData.THINC.Turret();
            EasyToolData_THINC_Axes = new Okuma.EasyToolData.THINC.Axes();

            ValidSpindlesCollection = new ObservableCollection<Spindles>();
            ValidTurretsCollection = new ObservableCollection<Turrets>();
            OffsetsCollection = new ObservableCollection<Okuma.EasyToolData.Offset_Shift>();
            ZeroShiftsCollection = new ObservableCollection<Okuma.EasyToolData.Offset_Shift>();

            if (Okuma.EasyToolData.Global.MachineType != BasicMachineType.L)
            {
                ZeroShiftUnavailableVisibility = Visibility.Visible;
            }
        }



        // Methods

        private void Test_ThincWorkpiece()
        {
            ValidSpindlesCollection.Clear();
            
            foreach (Spindles s in EasyToolData_THINC_Spindle.ValidSpindles)
            {
                ValidSpindlesCollection.Add(s);
            }
            if (ValidSpindlesCollection.Count > 0)
            {
                Spindle_SelectedIndex = 0;
            }

            ValidTurretsCollection.Clear();

            if (EasyToolData_THINC_Turret.ValidTurrets.Count > 0)
            {
                foreach (Turrets t in EasyToolData_THINC_Turret.ValidTurrets)
                {
                    ValidTurretsCollection.Add(t);
                }
                if (ValidTurretsCollection.Count > 0)
                {
                    Turret_SelectedIndex = 0;
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

            GetOffsets();
        }

        private void SpindleCollection_SelectedIndexChanged()
        {
            GetOffsets();
        }

        private void TurretCollection_SelectedIndexChanged()
        {
            GetOffsets();
        }

        private void GetOffsets()
        {
            OffsetsCollection.Clear();
            
            List<Okuma.EasyToolData.ValidAxisCombo> SelectedValidAxisCombos = GetSelectedValidAxisCombos();

            // This seems to be Current Offset values.
            // Mill tends to have a current offset value of 0 a lot... 
            List<Okuma.EasyToolData.Offset_Shift> Offsets = GetOffsetValues(SelectedValidAxisCombos);
            
            foreach (Okuma.EasyToolData.Offset_Shift offset in Offsets)
            {
                OffsetsCollection.Add(offset);
            }

            // Shift Values are not valid on Mills
            if (ZeroShiftUnavailableVisibility == Visibility.Hidden)
            {
                ZeroShiftsCollection.Clear();

                List<Okuma.EasyToolData.Offset_Shift> ZShifts = GetZShiftValues(SelectedValidAxisCombos);

                foreach (Okuma.EasyToolData.Offset_Shift zshift in ZShifts)
                {
                    ZeroShiftsCollection.Add(zshift);
                }
            }
        }

        private List<Okuma.EasyToolData.ValidAxisCombo> GetSelectedValidAxisCombos()
        {
            List<Okuma.EasyToolData.ValidAxisCombo> AxesList = new List<Okuma.EasyToolData.ValidAxisCombo>();

            if (ValidTurretsCollection.Count > 0 && ValidSpindlesCollection.Count > 0)
            {
                if (Spindle_SelectedIndex >= 0 && Turret_SelectedIndex >= 0)
                {
                    Turrets SelectedTurret = ValidTurretsCollection[Turret_SelectedIndex];
                    Spindles SelectedSpindle = ValidSpindlesCollection[Spindle_SelectedIndex];

                    // Get a list of valid axes for the given turret and spindle.
                    AxesList =
                        EasyToolData_THINC_Axes.ValidAxisCombinations
                            .Where(vac => vac.Turret == SelectedTurret)
                            .Where(vac => vac.Spindle == SelectedSpindle)
                            .ToList();
                }
            }

            return AxesList;
        }

        private List<Okuma.EasyToolData.Offset_Shift> GetOffsetValues(List<Okuma.EasyToolData.ValidAxisCombo> whichAxisCombos)
        {
            List<Okuma.EasyToolData.Offset_Shift> Offsets = new List<Okuma.EasyToolData.Offset_Shift>();

            foreach (Okuma.EasyToolData.ValidAxisCombo vac in whichAxisCombos)
            {
                Okuma.EasyToolData.Offset_Shift offset = new Okuma.EasyToolData.Offset_Shift
                {
                    Axis = vac.Axis,
                    Spindle = vac.Spindle,
                    Turret = vac.Turret
                };

                ValidatedResponse response = EasyToolData_THINC_Workpiece.GetZeroOffset(vac, out double value);

                if (response == ValidatedResponse.TRUE)
                {
                    offset.Value = value;
                    Offsets.Add(offset);
                }
                else
                {
                    Log.Send(new Okuma.SharedLog.MessageArg(
                        string.Format("Unable to get Offset for Axis '{0}', Turret '{1}', Spindle '{2}'.", vac.Axis, vac.Turret, vac.Spindle),
                         MessageType.INFO, MethodBase.GetCurrentMethod().Name,
                         ex: null, log: true, display: true), typeof(Workpiece2_ViewModel).FullName);
                }
            }
            return Offsets;
        }

        private List<Okuma.EasyToolData.Offset_Shift> GetZShiftValues(List<Okuma.EasyToolData.ValidAxisCombo> whichAxisCombos)
        {
            List<Okuma.EasyToolData.Offset_Shift> ZShifts = new List<Okuma.EasyToolData.Offset_Shift>();

            foreach (Okuma.EasyToolData.ValidAxisCombo vac in whichAxisCombos)
            {
                Okuma.EasyToolData.Offset_Shift zshift = new Okuma.EasyToolData.Offset_Shift
                {
                    Axis = vac.Axis,
                    Spindle = vac.Spindle,
                    Turret = vac.Turret
                };

                ValidatedResponse response = EasyToolData_THINC_Workpiece.GetZeroShift(vac, out double value);
                if (response == ValidatedResponse.TRUE)
                {
                    zshift.Value = value;
                    ZShifts.Add(zshift);
                }
                else
                {
                    Log.Send(new Okuma.SharedLog.MessageArg(
                         string.Format("Unable to get Offset for Axis '{0}', Turret '{1}', Spindle '{2}'.", vac.Axis, vac.Spindle, vac.Turret),
                         MessageType.INFO, MethodBase.GetCurrentMethod().Name,
                         ex: null, log: true, display: true), typeof(Workpiece2_ViewModel).FullName);
                }
            }
            return ZShifts;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}


