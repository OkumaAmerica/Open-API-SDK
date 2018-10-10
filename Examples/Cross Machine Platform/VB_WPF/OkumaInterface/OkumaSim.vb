Imports VB_WPF

Public Class OkumaSim
    Implements IOkuma

    Private _variables As Dictionary(Of Integer, Double)

    Public Sub New()
        _variables = New Dictionary(Of Integer, Double)()

        For index = 1 To 200
            _variables.Add(index, 0#)
        Next

    End Sub

    Public Sub WriteVariable(variableNum As Integer, newValue As Double) Implements IOkuma.WriteVariable
        _variables(variableNum) = newValue
    End Sub

    Public Function GetOperationMode() As OperationModeEnum Implements IOkuma.GetOperationMode
        Return OperationModeEnum.Auto
    End Function

    Public Function ReadVariable(variableNum As Integer) As Double Implements IOkuma.ReadVariable
        Return _variables(variableNum)
    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        _variables.Clear()
        _variables = Nothing
    End Sub
End Class
