
Public Interface IOkuma
    Inherits IDisposable
    Function GetOperationMode() As OperationModeEnum
    Function ReadVariable(variableNum As Integer) As Double
    Sub WriteVariable(variableNum As Integer, newValue As Double)
End Interface
