
Module Globals

    Private _systemShutDown As Boolean

    Public Property SystemShutDown As Boolean
        Get
            Return _systemShutDown
        End Get
        Set(value As Boolean)
            _systemShutDown = value
        End Set
    End Property

End Module