//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="Okuma America Corporation" >
//    Copyright© 2018 Okuma America Corporation
// </copyright>
// <project> Single Instance WPF </project>
// <author> Scott Solmer</author>
// <remarks> This sample code is unlicensed.It is distributed "AS IS", 
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either expressed or implied. 
//    Okuma America grants you permission to use this code and derivative works 
//    thereof without limitation or obligation. 
// </remarks>
// <disclaimer> Under no circumstance shall Okuma America be held liable to 
//    anyone using this code or programs derived there from for damages of any 
//    kind as a result of the use or inability to use this code, including but 
//    not limited to damages for loss of goodwill, work stoppage, computer 
//    failure or malfunction, or any and all other commercial damages or losses. 
// </disclaimer> 
//-----------------------------------------------------------------------

namespace Single_Instance_WPF
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using Microsoft.Shell;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, ISingleInstanceApp
    {
        private const string UniqueStringForSingleInstanceApp = "Make a GUID and put it here";

        [STAThread]
        public static void Main()
        {
            // If this is the first instance...
            if (SingleInstance<App>.InitializeAsFirstInstance(UniqueStringForSingleInstanceApp))
            {
                try
                {
                    var application = new App();
                    application.InitializeComponent();
                    application.Run();
                }
                catch (Exception ex)
                {
                    // Global application exception logging can be handled here.

                    //Log.WriteEvent(
                    //    ex,
                    //    Message: "Unhandled Exception Caught at App level.",
                    //    Sender: "App.Xaml.cs",
                    //    Method: "Main()");

                    string innerException = "";
                    string stackTrace = "";
                    if (ex.InnerException != null) { innerException = ex.InnerException.ToString(); }
                    if (ex.StackTrace != null) { stackTrace = ex.StackTrace; }
                    MessageBox.Show(ex.Message + Environment.NewLine + innerException + Environment.NewLine + stackTrace);
                }

                // Allow single instance code to perform cleanup operations
                SingleInstance<App>.Cleanup();
            }
        }

        #region ISingleInstanceApp Members

        public bool SignalExternalCommandLineArgs(IList<string> args)
        {
            // Handle starting arguments here, if you want.
            if (Current.MainWindow != null)
            {
                Current.MainWindow.Activate();
            }
            return true;
        }

        #endregion
    }
}