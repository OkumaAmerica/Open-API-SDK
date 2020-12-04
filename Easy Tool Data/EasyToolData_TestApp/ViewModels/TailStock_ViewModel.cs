
namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System;

    using Okuma.EasyToolData.Enums;

    class TailStock_ViewModel : INotifyPropertyChanged
    {
        // Class Variables     

        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.TailStock EasyToolData_THINC_TailStock;

        // Properties

        private string _hasTailStock;
        public string HasTailStock
        {
            get { return _hasTailStock; }
            set
            {
                _hasTailStock = value;
                OnPropertyChanged("HasTailStock");
            }
        }


        private string _position;
        public string Position
        {
            get { return _position; }
            set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }


        private string _length_L;
        public string Length_L
        {
            get { return _length_L; }
            set
            {
                _length_L = value;
                OnPropertyChanged("Length_L");
            }
        }

        private string _length_L1;
        public string Length_L1
        {
            get { return _length_L1; }
            set
            {
                _length_L1 = value;
                OnPropertyChanged("Length_L1");
            }
        }

        private string _length_L2;
        public string Length_L2
        {
            get { return _length_L2; }
            set
            {
                _length_L2 = value;
                OnPropertyChanged("Length_L2");
            }
        }

        private string _diameter_D;
        public string Diameter_D
        {
            get { return _diameter_D; }
            set
            {
                _diameter_D = value;
                OnPropertyChanged("Diameter_D");
            }
        }

        private string _diameter_D1;
        public string Diameter_D1
        {
            get { return _diameter_D1; }
            set
            {
                _diameter_D1 = value;
                OnPropertyChanged("Diameter_D1");
            }
        }

        private string _diameter_D2;
        public string Diameter_D2
        {
            get { return _diameter_D2; }
            set
            {
                _diameter_D2 = value;
                OnPropertyChanged("Diameter_D2");
            }
        }

        private string _diameter_D3;
        public string Diameter_D3
        {
            get { return _diameter_D3; }
            set
            {
                _diameter_D3 = value;
                OnPropertyChanged("Diameter_D3");
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
                        (s) => { Execute_TailStock(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }


        // Constructor

        public TailStock_ViewModel()
        {
            EasyToolData_THINC_TailStock = new Okuma.EasyToolData.THINC.TailStock();
        }


        // Methods

        private void Execute_TailStock()
        {
            ValidatedResponse vr;
            HasTailStock = EasyToolData_THINC_TailStock.HasTailStock.ToString();

            vr = EasyToolData_THINC_TailStock.GetTailStockLength(out double dVal);
            Length_L = ReportValue(vr, dVal);

            vr = EasyToolData_THINC_TailStock.GetTailStockLength1(out dVal);
            Length_L1 = ReportValue(vr, dVal);

            vr = EasyToolData_THINC_TailStock.GetTailStockLength2(out dVal);
            Length_L2 = ReportValue(vr, dVal);

            vr = EasyToolData_THINC_TailStock.GetTailStockDiameter(out dVal);
            Diameter_D = ReportValue(vr, dVal);

            vr = EasyToolData_THINC_TailStock.GetTailStockDiameter1(out dVal);
            Diameter_D1 = ReportValue(vr, dVal);

            vr = EasyToolData_THINC_TailStock.GetTailStockDiameter2(out dVal);
            Diameter_D2 = ReportValue(vr, dVal);

            vr = EasyToolData_THINC_TailStock.GetTailStockHoleDiameter3(out dVal);
            Diameter_D3 = ReportValue(vr, dVal);

            vr = EasyToolData_THINC_TailStock.GetTailStockPosition(out dVal);
            Position = ReportValue(vr, dVal);
        }

        private string ReportValue(ValidatedResponse vr, double val)
        {
            if (vr == ValidatedResponse.TRUE)
            {
                return val.ToString();
            }
            else if (vr == ValidatedResponse.FALSE)
            {
                return @"N/A";
            }
            else
            {
                return vr.ToString();
            }
        }


        // Events

        public event PropertyChangedEventHandler PropertyChanged;
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
