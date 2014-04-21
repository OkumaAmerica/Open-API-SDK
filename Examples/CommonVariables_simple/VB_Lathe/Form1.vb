Imports Okuma.CLDATAPI.DataAPI
''' <summary>
''' Okuma Common Variable Editor Example for lathe
''' 
''' If possible, applications targeting Okuma OSP platform should:
'''   - Target .NET 2.0 [this is for backward compatibility and download size]
'''     - if >.NET 2.0 is required you must use .NET 4.0
'''   - Compile using the lowest API version possible out of ['1.9.1', '1.12.1', '1.17.1']
''' </summary>
''' <remarks></remarks>
Public Class Form1
    ' CMachine must be declared on main thread of each application (see initialization in 'Form1_Load')
    Private myCVariables As CVariables
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            ' 'Init()' must be called exactly once on the main
            '   thread from an instance of CMachine before any
            '   API operations can take place.
            ' Note that the instance of CMachine need not remain
            '   after 'Init()' is called as that part of CMachine
            '   is actually static.
            With New CMachine
                .Init()
            End With

            ' An instance of CVariables can be instantiated once
            '   to save overhead or multiple times if you need
            '   several versions of it.
            myCVariables = New CVariables
        Catch ex As Exception
            DoError(New Exception("Error initializing API: If API is installed, there should be a round" +
                " green icon in the task-bar that tells API version when clicked. If version is less than" +
                " 1.9.1, contact your distributor to request a free API upgrade.", ex))
            Application.Exit()
        End Try

        ' for "exit" button, callback to lambda to exit
        AddHandler btnExit.Click, Sub(si As Object, ei As EventArgs)
                                      Application.Exit()
                                  End Sub
    End Sub

    ''' <summary>
    ''' Uniformly handles display of errors to user.
    ''' </summary>
    ''' <param name="EXCEPTION"></param>
    ''' <remarks>
    ''' While not shown here, normally one would include logging in a central error handling function like this.
    ''' </remarks>
    Private Sub DoError(ByVal EXCEPTION As System.Exception)
        Dim _msg As String = "Error:  " & vbCrLf
        _msg &= EXCEPTION.Message & vbCrLf & vbCrLf & EXCEPTION.StackTrace
        MessageBox.Show(_msg, My.Application.Info.AssemblyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ''' <summary>
    ''' Reads from common variables into text boxes and resets color
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            tbNo1.Text = myCVariables.GetCommonVariableValue(1).ToString()
            tbNo2.Text = myCVariables.GetCommonVariableValue(2).ToString()
            tbNo1.BackColor = System.Drawing.SystemColors.Window
            tbNo2.BackColor = System.Drawing.SystemColors.Window
        Catch ex As Exception
            DoError(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Attempts to
    '''  - convert text box value to an integer
    '''  - write that value to common variable
    '''  - set text box color to green
    ''' If any part fails
    '''  - sets text box color to red
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnWrite_Click(sender As Object, e As EventArgs) Handles btnWrite.Click
        Dim tb As TextBox() = New TextBox() {tbNo1, tbNo2}
        For i As Integer = 0 To tb.Length - 1
            Try
                myCVariables.SetCommonVariableValue(i + 1, Integer.Parse(tb(i).Text))
                tb(i).BackColor = Color.Green
            Catch
                tb(i).BackColor = Color.Red
                tb(i).Focus()
                tb(i).SelectAll()
            End Try
        Next
    End Sub
End Class