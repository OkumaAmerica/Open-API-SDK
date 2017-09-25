
namespace TDG_Logging_Example
{
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult choice = System.Windows.Forms.MessageBox.Show(
                "Do you want to log a normal operation? " + Environment.NewLine +
                "Choose NO to generate an exception.",
                "Example Operation",
                System.Windows.Forms.MessageBoxButtons.YesNoCancel,
                System.Windows.Forms.MessageBoxIcon.Hand);

            if (choice == DialogResult.Yes)
            {
                Log.WriteEvent(this, "button1_Click()", tdg.logging.Enumerations.EventTypesEnum.INFO, "User chose \"Yes\".");

            }
            else if (choice == DialogResult.No)
            {
                MyMethod();
            }
            else if (choice == DialogResult.Cancel)
            {
                Log.WriteEvent(this, "button1_Click()", tdg.logging.Enumerations.EventTypesEnum.INFO, "User chose \"Cancel.\".");
            }

        }

        private int MyMethod()
        {
            try
            {
                Random r = new Random();
                r.Next();

                // Create a new random number between 1 and 6.
                int rint = r.Next(1, 6);

                switch (rint)
                {
                    case 1:
                        {
                            // DivideByZeroException
                            int x = 0;
                            return 1 / x;
                        }
                    case 2:
                        {
                            // OverflowException
                            return Convert.ToInt32(double.NegativeInfinity);
                        }
                    case 3:
                        {
                            // NullReferenceException
                            string s = null;
                            s.ToUpper();
                            return 1;
                        }
                    case 4:
                        {
                            // InvalidCastException
                            object o = new object();
                            return Convert.ToInt32(o);
                        }
                    default:
                        {
                            Exception e = new Exception("Custom Exception Happened.");
                            throw e;
                        }
                }
            }
            catch (Exception ex)
            {
                Log.WriteEvent(this, "MyMethod()", ex);
                return -1;
            }
        }

    }
}
