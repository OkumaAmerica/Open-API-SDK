Imports Microsoft.VisualBasic.ApplicationServices

Public Class SingleInstanceController
    Inherits WindowsFormsApplicationBase

    Public Sub New()
        ' Set whether the application is single instance
        Me.IsSingleInstance = True
        Me.EnableVisualStyles = True
        Me.SaveMySettingsOnExit = True
        Me.ShutdownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses


        AddHandler Me.StartupNextInstance, New StartupNextInstanceEventHandler(AddressOf SingleInstanceController_StartupNextInstance)
    End Sub


    Protected Overrides Sub OnCreateMainForm()
        ' Instantiate your main application form
        Me.MainForm = New Form1()
    End Sub

    Private Sub SingleInstanceController_Shutdown(sender As Object, e As System.EventArgs) Handles Me.Shutdown
        SystemShutDown = True
    End Sub

    Private Sub SingleInstanceController_StartupNextInstance(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
        ' Here you get the control when any other instance is
        ' invoked apart from the first one.
        ' You have args here in e.CommandLine.

        ' You custom code which should be run on other instances


        Me.ApplicationContext.MainForm.Visible = True
        Me.ApplicationContext.MainForm.Show()

    End Sub
End Class

