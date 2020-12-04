To use NuGet packages which are have not been submitted to NuGet.org (which these libraries have not), there are two options.

Option 1 (Command Line):
Copy the .nupkg file to the same directory as the .sln (VS Solution File).
Open the Package Manager Console from VS (Tools -> Nuget Package Manager ->  Package Manager Console)
Type "dir" to list files in the solution directory
Copy the package name (it should appear next to your solution file)
Type "Install-Package EXAMPLE.nupkg"

Option 2 (GUI):
Create a new directory somewhere in the development environment (ex. 'C:\Local_NuGetPackages')
Copy the desired NuGet packages into this directory. 
In Visual Studio (VS2019 used, but older versions should work similar) right-click the desired solution and select "Manage NuGet Packages For Solution"
Next To "Package Source" (default is nuget.org) click the settings gear.
Add a package sources location (the directory you created)
Select the new local source.
Any packages you added to the local directory should appear under Browse and can be installed or updated just as you would if using nuget.org as the source.