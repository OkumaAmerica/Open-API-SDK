
namespace EasyToolData_TestApp.ViewModels
{
    using System;
    using System.Windows;
    using System.Windows.Threading;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Okuma.EasyToolData.Enums;
    using System.Threading;



    class ToolObject_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        public event PropertyChangedEventHandler PropertyChanged;

        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.Tools EasyToolData_THINC_Tools;

        System.Diagnostics.Stopwatch GetToolTimer = new System.Diagnostics.Stopwatch();


        // Properties

        public ObservableCollection<Models.TreeViewNode> TreeViewNodeCollection { get; set; }

        private string _timeToGetTool;
        public string TimeToGetTool
        {
            get { return _timeToGetTool; }
            set
            {
                _timeToGetTool = value;
                OnPropertyChanged("TimeToGetTool");
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
                        (s) => { Execute_GetToolObjects(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        // Constructor
        public ToolObject_ViewModel()
        {
            EasyToolData_THINC_Tools = new Okuma.EasyToolData.THINC.Tools();

            GetToolTimer = new System.Diagnostics.Stopwatch();

            TreeViewNodeCollection = new ObservableCollection<Models.TreeViewNode>();
        }


        // Methods

        private void Execute_GetToolObjects()
        {
            TreeViewNodeCollection.Clear();
            GetToolTimer.Reset();

            Thread thread = new Thread(new ThreadStart(GetToolObject)) { Name = "GetToolObjects_Thread" };
            thread.Start();
        }


        private void GetToolObject()
        {
            long averageElapsed = 0;
            int howManyToolObjectsGot = 1;

            List<long> toolNumbers = EasyToolData_THINC_Tools.GetToolsList(ToolListType.Attached);

            if (toolNumbers.Count > 0)
            {

                foreach (long tool in toolNumbers)
                {
                    GetToolTimer.Start();
                    Okuma.EasyToolData.Tool t = EasyToolData_THINC_Tools.GetToolObject(tool);
                    GetToolTimer.Stop();

                    averageElapsed = GetToolTimer.ElapsedMilliseconds / howManyToolObjectsGot;
                    howManyToolObjectsGot++;

                    Application.Current.Dispatcher.BeginInvoke(
                        DispatcherPriority.Normal,
                        new Action(() =>
                        {
                            TreeViewNodeCollection.Add(new Models.TreeViewNode("Tool " + t.ToolNumber.ToString(), t));
                            TimeToGetTool = averageElapsed.ToString();
                        }));
                }
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Normal,
                    new Action(() =>
                    {
                        TimeToGetTool = "No Tools";
                    }));
            }
        }
        
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
       
    } // END class

} // END namespace