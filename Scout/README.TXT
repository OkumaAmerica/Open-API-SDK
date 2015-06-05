# SCOUT DLL AND TEST APPLICATION README #

* Last Compile date: 06/5/2015
* Okuma.Scout.dll - Version 1.0.0.4
* Test Application - Version 1.0.0.5

This README pertains to the Scout Test Application and included compiled Okuma.Scout.dll library only.  

The source code for Okuma.Scout.dll is not for distribution and Okuma America Corporation reserves all rights to its internal proprietary functions.  

### Contact Information ###

* For general programing questions related to Okuma products, we recommend asking your question on stackoverflow.com with the tag "okuma".  
 Refer to the following link to view all Okuma questions:  
http://stackoverflow.com/questions/tagged/okuma?sort=newest&pageSize=50  
* For detailed, specific, or bug related questions, please email your question to API@Okuma.com

### Change Notes ###

* 6/5/2015
  > Added class "Okuma.Scout.Display" class to provide information about screens / monitors attached to the system
  > Added method "Okuma.Scout.Helper.RegDwordIntegerVersionParse()" to convert raw uninstall "Version" data to version objects. 

* 5/15/2015
  > Determine CAPI version based on OCJ API library versions

* 5/9/2015
  > Added class "Okuma.Scout.Reg" and accompanying "Registry" tab in test application. 
    Functions in this class are compatible with 32 & 64 bit systems and .NET 2+.

* 3/23/2015
  > Fixed bug in API identification cross reference file that resulted in not properly detecting API version 1.17.2.0 on Machining Center.
  > Fixed bug in Operating System module that resulted in incorrect reporting of OS bitness.
  > Fixed bug where the absence of C:\Version.txt resulted in exception (handled).
  > Removed Options Identification class and supporting structures.

* 2/25/2015
  > Revamped the way PLC Spec codes are retrieved to allow for user defined files, 
    access to all spec code groups, file type validation, and more!  

* 02/24/2015
  > Changed the way NC & NCB Spec codes are retrieved to allow for user defined files, 
    access to all spec code groups, file type validation, and more.

* 02/02/2015
  > Added properties for scout.dll version & build date 
    and the calling assembly (sample program for example) version & build date
    The new properties use a more reliable method to obtain the actual build date
    rather than the file modified date.

### To Do ###

* Detect screen mode (SOFTWARE\OKUMA\NCHMI\SCREEN_MODE )


### Notes ###

The test application includes a debug version and release version of the Scout library  
To create a project using either the debug or release version depending on the compile setting, first include both versions using the same structure as the test application.  
Add the debug version as a resource to your project.  
Then modify the project file using a text editor and locate the Reference to Okuma.Scout change the <HintPath> by replacing the folder name "\Debug\" with "\$(ConfigurationName)\". 
Refer to the test application project file 'ScoutTestApplication.csproj' to see how this is done.


### Notice ###

  Author: Scott Solmer  
  Copyright© 2016 Okuma America Corporation.  
      
  This sample code is unlicensed.  
  It is distributed "AS IS", WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,  
  either expressed or implied. Okuma America grants you permission to use  
  this code and derivative works thereof without limitation or obligation.  
      
  Under no circumstance shall Okuma America be held liable to anyone   
  using this code or programs derived there from for damages of any kind  
  as a result of the use or inability to use this code, including but not  
  limited to damages for loss of goodwill, work stoppage, computer failure  
  or malfunction, or any and all other commercial damages or losses.  
