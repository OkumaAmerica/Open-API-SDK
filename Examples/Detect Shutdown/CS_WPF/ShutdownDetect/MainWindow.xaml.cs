using System.Windows;

namespace ShutdownDetect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Application.Current.SessionEnding += Current_SessionEnding;
        }

        private void Current_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            // TO DO:   Stop any threads in the application.
            //          Discontinue calling any THINC API function
            //          Unload the THINC API 'Okuma.CLDATAPI.DataAPI.CMachine.Close()'

            // If you want to know why the session is ending, that information is available.
            if (e.ReasonSessionEnding == ReasonSessionEnding.Logoff) { }
            else if (e.ReasonSessionEnding == ReasonSessionEnding.Shutdown) { }

            // You should see the window flash green before the system shuts down. (This is just to show that this sample works)
            MyWindow.Background = System.Windows.Media.Brushes.Green;

            // Only set this flag if you REALLY want to prevent the machine from shutting down (NOT RECCOMENDED)
            //e.Cancel = true;

            // 
            e.Cancel = false;
        }
    }
}
