
namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System;
    using EasyToolData_TestApp.Models;


    class OptionalParameters_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        private const int MaxLongWords = 200;
        private const int MaxWords = 256;
        private const int MaxBitNumber = 72;

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.OptionalParameters EasyToolData_THINC_OptionalParameters;


        // Properties
        public ObservableCollection<WordValues> LongWordCollection { get; set; }
        public ObservableCollection<WordValues> WordCollection { get; set; }
        public ObservableCollection<BitValues> BitCollection { get; set; }


        // Command
        private DelegateCommand<bool> _executeCommand;
        public DelegateCommand<bool> ExecuteCommand
        {
            get
            {
                if (_executeCommand == null)
                {
                    _executeCommand = new DelegateCommand<bool>(
                        (s) => { Test_ThincOptionalParameters(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Constructor
        public OptionalParameters_ViewModel()
        {
            EasyToolData_THINC_OptionalParameters = new Okuma.EasyToolData.THINC.OptionalParameters();

            LongWordCollection = new ObservableCollection<WordValues>();
            WordCollection = new ObservableCollection<WordValues>();
            BitCollection = new ObservableCollection<BitValues>();
        }

        private void Test_ThincOptionalParameters()
        {
            LongWordCollection.Clear();

            for (int i = 1; i < MaxLongWords +1; i++)
            {
                LongWordCollection.Add(
                    new WordValues(i, EasyToolData_THINC_OptionalParameters.GetLongWord(i))
                    );
            }

            WordCollection.Clear();

            for (int i = 1; i < MaxWords + 1; i++)
            {
                // NOTE: During testing, indexes beyond 128 were not able to be obtained.
                //       This is a limitation of the current machine-side "Custom" API (not THINC API).
                //       Access the full range should be possible in future versions of OSP software.
                if (i > 128) { break; } 

                WordCollection.Add(
                    new WordValues(i, EasyToolData_THINC_OptionalParameters.GetWord(i))
                    );
            }

            BitCollection.Clear();

            for (int i = 1; i < MaxBitNumber + 1; i++)
            { 
                BitValues bv = new BitValues(
                    i,
                    ValidatedResponseToNullableBool(EasyToolData_THINC_OptionalParameters.GetBit(i, 0)),
                    ValidatedResponseToNullableBool(EasyToolData_THINC_OptionalParameters.GetBit(i, 1)),
                    ValidatedResponseToNullableBool(EasyToolData_THINC_OptionalParameters.GetBit(i, 2)),
                    ValidatedResponseToNullableBool(EasyToolData_THINC_OptionalParameters.GetBit(i, 3)),
                    ValidatedResponseToNullableBool(EasyToolData_THINC_OptionalParameters.GetBit(i, 4)),
                    ValidatedResponseToNullableBool(EasyToolData_THINC_OptionalParameters.GetBit(i, 5)),
                    ValidatedResponseToNullableBool(EasyToolData_THINC_OptionalParameters.GetBit(i, 6)),
                    ValidatedResponseToNullableBool(EasyToolData_THINC_OptionalParameters.GetBit(i, 7))
                    );

                BitCollection.Add(bv);
            } 
        }
 
        private bool? ValidatedResponseToNullableBool(Okuma.EasyToolData.Enums.ValidatedResponse vr)
        {
            switch (vr)
            {
                default: { return null; }
                case Okuma.EasyToolData.Enums.ValidatedResponse.TRUE: { return true; }
                case Okuma.EasyToolData.Enums.ValidatedResponse.FALSE: { return false; }     
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    } // End Class
} // End Namespace