Imports Okuma.CLDATAPI.Enumerations
Imports Okuma.CLDATAPI.DataAPI
Imports Okuma.CLDATAPI.Structures
Imports System.Text
Imports Okuma.CLDATAPI

Public Class CDataApi_Samples

#Region "CUserManagement - Log In/Out Samples"
    ''' <summary>
    ''' Log current user out
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub LogOut()
        Dim enErrorCode As Enumerations.UserApiErrorCodeEnum
        GotoHomeScreen()
        enErrorCode = m_objUserMgr.LogOut()
        m_objUserMgr.CheckUserErrorCode(enErrorCode)
    End Sub

    ''' <summary>
    ''' Log in with user id and password
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub LogIn(strUserId As String, strPassword As String)
        Dim enErrorCode As UserApiErrorCodeEnum
        GotoHomeScreen()

        enErrorCode = m_objUserMgr.LogIn(strUserId, strPassword)
        m_objUserMgr.CheckUserErrorCode(enErrorCode)
    End Sub

    ''' <summary>
    ''' Go to Home Screen
    ''' </summary>
    ''' <remarks>Log In/Out operation must be perforemd while NC is at Home Screen only</remarks>
    Public Shared Sub GotoHomeScreen()
        Dim objView As New Okuma.CLCMDAPI.CommandAPI.CViews
        objView.HomeScreen()
    End Sub

#End Region

#Region "CPowers.EnergyUsage Samples"
    ''' <summary>
    ''' Get energy usage give axis index, energy usage type, and system
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GetAxisEnergyUsage(ByVal enEnergyUsageAxisIndex As EnergyUsageAxisIndexEnum, ByVal energyUsageType As EnergyUsageTypeEnum, ByVal enEnergyUsageSystem As EnergyUsageSystemEnum) As Double
        Dim dblValue As Double
        dblValue = m_objPowers.GetAxisEnergyUsage(enEnergyUsageAxisIndex, energyUsageType, enEnergyUsageSystem)
        Return dblValue
    End Function

    ''' <summary>
    ''' Get total energy usage given energy usage type
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GetTotalEnergyUsage(ByVal enEnergyUsage As TotalEnergyUsageEnum, ByVal energyUsageType As EnergyUsageTypeEnum) As Double
        Dim dblValue As Double
        dblValue = m_objPowers.GetTotalEnergyUsage(enEnergyUsage, energyUsageType)
        Return dblValue
    End Function

    ''' <summary>
    ''' Get all energy usage of all axes per system and energy usage type
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub GetAllAxisEnergyUsage()
        Dim arEnergyUsageInfo As System.Array
        Dim sEnergyUsageInfo As EnergyUsageInfo
        Dim enEnergyUsageTypes() As EnergyUsageTypeEnum
        Dim enSystem As EnergyUsageSystemEnum
        Dim enEnergyUsageType As EnergyUsageSystemEnum
        Dim dblValue As Double
        Dim lstSystems As System.Collections.Generic.List(Of EnergyUsageSystemEnum)

        lstSystems = GetEnergyUsageSystems()
        enEnergyUsageTypes = System.Enum.GetValues(GetType(EnergyUsageTypeEnum))

        For Each enSystem In lstSystems
            arEnergyUsageInfo = m_objPowers.GetAxisEnergyUsageInfo(enSystem)
            For Each sEnergyUsageInfo In arEnergyUsageInfo
                For Each enEnergyUsageType In enEnergyUsageTypes
                    dblValue = GetAxisEnergyUsage(sEnergyUsageInfo.AxisIndex, enEnergyUsageType, enSystem)
                Next
            Next
        Next

    End Sub

    ''' <summary>
    ''' Get total energy usage for all available
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GetAllTotalEnergyUsage() As ArrayList
        Dim enTotalEnergyUsages() As TotalEnergyUsageEnum
        Dim enTotalEnergyUsage As TotalEnergyUsageEnum
        Dim enEnergyUsageTypes() As EnergyUsageTypeEnum
        Dim enEnergyUsageType As EnergyUsageTypeEnum
        Dim dblValue As Double
        Dim strValues As ArrayList = New ArrayList

        enEnergyUsageTypes = System.Enum.GetValues(GetType(EnergyUsageTypeEnum))
        enTotalEnergyUsages = System.Enum.GetValues(GetType(TotalEnergyUsageEnum))

        For Each enEnergyUsageType In enEnergyUsageTypes
            For Each enTotalEnergyUsage In enTotalEnergyUsages
                dblValue = GetTotalEnergyUsage(enTotalEnergyUsage, enEnergyUsageType)
                strValues.Add(String.Format("Energy Usage = {0}, Type = {1}, Value = {2}", enTotalEnergyUsage.ToString, enEnergyUsageType.ToString, dblValue))
            Next
        Next

        Return strValues

    End Function

    ''' <summary>
    ''' Get available energy usage system
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared Function GetEnergyUsageSystems() As System.Collections.Generic.List(Of EnergyUsageSystemEnum)
        Dim lstSystems As System.Collections.Generic.List(Of EnergyUsageSystemEnum) = New System.Collections.Generic.List(Of EnergyUsageSystemEnum)
        Dim enEnergyUsageSystems() As EnergyUsageSystemEnum
        Dim enSystem As EnergyUsageSystemEnum

        enEnergyUsageSystems = System.Enum.GetValues(GetType(EnergyUsageSystemEnum))

        For Each enSystem In enEnergyUsageSystems
            Select Case enSystem
                Case EnergyUsageSystemEnum.A_System
                    lstSystems.Add(enSystem)
                Case EnergyUsageSystemEnum.B_System
                    If m_objSpec.GetSpecCode(2, 0) Then lstSystems.Add(enSystem)
                Case EnergyUsageSystemEnum.C_System
                    If m_objSpec.GetBSpecCode(21, 4) And m_objSpec.GetPLCSpecCode2(61, 7) Then lstSystems.Add(enSystem)
                Case EnergyUsageSystemEnum.R_System
                    If m_objSpec.GetSpecCode(4, 2) Then lstSystems.Add(enSystem)
                Case EnergyUsageSystemEnum.L_System
                    If m_objSpec.GetSpecCode(4, 2) Then lstSystems.Add(enSystem)
            End Select
        Next

        Return lstSystems
    End Function


    ''' <summary>
    ''' Get start Date and Time of integral Energy Usage
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Function GetEnergyUsageDateTime() As String
        Dim strValue As String

        strValue = m_objPowers.GetEnergyUsageStartDateTime()

        Return strValue
    End Function

#End Region

End Class
