
Imports System.Windows
Namespace VB_WPF

    ''' <summary> Interaction logic for MainWindow.xaml </summary>
    Partial Public Class MainWindow
        Inherits Window

        Private objMMachine As Okuma.CMDATAPI.DataAPI.CMachine
        Private objMVariables As Okuma.CMDATAPI.DataAPI.CVariables

        Private objLMachine As Okuma.CLDATAPI.DataAPI.CMachine
        Private objLVariables As Okuma.CLDATAPI.DataAPI.CVariables

        Public Sub New()
            'InitializeComponent()
        End Sub

        Private Sub btnInit_Click(sender As Object, e As RoutedEventArgs)
            If RadioBtnMC.IsChecked = True Then
                Try
                    ' Create an instance of CMachine class
                    objMMachine = New Okuma.CMDATAPI.DataAPI.CMachine()

                    ' 'Init()' must be called exactly once on the main
                    '   thread from an instance of CMachine before any
                    '   API operations can take place.
                    ' Note that the instance of CMachine need not remain
                    '   after 'Init()' is called as that part of CMachine
                    '   is actually static.
                    objMMachine.Init()

                    ' Create an instance of CVariables class
                    objMVariables = New Okuma.CMDATAPI.DataAPI.CVariables()

                    doneInit()
                Catch ex As Exception
                    'Environment.Exit(0);
                    DoError(New Exception("Error initializing API: If API is installed, there should be a round" + " green icon in the task-bar that tells API version when clicked. If version is less than" + " 1.9.1, contact your distributor to request a free API upgrade.", ex))
                End Try

            ElseIf RadioBtnLathe.IsChecked = True Then
                Try
                    ' Create an instance of CMachine class
                    objLMachine = New Okuma.CLDATAPI.DataAPI.CMachine()

                    ' Call the Init method of CMachine class to initialize the  
                    ' library once for the entire application.
                    objLMachine.Init()

                    ' Create an instance of CVariables class
                    objLVariables = New Okuma.CLDATAPI.DataAPI.CVariables()

                    doneInit()
                Catch ex As Exception
                    'Environment.Exit(0);
                    DoError(New Exception("Error initializing API: If API is installed, there should be a round" + " green icon in the task-bar that tells API version when clicked. If version is less than" + " 1.9.1, contact your distributor to request a free API upgrade.", ex))
                End Try
            End If
        End Sub

        Private Sub MainWindow_UnLoad(sender As Object, e As RoutedEventArgs)
            If btn_ReadCV.IsEnabled = True Then
                ' When your application exits (finalize, onClose(), etc) you must
                ' release the connections to the THINC API using the following code:
                objMMachine.Close()
            End If
        End Sub

        Private Sub btn_ReadCV_Click(sender As Object, e As RoutedEventArgs)
            ' Do not try to get common variable 0.
            ' Doing so will cause a 'not supported' exception 
            ' because there is no common variable 0.
            Dim i As Integer = combo_CVN.SelectedIndex
            Dim value As Double = 1

            Try
                If RadioBtnMC.IsChecked = True Then
                    value = objMVariables.GetCommonVariableValue(i)
                ElseIf RadioBtnLathe.IsChecked = True Then
                    value = objLVariables.GetCommonVariableValue(i)
                End If
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
                    If RadioBtnMC.IsChecked = True Then
                        objMVariables.SetCommonVariableValue(i, value)
                    ElseIf RadioBtnLathe.IsChecked = True Then
                        objLVariables.SetCommonVariableValue(i, value)
                    End If
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

            RadioBtnLathe.IsEnabled = False
            RadioBtnMC.IsEnabled = False
            btnInit.IsEnabled = False
        End Sub
    End Class
End Namespace
