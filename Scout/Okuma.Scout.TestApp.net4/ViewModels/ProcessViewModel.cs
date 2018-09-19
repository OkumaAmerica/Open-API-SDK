using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma.Scout.TestApp.net4.ViewModels
{
    using System.ComponentModel;

    class ProcessViewModel : INotifyPropertyChanged
    {

        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties

        private bool? _notifierRunning;
        public bool? NotifierRunning
        {
            get { return _notifierRunning; }
            set
            {
                _notifierRunning = value;
                OnPropertyChanged("NotifierRunning");
            }
        }

        private bool? _ebiFryRunning;
        public bool? EbiFryRunning
        {
            get { return _ebiFryRunning; }
            set
            {
                _ebiFryRunning = value;
                OnPropertyChanged("EbiFryRunning");
            }
        }

        private bool? _softSwitchRunning;
        public bool? SoftSwitchRunning
        {
            get { return _softSwitchRunning; }
            set
            {
                _softSwitchRunning = value;
                OnPropertyChanged("SoftSwitchRunning");
            }
        }

        private bool? _widgetManagerRunning;
        public bool? WidgetManagerRunning
        {
            get { return _widgetManagerRunning; }
            set
            {
                _widgetManagerRunning = value;
                OnPropertyChanged("WidgetManagerRunning");
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
                        (s) => { ExecuteProcessesTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Methods

        private void ExecuteProcessesTests()
        {
            NotifierRunning = Okuma.Scout.OspProcessInfo.ApiNotifierRunning;
            EbiFryRunning = Okuma.Scout.OspProcessInfo.EbiStartRunning;
            WidgetManagerRunning = Okuma.Scout.OspProcessInfo.WidgetManagerRunning;
            SoftSwitchRunning = Okuma.Scout.OspProcessInfo.SoftSwitchRunning;
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
