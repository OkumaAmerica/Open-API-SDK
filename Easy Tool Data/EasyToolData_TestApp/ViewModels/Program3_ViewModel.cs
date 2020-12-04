
namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System;
    using System.Reflection;
    using System.Windows;

    using System.IO;
    using Ookii.Dialogs.Wpf;
    using System.Windows.Data;



    class Program3_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;


        // Properties

        private string _path;
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged("Path");

                ExecuteCommand.RaiseCanExecuteChanged();
            }
        }


        public ObservableCollection<Okuma.EasyToolData.SubProgram> SubProgramsUsedCollection { get; set; }
        public ICollectionView SubProgramsUsedCollectionView;

        public ObservableCollection<string> ContainedProgramNames { get; set; }
        public ICollectionView ContainedProgramNamesView;

        public ObservableCollection<ExternalSubProgram> ExternalPrograms { get; set; }


        private string _containedProgramNamesSelectedItem;
        public string ContainedProgramNamesSelectedItem
        {
            get { return _containedProgramNamesSelectedItem; }
            set
            {
                _containedProgramNamesSelectedItem = value;
                OnPropertyChanged("ContainedProgramNamesSelectedItem");
            }
        }



    // Commands

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

        private DelegateCommand<bool> _executeCommand;
        public DelegateCommand<bool> ExecuteCommand
        {
            get
            {
                if (_executeCommand == null)
                {
                    _executeCommand = new DelegateCommand<bool>(
                        (s) => { Execute_ThincProgram3(); },
                        (s) => { return Path != ""; }
                        );
                }
                return _executeCommand;
            }
        }


        // Ctor
        public Program3_ViewModel()
        {    
            Path = "";

            SubProgramsUsedCollection = new ObservableCollection<Okuma.EasyToolData.SubProgram>();
            SubProgramsUsedCollectionView = CollectionViewSource.GetDefaultView(SubProgramsUsedCollection);
            SubProgramsUsedCollectionView.SortDescriptions.Add(new SortDescription("ProgramName", ListSortDirection.Ascending));
            SubProgramsUsedCollectionView.CurrentChanged += SubProgramsUsedCollectionView_CurrentChanged;


            ContainedProgramNames = new ObservableCollection<string>();
            ContainedProgramNamesView = CollectionViewSource.GetDefaultView(ContainedProgramNames);
            ContainedProgramNamesView.SortDescriptions.Add(new SortDescription(null, ListSortDirection.Ascending));

            ExternalPrograms = new ObservableCollection<ExternalSubProgram>();

        }

        private void SubProgramsUsedCollectionView_CurrentChanged(object sender, EventArgs e)
        {
            string c;
            if (SubProgramsUsedCollectionView.CurrentItem != null)
            {
                Okuma.EasyToolData.SubProgram s = (Okuma.EasyToolData.SubProgram)SubProgramsUsedCollectionView.CurrentItem;
                c = s.ProgramName;

                if (ContainedProgramNames.Contains(c))
                {
                    ContainedProgramNamesSelectedItem = c;                 
                }
            }       
        }


        // Methods

        private void Execute_ThincProgram3()
        {
            Clear();

            Okuma.EasyToolData.PartPrograms EasyToolData_PartPrograms = new Okuma.EasyToolData.PartPrograms();
            Okuma.EasyToolData.OSP_Program myProgram = EasyToolData_PartPrograms.GetProgramObject(Path);

            foreach (Okuma.EasyToolData.SubProgram sp in myProgram.UsedSubPrograms)
            {
                SubProgramsUsedCollection.Add(sp);
            }
            

            foreach (string p in myProgram.ProgramNames)
            {
                ContainedProgramNames.Add(p);
            }


            foreach (Okuma.EasyToolData.SubProgram Sub in myProgram.External_UsedSubPrograms)
            {
                ExternalSubProgram extSubProg = new ExternalSubProgram
                {
                    SubProgramName = Sub.ProgramName
                };

                Okuma.EasyToolData.OSP_Program program = EasyToolData_PartPrograms.FindSubProgram(Sub.ProgramName);

                // if (File.Exists(program.FileInfo.Path))
                if (File.Exists(program.Path))
                {
                    extSubProg.InProgram = program;
                }
                else
                {
                    program.FileName = "Not Found";
                    extSubProg.InProgram = program;
                }
               
                ExternalPrograms.Add(extSubProg);
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
                        Execute_ThincProgram3();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.SendEx(ex, typeof(Program3_ViewModel).FullName, MethodBase.GetCurrentMethod().Name);
            }
        }
        



        private void Clear()
        {
            SubProgramsUsedCollection.Clear();
            ContainedProgramNames.Clear();
            ExternalPrograms.Clear();
        }
        

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }


    public class ExternalSubProgram
    {
        public string SubProgramName { get; set; }

        public Okuma.EasyToolData.OSP_Program InProgram { get; set; }
    }

}