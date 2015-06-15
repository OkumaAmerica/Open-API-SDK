//-----------------------------------------------------------------------
// <copyright file="ResultBox.cs" company="Okuma America Corporation">
//     Copyright© 2016 Okuma America Corporation
// </copyright>
// <project> SCOUT Test Application
// </project>
// <author> Scott Solmer
// </author>   
// <remarks> This sample code is unlicensed.
// It is distributed "AS IS", WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either expressed or implied. Okuma America grants you permission to use
// this code and derivative works thereof without limitation or obligation.
// </remarks>
// <disclaimer> Under no circumstance shall Okuma America be held liable 
// to anyone using this code or programs derived there from for damages 
// of any kind as a result of the use or inability to use this code, 
// including but not limited to damages for loss of goodwill, work 
// stoppage, computer failure or malfunction, or any and all other 
// commercial damages or losses.
// </disclaimer>
//-----------------------------------------------------------------------

namespace ScoutTestApplication
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// This class represents a user control that is an extension of 
    /// the standard TextBox with color changing text.
    /// </summary>
    public class ResultBox : TextBox
    {
        /// <summary>Color for good result </summary>
        private Color good = Color.LimeGreen;

        /// <summary>Color for not as good a result </summary>
        private Color notGood = Color.DimGray;

        /// <summary>Color for a bad result </summary>
        private Color bad = Color.Firebrick;

        /// <summary>Color for a seriously bad result </summary>
        private Color reallyBad = Color.DeepPink;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultBox"/> class.
        /// </summary>
        public ResultBox()
        {
            // this.Enabled = false;
            this.ReadOnly = true;
            this.TextAlign = HorizontalAlignment.Center;
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// This function hides the flashy line in the box when it is selected.
        /// </summary>
        public void HideCaret()
        {
            NativeMethods.HideCaret(this.Handle);
        }

        /// <summary>
        /// This method handles the ResultBox.OnTextChanged Event.
        /// It's main function is to change the text color depending on the contents.
        /// </summary>
        /// <param name="e">Text Changed Event Args</param>
        protected override void OnTextChanged(EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;

            Okuma.Scout.Enums.LicenseStatus thisStatus =
                (Okuma.Scout.Enums.LicenseStatus)Enum.Parse(typeof(Okuma.Scout.Enums.LicenseStatus), this.Text);

            switch (thisStatus)
            {
                case Okuma.Scout.Enums.LicenseStatus.Bad_Key:
                    {
                        this.ForeColor = this.bad;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Bad_Version:
                    {
                        this.ForeColor = this.bad;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Critical_Exception:
                    {
                        this.ForeColor = this.reallyBad;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Expired:
                    {
                        this.ForeColor = this.notGood;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Feature_Not_Found:
                    {
                        this.ForeColor = this.notGood;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Flexnet_Not_Found:
                    {
                        this.ForeColor = this.bad;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Insufficient_Version:
                    {
                        this.ForeColor = this.bad;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Invalid:
                    {
                        this.ForeColor = this.bad;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Invalid_Machine_Type:
                    {
                        this.ForeColor = this.notGood;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.License_Not_Found:
                    {
                        this.ForeColor = this.bad;
                        break;
                    }

                case Okuma.Scout.Enums.LicenseStatus.Valid:
                    {
                        this.ForeColor = this.good;
                        break;
                    }
            }

            base.OnTextChanged(e);
        }

        /// <summary>
        /// Handles the OnMouseUp event for the ResultBox.
        /// This method overrides the standard behavior and hides the text caret.
        /// </summary>
        /// <param name="mevent">Mouse Event Arguments</param>
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            this.HideCaret();
            base.OnMouseUp(mevent);
        }
     }
}