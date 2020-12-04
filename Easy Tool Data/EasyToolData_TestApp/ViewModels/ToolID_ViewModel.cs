
using System.ComponentModel;
using System.Windows;
using System;

using Okuma.EasyToolData.Enums;


namespace EasyToolData_TestApp.ViewModels
{
    class ToolID_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.OptionalParameters EasyToolData_THINC_OptionalParameters;


        // Properties

        private string _hasToolID;
        public string HasToolID
        {
            get { return _hasToolID; }
            set
            {
                _hasToolID = value;
                OnPropertyChanged("HasToolID");
            }
        }

        private Visibility _disabledCover;
        public Visibility DisabledCover
        {
            get { return _disabledCover; }
            set
            {
                _disabledCover = value;
                OnPropertyChanged("DisabledCover");
            }
        }

        private string _b38_7, _b57_0, _b57_1, _b57_2, _b57_3, _b57_4, _b57_6, _b57_7, _b58_0, _b58_1, _b58_3, _b58_6;

        public string B38_7 { get { return _b38_7; } set { _b38_7 = value; OnPropertyChanged("B38_7"); } }
        public string B57_0 { get { return _b57_0; } set { _b57_0 = value; OnPropertyChanged("B57_0"); } }
        public string B57_1 { get { return _b57_1; } set { _b57_1 = value; OnPropertyChanged("B57_1"); } }
        public string B57_2 { get { return _b57_2; } set { _b57_2 = value; OnPropertyChanged("B57_2"); } }
        public string B57_3 { get { return _b57_3; } set { _b57_3 = value; OnPropertyChanged("B57_3"); } }
        public string B57_4 { get { return _b57_4; } set { _b57_4 = value; OnPropertyChanged("B57_4"); } }
        public string B57_6 { get { return _b57_6; } set { _b57_6 = value; OnPropertyChanged("B57_6"); } }
        public string B57_7 { get { return _b57_7; } set { _b57_7 = value; OnPropertyChanged("B57_7"); } }
        public string B58_0 { get { return _b58_0; } set { _b58_0 = value; OnPropertyChanged("B58_0"); } }
        public string B58_1 { get { return _b58_1; } set { _b58_1 = value; OnPropertyChanged("B58_1"); } }
        public string B58_3 { get { return _b58_3; } set { _b58_3 = value; OnPropertyChanged("B58_3"); } }
        public string B58_6 { get { return _b58_6; } set { _b58_6 = value; OnPropertyChanged("B58_6"); } }


        // Commands

        private DelegateCommand<bool> _executeCommand;
        public DelegateCommand<bool> ExecuteCommand
        {
            get
            {
                if (_executeCommand == null)
                {
                    _executeCommand = new DelegateCommand<bool>(
                        (s) => { Execute_Method(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Constructor
        public ToolID_ViewModel()
        {
            DisabledCover = Visibility.Visible;
            EasyToolData_THINC_OptionalParameters = new Okuma.EasyToolData.THINC.OptionalParameters();  
        }

        // Methods

        private void Execute_Method()
        {
            try
            {
                if (Okuma.EasyToolData.Global.MachineType == BasicMachineType.M)
                {
                    if (Okuma.EasyToolData.Global.ThincAPI_Initialized)
                    {
                        Okuma.EasyToolData.THINC.Spec s = new Okuma.EasyToolData.THINC.Spec();
                        ValidatedResponse vr = s.Get(s.M.ToolIDFunction);

                        HasToolID = vr.ToString();

                        if (vr == ValidatedResponse.TRUE)
                        {
                            DisabledCover = Visibility.Hidden;

                            B38_7 = ValidatedResponseToString(EasyToolData_THINC_OptionalParameters.GetBit(38, 7));
                            B57_0 = ValidatedResponseToString(EasyToolData_THINC_OptionalParameters.GetBit(57, 0));
                            B57_1 = ValidatedResponseToString(EasyToolData_THINC_OptionalParameters.GetBit(57, 1));
                            B57_2 = ValidatedResponseToString(EasyToolData_THINC_OptionalParameters.GetBit(57, 2));
                            B57_3 = ValidatedResponseToString(EasyToolData_THINC_OptionalParameters.GetBit(57, 3));
                            B57_4 = ValidatedResponseToString(EasyToolData_THINC_OptionalParameters.GetBit(57, 4));
                            B57_6 = ValidatedResponseToString(EasyToolData_THINC_OptionalParameters.GetBit(57, 6));
                            B57_7 = ValidatedResponseToString(EasyToolData_THINC_OptionalParameters.GetBit(57, 7));
                            B58_0 = ValidatedResponseToString(EasyToolData_THINC_OptionalParameters.GetBit(58, 0));
                            B58_1 = ValidatedResponseToString(EasyToolData_THINC_OptionalParameters.GetBit(58, 1));
                            B58_3 = ValidatedResponseToString(EasyToolData_THINC_OptionalParameters.GetBit(58, 3));
                            B58_6 = ValidatedResponseToString(EasyToolData_THINC_OptionalParameters.GetBit(58, 6));
                        }
                    }
                    else { HasToolID = "FAIL"; }
                }
                else { HasToolID = "N/A"; }
            }
            catch (Exception ex)
            {
                Log.SendEx(ex, typeof(ToolCurrent_ViewModel).FullName, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private string ValidatedResponseToString(Okuma.EasyToolData.Enums.ValidatedResponse vr)
        {
            switch (vr)
            {
                default: { return "?"; }
                case Okuma.EasyToolData.Enums.ValidatedResponse.TRUE: { return "1"; }
                case Okuma.EasyToolData.Enums.ValidatedResponse.FALSE: { return "0"; }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}