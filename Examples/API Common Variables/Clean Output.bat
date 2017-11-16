@Echo OFF

REM https://stackoverflow.com/a/10399706/2596334
REM https://stackoverflow.com/a/10221436/2596334

REM Important that Delayed Expansion is Enabled
setlocal enabledelayedexpansion

REM Set the base directory in which to search (the location of this batch file)
set root="%~dp0"
set root_ref=%~dp0

set foldername=obj
FOR /R %root% %%A IN (.) DO (
    if '%%A'=='' goto seconddirectory   
    REM Correctly parses info for executing the loop and RM functions
    set dir="%%A"
    set dir=!dir:.=!
    set directory=%%A
    set directory=!directory::=!
    set directory=!directory:\=;!   
    REM Checks each directory
    for /f "tokens=* delims=;" %%P in ("!directory!") do call :loop %%P
)

:seconddirectory
set foldername=bin
FOR /R %root% %%A IN (.) DO (
    if '%%A'=='' goto end   
    REM Correctly parses info for executing the loop and RM functions
    set dir="%%A"
    set dir=!dir:.=!
    set directory=%%A
    set directory=!directory::=!
    set directory=!directory:\=;!   
    REM Checks each directory
    for /f "tokens=* delims=;" %%P in ("!directory!") do call :loop %%P
)

REM After each directory is checked the batch will allow you to see folders deleted.
:end
pause
endlocal
exit

REM This loop checks each folder inside the directory for the specified folder name. 
REM This allows you to check multiple nested directories.
:loop
if '%1'=='' goto endloop
if '%1'=='%foldername%' (
    rd /S /Q !dir!
	
	REM Show relative path (seems to miss the first pass for some reason, but the delete happens anyway)
	set Path_to_convert=!dir!
	set Result=!Path_to_convert:*%root_ref%=!
	echo %Result% was deleted.   
)
SHIFT
goto :loop
:endloop