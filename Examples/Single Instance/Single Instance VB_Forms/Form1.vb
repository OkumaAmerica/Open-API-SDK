Imports System.Reflection

Public Class Form1

End Class

Module modMain

    Public m_objForm As Form1
    Public m_SinglInstanceController As SingleInstanceController

    Public Sub Main()
        'Add any initialization after the InitializeComponent() call
        Try
            Dim strArg() As String

            m_SinglInstanceController = New SingleInstanceController()

            strArg = Environment.GetCommandLineArgs()

            m_SinglInstanceController.Run(strArg)


        Catch ex As Exception

            Console.WriteLine("Error: " + ex.Message)
            Application.Exit()
        End Try

    End Sub

End Module
