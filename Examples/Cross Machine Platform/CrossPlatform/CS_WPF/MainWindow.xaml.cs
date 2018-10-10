using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_ReadCV_Click(object sender, RoutedEventArgs e)
        {
            // Do not try to get common variable 0.
            // Doing so will cause a 'not supported' exception 
            // because there is no common variable 0.
            int i = combo_CVN.SelectedIndex;
            double value = 1;

            try
            {
                if (RadioBtnMC.IsChecked == true)
                {
                    value = objMVariables.GetCommonVariableValue(i);
                }
                else if (RadioBtnLathe.IsChecked == true)
                {
                    value = objLVariables.GetCommonVariableValue(i);
                }
            }
            catch (Exception ex)
            {
                DoError(new Exception(String.Format("Error Reading Common Variable {0}.", i), ex));
            }

            txtBlockReadResult.Text = value.ToString();
        }

        private void btn_WriteCV_Click(object sender, RoutedEventArgs e)
        {
            bool validate = validateInput(txtBox_WriteVal.Text);

            if (validate)
            {
                int i = combo_CVN.SelectedIndex;
                int value = Convert.ToInt32(txtBox_WriteVal.Text);

                try
                {
                    if (RadioBtnMC.IsChecked == true)
                    {
                        objMVariables.SetCommonVariableValue(i, value);
                    }
                    else if (RadioBtnLathe.IsChecked == true)
                    {
                        objLVariables.SetCommonVariableValue(i, value);
                    }
                }
                catch (Exception ex)
                {
                    DoError(new Exception(String.Format("Error Reading Common Variable {0}.", i), ex));
                }
            }
            else { MessageBox.Show("Input Error! " + Environment.NewLine + "Blank or non-numerical input detected."); }
        }

        /// <summary>
        /// Uniformly handles display of errors to user.
        /// </summary>
        /// <param name="EXCEPTION"></param>
        /// <remarks>
        /// While not shown here, normally one would include logging in a central error handling function like this.
        /// </remarks>
        void DoError(Exception ex)
        {
            MessageBox.Show(
                "Error:  \n" + ex.Message + "\n" + ex.StackTrace,
                System.Reflection.Assembly.GetExecutingAssembly().FullName);
        }

        private bool validateInput(string s)
        {
            if (s == "") { return false; }
            else
            {
                foreach (char c in s)
                { if (c < '0' || c > '9') return false; }
                return true;
            }
        }


        private void doneInit()
        {
            combo_CVN.IsEnabled = true;
            btn_ReadCV.IsEnabled = true;
            btn_WriteCV.IsEnabled = true;

            RadioBtnLathe.IsEnabled = false;
            RadioBtnMC.IsEnabled = false;
            btnInit.IsEnabled = false;
        }
    }
}
