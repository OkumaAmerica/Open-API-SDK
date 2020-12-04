using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EasyToolData_TestApp.Views
{

    /// <summary>
    /// Interaction logic for Globals_View.xaml
    /// </summary>
    public partial class Globals_View : UserControl
    {
        public Globals_View()
        {
            InitializeComponent();

            AddItem(Okuma.EasyToolData.Global.EMPTY, nameof(Okuma.EasyToolData.Global.EMPTY)); // 0
            AddItem(Okuma.EasyToolData.Global.DUMMY, nameof(Okuma.EasyToolData.Global.DUMMY)); // -1
            AddItem(Okuma.EasyToolData.Global.RESERVED, nameof(Okuma.EasyToolData.Global.RESERVED)); // -2
            AddItem(Okuma.EasyToolData.Global.NOT_APPLICABLE, nameof(Okuma.EasyToolData.Global.NOT_APPLICABLE)); // -3
            AddItem(Okuma.EasyToolData.Global.UNKNOWN, nameof(Okuma.EasyToolData.Global.UNKNOWN)); // -4
            AddItem(Okuma.EasyToolData.Global.THINC_API_NOT_INIT, nameof(Okuma.EasyToolData.Global.THINC_API_NOT_INIT)); // -5
            AddItem(Okuma.EasyToolData.Global.DEFAULT_INITIAL_VALUE, nameof(Okuma.EasyToolData.Global.DEFAULT_INITIAL_VALUE)); // -8
            AddItem(Okuma.EasyToolData.Global.NOT_SUPPORTED, nameof(Okuma.EasyToolData.Global.NOT_SUPPORTED)); // -10
            AddItem(Okuma.EasyToolData.Global.ERROR_CODE, nameof(Okuma.EasyToolData.Global.ERROR_CODE)); // -88
            AddItem(Okuma.EasyToolData.Global.EXCEPTION_CODE, nameof(Okuma.EasyToolData.Global.EXCEPTION_CODE)); // -99
            AddItem(Okuma.EasyToolData.Global.EXCEPTION_RESULT, nameof(Okuma.EasyToolData.Global.EXCEPTION_RESULT)); 
            AddItem(Okuma.EasyToolData.Global.NO_RESULT, nameof(Okuma.EasyToolData.Global.NO_RESULT)); // 

            //AddItem(Okuma.EasyToolData.Global, nameof(Okuma.EasyToolData.Global)); // 

        }

        SolidColorBrush W = new SolidColorBrush(Colors.White);

        internal void AddItem(object Value, string Name)
        {
            TextBlock LeftValue = new TextBlock { Text = Value.ToString(), Foreground = W, TextAlignment = TextAlignment.Right };
            LeftPanel.Children.Add(LeftValue);

            TextBlock RightName = new TextBlock { Text = Name, Foreground = W };
            RightPanel.Children.Add(RightName);
        }

    }


}
