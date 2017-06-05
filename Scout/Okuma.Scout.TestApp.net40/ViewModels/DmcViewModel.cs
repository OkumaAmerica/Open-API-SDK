using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma.Scout.TestApp.net40.ViewModels
{
    using System.Threading;
    using System.ComponentModel;
    using System.Collections.ObjectModel;

    class DmcViewModel : INotifyPropertyChanged
    {

        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties

        private ObservableCollection<string> _dmcResults;
        public ObservableCollection<string> DmcResults
        {
            get
            {
                if (_dmcResults == null) { _dmcResults = new ObservableCollection<string>(); }
                return _dmcResults;
            }
            set
            {
                _dmcResults = value;
                OnPropertyChanged("DmcResults");
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
                        (s) => { ExecuteDataManagementCardItemsTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Methods

        /// <summary> Using Scout, acquire information from the Data Management Card. </summary>
        private void ExecuteDataManagementCardItemsTests()
        {
            DmcResults.Clear();

            DmcResults.Add("OSP Type: " + Okuma.Scout.DMC.OSPType);
            DmcResults.Add("Machine Type: " + Okuma.Scout.DMC.MachineType);
            DmcResults.Add("S/W Production No.: " + Okuma.Scout.DMC.SoftwareProductionNo);
            DmcResults.Add("Serial Number: " + Okuma.Scout.DMC.SerialNumber);
            DmcResults.Add("S/W Production Date: " + Okuma.Scout.DMC.SoftwareProductionDate);
            DmcResults.Add("Customer Name: " + Okuma.Scout.DMC.CustomerName);
            DmcResults.Add("Customer Address: " + Okuma.Scout.DMC.CustomerAddress);
            DmcResults.Add("Customer Phone Number: " + Okuma.Scout.DMC.CustomerPhone);
            DmcResults.Add("Customer: " + Okuma.Scout.DMC.Customer);
            DmcResults.Add("Note One: " + Okuma.Scout.DMC.NoteOne);
            DmcResults.Add("Note Special Spec: " + Okuma.Scout.DMC.NoteSpecialSpec);
            DmcResults.Add("Note Comment: " + Okuma.Scout.DMC.NoteComment);
            DmcResults.Add("Windows System CD Version: " + Okuma.Scout.DMC.WindowsSystemCDVersion);
            DmcResults.Add("OSP System CD Version: " + Okuma.Scout.DMC.OSPSystemCDVersion);
            DmcResults.Add("Windows System: " + Okuma.Scout.DMC.WindowsSystem);
            DmcResults.Add("OTSS Sample CD Version: " + Okuma.Scout.DMC.OTSSSampleCDVersion);
            DmcResults.Add("Excel Version: " + Okuma.Scout.DMC.ExcelVersion);
            DmcResults.Add("CAS Models CD Version: " + Okuma.Scout.DMC.CASModelsCDVersion);
            DmcResults.Add("NC Installer: " + Okuma.Scout.DMC.NcInstaller);
            DmcResults.Add("Real Time Operating System Driver: " + Okuma.Scout.DMC.RTOSDriver);
            DmcResults.Add("Real Time Operating System: " + Okuma.Scout.DMC.RTOS);
            DmcResults.Add("NC Control: " + Okuma.Scout.DMC.NcControl);
            DmcResults.Add("PLC System: " + Okuma.Scout.DMC.PLCSystem);
            DmcResults.Add("PLC System Message: " + Okuma.Scout.DMC.PLCSystemMsg);              
            DmcResults.Add("P100 Tool: " + Okuma.Scout.DMC.P100Tool);
            DmcResults.Add("PLC Control: " + Okuma.Scout.DMC.PLCControl);
            DmcResults.Add("One Touch IGF: " + Okuma.Scout.DMC.OTI);
            DmcResults.Add("One Touch IGF Advanced M Machine Type: " + Okuma.Scout.DMC.OTIMT);
            DmcResults.Add("One Touch IGF Message: " + Okuma.Scout.DMC.OTIMsg);
            DmcResults.Add("Vertical Function Key: " + Okuma.Scout.DMC.VFK);
            DmcResults.Add("Vertical Function Key 2: " + Okuma.Scout.DMC.VFK2);
            DmcResults.Add("Vertical Function Key Message: " + Okuma.Scout.DMC.VFKMsg);
            DmcResults.Add("One Touch Spreadsheet File Controller: " + Okuma.Scout.DMC.OTSFileCntrl);
            DmcResults.Add("One Touch Spreadsheet File Controller Message: " + Okuma.Scout.DMC.OTSFileCntrlMsg);
            DmcResults.Add("One Touch Spreadsheet Pre-install Contents: " + Okuma.Scout.DMC.OTSPreInst);
            DmcResults.Add("IT Plaza Application Common: " + Okuma.Scout.DMC.ITPlaza);
            DmcResults.Add("Collision Avoidance System: " + Okuma.Scout.DMC.CAS);
            DmcResults.Add("Easy Modeling: " + Okuma.Scout.DMC.EasyModel);
            DmcResults.Add("Custom API: " + Okuma.Scout.DMC.CustomAPI);

            // List items:
            DmcResults.Add("NC Control MSG.: " + ListToString(Okuma.Scout.DMC.NcControlMsg, 20));
            DmcResults.Add("NC Alarm Help: " + ListToString(Okuma.Scout.DMC.NcAlarmHelp, 20));
            DmcResults.Add("NC Manual: " + ListToString(Okuma.Scout.DMC.NcManual, 20));
        }


        private string ListToString(List<string> L, int indent)
        {
            string ret = Environment.NewLine;
            foreach (string s in L)
            {
                ret += s.PadLeft(s.Length + indent) + Environment.NewLine;
            }
            ret = ret.TrimEnd('\r', '\n');
            return ret;
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
