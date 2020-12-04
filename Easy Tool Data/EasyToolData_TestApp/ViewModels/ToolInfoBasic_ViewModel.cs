
namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System;

    using Okuma.EasyToolData.Extensions;
    using Okuma.EasyToolData.Enums;


    class ToolInfoBasic_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.Tools EasyToolData_THINC_Tools;
        Okuma.EasyToolData.THINC.Program EasyToolData_THINC_Program;

        // Properties


        public ObservableCollection<long> AllToolsCollection { get; set; }

        private int _allToolsCollection_SelectedIndex;
        public int AllToolsCollection_SelectedIndex
        {
            get { return _allToolsCollection_SelectedIndex; }
            set
            {
                _allToolsCollection_SelectedIndex = value;
                OnPropertyChanged("AllToolsCollection_SelectedIndex");

                AllToolsCollection_SelectedIndexChanged();
            }
        }

        /// <summary> All Tools Collection Selected Tool - Registered Edges </summary>
        public ObservableCollection<int> ToolEdgeCollection { get; set; }
        

        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                OnPropertyChanged("Comment");
            }
        }

        private string _toolKind;
        public string ToolKind
        {
            get { return _toolKind; }
            set
            {
                _toolKind = value;
                OnPropertyChanged("ToolKind");
            }
        }

        private string _toolIsRegistered;
        public string ToolIsRegistered
        {
            get { return _toolIsRegistered; }
            set
            {
                _toolIsRegistered = value;
                OnPropertyChanged("ToolIsRegistered");
            }
        }

        private string _toolIsMounted;
        public string ToolIsMounted
        {
            get { return _toolIsMounted; }
            set
            {
                _toolIsMounted = value;
                OnPropertyChanged("ToolIsMounted");
            }
        }

        private string _toolIsMultiEdge;
        public string ToolIsMultiEdge
        {
            get { return _toolIsMultiEdge; }
            set
            {
                _toolIsMultiEdge = value;
                OnPropertyChanged("ToolIsMultiEdge");
            }
        }

        private bool _selectedToolIsMultiEdge = true;
        public bool SelectedToolIsMultiEdge
        {
            get { return _selectedToolIsMultiEdge; }
            set
            {
                _selectedToolIsMultiEdge = value;
                OnPropertyChanged("SelectedToolIsMultiEdge");
            }
        }

        private string _toolLocation;
        public string ToolLocation
        {
            get { return _toolLocation; }
            set
            {
                _toolLocation = value;
                OnPropertyChanged("ToolLocation");
            }
        }

        private string _toolSizeEnum;
        public string ToolSizeEnum
        {
            get { return _toolSizeEnum; }
            set
            {
                _toolSizeEnum = value;
                OnPropertyChanged("ToolSizeEnum");
            }
        }

        private string _toolSizeString;
        public string ToolSizeString
        {
            get { return _toolSizeString; }
            set
            {
                _toolSizeString = value;
                OnPropertyChanged("ToolSizeString");
            }
        }

        private string _used;
        public string Used
        {
            get { return _used; }
            set
            {
                _used = value;
                OnPropertyChanged("Used");
            }
        }

        // Commands
        public DelegateCommand<bool> ExecuteCommand { get; }
        public DelegateCommand<bool> SetCommentCommand { get; }
        

        // Constructor
        public ToolInfoBasic_ViewModel()
        {
            EasyToolData_THINC_Tools = new Okuma.EasyToolData.THINC.Tools();
            EasyToolData_THINC_Program = new Okuma.EasyToolData.THINC.Program();

            ExecuteCommand = new DelegateCommand<bool>(Execute_GetBasicToolInfo, CanExecute => true);
            SetCommentCommand = new DelegateCommand<bool>(SetToolComment, CanExecute => true);

            AllToolsCollection = new ObservableCollection<long>();
            ToolEdgeCollection = new ObservableCollection<int>();
        }


        // Methods

        private void Execute_GetBasicToolInfo(bool obj)
        {
            AllToolsCollection.Clear();

            foreach (long t in EasyToolData_THINC_Tools.GetToolsList())
            {
                AllToolsCollection.Add(t);
            }
            if (AllToolsCollection.Count > 0)
            {
                AllToolsCollection_SelectedIndex = 0;
            }
        }

        private void SetToolComment(bool obj)
        {
            if (!string.IsNullOrEmpty(Comment))
            {
                if (AllToolsCollection.Count > 0 && AllToolsCollection_SelectedIndex >= 0)
                {
                    long t = AllToolsCollection[AllToolsCollection_SelectedIndex];

                    EasyToolData_THINC_Tools.SetComment(t, Comment);
                }
            }
        }

        private void AllToolsCollection_SelectedIndexChanged()
        {
            GetToolDataBasic();
        }
        
        private void GetToolDataBasic()
        {
            if (AllToolsCollection.Count > 0 && AllToolsCollection_SelectedIndex >= 0)
            {
                long t = AllToolsCollection[AllToolsCollection_SelectedIndex];

                Comment = EasyToolData_THINC_Tools.GetComment(t);
                ToolKind = EasyToolData_THINC_Tools.GetKind(t);
                ToolIsRegistered = EasyToolData_THINC_Tools.GetIsRegisteredTool(t).ToString();
                ToolIsMounted = EasyToolData_THINC_Tools.GetIsMountedTool(t).ToString();
                ToolIsMultiEdge = EasyToolData_THINC_Tools.GetIsMultiEdgeTool(t).ToString();
                ToolSizeEnum = EasyToolData_THINC_Tools.GetToolSize(t).ToString();
                ToolSizeString = EasyToolData_THINC_Tools.GetToolSize(t).ToolSizeString();
                Used = EasyToolData_THINC_Program.GetIsUsedTool(t).ToString();
                SelectedToolIsMultiEdge = (EasyToolData_THINC_Tools.GetIsMultiEdgeTool(t) == ValidatedResponse.TRUE);

                Okuma.EasyToolData.ToolLocation location = EasyToolData_THINC_Tools.LocateTool(t);
                if (location.Where == ToolLocationEnum.Unmounted) { ToolLocation = "Not in the machine"; }
                else
                {
                    ToolLocation = string.Format("{0}, {1} {2}", 
                        location.Where,
                        location.Where.ToString_PotOrStation(), 
                        location.Pot_or_TurretStation);
                }

                ToolEdgeCollection.Clear();
                foreach (int e in EasyToolData_THINC_Tools.GetRegisteredToolEdges(t.ToInt()))
                {
                    ToolEdgeCollection.Add(e);
                }
            }
            else
            {
                Comment = "";
                ToolKind = "";
                ToolIsRegistered = "";
                ToolIsMounted = "";
                ToolIsMultiEdge = "";
                ToolLocation = "";
                ToolSizeEnum = "";
                ToolSizeString = "";
                Used = "";
                ToolEdgeCollection.Clear();
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
    }
}


