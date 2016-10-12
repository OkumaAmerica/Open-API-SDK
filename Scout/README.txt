# SCOUT CHANGE LOG README #

* Last Compile date: 10/10/2016
* SCOUT Application      - Version 2.10.0.0
* SCOUT Test Application - Version 2.2.0.0
* Okuma.Scout.dll        - Version 2.2.0.0
* Okuma.Scout.Com.dll    - Version 1.0.0.0


##[ NOTES ]##
> #### ► About COM library: ####
>
>  * If the following classes accessed, Okuma.Scout.Com.dll must be deployed with Okuma.Scout.dll
>    1. COM_InterfaceImplementation
>    2. LicenseChecker
>    3. AccessGAC
>
>  * Okuma.Scout.Com.dll is accessed by the main SCOUT library by means of [Registration-Free COM Interop](https://msdn.microsoft.com/en-us/library/fh1h056h(v=vs.110).aspx), which requires the use of manifest files.
>  * Any executable that will use the COM library must have a manifest file that declares Okuma.Scout.Com as a dependant assembly. Please refer to the sample application. 
>  * While developing an application which uses SCOUT, you ####MUST#### disable the Visual Studio Hosting Process! Failure to do so will result in File Not Found exceptions as a result of the hosting process executable not matching the manifest file for the application.


► Only .NET versions are checked in command-line 'native' C++ 
     code (with no .NET requirement). The bulk of SCOUT is 
     contained in Scout.exe which is unpacked and ran 
     if .NET 2 or later is found.

► Due to the differences in Data Management Cards on older OSP controls,
     the output from them may contain little or poorly formatted data.
     This does not affect compatibility results.


### Contact Information ###

* For general programming questions related to Okuma products, we recommend asking your question on stackoverflow.com with the tag "okuma".  
 Refer to the following link to view all Okuma questions:  
http://stackoverflow.com/questions/tagged/okuma?sort=newest&pageSize=50  
* For detailed, specific, or bug related questions, please email your question to API@Okuma.com


##[ KEY ]##
	  [中] = SCOUT Library
	  [本] = SCOUT Application
	  [全] = Library　and Application (whole project)
	  [■] = Fully implemented
	  [♦] = Implemented, not tested
	  [◊] = New request
	  [‡] = Not implemented request; will not add 


#[ CHANGE LOG ]#
►　[ 2016-10-10 / Release 2.10.0.0  / SS ]

  * [本■] Added support for the following apps:
    * MTConnect Agent & Adapter v2.2.5
    * TrakHound Community v1.2.15
    * GO Macro Interface v1.2.7
    * GO Panel Mode v1.2.2
    * Gosiger Program Scheduler v0.1.3
    * Kitagawa Digital Grip Force Meter v1.0
    * Gosiger IFTTT
    * (Removed) Machining Cloud
    * (Removed) MTConnect Agent & Adapter versions 2.1 and 2.2.2

  * [全♦] Preliminary support for P300A Type Controls

  * [全■] Report Grinder API file information 

  * [全■] Report P300A Touch driver information

  * [本■] Report User Permissions (User, Administrator, Guest, etc.)

  * [本■] Fixed compatibility reporting scenario where THINC API is installed, apps report that they are compatible, and yet CAPI Spec is not enabled

  * [本■] Changed compatibility note for Gosiger View Control (compatibility restriction is related to Panel Size, not control type)

  * [本■] Fixed a bug that prevented THINC Startup Service version from being found compatible with required versions

  * [中■] *NEW* Okuma.Scout.Com.dll - COM library that allows SCOUT to access .NET CLR4 to support TAPI 1.19(dev)

  * [中■] Re-wrote the Machine Type detection routine for improved accuracy under various conditions

  * [中■] Re-wrote the Control Type detection routine for improved accuracy under various conditions

  * [中■] ApiVersionCrossRef.xml updated to detect CAPI v001A(Grinder), CAPI v003S(Lathe), and TAPI v1.19.0.0 (SCOUT Library Version up to v2.2.0.0)
  
  * [中■] Fixed an issue with registry key & value queries on 64-bit systems which limited the results returned 

  * [中■] Fixed an issue that prevented P100-II from being correctly Identified

  * [中■] Added HRESULT coercing to Windows string messages for registry access errors

  * [中♦] Update Licensing and GAC access for new TAPI 1.19.0.0 .NET4 libraries

  * [中◊] Instantiate and call methods (machine name, common variable) in TAPI 1.19 (.NET4) reflectively - Currently not possible, will develop.

  * [中■] Fixed a bug where the OSP Panel is not identified correctly on P100 models




►　[ 2016-8-1 / Okuma Open API SDK v0.8 (SCOUT Library v1.0.4.0)  / SS ]

  * [中♦] Preliminary support for P300A

  * [中♦] Preliminary support for Grinder Machine Type and Grinder APIs

  * [中■] Determine User Permissions (Operating System Tab)

  * [中■] Performance of (bool)OS.InternetConnection increased substantially 



►　[ 2016-2-19 / Release v2.0.0.8 / SS ]

  * [本■] Added support for the following apps:
    * GO View Control v16.2.191.0
    * Blum Gauging Guide v1.5.4.0
    * Machining Cloud v2.1.1.314
    * STEP-NC Machine v11.64.0.0



►　[ 2016-2-17 / SS ]

  * [全■] SCOUT Library project merged with SCOUT application repository



►　[ 2016-2-15 / develop / SS ]

  * [中■] Updated Okuma.Scout.dll v1.0.3.0

  * [本♦] Scout_v2.0.0.8.exe now extracts Scout Pack to system temp directory.
    This is done to prevent direct copy and run of Scout Pack on control without .NET



► [ 2016-2-15 / develop / SS ]

  * [本■] Removed escape character from machine name from spec code file return value

  * [本■] DMC Items no longer return page break information (correct data is returned)



► [ 2015-12-16 / Release v2.0.0.7 / SS ]

  * [本■] Added support for the following apps:
    + Elbo Controlli App v1.17.2.0
    * MTConnect Agent v2.2.0.0
    * Machining Cloud v2.0.1.193

  * [本■] Added support for THINC API 1.18.0.0

   * Detection, upgrade recommendation, app compatibility support



► [ 2015-12-15 / SS ] 

  * [中■] API Version Cross Reference updated. 
      * Added detection of CUSTOM API versions 003N and 003R.
      * Added detection of THIC API version 1.18.0.0.

  * [中■] New API License check status added: Invalid Host



► [ 2015-10-20 / Release v2.0.0.6 / SS ]

  * [本■] Added support for the following apps:
      * MTConnect Agent v2.2.0.0



► [ 2015-08-28 / Release v2.0.0.5 / SS ]

  * [本■] Time zone & OS language detection: prompt if time zone is Japan and language is English

  * [本■] MD5 File verification - Drag and drop AppStore downloads into Scout for integrity check

  * [本■] Added support for the following apps:
      + dataZen MIRA LITE 1.0.8
      * Machine Alert v1.4.7
      * OSP Variables Manager 1.1  

  * [本■] Bug fix - Fixed an issue where some 15" panel types were not correctly identified

  * [本♦] Detect 19" Screen Mode (Full, A, B)

  * [本■] Uses updated Okuma.Scout.dll v1.0.1.0 - Refer to Scout library readme for more information



► [ 2015-8-24 / develop / SS ]

  * [中■] Bug Fix - THINC API 1.17.0.0 now identified correctly

  * [中■] Bug Fix - Spec files with lower case file extensions identified correctly



► [ 2015-7-27 / develop / SS ]

  * [中■] Display class now includes "PanelType" property and matching PhysicalPanelSize enumeration

  * [中■] Display class now includes "SelectScreenMode" property and matching NineteenInchScreenMode enumeration



► [ 2015-6-16 / develop / SS ]

  * [中■] Bug Fix - Fixed a bug where THINC API v1.12.1.0 on Machining Center was not correctly identified.



► [ 2015-06-15 / Release v2.0.0.4 / SS ]

  * [本■] Single Instance

  * [本■] Main thread close delegate callback to end GatherInfo thread

  * [本■] Compatibility Results indicate apps that have already been installed

  * [本■] Added support for the following apps:
      + Part Flip Monitor v1.3
      + ABB Robot Studio
      + PartMaker Multi-Channel Viewer v15.0
      * Delcam PartMaker Viewer v8.1.10
      * Scheduled Maintenance v2.0

  * [本■] Add the following data points for each app in the compatibility list:
      * Include a .NET redistributable installer? (assume version included is the required version)
      * Required TSS / OSS version
      * Include TSS / OSS installer (assumes version included is the required version)
      * Details note (developer’s message to display in details page)
      * App Installer Package File Names
      * MD5 hash for app installer packages

  * [本■] Add the following detection capability to SCOUT.dll
      * Determine CAPI version based on OCJ API library versions	
      * TSS / OSS Installed & version
      * Display identification (primarily for determining 15" or 19" panel) 

  * [本■] Add the following Reporting Functions
      * THINC API compatibility report button: informs the user if a new version is available and how to get it. Also reports if there is any issue with the currently installed version and if an NC upgrade is required to get a newer version.
      * Compare SCOUT assembly date to machine date time and report how recently it was updated and if the user should check for a new version (using green, yellow, red indicators and text).
      * Report the latest version of THINC API compatible with the control based on CAPI version
      * Show details note
      * If contain .NET redistributable, ignore that requirement based on the included version and operating system For example: an XP machine + App that contains .Net 4.5 redistributable still won’t be compatible.



► [ 2015-6-15 / develop / SS ]

  * [中■] Created display information reporting in "Platform" tab of Test Program

  * [中■] Bug fix - LicenseItems now correctly display the license item name in the return object when checking a non-existent feature.

  * [中■] Bug fix - 'DetermineCAPIVersion()' now correctly sets 'ApiVersionCheckResult.UnknownVersion' when file version combination does not exist in ApiVersionCrossRef.xml

  * [中■] Fixed syntax error that resulted in skipping the last resort method of detecting Control Type via DMC. 



► [ 2015-6-5 / develop / SS ]

  * [中■] Added class "Okuma.Scout.Display" class to provide information about screens / monitors attached to the system

  * [中■] Added method "Okuma.Scout.Helper.RegDwordIntegerVersionParse()" to convert raw uninstall "Version" data to version objects. 



► [ 2015-5-15 / develop / SS ]

  * [中■] Determine CAPI version based on OCJ API library versions



► [ 2015-5-9 / develop / SS ]

  * [中■] Added class "Okuma.Scout.Reg" and accompanying "Registry" tab in test application. 
    Functions in this class are compatible with 32 & 64 bit systems and .NET 2+.



► [ 2015-03-25 / Release v2.0.0.3 / SS ]

  * [本■] Added support for the following apps:
      + dataZen MIRA LITE V1.0.0.0
      + Okuma MT Connect Agent / Adapter V1.0.0.0

  * [本■] Updated the following App versions
      * Okuma MT Connect Agent / Adapter V2.1.0.0
      * Delcam PartMaker Viewer V7.8.10.02 - changed compatibility to only PC or PC NC-Master due to PC requirements

  * [本■] Okuma.Scout.dll updated to version 1.0.0.3
    Refer to change notes of Scout.dll for details (can be found in the SDK)

  * [本■] Bug fix - 64 bit Operating Systems now detected properly

  * [本■] Bug fix - API Version 1.17.2.0 on Machine Center is now detected properly

  * [本■] Bug fix - Absence of C:\VERSION.txt no longer causes exception

  * [本♦] App compatibility by specific machine model

  * [本‡] Generate list of installed options based on Spec Codes (on hold until further notice)



► [ 2015-3-23 / develop / SS ]

  * [中■] Fixed bug in API identification cross reference file that resulted in not properly detecting API version 1.17.2.0 on Machining Center.

  * [中■] Fixed bug in Operating System module that resulted in incorrect reporting of OS bitness.

  * [中■] Fixed bug where the absence of C:\Version.txt resulted in exception (handled).

  * [中■] Removed Options Identification class and supporting structures.



► [ 2015-2-25 / develop / SS ]

  * [中■] Revamped the way PLC Spec codes are retrieved to allow for user defined files, 
    access to all spec code groups, file type validation, and more!  



► [ 2015-02-24 / develop / SS ]

  * [中■] Changed the way NC & NCB Spec codes are retrieved to allow for user defined files, 
    access to all spec code groups, file type validation, and more.



► [ 2015-02-04 / Release v2.0.0.2 / SS ]

  * [本■] Data collection code has been moved to the new Okuma.Scout.dll library

  * [本■] Added support for the following apps:
      + STEP-NC Machine v11.17.0.0
      + Machine Alert v1.4.6.0

  * [本■] Correction to the requirements for OSP Message v1.0.0.0
     This app is not compatible with the client version of .NET 4.0

  * [本■] Correction to the requirements for dataZen P_LOADER v2.0.0.0
     This app requires .NET 4+ and XP-SP3+

  * [本■] Okuma.Scout.dll is now featured in the Okuma Open API SDK. Future updates to 
     either this application or the Scout library will be reflected in both packages.

  * [本◊] Determine if upgrade of THINC API can be performed 
     without the need for OS or OSP upgrade



► [ 2015-02-02 / develop / SS ]

  * [中■] Added properties for scout.dll version & build date 
    and the calling assembly (sample program for example) version & build date
    The new properties use a more reliable method to obtain the actual build date
    rather than the file modified date.



► [ 2014-11-24 / Release v2.0.0.1 / SS ]

  * [本■] Add support for the following apps:
      + Caron BarCode v1.0.0.0		
      + Renishaw GUI for Lathes [Demo] v1.12.0.0
      + dataZen P-Keyboard v1.0.0.0
      + KennaTechnical LaunchPad v1.0.0.0	

  * [本■] Updated the following App versions
     * Blum Easy Results v1.0.6.0
     * MTConnect Agent v2.0.0.0
     * Visual Assistant Support v1.1.2.0

  * [本■] Corrected requirements for MTConnect Agent 



► [ 2014-11-11 / Release v2.0.0.0 / SS ]

  * [本■] Gathers System Information for comparison with requirements

  * [本■] Reports compatibility for all apps known at time of release

  * [本■] Generates log file in C root

  * [本■] INITIAL APP SUPPORT  
      + Screen Blocker v1.3.0.7
      + AutoComp [DEMO] v1.13.5.0
      + Scheduled Maintenance v1.2.7.0
      + Blum Easy Results v1.0.1.0
      + Blum Gauging Guide v1.4.22.0
      + Coolant Monitor v1.6.3.0
      + dataZen P_LOADER v2.0.0.0
      + dataZen P-SCANNER v1.0.0.0
      + Machine Alert v1.4.5.0
      + Delcam PartMaker Viewer v7.8.10.02
      + Machining Cloud v1.5.1.88
      + NOVO v1.5.1.88
      + MTConnect Agent v1.5.7.0
      + OSP Message v1.0.0.0
      + OSP Alarm Notifier v1.0.0.0
      + OSP Variables Manager v1.0.5.0
      + OSP Widget Manager v1.0.0.0
      + Part Flip Monitor v1.0.1.0
      + Renishaw GUI for Mills [Demo] v1.14.0.0
      + Sandvik Drilling & Tapping Calculator v1.0.6.0
      + Sandvik Milling Calculator v1.0.6.0
      + Sandvik Turning Calculator v1.0.6.0
      + STEP-NC Machine v10.50.0.0 
      + View Control v14.3.28.1
      + Visual Assistance Support v1.0.5.0

  * [本‡] Check for updates / report to Okuma over internet



### Notes ###

The test application includes a debug version and release version of the Scout library  
To create a project using either the debug or release version depending on the compile setting, first include both versions using the same structure as the test application.  
Add the debug version as a resource to your project.  
Then modify the project file using a text editor and locate the Reference to Okuma.Scout change the <HintPath> by replacing the folder name "\Debug\" with "\$(ConfigurationName)\". 
Refer to the test application project file 'ScoutTestApplication.csproj' to see how this is done.


### Notice ###

  Author: Scott Solmer  
  Copyright© 2017 Okuma America Corporation.  
      
  This sample code is unlicensed.  
  It is distributed "AS IS", WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,  
  either expressed or implied. Okuma America grants you permission to use  
  this code and derivative works thereof without limitation or obligation.  
      
  Under no circumstance shall Okuma America be held liable to anyone   
  using this code or programs derived there from for damages of any kind  
  as a result of the use or inability to use this code, including but not  
  limited to damages for loss of goodwill, work stoppage, computer failure  
  or malfunction, or any and all other commercial damages or losses.