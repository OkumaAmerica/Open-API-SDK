using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyToolData_TestApp.ViewModels
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Threading;
    using System.Reflection;
    using Okuma.SharedLog;



    class MainViewModel : INotifyPropertyChanged
    {

        //////////////////////////////////
        //  ______ _      _     _     
        //  |  ___(_)    | |   | |    
        //  | |_   _  ___| | __| |___ 
        //  |  _| | |/ _ \ |/ _` / __|
        //  | |   | |  __/ | (_| \__ \
        //  \_|   |_|\___|_|\__,_|___/

        public const bool AlwaysExecute = true;
        public event PropertyChangedEventHandler PropertyChanged;



        /////////////////////////////////////////////////////////
        //  ______                          _   _           
        //  | ___ \                        | | (_)          
        //  | |_/ / __ ___  _ __   ___ _ __| |_ _  ___  ___ 
        //  |  __/ '__/ _ \| '_ \ / _ \ '__| __| |/ _ \/ __|
        //  | |  | | | (_) | |_) |  __/ |  | |_| |  __/\__ \
        //  \_|  |_|  \___/| .__/ \___|_|   \__|_|\___||___/
        //                 | |                              
        //                 |_|   

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


        /////////////////////////////
        //   _____ _             
        //  /  __ \ |            
        //  | /  \/ |_ ___  _ __ 
        //  | |   | __/ _ \| '__|
        //  | \__/\ || (_) | |   
        //   \____/\__\___/|_|  

        public MainViewModel()
        {
            MainViewTitle = "Okuma.EasyToolData Test Application v" + Okuma.Scout.ProgramInfo.ThisAssemblyVersion +
                "  (Okuma.EasyToolData.dll v" + Okuma.EasyToolData.Helpers.DllAssemblyVersion  + ")";
        }



        /////////////////////////////////////////////////////////////
        //   _____                                           _     
        //  /  __ \                                         | |    
        //  | /  \/ ___  _ __ ___  _ __ ___   __ _ _ __   __| |___ 
        //  | |    / _ \| '_ ` _ \| '_ ` _ \ / _` | '_ \ / _` / __|
        //  | \__/\ (_) | | | | | | | | | | | (_| | | | | (_| \__ \
        //   \____/\___/|_| |_| |_|_| |_| |_|\__,_|_| |_|\__,_|___/

        private DelegateCommand<bool> _command_MainWindowLoaded;
        public DelegateCommand<bool> Command_MainWindowLoaded
        {
            get
            {
                if (_command_MainWindowLoaded == null)
                {
                    _command_MainWindowLoaded = new DelegateCommand<bool>(
                        (s) => { ExecuteMainWindowLoadedCommand(); },
                        (s) => { return AlwaysExecute; }
                        );
                }
                return _command_MainWindowLoaded;
            }
        }


        private void ExecuteMainWindowLoadedCommand()
        {
            // Attempt to ensure this executes on the main GUI thread!!!
            Application.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Normal, new Action(() =>
                {
                    AppLoadCompleted();
                }));
        }

        public void AppLoadCompleted()
        {
            try
            {
                // API required for these operations:
                // Prevent out-right crash (System.IO Exception) on machine w/out API
                if (Okuma.Scout.ThincApi.Installed)
                {
                    Okuma.Scout.LicenseItem Lic_P200 = Okuma.Scout.LicenseChecker.License_ControlTypeP200;

                    if (Lic_P200.Status != Okuma.Scout.Enums.LicenseStatus.Valid)
                    {
                        Log.Send(new MessageArg(
                            string.Format("THINC API License Not Valid." + Environment.NewLine +
                            "Feature '{0}' v{1} expires '{2}' status = {3}", Lic_P200.Feature, 
                            Lic_P200.Version, Lic_P200.ExpiryDate, Lic_P200.Status),
                            MessageType.STOP_ERROR, MethodBase.GetCurrentMethod().Name, 
                            ex: null, log: true, display: true), typeof(MainViewModel).FullName);

                        return;
                    }

                    if (Okuma.Scout.Platform.BaseMachineType == Okuma.Scout.Enums.MachineType.L)
                    {
                        Okuma.Scout.LicenseItem Lic_DatL = Okuma.Scout.LicenseChecker.License_DataApi_L;
                        Okuma.Scout.LicenseItem Lic_CmdL = Okuma.Scout.LicenseChecker.License_CommandApi_L;

                        string DatL_Exp = Lic_DatL.Expires == true ? string.Format("{0:d}", Lic_DatL.ExpiryDate) : "never";
                        string CmdL_Exp = Lic_CmdL.Expires == true ? string.Format("{0:d}", Lic_CmdL.ExpiryDate) : "never";

                        if (Lic_DatL.Status != Okuma.Scout.Enums.LicenseStatus.Valid ||
                            Lic_CmdL.Status != Okuma.Scout.Enums.LicenseStatus.Valid) 
                        {
                            Log.Send(new MessageArg(
                                string.Format("THINC API License Not Valid." + Environment.NewLine +
                                "     Feature '{0}' v{1} expires '{2}' status: {3}" + Environment.NewLine +
                                "     Feature '{4}' v{5} expires '{6}' status: {7}", 
                                Lic_DatL.Feature, Lic_DatL.Version, DatL_Exp, Lic_DatL.Status,
                                Lic_CmdL.Feature, Lic_CmdL.Version, CmdL_Exp, Lic_CmdL.Status),
                                MessageType.STOP_ERROR, MethodBase.GetCurrentMethod().Name,
                                ex: null, log: true, display: true), typeof(MainViewModel).FullName);

                            return;
                        }
                        else
                        {
                            Log.Send(new MessageArg(
                                string.Format("THINC API License Verified." + Environment.NewLine +
                                "     Feature '{0}' v{1} expires '{2}' Status: {3}" + Environment.NewLine +
                                "     Feature '{4}' v{5} expires '{6}' Status: {7}",
                                Lic_DatL.Feature, Lic_DatL.Version, DatL_Exp, Lic_DatL.Status,
                                Lic_CmdL.Feature, Lic_CmdL.Version, CmdL_Exp, Lic_CmdL.Status),
                                MessageType.STATUS, MethodBase.GetCurrentMethod().Name,
                                ex: null, log: true, display: true), typeof(MainViewModel).FullName);
                        }
                    }
                    else if (Okuma.Scout.Platform.BaseMachineType == Okuma.Scout.Enums.MachineType.M)
                    {
                        Okuma.Scout.LicenseItem Lic_DatM = Okuma.Scout.LicenseChecker.License_DataApi_MC;
                        Okuma.Scout.LicenseItem Lic_CmdM = Okuma.Scout.LicenseChecker.License_CommandApi_MC;

                        string DatM_Exp = Lic_DatM.Expires == true ? string.Format("{0:d}", Lic_DatM.ExpiryDate) : "never";
                        string CmdM_Exp = Lic_CmdM.Expires == true ? string.Format("{0:d}", Lic_CmdM.ExpiryDate) : "never";

                        if (Lic_DatM.Status != Okuma.Scout.Enums.LicenseStatus.Valid ||
                            Lic_CmdM.Status != Okuma.Scout.Enums.LicenseStatus.Valid)
                        {
                            Log.Send(new MessageArg(
                                string.Format("THINC API License Not Valid." + Environment.NewLine +
                                "     Feature '{0}' v{1} expires '{2}' status: {3}" + Environment.NewLine +
                                "     Feature '{4}' v{5} expires '{6}' status: {7}",
                                Lic_DatM.Feature, Lic_DatM.Version, DatM_Exp, Lic_DatM.Status,
                                Lic_CmdM.Feature, Lic_CmdM.Version, CmdM_Exp, Lic_CmdM.Status),
                                MessageType.STOP_ERROR, MethodBase.GetCurrentMethod().Name,
                                ex: null, log: true, display: true), typeof(MainViewModel).FullName);

                            return;
                        }
                        else
                        {
                            Log.Send(new MessageArg(
                                string.Format("THINC API License Verified." + Environment.NewLine +
                                "     Feature '{0}' v{1} expires '{2}' status: {3}" + Environment.NewLine +
                                "     Feature '{4}' v{5} expires '{6}' status: {7}",
                                Lic_DatM.Feature, Lic_DatM.Version, DatM_Exp, Lic_DatM.Status,
                                Lic_CmdM.Feature, Lic_CmdM.Version, CmdM_Exp, Lic_CmdM.Status),
                                MessageType.STATUS, MethodBase.GetCurrentMethod().Name,
                                ex: null, log: true, display: true), typeof(MainViewModel).FullName);
                        }
                    }
                  
                    if (Okuma.Scout.ThincApi.ApiAvailable == Okuma.Scout.Enums.ApiStatus.Ready)
                    {
                        Okuma.EasyToolData.THINC.API EasyToolData_THINC_API = new Okuma.EasyToolData.THINC.API();

                        // NOTE: The main thread name must be specified in order to 
                        //       ensure that the API is initialized on the correct thread.
                        EasyToolData_THINC_API.GuiThreadName = Global.MainGuiThreadName;

                        // Init API
                        EasyToolData_THINC_API.InitializeAPI();

                    }

                    Log.Send(new MessageArg(
                        "THINC API Status: " + Okuma.Scout.ThincApi.ApiAvailable,
                        MessageType.STATUS, MethodBase.GetCurrentMethod().Name,
                        ex: null, log: true, display: true), typeof(MainViewModel).FullName);         
                }
                else
                {
                    Log.Send(new MessageArg(
                        "THINC API Not Installed.",
                        MessageType.STOP_ERROR, MethodBase.GetCurrentMethod().Name,
                        ex: null, log: true, display: true), typeof(MainViewModel).FullName);
                }
            }
            catch (Exception ex)
            {
                Log.SendEx(ex, typeof(MainViewModel).FullName, MethodBase.GetCurrentMethod().Name);
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
