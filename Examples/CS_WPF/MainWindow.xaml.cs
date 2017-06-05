
/* ***************************************************************************\
 *                                                                            *
 *                            IMPORTANT NOTE                                  * 
 *                                                                            *
 *   Any application using the THINC API created with .NET 4 and up           *
 *   REQUIRES an App.Config file with the following lines:                    *
 *                                                                            *
 *    <startup useLegacyV2RuntimeActivationPolicy="true">                     *
 *    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.0" />    *
 *    </startup>                                                              *
 *                                                                            *
 *  This is due to application dependencies (the THINC API) being built       *
 *  with .NET Framework 1.1 which requires the legacy V2 Runtime.             *
 *  This situation will persist until THINC API version 1.20, when            *
 *  a move to .NET 4.0 is planned to be fully implemented.                    *
 *                                                                            *
 \*****************************************************************************/

namespace CS_WPF
{
    using System;
    using System.Windows;

    /// <summary> Interaction logic for MainWindow.xaml </summary>
    public partial class MainWindow : Window
    {
        Okuma.CMDATAPI.DataAPI.CMachine objMMachine;
        Okuma.CMDATAPI.DataAPI.CVariables objMVariables;

        Okuma.CLDATAPI.DataAPI.CMachine objLMachine;
        Okuma.CLDATAPI.DataAPI.CVariables objLVariables;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInit_Click(object sender, RoutedEventArgs e)
        {
            if (RadioBtnMC.IsChecked == true)
            {
                try
                {
                    // Create an instance of CMachine class
                    objMMachine = new Okuma.CMDATAPI.DataAPI.CMachine();

                    // 'Init()' must be called exactly once on the main
                    //   thread from an instance of CMachine before any
                    //   API operations can take place.
                    // Note that the instance of CMachine need not remain
                    //   after 'Init()' is called as that part of CMachine
                    //   is actually static.
                    objMMachine.Init();

                    // Create an instance of CVariables class
                    objMVariables = new Okuma.CMDATAPI.DataAPI.CVariables();

                    doneInit();
                }
                catch (Exception ex)
                {
                    DoError(new Exception("Error initializing API: If API is installed, there should be a round" +
                     " green icon in the task-bar that tells API version when clicked. If version is less than" +
                     " 1.9.1, contact your distributor to request a free API upgrade.", ex));
                    //Environment.Exit(0);
                }
            }

            else if (RadioBtnLathe.IsChecked == true)
            {
                try
                {
                    // Create an instance of CMachine class
                    objLMachine = new Okuma.CLDATAPI.DataAPI.CMachine();

                    // Call the Init method of CMachine class to initialize the  
                    // library once for the entire application.
                    objLMachine.Init();

                    // Create an instance of CVariables class
                    objLVariables = new Okuma.CLDATAPI.DataAPI.CVariables();

                    doneInit();
                }
                catch (Exception ex)
                {
                    DoError(new Exception("Error initializing API: If API is installed, there should be a round" +
                     " green icon in the task-bar that tells API version when clicked. If version is less than" +
                     " 1.9.1, contact your distributor to request a free API upgrade.", ex));
                    //Environment.Exit(0);
                }
            }
        }

        private void MainWindow_UnLoad(object sender, RoutedEventArgs e)
        {
            if (btn_ReadCV.IsEnabled == true)
            {
                // When your application exits (finalize, onClose(), etc) you must
                // release the connections to the THINC API using the following code:
                objMMachine.Close();
            }
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
            catch(Exception ex)
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
