


namespace Okuma.Scout.TestApp.net4.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Input;

    class GacViewModel : INotifyPropertyChanged
    {

        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        /// <summary> Used to query the GAC (useful when searching for "" where ALL files in GAC are returned...) </summary>
        private BackgroundWorker MyWorker = new BackgroundWorker();

        private Cursor _previousCursor;

        // Properties

        private string _assemblyName;
        public string AssemblyName
        {
            get { return _assemblyName; }
            set
            {
                _assemblyName = value;
                OnPropertyChanged("AssemblyName");
            }
        }

        private string _gacResults;
        public string GacResults
        {
            get { return _gacResults; }
            set
            {
                _gacResults = value;
                OnPropertyChanged("GacResults");
            }
        }

        // Commands

        private DelegateCommand<bool> _findAssembliesCommand;
        public DelegateCommand<bool> FindAssembliesCommand
        {
            get
            {
                if (_findAssembliesCommand == null)
                {
                    _findAssembliesCommand = new DelegateCommand<bool>(
                        (s) => { ExecuteGacTests(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _findAssembliesCommand;
            }
        }

        private DelegateCommand<bool> _clearCommand;
        public DelegateCommand<bool> ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                {
                    _clearCommand = new DelegateCommand<bool>(
                        (s) => { ExecuteClear(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _clearCommand; 
            }
        }

        // Constructor

        public GacViewModel()
        {
            AssemblyName = "System.Data"; 
            MyWorker.DoWork += MyWorker_DoWork;
            MyWorker.RunWorkerCompleted += MyWorker_RunWorkerCompleted;
        }

        // Methods

        private void MyWorker_DoWork(object Sender, System.ComponentModel.DoWorkEventArgs e)
        {
            List<System.Reflection.AssemblyName> AssemblyNames =
                Okuma.Scout.AccessGAC.QueryGAC(AssemblyName);

            if (AssemblyNames.Count > 0)
            {
                foreach (System.Reflection.AssemblyName a in AssemblyNames)
                {
                    if (a != null)
                    {
                        // Note: Culture seems to always be String.Empty
                        //       Flags seem to always be 'None'?
                        GacResults +=
                            a.FullName + "  " +
                            a.ProcessorArchitecture + "  " +
                            Environment.NewLine +
                            a.CodeBase +
                            Environment.NewLine + Environment.NewLine;
                    }
                }
            }
            else
            {
                GacResults += "Assembly Alias \"" + AssemblyName + "\" not found in GAC." + Environment.NewLine;
            }
            GacResults += "==================================================" + Environment.NewLine;        
        }

        private void MyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Mouse.OverrideCursor = _previousCursor;
        }

        private void ExecuteGacTests()
        {
            _previousCursor = Mouse.OverrideCursor;
            Mouse.OverrideCursor = Cursors.Wait;

            MyWorker.RunWorkerAsync();
        }

        private void ExecuteClear()
        {
            GacResults = string.Empty;
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
