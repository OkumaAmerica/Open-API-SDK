
Public Class API_Factory

    Public Shared Function GetAPI() As IOkuma

        If Okuma.Scout.Platform.BaseMachineType = Okuma.Scout.Enums.MachineType.L Then
            Return New OkumaLathe
        ElseIf Okuma.Scout.Platform.BaseMachineType = Okuma.Scout.Enums.MachineType.M Then
            Return New OkumaMill
        Else
            Return New OkumaSim
        End If

    End Function



End Class
