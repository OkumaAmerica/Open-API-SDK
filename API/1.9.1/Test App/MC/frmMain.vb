Imports System
Imports System.Threading
Imports System.ComponentModel
Imports System.Resources
Imports System.Globalization
Imports System.Reflection

Imports Okuma.CMDATAPI.DataAPI
Imports Okuma.CMDATAPI.Enumerations
Imports Okuma.CMDATAPI.Structures




Public Class frmMain
    Inherits System.Windows.Forms.Form
    Dim objMachine As CMachine
    Dim objAtc As CATC
    Dim objaxis As CAxis
    Dim objaxis2 As CAxis
    Dim objBS As CBallScrew
    Dim objCoolant As CCoolant
    Dim objCMOP As CMOPTool
    Dim objProgram As CProgram
    Dim objSpec As CSpec
    Dim objSpindle As CSpindle
    Dim objTools As CTools
    Dim objVariables As CVariables
    Dim objWorkPiece As CWorkpiece
    Dim objMah As MacMan.CAlarmHistory
    Dim objMor As MacMan.COperatingReport
    Dim objMoh As MacMan.COperationHistory
    Dim objMopnh As MacMan.COperatingHistory
    Dim objMeh As MacMan.CMachiningReport '--------------datazen india
    'Dim objBase As Okuma.CMCMDAPI.CommandAPI.CBase '--------------datazen india

    Dim objIO As Okuma.CMDATAPI.DataAPI.CIO
    Dim objOptionalParameter As Okuma.CMDATAPI.DataAPI.COptionalParameter

    Dim m_objToolID1 As Okuma.CMDATAPI.DataAPI.CTools2
    Dim m_objToolID2 As Okuma.CMDATAPI.DataAPI.CTools2
    Dim m_objCmdATC2 As Okuma.CMCMDAPI.CommandAPI.CATC2


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents tab_axis As System.Windows.Forms.TabPage
    Friend WithEvents tab_ballscrew As System.Windows.Forms.TabPage
    Friend WithEvents tab_machine As System.Windows.Forms.TabPage
    Friend WithEvents pot_number_lbl As System.Windows.Forms.Label
    Friend WithEvents potNumber As System.Windows.Forms.TextBox
    Friend WithEvents atcPotNumberButton As System.Windows.Forms.Button
    Friend WithEvents atcStatus As System.Windows.Forms.TextBox
    Friend WithEvents atcUpdateButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents clearLogButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents axisCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents actualFeedrate As System.Windows.Forms.TextBox
    Friend WithEvents apEncoderCoord As System.Windows.Forms.TextBox
    Friend WithEvents apMachineCoord As System.Windows.Forms.TextBox
    Friend WithEvents apProgramCoord As System.Windows.Forms.TextBox
    Friend WithEvents axisLoad As System.Windows.Forms.TextBox
    Friend WithEvents commandFeedRate As System.Windows.Forms.TextBox
    Friend WithEvents distanceTarget As System.Windows.Forms.TextBox
    Friend WithEvents targetPosition As System.Windows.Forms.TextBox
    Friend WithEvents axisName As System.Windows.Forms.TextBox
    Friend WithEvents axisType As System.Windows.Forms.TextBox
    Friend WithEvents feedHold As System.Windows.Forms.TextBox
    Friend WithEvents feedrateOverride As System.Windows.Forms.TextBox
    Friend WithEvents feedrateType As System.Windows.Forms.TextBox
    Friend WithEvents maxFeedrateOverride As System.Windows.Forms.TextBox
    Friend WithEvents axisUpdateButton As System.Windows.Forms.Button
    Friend WithEvents feedCommandOrderCombo As System.Windows.Forms.ComboBox
    Friend WithEvents feedTypeCombo As System.Windows.Forms.ComboBox
    Friend WithEvents axisTimerStart As System.Windows.Forms.Button
    Friend WithEvents AxisTimerStop As System.Windows.Forms.Button
    Friend WithEvents globalTimer As System.Windows.Forms.Timer
    Friend WithEvents tab_coolant As System.Windows.Forms.TabPage
    Friend WithEvents tab_program As System.Windows.Forms.TabPage
    Friend WithEvents tab_spec As System.Windows.Forms.TabPage
    Friend WithEvents tab_spindle As System.Windows.Forms.TabPage
    Friend WithEvents tab_tools As System.Windows.Forms.TabPage
    Friend WithEvents tab_variables As System.Windows.Forms.TabPage
    Friend WithEvents tab_workpiece As System.Windows.Forms.TabPage
    Friend WithEvents largeToolMemo As System.Windows.Forms.TextBox
    Friend WithEvents heavyToolMemo As System.Windows.Forms.TextBox
    Friend WithEvents getMemoButton As System.Windows.Forms.Button
    Friend WithEvents magazineNumber As System.Windows.Forms.TextBox
    Friend WithEvents endingPot As System.Windows.Forms.TextBox
    Friend WithEvents startingPot As System.Windows.Forms.TextBox
    Friend WithEvents getMagazineButton As System.Windows.Forms.Button
    Friend WithEvents numberOfPots As System.Windows.Forms.TextBox
    Friend WithEvents bsDataPoint As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents ballscrewAxisCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents bsInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents bsMaxPitchPoints As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents bsStartPosition As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents ballscrewUpdateButton As System.Windows.Forms.Button
    Friend WithEvents bsDataPointUpdate As System.Windows.Forms.TextBox
    Friend WithEvents bsStartPositionUpdate As System.Windows.Forms.TextBox
    Friend WithEvents bsMaxPitchPointsUpdate As System.Windows.Forms.TextBox
    Friend WithEvents bsIntervalUpdate As System.Windows.Forms.TextBox
    Friend WithEvents bsDataPointSet As System.Windows.Forms.Button
    Friend WithEvents bsIntervalAdd As System.Windows.Forms.Button
    Friend WithEvents bsIntervalSet As System.Windows.Forms.Button
    Friend WithEvents bsMaxPitchPointsAdd As System.Windows.Forms.Button
    Friend WithEvents bsMaxPicthPointsSet As System.Windows.Forms.Button
    Friend WithEvents bsStartPositionAdd As System.Windows.Forms.Button
    Friend WithEvents bsStartPositionSet As System.Windows.Forms.Button
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents machineExecutionMode As System.Windows.Forms.TextBox
    Friend WithEvents machineOperationMode As System.Windows.Forms.TextBox
    Friend WithEvents machineUnitSytem As System.Windows.Forms.TextBox
    Friend WithEvents machinePowerOnTime As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents machinePowerOnTimeUpdate As System.Windows.Forms.TextBox
    Friend WithEvents machinePowerOnTimeAdd As System.Windows.Forms.Button
    Friend WithEvents machinePowerOnTimeSet As System.Windows.Forms.Button
    Friend WithEvents machineUpdateButton As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents potToolNumber As System.Windows.Forms.TextBox
    Friend WithEvents potToolKind As System.Windows.Forms.TextBox
    Friend WithEvents coolantUpdateButton As System.Windows.Forms.Button
    Friend WithEvents coolantChipCondition As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents mopAxisCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents mopPositionTypeCombo As System.Windows.Forms.ComboBox
    Friend WithEvents mopToolNumber As System.Windows.Forms.TextBox
    Friend WithEvents mopUpdateButton As System.Windows.Forms.Button
    Friend WithEvents mopAircutReduction As System.Windows.Forms.TextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents mopAircutOverride As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents mopAdaptiveControl As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents mopAlarms As System.Windows.Forms.TextBox
    Friend WithEvents mopALVValue As System.Windows.Forms.TextBox
    Friend WithEvents mopUnusualSignal As System.Windows.Forms.TextBox
    Friend WithEvents mopAutoChange As System.Windows.Forms.TextBox
    Friend WithEvents mopCuttingLoad As System.Windows.Forms.TextBox
    Friend WithEvents mopCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopLimitValue As System.Windows.Forms.TextBox
    Friend WithEvents mopLLValue As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents mopMaxOverride As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents mopMinOverride As System.Windows.Forms.TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents mopOverloadMonitor As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents mopReferenceValue As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents progUpdateButton As System.Windows.Forms.Button
    Friend WithEvents progNoParams As System.Windows.Forms.TextBox
    Friend WithEvents label99 As System.Windows.Forms.Label
    Friend WithEvents progExecCombo As System.Windows.Forms.ComboBox
    Friend WithEvents progExecutingBlock As System.Windows.Forms.TextBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents progExecutePoint As System.Windows.Forms.TextBox
    Friend WithEvents progRead As System.Windows.Forms.TextBox
    Friend WithEvents progColumn As System.Windows.Forms.TextBox
    Friend WithEvents progRow As System.Windows.Forms.TextBox
    Friend WithEvents progButtonExecBlock As System.Windows.Forms.Button
    Friend WithEvents progButtonGetRunProgram As System.Windows.Forms.Button
    Friend WithEvents progRunningPrograms As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents specCode As System.Windows.Forms.TextBox
    Friend WithEvents specUpdateButton As System.Windows.Forms.Button
    Friend WithEvents specCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents spinUpdate As System.Windows.Forms.Button
    Friend WithEvents spinRateOverride As System.Windows.Forms.TextBox
    Friend WithEvents spinLoad As System.Windows.Forms.TextBox
    Friend WithEvents spinOilMist As System.Windows.Forms.TextBox
    Friend WithEvents spinMaxOverrideRate As System.Windows.Forms.TextBox
    Friend WithEvents spinCommandRate As System.Windows.Forms.TextBox
    Friend WithEvents spinActualRate As System.Windows.Forms.TextBox
    Friend WithEvents spinState As System.Windows.Forms.TextBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents tulReferenceToolOffset3 As System.Windows.Forms.TextBox
    Friend WithEvents tulReferenceToolOffset2 As System.Windows.Forms.TextBox
    Friend WithEvents tulPotNumber As System.Windows.Forms.TextBox
    Friend WithEvents tulToolGroup As System.Windows.Forms.TextBox
    Friend WithEvents tulToolMode As System.Windows.Forms.TextBox
    Friend WithEvents tulCutterRCompWearOffset As System.Windows.Forms.TextBox
    Friend WithEvents tulCutterRCompOffset As System.Windows.Forms.TextBox
    Friend WithEvents tulToolStatus As System.Windows.Forms.TextBox
    Friend WithEvents tulToolGroupOrder As System.Windows.Forms.TextBox
    Friend WithEvents tulToolKind As System.Windows.Forms.TextBox
    Friend WithEvents tulToolLengthOffset As System.Windows.Forms.TextBox
    Friend WithEvents tulToolLengthWearOffset As System.Windows.Forms.TextBox
    Friend WithEvents tulToolLife As System.Windows.Forms.TextBox
    Friend WithEvents tulToolLifeRemaining As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdateButton As System.Windows.Forms.Button
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents tulToolNumber As System.Windows.Forms.TextBox
    Friend WithEvents label100 As System.Windows.Forms.Label
    Friend WithEvents tulUpdReferenceToolOffset3 As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdReferenceToolOffset2 As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdToolGroup As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdCutterRCompWearOffset As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdCutterRCompOffset As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdToolLengthOffset As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdToolLengthWearOffset As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdToolLife As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdToolLifeRemaining As System.Windows.Forms.TextBox
    Friend WithEvents tulUpdateButtonNoParam As System.Windows.Forms.Button
    Friend WithEvents tulUpdToolMode As System.Windows.Forms.ComboBox
    Friend WithEvents tulUpdToolGroupOrder As System.Windows.Forms.ComboBox
    Friend WithEvents tulUpdToolStatus As System.Windows.Forms.ComboBox
    Friend WithEvents tulSetCutterRCompWearOffset As System.Windows.Forms.Button
    Friend WithEvents tulSetCutterRCompOffset As System.Windows.Forms.Button
    Friend WithEvents tulSetToolMode As System.Windows.Forms.Button
    Friend WithEvents tulSetToolGroup As System.Windows.Forms.Button
    Friend WithEvents tulSetReferenceToolOffset3 As System.Windows.Forms.Button
    Friend WithEvents tulSetReferenceToolOffset2 As System.Windows.Forms.Button
    Friend WithEvents tulSetToolStatus As System.Windows.Forms.Button
    Friend WithEvents tulSetToolGroupOrder As System.Windows.Forms.Button
    Friend WithEvents tulCalToolLengthOffset As System.Windows.Forms.Button
    Friend WithEvents tulSetToolLengthOffset As System.Windows.Forms.Button
    Friend WithEvents tulCalToolLengthWearOffset As System.Windows.Forms.Button
    Friend WithEvents tulAddToolLengthWearOffset As System.Windows.Forms.Button
    Friend WithEvents tulSetToolLengthWearOffset As System.Windows.Forms.Button
    Friend WithEvents tulSetToolLife As System.Windows.Forms.Button
    Friend WithEvents tulSetToolLifeRemaining As System.Windows.Forms.Button
    Friend WithEvents tulAddToolLengthOffset As System.Windows.Forms.Button
    Friend WithEvents tulNoParam As System.Windows.Forms.TextBox
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents varValueUpdate As System.Windows.Forms.TextBox
    Friend WithEvents varAddValue As System.Windows.Forms.Button
    Friend WithEvents varSetValue As System.Windows.Forms.Button
    Friend WithEvents varEnd As System.Windows.Forms.TextBox
    Friend WithEvents varBegin As System.Windows.Forms.TextBox
    Friend WithEvents varGetAllResults As System.Windows.Forms.TextBox
    Friend WithEvents varNumberOfVars As System.Windows.Forms.TextBox
    Friend WithEvents varGetAllButton As System.Windows.Forms.Button
    Friend WithEvents varCommonVarNumber As System.Windows.Forms.TextBox
    Friend WithEvents varUpdateButton As System.Windows.Forms.Button
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents varValue As System.Windows.Forms.TextBox
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents wkCounterCombo As System.Windows.Forms.ComboBox
    Friend WithEvents wkUpdateCounter As System.Windows.Forms.TextBox
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents wkCounterValue As System.Windows.Forms.TextBox
    Friend WithEvents wkAxisCombo As System.Windows.Forms.ComboBox
    Friend WithEvents Label96 As System.Windows.Forms.Label
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents wkButtonZeroOffsetCal As System.Windows.Forms.Button
    Friend WithEvents wkButtonZeroOffsetAdd As System.Windows.Forms.Button
    Friend WithEvents wkButtonZeroOffsetSet As System.Windows.Forms.Button
    Friend WithEvents wkUpdateZeroOffset As System.Windows.Forms.TextBox
    Friend WithEvents wkZeroOffset As System.Windows.Forms.TextBox
    Friend WithEvents wkCounterSetButton As System.Windows.Forms.Button
    Friend WithEvents wkUpdateValsWithNoParams As System.Windows.Forms.Button
    Friend WithEvents wkValsWithoutParameters As System.Windows.Forms.TextBox
    Friend WithEvents wkButtonZeroOffsetGet As System.Windows.Forms.Button
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents wkButtonGetCounter As System.Windows.Forms.Button
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents wkOffsetNumber As System.Windows.Forms.TextBox
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents tab_atc As System.Windows.Forms.TabPage
    Friend WithEvents tab_MacManAlarmHistory As System.Windows.Forms.TabPage
    Friend WithEvents tab_MacmanOperatingReport As System.Windows.Forms.TabPage
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents mahAlarmIndex As System.Windows.Forms.TextBox
    Friend WithEvents mahAlarmCount As System.Windows.Forms.TextBox
    Friend WithEvents mahAlarmTime As System.Windows.Forms.TextBox
    Friend WithEvents mahAlarmNumber As System.Windows.Forms.TextBox
    Friend WithEvents mahAlarmMessage As System.Windows.Forms.TextBox
    Friend WithEvents mahAlarmDate As System.Windows.Forms.TextBox
    Friend WithEvents mahAlarmCode As System.Windows.Forms.TextBox
    Friend WithEvents mahUpdateButton As System.Windows.Forms.Button
    Friend WithEvents mahMaxAlarmCount As System.Windows.Forms.TextBox
    Friend WithEvents mohUpdateButton As System.Windows.Forms.Button
    Friend WithEvents mohOperationIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents mohOperationTime As System.Windows.Forms.TextBox
    Friend WithEvents Label116 As System.Windows.Forms.Label
    Friend WithEvents mohOperationDate As System.Windows.Forms.TextBox
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents mohOperationData As System.Windows.Forms.TextBox
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents mohOperationMaxCount As System.Windows.Forms.TextBox
    Friend WithEvents Label119 As System.Windows.Forms.Label
    Friend WithEvents mohOperationCount As System.Windows.Forms.TextBox
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents atcSetLargeToolMemo As System.Windows.Forms.Button
    Friend WithEvents atcSetHeavyToolMemo As System.Windows.Forms.Button
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents atcMagazinePosition As System.Windows.Forms.TextBox
    Friend WithEvents bsDataPointAdd As System.Windows.Forms.Button
    Friend WithEvents bsPecPoint As System.Windows.Forms.TextBox
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents Label121 As System.Windows.Forms.Label
    Friend WithEvents Label123 As System.Windows.Forms.Label
    Friend WithEvents Label124 As System.Windows.Forms.Label
    Friend WithEvents Label125 As System.Windows.Forms.Label
    Friend WithEvents Label126 As System.Windows.Forms.Label
    Friend WithEvents Label127 As System.Windows.Forms.Label
    Friend WithEvents Label128 As System.Windows.Forms.Label
    Friend WithEvents wkZeroTo As System.Windows.Forms.TextBox
    Friend WithEvents wkZeroFrom As System.Windows.Forms.TextBox
    Friend WithEvents wkZeroResults As System.Windows.Forms.TextBox
    Friend WithEvents Label129 As System.Windows.Forms.Label
    Friend WithEvents tulButtonCutterRLengthOffset As System.Windows.Forms.Button
    Friend WithEvents tulButtonCutterROffset As System.Windows.Forms.Button
    Friend WithEvents tulButtonLengthWearOffset As System.Windows.Forms.Button
    Friend WithEvents tulButtonLengthOffset As System.Windows.Forms.Button
    Friend WithEvents tulTo As System.Windows.Forms.TextBox
    Friend WithEvents tulFrom As System.Windows.Forms.TextBox
    Friend WithEvents tulResults As System.Windows.Forms.TextBox
    Friend WithEvents Label131 As System.Windows.Forms.Label
    Friend WithEvents Label132 As System.Windows.Forms.Label
    Friend WithEvents mohTo As System.Windows.Forms.TextBox
    Friend WithEvents mohFrom As System.Windows.Forms.TextBox
    Friend WithEvents mohResults As System.Windows.Forms.TextBox
    Friend WithEvents mohButtonResults As System.Windows.Forms.Button
    Friend WithEvents mahTo As System.Windows.Forms.TextBox
    Friend WithEvents Label133 As System.Windows.Forms.Label
    Friend WithEvents mahFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label134 As System.Windows.Forms.Label
    Friend WithEvents mahButtonResults As System.Windows.Forms.Button
    Friend WithEvents mopSetULValue As System.Windows.Forms.TextBox
    Friend WithEvents mopSetToolDataInputMode As System.Windows.Forms.TextBox
    Friend WithEvents mopSetReferenceValue As System.Windows.Forms.TextBox
    Friend WithEvents mopSetOverloadMonitor As System.Windows.Forms.TextBox
    Friend WithEvents mopSetMinOverride As System.Windows.Forms.TextBox
    Friend WithEvents mopSetMaxOverride As System.Windows.Forms.TextBox
    Friend WithEvents mopSetLLValue As System.Windows.Forms.TextBox
    Friend WithEvents mopSetLimitValue As System.Windows.Forms.TextBox
    Friend WithEvents mopSetCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopSetAutoChange As System.Windows.Forms.TextBox
    Friend WithEvents mopSetUnusualSignal As System.Windows.Forms.TextBox
    Friend WithEvents mopSetALVValue As System.Windows.Forms.TextBox
    Friend WithEvents mopSetAircutReduction As System.Windows.Forms.TextBox
    Friend WithEvents mopSetAircutOverride As System.Windows.Forms.TextBox
    Friend WithEvents mopSetAdaptiveControl As System.Windows.Forms.TextBox
    Friend WithEvents mopUlValue As System.Windows.Forms.TextBox
    Friend WithEvents mopToolDataInputMode As System.Windows.Forms.TextBox
    Friend WithEvents mopSignalDiffAlarm As System.Windows.Forms.TextBox
    Friend WithEvents mopButtonULValue As System.Windows.Forms.Button
    Friend WithEvents mopButtonToolDataInput As System.Windows.Forms.Button
    Friend WithEvents mopButtonReferenceValue As System.Windows.Forms.Button
    Friend WithEvents mopButtonOverloadMonitor As System.Windows.Forms.Button
    Friend WithEvents mopButtonMinOverride As System.Windows.Forms.Button
    Friend WithEvents mopButtonMaxOverride As System.Windows.Forms.Button
    Friend WithEvents mopButtonLLValue As System.Windows.Forms.Button
    Friend WithEvents mopButtonLimitValue As System.Windows.Forms.Button
    Friend WithEvents mopButtonCuttingTime As System.Windows.Forms.Button
    Friend WithEvents mopbuttonAutoChange As System.Windows.Forms.Button
    Friend WithEvents mopButtonUnusualSignalChange As System.Windows.Forms.Button
    Friend WithEvents mopButtonALVValue As System.Windows.Forms.Button
    Friend WithEvents mopButtonAircutReduction As System.Windows.Forms.Button
    Friend WithEvents mopButtonAircutOverride As System.Windows.Forms.Button
    Friend WithEvents mopButtonAdaptiveControl As System.Windows.Forms.Button
    Friend WithEvents atcComboToolAttribute As System.Windows.Forms.ComboBox
    Friend WithEvents Label135 As System.Windows.Forms.Label
    Friend WithEvents Label136 As System.Windows.Forms.Label
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents atcButtonRegister As System.Windows.Forms.Button
    Friend WithEvents atcButtonRegisterAttribute As System.Windows.Forms.Button
    Friend WithEvents atcButtonUnRegister As System.Windows.Forms.Button
    Friend WithEvents atcButtonCancelTool As System.Windows.Forms.Button
    Friend WithEvents atcCMDToolNumber As System.Windows.Forms.TextBox
    Friend WithEvents atcCMDPotNumber As System.Windows.Forms.TextBox
    Friend WithEvents progSelectProgramButton As System.Windows.Forms.Button
    Friend WithEvents Label146 As System.Windows.Forms.Label
    Friend WithEvents prog3 As System.Windows.Forms.TextBox
    Friend WithEvents Label147 As System.Windows.Forms.Label
    Friend WithEvents prog2 As System.Windows.Forms.TextBox
    Friend WithEvents Label148 As System.Windows.Forms.Label
    Friend WithEvents prog1 As System.Windows.Forms.TextBox
    Friend WithEvents Label149 As System.Windows.Forms.Label
    Friend WithEvents Label150 As System.Windows.Forms.Label
    Friend WithEvents bsDataUnitSet As System.Windows.Forms.Button
    Friend WithEvents ballscrewDataUnitCombo As System.Windows.Forms.ComboBox
    Friend WithEvents tulDataUnitCombo As System.Windows.Forms.ComboBox
    Friend WithEvents tulSetDataUnit As System.Windows.Forms.Button
    Friend WithEvents Label151 As System.Windows.Forms.Label
    Friend WithEvents Label152 As System.Windows.Forms.Label
    Friend WithEvents wkDataUnitCombo As System.Windows.Forms.ComboBox
    Friend WithEvents wkSetDataUnitButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents Label190 As System.Windows.Forms.Label
    Friend WithEvents Label191 As System.Windows.Forms.Label
    Friend WithEvents Label192 As System.Windows.Forms.Label
    Friend WithEvents Label193 As System.Windows.Forms.Label
    Friend WithEvents Label194 As System.Windows.Forms.Label
    Friend WithEvents Label195 As System.Windows.Forms.Label
    Friend WithEvents Label196 As System.Windows.Forms.Label
    Friend WithEvents Label197 As System.Windows.Forms.Label
    Friend WithEvents Label198 As System.Windows.Forms.Label
    Friend WithEvents Label199 As System.Windows.Forms.Label
    Friend WithEvents Label200 As System.Windows.Forms.Label
    Friend WithEvents Label201 As System.Windows.Forms.Label
    Friend WithEvents Label202 As System.Windows.Forms.Label
    Friend WithEvents objMopnhUpdateButton As System.Windows.Forms.Button
    Friend WithEvents mopnhAlarmOnTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhSpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhMaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPartWaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhInProSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhNonOperatingReport As System.Windows.Forms.TextBox
    Friend WithEvents mopnhCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhTo As System.Windows.Forms.TextBox
    Friend WithEvents mopnhFrom As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label214 As System.Windows.Forms.Label
    Friend WithEvents Label215 As System.Windows.Forms.Label
    Friend WithEvents Label216 As System.Windows.Forms.Label
    Friend WithEvents Label217 As System.Windows.Forms.Label
    Friend WithEvents Label218 As System.Windows.Forms.Label
    Friend WithEvents Label219 As System.Windows.Forms.Label
    Friend WithEvents Label220 As System.Windows.Forms.Label
    Friend WithEvents Label221 As System.Windows.Forms.Label
    Friend WithEvents Label222 As System.Windows.Forms.Label
    Friend WithEvents Label223 As System.Windows.Forms.Label
    Friend WithEvents Label224 As System.Windows.Forms.Label
    Friend WithEvents Label203 As System.Windows.Forms.Label
    Friend WithEvents mopnhPrevRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevNonOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevInProSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevPartWaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevMaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevSpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhPrevAlarmonTime As System.Windows.Forms.TextBox
    Friend WithEvents mopnhMaxNoofReports As System.Windows.Forms.TextBox
    Friend WithEvents Label204 As System.Windows.Forms.Label
    Friend WithEvents Label205 As System.Windows.Forms.Label
    Friend WithEvents tulToolLifeRemainSec As System.Windows.Forms.TextBox
    Friend WithEvents axisDataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents axisSetDataUnit As System.Windows.Forms.Button
    Friend WithEvents Label206 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Txt_mdicommand As System.Windows.Forms.TextBox
    Friend WithEvents cmd_InputMDI As System.Windows.Forms.Button
    Friend WithEvents Tab_View As System.Windows.Forms.TabPage
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Label231 As System.Windows.Forms.Label
    Friend WithEvents Cmb_ChangeScreen As System.Windows.Forms.ComboBox
    Friend WithEvents cmd_ChangeScreen As System.Windows.Forms.Button
    Friend WithEvents Label232 As System.Windows.Forms.Label
    Friend WithEvents txt_screenname As System.Windows.Forms.TextBox
    Friend WithEvents Label233 As System.Windows.Forms.Label
    Friend WithEvents TXT_GetMaxMOPToolData As System.Windows.Forms.TextBox
    Friend WithEvents cmd_WorkpieceAdd As System.Windows.Forms.Button
    Friend WithEvents txt_RelativeActualPositionProgramCoord As System.Windows.Forms.TextBox
    Friend WithEvents Label234 As System.Windows.Forms.Label
    Friend WithEvents cboFileReadModeEnum As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents mopDelete As System.Windows.Forms.Button
    Friend WithEvents mopEdit As System.Windows.Forms.Button
    Friend WithEvents Label139 As System.Windows.Forms.Label
    Friend WithEvents mopCMDClassNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label140 As System.Windows.Forms.Label
    Friend WithEvents mopCMDToolNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label122 As System.Windows.Forms.Label
    Friend WithEvents mopToolDataNumber As System.Windows.Forms.TextBox
    Friend WithEvents morMaxNoOfOpReport As System.Windows.Forms.TextBox
    Friend WithEvents Label288 As System.Windows.Forms.Label
    Friend WithEvents morUpdateButton As System.Windows.Forms.Button
    Friend WithEvents morOperatingStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label289 As System.Windows.Forms.Label
    Friend WithEvents morNonoperatingCondition As System.Windows.Forms.TextBox
    Friend WithEvents Label290 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents morPrevExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevDateOfOperatingRept As System.Windows.Forms.TextBox
    Friend WithEvents morPrevAlarmOnTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevSpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevMaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevPartwaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevInProSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevNonOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents morPrevRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents Label276 As System.Windows.Forms.Label
    Friend WithEvents Label277 As System.Windows.Forms.Label
    Friend WithEvents Label278 As System.Windows.Forms.Label
    Friend WithEvents Label279 As System.Windows.Forms.Label
    Friend WithEvents Label280 As System.Windows.Forms.Label
    Friend WithEvents Label281 As System.Windows.Forms.Label
    Friend WithEvents Label282 As System.Windows.Forms.Label
    Friend WithEvents Label283 As System.Windows.Forms.Label
    Friend WithEvents Label284 As System.Windows.Forms.Label
    Friend WithEvents Label285 As System.Windows.Forms.Label
    Friend WithEvents Label286 As System.Windows.Forms.Label
    Friend WithEvents Label287 As System.Windows.Forms.Label
    Friend WithEvents morPrevOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label240 As System.Windows.Forms.Label
    Friend WithEvents morOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents Label264 As System.Windows.Forms.Label
    Friend WithEvents Label265 As System.Windows.Forms.Label
    Friend WithEvents Label266 As System.Windows.Forms.Label
    Friend WithEvents Label267 As System.Windows.Forms.Label
    Friend WithEvents Label268 As System.Windows.Forms.Label
    Friend WithEvents Label269 As System.Windows.Forms.Label
    Friend WithEvents morRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents morCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents morNonOPeratingTime As System.Windows.Forms.TextBox
    Friend WithEvents morInProSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents morNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents morPartWaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents Label270 As System.Windows.Forms.Label
    Friend WithEvents mormaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents Label271 As System.Windows.Forms.Label
    Friend WithEvents morOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents Label272 As System.Windows.Forms.Label
    Friend WithEvents morSpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents Label273 As System.Windows.Forms.Label
    Friend WithEvents morExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents morAlarmOnTime As System.Windows.Forms.TextBox
    Friend WithEvents Label274 As System.Windows.Forms.Label
    Friend WithEvents morDateOfOperatingReport As System.Windows.Forms.TextBox
    Friend WithEvents Label275 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents morPeriodDateOfOperatingReport As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodAlarmOnTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodSpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodMaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodPartWaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodInproSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodNonOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents morPeriodRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents Label130 As System.Windows.Forms.Label
    Friend WithEvents Label141 As System.Windows.Forms.Label
    Friend WithEvents Label153 As System.Windows.Forms.Label
    Friend WithEvents Label154 As System.Windows.Forms.Label
    Friend WithEvents Label155 As System.Windows.Forms.Label
    Friend WithEvents Label237 As System.Windows.Forms.Label
    Friend WithEvents Label238 As System.Windows.Forms.Label
    Friend WithEvents morPeriodOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents Label239 As System.Windows.Forms.Label
    Friend WithEvents grdMMMachiningReports As System.Windows.Forms.DataGrid
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtMachiningReport_NoOfWork As System.Windows.Forms.TextBox
    Friend WithEvents Label156 As System.Windows.Forms.Label
    Friend WithEvents MacreportTime As System.Windows.Forms.TextBox
    Friend WithEvents Label245 As System.Windows.Forms.Label
    Friend WithEvents txtto As System.Windows.Forms.TextBox
    Friend WithEvents Label158 As System.Windows.Forms.Label
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label159 As System.Windows.Forms.Label
    Friend WithEvents macreport_result As System.Windows.Forms.Button
    Friend WithEvents Label160 As System.Windows.Forms.Label
    Friend WithEvents Cmb_rptPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents MacReport_programname As System.Windows.Forms.TextBox
    Friend WithEvents Label161 As System.Windows.Forms.Label
    Friend WithEvents Macreport_filename As System.Windows.Forms.TextBox
    Friend WithEvents Label162 As System.Windows.Forms.Label
    Friend WithEvents MacReport_count As System.Windows.Forms.TextBox
    Friend WithEvents Label163 As System.Windows.Forms.Label
    Friend WithEvents macReportUpdateButton As System.Windows.Forms.Button
    Friend WithEvents MacReport_Index As System.Windows.Forms.TextBox
    Friend WithEvents Label164 As System.Windows.Forms.Label
    Friend WithEvents macreport_Operatingtime As System.Windows.Forms.TextBox
    Friend WithEvents Label225 As System.Windows.Forms.Label
    Friend WithEvents macreport_Runningtime As System.Windows.Forms.TextBox
    Friend WithEvents Label226 As System.Windows.Forms.Label
    Friend WithEvents Macreportdate As System.Windows.Forms.TextBox
    Friend WithEvents Label227 As System.Windows.Forms.Label
    Friend WithEvents macreport_maxcount As System.Windows.Forms.TextBox
    Friend WithEvents Label228 As System.Windows.Forms.Label
    Friend WithEvents macreport_cuttingtime As System.Windows.Forms.TextBox
    Friend WithEvents Label229 As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGetMachineZeroOffset As System.Windows.Forms.Button
    Friend WithEvents cmdSetMachineZeroOffset As System.Windows.Forms.Button
    Friend WithEvents cmdAddMachineZeroOffset As System.Windows.Forms.Button
    Friend WithEvents txtOutputMachineZeroOffset As System.Windows.Forms.TextBox
    Friend WithEvents Label142 As System.Windows.Forms.Label
    Friend WithEvents txtInputMachineZeroOffset As System.Windows.Forms.TextBox
    Friend WithEvents cboMachineZeroOffsetAxis As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCalMachineZeroOffset As System.Windows.Forms.Button
    Friend WithEvents cboMachineDataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents cmdMachineDataUnit As System.Windows.Forms.Button
    Friend WithEvents txtMachineSerial As System.Windows.Forms.TextBox
    Friend WithEvents txtMachineName As System.Windows.Forms.TextBox
    Friend WithEvents Label144 As System.Windows.Forms.Label
    Friend WithEvents Label143 As System.Windows.Forms.Label
    Friend WithEvents cmdCancelProgram As System.Windows.Forms.Button
    Friend WithEvents txtPanelMode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents grdMMAlarmHistory As System.Windows.Forms.DataGrid
    Friend WithEvents txtAlarmObject As System.Windows.Forms.TextBox
    Friend WithEvents Label145 As System.Windows.Forms.Label
    Friend WithEvents tulAddCutterRCompOffset As System.Windows.Forms.Button
    Friend WithEvents tulAddCutterRCompWearOffset As System.Windows.Forms.Button
    Friend WithEvents tab_axis2 As System.Windows.Forms.TabPage
    Friend WithEvents tab_PLC As System.Windows.Forms.TabPage
    Friend WithEvents tab_OptionalParameter As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOptionalParameterBitGet As System.Windows.Forms.Button
    Friend WithEvents cmdOptionalParameterWordGet As System.Windows.Forms.Button
    Friend WithEvents cmdOptionalParameterLongWordGet As System.Windows.Forms.Button
    Friend WithEvents txtOptionalParameterLongWord As System.Windows.Forms.TextBox
    Friend WithEvents txtOptionalParameterWord As System.Windows.Forms.TextBox
    Friend WithEvents txtOptionalParameterBit As System.Windows.Forms.TextBox
    Friend WithEvents Label299 As System.Windows.Forms.Label
    Friend WithEvents txtOptionalParameterBitNo As System.Windows.Forms.TextBox
    Friend WithEvents Label300 As System.Windows.Forms.Label
    Friend WithEvents txtOptionalParameterLongWordIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label301 As System.Windows.Forms.Label
    Friend WithEvents txtOptionalParameterWordIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label302 As System.Windows.Forms.Label
    Friend WithEvents txtOptionalParameterBitIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label303 As System.Windows.Forms.Label
    Friend WithEvents grpIOVariables As System.Windows.Forms.GroupBox
    Friend WithEvents Label297 As System.Windows.Forms.Label
    Friend WithEvents cboIOVariableTypes As System.Windows.Forms.ComboBox
    Friend WithEvents cmdIOGetBit As System.Windows.Forms.Button
    Friend WithEvents cmdIOGetWord As System.Windows.Forms.Button
    Friend WithEvents cmdIOGetLongWord As System.Windows.Forms.Button
    Friend WithEvents txtIOLongWord As System.Windows.Forms.TextBox
    Friend WithEvents txtIOWord As System.Windows.Forms.TextBox
    Friend WithEvents txtIOBit As System.Windows.Forms.TextBox
    Friend WithEvents Label296 As System.Windows.Forms.Label
    Friend WithEvents txtIOBitNo As System.Windows.Forms.TextBox
    Friend WithEvents Label295 As System.Windows.Forms.Label
    Friend WithEvents txtIOLongWordIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label294 As System.Windows.Forms.Label
    Friend WithEvents txtIOWordIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label293 As System.Windows.Forms.Label
    Friend WithEvents txtIOBitIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label292 As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label291 As System.Windows.Forms.Label
    Friend WithEvents cboUserParameterVariableLimitCoordinate As System.Windows.Forms.ComboBox
    Friend WithEvents txtUserParameterLimitInput As System.Windows.Forms.TextBox
    Friend WithEvents txtUserParameterLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label157 As System.Windows.Forms.Label
    Friend WithEvents cmdUserParameterVariableLimitAdd As System.Windows.Forms.Button
    Friend WithEvents cmdUserParameterVariableLimitSet As System.Windows.Forms.Button
    Friend WithEvents cmdUserParameterVariableLimitGet As System.Windows.Forms.Button
    Friend WithEvents Label165 As System.Windows.Forms.Label
    Friend WithEvents cboUserParameterVariableLimitAxis As System.Windows.Forms.ComboBox
    Friend WithEvents cmdAxis2DataUnit As System.Windows.Forms.Button
    Friend WithEvents cboAxis2DataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents tab_Program2 As System.Windows.Forms.TabPage
    Friend WithEvents Label168 As System.Windows.Forms.Label
    Friend WithEvents Label167 As System.Windows.Forms.Label
    Friend WithEvents Label166 As System.Windows.Forms.Label
    Friend WithEvents cmdSetProgramNameMCodeCall As System.Windows.Forms.Button
    Friend WithEvents cmdGetProgramNameMCodeCall As System.Windows.Forms.Button
    Friend WithEvents cmdSetProgramNameGCodeMod As System.Windows.Forms.Button
    Friend WithEvents cmdGetProgramNameGCodeMod As System.Windows.Forms.Button
    Friend WithEvents txtProgramNameInput As System.Windows.Forms.TextBox
    Friend WithEvents txtProgramNameOutput As System.Windows.Forms.TextBox
    Friend WithEvents txtGMCode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents Label170 As System.Windows.Forms.Label
    Friend WithEvents txtSpecCodeBit As System.Windows.Forms.TextBox
    Friend WithEvents Label169 As System.Windows.Forms.Label
    Friend WithEvents txtSpecCodeIndex As System.Windows.Forms.TextBox
    Friend WithEvents cmdGetSpecCode As System.Windows.Forms.Button
    Friend WithEvents txtSpecCode As System.Windows.Forms.TextBox
    Friend WithEvents cmdGetBSpecCode As System.Windows.Forms.Button
    Friend WithEvents cmdSetActualTool As System.Windows.Forms.Button
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSetNextTool As System.Windows.Forms.Button
    Friend WithEvents cmdSetReturnPot As System.Windows.Forms.Button
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSelectScheduleProgram As System.Windows.Forms.Button
    Friend WithEvents cmdBitSet As System.Windows.Forms.Button
    Friend WithEvents cmdWordSet As System.Windows.Forms.Button
    Friend WithEvents cmdLongWordSet As System.Windows.Forms.Button
    Friend WithEvents cmdWordAdd As System.Windows.Forms.Button
    Friend WithEvents cmdLongWordAdd As System.Windows.Forms.Button
    Friend WithEvents txtLongWordInput As System.Windows.Forms.TextBox
    Friend WithEvents txtWordInput As System.Windows.Forms.TextBox
    Friend WithEvents txtBitInput As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents Label171 As System.Windows.Forms.Label
    Friend WithEvents Label172 As System.Windows.Forms.Label
    Friend WithEvents Label173 As System.Windows.Forms.Label
    Friend WithEvents Label174 As System.Windows.Forms.Label
    Friend WithEvents Label175 As System.Windows.Forms.Label
    Friend WithEvents txtSR_RelativeBlock As System.Windows.Forms.TextBox
    Friend WithEvents txtSR_SequenceBlockNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtSR_RepeatNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboSR_AxisMovementOrder As System.Windows.Forms.ComboBox
    Friend WithEvents cboSR_MIDBlockRestart As System.Windows.Forms.ComboBox
    Friend WithEvents cmdReturnSearch As System.Windows.Forms.Button
    Friend WithEvents Label176 As System.Windows.Forms.Label
    Friend WithEvents Label177 As System.Windows.Forms.Label
    Friend WithEvents Label179 As System.Windows.Forms.Label
    Friend WithEvents Label180 As System.Windows.Forms.Label
    Friend WithEvents Label181 As System.Windows.Forms.Label
    Friend WithEvents Label182 As System.Windows.Forms.Label
    Friend WithEvents Label184 As System.Windows.Forms.Label
    Friend WithEvents Label185 As System.Windows.Forms.Label
    Friend WithEvents Label187 As System.Windows.Forms.Label
    Friend WithEvents Label188 As System.Windows.Forms.Label
    Friend WithEvents Label189 As System.Windows.Forms.Label
    Friend WithEvents cmdToolID_CutterRCompWearOffset_Add As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_DataUnit_Set As System.Windows.Forms.Button
    Friend WithEvents cboToolID_DataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents cboToolID_ToolLifeMode As System.Windows.Forms.ComboBox
    Friend WithEvents cmdToolID_ToolLifeMode_Set As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_CutterRCompWearOffset_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_CutterRCompWearOffsetValue As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_PotNo As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_ToolLifeMode As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_CutterRCompWearOffset As System.Windows.Forms.TextBox
    Friend WithEvents Label207 As System.Windows.Forms.Label
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdToolID_CutterRCompOffset1_Add As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_LengthOffset1_Add As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_LengthOffset1_Cal As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_LengthOffset1_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_LengthOffset1Value As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_LengthOffset1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdToolID_CutterRCompOffset1_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_CutterRCompOffset1Value As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_CutterRCompOffset1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdToolID_CutterRCompOffset2_Add As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_CutterRCompOffset2_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_CutterRCompOffset2Value As System.Windows.Forms.TextBox
    Friend WithEvents Label208 As System.Windows.Forms.Label
    Friend WithEvents txtToolID_CutterRCompOffset2 As System.Windows.Forms.TextBox
    Friend WithEvents cmdToolID_CutterRCompOffset3_Add As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_CutterRCompOffset3_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_CutterRCompOffset3Value As System.Windows.Forms.TextBox
    Friend WithEvents Label209 As System.Windows.Forms.Label
    Friend WithEvents txtToolID_CutterRCompOffset3 As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_LengthOffset2 As System.Windows.Forms.TextBox
    Friend WithEvents Label210 As System.Windows.Forms.Label
    Friend WithEvents cmdToolID_LengthOffset2_Add As System.Windows.Forms.Button
    Friend WithEvents txtToolID_LengthOffset2Value As System.Windows.Forms.TextBox
    Friend WithEvents cmdToolID_LengthOffset2_Set As System.Windows.Forms.Button
    Friend WithEvents Label211 As System.Windows.Forms.Label
    Friend WithEvents cmdToolID_LengthOffset2_Cal As System.Windows.Forms.Button
    Friend WithEvents txtToolID_LengthOffset3 As System.Windows.Forms.TextBox
    Friend WithEvents cmdToolID_LengthOffset3_Add As System.Windows.Forms.Button
    Friend WithEvents txtToolID_LengthOffset3Value As System.Windows.Forms.TextBox
    Friend WithEvents cmdToolID_LengthOffset3_Set As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_LengthOffset3_Cal As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_CutterRWearOffset As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_CutterROffset As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_LengthWearOffset As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_LenghtOffset As System.Windows.Forms.Button
    Friend WithEvents txtToolID_OffsetIndex123 As System.Windows.Forms.TextBox
    Friend WithEvents Label212 As System.Windows.Forms.Label
    Friend WithEvents tab_Tools2_1 As System.Windows.Forms.TabPage
    Friend WithEvents tab_MacManMachiningReport As System.Windows.Forms.TabPage
    Friend WithEvents tab_MopTool As System.Windows.Forms.TabPage
    Friend WithEvents tab_MacmanOperationHistory As System.Windows.Forms.TabPage
    Friend WithEvents tab_MacManOperatingHistory As System.Windows.Forms.TabPage
    Friend WithEvents Label213 As System.Windows.Forms.Label
    Friend WithEvents Label230 As System.Windows.Forms.Label
    Friend WithEvents Label235 As System.Windows.Forms.Label
    Friend WithEvents Label236 As System.Windows.Forms.Label
    Friend WithEvents Label241 As System.Windows.Forms.Label
    Friend WithEvents Label178 As System.Windows.Forms.Label
    Friend WithEvents cmdToolID_LifeStatus_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_GroupNoValue As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_GroupNo As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_CarrierStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label183 As System.Windows.Forms.Label
    Friend WithEvents cmdToolID_CarrierStatus_Set As System.Windows.Forms.Button
    Friend WithEvents cboToolID_CarrierStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtToolID_SerialNoValue As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_SerialNo As System.Windows.Forms.TextBox
    Friend WithEvents Label186 As System.Windows.Forms.Label
    Friend WithEvents cmdToolID_ToolAngle_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_ToolAngleValue As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_ToolAngle As System.Windows.Forms.TextBox
    Friend WithEvents Label242 As System.Windows.Forms.Label
    Friend WithEvents cmdToolID_ToolDiameter_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_ToolDiameterValue As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_ToolDiameter As System.Windows.Forms.TextBox
    Friend WithEvents Label243 As System.Windows.Forms.Label
    Friend WithEvents txtToolID_ToolKind As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_ToolName As System.Windows.Forms.TextBox
    Friend WithEvents Label244 As System.Windows.Forms.Label
    Friend WithEvents cmdToolID_ToolNoseDiameter_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_ToolNoseDiameterValue As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_ToolNoseDiameter As System.Windows.Forms.TextBox
    Friend WithEvents Label246 As System.Windows.Forms.Label
    Friend WithEvents cmdToolID_ToolType_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_ToolType As System.Windows.Forms.TextBox
    Friend WithEvents Label247 As System.Windows.Forms.Label
    Friend WithEvents cmdToolID_AdjustmentTool_Set As System.Windows.Forms.Button
    Friend WithEvents Label248 As System.Windows.Forms.Label
    Friend WithEvents cmdToolID_StandardTool_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_StandardTool As System.Windows.Forms.TextBox
    Friend WithEvents Label249 As System.Windows.Forms.Label
    Friend WithEvents cmdToolID_DataUnit_2_Set As System.Windows.Forms.Button
    Friend WithEvents cboToolID_DataUnit_2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmdToolID_2_Update As System.Windows.Forms.Button
    Friend WithEvents txtToolID_PotNo_2 As System.Windows.Forms.TextBox
    Friend WithEvents cboYesNo_AdjustmentTool As System.Windows.Forms.ComboBox
    Friend WithEvents cboYesNo_StandardTool As System.Windows.Forms.ComboBox
    Friend WithEvents cboYesNo_PotInUse As System.Windows.Forms.ComboBox
    Friend WithEvents cmdToolID_PotInUse_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_PotInUse As System.Windows.Forms.TextBox
    Friend WithEvents Label250 As System.Windows.Forms.Label
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents cboToolID_ToolLifeStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmdToolID_Update_1 As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_ToolLifeRemaining_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_ToolLifeRemainingValue As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_ToolLifeRemaining As System.Windows.Forms.TextBox
    Friend WithEvents cmdToolID_ToolLife_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_ToolLifeValue As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_ToolLife As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_ToolLifeRemainingSecond As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_ToolLifeStatus As System.Windows.Forms.TextBox
    Friend WithEvents cmdToolID_ToolLengthWearOffset_Add As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_ToolLengthWearOffset_Set As System.Windows.Forms.Button
    Friend WithEvents txtToolID_ToolLengthWearOffsetValue As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_ToolLengthWearOffset As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_ToPot As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_FromPot As System.Windows.Forms.TextBox
    Friend WithEvents lstToolID_Offset As System.Windows.Forms.ListBox
    Friend WithEvents txtToolID_AdjustmentTool As System.Windows.Forms.TextBox
    Friend WithEvents lstToolID_Update As System.Windows.Forms.ListBox
    Friend WithEvents cmdToolID_RegisterToolPot As System.Windows.Forms.Button
    Friend WithEvents txtToolID_ToolNameValue As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdToolID_UnRegisterToolPot As System.Windows.Forms.Button
    Friend WithEvents errorlog As System.Windows.Forms.TextBox
    Friend WithEvents chkToolID_DummyTool As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents tab_CurrentAlarm As System.Windows.Forms.TabPage
    Friend WithEvents txtCurrentAlarm_AlarmCharacterString As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentAlarm_AlarmCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentAlarm_ObjectMessage As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentAlarm_AlarmMessage As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentAlarm_AlarmLevel As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentAlarm_ObjectNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdCurrentAlarm_Update As System.Windows.Forms.Button
    Friend WithEvents txtCurrentAlarm_AlarmNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdToolID_ToolKind_Set As System.Windows.Forms.Button
    Friend WithEvents cboToolID_ToolKind As System.Windows.Forms.ComboBox
    Friend WithEvents cboToolID_ToolType As System.Windows.Forms.ComboBox
    Friend WithEvents cmdToolID_ToolAngle_Add As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_ToolNoseDiameter_Add As System.Windows.Forms.Button
    Friend WithEvents cmdToolID_ToolDiameter_Add As System.Windows.Forms.Button
    Friend WithEvents GroupBox21 As System.Windows.Forms.GroupBox
    Friend WithEvents Label251 As System.Windows.Forms.Label
    Friend WithEvents txtToolID_RATC_PotNoValue As System.Windows.Forms.TextBox
    Friend WithEvents txtToolID_RATC_PotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label252 As System.Windows.Forms.Label
    Friend WithEvents Tools2_2 As System.Windows.Forms.TabPage
    Friend WithEvents txtTools2_ToolInPot As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
Me.MainTabControl = New System.Windows.Forms.TabControl
Me.tab_atc = New System.Windows.Forms.TabPage
Me.GroupBox13 = New System.Windows.Forms.GroupBox
Me.cmdSetReturnPot = New System.Windows.Forms.Button
Me.cmdSetNextTool = New System.Windows.Forms.Button
Me.atcComboToolAttribute = New System.Windows.Forms.ComboBox
Me.Label138 = New System.Windows.Forms.Label
Me.atcButtonCancelTool = New System.Windows.Forms.Button
Me.atcCMDToolNumber = New System.Windows.Forms.TextBox
Me.Label136 = New System.Windows.Forms.Label
Me.atcCMDPotNumber = New System.Windows.Forms.TextBox
Me.Label135 = New System.Windows.Forms.Label
Me.cmdSetActualTool = New System.Windows.Forms.Button
Me.atcButtonUnRegister = New System.Windows.Forms.Button
Me.atcButtonRegisterAttribute = New System.Windows.Forms.Button
Me.atcButtonRegister = New System.Windows.Forms.Button
Me.atcSetLargeToolMemo = New System.Windows.Forms.Button
Me.atcSetHeavyToolMemo = New System.Windows.Forms.Button
Me.Label5 = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.largeToolMemo = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.heavyToolMemo = New System.Windows.Forms.TextBox
Me.atcUpdateButton = New System.Windows.Forms.Button
Me.atcStatus = New System.Windows.Forms.TextBox
Me.atcPotNumberButton = New System.Windows.Forms.Button
Me.pot_number_lbl = New System.Windows.Forms.Label
Me.potNumber = New System.Windows.Forms.TextBox
Me.Panel1 = New System.Windows.Forms.Panel
Me.Label38 = New System.Windows.Forms.Label
Me.potToolKind = New System.Windows.Forms.TextBox
Me.potToolNumber = New System.Windows.Forms.TextBox
Me.Label37 = New System.Windows.Forms.Label
Me.Panel2 = New System.Windows.Forms.Panel
Me.getMemoButton = New System.Windows.Forms.Button
Me.Label6 = New System.Windows.Forms.Label
Me.magazineNumber = New System.Windows.Forms.TextBox
Me.Panel3 = New System.Windows.Forms.Panel
Me.atcMagazinePosition = New System.Windows.Forms.TextBox
Me.Label114 = New System.Windows.Forms.Label
Me.endingPot = New System.Windows.Forms.TextBox
Me.Label9 = New System.Windows.Forms.Label
Me.startingPot = New System.Windows.Forms.TextBox
Me.Label8 = New System.Windows.Forms.Label
Me.getMagazineButton = New System.Windows.Forms.Button
Me.numberOfPots = New System.Windows.Forms.TextBox
Me.Label7 = New System.Windows.Forms.Label
Me.Button4 = New System.Windows.Forms.Button
Me.tab_program = New System.Windows.Forms.TabPage
Me.GroupBox15 = New System.Windows.Forms.GroupBox
Me.cmdReturnSearch = New System.Windows.Forms.Button
Me.cboSR_MIDBlockRestart = New System.Windows.Forms.ComboBox
Me.cboSR_AxisMovementOrder = New System.Windows.Forms.ComboBox
Me.txtSR_RepeatNumber = New System.Windows.Forms.TextBox
Me.Label175 = New System.Windows.Forms.Label
Me.txtSR_RelativeBlock = New System.Windows.Forms.TextBox
Me.Label171 = New System.Windows.Forms.Label
Me.Label172 = New System.Windows.Forms.Label
Me.Label173 = New System.Windows.Forms.Label
Me.txtSR_SequenceBlockNumber = New System.Windows.Forms.TextBox
Me.Label174 = New System.Windows.Forms.Label
Me.GroupBox14 = New System.Windows.Forms.GroupBox
Me.cmdSelectScheduleProgram = New System.Windows.Forms.Button
Me.cboFileReadModeEnum = New System.Windows.Forms.ComboBox
Me.progSelectProgramButton = New System.Windows.Forms.Button
Me.Label146 = New System.Windows.Forms.Label
Me.prog3 = New System.Windows.Forms.TextBox
Me.Label147 = New System.Windows.Forms.Label
Me.prog2 = New System.Windows.Forms.TextBox
Me.Label148 = New System.Windows.Forms.Label
Me.prog1 = New System.Windows.Forms.TextBox
Me.Label149 = New System.Windows.Forms.Label
Me.cmdCancelProgram = New System.Windows.Forms.Button
Me.progButtonExecBlock = New System.Windows.Forms.Button
Me.progExecutePoint = New System.Windows.Forms.TextBox
Me.Label59 = New System.Windows.Forms.Label
Me.progRead = New System.Windows.Forms.TextBox
Me.Label60 = New System.Windows.Forms.Label
Me.progColumn = New System.Windows.Forms.TextBox
Me.Label61 = New System.Windows.Forms.Label
Me.progRow = New System.Windows.Forms.TextBox
Me.Label62 = New System.Windows.Forms.Label
Me.Label58 = New System.Windows.Forms.Label
Me.progExecutingBlock = New System.Windows.Forms.TextBox
Me.label99 = New System.Windows.Forms.Label
Me.progExecCombo = New System.Windows.Forms.ComboBox
Me.Label57 = New System.Windows.Forms.Label
Me.progUpdateButton = New System.Windows.Forms.Button
Me.progNoParams = New System.Windows.Forms.TextBox
Me.Panel7 = New System.Windows.Forms.Panel
Me.Panel8 = New System.Windows.Forms.Panel
Me.progButtonGetRunProgram = New System.Windows.Forms.Button
Me.progRunningPrograms = New System.Windows.Forms.TextBox
Me.tab_Program2 = New System.Windows.Forms.TabPage
Me.Label168 = New System.Windows.Forms.Label
Me.txtProgramNameInput = New System.Windows.Forms.TextBox
Me.Label167 = New System.Windows.Forms.Label
Me.txtProgramNameOutput = New System.Windows.Forms.TextBox
Me.Label166 = New System.Windows.Forms.Label
Me.txtGMCode = New System.Windows.Forms.TextBox
Me.cmdSetProgramNameMCodeCall = New System.Windows.Forms.Button
Me.cmdGetProgramNameMCodeCall = New System.Windows.Forms.Button
Me.cmdSetProgramNameGCodeMod = New System.Windows.Forms.Button
Me.cmdGetProgramNameGCodeMod = New System.Windows.Forms.Button
Me.Tools2_2 = New System.Windows.Forms.TabPage
Me.GroupBox21 = New System.Windows.Forms.GroupBox
Me.txtTools2_ToolInPot = New System.Windows.Forms.TextBox
Me.Label252 = New System.Windows.Forms.Label
Me.Label249 = New System.Windows.Forms.Label
Me.cboToolID_ToolKind = New System.Windows.Forms.ComboBox
Me.cmdToolID_ToolKind_Set = New System.Windows.Forms.Button
Me.Label235 = New System.Windows.Forms.Label
Me.txtToolID_ToolKind = New System.Windows.Forms.TextBox
Me.cmdToolID_AdjustmentTool_Set = New System.Windows.Forms.Button
Me.txtToolID_AdjustmentTool = New System.Windows.Forms.TextBox
Me.Label248 = New System.Windows.Forms.Label
Me.Label250 = New System.Windows.Forms.Label
Me.txtToolID_PotInUse = New System.Windows.Forms.TextBox
Me.cmdToolID_PotInUse_Set = New System.Windows.Forms.Button
Me.cboYesNo_PotInUse = New System.Windows.Forms.ComboBox
Me.cboYesNo_AdjustmentTool = New System.Windows.Forms.ComboBox
Me.cboYesNo_StandardTool = New System.Windows.Forms.ComboBox
Me.cmdToolID_StandardTool_Set = New System.Windows.Forms.Button
Me.txtToolID_StandardTool = New System.Windows.Forms.TextBox
Me.lstToolID_Update = New System.Windows.Forms.ListBox
Me.GroupBox19 = New System.Windows.Forms.GroupBox
Me.txtToolID_RATC_PotNo = New System.Windows.Forms.TextBox
Me.txtToolID_RATC_PotNoValue = New System.Windows.Forms.TextBox
Me.Label251 = New System.Windows.Forms.Label
Me.chkToolID_DummyTool = New System.Windows.Forms.CheckBox
Me.txtToolID_ToolNameValue = New System.Windows.Forms.TextBox
Me.txtToolID_SerialNo = New System.Windows.Forms.TextBox
Me.txtToolID_ToolName = New System.Windows.Forms.TextBox
Me.Label244 = New System.Windows.Forms.Label
Me.txtToolID_GroupNoValue = New System.Windows.Forms.TextBox
Me.txtToolID_GroupNo = New System.Windows.Forms.TextBox
Me.Label186 = New System.Windows.Forms.Label
Me.Label241 = New System.Windows.Forms.Label
Me.txtToolID_SerialNoValue = New System.Windows.Forms.TextBox
Me.cmdToolID_UnRegisterToolPot = New System.Windows.Forms.Button
Me.cmdToolID_RegisterToolPot = New System.Windows.Forms.Button
Me.GroupBox18 = New System.Windows.Forms.GroupBox
Me.cmdToolID_ToolAngle_Add = New System.Windows.Forms.Button
Me.cmdToolID_ToolNoseDiameter_Add = New System.Windows.Forms.Button
Me.cmdToolID_ToolDiameter_Add = New System.Windows.Forms.Button
Me.cboToolID_ToolType = New System.Windows.Forms.ComboBox
Me.Label246 = New System.Windows.Forms.Label
Me.Label247 = New System.Windows.Forms.Label
Me.txtToolID_ToolType = New System.Windows.Forms.TextBox
Me.cmdToolID_ToolType_Set = New System.Windows.Forms.Button
Me.cmdToolID_ToolAngle_Set = New System.Windows.Forms.Button
Me.txtToolID_ToolAngleValue = New System.Windows.Forms.TextBox
Me.Label242 = New System.Windows.Forms.Label
Me.txtToolID_ToolAngle = New System.Windows.Forms.TextBox
Me.cmdToolID_ToolNoseDiameter_Set = New System.Windows.Forms.Button
Me.cmdToolID_ToolDiameter_Set = New System.Windows.Forms.Button
Me.txtToolID_ToolDiameterValue = New System.Windows.Forms.TextBox
Me.txtToolID_ToolNoseDiameterValue = New System.Windows.Forms.TextBox
Me.Label243 = New System.Windows.Forms.Label
Me.txtToolID_ToolNoseDiameter = New System.Windows.Forms.TextBox
Me.txtToolID_ToolDiameter = New System.Windows.Forms.TextBox
Me.cboToolID_CarrierStatus = New System.Windows.Forms.ComboBox
Me.cmdToolID_CarrierStatus_Set = New System.Windows.Forms.Button
Me.txtToolID_CarrierStatus = New System.Windows.Forms.TextBox
Me.Label183 = New System.Windows.Forms.Label
Me.Label213 = New System.Windows.Forms.Label
Me.cmdToolID_DataUnit_2_Set = New System.Windows.Forms.Button
Me.cboToolID_DataUnit_2 = New System.Windows.Forms.ComboBox
Me.Label230 = New System.Windows.Forms.Label
Me.cmdToolID_2_Update = New System.Windows.Forms.Button
Me.txtToolID_PotNo_2 = New System.Windows.Forms.TextBox
Me.Label236 = New System.Windows.Forms.Label
Me.tab_Tools2_1 = New System.Windows.Forms.TabPage
Me.cmdToolID_Update_1 = New System.Windows.Forms.Button
Me.GroupBox16 = New System.Windows.Forms.GroupBox
Me.lstToolID_Offset = New System.Windows.Forms.ListBox
Me.Label212 = New System.Windows.Forms.Label
Me.txtToolID_OffsetIndex123 = New System.Windows.Forms.TextBox
Me.cmdToolID_LengthOffset3_Cal = New System.Windows.Forms.Button
Me.cmdToolID_LengthOffset2_Cal = New System.Windows.Forms.Button
Me.txtToolID_LengthOffset3 = New System.Windows.Forms.TextBox
Me.Label211 = New System.Windows.Forms.Label
Me.cmdToolID_LengthOffset3_Add = New System.Windows.Forms.Button
Me.txtToolID_LengthOffset3Value = New System.Windows.Forms.TextBox
Me.cmdToolID_LengthOffset3_Set = New System.Windows.Forms.Button
Me.txtToolID_LengthOffset2 = New System.Windows.Forms.TextBox
Me.Label210 = New System.Windows.Forms.Label
Me.cmdToolID_LengthOffset2_Add = New System.Windows.Forms.Button
Me.txtToolID_LengthOffset2Value = New System.Windows.Forms.TextBox
Me.cmdToolID_LengthOffset2_Set = New System.Windows.Forms.Button
Me.cmdToolID_CutterRCompOffset3_Add = New System.Windows.Forms.Button
Me.cmdToolID_CutterRCompOffset3_Set = New System.Windows.Forms.Button
Me.txtToolID_CutterRCompOffset3Value = New System.Windows.Forms.TextBox
Me.Label209 = New System.Windows.Forms.Label
Me.txtToolID_CutterRCompOffset3 = New System.Windows.Forms.TextBox
Me.cmdToolID_CutterRCompOffset2_Add = New System.Windows.Forms.Button
Me.cmdToolID_CutterRCompOffset2_Set = New System.Windows.Forms.Button
Me.txtToolID_CutterRCompOffset2Value = New System.Windows.Forms.TextBox
Me.Label208 = New System.Windows.Forms.Label
Me.txtToolID_CutterRCompOffset2 = New System.Windows.Forms.TextBox
Me.cmdToolID_CutterRCompOffset1_Add = New System.Windows.Forms.Button
Me.cmdToolID_CutterRCompWearOffset_Add = New System.Windows.Forms.Button
Me.txtToolID_LengthOffset1 = New System.Windows.Forms.TextBox
Me.Label182 = New System.Windows.Forms.Label
Me.txtToolID_CutterRCompWearOffsetValue = New System.Windows.Forms.TextBox
Me.cmdToolID_CutterRCompWearOffset_Set = New System.Windows.Forms.Button
Me.cmdToolID_CutterRCompOffset1_Set = New System.Windows.Forms.Button
Me.cmdToolID_LengthOffset1_Add = New System.Windows.Forms.Button
Me.txtToolID_CutterRCompOffset1Value = New System.Windows.Forms.TextBox
Me.Label188 = New System.Windows.Forms.Label
Me.txtToolID_CutterRCompWearOffset = New System.Windows.Forms.TextBox
Me.Label189 = New System.Windows.Forms.Label
Me.txtToolID_CutterRCompOffset1 = New System.Windows.Forms.TextBox
Me.cmdToolID_ToolLengthWearOffset_Add = New System.Windows.Forms.Button
Me.cmdToolID_ToolLengthWearOffset_Set = New System.Windows.Forms.Button
Me.txtToolID_ToolLengthWearOffsetValue = New System.Windows.Forms.TextBox
Me.txtToolID_LengthOffset1Value = New System.Windows.Forms.TextBox
Me.txtToolID_ToolLengthWearOffset = New System.Windows.Forms.TextBox
Me.Label181 = New System.Windows.Forms.Label
Me.cmdToolID_LengthOffset1_Cal = New System.Windows.Forms.Button
Me.cmdToolID_LengthOffset1_Set = New System.Windows.Forms.Button
Me.cmdToolID_CutterRWearOffset = New System.Windows.Forms.Button
Me.cmdToolID_CutterROffset = New System.Windows.Forms.Button
Me.cmdToolID_LengthWearOffset = New System.Windows.Forms.Button
Me.cmdToolID_LenghtOffset = New System.Windows.Forms.Button
Me.txtToolID_ToPot = New System.Windows.Forms.TextBox
Me.Label176 = New System.Windows.Forms.Label
Me.txtToolID_FromPot = New System.Windows.Forms.TextBox
Me.Label177 = New System.Windows.Forms.Label
Me.GroupBox17 = New System.Windows.Forms.GroupBox
Me.txtToolID_ToolLifeRemainingSecond = New System.Windows.Forms.TextBox
Me.Label178 = New System.Windows.Forms.Label
Me.cmdToolID_LifeStatus_Set = New System.Windows.Forms.Button
Me.txtToolID_ToolLifeStatus = New System.Windows.Forms.TextBox
Me.Label184 = New System.Windows.Forms.Label
Me.cmdToolID_ToolLifeMode_Set = New System.Windows.Forms.Button
Me.Label187 = New System.Windows.Forms.Label
Me.cboToolID_ToolLifeStatus = New System.Windows.Forms.ComboBox
Me.cboToolID_ToolLifeMode = New System.Windows.Forms.ComboBox
Me.txtToolID_ToolLifeMode = New System.Windows.Forms.TextBox
Me.cmdToolID_ToolLifeRemaining_Set = New System.Windows.Forms.Button
Me.txtToolID_ToolLifeRemainingValue = New System.Windows.Forms.TextBox
Me.txtToolID_ToolLifeRemaining = New System.Windows.Forms.TextBox
Me.Label179 = New System.Windows.Forms.Label
Me.cmdToolID_ToolLife_Set = New System.Windows.Forms.Button
Me.txtToolID_ToolLifeValue = New System.Windows.Forms.TextBox
Me.txtToolID_ToolLife = New System.Windows.Forms.TextBox
Me.Label180 = New System.Windows.Forms.Label
Me.Label207 = New System.Windows.Forms.Label
Me.cmdToolID_DataUnit_Set = New System.Windows.Forms.Button
Me.cboToolID_DataUnit = New System.Windows.Forms.ComboBox
Me.txtToolID_PotNo = New System.Windows.Forms.TextBox
Me.Label185 = New System.Windows.Forms.Label
Me.tab_machine = New System.Windows.Forms.TabPage
Me.txtPanelMode = New System.Windows.Forms.TextBox
Me.Label2 = New System.Windows.Forms.Label
Me.GroupBox8 = New System.Windows.Forms.GroupBox
Me.cmdMachineDataUnit = New System.Windows.Forms.Button
Me.cboMachineDataUnit = New System.Windows.Forms.ComboBox
Me.txtInputMachineZeroOffset = New System.Windows.Forms.TextBox
Me.Label142 = New System.Windows.Forms.Label
Me.cboMachineZeroOffsetAxis = New System.Windows.Forms.ComboBox
Me.txtOutputMachineZeroOffset = New System.Windows.Forms.TextBox
Me.cmdCalMachineZeroOffset = New System.Windows.Forms.Button
Me.cmdAddMachineZeroOffset = New System.Windows.Forms.Button
Me.cmdSetMachineZeroOffset = New System.Windows.Forms.Button
Me.cmdGetMachineZeroOffset = New System.Windows.Forms.Button
Me.Panel11 = New System.Windows.Forms.Panel
Me.Txt_mdicommand = New System.Windows.Forms.TextBox
Me.cmd_InputMDI = New System.Windows.Forms.Button
Me.machineUpdateButton = New System.Windows.Forms.Button
Me.machinePowerOnTimeAdd = New System.Windows.Forms.Button
Me.machinePowerOnTimeSet = New System.Windows.Forms.Button
Me.machinePowerOnTimeUpdate = New System.Windows.Forms.TextBox
Me.machinePowerOnTime = New System.Windows.Forms.TextBox
Me.Label35 = New System.Windows.Forms.Label
Me.machineUnitSytem = New System.Windows.Forms.TextBox
Me.Label34 = New System.Windows.Forms.Label
Me.machineOperationMode = New System.Windows.Forms.TextBox
Me.Label33 = New System.Windows.Forms.Label
Me.machineExecutionMode = New System.Windows.Forms.TextBox
Me.Label32 = New System.Windows.Forms.Label
Me.tab_MacManAlarmHistory = New System.Windows.Forms.TabPage
Me.grdMMAlarmHistory = New System.Windows.Forms.DataGrid
Me.GroupBox9 = New System.Windows.Forms.GroupBox
Me.txtAlarmObject = New System.Windows.Forms.TextBox
Me.Label145 = New System.Windows.Forms.Label
Me.mahAlarmMessage = New System.Windows.Forms.TextBox
Me.Label104 = New System.Windows.Forms.Label
Me.mahAlarmDate = New System.Windows.Forms.TextBox
Me.Label105 = New System.Windows.Forms.Label
Me.mahAlarmCode = New System.Windows.Forms.TextBox
Me.mahAlarmTime = New System.Windows.Forms.TextBox
Me.Label106 = New System.Windows.Forms.Label
Me.Label102 = New System.Windows.Forms.Label
Me.mahAlarmNumber = New System.Windows.Forms.TextBox
Me.Label103 = New System.Windows.Forms.Label
Me.mahUpdateButton = New System.Windows.Forms.Button
Me.Label107 = New System.Windows.Forms.Label
Me.mahMaxAlarmCount = New System.Windows.Forms.TextBox
Me.Label98 = New System.Windows.Forms.Label
Me.mahAlarmCount = New System.Windows.Forms.TextBox
Me.Label101 = New System.Windows.Forms.Label
Me.mahAlarmIndex = New System.Windows.Forms.TextBox
Me.mahTo = New System.Windows.Forms.TextBox
Me.Label133 = New System.Windows.Forms.Label
Me.mahFrom = New System.Windows.Forms.TextBox
Me.Label134 = New System.Windows.Forms.Label
Me.mahButtonResults = New System.Windows.Forms.Button
Me.tab_tools = New System.Windows.Forms.TabPage
Me.tulAddCutterRCompOffset = New System.Windows.Forms.Button
Me.tulAddCutterRCompWearOffset = New System.Windows.Forms.Button
Me.tulToolLifeRemainSec = New System.Windows.Forms.TextBox
Me.Label205 = New System.Windows.Forms.Label
Me.Label151 = New System.Windows.Forms.Label
Me.tulSetDataUnit = New System.Windows.Forms.Button
Me.tulDataUnitCombo = New System.Windows.Forms.ComboBox
Me.tulButtonCutterRLengthOffset = New System.Windows.Forms.Button
Me.tulButtonCutterROffset = New System.Windows.Forms.Button
Me.tulButtonLengthWearOffset = New System.Windows.Forms.Button
Me.tulButtonLengthOffset = New System.Windows.Forms.Button
Me.tulTo = New System.Windows.Forms.TextBox
Me.Label125 = New System.Windows.Forms.Label
Me.tulFrom = New System.Windows.Forms.TextBox
Me.Label126 = New System.Windows.Forms.Label
Me.tulResults = New System.Windows.Forms.TextBox
Me.tulAddToolLengthOffset = New System.Windows.Forms.Button
Me.tulUpdToolGroupOrder = New System.Windows.Forms.ComboBox
Me.tulUpdToolStatus = New System.Windows.Forms.ComboBox
Me.tulUpdToolMode = New System.Windows.Forms.ComboBox
Me.tulToolNumber = New System.Windows.Forms.TextBox
Me.label100 = New System.Windows.Forms.Label
Me.Label81 = New System.Windows.Forms.Label
Me.tulUpdateButtonNoParam = New System.Windows.Forms.Button
Me.tulNoParam = New System.Windows.Forms.TextBox
Me.tulUpdateButton = New System.Windows.Forms.Button
Me.tulSetToolLifeRemaining = New System.Windows.Forms.Button
Me.tulUpdToolLifeRemaining = New System.Windows.Forms.TextBox
Me.tulToolLifeRemaining = New System.Windows.Forms.TextBox
Me.Label88 = New System.Windows.Forms.Label
Me.tulSetToolLife = New System.Windows.Forms.Button
Me.tulUpdToolLife = New System.Windows.Forms.TextBox
Me.tulToolLife = New System.Windows.Forms.TextBox
Me.Label87 = New System.Windows.Forms.Label
Me.tulCalToolLengthWearOffset = New System.Windows.Forms.Button
Me.tulAddToolLengthWearOffset = New System.Windows.Forms.Button
Me.tulSetToolLengthWearOffset = New System.Windows.Forms.Button
Me.tulUpdToolLengthWearOffset = New System.Windows.Forms.TextBox
Me.tulToolLengthWearOffset = New System.Windows.Forms.TextBox
Me.Label86 = New System.Windows.Forms.Label
Me.tulCalToolLengthOffset = New System.Windows.Forms.Button
Me.tulSetToolLengthOffset = New System.Windows.Forms.Button
Me.tulUpdToolLengthOffset = New System.Windows.Forms.TextBox
Me.tulToolLengthOffset = New System.Windows.Forms.TextBox
Me.Label85 = New System.Windows.Forms.Label
Me.tulToolKind = New System.Windows.Forms.TextBox
Me.Label84 = New System.Windows.Forms.Label
Me.tulSetToolGroupOrder = New System.Windows.Forms.Button
Me.tulToolGroupOrder = New System.Windows.Forms.TextBox
Me.Label83 = New System.Windows.Forms.Label
Me.tulSetToolStatus = New System.Windows.Forms.Button
Me.tulToolStatus = New System.Windows.Forms.TextBox
Me.Label82 = New System.Windows.Forms.Label
Me.tulSetReferenceToolOffset3 = New System.Windows.Forms.Button
Me.tulSetReferenceToolOffset2 = New System.Windows.Forms.Button
Me.tulSetToolMode = New System.Windows.Forms.Button
Me.tulSetToolGroup = New System.Windows.Forms.Button
Me.tulSetCutterRCompWearOffset = New System.Windows.Forms.Button
Me.tulSetCutterRCompOffset = New System.Windows.Forms.Button
Me.tulUpdReferenceToolOffset3 = New System.Windows.Forms.TextBox
Me.tulUpdReferenceToolOffset2 = New System.Windows.Forms.TextBox
Me.tulUpdToolGroup = New System.Windows.Forms.TextBox
Me.tulUpdCutterRCompWearOffset = New System.Windows.Forms.TextBox
Me.tulUpdCutterRCompOffset = New System.Windows.Forms.TextBox
Me.tulReferenceToolOffset3 = New System.Windows.Forms.TextBox
Me.Label74 = New System.Windows.Forms.Label
Me.tulReferenceToolOffset2 = New System.Windows.Forms.TextBox
Me.Label75 = New System.Windows.Forms.Label
Me.tulPotNumber = New System.Windows.Forms.TextBox
Me.Label76 = New System.Windows.Forms.Label
Me.tulToolGroup = New System.Windows.Forms.TextBox
Me.Label77 = New System.Windows.Forms.Label
Me.tulToolMode = New System.Windows.Forms.TextBox
Me.Label78 = New System.Windows.Forms.Label
Me.Label79 = New System.Windows.Forms.Label
Me.tulCutterRCompWearOffset = New System.Windows.Forms.TextBox
Me.Label80 = New System.Windows.Forms.Label
Me.tulCutterRCompOffset = New System.Windows.Forms.TextBox
Me.tab_axis = New System.Windows.Forms.TabPage
Me.txt_RelativeActualPositionProgramCoord = New System.Windows.Forms.TextBox
Me.Label234 = New System.Windows.Forms.Label
Me.Label206 = New System.Windows.Forms.Label
Me.axisSetDataUnit = New System.Windows.Forms.Button
Me.axisDataUnit = New System.Windows.Forms.ComboBox
Me.AxisTimerStop = New System.Windows.Forms.Button
Me.axisTimerStart = New System.Windows.Forms.Button
Me.axisUpdateButton = New System.Windows.Forms.Button
Me.maxFeedrateOverride = New System.Windows.Forms.TextBox
Me.Label26 = New System.Windows.Forms.Label
Me.feedrateType = New System.Windows.Forms.TextBox
Me.Label25 = New System.Windows.Forms.Label
Me.feedrateOverride = New System.Windows.Forms.TextBox
Me.Label24 = New System.Windows.Forms.Label
Me.feedHold = New System.Windows.Forms.TextBox
Me.Label23 = New System.Windows.Forms.Label
Me.axisType = New System.Windows.Forms.TextBox
Me.Label22 = New System.Windows.Forms.Label
Me.axisName = New System.Windows.Forms.TextBox
Me.Label21 = New System.Windows.Forms.Label
Me.targetPosition = New System.Windows.Forms.TextBox
Me.Label20 = New System.Windows.Forms.Label
Me.distanceTarget = New System.Windows.Forms.TextBox
Me.Label19 = New System.Windows.Forms.Label
Me.commandFeedRate = New System.Windows.Forms.TextBox
Me.Label18 = New System.Windows.Forms.Label
Me.axisLoad = New System.Windows.Forms.TextBox
Me.Label17 = New System.Windows.Forms.Label
Me.apProgramCoord = New System.Windows.Forms.TextBox
Me.Label16 = New System.Windows.Forms.Label
Me.apMachineCoord = New System.Windows.Forms.TextBox
Me.Label15 = New System.Windows.Forms.Label
Me.apEncoderCoord = New System.Windows.Forms.TextBox
Me.Label14 = New System.Windows.Forms.Label
Me.actualFeedrate = New System.Windows.Forms.TextBox
Me.Label13 = New System.Windows.Forms.Label
Me.feedCommandOrderCombo = New System.Windows.Forms.ComboBox
Me.Label12 = New System.Windows.Forms.Label
Me.feedTypeCombo = New System.Windows.Forms.ComboBox
Me.Label11 = New System.Windows.Forms.Label
Me.axisCombo = New System.Windows.Forms.ComboBox
Me.Label10 = New System.Windows.Forms.Label
Me.Panel4 = New System.Windows.Forms.Panel
Me.tab_axis2 = New System.Windows.Forms.TabPage
Me.cmdAxis2DataUnit = New System.Windows.Forms.Button
Me.cboAxis2DataUnit = New System.Windows.Forms.ComboBox
Me.GroupBox11 = New System.Windows.Forms.GroupBox
Me.Label291 = New System.Windows.Forms.Label
Me.cboUserParameterVariableLimitCoordinate = New System.Windows.Forms.ComboBox
Me.txtUserParameterLimitInput = New System.Windows.Forms.TextBox
Me.txtUserParameterLimit = New System.Windows.Forms.TextBox
Me.Label157 = New System.Windows.Forms.Label
Me.cmdUserParameterVariableLimitAdd = New System.Windows.Forms.Button
Me.cmdUserParameterVariableLimitSet = New System.Windows.Forms.Button
Me.cmdUserParameterVariableLimitGet = New System.Windows.Forms.Button
Me.Label165 = New System.Windows.Forms.Label
Me.cboUserParameterVariableLimitAxis = New System.Windows.Forms.ComboBox
Me.tab_spec = New System.Windows.Forms.TabPage
Me.GroupBox10 = New System.Windows.Forms.GroupBox
Me.cmdGetBSpecCode = New System.Windows.Forms.Button
Me.txtSpecCode = New System.Windows.Forms.TextBox
Me.Label170 = New System.Windows.Forms.Label
Me.txtSpecCodeBit = New System.Windows.Forms.TextBox
Me.Label169 = New System.Windows.Forms.Label
Me.txtSpecCodeIndex = New System.Windows.Forms.TextBox
Me.cmdGetSpecCode = New System.Windows.Forms.Button
Me.txtMachineSerial = New System.Windows.Forms.TextBox
Me.txtMachineName = New System.Windows.Forms.TextBox
Me.Label144 = New System.Windows.Forms.Label
Me.Label143 = New System.Windows.Forms.Label
Me.Label66 = New System.Windows.Forms.Label
Me.specCombo = New System.Windows.Forms.ComboBox
Me.specUpdateButton = New System.Windows.Forms.Button
Me.specCode = New System.Windows.Forms.TextBox
Me.Label63 = New System.Windows.Forms.Label
Me.tab_MacManMachiningReport = New System.Windows.Forms.TabPage
Me.grdMMMachiningReports = New System.Windows.Forms.DataGrid
Me.PictureBox1 = New System.Windows.Forms.PictureBox
Me.txtMachiningReport_NoOfWork = New System.Windows.Forms.TextBox
Me.Label156 = New System.Windows.Forms.Label
Me.MacreportTime = New System.Windows.Forms.TextBox
Me.Label245 = New System.Windows.Forms.Label
Me.txtto = New System.Windows.Forms.TextBox
Me.Label158 = New System.Windows.Forms.Label
Me.txtFrom = New System.Windows.Forms.TextBox
Me.Label159 = New System.Windows.Forms.Label
Me.macreport_result = New System.Windows.Forms.Button
Me.Label160 = New System.Windows.Forms.Label
Me.Cmb_rptPeriod = New System.Windows.Forms.ComboBox
Me.MacReport_programname = New System.Windows.Forms.TextBox
Me.Label161 = New System.Windows.Forms.Label
Me.Macreport_filename = New System.Windows.Forms.TextBox
Me.Label162 = New System.Windows.Forms.Label
Me.MacReport_count = New System.Windows.Forms.TextBox
Me.Label163 = New System.Windows.Forms.Label
Me.macReportUpdateButton = New System.Windows.Forms.Button
Me.MacReport_Index = New System.Windows.Forms.TextBox
Me.Label164 = New System.Windows.Forms.Label
Me.macreport_Operatingtime = New System.Windows.Forms.TextBox
Me.Label225 = New System.Windows.Forms.Label
Me.macreport_Runningtime = New System.Windows.Forms.TextBox
Me.Label226 = New System.Windows.Forms.Label
Me.Macreportdate = New System.Windows.Forms.TextBox
Me.Label227 = New System.Windows.Forms.Label
Me.macreport_maxcount = New System.Windows.Forms.TextBox
Me.Label228 = New System.Windows.Forms.Label
Me.macreport_cuttingtime = New System.Windows.Forms.TextBox
Me.Label229 = New System.Windows.Forms.Label
Me.Tab_View = New System.Windows.Forms.TabPage
Me.Panel12 = New System.Windows.Forms.Panel
Me.Label231 = New System.Windows.Forms.Label
Me.Cmb_ChangeScreen = New System.Windows.Forms.ComboBox
Me.cmd_ChangeScreen = New System.Windows.Forms.Button
Me.txt_screenname = New System.Windows.Forms.TextBox
Me.Label232 = New System.Windows.Forms.Label
Me.tab_MacmanOperationHistory = New System.Windows.Forms.TabPage
Me.mohTo = New System.Windows.Forms.TextBox
Me.Label131 = New System.Windows.Forms.Label
Me.mohFrom = New System.Windows.Forms.TextBox
Me.Label132 = New System.Windows.Forms.Label
Me.mohResults = New System.Windows.Forms.TextBox
Me.mohButtonResults = New System.Windows.Forms.Button
Me.mohUpdateButton = New System.Windows.Forms.Button
Me.mohOperationIndex = New System.Windows.Forms.TextBox
Me.Label113 = New System.Windows.Forms.Label
Me.mohOperationTime = New System.Windows.Forms.TextBox
Me.Label116 = New System.Windows.Forms.Label
Me.mohOperationDate = New System.Windows.Forms.TextBox
Me.Label117 = New System.Windows.Forms.Label
Me.mohOperationData = New System.Windows.Forms.TextBox
Me.Label118 = New System.Windows.Forms.Label
Me.mohOperationMaxCount = New System.Windows.Forms.TextBox
Me.Label119 = New System.Windows.Forms.Label
Me.mohOperationCount = New System.Windows.Forms.TextBox
Me.Label120 = New System.Windows.Forms.Label
Me.tab_ballscrew = New System.Windows.Forms.TabPage
Me.ballscrewDataUnitCombo = New System.Windows.Forms.ComboBox
Me.bsDataUnitSet = New System.Windows.Forms.Button
Me.Label150 = New System.Windows.Forms.Label
Me.Label115 = New System.Windows.Forms.Label
Me.bsPecPoint = New System.Windows.Forms.TextBox
Me.bsStartPositionAdd = New System.Windows.Forms.Button
Me.bsStartPositionSet = New System.Windows.Forms.Button
Me.bsMaxPitchPointsAdd = New System.Windows.Forms.Button
Me.bsMaxPicthPointsSet = New System.Windows.Forms.Button
Me.bsIntervalAdd = New System.Windows.Forms.Button
Me.bsIntervalSet = New System.Windows.Forms.Button
Me.bsDataPointAdd = New System.Windows.Forms.Button
Me.bsDataPointSet = New System.Windows.Forms.Button
Me.bsStartPositionUpdate = New System.Windows.Forms.TextBox
Me.bsMaxPitchPointsUpdate = New System.Windows.Forms.TextBox
Me.bsIntervalUpdate = New System.Windows.Forms.TextBox
Me.bsDataPointUpdate = New System.Windows.Forms.TextBox
Me.bsStartPosition = New System.Windows.Forms.TextBox
Me.Label31 = New System.Windows.Forms.Label
Me.bsMaxPitchPoints = New System.Windows.Forms.TextBox
Me.Label30 = New System.Windows.Forms.Label
Me.bsInterval = New System.Windows.Forms.TextBox
Me.Label29 = New System.Windows.Forms.Label
Me.ballscrewUpdateButton = New System.Windows.Forms.Button
Me.Label28 = New System.Windows.Forms.Label
Me.ballscrewAxisCombo = New System.Windows.Forms.ComboBox
Me.Panel5 = New System.Windows.Forms.Panel
Me.bsDataPoint = New System.Windows.Forms.TextBox
Me.Label27 = New System.Windows.Forms.Label
Me.tab_CurrentAlarm = New System.Windows.Forms.TabPage
Me.cmdCurrentAlarm_Update = New System.Windows.Forms.Button
Me.GroupBox20 = New System.Windows.Forms.GroupBox
Me.txtCurrentAlarm_AlarmCharacterString = New System.Windows.Forms.TextBox
Me.txtCurrentAlarm_AlarmCode = New System.Windows.Forms.TextBox
Me.PictureBox2 = New System.Windows.Forms.PictureBox
Me.txtCurrentAlarm_ObjectMessage = New System.Windows.Forms.TextBox
Me.txtCurrentAlarm_AlarmMessage = New System.Windows.Forms.TextBox
Me.txtCurrentAlarm_AlarmLevel = New System.Windows.Forms.TextBox
Me.txtCurrentAlarm_ObjectNumber = New System.Windows.Forms.TextBox
Me.txtCurrentAlarm_AlarmNumber = New System.Windows.Forms.TextBox
Me.PictureBox3 = New System.Windows.Forms.PictureBox
Me.tab_OptionalParameter = New System.Windows.Forms.TabPage
Me.GroupBox12 = New System.Windows.Forms.GroupBox
Me.txtLongWordInput = New System.Windows.Forms.TextBox
Me.txtWordInput = New System.Windows.Forms.TextBox
Me.txtBitInput = New System.Windows.Forms.TextBox
Me.cmdWordAdd = New System.Windows.Forms.Button
Me.cmdLongWordAdd = New System.Windows.Forms.Button
Me.cmdBitSet = New System.Windows.Forms.Button
Me.cmdWordSet = New System.Windows.Forms.Button
Me.cmdLongWordSet = New System.Windows.Forms.Button
Me.cmdOptionalParameterBitGet = New System.Windows.Forms.Button
Me.cmdOptionalParameterWordGet = New System.Windows.Forms.Button
Me.cmdOptionalParameterLongWordGet = New System.Windows.Forms.Button
Me.txtOptionalParameterLongWord = New System.Windows.Forms.TextBox
Me.txtOptionalParameterWord = New System.Windows.Forms.TextBox
Me.txtOptionalParameterBit = New System.Windows.Forms.TextBox
Me.Label299 = New System.Windows.Forms.Label
Me.txtOptionalParameterBitNo = New System.Windows.Forms.TextBox
Me.Label300 = New System.Windows.Forms.Label
Me.txtOptionalParameterLongWordIndex = New System.Windows.Forms.TextBox
Me.Label301 = New System.Windows.Forms.Label
Me.txtOptionalParameterWordIndex = New System.Windows.Forms.TextBox
Me.Label302 = New System.Windows.Forms.Label
Me.txtOptionalParameterBitIndex = New System.Windows.Forms.TextBox
Me.Label303 = New System.Windows.Forms.Label
Me.tab_MopTool = New System.Windows.Forms.TabPage
Me.Label233 = New System.Windows.Forms.Label
Me.TXT_GetMaxMOPToolData = New System.Windows.Forms.TextBox
Me.mopButtonULValue = New System.Windows.Forms.Button
Me.mopSetULValue = New System.Windows.Forms.TextBox
Me.mopButtonToolDataInput = New System.Windows.Forms.Button
Me.mopSetToolDataInputMode = New System.Windows.Forms.TextBox
Me.mopButtonReferenceValue = New System.Windows.Forms.Button
Me.mopSetReferenceValue = New System.Windows.Forms.TextBox
Me.mopButtonOverloadMonitor = New System.Windows.Forms.Button
Me.mopSetOverloadMonitor = New System.Windows.Forms.TextBox
Me.mopButtonMinOverride = New System.Windows.Forms.Button
Me.mopSetMinOverride = New System.Windows.Forms.TextBox
Me.mopButtonMaxOverride = New System.Windows.Forms.Button
Me.mopSetMaxOverride = New System.Windows.Forms.TextBox
Me.mopButtonLLValue = New System.Windows.Forms.Button
Me.mopSetLLValue = New System.Windows.Forms.TextBox
Me.mopButtonLimitValue = New System.Windows.Forms.Button
Me.mopSetLimitValue = New System.Windows.Forms.TextBox
Me.mopButtonCuttingTime = New System.Windows.Forms.Button
Me.mopSetCuttingTime = New System.Windows.Forms.TextBox
Me.mopbuttonAutoChange = New System.Windows.Forms.Button
Me.mopSetAutoChange = New System.Windows.Forms.TextBox
Me.mopButtonUnusualSignalChange = New System.Windows.Forms.Button
Me.mopSetUnusualSignal = New System.Windows.Forms.TextBox
Me.mopButtonALVValue = New System.Windows.Forms.Button
Me.mopSetALVValue = New System.Windows.Forms.TextBox
Me.mopButtonAircutReduction = New System.Windows.Forms.Button
Me.mopSetAircutReduction = New System.Windows.Forms.TextBox
Me.mopButtonAircutOverride = New System.Windows.Forms.Button
Me.mopSetAircutOverride = New System.Windows.Forms.TextBox
Me.mopButtonAdaptiveControl = New System.Windows.Forms.Button
Me.mopSetAdaptiveControl = New System.Windows.Forms.TextBox
Me.mopUlValue = New System.Windows.Forms.TextBox
Me.Label121 = New System.Windows.Forms.Label
Me.mopToolDataInputMode = New System.Windows.Forms.TextBox
Me.Label123 = New System.Windows.Forms.Label
Me.mopSignalDiffAlarm = New System.Windows.Forms.TextBox
Me.Label124 = New System.Windows.Forms.Label
Me.mopReferenceValue = New System.Windows.Forms.TextBox
Me.Label56 = New System.Windows.Forms.Label
Me.mopOverloadMonitor = New System.Windows.Forms.TextBox
Me.Label55 = New System.Windows.Forms.Label
Me.mopMinOverride = New System.Windows.Forms.TextBox
Me.Label54 = New System.Windows.Forms.Label
Me.mopMaxOverride = New System.Windows.Forms.TextBox
Me.Label53 = New System.Windows.Forms.Label
Me.mopLLValue = New System.Windows.Forms.TextBox
Me.Label52 = New System.Windows.Forms.Label
Me.mopLimitValue = New System.Windows.Forms.TextBox
Me.Label51 = New System.Windows.Forms.Label
Me.mopCuttingTime = New System.Windows.Forms.TextBox
Me.Label50 = New System.Windows.Forms.Label
Me.mopCuttingLoad = New System.Windows.Forms.TextBox
Me.Label48 = New System.Windows.Forms.Label
Me.mopAutoChange = New System.Windows.Forms.TextBox
Me.Label47 = New System.Windows.Forms.Label
Me.mopUnusualSignal = New System.Windows.Forms.TextBox
Me.Label49 = New System.Windows.Forms.Label
Me.mopAlarms = New System.Windows.Forms.TextBox
Me.Label46 = New System.Windows.Forms.Label
Me.mopALVValue = New System.Windows.Forms.TextBox
Me.Label45 = New System.Windows.Forms.Label
Me.mopAircutReduction = New System.Windows.Forms.TextBox
Me.Label42 = New System.Windows.Forms.Label
Me.mopAircutOverride = New System.Windows.Forms.TextBox
Me.Label43 = New System.Windows.Forms.Label
Me.mopAdaptiveControl = New System.Windows.Forms.TextBox
Me.Label44 = New System.Windows.Forms.Label
Me.Label39 = New System.Windows.Forms.Label
Me.mopPositionTypeCombo = New System.Windows.Forms.ComboBox
Me.Label40 = New System.Windows.Forms.Label
Me.Label41 = New System.Windows.Forms.Label
Me.mopAxisCombo = New System.Windows.Forms.ComboBox
Me.Panel6 = New System.Windows.Forms.Panel
Me.mopToolNumber = New System.Windows.Forms.TextBox
Me.mopUpdateButton = New System.Windows.Forms.Button
Me.GroupBox6 = New System.Windows.Forms.GroupBox
Me.mopToolDataNumber = New System.Windows.Forms.TextBox
Me.mopDelete = New System.Windows.Forms.Button
Me.mopEdit = New System.Windows.Forms.Button
Me.Label139 = New System.Windows.Forms.Label
Me.mopCMDClassNumber = New System.Windows.Forms.TextBox
Me.Label140 = New System.Windows.Forms.Label
Me.mopCMDToolNumber = New System.Windows.Forms.TextBox
Me.Label122 = New System.Windows.Forms.Label
Me.GroupBox7 = New System.Windows.Forms.GroupBox
Me.tab_MacManOperatingHistory = New System.Windows.Forms.TabPage
Me.Label204 = New System.Windows.Forms.Label
Me.mopnhMaxNoofReports = New System.Windows.Forms.TextBox
Me.GroupBox5 = New System.Windows.Forms.GroupBox
Me.mopnhPrevAlarmonTime = New System.Windows.Forms.TextBox
Me.mopnhPrevExternalInputTime = New System.Windows.Forms.TextBox
Me.mopnhPrevSpindleRunTime = New System.Windows.Forms.TextBox
Me.mopnhPrevOtherTime = New System.Windows.Forms.TextBox
Me.mopnhPrevMaintenanceTime = New System.Windows.Forms.TextBox
Me.mopnhPrevPartWaitingTime = New System.Windows.Forms.TextBox
Me.mopnhPrevNoOperatorTime = New System.Windows.Forms.TextBox
Me.mopnhPrevInProSetupTime = New System.Windows.Forms.TextBox
Me.mopnhPrevNonOperatingTime = New System.Windows.Forms.TextBox
Me.mopnhPrevCuttingTime = New System.Windows.Forms.TextBox
Me.mopnhPrevOperatingTime = New System.Windows.Forms.TextBox
Me.Label214 = New System.Windows.Forms.Label
Me.Label215 = New System.Windows.Forms.Label
Me.Label216 = New System.Windows.Forms.Label
Me.Label217 = New System.Windows.Forms.Label
Me.Label218 = New System.Windows.Forms.Label
Me.Label219 = New System.Windows.Forms.Label
Me.Label220 = New System.Windows.Forms.Label
Me.Label221 = New System.Windows.Forms.Label
Me.Label222 = New System.Windows.Forms.Label
Me.Label223 = New System.Windows.Forms.Label
Me.Label224 = New System.Windows.Forms.Label
Me.Label203 = New System.Windows.Forms.Label
Me.mopnhPrevRunningTime = New System.Windows.Forms.TextBox
Me.objMopnhUpdateButton = New System.Windows.Forms.Button
Me.Label202 = New System.Windows.Forms.Label
Me.Label201 = New System.Windows.Forms.Label
Me.mopnhTo = New System.Windows.Forms.TextBox
Me.GroupBox4 = New System.Windows.Forms.GroupBox
Me.mopnhAlarmOnTime = New System.Windows.Forms.TextBox
Me.mopnhExternalInputTime = New System.Windows.Forms.TextBox
Me.mopnhSpindleRunTime = New System.Windows.Forms.TextBox
Me.mopnhOtherTime = New System.Windows.Forms.TextBox
Me.mopnhMaintenanceTime = New System.Windows.Forms.TextBox
Me.mopnhPartWaitingTime = New System.Windows.Forms.TextBox
Me.mopnhNoOperatorTime = New System.Windows.Forms.TextBox
Me.mopnhInProSetupTime = New System.Windows.Forms.TextBox
Me.mopnhNonOperatingReport = New System.Windows.Forms.TextBox
Me.mopnhCuttingTime = New System.Windows.Forms.TextBox
Me.mopnhOperatingTime = New System.Windows.Forms.TextBox
Me.mopnhRunningTime = New System.Windows.Forms.TextBox
Me.Label200 = New System.Windows.Forms.Label
Me.Label199 = New System.Windows.Forms.Label
Me.Label198 = New System.Windows.Forms.Label
Me.Label197 = New System.Windows.Forms.Label
Me.Label196 = New System.Windows.Forms.Label
Me.Label195 = New System.Windows.Forms.Label
Me.Label194 = New System.Windows.Forms.Label
Me.Label193 = New System.Windows.Forms.Label
Me.Label192 = New System.Windows.Forms.Label
Me.Label191 = New System.Windows.Forms.Label
Me.Label190 = New System.Windows.Forms.Label
Me.Label108 = New System.Windows.Forms.Label
Me.mopnhFrom = New System.Windows.Forms.TextBox
Me.tab_MacmanOperatingReport = New System.Windows.Forms.TabPage
Me.morMaxNoOfOpReport = New System.Windows.Forms.TextBox
Me.Label288 = New System.Windows.Forms.Label
Me.morUpdateButton = New System.Windows.Forms.Button
Me.morOperatingStatus = New System.Windows.Forms.TextBox
Me.Label289 = New System.Windows.Forms.Label
Me.morNonoperatingCondition = New System.Windows.Forms.TextBox
Me.Label290 = New System.Windows.Forms.Label
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.Label64 = New System.Windows.Forms.Label
Me.morPrevExternalInputTime = New System.Windows.Forms.TextBox
Me.morPrevDateOfOperatingRept = New System.Windows.Forms.TextBox
Me.morPrevAlarmOnTime = New System.Windows.Forms.TextBox
Me.morPrevSpindleRunTime = New System.Windows.Forms.TextBox
Me.morPrevOtherTime = New System.Windows.Forms.TextBox
Me.morPrevMaintenanceTime = New System.Windows.Forms.TextBox
Me.morPrevPartwaitingTime = New System.Windows.Forms.TextBox
Me.morPrevNoOperatorTime = New System.Windows.Forms.TextBox
Me.morPrevInProSetupTime = New System.Windows.Forms.TextBox
Me.morPrevNonOperatingTime = New System.Windows.Forms.TextBox
Me.morPrevCuttingTime = New System.Windows.Forms.TextBox
Me.morPrevRunningTime = New System.Windows.Forms.TextBox
Me.Label276 = New System.Windows.Forms.Label
Me.Label277 = New System.Windows.Forms.Label
Me.Label278 = New System.Windows.Forms.Label
Me.Label279 = New System.Windows.Forms.Label
Me.Label280 = New System.Windows.Forms.Label
Me.Label281 = New System.Windows.Forms.Label
Me.Label282 = New System.Windows.Forms.Label
Me.Label283 = New System.Windows.Forms.Label
Me.Label284 = New System.Windows.Forms.Label
Me.Label285 = New System.Windows.Forms.Label
Me.Label286 = New System.Windows.Forms.Label
Me.Label287 = New System.Windows.Forms.Label
Me.morPrevOperatingTime = New System.Windows.Forms.TextBox
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.Label240 = New System.Windows.Forms.Label
Me.morOperatingTime = New System.Windows.Forms.TextBox
Me.Label264 = New System.Windows.Forms.Label
Me.Label265 = New System.Windows.Forms.Label
Me.Label266 = New System.Windows.Forms.Label
Me.Label267 = New System.Windows.Forms.Label
Me.Label268 = New System.Windows.Forms.Label
Me.Label269 = New System.Windows.Forms.Label
Me.morRunningTime = New System.Windows.Forms.TextBox
Me.morCuttingTime = New System.Windows.Forms.TextBox
Me.morNonOPeratingTime = New System.Windows.Forms.TextBox
Me.morInProSetupTime = New System.Windows.Forms.TextBox
Me.morNoOperatorTime = New System.Windows.Forms.TextBox
Me.morPartWaitingTime = New System.Windows.Forms.TextBox
Me.Label270 = New System.Windows.Forms.Label
Me.mormaintenanceTime = New System.Windows.Forms.TextBox
Me.Label271 = New System.Windows.Forms.Label
Me.morOtherTime = New System.Windows.Forms.TextBox
Me.Label272 = New System.Windows.Forms.Label
Me.morSpindleRunTime = New System.Windows.Forms.TextBox
Me.Label273 = New System.Windows.Forms.Label
Me.morExternalInputTime = New System.Windows.Forms.TextBox
Me.morAlarmOnTime = New System.Windows.Forms.TextBox
Me.Label274 = New System.Windows.Forms.Label
Me.morDateOfOperatingReport = New System.Windows.Forms.TextBox
Me.Label275 = New System.Windows.Forms.Label
Me.GroupBox3 = New System.Windows.Forms.GroupBox
Me.morPeriodDateOfOperatingReport = New System.Windows.Forms.TextBox
Me.morPeriodAlarmOnTime = New System.Windows.Forms.TextBox
Me.morPeriodExternalInputTime = New System.Windows.Forms.TextBox
Me.morPeriodSpindleRunTime = New System.Windows.Forms.TextBox
Me.morPeriodOtherTime = New System.Windows.Forms.TextBox
Me.morPeriodMaintenanceTime = New System.Windows.Forms.TextBox
Me.morPeriodNoOperatorTime = New System.Windows.Forms.TextBox
Me.morPeriodPartWaitingTime = New System.Windows.Forms.TextBox
Me.morPeriodInproSetupTime = New System.Windows.Forms.TextBox
Me.morPeriodNonOperatingTime = New System.Windows.Forms.TextBox
Me.morPeriodCuttingTime = New System.Windows.Forms.TextBox
Me.morPeriodRunningTime = New System.Windows.Forms.TextBox
Me.Label65 = New System.Windows.Forms.Label
Me.Label109 = New System.Windows.Forms.Label
Me.Label110 = New System.Windows.Forms.Label
Me.Label111 = New System.Windows.Forms.Label
Me.Label112 = New System.Windows.Forms.Label
Me.Label130 = New System.Windows.Forms.Label
Me.Label141 = New System.Windows.Forms.Label
Me.Label153 = New System.Windows.Forms.Label
Me.Label154 = New System.Windows.Forms.Label
Me.Label155 = New System.Windows.Forms.Label
Me.Label237 = New System.Windows.Forms.Label
Me.Label238 = New System.Windows.Forms.Label
Me.morPeriodOperatingTime = New System.Windows.Forms.TextBox
Me.Label239 = New System.Windows.Forms.Label
Me.tab_PLC = New System.Windows.Forms.TabPage
Me.grpIOVariables = New System.Windows.Forms.GroupBox
Me.Label297 = New System.Windows.Forms.Label
Me.cboIOVariableTypes = New System.Windows.Forms.ComboBox
Me.cmdIOGetBit = New System.Windows.Forms.Button
Me.cmdIOGetWord = New System.Windows.Forms.Button
Me.cmdIOGetLongWord = New System.Windows.Forms.Button
Me.txtIOLongWord = New System.Windows.Forms.TextBox
Me.txtIOWord = New System.Windows.Forms.TextBox
Me.txtIOBit = New System.Windows.Forms.TextBox
Me.Label296 = New System.Windows.Forms.Label
Me.txtIOBitNo = New System.Windows.Forms.TextBox
Me.Label295 = New System.Windows.Forms.Label
Me.txtIOLongWordIndex = New System.Windows.Forms.TextBox
Me.Label294 = New System.Windows.Forms.Label
Me.txtIOWordIndex = New System.Windows.Forms.TextBox
Me.Label293 = New System.Windows.Forms.Label
Me.txtIOBitIndex = New System.Windows.Forms.TextBox
Me.Label292 = New System.Windows.Forms.Label
Me.tab_workpiece = New System.Windows.Forms.TabPage
Me.wkSetDataUnitButton = New System.Windows.Forms.Button
Me.wkDataUnitCombo = New System.Windows.Forms.ComboBox
Me.Label152 = New System.Windows.Forms.Label
Me.Label129 = New System.Windows.Forms.Label
Me.wkZeroTo = New System.Windows.Forms.TextBox
Me.Label127 = New System.Windows.Forms.Label
Me.wkZeroFrom = New System.Windows.Forms.TextBox
Me.Label128 = New System.Windows.Forms.Label
Me.wkZeroResults = New System.Windows.Forms.TextBox
Me.wkButtonGetCounter = New System.Windows.Forms.Button
Me.Label97 = New System.Windows.Forms.Label
Me.Label96 = New System.Windows.Forms.Label
Me.wkUpdateValsWithNoParams = New System.Windows.Forms.Button
Me.wkValsWithoutParameters = New System.Windows.Forms.TextBox
Me.wkCounterSetButton = New System.Windows.Forms.Button
Me.wkCounterValue = New System.Windows.Forms.TextBox
Me.Label95 = New System.Windows.Forms.Label
Me.wkUpdateCounter = New System.Windows.Forms.TextBox
Me.wkCounterCombo = New System.Windows.Forms.ComboBox
Me.wkUpdateZeroOffset = New System.Windows.Forms.TextBox
Me.wkZeroOffset = New System.Windows.Forms.TextBox
Me.Label94 = New System.Windows.Forms.Label
Me.wkAxisCombo = New System.Windows.Forms.ComboBox
Me.Panel9 = New System.Windows.Forms.Panel
Me.wkButtonZeroOffsetGet = New System.Windows.Forms.Button
Me.wkButtonZeroOffsetCal = New System.Windows.Forms.Button
Me.wkButtonZeroOffsetAdd = New System.Windows.Forms.Button
Me.wkButtonZeroOffsetSet = New System.Windows.Forms.Button
Me.wkOffsetNumber = New System.Windows.Forms.TextBox
Me.Label93 = New System.Windows.Forms.Label
Me.Panel10 = New System.Windows.Forms.Panel
Me.cmd_WorkpieceAdd = New System.Windows.Forms.Button
Me.tab_coolant = New System.Windows.Forms.TabPage
Me.coolantUpdateButton = New System.Windows.Forms.Button
Me.coolantChipCondition = New System.Windows.Forms.TextBox
Me.Label36 = New System.Windows.Forms.Label
Me.tab_spindle = New System.Windows.Forms.TabPage
Me.spinState = New System.Windows.Forms.TextBox
Me.Label73 = New System.Windows.Forms.Label
Me.spinUpdate = New System.Windows.Forms.Button
Me.spinRateOverride = New System.Windows.Forms.TextBox
Me.Label67 = New System.Windows.Forms.Label
Me.spinLoad = New System.Windows.Forms.TextBox
Me.Label68 = New System.Windows.Forms.Label
Me.spinOilMist = New System.Windows.Forms.TextBox
Me.Label69 = New System.Windows.Forms.Label
Me.spinMaxOverrideRate = New System.Windows.Forms.TextBox
Me.Label70 = New System.Windows.Forms.Label
Me.spinCommandRate = New System.Windows.Forms.TextBox
Me.Label71 = New System.Windows.Forms.Label
Me.spinActualRate = New System.Windows.Forms.TextBox
Me.Label72 = New System.Windows.Forms.Label
Me.tab_variables = New System.Windows.Forms.TabPage
Me.Label90 = New System.Windows.Forms.Label
Me.varValue = New System.Windows.Forms.TextBox
Me.varUpdateButton = New System.Windows.Forms.Button
Me.varGetAllButton = New System.Windows.Forms.Button
Me.Label89 = New System.Windows.Forms.Label
Me.varNumberOfVars = New System.Windows.Forms.TextBox
Me.varGetAllResults = New System.Windows.Forms.TextBox
Me.varAddValue = New System.Windows.Forms.Button
Me.varSetValue = New System.Windows.Forms.Button
Me.varEnd = New System.Windows.Forms.TextBox
Me.varBegin = New System.Windows.Forms.TextBox
Me.varValueUpdate = New System.Windows.Forms.TextBox
Me.Label91 = New System.Windows.Forms.Label
Me.varCommonVarNumber = New System.Windows.Forms.TextBox
Me.Label92 = New System.Windows.Forms.Label
Me.errorlog = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.clearLogButton = New System.Windows.Forms.Button
Me.MainTabControl.SuspendLayout
Me.tab_atc.SuspendLayout
Me.GroupBox13.SuspendLayout
Me.Panel1.SuspendLayout
Me.Panel2.SuspendLayout
Me.Panel3.SuspendLayout
Me.tab_program.SuspendLayout
Me.GroupBox15.SuspendLayout
Me.GroupBox14.SuspendLayout
Me.Panel8.SuspendLayout
Me.tab_Program2.SuspendLayout
Me.Tools2_2.SuspendLayout
Me.GroupBox21.SuspendLayout
Me.GroupBox19.SuspendLayout
Me.GroupBox18.SuspendLayout
Me.tab_Tools2_1.SuspendLayout
Me.GroupBox16.SuspendLayout
Me.GroupBox17.SuspendLayout
Me.tab_machine.SuspendLayout
Me.GroupBox8.SuspendLayout
Me.Panel11.SuspendLayout
Me.tab_MacManAlarmHistory.SuspendLayout
CType(Me.grdMMAlarmHistory,System.ComponentModel.ISupportInitialize).BeginInit
Me.GroupBox9.SuspendLayout
Me.tab_tools.SuspendLayout
Me.tab_axis.SuspendLayout
Me.tab_axis2.SuspendLayout
Me.GroupBox11.SuspendLayout
Me.tab_spec.SuspendLayout
Me.GroupBox10.SuspendLayout
Me.tab_MacManMachiningReport.SuspendLayout
CType(Me.grdMMMachiningReports,System.ComponentModel.ISupportInitialize).BeginInit
Me.Tab_View.SuspendLayout
Me.Panel12.SuspendLayout
Me.tab_MacmanOperationHistory.SuspendLayout
Me.tab_ballscrew.SuspendLayout
Me.tab_CurrentAlarm.SuspendLayout
Me.GroupBox20.SuspendLayout
Me.tab_OptionalParameter.SuspendLayout
Me.GroupBox12.SuspendLayout
Me.tab_MopTool.SuspendLayout
Me.Panel6.SuspendLayout
Me.GroupBox6.SuspendLayout
Me.tab_MacManOperatingHistory.SuspendLayout
Me.GroupBox5.SuspendLayout
Me.GroupBox4.SuspendLayout
Me.tab_MacmanOperatingReport.SuspendLayout
Me.GroupBox1.SuspendLayout
Me.GroupBox2.SuspendLayout
Me.GroupBox3.SuspendLayout
Me.tab_PLC.SuspendLayout
Me.grpIOVariables.SuspendLayout
Me.tab_workpiece.SuspendLayout
Me.Panel9.SuspendLayout
Me.Panel10.SuspendLayout
Me.tab_coolant.SuspendLayout
Me.tab_spindle.SuspendLayout
Me.tab_variables.SuspendLayout
Me.SuspendLayout
'
'MainTabControl
'
Me.MainTabControl.Controls.Add(Me.tab_atc)
Me.MainTabControl.Controls.Add(Me.tab_program)
Me.MainTabControl.Controls.Add(Me.tab_Program2)
Me.MainTabControl.Controls.Add(Me.Tools2_2)
Me.MainTabControl.Controls.Add(Me.tab_Tools2_1)
Me.MainTabControl.Controls.Add(Me.tab_machine)
Me.MainTabControl.Controls.Add(Me.tab_MacManAlarmHistory)
Me.MainTabControl.Controls.Add(Me.tab_tools)
Me.MainTabControl.Controls.Add(Me.tab_axis)
Me.MainTabControl.Controls.Add(Me.tab_axis2)
Me.MainTabControl.Controls.Add(Me.tab_spec)
Me.MainTabControl.Controls.Add(Me.tab_MacManMachiningReport)
Me.MainTabControl.Controls.Add(Me.Tab_View)
Me.MainTabControl.Controls.Add(Me.tab_MacmanOperationHistory)
Me.MainTabControl.Controls.Add(Me.tab_ballscrew)
Me.MainTabControl.Controls.Add(Me.tab_CurrentAlarm)
Me.MainTabControl.Controls.Add(Me.tab_OptionalParameter)
Me.MainTabControl.Controls.Add(Me.tab_MopTool)
Me.MainTabControl.Controls.Add(Me.tab_MacManOperatingHistory)
Me.MainTabControl.Controls.Add(Me.tab_MacmanOperatingReport)
Me.MainTabControl.Controls.Add(Me.tab_PLC)
Me.MainTabControl.Controls.Add(Me.tab_workpiece)
Me.MainTabControl.Controls.Add(Me.tab_coolant)
Me.MainTabControl.Controls.Add(Me.tab_spindle)
Me.MainTabControl.Controls.Add(Me.tab_variables)
Me.MainTabControl.Location = New System.Drawing.Point(8, 16)
Me.MainTabControl.Name = "MainTabControl"
Me.MainTabControl.SelectedIndex = 0
Me.MainTabControl.Size = New System.Drawing.Size(784, 472)
Me.MainTabControl.TabIndex = 0
'
'tab_atc
'
Me.tab_atc.Controls.Add(Me.GroupBox13)
Me.tab_atc.Controls.Add(Me.atcSetLargeToolMemo)
Me.tab_atc.Controls.Add(Me.atcSetHeavyToolMemo)
Me.tab_atc.Controls.Add(Me.Label5)
Me.tab_atc.Controls.Add(Me.Label4)
Me.tab_atc.Controls.Add(Me.largeToolMemo)
Me.tab_atc.Controls.Add(Me.Label3)
Me.tab_atc.Controls.Add(Me.heavyToolMemo)
Me.tab_atc.Controls.Add(Me.atcUpdateButton)
Me.tab_atc.Controls.Add(Me.atcStatus)
Me.tab_atc.Controls.Add(Me.atcPotNumberButton)
Me.tab_atc.Controls.Add(Me.pot_number_lbl)
Me.tab_atc.Controls.Add(Me.potNumber)
Me.tab_atc.Controls.Add(Me.Panel1)
Me.tab_atc.Controls.Add(Me.Panel2)
Me.tab_atc.Controls.Add(Me.Label6)
Me.tab_atc.Controls.Add(Me.magazineNumber)
Me.tab_atc.Controls.Add(Me.Panel3)
Me.tab_atc.Controls.Add(Me.Button4)
Me.tab_atc.Location = New System.Drawing.Point(4, 22)
Me.tab_atc.Name = "tab_atc"
Me.tab_atc.Size = New System.Drawing.Size(776, 446)
Me.tab_atc.TabIndex = 0
Me.tab_atc.Text = "ATC"
'
'GroupBox13
'
Me.GroupBox13.Controls.Add(Me.cmdSetReturnPot)
Me.GroupBox13.Controls.Add(Me.cmdSetNextTool)
Me.GroupBox13.Controls.Add(Me.atcComboToolAttribute)
Me.GroupBox13.Controls.Add(Me.Label138)
Me.GroupBox13.Controls.Add(Me.atcButtonCancelTool)
Me.GroupBox13.Controls.Add(Me.atcCMDToolNumber)
Me.GroupBox13.Controls.Add(Me.Label136)
Me.GroupBox13.Controls.Add(Me.atcCMDPotNumber)
Me.GroupBox13.Controls.Add(Me.Label135)
Me.GroupBox13.Controls.Add(Me.cmdSetActualTool)
Me.GroupBox13.Controls.Add(Me.atcButtonUnRegister)
Me.GroupBox13.Controls.Add(Me.atcButtonRegisterAttribute)
Me.GroupBox13.Controls.Add(Me.atcButtonRegister)
Me.GroupBox13.Location = New System.Drawing.Point(320, 152)
Me.GroupBox13.Name = "GroupBox13"
Me.GroupBox13.Size = New System.Drawing.Size(448, 152)
Me.GroupBox13.TabIndex = 177
Me.GroupBox13.TabStop = false
'
'cmdSetReturnPot
'
Me.cmdSetReturnPot.Location = New System.Drawing.Point(248, 120)
Me.cmdSetReturnPot.Name = "cmdSetReturnPot"
Me.cmdSetReturnPot.Size = New System.Drawing.Size(104, 24)
Me.cmdSetReturnPot.TabIndex = 178
Me.cmdSetReturnPot.Text = "Set Return Pot"
'
'cmdSetNextTool
'
Me.cmdSetNextTool.Location = New System.Drawing.Point(136, 120)
Me.cmdSetNextTool.Name = "cmdSetNextTool"
Me.cmdSetNextTool.Size = New System.Drawing.Size(104, 24)
Me.cmdSetNextTool.TabIndex = 177
Me.cmdSetNextTool.Text = "Set Next Tool"
'
'atcComboToolAttribute
'
Me.atcComboToolAttribute.Location = New System.Drawing.Point(296, 24)
Me.atcComboToolAttribute.Name = "atcComboToolAttribute"
Me.atcComboToolAttribute.Size = New System.Drawing.Size(96, 21)
Me.atcComboToolAttribute.TabIndex = 164
'
'Label138
'
Me.Label138.Location = New System.Drawing.Point(208, 24)
Me.Label138.Name = "Label138"
Me.Label138.Size = New System.Drawing.Size(80, 16)
Me.Label138.TabIndex = 171
Me.Label138.Text = "Tool Attribute:"
'
'atcButtonCancelTool
'
Me.atcButtonCancelTool.Location = New System.Drawing.Point(360, 120)
Me.atcButtonCancelTool.Name = "atcButtonCancelTool"
Me.atcButtonCancelTool.Size = New System.Drawing.Size(80, 24)
Me.atcButtonCancelTool.TabIndex = 175
Me.atcButtonCancelTool.Text = "Cancel Tool"
'
'atcCMDToolNumber
'
Me.atcCMDToolNumber.Location = New System.Drawing.Point(104, 56)
Me.atcCMDToolNumber.Name = "atcCMDToolNumber"
Me.atcCMDToolNumber.Size = New System.Drawing.Size(64, 20)
Me.atcCMDToolNumber.TabIndex = 165
Me.atcCMDToolNumber.Tag = ""
Me.atcCMDToolNumber.Text = "1"
'
'Label136
'
Me.Label136.Location = New System.Drawing.Point(216, 56)
Me.Label136.Name = "Label136"
Me.Label136.Size = New System.Drawing.Size(64, 16)
Me.Label136.TabIndex = 168
Me.Label136.Text = "Pot Number"
'
'atcCMDPotNumber
'
Me.atcCMDPotNumber.Location = New System.Drawing.Point(296, 56)
Me.atcCMDPotNumber.Name = "atcCMDPotNumber"
Me.atcCMDPotNumber.Size = New System.Drawing.Size(64, 20)
Me.atcCMDPotNumber.TabIndex = 167
Me.atcCMDPotNumber.Text = "1"
'
'Label135
'
Me.Label135.Location = New System.Drawing.Point(16, 56)
Me.Label135.Name = "Label135"
Me.Label135.Size = New System.Drawing.Size(72, 16)
Me.Label135.TabIndex = 166
Me.Label135.Text = "Tool Number"
'
'cmdSetActualTool
'
Me.cmdSetActualTool.Location = New System.Drawing.Point(16, 120)
Me.cmdSetActualTool.Name = "cmdSetActualTool"
Me.cmdSetActualTool.Size = New System.Drawing.Size(112, 24)
Me.cmdSetActualTool.TabIndex = 176
Me.cmdSetActualTool.Text = "Set Actual Tool"
'
'atcButtonUnRegister
'
Me.atcButtonUnRegister.Location = New System.Drawing.Point(288, 88)
Me.atcButtonUnRegister.Name = "atcButtonUnRegister"
Me.atcButtonUnRegister.Size = New System.Drawing.Size(104, 24)
Me.atcButtonUnRegister.TabIndex = 174
Me.atcButtonUnRegister.Text = "Unregister Tool"
'
'atcButtonRegisterAttribute
'
Me.atcButtonRegisterAttribute.Location = New System.Drawing.Point(120, 88)
Me.atcButtonRegisterAttribute.Name = "atcButtonRegisterAttribute"
Me.atcButtonRegisterAttribute.Size = New System.Drawing.Size(160, 24)
Me.atcButtonRegisterAttribute.TabIndex = 173
Me.atcButtonRegisterAttribute.Text = "Register with Tool Attribute"
'
'atcButtonRegister
'
Me.atcButtonRegister.Location = New System.Drawing.Point(16, 88)
Me.atcButtonRegister.Name = "atcButtonRegister"
Me.atcButtonRegister.Size = New System.Drawing.Size(96, 24)
Me.atcButtonRegister.TabIndex = 172
Me.atcButtonRegister.Text = "Register Tool"
'
'atcSetLargeToolMemo
'
Me.atcSetLargeToolMemo.Location = New System.Drawing.Point(232, 192)
Me.atcSetLargeToolMemo.Name = "atcSetLargeToolMemo"
Me.atcSetLargeToolMemo.Size = New System.Drawing.Size(44, 24)
Me.atcSetLargeToolMemo.TabIndex = 15
Me.atcSetLargeToolMemo.Text = "Set"
'
'atcSetHeavyToolMemo
'
Me.atcSetHeavyToolMemo.Location = New System.Drawing.Point(232, 160)
Me.atcSetHeavyToolMemo.Name = "atcSetHeavyToolMemo"
Me.atcSetHeavyToolMemo.Size = New System.Drawing.Size(44, 24)
Me.atcSetHeavyToolMemo.TabIndex = 14
Me.atcSetHeavyToolMemo.Text = "Set"
'
'Label5
'
Me.Label5.Location = New System.Drawing.Point(312, 16)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(80, 40)
Me.Label5.TabIndex = 13
Me.Label5.Text = "Values with no parameters :"
Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'Label4
'
Me.Label4.Location = New System.Drawing.Point(16, 192)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(104, 16)
Me.Label4.TabIndex = 12
Me.Label4.Text = "Large Tool Memo"
'
'largeToolMemo
'
Me.largeToolMemo.Location = New System.Drawing.Point(120, 192)
Me.largeToolMemo.Name = "largeToolMemo"
Me.largeToolMemo.Size = New System.Drawing.Size(104, 20)
Me.largeToolMemo.TabIndex = 11
Me.largeToolMemo.Text = ""
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(16, 160)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(104, 16)
Me.Label3.TabIndex = 10
Me.Label3.Text = "Heavy Tool Memo"
'
'heavyToolMemo
'
Me.heavyToolMemo.Location = New System.Drawing.Point(120, 160)
Me.heavyToolMemo.Name = "heavyToolMemo"
Me.heavyToolMemo.Size = New System.Drawing.Size(104, 20)
Me.heavyToolMemo.TabIndex = 9
Me.heavyToolMemo.Text = ""
'
'atcUpdateButton
'
Me.atcUpdateButton.Location = New System.Drawing.Point(320, 64)
Me.atcUpdateButton.Name = "atcUpdateButton"
Me.atcUpdateButton.Size = New System.Drawing.Size(72, 24)
Me.atcUpdateButton.TabIndex = 4
Me.atcUpdateButton.Text = "Update"
'
'atcStatus
'
Me.atcStatus.Location = New System.Drawing.Point(408, 16)
Me.atcStatus.Multiline = true
Me.atcStatus.Name = "atcStatus"
Me.atcStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.atcStatus.Size = New System.Drawing.Size(360, 128)
Me.atcStatus.TabIndex = 3
Me.atcStatus.Text = ""
'
'atcPotNumberButton
'
Me.atcPotNumberButton.Location = New System.Drawing.Point(160, 24)
Me.atcPotNumberButton.Name = "atcPotNumberButton"
Me.atcPotNumberButton.Size = New System.Drawing.Size(88, 24)
Me.atcPotNumberButton.TabIndex = 2
Me.atcPotNumberButton.Text = "Get Tool Info"
'
'pot_number_lbl
'
Me.pot_number_lbl.Location = New System.Drawing.Point(16, 24)
Me.pot_number_lbl.Name = "pot_number_lbl"
Me.pot_number_lbl.Size = New System.Drawing.Size(64, 16)
Me.pot_number_lbl.TabIndex = 1
Me.pot_number_lbl.Text = "Pot Number"
'
'potNumber
'
Me.potNumber.Location = New System.Drawing.Point(80, 24)
Me.potNumber.Name = "potNumber"
Me.potNumber.Size = New System.Drawing.Size(64, 20)
Me.potNumber.TabIndex = 0
Me.potNumber.Text = "1"
'
'Panel1
'
Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel1.Controls.Add(Me.Label38)
Me.Panel1.Controls.Add(Me.potToolKind)
Me.Panel1.Controls.Add(Me.potToolNumber)
Me.Panel1.Controls.Add(Me.Label37)
Me.Panel1.Location = New System.Drawing.Point(8, 8)
Me.Panel1.Name = "Panel1"
Me.Panel1.Size = New System.Drawing.Size(296, 104)
Me.Panel1.TabIndex = 5
'
'Label38
'
Me.Label38.Location = New System.Drawing.Point(8, 72)
Me.Label38.Name = "Label38"
Me.Label38.Size = New System.Drawing.Size(88, 16)
Me.Label38.TabIndex = 18
Me.Label38.Text = "Tool Kind"
'
'potToolKind
'
Me.potToolKind.Location = New System.Drawing.Point(112, 72)
Me.potToolKind.Name = "potToolKind"
Me.potToolKind.Size = New System.Drawing.Size(88, 20)
Me.potToolKind.TabIndex = 17
Me.potToolKind.Text = ""
'
'potToolNumber
'
Me.potToolNumber.Location = New System.Drawing.Point(112, 48)
Me.potToolNumber.Name = "potToolNumber"
Me.potToolNumber.Size = New System.Drawing.Size(88, 20)
Me.potToolNumber.TabIndex = 16
Me.potToolNumber.Text = ""
'
'Label37
'
Me.Label37.Location = New System.Drawing.Point(8, 48)
Me.Label37.Name = "Label37"
Me.Label37.Size = New System.Drawing.Size(88, 16)
Me.Label37.TabIndex = 16
Me.Label37.Text = "Tool Number"
'
'Panel2
'
Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel2.Controls.Add(Me.getMemoButton)
Me.Panel2.Location = New System.Drawing.Point(8, 120)
Me.Panel2.Name = "Panel2"
Me.Panel2.Size = New System.Drawing.Size(296, 104)
Me.Panel2.TabIndex = 6
'
'getMemoButton
'
Me.getMemoButton.Location = New System.Drawing.Point(8, 8)
Me.getMemoButton.Name = "getMemoButton"
Me.getMemoButton.Size = New System.Drawing.Size(72, 24)
Me.getMemoButton.TabIndex = 8
Me.getMemoButton.Text = "Get Memo"
'
'Label6
'
Me.Label6.Location = New System.Drawing.Point(16, 240)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(104, 16)
Me.Label6.TabIndex = 11
Me.Label6.Text = "Magazine Number"
'
'magazineNumber
'
Me.magazineNumber.Location = New System.Drawing.Point(120, 240)
Me.magazineNumber.Name = "magazineNumber"
Me.magazineNumber.Size = New System.Drawing.Size(64, 20)
Me.magazineNumber.TabIndex = 9
Me.magazineNumber.Text = "1"
'
'Panel3
'
Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel3.Controls.Add(Me.atcMagazinePosition)
Me.Panel3.Controls.Add(Me.Label114)
Me.Panel3.Controls.Add(Me.endingPot)
Me.Panel3.Controls.Add(Me.Label9)
Me.Panel3.Controls.Add(Me.startingPot)
Me.Panel3.Controls.Add(Me.Label8)
Me.Panel3.Controls.Add(Me.getMagazineButton)
Me.Panel3.Controls.Add(Me.numberOfPots)
Me.Panel3.Controls.Add(Me.Label7)
Me.Panel3.Location = New System.Drawing.Point(8, 232)
Me.Panel3.Name = "Panel3"
Me.Panel3.Size = New System.Drawing.Size(296, 144)
Me.Panel3.TabIndex = 10
'
'atcMagazinePosition
'
Me.atcMagazinePosition.Location = New System.Drawing.Point(128, 112)
Me.atcMagazinePosition.Name = "atcMagazinePosition"
Me.atcMagazinePosition.Size = New System.Drawing.Size(96, 20)
Me.atcMagazinePosition.TabIndex = 23
Me.atcMagazinePosition.Text = ""
'
'Label114
'
Me.Label114.Location = New System.Drawing.Point(8, 112)
Me.Label114.Name = "Label114"
Me.Label114.Size = New System.Drawing.Size(104, 16)
Me.Label114.TabIndex = 22
Me.Label114.Text = "Magazine Position :"
'
'endingPot
'
Me.endingPot.Location = New System.Drawing.Point(128, 88)
Me.endingPot.Name = "endingPot"
Me.endingPot.Size = New System.Drawing.Size(96, 20)
Me.endingPot.TabIndex = 20
Me.endingPot.Text = ""
'
'Label9
'
Me.Label9.Location = New System.Drawing.Point(8, 64)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(120, 16)
Me.Label9.TabIndex = 21
Me.Label9.Text = "Starting Pot Number"
'
'startingPot
'
Me.startingPot.Location = New System.Drawing.Point(128, 64)
Me.startingPot.Name = "startingPot"
Me.startingPot.Size = New System.Drawing.Size(96, 20)
Me.startingPot.TabIndex = 18
Me.startingPot.Text = ""
'
'Label8
'
Me.Label8.Location = New System.Drawing.Point(8, 40)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(104, 16)
Me.Label8.TabIndex = 19
Me.Label8.Text = "Number of Pots"
'
'getMagazineButton
'
Me.getMagazineButton.Location = New System.Drawing.Point(184, 8)
Me.getMagazineButton.Name = "getMagazineButton"
Me.getMagazineButton.Size = New System.Drawing.Size(104, 24)
Me.getMagazineButton.TabIndex = 16
Me.getMagazineButton.Text = "Get Magazine"
'
'numberOfPots
'
Me.numberOfPots.Location = New System.Drawing.Point(128, 40)
Me.numberOfPots.Name = "numberOfPots"
Me.numberOfPots.Size = New System.Drawing.Size(96, 20)
Me.numberOfPots.TabIndex = 16
Me.numberOfPots.Text = ""
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(8, 88)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(104, 16)
Me.Label7.TabIndex = 17
Me.Label7.Text = "Ending Pot Number"
'
'Button4
'
Me.Button4.Location = New System.Drawing.Point(176, 240)
Me.Button4.Name = "Button4"
Me.Button4.Size = New System.Drawing.Size(72, 24)
Me.Button4.TabIndex = 12
Me.Button4.Text = "Get Memo"
'
'tab_program
'
Me.tab_program.Controls.Add(Me.GroupBox15)
Me.tab_program.Controls.Add(Me.GroupBox14)
Me.tab_program.Controls.Add(Me.progButtonExecBlock)
Me.tab_program.Controls.Add(Me.progExecutePoint)
Me.tab_program.Controls.Add(Me.Label59)
Me.tab_program.Controls.Add(Me.progRead)
Me.tab_program.Controls.Add(Me.Label60)
Me.tab_program.Controls.Add(Me.progColumn)
Me.tab_program.Controls.Add(Me.Label61)
Me.tab_program.Controls.Add(Me.progRow)
Me.tab_program.Controls.Add(Me.Label62)
Me.tab_program.Controls.Add(Me.Label58)
Me.tab_program.Controls.Add(Me.progExecutingBlock)
Me.tab_program.Controls.Add(Me.label99)
Me.tab_program.Controls.Add(Me.progExecCombo)
Me.tab_program.Controls.Add(Me.Label57)
Me.tab_program.Controls.Add(Me.progUpdateButton)
Me.tab_program.Controls.Add(Me.progNoParams)
Me.tab_program.Controls.Add(Me.Panel7)
Me.tab_program.Controls.Add(Me.Panel8)
Me.tab_program.Location = New System.Drawing.Point(4, 22)
Me.tab_program.Name = "tab_program"
Me.tab_program.Size = New System.Drawing.Size(776, 446)
Me.tab_program.TabIndex = 6
Me.tab_program.Text = "Program"
'
'GroupBox15
'
Me.GroupBox15.Controls.Add(Me.cmdReturnSearch)
Me.GroupBox15.Controls.Add(Me.cboSR_MIDBlockRestart)
Me.GroupBox15.Controls.Add(Me.cboSR_AxisMovementOrder)
Me.GroupBox15.Controls.Add(Me.txtSR_RepeatNumber)
Me.GroupBox15.Controls.Add(Me.Label175)
Me.GroupBox15.Controls.Add(Me.txtSR_RelativeBlock)
Me.GroupBox15.Controls.Add(Me.Label171)
Me.GroupBox15.Controls.Add(Me.Label172)
Me.GroupBox15.Controls.Add(Me.Label173)
Me.GroupBox15.Controls.Add(Me.txtSR_SequenceBlockNumber)
Me.GroupBox15.Controls.Add(Me.Label174)
Me.GroupBox15.Location = New System.Drawing.Point(432, 304)
Me.GroupBox15.Name = "GroupBox15"
Me.GroupBox15.Size = New System.Drawing.Size(336, 144)
Me.GroupBox15.TabIndex = 110
Me.GroupBox15.TabStop = false
'
'cmdReturnSearch
'
Me.cmdReturnSearch.Location = New System.Drawing.Point(232, 96)
Me.cmdReturnSearch.Name = "cmdReturnSearch"
Me.cmdReturnSearch.Size = New System.Drawing.Size(96, 40)
Me.cmdReturnSearch.TabIndex = 107
Me.cmdReturnSearch.Text = "Return Search"
'
'cboSR_MIDBlockRestart
'
Me.cboSR_MIDBlockRestart.Location = New System.Drawing.Point(160, 62)
Me.cboSR_MIDBlockRestart.Name = "cboSR_MIDBlockRestart"
Me.cboSR_MIDBlockRestart.Size = New System.Drawing.Size(152, 21)
Me.cboSR_MIDBlockRestart.TabIndex = 88
'
'cboSR_AxisMovementOrder
'
Me.cboSR_AxisMovementOrder.Location = New System.Drawing.Point(160, 40)
Me.cboSR_AxisMovementOrder.Name = "cboSR_AxisMovementOrder"
Me.cboSR_AxisMovementOrder.Size = New System.Drawing.Size(152, 21)
Me.cboSR_AxisMovementOrder.TabIndex = 87
'
'txtSR_RepeatNumber
'
Me.txtSR_RepeatNumber.Location = New System.Drawing.Point(160, 112)
Me.txtSR_RepeatNumber.Name = "txtSR_RepeatNumber"
Me.txtSR_RepeatNumber.Size = New System.Drawing.Size(64, 20)
Me.txtSR_RepeatNumber.TabIndex = 86
Me.txtSR_RepeatNumber.Text = "1"
'
'Label175
'
Me.Label175.Location = New System.Drawing.Point(16, 112)
Me.Label175.Name = "Label175"
Me.Label175.Size = New System.Drawing.Size(136, 16)
Me.Label175.TabIndex = 85
Me.Label175.Text = "Repeat Number"
'
'txtSR_RelativeBlock
'
Me.txtSR_RelativeBlock.Location = New System.Drawing.Point(160, 88)
Me.txtSR_RelativeBlock.Name = "txtSR_RelativeBlock"
Me.txtSR_RelativeBlock.Size = New System.Drawing.Size(64, 20)
Me.txtSR_RelativeBlock.TabIndex = 84
Me.txtSR_RelativeBlock.Text = "0"
'
'Label171
'
Me.Label171.Location = New System.Drawing.Point(16, 88)
Me.Label171.Name = "Label171"
Me.Label171.Size = New System.Drawing.Size(136, 16)
Me.Label171.TabIndex = 83
Me.Label171.Text = "Relative Block"
'
'Label172
'
Me.Label172.Location = New System.Drawing.Point(16, 40)
Me.Label172.Name = "Label172"
Me.Label172.Size = New System.Drawing.Size(136, 16)
Me.Label172.TabIndex = 82
Me.Label172.Text = "Axis Movement Order"
'
'Label173
'
Me.Label173.Location = New System.Drawing.Point(16, 16)
Me.Label173.Name = "Label173"
Me.Label173.Size = New System.Drawing.Size(136, 16)
Me.Label173.TabIndex = 80
Me.Label173.Text = "Sequence/Block number"
'
'txtSR_SequenceBlockNumber
'
Me.txtSR_SequenceBlockNumber.Location = New System.Drawing.Point(160, 16)
Me.txtSR_SequenceBlockNumber.Name = "txtSR_SequenceBlockNumber"
Me.txtSR_SequenceBlockNumber.Size = New System.Drawing.Size(64, 20)
Me.txtSR_SequenceBlockNumber.TabIndex = 77
Me.txtSR_SequenceBlockNumber.Text = "10"
'
'Label174
'
Me.Label174.Location = New System.Drawing.Point(16, 64)
Me.Label174.Name = "Label174"
Me.Label174.Size = New System.Drawing.Size(136, 16)
Me.Label174.TabIndex = 78
Me.Label174.Text = "MID Block Restart"
'
'GroupBox14
'
Me.GroupBox14.Controls.Add(Me.cmdSelectScheduleProgram)
Me.GroupBox14.Controls.Add(Me.cboFileReadModeEnum)
Me.GroupBox14.Controls.Add(Me.progSelectProgramButton)
Me.GroupBox14.Controls.Add(Me.Label146)
Me.GroupBox14.Controls.Add(Me.prog3)
Me.GroupBox14.Controls.Add(Me.Label147)
Me.GroupBox14.Controls.Add(Me.prog2)
Me.GroupBox14.Controls.Add(Me.Label148)
Me.GroupBox14.Controls.Add(Me.prog1)
Me.GroupBox14.Controls.Add(Me.Label149)
Me.GroupBox14.Controls.Add(Me.cmdCancelProgram)
Me.GroupBox14.Location = New System.Drawing.Point(432, 136)
Me.GroupBox14.Name = "GroupBox14"
Me.GroupBox14.Size = New System.Drawing.Size(336, 168)
Me.GroupBox14.TabIndex = 109
Me.GroupBox14.TabStop = false
'
'cmdSelectScheduleProgram
'
Me.cmdSelectScheduleProgram.Location = New System.Drawing.Point(104, 120)
Me.cmdSelectScheduleProgram.Name = "cmdSelectScheduleProgram"
Me.cmdSelectScheduleProgram.Size = New System.Drawing.Size(112, 40)
Me.cmdSelectScheduleProgram.TabIndex = 109
Me.cmdSelectScheduleProgram.Text = "Select Schedule Program"
'
'cboFileReadModeEnum
'
Me.cboFileReadModeEnum.Location = New System.Drawing.Point(152, 88)
Me.cboFileReadModeEnum.Name = "cboFileReadModeEnum"
Me.cboFileReadModeEnum.Size = New System.Drawing.Size(176, 21)
Me.cboFileReadModeEnum.TabIndex = 107
Me.cboFileReadModeEnum.Text = "ComboBox1"
'
'progSelectProgramButton
'
Me.progSelectProgramButton.Location = New System.Drawing.Point(8, 120)
Me.progSelectProgramButton.Name = "progSelectProgramButton"
Me.progSelectProgramButton.Size = New System.Drawing.Size(88, 40)
Me.progSelectProgramButton.TabIndex = 106
Me.progSelectProgramButton.Text = "Select Main Program"
'
'Label146
'
Me.Label146.Location = New System.Drawing.Point(8, 88)
Me.Label146.Name = "Label146"
Me.Label146.Size = New System.Drawing.Size(136, 16)
Me.Label146.TabIndex = 105
Me.Label146.Text = "File Read Mode"
'
'prog3
'
Me.prog3.Location = New System.Drawing.Point(152, 64)
Me.prog3.Name = "prog3"
Me.prog3.Size = New System.Drawing.Size(176, 20)
Me.prog3.TabIndex = 103
Me.prog3.Text = ""
'
'Label147
'
Me.Label147.Location = New System.Drawing.Point(8, 64)
Me.Label147.Name = "Label147"
Me.Label147.Size = New System.Drawing.Size(136, 16)
Me.Label147.TabIndex = 102
Me.Label147.Text = "System Sub FileName"
'
'prog2
'
Me.prog2.Location = New System.Drawing.Point(152, 40)
Me.prog2.Name = "prog2"
Me.prog2.Size = New System.Drawing.Size(176, 20)
Me.prog2.TabIndex = 100
Me.prog2.Text = ""
'
'Label148
'
Me.Label148.Location = New System.Drawing.Point(8, 16)
Me.Label148.Name = "Label148"
Me.Label148.Size = New System.Drawing.Size(136, 16)
Me.Label148.TabIndex = 101
Me.Label148.Text = "Program FileName"
'
'prog1
'
Me.prog1.Location = New System.Drawing.Point(152, 16)
Me.prog1.Name = "prog1"
Me.prog1.Size = New System.Drawing.Size(176, 20)
Me.prog1.TabIndex = 99
Me.prog1.Text = "A.MIN"
'
'Label149
'
Me.Label149.Location = New System.Drawing.Point(8, 40)
Me.Label149.Name = "Label149"
Me.Label149.Size = New System.Drawing.Size(136, 16)
Me.Label149.TabIndex = 98
Me.Label149.Text = "SubProgram FileName"
'
'cmdCancelProgram
'
Me.cmdCancelProgram.Location = New System.Drawing.Point(224, 120)
Me.cmdCancelProgram.Name = "cmdCancelProgram"
Me.cmdCancelProgram.Size = New System.Drawing.Size(104, 40)
Me.cmdCancelProgram.TabIndex = 108
Me.cmdCancelProgram.Text = "Cancel Program"
'
'progButtonExecBlock
'
Me.progButtonExecBlock.Location = New System.Drawing.Point(280, 56)
Me.progButtonExecBlock.Name = "progButtonExecBlock"
Me.progButtonExecBlock.Size = New System.Drawing.Size(128, 24)
Me.progButtonExecBlock.TabIndex = 77
Me.progButtonExecBlock.Text = "Get Execute Block"
'
'progExecutePoint
'
Me.progExecutePoint.Location = New System.Drawing.Point(168, 184)
Me.progExecutePoint.Name = "progExecutePoint"
Me.progExecutePoint.ReadOnly = true
Me.progExecutePoint.Size = New System.Drawing.Size(64, 20)
Me.progExecutePoint.TabIndex = 76
Me.progExecutePoint.Text = ""
'
'Label59
'
Me.Label59.Location = New System.Drawing.Point(24, 184)
Me.Label59.Name = "Label59"
Me.Label59.Size = New System.Drawing.Size(136, 16)
Me.Label59.TabIndex = 75
Me.Label59.Text = "Execute Point (Int)"
'
'progRead
'
Me.progRead.Location = New System.Drawing.Point(168, 160)
Me.progRead.Name = "progRead"
Me.progRead.ReadOnly = true
Me.progRead.Size = New System.Drawing.Size(64, 20)
Me.progRead.TabIndex = 73
Me.progRead.Text = ""
'
'Label60
'
Me.Label60.Location = New System.Drawing.Point(24, 136)
Me.Label60.Name = "Label60"
Me.Label60.Size = New System.Drawing.Size(136, 16)
Me.Label60.TabIndex = 74
Me.Label60.Text = "Column (int)"
'
'progColumn
'
Me.progColumn.Location = New System.Drawing.Point(168, 136)
Me.progColumn.Name = "progColumn"
Me.progColumn.Size = New System.Drawing.Size(64, 20)
Me.progColumn.TabIndex = 71
Me.progColumn.Text = "79"
'
'Label61
'
Me.Label61.Location = New System.Drawing.Point(24, 112)
Me.Label61.Name = "Label61"
Me.Label61.Size = New System.Drawing.Size(136, 16)
Me.Label61.TabIndex = 72
Me.Label61.Text = "Row (int)"
'
'progRow
'
Me.progRow.Location = New System.Drawing.Point(168, 112)
Me.progRow.Name = "progRow"
Me.progRow.Size = New System.Drawing.Size(64, 20)
Me.progRow.TabIndex = 69
Me.progRow.Text = "10"
'
'Label62
'
Me.Label62.Location = New System.Drawing.Point(24, 160)
Me.Label62.Name = "Label62"
Me.Label62.Size = New System.Drawing.Size(136, 16)
Me.Label62.TabIndex = 70
Me.Label62.Text = "Read Point (int)"
'
'Label58
'
Me.Label58.BackColor = System.Drawing.SystemColors.Control
Me.Label58.Location = New System.Drawing.Point(40, 56)
Me.Label58.Name = "Label58"
Me.Label58.Size = New System.Drawing.Size(96, 16)
Me.Label58.TabIndex = 61
Me.Label58.Text = "Executing Block :"
'
'progExecutingBlock
'
Me.progExecutingBlock.Location = New System.Drawing.Point(144, 56)
Me.progExecutingBlock.Name = "progExecutingBlock"
Me.progExecutingBlock.Size = New System.Drawing.Size(120, 20)
Me.progExecutingBlock.TabIndex = 60
Me.progExecutingBlock.Text = ""
'
'label99
'
Me.label99.BackColor = System.Drawing.SystemColors.Control
Me.label99.Location = New System.Drawing.Point(24, 24)
Me.label99.Name = "label99"
Me.label99.Size = New System.Drawing.Size(112, 16)
Me.label99.TabIndex = 58
Me.label99.Text = "Execute Block Type :"
'
'progExecCombo
'
Me.progExecCombo.Location = New System.Drawing.Point(144, 24)
Me.progExecCombo.Name = "progExecCombo"
Me.progExecCombo.Size = New System.Drawing.Size(168, 21)
Me.progExecCombo.TabIndex = 57
'
'Label57
'
Me.Label57.Location = New System.Drawing.Point(424, 8)
Me.Label57.Name = "Label57"
Me.Label57.Size = New System.Drawing.Size(80, 32)
Me.Label57.TabIndex = 16
Me.Label57.Text = "Values with no parameters :"
Me.Label57.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'progUpdateButton
'
Me.progUpdateButton.Location = New System.Drawing.Point(424, 48)
Me.progUpdateButton.Name = "progUpdateButton"
Me.progUpdateButton.Size = New System.Drawing.Size(88, 24)
Me.progUpdateButton.TabIndex = 15
Me.progUpdateButton.Text = "Update"
'
'progNoParams
'
Me.progNoParams.Location = New System.Drawing.Point(520, 8)
Me.progNoParams.Multiline = true
Me.progNoParams.Name = "progNoParams"
Me.progNoParams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.progNoParams.Size = New System.Drawing.Size(248, 128)
Me.progNoParams.TabIndex = 14
Me.progNoParams.Text = ""
'
'Panel7
'
Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel7.Location = New System.Drawing.Point(8, 8)
Me.Panel7.Name = "Panel7"
Me.Panel7.Size = New System.Drawing.Size(408, 80)
Me.Panel7.TabIndex = 78
'
'Panel8
'
Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel8.Controls.Add(Me.progButtonGetRunProgram)
Me.Panel8.Controls.Add(Me.progRunningPrograms)
Me.Panel8.Location = New System.Drawing.Point(8, 96)
Me.Panel8.Name = "Panel8"
Me.Panel8.Size = New System.Drawing.Size(408, 288)
Me.Panel8.TabIndex = 79
'
'progButtonGetRunProgram
'
Me.progButtonGetRunProgram.Location = New System.Drawing.Point(272, 8)
Me.progButtonGetRunProgram.Name = "progButtonGetRunProgram"
Me.progButtonGetRunProgram.Size = New System.Drawing.Size(128, 24)
Me.progButtonGetRunProgram.TabIndex = 78
Me.progButtonGetRunProgram.Text = "Get Running Program"
'
'progRunningPrograms
'
Me.progRunningPrograms.Location = New System.Drawing.Point(8, 120)
Me.progRunningPrograms.Multiline = true
Me.progRunningPrograms.Name = "progRunningPrograms"
Me.progRunningPrograms.Size = New System.Drawing.Size(392, 160)
Me.progRunningPrograms.TabIndex = 80
Me.progRunningPrograms.Text = ""
'
'tab_Program2
'
Me.tab_Program2.Controls.Add(Me.Label168)
Me.tab_Program2.Controls.Add(Me.txtProgramNameInput)
Me.tab_Program2.Controls.Add(Me.Label167)
Me.tab_Program2.Controls.Add(Me.txtProgramNameOutput)
Me.tab_Program2.Controls.Add(Me.Label166)
Me.tab_Program2.Controls.Add(Me.txtGMCode)
Me.tab_Program2.Controls.Add(Me.cmdSetProgramNameMCodeCall)
Me.tab_Program2.Controls.Add(Me.cmdGetProgramNameMCodeCall)
Me.tab_Program2.Controls.Add(Me.cmdSetProgramNameGCodeMod)
Me.tab_Program2.Controls.Add(Me.cmdGetProgramNameGCodeMod)
Me.tab_Program2.Location = New System.Drawing.Point(4, 22)
Me.tab_Program2.Name = "tab_Program2"
Me.tab_Program2.Size = New System.Drawing.Size(776, 446)
Me.tab_Program2.TabIndex = 21
Me.tab_Program2.Text = "Program 2 (G/M Code Macro)"
'
'Label168
'
Me.Label168.Location = New System.Drawing.Point(524, 296)
Me.Label168.Name = "Label168"
Me.Label168.Size = New System.Drawing.Size(120, 23)
Me.Label168.TabIndex = 27
Me.Label168.Text = "Program Name:"
'
'txtProgramNameInput
'
Me.txtProgramNameInput.Location = New System.Drawing.Point(524, 328)
Me.txtProgramNameInput.Name = "txtProgramNameInput"
Me.txtProgramNameInput.Size = New System.Drawing.Size(224, 20)
Me.txtProgramNameInput.TabIndex = 26
Me.txtProgramNameInput.Text = ""
'
'Label167
'
Me.Label167.Location = New System.Drawing.Point(524, 48)
Me.Label167.Name = "Label167"
Me.Label167.Size = New System.Drawing.Size(120, 23)
Me.Label167.TabIndex = 25
Me.Label167.Text = "Program Name:"
'
'txtProgramNameOutput
'
Me.txtProgramNameOutput.Location = New System.Drawing.Point(524, 80)
Me.txtProgramNameOutput.Name = "txtProgramNameOutput"
Me.txtProgramNameOutput.ReadOnly = true
Me.txtProgramNameOutput.Size = New System.Drawing.Size(232, 20)
Me.txtProgramNameOutput.TabIndex = 24
Me.txtProgramNameOutput.Text = ""
'
'Label166
'
Me.Label166.Location = New System.Drawing.Point(304, 176)
Me.Label166.Name = "Label166"
Me.Label166.Size = New System.Drawing.Size(120, 23)
Me.Label166.TabIndex = 23
Me.Label166.Text = "G/M Code Number:"
'
'txtGMCode
'
Me.txtGMCode.Location = New System.Drawing.Point(304, 208)
Me.txtGMCode.Name = "txtGMCode"
Me.txtGMCode.Size = New System.Drawing.Size(120, 20)
Me.txtGMCode.TabIndex = 22
Me.txtGMCode.Text = "0"
'
'cmdSetProgramNameMCodeCall
'
Me.cmdSetProgramNameMCodeCall.Location = New System.Drawing.Point(20, 360)
Me.cmdSetProgramNameMCodeCall.Name = "cmdSetProgramNameMCodeCall"
Me.cmdSetProgramNameMCodeCall.Size = New System.Drawing.Size(224, 40)
Me.cmdSetProgramNameMCodeCall.TabIndex = 19
Me.cmdSetProgramNameMCodeCall.Text = "Set Program Name to M Code CALL"
'
'cmdGetProgramNameMCodeCall
'
Me.cmdGetProgramNameMCodeCall.Location = New System.Drawing.Point(20, 112)
Me.cmdGetProgramNameMCodeCall.Name = "cmdGetProgramNameMCodeCall"
Me.cmdGetProgramNameMCodeCall.Size = New System.Drawing.Size(224, 40)
Me.cmdGetProgramNameMCodeCall.TabIndex = 18
Me.cmdGetProgramNameMCodeCall.Text = "Get Program assigned to M Code CALL"
'
'cmdSetProgramNameGCodeMod
'
Me.cmdSetProgramNameGCodeMod.Location = New System.Drawing.Point(20, 264)
Me.cmdSetProgramNameGCodeMod.Name = "cmdSetProgramNameGCodeMod"
Me.cmdSetProgramNameGCodeMod.Size = New System.Drawing.Size(224, 40)
Me.cmdSetProgramNameGCodeMod.TabIndex = 17
Me.cmdSetProgramNameGCodeMod.Text = "Set Program Name to G Code CALL/MODIN"
'
'cmdGetProgramNameGCodeMod
'
Me.cmdGetProgramNameGCodeMod.Location = New System.Drawing.Point(20, 16)
Me.cmdGetProgramNameGCodeMod.Name = "cmdGetProgramNameGCodeMod"
Me.cmdGetProgramNameGCodeMod.Size = New System.Drawing.Size(224, 40)
Me.cmdGetProgramNameGCodeMod.TabIndex = 16
Me.cmdGetProgramNameGCodeMod.Text = "Get Program assigned to G Code CALL/MODIN"
'
'Tools2_2
'
Me.Tools2_2.Controls.Add(Me.GroupBox21)
Me.Tools2_2.Controls.Add(Me.lstToolID_Update)
Me.Tools2_2.Controls.Add(Me.GroupBox19)
Me.Tools2_2.Controls.Add(Me.GroupBox18)
Me.Tools2_2.Controls.Add(Me.cboToolID_CarrierStatus)
Me.Tools2_2.Controls.Add(Me.cmdToolID_CarrierStatus_Set)
Me.Tools2_2.Controls.Add(Me.txtToolID_CarrierStatus)
Me.Tools2_2.Controls.Add(Me.Label183)
Me.Tools2_2.Controls.Add(Me.Label213)
Me.Tools2_2.Controls.Add(Me.cmdToolID_DataUnit_2_Set)
Me.Tools2_2.Controls.Add(Me.cboToolID_DataUnit_2)
Me.Tools2_2.Controls.Add(Me.Label230)
Me.Tools2_2.Controls.Add(Me.cmdToolID_2_Update)
Me.Tools2_2.Controls.Add(Me.txtToolID_PotNo_2)
Me.Tools2_2.Controls.Add(Me.Label236)
Me.Tools2_2.Location = New System.Drawing.Point(4, 22)
Me.Tools2_2.Name = "Tools2_2"
Me.Tools2_2.Size = New System.Drawing.Size(776, 446)
Me.Tools2_2.TabIndex = 23
Me.Tools2_2.Text = "Tools 2 -1"
'
'GroupBox21
'
Me.GroupBox21.Controls.Add(Me.txtTools2_ToolInPot)
Me.GroupBox21.Controls.Add(Me.Label252)
Me.GroupBox21.Controls.Add(Me.Label249)
Me.GroupBox21.Controls.Add(Me.cboToolID_ToolKind)
Me.GroupBox21.Controls.Add(Me.cmdToolID_ToolKind_Set)
Me.GroupBox21.Controls.Add(Me.Label235)
Me.GroupBox21.Controls.Add(Me.txtToolID_ToolKind)
Me.GroupBox21.Controls.Add(Me.cmdToolID_AdjustmentTool_Set)
Me.GroupBox21.Controls.Add(Me.txtToolID_AdjustmentTool)
Me.GroupBox21.Controls.Add(Me.Label248)
Me.GroupBox21.Controls.Add(Me.Label250)
Me.GroupBox21.Controls.Add(Me.txtToolID_PotInUse)
Me.GroupBox21.Controls.Add(Me.cmdToolID_PotInUse_Set)
Me.GroupBox21.Controls.Add(Me.cboYesNo_PotInUse)
Me.GroupBox21.Controls.Add(Me.cboYesNo_AdjustmentTool)
Me.GroupBox21.Controls.Add(Me.cboYesNo_StandardTool)
Me.GroupBox21.Controls.Add(Me.cmdToolID_StandardTool_Set)
Me.GroupBox21.Controls.Add(Me.txtToolID_StandardTool)
Me.GroupBox21.Location = New System.Drawing.Point(7, 263)
Me.GroupBox21.Name = "GroupBox21"
Me.GroupBox21.Size = New System.Drawing.Size(311, 174)
Me.GroupBox21.TabIndex = 313
Me.GroupBox21.TabStop = false
Me.GroupBox21.Text = "Tool Pot"
'
'txtTools2_ToolInPot
'
Me.txtTools2_ToolInPot.Location = New System.Drawing.Point(187, 146)
Me.txtTools2_ToolInPot.Name = "txtTools2_ToolInPot"
Me.txtTools2_ToolInPot.ReadOnly = true
Me.txtTools2_ToolInPot.Size = New System.Drawing.Size(66, 20)
Me.txtTools2_ToolInPot.TabIndex = 320
Me.txtTools2_ToolInPot.Text = "0"
'
'Label252
'
Me.Label252.Location = New System.Drawing.Point(7, 146)
Me.Label252.Name = "Label252"
Me.Label252.Size = New System.Drawing.Size(166, 16)
Me.Label252.TabIndex = 319
Me.Label252.Text = "Random ATC - Tool in Pot"
'
'Label249
'
Me.Label249.Location = New System.Drawing.Point(8, 48)
Me.Label249.Name = "Label249"
Me.Label249.Size = New System.Drawing.Size(96, 16)
Me.Label249.TabIndex = 302
Me.Label249.Text = "Standard Tool:"
'
'cboToolID_ToolKind
'
Me.cboToolID_ToolKind.Location = New System.Drawing.Point(184, 112)
Me.cboToolID_ToolKind.Name = "cboToolID_ToolKind"
Me.cboToolID_ToolKind.Size = New System.Drawing.Size(72, 20)
Me.cboToolID_ToolKind.TabIndex = 318
Me.cboToolID_ToolKind.Text = "Tool Kind"
'
'cmdToolID_ToolKind_Set
'
Me.cmdToolID_ToolKind_Set.Location = New System.Drawing.Point(264, 112)
Me.cmdToolID_ToolKind_Set.Name = "cmdToolID_ToolKind_Set"
Me.cmdToolID_ToolKind_Set.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_ToolKind_Set.TabIndex = 317
Me.cmdToolID_ToolKind_Set.Text = "Set"
'
'Label235
'
Me.Label235.Location = New System.Drawing.Point(8, 112)
Me.Label235.Name = "Label235"
Me.Label235.Size = New System.Drawing.Size(64, 16)
Me.Label235.TabIndex = 261
Me.Label235.Text = "Tool Kind"
'
'txtToolID_ToolKind
'
Me.txtToolID_ToolKind.Location = New System.Drawing.Point(72, 112)
Me.txtToolID_ToolKind.Name = "txtToolID_ToolKind"
Me.txtToolID_ToolKind.ReadOnly = true
Me.txtToolID_ToolKind.Size = New System.Drawing.Size(104, 20)
Me.txtToolID_ToolKind.TabIndex = 262
Me.txtToolID_ToolKind.Text = "0"
'
'cmdToolID_AdjustmentTool_Set
'
Me.cmdToolID_AdjustmentTool_Set.Location = New System.Drawing.Point(264, 16)
Me.cmdToolID_AdjustmentTool_Set.Name = "cmdToolID_AdjustmentTool_Set"
Me.cmdToolID_AdjustmentTool_Set.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_AdjustmentTool_Set.TabIndex = 300
Me.cmdToolID_AdjustmentTool_Set.Text = "Set"
'
'txtToolID_AdjustmentTool
'
Me.txtToolID_AdjustmentTool.Location = New System.Drawing.Point(112, 16)
Me.txtToolID_AdjustmentTool.Name = "txtToolID_AdjustmentTool"
Me.txtToolID_AdjustmentTool.ReadOnly = true
Me.txtToolID_AdjustmentTool.Size = New System.Drawing.Size(64, 20)
Me.txtToolID_AdjustmentTool.TabIndex = 298
Me.txtToolID_AdjustmentTool.Text = "0"
'
'Label248
'
Me.Label248.Location = New System.Drawing.Point(8, 16)
Me.Label248.Name = "Label248"
Me.Label248.Size = New System.Drawing.Size(96, 16)
Me.Label248.TabIndex = 297
Me.Label248.Text = "Adjustment Tool:"
'
'Label250
'
Me.Label250.Location = New System.Drawing.Point(8, 80)
Me.Label250.Name = "Label250"
Me.Label250.Size = New System.Drawing.Size(96, 16)
Me.Label250.TabIndex = 306
Me.Label250.Text = "Pot In Use:"
'
'txtToolID_PotInUse
'
Me.txtToolID_PotInUse.Location = New System.Drawing.Point(112, 80)
Me.txtToolID_PotInUse.Name = "txtToolID_PotInUse"
Me.txtToolID_PotInUse.ReadOnly = true
Me.txtToolID_PotInUse.Size = New System.Drawing.Size(64, 20)
Me.txtToolID_PotInUse.TabIndex = 307
Me.txtToolID_PotInUse.Text = "0"
'
'cmdToolID_PotInUse_Set
'
Me.cmdToolID_PotInUse_Set.Location = New System.Drawing.Point(264, 80)
Me.cmdToolID_PotInUse_Set.Name = "cmdToolID_PotInUse_Set"
Me.cmdToolID_PotInUse_Set.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_PotInUse_Set.TabIndex = 308
Me.cmdToolID_PotInUse_Set.Text = "Set"
'
'cboYesNo_PotInUse
'
Me.cboYesNo_PotInUse.Location = New System.Drawing.Point(184, 80)
Me.cboYesNo_PotInUse.Name = "cboYesNo_PotInUse"
Me.cboYesNo_PotInUse.Size = New System.Drawing.Size(72, 20)
Me.cboYesNo_PotInUse.TabIndex = 309
Me.cboYesNo_PotInUse.Text = "Yes/No"
'
'cboYesNo_AdjustmentTool
'
Me.cboYesNo_AdjustmentTool.Location = New System.Drawing.Point(184, 16)
Me.cboYesNo_AdjustmentTool.Name = "cboYesNo_AdjustmentTool"
Me.cboYesNo_AdjustmentTool.Size = New System.Drawing.Size(72, 20)
Me.cboYesNo_AdjustmentTool.TabIndex = 301
Me.cboYesNo_AdjustmentTool.Text = "Yes/No"
'
'cboYesNo_StandardTool
'
Me.cboYesNo_StandardTool.Location = New System.Drawing.Point(184, 48)
Me.cboYesNo_StandardTool.Name = "cboYesNo_StandardTool"
Me.cboYesNo_StandardTool.Size = New System.Drawing.Size(72, 20)
Me.cboYesNo_StandardTool.TabIndex = 305
Me.cboYesNo_StandardTool.Text = "Yes/No"
'
'cmdToolID_StandardTool_Set
'
Me.cmdToolID_StandardTool_Set.Location = New System.Drawing.Point(264, 48)
Me.cmdToolID_StandardTool_Set.Name = "cmdToolID_StandardTool_Set"
Me.cmdToolID_StandardTool_Set.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_StandardTool_Set.TabIndex = 304
Me.cmdToolID_StandardTool_Set.Text = "Set"
'
'txtToolID_StandardTool
'
Me.txtToolID_StandardTool.Location = New System.Drawing.Point(112, 48)
Me.txtToolID_StandardTool.Name = "txtToolID_StandardTool"
Me.txtToolID_StandardTool.ReadOnly = true
Me.txtToolID_StandardTool.Size = New System.Drawing.Size(64, 20)
Me.txtToolID_StandardTool.TabIndex = 303
Me.txtToolID_StandardTool.Text = "0"
'
'lstToolID_Update
'
Me.lstToolID_Update.ItemHeight = 16
Me.lstToolID_Update.Location = New System.Drawing.Point(520, 8)
Me.lstToolID_Update.Name = "lstToolID_Update"
Me.lstToolID_Update.Size = New System.Drawing.Size(248, 73)
Me.lstToolID_Update.TabIndex = 312
'
'GroupBox19
'
Me.GroupBox19.Controls.Add(Me.txtToolID_RATC_PotNo)
Me.GroupBox19.Controls.Add(Me.txtToolID_RATC_PotNoValue)
Me.GroupBox19.Controls.Add(Me.Label251)
Me.GroupBox19.Controls.Add(Me.chkToolID_DummyTool)
Me.GroupBox19.Controls.Add(Me.txtToolID_ToolNameValue)
Me.GroupBox19.Controls.Add(Me.txtToolID_SerialNo)
Me.GroupBox19.Controls.Add(Me.txtToolID_ToolName)
Me.GroupBox19.Controls.Add(Me.Label244)
Me.GroupBox19.Controls.Add(Me.txtToolID_GroupNoValue)
Me.GroupBox19.Controls.Add(Me.txtToolID_GroupNo)
Me.GroupBox19.Controls.Add(Me.Label186)
Me.GroupBox19.Controls.Add(Me.Label241)
Me.GroupBox19.Controls.Add(Me.txtToolID_SerialNoValue)
Me.GroupBox19.Controls.Add(Me.cmdToolID_UnRegisterToolPot)
Me.GroupBox19.Controls.Add(Me.cmdToolID_RegisterToolPot)
Me.GroupBox19.Location = New System.Drawing.Point(8, 42)
Me.GroupBox19.Name = "GroupBox19"
Me.GroupBox19.Size = New System.Drawing.Size(328, 217)
Me.GroupBox19.TabIndex = 311
Me.GroupBox19.TabStop = false
Me.GroupBox19.Text = "Register/Un-Register Tool"
'
'txtToolID_RATC_PotNo
'
Me.txtToolID_RATC_PotNo.Location = New System.Drawing.Point(153, 111)
Me.txtToolID_RATC_PotNo.Name = "txtToolID_RATC_PotNo"
Me.txtToolID_RATC_PotNo.ReadOnly = true
Me.txtToolID_RATC_PotNo.Size = New System.Drawing.Size(40, 20)
Me.txtToolID_RATC_PotNo.TabIndex = 319
Me.txtToolID_RATC_PotNo.Text = "0"
'
'txtToolID_RATC_PotNoValue
'
Me.txtToolID_RATC_PotNoValue.ForeColor = System.Drawing.Color.Red
Me.txtToolID_RATC_PotNoValue.Location = New System.Drawing.Point(200, 111)
Me.txtToolID_RATC_PotNoValue.Name = "txtToolID_RATC_PotNoValue"
Me.txtToolID_RATC_PotNoValue.Size = New System.Drawing.Size(120, 20)
Me.txtToolID_RATC_PotNoValue.TabIndex = 318
Me.txtToolID_RATC_PotNoValue.Text = "0"
'
'Label251
'
Me.Label251.Location = New System.Drawing.Point(13, 111)
Me.Label251.Name = "Label251"
Me.Label251.Size = New System.Drawing.Size(120, 14)
Me.Label251.TabIndex = 317
Me.Label251.Text = "Random ATC Pot No:"
'
'chkToolID_DummyTool
'
Me.chkToolID_DummyTool.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.chkToolID_DummyTool.Location = New System.Drawing.Point(13, 146)
Me.chkToolID_DummyTool.Name = "chkToolID_DummyTool"
Me.chkToolID_DummyTool.Size = New System.Drawing.Size(94, 24)
Me.chkToolID_DummyTool.TabIndex = 316
Me.chkToolID_DummyTool.Text = "Dummy Tool"
'
'txtToolID_ToolNameValue
'
Me.txtToolID_ToolNameValue.ForeColor = System.Drawing.Color.Red
Me.txtToolID_ToolNameValue.Location = New System.Drawing.Point(200, 80)
Me.txtToolID_ToolNameValue.Name = "txtToolID_ToolNameValue"
Me.txtToolID_ToolNameValue.Size = New System.Drawing.Size(120, 20)
Me.txtToolID_ToolNameValue.TabIndex = 315
Me.txtToolID_ToolNameValue.Text = "0"
'
'txtToolID_SerialNo
'
Me.txtToolID_SerialNo.Location = New System.Drawing.Point(112, 48)
Me.txtToolID_SerialNo.Name = "txtToolID_SerialNo"
Me.txtToolID_SerialNo.ReadOnly = true
Me.txtToolID_SerialNo.Size = New System.Drawing.Size(80, 20)
Me.txtToolID_SerialNo.TabIndex = 276
Me.txtToolID_SerialNo.Text = "0"
'
'txtToolID_ToolName
'
Me.txtToolID_ToolName.Location = New System.Drawing.Point(80, 80)
Me.txtToolID_ToolName.Name = "txtToolID_ToolName"
Me.txtToolID_ToolName.ReadOnly = true
Me.txtToolID_ToolName.Size = New System.Drawing.Size(112, 20)
Me.txtToolID_ToolName.TabIndex = 288
Me.txtToolID_ToolName.Text = "0"
'
'Label244
'
Me.Label244.Location = New System.Drawing.Point(8, 80)
Me.Label244.Name = "Label244"
Me.Label244.Size = New System.Drawing.Size(64, 16)
Me.Label244.TabIndex = 287
Me.Label244.Text = "Tool Name"
'
'txtToolID_GroupNoValue
'
Me.txtToolID_GroupNoValue.ForeColor = System.Drawing.Color.Red
Me.txtToolID_GroupNoValue.Location = New System.Drawing.Point(200, 16)
Me.txtToolID_GroupNoValue.Name = "txtToolID_GroupNoValue"
Me.txtToolID_GroupNoValue.Size = New System.Drawing.Size(120, 20)
Me.txtToolID_GroupNoValue.TabIndex = 259
Me.txtToolID_GroupNoValue.Text = "0"
'
'txtToolID_GroupNo
'
Me.txtToolID_GroupNo.Location = New System.Drawing.Point(112, 16)
Me.txtToolID_GroupNo.Name = "txtToolID_GroupNo"
Me.txtToolID_GroupNo.ReadOnly = true
Me.txtToolID_GroupNo.Size = New System.Drawing.Size(80, 20)
Me.txtToolID_GroupNo.TabIndex = 256
Me.txtToolID_GroupNo.Text = "0"
'
'Label186
'
Me.Label186.Location = New System.Drawing.Point(8, 56)
Me.Label186.Name = "Label186"
Me.Label186.Size = New System.Drawing.Size(80, 16)
Me.Label186.TabIndex = 275
Me.Label186.Text = "Serial Number:"
'
'Label241
'
Me.Label241.Location = New System.Drawing.Point(8, 24)
Me.Label241.Name = "Label241"
Me.Label241.Size = New System.Drawing.Size(88, 16)
Me.Label241.TabIndex = 255
Me.Label241.Text = "Group Number:"
'
'txtToolID_SerialNoValue
'
Me.txtToolID_SerialNoValue.ForeColor = System.Drawing.Color.Red
Me.txtToolID_SerialNoValue.Location = New System.Drawing.Point(200, 48)
Me.txtToolID_SerialNoValue.Name = "txtToolID_SerialNoValue"
Me.txtToolID_SerialNoValue.Size = New System.Drawing.Size(120, 20)
Me.txtToolID_SerialNoValue.TabIndex = 277
Me.txtToolID_SerialNoValue.Text = "0"
'
'cmdToolID_UnRegisterToolPot
'
Me.cmdToolID_UnRegisterToolPot.Location = New System.Drawing.Point(184, 180)
Me.cmdToolID_UnRegisterToolPot.Name = "cmdToolID_UnRegisterToolPot"
Me.cmdToolID_UnRegisterToolPot.Size = New System.Drawing.Size(136, 25)
Me.cmdToolID_UnRegisterToolPot.TabIndex = 313
Me.cmdToolID_UnRegisterToolPot.Text = "Un-Register Tool Pot"
'
'cmdToolID_RegisterToolPot
'
Me.cmdToolID_RegisterToolPot.Location = New System.Drawing.Point(8, 180)
Me.cmdToolID_RegisterToolPot.Name = "cmdToolID_RegisterToolPot"
Me.cmdToolID_RegisterToolPot.Size = New System.Drawing.Size(152, 25)
Me.cmdToolID_RegisterToolPot.TabIndex = 314
Me.cmdToolID_RegisterToolPot.Text = "Register Tool Pot"
'
'GroupBox18
'
Me.GroupBox18.Controls.Add(Me.cmdToolID_ToolAngle_Add)
Me.GroupBox18.Controls.Add(Me.cmdToolID_ToolNoseDiameter_Add)
Me.GroupBox18.Controls.Add(Me.cmdToolID_ToolDiameter_Add)
Me.GroupBox18.Controls.Add(Me.cboToolID_ToolType)
Me.GroupBox18.Controls.Add(Me.Label246)
Me.GroupBox18.Controls.Add(Me.Label247)
Me.GroupBox18.Controls.Add(Me.txtToolID_ToolType)
Me.GroupBox18.Controls.Add(Me.cmdToolID_ToolType_Set)
Me.GroupBox18.Controls.Add(Me.cmdToolID_ToolAngle_Set)
Me.GroupBox18.Controls.Add(Me.txtToolID_ToolAngleValue)
Me.GroupBox18.Controls.Add(Me.Label242)
Me.GroupBox18.Controls.Add(Me.txtToolID_ToolAngle)
Me.GroupBox18.Controls.Add(Me.cmdToolID_ToolNoseDiameter_Set)
Me.GroupBox18.Controls.Add(Me.cmdToolID_ToolDiameter_Set)
Me.GroupBox18.Controls.Add(Me.txtToolID_ToolDiameterValue)
Me.GroupBox18.Controls.Add(Me.txtToolID_ToolNoseDiameterValue)
Me.GroupBox18.Controls.Add(Me.Label243)
Me.GroupBox18.Controls.Add(Me.txtToolID_ToolNoseDiameter)
Me.GroupBox18.Controls.Add(Me.txtToolID_ToolDiameter)
Me.GroupBox18.Location = New System.Drawing.Point(400, 139)
Me.GroupBox18.Name = "GroupBox18"
Me.GroupBox18.Size = New System.Drawing.Size(368, 144)
Me.GroupBox18.TabIndex = 310
Me.GroupBox18.TabStop = false
Me.GroupBox18.Text = "Tool Shape"
'
'cmdToolID_ToolAngle_Add
'
Me.cmdToolID_ToolAngle_Add.Location = New System.Drawing.Point(320, 80)
Me.cmdToolID_ToolAngle_Add.Name = "cmdToolID_ToolAngle_Add"
Me.cmdToolID_ToolAngle_Add.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_ToolAngle_Add.TabIndex = 307
Me.cmdToolID_ToolAngle_Add.Text = "Add"
'
'cmdToolID_ToolNoseDiameter_Add
'
Me.cmdToolID_ToolNoseDiameter_Add.Location = New System.Drawing.Point(320, 112)
Me.cmdToolID_ToolNoseDiameter_Add.Name = "cmdToolID_ToolNoseDiameter_Add"
Me.cmdToolID_ToolNoseDiameter_Add.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_ToolNoseDiameter_Add.TabIndex = 309
Me.cmdToolID_ToolNoseDiameter_Add.Text = "Add"
'
'cmdToolID_ToolDiameter_Add
'
Me.cmdToolID_ToolDiameter_Add.Location = New System.Drawing.Point(320, 48)
Me.cmdToolID_ToolDiameter_Add.Name = "cmdToolID_ToolDiameter_Add"
Me.cmdToolID_ToolDiameter_Add.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_ToolDiameter_Add.TabIndex = 308
Me.cmdToolID_ToolDiameter_Add.Text = "Add"
'
'cboToolID_ToolType
'
Me.cboToolID_ToolType.Location = New System.Drawing.Point(200, 16)
Me.cboToolID_ToolType.Name = "cboToolID_ToolType"
Me.cboToolID_ToolType.Size = New System.Drawing.Size(112, 20)
Me.cboToolID_ToolType.TabIndex = 306
Me.cboToolID_ToolType.Text = "Tool Type"
'
'Label246
'
Me.Label246.Location = New System.Drawing.Point(8, 112)
Me.Label246.Name = "Label246"
Me.Label246.Size = New System.Drawing.Size(112, 16)
Me.Label246.TabIndex = 289
Me.Label246.Text = "Tool Nose Diameter:"
'
'Label247
'
Me.Label247.Location = New System.Drawing.Point(8, 16)
Me.Label247.Name = "Label247"
Me.Label247.Size = New System.Drawing.Size(112, 16)
Me.Label247.TabIndex = 293
Me.Label247.Text = "Tool Type:"
'
'txtToolID_ToolType
'
Me.txtToolID_ToolType.Location = New System.Drawing.Point(128, 16)
Me.txtToolID_ToolType.Name = "txtToolID_ToolType"
Me.txtToolID_ToolType.ReadOnly = true
Me.txtToolID_ToolType.Size = New System.Drawing.Size(64, 20)
Me.txtToolID_ToolType.TabIndex = 294
Me.txtToolID_ToolType.Text = "0"
'
'cmdToolID_ToolType_Set
'
Me.cmdToolID_ToolType_Set.Location = New System.Drawing.Point(320, 16)
Me.cmdToolID_ToolType_Set.Name = "cmdToolID_ToolType_Set"
Me.cmdToolID_ToolType_Set.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_ToolType_Set.TabIndex = 296
Me.cmdToolID_ToolType_Set.Text = "Set"
'
'cmdToolID_ToolAngle_Set
'
Me.cmdToolID_ToolAngle_Set.Location = New System.Drawing.Point(272, 80)
Me.cmdToolID_ToolAngle_Set.Name = "cmdToolID_ToolAngle_Set"
Me.cmdToolID_ToolAngle_Set.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_ToolAngle_Set.TabIndex = 282
Me.cmdToolID_ToolAngle_Set.Text = "Set"
'
'txtToolID_ToolAngleValue
'
Me.txtToolID_ToolAngleValue.ForeColor = System.Drawing.Color.Red
Me.txtToolID_ToolAngleValue.Location = New System.Drawing.Point(200, 80)
Me.txtToolID_ToolAngleValue.Name = "txtToolID_ToolAngleValue"
Me.txtToolID_ToolAngleValue.Size = New System.Drawing.Size(64, 20)
Me.txtToolID_ToolAngleValue.TabIndex = 281
Me.txtToolID_ToolAngleValue.Text = "0"
'
'Label242
'
Me.Label242.Location = New System.Drawing.Point(8, 80)
Me.Label242.Name = "Label242"
Me.Label242.Size = New System.Drawing.Size(112, 16)
Me.Label242.TabIndex = 279
Me.Label242.Text = "Tool Angle:"
'
'txtToolID_ToolAngle
'
Me.txtToolID_ToolAngle.Location = New System.Drawing.Point(128, 80)
Me.txtToolID_ToolAngle.Name = "txtToolID_ToolAngle"
Me.txtToolID_ToolAngle.ReadOnly = true
Me.txtToolID_ToolAngle.Size = New System.Drawing.Size(64, 20)
Me.txtToolID_ToolAngle.TabIndex = 280
Me.txtToolID_ToolAngle.Text = "0"
'
'cmdToolID_ToolNoseDiameter_Set
'
Me.cmdToolID_ToolNoseDiameter_Set.Location = New System.Drawing.Point(272, 112)
Me.cmdToolID_ToolNoseDiameter_Set.Name = "cmdToolID_ToolNoseDiameter_Set"
Me.cmdToolID_ToolNoseDiameter_Set.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_ToolNoseDiameter_Set.TabIndex = 292
Me.cmdToolID_ToolNoseDiameter_Set.Text = "Set"
'
'cmdToolID_ToolDiameter_Set
'
Me.cmdToolID_ToolDiameter_Set.Location = New System.Drawing.Point(272, 48)
Me.cmdToolID_ToolDiameter_Set.Name = "cmdToolID_ToolDiameter_Set"
Me.cmdToolID_ToolDiameter_Set.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_ToolDiameter_Set.TabIndex = 286
Me.cmdToolID_ToolDiameter_Set.Text = "Set"
'
'txtToolID_ToolDiameterValue
'
Me.txtToolID_ToolDiameterValue.ForeColor = System.Drawing.Color.Red
Me.txtToolID_ToolDiameterValue.Location = New System.Drawing.Point(200, 48)
Me.txtToolID_ToolDiameterValue.Name = "txtToolID_ToolDiameterValue"
Me.txtToolID_ToolDiameterValue.Size = New System.Drawing.Size(64, 20)
Me.txtToolID_ToolDiameterValue.TabIndex = 285
Me.txtToolID_ToolDiameterValue.Text = "0"
'
'txtToolID_ToolNoseDiameterValue
'
Me.txtToolID_ToolNoseDiameterValue.ForeColor = System.Drawing.Color.Red
Me.txtToolID_ToolNoseDiameterValue.Location = New System.Drawing.Point(200, 112)
Me.txtToolID_ToolNoseDiameterValue.Name = "txtToolID_ToolNoseDiameterValue"
Me.txtToolID_ToolNoseDiameterValue.Size = New System.Drawing.Size(64, 20)
Me.txtToolID_ToolNoseDiameterValue.TabIndex = 291
Me.txtToolID_ToolNoseDiameterValue.Text = "0"
'
'Label243
'
Me.Label243.Location = New System.Drawing.Point(8, 48)
Me.Label243.Name = "Label243"
Me.Label243.Size = New System.Drawing.Size(112, 16)
Me.Label243.TabIndex = 283
Me.Label243.Text = "Tool Diameter:"
'
'txtToolID_ToolNoseDiameter
'
Me.txtToolID_ToolNoseDiameter.Location = New System.Drawing.Point(128, 112)
Me.txtToolID_ToolNoseDiameter.Name = "txtToolID_ToolNoseDiameter"
Me.txtToolID_ToolNoseDiameter.ReadOnly = true
Me.txtToolID_ToolNoseDiameter.Size = New System.Drawing.Size(64, 20)
Me.txtToolID_ToolNoseDiameter.TabIndex = 290
Me.txtToolID_ToolNoseDiameter.Text = "0"
'
'txtToolID_ToolDiameter
'
Me.txtToolID_ToolDiameter.Location = New System.Drawing.Point(128, 48)
Me.txtToolID_ToolDiameter.Name = "txtToolID_ToolDiameter"
Me.txtToolID_ToolDiameter.ReadOnly = true
Me.txtToolID_ToolDiameter.Size = New System.Drawing.Size(64, 20)
Me.txtToolID_ToolDiameter.TabIndex = 284
Me.txtToolID_ToolDiameter.Text = "0"
'
'cboToolID_CarrierStatus
'
Me.cboToolID_CarrierStatus.Location = New System.Drawing.Point(592, 104)
Me.cboToolID_CarrierStatus.Name = "cboToolID_CarrierStatus"
Me.cboToolID_CarrierStatus.Size = New System.Drawing.Size(128, 20)
Me.cboToolID_CarrierStatus.TabIndex = 274
Me.cboToolID_CarrierStatus.Text = "CarrierStatus"
'
'cmdToolID_CarrierStatus_Set
'
Me.cmdToolID_CarrierStatus_Set.Location = New System.Drawing.Point(728, 104)
Me.cmdToolID_CarrierStatus_Set.Name = "cmdToolID_CarrierStatus_Set"
Me.cmdToolID_CarrierStatus_Set.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_CarrierStatus_Set.TabIndex = 273
Me.cmdToolID_CarrierStatus_Set.Text = "Set"
'
'txtToolID_CarrierStatus
'
Me.txtToolID_CarrierStatus.Location = New System.Drawing.Point(480, 104)
Me.txtToolID_CarrierStatus.Name = "txtToolID_CarrierStatus"
Me.txtToolID_CarrierStatus.ReadOnly = true
Me.txtToolID_CarrierStatus.Size = New System.Drawing.Size(104, 20)
Me.txtToolID_CarrierStatus.TabIndex = 271
Me.txtToolID_CarrierStatus.Text = "0"
'
'Label183
'
Me.Label183.Location = New System.Drawing.Point(400, 104)
Me.Label183.Name = "Label183"
Me.Label183.Size = New System.Drawing.Size(88, 16)
Me.Label183.TabIndex = 270
Me.Label183.Text = "Carrier Status:"
'
'Label213
'
Me.Label213.Location = New System.Drawing.Point(168, 16)
Me.Label213.Name = "Label213"
Me.Label213.Size = New System.Drawing.Size(64, 16)
Me.Label213.TabIndex = 269
Me.Label213.Text = "Data Unit"
'
'cmdToolID_DataUnit_2_Set
'
Me.cmdToolID_DataUnit_2_Set.Location = New System.Drawing.Point(344, 8)
Me.cmdToolID_DataUnit_2_Set.Name = "cmdToolID_DataUnit_2_Set"
Me.cmdToolID_DataUnit_2_Set.Size = New System.Drawing.Size(48, 23)
Me.cmdToolID_DataUnit_2_Set.TabIndex = 267
Me.cmdToolID_DataUnit_2_Set.Text = "Set"
'
'cboToolID_DataUnit_2
'
Me.cboToolID_DataUnit_2.Location = New System.Drawing.Point(240, 8)
Me.cboToolID_DataUnit_2.Name = "cboToolID_DataUnit_2"
Me.cboToolID_DataUnit_2.Size = New System.Drawing.Size(96, 20)
Me.cboToolID_DataUnit_2.TabIndex = 266
'
'Label230
'
Me.Label230.Location = New System.Drawing.Point(432, 48)
Me.Label230.Name = "Label230"
Me.Label230.Size = New System.Drawing.Size(80, 32)
Me.Label230.TabIndex = 265
Me.Label230.Text = "Values with no parameters :"
Me.Label230.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'cmdToolID_2_Update
'
Me.cmdToolID_2_Update.Location = New System.Drawing.Point(440, 8)
Me.cmdToolID_2_Update.Name = "cmdToolID_2_Update"
Me.cmdToolID_2_Update.Size = New System.Drawing.Size(72, 24)
Me.cmdToolID_2_Update.TabIndex = 264
Me.cmdToolID_2_Update.Text = "Update"
'
'txtToolID_PotNo_2
'
Me.txtToolID_PotNo_2.Location = New System.Drawing.Point(96, 8)
Me.txtToolID_PotNo_2.Name = "txtToolID_PotNo_2"
Me.txtToolID_PotNo_2.Size = New System.Drawing.Size(64, 20)
Me.txtToolID_PotNo_2.TabIndex = 258
Me.txtToolID_PotNo_2.Text = "1"
'
'Label236
'
Me.Label236.Location = New System.Drawing.Point(8, 8)
Me.Label236.Name = "Label236"
Me.Label236.Size = New System.Drawing.Size(64, 16)
Me.Label236.TabIndex = 257
Me.Label236.Text = "Tool/Pot Number"
'
'tab_Tools2_1
'
Me.tab_Tools2_1.Controls.Add(Me.cmdToolID_Update_1)
Me.tab_Tools2_1.Controls.Add(Me.GroupBox16)
Me.tab_Tools2_1.Controls.Add(Me.GroupBox17)
Me.tab_Tools2_1.Controls.Add(Me.Label207)
Me.tab_Tools2_1.Controls.Add(Me.cmdToolID_DataUnit_Set)
Me.tab_Tools2_1.Controls.Add(Me.cboToolID_DataUnit)
Me.tab_Tools2_1.Controls.Add(Me.txtToolID_PotNo)
Me.tab_Tools2_1.Controls.Add(Me.Label185)
Me.tab_Tools2_1.Location = New System.Drawing.Point(4, 22)
Me.tab_Tools2_1.Name = "tab_Tools2_1"
Me.tab_Tools2_1.Size = New System.Drawing.Size(776, 446)
Me.tab_Tools2_1.TabIndex = 22
Me.tab_Tools2_1.Text = "Tools 2 - 2"
'
'cmdToolID_Update_1
'
Me.cmdToolID_Update_1.Location = New System.Drawing.Point(624, 16)
Me.cmdToolID_Update_1.Name = "cmdToolID_Update_1"
Me.cmdToolID_Update_1.Size = New System.Drawing.Size(136, 24)
Me.cmdToolID_Update_1.TabIndex = 257
Me.cmdToolID_Update_1.Text = "Update"
'
'GroupBox16
'
Me.GroupBox16.Controls.Add(Me.lstToolID_Offset)
Me.GroupBox16.Controls.Add(Me.Label212)
Me.GroupBox16.Controls.Add(Me.txtToolID_OffsetIndex123)
Me.GroupBox16.Controls.Add(Me.cmdToolID_LengthOffset3_Cal)
Me.GroupBox16.Controls.Add(Me.cmdToolID_LengthOffset2_Cal)
Me.GroupBox16.Controls.Add(Me.txtToolID_LengthOffset3)
Me.GroupBox16.Controls.Add(Me.Label211)
Me.GroupBox16.Controls.Add(Me.cmdToolID_LengthOffset3_Add)
Me.GroupBox16.Controls.Add(Me.txtToolID_LengthOffset3Value)
Me.GroupBox16.Controls.Add(Me.cmdToolID_LengthOffset3_Set)
Me.GroupBox16.Controls.Add(Me.txtToolID_LengthOffset2)
Me.GroupBox16.Controls.Add(Me.Label210)
Me.GroupBox16.Controls.Add(Me.cmdToolID_LengthOffset2_Add)
Me.GroupBox16.Controls.Add(Me.txtToolID_LengthOffset2Value)
Me.GroupBox16.Controls.Add(Me.cmdToolID_LengthOffset2_Set)
Me.GroupBox16.Controls.Add(Me.cmdToolID_CutterRCompOffset3_Add)
Me.GroupBox16.Controls.Add(Me.cmdToolID_CutterRCompOffset3_Set)
Me.GroupBox16.Controls.Add(Me.txtToolID_CutterRCompOffset3Value)
Me.GroupBox16.Controls.Add(Me.Label209)
Me.GroupBox16.Controls.Add(Me.txtToolID_CutterRCompOffset3)
Me.GroupBox16.Controls.Add(Me.cmdToolID_CutterRCompOffset2_Add)
Me.GroupBox16.Controls.Add(Me.cmdToolID_CutterRCompOffset2_Set)
Me.GroupBox16.Controls.Add(Me.txtToolID_CutterRCompOffset2Value)
Me.GroupBox16.Controls.Add(Me.Label208)
Me.GroupBox16.Controls.Add(Me.txtToolID_CutterRCompOffset2)
Me.GroupBox16.Controls.Add(Me.cmdToolID_CutterRCompOffset1_Add)
Me.GroupBox16.Controls.Add(Me.cmdToolID_CutterRCompWearOffset_Add)
Me.GroupBox16.Controls.Add(Me.txtToolID_LengthOffset1)
Me.GroupBox16.Controls.Add(Me.Label182)
Me.GroupBox16.Controls.Add(Me.txtToolID_CutterRCompWearOffsetValue)
Me.GroupBox16.Controls.Add(Me.cmdToolID_CutterRCompWearOffset_Set)
Me.GroupBox16.Controls.Add(Me.cmdToolID_CutterRCompOffset1_Set)
Me.GroupBox16.Controls.Add(Me.cmdToolID_LengthOffset1_Add)
Me.GroupBox16.Controls.Add(Me.txtToolID_CutterRCompOffset1Value)
Me.GroupBox16.Controls.Add(Me.Label188)
Me.GroupBox16.Controls.Add(Me.txtToolID_CutterRCompWearOffset)
Me.GroupBox16.Controls.Add(Me.Label189)
Me.GroupBox16.Controls.Add(Me.txtToolID_CutterRCompOffset1)
Me.GroupBox16.Controls.Add(Me.cmdToolID_ToolLengthWearOffset_Add)
Me.GroupBox16.Controls.Add(Me.cmdToolID_ToolLengthWearOffset_Set)
Me.GroupBox16.Controls.Add(Me.txtToolID_ToolLengthWearOffsetValue)
Me.GroupBox16.Controls.Add(Me.txtToolID_LengthOffset1Value)
Me.GroupBox16.Controls.Add(Me.txtToolID_ToolLengthWearOffset)
Me.GroupBox16.Controls.Add(Me.Label181)
Me.GroupBox16.Controls.Add(Me.cmdToolID_LengthOffset1_Cal)
Me.GroupBox16.Controls.Add(Me.cmdToolID_LengthOffset1_Set)
Me.GroupBox16.Controls.Add(Me.cmdToolID_CutterRWearOffset)
Me.GroupBox16.Controls.Add(Me.cmdToolID_CutterROffset)
Me.GroupBox16.Controls.Add(Me.cmdToolID_LengthWearOffset)
Me.GroupBox16.Controls.Add(Me.cmdToolID_LenghtOffset)
Me.GroupBox16.Controls.Add(Me.txtToolID_ToPot)
Me.GroupBox16.Controls.Add(Me.Label176)
Me.GroupBox16.Controls.Add(Me.txtToolID_FromPot)
Me.GroupBox16.Controls.Add(Me.Label177)
Me.GroupBox16.Location = New System.Drawing.Point(7, 144)
Me.GroupBox16.Name = "GroupBox16"
Me.GroupBox16.Size = New System.Drawing.Size(768, 296)
Me.GroupBox16.TabIndex = 255
Me.GroupBox16.TabStop = false
Me.GroupBox16.Text = "Offset"
'
'lstToolID_Offset
'
Me.lstToolID_Offset.ItemHeight = 16
Me.lstToolID_Offset.Location = New System.Drawing.Point(304, 168)
Me.lstToolID_Offset.Name = "lstToolID_Offset"
Me.lstToolID_Offset.Size = New System.Drawing.Size(264, 115)
Me.lstToolID_Offset.TabIndex = 278
'
'Label212
'
Me.Label212.Location = New System.Drawing.Point(16, 184)
Me.Label212.Name = "Label212"
Me.Label212.Size = New System.Drawing.Size(96, 16)
Me.Label212.TabIndex = 277
Me.Label212.Text = "Offset Index 1/2/3"
'
'txtToolID_OffsetIndex123
'
Me.txtToolID_OffsetIndex123.Location = New System.Drawing.Point(128, 184)
Me.txtToolID_OffsetIndex123.Name = "txtToolID_OffsetIndex123"
Me.txtToolID_OffsetIndex123.Size = New System.Drawing.Size(24, 20)
Me.txtToolID_OffsetIndex123.TabIndex = 276
Me.txtToolID_OffsetIndex123.Text = "1"
'
'cmdToolID_LengthOffset3_Cal
'
Me.cmdToolID_LengthOffset3_Cal.Location = New System.Drawing.Point(360, 80)
Me.cmdToolID_LengthOffset3_Cal.Name = "cmdToolID_LengthOffset3_Cal"
Me.cmdToolID_LengthOffset3_Cal.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_LengthOffset3_Cal.TabIndex = 275
Me.cmdToolID_LengthOffset3_Cal.Text = "Cal"
'
'cmdToolID_LengthOffset2_Cal
'
Me.cmdToolID_LengthOffset2_Cal.Location = New System.Drawing.Point(360, 48)
Me.cmdToolID_LengthOffset2_Cal.Name = "cmdToolID_LengthOffset2_Cal"
Me.cmdToolID_LengthOffset2_Cal.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_LengthOffset2_Cal.TabIndex = 274
Me.cmdToolID_LengthOffset2_Cal.Text = "Cal"
'
'txtToolID_LengthOffset3
'
Me.txtToolID_LengthOffset3.Location = New System.Drawing.Point(152, 80)
Me.txtToolID_LengthOffset3.Name = "txtToolID_LengthOffset3"
Me.txtToolID_LengthOffset3.ReadOnly = true
Me.txtToolID_LengthOffset3.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_LengthOffset3.TabIndex = 270
Me.txtToolID_LengthOffset3.Text = "0"
'
'Label211
'
Me.Label211.Location = New System.Drawing.Point(8, 80)
Me.Label211.Name = "Label211"
Me.Label211.Size = New System.Drawing.Size(136, 16)
Me.Label211.TabIndex = 269
Me.Label211.Text = "Tool Length Offset 3"
'
'cmdToolID_LengthOffset3_Add
'
Me.cmdToolID_LengthOffset3_Add.Location = New System.Drawing.Point(320, 80)
Me.cmdToolID_LengthOffset3_Add.Name = "cmdToolID_LengthOffset3_Add"
Me.cmdToolID_LengthOffset3_Add.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_LengthOffset3_Add.TabIndex = 273
Me.cmdToolID_LengthOffset3_Add.Text = "Add"
'
'txtToolID_LengthOffset3Value
'
Me.txtToolID_LengthOffset3Value.ForeColor = System.Drawing.Color.Red
Me.txtToolID_LengthOffset3Value.Location = New System.Drawing.Point(216, 80)
Me.txtToolID_LengthOffset3Value.Name = "txtToolID_LengthOffset3Value"
Me.txtToolID_LengthOffset3Value.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_LengthOffset3Value.TabIndex = 271
Me.txtToolID_LengthOffset3Value.Text = "0"
'
'cmdToolID_LengthOffset3_Set
'
Me.cmdToolID_LengthOffset3_Set.Location = New System.Drawing.Point(280, 80)
Me.cmdToolID_LengthOffset3_Set.Name = "cmdToolID_LengthOffset3_Set"
Me.cmdToolID_LengthOffset3_Set.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_LengthOffset3_Set.TabIndex = 272
Me.cmdToolID_LengthOffset3_Set.Text = "Set"
'
'txtToolID_LengthOffset2
'
Me.txtToolID_LengthOffset2.Location = New System.Drawing.Point(152, 48)
Me.txtToolID_LengthOffset2.Name = "txtToolID_LengthOffset2"
Me.txtToolID_LengthOffset2.ReadOnly = true
Me.txtToolID_LengthOffset2.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_LengthOffset2.TabIndex = 265
Me.txtToolID_LengthOffset2.Text = "0"
'
'Label210
'
Me.Label210.Location = New System.Drawing.Point(8, 48)
Me.Label210.Name = "Label210"
Me.Label210.Size = New System.Drawing.Size(136, 16)
Me.Label210.TabIndex = 264
Me.Label210.Text = "Tool Length Offset 2"
'
'cmdToolID_LengthOffset2_Add
'
Me.cmdToolID_LengthOffset2_Add.Location = New System.Drawing.Point(320, 48)
Me.cmdToolID_LengthOffset2_Add.Name = "cmdToolID_LengthOffset2_Add"
Me.cmdToolID_LengthOffset2_Add.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_LengthOffset2_Add.TabIndex = 268
Me.cmdToolID_LengthOffset2_Add.Text = "Add"
'
'txtToolID_LengthOffset2Value
'
Me.txtToolID_LengthOffset2Value.ForeColor = System.Drawing.Color.Red
Me.txtToolID_LengthOffset2Value.Location = New System.Drawing.Point(216, 48)
Me.txtToolID_LengthOffset2Value.Name = "txtToolID_LengthOffset2Value"
Me.txtToolID_LengthOffset2Value.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_LengthOffset2Value.TabIndex = 266
Me.txtToolID_LengthOffset2Value.Text = "0"
'
'cmdToolID_LengthOffset2_Set
'
Me.cmdToolID_LengthOffset2_Set.Location = New System.Drawing.Point(280, 48)
Me.cmdToolID_LengthOffset2_Set.Name = "cmdToolID_LengthOffset2_Set"
Me.cmdToolID_LengthOffset2_Set.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_LengthOffset2_Set.TabIndex = 267
Me.cmdToolID_LengthOffset2_Set.Text = "Set"
'
'cmdToolID_CutterRCompOffset3_Add
'
Me.cmdToolID_CutterRCompOffset3_Add.Location = New System.Drawing.Point(720, 80)
Me.cmdToolID_CutterRCompOffset3_Add.Name = "cmdToolID_CutterRCompOffset3_Add"
Me.cmdToolID_CutterRCompOffset3_Add.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_CutterRCompOffset3_Add.TabIndex = 263
Me.cmdToolID_CutterRCompOffset3_Add.Text = "Add"
'
'cmdToolID_CutterRCompOffset3_Set
'
Me.cmdToolID_CutterRCompOffset3_Set.Location = New System.Drawing.Point(680, 80)
Me.cmdToolID_CutterRCompOffset3_Set.Name = "cmdToolID_CutterRCompOffset3_Set"
Me.cmdToolID_CutterRCompOffset3_Set.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_CutterRCompOffset3_Set.TabIndex = 262
Me.cmdToolID_CutterRCompOffset3_Set.Text = "Set"
'
'txtToolID_CutterRCompOffset3Value
'
Me.txtToolID_CutterRCompOffset3Value.ForeColor = System.Drawing.Color.Red
Me.txtToolID_CutterRCompOffset3Value.Location = New System.Drawing.Point(616, 80)
Me.txtToolID_CutterRCompOffset3Value.Name = "txtToolID_CutterRCompOffset3Value"
Me.txtToolID_CutterRCompOffset3Value.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_CutterRCompOffset3Value.TabIndex = 261
Me.txtToolID_CutterRCompOffset3Value.Text = "0"
'
'Label209
'
Me.Label209.Location = New System.Drawing.Point(400, 80)
Me.Label209.Name = "Label209"
Me.Label209.Size = New System.Drawing.Size(144, 16)
Me.Label209.TabIndex = 260
Me.Label209.Text = "Cutter R. Comp Offset 3"
'
'txtToolID_CutterRCompOffset3
'
Me.txtToolID_CutterRCompOffset3.Location = New System.Drawing.Point(552, 80)
Me.txtToolID_CutterRCompOffset3.Name = "txtToolID_CutterRCompOffset3"
Me.txtToolID_CutterRCompOffset3.ReadOnly = true
Me.txtToolID_CutterRCompOffset3.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_CutterRCompOffset3.TabIndex = 259
Me.txtToolID_CutterRCompOffset3.Text = "0"
'
'cmdToolID_CutterRCompOffset2_Add
'
Me.cmdToolID_CutterRCompOffset2_Add.Location = New System.Drawing.Point(720, 48)
Me.cmdToolID_CutterRCompOffset2_Add.Name = "cmdToolID_CutterRCompOffset2_Add"
Me.cmdToolID_CutterRCompOffset2_Add.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_CutterRCompOffset2_Add.TabIndex = 258
Me.cmdToolID_CutterRCompOffset2_Add.Text = "Add"
'
'cmdToolID_CutterRCompOffset2_Set
'
Me.cmdToolID_CutterRCompOffset2_Set.Location = New System.Drawing.Point(680, 48)
Me.cmdToolID_CutterRCompOffset2_Set.Name = "cmdToolID_CutterRCompOffset2_Set"
Me.cmdToolID_CutterRCompOffset2_Set.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_CutterRCompOffset2_Set.TabIndex = 257
Me.cmdToolID_CutterRCompOffset2_Set.Text = "Set"
'
'txtToolID_CutterRCompOffset2Value
'
Me.txtToolID_CutterRCompOffset2Value.ForeColor = System.Drawing.Color.Red
Me.txtToolID_CutterRCompOffset2Value.Location = New System.Drawing.Point(616, 48)
Me.txtToolID_CutterRCompOffset2Value.Name = "txtToolID_CutterRCompOffset2Value"
Me.txtToolID_CutterRCompOffset2Value.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_CutterRCompOffset2Value.TabIndex = 256
Me.txtToolID_CutterRCompOffset2Value.Text = "0"
'
'Label208
'
Me.Label208.Location = New System.Drawing.Point(400, 48)
Me.Label208.Name = "Label208"
Me.Label208.Size = New System.Drawing.Size(144, 16)
Me.Label208.TabIndex = 255
Me.Label208.Text = "Cutter R. Comp Offset 2"
'
'txtToolID_CutterRCompOffset2
'
Me.txtToolID_CutterRCompOffset2.Location = New System.Drawing.Point(552, 48)
Me.txtToolID_CutterRCompOffset2.Name = "txtToolID_CutterRCompOffset2"
Me.txtToolID_CutterRCompOffset2.ReadOnly = true
Me.txtToolID_CutterRCompOffset2.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_CutterRCompOffset2.TabIndex = 254
Me.txtToolID_CutterRCompOffset2.Text = "0"
'
'cmdToolID_CutterRCompOffset1_Add
'
Me.cmdToolID_CutterRCompOffset1_Add.Location = New System.Drawing.Point(720, 16)
Me.cmdToolID_CutterRCompOffset1_Add.Name = "cmdToolID_CutterRCompOffset1_Add"
Me.cmdToolID_CutterRCompOffset1_Add.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_CutterRCompOffset1_Add.TabIndex = 253
Me.cmdToolID_CutterRCompOffset1_Add.Text = "Add"
'
'cmdToolID_CutterRCompWearOffset_Add
'
Me.cmdToolID_CutterRCompWearOffset_Add.Location = New System.Drawing.Point(720, 112)
Me.cmdToolID_CutterRCompWearOffset_Add.Name = "cmdToolID_CutterRCompWearOffset_Add"
Me.cmdToolID_CutterRCompWearOffset_Add.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_CutterRCompWearOffset_Add.TabIndex = 252
Me.cmdToolID_CutterRCompWearOffset_Add.Text = "Add"
'
'txtToolID_LengthOffset1
'
Me.txtToolID_LengthOffset1.Location = New System.Drawing.Point(152, 16)
Me.txtToolID_LengthOffset1.Name = "txtToolID_LengthOffset1"
Me.txtToolID_LengthOffset1.ReadOnly = true
Me.txtToolID_LengthOffset1.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_LengthOffset1.TabIndex = 216
Me.txtToolID_LengthOffset1.Text = "0"
'
'Label182
'
Me.Label182.Location = New System.Drawing.Point(8, 16)
Me.Label182.Name = "Label182"
Me.Label182.Size = New System.Drawing.Size(136, 16)
Me.Label182.TabIndex = 215
Me.Label182.Text = "Tool Length Offset 1"
'
'txtToolID_CutterRCompWearOffsetValue
'
Me.txtToolID_CutterRCompWearOffsetValue.ForeColor = System.Drawing.Color.Red
Me.txtToolID_CutterRCompWearOffsetValue.Location = New System.Drawing.Point(616, 112)
Me.txtToolID_CutterRCompWearOffsetValue.Name = "txtToolID_CutterRCompWearOffsetValue"
Me.txtToolID_CutterRCompWearOffsetValue.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_CutterRCompWearOffsetValue.TabIndex = 204
Me.txtToolID_CutterRCompWearOffsetValue.Text = "0"
'
'cmdToolID_CutterRCompWearOffset_Set
'
Me.cmdToolID_CutterRCompWearOffset_Set.Location = New System.Drawing.Point(680, 112)
Me.cmdToolID_CutterRCompWearOffset_Set.Name = "cmdToolID_CutterRCompWearOffset_Set"
Me.cmdToolID_CutterRCompWearOffset_Set.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_CutterRCompWearOffset_Set.TabIndex = 207
Me.cmdToolID_CutterRCompWearOffset_Set.Text = "Set"
'
'cmdToolID_CutterRCompOffset1_Set
'
Me.cmdToolID_CutterRCompOffset1_Set.Location = New System.Drawing.Point(680, 16)
Me.cmdToolID_CutterRCompOffset1_Set.Name = "cmdToolID_CutterRCompOffset1_Set"
Me.cmdToolID_CutterRCompOffset1_Set.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_CutterRCompOffset1_Set.TabIndex = 206
Me.cmdToolID_CutterRCompOffset1_Set.Text = "Set"
'
'cmdToolID_LengthOffset1_Add
'
Me.cmdToolID_LengthOffset1_Add.Location = New System.Drawing.Point(320, 16)
Me.cmdToolID_LengthOffset1_Add.Name = "cmdToolID_LengthOffset1_Add"
Me.cmdToolID_LengthOffset1_Add.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_LengthOffset1_Add.TabIndex = 239
Me.cmdToolID_LengthOffset1_Add.Text = "Add"
'
'txtToolID_CutterRCompOffset1Value
'
Me.txtToolID_CutterRCompOffset1Value.ForeColor = System.Drawing.Color.Red
Me.txtToolID_CutterRCompOffset1Value.Location = New System.Drawing.Point(616, 16)
Me.txtToolID_CutterRCompOffset1Value.Name = "txtToolID_CutterRCompOffset1Value"
Me.txtToolID_CutterRCompOffset1Value.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_CutterRCompOffset1Value.TabIndex = 203
Me.txtToolID_CutterRCompOffset1Value.Text = "0"
'
'Label188
'
Me.Label188.Location = New System.Drawing.Point(400, 112)
Me.Label188.Name = "Label188"
Me.Label188.Size = New System.Drawing.Size(144, 16)
Me.Label188.TabIndex = 196
Me.Label188.Text = "Cutter R Comp Wear Offset"
'
'txtToolID_CutterRCompWearOffset
'
Me.txtToolID_CutterRCompWearOffset.Location = New System.Drawing.Point(552, 112)
Me.txtToolID_CutterRCompWearOffset.Name = "txtToolID_CutterRCompWearOffset"
Me.txtToolID_CutterRCompWearOffset.ReadOnly = true
Me.txtToolID_CutterRCompWearOffset.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_CutterRCompWearOffset.TabIndex = 194
Me.txtToolID_CutterRCompWearOffset.Text = "0"
'
'Label189
'
Me.Label189.Location = New System.Drawing.Point(400, 16)
Me.Label189.Name = "Label189"
Me.Label189.Size = New System.Drawing.Size(144, 16)
Me.Label189.TabIndex = 195
Me.Label189.Text = "Cutter R. Comp Offset 1"
'
'txtToolID_CutterRCompOffset1
'
Me.txtToolID_CutterRCompOffset1.Location = New System.Drawing.Point(552, 16)
Me.txtToolID_CutterRCompOffset1.Name = "txtToolID_CutterRCompOffset1"
Me.txtToolID_CutterRCompOffset1.ReadOnly = true
Me.txtToolID_CutterRCompOffset1.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_CutterRCompOffset1.TabIndex = 193
Me.txtToolID_CutterRCompOffset1.Text = "0"
'
'cmdToolID_ToolLengthWearOffset_Add
'
Me.cmdToolID_ToolLengthWearOffset_Add.Location = New System.Drawing.Point(320, 112)
Me.cmdToolID_ToolLengthWearOffset_Add.Name = "cmdToolID_ToolLengthWearOffset_Add"
Me.cmdToolID_ToolLengthWearOffset_Add.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_ToolLengthWearOffset_Add.TabIndex = 224
Me.cmdToolID_ToolLengthWearOffset_Add.Text = "Add"
'
'cmdToolID_ToolLengthWearOffset_Set
'
Me.cmdToolID_ToolLengthWearOffset_Set.Location = New System.Drawing.Point(280, 112)
Me.cmdToolID_ToolLengthWearOffset_Set.Name = "cmdToolID_ToolLengthWearOffset_Set"
Me.cmdToolID_ToolLengthWearOffset_Set.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_ToolLengthWearOffset_Set.TabIndex = 223
Me.cmdToolID_ToolLengthWearOffset_Set.Text = "Set"
'
'txtToolID_ToolLengthWearOffsetValue
'
Me.txtToolID_ToolLengthWearOffsetValue.ForeColor = System.Drawing.Color.Red
Me.txtToolID_ToolLengthWearOffsetValue.Location = New System.Drawing.Point(216, 112)
Me.txtToolID_ToolLengthWearOffsetValue.Name = "txtToolID_ToolLengthWearOffsetValue"
Me.txtToolID_ToolLengthWearOffsetValue.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_ToolLengthWearOffsetValue.TabIndex = 222
Me.txtToolID_ToolLengthWearOffsetValue.Text = "0"
'
'txtToolID_LengthOffset1Value
'
Me.txtToolID_LengthOffset1Value.ForeColor = System.Drawing.Color.Red
Me.txtToolID_LengthOffset1Value.Location = New System.Drawing.Point(216, 16)
Me.txtToolID_LengthOffset1Value.Name = "txtToolID_LengthOffset1Value"
Me.txtToolID_LengthOffset1Value.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_LengthOffset1Value.TabIndex = 217
Me.txtToolID_LengthOffset1Value.Text = "0"
'
'txtToolID_ToolLengthWearOffset
'
Me.txtToolID_ToolLengthWearOffset.Location = New System.Drawing.Point(152, 112)
Me.txtToolID_ToolLengthWearOffset.Name = "txtToolID_ToolLengthWearOffset"
Me.txtToolID_ToolLengthWearOffset.ReadOnly = true
Me.txtToolID_ToolLengthWearOffset.Size = New System.Drawing.Size(56, 20)
Me.txtToolID_ToolLengthWearOffset.TabIndex = 221
Me.txtToolID_ToolLengthWearOffset.Text = "0"
'
'Label181
'
Me.Label181.Location = New System.Drawing.Point(8, 112)
Me.Label181.Name = "Label181"
Me.Label181.Size = New System.Drawing.Size(136, 16)
Me.Label181.TabIndex = 220
Me.Label181.Text = "Tool Length Wear Offset"
'
'cmdToolID_LengthOffset1_Cal
'
Me.cmdToolID_LengthOffset1_Cal.Location = New System.Drawing.Point(360, 16)
Me.cmdToolID_LengthOffset1_Cal.Name = "cmdToolID_LengthOffset1_Cal"
Me.cmdToolID_LengthOffset1_Cal.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_LengthOffset1_Cal.TabIndex = 219
Me.cmdToolID_LengthOffset1_Cal.Text = "Cal"
'
'cmdToolID_LengthOffset1_Set
'
Me.cmdToolID_LengthOffset1_Set.Location = New System.Drawing.Point(280, 16)
Me.cmdToolID_LengthOffset1_Set.Name = "cmdToolID_LengthOffset1_Set"
Me.cmdToolID_LengthOffset1_Set.Size = New System.Drawing.Size(32, 24)
Me.cmdToolID_LengthOffset1_Set.TabIndex = 218
Me.cmdToolID_LengthOffset1_Set.Text = "Set"
'
'cmdToolID_CutterRWearOffset
'
Me.cmdToolID_CutterRWearOffset.Location = New System.Drawing.Point(576, 216)
Me.cmdToolID_CutterRWearOffset.Name = "cmdToolID_CutterRWearOffset"
Me.cmdToolID_CutterRWearOffset.Size = New System.Drawing.Size(136, 24)
Me.cmdToolID_CutterRWearOffset.TabIndex = 248
Me.cmdToolID_CutterRWearOffset.Text = "CutterRadiusWearOffset"
'
'cmdToolID_CutterROffset
'
Me.cmdToolID_CutterROffset.Location = New System.Drawing.Point(160, 216)
Me.cmdToolID_CutterROffset.Name = "cmdToolID_CutterROffset"
Me.cmdToolID_CutterROffset.Size = New System.Drawing.Size(136, 24)
Me.cmdToolID_CutterROffset.TabIndex = 247
Me.cmdToolID_CutterROffset.Text = "CutterRadiusOffset"
'
'cmdToolID_LengthWearOffset
'
Me.cmdToolID_LengthWearOffset.Location = New System.Drawing.Point(576, 184)
Me.cmdToolID_LengthWearOffset.Name = "cmdToolID_LengthWearOffset"
Me.cmdToolID_LengthWearOffset.Size = New System.Drawing.Size(136, 24)
Me.cmdToolID_LengthWearOffset.TabIndex = 246
Me.cmdToolID_LengthWearOffset.Text = "LengthWearOffset"
'
'cmdToolID_LenghtOffset
'
Me.cmdToolID_LenghtOffset.Location = New System.Drawing.Point(160, 184)
Me.cmdToolID_LenghtOffset.Name = "cmdToolID_LenghtOffset"
Me.cmdToolID_LenghtOffset.Size = New System.Drawing.Size(136, 24)
Me.cmdToolID_LenghtOffset.TabIndex = 245
Me.cmdToolID_LenghtOffset.Text = "LengthOffset"
'
'txtToolID_ToPot
'
Me.txtToolID_ToPot.Location = New System.Drawing.Point(504, 144)
Me.txtToolID_ToPot.Name = "txtToolID_ToPot"
Me.txtToolID_ToPot.Size = New System.Drawing.Size(32, 20)
Me.txtToolID_ToPot.TabIndex = 244
Me.txtToolID_ToPot.Text = "2"
'
'Label176
'
Me.Label176.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label176.Location = New System.Drawing.Point(456, 144)
Me.Label176.Name = "Label176"
Me.Label176.Size = New System.Drawing.Size(48, 16)
Me.Label176.TabIndex = 243
Me.Label176.Text = "To Pot"
'
'txtToolID_FromPot
'
Me.txtToolID_FromPot.Location = New System.Drawing.Point(384, 144)
Me.txtToolID_FromPot.Name = "txtToolID_FromPot"
Me.txtToolID_FromPot.Size = New System.Drawing.Size(32, 20)
Me.txtToolID_FromPot.TabIndex = 242
Me.txtToolID_FromPot.Text = "1"
'
'Label177
'
Me.Label177.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label177.Location = New System.Drawing.Point(312, 144)
Me.Label177.Name = "Label177"
Me.Label177.Size = New System.Drawing.Size(72, 16)
Me.Label177.TabIndex = 241
Me.Label177.Text = "From Pot"
'
'GroupBox17
'
Me.GroupBox17.Controls.Add(Me.txtToolID_ToolLifeRemainingSecond)
Me.GroupBox17.Controls.Add(Me.Label178)
Me.GroupBox17.Controls.Add(Me.cmdToolID_LifeStatus_Set)
Me.GroupBox17.Controls.Add(Me.txtToolID_ToolLifeStatus)
Me.GroupBox17.Controls.Add(Me.Label184)
Me.GroupBox17.Controls.Add(Me.cmdToolID_ToolLifeMode_Set)
Me.GroupBox17.Controls.Add(Me.Label187)
Me.GroupBox17.Controls.Add(Me.cboToolID_ToolLifeStatus)
Me.GroupBox17.Controls.Add(Me.cboToolID_ToolLifeMode)
Me.GroupBox17.Controls.Add(Me.txtToolID_ToolLifeMode)
Me.GroupBox17.Controls.Add(Me.cmdToolID_ToolLifeRemaining_Set)
Me.GroupBox17.Controls.Add(Me.txtToolID_ToolLifeRemainingValue)
Me.GroupBox17.Controls.Add(Me.txtToolID_ToolLifeRemaining)
Me.GroupBox17.Controls.Add(Me.Label179)
Me.GroupBox17.Controls.Add(Me.cmdToolID_ToolLife_Set)
Me.GroupBox17.Controls.Add(Me.txtToolID_ToolLifeValue)
Me.GroupBox17.Controls.Add(Me.txtToolID_ToolLife)
Me.GroupBox17.Controls.Add(Me.Label180)
Me.GroupBox17.Location = New System.Drawing.Point(8, 48)
Me.GroupBox17.Name = "GroupBox17"
Me.GroupBox17.Size = New System.Drawing.Size(760, 88)
Me.GroupBox17.TabIndex = 256
Me.GroupBox17.TabStop = false
Me.GroupBox17.Text = "Tool Life"
'
'txtToolID_ToolLifeRemainingSecond
'
Me.txtToolID_ToolLifeRemainingSecond.Location = New System.Drawing.Point(632, 56)
Me.txtToolID_ToolLifeRemainingSecond.Name = "txtToolID_ToolLifeRemainingSecond"
Me.txtToolID_ToolLifeRemainingSecond.ReadOnly = true
Me.txtToolID_ToolLifeRemainingSecond.Size = New System.Drawing.Size(48, 20)
Me.txtToolID_ToolLifeRemainingSecond.TabIndex = 240
Me.txtToolID_ToolLifeRemainingSecond.Text = "0"
'
'Label178
'
Me.Label178.Location = New System.Drawing.Point(632, 16)
Me.Label178.Name = "Label178"
Me.Label178.Size = New System.Drawing.Size(120, 32)
Me.Label178.TabIndex = 239
Me.Label178.Text = "Tool Life Remaining in Second"
'
'cmdToolID_LifeStatus_Set
'
Me.cmdToolID_LifeStatus_Set.Location = New System.Drawing.Point(576, 32)
Me.cmdToolID_LifeStatus_Set.Name = "cmdToolID_LifeStatus_Set"
Me.cmdToolID_LifeStatus_Set.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_LifeStatus_Set.TabIndex = 212
Me.cmdToolID_LifeStatus_Set.Text = "Set"
'
'txtToolID_ToolLifeStatus
'
Me.txtToolID_ToolLifeStatus.Location = New System.Drawing.Point(344, 32)
Me.txtToolID_ToolLifeStatus.Name = "txtToolID_ToolLifeStatus"
Me.txtToolID_ToolLifeStatus.ReadOnly = true
Me.txtToolID_ToolLifeStatus.Size = New System.Drawing.Size(96, 20)
Me.txtToolID_ToolLifeStatus.TabIndex = 211
Me.txtToolID_ToolLifeStatus.Text = "0"
'
'Label184
'
Me.Label184.Location = New System.Drawing.Point(272, 32)
Me.Label184.Name = "Label184"
Me.Label184.Size = New System.Drawing.Size(64, 16)
Me.Label184.TabIndex = 210
Me.Label184.Text = "Tool Status"
'
'cmdToolID_ToolLifeMode_Set
'
Me.cmdToolID_ToolLifeMode_Set.Location = New System.Drawing.Point(576, 56)
Me.cmdToolID_ToolLifeMode_Set.Name = "cmdToolID_ToolLifeMode_Set"
Me.cmdToolID_ToolLifeMode_Set.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_ToolLifeMode_Set.TabIndex = 209
Me.cmdToolID_ToolLifeMode_Set.Text = "Set"
'
'Label187
'
Me.Label187.Location = New System.Drawing.Point(272, 56)
Me.Label187.Name = "Label187"
Me.Label187.Size = New System.Drawing.Size(64, 16)
Me.Label187.TabIndex = 197
Me.Label187.Text = "Tool Mode"
'
'cboToolID_ToolLifeStatus
'
Me.cboToolID_ToolLifeStatus.Items.AddRange(New Object() {"True", "False"})
Me.cboToolID_ToolLifeStatus.Location = New System.Drawing.Point(448, 32)
Me.cboToolID_ToolLifeStatus.Name = "cboToolID_ToolLifeStatus"
Me.cboToolID_ToolLifeStatus.Size = New System.Drawing.Size(120, 20)
Me.cboToolID_ToolLifeStatus.TabIndex = 238
'
'cboToolID_ToolLifeMode
'
Me.cboToolID_ToolLifeMode.Location = New System.Drawing.Point(448, 56)
Me.cboToolID_ToolLifeMode.Name = "cboToolID_ToolLifeMode"
Me.cboToolID_ToolLifeMode.Size = New System.Drawing.Size(120, 20)
Me.cboToolID_ToolLifeMode.TabIndex = 237
'
'txtToolID_ToolLifeMode
'
Me.txtToolID_ToolLifeMode.Location = New System.Drawing.Point(344, 56)
Me.txtToolID_ToolLifeMode.Name = "txtToolID_ToolLifeMode"
Me.txtToolID_ToolLifeMode.ReadOnly = true
Me.txtToolID_ToolLifeMode.Size = New System.Drawing.Size(96, 20)
Me.txtToolID_ToolLifeMode.TabIndex = 198
Me.txtToolID_ToolLifeMode.Text = "0"
'
'cmdToolID_ToolLifeRemaining_Set
'
Me.cmdToolID_ToolLifeRemaining_Set.Location = New System.Drawing.Point(224, 48)
Me.cmdToolID_ToolLifeRemaining_Set.Name = "cmdToolID_ToolLifeRemaining_Set"
Me.cmdToolID_ToolLifeRemaining_Set.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_ToolLifeRemaining_Set.TabIndex = 233
Me.cmdToolID_ToolLifeRemaining_Set.Text = "Set"
'
'txtToolID_ToolLifeRemainingValue
'
Me.txtToolID_ToolLifeRemainingValue.ForeColor = System.Drawing.Color.Red
Me.txtToolID_ToolLifeRemainingValue.Location = New System.Drawing.Point(176, 48)
Me.txtToolID_ToolLifeRemainingValue.Name = "txtToolID_ToolLifeRemainingValue"
Me.txtToolID_ToolLifeRemainingValue.Size = New System.Drawing.Size(40, 20)
Me.txtToolID_ToolLifeRemainingValue.TabIndex = 232
Me.txtToolID_ToolLifeRemainingValue.Text = "0"
'
'txtToolID_ToolLifeRemaining
'
Me.txtToolID_ToolLifeRemaining.Location = New System.Drawing.Point(120, 48)
Me.txtToolID_ToolLifeRemaining.Name = "txtToolID_ToolLifeRemaining"
Me.txtToolID_ToolLifeRemaining.ReadOnly = true
Me.txtToolID_ToolLifeRemaining.Size = New System.Drawing.Size(48, 20)
Me.txtToolID_ToolLifeRemaining.TabIndex = 231
Me.txtToolID_ToolLifeRemaining.Text = "0"
'
'Label179
'
Me.Label179.Location = New System.Drawing.Point(8, 48)
Me.Label179.Name = "Label179"
Me.Label179.Size = New System.Drawing.Size(112, 16)
Me.Label179.TabIndex = 230
Me.Label179.Text = "Tool Life Remaining"
'
'cmdToolID_ToolLife_Set
'
Me.cmdToolID_ToolLife_Set.Location = New System.Drawing.Point(224, 24)
Me.cmdToolID_ToolLife_Set.Name = "cmdToolID_ToolLife_Set"
Me.cmdToolID_ToolLife_Set.Size = New System.Drawing.Size(40, 24)
Me.cmdToolID_ToolLife_Set.TabIndex = 229
Me.cmdToolID_ToolLife_Set.Text = "Set"
'
'txtToolID_ToolLifeValue
'
Me.txtToolID_ToolLifeValue.ForeColor = System.Drawing.Color.Red
Me.txtToolID_ToolLifeValue.Location = New System.Drawing.Point(176, 24)
Me.txtToolID_ToolLifeValue.Name = "txtToolID_ToolLifeValue"
Me.txtToolID_ToolLifeValue.Size = New System.Drawing.Size(40, 20)
Me.txtToolID_ToolLifeValue.TabIndex = 228
Me.txtToolID_ToolLifeValue.Text = "0"
'
'txtToolID_ToolLife
'
Me.txtToolID_ToolLife.Location = New System.Drawing.Point(120, 24)
Me.txtToolID_ToolLife.Name = "txtToolID_ToolLife"
Me.txtToolID_ToolLife.ReadOnly = true
Me.txtToolID_ToolLife.Size = New System.Drawing.Size(48, 20)
Me.txtToolID_ToolLife.TabIndex = 227
Me.txtToolID_ToolLife.Text = "0"
'
'Label180
'
Me.Label180.Location = New System.Drawing.Point(8, 24)
Me.Label180.Name = "Label180"
Me.Label180.Size = New System.Drawing.Size(112, 16)
Me.Label180.TabIndex = 226
Me.Label180.Text = "Tool Life"
'
'Label207
'
Me.Label207.Location = New System.Drawing.Point(232, 16)
Me.Label207.Name = "Label207"
Me.Label207.Size = New System.Drawing.Size(64, 16)
Me.Label207.TabIndex = 254
Me.Label207.Text = "Data Unit"
'
'cmdToolID_DataUnit_Set
'
Me.cmdToolID_DataUnit_Set.Location = New System.Drawing.Point(384, 16)
Me.cmdToolID_DataUnit_Set.Name = "cmdToolID_DataUnit_Set"
Me.cmdToolID_DataUnit_Set.Size = New System.Drawing.Size(48, 23)
Me.cmdToolID_DataUnit_Set.TabIndex = 250
Me.cmdToolID_DataUnit_Set.Text = "Set"
'
'cboToolID_DataUnit
'
Me.cboToolID_DataUnit.Location = New System.Drawing.Point(304, 16)
Me.cboToolID_DataUnit.Name = "cboToolID_DataUnit"
Me.cboToolID_DataUnit.Size = New System.Drawing.Size(72, 20)
Me.cboToolID_DataUnit.TabIndex = 249
'
'txtToolID_PotNo
'
Me.txtToolID_PotNo.Location = New System.Drawing.Point(156, 16)
Me.txtToolID_PotNo.Name = "txtToolID_PotNo"
Me.txtToolID_PotNo.Size = New System.Drawing.Size(64, 20)
Me.txtToolID_PotNo.TabIndex = 202
Me.txtToolID_PotNo.Text = "1"
'
'Label185
'
Me.Label185.Location = New System.Drawing.Point(12, 16)
Me.Label185.Name = "Label185"
Me.Label185.Size = New System.Drawing.Size(136, 16)
Me.Label185.TabIndex = 201
Me.Label185.Text = "Tool/Pot Number"
'
'tab_machine
'
Me.tab_machine.Controls.Add(Me.txtPanelMode)
Me.tab_machine.Controls.Add(Me.Label2)
Me.tab_machine.Controls.Add(Me.GroupBox8)
Me.tab_machine.Controls.Add(Me.Panel11)
Me.tab_machine.Controls.Add(Me.machineUpdateButton)
Me.tab_machine.Controls.Add(Me.machinePowerOnTimeAdd)
Me.tab_machine.Controls.Add(Me.machinePowerOnTimeSet)
Me.tab_machine.Controls.Add(Me.machinePowerOnTimeUpdate)
Me.tab_machine.Controls.Add(Me.machinePowerOnTime)
Me.tab_machine.Controls.Add(Me.Label35)
Me.tab_machine.Controls.Add(Me.machineUnitSytem)
Me.tab_machine.Controls.Add(Me.Label34)
Me.tab_machine.Controls.Add(Me.machineOperationMode)
Me.tab_machine.Controls.Add(Me.Label33)
Me.tab_machine.Controls.Add(Me.machineExecutionMode)
Me.tab_machine.Controls.Add(Me.Label32)
Me.tab_machine.Location = New System.Drawing.Point(4, 22)
Me.tab_machine.Name = "tab_machine"
Me.tab_machine.Size = New System.Drawing.Size(776, 446)
Me.tab_machine.TabIndex = 3
Me.tab_machine.Text = "Machine"
'
'txtPanelMode
'
Me.txtPanelMode.BackColor = System.Drawing.SystemColors.Control
Me.txtPanelMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtPanelMode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.txtPanelMode.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.txtPanelMode.Location = New System.Drawing.Point(208, 104)
Me.txtPanelMode.Name = "txtPanelMode"
Me.txtPanelMode.Size = New System.Drawing.Size(256, 21)
Me.txtPanelMode.TabIndex = 82
Me.txtPanelMode.Text = ""
'
'Label2
'
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label2.Location = New System.Drawing.Point(8, 108)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(184, 16)
Me.Label2.TabIndex = 81
Me.Label2.Text = "Panel Mode :"
'
'GroupBox8
'
Me.GroupBox8.Controls.Add(Me.cmdMachineDataUnit)
Me.GroupBox8.Controls.Add(Me.cboMachineDataUnit)
Me.GroupBox8.Controls.Add(Me.txtInputMachineZeroOffset)
Me.GroupBox8.Controls.Add(Me.Label142)
Me.GroupBox8.Controls.Add(Me.cboMachineZeroOffsetAxis)
Me.GroupBox8.Controls.Add(Me.txtOutputMachineZeroOffset)
Me.GroupBox8.Controls.Add(Me.cmdCalMachineZeroOffset)
Me.GroupBox8.Controls.Add(Me.cmdAddMachineZeroOffset)
Me.GroupBox8.Controls.Add(Me.cmdSetMachineZeroOffset)
Me.GroupBox8.Controls.Add(Me.cmdGetMachineZeroOffset)
Me.GroupBox8.Location = New System.Drawing.Point(8, 200)
Me.GroupBox8.Name = "GroupBox8"
Me.GroupBox8.Size = New System.Drawing.Size(456, 96)
Me.GroupBox8.TabIndex = 80
Me.GroupBox8.TabStop = false
Me.GroupBox8.Text = "Machine Zero Offset"
'
'cmdMachineDataUnit
'
Me.cmdMachineDataUnit.Location = New System.Drawing.Point(352, 24)
Me.cmdMachineDataUnit.Name = "cmdMachineDataUnit"
Me.cmdMachineDataUnit.Size = New System.Drawing.Size(96, 24)
Me.cmdMachineDataUnit.TabIndex = 9
Me.cmdMachineDataUnit.Text = "Set Data Unit"
'
'cboMachineDataUnit
'
Me.cboMachineDataUnit.Location = New System.Drawing.Point(200, 24)
Me.cboMachineDataUnit.Name = "cboMachineDataUnit"
Me.cboMachineDataUnit.Size = New System.Drawing.Size(144, 20)
Me.cboMachineDataUnit.TabIndex = 8
Me.cboMachineDataUnit.Text = "ComboBox1"
'
'txtInputMachineZeroOffset
'
Me.txtInputMachineZeroOffset.ForeColor = System.Drawing.Color.Red
Me.txtInputMachineZeroOffset.Location = New System.Drawing.Point(312, 56)
Me.txtInputMachineZeroOffset.Name = "txtInputMachineZeroOffset"
Me.txtInputMachineZeroOffset.Size = New System.Drawing.Size(80, 20)
Me.txtInputMachineZeroOffset.TabIndex = 7
Me.txtInputMachineZeroOffset.Text = "0.0"
'
'Label142
'
Me.Label142.Location = New System.Drawing.Point(8, 24)
Me.Label142.Name = "Label142"
Me.Label142.Size = New System.Drawing.Size(32, 16)
Me.Label142.TabIndex = 6
Me.Label142.Text = "Axis"
'
'cboMachineZeroOffsetAxis
'
Me.cboMachineZeroOffsetAxis.Location = New System.Drawing.Point(48, 24)
Me.cboMachineZeroOffsetAxis.Name = "cboMachineZeroOffsetAxis"
Me.cboMachineZeroOffsetAxis.Size = New System.Drawing.Size(144, 20)
Me.cboMachineZeroOffsetAxis.TabIndex = 5
'
'txtOutputMachineZeroOffset
'
Me.txtOutputMachineZeroOffset.Location = New System.Drawing.Point(224, 56)
Me.txtOutputMachineZeroOffset.Name = "txtOutputMachineZeroOffset"
Me.txtOutputMachineZeroOffset.ReadOnly = true
Me.txtOutputMachineZeroOffset.Size = New System.Drawing.Size(80, 20)
Me.txtOutputMachineZeroOffset.TabIndex = 4
Me.txtOutputMachineZeroOffset.Text = "0.0"
'
'cmdCalMachineZeroOffset
'
Me.cmdCalMachineZeroOffset.Location = New System.Drawing.Point(152, 56)
Me.cmdCalMachineZeroOffset.Name = "cmdCalMachineZeroOffset"
Me.cmdCalMachineZeroOffset.Size = New System.Drawing.Size(64, 32)
Me.cmdCalMachineZeroOffset.TabIndex = 3
Me.cmdCalMachineZeroOffset.Text = "Calculate"
'
'cmdAddMachineZeroOffset
'
Me.cmdAddMachineZeroOffset.Location = New System.Drawing.Point(104, 56)
Me.cmdAddMachineZeroOffset.Name = "cmdAddMachineZeroOffset"
Me.cmdAddMachineZeroOffset.Size = New System.Drawing.Size(40, 32)
Me.cmdAddMachineZeroOffset.TabIndex = 2
Me.cmdAddMachineZeroOffset.Text = "Add"
'
'cmdSetMachineZeroOffset
'
Me.cmdSetMachineZeroOffset.Location = New System.Drawing.Point(56, 56)
Me.cmdSetMachineZeroOffset.Name = "cmdSetMachineZeroOffset"
Me.cmdSetMachineZeroOffset.Size = New System.Drawing.Size(40, 32)
Me.cmdSetMachineZeroOffset.TabIndex = 1
Me.cmdSetMachineZeroOffset.Text = "Set"
'
'cmdGetMachineZeroOffset
'
Me.cmdGetMachineZeroOffset.Location = New System.Drawing.Point(8, 56)
Me.cmdGetMachineZeroOffset.Name = "cmdGetMachineZeroOffset"
Me.cmdGetMachineZeroOffset.Size = New System.Drawing.Size(40, 32)
Me.cmdGetMachineZeroOffset.TabIndex = 0
Me.cmdGetMachineZeroOffset.Text = "Get"
'
'Panel11
'
Me.Panel11.Controls.Add(Me.Txt_mdicommand)
Me.Panel11.Controls.Add(Me.cmd_InputMDI)
Me.Panel11.Location = New System.Drawing.Point(8, 304)
Me.Panel11.Name = "Panel11"
Me.Panel11.Size = New System.Drawing.Size(456, 40)
Me.Panel11.TabIndex = 79
'
'Txt_mdicommand
'
Me.Txt_mdicommand.Location = New System.Drawing.Point(96, 8)
Me.Txt_mdicommand.Name = "Txt_mdicommand"
Me.Txt_mdicommand.Size = New System.Drawing.Size(352, 20)
Me.Txt_mdicommand.TabIndex = 80
Me.Txt_mdicommand.Text = ""
'
'cmd_InputMDI
'
Me.cmd_InputMDI.Location = New System.Drawing.Point(8, 8)
Me.cmd_InputMDI.Name = "cmd_InputMDI"
Me.cmd_InputMDI.Size = New System.Drawing.Size(80, 24)
Me.cmd_InputMDI.TabIndex = 79
Me.cmd_InputMDI.Text = "InputMDI"
'
'machineUpdateButton
'
Me.machineUpdateButton.Location = New System.Drawing.Point(8, 8)
Me.machineUpdateButton.Name = "machineUpdateButton"
Me.machineUpdateButton.Size = New System.Drawing.Size(104, 24)
Me.machineUpdateButton.TabIndex = 75
Me.machineUpdateButton.Text = "Update"
'
'machinePowerOnTimeAdd
'
Me.machinePowerOnTimeAdd.Location = New System.Drawing.Point(400, 168)
Me.machinePowerOnTimeAdd.Name = "machinePowerOnTimeAdd"
Me.machinePowerOnTimeAdd.Size = New System.Drawing.Size(40, 24)
Me.machinePowerOnTimeAdd.TabIndex = 74
Me.machinePowerOnTimeAdd.Text = "Add"
'
'machinePowerOnTimeSet
'
Me.machinePowerOnTimeSet.Location = New System.Drawing.Point(344, 168)
Me.machinePowerOnTimeSet.Name = "machinePowerOnTimeSet"
Me.machinePowerOnTimeSet.Size = New System.Drawing.Size(48, 24)
Me.machinePowerOnTimeSet.TabIndex = 73
Me.machinePowerOnTimeSet.Text = "Set"
'
'machinePowerOnTimeUpdate
'
Me.machinePowerOnTimeUpdate.BackColor = System.Drawing.Color.White
Me.machinePowerOnTimeUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.machinePowerOnTimeUpdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.machinePowerOnTimeUpdate.ForeColor = System.Drawing.Color.Red
Me.machinePowerOnTimeUpdate.Location = New System.Drawing.Point(240, 168)
Me.machinePowerOnTimeUpdate.Name = "machinePowerOnTimeUpdate"
Me.machinePowerOnTimeUpdate.Size = New System.Drawing.Size(88, 14)
Me.machinePowerOnTimeUpdate.TabIndex = 62
Me.machinePowerOnTimeUpdate.Text = "0"
'
'machinePowerOnTime
'
Me.machinePowerOnTime.BackColor = System.Drawing.SystemColors.Control
Me.machinePowerOnTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.machinePowerOnTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.machinePowerOnTime.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.machinePowerOnTime.Location = New System.Drawing.Point(120, 168)
Me.machinePowerOnTime.Name = "machinePowerOnTime"
Me.machinePowerOnTime.Size = New System.Drawing.Size(112, 21)
Me.machinePowerOnTime.TabIndex = 31
Me.machinePowerOnTime.Text = "0"
'
'Label35
'
Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label35.Location = New System.Drawing.Point(8, 168)
Me.Label35.Name = "Label35"
Me.Label35.Size = New System.Drawing.Size(104, 16)
Me.Label35.TabIndex = 30
Me.Label35.Text = "Power On Time :"
'
'machineUnitSytem
'
Me.machineUnitSytem.BackColor = System.Drawing.SystemColors.Control
Me.machineUnitSytem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.machineUnitSytem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.machineUnitSytem.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.machineUnitSytem.Location = New System.Drawing.Point(208, 136)
Me.machineUnitSytem.Name = "machineUnitSytem"
Me.machineUnitSytem.Size = New System.Drawing.Size(256, 21)
Me.machineUnitSytem.TabIndex = 29
Me.machineUnitSytem.Text = ""
'
'Label34
'
Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label34.Location = New System.Drawing.Point(8, 138)
Me.Label34.Name = "Label34"
Me.Label34.Size = New System.Drawing.Size(184, 16)
Me.Label34.TabIndex = 28
Me.Label34.Text = "Operation Unit System Display :"
'
'machineOperationMode
'
Me.machineOperationMode.BackColor = System.Drawing.SystemColors.Control
Me.machineOperationMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.machineOperationMode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.machineOperationMode.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.machineOperationMode.Location = New System.Drawing.Point(208, 72)
Me.machineOperationMode.Name = "machineOperationMode"
Me.machineOperationMode.Size = New System.Drawing.Size(256, 21)
Me.machineOperationMode.TabIndex = 27
Me.machineOperationMode.Text = ""
'
'Label33
'
Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label33.Location = New System.Drawing.Point(8, 78)
Me.Label33.Name = "Label33"
Me.Label33.Size = New System.Drawing.Size(184, 16)
Me.Label33.TabIndex = 26
Me.Label33.Text = "Operation Mode :"
'
'machineExecutionMode
'
Me.machineExecutionMode.BackColor = System.Drawing.SystemColors.Control
Me.machineExecutionMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.machineExecutionMode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.machineExecutionMode.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.machineExecutionMode.Location = New System.Drawing.Point(208, 40)
Me.machineExecutionMode.Name = "machineExecutionMode"
Me.machineExecutionMode.Size = New System.Drawing.Size(256, 21)
Me.machineExecutionMode.TabIndex = 25
Me.machineExecutionMode.Text = ""
'
'Label32
'
Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label32.Location = New System.Drawing.Point(8, 48)
Me.Label32.Name = "Label32"
Me.Label32.Size = New System.Drawing.Size(184, 16)
Me.Label32.TabIndex = 24
Me.Label32.Text = "Execution Mode :"
'
'tab_MacManAlarmHistory
'
Me.tab_MacManAlarmHistory.Controls.Add(Me.grdMMAlarmHistory)
Me.tab_MacManAlarmHistory.Controls.Add(Me.GroupBox9)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahTo)
Me.tab_MacManAlarmHistory.Controls.Add(Me.Label133)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahFrom)
Me.tab_MacManAlarmHistory.Controls.Add(Me.Label134)
Me.tab_MacManAlarmHistory.Controls.Add(Me.mahButtonResults)
Me.tab_MacManAlarmHistory.Location = New System.Drawing.Point(4, 22)
Me.tab_MacManAlarmHistory.Name = "tab_MacManAlarmHistory"
Me.tab_MacManAlarmHistory.Size = New System.Drawing.Size(776, 446)
Me.tab_MacManAlarmHistory.TabIndex = 12
Me.tab_MacManAlarmHistory.Text = "MacMan Alarm History"
'
'grdMMAlarmHistory
'
Me.grdMMAlarmHistory.DataMember = ""
Me.grdMMAlarmHistory.HeaderForeColor = System.Drawing.SystemColors.ControlText
Me.grdMMAlarmHistory.Location = New System.Drawing.Point(8, 168)
Me.grdMMAlarmHistory.Name = "grdMMAlarmHistory"
Me.grdMMAlarmHistory.Size = New System.Drawing.Size(760, 256)
Me.grdMMAlarmHistory.TabIndex = 214
'
'GroupBox9
'
Me.GroupBox9.Controls.Add(Me.txtAlarmObject)
Me.GroupBox9.Controls.Add(Me.Label145)
Me.GroupBox9.Controls.Add(Me.mahAlarmMessage)
Me.GroupBox9.Controls.Add(Me.Label104)
Me.GroupBox9.Controls.Add(Me.mahAlarmDate)
Me.GroupBox9.Controls.Add(Me.Label105)
Me.GroupBox9.Controls.Add(Me.mahAlarmCode)
Me.GroupBox9.Controls.Add(Me.mahAlarmTime)
Me.GroupBox9.Controls.Add(Me.Label106)
Me.GroupBox9.Controls.Add(Me.Label102)
Me.GroupBox9.Controls.Add(Me.mahAlarmNumber)
Me.GroupBox9.Controls.Add(Me.Label103)
Me.GroupBox9.Controls.Add(Me.mahUpdateButton)
Me.GroupBox9.Controls.Add(Me.Label107)
Me.GroupBox9.Controls.Add(Me.mahMaxAlarmCount)
Me.GroupBox9.Controls.Add(Me.Label98)
Me.GroupBox9.Controls.Add(Me.mahAlarmCount)
Me.GroupBox9.Controls.Add(Me.Label101)
Me.GroupBox9.Controls.Add(Me.mahAlarmIndex)
Me.GroupBox9.Location = New System.Drawing.Point(8, 8)
Me.GroupBox9.Name = "GroupBox9"
Me.GroupBox9.Size = New System.Drawing.Size(764, 112)
Me.GroupBox9.TabIndex = 213
Me.GroupBox9.TabStop = false
'
'txtAlarmObject
'
Me.txtAlarmObject.Location = New System.Drawing.Point(312, 80)
Me.txtAlarmObject.Name = "txtAlarmObject"
Me.txtAlarmObject.Size = New System.Drawing.Size(96, 20)
Me.txtAlarmObject.TabIndex = 183
Me.txtAlarmObject.Text = ""
'
'Label145
'
Me.Label145.Location = New System.Drawing.Point(312, 56)
Me.Label145.Name = "Label145"
Me.Label145.Size = New System.Drawing.Size(96, 16)
Me.Label145.TabIndex = 182
Me.Label145.Text = "Alarm Object:"
'
'mahAlarmMessage
'
Me.mahAlarmMessage.Location = New System.Drawing.Point(568, 80)
Me.mahAlarmMessage.Name = "mahAlarmMessage"
Me.mahAlarmMessage.Size = New System.Drawing.Size(192, 20)
Me.mahAlarmMessage.TabIndex = 170
Me.mahAlarmMessage.Text = ""
'
'Label104
'
Me.Label104.Location = New System.Drawing.Point(568, 56)
Me.Label104.Name = "Label104"
Me.Label104.Size = New System.Drawing.Size(136, 16)
Me.Label104.TabIndex = 169
Me.Label104.Text = "Alarm Message :"
'
'mahAlarmDate
'
Me.mahAlarmDate.Location = New System.Drawing.Point(8, 80)
Me.mahAlarmDate.Name = "mahAlarmDate"
Me.mahAlarmDate.Size = New System.Drawing.Size(88, 20)
Me.mahAlarmDate.TabIndex = 168
Me.mahAlarmDate.Text = ""
'
'Label105
'
Me.Label105.Location = New System.Drawing.Point(8, 56)
Me.Label105.Name = "Label105"
Me.Label105.Size = New System.Drawing.Size(88, 16)
Me.Label105.TabIndex = 167
Me.Label105.Text = "Alarm Date :"
'
'mahAlarmCode
'
Me.mahAlarmCode.Location = New System.Drawing.Point(416, 80)
Me.mahAlarmCode.Name = "mahAlarmCode"
Me.mahAlarmCode.Size = New System.Drawing.Size(144, 20)
Me.mahAlarmCode.TabIndex = 166
Me.mahAlarmCode.Text = ""
'
'mahAlarmTime
'
Me.mahAlarmTime.Location = New System.Drawing.Point(104, 80)
Me.mahAlarmTime.Name = "mahAlarmTime"
Me.mahAlarmTime.Size = New System.Drawing.Size(96, 20)
Me.mahAlarmTime.TabIndex = 174
Me.mahAlarmTime.Text = ""
'
'Label106
'
Me.Label106.Location = New System.Drawing.Point(416, 56)
Me.Label106.Name = "Label106"
Me.Label106.Size = New System.Drawing.Size(136, 16)
Me.Label106.TabIndex = 165
Me.Label106.Text = "Alarm Code :"
'
'Label102
'
Me.Label102.Location = New System.Drawing.Point(104, 56)
Me.Label102.Name = "Label102"
Me.Label102.Size = New System.Drawing.Size(96, 16)
Me.Label102.TabIndex = 173
Me.Label102.Text = "Alarm Time :"
'
'mahAlarmNumber
'
Me.mahAlarmNumber.Location = New System.Drawing.Point(208, 80)
Me.mahAlarmNumber.Name = "mahAlarmNumber"
Me.mahAlarmNumber.Size = New System.Drawing.Size(96, 20)
Me.mahAlarmNumber.TabIndex = 172
Me.mahAlarmNumber.Text = ""
'
'Label103
'
Me.Label103.Location = New System.Drawing.Point(208, 56)
Me.Label103.Name = "Label103"
Me.Label103.Size = New System.Drawing.Size(96, 16)
Me.Label103.TabIndex = 171
Me.Label103.Text = "Alarm Number :"
'
'mahUpdateButton
'
Me.mahUpdateButton.Location = New System.Drawing.Point(200, 16)
Me.mahUpdateButton.Name = "mahUpdateButton"
Me.mahUpdateButton.Size = New System.Drawing.Size(72, 24)
Me.mahUpdateButton.TabIndex = 181
Me.mahUpdateButton.Text = "Update"
'
'Label107
'
Me.Label107.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label107.Location = New System.Drawing.Point(8, 16)
Me.Label107.Name = "Label107"
Me.Label107.Size = New System.Drawing.Size(104, 16)
Me.Label107.TabIndex = 179
Me.Label107.Text = "Alarm Index :"
'
'mahMaxAlarmCount
'
Me.mahMaxAlarmCount.Location = New System.Drawing.Point(640, 16)
Me.mahMaxAlarmCount.Name = "mahMaxAlarmCount"
Me.mahMaxAlarmCount.Size = New System.Drawing.Size(88, 20)
Me.mahMaxAlarmCount.TabIndex = 178
Me.mahMaxAlarmCount.Text = ""
'
'Label98
'
Me.Label98.Location = New System.Drawing.Point(504, 16)
Me.Label98.Name = "Label98"
Me.Label98.Size = New System.Drawing.Size(120, 16)
Me.Label98.TabIndex = 177
Me.Label98.Text = "Max Alarm Count :"
'
'mahAlarmCount
'
Me.mahAlarmCount.Location = New System.Drawing.Point(392, 16)
Me.mahAlarmCount.Name = "mahAlarmCount"
Me.mahAlarmCount.Size = New System.Drawing.Size(96, 20)
Me.mahAlarmCount.TabIndex = 176
Me.mahAlarmCount.Text = ""
'
'Label101
'
Me.Label101.Location = New System.Drawing.Point(296, 16)
Me.Label101.Name = "Label101"
Me.Label101.Size = New System.Drawing.Size(80, 16)
Me.Label101.TabIndex = 175
Me.Label101.Text = "Alarm Count :"
'
'mahAlarmIndex
'
Me.mahAlarmIndex.Location = New System.Drawing.Point(120, 16)
Me.mahAlarmIndex.Name = "mahAlarmIndex"
Me.mahAlarmIndex.Size = New System.Drawing.Size(64, 20)
Me.mahAlarmIndex.TabIndex = 180
Me.mahAlarmIndex.Text = "1"
'
'mahTo
'
Me.mahTo.Location = New System.Drawing.Point(328, 136)
Me.mahTo.Name = "mahTo"
Me.mahTo.Size = New System.Drawing.Size(64, 20)
Me.mahTo.TabIndex = 212
Me.mahTo.Text = "2"
'
'Label133
'
Me.Label133.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label133.Location = New System.Drawing.Point(272, 136)
Me.Label133.Name = "Label133"
Me.Label133.Size = New System.Drawing.Size(48, 16)
Me.Label133.TabIndex = 211
Me.Label133.Text = "To"
'
'mahFrom
'
Me.mahFrom.Location = New System.Drawing.Point(176, 136)
Me.mahFrom.Name = "mahFrom"
Me.mahFrom.Size = New System.Drawing.Size(64, 20)
Me.mahFrom.TabIndex = 210
Me.mahFrom.Text = "1"
'
'Label134
'
Me.Label134.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label134.Location = New System.Drawing.Point(112, 136)
Me.Label134.Name = "Label134"
Me.Label134.Size = New System.Drawing.Size(48, 16)
Me.Label134.TabIndex = 209
Me.Label134.Text = "From"
'
'mahButtonResults
'
Me.mahButtonResults.Location = New System.Drawing.Point(16, 136)
Me.mahButtonResults.Name = "mahButtonResults"
Me.mahButtonResults.Size = New System.Drawing.Size(72, 24)
Me.mahButtonResults.TabIndex = 207
Me.mahButtonResults.Text = "Update"
'
'tab_tools
'
Me.tab_tools.Controls.Add(Me.tulAddCutterRCompOffset)
Me.tab_tools.Controls.Add(Me.tulAddCutterRCompWearOffset)
Me.tab_tools.Controls.Add(Me.tulToolLifeRemainSec)
Me.tab_tools.Controls.Add(Me.Label205)
Me.tab_tools.Controls.Add(Me.Label151)
Me.tab_tools.Controls.Add(Me.tulSetDataUnit)
Me.tab_tools.Controls.Add(Me.tulDataUnitCombo)
Me.tab_tools.Controls.Add(Me.tulButtonCutterRLengthOffset)
Me.tab_tools.Controls.Add(Me.tulButtonCutterROffset)
Me.tab_tools.Controls.Add(Me.tulButtonLengthWearOffset)
Me.tab_tools.Controls.Add(Me.tulButtonLengthOffset)
Me.tab_tools.Controls.Add(Me.tulTo)
Me.tab_tools.Controls.Add(Me.Label125)
Me.tab_tools.Controls.Add(Me.tulFrom)
Me.tab_tools.Controls.Add(Me.Label126)
Me.tab_tools.Controls.Add(Me.tulResults)
Me.tab_tools.Controls.Add(Me.tulAddToolLengthOffset)
Me.tab_tools.Controls.Add(Me.tulUpdToolGroupOrder)
Me.tab_tools.Controls.Add(Me.tulUpdToolStatus)
Me.tab_tools.Controls.Add(Me.tulUpdToolMode)
Me.tab_tools.Controls.Add(Me.tulToolNumber)
Me.tab_tools.Controls.Add(Me.label100)
Me.tab_tools.Controls.Add(Me.Label81)
Me.tab_tools.Controls.Add(Me.tulUpdateButtonNoParam)
Me.tab_tools.Controls.Add(Me.tulNoParam)
Me.tab_tools.Controls.Add(Me.tulUpdateButton)
Me.tab_tools.Controls.Add(Me.tulSetToolLifeRemaining)
Me.tab_tools.Controls.Add(Me.tulUpdToolLifeRemaining)
Me.tab_tools.Controls.Add(Me.tulToolLifeRemaining)
Me.tab_tools.Controls.Add(Me.Label88)
Me.tab_tools.Controls.Add(Me.tulSetToolLife)
Me.tab_tools.Controls.Add(Me.tulUpdToolLife)
Me.tab_tools.Controls.Add(Me.tulToolLife)
Me.tab_tools.Controls.Add(Me.Label87)
Me.tab_tools.Controls.Add(Me.tulCalToolLengthWearOffset)
Me.tab_tools.Controls.Add(Me.tulAddToolLengthWearOffset)
Me.tab_tools.Controls.Add(Me.tulSetToolLengthWearOffset)
Me.tab_tools.Controls.Add(Me.tulUpdToolLengthWearOffset)
Me.tab_tools.Controls.Add(Me.tulToolLengthWearOffset)
Me.tab_tools.Controls.Add(Me.Label86)
Me.tab_tools.Controls.Add(Me.tulCalToolLengthOffset)
Me.tab_tools.Controls.Add(Me.tulSetToolLengthOffset)
Me.tab_tools.Controls.Add(Me.tulUpdToolLengthOffset)
Me.tab_tools.Controls.Add(Me.tulToolLengthOffset)
Me.tab_tools.Controls.Add(Me.Label85)
Me.tab_tools.Controls.Add(Me.tulToolKind)
Me.tab_tools.Controls.Add(Me.Label84)
Me.tab_tools.Controls.Add(Me.tulSetToolGroupOrder)
Me.tab_tools.Controls.Add(Me.tulToolGroupOrder)
Me.tab_tools.Controls.Add(Me.Label83)
Me.tab_tools.Controls.Add(Me.tulSetToolStatus)
Me.tab_tools.Controls.Add(Me.tulToolStatus)
Me.tab_tools.Controls.Add(Me.Label82)
Me.tab_tools.Controls.Add(Me.tulSetReferenceToolOffset3)
Me.tab_tools.Controls.Add(Me.tulSetReferenceToolOffset2)
Me.tab_tools.Controls.Add(Me.tulSetToolMode)
Me.tab_tools.Controls.Add(Me.tulSetToolGroup)
Me.tab_tools.Controls.Add(Me.tulSetCutterRCompWearOffset)
Me.tab_tools.Controls.Add(Me.tulSetCutterRCompOffset)
Me.tab_tools.Controls.Add(Me.tulUpdReferenceToolOffset3)
Me.tab_tools.Controls.Add(Me.tulUpdReferenceToolOffset2)
Me.tab_tools.Controls.Add(Me.tulUpdToolGroup)
Me.tab_tools.Controls.Add(Me.tulUpdCutterRCompWearOffset)
Me.tab_tools.Controls.Add(Me.tulUpdCutterRCompOffset)
Me.tab_tools.Controls.Add(Me.tulReferenceToolOffset3)
Me.tab_tools.Controls.Add(Me.Label74)
Me.tab_tools.Controls.Add(Me.tulReferenceToolOffset2)
Me.tab_tools.Controls.Add(Me.Label75)
Me.tab_tools.Controls.Add(Me.tulPotNumber)
Me.tab_tools.Controls.Add(Me.Label76)
Me.tab_tools.Controls.Add(Me.tulToolGroup)
Me.tab_tools.Controls.Add(Me.Label77)
Me.tab_tools.Controls.Add(Me.tulToolMode)
Me.tab_tools.Controls.Add(Me.Label78)
Me.tab_tools.Controls.Add(Me.Label79)
Me.tab_tools.Controls.Add(Me.tulCutterRCompWearOffset)
Me.tab_tools.Controls.Add(Me.Label80)
Me.tab_tools.Controls.Add(Me.tulCutterRCompOffset)
Me.tab_tools.Location = New System.Drawing.Point(4, 22)
Me.tab_tools.Name = "tab_tools"
Me.tab_tools.Size = New System.Drawing.Size(776, 446)
Me.tab_tools.TabIndex = 9
Me.tab_tools.Text = "Tools"
'
'tulAddCutterRCompOffset
'
Me.tulAddCutterRCompOffset.Location = New System.Drawing.Point(352, 40)
Me.tulAddCutterRCompOffset.Name = "tulAddCutterRCompOffset"
Me.tulAddCutterRCompOffset.Size = New System.Drawing.Size(40, 24)
Me.tulAddCutterRCompOffset.TabIndex = 192
Me.tulAddCutterRCompOffset.Text = "Add"
'
'tulAddCutterRCompWearOffset
'
Me.tulAddCutterRCompWearOffset.Location = New System.Drawing.Point(352, 64)
Me.tulAddCutterRCompWearOffset.Name = "tulAddCutterRCompWearOffset"
Me.tulAddCutterRCompWearOffset.Size = New System.Drawing.Size(40, 24)
Me.tulAddCutterRCompWearOffset.TabIndex = 191
Me.tulAddCutterRCompWearOffset.Text = "Add"
'
'tulToolLifeRemainSec
'
Me.tulToolLifeRemainSec.Location = New System.Drawing.Point(440, 96)
Me.tulToolLifeRemainSec.Name = "tulToolLifeRemainSec"
Me.tulToolLifeRemainSec.Size = New System.Drawing.Size(72, 20)
Me.tulToolLifeRemainSec.TabIndex = 190
Me.tulToolLifeRemainSec.Text = "0"
'
'Label205
'
Me.Label205.Location = New System.Drawing.Point(440, 40)
Me.Label205.Name = "Label205"
Me.Label205.Size = New System.Drawing.Size(64, 40)
Me.Label205.TabIndex = 189
Me.Label205.Text = "Tool Life Remaining Seconds"
'
'Label151
'
Me.Label151.Location = New System.Drawing.Point(296, 16)
Me.Label151.Name = "Label151"
Me.Label151.Size = New System.Drawing.Size(64, 16)
Me.Label151.TabIndex = 188
Me.Label151.Text = "Data Unit"
'
'tulSetDataUnit
'
Me.tulSetDataUnit.Location = New System.Drawing.Point(432, 8)
Me.tulSetDataUnit.Name = "tulSetDataUnit"
Me.tulSetDataUnit.Size = New System.Drawing.Size(48, 23)
Me.tulSetDataUnit.TabIndex = 187
Me.tulSetDataUnit.Text = "Set"
'
'tulDataUnitCombo
'
Me.tulDataUnitCombo.Location = New System.Drawing.Point(360, 8)
Me.tulDataUnitCombo.Name = "tulDataUnitCombo"
Me.tulDataUnitCombo.Size = New System.Drawing.Size(72, 20)
Me.tulDataUnitCombo.TabIndex = 186
'
'tulButtonCutterRLengthOffset
'
Me.tulButtonCutterRLengthOffset.Location = New System.Drawing.Point(456, 344)
Me.tulButtonCutterRLengthOffset.Name = "tulButtonCutterRLengthOffset"
Me.tulButtonCutterRLengthOffset.Size = New System.Drawing.Size(120, 24)
Me.tulButtonCutterRLengthOffset.TabIndex = 185
Me.tulButtonCutterRLengthOffset.Text = "CutterRWearOffset"
'
'tulButtonCutterROffset
'
Me.tulButtonCutterROffset.Location = New System.Drawing.Point(456, 312)
Me.tulButtonCutterROffset.Name = "tulButtonCutterROffset"
Me.tulButtonCutterROffset.Size = New System.Drawing.Size(120, 24)
Me.tulButtonCutterROffset.TabIndex = 184
Me.tulButtonCutterROffset.Text = "CutterROffset"
'
'tulButtonLengthWearOffset
'
Me.tulButtonLengthWearOffset.Location = New System.Drawing.Point(456, 280)
Me.tulButtonLengthWearOffset.Name = "tulButtonLengthWearOffset"
Me.tulButtonLengthWearOffset.Size = New System.Drawing.Size(120, 24)
Me.tulButtonLengthWearOffset.TabIndex = 183
Me.tulButtonLengthWearOffset.Text = "LengthWearOffset"
'
'tulButtonLengthOffset
'
Me.tulButtonLengthOffset.Location = New System.Drawing.Point(456, 248)
Me.tulButtonLengthOffset.Name = "tulButtonLengthOffset"
Me.tulButtonLengthOffset.Size = New System.Drawing.Size(120, 24)
Me.tulButtonLengthOffset.TabIndex = 182
Me.tulButtonLengthOffset.Text = "LengthOffset"
'
'tulTo
'
Me.tulTo.Location = New System.Drawing.Point(512, 216)
Me.tulTo.Name = "tulTo"
Me.tulTo.Size = New System.Drawing.Size(64, 20)
Me.tulTo.TabIndex = 181
Me.tulTo.Text = "2"
'
'Label125
'
Me.Label125.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label125.Location = New System.Drawing.Point(464, 216)
Me.Label125.Name = "Label125"
Me.Label125.Size = New System.Drawing.Size(48, 16)
Me.Label125.TabIndex = 180
Me.Label125.Text = "To"
'
'tulFrom
'
Me.tulFrom.Location = New System.Drawing.Point(512, 192)
Me.tulFrom.Name = "tulFrom"
Me.tulFrom.Size = New System.Drawing.Size(64, 20)
Me.tulFrom.TabIndex = 179
Me.tulFrom.Text = "1"
'
'Label126
'
Me.Label126.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label126.Location = New System.Drawing.Point(464, 192)
Me.Label126.Name = "Label126"
Me.Label126.Size = New System.Drawing.Size(48, 16)
Me.Label126.TabIndex = 178
Me.Label126.Text = "From"
'
'tulResults
'
Me.tulResults.Location = New System.Drawing.Point(584, 192)
Me.tulResults.Multiline = true
Me.tulResults.Name = "tulResults"
Me.tulResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.tulResults.Size = New System.Drawing.Size(164, 184)
Me.tulResults.TabIndex = 177
Me.tulResults.Text = ""
'
'tulAddToolLengthOffset
'
Me.tulAddToolLengthOffset.Location = New System.Drawing.Point(352, 280)
Me.tulAddToolLengthOffset.Name = "tulAddToolLengthOffset"
Me.tulAddToolLengthOffset.Size = New System.Drawing.Size(40, 24)
Me.tulAddToolLengthOffset.TabIndex = 176
Me.tulAddToolLengthOffset.Text = "Add"
'
'tulUpdToolGroupOrder
'
Me.tulUpdToolGroupOrder.Items.AddRange(New Object() {"True", "False"})
Me.tulUpdToolGroupOrder.Location = New System.Drawing.Point(232, 232)
Me.tulUpdToolGroupOrder.Name = "tulUpdToolGroupOrder"
Me.tulUpdToolGroupOrder.Size = New System.Drawing.Size(120, 20)
Me.tulUpdToolGroupOrder.TabIndex = 175
'
'tulUpdToolStatus
'
Me.tulUpdToolStatus.Items.AddRange(New Object() {"True", "False"})
Me.tulUpdToolStatus.Location = New System.Drawing.Point(232, 208)
Me.tulUpdToolStatus.Name = "tulUpdToolStatus"
Me.tulUpdToolStatus.Size = New System.Drawing.Size(120, 20)
Me.tulUpdToolStatus.TabIndex = 174
'
'tulUpdToolMode
'
Me.tulUpdToolMode.Location = New System.Drawing.Point(232, 112)
Me.tulUpdToolMode.Name = "tulUpdToolMode"
Me.tulUpdToolMode.Size = New System.Drawing.Size(120, 20)
Me.tulUpdToolMode.TabIndex = 173
'
'tulToolNumber
'
Me.tulToolNumber.Location = New System.Drawing.Point(160, 11)
Me.tulToolNumber.Name = "tulToolNumber"
Me.tulToolNumber.Size = New System.Drawing.Size(64, 20)
Me.tulToolNumber.TabIndex = 172
Me.tulToolNumber.Text = "1"
'
'label100
'
Me.label100.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.label100.Location = New System.Drawing.Point(16, 8)
Me.label100.Name = "label100"
Me.label100.Size = New System.Drawing.Size(136, 16)
Me.label100.TabIndex = 171
Me.label100.Text = "Tool Number/Offset"
'
'Label81
'
Me.Label81.Location = New System.Drawing.Point(496, 152)
Me.Label81.Name = "Label81"
Me.Label81.Size = New System.Drawing.Size(80, 32)
Me.Label81.TabIndex = 170
Me.Label81.Text = "Values with no parameters :"
Me.Label81.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'tulUpdateButtonNoParam
'
Me.tulUpdateButtonNoParam.Location = New System.Drawing.Point(664, 152)
Me.tulUpdateButtonNoParam.Name = "tulUpdateButtonNoParam"
Me.tulUpdateButtonNoParam.Size = New System.Drawing.Size(72, 24)
Me.tulUpdateButtonNoParam.TabIndex = 169
Me.tulUpdateButtonNoParam.Text = "Update"
'
'tulNoParam
'
Me.tulNoParam.Location = New System.Drawing.Point(520, 16)
Me.tulNoParam.Multiline = true
Me.tulNoParam.Name = "tulNoParam"
Me.tulNoParam.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.tulNoParam.Size = New System.Drawing.Size(248, 128)
Me.tulNoParam.TabIndex = 168
Me.tulNoParam.Text = ""
'
'tulUpdateButton
'
Me.tulUpdateButton.Location = New System.Drawing.Point(232, 7)
Me.tulUpdateButton.Name = "tulUpdateButton"
Me.tulUpdateButton.Size = New System.Drawing.Size(56, 24)
Me.tulUpdateButton.TabIndex = 167
Me.tulUpdateButton.Text = "Update"
'
'tulSetToolLifeRemaining
'
Me.tulSetToolLifeRemaining.Location = New System.Drawing.Point(304, 352)
Me.tulSetToolLifeRemaining.Name = "tulSetToolLifeRemaining"
Me.tulSetToolLifeRemaining.Size = New System.Drawing.Size(40, 24)
Me.tulSetToolLifeRemaining.TabIndex = 166
Me.tulSetToolLifeRemaining.Text = "Set"
'
'tulUpdToolLifeRemaining
'
Me.tulUpdToolLifeRemaining.ForeColor = System.Drawing.Color.Red
Me.tulUpdToolLifeRemaining.Location = New System.Drawing.Point(232, 352)
Me.tulUpdToolLifeRemaining.Name = "tulUpdToolLifeRemaining"
Me.tulUpdToolLifeRemaining.Size = New System.Drawing.Size(64, 20)
Me.tulUpdToolLifeRemaining.TabIndex = 165
Me.tulUpdToolLifeRemaining.Text = "0"
'
'tulToolLifeRemaining
'
Me.tulToolLifeRemaining.Location = New System.Drawing.Point(160, 352)
Me.tulToolLifeRemaining.Name = "tulToolLifeRemaining"
Me.tulToolLifeRemaining.Size = New System.Drawing.Size(64, 20)
Me.tulToolLifeRemaining.TabIndex = 164
Me.tulToolLifeRemaining.Text = "0"
'
'Label88
'
Me.Label88.Location = New System.Drawing.Point(16, 352)
Me.Label88.Name = "Label88"
Me.Label88.Size = New System.Drawing.Size(136, 16)
Me.Label88.TabIndex = 163
Me.Label88.Text = "Tool Life Remaining"
'
'tulSetToolLife
'
Me.tulSetToolLife.Location = New System.Drawing.Point(304, 328)
Me.tulSetToolLife.Name = "tulSetToolLife"
Me.tulSetToolLife.Size = New System.Drawing.Size(40, 24)
Me.tulSetToolLife.TabIndex = 160
Me.tulSetToolLife.Text = "Set"
'
'tulUpdToolLife
'
Me.tulUpdToolLife.ForeColor = System.Drawing.Color.Red
Me.tulUpdToolLife.Location = New System.Drawing.Point(232, 328)
Me.tulUpdToolLife.Name = "tulUpdToolLife"
Me.tulUpdToolLife.Size = New System.Drawing.Size(64, 20)
Me.tulUpdToolLife.TabIndex = 159
Me.tulUpdToolLife.Text = "0"
'
'tulToolLife
'
Me.tulToolLife.Location = New System.Drawing.Point(160, 328)
Me.tulToolLife.Name = "tulToolLife"
Me.tulToolLife.Size = New System.Drawing.Size(64, 20)
Me.tulToolLife.TabIndex = 158
Me.tulToolLife.Text = "0"
'
'Label87
'
Me.Label87.Location = New System.Drawing.Point(16, 328)
Me.Label87.Name = "Label87"
Me.Label87.Size = New System.Drawing.Size(136, 16)
Me.Label87.TabIndex = 157
Me.Label87.Text = "Tool Life"
'
'tulCalToolLengthWearOffset
'
Me.tulCalToolLengthWearOffset.Location = New System.Drawing.Point(400, 304)
Me.tulCalToolLengthWearOffset.Name = "tulCalToolLengthWearOffset"
Me.tulCalToolLengthWearOffset.Size = New System.Drawing.Size(40, 24)
Me.tulCalToolLengthWearOffset.TabIndex = 156
Me.tulCalToolLengthWearOffset.Text = "Cal"
'
'tulAddToolLengthWearOffset
'
Me.tulAddToolLengthWearOffset.Location = New System.Drawing.Point(352, 304)
Me.tulAddToolLengthWearOffset.Name = "tulAddToolLengthWearOffset"
Me.tulAddToolLengthWearOffset.Size = New System.Drawing.Size(40, 24)
Me.tulAddToolLengthWearOffset.TabIndex = 155
Me.tulAddToolLengthWearOffset.Text = "Add"
'
'tulSetToolLengthWearOffset
'
Me.tulSetToolLengthWearOffset.Location = New System.Drawing.Point(304, 304)
Me.tulSetToolLengthWearOffset.Name = "tulSetToolLengthWearOffset"
Me.tulSetToolLengthWearOffset.Size = New System.Drawing.Size(40, 24)
Me.tulSetToolLengthWearOffset.TabIndex = 154
Me.tulSetToolLengthWearOffset.Text = "Set"
'
'tulUpdToolLengthWearOffset
'
Me.tulUpdToolLengthWearOffset.ForeColor = System.Drawing.Color.Red
Me.tulUpdToolLengthWearOffset.Location = New System.Drawing.Point(232, 304)
Me.tulUpdToolLengthWearOffset.Name = "tulUpdToolLengthWearOffset"
Me.tulUpdToolLengthWearOffset.Size = New System.Drawing.Size(64, 20)
Me.tulUpdToolLengthWearOffset.TabIndex = 153
Me.tulUpdToolLengthWearOffset.Text = "0"
'
'tulToolLengthWearOffset
'
Me.tulToolLengthWearOffset.Location = New System.Drawing.Point(160, 304)
Me.tulToolLengthWearOffset.Name = "tulToolLengthWearOffset"
Me.tulToolLengthWearOffset.Size = New System.Drawing.Size(64, 20)
Me.tulToolLengthWearOffset.TabIndex = 152
Me.tulToolLengthWearOffset.Text = "0"
'
'Label86
'
Me.Label86.Location = New System.Drawing.Point(16, 304)
Me.Label86.Name = "Label86"
Me.Label86.Size = New System.Drawing.Size(136, 16)
Me.Label86.TabIndex = 151
Me.Label86.Text = "Tool Length Wear Offset"
'
'tulCalToolLengthOffset
'
Me.tulCalToolLengthOffset.Location = New System.Drawing.Point(400, 280)
Me.tulCalToolLengthOffset.Name = "tulCalToolLengthOffset"
Me.tulCalToolLengthOffset.Size = New System.Drawing.Size(40, 24)
Me.tulCalToolLengthOffset.TabIndex = 150
Me.tulCalToolLengthOffset.Text = "Cal"
'
'tulSetToolLengthOffset
'
Me.tulSetToolLengthOffset.Location = New System.Drawing.Point(304, 280)
Me.tulSetToolLengthOffset.Name = "tulSetToolLengthOffset"
Me.tulSetToolLengthOffset.Size = New System.Drawing.Size(40, 24)
Me.tulSetToolLengthOffset.TabIndex = 148
Me.tulSetToolLengthOffset.Text = "Set"
'
'tulUpdToolLengthOffset
'
Me.tulUpdToolLengthOffset.ForeColor = System.Drawing.Color.Red
Me.tulUpdToolLengthOffset.Location = New System.Drawing.Point(232, 280)
Me.tulUpdToolLengthOffset.Name = "tulUpdToolLengthOffset"
Me.tulUpdToolLengthOffset.Size = New System.Drawing.Size(64, 20)
Me.tulUpdToolLengthOffset.TabIndex = 147
Me.tulUpdToolLengthOffset.Text = "0"
'
'tulToolLengthOffset
'
Me.tulToolLengthOffset.Location = New System.Drawing.Point(160, 280)
Me.tulToolLengthOffset.Name = "tulToolLengthOffset"
Me.tulToolLengthOffset.Size = New System.Drawing.Size(64, 20)
Me.tulToolLengthOffset.TabIndex = 146
Me.tulToolLengthOffset.Text = "0"
'
'Label85
'
Me.Label85.Location = New System.Drawing.Point(16, 280)
Me.Label85.Name = "Label85"
Me.Label85.Size = New System.Drawing.Size(136, 16)
Me.Label85.TabIndex = 145
Me.Label85.Text = "Tool Length Offset"
'
'tulToolKind
'
Me.tulToolKind.Location = New System.Drawing.Point(160, 256)
Me.tulToolKind.Name = "tulToolKind"
Me.tulToolKind.Size = New System.Drawing.Size(64, 20)
Me.tulToolKind.TabIndex = 140
Me.tulToolKind.Text = "0"
'
'Label84
'
Me.Label84.Location = New System.Drawing.Point(16, 256)
Me.Label84.Name = "Label84"
Me.Label84.Size = New System.Drawing.Size(136, 16)
Me.Label84.TabIndex = 139
Me.Label84.Text = "Tool Kind"
'
'tulSetToolGroupOrder
'
Me.tulSetToolGroupOrder.Location = New System.Drawing.Point(360, 232)
Me.tulSetToolGroupOrder.Name = "tulSetToolGroupOrder"
Me.tulSetToolGroupOrder.Size = New System.Drawing.Size(40, 24)
Me.tulSetToolGroupOrder.TabIndex = 136
Me.tulSetToolGroupOrder.Text = "Set"
'
'tulToolGroupOrder
'
Me.tulToolGroupOrder.Location = New System.Drawing.Point(160, 232)
Me.tulToolGroupOrder.Name = "tulToolGroupOrder"
Me.tulToolGroupOrder.Size = New System.Drawing.Size(64, 20)
Me.tulToolGroupOrder.TabIndex = 134
Me.tulToolGroupOrder.Text = "0"
'
'Label83
'
Me.Label83.Location = New System.Drawing.Point(16, 232)
Me.Label83.Name = "Label83"
Me.Label83.Size = New System.Drawing.Size(136, 16)
Me.Label83.TabIndex = 133
Me.Label83.Text = "Tool Group Order"
'
'tulSetToolStatus
'
Me.tulSetToolStatus.Location = New System.Drawing.Point(360, 208)
Me.tulSetToolStatus.Name = "tulSetToolStatus"
Me.tulSetToolStatus.Size = New System.Drawing.Size(40, 24)
Me.tulSetToolStatus.TabIndex = 130
Me.tulSetToolStatus.Text = "Set"
'
'tulToolStatus
'
Me.tulToolStatus.Location = New System.Drawing.Point(160, 208)
Me.tulToolStatus.Name = "tulToolStatus"
Me.tulToolStatus.Size = New System.Drawing.Size(64, 20)
Me.tulToolStatus.TabIndex = 128
Me.tulToolStatus.Text = "0"
'
'Label82
'
Me.Label82.Location = New System.Drawing.Point(16, 208)
Me.Label82.Name = "Label82"
Me.Label82.Size = New System.Drawing.Size(136, 16)
Me.Label82.TabIndex = 127
Me.Label82.Text = "Tool Status"
'
'tulSetReferenceToolOffset3
'
Me.tulSetReferenceToolOffset3.Location = New System.Drawing.Point(304, 184)
Me.tulSetReferenceToolOffset3.Name = "tulSetReferenceToolOffset3"
Me.tulSetReferenceToolOffset3.Size = New System.Drawing.Size(40, 24)
Me.tulSetReferenceToolOffset3.TabIndex = 110
Me.tulSetReferenceToolOffset3.Text = "Set"
'
'tulSetReferenceToolOffset2
'
Me.tulSetReferenceToolOffset2.Location = New System.Drawing.Point(304, 160)
Me.tulSetReferenceToolOffset2.Name = "tulSetReferenceToolOffset2"
Me.tulSetReferenceToolOffset2.Size = New System.Drawing.Size(40, 24)
Me.tulSetReferenceToolOffset2.TabIndex = 109
Me.tulSetReferenceToolOffset2.Text = "Set"
'
'tulSetToolMode
'
Me.tulSetToolMode.Location = New System.Drawing.Point(360, 112)
Me.tulSetToolMode.Name = "tulSetToolMode"
Me.tulSetToolMode.Size = New System.Drawing.Size(40, 24)
Me.tulSetToolMode.TabIndex = 107
Me.tulSetToolMode.Text = "Set"
'
'tulSetToolGroup
'
Me.tulSetToolGroup.Location = New System.Drawing.Point(304, 88)
Me.tulSetToolGroup.Name = "tulSetToolGroup"
Me.tulSetToolGroup.Size = New System.Drawing.Size(40, 24)
Me.tulSetToolGroup.TabIndex = 106
Me.tulSetToolGroup.Text = "Set"
'
'tulSetCutterRCompWearOffset
'
Me.tulSetCutterRCompWearOffset.Location = New System.Drawing.Point(304, 64)
Me.tulSetCutterRCompWearOffset.Name = "tulSetCutterRCompWearOffset"
Me.tulSetCutterRCompWearOffset.Size = New System.Drawing.Size(40, 24)
Me.tulSetCutterRCompWearOffset.TabIndex = 104
Me.tulSetCutterRCompWearOffset.Text = "Set"
'
'tulSetCutterRCompOffset
'
Me.tulSetCutterRCompOffset.Location = New System.Drawing.Point(304, 40)
Me.tulSetCutterRCompOffset.Name = "tulSetCutterRCompOffset"
Me.tulSetCutterRCompOffset.Size = New System.Drawing.Size(40, 24)
Me.tulSetCutterRCompOffset.TabIndex = 103
Me.tulSetCutterRCompOffset.Text = "Set"
'
'tulUpdReferenceToolOffset3
'
Me.tulUpdReferenceToolOffset3.ForeColor = System.Drawing.Color.Red
Me.tulUpdReferenceToolOffset3.Location = New System.Drawing.Point(232, 184)
Me.tulUpdReferenceToolOffset3.Name = "tulUpdReferenceToolOffset3"
Me.tulUpdReferenceToolOffset3.Size = New System.Drawing.Size(64, 20)
Me.tulUpdReferenceToolOffset3.TabIndex = 102
Me.tulUpdReferenceToolOffset3.Text = "0"
'
'tulUpdReferenceToolOffset2
'
Me.tulUpdReferenceToolOffset2.ForeColor = System.Drawing.Color.Red
Me.tulUpdReferenceToolOffset2.Location = New System.Drawing.Point(232, 160)
Me.tulUpdReferenceToolOffset2.Name = "tulUpdReferenceToolOffset2"
Me.tulUpdReferenceToolOffset2.Size = New System.Drawing.Size(64, 20)
Me.tulUpdReferenceToolOffset2.TabIndex = 101
Me.tulUpdReferenceToolOffset2.Text = "0"
'
'tulUpdToolGroup
'
Me.tulUpdToolGroup.ForeColor = System.Drawing.Color.Red
Me.tulUpdToolGroup.Location = New System.Drawing.Point(232, 88)
Me.tulUpdToolGroup.Name = "tulUpdToolGroup"
Me.tulUpdToolGroup.Size = New System.Drawing.Size(64, 20)
Me.tulUpdToolGroup.TabIndex = 99
Me.tulUpdToolGroup.Text = "0"
'
'tulUpdCutterRCompWearOffset
'
Me.tulUpdCutterRCompWearOffset.ForeColor = System.Drawing.Color.Red
Me.tulUpdCutterRCompWearOffset.Location = New System.Drawing.Point(232, 64)
Me.tulUpdCutterRCompWearOffset.Name = "tulUpdCutterRCompWearOffset"
Me.tulUpdCutterRCompWearOffset.Size = New System.Drawing.Size(64, 20)
Me.tulUpdCutterRCompWearOffset.TabIndex = 96
Me.tulUpdCutterRCompWearOffset.Text = "0"
'
'tulUpdCutterRCompOffset
'
Me.tulUpdCutterRCompOffset.ForeColor = System.Drawing.Color.Red
Me.tulUpdCutterRCompOffset.Location = New System.Drawing.Point(232, 40)
Me.tulUpdCutterRCompOffset.Name = "tulUpdCutterRCompOffset"
Me.tulUpdCutterRCompOffset.Size = New System.Drawing.Size(64, 20)
Me.tulUpdCutterRCompOffset.TabIndex = 95
Me.tulUpdCutterRCompOffset.Text = "0"
'
'tulReferenceToolOffset3
'
Me.tulReferenceToolOffset3.Location = New System.Drawing.Point(160, 184)
Me.tulReferenceToolOffset3.Name = "tulReferenceToolOffset3"
Me.tulReferenceToolOffset3.Size = New System.Drawing.Size(64, 20)
Me.tulReferenceToolOffset3.TabIndex = 94
Me.tulReferenceToolOffset3.Text = "0"
'
'Label74
'
Me.Label74.Location = New System.Drawing.Point(16, 184)
Me.Label74.Name = "Label74"
Me.Label74.Size = New System.Drawing.Size(136, 16)
Me.Label74.TabIndex = 93
Me.Label74.Text = "Reference ToolOffset 3"
'
'tulReferenceToolOffset2
'
Me.tulReferenceToolOffset2.Location = New System.Drawing.Point(160, 160)
Me.tulReferenceToolOffset2.Name = "tulReferenceToolOffset2"
Me.tulReferenceToolOffset2.Size = New System.Drawing.Size(64, 20)
Me.tulReferenceToolOffset2.TabIndex = 92
Me.tulReferenceToolOffset2.Text = "0"
'
'Label75
'
Me.Label75.Location = New System.Drawing.Point(16, 160)
Me.Label75.Name = "Label75"
Me.Label75.Size = New System.Drawing.Size(136, 16)
Me.Label75.TabIndex = 91
Me.Label75.Text = "Reference ToolOffset 2"
'
'tulPotNumber
'
Me.tulPotNumber.Location = New System.Drawing.Point(160, 136)
Me.tulPotNumber.Name = "tulPotNumber"
Me.tulPotNumber.Size = New System.Drawing.Size(64, 20)
Me.tulPotNumber.TabIndex = 90
Me.tulPotNumber.Text = "0"
'
'Label76
'
Me.Label76.Location = New System.Drawing.Point(16, 136)
Me.Label76.Name = "Label76"
Me.Label76.Size = New System.Drawing.Size(136, 16)
Me.Label76.TabIndex = 89
Me.Label76.Text = "Pot Number"
'
'tulToolGroup
'
Me.tulToolGroup.Location = New System.Drawing.Point(160, 88)
Me.tulToolGroup.Name = "tulToolGroup"
Me.tulToolGroup.Size = New System.Drawing.Size(64, 20)
Me.tulToolGroup.TabIndex = 88
Me.tulToolGroup.Text = "0"
'
'Label77
'
Me.Label77.Location = New System.Drawing.Point(16, 88)
Me.Label77.Name = "Label77"
Me.Label77.Size = New System.Drawing.Size(136, 16)
Me.Label77.TabIndex = 87
Me.Label77.Text = "Tool Group"
'
'tulToolMode
'
Me.tulToolMode.Location = New System.Drawing.Point(160, 112)
Me.tulToolMode.Name = "tulToolMode"
Me.tulToolMode.Size = New System.Drawing.Size(64, 20)
Me.tulToolMode.TabIndex = 86
Me.tulToolMode.Text = "0"
'
'Label78
'
Me.Label78.Location = New System.Drawing.Point(16, 112)
Me.Label78.Name = "Label78"
Me.Label78.Size = New System.Drawing.Size(136, 16)
Me.Label78.TabIndex = 85
Me.Label78.Text = "Tool Mode"
'
'Label79
'
Me.Label79.Location = New System.Drawing.Point(16, 64)
Me.Label79.Name = "Label79"
Me.Label79.Size = New System.Drawing.Size(144, 16)
Me.Label79.TabIndex = 84
Me.Label79.Text = "Cutter R Comp Wear Offset"
'
'tulCutterRCompWearOffset
'
Me.tulCutterRCompWearOffset.Location = New System.Drawing.Point(160, 64)
Me.tulCutterRCompWearOffset.Name = "tulCutterRCompWearOffset"
Me.tulCutterRCompWearOffset.Size = New System.Drawing.Size(64, 20)
Me.tulCutterRCompWearOffset.TabIndex = 81
Me.tulCutterRCompWearOffset.Text = "0"
'
'Label80
'
Me.Label80.Location = New System.Drawing.Point(16, 40)
Me.Label80.Name = "Label80"
Me.Label80.Size = New System.Drawing.Size(136, 16)
Me.Label80.TabIndex = 82
Me.Label80.Text = "Cutter R Comp Offset"
'
'tulCutterRCompOffset
'
Me.tulCutterRCompOffset.Location = New System.Drawing.Point(160, 40)
Me.tulCutterRCompOffset.Name = "tulCutterRCompOffset"
Me.tulCutterRCompOffset.Size = New System.Drawing.Size(64, 20)
Me.tulCutterRCompOffset.TabIndex = 79
Me.tulCutterRCompOffset.Text = "0"
'
'tab_axis
'
Me.tab_axis.Controls.Add(Me.txt_RelativeActualPositionProgramCoord)
Me.tab_axis.Controls.Add(Me.Label234)
Me.tab_axis.Controls.Add(Me.Label206)
Me.tab_axis.Controls.Add(Me.axisSetDataUnit)
Me.tab_axis.Controls.Add(Me.axisDataUnit)
Me.tab_axis.Controls.Add(Me.AxisTimerStop)
Me.tab_axis.Controls.Add(Me.axisTimerStart)
Me.tab_axis.Controls.Add(Me.axisUpdateButton)
Me.tab_axis.Controls.Add(Me.maxFeedrateOverride)
Me.tab_axis.Controls.Add(Me.Label26)
Me.tab_axis.Controls.Add(Me.feedrateType)
Me.tab_axis.Controls.Add(Me.Label25)
Me.tab_axis.Controls.Add(Me.feedrateOverride)
Me.tab_axis.Controls.Add(Me.Label24)
Me.tab_axis.Controls.Add(Me.feedHold)
Me.tab_axis.Controls.Add(Me.Label23)
Me.tab_axis.Controls.Add(Me.axisType)
Me.tab_axis.Controls.Add(Me.Label22)
Me.tab_axis.Controls.Add(Me.axisName)
Me.tab_axis.Controls.Add(Me.Label21)
Me.tab_axis.Controls.Add(Me.targetPosition)
Me.tab_axis.Controls.Add(Me.Label20)
Me.tab_axis.Controls.Add(Me.distanceTarget)
Me.tab_axis.Controls.Add(Me.Label19)
Me.tab_axis.Controls.Add(Me.commandFeedRate)
Me.tab_axis.Controls.Add(Me.Label18)
Me.tab_axis.Controls.Add(Me.axisLoad)
Me.tab_axis.Controls.Add(Me.Label17)
Me.tab_axis.Controls.Add(Me.apProgramCoord)
Me.tab_axis.Controls.Add(Me.Label16)
Me.tab_axis.Controls.Add(Me.apMachineCoord)
Me.tab_axis.Controls.Add(Me.Label15)
Me.tab_axis.Controls.Add(Me.apEncoderCoord)
Me.tab_axis.Controls.Add(Me.Label14)
Me.tab_axis.Controls.Add(Me.actualFeedrate)
Me.tab_axis.Controls.Add(Me.Label13)
Me.tab_axis.Controls.Add(Me.feedCommandOrderCombo)
Me.tab_axis.Controls.Add(Me.Label12)
Me.tab_axis.Controls.Add(Me.feedTypeCombo)
Me.tab_axis.Controls.Add(Me.Label11)
Me.tab_axis.Controls.Add(Me.axisCombo)
Me.tab_axis.Controls.Add(Me.Label10)
Me.tab_axis.Controls.Add(Me.Panel4)
Me.tab_axis.Location = New System.Drawing.Point(4, 22)
Me.tab_axis.Name = "tab_axis"
Me.tab_axis.Size = New System.Drawing.Size(776, 446)
Me.tab_axis.TabIndex = 1
Me.tab_axis.Text = "Axis"
'
'txt_RelativeActualPositionProgramCoord
'
Me.txt_RelativeActualPositionProgramCoord.BackColor = System.Drawing.SystemColors.Control
Me.txt_RelativeActualPositionProgramCoord.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.txt_RelativeActualPositionProgramCoord.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.txt_RelativeActualPositionProgramCoord.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.txt_RelativeActualPositionProgramCoord.Location = New System.Drawing.Point(600, 264)
Me.txt_RelativeActualPositionProgramCoord.Name = "txt_RelativeActualPositionProgramCoord"
Me.txt_RelativeActualPositionProgramCoord.Size = New System.Drawing.Size(128, 16)
Me.txt_RelativeActualPositionProgramCoord.TabIndex = 55
Me.txt_RelativeActualPositionProgramCoord.Text = ""
'
'Label234
'
Me.Label234.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label234.Location = New System.Drawing.Point(432, 264)
Me.Label234.Name = "Label234"
Me.Label234.Size = New System.Drawing.Size(152, 32)
Me.Label234.TabIndex = 54
Me.Label234.Text = "Relative Actual Position Program Coord"
'
'Label206
'
Me.Label206.Location = New System.Drawing.Point(8, 64)
Me.Label206.Name = "Label206"
Me.Label206.Size = New System.Drawing.Size(56, 23)
Me.Label206.TabIndex = 53
Me.Label206.Text = "Data Unit"
'
'axisSetDataUnit
'
Me.axisSetDataUnit.Location = New System.Drawing.Point(168, 56)
Me.axisSetDataUnit.Name = "axisSetDataUnit"
Me.axisSetDataUnit.TabIndex = 52
Me.axisSetDataUnit.Text = "Set"
'
'axisDataUnit
'
Me.axisDataUnit.Location = New System.Drawing.Point(72, 56)
Me.axisDataUnit.Name = "axisDataUnit"
Me.axisDataUnit.Size = New System.Drawing.Size(88, 20)
Me.axisDataUnit.TabIndex = 51
'
'AxisTimerStop
'
Me.AxisTimerStop.Location = New System.Drawing.Point(488, 56)
Me.AxisTimerStop.Name = "AxisTimerStop"
Me.AxisTimerStop.Size = New System.Drawing.Size(104, 24)
Me.AxisTimerStop.TabIndex = 50
Me.AxisTimerStop.Text = "Stop"
'
'axisTimerStart
'
Me.axisTimerStart.Location = New System.Drawing.Point(368, 56)
Me.axisTimerStart.Name = "axisTimerStart"
Me.axisTimerStart.Size = New System.Drawing.Size(104, 24)
Me.axisTimerStart.TabIndex = 49
Me.axisTimerStart.Text = "Start"
'
'axisUpdateButton
'
Me.axisUpdateButton.Location = New System.Drawing.Point(248, 56)
Me.axisUpdateButton.Name = "axisUpdateButton"
Me.axisUpdateButton.Size = New System.Drawing.Size(104, 24)
Me.axisUpdateButton.TabIndex = 48
Me.axisUpdateButton.Text = "Update"
'
'maxFeedrateOverride
'
Me.maxFeedrateOverride.BackColor = System.Drawing.SystemColors.Control
Me.maxFeedrateOverride.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.maxFeedrateOverride.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.maxFeedrateOverride.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.maxFeedrateOverride.Location = New System.Drawing.Point(600, 232)
Me.maxFeedrateOverride.Name = "maxFeedrateOverride"
Me.maxFeedrateOverride.Size = New System.Drawing.Size(128, 16)
Me.maxFeedrateOverride.TabIndex = 47
Me.maxFeedrateOverride.Text = ""
'
'Label26
'
Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label26.Location = New System.Drawing.Point(432, 232)
Me.Label26.Name = "Label26"
Me.Label26.Size = New System.Drawing.Size(152, 16)
Me.Label26.TabIndex = 46
Me.Label26.Text = "Max Feedrate Override :"
'
'feedrateType
'
Me.feedrateType.BackColor = System.Drawing.SystemColors.Control
Me.feedrateType.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.feedrateType.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.feedrateType.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.feedrateType.Location = New System.Drawing.Point(600, 208)
Me.feedrateType.Name = "feedrateType"
Me.feedrateType.Size = New System.Drawing.Size(128, 16)
Me.feedrateType.TabIndex = 45
Me.feedrateType.Text = ""
'
'Label25
'
Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label25.Location = New System.Drawing.Point(432, 208)
Me.Label25.Name = "Label25"
Me.Label25.Size = New System.Drawing.Size(152, 16)
Me.Label25.TabIndex = 44
Me.Label25.Text = "Feedrate Type :"
'
'feedrateOverride
'
Me.feedrateOverride.BackColor = System.Drawing.SystemColors.Control
Me.feedrateOverride.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.feedrateOverride.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.feedrateOverride.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.feedrateOverride.Location = New System.Drawing.Point(600, 184)
Me.feedrateOverride.Name = "feedrateOverride"
Me.feedrateOverride.Size = New System.Drawing.Size(128, 16)
Me.feedrateOverride.TabIndex = 43
Me.feedrateOverride.Text = ""
'
'Label24
'
Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label24.Location = New System.Drawing.Point(432, 184)
Me.Label24.Name = "Label24"
Me.Label24.Size = New System.Drawing.Size(152, 16)
Me.Label24.TabIndex = 42
Me.Label24.Text = "Feedrate Override :"
'
'feedHold
'
Me.feedHold.BackColor = System.Drawing.SystemColors.Control
Me.feedHold.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.feedHold.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.feedHold.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.feedHold.Location = New System.Drawing.Point(600, 160)
Me.feedHold.Name = "feedHold"
Me.feedHold.Size = New System.Drawing.Size(128, 16)
Me.feedHold.TabIndex = 41
Me.feedHold.Text = ""
'
'Label23
'
Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label23.Location = New System.Drawing.Point(432, 160)
Me.Label23.Name = "Label23"
Me.Label23.Size = New System.Drawing.Size(152, 16)
Me.Label23.TabIndex = 40
Me.Label23.Text = "Feed Hold :"
'
'axisType
'
Me.axisType.BackColor = System.Drawing.SystemColors.Control
Me.axisType.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.axisType.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.axisType.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.axisType.Location = New System.Drawing.Point(600, 136)
Me.axisType.Name = "axisType"
Me.axisType.Size = New System.Drawing.Size(128, 16)
Me.axisType.TabIndex = 39
Me.axisType.Text = ""
'
'Label22
'
Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label22.Location = New System.Drawing.Point(432, 136)
Me.Label22.Name = "Label22"
Me.Label22.Size = New System.Drawing.Size(152, 16)
Me.Label22.TabIndex = 38
Me.Label22.Text = "Axis Type :"
'
'axisName
'
Me.axisName.BackColor = System.Drawing.SystemColors.Control
Me.axisName.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.axisName.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.axisName.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.axisName.Location = New System.Drawing.Point(600, 112)
Me.axisName.Name = "axisName"
Me.axisName.Size = New System.Drawing.Size(128, 16)
Me.axisName.TabIndex = 37
Me.axisName.Text = ""
'
'Label21
'
Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label21.Location = New System.Drawing.Point(432, 112)
Me.Label21.Name = "Label21"
Me.Label21.Size = New System.Drawing.Size(152, 16)
Me.Label21.TabIndex = 36
Me.Label21.Text = "Axis Name :"
'
'targetPosition
'
Me.targetPosition.BackColor = System.Drawing.SystemColors.Control
Me.targetPosition.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.targetPosition.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.targetPosition.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.targetPosition.Location = New System.Drawing.Point(256, 336)
Me.targetPosition.Name = "targetPosition"
Me.targetPosition.Size = New System.Drawing.Size(160, 24)
Me.targetPosition.TabIndex = 35
Me.targetPosition.Text = "0.00"
'
'Label20
'
Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label20.Location = New System.Drawing.Point(16, 336)
Me.Label20.Name = "Label20"
Me.Label20.Size = New System.Drawing.Size(208, 16)
Me.Label20.TabIndex = 34
Me.Label20.Text = "Target Position :"
'
'distanceTarget
'
Me.distanceTarget.BackColor = System.Drawing.SystemColors.Control
Me.distanceTarget.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.distanceTarget.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.distanceTarget.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.distanceTarget.Location = New System.Drawing.Point(256, 304)
Me.distanceTarget.Name = "distanceTarget"
Me.distanceTarget.Size = New System.Drawing.Size(160, 24)
Me.distanceTarget.TabIndex = 33
Me.distanceTarget.Text = "0.00"
'
'Label19
'
Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label19.Location = New System.Drawing.Point(16, 304)
Me.Label19.Name = "Label19"
Me.Label19.Size = New System.Drawing.Size(208, 16)
Me.Label19.TabIndex = 32
Me.Label19.Text = "Distance to Target Position :"
'
'commandFeedRate
'
Me.commandFeedRate.BackColor = System.Drawing.SystemColors.Control
Me.commandFeedRate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.commandFeedRate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.commandFeedRate.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.commandFeedRate.Location = New System.Drawing.Point(256, 272)
Me.commandFeedRate.Name = "commandFeedRate"
Me.commandFeedRate.Size = New System.Drawing.Size(160, 24)
Me.commandFeedRate.TabIndex = 31
Me.commandFeedRate.Text = "0.00"
'
'Label18
'
Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label18.Location = New System.Drawing.Point(16, 272)
Me.Label18.Name = "Label18"
Me.Label18.Size = New System.Drawing.Size(144, 16)
Me.Label18.TabIndex = 30
Me.Label18.Text = "Command FeedRate:"
'
'axisLoad
'
Me.axisLoad.BackColor = System.Drawing.SystemColors.Control
Me.axisLoad.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.axisLoad.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.axisLoad.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.axisLoad.Location = New System.Drawing.Point(256, 240)
Me.axisLoad.Name = "axisLoad"
Me.axisLoad.Size = New System.Drawing.Size(160, 24)
Me.axisLoad.TabIndex = 29
Me.axisLoad.Text = "0.00"
'
'Label17
'
Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label17.Location = New System.Drawing.Point(16, 240)
Me.Label17.Name = "Label17"
Me.Label17.Size = New System.Drawing.Size(96, 16)
Me.Label17.TabIndex = 28
Me.Label17.Text = "Axis Load:"
'
'apProgramCoord
'
Me.apProgramCoord.BackColor = System.Drawing.SystemColors.Control
Me.apProgramCoord.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.apProgramCoord.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.apProgramCoord.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.apProgramCoord.Location = New System.Drawing.Point(256, 208)
Me.apProgramCoord.Name = "apProgramCoord"
Me.apProgramCoord.Size = New System.Drawing.Size(160, 24)
Me.apProgramCoord.TabIndex = 27
Me.apProgramCoord.Text = "0.00"
'
'Label16
'
Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label16.Location = New System.Drawing.Point(16, 208)
Me.Label16.Name = "Label16"
Me.Label16.Size = New System.Drawing.Size(208, 16)
Me.Label16.TabIndex = 26
Me.Label16.Text = "Actual Position Program Coordinates:"
'
'apMachineCoord
'
Me.apMachineCoord.BackColor = System.Drawing.SystemColors.Control
Me.apMachineCoord.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.apMachineCoord.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.apMachineCoord.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.apMachineCoord.Location = New System.Drawing.Point(256, 176)
Me.apMachineCoord.Name = "apMachineCoord"
Me.apMachineCoord.Size = New System.Drawing.Size(160, 24)
Me.apMachineCoord.TabIndex = 25
Me.apMachineCoord.Text = "0.00"
'
'Label15
'
Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label15.Location = New System.Drawing.Point(16, 176)
Me.Label15.Name = "Label15"
Me.Label15.Size = New System.Drawing.Size(208, 16)
Me.Label15.TabIndex = 24
Me.Label15.Text = "Actual Position Machine Coordinates:"
'
'apEncoderCoord
'
Me.apEncoderCoord.BackColor = System.Drawing.SystemColors.Control
Me.apEncoderCoord.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.apEncoderCoord.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.apEncoderCoord.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.apEncoderCoord.Location = New System.Drawing.Point(256, 144)
Me.apEncoderCoord.Name = "apEncoderCoord"
Me.apEncoderCoord.Size = New System.Drawing.Size(160, 24)
Me.apEncoderCoord.TabIndex = 23
Me.apEncoderCoord.Text = "0.00"
'
'Label14
'
Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label14.Location = New System.Drawing.Point(16, 144)
Me.Label14.Name = "Label14"
Me.Label14.Size = New System.Drawing.Size(208, 16)
Me.Label14.TabIndex = 22
Me.Label14.Text = "Actual Position Encoder Coordinates:"
'
'actualFeedrate
'
Me.actualFeedrate.BackColor = System.Drawing.SystemColors.Control
Me.actualFeedrate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.actualFeedrate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.actualFeedrate.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.actualFeedrate.Location = New System.Drawing.Point(256, 112)
Me.actualFeedrate.Name = "actualFeedrate"
Me.actualFeedrate.Size = New System.Drawing.Size(160, 24)
Me.actualFeedrate.TabIndex = 21
Me.actualFeedrate.Text = "0.00"
'
'Label13
'
Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Label13.Location = New System.Drawing.Point(440, 16)
Me.Label13.Name = "Label13"
Me.Label13.Size = New System.Drawing.Size(144, 16)
Me.Label13.TabIndex = 18
Me.Label13.Text = "FeedRate Command Order"
'
'feedCommandOrderCombo
'
Me.feedCommandOrderCombo.Location = New System.Drawing.Point(584, 16)
Me.feedCommandOrderCombo.Name = "feedCommandOrderCombo"
Me.feedCommandOrderCombo.Size = New System.Drawing.Size(120, 20)
Me.feedCommandOrderCombo.TabIndex = 17
'
'Label12
'
Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Label12.Location = New System.Drawing.Point(208, 16)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(88, 16)
Me.Label12.TabIndex = 16
Me.Label12.Text = "FeedRate Type"
'
'feedTypeCombo
'
Me.feedTypeCombo.Location = New System.Drawing.Point(296, 16)
Me.feedTypeCombo.Name = "feedTypeCombo"
Me.feedTypeCombo.Size = New System.Drawing.Size(120, 20)
Me.feedTypeCombo.TabIndex = 15
'
'Label11
'
Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Label11.Location = New System.Drawing.Point(16, 16)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(40, 16)
Me.Label11.TabIndex = 14
Me.Label11.Text = "Axis"
'
'axisCombo
'
Me.axisCombo.Location = New System.Drawing.Point(56, 16)
Me.axisCombo.Name = "axisCombo"
Me.axisCombo.Size = New System.Drawing.Size(120, 20)
Me.axisCombo.TabIndex = 13
'
'Label10
'
Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label10.Location = New System.Drawing.Point(16, 112)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(96, 16)
Me.Label10.TabIndex = 12
Me.Label10.Text = "Actual FeedRate:"
'
'Panel4
'
Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel4.Location = New System.Drawing.Point(8, 8)
Me.Panel4.Name = "Panel4"
Me.Panel4.Size = New System.Drawing.Size(736, 40)
Me.Panel4.TabIndex = 19
'
'tab_axis2
'
Me.tab_axis2.Controls.Add(Me.cmdAxis2DataUnit)
Me.tab_axis2.Controls.Add(Me.cboAxis2DataUnit)
Me.tab_axis2.Controls.Add(Me.GroupBox11)
Me.tab_axis2.Location = New System.Drawing.Point(4, 22)
Me.tab_axis2.Name = "tab_axis2"
Me.tab_axis2.Size = New System.Drawing.Size(776, 446)
Me.tab_axis2.TabIndex = 18
Me.tab_axis2.Text = "Axis 2"
'
'cmdAxis2DataUnit
'
Me.cmdAxis2DataUnit.Location = New System.Drawing.Point(8, 16)
Me.cmdAxis2DataUnit.Name = "cmdAxis2DataUnit"
Me.cmdAxis2DataUnit.Size = New System.Drawing.Size(96, 24)
Me.cmdAxis2DataUnit.TabIndex = 298
Me.cmdAxis2DataUnit.Text = "Set Data Unit"
'
'cboAxis2DataUnit
'
Me.cboAxis2DataUnit.ItemHeight = 16
Me.cboAxis2DataUnit.Location = New System.Drawing.Point(112, 16)
Me.cboAxis2DataUnit.Name = "cboAxis2DataUnit"
Me.cboAxis2DataUnit.Size = New System.Drawing.Size(224, 20)
Me.cboAxis2DataUnit.TabIndex = 297
'
'GroupBox11
'
Me.GroupBox11.Controls.Add(Me.Label291)
Me.GroupBox11.Controls.Add(Me.cboUserParameterVariableLimitCoordinate)
Me.GroupBox11.Controls.Add(Me.txtUserParameterLimitInput)
Me.GroupBox11.Controls.Add(Me.txtUserParameterLimit)
Me.GroupBox11.Controls.Add(Me.Label157)
Me.GroupBox11.Controls.Add(Me.cmdUserParameterVariableLimitAdd)
Me.GroupBox11.Controls.Add(Me.cmdUserParameterVariableLimitSet)
Me.GroupBox11.Controls.Add(Me.cmdUserParameterVariableLimitGet)
Me.GroupBox11.Controls.Add(Me.Label165)
Me.GroupBox11.Controls.Add(Me.cboUserParameterVariableLimitAxis)
Me.GroupBox11.Location = New System.Drawing.Point(8, 48)
Me.GroupBox11.Name = "GroupBox11"
Me.GroupBox11.Size = New System.Drawing.Size(752, 104)
Me.GroupBox11.TabIndex = 7
Me.GroupBox11.TabStop = false
Me.GroupBox11.Text = "Variable Limit"
'
'Label291
'
Me.Label291.Location = New System.Drawing.Point(312, 24)
Me.Label291.Name = "Label291"
Me.Label291.Size = New System.Drawing.Size(144, 24)
Me.Label291.TabIndex = 15
Me.Label291.Text = "Variable Limit Coordinate"
'
'cboUserParameterVariableLimitCoordinate
'
Me.cboUserParameterVariableLimitCoordinate.Location = New System.Drawing.Point(472, 24)
Me.cboUserParameterVariableLimitCoordinate.Name = "cboUserParameterVariableLimitCoordinate"
Me.cboUserParameterVariableLimitCoordinate.Size = New System.Drawing.Size(216, 20)
Me.cboUserParameterVariableLimitCoordinate.TabIndex = 14
'
'txtUserParameterLimitInput
'
Me.txtUserParameterLimitInput.ForeColor = System.Drawing.Color.Red
Me.txtUserParameterLimitInput.Location = New System.Drawing.Point(320, 56)
Me.txtUserParameterLimitInput.Name = "txtUserParameterLimitInput"
Me.txtUserParameterLimitInput.Size = New System.Drawing.Size(96, 20)
Me.txtUserParameterLimitInput.TabIndex = 13
Me.txtUserParameterLimitInput.Text = "0.0"
'
'txtUserParameterLimit
'
Me.txtUserParameterLimit.Location = New System.Drawing.Point(200, 56)
Me.txtUserParameterLimit.Name = "txtUserParameterLimit"
Me.txtUserParameterLimit.ReadOnly = true
Me.txtUserParameterLimit.Size = New System.Drawing.Size(104, 20)
Me.txtUserParameterLimit.TabIndex = 12
Me.txtUserParameterLimit.Text = "0.0"
'
'Label157
'
Me.Label157.Location = New System.Drawing.Point(8, 56)
Me.Label157.Name = "Label157"
Me.Label157.Size = New System.Drawing.Size(176, 32)
Me.Label157.TabIndex = 8
Me.Label157.Text = "User Parameter Variable Limit"
'
'cmdUserParameterVariableLimitAdd
'
Me.cmdUserParameterVariableLimitAdd.Location = New System.Drawing.Point(592, 56)
Me.cmdUserParameterVariableLimitAdd.Name = "cmdUserParameterVariableLimitAdd"
Me.cmdUserParameterVariableLimitAdd.Size = New System.Drawing.Size(64, 32)
Me.cmdUserParameterVariableLimitAdd.TabIndex = 10
Me.cmdUserParameterVariableLimitAdd.Text = "Add"
'
'cmdUserParameterVariableLimitSet
'
Me.cmdUserParameterVariableLimitSet.Location = New System.Drawing.Point(512, 56)
Me.cmdUserParameterVariableLimitSet.Name = "cmdUserParameterVariableLimitSet"
Me.cmdUserParameterVariableLimitSet.Size = New System.Drawing.Size(64, 32)
Me.cmdUserParameterVariableLimitSet.TabIndex = 9
Me.cmdUserParameterVariableLimitSet.Text = "Set"
'
'cmdUserParameterVariableLimitGet
'
Me.cmdUserParameterVariableLimitGet.Location = New System.Drawing.Point(432, 56)
Me.cmdUserParameterVariableLimitGet.Name = "cmdUserParameterVariableLimitGet"
Me.cmdUserParameterVariableLimitGet.Size = New System.Drawing.Size(64, 32)
Me.cmdUserParameterVariableLimitGet.TabIndex = 11
Me.cmdUserParameterVariableLimitGet.Text = "Get"
'
'Label165
'
Me.Label165.Location = New System.Drawing.Point(8, 24)
Me.Label165.Name = "Label165"
Me.Label165.Size = New System.Drawing.Size(64, 24)
Me.Label165.TabIndex = 1
Me.Label165.Text = "Axis Index"
'
'cboUserParameterVariableLimitAxis
'
Me.cboUserParameterVariableLimitAxis.Location = New System.Drawing.Point(80, 24)
Me.cboUserParameterVariableLimitAxis.Name = "cboUserParameterVariableLimitAxis"
Me.cboUserParameterVariableLimitAxis.Size = New System.Drawing.Size(184, 20)
Me.cboUserParameterVariableLimitAxis.TabIndex = 0
'
'tab_spec
'
Me.tab_spec.Controls.Add(Me.GroupBox10)
Me.tab_spec.Controls.Add(Me.txtMachineSerial)
Me.tab_spec.Controls.Add(Me.txtMachineName)
Me.tab_spec.Controls.Add(Me.Label144)
Me.tab_spec.Controls.Add(Me.Label143)
Me.tab_spec.Controls.Add(Me.Label66)
Me.tab_spec.Controls.Add(Me.specCombo)
Me.tab_spec.Controls.Add(Me.specUpdateButton)
Me.tab_spec.Controls.Add(Me.specCode)
Me.tab_spec.Controls.Add(Me.Label63)
Me.tab_spec.Location = New System.Drawing.Point(4, 22)
Me.tab_spec.Name = "tab_spec"
Me.tab_spec.Size = New System.Drawing.Size(776, 446)
Me.tab_spec.TabIndex = 7
Me.tab_spec.Text = "Spec"
'
'GroupBox10
'
Me.GroupBox10.Controls.Add(Me.cmdGetBSpecCode)
Me.GroupBox10.Controls.Add(Me.txtSpecCode)
Me.GroupBox10.Controls.Add(Me.Label170)
Me.GroupBox10.Controls.Add(Me.txtSpecCodeBit)
Me.GroupBox10.Controls.Add(Me.Label169)
Me.GroupBox10.Controls.Add(Me.txtSpecCodeIndex)
Me.GroupBox10.Controls.Add(Me.cmdGetSpecCode)
Me.GroupBox10.Location = New System.Drawing.Point(536, 24)
Me.GroupBox10.Name = "GroupBox10"
Me.GroupBox10.Size = New System.Drawing.Size(224, 176)
Me.GroupBox10.TabIndex = 96
Me.GroupBox10.TabStop = false
Me.GroupBox10.Text = "General Spec Code"
'
'cmdGetBSpecCode
'
Me.cmdGetBSpecCode.Location = New System.Drawing.Point(16, 64)
Me.cmdGetBSpecCode.Name = "cmdGetBSpecCode"
Me.cmdGetBSpecCode.Size = New System.Drawing.Size(152, 24)
Me.cmdGetBSpecCode.TabIndex = 102
Me.cmdGetBSpecCode.Text = "Get B Spec Code"
'
'txtSpecCode
'
Me.txtSpecCode.Location = New System.Drawing.Point(176, 48)
Me.txtSpecCode.Name = "txtSpecCode"
Me.txtSpecCode.ReadOnly = true
Me.txtSpecCode.Size = New System.Drawing.Size(32, 20)
Me.txtSpecCode.TabIndex = 101
Me.txtSpecCode.Text = "0"
'
'Label170
'
Me.Label170.Location = New System.Drawing.Point(16, 144)
Me.Label170.Name = "Label170"
Me.Label170.Size = New System.Drawing.Size(136, 24)
Me.Label170.TabIndex = 100
Me.Label170.Text = "Spec Code Bit Number"
'
'txtSpecCodeBit
'
Me.txtSpecCodeBit.Location = New System.Drawing.Point(176, 144)
Me.txtSpecCodeBit.Name = "txtSpecCodeBit"
Me.txtSpecCodeBit.Size = New System.Drawing.Size(32, 20)
Me.txtSpecCodeBit.TabIndex = 99
Me.txtSpecCodeBit.Text = "1"
'
'Label169
'
Me.Label169.Location = New System.Drawing.Point(16, 104)
Me.Label169.Name = "Label169"
Me.Label169.Size = New System.Drawing.Size(144, 24)
Me.Label169.TabIndex = 98
Me.Label169.Text = "Spec Code Index"
'
'txtSpecCodeIndex
'
Me.txtSpecCodeIndex.Location = New System.Drawing.Point(176, 104)
Me.txtSpecCodeIndex.Name = "txtSpecCodeIndex"
Me.txtSpecCodeIndex.Size = New System.Drawing.Size(32, 20)
Me.txtSpecCodeIndex.TabIndex = 97
Me.txtSpecCodeIndex.Text = "1"
'
'cmdGetSpecCode
'
Me.cmdGetSpecCode.Location = New System.Drawing.Point(16, 24)
Me.cmdGetSpecCode.Name = "cmdGetSpecCode"
Me.cmdGetSpecCode.Size = New System.Drawing.Size(152, 24)
Me.cmdGetSpecCode.TabIndex = 96
Me.cmdGetSpecCode.Text = "Get Spec Code"
'
'txtMachineSerial
'
Me.txtMachineSerial.BackColor = System.Drawing.SystemColors.Control
Me.txtMachineSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtMachineSerial.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.txtMachineSerial.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.txtMachineSerial.Location = New System.Drawing.Point(232, 152)
Me.txtMachineSerial.Name = "txtMachineSerial"
Me.txtMachineSerial.Size = New System.Drawing.Size(272, 31)
Me.txtMachineSerial.TabIndex = 89
Me.txtMachineSerial.Text = ""
'
'txtMachineName
'
Me.txtMachineName.BackColor = System.Drawing.SystemColors.Control
Me.txtMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.txtMachineName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.txtMachineName.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.txtMachineName.Location = New System.Drawing.Point(232, 112)
Me.txtMachineName.Name = "txtMachineName"
Me.txtMachineName.Size = New System.Drawing.Size(272, 31)
Me.txtMachineName.TabIndex = 88
Me.txtMachineName.Text = ""
'
'Label144
'
Me.Label144.Location = New System.Drawing.Point(32, 160)
Me.Label144.Name = "Label144"
Me.Label144.Size = New System.Drawing.Size(184, 16)
Me.Label144.TabIndex = 87
Me.Label144.Text = "Machine Serial:"
'
'Label143
'
Me.Label143.Location = New System.Drawing.Point(32, 120)
Me.Label143.Name = "Label143"
Me.Label143.Size = New System.Drawing.Size(184, 16)
Me.Label143.TabIndex = 86
Me.Label143.Text = "Machine Name:"
'
'Label66
'
Me.Label66.Location = New System.Drawing.Point(32, 48)
Me.Label66.Name = "Label66"
Me.Label66.Size = New System.Drawing.Size(136, 16)
Me.Label66.TabIndex = 85
Me.Label66.Text = "Option Spec Code"
'
'specCombo
'
Me.specCombo.Location = New System.Drawing.Point(232, 48)
Me.specCombo.Name = "specCombo"
Me.specCombo.Size = New System.Drawing.Size(152, 20)
Me.specCombo.TabIndex = 84
'
'specUpdateButton
'
Me.specUpdateButton.Location = New System.Drawing.Point(32, 8)
Me.specUpdateButton.Name = "specUpdateButton"
Me.specUpdateButton.Size = New System.Drawing.Size(72, 24)
Me.specUpdateButton.TabIndex = 83
Me.specUpdateButton.Text = "Update"
'
'specCode
'
Me.specCode.Location = New System.Drawing.Point(232, 80)
Me.specCode.Name = "specCode"
Me.specCode.Size = New System.Drawing.Size(176, 20)
Me.specCode.TabIndex = 82
Me.specCode.Text = ""
'
'Label63
'
Me.Label63.Location = New System.Drawing.Point(32, 80)
Me.Label63.Name = "Label63"
Me.Label63.Size = New System.Drawing.Size(136, 16)
Me.Label63.TabIndex = 81
Me.Label63.Text = "Option Spec Code"
'
'tab_MacManMachiningReport
'
Me.tab_MacManMachiningReport.Controls.Add(Me.grdMMMachiningReports)
Me.tab_MacManMachiningReport.Controls.Add(Me.PictureBox1)
Me.tab_MacManMachiningReport.Controls.Add(Me.txtMachiningReport_NoOfWork)
Me.tab_MacManMachiningReport.Controls.Add(Me.Label156)
Me.tab_MacManMachiningReport.Controls.Add(Me.MacreportTime)
Me.tab_MacManMachiningReport.Controls.Add(Me.Label245)
Me.tab_MacManMachiningReport.Controls.Add(Me.txtto)
Me.tab_MacManMachiningReport.Controls.Add(Me.Label158)
Me.tab_MacManMachiningReport.Controls.Add(Me.txtFrom)
Me.tab_MacManMachiningReport.Controls.Add(Me.Label159)
Me.tab_MacManMachiningReport.Controls.Add(Me.macreport_result)
Me.tab_MacManMachiningReport.Controls.Add(Me.Label160)
Me.tab_MacManMachiningReport.Controls.Add(Me.Cmb_rptPeriod)
Me.tab_MacManMachiningReport.Controls.Add(Me.MacReport_programname)
Me.tab_MacManMachiningReport.Controls.Add(Me.Label161)
Me.tab_MacManMachiningReport.Controls.Add(Me.Macreport_filename)
Me.tab_MacManMachiningReport.Controls.Add(Me.Label162)
Me.tab_MacManMachiningReport.Controls.Add(Me.MacReport_count)
Me.tab_MacManMachiningReport.Controls.Add(Me.Label163)
Me.tab_MacManMachiningReport.Controls.Add(Me.macReportUpdateButton)
Me.tab_MacManMachiningReport.Controls.Add(Me.MacReport_Index)
Me.tab_MacManMachiningReport.Controls.Add(Me.Label164)
Me.tab_MacManMachiningReport.Controls.Add(Me.macreport_Operatingtime)
Me.tab_MacManMachiningReport.Controls.Add(Me.Label225)
Me.tab_MacManMachiningReport.Controls.Add(Me.macreport_Runningtime)
Me.tab_MacManMachiningReport.Controls.Add(Me.Label226)
Me.tab_MacManMachiningReport.Controls.Add(Me.Macreportdate)
Me.tab_MacManMachiningReport.Controls.Add(Me.Label227)
Me.tab_MacManMachiningReport.Controls.Add(Me.macreport_maxcount)
Me.tab_MacManMachiningReport.Controls.Add(Me.Label228)
Me.tab_MacManMachiningReport.Controls.Add(Me.macreport_cuttingtime)
Me.tab_MacManMachiningReport.Controls.Add(Me.Label229)
Me.tab_MacManMachiningReport.Location = New System.Drawing.Point(4, 22)
Me.tab_MacManMachiningReport.Name = "tab_MacManMachiningReport"
Me.tab_MacManMachiningReport.Size = New System.Drawing.Size(776, 446)
Me.tab_MacManMachiningReport.TabIndex = 15
Me.tab_MacManMachiningReport.Text = "MacMan Machining Reports"
'
'grdMMMachiningReports
'
Me.grdMMMachiningReports.DataMember = ""
Me.grdMMMachiningReports.HeaderForeColor = System.Drawing.SystemColors.ControlText
Me.grdMMMachiningReports.Location = New System.Drawing.Point(12, 176)
Me.grdMMMachiningReports.Name = "grdMMMachiningReports"
Me.grdMMMachiningReports.PreferredColumnWidth = 80
Me.grdMMMachiningReports.ReadOnly = true
Me.grdMMMachiningReports.Size = New System.Drawing.Size(752, 248)
Me.grdMMMachiningReports.TabIndex = 335
'
'PictureBox1
'
Me.PictureBox1.Location = New System.Drawing.Point(500, 136)
Me.PictureBox1.Name = "PictureBox1"
Me.PictureBox1.Size = New System.Drawing.Size(8, 8)
Me.PictureBox1.TabIndex = 334
Me.PictureBox1.TabStop = false
'
'txtMachiningReport_NoOfWork
'
Me.txtMachiningReport_NoOfWork.Location = New System.Drawing.Point(396, 88)
Me.txtMachiningReport_NoOfWork.Name = "txtMachiningReport_NoOfWork"
Me.txtMachiningReport_NoOfWork.ReadOnly = true
Me.txtMachiningReport_NoOfWork.Size = New System.Drawing.Size(88, 20)
Me.txtMachiningReport_NoOfWork.TabIndex = 333
Me.txtMachiningReport_NoOfWork.Text = ""
'
'Label156
'
Me.Label156.Location = New System.Drawing.Point(396, 56)
Me.Label156.Name = "Label156"
Me.Label156.Size = New System.Drawing.Size(88, 16)
Me.Label156.TabIndex = 332
Me.Label156.Text = "No. Of Work"
'
'MacreportTime
'
Me.MacreportTime.Location = New System.Drawing.Point(300, 88)
Me.MacreportTime.Name = "MacreportTime"
Me.MacreportTime.ReadOnly = true
Me.MacreportTime.Size = New System.Drawing.Size(88, 20)
Me.MacreportTime.TabIndex = 328
Me.MacreportTime.Text = ""
'
'Label245
'
Me.Label245.Location = New System.Drawing.Point(292, 56)
Me.Label245.Name = "Label245"
Me.Label245.Size = New System.Drawing.Size(88, 16)
Me.Label245.TabIndex = 327
Me.Label245.Text = "Start Time:"
'
'txtto
'
Me.txtto.Location = New System.Drawing.Point(388, 144)
Me.txtto.Name = "txtto"
Me.txtto.Size = New System.Drawing.Size(64, 20)
Me.txtto.TabIndex = 326
Me.txtto.Text = "2"
'
'Label158
'
Me.Label158.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label158.Location = New System.Drawing.Point(332, 144)
Me.Label158.Name = "Label158"
Me.Label158.Size = New System.Drawing.Size(48, 16)
Me.Label158.TabIndex = 325
Me.Label158.Text = "To"
'
'txtFrom
'
Me.txtFrom.Location = New System.Drawing.Point(236, 144)
Me.txtFrom.Name = "txtFrom"
Me.txtFrom.Size = New System.Drawing.Size(64, 20)
Me.txtFrom.TabIndex = 324
Me.txtFrom.Text = "1"
'
'Label159
'
Me.Label159.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label159.Location = New System.Drawing.Point(180, 144)
Me.Label159.Name = "Label159"
Me.Label159.Size = New System.Drawing.Size(48, 16)
Me.Label159.TabIndex = 323
Me.Label159.Text = "From"
'
'macreport_result
'
Me.macreport_result.Location = New System.Drawing.Point(12, 144)
Me.macreport_result.Name = "macreport_result"
Me.macreport_result.Size = New System.Drawing.Size(72, 24)
Me.macreport_result.TabIndex = 322
Me.macreport_result.Text = "Update"
'
'Label160
'
Me.Label160.Location = New System.Drawing.Point(252, 16)
Me.Label160.Name = "Label160"
Me.Label160.Size = New System.Drawing.Size(72, 16)
Me.Label160.TabIndex = 321
Me.Label160.Text = "Period Time"
'
'Cmb_rptPeriod
'
Me.Cmb_rptPeriod.Location = New System.Drawing.Point(332, 16)
Me.Cmb_rptPeriod.Name = "Cmb_rptPeriod"
Me.Cmb_rptPeriod.Size = New System.Drawing.Size(104, 20)
Me.Cmb_rptPeriod.TabIndex = 320
'
'MacReport_programname
'
Me.MacReport_programname.Location = New System.Drawing.Point(108, 88)
Me.MacReport_programname.Name = "MacReport_programname"
Me.MacReport_programname.ReadOnly = true
Me.MacReport_programname.Size = New System.Drawing.Size(88, 20)
Me.MacReport_programname.TabIndex = 319
Me.MacReport_programname.Text = ""
'
'Label161
'
Me.Label161.Location = New System.Drawing.Point(108, 56)
Me.Label161.Name = "Label161"
Me.Label161.Size = New System.Drawing.Size(88, 24)
Me.Label161.TabIndex = 318
Me.Label161.Text = "Main program name"
'
'Macreport_filename
'
Me.Macreport_filename.Location = New System.Drawing.Point(12, 88)
Me.Macreport_filename.Name = "Macreport_filename"
Me.Macreport_filename.ReadOnly = true
Me.Macreport_filename.Size = New System.Drawing.Size(88, 20)
Me.Macreport_filename.TabIndex = 317
Me.Macreport_filename.Text = ""
'
'Label162
'
Me.Label162.Location = New System.Drawing.Point(12, 56)
Me.Label162.Name = "Label162"
Me.Label162.Size = New System.Drawing.Size(88, 24)
Me.Label162.TabIndex = 316
Me.Label162.Text = "Main program file name"
'
'MacReport_count
'
Me.MacReport_count.Location = New System.Drawing.Point(668, 16)
Me.MacReport_count.Name = "MacReport_count"
Me.MacReport_count.ReadOnly = true
Me.MacReport_count.Size = New System.Drawing.Size(64, 20)
Me.MacReport_count.TabIndex = 315
Me.MacReport_count.Text = ""
'
'Label163
'
Me.Label163.Location = New System.Drawing.Point(612, 16)
Me.Label163.Name = "Label163"
Me.Label163.Size = New System.Drawing.Size(48, 16)
Me.Label163.TabIndex = 314
Me.Label163.Text = "Count"
'
'macReportUpdateButton
'
Me.macReportUpdateButton.Location = New System.Drawing.Point(12, 16)
Me.macReportUpdateButton.Name = "macReportUpdateButton"
Me.macReportUpdateButton.Size = New System.Drawing.Size(72, 24)
Me.macReportUpdateButton.TabIndex = 313
Me.macReportUpdateButton.Text = "Update"
'
'MacReport_Index
'
Me.MacReport_Index.Location = New System.Drawing.Point(180, 16)
Me.MacReport_Index.Name = "MacReport_Index"
Me.MacReport_Index.Size = New System.Drawing.Size(64, 20)
Me.MacReport_Index.TabIndex = 312
Me.MacReport_Index.Text = "1"
'
'Label164
'
Me.Label164.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label164.Location = New System.Drawing.Point(100, 16)
Me.Label164.Name = "Label164"
Me.Label164.Size = New System.Drawing.Size(64, 16)
Me.Label164.TabIndex = 311
Me.Label164.Text = "Index :"
'
'macreport_Operatingtime
'
Me.macreport_Operatingtime.Location = New System.Drawing.Point(580, 88)
Me.macreport_Operatingtime.Name = "macreport_Operatingtime"
Me.macreport_Operatingtime.ReadOnly = true
Me.macreport_Operatingtime.Size = New System.Drawing.Size(88, 20)
Me.macreport_Operatingtime.TabIndex = 310
Me.macreport_Operatingtime.Text = ""
'
'Label225
'
Me.Label225.Location = New System.Drawing.Point(580, 56)
Me.Label225.Name = "Label225"
Me.Label225.Size = New System.Drawing.Size(88, 32)
Me.Label225.TabIndex = 309
Me.Label225.Text = "Operating Time (ms)"
'
'macreport_Runningtime
'
Me.macreport_Runningtime.Location = New System.Drawing.Point(492, 88)
Me.macreport_Runningtime.Name = "macreport_Runningtime"
Me.macreport_Runningtime.ReadOnly = true
Me.macreport_Runningtime.Size = New System.Drawing.Size(80, 20)
Me.macreport_Runningtime.TabIndex = 308
Me.macreport_Runningtime.Text = ""
'
'Label226
'
Me.Label226.Location = New System.Drawing.Point(492, 56)
Me.Label226.Name = "Label226"
Me.Label226.Size = New System.Drawing.Size(88, 32)
Me.Label226.TabIndex = 307
Me.Label226.Text = "Running Time (ms)"
'
'Macreportdate
'
Me.Macreportdate.Location = New System.Drawing.Point(204, 88)
Me.Macreportdate.Name = "Macreportdate"
Me.Macreportdate.ReadOnly = true
Me.Macreportdate.Size = New System.Drawing.Size(88, 20)
Me.Macreportdate.TabIndex = 306
Me.Macreportdate.Text = ""
'
'Label227
'
Me.Label227.Location = New System.Drawing.Point(204, 56)
Me.Label227.Name = "Label227"
Me.Label227.Size = New System.Drawing.Size(80, 16)
Me.Label227.TabIndex = 305
Me.Label227.Text = "Start Date:"
'
'macreport_maxcount
'
Me.macreport_maxcount.Location = New System.Drawing.Point(532, 16)
Me.macreport_maxcount.Name = "macreport_maxcount"
Me.macreport_maxcount.ReadOnly = true
Me.macreport_maxcount.Size = New System.Drawing.Size(64, 20)
Me.macreport_maxcount.TabIndex = 304
Me.macreport_maxcount.Text = ""
'
'Label228
'
Me.Label228.Location = New System.Drawing.Point(444, 16)
Me.Label228.Name = "Label228"
Me.Label228.Size = New System.Drawing.Size(72, 16)
Me.Label228.TabIndex = 303
Me.Label228.Text = "Max Count :"
'
'macreport_cuttingtime
'
Me.macreport_cuttingtime.Location = New System.Drawing.Point(676, 88)
Me.macreport_cuttingtime.Name = "macreport_cuttingtime"
Me.macreport_cuttingtime.ReadOnly = true
Me.macreport_cuttingtime.Size = New System.Drawing.Size(88, 20)
Me.macreport_cuttingtime.TabIndex = 302
Me.macreport_cuttingtime.Text = ""
'
'Label229
'
Me.Label229.Location = New System.Drawing.Point(676, 56)
Me.Label229.Name = "Label229"
Me.Label229.Size = New System.Drawing.Size(88, 32)
Me.Label229.TabIndex = 301
Me.Label229.Text = "Cutting Time (ms)"
'
'Tab_View
'
Me.Tab_View.Controls.Add(Me.Panel12)
Me.Tab_View.Location = New System.Drawing.Point(4, 22)
Me.Tab_View.Name = "Tab_View"
Me.Tab_View.Size = New System.Drawing.Size(776, 446)
Me.Tab_View.TabIndex = 17
Me.Tab_View.Text = "View"
'
'Panel12
'
Me.Panel12.Controls.Add(Me.Label231)
Me.Panel12.Controls.Add(Me.Cmb_ChangeScreen)
Me.Panel12.Controls.Add(Me.cmd_ChangeScreen)
Me.Panel12.Controls.Add(Me.txt_screenname)
Me.Panel12.Controls.Add(Me.Label232)
Me.Panel12.Location = New System.Drawing.Point(8, 8)
Me.Panel12.Name = "Panel12"
Me.Panel12.Size = New System.Drawing.Size(432, 168)
Me.Panel12.TabIndex = 270
'
'Label231
'
Me.Label231.Location = New System.Drawing.Point(16, 80)
Me.Label231.Name = "Label231"
Me.Label231.Size = New System.Drawing.Size(160, 16)
Me.Label231.TabIndex = 274
Me.Label231.Text = "PanelGroupEnum"
'
'Cmb_ChangeScreen
'
Me.Cmb_ChangeScreen.Location = New System.Drawing.Point(192, 80)
Me.Cmb_ChangeScreen.Name = "Cmb_ChangeScreen"
Me.Cmb_ChangeScreen.Size = New System.Drawing.Size(232, 20)
Me.Cmb_ChangeScreen.TabIndex = 273
'
'cmd_ChangeScreen
'
Me.cmd_ChangeScreen.Location = New System.Drawing.Point(192, 24)
Me.cmd_ChangeScreen.Name = "cmd_ChangeScreen"
Me.cmd_ChangeScreen.Size = New System.Drawing.Size(104, 24)
Me.cmd_ChangeScreen.TabIndex = 272
Me.cmd_ChangeScreen.Text = "ChangeScreen"
'
'txt_screenname
'
Me.txt_screenname.Location = New System.Drawing.Point(192, 120)
Me.txt_screenname.Name = "txt_screenname"
Me.txt_screenname.Size = New System.Drawing.Size(232, 20)
Me.txt_screenname.TabIndex = 271
Me.txt_screenname.Text = ""
'
'Label232
'
Me.Label232.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label232.Location = New System.Drawing.Point(16, 120)
Me.Label232.Name = "Label232"
Me.Label232.Size = New System.Drawing.Size(136, 16)
Me.Label232.TabIndex = 270
Me.Label232.Text = "Screen Name"
'
'tab_MacmanOperationHistory
'
Me.tab_MacmanOperationHistory.Controls.Add(Me.mohTo)
Me.tab_MacmanOperationHistory.Controls.Add(Me.Label131)
Me.tab_MacmanOperationHistory.Controls.Add(Me.mohFrom)
Me.tab_MacmanOperationHistory.Controls.Add(Me.Label132)
Me.tab_MacmanOperationHistory.Controls.Add(Me.mohResults)
Me.tab_MacmanOperationHistory.Controls.Add(Me.mohButtonResults)
Me.tab_MacmanOperationHistory.Controls.Add(Me.mohUpdateButton)
Me.tab_MacmanOperationHistory.Controls.Add(Me.mohOperationIndex)
Me.tab_MacmanOperationHistory.Controls.Add(Me.Label113)
Me.tab_MacmanOperationHistory.Controls.Add(Me.mohOperationTime)
Me.tab_MacmanOperationHistory.Controls.Add(Me.Label116)
Me.tab_MacmanOperationHistory.Controls.Add(Me.mohOperationDate)
Me.tab_MacmanOperationHistory.Controls.Add(Me.Label117)
Me.tab_MacmanOperationHistory.Controls.Add(Me.mohOperationData)
Me.tab_MacmanOperationHistory.Controls.Add(Me.Label118)
Me.tab_MacmanOperationHistory.Controls.Add(Me.mohOperationMaxCount)
Me.tab_MacmanOperationHistory.Controls.Add(Me.Label119)
Me.tab_MacmanOperationHistory.Controls.Add(Me.mohOperationCount)
Me.tab_MacmanOperationHistory.Controls.Add(Me.Label120)
Me.tab_MacmanOperationHistory.Location = New System.Drawing.Point(4, 22)
Me.tab_MacmanOperationHistory.Name = "tab_MacmanOperationHistory"
Me.tab_MacmanOperationHistory.Size = New System.Drawing.Size(776, 446)
Me.tab_MacmanOperationHistory.TabIndex = 14
Me.tab_MacmanOperationHistory.Text = "MacMan Operation History"
'
'mohTo
'
Me.mohTo.Location = New System.Drawing.Point(528, 16)
Me.mohTo.Name = "mohTo"
Me.mohTo.Size = New System.Drawing.Size(64, 20)
Me.mohTo.TabIndex = 206
Me.mohTo.Text = "2"
'
'Label131
'
Me.Label131.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label131.Location = New System.Drawing.Point(472, 16)
Me.Label131.Name = "Label131"
Me.Label131.Size = New System.Drawing.Size(48, 16)
Me.Label131.TabIndex = 205
Me.Label131.Text = "To"
'
'mohFrom
'
Me.mohFrom.Location = New System.Drawing.Point(376, 16)
Me.mohFrom.Name = "mohFrom"
Me.mohFrom.Size = New System.Drawing.Size(64, 20)
Me.mohFrom.TabIndex = 204
Me.mohFrom.Text = "1"
'
'Label132
'
Me.Label132.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label132.Location = New System.Drawing.Point(320, 16)
Me.Label132.Name = "Label132"
Me.Label132.Size = New System.Drawing.Size(48, 16)
Me.Label132.TabIndex = 203
Me.Label132.Text = "From"
'
'mohResults
'
Me.mohResults.Location = New System.Drawing.Point(184, 48)
Me.mohResults.Multiline = true
Me.mohResults.Name = "mohResults"
Me.mohResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.mohResults.Size = New System.Drawing.Size(552, 328)
Me.mohResults.TabIndex = 202
Me.mohResults.Text = ""
'
'mohButtonResults
'
Me.mohButtonResults.Location = New System.Drawing.Point(664, 16)
Me.mohButtonResults.Name = "mohButtonResults"
Me.mohButtonResults.Size = New System.Drawing.Size(72, 24)
Me.mohButtonResults.TabIndex = 201
Me.mohButtonResults.Text = "Update"
'
'mohUpdateButton
'
Me.mohUpdateButton.Location = New System.Drawing.Point(16, 16)
Me.mohUpdateButton.Name = "mohUpdateButton"
Me.mohUpdateButton.Size = New System.Drawing.Size(152, 24)
Me.mohUpdateButton.TabIndex = 198
Me.mohUpdateButton.Text = "Update"
'
'mohOperationIndex
'
Me.mohOperationIndex.Location = New System.Drawing.Point(16, 72)
Me.mohOperationIndex.Name = "mohOperationIndex"
Me.mohOperationIndex.Size = New System.Drawing.Size(64, 20)
Me.mohOperationIndex.TabIndex = 197
Me.mohOperationIndex.Text = "1"
'
'Label113
'
Me.Label113.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label113.Location = New System.Drawing.Point(16, 48)
Me.Label113.Name = "Label113"
Me.Label113.Size = New System.Drawing.Size(136, 16)
Me.Label113.TabIndex = 196
Me.Label113.Text = "Operation History Index :"
'
'mohOperationTime
'
Me.mohOperationTime.Location = New System.Drawing.Point(16, 240)
Me.mohOperationTime.Name = "mohOperationTime"
Me.mohOperationTime.Size = New System.Drawing.Size(152, 20)
Me.mohOperationTime.TabIndex = 191
Me.mohOperationTime.Text = ""
'
'Label116
'
Me.Label116.Location = New System.Drawing.Point(16, 216)
Me.Label116.Name = "Label116"
Me.Label116.Size = New System.Drawing.Size(160, 16)
Me.Label116.TabIndex = 190
Me.Label116.Text = "Operation Time :"
'
'mohOperationDate
'
Me.mohOperationDate.Location = New System.Drawing.Point(16, 184)
Me.mohOperationDate.Name = "mohOperationDate"
Me.mohOperationDate.Size = New System.Drawing.Size(152, 20)
Me.mohOperationDate.TabIndex = 189
Me.mohOperationDate.Text = ""
'
'Label117
'
Me.Label117.Location = New System.Drawing.Point(16, 160)
Me.Label117.Name = "Label117"
Me.Label117.Size = New System.Drawing.Size(160, 16)
Me.Label117.TabIndex = 188
Me.Label117.Text = "Operation Date :"
'
'mohOperationData
'
Me.mohOperationData.Location = New System.Drawing.Point(16, 128)
Me.mohOperationData.Name = "mohOperationData"
Me.mohOperationData.Size = New System.Drawing.Size(152, 20)
Me.mohOperationData.TabIndex = 187
Me.mohOperationData.Text = ""
'
'Label118
'
Me.Label118.Location = New System.Drawing.Point(16, 104)
Me.Label118.Name = "Label118"
Me.Label118.Size = New System.Drawing.Size(152, 16)
Me.Label118.TabIndex = 186
Me.Label118.Text = "Operation Data :"
'
'mohOperationMaxCount
'
Me.mohOperationMaxCount.Location = New System.Drawing.Point(16, 352)
Me.mohOperationMaxCount.Name = "mohOperationMaxCount"
Me.mohOperationMaxCount.Size = New System.Drawing.Size(152, 20)
Me.mohOperationMaxCount.TabIndex = 185
Me.mohOperationMaxCount.Text = ""
'
'Label119
'
Me.Label119.Location = New System.Drawing.Point(16, 328)
Me.Label119.Name = "Label119"
Me.Label119.Size = New System.Drawing.Size(160, 16)
Me.Label119.TabIndex = 184
Me.Label119.Text = "Operation History Max Count :"
'
'mohOperationCount
'
Me.mohOperationCount.Location = New System.Drawing.Point(16, 296)
Me.mohOperationCount.Name = "mohOperationCount"
Me.mohOperationCount.Size = New System.Drawing.Size(152, 20)
Me.mohOperationCount.TabIndex = 183
Me.mohOperationCount.Text = ""
'
'Label120
'
Me.Label120.Location = New System.Drawing.Point(16, 272)
Me.Label120.Name = "Label120"
Me.Label120.Size = New System.Drawing.Size(160, 16)
Me.Label120.TabIndex = 182
Me.Label120.Text = "Operation History Count :"
'
'tab_ballscrew
'
Me.tab_ballscrew.Controls.Add(Me.ballscrewDataUnitCombo)
Me.tab_ballscrew.Controls.Add(Me.bsDataUnitSet)
Me.tab_ballscrew.Controls.Add(Me.Label150)
Me.tab_ballscrew.Controls.Add(Me.Label115)
Me.tab_ballscrew.Controls.Add(Me.bsPecPoint)
Me.tab_ballscrew.Controls.Add(Me.bsStartPositionAdd)
Me.tab_ballscrew.Controls.Add(Me.bsStartPositionSet)
Me.tab_ballscrew.Controls.Add(Me.bsMaxPitchPointsAdd)
Me.tab_ballscrew.Controls.Add(Me.bsMaxPicthPointsSet)
Me.tab_ballscrew.Controls.Add(Me.bsIntervalAdd)
Me.tab_ballscrew.Controls.Add(Me.bsIntervalSet)
Me.tab_ballscrew.Controls.Add(Me.bsDataPointAdd)
Me.tab_ballscrew.Controls.Add(Me.bsDataPointSet)
Me.tab_ballscrew.Controls.Add(Me.bsStartPositionUpdate)
Me.tab_ballscrew.Controls.Add(Me.bsMaxPitchPointsUpdate)
Me.tab_ballscrew.Controls.Add(Me.bsIntervalUpdate)
Me.tab_ballscrew.Controls.Add(Me.bsDataPointUpdate)
Me.tab_ballscrew.Controls.Add(Me.bsStartPosition)
Me.tab_ballscrew.Controls.Add(Me.Label31)
Me.tab_ballscrew.Controls.Add(Me.bsMaxPitchPoints)
Me.tab_ballscrew.Controls.Add(Me.Label30)
Me.tab_ballscrew.Controls.Add(Me.bsInterval)
Me.tab_ballscrew.Controls.Add(Me.Label29)
Me.tab_ballscrew.Controls.Add(Me.ballscrewUpdateButton)
Me.tab_ballscrew.Controls.Add(Me.Label28)
Me.tab_ballscrew.Controls.Add(Me.ballscrewAxisCombo)
Me.tab_ballscrew.Controls.Add(Me.Panel5)
Me.tab_ballscrew.Controls.Add(Me.bsDataPoint)
Me.tab_ballscrew.Controls.Add(Me.Label27)
Me.tab_ballscrew.Location = New System.Drawing.Point(4, 22)
Me.tab_ballscrew.Name = "tab_ballscrew"
Me.tab_ballscrew.Size = New System.Drawing.Size(776, 446)
Me.tab_ballscrew.TabIndex = 2
Me.tab_ballscrew.Text = "Ballscrew"
'
'ballscrewDataUnitCombo
'
Me.ballscrewDataUnitCombo.Location = New System.Drawing.Point(376, 264)
Me.ballscrewDataUnitCombo.Name = "ballscrewDataUnitCombo"
Me.ballscrewDataUnitCombo.TabIndex = 78
'
'bsDataUnitSet
'
Me.bsDataUnitSet.Location = New System.Drawing.Point(512, 264)
Me.bsDataUnitSet.Name = "bsDataUnitSet"
Me.bsDataUnitSet.Size = New System.Drawing.Size(72, 24)
Me.bsDataUnitSet.TabIndex = 77
Me.bsDataUnitSet.Text = "Set"
'
'Label150
'
Me.Label150.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label150.Location = New System.Drawing.Point(304, 264)
Me.Label150.Name = "Label150"
Me.Label150.Size = New System.Drawing.Size(80, 16)
Me.Label150.TabIndex = 75
Me.Label150.Text = "Data Unit"
'
'Label115
'
Me.Label115.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label115.Location = New System.Drawing.Point(304, 96)
Me.Label115.Name = "Label115"
Me.Label115.Size = New System.Drawing.Size(80, 16)
Me.Label115.TabIndex = 74
Me.Label115.Text = "PEC Point:"
'
'bsPecPoint
'
Me.bsPecPoint.Location = New System.Drawing.Point(392, 96)
Me.bsPecPoint.Name = "bsPecPoint"
Me.bsPecPoint.Size = New System.Drawing.Size(104, 20)
Me.bsPecPoint.TabIndex = 73
Me.bsPecPoint.Text = "1"
'
'bsStartPositionAdd
'
Me.bsStartPositionAdd.Location = New System.Drawing.Point(600, 224)
Me.bsStartPositionAdd.Name = "bsStartPositionAdd"
Me.bsStartPositionAdd.Size = New System.Drawing.Size(64, 24)
Me.bsStartPositionAdd.TabIndex = 72
Me.bsStartPositionAdd.Text = "Add"
'
'bsStartPositionSet
'
Me.bsStartPositionSet.Location = New System.Drawing.Point(512, 224)
Me.bsStartPositionSet.Name = "bsStartPositionSet"
Me.bsStartPositionSet.Size = New System.Drawing.Size(72, 24)
Me.bsStartPositionSet.TabIndex = 71
Me.bsStartPositionSet.Text = "Set"
'
'bsMaxPitchPointsAdd
'
Me.bsMaxPitchPointsAdd.Location = New System.Drawing.Point(600, 192)
Me.bsMaxPitchPointsAdd.Name = "bsMaxPitchPointsAdd"
Me.bsMaxPitchPointsAdd.Size = New System.Drawing.Size(64, 24)
Me.bsMaxPitchPointsAdd.TabIndex = 70
Me.bsMaxPitchPointsAdd.Text = "Add"
'
'bsMaxPicthPointsSet
'
Me.bsMaxPicthPointsSet.Location = New System.Drawing.Point(512, 192)
Me.bsMaxPicthPointsSet.Name = "bsMaxPicthPointsSet"
Me.bsMaxPicthPointsSet.Size = New System.Drawing.Size(72, 24)
Me.bsMaxPicthPointsSet.TabIndex = 69
Me.bsMaxPicthPointsSet.Text = "Set"
'
'bsIntervalAdd
'
Me.bsIntervalAdd.Location = New System.Drawing.Point(600, 160)
Me.bsIntervalAdd.Name = "bsIntervalAdd"
Me.bsIntervalAdd.Size = New System.Drawing.Size(64, 24)
Me.bsIntervalAdd.TabIndex = 68
Me.bsIntervalAdd.Text = "Add"
'
'bsIntervalSet
'
Me.bsIntervalSet.Location = New System.Drawing.Point(512, 160)
Me.bsIntervalSet.Name = "bsIntervalSet"
Me.bsIntervalSet.Size = New System.Drawing.Size(72, 24)
Me.bsIntervalSet.TabIndex = 67
Me.bsIntervalSet.Text = "Set"
'
'bsDataPointAdd
'
Me.bsDataPointAdd.Location = New System.Drawing.Point(600, 128)
Me.bsDataPointAdd.Name = "bsDataPointAdd"
Me.bsDataPointAdd.Size = New System.Drawing.Size(64, 24)
Me.bsDataPointAdd.TabIndex = 66
Me.bsDataPointAdd.Text = "Add"
'
'bsDataPointSet
'
Me.bsDataPointSet.Location = New System.Drawing.Point(512, 128)
Me.bsDataPointSet.Name = "bsDataPointSet"
Me.bsDataPointSet.Size = New System.Drawing.Size(72, 24)
Me.bsDataPointSet.TabIndex = 65
Me.bsDataPointSet.Text = "Set"
'
'bsStartPositionUpdate
'
Me.bsStartPositionUpdate.BackColor = System.Drawing.SystemColors.Control
Me.bsStartPositionUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsStartPositionUpdate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsStartPositionUpdate.ForeColor = System.Drawing.Color.Red
Me.bsStartPositionUpdate.Location = New System.Drawing.Point(400, 224)
Me.bsStartPositionUpdate.Name = "bsStartPositionUpdate"
Me.bsStartPositionUpdate.Size = New System.Drawing.Size(104, 24)
Me.bsStartPositionUpdate.TabIndex = 64
Me.bsStartPositionUpdate.Text = "0.00"
'
'bsMaxPitchPointsUpdate
'
Me.bsMaxPitchPointsUpdate.BackColor = System.Drawing.SystemColors.Control
Me.bsMaxPitchPointsUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsMaxPitchPointsUpdate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsMaxPitchPointsUpdate.ForeColor = System.Drawing.Color.Red
Me.bsMaxPitchPointsUpdate.Location = New System.Drawing.Point(400, 192)
Me.bsMaxPitchPointsUpdate.Name = "bsMaxPitchPointsUpdate"
Me.bsMaxPitchPointsUpdate.Size = New System.Drawing.Size(104, 24)
Me.bsMaxPitchPointsUpdate.TabIndex = 63
Me.bsMaxPitchPointsUpdate.Text = "0"
'
'bsIntervalUpdate
'
Me.bsIntervalUpdate.BackColor = System.Drawing.SystemColors.Control
Me.bsIntervalUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsIntervalUpdate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsIntervalUpdate.ForeColor = System.Drawing.Color.Red
Me.bsIntervalUpdate.Location = New System.Drawing.Point(400, 160)
Me.bsIntervalUpdate.Name = "bsIntervalUpdate"
Me.bsIntervalUpdate.Size = New System.Drawing.Size(104, 24)
Me.bsIntervalUpdate.TabIndex = 62
Me.bsIntervalUpdate.Text = "0.00"
'
'bsDataPointUpdate
'
Me.bsDataPointUpdate.BackColor = System.Drawing.SystemColors.Control
Me.bsDataPointUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsDataPointUpdate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsDataPointUpdate.ForeColor = System.Drawing.Color.Red
Me.bsDataPointUpdate.Location = New System.Drawing.Point(400, 128)
Me.bsDataPointUpdate.Name = "bsDataPointUpdate"
Me.bsDataPointUpdate.Size = New System.Drawing.Size(104, 24)
Me.bsDataPointUpdate.TabIndex = 61
Me.bsDataPointUpdate.Text = "0"
'
'bsStartPosition
'
Me.bsStartPosition.BackColor = System.Drawing.SystemColors.Control
Me.bsStartPosition.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsStartPosition.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsStartPosition.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.bsStartPosition.Location = New System.Drawing.Point(224, 224)
Me.bsStartPosition.Name = "bsStartPosition"
Me.bsStartPosition.Size = New System.Drawing.Size(160, 24)
Me.bsStartPosition.TabIndex = 60
Me.bsStartPosition.Text = "0.00"
'
'Label31
'
Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label31.Location = New System.Drawing.Point(48, 224)
Me.Label31.Name = "Label31"
Me.Label31.Size = New System.Drawing.Size(160, 16)
Me.Label31.TabIndex = 59
Me.Label31.Text = "Start Position :"
'
'bsMaxPitchPoints
'
Me.bsMaxPitchPoints.BackColor = System.Drawing.SystemColors.Control
Me.bsMaxPitchPoints.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsMaxPitchPoints.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsMaxPitchPoints.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.bsMaxPitchPoints.Location = New System.Drawing.Point(224, 192)
Me.bsMaxPitchPoints.Name = "bsMaxPitchPoints"
Me.bsMaxPitchPoints.Size = New System.Drawing.Size(160, 24)
Me.bsMaxPitchPoints.TabIndex = 58
Me.bsMaxPitchPoints.Text = "0"
'
'Label30
'
Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label30.Location = New System.Drawing.Point(48, 192)
Me.Label30.Name = "Label30"
Me.Label30.Size = New System.Drawing.Size(160, 16)
Me.Label30.TabIndex = 57
Me.Label30.Text = "Max Pitch Points :"
'
'bsInterval
'
Me.bsInterval.BackColor = System.Drawing.SystemColors.Control
Me.bsInterval.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsInterval.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsInterval.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.bsInterval.Location = New System.Drawing.Point(224, 160)
Me.bsInterval.Name = "bsInterval"
Me.bsInterval.Size = New System.Drawing.Size(160, 24)
Me.bsInterval.TabIndex = 56
Me.bsInterval.Text = "0.00"
'
'Label29
'
Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label29.Location = New System.Drawing.Point(48, 160)
Me.Label29.Name = "Label29"
Me.Label29.Size = New System.Drawing.Size(160, 16)
Me.Label29.TabIndex = 55
Me.Label29.Text = "Interval :"
'
'ballscrewUpdateButton
'
Me.ballscrewUpdateButton.Location = New System.Drawing.Point(224, 56)
Me.ballscrewUpdateButton.Name = "ballscrewUpdateButton"
Me.ballscrewUpdateButton.Size = New System.Drawing.Size(104, 24)
Me.ballscrewUpdateButton.TabIndex = 52
Me.ballscrewUpdateButton.Text = "Update"
'
'Label28
'
Me.Label28.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Label28.Location = New System.Drawing.Point(16, 16)
Me.Label28.Name = "Label28"
Me.Label28.Size = New System.Drawing.Size(40, 16)
Me.Label28.TabIndex = 50
Me.Label28.Text = "Axis"
'
'ballscrewAxisCombo
'
Me.ballscrewAxisCombo.Location = New System.Drawing.Point(56, 16)
Me.ballscrewAxisCombo.Name = "ballscrewAxisCombo"
Me.ballscrewAxisCombo.Size = New System.Drawing.Size(120, 20)
Me.ballscrewAxisCombo.TabIndex = 49
'
'Panel5
'
Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel5.Location = New System.Drawing.Point(8, 8)
Me.Panel5.Name = "Panel5"
Me.Panel5.Size = New System.Drawing.Size(736, 40)
Me.Panel5.TabIndex = 51
'
'bsDataPoint
'
Me.bsDataPoint.BackColor = System.Drawing.SystemColors.Control
Me.bsDataPoint.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.bsDataPoint.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.bsDataPoint.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.bsDataPoint.Location = New System.Drawing.Point(224, 128)
Me.bsDataPoint.Name = "bsDataPoint"
Me.bsDataPoint.Size = New System.Drawing.Size(160, 24)
Me.bsDataPoint.TabIndex = 23
Me.bsDataPoint.Text = "0"
'
'Label27
'
Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label27.Location = New System.Drawing.Point(48, 128)
Me.Label27.Name = "Label27"
Me.Label27.Size = New System.Drawing.Size(160, 16)
Me.Label27.TabIndex = 22
Me.Label27.Text = "Data Point:"
'
'tab_CurrentAlarm
'
Me.tab_CurrentAlarm.Controls.Add(Me.cmdCurrentAlarm_Update)
Me.tab_CurrentAlarm.Controls.Add(Me.GroupBox20)
Me.tab_CurrentAlarm.Location = New System.Drawing.Point(4, 22)
Me.tab_CurrentAlarm.Name = "tab_CurrentAlarm"
Me.tab_CurrentAlarm.Size = New System.Drawing.Size(776, 446)
Me.tab_CurrentAlarm.TabIndex = 24
Me.tab_CurrentAlarm.Text = "Current Alarm"
'
'cmdCurrentAlarm_Update
'
Me.cmdCurrentAlarm_Update.Location = New System.Drawing.Point(8, 16)
Me.cmdCurrentAlarm_Update.Name = "cmdCurrentAlarm_Update"
Me.cmdCurrentAlarm_Update.Size = New System.Drawing.Size(112, 32)
Me.cmdCurrentAlarm_Update.TabIndex = 85
Me.cmdCurrentAlarm_Update.Text = "Update"
'
'GroupBox20
'
Me.GroupBox20.Controls.Add(Me.txtCurrentAlarm_AlarmCharacterString)
Me.GroupBox20.Controls.Add(Me.txtCurrentAlarm_AlarmCode)
Me.GroupBox20.Controls.Add(Me.PictureBox2)
Me.GroupBox20.Controls.Add(Me.txtCurrentAlarm_ObjectMessage)
Me.GroupBox20.Controls.Add(Me.txtCurrentAlarm_AlarmMessage)
Me.GroupBox20.Controls.Add(Me.txtCurrentAlarm_AlarmLevel)
Me.GroupBox20.Controls.Add(Me.txtCurrentAlarm_ObjectNumber)
Me.GroupBox20.Controls.Add(Me.txtCurrentAlarm_AlarmNumber)
Me.GroupBox20.Controls.Add(Me.PictureBox3)
Me.GroupBox20.Location = New System.Drawing.Point(8, 56)
Me.GroupBox20.Name = "GroupBox20"
Me.GroupBox20.Size = New System.Drawing.Size(760, 360)
Me.GroupBox20.TabIndex = 84
Me.GroupBox20.TabStop = false
Me.GroupBox20.Text = "Current OSP Alarm"
'
'txtCurrentAlarm_AlarmCharacterString
'
Me.txtCurrentAlarm_AlarmCharacterString.Location = New System.Drawing.Point(280, 326)
Me.txtCurrentAlarm_AlarmCharacterString.Name = "txtCurrentAlarm_AlarmCharacterString"
Me.txtCurrentAlarm_AlarmCharacterString.ReadOnly = true
Me.txtCurrentAlarm_AlarmCharacterString.Size = New System.Drawing.Size(472, 20)
Me.txtCurrentAlarm_AlarmCharacterString.TabIndex = 10
Me.txtCurrentAlarm_AlarmCharacterString.Text = ""
'
'txtCurrentAlarm_AlarmCode
'
Me.txtCurrentAlarm_AlarmCode.Location = New System.Drawing.Point(280, 293)
Me.txtCurrentAlarm_AlarmCode.Name = "txtCurrentAlarm_AlarmCode"
Me.txtCurrentAlarm_AlarmCode.ReadOnly = true
Me.txtCurrentAlarm_AlarmCode.Size = New System.Drawing.Size(472, 20)
Me.txtCurrentAlarm_AlarmCode.TabIndex = 9
Me.txtCurrentAlarm_AlarmCode.Text = ""
'
'PictureBox2
'
Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"),System.Drawing.Image)
Me.PictureBox2.Location = New System.Drawing.Point(8, 16)
Me.PictureBox2.Name = "PictureBox2"
Me.PictureBox2.Size = New System.Drawing.Size(744, 96)
Me.PictureBox2.TabIndex = 8
Me.PictureBox2.TabStop = false
'
'txtCurrentAlarm_ObjectMessage
'
Me.txtCurrentAlarm_ObjectMessage.Location = New System.Drawing.Point(280, 260)
Me.txtCurrentAlarm_ObjectMessage.Name = "txtCurrentAlarm_ObjectMessage"
Me.txtCurrentAlarm_ObjectMessage.ReadOnly = true
Me.txtCurrentAlarm_ObjectMessage.Size = New System.Drawing.Size(472, 20)
Me.txtCurrentAlarm_ObjectMessage.TabIndex = 7
Me.txtCurrentAlarm_ObjectMessage.Text = ""
'
'txtCurrentAlarm_AlarmMessage
'
Me.txtCurrentAlarm_AlarmMessage.Location = New System.Drawing.Point(280, 227)
Me.txtCurrentAlarm_AlarmMessage.Name = "txtCurrentAlarm_AlarmMessage"
Me.txtCurrentAlarm_AlarmMessage.ReadOnly = true
Me.txtCurrentAlarm_AlarmMessage.Size = New System.Drawing.Size(232, 20)
Me.txtCurrentAlarm_AlarmMessage.TabIndex = 6
Me.txtCurrentAlarm_AlarmMessage.Text = ""
'
'txtCurrentAlarm_AlarmLevel
'
Me.txtCurrentAlarm_AlarmLevel.Location = New System.Drawing.Point(280, 194)
Me.txtCurrentAlarm_AlarmLevel.Name = "txtCurrentAlarm_AlarmLevel"
Me.txtCurrentAlarm_AlarmLevel.ReadOnly = true
Me.txtCurrentAlarm_AlarmLevel.Size = New System.Drawing.Size(128, 20)
Me.txtCurrentAlarm_AlarmLevel.TabIndex = 5
Me.txtCurrentAlarm_AlarmLevel.Text = ""
'
'txtCurrentAlarm_ObjectNumber
'
Me.txtCurrentAlarm_ObjectNumber.Location = New System.Drawing.Point(280, 161)
Me.txtCurrentAlarm_ObjectNumber.Name = "txtCurrentAlarm_ObjectNumber"
Me.txtCurrentAlarm_ObjectNumber.ReadOnly = true
Me.txtCurrentAlarm_ObjectNumber.Size = New System.Drawing.Size(56, 20)
Me.txtCurrentAlarm_ObjectNumber.TabIndex = 4
Me.txtCurrentAlarm_ObjectNumber.Text = ""
'
'txtCurrentAlarm_AlarmNumber
'
Me.txtCurrentAlarm_AlarmNumber.Location = New System.Drawing.Point(280, 128)
Me.txtCurrentAlarm_AlarmNumber.Name = "txtCurrentAlarm_AlarmNumber"
Me.txtCurrentAlarm_AlarmNumber.ReadOnly = true
Me.txtCurrentAlarm_AlarmNumber.Size = New System.Drawing.Size(56, 20)
Me.txtCurrentAlarm_AlarmNumber.TabIndex = 3
Me.txtCurrentAlarm_AlarmNumber.Text = ""
'
'PictureBox3
'
Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"),System.Drawing.Image)
Me.PictureBox3.Location = New System.Drawing.Point(8, 120)
Me.PictureBox3.Name = "PictureBox3"
Me.PictureBox3.Size = New System.Drawing.Size(264, 232)
Me.PictureBox3.TabIndex = 1
Me.PictureBox3.TabStop = false
'
'tab_OptionalParameter
'
Me.tab_OptionalParameter.Controls.Add(Me.GroupBox12)
Me.tab_OptionalParameter.Location = New System.Drawing.Point(4, 22)
Me.tab_OptionalParameter.Name = "tab_OptionalParameter"
Me.tab_OptionalParameter.Size = New System.Drawing.Size(776, 446)
Me.tab_OptionalParameter.TabIndex = 20
Me.tab_OptionalParameter.Text = "Optional Parameter"
'
'GroupBox12
'
Me.GroupBox12.Controls.Add(Me.txtLongWordInput)
Me.GroupBox12.Controls.Add(Me.txtWordInput)
Me.GroupBox12.Controls.Add(Me.txtBitInput)
Me.GroupBox12.Controls.Add(Me.cmdWordAdd)
Me.GroupBox12.Controls.Add(Me.cmdLongWordAdd)
Me.GroupBox12.Controls.Add(Me.cmdBitSet)
Me.GroupBox12.Controls.Add(Me.cmdWordSet)
Me.GroupBox12.Controls.Add(Me.cmdLongWordSet)
Me.GroupBox12.Controls.Add(Me.cmdOptionalParameterBitGet)
Me.GroupBox12.Controls.Add(Me.cmdOptionalParameterWordGet)
Me.GroupBox12.Controls.Add(Me.cmdOptionalParameterLongWordGet)
Me.GroupBox12.Controls.Add(Me.txtOptionalParameterLongWord)
Me.GroupBox12.Controls.Add(Me.txtOptionalParameterWord)
Me.GroupBox12.Controls.Add(Me.txtOptionalParameterBit)
Me.GroupBox12.Controls.Add(Me.Label299)
Me.GroupBox12.Controls.Add(Me.txtOptionalParameterBitNo)
Me.GroupBox12.Controls.Add(Me.Label300)
Me.GroupBox12.Controls.Add(Me.txtOptionalParameterLongWordIndex)
Me.GroupBox12.Controls.Add(Me.Label301)
Me.GroupBox12.Controls.Add(Me.txtOptionalParameterWordIndex)
Me.GroupBox12.Controls.Add(Me.Label302)
Me.GroupBox12.Controls.Add(Me.txtOptionalParameterBitIndex)
Me.GroupBox12.Controls.Add(Me.Label303)
Me.GroupBox12.Location = New System.Drawing.Point(8, 16)
Me.GroupBox12.Name = "GroupBox12"
Me.GroupBox12.Size = New System.Drawing.Size(488, 168)
Me.GroupBox12.TabIndex = 236
Me.GroupBox12.TabStop = false
Me.GroupBox12.Text = "Optional Parameter - Bit/Word/LongWord"
'
'txtLongWordInput
'
Me.txtLongWordInput.ForeColor = System.Drawing.Color.Red
Me.txtLongWordInput.Location = New System.Drawing.Point(432, 136)
Me.txtLongWordInput.Name = "txtLongWordInput"
Me.txtLongWordInput.Size = New System.Drawing.Size(48, 20)
Me.txtLongWordInput.TabIndex = 204
Me.txtLongWordInput.Text = "1"
'
'txtWordInput
'
Me.txtWordInput.ForeColor = System.Drawing.Color.Red
Me.txtWordInput.Location = New System.Drawing.Point(432, 96)
Me.txtWordInput.Name = "txtWordInput"
Me.txtWordInput.Size = New System.Drawing.Size(48, 20)
Me.txtWordInput.TabIndex = 203
Me.txtWordInput.Text = "1"
'
'txtBitInput
'
Me.txtBitInput.ForeColor = System.Drawing.Color.Red
Me.txtBitInput.Location = New System.Drawing.Point(432, 56)
Me.txtBitInput.Name = "txtBitInput"
Me.txtBitInput.Size = New System.Drawing.Size(48, 20)
Me.txtBitInput.TabIndex = 202
Me.txtBitInput.Text = "1"
'
'cmdWordAdd
'
Me.cmdWordAdd.Location = New System.Drawing.Point(384, 96)
Me.cmdWordAdd.Name = "cmdWordAdd"
Me.cmdWordAdd.Size = New System.Drawing.Size(40, 24)
Me.cmdWordAdd.TabIndex = 201
Me.cmdWordAdd.Text = "Add"
'
'cmdLongWordAdd
'
Me.cmdLongWordAdd.Location = New System.Drawing.Point(384, 136)
Me.cmdLongWordAdd.Name = "cmdLongWordAdd"
Me.cmdLongWordAdd.Size = New System.Drawing.Size(40, 24)
Me.cmdLongWordAdd.TabIndex = 200
Me.cmdLongWordAdd.Text = "Add"
'
'cmdBitSet
'
Me.cmdBitSet.Location = New System.Drawing.Point(336, 56)
Me.cmdBitSet.Name = "cmdBitSet"
Me.cmdBitSet.Size = New System.Drawing.Size(40, 24)
Me.cmdBitSet.TabIndex = 199
Me.cmdBitSet.Text = "Set"
'
'cmdWordSet
'
Me.cmdWordSet.Location = New System.Drawing.Point(336, 96)
Me.cmdWordSet.Name = "cmdWordSet"
Me.cmdWordSet.Size = New System.Drawing.Size(40, 24)
Me.cmdWordSet.TabIndex = 198
Me.cmdWordSet.Text = "Set"
'
'cmdLongWordSet
'
Me.cmdLongWordSet.Location = New System.Drawing.Point(336, 136)
Me.cmdLongWordSet.Name = "cmdLongWordSet"
Me.cmdLongWordSet.Size = New System.Drawing.Size(40, 24)
Me.cmdLongWordSet.TabIndex = 197
Me.cmdLongWordSet.Text = "Set"
'
'cmdOptionalParameterBitGet
'
Me.cmdOptionalParameterBitGet.Location = New System.Drawing.Point(288, 56)
Me.cmdOptionalParameterBitGet.Name = "cmdOptionalParameterBitGet"
Me.cmdOptionalParameterBitGet.Size = New System.Drawing.Size(40, 24)
Me.cmdOptionalParameterBitGet.TabIndex = 196
Me.cmdOptionalParameterBitGet.Text = "Get"
'
'cmdOptionalParameterWordGet
'
Me.cmdOptionalParameterWordGet.Location = New System.Drawing.Point(288, 96)
Me.cmdOptionalParameterWordGet.Name = "cmdOptionalParameterWordGet"
Me.cmdOptionalParameterWordGet.Size = New System.Drawing.Size(40, 24)
Me.cmdOptionalParameterWordGet.TabIndex = 193
Me.cmdOptionalParameterWordGet.Text = "Get"
'
'cmdOptionalParameterLongWordGet
'
Me.cmdOptionalParameterLongWordGet.Location = New System.Drawing.Point(288, 136)
Me.cmdOptionalParameterLongWordGet.Name = "cmdOptionalParameterLongWordGet"
Me.cmdOptionalParameterLongWordGet.Size = New System.Drawing.Size(40, 24)
Me.cmdOptionalParameterLongWordGet.TabIndex = 190
Me.cmdOptionalParameterLongWordGet.Text = "Get"
'
'txtOptionalParameterLongWord
'
Me.txtOptionalParameterLongWord.Location = New System.Drawing.Point(208, 136)
Me.txtOptionalParameterLongWord.Name = "txtOptionalParameterLongWord"
Me.txtOptionalParameterLongWord.ReadOnly = true
Me.txtOptionalParameterLongWord.Size = New System.Drawing.Size(64, 20)
Me.txtOptionalParameterLongWord.TabIndex = 11
Me.txtOptionalParameterLongWord.Text = "0"
'
'txtOptionalParameterWord
'
Me.txtOptionalParameterWord.Location = New System.Drawing.Point(208, 96)
Me.txtOptionalParameterWord.Name = "txtOptionalParameterWord"
Me.txtOptionalParameterWord.ReadOnly = true
Me.txtOptionalParameterWord.Size = New System.Drawing.Size(64, 20)
Me.txtOptionalParameterWord.TabIndex = 10
Me.txtOptionalParameterWord.Text = "0"
'
'txtOptionalParameterBit
'
Me.txtOptionalParameterBit.Location = New System.Drawing.Point(208, 56)
Me.txtOptionalParameterBit.Name = "txtOptionalParameterBit"
Me.txtOptionalParameterBit.ReadOnly = true
Me.txtOptionalParameterBit.Size = New System.Drawing.Size(64, 20)
Me.txtOptionalParameterBit.TabIndex = 9
Me.txtOptionalParameterBit.Text = "0"
'
'Label299
'
Me.Label299.Location = New System.Drawing.Point(144, 24)
Me.Label299.Name = "Label299"
Me.Label299.Size = New System.Drawing.Size(48, 23)
Me.Label299.TabIndex = 8
Me.Label299.Text = "Bit No."
'
'txtOptionalParameterBitNo
'
Me.txtOptionalParameterBitNo.Location = New System.Drawing.Point(144, 56)
Me.txtOptionalParameterBitNo.Name = "txtOptionalParameterBitNo"
Me.txtOptionalParameterBitNo.Size = New System.Drawing.Size(48, 20)
Me.txtOptionalParameterBitNo.TabIndex = 7
Me.txtOptionalParameterBitNo.Text = "0"
'
'Label300
'
Me.Label300.Location = New System.Drawing.Point(80, 24)
Me.Label300.Name = "Label300"
Me.Label300.Size = New System.Drawing.Size(48, 23)
Me.Label300.TabIndex = 6
Me.Label300.Text = "Index"
'
'txtOptionalParameterLongWordIndex
'
Me.txtOptionalParameterLongWordIndex.Location = New System.Drawing.Point(80, 136)
Me.txtOptionalParameterLongWordIndex.Name = "txtOptionalParameterLongWordIndex"
Me.txtOptionalParameterLongWordIndex.Size = New System.Drawing.Size(48, 20)
Me.txtOptionalParameterLongWordIndex.TabIndex = 5
Me.txtOptionalParameterLongWordIndex.Text = "1"
'
'Label301
'
Me.Label301.Location = New System.Drawing.Point(8, 136)
Me.Label301.Name = "Label301"
Me.Label301.Size = New System.Drawing.Size(64, 24)
Me.Label301.TabIndex = 4
Me.Label301.Text = "Long Word"
'
'txtOptionalParameterWordIndex
'
Me.txtOptionalParameterWordIndex.Location = New System.Drawing.Point(80, 96)
Me.txtOptionalParameterWordIndex.Name = "txtOptionalParameterWordIndex"
Me.txtOptionalParameterWordIndex.Size = New System.Drawing.Size(48, 20)
Me.txtOptionalParameterWordIndex.TabIndex = 3
Me.txtOptionalParameterWordIndex.Text = "1"
'
'Label302
'
Me.Label302.Location = New System.Drawing.Point(8, 96)
Me.Label302.Name = "Label302"
Me.Label302.Size = New System.Drawing.Size(64, 24)
Me.Label302.TabIndex = 2
Me.Label302.Text = "Word"
'
'txtOptionalParameterBitIndex
'
Me.txtOptionalParameterBitIndex.Location = New System.Drawing.Point(80, 56)
Me.txtOptionalParameterBitIndex.Name = "txtOptionalParameterBitIndex"
Me.txtOptionalParameterBitIndex.Size = New System.Drawing.Size(48, 20)
Me.txtOptionalParameterBitIndex.TabIndex = 1
Me.txtOptionalParameterBitIndex.Text = "1"
'
'Label303
'
Me.Label303.Location = New System.Drawing.Point(8, 56)
Me.Label303.Name = "Label303"
Me.Label303.Size = New System.Drawing.Size(64, 24)
Me.Label303.TabIndex = 0
Me.Label303.Text = "Bit"
'
'tab_MopTool
'
Me.tab_MopTool.Controls.Add(Me.Label233)
Me.tab_MopTool.Controls.Add(Me.TXT_GetMaxMOPToolData)
Me.tab_MopTool.Controls.Add(Me.mopButtonULValue)
Me.tab_MopTool.Controls.Add(Me.mopSetULValue)
Me.tab_MopTool.Controls.Add(Me.mopButtonToolDataInput)
Me.tab_MopTool.Controls.Add(Me.mopSetToolDataInputMode)
Me.tab_MopTool.Controls.Add(Me.mopButtonReferenceValue)
Me.tab_MopTool.Controls.Add(Me.mopSetReferenceValue)
Me.tab_MopTool.Controls.Add(Me.mopButtonOverloadMonitor)
Me.tab_MopTool.Controls.Add(Me.mopSetOverloadMonitor)
Me.tab_MopTool.Controls.Add(Me.mopButtonMinOverride)
Me.tab_MopTool.Controls.Add(Me.mopSetMinOverride)
Me.tab_MopTool.Controls.Add(Me.mopButtonMaxOverride)
Me.tab_MopTool.Controls.Add(Me.mopSetMaxOverride)
Me.tab_MopTool.Controls.Add(Me.mopButtonLLValue)
Me.tab_MopTool.Controls.Add(Me.mopSetLLValue)
Me.tab_MopTool.Controls.Add(Me.mopButtonLimitValue)
Me.tab_MopTool.Controls.Add(Me.mopSetLimitValue)
Me.tab_MopTool.Controls.Add(Me.mopButtonCuttingTime)
Me.tab_MopTool.Controls.Add(Me.mopSetCuttingTime)
Me.tab_MopTool.Controls.Add(Me.mopbuttonAutoChange)
Me.tab_MopTool.Controls.Add(Me.mopSetAutoChange)
Me.tab_MopTool.Controls.Add(Me.mopButtonUnusualSignalChange)
Me.tab_MopTool.Controls.Add(Me.mopSetUnusualSignal)
Me.tab_MopTool.Controls.Add(Me.mopButtonALVValue)
Me.tab_MopTool.Controls.Add(Me.mopSetALVValue)
Me.tab_MopTool.Controls.Add(Me.mopButtonAircutReduction)
Me.tab_MopTool.Controls.Add(Me.mopSetAircutReduction)
Me.tab_MopTool.Controls.Add(Me.mopButtonAircutOverride)
Me.tab_MopTool.Controls.Add(Me.mopSetAircutOverride)
Me.tab_MopTool.Controls.Add(Me.mopButtonAdaptiveControl)
Me.tab_MopTool.Controls.Add(Me.mopSetAdaptiveControl)
Me.tab_MopTool.Controls.Add(Me.mopUlValue)
Me.tab_MopTool.Controls.Add(Me.Label121)
Me.tab_MopTool.Controls.Add(Me.mopToolDataInputMode)
Me.tab_MopTool.Controls.Add(Me.Label123)
Me.tab_MopTool.Controls.Add(Me.mopSignalDiffAlarm)
Me.tab_MopTool.Controls.Add(Me.Label124)
Me.tab_MopTool.Controls.Add(Me.mopReferenceValue)
Me.tab_MopTool.Controls.Add(Me.Label56)
Me.tab_MopTool.Controls.Add(Me.mopOverloadMonitor)
Me.tab_MopTool.Controls.Add(Me.Label55)
Me.tab_MopTool.Controls.Add(Me.mopMinOverride)
Me.tab_MopTool.Controls.Add(Me.Label54)
Me.tab_MopTool.Controls.Add(Me.mopMaxOverride)
Me.tab_MopTool.Controls.Add(Me.Label53)
Me.tab_MopTool.Controls.Add(Me.mopLLValue)
Me.tab_MopTool.Controls.Add(Me.Label52)
Me.tab_MopTool.Controls.Add(Me.mopLimitValue)
Me.tab_MopTool.Controls.Add(Me.Label51)
Me.tab_MopTool.Controls.Add(Me.mopCuttingTime)
Me.tab_MopTool.Controls.Add(Me.Label50)
Me.tab_MopTool.Controls.Add(Me.mopCuttingLoad)
Me.tab_MopTool.Controls.Add(Me.Label48)
Me.tab_MopTool.Controls.Add(Me.mopAutoChange)
Me.tab_MopTool.Controls.Add(Me.Label47)
Me.tab_MopTool.Controls.Add(Me.mopUnusualSignal)
Me.tab_MopTool.Controls.Add(Me.Label49)
Me.tab_MopTool.Controls.Add(Me.mopAlarms)
Me.tab_MopTool.Controls.Add(Me.Label46)
Me.tab_MopTool.Controls.Add(Me.mopALVValue)
Me.tab_MopTool.Controls.Add(Me.Label45)
Me.tab_MopTool.Controls.Add(Me.mopAircutReduction)
Me.tab_MopTool.Controls.Add(Me.Label42)
Me.tab_MopTool.Controls.Add(Me.mopAircutOverride)
Me.tab_MopTool.Controls.Add(Me.Label43)
Me.tab_MopTool.Controls.Add(Me.mopAdaptiveControl)
Me.tab_MopTool.Controls.Add(Me.Label44)
Me.tab_MopTool.Controls.Add(Me.Label39)
Me.tab_MopTool.Controls.Add(Me.mopPositionTypeCombo)
Me.tab_MopTool.Controls.Add(Me.Label40)
Me.tab_MopTool.Controls.Add(Me.Label41)
Me.tab_MopTool.Controls.Add(Me.mopAxisCombo)
Me.tab_MopTool.Controls.Add(Me.Panel6)
Me.tab_MopTool.Controls.Add(Me.GroupBox6)
Me.tab_MopTool.Controls.Add(Me.GroupBox7)
Me.tab_MopTool.Location = New System.Drawing.Point(4, 22)
Me.tab_MopTool.Name = "tab_MopTool"
Me.tab_MopTool.Size = New System.Drawing.Size(776, 446)
Me.tab_MopTool.TabIndex = 5
Me.tab_MopTool.Text = "MOP Tool"
'
'Label233
'
Me.Label233.Location = New System.Drawing.Point(376, 368)
Me.Label233.Name = "Label233"
Me.Label233.Size = New System.Drawing.Size(136, 16)
Me.Label233.TabIndex = 204
Me.Label233.Text = "Max tool Data"
'
'TXT_GetMaxMOPToolData
'
Me.TXT_GetMaxMOPToolData.Location = New System.Drawing.Point(520, 360)
Me.TXT_GetMaxMOPToolData.Name = "TXT_GetMaxMOPToolData"
Me.TXT_GetMaxMOPToolData.Size = New System.Drawing.Size(64, 20)
Me.TXT_GetMaxMOPToolData.TabIndex = 203
Me.TXT_GetMaxMOPToolData.Text = ""
'
'mopButtonULValue
'
Me.mopButtonULValue.Location = New System.Drawing.Point(312, 232)
Me.mopButtonULValue.Name = "mopButtonULValue"
Me.mopButtonULValue.Size = New System.Drawing.Size(40, 24)
Me.mopButtonULValue.TabIndex = 196
Me.mopButtonULValue.Text = "Set"
'
'mopSetULValue
'
Me.mopSetULValue.ForeColor = System.Drawing.Color.Red
Me.mopSetULValue.Location = New System.Drawing.Point(240, 232)
Me.mopSetULValue.Name = "mopSetULValue"
Me.mopSetULValue.Size = New System.Drawing.Size(64, 20)
Me.mopSetULValue.TabIndex = 195
Me.mopSetULValue.Text = "0"
'
'mopButtonToolDataInput
'
Me.mopButtonToolDataInput.Location = New System.Drawing.Point(312, 96)
Me.mopButtonToolDataInput.Name = "mopButtonToolDataInput"
Me.mopButtonToolDataInput.Size = New System.Drawing.Size(40, 24)
Me.mopButtonToolDataInput.TabIndex = 194
Me.mopButtonToolDataInput.Text = "Set"
'
'mopSetToolDataInputMode
'
Me.mopSetToolDataInputMode.ForeColor = System.Drawing.Color.Red
Me.mopSetToolDataInputMode.Location = New System.Drawing.Point(240, 96)
Me.mopSetToolDataInputMode.Name = "mopSetToolDataInputMode"
Me.mopSetToolDataInputMode.Size = New System.Drawing.Size(64, 20)
Me.mopSetToolDataInputMode.TabIndex = 193
Me.mopSetToolDataInputMode.Text = "0"
'
'mopButtonReferenceValue
'
Me.mopButtonReferenceValue.Location = New System.Drawing.Point(312, 136)
Me.mopButtonReferenceValue.Name = "mopButtonReferenceValue"
Me.mopButtonReferenceValue.Size = New System.Drawing.Size(40, 24)
Me.mopButtonReferenceValue.TabIndex = 192
Me.mopButtonReferenceValue.Text = "Set"
'
'mopSetReferenceValue
'
Me.mopSetReferenceValue.ForeColor = System.Drawing.Color.Red
Me.mopSetReferenceValue.Location = New System.Drawing.Point(240, 136)
Me.mopSetReferenceValue.Name = "mopSetReferenceValue"
Me.mopSetReferenceValue.Size = New System.Drawing.Size(64, 20)
Me.mopSetReferenceValue.TabIndex = 191
Me.mopSetReferenceValue.Text = "0"
'
'mopButtonOverloadMonitor
'
Me.mopButtonOverloadMonitor.Location = New System.Drawing.Point(664, 128)
Me.mopButtonOverloadMonitor.Name = "mopButtonOverloadMonitor"
Me.mopButtonOverloadMonitor.Size = New System.Drawing.Size(40, 24)
Me.mopButtonOverloadMonitor.TabIndex = 190
Me.mopButtonOverloadMonitor.Text = "Set"
'
'mopSetOverloadMonitor
'
Me.mopSetOverloadMonitor.ForeColor = System.Drawing.Color.Red
Me.mopSetOverloadMonitor.Location = New System.Drawing.Point(592, 128)
Me.mopSetOverloadMonitor.Name = "mopSetOverloadMonitor"
Me.mopSetOverloadMonitor.Size = New System.Drawing.Size(64, 20)
Me.mopSetOverloadMonitor.TabIndex = 189
Me.mopSetOverloadMonitor.Text = "0"
'
'mopButtonMinOverride
'
Me.mopButtonMinOverride.Location = New System.Drawing.Point(312, 328)
Me.mopButtonMinOverride.Name = "mopButtonMinOverride"
Me.mopButtonMinOverride.Size = New System.Drawing.Size(40, 24)
Me.mopButtonMinOverride.TabIndex = 188
Me.mopButtonMinOverride.Text = "Set"
'
'mopSetMinOverride
'
Me.mopSetMinOverride.ForeColor = System.Drawing.Color.Red
Me.mopSetMinOverride.Location = New System.Drawing.Point(240, 328)
Me.mopSetMinOverride.Name = "mopSetMinOverride"
Me.mopSetMinOverride.Size = New System.Drawing.Size(64, 20)
Me.mopSetMinOverride.TabIndex = 187
Me.mopSetMinOverride.Text = "0"
'
'mopButtonMaxOverride
'
Me.mopButtonMaxOverride.Location = New System.Drawing.Point(312, 296)
Me.mopButtonMaxOverride.Name = "mopButtonMaxOverride"
Me.mopButtonMaxOverride.Size = New System.Drawing.Size(40, 24)
Me.mopButtonMaxOverride.TabIndex = 186
Me.mopButtonMaxOverride.Text = "Set"
'
'mopSetMaxOverride
'
Me.mopSetMaxOverride.ForeColor = System.Drawing.Color.Red
Me.mopSetMaxOverride.Location = New System.Drawing.Point(240, 296)
Me.mopSetMaxOverride.Name = "mopSetMaxOverride"
Me.mopSetMaxOverride.Size = New System.Drawing.Size(64, 20)
Me.mopSetMaxOverride.TabIndex = 185
Me.mopSetMaxOverride.Text = "0"
'
'mopButtonLLValue
'
Me.mopButtonLLValue.Location = New System.Drawing.Point(312, 264)
Me.mopButtonLLValue.Name = "mopButtonLLValue"
Me.mopButtonLLValue.Size = New System.Drawing.Size(40, 24)
Me.mopButtonLLValue.TabIndex = 184
Me.mopButtonLLValue.Text = "Set"
'
'mopSetLLValue
'
Me.mopSetLLValue.ForeColor = System.Drawing.Color.Red
Me.mopSetLLValue.Location = New System.Drawing.Point(240, 264)
Me.mopSetLLValue.Name = "mopSetLLValue"
Me.mopSetLLValue.Size = New System.Drawing.Size(64, 20)
Me.mopSetLLValue.TabIndex = 183
Me.mopSetLLValue.Text = "0"
'
'mopButtonLimitValue
'
Me.mopButtonLimitValue.Location = New System.Drawing.Point(312, 200)
Me.mopButtonLimitValue.Name = "mopButtonLimitValue"
Me.mopButtonLimitValue.Size = New System.Drawing.Size(40, 24)
Me.mopButtonLimitValue.TabIndex = 182
Me.mopButtonLimitValue.Text = "Set"
'
'mopSetLimitValue
'
Me.mopSetLimitValue.ForeColor = System.Drawing.Color.Red
Me.mopSetLimitValue.Location = New System.Drawing.Point(240, 200)
Me.mopSetLimitValue.Name = "mopSetLimitValue"
Me.mopSetLimitValue.Size = New System.Drawing.Size(64, 20)
Me.mopSetLimitValue.TabIndex = 181
Me.mopSetLimitValue.Text = "0"
'
'mopButtonCuttingTime
'
Me.mopButtonCuttingTime.Location = New System.Drawing.Point(312, 64)
Me.mopButtonCuttingTime.Name = "mopButtonCuttingTime"
Me.mopButtonCuttingTime.Size = New System.Drawing.Size(40, 24)
Me.mopButtonCuttingTime.TabIndex = 180
Me.mopButtonCuttingTime.Text = "Set"
'
'mopSetCuttingTime
'
Me.mopSetCuttingTime.ForeColor = System.Drawing.Color.Red
Me.mopSetCuttingTime.Location = New System.Drawing.Point(240, 64)
Me.mopSetCuttingTime.Name = "mopSetCuttingTime"
Me.mopSetCuttingTime.Size = New System.Drawing.Size(64, 20)
Me.mopSetCuttingTime.TabIndex = 179
Me.mopSetCuttingTime.Text = "0"
'
'mopbuttonAutoChange
'
Me.mopbuttonAutoChange.Location = New System.Drawing.Point(664, 215)
Me.mopbuttonAutoChange.Name = "mopbuttonAutoChange"
Me.mopbuttonAutoChange.Size = New System.Drawing.Size(40, 24)
Me.mopbuttonAutoChange.TabIndex = 178
Me.mopbuttonAutoChange.Text = "Set"
'
'mopSetAutoChange
'
Me.mopSetAutoChange.ForeColor = System.Drawing.Color.Red
Me.mopSetAutoChange.Location = New System.Drawing.Point(592, 215)
Me.mopSetAutoChange.Name = "mopSetAutoChange"
Me.mopSetAutoChange.Size = New System.Drawing.Size(64, 20)
Me.mopSetAutoChange.TabIndex = 177
Me.mopSetAutoChange.Text = "0"
'
'mopButtonUnusualSignalChange
'
Me.mopButtonUnusualSignalChange.Location = New System.Drawing.Point(664, 328)
Me.mopButtonUnusualSignalChange.Name = "mopButtonUnusualSignalChange"
Me.mopButtonUnusualSignalChange.Size = New System.Drawing.Size(40, 24)
Me.mopButtonUnusualSignalChange.TabIndex = 176
Me.mopButtonUnusualSignalChange.Text = "Set"
'
'mopSetUnusualSignal
'
Me.mopSetUnusualSignal.ForeColor = System.Drawing.Color.Red
Me.mopSetUnusualSignal.Location = New System.Drawing.Point(592, 328)
Me.mopSetUnusualSignal.Name = "mopSetUnusualSignal"
Me.mopSetUnusualSignal.Size = New System.Drawing.Size(64, 20)
Me.mopSetUnusualSignal.TabIndex = 175
Me.mopSetUnusualSignal.Text = "0"
'
'mopButtonALVValue
'
Me.mopButtonALVValue.Location = New System.Drawing.Point(312, 168)
Me.mopButtonALVValue.Name = "mopButtonALVValue"
Me.mopButtonALVValue.Size = New System.Drawing.Size(40, 24)
Me.mopButtonALVValue.TabIndex = 174
Me.mopButtonALVValue.Text = "Set"
'
'mopSetALVValue
'
Me.mopSetALVValue.ForeColor = System.Drawing.Color.Red
Me.mopSetALVValue.Location = New System.Drawing.Point(240, 168)
Me.mopSetALVValue.Name = "mopSetALVValue"
Me.mopSetALVValue.Size = New System.Drawing.Size(64, 20)
Me.mopSetALVValue.TabIndex = 173
Me.mopSetALVValue.Text = "0"
'
'mopButtonAircutReduction
'
Me.mopButtonAircutReduction.Location = New System.Drawing.Point(664, 186)
Me.mopButtonAircutReduction.Name = "mopButtonAircutReduction"
Me.mopButtonAircutReduction.Size = New System.Drawing.Size(40, 24)
Me.mopButtonAircutReduction.TabIndex = 172
Me.mopButtonAircutReduction.Text = "Set"
'
'mopSetAircutReduction
'
Me.mopSetAircutReduction.ForeColor = System.Drawing.Color.Red
Me.mopSetAircutReduction.Location = New System.Drawing.Point(592, 186)
Me.mopSetAircutReduction.Name = "mopSetAircutReduction"
Me.mopSetAircutReduction.Size = New System.Drawing.Size(64, 20)
Me.mopSetAircutReduction.TabIndex = 171
Me.mopSetAircutReduction.Text = "0"
'
'mopButtonAircutOverride
'
Me.mopButtonAircutOverride.Location = New System.Drawing.Point(312, 360)
Me.mopButtonAircutOverride.Name = "mopButtonAircutOverride"
Me.mopButtonAircutOverride.Size = New System.Drawing.Size(40, 24)
Me.mopButtonAircutOverride.TabIndex = 170
Me.mopButtonAircutOverride.Text = "Set"
'
'mopSetAircutOverride
'
Me.mopSetAircutOverride.ForeColor = System.Drawing.Color.Red
Me.mopSetAircutOverride.Location = New System.Drawing.Point(240, 360)
Me.mopSetAircutOverride.Name = "mopSetAircutOverride"
Me.mopSetAircutOverride.Size = New System.Drawing.Size(64, 20)
Me.mopSetAircutOverride.TabIndex = 169
Me.mopSetAircutOverride.Text = "0"
'
'mopButtonAdaptiveControl
'
Me.mopButtonAdaptiveControl.Location = New System.Drawing.Point(664, 157)
Me.mopButtonAdaptiveControl.Name = "mopButtonAdaptiveControl"
Me.mopButtonAdaptiveControl.Size = New System.Drawing.Size(40, 24)
Me.mopButtonAdaptiveControl.TabIndex = 168
Me.mopButtonAdaptiveControl.Text = "Set"
'
'mopSetAdaptiveControl
'
Me.mopSetAdaptiveControl.ForeColor = System.Drawing.Color.Red
Me.mopSetAdaptiveControl.Location = New System.Drawing.Point(592, 157)
Me.mopSetAdaptiveControl.Name = "mopSetAdaptiveControl"
Me.mopSetAdaptiveControl.Size = New System.Drawing.Size(64, 20)
Me.mopSetAdaptiveControl.TabIndex = 167
Me.mopSetAdaptiveControl.Text = "0"
'
'mopUlValue
'
Me.mopUlValue.Location = New System.Drawing.Point(168, 232)
Me.mopUlValue.Name = "mopUlValue"
Me.mopUlValue.Size = New System.Drawing.Size(64, 20)
Me.mopUlValue.TabIndex = 100
Me.mopUlValue.Text = ""
'
'Label121
'
Me.Label121.Location = New System.Drawing.Point(24, 232)
Me.Label121.Name = "Label121"
Me.Label121.Size = New System.Drawing.Size(136, 16)
Me.Label121.TabIndex = 99
Me.Label121.Text = "UL Value :"
'
'mopToolDataInputMode
'
Me.mopToolDataInputMode.Location = New System.Drawing.Point(168, 96)
Me.mopToolDataInputMode.Name = "mopToolDataInputMode"
Me.mopToolDataInputMode.Size = New System.Drawing.Size(64, 20)
Me.mopToolDataInputMode.TabIndex = 96
Me.mopToolDataInputMode.Text = ""
'
'Label123
'
Me.Label123.Location = New System.Drawing.Point(24, 96)
Me.Label123.Name = "Label123"
Me.Label123.Size = New System.Drawing.Size(136, 16)
Me.Label123.TabIndex = 95
Me.Label123.Text = "Tool Data Input Mode"
'
'mopSignalDiffAlarm
'
Me.mopSignalDiffAlarm.Location = New System.Drawing.Point(520, 273)
Me.mopSignalDiffAlarm.Name = "mopSignalDiffAlarm"
Me.mopSignalDiffAlarm.Size = New System.Drawing.Size(64, 20)
Me.mopSignalDiffAlarm.TabIndex = 94
Me.mopSignalDiffAlarm.Text = ""
'
'Label124
'
Me.Label124.Location = New System.Drawing.Point(376, 280)
Me.Label124.Name = "Label124"
Me.Label124.Size = New System.Drawing.Size(136, 16)
Me.Label124.TabIndex = 93
Me.Label124.Text = "Signal Different at Alarm"
'
'mopReferenceValue
'
Me.mopReferenceValue.Location = New System.Drawing.Point(168, 136)
Me.mopReferenceValue.Name = "mopReferenceValue"
Me.mopReferenceValue.Size = New System.Drawing.Size(64, 20)
Me.mopReferenceValue.TabIndex = 92
Me.mopReferenceValue.Text = ""
'
'Label56
'
Me.Label56.Location = New System.Drawing.Point(24, 136)
Me.Label56.Name = "Label56"
Me.Label56.Size = New System.Drawing.Size(136, 16)
Me.Label56.TabIndex = 91
Me.Label56.Text = "Reference Value"
'
'mopOverloadMonitor
'
Me.mopOverloadMonitor.Location = New System.Drawing.Point(520, 128)
Me.mopOverloadMonitor.Name = "mopOverloadMonitor"
Me.mopOverloadMonitor.Size = New System.Drawing.Size(64, 20)
Me.mopOverloadMonitor.TabIndex = 90
Me.mopOverloadMonitor.Text = ""
'
'Label55
'
Me.Label55.Location = New System.Drawing.Point(376, 136)
Me.Label55.Name = "Label55"
Me.Label55.Size = New System.Drawing.Size(136, 16)
Me.Label55.TabIndex = 89
Me.Label55.Text = "Overload Monitor"
'
'mopMinOverride
'
Me.mopMinOverride.Location = New System.Drawing.Point(168, 328)
Me.mopMinOverride.Name = "mopMinOverride"
Me.mopMinOverride.Size = New System.Drawing.Size(64, 20)
Me.mopMinOverride.TabIndex = 88
Me.mopMinOverride.Text = ""
'
'Label54
'
Me.Label54.Location = New System.Drawing.Point(24, 328)
Me.Label54.Name = "Label54"
Me.Label54.Size = New System.Drawing.Size(136, 16)
Me.Label54.TabIndex = 87
Me.Label54.Text = "Min Override"
'
'mopMaxOverride
'
Me.mopMaxOverride.Location = New System.Drawing.Point(168, 296)
Me.mopMaxOverride.Name = "mopMaxOverride"
Me.mopMaxOverride.Size = New System.Drawing.Size(64, 20)
Me.mopMaxOverride.TabIndex = 86
Me.mopMaxOverride.Text = ""
'
'Label53
'
Me.Label53.Location = New System.Drawing.Point(24, 296)
Me.Label53.Name = "Label53"
Me.Label53.Size = New System.Drawing.Size(136, 16)
Me.Label53.TabIndex = 85
Me.Label53.Text = "Max Override"
'
'mopLLValue
'
Me.mopLLValue.Location = New System.Drawing.Point(168, 264)
Me.mopLLValue.Name = "mopLLValue"
Me.mopLLValue.Size = New System.Drawing.Size(64, 20)
Me.mopLLValue.TabIndex = 84
Me.mopLLValue.Text = ""
'
'Label52
'
Me.Label52.Location = New System.Drawing.Point(24, 264)
Me.Label52.Name = "Label52"
Me.Label52.Size = New System.Drawing.Size(136, 16)
Me.Label52.TabIndex = 83
Me.Label52.Text = "LL Value"
'
'mopLimitValue
'
Me.mopLimitValue.Location = New System.Drawing.Point(168, 200)
Me.mopLimitValue.Name = "mopLimitValue"
Me.mopLimitValue.Size = New System.Drawing.Size(64, 20)
Me.mopLimitValue.TabIndex = 82
Me.mopLimitValue.Text = ""
'
'Label51
'
Me.Label51.Location = New System.Drawing.Point(24, 200)
Me.Label51.Name = "Label51"
Me.Label51.Size = New System.Drawing.Size(136, 16)
Me.Label51.TabIndex = 81
Me.Label51.Text = "Limit Value"
'
'mopCuttingTime
'
Me.mopCuttingTime.Location = New System.Drawing.Point(168, 64)
Me.mopCuttingTime.Name = "mopCuttingTime"
Me.mopCuttingTime.Size = New System.Drawing.Size(64, 20)
Me.mopCuttingTime.TabIndex = 80
Me.mopCuttingTime.Text = ""
'
'Label50
'
Me.Label50.Location = New System.Drawing.Point(24, 64)
Me.Label50.Name = "Label50"
Me.Label50.Size = New System.Drawing.Size(136, 16)
Me.Label50.TabIndex = 79
Me.Label50.Text = "Cutting Time"
'
'mopCuttingLoad
'
Me.mopCuttingLoad.Location = New System.Drawing.Point(520, 302)
Me.mopCuttingLoad.Name = "mopCuttingLoad"
Me.mopCuttingLoad.Size = New System.Drawing.Size(64, 20)
Me.mopCuttingLoad.TabIndex = 78
Me.mopCuttingLoad.Text = ""
'
'Label48
'
Me.Label48.Location = New System.Drawing.Point(376, 312)
Me.Label48.Name = "Label48"
Me.Label48.Size = New System.Drawing.Size(136, 16)
Me.Label48.TabIndex = 77
Me.Label48.Text = "Cutting Load at Alarm"
'
'mopAutoChange
'
Me.mopAutoChange.Location = New System.Drawing.Point(520, 215)
Me.mopAutoChange.Name = "mopAutoChange"
Me.mopAutoChange.Size = New System.Drawing.Size(64, 20)
Me.mopAutoChange.TabIndex = 76
Me.mopAutoChange.Text = ""
'
'Label47
'
Me.Label47.Location = New System.Drawing.Point(376, 224)
Me.Label47.Name = "Label47"
Me.Label47.Size = New System.Drawing.Size(136, 16)
Me.Label47.TabIndex = 75
Me.Label47.Text = "Auto Change"
'
'mopUnusualSignal
'
Me.mopUnusualSignal.Location = New System.Drawing.Point(520, 331)
Me.mopUnusualSignal.Name = "mopUnusualSignal"
Me.mopUnusualSignal.Size = New System.Drawing.Size(64, 20)
Me.mopUnusualSignal.TabIndex = 74
Me.mopUnusualSignal.Text = ""
'
'Label49
'
Me.Label49.Location = New System.Drawing.Point(376, 336)
Me.Label49.Name = "Label49"
Me.Label49.Size = New System.Drawing.Size(136, 16)
Me.Label49.TabIndex = 73
Me.Label49.Text = "Unusual Signal Change"
'
'mopAlarms
'
Me.mopAlarms.Location = New System.Drawing.Point(520, 244)
Me.mopAlarms.Name = "mopAlarms"
Me.mopAlarms.Size = New System.Drawing.Size(184, 20)
Me.mopAlarms.TabIndex = 68
Me.mopAlarms.Text = ""
'
'Label46
'
Me.Label46.Location = New System.Drawing.Point(376, 248)
Me.Label46.Name = "Label46"
Me.Label46.Size = New System.Drawing.Size(136, 16)
Me.Label46.TabIndex = 67
Me.Label46.Text = "Alarms"
'
'mopALVValue
'
Me.mopALVValue.Location = New System.Drawing.Point(168, 168)
Me.mopALVValue.Name = "mopALVValue"
Me.mopALVValue.Size = New System.Drawing.Size(64, 20)
Me.mopALVValue.TabIndex = 66
Me.mopALVValue.Text = ""
'
'Label45
'
Me.Label45.Location = New System.Drawing.Point(24, 168)
Me.Label45.Name = "Label45"
Me.Label45.Size = New System.Drawing.Size(136, 16)
Me.Label45.TabIndex = 65
Me.Label45.Text = "ALV Value"
'
'mopAircutReduction
'
Me.mopAircutReduction.Location = New System.Drawing.Point(520, 186)
Me.mopAircutReduction.Name = "mopAircutReduction"
Me.mopAircutReduction.Size = New System.Drawing.Size(64, 20)
Me.mopAircutReduction.TabIndex = 63
Me.mopAircutReduction.Text = ""
'
'Label42
'
Me.Label42.Location = New System.Drawing.Point(24, 360)
Me.Label42.Name = "Label42"
Me.Label42.Size = New System.Drawing.Size(136, 16)
Me.Label42.TabIndex = 64
Me.Label42.Text = "Aircut Override"
'
'mopAircutOverride
'
Me.mopAircutOverride.Location = New System.Drawing.Point(168, 360)
Me.mopAircutOverride.Name = "mopAircutOverride"
Me.mopAircutOverride.Size = New System.Drawing.Size(64, 20)
Me.mopAircutOverride.TabIndex = 61
Me.mopAircutOverride.Text = ""
'
'Label43
'
Me.Label43.Location = New System.Drawing.Point(376, 168)
Me.Label43.Name = "Label43"
Me.Label43.Size = New System.Drawing.Size(136, 16)
Me.Label43.TabIndex = 62
Me.Label43.Text = "Adaptive Control"
'
'mopAdaptiveControl
'
Me.mopAdaptiveControl.Location = New System.Drawing.Point(520, 157)
Me.mopAdaptiveControl.Name = "mopAdaptiveControl"
Me.mopAdaptiveControl.Size = New System.Drawing.Size(64, 20)
Me.mopAdaptiveControl.TabIndex = 59
Me.mopAdaptiveControl.Text = ""
'
'Label44
'
Me.Label44.Location = New System.Drawing.Point(376, 192)
Me.Label44.Name = "Label44"
Me.Label44.Size = New System.Drawing.Size(136, 16)
Me.Label44.TabIndex = 60
Me.Label44.Text = "Aircut Reduction"
'
'Label39
'
Me.Label39.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Label39.Location = New System.Drawing.Point(376, 16)
Me.Label39.Name = "Label39"
Me.Label39.Size = New System.Drawing.Size(88, 16)
Me.Label39.TabIndex = 56
Me.Label39.Text = "Position Type :"
'
'mopPositionTypeCombo
'
Me.mopPositionTypeCombo.Location = New System.Drawing.Point(464, 16)
Me.mopPositionTypeCombo.Name = "mopPositionTypeCombo"
Me.mopPositionTypeCombo.Size = New System.Drawing.Size(120, 20)
Me.mopPositionTypeCombo.TabIndex = 55
'
'Label40
'
Me.Label40.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Label40.Location = New System.Drawing.Point(208, 16)
Me.Label40.Name = "Label40"
Me.Label40.Size = New System.Drawing.Size(88, 16)
Me.Label40.TabIndex = 54
Me.Label40.Text = "MOP Tool No."
'
'Label41
'
Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Label41.Location = New System.Drawing.Point(16, 16)
Me.Label41.Name = "Label41"
Me.Label41.Size = New System.Drawing.Size(56, 16)
Me.Label41.TabIndex = 52
Me.Label41.Text = "Mop Axis"
'
'mopAxisCombo
'
Me.mopAxisCombo.Location = New System.Drawing.Point(72, 16)
Me.mopAxisCombo.Name = "mopAxisCombo"
Me.mopAxisCombo.Size = New System.Drawing.Size(120, 20)
Me.mopAxisCombo.TabIndex = 51
'
'Panel6
'
Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(255,Byte), CType(192,Byte), CType(128,Byte))
Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel6.Controls.Add(Me.mopToolNumber)
Me.Panel6.Controls.Add(Me.mopUpdateButton)
Me.Panel6.Location = New System.Drawing.Point(8, 8)
Me.Panel6.Name = "Panel6"
Me.Panel6.Size = New System.Drawing.Size(736, 40)
Me.Panel6.TabIndex = 57
'
'mopToolNumber
'
Me.mopToolNumber.Location = New System.Drawing.Point(288, 8)
Me.mopToolNumber.Name = "mopToolNumber"
Me.mopToolNumber.Size = New System.Drawing.Size(64, 20)
Me.mopToolNumber.TabIndex = 1
Me.mopToolNumber.Text = "1"
'
'mopUpdateButton
'
Me.mopUpdateButton.Location = New System.Drawing.Point(600, 8)
Me.mopUpdateButton.Name = "mopUpdateButton"
Me.mopUpdateButton.Size = New System.Drawing.Size(128, 24)
Me.mopUpdateButton.TabIndex = 58
Me.mopUpdateButton.Text = "Update"
'
'GroupBox6
'
Me.GroupBox6.Controls.Add(Me.mopToolDataNumber)
Me.GroupBox6.Controls.Add(Me.mopDelete)
Me.GroupBox6.Controls.Add(Me.mopEdit)
Me.GroupBox6.Controls.Add(Me.Label139)
Me.GroupBox6.Controls.Add(Me.mopCMDClassNumber)
Me.GroupBox6.Controls.Add(Me.Label140)
Me.GroupBox6.Controls.Add(Me.mopCMDToolNumber)
Me.GroupBox6.Controls.Add(Me.Label122)
Me.GroupBox6.Location = New System.Drawing.Point(368, 48)
Me.GroupBox6.Name = "GroupBox6"
Me.GroupBox6.Size = New System.Drawing.Size(376, 72)
Me.GroupBox6.TabIndex = 205
Me.GroupBox6.TabStop = false
'
'mopToolDataNumber
'
Me.mopToolDataNumber.Location = New System.Drawing.Point(272, 8)
Me.mopToolDataNumber.Multiline = true
Me.mopToolDataNumber.Name = "mopToolDataNumber"
Me.mopToolDataNumber.ReadOnly = true
Me.mopToolDataNumber.Size = New System.Drawing.Size(88, 24)
Me.mopToolDataNumber.TabIndex = 211
Me.mopToolDataNumber.Text = "0"
'
'mopDelete
'
Me.mopDelete.Location = New System.Drawing.Point(248, 40)
Me.mopDelete.Name = "mopDelete"
Me.mopDelete.Size = New System.Drawing.Size(64, 24)
Me.mopDelete.TabIndex = 210
Me.mopDelete.Text = "Delete"
'
'mopEdit
'
Me.mopEdit.Location = New System.Drawing.Point(176, 40)
Me.mopEdit.Name = "mopEdit"
Me.mopEdit.Size = New System.Drawing.Size(56, 24)
Me.mopEdit.TabIndex = 209
Me.mopEdit.Text = "Edit"
'
'Label139
'
Me.Label139.Location = New System.Drawing.Point(8, 40)
Me.Label139.Name = "Label139"
Me.Label139.Size = New System.Drawing.Size(80, 16)
Me.Label139.TabIndex = 208
Me.Label139.Text = "Class Number"
'
'mopCMDClassNumber
'
Me.mopCMDClassNumber.Location = New System.Drawing.Point(88, 40)
Me.mopCMDClassNumber.Name = "mopCMDClassNumber"
Me.mopCMDClassNumber.Size = New System.Drawing.Size(64, 20)
Me.mopCMDClassNumber.TabIndex = 207
Me.mopCMDClassNumber.Text = "1"
'
'Label140
'
Me.Label140.Location = New System.Drawing.Point(8, 8)
Me.Label140.Name = "Label140"
Me.Label140.Size = New System.Drawing.Size(72, 16)
Me.Label140.TabIndex = 206
Me.Label140.Text = "Tool Number"
'
'mopCMDToolNumber
'
Me.mopCMDToolNumber.Location = New System.Drawing.Point(88, 8)
Me.mopCMDToolNumber.Name = "mopCMDToolNumber"
Me.mopCMDToolNumber.Size = New System.Drawing.Size(64, 20)
Me.mopCMDToolNumber.TabIndex = 205
Me.mopCMDToolNumber.Tag = ""
Me.mopCMDToolNumber.Text = "1"
'
'Label122
'
Me.Label122.Location = New System.Drawing.Point(168, 8)
Me.Label122.Name = "Label122"
Me.Label122.Size = New System.Drawing.Size(104, 16)
Me.Label122.TabIndex = 203
Me.Label122.Text = "Tool Data Number :"
'
'GroupBox7
'
Me.GroupBox7.Location = New System.Drawing.Point(16, 48)
Me.GroupBox7.Name = "GroupBox7"
Me.GroupBox7.Size = New System.Drawing.Size(344, 80)
Me.GroupBox7.TabIndex = 206
Me.GroupBox7.TabStop = false
'
'tab_MacManOperatingHistory
'
Me.tab_MacManOperatingHistory.Controls.Add(Me.Label204)
Me.tab_MacManOperatingHistory.Controls.Add(Me.mopnhMaxNoofReports)
Me.tab_MacManOperatingHistory.Controls.Add(Me.GroupBox5)
Me.tab_MacManOperatingHistory.Controls.Add(Me.objMopnhUpdateButton)
Me.tab_MacManOperatingHistory.Controls.Add(Me.Label202)
Me.tab_MacManOperatingHistory.Controls.Add(Me.Label201)
Me.tab_MacManOperatingHistory.Controls.Add(Me.mopnhTo)
Me.tab_MacManOperatingHistory.Controls.Add(Me.GroupBox4)
Me.tab_MacManOperatingHistory.Controls.Add(Me.mopnhFrom)
Me.tab_MacManOperatingHistory.Location = New System.Drawing.Point(4, 22)
Me.tab_MacManOperatingHistory.Name = "tab_MacManOperatingHistory"
Me.tab_MacManOperatingHistory.Size = New System.Drawing.Size(776, 446)
Me.tab_MacManOperatingHistory.TabIndex = 16
Me.tab_MacManOperatingHistory.Text = "Macman Operating History"
'
'Label204
'
Me.Label204.Location = New System.Drawing.Point(424, 16)
Me.Label204.Name = "Label204"
Me.Label204.Size = New System.Drawing.Size(216, 24)
Me.Label204.TabIndex = 32
Me.Label204.Text = "Maximum no of operating history"
'
'mopnhMaxNoofReports
'
Me.mopnhMaxNoofReports.Location = New System.Drawing.Point(656, 16)
Me.mopnhMaxNoofReports.Name = "mopnhMaxNoofReports"
Me.mopnhMaxNoofReports.Size = New System.Drawing.Size(72, 20)
Me.mopnhMaxNoofReports.TabIndex = 31
Me.mopnhMaxNoofReports.Text = "0"
'
'GroupBox5
'
Me.GroupBox5.Controls.Add(Me.mopnhPrevAlarmonTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevExternalInputTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevSpindleRunTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevOtherTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevMaintenanceTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevPartWaitingTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevNoOperatorTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevInProSetupTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevNonOperatingTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevCuttingTime)
Me.GroupBox5.Controls.Add(Me.mopnhPrevOperatingTime)
Me.GroupBox5.Controls.Add(Me.Label214)
Me.GroupBox5.Controls.Add(Me.Label215)
Me.GroupBox5.Controls.Add(Me.Label216)
Me.GroupBox5.Controls.Add(Me.Label217)
Me.GroupBox5.Controls.Add(Me.Label218)
Me.GroupBox5.Controls.Add(Me.Label219)
Me.GroupBox5.Controls.Add(Me.Label220)
Me.GroupBox5.Controls.Add(Me.Label221)
Me.GroupBox5.Controls.Add(Me.Label222)
Me.GroupBox5.Controls.Add(Me.Label223)
Me.GroupBox5.Controls.Add(Me.Label224)
Me.GroupBox5.Controls.Add(Me.Label203)
Me.GroupBox5.Controls.Add(Me.mopnhPrevRunningTime)
Me.GroupBox5.Location = New System.Drawing.Point(384, 48)
Me.GroupBox5.Name = "GroupBox5"
Me.GroupBox5.Size = New System.Drawing.Size(352, 328)
Me.GroupBox5.TabIndex = 30
Me.GroupBox5.TabStop = false
Me.GroupBox5.Text = "Previousday Operating History"
'
'mopnhPrevAlarmonTime
'
Me.mopnhPrevAlarmonTime.Location = New System.Drawing.Point(120, 288)
Me.mopnhPrevAlarmonTime.Name = "mopnhPrevAlarmonTime"
Me.mopnhPrevAlarmonTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevAlarmonTime.TabIndex = 45
Me.mopnhPrevAlarmonTime.Text = "0"
'
'mopnhPrevExternalInputTime
'
Me.mopnhPrevExternalInputTime.Location = New System.Drawing.Point(120, 264)
Me.mopnhPrevExternalInputTime.Name = "mopnhPrevExternalInputTime"
Me.mopnhPrevExternalInputTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevExternalInputTime.TabIndex = 44
Me.mopnhPrevExternalInputTime.Text = "0"
'
'mopnhPrevSpindleRunTime
'
Me.mopnhPrevSpindleRunTime.Location = New System.Drawing.Point(120, 240)
Me.mopnhPrevSpindleRunTime.Name = "mopnhPrevSpindleRunTime"
Me.mopnhPrevSpindleRunTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevSpindleRunTime.TabIndex = 43
Me.mopnhPrevSpindleRunTime.Text = "0"
'
'mopnhPrevOtherTime
'
Me.mopnhPrevOtherTime.Location = New System.Drawing.Point(120, 216)
Me.mopnhPrevOtherTime.Name = "mopnhPrevOtherTime"
Me.mopnhPrevOtherTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevOtherTime.TabIndex = 42
Me.mopnhPrevOtherTime.Text = "0"
'
'mopnhPrevMaintenanceTime
'
Me.mopnhPrevMaintenanceTime.Location = New System.Drawing.Point(120, 192)
Me.mopnhPrevMaintenanceTime.Name = "mopnhPrevMaintenanceTime"
Me.mopnhPrevMaintenanceTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevMaintenanceTime.TabIndex = 41
Me.mopnhPrevMaintenanceTime.Text = "0"
'
'mopnhPrevPartWaitingTime
'
Me.mopnhPrevPartWaitingTime.Location = New System.Drawing.Point(120, 168)
Me.mopnhPrevPartWaitingTime.Name = "mopnhPrevPartWaitingTime"
Me.mopnhPrevPartWaitingTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevPartWaitingTime.TabIndex = 40
Me.mopnhPrevPartWaitingTime.Text = "0"
'
'mopnhPrevNoOperatorTime
'
Me.mopnhPrevNoOperatorTime.Location = New System.Drawing.Point(120, 144)
Me.mopnhPrevNoOperatorTime.Name = "mopnhPrevNoOperatorTime"
Me.mopnhPrevNoOperatorTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevNoOperatorTime.TabIndex = 39
Me.mopnhPrevNoOperatorTime.Text = "0"
'
'mopnhPrevInProSetupTime
'
Me.mopnhPrevInProSetupTime.Location = New System.Drawing.Point(120, 120)
Me.mopnhPrevInProSetupTime.Name = "mopnhPrevInProSetupTime"
Me.mopnhPrevInProSetupTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevInProSetupTime.TabIndex = 38
Me.mopnhPrevInProSetupTime.Text = "0"
'
'mopnhPrevNonOperatingTime
'
Me.mopnhPrevNonOperatingTime.Location = New System.Drawing.Point(120, 96)
Me.mopnhPrevNonOperatingTime.Name = "mopnhPrevNonOperatingTime"
Me.mopnhPrevNonOperatingTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevNonOperatingTime.TabIndex = 37
Me.mopnhPrevNonOperatingTime.Text = "0"
'
'mopnhPrevCuttingTime
'
Me.mopnhPrevCuttingTime.Location = New System.Drawing.Point(120, 72)
Me.mopnhPrevCuttingTime.Name = "mopnhPrevCuttingTime"
Me.mopnhPrevCuttingTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevCuttingTime.TabIndex = 36
Me.mopnhPrevCuttingTime.Text = "0"
'
'mopnhPrevOperatingTime
'
Me.mopnhPrevOperatingTime.Location = New System.Drawing.Point(120, 48)
Me.mopnhPrevOperatingTime.Name = "mopnhPrevOperatingTime"
Me.mopnhPrevOperatingTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevOperatingTime.TabIndex = 35
Me.mopnhPrevOperatingTime.Text = "0"
'
'Label214
'
Me.Label214.Location = New System.Drawing.Point(32, 288)
Me.Label214.Name = "Label214"
Me.Label214.Size = New System.Drawing.Size(112, 23)
Me.Label214.TabIndex = 34
Me.Label214.Text = "Alarm on Time"
'
'Label215
'
Me.Label215.Location = New System.Drawing.Point(16, 264)
Me.Label215.Name = "Label215"
Me.Label215.Size = New System.Drawing.Size(112, 23)
Me.Label215.TabIndex = 33
Me.Label215.Text = "External input Time"
'
'Label216
'
Me.Label216.Location = New System.Drawing.Point(32, 216)
Me.Label216.Name = "Label216"
Me.Label216.TabIndex = 32
Me.Label216.Text = "Other Time"
'
'Label217
'
Me.Label217.Location = New System.Drawing.Point(16, 192)
Me.Label217.Name = "Label217"
Me.Label217.TabIndex = 31
Me.Label217.Text = "Maintenance Time"
'
'Label218
'
Me.Label218.Location = New System.Drawing.Point(16, 168)
Me.Label218.Name = "Label218"
Me.Label218.TabIndex = 30
Me.Label218.Text = "Part waiting time"
'
'Label219
'
Me.Label219.Location = New System.Drawing.Point(16, 144)
Me.Label219.Name = "Label219"
Me.Label219.TabIndex = 29
Me.Label219.Text = "No Operator Time"
'
'Label220
'
Me.Label220.Location = New System.Drawing.Point(16, 120)
Me.Label220.Name = "Label220"
Me.Label220.TabIndex = 28
Me.Label220.Text = "In-Pro set up Time"
'
'Label221
'
Me.Label221.Location = New System.Drawing.Point(16, 96)
Me.Label221.Name = "Label221"
Me.Label221.Size = New System.Drawing.Size(104, 23)
Me.Label221.TabIndex = 27
Me.Label221.Text = "Non operating Time"
'
'Label222
'
Me.Label222.Location = New System.Drawing.Point(16, 72)
Me.Label222.Name = "Label222"
Me.Label222.TabIndex = 26
Me.Label222.Text = "Cutting TIme"
'
'Label223
'
Me.Label223.Location = New System.Drawing.Point(16, 48)
Me.Label223.Name = "Label223"
Me.Label223.TabIndex = 25
Me.Label223.Text = "Operating Time"
'
'Label224
'
Me.Label224.Location = New System.Drawing.Point(16, 24)
Me.Label224.Name = "Label224"
Me.Label224.Size = New System.Drawing.Size(80, 23)
Me.Label224.TabIndex = 24
Me.Label224.Text = "Running Time"
'
'Label203
'
Me.Label203.Location = New System.Drawing.Point(16, 240)
Me.Label203.Name = "Label203"
Me.Label203.TabIndex = 24
Me.Label203.Text = "Spindle run Time"
'
'mopnhPrevRunningTime
'
Me.mopnhPrevRunningTime.Location = New System.Drawing.Point(120, 24)
Me.mopnhPrevRunningTime.Name = "mopnhPrevRunningTime"
Me.mopnhPrevRunningTime.Size = New System.Drawing.Size(224, 20)
Me.mopnhPrevRunningTime.TabIndex = 24
Me.mopnhPrevRunningTime.Text = "0"
'
'objMopnhUpdateButton
'
Me.objMopnhUpdateButton.Location = New System.Drawing.Point(320, 16)
Me.objMopnhUpdateButton.Name = "objMopnhUpdateButton"
Me.objMopnhUpdateButton.TabIndex = 29
Me.objMopnhUpdateButton.Text = "Update"
'
'Label202
'
Me.Label202.Location = New System.Drawing.Point(168, 16)
Me.Label202.Name = "Label202"
Me.Label202.Size = New System.Drawing.Size(32, 23)
Me.Label202.TabIndex = 28
Me.Label202.Text = "To"
'
'Label201
'
Me.Label201.Location = New System.Drawing.Point(24, 16)
Me.Label201.Name = "Label201"
Me.Label201.Size = New System.Drawing.Size(32, 23)
Me.Label201.TabIndex = 27
Me.Label201.Text = "From"
'
'mopnhTo
'
Me.mopnhTo.Location = New System.Drawing.Point(200, 16)
Me.mopnhTo.Name = "mopnhTo"
Me.mopnhTo.TabIndex = 25
Me.mopnhTo.Text = "2"
'
'GroupBox4
'
Me.GroupBox4.Controls.Add(Me.mopnhAlarmOnTime)
Me.GroupBox4.Controls.Add(Me.mopnhExternalInputTime)
Me.GroupBox4.Controls.Add(Me.mopnhSpindleRunTime)
Me.GroupBox4.Controls.Add(Me.mopnhOtherTime)
Me.GroupBox4.Controls.Add(Me.mopnhMaintenanceTime)
Me.GroupBox4.Controls.Add(Me.mopnhPartWaitingTime)
Me.GroupBox4.Controls.Add(Me.mopnhNoOperatorTime)
Me.GroupBox4.Controls.Add(Me.mopnhInProSetupTime)
Me.GroupBox4.Controls.Add(Me.mopnhNonOperatingReport)
Me.GroupBox4.Controls.Add(Me.mopnhCuttingTime)
Me.GroupBox4.Controls.Add(Me.mopnhOperatingTime)
Me.GroupBox4.Controls.Add(Me.mopnhRunningTime)
Me.GroupBox4.Controls.Add(Me.Label200)
Me.GroupBox4.Controls.Add(Me.Label199)
Me.GroupBox4.Controls.Add(Me.Label198)
Me.GroupBox4.Controls.Add(Me.Label197)
Me.GroupBox4.Controls.Add(Me.Label196)
Me.GroupBox4.Controls.Add(Me.Label195)
Me.GroupBox4.Controls.Add(Me.Label194)
Me.GroupBox4.Controls.Add(Me.Label193)
Me.GroupBox4.Controls.Add(Me.Label192)
Me.GroupBox4.Controls.Add(Me.Label191)
Me.GroupBox4.Controls.Add(Me.Label190)
Me.GroupBox4.Controls.Add(Me.Label108)
Me.GroupBox4.Location = New System.Drawing.Point(8, 48)
Me.GroupBox4.Name = "GroupBox4"
Me.GroupBox4.Size = New System.Drawing.Size(368, 328)
Me.GroupBox4.TabIndex = 0
Me.GroupBox4.TabStop = false
Me.GroupBox4.Text = "Today Operating History"
'
'mopnhAlarmOnTime
'
Me.mopnhAlarmOnTime.Location = New System.Drawing.Point(128, 288)
Me.mopnhAlarmOnTime.Name = "mopnhAlarmOnTime"
Me.mopnhAlarmOnTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhAlarmOnTime.TabIndex = 23
Me.mopnhAlarmOnTime.Text = "0"
'
'mopnhExternalInputTime
'
Me.mopnhExternalInputTime.Location = New System.Drawing.Point(128, 264)
Me.mopnhExternalInputTime.Name = "mopnhExternalInputTime"
Me.mopnhExternalInputTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhExternalInputTime.TabIndex = 22
Me.mopnhExternalInputTime.Text = "0"
'
'mopnhSpindleRunTime
'
Me.mopnhSpindleRunTime.Location = New System.Drawing.Point(128, 240)
Me.mopnhSpindleRunTime.Name = "mopnhSpindleRunTime"
Me.mopnhSpindleRunTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhSpindleRunTime.TabIndex = 21
Me.mopnhSpindleRunTime.Text = "0"
'
'mopnhOtherTime
'
Me.mopnhOtherTime.Location = New System.Drawing.Point(128, 216)
Me.mopnhOtherTime.Name = "mopnhOtherTime"
Me.mopnhOtherTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhOtherTime.TabIndex = 20
Me.mopnhOtherTime.Text = "0"
'
'mopnhMaintenanceTime
'
Me.mopnhMaintenanceTime.Location = New System.Drawing.Point(128, 192)
Me.mopnhMaintenanceTime.Name = "mopnhMaintenanceTime"
Me.mopnhMaintenanceTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhMaintenanceTime.TabIndex = 19
Me.mopnhMaintenanceTime.Text = "0"
'
'mopnhPartWaitingTime
'
Me.mopnhPartWaitingTime.Location = New System.Drawing.Point(128, 168)
Me.mopnhPartWaitingTime.Name = "mopnhPartWaitingTime"
Me.mopnhPartWaitingTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhPartWaitingTime.TabIndex = 18
Me.mopnhPartWaitingTime.Text = "0"
'
'mopnhNoOperatorTime
'
Me.mopnhNoOperatorTime.Location = New System.Drawing.Point(128, 144)
Me.mopnhNoOperatorTime.Name = "mopnhNoOperatorTime"
Me.mopnhNoOperatorTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhNoOperatorTime.TabIndex = 17
Me.mopnhNoOperatorTime.Text = "0"
'
'mopnhInProSetupTime
'
Me.mopnhInProSetupTime.Location = New System.Drawing.Point(128, 120)
Me.mopnhInProSetupTime.Name = "mopnhInProSetupTime"
Me.mopnhInProSetupTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhInProSetupTime.TabIndex = 16
Me.mopnhInProSetupTime.Text = "0"
'
'mopnhNonOperatingReport
'
Me.mopnhNonOperatingReport.Location = New System.Drawing.Point(128, 96)
Me.mopnhNonOperatingReport.Name = "mopnhNonOperatingReport"
Me.mopnhNonOperatingReport.Size = New System.Drawing.Size(232, 20)
Me.mopnhNonOperatingReport.TabIndex = 15
Me.mopnhNonOperatingReport.Text = "0"
'
'mopnhCuttingTime
'
Me.mopnhCuttingTime.Location = New System.Drawing.Point(128, 72)
Me.mopnhCuttingTime.Name = "mopnhCuttingTime"
Me.mopnhCuttingTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhCuttingTime.TabIndex = 14
Me.mopnhCuttingTime.Text = "0"
'
'mopnhOperatingTime
'
Me.mopnhOperatingTime.Location = New System.Drawing.Point(128, 48)
Me.mopnhOperatingTime.Name = "mopnhOperatingTime"
Me.mopnhOperatingTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhOperatingTime.TabIndex = 13
Me.mopnhOperatingTime.Text = "0"
'
'mopnhRunningTime
'
Me.mopnhRunningTime.Location = New System.Drawing.Point(128, 24)
Me.mopnhRunningTime.Name = "mopnhRunningTime"
Me.mopnhRunningTime.Size = New System.Drawing.Size(232, 20)
Me.mopnhRunningTime.TabIndex = 12
Me.mopnhRunningTime.Text = "0"
'
'Label200
'
Me.Label200.Location = New System.Drawing.Point(8, 288)
Me.Label200.Name = "Label200"
Me.Label200.Size = New System.Drawing.Size(112, 23)
Me.Label200.TabIndex = 11
Me.Label200.Text = "Alarm on Time"
'
'Label199
'
Me.Label199.Location = New System.Drawing.Point(8, 264)
Me.Label199.Name = "Label199"
Me.Label199.Size = New System.Drawing.Size(112, 23)
Me.Label199.TabIndex = 10
Me.Label199.Text = "External input Time"
'
'Label198
'
Me.Label198.Location = New System.Drawing.Point(8, 240)
Me.Label198.Name = "Label198"
Me.Label198.TabIndex = 9
Me.Label198.Text = "Spindle run Time"
'
'Label197
'
Me.Label197.Location = New System.Drawing.Point(8, 224)
Me.Label197.Name = "Label197"
Me.Label197.TabIndex = 8
Me.Label197.Text = "Other Time"
'
'Label196
'
Me.Label196.Location = New System.Drawing.Point(8, 200)
Me.Label196.Name = "Label196"
Me.Label196.TabIndex = 7
Me.Label196.Text = "Maintenance Time"
'
'Label195
'
Me.Label195.Location = New System.Drawing.Point(8, 176)
Me.Label195.Name = "Label195"
Me.Label195.TabIndex = 6
Me.Label195.Text = "Part waiting time"
'
'Label194
'
Me.Label194.Location = New System.Drawing.Point(8, 152)
Me.Label194.Name = "Label194"
Me.Label194.TabIndex = 5
Me.Label194.Text = "No Operator Time"
'
'Label193
'
Me.Label193.Location = New System.Drawing.Point(8, 128)
Me.Label193.Name = "Label193"
Me.Label193.TabIndex = 4
Me.Label193.Text = "In-Pro set up Time"
'
'Label192
'
Me.Label192.Location = New System.Drawing.Point(8, 104)
Me.Label192.Name = "Label192"
Me.Label192.Size = New System.Drawing.Size(104, 23)
Me.Label192.TabIndex = 3
Me.Label192.Text = "Non operating Time"
'
'Label191
'
Me.Label191.Location = New System.Drawing.Point(8, 80)
Me.Label191.Name = "Label191"
Me.Label191.TabIndex = 2
Me.Label191.Text = "Cutting TIme"
'
'Label190
'
Me.Label190.Location = New System.Drawing.Point(8, 56)
Me.Label190.Name = "Label190"
Me.Label190.TabIndex = 1
Me.Label190.Text = "Operating Time"
'
'Label108
'
Me.Label108.Location = New System.Drawing.Point(8, 32)
Me.Label108.Name = "Label108"
Me.Label108.TabIndex = 0
Me.Label108.Text = "Running Time"
'
'mopnhFrom
'
Me.mopnhFrom.Location = New System.Drawing.Point(64, 16)
Me.mopnhFrom.Name = "mopnhFrom"
Me.mopnhFrom.TabIndex = 24
Me.mopnhFrom.Text = "1"
'
'tab_MacmanOperatingReport
'
Me.tab_MacmanOperatingReport.Controls.Add(Me.morMaxNoOfOpReport)
Me.tab_MacmanOperatingReport.Controls.Add(Me.Label288)
Me.tab_MacmanOperatingReport.Controls.Add(Me.morUpdateButton)
Me.tab_MacmanOperatingReport.Controls.Add(Me.morOperatingStatus)
Me.tab_MacmanOperatingReport.Controls.Add(Me.Label289)
Me.tab_MacmanOperatingReport.Controls.Add(Me.morNonoperatingCondition)
Me.tab_MacmanOperatingReport.Controls.Add(Me.Label290)
Me.tab_MacmanOperatingReport.Controls.Add(Me.GroupBox1)
Me.tab_MacmanOperatingReport.Controls.Add(Me.GroupBox2)
Me.tab_MacmanOperatingReport.Controls.Add(Me.GroupBox3)
Me.tab_MacmanOperatingReport.Location = New System.Drawing.Point(4, 22)
Me.tab_MacmanOperatingReport.Name = "tab_MacmanOperatingReport"
Me.tab_MacmanOperatingReport.Size = New System.Drawing.Size(776, 446)
Me.tab_MacmanOperatingReport.TabIndex = 13
Me.tab_MacmanOperatingReport.Text = "MacMan Operating Report"
'
'morMaxNoOfOpReport
'
Me.morMaxNoOfOpReport.Location = New System.Drawing.Point(668, 42)
Me.morMaxNoOfOpReport.Name = "morMaxNoOfOpReport"
Me.morMaxNoOfOpReport.Size = New System.Drawing.Size(96, 20)
Me.morMaxNoOfOpReport.TabIndex = 321
Me.morMaxNoOfOpReport.Text = "0"
'
'Label288
'
Me.Label288.Location = New System.Drawing.Point(492, 42)
Me.Label288.Name = "Label288"
Me.Label288.Size = New System.Drawing.Size(168, 24)
Me.Label288.TabIndex = 320
Me.Label288.Text = "Maximum no of operating report"
'
'morUpdateButton
'
Me.morUpdateButton.Location = New System.Drawing.Point(320, 8)
Me.morUpdateButton.Name = "morUpdateButton"
Me.morUpdateButton.Size = New System.Drawing.Size(88, 24)
Me.morUpdateButton.TabIndex = 319
Me.morUpdateButton.Text = "Update"
'
'morOperatingStatus
'
Me.morOperatingStatus.Location = New System.Drawing.Point(380, 42)
Me.morOperatingStatus.Name = "morOperatingStatus"
Me.morOperatingStatus.Size = New System.Drawing.Size(80, 20)
Me.morOperatingStatus.TabIndex = 318
Me.morOperatingStatus.Text = "0"
'
'Label289
'
Me.Label289.Location = New System.Drawing.Point(276, 42)
Me.Label289.Name = "Label289"
Me.Label289.Size = New System.Drawing.Size(96, 24)
Me.Label289.TabIndex = 317
Me.Label289.Text = "Operating Status :"
'
'morNonoperatingCondition
'
Me.morNonoperatingCondition.Location = New System.Drawing.Point(156, 42)
Me.morNonoperatingCondition.Name = "morNonoperatingCondition"
Me.morNonoperatingCondition.Size = New System.Drawing.Size(96, 20)
Me.morNonoperatingCondition.TabIndex = 316
Me.morNonoperatingCondition.Text = "0"
'
'Label290
'
Me.Label290.Location = New System.Drawing.Point(20, 42)
Me.Label290.Name = "Label290"
Me.Label290.Size = New System.Drawing.Size(136, 16)
Me.Label290.TabIndex = 315
Me.Label290.Text = "Non Operating Condition :"
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.Label64)
Me.GroupBox1.Controls.Add(Me.morPrevExternalInputTime)
Me.GroupBox1.Controls.Add(Me.morPrevDateOfOperatingRept)
Me.GroupBox1.Controls.Add(Me.morPrevAlarmOnTime)
Me.GroupBox1.Controls.Add(Me.morPrevSpindleRunTime)
Me.GroupBox1.Controls.Add(Me.morPrevOtherTime)
Me.GroupBox1.Controls.Add(Me.morPrevMaintenanceTime)
Me.GroupBox1.Controls.Add(Me.morPrevPartwaitingTime)
Me.GroupBox1.Controls.Add(Me.morPrevNoOperatorTime)
Me.GroupBox1.Controls.Add(Me.morPrevInProSetupTime)
Me.GroupBox1.Controls.Add(Me.morPrevNonOperatingTime)
Me.GroupBox1.Controls.Add(Me.morPrevCuttingTime)
Me.GroupBox1.Controls.Add(Me.morPrevRunningTime)
Me.GroupBox1.Controls.Add(Me.Label276)
Me.GroupBox1.Controls.Add(Me.Label277)
Me.GroupBox1.Controls.Add(Me.Label278)
Me.GroupBox1.Controls.Add(Me.Label279)
Me.GroupBox1.Controls.Add(Me.Label280)
Me.GroupBox1.Controls.Add(Me.Label281)
Me.GroupBox1.Controls.Add(Me.Label282)
Me.GroupBox1.Controls.Add(Me.Label283)
Me.GroupBox1.Controls.Add(Me.Label284)
Me.GroupBox1.Controls.Add(Me.Label285)
Me.GroupBox1.Controls.Add(Me.Label286)
Me.GroupBox1.Controls.Add(Me.Label287)
Me.GroupBox1.Controls.Add(Me.morPrevOperatingTime)
Me.GroupBox1.Location = New System.Drawing.Point(524, 74)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(240, 352)
Me.GroupBox1.TabIndex = 314
Me.GroupBox1.TabStop = false
Me.GroupBox1.Text = "Previous Day Operating Report"
'
'Label64
'
Me.Label64.Location = New System.Drawing.Point(8, 264)
Me.Label64.Name = "Label64"
Me.Label64.Size = New System.Drawing.Size(104, 23)
Me.Label64.TabIndex = 219
Me.Label64.Text = "External Input Time"
'
'morPrevExternalInputTime
'
Me.morPrevExternalInputTime.Location = New System.Drawing.Point(136, 256)
Me.morPrevExternalInputTime.Name = "morPrevExternalInputTime"
Me.morPrevExternalInputTime.TabIndex = 220
Me.morPrevExternalInputTime.Text = "0"
'
'morPrevDateOfOperatingRept
'
Me.morPrevDateOfOperatingRept.Location = New System.Drawing.Point(136, 304)
Me.morPrevDateOfOperatingRept.Name = "morPrevDateOfOperatingRept"
Me.morPrevDateOfOperatingRept.TabIndex = 218
Me.morPrevDateOfOperatingRept.Text = "0"
'
'morPrevAlarmOnTime
'
Me.morPrevAlarmOnTime.Location = New System.Drawing.Point(136, 280)
Me.morPrevAlarmOnTime.Name = "morPrevAlarmOnTime"
Me.morPrevAlarmOnTime.TabIndex = 217
Me.morPrevAlarmOnTime.Text = "0"
'
'morPrevSpindleRunTime
'
Me.morPrevSpindleRunTime.Location = New System.Drawing.Point(136, 232)
Me.morPrevSpindleRunTime.Name = "morPrevSpindleRunTime"
Me.morPrevSpindleRunTime.TabIndex = 216
Me.morPrevSpindleRunTime.Text = "0"
'
'morPrevOtherTime
'
Me.morPrevOtherTime.Location = New System.Drawing.Point(136, 208)
Me.morPrevOtherTime.Name = "morPrevOtherTime"
Me.morPrevOtherTime.TabIndex = 215
Me.morPrevOtherTime.Text = "0"
'
'morPrevMaintenanceTime
'
Me.morPrevMaintenanceTime.Location = New System.Drawing.Point(136, 184)
Me.morPrevMaintenanceTime.Name = "morPrevMaintenanceTime"
Me.morPrevMaintenanceTime.TabIndex = 214
Me.morPrevMaintenanceTime.Text = "0"
'
'morPrevPartwaitingTime
'
Me.morPrevPartwaitingTime.Location = New System.Drawing.Point(136, 160)
Me.morPrevPartwaitingTime.Name = "morPrevPartwaitingTime"
Me.morPrevPartwaitingTime.TabIndex = 213
Me.morPrevPartwaitingTime.Text = "0"
'
'morPrevNoOperatorTime
'
Me.morPrevNoOperatorTime.Location = New System.Drawing.Point(136, 136)
Me.morPrevNoOperatorTime.Name = "morPrevNoOperatorTime"
Me.morPrevNoOperatorTime.TabIndex = 212
Me.morPrevNoOperatorTime.Text = "0"
'
'morPrevInProSetupTime
'
Me.morPrevInProSetupTime.Location = New System.Drawing.Point(136, 112)
Me.morPrevInProSetupTime.Name = "morPrevInProSetupTime"
Me.morPrevInProSetupTime.TabIndex = 211
Me.morPrevInProSetupTime.Text = "0"
'
'morPrevNonOperatingTime
'
Me.morPrevNonOperatingTime.Location = New System.Drawing.Point(136, 88)
Me.morPrevNonOperatingTime.Name = "morPrevNonOperatingTime"
Me.morPrevNonOperatingTime.TabIndex = 210
Me.morPrevNonOperatingTime.Text = "0"
'
'morPrevCuttingTime
'
Me.morPrevCuttingTime.Location = New System.Drawing.Point(136, 64)
Me.morPrevCuttingTime.Name = "morPrevCuttingTime"
Me.morPrevCuttingTime.TabIndex = 209
Me.morPrevCuttingTime.Text = "0"
'
'morPrevRunningTime
'
Me.morPrevRunningTime.Location = New System.Drawing.Point(136, 40)
Me.morPrevRunningTime.Name = "morPrevRunningTime"
Me.morPrevRunningTime.TabIndex = 208
Me.morPrevRunningTime.Text = "0"
'
'Label276
'
Me.Label276.Location = New System.Drawing.Point(8, 16)
Me.Label276.Name = "Label276"
Me.Label276.Size = New System.Drawing.Size(88, 23)
Me.Label276.TabIndex = 203
Me.Label276.Text = "Operating Time"
'
'Label277
'
Me.Label277.Location = New System.Drawing.Point(8, 40)
Me.Label277.Name = "Label277"
Me.Label277.TabIndex = 203
Me.Label277.Text = "Runing Time"
'
'Label278
'
Me.Label278.Location = New System.Drawing.Point(8, 64)
Me.Label278.Name = "Label278"
Me.Label278.TabIndex = 203
Me.Label278.Text = "Cutting Time"
'
'Label279
'
Me.Label279.Location = New System.Drawing.Point(8, 88)
Me.Label279.Name = "Label279"
Me.Label279.Size = New System.Drawing.Size(120, 23)
Me.Label279.TabIndex = 203
Me.Label279.Text = "Non Operating Time"
'
'Label280
'
Me.Label280.Location = New System.Drawing.Point(8, 112)
Me.Label280.Name = "Label280"
Me.Label280.TabIndex = 203
Me.Label280.Text = "In Pro Setup Time"
'
'Label281
'
Me.Label281.Location = New System.Drawing.Point(8, 136)
Me.Label281.Name = "Label281"
Me.Label281.TabIndex = 203
Me.Label281.Text = "No Operator Time"
'
'Label282
'
Me.Label282.Location = New System.Drawing.Point(8, 160)
Me.Label282.Name = "Label282"
Me.Label282.TabIndex = 203
Me.Label282.Text = "Part waiting Time"
'
'Label283
'
Me.Label283.Location = New System.Drawing.Point(8, 192)
Me.Label283.Name = "Label283"
Me.Label283.TabIndex = 203
Me.Label283.Text = "Maintenance Time"
'
'Label284
'
Me.Label284.Location = New System.Drawing.Point(8, 216)
Me.Label284.Name = "Label284"
Me.Label284.TabIndex = 203
Me.Label284.Text = "Other Time"
'
'Label285
'
Me.Label285.Location = New System.Drawing.Point(8, 240)
Me.Label285.Name = "Label285"
Me.Label285.TabIndex = 203
Me.Label285.Text = "Spindle Run Time"
'
'Label286
'
Me.Label286.Location = New System.Drawing.Point(8, 288)
Me.Label286.Name = "Label286"
Me.Label286.Size = New System.Drawing.Size(80, 23)
Me.Label286.TabIndex = 203
Me.Label286.Text = "Alarm On Time"
'
'Label287
'
Me.Label287.Location = New System.Drawing.Point(8, 312)
Me.Label287.Name = "Label287"
Me.Label287.Size = New System.Drawing.Size(112, 32)
Me.Label287.TabIndex = 203
Me.Label287.Text = "Date Of Operating report"
'
'morPrevOperatingTime
'
Me.morPrevOperatingTime.Location = New System.Drawing.Point(136, 16)
Me.morPrevOperatingTime.Name = "morPrevOperatingTime"
Me.morPrevOperatingTime.TabIndex = 207
Me.morPrevOperatingTime.Text = "0"
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.Label240)
Me.GroupBox2.Controls.Add(Me.morOperatingTime)
Me.GroupBox2.Controls.Add(Me.Label264)
Me.GroupBox2.Controls.Add(Me.Label265)
Me.GroupBox2.Controls.Add(Me.Label266)
Me.GroupBox2.Controls.Add(Me.Label267)
Me.GroupBox2.Controls.Add(Me.Label268)
Me.GroupBox2.Controls.Add(Me.Label269)
Me.GroupBox2.Controls.Add(Me.morRunningTime)
Me.GroupBox2.Controls.Add(Me.morCuttingTime)
Me.GroupBox2.Controls.Add(Me.morNonOPeratingTime)
Me.GroupBox2.Controls.Add(Me.morInProSetupTime)
Me.GroupBox2.Controls.Add(Me.morNoOperatorTime)
Me.GroupBox2.Controls.Add(Me.morPartWaitingTime)
Me.GroupBox2.Controls.Add(Me.Label270)
Me.GroupBox2.Controls.Add(Me.mormaintenanceTime)
Me.GroupBox2.Controls.Add(Me.Label271)
Me.GroupBox2.Controls.Add(Me.morOtherTime)
Me.GroupBox2.Controls.Add(Me.Label272)
Me.GroupBox2.Controls.Add(Me.morSpindleRunTime)
Me.GroupBox2.Controls.Add(Me.Label273)
Me.GroupBox2.Controls.Add(Me.morExternalInputTime)
Me.GroupBox2.Controls.Add(Me.morAlarmOnTime)
Me.GroupBox2.Controls.Add(Me.Label274)
Me.GroupBox2.Controls.Add(Me.morDateOfOperatingReport)
Me.GroupBox2.Controls.Add(Me.Label275)
Me.GroupBox2.Location = New System.Drawing.Point(268, 74)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(248, 352)
Me.GroupBox2.TabIndex = 313
Me.GroupBox2.TabStop = false
Me.GroupBox2.Text = "Today Operating report"
'
'Label240
'
Me.Label240.Location = New System.Drawing.Point(8, 16)
Me.Label240.Name = "Label240"
Me.Label240.Size = New System.Drawing.Size(88, 23)
Me.Label240.TabIndex = 176
Me.Label240.Text = "Operating Time"
'
'morOperatingTime
'
Me.morOperatingTime.Location = New System.Drawing.Point(144, 16)
Me.morOperatingTime.Name = "morOperatingTime"
Me.morOperatingTime.Size = New System.Drawing.Size(96, 20)
Me.morOperatingTime.TabIndex = 179
Me.morOperatingTime.Text = "0"
'
'Label264
'
Me.Label264.Location = New System.Drawing.Point(8, 40)
Me.Label264.Name = "Label264"
Me.Label264.TabIndex = 177
Me.Label264.Text = "Runing Time"
'
'Label265
'
Me.Label265.Location = New System.Drawing.Point(8, 64)
Me.Label265.Name = "Label265"
Me.Label265.TabIndex = 178
Me.Label265.Text = "Cutting Time"
'
'Label266
'
Me.Label266.Location = New System.Drawing.Point(8, 88)
Me.Label266.Name = "Label266"
Me.Label266.Size = New System.Drawing.Size(120, 23)
Me.Label266.TabIndex = 182
Me.Label266.Text = "Non Operating Time"
'
'Label267
'
Me.Label267.Location = New System.Drawing.Point(8, 112)
Me.Label267.Name = "Label267"
Me.Label267.TabIndex = 183
Me.Label267.Text = "In Pro Setup Time"
'
'Label268
'
Me.Label268.Location = New System.Drawing.Point(8, 136)
Me.Label268.Name = "Label268"
Me.Label268.TabIndex = 184
Me.Label268.Text = "No Operator Time"
'
'Label269
'
Me.Label269.Location = New System.Drawing.Point(8, 160)
Me.Label269.Name = "Label269"
Me.Label269.TabIndex = 188
Me.Label269.Text = "Part waiting Time"
'
'morRunningTime
'
Me.morRunningTime.Location = New System.Drawing.Point(144, 40)
Me.morRunningTime.Name = "morRunningTime"
Me.morRunningTime.Size = New System.Drawing.Size(96, 20)
Me.morRunningTime.TabIndex = 180
Me.morRunningTime.Text = "0"
'
'morCuttingTime
'
Me.morCuttingTime.Location = New System.Drawing.Point(144, 64)
Me.morCuttingTime.Name = "morCuttingTime"
Me.morCuttingTime.Size = New System.Drawing.Size(96, 20)
Me.morCuttingTime.TabIndex = 181
Me.morCuttingTime.Text = "0"
'
'morNonOPeratingTime
'
Me.morNonOPeratingTime.Location = New System.Drawing.Point(144, 88)
Me.morNonOPeratingTime.Name = "morNonOPeratingTime"
Me.morNonOPeratingTime.Size = New System.Drawing.Size(96, 20)
Me.morNonOPeratingTime.TabIndex = 185
Me.morNonOPeratingTime.Text = "0"
'
'morInProSetupTime
'
Me.morInProSetupTime.Location = New System.Drawing.Point(144, 112)
Me.morInProSetupTime.Name = "morInProSetupTime"
Me.morInProSetupTime.Size = New System.Drawing.Size(96, 20)
Me.morInProSetupTime.TabIndex = 186
Me.morInProSetupTime.Text = "0"
'
'morNoOperatorTime
'
Me.morNoOperatorTime.Location = New System.Drawing.Point(144, 136)
Me.morNoOperatorTime.Name = "morNoOperatorTime"
Me.morNoOperatorTime.Size = New System.Drawing.Size(96, 20)
Me.morNoOperatorTime.TabIndex = 187
Me.morNoOperatorTime.Text = "0"
'
'morPartWaitingTime
'
Me.morPartWaitingTime.Location = New System.Drawing.Point(144, 160)
Me.morPartWaitingTime.Name = "morPartWaitingTime"
Me.morPartWaitingTime.Size = New System.Drawing.Size(96, 20)
Me.morPartWaitingTime.TabIndex = 191
Me.morPartWaitingTime.Text = "0"
'
'Label270
'
Me.Label270.Location = New System.Drawing.Point(8, 184)
Me.Label270.Name = "Label270"
Me.Label270.TabIndex = 189
Me.Label270.Text = "Maintenance Time"
'
'mormaintenanceTime
'
Me.mormaintenanceTime.Location = New System.Drawing.Point(144, 184)
Me.mormaintenanceTime.Name = "mormaintenanceTime"
Me.mormaintenanceTime.Size = New System.Drawing.Size(96, 20)
Me.mormaintenanceTime.TabIndex = 192
Me.mormaintenanceTime.Text = "0"
'
'Label271
'
Me.Label271.Location = New System.Drawing.Point(8, 208)
Me.Label271.Name = "Label271"
Me.Label271.TabIndex = 190
Me.Label271.Text = "Other Time"
'
'morOtherTime
'
Me.morOtherTime.Location = New System.Drawing.Point(144, 208)
Me.morOtherTime.Name = "morOtherTime"
Me.morOtherTime.Size = New System.Drawing.Size(96, 20)
Me.morOtherTime.TabIndex = 193
Me.morOtherTime.Text = "0"
'
'Label272
'
Me.Label272.Location = New System.Drawing.Point(8, 232)
Me.Label272.Name = "Label272"
Me.Label272.TabIndex = 194
Me.Label272.Text = "Spindle Run Time"
'
'morSpindleRunTime
'
Me.morSpindleRunTime.Location = New System.Drawing.Point(144, 232)
Me.morSpindleRunTime.Name = "morSpindleRunTime"
Me.morSpindleRunTime.Size = New System.Drawing.Size(96, 20)
Me.morSpindleRunTime.TabIndex = 199
Me.morSpindleRunTime.Text = "0"
'
'Label273
'
Me.Label273.Location = New System.Drawing.Point(8, 256)
Me.Label273.Name = "Label273"
Me.Label273.Size = New System.Drawing.Size(104, 23)
Me.Label273.TabIndex = 195
Me.Label273.Text = "External Input Time"
'
'morExternalInputTime
'
Me.morExternalInputTime.Location = New System.Drawing.Point(144, 256)
Me.morExternalInputTime.Name = "morExternalInputTime"
Me.morExternalInputTime.Size = New System.Drawing.Size(96, 20)
Me.morExternalInputTime.TabIndex = 200
Me.morExternalInputTime.Text = "0"
'
'morAlarmOnTime
'
Me.morAlarmOnTime.Location = New System.Drawing.Point(144, 280)
Me.morAlarmOnTime.Name = "morAlarmOnTime"
Me.morAlarmOnTime.Size = New System.Drawing.Size(96, 20)
Me.morAlarmOnTime.TabIndex = 201
Me.morAlarmOnTime.Text = "0"
'
'Label274
'
Me.Label274.Location = New System.Drawing.Point(8, 280)
Me.Label274.Name = "Label274"
Me.Label274.TabIndex = 196
Me.Label274.Text = "Alarm On Time"
'
'morDateOfOperatingReport
'
Me.morDateOfOperatingReport.Location = New System.Drawing.Point(144, 304)
Me.morDateOfOperatingReport.Name = "morDateOfOperatingReport"
Me.morDateOfOperatingReport.Size = New System.Drawing.Size(96, 20)
Me.morDateOfOperatingReport.TabIndex = 202
Me.morDateOfOperatingReport.Text = "0"
'
'Label275
'
Me.Label275.Location = New System.Drawing.Point(8, 304)
Me.Label275.Name = "Label275"
Me.Label275.Size = New System.Drawing.Size(112, 40)
Me.Label275.TabIndex = 197
Me.Label275.Text = "Date Of Operating report"
'
'GroupBox3
'
Me.GroupBox3.Controls.Add(Me.morPeriodDateOfOperatingReport)
Me.GroupBox3.Controls.Add(Me.morPeriodAlarmOnTime)
Me.GroupBox3.Controls.Add(Me.morPeriodExternalInputTime)
Me.GroupBox3.Controls.Add(Me.morPeriodSpindleRunTime)
Me.GroupBox3.Controls.Add(Me.morPeriodOtherTime)
Me.GroupBox3.Controls.Add(Me.morPeriodMaintenanceTime)
Me.GroupBox3.Controls.Add(Me.morPeriodNoOperatorTime)
Me.GroupBox3.Controls.Add(Me.morPeriodPartWaitingTime)
Me.GroupBox3.Controls.Add(Me.morPeriodInproSetupTime)
Me.GroupBox3.Controls.Add(Me.morPeriodNonOperatingTime)
Me.GroupBox3.Controls.Add(Me.morPeriodCuttingTime)
Me.GroupBox3.Controls.Add(Me.morPeriodRunningTime)
Me.GroupBox3.Controls.Add(Me.Label65)
Me.GroupBox3.Controls.Add(Me.Label109)
Me.GroupBox3.Controls.Add(Me.Label110)
Me.GroupBox3.Controls.Add(Me.Label111)
Me.GroupBox3.Controls.Add(Me.Label112)
Me.GroupBox3.Controls.Add(Me.Label130)
Me.GroupBox3.Controls.Add(Me.Label141)
Me.GroupBox3.Controls.Add(Me.Label153)
Me.GroupBox3.Controls.Add(Me.Label154)
Me.GroupBox3.Controls.Add(Me.Label155)
Me.GroupBox3.Controls.Add(Me.Label237)
Me.GroupBox3.Controls.Add(Me.Label238)
Me.GroupBox3.Controls.Add(Me.morPeriodOperatingTime)
Me.GroupBox3.Controls.Add(Me.Label239)
Me.GroupBox3.Location = New System.Drawing.Point(12, 74)
Me.GroupBox3.Name = "GroupBox3"
Me.GroupBox3.Size = New System.Drawing.Size(248, 352)
Me.GroupBox3.TabIndex = 312
Me.GroupBox3.TabStop = false
Me.GroupBox3.Text = "Period Operating Report"
'
'morPeriodDateOfOperatingReport
'
Me.morPeriodDateOfOperatingReport.Location = New System.Drawing.Point(144, 296)
Me.morPeriodDateOfOperatingReport.Name = "morPeriodDateOfOperatingReport"
Me.morPeriodDateOfOperatingReport.Size = New System.Drawing.Size(96, 20)
Me.morPeriodDateOfOperatingReport.TabIndex = 216
Me.morPeriodDateOfOperatingReport.Text = "0"
'
'morPeriodAlarmOnTime
'
Me.morPeriodAlarmOnTime.Location = New System.Drawing.Point(144, 272)
Me.morPeriodAlarmOnTime.Name = "morPeriodAlarmOnTime"
Me.morPeriodAlarmOnTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodAlarmOnTime.TabIndex = 215
Me.morPeriodAlarmOnTime.Text = "0"
'
'morPeriodExternalInputTime
'
Me.morPeriodExternalInputTime.Location = New System.Drawing.Point(144, 248)
Me.morPeriodExternalInputTime.Name = "morPeriodExternalInputTime"
Me.morPeriodExternalInputTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodExternalInputTime.TabIndex = 214
Me.morPeriodExternalInputTime.Text = "0"
'
'morPeriodSpindleRunTime
'
Me.morPeriodSpindleRunTime.Location = New System.Drawing.Point(144, 224)
Me.morPeriodSpindleRunTime.Name = "morPeriodSpindleRunTime"
Me.morPeriodSpindleRunTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodSpindleRunTime.TabIndex = 213
Me.morPeriodSpindleRunTime.Text = "0"
'
'morPeriodOtherTime
'
Me.morPeriodOtherTime.Location = New System.Drawing.Point(144, 200)
Me.morPeriodOtherTime.Name = "morPeriodOtherTime"
Me.morPeriodOtherTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodOtherTime.TabIndex = 212
Me.morPeriodOtherTime.Text = "0"
'
'morPeriodMaintenanceTime
'
Me.morPeriodMaintenanceTime.Location = New System.Drawing.Point(144, 176)
Me.morPeriodMaintenanceTime.Name = "morPeriodMaintenanceTime"
Me.morPeriodMaintenanceTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodMaintenanceTime.TabIndex = 211
Me.morPeriodMaintenanceTime.Text = "0"
'
'morPeriodNoOperatorTime
'
Me.morPeriodNoOperatorTime.Location = New System.Drawing.Point(144, 128)
Me.morPeriodNoOperatorTime.Name = "morPeriodNoOperatorTime"
Me.morPeriodNoOperatorTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodNoOperatorTime.TabIndex = 209
Me.morPeriodNoOperatorTime.Text = "0"
'
'morPeriodPartWaitingTime
'
Me.morPeriodPartWaitingTime.Location = New System.Drawing.Point(144, 152)
Me.morPeriodPartWaitingTime.Name = "morPeriodPartWaitingTime"
Me.morPeriodPartWaitingTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodPartWaitingTime.TabIndex = 208
Me.morPeriodPartWaitingTime.Text = "0"
'
'morPeriodInproSetupTime
'
Me.morPeriodInproSetupTime.Location = New System.Drawing.Point(144, 104)
Me.morPeriodInproSetupTime.Name = "morPeriodInproSetupTime"
Me.morPeriodInproSetupTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodInproSetupTime.TabIndex = 207
Me.morPeriodInproSetupTime.Text = "0"
'
'morPeriodNonOperatingTime
'
Me.morPeriodNonOperatingTime.Location = New System.Drawing.Point(144, 80)
Me.morPeriodNonOperatingTime.Name = "morPeriodNonOperatingTime"
Me.morPeriodNonOperatingTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodNonOperatingTime.TabIndex = 206
Me.morPeriodNonOperatingTime.Text = "0"
'
'morPeriodCuttingTime
'
Me.morPeriodCuttingTime.Location = New System.Drawing.Point(144, 56)
Me.morPeriodCuttingTime.Name = "morPeriodCuttingTime"
Me.morPeriodCuttingTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodCuttingTime.TabIndex = 205
Me.morPeriodCuttingTime.Text = "0"
'
'morPeriodRunningTime
'
Me.morPeriodRunningTime.Location = New System.Drawing.Point(144, 32)
Me.morPeriodRunningTime.Name = "morPeriodRunningTime"
Me.morPeriodRunningTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodRunningTime.TabIndex = 204
Me.morPeriodRunningTime.Text = "0"
'
'Label65
'
Me.Label65.Location = New System.Drawing.Point(8, 16)
Me.Label65.Name = "Label65"
Me.Label65.Size = New System.Drawing.Size(88, 23)
Me.Label65.TabIndex = 203
Me.Label65.Text = "Operating Time"
'
'Label109
'
Me.Label109.Location = New System.Drawing.Point(8, 40)
Me.Label109.Name = "Label109"
Me.Label109.TabIndex = 203
Me.Label109.Text = "Runing Time"
'
'Label110
'
Me.Label110.Location = New System.Drawing.Point(8, 64)
Me.Label110.Name = "Label110"
Me.Label110.TabIndex = 203
Me.Label110.Text = "Cutting Time"
'
'Label111
'
Me.Label111.Location = New System.Drawing.Point(8, 88)
Me.Label111.Name = "Label111"
Me.Label111.Size = New System.Drawing.Size(120, 23)
Me.Label111.TabIndex = 203
Me.Label111.Text = "Non Operating Time"
'
'Label112
'
Me.Label112.Location = New System.Drawing.Point(8, 112)
Me.Label112.Name = "Label112"
Me.Label112.TabIndex = 203
Me.Label112.Text = "In Pro Setup Time"
'
'Label130
'
Me.Label130.Location = New System.Drawing.Point(8, 136)
Me.Label130.Name = "Label130"
Me.Label130.TabIndex = 203
Me.Label130.Text = "No Operator Time"
'
'Label141
'
Me.Label141.Location = New System.Drawing.Point(8, 160)
Me.Label141.Name = "Label141"
Me.Label141.Size = New System.Drawing.Size(112, 23)
Me.Label141.TabIndex = 203
Me.Label141.Text = "Part waiting Time"
'
'Label153
'
Me.Label153.Location = New System.Drawing.Point(8, 184)
Me.Label153.Name = "Label153"
Me.Label153.TabIndex = 203
Me.Label153.Text = "Maintenance Time"
'
'Label154
'
Me.Label154.Location = New System.Drawing.Point(8, 208)
Me.Label154.Name = "Label154"
Me.Label154.TabIndex = 203
Me.Label154.Text = "Other Time"
'
'Label155
'
Me.Label155.Location = New System.Drawing.Point(8, 232)
Me.Label155.Name = "Label155"
Me.Label155.TabIndex = 203
Me.Label155.Text = "Spindle Run Time"
'
'Label237
'
Me.Label237.Location = New System.Drawing.Point(8, 256)
Me.Label237.Name = "Label237"
Me.Label237.Size = New System.Drawing.Size(104, 23)
Me.Label237.TabIndex = 203
Me.Label237.Text = "External Input Time"
'
'Label238
'
Me.Label238.Location = New System.Drawing.Point(16, 280)
Me.Label238.Name = "Label238"
Me.Label238.TabIndex = 203
Me.Label238.Text = "Alarm On Time"
'
'morPeriodOperatingTime
'
Me.morPeriodOperatingTime.Location = New System.Drawing.Point(144, 8)
Me.morPeriodOperatingTime.Name = "morPeriodOperatingTime"
Me.morPeriodOperatingTime.Size = New System.Drawing.Size(96, 20)
Me.morPeriodOperatingTime.TabIndex = 203
Me.morPeriodOperatingTime.Text = "0"
'
'Label239
'
Me.Label239.Location = New System.Drawing.Point(8, 304)
Me.Label239.Name = "Label239"
Me.Label239.Size = New System.Drawing.Size(120, 32)
Me.Label239.TabIndex = 203
Me.Label239.Text = "Date Of Operating report"
'
'tab_PLC
'
Me.tab_PLC.Controls.Add(Me.grpIOVariables)
Me.tab_PLC.Location = New System.Drawing.Point(4, 22)
Me.tab_PLC.Name = "tab_PLC"
Me.tab_PLC.Size = New System.Drawing.Size(776, 446)
Me.tab_PLC.TabIndex = 19
Me.tab_PLC.Text = "PLC"
'
'grpIOVariables
'
Me.grpIOVariables.Controls.Add(Me.Label297)
Me.grpIOVariables.Controls.Add(Me.cboIOVariableTypes)
Me.grpIOVariables.Controls.Add(Me.cmdIOGetBit)
Me.grpIOVariables.Controls.Add(Me.cmdIOGetWord)
Me.grpIOVariables.Controls.Add(Me.cmdIOGetLongWord)
Me.grpIOVariables.Controls.Add(Me.txtIOLongWord)
Me.grpIOVariables.Controls.Add(Me.txtIOWord)
Me.grpIOVariables.Controls.Add(Me.txtIOBit)
Me.grpIOVariables.Controls.Add(Me.Label296)
Me.grpIOVariables.Controls.Add(Me.txtIOBitNo)
Me.grpIOVariables.Controls.Add(Me.Label295)
Me.grpIOVariables.Controls.Add(Me.txtIOLongWordIndex)
Me.grpIOVariables.Controls.Add(Me.Label294)
Me.grpIOVariables.Controls.Add(Me.txtIOWordIndex)
Me.grpIOVariables.Controls.Add(Me.Label293)
Me.grpIOVariables.Controls.Add(Me.txtIOBitIndex)
Me.grpIOVariables.Controls.Add(Me.Label292)
Me.grpIOVariables.Location = New System.Drawing.Point(8, 8)
Me.grpIOVariables.Name = "grpIOVariables"
Me.grpIOVariables.Size = New System.Drawing.Size(408, 192)
Me.grpIOVariables.TabIndex = 235
Me.grpIOVariables.TabStop = false
Me.grpIOVariables.Text = "I/O Variables"
'
'Label297
'
Me.Label297.Location = New System.Drawing.Point(96, 16)
Me.Label297.Name = "Label297"
Me.Label297.Size = New System.Drawing.Size(120, 24)
Me.Label297.TabIndex = 198
Me.Label297.Text = "I/O Type:"
'
'cboIOVariableTypes
'
Me.cboIOVariableTypes.Location = New System.Drawing.Point(224, 16)
Me.cboIOVariableTypes.Name = "cboIOVariableTypes"
Me.cboIOVariableTypes.Size = New System.Drawing.Size(176, 20)
Me.cboIOVariableTypes.TabIndex = 197
'
'cmdIOGetBit
'
Me.cmdIOGetBit.Location = New System.Drawing.Point(360, 80)
Me.cmdIOGetBit.Name = "cmdIOGetBit"
Me.cmdIOGetBit.Size = New System.Drawing.Size(40, 24)
Me.cmdIOGetBit.TabIndex = 196
Me.cmdIOGetBit.Text = "Get"
'
'cmdIOGetWord
'
Me.cmdIOGetWord.Location = New System.Drawing.Point(360, 120)
Me.cmdIOGetWord.Name = "cmdIOGetWord"
Me.cmdIOGetWord.Size = New System.Drawing.Size(40, 24)
Me.cmdIOGetWord.TabIndex = 193
Me.cmdIOGetWord.Text = "Get"
'
'cmdIOGetLongWord
'
Me.cmdIOGetLongWord.Location = New System.Drawing.Point(360, 160)
Me.cmdIOGetLongWord.Name = "cmdIOGetLongWord"
Me.cmdIOGetLongWord.Size = New System.Drawing.Size(40, 24)
Me.cmdIOGetLongWord.TabIndex = 190
Me.cmdIOGetLongWord.Text = "Get"
'
'txtIOLongWord
'
Me.txtIOLongWord.Location = New System.Drawing.Point(232, 160)
Me.txtIOLongWord.Name = "txtIOLongWord"
Me.txtIOLongWord.ReadOnly = true
Me.txtIOLongWord.Size = New System.Drawing.Size(120, 20)
Me.txtIOLongWord.TabIndex = 11
Me.txtIOLongWord.Text = "0"
'
'txtIOWord
'
Me.txtIOWord.Location = New System.Drawing.Point(232, 120)
Me.txtIOWord.Name = "txtIOWord"
Me.txtIOWord.ReadOnly = true
Me.txtIOWord.Size = New System.Drawing.Size(64, 20)
Me.txtIOWord.TabIndex = 10
Me.txtIOWord.Text = "0"
'
'txtIOBit
'
Me.txtIOBit.Location = New System.Drawing.Point(232, 80)
Me.txtIOBit.Name = "txtIOBit"
Me.txtIOBit.ReadOnly = true
Me.txtIOBit.Size = New System.Drawing.Size(24, 20)
Me.txtIOBit.TabIndex = 9
Me.txtIOBit.Text = "0"
'
'Label296
'
Me.Label296.Location = New System.Drawing.Point(168, 48)
Me.Label296.Name = "Label296"
Me.Label296.Size = New System.Drawing.Size(48, 23)
Me.Label296.TabIndex = 8
Me.Label296.Text = "Bit No."
'
'txtIOBitNo
'
Me.txtIOBitNo.Location = New System.Drawing.Point(168, 80)
Me.txtIOBitNo.Name = "txtIOBitNo"
Me.txtIOBitNo.Size = New System.Drawing.Size(48, 20)
Me.txtIOBitNo.TabIndex = 7
Me.txtIOBitNo.Text = "0"
'
'Label295
'
Me.Label295.Location = New System.Drawing.Point(104, 48)
Me.Label295.Name = "Label295"
Me.Label295.Size = New System.Drawing.Size(48, 23)
Me.Label295.TabIndex = 6
Me.Label295.Text = "Index"
'
'txtIOLongWordIndex
'
Me.txtIOLongWordIndex.Location = New System.Drawing.Point(104, 160)
Me.txtIOLongWordIndex.Name = "txtIOLongWordIndex"
Me.txtIOLongWordIndex.Size = New System.Drawing.Size(48, 20)
Me.txtIOLongWordIndex.TabIndex = 5
Me.txtIOLongWordIndex.Text = "1"
'
'Label294
'
Me.Label294.Location = New System.Drawing.Point(8, 160)
Me.Label294.Name = "Label294"
Me.Label294.Size = New System.Drawing.Size(88, 24)
Me.Label294.TabIndex = 4
Me.Label294.Text = "Long Word I/O"
'
'txtIOWordIndex
'
Me.txtIOWordIndex.Location = New System.Drawing.Point(104, 120)
Me.txtIOWordIndex.Name = "txtIOWordIndex"
Me.txtIOWordIndex.Size = New System.Drawing.Size(48, 20)
Me.txtIOWordIndex.TabIndex = 3
Me.txtIOWordIndex.Text = "1"
'
'Label293
'
Me.Label293.Location = New System.Drawing.Point(8, 120)
Me.Label293.Name = "Label293"
Me.Label293.Size = New System.Drawing.Size(64, 24)
Me.Label293.TabIndex = 2
Me.Label293.Text = "Word I/O"
'
'txtIOBitIndex
'
Me.txtIOBitIndex.Location = New System.Drawing.Point(104, 80)
Me.txtIOBitIndex.Name = "txtIOBitIndex"
Me.txtIOBitIndex.Size = New System.Drawing.Size(48, 20)
Me.txtIOBitIndex.TabIndex = 1
Me.txtIOBitIndex.Text = "1"
'
'Label292
'
Me.Label292.Location = New System.Drawing.Point(8, 80)
Me.Label292.Name = "Label292"
Me.Label292.Size = New System.Drawing.Size(64, 24)
Me.Label292.TabIndex = 0
Me.Label292.Text = "Bit I/O"
'
'tab_workpiece
'
Me.tab_workpiece.Controls.Add(Me.wkSetDataUnitButton)
Me.tab_workpiece.Controls.Add(Me.wkDataUnitCombo)
Me.tab_workpiece.Controls.Add(Me.Label152)
Me.tab_workpiece.Controls.Add(Me.Label129)
Me.tab_workpiece.Controls.Add(Me.wkZeroTo)
Me.tab_workpiece.Controls.Add(Me.Label127)
Me.tab_workpiece.Controls.Add(Me.wkZeroFrom)
Me.tab_workpiece.Controls.Add(Me.Label128)
Me.tab_workpiece.Controls.Add(Me.wkZeroResults)
Me.tab_workpiece.Controls.Add(Me.wkButtonGetCounter)
Me.tab_workpiece.Controls.Add(Me.Label97)
Me.tab_workpiece.Controls.Add(Me.Label96)
Me.tab_workpiece.Controls.Add(Me.wkUpdateValsWithNoParams)
Me.tab_workpiece.Controls.Add(Me.wkValsWithoutParameters)
Me.tab_workpiece.Controls.Add(Me.wkCounterSetButton)
Me.tab_workpiece.Controls.Add(Me.wkCounterValue)
Me.tab_workpiece.Controls.Add(Me.Label95)
Me.tab_workpiece.Controls.Add(Me.wkUpdateCounter)
Me.tab_workpiece.Controls.Add(Me.wkCounterCombo)
Me.tab_workpiece.Controls.Add(Me.wkUpdateZeroOffset)
Me.tab_workpiece.Controls.Add(Me.wkZeroOffset)
Me.tab_workpiece.Controls.Add(Me.Label94)
Me.tab_workpiece.Controls.Add(Me.wkAxisCombo)
Me.tab_workpiece.Controls.Add(Me.Panel9)
Me.tab_workpiece.Controls.Add(Me.Panel10)
Me.tab_workpiece.Location = New System.Drawing.Point(4, 22)
Me.tab_workpiece.Name = "tab_workpiece"
Me.tab_workpiece.Size = New System.Drawing.Size(776, 446)
Me.tab_workpiece.TabIndex = 11
Me.tab_workpiece.Text = "Workpiece"
'
'wkSetDataUnitButton
'
Me.wkSetDataUnitButton.Location = New System.Drawing.Point(224, 312)
Me.wkSetDataUnitButton.Name = "wkSetDataUnitButton"
Me.wkSetDataUnitButton.Size = New System.Drawing.Size(48, 23)
Me.wkSetDataUnitButton.TabIndex = 191
Me.wkSetDataUnitButton.Text = "Set"
'
'wkDataUnitCombo
'
Me.wkDataUnitCombo.Location = New System.Drawing.Point(88, 312)
Me.wkDataUnitCombo.Name = "wkDataUnitCombo"
Me.wkDataUnitCombo.TabIndex = 190
'
'Label152
'
Me.Label152.Location = New System.Drawing.Point(16, 312)
Me.Label152.Name = "Label152"
Me.Label152.Size = New System.Drawing.Size(72, 23)
Me.Label152.TabIndex = 189
Me.Label152.Text = "Data Unit"
'
'Label129
'
Me.Label129.Location = New System.Drawing.Point(352, 184)
Me.Label129.Name = "Label129"
Me.Label129.Size = New System.Drawing.Size(80, 16)
Me.Label129.TabIndex = 188
Me.Label129.Text = "Zero Offsets :"
'
'wkZeroTo
'
Me.wkZeroTo.Location = New System.Drawing.Point(496, 208)
Me.wkZeroTo.Name = "wkZeroTo"
Me.wkZeroTo.Size = New System.Drawing.Size(64, 20)
Me.wkZeroTo.TabIndex = 186
Me.wkZeroTo.Text = "2"
'
'Label127
'
Me.Label127.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label127.Location = New System.Drawing.Point(440, 208)
Me.Label127.Name = "Label127"
Me.Label127.Size = New System.Drawing.Size(48, 16)
Me.Label127.TabIndex = 185
Me.Label127.Text = "To"
'
'wkZeroFrom
'
Me.wkZeroFrom.Location = New System.Drawing.Point(496, 184)
Me.wkZeroFrom.Name = "wkZeroFrom"
Me.wkZeroFrom.Size = New System.Drawing.Size(64, 20)
Me.wkZeroFrom.TabIndex = 184
Me.wkZeroFrom.Text = "1"
'
'Label128
'
Me.Label128.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label128.Location = New System.Drawing.Point(440, 184)
Me.Label128.Name = "Label128"
Me.Label128.Size = New System.Drawing.Size(48, 16)
Me.Label128.TabIndex = 183
Me.Label128.Text = "From"
'
'wkZeroResults
'
Me.wkZeroResults.Location = New System.Drawing.Point(568, 184)
Me.wkZeroResults.Multiline = true
Me.wkZeroResults.Name = "wkZeroResults"
Me.wkZeroResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.wkZeroResults.Size = New System.Drawing.Size(164, 184)
Me.wkZeroResults.TabIndex = 182
Me.wkZeroResults.Text = ""
'
'wkButtonGetCounter
'
Me.wkButtonGetCounter.Location = New System.Drawing.Point(152, 64)
Me.wkButtonGetCounter.Name = "wkButtonGetCounter"
Me.wkButtonGetCounter.Size = New System.Drawing.Size(40, 24)
Me.wkButtonGetCounter.TabIndex = 174
Me.wkButtonGetCounter.Text = "Get"
'
'Label97
'
Me.Label97.Location = New System.Drawing.Point(16, 136)
Me.Label97.Name = "Label97"
Me.Label97.Size = New System.Drawing.Size(40, 16)
Me.Label97.TabIndex = 171
Me.Label97.Text = "Axis :"
'
'Label96
'
Me.Label96.Location = New System.Drawing.Point(480, 8)
Me.Label96.Name = "Label96"
Me.Label96.Size = New System.Drawing.Size(80, 32)
Me.Label96.TabIndex = 170
Me.Label96.Text = "Values with no parameters :"
Me.Label96.TextAlign = System.Drawing.ContentAlignment.TopRight
'
'wkUpdateValsWithNoParams
'
Me.wkUpdateValsWithNoParams.Location = New System.Drawing.Point(488, 240)
Me.wkUpdateValsWithNoParams.Name = "wkUpdateValsWithNoParams"
Me.wkUpdateValsWithNoParams.Size = New System.Drawing.Size(72, 24)
Me.wkUpdateValsWithNoParams.TabIndex = 169
Me.wkUpdateValsWithNoParams.Text = "Update"
'
'wkValsWithoutParameters
'
Me.wkValsWithoutParameters.Location = New System.Drawing.Point(488, 40)
Me.wkValsWithoutParameters.Multiline = true
Me.wkValsWithoutParameters.Name = "wkValsWithoutParameters"
Me.wkValsWithoutParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.wkValsWithoutParameters.Size = New System.Drawing.Size(248, 128)
Me.wkValsWithoutParameters.TabIndex = 168
Me.wkValsWithoutParameters.Text = ""
'
'wkCounterSetButton
'
Me.wkCounterSetButton.Location = New System.Drawing.Point(224, 64)
Me.wkCounterSetButton.Name = "wkCounterSetButton"
Me.wkCounterSetButton.Size = New System.Drawing.Size(40, 24)
Me.wkCounterSetButton.TabIndex = 167
Me.wkCounterSetButton.Text = "Set"
'
'wkCounterValue
'
Me.wkCounterValue.Enabled = false
Me.wkCounterValue.Location = New System.Drawing.Point(128, 32)
Me.wkCounterValue.Name = "wkCounterValue"
Me.wkCounterValue.Size = New System.Drawing.Size(64, 20)
Me.wkCounterValue.TabIndex = 166
Me.wkCounterValue.Text = "0"
'
'Label95
'
Me.Label95.Location = New System.Drawing.Point(16, 32)
Me.Label95.Name = "Label95"
Me.Label95.Size = New System.Drawing.Size(136, 16)
Me.Label95.TabIndex = 165
Me.Label95.Text = "Workpiece Counter"
'
'wkUpdateCounter
'
Me.wkUpdateCounter.ForeColor = System.Drawing.Color.Red
Me.wkUpdateCounter.Location = New System.Drawing.Point(200, 32)
Me.wkUpdateCounter.Name = "wkUpdateCounter"
Me.wkUpdateCounter.Size = New System.Drawing.Size(64, 20)
Me.wkUpdateCounter.TabIndex = 164
Me.wkUpdateCounter.Text = "0"
'
'wkCounterCombo
'
Me.wkCounterCombo.Location = New System.Drawing.Point(280, 32)
Me.wkCounterCombo.Name = "wkCounterCombo"
Me.wkCounterCombo.Size = New System.Drawing.Size(96, 20)
Me.wkCounterCombo.TabIndex = 163
'
'wkUpdateZeroOffset
'
Me.wkUpdateZeroOffset.ForeColor = System.Drawing.Color.Red
Me.wkUpdateZeroOffset.Location = New System.Drawing.Point(176, 232)
Me.wkUpdateZeroOffset.Name = "wkUpdateZeroOffset"
Me.wkUpdateZeroOffset.Size = New System.Drawing.Size(64, 20)
Me.wkUpdateZeroOffset.TabIndex = 159
Me.wkUpdateZeroOffset.Text = "0.00"
'
'wkZeroOffset
'
Me.wkZeroOffset.Location = New System.Drawing.Point(104, 232)
Me.wkZeroOffset.Name = "wkZeroOffset"
Me.wkZeroOffset.Size = New System.Drawing.Size(64, 20)
Me.wkZeroOffset.TabIndex = 158
Me.wkZeroOffset.Text = "0.00"
'
'Label94
'
Me.Label94.Location = New System.Drawing.Point(16, 232)
Me.Label94.Name = "Label94"
Me.Label94.Size = New System.Drawing.Size(80, 16)
Me.Label94.TabIndex = 157
Me.Label94.Text = "Zero Offsets :"
'
'wkAxisCombo
'
Me.wkAxisCombo.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6"})
Me.wkAxisCombo.Location = New System.Drawing.Point(72, 136)
Me.wkAxisCombo.Name = "wkAxisCombo"
Me.wkAxisCombo.Size = New System.Drawing.Size(120, 20)
Me.wkAxisCombo.TabIndex = 15
'
'Panel9
'
Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel9.Controls.Add(Me.wkButtonZeroOffsetGet)
Me.Panel9.Controls.Add(Me.wkButtonZeroOffsetCal)
Me.Panel9.Controls.Add(Me.wkButtonZeroOffsetAdd)
Me.Panel9.Controls.Add(Me.wkButtonZeroOffsetSet)
Me.Panel9.Controls.Add(Me.wkOffsetNumber)
Me.Panel9.Controls.Add(Me.Label93)
Me.Panel9.Location = New System.Drawing.Point(8, 120)
Me.Panel9.Name = "Panel9"
Me.Panel9.Size = New System.Drawing.Size(280, 168)
Me.Panel9.TabIndex = 173
'
'wkButtonZeroOffsetGet
'
Me.wkButtonZeroOffsetGet.Location = New System.Drawing.Point(136, 72)
Me.wkButtonZeroOffsetGet.Name = "wkButtonZeroOffsetGet"
Me.wkButtonZeroOffsetGet.Size = New System.Drawing.Size(40, 24)
Me.wkButtonZeroOffsetGet.TabIndex = 172
Me.wkButtonZeroOffsetGet.Text = "Get"
'
'wkButtonZeroOffsetCal
'
Me.wkButtonZeroOffsetCal.Location = New System.Drawing.Point(192, 136)
Me.wkButtonZeroOffsetCal.Name = "wkButtonZeroOffsetCal"
Me.wkButtonZeroOffsetCal.Size = New System.Drawing.Size(40, 24)
Me.wkButtonZeroOffsetCal.TabIndex = 162
Me.wkButtonZeroOffsetCal.Text = "Cal"
'
'wkButtonZeroOffsetAdd
'
Me.wkButtonZeroOffsetAdd.Location = New System.Drawing.Point(144, 136)
Me.wkButtonZeroOffsetAdd.Name = "wkButtonZeroOffsetAdd"
Me.wkButtonZeroOffsetAdd.Size = New System.Drawing.Size(40, 24)
Me.wkButtonZeroOffsetAdd.TabIndex = 161
Me.wkButtonZeroOffsetAdd.Text = "Add"
'
'wkButtonZeroOffsetSet
'
Me.wkButtonZeroOffsetSet.Location = New System.Drawing.Point(96, 136)
Me.wkButtonZeroOffsetSet.Name = "wkButtonZeroOffsetSet"
Me.wkButtonZeroOffsetSet.Size = New System.Drawing.Size(40, 24)
Me.wkButtonZeroOffsetSet.TabIndex = 160
Me.wkButtonZeroOffsetSet.Text = "Set"
'
'wkOffsetNumber
'
Me.wkOffsetNumber.Location = New System.Drawing.Point(120, 48)
Me.wkOffsetNumber.Name = "wkOffsetNumber"
Me.wkOffsetNumber.Size = New System.Drawing.Size(64, 20)
Me.wkOffsetNumber.TabIndex = 177
Me.wkOffsetNumber.Text = "1"
'
'Label93
'
Me.Label93.Location = New System.Drawing.Point(8, 48)
Me.Label93.Name = "Label93"
Me.Label93.Size = New System.Drawing.Size(88, 16)
Me.Label93.TabIndex = 176
Me.Label93.Text = "Offset Number :"
'
'Panel10
'
Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.Panel10.Controls.Add(Me.cmd_WorkpieceAdd)
Me.Panel10.Location = New System.Drawing.Point(8, 8)
Me.Panel10.Name = "Panel10"
Me.Panel10.Size = New System.Drawing.Size(400, 104)
Me.Panel10.TabIndex = 175
'
'cmd_WorkpieceAdd
'
Me.cmd_WorkpieceAdd.Location = New System.Drawing.Point(264, 56)
Me.cmd_WorkpieceAdd.Name = "cmd_WorkpieceAdd"
Me.cmd_WorkpieceAdd.Size = New System.Drawing.Size(40, 24)
Me.cmd_WorkpieceAdd.TabIndex = 162
Me.cmd_WorkpieceAdd.Text = "Add"
'
'tab_coolant
'
Me.tab_coolant.Controls.Add(Me.coolantUpdateButton)
Me.tab_coolant.Controls.Add(Me.coolantChipCondition)
Me.tab_coolant.Controls.Add(Me.Label36)
Me.tab_coolant.Location = New System.Drawing.Point(4, 22)
Me.tab_coolant.Name = "tab_coolant"
Me.tab_coolant.Size = New System.Drawing.Size(776, 446)
Me.tab_coolant.TabIndex = 4
Me.tab_coolant.Text = "Coolant"
'
'coolantUpdateButton
'
Me.coolantUpdateButton.Location = New System.Drawing.Point(288, 32)
Me.coolantUpdateButton.Name = "coolantUpdateButton"
Me.coolantUpdateButton.Size = New System.Drawing.Size(104, 24)
Me.coolantUpdateButton.TabIndex = 78
Me.coolantUpdateButton.Text = "Update"
'
'coolantChipCondition
'
Me.coolantChipCondition.BackColor = System.Drawing.SystemColors.Control
Me.coolantChipCondition.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.coolantChipCondition.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.coolantChipCondition.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.coolantChipCondition.Location = New System.Drawing.Point(380, 120)
Me.coolantChipCondition.Name = "coolantChipCondition"
Me.coolantChipCondition.Size = New System.Drawing.Size(160, 24)
Me.coolantChipCondition.TabIndex = 77
Me.coolantChipCondition.Text = ""
'
'Label36
'
Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label36.Location = New System.Drawing.Point(180, 120)
Me.Label36.Name = "Label36"
Me.Label36.Size = New System.Drawing.Size(184, 16)
Me.Label36.TabIndex = 76
Me.Label36.Text = "Chip Flush Condition :"
'
'tab_spindle
'
Me.tab_spindle.Controls.Add(Me.spinState)
Me.tab_spindle.Controls.Add(Me.Label73)
Me.tab_spindle.Controls.Add(Me.spinUpdate)
Me.tab_spindle.Controls.Add(Me.spinRateOverride)
Me.tab_spindle.Controls.Add(Me.Label67)
Me.tab_spindle.Controls.Add(Me.spinLoad)
Me.tab_spindle.Controls.Add(Me.Label68)
Me.tab_spindle.Controls.Add(Me.spinOilMist)
Me.tab_spindle.Controls.Add(Me.Label69)
Me.tab_spindle.Controls.Add(Me.spinMaxOverrideRate)
Me.tab_spindle.Controls.Add(Me.Label70)
Me.tab_spindle.Controls.Add(Me.spinCommandRate)
Me.tab_spindle.Controls.Add(Me.Label71)
Me.tab_spindle.Controls.Add(Me.spinActualRate)
Me.tab_spindle.Controls.Add(Me.Label72)
Me.tab_spindle.Location = New System.Drawing.Point(4, 22)
Me.tab_spindle.Name = "tab_spindle"
Me.tab_spindle.Size = New System.Drawing.Size(776, 446)
Me.tab_spindle.TabIndex = 8
Me.tab_spindle.Text = "Spindle"
'
'spinState
'
Me.spinState.BackColor = System.Drawing.SystemColors.Control
Me.spinState.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinState.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.spinState.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinState.Location = New System.Drawing.Point(256, 296)
Me.spinState.Name = "spinState"
Me.spinState.Size = New System.Drawing.Size(400, 24)
Me.spinState.TabIndex = 63
Me.spinState.Text = ""
'
'Label73
'
Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label73.Location = New System.Drawing.Point(16, 296)
Me.Label73.Name = "Label73"
Me.Label73.Size = New System.Drawing.Size(144, 16)
Me.Label73.TabIndex = 62
Me.Label73.Text = "Spindle State :"
'
'spinUpdate
'
Me.spinUpdate.Location = New System.Drawing.Point(320, 56)
Me.spinUpdate.Name = "spinUpdate"
Me.spinUpdate.Size = New System.Drawing.Size(104, 24)
Me.spinUpdate.TabIndex = 61
Me.spinUpdate.Text = "Update"
'
'spinRateOverride
'
Me.spinRateOverride.BackColor = System.Drawing.SystemColors.Control
Me.spinRateOverride.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinRateOverride.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.spinRateOverride.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinRateOverride.Location = New System.Drawing.Point(256, 264)
Me.spinRateOverride.Name = "spinRateOverride"
Me.spinRateOverride.Size = New System.Drawing.Size(160, 24)
Me.spinRateOverride.TabIndex = 60
Me.spinRateOverride.Text = "0"
'
'Label67
'
Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label67.Location = New System.Drawing.Point(16, 264)
Me.Label67.Name = "Label67"
Me.Label67.Size = New System.Drawing.Size(144, 16)
Me.Label67.TabIndex = 59
Me.Label67.Text = "Spindle Rate Override :"
'
'spinLoad
'
Me.spinLoad.BackColor = System.Drawing.SystemColors.Control
Me.spinLoad.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinLoad.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.spinLoad.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinLoad.Location = New System.Drawing.Point(256, 232)
Me.spinLoad.Name = "spinLoad"
Me.spinLoad.Size = New System.Drawing.Size(160, 24)
Me.spinLoad.TabIndex = 58
Me.spinLoad.Text = "0.00"
'
'Label68
'
Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label68.Location = New System.Drawing.Point(16, 232)
Me.Label68.Name = "Label68"
Me.Label68.Size = New System.Drawing.Size(96, 16)
Me.Label68.TabIndex = 57
Me.Label68.Text = "Spindle Load:"
'
'spinOilMist
'
Me.spinOilMist.BackColor = System.Drawing.SystemColors.Control
Me.spinOilMist.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinOilMist.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.spinOilMist.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinOilMist.Location = New System.Drawing.Point(256, 200)
Me.spinOilMist.Name = "spinOilMist"
Me.spinOilMist.Size = New System.Drawing.Size(160, 24)
Me.spinOilMist.TabIndex = 56
Me.spinOilMist.Text = ""
'
'Label69
'
Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label69.Location = New System.Drawing.Point(16, 200)
Me.Label69.Name = "Label69"
Me.Label69.Size = New System.Drawing.Size(208, 16)
Me.Label69.TabIndex = 55
Me.Label69.Text = "Oil Mist Condition :"
'
'spinMaxOverrideRate
'
Me.spinMaxOverrideRate.BackColor = System.Drawing.SystemColors.Control
Me.spinMaxOverrideRate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinMaxOverrideRate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.spinMaxOverrideRate.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinMaxOverrideRate.Location = New System.Drawing.Point(256, 168)
Me.spinMaxOverrideRate.Name = "spinMaxOverrideRate"
Me.spinMaxOverrideRate.Size = New System.Drawing.Size(160, 24)
Me.spinMaxOverrideRate.TabIndex = 54
Me.spinMaxOverrideRate.Text = "0"
'
'Label70
'
Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label70.Location = New System.Drawing.Point(16, 168)
Me.Label70.Name = "Label70"
Me.Label70.Size = New System.Drawing.Size(208, 16)
Me.Label70.TabIndex = 53
Me.Label70.Text = "Max Spindle Rate Override :"
'
'spinCommandRate
'
Me.spinCommandRate.BackColor = System.Drawing.SystemColors.Control
Me.spinCommandRate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinCommandRate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.spinCommandRate.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinCommandRate.Location = New System.Drawing.Point(256, 136)
Me.spinCommandRate.Name = "spinCommandRate"
Me.spinCommandRate.Size = New System.Drawing.Size(160, 24)
Me.spinCommandRate.TabIndex = 52
Me.spinCommandRate.Text = "0"
'
'Label71
'
Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label71.Location = New System.Drawing.Point(16, 136)
Me.Label71.Name = "Label71"
Me.Label71.Size = New System.Drawing.Size(208, 16)
Me.Label71.TabIndex = 51
Me.Label71.Text = "Command Spindle Rate :"
'
'spinActualRate
'
Me.spinActualRate.BackColor = System.Drawing.SystemColors.Control
Me.spinActualRate.BorderStyle = System.Windows.Forms.BorderStyle.None
Me.spinActualRate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
Me.spinActualRate.ForeColor = System.Drawing.Color.FromArgb(CType(0,Byte), CType(0,Byte), CType(192,Byte))
Me.spinActualRate.Location = New System.Drawing.Point(256, 104)
Me.spinActualRate.Name = "spinActualRate"
Me.spinActualRate.Size = New System.Drawing.Size(160, 24)
Me.spinActualRate.TabIndex = 50
Me.spinActualRate.Text = "0"
'
'Label72
'
Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.Label72.Location = New System.Drawing.Point(16, 104)
Me.Label72.Name = "Label72"
Me.Label72.Size = New System.Drawing.Size(200, 16)
Me.Label72.TabIndex = 49
Me.Label72.Text = "Actual Spindle Rate :"
'
'tab_variables
'
Me.tab_variables.Controls.Add(Me.Label90)
Me.tab_variables.Controls.Add(Me.varValue)
Me.tab_variables.Controls.Add(Me.varUpdateButton)
Me.tab_variables.Controls.Add(Me.varGetAllButton)
Me.tab_variables.Controls.Add(Me.Label89)
Me.tab_variables.Controls.Add(Me.varNumberOfVars)
Me.tab_variables.Controls.Add(Me.varGetAllResults)
Me.tab_variables.Controls.Add(Me.varAddValue)
Me.tab_variables.Controls.Add(Me.varSetValue)
Me.tab_variables.Controls.Add(Me.varEnd)
Me.tab_variables.Controls.Add(Me.varBegin)
Me.tab_variables.Controls.Add(Me.varValueUpdate)
Me.tab_variables.Controls.Add(Me.Label91)
Me.tab_variables.Controls.Add(Me.varCommonVarNumber)
Me.tab_variables.Controls.Add(Me.Label92)
Me.tab_variables.Location = New System.Drawing.Point(4, 22)
Me.tab_variables.Name = "tab_variables"
Me.tab_variables.Size = New System.Drawing.Size(776, 446)
Me.tab_variables.TabIndex = 10
Me.tab_variables.Text = "Variables"
'
'Label90
'
Me.Label90.Location = New System.Drawing.Point(16, 96)
Me.Label90.Name = "Label90"
Me.Label90.Size = New System.Drawing.Size(152, 16)
Me.Label90.TabIndex = 185
Me.Label90.Text = "Common Variable Value"
'
'varValue
'
Me.varValue.Location = New System.Drawing.Point(168, 96)
Me.varValue.Name = "varValue"
Me.varValue.Size = New System.Drawing.Size(64, 20)
Me.varValue.TabIndex = 184
Me.varValue.Text = "1"
'
'varUpdateButton
'
Me.varUpdateButton.Location = New System.Drawing.Point(232, 32)
Me.varUpdateButton.Name = "varUpdateButton"
Me.varUpdateButton.Size = New System.Drawing.Size(72, 24)
Me.varUpdateButton.TabIndex = 183
Me.varUpdateButton.Text = "Update"
'
'varGetAllButton
'
Me.varGetAllButton.Location = New System.Drawing.Point(472, 144)
Me.varGetAllButton.Name = "varGetAllButton"
Me.varGetAllButton.Size = New System.Drawing.Size(72, 24)
Me.varGetAllButton.TabIndex = 182
Me.varGetAllButton.Text = "Get All -->"
'
'Label89
'
Me.Label89.Location = New System.Drawing.Point(16, 64)
Me.Label89.Name = "Label89"
Me.Label89.Size = New System.Drawing.Size(156, 16)
Me.Label89.TabIndex = 181
Me.Label89.Text = "Number of Common Variables"
'
'varNumberOfVars
'
Me.varNumberOfVars.Location = New System.Drawing.Point(184, 64)
Me.varNumberOfVars.Name = "varNumberOfVars"
Me.varNumberOfVars.Size = New System.Drawing.Size(44, 20)
Me.varNumberOfVars.TabIndex = 180
Me.varNumberOfVars.Text = "0"
'
'varGetAllResults
'
Me.varGetAllResults.Location = New System.Drawing.Point(560, 16)
Me.varGetAllResults.Multiline = true
Me.varGetAllResults.Name = "varGetAllResults"
Me.varGetAllResults.Size = New System.Drawing.Size(176, 344)
Me.varGetAllResults.TabIndex = 179
Me.varGetAllResults.Text = ""
'
'varAddValue
'
Me.varAddValue.Location = New System.Drawing.Point(360, 96)
Me.varAddValue.Name = "varAddValue"
Me.varAddValue.Size = New System.Drawing.Size(40, 24)
Me.varAddValue.TabIndex = 178
Me.varAddValue.Text = "Add"
'
'varSetValue
'
Me.varSetValue.Location = New System.Drawing.Point(312, 96)
Me.varSetValue.Name = "varSetValue"
Me.varSetValue.Size = New System.Drawing.Size(40, 24)
Me.varSetValue.TabIndex = 177
Me.varSetValue.Text = "Set"
'
'varEnd
'
Me.varEnd.Location = New System.Drawing.Point(384, 144)
Me.varEnd.Name = "varEnd"
Me.varEnd.Size = New System.Drawing.Size(64, 20)
Me.varEnd.TabIndex = 76
Me.varEnd.Text = "10"
'
'varBegin
'
Me.varBegin.Location = New System.Drawing.Point(240, 144)
Me.varBegin.Name = "varBegin"
Me.varBegin.Size = New System.Drawing.Size(64, 20)
Me.varBegin.TabIndex = 73
Me.varBegin.Text = "1"
'
'varValueUpdate
'
Me.varValueUpdate.ForeColor = System.Drawing.Color.Red
Me.varValueUpdate.Location = New System.Drawing.Point(240, 96)
Me.varValueUpdate.Name = "varValueUpdate"
Me.varValueUpdate.Size = New System.Drawing.Size(64, 20)
Me.varValueUpdate.TabIndex = 71
Me.varValueUpdate.Text = "0"
'
'Label91
'
Me.Label91.Location = New System.Drawing.Point(16, 32)
Me.Label91.Name = "Label91"
Me.Label91.Size = New System.Drawing.Size(152, 16)
Me.Label91.TabIndex = 72
Me.Label91.Text = "Common Variable Number"
'
'varCommonVarNumber
'
Me.varCommonVarNumber.Location = New System.Drawing.Point(168, 32)
Me.varCommonVarNumber.Name = "varCommonVarNumber"
Me.varCommonVarNumber.Size = New System.Drawing.Size(64, 20)
Me.varCommonVarNumber.TabIndex = 69
Me.varCommonVarNumber.Text = "1"
'
'Label92
'
Me.Label92.Location = New System.Drawing.Point(320, 144)
Me.Label92.Name = "Label92"
Me.Label92.Size = New System.Drawing.Size(48, 16)
Me.Label92.TabIndex = 70
Me.Label92.Text = "Between"
'
'errorlog
'
Me.errorlog.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
Me.errorlog.ForeColor = System.Drawing.Color.Red
Me.errorlog.Location = New System.Drawing.Point(40, 496)
Me.errorlog.Multiline = true
Me.errorlog.Name = "errorlog"
Me.errorlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.errorlog.Size = New System.Drawing.Size(672, 104)
Me.errorlog.TabIndex = 5
Me.errorlog.Text = ""
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(8, 496)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(24, 16)
Me.Label1.TabIndex = 5
Me.Label1.Text = "Log"
'
'clearLogButton
'
Me.clearLogButton.Location = New System.Drawing.Point(720, 576)
Me.clearLogButton.Name = "clearLogButton"
Me.clearLogButton.Size = New System.Drawing.Size(72, 24)
Me.clearLogButton.TabIndex = 5
Me.clearLogButton.Text = "Clear"
'
'frmMain
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.ClientSize = New System.Drawing.Size(799, 606)
Me.Controls.Add(Me.MainTabControl)
Me.Controls.Add(Me.errorlog)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.clearLogButton)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
Me.MaximizeBox = false
Me.Name = "frmMain"
Me.Text = "Sample Thinc API (Machining Centers)"
Me.MainTabControl.ResumeLayout(false)
Me.tab_atc.ResumeLayout(false)
Me.GroupBox13.ResumeLayout(false)
Me.Panel1.ResumeLayout(false)
Me.Panel2.ResumeLayout(false)
Me.Panel3.ResumeLayout(false)
Me.tab_program.ResumeLayout(false)
Me.GroupBox15.ResumeLayout(false)
Me.GroupBox14.ResumeLayout(false)
Me.Panel8.ResumeLayout(false)
Me.tab_Program2.ResumeLayout(false)
Me.Tools2_2.ResumeLayout(false)
Me.GroupBox21.ResumeLayout(false)
Me.GroupBox19.ResumeLayout(false)
Me.GroupBox18.ResumeLayout(false)
Me.tab_Tools2_1.ResumeLayout(false)
Me.GroupBox16.ResumeLayout(false)
Me.GroupBox17.ResumeLayout(false)
Me.tab_machine.ResumeLayout(false)
Me.GroupBox8.ResumeLayout(false)
Me.Panel11.ResumeLayout(false)
Me.tab_MacManAlarmHistory.ResumeLayout(false)
CType(Me.grdMMAlarmHistory,System.ComponentModel.ISupportInitialize).EndInit
Me.GroupBox9.ResumeLayout(false)
Me.tab_tools.ResumeLayout(false)
Me.tab_axis.ResumeLayout(false)
Me.tab_axis2.ResumeLayout(false)
Me.GroupBox11.ResumeLayout(false)
Me.tab_spec.ResumeLayout(false)
Me.GroupBox10.ResumeLayout(false)
Me.tab_MacManMachiningReport.ResumeLayout(false)
CType(Me.grdMMMachiningReports,System.ComponentModel.ISupportInitialize).EndInit
Me.Tab_View.ResumeLayout(false)
Me.Panel12.ResumeLayout(false)
Me.tab_MacmanOperationHistory.ResumeLayout(false)
Me.tab_ballscrew.ResumeLayout(false)
Me.tab_CurrentAlarm.ResumeLayout(false)
Me.GroupBox20.ResumeLayout(false)
Me.tab_OptionalParameter.ResumeLayout(false)
Me.GroupBox12.ResumeLayout(false)
Me.tab_MopTool.ResumeLayout(false)
Me.Panel6.ResumeLayout(false)
Me.GroupBox6.ResumeLayout(false)
Me.tab_MacManOperatingHistory.ResumeLayout(false)
Me.GroupBox5.ResumeLayout(false)
Me.GroupBox4.ResumeLayout(false)
Me.tab_MacmanOperatingReport.ResumeLayout(false)
Me.GroupBox1.ResumeLayout(false)
Me.GroupBox2.ResumeLayout(false)
Me.GroupBox3.ResumeLayout(false)
Me.tab_PLC.ResumeLayout(false)
Me.grpIOVariables.ResumeLayout(false)
Me.tab_workpiece.ResumeLayout(false)
Me.Panel9.ResumeLayout(false)
Me.Panel10.ResumeLayout(false)
Me.tab_coolant.ResumeLayout(false)
Me.tab_spindle.ResumeLayout(false)
Me.tab_variables.ResumeLayout(false)
Me.ResumeLayout(false)

    End Sub

#End Region




    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try



            globalTimer = New System.Windows.Forms.Timer
            'init combos
            cboToolID_ToolType.DataSource = System.Enum.GetValues(GetType(Okuma.CMDATAPI.Enumerations.ToolTypeEnum))
            cboToolID_ToolKind.DataSource = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.ToolKindEnum))
            cboToolID_CarrierStatus.DataSource = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.CarrierStatusEnum))
            cboYesNo_AdjustmentTool.DataSource = System.Enum.GetValues(GetType(YesNoEnum))
            cboYesNo_StandardTool.DataSource = System.Enum.GetValues(GetType(YesNoEnum))
            cboYesNo_PotInUse.DataSource = System.Enum.GetValues(GetType(YesNoEnum))
            cboToolID_ToolLifeStatus.DataSource = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.ToolLifeStatusEnum))
            cboToolID_ToolLifeMode.DataSource = System.Enum.GetValues(GetType(Okuma.CMDATAPI.Enumerations.ToolLifeModeEnum))
            cboToolID_DataUnit.DataSource = System.Enum.GetValues(GetType(Okuma.CMDATAPI.Enumerations.DataUnitEnum))
            cboToolID_DataUnit_2.DataSource = System.Enum.GetValues(GetType(Okuma.CMDATAPI.Enumerations.DataUnitEnum))

            cboSR_MIDBlockRestart.DataSource = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.MIDBlockRestartEnum))
            cboSR_AxisMovementOrder.DataSource = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.AxisMovementOrderEnum))


            cboAxis2DataUnit.DataSource = System.Enum.GetValues(GetType(Okuma.CMDATAPI.Enumerations.DataUnitEnum))
            cboUserParameterVariableLimitCoordinate.DataSource = System.Enum.GetValues(GetType(Okuma.CMDATAPI.Enumerations.UserParameterVariableLimitEnum))
            cboUserParameterVariableLimitAxis.DataSource = System.Enum.GetValues(GetType(Okuma.CMDATAPI.Enumerations.AxisIndexEnum))
            cboIOVariableTypes.DataSource = System.Enum.GetValues(GetType(Okuma.CMDATAPI.Enumerations.IOTypeEnum))

            cboMachineDataUnit.DataSource = System.Enum.GetValues(GetType(DataUnitEnum))
            cboMachineZeroOffsetAxis.DataSource = System.Enum.GetValues(GetType(AxisIndexEnum))
            axisCombo.DataSource = System.Enum.GetValues(GetType(AxisIndexEnum))
            feedCommandOrderCombo.DataSource = System.Enum.GetValues(GetType(CommandFeedrateOrderEnum))
            feedTypeCombo.DataSource = System.Enum.GetValues(GetType(FeedrateTypeEnum))
            ballscrewAxisCombo.DataSource = System.Enum.GetValues(GetType(AxisIndexEnum))
            Me.mopAxisCombo.DataSource = System.Enum.GetValues(GetType(MOPToolAxisEnum))
            Me.mopPositionTypeCombo.DataSource = System.Enum.GetValues(GetType(MOPToolInputModeEnum))
            Me.progExecCombo.DataSource = System.Enum.GetValues(GetType(ExecuteBlockTypeEnum))
            specCombo.DataSource = System.Enum.GetValues(GetType(OptionSpecEnum))
            tulUpdToolMode.DataSource = System.Enum.GetValues(GetType(ToolLifeModeEnum))
            tulUpdToolGroupOrder.DataSource = System.Enum.GetValues(GetType(ToolGroupOrderEnum))
            wkCounterCombo.DataSource = System.Enum.GetValues(GetType(WorkpieceCounterEnum))
            wkAxisCombo.DataSource = System.Enum.GetValues(GetType(AxisIndexEnum))
            atcComboToolAttribute.DataSource = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.ToolAttributeEnum))


            '------------added by dataZen india
            Me.ballscrewDataUnitCombo.DataSource = System.Enum.GetValues(GetType(DataUnitEnum))
            Me.tulDataUnitCombo.DataSource = System.Enum.GetValues(GetType(DataUnitEnum))
            Me.wkDataUnitCombo.DataSource = System.Enum.GetValues(GetType(DataUnitEnum))
            Me.axisDataUnit.DataSource = System.Enum.GetValues(GetType(DataUnitEnum))
            Me.Cmb_rptPeriod.DataSource = System.Enum.GetValues(GetType(Okuma.CMDATAPI.Enumerations.ReportPeriodEnum))
            Me.Cmb_ChangeScreen.DataSource = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.PanelGroupEnum))
            '------------added by dataZen india

            ' init file read mod enum
            cboFileReadModeEnum.DataSource = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.FileReadModeEnum))


            ' Try
            objMachine = New CMachine("MCTestAPP")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' It is important to create the DataAPI.CMachine object first and call the Init method to initialize the 
            ' communication with NC, explicitly.
            ' Before exiting the application, it can call objMachine.Close to close the communication with NC.
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            objMachine.Init()




            objAtc = New CATC
            objaxis = New CAxis
            objaxis2 = New CAxis
            objBS = New CBallScrew
            objCoolant = New CCoolant
            objCMOP = New CMOPTool
            objProgram = New CProgram
            objSpec = New CSpec
            objSpindle = New CSpindle
            objTools = New CTools
            objVariables = New CVariables
            objWorkPiece = New CWorkpiece
            objOptionalParameter = New COptionalParameter
            objIO = New CIO
            m_objToolID1 = New CTools2
            m_objToolID2 = New CTools2

            m_objCmdATC2 = New Okuma.CMCMDAPI.CommandAPI.CATC2("MCTestAPP")



            objMah = New MacMan.CAlarmHistory
            objMor = New MacMan.COperatingReport
            objMoh = New MacMan.COperationHistory
            objMeh = New MacMan.CMachiningReport
            objMopnh = New MacMan.COperatingHistory



            ' Add sample application version to form caption 
            Dim objVersion As System.Version
            Dim strVersion As String

            objVersion = [Assembly].GetExecutingAssembly.GetName().Version

            strVersion = String.Format("{0}.{1}.{2}.{3}", objVersion.Major.ToString, objVersion.Minor.ToString, objVersion.Build.ToString, objVersion.Revision.ToString)
            Me.Text = String.Format("{0} - {1}", "THINC Machining Center Sample Application", strVersion)



            Exit Sub


        Catch ex As Exception
            Dim objForm As frmMessage
            Dim strLabelMessage As String
            Dim strTextMessage As String
            Dim strVersion As String
            Dim objVersion As System.Version

            objVersion = [Assembly].GetExecutingAssembly.GetName().Version

            strVersion = String.Format("{0}.{1}.{2}.{3}", objVersion.Major.ToString, objVersion.Minor.ToString, objVersion.Build.ToString, objVersion.Revision.ToString)


            strLabelMessage = String.Format("{0}{1}", "Please contact OKUMA Software department to resolve problem.", ControlChars.CrLf + ControlChars.CrLf)
            strLabelMessage = strLabelMessage + String.Format("Please send the entire error message to api@okuma.com for futher investigate.")

            strTextMessage = String.Format("THINC Machining Center Sample Application version {0}.{1}{2}", strVersion, ControlChars.CrLf + ControlChars.CrLf, ex.Message)
            objForm = New frmMessage(strLabelMessage, strTextMessage, MessageBoxIcon.Stop)
            objForm.ShowDialog()
            Application.Exit()
        End Try



    End Sub

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        objMachine.Close()
    End Sub
    Private Sub DisplayError(ByVal moduleName As String, ByVal errMsg As String)
        Me.errorlog.Text = Now() & " - " & moduleName & ": " & errMsg & vbCrLf & Me.errorlog.Text

    End Sub

    Private Sub clearLogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearLogButton.Click
        Me.errorlog.Text = ""
    End Sub


#Region "ATC tab"
    Private Sub atcButtonRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcButtonRegister.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC
            objcatc.RegisterToolPot(CInt(Me.atcCMDPotNumber.Text), CInt(Me.atcCMDToolNumber.Text))
        Catch ae As ApplicationException
            DisplayError("CATC", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try
    End Sub

    Private Sub atcButtonRegisterAttribute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcButtonRegisterAttribute.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC
            objcatc.RegisterToolPot(CInt(Me.atcCMDPotNumber.Text), CInt(Me.atcCMDToolNumber.Text), Me.atcComboToolAttribute.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("CATC", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try
    End Sub

    Private Sub atcButtonUnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcButtonUnRegister.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC
            objcatc.UnRegisterToolPot(CInt(Me.atcCMDPotNumber.Text))
        Catch ae As ApplicationException
            DisplayError("CATC", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try
    End Sub

    Private Sub atcButtonCancelTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcButtonCancelTool.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Try
            If (MsgBox("This will cancel all tool in ATC table.  Do you want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No) Then
                Exit Sub
            End If
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC
            objcatc.CancelTool()
        Catch ae As ApplicationException
            DisplayError("CATC", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try
    End Sub

    Private Sub atcUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcUpdateButton.Click
        Dim atcType As ATCTypeEnum
        Dim maxMagazines As Int32
        Dim heavyToolMemo As Double
        Dim largeToolMemo As Double
        Dim magazineType As MagazineTypeEnum
        Dim maxPots As Int32
        Dim retTool As String
        Dim actTool As String
        Dim nextTool As String


        Try

            atcType = objAtc.GetATCType
            maxMagazines = objAtc.GetMaxMagazines
            magazineType = objAtc.GetMagazineType
            maxPots = objAtc.GetMaxPots
            actTool = objAtc.GetActualTool
            nextTool = objAtc.GetNextTool
            retTool = objAtc.GetReturnTool


        Catch ae As ApplicationException
            DisplayError("CATC", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try

        Me.atcStatus.Text = "ATC Type: " & System.Enum.GetNames(GetType(ATCTypeEnum)).GetValue(atcType) & vbCrLf _
            & "Number of Magazines: " & maxMagazines & vbCrLf _
            & "Magazine Type: " & System.Enum.GetNames(GetType(MagazineTypeEnum)).GetValue(magazineType) & vbCrLf _
            & "Number of Pots: " & maxPots & vbCrLf _
            & "Return Tool: " & retTool & vbCrLf _
            & "Actual Tool: " & actTool & vbCrLf _
            & "Next Tool: " & nextTool & vbCrLf


    End Sub
    Private Sub getMemoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles getMemoButton.Click
        Try
            Me.heavyToolMemo.Text = objAtc.GetHeavyToolMemo()
            Me.largeToolMemo.Text = objAtc.GetLargeToolMemo()
        Catch ae As ApplicationException
            DisplayError("CATC: Heavy Tool Memo", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CATC: Heavy Tool Memo", ex.Message)
        End Try
    End Sub

    Private Sub getMagazineButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles getMagazineButton.Click
        Dim magProp As MagazineProperty

        Try
            Me.atcMagazinePosition.Text = objAtc.GetMagazinePosition(CInt(Me.magazineNumber.Text))
            magProp = objAtc.GetMagazineProperty(CInt(Me.magazineNumber.Text))
            Me.numberOfPots.Text = magProp.PotPerMagazine
            Me.startingPot.Text = magProp.StartingPotNumber
            Me.endingPot.Text = magProp.EndingPotNumber

        Catch ae As ApplicationException
            DisplayError("CATC: Magazine Property", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CATC: Magazine Property", ex.Message)
        End Try
    End Sub

    Private Sub atcPotNumberButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcPotNumberButton.Click
        Dim toolProp As ToolProperty
        Try
            toolProp = objAtc.GetPotTool(CInt(Me.potNumber.Text))
            Me.potToolNumber.Text = toolProp.intToolNo
            Me.potToolKind.Text = toolProp.strToolKind

        Catch ae As ApplicationException
            DisplayError("CATC: GetPotTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CATC: GetPotTool", ex.Message)
        End Try
    End Sub

    Private Sub atcSetHeavyToolMemo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcSetHeavyToolMemo.Click
        Try
            objAtc.SetHeavyToolMemo(Me.heavyToolMemo.Text)
            Me.heavyToolMemo.Text = objAtc.GetHeavyToolMemo()
            Me.largeToolMemo.Text = objAtc.GetLargeToolMemo()
        Catch ae As ApplicationException
            DisplayError("CATC: GetPotTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CATC: GetPotTool", ex.Message)
        End Try
    End Sub

    Private Sub atcSetLargeToolMemo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcSetLargeToolMemo.Click
        Try
            objAtc.SetLargeToolMemo(Me.largeToolMemo.Text)
            Me.heavyToolMemo.Text = objAtc.GetHeavyToolMemo()
            Me.largeToolMemo.Text = objAtc.GetLargeToolMemo()
        Catch ae As ApplicationException
            DisplayError("CATC: GetPotTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CATC: GetPotTool", ex.Message)
        End Try
    End Sub


    Private Sub cmdSetActualTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetActualTool.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC
            objcatc.SetActualTool(CInt(Me.atcCMDToolNumber.Text), atcComboToolAttribute.SelectedValue)

        Catch ae As ApplicationException
            DisplayError("CATC", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try
    End Sub

    Private Sub cmdSetNextTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetNextTool.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC
            objcatc.SetNextTool(CInt(Me.atcCMDToolNumber.Text))

        Catch ae As ApplicationException
            DisplayError("CATC", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try
    End Sub

    Private Sub cmdSetReturnPot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetReturnPot.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC
            objcatc.SetReturnPot(CInt(Me.atcCMDPotNumber.Text))

        Catch ae As ApplicationException
            DisplayError("CATC", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try
    End Sub
#End Region

#Region "Axis Tab"

    Private Sub axisUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles axisUpdateButton.Click
        refresh_axis_tab()
        'MsgBox(Me.feedTypeCombo.SelectedValue)
        ' MsgBox(axisCombo.SelectedValue)

        'Catch ae As ApplicationException
        '    DisplayError("CAxis", ae.Message)
        '    'Exit Sub
        'Catch ex As Exception
        '    DisplayError("CAxis", ex.Message)
        'End Try
    End Sub

    Private Sub refresh_axis_tab()
        On Error GoTo sd

        Dim curFeedrateEnum As FeedrateTypeEnum
        Dim curAxisEnum As AxisIndexEnum
        Dim curCommandFeedrateEnum As CommandFeedrateOrderEnum

        curFeedrateEnum = Me.feedTypeCombo.SelectedValue
        curAxisEnum = Me.axisCombo.SelectedValue
        curCommandFeedrateEnum = Me.feedCommandOrderCombo.SelectedValue
        ' Try

        Me.actualFeedrate.Text = objaxis.GetActualFeedrate(curFeedrateEnum)
        Me.apEncoderCoord.Text = CDbl(objaxis.GetActualPositionEncoderCoord(curAxisEnum))
        Me.apMachineCoord.Text = CDbl(objaxis.GetActualPositionMachineCoord(curAxisEnum))
        Me.apProgramCoord.Text = CDbl(objaxis.GetActualPositionProgramCoord(curAxisEnum))
        '---------added by datazen india
        Me.txt_RelativeActualPositionProgramCoord.Text = CDbl(objaxis.GetRelativeActualPositionProgramCoord(curAxisEnum))
        Me.axisLoad.Text = objaxis.GetAxisLoad(curAxisEnum)
        Me.commandFeedRate.Text = objaxis.GetCommandFeedrate(curCommandFeedrateEnum)
        Me.distanceTarget.Text = objaxis.GetDistanceToTargetPosition(curAxisEnum)
        Me.targetPosition.Text = objaxis.GetTargetPosition(curAxisEnum)
        Me.axisName.Text = objaxis.GetAxisName(curAxisEnum)
        Me.axisType.Text = System.Enum.GetNames(GetType(AxisTypeEnum)).GetValue(objaxis.GetAxisType(curAxisEnum))
        Me.feedHold.Text = objaxis.GetFeedHold
        Me.feedrateOverride.Text = objaxis.GetFeedrateOverride
        Me.feedrateType.Text = System.Enum.GetNames(GetType(FeedrateTypeEnum)).GetValue(objaxis.GetFeedrateType)
        Me.maxFeedrateOverride.Text = objaxis.GetMaxFeedrateOverride


        Exit Sub

sd:

        DisplayError("CAxis", Err.Description)
        Resume Next

    End Sub

    Private Sub axisTimerStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles axisTimerStart.Click
        globalTimer.Enabled = True
    End Sub

    Private Sub AxisTimerStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AxisTimerStop.Click
        globalTimer.Enabled = False
    End Sub

    Private Sub globalTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles globalTimer.Tick
        refresh_axis_tab()
    End Sub

    Private Sub axisSetDataUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles axisSetDataUnit.Click
        'Added by DataZen India
        Try
            objaxis.SetDataUnit(Me.axisDataUnit.SelectedValue)
            refresh_axis_tab()
        Catch ae As ApplicationException
            DisplayError("CAxis", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CAxis", ex.Message)
        End Try
    End Sub
#End Region

#Region "Ballscrew tab"
    Private Sub ballscrewUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ballscrewUpdateButton.Click
        ballscrewUpdate()
    End Sub



    Private Sub ballscrewUpdate()
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)

            Me.bsDataPoint.Text = objBS.GetDataPoint(CInt(Me.bsPecPoint.Text), curAxisEnum)

            Me.bsInterval.Text = objBS.GetInterval(curAxisEnum)
            Me.bsMaxPitchPoints.Text = objBS.GetMaxPitchPoints(curAxisEnum)
            Me.bsStartPosition.Text = objBS.GetStartPositionInNDirection(curAxisEnum)
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
    Private Sub bsIntervalSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsIntervalSet.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            objBS.SetInterval(curAxisEnum, CInt(Me.bsIntervalUpdate.Text))
            ballscrewUpdate()
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
    Private Sub bsMaxPicthPointsSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsMaxPicthPointsSet.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            objBS.SetMaxPitchPoints(curAxisEnum, CInt(Me.bsMaxPitchPointsUpdate.Text))
            ballscrewUpdate()
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
    Private Sub bsStartPositionSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsStartPositionSet.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            objBS.SetStartPositionInNDirection(curAxisEnum, CDbl(Me.bsStartPositionUpdate.Text))
            ballscrewUpdate()
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
    Private Sub bsIntervalAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsIntervalAdd.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            objBS.AddInterval(curAxisEnum, CInt(Me.bsIntervalUpdate.Text))
            ballscrewUpdate()
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub

    Private Sub bsMaxPitchPointsAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsMaxPitchPointsAdd.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            objBS.AddMaxPitchPoints(curAxisEnum, CInt(Me.bsMaxPitchPointsUpdate.Text))
            ballscrewUpdate()
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub

    Private Sub bsStartPositionAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsStartPositionAdd.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            objBS.AddStartPositionInNDirection(curAxisEnum, CDbl(Me.bsStartPositionUpdate.Text))
            ballscrewUpdate()
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
    Private Sub bsDataPointSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsDataPointSet.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            objBS.SetDataPoint(CInt(Me.bsPecPoint.Text), curAxisEnum, CInt(Me.bsDataPointUpdate.Text))
            Me.bsDataPoint.Text = objBS.GetDataPoint(CInt(Me.bsPecPoint.Text), curAxisEnum)
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try




    End Sub

    Private Sub bsDataPointAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsDataPointAdd.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            objBS.AddDataPoint(CInt(Me.bsPecPoint.Text), curAxisEnum, CInt(Me.bsDataPointUpdate.Text))
            Me.bsDataPoint.Text = objBS.GetDataPoint(CInt(Me.bsPecPoint.Text), curAxisEnum)
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
    Private Sub bsDataUnitSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsDataUnitSet.Click
        'Added by DataZen India
        Try
            objBS.SetDataUnit(Me.ballscrewDataUnitCombo.SelectedValue)
            ballscrewUpdate()
        Catch ae As ApplicationException
            DisplayError("CBallScrew", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
#End Region


#Region "Machine tab"

    Private Sub machineUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles machineUpdateButton.Click
        updateMachineTab()
    End Sub

    Private Sub updateMachineTab()
        Try
            Me.machineExecutionMode.Text = System.Enum.GetNames(GetType(ExecutionModeEnum)).GetValue(objMachine.GetExecutionMode)
            Me.machineOperationMode.Text = System.Enum.GetNames(GetType(OperationModeEnum)).GetValue(objMachine.GetOperationMode)
            Me.txtPanelMode.Text = System.Enum.GetNames(GetType(PanelModeEnum)).GetValue(objMachine.GetPanelMode)
            Me.machineUnitSytem.Text = objMachine.GetOperationUnitSystemDisplay
            Me.machinePowerOnTime.Text = objMachine.GetPowerOnTime



        Catch ae As ApplicationException
            DisplayError("CMachine:", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMachine:", ex.Message)
        End Try
    End Sub

    Private Sub machinePowerOnTimeSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles machinePowerOnTimeSet.Click
        Try
            objMachine.SetPowerOnTime(CInt(Me.machinePowerOnTimeUpdate.Text))
            updateMachineTab()
        Catch ae As ApplicationException
            DisplayError("CMachine:", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMachine:", ex.Message)
        End Try
    End Sub

    Private Sub machinePowerOnTimeAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles machinePowerOnTimeAdd.Click
        Try
            objMachine.AddPowerOnTime(CInt(Me.machinePowerOnTimeUpdate.Text))
            updateMachineTab()
        Catch ae As ApplicationException
            DisplayError("CMachine:", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMachine:", ex.Message)
        End Try
    End Sub

#End Region


#Region "Machine - 2"

#End Region

#Region "Coolant Tab"
    Private Sub coolantUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles coolantUpdateButton.Click
        Try
            Me.coolantChipCondition.Text = System.Enum.GetName(GetType(OnOffEnum), CInt(objCoolant.GetChipFlushCondition))
        Catch ae As ApplicationException
            DisplayError("CCoolant", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CCoolant", ex.Message)
        End Try
    End Sub

#End Region


#Region "CMOP tool"

    Private Sub mopEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopEdit.Click
        Dim objccmop As Okuma.CMCMDAPI.CommandAPI.CMOPTool
        Try


            objccmop = New Okuma.CMCMDAPI.CommandAPI.CMOPTool
            objccmop.Edit(CLng(Me.mopCMDToolNumber.Text), CInt(Me.mopCMDClassNumber.Text))

            Me.mopToolDataNumber.Text = objCMOP.GetToolDataNumber(CInt(mopCMDToolNumber.Text), CInt(mopCMDClassNumber.Text))

        Catch ae As ApplicationException
            DisplayError("cmop", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("cmop", ex.Message)
        End Try
    End Sub

    Private Sub mopDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopDelete.Click
        Dim objccmop As Okuma.CMCMDAPI.CommandAPI.CMOPTool
        Try


            objccmop = New Okuma.CMCMDAPI.CommandAPI.CMOPTool
            objccmop.Delete(CLng(Me.mopCMDToolNumber.Text), CInt(Me.mopCMDClassNumber.Text))

            Me.mopToolDataNumber.Text = 0

        Catch ae As ApplicationException
            DisplayError("cmop", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("cmop", ex.Message)
        End Try
    End Sub
    Private Sub mopUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopUpdateButton.Click

        mopUpdate()
    End Sub

    Private Sub mopUpdate()
        On Error GoTo sd

        Dim curMopTool As Integer
        Dim curAxisEnum As AxisIndexEnum
        Dim posTypeEnum As MOPToolInputModeEnum

        curAxisEnum = System.Enum.GetValues(GetType(MOPToolAxisEnum)).GetValue(Me.mopAxisCombo.SelectedValue)
        posTypeEnum = System.Enum.GetValues(GetType(MOPToolInputModeEnum)).GetValue(Me.mopPositionTypeCombo.SelectedValue)

        curMopTool = CInt(Me.mopToolNumber.Text)

        Me.mopAdaptiveControl.Text = objCMOP.GetAdaptiveControl(curAxisEnum, curMopTool)
        Me.mopAircutOverride.Text = objCMOP.GetAirCutOverride(curMopTool)
        Me.mopAircutReduction.Text = objCMOP.GetAirCutReduction(curAxisEnum, curMopTool)
        Me.mopALVValue.Text = objCMOP.GetALVValue(curAxisEnum, curMopTool, posTypeEnum)
        Me.mopAlarms.Text = System.Enum.GetNames(GetType(MOPToolDataAlarm)).GetValue(objCMOP.GetAlarm(curAxisEnum, curMopTool))
        Me.mopAutoChange.Text = System.Enum.GetNames(GetType(OnOffEnum)).GetValue(objCMOP.GetAutoChange(curAxisEnum, curMopTool))
        Me.mopCuttingTime.Text = objCMOP.GetCuttingTime(curMopTool)
        Me.mopLimitValue.Text = objCMOP.GetLimitValue(curAxisEnum, curMopTool, posTypeEnum)
        Me.mopLLValue.Text = objCMOP.GetLLValue(curAxisEnum, curMopTool, posTypeEnum)
        Me.mopMaxOverride.Text = objCMOP.GetMaxOverride(curMopTool)
        Me.mopMinOverride.Text = objCMOP.GetMinOverride(curMopTool)
        Me.mopOverloadMonitor.Text = objCMOP.GetOverloadMonitor(curAxisEnum, curMopTool)
        Me.mopReferenceValue.Text = objCMOP.GetReferenceValue(curAxisEnum, curMopTool)
        Me.mopUnusualSignal.Text = objCMOP.GetAmountUnsualSignalChange(curMopTool)

        Me.mopToolDataInputMode.Text = System.Enum.GetNames(GetType(MOPToolInputModeEnum)).GetValue(objCMOP.GetToolDataInputMode)


        Me.mopUlValue.Text = objCMOP.GetULValue(curAxisEnum, curMopTool, posTypeEnum)
        Me.TXT_GetMaxMOPToolData.Text = CInt(objCMOP.GetMaxMOPToolData) '---------ADDED BY DATAZEN INDIA


        'wait for kenji input
        Me.mopCuttingLoad.Text = objCMOP.GetCuttingLoadAtAlarm(curAxisEnum, curMopTool)
        Me.mopSignalDiffAlarm.Text = objCMOP.GetSignalDifferentAtAlarm(curAxisEnum, curMopTool)

        Exit Sub

sd:

        DisplayError("CMOP Tool", Err.Description)
        Resume Next
    End Sub

    Private Sub mopButtonAdaptiveControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonAdaptiveControl.Click
        Try
            objCMOP.SetAdaptiveControl(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CInt(Me.mopSetAdaptiveControl.Text))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try

    End Sub

    Private Sub mopButtonAircutOverride_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonAircutOverride.Click
        Try
            objCMOP.SetAirCutOverride(CInt(Me.mopToolNumber.Text), CInt(Me.mopSetAircutOverride.Text))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonAircutReduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonAircutReduction.Click
        Try
            objCMOP.SetAirCutReduction(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CInt(Me.mopSetAircutReduction.Text))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonALVValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonALVValue.Click
        Try
            objCMOP.SetALVValue(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CDbl(Me.mopSetALVValue.Text), CInt(Me.mopPositionTypeCombo.SelectedValue))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonUnusualSignalChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonUnusualSignalChange.Click
        Try
            objCMOP.SetAmountUnsualSignalChange(CInt(Me.mopAxisCombo.SelectedValue), CDbl(Me.mopSetUnusualSignal.Text))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopbuttonAutoChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopbuttonAutoChange.Click
        Try
            objCMOP.SetAutoChange(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CInt(Me.mopSetAutoChange.Text))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonCuttingTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonCuttingTime.Click
        Try
            objCMOP.SetCuttingTime(CInt(Me.mopToolNumber.Text), CDbl(Me.mopSetCuttingTime.Text))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonLimitValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonLimitValue.Click
        Try
            objCMOP.SetLimitValue(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CDbl(Me.mopSetLimitValue.Text), CInt(Me.mopPositionTypeCombo.SelectedValue))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonLLValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonLLValue.Click
        Try
            objCMOP.SetLLValue(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CDbl(Me.mopSetLLValue.Text), CInt(Me.mopPositionTypeCombo.SelectedValue))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonMaxOverride_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonMaxOverride.Click
        Try
            objCMOP.SetMaxOverride(CInt(Me.mopToolNumber.Text), CInt(Me.mopSetMaxOverride.Text))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonMinOverride_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonMinOverride.Click
        Try
            objCMOP.SetMinOverride(CInt(Me.mopToolNumber.Text), CInt(Me.mopSetMinOverride.Text))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonOverloadMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonOverloadMonitor.Click
        Try
            objCMOP.SetOverloadMonitor(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CInt(Me.mopSetOverloadMonitor.Text))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonReferenceValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonReferenceValue.Click
        Try
            objCMOP.SetReferenceValue(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CDbl(Me.mopSetReferenceValue.Text))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonToolDataInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonToolDataInput.Click
        Try
            objCMOP.SetToolDataInputMode(CInt(Me.mopSetToolDataInputMode.Text))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonULValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonULValue.Click
        Try
            objCMOP.SetULValue(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CDbl(Me.mopSetULValue.Text), CInt(Me.mopPositionTypeCombo.SelectedValue))
            mopUpdate()
        Catch ae As ApplicationException
            DisplayError("CMOP Tool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub
#End Region

#Region "Program Tab"
    Private Sub cmdReturnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReturnSearch.Click
        Dim intRelativeBlock As Integer
        Dim enAxisMovement As Okuma.CMCMDAPI.Enumerations.AxisMovementOrderEnum
        Dim enMIDBlockRestart As Okuma.CMCMDAPI.Enumerations.MIDBlockRestartEnum
        Dim intRepeatNumber As Integer
        Dim objCMDProgram As Okuma.CMCMDAPI.CommandAPI.CProgram
        Dim strSequence As String = ""


        Try
            objCMDProgram = New Okuma.CMCMDAPI.CommandAPI.CProgram

            strSequence = txtSR_SequenceBlockNumber.Text
            intRelativeBlock = CInt(txtSR_RelativeBlock.Text)
            intRepeatNumber = CInt(txtSR_RepeatNumber.Text)
            enAxisMovement = cboSR_AxisMovementOrder.SelectedValue
            enMIDBlockRestart = cboSR_MIDBlockRestart.SelectedValue
            objCMDProgram.ReturnSearch(strSequence, enAxisMovement, enMIDBlockRestart, intRelativeBlock, intRepeatNumber)

        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub

    Private Sub progUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progUpdateButton.Click

        Dim activeProgramFname As String
        Dim activeProgramName As String
        Dim currentBlockNumber As Int32
        Dim defaultProgramPath As String
        Dim execSequenceNumber As String
        Dim gCodes As String
        Dim mCodes As String



        Try

            activeProgramFname = objProgram.GetActiveProgramFileName
            activeProgramName = objProgram.GetActiveProgramName
            currentBlockNumber = objProgram.GetCurrentBlockNumber
            defaultProgramPath = objProgram.GetDefaultProgramPath
            execSequenceNumber = objProgram.GetExecutedSequenceNumber
            gCodes = objProgram.GetGCodes
            mCodes = objProgram.GetMCodes



        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try

        Me.progNoParams.Text = "Active Program Filename: " & activeProgramFname & vbCrLf _
            & "Active Program Name: " & activeProgramName & vbCrLf _
            & "Current Block Number: " & currentBlockNumber & vbCrLf _
            & "Default Program Path: " & defaultProgramPath & vbCrLf _
            & "Execution Sequence Number: " & execSequenceNumber & vbCrLf _
            & "G Codes: " & gCodes & vbCrLf _
            & "M Codes: " & mCodes & vbCrLf

    End Sub

    Private Sub progButtonExecBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progButtonExecBlock.Click
        Dim curExecEnum As ExecuteBlockTypeEnum
        Try
            curExecEnum = System.Enum.GetValues(GetType(ExecuteBlockTypeEnum)).GetValue(Me.progExecCombo.SelectedValue)
            progExecutingBlock.Text = objProgram.GetExecuteBlock(curExecEnum)
        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub

    Private Sub progButtonGetRunProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progButtonGetRunProgram.Click
        Dim rp As String()
        Dim currp As String
        Dim rpoint As Int32
        Dim epoint As Int32


        Try
            progRunningPrograms.Clear()
            rp = objProgram.GetRunningProgram(CInt(Me.progRow.Text), CInt(Me.progColumn.Text), rpoint, epoint)
            Me.progExecutePoint.Text = epoint
            Me.progRead.Text = rpoint
            For Each currp In rp
                progRunningPrograms.Text += currp & vbCrLf
            Next
        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub

    Private Sub progSelectProgramButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progSelectProgramButton.Click
        Dim objcprogram As New Okuma.CMCMDAPI.CommandAPI.CProgram
        Dim enFiledReadMode As Okuma.CMCMDAPI.Enumerations.FileReadModeEnum
        Try
            enFiledReadMode = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.FileReadModeEnum)).GetValue(Me.cboFileReadModeEnum.SelectedValue)

            objcprogram.SelectMainProgram(prog1.Text, prog2.Text, prog3.Text, enFiledReadMode)
        Catch ae As ApplicationException
            DisplayError("CMD program", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMD Program", ex.Message)
        End Try
    End Sub

    Private Sub cmdSelectScheduleProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectScheduleProgram.Click
        Dim objcprogram As New Okuma.CMCMDAPI.CommandAPI.CProgram
        Try
            objcprogram.SelectScheduleProgram(prog1.Text)
        Catch ae As ApplicationException
            DisplayError("CMD program", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CMD Program", ex.Message)
        End Try
    End Sub
#End Region

#Region "Spec Tab"
    Private Sub specUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles specUpdateButton.Click
        Dim curSpecEnum As OptionSpecEnum


        Try


            curSpecEnum = Me.specCombo.SelectedValue

            Me.specCode.Text = objSpec.GetOptionSpecCode(curSpecEnum)

            txtMachineName.Text = objSpec.GetMachineName
            txtMachineSerial.Text = objSpec.GetMachineSerialNumber



        Catch ae As ApplicationException
            DisplayError("CSpec", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CSpec", ex.Message)
        End Try
    End Sub

    Private Sub cmdGetSpecCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetSpecCode.Click
        Try
            txtSpecCode.Text = objSpec.GetSpecCode(CInt(txtSpecCodeIndex.Text), CInt(txtSpecCodeBit.Text))

        Catch ae As ApplicationException
            DisplayError("CSpec", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("CSpec", ne.Message)
        Catch ex As Exception
            DisplayError("CSpec", ex.Message)
        End Try
    End Sub

    Private Sub cmdGetBSpecCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetBSpecCode.Click
        Try
            txtSpecCode.Text = objSpec.GetBSpecCode(CInt(txtSpecCodeIndex.Text), CInt(txtSpecCodeBit.Text))

        Catch ae As ApplicationException
            DisplayError("CSpec", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("CSpec", ne.Message)
        Catch ex As Exception
            DisplayError("CSpec", ex.Message)
        End Try
    End Sub
#End Region

#Region "Spindle Tab"
    Private Sub spinUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spinUpdate.Click
        Try
            Me.spinActualRate.Text = objSpindle.GetActualSpindlerate
            Me.spinCommandRate.Text = objSpindle.GetCommandSpindlerate
            Me.spinLoad.Text = objSpindle.GetSpindleLoad
            Me.spinMaxOverrideRate.Text = objSpindle.GetMaxSpindlerateOverride
            Me.spinOilMist.Text = System.Enum.GetNames(GetType(OnOffEnum)).GetValue(objSpindle.GetOilMistCondition)
            Me.spinRateOverride.Text = objSpindle.GetSpindlerateOverride
            Me.spinState.Text = System.Enum.GetNames(GetType(SpindleStateEnum)).GetValue(objSpindle.GetSpindleState)

        Catch ae As ApplicationException
            DisplayError("CSpindle", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CSpindle", ex.Message)
        End Try
    End Sub
#End Region

#Region "Tool Tab"
    Private Sub tulButtonLengthOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulButtonLengthOffset.Click
        Dim dblResults As Double()
        Dim dr As Double

        Try
            Me.tulResults.Text = ""
            dblResults = objTools.GetToolLengthOffset(CInt(Me.tulFrom.Text), CInt(Me.tulTo.Text))
            For Each dr In dblResults
                Me.tulResults.Text += dr & vbCrLf
            Next
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulButtonLengthWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulButtonLengthWearOffset.Click
        Dim dblResults As Double()
        Dim dr As Double

        Try
            Me.tulResults.Text = ""
            dblResults = objTools.GetToolLengthWearOffset(CInt(Me.tulFrom.Text), CInt(Me.tulTo.Text))
            For Each dr In dblResults
                Me.tulResults.Text += dr & vbCrLf
            Next
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try

    End Sub

    Private Sub tulButtonCutterROffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulButtonCutterROffset.Click
        Dim dblResults As Double()
        Dim dr As Double

        Try
            Me.tulResults.Text = ""
            dblResults = objTools.GetCutterRCompOffset(CInt(Me.tulFrom.Text), CInt(Me.tulTo.Text))
            For Each dr In dblResults
                Me.tulResults.Text += dr & vbCrLf
            Next
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulButtonCutterRLengthOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulButtonCutterRLengthOffset.Click
        Dim dblResults As Double()
        Dim dr As Double

        Try
            Me.tulResults.Text = ""
            dblResults = objTools.GetCutterRCompWearOffset(CInt(Me.tulFrom.Text), CInt(Me.tulTo.Text))
            For Each dr In dblResults
                Me.tulResults.Text += dr & vbCrLf
            Next
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulUpdateButton.Click
        updateTools()
    End Sub
    Private Sub tulUpdateButtonNoParam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulUpdateButtonNoParam.Click

        Dim CurrentCutterRCompOffsetNumber As Int32
        Dim CurrentToolLengthOffsetNumber As Int32
        Dim CurrentToolNumber As Int32
        Dim MaxTools As Int32



        Try

            CurrentCutterRCompOffsetNumber = objTools.GetCurrentCutterRCompOffsetNumber
            CurrentToolLengthOffsetNumber = objTools.GetCurrentToolLengthOffsetNumber
            CurrentToolNumber = objTools.GetCurrentToolNumber
            MaxTools = objTools.GetMaxTools



        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try

        Me.tulNoParam.Text = "Current Cutter R Comp Offset Number: " & CurrentCutterRCompOffsetNumber & vbCrLf _
            & "Current Tool Length Offset Number: " & CurrentToolLengthOffsetNumber & vbCrLf _
            & "Current Tool Number: " & CurrentToolNumber & vbCrLf _
            & "Max Tools: " & MaxTools

    End Sub

    Private Sub updateTools()
        On Error GoTo sd

        Dim toolNum As Int16
        toolNum = CInt(Me.tulToolNumber.Text)


        Me.tulCutterRCompOffset.Text = objTools.GetCutterRCompOffset(toolNum)
        Me.tulPotNumber.Text = objTools.GetPotNo(toolNum)
        Me.tulReferenceToolOffset2.Text = objTools.GetReferenceToolOffset2(toolNum)
        Me.tulReferenceToolOffset3.Text = objTools.GetReferenceToolOffset3(toolNum)
        Me.tulToolGroup.Text = objTools.GetGroupNo(toolNum)
        Me.tulToolGroupOrder.Text = System.Enum.GetNames(GetType(ToolGroupOrderEnum)).GetValue(objTools.GetToolGroupOrder(toolNum))
        Me.tulToolKind.Text = objTools.GetToolKind(toolNum)
        Me.tulToolLengthOffset.Text = objTools.GetToolLengthOffset(toolNum)
        Me.tulToolLife.Text = objTools.GetToolLife(toolNum)
        Me.tulToolLifeRemaining.Text = objTools.GetToolLifeRemaining(toolNum)
        Me.tulToolMode.Text = System.Enum.GetNames(GetType(ToolLifeModeEnum)).GetValue(objTools.GetMode(toolNum))
        Me.tulToolStatus.Text = System.Enum.GetName(GetType(ToolLifeStatusEnum), objTools.GetStatus(toolNum))
        'added by datazen india
        Me.tulToolLifeRemainSec.Text = objTools.GetToolLifeRemainingTimeSecond(toolNum)



        Me.tulToolLengthWearOffset.Text = objTools.GetToolLengthWearOffset(toolNum)
        Me.tulCutterRCompWearOffset.Text = objTools.GetCutterRCompWearOffset(toolNum)

        Exit Sub

sd:

        DisplayError("CTool", Err.Description)
        Resume Next
    End Sub


    Private Sub tulSetCutterRCompOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetCutterRCompOffset.Click
        Try
            objTools.SetCutterRCompOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdCutterRCompOffset.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetCutterRCompWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetCutterRCompWearOffset.Click
        Try
            objTools.SetCutterRCompWearOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdCutterRCompWearOffset.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolGroup.Click
        Try
            objTools.SetGroupNo(CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdToolGroup.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolMode.Click
        Try
            objTools.SetMode(CInt(Me.tulToolNumber.Text), Me.tulUpdToolMode.SelectedValue)
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetReferenceToolOffset2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetReferenceToolOffset2.Click
        Try
            objTools.SetReferenceToolOffset2(CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdReferenceToolOffset2.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetReferenceToolOffset3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetReferenceToolOffset3.Click
        Try
            objTools.SetReferenceToolOffset3(CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdReferenceToolOffset3.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolStatus.Click
        Try
            objTools.SetStatus(CInt(Me.tulToolNumber.Text), Me.tulUpdToolStatus.Text)
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolGroupOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolGroupOrder.Click
        Try
            objTools.SetToolGroupOrder(CInt(Me.tulToolNumber.Text), Me.tulUpdToolGroupOrder.SelectedValue)
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolLengthOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolLengthOffset.Click
        Try
            objTools.SetToolLengthOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdToolLengthOffset.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolLengthWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolLengthWearOffset.Click
        Try
            objTools.SetToolLengthWearOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdToolLengthWearOffset.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolLife_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolLife.Click
        Try
            objTools.SetToolLife(CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdToolLife.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolLifeRemaining_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolLifeRemaining.Click
        Try
            objTools.SetToolLifeRemaining(CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdToolLifeRemaining.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub
    Private Sub tulAddToolLengthWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulAddToolLengthWearOffset.Click
        Try
            objTools.AddToolLengthWearOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdToolLengthWearOffset.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub
    Private Sub tulAddToolLengthOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulAddToolLengthOffset.Click
        Try
            objTools.AddToolLengthOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdToolLengthOffset.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulCalToolLengthWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulCalToolLengthWearOffset.Click
        Try
            objTools.CalToolLengthWearOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdToolLengthWearOffset.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulCalToolLengthOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulCalToolLengthOffset.Click
        Try
            objTools.CalToolLengthOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdToolLengthOffset.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub
    Private Sub tulSetDataUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetDataUnit.Click
        'Added by DataZen India
        Try
            objTools.SetDataUnit(Me.tulDataUnitCombo.SelectedValue)
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub
#End Region


#Region "Common Var Tab"

    Private Sub varUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles varUpdateButton.Click

        Try
            Me.varValue.Text = objVariables.GetCommonVariableValue(CInt(Me.varCommonVarNumber.Text))
            Me.varNumberOfVars.Text = objVariables.GetCommonVariableCount
        Catch ae As ApplicationException
            DisplayError("CVariable", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub

    Private Sub varSetValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles varSetValue.Click
        Try
            objVariables.SetCommonVariableValue(CInt(Me.varCommonVarNumber.Text), CDbl(Me.varValueUpdate.Text))
            Me.varValue.Text = objVariables.GetCommonVariableValue(CInt(Me.varCommonVarNumber.Text))

        Catch ae As ApplicationException
            DisplayError("CVariable", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub

    Private Sub varAddValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles varAddValue.Click
        Try
            objVariables.AddCommonVariableValue(CInt(Me.varCommonVarNumber.Text), CDbl(Me.varValueUpdate.Text))
            Me.varValue.Text = objVariables.GetCommonVariableValue(CInt(Me.varCommonVarNumber.Text))

        Catch ae As ApplicationException
            DisplayError("CVariable", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub

    Private Sub varGetAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles varGetAllButton.Click
        Dim varRes As Double()
        Dim curRes As Double

        Try
            Me.varGetAllResults.Text = ""
            varRes = objVariables.GetCommonVariableValues(CInt(Me.varBegin.Text), CInt(Me.varEnd.Text))
            For Each curRes In varRes
                Me.varGetAllResults.Text += curRes & vbCrLf
            Next


        Catch ae As ApplicationException
            DisplayError("CVariable", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub
#End Region

#Region "Workpiece Tab"

    Private Sub wkButtonGetCounter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkButtonGetCounter.Click
        Try
            wkCounterValue.Text = objWorkPiece.GetWorkpieceCounter(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(wkCounterCombo.SelectedValue))
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub
    Private Sub wkCounterSetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkCounterSetButton.Click
        Try
            objWorkPiece.SetWorkpieceCounter(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(wkCounterCombo.SelectedValue), CInt(Me.wkUpdateCounter.Text))
            wkCounterValue.Text = objWorkPiece.GetWorkpieceCounter(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(wkCounterCombo.SelectedValue))
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub


    Private Sub wkButtonZeroOffsetGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkButtonZeroOffsetGet.Click
        Try
            Me.wkZeroOffset.Text = objWorkPiece.GetZeroOffset(CInt(Me.wkOffsetNumber.Text), System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.wkAxisCombo.SelectedValue))
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub wkButtonZeroOffsetSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkButtonZeroOffsetSet.Click
        Try
            objWorkPiece.SetZeroOffset(CInt(Me.wkOffsetNumber.Text), System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.wkAxisCombo.SelectedValue), CDbl(Me.wkUpdateZeroOffset.Text))
            Me.wkZeroOffset.Text = objWorkPiece.GetZeroOffset(CInt(Me.wkOffsetNumber.Text), System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.wkAxisCombo.SelectedValue))
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub wkButtonZeroOffsetAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkButtonZeroOffsetAdd.Click
        Try
            objWorkPiece.AddZeroOffset(CInt(Me.wkOffsetNumber.Text), System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.wkAxisCombo.SelectedValue), CDbl(Me.wkUpdateZeroOffset.Text))
            Me.wkZeroOffset.Text = objWorkPiece.GetZeroOffset(CInt(Me.wkOffsetNumber.Text), System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.wkAxisCombo.SelectedValue))
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub wkButtonZeroOffsetCal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkButtonZeroOffsetCal.Click
        Try
            objWorkPiece.CalZeroOffset(CInt(Me.wkOffsetNumber.Text), System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.wkAxisCombo.SelectedValue), CDbl(Me.wkUpdateZeroOffset.Text))
            Me.wkZeroOffset.Text = objWorkPiece.GetZeroOffset(CInt(Me.wkOffsetNumber.Text), System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.wkAxisCombo.SelectedValue))
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub wkUpdateValsWithNoParams_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkUpdateValsWithNoParams.Click
        Dim MaxZeroOffset As Int32
        Dim CurrentZeroOffsetNumber As Int32
        Dim ZeroResults As Double()
        Dim zr As Double

        Try
            wkZeroResults.Clear()

            MaxZeroOffset = objWorkPiece.GetMaxZeroOffset
            CurrentZeroOffsetNumber = objWorkPiece.GetCurrentZeroOffsetNumber
            ZeroResults = objWorkPiece.GetZeroOffsets(CInt(Me.wkZeroFrom.Text), CInt(Me.wkZeroTo.Text), CInt(wkAxisCombo.SelectedValue))
            For Each zr In ZeroResults
                Me.wkZeroResults.Text += zr & vbCrLf
            Next
        Catch ae As ApplicationException
            DisplayError("Cworkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("Cworkpiece", ex.Message)
        End Try

        Me.wkValsWithoutParameters.Text = "Maximum Zero Offset : " & MaxZeroOffset & vbCrLf _
            & "Current Zero Offset Number: " & CurrentZeroOffsetNumber & vbCrLf
    End Sub
    'Added by Datazen India
    Private Sub wkSetDataUnitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkSetDataUnitButton.Click
        Try
            objWorkPiece.SetDataUnit(Me.wkDataUnitCombo.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Cworkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("Cworkpiece", ex.Message)
        End Try
    End Sub
#End Region


#Region "Macman Alarm History Tab"

    Private Sub mahButtonResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mahButtonResults.Click
        'Dim mohObject As MacMan.CAlarm
        'Dim mohObjects As ArrayList

        'Try
        '    Me.mahResults.Text = ""
        '    mohObjects = objMah.GetAlarms(CInt(Me.mahFrom.Text), CInt(Me.mahTo.Text))
        '    For Each mohObject In mohObjects
        '        Me.mahResults.Text += mohObject.Date & " " & mohObject.Time & vbTab & mohObject.Code & vbTab & mohObject.Message & vbCrLf
        '    Next
        'Catch ae As ApplicationException
        '    DisplayError("Macman Alarm History", ae.Message)
        '    'Exit Sub
        'Catch ex As Exception
        '    DisplayError("Macman Alarm History", ex.Message)
        'End Try


        Dim mohObject As MacMan.CAlarm
        Dim mohObjects As ArrayList



        Try
            mohObjects = objMah.GetAlarms(CInt(Me.mahFrom.Text), CInt(Me.mahTo.Text))

            grdMMAlarmHistory.DataSource = mohObjects
            grdMMAlarmHistory.Refresh()



        Catch ae As ApplicationException
            DisplayError("MacMan Alarm History", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("MacMan Alarm History", ex.Message)
        End Try
    End Sub

    Private Sub mahUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mahUpdateButton.Click
        UpdateMah()
    End Sub

    Private Sub UpdateMah()
        On Error GoTo sd
        Dim alarmIndex As Int16
        alarmIndex = CInt(Me.mahAlarmIndex.Text)
        Dim mahObject As MacMan.CAlarm
        mahObject = objMah.GetAlarm(alarmIndex)

        Me.mahAlarmCount.Text = objMah.GetCount
        Me.mahMaxAlarmCount.Text = objMah.GetMaxCount

        Me.mahAlarmDate.Text = mahObject.Date
        Me.mahAlarmTime.Text = mahObject.Time
        Me.mahAlarmNumber.Text = mahObject.Number
        Me.txtAlarmObject.Text = mahObject.Object
        Me.mahAlarmCode.Text = mahObject.Code
        Me.mahAlarmMessage.Text = mahObject.Message

        Exit Sub

sd:

        DisplayError("MacMan Alarm History", Err.Description)
        Resume Next
    End Sub
#End Region

#Region "macman Operating Report"
    Private Sub morUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles morUpdateButton.Click
        On Error GoTo sd

        Me.morNonoperatingCondition.Text = System.Enum.GetNames(GetType(NonOperatingConditionEnum)).GetValue(objMor.GetNonOperatingCondition)
        Me.morOperatingStatus.Text = System.Enum.GetNames(GetType(OperatingStatusEnum)).GetValue(objMor.GetOperatingStatus)

        Me.morDateOfOperatingReport.Text = objMor.GetTodayOperatingReportDate()
        Me.morMaxNoOfOpReport.Text = objMor.GetMaxCount()

        Me.morOperatingTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.OperatingTime)
        Me.morRunningTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.RunningTime)
        Me.morCuttingTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.CuttingTime)
        Me.morNonOPeratingTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.NonOperatingTime)
        Me.morInProSetupTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.InProcessSetupTime)
        Me.morNoOperatorTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.NoOperatorTime)
        Me.morPartWaitingTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.PartWaitingTime)
        Me.mormaintenanceTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.MaintenanceTime)
        Me.morOtherTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.OtherTime)
        Me.morSpindleRunTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.SpindleRunTime)
        Me.morExternalInputTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.ExternalInputTime)
        Me.morAlarmOnTime.Text = objMor.GetTodayOperatingReport(OperatingReportDataEnum.AlarmOnTime)




        Me.morPrevDateOfOperatingRept.Text = objMor.GetPreviousOperatingReportDate()

        Me.morPrevAlarmOnTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.AlarmOnTime)
        Me.morPrevCuttingTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.CuttingTime)
        Me.morPrevInProSetupTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.InProcessSetupTime)
        Me.morPrevMaintenanceTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.MaintenanceTime)
        Me.morPrevNonOperatingTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.NonOperatingTime)
        Me.morPrevNoOperatorTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.NoOperatorTime)
        Me.morPrevOperatingTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.OperatingTime)
        Me.morPrevOtherTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.OtherTime)
        Me.morPrevPartwaitingTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.PartWaitingTime)
        Me.morPrevRunningTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.RunningTime)
        Me.morPrevSpindleRunTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.SpindleRunTime)
        Me.morPrevExternalInputTime.Text = objMor.GetPreviousOperatingReport(OperatingReportDataEnum.ExternalInputTime)


        Me.morPeriodDateOfOperatingReport.Text = objMor.GetPeriodOperatingReportDate()

        Me.morPeriodAlarmOnTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.AlarmOnTime)
        Me.morPeriodCuttingTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.CuttingTime)
        Me.morPeriodExternalInputTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.ExternalInputTime)
        Me.morPeriodInproSetupTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.InProcessSetupTime)
        Me.morPeriodMaintenanceTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.MaintenanceTime)
        Me.morPeriodNonOperatingTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.NonOperatingTime)
        Me.morPeriodNoOperatorTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.NoOperatorTime)
        Me.morPeriodOperatingTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.OperatingTime)
        Me.morPeriodOtherTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.OtherTime)
        Me.morPeriodPartWaitingTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.PartWaitingTime)
        Me.morPeriodRunningTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.RunningTime)
        Me.morPeriodSpindleRunTime.Text = objMor.GetPeriodOperatingReport(OperatingReportDataEnum.SpindleRunTime)

        Exit Sub
sd:

        DisplayError("MacmMan Operating Report", Err.Description)
        Resume Next
    End Sub

#End Region

#Region "Macman Operation History"
    Private Sub mohUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mohUpdateButton.Click
        On Error GoTo sd
        Dim opIndex As Int16
        Dim mohObject As MacMan.COperation

        opIndex = CInt(Me.mohOperationIndex.Text)

        mohObject = objMoh.GetOperationHistory(opIndex)

        Me.mohOperationData.Text = mohObject.Data
        Me.mohOperationDate.Text = mohObject.Date
        Me.mohOperationTime.Text = mohObject.Time
        Me.mohOperationCount.Text = objMoh.GetCount
        Me.mohOperationMaxCount.Text = objMoh.GetMaxCount

        Exit Sub

sd:

        DisplayError("MacMan Operating Report", Err.Description)
        Resume Next
    End Sub

    Private Sub mohButtonResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mohButtonResults.Click
        Dim mohObject As MacMan.COperation
        Dim mohObjects As ArrayList
        Dim intIndex As Integer = 1


        Try
            Me.mohResults.Text = ""
            mohObjects = objMoh.GetOperationHistory(CInt(Me.mohFrom.Text), CInt(Me.mohTo.Text))
            For Each mohObject In mohObjects
                Me.mohResults.Text += String.Format("{0:###}", intIndex.ToString()) & vbTab & mohObject.Date & vbTab & mohObject.Time & vbTab & mohObject.Data & vbCrLf
                intIndex = intIndex + 1
            Next
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub
#End Region

#Region "Macman Operating History"
    'Added by DataZen India
    Private Sub objMopnhUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles objMopnhUpdateButton.Click
        On Error GoTo sd


        Me.mopnhAlarmOnTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.AlarmOnTime))
        Me.mopnhCuttingTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.CuttingTime))
        Me.mopnhExternalInputTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.ExternalInputTime))
        Me.mopnhInProSetupTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.InProcessSetupTime))
        Me.mopnhMaintenanceTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.MaintenanceTime))
        Me.mopnhNonOperatingReport.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.NonOperatingTime))
        Me.mopnhNoOperatorTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.NoOperatorTime))
        Me.mopnhOperatingTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.OperatingTime))
        Me.mopnhOtherTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.OtherTime))
        Me.mopnhPartWaitingTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.PartWaitingTime))
        Me.mopnhRunningTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.RunningTime))
        Me.mopnhSpindleRunTime.Text = ArrayToString(objMopnh.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.SpindleRunTime))

        Me.mopnhPrevAlarmonTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.AlarmOnTime))
        Me.mopnhPrevCuttingTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.CuttingTime))
        Me.mopnhPrevExternalInputTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.ExternalInputTime))
        Me.mopnhPrevInProSetupTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.InProcessSetupTime))
        Me.mopnhPrevMaintenanceTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.MaintenanceTime))
        Me.mopnhPrevNonOperatingTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.NonOperatingTime))
        Me.mopnhPrevNoOperatorTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.NoOperatorTime))
        Me.mopnhPrevOperatingTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.OperatingTime))
        Me.mopnhPrevOtherTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.OtherTime))
        Me.mopnhPrevPartWaitingTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.PartWaitingTime))
        Me.mopnhPrevRunningTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.RunningTime))
        Me.mopnhPrevSpindleRunTime.Text = ArrayToString(objMopnh.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.SpindleRunTime))

        Me.mopnhMaxNoofReports.Text = objMopnh.GetMaxCount()
        Exit Sub

sd:

        DisplayError("MacMan Operating History Report", Err.Description)
        Resume Next
    End Sub
#End Region

#Region "MacMan Machining Report"
    Private Sub macReportUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles macReportUpdateButton.Click
        On Error GoTo sd
        Dim Mac_reportObject As MacMan.CMachining
        Dim int_PeriodReport As Int32
        Dim opIndex As Int16
        int_PeriodReport = CInt(Me.Cmb_rptPeriod.SelectedItem)
        opIndex = CInt(Me.MacReport_Index.Text)
        Mac_reportObject = objMeh.GetMachiningReport(opIndex, int_PeriodReport)
        Me.MacReport_count.Text = objMeh.GetCount(int_PeriodReport)
        Me.macreport_maxcount.Text = objMeh.GetMaxCount(int_PeriodReport)

        Me.MacreportTime.Text = Mac_reportObject.StartTime
        Me.Macreportdate.Text = Mac_reportObject.StartDate

        Me.macreport_cuttingtime.Text = Mac_reportObject.CuttingTime
        Me.macreport_Operatingtime.Text = Mac_reportObject.OperatingTime
        Me.macreport_Runningtime.Text = Mac_reportObject.RunningTime
        Me.Macreport_filename.Text = Mac_reportObject.MainProgramFileName
        Me.MacReport_programname.Text = Mac_reportObject.MainProgramName
        txtMachiningReport_NoOfWork.Text = Mac_reportObject.NumberOfWork


        Exit Sub
sd:

        DisplayError("MacMan Machining  Report", Err.Description)
        Resume Next
    End Sub


    Private Sub macreport_result_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles macreport_result.Click
        Dim Mac_reportObject As MacMan.CMachining
        Dim int_PeriodReport As Int32
        Dim mac_objects As ArrayList
        Dim opIndex As Int16


        Dim Mac_reportObjects As ArrayList

        Try
            int_PeriodReport = CInt(Me.Cmb_rptPeriod.SelectedItem)
            opIndex = CInt(Me.txtFrom.Text)
            mac_objects = objMeh.GetMachiningReports(CInt(txtFrom.Text), CInt(txtto.Text), int_PeriodReport)

            grdMMMachiningReports.DataSource = mac_objects
            grdMMMachiningReports.Refresh()



        Catch ae As ApplicationException
            DisplayError("MacMan Machining  Report", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("MacMan Machining  Report", ex.Message)
        End Try
    End Sub

#End Region



    Private Sub cmd_ChangeScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChangeScreen.Click
        '----------------datazen india
        Dim objview As Okuma.CMCMDAPI.CommandAPI.CViews
        Dim int_panalenum As Int32
        Try
            int_panalenum = CInt(Cmb_ChangeScreen.SelectedItem)
            objview = New Okuma.CMCMDAPI.CommandAPI.CViews
            objview.ChangeScreen(int_panalenum, txt_screenname.Text)
        Catch ae As ApplicationException
            DisplayError("Cview", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("Cview", ex.Message)
        End Try
    End Sub

    Private Sub cmd_InputMDI_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_InputMDI.Click
        '----------------DATAZEN India---------------

        Dim objmac As Okuma.CMCMDAPI.CommandAPI.CMachine

        Try
            objmac = New Okuma.CMCMDAPI.CommandAPI.CMachine
            objmac.InputMDI(Txt_mdicommand.Text)
        Catch ae As ApplicationException
            DisplayError("Cmachine", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("Cmachine", ex.Message)
        End Try
    End Sub

    Private Sub cmd_WorkpieceAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_WorkpieceAdd.Click

        Try
            objWorkPiece.AddWorkpieceCounter(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(wkCounterCombo.SelectedValue), CInt(Me.wkUpdateCounter.Text))
            wkCounterValue.Text = objWorkPiece.GetWorkpieceCounter(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(wkCounterCombo.SelectedValue))
        Catch ae As ApplicationException
            DisplayError("CWorkpiece", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

#Region "Private Function"
    Private Function ArrayToString(ByRef arInt() As Int32) As String
        Dim str As System.String = ""

        Dim intCount As Integer
        Dim intIndex As Integer

        intCount = UBound(arInt)

        For intIndex = 0 To intCount
            str = str + CStr(arInt(intIndex)) + "-"
        Next

        Return str

    End Function
#End Region


    Private Sub cmdGetMachineZeroOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetMachineZeroOffset.Click
        Try
            txtOutputMachineZeroOffset.Text = objMachine.GetZeroOffset(cboMachineZeroOffsetAxis.SelectedValue)
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub

    Private Sub cmdSetMachineZeroOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetMachineZeroOffset.Click
        Try
            objMachine.SetZeroOffset(cboMachineZeroOffsetAxis.SelectedValue, CDbl(txtInputMachineZeroOffset.Text))
            txtOutputMachineZeroOffset.Text = objMachine.GetZeroOffset(cboMachineZeroOffsetAxis.SelectedValue)

        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub

    Private Sub cmdAddMachineZeroOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddMachineZeroOffset.Click
        Try
            objMachine.AddZeroOffset(cboMachineZeroOffsetAxis.SelectedValue, CDbl(txtInputMachineZeroOffset.Text))
            txtOutputMachineZeroOffset.Text = objMachine.GetZeroOffset(cboMachineZeroOffsetAxis.SelectedValue)

        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub


    Private Sub cmdCalMachineZeroOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalMachineZeroOffset.Click
        Try
            objMachine.CalZeroOffset(cboMachineZeroOffsetAxis.SelectedValue, CDbl(txtInputMachineZeroOffset.Text))
            txtOutputMachineZeroOffset.Text = objMachine.GetZeroOffset(cboMachineZeroOffsetAxis.SelectedValue)

        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub


    Private Sub cmdMachineDataUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMachineDataUnit.Click
        Try
            objMachine.SetDataUnit(cboMachineDataUnit.SelectedValue)

        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub

    Private Sub cmdCancelProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelProgram.Click
        Dim objcprogram As New Okuma.CMCMDAPI.CommandAPI.CProgram

        Try
            objcprogram.CancelMainProgram()
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)

        End Try
    End Sub

    Private Sub tulAddCutterRCompOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulAddCutterRCompOffset.Click
        Try
            objTools.AddCutterRCompOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdCutterRCompOffset.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulAddCutterRCompWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulAddCutterRCompWearOffset.Click
        Try
            objTools.AddCutterRCompWearOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdCutterRCompWearOffset.Text))
            updateTools()
        Catch ae As ApplicationException
            DisplayError("CTool", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

#Region "Optional Parameter"
    Private Sub cmdOptionalParameterBitGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOptionalParameterBitGet.Click
        Try
            Me.txtOptionalParameterBit.Text = objOptionalParameter.GetNCOptionalParameterBit(CInt(Me.txtOptionalParameterBitIndex.Text), CInt(Me.txtOptionalParameterBitNo.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdOptionalParameterWordGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOptionalParameterWordGet.Click
        Try
            txtOptionalParameterWord.Text = objOptionalParameter.GetNCOptionalParameterWord(CInt(Me.txtOptionalParameterWordIndex.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdOptionalParameterLongWordGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOptionalParameterLongWordGet.Click
        Try
            txtOptionalParameterLongWord.Text = objOptionalParameter.GetNCOptionalParameterLongWord(CInt(Me.txtOptionalParameterLongWordIndex.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub


    Private Sub cmdBitSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBitSet.Click
        Try
            objOptionalParameter.SetNCOptionalParameterBit(CInt(Me.txtOptionalParameterBitIndex.Text), CInt(Me.txtOptionalParameterBitNo.Text), CBool(txtBitInput.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdWordSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWordSet.Click
        Try
            objOptionalParameter.SetNCOptionalParameterWord(CInt(Me.txtOptionalParameterWordIndex.Text), CInt(txtWordInput.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdLongWordSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLongWordSet.Click
        Try
            objOptionalParameter.SetNCOptionalParameterLongWord(CInt(Me.txtOptionalParameterLongWordIndex.Text), CInt(txtLongWordInput.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdWordAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWordAdd.Click
        Try
            objOptionalParameter.AddNCOptionalParameterWord(CInt(Me.txtOptionalParameterWordIndex.Text), CInt(txtWordInput.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdLongWordAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLongWordAdd.Click
        Try
            objOptionalParameter.AddNCOptionalParameterLongWord(CInt(Me.txtOptionalParameterLongWordIndex.Text), CInt(txtLongWordInput.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub
#End Region

#Region "PLC I/O"
    Private Sub cmdIOGetBit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetBit.Click
        Try
            Me.txtIOBit.Text = objIO.GetBitIO(Me.cboIOVariableTypes.SelectedValue, CInt(Me.txtIOBitIndex.Text), CInt(Me.txtIOBitNo.Text))
        Catch ae As ApplicationException
            DisplayError("I/O Variables", ae.Message)
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub
    Private Sub cmdIOGetWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetWord.Click
        Try
            Me.txtIOWord.Text = objIO.GetWordIO(Me.cboIOVariableTypes.SelectedValue, CInt(Me.txtIOWordIndex.Text))
        Catch ae As ApplicationException
            DisplayError("I/O Variables", ae.Message)
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub
    Private Sub cmdIOGetLongWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetLongWord.Click
        Try
            Me.txtIOLongWord.Text = objIO.GetLongWordIO(Me.cboIOVariableTypes.SelectedValue, CInt(Me.txtIOLongWordIndex.Text))
        Catch ae As ApplicationException
            DisplayError("I/O Variables", ae.Message)
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub
#End Region


#Region "Axis 2"
    Private Sub cmdAxis2DataUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAxis2DataUnit.Click
        Try
            objaxis2.SetDataUnit(Me.cboAxis2DataUnit.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Axis 2", ae.Message)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdUserParameterVariableLimitGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserParameterVariableLimitGet.Click
        Try
            Me.txtUserParameterLimit.Text = objaxis2.GetUserParameterVariableLimit(Me.cboUserParameterVariableLimitCoordinate.SelectedValue, Me.cboUserParameterVariableLimitAxis.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Axis 2", ae.Message)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub


    Private Sub cmdUserParameterVariableLimitSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserParameterVariableLimitSet.Click
        Try
            objaxis2.SetUserParameterVariableLimit(Me.cboUserParameterVariableLimitCoordinate.SelectedValue, Me.cboUserParameterVariableLimitAxis.SelectedValue, CDbl(Me.txtUserParameterLimitInput.Text))
        Catch ae As ApplicationException
            DisplayError("Axis 2", ae.Message)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdUserParameterVariableLimitAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserParameterVariableLimitAdd.Click
        Try
            objaxis2.AddUserParameterVariableLimit(Me.cboUserParameterVariableLimitCoordinate.SelectedValue, Me.cboUserParameterVariableLimitAxis.SelectedValue, CDbl(Me.txtUserParameterLimitInput.Text))
        Catch ae As ApplicationException
            DisplayError("Axis 2", ae.Message)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub
#End Region

#Region "Program 2 (G/M Code Macro)"
    Private Sub cmdGetProgramNameGCodeMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetProgramNameGCodeMod.Click
        Try
            txtProgramNameOutput.Text = objProgram.GetProgramGCodeMacro(CInt(txtGMCode.Text))
        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("CProgram", ne.Message)
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub


    Private Sub cmdGetProgramNameMCodeCall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetProgramNameMCodeCall.Click
        Try
            txtProgramNameOutput.Text = objProgram.GetProgramMCodeMacro(CInt(txtGMCode.Text))
        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("CProgram", ne.Message)
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub

    Private Sub cmdSetProgramNameGCodeMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetProgramNameGCodeMod.Click
        Try
            objProgram.SetProgramGCodeMacro(CInt(txtGMCode.Text), txtProgramNameInput.Text)
        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("CProgram", ne.Message)
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub



    Private Sub cmdSetProgramNameMCodeCall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetProgramNameMCodeCall.Click
        Try
            objProgram.SetProgramMCodeMacro(CInt(txtGMCode.Text), txtProgramNameInput.Text)
        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("CProgram", ne.Message)
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub
#End Region

#Region "Tools 2 - 1"
    Private Sub cmdToolID_DataUnit_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_DataUnit_Set.Click
        Try
            m_objToolID1.SetDataUnit(cboToolID_DataUnit.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_Update_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_Update_1.Click
        ToolIDUpdate_1()
    End Sub

    Private Sub ToolIDUpdate_1()
        Dim intToolPotNo As Integer
        Try
            intToolPotNo = CInt(txtToolID_PotNo.Text)
            'Tool Life
            txtToolID_ToolLife.Text = m_objToolID1.GetToolLife(intToolPotNo)
            txtToolID_ToolLifeRemaining.Text = m_objToolID1.GetToolLifeRemaining(intToolPotNo)
            txtToolID_ToolLifeRemainingSecond.Text = m_objToolID1.GetToolLifeRemainingTimeSecond(intToolPotNo)
            txtToolID_ToolLifeMode.Text = System.Enum.GetName(GetType(Okuma.CMDATAPI.Enumerations.ToolLifeModeEnum), m_objToolID1.GetMode(intToolPotNo))
            txtToolID_ToolLifeStatus.Text = System.Enum.GetName(GetType(Okuma.CMDATAPI.Enumerations.ToolLifeStatusEnum), m_objToolID1.GetStatus(intToolPotNo))

            'Offset
            txtToolID_CutterRCompOffset1.Text = m_objToolID1.GetCutterRCompOffset1(intToolPotNo)
            txtToolID_CutterRCompOffset2.Text = m_objToolID1.GetCutterRCompOffset2(intToolPotNo)
            txtToolID_CutterRCompOffset3.Text = m_objToolID1.GetCutterRCompOffset3(intToolPotNo)
            txtToolID_LengthOffset1.Text = m_objToolID1.GetToolLengthOffset1(intToolPotNo)
            txtToolID_LengthOffset2.Text = m_objToolID1.GetToolLengthOffset2(intToolPotNo)
            txtToolID_LengthOffset3.Text = m_objToolID1.GetToolLengthOffset3(intToolPotNo)

            txtToolID_ToolLengthWearOffset.Text = m_objToolID1.GetToolLengthWearOffset(intToolPotNo)
            txtToolID_CutterRCompWearOffset.Text = m_objToolID1.GetCutterRCompWearOffset(intToolPotNo)



        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolLife_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolLife_Set.Click
        Try
            m_objToolID1.SetToolLife(CInt(txtToolID_PotNo.Text), CInt(txtToolID_ToolLifeValue.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolLifeRemaining_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolLifeRemaining_Set.Click
        Try
            m_objToolID1.SetToolLifeRemaining(CInt(txtToolID_PotNo.Text), CInt(txtToolID_ToolLifeRemainingValue.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LifeStatus_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LifeStatus_Set.Click
        Try
            m_objCmdATC2.SetToolLifeStatus(CInt(txtToolID_PotNo.Text), cboToolID_ToolLifeStatus.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub


    Private Sub cmdToolID_ToolLifeMode_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolLifeMode_Set.Click
        Try
            m_objToolID1.SetMode(CInt(txtToolID_PotNo.Text), cboToolID_ToolLifeMode.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRCompOffset1_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompOffset1_Set.Click

        Try
            m_objToolID1.SetCutterRCompOffset1(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompOffset1Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub


    Private Sub cmdToolID_CutterRCompOffset1_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompOffset1_Add.Click

        Try
            m_objToolID1.AddCutterRCompOffset1(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompOffset1Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRCompOffset2_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompOffset2_Set.Click
        Try
            m_objToolID1.SetCutterRCompOffset2(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompOffset2Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRCompOffset2_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompOffset2_Add.Click
        Try
            m_objToolID1.AddCutterRCompOffset2(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompOffset2Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRCompOffset3_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompOffset3_Set.Click
        Try
            m_objToolID1.SetCutterRCompOffset3(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompOffset3Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRCompOffset3_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompOffset3_Add.Click
        Try
            m_objToolID1.AddCutterRCompOffset3(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompOffset3Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset1_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset1_Set.Click
        Try
            m_objToolID1.SetToolLengthOffset1(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset1Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset1_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset1_Add.Click
        Try
            m_objToolID1.AddToolLengthOffset1(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset1Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset1_Cal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset1_Cal.Click
        Try
            m_objToolID1.CalToolLengthOffset1(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset1Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset2_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset2_Set.Click
        Try
            m_objToolID1.SetToolLengthOffset2(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset2Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset2_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset2_Add.Click
        Try
            m_objToolID1.AddToolLengthOffset2(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset2Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset2_Cal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset2_Cal.Click
        Try
            m_objToolID1.CalToolLengthOffset2(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset2Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset3_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset3_Set.Click
        Try
            m_objToolID1.SetToolLengthOffset3(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset3Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset3_Cal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset3_Cal.Click
        Try
            m_objToolID1.CalToolLengthOffset3(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset3Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset3_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset3_Add.Click
        Try
            m_objToolID1.AddToolLengthOffset3(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset3Value.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolLengthWearOffset_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolLengthWearOffset_Set.Click
        Try
            m_objToolID1.SetToolLengthWearOffset(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_ToolLengthWearOffsetValue.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolLengthWearOffset_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolLengthWearOffset_Add.Click
        Try
            m_objToolID1.AddToolLengthWearOffset(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_ToolLengthWearOffsetValue.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRCompWearOffset_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompWearOffset_Set.Click
        Try
            m_objToolID1.SetCutterRCompWearOffset(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompWearOffsetValue.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRCompWearOffset_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompWearOffset_Add.Click
        Try
            m_objToolID1.AddCutterRCompWearOffset(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompWearOffsetValue.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LenghtOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LenghtOffset.Click

        Dim intFromPot As Integer
        Dim intToPot As Integer
        Dim intIndex As Integer
        Dim intCount As Integer
        Dim dblValue As Double
        Dim arValues As ArrayList


        Try
            lstToolID_Offset.DataSource = Nothing

            lstToolID_Offset.Items.Clear()

            intFromPot = CInt(txtToolID_FromPot.Text)
            intToPot = CInt(txtToolID_ToPot.Text)

            Select Case (CInt(txtToolID_OffsetIndex123.Text))
                Case 1
                    arValues = m_objToolID1.GetToolLengthOffset1(intFromPot, intToPot)
                Case 2
                    arValues = m_objToolID1.GetToolLengthOffset2(intFromPot, intToPot)
                Case 3
                    arValues = m_objToolID1.GetToolLengthOffset3(intFromPot, intToPot)

            End Select

            lstToolID_Offset.DataSource = arValues

        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterROffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterROffset.Click

        Dim intFromPot As Integer
        Dim intToPot As Integer
        Dim intIndex As Integer
        Dim intCount As Integer
        Dim arValues As ArrayList


        Try


            lstToolID_Offset.DataSource = Nothing

            lstToolID_Offset.Items.Clear()

            intFromPot = CInt(txtToolID_FromPot.Text)
            intToPot = CInt(txtToolID_ToPot.Text)

            Select Case (CInt(txtToolID_OffsetIndex123.Text))
                Case 1
                    arValues = m_objToolID1.GetCutterRCompOffset1(intFromPot, intToPot)
                Case 2
                    arValues = m_objToolID1.GetCutterRCompOffset2(intFromPot, intToPot)
                Case 3
                    arValues = m_objToolID1.GetCutterRCompOffset3(intFromPot, intToPot)

            End Select

            lstToolID_Offset.DataSource = arValues

        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub


    Private Sub cmdToolID_LengthWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthWearOffset.Click
        Dim intFromPot As Integer
        Dim intToPot As Integer
        Dim intIndex As Integer
        Dim intCount As Integer
        Dim arValues As ArrayList


        Try


            lstToolID_Offset.DataSource = Nothing

            lstToolID_Offset.Items.Clear()

            intFromPot = CInt(txtToolID_FromPot.Text)
            intToPot = CInt(txtToolID_ToPot.Text)


            arValues = m_objToolID1.GetToolLengthWearOffset(intFromPot, intToPot)

            lstToolID_Offset.DataSource = arValues


        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRWearOffset.Click
        Dim intFromPot As Integer
        Dim intToPot As Integer
        Dim intIndex As Integer
        Dim intCount As Integer
        Dim arValues As ArrayList


        Try


            lstToolID_Offset.DataSource = Nothing

            lstToolID_Offset.Items.Clear()

            intFromPot = CInt(txtToolID_FromPot.Text)
            intToPot = CInt(txtToolID_ToPot.Text)


            arValues = m_objToolID1.GetCutterRCompWearOffset(intFromPot, intToPot)

            lstToolID_Offset.DataSource = arValues


        Catch ae As ApplicationException
            DisplayError("Tools 2 - 1", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub
#End Region
#Region "Tools 2 - 2"
    Private Sub cmdToolID_2_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_2_Update.Click
        Dim intToolPotNo As Integer
        Dim strValue As String
        Dim enATCType As Okuma.CMDATAPI.Enumerations.ATCTypeEnum
        Try
            enATCType = objAtc.GetATCType()
            lstToolID_Update.Items.Clear()

            intToolPotNo = CInt(txtToolID_PotNo_2.Text)

            If enATCType = ATCTypeEnum.RandomAddress Then
                txtToolID_RATC_PotNo.Text = m_objToolID2.GetPotNo(intToolPotNo)
                txtTools2_ToolInPot.Text = m_objToolID2.GetToolNo(CInt(txtToolID_RATC_PotNo.Text))

                strValue = m_objToolID2.GetMaxTools().ToString
                lstToolID_Update.Items.Add(String.Format("Max Tool Group: {0}", strValue))
            Else
                txtToolID_RATC_PotNo.Text = "N/A"
                txtTools2_ToolInPot.Text = "N/A"
            End If


            txtToolID_GroupNo.Text = m_objToolID2.GetGroupNo(intToolPotNo)
            txtToolID_SerialNo.Text = m_objToolID2.GetSerialNo(intToolPotNo)
            txtToolID_AdjustmentTool.Text = m_objToolID2.IsAdjustmentTool(intToolPotNo).ToString
            txtToolID_StandardTool.Text = m_objToolID2.IsStandardTool(intToolPotNo).ToString
            txtToolID_PotInUse.Text = m_objToolID2.IsToolInUse(intToolPotNo).ToString



            txtToolID_CarrierStatus.Text = System.Enum.GetName(GetType(Okuma.CMDATAPI.Enumerations.CarrierStatusEnum), m_objToolID2.GetCarrierStatus(intToolPotNo))

            'functions without parameters

            strValue = m_objToolID2.GetMaxPots().ToString
            lstToolID_Update.Items.Add(String.Format("Max Pots: {0}", strValue))


            txtToolID_ToolName.Text = m_objToolID2.GetToolName(intToolPotNo)
            txtToolID_ToolKind.Text = m_objToolID2.GetToolKind(intToolPotNo)
            txtToolID_ToolType.Text = System.Enum.GetName(GetType(Okuma.CMDATAPI.Enumerations.ToolTypeEnum), m_objToolID2.GetToolType(intToolPotNo))
            txtToolID_ToolDiameter.Text = m_objToolID2.GetToolDiameter(intToolPotNo)
            txtToolID_ToolAngle.Text = m_objToolID2.GetToolAngle(intToolPotNo)
            txtToolID_ToolNoseDiameter.Text = m_objToolID2.GetToolNoseDiameter(intToolPotNo)

        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_DataUnit_2_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_DataUnit_2_Set.Click
        Try
            m_objToolID2.SetDataUnit(cboToolID_DataUnit_2.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CarrierStatus_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CarrierStatus_Set.Click
        Try
            m_objCmdATC2.SetToolCarrierStatus(CInt(txtToolID_PotNo_2.Text), cboToolID_CarrierStatus.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub


    Private Sub cmdToolID_RegisterToolPot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_RegisterToolPot.Click
        Dim intGroupNo As Integer
        Dim intSerialNo As Integer
        Dim blnDummyTool As Boolean
        Dim strToolName As String
        Dim enATCType As Okuma.CMDATAPI.Enumerations.ATCTypeEnum
        Try
            enATCType = objAtc.GetATCType()

            intGroupNo = CInt(txtToolID_GroupNoValue.Text)
            intSerialNo = CInt(txtToolID_SerialNoValue.Text)
            blnDummyTool = chkToolID_DummyTool.Checked
            strToolName = txtToolID_ToolNameValue.Text

            If enATCType = ATCTypeEnum.RandomAddress Then
                m_objCmdATC2.RegisterToolPot(CInt(txtToolID_PotNo_2.Text), CInt(txtToolID_RATC_PotNoValue.Text), intGroupNo, intSerialNo, blnDummyTool, strToolName)
            Else
                m_objCmdATC2.RegisterToolPot(CInt(txtToolID_PotNo_2.Text), intGroupNo, intSerialNo, blnDummyTool, strToolName)
            End If

        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub


    Private Sub cmdToolID_UnRegisterToolPot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_UnRegisterToolPot.Click
        Dim enATCType As Okuma.CMDATAPI.Enumerations.ATCTypeEnum
        Try
            enATCType = objAtc.GetATCType()
            If enATCType = ATCTypeEnum.RandomAddress Then
                m_objCmdATC2.UnRegisterToolPot(CInt(Me.txtToolID_RATC_PotNoValue.Text), CInt(txtToolID_PotNo_2.Text), True)
            Else
                m_objCmdATC2.UnRegisterToolPot(CInt(Me.txtToolID_RATC_PotNoValue.Text), CInt(txtToolID_PotNo_2.Text), False)
            End If
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_PotInUse_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_PotInUse_Set.Click
        Try
            Me.m_objToolID2.SetToolInUse(CInt(txtToolID_PotNo_2.Text), cboYesNo_PotInUse.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolKind_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolKind_Set.Click
        Try
            m_objCmdATC2.SetToolKind(CInt(txtToolID_PotNo_2.Text), cboToolID_ToolKind.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_AdjustmentTool_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_AdjustmentTool_Set.Click
        Try
            Me.m_objToolID2.SetAdjustmentTool(CInt(txtToolID_PotNo_2.Text), cboYesNo_AdjustmentTool.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_StandardTool_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_StandardTool_Set.Click
        Try
            Me.m_objToolID2.SetStandardTool(CInt(txtToolID_PotNo_2.Text), cboYesNo_StandardTool.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolType_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolType_Set.Click
        Try
            Me.m_objToolID2.SetToolType(CInt(txtToolID_PotNo_2.Text), cboToolID_ToolType.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolAngle_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolAngle_Set.Click
        Try
            Me.m_objToolID2.SetToolAngle(CInt(txtToolID_PotNo_2.Text), CDbl(txtToolID_ToolAngleValue.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolDiameter_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolDiameter_Set.Click
        Try
            Me.m_objToolID2.SetToolDiameter(CInt(txtToolID_PotNo_2.Text), CDbl(txtToolID_ToolDiameterValue.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolNoseDiameter_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolNoseDiameter_Set.Click
        Try
            Me.m_objToolID2.SetToolNoseDiameter(CInt(txtToolID_PotNo_2.Text), CDbl(txtToolID_ToolNoseDiameterValue.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolDiameter_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolDiameter_Add.Click
        Try
            Me.m_objToolID2.AddToolDiameter(CInt(txtToolID_PotNo_2.Text), CDbl(txtToolID_ToolDiameterValue.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolAngle_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolAngle_Add.Click
        Try
            Me.m_objToolID2.AddToolAngle(CInt(txtToolID_PotNo_2.Text), CDbl(txtToolID_ToolAngleValue.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolNoseDiameter_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolNoseDiameter_Add.Click
        Try
            Me.m_objToolID2.AddToolNoseDiameter(CInt(txtToolID_PotNo_2.Text), CDbl(txtToolID_ToolNoseDiameterValue.Text))
        Catch ae As ApplicationException
            DisplayError("Tools 2 - 2", ae.Message)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub
#End Region





#Region "Current Alarm"
    Private Sub cmdCurrentAlarm_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCurrentAlarm_Update.Click
        Dim objCurrentAlarm As CCurrentAlarm
        Try
            objCurrentAlarm = objMachine.GetCurrentAlarm()

            txtCurrentAlarm_AlarmNumber.Text = objCurrentAlarm.AlarmNumber()
            txtCurrentAlarm_ObjectNumber.Text = objCurrentAlarm.ObjectNumber
            txtCurrentAlarm_ObjectMessage.Text = objCurrentAlarm.ObjectMessage()
            txtCurrentAlarm_AlarmMessage.Text = objCurrentAlarm.AlarmMessage()
            txtCurrentAlarm_AlarmCharacterString.Text = objCurrentAlarm.AlarmCharacterString()
            txtCurrentAlarm_AlarmCode.Text = objCurrentAlarm.AlarmCode()
            txtCurrentAlarm_AlarmLevel.Text = System.Enum.GetName(GetType(OSPAlarmLevelEnum), objCurrentAlarm.AlarmLevel())


        Catch ae As ApplicationException
            DisplayError("Current Alarm", ae.Message)
        Catch ex As Exception
            DisplayError("Current Alarm", ex.Message)
        End Try
    End Sub
#End Region





End Class
