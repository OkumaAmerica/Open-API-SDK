using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;


namespace EasyToolData_TestApp
{
    using System;
    //using Microsoft.Shell;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// NOTE: Build Action for App.xaml is set to "Page".
        ///       If duplicating this, you must change if from "ApplicationDefinition" to "Page".
        ///       Otherwise the compiler will attempt to create the Main() method in obj\App.g.i.cs
        /// </summary>
        [STAThread]
        public static void Main()
        {

            System.Threading.Thread.CurrentThread.Name = Global.MainGuiThreadName;

            try
            {
                var application = new App();
                application.InitializeComponent();
                application.Run();
            }
            catch (Exception ex)
            {
                Log.SendEx(ex, "App.xaml.cs", "Main()");
            }

            // Note: Will not handle Stack Overflow exceptions. 
            //       There's no way to handle those. 
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                //Console.Error.WriteLine("Unhandled exception: " + args.ExceptionObject);
                //Log.WriteEvent((object)"EasyToolData_TestApp.App", "Global Unhandled Exception", (Exception)args.ExceptionObject);

                Exception ex = (Exception)args.ExceptionObject;
                MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);

            };

        }
    }
}
