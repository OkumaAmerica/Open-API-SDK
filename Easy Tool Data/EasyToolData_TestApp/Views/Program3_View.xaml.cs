using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyToolData_TestApp.Views
{
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for Program3_View.xaml
    /// </summary>
    public partial class Program3_View : UserControl
    {
        public Program3_View()
        {
            InitializeComponent();

            ListBox_ContainsPrograms.SelectionChanged += ListBox_ContainsPrograms_SelectionChanged;
        }

        private void ListBox_ContainsPrograms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox_ContainsPrograms.SelectedItem != null)
            {
                ListBox_ContainsPrograms.Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    new Action(() =>
                    {
                        ListBox_ContainsPrograms.UpdateLayout();
                        ListBox_ContainsPrograms.ScrollIntoView(ListBox_ContainsPrograms.SelectedItem);
                    }));
            }


        }
    }
}
