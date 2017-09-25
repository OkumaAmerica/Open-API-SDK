Imports System
Imports System.Threading
Imports System.ComponentModel
Imports System.Resources
Imports System.Globalization
Imports System.Reflection

Module modMain
    Public m_objForm As frmMain
    Private m_strTHINCAPIPath As String

    Sub Main()
        'Add any initialization after the InitializeComponent() call
        Try

            Dim objFile As System.IO.File

            Application.Run(New frmMain)


        Catch ex As Exception
            Dim objForm As frmMessage
            Dim strLabelMessage As String
            Dim strTextMessage As String
            Dim strVersion As String
            Dim objVersion As System.Version

            objVersion = [Assembly].GetExecutingAssembly.GetName().Version

            strVersion = String.Format("{0}.{1}.{2}.{3}", objVersion.Major.ToString, objVersion.Minor.ToString, objVersion.Build.ToString, objVersion.Revision.ToString)


            strLabelMessage = String.Format("{0}{1}", "Please contact OKUMA Software department to resolve problem.", ControlChars.CrLf + ControlChars.CrLf)
            strLabelMessage = strLabelMessage + String.Format("Please send the entire error message to api@okuma.com for futher investigate.")

            strTextMessage = String.Format("THINC Lathe Sample Application version {0}.{1}{2}", strVersion, ControlChars.CrLf + ControlChars.CrLf, ex.Message)
            objForm = New frmMessage(strLabelMessage, strTextMessage, MessageBoxIcon.Stop)
            objForm.ShowDialog()
            Application.Exit()
        End Try

    End Sub

    Sub CheckFileVersion(ByVal strFilePath As String, ByRef intMajor As Integer, ByRef intMinor As Integer, ByRef intBuild As Integer, ByRef intRevision As Integer)
        Dim strMessage As String

        Try
            Dim intFileVersionMajor As Integer
            Dim intFileVersionMinor As Integer
            Dim intFileVersionBuild As Integer
            Dim intFileVersionRevision As Integer
            Dim blnReturn As Boolean
            Dim strError As String
            Dim strSolution As String
            Dim strProblem As String
            Dim strVersion As String


            strVersion = String.Format("{0}.{1}.{2}.{3}", intMajor.ToString, intMinor.ToString, intBuild.ToString, intRevision.ToString)

            strMessage = String.Format("Checking file version: {0}, Compared Version: {1}", strFilePath, strVersion)







            ' Get the file version for the notepad.
            Dim objFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(strFilePath)




            intFileVersionMajor = objFileVersionInfo.FileMajorPart()
            intFileVersionMinor = objFileVersionInfo.FileMinorPart()
            intFileVersionBuild = objFileVersionInfo.FileBuildPart()
            intFileVersionRevision = objFileVersionInfo.FilePrivatePart()

            strError = String.Format("ERROR: THINC Lathe sample application cannot load {0} having version {1}.{2}", strFilePath, objFileVersionInfo.FileVersion(), ControlChars.CrLf + ControlChars.CrLf)
            strProblem = String.Concat(strError, String.Format("PROBLEM: This application requires {0} to have version {1}.{2}", strFilePath, strVersion, ControlChars.CrLf + ControlChars.CrLf))
            strSolution = String.Concat(strProblem, String.Format("POSSIBLE SOLUTION: - Un-install current THINC-API and re-instal THINC-API again."))


            'THINC-API MUST HAVE AN EXACT VERSION
            If intFileVersionMajor <> intMajor Then

                blnReturn = False

            ElseIf intFileVersionMinor <> intMinor Then

                blnReturn = False

            ElseIf intFileVersionBuild <> intBuild Then

                blnReturn = False

            ElseIf intFileVersionRevision <> intRevision Then

                blnReturn = False
            Else
                blnReturn = True
            End If

            If blnReturn = False Then
                Throw New ApplicationException(strSolution)
            End If


        Catch ae As ApplicationException
            Throw ae
        Catch ex As Exception
            Throw New ApplicationException(String.Format("Exception occurs in {0} - {1}", strMessage, ex.Message))
        End Try


    End Sub 'GetFileVersion

End Module
