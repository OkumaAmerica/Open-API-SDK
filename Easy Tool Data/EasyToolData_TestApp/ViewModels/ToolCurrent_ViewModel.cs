
namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System;
    using System.Linq;
    
    using Okuma.EasyToolData.Enums;
    using Okuma.EasyToolData.Extensions;


    class ToolCurrent_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        private const string invalid = "n/a";

        List<Okuma.EasyToolData.ToolLocation> currentToolList;

        Okuma.EasyToolData.THINC.Tools EasyToolData_THINC_Tools;

        // Properties

        private string _mainSpindleTool;
        public string MainSpindleTool
        {
            get { return _mainSpindleTool; }
            set
            {
                _mainSpindleTool = value;
                OnPropertyChanged("MainSpindleTool");
            }
        }
 
        private string _currentToolPot;
        public string CurrentToolPot
        {
            get { return _currentToolPot; }
            set
            {
                _currentToolPot = value;
                OnPropertyChanged("CurrentToolPot");
            }
        }

        private string _h1TurretStation;
        public string H1TurretStation
        {
            get { return _h1TurretStation; }
            set
            {
                _h1TurretStation = value;
                OnPropertyChanged("H1TurretStation");
            }
        }

        private string _h1TurretTool;
        public string H1TurretTool
        {
            get { return _h1TurretTool; }
            set
            {
                _h1TurretTool = value;
                OnPropertyChanged("H1TurretTool");
            }
        }

        private string _aTurretStation;
        public string ATurretStation
        {
            get { return _aTurretStation; }
            set
            {
                _aTurretStation = value;
                OnPropertyChanged("ATurretStation");
            }
        }

        private string _aTurretTool;
        public string ATurretTool
        {
            get { return _aTurretTool; }
            set
            {
                _aTurretTool = value;
                OnPropertyChanged("ATurretTool");
            }
        }

        private string _bTurretStation;
        public string BTurretStation
        {
            get { return _bTurretStation; }
            set
            {
                _bTurretStation = value;
                OnPropertyChanged("BTurretStation");
            }
        }

        private string _bTurretTool;
        public string BTurretTool
        {
            get { return _bTurretTool; }
            set
            {
                _bTurretTool = value;
                OnPropertyChanged("BTurretTool");
            }
        }

        private string _cTurretStation;
        public string CTurretStation
        {
            get { return _cTurretStation; }
            set
            {
                _cTurretStation = value;
                OnPropertyChanged("CTurretStation");
            }
        }

        private string _cTurretTool;
        public string CTurretTool
        {
            get { return _cTurretTool; }
            set
            {
                _cTurretTool = value;
                OnPropertyChanged("CTurretTool");
            }
        }

        private string _leftSideStation;
        public string LeftSideStation
        {
            get { return _leftSideStation; }
            set
            {
                _leftSideStation = value;
                OnPropertyChanged("LeftSideStation");
            }
        }

        private string _leftSideTool;
        public string LeftSideTool
        {
            get { return _leftSideTool; }
            set
            {
                _leftSideTool = value;
                OnPropertyChanged("LeftSideTool");
            }
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
                        (s) => { Execute_GetCurrentTools(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }


        // Constructor
        public ToolCurrent_ViewModel()
        {
            EasyToolData_THINC_Tools = new Okuma.EasyToolData.THINC.Tools();
            currentToolList = new List<Okuma.EasyToolData.ToolLocation>();
        }


        // Methods

        private void Execute_GetCurrentTools()
        {
            try
            {
                currentToolList = EasyToolData_THINC_Tools.GetListOfCurrentToolsAndStations();
                Okuma.EasyToolData.ToolLocation tl;

                // Mill Spindle
                if (currentToolList.Any(s => s.Where == ToolLocationEnum.Spindle))
                {
                    tl = currentToolList.FirstOrDefault(l => l.Where == ToolLocationEnum.Spindle);
                    // Std. Mill w/ out ToolID & Random ATC Mode can't get pot of current tool.
                    if (tl.Pot_or_TurretStation == -3) { CurrentToolPot = invalid; }
                    else { CurrentToolPot = tl.Pot_or_TurretStation.ToString(); } 
                    MainSpindleTool = tl.ToolNumber.ToString();
                }
                else { MainSpindleTool = CurrentToolPot = invalid; }

                // MULTUS Main Turret
                if (currentToolList.Any(s => s.Where == ToolLocationEnum.H1_Turret))
                {
                    tl = currentToolList.FirstOrDefault(l => l.Where == ToolLocationEnum.H1_Turret);
                    H1TurretStation = tl.Pot_or_TurretStation.ToString();
                    H1TurretTool = tl.ToolNumber.ToString();
                }
                else { H1TurretStation = H1TurretTool = invalid; }

                // Lathe A-turret
                if (currentToolList.Any(s => s.Where == ToolLocationEnum.A_Turret))
                {
                    tl = currentToolList.FirstOrDefault(l => l.Where == ToolLocationEnum.A_Turret);
                    ATurretStation = tl.Pot_or_TurretStation.ToString();
                    ATurretTool = tl.ToolNumber.ToString();
                }
                else { ATurretStation = ATurretTool = invalid; }

                // Lathe B-turret
                if (currentToolList.Any(s => s.Where == ToolLocationEnum.B_Turret))
                {
                    tl = currentToolList.FirstOrDefault(l => l.Where == ToolLocationEnum.B_Turret);
                    BTurretStation = tl.Pot_or_TurretStation.ToString();
                    BTurretTool = tl.ToolNumber.ToString();
                }
                else { BTurretStation = BTurretTool = invalid; }

                // Lathe C-turret
                    if (currentToolList.Any(s => s.Where == ToolLocationEnum.C_Turret))
                {
                    tl = currentToolList.FirstOrDefault(l => l.Where == ToolLocationEnum.C_Turret);
                    CTurretStation = tl.Pot_or_TurretStation.ToString();
                    CTurretTool = tl.ToolNumber.ToString();
                }
                else { CTurretStation = CTurretTool = invalid; }

                // 2SP Left Side
                if (currentToolList.Any(s => s.Where == ToolLocationEnum.A_Turret_2ND_Left))
                {
                    tl = currentToolList.FirstOrDefault(l => l.Where == ToolLocationEnum.A_Turret_2ND_Left);
                    LeftSideStation = tl.Pot_or_TurretStation.ToString();
                    LeftSideTool = tl.ToolNumber.ToString();
                }
                else { LeftSideStation = LeftSideTool = invalid; }
            }
            catch (Exception ex)
            {
                MainSpindleTool = "ERROR";
                Log.SendEx(ex, typeof(ToolCurrent_ViewModel).FullName, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }
        

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
    }
}