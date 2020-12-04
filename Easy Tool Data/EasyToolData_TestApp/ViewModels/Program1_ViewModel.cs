
namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System;

    using Okuma.EasyToolData.Enums;


    class Program1_ViewModel : INotifyPropertyChanged
    {
        // Class Variables

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.Program EasyToolData_THINC_Program;


        // Properties        
        private string _programIsExecuting, _hasActiveSDF, _sdfFileName, _sdfPath, _hasActiveProgram, _programFileName, _ProgramPath, _ProgramName;

        public string ProgramIsExecuting { get { return _programIsExecuting; } set { _programIsExecuting = value; OnPropertyChanged(nameof(ProgramIsExecuting)); } }
        public string HasActiveSDF { get { return _hasActiveSDF; } set { _hasActiveSDF = value; OnPropertyChanged(nameof(HasActiveSDF)); } }
        public string SDFFileName { get { return _sdfFileName; } set { _sdfFileName = value; OnPropertyChanged(nameof(SDFFileName)); } }
        public string SDFFilePath { get { return _sdfPath; } set { _sdfPath = value; OnPropertyChanged(nameof(SDFFilePath)); } }
        public string HasActiveProgram { get { return _hasActiveProgram; } set { _hasActiveProgram = value; OnPropertyChanged(nameof(HasActiveProgram)); } }
        public string ProgramFileName { get { return _programFileName; } set { _programFileName = value; OnPropertyChanged(nameof(ProgramFileName)); } }
        public string PartProgramFilePath { get { return _ProgramPath; } set { _ProgramPath = value; OnPropertyChanged(nameof(PartProgramFilePath)); } }
        public string ActivePartProgramName { get { return _ProgramName; } set { _ProgramName = value; OnPropertyChanged(nameof(ActivePartProgramName)); } }


        // Commands

        private DelegateCommand<bool> _executeCommand;
        public DelegateCommand<bool> ExecuteCommand
        {
            get
            {
                if (_executeCommand == null)
                {
                    _executeCommand = new DelegateCommand<bool>(
                        (s) => { Test_ThincProgram(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }


        // Constructor
        public Program1_ViewModel()
        {
            EasyToolData_THINC_Program = new Okuma.EasyToolData.THINC.Program();
        }

        // Methods

        private void Test_ThincProgram()
        {
            ValidatedResponse vr;

            ProgramIsExecuting = EasyToolData_THINC_Program.PartProgramIsExecuting().ToString();

            // Has Active
            HasActiveSDF = EasyToolData_THINC_Program.HasActiveScheduledProgram.ToString();
            HasActiveProgram = EasyToolData_THINC_Program.HasActivePartProgram.ToString();

            // File Name
            vr = EasyToolData_THINC_Program.ActiveScheduledProgramFileName(out string s);
            if (vr == ValidatedResponse.TRUE) { SDFFileName = s; }
            else { SDFFileName = vr.ToString(); }

            vr = EasyToolData_THINC_Program.ActivePartProgramFileName(out s);
            if (vr == ValidatedResponse.TRUE) { ProgramFileName = s; }
            else { ProgramFileName = vr.ToString(); }

            // Path
            vr = EasyToolData_THINC_Program.ActiveScheduledProgramFilePath(out s);
            if (vr == ValidatedResponse.TRUE) { SDFFilePath = s; }
            else { SDFFilePath = vr.ToString(); }

            vr = EasyToolData_THINC_Program.ActivePartProgramFilePath(out s);
            if (vr == ValidatedResponse.TRUE) { PartProgramFilePath = s; }
            else { PartProgramFilePath = vr.ToString(); }

            // Program Name
            vr = EasyToolData_THINC_Program.ActivePartProgramName(out s);
            if (vr == ValidatedResponse.TRUE) { ActivePartProgramName = s; }
            else { ActivePartProgramName = vr.ToString(); }
        }


        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}