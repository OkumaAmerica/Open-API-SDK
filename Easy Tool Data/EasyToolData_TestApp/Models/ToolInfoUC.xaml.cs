
namespace EasyToolData_TestApp.Models
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;


    /// <summary>
    /// Interaction logic for ToolInfoUC.xaml
    /// </summary>
    public partial class ToolInfoUC : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> OecXmlInfo
        {
            get { return (ObservableCollection<string>)GetValue(OecXmlInfoProperty); }
            set { SetValue(OecXmlInfoProperty, value); }
        }

        public static readonly DependencyProperty OecXmlInfoProperty =
            DependencyProperty.Register("OecXmlInfo", typeof(ObservableCollection<string>),
              typeof(ToolInfoUC), new PropertyMetadata(null));

        public object InfoLabel
        {
            get { return (object)GetValue(InfoLabelProperty); }
            set { SetValue(InfoLabelProperty, value); }
        }

        public static readonly DependencyProperty InfoLabelProperty =
            DependencyProperty.Register("InfoLabel", typeof(object),
              typeof(ToolInfoUC), new PropertyMetadata(null));

        public ToolInfoUC()
        {
            InitializeComponent();

            OecXmlInfo = new ObservableCollection<string>();
           
        }
        
        private void CtrlCCopyCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ListBox lb = (ListBox)(sender);
            var selected = lb.SelectedItem;
            if (selected != null) Clipboard.SetText(selected.ToString());
        }

        private void CtrlCCopyCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void RightClickCopyCmdExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            var selected = mi.DataContext;
            if (selected != null) Clipboard.SetText(selected.ToString());
        }

        private void RightClickCopyCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
