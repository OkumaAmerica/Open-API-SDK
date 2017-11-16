
<img src="Header.png" width="100%" title="Github Logo">

# ﻿﻿Okuma Open API SDK

Software Development Kit for applications targeting Okuma OSP-P Machine Tools.
  * v1.5 pre-release


## Getting Started

> :warning:  NOTE:
>
> The API's `Init()` method must be called before accessing any machine data.  
> Furthermore, the initialization will **FAIL** if it is not executed in an environment where OSP NC Software is running.  
> The following environments will allow successful execution of API methods:  
>   * PC NC-Master (PC Simulation Software)
>   * NC-Master (Physical Hardware Simulator)
>   * Actual Okuma Machine Tool with P-type control


## Structure

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
│   └───1.9.1
│       ├───Bin
│       ├───Help
│       └───Test App
│           ├───Lathe
│           └───MC
├───Documentation           ※ Various information useful for app development
│   └───THINC API Release Notes
│       ├───1.9.1
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
│       └───1.19.0
├───Examples                   ╔══════════════════════════════════════════╗
│   ├───API Common Variables   ║  Example usage of the API                ║
│   │   ├───Compiled           ║  These examples, in different languages  ║
│   │   ├───CS_Lathe           ║  and targeting different machine types   ║
│   │   │   ├───Properties     ║  each demonstrate how to access common   ║
│   │   │   └───Resources      ║  variables.                              ║
│   │   ├───CS_MC              ╚══════════════════════════════════════════╝
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
│   ├───Python                ※ API Tutorial for Python
│   └───Single Instance
│       └───Single Instance WPF
│           └───Properties
├───OSP suite Shortcuts       ※ Instructions and example to make shortcut
│   └───010-NOTEPAD
│       └───00000010
│           └───res
├───Register V-FKEY
│   ├───README.txt            ※ Information about RegisterVfkey
│   └───RegisterVfkey.exe     ※ Utiltiy to add shortcut to V-FKEY
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
└───TDG Logging               ※ Library for creation of application logs
    ├───TDG.Logging 2.16      ※ The logging library and dependencies
    └───TestApp			          
        └───TDG Logging Example    ※ Test Application for TDG Logging Utility
            ├───Properties       
            └───TextLogSyntax
```	   

## Revision History

v0.1a   2014.04.??	> first distributable version  
v0.2a   2014.04.??	> add Okuma Open API v1.17.1  
v0.3a   2014.06.26	> add approval and widget Documentation  
v0.4a   2015.01.28	> add Scout libraries and test application  
v0.5a   2015.06.05	> update to Okuma.Scout.dll v1.0.0.4  
v0.6a   2015.08.24	> SCOUT v1.0.1.0, Update Cross Reference  
v0.7    2015.12.15	> SCOUT v1.0.2.0, Add API 1.18.0   
v0.8    2016.08.01	> SCOUT v1.0.4.0  
v1.0    2016.10.10	> SCOUT v2.2.0.0  
v1.0.1  2016.10.13	> SCOUT v2.2.1.0  
v1.2    2017.06.05	> SCOUT v2.3.0.0 & 4.0.0.0  
v1.3    2017.09.25	> SCOUT v2.3.1.0 & 4.1.0.0, RegisterVfkey, OSP suite shortcuts, TDG Logging 2.16, API 1.19  
v1.4    2017.11.01	> Okuma_Scout_Help.chm  
v1.5    2017.TBD   > Improved Examples


## Contact

api@okuma.com  


Retrieved from GitHub :octocat:  
[https://github.com/OkumaAmerica/Open-API-SDK](https://github.com/OkumaAmerica/Open-API-SDK)

© 2017 Okuma America Corporation All rights reserved.
