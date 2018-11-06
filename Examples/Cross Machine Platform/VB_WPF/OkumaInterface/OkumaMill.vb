Imports Okuma.CMDATAPI.DataAPI
Public Class OkumaMill
    Implements IOkuma

    Private _machine As CMachine
    Private _variables As CVariables

    Public Sub New()
        _machine = New CMachine()
        _machine.Init()
        _variables = New CVariables()

    End Sub

    Public Function ReadVariable(variableNum As Integer) As Double Implements IOkuma.ReadVariable

        Return _variables.GetCommonVariableValue(variableNum)

    End Function

    Public Sub WriteVariable(variableNum As Integer, newValue As Double) Implements IOkuma.WriteVariable
        _variables.SetCommonVariableValue(variableNum, newValue)
    End Sub

    Public Function GetOperationMode() As OperationModeEnum Implements IOkuma.GetOperationMode
        Return CType(_machine.GetOperationMode(), OperationModeEnum)
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        If _machine IsNot Nothing Then
            _machine.Close()
            _variables = Nothing
        End If
    End Sub
End Class
