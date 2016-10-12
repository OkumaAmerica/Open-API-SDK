Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("THINC Lathe Sample")> 
<Assembly: AssemblyDescription("THINC Lathe Sample")> 
<Assembly: AssemblyCompany("Okuma America Corporation")> 
<Assembly: AssemblyProduct("THINC Lathe Sample")> 
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

<Assembly: AssemblyVersion("1.18.0.0")> 


'//<Assembly: AssemblyVersion("1.0.0.0")> 
'Public RELEASE
'//<Assembly: AssemblyVersion("1.1.0.0")> 
'Public RELEASE v1.1.0.0
'add CSpec machine name and serial
'add CTurret.GetMaxToolPots

'<Assembly: AssemblyVersion("1.2.0.0")> 
'support COptionalParameter, I/O Variable, Variable Limit and Droop Data
'Add version check in in modMain module


'<Assembly: AssemblyVersion("1.2.0.1")> 
'correct version checking routine

'<Assembly: AssemblyVersion("1.2.0.2")> 
'correct version checking rule by adding full THINC-API PATH 
' It probably runs from a short cut ==> different file path ==> fail to check files


'<Assembly: AssemblyVersion("1.2.0.3")> 
'check local api version only

'<Assembly: AssemblyVersion("1.2.0.4")> 
'revise error message in file version checking routine
'change to single tab in mainform


'<Assembly: AssemblyVersion("1.3.0.0")> 
'support samples for DATA-API VERSION 1.3.0.0 AND COMMAND API V1.1.0.0

'<Assembly: AssemblyVersion("1.5.0.0")> 
'support public release 1.5

'<Assembly: AssemblyVersion("1.6.0.0")> 
'support public release 1.6
'correct set subsystem for Optional parameter tab


'<Assembly: AssemblyVersion("1.6.3.0")> 
'support public release 1.6.3.0

'<Assembly: AssemblyVersion("1.7.0.0")> 
'for public release 1.7.0.0


'<Assembly: AssemblyVersion("1.9.1.0")> 
'FOR PUBLIC RELEASE 1.9.1.0


'<Assembly: AssemblyVersion("2.0.0.0")> 
'for public release 2.0.0.0


'<Assembly: AssemblyVersion("1.9.2.0")> 
'for public release 1.9.2.0


'<Assembly: AssemblyVersion("1.10.0.0")> 
' for public release 1.10.0.0


'<Assembly: AssemblyVersion("1.11.0.0")> 
' for public release 1.11.0.0

'<Assembly: AssemblyVersion("1.12.0.0")> 
' for public release 1.12.0.0

'<Assembly: AssemblyVersion("1.12.1.0")> 
' for public release 1.12.1.0

'<Assembly: AssemblyVersion("1.14.0.0")> 
' for public release 1.14.0.0

'<Assembly: AssemblyVersion("1.15.0.0")> 
' for public release 1.15.0.0

'<Assembly: AssemblyVersion("1.15.1.0")> 
' for public release 1.15.1.0


'<Assembly: AssemblyVersion("1.17.0.0")> 
'add/revise functions to support AutoComp & Tool ID for CE
'
'<Assembly: AssemblyVersion("1.17.1.0")> 
' for public release 1.17.1.0

'<Assembly: AssemblyVersion("1.17.2.0")> 
'for public release 1.17.2.0

'<Assembly: AssemblyVersion("1.17.2.1")> 
'for public release 1.17.2.0
'SUPPORT DATA API 2.6.1.1 RELEASE TO SUPPORT DUAL MAGAZINE MULTUS

''<Assembly: AssemblyVersion("1.18.0.0")> 
'for public release 1.18.0.0