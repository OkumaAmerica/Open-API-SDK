
namespace Okuma.Scout.TestApp.net4.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Threading;


    class OS2ViewModel : INotifyPropertyChanged
    {

        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        // Properties

        private string _caption;
        public string Caption
        {
            get { return _caption; }
            set
            {
                _caption = value;
                OnPropertyChanged("Caption");
            }
        }

        private string wmi_Win32OS_Class;

        public string WMI_Win32OS_Class
        {
            get { return wmi_Win32OS_Class; }
            set
            {
                wmi_Win32OS_Class = value;
                OnPropertyChanged("WMI_Win32OS_Class");
            }
        }
            
       



        // Commands

        private DelegateCommand<bool> _executeCommand;
        public DelegateCommand<bool> ExecuteCommand
        {
            get
            {
                if (_executeCommand == null)
                {
                    _executeCommand = new DelegateCommand<bool>(
                        (s) => { ExecuteOSTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Methods

        private void ExecuteOSTests()
        {
            // The process of gathering Operating System information can be slow.
            // To prevent locking up the User Interface, the retrieval
            // of this information is performed using a thread.
            Thread getOSInfo = new Thread(new ThreadStart(this.OSInfo));
            getOSInfo.Name = "GetApiFileInfoThread";
            getOSInfo.Priority = ThreadPriority.Normal;
            getOSInfo.Start();

            // Note that it is NECESSARY to subscribe to Okuma.Scout.Error.ReporterEvent 
            // inside the thread in order to capture any of those events.
            // Be sure to use a thread safe handler.

        }


        /// <summary>
        /// Using Scout, acquire information about the Operating System via WMI (System.Management)
        /// </summary>
        private void OSInfo()
        {
            string temp_ClassPropertiesAndValues = string.Empty;

            // Access individual properties
            Caption = Okuma.Scout.OS.WMI_Win32OS.Caption;

            // Or grab the entire class of properties
            Okuma.Scout.OS.WMI_OperatingSystem WMI_OSinfo = Okuma.Scout.OS.WMI_Win32OS;

            // Get values for all properties
            foreach (System.Reflection.PropertyInfo prop in typeof(Okuma.Scout.OS.WMI_OperatingSystem).GetProperties())
            {
                // Retrieve a property value
                var PropertyValueObject = prop.GetValue(WMI_OSinfo, null);

                // Don't display properties whose values are null or empty.
                if (PropertyValueObject != null)
                {
                    string PropertyValue = PropertyValueObject.ToString();

                    if (PropertyValue != string.Empty)
                    {
                        temp_ClassPropertiesAndValues +=
                            String.Format("{0} = {1}", prop.Name, PropertyValue) + Environment.NewLine;
                    }
                }
            }

            // Display the property names and values
            WMI_Win32OS_Class = temp_ClassPropertiesAndValues;
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