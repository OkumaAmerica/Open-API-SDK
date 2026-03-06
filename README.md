
<img src="Images/Header.png" width="100%" title="Github Logo">

# ﻿﻿Okuma Open API SDK v2.4.0

Software Development Kit for applications targeting Okuma OSP-P Machine Tools.  

## Welcome

Thank you for your interest in creating [Machine Tool Apps](http://www.okuma.com/wp-machine-tool-apps) for the Okuma OSP-P NC Control.  
We use [StackOverflow](http://stackoverflow.com/questions/tagged/okuma) to answer programming questions.

Open API questions should be sent to [API@okuma.com](mailto:API@okuma.com)  
Okuma App Store questions should be sent to [AppStore@okuma.com](mailto:AppStore@okuma.com)  

If you have an app you would like to appear on the MyOkuma.com App Store,  
please refer to "MyOkuma App Store App Guidelines.txt" before submitting.


## Getting Started

### :heavy_exclamation_mark: How to open API Help files  

 API help files are provided in .chm [Microsoft Compiled HTML Help](https://en.wikipedia.org/wiki/Microsoft_Compiled_HTML_Help) format.  
 For various reasons, these files might not open or display correctly.  
 If you experience this, please try the following:  

>    * Store the files locally and do not attempt to open over a network
>    * Do not store the files in a directory which contains the '#' character.
>    * Right-click on the help file and select Properties.  
>      Then click the "Unblock" button.  

  ![Unblock](Images/Unblock.png)

### :heavy_exclamation_mark: Calling THINC-API functions inside a thread
All functions of THINC-API can be called inside a thread if and only if the thread is not 
spawn by the system (thread pool).  BackgroundWorker thread or Task thread will use system thread pool
which will cause intermittent issue with the THINC-API library.

### :warning: Where can API functions be executed
 The API's `Init()` method must be called in the MAIN / GUI
 thread before accessing any machine data.  
 Furthermore, the initialization will **FAIL** if it is not 
 executed in an environment where OSP NC Software is running
 **AND** THINC API is installed with API Notifier service running
 and Initialized.

### :warning: Initialized THINC-API
All applications/services using THINC-API must use OKUMA Startup Service to start the applications/services to 
ensure that THINC-API is ready before trying to initialize THINC-API in the application itself. 
 
 The following environments will allow successful execution of API methods:  

    * PC NC-Master (PC Simulation Software,  application must be run under Administrator account, explicitly)
    * NC-Master (Physical Hardware Simulator)
    * Actual Okuma Machine Tool with P-type control
    
    For information about simulation hardware or software, refer to
    'Documentation\Machine Simulators.txt' and contact your local Okuma distributor. 
[https://www.okuma.com/distributors](https://www.okuma.com/distributors)

This Init method of CMachine class should only be called once during the life time of the application once it is successful.  Multiple calling of this routine might have an undesired affect on machine data.

### :warning: Closing THINC-API
Unless the application is shutting down, the Close method on CMachine class should only be called. If application needs to 

## :notebook_with_decorative_cover: Structure

```  
├───API                ╔══════════════════════════════════════════════╗   
│   ├───1.12.1         ║  Recommended API versions for development.   ║  
│   │   ├───Bin        ║  Refer to the test applications for details  ║  
│   │   ├───Help       ║  about how to use each function in the       ║  
│   │   └───Test App   ║  API. Okuma uses these projects to verify    ║  
│   │       ├───Lathe  ║  the operation of the API before release.    ║  
│   │       └───MC     ╚══════════════════════════════════════════════╝  
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
│   ├───1.21.1
│   │   ├───Bin
│   │   ├───Help
│   │   └───Test App
│   │       ├───ThincGrinder
│   │       │   ├───Lib
│   │       │   └───My Project
│   │       │       └───DataSources
│   │       ├───ThincLathe
│   │       │   ├───lib
│   │       │   └───My Project
│   │       │       └───DataSources
│   │       └───ThincMC
│   │           ├───lib
│   │           └───My Project
│   │               └───DataSources
│   ├───1.23.0
│   │   ├───Bin
│   │   ├───Help
│   │   └───TestApp
│   ├───1.23.1
│   │   ├───Bin
│   │   ├───Help
│   │   └───TestApp
│   ├───1.24.0
│   │   ├───Bin
│   │   ├───Help
│   │   └───TestApp
│   ├───1.24.2
│   │   ├───Bin
│   │   ├───Help
│   │   └───TestApp
│   ├───1.25.0
│   │   ├───Bin
│   │   ├───Help
│   │   └───TestApp
│   ├───1.25.1
│   │   ├───Bin
│   │   ├───Help
│   │   └───TestApp
│   ├───1.26.1
│   │   ├───Bin
│   │   ├───Help
│   │   └───TestApp
│   ├───1.26.2
│   │   ├───Bin
│   │   ├───Help
│   │   └───TestApp
│   ├───1.26.3
│   │   ├───Bin
│   │   ├───Help
│   │   └───TestApp
│   ├───1.26.4
│   │   ├───Bin
│   │   ├───Help
│   │   └───TestApp
│   └───1.9.1
│       ├───Bin
│       ├───Help
│       └───Test App
│           ├───Lathe
│           └───MC
├───Documentation
│   ├───Best Practices
│   ├───Remote Debugging
│   │   └───media
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
│       ├───1.20.0
│       ├───1.21.1
│       ├───1.22.0
│       ├───1.23.1
│       ├───1.24.0
│       ├───1.24.2
│       ├───1.25.0
│       ├───1.25.1
│       ├───1.26.1 OBSOLETE
│       ├───1.26.2 OBSOLETE
│       ├───1.26.3
│       ├───1.26.4
│       └───1.9.1
├───Examples
│   ├───API Common Variables
│   │   ├───Common
│   │   ├───Compiled
│   │   ├───CS_Lathe
│   │   │   └───Properties
│   │   ├───CS_MC
│   │   │   └───Properties
│   │   ├───CS_WPF
│   │   │   └───Properties
│   │   ├───VB_Lathe
│   │   │   └───My Project
│   │   ├───VB_MC
│   │   │   └───My Project
│   │   └───VB_WPF
│   │       └───My Project
│   │           └───MyExtensions
│   ├───Cross Machine Platform
│   │   ├───CS_WPF
│   │   │   ├───OkumaInterface
│   │   │   └───Properties
│   │   └───VB_WPF
│   │       ├───My Project
│   │       │   └───MyExtensions
│   │       └───OkumaInterface
│   └───Single Instance
│       ├───Single Instance CS_Forms
│       │   ├───bin
│       │   │   └───Debug
│       │   └───Properties
│       ├───Single Instance CS_WPF
│       │   ├───bin
│       │   │   └───Debug
│       │   └───Properties
│       └───Single Instance VB_Forms
│           ├───bin
│           │   └───Debug
│           └───My Project
├───Images
├───OSP suite Shortcuts
│   └───010-NOTEPAD
│       └───00000010
│           └───res
├───Register V-FKEY
└───Scout
    ├───Doc
    ├───Lib
    │   ├───.NET 2.0
    │   │   ├───Debug
    │   │   └───Release
    │   └───.NET 4.0
    │       ├───Debug
    │       └───Release
    ├───Okuma.Scout.TestApp.net2
    │   └───Properties
    └───Okuma.Scout.TestApp.net4
        ├───Helpers
        ├───Properties
        ├───Resources
        ├───ViewModels
        └───Views

```

## :mailbox_with_mail: Contact

[api@okuma.com](mailto:api@okuma.com)  


Do you enjoy developing applications for the Okuma OSP Control?  
Have some ideas you would like to share?  
Or maybe you would just enjoy the chance to talk with the experts?  

Consider joining the **THINC Developers Group**  
Contact: [thincdg@gmail.com](mailto:thincdg@gmail.com)  
Information:

  * [https://www.okuma.com/thinc-developers-group](https://www.okuma.com/thinc-developers-group)

## :memo: Revision History

Version | Date 			| Note  
:---	|:---			|:--  
v2.4    | 2026.02.16  	| API 1.26.4 
v2.3    | 2025.03.14  	| API 1.26.3 
v2.2    | 2024.11.15  	| API 1.26.2 OBSOLETE
v2.1    | 2024.09.09  	| API 1.25.1
v2.0    | 2024.08.26  	| API 1.26.1
v1.9    | 2024.04.11  	| API 1.25.0
v1.8    | 2023.03.07  	| API 1.24.2.0
v1.7    | 2023.02.22  	| API 1.24.0.0
v1.6    | 2021.09.17  	| API 1.23.1.0
v1.5    | 2018.09.21  	| API 1.21.1.0, SCOUT v4.12.36.1, TDG Logging 4.19 
v1.4    | 2017.11.01	| SCOUT .CHM Help File  
v1.3    | 2017.09.25	| API 1.19, SCOUT v4.1.0.0, TDG Logging 2.16, RegisterVfkey, OSP suite Shortcuts  
v1.2    | 2017.06.05	| SCOUT v2.3.0.0 & 4.0.0.0  
v1.0.1  | 2016.10.13	| SCOUT v2.2.1.0  
v1.0    | 2016.10.10	| SCOUT v2.2.0.0  
v0.8    | 2016.08.01	| SCOUT v1.0.4.0  
v0.7    | 2015.12.15	| API 1.18.0, SCOUT v1.0.2.0  
v0.6a   | 2015.08.24	| SCOUT v1.0.1.0, Update Cross Reference  
v0.5a   | 2015.06.05	| SCOUT v1.0.0.4  
v0.4a   | 2015.01.28	| add Scout libraries and test application  
v0.3a   | 2014.06.26	| add approval and widget Documentation    
v0.2a   | 2014.04.??	| API v1.17.1  
v0.1a   | 2014.04.??	| first distributed version   

## :construction: TO DO
___

Retrieved from GitHub :octocat:  
[https://github.com/OkumaAmerica/Open-API-SDK](https://github.com/OkumaAmerica/Open-API-SDK)

© 2024 Okuma America Corporation
	Please see the Installation Manual
  * THINC API - Best Practices
