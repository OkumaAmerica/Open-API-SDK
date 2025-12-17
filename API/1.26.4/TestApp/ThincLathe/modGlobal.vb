Imports System.Reflection
Imports System.Text
Imports Okuma.CLDATAPI
Imports Okuma.CLCMDAPI
Imports Okuma.CLDATAPI.Enumerations
Imports Okuma.CLDATAPI.DataAPI
Imports Okuma.ApiLog2.CApiLog
Imports Okuma.Api.LogService.Data
Imports Okuma.CLDATAPI.Structures

Module modGlobal

    Public m_objMachine As DataAPI.CMachine

    Public m_objAxis As DataAPI.CAxis
    Public m_objAxis2 As DataAPI.CAxis
    Public m_objSpindle As DataAPI.CSpindle
    Public m_objBallScrew As DataAPI.CBallScrew
    Public m_objWorkpiece As DataAPI.CWorkpiece
    Public m_objVariables As DataAPI.CVariables
    Public m_objTool As DataAPI.CTools
    Public m_objMultiTool As DataAPI.CTools
    Public m_objSpec As DataAPI.CSpec
    Public m_objMSpindle As DataAPI.CMSpindle
    Public m_objProgram As DataAPI.CProgram
    Public m_objChuck As DataAPI.CChuck
    Public m_objTurret As DataAPI.CTurret
    Public m_objTailStock As DataAPI.CTailStock
    Public m_objATC As DataAPI.CATC
    Public m_objIO As DataAPI.CIO
    Public m_objOptionalParameter As Okuma.CLDATAPI.DataAPI.COptionalParameter
    Public m_objUserMgr As Okuma.CLDATAPI.DataAPI.CUserManagement
    Public m_objPowers As Okuma.CLDATAPI.DataAPI.CPowers

    Public m_objAlarmHistory As DataAPI.MacMan.CAlarmHistory
    Public m_objOperationHistory As DataAPI.MacMan.COperationHistory
    Public m_objOperatingHistory As DataAPI.MacMan.COperatingHistory
    Public m_objOperatingReport As DataAPI.MacMan.COperatingReport
    Public m_objMachiningReport As Okuma.CLDATAPI.DataAPI.MacMan.CMachiningReport

    Public m_objCMDTool As CommandAPI.CTools
    Public m_objCMDMachine As CommandAPI.CMachine
    Public m_objCMDProgram As CommandAPI.CProgram
    Public m_objCMDSpec As CommandAPI.CSpec
    Public m_objSimulation As CommandAPI.CSimulation
    Public m_objCmdATC As CommandAPI.CATC
    Public m_objCmdATCPanel As CommandAPI.CATCPanel
    Public m_objCmdViews As Okuma.CLCMDAPI.CommandAPI.CViews



End Module
