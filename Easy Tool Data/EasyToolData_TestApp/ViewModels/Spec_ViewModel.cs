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

    class Spec_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        public const int MaxWord = 32;
        public const int MaxBit = 7;

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        public ObservableCollection<Okuma.EasyToolData.Enums.SimplifiedSubsystem> SubSystemsCollection { get; set; }

        public ObservableCollection<Okuma.EasyToolData.DefinedSpec> DefinedSpecsCollection { get; set; }

        public ObservableCollection<Okuma.EasyToolData.Enums.SpecType> SpecTypeCollection { get; set; }

        public ObservableCollection<Okuma.EasyToolData.Enums.SpecGroup> SpecGroupCollection { get; set; }

        public ObservableCollection<int> SpecWordCollection { get; set; }

        public ObservableCollection<int> SpecBitCollection { get; set; }


        Okuma.EasyToolData.THINC.Spec EasyToolData_THINC_Spec;

        // Properties

        private string _machineName;
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; OnPropertyChanged(nameof(MachineName)); }
        }

        private string _serialNumber;
        public string SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; OnPropertyChanged(nameof(SerialNumber)); }
        }

        private string _controlType;
        public string ControlType
        {
            get { return _controlType; }
            set { _controlType = value; OnPropertyChanged(nameof(ControlType)); }
        }

        private string _selectedSubsystem;
        public string SelectedSubsystem
        {
            get { return _selectedSubsystem; }
            set { _selectedSubsystem = value; OnPropertyChanged(nameof(SelectedSubsystem)); }
        }

        private int _selectedSubSystemIndex;
        public int SelectedSubSystemIndex
        {
            get { return _selectedSubSystemIndex; }
            set { _selectedSubSystemIndex = value; SelectedSubSystemIndexChanged(); OnPropertyChanged(nameof(SelectedSubSystemIndex)); }
        }

        private string _isValidSubsystemResult;
        public string IsValidSubsystemResult
        {
            get { return _isValidSubsystemResult; }
            set { _isValidSubsystemResult = value; OnPropertyChanged(nameof(IsValidSubsystemResult)); }
        }
        
        private int _selectedDefinedSpecIndex;
        public int SelectedDefindSpecIndex
        {
            get { return _selectedDefinedSpecIndex; }
            set
            {
                _selectedDefinedSpecIndex = value;
                SelectedDefinedSpecIndexChanged();
                OnPropertyChanged(nameof(SelectedDefindSpecIndex));
            }
        }

        private string _preDefinedSpec_NameEn;
        public string PreDefinedSpec_NameEn
        {
            get { return _preDefinedSpec_NameEn; }
            set { _preDefinedSpec_NameEn = value; OnPropertyChanged(nameof(PreDefinedSpec_NameEn)); }
        }

        private string _preDefinedSpec_NameJp;
        public string PreDefinedSpec_NameJp
        {
            get { return _preDefinedSpec_NameJp; }
            set { _preDefinedSpec_NameJp = value; OnPropertyChanged(nameof(PreDefinedSpec_NameJp)); }
        }

        private string _preDefinedSpec_Code;
        public string PreDefinedSpec_Code
        {
            get { return _preDefinedSpec_Code; }
            set { _preDefinedSpec_Code = value; OnPropertyChanged(nameof(PreDefinedSpec_Code)); }
        }

        private string _preDefinedSpec_Type;
        public string PreDefinedSpec_Type
        {
            get { return _preDefinedSpec_Type; }
            set { _preDefinedSpec_Type = value; OnPropertyChanged(nameof(PreDefinedSpec_Type)); }
        }

        private string _preDefinedSpec_Group;
        public string PreDefinedSpec_Group
        {
            get { return _preDefinedSpec_Group; }
            set { _preDefinedSpec_Group = value; OnPropertyChanged(nameof(PreDefinedSpec_Group)); }
        }

        private string _preDefinedSpec_Word;
        public string PreDefinedSpec_Word
        {
            get { return _preDefinedSpec_Word; }
            set { _preDefinedSpec_Word = value; OnPropertyChanged(nameof(PreDefinedSpec_Word)); }
        }

        private string _preDefinedSpec_Bit;
        public string PreDefinedSpec_Bit
        {
            get { return _preDefinedSpec_Bit; }
            set { _preDefinedSpec_Bit = value; OnPropertyChanged(nameof(PreDefinedSpec_Bit)); }
        }

        private string _preDefinedSpec_Value;
        public string PreDefinedSpec_Value
        {
            get { return _preDefinedSpec_Value; }
            set { _preDefinedSpec_Value = value; OnPropertyChanged(nameof(PreDefinedSpec_Value)); }
        }


        private int _selectedSpecTypeIndex;
        public int SelectedSpecTypeIndex
        {
            get { return _selectedSpecTypeIndex; }
            set
            {
                _selectedSpecTypeIndex = value;
                SelectedSpecTypeIndexChanged();
                OnPropertyChanged(nameof(SelectedSpecTypeIndex));
            }
        }

        private int _selectedSpecGroupIndex;
        public int SelectedSpecGroupIndex
        {
            get { return _selectedSpecGroupIndex; }
            set
            {
                _selectedSpecGroupIndex = value;
                SelectedSpecGroupIndexChanged();
                OnPropertyChanged(nameof(SelectedSpecGroupIndex));
            }
        }

        private int _selectedSpecWordIndex;
        public int SelectedSpecWordIndex
        {
            get { return _selectedSpecWordIndex; }
            set
            {
                _selectedSpecWordIndex = value;
                SelectedSpecWordIndexChanged();
                OnPropertyChanged(nameof(SelectedSpecWordIndex));
            }
        }

        private int _selectedSpecBitIndex;
        public int SelectedSpecBitIndex
        {
            get { return _selectedSpecBitIndex; }
            set
            {
                _selectedSpecBitIndex = value;
                SelectedSpecBitIndexChanged();
                OnPropertyChanged(nameof(SelectedSpecBitIndex));
            }
        }

        private string _pickSpec_Value;
        public string PickSpec_Value
        {
            get { return _pickSpec_Value; }
            set { _pickSpec_Value = value; OnPropertyChanged(nameof(PickSpec_Value)); }
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
                        (s) => { Test_ThincSpec(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        private DelegateCommand<bool> _getSpecValueCommand;
        public DelegateCommand<bool> GetSpecValueCommand
        {
            get
            {
                if (_getSpecValueCommand == null)
                {
                    _getSpecValueCommand = new DelegateCommand<bool>(
                        (s) => { SpecGetValue(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _getSpecValueCommand;
            }
        }


        // Constructor
        public Spec_ViewModel()
        {
            EasyToolData_THINC_Spec = new Okuma.EasyToolData.THINC.Spec();

            SubSystemsCollection = new ObservableCollection<Okuma.EasyToolData.Enums.SimplifiedSubsystem>();
            foreach (Okuma.EasyToolData.Enums.SimplifiedSubsystem ss in Enum.GetValues(typeof(Okuma.EasyToolData.Enums.SimplifiedSubsystem)))
            {
                SubSystemsCollection.Add(ss);
            }

            SpecTypeCollection = new ObservableCollection<Okuma.EasyToolData.Enums.SpecType>();
            foreach (Okuma.EasyToolData.Enums.SpecType st in Enum.GetValues(typeof(Okuma.EasyToolData.Enums.SpecType)))
            {
                SpecTypeCollection.Add(st);
            }

            SpecGroupCollection = new ObservableCollection<Okuma.EasyToolData.Enums.SpecGroup>();
            foreach (Okuma.EasyToolData.Enums.SpecGroup sg in Enum.GetValues(typeof(Okuma.EasyToolData.Enums.SpecGroup)))
            {
                SpecGroupCollection.Add(sg);
            }

            SpecWordCollection = new ObservableCollection<int>();
            for (int w = 1; w <= MaxWord; w++)
            {
                SpecWordCollection.Add(w);
            }

            SpecBitCollection = new ObservableCollection<int>();
            for (int b = 0; b <= MaxBit; b++)
            {
                SpecBitCollection.Add(b);
            }

            DefinedSpecsCollection = new ObservableCollection<Okuma.EasyToolData.DefinedSpec>();
            PopulateDefinedSpecsCollection();
            
            SelectedDefinedSpecIndexChanged();
        }


        // Methods

        private void Test_ThincSpec()
        {
            MachineName = EasyToolData_THINC_Spec.MachineName();
            SerialNumber = EasyToolData_THINC_Spec.SerialNumber();
            ControlType = EasyToolData_THINC_Spec.ControlType().ToString();

            SelectedSubSystemIndexChanged();
        }

        private void SpecGetValue()
        {
            Okuma.EasyToolData.Enums.ValidatedResponse vr =
                  EasyToolData_THINC_Spec.Get(
                    SpecTypeCollection[SelectedSpecTypeIndex],
                    SpecGroupCollection[SelectedSpecGroupIndex],
                    SpecWordCollection[SelectedSpecWordIndex],
                    SpecBitCollection[SelectedSpecBitIndex]
                    );

            PickSpec_Value = vr.ToString();
        }

        private void SelectedSubSystemIndexChanged()
        {
            if (SelectedSubSystemIndex >= 0)
            {
                Okuma.EasyToolData.Enums.SimplifiedSubsystem ss = SubSystemsCollection[SelectedSubSystemIndex];
                SelectedSubsystem = ss.ToString();

                IsValidSubsystemResult = EasyToolData_THINC_Spec.IsSubSystemValid(ss).ToString();
            }
        }

        private void PopulateDefinedSpecsCollection()
        {
            if (Okuma.Scout.Platform.BaseMachineType == Okuma.Scout.Enums.MachineType.L)
            {
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.AutoTailStock);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.BAxisControl);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.BAxisInterpolation);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.B_Axial_1_DegreePitch);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.B_Axial_Point001_DegreePitch);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.B_Turret_M_Axis);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.B_Turret_Y_Axis);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.CB_Axis_Without_MB_Axis);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.CenterCompensation);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.CoordinateConversion);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.C_Axis_1Point);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.C_Axis_AutoClamp);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.C_Axis_ManualConnection);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.C_Axis_NotchFilterSwitching);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.C_Axis_PitchComp2);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.C_Axis_PitchComp2);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.C_Axis_PitchErrorComp);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.C_Axis_SynchronousControl);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.C_Axis_TorqueSkip);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.C_Axis_ZeroOffset);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.C_Turret_M_Axis);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.C_Turret_Y_Axis);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.H1Turret);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.LatheToolInformationManagement);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.LT_Machine);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.L_Tool_Index);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.MultiFunctionMachine);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.MultiMagazine);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.MultiMagazineB);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.MultipleCuttingEdgeTool);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.MultipleToolOffsetSystems);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.MultiTool);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.M_Axis_No_C_Axis);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.NC_TailStock);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.New_W_Data);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.Parallel2Spindle);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.ProgrammableTailStock);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.ProgrammableTailStockB);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.Slant_Y_Axis);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.SteadyRestZB);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.SubMagazine);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.SubSpindle);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.ThreeSaddle_NCB);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.ThreeSaddle_PLC);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.ToolInformationManagement);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.ToolLifeManagement);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.ToolWearCompensation);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.TurretPositionCompensation);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.TwoSaddle);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.WorkCoordinate10);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.WorkCoordinate100);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.WorkCoordinate50);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.L.ZA_ZC_Interlock);      
            }
            else if (Okuma.Scout.Platform.BaseMachineType == Okuma.Scout.Enums.MachineType.M)
            {
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.AAxisName);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ANGAT_ATC_Interlock);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ATCSubpanel);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ATC_APC_DoorLockCheck);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ATC_FixedAddress); 
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ATC_Simulator);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.AT_ATC);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.AutoDoor);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.BAxisLimit);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.BAxisLimitFunction);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.BAxisName);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.CAxisLimit);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.CAxisName);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ChipConv_ATC_Interlock);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.LinearAAxis);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.LinearBAxis);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.LinearCAxis);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.RotarySecondAxis);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.RotaryTwoSet);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.OspSuite);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ToolData100);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ToolData200);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ToolData300);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ToolData999);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ToolIDFunctionNCB);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.UAxisName);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.VAxisName);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.WAxisName);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.FourthAxisControl);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.FifthAxisControl);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.FifthAxisLimit);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.SixthAxisControl);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.WorkCordinate20);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.WorkCordinate50);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.WorkCoordinate100);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.WorkCoordinate200);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.WorkCoordinate400);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ToolWearOffset);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.HasATC);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ToolData100_PLC);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ToolData200_PLC);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ToolData300_PLC);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ToolIDFunction);
                DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ToolIDFunctionNCB);

                // OUT OF "NORMAL" RANGE...
                //DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.NewATC_CamBox);
                //DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.RandomATC);
                //DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.SecondATC_ControlPanel);
                //DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.SequentialATC_Screen);
                //DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ToolArmHomePositionDisplay);
                //DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.DetailedATC_ScreenDisplay);
                //DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.APC_ATC_Interlock);
                //DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.APC_Mount);
                //DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ATC2);
                //DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ATC_BeltOutDetect);
                //DefinedSpecsCollection.Add(EasyToolData_THINC_Spec.M.ATC_ShutterDoorMiddlePositionCheck);


            }
        }


        private void SelectedDefinedSpecIndexChanged()
        {
            if (SelectedDefindSpecIndex >= 0 && DefinedSpecsCollection.Count > 0)
            {
                Okuma.EasyToolData.DefinedSpec spec = DefinedSpecsCollection[SelectedDefindSpecIndex];
                PreDefinedSpec_NameEn = spec.NameEn;
                PreDefinedSpec_NameJp = spec.NameJp;
                PreDefinedSpec_Code = spec.Code;
                PreDefinedSpec_Type = spec.Type.ToString();
                PreDefinedSpec_Group = spec.Group.ToString();
                PreDefinedSpec_Word = spec.Word.ToString();
                PreDefinedSpec_Bit = spec.Bit.ToString();

                PreDefinedSpec_Value = EasyToolData_THINC_Spec.Get(spec).ToString();
            }
        }

        public void SelectedSpecTypeIndexChanged()
        {
            PickSpec_Value = "";
        }

        public void SelectedSpecGroupIndexChanged()
        {
            PickSpec_Value = "";
        }

        public void SelectedSpecWordIndexChanged()
        {
            PickSpec_Value = "";
        }

        public void SelectedSpecBitIndexChanged()
        {
            PickSpec_Value = "";
        }


        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}


