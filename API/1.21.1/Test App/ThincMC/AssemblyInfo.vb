Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("THINC Machining Center Sample")> 
<Assembly: AssemblyDescription("THINC Machining Center Sample")> 
<Assembly: AssemblyCompany("Okuma America Corporation")> 
<Assembly: AssemblyProduct("THINC Machining Center Sample")> 
<Assembly: AssemblyCopyright("Okuma")> 
<Assembly: AssemblyTrademark("")> 
<Assembly: CLSCompliant(True)> 

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("4F32EDE9-037C-4EA2-BAAD-E8E17E94CD54")> 

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:

<Assembly: AssemblyVersion("1.21.1.0")> 

'<Assembly: AssemblyVersion("1.0.0.0")> 
'Public release version 1.0.0.0

'<Assembly: AssemblyVersion("1.1.0.0")> 
'add sample code for 
' AddCutterRCompOffset(Int32 intOffsetIndex, Double dblValue) ;
' AddCutterRCompWearOffset(Int32 intOffsetIndex, Double dblValue) ;


'<Assembly: AssemblyVersion("1.2.0.0")> 
'add sample code for 
'release 1.2 okuma.cmdatapai.dll
'release 1.1 okuma.cmcmdapi.dll


'<Assembly: AssemblyVersion("1.3.0.0")> 
'support sample codes for:
'release 1.3 okuma.cmdatapai.dll
'release 1.2 okuma.cmcmdapi.dll
'<Assembly: AssemblyVersion("1.5.0.0")> 
'support public release 1.5


'<Assembly: AssemblyVersion("1.6.0.0")> 
'support public release 1.6
'remove mop tool check and use thinc api notifier to set option in registry to detect in cmd api
'If objSpec.GetOptionSpecCode(OptionSpecEnum.MOPTool) = False Then
'    MsgBox("MOP Tool option is not available for this funtion", MsgBoxStyle.Exclamation)
'    Exit Sub
'End If
'<Assembly: AssemblyVersion("1.6.3.0")> 
'support public release 1.6.3.0
'support release CMDATAPIdll version 1.5.0.1


'<Assembly: AssemblyVersion("1.7.0.0")>
'for public release 1.7.0.0
'support release CMDATAPIdll version 1.6.0.0
'support release 1.5.0.0 okuma.cmcmdapi.dll


'support Random ATC 8 Digits Tool ID
'correct unregister tool pot for ATC Random




'<Assembly: AssemblyVersion("1.9.1.0")> 
'no new functions added


'<Assembly: AssemblyVersion("1.11.1.0")> 
'no new function added , just use new apilog version 1.2


'<Assembly: AssemblyVersion("1.10.0.0")> 
'no new functions added

'<Assembly: AssemblyVersion("1.11.0.0")> 
'no new functions added
'<Assembly: AssemblyVersion("1.12.1.0")> 
'no new functions added
'SUPPORT RELEASE 1.12.1.0


'<Assembly: AssemblyVersion("1.12.2.0")> 
'no new functions added
'SUPPORT RELEASE 1.12.2.0


'<Assembly: AssemblyVersion("1.14.0.0")> 
'add functions for renishaw
'SUPPORT BETA RELEASE 1.14.0.0

'<Assembly: AssemblyVersion("1.15.0.0")>
'support public release 1.15.0.0
'<Assembly: AssemblyVersion("1.14.2.0")> 
'add functions for renishaw command api
'SUPPORT BETA RELEASE 1.14.2.0



'<Assembly: AssemblyVersion("1.15.3.0")>
'Support beta release 1.15.3.0


'<Assembly: AssemblyVersion("1.16.0.0")> 
'SUPPORT PUBLIC RELEASE 1.16.0.0


'<Assembly: AssemblyVersion("1.17.0.0")> 
'SUPPORT PUBLIC RELEASE 1.17.0.0

'<Assembly: AssemblyVersion("1.17.1.0")> 
'SUPPORT PUBLIC RELEASE 1.17.1.0


'<Assembly: AssemblyVersion("1.17.2.0")> 
'SUPPORT PUBLIC RELEASE 1.17.2.0

'<Assembly: AssemblyVersion("1.17.3.0")> 
'SUPPORT Beta RELEASE 1.17.3.0 beta for OCJ Renishaw API
'correct SetNCOptionalParamterBit routine

'<Assembly: AssemblyVersion("1.17.3.1")> 
'SUPPORT Beta RELEASE 1.17.3.1


'<Assembly: AssemblyVersion("1.18.0.0")> 
'public release 1.18.0.0

'<Assembly: AssemblyVersion("1.18.0.0")> 
'beta release 1.18.1.0


'<Assembly: AssemblyVersion("1.19.0.0")> 
'public release 1.19.0.0
'CMDATAPI.DLL version 2.8.0.0
'CMCMDAPI.DLL version 2.5.0.0


'<Assembly: AssemblyVersion("1.20.0.0")>
'public release 1.20.0.0
'CMDATAPI.DLL version 3.0.0.0
'CMCMDAPI.DLL version 3.1.0.0
'Okuma.ApiLog2.dll version 1.2.0.0
'Okuma.Api.LogService.Data version 1.0.0.0


'<Assembly: AssemblyVersion("1.21.0.0")>
'public beta release 1.21.0.0
'CMDATAPI.DLL version 3.1.0.0
'CMCMDAPI.DLL version 3.???
'Okuma.ApiLog2.dll version 1.2.0.0
'Okuma.Api.LogService.Data version 1.0.0.0

'<Assembly: AssemblyVersion("1.21.1.0")> 
'public release 1.21.1.0
'CMDATAPI.DLL version 3.2.0.0
'CMCMDAPI.DLL version 3.2.1.0
'Okuma.ApiLog2.dll version 1.2.0.0
'Okuma.Api.LogService.Data version 1.0.0.0
