using CS_WPF.OkumaInterface;
using System;
using System.Linq;
using System.Windows;

namespace CS_WPF
{
    using Okuma.Scout;
    using System.Reflection;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly IOkuma _okumaAPI;

        public MainWindow()
        {
            InitializeComponent();

            
            try
            {
                _okumaAPI = API_Factory.GetOkumaAPI();
                txtMachinePlatform.Text = $"Machine Type is {Platform.BaseMachineType}";

                txtMachineMode.Text = $"Machine Mode is  {_okumaAPI.GetOperationMode()}";

                doneInit();
            } catch(Exception ex)
            {
                DoError(new Exception("Initializing API", ex));
            }
        }

        void btn_ReadCV_Click(object sender, RoutedEventArgs e)
        {
            // Do not try to get common variable 0.
            // Doing so will cause a 'not supported' exception 
            // because there is no common variable 0.
            int i = combo_CVN.SelectedIndex;
            double value = 1;

            try
            {
                //Read the value of common variable 'i' using our IOkuma interface
                value = _okumaAPI.ReadVariable(i);
            } catch(Exception ex)
            {
                DoError(new Exception($"Error Reading Common Variable {i}.", ex));
            }

            txtBlockReadResult.Text = value.ToString();
        }

        void btn_WriteCV_Click(object sender, RoutedEventArgs e)
        {
            bool validate = validateInput(txtBox_WriteVal.Text);

            if(validate)
            {
                int i = combo_CVN.SelectedIndex;
                int value = Convert.ToInt32(txtBox_WriteVal.Text);

                try
                {
                    //Set the value of common variable 'i' to 'value' using our IOkuma interface
                    _okumaAPI.WriteVariable(i, value);
                } catch(Exception ex)
                {
                    DoError(new Exception($"Error Reading Common Variable {i}.", ex));
                }
            } else
            {
                MessageBox.Show("Input Error! " + Environment.NewLine + "Blank or non-numerical input detected.");
            }
        }

        /// <summary>
        /// Uniformly handles display of errors to user.
        /// </summary>
        /// <param name="EXCEPTION"></param>
        /// <remarks>
        /// While not shown here, normally one would include logging in a central error handling function like this.
        /// </remarks>
        void DoError(Exception ex) => MessageBox.Show("Error:  \n" + ex.Message + "\n" + ex.StackTrace,
                                                      Assembly.GetExecutingAssembly().FullName);


        void doneInit()
        {
            combo_CVN.IsEnabled = true;
            btn_ReadCV.IsEnabled = true;
            btn_WriteCV.IsEnabled = true;
        }

        void MainWindow_UnLoad(object sender, RoutedEventArgs e) => _okumaAPI.Dispose();

        bool validateInput(string s)
        {
            if(s == string.Empty)
            {
                return false;
            } else
            {
                foreach(char c in s)
                {
                    if(c < '0' || c > '9')
                        return false;
                }
                return true;
            }
        }
    }
}
