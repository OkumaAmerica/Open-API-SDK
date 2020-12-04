using System;
using System.Windows;
using System.Windows.Controls;

namespace EasyToolData_TestApp.Views
{
    /// <summary>
    /// Interaction logic for THINC_Tools_View5.xaml
    /// </summary>
    public partial class ToolOffsets_View : UserControl
    {
        public ToolOffsets_View()
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
