
namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System;
    using System.Windows;
    using System.Reflection;


    class ToolLists_ViewModel : INotifyPropertyChanged
    {
        //////////////////////////////////
        //  ______ _      _     _     
        //  |  ___(_)    | |   | |    
        //  | |_   _  ___| | __| |___ 
        //  |  _| | |/ _ \ |/ _` / __|
        //  | |   | |  __/ | (_| \__ \
        //  \_|   |_|\___|_|\__,_|___/

        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.Tools EasyToolData_THINC_Tools;


        /////////////////////////////////////////////////////////
        //  ______                          _   _           
        //  | ___ \                        | | (_)          
        //  | |_/ / __ ___  _ __   ___ _ __| |_ _  ___  ___ 
        //  |  __/ '__/ _ \| '_ \ / _ \ '__| __| |/ _ \/ __|
        //  | |  | | | (_) | |_) |  __/ |  | |_| |  __/\__ \
        //  \_|  |_|  \___/| .__/ \___|_|   \__|_|\___||___/
        //                 | |                              
        //                 |_|                              

        public ObservableCollection<long> AllToolsCollection { get; set; }

        public ObservableCollection<long> NotAttachedToolsCollection { get; set; }

        public ObservableCollection<long> AttachedToolsCollection { get; set; }


        private string _maxToolOffset;
        public string MaxToolOffset
        {
            get { return _maxToolOffset; }
            set
            {
                _maxToolOffset = value;
                OnPropertyChanged("MaxToolOffset");
            }
        }

        private string _toolListsLabel;
        public string ToolListsLabel
        {
            get { return _toolListsLabel; }
            set
            {
                _toolListsLabel = value;
                OnPropertyChanged("ToolListsLabel");
            }
        }

        private Visibility _onlyAttachedToolsValid;
        public Visibility OnlyAttachedToolsValid
        {
            get { return _onlyAttachedToolsValid; }
            set
            {
                _onlyAttachedToolsValid = value;
                OnPropertyChanged("OnlyAttachedToolsValid");
            }
        }


        /////////////////////////////////////////////////////////////
        //   _____                                           _     
        //  /  __ \                                         | |    
        //  | /  \/ ___  _ __ ___  _ __ ___   __ _ _ __   __| |___ 
        //  | |    / _ \| '_ ` _ \| '_ ` _ \ / _` | '_ \ / _` / __|
        //  | \__/\ (_) | | | | | | | | | | | (_| | | | | (_| \__ \
        //   \____/\___/|_| |_| |_|_| |_| |_|\__,_|_| |_|\__,_|___/

        private DelegateCommand<bool> _executeCommand;
        public DelegateCommand<bool> ExecuteCommand
        {
            get
            {
                if (_executeCommand == null)
                {
                    _executeCommand = new DelegateCommand<bool>(
                        (s) => { Execute_ToolLists(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }


        /////////////////////////////
        //   _____ _             
        //  /  __ \ |            
        //  | /  \/ |_ ___  _ __ 
        //  | |   | __/ _ \| '__|
        //  | \__/\ || (_) | |   
        //   \____/\__\___/|_|   

        public ToolLists_ViewModel()
        {
            EasyToolData_THINC_Tools = new Okuma.EasyToolData.THINC.Tools();

            // Note: Tool Number will only ever exceed Int32.MaxValue if run on Mill with Tool-ID Option.
            AllToolsCollection = new ObservableCollection<long>(); 
            AttachedToolsCollection = new ObservableCollection<long>();
            NotAttachedToolsCollection = new ObservableCollection<long>();

            OnlyAttachedToolsValid = Visibility.Hidden;
        }


        /////////////////////////////////////////////////
        //  ___  ___     _   _               _     
        //  |  \/  |    | | | |             | |    
        //  | .  . | ___| |_| |__   ___   __| |___ 
        //  | |\/| |/ _ \ __| '_ \ / _ \ / _` / __|
        //  | |  | |  __/ |_| | | | (_) | (_| \__ \
        //  \_|  |_/\___|\__|_| |_|\___/ \__,_|___/

        private void Execute_ToolLists()
        {
            try
            {
                MaxToolOffset = EasyToolData_THINC_Tools.MaxToolOffset().ToString();

                AttachedToolsCollection.Clear();
                foreach (long tool in EasyToolData_THINC_Tools.GetToolsList(Okuma.EasyToolData.Enums.ToolListType.Attached))
                {
                    AttachedToolsCollection.Add(tool);
                }

                if (Okuma.EasyToolData.Global.MachineType == Okuma.EasyToolData.Enums.BasicMachineType.M)
                {
                    OnlyAttachedToolsValid = Visibility.Visible;
                    ToolListsLabel = "  (Mill API 1.19 does not support getting non-attached tools)";
                }
                else
                {
                    NotAttachedToolsCollection.Clear();
                    foreach (long tool in EasyToolData_THINC_Tools.GetToolsList(Okuma.EasyToolData.Enums.ToolListType.NotAttached))
                    {
                        NotAttachedToolsCollection.Add(tool);
                    }

                    AllToolsCollection.Clear();
                    foreach (long tool in EasyToolData_THINC_Tools.GetToolsList(Okuma.EasyToolData.Enums.ToolListType.All))
                    {
                        AllToolsCollection.Add(tool);
                    }
                }
            }
            catch (Exception ex) 
            {
                Log.SendEx(ex, typeof(ToolLists_ViewModel).FullName, MethodBase.GetCurrentMethod().Name);
            }
        }


        //////////////////////////////////////
        //   _____                _       
        //  |  ___|              | |      
        //  | |____   _____ _ __ | |_ ___ 
        //  |  __\ \ / / _ \ '_ \| __/ __|
        //  | |___\ V /  __/ | | | |_\__ \
        //  \____/ \_/ \___|_| |_|\__|___/

        public event PropertyChangedEventHandler PropertyChanged;
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