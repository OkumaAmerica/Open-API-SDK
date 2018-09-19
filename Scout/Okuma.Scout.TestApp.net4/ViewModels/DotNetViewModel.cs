using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma.Scout.TestApp.net4.ViewModels
{
    using System.ComponentModel;

    class DotNetViewModel : INotifyPropertyChanged
    {

        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties

        private bool? _dotNetInstalled10;
        public bool? DotNetInstalled10
        {
            get { return _dotNetInstalled10; }
            set
            {
                _dotNetInstalled10 = value;
                OnPropertyChanged("DotNetInstalled10");
            }
        }

        private bool? _dotNetInstalled11;
        public bool? DotNetInstalled11
        {
            get { return _dotNetInstalled11; }
            set
            {
                _dotNetInstalled11 = value;
                OnPropertyChanged("DotNetInstalled11");
            }
        }

        private bool? _dotNetInstalled20;
        public bool? DotNetInstalled20
        {
            get { return _dotNetInstalled20; }
            set
            {
                _dotNetInstalled20 = value;
                OnPropertyChanged("DotNetInstalled20");
            }
        }

        private bool? _dotNetInstalled30;
        public bool? DotNetInstalled30
        {
            get { return _dotNetInstalled30; }
            set
            {
                _dotNetInstalled30 = value;
                OnPropertyChanged("DotNetInstalled30");
            }
        }

        private bool? _dotNetInstalled35;
        public bool? DotNetInstalled35
        {
            get { return _dotNetInstalled35; }
            set
            {
                _dotNetInstalled35 = value;
                OnPropertyChanged("DotNetInstalled35");
            }
        }

        private bool? _dotNetInstalled40C;
        public bool? DotNetInstalled40C
        {
            get { return _dotNetInstalled40C; }
            set
            {
                _dotNetInstalled40C = value;
                OnPropertyChanged("DotNetInstalled40C");
            }
        }

        private bool? _dotNetInstalled40F;
        public bool? DotNetInstalled40F
        {
            get { return _dotNetInstalled40F; }
            set
            {
                _dotNetInstalled40F = value;
                OnPropertyChanged("DotNetInstalled40F");
            }
        }

        private bool? _dotNetInstalled45;
        public bool? DotNetInstalled45
        {
            get { return _dotNetInstalled45; }
            set
            {
                _dotNetInstalled45 = value;
                OnPropertyChanged("DotNetInstalled45");
            }
        }

        private bool? _dotNetInstalled451;
        public bool? DotNetInstalled451
        {
            get { return _dotNetInstalled451; }
            set
            {
                _dotNetInstalled451 = value;
                OnPropertyChanged("DotNetInstalled451");
            }
        }

        private bool? _dotNetInstalled452;
        public bool? DotNetInstalled452
        {
            get { return _dotNetInstalled452; }
            set
            {
                _dotNetInstalled452 = value;
                OnPropertyChanged("DotNetInstalled452");
            }
        }

        private bool? _dotNetInstalled46;
        public bool? DotNetInstalled46
        {
            get { return _dotNetInstalled46; }
            set
            {
                _dotNetInstalled46 = value;
                OnPropertyChanged("DotNetInstalled46");
            }
        }

        private bool? _dotNetInstalled461;
        public bool? DotNetInstalled461
        {
            get { return _dotNetInstalled461; }
            set
            {
                _dotNetInstalled461 = value;
                OnPropertyChanged("DotNetInstalled461");
            }
        }

        private bool? _dotNetInstalled462;
        public bool? DotNetInstalled462
        {
            get { return _dotNetInstalled462; }
            set
            {
                _dotNetInstalled462 = value;
                OnPropertyChanged("DotNetInstalled462");
            }
        }

        private bool? _dotNetInstalled47;
        public bool? DotNetInstalled47
        {
            get { return _dotNetInstalled47; }
            set
            {
                _dotNetInstalled47 = value;
                OnPropertyChanged("DotNetInstalled47");
            }
        }

        private bool? _dotNetInstalled471;
        public bool? DotNetInstalled471
        {
            get { return _dotNetInstalled471; }
            set
            {
                _dotNetInstalled471 = value;
                OnPropertyChanged("DotNetInstalled471");
            }
        }

        private bool? _dotNetInstalled472;
        public bool? DotNetInstalled472
        {
            get { return _dotNetInstalled472; }
            set
            {
                _dotNetInstalled472 = value;
                OnPropertyChanged("DotNetInstalled472");
            }
        }



        private string _servicePack10;
        public string ServicePack10
        {
            get { return _servicePack10; }
            set
            {
                _servicePack10 = value;
                OnPropertyChanged("ServicePack10");
            }
        }

        private string _servicePack11;
        public string ServicePack11
        {
            get { return _servicePack11; }
            set
            {
                _servicePack11 = value;
                OnPropertyChanged("ServicePack11");
            }
        }

        private string _servicePack20;
        public string ServicePack20
        {
            get { return _servicePack20; }
            set
            {
                _servicePack20 = value;
                OnPropertyChanged("ServicePack20");
            }
        }

        private string _servicePack30;
        public string ServicePack30
        {
            get { return _servicePack30; }
            set
            {
                _servicePack30 = value;
                OnPropertyChanged("ServicePack30");
            }
        }

        private string _servicePack35;
        public string ServicePack35
        {
            get { return _servicePack35; }
            set
            {
                _servicePack35 = value;
                OnPropertyChanged("ServicePack35");
            }
        }

        private string _servicePack40C;
        public string ServicePack40C
        {
            get { return _servicePack40C; }
            set
            {
                _servicePack40C = value;
                OnPropertyChanged("ServicePack40C");
            }
        }

        private string _servicePack40F;
        public string ServicePack40F
        {
            get { return _servicePack40F; }
            set
            {
                _servicePack40F = value;
                OnPropertyChanged("ServicePack40F");
            }
        }

        private string _releaseVersion45AndUp;
        public string ReleaseVersion45AndUp
        {
            get { return _releaseVersion45AndUp; }
            set
            {
                _releaseVersion45AndUp = value;
                OnPropertyChanged("ReleaseVersion45AndUp");
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
                        (s) => { ExecuteDotNetTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Methods

        private void ExecuteDotNetTests()
        {
            DotNetInstalled10 = Okuma.Scout.DotNet.v10_Installed;
            DotNetInstalled11 = Okuma.Scout.DotNet.v11_Installed;
            DotNetInstalled20 = Okuma.Scout.DotNet.v20_Installed;
            DotNetInstalled30 = Okuma.Scout.DotNet.v30_Installed;
            DotNetInstalled35 = Okuma.Scout.DotNet.v35_Installed;
            DotNetInstalled40C = Okuma.Scout.DotNet.v40Client_Installed;
            DotNetInstalled40F = Okuma.Scout.DotNet.v40Full_Installed;
            DotNetInstalled45 = Okuma.Scout.DotNet.v45_Installed;
            DotNetInstalled451 = Okuma.Scout.DotNet.v451_Installed;
            DotNetInstalled452 = Okuma.Scout.DotNet.v452_Installed;
            DotNetInstalled46 = Okuma.Scout.DotNet.v46_Installed;
            DotNetInstalled461 = Okuma.Scout.DotNet.v461_Installed;
            DotNetInstalled462 = Okuma.Scout.DotNet.v462_Installed;
            DotNetInstalled47 = Okuma.Scout.DotNet.v47_Installed;
            DotNetInstalled471 = Okuma.Scout.DotNet.v471_Installed;
            DotNetInstalled472 = Okuma.Scout.DotNet.v472_Installed;

            ServicePack10 = SPCheck(Okuma.Scout.DotNet.ServicePack_10);
            ServicePack11 = SPCheck(Okuma.Scout.DotNet.ServicePack_11);
            ServicePack20 = SPCheck(Okuma.Scout.DotNet.ServicePack_20);
            ServicePack30 = SPCheck(Okuma.Scout.DotNet.ServicePack_30);
            ServicePack35 = SPCheck(Okuma.Scout.DotNet.ServicePack_35);
            ServicePack40C = SPCheck(Okuma.Scout.DotNet.ServicePack_40Client);
            ServicePack40F = SPCheck(Okuma.Scout.DotNet.ServicePack_40Full);

            ReleaseVersion45AndUp = SPCheck(Okuma.Scout.DotNet.ReleaseVersion_45AndUp);
        }

        /// <summary>
        /// This function translates the return value of DotNet.ServicePack_.. 
        /// and replaces the invalid / error value of -1 with 'N/A'.
        /// </summary>
        /// <param name="sp">Integer representing the service pack</param>
        /// <returns>A string value representing the service pack</returns>
        private static string SPCheck(int sp)
        {
            if (sp == -1)
            {
                return "N/A";
            }
            else
            {
                return sp.ToString();
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
