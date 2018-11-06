Class MainWindow

    Private ReadOnly _okumaAPI As IOkuma

    Public Sub New()
        InitializeComponent()

        Try
            _okumaAPI = API_Factory.GetAPI

            txtMachinePlatform.Text = $"Machine Type is {Okuma.Scout.Platform.BaseMachineType}"

            txtMachineMode.Text = $"Machine Mode is  {_okumaAPI.GetOperationMode()}"

            doneInit()
        Catch ex As Exception
            DoError(New Exception("On API init", ex))
        End Try

    End Sub

    Private Sub btn_ReadCV_Click(sender As Object, e As RoutedEventArgs)
        ' Do not try to get common variable 0.
        ' Doing so will cause a 'not supported' exception 
        ' because there is no common variable 0.
        Dim i As Integer = combo_CVN.SelectedIndex
        Dim value As Double = 1

        Try
            'Read the value of common variable 'i' using our IOkuma interface
            value = _okumaAPI.ReadVariable(i)
        Catch ex As Exception
            DoError(New Exception([String].Format("Error Reading Common Variable {0}.", i), ex))
        End Try

        txtBlockReadResult.Text = value.ToString()
    End Sub

    Private Sub btn_WriteCV_Click(sender As Object, e As RoutedEventArgs)
        Dim validate As Boolean = validateInput(txtBox_WriteVal.Text)

        If validate Then
            Dim i As Integer = combo_CVN.SelectedIndex
            Dim value As Integer = Convert.ToInt32(txtBox_WriteVal.Text)

            Try
                'Set the value of common variable 'i' to 'value' using our IOkuma interface
                _okumaAPI.WriteVariable(i, value)
            Catch ex As Exception
                DoError(New Exception([String].Format("Error Reading Common Variable {0}.", i), ex))
            End Try
        Else
            MessageBox.Show("Input Error! " + Environment.NewLine + "Blank or non-numerical input detected.")
        End If
    End Sub

    ''' <summary>
    ''' Uniformly handles display of errors to user.
    ''' </summary>
    ''' <param name="EXCEPTION"></param>
    ''' <remarks>
    ''' While not shown here, normally one would include logging in a central error handling function like this.
    ''' </remarks>
    Private Sub DoError(ex As Exception)
        MessageBox.Show("Error:  " & vbLf + ex.Message + vbLf + ex.StackTrace, System.Reflection.Assembly.GetExecutingAssembly().FullName)
    End Sub

    Private Function validateInput(s As String) As Boolean
        If s = "" Then
            Return False
        Else
            For Each c As Char In s
                If c < "0"c OrElse c > "9"c Then
                    Return False
                End If
            Next
            Return True
        End If
    End Function


    Private Sub doneInit()
        combo_CVN.IsEnabled = True
        btn_ReadCV.IsEnabled = True
        btn_WriteCV.IsEnabled = True

    End Sub


    Private Sub MainWindow_UnLoad(sender As Object, e As RoutedEventArgs)
        _okumaAPI.Dispose()
    End Sub
End Class
