
namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System;

    class ATC_ViewModel : INotifyPropertyChanged
    {
        // Fields

        public event PropertyChangedEventHandler PropertyChanged;
        private const bool AlwaysExecute = true;
        Okuma.EasyToolData.THINC.ATC EasyToolData_THINC_ATC;


        // Properties

        private string _hasATC;
        public string HasATC
        {
            get { return _hasATC; }
            set
            {
                _hasATC = value;
                OnPropertyChanged("HasATC");
            }
        }

        private string _addressModeATC;
        public string AddressModeATC
        {
            get { return _addressModeATC; }
            set
            {
                _addressModeATC = value;
                OnPropertyChanged("AddressModeATC");
            }
        }

        private int _magPots;
        public int MagPots
        {
            get { return _magPots; }
            set
            {
                _magPots = value;
                OnPropertyChanged("MagPots");
            }
        }

        private string _magKind;
        public string MagKind
        {
            get { return _magKind; }
            set
            {
                _magKind = value;
                OnPropertyChanged("MagKind");
            }
        }

        private string _toolInSpindle;
        public string ToolInSpindle
        {
            get { return _toolInSpindle; }
            set
            {
                _toolInSpindle = value;
                OnPropertyChanged("ToolInSpindle");
            }
        }

        private long _toolInput;
        public long ToolInput
        {
            get { return _toolInput; }
            set
            {
                _toolInput = value;
                OnPropertyChanged("ToolInput");
            }
        }

        private string _potOutput;
        public string PotOutput
        {
            get { return _potOutput; }
            set
            {
                _potOutput = value;
                OnPropertyChanged("PotOutput");
            }
        }

        private string _toolOutput;
        public string ToolOutput
        {
            get { return _toolOutput; }
            set
            {
                _toolOutput = value;
                OnPropertyChanged("ToolOutput");
            }
        }

        private int _potInput;
        public int PotInput
        {
            get { return _potInput; }
            set
            {
                _potInput = value;
                OnPropertyChanged("PotInput");
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
                        (s) => { Test_ThincATC(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }


        // Constructor
        public ATC_ViewModel()
        {
            EasyToolData_THINC_ATC = new Okuma.EasyToolData.THINC.ATC();

            ToolInput = 1;
            PotInput = 1;
        }


        // Methods

        private void Test_ThincATC()
        {
            Okuma.EasyToolData.Enums.ValidatedResponse hasAtc = EasyToolData_THINC_ATC.HasATC;
            HasATC = hasAtc.ToString();
            AddressModeATC = EasyToolData_THINC_ATC.GetAutomaticToolChangerAddressMode().ToString();
            MagPots = EasyToolData_THINC_ATC.MaxMagazinePots;
            MagKind = EasyToolData_THINC_ATC.GetMagazineKind().ToString();


            if (hasAtc == Okuma.EasyToolData.Enums.ValidatedResponse.TRUE)
            {
                ToolInSpindle = EasyToolData_THINC_ATC.GetToolNumberInSpindle().ToString();
                PotOutput = EasyToolData_THINC_ATC.GetPotNumber(ToolInput).ToString();
                ToolOutput = EasyToolData_THINC_ATC.GetToolNumberInMagazinePot(PotInput).ToString();
            }
            else
            {
                ToolInSpindle = "N/A";
                PotOutput = "N/A";
                ToolOutput = "N/A";
            }         
        }
        
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
