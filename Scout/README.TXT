# SCOUT DLL AND TEST APPLICATION README #

This README pertains to the Scout Test Application and included compiled Okuma.Scout.dll library only.  

The source code for the library file is not for distribution and Okuma America Corporation reserves all rights to its internal proprietary functions.  

### Contact Information ###

* For general programing questions related to Okuma products, we recommend asking your question on stackoverflow.com with the tag "okuma".  
 Refer to the following link to view all Okuma questions:  
 http://stackoverflow.com/questions/tagged/okuma?sort=newest&pageSize=50  
* For detailed, specific, or bug related questions, please email your question to API@Okuma.com

### Current Release Version ###

* Final Compile date: 1/19/2015
* Okuma.Scout.dll - Version 1.0.0.0
* ScoutTestApplication.exe / ScoutTestApplication.csproj - Version 1.0.0.0

### Change Notes ###

* None

### To Do ###

* None

### Notes ###

The test application includes a debug version and release version of the Scout library  
To create a project using either the debug or release version depending on the compile setting, first include both versions using the same structure as the test application.  
Add the debug version as a resource to your project.  
Modify the project file using a text editor and locate the Reference to Okuma.Scout and change the <HintPath> by replacing the folder name "\Debug\" with "\$(ConfigurationName)\". 
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
