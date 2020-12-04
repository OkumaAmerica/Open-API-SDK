
namespace EasyToolData_TestApp.ViewModels
{
    using System;
    using System.Windows;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Okuma.EasyToolData.Enums;


    class ToolOffsetsMill_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.Tools EasyToolData_THINC_Tools;

        public bool multifunction = false;


        // Properties

        /// <summary> 
        /// Registered Tools 
        /// </summary>
        public ObservableCollection<long> AllToolsCollection { get; set; }

        private int _allToolsCollection_SelectedIndex;
        public int AllToolsCollection_SelectedIndex
        {
            get { return _allToolsCollection_SelectedIndex; }
            set
            {
                _allToolsCollection_SelectedIndex = value;
                OnPropertyChanged(nameof(AllToolsCollection_SelectedIndex));
                AllToolsCollection_SelectedIndexChanged();
            }
        }
     
        private string _rco1;
        public string RCompOffsetG1 { get { return _rco1; } set { _rco1 = value; OnPropertyChanged(nameof(RCompOffsetG1)); } }
        private string _rco2;
        public string RCompOffsetG2 { get { return _rco2; } set { _rco2 = value; OnPropertyChanged(nameof(RCompOffsetG2)); } }
        private string _rco3;
        public string RCompOffsetG3 { get { return _rco3; } set { _rco3 = value; OnPropertyChanged(nameof(RCompOffsetG3)); } }
        private string _compWear1;
        public string RCompWearG1 { get { return _compWear1; } set { _compWear1 = value; OnPropertyChanged(nameof(RCompWearG1)); } }
        private string _compWear2;
        public string RCompWearG2 { get { return _compWear2; } set { _compWear2 = value; OnPropertyChanged(nameof(RCompWearG2)); } }
        private string _compWear3;
        public string RCompWearG3 { get { return _compWear3; } set { _compWear3 = value; OnPropertyChanged(nameof(RCompWearG3)); } }
        private string _len1;
        public string LengthOffsetG1 { get { return _len1; } set { _len1 = value; OnPropertyChanged(nameof(LengthOffsetG1)); } }
        private string _len2;
        public string LengthOffsetG2 { get { return _len2; } set { _len2 = value; OnPropertyChanged(nameof(LengthOffsetG2)); } }
        private string _len3;
        public string LengthOffsetG3 { get { return _len3; } set { _len3 = value; OnPropertyChanged(nameof(LengthOffsetG3)); } }
        private string _lenWear1;
        public string LengthWearG1 { get { return _lenWear1; } set { _lenWear1 = value; OnPropertyChanged(nameof(LengthWearG1)); } }
        private string _lenWear2;
        public string LengthWearG2 { get { return _lenWear2; } set { _lenWear2 = value; OnPropertyChanged(nameof(LengthWearG2)); } }
        private string _lenWear3;
        public string LengthWearG3 { get { return _lenWear3; } set { _lenWear3 = value; OnPropertyChanged(nameof(LengthWearG3)); } }

        private Visibility _invalidMachineType;
        public Visibility InvalidMachineType
        {
            get { return _invalidMachineType; }
            set { _invalidMachineType = value; OnPropertyChanged(nameof(InvalidMachineType)); }
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
                        (s) => { Execute_ToolOffsetsMill(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Constructor
        public ToolOffsetsMill_ViewModel()
        {
            InvalidMachineType = Visibility.Hidden;

            EasyToolData_THINC_Tools = new Okuma.EasyToolData.THINC.Tools();
            AllToolsCollection = new ObservableCollection<long>();
        }

        // Methods

        private void Execute_ToolOffsetsMill()
        {
            AllToolsCollection.Clear();

            // Get All Tools List and make a default selection
            foreach (long t in EasyToolData_THINC_Tools.GetToolsList())
            {
                AllToolsCollection.Add(t);
            }
            if (AllToolsCollection.Count > 0)
            {
                AllToolsCollection_SelectedIndex = 0;
            }
        }

        private void AllToolsCollection_SelectedIndexChanged()
        {
            GetToolOffsets();
        }

        private void GetToolOffsets()
        {
            if (AllToolsCollection.Count > 0 && AllToolsCollection_SelectedIndex >= 0)
            {
                long tool = AllToolsCollection[AllToolsCollection_SelectedIndex];

                if (Okuma.EasyToolData.Global.MachineType == BasicMachineType.M)
                {
                    ValidatedResponse vr = EasyToolData_THINC_Tools.GetMillOffsets(tool, out Okuma.EasyToolData.ToolOffsets_Mill toolOffsets);

                    if (vr == ValidatedResponse.TRUE)
                    {
                        string f = Global.NumberFormat;

                        RCompOffsetG1 = toolOffsets.Offset1_HADA.CutterRComp_Geometry.ToString(f);
                        LengthOffsetG1 = toolOffsets.Offset1_HADA.ToolLengthOffset_Geometry.ToString(f);
                        // G1 should always contain Wear values
                        RCompWearG1 = toolOffsets.Offset1_HADA.CutterRComp_Wear.ToString(f);
                        LengthWearG1 = toolOffsets.Offset1_HADA.ToolLengthOffset_Wear.ToString(f);

                        RCompOffsetG2 = toolOffsets.Offset2_HBDB.CutterRComp_Geometry.ToString(f);
                        LengthOffsetG2 = toolOffsets.Offset2_HBDB.ToolLengthOffset_Geometry.ToString(f);
                        // G2 & G3 will not have Wear values if ToolID.
                        if (toolOffsets.Offset2_HBDB.WearOffsetsValid)
                        {
                            RCompWearG2 = toolOffsets.Offset2_HBDB.CutterRComp_Wear.ToString(f);
                            LengthWearG2 = toolOffsets.Offset2_HBDB.ToolLengthOffset_Wear.ToString(f);
                        }
                        else { RCompWearG2 = LengthWearG2 = Okuma.EasyToolData.Global.NO_RESULT; }


                        RCompOffsetG3 = toolOffsets.Offset3_HCDC.CutterRComp_Geometry.ToString(f);
                        LengthOffsetG3 = toolOffsets.Offset3_HCDC.ToolLengthOffset_Geometry.ToString(f);
                        if (toolOffsets.Offset3_HCDC.WearOffsetsValid)
                        {
                            RCompWearG3 = toolOffsets.Offset3_HCDC.CutterRComp_Wear.ToString(f);
                            LengthWearG3 = toolOffsets.Offset3_HCDC.ToolLengthOffset_Wear.ToString(f);
                        }
                        else { RCompWearG3 = LengthWearG3 = Okuma.EasyToolData.Global.NO_RESULT; }
                    }
                    else
                    {
                        RCompOffsetG1 = vr.ToString();

                        RCompOffsetG2 = RCompOffsetG3 = "";
                        RCompWearG1 = RCompWearG2 = RCompWearG3 = "";
                        LengthOffsetG1 = LengthOffsetG2 = LengthOffsetG3 = "";
                        LengthWearG1 = LengthWearG2 = LengthWearG3 = "";
                    }
                }
                else if (Okuma.EasyToolData.Global.MachineType == BasicMachineType.L)
                {
                    InvalidMachineType = Visibility.Visible;
                }
                else
                {
                    RCompOffsetG1 = Okuma.EasyToolData.Global.EXCEPTION_RESULT;
                }
            }
        }    
        
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
    } // END class 

} // END namespace EasyToolData_TestApp.ViewModels