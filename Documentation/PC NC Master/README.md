---
title: Debugging on PC NC Master
---

Required Setup
=====
Debugging on PC NC Master is pretty easy to do. 
1. Be sure you have installed PC-based NC Master and THiNC API
2. OPen visual studio as Administrator 
3. Locate an dopen app.manifest. If you do not have an app.manifest file you may need to create one:
    1. Right click your project -> Add -> New Item -> General -> Application Manifest file
4. Locate "requestedExecutionLevel" and change "Level="requireAdministrator"
        <requestedExecutionLevel level="requireAdministrator" uiAccess="false" />


Thats all there is to it. With PC NC MAster open, you can now run files with the run button directly from Visual Studio. 