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

    class Spindle_ViewModel : INotifyPropertyChanged
    {
        // Fields
        private bool GotValidSpindles = false;       
        Okuma.EasyToolData.THINC.Spindle EasyToolData_THINC_Spindle;

        // Properties
        public ObservableCollection<Okuma.EasyToolData.Enums.Spindles> ValidSpindlesCollection { get; set; }

        private Okuma.EasyToolData.Enums.Spindles _selectedSpindle;
        public Okuma.EasyToolData.Enums.Spindles SelectedSpindle 
        {
            get { return _selectedSpindle; }
            set { _selectedSpindle = value; OnPropertyChanged(nameof(SelectedSpindle)); SelectedSpindleChanged(); }
        }

        private int _actualSpindleRate;
        public int ActualSpindleRate
        {
            get { return _actualSpindleRate; }
            set { _actualSpindleRate = value; OnPropertyChanged(nameof(ActualSpindleRate)); }
        }

        private int _commandedSpindleRate;
        public int CommandedSpindleRate
        {
            get { return _commandedSpindleRate; }
            set { _commandedSpindleRate = value; OnPropertyChanged(nameof(CommandedSpindleRate)); }
        }

        private int _maxSpindlerateOverride;
        public int MaxSpindlerateOverride
        {
            get { return _maxSpindlerateOverride; }
            set { _maxSpindlerateOverride = value; OnPropertyChanged(nameof(MaxSpindlerateOverride)); }
        }

        private int _spindleLoad;
        public int SpindleLoad
        {
            get { return _spindleLoad; }
            set { _spindleLoad = value; OnPropertyChanged(nameof(SpindleLoad)); }
        }

        private int _spindleRateOverride;
        public int SpindleRateOverride
        {
            get { return _spindleRateOverride; }
            set { _spindleRateOverride = value; OnPropertyChanged(nameof(SpindleRateOverride)); }
        }

        private Okuma.EasyToolData.Enums.SpindleState _spindleState;
        public Okuma.EasyToolData.Enums.SpindleState SpindleState
        {
            get { return _spindleState; }
            set { _spindleState = value; OnPropertyChanged(nameof(SpindleState)); }
        }


        // Commands       
        public DelegateCommand<bool> ExecuteCommand { get; }

        // Constructor
        public Spindle_ViewModel()
        {
            EasyToolData_THINC_Spindle = new Okuma.EasyToolData.THINC.Spindle();
            ValidSpindlesCollection = new ObservableCollection<Okuma.EasyToolData.Enums.Spindles>();
            ExecuteCommand = new DelegateCommand<bool>(Test_ThincSpindle, CanExecute => true);            
        }

        // Methods
        private void Test_ThincSpindle(bool obj)
        {
            // Execute button should update valid spindles 
            // THEN selection of item in the collection should trigger the rest of the things to happen.
            // That way the other things will be updated if the user changes the selected thing.

            GotValidSpindles = false;
            ValidSpindlesCollection.Clear();

            foreach (Okuma.EasyToolData.Enums.Spindles s in EasyToolData_THINC_Spindle.ValidSpindles)
            {
                ValidSpindlesCollection.Add(s);
            }

            GotValidSpindles = true;

            if (ValidSpindlesCollection.Any())
            {
                SelectedSpindle = ValidSpindlesCollection.First();
            }
        }

        public void SelectedSpindleChanged()
        {
            if (GotValidSpindles && SelectedSpindle != Okuma.EasyToolData.Enums.Spindles.Unknown)
            {
                ActualSpindleRate = EasyToolData_THINC_Spindle.GetActualSpindleRate(SelectedSpindle);
                CommandedSpindleRate = EasyToolData_THINC_Spindle.GetCommandedSpindleRate(SelectedSpindle);
                MaxSpindlerateOverride = EasyToolData_THINC_Spindle.GetMaxSpindlerateOverride(SelectedSpindle);
                SpindleLoad = EasyToolData_THINC_Spindle.GetSpindleLoad(SelectedSpindle);
                SpindleRateOverride = EasyToolData_THINC_Spindle.GetSpindleRateOverride(SelectedSpindle);
                SpindleState = EasyToolData_THINC_Spindle.GetSpindleState(SelectedSpindle);
            }
        }

        public void ClearResults()
        {
            ActualSpindleRate = -3;
            CommandedSpindleRate = -3;
            MaxSpindlerateOverride = -3;
            SpindleLoad = -3;
            SpindleRateOverride = -3;
            SpindleState = Okuma.EasyToolData.Enums.SpindleState.Unknown;
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}