using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyToolData_TestApp.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System;

    class Workpiece3_ViewModel : INotifyPropertyChanged
    {
        //////////////////////////////////
        //  ______ _      _     _     
        //  |  ___(_)    | |   | |    
        //  | |_   _  ___| | __| |___ 
        //  |  _| | |/ _ \ |/ _` / __|
        //  | |   | |  __/ | (_| \__ \
        //  \_|   |_|\___|_|\__,_|___/

        /// <summary> Necessary to support binding updates </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        System.Threading.Thread GetDataThread;

        private bool Loaded = false;

        /// <summary> Used for delegate commands that can always be executed </summary>
        private const bool AlwaysExecute = true;

        Okuma.EasyToolData.THINC.Workpiece EasyToolData_THINC_Workpiece;
        Okuma.EasyToolData.THINC.Spindle EasyToolData_THINC_Spindle;
        Okuma.EasyToolData.THINC.Turret EasyToolData_THINC_Turret;
        Okuma.EasyToolData.THINC.Axes EasyToolData_THINC_Axes;


        /////////////////////////////////////////////////////////
        //  ______                          _   _           
        //  | ___ \                        | | (_)          
        //  | |_/ / __ ___  _ __   ___ _ __| |_ _  ___  ___ 
        //  |  __/ '__/ _ \| '_ \ / _ \ '__| __| |/ _ \/ __|
        //  | |  | | | (_) | |_) |  __/ |  | |_| |  __/\__ \
        //  \_|  |_|  \___/| .__/ \___|_|   \__|_|\___||___/
        //                 | |                              
        //                 |_|                              
      
        public ObservableCollection<Okuma.EasyToolData.Enums.Turrets> Turrets { get; set; }
        public ObservableCollection<Okuma.EasyToolData.Enums.Spindles> Spindles { get; set; }
        public ObservableCollection<Okuma.EasyToolData.NumberedOffset> NumberedOffsetsCollection { get; set; }
        public ObservableCollection<OffsetDisplay> OffsetDisplayCollection { get; set; }
        public ObservableCollection<ColumnDescriptor> Columns { get; private set; }


        private int _spindles_SelectedIndex;
        public int Spindles_SelectedIndex
        {
            get { return _spindles_SelectedIndex; }
            set
            {
                _spindles_SelectedIndex = value;
                OnPropertyChanged(nameof(Spindles_SelectedIndex));

                Spindles_SelectedIndexChanged();
            }
        }

        private int _turrets_SelectedIndex;
        public int Turrets_SelectedIndex
        {
            get { return _turrets_SelectedIndex; }
            set
            {
                _turrets_SelectedIndex = value;
                OnPropertyChanged(nameof(Turrets_SelectedIndex));

                Turrets_SelectedIndexChanged();
            }
        }

        private string _numberOfOffsets;
        public string NumberOfOffsets
        {
            get { return _numberOfOffsets; }
            set { _numberOfOffsets = value; OnPropertyChanged(nameof(NumberOfOffsets)); }
        }

        private bool _turretsExist = true;
        public bool TurretsExist
        {
            get { return _turretsExist; }
            set { _turretsExist = value; OnPropertyChanged(nameof(TurretsExist)); }
        }


        /////////////////////////////////////////////////////////////
        //   _____                                           _     
        //  /  __ \                                         | |    
        //  | /  \/ ___  _ __ ___  _ __ ___   __ _ _ __   __| |___ 
        //  | |    / _ \| '_ ` _ \| '_ ` _ \ / _` | '_ \ / _` / __|
        //  | \__/\ (_) | | | | | | | | | | | (_| | | | | (_| \__ \
        //   \____/\___/|_| |_| |_|_| |_| |_|\__,_|_| |_|\__,_|___/
        
        private DelegateCommand<bool> _executeCommand;
        public DelegateCommand<bool> ExecuteCommand
        {
            get
            {
                if (_executeCommand == null)
                {
                    _executeCommand = new DelegateCommand<bool>(
                        (s) => { Test_ThincWorkpiece(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _executeCommand;
            }
        }


        /////////////////////////////
        //   _____ _             
        //  /  __ \ |            
        //  | /  \/ |_ ___  _ __ 
        //  | |   | __/ _ \| '__|
        //  | \__/\ || (_) | |   
        //   \____/\__\___/|_|   

        public Workpiece3_ViewModel()
        {
            EasyToolData_THINC_Workpiece = new Okuma.EasyToolData.THINC.Workpiece();
            EasyToolData_THINC_Spindle = new Okuma.EasyToolData.THINC.Spindle();
            EasyToolData_THINC_Turret = new Okuma.EasyToolData.THINC.Turret();
            EasyToolData_THINC_Axes = new Okuma.EasyToolData.THINC.Axes();

            NumberedOffsetsCollection = new ObservableCollection<Okuma.EasyToolData.NumberedOffset>();
            OffsetDisplayCollection = new ObservableCollection<OffsetDisplay>();
            Spindles = new ObservableCollection<Okuma.EasyToolData.Enums.Spindles>();
            Turrets = new ObservableCollection<Okuma.EasyToolData.Enums.Turrets>();
            Columns = new ObservableCollection<ColumnDescriptor>();
        }


        /////////////////////////////////////////////////
        //  ___  ___     _   _               _     
        //  |  \/  |    | | | |             | |    
        //  | .  . | ___| |_| |__   ___   __| |___ 
        //  | |\/| |/ _ \ __| '_ \ / _ \ / _` / __|
        //  | |  | |  __/ |_| | | | (_) | (_| \__ \
        //  \_|  |_/\___|\__|_| |_|\___/ \__,_|___/
        
        private void Test_ThincWorkpiece()
        {
            NumberOfOffsets = EasyToolData_THINC_Workpiece.NumberOfOffsets.ToString();

            if (!Loaded)
            {

                foreach (Okuma.EasyToolData.Enums.Spindles s in EasyToolData_THINC_Spindle.ValidSpindles)
                {
                    Spindles.Add(s);
                }
                if (Spindles.Count > 0)
                {
                    Spindles_SelectedIndex = 0;
                }

                if (EasyToolData_THINC_Turret.ValidTurrets.Count > 0)
                {
                    foreach (Okuma.EasyToolData.Enums.Turrets t in EasyToolData_THINC_Turret.ValidTurrets)
                    {
                        Turrets.Add(t);
                    }
                    if (Turrets.Count > 0)
                    {
                        Turrets_SelectedIndex = 0;
                    }

                    if (EasyToolData_THINC_Turret.ValidTurrets.Count == 1 &&
                        EasyToolData_THINC_Turret.ValidTurrets[0] == Okuma.EasyToolData.Enums.Turrets.None)
                    {
                        if (TurretsExist) { TurretsExist = false; }
                    }
                }
                else
                {
                    if (TurretsExist) { TurretsExist = false; }
                }

                List<Okuma.EasyToolData.Enums.Axes> validAxes = EasyToolData_THINC_Axes.ValidAxes;

                AddCol(" Offset Number ", "OffsetNumber");
                if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.BA)) { AddCol(" BA ", "Value_BA"); }
                if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.C)) { AddCol(" C ", "Value_C"); }
                if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.Fifth)) { AddCol(" 5th ", "Value_Fifth"); }
                if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.Fourth)) { AddCol(" 4th ", "Value_Fourth"); }
                if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.Sixth)) { AddCol(" 6th ","Value_Sixth"); }
                if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.Unknown)) { AddCol(" Unknown ", "Value_Unknown"); }
                if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.W)) { AddCol(" W ", "Value_W"); }
                if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.X)) { AddCol(" X ", "Value_X"); }
                //if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.XI)) { AddCol(" XI ", "Value_XI"); }
                //if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.XIR)) { AddCol(" XIR ", "Value_XIR"); }
                if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.Y)) { AddCol(" Y ", "Value_Y"); }
                if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.YI)) { AddCol(" YI ","Value_YI"); }
                //if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.YIR)) { AddCol(" YIR ", "Value_YIR"); }
                if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.YS)) { AddCol(" YS ", "Value_YS"); }
                if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.Z)) { AddCol(" Z ", "Value_Z"); }
                //if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.ZI)) { AddCol(" ZI ", "Value_ZI"); }
                //if (validAxes.Contains(Okuma.EasyToolData.Enums.Axes.ZIR)) { AddCol(" ZIR ", "Value_ZIR"); }
                AddCol(" Use ", "Use");

                Loaded = true;
            }

            Threaded_GetOffets();
        }

        private void AddCol(string HeaderText, string DisplayMember)
        {
            this.Columns.Add(new ColumnDescriptor(HeaderText, DisplayMember));
        }

        private void Spindles_SelectedIndexChanged()
        {
            if (Loaded)
            {
                Threaded_GetOffets();
            }
        }

        private void Turrets_SelectedIndexChanged()
        {
            if (Loaded)
            {
                Threaded_GetOffets();
            }
        }

        private void Axes_SelectedIndexChanged()
        {
            if (Loaded)
            {
                Threaded_GetOffets(); 
            }
        }

        private void Threaded_GetOffets()
        {
            if (GetDataThread != null && GetDataThread.IsAlive)
            {
                // Do nothing. Aborting Causes Exception
                // GetDataThread.Abort();
            }
            else
            {
                GetDataThread = new System.Threading.Thread(GetOffsets)
                {
                    Name = "Get Offsets Thread",
                    Priority = System.Threading.ThreadPriority.Normal
                };

                GetDataThread.Start();
            }
        }

        /// <summary>
        /// This is a Lathe-only implementation at the moment.
        /// Mill Offsets are a whole nother bag of snakes.
        /// </summary>
        private void GetOffsets()
        {
            System.Windows.Application.Current.Dispatcher.BeginInvoke(
                System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
                {
                    NumberedOffsetsCollection.Clear();
                }));

            // You are responsible for determining if a numbered offset is the current one.
            // The GetNumberedOffset function would be required to double the number of API calls otherwise.
            // Here, we call GetCurrentOffsets() just once, before entering the loop over NumberOfOffsets.
            EasyToolData_THINC_Workpiece.GetCurrentOffsets(
                Turrets[Turrets_SelectedIndex],
                Spindles[Spindles_SelectedIndex],
                out Okuma.EasyToolData.NumberedOffset currentOffset);


            // Everything below this comment should go away and IsUsed must 
            // be determined by EasyToolData as a part of GetCurrentOffsets().


            // There should only be 1 "USE" numbered offset.
            // Only mark the FIRST one that matches current as used.
            bool UsedOffsetIdentified = false;

            for (int i = 1; i < EasyToolData_THINC_Workpiece.NumberOfOffsets + 1; i++)
            {
                EasyToolData_THINC_Workpiece.GetNumberedOffset(
                    Turrets[Turrets_SelectedIndex],
                    Spindles[Spindles_SelectedIndex],
                    i, out Okuma.EasyToolData.NumberedOffset offset);

                if (!UsedOffsetIdentified)
                {
                    offset.Use = IsOffsetUsed(currentOffset, offset);
                    UsedOffsetIdentified = offset.Use;
                }

                System.Windows.Application.Current.Dispatcher.BeginInvoke(
                    System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
                    {
                        NumberedOffsetsCollection.Add(offset);
                    }));
            }

            // Finished populating NumberedOffsetsCollection. 

            // Now convert to OffsetDisplayCollection.
            // Note: should probably just do this to begin with and skip NumberedOffsetsCollection. NumberedOffsetsCollection is a hold-over.

            System.Windows.Application.Current.Dispatcher.BeginInvoke(
                System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
                {
                    OffsetDisplayCollection.Clear();
                }));

            foreach (Okuma.EasyToolData.NumberedOffset o in NumberedOffsetsCollection)
            {
                OffsetDisplay od = new OffsetDisplay();

                od.OffsetNumber = o.OffsetNumber;

                foreach (Okuma.EasyToolData.AxisOffsetValue aov in o.Offsets)
                {
                    switch (aov.Axis)
                    {
                        case Okuma.EasyToolData.Enums.Axes.BA: { od.Value_BA = aov.Value; break; }
                        case Okuma.EasyToolData.Enums.Axes.C: { od.Value_C = aov.Value; break; }
                        case Okuma.EasyToolData.Enums.Axes.Fifth: { od.Value_Fifth = aov.Value; break; }
                        case Okuma.EasyToolData.Enums.Axes.Fourth: { od.Value_Fourth = aov.Value; break; }
                        case Okuma.EasyToolData.Enums.Axes.Sixth: { od.Value_Sixth = aov.Value; break; }
                        case Okuma.EasyToolData.Enums.Axes.Unknown: { od.Value_Unknown = aov.Value; break; }
                        case Okuma.EasyToolData.Enums.Axes.W: { od.Value_W = aov.Value; break; }
                        case Okuma.EasyToolData.Enums.Axes.X: { od.Value_X = aov.Value; break; }
                        //case Okuma.EasyToolData.Enums.Axes.XI: { od.Value_XI = aov.Value; break; }
                        //case Okuma.EasyToolData.Enums.Axes.XIR: { od.Value_XIR = aov.Value; break; }
                        case Okuma.EasyToolData.Enums.Axes.Y: { od.Value_Y = aov.Value; break; }
                        case Okuma.EasyToolData.Enums.Axes.YI: { od.Value_YI = aov.Value; break; }
                        //case Okuma.EasyToolData.Enums.Axes.YIR: { od.Value_YIR = aov.Value; break; }
                        case Okuma.EasyToolData.Enums.Axes.YS: { od.Value_YS = aov.Value; break; }
                        case Okuma.EasyToolData.Enums.Axes.Z: { od.Value_Z = aov.Value; break; }
                        //case Okuma.EasyToolData.Enums.Axes.ZI: { od.Value_ZI = aov.Value; break; }
                        //case Okuma.EasyToolData.Enums.Axes.ZIR: { od.Value_ZIR = aov.Value; break; }
                    }          
                }

                System.Windows.Application.Current.Dispatcher.BeginInvoke(
                    System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
                    {
                        OffsetDisplayCollection.Add(od);
                    }));

            }

        }

        // This should go away, and IsUsed should be determined by EasyToolData function.
        private bool IsOffsetUsed(Okuma.EasyToolData.NumberedOffset current, Okuma.EasyToolData.NumberedOffset given)
        {
            if(current.Spindle == given.Spindle &&
                current.Turret == given.Turret) 
            {
                // Check for the existence of each AxisOffsetValue in the Offsets list
                foreach (Okuma.EasyToolData.AxisOffsetValue aov in current.Offsets)
                {
                    // Note: The AxisOffsetValue Class overrides Equals() and GetHashCode() to make this possible. 
                    if (!given.Offsets.Contains(aov))
                    {
                        return false;
                    }
                }

                // If each one of the current offsets exists in the given offsets and are equal
                // as defined in the AxisOffsetValue class (called via the 'Contains()' method), 
                // Then presumably current == given.
                return true; 
            }

            return false;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }

    public class OffsetDisplay
    {
        public int OffsetNumber { get; set; }
        public bool Use { get; set; }

        // .ZIR  .ZI  .Z  .YS  .YIR  .YI  .Y  .XIR  .XI  .X  .W  .Unknown  .Sixth  .Fourth  .Fifth  .C  .BA

        public double Value_BA { get; set; }
        public double Value_C { get; set; }
        public double Value_Fifth { get; set; }
        public double Value_Fourth { get; set; }
        public double Value_Sixth { get; set; }
        public double Value_Unknown { get; set; }
        public double Value_W { get; set; }
        public double Value_X { get; set; }
        //public double Value_XI { get; set; }
        //public double Value_XIR { get; set; }
        public double Value_Y { get; set; }
        public double Value_YI { get; set; }
        //public double Value_YIR { get; set; }
        public double Value_YS { get; set; }
        public double Value_Z { get; set; }
        //public double Value_ZI { get; set; }
        //public double Value_ZIR { get; set; }
    }




}