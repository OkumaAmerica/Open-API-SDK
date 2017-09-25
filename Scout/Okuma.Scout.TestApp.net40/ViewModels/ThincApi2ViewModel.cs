using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma.Scout.TestApp.net40.ViewModels
{
    using System.ComponentModel;

    
    class ThincApi2ViewModel : INotifyPropertyChanged
    {

        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;


        // Constructor

        public ThincApi2ViewModel()
        {

        }


        private string _isTAPICompatibleInput;
        public string IsTAPICompatibleInput
        {
            get { return _isTAPICompatibleInput; }
            set
            {
                _isTAPICompatibleInput = value;
                OnPropertyChanged("IsTAPICompatibleInput");
            }
        }

        private string _isTAPICompatibleResult;
        public string IsTAPICompatibleResult
        {
            get { return _isTAPICompatibleResult; }
            set
            {
                _isTAPICompatibleResult = value;
                OnPropertyChanged("IsTAPICompatibleResult");
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
                        (s) => { ExecuteThincApi2Tests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }


        private void ExecuteThincApi2Tests()
        {
            Version parsedInput;

            bool parsed = Version.TryParse(IsTAPICompatibleInput, out parsedInput);

            if (parsed)
            {
                //IsTAPICompatibleResult = parsedInput.ToString(); (test)
                bool isSupported = Okuma.Scout.ThincApi.DoesMachineSupportThincApiVersion(parsedInput);

                IsTAPICompatibleResult = isSupported.ToString();
            }
            else
            {
                IsTAPICompatibleResult = "Input is not a version.";
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
