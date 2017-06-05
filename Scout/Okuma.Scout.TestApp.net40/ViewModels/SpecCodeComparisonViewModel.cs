using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma.Scout.TestApp.net40.ViewModels
{
    using System.ComponentModel;

    class SpecCodeComparisonViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties
        private string _machineType;
        public string MachineType
        {
            get { return _machineType; }
            set
            {
                _machineType = value;
                OnPropertyChanged("MachineType");
            }
        }

        private string _machineType_DMC;
        public string MachineType_DMC
        {
            get { return _machineType_DMC; }
            set
            {
                _machineType_DMC = value;
                OnPropertyChanged("MachineType_DMC");
            }
        }

        private string _plc1A;
        public string PLC1A
        {
            get { return _plc1A; }
            set
            {
                _plc1A = value;
                OnPropertyChanged("PLC1A");
            }
        }

        private string _plc1A_DMC;
        public string PLC1A_DMC
        {
            get { return _plc1A_DMC; }
            set
            {
                _plc1A_DMC = value;
                OnPropertyChanged("PLC1A_DMC");
            }
        }

        private string _plc1B;
        public string PLC1B
        {
            get { return _plc1B; }
            set
            {
                _plc1B = value;
                OnPropertyChanged("PLC1B");
            }
        }

        private string _plc1B_DMC;
        public string PLC1B_DMC
        {
            get { return _plc1B_DMC; }
            set
            {
                _plc1B_DMC = value;
                OnPropertyChanged("PLC1B_DMC");
            }
        }

        private string _plc2A;
        public string PLC2A
        {
            get { return _plc2A; }
            set
            {
                _plc2A = value;
                OnPropertyChanged("PLC2A");
            }
        }

        private string _plc2A_DMC;
        public string PLC2A_DMC
        {
            get { return _plc2A_DMC; }
            set
            {
                _plc2A_DMC = value;
                OnPropertyChanged("PLC2A_DMC");
            }
        }

        private string _plc2B;
        public string PLC2B
        {
            get { return _plc2B; }
            set
            {
                _plc2B = value;
                OnPropertyChanged("PLC2B");
            }
        }

        private string _plc2B_DMC;
        public string PLC2B_DMC
        {
            get { return _plc2B_DMC; }
            set
            {
                _plc2B_DMC = value;
                OnPropertyChanged("PLC2B_DMC");
            }
        }

        private string _ncSpecA;
        public string NCSpecA
        {
            get { return _ncSpecA; }
            set
            {
                _ncSpecA = value;
                OnPropertyChanged("NCSpecA");
            }
        }

        private string _ncSpecA_DMC;
        public string NCSpecA_DMC
        {
            get { return _ncSpecA_DMC; }
            set
            {
                _ncSpecA_DMC = value;
                OnPropertyChanged("NCSpecA_DMC");
            }
        }

        private string _ncSpecB;
        public string NCSpecB
        {
            get { return _ncSpecB; }
            set
            {
                _ncSpecB = value;
                OnPropertyChanged("NCSpecB");
            }
        }

        private string _ncSpecB_DMC;
        public string NCSpecB_DMC
        {
            get { return _ncSpecB_DMC; }
            set
            {
                _ncSpecB_DMC = value;
                OnPropertyChanged("NCSpecB_DMC");
            }
        }

        private string _ncBSpecA;
        public string NCBSpecA
        {
            get { return _ncBSpecA; }
            set
            {
                _ncBSpecA = value;
                OnPropertyChanged("NCBSpecA");
            }
        }

        private string _ncBSpecA_DMC;
        public string NCBSpecA_DMC
        {
            get { return _ncBSpecA_DMC; }
            set
            {
                _ncBSpecA_DMC = value;
                OnPropertyChanged("NCBSpecA_DMC");
            }
        }

        private string _ncBSpecB;
        public string NCBSpecB
        {
            get { return _ncBSpecB; }
            set
            {
                _ncBSpecB = value;
                OnPropertyChanged("NCBSpecB");
            }
        }

        private string _ncBSpecB_DMC;
        public string NCBSpecB_DMC
        {
            get { return _ncBSpecB_DMC; }
            set
            {
                _ncBSpecB_DMC = value;
                OnPropertyChanged("NCBSpecB_DMC");
            }
        }

        private bool? _match_PLC1A;
        public bool? Match_PLC1A
        {
            get { return _match_PLC1A; }
            set
            {
                _match_PLC1A = value;
                OnPropertyChanged("Match_PLC1A");
            }
        }

        private bool? _match_PLC1B;
        public bool? Match_PLC1B
        {
            get { return _match_PLC1B; }
            set
            {
                _match_PLC1B = value;
                OnPropertyChanged("Match_PLC1B");
            }
        }

        private bool? _match_PLC2A;
        public bool? Match_PLC2A
        {
            get { return _match_PLC2A; }
            set
            {
                _match_PLC2A = value;
                OnPropertyChanged("Match_PLC2A");
            }
        }

        private bool? _match_PLC2B;
        public bool? Match_PLC2B
        {
            get { return _match_PLC2B; }
            set
            {
                _match_PLC2B = value;
                OnPropertyChanged("Match_PLC2B");
            }
        }

        private bool? _match_NCA;
        public bool? Match_NCA
        {
            get { return _match_NCA; }
            set
            {
                _match_NCA = value;
                OnPropertyChanged("Match_NCA");
            }
        }

        private bool? _match_NCB;
        public bool? Match_NCB
        {
            get { return _match_NCB; }
            set
            {
                _match_NCB = value;
                OnPropertyChanged("Match_NCB");
            }
        }

        private bool? _match_NCBA;
        public bool? Match_NCBA
        {
            get { return _match_NCBA; }
            set
            {
                _match_NCBA = value;
                OnPropertyChanged("Match_NCBA");
            }
        }

        private bool? _match_NCBB;
        public bool? Match_NCBB
        {
            get { return _match_NCBB; }
            set
            {
                _match_NCBB = value;
                OnPropertyChanged("Match_NCBB");
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
                        (s) => { ExecuteSpecCodeCompareTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Methods

        private void ExecuteSpecCodeCompareTests()
        {
            MachineType = Okuma.Scout.SpecCode.NC.machineNameFromFile;
            MachineType_DMC = Okuma.Scout.DMC.MachineType;

            PLC1A = Okuma.Scout.SpecCode.PLC.GroupFirstHalf(Okuma.Scout.Enums.PLCSpecGroup.PLC1MG);
            PLC1B = Okuma.Scout.SpecCode.PLC.GroupSecondHalf(Okuma.Scout.Enums.PLCSpecGroup.PLC1MG);
            PLC2A = Okuma.Scout.SpecCode.PLC.GroupFirstHalf(Okuma.Scout.Enums.PLCSpecGroup.PLC2MG);
            PLC2B = Okuma.Scout.SpecCode.PLC.GroupSecondHalf(Okuma.Scout.Enums.PLCSpecGroup.PLC2MG);

            NCSpecA = Okuma.Scout.SpecCode.NC.GroupFirstHalf(Okuma.Scout.Enums.NCSpecGroup.NC1MG);
            NCSpecB = Okuma.Scout.SpecCode.NC.GroupSecondHalf(Okuma.Scout.Enums.NCSpecGroup.NC1MG);

            NCBSpecA = Okuma.Scout.SpecCode.NCB.GroupFirstHalf(Okuma.Scout.Enums.NCBSpecGroup.NCB1MG);
            NCBSpecB = Okuma.Scout.SpecCode.NCB.GroupSecondHalf(Okuma.Scout.Enums.NCBSpecGroup.NCB1MG);

            PLC1A_DMC = Okuma.Scout.SpecCode.PLC1_DMC_FirstHalf;
            PLC1B_DMC = Okuma.Scout.SpecCode.PLC1_DMC_SecondHalf;
            PLC2A_DMC = Okuma.Scout.SpecCode.PLC2_DMC_FirstHalf;
            PLC2B_DMC = Okuma.Scout.SpecCode.PLC2_DMC_SecondHalf;
            NCSpecA_DMC = Okuma.Scout.SpecCode.NC1_DMC_FirstHalf;
            NCSpecB_DMC = Okuma.Scout.SpecCode.NC1_DMC_SecondHalf;
            NCBSpecA_DMC = Okuma.Scout.SpecCode.NCB1_DMC_FirstHalf;
            NCBSpecB_DMC = Okuma.Scout.SpecCode.NCB1_DMC_SecondHalf;

            Match_PLC1A = Okuma.Scout.SpecCode.Match_PLC1_FirstHalf;
            Match_PLC1B = Okuma.Scout.SpecCode.Match_PLC1_SecondHalf;
            Match_PLC2A = Okuma.Scout.SpecCode.Match_PLC2_FirstHalf;
            Match_PLC2B = Okuma.Scout.SpecCode.Match_PLC2_SecondHalf;
            Match_NCA = Okuma.Scout.SpecCode.Match_NC1_FirstHalf;
            Match_NCB = Okuma.Scout.SpecCode.Match_NC1_SecondHalf;
            Match_NCBA = Okuma.Scout.SpecCode.Match_NCB1_FirstHalf;
            Match_NCBB = Okuma.Scout.SpecCode.Match_NCB1_SecondHalf;
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