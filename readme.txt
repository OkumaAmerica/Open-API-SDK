﻿Okuma Open API SDK v1.4 - November 2017
_________________________________________________________________________
Purpose:

Reference information for developers targeting the Okuma OSP-P platform
_________________________________________________________________________
Structure:

├───API		       /* Recommended API versions for development     */
│   ├───1.9.1
│   │   ├───Bin        /* Refer to the test applications for details   */
│   │   ├───Help       /*  about how to use each function in the       */
│   │   └───Test App   /*  API. Okuma uses these projects to verify    */
│   ├───1.12.1	       /*  the operation of the API before release.    */
│   ├───1.17.2
│   └───1.19.0
├───Documentation    /* Various information useful for app development */
├───Examples            /* Example usage of the API                    */
│   ├───Compiled        /*   These examples, in different languages    */
│   ├───CS_Lathe        /*   and targeting different machine types     */
│   ├───CS_MC           /*   each demonstrate how to access common     */
│   ├───CS_WPF          /*   variables.                                */
│   ├───Python          /* API Tutorial for Python	               */
│   ├───VB_Lathe
│   └───VB_MC
├───OSP suite Shortcuts   /* Instructions and example to make shortcut */
├───Register V-FKEY
│   ├───README.txt	    /*  Information about RegisterVfkey        */
│   └───RegisterVfkey.exe   /*  Utiltiy to add shortcut to V-FKEY      */
├───Scout
│   ├───README.html	    /*  Information about SCOUT                */
│   ├───Scout SDK.sln	    /*  Microsoft Visual Studio Solution File  */
│   ├───Okuma.Scout.TestApp.net20 
│   │   └───Lib
│   │	    └─Release
│   │	      └─Okuma.Scout.dll	    /* .NET 2.0 SCOUT Library	       */
│   └───Okuma.Scout.TestApp.net40 
│       └───Lib
│    	    └─Release
│    	      └─Okuma.Scout.dll	    /* .NET 4.0 SCOUT Library	       */
└───TDG Logging		   /* Library for creation of application logs */
    ├───TDG.Logging 2.16   /* The logging library and dependencies     */
    └───TestApp	 	   /* Test Application for TDG Logging Utility */


tree...
├───API
│   ├───1.12.1
│   │   ├───Bin
│   │   ├───Help
│   │   └───Test App
│   │       ├───Lathe
│   │       └───MC
│   ├───1.17.2
│   │   ├───Bin
│   │   ├───Help
│   │   └───Test App
│   │       ├───Lathe
│   │       └───MC
│   ├───1.19.0
│   │   ├───Bin
│   │   ├───Help
│   │   └───Test App
│   │       ├───ThincGrinder
│   │       │   ├───Lib
│   │       │   └───My Project
│   │       │       └───DataSources
│   │       ├───ThincLathe
│   │       │   └───lib
│   │       └───ThincMC
│   │           └───lib
│   └───1.9.1
│       ├───Bin
│       ├───Help
│       └───Test App
│           ├───Lathe
│           └───MC
├───Documentation
│   └───THINC API Release Notes
│       ├───1.10.0
│       ├───1.11.0
│       ├───1.11.1
│       ├───1.12.0
│       ├───1.12.1
│       ├───1.15.0
│       ├───1.16.0
│       ├───1.17.0
│       ├───1.17.1
│       ├───1.17.2
│       ├───1.18.0
│       ├───1.19.0
│       └───1.9.1
├───Examples
│   ├───API Common Variables
│   │   ├───Compiled
│   │   ├───CS_Lathe
│   │   │   ├───Properties
│   │   │   └───Resources
│   │   ├───CS_MC
│   │   │   ├───Properties
│   │   │   └───Resources
│   │   ├───CS_WPF
│   │   │   └───Properties
│   │   ├───VB_Lathe
│   │   │   ├───My Project
│   │   │   └───Resources
│   │   └───VB_MC
│   │       ├───My Project
│   │       └───Resources
│   ├───Python
│   └───Single Instance
│       └───Single Instance WPF
│           └───Properties
├───OSP suite Shortcuts
│   └───010-NOTEPAD
│       └───00000010
│           └───res
├───Register V-FKEY
├───Scout
│   ├───Okuma.Scout.TestApp.net20
│   │   ├───Lib
│   │   │   ├───Debug
│   │   │   └───Release
│   │   └───Properties
│   └───Okuma.Scout.TestApp.net40
│       ├───Helpers
│       ├───Lib
│       │   ├───Debug
│       │   └───Release
│       ├───Properties
│       ├───Resources
│       ├───ViewModels
│       └───Views
└───TDG Logging
    ├───TDG.Logging 2.16
    └───TestApp
        └───TDG Logging Example
            ├───Properties
            └───TextLogSyntax


_________________________________________________________________________
Revision History:

v0.1a	2014.04.??	> first distributable version
v0.2a	2014.04.??	> add Okuma Open API v1.17.1
v0.3a	2014.06.26	> add approval and widget Documentation
v0.4a	2015.01.28	> add Scout libraries and test application
v0.5a	2015.06.05	> update to Okuma.Scout.dll v1.0.0.4
v0.6a   2015.08.24	> SCOUT v1.0.1.0, Update Cross Reference
v0.7    2015.12.15	> SCOUT v1.0.2.0, Add API 1.18.0 
v0.8	2016.08.01	> SCOUT v1.0.4.0
v1.0	2016.10.10	> SCOUT v2.2.0.0
v1.0.1  2016.10.13	> SCOUT v2.2.1.0
v1.2	2017.06.05	> SCOUT v2.3.0.0 & 4.0.0.0
v1.3	2017.09.25	> SCOUT v2.3.1.0 & 4.1.0.0, RegisterVfkey,
			  OSP suite shortcuts, TDG Logging 2.16, API 1.19
_________________________________________________________________________

Contact:

api@okuma.com