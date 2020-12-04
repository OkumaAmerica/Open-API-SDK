
namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System;
    using System.Windows;
    using System.IO;
    using Ookii.Dialogs.Wpf;
    using System.Reflection;
    using System.Collections.Generic;
    using Okuma.SharedLog;


    class Program2_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        readonly Okuma.EasyToolData.THINC.Program EasyToolData_THINC_Program;
        Okuma.EasyToolData.PartPrograms EasyToolData_PartPrograms;

        private System.Diagnostics.Stopwatch stopwatch;

        // Properties

        public ObservableCollection<Okuma.EasyToolData.OSP_Program> ProgramsCollection { get; set; }

        private int _programsCollectionSelectedIndex;
        public int ProgramsCollectionSelectedIndex
        {
            get { return _programsCollectionSelectedIndex; }
            set
            {
                _programsCollectionSelectedIndex = value;
                DisplayProgramDetails();
                OnPropertyChanged("ProgramsCollectionSelectedIndex");
            }
        }

        public ObservableCollection<Okuma.EasyToolData.SubProgram> SubProgramsCollection { get; set; }

        private int _subProgramsCollectionSelectedIndex;
        public int SubProgramsCollectionSelectedIndex
        {
            get { return _subProgramsCollectionSelectedIndex; }
            set
            {
                _subProgramsCollectionSelectedIndex = value;
                DisplaySubProgramCalloutDetails();
                OnPropertyChanged("SubProgramsCollectionSelectedIndex");
            }
        }



        public ObservableCollection<string> ProgramNames { get; set; }

        private string _path;
        public string Path { get { return _path; } set { _path = value;  OnPropertyChanged(nameof(Path)); } }

        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }

        private string _extension;
        public string Extension { get { return _extension; } set { _extension = value; OnPropertyChanged(nameof(Extension)); } }

        private string _size;
        public string Size { get { return _size; } set { _size = value; OnPropertyChanged(nameof(Size)); } }

        private string _lines;
        public string Lines { get { return _lines; } set { _lines = value; OnPropertyChanged(nameof(Lines)); } }

        private string _modified;
        public string Modified { get { return _modified; } set { _modified = value; OnPropertyChanged(nameof(Modified)); } }

        private string _subType;
        public string SubType { get { return _subType; } set { _subType = value; OnPropertyChanged(nameof(SubType)); } }

        private string _subLine;
        public string SubLine { get { return _subLine; } set { _subLine = value; OnPropertyChanged(nameof(SubLine)); } }

        private string _subCode;
        public string SubCode { get { return _subCode; } set { _subCode = value; OnPropertyChanged(nameof(SubCode)); } }



        // Commands

        private DelegateCommand<bool> _executeCommand;
        public DelegateCommand<bool> ExecuteCommand
        {
            get
            {
                if (_executeCommand == null)
                {
                    _executeCommand = new DelegateCommand<bool>(
                        (s) => { Execute_ThincProgram2(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }

        private DelegateCommand<bool> _chooseProgramCommand;
        public DelegateCommand<bool> ChooseProgramCommand
        {
            get
            {
                if (_chooseProgramCommand == null)
                {
                    _chooseProgramCommand = new DelegateCommand<bool>(
                        (s) => { ChooseProgram(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _chooseProgramCommand;
            }
        }
        
        // Constructor
        public Program2_ViewModel()
        {
            ProgramsCollection = new ObservableCollection<Okuma.EasyToolData.OSP_Program>();
            SubProgramsCollection = new ObservableCollection<Okuma.EasyToolData.SubProgram>();
            ProgramNames = new ObservableCollection<string>();
            EasyToolData_THINC_Program = new Okuma.EasyToolData.THINC.Program();
            EasyToolData_PartPrograms = new Okuma.EasyToolData.PartPrograms();
            stopwatch = new System.Diagnostics.Stopwatch();
        }

        // Methods
        
        private void Execute_ThincProgram2()
        {
            ProgramsCollection.Clear();

            stopwatch.Reset();
            stopwatch.Start();
            List<Okuma.EasyToolData.OSP_Program> osppList = EasyToolData_PartPrograms.FindAllPrograms(UseCachedList: false);
            stopwatch.Stop();

            Log.Send(new MessageArg(
                string.Format("EasyToolData_PartPrograms.FindAllPrograms() took {0} ms to complete.", stopwatch.ElapsedMilliseconds),
                MessageType.INFO, "Execute_ThincProgram2()"), this.GetType().FullName);

            foreach (Okuma.EasyToolData.OSP_Program ospp in osppList)
            {
                ProgramsCollection.Add(ospp);
            }

            if (ProgramsCollection.Count > 0)
            {
                ProgramsCollectionSelectedIndex = 0;
            }
        }

        private void ChooseProgram()
        {
            try
            {
                // As of .Net 3.5 SP1, WPF's Microsoft.Win32.OpenFileDialog class still uses the old style
                VistaOpenFileDialog dialog = new VistaOpenFileDialog
                {
                    Filter = "Programs (*.MIN;*.SUB;*.MSB;*.SSB;*.LIB;*.SDF)|*.MIN;*.SUB;*.MSB;*.SSB;*.LIB;*.SDF",
                    Multiselect = false,
                    Title = "Please Choose a Part Program File"
                };

                if (Directory.Exists(@"D:\MD1\"))
                {
                    dialog.InitialDirectory = @"D:\MD1\";
                }

                if (!VistaFileDialog.IsVistaFileDialogSupported)
                {
                    MessageBox.Show("Because you are not using Windows Vista or later, the regular open file " +
                        "dialog will be used. Please use Windows Vista to see the new dialog.", "Please Choose a Part Program File");
                }
                if ((bool)dialog.ShowDialog())
                {
                    if (File.Exists(dialog.FileName))
                    {
                        Path = dialog.FileName;

                        ProgramsCollection.Clear();
                        Okuma.EasyToolData.OSP_Program program = EasyToolData_PartPrograms.GetProgramObject(dialog.FileName);
                        ProgramsCollection.Add(program);
                        ProgramsCollectionSelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.SendEx(ex, typeof(Program2_ViewModel).FullName, MethodBase.GetCurrentMethod().Name);
            }
        }

        private void DisplayProgramDetails()
        {
            if (ProgramsCollection.Count > 0 && ProgramsCollectionSelectedIndex > -1)
            {
                Path = ProgramsCollection[ProgramsCollectionSelectedIndex].Path;
                Name = ProgramsCollection[ProgramsCollectionSelectedIndex].FileName;
                Extension = ProgramsCollection[ProgramsCollectionSelectedIndex].Extension;
                Size = ProgramsCollection[ProgramsCollectionSelectedIndex].Bytes.ToString();
                Lines = ProgramsCollection[ProgramsCollectionSelectedIndex].Lines.ToString();
                Modified = ProgramsCollection[ProgramsCollectionSelectedIndex].Modified.ToShortDateString();
                Lines = ProgramsCollection[ProgramsCollectionSelectedIndex].Lines.ToString();

                SubProgramsCollection.Clear();
                ProgramNames.Clear();

                foreach (Okuma.EasyToolData.SubProgram sp in ProgramsCollection[ProgramsCollectionSelectedIndex].UsedSubPrograms)
                {
                    SubProgramsCollection.Add(sp);
                }
                foreach (string p in ProgramsCollection[ProgramsCollectionSelectedIndex].ProgramNames)
                {
                    ProgramNames.Add(p);
                }
            }
            else { ClearDetails(); }
        }

        private void DisplaySubProgramCalloutDetails()
        {
            if (SubProgramsCollection.Count > 0 && SubProgramsCollectionSelectedIndex > -1)
            {
                SubType = SubProgramsCollection[SubProgramsCollectionSelectedIndex].SubCalloutType.ToString();
                SubLine = SubProgramsCollection[SubProgramsCollectionSelectedIndex].CalloutLine;

                if (SubProgramsCollection[SubProgramsCollectionSelectedIndex].SubCalloutType == Okuma.EasyToolData.Enums.SubCalloutType.GCode)
                {
                    SubCode = SubProgramsCollection[SubProgramsCollectionSelectedIndex].GCodeNumber;
                }
                else if (SubProgramsCollection[SubProgramsCollectionSelectedIndex].SubCalloutType == Okuma.EasyToolData.Enums.SubCalloutType.MCode)
                {
                    SubCode = SubProgramsCollection[SubProgramsCollectionSelectedIndex].MCodeNumber;
                }
                else
                {
                    // clear SubCode?
                }          
            }
            else
            {
                SubType = "";
                SubLine = "";
                SubCode = "";
            }
        }

        private void ClearDetails()
        {
            Path = "";
            Name = "";
            Extension = "";
            Size = "";
            Lines = "";
            Modified = "";

            SubProgramsCollection.Clear();
            ProgramNames.Clear();

            SubType = "";
            SubLine = "";
            SubCode = "";
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}