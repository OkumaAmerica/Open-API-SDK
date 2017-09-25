
namespace Okuma.Scout.TestApp.net40.ViewModels
{
    using System.ComponentModel;


    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _mainViewTitle;
        public string MainViewTitle
        {
            get { return _mainViewTitle; }
            set
            {
                _mainViewTitle = value;
                OnPropertyChanged("MainViewTitle");
            }
        }

        public MainViewModel()
        {
            MainViewTitle = "Okuma.Scout Test Application v" + Okuma.Scout.ProgramInfo.ThisAssemblyVersion +
                "  (Okuma.Scout.dll v" + Okuma.Scout.ProgramInfo.ScoutDllAssemblyVersion + ")";
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
