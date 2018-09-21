//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Okuma America Corporation" >
//    Copyright© 2019 Okuma America Corporation
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

namespace Single_Instance_CS_WPF
{
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
        }

        private string instructions =
            "Directions to Create a Single Instance C# WPF Application:" +
                Environment.NewLine +
                "    1:  Create a new WPF project." +
                Environment.NewLine +
                "    2:  Add a project reference to System.Runtime.Remoting." +
                Environment.NewLine +
                "    3:  Add SingleInstance.cs to your project." +
                Environment.NewLine +
                "    4:  Open App.xaml Properties and change the Build Action from 'ApplicationDefinition' to 'Page'." +
                Environment.NewLine +
                "    5:  Copy and paste the contents of App.xaml.cs to your project (right-click on App.xaml, View Code)" +
                Environment.NewLine +
                "    6:  Ensure your application's namespace is correct in App.xaml.cs" +
                Environment.NewLine +
                "    7:  Add your own unique GUID to \"Make a GUID and put it here\" in App.xaml.cs" +
                Environment.NewLine +
                "    8:  Open the Project Properties window and change the Startup object to YourApp.App" +
                Environment.NewLine +
                "    9:  Build the project." +
                Environment.NewLine +
                "   10:  Run the application and attempt to open a second copy to verify it works.";

        public string Instructions
        {
            get { return instructions; }
            set { instructions = value; }
        }
    }
}
