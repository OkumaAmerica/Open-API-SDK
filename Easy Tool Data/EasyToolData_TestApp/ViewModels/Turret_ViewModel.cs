
namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;



    class Turret_ViewModel : INotifyPropertyChanged
    {

        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.Turret EasyToolData_THINC_Turret;

        // Properties
        
        public ObservableCollection<Models.TurretInfo> TurretCollection { get; set; }

        private bool _turretsExist = true;
        public bool TurretsExist
        {
            get { return _turretsExist; }
            set { _turretsExist = value; OnPropertyChanged(nameof(TurretsExist)); }
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
                        (s) => { Test_ThincTurret(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }


        // Constructor
        public Turret_ViewModel()
        {
            InvalidMachineType = Visibility.Hidden;

            EasyToolData_THINC_Turret = new Okuma.EasyToolData.THINC.Turret();

            TurretCollection = new ObservableCollection<Models.TurretInfo>();
        }

        // Methods

        private void Test_ThincTurret()
        {
            TurretCollection.Clear();

            if (Okuma.EasyToolData.Global.MachineType == Okuma.EasyToolData.Enums.BasicMachineType.L)
            {
                foreach (Okuma.EasyToolData.ToolLocation tts in EasyToolData_THINC_Turret.GetTurretsStationsAndTools())
                {
                    Models.TurretInfo ti = new Models.TurretInfo()
                    {
                        Turret = tts.Where.ToString(),
                        Station = tts.Pot_or_TurretStation.ToString(),
                        Tool = tts.ToolNumber.ToString()
                    };

                    TurretCollection.Add(ti);
                }
            }
            else
            {
                InvalidMachineType = Visibility.Visible;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}


