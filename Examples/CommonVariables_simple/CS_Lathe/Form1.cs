using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Okuma.CLDATAPI.DataAPI;

// Okuma Common Variable Editor Example for lathe
namespace CS_Lathe
{
    /// <summary>
    /// if possible, applications targeting Okuma OSP platform should:
    ///   - Target .NET 2.0 [this is for backward compatibility and download size]
    ///     - if >.NET 2.0 is required you must use .NET 4.0
    ///   - Compile using the lowest API version possible out of ['1.9.1', '1.12.1', '1.17.1']
    /// </summary>
    public partial class Form1 : Form
    {
        // CMachine must be declared on main thread of each application (see initialization in 'Form1_Load')
        CVariables myCVariables;
        public Form1()
        {
            InitializeComponent();
            try
            {
                // 'Init()' must be called exactly once on the main
                //   thread from an instance of CMachine before any
                //   API operations can take place.
                // Note that the instance of CMachine need not remain
                //   after 'Init()' is called as that part of CMachine
                //   is actually static.
                (new CMachine()).Init();

                // An instance of CVariables can be instantiated once
                //   to save overhead or multiple times if you need
                //   several versions of it.
                myCVariables = new CVariables();
            }
            catch (Exception ex)
            {
                DoError(new Exception("Error initializing API: If API is installed, there should be a round" +
                    " green icon in the task-bar that tells API version when clicked. If version is less than" +
                    " 1.9.1, contact your distributor to request a free API upgrade.", ex));
                Application.Exit();
            }
            btnExit.Click += (object sender, EventArgs e) => { Application.Exit(); };
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
                System.Reflection.Assembly.GetExecutingAssembly().FullName,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Reads from common variables into text boxes and resets color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                tbNo1.Text = myCVariables.GetCommonVariableValue(1).ToString();
                tbNo2.Text = myCVariables.GetCommonVariableValue(2).ToString();
                tbNo1.BackColor = System.Drawing.SystemColors.Window;
                tbNo2.BackColor = System.Drawing.SystemColors.Window;
            }
            catch (Exception ex)
            {
                DoError(ex);
            }
        }

        /// <summary>
        /// Attempts to
        ///  - convert text box value to an integer
        ///  - write that value to common variable
        ///  - set text box color to green
        /// If any part fails
        ///  - sets text box color to red
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWrite_Click(object sender, EventArgs e)
        {
            TextBox[] tb = new TextBox[] { tbNo1, tbNo2 };
            for (int i = 0; i < tb.Length; i++)
                try
                {
                    myCVariables.SetCommonVariableValue(i+1, int.Parse(tb[i].Text));
                    tb[i].BackColor = Color.Green;
                }
                catch (Exception)
                {
                    tb[i].BackColor = Color.Red;
                    tb[i].Focus();
                    tb[i].SelectAll();
                }
        }
    }
}