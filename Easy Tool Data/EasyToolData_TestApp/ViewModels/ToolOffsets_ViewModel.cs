
namespace EasyToolData_TestApp.ViewModels
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    using Okuma.EasyToolData.Extensions;
    using Okuma.EasyToolData.Enums;
    using Okuma.SharedLog;
    using System.Reflection;
    using System.Windows;


    class ToolOffsets_ViewModel : INotifyPropertyChanged
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

        private bool _selectedToolIsMultiEdge;
        public bool SelectedToolIsMultiEdge
        {
            get { return _selectedToolIsMultiEdge; }
            set { _selectedToolIsMultiEdge = value; OnPropertyChanged(nameof(SelectedToolIsMultiEdge)); }
        }

        private bool _hideAdjustmentRow;
        public bool HideAdjustmentRow
        {
            get { return _hideAdjustmentRow; }
            set { _hideAdjustmentRow = value; OnPropertyChanged(nameof(HideAdjustmentRow)); }
        }

        /// <summary> 
        /// Registered Tools Collection Selected Tool - Registered Edges 
        /// </summary>
        public ObservableCollection<int> ToolEdgeCollection { get; set; }

        private int _toolEdgeCollection_SelectedIndex;
        public int ToolEdgeCollection_SelectedIndex
        {
            get { return _toolEdgeCollection_SelectedIndex; }
            set
            {
                _toolEdgeCollection_SelectedIndex = value;
                OnPropertyChanged(nameof(ToolEdgeCollection_SelectedIndex));
                ToolEdgeCollection_SelectedIndexChanged();
            }
        }

        private bool _selectedToolHasCuttingPosition;
        public bool SelectedToolHasCuttingPosition
        {
            get { return _selectedToolHasCuttingPosition; }
            set
            {
                _selectedToolHasCuttingPosition = value;
                OnPropertyChanged(nameof(SelectedToolHasCuttingPosition));
            }
        }

        /// <summary> 
        /// Registered Tools Collection Selected Tool - Tool Edge Collection Selected Edge - Registered Cutting Positions
        /// </summary>
        public ObservableCollection<int> ToolCuttingPositionsCollection { get; set; }

        private int _toolCuttingPositionsCollection_SelectedIndex;
        public int ToolCuttingPositionsCollection_SelectedIndex
        {
            get { return _toolCuttingPositionsCollection_SelectedIndex; }
            set
            {
                _toolCuttingPositionsCollection_SelectedIndex = value;
                OnPropertyChanged(nameof(ToolCuttingPositionsCollection_SelectedIndex));
                ToolCuttingPositionsCollection_SelectedIndexChanged();
            }
        }

        private string _firstOffsetGroupNumber;
        public string FirstOffsetGroupNumber
        {
            get { return _firstOffsetGroupNumber; }
            set { _firstOffsetGroupNumber = value; OnPropertyChanged(nameof(FirstOffsetGroupNumber)); }
        }

        private string _secondOffsetGroupNumber;
        public string SecondOffsetGroupNumber
        {
            get { return _secondOffsetGroupNumber; }
            set { _secondOffsetGroupNumber = value; OnPropertyChanged(nameof(SecondOffsetGroupNumber)); }
        }

        private Visibility _standardLatheItemVisibility;
        public Visibility StandardLatheItemVisibility
        {
            get { return _standardLatheItemVisibility; }
            set { _standardLatheItemVisibility = value; OnPropertyChanged(nameof(StandardLatheItemVisibility)); }
        }
        
        private string _axisRef;
        public string AxisRef
        {
            get { return _axisRef; }
            set { _axisRef = value; OnPropertyChanged(nameof(AxisRef)); }
        }

        private string _toolOffset_X;
        public string ToolOffset_X
        {
            get { return _toolOffset_X; }
            set { _toolOffset_X = value; OnPropertyChanged(nameof(ToolOffset_X)); }
        }

        private string _toolOffset_Z;
        public string ToolOffset_Z
        {
            get { return _toolOffset_Z; }
            set { _toolOffset_Z = value; OnPropertyChanged(nameof(ToolOffset_Z)); }
        }

        private string _toolOffset_YI;
        public string ToolOffset_YI
        {
            get { return _toolOffset_YI; }
            set { _toolOffset_YI = value; OnPropertyChanged(nameof(ToolOffset_YI)); }
        }

        private string _adjustment_X;
        public string Adjustment_X
        {
            get { return _adjustment_X; }
            set { _adjustment_X = value; OnPropertyChanged(nameof(Adjustment_X)); }
        }

        private string _adjustment_Z;
        public string Adjustment_Z
        {
            get { return _adjustment_Z; }
            set { _adjustment_Z = value; OnPropertyChanged(nameof(Adjustment_Z)); }
        }

        private string _adjustment_YI;
        public string Adjustment_YI
        {
            get { return _adjustment_YI; }
            set { _adjustment_YI = value; OnPropertyChanged(nameof(Adjustment_YI)); }
        }

        private string _wear_X;
        public string Wear_X
        {
            get { return _wear_X; }
            set { _wear_X = value; OnPropertyChanged(nameof(Wear_X)); }
        }

        private string _wear_Z;
        public string Wear_Z
        {
            get { return _wear_Z; }
            set { _wear_Z = value; OnPropertyChanged(nameof(Wear_Z)); }
        }

        private string _noseR_X;
        public string NoseR_X
        {
            get { return _noseR_X; }
            set { _noseR_X = value; OnPropertyChanged(nameof(NoseR_X)); }
        }

        private string _noseR_Z;
        public string NoseR_Z
        {
            get { return _noseR_Z; }
            set { _noseR_Z = value; OnPropertyChanged(nameof(NoseR_Z)); }
        }

        private string _noseR_P;
        public string NoseR_P
        {
            get { return _noseR_P; }
            set { _noseR_P = value; OnPropertyChanged(nameof(NoseR_P)); }
        }

        private string _toolOffset_X2;
        public string ToolOffset_X2
        {
            get { return _toolOffset_X2; }
            set { _toolOffset_X2 = value; OnPropertyChanged(nameof(ToolOffset_X2)); }
        }

        private string _toolOffset_Z2;
        public string ToolOffset_Z2
        {
            get { return _toolOffset_Z2; }
            set { _toolOffset_Z2 = value; OnPropertyChanged(nameof(ToolOffset_Z2)); }
        }

        private string _toolOffset_YI2;
        public string ToolOffset_YI2
        {
            get { return _toolOffset_YI2; }
            set { _toolOffset_YI2 = value; OnPropertyChanged(nameof(ToolOffset_YI2)); }
        }

        private string _wear_X2;
        public string Wear_X2
        {
            get { return _wear_X2; }
            set { _wear_X2 = value; OnPropertyChanged(nameof(Wear_X2)); }
        }

        private string _wear_Z2;
        public string Wear_Z2
        {
            get { return _wear_Z2; }
            set { _wear_Z2 = value; OnPropertyChanged(nameof(Wear_Z2)); }
        }

        private string _noseR_X2;
        public string NoseR_X2
        {
            get { return _noseR_X2; }
            set { _noseR_X2 = value; OnPropertyChanged(nameof(NoseR_X2)); }
        }

        private string _noseR_Z2;
        public string NoseR_Z2
        {
            get { return _noseR_Z2; }
            set { _noseR_Z2 = value; OnPropertyChanged(nameof(NoseR_Z2)); }
        }

        private string _noseR_P2;
        public string NoseR_P2
        {
            get { return _noseR_P2; }
            set { _noseR_P2 = value; OnPropertyChanged(nameof(NoseR_P2)); }
        }

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
                        (s) => { Execute_ToolOffsets(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Constructor
        public ToolOffsets_ViewModel()
        {
            EasyToolData_THINC_Tools = new Okuma.EasyToolData.THINC.Tools();

            AllToolsCollection = new ObservableCollection<long>();
            ToolEdgeCollection = new ObservableCollection<int>();
            ToolCuttingPositionsCollection = new ObservableCollection<int>();

            AxisRef = "";
            InvalidMachineType = Visibility.Hidden;

            if (Okuma.EasyToolData.Global.MachineType == BasicMachineType.L)
            { 
                Okuma.EasyToolData.THINC.Spec s = new Okuma.EasyToolData.THINC.Spec();

                if (Okuma.EasyToolData.Global.Is_S_Control &&
                    s.Get(s.L.H1Turret) == ValidatedResponse.TRUE)
                {
                    multifunction = true;
                    StandardLatheItemVisibility = Visibility.Hidden;
                }
                else // Standard Lathe
                {
                    HideAdjustmentRow = true;
                    StandardLatheItemVisibility = Visibility.Visible;
                }
            }
        }



        // Methods

        private void Execute_ToolOffsets()
        {
            ToolEdgeCollection.Clear();
            AllToolsCollection.Clear();
            ToolCuttingPositionsCollection.Clear();

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

        /// <summary>
        /// If you don't use a lock such as this, the GetData method will be called excessively.
        /// additionally, bad arguments may end up being passed potentially resulting in exceptions.
        /// </summary>
        private bool IgnoreSelectedIndexChanges = false;

        private void AllToolsCollection_SelectedIndexChanged()
        {
            IgnoreSelectedIndexChanges = true;
            FindToolEdges();
            FindToolCuttingPositions();
            IgnoreSelectedIndexChanges = false;
            GetToolOffsets();
        }

        private void ToolEdgeCollection_SelectedIndexChanged()
        {
            if (!IgnoreSelectedIndexChanges)
            {
                IgnoreSelectedIndexChanges = true;
                FindToolCuttingPositions();
                IgnoreSelectedIndexChanges = false;
                GetToolOffsets();
            }
        }

        private void ToolCuttingPositionsCollection_SelectedIndexChanged()
        {
            if (!IgnoreSelectedIndexChanges)
            {
                GetToolOffsets();
            }
        }

        private void GetToolOffsets()
        {
            long tool;
            int edge;

            // Every tool (on MULTUS) should have at least 1 cutting position.
            // Other machine types can completely ignore this argument.
            int cuttingposition = 1;

            if (AllToolsCollection.Count > 0 && AllToolsCollection_SelectedIndex >= 0)
            {
                tool = AllToolsCollection[AllToolsCollection_SelectedIndex];

                if (_selectedToolIsMultiEdge && ToolEdgeCollection.Count > 0 && ToolEdgeCollection_SelectedIndex >= 0)
                {
                    edge = ToolEdgeCollection[ToolEdgeCollection_SelectedIndex];
                }   // Non Multi-Edge Tools use Tool Edge 1 to call the following functions.
                else { edge = 1; }

                if (SelectedToolHasCuttingPosition)
                {
                    cuttingposition = ToolCuttingPositionsCollection[ToolCuttingPositionsCollection_SelectedIndex];
                }

                // Which turret offsets are in reference to?
                Okuma.EasyToolData.ToolLocation loc = EasyToolData_THINC_Tools.LocateTool(tool);

                if (loc.Where == ToolLocationEnum.A_Turret_2ND_Left) { AxisRef = "A-L"; }
                else if (loc.Where == ToolLocationEnum.A_Turret) { AxisRef = "A"; }
                else if (loc.Where == ToolLocationEnum.H1_Turret) { AxisRef = "A"; }
                else if (loc.Where == ToolLocationEnum.B_Turret) { AxisRef = "B"; }
                else if (loc.Where == ToolLocationEnum.C_Turret) { AxisRef = "C"; }
                else { AxisRef = ""; }

                // String to display if no result
                string noResult = "";

                string f = Global.NumberFormat;

                // Multi-function Lathes (MULTUS)
                if (multifunction)
                {
                    bool ok = EasyToolData_THINC_Tools.GetOffsetGroup(tool.ToInt(), edge, cuttingposition, out Okuma.EasyToolData.OffsetGroup OG);

                    if (ok)
                    {
                        if (OG.GroupNumber == 0) { FirstOffsetGroupNumber = ""; }
                        else { FirstOffsetGroupNumber = "No.  " + OG.GroupLabel; }

                        if (OG.ToolOffset.IsValid_X) { ToolOffset_X = OG.ToolOffset.Axis_X.ToString(f); }
                        else { ToolOffset_X = noResult; }

                        if (OG.ToolOffset.IsValid_Z) { ToolOffset_Z = OG.ToolOffset.Axis_Z.ToString(f); }
                        else { ToolOffset_Z = noResult; }

                        if (OG.ToolOffset.IsValid_YI) { ToolOffset_YI = OG.ToolOffset.Axis_YI.ToString(f); }
                        else { ToolOffset_YI = noResult; }

                        if (OG.ToolWear.IsValid_X) { Wear_X = OG.ToolWear.Axis_X.ToString(f); }
                        else { Wear_X = noResult; }

                        if (OG.ToolWear.IsValid_Z) { Wear_Z = OG.ToolWear.Axis_Z.ToString(f); }
                        else { Wear_Z = noResult; }

                        if (OG.Nose_R.Valid)
                        {
                            NoseR_X = OG.Nose_R.X.ToString(f);
                            NoseR_Z = OG.Nose_R.Z.ToString(f);
                            NoseR_P = ((int)OG.Nose_R.P).ToString() + "  (" + OG.Nose_R.P.ToString() + ")";
                        }
                        else
                        {
                            NoseR_X = noResult;
                            NoseR_Z = noResult;
                            NoseR_P = noResult;
                        }

                        // "Adjustment" is a MULTUS - only concept.
                        if (OG.Adjustment.IsValid_X) { Adjustment_X = OG.Adjustment.Axis_X.ToString(f); }
                        else { Adjustment_X = noResult; }

                        if (OG.Adjustment.IsValid_Z) { Adjustment_Z = OG.Adjustment.Axis_Z.ToString(f); }
                        else { Adjustment_Z = noResult; }

                        if (OG.Adjustment.IsValid_YI) { Adjustment_YI = OG.Adjustment.Axis_YI.ToString(f); }
                        else { Adjustment_YI = noResult; }

                    }
                }
                else if (Okuma.EasyToolData.Global.MachineType == BasicMachineType.L) // Standard Lathes
                {
                    bool ok = EasyToolData_THINC_Tools.GetOffsetGroup(tool.ToInt(), edge, cuttingposition, out Okuma.EasyToolData.OffsetGroup OG);
                    if (ok)
                    {
                        if (OG.GroupNumber == 0) { FirstOffsetGroupNumber = ""; }
                        else { FirstOffsetGroupNumber = "No.  " + OG.GroupLabel; }

                        if (OG.ToolOffset.IsValid_X) { ToolOffset_X = OG.ToolOffset.Axis_X.ToString(f); }
                        else { ToolOffset_X = noResult; }

                        if (OG.ToolOffset.IsValid_Z) { ToolOffset_Z = OG.ToolOffset.Axis_Z.ToString(f); }
                        else { ToolOffset_Z = noResult; }

                        if (OG.ToolOffset.IsValid_YI) { ToolOffset_YI = OG.ToolOffset.Axis_YI.ToString(f); }
                        else { ToolOffset_YI = noResult; }

                        if (OG.ToolWear.IsValid_X) { Wear_X = OG.ToolWear.Axis_X.ToString(f); }
                        else { Wear_X = noResult; }

                        if (OG.ToolWear.IsValid_Z) { Wear_Z = OG.ToolWear.Axis_Z.ToString(f); }
                        else { Wear_Z = noResult; }

                        if (OG.Nose_R.Valid)
                        {
                            NoseR_X = OG.Nose_R.X.ToString(f);
                            NoseR_Z = OG.Nose_R.Z.ToString(f);
                            NoseR_P = ((int)OG.Nose_R.P).ToString() + "  (" + OG.Nose_R.P.ToString() + ")";
                        }
                        else
                        {
                            NoseR_X = noResult;
                            NoseR_Z = noResult;
                            NoseR_P = noResult;
                        }

                    }

                    ok = EasyToolData_THINC_Tools.GetOffsetGroup2(tool.ToInt(), edge, cuttingposition, out Okuma.EasyToolData.OffsetGroup OG2);
                    if (ok)
                    {
                        if (OG2.GroupNumber == 0) { SecondOffsetGroupNumber = ""; }
                        else { SecondOffsetGroupNumber = "No.  " + OG2.GroupLabel; }

                        if (OG2.ToolOffset.IsValid_X) { ToolOffset_X2 = OG2.ToolOffset.Axis_X.ToString(f); }
                        else { ToolOffset_X2 = noResult; }

                        if (OG2.ToolOffset.IsValid_Z) { ToolOffset_Z2 = OG2.ToolOffset.Axis_Z.ToString(f); }
                        else { ToolOffset_Z2 = noResult; }

                        if (OG2.ToolOffset.IsValid_YI) { ToolOffset_YI2 = OG2.ToolOffset.Axis_YI.ToString(f); }
                        else { ToolOffset_YI2 = noResult; }

                        if (OG2.ToolWear.IsValid_X) { Wear_X2 = OG2.ToolWear.Axis_X.ToString(f); }
                        else { Wear_X2 = noResult; }

                        if (OG2.ToolWear.IsValid_Z) { Wear_Z2 = OG2.ToolWear.Axis_Z.ToString(f); }
                        else { Wear_Z2 = noResult; }

                        if (OG2.Nose_R.Valid)
                        {
                            NoseR_X2 = OG2.Nose_R.X.ToString(f);
                            NoseR_Z2 = OG2.Nose_R.Z.ToString(f);
                            NoseR_P2 = ((int)OG2.Nose_R.P).ToString() + "  (" + OG2.Nose_R.P.ToString() + ")";
                        }
                        else
                        {
                            NoseR_X2 = noResult;
                            NoseR_Z2 = noResult;
                            NoseR_P2 = noResult;
                        }

                    }
                }
                else if (Okuma.EasyToolData.Global.MachineType == BasicMachineType.M)
                {
                    // Mills are so different they need their own page.
                    InvalidMachineType = Visibility.Visible;
                }
            }
        }

        private void FindToolEdges()
        {
            ToolEdgeCollection.Clear();

            if (AllToolsCollection.Count > 0 && AllToolsCollection_SelectedIndex >= 0)
            {
                long tool = AllToolsCollection[AllToolsCollection_SelectedIndex];

                // Check if the selected tool is Multi-edge
                if (EasyToolData_THINC_Tools.GetIsMultiEdgeTool(tool) == ValidatedResponse.TRUE)
                {
                    // If it is Multi-edge, add its edges to the edge collection
                    foreach (int edge in EasyToolData_THINC_Tools.GetRegisteredToolEdges(tool))
                    {
                        ToolEdgeCollection.Add(edge);
                    }
                }

                // Determine if Edges were received, and make a default selection
                if (ToolEdgeCollection.Count > 0)
                {
                    ToolEdgeCollection_SelectedIndex = 0;
                    SelectedToolIsMultiEdge = true;
                }
                else { SelectedToolIsMultiEdge = false; }
            }
            else { SelectedToolIsMultiEdge = false; }
        }


        private void FindToolCuttingPositions()
        {
            ToolCuttingPositionsCollection.Clear();

            if (AllToolsCollection.Count > 0 && AllToolsCollection_SelectedIndex >= 0)
            {
                long tool = AllToolsCollection[AllToolsCollection_SelectedIndex];

                // Get Cutting Positions
                if (SelectedToolIsMultiEdge && ToolEdgeCollection.Count > 0 && ToolEdgeCollection_SelectedIndex >= 0)
                {
                    int edge = ToolEdgeCollection[ToolEdgeCollection_SelectedIndex];

                    foreach (int cutposition in EasyToolData_THINC_Tools.GetRegisteredCuttingPositions(tool, edge))
                    {
                        ToolCuttingPositionsCollection.Add(cutposition);
                    }
                }
                else
                {
                    foreach (int cutposition in EasyToolData_THINC_Tools.GetRegisteredCuttingPositions(tool))
                    {
                        ToolCuttingPositionsCollection.Add(cutposition);
                    }
                }

                // Determine if Cutting Positions were received, and make a default selection
                if (ToolCuttingPositionsCollection.Count > 0)
                {
                    ToolCuttingPositionsCollection_SelectedIndex = 0;
                    SelectedToolHasCuttingPosition = true;
                }
                else { SelectedToolHasCuttingPosition = false; }
            }
            else { SelectedToolHasCuttingPosition = false; }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
    } // END class

} // END namespace EasyToolData_TestApp.ViewModels