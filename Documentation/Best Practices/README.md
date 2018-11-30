---
# Thinc API development Best Practices
---

Application Settings
====================

Intro
-----

The Thinc Developers Group (TDG) has recommended that all machine specific
settings for an application installed on an OSP control be stored in a common
AppData folder. Storing the application settings in a common location offers
several benefits:

-   Allows anyone to quickly back up setting for all of the installed
    applications from one location

-   Makes it easier for service personnel to backup data

-   Users will get accustomed to looking in one location for configuration files

-   User settings can “survive” a Windows reload because

-   Required for any app submitted to Okuma as an Okuma Certified App

-   Hopefully one day Okuma will include this folder as part of the standard
    parameter backup that the service guys perform before a software
    installation.

Location 
---------

The recommended location is D:\\AppData\\[CompanyName]\\[ApplicationName]

-   The [applicationName] directory may contain as many or as few sub
    directories as your application requires.

-   This folder should only contain files which were generated during and after
    the installation of the application. All static resources of the application
    itself should be installed in their normal location

-   Your application should first check for existence of the D:\\AppData
    directory and if doesn’t exist create it.

-   The D:\\ drive was chosen as the location of the AppData folder because the
    D:\\ drive is not touched during a standard Windows reload using the Okuma
    Windows disk.

    Note: even though your applications settings will survive a Windows Reload
    your app’s shortcuts on the desktop and/or Start Menu will not. Windows will
    no longer recognize your app as an installed application.

Format
------

Application settings can be in any format your application requires. We
recommend that you choose an easy to use, man readable format. Below are a few
good options:

-   [TOML](https://github.com/toml-lang/toml) (Nett is a .net TOML library)

-   [JSON](https://www.json.org) (.net has built in support for serializing JSON
    or use [json.net](https://www.newtonsoft.com/json) a popular .net JSON
    library)

-   XML (.net has built in support for serializing XML)

-   INI (check out this [ini-parser](https://github.com/rickyah/ini-parser))

Using built in Application Settings
-----------------------------------

If you prefer to use the standard Application Settings (My.Settings in VB) then
you will have to work with the ConfigurationManager to control where the
settings are saved to/loaded from. Check this
[SO](https://stackoverflow.com/questions/2389290/how-to-load-a-separate-application-settings-file-dynamically-and-merge-with-curre)
post for a lead on this.

Log Files
=========

Intro
-----

If your application generates a log file it is recommended that store those log
files in a common location. The Thinc Developers Group (TDG) has recommended
that settings and log files be stored in a common AppData folder. Some of the
advantages to this approach are:

-   Makes it easier for a user to get help from the developer if the log files
    are stored in a consistent manner

-   Makes it easier for AE’s and service personnel to assist customers with
    problems

-   Log files stored in this location can survive a standard Windows reload

Location
--------

The recommended storage location for log file is
D:\\AppData\\[CompanyName]\\[ApplicationName]\\[logs]

Format
------

There is no specific recommend format for log files. There are many different
formats and providers out there. We recommend you check out the [TDG logging
library](https://github.com/OkumaAmerica/Open-API-SDK/tree/master/TDG%20Logging).
Some other popular options are [NLog](https://nlog-project.org/),
[Log4Net](https://logging.apache.org/log4net/), and
[Serilog](https://serilog.net/).

API Initialization
==================

Before any API operations are called the CMachine.Init() must be called. This
must be done once per application one time on the main thread of the
application. Init can be called at any time before instantiating any instance of
any other API class. The application Startup or FormLoad are both acceptable
locations.  The instance of CMachine upon which Init() does not need to be retained
since that part of CMachine is static.

C\#

```

// Create an instance of CMachine class

var objMMachine = new Okuma.CMDATAPI.DataAPI.CMachine();

// 'Init()' must be called exactly once on the main

// thread from an instance of CMachine before any

// API operations can take place.

// Note that the instance of CMachine need not remain

// after 'Init()' is called as that part of CMachine

// is actually static.

objMMachine.Init();

```

VB.NET

```

' Init()' must be called exactly once on the main

' thread from an instance of CMachine before any

' API operations can take place.

' Note that the instance of CMachine need not remain

' after 'Init()' is called as that part of CMachine

' is actually static.

With New CMachine

.Init()

End With

```

Threading
=========

All calls to the API should be performed from a thread with an MTA apartment
state. Any calls performed on STA thread are likely to yield unreliable data.
