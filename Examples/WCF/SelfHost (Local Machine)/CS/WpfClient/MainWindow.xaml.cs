/*
!!! WARNING !!!
YOU SHOULD NEVER USE THIS EXAMPLE CODE IN A PRODUCTION ENVIRONMENT!

Modifying variables on a machine which is in production HAS RESULTED IN MACHINE
CRASHES AND PROPERTY DAMAGE, AND COULD RESULT IN PERSONAL INJURY OR EVEN DEATH!

This example does not include any transport security, message security, authentication, 
or authorization of clients.It is configured to operate only on the local machine. 

IF you decide to MODIFY this example to operate over a network connection, compile and
deploy any part of this code in a production environment, YOU ACCEPT ALL RESPONSIBILTY 
for the outcome, however detrimental, and AGREE that OKUMA CANNOT BE HELD LIABLE 
for your poor judgment and failure to heed this warning.
*/

using System;
using System.Windows;
using System.ComponentModel;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        CommonVariablesClient client;

        private int _addIndex;
        public int AddIndex
        {
            get { return _addIndex; }
            set
            {
                _addIndex = value;
                OnPropertyChanged("AddIndex");
            }
        }

        private double _addValue;
        public double AddValue
        {
            get { return _addValue; }
            set
            {
                _addValue = value;
                OnPropertyChanged("AddValue");
            }
        }

        private string _addResult;
        public string AddResult
        {
            get { return _addResult; }
            set
            {
                _addResult = value;
                OnPropertyChanged("AddResult");
            }
        }

        private string _log;
        public string Log
        {
            get { return _log; }
            set
            {
                _log = value;
                OnPropertyChanged("Log");
            }
        }

        private int _cvCount;
        public int CVCount
        {
            get { return _cvCount; }
            set
            {
                _cvCount = value;
                OnPropertyChanged("CVCount");
            }
        }

        private int _valueIndex;
        public int ValueIndex
        {
            get { return _valueIndex; }
            set
            {
                _valueIndex = value;
                OnPropertyChanged("ValueIndex");
            }
        }

        private double _valueResult;
        public double ValueResult
        {
            get { return _valueResult; }
            set
            {
                _valueResult = value;
                OnPropertyChanged("ValueResult");
            }
        }

        private int _setIndex;
        public int SetIndex
        {
            get { return _setIndex; }
            set
            {
                _setIndex = value;
                OnPropertyChanged("SetIndex");
            }
        }

        private double _setVarValue;
        public double SetVarValue
        {
            get { return _setVarValue; }
            set
            {
                _setVarValue = value;
                OnPropertyChanged("SetVarValue");
            }
        }

        private string _setResult;
        public string SetResult
        {
            get { return _setResult; }
            set
            {
                _setResult = value;
                OnPropertyChanged("SetResult");
            }
        }

        public System.Collections.ObjectModel.ObservableCollection<CV_Value> CVCollection { get; set; } 
            = new System.Collections.ObjectModel.ObservableCollection<CV_Value>();

        private int _fromIndex;
        public int FromIndex
        {
            get { return _fromIndex; }
            set
            {
                _fromIndex = value;
                OnPropertyChanged("FromIndex");
            }
        }

        private int _toIndex;
        public int ToIndex
        {
            get { return _toIndex; }
            set
            {
                _toIndex = value;
                OnPropertyChanged("ToIndex");
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;

            // Create the client
            client = new CommonVariablesClient();

            MessageBox.Show(
                "YOU SHOULD NEVER USE THIS EXAMPLE CODE IN A PRODUCTION ENVIRONMENT! " +
                Environment.NewLine + Environment.NewLine +
                "Modifying variables on a machine which is in production HAS RESULTED IN MACHINE " +
                "CRASHES AND PROPERTY DAMAGE, AND COULD RESULT IN PERSONAL INJURY OR EVEN DEATH! " + 
                Environment.NewLine + Environment.NewLine +
                "This example does not include any transport security, message security, authentication, " +
                "or authorization of clients. It is configured to operate only on the local machine. " +
                Environment.NewLine + Environment.NewLine +
                "IF you decide to MODIFY this example to operate over a network connection, compile and " + 
                "deploy any part of this code in a production environment, YOU ACCEPT ALL RESPONSIBILTY " + 
                "for the outcome, however detrimental, and AGREE that OKUMA CANNOT BE HELD LIABLE " + 
                "for your poor judgment and failure to heed this warning. " +
                Environment.NewLine,
                "!!!WARNING!!!", 
                MessageBoxButton.OK, 
                MessageBoxImage.Warning
                );
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddResult = client.AddCommonVariable(AddIndex, AddValue).ToString();
            }
            catch (Exception ex)
            {
                Log = Log += ex.Message + Environment.NewLine;
                if (ex.InnerException != null)
                {
                    Log = Log += "Inner Exception: " + ex.InnerException + Environment.NewLine;
                }
            }
        }

        private void CountButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CVCount = client.GetCommonVariableCount();
            }
            catch (Exception ex)
            {
                Log = Log += ex.Message + Environment.NewLine;
                if (ex.InnerException != null)
                {
                    Log = Log += "Inner Exception: " + ex.InnerException + Environment.NewLine;
                }
            }
        }

        private void GetValueButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValueResult = client.GetCommonVariable(ValueIndex);
            }
            catch (Exception ex)
            {
                Log = Log += ex.Message + Environment.NewLine;
                if (ex.InnerException != null)
                {
                    Log = Log += "Inner Exception: " + ex.InnerException + Environment.NewLine;
                }
            }
        }

        private void SetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetResult = client.SetCommonVariable(SetIndex, SetVarValue).ToString();
            }
            catch (Exception ex)
            {
                Log = Log += ex.Message + Environment.NewLine;
                if (ex.InnerException != null)
                {
                    Log = Log += "Inner Exception: " + ex.InnerException + Environment.NewLine;
                }
            }
        }

        private void GetValuesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CVCollection.Clear();

                var doubleArray = client.GetCommonVariables(FromIndex, ToIndex);

                int i = 0;
                foreach (double d in doubleArray)
                {
                    CVCollection.Add(new CV_Value(FromIndex + i, d));
                    i++;
                }

            }
            catch (Exception ex)
            {
                Log = Log += ex.Message + Environment.NewLine;
                if (ex.InnerException != null)
                {
                    Log = Log += "Inner Exception: " + ex.InnerException + Environment.NewLine;
                }
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class CV_Value
    {
        public int Index { get; set; }
        public double Value { get; set; }

        public CV_Value(int cv, double val)
        {
            Index = cv;
            Value = val;
        }
    }
}
