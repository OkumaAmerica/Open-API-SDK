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

    using Okuma.EasyToolData.Extensions;


    class ToolScanner_ViewModel : INotifyPropertyChanged
    {
        //////////////////////////////////
        //  ______ _      _     _     
        //  |  ___(_)    | |   | |    
        //  | |_   _  ___| | __| |___ 
        //  |  _| | |/ _ \ |/ _` / __|
        //  | |   | |  __/ | (_| \__ \
        //  \_|   |_|\___|_|\__,_|___/

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        readonly Okuma.EasyToolData.THINC.Program EasyToolData_THINC_Program;


        /////////////////////////////////////////////////////////
        //  ______                          _   _           
        //  | ___ \                        | | (_)          
        //  | |_/ / __ ___  _ __   ___ _ __| |_ _  ___  ___ 
        //  |  __/ '__/ _ \| '_ \ / _ \ '__| __| |/ _ \/ __|
        //  | |  | | | (_) | |_) |  __/ |  | |_| |  __/\__ \
        //  \_|  |_|  \___/| .__/ \___|_|   \__|_|\___||___/
        //                 | |                              
        //                 |_|                              

        public ObservableCollection<Okuma.EasyToolData.OSP_Program> ProgramsCollection { get; set; }

        public ObservableCollection<Okuma.EasyToolData.ToolCalloutDetails> ToolCalloutsCollection { get; set; }


        private int _programsCollectionSelectedIndex;
        public int ProgramsCollectionSelectedIndex
        {
            get { return _programsCollectionSelectedIndex; }
            set
            {
                _programsCollectionSelectedIndex = value;
                DisplayProgramDetails();
                OnPropertyChanged("ProgramsCollectionSelectedIndex");
            }
        }
        
        private string _path;
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged("Path");
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
                        (s) => { Execute_ToolScanner(); },
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

        public ToolScanner_ViewModel()
        {
            ProgramsCollection = new ObservableCollection<Okuma.EasyToolData.OSP_Program>();
            ToolCalloutsCollection = new ObservableCollection<Okuma.EasyToolData.ToolCalloutDetails>();

            EasyToolData_THINC_Program = new Okuma.EasyToolData.THINC.Program();
        }


        ////////////////////////////////////////////////////////////////////////////
        //  ______     _            _        ___  ___     _   _               _     
        //  | ___ \   (_)          | |       |  \/  |    | | | |             | |    
        //  | |_/ / __ ___   ____ _| |_ ___  | .  . | ___| |_| |__   ___   __| |___ 
        //  |  __/ '__| \ \ / / _` | __/ _ \ | |\/| |/ _ \ __| '_ \ / _ \ / _` / __|
        //  | |  | |  | |\ V / (_| | ||  __/ | |  | |  __/ |_| | | | (_) | (_| \__ \
        //  \_|  |_|  |_| \_/ \__,_|\__\___| \_|  |_/\___|\__|_| |_|\___/ \__,_|___/

        private void Execute_ToolScanner()
        {
            ProgramsCollection.Clear();

            Okuma.EasyToolData.PartPrograms pp = new Okuma.EasyToolData.PartPrograms();

            foreach (Okuma.EasyToolData.OSP_Program ospp in pp.FindAllPrograms(UseCachedList: false))
            {
                ProgramsCollection.Add(ospp);
            }

            if (ProgramsCollection.Count > 0)
            {
                ProgramsCollectionSelectedIndex = 0;
            }
        }
        
        private void DisplayProgramDetails()
        {
            if (ProgramsCollection.Count > 0 && ProgramsCollectionSelectedIndex > -1)
            {
                Path = ProgramsCollection[ProgramsCollectionSelectedIndex].Path;

                Okuma.EasyToolData.PartPrograms pps = new Okuma.EasyToolData.PartPrograms();

                ToolCalloutsCollection.Clear();
                
                foreach (Okuma.EasyToolData.ToolCalloutDetails tcd in pps.GetToolList(Path, Okuma.EasyToolData.Global.MachineType))
                {
                    ToolCalloutsCollection.Add(tcd);
                }
            }
            else
            {
                ClearDetails();
            }
        }

        private void ClearDetails()
        {
            Path = "";
            ToolCalloutsCollection.Clear();

        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}