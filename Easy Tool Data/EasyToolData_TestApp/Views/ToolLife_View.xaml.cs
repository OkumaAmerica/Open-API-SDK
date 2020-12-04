using System.Windows;
using System.Windows.Controls;


namespace EasyToolData_TestApp.Views
{
    public partial class ToolLife_View : UserControl
    {
        public ToolLife_View()
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
