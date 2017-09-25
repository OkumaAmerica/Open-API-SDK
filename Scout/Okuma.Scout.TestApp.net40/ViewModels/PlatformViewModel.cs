


namespace Okuma.Scout.TestApp.net40.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System;
    

    class PlatformViewModel : INotifyPropertyChanged
    {

        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        /// <summary>Used to prevent access to Okuma.Scout.Display until user has executed 'Platform'.</summary>
        private bool platformExecuted = false;


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

        private string _controlType;
        public string ControlType
        {
            get { return _controlType; }
            set
            {
                _controlType = value;
                OnPropertyChanged("ControlType");
            }
        }
        
        private string _ospSuiteVersion;
        public string OspSuiteVersion
        {
            get { return _ospSuiteVersion; }
            set
            {
                _ospSuiteVersion = value;
                OnPropertyChanged("OspSuiteVersion");
            }
        }

        private string _panelType;
        public string PanelType
        {
            get { return _panelType; }
            set
            {
                _panelType = value;
                OnPropertyChanged("PanelType");
            }
        }

        private string _selectScreenMode;
        public string SelectScreenMode
        {
            get { return _selectScreenMode; }
            set
            {
                _selectScreenMode = value;
                OnPropertyChanged("SelectScreenMode");
            }
        }

        private string _displayInfo;
        public string DisplayInfo
        {
            get { return _displayInfo; }
            set
            {
                _displayInfo = value;
                OnPropertyChanged("DisplayInfo");
            }
        }

        private int _displaysSelectedIndex;
        public int DisplaysSelectedIndex
        {
            get { return _displaysSelectedIndex; }
            set
            {
                _displaysSelectedIndex = value;
                OnPropertyChanged("DisplaysSelectedIndex");
                ComboBoxDisplay_IndexChanged();
            }
        }

        private string _ncSoftPackageVersion;
        public string NcSoftPackageVersion
        {
            get { return _ncSoftPackageVersion; }
            set
            {
                _ncSoftPackageVersion = value;
                OnPropertyChanged("NcSoftPackageVersion");
            }
        }

        private string _ospRestrictions;
        public string OSPRestrictions
        {
            get { return _ospRestrictions; }
            set
            {
                _ospRestrictions = value;
                OnPropertyChanged("OSPRestrictions");
            }
        }

        private ObservableCollection<Scout.Display.DisplayInfo> _displaysCollection;
        public ObservableCollection<Scout.Display.DisplayInfo> DisplaysCollection
        {
            get
            {
                if (_displaysCollection == null) { _displaysCollection = 
                        new ObservableCollection<Scout.Display.DisplayInfo>(); }
                return _displaysCollection;
            }
            set
            {
                _displaysCollection = value;
                OnPropertyChanged("DisplaysCollection");
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
                        (s) => { ExecutePlatformTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Methods

        private void ExecutePlatformTests()
        {
            // This is where the machine and control type are determined.
            Okuma.Scout.Enums.MachineType currentMachine = Okuma.Scout.Platform.Machine;
            Okuma.Scout.Enums.ControlType currentControl = Okuma.Scout.Platform.Control;

            // The enumeration values for machine type can be cryptic ("PCNCM_M" for example..)
            // ConvertToMachineTypeString() returns a human readable version.
            MachineType = Okuma.Scout.Platform.ConvertToMachineTypeString(currentMachine);
            ControlType = currentControl.ToString();
            OspSuiteVersion = Okuma.Scout.Platform.OspSuiteVersion;
            NcSoftPackageVersion = Okuma.Scout.Platform.NcControlPackageVersion;
            OSPRestrictions = Okuma.Scout.SpecCode.OspRectrictions.ToString();

            // The PhysicalPanelSize enumeration isn't too bad, but the following lines of code
            // attempt to improve readability anyway as the result is for human consumption in this case.
            string PanelTypeEnumToText = "";
            Okuma.Scout.Enums.PhysicalPanelSize PPS = Okuma.Scout.Display.PanelType;
            switch (PPS)
            {
                case Okuma.Scout.Enums.PhysicalPanelSize.PnP_NonOsp:
                    {
                        PanelTypeEnumToText = @"Plug and Play Non-OSP panel";
                        break;
                    }
                case Okuma.Scout.Enums.PhysicalPanelSize.SixPointFiveInch:
                    {
                        PanelTypeEnumToText = @"6.5"" OSP panel";
                        break;
                    }
                case Okuma.Scout.Enums.PhysicalPanelSize.FifteenInch:
                    {
                        PanelTypeEnumToText = @"15"" OSP panel";
                        break;
                    }
                case Okuma.Scout.Enums.PhysicalPanelSize.NineteenInch:
                    {
                        PanelTypeEnumToText = @"19"" OSP panel";
                        break;
                    }
                case Okuma.Scout.Enums.PhysicalPanelSize.UnknownSize:
                    {
                        PanelTypeEnumToText = "OSP panel not recognized";
                        break;
                    }
                default:
                    {
                        PanelTypeEnumToText = "Not an OSP panel";
                        break;
                    }
            }
            PanelType = PanelTypeEnumToText;

            // The following code is only applicable on 19" panel sizes because the 15" displays do not include
            // the SELECTSCREEN tool. In that case, the result will be NA.
            string ScreenModeEnumToText = "";
            Okuma.Scout.Enums.NineteenInchScreenMode NISM = Okuma.Scout.Display.SelectScreenMode;
            switch (NISM)
            {
                case Okuma.Scout.Enums.NineteenInchScreenMode.FullScreen:
                    {
                        ScreenModeEnumToText = "Full Screen";
                        break;
                    }
                case Okuma.Scout.Enums.NineteenInchScreenMode.ModeA:
                    {
                        ScreenModeEnumToText = "A Mode (Windowed, lower left)";
                        break;
                    }
                case Okuma.Scout.Enums.NineteenInchScreenMode.ModeB:
                    {
                        ScreenModeEnumToText = "B Mode (Windowed, lower right)";
                        break;
                    }
                case Okuma.Scout.Enums.NineteenInchScreenMode.UnknownMode:
                    {
                        ScreenModeEnumToText = "Error: Unknown Screen Mode";
                        break;
                    }
                default:
                    {
                        ScreenModeEnumToText = "NA";
                        break;
                    }
            }
            SelectScreenMode = ScreenModeEnumToText;

            // Clear the display data and refresh it every time the Platform Execute button is clicked.
            DisplaysCollection.Clear();
            Okuma.Scout.Display.RefreshDisplayInfo();

            // Add the detected displays to the combo box
            foreach (KeyValuePair<int, Okuma.Scout.Display.DisplayInfo> DI in Okuma.Scout.Display.DisplayDictionary)
            {
                DisplaysCollection.Add(DI.Value);
            }
            platformExecuted = true;

            // Select the first item in the list (if any exist).
            if (DisplaysCollection.Count > 0)
            {
                DisplaysSelectedIndex = 0;
            }
        }

        /// <summary>
        /// When a display is selected from the combo box, show the information related
        /// to that display in the Display Information text box. </summary>
        private void ComboBoxDisplay_IndexChanged()
        {
            if (platformExecuted)
            {
                foreach (KeyValuePair<int, Okuma.Scout.Display.DisplayInfo> DI in Okuma.Scout.Display.DisplayDictionary)
                {
                    if (DI.Value.DisplayName == DisplaysCollection[DisplaysSelectedIndex].DisplayName)
                    {
                        string DisplayName = "Display Name: " + DI.Value.DisplayName;
                        string MonitorName = "Monitor Name: " + DI.Value.MonitorName;
                        string Primary = "Primary Display: " + DI.Value.Primary.ToString();
                        string Bounds = "Display Bounds: " + DI.Value.Bounds.ToString();
                        string WorkArea = "Display Work Area: " + DI.Value.WorkArea.ToString();
                        string DeviceID = "Device ID: " + DI.Value.DeviceID;
                        string DeviceKey = "Device Key: " + DI.Value.DeviceKey;

                        DisplayInfo =
                            DisplayName + Environment.NewLine +
                            MonitorName + Environment.NewLine +
                            Primary + Environment.NewLine +
                            Bounds + Environment.NewLine +
                            WorkArea + Environment.NewLine +
                            DeviceID + Environment.NewLine +
                            DeviceKey;
                    }
                }
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
