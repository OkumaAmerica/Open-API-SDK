namespace EasyToolData_TestApp.Views
{
    using System.Windows;
    using System.Windows.Controls;


    /// <summary>
    /// Interaction logic for THINC_OptionalParameters_View.xaml
    /// </summary>
    public partial class OptionalParameters_View : UserControl
    {
        public OptionalParameters_View()
        {
            InitializeComponent();
        }

        private void ShowLegend(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "Global Constants",
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                Content = new Views.Globals_View(),
                Owner = Application.Current.MainWindow
            };

            window.ShowDialog();
        }
    }
}
