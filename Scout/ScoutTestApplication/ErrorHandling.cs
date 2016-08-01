//-----------------------------------------------------------------------
// <copyright file="ErrorHandling.cs" company="Okuma America Corporation">
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
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// This is just an extension of Form1 broken into a separate file for
    /// organization and clarity </summary>
    public partial class ScoutTestApplicationForm : Form
    {

        static bool uiLoaded = false;

        /// <summary>
        /// Some Scout functions in this test application are executed using threading.
        /// Because of this, cross-threading issues may arise when attempting to
        /// perform operations on the main GUI thread. To prevent this, use the 
        /// Invoke method. Refer to the <see cref="Button_DMC_Click"/> method.</summary>
        /// <param name="lvl">level of error severity <c>Okuma.Scout.Enums.MessageLevel</c></param>
        /// <param name="text">If level is other than "Exception", this contains the message to be displayed.</param>
        internal void PostError(Okuma.Scout.Enums.MessageLevel lvl, string text)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.TextBox_ErrorHandling.Text = this.TextBox_ErrorHandling.Text +
                lvl.ToString() + ":  " + text + Environment.NewLine;
            });
        }

        /// <summary>
        /// This event is fired when the test application is finished loading.
        /// By default, the application will subscribe to the Error Reporting event
        /// and show all messages. </summary>
        /// <param name="sender">The object which triggered this method</param>
        /// <param name="e">Event arguments associated with the sender</param>
        private void ScoutTestApplication_Loaded(object sender, EventArgs e)
        {
            // Refer to the events below for more details.

            // Subscribe to the error handler by default
            Okuma.Scout.Error.Reporter += this.HandleScoutErrorInfo;
            this.CheckBox_ErrorSubscribed.Checked = true;

            // Show debugging information by default
            Okuma.Scout.Error.ShowDebugInfo = true;
            this.CheckBox_ShowDebugInfo.CheckState = CheckState.Checked;

            SetInitialComboBoxConditions();

            uiLoaded = true;
        }


        /// <summary>
        /// When handling the Reporter event, make sure to distinguish between 
        /// exceptions and information. In the case of an exception, e.Message
        /// will be String.Empty, while in all other cases it will contain the
        /// error information and e.Exception will be null. </summary>
        /// <param name="sender">This value will always be null because the source is a 
        /// static library.</param>
        /// <param name="e">Type 'Okuma.Scout.Error.Args', this value will
        /// contain exception and message information.</param>
        private void HandleScoutErrorInfo(object sender, Okuma.Scout.Error.Args e)
        {
            if (e.Severity == Okuma.Scout.Enums.MessageLevel.Exception)
            {
                this.PostError(e.Severity, e.Exception.ToString());

                if (e.Exception.InnerException != null)
                {
                    this.PostError(e.Severity, e.Exception.InnerException.ToString());
                }

                // At this point Scout.dll has generated an exception and you have
                // the option of handling it gracefully, or throwing it.
                // to throw the exception uncomment the line below.
                // throw e.Exception;
            }
            else
            {
                // This is not an exception, thus e.Exception will be null
                // and all of the relevant debugging information will be held
                // in e.Message
                this.PostError(e.Severity, e.Message.ToString());
            }
        }

        /// <summary>
        /// Subscribe to the error reporting event of Scout </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_ErrorSubscribe_Click(object sender, EventArgs e)
        {
            // Subscribe to this event to view diagnostic information from Scout.dll 
            // and handle any exceptions generated by the library.
            // If this event is not subscribed to, SCOUT may generate unhandled 
            // exceptions. Additionally, minor errors / diagnostic information will 
            // be invisible / hidden from the user.
            Okuma.Scout.Error.Reporter += this.HandleScoutErrorInfo;

            // display the status of subscription status
            this.CheckBox_ErrorSubscribed.Checked = true;

            // Subscribing multiple times would result in duplicate lines.
            this.Button_ErrorSubscribe.Enabled = false;
        }

        /// <summary>
        /// Unsubscribe from the error reporting event of Scout </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_ErrorUnSubscribe_Click(object sender, EventArgs e)
        {
            // Remember to unsubscribe from this event when Scout functionality
            // is no longer required. As long as the Reporter Event is 
            // subscribed to, Scout.dll will be held in memory and not 
            // garbage collected by the CLR; even if the class which uses
            // Scout functionality loses scope.
            Okuma.Scout.Error.Reporter -= this.HandleScoutErrorInfo;

            // Display the status of subscription status.
            this.CheckBox_ErrorSubscribed.Checked = false;

            // Allow user to subscribe to the event again.
            this.Button_ErrorSubscribe.Enabled = true;
        }

        /// <summary>
        /// Choose if you would like to handle exceptions only or all messages 
        /// </summary>
        /// <param name="sender">The check box object</param>
        /// <param name="e">Event arguments associated with the change event</param>
        private void CheckBox_ShowDebugInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.CheckBox_ShowDebugInfo.CheckState == CheckState.Checked)
            {
                Okuma.Scout.Error.ShowDebugInfo = true;
            }
            else 
            { 
                Okuma.Scout.Error.ShowDebugInfo = false; 
            }
        }

        /// <summary>
        /// Generate a test message of level 'Information' </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_ErrorInfo_Click(object sender, EventArgs e)
        {
            Okuma.Scout.Error.TestReporter(Okuma.Scout.Enums.MessageLevel.Information);
        }

        /// <summary>
        /// Generate a test message of level 'Warning' </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_ErrorWarning_Click(object sender, EventArgs e)
        {
            Okuma.Scout.Error.TestReporter(Okuma.Scout.Enums.MessageLevel.Warning);
        }

        /// <summary>
        /// Generate a test message of level 'Error' </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_ErrorError_Click(object sender, EventArgs e)
        {
            Okuma.Scout.Error.TestReporter(Okuma.Scout.Enums.MessageLevel.Error);
        }

        /// <summary>
        /// Generate a test exception </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_ErrorException_Click(object sender, EventArgs e)
        {
            Okuma.Scout.Error.TestReporter(Okuma.Scout.Enums.MessageLevel.Exception);
        }
    }
}
