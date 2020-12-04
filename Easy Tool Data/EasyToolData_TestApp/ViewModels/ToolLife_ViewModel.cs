namespace EasyToolData_TestApp.ViewModels
{
    using System;
    using System.Windows;    
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using Okuma.EasyToolData.Extensions;
    using Okuma.EasyToolData.Enums;


    class ToolLife_ViewModel : INotifyPropertyChanged
    {        
        Okuma.EasyToolData.THINC.Tools EasyToolData_THINC_Tools;

        private bool IgnoreSelectedIndexChanges = false;


        // Properties

        public ObservableCollection<long> AllToolsCollection { get; set; }

        private int _allToolsCollection_SelectedIndex;
        public int AllToolsCollection_SelectedIndex
        {
            get { return _allToolsCollection_SelectedIndex; }
            set
            {
                _allToolsCollection_SelectedIndex = value;
                AllToolsCollection_SelectedIndexChanged();
                OnPropertyChanged(nameof(AllToolsCollection_SelectedIndex));
            }
        }

        /// <summary> Registered Tools Collection Selected Tool - Registered Edges </summary>
        public ObservableCollection<int> ToolEdgeCollection { get; set; }

        private int _toolEdgeCollection_SelectedIndex;
        public int ToolEdgeCollection_SelectedIndex
        {
            get { return _toolEdgeCollection_SelectedIndex; }
            set
            {
                _toolEdgeCollection_SelectedIndex = value;
                ToolEdgeCollection_SelectedIndexChanged();
                OnPropertyChanged(nameof(ToolEdgeCollection_SelectedIndex));
            }
        }

        public ObservableCollection<Okuma.EasyToolData.Enums.ToolLifeManagementMode> ManagementModeCollection { get; set; }

        private int _selectedManagementModeIndex;
        public int SelectedManagementModeIndex
        {
            get { return _selectedManagementModeIndex; }
            set
            {
                _selectedManagementModeIndex = value;
                OnPropertyChanged(nameof(SelectedManagementModeIndex));
            }
        }

        public ObservableCollection<Okuma.EasyToolData.Enums.ToolStatus> ToolLifeStatusCollection { get; set; }

        private int _selectedToolLifeStatusIndex;
        public int SelectedToolLifeStatusIndex
        {
            get { return _selectedToolLifeStatusIndex; }
            set
            {
                _selectedToolLifeStatusIndex = value;                
                OnPropertyChanged(nameof(SelectedToolLifeStatusIndex));
            }
        }

        private bool _selectedToolIsMultiEdge;
        public bool SelectedToolIsMultiEdge
        {
            get { return _selectedToolIsMultiEdge; }
            set { _selectedToolIsMultiEdge = value; OnPropertyChanged(nameof(SelectedToolIsMultiEdge)); }
        }

        private string _group;
        public string Group
        {
            get { return _group; }
            set { _group = value; OnPropertyChanged(nameof(Group)); }
        }

        private string _groupStatus;
        public string GroupStatus
        {
            get { return _groupStatus; }
            set { _groupStatus = value; OnPropertyChanged(nameof(GroupStatus)); }
        }

        private string _gaugeStatus;
        public string GaugeStatus
        {
            get { return _gaugeStatus; }
            set { _gaugeStatus = value; OnPropertyChanged(nameof(GaugeStatus)); }
        }

        private string _lifeStatus;
        public string LifeStatus
        {
            get { return _lifeStatus; }
            set { _lifeStatus = value; OnPropertyChanged(nameof(LifeStatus)); }
        }

        private string _lifeMode;
        public string LifeMode
        {
            get { return _lifeMode; }
            set { _lifeMode = value; OnPropertyChanged(nameof(LifeMode)); }
        }

        private string _setNumber;
        public string SetNumber
        {
            get { return _setNumber; }
            set { _setNumber = value; OnPropertyChanged(nameof(SetNumber)); }
        }

        private string _currentNumber;
        public string CurrentNumber
        {
            get { return _currentNumber; }
            set { _currentNumber = value; OnPropertyChanged(nameof(CurrentNumber)); }
        }

        private string _remainNumber;
        public string RemainNumber
        {
            get { return _remainNumber; }
            set { _remainNumber = value; OnPropertyChanged(nameof(RemainNumber)); }
        }

        private string _setTime;
        public string SetTime
        {
            get { return _setTime; }
            set { _setTime = value; OnPropertyChanged(nameof(SetTime)); }
        }

        private string _currentTime;
        public string CurrentTime
        {
            get { return _currentTime; }
            set { _currentTime = value; OnPropertyChanged(nameof(CurrentTime)); }
        }

        private string _remainTime;
        public string RemainTime
        {
            get { return _remainTime; }
            set { _remainTime = value; OnPropertyChanged(nameof(RemainTime)); }
        }

        private string _setWear;
        public string SetWear
        {
            get { return _setWear; }
            set { _setWear = value; OnPropertyChanged(nameof(SetWear)); }
        }

        private string _currentWear;
        public string CurrentWear
        {
            get { return _currentWear; }
            set { _currentWear = value; OnPropertyChanged(nameof(CurrentWear)); }
        }

        private string _remainWear;
        public string RemainWear
        {
            get { return _remainWear; }
            set { _remainWear = value; OnPropertyChanged(nameof(RemainWear)); }
        }

        private int _numberRemainingPercent;
        public int NumberRemainingPercent
        {
            get { return _numberRemainingPercent; }
            set { _numberRemainingPercent = value; OnPropertyChanged(nameof(NumberRemainingPercent)); }
        }

        private int _timeRemainingPercent;
        public int TimeRemainingPercent
        {
            get { return _timeRemainingPercent; }
            set { _timeRemainingPercent = value; OnPropertyChanged(nameof(TimeRemainingPercent)); }
        }

        private int _wearRemainingPercent;
        public int WearRemainingPercent
        {
            get { return _wearRemainingPercent; }
            set { _wearRemainingPercent = value; OnPropertyChanged(nameof(WearRemainingPercent)); }
        }

        private Visibility _hideWearLife = Visibility.Hidden;
        public Visibility HideWearLife
        {
            get { return _hideWearLife; }
            set { _hideWearLife = value; OnPropertyChanged(nameof(HideWearLife)); }
        }

        private bool _setToolLifeType_IsChecked_Set;
        public bool SetToolLifeType_IsChecked_Set
        {
            get { return _setToolLifeType_IsChecked_Set; }
            set { _setToolLifeType_IsChecked_Set = value; OnPropertyChanged(nameof(SetToolLifeType_IsChecked_Set)); }
        }

        private bool _setToolLifeType_IsChecked_Current;
        public bool SetToolLifeType_IsChecked_Current
        {
            get { return _setToolLifeType_IsChecked_Current; }
            set { _setToolLifeType_IsChecked_Current = value; OnPropertyChanged(nameof(SetToolLifeType_IsChecked_Current)); }
        }

        private bool _setToolLifeType_IsChecked_Remain;
        public bool SetToolLifeType_IsChecked_Remain
        {
            get { return _setToolLifeType_IsChecked_Remain; }
            set { _setToolLifeType_IsChecked_Remain = value; OnPropertyChanged(nameof(SetToolLifeType_IsChecked_Remain)); }
        }

        private string _setToolLifeInput_Workpieces;
        public string SetToolLifeInput_Workpieces
        {
            get { return _setToolLifeInput_Workpieces; }
            set { _setToolLifeInput_Workpieces = value; OnPropertyChanged(nameof(SetToolLifeInput_Workpieces)); }
        }


        // Commands

        public DelegateCommand<bool> ExecuteCommand { get; }
        public DelegateCommand<bool> SetManagementModeCommand { get; }
        public DelegateCommand<bool> SetToolLifeStatusCommand { get; }        
        public DelegateCommand<bool> SetToolLifeWorkpiecesCommand { get; }


        // Constructor
        public ToolLife_ViewModel()
        {
            EasyToolData_THINC_Tools = new Okuma.EasyToolData.THINC.Tools();

            AllToolsCollection = new ObservableCollection<long>();
            ToolEdgeCollection = new ObservableCollection<int>();

            ManagementModeCollection = new ObservableCollection<ToolLifeManagementMode>();
            foreach (Okuma.EasyToolData.Enums.ToolLifeManagementMode mode in Enum.GetValues(typeof(Okuma.EasyToolData.Enums.ToolLifeManagementMode)))
            {
                ManagementModeCollection.Add(mode);
            }

            ToolLifeStatusCollection = new ObservableCollection<ToolStatus>();
            foreach (Okuma.EasyToolData.Enums.ToolStatus status in Enum.GetValues(typeof(Okuma.EasyToolData.Enums.ToolStatus)))
            {
                ToolLifeStatusCollection.Add(status);
            }

            SetToolLifeType_IsChecked_Set = true;

            ExecuteCommand = new DelegateCommand<bool>(RefreshTools, CanExecute => true);
            SetManagementModeCommand = new DelegateCommand<bool>(SetManagementMode, CanExecuteSetFunctions);
            SetToolLifeStatusCommand = new DelegateCommand<bool>(SetToolLifeStatus, CanExecuteSetFunctions);
            SetToolLifeWorkpiecesCommand = new DelegateCommand<bool>(SetToolLifeWorkpieces, CanExecuteSetFunctions);
        }



        // Methods

        private void RefreshTools(bool obj)
        {
            // Do not react to 
            IgnoreSelectedIndexChanges = true;

            // Look for currently selected tool
            long selectedTool = -1;
            if (AllToolsCollection.Count > 0 && AllToolsCollection_SelectedIndex >= 0)
            {
                selectedTool = AllToolsCollection[AllToolsCollection_SelectedIndex];
            }

            // Do Clear / Refresh
            ToolEdgeCollection.Clear();
            AllToolsCollection.Clear();
            foreach (long t in EasyToolData_THINC_Tools.GetToolsList())
            {
                AllToolsCollection.Add(t);
            }
            if (AllToolsCollection.Count > 0)
            {
                AllToolsCollection_SelectedIndex = 0;
            }

            // Re-select previous selected tool
            if (selectedTool != -1)
            {
                for (int i = 0; i < AllToolsCollection.Count; i++)
                {
                    if (AllToolsCollection[i] == selectedTool)
                    {
                        AllToolsCollection_SelectedIndex = i;
                    }
                }
            }

            // Do Tool Edge Detection            
            FindToolEdges();
            
            IgnoreSelectedIndexChanges = false;

            // Do the real work
            GetToolLifeData();
        }

        private void AllToolsCollection_SelectedIndexChanged()
        {
            if (!IgnoreSelectedIndexChanges) { GetToolLifeData(); }
        }

        private void ToolEdgeCollection_SelectedIndexChanged()
        {
            if (!IgnoreSelectedIndexChanges) { GetToolLifeData(); }
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
                    // Mill is the only Machine type with type long tool numbers and does not have multi-edge tools.
                    foreach (int edge in EasyToolData_THINC_Tools.GetRegisteredToolEdges(tool.ToInt()))
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
        }

        [SuppressMessage("Rule Category Not Documented", "IDE0018:Variable Declaration", Justification = "Easier to read without In-Lining")]
        private void GetToolLifeData()
        {
            int edge;
            if (SelectedToolIsMultiEdge) { edge = ToolEdgeCollection[ToolEdgeCollection_SelectedIndex]; }
            // Non Multi-Edge Tools use Tool Edge 1 to call the following functions.
            else { edge = 1; }
            
            if (AllToolsCollection.Count > 0 && AllToolsCollection_SelectedIndex >= 0)
            {
                long tool = AllToolsCollection[AllToolsCollection_SelectedIndex];

                int groupNumber = EasyToolData_THINC_Tools.GetToolLifeGroupNumber(tool, edge);

                // In case of standard Lathe, list the turret with the group number.
                if (Okuma.EasyToolData.Global.MachineType == BasicMachineType.L && (Okuma.EasyToolData.Global.Is_S_Control == false))
                {
                    Group = EasyToolData_THINC_Tools.LocateTool(tool).Where.ToTurret().ToString() + " " + groupNumber.ToString();
                }
                else { Group = groupNumber.ToString(); }
                
                if (groupNumber > 0)
                {
                    // Mill does not need to provide a value for Turret, as it will be ignored.
                    // As written, this code will perform as expected on any machine type.
                    Turrets trt = EasyToolData_THINC_Tools.LocateTool(tool).Where.ToTurret();
                    ToolStatus tgs = EasyToolData_THINC_Tools.GetGroupToolLifeStatus(groupNumber, Turret: trt);
                    GroupStatus = tgs.ToString();
                }
                else { GroupStatus = Okuma.EasyToolData.Global.NO_RESULT; }

                GaugeStatus = EasyToolData_THINC_Tools.GetGaugeStatus(tool, edge).ToString();
                LifeStatus = EasyToolData_THINC_Tools.GetLifeStatus(tool, edge).ToString();
                LifeMode = EasyToolData_THINC_Tools.GetToolLifeManagementMode(tool).ToString();

                // TOOL LIFE: By Number Of Workpieces
                ValidatedResponse GotSet_Pieces = EasyToolData_THINC_Tools.GetToolLife_Workpieces(tool, ToolLifeType.Set, out int temp_SetNumber, edge);
                if (GotSet_Pieces == ValidatedResponse.TRUE) { SetNumber = temp_SetNumber.ToString(); }
                else if (GotSet_Pieces == ValidatedResponse.FALSE) { SetNumber = Okuma.EasyToolData.Global.NO_RESULT; }
                else { SetNumber = GotSet_Pieces.ToString(); }

                ValidatedResponse GotCurrent_Pieces = EasyToolData_THINC_Tools.GetToolLife_Workpieces(tool, ToolLifeType.Current, out int temp_WorkNumber, edge);
                if (GotCurrent_Pieces == ValidatedResponse.TRUE) { CurrentNumber = temp_WorkNumber.ToString(); }
                else if (GotCurrent_Pieces == ValidatedResponse.FALSE) { CurrentNumber = Okuma.EasyToolData.Global.NO_RESULT; }
                else { CurrentNumber = GotCurrent_Pieces.ToString(); }

                ValidatedResponse GotRemain_Pieces = EasyToolData_THINC_Tools.GetToolLife_Workpieces(tool, ToolLifeType.Remaining, out int temp_RemainNumber, edge);
                if (GotRemain_Pieces == ValidatedResponse.TRUE) { RemainNumber = temp_RemainNumber.ToString(); }
                else if (GotRemain_Pieces == ValidatedResponse.FALSE) { RemainNumber = Okuma.EasyToolData.Global.NO_RESULT; }
                else { RemainNumber = GotRemain_Pieces.ToString(); }

                ValidatedResponse GetPercent_Pieces = EasyToolData_THINC_Tools.GetToolLife_PercentWorkpieces(tool, out int temp_PercentNumber, edge);
                NumberRemainingPercent = temp_PercentNumber;

                // TOOL LIFE: By Cutting Time
                TimeSpan temp_SetTime;
                ValidatedResponse GotSet_CutTime = EasyToolData_THINC_Tools.GetToolLife_CuttingTime(tool, ToolLifeType.Set, out temp_SetTime, edge);
                if (GotSet_CutTime == ValidatedResponse.TRUE) { SetTime = temp_SetTime.ToString(@"hh\:mm\:ss"); }
                else { SetTime = GotSet_CutTime.ToString(); }
                
                TimeSpan temp_CurrentTime;
                ValidatedResponse GotCurrent_CutTime = EasyToolData_THINC_Tools.GetToolLife_CuttingTime(tool, ToolLifeType.Current, out temp_CurrentTime, edge);
                if (GotCurrent_CutTime == ValidatedResponse.TRUE) { CurrentTime = temp_CurrentTime.ToString(@"hh\:mm\:ss"); }
                else { CurrentTime = GotCurrent_CutTime.ToString(); }

                TimeSpan temp_RemainTime;
                ValidatedResponse GotRemain_CutTime = EasyToolData_THINC_Tools.GetToolLife_CuttingTime(tool, ToolLifeType.Remaining, out temp_RemainTime, edge);
                if (GotRemain_CutTime == ValidatedResponse.TRUE) { RemainTime = temp_RemainTime.ToString(@"hh\:mm\:ss"); }
                else { RemainTime = GotRemain_CutTime.ToString(); }

                int temp_PercentCutTime;
                ValidatedResponse GetPercent_CutTime = EasyToolData_THINC_Tools.GetToolLife_PercentCuttingTime(tool, out temp_PercentCutTime, edge);
                TimeRemainingPercent = temp_PercentCutTime;

                // Milling machines can not track tool life by wear, AFAIK.
                if (Okuma.EasyToolData.Global.MachineType == BasicMachineType.M) 
                {
                    HideWearLife = Visibility.Visible;
                    SetWear = "N/A";
                    CurrentWear = "N/A";
                    RemainWear = "N/A";
                }
                else
                {
                    // TOOL LIFE: By Wear
                    ValidatedResponse GotSet_Wear = EasyToolData_THINC_Tools.GetToolLife_Wear(tool, ToolLifeType.Set, out double temp_SetWear, edge);
                    if (GotSet_Wear == ValidatedResponse.TRUE) { SetWear = temp_SetWear.ToString(); }
                    else if (GotSet_Wear == ValidatedResponse.FALSE) { SetWear = Okuma.EasyToolData.Global.NO_RESULT; }
                    else { SetWear = GotSet_Wear.ToString(); }

                    ValidatedResponse GotCurrent_Wear = EasyToolData_THINC_Tools.GetToolLife_Wear(tool, ToolLifeType.Current, out double temp_CurrentWear, edge);
                    if (GotCurrent_Wear == ValidatedResponse.TRUE) { CurrentWear = temp_CurrentWear.ToString(); }
                    else if (GotCurrent_Wear == ValidatedResponse.FALSE) { CurrentWear = Okuma.EasyToolData.Global.NO_RESULT; }
                    else { CurrentWear = GotCurrent_Wear.ToString(); }

                    ValidatedResponse GotRemain_Wear = EasyToolData_THINC_Tools.GetToolLife_Wear(tool, ToolLifeType.Remaining, out double temp_RemainWear, edge);
                    if (GotRemain_Wear == ValidatedResponse.TRUE) { RemainWear = temp_RemainWear.ToString(); }
                    else if (GotRemain_Wear == ValidatedResponse.FALSE) { RemainWear = Okuma.EasyToolData.Global.NO_RESULT; }
                    else { RemainWear = GotRemain_Wear.ToString(); }

                    int temp_PercentWear;
                    ValidatedResponse GetPercentWear = EasyToolData_THINC_Tools.GetToolLife_PercentWear(tool, out temp_PercentWear, edge);
                    WearRemainingPercent = temp_PercentWear;
                }
            }
            else
            {
                string clear = "";

                Group = clear;
                GroupStatus = clear;
                GaugeStatus = clear;
                LifeStatus = clear;
                LifeMode = clear;
                SetNumber = clear;
                CurrentNumber = clear;
                SetTime = clear;
                CurrentTime = clear;
                SetWear = clear;
                CurrentWear = clear;
            }

            SetManagementModeCommand.RaiseCanExecuteChanged();
            SetToolLifeStatusCommand.RaiseCanExecuteChanged();
            SetToolLifeWorkpiecesCommand.RaiseCanExecuteChanged();
        }

        private bool CanExecuteSetFunctions(bool obj)
        {
            if (AllToolsCollection.Count > 0 && AllToolsCollection_SelectedIndex >= 0)
            {
                return true;
            }
            return false;
        }

        private void SetManagementMode(bool obj)
        {            
            long selectedTool = AllToolsCollection[AllToolsCollection_SelectedIndex];
            Okuma.EasyToolData.Enums.ToolLifeManagementMode tlmm = ManagementModeCollection[SelectedManagementModeIndex];
            EasyToolData_THINC_Tools.SetToolLifeManagementMode(selectedTool, tlmm);

            // Update 
            GetToolLifeData();
        }

        private void SetToolLifeStatus(bool obj)
        {
            long selectedTool = AllToolsCollection[AllToolsCollection_SelectedIndex];
            Okuma.EasyToolData.Enums.ToolStatus status = ToolLifeStatusCollection[SelectedToolLifeStatusIndex];
            EasyToolData_THINC_Tools.SetToolLifeStatus(selectedTool, status);

            // Update 
            GetToolLifeData();
        }

        private void SetToolLifeWorkpieces(bool obj)
        {            
            Okuma.EasyToolData.Enums.ToolLifeType lifeType = ToolLifeType.Set;
            if (SetToolLifeType_IsChecked_Current) { lifeType = ToolLifeType.Current; }
            else if (SetToolLifeType_IsChecked_Remain) { lifeType = ToolLifeType.Remaining; }

            long selectedTool = AllToolsCollection[AllToolsCollection_SelectedIndex];
            
            bool validValue = Int32.TryParse(SetToolLifeInput_Workpieces, out int newValue);
            if (validValue)
            {                
                if (SelectedToolIsMultiEdge)
                {
                    int edge = ToolEdgeCollection[ToolEdgeCollection_SelectedIndex];
                    EasyToolData_THINC_Tools.SetToolLife_Workpieces(selectedTool, lifeType, newValue, edge);
                }
                else
                {
                    EasyToolData_THINC_Tools.SetToolLife_Workpieces(selectedTool, lifeType, newValue);
                }

                // Update 
                GetToolLifeData();
            }
            else
            {
                MessageBox.Show("Invalid input value for Set Tool Life Workpieces.");
                SetToolLifeInput_Workpieces = "";
            }
        }

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }        
    }
}