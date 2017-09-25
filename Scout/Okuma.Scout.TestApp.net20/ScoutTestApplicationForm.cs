//-----------------------------------------------------------------------
// <copyright file="Form1.cs" company="Okuma America Corporation">
//     Copyright© 2018 Okuma America Corporation
// </copyright>
// <project> SCOUT Test Application
// </project>
// <author> Scott Solmer
// </author>   
// <remarks> This sample code is unlicensed.
// It is distributed "AS IS", WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either expressed or implied. Okuma America grants you permission to use
// this code and derivative works thereof without limitation or obligation.
// </remarks>
// <disclaimer> Under no circumstance shall Okuma America be held liable 
// to anyone using this code or programs derived there from for damages 
// of any kind as a result of the use or inability to use this code, 
// including but not limited to damages for loss of goodwill, work 
// stoppage, computer failure or malfunction, or any and all other 
// commercial damages or losses.
// </disclaimer>
//-----------------------------------------------------------------------


[assembly: System.CLSCompliant(true)]

namespace Okuma.Scout.TestApp.net20
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Forms;
    using Okuma.Scout;


    /// <summary>
    /// Scout Test Application Class (Form1.cs)
    /// For Error Handling Code, refer to ErrorHandling.cs </summary>
    public partial class ScoutTestApplicationForm : Form
    {
        /// <summary>Used to prevent access to Okuma.Scout.Display until user has executed 'Platform'.</summary>
        private bool platformExecuted = false;

        /// <summary>Used to prevent unnecessary repeat checks of ready status</summary>
        private bool apiHasBeenInitializedOrIsReady = false;

        /// <summary>Support structures for DataGridView on 'Registry' tab</summary>
        DataGridView BackingInstanceForDataGridView_SubKeys;
        SortableBindingList<Subkeys> SubkeysBindingList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoutTestApplicationForm"/> class.
        /// </summary>
        public ScoutTestApplicationForm()
        {
            this.InitializeComponent();

            /* ===============================================================================
             * === These default error messages may be modified if desired. (not required) ===
             * 
             * Okuma.Scout.OspFileInfo.ErrorMessage = "Not Found"; 
             * Okuma.Scout.DMC.DMC_ErrorMessage = "Data Management Card Not Found.";
             * Okuma.Scout.SpecCode.FileNotFoundErrorMessage = "File Not Found.";
             * Okuma.Scout.SpecCode.FileReadErrorMessage = "Error Reading File.";
             * Okuma.Scout.OS.ErrorMessage = "No Value";
             * 
             */

            // Prepare 'Registry' tab support structures (Refer to Subkeys.cs and SortableBindingList.cs)
            BackingInstanceForDataGridView_SubKeys = DataGridView_SubKeys;
            SubkeysBindingList = new SortableBindingList<Subkeys>();
            BackingInstanceForDataGridView_SubKeys.DataSource = SubkeysBindingList;

            // Get Common Language Runtime Versions
            DisplayClrVersions();

            // Add more info to test App title bar
            string moreInfo = "  v" + Okuma.Scout.ProgramInfo.ThisAssemblyVersion +
                "  (Okuma.Scout.dll v" + Okuma.Scout.ProgramInfo.ScoutDllAssemblyVersion + ")";
            this.Text += moreInfo;
        }


        #region Platform
        /// <summary>
        /// Acquire the machine type, control type, and display information </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click </param>
        private void Button_Platform_Click(object sender, EventArgs e)
        {
            // This is where the machine and control type are determined.
            Okuma.Scout.Enums.MachineType currentMachine = Okuma.Scout.Platform.Machine;
            Okuma.Scout.Enums.ControlType currentControl = Okuma.Scout.Platform.Control;

            // The enumeration values for machine type can be cryptic ("PCNCM_M" for example..)
            // ConvertToMachineTypeString() returns a human readable version.
            this.TextBox_MachineType.Text = Okuma.Scout.Platform.ConvertToMachineTypeString(currentMachine);
            this.TextBox_ControlType.Text = currentControl.ToString();
            this.TextBox_suiteVersion.Text = Okuma.Scout.Platform.OspSuiteVersion;
            this.TextBox_NcSoftPkgVersion.Text = Okuma.Scout.Platform.NcControlPackageVersion;
            this.TextBox_OspRestrictions.Text = Okuma.Scout.SpecCode.OspRectrictions.ToString();

            // The PhysicalPanelSize enumeration isn't too bad, but the following lines of code
            // attempt to improve readability anyway as the result is for human consumption in this case.
            string PanelTypeEnumToText = "";
            Okuma.Scout.Enums.PhysicalPanelSize PPS = Okuma.Scout.Display.PanelType;
            switch (PPS)
            {
                case Enums.PhysicalPanelSize.PnP_NonOsp:
                    {
                        PanelTypeEnumToText = @"Plug and Play Non-OSP panel";
                        break;
                    }
                case Enums.PhysicalPanelSize.SixPointFiveInch:
                    {
                        PanelTypeEnumToText = @"6.5"" OSP panel";
                        break;
                    }
                case Enums.PhysicalPanelSize.FifteenInch:
                    {
                        PanelTypeEnumToText = @"15"" OSP panel";
                        break;
                    }
                case Enums.PhysicalPanelSize.NineteenInch:
                    {
                        PanelTypeEnumToText = @"19"" OSP panel";
                        break;
                    }
                case Enums.PhysicalPanelSize.UnknownSize:
                    {
                        PanelTypeEnumToText = "OSP panel not recognized";
                        break;
                    }
                default:
                    {
                        PanelTypeEnumToText = "Not an OSP panel";
                        break;
                    }
            }
            this.TextBox_PanelType.Text = PanelTypeEnumToText;

            // The following code is only applicable on 19" panel sizes because the 15" displays do not include
            // the SELECTSCREEN tool. In that case, the result will be NA.
            string ScreenModeEnumToText = "";
            Okuma.Scout.Enums.NineteenInchScreenMode NISM = Okuma.Scout.Display.SelectScreenMode;
            switch (NISM)
            {
                case Enums.NineteenInchScreenMode.FullScreen:
                    {
                        ScreenModeEnumToText = "Full Screen";
                        break;
                    }
                case Enums.NineteenInchScreenMode.ModeA:
                    {
                        ScreenModeEnumToText = "A Mode (Windowed, lower left)";
                        break;
                    }
                case Enums.NineteenInchScreenMode.ModeB:
                    {
                        ScreenModeEnumToText = "B Mode (Windowed, lower right)";
                        break;
                    }
                case Enums.NineteenInchScreenMode.UnknownMode:
                    {
                        ScreenModeEnumToText = "Error: Unknown Screen Mode";
                        break;
                    }
                default:
                    {
                        ScreenModeEnumToText = "NA";
                        break;
                    }
            }
            TextBox_ScreenMode.Text = ScreenModeEnumToText;

            // Clear the display data and refresh it every time the Platform button is clicked.
            this.ComboBox_Display.Items.Clear();
            Okuma.Scout.Display.RefreshDisplayInfo();

            // Add the detected displays to the combo box
            foreach (KeyValuePair<int, Okuma.Scout.Display.DisplayInfo> DI in Okuma.Scout.Display.DisplayDictionary)
            {
                this.ComboBox_Display.Items.Add(DI.Value.DisplayName);
            }
            platformExecuted = true;

            // Select the first item in the list (if any exist).
            if (ComboBox_Display.Items.Count > 0)
            {
                ComboBox_Display.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// When a display is selected from the combo box, show the information related
        /// to that display in the Display Information text box.
        /// </summary>
        /// <param name="sender">The combo box object</param>
        /// <param name="e">Event arguments associated with the combo box index change </param>
        private void ComboBoxDisplay_IndexChanged(object sender, EventArgs e)
        {
            if (uiLoaded && platformExecuted)
            {
                foreach (KeyValuePair<int, Okuma.Scout.Display.DisplayInfo> DI in Okuma.Scout.Display.DisplayDictionary)
                {
                    if (DI.Value.DisplayName == ComboBox_Display.SelectedItem.ToString())
                    {
                        string DisplayName = "Display Name: " + DI.Value.DisplayName;
                        string MonitorName = "Monitor Name: " + DI.Value.MonitorName;
                        string Primary = "Primary Display: " + DI.Value.Primary.ToString();
                        string Bounds = "Display Bounds: " + DI.Value.Bounds.ToString();
                        string WorkArea = "Display Work Area: " + DI.Value.WorkArea.ToString();
                        string DeviceID = "Device ID: " + DI.Value.DeviceID;
                        string DeviceKey = "Device Key: " + DI.Value.DeviceKey;

                        TextBox_DisplayInfo.Text =
                            DisplayName + Environment.NewLine +
                            MonitorName + Environment.NewLine +
                            Primary + Environment.NewLine +
                            Bounds + Environment.NewLine +
                            WorkArea + Environment.NewLine +
                            DeviceID + Environment.NewLine +
                            DeviceKey;
                    }
                }
            }
        }


        #endregion

        #region Directories
        /// <summary>
        /// Using Scout, acquire the existence of system directories
        /// </summary>
        /// <param name="sender">Object which created the event</param>
        /// <param name="e">Event arguments</param>
        private void Button_Directories_Click(object sender, EventArgs e)
        {
            // Returns type Boolean, converted to string for display in text box
            this.TextBox_DirOsp.Text = Okuma.Scout.OspFileInfo.DirExists_OSP.ToString();
            this.TextBox_DirCns.Text = Okuma.Scout.OspFileInfo.DirExists_CNS.ToString();
            this.TextBox_DirVolante.Text = Okuma.Scout.OspFileInfo.DirExists_VOLANTE.ToString();
            this.TextBox_DirCrad.Text = Okuma.Scout.OspFileInfo.DirExists_CRAD.ToString();
            this.TextBox_DirOkuma.Text = Okuma.Scout.OspFileInfo.DirExists_Okuma.ToString();
            this.TextBox_DirPCNCM.Text = Okuma.Scout.OspFileInfo.DirExists_PCNCM.ToString();

            this.TextBox_DirCurrent.Text = Environment.CurrentDirectory;
            this.TextBox_DirSystem.Text = Environment.SystemDirectory;
        }
        #endregion

        #region API Info

        /// <summary>
        /// Using Scout, acquire information about the API
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_ThincApiInfo_Click(object sender, EventArgs e)
        {
            // THINC API Install Info
            this.TextBox_ApiSpecValid.Text = Okuma.Scout.SpecCode.ThincApiSpec.ToString();
            this.TextBox_ApiInstalled.Text = Okuma.Scout.ThincApi.Installed.ToString();
            this.TextBox_InstallType.Text = Okuma.Scout.ThincApi.InstallType;
            if (Okuma.Scout.ThincApi.InstallVersion.Result == Okuma.Scout.Enums.ApiVersionCheckResult.VersionRecognized)
            {
                this.TextBox_ApiInstallVersion.Text = Okuma.Scout.ThincApi.InstallVersion.ApiVersion.ToString();
            }
            else
            {
                this.TextBox_ApiInstallVersion.Text = Okuma.Scout.ThincApi.InstallVersion.Result.ToString();
            }

            // THINC API Installed Libraries
            this.TextBox_ThincLatheCommandApi.Text = Okuma.Scout.ThincApi.GACExist_CommandApi_Lathe.ToString();
            this.TextBox_ThincLatheDataApi.Text = Okuma.Scout.ThincApi.GACExist_DataApi_Lathe.ToString();
            this.TextBox_ThincMachiningCenterCommandApi.Text = Okuma.Scout.ThincApi.GACExist_CommandApi_MachiningCenter.ToString();
            this.TextBox_ThincMachiningCenterDataApi.Text = Okuma.Scout.ThincApi.GACExist_DataApi_MachiningCenter.ToString();
            this.TextBox_ThincGrinderCommandApi.Text = Okuma.Scout.ThincApi.GACExist_CommandApi_Grinder.ToString();
            this.TextBox_ThincGrinderDataApi.Text = Okuma.Scout.ThincApi.GACExist_DataApi_Grinder.ToString();
            this.TextBox_FlexNet.Text = Okuma.Scout.ThincApi.GACExist_FlexNet.ToString();

            // THINC API Installed Library Versions
            this.TextBox_ThincLatheCommandApiVer.Text = Okuma.Scout.ThincApi.CommandApiVersionInGAC_Lathe;
            this.TextBox_ThincLatheDataApiVer.Text = Okuma.Scout.ThincApi.DataApiVersionInGAC_Lathe;
            this.TextBox_ThincMachiningCenterCommandApiVer.Text = Okuma.Scout.ThincApi.CommandApiVersionInGAC_MachiningCenter;
            this.TextBox_ThincMachiningCenterDataApiVer.Text = Okuma.Scout.ThincApi.DataApiVersionInGAC_MachiningCenter;
            this.TextBox_ThincGrinderCommandApiVer.Text = Okuma.Scout.ThincApi.CommandApiVersionInGAC_Grinder;
            this.TextBox_ThincGrinderDataApiVer.Text = Okuma.Scout.ThincApi.DataApiVersionInGAC_Grinder;
            this.TextBox_FlexNetVersion.Text = Okuma.Scout.ThincApi.FlexNetVersionInGAC;

            if (this.apiHasBeenInitializedOrIsReady == false)
            {
                // Check if the API is available for use
                // Note that accessing this property may result in an attempt to instantiate the
                // API and will not allow the check to be made more than once every 5 seconds.
                // Thus, the property should be temporarily kept in a local variable if it is to be
                // used multiple times in the same scope.
                Okuma.Scout.Enums.ApiStatus status = Okuma.Scout.ThincApi.ApiAvailable;

                switch (status)
                {
                    case Okuma.Scout.Enums.ApiStatus.Ready:
                        {
                            this.TextBox_ApiAvailable.Text = status.ToString();
                            this.Button_InitApi.Enabled = true;
                            this.apiHasBeenInitializedOrIsReady = true;
                            break;
                        }

                    case Okuma.Scout.Enums.ApiStatus.NotReady:
                        {
                            this.TextBox_ApiAvailable.Text = status.ToString();
                            break;
                        }

                    case Okuma.Scout.Enums.ApiStatus.Initialized:
                        {
                            this.TextBox_ApiAvailable.Text = "Ready";
                            this.TextBox_ApiInstantiated.Text = status.ToString();
                            this.Button_ExecuteApiFunctions.Enabled = true;
                            this.apiHasBeenInitializedOrIsReady = true;
                            break;
                        }

                    case Okuma.Scout.Enums.ApiStatus.FailedToInitialize:
                        {
                            this.TextBox_ApiAvailable.Text = status.ToString();
                            break;
                        }

                    case Okuma.Scout.Enums.ApiStatus.FiveSecondTimeOutPeriod:
                        {
                            this.TextBox_ApiAvailable.Text = status.ToString();
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Using Scout, Initialize the API through reflection
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_InitApi_Click(object sender, EventArgs e)
        {
            Okuma.Scout.Enums.ApiStatus status = Okuma.Scout.ThincApiReflector.InitAPI();
            this.TextBox_ApiInstantiated.Text = status.ToString();

            if (status == Okuma.Scout.Enums.ApiStatus.Initialized)
            {
                this.Button_ExecuteApiFunctions.Enabled = true;
                this.Button_InitApi.Enabled = false;
            }
        }

        /// <summary>
        /// Using Scout, perform actions with the API (through reflection)
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_ExecuteApiFunctions_Click(object sender, EventArgs e)
        {
            /* !! WARNING !! These functions are only to be used in situations where accessing the THINC API
             * via Reflection (http://msdn.microsoft.com/en-us/library/vstudio/f7ykdhsy%28v=vs.110%29.aspx) is necessary.
             * Normally, these same API functions can be accessed in your program by adding the THINC API files as
             * references to your project. That is the recommended method to use the THINC API. 
             * These functions can only be executed once Okuma.Scout.ThincApi.InitAPI() returns "Initialized".
             */
            this.TextBox_ApiMachineName.Text = Okuma.Scout.ThincApiReflector.MachineName();
            this.TextBox_ApiSerialNumber.Text = Okuma.Scout.ThincApiReflector.SerialNumber();
            this.TextBox_ApiCV1.Text = Okuma.Scout.ThincApiReflector.GetCommonVariable(1).ToString();
        }


        private void Button_OspApiInfo_Click(object sender, EventArgs e)
        {
            // OSP API Files Exist
            // The process of gathering all API files information can take up to a 
            // few seconds. To prevent locking up the User Interface, the retrieval
            // of this information is performed using a thread.
            Thread getApiFilesInfo = new Thread(new ThreadStart(this.ApiFiles));
            getApiFilesInfo.Name = "GetApiFileInfoThread";
            getApiFilesInfo.Priority = ThreadPriority.Normal;
            getApiFilesInfo.Start();


            Okuma.Scout.VersionInformation ver = Okuma.Scout.ThincApi.CAPIVersion;

            switch (ver.Result)
            {
                case Enums.ApiVersionCheckResult.MachineTypeNotSupported:
                    {
                        TextBox_CAPIVersion.Text = "N/A";
                        break;
                    }
                case Enums.ApiVersionCheckResult.MissingApiFiles:
                    {
                        TextBox_CAPIVersion.Text = "CAPI files missing";
                        break;
                    }
                case Enums.ApiVersionCheckResult.MissingCrossReference:
                    {
                        TextBox_CAPIVersion.Text = "Version Cross Reference missing.";
                        break;
                    }
                case Enums.ApiVersionCheckResult.UnknownVersion:
                    {
                        TextBox_CAPIVersion.Text = "Unknown CAPI version.";
                        break;
                    }
                case Enums.ApiVersionCheckResult.VersionRecognized:
                    {
                        TextBox_CAPIVersion.Text = ver.CustomApiVersion;
                        break;
                    }
                default:
                    {
                        TextBox_CAPIVersion.Text = "Error";
                        break;
                    }
            }
        }


        /// <summary>
        /// Using Scout, acquire information related to API files.
        /// Runs on a separate thread started by the <see cref="Button_FileInfo_Click"/> method.
        /// </summary>
        private void ApiFiles()
        {
            string tempString = string.Empty;

            // Lathe Files Exist?
            // Returns type Boolean, converted to string for display in text box
            tempString = Okuma.Scout.OspFileInfo.OspLatheSpecialApi_Exists.ToString();
            this.PostResult(this.TextBox_OspLatheSpecialApi, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspLatheCommandApi_Exists.ToString();
            this.PostResult(this.TextBox_OspLatheCommandApi, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspLatheDataApi_Exists.ToString();
            this.PostResult(this.TextBox_OspLatheDataApi, tempString);

            // Machining Center Files Exist?
            // Returns type Boolean, converted to string for display in text box
            tempString = Okuma.Scout.OspFileInfo.OspMachiningCenterSpecialApi_Exists.ToString();
            this.PostResult(this.TextBox_OspMachiningCenterSpecialApi, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspMachiningCenterCommandApi_Exists.ToString();
            this.PostResult(this.TextBox_OspMachiningCenterCommandApi, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspMachiningCenterDataApi_Exists.ToString();
            this.PostResult(this.TextBox_OspMachiningCenterDataApi, tempString);

            // Grinder Files Exist?
            // Returns type Boolean, converted to string for display in text box
            tempString = Okuma.Scout.OspFileInfo.OspGrinderCommandApi_Exists.ToString();
            this.PostResult(this.TextBox_OspGrinderCommandApi, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspGrinderDataApi_Exists.ToString();
            this.PostResult(this.TextBox_OspGrinderDataApi, tempString);

            // Lathe File Versions
            // Returns type string
            tempString = Okuma.Scout.OspFileInfo.OspLatheSpecialApi_Version;
            this.PostResult(this.TextBox_OspLatheSpecialApiVer, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspLatheCommandApi_Version;
            this.PostResult(this.TextBox_OspLatheCommandApiVer, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspLatheDataApi_Version;
            this.PostResult(this.TextBox_OspLatheDataApiVer, tempString);

            // Machining Center File Versions
            // Returns type string
            tempString = Okuma.Scout.OspFileInfo.OspMachiningCenterSpecialApi_Version;
            this.PostResult(this.TextBox_OspMachiningCenterSpecialApiVer, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspMachiningCenterCommandApi_Version;
            this.PostResult(this.TextBox_OspMachiningCenterCommandApiVer, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspMachiningCenterDataApi_Version;
            this.PostResult(this.TextBox_OspMachiningCenterDataApiVer, tempString);

            // Grinder File Versions
            // Returns type string
            tempString = Okuma.Scout.OspFileInfo.OspGrinderCommandApi_Version;
            this.PostResult(this.TextBox_OspGrinderCommandApiVer, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspGrinderDataApi_Version;
            this.PostResult(this.TextBox_OspGrinderDataApiVer, tempString);
        }


        // ========================================================================
        // ========================================================================
        // THINC API 2
        //

        private void Button_ThincApiInfo2_Click(object sender, EventArgs e)
        {
            Version parsedInput;

            bool parsed = Okuma.Scout.Helper.VersionTryParse(TextBox_IsTapiCompatibleInput.Text, out parsedInput);

            if (parsed)
            {
                bool isSupported = Okuma.Scout.ThincApi.DoesMachineSupportThincApiVersion(parsedInput);

                TextBox_IsTapiCompatibleResult.Text = isSupported.ToString();
            }
            else
            {
                TextBox_IsTapiCompatibleResult.Text = "Input is not a version.";
            }
        }


        #endregion

        #region File Info

        /// <summary>
        /// Using Scout, acquire information about Okuma system files
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_FileInfo_Click(object sender, EventArgs e)
        {
            // PC NC-Master Control Panel Exist
            this.TextBox_PCNCMControlPanelExist.Text = Okuma.Scout.OspFileInfo.PcNcMasterExists.ToString();

            // Spec Code Files Exist
            this.TextBox_PLCSpecFileExist.Text = Okuma.Scout.SpecCode.PLC.MachineSpecCodeFileExists.ToString();
            this.TextBox_NCSpecFileExist.Text = Okuma.Scout.SpecCode.NC.MachineSpecCodeFileExists.ToString();
            this.TextBox_NCBSpecFileExist.Text = Okuma.Scout.SpecCode.NCB.MachineSpecCodeFileExists.ToString();

            // Misc Files Exist
            this.TextBox_DMC.Text = Okuma.Scout.OspFileInfo.DMCExists.ToString();
            this.TextBox_ThincApiLicense.Text = Okuma.Scout.OspFileInfo.ThincApiLicenseExists.ToString();
            this.TextBox_EbiFry.Text = Okuma.Scout.OspFileInfo.EbyFryExists.ToString();
            this.TextBox_ApiNotifier.Text = Okuma.Scout.OspFileInfo.ApiNotifierExists.ToString();
            this.TextBox_EbiFryVer.Text = Okuma.Scout.OspFileInfo.EbiFryVersion;
            this.TextBox_ApiNotifierVer.Text = Okuma.Scout.OspFileInfo.ApiNotifierVersion;
            this.TextBox_SoftSwitch.Text = Okuma.Scout.OspFileInfo.SoftSwitchExists.ToString();
            this.TextBox_SoftSwitchVer.Text = Okuma.Scout.OspFileInfo.SoftSwitchVersion;
            this.TextBox_PiodLibExists.Text = Okuma.Scout.OspFileInfo.PiodLib_Exists.ToString();
            this.TextBox_PiodLibVersion.Text = Okuma.Scout.OspFileInfo.PiodLib_Version.ToString();
            this.TextBox_OspGestureExists.Text = Okuma.Scout.OspFileInfo.OspGesture_Exists.ToString();
            this.TextBox_OspGestureVersion.Text = Okuma.Scout.OspFileInfo.OspGesture_Version.ToString();
            this.TextBox_OspTouchExists.Text = Okuma.Scout.OspFileInfo.OspTouch_Exists.ToString();
            this.TextBox_OspTouchVersion.Text = Okuma.Scout.OspFileInfo.OspTouch_Version.ToString();

            // Modified
            this.TextBox_DMCModified.Text = Okuma.Scout.OspFileInfo.DMCModifiedDate;
            this.TextBox_ThincApiLicenseModified.Text = Okuma.Scout.OspFileInfo.ThincApiLicenseModifiedDate;
        }


        #endregion

        #region Processes
        /// <summary>
        /// Using Scout, acquire information about running processes
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_Processes_Click(object sender, EventArgs e)
        {
            this.TextBox_ApiNotifierRun.Text = Okuma.Scout.OspProcessInfo.ApiNotifierRunning.ToString();
            this.TextBox_OspRun.Text = Okuma.Scout.OspProcessInfo.EbiStartRunning.ToString();
            this.TextBox_OwmRun.Text = Okuma.Scout.OspProcessInfo.WidgetManagerRunning.ToString();
            this.TextBox_SoftSwitchRun.Text = Okuma.Scout.OspProcessInfo.SoftSwitchRunning.ToString();
        }
        #endregion

        #region PIOD
        private void Button_PiodFileExecute_Click(object sender, EventArgs e)
        {
            this.TextBox_ValidPiodFileExists.Text = Okuma.Scout.PIOD.MachinePiodFileExists.ToString();
            this.TextBox_PiodControl.Text = Okuma.Scout.PIOD.Control;
            this.TextBox_PiodMachineType.Text = Okuma.Scout.PIOD.MachineType;
            this.TextBox_PiodPlcSystem.Text = Okuma.Scout.PIOD.PlcSystem;
            this.TextBox_PiodProjectNumber.Text = Okuma.Scout.PIOD.ProjectNumber;
        }

        private void RadioButton_PiodFile_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton_PiodFile();
        }

        /// <summary>
        /// Function called when radio button checked changed event is triggered.
        /// Sets user defined file path and "UseUserDefinedFilePath" properties depending
        /// on the checked state of the radio buttons. </summary>
        private void RadioButton_PiodFile()
        {
            if ((bool)uiLoaded)
            {
                if (RadioButton_PiodFileUser.Checked == true)
                {
                    Okuma.Scout.PIOD.UseUserDefinedFile = true;
                    if (string.IsNullOrEmpty(Okuma.Scout.PIOD.UserDefinedFilePath))
                    {
                        this.ChoosePiodFile();
                    }
                }
                else if (RadioButton_PiodFileDefault.Checked == true)
                {
                    Okuma.Scout.PIOD.UseUserDefinedFile = false;
                }
            }
        }

        private void Button_PiodSelectFile_Click(object sender, EventArgs e)
        {
            if (RadioButton_PiodFileDefault.Checked == true)
            {
                RadioButton_PiodFileUser.Checked = true;
            }
            else { this.ChoosePiodFile(); }
        }

        /// <summary>
        /// Generate open file dialog for selection of user defined spec file
        /// </summary>
        private void ChoosePiodFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select PIOD File";
            ofd.InitialDirectory = @"C:\";
            ofd.CustomPlaces.Add(@"C:\OSP-P\CNS-DAT\ENG\");
            ofd.CustomPlaces.Add(@"C:\OSP-P\CNS-DAT\JPN\");
            ofd.Filter = "PIOD File (*.CNS)|*.CNS";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Okuma.Scout.PIOD.UserDefinedFilePath = ofd.FileName;

                if (!Okuma.Scout.PIOD.PiodFileIsValid)
                {
                    RadioButton_PiodFileDefault.Checked = true;
                    MessageBox.Show(
                        "The selected PIOD file is not valid." + Environment.NewLine +
                        "Please choose another file.",
                        "Error Reading File",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);

                    Okuma.Scout.PIOD.UseUserDefinedFile = false;
                    Label_PiodFileUserFile.Text = string.Empty;

                    Okuma.Scout.PIOD.UserDefinedFilePath = string.Empty;
                }
                else { Label_PiodFileUserFile.Text = ofd.FileName; }
            }
            else { RadioButton_PiodFileDefault.Checked = true; }
        }

        #endregion

        #region Data Management Card
        /// <summary>
        /// Using Scout, acquire information from the Data Management Card
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_DMC_Click(object sender, EventArgs e)
        {
            // The process of gathering all Data Management Card Items can take up to a 
            // few seconds. To prevent locking up the User Interface, the retrieval
            // of this information is performed using a thread.
            Thread getDMCInfo = new Thread(new ThreadStart(this.DMCItems));
            getDMCInfo.Name = "GetDMCItemsThread";
            getDMCInfo.Priority = ThreadPriority.Normal;
            getDMCInfo.Start();
        }

        /// <summary>
        /// Using Scout, acquire information from the Data Management Card.
        /// Runs on a separate thread started by the <see cref="Button_DMC_Click"/> method.
        /// </summary>
        private void DMCItems()
        {
            this.ClearItems();

            this.PostItem("OSP Type: " + Okuma.Scout.DMC.OSPType);
            this.PostItem("Machine Type: " + Okuma.Scout.DMC.MachineType);
            this.PostItem("S/W Production No.: " + Okuma.Scout.DMC.SoftwareProductionNo);
            this.PostItem("Serial Number: " + Okuma.Scout.DMC.SerialNumber);
            this.PostItem("S/W Production Date: " + Okuma.Scout.DMC.SoftwareProductionDate);
            this.PostItem("Customer Name: " + Okuma.Scout.DMC.CustomerName);
            this.PostItem("Customer Address: " + Okuma.Scout.DMC.CustomerAddress);
            this.PostItem("Customer Phone Number: " + Okuma.Scout.DMC.CustomerPhone);
            this.PostItem("Customer: " + Okuma.Scout.DMC.Customer);
            this.PostItem("Note One: " + Okuma.Scout.DMC.NoteOne);
            this.PostItem("Note Special Spec: " + Okuma.Scout.DMC.NoteSpecialSpec);
            this.PostItem("Note Comment: " + Okuma.Scout.DMC.NoteComment);
            this.PostItem("Windows System CD Version: " + Okuma.Scout.DMC.WindowsSystemCDVersion);
            this.PostItem("OSP System CD Version: " + Okuma.Scout.DMC.OSPSystemCDVersion);
            this.PostItem("Windows System: " + Okuma.Scout.DMC.WindowsSystem);
            this.PostItem("OTSS Sample CD Version: " + Okuma.Scout.DMC.OTSSSampleCDVersion);
            this.PostItem("Excel Version: " + Okuma.Scout.DMC.ExcelVersion);
            this.PostItem("CAS Models CD Version: " + Okuma.Scout.DMC.CASModelsCDVersion);
            this.PostItem("NC Installer: " + Okuma.Scout.DMC.NcInstaller);
            this.PostItem("Real Time Operating System Driver: " + Okuma.Scout.DMC.RTOSDriver);
            this.PostItem("Real Time Operating System: " + Okuma.Scout.DMC.RTOS);
            this.PostItem("NC Control: " + Okuma.Scout.DMC.NcControl);
            this.PostItem("PLC System: " + Okuma.Scout.DMC.PLCSystem);
            this.PostItem("PLC System Message: " + Okuma.Scout.DMC.PLCSystemMsg);
            this.PostItem("P100 Tool: " + Okuma.Scout.DMC.P100Tool);
            this.PostItem("PLC Control: " + Okuma.Scout.DMC.PLCControl);
            this.PostItem("One Touch IGF: " + Okuma.Scout.DMC.OTI);
            this.PostItem("One Touch IGF Advanced M Machine Type: " + Okuma.Scout.DMC.OTIMT);
            this.PostItem("One Touch IGF Message: " + Okuma.Scout.DMC.OTIMsg);
            this.PostItem("Vertical Function Key: " + Okuma.Scout.DMC.VFK);
            this.PostItem("Vertical Function Key 2: " + Okuma.Scout.DMC.VFK2);
            this.PostItem("Vertical Function Key Message: " + Okuma.Scout.DMC.VFKMsg);
            this.PostItem("One Touch Spreadsheet File Controller: " + Okuma.Scout.DMC.OTSFileCntrl);
            this.PostItem("One Touch Spreadsheet File Controller Message: " + Okuma.Scout.DMC.OTSFileCntrlMsg);
            this.PostItem("One Touch Spreadsheet Pre-install Contents: " + Okuma.Scout.DMC.OTSPreInst);
            this.PostItem("IT Plaza Application Common: " + Okuma.Scout.DMC.ITPlaza);
            this.PostItem("Collision Avoidance System: " + Okuma.Scout.DMC.CAS);
            this.PostItem("Easy Modeling: " + Okuma.Scout.DMC.EasyModel);
            this.PostItem("Custom API: " + Okuma.Scout.DMC.CustomAPI);

            // List items:
            this.PostItem("NC Control MSG.: " + ListToString(Okuma.Scout.DMC.NcControlMsg));
            this.PostItem("NC Alarm Help: " + ListToString(Okuma.Scout.DMC.NcAlarmHelp));
            this.PostItem("NC Manual: " + ListToString(Okuma.Scout.DMC.NcManual));
        }


        private string ListToString(List<string> L)
        {
            string ret = Environment.NewLine;
            foreach (string s in L)
            {
                ret += s + ", ";
            }
            ret = ret.TrimEnd(',', ' ');
            return ret;
        }

        /// <summary>
        /// This function resolves cross-threading issues by invoking the 
        /// GUI thread to change list box contents </summary>
        /// <param name="item">New string to add to the list box</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exceptions are reported via the Error Handling Tab.")]
        private void PostItem(string item)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        this.ListBox_DMC.Items.Add(item + Environment.NewLine);
                    });
                }
                else
                {
                    this.ListBox_DMC.Items.Add(item + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                Okuma.Scout.Error.Args args = new Okuma.Scout.Error.Args(Okuma.Scout.Enums.MessageLevel.Exception, string.Empty, ex);
                this.HandleScoutErrorInfo(null, args);
            }
        }

        /// <summary>

        /// This function resolves cross-threading issues by invoking the 
        /// GUI thread to clear the list box contents </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exceptions are reported via the Error Handling Tab.")]
        private void ClearItems()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        this.ListBox_DMC.Items.Clear();
                    });
                }
                else
                {
                    this.ListBox_DMC.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                Okuma.Scout.Error.Args args = new Okuma.Scout.Error.Args(Enums.MessageLevel.Exception, string.Empty, ex);
                this.HandleScoutErrorInfo(null, args);
            }
        }
        #endregion

        #region .NET
        /// <summary>
        /// Using Scout, acquire information about the .NET Framework
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_DotNet_Click(object sender, EventArgs e)
        {
            this.TextBox_Net10.Text = Okuma.Scout.DotNet.v10_Installed.ToString();
            this.TextBox_Net11.Text = Okuma.Scout.DotNet.v11_Installed.ToString();
            this.TextBox_Net20.Text = Okuma.Scout.DotNet.v20_Installed.ToString();
            this.TextBox_Net30.Text = Okuma.Scout.DotNet.v30_Installed.ToString();
            this.TextBox_Net35.Text = Okuma.Scout.DotNet.v35_Installed.ToString();
            this.TextBox_Net40C.Text = Okuma.Scout.DotNet.v40Client_Installed.ToString();
            this.TextBox_Net40F.Text = Okuma.Scout.DotNet.v40Full_Installed.ToString();
            this.TextBox_Net45.Text = Okuma.Scout.DotNet.v45_Installed.ToString();
            this.TextBox_Net451.Text = Okuma.Scout.DotNet.v451_Installed.ToString();
            this.TextBox_Net452.Text = Okuma.Scout.DotNet.v452_Installed.ToString();
            this.TextBox_Net46.Text = Okuma.Scout.DotNet.v46_Installed.ToString();
            this.TextBox_Net461.Text = Okuma.Scout.DotNet.v461_Installed.ToString();
            this.TextBox_Net462.Text = Okuma.Scout.DotNet.v462_Installed.ToString();
            this.TextBox_Net47.Text = Okuma.Scout.DotNet.v47_Installed.ToString();

            this.TextBox_Net10Sp.Text = SPCheck(Okuma.Scout.DotNet.ServicePack_10);
            this.TextBox_Net11Sp.Text = SPCheck(Okuma.Scout.DotNet.ServicePack_11);
            this.TextBox_Net20Sp.Text = SPCheck(Okuma.Scout.DotNet.ServicePack_20);
            this.TextBox_Net30Sp.Text = SPCheck(Okuma.Scout.DotNet.ServicePack_30);
            this.TextBox_Net35Sp.Text = SPCheck(Okuma.Scout.DotNet.ServicePack_35);
            this.TextBox_Net40CSp.Text = SPCheck(Okuma.Scout.DotNet.ServicePack_40Client);
            this.TextBox_Net40FSp.Text = SPCheck(Okuma.Scout.DotNet.ServicePack_40Full);

            this.TextBox_Net45AndUpReleaseVersion.Text = SPCheck(Okuma.Scout.DotNet.ReleaseVersion_45AndUp);
        }

        /// <summary>
        /// This function translates the return value of DotNet.ServicePack_.. 
        /// and replaces the invalid / error value of -1 with 'N/A'.
        /// </summary>
        /// <param name="sp">Integer representing the service pack</param>
        /// <returns>A string value representing the service pack</returns>
        private static string SPCheck(int sp)
        {
            if (sp == -1)
            {
                return "N/A";
            }
            else
            {
                return sp.ToString();
            }
        }
        #endregion

        #region License
        /// <summary>
        /// Using Scout, acquire information related to licensing of API features
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_ApiLicense1_Click(object sender, EventArgs e)
        {
            // Data API License (Lathe):
            Okuma.Scout.LicenseItem dataApiLathe = Okuma.Scout.LicenseChecker.License_DataApi_L;
            this.TextBox_License_LDATAPI_FeatureName.Text = dataApiLathe.Feature;
            this.TextBox_License_LDATAPI_Version.Text = dataApiLathe.Version;
            this.TextBox_License_LDATAPI_Expires.Text = dataApiLathe.Expires.ToString();
            this.TextBox_License_LDATAPI_ExpireDate.Text = FormatExpireDate(dataApiLathe.ExpiryDate);
            this.TextBox_License_LDATAPI_Status.Text = dataApiLathe.Status.ToString();

            // Data API License (Machining Center):
            Okuma.Scout.LicenseItem dataApiMachiningCenter = Okuma.Scout.LicenseChecker.License_DataApi_MC;
            this.TextBox_License_MDATAPI_FeatureName.Text = dataApiMachiningCenter.Feature;
            this.TextBox_License_MDATAPI_Version.Text = dataApiMachiningCenter.Version;
            this.TextBox_License_MDATAPI_Expires.Text = dataApiMachiningCenter.Expires.ToString();
            this.TextBox_License_MDATAPI_ExpireDate.Text = FormatExpireDate(dataApiMachiningCenter.ExpiryDate);
            this.TextBox_License_MDATAPI_Status.Text = dataApiMachiningCenter.Status.ToString();

            // Data API License (Grinder):
            Okuma.Scout.LicenseItem dataApiGrinder = Okuma.Scout.LicenseChecker.License_DataApi_G;
            this.TextBox_License_GDATAPI_FeatureName.Text = dataApiGrinder.Feature;
            this.TextBox_License_GDATAPI_Version.Text = dataApiGrinder.Version;
            this.TextBox_License_GDATAPI_Expires.Text = dataApiGrinder.Expires.ToString();
            this.TextBox_License_GDATAPI_ExpireDate.Text = FormatExpireDate(dataApiGrinder.ExpiryDate);
            this.TextBox_License_GDATAPI_Status.Text = dataApiGrinder.Status.ToString();

            // Command API License (Lathe):
            Okuma.Scout.LicenseItem commandApiLathe = Okuma.Scout.LicenseChecker.License_CommandApi_L;
            this.TextBox_License_LCMDAPI_FeatureName.Text = commandApiLathe.Feature;
            this.TextBox_License_LCMDAPI_Version.Text = commandApiLathe.Version;
            this.TextBox_License_LCMDAPI_Expires.Text = commandApiLathe.Expires.ToString();
            this.TextBox_License_LCMDAPI_ExpireDate.Text = FormatExpireDate(commandApiLathe.ExpiryDate);
            this.TextBox_License_LCMDAPI_Status.Text = commandApiLathe.Status.ToString();

            // Command API License (Machining Center):
            Okuma.Scout.LicenseItem commandApiMachiningCenter = Okuma.Scout.LicenseChecker.License_CommandApi_MC;
            this.TextBox_License_MCMDAPI_FeatureName.Text = commandApiMachiningCenter.Feature;
            this.TextBox_License_MCMDAPI_Version.Text = commandApiMachiningCenter.Version;
            this.TextBox_License_MCMDAPI_Expires.Text = commandApiMachiningCenter.Expires.ToString();
            this.TextBox_License_MCMDAPI_ExpireDate.Text = FormatExpireDate(commandApiMachiningCenter.ExpiryDate);
            this.TextBox_License_MCMDAPI_Status.Text = commandApiMachiningCenter.Status.ToString();

            // Command API License (Grinder):
            Okuma.Scout.LicenseItem commandApiGrinder = Okuma.Scout.LicenseChecker.License_CommandApi_G;
            this.TextBox_License_GCMDAPI_FeatureName.Text = commandApiGrinder.Feature;
            this.TextBox_License_GCMDAPI_Version.Text = commandApiGrinder.Version;
            this.TextBox_License_GCMDAPI_Expires.Text = commandApiGrinder.Expires.ToString();
            this.TextBox_License_GCMDAPI_ExpireDate.Text = FormatExpireDate(commandApiGrinder.ExpiryDate);
            this.TextBox_License_GCMDAPI_Status.Text = commandApiGrinder.Status.ToString();

            // THINC Control Type P200 License:
            Okuma.Scout.LicenseItem p200Control = Okuma.Scout.LicenseChecker.License_ControlTypeP200;
            this.TextBox_License_P200_FeatureName.Text = p200Control.Feature;
            this.TextBox_License_P200_Version.Text = p200Control.Version;
            this.TextBox_License_P200_Expires.Text = p200Control.Expires.ToString();
            this.TextBox_License_P200_ExpireDate.Text = FormatExpireDate(p200Control.ExpiryDate);
            this.TextBox_License_P200_Status.Text = p200Control.Status.ToString();

            // NC Current Alarm Option License:
            Okuma.Scout.LicenseItem numericalControlCurrentAlarm = Okuma.Scout.LicenseChecker.License_NcCurrentAlarm;
            this.TextBox_License_NcCurrentAlarm_FeatureName.Text = numericalControlCurrentAlarm.Feature;
            this.TextBox_License_NcCurrentAlarm_Version.Text = numericalControlCurrentAlarm.Version;
            this.TextBox_License_NcCurrentAlarm_Expires.Text = numericalControlCurrentAlarm.Expires.ToString();
            this.TextBox_License_NcCurrentAlarm_ExpireDate.Text = FormatExpireDate(numericalControlCurrentAlarm.ExpiryDate);
            this.TextBox_License_NcCurrentAlarm_Status.Text = numericalControlCurrentAlarm.Status.ToString();

            // User Task I/O Lathe Option License:
            Okuma.Scout.LicenseItem userTaskIOLathe = Okuma.Scout.LicenseChecker.License_UserTaskIO_L;
            this.TextBox_License_UserTaskIOL_FeatureName.Text = userTaskIOLathe.Feature;
            this.TextBox_License_UserTaskIOL_Version.Text = userTaskIOLathe.Version;
            this.TextBox_License_UserTaskIOL_Expires.Text = userTaskIOLathe.Expires.ToString();
            this.TextBox_License_UserTaskIOL_ExpireDate.Text = FormatExpireDate(userTaskIOLathe.ExpiryDate);
            this.TextBox_License_UserTaskIOL_Status.Text = userTaskIOLathe.Status.ToString();

            // User Task I/O Machining Center Option License:
            Okuma.Scout.LicenseItem userTaskIOMachiningCenter = Okuma.Scout.LicenseChecker.License_UserTaskIO_MC;
            this.TextBox_License_UserTaskIOMC_FeatureName.Text = userTaskIOMachiningCenter.Feature;
            this.TextBox_License_UserTaskIOMC_Version.Text = userTaskIOMachiningCenter.Version;
            this.TextBox_License_UserTaskIOMC_Expires.Text = userTaskIOMachiningCenter.Expires.ToString();
            this.TextBox_License_UserTaskIOMC_ExpireDate.Text = FormatExpireDate(userTaskIOMachiningCenter.ExpiryDate);
            this.TextBox_License_UserTaskIOMC_Status.Text = userTaskIOMachiningCenter.Status.ToString();

            // User Alarm Lathe Option License:
            Okuma.Scout.LicenseItem userAlarmLathe = Okuma.Scout.LicenseChecker.License_UserAlarm_L;
            this.TextBox_License_UserAlarmL_FeatureName.Text = userAlarmLathe.Feature;
            this.TextBox_License_UserAlarmL_Version.Text = userAlarmLathe.Version;
            this.TextBox_License_UserAlarmL_Expires.Text = userAlarmLathe.Expires.ToString();
            this.TextBox_License_UserAlarmL_ExpireDate.Text = FormatExpireDate(userAlarmLathe.ExpiryDate);
            this.TextBox_License_UserAlarmL_Status.Text = userAlarmLathe.Status.ToString();

            // User Alarm Machining Center Option License:
            Okuma.Scout.LicenseItem userAlarmMachiningCenter = Okuma.Scout.LicenseChecker.License_UserAlarm_MC;
            this.TextBox_License_UserAlarmMC_FeatureName.Text = userAlarmMachiningCenter.Feature;
            this.TextBox_License_UserAlarmMC_Version.Text = userAlarmMachiningCenter.Version;
            this.TextBox_License_UserAlarmMC_Expires.Text = userAlarmMachiningCenter.Expires.ToString();
            this.TextBox_License_UserAlarmMC_ExpireDate.Text = FormatExpireDate(userAlarmMachiningCenter.ExpiryDate);
            this.TextBox_License_UserAlarmMC_Status.Text = userAlarmMachiningCenter.Status.ToString();

            // 8 Digit Tool ID Machining Center Option License:
            Okuma.Scout.LicenseItem toolID = Okuma.Scout.LicenseChecker.License_ToolID_MC;
            this.TextBox_License_ToolId_FeatureName.Text = toolID.Feature;
            this.TextBox_License_ToolId_Version.Text = toolID.Version;
            this.TextBox_License_ToolId_Expires.Text = toolID.Expires.ToString();
            this.TextBox_License_ToolId_ExpireDate.Text = FormatExpireDate(toolID.ExpiryDate);
            this.TextBox_License_ToolId_Status.Text = toolID.Status.ToString();
        }

        /// <summary>
        /// Return just the date and format as string if the license expires, otherwise return "N/A" </summary>
        /// <param name="expires">Boolean value Okuma.Scout.LicenseItem.Expires </param>
        /// <param name="expireDate">DateTime Okuma.Scout.LicenseItem.ExpiryDate </param>
        /// <returns>type string</returns>
        private static string FormatExpireDate(Nullable<DateTime> expireDate)
        {
            return expireDate.HasValue ? expireDate.Value.ToString("dd/MM/yyyy") : "N/A";
        }
        #endregion

        #region Program Info

        /// <summary>
        /// Using Scout, acquire information about the currently executing program.
        /// In this case, it is the Scout test application.
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_ProgramInfo_Click(object sender, EventArgs e)
        {
            this.TextBox_ErrorMessage.Text = Okuma.Scout.ProgramInfo.ErrorMessage;

            this.TextBox_AssemblyGuid.Text = Okuma.Scout.ProgramInfo.AssemblyGuid;
            this.TextBox_AssemblyTitle.Text = Okuma.Scout.ProgramInfo.AssemblyTitle;
            this.TextBox_AssemblyCopyright.Text = Okuma.Scout.ProgramInfo.AssemblyCopyright;
            this.TextBox_AssemblyCompany.Text = Okuma.Scout.ProgramInfo.AssemblyCompany;
            this.TextBox_AssemblyDescription.Text = Okuma.Scout.ProgramInfo.AssemblyDescription;

            this.TextBox_TestAppVersion.Text = Okuma.Scout.ProgramInfo.ThisAssemblyVersion;
            this.TextBox_TestAppBuildDate.Text = Okuma.Scout.ProgramInfo.ThisAssemblyBuildDate.ToString();

            this.TextBox_ScoutDllAssemblyVersion.Text = Okuma.Scout.ProgramInfo.ScoutDllAssemblyVersion;
            this.TextBox_ScoutDllBuildDate.Text = Okuma.Scout.ProgramInfo.ScoutDllBuildDate.ToString();

            // Slightly misleading, but this function is found in the Operating System class.
            // It reports the "bitness" of the currently executing program, hence it is under the Program tab.
            this.TextBox_ProgramBits.Text = Okuma.Scout.OS.ProgramBits.ToString();
        }

        /// <summary>
        /// Set the Scout program information error message
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_SetErrorMessage_Click(object sender, EventArgs e)
        {
            Okuma.Scout.ProgramInfo.ErrorMessage = this.TextBox_ErrorMessage.Text;
        }
        #endregion

        #region Operating System
        /// <summary>
        /// Using Scout, acquire information about the Operating System </summary>
        private void Button_OS1_Click(object sender, EventArgs e)
        {
            // The process of gathering Operating System information can take up to a 
            // few seconds. To prevent locking up the User Interface, the retrieval
            // of this information is performed using a thread.
            Thread getOSInfo = new Thread(new ThreadStart(this.OSInfo));
            getOSInfo.Name = "GetApiFileInfoThread";
            getOSInfo.Priority = ThreadPriority.Normal;
            getOSInfo.Start();
        }

        /// <summary> (WMI specific)
        /// Using Scout, acquire information about the Operating System </summary>
        private void Button_OS2_Click(object sender, EventArgs e)
        {
            string temp_ClassPropertiesAndValues = string.Empty;

            // Access individual properties
            TextBox_OS2Caption.Text = Okuma.Scout.OS.WMI_Win32OS.Caption;

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
            TextBox_OS2WMI.Text = temp_ClassPropertiesAndValues;

        }

        /// <summary> (Version.txt specific)
        /// Using Scout, acquire information about the Operating System </summary>
        private void Button_OS3_Click(object sender, EventArgs e)
        {
            this.PostResult(this.TextBox_OSVersionTitle, Okuma.Scout.OS.VersionTitle);
            this.PostResult(this.TextBox_OSVersionComment, Okuma.Scout.OS.VersionComment);
            this.PostResult(this.TextBox_OSVersionConfigDate, Okuma.Scout.OS.VersionConfigDate);
            this.PostResult(this.TextBox_OSVersionConfigVersion, Okuma.Scout.OS.VersionConfigVersion);
            this.PostResult(this.TextBox_OSVersionLanguage, Okuma.Scout.OS.VersionLanguage);
            this.PostResult(this.TextBox_OSVersionTarget, Okuma.Scout.OS.VersionTarget);
        }

        /// <summary>
        /// Using Scout, acquire information about the Operating System.
        /// Runs on a separate thread started by the <see cref="Button_OS1_Click"/> method.
        /// </summary>
        private void OSInfo()
        {
            this.PostResult(this.TextBox_OSName, Okuma.Scout.OS.Name);
            this.PostResult(this.TextBox_OSEdition, Okuma.Scout.OS.Edition);
            this.PostResult(this.TextBox_OSServicePack, Okuma.Scout.OS.ServicePack);
            this.PostResult(this.TextBox_OSVersion, Okuma.Scout.OS.Version.ToString());
            this.PostResult(this.TextBox_OSProcessorBits, Okuma.Scout.OS.ProcessorBits.ToString());
            this.PostResult(this.TextBox_OSBits, Okuma.Scout.OS.OSBits.ToString());
            this.PostResult(this.TextBox_OSInternet, Okuma.Scout.OS.InternetConnection.ToString());
            this.PostResult(this.TextBox_EnvUserPermissions, Okuma.Scout.OS.GetAccessLevel().ToString());

            this.PostResult(this.TextBox_EnvMachineName, Environment.MachineName);
            this.PostResult(this.TextBox_EnvOSVer, Environment.OSVersion.ToString());
            this.PostResult(this.TextBox_EnvProcessorCount, Environment.ProcessorCount.ToString());
            this.PostResult(this.TextBox_EnvUserName, Environment.UserName);
            this.PostResult(this.TextBox_EnvUserDomain, Environment.UserDomainName);           
        }
        #endregion

        #region Registry

        /// <summary>
        /// Populates the SubKeys DataGridView with results based 
        /// on the user's input from 'TextBox_RegKey'
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_Registry_Click(object sender, EventArgs e)
        {
            bool ItemsAdded = false;

            // Clear the list before starting
            SubkeysBindingList.Clear();

            // Get the base key from user input
            string basekey = TextBox_RegKey.Text;

            // Initialize results output for Reg.RegistryGetSubKeyNames() 
            string DisplayName = string.Empty;

            // Initialize results output for Reg.RegistryGetLocalMachineValue()
            List<string> SubkeysList = new List<string>();

            // Only modify / add items to the binding list if sub-keys exist under the specified base key
            if (Okuma.Scout.Reg.RegistryGetSubKeyNames(basekey, out SubkeysList))
            {
                // Iterate through the output results
                foreach (string subkey in SubkeysList)
                {
                    // Combine the base key and sub key to check for a value
                    // Do not escape the string literal or extra slashes will be added (for example: @"\\") 
                    string newkey = basekey + "\\" + subkey;

                    // For the purpose of filling the DataGridView, the value "DisplayName" is explicitly specified
                    if (Okuma.Scout.Reg.RegistryGetLocalMachineValue(newkey, "DisplayName", out DisplayName))
                    {
                        // If a Value for "DisplayName" exists under the new key, add it to the binding list
                        SubkeysBindingList.Add(new Subkeys(DisplayName, subkey));
                        ItemsAdded = true;
                    }
                    else
                    {
                        // Otherwise, leave it blank and just add the sub-key
                        SubkeysBindingList.Add(new Subkeys(string.Empty, subkey));
                        ItemsAdded = true;
                    }
                }
            }

            // Resize the DataGridView columns (default is 50/50 [Fill])
            if (ItemsAdded)
            {
                BackingInstanceForDataGridView_SubKeys.Columns[0].Width = 200;
            }
        }

        /// <summary>
        /// Populates the "Exist" and "Data" text boxes based on the Key in the
        /// selected DataGridView row and the value specified in 'TextBox_RegValue'.
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_GetRegValue_Click(object sender, EventArgs e)
        {
            string Key = string.Empty;
            string ValueResult = string.Empty;


            if (BackingInstanceForDataGridView_SubKeys.SelectedCells.Count > 0)
            {
                // Figure out which row of the DGV is selected
                int selectedrowindex = BackingInstanceForDataGridView_SubKeys.SelectedCells[0].RowIndex;

                // Get the Key value from the selected DGV row (second column = Cells[1])
                Key = BackingInstanceForDataGridView_SubKeys.Rows[selectedrowindex].Cells[1].Value.ToString();

                if (!String.IsNullOrEmpty(Key))
                {
                    // The Key is valid
                    ResultBox_RegValueExist.Text = "True";

                    // Combine the base key and sub key to check for a value
                    // Do not escape the string literal or extra slashes will be added (for example: @"\\") 
                    string FullKey = TextBox_RegKey.Text + "\\" + Key;

                    // Get the DATA from the desired VALUE in the specified KEY
                    if (Okuma.Scout.Reg.RegistryGetLocalMachineValue(FullKey, TextBox_RegValue.Text, out ValueResult))
                    {
                        // RegistryGetLocalMachineValue() returned TRUE, meaning data was obtained.
                        ResultBox_RegData.Text = ValueResult;

                        // If the registry value is "Version", parse the result to a version number.
                        if (TextBox_RegValue.Text == "Version")
                        {
                            ResultBox_RegVersion.Text = Okuma.Scout.Helper.RegDwordIntegerVersionParse(ValueResult).ToString();
                            label155.Enabled = true;
                            ResultBox_RegVersion.Enabled = true;
                        }
                        else
                        {
                            ResultBox_RegVersion.Text = string.Empty;
                            label155.Enabled = false;
                            ResultBox_RegVersion.Enabled = false;
                        }
                    }
                    else
                    {
                        // A value was not returned
                        ResultBox_RegValueExist.Text = "False";
                        ResultBox_RegData.Text = "";

                        ResultBox_RegVersion.Text = string.Empty;
                        label155.Enabled = false;
                        ResultBox_RegVersion.Enabled = false;
                    }
                }
                else
                {
                    // There is no key specified
                    ResultBox_RegValueExist.Text = "False";
                    ResultBox_RegData.Text = "";

                    ResultBox_RegVersion.Text = string.Empty;
                    label155.Enabled = false;
                    ResultBox_RegVersion.Enabled = false;
                }
            }
            else
            {
                // There are no selected rows in the DGV (no key to query)
                ResultBox_RegValueExist.Text = "n/a";
                ResultBox_RegData.Text = "nothing selected";

                ResultBox_RegVersion.Text = string.Empty;
                label155.Enabled = false;
                ResultBox_RegVersion.Enabled = false;
            }
        }

        #endregion

        #region Misc

        /// <summary>
        /// This function resolves cross-threading issues by invoking the 
        /// GUI thread to change text box contents </summary>
        /// <remarks>Used under several different tabs; this is a "general" method. </remarks>
        /// <param name="tb">Text box object to modify</param>
        /// <param name="r">New string to pass to the text box</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Exceptions are reported via the Error Handling Tab.")]
        private void PostResult(TextBox tb, string r)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        tb.Text = r;
                    });
                }
                else
                {
                    tb.Text = r;
                }
            }
            catch (Exception ex)
            {
                Okuma.Scout.Error.Args args = new Okuma.Scout.Error.Args(Okuma.Scout.Enums.MessageLevel.Exception, string.Empty, ex);
                this.HandleScoutErrorInfo(null, args);
            }
        }
        #endregion

        #region GAC (Global Assembly Cache)

        public void DisplayClrVersions()
        {
            Label_A.Text = String.Format("CLR version from {0}: {1}",
                System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location),
                Environment.Version);
        }

        private void Button_ExecuteFindInGAC_Click(object sender, EventArgs e)
        {

            List<System.Reflection.AssemblyName> AssemblyNames =
                Okuma.Scout.AccessGAC.QueryGAC(TextBox_AssemblyName.Text);

            if (AssemblyNames.Count > 0)
            {
                foreach (System.Reflection.AssemblyName a in AssemblyNames)
                {
                    if (a != null)
                    {
                        // Note: Culture seems to always be String.Empty
                        //       Flags seem to always be 'None'?
                        textBox1.Text +=
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
                textBox1.Text += "Assembly Alias \"" + TextBox_AssemblyName.Text + "\" not found in GAC." + Environment.NewLine;
            }
            textBox1.Text += "==================================================" + Environment.NewLine;
        }

        private void Button_Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }






        #endregion
    }
}