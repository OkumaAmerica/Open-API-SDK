
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



    class ToolEdgeInfo_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.Tools EasyToolData_THINC_Tools;



        // Properties

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
            set
            {
                _selectedToolIsMultiEdge = value;
                OnPropertyChanged(nameof(SelectedToolIsMultiEdge));
            }
        }

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

        private bool _selectedToolHasCuttingPositions;
        public bool SelectedToolHasCuttingPositions
        {
            get { return _selectedToolHasCuttingPositions; }
            set
            {
                _selectedToolHasCuttingPositions = value;
                OnPropertyChanged(nameof(SelectedToolHasCuttingPositions));
            }
        }

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

        private string _toolType;
        public string ToolType
        {
            get { return _toolType; }
            set { _toolType = value; OnPropertyChanged(nameof(ToolType)); }
        }

        private string _og1;
        public string OG1
        {
            get { return _og1; }
            set { _og1 = value; OnPropertyChanged(nameof(OG1)); }
        }

        private string _og2;
        public string OG2
        {
            get { return _og2; }
            set { _og2 = value; OnPropertyChanged(nameof(OG2)); }
        }

        private string _og3;
        public string OG3
        {
            get { return _og3; }
            set { _og3 = value; OnPropertyChanged(nameof(OG3)); }
        }

        private string _ba_Angle;
        public string BA_Angle
        {
            get { return _ba_Angle; }
            set { _ba_Angle = value; OnPropertyChanged(nameof(BA_Angle)); }
        }

        private string _cuttingPositionIsActive;
        public string CuttingPositionIsActive
        {
            get { return _cuttingPositionIsActive; }
            set { _cuttingPositionIsActive = value; OnPropertyChanged(nameof(CuttingPositionIsActive)); }
        }

        private string _spindleAxisMode;
        public string SpindleAxisMode
        {
            get { return _spindleAxisMode; }
            set { _spindleAxisMode = value; OnPropertyChanged(nameof(SpindleAxisMode)); }
        }

        private string _processKind;
        public string ProcessKind
        {
            get { return _processKind; }
            set { _processKind = value; OnPropertyChanged(nameof(ProcessKind)); }
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
                        (s) => { Execute(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }



        // Constructor
        public ToolEdgeInfo_ViewModel()
        {
            EasyToolData_THINC_Tools = new Okuma.EasyToolData.THINC.Tools();

            AllToolsCollection = new ObservableCollection<long>();
            ToolEdgeCollection = new ObservableCollection<int>();
            ToolCuttingPositionsCollection = new ObservableCollection<int>();
        }



        // Methods

        private void Execute()
        {
            AllToolsCollection.Clear();
            ToolEdgeCollection.Clear(); 
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
        /// If you don't use a lock such as this, `GetDataForPage4()` will be called 7 times in a row 
        /// any time `AllToolsCollection_SelectedIndexChanged()` is called, 
        /// and bad arguments will end up being passed, potentially resulting in exceptions.
        /// </summary>
        private bool IgnoreSelectedIndexChanges = false;

        private void AllToolsCollection_SelectedIndexChanged()
        {
            IgnoreSelectedIndexChanges = true;

            FindToolEdges();
            FindToolCuttingPositions();

            IgnoreSelectedIndexChanges = false;

            GetToolEdgeInfo();
        }

        private void ToolEdgeCollection_SelectedIndexChanged()
        {
            if (!IgnoreSelectedIndexChanges)
            {
                IgnoreSelectedIndexChanges = true;

                FindToolCuttingPositions();

                IgnoreSelectedIndexChanges = false;

                GetToolEdgeInfo();
            }
        }

        private void ToolCuttingPositionsCollection_SelectedIndexChanged()
        {
            if (!IgnoreSelectedIndexChanges)
            {
                GetToolEdgeInfo();
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
                //  Selected Tool
                long tool = AllToolsCollection[AllToolsCollection_SelectedIndex];

                // Get Cutting Positions (MULTUS / Multi-Function Machine Only)
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
                    SelectedToolHasCuttingPositions = true;
                }
                else { SelectedToolHasCuttingPositions = false; }
            }
            else { SelectedToolHasCuttingPositions = false; }
        }

        private void GetToolEdgeInfo()
        {
            long tool;
            int edge;
            int cuttingposition;

            if (AllToolsCollection.Count > 0 && AllToolsCollection_SelectedIndex >= 0)
            {
                tool = AllToolsCollection[AllToolsCollection_SelectedIndex];

                if (_selectedToolIsMultiEdge && ToolEdgeCollection.Count > 0 && ToolEdgeCollection_SelectedIndex >= 0)
                {
                    edge = ToolEdgeCollection[ToolEdgeCollection_SelectedIndex];
                }
                // Non Multi-Edge Tools use Tool Edge 1 to call the following functions.
                else { edge = 1; }
                
                ToolType = EasyToolData_THINC_Tools.GetToolType(tool, edge).ToString();
                
                bool ok = EasyToolData_THINC_Tools.GetReferenceToolOffset(OffsetReferenceGroup.OG1, tool, out double result_OG, edge);
                if (ok) { OG1 = result_OG.ToString(); }
                else { OG1 = "N/A"; }

                ok = EasyToolData_THINC_Tools.GetReferenceToolOffset(OffsetReferenceGroup.OG2, tool, out result_OG, edge);
                if (ok) { OG2 = result_OG.ToString(); }
                else { OG2 = "N/A"; }

                ok = EasyToolData_THINC_Tools.GetReferenceToolOffset(OffsetReferenceGroup.OG3, tool, out result_OG, edge);
                if (ok) { OG3 = result_OG.ToString(); }
                else { OG3 = "N/A"; }

                if (Okuma.EasyToolData.Global.Is_S_Control && SelectedToolHasCuttingPositions)
                {
                    cuttingposition = ToolCuttingPositionsCollection[ToolCuttingPositionsCollection_SelectedIndex];

                    BA_Angle = EasyToolData_THINC_Tools.GetBA_Angle(tool.ToInt(), edge, cuttingposition).ToString(Global.NumberFormat);
                    CuttingPositionIsActive = EasyToolData_THINC_Tools.GetIsActiveCuttingPosition(tool.ToInt(), edge, cuttingposition).ToString();
                    SpindleAxisMode = EasyToolData_THINC_Tools.GetSpindleAxisMode(tool, edge, cuttingposition);
                    ProcessKind = EasyToolData_THINC_Tools.GetToolProcessKind(tool, edge, cuttingposition).ToString();
                }
                else
                {
                    BA_Angle = Okuma.EasyToolData.Global.NO_RESULT;
                    CuttingPositionIsActive = Okuma.EasyToolData.Global.NO_RESULT;
                    SpindleAxisMode = Okuma.EasyToolData.Global.NO_RESULT;
                    ProcessKind = Okuma.EasyToolData.Global.NO_RESULT;
                }
 
            }
        }


        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    } // END class THINC_Tools_ViewModel4

} // END namespace EasyToolData_TestApp.ViewModels