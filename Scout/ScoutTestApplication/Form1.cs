//-----------------------------------------------------------------------
// <copyright file="Form1.cs" company="Okuma America Corporation">
//     Copyright© 2016 Okuma America Corporation
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

namespace ScoutTestApplication
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using System.Threading; 
    using System.Windows.Forms;

    /// <summary>
    /// Scout Test Application class </summary>
    public partial class ScoutTestApplicationForm : Form
    {
        /// <summary>Used to prevent unnecessary repeat checks of ready status</summary>
        private bool apiHasBeenInitializedOrIsReady = false;

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

        /// <summary>
        /// Return just the date and format as string if the license expires, otherwise return "N/A" </summary>
        /// <param name="expires">Boolean value Okuma.Scout.LicenseItem.Expires </param>
        /// <param name="expireDate">DateTime Okuma.Scout.LicenseItem.ExpiryDate </param>
        /// <returns>type string</returns>
        private static string FormatExpireDate(bool expires, DateTime expireDate)
        {
            if (expires)
            {
                return expireDate.ToString("dd/MM/yyyy");
            }
            else
            {
                return "N/A";
            }
        }

        /// <summary>
        /// Using Scout, acquire the machine type and control type </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_Platform_Click(object sender, EventArgs e)
        {
            // This is where the machine and control type are determined.
            Okuma.Scout.Enums.MachineType currentMachine = Okuma.Scout.Platform.Machine;
            Okuma.Scout.Enums.ControlType currentControl = Okuma.Scout.Platform.Control;

            // The enum values for machine type can be cryptic ("PCNCM_M" for example..)
            // ConvertToMachineTypeString() returns a human readable version.
            this.TextBox_MachineType.Text = Okuma.Scout.Platform.ConvertToMachineTypeString(currentMachine);
            this.TextBox_ControlType.Text = currentControl.ToString();
        }

        /// <summary>
        /// Using Scout, acquire the existence of system directories
        /// </summary>
        /// <param name="sender">Object which created the event</param>
        /// <param name="e">Event arguments</param>
        private void Button_Directories_Click(object sender, EventArgs e)
        {
            // Returns type bool, converted to string for display in text box
            this.TextBox_DirOsp.Text = Okuma.Scout.OspFileInfo.DirExists_OSP.ToString();
            this.TextBox_DirCns.Text = Okuma.Scout.OspFileInfo.DirExists_CNS.ToString();
            this.TextBox_DirVolante.Text = Okuma.Scout.OspFileInfo.DirExists_VOLANTE.ToString();
            this.TextBox_DirCrad.Text = Okuma.Scout.OspFileInfo.DirExists_CRAD.ToString();
            this.TextBox_DirOkuma.Text = Okuma.Scout.OspFileInfo.DirExists_Okuma.ToString();

            this.TextBox_DirCurrent.Text = Environment.CurrentDirectory;
            this.TextBox_DirSystem.Text = Environment.SystemDirectory;                
        }

        /// <summary>
        /// Using Scout, acquire information about the API
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_ApiInfo_Click(object sender, EventArgs e)
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
            this.TextBox_ThincLatheCommandApi.Text = Okuma.Scout.ThincApi.CommandApiExistInGAC_Lathe.ToString();
            this.TextBox_ThincLatheDataApi.Text = Okuma.Scout.ThincApi.DataApiExistInGAC_Lathe.ToString();
            this.TextBox_ThincMachiningCenterCommandApi.Text = Okuma.Scout.ThincApi.CommandApiExistInGAC_MachiningCenter.ToString();
            this.TextBox_ThincMachiningCenterDataApi.Text = Okuma.Scout.ThincApi.DataApiExistInGAC_MachiningCenter.ToString();
            this.TextBox_FlexNet.Text = Okuma.Scout.ThincApi.FlexNetExistInGAC.ToString();

            // THINC API Installed Library Versions
            this.TextBox_ThincLatheCommandApiVer.Text = Okuma.Scout.ThincApi.CommandApiVersionInGAC_Lathe;
            this.TextBox_ThincLatheDataApiVer.Text = Okuma.Scout.ThincApi.DataApiVersionInGAC_Lathe;
            this.TextBox_ThincMachiningCenterCommandApiVer.Text = Okuma.Scout.ThincApi.CommandApiVersionInGAC_MachiningCenter;
            this.TextBox_ThincMachiningCenterDataApiVer.Text = Okuma.Scout.ThincApi.DataApiVersionInGAC_MachiningCenter;
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
            Okuma.Scout.Enums.ApiStatus status = Okuma.Scout.ThincApi.InitAPI();
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
             * references to your project. That is the reccomended method to use the THINC API. 
             */
            this.TextBox_ApiMachineName.Text = Okuma.Scout.ThincApi.MachineName();
            this.TextBox_ApiSerialNumber.Text = Okuma.Scout.ThincApi.SerialNumber();
            this.TextBox_ApiCV1.Text = Okuma.Scout.ThincApi.GetCommonVariable(1).ToString();
        }

        /// <summary>
        /// Using Scout, acquire information about Okuma system files
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_FileInfo_Click(object sender, EventArgs e)
        {
            // Misc Files Exist
            this.TextBox_DMC.Text = Okuma.Scout.OspFileInfo.DMCExists.ToString();
            this.TextBox_ThincApiLicense.Text = Okuma.Scout.OspFileInfo.ThincApiLicenseExists.ToString();
            this.TextBox_EbiFry.Text = Okuma.Scout.OspFileInfo.EbyFryExists.ToString();
            this.TextBox_ApiNotifier.Text = Okuma.Scout.OspFileInfo.ApiNotifierExists.ToString();
            this.TextBox_EbiFryVer.Text = Okuma.Scout.OspFileInfo.EbiFryVersion;
            this.TextBox_ApiNotifierVer.Text = Okuma.Scout.OspFileInfo.ApiNotifierVersion;
            this.TextBox_SoftSwitch.Text = Okuma.Scout.OspFileInfo.SoftSwitchExists.ToString();
            this.TextBox_SoftSwitchVer.Text = Okuma.Scout.OspFileInfo.SoftSwitchVersion;

            // Modified
            this.TextBox_DMCModified.Text = Okuma.Scout.OspFileInfo.DMCModifiedDate;
            this.TextBox_ThincApiLicenseModified.Text = Okuma.Scout.OspFileInfo.ThincApiLicenseModifiedDate;

            // OSP API Files Exist
            // The process of gathering all API files information can take up to a 
            // few seconds. To prevent locking up the User Interface, the retreival
            // of this information is performed using a thread.
            Thread getApiFilesInfo = new Thread(new ThreadStart(this.ApiFiles));
            getApiFilesInfo.Name = "GetApiFileInfoThread";
            getApiFilesInfo.Priority = ThreadPriority.Normal;
            getApiFilesInfo.Start();
        }        

        /// <summary>
        /// Using Scout, acquire information related to API files.
        /// Runs on a separate thread started by the <see cref="Button_FileInfo_Click"/> method.
        /// </summary>
        private void ApiFiles()
        {
            string tempString = string.Empty;

            // Lathe Files Exist?
            // Returns type bool, converted to string for display in text box
            tempString = Okuma.Scout.OspFileInfo.OspLatheSpecialApi_Exists.ToString();
            this.PostResult(this.TextBox_OspLatheSpecialApi, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspLatheCommandApi_Exists.ToString();
            this.PostResult(this.TextBox_OspLatheCommandApi, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspLatheDataApi_Exists.ToString();
            this.PostResult(this.TextBox_OspLatheDataApi, tempString);

            // Machining Center Files Exist?
            // Returns type bool, converted to string for display in text box
            tempString = Okuma.Scout.OspFileInfo.OspMachiningCenterSpecialApi_Exists.ToString();
            this.PostResult(this.TextBox_OspMachiningCenterSpecialApi, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspMachiningCenterCommandApi_Exists.ToString();
            this.PostResult(this.TextBox_OspMachiningCenterCommandApi, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspMachiningCenterDataApi_Exists.ToString();
            this.PostResult(this.TextBox_OspMachiningCenterDataApi, tempString);

            // Lathe File Versions
            // Returns type string
            tempString = Okuma.Scout.OspFileInfo.OspLatheSpecialApi_Version;
            this.PostResult(this.TextBox_OspLatheSpecialApiVer, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspLatheCommandApi_Version;
            this.PostResult(this.TextBox_OspLatheCommandApiVer, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspLatheDataApi_Version;
            this.PostResult(this.TextBox_OspLatheDataApiVer, tempString);

            // Maching Center File Versions
            // Returns type string
            tempString = Okuma.Scout.OspFileInfo.OspMachiningCenterSpecialApi_Version;
            this.PostResult(this.TextBox_OspMachiningCenterSpecialApiVer, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspMachiningCenterCommandApi_Version;
            this.PostResult(this.TextBox_OspMachiningCenterCommandApiVer, tempString);
            tempString = Okuma.Scout.OspFileInfo.OspMachiningCenterDataApi_Version;
            this.PostResult(this.TextBox_OspMachiningCenterDataApiVer, tempString);

            // Spec Code Files Exist?
            tempString = Okuma.Scout.SpecCode.PLC_SpecCodeFileExists.ToString();
            this.PostResult(this.TextBox_PLCSpecFileExist, tempString);
            tempString = Okuma.Scout.SpecCode.NC_SpecCodeFileExists.ToString();
            this.PostResult(this.TextBox_NCSpecFileExist, tempString);
            tempString = Okuma.Scout.SpecCode.NCB_SpecCodeFileExists.ToString();
            this.PostResult(this.TextBox_NCBSpecFileExist, tempString);  
        }

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

        /// <summary>
        /// Using Scout, acquire information from the Data Management Card
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_DMC_Click(object sender, EventArgs e)
        {
            // The process of gathering all Data Management Card Items can take up to a 
            // few seconds. To prevent locking up the User Interface, the retreival
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
            this.PostItem("NC Control Msg.: " + Okuma.Scout.DMC.NcControlMsg);
            this.PostItem("PLC System: " + Okuma.Scout.DMC.PLCSystem);
            this.PostItem("PLC System Message: " + Okuma.Scout.DMC.PLCSystemMsg);
            this.PostItem("NC Alarm Help: " + Okuma.Scout.DMC.NcAlarmHelp);
            this.PostItem("NC Manual: " + Okuma.Scout.DMC.NcManual);
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
            this.PostItem("One Touch Spreadsheet Preinstall Contents: " + Okuma.Scout.DMC.OTSPreInst);
            this.PostItem("IT Plaza Application Common: " + Okuma.Scout.DMC.ITPlaza);
            this.PostItem("Collision Avoidance System: " + Okuma.Scout.DMC.CAS);
            this.PostItem("Easy Modeling: " + Okuma.Scout.DMC.EasyModel);
            this.PostItem("Custom API: " + Okuma.Scout.DMC.CustAPI);
        }

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
            this.TextBox_Net46.Text = Okuma.Scout.DotNet.v46Preview_Installed.ToString();

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
            this.TextBox_License_LDATAPI_ExpireDate.Text = FormatExpireDate(dataApiLathe.Expires, dataApiLathe.ExpiryDate);
            this.TextBox_License_LDATAPI_Status.Text = dataApiLathe.Status.ToString();            

            // Data API License (Machining Center):
            Okuma.Scout.LicenseItem dataApiMachiningCenter = Okuma.Scout.LicenseChecker.License_DataApi_MC;
            this.TextBox_License_MDATAPI_FeatureName.Text = dataApiMachiningCenter.Feature;
            this.TextBox_License_MDATAPI_Version.Text = dataApiMachiningCenter.Version;
            this.TextBox_License_MDATAPI_Expires.Text = dataApiMachiningCenter.Expires.ToString();
            this.TextBox_License_MDATAPI_ExpireDate.Text = FormatExpireDate(dataApiMachiningCenter.Expires, dataApiMachiningCenter.ExpiryDate);
            this.TextBox_License_MDATAPI_Status.Text = dataApiMachiningCenter.Status.ToString();

            // Command API License (Lathe):
            Okuma.Scout.LicenseItem commandApiLathe = Okuma.Scout.LicenseChecker.License_CommandApi_L;
            this.TextBox_License_LCMDAPI_FeatureName.Text = commandApiLathe.Feature;
            this.TextBox_License_LCMDAPI_Version.Text = commandApiLathe.Version;
            this.TextBox_License_LCMDAPI_Expires.Text = commandApiLathe.Expires.ToString();
            this.TextBox_License_LCMDAPI_ExpireDate.Text = FormatExpireDate(commandApiLathe.Expires, commandApiLathe.ExpiryDate);
            this.TextBox_License_LCMDAPI_Status.Text = commandApiLathe.Status.ToString();

            // Command API License (Machining Center):
            Okuma.Scout.LicenseItem commandApiMachiningCenter = Okuma.Scout.LicenseChecker.License_CommandApi_MC;
            this.TextBox_License_MCMDAPI_FeatureName.Text = commandApiMachiningCenter.Feature;
            this.TextBox_License_MCMDAPI_Version.Text = commandApiMachiningCenter.Version;
            this.TextBox_License_MCMDAPI_Expires.Text = commandApiMachiningCenter.Expires.ToString();
            this.TextBox_License_MCMDAPI_ExpireDate.Text = FormatExpireDate(commandApiMachiningCenter.Expires, commandApiMachiningCenter.ExpiryDate);
            this.TextBox_License_MCMDAPI_Status.Text = commandApiMachiningCenter.Status.ToString();

            // THINC Control Type P200 License:
            Okuma.Scout.LicenseItem p200Control = Okuma.Scout.LicenseChecker.License_ControlTypeP200;
            this.TextBox_License_P200_FeatureName.Text = p200Control.Feature;
            this.TextBox_License_P200_Version.Text = p200Control.Version;
            this.TextBox_License_P200_Expires.Text = p200Control.Expires.ToString();
            this.TextBox_License_P200_ExpireDate.Text = FormatExpireDate(p200Control.Expires, p200Control.ExpiryDate);
            this.TextBox_License_P200_Status.Text = p200Control.Status.ToString();

            // NC Current Alarm Option License:
            Okuma.Scout.LicenseItem numericalControlCurrentAlarm = Okuma.Scout.LicenseChecker.License_NcCurrentAlarm;
            this.TextBox_License_NcCurrentAlarm_FeatureName.Text = numericalControlCurrentAlarm.Feature;
            this.TextBox_License_NcCurrentAlarm_Version.Text = numericalControlCurrentAlarm.Version;
            this.TextBox_License_NcCurrentAlarm_Expires.Text = numericalControlCurrentAlarm.Expires.ToString();
            this.TextBox_License_NcCurrentAlarm_ExpireDate.Text = FormatExpireDate(numericalControlCurrentAlarm.Expires, numericalControlCurrentAlarm.ExpiryDate);
            this.TextBox_License_NcCurrentAlarm_Status.Text = numericalControlCurrentAlarm.Status.ToString();

            // User Task I/O Lathe Option License:
            Okuma.Scout.LicenseItem userTaskIOLathe = Okuma.Scout.LicenseChecker.License_UserTaskIO_L;
            this.TextBox_License_UserTaskIOL_FeatureName.Text = userTaskIOLathe.Feature;
            this.TextBox_License_UserTaskIOL_Version.Text = userTaskIOLathe.Version;
            this.TextBox_License_UserTaskIOL_Expires.Text = userTaskIOLathe.Expires.ToString();
            this.TextBox_License_UserTaskIOL_ExpireDate.Text = FormatExpireDate(userTaskIOLathe.Expires, userTaskIOLathe.ExpiryDate);
            this.TextBox_License_UserTaskIOL_Status.Text = userTaskIOLathe.Status.ToString();

            // User Task I/O Machining Center Option License:
            Okuma.Scout.LicenseItem userTaskIOMachiningCenter = Okuma.Scout.LicenseChecker.License_UserTaskIO_MC;
            this.TextBox_License_UserTaskIOMC_FeatureName.Text = userTaskIOMachiningCenter.Feature;
            this.TextBox_License_UserTaskIOMC_Version.Text = userTaskIOMachiningCenter.Version;
            this.TextBox_License_UserTaskIOMC_Expires.Text = userTaskIOMachiningCenter.Expires.ToString();
            this.TextBox_License_UserTaskIOMC_ExpireDate.Text = FormatExpireDate(userTaskIOMachiningCenter.Expires, userTaskIOMachiningCenter.ExpiryDate);
            this.TextBox_License_UserTaskIOMC_Status.Text = userTaskIOMachiningCenter.Status.ToString();

            // User Alarm Lathe Option License:
            Okuma.Scout.LicenseItem userAlarmLathe = Okuma.Scout.LicenseChecker.License_UserAlarm_L;
            this.TextBox_License_UserAlarmL_FeatureName.Text = userAlarmLathe.Feature;
            this.TextBox_License_UserAlarmL_Version.Text = userAlarmLathe.Version;
            this.TextBox_License_UserAlarmL_Expires.Text = userAlarmLathe.Expires.ToString();
            this.TextBox_License_UserAlarmL_ExpireDate.Text = FormatExpireDate(userAlarmLathe.Expires, userAlarmLathe.ExpiryDate);
            this.TextBox_License_UserAlarmL_Status.Text = userAlarmLathe.Status.ToString();

            // User Alarm Machining Center Option License:
            Okuma.Scout.LicenseItem userAlarmMachiningCenter = Okuma.Scout.LicenseChecker.License_UserAlarm_MC;
            this.TextBox_License_UserAlarmMC_FeatureName.Text = userAlarmMachiningCenter.Feature;
            this.TextBox_License_UserAlarmMC_Version.Text = userAlarmMachiningCenter.Version;
            this.TextBox_License_UserAlarmMC_Expires.Text = userAlarmMachiningCenter.Expires.ToString();
            this.TextBox_License_UserAlarmMC_ExpireDate.Text = FormatExpireDate(userAlarmMachiningCenter.Expires, userAlarmMachiningCenter.ExpiryDate);
            this.TextBox_License_UserAlarmMC_Status.Text = userAlarmMachiningCenter.Status.ToString();

            // 8 Digit Tool ID Machining Center Option License:
            Okuma.Scout.LicenseItem toolID = Okuma.Scout.LicenseChecker.License_ToolID_MC;
            this.TextBox_License_ToolId_FeatureName.Text = toolID.Feature;
            this.TextBox_License_ToolId_Version.Text = toolID.Version;
            this.TextBox_License_ToolId_Expires.Text = toolID.Expires.ToString();
            this.TextBox_License_ToolId_ExpireDate.Text = FormatExpireDate(toolID.Expires, toolID.ExpiryDate);
            this.TextBox_License_ToolId_Status.Text = toolID.Status.ToString();
        }

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
            this.TextBox_AssemblyVersion.Text = Okuma.Scout.ProgramInfo.AssemblyVersion;
            this.TextBox_AssemblyCopyright.Text = Okuma.Scout.ProgramInfo.AssemblyCopyright;
            this.TextBox_AssemblyCompany.Text = Okuma.Scout.ProgramInfo.AssemblyCompany;
            this.TextBox_AssemblyDescription.Text = Okuma.Scout.ProgramInfo.AssemblyDescription;
            this.TextBox_AssemblyBuildDate.Text = Okuma.Scout.ProgramInfo.AssemblyBuildDate.ToString();

            // Slightly misleading, but this function is found in the Operating System class.
            // It reports the "bitness" of the currently executing program, hence it is under the Program tab.
            this.TextBox_ProgramBits.Text = Okuma.Scout.OS.ProgramBits.ToString();
        }

        /// <summary>
        /// Using Scout, acquire information about the Operating System
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_OS_Click(object sender, EventArgs e)
        {
            // The process of gathering Operating System information can take up to a 
            // few seconds. To prevent locking up the User Interface, the retreival
            // of this information is performed using a thread.
            // Particularily, OS.InternetConnection takes time to obtain a result.
            Thread getOSInfo = new Thread(new ThreadStart(this.OSInfo));
            getOSInfo.Name = "GetApiFileInfoThread";
            getOSInfo.Priority = ThreadPriority.Normal;
            getOSInfo.Start();
        }

        /// <summary>
        /// Using Scout, acquire information about the Operating System.
        /// Runs on a separate thread started by the <see cref="Button_OS_Click"/> method.
        /// </summary>
        private void OSInfo()
        {
            this.PostResult(this.TextBox_OSName, Okuma.Scout.OS.Name);
            this.PostResult(this.TextBox_OSEdition, Okuma.Scout.OS.Edition);
            this.PostResult(this.TextBox_OSServicePack, Okuma.Scout.OS.ServicePack);
            this.PostResult(this.TextBox_OSVersion, Okuma.Scout.OS.Version.ToString());
            this.PostResult(this.TextBox_OSProcessorBits, Okuma.Scout.OS.ProcessorBits.ToString());
            this.PostResult(this.TextBox_OSBits, Okuma.Scout.OS.OSBits.ToString());

            this.PostResult(this.TextBox_OSVersionTitle, Okuma.Scout.OS.VersionTitle);
            this.PostResult(this.TextBox_OSVersionComment, Okuma.Scout.OS.VersionComment);
            this.PostResult(this.TextBox_OSVersionConfigDate, Okuma.Scout.OS.VersionConfigDate);
            this.PostResult(this.TextBox_OSVersionConfigVersion, Okuma.Scout.OS.VersionConfigVersion);
            this.PostResult(this.TextBox_OSVersionLanguage, Okuma.Scout.OS.VersionLanguage);
            this.PostResult(this.TextBox_OSVersionTarget, Okuma.Scout.OS.VersionTarget);

            this.PostResult(this.TextBox_EnvMachineName, Environment.MachineName);
            this.PostResult(this.TextBox_EnvOSVer, Environment.OSVersion.ToString());
            this.PostResult(this.TextBox_EnvProcessorCount, Environment.ProcessorCount.ToString());
            this.PostResult(this.TextBox_EnvUserName, Environment.UserName);
            this.PostResult(this.TextBox_EnvUserDomain, Environment.UserDomainName);

            // Do this last, as it takes the most time.
            this.PostResult(this.TextBox_OSInternet, Okuma.Scout.OS.InternetConnection.ToString());
        }

        /// <summary>
        /// Using Scout, acquire information about the machine specifications
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_SpecCodes_Click(object sender, EventArgs e)
        {
            this.TextBox_SpecMachineType.Text = Okuma.Scout.SpecCode.MachineType;
            this.TextBox_SpecMachineType_DMC.Text = Okuma.Scout.DMC.MachineType;

            this.TextBox_PLCSpec1A.Text = Okuma.Scout.SpecCode.PLC1A;
            this.TextBox_PLCSpec1B.Text = Okuma.Scout.SpecCode.PLC1B;
            this.TextBox_PLCSpec2A.Text = Okuma.Scout.SpecCode.PLC2A;
            this.TextBox_PLCSpec2B.Text = Okuma.Scout.SpecCode.PLC2B;
            this.TextBox_NCSpecA.Text = Okuma.Scout.SpecCode.NCA;
            this.TextBox_NCSpecB.Text = Okuma.Scout.SpecCode.NCB;
            this.TextBox_NCBSpecA.Text = Okuma.Scout.SpecCode.NCBA;
            this.TextBox_NCBSpecB.Text = Okuma.Scout.SpecCode.NCBB;

            this.TextBox_PLCSpec1A_DMC.Text = Okuma.Scout.SpecCode.PLC1A_DMC;
            this.TextBox_PLCSpec1B_DMC.Text = Okuma.Scout.SpecCode.PLC1B_DMC;
            this.TextBox_PLCSpec2A_DMC.Text = Okuma.Scout.SpecCode.PLC2A_DMC;
            this.TextBox_PLCSpec2B_DMC.Text = Okuma.Scout.SpecCode.PLC2B_DMC;
            this.TextBox_NCSpecA_DMC.Text = Okuma.Scout.SpecCode.NCA_DMC;
            this.TextBox_NCSpecB_DMC.Text = Okuma.Scout.SpecCode.NCB_DMC;
            this.TextBox_NCBSpecA_DMC.Text = Okuma.Scout.SpecCode.NCBA_DMC;
            this.TextBox_NCBSpecB_DMC.Text = Okuma.Scout.SpecCode.NCBB_DMC;

            this.TextBox_PLCSpec1A_Match.Text = Okuma.Scout.SpecCode.Match_PLC1A;
            this.TextBox_PLCSpec1B_Match.Text = Okuma.Scout.SpecCode.Match_PLC1B;
            this.TextBox_PLCSpec2A_Match.Text = Okuma.Scout.SpecCode.Match_PLC2A;
            this.TextBox_PLCSpec2B_Match.Text = Okuma.Scout.SpecCode.Match_PLC2B;
            this.TextBox_NCSpecA_Match.Text = Okuma.Scout.SpecCode.Match_NCA;
            this.TextBox_NCSpecB_Match.Text = Okuma.Scout.SpecCode.Match_NCB;
            this.TextBox_NCBSpecA_Match.Text = Okuma.Scout.SpecCode.Match_NCBA;
            this.TextBox_NCBSpecB_Match.Text = Okuma.Scout.SpecCode.Match_NCBB;
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

        /// <summary>
        /// This function resolves cross-threading issues by invoking the 
        /// GUI thread to change text box contents </summary>
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
                Okuma.Scout.Error.Args args = new Okuma.Scout.Error.Args(Okuma.Scout.Enums.MessageLevel.Exception, string.Empty, ex);
                this.HandleScoutErrorInfo(null, args);
            }
        }
    }
}