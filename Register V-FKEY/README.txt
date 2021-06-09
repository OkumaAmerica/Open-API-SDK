V-FKEY stands for Vertical Function Key (menu).

The command line application RegisterVfkey.exe is designed to be called by an 
application's installer and creates a short-cut in the vertical function key menu.

Users may manually add or remove short-cuts from the V-KEY menu by running 
C:\OSP-P\V-FKEY\SVFKA-SET.EXE while in Windows Only Mode. 

RegisterVfkey.exe allows the process to be automated (called by a script) 
and will work even while the OSP control is running.

For details about how to use the application, run it with the 
command line switch '/?'


"RegisterVfkey.exe /?"

Questions may be directed to api@okuma.com


Legacy V-KEY library: Okuma.OSPUtilities.dll
Sample codes show how to register an application OSP V-KEY 
Application must call the function while OSP system is not running OLY

    Private Sub CreateOSPShortCut()
        Try
            Okuma.OSPUtilities.cVFKEY.AddButton(m_strFullPath & "\" & m_strApplication, "MONITORING", "SYSTEM", "", False, True)  'note 1  'note 1
            m_InstallLog.WriteLine("Finish installing OSP short cut for " & m_strFullPath & "\" & m_strApplication)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RemoveOSPShortCut()
        Try
            Okuma.OSPUtilities.cVFKEY.RemoveButton(m_strFullPath & "\" & m_strApplication)   'note 2
            m_InstallLog.WriteLine("Finish removing OSP short cut for " & m_strFullPath & "\" & m_strApplication)

        Catch ex As Exception
        End Try
    End Sub


