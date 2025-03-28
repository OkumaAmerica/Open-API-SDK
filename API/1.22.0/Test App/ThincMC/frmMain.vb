Imports System
Imports System.Threading
Imports System.ComponentModel
Imports System.Resources
Imports System.Globalization
Imports System.Reflection

Imports Okuma.CMDATAPI.DataAPI
Imports Okuma.CMDATAPI.Enumerations
Imports Okuma.CMCMDAPI.Enumerations
Imports Okuma.CMDATAPI.Structures




Public Class frmMain
    Inherits System.Windows.Forms.Form
    Dim m_objMachine As CMachine
    Dim m_objAtc As CATC
    Dim m_objAxis As CAxis
    Dim m_objAxis2 As CAxis
    Dim m_objBS As CBallScrew
    Dim m_objCoolant As CCoolant
    Dim m_objCMOP As CMOPTool
    Dim m_objProgram As CProgram
    Dim m_objSpec As CSpec
    Dim m_objSpindle As CSpindle
    Dim m_objTools As CTools
    Dim m_objVariables As CVariables
    Dim m_objWorkPiece As CWorkpiece
    Dim m_objAlarmHistory As MacMan.CAlarmHistory
    Dim m_objOperatingReport As MacMan.COperatingReport
    Dim m_objOperationHistory As MacMan.COperationHistory
    Dim m_objOperatingHistory As MacMan.COperatingHistory
    Dim m_objMachiningReport As MacMan.CMachiningReport '--------------

    Dim m_objIO As Okuma.CMDATAPI.DataAPI.CIO
    Dim m_objOptionalParameter As Okuma.CMDATAPI.DataAPI.COptionalParameter

    Dim m_objToolID1 As Okuma.CMDATAPI.DataAPI.CTools2
    Dim m_objToolID2 As Okuma.CMDATAPI.DataAPI.CTools2

    Friend WithEvents tabAPILoggingService As System.Windows.Forms.TabPage
    Friend WithEvents dgvLogging As System.Windows.Forms.DataGridView
    Friend WithEvents DateLoggedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AppNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClassNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MethodNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IOParametersDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoggingLevelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MessageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLogRecordBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox40 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLogMessage As System.Windows.Forms.TextBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents txtLogIOParameters As System.Windows.Forms.TextBox
    Friend WithEvents lblIOParameters As System.Windows.Forms.Label
    Friend WithEvents txtLogFunctionName As System.Windows.Forms.TextBox
    Friend WithEvents lblFunctionName As System.Windows.Forms.Label
    Friend WithEvents txtLogClassName As System.Windows.Forms.TextBox
    Friend WithEvents lblClassName As System.Windows.Forms.Label
    Friend WithEvents txtLogAppName As System.Windows.Forms.TextBox
    Friend WithEvents lblAppName As System.Windows.Forms.Label
    Friend WithEvents btnDisplayLogRecords As System.Windows.Forms.Button
    Friend WithEvents Label326 As System.Windows.Forms.Label
    Friend WithEvents cboLoggingLevel As System.Windows.Forms.ComboBox
    Friend WithEvents Label327 As System.Windows.Forms.Label
    Friend WithEvents Label328 As System.Windows.Forms.Label
    Friend WithEvents dtpEndingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboAllLoggingLevel As System.Windows.Forms.ComboBox
    Friend WithEvents tab_ATCSubPanel As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox41 As System.Windows.Forms.GroupBox
    Friend WithEvents Label329 As System.Windows.Forms.Label
    Friend WithEvents txtATCSubGroupNo As System.Windows.Forms.TextBox
    Friend WithEvents txtATCSubSerialNo As System.Windows.Forms.TextBox
    Friend WithEvents btnATCSubSearchPotByToolName As System.Windows.Forms.Button
    Friend WithEvents Label333 As System.Windows.Forms.Label
    Friend WithEvents txtATCSubToolName As System.Windows.Forms.TextBox
    Friend WithEvents Label334 As System.Windows.Forms.Label
    Friend WithEvents txtATCSubReturnPotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label335 As System.Windows.Forms.Label
    Friend WithEvents btnATCSubSearchPotByGroupSerial As System.Windows.Forms.Button
    Friend WithEvents btnATCSubClearError As System.Windows.Forms.Button
    Friend WithEvents GroupBox42 As System.Windows.Forms.GroupBox
    Friend WithEvents txtATCSubOperationMode As System.Windows.Forms.TextBox
    Friend WithEvents btnATCSubGetOperationMode As System.Windows.Forms.Button
    Friend WithEvents cboATCSubPanelOperationModes As System.Windows.Forms.ComboBox
    Friend WithEvents btnATCSubSetOperationMode As System.Windows.Forms.Button
    Friend WithEvents GroupBox43 As System.Windows.Forms.GroupBox
    Friend WithEvents txtATCSubToolNo As System.Windows.Forms.TextBox
    Friend WithEvents Label332 As System.Windows.Forms.Label
    Friend WithEvents txtATCSubPotNo As System.Windows.Forms.TextBox
    Friend WithEvents Label336 As System.Windows.Forms.Label
    Friend WithEvents btnATCSubGetErrorCode As System.Windows.Forms.Button
    Friend WithEvents btnATCGetPotNo As System.Windows.Forms.Button
    Friend WithEvents btnATCSubGetToolNo As System.Windows.Forms.Button
    Friend WithEvents Label330 As System.Windows.Forms.Label
    Friend WithEvents txtATCSubErrorCode As System.Windows.Forms.TextBox

    Dim m_objCmdATC2 As Okuma.CMCMDAPI.CommandAPI.CATC2
    Friend WithEvents btnATCPanelSetIndexToolNo As System.Windows.Forms.Button
    Friend WithEvents Label331 As System.Windows.Forms.Label
    Friend WithEvents txtATCPanelIndexPotNo As System.Windows.Forms.TextBox
    Friend WithEvents btnP300GetAttachedToolList As System.Windows.Forms.Button
    Friend WithEvents btnP300GetAllToolList As System.Windows.Forms.Button
    Friend WithEvents txtP300ToolsUpdate2 As System.Windows.Forms.TextBox
    Friend WithEvents btnP300GetRegisteredToolList As System.Windows.Forms.Button
    Friend WithEvents btnGetPLC3SpecCode As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnGetPalletID As System.Windows.Forms.Button
    Friend WithEvents txtPalletID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox44 As System.Windows.Forms.GroupBox
    Friend WithEvents chkP300TLDataOverwrite As System.Windows.Forms.CheckBox
    Friend WithEvents btnP300TLDataOutput As System.Windows.Forms.Button
    Friend WithEvents btnP300TLDataInput As System.Windows.Forms.Button
    Friend WithEvents Label393 As System.Windows.Forms.Label
    Friend WithEvents txtLoadSaveToolNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label399 As System.Windows.Forms.Label
    Friend WithEvents txtLoadSaveFolderPath As System.Windows.Forms.TextBox

    Dim m_objCmdATCPanel As Okuma.CMCMDAPI.CommandAPI.CATCPanel
    Dim m_objCmdATC As Okuma.CMCMDAPI.CommandAPI.CATC


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
    Friend WithEvents grpUserTaskIOVariable As System.Windows.Forms.GroupBox
    Friend WithEvents cboSetUserTaskOutputVariableProtected As System.Windows.Forms.ComboBox
    Friend WithEvents cboSetUserTaskOutputVariable As System.Windows.Forms.ComboBox
    Friend WithEvents btnSetProtectedUserTaskOutputVariable As System.Windows.Forms.Button
    Friend WithEvents txtSetProtectedUserTaskIOOutputVariableIndex As System.Windows.Forms.TextBox
    Friend WithEvents txtGetProtectedUserTaskIOOutputVariableValue As System.Windows.Forms.TextBox
    Friend WithEvents btnGetProtectedUserTaskOutputVariable As System.Windows.Forms.Button
    Friend WithEvents txtGetProtectedUserTaskIOOutputVariableIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label338 As System.Windows.Forms.Label
    Friend WithEvents btnSetUserTaskOutputVariable As System.Windows.Forms.Button
    Friend WithEvents txtSetUserTaskIOOutputVariableIndex As System.Windows.Forms.TextBox
    Friend WithEvents txtUserTaskIOOutputVariableValue As System.Windows.Forms.TextBox
    Friend WithEvents btnGetUserTaskOutputIOVariable As System.Windows.Forms.Button
    Friend WithEvents txtUserTaskIOOutputVariableIndex As System.Windows.Forms.TextBox
    Friend WithEvents txtUserTaskIOInputVariableValue As System.Windows.Forms.TextBox
    Friend WithEvents btnGetUserTaskInputIOVariable As System.Windows.Forms.Button
    Friend WithEvents txtUserTaskIOInputVariableIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label337 As System.Windows.Forms.Label
    Friend WithEvents btnProbeUpdate As System.Windows.Forms.Button
    Friend WithEvents txtProbePositionY As System.Windows.Forms.TextBox
    Friend WithEvents txtProbePositionX As System.Windows.Forms.TextBox
    Friend WithEvents Label253 As System.Windows.Forms.Label
    Friend WithEvents Label254 As System.Windows.Forms.Label
    Friend WithEvents txtProbePositionA As System.Windows.Forms.TextBox
    Friend WithEvents txtProbePositionZ As System.Windows.Forms.TextBox
    Friend WithEvents Label255 As System.Windows.Forms.Label
    Friend WithEvents Label256 As System.Windows.Forms.Label
    Friend WithEvents txtProbePositionC As System.Windows.Forms.TextBox
    Friend WithEvents txtProbePositionB As System.Windows.Forms.TextBox
    Friend WithEvents Label257 As System.Windows.Forms.Label
    Friend WithEvents Label258 As System.Windows.Forms.Label
    Friend WithEvents txtProbeSubProgramStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label259 As System.Windows.Forms.Label
    Friend WithEvents btnProbeSubProgramStatus As System.Windows.Forms.Button
    Friend WithEvents txtTouchProbeSignal As System.Windows.Forms.TextBox
    Friend WithEvents Label260 As System.Windows.Forms.Label
    Friend WithEvents btnGetTouchProbeSignal As System.Windows.Forms.Button
    Friend WithEvents txtSubProgramFileName As System.Windows.Forms.Button
    Friend WithEvents cboSR_MIDBlockRestart As System.Windows.Forms.ComboBox
    Friend WithEvents btnSelectSubProgram As System.Windows.Forms.Button
    Friend WithEvents txtSelectSubProgram As System.Windows.Forms.TextBox
    Friend WithEvents Label261 As System.Windows.Forms.Label
    Friend WithEvents tab_Renishaw_1 As System.Windows.Forms.TabPage
    Friend WithEvents tab_Renishaw_2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox22 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox25 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRowMatrix As System.Windows.Forms.TextBox
    Friend WithEvents Label307 As System.Windows.Forms.Label
    Friend WithEvents txtColumnMatrix As System.Windows.Forms.TextBox
    Friend WithEvents txtRotateAmountISC As System.Windows.Forms.TextBox
    Friend WithEvents btnGetRotateAmoutISC As System.Windows.Forms.Button
    Friend WithEvents txtRotateAmountSC As System.Windows.Forms.TextBox
    Friend WithEvents btnGetRotateAmoutSC As System.Windows.Forms.Button
    Friend WithEvents txtShiftAmountISC As System.Windows.Forms.TextBox
    Friend WithEvents btnGetShiftAmoutISC As System.Windows.Forms.Button
    Friend WithEvents txtShiftAmountSC As System.Windows.Forms.TextBox
    Friend WithEvents btnGetShiftAmoutSC As System.Windows.Forms.Button
    Friend WithEvents Label305 As System.Windows.Forms.Label
    Friend WithEvents cboSlopeCoordAxisIndex As System.Windows.Forms.ComboBox
    Friend WithEvents Label306 As System.Windows.Forms.Label
    Friend WithEvents GroupBox24 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGetRotatyAxisName As System.Windows.Forms.Button
    Friend WithEvents txtRotaryAxisName As System.Windows.Forms.TextBox
    Friend WithEvents cboRotaryAxes As System.Windows.Forms.ComboBox
    Friend WithEvents Label262 As System.Windows.Forms.Label
    Friend WithEvents btnRotaryAxisSetupStructure As System.Windows.Forms.Button
    Friend WithEvents txtRotaryAxisSetupStructure As System.Windows.Forms.TextBox
    Friend WithEvents btnRotaryAxisSetupPosition As System.Windows.Forms.Button
    Friend WithEvents txtRotaryAxisSetupPosition As System.Windows.Forms.TextBox
    Friend WithEvents btnRotaryAxisISO As System.Windows.Forms.Button
    Friend WithEvents txtRotaryAxisISO As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox23 As System.Windows.Forms.GroupBox
    Friend WithEvents Label304 As System.Windows.Forms.Label
    Friend WithEvents cboRotaryAxisStructure As System.Windows.Forms.ComboBox
    Friend WithEvents Label298 As System.Windows.Forms.Label
    Friend WithEvents cboLinearAxisIndex As System.Windows.Forms.ComboBox
    Friend WithEvents Label263 As System.Windows.Forms.Label
    Friend WithEvents cboRotationCenters As System.Windows.Forms.ComboBox
    Friend WithEvents btnGetRotationCenterSetupPosition As System.Windows.Forms.Button
    Friend WithEvents txtRotationCenterSetupPosition As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectSubProgram2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox26 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGetPLC2SpecCode As System.Windows.Forms.Button
    Friend WithEvents Label308 As System.Windows.Forms.Label
    Friend WithEvents txtPLCSpecCodeBit As System.Windows.Forms.TextBox
    Friend WithEvents Label309 As System.Windows.Forms.Label
    Friend WithEvents txtPLCSpecCodeIndex As System.Windows.Forms.TextBox
    Friend WithEvents btnGetPLCSpecCode As System.Windows.Forms.Button
    Friend WithEvents txtPLCSpecCode As System.Windows.Forms.TextBox
    Friend WithEvents cboUserAlarm As System.Windows.Forms.ComboBox
    Friend WithEvents txtUserAlarmMessage As System.Windows.Forms.TextBox
    Friend WithEvents btnClearUserAlarmD As System.Windows.Forms.Button
    Friend WithEvents btnSetUserAlarm As System.Windows.Forms.Button
    Friend WithEvents txtInputMDI As System.Windows.Forms.TextBox
    Friend WithEvents txtMachine As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox29 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox27 As System.Windows.Forms.GroupBox
    Friend WithEvents btnP300AddToolOffset As System.Windows.Forms.Button
    Friend WithEvents txtP300ToolOffsetSetValue As System.Windows.Forms.TextBox
    Friend WithEvents btnP300GetToolOffset As System.Windows.Forms.Button
    Friend WithEvents txtP300ToolOffset As System.Windows.Forms.TextBox
    Friend WithEvents btnP300CalToolOffset As System.Windows.Forms.Button
    Friend WithEvents btnP300SetToolOffset As System.Windows.Forms.Button
    Friend WithEvents GroupBox28 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox31 As System.Windows.Forms.GroupBox
    Friend WithEvents btnP300AddToolWear As System.Windows.Forms.Button
    Friend WithEvents txtP300ToolWearSetValue As System.Windows.Forms.TextBox
    Friend WithEvents btnP300GetToolWear As System.Windows.Forms.Button
    Friend WithEvents txtP300ToolWear As System.Windows.Forms.TextBox
    Friend WithEvents btnP300SetToolWear As System.Windows.Forms.Button
    Friend WithEvents GroupBox32 As System.Windows.Forms.GroupBox
    Friend WithEvents btnP300AddNoseRComp As System.Windows.Forms.Button
    Friend WithEvents txtP300NoseRCompSetValue As System.Windows.Forms.TextBox
    Friend WithEvents btnP300GetNoseRComp As System.Windows.Forms.Button
    Friend WithEvents txtP300NoseRComp As System.Windows.Forms.TextBox
    Friend WithEvents btnP300SetNoseRComp As System.Windows.Forms.Button
    Friend WithEvents GroupBox35 As System.Windows.Forms.GroupBox
    Friend WithEvents txtP300ToolLifeSetValue As System.Windows.Forms.TextBox
    Friend WithEvents btnP300GetToolLifeSet As System.Windows.Forms.Button
    Friend WithEvents txtP300ToolLifeSet As System.Windows.Forms.TextBox
    Friend WithEvents btnP300SetToolLifeSet As System.Windows.Forms.Button
    Friend WithEvents GroupBox36 As System.Windows.Forms.GroupBox
    Friend WithEvents txtP300ToolGaugeStatusValue As System.Windows.Forms.GroupBox
    Friend WithEvents btnP300GetToolLifeStatus As System.Windows.Forms.Button
    Friend WithEvents txtP300ToolLifeStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnP300SetToolLifeStatus As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtP300GroupNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnP300ToolSetDataUnit As System.Windows.Forms.Button
    Friend WithEvents Label342 As System.Windows.Forms.Label
    Friend WithEvents cboP300ToolsDataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents txtP300ToolNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label340 As System.Windows.Forms.Label
    Friend WithEvents cboP300ToolCompensation As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnP300AddNoseRCompWear As System.Windows.Forms.Button
    Friend WithEvents btnP300GetNoseRCompWear As System.Windows.Forms.Button
    Friend WithEvents btnP300CalNoseRCompWear As System.Windows.Forms.Button
    Friend WithEvents btnP300SetNoseRCompWear As System.Windows.Forms.Button
    Friend WithEvents txtP300NoseRCompWearSetValue As System.Windows.Forms.TextBox
    Friend WithEvents txtP300NoseRCompWear As System.Windows.Forms.TextBox
    Friend WithEvents txtP300ToolLifeLeftValue As System.Windows.Forms.TextBox
    Friend WithEvents txtP300ToolLifeLeft As System.Windows.Forms.TextBox
    Friend WithEvents btnP300GetToolLifeLeft As System.Windows.Forms.Button
    Friend WithEvents btnP300SetToolLifeLeft As System.Windows.Forms.Button
    Friend WithEvents btnP300ToolUpdate As System.Windows.Forms.Button
    Friend WithEvents txtP300ToolsUpdate As System.Windows.Forms.TextBox
    Friend WithEvents cboP300ToolLifeStatus As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox30 As System.Windows.Forms.GroupBox
    Friend WithEvents txtP300ToolGroupNoValue As System.Windows.Forms.TextBox
    Friend WithEvents btnP300GetToolGroupNo As System.Windows.Forms.Button
    Friend WithEvents txtP300ToolGroupNo As System.Windows.Forms.TextBox
    Friend WithEvents btnP300SetToolGroupNo As System.Windows.Forms.Button
    Friend WithEvents tabMain As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox33 As System.Windows.Forms.GroupBox
    Friend WithEvents cboP300ToolKind2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label137 As System.Windows.Forms.Label
    Friend WithEvents Label310 As System.Windows.Forms.Label
    Friend WithEvents cboP300HeightKind As System.Windows.Forms.ComboBox
    Friend WithEvents Label311 As System.Windows.Forms.Label
    Friend WithEvents Label312 As System.Windows.Forms.Label
    Friend WithEvents chkP300ManualAttachmentToolATCType As System.Windows.Forms.CheckBox
    Friend WithEvents btnP300DeleteTool As System.Windows.Forms.Button
    Friend WithEvents btbP300RegisterTool As System.Windows.Forms.Button
    Friend WithEvents txtP300MaxToolSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label313 As System.Windows.Forms.Label
    Friend WithEvents cboP300DiameterKind As System.Windows.Forms.ComboBox
    Friend WithEvents tab_P300ATC As System.Windows.Forms.TabPage
    Friend WithEvents cboP300WeightKind As System.Windows.Forms.ComboBox
    Friend WithEvents txtP300ATCToolNo As System.Windows.Forms.TextBox
    Friend WithEvents txtP300ATCPotNo As System.Windows.Forms.TextBox
    Friend WithEvents chkP300ThroughCoolantToolType As System.Windows.Forms.CheckBox
    Friend WithEvents btnAttachNextTool As System.Windows.Forms.Button
    Friend WithEvents btnP300AttachActualTool As System.Windows.Forms.Button
    Friend WithEvents btnP300UnregisterTool As System.Windows.Forms.Button
    Friend WithEvents btnAttachTool As System.Windows.Forms.Button
    Friend WithEvents GroupBox34 As System.Windows.Forms.GroupBox
    Friend WithEvents btnP300GetToolType As System.Windows.Forms.Button
    Friend WithEvents txtP300ToolType As System.Windows.Forms.TextBox
    Friend WithEvents txtControlType As System.Windows.Forms.TextBox
    Friend WithEvents Label314 As System.Windows.Forms.Label
    Friend WithEvents grpOptionalCommonVariable As System.Windows.Forms.GroupBox
    Friend WithEvents Label315 As System.Windows.Forms.Label
    Friend WithEvents txtOpCV As System.Windows.Forms.TextBox
    Friend WithEvents btnGetOpCV As System.Windows.Forms.Button
    Friend WithEvents btnGetAllOpCV As System.Windows.Forms.Button
    Friend WithEvents btnAddOpCV As System.Windows.Forms.Button
    Friend WithEvents btnSetOpCV As System.Windows.Forms.Button
    Friend WithEvents txtOpCVIndex2 As System.Windows.Forms.TextBox
    Friend WithEvents txtOpCVIndex1 As System.Windows.Forms.TextBox
    Friend WithEvents txtOpCVValue As System.Windows.Forms.TextBox
    Friend WithEvents Label317 As System.Windows.Forms.Label
    Friend WithEvents txtOpCVIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label318 As System.Windows.Forms.Label
    Friend WithEvents txtOpCVOutput As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelSubProgram As System.Windows.Forms.Button
    Friend WithEvents btnGetSlopeConverting As System.Windows.Forms.Button
    Friend WithEvents txtSlopeConverting As System.Windows.Forms.TextBox
    Friend WithEvents btnGetActiveProgramFilePath As System.Windows.Forms.Button
    Friend WithEvents txtActiveProgramFilePath As System.Windows.Forms.TextBox
    Friend WithEvents cmdIOGetBitByLabel As System.Windows.Forms.Button
    Friend WithEvents cmdIOGetWordByLabel As System.Windows.Forms.Button
    Friend WithEvents cmdIOGetLongWordByLabel As System.Windows.Forms.Button
    Friend WithEvents txtIOLongWordLabel As System.Windows.Forms.TextBox
    Friend WithEvents txtIOWordLabel As System.Windows.Forms.TextBox
    Friend WithEvents txtIOBitLabel As System.Windows.Forms.TextBox
    Friend WithEvents btnGetIOLabel As System.Windows.Forms.Button
    Friend WithEvents txtIOLabel As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox37 As System.Windows.Forms.GroupBox
    Friend WithEvents txtP300ToolMaxSpeedValue As System.Windows.Forms.TextBox
    Friend WithEvents btnP300GetToolMaxSpeed As System.Windows.Forms.Button
    Friend WithEvents txtP300ToolMaxSpeed As System.Windows.Forms.TextBox
    Friend WithEvents btnP300SetToolMaxSpeed As System.Windows.Forms.Button
    Friend WithEvents GroupBox38 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHomePosition As System.Windows.Forms.TextBox
    Friend WithEvents Label319 As System.Windows.Forms.Label
    Friend WithEvents Label320 As System.Windows.Forms.Label
    Friend WithEvents Label316 As System.Windows.Forms.Label
    Friend WithEvents txtHomePositionIndex As System.Windows.Forms.TextBox
    Friend WithEvents txtHomePositionMax As System.Windows.Forms.TextBox
    Friend WithEvents Label321 As System.Windows.Forms.Label
    Friend WithEvents txtRapidFeedrateOverride As System.Windows.Forms.TextBox
    Friend WithEvents Label322 As System.Windows.Forms.Label
    Friend WithEvents Label323 As System.Windows.Forms.Label
    Friend WithEvents txtOpCVMax As System.Windows.Forms.TextBox
    Friend WithEvents btnGetHomePosition As System.Windows.Forms.Button
    Friend WithEvents cboHomePositionAxis As System.Windows.Forms.ComboBox
    Friend WithEvents Label324 As System.Windows.Forms.Label
    Friend WithEvents txtHomePositionMovementOrder As System.Windows.Forms.TextBox
    Friend WithEvents btnGetHiCutProFeedrateUpperLimit As System.Windows.Forms.Button
    Friend WithEvents txtHiCutProMachiningTolerance As System.Windows.Forms.TextBox
    Friend WithEvents btnGetHiCutProMachiningTolerance As System.Windows.Forms.Button
    Friend WithEvents txtHiCutProFeedrateUpperLimit As System.Windows.Forms.TextBox
    Friend WithEvents Tab_OptionCommonVariables As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox39 As System.Windows.Forms.GroupBox
    Friend WithEvents txtP300ToolNameValue As System.Windows.Forms.TextBox
    Friend WithEvents btnP300GetToolName As System.Windows.Forms.Button
    Friend WithEvents txtP300ToolName As System.Windows.Forms.TextBox
    Friend WithEvents btnP300SetToolName As System.Windows.Forms.Button
    Friend WithEvents cboWorkpieceCounterSet As System.Windows.Forms.ComboBox
    Friend WithEvents txtWPCounterSetValue As System.Windows.Forms.TextBox
    Friend WithEvents txtWPCounterSet As System.Windows.Forms.TextBox
    Friend WithEvents Label325 As System.Windows.Forms.Label
    Friend WithEvents btnWPCounterSetGet As System.Windows.Forms.Button
    Friend WithEvents btnWPCounterSetSet As System.Windows.Forms.Button
    Friend WithEvents btnWPCounterSetAdd As System.Windows.Forms.Button
    Friend WithEvents grpHourMeter As System.Windows.Forms.GroupBox
    Friend WithEvents btnHourMeterCountGet As System.Windows.Forms.Button
    Friend WithEvents btnHourMeterCountSet As System.Windows.Forms.Button
    Friend WithEvents btnHourMeterCountAdd As System.Windows.Forms.Button
    Friend WithEvents cboHourMeterCount As System.Windows.Forms.ComboBox
    Friend WithEvents txtHourMeterCount As System.Windows.Forms.TextBox
    Friend WithEvents txtHourMeterCountValue As System.Windows.Forms.TextBox
    Friend WithEvents txtHourMeterCountSet As System.Windows.Forms.TextBox
    Friend WithEvents txtHourMeterCountSetValue As System.Windows.Forms.TextBox
    Friend WithEvents cboHourMeterCountSet As System.Windows.Forms.ComboBox
    Friend WithEvents btnHourMeterCountSetGet As System.Windows.Forms.Button
    Friend WithEvents btnHourMeterCountSetSet As System.Windows.Forms.Button
    Friend WithEvents btnHourMeterCountSetAdd As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MainTabControl = New System.Windows.Forms.TabControl()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.btnP300GetAttachedToolList = New System.Windows.Forms.Button()
        Me.btnP300GetAllToolList = New System.Windows.Forms.Button()
        Me.txtP300ToolsUpdate2 = New System.Windows.Forms.TextBox()
        Me.btnP300GetRegisteredToolList = New System.Windows.Forms.Button()
        Me.GroupBox39 = New System.Windows.Forms.GroupBox()
        Me.txtP300ToolNameValue = New System.Windows.Forms.TextBox()
        Me.btnP300GetToolName = New System.Windows.Forms.Button()
        Me.txtP300ToolName = New System.Windows.Forms.TextBox()
        Me.btnP300SetToolName = New System.Windows.Forms.Button()
        Me.GroupBox34 = New System.Windows.Forms.GroupBox()
        Me.btnP300GetToolType = New System.Windows.Forms.Button()
        Me.txtP300ToolType = New System.Windows.Forms.TextBox()
        Me.btnP300ToolUpdate = New System.Windows.Forms.Button()
        Me.txtP300ToolsUpdate = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cboP300ToolCompensation = New System.Windows.Forms.ComboBox()
        Me.GroupBox29 = New System.Windows.Forms.GroupBox()
        Me.GroupBox37 = New System.Windows.Forms.GroupBox()
        Me.txtP300ToolMaxSpeedValue = New System.Windows.Forms.TextBox()
        Me.btnP300GetToolMaxSpeed = New System.Windows.Forms.Button()
        Me.txtP300ToolMaxSpeed = New System.Windows.Forms.TextBox()
        Me.btnP300SetToolMaxSpeed = New System.Windows.Forms.Button()
        Me.GroupBox30 = New System.Windows.Forms.GroupBox()
        Me.txtP300ToolGroupNoValue = New System.Windows.Forms.TextBox()
        Me.btnP300GetToolGroupNo = New System.Windows.Forms.Button()
        Me.txtP300ToolGroupNo = New System.Windows.Forms.TextBox()
        Me.btnP300SetToolGroupNo = New System.Windows.Forms.Button()
        Me.GroupBox27 = New System.Windows.Forms.GroupBox()
        Me.btnP300AddToolOffset = New System.Windows.Forms.Button()
        Me.txtP300ToolOffsetSetValue = New System.Windows.Forms.TextBox()
        Me.btnP300GetToolOffset = New System.Windows.Forms.Button()
        Me.txtP300ToolOffset = New System.Windows.Forms.TextBox()
        Me.btnP300CalToolOffset = New System.Windows.Forms.Button()
        Me.btnP300SetToolOffset = New System.Windows.Forms.Button()
        Me.GroupBox28 = New System.Windows.Forms.GroupBox()
        Me.btnP300AddNoseRCompWear = New System.Windows.Forms.Button()
        Me.txtP300NoseRCompWearSetValue = New System.Windows.Forms.TextBox()
        Me.btnP300GetNoseRCompWear = New System.Windows.Forms.Button()
        Me.txtP300NoseRCompWear = New System.Windows.Forms.TextBox()
        Me.btnP300CalNoseRCompWear = New System.Windows.Forms.Button()
        Me.btnP300SetNoseRCompWear = New System.Windows.Forms.Button()
        Me.GroupBox31 = New System.Windows.Forms.GroupBox()
        Me.btnP300AddToolWear = New System.Windows.Forms.Button()
        Me.txtP300ToolWearSetValue = New System.Windows.Forms.TextBox()
        Me.btnP300GetToolWear = New System.Windows.Forms.Button()
        Me.txtP300ToolWear = New System.Windows.Forms.TextBox()
        Me.btnP300SetToolWear = New System.Windows.Forms.Button()
        Me.GroupBox32 = New System.Windows.Forms.GroupBox()
        Me.btnP300AddNoseRComp = New System.Windows.Forms.Button()
        Me.txtP300NoseRCompSetValue = New System.Windows.Forms.TextBox()
        Me.btnP300GetNoseRComp = New System.Windows.Forms.Button()
        Me.txtP300NoseRComp = New System.Windows.Forms.TextBox()
        Me.btnP300SetNoseRComp = New System.Windows.Forms.Button()
        Me.GroupBox35 = New System.Windows.Forms.GroupBox()
        Me.txtP300ToolLifeSetValue = New System.Windows.Forms.TextBox()
        Me.btnP300GetToolLifeSet = New System.Windows.Forms.Button()
        Me.txtP300ToolLifeSet = New System.Windows.Forms.TextBox()
        Me.btnP300SetToolLifeSet = New System.Windows.Forms.Button()
        Me.GroupBox36 = New System.Windows.Forms.GroupBox()
        Me.txtP300ToolLifeLeftValue = New System.Windows.Forms.TextBox()
        Me.btnP300GetToolLifeLeft = New System.Windows.Forms.Button()
        Me.txtP300ToolLifeLeft = New System.Windows.Forms.TextBox()
        Me.btnP300SetToolLifeLeft = New System.Windows.Forms.Button()
        Me.txtP300ToolGaugeStatusValue = New System.Windows.Forms.GroupBox()
        Me.cboP300ToolLifeStatus = New System.Windows.Forms.ComboBox()
        Me.btnP300GetToolLifeStatus = New System.Windows.Forms.Button()
        Me.txtP300ToolLifeStatus = New System.Windows.Forms.TextBox()
        Me.btnP300SetToolLifeStatus = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtP300GroupNumber = New System.Windows.Forms.TextBox()
        Me.btnP300ToolSetDataUnit = New System.Windows.Forms.Button()
        Me.Label342 = New System.Windows.Forms.Label()
        Me.cboP300ToolsDataUnit = New System.Windows.Forms.ComboBox()
        Me.Label340 = New System.Windows.Forms.Label()
        Me.txtP300ToolNumber = New System.Windows.Forms.TextBox()
        Me.tab_atc = New System.Windows.Forms.TabPage()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.btnGetPalletID = New System.Windows.Forms.Button()
        Me.txtPalletID = New System.Windows.Forms.TextBox()
        Me.cmdSetReturnPot = New System.Windows.Forms.Button()
        Me.cmdSetNextTool = New System.Windows.Forms.Button()
        Me.atcComboToolAttribute = New System.Windows.Forms.ComboBox()
        Me.Label138 = New System.Windows.Forms.Label()
        Me.atcButtonCancelTool = New System.Windows.Forms.Button()
        Me.atcCMDToolNumber = New System.Windows.Forms.TextBox()
        Me.Label136 = New System.Windows.Forms.Label()
        Me.atcCMDPotNumber = New System.Windows.Forms.TextBox()
        Me.Label135 = New System.Windows.Forms.Label()
        Me.cmdSetActualTool = New System.Windows.Forms.Button()
        Me.atcButtonUnRegister = New System.Windows.Forms.Button()
        Me.atcButtonRegisterAttribute = New System.Windows.Forms.Button()
        Me.atcButtonRegister = New System.Windows.Forms.Button()
        Me.atcSetLargeToolMemo = New System.Windows.Forms.Button()
        Me.atcSetHeavyToolMemo = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.largeToolMemo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.heavyToolMemo = New System.Windows.Forms.TextBox()
        Me.atcUpdateButton = New System.Windows.Forms.Button()
        Me.atcStatus = New System.Windows.Forms.TextBox()
        Me.atcPotNumberButton = New System.Windows.Forms.Button()
        Me.pot_number_lbl = New System.Windows.Forms.Label()
        Me.potNumber = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.potToolKind = New System.Windows.Forms.TextBox()
        Me.potToolNumber = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.getMemoButton = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.magazineNumber = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.atcMagazinePosition = New System.Windows.Forms.TextBox()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.endingPot = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.startingPot = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.getMagazineButton = New System.Windows.Forms.Button()
        Me.numberOfPots = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.tab_P300ATC = New System.Windows.Forms.TabPage()
        Me.GroupBox44 = New System.Windows.Forms.GroupBox()
        Me.chkP300TLDataOverwrite = New System.Windows.Forms.CheckBox()
        Me.btnP300TLDataOutput = New System.Windows.Forms.Button()
        Me.btnP300TLDataInput = New System.Windows.Forms.Button()
        Me.Label393 = New System.Windows.Forms.Label()
        Me.txtLoadSaveToolNumber = New System.Windows.Forms.TextBox()
        Me.Label399 = New System.Windows.Forms.Label()
        Me.txtLoadSaveFolderPath = New System.Windows.Forms.TextBox()
        Me.GroupBox33 = New System.Windows.Forms.GroupBox()
        Me.btnAttachTool = New System.Windows.Forms.Button()
        Me.btnP300AttachActualTool = New System.Windows.Forms.Button()
        Me.txtP300MaxToolSpeed = New System.Windows.Forms.TextBox()
        Me.Label313 = New System.Windows.Forms.Label()
        Me.chkP300ManualAttachmentToolATCType = New System.Windows.Forms.CheckBox()
        Me.chkP300ThroughCoolantToolType = New System.Windows.Forms.CheckBox()
        Me.cboP300WeightKind = New System.Windows.Forms.ComboBox()
        Me.Label312 = New System.Windows.Forms.Label()
        Me.cboP300HeightKind = New System.Windows.Forms.ComboBox()
        Me.Label311 = New System.Windows.Forms.Label()
        Me.cboP300DiameterKind = New System.Windows.Forms.ComboBox()
        Me.Label310 = New System.Windows.Forms.Label()
        Me.btnP300DeleteTool = New System.Windows.Forms.Button()
        Me.btnAttachNextTool = New System.Windows.Forms.Button()
        Me.cboP300ToolKind2 = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtP300ATCToolNo = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtP300ATCPotNo = New System.Windows.Forms.TextBox()
        Me.Label137 = New System.Windows.Forms.Label()
        Me.btnP300UnregisterTool = New System.Windows.Forms.Button()
        Me.btbP300RegisterTool = New System.Windows.Forms.Button()
        Me.tab_ATCSubPanel = New System.Windows.Forms.TabPage()
        Me.GroupBox43 = New System.Windows.Forms.GroupBox()
        Me.btnATCSubGetErrorCode = New System.Windows.Forms.Button()
        Me.btnATCGetPotNo = New System.Windows.Forms.Button()
        Me.btnATCSubGetToolNo = New System.Windows.Forms.Button()
        Me.Label330 = New System.Windows.Forms.Label()
        Me.txtATCSubErrorCode = New System.Windows.Forms.TextBox()
        Me.txtATCSubToolNo = New System.Windows.Forms.TextBox()
        Me.btnATCSubClearError = New System.Windows.Forms.Button()
        Me.Label332 = New System.Windows.Forms.Label()
        Me.txtATCSubPotNo = New System.Windows.Forms.TextBox()
        Me.Label336 = New System.Windows.Forms.Label()
        Me.GroupBox42 = New System.Windows.Forms.GroupBox()
        Me.txtATCSubOperationMode = New System.Windows.Forms.TextBox()
        Me.btnATCSubGetOperationMode = New System.Windows.Forms.Button()
        Me.cboATCSubPanelOperationModes = New System.Windows.Forms.ComboBox()
        Me.btnATCSubSetOperationMode = New System.Windows.Forms.Button()
        Me.GroupBox41 = New System.Windows.Forms.GroupBox()
        Me.Label331 = New System.Windows.Forms.Label()
        Me.txtATCPanelIndexPotNo = New System.Windows.Forms.TextBox()
        Me.btnATCPanelSetIndexToolNo = New System.Windows.Forms.Button()
        Me.Label329 = New System.Windows.Forms.Label()
        Me.txtATCSubGroupNo = New System.Windows.Forms.TextBox()
        Me.txtATCSubSerialNo = New System.Windows.Forms.TextBox()
        Me.btnATCSubSearchPotByToolName = New System.Windows.Forms.Button()
        Me.Label333 = New System.Windows.Forms.Label()
        Me.txtATCSubToolName = New System.Windows.Forms.TextBox()
        Me.Label334 = New System.Windows.Forms.Label()
        Me.txtATCSubReturnPotNo = New System.Windows.Forms.TextBox()
        Me.Label335 = New System.Windows.Forms.Label()
        Me.btnATCSubSearchPotByGroupSerial = New System.Windows.Forms.Button()
        Me.tab_machine = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboAllLoggingLevel = New System.Windows.Forms.ComboBox()
        Me.grpHourMeter = New System.Windows.Forms.GroupBox()
        Me.btnHourMeterCountSetAdd = New System.Windows.Forms.Button()
        Me.btnHourMeterCountSetSet = New System.Windows.Forms.Button()
        Me.btnHourMeterCountSetGet = New System.Windows.Forms.Button()
        Me.cboHourMeterCountSet = New System.Windows.Forms.ComboBox()
        Me.txtHourMeterCountSetValue = New System.Windows.Forms.TextBox()
        Me.txtHourMeterCountSet = New System.Windows.Forms.TextBox()
        Me.txtHourMeterCountValue = New System.Windows.Forms.TextBox()
        Me.txtHourMeterCount = New System.Windows.Forms.TextBox()
        Me.cboHourMeterCount = New System.Windows.Forms.ComboBox()
        Me.btnHourMeterCountAdd = New System.Windows.Forms.Button()
        Me.btnHourMeterCountSet = New System.Windows.Forms.Button()
        Me.btnHourMeterCountGet = New System.Windows.Forms.Button()
        Me.txtMachine = New System.Windows.Forms.TextBox()
        Me.txtUserAlarmMessage = New System.Windows.Forms.TextBox()
        Me.cboUserAlarm = New System.Windows.Forms.ComboBox()
        Me.btnSetUserAlarm = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.cmdMachineDataUnit = New System.Windows.Forms.Button()
        Me.cboMachineDataUnit = New System.Windows.Forms.ComboBox()
        Me.txtInputMachineZeroOffset = New System.Windows.Forms.TextBox()
        Me.Label142 = New System.Windows.Forms.Label()
        Me.cboMachineZeroOffsetAxis = New System.Windows.Forms.ComboBox()
        Me.txtOutputMachineZeroOffset = New System.Windows.Forms.TextBox()
        Me.cmdCalMachineZeroOffset = New System.Windows.Forms.Button()
        Me.cmdAddMachineZeroOffset = New System.Windows.Forms.Button()
        Me.cmdSetMachineZeroOffset = New System.Windows.Forms.Button()
        Me.cmdGetMachineZeroOffset = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.txtInputMDI = New System.Windows.Forms.TextBox()
        Me.cmd_InputMDI = New System.Windows.Forms.Button()
        Me.machineUpdateButton = New System.Windows.Forms.Button()
        Me.machinePowerOnTimeAdd = New System.Windows.Forms.Button()
        Me.machinePowerOnTimeSet = New System.Windows.Forms.Button()
        Me.machinePowerOnTimeUpdate = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.btnClearUserAlarmD = New System.Windows.Forms.Button()
        Me.tab_workpiece = New System.Windows.Forms.TabPage()
        Me.wkSetDataUnitButton = New System.Windows.Forms.Button()
        Me.wkDataUnitCombo = New System.Windows.Forms.ComboBox()
        Me.Label152 = New System.Windows.Forms.Label()
        Me.Label129 = New System.Windows.Forms.Label()
        Me.wkZeroTo = New System.Windows.Forms.TextBox()
        Me.Label127 = New System.Windows.Forms.Label()
        Me.wkZeroFrom = New System.Windows.Forms.TextBox()
        Me.Label128 = New System.Windows.Forms.Label()
        Me.wkZeroResults = New System.Windows.Forms.TextBox()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.wkUpdateValsWithNoParams = New System.Windows.Forms.Button()
        Me.wkValsWithoutParameters = New System.Windows.Forms.TextBox()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.wkUpdateZeroOffset = New System.Windows.Forms.TextBox()
        Me.wkZeroOffset = New System.Windows.Forms.TextBox()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.wkAxisCombo = New System.Windows.Forms.ComboBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.wkButtonZeroOffsetGet = New System.Windows.Forms.Button()
        Me.wkButtonZeroOffsetCal = New System.Windows.Forms.Button()
        Me.wkButtonZeroOffsetAdd = New System.Windows.Forms.Button()
        Me.wkButtonZeroOffsetSet = New System.Windows.Forms.Button()
        Me.wkOffsetNumber = New System.Windows.Forms.TextBox()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.btnWPCounterSetAdd = New System.Windows.Forms.Button()
        Me.btnWPCounterSetSet = New System.Windows.Forms.Button()
        Me.btnWPCounterSetGet = New System.Windows.Forms.Button()
        Me.Label325 = New System.Windows.Forms.Label()
        Me.txtWPCounterSet = New System.Windows.Forms.TextBox()
        Me.txtWPCounterSetValue = New System.Windows.Forms.TextBox()
        Me.cboWorkpieceCounterSet = New System.Windows.Forms.ComboBox()
        Me.cmd_WorkpieceAdd = New System.Windows.Forms.Button()
        Me.wkCounterCombo = New System.Windows.Forms.ComboBox()
        Me.wkUpdateCounter = New System.Windows.Forms.TextBox()
        Me.wkCounterValue = New System.Windows.Forms.TextBox()
        Me.wkButtonGetCounter = New System.Windows.Forms.Button()
        Me.wkCounterSetButton = New System.Windows.Forms.Button()
        Me.tab_OptionalParameter = New System.Windows.Forms.TabPage()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.txtLongWordInput = New System.Windows.Forms.TextBox()
        Me.txtWordInput = New System.Windows.Forms.TextBox()
        Me.txtBitInput = New System.Windows.Forms.TextBox()
        Me.cmdWordAdd = New System.Windows.Forms.Button()
        Me.cmdLongWordAdd = New System.Windows.Forms.Button()
        Me.cmdBitSet = New System.Windows.Forms.Button()
        Me.cmdWordSet = New System.Windows.Forms.Button()
        Me.cmdLongWordSet = New System.Windows.Forms.Button()
        Me.cmdOptionalParameterBitGet = New System.Windows.Forms.Button()
        Me.cmdOptionalParameterWordGet = New System.Windows.Forms.Button()
        Me.cmdOptionalParameterLongWordGet = New System.Windows.Forms.Button()
        Me.txtOptionalParameterLongWord = New System.Windows.Forms.TextBox()
        Me.txtOptionalParameterWord = New System.Windows.Forms.TextBox()
        Me.txtOptionalParameterBit = New System.Windows.Forms.TextBox()
        Me.Label299 = New System.Windows.Forms.Label()
        Me.txtOptionalParameterBitNo = New System.Windows.Forms.TextBox()
        Me.Label300 = New System.Windows.Forms.Label()
        Me.txtOptionalParameterLongWordIndex = New System.Windows.Forms.TextBox()
        Me.Label301 = New System.Windows.Forms.Label()
        Me.txtOptionalParameterWordIndex = New System.Windows.Forms.TextBox()
        Me.Label302 = New System.Windows.Forms.Label()
        Me.txtOptionalParameterBitIndex = New System.Windows.Forms.TextBox()
        Me.Label303 = New System.Windows.Forms.Label()
        Me.tab_spec = New System.Windows.Forms.TabPage()
        Me.txtControlType = New System.Windows.Forms.TextBox()
        Me.Label314 = New System.Windows.Forms.Label()
        Me.GroupBox26 = New System.Windows.Forms.GroupBox()
        Me.btnGetPLC3SpecCode = New System.Windows.Forms.Button()
        Me.btnGetPLC2SpecCode = New System.Windows.Forms.Button()
        Me.txtPLCSpecCode = New System.Windows.Forms.TextBox()
        Me.Label308 = New System.Windows.Forms.Label()
        Me.txtPLCSpecCodeBit = New System.Windows.Forms.TextBox()
        Me.Label309 = New System.Windows.Forms.Label()
        Me.txtPLCSpecCodeIndex = New System.Windows.Forms.TextBox()
        Me.btnGetPLCSpecCode = New System.Windows.Forms.Button()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.cmdGetBSpecCode = New System.Windows.Forms.Button()
        Me.txtSpecCode = New System.Windows.Forms.TextBox()
        Me.Label170 = New System.Windows.Forms.Label()
        Me.txtSpecCodeBit = New System.Windows.Forms.TextBox()
        Me.Label169 = New System.Windows.Forms.Label()
        Me.txtSpecCodeIndex = New System.Windows.Forms.TextBox()
        Me.cmdGetSpecCode = New System.Windows.Forms.Button()
        Me.txtMachineSerial = New System.Windows.Forms.TextBox()
        Me.txtMachineName = New System.Windows.Forms.TextBox()
        Me.Label144 = New System.Windows.Forms.Label()
        Me.Label143 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.specCombo = New System.Windows.Forms.ComboBox()
        Me.specUpdateButton = New System.Windows.Forms.Button()
        Me.specCode = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Tools2_2 = New System.Windows.Forms.TabPage()
        Me.GroupBox21 = New System.Windows.Forms.GroupBox()
        Me.txtTools2_ToolInPot = New System.Windows.Forms.TextBox()
        Me.Label252 = New System.Windows.Forms.Label()
        Me.Label249 = New System.Windows.Forms.Label()
        Me.cboToolID_ToolKind = New System.Windows.Forms.ComboBox()
        Me.cmdToolID_ToolKind_Set = New System.Windows.Forms.Button()
        Me.Label235 = New System.Windows.Forms.Label()
        Me.txtToolID_ToolKind = New System.Windows.Forms.TextBox()
        Me.cmdToolID_AdjustmentTool_Set = New System.Windows.Forms.Button()
        Me.txtToolID_AdjustmentTool = New System.Windows.Forms.TextBox()
        Me.Label248 = New System.Windows.Forms.Label()
        Me.Label250 = New System.Windows.Forms.Label()
        Me.txtToolID_PotInUse = New System.Windows.Forms.TextBox()
        Me.cmdToolID_PotInUse_Set = New System.Windows.Forms.Button()
        Me.cboYesNo_PotInUse = New System.Windows.Forms.ComboBox()
        Me.cboYesNo_AdjustmentTool = New System.Windows.Forms.ComboBox()
        Me.cboYesNo_StandardTool = New System.Windows.Forms.ComboBox()
        Me.cmdToolID_StandardTool_Set = New System.Windows.Forms.Button()
        Me.txtToolID_StandardTool = New System.Windows.Forms.TextBox()
        Me.lstToolID_Update = New System.Windows.Forms.ListBox()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.txtToolID_RATC_PotNo = New System.Windows.Forms.TextBox()
        Me.txtToolID_RATC_PotNoValue = New System.Windows.Forms.TextBox()
        Me.Label251 = New System.Windows.Forms.Label()
        Me.chkToolID_DummyTool = New System.Windows.Forms.CheckBox()
        Me.txtToolID_ToolNameValue = New System.Windows.Forms.TextBox()
        Me.txtToolID_SerialNo = New System.Windows.Forms.TextBox()
        Me.txtToolID_ToolName = New System.Windows.Forms.TextBox()
        Me.Label244 = New System.Windows.Forms.Label()
        Me.txtToolID_GroupNoValue = New System.Windows.Forms.TextBox()
        Me.txtToolID_GroupNo = New System.Windows.Forms.TextBox()
        Me.Label186 = New System.Windows.Forms.Label()
        Me.Label241 = New System.Windows.Forms.Label()
        Me.txtToolID_SerialNoValue = New System.Windows.Forms.TextBox()
        Me.cmdToolID_UnRegisterToolPot = New System.Windows.Forms.Button()
        Me.cmdToolID_RegisterToolPot = New System.Windows.Forms.Button()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.cmdToolID_ToolAngle_Add = New System.Windows.Forms.Button()
        Me.cmdToolID_ToolNoseDiameter_Add = New System.Windows.Forms.Button()
        Me.cmdToolID_ToolDiameter_Add = New System.Windows.Forms.Button()
        Me.cboToolID_ToolType = New System.Windows.Forms.ComboBox()
        Me.Label246 = New System.Windows.Forms.Label()
        Me.Label247 = New System.Windows.Forms.Label()
        Me.txtToolID_ToolType = New System.Windows.Forms.TextBox()
        Me.cmdToolID_ToolType_Set = New System.Windows.Forms.Button()
        Me.cmdToolID_ToolAngle_Set = New System.Windows.Forms.Button()
        Me.txtToolID_ToolAngleValue = New System.Windows.Forms.TextBox()
        Me.Label242 = New System.Windows.Forms.Label()
        Me.txtToolID_ToolAngle = New System.Windows.Forms.TextBox()
        Me.cmdToolID_ToolNoseDiameter_Set = New System.Windows.Forms.Button()
        Me.cmdToolID_ToolDiameter_Set = New System.Windows.Forms.Button()
        Me.txtToolID_ToolDiameterValue = New System.Windows.Forms.TextBox()
        Me.txtToolID_ToolNoseDiameterValue = New System.Windows.Forms.TextBox()
        Me.Label243 = New System.Windows.Forms.Label()
        Me.txtToolID_ToolNoseDiameter = New System.Windows.Forms.TextBox()
        Me.txtToolID_ToolDiameter = New System.Windows.Forms.TextBox()
        Me.cboToolID_CarrierStatus = New System.Windows.Forms.ComboBox()
        Me.cmdToolID_CarrierStatus_Set = New System.Windows.Forms.Button()
        Me.txtToolID_CarrierStatus = New System.Windows.Forms.TextBox()
        Me.Label183 = New System.Windows.Forms.Label()
        Me.Label213 = New System.Windows.Forms.Label()
        Me.cmdToolID_DataUnit_2_Set = New System.Windows.Forms.Button()
        Me.cboToolID_DataUnit_2 = New System.Windows.Forms.ComboBox()
        Me.Label230 = New System.Windows.Forms.Label()
        Me.cmdToolID_2_Update = New System.Windows.Forms.Button()
        Me.txtToolID_PotNo_2 = New System.Windows.Forms.TextBox()
        Me.Label236 = New System.Windows.Forms.Label()
        Me.tab_coolant = New System.Windows.Forms.TabPage()
        Me.coolantUpdateButton = New System.Windows.Forms.Button()
        Me.coolantChipCondition = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.tab_MacManOperatingHistory = New System.Windows.Forms.TabPage()
        Me.Label204 = New System.Windows.Forms.Label()
        Me.mopnhMaxNoofReports = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.mopnhPrevAlarmonTime = New System.Windows.Forms.TextBox()
        Me.mopnhPrevExternalInputTime = New System.Windows.Forms.TextBox()
        Me.mopnhPrevSpindleRunTime = New System.Windows.Forms.TextBox()
        Me.mopnhPrevOtherTime = New System.Windows.Forms.TextBox()
        Me.mopnhPrevMaintenanceTime = New System.Windows.Forms.TextBox()
        Me.mopnhPrevPartWaitingTime = New System.Windows.Forms.TextBox()
        Me.mopnhPrevNoOperatorTime = New System.Windows.Forms.TextBox()
        Me.mopnhPrevInProSetupTime = New System.Windows.Forms.TextBox()
        Me.mopnhPrevNonOperatingTime = New System.Windows.Forms.TextBox()
        Me.mopnhPrevCuttingTime = New System.Windows.Forms.TextBox()
        Me.mopnhPrevOperatingTime = New System.Windows.Forms.TextBox()
        Me.Label214 = New System.Windows.Forms.Label()
        Me.Label215 = New System.Windows.Forms.Label()
        Me.Label216 = New System.Windows.Forms.Label()
        Me.Label217 = New System.Windows.Forms.Label()
        Me.Label218 = New System.Windows.Forms.Label()
        Me.Label219 = New System.Windows.Forms.Label()
        Me.Label220 = New System.Windows.Forms.Label()
        Me.Label221 = New System.Windows.Forms.Label()
        Me.Label222 = New System.Windows.Forms.Label()
        Me.Label223 = New System.Windows.Forms.Label()
        Me.Label224 = New System.Windows.Forms.Label()
        Me.Label203 = New System.Windows.Forms.Label()
        Me.mopnhPrevRunningTime = New System.Windows.Forms.TextBox()
        Me.objMopnhUpdateButton = New System.Windows.Forms.Button()
        Me.Label202 = New System.Windows.Forms.Label()
        Me.Label201 = New System.Windows.Forms.Label()
        Me.mopnhTo = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.mopnhAlarmOnTime = New System.Windows.Forms.TextBox()
        Me.mopnhExternalInputTime = New System.Windows.Forms.TextBox()
        Me.mopnhSpindleRunTime = New System.Windows.Forms.TextBox()
        Me.mopnhOtherTime = New System.Windows.Forms.TextBox()
        Me.mopnhMaintenanceTime = New System.Windows.Forms.TextBox()
        Me.mopnhPartWaitingTime = New System.Windows.Forms.TextBox()
        Me.mopnhNoOperatorTime = New System.Windows.Forms.TextBox()
        Me.mopnhInProSetupTime = New System.Windows.Forms.TextBox()
        Me.mopnhNonOperatingReport = New System.Windows.Forms.TextBox()
        Me.mopnhCuttingTime = New System.Windows.Forms.TextBox()
        Me.mopnhOperatingTime = New System.Windows.Forms.TextBox()
        Me.mopnhRunningTime = New System.Windows.Forms.TextBox()
        Me.Label200 = New System.Windows.Forms.Label()
        Me.Label199 = New System.Windows.Forms.Label()
        Me.Label198 = New System.Windows.Forms.Label()
        Me.Label197 = New System.Windows.Forms.Label()
        Me.Label196 = New System.Windows.Forms.Label()
        Me.Label195 = New System.Windows.Forms.Label()
        Me.Label194 = New System.Windows.Forms.Label()
        Me.Label193 = New System.Windows.Forms.Label()
        Me.Label192 = New System.Windows.Forms.Label()
        Me.Label191 = New System.Windows.Forms.Label()
        Me.Label190 = New System.Windows.Forms.Label()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.mopnhFrom = New System.Windows.Forms.TextBox()
        Me.tab_MacManMachiningReport = New System.Windows.Forms.TabPage()
        Me.grdMMMachiningReports = New System.Windows.Forms.DataGrid()
        Me.txtMachiningReport_NoOfWork = New System.Windows.Forms.TextBox()
        Me.Label156 = New System.Windows.Forms.Label()
        Me.MacreportTime = New System.Windows.Forms.TextBox()
        Me.Label245 = New System.Windows.Forms.Label()
        Me.txtto = New System.Windows.Forms.TextBox()
        Me.Label158 = New System.Windows.Forms.Label()
        Me.txtFrom = New System.Windows.Forms.TextBox()
        Me.Label159 = New System.Windows.Forms.Label()
        Me.macreport_result = New System.Windows.Forms.Button()
        Me.Label160 = New System.Windows.Forms.Label()
        Me.Cmb_rptPeriod = New System.Windows.Forms.ComboBox()
        Me.MacReport_programname = New System.Windows.Forms.TextBox()
        Me.Label161 = New System.Windows.Forms.Label()
        Me.Macreport_filename = New System.Windows.Forms.TextBox()
        Me.Label162 = New System.Windows.Forms.Label()
        Me.MacReport_count = New System.Windows.Forms.TextBox()
        Me.Label163 = New System.Windows.Forms.Label()
        Me.macReportUpdateButton = New System.Windows.Forms.Button()
        Me.MacReport_Index = New System.Windows.Forms.TextBox()
        Me.Label164 = New System.Windows.Forms.Label()
        Me.macreport_Operatingtime = New System.Windows.Forms.TextBox()
        Me.Label225 = New System.Windows.Forms.Label()
        Me.macreport_Runningtime = New System.Windows.Forms.TextBox()
        Me.Label226 = New System.Windows.Forms.Label()
        Me.Macreportdate = New System.Windows.Forms.TextBox()
        Me.Label227 = New System.Windows.Forms.Label()
        Me.macreport_maxcount = New System.Windows.Forms.TextBox()
        Me.Label228 = New System.Windows.Forms.Label()
        Me.macreport_cuttingtime = New System.Windows.Forms.TextBox()
        Me.Label229 = New System.Windows.Forms.Label()
        Me.tab_MacmanOperatingReport = New System.Windows.Forms.TabPage()
        Me.morMaxNoOfOpReport = New System.Windows.Forms.TextBox()
        Me.Label288 = New System.Windows.Forms.Label()
        Me.morUpdateButton = New System.Windows.Forms.Button()
        Me.morOperatingStatus = New System.Windows.Forms.TextBox()
        Me.Label289 = New System.Windows.Forms.Label()
        Me.morNonoperatingCondition = New System.Windows.Forms.TextBox()
        Me.Label290 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.morPrevExternalInputTime = New System.Windows.Forms.TextBox()
        Me.morPrevDateOfOperatingRept = New System.Windows.Forms.TextBox()
        Me.morPrevAlarmOnTime = New System.Windows.Forms.TextBox()
        Me.morPrevSpindleRunTime = New System.Windows.Forms.TextBox()
        Me.morPrevOtherTime = New System.Windows.Forms.TextBox()
        Me.morPrevMaintenanceTime = New System.Windows.Forms.TextBox()
        Me.morPrevPartwaitingTime = New System.Windows.Forms.TextBox()
        Me.morPrevNoOperatorTime = New System.Windows.Forms.TextBox()
        Me.morPrevInProSetupTime = New System.Windows.Forms.TextBox()
        Me.morPrevNonOperatingTime = New System.Windows.Forms.TextBox()
        Me.morPrevCuttingTime = New System.Windows.Forms.TextBox()
        Me.morPrevRunningTime = New System.Windows.Forms.TextBox()
        Me.Label276 = New System.Windows.Forms.Label()
        Me.Label277 = New System.Windows.Forms.Label()
        Me.Label278 = New System.Windows.Forms.Label()
        Me.Label279 = New System.Windows.Forms.Label()
        Me.Label280 = New System.Windows.Forms.Label()
        Me.Label281 = New System.Windows.Forms.Label()
        Me.Label282 = New System.Windows.Forms.Label()
        Me.Label283 = New System.Windows.Forms.Label()
        Me.Label284 = New System.Windows.Forms.Label()
        Me.Label285 = New System.Windows.Forms.Label()
        Me.Label286 = New System.Windows.Forms.Label()
        Me.Label287 = New System.Windows.Forms.Label()
        Me.morPrevOperatingTime = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label240 = New System.Windows.Forms.Label()
        Me.morOperatingTime = New System.Windows.Forms.TextBox()
        Me.Label264 = New System.Windows.Forms.Label()
        Me.Label265 = New System.Windows.Forms.Label()
        Me.Label266 = New System.Windows.Forms.Label()
        Me.Label267 = New System.Windows.Forms.Label()
        Me.Label268 = New System.Windows.Forms.Label()
        Me.Label269 = New System.Windows.Forms.Label()
        Me.morRunningTime = New System.Windows.Forms.TextBox()
        Me.morCuttingTime = New System.Windows.Forms.TextBox()
        Me.morNonOPeratingTime = New System.Windows.Forms.TextBox()
        Me.morInProSetupTime = New System.Windows.Forms.TextBox()
        Me.morNoOperatorTime = New System.Windows.Forms.TextBox()
        Me.morPartWaitingTime = New System.Windows.Forms.TextBox()
        Me.Label270 = New System.Windows.Forms.Label()
        Me.mormaintenanceTime = New System.Windows.Forms.TextBox()
        Me.Label271 = New System.Windows.Forms.Label()
        Me.morOtherTime = New System.Windows.Forms.TextBox()
        Me.Label272 = New System.Windows.Forms.Label()
        Me.morSpindleRunTime = New System.Windows.Forms.TextBox()
        Me.Label273 = New System.Windows.Forms.Label()
        Me.morExternalInputTime = New System.Windows.Forms.TextBox()
        Me.morAlarmOnTime = New System.Windows.Forms.TextBox()
        Me.Label274 = New System.Windows.Forms.Label()
        Me.morDateOfOperatingReport = New System.Windows.Forms.TextBox()
        Me.Label275 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.morPeriodDateOfOperatingReport = New System.Windows.Forms.TextBox()
        Me.morPeriodAlarmOnTime = New System.Windows.Forms.TextBox()
        Me.morPeriodExternalInputTime = New System.Windows.Forms.TextBox()
        Me.morPeriodSpindleRunTime = New System.Windows.Forms.TextBox()
        Me.morPeriodOtherTime = New System.Windows.Forms.TextBox()
        Me.morPeriodMaintenanceTime = New System.Windows.Forms.TextBox()
        Me.morPeriodNoOperatorTime = New System.Windows.Forms.TextBox()
        Me.morPeriodPartWaitingTime = New System.Windows.Forms.TextBox()
        Me.morPeriodInproSetupTime = New System.Windows.Forms.TextBox()
        Me.morPeriodNonOperatingTime = New System.Windows.Forms.TextBox()
        Me.morPeriodCuttingTime = New System.Windows.Forms.TextBox()
        Me.morPeriodRunningTime = New System.Windows.Forms.TextBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.Label130 = New System.Windows.Forms.Label()
        Me.Label141 = New System.Windows.Forms.Label()
        Me.Label153 = New System.Windows.Forms.Label()
        Me.Label154 = New System.Windows.Forms.Label()
        Me.Label155 = New System.Windows.Forms.Label()
        Me.Label237 = New System.Windows.Forms.Label()
        Me.Label238 = New System.Windows.Forms.Label()
        Me.morPeriodOperatingTime = New System.Windows.Forms.TextBox()
        Me.Label239 = New System.Windows.Forms.Label()
        Me.tab_MacManAlarmHistory = New System.Windows.Forms.TabPage()
        Me.grdMMAlarmHistory = New System.Windows.Forms.DataGrid()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.txtAlarmObject = New System.Windows.Forms.TextBox()
        Me.Label145 = New System.Windows.Forms.Label()
        Me.mahAlarmMessage = New System.Windows.Forms.TextBox()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.mahAlarmDate = New System.Windows.Forms.TextBox()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.mahAlarmCode = New System.Windows.Forms.TextBox()
        Me.mahAlarmTime = New System.Windows.Forms.TextBox()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.mahAlarmNumber = New System.Windows.Forms.TextBox()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.mahUpdateButton = New System.Windows.Forms.Button()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.mahMaxAlarmCount = New System.Windows.Forms.TextBox()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.mahAlarmCount = New System.Windows.Forms.TextBox()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.mahAlarmIndex = New System.Windows.Forms.TextBox()
        Me.mahTo = New System.Windows.Forms.TextBox()
        Me.Label133 = New System.Windows.Forms.Label()
        Me.mahFrom = New System.Windows.Forms.TextBox()
        Me.Label134 = New System.Windows.Forms.Label()
        Me.mahButtonResults = New System.Windows.Forms.Button()
        Me.tab_MacmanOperationHistory = New System.Windows.Forms.TabPage()
        Me.mohTo = New System.Windows.Forms.TextBox()
        Me.Label131 = New System.Windows.Forms.Label()
        Me.mohFrom = New System.Windows.Forms.TextBox()
        Me.Label132 = New System.Windows.Forms.Label()
        Me.mohResults = New System.Windows.Forms.TextBox()
        Me.mohButtonResults = New System.Windows.Forms.Button()
        Me.mohUpdateButton = New System.Windows.Forms.Button()
        Me.mohOperationIndex = New System.Windows.Forms.TextBox()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.mohOperationTime = New System.Windows.Forms.TextBox()
        Me.Label116 = New System.Windows.Forms.Label()
        Me.mohOperationDate = New System.Windows.Forms.TextBox()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.mohOperationData = New System.Windows.Forms.TextBox()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.mohOperationMaxCount = New System.Windows.Forms.TextBox()
        Me.Label119 = New System.Windows.Forms.Label()
        Me.mohOperationCount = New System.Windows.Forms.TextBox()
        Me.Label120 = New System.Windows.Forms.Label()
        Me.tab_CurrentAlarm = New System.Windows.Forms.TabPage()
        Me.cmdCurrentAlarm_Update = New System.Windows.Forms.Button()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.txtCurrentAlarm_AlarmCharacterString = New System.Windows.Forms.TextBox()
        Me.txtCurrentAlarm_AlarmCode = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtCurrentAlarm_ObjectMessage = New System.Windows.Forms.TextBox()
        Me.txtCurrentAlarm_AlarmMessage = New System.Windows.Forms.TextBox()
        Me.txtCurrentAlarm_AlarmLevel = New System.Windows.Forms.TextBox()
        Me.txtCurrentAlarm_ObjectNumber = New System.Windows.Forms.TextBox()
        Me.txtCurrentAlarm_AlarmNumber = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.tab_Tools2_1 = New System.Windows.Forms.TabPage()
        Me.cmdToolID_Update_1 = New System.Windows.Forms.Button()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.lstToolID_Offset = New System.Windows.Forms.ListBox()
        Me.Label212 = New System.Windows.Forms.Label()
        Me.txtToolID_OffsetIndex123 = New System.Windows.Forms.TextBox()
        Me.cmdToolID_LengthOffset3_Cal = New System.Windows.Forms.Button()
        Me.cmdToolID_LengthOffset2_Cal = New System.Windows.Forms.Button()
        Me.txtToolID_LengthOffset3 = New System.Windows.Forms.TextBox()
        Me.Label211 = New System.Windows.Forms.Label()
        Me.cmdToolID_LengthOffset3_Add = New System.Windows.Forms.Button()
        Me.txtToolID_LengthOffset3Value = New System.Windows.Forms.TextBox()
        Me.cmdToolID_LengthOffset3_Set = New System.Windows.Forms.Button()
        Me.txtToolID_LengthOffset2 = New System.Windows.Forms.TextBox()
        Me.Label210 = New System.Windows.Forms.Label()
        Me.cmdToolID_LengthOffset2_Add = New System.Windows.Forms.Button()
        Me.txtToolID_LengthOffset2Value = New System.Windows.Forms.TextBox()
        Me.cmdToolID_LengthOffset2_Set = New System.Windows.Forms.Button()
        Me.cmdToolID_CutterRCompOffset3_Add = New System.Windows.Forms.Button()
        Me.cmdToolID_CutterRCompOffset3_Set = New System.Windows.Forms.Button()
        Me.txtToolID_CutterRCompOffset3Value = New System.Windows.Forms.TextBox()
        Me.Label209 = New System.Windows.Forms.Label()
        Me.txtToolID_CutterRCompOffset3 = New System.Windows.Forms.TextBox()
        Me.cmdToolID_CutterRCompOffset2_Add = New System.Windows.Forms.Button()
        Me.cmdToolID_CutterRCompOffset2_Set = New System.Windows.Forms.Button()
        Me.txtToolID_CutterRCompOffset2Value = New System.Windows.Forms.TextBox()
        Me.Label208 = New System.Windows.Forms.Label()
        Me.txtToolID_CutterRCompOffset2 = New System.Windows.Forms.TextBox()
        Me.cmdToolID_CutterRCompOffset1_Add = New System.Windows.Forms.Button()
        Me.cmdToolID_CutterRCompWearOffset_Add = New System.Windows.Forms.Button()
        Me.txtToolID_LengthOffset1 = New System.Windows.Forms.TextBox()
        Me.Label182 = New System.Windows.Forms.Label()
        Me.txtToolID_CutterRCompWearOffsetValue = New System.Windows.Forms.TextBox()
        Me.cmdToolID_CutterRCompWearOffset_Set = New System.Windows.Forms.Button()
        Me.cmdToolID_CutterRCompOffset1_Set = New System.Windows.Forms.Button()
        Me.cmdToolID_LengthOffset1_Add = New System.Windows.Forms.Button()
        Me.txtToolID_CutterRCompOffset1Value = New System.Windows.Forms.TextBox()
        Me.Label188 = New System.Windows.Forms.Label()
        Me.txtToolID_CutterRCompWearOffset = New System.Windows.Forms.TextBox()
        Me.Label189 = New System.Windows.Forms.Label()
        Me.txtToolID_CutterRCompOffset1 = New System.Windows.Forms.TextBox()
        Me.cmdToolID_ToolLengthWearOffset_Add = New System.Windows.Forms.Button()
        Me.cmdToolID_ToolLengthWearOffset_Set = New System.Windows.Forms.Button()
        Me.txtToolID_ToolLengthWearOffsetValue = New System.Windows.Forms.TextBox()
        Me.txtToolID_LengthOffset1Value = New System.Windows.Forms.TextBox()
        Me.txtToolID_ToolLengthWearOffset = New System.Windows.Forms.TextBox()
        Me.Label181 = New System.Windows.Forms.Label()
        Me.cmdToolID_LengthOffset1_Cal = New System.Windows.Forms.Button()
        Me.cmdToolID_LengthOffset1_Set = New System.Windows.Forms.Button()
        Me.cmdToolID_CutterRWearOffset = New System.Windows.Forms.Button()
        Me.cmdToolID_CutterROffset = New System.Windows.Forms.Button()
        Me.cmdToolID_LengthWearOffset = New System.Windows.Forms.Button()
        Me.cmdToolID_LenghtOffset = New System.Windows.Forms.Button()
        Me.txtToolID_ToPot = New System.Windows.Forms.TextBox()
        Me.Label176 = New System.Windows.Forms.Label()
        Me.txtToolID_FromPot = New System.Windows.Forms.TextBox()
        Me.Label177 = New System.Windows.Forms.Label()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.txtToolID_ToolLifeRemainingSecond = New System.Windows.Forms.TextBox()
        Me.Label178 = New System.Windows.Forms.Label()
        Me.cmdToolID_LifeStatus_Set = New System.Windows.Forms.Button()
        Me.txtToolID_ToolLifeStatus = New System.Windows.Forms.TextBox()
        Me.Label184 = New System.Windows.Forms.Label()
        Me.cmdToolID_ToolLifeMode_Set = New System.Windows.Forms.Button()
        Me.Label187 = New System.Windows.Forms.Label()
        Me.cboToolID_ToolLifeStatus = New System.Windows.Forms.ComboBox()
        Me.cboToolID_ToolLifeMode = New System.Windows.Forms.ComboBox()
        Me.txtToolID_ToolLifeMode = New System.Windows.Forms.TextBox()
        Me.cmdToolID_ToolLifeRemaining_Set = New System.Windows.Forms.Button()
        Me.txtToolID_ToolLifeRemainingValue = New System.Windows.Forms.TextBox()
        Me.txtToolID_ToolLifeRemaining = New System.Windows.Forms.TextBox()
        Me.Label179 = New System.Windows.Forms.Label()
        Me.cmdToolID_ToolLife_Set = New System.Windows.Forms.Button()
        Me.txtToolID_ToolLifeValue = New System.Windows.Forms.TextBox()
        Me.txtToolID_ToolLife = New System.Windows.Forms.TextBox()
        Me.Label180 = New System.Windows.Forms.Label()
        Me.Label207 = New System.Windows.Forms.Label()
        Me.cmdToolID_DataUnit_Set = New System.Windows.Forms.Button()
        Me.cboToolID_DataUnit = New System.Windows.Forms.ComboBox()
        Me.txtToolID_PotNo = New System.Windows.Forms.TextBox()
        Me.Label185 = New System.Windows.Forms.Label()
        Me.tab_Renishaw_2 = New System.Windows.Forms.TabPage()
        Me.GroupBox22 = New System.Windows.Forms.GroupBox()
        Me.btnGetSlopeConverting = New System.Windows.Forms.Button()
        Me.txtSlopeConverting = New System.Windows.Forms.TextBox()
        Me.GroupBox25 = New System.Windows.Forms.GroupBox()
        Me.txtRowMatrix = New System.Windows.Forms.TextBox()
        Me.Label307 = New System.Windows.Forms.Label()
        Me.txtColumnMatrix = New System.Windows.Forms.TextBox()
        Me.txtRotateAmountISC = New System.Windows.Forms.TextBox()
        Me.btnGetRotateAmoutISC = New System.Windows.Forms.Button()
        Me.txtRotateAmountSC = New System.Windows.Forms.TextBox()
        Me.btnGetRotateAmoutSC = New System.Windows.Forms.Button()
        Me.txtShiftAmountISC = New System.Windows.Forms.TextBox()
        Me.btnGetShiftAmoutISC = New System.Windows.Forms.Button()
        Me.txtShiftAmountSC = New System.Windows.Forms.TextBox()
        Me.btnGetShiftAmoutSC = New System.Windows.Forms.Button()
        Me.Label305 = New System.Windows.Forms.Label()
        Me.cboSlopeCoordAxisIndex = New System.Windows.Forms.ComboBox()
        Me.Label306 = New System.Windows.Forms.Label()
        Me.GroupBox24 = New System.Windows.Forms.GroupBox()
        Me.btnGetRotatyAxisName = New System.Windows.Forms.Button()
        Me.txtRotaryAxisName = New System.Windows.Forms.TextBox()
        Me.cboRotaryAxes = New System.Windows.Forms.ComboBox()
        Me.Label262 = New System.Windows.Forms.Label()
        Me.btnRotaryAxisSetupStructure = New System.Windows.Forms.Button()
        Me.txtRotaryAxisSetupStructure = New System.Windows.Forms.TextBox()
        Me.btnRotaryAxisSetupPosition = New System.Windows.Forms.Button()
        Me.txtRotaryAxisSetupPosition = New System.Windows.Forms.TextBox()
        Me.btnRotaryAxisISO = New System.Windows.Forms.Button()
        Me.txtRotaryAxisISO = New System.Windows.Forms.TextBox()
        Me.GroupBox23 = New System.Windows.Forms.GroupBox()
        Me.Label304 = New System.Windows.Forms.Label()
        Me.cboRotaryAxisStructure = New System.Windows.Forms.ComboBox()
        Me.Label298 = New System.Windows.Forms.Label()
        Me.cboLinearAxisIndex = New System.Windows.Forms.ComboBox()
        Me.Label263 = New System.Windows.Forms.Label()
        Me.cboRotationCenters = New System.Windows.Forms.ComboBox()
        Me.btnGetRotationCenterSetupPosition = New System.Windows.Forms.Button()
        Me.txtRotationCenterSetupPosition = New System.Windows.Forms.TextBox()
        Me.tab_axis = New System.Windows.Forms.TabPage()
        Me.txtRapidFeedrateOverride = New System.Windows.Forms.TextBox()
        Me.Label322 = New System.Windows.Forms.Label()
        Me.txt_RelativeActualPositionProgramCoord = New System.Windows.Forms.TextBox()
        Me.Label234 = New System.Windows.Forms.Label()
        Me.Label206 = New System.Windows.Forms.Label()
        Me.axisSetDataUnit = New System.Windows.Forms.Button()
        Me.axisDataUnit = New System.Windows.Forms.ComboBox()
        Me.AxisTimerStop = New System.Windows.Forms.Button()
        Me.axisTimerStart = New System.Windows.Forms.Button()
        Me.axisUpdateButton = New System.Windows.Forms.Button()
        Me.maxFeedrateOverride = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.feedrateType = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.feedrateOverride = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.feedHold = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.axisType = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.axisName = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.targetPosition = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.distanceTarget = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.commandFeedRate = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.axisLoad = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.apProgramCoord = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.apMachineCoord = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.apEncoderCoord = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.actualFeedrate = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.feedCommandOrderCombo = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.feedTypeCombo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.axisCombo = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.tab_Program2 = New System.Windows.Forms.TabPage()
        Me.Label168 = New System.Windows.Forms.Label()
        Me.txtProgramNameInput = New System.Windows.Forms.TextBox()
        Me.Label167 = New System.Windows.Forms.Label()
        Me.txtProgramNameOutput = New System.Windows.Forms.TextBox()
        Me.Label166 = New System.Windows.Forms.Label()
        Me.txtGMCode = New System.Windows.Forms.TextBox()
        Me.cmdSetProgramNameMCodeCall = New System.Windows.Forms.Button()
        Me.cmdGetProgramNameMCodeCall = New System.Windows.Forms.Button()
        Me.cmdSetProgramNameGCodeMod = New System.Windows.Forms.Button()
        Me.cmdGetProgramNameGCodeMod = New System.Windows.Forms.Button()
        Me.tab_MopTool = New System.Windows.Forms.TabPage()
        Me.Label233 = New System.Windows.Forms.Label()
        Me.TXT_GetMaxMOPToolData = New System.Windows.Forms.TextBox()
        Me.mopButtonULValue = New System.Windows.Forms.Button()
        Me.mopSetULValue = New System.Windows.Forms.TextBox()
        Me.mopButtonToolDataInput = New System.Windows.Forms.Button()
        Me.mopSetToolDataInputMode = New System.Windows.Forms.TextBox()
        Me.mopButtonReferenceValue = New System.Windows.Forms.Button()
        Me.mopSetReferenceValue = New System.Windows.Forms.TextBox()
        Me.mopButtonOverloadMonitor = New System.Windows.Forms.Button()
        Me.mopSetOverloadMonitor = New System.Windows.Forms.TextBox()
        Me.mopButtonMinOverride = New System.Windows.Forms.Button()
        Me.mopSetMinOverride = New System.Windows.Forms.TextBox()
        Me.mopButtonMaxOverride = New System.Windows.Forms.Button()
        Me.mopSetMaxOverride = New System.Windows.Forms.TextBox()
        Me.mopButtonLLValue = New System.Windows.Forms.Button()
        Me.mopSetLLValue = New System.Windows.Forms.TextBox()
        Me.mopButtonLimitValue = New System.Windows.Forms.Button()
        Me.mopSetLimitValue = New System.Windows.Forms.TextBox()
        Me.mopButtonCuttingTime = New System.Windows.Forms.Button()
        Me.mopSetCuttingTime = New System.Windows.Forms.TextBox()
        Me.mopbuttonAutoChange = New System.Windows.Forms.Button()
        Me.mopSetAutoChange = New System.Windows.Forms.TextBox()
        Me.mopButtonUnusualSignalChange = New System.Windows.Forms.Button()
        Me.mopSetUnusualSignal = New System.Windows.Forms.TextBox()
        Me.mopButtonALVValue = New System.Windows.Forms.Button()
        Me.mopSetALVValue = New System.Windows.Forms.TextBox()
        Me.mopButtonAircutReduction = New System.Windows.Forms.Button()
        Me.mopSetAircutReduction = New System.Windows.Forms.TextBox()
        Me.mopButtonAircutOverride = New System.Windows.Forms.Button()
        Me.mopSetAircutOverride = New System.Windows.Forms.TextBox()
        Me.mopButtonAdaptiveControl = New System.Windows.Forms.Button()
        Me.mopSetAdaptiveControl = New System.Windows.Forms.TextBox()
        Me.mopUlValue = New System.Windows.Forms.TextBox()
        Me.Label121 = New System.Windows.Forms.Label()
        Me.mopToolDataInputMode = New System.Windows.Forms.TextBox()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.mopSignalDiffAlarm = New System.Windows.Forms.TextBox()
        Me.Label124 = New System.Windows.Forms.Label()
        Me.mopReferenceValue = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.mopOverloadMonitor = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.mopMinOverride = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.mopMaxOverride = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.mopLLValue = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.mopLimitValue = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.mopCuttingTime = New System.Windows.Forms.TextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.mopCuttingLoad = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.mopAutoChange = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.mopUnusualSignal = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.mopAlarms = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.mopALVValue = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.mopAircutReduction = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.mopAircutOverride = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.mopAdaptiveControl = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.mopPositionTypeCombo = New System.Windows.Forms.ComboBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.mopAxisCombo = New System.Windows.Forms.ComboBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.mopToolNumber = New System.Windows.Forms.TextBox()
        Me.mopUpdateButton = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.mopToolDataNumber = New System.Windows.Forms.TextBox()
        Me.mopDelete = New System.Windows.Forms.Button()
        Me.mopEdit = New System.Windows.Forms.Button()
        Me.Label139 = New System.Windows.Forms.Label()
        Me.mopCMDClassNumber = New System.Windows.Forms.TextBox()
        Me.Label140 = New System.Windows.Forms.Label()
        Me.mopCMDToolNumber = New System.Windows.Forms.TextBox()
        Me.Label122 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.tab_spindle = New System.Windows.Forms.TabPage()
        Me.spinState = New System.Windows.Forms.TextBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.spinUpdate = New System.Windows.Forms.Button()
        Me.spinRateOverride = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.spinLoad = New System.Windows.Forms.TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.spinOilMist = New System.Windows.Forms.TextBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.spinMaxOverrideRate = New System.Windows.Forms.TextBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.spinCommandRate = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.spinActualRate = New System.Windows.Forms.TextBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.tab_axis2 = New System.Windows.Forms.TabPage()
        Me.txtHiCutProMachiningTolerance = New System.Windows.Forms.TextBox()
        Me.btnGetHiCutProMachiningTolerance = New System.Windows.Forms.Button()
        Me.txtHiCutProFeedrateUpperLimit = New System.Windows.Forms.TextBox()
        Me.btnGetHiCutProFeedrateUpperLimit = New System.Windows.Forms.Button()
        Me.GroupBox38 = New System.Windows.Forms.GroupBox()
        Me.txtHomePositionMax = New System.Windows.Forms.TextBox()
        Me.Label321 = New System.Windows.Forms.Label()
        Me.txtHomePositionIndex = New System.Windows.Forms.TextBox()
        Me.Label316 = New System.Windows.Forms.Label()
        Me.txtHomePosition = New System.Windows.Forms.TextBox()
        Me.Label319 = New System.Windows.Forms.Label()
        Me.btnGetHomePosition = New System.Windows.Forms.Button()
        Me.Label320 = New System.Windows.Forms.Label()
        Me.cboHomePositionAxis = New System.Windows.Forms.ComboBox()
        Me.txtHomePositionMovementOrder = New System.Windows.Forms.TextBox()
        Me.Label324 = New System.Windows.Forms.Label()
        Me.cmdAxis2DataUnit = New System.Windows.Forms.Button()
        Me.cboAxis2DataUnit = New System.Windows.Forms.ComboBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label291 = New System.Windows.Forms.Label()
        Me.cboUserParameterVariableLimitCoordinate = New System.Windows.Forms.ComboBox()
        Me.txtUserParameterLimitInput = New System.Windows.Forms.TextBox()
        Me.txtUserParameterLimit = New System.Windows.Forms.TextBox()
        Me.Label157 = New System.Windows.Forms.Label()
        Me.cmdUserParameterVariableLimitAdd = New System.Windows.Forms.Button()
        Me.cmdUserParameterVariableLimitSet = New System.Windows.Forms.Button()
        Me.cmdUserParameterVariableLimitGet = New System.Windows.Forms.Button()
        Me.Label165 = New System.Windows.Forms.Label()
        Me.cboUserParameterVariableLimitAxis = New System.Windows.Forms.ComboBox()
        Me.Tab_OptionCommonVariables = New System.Windows.Forms.TabPage()
        Me.txtOpCVOutput = New System.Windows.Forms.TextBox()
        Me.grpOptionalCommonVariable = New System.Windows.Forms.GroupBox()
        Me.Label323 = New System.Windows.Forms.Label()
        Me.txtOpCVMax = New System.Windows.Forms.TextBox()
        Me.Label315 = New System.Windows.Forms.Label()
        Me.txtOpCV = New System.Windows.Forms.TextBox()
        Me.btnGetOpCV = New System.Windows.Forms.Button()
        Me.btnGetAllOpCV = New System.Windows.Forms.Button()
        Me.btnAddOpCV = New System.Windows.Forms.Button()
        Me.btnSetOpCV = New System.Windows.Forms.Button()
        Me.txtOpCVIndex2 = New System.Windows.Forms.TextBox()
        Me.txtOpCVIndex1 = New System.Windows.Forms.TextBox()
        Me.txtOpCVValue = New System.Windows.Forms.TextBox()
        Me.Label317 = New System.Windows.Forms.Label()
        Me.txtOpCVIndex = New System.Windows.Forms.TextBox()
        Me.Label318 = New System.Windows.Forms.Label()
        Me.tab_program = New System.Windows.Forms.TabPage()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.txtSubProgramFileName = New System.Windows.Forms.Button()
        Me.cboSR_MIDBlockRestart = New System.Windows.Forms.ComboBox()
        Me.cboSR_AxisMovementOrder = New System.Windows.Forms.ComboBox()
        Me.txtSR_RepeatNumber = New System.Windows.Forms.TextBox()
        Me.Label175 = New System.Windows.Forms.Label()
        Me.txtSR_RelativeBlock = New System.Windows.Forms.TextBox()
        Me.Label171 = New System.Windows.Forms.Label()
        Me.Label172 = New System.Windows.Forms.Label()
        Me.Label173 = New System.Windows.Forms.Label()
        Me.txtSR_SequenceBlockNumber = New System.Windows.Forms.TextBox()
        Me.Label174 = New System.Windows.Forms.Label()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.cmdSelectScheduleProgram = New System.Windows.Forms.Button()
        Me.cboFileReadModeEnum = New System.Windows.Forms.ComboBox()
        Me.progSelectProgramButton = New System.Windows.Forms.Button()
        Me.Label146 = New System.Windows.Forms.Label()
        Me.prog3 = New System.Windows.Forms.TextBox()
        Me.Label147 = New System.Windows.Forms.Label()
        Me.prog2 = New System.Windows.Forms.TextBox()
        Me.Label148 = New System.Windows.Forms.Label()
        Me.prog1 = New System.Windows.Forms.TextBox()
        Me.Label149 = New System.Windows.Forms.Label()
        Me.cmdCancelProgram = New System.Windows.Forms.Button()
        Me.progButtonExecBlock = New System.Windows.Forms.Button()
        Me.progExecutePoint = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.progRead = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.progColumn = New System.Windows.Forms.TextBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.progRow = New System.Windows.Forms.TextBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.progExecutingBlock = New System.Windows.Forms.TextBox()
        Me.label99 = New System.Windows.Forms.Label()
        Me.progExecCombo = New System.Windows.Forms.ComboBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.progUpdateButton = New System.Windows.Forms.Button()
        Me.progNoParams = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.progButtonGetRunProgram = New System.Windows.Forms.Button()
        Me.progRunningPrograms = New System.Windows.Forms.TextBox()
        Me.tab_Renishaw_1 = New System.Windows.Forms.TabPage()
        Me.btnGetActiveProgramFilePath = New System.Windows.Forms.Button()
        Me.txtActiveProgramFilePath = New System.Windows.Forms.TextBox()
        Me.btnCancelSubProgram = New System.Windows.Forms.Button()
        Me.btnSelectSubProgram2 = New System.Windows.Forms.Button()
        Me.btnSelectSubProgram = New System.Windows.Forms.Button()
        Me.txtSelectSubProgram = New System.Windows.Forms.TextBox()
        Me.Label261 = New System.Windows.Forms.Label()
        Me.txtTouchProbeSignal = New System.Windows.Forms.TextBox()
        Me.Label260 = New System.Windows.Forms.Label()
        Me.btnGetTouchProbeSignal = New System.Windows.Forms.Button()
        Me.txtProbeSubProgramStatus = New System.Windows.Forms.TextBox()
        Me.Label259 = New System.Windows.Forms.Label()
        Me.btnProbeSubProgramStatus = New System.Windows.Forms.Button()
        Me.txtProbePositionC = New System.Windows.Forms.TextBox()
        Me.txtProbePositionB = New System.Windows.Forms.TextBox()
        Me.Label257 = New System.Windows.Forms.Label()
        Me.Label258 = New System.Windows.Forms.Label()
        Me.txtProbePositionA = New System.Windows.Forms.TextBox()
        Me.txtProbePositionZ = New System.Windows.Forms.TextBox()
        Me.Label255 = New System.Windows.Forms.Label()
        Me.Label256 = New System.Windows.Forms.Label()
        Me.txtProbePositionY = New System.Windows.Forms.TextBox()
        Me.txtProbePositionX = New System.Windows.Forms.TextBox()
        Me.Label253 = New System.Windows.Forms.Label()
        Me.Label254 = New System.Windows.Forms.Label()
        Me.btnProbeUpdate = New System.Windows.Forms.Button()
        Me.tab_variables = New System.Windows.Forms.TabPage()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.varValue = New System.Windows.Forms.TextBox()
        Me.varUpdateButton = New System.Windows.Forms.Button()
        Me.varGetAllButton = New System.Windows.Forms.Button()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.varNumberOfVars = New System.Windows.Forms.TextBox()
        Me.varGetAllResults = New System.Windows.Forms.TextBox()
        Me.varAddValue = New System.Windows.Forms.Button()
        Me.varSetValue = New System.Windows.Forms.Button()
        Me.varEnd = New System.Windows.Forms.TextBox()
        Me.varBegin = New System.Windows.Forms.TextBox()
        Me.varValueUpdate = New System.Windows.Forms.TextBox()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.varCommonVarNumber = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.Tab_View = New System.Windows.Forms.TabPage()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label231 = New System.Windows.Forms.Label()
        Me.Cmb_ChangeScreen = New System.Windows.Forms.ComboBox()
        Me.cmd_ChangeScreen = New System.Windows.Forms.Button()
        Me.txt_screenname = New System.Windows.Forms.TextBox()
        Me.Label232 = New System.Windows.Forms.Label()
        Me.tab_PLC = New System.Windows.Forms.TabPage()
        Me.grpUserTaskIOVariable = New System.Windows.Forms.GroupBox()
        Me.cboSetUserTaskOutputVariableProtected = New System.Windows.Forms.ComboBox()
        Me.cboSetUserTaskOutputVariable = New System.Windows.Forms.ComboBox()
        Me.btnSetProtectedUserTaskOutputVariable = New System.Windows.Forms.Button()
        Me.txtSetProtectedUserTaskIOOutputVariableIndex = New System.Windows.Forms.TextBox()
        Me.txtGetProtectedUserTaskIOOutputVariableValue = New System.Windows.Forms.TextBox()
        Me.btnGetProtectedUserTaskOutputVariable = New System.Windows.Forms.Button()
        Me.txtGetProtectedUserTaskIOOutputVariableIndex = New System.Windows.Forms.TextBox()
        Me.Label338 = New System.Windows.Forms.Label()
        Me.btnSetUserTaskOutputVariable = New System.Windows.Forms.Button()
        Me.txtSetUserTaskIOOutputVariableIndex = New System.Windows.Forms.TextBox()
        Me.txtUserTaskIOOutputVariableValue = New System.Windows.Forms.TextBox()
        Me.btnGetUserTaskOutputIOVariable = New System.Windows.Forms.Button()
        Me.txtUserTaskIOOutputVariableIndex = New System.Windows.Forms.TextBox()
        Me.txtUserTaskIOInputVariableValue = New System.Windows.Forms.TextBox()
        Me.btnGetUserTaskInputIOVariable = New System.Windows.Forms.Button()
        Me.txtUserTaskIOInputVariableIndex = New System.Windows.Forms.TextBox()
        Me.Label337 = New System.Windows.Forms.Label()
        Me.grpIOVariables = New System.Windows.Forms.GroupBox()
        Me.txtIOLabel = New System.Windows.Forms.TextBox()
        Me.btnGetIOLabel = New System.Windows.Forms.Button()
        Me.txtIOLongWordLabel = New System.Windows.Forms.TextBox()
        Me.txtIOWordLabel = New System.Windows.Forms.TextBox()
        Me.txtIOBitLabel = New System.Windows.Forms.TextBox()
        Me.cmdIOGetBitByLabel = New System.Windows.Forms.Button()
        Me.cmdIOGetWordByLabel = New System.Windows.Forms.Button()
        Me.cmdIOGetLongWordByLabel = New System.Windows.Forms.Button()
        Me.Label297 = New System.Windows.Forms.Label()
        Me.cboIOVariableTypes = New System.Windows.Forms.ComboBox()
        Me.cmdIOGetBit = New System.Windows.Forms.Button()
        Me.cmdIOGetWord = New System.Windows.Forms.Button()
        Me.cmdIOGetLongWord = New System.Windows.Forms.Button()
        Me.txtIOLongWord = New System.Windows.Forms.TextBox()
        Me.txtIOWord = New System.Windows.Forms.TextBox()
        Me.txtIOBit = New System.Windows.Forms.TextBox()
        Me.Label296 = New System.Windows.Forms.Label()
        Me.txtIOBitNo = New System.Windows.Forms.TextBox()
        Me.Label295 = New System.Windows.Forms.Label()
        Me.txtIOLongWordIndex = New System.Windows.Forms.TextBox()
        Me.Label294 = New System.Windows.Forms.Label()
        Me.txtIOWordIndex = New System.Windows.Forms.TextBox()
        Me.Label293 = New System.Windows.Forms.Label()
        Me.txtIOBitIndex = New System.Windows.Forms.TextBox()
        Me.Label292 = New System.Windows.Forms.Label()
        Me.tab_ballscrew = New System.Windows.Forms.TabPage()
        Me.ballscrewDataUnitCombo = New System.Windows.Forms.ComboBox()
        Me.bsDataUnitSet = New System.Windows.Forms.Button()
        Me.Label150 = New System.Windows.Forms.Label()
        Me.Label115 = New System.Windows.Forms.Label()
        Me.bsPecPoint = New System.Windows.Forms.TextBox()
        Me.bsStartPositionAdd = New System.Windows.Forms.Button()
        Me.bsStartPositionSet = New System.Windows.Forms.Button()
        Me.bsMaxPitchPointsAdd = New System.Windows.Forms.Button()
        Me.bsMaxPicthPointsSet = New System.Windows.Forms.Button()
        Me.bsIntervalAdd = New System.Windows.Forms.Button()
        Me.bsIntervalSet = New System.Windows.Forms.Button()
        Me.bsDataPointAdd = New System.Windows.Forms.Button()
        Me.bsDataPointSet = New System.Windows.Forms.Button()
        Me.bsStartPositionUpdate = New System.Windows.Forms.TextBox()
        Me.bsMaxPitchPointsUpdate = New System.Windows.Forms.TextBox()
        Me.bsIntervalUpdate = New System.Windows.Forms.TextBox()
        Me.bsDataPointUpdate = New System.Windows.Forms.TextBox()
        Me.bsStartPosition = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.bsMaxPitchPoints = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.bsInterval = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.ballscrewUpdateButton = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.ballscrewAxisCombo = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.bsDataPoint = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tab_tools = New System.Windows.Forms.TabPage()
        Me.tulAddCutterRCompOffset = New System.Windows.Forms.Button()
        Me.tulAddCutterRCompWearOffset = New System.Windows.Forms.Button()
        Me.tulToolLifeRemainSec = New System.Windows.Forms.TextBox()
        Me.Label205 = New System.Windows.Forms.Label()
        Me.Label151 = New System.Windows.Forms.Label()
        Me.tulSetDataUnit = New System.Windows.Forms.Button()
        Me.tulDataUnitCombo = New System.Windows.Forms.ComboBox()
        Me.tulButtonCutterRLengthOffset = New System.Windows.Forms.Button()
        Me.tulButtonCutterROffset = New System.Windows.Forms.Button()
        Me.tulButtonLengthWearOffset = New System.Windows.Forms.Button()
        Me.tulButtonLengthOffset = New System.Windows.Forms.Button()
        Me.tulTo = New System.Windows.Forms.TextBox()
        Me.Label125 = New System.Windows.Forms.Label()
        Me.tulFrom = New System.Windows.Forms.TextBox()
        Me.Label126 = New System.Windows.Forms.Label()
        Me.tulResults = New System.Windows.Forms.TextBox()
        Me.tulAddToolLengthOffset = New System.Windows.Forms.Button()
        Me.tulUpdToolGroupOrder = New System.Windows.Forms.ComboBox()
        Me.tulUpdToolStatus = New System.Windows.Forms.ComboBox()
        Me.tulUpdToolMode = New System.Windows.Forms.ComboBox()
        Me.tulToolNumber = New System.Windows.Forms.TextBox()
        Me.label100 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.tulUpdateButtonNoParam = New System.Windows.Forms.Button()
        Me.tulNoParam = New System.Windows.Forms.TextBox()
        Me.tulUpdateButton = New System.Windows.Forms.Button()
        Me.tulSetToolLifeRemaining = New System.Windows.Forms.Button()
        Me.tulUpdToolLifeRemaining = New System.Windows.Forms.TextBox()
        Me.tulToolLifeRemaining = New System.Windows.Forms.TextBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.tulSetToolLife = New System.Windows.Forms.Button()
        Me.tulUpdToolLife = New System.Windows.Forms.TextBox()
        Me.tulToolLife = New System.Windows.Forms.TextBox()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.tulCalToolLengthWearOffset = New System.Windows.Forms.Button()
        Me.tulAddToolLengthWearOffset = New System.Windows.Forms.Button()
        Me.tulSetToolLengthWearOffset = New System.Windows.Forms.Button()
        Me.tulUpdToolLengthWearOffset = New System.Windows.Forms.TextBox()
        Me.tulToolLengthWearOffset = New System.Windows.Forms.TextBox()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.tulCalToolLengthOffset = New System.Windows.Forms.Button()
        Me.tulSetToolLengthOffset = New System.Windows.Forms.Button()
        Me.tulUpdToolLengthOffset = New System.Windows.Forms.TextBox()
        Me.tulToolLengthOffset = New System.Windows.Forms.TextBox()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.tulToolKind = New System.Windows.Forms.TextBox()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.tulSetToolGroupOrder = New System.Windows.Forms.Button()
        Me.tulToolGroupOrder = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.tulSetToolStatus = New System.Windows.Forms.Button()
        Me.tulToolStatus = New System.Windows.Forms.TextBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.tulSetReferenceToolOffset3 = New System.Windows.Forms.Button()
        Me.tulSetReferenceToolOffset2 = New System.Windows.Forms.Button()
        Me.tulSetToolMode = New System.Windows.Forms.Button()
        Me.tulSetToolGroup = New System.Windows.Forms.Button()
        Me.tulSetCutterRCompWearOffset = New System.Windows.Forms.Button()
        Me.tulSetCutterRCompOffset = New System.Windows.Forms.Button()
        Me.tulUpdReferenceToolOffset3 = New System.Windows.Forms.TextBox()
        Me.tulUpdReferenceToolOffset2 = New System.Windows.Forms.TextBox()
        Me.tulUpdToolGroup = New System.Windows.Forms.TextBox()
        Me.tulUpdCutterRCompWearOffset = New System.Windows.Forms.TextBox()
        Me.tulUpdCutterRCompOffset = New System.Windows.Forms.TextBox()
        Me.tulReferenceToolOffset3 = New System.Windows.Forms.TextBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.tulReferenceToolOffset2 = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.tulPotNumber = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.tulToolGroup = New System.Windows.Forms.TextBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.tulToolMode = New System.Windows.Forms.TextBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.tulCutterRCompWearOffset = New System.Windows.Forms.TextBox()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.tulCutterRCompOffset = New System.Windows.Forms.TextBox()
        Me.tabAPILoggingService = New System.Windows.Forms.TabPage()
        Me.dgvLogging = New System.Windows.Forms.DataGridView()
        Me.DateLoggedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AppNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClassNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MethodNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IOParametersDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LoggingLevelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MessageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLogRecordBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox40 = New System.Windows.Forms.GroupBox()
        Me.txtLogMessage = New System.Windows.Forms.TextBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.txtLogIOParameters = New System.Windows.Forms.TextBox()
        Me.lblIOParameters = New System.Windows.Forms.Label()
        Me.txtLogFunctionName = New System.Windows.Forms.TextBox()
        Me.lblFunctionName = New System.Windows.Forms.Label()
        Me.txtLogClassName = New System.Windows.Forms.TextBox()
        Me.lblClassName = New System.Windows.Forms.Label()
        Me.txtLogAppName = New System.Windows.Forms.TextBox()
        Me.lblAppName = New System.Windows.Forms.Label()
        Me.btnDisplayLogRecords = New System.Windows.Forms.Button()
        Me.Label326 = New System.Windows.Forms.Label()
        Me.cboLoggingLevel = New System.Windows.Forms.ComboBox()
        Me.Label327 = New System.Windows.Forms.Label()
        Me.Label328 = New System.Windows.Forms.Label()
        Me.dtpEndingDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartingDate = New System.Windows.Forms.DateTimePicker()
        Me.errorlog = New System.Windows.Forms.TextBox()
        Me.clearLogButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.MainTabControl.SuspendLayout
        Me.tabMain.SuspendLayout
        Me.GroupBox39.SuspendLayout
        Me.GroupBox34.SuspendLayout
        Me.GroupBox29.SuspendLayout
        Me.GroupBox37.SuspendLayout
        Me.GroupBox30.SuspendLayout
        Me.GroupBox27.SuspendLayout
        Me.GroupBox28.SuspendLayout
        Me.GroupBox31.SuspendLayout
        Me.GroupBox32.SuspendLayout
        Me.GroupBox35.SuspendLayout
        Me.GroupBox36.SuspendLayout
        Me.txtP300ToolGaugeStatusValue.SuspendLayout
        Me.tab_atc.SuspendLayout
        Me.GroupBox13.SuspendLayout
        Me.Panel1.SuspendLayout
        Me.Panel2.SuspendLayout
        Me.Panel3.SuspendLayout
        Me.tab_P300ATC.SuspendLayout
        Me.GroupBox44.SuspendLayout
        Me.GroupBox33.SuspendLayout
        Me.tab_ATCSubPanel.SuspendLayout
        Me.GroupBox43.SuspendLayout
        Me.GroupBox42.SuspendLayout
        Me.GroupBox41.SuspendLayout
        Me.tab_machine.SuspendLayout
        Me.grpHourMeter.SuspendLayout
        Me.GroupBox8.SuspendLayout
        Me.Panel11.SuspendLayout
        Me.tab_workpiece.SuspendLayout
        Me.Panel9.SuspendLayout
        Me.Panel10.SuspendLayout
        Me.tab_OptionalParameter.SuspendLayout
        Me.GroupBox12.SuspendLayout
        Me.tab_spec.SuspendLayout
        Me.GroupBox26.SuspendLayout
        Me.GroupBox10.SuspendLayout
        Me.Tools2_2.SuspendLayout
        Me.GroupBox21.SuspendLayout
        Me.GroupBox19.SuspendLayout
        Me.GroupBox18.SuspendLayout
        Me.tab_coolant.SuspendLayout
        Me.tab_MacManOperatingHistory.SuspendLayout
        Me.GroupBox5.SuspendLayout
        Me.GroupBox4.SuspendLayout
        Me.tab_MacManMachiningReport.SuspendLayout
        CType(Me.grdMMMachiningReports,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tab_MacmanOperatingReport.SuspendLayout
        Me.GroupBox1.SuspendLayout
        Me.GroupBox2.SuspendLayout
        Me.GroupBox3.SuspendLayout
        Me.tab_MacManAlarmHistory.SuspendLayout
        CType(Me.grdMMAlarmHistory,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox9.SuspendLayout
        Me.tab_MacmanOperationHistory.SuspendLayout
        Me.tab_CurrentAlarm.SuspendLayout
        Me.GroupBox20.SuspendLayout
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tab_Tools2_1.SuspendLayout
        Me.GroupBox16.SuspendLayout
        Me.GroupBox17.SuspendLayout
        Me.tab_Renishaw_2.SuspendLayout
        Me.GroupBox22.SuspendLayout
        Me.GroupBox25.SuspendLayout
        Me.GroupBox24.SuspendLayout
        Me.GroupBox23.SuspendLayout
        Me.tab_axis.SuspendLayout
        Me.tab_Program2.SuspendLayout
        Me.tab_MopTool.SuspendLayout
        Me.Panel6.SuspendLayout
        Me.GroupBox6.SuspendLayout
        Me.tab_spindle.SuspendLayout
        Me.tab_axis2.SuspendLayout
        Me.GroupBox38.SuspendLayout
        Me.GroupBox11.SuspendLayout
        Me.Tab_OptionCommonVariables.SuspendLayout
        Me.grpOptionalCommonVariable.SuspendLayout
        Me.tab_program.SuspendLayout
        Me.GroupBox15.SuspendLayout
        Me.GroupBox14.SuspendLayout
        Me.Panel8.SuspendLayout
        Me.tab_Renishaw_1.SuspendLayout
        Me.tab_variables.SuspendLayout
        Me.Tab_View.SuspendLayout
        Me.Panel12.SuspendLayout
        Me.tab_PLC.SuspendLayout
        Me.grpUserTaskIOVariable.SuspendLayout
        Me.grpIOVariables.SuspendLayout
        Me.tab_ballscrew.SuspendLayout
        Me.tab_tools.SuspendLayout
        Me.tabAPILoggingService.SuspendLayout
        CType(Me.dgvLogging,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.CLogRecordBindingSource,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox40.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
        '
        'MainTabControl
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.MainTabControl, 2)
        Me.MainTabControl.Controls.Add(Me.tabMain)
        Me.MainTabControl.Controls.Add(Me.tab_atc)
        Me.MainTabControl.Controls.Add(Me.tab_P300ATC)
        Me.MainTabControl.Controls.Add(Me.tab_ATCSubPanel)
        Me.MainTabControl.Controls.Add(Me.tab_machine)
        Me.MainTabControl.Controls.Add(Me.tab_workpiece)
        Me.MainTabControl.Controls.Add(Me.tab_OptionalParameter)
        Me.MainTabControl.Controls.Add(Me.tab_spec)
        Me.MainTabControl.Controls.Add(Me.Tools2_2)
        Me.MainTabControl.Controls.Add(Me.tab_coolant)
        Me.MainTabControl.Controls.Add(Me.tab_MacManOperatingHistory)
        Me.MainTabControl.Controls.Add(Me.tab_MacManMachiningReport)
        Me.MainTabControl.Controls.Add(Me.tab_MacmanOperatingReport)
        Me.MainTabControl.Controls.Add(Me.tab_MacManAlarmHistory)
        Me.MainTabControl.Controls.Add(Me.tab_MacmanOperationHistory)
        Me.MainTabControl.Controls.Add(Me.tab_CurrentAlarm)
        Me.MainTabControl.Controls.Add(Me.tab_Tools2_1)
        Me.MainTabControl.Controls.Add(Me.tab_Renishaw_2)
        Me.MainTabControl.Controls.Add(Me.tab_axis)
        Me.MainTabControl.Controls.Add(Me.tab_Program2)
        Me.MainTabControl.Controls.Add(Me.tab_MopTool)
        Me.MainTabControl.Controls.Add(Me.tab_spindle)
        Me.MainTabControl.Controls.Add(Me.tab_axis2)
        Me.MainTabControl.Controls.Add(Me.Tab_OptionCommonVariables)
        Me.MainTabControl.Controls.Add(Me.tab_program)
        Me.MainTabControl.Controls.Add(Me.tab_Renishaw_1)
        Me.MainTabControl.Controls.Add(Me.tab_variables)
        Me.MainTabControl.Controls.Add(Me.Tab_View)
        Me.MainTabControl.Controls.Add(Me.tab_PLC)
        Me.MainTabControl.Controls.Add(Me.tab_ballscrew)
        Me.MainTabControl.Controls.Add(Me.tab_tools)
        Me.MainTabControl.Controls.Add(Me.tabAPILoggingService)
        Me.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainTabControl.Location = New System.Drawing.Point(3, 3)
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        Me.MainTabControl.Size = New System.Drawing.Size(1027, 527)
        Me.MainTabControl.TabIndex = 0
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.btnP300GetAttachedToolList)
        Me.tabMain.Controls.Add(Me.btnP300GetAllToolList)
        Me.tabMain.Controls.Add(Me.txtP300ToolsUpdate2)
        Me.tabMain.Controls.Add(Me.btnP300GetRegisteredToolList)
        Me.tabMain.Controls.Add(Me.GroupBox39)
        Me.tabMain.Controls.Add(Me.GroupBox34)
        Me.tabMain.Controls.Add(Me.btnP300ToolUpdate)
        Me.tabMain.Controls.Add(Me.txtP300ToolsUpdate)
        Me.tabMain.Controls.Add(Me.Label32)
        Me.tabMain.Controls.Add(Me.cboP300ToolCompensation)
        Me.tabMain.Controls.Add(Me.GroupBox29)
        Me.tabMain.Controls.Add(Me.Label2)
        Me.tabMain.Controls.Add(Me.txtP300GroupNumber)
        Me.tabMain.Controls.Add(Me.btnP300ToolSetDataUnit)
        Me.tabMain.Controls.Add(Me.Label342)
        Me.tabMain.Controls.Add(Me.cboP300ToolsDataUnit)
        Me.tabMain.Controls.Add(Me.Label340)
        Me.tabMain.Controls.Add(Me.txtP300ToolNumber)
        Me.tabMain.Location = New System.Drawing.Point(4, 25)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Size = New System.Drawing.Size(1019, 498)
        Me.tabMain.TabIndex = 25
        Me.tabMain.Text = "P300 Tools"
        '
        'btnP300GetAttachedToolList
        '
        Me.btnP300GetAttachedToolList.Location = New System.Drawing.Point(534, 321)
        Me.btnP300GetAttachedToolList.Name = "btnP300GetAttachedToolList"
        Me.btnP300GetAttachedToolList.Size = New System.Drawing.Size(169, 51)
        Me.btnP300GetAttachedToolList.TabIndex = 391
        Me.btnP300GetAttachedToolList.Text = "Get Attached Tool List (P300S/L)"
        '
        'btnP300GetAllToolList
        '
        Me.btnP300GetAllToolList.Location = New System.Drawing.Point(534, 374)
        Me.btnP300GetAllToolList.Name = "btnP300GetAllToolList"
        Me.btnP300GetAllToolList.Size = New System.Drawing.Size(169, 51)
        Me.btnP300GetAllToolList.TabIndex = 390
        Me.btnP300GetAllToolList.Text = "Get All Tool List (P300S/L)"
        '
        'txtP300ToolsUpdate2
        '
        Me.txtP300ToolsUpdate2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtP300ToolsUpdate2.Location = New System.Drawing.Point(709, 267)
        Me.txtP300ToolsUpdate2.Multiline = true
        Me.txtP300ToolsUpdate2.Name = "txtP300ToolsUpdate2"
        Me.txtP300ToolsUpdate2.ReadOnly = true
        Me.txtP300ToolsUpdate2.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtP300ToolsUpdate2.Size = New System.Drawing.Size(303, 205)
        Me.txtP300ToolsUpdate2.TabIndex = 389
        '
        'btnP300GetRegisteredToolList
        '
        Me.btnP300GetRegisteredToolList.Location = New System.Drawing.Point(534, 268)
        Me.btnP300GetRegisteredToolList.Name = "btnP300GetRegisteredToolList"
        Me.btnP300GetRegisteredToolList.Size = New System.Drawing.Size(169, 51)
        Me.btnP300GetRegisteredToolList.TabIndex = 388
        Me.btnP300GetRegisteredToolList.Text = "Get Registered Tool List (P300S/L)"
        '
        'GroupBox39
        '
        Me.GroupBox39.Controls.Add(Me.txtP300ToolNameValue)
        Me.GroupBox39.Controls.Add(Me.btnP300GetToolName)
        Me.GroupBox39.Controls.Add(Me.txtP300ToolName)
        Me.GroupBox39.Controls.Add(Me.btnP300SetToolName)
        Me.GroupBox39.Location = New System.Drawing.Point(200, 264)
        Me.GroupBox39.Name = "GroupBox39"
        Me.GroupBox39.Size = New System.Drawing.Size(326, 64)
        Me.GroupBox39.TabIndex = 370
        Me.GroupBox39.TabStop = false
        Me.GroupBox39.Text = "Tool Name"
        '
        'txtP300ToolNameValue
        '
        Me.txtP300ToolNameValue.ForeColor = System.Drawing.Color.Red
        Me.txtP300ToolNameValue.Location = New System.Drawing.Point(200, 32)
        Me.txtP300ToolNameValue.Name = "txtP300ToolNameValue"
        Me.txtP300ToolNameValue.Size = New System.Drawing.Size(120, 22)
        Me.txtP300ToolNameValue.TabIndex = 317
        Me.txtP300ToolNameValue.Text = "0"
        '
        'btnP300GetToolName
        '
        Me.btnP300GetToolName.Location = New System.Drawing.Point(0, 28)
        Me.btnP300GetToolName.Name = "btnP300GetToolName"
        Me.btnP300GetToolName.Size = New System.Drawing.Size(44, 27)
        Me.btnP300GetToolName.TabIndex = 300
        Me.btnP300GetToolName.Text = "Get"
        '
        'txtP300ToolName
        '
        Me.txtP300ToolName.Location = New System.Drawing.Point(96, 32)
        Me.txtP300ToolName.Name = "txtP300ToolName"
        Me.txtP300ToolName.ReadOnly = true
        Me.txtP300ToolName.Size = New System.Drawing.Size(96, 22)
        Me.txtP300ToolName.TabIndex = 316
        Me.txtP300ToolName.Text = "1"
        '
        'btnP300SetToolName
        '
        Me.btnP300SetToolName.Location = New System.Drawing.Point(48, 28)
        Me.btnP300SetToolName.Name = "btnP300SetToolName"
        Me.btnP300SetToolName.Size = New System.Drawing.Size(38, 27)
        Me.btnP300SetToolName.TabIndex = 301
        Me.btnP300SetToolName.Text = "Set"
        '
        'GroupBox34
        '
        Me.GroupBox34.Controls.Add(Me.btnP300GetToolType)
        Me.GroupBox34.Controls.Add(Me.txtP300ToolType)
        Me.GroupBox34.Location = New System.Drawing.Point(10, 268)
        Me.GroupBox34.Name = "GroupBox34"
        Me.GroupBox34.Size = New System.Drawing.Size(172, 64)
        Me.GroupBox34.TabIndex = 369
        Me.GroupBox34.TabStop = false
        Me.GroupBox34.Text = "Tool Type"
        '
        'btnP300GetToolType
        '
        Me.btnP300GetToolType.Location = New System.Drawing.Point(6, 28)
        Me.btnP300GetToolType.Name = "btnP300GetToolType"
        Me.btnP300GetToolType.Size = New System.Drawing.Size(48, 27)
        Me.btnP300GetToolType.TabIndex = 300
        Me.btnP300GetToolType.Text = "Get"
        '
        'txtP300ToolType
        '
        Me.txtP300ToolType.Location = New System.Drawing.Point(58, 28)
        Me.txtP300ToolType.Name = "txtP300ToolType"
        Me.txtP300ToolType.ReadOnly = true
        Me.txtP300ToolType.Size = New System.Drawing.Size(105, 22)
        Me.txtP300ToolType.TabIndex = 316
        Me.txtP300ToolType.Text = "1"
        '
        'btnP300ToolUpdate
        '
        Me.btnP300ToolUpdate.Location = New System.Drawing.Point(8, 336)
        Me.btnP300ToolUpdate.Name = "btnP300ToolUpdate"
        Me.btnP300ToolUpdate.Size = New System.Drawing.Size(76, 37)
        Me.btnP300ToolUpdate.TabIndex = 368
        Me.btnP300ToolUpdate.Text = "Update"
        '
        'txtP300ToolsUpdate
        '
        Me.txtP300ToolsUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtP300ToolsUpdate.Location = New System.Drawing.Point(96, 336)
        Me.txtP300ToolsUpdate.Multiline = true
        Me.txtP300ToolsUpdate.Name = "txtP300ToolsUpdate"
        Me.txtP300ToolsUpdate.ReadOnly = true
        Me.txtP300ToolsUpdate.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtP300ToolsUpdate.Size = New System.Drawing.Size(432, 136)
        Me.txtP300ToolsUpdate.TabIndex = 367
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(355, 9)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(125, 19)
        Me.Label32.TabIndex = 366
        Me.Label32.Text = "Compensation No"
        '
        'cboP300ToolCompensation
        '
        Me.cboP300ToolCompensation.Location = New System.Drawing.Point(490, 9)
        Me.cboP300ToolCompensation.Name = "cboP300ToolCompensation"
        Me.cboP300ToolCompensation.Size = New System.Drawing.Size(86, 24)
        Me.cboP300ToolCompensation.TabIndex = 365
        '
        'GroupBox29
        '
        Me.GroupBox29.Controls.Add(Me.GroupBox37)
        Me.GroupBox29.Controls.Add(Me.GroupBox30)
        Me.GroupBox29.Controls.Add(Me.GroupBox27)
        Me.GroupBox29.Controls.Add(Me.GroupBox28)
        Me.GroupBox29.Controls.Add(Me.GroupBox31)
        Me.GroupBox29.Controls.Add(Me.GroupBox32)
        Me.GroupBox29.Controls.Add(Me.GroupBox35)
        Me.GroupBox29.Controls.Add(Me.GroupBox36)
        Me.GroupBox29.Controls.Add(Me.txtP300ToolGaugeStatusValue)
        Me.GroupBox29.Location = New System.Drawing.Point(10, 37)
        Me.GroupBox29.Name = "GroupBox29"
        Me.GroupBox29.Size = New System.Drawing.Size(1002, 221)
        Me.GroupBox29.TabIndex = 361
        Me.GroupBox29.TabStop = false
        Me.GroupBox29.Text = "P300 S(MP) / M"
        '
        'GroupBox37
        '
        Me.GroupBox37.Controls.Add(Me.txtP300ToolMaxSpeedValue)
        Me.GroupBox37.Controls.Add(Me.btnP300GetToolMaxSpeed)
        Me.GroupBox37.Controls.Add(Me.txtP300ToolMaxSpeed)
        Me.GroupBox37.Controls.Add(Me.btnP300SetToolMaxSpeed)
        Me.GroupBox37.Location = New System.Drawing.Point(490, 148)
        Me.GroupBox37.Name = "GroupBox37"
        Me.GroupBox37.Size = New System.Drawing.Size(238, 64)
        Me.GroupBox37.TabIndex = 329
        Me.GroupBox37.TabStop = false
        Me.GroupBox37.Text = "Tool Max Speed"
        '
        'txtP300ToolMaxSpeedValue
        '
        Me.txtP300ToolMaxSpeedValue.ForeColor = System.Drawing.Color.Red
        Me.txtP300ToolMaxSpeedValue.Location = New System.Drawing.Point(163, 28)
        Me.txtP300ToolMaxSpeedValue.Name = "txtP300ToolMaxSpeedValue"
        Me.txtP300ToolMaxSpeedValue.Size = New System.Drawing.Size(58, 22)
        Me.txtP300ToolMaxSpeedValue.TabIndex = 317
        Me.txtP300ToolMaxSpeedValue.Text = "0"
        '
        'btnP300GetToolMaxSpeed
        '
        Me.btnP300GetToolMaxSpeed.Location = New System.Drawing.Point(0, 28)
        Me.btnP300GetToolMaxSpeed.Name = "btnP300GetToolMaxSpeed"
        Me.btnP300GetToolMaxSpeed.Size = New System.Drawing.Size(48, 27)
        Me.btnP300GetToolMaxSpeed.TabIndex = 300
        Me.btnP300GetToolMaxSpeed.Text = "Get"
        '
        'txtP300ToolMaxSpeed
        '
        Me.txtP300ToolMaxSpeed.Location = New System.Drawing.Point(96, 28)
        Me.txtP300ToolMaxSpeed.Name = "txtP300ToolMaxSpeed"
        Me.txtP300ToolMaxSpeed.ReadOnly = true
        Me.txtP300ToolMaxSpeed.Size = New System.Drawing.Size(58, 22)
        Me.txtP300ToolMaxSpeed.TabIndex = 316
        Me.txtP300ToolMaxSpeed.Text = "1"
        '
        'btnP300SetToolMaxSpeed
        '
        Me.btnP300SetToolMaxSpeed.Location = New System.Drawing.Point(48, 28)
        Me.btnP300SetToolMaxSpeed.Name = "btnP300SetToolMaxSpeed"
        Me.btnP300SetToolMaxSpeed.Size = New System.Drawing.Size(38, 27)
        Me.btnP300SetToolMaxSpeed.TabIndex = 301
        Me.btnP300SetToolMaxSpeed.Text = "Set"
        '
        'GroupBox30
        '
        Me.GroupBox30.Controls.Add(Me.txtP300ToolGroupNoValue)
        Me.GroupBox30.Controls.Add(Me.btnP300GetToolGroupNo)
        Me.GroupBox30.Controls.Add(Me.txtP300ToolGroupNo)
        Me.GroupBox30.Controls.Add(Me.btnP300SetToolGroupNo)
        Me.GroupBox30.Location = New System.Drawing.Point(254, 148)
        Me.GroupBox30.Name = "GroupBox30"
        Me.GroupBox30.Size = New System.Drawing.Size(230, 64)
        Me.GroupBox30.TabIndex = 328
        Me.GroupBox30.TabStop = false
        Me.GroupBox30.Text = "Tool Group No."
        '
        'txtP300ToolGroupNoValue
        '
        Me.txtP300ToolGroupNoValue.ForeColor = System.Drawing.Color.Red
        Me.txtP300ToolGroupNoValue.Location = New System.Drawing.Point(163, 28)
        Me.txtP300ToolGroupNoValue.Name = "txtP300ToolGroupNoValue"
        Me.txtP300ToolGroupNoValue.Size = New System.Drawing.Size(58, 22)
        Me.txtP300ToolGroupNoValue.TabIndex = 317
        Me.txtP300ToolGroupNoValue.Text = "0"
        '
        'btnP300GetToolGroupNo
        '
        Me.btnP300GetToolGroupNo.Location = New System.Drawing.Point(2, 28)
        Me.btnP300GetToolGroupNo.Name = "btnP300GetToolGroupNo"
        Me.btnP300GetToolGroupNo.Size = New System.Drawing.Size(46, 27)
        Me.btnP300GetToolGroupNo.TabIndex = 300
        Me.btnP300GetToolGroupNo.Text = "Get"
        '
        'txtP300ToolGroupNo
        '
        Me.txtP300ToolGroupNo.Location = New System.Drawing.Point(96, 28)
        Me.txtP300ToolGroupNo.Name = "txtP300ToolGroupNo"
        Me.txtP300ToolGroupNo.ReadOnly = true
        Me.txtP300ToolGroupNo.Size = New System.Drawing.Size(58, 22)
        Me.txtP300ToolGroupNo.TabIndex = 316
        Me.txtP300ToolGroupNo.Text = "1"
        '
        'btnP300SetToolGroupNo
        '
        Me.btnP300SetToolGroupNo.Location = New System.Drawing.Point(48, 28)
        Me.btnP300SetToolGroupNo.Name = "btnP300SetToolGroupNo"
        Me.btnP300SetToolGroupNo.Size = New System.Drawing.Size(38, 27)
        Me.btnP300SetToolGroupNo.TabIndex = 301
        Me.btnP300SetToolGroupNo.Text = "Set"
        '
        'GroupBox27
        '
        Me.GroupBox27.Controls.Add(Me.btnP300AddToolOffset)
        Me.GroupBox27.Controls.Add(Me.txtP300ToolOffsetSetValue)
        Me.GroupBox27.Controls.Add(Me.btnP300GetToolOffset)
        Me.GroupBox27.Controls.Add(Me.txtP300ToolOffset)
        Me.GroupBox27.Controls.Add(Me.btnP300CalToolOffset)
        Me.GroupBox27.Controls.Add(Me.btnP300SetToolOffset)
        Me.GroupBox27.Location = New System.Drawing.Point(10, 18)
        Me.GroupBox27.Name = "GroupBox27"
        Me.GroupBox27.Size = New System.Drawing.Size(326, 65)
        Me.GroupBox27.TabIndex = 318
        Me.GroupBox27.TabStop = false
        Me.GroupBox27.Text = "Tool Offset"
        '
        'btnP300AddToolOffset
        '
        Me.btnP300AddToolOffset.Location = New System.Drawing.Point(86, 28)
        Me.btnP300AddToolOffset.Name = "btnP300AddToolOffset"
        Me.btnP300AddToolOffset.Size = New System.Drawing.Size(39, 27)
        Me.btnP300AddToolOffset.TabIndex = 302
        Me.btnP300AddToolOffset.Text = "Add"
        '
        'txtP300ToolOffsetSetValue
        '
        Me.txtP300ToolOffsetSetValue.ForeColor = System.Drawing.Color.Red
        Me.txtP300ToolOffsetSetValue.Location = New System.Drawing.Point(250, 28)
        Me.txtP300ToolOffsetSetValue.Name = "txtP300ToolOffsetSetValue"
        Me.txtP300ToolOffsetSetValue.Size = New System.Drawing.Size(67, 22)
        Me.txtP300ToolOffsetSetValue.TabIndex = 317
        Me.txtP300ToolOffsetSetValue.Text = "0"
        '
        'btnP300GetToolOffset
        '
        Me.btnP300GetToolOffset.Location = New System.Drawing.Point(0, 28)
        Me.btnP300GetToolOffset.Name = "btnP300GetToolOffset"
        Me.btnP300GetToolOffset.Size = New System.Drawing.Size(44, 27)
        Me.btnP300GetToolOffset.TabIndex = 300
        Me.btnP300GetToolOffset.Text = "Get"
        '
        'txtP300ToolOffset
        '
        Me.txtP300ToolOffset.Location = New System.Drawing.Point(173, 28)
        Me.txtP300ToolOffset.Name = "txtP300ToolOffset"
        Me.txtP300ToolOffset.ReadOnly = true
        Me.txtP300ToolOffset.Size = New System.Drawing.Size(67, 22)
        Me.txtP300ToolOffset.TabIndex = 316
        Me.txtP300ToolOffset.Text = "1"
        '
        'btnP300CalToolOffset
        '
        Me.btnP300CalToolOffset.Location = New System.Drawing.Point(125, 28)
        Me.btnP300CalToolOffset.Name = "btnP300CalToolOffset"
        Me.btnP300CalToolOffset.Size = New System.Drawing.Size(38, 27)
        Me.btnP300CalToolOffset.TabIndex = 303
        Me.btnP300CalToolOffset.Text = "Cal"
        '
        'btnP300SetToolOffset
        '
        Me.btnP300SetToolOffset.Location = New System.Drawing.Point(48, 28)
        Me.btnP300SetToolOffset.Name = "btnP300SetToolOffset"
        Me.btnP300SetToolOffset.Size = New System.Drawing.Size(38, 27)
        Me.btnP300SetToolOffset.TabIndex = 301
        Me.btnP300SetToolOffset.Text = "Set"
        '
        'GroupBox28
        '
        Me.GroupBox28.Controls.Add(Me.btnP300AddNoseRCompWear)
        Me.GroupBox28.Controls.Add(Me.txtP300NoseRCompWearSetValue)
        Me.GroupBox28.Controls.Add(Me.btnP300GetNoseRCompWear)
        Me.GroupBox28.Controls.Add(Me.txtP300NoseRCompWear)
        Me.GroupBox28.Controls.Add(Me.btnP300CalNoseRCompWear)
        Me.GroupBox28.Controls.Add(Me.btnP300SetNoseRCompWear)
        Me.GroupBox28.Location = New System.Drawing.Point(10, 83)
        Me.GroupBox28.Name = "GroupBox28"
        Me.GroupBox28.Size = New System.Drawing.Size(326, 65)
        Me.GroupBox28.TabIndex = 321
        Me.GroupBox28.TabStop = false
        Me.GroupBox28.Text = "Cutter Radius Wear Offset"
        '
        'btnP300AddNoseRCompWear
        '
        Me.btnP300AddNoseRCompWear.Location = New System.Drawing.Point(86, 28)
        Me.btnP300AddNoseRCompWear.Name = "btnP300AddNoseRCompWear"
        Me.btnP300AddNoseRCompWear.Size = New System.Drawing.Size(39, 27)
        Me.btnP300AddNoseRCompWear.TabIndex = 302
        Me.btnP300AddNoseRCompWear.Text = "Add"
        '
        'txtP300NoseRCompWearSetValue
        '
        Me.txtP300NoseRCompWearSetValue.ForeColor = System.Drawing.Color.Red
        Me.txtP300NoseRCompWearSetValue.Location = New System.Drawing.Point(250, 28)
        Me.txtP300NoseRCompWearSetValue.Name = "txtP300NoseRCompWearSetValue"
        Me.txtP300NoseRCompWearSetValue.Size = New System.Drawing.Size(67, 22)
        Me.txtP300NoseRCompWearSetValue.TabIndex = 317
        Me.txtP300NoseRCompWearSetValue.Text = "0"
        '
        'btnP300GetNoseRCompWear
        '
        Me.btnP300GetNoseRCompWear.Location = New System.Drawing.Point(0, 28)
        Me.btnP300GetNoseRCompWear.Name = "btnP300GetNoseRCompWear"
        Me.btnP300GetNoseRCompWear.Size = New System.Drawing.Size(44, 27)
        Me.btnP300GetNoseRCompWear.TabIndex = 300
        Me.btnP300GetNoseRCompWear.Text = "Get"
        '
        'txtP300NoseRCompWear
        '
        Me.txtP300NoseRCompWear.Location = New System.Drawing.Point(173, 28)
        Me.txtP300NoseRCompWear.Name = "txtP300NoseRCompWear"
        Me.txtP300NoseRCompWear.ReadOnly = true
        Me.txtP300NoseRCompWear.Size = New System.Drawing.Size(67, 22)
        Me.txtP300NoseRCompWear.TabIndex = 316
        Me.txtP300NoseRCompWear.Text = "1"
        '
        'btnP300CalNoseRCompWear
        '
        Me.btnP300CalNoseRCompWear.Location = New System.Drawing.Point(125, 28)
        Me.btnP300CalNoseRCompWear.Name = "btnP300CalNoseRCompWear"
        Me.btnP300CalNoseRCompWear.Size = New System.Drawing.Size(38, 27)
        Me.btnP300CalNoseRCompWear.TabIndex = 303
        Me.btnP300CalNoseRCompWear.Text = "Cal"
        '
        'btnP300SetNoseRCompWear
        '
        Me.btnP300SetNoseRCompWear.Location = New System.Drawing.Point(48, 28)
        Me.btnP300SetNoseRCompWear.Name = "btnP300SetNoseRCompWear"
        Me.btnP300SetNoseRCompWear.Size = New System.Drawing.Size(38, 27)
        Me.btnP300SetNoseRCompWear.TabIndex = 301
        Me.btnP300SetNoseRCompWear.Text = "Set"
        '
        'GroupBox31
        '
        Me.GroupBox31.Controls.Add(Me.btnP300AddToolWear)
        Me.GroupBox31.Controls.Add(Me.txtP300ToolWearSetValue)
        Me.GroupBox31.Controls.Add(Me.btnP300GetToolWear)
        Me.GroupBox31.Controls.Add(Me.txtP300ToolWear)
        Me.GroupBox31.Controls.Add(Me.btnP300SetToolWear)
        Me.GroupBox31.Location = New System.Drawing.Point(336, 18)
        Me.GroupBox31.Name = "GroupBox31"
        Me.GroupBox31.Size = New System.Drawing.Size(298, 65)
        Me.GroupBox31.TabIndex = 322
        Me.GroupBox31.TabStop = false
        Me.GroupBox31.Text = "Tool Wear Offset"
        '
        'btnP300AddToolWear
        '
        Me.btnP300AddToolWear.Location = New System.Drawing.Point(86, 28)
        Me.btnP300AddToolWear.Name = "btnP300AddToolWear"
        Me.btnP300AddToolWear.Size = New System.Drawing.Size(39, 27)
        Me.btnP300AddToolWear.TabIndex = 302
        Me.btnP300AddToolWear.Text = "Add"
        '
        'txtP300ToolWearSetValue
        '
        Me.txtP300ToolWearSetValue.ForeColor = System.Drawing.Color.Red
        Me.txtP300ToolWearSetValue.Location = New System.Drawing.Point(211, 28)
        Me.txtP300ToolWearSetValue.Name = "txtP300ToolWearSetValue"
        Me.txtP300ToolWearSetValue.Size = New System.Drawing.Size(77, 22)
        Me.txtP300ToolWearSetValue.TabIndex = 317
        Me.txtP300ToolWearSetValue.Text = "0"
        '
        'btnP300GetToolWear
        '
        Me.btnP300GetToolWear.Location = New System.Drawing.Point(6, 28)
        Me.btnP300GetToolWear.Name = "btnP300GetToolWear"
        Me.btnP300GetToolWear.Size = New System.Drawing.Size(40, 27)
        Me.btnP300GetToolWear.TabIndex = 300
        Me.btnP300GetToolWear.Text = "Get"
        '
        'txtP300ToolWear
        '
        Me.txtP300ToolWear.Location = New System.Drawing.Point(134, 28)
        Me.txtP300ToolWear.Name = "txtP300ToolWear"
        Me.txtP300ToolWear.ReadOnly = true
        Me.txtP300ToolWear.Size = New System.Drawing.Size(68, 22)
        Me.txtP300ToolWear.TabIndex = 316
        Me.txtP300ToolWear.Text = "1"
        '
        'btnP300SetToolWear
        '
        Me.btnP300SetToolWear.Location = New System.Drawing.Point(48, 28)
        Me.btnP300SetToolWear.Name = "btnP300SetToolWear"
        Me.btnP300SetToolWear.Size = New System.Drawing.Size(38, 27)
        Me.btnP300SetToolWear.TabIndex = 301
        Me.btnP300SetToolWear.Text = "Set"
        '
        'GroupBox32
        '
        Me.GroupBox32.Controls.Add(Me.btnP300AddNoseRComp)
        Me.GroupBox32.Controls.Add(Me.txtP300NoseRCompSetValue)
        Me.GroupBox32.Controls.Add(Me.btnP300GetNoseRComp)
        Me.GroupBox32.Controls.Add(Me.txtP300NoseRComp)
        Me.GroupBox32.Controls.Add(Me.btnP300SetNoseRComp)
        Me.GroupBox32.Location = New System.Drawing.Point(336, 83)
        Me.GroupBox32.Name = "GroupBox32"
        Me.GroupBox32.Size = New System.Drawing.Size(298, 65)
        Me.GroupBox32.TabIndex = 319
        Me.GroupBox32.TabStop = false
        Me.GroupBox32.Text = "Cutter Radius Offset"
        '
        'btnP300AddNoseRComp
        '
        Me.btnP300AddNoseRComp.Location = New System.Drawing.Point(86, 28)
        Me.btnP300AddNoseRComp.Name = "btnP300AddNoseRComp"
        Me.btnP300AddNoseRComp.Size = New System.Drawing.Size(39, 27)
        Me.btnP300AddNoseRComp.TabIndex = 302
        Me.btnP300AddNoseRComp.Text = "Add"
        '
        'txtP300NoseRCompSetValue
        '
        Me.txtP300NoseRCompSetValue.ForeColor = System.Drawing.Color.Red
        Me.txtP300NoseRCompSetValue.Location = New System.Drawing.Point(211, 28)
        Me.txtP300NoseRCompSetValue.Name = "txtP300NoseRCompSetValue"
        Me.txtP300NoseRCompSetValue.Size = New System.Drawing.Size(77, 22)
        Me.txtP300NoseRCompSetValue.TabIndex = 317
        Me.txtP300NoseRCompSetValue.Text = "0"
        '
        'btnP300GetNoseRComp
        '
        Me.btnP300GetNoseRComp.Location = New System.Drawing.Point(6, 28)
        Me.btnP300GetNoseRComp.Name = "btnP300GetNoseRComp"
        Me.btnP300GetNoseRComp.Size = New System.Drawing.Size(40, 27)
        Me.btnP300GetNoseRComp.TabIndex = 300
        Me.btnP300GetNoseRComp.Text = "Get"
        '
        'txtP300NoseRComp
        '
        Me.txtP300NoseRComp.Location = New System.Drawing.Point(134, 28)
        Me.txtP300NoseRComp.Name = "txtP300NoseRComp"
        Me.txtP300NoseRComp.ReadOnly = true
        Me.txtP300NoseRComp.Size = New System.Drawing.Size(68, 22)
        Me.txtP300NoseRComp.TabIndex = 316
        Me.txtP300NoseRComp.Text = "1"
        '
        'btnP300SetNoseRComp
        '
        Me.btnP300SetNoseRComp.Location = New System.Drawing.Point(48, 28)
        Me.btnP300SetNoseRComp.Name = "btnP300SetNoseRComp"
        Me.btnP300SetNoseRComp.Size = New System.Drawing.Size(38, 27)
        Me.btnP300SetNoseRComp.TabIndex = 301
        Me.btnP300SetNoseRComp.Text = "Set"
        '
        'GroupBox35
        '
        Me.GroupBox35.Controls.Add(Me.txtP300ToolLifeSetValue)
        Me.GroupBox35.Controls.Add(Me.btnP300GetToolLifeSet)
        Me.GroupBox35.Controls.Add(Me.txtP300ToolLifeSet)
        Me.GroupBox35.Controls.Add(Me.btnP300SetToolLifeSet)
        Me.GroupBox35.Location = New System.Drawing.Point(634, 18)
        Me.GroupBox35.Name = "GroupBox35"
        Me.GroupBox35.Size = New System.Drawing.Size(230, 65)
        Me.GroupBox35.TabIndex = 325
        Me.GroupBox35.TabStop = false
        Me.GroupBox35.Text = "Tool Life - SET"
        '
        'txtP300ToolLifeSetValue
        '
        Me.txtP300ToolLifeSetValue.ForeColor = System.Drawing.Color.Red
        Me.txtP300ToolLifeSetValue.Location = New System.Drawing.Point(163, 28)
        Me.txtP300ToolLifeSetValue.Name = "txtP300ToolLifeSetValue"
        Me.txtP300ToolLifeSetValue.Size = New System.Drawing.Size(58, 22)
        Me.txtP300ToolLifeSetValue.TabIndex = 317
        Me.txtP300ToolLifeSetValue.Text = "0"
        '
        'btnP300GetToolLifeSet
        '
        Me.btnP300GetToolLifeSet.Location = New System.Drawing.Point(6, 28)
        Me.btnP300GetToolLifeSet.Name = "btnP300GetToolLifeSet"
        Me.btnP300GetToolLifeSet.Size = New System.Drawing.Size(42, 27)
        Me.btnP300GetToolLifeSet.TabIndex = 300
        Me.btnP300GetToolLifeSet.Text = "Get"
        '
        'txtP300ToolLifeSet
        '
        Me.txtP300ToolLifeSet.Location = New System.Drawing.Point(96, 28)
        Me.txtP300ToolLifeSet.Name = "txtP300ToolLifeSet"
        Me.txtP300ToolLifeSet.ReadOnly = true
        Me.txtP300ToolLifeSet.Size = New System.Drawing.Size(58, 22)
        Me.txtP300ToolLifeSet.TabIndex = 316
        Me.txtP300ToolLifeSet.Text = "1"
        '
        'btnP300SetToolLifeSet
        '
        Me.btnP300SetToolLifeSet.Location = New System.Drawing.Point(48, 28)
        Me.btnP300SetToolLifeSet.Name = "btnP300SetToolLifeSet"
        Me.btnP300SetToolLifeSet.Size = New System.Drawing.Size(38, 27)
        Me.btnP300SetToolLifeSet.TabIndex = 301
        Me.btnP300SetToolLifeSet.Text = "Set"
        '
        'GroupBox36
        '
        Me.GroupBox36.Controls.Add(Me.txtP300ToolLifeLeftValue)
        Me.GroupBox36.Controls.Add(Me.btnP300GetToolLifeLeft)
        Me.GroupBox36.Controls.Add(Me.txtP300ToolLifeLeft)
        Me.GroupBox36.Controls.Add(Me.btnP300SetToolLifeLeft)
        Me.GroupBox36.Location = New System.Drawing.Point(634, 83)
        Me.GroupBox36.Name = "GroupBox36"
        Me.GroupBox36.Size = New System.Drawing.Size(230, 65)
        Me.GroupBox36.TabIndex = 326
        Me.GroupBox36.TabStop = false
        Me.GroupBox36.Text = "Tool Life - LEFT"
        '
        'txtP300ToolLifeLeftValue
        '
        Me.txtP300ToolLifeLeftValue.ForeColor = System.Drawing.Color.Red
        Me.txtP300ToolLifeLeftValue.Location = New System.Drawing.Point(163, 28)
        Me.txtP300ToolLifeLeftValue.Name = "txtP300ToolLifeLeftValue"
        Me.txtP300ToolLifeLeftValue.Size = New System.Drawing.Size(58, 22)
        Me.txtP300ToolLifeLeftValue.TabIndex = 317
        Me.txtP300ToolLifeLeftValue.Text = "0"
        '
        'btnP300GetToolLifeLeft
        '
        Me.btnP300GetToolLifeLeft.Location = New System.Drawing.Point(6, 28)
        Me.btnP300GetToolLifeLeft.Name = "btnP300GetToolLifeLeft"
        Me.btnP300GetToolLifeLeft.Size = New System.Drawing.Size(42, 27)
        Me.btnP300GetToolLifeLeft.TabIndex = 300
        Me.btnP300GetToolLifeLeft.Text = "Get"
        '
        'txtP300ToolLifeLeft
        '
        Me.txtP300ToolLifeLeft.Location = New System.Drawing.Point(96, 28)
        Me.txtP300ToolLifeLeft.Name = "txtP300ToolLifeLeft"
        Me.txtP300ToolLifeLeft.ReadOnly = true
        Me.txtP300ToolLifeLeft.Size = New System.Drawing.Size(58, 22)
        Me.txtP300ToolLifeLeft.TabIndex = 316
        Me.txtP300ToolLifeLeft.Text = "1"
        '
        'btnP300SetToolLifeLeft
        '
        Me.btnP300SetToolLifeLeft.Location = New System.Drawing.Point(48, 28)
        Me.btnP300SetToolLifeLeft.Name = "btnP300SetToolLifeLeft"
        Me.btnP300SetToolLifeLeft.Size = New System.Drawing.Size(38, 27)
        Me.btnP300SetToolLifeLeft.TabIndex = 301
        Me.btnP300SetToolLifeLeft.Text = "Set"
        '
        'txtP300ToolGaugeStatusValue
        '
        Me.txtP300ToolGaugeStatusValue.Controls.Add(Me.cboP300ToolLifeStatus)
        Me.txtP300ToolGaugeStatusValue.Controls.Add(Me.btnP300GetToolLifeStatus)
        Me.txtP300ToolGaugeStatusValue.Controls.Add(Me.txtP300ToolLifeStatus)
        Me.txtP300ToolGaugeStatusValue.Controls.Add(Me.btnP300SetToolLifeStatus)
        Me.txtP300ToolGaugeStatusValue.Location = New System.Drawing.Point(10, 148)
        Me.txtP300ToolGaugeStatusValue.Name = "txtP300ToolGaugeStatusValue"
        Me.txtP300ToolGaugeStatusValue.Size = New System.Drawing.Size(240, 64)
        Me.txtP300ToolGaugeStatusValue.TabIndex = 327
        Me.txtP300ToolGaugeStatusValue.TabStop = false
        Me.txtP300ToolGaugeStatusValue.Text = "Tool Life STATUS"
        '
        'cboP300ToolLifeStatus
        '
        Me.cboP300ToolLifeStatus.Location = New System.Drawing.Point(144, 28)
        Me.cboP300ToolLifeStatus.Name = "cboP300ToolLifeStatus"
        Me.cboP300ToolLifeStatus.Size = New System.Drawing.Size(86, 24)
        Me.cboP300ToolLifeStatus.TabIndex = 366
        '
        'btnP300GetToolLifeStatus
        '
        Me.btnP300GetToolLifeStatus.Location = New System.Drawing.Point(0, 28)
        Me.btnP300GetToolLifeStatus.Name = "btnP300GetToolLifeStatus"
        Me.btnP300GetToolLifeStatus.Size = New System.Drawing.Size(48, 27)
        Me.btnP300GetToolLifeStatus.TabIndex = 300
        Me.btnP300GetToolLifeStatus.Text = "Get"
        '
        'txtP300ToolLifeStatus
        '
        Me.txtP300ToolLifeStatus.Location = New System.Drawing.Point(96, 28)
        Me.txtP300ToolLifeStatus.Name = "txtP300ToolLifeStatus"
        Me.txtP300ToolLifeStatus.ReadOnly = true
        Me.txtP300ToolLifeStatus.Size = New System.Drawing.Size(38, 22)
        Me.txtP300ToolLifeStatus.TabIndex = 316
        Me.txtP300ToolLifeStatus.Text = "1"
        '
        'btnP300SetToolLifeStatus
        '
        Me.btnP300SetToolLifeStatus.Location = New System.Drawing.Point(48, 28)
        Me.btnP300SetToolLifeStatus.Name = "btnP300SetToolLifeStatus"
        Me.btnP300SetToolLifeStatus.Size = New System.Drawing.Size(38, 27)
        Me.btnP300SetToolLifeStatus.TabIndex = 301
        Me.btnP300SetToolLifeStatus.Text = "Set"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 19)
        Me.Label2.TabIndex = 358
        Me.Label2.Text = "Group No."
        '
        'txtP300GroupNumber
        '
        Me.txtP300GroupNumber.Location = New System.Drawing.Point(96, 9)
        Me.txtP300GroupNumber.Name = "txtP300GroupNumber"
        Me.txtP300GroupNumber.Size = New System.Drawing.Size(58, 22)
        Me.txtP300GroupNumber.TabIndex = 357
        Me.txtP300GroupNumber.Text = "1"
        '
        'btnP300ToolSetDataUnit
        '
        Me.btnP300ToolSetDataUnit.Location = New System.Drawing.Point(854, 9)
        Me.btnP300ToolSetDataUnit.Name = "btnP300ToolSetDataUnit"
        Me.btnP300ToolSetDataUnit.Size = New System.Drawing.Size(68, 28)
        Me.btnP300ToolSetDataUnit.TabIndex = 347
        Me.btnP300ToolSetDataUnit.Text = "SET"
        '
        'Label342
        '
        Me.Label342.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label342.Location = New System.Drawing.Point(586, 9)
        Me.Label342.Name = "Label342"
        Me.Label342.Size = New System.Drawing.Size(96, 19)
        Me.Label342.TabIndex = 346
        Me.Label342.Text = "Data Unit :"
        '
        'cboP300ToolsDataUnit
        '
        Me.cboP300ToolsDataUnit.Location = New System.Drawing.Point(691, 9)
        Me.cboP300ToolsDataUnit.Name = "cboP300ToolsDataUnit"
        Me.cboP300ToolsDataUnit.Size = New System.Drawing.Size(145, 24)
        Me.cboP300ToolsDataUnit.TabIndex = 345
        '
        'Label340
        '
        Me.Label340.Location = New System.Drawing.Point(173, 9)
        Me.Label340.Name = "Label340"
        Me.Label340.Size = New System.Drawing.Size(96, 19)
        Me.Label340.TabIndex = 343
        Me.Label340.Text = "Tool/Station"
        '
        'txtP300ToolNumber
        '
        Me.txtP300ToolNumber.Location = New System.Drawing.Point(278, 9)
        Me.txtP300ToolNumber.Name = "txtP300ToolNumber"
        Me.txtP300ToolNumber.Size = New System.Drawing.Size(68, 22)
        Me.txtP300ToolNumber.TabIndex = 342
        Me.txtP300ToolNumber.Text = "1"
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
        Me.tab_atc.Location = New System.Drawing.Point(4, 25)
        Me.tab_atc.Name = "tab_atc"
        Me.tab_atc.Size = New System.Drawing.Size(1019, 498)
        Me.tab_atc.TabIndex = 0
        Me.tab_atc.Text = "ATC"
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.btnGetPalletID)
        Me.GroupBox13.Controls.Add(Me.txtPalletID)
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
        Me.GroupBox13.Location = New System.Drawing.Point(384, 175)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(538, 257)
        Me.GroupBox13.TabIndex = 177
        Me.GroupBox13.TabStop = false
        '
        'btnGetPalletID
        '
        Me.btnGetPalletID.Location = New System.Drawing.Point(10, 190)
        Me.btnGetPalletID.Name = "btnGetPalletID"
        Me.btnGetPalletID.Size = New System.Drawing.Size(135, 27)
        Me.btnGetPalletID.TabIndex = 180
        Me.btnGetPalletID.Text = "Get Pallet ID"
        '
        'txtPalletID
        '
        Me.txtPalletID.Location = New System.Drawing.Point(163, 192)
        Me.txtPalletID.Name = "txtPalletID"
        Me.txtPalletID.Size = New System.Drawing.Size(77, 22)
        Me.txtPalletID.TabIndex = 179
        Me.txtPalletID.Tag = ""
        Me.txtPalletID.Text = "0"
        '
        'cmdSetReturnPot
        '
        Me.cmdSetReturnPot.Location = New System.Drawing.Point(298, 138)
        Me.cmdSetReturnPot.Name = "cmdSetReturnPot"
        Me.cmdSetReturnPot.Size = New System.Drawing.Size(124, 28)
        Me.cmdSetReturnPot.TabIndex = 178
        Me.cmdSetReturnPot.Text = "Set Return Pot"
        '
        'cmdSetNextTool
        '
        Me.cmdSetNextTool.Location = New System.Drawing.Point(163, 138)
        Me.cmdSetNextTool.Name = "cmdSetNextTool"
        Me.cmdSetNextTool.Size = New System.Drawing.Size(125, 28)
        Me.cmdSetNextTool.TabIndex = 177
        Me.cmdSetNextTool.Text = "Set Next Tool"
        '
        'atcComboToolAttribute
        '
        Me.atcComboToolAttribute.Location = New System.Drawing.Point(355, 28)
        Me.atcComboToolAttribute.Name = "atcComboToolAttribute"
        Me.atcComboToolAttribute.Size = New System.Drawing.Size(115, 24)
        Me.atcComboToolAttribute.TabIndex = 164
        '
        'Label138
        '
        Me.Label138.Location = New System.Drawing.Point(250, 28)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(96, 18)
        Me.Label138.TabIndex = 171
        Me.Label138.Text = "Tool Attribute:"
        '
        'atcButtonCancelTool
        '
        Me.atcButtonCancelTool.Location = New System.Drawing.Point(432, 138)
        Me.atcButtonCancelTool.Name = "atcButtonCancelTool"
        Me.atcButtonCancelTool.Size = New System.Drawing.Size(96, 28)
        Me.atcButtonCancelTool.TabIndex = 175
        Me.atcButtonCancelTool.Text = "Cancel Tool"
        '
        'atcCMDToolNumber
        '
        Me.atcCMDToolNumber.Location = New System.Drawing.Point(125, 65)
        Me.atcCMDToolNumber.Name = "atcCMDToolNumber"
        Me.atcCMDToolNumber.Size = New System.Drawing.Size(77, 22)
        Me.atcCMDToolNumber.TabIndex = 165
        Me.atcCMDToolNumber.Tag = ""
        Me.atcCMDToolNumber.Text = "1"
        '
        'Label136
        '
        Me.Label136.Location = New System.Drawing.Point(259, 65)
        Me.Label136.Name = "Label136"
        Me.Label136.Size = New System.Drawing.Size(77, 18)
        Me.Label136.TabIndex = 168
        Me.Label136.Text = "Pot Number"
        '
        'atcCMDPotNumber
        '
        Me.atcCMDPotNumber.Location = New System.Drawing.Point(355, 65)
        Me.atcCMDPotNumber.Name = "atcCMDPotNumber"
        Me.atcCMDPotNumber.Size = New System.Drawing.Size(77, 22)
        Me.atcCMDPotNumber.TabIndex = 167
        Me.atcCMDPotNumber.Text = "1"
        '
        'Label135
        '
        Me.Label135.Location = New System.Drawing.Point(19, 65)
        Me.Label135.Name = "Label135"
        Me.Label135.Size = New System.Drawing.Size(87, 18)
        Me.Label135.TabIndex = 166
        Me.Label135.Text = "Tool Number"
        '
        'cmdSetActualTool
        '
        Me.cmdSetActualTool.Location = New System.Drawing.Point(10, 138)
        Me.cmdSetActualTool.Name = "cmdSetActualTool"
        Me.cmdSetActualTool.Size = New System.Drawing.Size(135, 28)
        Me.cmdSetActualTool.TabIndex = 176
        Me.cmdSetActualTool.Text = "Set Actual Tool"
        '
        'atcButtonUnRegister
        '
        Me.atcButtonUnRegister.Location = New System.Drawing.Point(346, 102)
        Me.atcButtonUnRegister.Name = "atcButtonUnRegister"
        Me.atcButtonUnRegister.Size = New System.Drawing.Size(124, 27)
        Me.atcButtonUnRegister.TabIndex = 174
        Me.atcButtonUnRegister.Text = "Unregister Tool"
        '
        'atcButtonRegisterAttribute
        '
        Me.atcButtonRegisterAttribute.Location = New System.Drawing.Point(144, 102)
        Me.atcButtonRegisterAttribute.Name = "atcButtonRegisterAttribute"
        Me.atcButtonRegisterAttribute.Size = New System.Drawing.Size(192, 27)
        Me.atcButtonRegisterAttribute.TabIndex = 173
        Me.atcButtonRegisterAttribute.Text = "Register with Tool Attribute"
        '
        'atcButtonRegister
        '
        Me.atcButtonRegister.Location = New System.Drawing.Point(10, 102)
        Me.atcButtonRegister.Name = "atcButtonRegister"
        Me.atcButtonRegister.Size = New System.Drawing.Size(115, 27)
        Me.atcButtonRegister.TabIndex = 172
        Me.atcButtonRegister.Text = "Register Tool"
        '
        'atcSetLargeToolMemo
        '
        Me.atcSetLargeToolMemo.Location = New System.Drawing.Point(278, 222)
        Me.atcSetLargeToolMemo.Name = "atcSetLargeToolMemo"
        Me.atcSetLargeToolMemo.Size = New System.Drawing.Size(53, 27)
        Me.atcSetLargeToolMemo.TabIndex = 15
        Me.atcSetLargeToolMemo.Text = "Set"
        '
        'atcSetHeavyToolMemo
        '
        Me.atcSetHeavyToolMemo.Location = New System.Drawing.Point(278, 185)
        Me.atcSetHeavyToolMemo.Name = "atcSetHeavyToolMemo"
        Me.atcSetHeavyToolMemo.Size = New System.Drawing.Size(53, 27)
        Me.atcSetHeavyToolMemo.TabIndex = 14
        Me.atcSetHeavyToolMemo.Text = "Set"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(374, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 47)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Values with no parameters :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(19, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 18)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Large Tool Memo"
        '
        'largeToolMemo
        '
        Me.largeToolMemo.Location = New System.Drawing.Point(144, 222)
        Me.largeToolMemo.Name = "largeToolMemo"
        Me.largeToolMemo.Size = New System.Drawing.Size(125, 22)
        Me.largeToolMemo.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(19, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 18)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Heavy Tool Memo"
        '
        'heavyToolMemo
        '
        Me.heavyToolMemo.Location = New System.Drawing.Point(144, 185)
        Me.heavyToolMemo.Name = "heavyToolMemo"
        Me.heavyToolMemo.Size = New System.Drawing.Size(125, 22)
        Me.heavyToolMemo.TabIndex = 9
        '
        'atcUpdateButton
        '
        Me.atcUpdateButton.Location = New System.Drawing.Point(384, 74)
        Me.atcUpdateButton.Name = "atcUpdateButton"
        Me.atcUpdateButton.Size = New System.Drawing.Size(86, 28)
        Me.atcUpdateButton.TabIndex = 4
        Me.atcUpdateButton.Text = "Update"
        '
        'atcStatus
        '
        Me.atcStatus.Location = New System.Drawing.Point(490, 18)
        Me.atcStatus.Multiline = true
        Me.atcStatus.Name = "atcStatus"
        Me.atcStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.atcStatus.Size = New System.Drawing.Size(432, 148)
        Me.atcStatus.TabIndex = 3
        '
        'atcPotNumberButton
        '
        Me.atcPotNumberButton.Location = New System.Drawing.Point(192, 28)
        Me.atcPotNumberButton.Name = "atcPotNumberButton"
        Me.atcPotNumberButton.Size = New System.Drawing.Size(119, 27)
        Me.atcPotNumberButton.TabIndex = 2
        Me.atcPotNumberButton.Text = "Get Tool Info"
        '
        'pot_number_lbl
        '
        Me.pot_number_lbl.Location = New System.Drawing.Point(19, 28)
        Me.pot_number_lbl.Name = "pot_number_lbl"
        Me.pot_number_lbl.Size = New System.Drawing.Size(77, 18)
        Me.pot_number_lbl.TabIndex = 1
        Me.pot_number_lbl.Text = "Pot Number"
        '
        'potNumber
        '
        Me.potNumber.Location = New System.Drawing.Point(96, 28)
        Me.potNumber.Name = "potNumber"
        Me.potNumber.Size = New System.Drawing.Size(77, 22)
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
        Me.Panel1.Location = New System.Drawing.Point(10, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(355, 120)
        Me.Panel1.TabIndex = 5
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(10, 83)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(105, 19)
        Me.Label38.TabIndex = 18
        Me.Label38.Text = "Tool Kind"
        '
        'potToolKind
        '
        Me.potToolKind.Location = New System.Drawing.Point(134, 83)
        Me.potToolKind.Name = "potToolKind"
        Me.potToolKind.Size = New System.Drawing.Size(106, 22)
        Me.potToolKind.TabIndex = 17
        '
        'potToolNumber
        '
        Me.potToolNumber.Location = New System.Drawing.Point(134, 55)
        Me.potToolNumber.Name = "potToolNumber"
        Me.potToolNumber.Size = New System.Drawing.Size(106, 22)
        Me.potToolNumber.TabIndex = 16
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(10, 55)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(105, 19)
        Me.Label37.TabIndex = 16
        Me.Label37.Text = "Tool Number"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.getMemoButton)
        Me.Panel2.Location = New System.Drawing.Point(10, 138)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(355, 120)
        Me.Panel2.TabIndex = 6
        '
        'getMemoButton
        '
        Me.getMemoButton.Location = New System.Drawing.Point(10, 9)
        Me.getMemoButton.Name = "getMemoButton"
        Me.getMemoButton.Size = New System.Drawing.Size(86, 28)
        Me.getMemoButton.TabIndex = 8
        Me.getMemoButton.Text = "Get Memo"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(19, 277)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(125, 18)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Magazine Number"
        '
        'magazineNumber
        '
        Me.magazineNumber.Location = New System.Drawing.Point(144, 277)
        Me.magazineNumber.Name = "magazineNumber"
        Me.magazineNumber.Size = New System.Drawing.Size(77, 22)
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
        Me.Panel3.Location = New System.Drawing.Point(10, 268)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(355, 166)
        Me.Panel3.TabIndex = 10
        '
        'atcMagazinePosition
        '
        Me.atcMagazinePosition.Location = New System.Drawing.Point(154, 129)
        Me.atcMagazinePosition.Name = "atcMagazinePosition"
        Me.atcMagazinePosition.Size = New System.Drawing.Size(115, 22)
        Me.atcMagazinePosition.TabIndex = 23
        '
        'Label114
        '
        Me.Label114.Location = New System.Drawing.Point(10, 129)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(124, 19)
        Me.Label114.TabIndex = 22
        Me.Label114.Text = "Magazine Position :"
        '
        'endingPot
        '
        Me.endingPot.Location = New System.Drawing.Point(154, 102)
        Me.endingPot.Name = "endingPot"
        Me.endingPot.Size = New System.Drawing.Size(115, 22)
        Me.endingPot.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(10, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 18)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Starting Pot Number"
        '
        'startingPot
        '
        Me.startingPot.Location = New System.Drawing.Point(154, 74)
        Me.startingPot.Name = "startingPot"
        Me.startingPot.Size = New System.Drawing.Size(115, 22)
        Me.startingPot.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(10, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 19)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Number of Pots"
        '
        'getMagazineButton
        '
        Me.getMagazineButton.Location = New System.Drawing.Point(221, 9)
        Me.getMagazineButton.Name = "getMagazineButton"
        Me.getMagazineButton.Size = New System.Drawing.Size(125, 28)
        Me.getMagazineButton.TabIndex = 16
        Me.getMagazineButton.Text = "Get Magazine"
        '
        'numberOfPots
        '
        Me.numberOfPots.Location = New System.Drawing.Point(154, 46)
        Me.numberOfPots.Name = "numberOfPots"
        Me.numberOfPots.Size = New System.Drawing.Size(115, 22)
        Me.numberOfPots.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(10, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 18)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Ending Pot Number"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(211, 277)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(87, 28)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Get Memo"
        '
        'tab_P300ATC
        '
        Me.tab_P300ATC.Controls.Add(Me.GroupBox44)
        Me.tab_P300ATC.Controls.Add(Me.GroupBox33)
        Me.tab_P300ATC.Location = New System.Drawing.Point(4, 25)
        Me.tab_P300ATC.Name = "tab_P300ATC"
        Me.tab_P300ATC.Size = New System.Drawing.Size(1019, 498)
        Me.tab_P300ATC.TabIndex = 26
        Me.tab_P300ATC.Text = "P300 ATC"
        '
        'GroupBox44
        '
        Me.GroupBox44.Controls.Add(Me.chkP300TLDataOverwrite)
        Me.GroupBox44.Controls.Add(Me.btnP300TLDataOutput)
        Me.GroupBox44.Controls.Add(Me.btnP300TLDataInput)
        Me.GroupBox44.Controls.Add(Me.Label393)
        Me.GroupBox44.Controls.Add(Me.txtLoadSaveToolNumber)
        Me.GroupBox44.Controls.Add(Me.Label399)
        Me.GroupBox44.Controls.Add(Me.txtLoadSaveFolderPath)
        Me.GroupBox44.Location = New System.Drawing.Point(10, 228)
        Me.GroupBox44.Name = "GroupBox44"
        Me.GroupBox44.Size = New System.Drawing.Size(401, 143)
        Me.GroupBox44.TabIndex = 418
        Me.GroupBox44.TabStop = false
        Me.GroupBox44.Text = "Load/Save Tool Data"
        '
        'chkP300TLDataOverwrite
        '
        Me.chkP300TLDataOverwrite.AutoSize = true
        Me.chkP300TLDataOverwrite.Location = New System.Drawing.Point(163, 79)
        Me.chkP300TLDataOverwrite.Name = "chkP300TLDataOverwrite"
        Me.chkP300TLDataOverwrite.Size = New System.Drawing.Size(156, 21)
        Me.chkP300TLDataOverwrite.TabIndex = 410
        Me.chkP300TLDataOverwrite.Text = "Overwrite Tool Data"
        Me.chkP300TLDataOverwrite.UseVisualStyleBackColor = true
        '
        'btnP300TLDataOutput
        '
        Me.btnP300TLDataOutput.Location = New System.Drawing.Point(6, 108)
        Me.btnP300TLDataOutput.Name = "btnP300TLDataOutput"
        Me.btnP300TLDataOutput.Size = New System.Drawing.Size(141, 27)
        Me.btnP300TLDataOutput.TabIndex = 409
        Me.btnP300TLDataOutput.Text = "TL-DATA OUPTUT"
        '
        'btnP300TLDataInput
        '
        Me.btnP300TLDataInput.Location = New System.Drawing.Point(6, 75)
        Me.btnP300TLDataInput.Name = "btnP300TLDataInput"
        Me.btnP300TLDataInput.Size = New System.Drawing.Size(144, 27)
        Me.btnP300TLDataInput.TabIndex = 408
        Me.btnP300TLDataInput.Text = "TL-DATA INPUT"
        '
        'Label393
        '
        Me.Label393.Location = New System.Drawing.Point(8, 19)
        Me.Label393.Name = "Label393"
        Me.Label393.Size = New System.Drawing.Size(76, 19)
        Me.Label393.TabIndex = 367
        Me.Label393.Text = "Tool No."
        '
        'txtLoadSaveToolNumber
        '
        Me.txtLoadSaveToolNumber.Location = New System.Drawing.Point(8, 47)
        Me.txtLoadSaveToolNumber.Name = "txtLoadSaveToolNumber"
        Me.txtLoadSaveToolNumber.Size = New System.Drawing.Size(144, 22)
        Me.txtLoadSaveToolNumber.TabIndex = 366
        Me.txtLoadSaveToolNumber.Text = "1"
        '
        'Label399
        '
        Me.Label399.Location = New System.Drawing.Point(160, 19)
        Me.Label399.Name = "Label399"
        Me.Label399.Size = New System.Drawing.Size(148, 19)
        Me.Label399.TabIndex = 365
        Me.Label399.Text = "Folder Path:"
        '
        'txtLoadSaveFolderPath
        '
        Me.txtLoadSaveFolderPath.Location = New System.Drawing.Point(160, 47)
        Me.txtLoadSaveFolderPath.Name = "txtLoadSaveFolderPath"
        Me.txtLoadSaveFolderPath.Size = New System.Drawing.Size(232, 22)
        Me.txtLoadSaveFolderPath.TabIndex = 364
        Me.txtLoadSaveFolderPath.Text = "D:\MD1\MY-TOOL-DATA"
        '
        'GroupBox33
        '
        Me.GroupBox33.Controls.Add(Me.btnAttachTool)
        Me.GroupBox33.Controls.Add(Me.btnP300AttachActualTool)
        Me.GroupBox33.Controls.Add(Me.txtP300MaxToolSpeed)
        Me.GroupBox33.Controls.Add(Me.Label313)
        Me.GroupBox33.Controls.Add(Me.chkP300ManualAttachmentToolATCType)
        Me.GroupBox33.Controls.Add(Me.chkP300ThroughCoolantToolType)
        Me.GroupBox33.Controls.Add(Me.cboP300WeightKind)
        Me.GroupBox33.Controls.Add(Me.Label312)
        Me.GroupBox33.Controls.Add(Me.cboP300HeightKind)
        Me.GroupBox33.Controls.Add(Me.Label311)
        Me.GroupBox33.Controls.Add(Me.cboP300DiameterKind)
        Me.GroupBox33.Controls.Add(Me.Label310)
        Me.GroupBox33.Controls.Add(Me.btnP300DeleteTool)
        Me.GroupBox33.Controls.Add(Me.btnAttachNextTool)
        Me.GroupBox33.Controls.Add(Me.cboP300ToolKind2)
        Me.GroupBox33.Controls.Add(Me.Label33)
        Me.GroupBox33.Controls.Add(Me.txtP300ATCToolNo)
        Me.GroupBox33.Controls.Add(Me.Label34)
        Me.GroupBox33.Controls.Add(Me.txtP300ATCPotNo)
        Me.GroupBox33.Controls.Add(Me.Label137)
        Me.GroupBox33.Controls.Add(Me.btnP300UnregisterTool)
        Me.GroupBox33.Controls.Add(Me.btbP300RegisterTool)
        Me.GroupBox33.Location = New System.Drawing.Point(10, 9)
        Me.GroupBox33.Name = "GroupBox33"
        Me.GroupBox33.Size = New System.Drawing.Size(912, 213)
        Me.GroupBox33.TabIndex = 178
        Me.GroupBox33.TabStop = false
        '
        'btnAttachTool
        '
        Me.btnAttachTool.Location = New System.Drawing.Point(192, 138)
        Me.btnAttachTool.Name = "btnAttachTool"
        Me.btnAttachTool.Size = New System.Drawing.Size(144, 28)
        Me.btnAttachTool.TabIndex = 194
        Me.btnAttachTool.Text = "Attach Tool"
        '
        'btnP300AttachActualTool
        '
        Me.btnP300AttachActualTool.Location = New System.Drawing.Point(346, 138)
        Me.btnP300AttachActualTool.Name = "btnP300AttachActualTool"
        Me.btnP300AttachActualTool.Size = New System.Drawing.Size(144, 28)
        Me.btnP300AttachActualTool.TabIndex = 190
        Me.btnP300AttachActualTool.Text = "Set Actual Tool"
        '
        'txtP300MaxToolSpeed
        '
        Me.txtP300MaxToolSpeed.Location = New System.Drawing.Point(154, 102)
        Me.txtP300MaxToolSpeed.Name = "txtP300MaxToolSpeed"
        Me.txtP300MaxToolSpeed.Size = New System.Drawing.Size(76, 22)
        Me.txtP300MaxToolSpeed.TabIndex = 188
        Me.txtP300MaxToolSpeed.Tag = ""
        Me.txtP300MaxToolSpeed.Text = "0"
        '
        'Label313
        '
        Me.Label313.Location = New System.Drawing.Point(19, 102)
        Me.Label313.Name = "Label313"
        Me.Label313.Size = New System.Drawing.Size(106, 18)
        Me.Label313.TabIndex = 189
        Me.Label313.Text = "Max Tool Speed"
        '
        'chkP300ManualAttachmentToolATCType
        '
        Me.chkP300ManualAttachmentToolATCType.Location = New System.Drawing.Point(662, 55)
        Me.chkP300ManualAttachmentToolATCType.Name = "chkP300ManualAttachmentToolATCType"
        Me.chkP300ManualAttachmentToolATCType.Size = New System.Drawing.Size(240, 28)
        Me.chkP300ManualAttachmentToolATCType.TabIndex = 187
        Me.chkP300ManualAttachmentToolATCType.Text = "Manual Attachment Tool ATC Type"
        '
        'chkP300ThroughCoolantToolType
        '
        Me.chkP300ThroughCoolantToolType.Location = New System.Drawing.Point(451, 55)
        Me.chkP300ThroughCoolantToolType.Name = "chkP300ThroughCoolantToolType"
        Me.chkP300ThroughCoolantToolType.Size = New System.Drawing.Size(202, 28)
        Me.chkP300ThroughCoolantToolType.TabIndex = 186
        Me.chkP300ThroughCoolantToolType.Text = "Through Coolant Tool Type"
        '
        'cboP300WeightKind
        '
        Me.cboP300WeightKind.Location = New System.Drawing.Point(326, 55)
        Me.cboP300WeightKind.Name = "cboP300WeightKind"
        Me.cboP300WeightKind.Size = New System.Drawing.Size(106, 24)
        Me.cboP300WeightKind.TabIndex = 184
        '
        'Label312
        '
        Me.Label312.Location = New System.Drawing.Point(230, 55)
        Me.Label312.Name = "Label312"
        Me.Label312.Size = New System.Drawing.Size(87, 19)
        Me.Label312.TabIndex = 185
        Me.Label312.Text = "Weight Kind"
        '
        'cboP300HeightKind
        '
        Me.cboP300HeightKind.Location = New System.Drawing.Point(115, 55)
        Me.cboP300HeightKind.Name = "cboP300HeightKind"
        Me.cboP300HeightKind.Size = New System.Drawing.Size(106, 24)
        Me.cboP300HeightKind.TabIndex = 182
        '
        'Label311
        '
        Me.Label311.Location = New System.Drawing.Point(19, 55)
        Me.Label311.Name = "Label311"
        Me.Label311.Size = New System.Drawing.Size(77, 19)
        Me.Label311.TabIndex = 183
        Me.Label311.Text = "Height Kind"
        '
        'cboP300DiameterKind
        '
        Me.cboP300DiameterKind.Location = New System.Drawing.Point(720, 18)
        Me.cboP300DiameterKind.Name = "cboP300DiameterKind"
        Me.cboP300DiameterKind.Size = New System.Drawing.Size(182, 24)
        Me.cboP300DiameterKind.TabIndex = 180
        '
        'Label310
        '
        Me.Label310.Location = New System.Drawing.Point(614, 18)
        Me.Label310.Name = "Label310"
        Me.Label310.Size = New System.Drawing.Size(96, 19)
        Me.Label310.TabIndex = 181
        Me.Label310.Text = "Diameter Kind"
        '
        'btnP300DeleteTool
        '
        Me.btnP300DeleteTool.Location = New System.Drawing.Point(192, 175)
        Me.btnP300DeleteTool.Name = "btnP300DeleteTool"
        Me.btnP300DeleteTool.Size = New System.Drawing.Size(144, 28)
        Me.btnP300DeleteTool.TabIndex = 179
        Me.btnP300DeleteTool.Text = "Delete Tool"
        '
        'btnAttachNextTool
        '
        Me.btnAttachNextTool.Location = New System.Drawing.Point(346, 175)
        Me.btnAttachNextTool.Name = "btnAttachNextTool"
        Me.btnAttachNextTool.Size = New System.Drawing.Size(144, 28)
        Me.btnAttachNextTool.TabIndex = 177
        Me.btnAttachNextTool.Text = "Set Next Tool"
        '
        'cboP300ToolKind2
        '
        Me.cboP300ToolKind2.Location = New System.Drawing.Point(442, 18)
        Me.cboP300ToolKind2.Name = "cboP300ToolKind2"
        Me.cboP300ToolKind2.Size = New System.Drawing.Size(144, 24)
        Me.cboP300ToolKind2.TabIndex = 164
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(355, 18)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(77, 19)
        Me.Label33.TabIndex = 171
        Me.Label33.Text = "Tool Kind"
        '
        'txtP300ATCToolNo
        '
        Me.txtP300ATCToolNo.Location = New System.Drawing.Point(125, 18)
        Me.txtP300ATCToolNo.Name = "txtP300ATCToolNo"
        Me.txtP300ATCToolNo.Size = New System.Drawing.Size(77, 22)
        Me.txtP300ATCToolNo.TabIndex = 165
        Me.txtP300ATCToolNo.Tag = ""
        Me.txtP300ATCToolNo.Text = "0"
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(211, 18)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(77, 19)
        Me.Label34.TabIndex = 168
        Me.Label34.Text = "Pot Number"
        '
        'txtP300ATCPotNo
        '
        Me.txtP300ATCPotNo.Location = New System.Drawing.Point(298, 18)
        Me.txtP300ATCPotNo.Name = "txtP300ATCPotNo"
        Me.txtP300ATCPotNo.Size = New System.Drawing.Size(48, 22)
        Me.txtP300ATCPotNo.TabIndex = 167
        Me.txtP300ATCPotNo.Text = "1"
        '
        'Label137
        '
        Me.Label137.Location = New System.Drawing.Point(19, 18)
        Me.Label137.Name = "Label137"
        Me.Label137.Size = New System.Drawing.Size(87, 19)
        Me.Label137.TabIndex = 166
        Me.Label137.Text = "Tool Number"
        '
        'btnP300UnregisterTool
        '
        Me.btnP300UnregisterTool.Location = New System.Drawing.Point(19, 175)
        Me.btnP300UnregisterTool.Name = "btnP300UnregisterTool"
        Me.btnP300UnregisterTool.Size = New System.Drawing.Size(154, 28)
        Me.btnP300UnregisterTool.TabIndex = 174
        Me.btnP300UnregisterTool.Text = "Unregister Tool"
        '
        'btbP300RegisterTool
        '
        Me.btbP300RegisterTool.Location = New System.Drawing.Point(19, 138)
        Me.btbP300RegisterTool.Name = "btbP300RegisterTool"
        Me.btbP300RegisterTool.Size = New System.Drawing.Size(154, 28)
        Me.btbP300RegisterTool.TabIndex = 172
        Me.btbP300RegisterTool.Text = "Register Tool"
        '
        'tab_ATCSubPanel
        '
        Me.tab_ATCSubPanel.Controls.Add(Me.GroupBox43)
        Me.tab_ATCSubPanel.Controls.Add(Me.GroupBox42)
        Me.tab_ATCSubPanel.Controls.Add(Me.GroupBox41)
        Me.tab_ATCSubPanel.Location = New System.Drawing.Point(4, 25)
        Me.tab_ATCSubPanel.Name = "tab_ATCSubPanel"
        Me.tab_ATCSubPanel.Size = New System.Drawing.Size(1019, 498)
        Me.tab_ATCSubPanel.TabIndex = 29
        Me.tab_ATCSubPanel.Text = "ATC Sub Panel"
        Me.tab_ATCSubPanel.UseVisualStyleBackColor = true
        '
        'GroupBox43
        '
        Me.GroupBox43.Controls.Add(Me.btnATCSubGetErrorCode)
        Me.GroupBox43.Controls.Add(Me.btnATCGetPotNo)
        Me.GroupBox43.Controls.Add(Me.btnATCSubGetToolNo)
        Me.GroupBox43.Controls.Add(Me.Label330)
        Me.GroupBox43.Controls.Add(Me.txtATCSubErrorCode)
        Me.GroupBox43.Controls.Add(Me.txtATCSubToolNo)
        Me.GroupBox43.Controls.Add(Me.btnATCSubClearError)
        Me.GroupBox43.Controls.Add(Me.Label332)
        Me.GroupBox43.Controls.Add(Me.txtATCSubPotNo)
        Me.GroupBox43.Controls.Add(Me.Label336)
        Me.GroupBox43.Location = New System.Drawing.Point(3, 218)
        Me.GroupBox43.Name = "GroupBox43"
        Me.GroupBox43.Size = New System.Drawing.Size(465, 213)
        Me.GroupBox43.TabIndex = 181
        Me.GroupBox43.TabStop = false
        Me.GroupBox43.Text = "Tool/Pot"
        '
        'btnATCSubGetErrorCode
        '
        Me.btnATCSubGetErrorCode.Location = New System.Drawing.Point(322, 112)
        Me.btnATCSubGetErrorCode.Name = "btnATCSubGetErrorCode"
        Me.btnATCSubGetErrorCode.Size = New System.Drawing.Size(124, 35)
        Me.btnATCSubGetErrorCode.TabIndex = 206
        Me.btnATCSubGetErrorCode.Text = "Get Error Code"
        '
        'btnATCGetPotNo
        '
        Me.btnATCGetPotNo.Location = New System.Drawing.Point(322, 68)
        Me.btnATCGetPotNo.Name = "btnATCGetPotNo"
        Me.btnATCGetPotNo.Size = New System.Drawing.Size(124, 35)
        Me.btnATCGetPotNo.TabIndex = 205
        Me.btnATCGetPotNo.Text = "Get Pot No"
        '
        'btnATCSubGetToolNo
        '
        Me.btnATCSubGetToolNo.Location = New System.Drawing.Point(322, 22)
        Me.btnATCSubGetToolNo.Name = "btnATCSubGetToolNo"
        Me.btnATCSubGetToolNo.Size = New System.Drawing.Size(124, 35)
        Me.btnATCSubGetToolNo.TabIndex = 204
        Me.btnATCSubGetToolNo.Text = "Get Tool No"
        '
        'Label330
        '
        Me.Label330.Location = New System.Drawing.Point(7, 112)
        Me.Label330.Name = "Label330"
        Me.Label330.Size = New System.Drawing.Size(91, 19)
        Me.Label330.TabIndex = 203
        Me.Label330.Text = "Error Code"
        '
        'txtATCSubErrorCode
        '
        Me.txtATCSubErrorCode.Location = New System.Drawing.Point(126, 112)
        Me.txtATCSubErrorCode.Name = "txtATCSubErrorCode"
        Me.txtATCSubErrorCode.ReadOnly = true
        Me.txtATCSubErrorCode.Size = New System.Drawing.Size(77, 22)
        Me.txtATCSubErrorCode.TabIndex = 202
        Me.txtATCSubErrorCode.Text = "0"
        '
        'txtATCSubToolNo
        '
        Me.txtATCSubToolNo.ForeColor = System.Drawing.Color.Red
        Me.txtATCSubToolNo.Location = New System.Drawing.Point(126, 22)
        Me.txtATCSubToolNo.Name = "txtATCSubToolNo"
        Me.txtATCSubToolNo.ReadOnly = true
        Me.txtATCSubToolNo.Size = New System.Drawing.Size(77, 22)
        Me.txtATCSubToolNo.TabIndex = 198
        Me.txtATCSubToolNo.Tag = ""
        Me.txtATCSubToolNo.Text = "0"
        '
        'btnATCSubClearError
        '
        Me.btnATCSubClearError.Location = New System.Drawing.Point(198, 160)
        Me.btnATCSubClearError.Name = "btnATCSubClearError"
        Me.btnATCSubClearError.Size = New System.Drawing.Size(248, 35)
        Me.btnATCSubClearError.TabIndex = 172
        Me.btnATCSubClearError.Text = "Clear ATC Sub Panel Error"
        '
        'Label332
        '
        Me.Label332.Location = New System.Drawing.Point(7, 68)
        Me.Label332.Name = "Label332"
        Me.Label332.Size = New System.Drawing.Size(91, 19)
        Me.Label332.TabIndex = 201
        Me.Label332.Text = "Pot Number"
        '
        'txtATCSubPotNo
        '
        Me.txtATCSubPotNo.Location = New System.Drawing.Point(126, 68)
        Me.txtATCSubPotNo.Name = "txtATCSubPotNo"
        Me.txtATCSubPotNo.ReadOnly = true
        Me.txtATCSubPotNo.Size = New System.Drawing.Size(77, 22)
        Me.txtATCSubPotNo.TabIndex = 200
        Me.txtATCSubPotNo.Text = "0"
        '
        'Label336
        '
        Me.Label336.Location = New System.Drawing.Point(7, 22)
        Me.Label336.Name = "Label336"
        Me.Label336.Size = New System.Drawing.Size(101, 19)
        Me.Label336.TabIndex = 199
        Me.Label336.Text = "Tool No"
        '
        'GroupBox42
        '
        Me.GroupBox42.Controls.Add(Me.txtATCSubOperationMode)
        Me.GroupBox42.Controls.Add(Me.btnATCSubGetOperationMode)
        Me.GroupBox42.Controls.Add(Me.cboATCSubPanelOperationModes)
        Me.GroupBox42.Controls.Add(Me.btnATCSubSetOperationMode)
        Me.GroupBox42.Location = New System.Drawing.Point(483, 3)
        Me.GroupBox42.Name = "GroupBox42"
        Me.GroupBox42.Size = New System.Drawing.Size(324, 157)
        Me.GroupBox42.TabIndex = 180
        Me.GroupBox42.TabStop = false
        Me.GroupBox42.Text = "Operation Modes"
        '
        'txtATCSubOperationMode
        '
        Me.txtATCSubOperationMode.Location = New System.Drawing.Point(236, 84)
        Me.txtATCSubOperationMode.Name = "txtATCSubOperationMode"
        Me.txtATCSubOperationMode.ReadOnly = true
        Me.txtATCSubOperationMode.Size = New System.Drawing.Size(77, 22)
        Me.txtATCSubOperationMode.TabIndex = 201
        Me.txtATCSubOperationMode.Text = "0"
        '
        'btnATCSubGetOperationMode
        '
        Me.btnATCSubGetOperationMode.Location = New System.Drawing.Point(6, 87)
        Me.btnATCSubGetOperationMode.Name = "btnATCSubGetOperationMode"
        Me.btnATCSubGetOperationMode.Size = New System.Drawing.Size(138, 63)
        Me.btnATCSubGetOperationMode.TabIndex = 200
        Me.btnATCSubGetOperationMode.Text = "Get Operation Mode"
        '
        'cboATCSubPanelOperationModes
        '
        Me.cboATCSubPanelOperationModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboATCSubPanelOperationModes.FormattingEnabled = true
        Me.cboATCSubPanelOperationModes.Location = New System.Drawing.Point(159, 18)
        Me.cboATCSubPanelOperationModes.Name = "cboATCSubPanelOperationModes"
        Me.cboATCSubPanelOperationModes.Size = New System.Drawing.Size(154, 24)
        Me.cboATCSubPanelOperationModes.TabIndex = 199
        '
        'btnATCSubSetOperationMode
        '
        Me.btnATCSubSetOperationMode.Location = New System.Drawing.Point(6, 18)
        Me.btnATCSubSetOperationMode.Name = "btnATCSubSetOperationMode"
        Me.btnATCSubSetOperationMode.Size = New System.Drawing.Size(138, 63)
        Me.btnATCSubSetOperationMode.TabIndex = 198
        Me.btnATCSubSetOperationMode.Text = "Set ATC Panel Operation Mode"
        '
        'GroupBox41
        '
        Me.GroupBox41.Controls.Add(Me.Label331)
        Me.GroupBox41.Controls.Add(Me.txtATCPanelIndexPotNo)
        Me.GroupBox41.Controls.Add(Me.btnATCPanelSetIndexToolNo)
        Me.GroupBox41.Controls.Add(Me.Label329)
        Me.GroupBox41.Controls.Add(Me.txtATCSubGroupNo)
        Me.GroupBox41.Controls.Add(Me.txtATCSubSerialNo)
        Me.GroupBox41.Controls.Add(Me.btnATCSubSearchPotByToolName)
        Me.GroupBox41.Controls.Add(Me.Label333)
        Me.GroupBox41.Controls.Add(Me.txtATCSubToolName)
        Me.GroupBox41.Controls.Add(Me.Label334)
        Me.GroupBox41.Controls.Add(Me.txtATCSubReturnPotNo)
        Me.GroupBox41.Controls.Add(Me.Label335)
        Me.GroupBox41.Controls.Add(Me.btnATCSubSearchPotByGroupSerial)
        Me.GroupBox41.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox41.Name = "GroupBox41"
        Me.GroupBox41.Size = New System.Drawing.Size(465, 209)
        Me.GroupBox41.TabIndex = 179
        Me.GroupBox41.TabStop = false
        Me.GroupBox41.Text = "Search Pot No"
        '
        'Label331
        '
        Me.Label331.Location = New System.Drawing.Point(19, 181)
        Me.Label331.Name = "Label331"
        Me.Label331.Size = New System.Drawing.Size(186, 19)
        Me.Label331.TabIndex = 209
        Me.Label331.Text = "Calling/Storing Pot No."
        '
        'txtATCPanelIndexPotNo
        '
        Me.txtATCPanelIndexPotNo.ForeColor = System.Drawing.Color.Red
        Me.txtATCPanelIndexPotNo.Location = New System.Drawing.Point(224, 178)
        Me.txtATCPanelIndexPotNo.Name = "txtATCPanelIndexPotNo"
        Me.txtATCPanelIndexPotNo.Size = New System.Drawing.Size(77, 22)
        Me.txtATCPanelIndexPotNo.TabIndex = 208
        Me.txtATCPanelIndexPotNo.Text = "0"
        '
        'btnATCPanelSetIndexToolNo
        '
        Me.btnATCPanelSetIndexToolNo.Location = New System.Drawing.Point(308, 153)
        Me.btnATCPanelSetIndexToolNo.Name = "btnATCPanelSetIndexToolNo"
        Me.btnATCPanelSetIndexToolNo.Size = New System.Drawing.Size(138, 50)
        Me.btnATCPanelSetIndexToolNo.TabIndex = 207
        Me.btnATCPanelSetIndexToolNo.Text = "Set Pot No for calling or storing operation"
        '
        'Label329
        '
        Me.Label329.Location = New System.Drawing.Point(19, 56)
        Me.Label329.Name = "Label329"
        Me.Label329.Size = New System.Drawing.Size(91, 19)
        Me.Label329.TabIndex = 197
        Me.Label329.Text = "Group No"
        '
        'txtATCSubGroupNo
        '
        Me.txtATCSubGroupNo.ForeColor = System.Drawing.Color.Red
        Me.txtATCSubGroupNo.Location = New System.Drawing.Point(138, 56)
        Me.txtATCSubGroupNo.Name = "txtATCSubGroupNo"
        Me.txtATCSubGroupNo.Size = New System.Drawing.Size(77, 22)
        Me.txtATCSubGroupNo.TabIndex = 196
        Me.txtATCSubGroupNo.Text = "1"
        '
        'txtATCSubSerialNo
        '
        Me.txtATCSubSerialNo.ForeColor = System.Drawing.Color.Red
        Me.txtATCSubSerialNo.Location = New System.Drawing.Point(138, 95)
        Me.txtATCSubSerialNo.Name = "txtATCSubSerialNo"
        Me.txtATCSubSerialNo.Size = New System.Drawing.Size(48, 22)
        Me.txtATCSubSerialNo.TabIndex = 195
        Me.txtATCSubSerialNo.Text = "0000"
        '
        'btnATCSubSearchPotByToolName
        '
        Me.btnATCSubSearchPotByToolName.Location = New System.Drawing.Point(308, 84)
        Me.btnATCSubSearchPotByToolName.Name = "btnATCSubSearchPotByToolName"
        Me.btnATCSubSearchPotByToolName.Size = New System.Drawing.Size(138, 63)
        Me.btnATCSubSearchPotByToolName.TabIndex = 194
        Me.btnATCSubSearchPotByToolName.Text = "Search Pot by Tool Name"
        '
        'Label333
        '
        Me.Label333.Location = New System.Drawing.Point(19, 95)
        Me.Label333.Name = "Label333"
        Me.Label333.Size = New System.Drawing.Size(77, 19)
        Me.Label333.TabIndex = 171
        Me.Label333.Text = "Serial No"
        '
        'txtATCSubToolName
        '
        Me.txtATCSubToolName.ForeColor = System.Drawing.Color.Red
        Me.txtATCSubToolName.Location = New System.Drawing.Point(138, 18)
        Me.txtATCSubToolName.Name = "txtATCSubToolName"
        Me.txtATCSubToolName.Size = New System.Drawing.Size(163, 22)
        Me.txtATCSubToolName.TabIndex = 165
        Me.txtATCSubToolName.Tag = ""
        '
        'Label334
        '
        Me.Label334.Location = New System.Drawing.Point(19, 135)
        Me.Label334.Name = "Label334"
        Me.Label334.Size = New System.Drawing.Size(91, 19)
        Me.Label334.TabIndex = 168
        Me.Label334.Text = "Pot Number"
        '
        'txtATCSubReturnPotNo
        '
        Me.txtATCSubReturnPotNo.Location = New System.Drawing.Point(138, 135)
        Me.txtATCSubReturnPotNo.Name = "txtATCSubReturnPotNo"
        Me.txtATCSubReturnPotNo.ReadOnly = true
        Me.txtATCSubReturnPotNo.Size = New System.Drawing.Size(77, 22)
        Me.txtATCSubReturnPotNo.TabIndex = 167
        Me.txtATCSubReturnPotNo.Text = "0"
        '
        'Label335
        '
        Me.Label335.Location = New System.Drawing.Point(19, 18)
        Me.Label335.Name = "Label335"
        Me.Label335.Size = New System.Drawing.Size(101, 19)
        Me.Label335.TabIndex = 166
        Me.Label335.Text = "Tool Name"
        '
        'btnATCSubSearchPotByGroupSerial
        '
        Me.btnATCSubSearchPotByGroupSerial.Location = New System.Drawing.Point(308, 18)
        Me.btnATCSubSearchPotByGroupSerial.Name = "btnATCSubSearchPotByGroupSerial"
        Me.btnATCSubSearchPotByGroupSerial.Size = New System.Drawing.Size(138, 63)
        Me.btnATCSubSearchPotByGroupSerial.TabIndex = 174
        Me.btnATCSubSearchPotByGroupSerial.Text = "Search Pot By Group/Serial No"
        '
        'tab_machine
        '
        Me.tab_machine.Controls.Add(Me.Label1)
        Me.tab_machine.Controls.Add(Me.cboAllLoggingLevel)
        Me.tab_machine.Controls.Add(Me.grpHourMeter)
        Me.tab_machine.Controls.Add(Me.txtMachine)
        Me.tab_machine.Controls.Add(Me.txtUserAlarmMessage)
        Me.tab_machine.Controls.Add(Me.cboUserAlarm)
        Me.tab_machine.Controls.Add(Me.btnSetUserAlarm)
        Me.tab_machine.Controls.Add(Me.GroupBox8)
        Me.tab_machine.Controls.Add(Me.Panel11)
        Me.tab_machine.Controls.Add(Me.machineUpdateButton)
        Me.tab_machine.Controls.Add(Me.machinePowerOnTimeAdd)
        Me.tab_machine.Controls.Add(Me.machinePowerOnTimeSet)
        Me.tab_machine.Controls.Add(Me.machinePowerOnTimeUpdate)
        Me.tab_machine.Controls.Add(Me.Label35)
        Me.tab_machine.Controls.Add(Me.btnClearUserAlarmD)
        Me.tab_machine.Location = New System.Drawing.Point(4, 25)
        Me.tab_machine.Name = "tab_machine"
        Me.tab_machine.Size = New System.Drawing.Size(1019, 498)
        Me.tab_machine.TabIndex = 3
        Me.tab_machine.Text = "Machine"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(17, 147)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 17)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Set Logging Level To All objects:"
        '
        'cboAllLoggingLevel
        '
        Me.cboAllLoggingLevel.FormattingEnabled = true
        Me.cboAllLoggingLevel.Location = New System.Drawing.Point(250, 151)
        Me.cboAllLoggingLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.cboAllLoggingLevel.Name = "cboAllLoggingLevel"
        Me.cboAllLoggingLevel.Size = New System.Drawing.Size(215, 24)
        Me.cboAllLoggingLevel.TabIndex = 254
        '
        'grpHourMeter
        '
        Me.grpHourMeter.Controls.Add(Me.btnHourMeterCountSetAdd)
        Me.grpHourMeter.Controls.Add(Me.btnHourMeterCountSetSet)
        Me.grpHourMeter.Controls.Add(Me.btnHourMeterCountSetGet)
        Me.grpHourMeter.Controls.Add(Me.cboHourMeterCountSet)
        Me.grpHourMeter.Controls.Add(Me.txtHourMeterCountSetValue)
        Me.grpHourMeter.Controls.Add(Me.txtHourMeterCountSet)
        Me.grpHourMeter.Controls.Add(Me.txtHourMeterCountValue)
        Me.grpHourMeter.Controls.Add(Me.txtHourMeterCount)
        Me.grpHourMeter.Controls.Add(Me.cboHourMeterCount)
        Me.grpHourMeter.Controls.Add(Me.btnHourMeterCountAdd)
        Me.grpHourMeter.Controls.Add(Me.btnHourMeterCountSet)
        Me.grpHourMeter.Controls.Add(Me.btnHourMeterCountGet)
        Me.grpHourMeter.Location = New System.Drawing.Point(8, 8)
        Me.grpHourMeter.Name = "grpHourMeter"
        Me.grpHourMeter.Size = New System.Drawing.Size(552, 136)
        Me.grpHourMeter.TabIndex = 94
        Me.grpHourMeter.TabStop = false
        Me.grpHourMeter.Text = "NC OPR Monitor (Hour Meter)"
        '
        'btnHourMeterCountSetAdd
        '
        Me.btnHourMeterCountSetAdd.Location = New System.Drawing.Point(496, 88)
        Me.btnHourMeterCountSetAdd.Name = "btnHourMeterCountSetAdd"
        Me.btnHourMeterCountSetAdd.Size = New System.Drawing.Size(48, 32)
        Me.btnHourMeterCountSetAdd.TabIndex = 11
        Me.btnHourMeterCountSetAdd.Text = "Add"
        '
        'btnHourMeterCountSetSet
        '
        Me.btnHourMeterCountSetSet.Location = New System.Drawing.Point(440, 88)
        Me.btnHourMeterCountSetSet.Name = "btnHourMeterCountSetSet"
        Me.btnHourMeterCountSetSet.Size = New System.Drawing.Size(48, 32)
        Me.btnHourMeterCountSetSet.TabIndex = 10
        Me.btnHourMeterCountSetSet.Text = "Set"
        '
        'btnHourMeterCountSetGet
        '
        Me.btnHourMeterCountSetGet.Location = New System.Drawing.Point(384, 88)
        Me.btnHourMeterCountSetGet.Name = "btnHourMeterCountSetGet"
        Me.btnHourMeterCountSetGet.Size = New System.Drawing.Size(48, 32)
        Me.btnHourMeterCountSetGet.TabIndex = 9
        Me.btnHourMeterCountSetGet.Text = "Get"
        '
        'cboHourMeterCountSet
        '
        Me.cboHourMeterCountSet.Location = New System.Drawing.Point(256, 88)
        Me.cboHourMeterCountSet.Name = "cboHourMeterCountSet"
        Me.cboHourMeterCountSet.Size = New System.Drawing.Size(121, 24)
        Me.cboHourMeterCountSet.TabIndex = 8
        '
        'txtHourMeterCountSetValue
        '
        Me.txtHourMeterCountSetValue.ForeColor = System.Drawing.Color.Red
        Me.txtHourMeterCountSetValue.Location = New System.Drawing.Point(144, 88)
        Me.txtHourMeterCountSetValue.Name = "txtHourMeterCountSetValue"
        Me.txtHourMeterCountSetValue.Size = New System.Drawing.Size(100, 22)
        Me.txtHourMeterCountSetValue.TabIndex = 7
        Me.txtHourMeterCountSetValue.Text = "0"
        '
        'txtHourMeterCountSet
        '
        Me.txtHourMeterCountSet.Location = New System.Drawing.Point(8, 88)
        Me.txtHourMeterCountSet.Name = "txtHourMeterCountSet"
        Me.txtHourMeterCountSet.ReadOnly = true
        Me.txtHourMeterCountSet.Size = New System.Drawing.Size(100, 22)
        Me.txtHourMeterCountSet.TabIndex = 6
        Me.txtHourMeterCountSet.Text = "0"
        '
        'txtHourMeterCountValue
        '
        Me.txtHourMeterCountValue.ForeColor = System.Drawing.Color.Red
        Me.txtHourMeterCountValue.Location = New System.Drawing.Point(144, 32)
        Me.txtHourMeterCountValue.Name = "txtHourMeterCountValue"
        Me.txtHourMeterCountValue.Size = New System.Drawing.Size(100, 22)
        Me.txtHourMeterCountValue.TabIndex = 5
        Me.txtHourMeterCountValue.Text = "0"
        '
        'txtHourMeterCount
        '
        Me.txtHourMeterCount.Location = New System.Drawing.Point(8, 32)
        Me.txtHourMeterCount.Name = "txtHourMeterCount"
        Me.txtHourMeterCount.ReadOnly = true
        Me.txtHourMeterCount.Size = New System.Drawing.Size(100, 22)
        Me.txtHourMeterCount.TabIndex = 4
        Me.txtHourMeterCount.Text = "0"
        '
        'cboHourMeterCount
        '
        Me.cboHourMeterCount.Location = New System.Drawing.Point(256, 32)
        Me.cboHourMeterCount.Name = "cboHourMeterCount"
        Me.cboHourMeterCount.Size = New System.Drawing.Size(121, 24)
        Me.cboHourMeterCount.TabIndex = 3
        '
        'btnHourMeterCountAdd
        '
        Me.btnHourMeterCountAdd.Location = New System.Drawing.Point(496, 32)
        Me.btnHourMeterCountAdd.Name = "btnHourMeterCountAdd"
        Me.btnHourMeterCountAdd.Size = New System.Drawing.Size(48, 32)
        Me.btnHourMeterCountAdd.TabIndex = 2
        Me.btnHourMeterCountAdd.Text = "Add"
        '
        'btnHourMeterCountSet
        '
        Me.btnHourMeterCountSet.Location = New System.Drawing.Point(440, 32)
        Me.btnHourMeterCountSet.Name = "btnHourMeterCountSet"
        Me.btnHourMeterCountSet.Size = New System.Drawing.Size(48, 32)
        Me.btnHourMeterCountSet.TabIndex = 1
        Me.btnHourMeterCountSet.Text = "Set"
        '
        'btnHourMeterCountGet
        '
        Me.btnHourMeterCountGet.Location = New System.Drawing.Point(384, 32)
        Me.btnHourMeterCountGet.Name = "btnHourMeterCountGet"
        Me.btnHourMeterCountGet.Size = New System.Drawing.Size(48, 32)
        Me.btnHourMeterCountGet.TabIndex = 0
        Me.btnHourMeterCountGet.Text = "Get"
        '
        'txtMachine
        '
        Me.txtMachine.Location = New System.Drawing.Point(568, 48)
        Me.txtMachine.Multiline = true
        Me.txtMachine.Name = "txtMachine"
        Me.txtMachine.Size = New System.Drawing.Size(360, 416)
        Me.txtMachine.TabIndex = 93
        '
        'txtUserAlarmMessage
        '
        Me.txtUserAlarmMessage.BackColor = System.Drawing.Color.White
        Me.txtUserAlarmMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUserAlarmMessage.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtUserAlarmMessage.ForeColor = System.Drawing.Color.Red
        Me.txtUserAlarmMessage.Location = New System.Drawing.Point(192, 248)
        Me.txtUserAlarmMessage.Name = "txtUserAlarmMessage"
        Me.txtUserAlarmMessage.Size = New System.Drawing.Size(173, 20)
        Me.txtUserAlarmMessage.TabIndex = 87
        Me.txtUserAlarmMessage.Text = "0"
        '
        'cboUserAlarm
        '
        Me.cboUserAlarm.Location = New System.Drawing.Point(192, 200)
        Me.cboUserAlarm.Name = "cboUserAlarm"
        Me.cboUserAlarm.Size = New System.Drawing.Size(173, 24)
        Me.cboUserAlarm.TabIndex = 86
        Me.cboUserAlarm.Text = "ComboBox1"
        '
        'btnSetUserAlarm
        '
        Me.btnSetUserAlarm.Location = New System.Drawing.Point(16, 200)
        Me.btnSetUserAlarm.Name = "btnSetUserAlarm"
        Me.btnSetUserAlarm.Size = New System.Drawing.Size(144, 28)
        Me.btnSetUserAlarm.TabIndex = 85
        Me.btnSetUserAlarm.Text = "Set User Alarm"
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
        Me.GroupBox8.Location = New System.Drawing.Point(10, 314)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(547, 111)
        Me.GroupBox8.TabIndex = 80
        Me.GroupBox8.TabStop = false
        Me.GroupBox8.Text = "Machine Zero Offset"
        '
        'cmdMachineDataUnit
        '
        Me.cmdMachineDataUnit.Location = New System.Drawing.Point(422, 28)
        Me.cmdMachineDataUnit.Name = "cmdMachineDataUnit"
        Me.cmdMachineDataUnit.Size = New System.Drawing.Size(116, 27)
        Me.cmdMachineDataUnit.TabIndex = 9
        Me.cmdMachineDataUnit.Text = "Set Data Unit"
        '
        'cboMachineDataUnit
        '
        Me.cboMachineDataUnit.Location = New System.Drawing.Point(240, 28)
        Me.cboMachineDataUnit.Name = "cboMachineDataUnit"
        Me.cboMachineDataUnit.Size = New System.Drawing.Size(173, 24)
        Me.cboMachineDataUnit.TabIndex = 8
        Me.cboMachineDataUnit.Text = "ComboBox1"
        '
        'txtInputMachineZeroOffset
        '
        Me.txtInputMachineZeroOffset.ForeColor = System.Drawing.Color.Red
        Me.txtInputMachineZeroOffset.Location = New System.Drawing.Point(374, 65)
        Me.txtInputMachineZeroOffset.Name = "txtInputMachineZeroOffset"
        Me.txtInputMachineZeroOffset.Size = New System.Drawing.Size(96, 22)
        Me.txtInputMachineZeroOffset.TabIndex = 7
        Me.txtInputMachineZeroOffset.Text = "0.0"
        '
        'Label142
        '
        Me.Label142.Location = New System.Drawing.Point(10, 28)
        Me.Label142.Name = "Label142"
        Me.Label142.Size = New System.Drawing.Size(38, 18)
        Me.Label142.TabIndex = 6
        Me.Label142.Text = "Axis"
        '
        'cboMachineZeroOffsetAxis
        '
        Me.cboMachineZeroOffsetAxis.Location = New System.Drawing.Point(58, 28)
        Me.cboMachineZeroOffsetAxis.Name = "cboMachineZeroOffsetAxis"
        Me.cboMachineZeroOffsetAxis.Size = New System.Drawing.Size(172, 24)
        Me.cboMachineZeroOffsetAxis.TabIndex = 5
        '
        'txtOutputMachineZeroOffset
        '
        Me.txtOutputMachineZeroOffset.Location = New System.Drawing.Point(269, 65)
        Me.txtOutputMachineZeroOffset.Name = "txtOutputMachineZeroOffset"
        Me.txtOutputMachineZeroOffset.ReadOnly = true
        Me.txtOutputMachineZeroOffset.Size = New System.Drawing.Size(96, 22)
        Me.txtOutputMachineZeroOffset.TabIndex = 4
        Me.txtOutputMachineZeroOffset.Text = "0.0"
        '
        'cmdCalMachineZeroOffset
        '
        Me.cmdCalMachineZeroOffset.Location = New System.Drawing.Point(182, 65)
        Me.cmdCalMachineZeroOffset.Name = "cmdCalMachineZeroOffset"
        Me.cmdCalMachineZeroOffset.Size = New System.Drawing.Size(77, 37)
        Me.cmdCalMachineZeroOffset.TabIndex = 3
        Me.cmdCalMachineZeroOffset.Text = "Calculate"
        '
        'cmdAddMachineZeroOffset
        '
        Me.cmdAddMachineZeroOffset.Location = New System.Drawing.Point(125, 65)
        Me.cmdAddMachineZeroOffset.Name = "cmdAddMachineZeroOffset"
        Me.cmdAddMachineZeroOffset.Size = New System.Drawing.Size(48, 37)
        Me.cmdAddMachineZeroOffset.TabIndex = 2
        Me.cmdAddMachineZeroOffset.Text = "Add"
        '
        'cmdSetMachineZeroOffset
        '
        Me.cmdSetMachineZeroOffset.Location = New System.Drawing.Point(67, 65)
        Me.cmdSetMachineZeroOffset.Name = "cmdSetMachineZeroOffset"
        Me.cmdSetMachineZeroOffset.Size = New System.Drawing.Size(48, 37)
        Me.cmdSetMachineZeroOffset.TabIndex = 1
        Me.cmdSetMachineZeroOffset.Text = "Set"
        '
        'cmdGetMachineZeroOffset
        '
        Me.cmdGetMachineZeroOffset.Location = New System.Drawing.Point(10, 65)
        Me.cmdGetMachineZeroOffset.Name = "cmdGetMachineZeroOffset"
        Me.cmdGetMachineZeroOffset.Size = New System.Drawing.Size(48, 37)
        Me.cmdGetMachineZeroOffset.TabIndex = 0
        Me.cmdGetMachineZeroOffset.Text = "Get"
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.txtInputMDI)
        Me.Panel11.Controls.Add(Me.cmd_InputMDI)
        Me.Panel11.Location = New System.Drawing.Point(10, 434)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(547, 46)
        Me.Panel11.TabIndex = 79
        '
        'txtInputMDI
        '
        Me.txtInputMDI.Location = New System.Drawing.Point(115, 9)
        Me.txtInputMDI.Name = "txtInputMDI"
        Me.txtInputMDI.Size = New System.Drawing.Size(423, 22)
        Me.txtInputMDI.TabIndex = 80
        '
        'cmd_InputMDI
        '
        Me.cmd_InputMDI.Location = New System.Drawing.Point(10, 9)
        Me.cmd_InputMDI.Name = "cmd_InputMDI"
        Me.cmd_InputMDI.Size = New System.Drawing.Size(96, 28)
        Me.cmd_InputMDI.TabIndex = 79
        Me.cmd_InputMDI.Text = "InputMDI"
        '
        'machineUpdateButton
        '
        Me.machineUpdateButton.Location = New System.Drawing.Point(792, 8)
        Me.machineUpdateButton.Name = "machineUpdateButton"
        Me.machineUpdateButton.Size = New System.Drawing.Size(124, 28)
        Me.machineUpdateButton.TabIndex = 75
        Me.machineUpdateButton.Text = "Update"
        '
        'machinePowerOnTimeAdd
        '
        Me.machinePowerOnTimeAdd.Location = New System.Drawing.Point(326, 286)
        Me.machinePowerOnTimeAdd.Name = "machinePowerOnTimeAdd"
        Me.machinePowerOnTimeAdd.Size = New System.Drawing.Size(48, 28)
        Me.machinePowerOnTimeAdd.TabIndex = 74
        Me.machinePowerOnTimeAdd.Text = "Add"
        '
        'machinePowerOnTimeSet
        '
        Me.machinePowerOnTimeSet.Location = New System.Drawing.Point(259, 286)
        Me.machinePowerOnTimeSet.Name = "machinePowerOnTimeSet"
        Me.machinePowerOnTimeSet.Size = New System.Drawing.Size(58, 28)
        Me.machinePowerOnTimeSet.TabIndex = 73
        Me.machinePowerOnTimeSet.Text = "Set"
        '
        'machinePowerOnTimeUpdate
        '
        Me.machinePowerOnTimeUpdate.BackColor = System.Drawing.Color.White
        Me.machinePowerOnTimeUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.machinePowerOnTimeUpdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.machinePowerOnTimeUpdate.ForeColor = System.Drawing.Color.Red
        Me.machinePowerOnTimeUpdate.Location = New System.Drawing.Point(134, 286)
        Me.machinePowerOnTimeUpdate.Name = "machinePowerOnTimeUpdate"
        Me.machinePowerOnTimeUpdate.Size = New System.Drawing.Size(106, 17)
        Me.machinePowerOnTimeUpdate.TabIndex = 62
        Me.machinePowerOnTimeUpdate.Text = "0"
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label35.Location = New System.Drawing.Point(10, 286)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(124, 19)
        Me.Label35.TabIndex = 30
        Me.Label35.Text = "Power On Time :"
        '
        'btnClearUserAlarmD
        '
        Me.btnClearUserAlarmD.Location = New System.Drawing.Point(16, 240)
        Me.btnClearUserAlarmD.Name = "btnClearUserAlarmD"
        Me.btnClearUserAlarmD.Size = New System.Drawing.Size(144, 28)
        Me.btnClearUserAlarmD.TabIndex = 86
        Me.btnClearUserAlarmD.Text = "Clear User Alarm D"
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
        Me.tab_workpiece.Controls.Add(Me.Label97)
        Me.tab_workpiece.Controls.Add(Me.Label96)
        Me.tab_workpiece.Controls.Add(Me.wkUpdateValsWithNoParams)
        Me.tab_workpiece.Controls.Add(Me.wkValsWithoutParameters)
        Me.tab_workpiece.Controls.Add(Me.Label95)
        Me.tab_workpiece.Controls.Add(Me.wkUpdateZeroOffset)
        Me.tab_workpiece.Controls.Add(Me.wkZeroOffset)
        Me.tab_workpiece.Controls.Add(Me.Label94)
        Me.tab_workpiece.Controls.Add(Me.wkAxisCombo)
        Me.tab_workpiece.Controls.Add(Me.Panel9)
        Me.tab_workpiece.Controls.Add(Me.Panel10)
        Me.tab_workpiece.Location = New System.Drawing.Point(4, 25)
        Me.tab_workpiece.Name = "tab_workpiece"
        Me.tab_workpiece.Size = New System.Drawing.Size(1019, 498)
        Me.tab_workpiece.TabIndex = 11
        Me.tab_workpiece.Text = "Workpiece"
        '
        'wkSetDataUnitButton
        '
        Me.wkSetDataUnitButton.Location = New System.Drawing.Point(264, 440)
        Me.wkSetDataUnitButton.Name = "wkSetDataUnitButton"
        Me.wkSetDataUnitButton.Size = New System.Drawing.Size(57, 27)
        Me.wkSetDataUnitButton.TabIndex = 191
        Me.wkSetDataUnitButton.Text = "Set"
        '
        'wkDataUnitCombo
        '
        Me.wkDataUnitCombo.Location = New System.Drawing.Point(104, 440)
        Me.wkDataUnitCombo.Name = "wkDataUnitCombo"
        Me.wkDataUnitCombo.Size = New System.Drawing.Size(145, 24)
        Me.wkDataUnitCombo.TabIndex = 190
        '
        'Label152
        '
        Me.Label152.Location = New System.Drawing.Point(16, 440)
        Me.Label152.Name = "Label152"
        Me.Label152.Size = New System.Drawing.Size(87, 27)
        Me.Label152.TabIndex = 189
        Me.Label152.Text = "Data Unit"
        '
        'Label129
        '
        Me.Label129.Location = New System.Drawing.Point(422, 212)
        Me.Label129.Name = "Label129"
        Me.Label129.Size = New System.Drawing.Size(96, 19)
        Me.Label129.TabIndex = 188
        Me.Label129.Text = "Zero Offsets :"
        '
        'wkZeroTo
        '
        Me.wkZeroTo.Location = New System.Drawing.Point(595, 240)
        Me.wkZeroTo.Name = "wkZeroTo"
        Me.wkZeroTo.Size = New System.Drawing.Size(77, 22)
        Me.wkZeroTo.TabIndex = 186
        Me.wkZeroTo.Text = "2"
        '
        'Label127
        '
        Me.Label127.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label127.Location = New System.Drawing.Point(528, 240)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(58, 18)
        Me.Label127.TabIndex = 185
        Me.Label127.Text = "To"
        '
        'wkZeroFrom
        '
        Me.wkZeroFrom.Location = New System.Drawing.Point(595, 212)
        Me.wkZeroFrom.Name = "wkZeroFrom"
        Me.wkZeroFrom.Size = New System.Drawing.Size(77, 22)
        Me.wkZeroFrom.TabIndex = 184
        Me.wkZeroFrom.Text = "1"
        '
        'Label128
        '
        Me.Label128.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label128.Location = New System.Drawing.Point(528, 212)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(58, 19)
        Me.Label128.TabIndex = 183
        Me.Label128.Text = "From"
        '
        'wkZeroResults
        '
        Me.wkZeroResults.Location = New System.Drawing.Point(682, 212)
        Me.wkZeroResults.Multiline = true
        Me.wkZeroResults.Name = "wkZeroResults"
        Me.wkZeroResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.wkZeroResults.Size = New System.Drawing.Size(196, 213)
        Me.wkZeroResults.TabIndex = 182
        '
        'Label97
        '
        Me.Label97.Location = New System.Drawing.Point(16, 240)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(48, 18)
        Me.Label97.TabIndex = 171
        Me.Label97.Text = "Axis :"
        '
        'Label96
        '
        Me.Label96.Location = New System.Drawing.Point(583, 6)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(189, 37)
        Me.Label96.TabIndex = 170
        Me.Label96.Text = "All functions without parameters:"
        Me.Label96.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'wkUpdateValsWithNoParams
        '
        Me.wkUpdateValsWithNoParams.Location = New System.Drawing.Point(586, 277)
        Me.wkUpdateValsWithNoParams.Name = "wkUpdateValsWithNoParams"
        Me.wkUpdateValsWithNoParams.Size = New System.Drawing.Size(86, 28)
        Me.wkUpdateValsWithNoParams.TabIndex = 169
        Me.wkUpdateValsWithNoParams.Text = "Update"
        '
        'wkValsWithoutParameters
        '
        Me.wkValsWithoutParameters.Location = New System.Drawing.Point(586, 46)
        Me.wkValsWithoutParameters.Multiline = true
        Me.wkValsWithoutParameters.Name = "wkValsWithoutParameters"
        Me.wkValsWithoutParameters.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.wkValsWithoutParameters.Size = New System.Drawing.Size(297, 148)
        Me.wkValsWithoutParameters.TabIndex = 168
        '
        'Label95
        '
        Me.Label95.Location = New System.Drawing.Point(19, 37)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(149, 19)
        Me.Label95.TabIndex = 165
        Me.Label95.Text = "Workpiece Counter"
        '
        'wkUpdateZeroOffset
        '
        Me.wkUpdateZeroOffset.ForeColor = System.Drawing.Color.Red
        Me.wkUpdateZeroOffset.Location = New System.Drawing.Point(208, 352)
        Me.wkUpdateZeroOffset.Name = "wkUpdateZeroOffset"
        Me.wkUpdateZeroOffset.Size = New System.Drawing.Size(77, 22)
        Me.wkUpdateZeroOffset.TabIndex = 159
        Me.wkUpdateZeroOffset.Text = "0.00"
        '
        'wkZeroOffset
        '
        Me.wkZeroOffset.Location = New System.Drawing.Point(120, 352)
        Me.wkZeroOffset.Name = "wkZeroOffset"
        Me.wkZeroOffset.Size = New System.Drawing.Size(77, 22)
        Me.wkZeroOffset.TabIndex = 158
        Me.wkZeroOffset.Text = "0.00"
        '
        'Label94
        '
        Me.Label94.Location = New System.Drawing.Point(16, 352)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(96, 18)
        Me.Label94.TabIndex = 157
        Me.Label94.Text = "Zero Offsets :"
        '
        'wkAxisCombo
        '
        Me.wkAxisCombo.Items.AddRange(New Object() {"0", "1", "2", "3", "4", "5", "6"})
        Me.wkAxisCombo.Location = New System.Drawing.Point(88, 240)
        Me.wkAxisCombo.Name = "wkAxisCombo"
        Me.wkAxisCombo.Size = New System.Drawing.Size(144, 24)
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
        Me.Panel9.Location = New System.Drawing.Point(8, 216)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(336, 194)
        Me.Panel9.TabIndex = 173
        '
        'wkButtonZeroOffsetGet
        '
        Me.wkButtonZeroOffsetGet.Location = New System.Drawing.Point(163, 83)
        Me.wkButtonZeroOffsetGet.Name = "wkButtonZeroOffsetGet"
        Me.wkButtonZeroOffsetGet.Size = New System.Drawing.Size(48, 28)
        Me.wkButtonZeroOffsetGet.TabIndex = 172
        Me.wkButtonZeroOffsetGet.Text = "Get"
        '
        'wkButtonZeroOffsetCal
        '
        Me.wkButtonZeroOffsetCal.Location = New System.Drawing.Point(230, 157)
        Me.wkButtonZeroOffsetCal.Name = "wkButtonZeroOffsetCal"
        Me.wkButtonZeroOffsetCal.Size = New System.Drawing.Size(48, 28)
        Me.wkButtonZeroOffsetCal.TabIndex = 162
        Me.wkButtonZeroOffsetCal.Text = "Cal"
        '
        'wkButtonZeroOffsetAdd
        '
        Me.wkButtonZeroOffsetAdd.Location = New System.Drawing.Point(173, 157)
        Me.wkButtonZeroOffsetAdd.Name = "wkButtonZeroOffsetAdd"
        Me.wkButtonZeroOffsetAdd.Size = New System.Drawing.Size(48, 28)
        Me.wkButtonZeroOffsetAdd.TabIndex = 161
        Me.wkButtonZeroOffsetAdd.Text = "Add"
        '
        'wkButtonZeroOffsetSet
        '
        Me.wkButtonZeroOffsetSet.Location = New System.Drawing.Point(115, 157)
        Me.wkButtonZeroOffsetSet.Name = "wkButtonZeroOffsetSet"
        Me.wkButtonZeroOffsetSet.Size = New System.Drawing.Size(48, 28)
        Me.wkButtonZeroOffsetSet.TabIndex = 160
        Me.wkButtonZeroOffsetSet.Text = "Set"
        '
        'wkOffsetNumber
        '
        Me.wkOffsetNumber.Location = New System.Drawing.Point(144, 55)
        Me.wkOffsetNumber.Name = "wkOffsetNumber"
        Me.wkOffsetNumber.Size = New System.Drawing.Size(77, 22)
        Me.wkOffsetNumber.TabIndex = 177
        Me.wkOffsetNumber.Text = "1"
        '
        'Label93
        '
        Me.Label93.Location = New System.Drawing.Point(10, 55)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(105, 19)
        Me.Label93.TabIndex = 176
        Me.Label93.Text = "Offset Number :"
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.btnWPCounterSetAdd)
        Me.Panel10.Controls.Add(Me.btnWPCounterSetSet)
        Me.Panel10.Controls.Add(Me.btnWPCounterSetGet)
        Me.Panel10.Controls.Add(Me.Label325)
        Me.Panel10.Controls.Add(Me.txtWPCounterSet)
        Me.Panel10.Controls.Add(Me.txtWPCounterSetValue)
        Me.Panel10.Controls.Add(Me.cboWorkpieceCounterSet)
        Me.Panel10.Controls.Add(Me.cmd_WorkpieceAdd)
        Me.Panel10.Controls.Add(Me.wkCounterCombo)
        Me.Panel10.Controls.Add(Me.wkUpdateCounter)
        Me.Panel10.Controls.Add(Me.wkCounterValue)
        Me.Panel10.Controls.Add(Me.wkButtonGetCounter)
        Me.Panel10.Controls.Add(Me.wkCounterSetButton)
        Me.Panel10.Location = New System.Drawing.Point(8, 24)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(560, 176)
        Me.Panel10.TabIndex = 175
        '
        'btnWPCounterSetAdd
        '
        Me.btnWPCounterSetAdd.Location = New System.Drawing.Point(392, 128)
        Me.btnWPCounterSetAdd.Name = "btnWPCounterSetAdd"
        Me.btnWPCounterSetAdd.Size = New System.Drawing.Size(48, 32)
        Me.btnWPCounterSetAdd.TabIndex = 181
        Me.btnWPCounterSetAdd.Text = "Add"
        '
        'btnWPCounterSetSet
        '
        Me.btnWPCounterSetSet.Location = New System.Drawing.Point(296, 128)
        Me.btnWPCounterSetSet.Name = "btnWPCounterSetSet"
        Me.btnWPCounterSetSet.Size = New System.Drawing.Size(56, 32)
        Me.btnWPCounterSetSet.TabIndex = 180
        Me.btnWPCounterSetSet.Text = "Set"
        '
        'btnWPCounterSetGet
        '
        Me.btnWPCounterSetGet.Location = New System.Drawing.Point(208, 128)
        Me.btnWPCounterSetGet.Name = "btnWPCounterSetGet"
        Me.btnWPCounterSetGet.Size = New System.Drawing.Size(56, 32)
        Me.btnWPCounterSetGet.TabIndex = 179
        Me.btnWPCounterSetGet.Text = "Get"
        '
        'Label325
        '
        Me.Label325.Location = New System.Drawing.Point(8, 96)
        Me.Label325.Name = "Label325"
        Me.Label325.Size = New System.Drawing.Size(168, 23)
        Me.Label325.TabIndex = 178
        Me.Label325.Text = "Workpiece Counter SET"
        '
        'txtWPCounterSet
        '
        Me.txtWPCounterSet.Location = New System.Drawing.Point(208, 96)
        Me.txtWPCounterSet.Name = "txtWPCounterSet"
        Me.txtWPCounterSet.Size = New System.Drawing.Size(80, 22)
        Me.txtWPCounterSet.TabIndex = 177
        Me.txtWPCounterSet.Text = "0"
        '
        'txtWPCounterSetValue
        '
        Me.txtWPCounterSetValue.ForeColor = System.Drawing.Color.Red
        Me.txtWPCounterSetValue.Location = New System.Drawing.Point(296, 96)
        Me.txtWPCounterSetValue.Name = "txtWPCounterSetValue"
        Me.txtWPCounterSetValue.Size = New System.Drawing.Size(80, 22)
        Me.txtWPCounterSetValue.TabIndex = 176
        Me.txtWPCounterSetValue.Text = "0"
        '
        'cboWorkpieceCounterSet
        '
        Me.cboWorkpieceCounterSet.Location = New System.Drawing.Point(392, 96)
        Me.cboWorkpieceCounterSet.Name = "cboWorkpieceCounterSet"
        Me.cboWorkpieceCounterSet.Size = New System.Drawing.Size(144, 24)
        Me.cboWorkpieceCounterSet.TabIndex = 175
        '
        'cmd_WorkpieceAdd
        '
        Me.cmd_WorkpieceAdd.Location = New System.Drawing.Point(392, 48)
        Me.cmd_WorkpieceAdd.Name = "cmd_WorkpieceAdd"
        Me.cmd_WorkpieceAdd.Size = New System.Drawing.Size(48, 27)
        Me.cmd_WorkpieceAdd.TabIndex = 162
        Me.cmd_WorkpieceAdd.Text = "Add"
        '
        'wkCounterCombo
        '
        Me.wkCounterCombo.Location = New System.Drawing.Point(392, 8)
        Me.wkCounterCombo.Name = "wkCounterCombo"
        Me.wkCounterCombo.Size = New System.Drawing.Size(144, 24)
        Me.wkCounterCombo.TabIndex = 163
        '
        'wkUpdateCounter
        '
        Me.wkUpdateCounter.ForeColor = System.Drawing.Color.Red
        Me.wkUpdateCounter.Location = New System.Drawing.Point(296, 8)
        Me.wkUpdateCounter.Name = "wkUpdateCounter"
        Me.wkUpdateCounter.Size = New System.Drawing.Size(77, 22)
        Me.wkUpdateCounter.TabIndex = 164
        Me.wkUpdateCounter.Text = "0"
        '
        'wkCounterValue
        '
        Me.wkCounterValue.Enabled = false
        Me.wkCounterValue.Location = New System.Drawing.Point(208, 8)
        Me.wkCounterValue.Name = "wkCounterValue"
        Me.wkCounterValue.Size = New System.Drawing.Size(76, 22)
        Me.wkCounterValue.TabIndex = 166
        Me.wkCounterValue.Text = "0"
        '
        'wkButtonGetCounter
        '
        Me.wkButtonGetCounter.Location = New System.Drawing.Point(208, 48)
        Me.wkButtonGetCounter.Name = "wkButtonGetCounter"
        Me.wkButtonGetCounter.Size = New System.Drawing.Size(48, 30)
        Me.wkButtonGetCounter.TabIndex = 174
        Me.wkButtonGetCounter.Text = "Get"
        '
        'wkCounterSetButton
        '
        Me.wkCounterSetButton.Location = New System.Drawing.Point(296, 48)
        Me.wkCounterSetButton.Name = "wkCounterSetButton"
        Me.wkCounterSetButton.Size = New System.Drawing.Size(48, 30)
        Me.wkCounterSetButton.TabIndex = 167
        Me.wkCounterSetButton.Text = "Set"
        '
        'tab_OptionalParameter
        '
        Me.tab_OptionalParameter.Controls.Add(Me.GroupBox12)
        Me.tab_OptionalParameter.Location = New System.Drawing.Point(4, 25)
        Me.tab_OptionalParameter.Name = "tab_OptionalParameter"
        Me.tab_OptionalParameter.Size = New System.Drawing.Size(1019, 498)
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
        Me.GroupBox12.Location = New System.Drawing.Point(10, 18)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(585, 194)
        Me.GroupBox12.TabIndex = 236
        Me.GroupBox12.TabStop = false
        Me.GroupBox12.Text = "Optional Parameter - Bit/Word/LongWord"
        '
        'txtLongWordInput
        '
        Me.txtLongWordInput.ForeColor = System.Drawing.Color.Red
        Me.txtLongWordInput.Location = New System.Drawing.Point(518, 157)
        Me.txtLongWordInput.Name = "txtLongWordInput"
        Me.txtLongWordInput.Size = New System.Drawing.Size(58, 22)
        Me.txtLongWordInput.TabIndex = 204
        Me.txtLongWordInput.Text = "1"
        '
        'txtWordInput
        '
        Me.txtWordInput.ForeColor = System.Drawing.Color.Red
        Me.txtWordInput.Location = New System.Drawing.Point(518, 111)
        Me.txtWordInput.Name = "txtWordInput"
        Me.txtWordInput.Size = New System.Drawing.Size(58, 22)
        Me.txtWordInput.TabIndex = 203
        Me.txtWordInput.Text = "1"
        '
        'txtBitInput
        '
        Me.txtBitInput.ForeColor = System.Drawing.Color.Red
        Me.txtBitInput.Location = New System.Drawing.Point(518, 65)
        Me.txtBitInput.Name = "txtBitInput"
        Me.txtBitInput.Size = New System.Drawing.Size(58, 22)
        Me.txtBitInput.TabIndex = 202
        Me.txtBitInput.Text = "1"
        '
        'cmdWordAdd
        '
        Me.cmdWordAdd.Location = New System.Drawing.Point(461, 111)
        Me.cmdWordAdd.Name = "cmdWordAdd"
        Me.cmdWordAdd.Size = New System.Drawing.Size(48, 27)
        Me.cmdWordAdd.TabIndex = 201
        Me.cmdWordAdd.Text = "Add"
        '
        'cmdLongWordAdd
        '
        Me.cmdLongWordAdd.Location = New System.Drawing.Point(461, 157)
        Me.cmdLongWordAdd.Name = "cmdLongWordAdd"
        Me.cmdLongWordAdd.Size = New System.Drawing.Size(48, 28)
        Me.cmdLongWordAdd.TabIndex = 200
        Me.cmdLongWordAdd.Text = "Add"
        '
        'cmdBitSet
        '
        Me.cmdBitSet.Location = New System.Drawing.Point(403, 65)
        Me.cmdBitSet.Name = "cmdBitSet"
        Me.cmdBitSet.Size = New System.Drawing.Size(48, 27)
        Me.cmdBitSet.TabIndex = 199
        Me.cmdBitSet.Text = "Set"
        '
        'cmdWordSet
        '
        Me.cmdWordSet.Location = New System.Drawing.Point(403, 111)
        Me.cmdWordSet.Name = "cmdWordSet"
        Me.cmdWordSet.Size = New System.Drawing.Size(48, 27)
        Me.cmdWordSet.TabIndex = 198
        Me.cmdWordSet.Text = "Set"
        '
        'cmdLongWordSet
        '
        Me.cmdLongWordSet.Location = New System.Drawing.Point(403, 157)
        Me.cmdLongWordSet.Name = "cmdLongWordSet"
        Me.cmdLongWordSet.Size = New System.Drawing.Size(48, 28)
        Me.cmdLongWordSet.TabIndex = 197
        Me.cmdLongWordSet.Text = "Set"
        '
        'cmdOptionalParameterBitGet
        '
        Me.cmdOptionalParameterBitGet.Location = New System.Drawing.Point(346, 65)
        Me.cmdOptionalParameterBitGet.Name = "cmdOptionalParameterBitGet"
        Me.cmdOptionalParameterBitGet.Size = New System.Drawing.Size(48, 27)
        Me.cmdOptionalParameterBitGet.TabIndex = 196
        Me.cmdOptionalParameterBitGet.Text = "Get"
        '
        'cmdOptionalParameterWordGet
        '
        Me.cmdOptionalParameterWordGet.Location = New System.Drawing.Point(346, 111)
        Me.cmdOptionalParameterWordGet.Name = "cmdOptionalParameterWordGet"
        Me.cmdOptionalParameterWordGet.Size = New System.Drawing.Size(48, 27)
        Me.cmdOptionalParameterWordGet.TabIndex = 193
        Me.cmdOptionalParameterWordGet.Text = "Get"
        '
        'cmdOptionalParameterLongWordGet
        '
        Me.cmdOptionalParameterLongWordGet.Location = New System.Drawing.Point(346, 157)
        Me.cmdOptionalParameterLongWordGet.Name = "cmdOptionalParameterLongWordGet"
        Me.cmdOptionalParameterLongWordGet.Size = New System.Drawing.Size(48, 28)
        Me.cmdOptionalParameterLongWordGet.TabIndex = 190
        Me.cmdOptionalParameterLongWordGet.Text = "Get"
        '
        'txtOptionalParameterLongWord
        '
        Me.txtOptionalParameterLongWord.Location = New System.Drawing.Point(250, 157)
        Me.txtOptionalParameterLongWord.Name = "txtOptionalParameterLongWord"
        Me.txtOptionalParameterLongWord.ReadOnly = true
        Me.txtOptionalParameterLongWord.Size = New System.Drawing.Size(76, 22)
        Me.txtOptionalParameterLongWord.TabIndex = 11
        Me.txtOptionalParameterLongWord.Text = "0"
        '
        'txtOptionalParameterWord
        '
        Me.txtOptionalParameterWord.Location = New System.Drawing.Point(250, 111)
        Me.txtOptionalParameterWord.Name = "txtOptionalParameterWord"
        Me.txtOptionalParameterWord.ReadOnly = true
        Me.txtOptionalParameterWord.Size = New System.Drawing.Size(76, 22)
        Me.txtOptionalParameterWord.TabIndex = 10
        Me.txtOptionalParameterWord.Text = "0"
        '
        'txtOptionalParameterBit
        '
        Me.txtOptionalParameterBit.Location = New System.Drawing.Point(250, 65)
        Me.txtOptionalParameterBit.Name = "txtOptionalParameterBit"
        Me.txtOptionalParameterBit.ReadOnly = true
        Me.txtOptionalParameterBit.Size = New System.Drawing.Size(76, 22)
        Me.txtOptionalParameterBit.TabIndex = 9
        Me.txtOptionalParameterBit.Text = "0"
        '
        'Label299
        '
        Me.Label299.Location = New System.Drawing.Point(173, 28)
        Me.Label299.Name = "Label299"
        Me.Label299.Size = New System.Drawing.Size(57, 26)
        Me.Label299.TabIndex = 8
        Me.Label299.Text = "Bit No."
        '
        'txtOptionalParameterBitNo
        '
        Me.txtOptionalParameterBitNo.Location = New System.Drawing.Point(173, 65)
        Me.txtOptionalParameterBitNo.Name = "txtOptionalParameterBitNo"
        Me.txtOptionalParameterBitNo.Size = New System.Drawing.Size(57, 22)
        Me.txtOptionalParameterBitNo.TabIndex = 7
        Me.txtOptionalParameterBitNo.Text = "0"
        '
        'Label300
        '
        Me.Label300.Location = New System.Drawing.Point(96, 28)
        Me.Label300.Name = "Label300"
        Me.Label300.Size = New System.Drawing.Size(58, 26)
        Me.Label300.TabIndex = 6
        Me.Label300.Text = "Index"
        '
        'txtOptionalParameterLongWordIndex
        '
        Me.txtOptionalParameterLongWordIndex.Location = New System.Drawing.Point(96, 157)
        Me.txtOptionalParameterLongWordIndex.Name = "txtOptionalParameterLongWordIndex"
        Me.txtOptionalParameterLongWordIndex.Size = New System.Drawing.Size(58, 22)
        Me.txtOptionalParameterLongWordIndex.TabIndex = 5
        Me.txtOptionalParameterLongWordIndex.Text = "1"
        '
        'Label301
        '
        Me.Label301.Location = New System.Drawing.Point(10, 157)
        Me.Label301.Name = "Label301"
        Me.Label301.Size = New System.Drawing.Size(76, 28)
        Me.Label301.TabIndex = 4
        Me.Label301.Text = "Long Word"
        '
        'txtOptionalParameterWordIndex
        '
        Me.txtOptionalParameterWordIndex.Location = New System.Drawing.Point(96, 111)
        Me.txtOptionalParameterWordIndex.Name = "txtOptionalParameterWordIndex"
        Me.txtOptionalParameterWordIndex.Size = New System.Drawing.Size(58, 22)
        Me.txtOptionalParameterWordIndex.TabIndex = 3
        Me.txtOptionalParameterWordIndex.Text = "1"
        '
        'Label302
        '
        Me.Label302.Location = New System.Drawing.Point(10, 111)
        Me.Label302.Name = "Label302"
        Me.Label302.Size = New System.Drawing.Size(76, 27)
        Me.Label302.TabIndex = 2
        Me.Label302.Text = "Word"
        '
        'txtOptionalParameterBitIndex
        '
        Me.txtOptionalParameterBitIndex.Location = New System.Drawing.Point(96, 65)
        Me.txtOptionalParameterBitIndex.Name = "txtOptionalParameterBitIndex"
        Me.txtOptionalParameterBitIndex.Size = New System.Drawing.Size(58, 22)
        Me.txtOptionalParameterBitIndex.TabIndex = 1
        Me.txtOptionalParameterBitIndex.Text = "1"
        '
        'Label303
        '
        Me.Label303.Location = New System.Drawing.Point(10, 65)
        Me.Label303.Name = "Label303"
        Me.Label303.Size = New System.Drawing.Size(76, 27)
        Me.Label303.TabIndex = 0
        Me.Label303.Text = "Bit"
        '
        'tab_spec
        '
        Me.tab_spec.Controls.Add(Me.txtControlType)
        Me.tab_spec.Controls.Add(Me.Label314)
        Me.tab_spec.Controls.Add(Me.GroupBox26)
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
        Me.tab_spec.Location = New System.Drawing.Point(4, 25)
        Me.tab_spec.Name = "tab_spec"
        Me.tab_spec.Size = New System.Drawing.Size(1019, 498)
        Me.tab_spec.TabIndex = 7
        Me.tab_spec.Text = "Spec"
        '
        'txtControlType
        '
        Me.txtControlType.BackColor = System.Drawing.SystemColors.Control
        Me.txtControlType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtControlType.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtControlType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtControlType.Location = New System.Drawing.Point(278, 222)
        Me.txtControlType.Name = "txtControlType"
        Me.txtControlType.Size = New System.Drawing.Size(327, 36)
        Me.txtControlType.TabIndex = 99
        '
        'Label314
        '
        Me.Label314.Location = New System.Drawing.Point(38, 231)
        Me.Label314.Name = "Label314"
        Me.Label314.Size = New System.Drawing.Size(221, 18)
        Me.Label314.TabIndex = 98
        Me.Label314.Text = "Control Type:"
        '
        'GroupBox26
        '
        Me.GroupBox26.Controls.Add(Me.btnGetPLC3SpecCode)
        Me.GroupBox26.Controls.Add(Me.btnGetPLC2SpecCode)
        Me.GroupBox26.Controls.Add(Me.txtPLCSpecCode)
        Me.GroupBox26.Controls.Add(Me.Label308)
        Me.GroupBox26.Controls.Add(Me.txtPLCSpecCodeBit)
        Me.GroupBox26.Controls.Add(Me.Label309)
        Me.GroupBox26.Controls.Add(Me.txtPLCSpecCodeIndex)
        Me.GroupBox26.Controls.Add(Me.btnGetPLCSpecCode)
        Me.GroupBox26.Location = New System.Drawing.Point(653, 222)
        Me.GroupBox26.Name = "GroupBox26"
        Me.GroupBox26.Size = New System.Drawing.Size(269, 256)
        Me.GroupBox26.TabIndex = 97
        Me.GroupBox26.TabStop = false
        Me.GroupBox26.Text = "General PLC Spec Code"
        '
        'btnGetPLC3SpecCode
        '
        Me.btnGetPLC3SpecCode.Location = New System.Drawing.Point(19, 122)
        Me.btnGetPLC3SpecCode.Name = "btnGetPLC3SpecCode"
        Me.btnGetPLC3SpecCode.Size = New System.Drawing.Size(183, 28)
        Me.btnGetPLC3SpecCode.TabIndex = 103
        Me.btnGetPLC3SpecCode.Text = "Get PLC Spec Code 3"
        '
        'btnGetPLC2SpecCode
        '
        Me.btnGetPLC2SpecCode.Location = New System.Drawing.Point(19, 74)
        Me.btnGetPLC2SpecCode.Name = "btnGetPLC2SpecCode"
        Me.btnGetPLC2SpecCode.Size = New System.Drawing.Size(183, 28)
        Me.btnGetPLC2SpecCode.TabIndex = 102
        Me.btnGetPLC2SpecCode.Text = "Get PLC Spec Code 2"
        '
        'txtPLCSpecCode
        '
        Me.txtPLCSpecCode.Location = New System.Drawing.Point(211, 55)
        Me.txtPLCSpecCode.Name = "txtPLCSpecCode"
        Me.txtPLCSpecCode.ReadOnly = true
        Me.txtPLCSpecCode.Size = New System.Drawing.Size(39, 22)
        Me.txtPLCSpecCode.TabIndex = 101
        Me.txtPLCSpecCode.Text = "0"
        '
        'Label308
        '
        Me.Label308.Location = New System.Drawing.Point(19, 225)
        Me.Label308.Name = "Label308"
        Me.Label308.Size = New System.Drawing.Size(163, 28)
        Me.Label308.TabIndex = 100
        Me.Label308.Text = "Spec Code Bit Number"
        '
        'txtPLCSpecCodeBit
        '
        Me.txtPLCSpecCodeBit.Location = New System.Drawing.Point(211, 225)
        Me.txtPLCSpecCodeBit.Name = "txtPLCSpecCodeBit"
        Me.txtPLCSpecCodeBit.Size = New System.Drawing.Size(39, 22)
        Me.txtPLCSpecCodeBit.TabIndex = 99
        Me.txtPLCSpecCodeBit.Text = "1"
        '
        'Label309
        '
        Me.Label309.Location = New System.Drawing.Point(19, 179)
        Me.Label309.Name = "Label309"
        Me.Label309.Size = New System.Drawing.Size(173, 28)
        Me.Label309.TabIndex = 98
        Me.Label309.Text = "Spec Code Index"
        '
        'txtPLCSpecCodeIndex
        '
        Me.txtPLCSpecCodeIndex.Location = New System.Drawing.Point(211, 179)
        Me.txtPLCSpecCodeIndex.Name = "txtPLCSpecCodeIndex"
        Me.txtPLCSpecCodeIndex.Size = New System.Drawing.Size(39, 22)
        Me.txtPLCSpecCodeIndex.TabIndex = 97
        Me.txtPLCSpecCodeIndex.Text = "1"
        '
        'btnGetPLCSpecCode
        '
        Me.btnGetPLCSpecCode.Location = New System.Drawing.Point(19, 28)
        Me.btnGetPLCSpecCode.Name = "btnGetPLCSpecCode"
        Me.btnGetPLCSpecCode.Size = New System.Drawing.Size(183, 27)
        Me.btnGetPLCSpecCode.TabIndex = 96
        Me.btnGetPLCSpecCode.Text = "Get PLC Spec Code 1"
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
        Me.GroupBox10.Location = New System.Drawing.Point(653, 9)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(269, 203)
        Me.GroupBox10.TabIndex = 96
        Me.GroupBox10.TabStop = false
        Me.GroupBox10.Text = "General NC Spec Code"
        '
        'cmdGetBSpecCode
        '
        Me.cmdGetBSpecCode.Location = New System.Drawing.Point(19, 74)
        Me.cmdGetBSpecCode.Name = "cmdGetBSpecCode"
        Me.cmdGetBSpecCode.Size = New System.Drawing.Size(183, 28)
        Me.cmdGetBSpecCode.TabIndex = 102
        Me.cmdGetBSpecCode.Text = "Get B Spec Code"
        '
        'txtSpecCode
        '
        Me.txtSpecCode.Location = New System.Drawing.Point(211, 55)
        Me.txtSpecCode.Name = "txtSpecCode"
        Me.txtSpecCode.ReadOnly = true
        Me.txtSpecCode.Size = New System.Drawing.Size(39, 22)
        Me.txtSpecCode.TabIndex = 101
        Me.txtSpecCode.Text = "0"
        '
        'Label170
        '
        Me.Label170.Location = New System.Drawing.Point(19, 166)
        Me.Label170.Name = "Label170"
        Me.Label170.Size = New System.Drawing.Size(163, 28)
        Me.Label170.TabIndex = 100
        Me.Label170.Text = "Spec Code Bit Number"
        '
        'txtSpecCodeBit
        '
        Me.txtSpecCodeBit.Location = New System.Drawing.Point(211, 166)
        Me.txtSpecCodeBit.Name = "txtSpecCodeBit"
        Me.txtSpecCodeBit.Size = New System.Drawing.Size(39, 22)
        Me.txtSpecCodeBit.TabIndex = 99
        Me.txtSpecCodeBit.Text = "1"
        '
        'Label169
        '
        Me.Label169.Location = New System.Drawing.Point(19, 120)
        Me.Label169.Name = "Label169"
        Me.Label169.Size = New System.Drawing.Size(173, 28)
        Me.Label169.TabIndex = 98
        Me.Label169.Text = "Spec Code Index"
        '
        'txtSpecCodeIndex
        '
        Me.txtSpecCodeIndex.Location = New System.Drawing.Point(211, 120)
        Me.txtSpecCodeIndex.Name = "txtSpecCodeIndex"
        Me.txtSpecCodeIndex.Size = New System.Drawing.Size(39, 22)
        Me.txtSpecCodeIndex.TabIndex = 97
        Me.txtSpecCodeIndex.Text = "1"
        '
        'cmdGetSpecCode
        '
        Me.cmdGetSpecCode.Location = New System.Drawing.Point(19, 28)
        Me.cmdGetSpecCode.Name = "cmdGetSpecCode"
        Me.cmdGetSpecCode.Size = New System.Drawing.Size(183, 27)
        Me.cmdGetSpecCode.TabIndex = 96
        Me.cmdGetSpecCode.Text = "Get Spec Code"
        '
        'txtMachineSerial
        '
        Me.txtMachineSerial.BackColor = System.Drawing.SystemColors.Control
        Me.txtMachineSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineSerial.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtMachineSerial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtMachineSerial.Location = New System.Drawing.Point(278, 175)
        Me.txtMachineSerial.Name = "txtMachineSerial"
        Me.txtMachineSerial.Size = New System.Drawing.Size(327, 36)
        Me.txtMachineSerial.TabIndex = 89
        '
        'txtMachineName
        '
        Me.txtMachineName.BackColor = System.Drawing.SystemColors.Control
        Me.txtMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtMachineName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtMachineName.Location = New System.Drawing.Point(278, 129)
        Me.txtMachineName.Name = "txtMachineName"
        Me.txtMachineName.Size = New System.Drawing.Size(327, 36)
        Me.txtMachineName.TabIndex = 88
        '
        'Label144
        '
        Me.Label144.Location = New System.Drawing.Point(38, 185)
        Me.Label144.Name = "Label144"
        Me.Label144.Size = New System.Drawing.Size(221, 18)
        Me.Label144.TabIndex = 87
        Me.Label144.Text = "Machine Serial:"
        '
        'Label143
        '
        Me.Label143.Location = New System.Drawing.Point(38, 138)
        Me.Label143.Name = "Label143"
        Me.Label143.Size = New System.Drawing.Size(221, 19)
        Me.Label143.TabIndex = 86
        Me.Label143.Text = "Machine Name:"
        '
        'Label66
        '
        Me.Label66.Location = New System.Drawing.Point(38, 55)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(164, 19)
        Me.Label66.TabIndex = 85
        Me.Label66.Text = "Option Spec Code"
        '
        'specCombo
        '
        Me.specCombo.Location = New System.Drawing.Point(278, 55)
        Me.specCombo.Name = "specCombo"
        Me.specCombo.Size = New System.Drawing.Size(183, 24)
        Me.specCombo.TabIndex = 84
        '
        'specUpdateButton
        '
        Me.specUpdateButton.Location = New System.Drawing.Point(38, 9)
        Me.specUpdateButton.Name = "specUpdateButton"
        Me.specUpdateButton.Size = New System.Drawing.Size(87, 28)
        Me.specUpdateButton.TabIndex = 83
        Me.specUpdateButton.Text = "Update"
        '
        'specCode
        '
        Me.specCode.Location = New System.Drawing.Point(278, 92)
        Me.specCode.Name = "specCode"
        Me.specCode.Size = New System.Drawing.Size(212, 22)
        Me.specCode.TabIndex = 82
        '
        'Label63
        '
        Me.Label63.Location = New System.Drawing.Point(38, 92)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(164, 19)
        Me.Label63.TabIndex = 81
        Me.Label63.Text = "Option Spec Code"
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
        Me.Tools2_2.Location = New System.Drawing.Point(4, 25)
        Me.Tools2_2.Name = "Tools2_2"
        Me.Tools2_2.Size = New System.Drawing.Size(1019, 498)
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
        Me.GroupBox21.Location = New System.Drawing.Point(8, 304)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Size = New System.Drawing.Size(912, 128)
        Me.GroupBox21.TabIndex = 313
        Me.GroupBox21.TabStop = false
        Me.GroupBox21.Text = "Tool Pot"
        '
        'txtTools2_ToolInPot
        '
        Me.txtTools2_ToolInPot.Location = New System.Drawing.Point(600, 24)
        Me.txtTools2_ToolInPot.Name = "txtTools2_ToolInPot"
        Me.txtTools2_ToolInPot.ReadOnly = true
        Me.txtTools2_ToolInPot.Size = New System.Drawing.Size(80, 22)
        Me.txtTools2_ToolInPot.TabIndex = 320
        Me.txtTools2_ToolInPot.Text = "0"
        '
        'Label252
        '
        Me.Label252.Location = New System.Drawing.Point(384, 24)
        Me.Label252.Name = "Label252"
        Me.Label252.Size = New System.Drawing.Size(200, 19)
        Me.Label252.TabIndex = 319
        Me.Label252.Text = "Random ATC - Tool in Pot"
        '
        'Label249
        '
        Me.Label249.Location = New System.Drawing.Point(10, 55)
        Me.Label249.Name = "Label249"
        Me.Label249.Size = New System.Drawing.Size(115, 19)
        Me.Label249.TabIndex = 302
        Me.Label249.Text = "Standard Tool:"
        '
        'cboToolID_ToolKind
        '
        Me.cboToolID_ToolKind.Location = New System.Drawing.Point(600, 56)
        Me.cboToolID_ToolKind.Name = "cboToolID_ToolKind"
        Me.cboToolID_ToolKind.Size = New System.Drawing.Size(86, 24)
        Me.cboToolID_ToolKind.TabIndex = 318
        Me.cboToolID_ToolKind.Text = "Tool Kind"
        '
        'cmdToolID_ToolKind_Set
        '
        Me.cmdToolID_ToolKind_Set.Location = New System.Drawing.Point(696, 56)
        Me.cmdToolID_ToolKind_Set.Name = "cmdToolID_ToolKind_Set"
        Me.cmdToolID_ToolKind_Set.Size = New System.Drawing.Size(48, 28)
        Me.cmdToolID_ToolKind_Set.TabIndex = 317
        Me.cmdToolID_ToolKind_Set.Text = "Set"
        '
        'Label235
        '
        Me.Label235.Location = New System.Drawing.Point(384, 56)
        Me.Label235.Name = "Label235"
        Me.Label235.Size = New System.Drawing.Size(76, 19)
        Me.Label235.TabIndex = 261
        Me.Label235.Text = "Tool Kind"
        '
        'txtToolID_ToolKind
        '
        Me.txtToolID_ToolKind.Location = New System.Drawing.Point(464, 56)
        Me.txtToolID_ToolKind.Name = "txtToolID_ToolKind"
        Me.txtToolID_ToolKind.ReadOnly = true
        Me.txtToolID_ToolKind.Size = New System.Drawing.Size(125, 22)
        Me.txtToolID_ToolKind.TabIndex = 262
        Me.txtToolID_ToolKind.Text = "0"
        '
        'cmdToolID_AdjustmentTool_Set
        '
        Me.cmdToolID_AdjustmentTool_Set.Location = New System.Drawing.Point(317, 18)
        Me.cmdToolID_AdjustmentTool_Set.Name = "cmdToolID_AdjustmentTool_Set"
        Me.cmdToolID_AdjustmentTool_Set.Size = New System.Drawing.Size(48, 28)
        Me.cmdToolID_AdjustmentTool_Set.TabIndex = 300
        Me.cmdToolID_AdjustmentTool_Set.Text = "Set"
        '
        'txtToolID_AdjustmentTool
        '
        Me.txtToolID_AdjustmentTool.Location = New System.Drawing.Point(134, 18)
        Me.txtToolID_AdjustmentTool.Name = "txtToolID_AdjustmentTool"
        Me.txtToolID_AdjustmentTool.ReadOnly = true
        Me.txtToolID_AdjustmentTool.Size = New System.Drawing.Size(77, 22)
        Me.txtToolID_AdjustmentTool.TabIndex = 298
        Me.txtToolID_AdjustmentTool.Text = "0"
        '
        'Label248
        '
        Me.Label248.Location = New System.Drawing.Point(10, 18)
        Me.Label248.Name = "Label248"
        Me.Label248.Size = New System.Drawing.Size(115, 19)
        Me.Label248.TabIndex = 297
        Me.Label248.Text = "Adjustment Tool:"
        '
        'Label250
        '
        Me.Label250.Location = New System.Drawing.Point(10, 92)
        Me.Label250.Name = "Label250"
        Me.Label250.Size = New System.Drawing.Size(115, 19)
        Me.Label250.TabIndex = 306
        Me.Label250.Text = "Pot In Use:"
        '
        'txtToolID_PotInUse
        '
        Me.txtToolID_PotInUse.Location = New System.Drawing.Point(134, 92)
        Me.txtToolID_PotInUse.Name = "txtToolID_PotInUse"
        Me.txtToolID_PotInUse.ReadOnly = true
        Me.txtToolID_PotInUse.Size = New System.Drawing.Size(77, 22)
        Me.txtToolID_PotInUse.TabIndex = 307
        Me.txtToolID_PotInUse.Text = "0"
        '
        'cmdToolID_PotInUse_Set
        '
        Me.cmdToolID_PotInUse_Set.Location = New System.Drawing.Point(317, 92)
        Me.cmdToolID_PotInUse_Set.Name = "cmdToolID_PotInUse_Set"
        Me.cmdToolID_PotInUse_Set.Size = New System.Drawing.Size(48, 28)
        Me.cmdToolID_PotInUse_Set.TabIndex = 308
        Me.cmdToolID_PotInUse_Set.Text = "Set"
        '
        'cboYesNo_PotInUse
        '
        Me.cboYesNo_PotInUse.Location = New System.Drawing.Point(221, 92)
        Me.cboYesNo_PotInUse.Name = "cboYesNo_PotInUse"
        Me.cboYesNo_PotInUse.Size = New System.Drawing.Size(86, 24)
        Me.cboYesNo_PotInUse.TabIndex = 309
        Me.cboYesNo_PotInUse.Text = "Yes/No"
        '
        'cboYesNo_AdjustmentTool
        '
        Me.cboYesNo_AdjustmentTool.Location = New System.Drawing.Point(221, 18)
        Me.cboYesNo_AdjustmentTool.Name = "cboYesNo_AdjustmentTool"
        Me.cboYesNo_AdjustmentTool.Size = New System.Drawing.Size(86, 24)
        Me.cboYesNo_AdjustmentTool.TabIndex = 301
        Me.cboYesNo_AdjustmentTool.Text = "Yes/No"
        '
        'cboYesNo_StandardTool
        '
        Me.cboYesNo_StandardTool.Location = New System.Drawing.Point(221, 55)
        Me.cboYesNo_StandardTool.Name = "cboYesNo_StandardTool"
        Me.cboYesNo_StandardTool.Size = New System.Drawing.Size(86, 24)
        Me.cboYesNo_StandardTool.TabIndex = 305
        Me.cboYesNo_StandardTool.Text = "Yes/No"
        '
        'cmdToolID_StandardTool_Set
        '
        Me.cmdToolID_StandardTool_Set.Location = New System.Drawing.Point(317, 55)
        Me.cmdToolID_StandardTool_Set.Name = "cmdToolID_StandardTool_Set"
        Me.cmdToolID_StandardTool_Set.Size = New System.Drawing.Size(48, 28)
        Me.cmdToolID_StandardTool_Set.TabIndex = 304
        Me.cmdToolID_StandardTool_Set.Text = "Set"
        '
        'txtToolID_StandardTool
        '
        Me.txtToolID_StandardTool.Location = New System.Drawing.Point(134, 55)
        Me.txtToolID_StandardTool.Name = "txtToolID_StandardTool"
        Me.txtToolID_StandardTool.ReadOnly = true
        Me.txtToolID_StandardTool.Size = New System.Drawing.Size(77, 22)
        Me.txtToolID_StandardTool.TabIndex = 303
        Me.txtToolID_StandardTool.Text = "0"
        '
        'lstToolID_Update
        '
        Me.lstToolID_Update.ItemHeight = 16
        Me.lstToolID_Update.Location = New System.Drawing.Point(624, 9)
        Me.lstToolID_Update.Name = "lstToolID_Update"
        Me.lstToolID_Update.Size = New System.Drawing.Size(298, 68)
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
        Me.GroupBox19.Location = New System.Drawing.Point(10, 40)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Size = New System.Drawing.Size(393, 251)
        Me.GroupBox19.TabIndex = 311
        Me.GroupBox19.TabStop = false
        Me.GroupBox19.Text = "Register/Un-Register Tool"
        '
        'txtToolID_RATC_PotNo
        '
        Me.txtToolID_RATC_PotNo.Location = New System.Drawing.Point(184, 128)
        Me.txtToolID_RATC_PotNo.Name = "txtToolID_RATC_PotNo"
        Me.txtToolID_RATC_PotNo.ReadOnly = true
        Me.txtToolID_RATC_PotNo.Size = New System.Drawing.Size(48, 22)
        Me.txtToolID_RATC_PotNo.TabIndex = 319
        Me.txtToolID_RATC_PotNo.Text = "0"
        '
        'txtToolID_RATC_PotNoValue
        '
        Me.txtToolID_RATC_PotNoValue.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_RATC_PotNoValue.Location = New System.Drawing.Point(240, 128)
        Me.txtToolID_RATC_PotNoValue.Name = "txtToolID_RATC_PotNoValue"
        Me.txtToolID_RATC_PotNoValue.Size = New System.Drawing.Size(144, 22)
        Me.txtToolID_RATC_PotNoValue.TabIndex = 318
        Me.txtToolID_RATC_PotNoValue.Text = "0"
        '
        'Label251
        '
        Me.Label251.Location = New System.Drawing.Point(16, 128)
        Me.Label251.Name = "Label251"
        Me.Label251.Size = New System.Drawing.Size(144, 16)
        Me.Label251.TabIndex = 317
        Me.Label251.Text = "Random ATC Pot No:"
        '
        'chkToolID_DummyTool
        '
        Me.chkToolID_DummyTool.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkToolID_DummyTool.Location = New System.Drawing.Point(16, 168)
        Me.chkToolID_DummyTool.Name = "chkToolID_DummyTool"
        Me.chkToolID_DummyTool.Size = New System.Drawing.Size(112, 28)
        Me.chkToolID_DummyTool.TabIndex = 316
        Me.chkToolID_DummyTool.Text = "Dummy Tool"
        '
        'txtToolID_ToolNameValue
        '
        Me.txtToolID_ToolNameValue.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_ToolNameValue.Location = New System.Drawing.Point(240, 92)
        Me.txtToolID_ToolNameValue.Name = "txtToolID_ToolNameValue"
        Me.txtToolID_ToolNameValue.Size = New System.Drawing.Size(144, 22)
        Me.txtToolID_ToolNameValue.TabIndex = 315
        Me.txtToolID_ToolNameValue.Text = "0"
        '
        'txtToolID_SerialNo
        '
        Me.txtToolID_SerialNo.Location = New System.Drawing.Point(134, 55)
        Me.txtToolID_SerialNo.Name = "txtToolID_SerialNo"
        Me.txtToolID_SerialNo.ReadOnly = true
        Me.txtToolID_SerialNo.Size = New System.Drawing.Size(96, 22)
        Me.txtToolID_SerialNo.TabIndex = 276
        Me.txtToolID_SerialNo.Text = "0"
        '
        'txtToolID_ToolName
        '
        Me.txtToolID_ToolName.Location = New System.Drawing.Point(96, 92)
        Me.txtToolID_ToolName.Name = "txtToolID_ToolName"
        Me.txtToolID_ToolName.ReadOnly = true
        Me.txtToolID_ToolName.Size = New System.Drawing.Size(134, 22)
        Me.txtToolID_ToolName.TabIndex = 288
        Me.txtToolID_ToolName.Text = "0"
        '
        'Label244
        '
        Me.Label244.Location = New System.Drawing.Point(10, 92)
        Me.Label244.Name = "Label244"
        Me.Label244.Size = New System.Drawing.Size(76, 19)
        Me.Label244.TabIndex = 287
        Me.Label244.Text = "Tool Name"
        '
        'txtToolID_GroupNoValue
        '
        Me.txtToolID_GroupNoValue.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_GroupNoValue.Location = New System.Drawing.Point(240, 18)
        Me.txtToolID_GroupNoValue.Name = "txtToolID_GroupNoValue"
        Me.txtToolID_GroupNoValue.Size = New System.Drawing.Size(144, 22)
        Me.txtToolID_GroupNoValue.TabIndex = 259
        Me.txtToolID_GroupNoValue.Text = "0"
        '
        'txtToolID_GroupNo
        '
        Me.txtToolID_GroupNo.Location = New System.Drawing.Point(134, 18)
        Me.txtToolID_GroupNo.Name = "txtToolID_GroupNo"
        Me.txtToolID_GroupNo.ReadOnly = true
        Me.txtToolID_GroupNo.Size = New System.Drawing.Size(96, 22)
        Me.txtToolID_GroupNo.TabIndex = 256
        Me.txtToolID_GroupNo.Text = "0"
        '
        'Label186
        '
        Me.Label186.Location = New System.Drawing.Point(10, 65)
        Me.Label186.Name = "Label186"
        Me.Label186.Size = New System.Drawing.Size(96, 18)
        Me.Label186.TabIndex = 275
        Me.Label186.Text = "Serial Number:"
        '
        'Label241
        '
        Me.Label241.Location = New System.Drawing.Point(10, 28)
        Me.Label241.Name = "Label241"
        Me.Label241.Size = New System.Drawing.Size(105, 18)
        Me.Label241.TabIndex = 255
        Me.Label241.Text = "Group Number:"
        '
        'txtToolID_SerialNoValue
        '
        Me.txtToolID_SerialNoValue.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_SerialNoValue.Location = New System.Drawing.Point(240, 55)
        Me.txtToolID_SerialNoValue.Name = "txtToolID_SerialNoValue"
        Me.txtToolID_SerialNoValue.Size = New System.Drawing.Size(144, 22)
        Me.txtToolID_SerialNoValue.TabIndex = 277
        Me.txtToolID_SerialNoValue.Text = "0"
        '
        'cmdToolID_UnRegisterToolPot
        '
        Me.cmdToolID_UnRegisterToolPot.Location = New System.Drawing.Point(221, 208)
        Me.cmdToolID_UnRegisterToolPot.Name = "cmdToolID_UnRegisterToolPot"
        Me.cmdToolID_UnRegisterToolPot.Size = New System.Drawing.Size(163, 29)
        Me.cmdToolID_UnRegisterToolPot.TabIndex = 313
        Me.cmdToolID_UnRegisterToolPot.Text = "Un-Register Tool Pot"
        '
        'cmdToolID_RegisterToolPot
        '
        Me.cmdToolID_RegisterToolPot.Location = New System.Drawing.Point(10, 208)
        Me.cmdToolID_RegisterToolPot.Name = "cmdToolID_RegisterToolPot"
        Me.cmdToolID_RegisterToolPot.Size = New System.Drawing.Size(182, 29)
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
        Me.GroupBox18.Location = New System.Drawing.Point(416, 128)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Size = New System.Drawing.Size(442, 167)
        Me.GroupBox18.TabIndex = 310
        Me.GroupBox18.TabStop = false
        Me.GroupBox18.Text = "Tool Shape"
        '
        'cmdToolID_ToolAngle_Add
        '
        Me.cmdToolID_ToolAngle_Add.Location = New System.Drawing.Point(384, 92)
        Me.cmdToolID_ToolAngle_Add.Name = "cmdToolID_ToolAngle_Add"
        Me.cmdToolID_ToolAngle_Add.Size = New System.Drawing.Size(48, 28)
        Me.cmdToolID_ToolAngle_Add.TabIndex = 307
        Me.cmdToolID_ToolAngle_Add.Text = "Add"
        '
        'cmdToolID_ToolNoseDiameter_Add
        '
        Me.cmdToolID_ToolNoseDiameter_Add.Location = New System.Drawing.Point(384, 129)
        Me.cmdToolID_ToolNoseDiameter_Add.Name = "cmdToolID_ToolNoseDiameter_Add"
        Me.cmdToolID_ToolNoseDiameter_Add.Size = New System.Drawing.Size(48, 28)
        Me.cmdToolID_ToolNoseDiameter_Add.TabIndex = 309
        Me.cmdToolID_ToolNoseDiameter_Add.Text = "Add"
        '
        'cmdToolID_ToolDiameter_Add
        '
        Me.cmdToolID_ToolDiameter_Add.Location = New System.Drawing.Point(384, 55)
        Me.cmdToolID_ToolDiameter_Add.Name = "cmdToolID_ToolDiameter_Add"
        Me.cmdToolID_ToolDiameter_Add.Size = New System.Drawing.Size(48, 28)
        Me.cmdToolID_ToolDiameter_Add.TabIndex = 308
        Me.cmdToolID_ToolDiameter_Add.Text = "Add"
        '
        'cboToolID_ToolType
        '
        Me.cboToolID_ToolType.Location = New System.Drawing.Point(240, 18)
        Me.cboToolID_ToolType.Name = "cboToolID_ToolType"
        Me.cboToolID_ToolType.Size = New System.Drawing.Size(134, 24)
        Me.cboToolID_ToolType.TabIndex = 306
        Me.cboToolID_ToolType.Text = "Tool Type"
        '
        'Label246
        '
        Me.Label246.Location = New System.Drawing.Point(10, 129)
        Me.Label246.Name = "Label246"
        Me.Label246.Size = New System.Drawing.Size(134, 19)
        Me.Label246.TabIndex = 289
        Me.Label246.Text = "Tool Nose Diameter:"
        '
        'Label247
        '
        Me.Label247.Location = New System.Drawing.Point(10, 18)
        Me.Label247.Name = "Label247"
        Me.Label247.Size = New System.Drawing.Size(134, 19)
        Me.Label247.TabIndex = 293
        Me.Label247.Text = "Tool Type:"
        '
        'txtToolID_ToolType
        '
        Me.txtToolID_ToolType.Location = New System.Drawing.Point(154, 18)
        Me.txtToolID_ToolType.Name = "txtToolID_ToolType"
        Me.txtToolID_ToolType.ReadOnly = true
        Me.txtToolID_ToolType.Size = New System.Drawing.Size(76, 22)
        Me.txtToolID_ToolType.TabIndex = 294
        Me.txtToolID_ToolType.Text = "0"
        '
        'cmdToolID_ToolType_Set
        '
        Me.cmdToolID_ToolType_Set.Location = New System.Drawing.Point(384, 18)
        Me.cmdToolID_ToolType_Set.Name = "cmdToolID_ToolType_Set"
        Me.cmdToolID_ToolType_Set.Size = New System.Drawing.Size(48, 28)
        Me.cmdToolID_ToolType_Set.TabIndex = 296
        Me.cmdToolID_ToolType_Set.Text = "Set"
        '
        'cmdToolID_ToolAngle_Set
        '
        Me.cmdToolID_ToolAngle_Set.Location = New System.Drawing.Point(326, 92)
        Me.cmdToolID_ToolAngle_Set.Name = "cmdToolID_ToolAngle_Set"
        Me.cmdToolID_ToolAngle_Set.Size = New System.Drawing.Size(48, 28)
        Me.cmdToolID_ToolAngle_Set.TabIndex = 282
        Me.cmdToolID_ToolAngle_Set.Text = "Set"
        '
        'txtToolID_ToolAngleValue
        '
        Me.txtToolID_ToolAngleValue.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_ToolAngleValue.Location = New System.Drawing.Point(240, 92)
        Me.txtToolID_ToolAngleValue.Name = "txtToolID_ToolAngleValue"
        Me.txtToolID_ToolAngleValue.Size = New System.Drawing.Size(77, 22)
        Me.txtToolID_ToolAngleValue.TabIndex = 281
        Me.txtToolID_ToolAngleValue.Text = "0"
        '
        'Label242
        '
        Me.Label242.Location = New System.Drawing.Point(10, 92)
        Me.Label242.Name = "Label242"
        Me.Label242.Size = New System.Drawing.Size(134, 19)
        Me.Label242.TabIndex = 279
        Me.Label242.Text = "Tool Angle:"
        '
        'txtToolID_ToolAngle
        '
        Me.txtToolID_ToolAngle.Location = New System.Drawing.Point(154, 92)
        Me.txtToolID_ToolAngle.Name = "txtToolID_ToolAngle"
        Me.txtToolID_ToolAngle.ReadOnly = true
        Me.txtToolID_ToolAngle.Size = New System.Drawing.Size(76, 22)
        Me.txtToolID_ToolAngle.TabIndex = 280
        Me.txtToolID_ToolAngle.Text = "0"
        '
        'cmdToolID_ToolNoseDiameter_Set
        '
        Me.cmdToolID_ToolNoseDiameter_Set.Location = New System.Drawing.Point(326, 129)
        Me.cmdToolID_ToolNoseDiameter_Set.Name = "cmdToolID_ToolNoseDiameter_Set"
        Me.cmdToolID_ToolNoseDiameter_Set.Size = New System.Drawing.Size(48, 28)
        Me.cmdToolID_ToolNoseDiameter_Set.TabIndex = 292
        Me.cmdToolID_ToolNoseDiameter_Set.Text = "Set"
        '
        'cmdToolID_ToolDiameter_Set
        '
        Me.cmdToolID_ToolDiameter_Set.Location = New System.Drawing.Point(326, 55)
        Me.cmdToolID_ToolDiameter_Set.Name = "cmdToolID_ToolDiameter_Set"
        Me.cmdToolID_ToolDiameter_Set.Size = New System.Drawing.Size(48, 28)
        Me.cmdToolID_ToolDiameter_Set.TabIndex = 286
        Me.cmdToolID_ToolDiameter_Set.Text = "Set"
        '
        'txtToolID_ToolDiameterValue
        '
        Me.txtToolID_ToolDiameterValue.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_ToolDiameterValue.Location = New System.Drawing.Point(240, 55)
        Me.txtToolID_ToolDiameterValue.Name = "txtToolID_ToolDiameterValue"
        Me.txtToolID_ToolDiameterValue.Size = New System.Drawing.Size(77, 22)
        Me.txtToolID_ToolDiameterValue.TabIndex = 285
        Me.txtToolID_ToolDiameterValue.Text = "0"
        '
        'txtToolID_ToolNoseDiameterValue
        '
        Me.txtToolID_ToolNoseDiameterValue.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_ToolNoseDiameterValue.Location = New System.Drawing.Point(240, 129)
        Me.txtToolID_ToolNoseDiameterValue.Name = "txtToolID_ToolNoseDiameterValue"
        Me.txtToolID_ToolNoseDiameterValue.Size = New System.Drawing.Size(77, 22)
        Me.txtToolID_ToolNoseDiameterValue.TabIndex = 291
        Me.txtToolID_ToolNoseDiameterValue.Text = "0"
        '
        'Label243
        '
        Me.Label243.Location = New System.Drawing.Point(10, 55)
        Me.Label243.Name = "Label243"
        Me.Label243.Size = New System.Drawing.Size(134, 19)
        Me.Label243.TabIndex = 283
        Me.Label243.Text = "Tool Diameter:"
        '
        'txtToolID_ToolNoseDiameter
        '
        Me.txtToolID_ToolNoseDiameter.Location = New System.Drawing.Point(154, 129)
        Me.txtToolID_ToolNoseDiameter.Name = "txtToolID_ToolNoseDiameter"
        Me.txtToolID_ToolNoseDiameter.ReadOnly = true
        Me.txtToolID_ToolNoseDiameter.Size = New System.Drawing.Size(76, 22)
        Me.txtToolID_ToolNoseDiameter.TabIndex = 290
        Me.txtToolID_ToolNoseDiameter.Text = "0"
        '
        'txtToolID_ToolDiameter
        '
        Me.txtToolID_ToolDiameter.Location = New System.Drawing.Point(154, 55)
        Me.txtToolID_ToolDiameter.Name = "txtToolID_ToolDiameter"
        Me.txtToolID_ToolDiameter.ReadOnly = true
        Me.txtToolID_ToolDiameter.Size = New System.Drawing.Size(76, 22)
        Me.txtToolID_ToolDiameter.TabIndex = 284
        Me.txtToolID_ToolDiameter.Text = "0"
        '
        'cboToolID_CarrierStatus
        '
        Me.cboToolID_CarrierStatus.Location = New System.Drawing.Point(704, 88)
        Me.cboToolID_CarrierStatus.Name = "cboToolID_CarrierStatus"
        Me.cboToolID_CarrierStatus.Size = New System.Drawing.Size(154, 24)
        Me.cboToolID_CarrierStatus.TabIndex = 274
        Me.cboToolID_CarrierStatus.Text = "CarrierStatus"
        '
        'cmdToolID_CarrierStatus_Set
        '
        Me.cmdToolID_CarrierStatus_Set.Location = New System.Drawing.Point(872, 88)
        Me.cmdToolID_CarrierStatus_Set.Name = "cmdToolID_CarrierStatus_Set"
        Me.cmdToolID_CarrierStatus_Set.Size = New System.Drawing.Size(48, 28)
        Me.cmdToolID_CarrierStatus_Set.TabIndex = 273
        Me.cmdToolID_CarrierStatus_Set.Text = "Set"
        '
        'txtToolID_CarrierStatus
        '
        Me.txtToolID_CarrierStatus.Location = New System.Drawing.Point(576, 88)
        Me.txtToolID_CarrierStatus.Name = "txtToolID_CarrierStatus"
        Me.txtToolID_CarrierStatus.ReadOnly = true
        Me.txtToolID_CarrierStatus.Size = New System.Drawing.Size(125, 22)
        Me.txtToolID_CarrierStatus.TabIndex = 271
        Me.txtToolID_CarrierStatus.Text = "0"
        '
        'Label183
        '
        Me.Label183.Location = New System.Drawing.Point(480, 88)
        Me.Label183.Name = "Label183"
        Me.Label183.Size = New System.Drawing.Size(106, 18)
        Me.Label183.TabIndex = 270
        Me.Label183.Text = "Carrier Status:"
        '
        'Label213
        '
        Me.Label213.Location = New System.Drawing.Point(202, 18)
        Me.Label213.Name = "Label213"
        Me.Label213.Size = New System.Drawing.Size(76, 19)
        Me.Label213.TabIndex = 269
        Me.Label213.Text = "Data Unit"
        '
        'cmdToolID_DataUnit_2_Set
        '
        Me.cmdToolID_DataUnit_2_Set.Location = New System.Drawing.Point(413, 9)
        Me.cmdToolID_DataUnit_2_Set.Name = "cmdToolID_DataUnit_2_Set"
        Me.cmdToolID_DataUnit_2_Set.Size = New System.Drawing.Size(57, 27)
        Me.cmdToolID_DataUnit_2_Set.TabIndex = 267
        Me.cmdToolID_DataUnit_2_Set.Text = "Set"
        '
        'cboToolID_DataUnit_2
        '
        Me.cboToolID_DataUnit_2.Location = New System.Drawing.Point(288, 9)
        Me.cboToolID_DataUnit_2.Name = "cboToolID_DataUnit_2"
        Me.cboToolID_DataUnit_2.Size = New System.Drawing.Size(115, 24)
        Me.cboToolID_DataUnit_2.TabIndex = 266
        '
        'Label230
        '
        Me.Label230.Location = New System.Drawing.Point(518, 55)
        Me.Label230.Name = "Label230"
        Me.Label230.Size = New System.Drawing.Size(96, 37)
        Me.Label230.TabIndex = 265
        Me.Label230.Text = "Values with no parameters :"
        Me.Label230.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdToolID_2_Update
        '
        Me.cmdToolID_2_Update.Location = New System.Drawing.Point(528, 9)
        Me.cmdToolID_2_Update.Name = "cmdToolID_2_Update"
        Me.cmdToolID_2_Update.Size = New System.Drawing.Size(86, 28)
        Me.cmdToolID_2_Update.TabIndex = 264
        Me.cmdToolID_2_Update.Text = "Update"
        '
        'txtToolID_PotNo_2
        '
        Me.txtToolID_PotNo_2.Location = New System.Drawing.Point(115, 9)
        Me.txtToolID_PotNo_2.Name = "txtToolID_PotNo_2"
        Me.txtToolID_PotNo_2.Size = New System.Drawing.Size(77, 22)
        Me.txtToolID_PotNo_2.TabIndex = 258
        Me.txtToolID_PotNo_2.Text = "1"
        '
        'Label236
        '
        Me.Label236.Location = New System.Drawing.Point(10, 9)
        Me.Label236.Name = "Label236"
        Me.Label236.Size = New System.Drawing.Size(76, 19)
        Me.Label236.TabIndex = 257
        Me.Label236.Text = "Tool/Pot Number"
        '
        'tab_coolant
        '
        Me.tab_coolant.Controls.Add(Me.coolantUpdateButton)
        Me.tab_coolant.Controls.Add(Me.coolantChipCondition)
        Me.tab_coolant.Controls.Add(Me.Label36)
        Me.tab_coolant.Location = New System.Drawing.Point(4, 25)
        Me.tab_coolant.Name = "tab_coolant"
        Me.tab_coolant.Size = New System.Drawing.Size(1019, 498)
        Me.tab_coolant.TabIndex = 4
        Me.tab_coolant.Text = "Coolant"
        '
        'coolantUpdateButton
        '
        Me.coolantUpdateButton.Location = New System.Drawing.Point(346, 37)
        Me.coolantUpdateButton.Name = "coolantUpdateButton"
        Me.coolantUpdateButton.Size = New System.Drawing.Size(124, 28)
        Me.coolantUpdateButton.TabIndex = 78
        Me.coolantUpdateButton.Text = "Update"
        '
        'coolantChipCondition
        '
        Me.coolantChipCondition.BackColor = System.Drawing.SystemColors.Control
        Me.coolantChipCondition.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.coolantChipCondition.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.coolantChipCondition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.coolantChipCondition.Location = New System.Drawing.Point(456, 138)
        Me.coolantChipCondition.Name = "coolantChipCondition"
        Me.coolantChipCondition.Size = New System.Drawing.Size(192, 29)
        Me.coolantChipCondition.TabIndex = 77
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label36.Location = New System.Drawing.Point(216, 138)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(221, 19)
        Me.Label36.TabIndex = 76
        Me.Label36.Text = "Chip Flush Condition :"
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
        Me.tab_MacManOperatingHistory.Location = New System.Drawing.Point(4, 25)
        Me.tab_MacManOperatingHistory.Name = "tab_MacManOperatingHistory"
        Me.tab_MacManOperatingHistory.Size = New System.Drawing.Size(1019, 498)
        Me.tab_MacManOperatingHistory.TabIndex = 16
        Me.tab_MacManOperatingHistory.Text = "Macman Operating History"
        '
        'Label204
        '
        Me.Label204.Location = New System.Drawing.Point(509, 18)
        Me.Label204.Name = "Label204"
        Me.Label204.Size = New System.Drawing.Size(259, 28)
        Me.Label204.TabIndex = 32
        Me.Label204.Text = "Maximum no of operating history"
        '
        'mopnhMaxNoofReports
        '
        Me.mopnhMaxNoofReports.Location = New System.Drawing.Point(787, 18)
        Me.mopnhMaxNoofReports.Name = "mopnhMaxNoofReports"
        Me.mopnhMaxNoofReports.Size = New System.Drawing.Size(87, 22)
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
        Me.GroupBox5.Location = New System.Drawing.Point(461, 55)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(422, 379)
        Me.GroupBox5.TabIndex = 30
        Me.GroupBox5.TabStop = false
        Me.GroupBox5.Text = "Previousday Operating History"
        '
        'mopnhPrevAlarmonTime
        '
        Me.mopnhPrevAlarmonTime.Location = New System.Drawing.Point(144, 332)
        Me.mopnhPrevAlarmonTime.Name = "mopnhPrevAlarmonTime"
        Me.mopnhPrevAlarmonTime.Size = New System.Drawing.Size(269, 22)
        Me.mopnhPrevAlarmonTime.TabIndex = 45
        Me.mopnhPrevAlarmonTime.Text = "0"
        '
        'mopnhPrevExternalInputTime
        '
        Me.mopnhPrevExternalInputTime.Location = New System.Drawing.Point(144, 305)
        Me.mopnhPrevExternalInputTime.Name = "mopnhPrevExternalInputTime"
        Me.mopnhPrevExternalInputTime.Size = New System.Drawing.Size(269, 22)
        Me.mopnhPrevExternalInputTime.TabIndex = 44
        Me.mopnhPrevExternalInputTime.Text = "0"
        '
        'mopnhPrevSpindleRunTime
        '
        Me.mopnhPrevSpindleRunTime.Location = New System.Drawing.Point(144, 277)
        Me.mopnhPrevSpindleRunTime.Name = "mopnhPrevSpindleRunTime"
        Me.mopnhPrevSpindleRunTime.Size = New System.Drawing.Size(269, 22)
        Me.mopnhPrevSpindleRunTime.TabIndex = 43
        Me.mopnhPrevSpindleRunTime.Text = "0"
        '
        'mopnhPrevOtherTime
        '
        Me.mopnhPrevOtherTime.Location = New System.Drawing.Point(144, 249)
        Me.mopnhPrevOtherTime.Name = "mopnhPrevOtherTime"
        Me.mopnhPrevOtherTime.Size = New System.Drawing.Size(269, 22)
        Me.mopnhPrevOtherTime.TabIndex = 42
        Me.mopnhPrevOtherTime.Text = "0"
        '
        'mopnhPrevMaintenanceTime
        '
        Me.mopnhPrevMaintenanceTime.Location = New System.Drawing.Point(144, 222)
        Me.mopnhPrevMaintenanceTime.Name = "mopnhPrevMaintenanceTime"
        Me.mopnhPrevMaintenanceTime.Size = New System.Drawing.Size(269, 22)
        Me.mopnhPrevMaintenanceTime.TabIndex = 41
        Me.mopnhPrevMaintenanceTime.Text = "0"
        '
        'mopnhPrevPartWaitingTime
        '
        Me.mopnhPrevPartWaitingTime.Location = New System.Drawing.Point(144, 194)
        Me.mopnhPrevPartWaitingTime.Name = "mopnhPrevPartWaitingTime"
        Me.mopnhPrevPartWaitingTime.Size = New System.Drawing.Size(269, 22)
        Me.mopnhPrevPartWaitingTime.TabIndex = 40
        Me.mopnhPrevPartWaitingTime.Text = "0"
        '
        'mopnhPrevNoOperatorTime
        '
        Me.mopnhPrevNoOperatorTime.Location = New System.Drawing.Point(144, 166)
        Me.mopnhPrevNoOperatorTime.Name = "mopnhPrevNoOperatorTime"
        Me.mopnhPrevNoOperatorTime.Size = New System.Drawing.Size(269, 22)
        Me.mopnhPrevNoOperatorTime.TabIndex = 39
        Me.mopnhPrevNoOperatorTime.Text = "0"
        '
        'mopnhPrevInProSetupTime
        '
        Me.mopnhPrevInProSetupTime.Location = New System.Drawing.Point(144, 138)
        Me.mopnhPrevInProSetupTime.Name = "mopnhPrevInProSetupTime"
        Me.mopnhPrevInProSetupTime.Size = New System.Drawing.Size(269, 22)
        Me.mopnhPrevInProSetupTime.TabIndex = 38
        Me.mopnhPrevInProSetupTime.Text = "0"
        '
        'mopnhPrevNonOperatingTime
        '
        Me.mopnhPrevNonOperatingTime.Location = New System.Drawing.Point(144, 111)
        Me.mopnhPrevNonOperatingTime.Name = "mopnhPrevNonOperatingTime"
        Me.mopnhPrevNonOperatingTime.Size = New System.Drawing.Size(269, 22)
        Me.mopnhPrevNonOperatingTime.TabIndex = 37
        Me.mopnhPrevNonOperatingTime.Text = "0"
        '
        'mopnhPrevCuttingTime
        '
        Me.mopnhPrevCuttingTime.Location = New System.Drawing.Point(144, 83)
        Me.mopnhPrevCuttingTime.Name = "mopnhPrevCuttingTime"
        Me.mopnhPrevCuttingTime.Size = New System.Drawing.Size(269, 22)
        Me.mopnhPrevCuttingTime.TabIndex = 36
        Me.mopnhPrevCuttingTime.Text = "0"
        '
        'mopnhPrevOperatingTime
        '
        Me.mopnhPrevOperatingTime.Location = New System.Drawing.Point(144, 55)
        Me.mopnhPrevOperatingTime.Name = "mopnhPrevOperatingTime"
        Me.mopnhPrevOperatingTime.Size = New System.Drawing.Size(269, 22)
        Me.mopnhPrevOperatingTime.TabIndex = 35
        Me.mopnhPrevOperatingTime.Text = "0"
        '
        'Label214
        '
        Me.Label214.Location = New System.Drawing.Point(38, 332)
        Me.Label214.Name = "Label214"
        Me.Label214.Size = New System.Drawing.Size(135, 27)
        Me.Label214.TabIndex = 34
        Me.Label214.Text = "Alarm on Time"
        '
        'Label215
        '
        Me.Label215.Location = New System.Drawing.Point(19, 305)
        Me.Label215.Name = "Label215"
        Me.Label215.Size = New System.Drawing.Size(135, 26)
        Me.Label215.TabIndex = 33
        Me.Label215.Text = "External input Time"
        '
        'Label216
        '
        Me.Label216.Location = New System.Drawing.Point(38, 249)
        Me.Label216.Name = "Label216"
        Me.Label216.Size = New System.Drawing.Size(120, 27)
        Me.Label216.TabIndex = 32
        Me.Label216.Text = "Other Time"
        '
        'Label217
        '
        Me.Label217.Location = New System.Drawing.Point(19, 222)
        Me.Label217.Name = "Label217"
        Me.Label217.Size = New System.Drawing.Size(120, 26)
        Me.Label217.TabIndex = 31
        Me.Label217.Text = "Maintenance Time"
        '
        'Label218
        '
        Me.Label218.Location = New System.Drawing.Point(19, 194)
        Me.Label218.Name = "Label218"
        Me.Label218.Size = New System.Drawing.Size(120, 26)
        Me.Label218.TabIndex = 30
        Me.Label218.Text = "Part waiting time"
        '
        'Label219
        '
        Me.Label219.Location = New System.Drawing.Point(19, 166)
        Me.Label219.Name = "Label219"
        Me.Label219.Size = New System.Drawing.Size(120, 27)
        Me.Label219.TabIndex = 29
        Me.Label219.Text = "No Operator Time"
        '
        'Label220
        '
        Me.Label220.Location = New System.Drawing.Point(19, 138)
        Me.Label220.Name = "Label220"
        Me.Label220.Size = New System.Drawing.Size(120, 27)
        Me.Label220.TabIndex = 28
        Me.Label220.Text = "In-Pro set up Time"
        '
        'Label221
        '
        Me.Label221.Location = New System.Drawing.Point(19, 111)
        Me.Label221.Name = "Label221"
        Me.Label221.Size = New System.Drawing.Size(125, 26)
        Me.Label221.TabIndex = 27
        Me.Label221.Text = "Non operating Time"
        '
        'Label222
        '
        Me.Label222.Location = New System.Drawing.Point(19, 83)
        Me.Label222.Name = "Label222"
        Me.Label222.Size = New System.Drawing.Size(120, 27)
        Me.Label222.TabIndex = 26
        Me.Label222.Text = "Cutting TIme"
        '
        'Label223
        '
        Me.Label223.Location = New System.Drawing.Point(19, 55)
        Me.Label223.Name = "Label223"
        Me.Label223.Size = New System.Drawing.Size(120, 27)
        Me.Label223.TabIndex = 25
        Me.Label223.Text = "Operating Time"
        '
        'Label224
        '
        Me.Label224.Location = New System.Drawing.Point(19, 28)
        Me.Label224.Name = "Label224"
        Me.Label224.Size = New System.Drawing.Size(96, 26)
        Me.Label224.TabIndex = 24
        Me.Label224.Text = "Running Time"
        '
        'Label203
        '
        Me.Label203.Location = New System.Drawing.Point(19, 277)
        Me.Label203.Name = "Label203"
        Me.Label203.Size = New System.Drawing.Size(120, 26)
        Me.Label203.TabIndex = 24
        Me.Label203.Text = "Spindle run Time"
        '
        'mopnhPrevRunningTime
        '
        Me.mopnhPrevRunningTime.Location = New System.Drawing.Point(144, 28)
        Me.mopnhPrevRunningTime.Name = "mopnhPrevRunningTime"
        Me.mopnhPrevRunningTime.Size = New System.Drawing.Size(269, 22)
        Me.mopnhPrevRunningTime.TabIndex = 24
        Me.mopnhPrevRunningTime.Text = "0"
        '
        'objMopnhUpdateButton
        '
        Me.objMopnhUpdateButton.Location = New System.Drawing.Point(384, 18)
        Me.objMopnhUpdateButton.Name = "objMopnhUpdateButton"
        Me.objMopnhUpdateButton.Size = New System.Drawing.Size(90, 27)
        Me.objMopnhUpdateButton.TabIndex = 29
        Me.objMopnhUpdateButton.Text = "Update"
        '
        'Label202
        '
        Me.Label202.Location = New System.Drawing.Point(202, 18)
        Me.Label202.Name = "Label202"
        Me.Label202.Size = New System.Drawing.Size(38, 27)
        Me.Label202.TabIndex = 28
        Me.Label202.Text = "To"
        '
        'Label201
        '
        Me.Label201.Location = New System.Drawing.Point(29, 18)
        Me.Label201.Name = "Label201"
        Me.Label201.Size = New System.Drawing.Size(38, 27)
        Me.Label201.TabIndex = 27
        Me.Label201.Text = "From"
        '
        'mopnhTo
        '
        Me.mopnhTo.Location = New System.Drawing.Point(240, 18)
        Me.mopnhTo.Name = "mopnhTo"
        Me.mopnhTo.Size = New System.Drawing.Size(120, 22)
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
        Me.GroupBox4.Location = New System.Drawing.Point(10, 55)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(441, 379)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = false
        Me.GroupBox4.Text = "Today Operating History"
        '
        'mopnhAlarmOnTime
        '
        Me.mopnhAlarmOnTime.Location = New System.Drawing.Point(154, 332)
        Me.mopnhAlarmOnTime.Name = "mopnhAlarmOnTime"
        Me.mopnhAlarmOnTime.Size = New System.Drawing.Size(278, 22)
        Me.mopnhAlarmOnTime.TabIndex = 23
        Me.mopnhAlarmOnTime.Text = "0"
        '
        'mopnhExternalInputTime
        '
        Me.mopnhExternalInputTime.Location = New System.Drawing.Point(154, 305)
        Me.mopnhExternalInputTime.Name = "mopnhExternalInputTime"
        Me.mopnhExternalInputTime.Size = New System.Drawing.Size(278, 22)
        Me.mopnhExternalInputTime.TabIndex = 22
        Me.mopnhExternalInputTime.Text = "0"
        '
        'mopnhSpindleRunTime
        '
        Me.mopnhSpindleRunTime.Location = New System.Drawing.Point(154, 277)
        Me.mopnhSpindleRunTime.Name = "mopnhSpindleRunTime"
        Me.mopnhSpindleRunTime.Size = New System.Drawing.Size(278, 22)
        Me.mopnhSpindleRunTime.TabIndex = 21
        Me.mopnhSpindleRunTime.Text = "0"
        '
        'mopnhOtherTime
        '
        Me.mopnhOtherTime.Location = New System.Drawing.Point(154, 249)
        Me.mopnhOtherTime.Name = "mopnhOtherTime"
        Me.mopnhOtherTime.Size = New System.Drawing.Size(278, 22)
        Me.mopnhOtherTime.TabIndex = 20
        Me.mopnhOtherTime.Text = "0"
        '
        'mopnhMaintenanceTime
        '
        Me.mopnhMaintenanceTime.Location = New System.Drawing.Point(154, 222)
        Me.mopnhMaintenanceTime.Name = "mopnhMaintenanceTime"
        Me.mopnhMaintenanceTime.Size = New System.Drawing.Size(278, 22)
        Me.mopnhMaintenanceTime.TabIndex = 19
        Me.mopnhMaintenanceTime.Text = "0"
        '
        'mopnhPartWaitingTime
        '
        Me.mopnhPartWaitingTime.Location = New System.Drawing.Point(154, 194)
        Me.mopnhPartWaitingTime.Name = "mopnhPartWaitingTime"
        Me.mopnhPartWaitingTime.Size = New System.Drawing.Size(278, 22)
        Me.mopnhPartWaitingTime.TabIndex = 18
        Me.mopnhPartWaitingTime.Text = "0"
        '
        'mopnhNoOperatorTime
        '
        Me.mopnhNoOperatorTime.Location = New System.Drawing.Point(154, 166)
        Me.mopnhNoOperatorTime.Name = "mopnhNoOperatorTime"
        Me.mopnhNoOperatorTime.Size = New System.Drawing.Size(278, 22)
        Me.mopnhNoOperatorTime.TabIndex = 17
        Me.mopnhNoOperatorTime.Text = "0"
        '
        'mopnhInProSetupTime
        '
        Me.mopnhInProSetupTime.Location = New System.Drawing.Point(154, 138)
        Me.mopnhInProSetupTime.Name = "mopnhInProSetupTime"
        Me.mopnhInProSetupTime.Size = New System.Drawing.Size(278, 22)
        Me.mopnhInProSetupTime.TabIndex = 16
        Me.mopnhInProSetupTime.Text = "0"
        '
        'mopnhNonOperatingReport
        '
        Me.mopnhNonOperatingReport.Location = New System.Drawing.Point(154, 111)
        Me.mopnhNonOperatingReport.Name = "mopnhNonOperatingReport"
        Me.mopnhNonOperatingReport.Size = New System.Drawing.Size(278, 22)
        Me.mopnhNonOperatingReport.TabIndex = 15
        Me.mopnhNonOperatingReport.Text = "0"
        '
        'mopnhCuttingTime
        '
        Me.mopnhCuttingTime.Location = New System.Drawing.Point(154, 83)
        Me.mopnhCuttingTime.Name = "mopnhCuttingTime"
        Me.mopnhCuttingTime.Size = New System.Drawing.Size(278, 22)
        Me.mopnhCuttingTime.TabIndex = 14
        Me.mopnhCuttingTime.Text = "0"
        '
        'mopnhOperatingTime
        '
        Me.mopnhOperatingTime.Location = New System.Drawing.Point(154, 55)
        Me.mopnhOperatingTime.Name = "mopnhOperatingTime"
        Me.mopnhOperatingTime.Size = New System.Drawing.Size(278, 22)
        Me.mopnhOperatingTime.TabIndex = 13
        Me.mopnhOperatingTime.Text = "0"
        '
        'mopnhRunningTime
        '
        Me.mopnhRunningTime.Location = New System.Drawing.Point(154, 28)
        Me.mopnhRunningTime.Name = "mopnhRunningTime"
        Me.mopnhRunningTime.Size = New System.Drawing.Size(278, 22)
        Me.mopnhRunningTime.TabIndex = 12
        Me.mopnhRunningTime.Text = "0"
        '
        'Label200
        '
        Me.Label200.Location = New System.Drawing.Point(10, 332)
        Me.Label200.Name = "Label200"
        Me.Label200.Size = New System.Drawing.Size(134, 27)
        Me.Label200.TabIndex = 11
        Me.Label200.Text = "Alarm on Time"
        '
        'Label199
        '
        Me.Label199.Location = New System.Drawing.Point(10, 305)
        Me.Label199.Name = "Label199"
        Me.Label199.Size = New System.Drawing.Size(134, 26)
        Me.Label199.TabIndex = 10
        Me.Label199.Text = "External input Time"
        '
        'Label198
        '
        Me.Label198.Location = New System.Drawing.Point(10, 277)
        Me.Label198.Name = "Label198"
        Me.Label198.Size = New System.Drawing.Size(120, 26)
        Me.Label198.TabIndex = 9
        Me.Label198.Text = "Spindle run Time"
        '
        'Label197
        '
        Me.Label197.Location = New System.Drawing.Point(10, 258)
        Me.Label197.Name = "Label197"
        Me.Label197.Size = New System.Drawing.Size(120, 27)
        Me.Label197.TabIndex = 8
        Me.Label197.Text = "Other Time"
        '
        'Label196
        '
        Me.Label196.Location = New System.Drawing.Point(10, 231)
        Me.Label196.Name = "Label196"
        Me.Label196.Size = New System.Drawing.Size(120, 26)
        Me.Label196.TabIndex = 7
        Me.Label196.Text = "Maintenance Time"
        '
        'Label195
        '
        Me.Label195.Location = New System.Drawing.Point(10, 203)
        Me.Label195.Name = "Label195"
        Me.Label195.Size = New System.Drawing.Size(120, 27)
        Me.Label195.TabIndex = 6
        Me.Label195.Text = "Part waiting time"
        '
        'Label194
        '
        Me.Label194.Location = New System.Drawing.Point(10, 175)
        Me.Label194.Name = "Label194"
        Me.Label194.Size = New System.Drawing.Size(120, 27)
        Me.Label194.TabIndex = 5
        Me.Label194.Text = "No Operator Time"
        '
        'Label193
        '
        Me.Label193.Location = New System.Drawing.Point(10, 148)
        Me.Label193.Name = "Label193"
        Me.Label193.Size = New System.Drawing.Size(120, 26)
        Me.Label193.TabIndex = 4
        Me.Label193.Text = "In-Pro set up Time"
        '
        'Label192
        '
        Me.Label192.Location = New System.Drawing.Point(10, 120)
        Me.Label192.Name = "Label192"
        Me.Label192.Size = New System.Drawing.Size(124, 27)
        Me.Label192.TabIndex = 3
        Me.Label192.Text = "Non operating Time"
        '
        'Label191
        '
        Me.Label191.Location = New System.Drawing.Point(10, 92)
        Me.Label191.Name = "Label191"
        Me.Label191.Size = New System.Drawing.Size(120, 27)
        Me.Label191.TabIndex = 2
        Me.Label191.Text = "Cutting TIme"
        '
        'Label190
        '
        Me.Label190.Location = New System.Drawing.Point(10, 65)
        Me.Label190.Name = "Label190"
        Me.Label190.Size = New System.Drawing.Size(120, 26)
        Me.Label190.TabIndex = 1
        Me.Label190.Text = "Operating Time"
        '
        'Label108
        '
        Me.Label108.Location = New System.Drawing.Point(10, 37)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(120, 26)
        Me.Label108.TabIndex = 0
        Me.Label108.Text = "Running Time"
        '
        'mopnhFrom
        '
        Me.mopnhFrom.Location = New System.Drawing.Point(77, 18)
        Me.mopnhFrom.Name = "mopnhFrom"
        Me.mopnhFrom.Size = New System.Drawing.Size(120, 22)
        Me.mopnhFrom.TabIndex = 24
        Me.mopnhFrom.Text = "1"
        '
        'tab_MacManMachiningReport
        '
        Me.tab_MacManMachiningReport.Controls.Add(Me.grdMMMachiningReports)
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
        Me.tab_MacManMachiningReport.Location = New System.Drawing.Point(4, 25)
        Me.tab_MacManMachiningReport.Name = "tab_MacManMachiningReport"
        Me.tab_MacManMachiningReport.Size = New System.Drawing.Size(1019, 498)
        Me.tab_MacManMachiningReport.TabIndex = 15
        Me.tab_MacManMachiningReport.Text = "MacMan Machining Reports"
        '
        'grdMMMachiningReports
        '
        Me.grdMMMachiningReports.DataMember = ""
        Me.grdMMMachiningReports.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdMMMachiningReports.Location = New System.Drawing.Point(16, 200)
        Me.grdMMMachiningReports.Name = "grdMMMachiningReports"
        Me.grdMMMachiningReports.PreferredColumnWidth = 80
        Me.grdMMMachiningReports.ReadOnly = true
        Me.grdMMMachiningReports.Size = New System.Drawing.Size(903, 272)
        Me.grdMMMachiningReports.TabIndex = 335
        '
        'txtMachiningReport_NoOfWork
        '
        Me.txtMachiningReport_NoOfWork.Location = New System.Drawing.Point(475, 102)
        Me.txtMachiningReport_NoOfWork.Name = "txtMachiningReport_NoOfWork"
        Me.txtMachiningReport_NoOfWork.ReadOnly = true
        Me.txtMachiningReport_NoOfWork.Size = New System.Drawing.Size(106, 22)
        Me.txtMachiningReport_NoOfWork.TabIndex = 333
        '
        'Label156
        '
        Me.Label156.Location = New System.Drawing.Point(475, 65)
        Me.Label156.Name = "Label156"
        Me.Label156.Size = New System.Drawing.Size(106, 18)
        Me.Label156.TabIndex = 332
        Me.Label156.Text = "No. Of Work"
        '
        'MacreportTime
        '
        Me.MacreportTime.Location = New System.Drawing.Point(360, 102)
        Me.MacreportTime.Name = "MacreportTime"
        Me.MacreportTime.ReadOnly = true
        Me.MacreportTime.Size = New System.Drawing.Size(106, 22)
        Me.MacreportTime.TabIndex = 328
        '
        'Label245
        '
        Me.Label245.Location = New System.Drawing.Point(350, 65)
        Me.Label245.Name = "Label245"
        Me.Label245.Size = New System.Drawing.Size(106, 18)
        Me.Label245.TabIndex = 327
        Me.Label245.Text = "Start Time:"
        '
        'txtto
        '
        Me.txtto.Location = New System.Drawing.Point(466, 166)
        Me.txtto.Name = "txtto"
        Me.txtto.Size = New System.Drawing.Size(76, 22)
        Me.txtto.TabIndex = 326
        Me.txtto.Text = "2"
        '
        'Label158
        '
        Me.Label158.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label158.Location = New System.Drawing.Point(398, 166)
        Me.Label158.Name = "Label158"
        Me.Label158.Size = New System.Drawing.Size(58, 19)
        Me.Label158.TabIndex = 325
        Me.Label158.Text = "To"
        '
        'txtFrom
        '
        Me.txtFrom.Location = New System.Drawing.Point(283, 166)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(77, 22)
        Me.txtFrom.TabIndex = 324
        Me.txtFrom.Text = "1"
        '
        'Label159
        '
        Me.Label159.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label159.Location = New System.Drawing.Point(216, 166)
        Me.Label159.Name = "Label159"
        Me.Label159.Size = New System.Drawing.Size(58, 19)
        Me.Label159.TabIndex = 323
        Me.Label159.Text = "From"
        '
        'macreport_result
        '
        Me.macreport_result.Location = New System.Drawing.Point(14, 166)
        Me.macreport_result.Name = "macreport_result"
        Me.macreport_result.Size = New System.Drawing.Size(87, 28)
        Me.macreport_result.TabIndex = 322
        Me.macreport_result.Text = "Update"
        '
        'Label160
        '
        Me.Label160.Location = New System.Drawing.Point(302, 18)
        Me.Label160.Name = "Label160"
        Me.Label160.Size = New System.Drawing.Size(87, 19)
        Me.Label160.TabIndex = 321
        Me.Label160.Text = "Period Time"
        '
        'Cmb_rptPeriod
        '
        Me.Cmb_rptPeriod.Location = New System.Drawing.Point(398, 18)
        Me.Cmb_rptPeriod.Name = "Cmb_rptPeriod"
        Me.Cmb_rptPeriod.Size = New System.Drawing.Size(125, 24)
        Me.Cmb_rptPeriod.TabIndex = 320
        '
        'MacReport_programname
        '
        Me.MacReport_programname.Location = New System.Drawing.Point(130, 102)
        Me.MacReport_programname.Name = "MacReport_programname"
        Me.MacReport_programname.ReadOnly = true
        Me.MacReport_programname.Size = New System.Drawing.Size(105, 22)
        Me.MacReport_programname.TabIndex = 319
        '
        'Label161
        '
        Me.Label161.Location = New System.Drawing.Point(130, 65)
        Me.Label161.Name = "Label161"
        Me.Label161.Size = New System.Drawing.Size(105, 27)
        Me.Label161.TabIndex = 318
        Me.Label161.Text = "Main program name"
        '
        'Macreport_filename
        '
        Me.Macreport_filename.Location = New System.Drawing.Point(14, 102)
        Me.Macreport_filename.Name = "Macreport_filename"
        Me.Macreport_filename.ReadOnly = true
        Me.Macreport_filename.Size = New System.Drawing.Size(106, 22)
        Me.Macreport_filename.TabIndex = 317
        '
        'Label162
        '
        Me.Label162.Location = New System.Drawing.Point(14, 65)
        Me.Label162.Name = "Label162"
        Me.Label162.Size = New System.Drawing.Size(106, 27)
        Me.Label162.TabIndex = 316
        Me.Label162.Text = "Main program file name"
        '
        'MacReport_count
        '
        Me.MacReport_count.Location = New System.Drawing.Point(802, 18)
        Me.MacReport_count.Name = "MacReport_count"
        Me.MacReport_count.ReadOnly = true
        Me.MacReport_count.Size = New System.Drawing.Size(76, 22)
        Me.MacReport_count.TabIndex = 315
        '
        'Label163
        '
        Me.Label163.Location = New System.Drawing.Point(734, 18)
        Me.Label163.Name = "Label163"
        Me.Label163.Size = New System.Drawing.Size(58, 19)
        Me.Label163.TabIndex = 314
        Me.Label163.Text = "Count"
        '
        'macReportUpdateButton
        '
        Me.macReportUpdateButton.Location = New System.Drawing.Point(14, 18)
        Me.macReportUpdateButton.Name = "macReportUpdateButton"
        Me.macReportUpdateButton.Size = New System.Drawing.Size(87, 28)
        Me.macReportUpdateButton.TabIndex = 313
        Me.macReportUpdateButton.Text = "Update"
        '
        'MacReport_Index
        '
        Me.MacReport_Index.Location = New System.Drawing.Point(216, 18)
        Me.MacReport_Index.Name = "MacReport_Index"
        Me.MacReport_Index.Size = New System.Drawing.Size(77, 22)
        Me.MacReport_Index.TabIndex = 312
        Me.MacReport_Index.Text = "1"
        '
        'Label164
        '
        Me.Label164.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label164.Location = New System.Drawing.Point(120, 18)
        Me.Label164.Name = "Label164"
        Me.Label164.Size = New System.Drawing.Size(77, 19)
        Me.Label164.TabIndex = 311
        Me.Label164.Text = "Index :"
        '
        'macreport_Operatingtime
        '
        Me.macreport_Operatingtime.Location = New System.Drawing.Point(696, 102)
        Me.macreport_Operatingtime.Name = "macreport_Operatingtime"
        Me.macreport_Operatingtime.ReadOnly = true
        Me.macreport_Operatingtime.Size = New System.Drawing.Size(106, 22)
        Me.macreport_Operatingtime.TabIndex = 310
        '
        'Label225
        '
        Me.Label225.Location = New System.Drawing.Point(696, 65)
        Me.Label225.Name = "Label225"
        Me.Label225.Size = New System.Drawing.Size(106, 37)
        Me.Label225.TabIndex = 309
        Me.Label225.Text = "Operating Time (ms)"
        '
        'macreport_Runningtime
        '
        Me.macreport_Runningtime.Location = New System.Drawing.Point(590, 102)
        Me.macreport_Runningtime.Name = "macreport_Runningtime"
        Me.macreport_Runningtime.ReadOnly = true
        Me.macreport_Runningtime.Size = New System.Drawing.Size(96, 22)
        Me.macreport_Runningtime.TabIndex = 308
        '
        'Label226
        '
        Me.Label226.Location = New System.Drawing.Point(590, 65)
        Me.Label226.Name = "Label226"
        Me.Label226.Size = New System.Drawing.Size(106, 37)
        Me.Label226.TabIndex = 307
        Me.Label226.Text = "Running Time (ms)"
        '
        'Macreportdate
        '
        Me.Macreportdate.Location = New System.Drawing.Point(245, 102)
        Me.Macreportdate.Name = "Macreportdate"
        Me.Macreportdate.ReadOnly = true
        Me.Macreportdate.Size = New System.Drawing.Size(105, 22)
        Me.Macreportdate.TabIndex = 306
        '
        'Label227
        '
        Me.Label227.Location = New System.Drawing.Point(245, 65)
        Me.Label227.Name = "Label227"
        Me.Label227.Size = New System.Drawing.Size(96, 18)
        Me.Label227.TabIndex = 305
        Me.Label227.Text = "Start Date:"
        '
        'macreport_maxcount
        '
        Me.macreport_maxcount.Location = New System.Drawing.Point(638, 18)
        Me.macreport_maxcount.Name = "macreport_maxcount"
        Me.macreport_maxcount.ReadOnly = true
        Me.macreport_maxcount.Size = New System.Drawing.Size(77, 22)
        Me.macreport_maxcount.TabIndex = 304
        '
        'Label228
        '
        Me.Label228.Location = New System.Drawing.Point(533, 18)
        Me.Label228.Name = "Label228"
        Me.Label228.Size = New System.Drawing.Size(86, 19)
        Me.Label228.TabIndex = 303
        Me.Label228.Text = "Max Count :"
        '
        'macreport_cuttingtime
        '
        Me.macreport_cuttingtime.Location = New System.Drawing.Point(811, 102)
        Me.macreport_cuttingtime.Name = "macreport_cuttingtime"
        Me.macreport_cuttingtime.ReadOnly = true
        Me.macreport_cuttingtime.Size = New System.Drawing.Size(106, 22)
        Me.macreport_cuttingtime.TabIndex = 302
        '
        'Label229
        '
        Me.Label229.Location = New System.Drawing.Point(811, 65)
        Me.Label229.Name = "Label229"
        Me.Label229.Size = New System.Drawing.Size(106, 37)
        Me.Label229.TabIndex = 301
        Me.Label229.Text = "Cutting Time (ms)"
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
        Me.tab_MacmanOperatingReport.Location = New System.Drawing.Point(4, 25)
        Me.tab_MacmanOperatingReport.Name = "tab_MacmanOperatingReport"
        Me.tab_MacmanOperatingReport.Size = New System.Drawing.Size(1019, 498)
        Me.tab_MacmanOperatingReport.TabIndex = 13
        Me.tab_MacmanOperatingReport.Text = "MacMan Operating Report"
        '
        'morMaxNoOfOpReport
        '
        Me.morMaxNoOfOpReport.Location = New System.Drawing.Point(802, 48)
        Me.morMaxNoOfOpReport.Name = "morMaxNoOfOpReport"
        Me.morMaxNoOfOpReport.Size = New System.Drawing.Size(115, 22)
        Me.morMaxNoOfOpReport.TabIndex = 321
        Me.morMaxNoOfOpReport.Text = "0"
        '
        'Label288
        '
        Me.Label288.Location = New System.Drawing.Point(590, 48)
        Me.Label288.Name = "Label288"
        Me.Label288.Size = New System.Drawing.Size(202, 28)
        Me.Label288.TabIndex = 320
        Me.Label288.Text = "Maximum no of operating report"
        '
        'morUpdateButton
        '
        Me.morUpdateButton.Location = New System.Drawing.Point(384, 9)
        Me.morUpdateButton.Name = "morUpdateButton"
        Me.morUpdateButton.Size = New System.Drawing.Size(106, 28)
        Me.morUpdateButton.TabIndex = 319
        Me.morUpdateButton.Text = "Update"
        '
        'morOperatingStatus
        '
        Me.morOperatingStatus.Location = New System.Drawing.Point(456, 48)
        Me.morOperatingStatus.Name = "morOperatingStatus"
        Me.morOperatingStatus.Size = New System.Drawing.Size(96, 22)
        Me.morOperatingStatus.TabIndex = 318
        Me.morOperatingStatus.Text = "0"
        '
        'Label289
        '
        Me.Label289.Location = New System.Drawing.Point(331, 48)
        Me.Label289.Name = "Label289"
        Me.Label289.Size = New System.Drawing.Size(115, 28)
        Me.Label289.TabIndex = 317
        Me.Label289.Text = "Operating Status :"
        '
        'morNonoperatingCondition
        '
        Me.morNonoperatingCondition.Location = New System.Drawing.Point(187, 48)
        Me.morNonoperatingCondition.Name = "morNonoperatingCondition"
        Me.morNonoperatingCondition.Size = New System.Drawing.Size(115, 22)
        Me.morNonoperatingCondition.TabIndex = 316
        Me.morNonoperatingCondition.Text = "0"
        '
        'Label290
        '
        Me.Label290.Location = New System.Drawing.Point(24, 48)
        Me.Label290.Name = "Label290"
        Me.Label290.Size = New System.Drawing.Size(163, 19)
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
        Me.GroupBox1.Location = New System.Drawing.Point(629, 85)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 407)
        Me.GroupBox1.TabIndex = 314
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Previous Day Operating Report"
        '
        'Label64
        '
        Me.Label64.Location = New System.Drawing.Point(10, 305)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(124, 26)
        Me.Label64.TabIndex = 219
        Me.Label64.Text = "External Input Time"
        '
        'morPrevExternalInputTime
        '
        Me.morPrevExternalInputTime.Location = New System.Drawing.Point(163, 295)
        Me.morPrevExternalInputTime.Name = "morPrevExternalInputTime"
        Me.morPrevExternalInputTime.Size = New System.Drawing.Size(120, 22)
        Me.morPrevExternalInputTime.TabIndex = 220
        Me.morPrevExternalInputTime.Text = "0"
        '
        'morPrevDateOfOperatingRept
        '
        Me.morPrevDateOfOperatingRept.Location = New System.Drawing.Point(163, 351)
        Me.morPrevDateOfOperatingRept.Name = "morPrevDateOfOperatingRept"
        Me.morPrevDateOfOperatingRept.Size = New System.Drawing.Size(120, 22)
        Me.morPrevDateOfOperatingRept.TabIndex = 218
        Me.morPrevDateOfOperatingRept.Text = "0"
        '
        'morPrevAlarmOnTime
        '
        Me.morPrevAlarmOnTime.Location = New System.Drawing.Point(163, 323)
        Me.morPrevAlarmOnTime.Name = "morPrevAlarmOnTime"
        Me.morPrevAlarmOnTime.Size = New System.Drawing.Size(120, 22)
        Me.morPrevAlarmOnTime.TabIndex = 217
        Me.morPrevAlarmOnTime.Text = "0"
        '
        'morPrevSpindleRunTime
        '
        Me.morPrevSpindleRunTime.Location = New System.Drawing.Point(163, 268)
        Me.morPrevSpindleRunTime.Name = "morPrevSpindleRunTime"
        Me.morPrevSpindleRunTime.Size = New System.Drawing.Size(120, 22)
        Me.morPrevSpindleRunTime.TabIndex = 216
        Me.morPrevSpindleRunTime.Text = "0"
        '
        'morPrevOtherTime
        '
        Me.morPrevOtherTime.Location = New System.Drawing.Point(163, 240)
        Me.morPrevOtherTime.Name = "morPrevOtherTime"
        Me.morPrevOtherTime.Size = New System.Drawing.Size(120, 22)
        Me.morPrevOtherTime.TabIndex = 215
        Me.morPrevOtherTime.Text = "0"
        '
        'morPrevMaintenanceTime
        '
        Me.morPrevMaintenanceTime.Location = New System.Drawing.Point(163, 212)
        Me.morPrevMaintenanceTime.Name = "morPrevMaintenanceTime"
        Me.morPrevMaintenanceTime.Size = New System.Drawing.Size(120, 22)
        Me.morPrevMaintenanceTime.TabIndex = 214
        Me.morPrevMaintenanceTime.Text = "0"
        '
        'morPrevPartwaitingTime
        '
        Me.morPrevPartwaitingTime.Location = New System.Drawing.Point(163, 185)
        Me.morPrevPartwaitingTime.Name = "morPrevPartwaitingTime"
        Me.morPrevPartwaitingTime.Size = New System.Drawing.Size(120, 22)
        Me.morPrevPartwaitingTime.TabIndex = 213
        Me.morPrevPartwaitingTime.Text = "0"
        '
        'morPrevNoOperatorTime
        '
        Me.morPrevNoOperatorTime.Location = New System.Drawing.Point(163, 157)
        Me.morPrevNoOperatorTime.Name = "morPrevNoOperatorTime"
        Me.morPrevNoOperatorTime.Size = New System.Drawing.Size(120, 22)
        Me.morPrevNoOperatorTime.TabIndex = 212
        Me.morPrevNoOperatorTime.Text = "0"
        '
        'morPrevInProSetupTime
        '
        Me.morPrevInProSetupTime.Location = New System.Drawing.Point(163, 129)
        Me.morPrevInProSetupTime.Name = "morPrevInProSetupTime"
        Me.morPrevInProSetupTime.Size = New System.Drawing.Size(120, 22)
        Me.morPrevInProSetupTime.TabIndex = 211
        Me.morPrevInProSetupTime.Text = "0"
        '
        'morPrevNonOperatingTime
        '
        Me.morPrevNonOperatingTime.Location = New System.Drawing.Point(163, 102)
        Me.morPrevNonOperatingTime.Name = "morPrevNonOperatingTime"
        Me.morPrevNonOperatingTime.Size = New System.Drawing.Size(120, 22)
        Me.morPrevNonOperatingTime.TabIndex = 210
        Me.morPrevNonOperatingTime.Text = "0"
        '
        'morPrevCuttingTime
        '
        Me.morPrevCuttingTime.Location = New System.Drawing.Point(163, 74)
        Me.morPrevCuttingTime.Name = "morPrevCuttingTime"
        Me.morPrevCuttingTime.Size = New System.Drawing.Size(120, 22)
        Me.morPrevCuttingTime.TabIndex = 209
        Me.morPrevCuttingTime.Text = "0"
        '
        'morPrevRunningTime
        '
        Me.morPrevRunningTime.Location = New System.Drawing.Point(163, 46)
        Me.morPrevRunningTime.Name = "morPrevRunningTime"
        Me.morPrevRunningTime.Size = New System.Drawing.Size(120, 22)
        Me.morPrevRunningTime.TabIndex = 208
        Me.morPrevRunningTime.Text = "0"
        '
        'Label276
        '
        Me.Label276.Location = New System.Drawing.Point(10, 18)
        Me.Label276.Name = "Label276"
        Me.Label276.Size = New System.Drawing.Size(105, 27)
        Me.Label276.TabIndex = 203
        Me.Label276.Text = "Operating Time"
        '
        'Label277
        '
        Me.Label277.Location = New System.Drawing.Point(10, 46)
        Me.Label277.Name = "Label277"
        Me.Label277.Size = New System.Drawing.Size(120, 27)
        Me.Label277.TabIndex = 203
        Me.Label277.Text = "Runing Time"
        '
        'Label278
        '
        Me.Label278.Location = New System.Drawing.Point(10, 74)
        Me.Label278.Name = "Label278"
        Me.Label278.Size = New System.Drawing.Size(120, 26)
        Me.Label278.TabIndex = 203
        Me.Label278.Text = "Cutting Time"
        '
        'Label279
        '
        Me.Label279.Location = New System.Drawing.Point(10, 102)
        Me.Label279.Name = "Label279"
        Me.Label279.Size = New System.Drawing.Size(144, 26)
        Me.Label279.TabIndex = 203
        Me.Label279.Text = "Non Operating Time"
        '
        'Label280
        '
        Me.Label280.Location = New System.Drawing.Point(10, 129)
        Me.Label280.Name = "Label280"
        Me.Label280.Size = New System.Drawing.Size(120, 27)
        Me.Label280.TabIndex = 203
        Me.Label280.Text = "In Pro Setup Time"
        '
        'Label281
        '
        Me.Label281.Location = New System.Drawing.Point(10, 157)
        Me.Label281.Name = "Label281"
        Me.Label281.Size = New System.Drawing.Size(120, 26)
        Me.Label281.TabIndex = 203
        Me.Label281.Text = "No Operator Time"
        '
        'Label282
        '
        Me.Label282.Location = New System.Drawing.Point(10, 185)
        Me.Label282.Name = "Label282"
        Me.Label282.Size = New System.Drawing.Size(120, 26)
        Me.Label282.TabIndex = 203
        Me.Label282.Text = "Part waiting Time"
        '
        'Label283
        '
        Me.Label283.Location = New System.Drawing.Point(10, 222)
        Me.Label283.Name = "Label283"
        Me.Label283.Size = New System.Drawing.Size(120, 26)
        Me.Label283.TabIndex = 203
        Me.Label283.Text = "Maintenance Time"
        '
        'Label284
        '
        Me.Label284.Location = New System.Drawing.Point(10, 249)
        Me.Label284.Name = "Label284"
        Me.Label284.Size = New System.Drawing.Size(120, 27)
        Me.Label284.TabIndex = 203
        Me.Label284.Text = "Other Time"
        '
        'Label285
        '
        Me.Label285.Location = New System.Drawing.Point(10, 277)
        Me.Label285.Name = "Label285"
        Me.Label285.Size = New System.Drawing.Size(120, 26)
        Me.Label285.TabIndex = 203
        Me.Label285.Text = "Spindle Run Time"
        '
        'Label286
        '
        Me.Label286.Location = New System.Drawing.Point(10, 332)
        Me.Label286.Name = "Label286"
        Me.Label286.Size = New System.Drawing.Size(96, 27)
        Me.Label286.TabIndex = 203
        Me.Label286.Text = "Alarm On Time"
        '
        'Label287
        '
        Me.Label287.Location = New System.Drawing.Point(10, 360)
        Me.Label287.Name = "Label287"
        Me.Label287.Size = New System.Drawing.Size(134, 37)
        Me.Label287.TabIndex = 203
        Me.Label287.Text = "Date Of Operating report"
        '
        'morPrevOperatingTime
        '
        Me.morPrevOperatingTime.Location = New System.Drawing.Point(163, 18)
        Me.morPrevOperatingTime.Name = "morPrevOperatingTime"
        Me.morPrevOperatingTime.Size = New System.Drawing.Size(120, 22)
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
        Me.GroupBox2.Location = New System.Drawing.Point(322, 85)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(297, 407)
        Me.GroupBox2.TabIndex = 313
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Today Operating report"
        '
        'Label240
        '
        Me.Label240.Location = New System.Drawing.Point(10, 18)
        Me.Label240.Name = "Label240"
        Me.Label240.Size = New System.Drawing.Size(105, 27)
        Me.Label240.TabIndex = 176
        Me.Label240.Text = "Operating Time"
        '
        'morOperatingTime
        '
        Me.morOperatingTime.Location = New System.Drawing.Point(173, 18)
        Me.morOperatingTime.Name = "morOperatingTime"
        Me.morOperatingTime.Size = New System.Drawing.Size(115, 22)
        Me.morOperatingTime.TabIndex = 179
        Me.morOperatingTime.Text = "0"
        '
        'Label264
        '
        Me.Label264.Location = New System.Drawing.Point(10, 46)
        Me.Label264.Name = "Label264"
        Me.Label264.Size = New System.Drawing.Size(120, 27)
        Me.Label264.TabIndex = 177
        Me.Label264.Text = "Runing Time"
        '
        'Label265
        '
        Me.Label265.Location = New System.Drawing.Point(10, 74)
        Me.Label265.Name = "Label265"
        Me.Label265.Size = New System.Drawing.Size(120, 26)
        Me.Label265.TabIndex = 178
        Me.Label265.Text = "Cutting Time"
        '
        'Label266
        '
        Me.Label266.Location = New System.Drawing.Point(10, 102)
        Me.Label266.Name = "Label266"
        Me.Label266.Size = New System.Drawing.Size(144, 26)
        Me.Label266.TabIndex = 182
        Me.Label266.Text = "Non Operating Time"
        '
        'Label267
        '
        Me.Label267.Location = New System.Drawing.Point(10, 129)
        Me.Label267.Name = "Label267"
        Me.Label267.Size = New System.Drawing.Size(120, 27)
        Me.Label267.TabIndex = 183
        Me.Label267.Text = "In Pro Setup Time"
        '
        'Label268
        '
        Me.Label268.Location = New System.Drawing.Point(10, 157)
        Me.Label268.Name = "Label268"
        Me.Label268.Size = New System.Drawing.Size(120, 26)
        Me.Label268.TabIndex = 184
        Me.Label268.Text = "No Operator Time"
        '
        'Label269
        '
        Me.Label269.Location = New System.Drawing.Point(10, 185)
        Me.Label269.Name = "Label269"
        Me.Label269.Size = New System.Drawing.Size(120, 26)
        Me.Label269.TabIndex = 188
        Me.Label269.Text = "Part waiting Time"
        '
        'morRunningTime
        '
        Me.morRunningTime.Location = New System.Drawing.Point(173, 46)
        Me.morRunningTime.Name = "morRunningTime"
        Me.morRunningTime.Size = New System.Drawing.Size(115, 22)
        Me.morRunningTime.TabIndex = 180
        Me.morRunningTime.Text = "0"
        '
        'morCuttingTime
        '
        Me.morCuttingTime.Location = New System.Drawing.Point(173, 74)
        Me.morCuttingTime.Name = "morCuttingTime"
        Me.morCuttingTime.Size = New System.Drawing.Size(115, 22)
        Me.morCuttingTime.TabIndex = 181
        Me.morCuttingTime.Text = "0"
        '
        'morNonOPeratingTime
        '
        Me.morNonOPeratingTime.Location = New System.Drawing.Point(173, 102)
        Me.morNonOPeratingTime.Name = "morNonOPeratingTime"
        Me.morNonOPeratingTime.Size = New System.Drawing.Size(115, 22)
        Me.morNonOPeratingTime.TabIndex = 185
        Me.morNonOPeratingTime.Text = "0"
        '
        'morInProSetupTime
        '
        Me.morInProSetupTime.Location = New System.Drawing.Point(173, 129)
        Me.morInProSetupTime.Name = "morInProSetupTime"
        Me.morInProSetupTime.Size = New System.Drawing.Size(115, 22)
        Me.morInProSetupTime.TabIndex = 186
        Me.morInProSetupTime.Text = "0"
        '
        'morNoOperatorTime
        '
        Me.morNoOperatorTime.Location = New System.Drawing.Point(173, 157)
        Me.morNoOperatorTime.Name = "morNoOperatorTime"
        Me.morNoOperatorTime.Size = New System.Drawing.Size(115, 22)
        Me.morNoOperatorTime.TabIndex = 187
        Me.morNoOperatorTime.Text = "0"
        '
        'morPartWaitingTime
        '
        Me.morPartWaitingTime.Location = New System.Drawing.Point(173, 185)
        Me.morPartWaitingTime.Name = "morPartWaitingTime"
        Me.morPartWaitingTime.Size = New System.Drawing.Size(115, 22)
        Me.morPartWaitingTime.TabIndex = 191
        Me.morPartWaitingTime.Text = "0"
        '
        'Label270
        '
        Me.Label270.Location = New System.Drawing.Point(10, 212)
        Me.Label270.Name = "Label270"
        Me.Label270.Size = New System.Drawing.Size(120, 27)
        Me.Label270.TabIndex = 189
        Me.Label270.Text = "Maintenance Time"
        '
        'mormaintenanceTime
        '
        Me.mormaintenanceTime.Location = New System.Drawing.Point(173, 212)
        Me.mormaintenanceTime.Name = "mormaintenanceTime"
        Me.mormaintenanceTime.Size = New System.Drawing.Size(115, 22)
        Me.mormaintenanceTime.TabIndex = 192
        Me.mormaintenanceTime.Text = "0"
        '
        'Label271
        '
        Me.Label271.Location = New System.Drawing.Point(10, 240)
        Me.Label271.Name = "Label271"
        Me.Label271.Size = New System.Drawing.Size(120, 27)
        Me.Label271.TabIndex = 190
        Me.Label271.Text = "Other Time"
        '
        'morOtherTime
        '
        Me.morOtherTime.Location = New System.Drawing.Point(173, 240)
        Me.morOtherTime.Name = "morOtherTime"
        Me.morOtherTime.Size = New System.Drawing.Size(115, 22)
        Me.morOtherTime.TabIndex = 193
        Me.morOtherTime.Text = "0"
        '
        'Label272
        '
        Me.Label272.Location = New System.Drawing.Point(10, 268)
        Me.Label272.Name = "Label272"
        Me.Label272.Size = New System.Drawing.Size(120, 26)
        Me.Label272.TabIndex = 194
        Me.Label272.Text = "Spindle Run Time"
        '
        'morSpindleRunTime
        '
        Me.morSpindleRunTime.Location = New System.Drawing.Point(173, 268)
        Me.morSpindleRunTime.Name = "morSpindleRunTime"
        Me.morSpindleRunTime.Size = New System.Drawing.Size(115, 22)
        Me.morSpindleRunTime.TabIndex = 199
        Me.morSpindleRunTime.Text = "0"
        '
        'Label273
        '
        Me.Label273.Location = New System.Drawing.Point(10, 295)
        Me.Label273.Name = "Label273"
        Me.Label273.Size = New System.Drawing.Size(124, 27)
        Me.Label273.TabIndex = 195
        Me.Label273.Text = "External Input Time"
        '
        'morExternalInputTime
        '
        Me.morExternalInputTime.Location = New System.Drawing.Point(173, 295)
        Me.morExternalInputTime.Name = "morExternalInputTime"
        Me.morExternalInputTime.Size = New System.Drawing.Size(115, 22)
        Me.morExternalInputTime.TabIndex = 200
        Me.morExternalInputTime.Text = "0"
        '
        'morAlarmOnTime
        '
        Me.morAlarmOnTime.Location = New System.Drawing.Point(173, 323)
        Me.morAlarmOnTime.Name = "morAlarmOnTime"
        Me.morAlarmOnTime.Size = New System.Drawing.Size(115, 22)
        Me.morAlarmOnTime.TabIndex = 201
        Me.morAlarmOnTime.Text = "0"
        '
        'Label274
        '
        Me.Label274.Location = New System.Drawing.Point(10, 323)
        Me.Label274.Name = "Label274"
        Me.Label274.Size = New System.Drawing.Size(120, 27)
        Me.Label274.TabIndex = 196
        Me.Label274.Text = "Alarm On Time"
        '
        'morDateOfOperatingReport
        '
        Me.morDateOfOperatingReport.Location = New System.Drawing.Point(173, 351)
        Me.morDateOfOperatingReport.Name = "morDateOfOperatingReport"
        Me.morDateOfOperatingReport.Size = New System.Drawing.Size(115, 22)
        Me.morDateOfOperatingReport.TabIndex = 202
        Me.morDateOfOperatingReport.Text = "0"
        '
        'Label275
        '
        Me.Label275.Location = New System.Drawing.Point(10, 351)
        Me.Label275.Name = "Label275"
        Me.Label275.Size = New System.Drawing.Size(134, 46)
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
        Me.GroupBox3.Location = New System.Drawing.Point(14, 85)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(298, 407)
        Me.GroupBox3.TabIndex = 312
        Me.GroupBox3.TabStop = false
        Me.GroupBox3.Text = "Period Operating Report"
        '
        'morPeriodDateOfOperatingReport
        '
        Me.morPeriodDateOfOperatingReport.Location = New System.Drawing.Point(173, 342)
        Me.morPeriodDateOfOperatingReport.Name = "morPeriodDateOfOperatingReport"
        Me.morPeriodDateOfOperatingReport.Size = New System.Drawing.Size(115, 22)
        Me.morPeriodDateOfOperatingReport.TabIndex = 216
        Me.morPeriodDateOfOperatingReport.Text = "0"
        '
        'morPeriodAlarmOnTime
        '
        Me.morPeriodAlarmOnTime.Location = New System.Drawing.Point(173, 314)
        Me.morPeriodAlarmOnTime.Name = "morPeriodAlarmOnTime"
        Me.morPeriodAlarmOnTime.Size = New System.Drawing.Size(115, 22)
        Me.morPeriodAlarmOnTime.TabIndex = 215
        Me.morPeriodAlarmOnTime.Text = "0"
        '
        'morPeriodExternalInputTime
        '
        Me.morPeriodExternalInputTime.Location = New System.Drawing.Point(173, 286)
        Me.morPeriodExternalInputTime.Name = "morPeriodExternalInputTime"
        Me.morPeriodExternalInputTime.Size = New System.Drawing.Size(115, 22)
        Me.morPeriodExternalInputTime.TabIndex = 214
        Me.morPeriodExternalInputTime.Text = "0"
        '
        'morPeriodSpindleRunTime
        '
        Me.morPeriodSpindleRunTime.Location = New System.Drawing.Point(173, 258)
        Me.morPeriodSpindleRunTime.Name = "morPeriodSpindleRunTime"
        Me.morPeriodSpindleRunTime.Size = New System.Drawing.Size(115, 22)
        Me.morPeriodSpindleRunTime.TabIndex = 213
        Me.morPeriodSpindleRunTime.Text = "0"
        '
        'morPeriodOtherTime
        '
        Me.morPeriodOtherTime.Location = New System.Drawing.Point(173, 231)
        Me.morPeriodOtherTime.Name = "morPeriodOtherTime"
        Me.morPeriodOtherTime.Size = New System.Drawing.Size(115, 22)
        Me.morPeriodOtherTime.TabIndex = 212
        Me.morPeriodOtherTime.Text = "0"
        '
        'morPeriodMaintenanceTime
        '
        Me.morPeriodMaintenanceTime.Location = New System.Drawing.Point(173, 203)
        Me.morPeriodMaintenanceTime.Name = "morPeriodMaintenanceTime"
        Me.morPeriodMaintenanceTime.Size = New System.Drawing.Size(115, 22)
        Me.morPeriodMaintenanceTime.TabIndex = 211
        Me.morPeriodMaintenanceTime.Text = "0"
        '
        'morPeriodNoOperatorTime
        '
        Me.morPeriodNoOperatorTime.Location = New System.Drawing.Point(173, 148)
        Me.morPeriodNoOperatorTime.Name = "morPeriodNoOperatorTime"
        Me.morPeriodNoOperatorTime.Size = New System.Drawing.Size(115, 22)
        Me.morPeriodNoOperatorTime.TabIndex = 209
        Me.morPeriodNoOperatorTime.Text = "0"
        '
        'morPeriodPartWaitingTime
        '
        Me.morPeriodPartWaitingTime.Location = New System.Drawing.Point(173, 175)
        Me.morPeriodPartWaitingTime.Name = "morPeriodPartWaitingTime"
        Me.morPeriodPartWaitingTime.Size = New System.Drawing.Size(115, 22)
        Me.morPeriodPartWaitingTime.TabIndex = 208
        Me.morPeriodPartWaitingTime.Text = "0"
        '
        'morPeriodInproSetupTime
        '
        Me.morPeriodInproSetupTime.Location = New System.Drawing.Point(173, 120)
        Me.morPeriodInproSetupTime.Name = "morPeriodInproSetupTime"
        Me.morPeriodInproSetupTime.Size = New System.Drawing.Size(115, 22)
        Me.morPeriodInproSetupTime.TabIndex = 207
        Me.morPeriodInproSetupTime.Text = "0"
        '
        'morPeriodNonOperatingTime
        '
        Me.morPeriodNonOperatingTime.Location = New System.Drawing.Point(173, 92)
        Me.morPeriodNonOperatingTime.Name = "morPeriodNonOperatingTime"
        Me.morPeriodNonOperatingTime.Size = New System.Drawing.Size(115, 22)
        Me.morPeriodNonOperatingTime.TabIndex = 206
        Me.morPeriodNonOperatingTime.Text = "0"
        '
        'morPeriodCuttingTime
        '
        Me.morPeriodCuttingTime.Location = New System.Drawing.Point(173, 65)
        Me.morPeriodCuttingTime.Name = "morPeriodCuttingTime"
        Me.morPeriodCuttingTime.Size = New System.Drawing.Size(115, 22)
        Me.morPeriodCuttingTime.TabIndex = 205
        Me.morPeriodCuttingTime.Text = "0"
        '
        'morPeriodRunningTime
        '
        Me.morPeriodRunningTime.Location = New System.Drawing.Point(173, 37)
        Me.morPeriodRunningTime.Name = "morPeriodRunningTime"
        Me.morPeriodRunningTime.Size = New System.Drawing.Size(115, 22)
        Me.morPeriodRunningTime.TabIndex = 204
        Me.morPeriodRunningTime.Text = "0"
        '
        'Label65
        '
        Me.Label65.Location = New System.Drawing.Point(10, 18)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(105, 27)
        Me.Label65.TabIndex = 203
        Me.Label65.Text = "Operating Time"
        '
        'Label109
        '
        Me.Label109.Location = New System.Drawing.Point(10, 46)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(120, 27)
        Me.Label109.TabIndex = 203
        Me.Label109.Text = "Runing Time"
        '
        'Label110
        '
        Me.Label110.Location = New System.Drawing.Point(10, 74)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(120, 26)
        Me.Label110.TabIndex = 203
        Me.Label110.Text = "Cutting Time"
        '
        'Label111
        '
        Me.Label111.Location = New System.Drawing.Point(10, 102)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(144, 26)
        Me.Label111.TabIndex = 203
        Me.Label111.Text = "Non Operating Time"
        '
        'Label112
        '
        Me.Label112.Location = New System.Drawing.Point(10, 129)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(120, 27)
        Me.Label112.TabIndex = 203
        Me.Label112.Text = "In Pro Setup Time"
        '
        'Label130
        '
        Me.Label130.Location = New System.Drawing.Point(10, 157)
        Me.Label130.Name = "Label130"
        Me.Label130.Size = New System.Drawing.Size(120, 26)
        Me.Label130.TabIndex = 203
        Me.Label130.Text = "No Operator Time"
        '
        'Label141
        '
        Me.Label141.Location = New System.Drawing.Point(10, 185)
        Me.Label141.Name = "Label141"
        Me.Label141.Size = New System.Drawing.Size(134, 26)
        Me.Label141.TabIndex = 203
        Me.Label141.Text = "Part waiting Time"
        '
        'Label153
        '
        Me.Label153.Location = New System.Drawing.Point(10, 212)
        Me.Label153.Name = "Label153"
        Me.Label153.Size = New System.Drawing.Size(120, 27)
        Me.Label153.TabIndex = 203
        Me.Label153.Text = "Maintenance Time"
        '
        'Label154
        '
        Me.Label154.Location = New System.Drawing.Point(10, 240)
        Me.Label154.Name = "Label154"
        Me.Label154.Size = New System.Drawing.Size(120, 27)
        Me.Label154.TabIndex = 203
        Me.Label154.Text = "Other Time"
        '
        'Label155
        '
        Me.Label155.Location = New System.Drawing.Point(10, 268)
        Me.Label155.Name = "Label155"
        Me.Label155.Size = New System.Drawing.Size(120, 26)
        Me.Label155.TabIndex = 203
        Me.Label155.Text = "Spindle Run Time"
        '
        'Label237
        '
        Me.Label237.Location = New System.Drawing.Point(10, 295)
        Me.Label237.Name = "Label237"
        Me.Label237.Size = New System.Drawing.Size(124, 27)
        Me.Label237.TabIndex = 203
        Me.Label237.Text = "External Input Time"
        '
        'Label238
        '
        Me.Label238.Location = New System.Drawing.Point(10, 323)
        Me.Label238.Name = "Label238"
        Me.Label238.Size = New System.Drawing.Size(120, 27)
        Me.Label238.TabIndex = 203
        Me.Label238.Text = "Alarm On Time"
        '
        'morPeriodOperatingTime
        '
        Me.morPeriodOperatingTime.Location = New System.Drawing.Point(173, 9)
        Me.morPeriodOperatingTime.Name = "morPeriodOperatingTime"
        Me.morPeriodOperatingTime.Size = New System.Drawing.Size(115, 22)
        Me.morPeriodOperatingTime.TabIndex = 203
        Me.morPeriodOperatingTime.Text = "0"
        '
        'Label239
        '
        Me.Label239.Location = New System.Drawing.Point(10, 351)
        Me.Label239.Name = "Label239"
        Me.Label239.Size = New System.Drawing.Size(144, 37)
        Me.Label239.TabIndex = 203
        Me.Label239.Text = "Date Of Operating report"
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
        Me.tab_MacManAlarmHistory.Location = New System.Drawing.Point(4, 25)
        Me.tab_MacManAlarmHistory.Name = "tab_MacManAlarmHistory"
        Me.tab_MacManAlarmHistory.Size = New System.Drawing.Size(1019, 498)
        Me.tab_MacManAlarmHistory.TabIndex = 12
        Me.tab_MacManAlarmHistory.Text = "MacMan Alarm History"
        '
        'grdMMAlarmHistory
        '
        Me.grdMMAlarmHistory.DataMember = ""
        Me.grdMMAlarmHistory.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdMMAlarmHistory.Location = New System.Drawing.Point(16, 192)
        Me.grdMMAlarmHistory.Name = "grdMMAlarmHistory"
        Me.grdMMAlarmHistory.Size = New System.Drawing.Size(912, 280)
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
        Me.GroupBox9.Location = New System.Drawing.Point(10, 9)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(916, 129)
        Me.GroupBox9.TabIndex = 213
        Me.GroupBox9.TabStop = false
        '
        'txtAlarmObject
        '
        Me.txtAlarmObject.Location = New System.Drawing.Point(374, 92)
        Me.txtAlarmObject.Name = "txtAlarmObject"
        Me.txtAlarmObject.Size = New System.Drawing.Size(116, 22)
        Me.txtAlarmObject.TabIndex = 183
        '
        'Label145
        '
        Me.Label145.Location = New System.Drawing.Point(374, 65)
        Me.Label145.Name = "Label145"
        Me.Label145.Size = New System.Drawing.Size(116, 18)
        Me.Label145.TabIndex = 182
        Me.Label145.Text = "Alarm Object:"
        '
        'mahAlarmMessage
        '
        Me.mahAlarmMessage.Location = New System.Drawing.Point(682, 92)
        Me.mahAlarmMessage.Name = "mahAlarmMessage"
        Me.mahAlarmMessage.Size = New System.Drawing.Size(230, 22)
        Me.mahAlarmMessage.TabIndex = 170
        '
        'Label104
        '
        Me.Label104.Location = New System.Drawing.Point(682, 65)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(163, 18)
        Me.Label104.TabIndex = 169
        Me.Label104.Text = "Alarm Message :"
        '
        'mahAlarmDate
        '
        Me.mahAlarmDate.Location = New System.Drawing.Point(10, 92)
        Me.mahAlarmDate.Name = "mahAlarmDate"
        Me.mahAlarmDate.Size = New System.Drawing.Size(105, 22)
        Me.mahAlarmDate.TabIndex = 168
        '
        'Label105
        '
        Me.Label105.Location = New System.Drawing.Point(10, 65)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(105, 18)
        Me.Label105.TabIndex = 167
        Me.Label105.Text = "Alarm Date :"
        '
        'mahAlarmCode
        '
        Me.mahAlarmCode.Location = New System.Drawing.Point(499, 92)
        Me.mahAlarmCode.Name = "mahAlarmCode"
        Me.mahAlarmCode.Size = New System.Drawing.Size(173, 22)
        Me.mahAlarmCode.TabIndex = 166
        '
        'mahAlarmTime
        '
        Me.mahAlarmTime.Location = New System.Drawing.Point(125, 92)
        Me.mahAlarmTime.Name = "mahAlarmTime"
        Me.mahAlarmTime.Size = New System.Drawing.Size(115, 22)
        Me.mahAlarmTime.TabIndex = 174
        '
        'Label106
        '
        Me.Label106.Location = New System.Drawing.Point(499, 65)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(163, 18)
        Me.Label106.TabIndex = 165
        Me.Label106.Text = "Alarm Code :"
        '
        'Label102
        '
        Me.Label102.Location = New System.Drawing.Point(125, 65)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(115, 18)
        Me.Label102.TabIndex = 173
        Me.Label102.Text = "Alarm Time :"
        '
        'mahAlarmNumber
        '
        Me.mahAlarmNumber.Location = New System.Drawing.Point(250, 92)
        Me.mahAlarmNumber.Name = "mahAlarmNumber"
        Me.mahAlarmNumber.Size = New System.Drawing.Size(115, 22)
        Me.mahAlarmNumber.TabIndex = 172
        '
        'Label103
        '
        Me.Label103.Location = New System.Drawing.Point(250, 65)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(115, 18)
        Me.Label103.TabIndex = 171
        Me.Label103.Text = "Alarm Number :"
        '
        'mahUpdateButton
        '
        Me.mahUpdateButton.Location = New System.Drawing.Point(240, 18)
        Me.mahUpdateButton.Name = "mahUpdateButton"
        Me.mahUpdateButton.Size = New System.Drawing.Size(86, 28)
        Me.mahUpdateButton.TabIndex = 181
        Me.mahUpdateButton.Text = "Update"
        '
        'Label107
        '
        Me.Label107.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label107.Location = New System.Drawing.Point(10, 18)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(124, 19)
        Me.Label107.TabIndex = 179
        Me.Label107.Text = "Alarm Index :"
        '
        'mahMaxAlarmCount
        '
        Me.mahMaxAlarmCount.Location = New System.Drawing.Point(768, 18)
        Me.mahMaxAlarmCount.Name = "mahMaxAlarmCount"
        Me.mahMaxAlarmCount.Size = New System.Drawing.Size(106, 22)
        Me.mahMaxAlarmCount.TabIndex = 178
        '
        'Label98
        '
        Me.Label98.Location = New System.Drawing.Point(605, 18)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(144, 19)
        Me.Label98.TabIndex = 177
        Me.Label98.Text = "Max Alarm Count :"
        '
        'mahAlarmCount
        '
        Me.mahAlarmCount.Location = New System.Drawing.Point(470, 18)
        Me.mahAlarmCount.Name = "mahAlarmCount"
        Me.mahAlarmCount.Size = New System.Drawing.Size(116, 22)
        Me.mahAlarmCount.TabIndex = 176
        '
        'Label101
        '
        Me.Label101.Location = New System.Drawing.Point(355, 18)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(96, 19)
        Me.Label101.TabIndex = 175
        Me.Label101.Text = "Alarm Count :"
        '
        'mahAlarmIndex
        '
        Me.mahAlarmIndex.Location = New System.Drawing.Point(144, 18)
        Me.mahAlarmIndex.Name = "mahAlarmIndex"
        Me.mahAlarmIndex.Size = New System.Drawing.Size(77, 22)
        Me.mahAlarmIndex.TabIndex = 180
        Me.mahAlarmIndex.Text = "1"
        '
        'mahTo
        '
        Me.mahTo.Location = New System.Drawing.Point(394, 157)
        Me.mahTo.Name = "mahTo"
        Me.mahTo.Size = New System.Drawing.Size(76, 22)
        Me.mahTo.TabIndex = 212
        Me.mahTo.Text = "2"
        '
        'Label133
        '
        Me.Label133.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label133.Location = New System.Drawing.Point(326, 157)
        Me.Label133.Name = "Label133"
        Me.Label133.Size = New System.Drawing.Size(58, 18)
        Me.Label133.TabIndex = 211
        Me.Label133.Text = "To"
        '
        'mahFrom
        '
        Me.mahFrom.Location = New System.Drawing.Point(211, 157)
        Me.mahFrom.Name = "mahFrom"
        Me.mahFrom.Size = New System.Drawing.Size(77, 22)
        Me.mahFrom.TabIndex = 210
        Me.mahFrom.Text = "1"
        '
        'Label134
        '
        Me.Label134.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label134.Location = New System.Drawing.Point(134, 157)
        Me.Label134.Name = "Label134"
        Me.Label134.Size = New System.Drawing.Size(58, 18)
        Me.Label134.TabIndex = 209
        Me.Label134.Text = "From"
        '
        'mahButtonResults
        '
        Me.mahButtonResults.Location = New System.Drawing.Point(19, 157)
        Me.mahButtonResults.Name = "mahButtonResults"
        Me.mahButtonResults.Size = New System.Drawing.Size(87, 28)
        Me.mahButtonResults.TabIndex = 207
        Me.mahButtonResults.Text = "Update"
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
        Me.tab_MacmanOperationHistory.Location = New System.Drawing.Point(4, 25)
        Me.tab_MacmanOperationHistory.Name = "tab_MacmanOperationHistory"
        Me.tab_MacmanOperationHistory.Size = New System.Drawing.Size(1019, 498)
        Me.tab_MacmanOperationHistory.TabIndex = 14
        Me.tab_MacmanOperationHistory.Text = "MacMan Operation History"
        '
        'mohTo
        '
        Me.mohTo.Location = New System.Drawing.Point(634, 18)
        Me.mohTo.Name = "mohTo"
        Me.mohTo.Size = New System.Drawing.Size(76, 22)
        Me.mohTo.TabIndex = 206
        Me.mohTo.Text = "2"
        '
        'Label131
        '
        Me.Label131.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label131.Location = New System.Drawing.Point(566, 18)
        Me.Label131.Name = "Label131"
        Me.Label131.Size = New System.Drawing.Size(58, 19)
        Me.Label131.TabIndex = 205
        Me.Label131.Text = "To"
        '
        'mohFrom
        '
        Me.mohFrom.Location = New System.Drawing.Point(451, 18)
        Me.mohFrom.Name = "mohFrom"
        Me.mohFrom.Size = New System.Drawing.Size(77, 22)
        Me.mohFrom.TabIndex = 204
        Me.mohFrom.Text = "1"
        '
        'Label132
        '
        Me.Label132.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label132.Location = New System.Drawing.Point(384, 18)
        Me.Label132.Name = "Label132"
        Me.Label132.Size = New System.Drawing.Size(58, 19)
        Me.Label132.TabIndex = 203
        Me.Label132.Text = "From"
        '
        'mohResults
        '
        Me.mohResults.Location = New System.Drawing.Point(221, 55)
        Me.mohResults.Multiline = true
        Me.mohResults.Name = "mohResults"
        Me.mohResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.mohResults.Size = New System.Drawing.Size(662, 379)
        Me.mohResults.TabIndex = 202
        '
        'mohButtonResults
        '
        Me.mohButtonResults.Location = New System.Drawing.Point(797, 18)
        Me.mohButtonResults.Name = "mohButtonResults"
        Me.mohButtonResults.Size = New System.Drawing.Size(86, 28)
        Me.mohButtonResults.TabIndex = 201
        Me.mohButtonResults.Text = "Update"
        '
        'mohUpdateButton
        '
        Me.mohUpdateButton.Location = New System.Drawing.Point(19, 18)
        Me.mohUpdateButton.Name = "mohUpdateButton"
        Me.mohUpdateButton.Size = New System.Drawing.Size(183, 28)
        Me.mohUpdateButton.TabIndex = 198
        Me.mohUpdateButton.Text = "Update"
        '
        'mohOperationIndex
        '
        Me.mohOperationIndex.Location = New System.Drawing.Point(19, 83)
        Me.mohOperationIndex.Name = "mohOperationIndex"
        Me.mohOperationIndex.Size = New System.Drawing.Size(77, 22)
        Me.mohOperationIndex.TabIndex = 197
        Me.mohOperationIndex.Text = "1"
        '
        'Label113
        '
        Me.Label113.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label113.Location = New System.Drawing.Point(19, 55)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(163, 19)
        Me.Label113.TabIndex = 196
        Me.Label113.Text = "Operation History Index :"
        '
        'mohOperationTime
        '
        Me.mohOperationTime.Location = New System.Drawing.Point(19, 277)
        Me.mohOperationTime.Name = "mohOperationTime"
        Me.mohOperationTime.Size = New System.Drawing.Size(183, 22)
        Me.mohOperationTime.TabIndex = 191
        '
        'Label116
        '
        Me.Label116.Location = New System.Drawing.Point(19, 249)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(192, 19)
        Me.Label116.TabIndex = 190
        Me.Label116.Text = "Operation Time :"
        '
        'mohOperationDate
        '
        Me.mohOperationDate.Location = New System.Drawing.Point(19, 212)
        Me.mohOperationDate.Name = "mohOperationDate"
        Me.mohOperationDate.Size = New System.Drawing.Size(183, 22)
        Me.mohOperationDate.TabIndex = 189
        '
        'Label117
        '
        Me.Label117.Location = New System.Drawing.Point(19, 185)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(192, 18)
        Me.Label117.TabIndex = 188
        Me.Label117.Text = "Operation Date :"
        '
        'mohOperationData
        '
        Me.mohOperationData.Location = New System.Drawing.Point(19, 148)
        Me.mohOperationData.Name = "mohOperationData"
        Me.mohOperationData.Size = New System.Drawing.Size(183, 22)
        Me.mohOperationData.TabIndex = 187
        '
        'Label118
        '
        Me.Label118.Location = New System.Drawing.Point(19, 120)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(183, 18)
        Me.Label118.TabIndex = 186
        Me.Label118.Text = "Operation Data :"
        '
        'mohOperationMaxCount
        '
        Me.mohOperationMaxCount.Location = New System.Drawing.Point(19, 406)
        Me.mohOperationMaxCount.Name = "mohOperationMaxCount"
        Me.mohOperationMaxCount.Size = New System.Drawing.Size(183, 22)
        Me.mohOperationMaxCount.TabIndex = 185
        '
        'Label119
        '
        Me.Label119.Location = New System.Drawing.Point(19, 378)
        Me.Label119.Name = "Label119"
        Me.Label119.Size = New System.Drawing.Size(192, 19)
        Me.Label119.TabIndex = 184
        Me.Label119.Text = "Operation History Max Count :"
        '
        'mohOperationCount
        '
        Me.mohOperationCount.Location = New System.Drawing.Point(19, 342)
        Me.mohOperationCount.Name = "mohOperationCount"
        Me.mohOperationCount.Size = New System.Drawing.Size(183, 22)
        Me.mohOperationCount.TabIndex = 183
        '
        'Label120
        '
        Me.Label120.Location = New System.Drawing.Point(19, 314)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(192, 18)
        Me.Label120.TabIndex = 182
        Me.Label120.Text = "Operation History Count :"
        '
        'tab_CurrentAlarm
        '
        Me.tab_CurrentAlarm.Controls.Add(Me.cmdCurrentAlarm_Update)
        Me.tab_CurrentAlarm.Controls.Add(Me.GroupBox20)
        Me.tab_CurrentAlarm.Location = New System.Drawing.Point(4, 25)
        Me.tab_CurrentAlarm.Name = "tab_CurrentAlarm"
        Me.tab_CurrentAlarm.Size = New System.Drawing.Size(1019, 498)
        Me.tab_CurrentAlarm.TabIndex = 24
        Me.tab_CurrentAlarm.Text = "Current Alarm"
        '
        'cmdCurrentAlarm_Update
        '
        Me.cmdCurrentAlarm_Update.Location = New System.Drawing.Point(10, 18)
        Me.cmdCurrentAlarm_Update.Name = "cmdCurrentAlarm_Update"
        Me.cmdCurrentAlarm_Update.Size = New System.Drawing.Size(134, 37)
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
        Me.GroupBox20.Location = New System.Drawing.Point(10, 65)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Size = New System.Drawing.Size(912, 415)
        Me.GroupBox20.TabIndex = 84
        Me.GroupBox20.TabStop = false
        Me.GroupBox20.Text = "Current OSP Alarm"
        '
        'txtCurrentAlarm_AlarmCharacterString
        '
        Me.txtCurrentAlarm_AlarmCharacterString.Location = New System.Drawing.Point(336, 376)
        Me.txtCurrentAlarm_AlarmCharacterString.Name = "txtCurrentAlarm_AlarmCharacterString"
        Me.txtCurrentAlarm_AlarmCharacterString.ReadOnly = true
        Me.txtCurrentAlarm_AlarmCharacterString.Size = New System.Drawing.Size(566, 22)
        Me.txtCurrentAlarm_AlarmCharacterString.TabIndex = 10
        '
        'txtCurrentAlarm_AlarmCode
        '
        Me.txtCurrentAlarm_AlarmCode.Location = New System.Drawing.Point(336, 338)
        Me.txtCurrentAlarm_AlarmCode.Name = "txtCurrentAlarm_AlarmCode"
        Me.txtCurrentAlarm_AlarmCode.ReadOnly = true
        Me.txtCurrentAlarm_AlarmCode.Size = New System.Drawing.Size(566, 22)
        Me.txtCurrentAlarm_AlarmCode.TabIndex = 9
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"),System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(10, 18)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(892, 111)
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = false
        '
        'txtCurrentAlarm_ObjectMessage
        '
        Me.txtCurrentAlarm_ObjectMessage.Location = New System.Drawing.Point(336, 300)
        Me.txtCurrentAlarm_ObjectMessage.Name = "txtCurrentAlarm_ObjectMessage"
        Me.txtCurrentAlarm_ObjectMessage.ReadOnly = true
        Me.txtCurrentAlarm_ObjectMessage.Size = New System.Drawing.Size(566, 22)
        Me.txtCurrentAlarm_ObjectMessage.TabIndex = 7
        '
        'txtCurrentAlarm_AlarmMessage
        '
        Me.txtCurrentAlarm_AlarmMessage.Location = New System.Drawing.Point(336, 262)
        Me.txtCurrentAlarm_AlarmMessage.Name = "txtCurrentAlarm_AlarmMessage"
        Me.txtCurrentAlarm_AlarmMessage.ReadOnly = true
        Me.txtCurrentAlarm_AlarmMessage.Size = New System.Drawing.Size(278, 22)
        Me.txtCurrentAlarm_AlarmMessage.TabIndex = 6
        '
        'txtCurrentAlarm_AlarmLevel
        '
        Me.txtCurrentAlarm_AlarmLevel.Location = New System.Drawing.Point(336, 224)
        Me.txtCurrentAlarm_AlarmLevel.Name = "txtCurrentAlarm_AlarmLevel"
        Me.txtCurrentAlarm_AlarmLevel.ReadOnly = true
        Me.txtCurrentAlarm_AlarmLevel.Size = New System.Drawing.Size(154, 22)
        Me.txtCurrentAlarm_AlarmLevel.TabIndex = 5
        '
        'txtCurrentAlarm_ObjectNumber
        '
        Me.txtCurrentAlarm_ObjectNumber.Location = New System.Drawing.Point(336, 186)
        Me.txtCurrentAlarm_ObjectNumber.Name = "txtCurrentAlarm_ObjectNumber"
        Me.txtCurrentAlarm_ObjectNumber.ReadOnly = true
        Me.txtCurrentAlarm_ObjectNumber.Size = New System.Drawing.Size(67, 22)
        Me.txtCurrentAlarm_ObjectNumber.TabIndex = 4
        '
        'txtCurrentAlarm_AlarmNumber
        '
        Me.txtCurrentAlarm_AlarmNumber.Location = New System.Drawing.Point(336, 148)
        Me.txtCurrentAlarm_AlarmNumber.Name = "txtCurrentAlarm_AlarmNumber"
        Me.txtCurrentAlarm_AlarmNumber.ReadOnly = true
        Me.txtCurrentAlarm_AlarmNumber.Size = New System.Drawing.Size(67, 22)
        Me.txtCurrentAlarm_AlarmNumber.TabIndex = 3
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"),System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(10, 138)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(316, 268)
        Me.PictureBox3.TabIndex = 1
        Me.PictureBox3.TabStop = false
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
        Me.tab_Tools2_1.Location = New System.Drawing.Point(4, 25)
        Me.tab_Tools2_1.Name = "tab_Tools2_1"
        Me.tab_Tools2_1.Size = New System.Drawing.Size(1019, 498)
        Me.tab_Tools2_1.TabIndex = 22
        Me.tab_Tools2_1.Text = "Tools 2 - 2"
        '
        'cmdToolID_Update_1
        '
        Me.cmdToolID_Update_1.Location = New System.Drawing.Point(749, 18)
        Me.cmdToolID_Update_1.Name = "cmdToolID_Update_1"
        Me.cmdToolID_Update_1.Size = New System.Drawing.Size(163, 28)
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
        Me.GroupBox16.Location = New System.Drawing.Point(8, 166)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Size = New System.Drawing.Size(922, 342)
        Me.GroupBox16.TabIndex = 255
        Me.GroupBox16.TabStop = false
        Me.GroupBox16.Text = "Offset"
        '
        'lstToolID_Offset
        '
        Me.lstToolID_Offset.ItemHeight = 16
        Me.lstToolID_Offset.Location = New System.Drawing.Point(365, 194)
        Me.lstToolID_Offset.Name = "lstToolID_Offset"
        Me.lstToolID_Offset.Size = New System.Drawing.Size(317, 116)
        Me.lstToolID_Offset.TabIndex = 278
        '
        'Label212
        '
        Me.Label212.Location = New System.Drawing.Point(19, 212)
        Me.Label212.Name = "Label212"
        Me.Label212.Size = New System.Drawing.Size(115, 19)
        Me.Label212.TabIndex = 277
        Me.Label212.Text = "Offset Index 1/2/3"
        '
        'txtToolID_OffsetIndex123
        '
        Me.txtToolID_OffsetIndex123.Location = New System.Drawing.Point(154, 212)
        Me.txtToolID_OffsetIndex123.Name = "txtToolID_OffsetIndex123"
        Me.txtToolID_OffsetIndex123.Size = New System.Drawing.Size(28, 22)
        Me.txtToolID_OffsetIndex123.TabIndex = 276
        Me.txtToolID_OffsetIndex123.Text = "1"
        '
        'cmdToolID_LengthOffset3_Cal
        '
        Me.cmdToolID_LengthOffset3_Cal.Location = New System.Drawing.Point(432, 92)
        Me.cmdToolID_LengthOffset3_Cal.Name = "cmdToolID_LengthOffset3_Cal"
        Me.cmdToolID_LengthOffset3_Cal.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_LengthOffset3_Cal.TabIndex = 275
        Me.cmdToolID_LengthOffset3_Cal.Text = "Cal"
        '
        'cmdToolID_LengthOffset2_Cal
        '
        Me.cmdToolID_LengthOffset2_Cal.Location = New System.Drawing.Point(432, 55)
        Me.cmdToolID_LengthOffset2_Cal.Name = "cmdToolID_LengthOffset2_Cal"
        Me.cmdToolID_LengthOffset2_Cal.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_LengthOffset2_Cal.TabIndex = 274
        Me.cmdToolID_LengthOffset2_Cal.Text = "Cal"
        '
        'txtToolID_LengthOffset3
        '
        Me.txtToolID_LengthOffset3.Location = New System.Drawing.Point(182, 92)
        Me.txtToolID_LengthOffset3.Name = "txtToolID_LengthOffset3"
        Me.txtToolID_LengthOffset3.ReadOnly = true
        Me.txtToolID_LengthOffset3.Size = New System.Drawing.Size(68, 22)
        Me.txtToolID_LengthOffset3.TabIndex = 270
        Me.txtToolID_LengthOffset3.Text = "0"
        '
        'Label211
        '
        Me.Label211.Location = New System.Drawing.Point(10, 92)
        Me.Label211.Name = "Label211"
        Me.Label211.Size = New System.Drawing.Size(163, 19)
        Me.Label211.TabIndex = 269
        Me.Label211.Text = "Tool Length Offset 3"
        '
        'cmdToolID_LengthOffset3_Add
        '
        Me.cmdToolID_LengthOffset3_Add.Location = New System.Drawing.Point(384, 92)
        Me.cmdToolID_LengthOffset3_Add.Name = "cmdToolID_LengthOffset3_Add"
        Me.cmdToolID_LengthOffset3_Add.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_LengthOffset3_Add.TabIndex = 273
        Me.cmdToolID_LengthOffset3_Add.Text = "Add"
        '
        'txtToolID_LengthOffset3Value
        '
        Me.txtToolID_LengthOffset3Value.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_LengthOffset3Value.Location = New System.Drawing.Point(259, 92)
        Me.txtToolID_LengthOffset3Value.Name = "txtToolID_LengthOffset3Value"
        Me.txtToolID_LengthOffset3Value.Size = New System.Drawing.Size(67, 22)
        Me.txtToolID_LengthOffset3Value.TabIndex = 271
        Me.txtToolID_LengthOffset3Value.Text = "0"
        '
        'cmdToolID_LengthOffset3_Set
        '
        Me.cmdToolID_LengthOffset3_Set.Location = New System.Drawing.Point(336, 92)
        Me.cmdToolID_LengthOffset3_Set.Name = "cmdToolID_LengthOffset3_Set"
        Me.cmdToolID_LengthOffset3_Set.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_LengthOffset3_Set.TabIndex = 272
        Me.cmdToolID_LengthOffset3_Set.Text = "Set"
        '
        'txtToolID_LengthOffset2
        '
        Me.txtToolID_LengthOffset2.Location = New System.Drawing.Point(182, 55)
        Me.txtToolID_LengthOffset2.Name = "txtToolID_LengthOffset2"
        Me.txtToolID_LengthOffset2.ReadOnly = true
        Me.txtToolID_LengthOffset2.Size = New System.Drawing.Size(68, 22)
        Me.txtToolID_LengthOffset2.TabIndex = 265
        Me.txtToolID_LengthOffset2.Text = "0"
        '
        'Label210
        '
        Me.Label210.Location = New System.Drawing.Point(10, 55)
        Me.Label210.Name = "Label210"
        Me.Label210.Size = New System.Drawing.Size(163, 19)
        Me.Label210.TabIndex = 264
        Me.Label210.Text = "Tool Length Offset 2"
        '
        'cmdToolID_LengthOffset2_Add
        '
        Me.cmdToolID_LengthOffset2_Add.Location = New System.Drawing.Point(384, 55)
        Me.cmdToolID_LengthOffset2_Add.Name = "cmdToolID_LengthOffset2_Add"
        Me.cmdToolID_LengthOffset2_Add.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_LengthOffset2_Add.TabIndex = 268
        Me.cmdToolID_LengthOffset2_Add.Text = "Add"
        '
        'txtToolID_LengthOffset2Value
        '
        Me.txtToolID_LengthOffset2Value.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_LengthOffset2Value.Location = New System.Drawing.Point(259, 55)
        Me.txtToolID_LengthOffset2Value.Name = "txtToolID_LengthOffset2Value"
        Me.txtToolID_LengthOffset2Value.Size = New System.Drawing.Size(67, 22)
        Me.txtToolID_LengthOffset2Value.TabIndex = 266
        Me.txtToolID_LengthOffset2Value.Text = "0"
        '
        'cmdToolID_LengthOffset2_Set
        '
        Me.cmdToolID_LengthOffset2_Set.Location = New System.Drawing.Point(336, 55)
        Me.cmdToolID_LengthOffset2_Set.Name = "cmdToolID_LengthOffset2_Set"
        Me.cmdToolID_LengthOffset2_Set.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_LengthOffset2_Set.TabIndex = 267
        Me.cmdToolID_LengthOffset2_Set.Text = "Set"
        '
        'cmdToolID_CutterRCompOffset3_Add
        '
        Me.cmdToolID_CutterRCompOffset3_Add.Location = New System.Drawing.Point(864, 92)
        Me.cmdToolID_CutterRCompOffset3_Add.Name = "cmdToolID_CutterRCompOffset3_Add"
        Me.cmdToolID_CutterRCompOffset3_Add.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_CutterRCompOffset3_Add.TabIndex = 263
        Me.cmdToolID_CutterRCompOffset3_Add.Text = "Add"
        '
        'cmdToolID_CutterRCompOffset3_Set
        '
        Me.cmdToolID_CutterRCompOffset3_Set.Location = New System.Drawing.Point(816, 92)
        Me.cmdToolID_CutterRCompOffset3_Set.Name = "cmdToolID_CutterRCompOffset3_Set"
        Me.cmdToolID_CutterRCompOffset3_Set.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_CutterRCompOffset3_Set.TabIndex = 262
        Me.cmdToolID_CutterRCompOffset3_Set.Text = "Set"
        '
        'txtToolID_CutterRCompOffset3Value
        '
        Me.txtToolID_CutterRCompOffset3Value.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_CutterRCompOffset3Value.Location = New System.Drawing.Point(739, 92)
        Me.txtToolID_CutterRCompOffset3Value.Name = "txtToolID_CutterRCompOffset3Value"
        Me.txtToolID_CutterRCompOffset3Value.Size = New System.Drawing.Size(67, 22)
        Me.txtToolID_CutterRCompOffset3Value.TabIndex = 261
        Me.txtToolID_CutterRCompOffset3Value.Text = "0"
        '
        'Label209
        '
        Me.Label209.Location = New System.Drawing.Point(480, 92)
        Me.Label209.Name = "Label209"
        Me.Label209.Size = New System.Drawing.Size(173, 19)
        Me.Label209.TabIndex = 260
        Me.Label209.Text = "Cutter R. Comp Offset 3"
        '
        'txtToolID_CutterRCompOffset3
        '
        Me.txtToolID_CutterRCompOffset3.Location = New System.Drawing.Point(662, 92)
        Me.txtToolID_CutterRCompOffset3.Name = "txtToolID_CutterRCompOffset3"
        Me.txtToolID_CutterRCompOffset3.ReadOnly = true
        Me.txtToolID_CutterRCompOffset3.Size = New System.Drawing.Size(68, 22)
        Me.txtToolID_CutterRCompOffset3.TabIndex = 259
        Me.txtToolID_CutterRCompOffset3.Text = "0"
        '
        'cmdToolID_CutterRCompOffset2_Add
        '
        Me.cmdToolID_CutterRCompOffset2_Add.Location = New System.Drawing.Point(864, 55)
        Me.cmdToolID_CutterRCompOffset2_Add.Name = "cmdToolID_CutterRCompOffset2_Add"
        Me.cmdToolID_CutterRCompOffset2_Add.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_CutterRCompOffset2_Add.TabIndex = 258
        Me.cmdToolID_CutterRCompOffset2_Add.Text = "Add"
        '
        'cmdToolID_CutterRCompOffset2_Set
        '
        Me.cmdToolID_CutterRCompOffset2_Set.Location = New System.Drawing.Point(816, 55)
        Me.cmdToolID_CutterRCompOffset2_Set.Name = "cmdToolID_CutterRCompOffset2_Set"
        Me.cmdToolID_CutterRCompOffset2_Set.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_CutterRCompOffset2_Set.TabIndex = 257
        Me.cmdToolID_CutterRCompOffset2_Set.Text = "Set"
        '
        'txtToolID_CutterRCompOffset2Value
        '
        Me.txtToolID_CutterRCompOffset2Value.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_CutterRCompOffset2Value.Location = New System.Drawing.Point(739, 55)
        Me.txtToolID_CutterRCompOffset2Value.Name = "txtToolID_CutterRCompOffset2Value"
        Me.txtToolID_CutterRCompOffset2Value.Size = New System.Drawing.Size(67, 22)
        Me.txtToolID_CutterRCompOffset2Value.TabIndex = 256
        Me.txtToolID_CutterRCompOffset2Value.Text = "0"
        '
        'Label208
        '
        Me.Label208.Location = New System.Drawing.Point(480, 55)
        Me.Label208.Name = "Label208"
        Me.Label208.Size = New System.Drawing.Size(173, 19)
        Me.Label208.TabIndex = 255
        Me.Label208.Text = "Cutter R. Comp Offset 2"
        '
        'txtToolID_CutterRCompOffset2
        '
        Me.txtToolID_CutterRCompOffset2.Location = New System.Drawing.Point(662, 55)
        Me.txtToolID_CutterRCompOffset2.Name = "txtToolID_CutterRCompOffset2"
        Me.txtToolID_CutterRCompOffset2.ReadOnly = true
        Me.txtToolID_CutterRCompOffset2.Size = New System.Drawing.Size(68, 22)
        Me.txtToolID_CutterRCompOffset2.TabIndex = 254
        Me.txtToolID_CutterRCompOffset2.Text = "0"
        '
        'cmdToolID_CutterRCompOffset1_Add
        '
        Me.cmdToolID_CutterRCompOffset1_Add.Location = New System.Drawing.Point(864, 18)
        Me.cmdToolID_CutterRCompOffset1_Add.Name = "cmdToolID_CutterRCompOffset1_Add"
        Me.cmdToolID_CutterRCompOffset1_Add.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_CutterRCompOffset1_Add.TabIndex = 253
        Me.cmdToolID_CutterRCompOffset1_Add.Text = "Add"
        '
        'cmdToolID_CutterRCompWearOffset_Add
        '
        Me.cmdToolID_CutterRCompWearOffset_Add.Location = New System.Drawing.Point(864, 129)
        Me.cmdToolID_CutterRCompWearOffset_Add.Name = "cmdToolID_CutterRCompWearOffset_Add"
        Me.cmdToolID_CutterRCompWearOffset_Add.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_CutterRCompWearOffset_Add.TabIndex = 252
        Me.cmdToolID_CutterRCompWearOffset_Add.Text = "Add"
        '
        'txtToolID_LengthOffset1
        '
        Me.txtToolID_LengthOffset1.Location = New System.Drawing.Point(182, 18)
        Me.txtToolID_LengthOffset1.Name = "txtToolID_LengthOffset1"
        Me.txtToolID_LengthOffset1.ReadOnly = true
        Me.txtToolID_LengthOffset1.Size = New System.Drawing.Size(68, 22)
        Me.txtToolID_LengthOffset1.TabIndex = 216
        Me.txtToolID_LengthOffset1.Text = "0"
        '
        'Label182
        '
        Me.Label182.Location = New System.Drawing.Point(10, 18)
        Me.Label182.Name = "Label182"
        Me.Label182.Size = New System.Drawing.Size(163, 19)
        Me.Label182.TabIndex = 215
        Me.Label182.Text = "Tool Length Offset 1"
        '
        'txtToolID_CutterRCompWearOffsetValue
        '
        Me.txtToolID_CutterRCompWearOffsetValue.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_CutterRCompWearOffsetValue.Location = New System.Drawing.Point(739, 129)
        Me.txtToolID_CutterRCompWearOffsetValue.Name = "txtToolID_CutterRCompWearOffsetValue"
        Me.txtToolID_CutterRCompWearOffsetValue.Size = New System.Drawing.Size(67, 22)
        Me.txtToolID_CutterRCompWearOffsetValue.TabIndex = 204
        Me.txtToolID_CutterRCompWearOffsetValue.Text = "0"
        '
        'cmdToolID_CutterRCompWearOffset_Set
        '
        Me.cmdToolID_CutterRCompWearOffset_Set.Location = New System.Drawing.Point(816, 129)
        Me.cmdToolID_CutterRCompWearOffset_Set.Name = "cmdToolID_CutterRCompWearOffset_Set"
        Me.cmdToolID_CutterRCompWearOffset_Set.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_CutterRCompWearOffset_Set.TabIndex = 207
        Me.cmdToolID_CutterRCompWearOffset_Set.Text = "Set"
        '
        'cmdToolID_CutterRCompOffset1_Set
        '
        Me.cmdToolID_CutterRCompOffset1_Set.Location = New System.Drawing.Point(816, 18)
        Me.cmdToolID_CutterRCompOffset1_Set.Name = "cmdToolID_CutterRCompOffset1_Set"
        Me.cmdToolID_CutterRCompOffset1_Set.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_CutterRCompOffset1_Set.TabIndex = 206
        Me.cmdToolID_CutterRCompOffset1_Set.Text = "Set"
        '
        'cmdToolID_LengthOffset1_Add
        '
        Me.cmdToolID_LengthOffset1_Add.Location = New System.Drawing.Point(384, 18)
        Me.cmdToolID_LengthOffset1_Add.Name = "cmdToolID_LengthOffset1_Add"
        Me.cmdToolID_LengthOffset1_Add.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_LengthOffset1_Add.TabIndex = 239
        Me.cmdToolID_LengthOffset1_Add.Text = "Add"
        '
        'txtToolID_CutterRCompOffset1Value
        '
        Me.txtToolID_CutterRCompOffset1Value.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_CutterRCompOffset1Value.Location = New System.Drawing.Point(739, 18)
        Me.txtToolID_CutterRCompOffset1Value.Name = "txtToolID_CutterRCompOffset1Value"
        Me.txtToolID_CutterRCompOffset1Value.Size = New System.Drawing.Size(67, 22)
        Me.txtToolID_CutterRCompOffset1Value.TabIndex = 203
        Me.txtToolID_CutterRCompOffset1Value.Text = "0"
        '
        'Label188
        '
        Me.Label188.Location = New System.Drawing.Point(480, 129)
        Me.Label188.Name = "Label188"
        Me.Label188.Size = New System.Drawing.Size(173, 19)
        Me.Label188.TabIndex = 196
        Me.Label188.Text = "Cutter R Comp Wear Offset"
        '
        'txtToolID_CutterRCompWearOffset
        '
        Me.txtToolID_CutterRCompWearOffset.Location = New System.Drawing.Point(662, 129)
        Me.txtToolID_CutterRCompWearOffset.Name = "txtToolID_CutterRCompWearOffset"
        Me.txtToolID_CutterRCompWearOffset.ReadOnly = true
        Me.txtToolID_CutterRCompWearOffset.Size = New System.Drawing.Size(68, 22)
        Me.txtToolID_CutterRCompWearOffset.TabIndex = 194
        Me.txtToolID_CutterRCompWearOffset.Text = "0"
        '
        'Label189
        '
        Me.Label189.Location = New System.Drawing.Point(480, 18)
        Me.Label189.Name = "Label189"
        Me.Label189.Size = New System.Drawing.Size(173, 19)
        Me.Label189.TabIndex = 195
        Me.Label189.Text = "Cutter R. Comp Offset 1"
        '
        'txtToolID_CutterRCompOffset1
        '
        Me.txtToolID_CutterRCompOffset1.Location = New System.Drawing.Point(662, 18)
        Me.txtToolID_CutterRCompOffset1.Name = "txtToolID_CutterRCompOffset1"
        Me.txtToolID_CutterRCompOffset1.ReadOnly = true
        Me.txtToolID_CutterRCompOffset1.Size = New System.Drawing.Size(68, 22)
        Me.txtToolID_CutterRCompOffset1.TabIndex = 193
        Me.txtToolID_CutterRCompOffset1.Text = "0"
        '
        'cmdToolID_ToolLengthWearOffset_Add
        '
        Me.cmdToolID_ToolLengthWearOffset_Add.Location = New System.Drawing.Point(384, 129)
        Me.cmdToolID_ToolLengthWearOffset_Add.Name = "cmdToolID_ToolLengthWearOffset_Add"
        Me.cmdToolID_ToolLengthWearOffset_Add.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_ToolLengthWearOffset_Add.TabIndex = 224
        Me.cmdToolID_ToolLengthWearOffset_Add.Text = "Add"
        '
        'cmdToolID_ToolLengthWearOffset_Set
        '
        Me.cmdToolID_ToolLengthWearOffset_Set.Location = New System.Drawing.Point(336, 129)
        Me.cmdToolID_ToolLengthWearOffset_Set.Name = "cmdToolID_ToolLengthWearOffset_Set"
        Me.cmdToolID_ToolLengthWearOffset_Set.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_ToolLengthWearOffset_Set.TabIndex = 223
        Me.cmdToolID_ToolLengthWearOffset_Set.Text = "Set"
        '
        'txtToolID_ToolLengthWearOffsetValue
        '
        Me.txtToolID_ToolLengthWearOffsetValue.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_ToolLengthWearOffsetValue.Location = New System.Drawing.Point(259, 129)
        Me.txtToolID_ToolLengthWearOffsetValue.Name = "txtToolID_ToolLengthWearOffsetValue"
        Me.txtToolID_ToolLengthWearOffsetValue.Size = New System.Drawing.Size(67, 22)
        Me.txtToolID_ToolLengthWearOffsetValue.TabIndex = 222
        Me.txtToolID_ToolLengthWearOffsetValue.Text = "0"
        '
        'txtToolID_LengthOffset1Value
        '
        Me.txtToolID_LengthOffset1Value.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_LengthOffset1Value.Location = New System.Drawing.Point(259, 18)
        Me.txtToolID_LengthOffset1Value.Name = "txtToolID_LengthOffset1Value"
        Me.txtToolID_LengthOffset1Value.Size = New System.Drawing.Size(67, 22)
        Me.txtToolID_LengthOffset1Value.TabIndex = 217
        Me.txtToolID_LengthOffset1Value.Text = "0"
        '
        'txtToolID_ToolLengthWearOffset
        '
        Me.txtToolID_ToolLengthWearOffset.Location = New System.Drawing.Point(182, 129)
        Me.txtToolID_ToolLengthWearOffset.Name = "txtToolID_ToolLengthWearOffset"
        Me.txtToolID_ToolLengthWearOffset.ReadOnly = true
        Me.txtToolID_ToolLengthWearOffset.Size = New System.Drawing.Size(68, 22)
        Me.txtToolID_ToolLengthWearOffset.TabIndex = 221
        Me.txtToolID_ToolLengthWearOffset.Text = "0"
        '
        'Label181
        '
        Me.Label181.Location = New System.Drawing.Point(10, 129)
        Me.Label181.Name = "Label181"
        Me.Label181.Size = New System.Drawing.Size(163, 19)
        Me.Label181.TabIndex = 220
        Me.Label181.Text = "Tool Length Wear Offset"
        '
        'cmdToolID_LengthOffset1_Cal
        '
        Me.cmdToolID_LengthOffset1_Cal.Location = New System.Drawing.Point(432, 18)
        Me.cmdToolID_LengthOffset1_Cal.Name = "cmdToolID_LengthOffset1_Cal"
        Me.cmdToolID_LengthOffset1_Cal.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_LengthOffset1_Cal.TabIndex = 219
        Me.cmdToolID_LengthOffset1_Cal.Text = "Cal"
        '
        'cmdToolID_LengthOffset1_Set
        '
        Me.cmdToolID_LengthOffset1_Set.Location = New System.Drawing.Point(336, 18)
        Me.cmdToolID_LengthOffset1_Set.Name = "cmdToolID_LengthOffset1_Set"
        Me.cmdToolID_LengthOffset1_Set.Size = New System.Drawing.Size(38, 28)
        Me.cmdToolID_LengthOffset1_Set.TabIndex = 218
        Me.cmdToolID_LengthOffset1_Set.Text = "Set"
        '
        'cmdToolID_CutterRWearOffset
        '
        Me.cmdToolID_CutterRWearOffset.Location = New System.Drawing.Point(691, 249)
        Me.cmdToolID_CutterRWearOffset.Name = "cmdToolID_CutterRWearOffset"
        Me.cmdToolID_CutterRWearOffset.Size = New System.Drawing.Size(163, 28)
        Me.cmdToolID_CutterRWearOffset.TabIndex = 248
        Me.cmdToolID_CutterRWearOffset.Text = "CutterRadiusWearOffset"
        '
        'cmdToolID_CutterROffset
        '
        Me.cmdToolID_CutterROffset.Location = New System.Drawing.Point(192, 249)
        Me.cmdToolID_CutterROffset.Name = "cmdToolID_CutterROffset"
        Me.cmdToolID_CutterROffset.Size = New System.Drawing.Size(163, 28)
        Me.cmdToolID_CutterROffset.TabIndex = 247
        Me.cmdToolID_CutterROffset.Text = "CutterRadiusOffset"
        '
        'cmdToolID_LengthWearOffset
        '
        Me.cmdToolID_LengthWearOffset.Location = New System.Drawing.Point(691, 212)
        Me.cmdToolID_LengthWearOffset.Name = "cmdToolID_LengthWearOffset"
        Me.cmdToolID_LengthWearOffset.Size = New System.Drawing.Size(163, 28)
        Me.cmdToolID_LengthWearOffset.TabIndex = 246
        Me.cmdToolID_LengthWearOffset.Text = "LengthWearOffset"
        '
        'cmdToolID_LenghtOffset
        '
        Me.cmdToolID_LenghtOffset.Location = New System.Drawing.Point(192, 212)
        Me.cmdToolID_LenghtOffset.Name = "cmdToolID_LenghtOffset"
        Me.cmdToolID_LenghtOffset.Size = New System.Drawing.Size(163, 28)
        Me.cmdToolID_LenghtOffset.TabIndex = 245
        Me.cmdToolID_LenghtOffset.Text = "LengthOffset"
        '
        'txtToolID_ToPot
        '
        Me.txtToolID_ToPot.Location = New System.Drawing.Point(605, 166)
        Me.txtToolID_ToPot.Name = "txtToolID_ToPot"
        Me.txtToolID_ToPot.Size = New System.Drawing.Size(38, 22)
        Me.txtToolID_ToPot.TabIndex = 244
        Me.txtToolID_ToPot.Text = "2"
        '
        'Label176
        '
        Me.Label176.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label176.Location = New System.Drawing.Point(547, 166)
        Me.Label176.Name = "Label176"
        Me.Label176.Size = New System.Drawing.Size(58, 19)
        Me.Label176.TabIndex = 243
        Me.Label176.Text = "To Pot"
        '
        'txtToolID_FromPot
        '
        Me.txtToolID_FromPot.Location = New System.Drawing.Point(461, 166)
        Me.txtToolID_FromPot.Name = "txtToolID_FromPot"
        Me.txtToolID_FromPot.Size = New System.Drawing.Size(38, 22)
        Me.txtToolID_FromPot.TabIndex = 242
        Me.txtToolID_FromPot.Text = "1"
        '
        'Label177
        '
        Me.Label177.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label177.Location = New System.Drawing.Point(374, 166)
        Me.Label177.Name = "Label177"
        Me.Label177.Size = New System.Drawing.Size(87, 19)
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
        Me.GroupBox17.Location = New System.Drawing.Point(10, 55)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(912, 102)
        Me.GroupBox17.TabIndex = 256
        Me.GroupBox17.TabStop = false
        Me.GroupBox17.Text = "Tool Life"
        '
        'txtToolID_ToolLifeRemainingSecond
        '
        Me.txtToolID_ToolLifeRemainingSecond.Location = New System.Drawing.Point(758, 65)
        Me.txtToolID_ToolLifeRemainingSecond.Name = "txtToolID_ToolLifeRemainingSecond"
        Me.txtToolID_ToolLifeRemainingSecond.ReadOnly = true
        Me.txtToolID_ToolLifeRemainingSecond.Size = New System.Drawing.Size(58, 22)
        Me.txtToolID_ToolLifeRemainingSecond.TabIndex = 240
        Me.txtToolID_ToolLifeRemainingSecond.Text = "0"
        '
        'Label178
        '
        Me.Label178.Location = New System.Drawing.Point(758, 18)
        Me.Label178.Name = "Label178"
        Me.Label178.Size = New System.Drawing.Size(144, 37)
        Me.Label178.TabIndex = 239
        Me.Label178.Text = "Tool Life Remaining in Second"
        '
        'cmdToolID_LifeStatus_Set
        '
        Me.cmdToolID_LifeStatus_Set.Location = New System.Drawing.Point(691, 37)
        Me.cmdToolID_LifeStatus_Set.Name = "cmdToolID_LifeStatus_Set"
        Me.cmdToolID_LifeStatus_Set.Size = New System.Drawing.Size(48, 28)
        Me.cmdToolID_LifeStatus_Set.TabIndex = 212
        Me.cmdToolID_LifeStatus_Set.Text = "Set"
        '
        'txtToolID_ToolLifeStatus
        '
        Me.txtToolID_ToolLifeStatus.Location = New System.Drawing.Point(413, 37)
        Me.txtToolID_ToolLifeStatus.Name = "txtToolID_ToolLifeStatus"
        Me.txtToolID_ToolLifeStatus.ReadOnly = true
        Me.txtToolID_ToolLifeStatus.Size = New System.Drawing.Size(115, 22)
        Me.txtToolID_ToolLifeStatus.TabIndex = 211
        Me.txtToolID_ToolLifeStatus.Text = "0"
        '
        'Label184
        '
        Me.Label184.Location = New System.Drawing.Point(326, 37)
        Me.Label184.Name = "Label184"
        Me.Label184.Size = New System.Drawing.Size(77, 18)
        Me.Label184.TabIndex = 210
        Me.Label184.Text = "Tool Status"
        '
        'cmdToolID_ToolLifeMode_Set
        '
        Me.cmdToolID_ToolLifeMode_Set.Location = New System.Drawing.Point(691, 65)
        Me.cmdToolID_ToolLifeMode_Set.Name = "cmdToolID_ToolLifeMode_Set"
        Me.cmdToolID_ToolLifeMode_Set.Size = New System.Drawing.Size(48, 27)
        Me.cmdToolID_ToolLifeMode_Set.TabIndex = 209
        Me.cmdToolID_ToolLifeMode_Set.Text = "Set"
        '
        'Label187
        '
        Me.Label187.Location = New System.Drawing.Point(326, 65)
        Me.Label187.Name = "Label187"
        Me.Label187.Size = New System.Drawing.Size(77, 18)
        Me.Label187.TabIndex = 197
        Me.Label187.Text = "Tool Mode"
        '
        'cboToolID_ToolLifeStatus
        '
        Me.cboToolID_ToolLifeStatus.Items.AddRange(New Object() {"True", "False"})
        Me.cboToolID_ToolLifeStatus.Location = New System.Drawing.Point(538, 37)
        Me.cboToolID_ToolLifeStatus.Name = "cboToolID_ToolLifeStatus"
        Me.cboToolID_ToolLifeStatus.Size = New System.Drawing.Size(144, 24)
        Me.cboToolID_ToolLifeStatus.TabIndex = 238
        '
        'cboToolID_ToolLifeMode
        '
        Me.cboToolID_ToolLifeMode.Location = New System.Drawing.Point(538, 65)
        Me.cboToolID_ToolLifeMode.Name = "cboToolID_ToolLifeMode"
        Me.cboToolID_ToolLifeMode.Size = New System.Drawing.Size(144, 24)
        Me.cboToolID_ToolLifeMode.TabIndex = 237
        '
        'txtToolID_ToolLifeMode
        '
        Me.txtToolID_ToolLifeMode.Location = New System.Drawing.Point(413, 65)
        Me.txtToolID_ToolLifeMode.Name = "txtToolID_ToolLifeMode"
        Me.txtToolID_ToolLifeMode.ReadOnly = true
        Me.txtToolID_ToolLifeMode.Size = New System.Drawing.Size(115, 22)
        Me.txtToolID_ToolLifeMode.TabIndex = 198
        Me.txtToolID_ToolLifeMode.Text = "0"
        '
        'cmdToolID_ToolLifeRemaining_Set
        '
        Me.cmdToolID_ToolLifeRemaining_Set.Location = New System.Drawing.Point(269, 55)
        Me.cmdToolID_ToolLifeRemaining_Set.Name = "cmdToolID_ToolLifeRemaining_Set"
        Me.cmdToolID_ToolLifeRemaining_Set.Size = New System.Drawing.Size(48, 28)
        Me.cmdToolID_ToolLifeRemaining_Set.TabIndex = 233
        Me.cmdToolID_ToolLifeRemaining_Set.Text = "Set"
        '
        'txtToolID_ToolLifeRemainingValue
        '
        Me.txtToolID_ToolLifeRemainingValue.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_ToolLifeRemainingValue.Location = New System.Drawing.Point(211, 55)
        Me.txtToolID_ToolLifeRemainingValue.Name = "txtToolID_ToolLifeRemainingValue"
        Me.txtToolID_ToolLifeRemainingValue.Size = New System.Drawing.Size(48, 22)
        Me.txtToolID_ToolLifeRemainingValue.TabIndex = 232
        Me.txtToolID_ToolLifeRemainingValue.Text = "0"
        '
        'txtToolID_ToolLifeRemaining
        '
        Me.txtToolID_ToolLifeRemaining.Location = New System.Drawing.Point(144, 55)
        Me.txtToolID_ToolLifeRemaining.Name = "txtToolID_ToolLifeRemaining"
        Me.txtToolID_ToolLifeRemaining.ReadOnly = true
        Me.txtToolID_ToolLifeRemaining.Size = New System.Drawing.Size(58, 22)
        Me.txtToolID_ToolLifeRemaining.TabIndex = 231
        Me.txtToolID_ToolLifeRemaining.Text = "0"
        '
        'Label179
        '
        Me.Label179.Location = New System.Drawing.Point(10, 55)
        Me.Label179.Name = "Label179"
        Me.Label179.Size = New System.Drawing.Size(134, 19)
        Me.Label179.TabIndex = 230
        Me.Label179.Text = "Tool Life Remaining"
        '
        'cmdToolID_ToolLife_Set
        '
        Me.cmdToolID_ToolLife_Set.Location = New System.Drawing.Point(269, 28)
        Me.cmdToolID_ToolLife_Set.Name = "cmdToolID_ToolLife_Set"
        Me.cmdToolID_ToolLife_Set.Size = New System.Drawing.Size(48, 27)
        Me.cmdToolID_ToolLife_Set.TabIndex = 229
        Me.cmdToolID_ToolLife_Set.Text = "Set"
        '
        'txtToolID_ToolLifeValue
        '
        Me.txtToolID_ToolLifeValue.ForeColor = System.Drawing.Color.Red
        Me.txtToolID_ToolLifeValue.Location = New System.Drawing.Point(211, 28)
        Me.txtToolID_ToolLifeValue.Name = "txtToolID_ToolLifeValue"
        Me.txtToolID_ToolLifeValue.Size = New System.Drawing.Size(48, 22)
        Me.txtToolID_ToolLifeValue.TabIndex = 228
        Me.txtToolID_ToolLifeValue.Text = "0"
        '
        'txtToolID_ToolLife
        '
        Me.txtToolID_ToolLife.Location = New System.Drawing.Point(144, 28)
        Me.txtToolID_ToolLife.Name = "txtToolID_ToolLife"
        Me.txtToolID_ToolLife.ReadOnly = true
        Me.txtToolID_ToolLife.Size = New System.Drawing.Size(58, 22)
        Me.txtToolID_ToolLife.TabIndex = 227
        Me.txtToolID_ToolLife.Text = "0"
        '
        'Label180
        '
        Me.Label180.Location = New System.Drawing.Point(10, 28)
        Me.Label180.Name = "Label180"
        Me.Label180.Size = New System.Drawing.Size(134, 18)
        Me.Label180.TabIndex = 226
        Me.Label180.Text = "Tool Life"
        '
        'Label207
        '
        Me.Label207.Location = New System.Drawing.Point(278, 18)
        Me.Label207.Name = "Label207"
        Me.Label207.Size = New System.Drawing.Size(77, 19)
        Me.Label207.TabIndex = 254
        Me.Label207.Text = "Data Unit"
        '
        'cmdToolID_DataUnit_Set
        '
        Me.cmdToolID_DataUnit_Set.Location = New System.Drawing.Point(461, 18)
        Me.cmdToolID_DataUnit_Set.Name = "cmdToolID_DataUnit_Set"
        Me.cmdToolID_DataUnit_Set.Size = New System.Drawing.Size(57, 27)
        Me.cmdToolID_DataUnit_Set.TabIndex = 250
        Me.cmdToolID_DataUnit_Set.Text = "Set"
        '
        'cboToolID_DataUnit
        '
        Me.cboToolID_DataUnit.Location = New System.Drawing.Point(365, 18)
        Me.cboToolID_DataUnit.Name = "cboToolID_DataUnit"
        Me.cboToolID_DataUnit.Size = New System.Drawing.Size(86, 24)
        Me.cboToolID_DataUnit.TabIndex = 249
        '
        'txtToolID_PotNo
        '
        Me.txtToolID_PotNo.Location = New System.Drawing.Point(187, 18)
        Me.txtToolID_PotNo.Name = "txtToolID_PotNo"
        Me.txtToolID_PotNo.Size = New System.Drawing.Size(77, 22)
        Me.txtToolID_PotNo.TabIndex = 202
        Me.txtToolID_PotNo.Text = "1"
        '
        'Label185
        '
        Me.Label185.Location = New System.Drawing.Point(14, 18)
        Me.Label185.Name = "Label185"
        Me.Label185.Size = New System.Drawing.Size(164, 19)
        Me.Label185.TabIndex = 201
        Me.Label185.Text = "Tool/Pot Number"
        '
        'tab_Renishaw_2
        '
        Me.tab_Renishaw_2.Controls.Add(Me.GroupBox22)
        Me.tab_Renishaw_2.Location = New System.Drawing.Point(4, 25)
        Me.tab_Renishaw_2.Name = "tab_Renishaw_2"
        Me.tab_Renishaw_2.Size = New System.Drawing.Size(1019, 498)
        Me.tab_Renishaw_2.TabIndex = 26
        Me.tab_Renishaw_2.Text = "Renishaw_2"
        '
        'GroupBox22
        '
        Me.GroupBox22.Controls.Add(Me.btnGetSlopeConverting)
        Me.GroupBox22.Controls.Add(Me.txtSlopeConverting)
        Me.GroupBox22.Controls.Add(Me.GroupBox25)
        Me.GroupBox22.Controls.Add(Me.GroupBox24)
        Me.GroupBox22.Controls.Add(Me.GroupBox23)
        Me.GroupBox22.Location = New System.Drawing.Point(10, 9)
        Me.GroupBox22.Name = "GroupBox22"
        Me.GroupBox22.Size = New System.Drawing.Size(1004, 499)
        Me.GroupBox22.TabIndex = 300
        Me.GroupBox22.TabStop = false
        Me.GroupBox22.Text = "Rotary Axes"
        '
        'btnGetSlopeConverting
        '
        Me.btnGetSlopeConverting.Location = New System.Drawing.Point(10, 305)
        Me.btnGetSlopeConverting.Name = "btnGetSlopeConverting"
        Me.btnGetSlopeConverting.Size = New System.Drawing.Size(153, 37)
        Me.btnGetSlopeConverting.TabIndex = 320
        Me.btnGetSlopeConverting.Text = "Get Slope Converting"
        '
        'txtSlopeConverting
        '
        Me.txtSlopeConverting.BackColor = System.Drawing.SystemColors.Control
        Me.txtSlopeConverting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSlopeConverting.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtSlopeConverting.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtSlopeConverting.Location = New System.Drawing.Point(10, 348)
        Me.txtSlopeConverting.Name = "txtSlopeConverting"
        Me.txtSlopeConverting.Size = New System.Drawing.Size(125, 36)
        Me.txtSlopeConverting.TabIndex = 319
        '
        'GroupBox25
        '
        Me.GroupBox25.Controls.Add(Me.txtRowMatrix)
        Me.GroupBox25.Controls.Add(Me.Label307)
        Me.GroupBox25.Controls.Add(Me.txtColumnMatrix)
        Me.GroupBox25.Controls.Add(Me.txtRotateAmountISC)
        Me.GroupBox25.Controls.Add(Me.btnGetRotateAmoutISC)
        Me.GroupBox25.Controls.Add(Me.txtRotateAmountSC)
        Me.GroupBox25.Controls.Add(Me.btnGetRotateAmoutSC)
        Me.GroupBox25.Controls.Add(Me.txtShiftAmountISC)
        Me.GroupBox25.Controls.Add(Me.btnGetShiftAmoutISC)
        Me.GroupBox25.Controls.Add(Me.txtShiftAmountSC)
        Me.GroupBox25.Controls.Add(Me.btnGetShiftAmoutSC)
        Me.GroupBox25.Controls.Add(Me.Label305)
        Me.GroupBox25.Controls.Add(Me.cboSlopeCoordAxisIndex)
        Me.GroupBox25.Controls.Add(Me.Label306)
        Me.GroupBox25.Location = New System.Drawing.Point(250, 249)
        Me.GroupBox25.Name = "GroupBox25"
        Me.GroupBox25.Size = New System.Drawing.Size(662, 166)
        Me.GroupBox25.TabIndex = 317
        Me.GroupBox25.TabStop = False
        '
        'txtRowMatrix
        '
        Me.txtRowMatrix.Location = New System.Drawing.Point(595, 18)
        Me.txtRowMatrix.Name = "txtRowMatrix"
        Me.txtRowMatrix.Size = New System.Drawing.Size(48, 22)
        Me.txtRowMatrix.TabIndex = 327
        Me.txtRowMatrix.Text = "0"
        '
        'Label307
        '
        Me.Label307.Location = New System.Drawing.Point(509, 18)
        Me.Label307.Name = "Label307"
        Me.Label307.Size = New System.Drawing.Size(67, 28)
        Me.Label307.TabIndex = 326
        Me.Label307.Text = "Row"
        '
        'txtColumnMatrix
        '
        Me.txtColumnMatrix.Location = New System.Drawing.Point(413, 18)
        Me.txtColumnMatrix.Name = "txtColumnMatrix"
        Me.txtColumnMatrix.Size = New System.Drawing.Size(48, 22)
        Me.txtColumnMatrix.TabIndex = 325
        Me.txtColumnMatrix.Text = "0"
        '
        'txtRotateAmountISC
        '
        Me.txtRotateAmountISC.Location = New System.Drawing.Point(518, 102)
        Me.txtRotateAmountISC.Name = "txtRotateAmountISC"
        Me.txtRotateAmountISC.ReadOnly = True
        Me.txtRotateAmountISC.Size = New System.Drawing.Size(125, 22)
        Me.txtRotateAmountISC.TabIndex = 324
        '
        'btnGetRotateAmoutISC
        '
        Me.btnGetRotateAmoutISC.Location = New System.Drawing.Point(326, 102)
        Me.btnGetRotateAmoutISC.Name = "btnGetRotateAmoutISC"
        Me.btnGetRotateAmoutISC.Size = New System.Drawing.Size(183, 36)
        Me.btnGetRotateAmoutISC.TabIndex = 323
        Me.btnGetRotateAmoutISC.Text = "Get Shift Amount Inverse Slope Coord"
        '
        'txtRotateAmountSC
        '
        Me.txtRotateAmountSC.Location = New System.Drawing.Point(518, 55)
        Me.txtRotateAmountSC.Name = "txtRotateAmountSC"
        Me.txtRotateAmountSC.ReadOnly = True
        Me.txtRotateAmountSC.Size = New System.Drawing.Size(125, 22)
        Me.txtRotateAmountSC.TabIndex = 322
        '
        'btnGetRotateAmoutSC
        '
        Me.btnGetRotateAmoutSC.Location = New System.Drawing.Point(326, 55)
        Me.btnGetRotateAmoutSC.Name = "btnGetRotateAmoutSC"
        Me.btnGetRotateAmoutSC.Size = New System.Drawing.Size(183, 37)
        Me.btnGetRotateAmoutSC.TabIndex = 321
        Me.btnGetRotateAmoutSC.Text = "Get Rotate Amount Slope Coord"
        '
        'txtShiftAmountISC
        '
        Me.txtShiftAmountISC.Location = New System.Drawing.Point(202, 102)
        Me.txtShiftAmountISC.Name = "txtShiftAmountISC"
        Me.txtShiftAmountISC.ReadOnly = True
        Me.txtShiftAmountISC.Size = New System.Drawing.Size(115, 22)
        Me.txtShiftAmountISC.TabIndex = 320
        '
        'btnGetShiftAmoutISC
        '
        Me.btnGetShiftAmoutISC.Location = New System.Drawing.Point(10, 102)
        Me.btnGetShiftAmoutISC.Name = "btnGetShiftAmoutISC"
        Me.btnGetShiftAmoutISC.Size = New System.Drawing.Size(182, 36)
        Me.btnGetShiftAmoutISC.TabIndex = 319
        Me.btnGetShiftAmoutISC.Text = "Get Shift Amount Inverse Slope Coord"
        '
        'txtShiftAmountSC
        '
        Me.txtShiftAmountSC.Location = New System.Drawing.Point(202, 55)
        Me.txtShiftAmountSC.Name = "txtShiftAmountSC"
        Me.txtShiftAmountSC.ReadOnly = True
        Me.txtShiftAmountSC.Size = New System.Drawing.Size(115, 22)
        Me.txtShiftAmountSC.TabIndex = 316
        '
        'btnGetShiftAmoutSC
        '
        Me.btnGetShiftAmoutSC.Location = New System.Drawing.Point(10, 55)
        Me.btnGetShiftAmoutSC.Name = "btnGetShiftAmoutSC"
        Me.btnGetShiftAmoutSC.Size = New System.Drawing.Size(182, 37)
        Me.btnGetShiftAmoutSC.TabIndex = 315
        Me.btnGetShiftAmoutSC.Text = "Get Shift Amount Slope Coord"
        '
        'Label305
        '
        Me.Label305.Location = New System.Drawing.Point(10, 18)
        Me.Label305.Name = "Label305"
        Me.Label305.Size = New System.Drawing.Size(86, 28)
        Me.Label305.TabIndex = 312
        Me.Label305.Text = "Linear Axis:"
        '
        'cboSlopeCoordAxisIndex
        '
        Me.cboSlopeCoordAxisIndex.Location = New System.Drawing.Point(115, 18)
        Me.cboSlopeCoordAxisIndex.Name = "cboSlopeCoordAxisIndex"
        Me.cboSlopeCoordAxisIndex.Size = New System.Drawing.Size(77, 24)
        Me.cboSlopeCoordAxisIndex.TabIndex = 311
        '
        'Label306
        '
        Me.Label306.Location = New System.Drawing.Point(326, 18)
        Me.Label306.Name = "Label306"
        Me.Label306.Size = New System.Drawing.Size(68, 28)
        Me.Label306.TabIndex = 313
        Me.Label306.Text = "Column"
        '
        'GroupBox24
        '
        Me.GroupBox24.Controls.Add(Me.btnGetRotatyAxisName)
        Me.GroupBox24.Controls.Add(Me.txtRotaryAxisName)
        Me.GroupBox24.Controls.Add(Me.cboRotaryAxes)
        Me.GroupBox24.Controls.Add(Me.Label262)
        Me.GroupBox24.Controls.Add(Me.btnRotaryAxisSetupStructure)
        Me.GroupBox24.Controls.Add(Me.txtRotaryAxisSetupStructure)
        Me.GroupBox24.Controls.Add(Me.btnRotaryAxisSetupPosition)
        Me.GroupBox24.Controls.Add(Me.txtRotaryAxisSetupPosition)
        Me.GroupBox24.Controls.Add(Me.btnRotaryAxisISO)
        Me.GroupBox24.Controls.Add(Me.txtRotaryAxisISO)
        Me.GroupBox24.Location = New System.Drawing.Point(10, 18)
        Me.GroupBox24.Name = "GroupBox24"
        Me.GroupBox24.Size = New System.Drawing.Size(230, 277)
        Me.GroupBox24.TabIndex = 316
        Me.GroupBox24.TabStop = False
        '
        'btnGetRotatyAxisName
        '
        Me.btnGetRotatyAxisName.Location = New System.Drawing.Point(10, 55)
        Me.btnGetRotatyAxisName.Name = "btnGetRotatyAxisName"
        Me.btnGetRotatyAxisName.Size = New System.Drawing.Size(124, 47)
        Me.btnGetRotatyAxisName.TabIndex = 299
        Me.btnGetRotatyAxisName.Text = "Get rotary axis name"
        '
        'txtRotaryAxisName
        '
        Me.txtRotaryAxisName.Location = New System.Drawing.Point(144, 65)
        Me.txtRotaryAxisName.Name = "txtRotaryAxisName"
        Me.txtRotaryAxisName.ReadOnly = True
        Me.txtRotaryAxisName.Size = New System.Drawing.Size(77, 22)
        Me.txtRotaryAxisName.TabIndex = 13
        '
        'cboRotaryAxes
        '
        Me.cboRotaryAxes.Location = New System.Drawing.Point(144, 18)
        Me.cboRotaryAxes.Name = "cboRotaryAxes"
        Me.cboRotaryAxes.Size = New System.Drawing.Size(77, 24)
        Me.cboRotaryAxes.TabIndex = 2
        '
        'Label262
        '
        Me.Label262.Location = New System.Drawing.Point(10, 18)
        Me.Label262.Name = "Label262"
        Me.Label262.Size = New System.Drawing.Size(124, 28)
        Me.Label262.TabIndex = 306
        Me.Label262.Text = "Rotary Axis Index:"
        '
        'btnRotaryAxisSetupStructure
        '
        Me.btnRotaryAxisSetupStructure.Location = New System.Drawing.Point(10, 222)
        Me.btnRotaryAxisSetupStructure.Name = "btnRotaryAxisSetupStructure"
        Me.btnRotaryAxisSetupStructure.Size = New System.Drawing.Size(124, 46)
        Me.btnRotaryAxisSetupStructure.TabIndex = 305
        Me.btnRotaryAxisSetupStructure.Text = "Get Rotary Axis Setup Structure"
        '
        'txtRotaryAxisSetupStructure
        '
        Me.txtRotaryAxisSetupStructure.Location = New System.Drawing.Point(144, 231)
        Me.txtRotaryAxisSetupStructure.Name = "txtRotaryAxisSetupStructure"
        Me.txtRotaryAxisSetupStructure.ReadOnly = True
        Me.txtRotaryAxisSetupStructure.Size = New System.Drawing.Size(77, 22)
        Me.txtRotaryAxisSetupStructure.TabIndex = 304
        '
        'btnRotaryAxisSetupPosition
        '
        Me.btnRotaryAxisSetupPosition.Location = New System.Drawing.Point(10, 166)
        Me.btnRotaryAxisSetupPosition.Name = "btnRotaryAxisSetupPosition"
        Me.btnRotaryAxisSetupPosition.Size = New System.Drawing.Size(124, 46)
        Me.btnRotaryAxisSetupPosition.TabIndex = 303
        Me.btnRotaryAxisSetupPosition.Text = "Get Rotary Axis Setup Position"
        '
        'txtRotaryAxisSetupPosition
        '
        Me.txtRotaryAxisSetupPosition.Location = New System.Drawing.Point(144, 175)
        Me.txtRotaryAxisSetupPosition.Name = "txtRotaryAxisSetupPosition"
        Me.txtRotaryAxisSetupPosition.ReadOnly = True
        Me.txtRotaryAxisSetupPosition.Size = New System.Drawing.Size(77, 22)
        Me.txtRotaryAxisSetupPosition.TabIndex = 302
        '
        'btnRotaryAxisISO
        '
        Me.btnRotaryAxisISO.Location = New System.Drawing.Point(10, 111)
        Me.btnRotaryAxisISO.Name = "btnRotaryAxisISO"
        Me.btnRotaryAxisISO.Size = New System.Drawing.Size(124, 46)
        Me.btnRotaryAxisISO.TabIndex = 301
        Me.btnRotaryAxisISO.Text = "Is Rotary axis ISO "
        '
        'txtRotaryAxisISO
        '
        Me.txtRotaryAxisISO.Location = New System.Drawing.Point(144, 120)
        Me.txtRotaryAxisISO.Name = "txtRotaryAxisISO"
        Me.txtRotaryAxisISO.ReadOnly = True
        Me.txtRotaryAxisISO.Size = New System.Drawing.Size(77, 22)
        Me.txtRotaryAxisISO.TabIndex = 300
        '
        'GroupBox23
        '
        Me.GroupBox23.Controls.Add(Me.Label304)
        Me.GroupBox23.Controls.Add(Me.cboRotaryAxisStructure)
        Me.GroupBox23.Controls.Add(Me.Label298)
        Me.GroupBox23.Controls.Add(Me.cboLinearAxisIndex)
        Me.GroupBox23.Controls.Add(Me.Label263)
        Me.GroupBox23.Controls.Add(Me.cboRotationCenters)
        Me.GroupBox23.Controls.Add(Me.btnGetRotationCenterSetupPosition)
        Me.GroupBox23.Controls.Add(Me.txtRotationCenterSetupPosition)
        Me.GroupBox23.Location = New System.Drawing.Point(250, 9)
        Me.GroupBox23.Name = "GroupBox23"
        Me.GroupBox23.Size = New System.Drawing.Size(351, 234)
        Me.GroupBox23.TabIndex = 315
        Me.GroupBox23.TabStop = False
        '
        'Label304
        '
        Me.Label304.Location = New System.Drawing.Point(14, 65)
        Me.Label304.Name = "Label304"
        Me.Label304.Size = New System.Drawing.Size(178, 32)
        Me.Label304.TabIndex = 312
        Me.Label304.Text = "Rotation Axis Structure"
        '
        'cboRotaryAxisStructure
        '
        Me.cboRotaryAxisStructure.Location = New System.Drawing.Point(202, 64)
        Me.cboRotaryAxisStructure.Name = "cboRotaryAxisStructure"
        Me.cboRotaryAxisStructure.Size = New System.Drawing.Size(134, 24)
        Me.cboRotaryAxisStructure.TabIndex = 311
        '
        'Label298
        '
        Me.Label298.Location = New System.Drawing.Point(14, 121)
        Me.Label298.Name = "Label298"
        Me.Label298.Size = New System.Drawing.Size(178, 21)
        Me.Label298.TabIndex = 310
        Me.Label298.Text = "Linear Axis:"
        '
        'cboLinearAxisIndex
        '
        Me.cboLinearAxisIndex.Location = New System.Drawing.Point(202, 116)
        Me.cboLinearAxisIndex.Name = "cboLinearAxisIndex"
        Me.cboLinearAxisIndex.Size = New System.Drawing.Size(134, 24)
        Me.cboLinearAxisIndex.TabIndex = 309
        '
        'Label263
        '
        Me.Label263.Location = New System.Drawing.Point(14, 18)
        Me.Label263.Name = "Label263"
        Me.Label263.Size = New System.Drawing.Size(178, 23)
        Me.Label263.TabIndex = 308
        Me.Label263.Text = "Rotation Centers:"
        '
        'cboRotationCenters
        '
        Me.cboRotationCenters.Location = New System.Drawing.Point(202, 18)
        Me.cboRotationCenters.Name = "cboRotationCenters"
        Me.cboRotationCenters.Size = New System.Drawing.Size(134, 24)
        Me.cboRotationCenters.TabIndex = 307
        '
        'btnGetRotationCenterSetupPosition
        '
        Me.btnGetRotationCenterSetupPosition.Location = New System.Drawing.Point(14, 166)
        Me.btnGetRotationCenterSetupPosition.Name = "btnGetRotationCenterSetupPosition"
        Me.btnGetRotationCenterSetupPosition.Size = New System.Drawing.Size(175, 40)
        Me.btnGetRotationCenterSetupPosition.TabIndex = 314
        Me.btnGetRotationCenterSetupPosition.Text = "Get rotary axis position"
        '
        'txtRotationCenterSetupPosition
        '
        Me.txtRotationCenterSetupPosition.Location = New System.Drawing.Point(202, 166)
        Me.txtRotationCenterSetupPosition.Name = "txtRotationCenterSetupPosition"
        Me.txtRotationCenterSetupPosition.ReadOnly = True
        Me.txtRotationCenterSetupPosition.Size = New System.Drawing.Size(134, 22)
        Me.txtRotationCenterSetupPosition.TabIndex = 313
        '
        'tab_axis
        '
        Me.tab_axis.Controls.Add(Me.txtRapidFeedrateOverride)
        Me.tab_axis.Controls.Add(Me.Label322)
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
        Me.tab_axis.Location = New System.Drawing.Point(4, 25)
        Me.tab_axis.Name = "tab_axis"
        Me.tab_axis.Size = New System.Drawing.Size(1019, 498)
        Me.tab_axis.TabIndex = 1
        Me.tab_axis.Text = "Axis"
        '
        'txtRapidFeedrateOverride
        '
        Me.txtRapidFeedrateOverride.BackColor = System.Drawing.SystemColors.Control
        Me.txtRapidFeedrateOverride.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRapidFeedrateOverride.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtRapidFeedrateOverride.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtRapidFeedrateOverride.Location = New System.Drawing.Point(720, 351)
        Me.txtRapidFeedrateOverride.Name = "txtRapidFeedrateOverride"
        Me.txtRapidFeedrateOverride.Size = New System.Drawing.Size(154, 20)
        Me.txtRapidFeedrateOverride.TabIndex = 57
        '
        'Label322
        '
        Me.Label322.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label322.Location = New System.Drawing.Point(518, 351)
        Me.Label322.Name = "Label322"
        Me.Label322.Size = New System.Drawing.Size(183, 18)
        Me.Label322.TabIndex = 56
        Me.Label322.Text = "Rapid Feedrate Override :"
        '
        'txt_RelativeActualPositionProgramCoord
        '
        Me.txt_RelativeActualPositionProgramCoord.BackColor = System.Drawing.SystemColors.Control
        Me.txt_RelativeActualPositionProgramCoord.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_RelativeActualPositionProgramCoord.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txt_RelativeActualPositionProgramCoord.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txt_RelativeActualPositionProgramCoord.Location = New System.Drawing.Point(720, 305)
        Me.txt_RelativeActualPositionProgramCoord.Name = "txt_RelativeActualPositionProgramCoord"
        Me.txt_RelativeActualPositionProgramCoord.Size = New System.Drawing.Size(154, 20)
        Me.txt_RelativeActualPositionProgramCoord.TabIndex = 55
        '
        'Label234
        '
        Me.Label234.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label234.Location = New System.Drawing.Point(518, 305)
        Me.Label234.Name = "Label234"
        Me.Label234.Size = New System.Drawing.Size(183, 37)
        Me.Label234.TabIndex = 54
        Me.Label234.Text = "Relative Actual Position Program Coord"
        '
        'Label206
        '
        Me.Label206.Location = New System.Drawing.Point(10, 74)
        Me.Label206.Name = "Label206"
        Me.Label206.Size = New System.Drawing.Size(67, 26)
        Me.Label206.TabIndex = 53
        Me.Label206.Text = "Data Unit"
        '
        'axisSetDataUnit
        '
        Me.axisSetDataUnit.Location = New System.Drawing.Point(202, 65)
        Me.axisSetDataUnit.Name = "axisSetDataUnit"
        Me.axisSetDataUnit.Size = New System.Drawing.Size(90, 26)
        Me.axisSetDataUnit.TabIndex = 52
        Me.axisSetDataUnit.Text = "Set"
        '
        'axisDataUnit
        '
        Me.axisDataUnit.Location = New System.Drawing.Point(86, 65)
        Me.axisDataUnit.Name = "axisDataUnit"
        Me.axisDataUnit.Size = New System.Drawing.Size(106, 24)
        Me.axisDataUnit.TabIndex = 51
        '
        'AxisTimerStop
        '
        Me.AxisTimerStop.Location = New System.Drawing.Point(586, 65)
        Me.AxisTimerStop.Name = "AxisTimerStop"
        Me.AxisTimerStop.Size = New System.Drawing.Size(124, 27)
        Me.AxisTimerStop.TabIndex = 50
        Me.AxisTimerStop.Text = "Stop"
        '
        'axisTimerStart
        '
        Me.axisTimerStart.Location = New System.Drawing.Point(442, 65)
        Me.axisTimerStart.Name = "axisTimerStart"
        Me.axisTimerStart.Size = New System.Drawing.Size(124, 27)
        Me.axisTimerStart.TabIndex = 49
        Me.axisTimerStart.Text = "Start"
        '
        'axisUpdateButton
        '
        Me.axisUpdateButton.Location = New System.Drawing.Point(298, 65)
        Me.axisUpdateButton.Name = "axisUpdateButton"
        Me.axisUpdateButton.Size = New System.Drawing.Size(124, 27)
        Me.axisUpdateButton.TabIndex = 48
        Me.axisUpdateButton.Text = "Update"
        '
        'maxFeedrateOverride
        '
        Me.maxFeedrateOverride.BackColor = System.Drawing.SystemColors.Control
        Me.maxFeedrateOverride.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.maxFeedrateOverride.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.maxFeedrateOverride.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.maxFeedrateOverride.Location = New System.Drawing.Point(720, 268)
        Me.maxFeedrateOverride.Name = "maxFeedrateOverride"
        Me.maxFeedrateOverride.Size = New System.Drawing.Size(154, 20)
        Me.maxFeedrateOverride.TabIndex = 47
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label26.Location = New System.Drawing.Point(518, 268)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(183, 18)
        Me.Label26.TabIndex = 46
        Me.Label26.Text = "Max Feedrate Override :"
        '
        'feedrateType
        '
        Me.feedrateType.BackColor = System.Drawing.SystemColors.Control
        Me.feedrateType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.feedrateType.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.feedrateType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.feedrateType.Location = New System.Drawing.Point(720, 240)
        Me.feedrateType.Name = "feedrateType"
        Me.feedrateType.Size = New System.Drawing.Size(154, 20)
        Me.feedrateType.TabIndex = 45
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label25.Location = New System.Drawing.Point(518, 240)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(183, 18)
        Me.Label25.TabIndex = 44
        Me.Label25.Text = "Feedrate Type :"
        '
        'feedrateOverride
        '
        Me.feedrateOverride.BackColor = System.Drawing.SystemColors.Control
        Me.feedrateOverride.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.feedrateOverride.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.feedrateOverride.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.feedrateOverride.Location = New System.Drawing.Point(720, 212)
        Me.feedrateOverride.Name = "feedrateOverride"
        Me.feedrateOverride.Size = New System.Drawing.Size(154, 20)
        Me.feedrateOverride.TabIndex = 43
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label24.Location = New System.Drawing.Point(518, 212)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(183, 19)
        Me.Label24.TabIndex = 42
        Me.Label24.Text = "Feedrate Override :"
        '
        'feedHold
        '
        Me.feedHold.BackColor = System.Drawing.SystemColors.Control
        Me.feedHold.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.feedHold.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.feedHold.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.feedHold.Location = New System.Drawing.Point(720, 185)
        Me.feedHold.Name = "feedHold"
        Me.feedHold.Size = New System.Drawing.Size(154, 20)
        Me.feedHold.TabIndex = 41
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label23.Location = New System.Drawing.Point(518, 185)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(183, 18)
        Me.Label23.TabIndex = 40
        Me.Label23.Text = "Feed Hold :"
        '
        'axisType
        '
        Me.axisType.BackColor = System.Drawing.SystemColors.Control
        Me.axisType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.axisType.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.axisType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.axisType.Location = New System.Drawing.Point(720, 157)
        Me.axisType.Name = "axisType"
        Me.axisType.Size = New System.Drawing.Size(154, 20)
        Me.axisType.TabIndex = 39
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label22.Location = New System.Drawing.Point(518, 157)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(183, 18)
        Me.Label22.TabIndex = 38
        Me.Label22.Text = "Axis Type :"
        '
        'axisName
        '
        Me.axisName.BackColor = System.Drawing.SystemColors.Control
        Me.axisName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.axisName.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.axisName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.axisName.Location = New System.Drawing.Point(720, 129)
        Me.axisName.Name = "axisName"
        Me.axisName.Size = New System.Drawing.Size(154, 20)
        Me.axisName.TabIndex = 37
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label21.Location = New System.Drawing.Point(518, 129)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(183, 19)
        Me.Label21.TabIndex = 36
        Me.Label21.Text = "Axis Name :"
        '
        'targetPosition
        '
        Me.targetPosition.BackColor = System.Drawing.SystemColors.Control
        Me.targetPosition.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.targetPosition.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.targetPosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.targetPosition.Location = New System.Drawing.Point(307, 388)
        Me.targetPosition.Name = "targetPosition"
        Me.targetPosition.Size = New System.Drawing.Size(192, 29)
        Me.targetPosition.TabIndex = 35
        Me.targetPosition.Text = "0.00"
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label20.Location = New System.Drawing.Point(19, 388)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(250, 18)
        Me.Label20.TabIndex = 34
        Me.Label20.Text = "Target Position :"
        '
        'distanceTarget
        '
        Me.distanceTarget.BackColor = System.Drawing.SystemColors.Control
        Me.distanceTarget.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.distanceTarget.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.distanceTarget.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.distanceTarget.Location = New System.Drawing.Point(307, 351)
        Me.distanceTarget.Name = "distanceTarget"
        Me.distanceTarget.Size = New System.Drawing.Size(192, 29)
        Me.distanceTarget.TabIndex = 33
        Me.distanceTarget.Text = "0.00"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label19.Location = New System.Drawing.Point(19, 351)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(250, 18)
        Me.Label19.TabIndex = 32
        Me.Label19.Text = "Distance to Target Position :"
        '
        'commandFeedRate
        '
        Me.commandFeedRate.BackColor = System.Drawing.SystemColors.Control
        Me.commandFeedRate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.commandFeedRate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.commandFeedRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.commandFeedRate.Location = New System.Drawing.Point(307, 314)
        Me.commandFeedRate.Name = "commandFeedRate"
        Me.commandFeedRate.Size = New System.Drawing.Size(192, 29)
        Me.commandFeedRate.TabIndex = 31
        Me.commandFeedRate.Text = "0.00"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label18.Location = New System.Drawing.Point(19, 314)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(173, 18)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "Command FeedRate:"
        '
        'axisLoad
        '
        Me.axisLoad.BackColor = System.Drawing.SystemColors.Control
        Me.axisLoad.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.axisLoad.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.axisLoad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.axisLoad.Location = New System.Drawing.Point(307, 277)
        Me.axisLoad.Name = "axisLoad"
        Me.axisLoad.Size = New System.Drawing.Size(192, 29)
        Me.axisLoad.TabIndex = 29
        Me.axisLoad.Text = "0.00"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label17.Location = New System.Drawing.Point(19, 277)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(115, 18)
        Me.Label17.TabIndex = 28
        Me.Label17.Text = "Axis Load:"
        '
        'apProgramCoord
        '
        Me.apProgramCoord.BackColor = System.Drawing.SystemColors.Control
        Me.apProgramCoord.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.apProgramCoord.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.apProgramCoord.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.apProgramCoord.Location = New System.Drawing.Point(307, 240)
        Me.apProgramCoord.Name = "apProgramCoord"
        Me.apProgramCoord.Size = New System.Drawing.Size(192, 29)
        Me.apProgramCoord.TabIndex = 27
        Me.apProgramCoord.Text = "0.00"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label16.Location = New System.Drawing.Point(19, 240)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(250, 18)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Actual Position Program Coordinates:"
        '
        'apMachineCoord
        '
        Me.apMachineCoord.BackColor = System.Drawing.SystemColors.Control
        Me.apMachineCoord.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.apMachineCoord.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.apMachineCoord.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.apMachineCoord.Location = New System.Drawing.Point(307, 203)
        Me.apMachineCoord.Name = "apMachineCoord"
        Me.apMachineCoord.Size = New System.Drawing.Size(192, 29)
        Me.apMachineCoord.TabIndex = 25
        Me.apMachineCoord.Text = "0.00"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label15.Location = New System.Drawing.Point(19, 203)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(250, 19)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Actual Position Machine Coordinates:"
        '
        'apEncoderCoord
        '
        Me.apEncoderCoord.BackColor = System.Drawing.SystemColors.Control
        Me.apEncoderCoord.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.apEncoderCoord.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.apEncoderCoord.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.apEncoderCoord.Location = New System.Drawing.Point(307, 166)
        Me.apEncoderCoord.Name = "apEncoderCoord"
        Me.apEncoderCoord.Size = New System.Drawing.Size(192, 29)
        Me.apEncoderCoord.TabIndex = 23
        Me.apEncoderCoord.Text = "0.00"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label14.Location = New System.Drawing.Point(19, 166)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(250, 19)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Actual Position Encoder Coordinates:"
        '
        'actualFeedrate
        '
        Me.actualFeedrate.BackColor = System.Drawing.SystemColors.Control
        Me.actualFeedrate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.actualFeedrate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.actualFeedrate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.actualFeedrate.Location = New System.Drawing.Point(307, 129)
        Me.actualFeedrate.Name = "actualFeedrate"
        Me.actualFeedrate.Size = New System.Drawing.Size(192, 29)
        Me.actualFeedrate.TabIndex = 21
        Me.actualFeedrate.Text = "0.00"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.Label13.Location = New System.Drawing.Point(528, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(173, 19)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "FeedRate Command Order"
        '
        'feedCommandOrderCombo
        '
        Me.feedCommandOrderCombo.Location = New System.Drawing.Point(701, 18)
        Me.feedCommandOrderCombo.Name = "feedCommandOrderCombo"
        Me.feedCommandOrderCombo.Size = New System.Drawing.Size(144, 24)
        Me.feedCommandOrderCombo.TabIndex = 17
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.Label12.Location = New System.Drawing.Point(250, 18)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 19)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "FeedRate Type"
        '
        'feedTypeCombo
        '
        Me.feedTypeCombo.Location = New System.Drawing.Point(355, 18)
        Me.feedTypeCombo.Name = "feedTypeCombo"
        Me.feedTypeCombo.Size = New System.Drawing.Size(144, 24)
        Me.feedTypeCombo.TabIndex = 15
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.Label11.Location = New System.Drawing.Point(19, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 19)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Axis"
        '
        'axisCombo
        '
        Me.axisCombo.Location = New System.Drawing.Point(67, 18)
        Me.axisCombo.Name = "axisCombo"
        Me.axisCombo.Size = New System.Drawing.Size(144, 24)
        Me.axisCombo.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label10.Location = New System.Drawing.Point(19, 129)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(250, 19)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Actual FeedRate:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Location = New System.Drawing.Point(10, 9)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(883, 46)
        Me.Panel4.TabIndex = 19
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
        Me.tab_Program2.Location = New System.Drawing.Point(4, 25)
        Me.tab_Program2.Name = "tab_Program2"
        Me.tab_Program2.Size = New System.Drawing.Size(1019, 498)
        Me.tab_Program2.TabIndex = 21
        Me.tab_Program2.Text = "Program 2 (G/M Code Macro)"
        '
        'Label168
        '
        Me.Label168.Location = New System.Drawing.Point(629, 342)
        Me.Label168.Name = "Label168"
        Me.Label168.Size = New System.Drawing.Size(144, 26)
        Me.Label168.TabIndex = 27
        Me.Label168.Text = "Program Name:"
        '
        'txtProgramNameInput
        '
        Me.txtProgramNameInput.Location = New System.Drawing.Point(629, 378)
        Me.txtProgramNameInput.Name = "txtProgramNameInput"
        Me.txtProgramNameInput.Size = New System.Drawing.Size(269, 22)
        Me.txtProgramNameInput.TabIndex = 26
        '
        'Label167
        '
        Me.Label167.Location = New System.Drawing.Point(629, 55)
        Me.Label167.Name = "Label167"
        Me.Label167.Size = New System.Drawing.Size(144, 27)
        Me.Label167.TabIndex = 25
        Me.Label167.Text = "Program Name:"
        '
        'txtProgramNameOutput
        '
        Me.txtProgramNameOutput.Location = New System.Drawing.Point(629, 92)
        Me.txtProgramNameOutput.Name = "txtProgramNameOutput"
        Me.txtProgramNameOutput.ReadOnly = true
        Me.txtProgramNameOutput.Size = New System.Drawing.Size(278, 22)
        Me.txtProgramNameOutput.TabIndex = 24
        '
        'Label166
        '
        Me.Label166.Location = New System.Drawing.Point(365, 203)
        Me.Label166.Name = "Label166"
        Me.Label166.Size = New System.Drawing.Size(144, 27)
        Me.Label166.TabIndex = 23
        Me.Label166.Text = "G/M Code Number:"
        '
        'txtGMCode
        '
        Me.txtGMCode.Location = New System.Drawing.Point(365, 240)
        Me.txtGMCode.Name = "txtGMCode"
        Me.txtGMCode.Size = New System.Drawing.Size(144, 22)
        Me.txtGMCode.TabIndex = 22
        Me.txtGMCode.Text = "0"
        '
        'cmdSetProgramNameMCodeCall
        '
        Me.cmdSetProgramNameMCodeCall.Location = New System.Drawing.Point(24, 415)
        Me.cmdSetProgramNameMCodeCall.Name = "cmdSetProgramNameMCodeCall"
        Me.cmdSetProgramNameMCodeCall.Size = New System.Drawing.Size(269, 47)
        Me.cmdSetProgramNameMCodeCall.TabIndex = 19
        Me.cmdSetProgramNameMCodeCall.Text = "Set Program Name to M Code CALL"
        '
        'cmdGetProgramNameMCodeCall
        '
        Me.cmdGetProgramNameMCodeCall.Location = New System.Drawing.Point(24, 129)
        Me.cmdGetProgramNameMCodeCall.Name = "cmdGetProgramNameMCodeCall"
        Me.cmdGetProgramNameMCodeCall.Size = New System.Drawing.Size(269, 46)
        Me.cmdGetProgramNameMCodeCall.TabIndex = 18
        Me.cmdGetProgramNameMCodeCall.Text = "Get Program assigned to M Code CALL"
        '
        'cmdSetProgramNameGCodeMod
        '
        Me.cmdSetProgramNameGCodeMod.Location = New System.Drawing.Point(24, 305)
        Me.cmdSetProgramNameGCodeMod.Name = "cmdSetProgramNameGCodeMod"
        Me.cmdSetProgramNameGCodeMod.Size = New System.Drawing.Size(269, 46)
        Me.cmdSetProgramNameGCodeMod.TabIndex = 17
        Me.cmdSetProgramNameGCodeMod.Text = "Set Program Name to G Code CALL/MODIN"
        '
        'cmdGetProgramNameGCodeMod
        '
        Me.cmdGetProgramNameGCodeMod.Location = New System.Drawing.Point(24, 18)
        Me.cmdGetProgramNameGCodeMod.Name = "cmdGetProgramNameGCodeMod"
        Me.cmdGetProgramNameGCodeMod.Size = New System.Drawing.Size(269, 47)
        Me.cmdGetProgramNameGCodeMod.TabIndex = 16
        Me.cmdGetProgramNameGCodeMod.Text = "Get Program assigned to G Code CALL/MODIN"
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
        Me.tab_MopTool.Location = New System.Drawing.Point(4, 25)
        Me.tab_MopTool.Name = "tab_MopTool"
        Me.tab_MopTool.Size = New System.Drawing.Size(1019, 498)
        Me.tab_MopTool.TabIndex = 5
        Me.tab_MopTool.Text = "MOP Tool"
        '
        'Label233
        '
        Me.Label233.Location = New System.Drawing.Point(451, 425)
        Me.Label233.Name = "Label233"
        Me.Label233.Size = New System.Drawing.Size(163, 18)
        Me.Label233.TabIndex = 204
        Me.Label233.Text = "Max tool Data"
        '
        'TXT_GetMaxMOPToolData
        '
        Me.TXT_GetMaxMOPToolData.Location = New System.Drawing.Point(624, 415)
        Me.TXT_GetMaxMOPToolData.Name = "TXT_GetMaxMOPToolData"
        Me.TXT_GetMaxMOPToolData.Size = New System.Drawing.Size(77, 22)
        Me.TXT_GetMaxMOPToolData.TabIndex = 203
        '
        'mopButtonULValue
        '
        Me.mopButtonULValue.Location = New System.Drawing.Point(374, 268)
        Me.mopButtonULValue.Name = "mopButtonULValue"
        Me.mopButtonULValue.Size = New System.Drawing.Size(48, 27)
        Me.mopButtonULValue.TabIndex = 196
        Me.mopButtonULValue.Text = "Set"
        '
        'mopSetULValue
        '
        Me.mopSetULValue.ForeColor = System.Drawing.Color.Red
        Me.mopSetULValue.Location = New System.Drawing.Point(288, 268)
        Me.mopSetULValue.Name = "mopSetULValue"
        Me.mopSetULValue.Size = New System.Drawing.Size(77, 22)
        Me.mopSetULValue.TabIndex = 195
        Me.mopSetULValue.Text = "0"
        '
        'mopButtonToolDataInput
        '
        Me.mopButtonToolDataInput.Location = New System.Drawing.Point(374, 111)
        Me.mopButtonToolDataInput.Name = "mopButtonToolDataInput"
        Me.mopButtonToolDataInput.Size = New System.Drawing.Size(48, 27)
        Me.mopButtonToolDataInput.TabIndex = 194
        Me.mopButtonToolDataInput.Text = "Set"
        '
        'mopSetToolDataInputMode
        '
        Me.mopSetToolDataInputMode.ForeColor = System.Drawing.Color.Red
        Me.mopSetToolDataInputMode.Location = New System.Drawing.Point(288, 111)
        Me.mopSetToolDataInputMode.Name = "mopSetToolDataInputMode"
        Me.mopSetToolDataInputMode.Size = New System.Drawing.Size(77, 22)
        Me.mopSetToolDataInputMode.TabIndex = 193
        Me.mopSetToolDataInputMode.Text = "0"
        '
        'mopButtonReferenceValue
        '
        Me.mopButtonReferenceValue.Location = New System.Drawing.Point(374, 157)
        Me.mopButtonReferenceValue.Name = "mopButtonReferenceValue"
        Me.mopButtonReferenceValue.Size = New System.Drawing.Size(48, 28)
        Me.mopButtonReferenceValue.TabIndex = 192
        Me.mopButtonReferenceValue.Text = "Set"
        '
        'mopSetReferenceValue
        '
        Me.mopSetReferenceValue.ForeColor = System.Drawing.Color.Red
        Me.mopSetReferenceValue.Location = New System.Drawing.Point(288, 157)
        Me.mopSetReferenceValue.Name = "mopSetReferenceValue"
        Me.mopSetReferenceValue.Size = New System.Drawing.Size(77, 22)
        Me.mopSetReferenceValue.TabIndex = 191
        Me.mopSetReferenceValue.Text = "0"
        '
        'mopButtonOverloadMonitor
        '
        Me.mopButtonOverloadMonitor.Location = New System.Drawing.Point(797, 148)
        Me.mopButtonOverloadMonitor.Name = "mopButtonOverloadMonitor"
        Me.mopButtonOverloadMonitor.Size = New System.Drawing.Size(48, 27)
        Me.mopButtonOverloadMonitor.TabIndex = 190
        Me.mopButtonOverloadMonitor.Text = "Set"
        '
        'mopSetOverloadMonitor
        '
        Me.mopSetOverloadMonitor.ForeColor = System.Drawing.Color.Red
        Me.mopSetOverloadMonitor.Location = New System.Drawing.Point(710, 148)
        Me.mopSetOverloadMonitor.Name = "mopSetOverloadMonitor"
        Me.mopSetOverloadMonitor.Size = New System.Drawing.Size(77, 22)
        Me.mopSetOverloadMonitor.TabIndex = 189
        Me.mopSetOverloadMonitor.Text = "0"
        '
        'mopButtonMinOverride
        '
        Me.mopButtonMinOverride.Location = New System.Drawing.Point(374, 378)
        Me.mopButtonMinOverride.Name = "mopButtonMinOverride"
        Me.mopButtonMinOverride.Size = New System.Drawing.Size(48, 28)
        Me.mopButtonMinOverride.TabIndex = 188
        Me.mopButtonMinOverride.Text = "Set"
        '
        'mopSetMinOverride
        '
        Me.mopSetMinOverride.ForeColor = System.Drawing.Color.Red
        Me.mopSetMinOverride.Location = New System.Drawing.Point(288, 378)
        Me.mopSetMinOverride.Name = "mopSetMinOverride"
        Me.mopSetMinOverride.Size = New System.Drawing.Size(77, 22)
        Me.mopSetMinOverride.TabIndex = 187
        Me.mopSetMinOverride.Text = "0"
        '
        'mopButtonMaxOverride
        '
        Me.mopButtonMaxOverride.Location = New System.Drawing.Point(374, 342)
        Me.mopButtonMaxOverride.Name = "mopButtonMaxOverride"
        Me.mopButtonMaxOverride.Size = New System.Drawing.Size(48, 27)
        Me.mopButtonMaxOverride.TabIndex = 186
        Me.mopButtonMaxOverride.Text = "Set"
        '
        'mopSetMaxOverride
        '
        Me.mopSetMaxOverride.ForeColor = System.Drawing.Color.Red
        Me.mopSetMaxOverride.Location = New System.Drawing.Point(288, 342)
        Me.mopSetMaxOverride.Name = "mopSetMaxOverride"
        Me.mopSetMaxOverride.Size = New System.Drawing.Size(77, 22)
        Me.mopSetMaxOverride.TabIndex = 185
        Me.mopSetMaxOverride.Text = "0"
        '
        'mopButtonLLValue
        '
        Me.mopButtonLLValue.Location = New System.Drawing.Point(374, 305)
        Me.mopButtonLLValue.Name = "mopButtonLLValue"
        Me.mopButtonLLValue.Size = New System.Drawing.Size(48, 27)
        Me.mopButtonLLValue.TabIndex = 184
        Me.mopButtonLLValue.Text = "Set"
        '
        'mopSetLLValue
        '
        Me.mopSetLLValue.ForeColor = System.Drawing.Color.Red
        Me.mopSetLLValue.Location = New System.Drawing.Point(288, 305)
        Me.mopSetLLValue.Name = "mopSetLLValue"
        Me.mopSetLLValue.Size = New System.Drawing.Size(77, 22)
        Me.mopSetLLValue.TabIndex = 183
        Me.mopSetLLValue.Text = "0"
        '
        'mopButtonLimitValue
        '
        Me.mopButtonLimitValue.Location = New System.Drawing.Point(374, 231)
        Me.mopButtonLimitValue.Name = "mopButtonLimitValue"
        Me.mopButtonLimitValue.Size = New System.Drawing.Size(48, 27)
        Me.mopButtonLimitValue.TabIndex = 182
        Me.mopButtonLimitValue.Text = "Set"
        '
        'mopSetLimitValue
        '
        Me.mopSetLimitValue.ForeColor = System.Drawing.Color.Red
        Me.mopSetLimitValue.Location = New System.Drawing.Point(288, 231)
        Me.mopSetLimitValue.Name = "mopSetLimitValue"
        Me.mopSetLimitValue.Size = New System.Drawing.Size(77, 22)
        Me.mopSetLimitValue.TabIndex = 181
        Me.mopSetLimitValue.Text = "0"
        '
        'mopButtonCuttingTime
        '
        Me.mopButtonCuttingTime.Location = New System.Drawing.Point(374, 74)
        Me.mopButtonCuttingTime.Name = "mopButtonCuttingTime"
        Me.mopButtonCuttingTime.Size = New System.Drawing.Size(48, 28)
        Me.mopButtonCuttingTime.TabIndex = 180
        Me.mopButtonCuttingTime.Text = "Set"
        '
        'mopSetCuttingTime
        '
        Me.mopSetCuttingTime.ForeColor = System.Drawing.Color.Red
        Me.mopSetCuttingTime.Location = New System.Drawing.Point(288, 74)
        Me.mopSetCuttingTime.Name = "mopSetCuttingTime"
        Me.mopSetCuttingTime.Size = New System.Drawing.Size(77, 22)
        Me.mopSetCuttingTime.TabIndex = 179
        Me.mopSetCuttingTime.Text = "0"
        '
        'mopbuttonAutoChange
        '
        Me.mopbuttonAutoChange.Location = New System.Drawing.Point(797, 248)
        Me.mopbuttonAutoChange.Name = "mopbuttonAutoChange"
        Me.mopbuttonAutoChange.Size = New System.Drawing.Size(48, 28)
        Me.mopbuttonAutoChange.TabIndex = 178
        Me.mopbuttonAutoChange.Text = "Set"
        '
        'mopSetAutoChange
        '
        Me.mopSetAutoChange.ForeColor = System.Drawing.Color.Red
        Me.mopSetAutoChange.Location = New System.Drawing.Point(710, 248)
        Me.mopSetAutoChange.Name = "mopSetAutoChange"
        Me.mopSetAutoChange.Size = New System.Drawing.Size(77, 22)
        Me.mopSetAutoChange.TabIndex = 177
        Me.mopSetAutoChange.Text = "0"
        '
        'mopButtonUnusualSignalChange
        '
        Me.mopButtonUnusualSignalChange.Location = New System.Drawing.Point(797, 378)
        Me.mopButtonUnusualSignalChange.Name = "mopButtonUnusualSignalChange"
        Me.mopButtonUnusualSignalChange.Size = New System.Drawing.Size(48, 28)
        Me.mopButtonUnusualSignalChange.TabIndex = 176
        Me.mopButtonUnusualSignalChange.Text = "Set"
        '
        'mopSetUnusualSignal
        '
        Me.mopSetUnusualSignal.ForeColor = System.Drawing.Color.Red
        Me.mopSetUnusualSignal.Location = New System.Drawing.Point(710, 378)
        Me.mopSetUnusualSignal.Name = "mopSetUnusualSignal"
        Me.mopSetUnusualSignal.Size = New System.Drawing.Size(77, 22)
        Me.mopSetUnusualSignal.TabIndex = 175
        Me.mopSetUnusualSignal.Text = "0"
        '
        'mopButtonALVValue
        '
        Me.mopButtonALVValue.Location = New System.Drawing.Point(374, 194)
        Me.mopButtonALVValue.Name = "mopButtonALVValue"
        Me.mopButtonALVValue.Size = New System.Drawing.Size(48, 28)
        Me.mopButtonALVValue.TabIndex = 174
        Me.mopButtonALVValue.Text = "Set"
        '
        'mopSetALVValue
        '
        Me.mopSetALVValue.ForeColor = System.Drawing.Color.Red
        Me.mopSetALVValue.Location = New System.Drawing.Point(288, 194)
        Me.mopSetALVValue.Name = "mopSetALVValue"
        Me.mopSetALVValue.Size = New System.Drawing.Size(77, 22)
        Me.mopSetALVValue.TabIndex = 173
        Me.mopSetALVValue.Text = "0"
        '
        'mopButtonAircutReduction
        '
        Me.mopButtonAircutReduction.Location = New System.Drawing.Point(797, 215)
        Me.mopButtonAircutReduction.Name = "mopButtonAircutReduction"
        Me.mopButtonAircutReduction.Size = New System.Drawing.Size(48, 27)
        Me.mopButtonAircutReduction.TabIndex = 172
        Me.mopButtonAircutReduction.Text = "Set"
        '
        'mopSetAircutReduction
        '
        Me.mopSetAircutReduction.ForeColor = System.Drawing.Color.Red
        Me.mopSetAircutReduction.Location = New System.Drawing.Point(710, 215)
        Me.mopSetAircutReduction.Name = "mopSetAircutReduction"
        Me.mopSetAircutReduction.Size = New System.Drawing.Size(77, 22)
        Me.mopSetAircutReduction.TabIndex = 171
        Me.mopSetAircutReduction.Text = "0"
        '
        'mopButtonAircutOverride
        '
        Me.mopButtonAircutOverride.Location = New System.Drawing.Point(374, 415)
        Me.mopButtonAircutOverride.Name = "mopButtonAircutOverride"
        Me.mopButtonAircutOverride.Size = New System.Drawing.Size(48, 28)
        Me.mopButtonAircutOverride.TabIndex = 170
        Me.mopButtonAircutOverride.Text = "Set"
        '
        'mopSetAircutOverride
        '
        Me.mopSetAircutOverride.ForeColor = System.Drawing.Color.Red
        Me.mopSetAircutOverride.Location = New System.Drawing.Point(288, 415)
        Me.mopSetAircutOverride.Name = "mopSetAircutOverride"
        Me.mopSetAircutOverride.Size = New System.Drawing.Size(77, 22)
        Me.mopSetAircutOverride.TabIndex = 169
        Me.mopSetAircutOverride.Text = "0"
        '
        'mopButtonAdaptiveControl
        '
        Me.mopButtonAdaptiveControl.Location = New System.Drawing.Point(797, 181)
        Me.mopButtonAdaptiveControl.Name = "mopButtonAdaptiveControl"
        Me.mopButtonAdaptiveControl.Size = New System.Drawing.Size(48, 28)
        Me.mopButtonAdaptiveControl.TabIndex = 168
        Me.mopButtonAdaptiveControl.Text = "Set"
        '
        'mopSetAdaptiveControl
        '
        Me.mopSetAdaptiveControl.ForeColor = System.Drawing.Color.Red
        Me.mopSetAdaptiveControl.Location = New System.Drawing.Point(710, 181)
        Me.mopSetAdaptiveControl.Name = "mopSetAdaptiveControl"
        Me.mopSetAdaptiveControl.Size = New System.Drawing.Size(77, 22)
        Me.mopSetAdaptiveControl.TabIndex = 167
        Me.mopSetAdaptiveControl.Text = "0"
        '
        'mopUlValue
        '
        Me.mopUlValue.Location = New System.Drawing.Point(202, 268)
        Me.mopUlValue.Name = "mopUlValue"
        Me.mopUlValue.Size = New System.Drawing.Size(76, 22)
        Me.mopUlValue.TabIndex = 100
        '
        'Label121
        '
        Me.Label121.Location = New System.Drawing.Point(29, 268)
        Me.Label121.Name = "Label121"
        Me.Label121.Size = New System.Drawing.Size(163, 18)
        Me.Label121.TabIndex = 99
        Me.Label121.Text = "UL Value :"
        '
        'mopToolDataInputMode
        '
        Me.mopToolDataInputMode.Location = New System.Drawing.Point(202, 111)
        Me.mopToolDataInputMode.Name = "mopToolDataInputMode"
        Me.mopToolDataInputMode.Size = New System.Drawing.Size(76, 22)
        Me.mopToolDataInputMode.TabIndex = 96
        '
        'Label123
        '
        Me.Label123.Location = New System.Drawing.Point(29, 111)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(163, 18)
        Me.Label123.TabIndex = 95
        Me.Label123.Text = "Tool Data Input Mode"
        '
        'mopSignalDiffAlarm
        '
        Me.mopSignalDiffAlarm.Location = New System.Drawing.Point(624, 315)
        Me.mopSignalDiffAlarm.Name = "mopSignalDiffAlarm"
        Me.mopSignalDiffAlarm.Size = New System.Drawing.Size(77, 22)
        Me.mopSignalDiffAlarm.TabIndex = 94
        '
        'Label124
        '
        Me.Label124.Location = New System.Drawing.Point(451, 323)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(163, 19)
        Me.Label124.TabIndex = 93
        Me.Label124.Text = "Signal Different at Alarm"
        '
        'mopReferenceValue
        '
        Me.mopReferenceValue.Location = New System.Drawing.Point(202, 157)
        Me.mopReferenceValue.Name = "mopReferenceValue"
        Me.mopReferenceValue.Size = New System.Drawing.Size(76, 22)
        Me.mopReferenceValue.TabIndex = 92
        '
        'Label56
        '
        Me.Label56.Location = New System.Drawing.Point(29, 157)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(163, 18)
        Me.Label56.TabIndex = 91
        Me.Label56.Text = "Reference Value"
        '
        'mopOverloadMonitor
        '
        Me.mopOverloadMonitor.Location = New System.Drawing.Point(624, 148)
        Me.mopOverloadMonitor.Name = "mopOverloadMonitor"
        Me.mopOverloadMonitor.Size = New System.Drawing.Size(77, 22)
        Me.mopOverloadMonitor.TabIndex = 90
        '
        'Label55
        '
        Me.Label55.Location = New System.Drawing.Point(451, 157)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(163, 18)
        Me.Label55.TabIndex = 89
        Me.Label55.Text = "Overload Monitor"
        '
        'mopMinOverride
        '
        Me.mopMinOverride.Location = New System.Drawing.Point(202, 378)
        Me.mopMinOverride.Name = "mopMinOverride"
        Me.mopMinOverride.Size = New System.Drawing.Size(76, 22)
        Me.mopMinOverride.TabIndex = 88
        '
        'Label54
        '
        Me.Label54.Location = New System.Drawing.Point(29, 378)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(163, 19)
        Me.Label54.TabIndex = 87
        Me.Label54.Text = "Min Override"
        '
        'mopMaxOverride
        '
        Me.mopMaxOverride.Location = New System.Drawing.Point(202, 342)
        Me.mopMaxOverride.Name = "mopMaxOverride"
        Me.mopMaxOverride.Size = New System.Drawing.Size(76, 22)
        Me.mopMaxOverride.TabIndex = 86
        '
        'Label53
        '
        Me.Label53.Location = New System.Drawing.Point(29, 342)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(163, 18)
        Me.Label53.TabIndex = 85
        Me.Label53.Text = "Max Override"
        '
        'mopLLValue
        '
        Me.mopLLValue.Location = New System.Drawing.Point(202, 305)
        Me.mopLLValue.Name = "mopLLValue"
        Me.mopLLValue.Size = New System.Drawing.Size(76, 22)
        Me.mopLLValue.TabIndex = 84
        '
        'Label52
        '
        Me.Label52.Location = New System.Drawing.Point(29, 305)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(163, 18)
        Me.Label52.TabIndex = 83
        Me.Label52.Text = "LL Value"
        '
        'mopLimitValue
        '
        Me.mopLimitValue.Location = New System.Drawing.Point(202, 231)
        Me.mopLimitValue.Name = "mopLimitValue"
        Me.mopLimitValue.Size = New System.Drawing.Size(76, 22)
        Me.mopLimitValue.TabIndex = 82
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(29, 231)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(163, 18)
        Me.Label51.TabIndex = 81
        Me.Label51.Text = "Limit Value"
        '
        'mopCuttingTime
        '
        Me.mopCuttingTime.Location = New System.Drawing.Point(202, 74)
        Me.mopCuttingTime.Name = "mopCuttingTime"
        Me.mopCuttingTime.Size = New System.Drawing.Size(76, 22)
        Me.mopCuttingTime.TabIndex = 80
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(29, 74)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(163, 18)
        Me.Label50.TabIndex = 79
        Me.Label50.Text = "Cutting Time"
        '
        'mopCuttingLoad
        '
        Me.mopCuttingLoad.Location = New System.Drawing.Point(624, 348)
        Me.mopCuttingLoad.Name = "mopCuttingLoad"
        Me.mopCuttingLoad.Size = New System.Drawing.Size(77, 22)
        Me.mopCuttingLoad.TabIndex = 78
        '
        'Label48
        '
        Me.Label48.Location = New System.Drawing.Point(451, 360)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(163, 18)
        Me.Label48.TabIndex = 77
        Me.Label48.Text = "Cutting Load at Alarm"
        '
        'mopAutoChange
        '
        Me.mopAutoChange.Location = New System.Drawing.Point(624, 248)
        Me.mopAutoChange.Name = "mopAutoChange"
        Me.mopAutoChange.Size = New System.Drawing.Size(77, 22)
        Me.mopAutoChange.TabIndex = 76
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(451, 258)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(163, 19)
        Me.Label47.TabIndex = 75
        Me.Label47.Text = "Auto Change"
        '
        'mopUnusualSignal
        '
        Me.mopUnusualSignal.Location = New System.Drawing.Point(624, 382)
        Me.mopUnusualSignal.Name = "mopUnusualSignal"
        Me.mopUnusualSignal.Size = New System.Drawing.Size(77, 22)
        Me.mopUnusualSignal.TabIndex = 74
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(451, 388)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(163, 18)
        Me.Label49.TabIndex = 73
        Me.Label49.Text = "Unusual Signal Change"
        '
        'mopAlarms
        '
        Me.mopAlarms.Location = New System.Drawing.Point(624, 282)
        Me.mopAlarms.Name = "mopAlarms"
        Me.mopAlarms.Size = New System.Drawing.Size(221, 22)
        Me.mopAlarms.TabIndex = 68
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(451, 286)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(163, 19)
        Me.Label46.TabIndex = 67
        Me.Label46.Text = "Alarms"
        '
        'mopALVValue
        '
        Me.mopALVValue.Location = New System.Drawing.Point(202, 194)
        Me.mopALVValue.Name = "mopALVValue"
        Me.mopALVValue.Size = New System.Drawing.Size(76, 22)
        Me.mopALVValue.TabIndex = 66
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(29, 194)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(163, 18)
        Me.Label45.TabIndex = 65
        Me.Label45.Text = "ALV Value"
        '
        'mopAircutReduction
        '
        Me.mopAircutReduction.Location = New System.Drawing.Point(624, 215)
        Me.mopAircutReduction.Name = "mopAircutReduction"
        Me.mopAircutReduction.Size = New System.Drawing.Size(77, 22)
        Me.mopAircutReduction.TabIndex = 63
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(29, 415)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(163, 19)
        Me.Label42.TabIndex = 64
        Me.Label42.Text = "Aircut Override"
        '
        'mopAircutOverride
        '
        Me.mopAircutOverride.Location = New System.Drawing.Point(202, 415)
        Me.mopAircutOverride.Name = "mopAircutOverride"
        Me.mopAircutOverride.Size = New System.Drawing.Size(76, 22)
        Me.mopAircutOverride.TabIndex = 61
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(451, 194)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(163, 18)
        Me.Label43.TabIndex = 62
        Me.Label43.Text = "Adaptive Control"
        '
        'mopAdaptiveControl
        '
        Me.mopAdaptiveControl.Location = New System.Drawing.Point(624, 181)
        Me.mopAdaptiveControl.Name = "mopAdaptiveControl"
        Me.mopAdaptiveControl.Size = New System.Drawing.Size(77, 22)
        Me.mopAdaptiveControl.TabIndex = 59
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(451, 222)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(163, 18)
        Me.Label44.TabIndex = 60
        Me.Label44.Text = "Aircut Reduction"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.Label39.Location = New System.Drawing.Point(451, 18)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(106, 19)
        Me.Label39.TabIndex = 56
        Me.Label39.Text = "Position Type :"
        '
        'mopPositionTypeCombo
        '
        Me.mopPositionTypeCombo.Location = New System.Drawing.Point(557, 18)
        Me.mopPositionTypeCombo.Name = "mopPositionTypeCombo"
        Me.mopPositionTypeCombo.Size = New System.Drawing.Size(144, 24)
        Me.mopPositionTypeCombo.TabIndex = 55
        '
        'Label40
        '
        Me.Label40.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.Label40.Location = New System.Drawing.Point(250, 18)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(105, 19)
        Me.Label40.TabIndex = 54
        Me.Label40.Text = "MOP Tool No."
        '
        'Label41
        '
        Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.Label41.Location = New System.Drawing.Point(19, 18)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(67, 19)
        Me.Label41.TabIndex = 52
        Me.Label41.Text = "Mop Axis"
        '
        'mopAxisCombo
        '
        Me.mopAxisCombo.Location = New System.Drawing.Point(86, 18)
        Me.mopAxisCombo.Name = "mopAxisCombo"
        Me.mopAxisCombo.Size = New System.Drawing.Size(144, 24)
        Me.mopAxisCombo.TabIndex = 51
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.mopToolNumber)
        Me.Panel6.Controls.Add(Me.mopUpdateButton)
        Me.Panel6.Location = New System.Drawing.Point(10, 9)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(883, 46)
        Me.Panel6.TabIndex = 57
        '
        'mopToolNumber
        '
        Me.mopToolNumber.Location = New System.Drawing.Point(346, 9)
        Me.mopToolNumber.Name = "mopToolNumber"
        Me.mopToolNumber.Size = New System.Drawing.Size(76, 22)
        Me.mopToolNumber.TabIndex = 1
        Me.mopToolNumber.Text = "1"
        '
        'mopUpdateButton
        '
        Me.mopUpdateButton.Location = New System.Drawing.Point(720, 9)
        Me.mopUpdateButton.Name = "mopUpdateButton"
        Me.mopUpdateButton.Size = New System.Drawing.Size(154, 28)
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
        Me.GroupBox6.Location = New System.Drawing.Point(442, 55)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(451, 83)
        Me.GroupBox6.TabIndex = 205
        Me.GroupBox6.TabStop = false
        '
        'mopToolDataNumber
        '
        Me.mopToolDataNumber.Location = New System.Drawing.Point(326, 9)
        Me.mopToolDataNumber.Multiline = true
        Me.mopToolDataNumber.Name = "mopToolDataNumber"
        Me.mopToolDataNumber.ReadOnly = true
        Me.mopToolDataNumber.Size = New System.Drawing.Size(106, 28)
        Me.mopToolDataNumber.TabIndex = 211
        Me.mopToolDataNumber.Text = "0"
        '
        'mopDelete
        '
        Me.mopDelete.Location = New System.Drawing.Point(298, 46)
        Me.mopDelete.Name = "mopDelete"
        Me.mopDelete.Size = New System.Drawing.Size(76, 28)
        Me.mopDelete.TabIndex = 210
        Me.mopDelete.Text = "Delete"
        '
        'mopEdit
        '
        Me.mopEdit.Location = New System.Drawing.Point(211, 46)
        Me.mopEdit.Name = "mopEdit"
        Me.mopEdit.Size = New System.Drawing.Size(67, 28)
        Me.mopEdit.TabIndex = 209
        Me.mopEdit.Text = "Edit"
        '
        'Label139
        '
        Me.Label139.Location = New System.Drawing.Point(10, 46)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(96, 19)
        Me.Label139.TabIndex = 208
        Me.Label139.Text = "Class Number"
        '
        'mopCMDClassNumber
        '
        Me.mopCMDClassNumber.Location = New System.Drawing.Point(106, 46)
        Me.mopCMDClassNumber.Name = "mopCMDClassNumber"
        Me.mopCMDClassNumber.Size = New System.Drawing.Size(76, 22)
        Me.mopCMDClassNumber.TabIndex = 207
        Me.mopCMDClassNumber.Text = "1"
        '
        'Label140
        '
        Me.Label140.Location = New System.Drawing.Point(10, 9)
        Me.Label140.Name = "Label140"
        Me.Label140.Size = New System.Drawing.Size(86, 19)
        Me.Label140.TabIndex = 206
        Me.Label140.Text = "Tool Number"
        '
        'mopCMDToolNumber
        '
        Me.mopCMDToolNumber.Location = New System.Drawing.Point(106, 9)
        Me.mopCMDToolNumber.Name = "mopCMDToolNumber"
        Me.mopCMDToolNumber.Size = New System.Drawing.Size(76, 22)
        Me.mopCMDToolNumber.TabIndex = 205
        Me.mopCMDToolNumber.Tag = ""
        Me.mopCMDToolNumber.Text = "1"
        '
        'Label122
        '
        Me.Label122.Location = New System.Drawing.Point(202, 9)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(124, 19)
        Me.Label122.TabIndex = 203
        Me.Label122.Text = "Tool Data Number :"
        '
        'GroupBox7
        '
        Me.GroupBox7.Location = New System.Drawing.Point(19, 55)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(413, 93)
        Me.GroupBox7.TabIndex = 206
        Me.GroupBox7.TabStop = false
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
        Me.tab_spindle.Location = New System.Drawing.Point(4, 25)
        Me.tab_spindle.Name = "tab_spindle"
        Me.tab_spindle.Size = New System.Drawing.Size(1019, 498)
        Me.tab_spindle.TabIndex = 8
        Me.tab_spindle.Text = "Spindle"
        '
        'spinState
        '
        Me.spinState.BackColor = System.Drawing.SystemColors.Control
        Me.spinState.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.spinState.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.spinState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.spinState.Location = New System.Drawing.Point(307, 342)
        Me.spinState.Name = "spinState"
        Me.spinState.Size = New System.Drawing.Size(480, 29)
        Me.spinState.TabIndex = 63
        '
        'Label73
        '
        Me.Label73.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label73.Location = New System.Drawing.Point(19, 342)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(173, 18)
        Me.Label73.TabIndex = 62
        Me.Label73.Text = "Spindle State :"
        '
        'spinUpdate
        '
        Me.spinUpdate.Location = New System.Drawing.Point(384, 65)
        Me.spinUpdate.Name = "spinUpdate"
        Me.spinUpdate.Size = New System.Drawing.Size(125, 27)
        Me.spinUpdate.TabIndex = 61
        Me.spinUpdate.Text = "Update"
        '
        'spinRateOverride
        '
        Me.spinRateOverride.BackColor = System.Drawing.SystemColors.Control
        Me.spinRateOverride.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.spinRateOverride.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.spinRateOverride.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.spinRateOverride.Location = New System.Drawing.Point(307, 305)
        Me.spinRateOverride.Name = "spinRateOverride"
        Me.spinRateOverride.Size = New System.Drawing.Size(192, 29)
        Me.spinRateOverride.TabIndex = 60
        Me.spinRateOverride.Text = "0"
        '
        'Label67
        '
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label67.Location = New System.Drawing.Point(19, 305)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(173, 18)
        Me.Label67.TabIndex = 59
        Me.Label67.Text = "Spindle Rate Override :"
        '
        'spinLoad
        '
        Me.spinLoad.BackColor = System.Drawing.SystemColors.Control
        Me.spinLoad.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.spinLoad.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.spinLoad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.spinLoad.Location = New System.Drawing.Point(307, 268)
        Me.spinLoad.Name = "spinLoad"
        Me.spinLoad.Size = New System.Drawing.Size(192, 29)
        Me.spinLoad.TabIndex = 58
        Me.spinLoad.Text = "0.00"
        '
        'Label68
        '
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label68.Location = New System.Drawing.Point(19, 268)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(115, 18)
        Me.Label68.TabIndex = 57
        Me.Label68.Text = "Spindle Load:"
        '
        'spinOilMist
        '
        Me.spinOilMist.BackColor = System.Drawing.SystemColors.Control
        Me.spinOilMist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.spinOilMist.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.spinOilMist.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.spinOilMist.Location = New System.Drawing.Point(307, 231)
        Me.spinOilMist.Name = "spinOilMist"
        Me.spinOilMist.Size = New System.Drawing.Size(192, 29)
        Me.spinOilMist.TabIndex = 56
        '
        'Label69
        '
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label69.Location = New System.Drawing.Point(19, 231)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(250, 18)
        Me.Label69.TabIndex = 55
        Me.Label69.Text = "Oil Mist Condition :"
        '
        'spinMaxOverrideRate
        '
        Me.spinMaxOverrideRate.BackColor = System.Drawing.SystemColors.Control
        Me.spinMaxOverrideRate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.spinMaxOverrideRate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.spinMaxOverrideRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.spinMaxOverrideRate.Location = New System.Drawing.Point(307, 194)
        Me.spinMaxOverrideRate.Name = "spinMaxOverrideRate"
        Me.spinMaxOverrideRate.Size = New System.Drawing.Size(192, 29)
        Me.spinMaxOverrideRate.TabIndex = 54
        Me.spinMaxOverrideRate.Text = "0"
        '
        'Label70
        '
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label70.Location = New System.Drawing.Point(19, 194)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(250, 18)
        Me.Label70.TabIndex = 53
        Me.Label70.Text = "Max Spindle Rate Override :"
        '
        'spinCommandRate
        '
        Me.spinCommandRate.BackColor = System.Drawing.SystemColors.Control
        Me.spinCommandRate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.spinCommandRate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.spinCommandRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.spinCommandRate.Location = New System.Drawing.Point(307, 157)
        Me.spinCommandRate.Name = "spinCommandRate"
        Me.spinCommandRate.Size = New System.Drawing.Size(192, 29)
        Me.spinCommandRate.TabIndex = 52
        Me.spinCommandRate.Text = "0"
        '
        'Label71
        '
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label71.Location = New System.Drawing.Point(19, 157)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(250, 18)
        Me.Label71.TabIndex = 51
        Me.Label71.Text = "Command Spindle Rate :"
        '
        'spinActualRate
        '
        Me.spinActualRate.BackColor = System.Drawing.SystemColors.Control
        Me.spinActualRate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.spinActualRate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.spinActualRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.spinActualRate.Location = New System.Drawing.Point(307, 120)
        Me.spinActualRate.Name = "spinActualRate"
        Me.spinActualRate.Size = New System.Drawing.Size(192, 29)
        Me.spinActualRate.TabIndex = 50
        Me.spinActualRate.Text = "0"
        '
        'Label72
        '
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label72.Location = New System.Drawing.Point(19, 120)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(240, 18)
        Me.Label72.TabIndex = 49
        Me.Label72.Text = "Actual Spindle Rate :"
        '
        'tab_axis2
        '
        Me.tab_axis2.Controls.Add(Me.txtHiCutProMachiningTolerance)
        Me.tab_axis2.Controls.Add(Me.btnGetHiCutProMachiningTolerance)
        Me.tab_axis2.Controls.Add(Me.txtHiCutProFeedrateUpperLimit)
        Me.tab_axis2.Controls.Add(Me.btnGetHiCutProFeedrateUpperLimit)
        Me.tab_axis2.Controls.Add(Me.GroupBox38)
        Me.tab_axis2.Controls.Add(Me.cmdAxis2DataUnit)
        Me.tab_axis2.Controls.Add(Me.cboAxis2DataUnit)
        Me.tab_axis2.Controls.Add(Me.GroupBox11)
        Me.tab_axis2.Location = New System.Drawing.Point(4, 25)
        Me.tab_axis2.Name = "tab_axis2"
        Me.tab_axis2.Size = New System.Drawing.Size(1019, 498)
        Me.tab_axis2.TabIndex = 18
        Me.tab_axis2.Text = "Axis 2"
        '
        'txtHiCutProMachiningTolerance
        '
        Me.txtHiCutProMachiningTolerance.Location = New System.Drawing.Point(307, 342)
        Me.txtHiCutProMachiningTolerance.Name = "txtHiCutProMachiningTolerance"
        Me.txtHiCutProMachiningTolerance.ReadOnly = true
        Me.txtHiCutProMachiningTolerance.Size = New System.Drawing.Size(77, 22)
        Me.txtHiCutProMachiningTolerance.TabIndex = 303
        Me.txtHiCutProMachiningTolerance.Text = "0.0"
        '
        'btnGetHiCutProMachiningTolerance
        '
        Me.btnGetHiCutProMachiningTolerance.Location = New System.Drawing.Point(10, 342)
        Me.btnGetHiCutProMachiningTolerance.Name = "btnGetHiCutProMachiningTolerance"
        Me.btnGetHiCutProMachiningTolerance.Size = New System.Drawing.Size(278, 27)
        Me.btnGetHiCutProMachiningTolerance.TabIndex = 302
        Me.btnGetHiCutProMachiningTolerance.Text = "Get Hi Cut Pro Machining Tolerance"
        '
        'txtHiCutProFeedrateUpperLimit
        '
        Me.txtHiCutProFeedrateUpperLimit.Location = New System.Drawing.Point(307, 305)
        Me.txtHiCutProFeedrateUpperLimit.Name = "txtHiCutProFeedrateUpperLimit"
        Me.txtHiCutProFeedrateUpperLimit.ReadOnly = true
        Me.txtHiCutProFeedrateUpperLimit.Size = New System.Drawing.Size(77, 22)
        Me.txtHiCutProFeedrateUpperLimit.TabIndex = 301
        Me.txtHiCutProFeedrateUpperLimit.Text = "0.0"
        '
        'btnGetHiCutProFeedrateUpperLimit
        '
        Me.btnGetHiCutProFeedrateUpperLimit.Location = New System.Drawing.Point(10, 305)
        Me.btnGetHiCutProFeedrateUpperLimit.Name = "btnGetHiCutProFeedrateUpperLimit"
        Me.btnGetHiCutProFeedrateUpperLimit.Size = New System.Drawing.Size(278, 27)
        Me.btnGetHiCutProFeedrateUpperLimit.TabIndex = 300
        Me.btnGetHiCutProFeedrateUpperLimit.Text = "Get Hi Cut Pro Feedrate Upper Limit"
        '
        'GroupBox38
        '
        Me.GroupBox38.Controls.Add(Me.txtHomePositionMax)
        Me.GroupBox38.Controls.Add(Me.Label321)
        Me.GroupBox38.Controls.Add(Me.txtHomePositionIndex)
        Me.GroupBox38.Controls.Add(Me.Label316)
        Me.GroupBox38.Controls.Add(Me.txtHomePosition)
        Me.GroupBox38.Controls.Add(Me.Label319)
        Me.GroupBox38.Controls.Add(Me.btnGetHomePosition)
        Me.GroupBox38.Controls.Add(Me.Label320)
        Me.GroupBox38.Controls.Add(Me.cboHomePositionAxis)
        Me.GroupBox38.Controls.Add(Me.txtHomePositionMovementOrder)
        Me.GroupBox38.Controls.Add(Me.Label324)
        Me.GroupBox38.Location = New System.Drawing.Point(10, 157)
        Me.GroupBox38.Name = "GroupBox38"
        Me.GroupBox38.Size = New System.Drawing.Size(902, 138)
        Me.GroupBox38.TabIndex = 299
        Me.GroupBox38.TabStop = false
        Me.GroupBox38.Text = "Home Positions:"
        '
        'txtHomePositionMax
        '
        Me.txtHomePositionMax.Location = New System.Drawing.Point(538, 102)
        Me.txtHomePositionMax.Name = "txtHomePositionMax"
        Me.txtHomePositionMax.ReadOnly = true
        Me.txtHomePositionMax.Size = New System.Drawing.Size(115, 22)
        Me.txtHomePositionMax.TabIndex = 18
        Me.txtHomePositionMax.Text = "0.0"
        '
        'Label321
        '
        Me.Label321.Location = New System.Drawing.Point(374, 102)
        Me.Label321.Name = "Label321"
        Me.Label321.Size = New System.Drawing.Size(154, 27)
        Me.Label321.TabIndex = 17
        Me.Label321.Text = "Max Home Positions:"
        '
        'txtHomePositionIndex
        '
        Me.txtHomePositionIndex.ForeColor = System.Drawing.Color.Red
        Me.txtHomePositionIndex.Location = New System.Drawing.Point(538, 65)
        Me.txtHomePositionIndex.Name = "txtHomePositionIndex"
        Me.txtHomePositionIndex.Size = New System.Drawing.Size(115, 22)
        Me.txtHomePositionIndex.TabIndex = 16
        Me.txtHomePositionIndex.Text = "1"
        '
        'Label316
        '
        Me.Label316.Location = New System.Drawing.Point(374, 65)
        Me.Label316.Name = "Label316"
        Me.Label316.Size = New System.Drawing.Size(135, 27)
        Me.Label316.TabIndex = 15
        Me.Label316.Text = "Home Position Index:"
        '
        'txtHomePosition
        '
        Me.txtHomePosition.Location = New System.Drawing.Point(240, 65)
        Me.txtHomePosition.Name = "txtHomePosition"
        Me.txtHomePosition.ReadOnly = true
        Me.txtHomePosition.Size = New System.Drawing.Size(77, 22)
        Me.txtHomePosition.TabIndex = 12
        Me.txtHomePosition.Text = "0.0"
        '
        'Label319
        '
        Me.Label319.Location = New System.Drawing.Point(10, 65)
        Me.Label319.Name = "Label319"
        Me.Label319.Size = New System.Drawing.Size(220, 27)
        Me.Label319.TabIndex = 8
        Me.Label319.Text = "Home Position:"
        '
        'btnGetHomePosition
        '
        Me.btnGetHomePosition.Location = New System.Drawing.Point(384, 18)
        Me.btnGetHomePosition.Name = "btnGetHomePosition"
        Me.btnGetHomePosition.Size = New System.Drawing.Size(154, 28)
        Me.btnGetHomePosition.TabIndex = 11
        Me.btnGetHomePosition.Text = "Get"
        '
        'Label320
        '
        Me.Label320.Location = New System.Drawing.Point(10, 28)
        Me.Label320.Name = "Label320"
        Me.Label320.Size = New System.Drawing.Size(76, 27)
        Me.Label320.TabIndex = 1
        Me.Label320.Text = "Axis Index"
        '
        'cboHomePositionAxis
        '
        Me.cboHomePositionAxis.Location = New System.Drawing.Point(96, 28)
        Me.cboHomePositionAxis.Name = "cboHomePositionAxis"
        Me.cboHomePositionAxis.Size = New System.Drawing.Size(221, 24)
        Me.cboHomePositionAxis.TabIndex = 0
        '
        'txtHomePositionMovementOrder
        '
        Me.txtHomePositionMovementOrder.Location = New System.Drawing.Point(240, 102)
        Me.txtHomePositionMovementOrder.Name = "txtHomePositionMovementOrder"
        Me.txtHomePositionMovementOrder.ReadOnly = true
        Me.txtHomePositionMovementOrder.Size = New System.Drawing.Size(77, 22)
        Me.txtHomePositionMovementOrder.TabIndex = 21
        Me.txtHomePositionMovementOrder.Text = "0.0"
        '
        'Label324
        '
        Me.Label324.Location = New System.Drawing.Point(10, 102)
        Me.Label324.Name = "Label324"
        Me.Label324.Size = New System.Drawing.Size(201, 27)
        Me.Label324.TabIndex = 20
        Me.Label324.Text = "Home Position Movement Order"
        '
        'cmdAxis2DataUnit
        '
        Me.cmdAxis2DataUnit.Location = New System.Drawing.Point(10, 9)
        Me.cmdAxis2DataUnit.Name = "cmdAxis2DataUnit"
        Me.cmdAxis2DataUnit.Size = New System.Drawing.Size(115, 28)
        Me.cmdAxis2DataUnit.TabIndex = 298
        Me.cmdAxis2DataUnit.Text = "Set Data Unit"
        '
        'cboAxis2DataUnit
        '
        Me.cboAxis2DataUnit.ItemHeight = 16
        Me.cboAxis2DataUnit.Location = New System.Drawing.Point(134, 9)
        Me.cboAxis2DataUnit.Name = "cboAxis2DataUnit"
        Me.cboAxis2DataUnit.Size = New System.Drawing.Size(269, 24)
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
        Me.GroupBox11.Location = New System.Drawing.Point(10, 46)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(902, 102)
        Me.GroupBox11.TabIndex = 7
        Me.GroupBox11.TabStop = false
        Me.GroupBox11.Text = "Variable Limit"
        '
        'Label291
        '
        Me.Label291.Location = New System.Drawing.Point(374, 28)
        Me.Label291.Name = "Label291"
        Me.Label291.Size = New System.Drawing.Size(173, 27)
        Me.Label291.TabIndex = 15
        Me.Label291.Text = "Variable Limit Coordinate"
        '
        'cboUserParameterVariableLimitCoordinate
        '
        Me.cboUserParameterVariableLimitCoordinate.Location = New System.Drawing.Point(566, 28)
        Me.cboUserParameterVariableLimitCoordinate.Name = "cboUserParameterVariableLimitCoordinate"
        Me.cboUserParameterVariableLimitCoordinate.Size = New System.Drawing.Size(260, 24)
        Me.cboUserParameterVariableLimitCoordinate.TabIndex = 14
        '
        'txtUserParameterLimitInput
        '
        Me.txtUserParameterLimitInput.ForeColor = System.Drawing.Color.Red
        Me.txtUserParameterLimitInput.Location = New System.Drawing.Point(384, 65)
        Me.txtUserParameterLimitInput.Name = "txtUserParameterLimitInput"
        Me.txtUserParameterLimitInput.Size = New System.Drawing.Size(115, 22)
        Me.txtUserParameterLimitInput.TabIndex = 13
        Me.txtUserParameterLimitInput.Text = "0.0"
        '
        'txtUserParameterLimit
        '
        Me.txtUserParameterLimit.Location = New System.Drawing.Point(240, 65)
        Me.txtUserParameterLimit.Name = "txtUserParameterLimit"
        Me.txtUserParameterLimit.ReadOnly = true
        Me.txtUserParameterLimit.Size = New System.Drawing.Size(125, 22)
        Me.txtUserParameterLimit.TabIndex = 12
        Me.txtUserParameterLimit.Text = "0.0"
        '
        'Label157
        '
        Me.Label157.Location = New System.Drawing.Point(10, 65)
        Me.Label157.Name = "Label157"
        Me.Label157.Size = New System.Drawing.Size(211, 27)
        Me.Label157.TabIndex = 8
        Me.Label157.Text = "User Parameter Variable Limit"
        '
        'cmdUserParameterVariableLimitAdd
        '
        Me.cmdUserParameterVariableLimitAdd.Location = New System.Drawing.Point(710, 65)
        Me.cmdUserParameterVariableLimitAdd.Name = "cmdUserParameterVariableLimitAdd"
        Me.cmdUserParameterVariableLimitAdd.Size = New System.Drawing.Size(77, 27)
        Me.cmdUserParameterVariableLimitAdd.TabIndex = 10
        Me.cmdUserParameterVariableLimitAdd.Text = "Add"
        '
        'cmdUserParameterVariableLimitSet
        '
        Me.cmdUserParameterVariableLimitSet.Location = New System.Drawing.Point(614, 65)
        Me.cmdUserParameterVariableLimitSet.Name = "cmdUserParameterVariableLimitSet"
        Me.cmdUserParameterVariableLimitSet.Size = New System.Drawing.Size(77, 27)
        Me.cmdUserParameterVariableLimitSet.TabIndex = 9
        Me.cmdUserParameterVariableLimitSet.Text = "Set"
        '
        'cmdUserParameterVariableLimitGet
        '
        Me.cmdUserParameterVariableLimitGet.Location = New System.Drawing.Point(518, 65)
        Me.cmdUserParameterVariableLimitGet.Name = "cmdUserParameterVariableLimitGet"
        Me.cmdUserParameterVariableLimitGet.Size = New System.Drawing.Size(77, 27)
        Me.cmdUserParameterVariableLimitGet.TabIndex = 11
        Me.cmdUserParameterVariableLimitGet.Text = "Get"
        '
        'Label165
        '
        Me.Label165.Location = New System.Drawing.Point(10, 28)
        Me.Label165.Name = "Label165"
        Me.Label165.Size = New System.Drawing.Size(76, 27)
        Me.Label165.TabIndex = 1
        Me.Label165.Text = "Axis Index"
        '
        'cboUserParameterVariableLimitAxis
        '
        Me.cboUserParameterVariableLimitAxis.Location = New System.Drawing.Point(96, 28)
        Me.cboUserParameterVariableLimitAxis.Name = "cboUserParameterVariableLimitAxis"
        Me.cboUserParameterVariableLimitAxis.Size = New System.Drawing.Size(221, 24)
        Me.cboUserParameterVariableLimitAxis.TabIndex = 0
        '
        'Tab_OptionCommonVariables
        '
        Me.Tab_OptionCommonVariables.Controls.Add(Me.txtOpCVOutput)
        Me.Tab_OptionCommonVariables.Controls.Add(Me.grpOptionalCommonVariable)
        Me.Tab_OptionCommonVariables.Location = New System.Drawing.Point(4, 25)
        Me.Tab_OptionCommonVariables.Name = "Tab_OptionCommonVariables"
        Me.Tab_OptionCommonVariables.Size = New System.Drawing.Size(1019, 498)
        Me.Tab_OptionCommonVariables.TabIndex = 27
        Me.Tab_OptionCommonVariables.Text = "Option Common Variable"
        '
        'txtOpCVOutput
        '
        Me.txtOpCVOutput.Location = New System.Drawing.Point(672, 8)
        Me.txtOpCVOutput.Multiline = true
        Me.txtOpCVOutput.Name = "txtOpCVOutput"
        Me.txtOpCVOutput.Size = New System.Drawing.Size(250, 464)
        Me.txtOpCVOutput.TabIndex = 188
        Me.txtOpCVOutput.Text = "1"
        '
        'grpOptionalCommonVariable
        '
        Me.grpOptionalCommonVariable.Controls.Add(Me.Label323)
        Me.grpOptionalCommonVariable.Controls.Add(Me.txtOpCVMax)
        Me.grpOptionalCommonVariable.Controls.Add(Me.Label315)
        Me.grpOptionalCommonVariable.Controls.Add(Me.txtOpCV)
        Me.grpOptionalCommonVariable.Controls.Add(Me.btnGetOpCV)
        Me.grpOptionalCommonVariable.Controls.Add(Me.btnGetAllOpCV)
        Me.grpOptionalCommonVariable.Controls.Add(Me.btnAddOpCV)
        Me.grpOptionalCommonVariable.Controls.Add(Me.btnSetOpCV)
        Me.grpOptionalCommonVariable.Controls.Add(Me.txtOpCVIndex2)
        Me.grpOptionalCommonVariable.Controls.Add(Me.txtOpCVIndex1)
        Me.grpOptionalCommonVariable.Controls.Add(Me.txtOpCVValue)
        Me.grpOptionalCommonVariable.Controls.Add(Me.Label317)
        Me.grpOptionalCommonVariable.Controls.Add(Me.txtOpCVIndex)
        Me.grpOptionalCommonVariable.Controls.Add(Me.Label318)
        Me.grpOptionalCommonVariable.Location = New System.Drawing.Point(10, 9)
        Me.grpOptionalCommonVariable.Name = "grpOptionalCommonVariable"
        Me.grpOptionalCommonVariable.Size = New System.Drawing.Size(652, 203)
        Me.grpOptionalCommonVariable.TabIndex = 187
        Me.grpOptionalCommonVariable.TabStop = false
        Me.grpOptionalCommonVariable.Text = "Optional Common Variables"
        '
        'Label323
        '
        Me.Label323.Location = New System.Drawing.Point(77, 65)
        Me.Label323.Name = "Label323"
        Me.Label323.Size = New System.Drawing.Size(187, 18)
        Me.Label323.TabIndex = 201
        Me.Label323.Text = "Number of Common Variables"
        '
        'txtOpCVMax
        '
        Me.txtOpCVMax.Location = New System.Drawing.Point(278, 65)
        Me.txtOpCVMax.Name = "txtOpCVMax"
        Me.txtOpCVMax.Size = New System.Drawing.Size(53, 22)
        Me.txtOpCVMax.TabIndex = 200
        Me.txtOpCVMax.Text = "0"
        '
        'Label315
        '
        Me.Label315.Location = New System.Drawing.Point(10, 102)
        Me.Label315.Name = "Label315"
        Me.Label315.Size = New System.Drawing.Size(182, 18)
        Me.Label315.TabIndex = 199
        Me.Label315.Text = "Common Variable Value"
        '
        'txtOpCV
        '
        Me.txtOpCV.Location = New System.Drawing.Point(192, 102)
        Me.txtOpCV.Name = "txtOpCV"
        Me.txtOpCV.Size = New System.Drawing.Size(77, 22)
        Me.txtOpCV.TabIndex = 198
        Me.txtOpCV.Text = "1"
        '
        'btnGetOpCV
        '
        Me.btnGetOpCV.Location = New System.Drawing.Point(278, 28)
        Me.btnGetOpCV.Name = "btnGetOpCV"
        Me.btnGetOpCV.Size = New System.Drawing.Size(87, 27)
        Me.btnGetOpCV.TabIndex = 197
        Me.btnGetOpCV.Text = "Update"
        '
        'btnGetAllOpCV
        '
        Me.btnGetAllOpCV.Location = New System.Drawing.Point(557, 157)
        Me.btnGetAllOpCV.Name = "btnGetAllOpCV"
        Me.btnGetAllOpCV.Size = New System.Drawing.Size(86, 28)
        Me.btnGetAllOpCV.TabIndex = 196
        Me.btnGetAllOpCV.Text = "Get All -->"
        '
        'btnAddOpCV
        '
        Me.btnAddOpCV.Location = New System.Drawing.Point(422, 102)
        Me.btnAddOpCV.Name = "btnAddOpCV"
        Me.btnAddOpCV.Size = New System.Drawing.Size(48, 27)
        Me.btnAddOpCV.TabIndex = 193
        Me.btnAddOpCV.Text = "Add"
        '
        'btnSetOpCV
        '
        Me.btnSetOpCV.Location = New System.Drawing.Point(365, 102)
        Me.btnSetOpCV.Name = "btnSetOpCV"
        Me.btnSetOpCV.Size = New System.Drawing.Size(48, 27)
        Me.btnSetOpCV.TabIndex = 192
        Me.btnSetOpCV.Text = "Set"
        '
        'txtOpCVIndex2
        '
        Me.txtOpCVIndex2.Location = New System.Drawing.Point(451, 157)
        Me.txtOpCVIndex2.Name = "txtOpCVIndex2"
        Me.txtOpCVIndex2.Size = New System.Drawing.Size(77, 22)
        Me.txtOpCVIndex2.TabIndex = 191
        Me.txtOpCVIndex2.Text = "10"
        '
        'txtOpCVIndex1
        '
        Me.txtOpCVIndex1.Location = New System.Drawing.Point(278, 157)
        Me.txtOpCVIndex1.Name = "txtOpCVIndex1"
        Me.txtOpCVIndex1.Size = New System.Drawing.Size(77, 22)
        Me.txtOpCVIndex1.TabIndex = 190
        Me.txtOpCVIndex1.Text = "1"
        '
        'txtOpCVValue
        '
        Me.txtOpCVValue.ForeColor = System.Drawing.Color.Red
        Me.txtOpCVValue.Location = New System.Drawing.Point(278, 102)
        Me.txtOpCVValue.Name = "txtOpCVValue"
        Me.txtOpCVValue.Size = New System.Drawing.Size(77, 22)
        Me.txtOpCVValue.TabIndex = 188
        Me.txtOpCVValue.Text = "0"
        '
        'Label317
        '
        Me.Label317.Location = New System.Drawing.Point(10, 28)
        Me.Label317.Name = "Label317"
        Me.Label317.Size = New System.Drawing.Size(182, 18)
        Me.Label317.TabIndex = 189
        Me.Label317.Text = "Common Variable Number"
        '
        'txtOpCVIndex
        '
        Me.txtOpCVIndex.Location = New System.Drawing.Point(192, 28)
        Me.txtOpCVIndex.Name = "txtOpCVIndex"
        Me.txtOpCVIndex.Size = New System.Drawing.Size(77, 22)
        Me.txtOpCVIndex.TabIndex = 186
        Me.txtOpCVIndex.Text = "1"
        '
        'Label318
        '
        Me.Label318.Location = New System.Drawing.Point(374, 157)
        Me.Label318.Name = "Label318"
        Me.Label318.Size = New System.Drawing.Size(58, 18)
        Me.Label318.TabIndex = 187
        Me.Label318.Text = "Between"
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
        Me.tab_program.Location = New System.Drawing.Point(4, 25)
        Me.tab_program.Name = "tab_program"
        Me.tab_program.Size = New System.Drawing.Size(1019, 498)
        Me.tab_program.TabIndex = 6
        Me.tab_program.Text = "Program"
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.txtSubProgramFileName)
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
        Me.GroupBox15.Location = New System.Drawing.Point(520, 312)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(404, 166)
        Me.GroupBox15.TabIndex = 110
        Me.GroupBox15.TabStop = false
        '
        'txtSubProgramFileName
        '
        Me.txtSubProgramFileName.Location = New System.Drawing.Point(278, 111)
        Me.txtSubProgramFileName.Name = "txtSubProgramFileName"
        Me.txtSubProgramFileName.Size = New System.Drawing.Size(116, 46)
        Me.txtSubProgramFileName.TabIndex = 107
        Me.txtSubProgramFileName.Text = "Return Search"
        '
        'cboSR_MIDBlockRestart
        '
        Me.cboSR_MIDBlockRestart.Location = New System.Drawing.Point(192, 72)
        Me.cboSR_MIDBlockRestart.Name = "cboSR_MIDBlockRestart"
        Me.cboSR_MIDBlockRestart.Size = New System.Drawing.Size(182, 24)
        Me.cboSR_MIDBlockRestart.TabIndex = 88
        '
        'cboSR_AxisMovementOrder
        '
        Me.cboSR_AxisMovementOrder.Location = New System.Drawing.Point(192, 46)
        Me.cboSR_AxisMovementOrder.Name = "cboSR_AxisMovementOrder"
        Me.cboSR_AxisMovementOrder.Size = New System.Drawing.Size(182, 24)
        Me.cboSR_AxisMovementOrder.TabIndex = 87
        '
        'txtSR_RepeatNumber
        '
        Me.txtSR_RepeatNumber.Location = New System.Drawing.Point(192, 129)
        Me.txtSR_RepeatNumber.Name = "txtSR_RepeatNumber"
        Me.txtSR_RepeatNumber.Size = New System.Drawing.Size(77, 22)
        Me.txtSR_RepeatNumber.TabIndex = 86
        Me.txtSR_RepeatNumber.Text = "1"
        '
        'Label175
        '
        Me.Label175.Location = New System.Drawing.Point(19, 129)
        Me.Label175.Name = "Label175"
        Me.Label175.Size = New System.Drawing.Size(163, 19)
        Me.Label175.TabIndex = 85
        Me.Label175.Text = "Repeat Number"
        '
        'txtSR_RelativeBlock
        '
        Me.txtSR_RelativeBlock.Location = New System.Drawing.Point(192, 102)
        Me.txtSR_RelativeBlock.Name = "txtSR_RelativeBlock"
        Me.txtSR_RelativeBlock.Size = New System.Drawing.Size(77, 22)
        Me.txtSR_RelativeBlock.TabIndex = 84
        Me.txtSR_RelativeBlock.Text = "0"
        '
        'Label171
        '
        Me.Label171.Location = New System.Drawing.Point(19, 102)
        Me.Label171.Name = "Label171"
        Me.Label171.Size = New System.Drawing.Size(163, 18)
        Me.Label171.TabIndex = 83
        Me.Label171.Text = "Relative Block"
        '
        'Label172
        '
        Me.Label172.Location = New System.Drawing.Point(19, 46)
        Me.Label172.Name = "Label172"
        Me.Label172.Size = New System.Drawing.Size(163, 19)
        Me.Label172.TabIndex = 82
        Me.Label172.Text = "Axis Movement Order"
        '
        'Label173
        '
        Me.Label173.Location = New System.Drawing.Point(19, 18)
        Me.Label173.Name = "Label173"
        Me.Label173.Size = New System.Drawing.Size(163, 19)
        Me.Label173.TabIndex = 80
        Me.Label173.Text = "Sequence/Block number"
        '
        'txtSR_SequenceBlockNumber
        '
        Me.txtSR_SequenceBlockNumber.Location = New System.Drawing.Point(192, 18)
        Me.txtSR_SequenceBlockNumber.Name = "txtSR_SequenceBlockNumber"
        Me.txtSR_SequenceBlockNumber.Size = New System.Drawing.Size(77, 22)
        Me.txtSR_SequenceBlockNumber.TabIndex = 77
        Me.txtSR_SequenceBlockNumber.Text = "10"
        '
        'Label174
        '
        Me.Label174.Location = New System.Drawing.Point(19, 74)
        Me.Label174.Name = "Label174"
        Me.Label174.Size = New System.Drawing.Size(163, 18)
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
        Me.GroupBox14.Location = New System.Drawing.Point(518, 120)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Size = New System.Drawing.Size(404, 192)
        Me.GroupBox14.TabIndex = 109
        Me.GroupBox14.TabStop = false
        '
        'cmdSelectScheduleProgram
        '
        Me.cmdSelectScheduleProgram.Location = New System.Drawing.Point(125, 138)
        Me.cmdSelectScheduleProgram.Name = "cmdSelectScheduleProgram"
        Me.cmdSelectScheduleProgram.Size = New System.Drawing.Size(134, 47)
        Me.cmdSelectScheduleProgram.TabIndex = 109
        Me.cmdSelectScheduleProgram.Text = "Select Schedule Program"
        '
        'cboFileReadModeEnum
        '
        Me.cboFileReadModeEnum.Location = New System.Drawing.Point(182, 102)
        Me.cboFileReadModeEnum.Name = "cboFileReadModeEnum"
        Me.cboFileReadModeEnum.Size = New System.Drawing.Size(212, 24)
        Me.cboFileReadModeEnum.TabIndex = 107
        Me.cboFileReadModeEnum.Text = "ComboBox1"
        '
        'progSelectProgramButton
        '
        Me.progSelectProgramButton.Location = New System.Drawing.Point(10, 138)
        Me.progSelectProgramButton.Name = "progSelectProgramButton"
        Me.progSelectProgramButton.Size = New System.Drawing.Size(105, 47)
        Me.progSelectProgramButton.TabIndex = 106
        Me.progSelectProgramButton.Text = "Select Main Program"
        '
        'Label146
        '
        Me.Label146.Location = New System.Drawing.Point(10, 102)
        Me.Label146.Name = "Label146"
        Me.Label146.Size = New System.Drawing.Size(163, 18)
        Me.Label146.TabIndex = 105
        Me.Label146.Text = "File Read Mode"
        '
        'prog3
        '
        Me.prog3.Location = New System.Drawing.Point(182, 74)
        Me.prog3.Name = "prog3"
        Me.prog3.Size = New System.Drawing.Size(212, 22)
        Me.prog3.TabIndex = 103
        '
        'Label147
        '
        Me.Label147.Location = New System.Drawing.Point(10, 74)
        Me.Label147.Name = "Label147"
        Me.Label147.Size = New System.Drawing.Size(163, 18)
        Me.Label147.TabIndex = 102
        Me.Label147.Text = "System Sub FileName"
        '
        'prog2
        '
        Me.prog2.Location = New System.Drawing.Point(182, 46)
        Me.prog2.Name = "prog2"
        Me.prog2.Size = New System.Drawing.Size(212, 22)
        Me.prog2.TabIndex = 100
        '
        'Label148
        '
        Me.Label148.Location = New System.Drawing.Point(10, 18)
        Me.Label148.Name = "Label148"
        Me.Label148.Size = New System.Drawing.Size(163, 19)
        Me.Label148.TabIndex = 101
        Me.Label148.Text = "Program FileName"
        '
        'prog1
        '
        Me.prog1.Location = New System.Drawing.Point(182, 18)
        Me.prog1.Name = "prog1"
        Me.prog1.Size = New System.Drawing.Size(212, 22)
        Me.prog1.TabIndex = 99
        Me.prog1.Text = "A.MIN"
        '
        'Label149
        '
        Me.Label149.Location = New System.Drawing.Point(10, 46)
        Me.Label149.Name = "Label149"
        Me.Label149.Size = New System.Drawing.Size(163, 19)
        Me.Label149.TabIndex = 98
        Me.Label149.Text = "SubProgram FileName"
        '
        'cmdCancelProgram
        '
        Me.cmdCancelProgram.Location = New System.Drawing.Point(269, 138)
        Me.cmdCancelProgram.Name = "cmdCancelProgram"
        Me.cmdCancelProgram.Size = New System.Drawing.Size(125, 47)
        Me.cmdCancelProgram.TabIndex = 108
        Me.cmdCancelProgram.Text = "Cancel Program"
        '
        'progButtonExecBlock
        '
        Me.progButtonExecBlock.Location = New System.Drawing.Point(336, 65)
        Me.progButtonExecBlock.Name = "progButtonExecBlock"
        Me.progButtonExecBlock.Size = New System.Drawing.Size(154, 27)
        Me.progButtonExecBlock.TabIndex = 77
        Me.progButtonExecBlock.Text = "Get Execute Block"
        '
        'progExecutePoint
        '
        Me.progExecutePoint.Location = New System.Drawing.Point(202, 212)
        Me.progExecutePoint.Name = "progExecutePoint"
        Me.progExecutePoint.ReadOnly = true
        Me.progExecutePoint.Size = New System.Drawing.Size(76, 22)
        Me.progExecutePoint.TabIndex = 76
        '
        'Label59
        '
        Me.Label59.Location = New System.Drawing.Point(29, 212)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(163, 19)
        Me.Label59.TabIndex = 75
        Me.Label59.Text = "Execute Point (Int)"
        '
        'progRead
        '
        Me.progRead.Location = New System.Drawing.Point(202, 185)
        Me.progRead.Name = "progRead"
        Me.progRead.ReadOnly = true
        Me.progRead.Size = New System.Drawing.Size(76, 22)
        Me.progRead.TabIndex = 73
        '
        'Label60
        '
        Me.Label60.Location = New System.Drawing.Point(29, 157)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(163, 18)
        Me.Label60.TabIndex = 74
        Me.Label60.Text = "Column (int)"
        '
        'progColumn
        '
        Me.progColumn.Location = New System.Drawing.Point(202, 157)
        Me.progColumn.Name = "progColumn"
        Me.progColumn.Size = New System.Drawing.Size(76, 22)
        Me.progColumn.TabIndex = 71
        Me.progColumn.Text = "79"
        '
        'Label61
        '
        Me.Label61.Location = New System.Drawing.Point(29, 129)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(163, 19)
        Me.Label61.TabIndex = 72
        Me.Label61.Text = "Row (int)"
        '
        'progRow
        '
        Me.progRow.Location = New System.Drawing.Point(202, 129)
        Me.progRow.Name = "progRow"
        Me.progRow.Size = New System.Drawing.Size(76, 22)
        Me.progRow.TabIndex = 69
        Me.progRow.Text = "10"
        '
        'Label62
        '
        Me.Label62.Location = New System.Drawing.Point(29, 185)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(163, 18)
        Me.Label62.TabIndex = 70
        Me.Label62.Text = "Read Point (int)"
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.SystemColors.Control
        Me.Label58.Location = New System.Drawing.Point(48, 65)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(115, 18)
        Me.Label58.TabIndex = 61
        Me.Label58.Text = "Executing Block :"
        '
        'progExecutingBlock
        '
        Me.progExecutingBlock.Location = New System.Drawing.Point(173, 65)
        Me.progExecutingBlock.Name = "progExecutingBlock"
        Me.progExecutingBlock.Size = New System.Drawing.Size(144, 22)
        Me.progExecutingBlock.TabIndex = 60
        '
        'label99
        '
        Me.label99.BackColor = System.Drawing.SystemColors.Control
        Me.label99.Location = New System.Drawing.Point(29, 28)
        Me.label99.Name = "label99"
        Me.label99.Size = New System.Drawing.Size(134, 18)
        Me.label99.TabIndex = 58
        Me.label99.Text = "Execute Block Type :"
        '
        'progExecCombo
        '
        Me.progExecCombo.Location = New System.Drawing.Point(173, 28)
        Me.progExecCombo.Name = "progExecCombo"
        Me.progExecCombo.Size = New System.Drawing.Size(201, 24)
        Me.progExecCombo.TabIndex = 57
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(509, 9)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(96, 37)
        Me.Label57.TabIndex = 16
        Me.Label57.Text = "Values with no parameters :"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'progUpdateButton
        '
        Me.progUpdateButton.Location = New System.Drawing.Point(509, 55)
        Me.progUpdateButton.Name = "progUpdateButton"
        Me.progUpdateButton.Size = New System.Drawing.Size(105, 28)
        Me.progUpdateButton.TabIndex = 15
        Me.progUpdateButton.Text = "Update"
        '
        'progNoParams
        '
        Me.progNoParams.Location = New System.Drawing.Point(624, 9)
        Me.progNoParams.Multiline = true
        Me.progNoParams.Name = "progNoParams"
        Me.progNoParams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.progNoParams.Size = New System.Drawing.Size(298, 102)
        Me.progNoParams.TabIndex = 14
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Location = New System.Drawing.Point(10, 9)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(489, 93)
        Me.Panel7.TabIndex = 78
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.progButtonGetRunProgram)
        Me.Panel8.Controls.Add(Me.progRunningPrograms)
        Me.Panel8.Location = New System.Drawing.Point(10, 111)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(489, 332)
        Me.Panel8.TabIndex = 79
        '
        'progButtonGetRunProgram
        '
        Me.progButtonGetRunProgram.Location = New System.Drawing.Point(326, 9)
        Me.progButtonGetRunProgram.Name = "progButtonGetRunProgram"
        Me.progButtonGetRunProgram.Size = New System.Drawing.Size(154, 28)
        Me.progButtonGetRunProgram.TabIndex = 78
        Me.progButtonGetRunProgram.Text = "Get Running Program"
        '
        'progRunningPrograms
        '
        Me.progRunningPrograms.Location = New System.Drawing.Point(10, 138)
        Me.progRunningPrograms.Multiline = true
        Me.progRunningPrograms.Name = "progRunningPrograms"
        Me.progRunningPrograms.Size = New System.Drawing.Size(470, 185)
        Me.progRunningPrograms.TabIndex = 80
        '
        'tab_Renishaw_1
        '
        Me.tab_Renishaw_1.Controls.Add(Me.btnGetActiveProgramFilePath)
        Me.tab_Renishaw_1.Controls.Add(Me.txtActiveProgramFilePath)
        Me.tab_Renishaw_1.Controls.Add(Me.btnCancelSubProgram)
        Me.tab_Renishaw_1.Controls.Add(Me.btnSelectSubProgram2)
        Me.tab_Renishaw_1.Controls.Add(Me.btnSelectSubProgram)
        Me.tab_Renishaw_1.Controls.Add(Me.txtSelectSubProgram)
        Me.tab_Renishaw_1.Controls.Add(Me.Label261)
        Me.tab_Renishaw_1.Controls.Add(Me.txtTouchProbeSignal)
        Me.tab_Renishaw_1.Controls.Add(Me.Label260)
        Me.tab_Renishaw_1.Controls.Add(Me.btnGetTouchProbeSignal)
        Me.tab_Renishaw_1.Controls.Add(Me.txtProbeSubProgramStatus)
        Me.tab_Renishaw_1.Controls.Add(Me.Label259)
        Me.tab_Renishaw_1.Controls.Add(Me.btnProbeSubProgramStatus)
        Me.tab_Renishaw_1.Controls.Add(Me.txtProbePositionC)
        Me.tab_Renishaw_1.Controls.Add(Me.txtProbePositionB)
        Me.tab_Renishaw_1.Controls.Add(Me.Label257)
        Me.tab_Renishaw_1.Controls.Add(Me.Label258)
        Me.tab_Renishaw_1.Controls.Add(Me.txtProbePositionA)
        Me.tab_Renishaw_1.Controls.Add(Me.txtProbePositionZ)
        Me.tab_Renishaw_1.Controls.Add(Me.Label255)
        Me.tab_Renishaw_1.Controls.Add(Me.Label256)
        Me.tab_Renishaw_1.Controls.Add(Me.txtProbePositionY)
        Me.tab_Renishaw_1.Controls.Add(Me.txtProbePositionX)
        Me.tab_Renishaw_1.Controls.Add(Me.Label253)
        Me.tab_Renishaw_1.Controls.Add(Me.Label254)
        Me.tab_Renishaw_1.Controls.Add(Me.btnProbeUpdate)
        Me.tab_Renishaw_1.Location = New System.Drawing.Point(4, 25)
        Me.tab_Renishaw_1.Name = "tab_Renishaw_1"
        Me.tab_Renishaw_1.Size = New System.Drawing.Size(1019, 498)
        Me.tab_Renishaw_1.TabIndex = 25
        Me.tab_Renishaw_1.Text = "Renishaw_1"
        '
        'btnGetActiveProgramFilePath
        '
        Me.btnGetActiveProgramFilePath.Location = New System.Drawing.Point(19, 332)
        Me.btnGetActiveProgramFilePath.Name = "btnGetActiveProgramFilePath"
        Me.btnGetActiveProgramFilePath.Size = New System.Drawing.Size(259, 37)
        Me.btnGetActiveProgramFilePath.TabIndex = 122
        Me.btnGetActiveProgramFilePath.Text = "Get Active Program File Path"
        '
        'txtActiveProgramFilePath
        '
        Me.txtActiveProgramFilePath.BackColor = System.Drawing.SystemColors.Control
        Me.txtActiveProgramFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActiveProgramFilePath.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtActiveProgramFilePath.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtActiveProgramFilePath.Location = New System.Drawing.Point(19, 378)
        Me.txtActiveProgramFilePath.Name = "txtActiveProgramFilePath"
        Me.txtActiveProgramFilePath.Size = New System.Drawing.Size(903, 36)
        Me.txtActiveProgramFilePath.TabIndex = 121
        '
        'btnCancelSubProgram
        '
        Me.btnCancelSubProgram.Location = New System.Drawing.Point(634, 138)
        Me.btnCancelSubProgram.Name = "btnCancelSubProgram"
        Me.btnCancelSubProgram.Size = New System.Drawing.Size(153, 28)
        Me.btnCancelSubProgram.TabIndex = 119
        Me.btnCancelSubProgram.Text = "Cancel Sub Program"
        '
        'btnSelectSubProgram2
        '
        Me.btnSelectSubProgram2.Location = New System.Drawing.Point(758, 18)
        Me.btnSelectSubProgram2.Name = "btnSelectSubProgram2"
        Me.btnSelectSubProgram2.Size = New System.Drawing.Size(154, 47)
        Me.btnSelectSubProgram2.TabIndex = 118
        Me.btnSelectSubProgram2.Text = "Select sub program with A Mode:"
        '
        'btnSelectSubProgram
        '
        Me.btnSelectSubProgram.Location = New System.Drawing.Point(634, 18)
        Me.btnSelectSubProgram.Name = "btnSelectSubProgram"
        Me.btnSelectSubProgram.Size = New System.Drawing.Size(115, 47)
        Me.btnSelectSubProgram.TabIndex = 117
        Me.btnSelectSubProgram.Text = "Select sub program:"
        '
        'txtSelectSubProgram
        '
        Me.txtSelectSubProgram.Location = New System.Drawing.Point(634, 102)
        Me.txtSelectSubProgram.Name = "txtSelectSubProgram"
        Me.txtSelectSubProgram.Size = New System.Drawing.Size(211, 22)
        Me.txtSelectSubProgram.TabIndex = 116
        Me.txtSelectSubProgram.Text = "OSPR1"
        '
        'Label261
        '
        Me.Label261.Location = New System.Drawing.Point(634, 74)
        Me.Label261.Name = "Label261"
        Me.Label261.Size = New System.Drawing.Size(192, 18)
        Me.Label261.TabIndex = 115
        Me.Label261.Text = "SubProgram FileName"
        '
        'txtTouchProbeSignal
        '
        Me.txtTouchProbeSignal.BackColor = System.Drawing.SystemColors.Control
        Me.txtTouchProbeSignal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTouchProbeSignal.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtTouchProbeSignal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtTouchProbeSignal.Location = New System.Drawing.Point(499, 157)
        Me.txtTouchProbeSignal.Name = "txtTouchProbeSignal"
        Me.txtTouchProbeSignal.Size = New System.Drawing.Size(106, 36)
        Me.txtTouchProbeSignal.TabIndex = 107
        '
        'Label260
        '
        Me.Label260.Location = New System.Drawing.Point(326, 166)
        Me.Label260.Name = "Label260"
        Me.Label260.Size = New System.Drawing.Size(154, 19)
        Me.Label260.TabIndex = 106
        Me.Label260.Text = "Touch Probe Signal: "
        '
        'btnGetTouchProbeSignal
        '
        Me.btnGetTouchProbeSignal.Location = New System.Drawing.Point(317, 120)
        Me.btnGetTouchProbeSignal.Name = "btnGetTouchProbeSignal"
        Me.btnGetTouchProbeSignal.Size = New System.Drawing.Size(288, 28)
        Me.btnGetTouchProbeSignal.TabIndex = 105
        Me.btnGetTouchProbeSignal.Text = "Get Touch Probe Signal"
        '
        'txtProbeSubProgramStatus
        '
        Me.txtProbeSubProgramStatus.BackColor = System.Drawing.SystemColors.Control
        Me.txtProbeSubProgramStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProbeSubProgramStatus.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtProbeSubProgramStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtProbeSubProgramStatus.Location = New System.Drawing.Point(490, 55)
        Me.txtProbeSubProgramStatus.Name = "txtProbeSubProgramStatus"
        Me.txtProbeSubProgramStatus.Size = New System.Drawing.Size(115, 36)
        Me.txtProbeSubProgramStatus.TabIndex = 104
        '
        'Label259
        '
        Me.Label259.Location = New System.Drawing.Point(317, 65)
        Me.Label259.Name = "Label259"
        Me.Label259.Size = New System.Drawing.Size(153, 18)
        Me.Label259.TabIndex = 103
        Me.Label259.Text = "Sub Program Status:"
        '
        'btnProbeSubProgramStatus
        '
        Me.btnProbeSubProgramStatus.Location = New System.Drawing.Point(317, 18)
        Me.btnProbeSubProgramStatus.Name = "btnProbeSubProgramStatus"
        Me.btnProbeSubProgramStatus.Size = New System.Drawing.Size(288, 28)
        Me.btnProbeSubProgramStatus.TabIndex = 102
        Me.btnProbeSubProgramStatus.Text = "Get Probe Sub Program Status"
        '
        'txtProbePositionC
        '
        Me.txtProbePositionC.BackColor = System.Drawing.SystemColors.Control
        Me.txtProbePositionC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProbePositionC.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtProbePositionC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtProbePositionC.Location = New System.Drawing.Point(192, 286)
        Me.txtProbePositionC.Name = "txtProbePositionC"
        Me.txtProbePositionC.Size = New System.Drawing.Size(86, 36)
        Me.txtProbePositionC.TabIndex = 101
        '
        'txtProbePositionB
        '
        Me.txtProbePositionB.BackColor = System.Drawing.SystemColors.Control
        Me.txtProbePositionB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProbePositionB.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtProbePositionB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtProbePositionB.Location = New System.Drawing.Point(192, 240)
        Me.txtProbePositionB.Name = "txtProbePositionB"
        Me.txtProbePositionB.Size = New System.Drawing.Size(86, 36)
        Me.txtProbePositionB.TabIndex = 100
        '
        'Label257
        '
        Me.Label257.Location = New System.Drawing.Point(19, 295)
        Me.Label257.Name = "Label257"
        Me.Label257.Size = New System.Drawing.Size(154, 19)
        Me.Label257.TabIndex = 99
        Me.Label257.Text = "Probe position C axis:"
        '
        'Label258
        '
        Me.Label258.Location = New System.Drawing.Point(19, 249)
        Me.Label258.Name = "Label258"
        Me.Label258.Size = New System.Drawing.Size(154, 19)
        Me.Label258.TabIndex = 98
        Me.Label258.Text = "Probe position B axis:"
        '
        'txtProbePositionA
        '
        Me.txtProbePositionA.BackColor = System.Drawing.SystemColors.Control
        Me.txtProbePositionA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProbePositionA.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtProbePositionA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtProbePositionA.Location = New System.Drawing.Point(192, 194)
        Me.txtProbePositionA.Name = "txtProbePositionA"
        Me.txtProbePositionA.Size = New System.Drawing.Size(86, 36)
        Me.txtProbePositionA.TabIndex = 97
        '
        'txtProbePositionZ
        '
        Me.txtProbePositionZ.BackColor = System.Drawing.SystemColors.Control
        Me.txtProbePositionZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProbePositionZ.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtProbePositionZ.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtProbePositionZ.Location = New System.Drawing.Point(192, 148)
        Me.txtProbePositionZ.Name = "txtProbePositionZ"
        Me.txtProbePositionZ.Size = New System.Drawing.Size(86, 36)
        Me.txtProbePositionZ.TabIndex = 96
        '
        'Label255
        '
        Me.Label255.Location = New System.Drawing.Point(19, 203)
        Me.Label255.Name = "Label255"
        Me.Label255.Size = New System.Drawing.Size(154, 19)
        Me.Label255.TabIndex = 95
        Me.Label255.Text = "Probe position A axis:"
        '
        'Label256
        '
        Me.Label256.Location = New System.Drawing.Point(19, 157)
        Me.Label256.Name = "Label256"
        Me.Label256.Size = New System.Drawing.Size(154, 18)
        Me.Label256.TabIndex = 94
        Me.Label256.Text = "Probe position Z axis:"
        '
        'txtProbePositionY
        '
        Me.txtProbePositionY.BackColor = System.Drawing.SystemColors.Control
        Me.txtProbePositionY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProbePositionY.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtProbePositionY.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtProbePositionY.Location = New System.Drawing.Point(192, 102)
        Me.txtProbePositionY.Name = "txtProbePositionY"
        Me.txtProbePositionY.Size = New System.Drawing.Size(86, 36)
        Me.txtProbePositionY.TabIndex = 93
        '
        'txtProbePositionX
        '
        Me.txtProbePositionX.BackColor = System.Drawing.SystemColors.Control
        Me.txtProbePositionX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProbePositionX.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtProbePositionX.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtProbePositionX.Location = New System.Drawing.Point(192, 55)
        Me.txtProbePositionX.Name = "txtProbePositionX"
        Me.txtProbePositionX.Size = New System.Drawing.Size(86, 36)
        Me.txtProbePositionX.TabIndex = 92
        '
        'Label253
        '
        Me.Label253.Location = New System.Drawing.Point(19, 111)
        Me.Label253.Name = "Label253"
        Me.Label253.Size = New System.Drawing.Size(154, 18)
        Me.Label253.TabIndex = 91
        Me.Label253.Text = "Probe position Y axis:"
        '
        'Label254
        '
        Me.Label254.Location = New System.Drawing.Point(19, 65)
        Me.Label254.Name = "Label254"
        Me.Label254.Size = New System.Drawing.Size(154, 18)
        Me.Label254.TabIndex = 90
        Me.Label254.Text = "Probe position X axis:"
        '
        'btnProbeUpdate
        '
        Me.btnProbeUpdate.Location = New System.Drawing.Point(10, 18)
        Me.btnProbeUpdate.Name = "btnProbeUpdate"
        Me.btnProbeUpdate.Size = New System.Drawing.Size(268, 28)
        Me.btnProbeUpdate.TabIndex = 17
        Me.btnProbeUpdate.Text = "Get Probe Positions"
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
        Me.tab_variables.Location = New System.Drawing.Point(4, 25)
        Me.tab_variables.Name = "tab_variables"
        Me.tab_variables.Size = New System.Drawing.Size(1019, 498)
        Me.tab_variables.TabIndex = 10
        Me.tab_variables.Text = "Variables"
        '
        'Label90
        '
        Me.Label90.Location = New System.Drawing.Point(19, 111)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(183, 18)
        Me.Label90.TabIndex = 185
        Me.Label90.Text = "Common Variable Value"
        '
        'varValue
        '
        Me.varValue.Location = New System.Drawing.Point(202, 111)
        Me.varValue.Name = "varValue"
        Me.varValue.Size = New System.Drawing.Size(76, 22)
        Me.varValue.TabIndex = 184
        Me.varValue.Text = "1"
        '
        'varUpdateButton
        '
        Me.varUpdateButton.Location = New System.Drawing.Point(288, 37)
        Me.varUpdateButton.Name = "varUpdateButton"
        Me.varUpdateButton.Size = New System.Drawing.Size(86, 28)
        Me.varUpdateButton.TabIndex = 183
        Me.varUpdateButton.Text = "Update"
        '
        'varGetAllButton
        '
        Me.varGetAllButton.Location = New System.Drawing.Point(566, 166)
        Me.varGetAllButton.Name = "varGetAllButton"
        Me.varGetAllButton.Size = New System.Drawing.Size(87, 28)
        Me.varGetAllButton.TabIndex = 182
        Me.varGetAllButton.Text = "Get All -->"
        '
        'Label89
        '
        Me.Label89.Location = New System.Drawing.Point(19, 74)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(187, 18)
        Me.Label89.TabIndex = 181
        Me.Label89.Text = "Number of Common Variables"
        '
        'varNumberOfVars
        '
        Me.varNumberOfVars.Location = New System.Drawing.Point(221, 74)
        Me.varNumberOfVars.Name = "varNumberOfVars"
        Me.varNumberOfVars.Size = New System.Drawing.Size(53, 22)
        Me.varNumberOfVars.TabIndex = 180
        Me.varNumberOfVars.Text = "0"
        '
        'varGetAllResults
        '
        Me.varGetAllResults.Location = New System.Drawing.Point(701, 18)
        Me.varGetAllResults.Multiline = true
        Me.varGetAllResults.Name = "varGetAllResults"
        Me.varGetAllResults.Size = New System.Drawing.Size(211, 397)
        Me.varGetAllResults.TabIndex = 179
        '
        'varAddValue
        '
        Me.varAddValue.Location = New System.Drawing.Point(432, 111)
        Me.varAddValue.Name = "varAddValue"
        Me.varAddValue.Size = New System.Drawing.Size(48, 27)
        Me.varAddValue.TabIndex = 178
        Me.varAddValue.Text = "Add"
        '
        'varSetValue
        '
        Me.varSetValue.Location = New System.Drawing.Point(374, 111)
        Me.varSetValue.Name = "varSetValue"
        Me.varSetValue.Size = New System.Drawing.Size(48, 27)
        Me.varSetValue.TabIndex = 177
        Me.varSetValue.Text = "Set"
        '
        'varEnd
        '
        Me.varEnd.Location = New System.Drawing.Point(461, 166)
        Me.varEnd.Name = "varEnd"
        Me.varEnd.Size = New System.Drawing.Size(77, 22)
        Me.varEnd.TabIndex = 76
        Me.varEnd.Text = "10"
        '
        'varBegin
        '
        Me.varBegin.Location = New System.Drawing.Point(288, 166)
        Me.varBegin.Name = "varBegin"
        Me.varBegin.Size = New System.Drawing.Size(77, 22)
        Me.varBegin.TabIndex = 73
        Me.varBegin.Text = "1"
        '
        'varValueUpdate
        '
        Me.varValueUpdate.ForeColor = System.Drawing.Color.Red
        Me.varValueUpdate.Location = New System.Drawing.Point(288, 111)
        Me.varValueUpdate.Name = "varValueUpdate"
        Me.varValueUpdate.Size = New System.Drawing.Size(77, 22)
        Me.varValueUpdate.TabIndex = 71
        Me.varValueUpdate.Text = "0"
        '
        'Label91
        '
        Me.Label91.Location = New System.Drawing.Point(19, 37)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(183, 18)
        Me.Label91.TabIndex = 72
        Me.Label91.Text = "Common Variable Number"
        '
        'varCommonVarNumber
        '
        Me.varCommonVarNumber.Location = New System.Drawing.Point(202, 37)
        Me.varCommonVarNumber.Name = "varCommonVarNumber"
        Me.varCommonVarNumber.Size = New System.Drawing.Size(76, 22)
        Me.varCommonVarNumber.TabIndex = 69
        Me.varCommonVarNumber.Text = "1"
        '
        'Label92
        '
        Me.Label92.Location = New System.Drawing.Point(384, 166)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(58, 19)
        Me.Label92.TabIndex = 70
        Me.Label92.Text = "Between"
        '
        'Tab_View
        '
        Me.Tab_View.Controls.Add(Me.Panel12)
        Me.Tab_View.Location = New System.Drawing.Point(4, 25)
        Me.Tab_View.Name = "Tab_View"
        Me.Tab_View.Size = New System.Drawing.Size(1019, 498)
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
        Me.Panel12.Location = New System.Drawing.Point(10, 9)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(518, 194)
        Me.Panel12.TabIndex = 270
        '
        'Label231
        '
        Me.Label231.Location = New System.Drawing.Point(19, 92)
        Me.Label231.Name = "Label231"
        Me.Label231.Size = New System.Drawing.Size(192, 19)
        Me.Label231.TabIndex = 274
        Me.Label231.Text = "PanelGroupEnum"
        '
        'Cmb_ChangeScreen
        '
        Me.Cmb_ChangeScreen.Location = New System.Drawing.Point(230, 92)
        Me.Cmb_ChangeScreen.Name = "Cmb_ChangeScreen"
        Me.Cmb_ChangeScreen.Size = New System.Drawing.Size(279, 24)
        Me.Cmb_ChangeScreen.TabIndex = 273
        '
        'cmd_ChangeScreen
        '
        Me.cmd_ChangeScreen.Location = New System.Drawing.Point(230, 28)
        Me.cmd_ChangeScreen.Name = "cmd_ChangeScreen"
        Me.cmd_ChangeScreen.Size = New System.Drawing.Size(125, 27)
        Me.cmd_ChangeScreen.TabIndex = 272
        Me.cmd_ChangeScreen.Text = "ChangeScreen"
        '
        'txt_screenname
        '
        Me.txt_screenname.Location = New System.Drawing.Point(230, 138)
        Me.txt_screenname.Name = "txt_screenname"
        Me.txt_screenname.Size = New System.Drawing.Size(279, 22)
        Me.txt_screenname.TabIndex = 271
        '
        'Label232
        '
        Me.Label232.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label232.Location = New System.Drawing.Point(19, 138)
        Me.Label232.Name = "Label232"
        Me.Label232.Size = New System.Drawing.Size(163, 19)
        Me.Label232.TabIndex = 270
        Me.Label232.Text = "Screen Name"
        '
        'tab_PLC
        '
        Me.tab_PLC.Controls.Add(Me.grpUserTaskIOVariable)
        Me.tab_PLC.Controls.Add(Me.grpIOVariables)
        Me.tab_PLC.Location = New System.Drawing.Point(4, 25)
        Me.tab_PLC.Name = "tab_PLC"
        Me.tab_PLC.Size = New System.Drawing.Size(1019, 498)
        Me.tab_PLC.TabIndex = 19
        Me.tab_PLC.Text = "I/O"
        '
        'grpUserTaskIOVariable
        '
        Me.grpUserTaskIOVariable.Controls.Add(Me.cboSetUserTaskOutputVariableProtected)
        Me.grpUserTaskIOVariable.Controls.Add(Me.cboSetUserTaskOutputVariable)
        Me.grpUserTaskIOVariable.Controls.Add(Me.btnSetProtectedUserTaskOutputVariable)
        Me.grpUserTaskIOVariable.Controls.Add(Me.txtSetProtectedUserTaskIOOutputVariableIndex)
        Me.grpUserTaskIOVariable.Controls.Add(Me.txtGetProtectedUserTaskIOOutputVariableValue)
        Me.grpUserTaskIOVariable.Controls.Add(Me.btnGetProtectedUserTaskOutputVariable)
        Me.grpUserTaskIOVariable.Controls.Add(Me.txtGetProtectedUserTaskIOOutputVariableIndex)
        Me.grpUserTaskIOVariable.Controls.Add(Me.Label338)
        Me.grpUserTaskIOVariable.Controls.Add(Me.btnSetUserTaskOutputVariable)
        Me.grpUserTaskIOVariable.Controls.Add(Me.txtSetUserTaskIOOutputVariableIndex)
        Me.grpUserTaskIOVariable.Controls.Add(Me.txtUserTaskIOOutputVariableValue)
        Me.grpUserTaskIOVariable.Controls.Add(Me.btnGetUserTaskOutputIOVariable)
        Me.grpUserTaskIOVariable.Controls.Add(Me.txtUserTaskIOOutputVariableIndex)
        Me.grpUserTaskIOVariable.Controls.Add(Me.txtUserTaskIOInputVariableValue)
        Me.grpUserTaskIOVariable.Controls.Add(Me.btnGetUserTaskInputIOVariable)
        Me.grpUserTaskIOVariable.Controls.Add(Me.txtUserTaskIOInputVariableIndex)
        Me.grpUserTaskIOVariable.Controls.Add(Me.Label337)
        Me.grpUserTaskIOVariable.Location = New System.Drawing.Point(10, 240)
        Me.grpUserTaskIOVariable.Name = "grpUserTaskIOVariable"
        Me.grpUserTaskIOVariable.Size = New System.Drawing.Size(544, 240)
        Me.grpUserTaskIOVariable.TabIndex = 237
        Me.grpUserTaskIOVariable.TabStop = false
        Me.grpUserTaskIOVariable.Text = "User Task I/O Variables"
        '
        'cboSetUserTaskOutputVariableProtected
        '
        Me.cboSetUserTaskOutputVariableProtected.Location = New System.Drawing.Point(442, 203)
        Me.cboSetUserTaskOutputVariableProtected.Name = "cboSetUserTaskOutputVariableProtected"
        Me.cboSetUserTaskOutputVariableProtected.Size = New System.Drawing.Size(87, 24)
        Me.cboSetUserTaskOutputVariableProtected.TabIndex = 216
        Me.cboSetUserTaskOutputVariableProtected.Text = "ComboBox2"
        '
        'cboSetUserTaskOutputVariable
        '
        Me.cboSetUserTaskOutputVariable.Location = New System.Drawing.Point(442, 129)
        Me.cboSetUserTaskOutputVariable.Name = "cboSetUserTaskOutputVariable"
        Me.cboSetUserTaskOutputVariable.Size = New System.Drawing.Size(87, 24)
        Me.cboSetUserTaskOutputVariable.TabIndex = 215
        Me.cboSetUserTaskOutputVariable.Text = "ComboBox2"
        '
        'btnSetProtectedUserTaskOutputVariable
        '
        Me.btnSetProtectedUserTaskOutputVariable.Location = New System.Drawing.Point(10, 203)
        Me.btnSetProtectedUserTaskOutputVariable.Name = "btnSetProtectedUserTaskOutputVariable"
        Me.btnSetProtectedUserTaskOutputVariable.Size = New System.Drawing.Size(345, 28)
        Me.btnSetProtectedUserTaskOutputVariable.TabIndex = 214
        Me.btnSetProtectedUserTaskOutputVariable.Text = "Set Protected User Task Output Variable"
        '
        'txtSetProtectedUserTaskIOOutputVariableIndex
        '
        Me.txtSetProtectedUserTaskIOOutputVariableIndex.Location = New System.Drawing.Point(365, 203)
        Me.txtSetProtectedUserTaskIOOutputVariableIndex.Name = "txtSetProtectedUserTaskIOOutputVariableIndex"
        Me.txtSetProtectedUserTaskIOOutputVariableIndex.Size = New System.Drawing.Size(67, 22)
        Me.txtSetProtectedUserTaskIOOutputVariableIndex.TabIndex = 213
        Me.txtSetProtectedUserTaskIOOutputVariableIndex.Text = "1"
        '
        'txtGetProtectedUserTaskIOOutputVariableValue
        '
        Me.txtGetProtectedUserTaskIOOutputVariableValue.Location = New System.Drawing.Point(442, 166)
        Me.txtGetProtectedUserTaskIOOutputVariableValue.Name = "txtGetProtectedUserTaskIOOutputVariableValue"
        Me.txtGetProtectedUserTaskIOOutputVariableValue.ReadOnly = true
        Me.txtGetProtectedUserTaskIOOutputVariableValue.Size = New System.Drawing.Size(87, 22)
        Me.txtGetProtectedUserTaskIOOutputVariableValue.TabIndex = 212
        Me.txtGetProtectedUserTaskIOOutputVariableValue.Text = "0"
        '
        'btnGetProtectedUserTaskOutputVariable
        '
        Me.btnGetProtectedUserTaskOutputVariable.Location = New System.Drawing.Point(10, 166)
        Me.btnGetProtectedUserTaskOutputVariable.Name = "btnGetProtectedUserTaskOutputVariable"
        Me.btnGetProtectedUserTaskOutputVariable.Size = New System.Drawing.Size(345, 28)
        Me.btnGetProtectedUserTaskOutputVariable.TabIndex = 211
        Me.btnGetProtectedUserTaskOutputVariable.Text = "Get Protected User Task Output Variable"
        '
        'txtGetProtectedUserTaskIOOutputVariableIndex
        '
        Me.txtGetProtectedUserTaskIOOutputVariableIndex.Location = New System.Drawing.Point(365, 166)
        Me.txtGetProtectedUserTaskIOOutputVariableIndex.Name = "txtGetProtectedUserTaskIOOutputVariableIndex"
        Me.txtGetProtectedUserTaskIOOutputVariableIndex.Size = New System.Drawing.Size(67, 22)
        Me.txtGetProtectedUserTaskIOOutputVariableIndex.TabIndex = 210
        Me.txtGetProtectedUserTaskIOOutputVariableIndex.Text = "1"
        '
        'Label338
        '
        Me.Label338.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label338.Location = New System.Drawing.Point(451, 18)
        Me.Label338.Name = "Label338"
        Me.Label338.Size = New System.Drawing.Size(58, 28)
        Me.Label338.TabIndex = 209
        Me.Label338.Text = "Value"
        '
        'btnSetUserTaskOutputVariable
        '
        Me.btnSetUserTaskOutputVariable.Location = New System.Drawing.Point(10, 129)
        Me.btnSetUserTaskOutputVariable.Name = "btnSetUserTaskOutputVariable"
        Me.btnSetUserTaskOutputVariable.Size = New System.Drawing.Size(268, 28)
        Me.btnSetUserTaskOutputVariable.TabIndex = 207
        Me.btnSetUserTaskOutputVariable.Text = "Set User Task Output Variable"
        '
        'txtSetUserTaskIOOutputVariableIndex
        '
        Me.txtSetUserTaskIOOutputVariableIndex.Location = New System.Drawing.Point(365, 129)
        Me.txtSetUserTaskIOOutputVariableIndex.Name = "txtSetUserTaskIOOutputVariableIndex"
        Me.txtSetUserTaskIOOutputVariableIndex.Size = New System.Drawing.Size(67, 22)
        Me.txtSetUserTaskIOOutputVariableIndex.TabIndex = 206
        Me.txtSetUserTaskIOOutputVariableIndex.Text = "1"
        '
        'txtUserTaskIOOutputVariableValue
        '
        Me.txtUserTaskIOOutputVariableValue.Location = New System.Drawing.Point(442, 92)
        Me.txtUserTaskIOOutputVariableValue.Name = "txtUserTaskIOOutputVariableValue"
        Me.txtUserTaskIOOutputVariableValue.ReadOnly = true
        Me.txtUserTaskIOOutputVariableValue.Size = New System.Drawing.Size(87, 22)
        Me.txtUserTaskIOOutputVariableValue.TabIndex = 205
        Me.txtUserTaskIOOutputVariableValue.Text = "0"
        '
        'btnGetUserTaskOutputIOVariable
        '
        Me.btnGetUserTaskOutputIOVariable.Location = New System.Drawing.Point(10, 92)
        Me.btnGetUserTaskOutputIOVariable.Name = "btnGetUserTaskOutputIOVariable"
        Me.btnGetUserTaskOutputIOVariable.Size = New System.Drawing.Size(268, 28)
        Me.btnGetUserTaskOutputIOVariable.TabIndex = 204
        Me.btnGetUserTaskOutputIOVariable.Text = "Get User Task Output Variable"
        '
        'txtUserTaskIOOutputVariableIndex
        '
        Me.txtUserTaskIOOutputVariableIndex.Location = New System.Drawing.Point(365, 92)
        Me.txtUserTaskIOOutputVariableIndex.Name = "txtUserTaskIOOutputVariableIndex"
        Me.txtUserTaskIOOutputVariableIndex.Size = New System.Drawing.Size(67, 22)
        Me.txtUserTaskIOOutputVariableIndex.TabIndex = 203
        Me.txtUserTaskIOOutputVariableIndex.Text = "1"
        '
        'txtUserTaskIOInputVariableValue
        '
        Me.txtUserTaskIOInputVariableValue.Location = New System.Drawing.Point(442, 55)
        Me.txtUserTaskIOInputVariableValue.Name = "txtUserTaskIOInputVariableValue"
        Me.txtUserTaskIOInputVariableValue.ReadOnly = true
        Me.txtUserTaskIOInputVariableValue.Size = New System.Drawing.Size(87, 22)
        Me.txtUserTaskIOInputVariableValue.TabIndex = 202
        Me.txtUserTaskIOInputVariableValue.Text = "0"
        '
        'btnGetUserTaskInputIOVariable
        '
        Me.btnGetUserTaskInputIOVariable.Location = New System.Drawing.Point(10, 55)
        Me.btnGetUserTaskInputIOVariable.Name = "btnGetUserTaskInputIOVariable"
        Me.btnGetUserTaskInputIOVariable.Size = New System.Drawing.Size(268, 28)
        Me.btnGetUserTaskInputIOVariable.TabIndex = 201
        Me.btnGetUserTaskInputIOVariable.Text = "Get User Task Input Variable"
        '
        'txtUserTaskIOInputVariableIndex
        '
        Me.txtUserTaskIOInputVariableIndex.Location = New System.Drawing.Point(365, 55)
        Me.txtUserTaskIOInputVariableIndex.Name = "txtUserTaskIOInputVariableIndex"
        Me.txtUserTaskIOInputVariableIndex.Size = New System.Drawing.Size(67, 22)
        Me.txtUserTaskIOInputVariableIndex.TabIndex = 198
        Me.txtUserTaskIOInputVariableIndex.Text = "1"
        '
        'Label337
        '
        Me.Label337.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label337.Location = New System.Drawing.Point(326, 18)
        Me.Label337.Name = "Label337"
        Me.Label337.Size = New System.Drawing.Size(106, 28)
        Me.Label337.TabIndex = 197
        Me.Label337.Text = "Variable Index"
        '
        'grpIOVariables
        '
        Me.grpIOVariables.Controls.Add(Me.txtIOLabel)
        Me.grpIOVariables.Controls.Add(Me.btnGetIOLabel)
        Me.grpIOVariables.Controls.Add(Me.txtIOLongWordLabel)
        Me.grpIOVariables.Controls.Add(Me.txtIOWordLabel)
        Me.grpIOVariables.Controls.Add(Me.txtIOBitLabel)
        Me.grpIOVariables.Controls.Add(Me.cmdIOGetBitByLabel)
        Me.grpIOVariables.Controls.Add(Me.cmdIOGetWordByLabel)
        Me.grpIOVariables.Controls.Add(Me.cmdIOGetLongWordByLabel)
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
        Me.grpIOVariables.Location = New System.Drawing.Point(10, 9)
        Me.grpIOVariables.Name = "grpIOVariables"
        Me.grpIOVariables.Size = New System.Drawing.Size(912, 222)
        Me.grpIOVariables.TabIndex = 235
        Me.grpIOVariables.TabStop = false
        Me.grpIOVariables.Text = "I/O Variables"
        '
        'txtIOLabel
        '
        Me.txtIOLabel.Location = New System.Drawing.Point(653, 18)
        Me.txtIOLabel.Name = "txtIOLabel"
        Me.txtIOLabel.Size = New System.Drawing.Size(115, 22)
        Me.txtIOLabel.TabIndex = 206
        '
        'btnGetIOLabel
        '
        Me.btnGetIOLabel.Location = New System.Drawing.Point(490, 18)
        Me.btnGetIOLabel.Name = "btnGetIOLabel"
        Me.btnGetIOLabel.Size = New System.Drawing.Size(144, 28)
        Me.btnGetIOLabel.TabIndex = 205
        Me.btnGetIOLabel.Text = "Get I/O Value label"
        '
        'txtIOLongWordLabel
        '
        Me.txtIOLongWordLabel.Location = New System.Drawing.Point(653, 185)
        Me.txtIOLongWordLabel.Name = "txtIOLongWordLabel"
        Me.txtIOLongWordLabel.ReadOnly = true
        Me.txtIOLongWordLabel.Size = New System.Drawing.Size(115, 22)
        Me.txtIOLongWordLabel.TabIndex = 204
        '
        'txtIOWordLabel
        '
        Me.txtIOWordLabel.Location = New System.Drawing.Point(653, 138)
        Me.txtIOWordLabel.Name = "txtIOWordLabel"
        Me.txtIOWordLabel.ReadOnly = true
        Me.txtIOWordLabel.Size = New System.Drawing.Size(115, 22)
        Me.txtIOWordLabel.TabIndex = 203
        '
        'txtIOBitLabel
        '
        Me.txtIOBitLabel.Location = New System.Drawing.Point(653, 92)
        Me.txtIOBitLabel.Name = "txtIOBitLabel"
        Me.txtIOBitLabel.ReadOnly = true
        Me.txtIOBitLabel.Size = New System.Drawing.Size(115, 22)
        Me.txtIOBitLabel.TabIndex = 202
        '
        'cmdIOGetBitByLabel
        '
        Me.cmdIOGetBitByLabel.Location = New System.Drawing.Point(547, 92)
        Me.cmdIOGetBitByLabel.Name = "cmdIOGetBitByLabel"
        Me.cmdIOGetBitByLabel.Size = New System.Drawing.Size(87, 28)
        Me.cmdIOGetBitByLabel.TabIndex = 201
        Me.cmdIOGetBitByLabel.Text = "Get label"
        '
        'cmdIOGetWordByLabel
        '
        Me.cmdIOGetWordByLabel.Location = New System.Drawing.Point(547, 138)
        Me.cmdIOGetWordByLabel.Name = "cmdIOGetWordByLabel"
        Me.cmdIOGetWordByLabel.Size = New System.Drawing.Size(87, 28)
        Me.cmdIOGetWordByLabel.TabIndex = 200
        Me.cmdIOGetWordByLabel.Text = "Get label"
        '
        'cmdIOGetLongWordByLabel
        '
        Me.cmdIOGetLongWordByLabel.Location = New System.Drawing.Point(547, 185)
        Me.cmdIOGetLongWordByLabel.Name = "cmdIOGetLongWordByLabel"
        Me.cmdIOGetLongWordByLabel.Size = New System.Drawing.Size(87, 27)
        Me.cmdIOGetLongWordByLabel.TabIndex = 199
        Me.cmdIOGetLongWordByLabel.Text = "Get label"
        '
        'Label297
        '
        Me.Label297.Location = New System.Drawing.Point(10, 18)
        Me.Label297.Name = "Label297"
        Me.Label297.Size = New System.Drawing.Size(144, 28)
        Me.Label297.TabIndex = 198
        Me.Label297.Text = "I/O Type:"
        '
        'cboIOVariableTypes
        '
        Me.cboIOVariableTypes.Location = New System.Drawing.Point(163, 18)
        Me.cboIOVariableTypes.Name = "cboIOVariableTypes"
        Me.cboIOVariableTypes.Size = New System.Drawing.Size(211, 24)
        Me.cboIOVariableTypes.TabIndex = 197
        '
        'cmdIOGetBit
        '
        Me.cmdIOGetBit.Location = New System.Drawing.Point(432, 92)
        Me.cmdIOGetBit.Name = "cmdIOGetBit"
        Me.cmdIOGetBit.Size = New System.Drawing.Size(48, 28)
        Me.cmdIOGetBit.TabIndex = 196
        Me.cmdIOGetBit.Text = "Get"
        '
        'cmdIOGetWord
        '
        Me.cmdIOGetWord.Location = New System.Drawing.Point(432, 138)
        Me.cmdIOGetWord.Name = "cmdIOGetWord"
        Me.cmdIOGetWord.Size = New System.Drawing.Size(48, 28)
        Me.cmdIOGetWord.TabIndex = 193
        Me.cmdIOGetWord.Text = "Get"
        '
        'cmdIOGetLongWord
        '
        Me.cmdIOGetLongWord.Location = New System.Drawing.Point(432, 185)
        Me.cmdIOGetLongWord.Name = "cmdIOGetLongWord"
        Me.cmdIOGetLongWord.Size = New System.Drawing.Size(48, 27)
        Me.cmdIOGetLongWord.TabIndex = 190
        Me.cmdIOGetLongWord.Text = "Get"
        '
        'txtIOLongWord
        '
        Me.txtIOLongWord.Location = New System.Drawing.Point(278, 185)
        Me.txtIOLongWord.Name = "txtIOLongWord"
        Me.txtIOLongWord.ReadOnly = true
        Me.txtIOLongWord.Size = New System.Drawing.Size(144, 22)
        Me.txtIOLongWord.TabIndex = 11
        Me.txtIOLongWord.Text = "0"
        '
        'txtIOWord
        '
        Me.txtIOWord.Location = New System.Drawing.Point(278, 138)
        Me.txtIOWord.Name = "txtIOWord"
        Me.txtIOWord.ReadOnly = true
        Me.txtIOWord.Size = New System.Drawing.Size(77, 22)
        Me.txtIOWord.TabIndex = 10
        Me.txtIOWord.Text = "0"
        '
        'txtIOBit
        '
        Me.txtIOBit.Location = New System.Drawing.Point(278, 92)
        Me.txtIOBit.Name = "txtIOBit"
        Me.txtIOBit.ReadOnly = true
        Me.txtIOBit.Size = New System.Drawing.Size(29, 22)
        Me.txtIOBit.TabIndex = 9
        Me.txtIOBit.Text = "0"
        '
        'Label296
        '
        Me.Label296.Location = New System.Drawing.Point(202, 55)
        Me.Label296.Name = "Label296"
        Me.Label296.Size = New System.Drawing.Size(57, 27)
        Me.Label296.TabIndex = 8
        Me.Label296.Text = "Bit No."
        '
        'txtIOBitNo
        '
        Me.txtIOBitNo.Location = New System.Drawing.Point(202, 92)
        Me.txtIOBitNo.Name = "txtIOBitNo"
        Me.txtIOBitNo.Size = New System.Drawing.Size(57, 22)
        Me.txtIOBitNo.TabIndex = 7
        Me.txtIOBitNo.Text = "0"
        '
        'Label295
        '
        Me.Label295.Location = New System.Drawing.Point(125, 55)
        Me.Label295.Name = "Label295"
        Me.Label295.Size = New System.Drawing.Size(57, 27)
        Me.Label295.TabIndex = 6
        Me.Label295.Text = "Index"
        '
        'txtIOLongWordIndex
        '
        Me.txtIOLongWordIndex.Location = New System.Drawing.Point(125, 185)
        Me.txtIOLongWordIndex.Name = "txtIOLongWordIndex"
        Me.txtIOLongWordIndex.Size = New System.Drawing.Size(57, 22)
        Me.txtIOLongWordIndex.TabIndex = 5
        Me.txtIOLongWordIndex.Text = "1"
        '
        'Label294
        '
        Me.Label294.Location = New System.Drawing.Point(10, 185)
        Me.Label294.Name = "Label294"
        Me.Label294.Size = New System.Drawing.Size(105, 27)
        Me.Label294.TabIndex = 4
        Me.Label294.Text = "Long Word I/O"
        '
        'txtIOWordIndex
        '
        Me.txtIOWordIndex.Location = New System.Drawing.Point(125, 138)
        Me.txtIOWordIndex.Name = "txtIOWordIndex"
        Me.txtIOWordIndex.Size = New System.Drawing.Size(57, 22)
        Me.txtIOWordIndex.TabIndex = 3
        Me.txtIOWordIndex.Text = "1"
        '
        'Label293
        '
        Me.Label293.Location = New System.Drawing.Point(10, 138)
        Me.Label293.Name = "Label293"
        Me.Label293.Size = New System.Drawing.Size(76, 28)
        Me.Label293.TabIndex = 2
        Me.Label293.Text = "Word I/O"
        '
        'txtIOBitIndex
        '
        Me.txtIOBitIndex.Location = New System.Drawing.Point(125, 92)
        Me.txtIOBitIndex.Name = "txtIOBitIndex"
        Me.txtIOBitIndex.Size = New System.Drawing.Size(57, 22)
        Me.txtIOBitIndex.TabIndex = 1
        Me.txtIOBitIndex.Text = "1"
        '
        'Label292
        '
        Me.Label292.Location = New System.Drawing.Point(10, 92)
        Me.Label292.Name = "Label292"
        Me.Label292.Size = New System.Drawing.Size(76, 28)
        Me.Label292.TabIndex = 0
        Me.Label292.Text = "Bit I/O"
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
        Me.tab_ballscrew.Location = New System.Drawing.Point(4, 25)
        Me.tab_ballscrew.Name = "tab_ballscrew"
        Me.tab_ballscrew.Size = New System.Drawing.Size(1019, 498)
        Me.tab_ballscrew.TabIndex = 2
        Me.tab_ballscrew.Text = "Ballscrew"
        '
        'ballscrewDataUnitCombo
        '
        Me.ballscrewDataUnitCombo.Location = New System.Drawing.Point(451, 305)
        Me.ballscrewDataUnitCombo.Name = "ballscrewDataUnitCombo"
        Me.ballscrewDataUnitCombo.Size = New System.Drawing.Size(145, 24)
        Me.ballscrewDataUnitCombo.TabIndex = 78
        '
        'bsDataUnitSet
        '
        Me.bsDataUnitSet.Location = New System.Drawing.Point(614, 305)
        Me.bsDataUnitSet.Name = "bsDataUnitSet"
        Me.bsDataUnitSet.Size = New System.Drawing.Size(87, 27)
        Me.bsDataUnitSet.TabIndex = 77
        Me.bsDataUnitSet.Text = "Set"
        '
        'Label150
        '
        Me.Label150.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label150.Location = New System.Drawing.Point(365, 305)
        Me.Label150.Name = "Label150"
        Me.Label150.Size = New System.Drawing.Size(96, 18)
        Me.Label150.TabIndex = 75
        Me.Label150.Text = "Data Unit"
        '
        'Label115
        '
        Me.Label115.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label115.Location = New System.Drawing.Point(365, 111)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(96, 18)
        Me.Label115.TabIndex = 74
        Me.Label115.Text = "PEC Point:"
        '
        'bsPecPoint
        '
        Me.bsPecPoint.Location = New System.Drawing.Point(470, 111)
        Me.bsPecPoint.Name = "bsPecPoint"
        Me.bsPecPoint.Size = New System.Drawing.Size(125, 22)
        Me.bsPecPoint.TabIndex = 73
        Me.bsPecPoint.Text = "1"
        '
        'bsStartPositionAdd
        '
        Me.bsStartPositionAdd.Location = New System.Drawing.Point(720, 258)
        Me.bsStartPositionAdd.Name = "bsStartPositionAdd"
        Me.bsStartPositionAdd.Size = New System.Drawing.Size(77, 28)
        Me.bsStartPositionAdd.TabIndex = 72
        Me.bsStartPositionAdd.Text = "Add"
        '
        'bsStartPositionSet
        '
        Me.bsStartPositionSet.Location = New System.Drawing.Point(614, 258)
        Me.bsStartPositionSet.Name = "bsStartPositionSet"
        Me.bsStartPositionSet.Size = New System.Drawing.Size(87, 28)
        Me.bsStartPositionSet.TabIndex = 71
        Me.bsStartPositionSet.Text = "Set"
        '
        'bsMaxPitchPointsAdd
        '
        Me.bsMaxPitchPointsAdd.Location = New System.Drawing.Point(720, 222)
        Me.bsMaxPitchPointsAdd.Name = "bsMaxPitchPointsAdd"
        Me.bsMaxPitchPointsAdd.Size = New System.Drawing.Size(77, 27)
        Me.bsMaxPitchPointsAdd.TabIndex = 70
        Me.bsMaxPitchPointsAdd.Text = "Add"
        '
        'bsMaxPicthPointsSet
        '
        Me.bsMaxPicthPointsSet.Location = New System.Drawing.Point(614, 222)
        Me.bsMaxPicthPointsSet.Name = "bsMaxPicthPointsSet"
        Me.bsMaxPicthPointsSet.Size = New System.Drawing.Size(87, 27)
        Me.bsMaxPicthPointsSet.TabIndex = 69
        Me.bsMaxPicthPointsSet.Text = "Set"
        '
        'bsIntervalAdd
        '
        Me.bsIntervalAdd.Location = New System.Drawing.Point(720, 185)
        Me.bsIntervalAdd.Name = "bsIntervalAdd"
        Me.bsIntervalAdd.Size = New System.Drawing.Size(77, 27)
        Me.bsIntervalAdd.TabIndex = 68
        Me.bsIntervalAdd.Text = "Add"
        '
        'bsIntervalSet
        '
        Me.bsIntervalSet.Location = New System.Drawing.Point(614, 185)
        Me.bsIntervalSet.Name = "bsIntervalSet"
        Me.bsIntervalSet.Size = New System.Drawing.Size(87, 27)
        Me.bsIntervalSet.TabIndex = 67
        Me.bsIntervalSet.Text = "Set"
        '
        'bsDataPointAdd
        '
        Me.bsDataPointAdd.Location = New System.Drawing.Point(720, 148)
        Me.bsDataPointAdd.Name = "bsDataPointAdd"
        Me.bsDataPointAdd.Size = New System.Drawing.Size(77, 27)
        Me.bsDataPointAdd.TabIndex = 66
        Me.bsDataPointAdd.Text = "Add"
        '
        'bsDataPointSet
        '
        Me.bsDataPointSet.Location = New System.Drawing.Point(614, 148)
        Me.bsDataPointSet.Name = "bsDataPointSet"
        Me.bsDataPointSet.Size = New System.Drawing.Size(87, 27)
        Me.bsDataPointSet.TabIndex = 65
        Me.bsDataPointSet.Text = "Set"
        '
        'bsStartPositionUpdate
        '
        Me.bsStartPositionUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.bsStartPositionUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.bsStartPositionUpdate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.bsStartPositionUpdate.ForeColor = System.Drawing.Color.Red
        Me.bsStartPositionUpdate.Location = New System.Drawing.Point(480, 258)
        Me.bsStartPositionUpdate.Name = "bsStartPositionUpdate"
        Me.bsStartPositionUpdate.Size = New System.Drawing.Size(125, 29)
        Me.bsStartPositionUpdate.TabIndex = 64
        Me.bsStartPositionUpdate.Text = "0.00"
        '
        'bsMaxPitchPointsUpdate
        '
        Me.bsMaxPitchPointsUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.bsMaxPitchPointsUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.bsMaxPitchPointsUpdate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.bsMaxPitchPointsUpdate.ForeColor = System.Drawing.Color.Red
        Me.bsMaxPitchPointsUpdate.Location = New System.Drawing.Point(480, 222)
        Me.bsMaxPitchPointsUpdate.Name = "bsMaxPitchPointsUpdate"
        Me.bsMaxPitchPointsUpdate.Size = New System.Drawing.Size(125, 29)
        Me.bsMaxPitchPointsUpdate.TabIndex = 63
        Me.bsMaxPitchPointsUpdate.Text = "0"
        '
        'bsIntervalUpdate
        '
        Me.bsIntervalUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.bsIntervalUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.bsIntervalUpdate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.bsIntervalUpdate.ForeColor = System.Drawing.Color.Red
        Me.bsIntervalUpdate.Location = New System.Drawing.Point(480, 185)
        Me.bsIntervalUpdate.Name = "bsIntervalUpdate"
        Me.bsIntervalUpdate.Size = New System.Drawing.Size(125, 29)
        Me.bsIntervalUpdate.TabIndex = 62
        Me.bsIntervalUpdate.Text = "0.00"
        '
        'bsDataPointUpdate
        '
        Me.bsDataPointUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.bsDataPointUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.bsDataPointUpdate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.bsDataPointUpdate.ForeColor = System.Drawing.Color.Red
        Me.bsDataPointUpdate.Location = New System.Drawing.Point(480, 148)
        Me.bsDataPointUpdate.Name = "bsDataPointUpdate"
        Me.bsDataPointUpdate.Size = New System.Drawing.Size(125, 29)
        Me.bsDataPointUpdate.TabIndex = 61
        Me.bsDataPointUpdate.Text = "0"
        '
        'bsStartPosition
        '
        Me.bsStartPosition.BackColor = System.Drawing.SystemColors.Control
        Me.bsStartPosition.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.bsStartPosition.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.bsStartPosition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.bsStartPosition.Location = New System.Drawing.Point(269, 258)
        Me.bsStartPosition.Name = "bsStartPosition"
        Me.bsStartPosition.Size = New System.Drawing.Size(192, 29)
        Me.bsStartPosition.TabIndex = 60
        Me.bsStartPosition.Text = "0.00"
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label31.Location = New System.Drawing.Point(58, 258)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(192, 19)
        Me.Label31.TabIndex = 59
        Me.Label31.Text = "Start Position :"
        '
        'bsMaxPitchPoints
        '
        Me.bsMaxPitchPoints.BackColor = System.Drawing.SystemColors.Control
        Me.bsMaxPitchPoints.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.bsMaxPitchPoints.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.bsMaxPitchPoints.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.bsMaxPitchPoints.Location = New System.Drawing.Point(269, 222)
        Me.bsMaxPitchPoints.Name = "bsMaxPitchPoints"
        Me.bsMaxPitchPoints.Size = New System.Drawing.Size(192, 29)
        Me.bsMaxPitchPoints.TabIndex = 58
        Me.bsMaxPitchPoints.Text = "0"
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label30.Location = New System.Drawing.Point(58, 222)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(192, 18)
        Me.Label30.TabIndex = 57
        Me.Label30.Text = "Max Pitch Points :"
        '
        'bsInterval
        '
        Me.bsInterval.BackColor = System.Drawing.SystemColors.Control
        Me.bsInterval.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.bsInterval.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.bsInterval.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.bsInterval.Location = New System.Drawing.Point(269, 185)
        Me.bsInterval.Name = "bsInterval"
        Me.bsInterval.Size = New System.Drawing.Size(192, 29)
        Me.bsInterval.TabIndex = 56
        Me.bsInterval.Text = "0.00"
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label29.Location = New System.Drawing.Point(58, 185)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(192, 18)
        Me.Label29.TabIndex = 55
        Me.Label29.Text = "Interval :"
        '
        'ballscrewUpdateButton
        '
        Me.ballscrewUpdateButton.Location = New System.Drawing.Point(269, 65)
        Me.ballscrewUpdateButton.Name = "ballscrewUpdateButton"
        Me.ballscrewUpdateButton.Size = New System.Drawing.Size(125, 27)
        Me.ballscrewUpdateButton.TabIndex = 52
        Me.ballscrewUpdateButton.Text = "Update"
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.Label28.Location = New System.Drawing.Point(19, 18)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(48, 19)
        Me.Label28.TabIndex = 50
        Me.Label28.Text = "Axis"
        '
        'ballscrewAxisCombo
        '
        Me.ballscrewAxisCombo.Location = New System.Drawing.Point(67, 18)
        Me.ballscrewAxisCombo.Name = "ballscrewAxisCombo"
        Me.ballscrewAxisCombo.Size = New System.Drawing.Size(144, 24)
        Me.ballscrewAxisCombo.TabIndex = 49
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(128,Byte),Integer))
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Location = New System.Drawing.Point(10, 9)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(883, 46)
        Me.Panel5.TabIndex = 51
        '
        'bsDataPoint
        '
        Me.bsDataPoint.BackColor = System.Drawing.SystemColors.Control
        Me.bsDataPoint.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.bsDataPoint.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.bsDataPoint.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(0,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.bsDataPoint.Location = New System.Drawing.Point(269, 148)
        Me.bsDataPoint.Name = "bsDataPoint"
        Me.bsDataPoint.Size = New System.Drawing.Size(192, 29)
        Me.bsDataPoint.TabIndex = 23
        Me.bsDataPoint.Text = "0"
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label27.Location = New System.Drawing.Point(58, 148)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(192, 18)
        Me.Label27.TabIndex = 22
        Me.Label27.Text = "Data Point:"
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
        Me.tab_tools.Location = New System.Drawing.Point(4, 25)
        Me.tab_tools.Name = "tab_tools"
        Me.tab_tools.Size = New System.Drawing.Size(1019, 498)
        Me.tab_tools.TabIndex = 9
        Me.tab_tools.Text = "Tools"
        '
        'tulAddCutterRCompOffset
        '
        Me.tulAddCutterRCompOffset.Location = New System.Drawing.Point(422, 46)
        Me.tulAddCutterRCompOffset.Name = "tulAddCutterRCompOffset"
        Me.tulAddCutterRCompOffset.Size = New System.Drawing.Size(48, 28)
        Me.tulAddCutterRCompOffset.TabIndex = 192
        Me.tulAddCutterRCompOffset.Text = "Add"
        '
        'tulAddCutterRCompWearOffset
        '
        Me.tulAddCutterRCompWearOffset.Location = New System.Drawing.Point(422, 74)
        Me.tulAddCutterRCompWearOffset.Name = "tulAddCutterRCompWearOffset"
        Me.tulAddCutterRCompWearOffset.Size = New System.Drawing.Size(48, 28)
        Me.tulAddCutterRCompWearOffset.TabIndex = 191
        Me.tulAddCutterRCompWearOffset.Text = "Add"
        '
        'tulToolLifeRemainSec
        '
        Me.tulToolLifeRemainSec.Location = New System.Drawing.Point(528, 111)
        Me.tulToolLifeRemainSec.Name = "tulToolLifeRemainSec"
        Me.tulToolLifeRemainSec.Size = New System.Drawing.Size(86, 22)
        Me.tulToolLifeRemainSec.TabIndex = 190
        Me.tulToolLifeRemainSec.Text = "0"
        '
        'Label205
        '
        Me.Label205.Location = New System.Drawing.Point(528, 46)
        Me.Label205.Name = "Label205"
        Me.Label205.Size = New System.Drawing.Size(77, 46)
        Me.Label205.TabIndex = 189
        Me.Label205.Text = "Tool Life Remaining Seconds"
        '
        'Label151
        '
        Me.Label151.Location = New System.Drawing.Point(355, 18)
        Me.Label151.Name = "Label151"
        Me.Label151.Size = New System.Drawing.Size(77, 19)
        Me.Label151.TabIndex = 188
        Me.Label151.Text = "Data Unit"
        '
        'tulSetDataUnit
        '
        Me.tulSetDataUnit.Location = New System.Drawing.Point(518, 9)
        Me.tulSetDataUnit.Name = "tulSetDataUnit"
        Me.tulSetDataUnit.Size = New System.Drawing.Size(58, 27)
        Me.tulSetDataUnit.TabIndex = 187
        Me.tulSetDataUnit.Text = "Set"
        '
        'tulDataUnitCombo
        '
        Me.tulDataUnitCombo.Location = New System.Drawing.Point(432, 9)
        Me.tulDataUnitCombo.Name = "tulDataUnitCombo"
        Me.tulDataUnitCombo.Size = New System.Drawing.Size(86, 24)
        Me.tulDataUnitCombo.TabIndex = 186
        '
        'tulButtonCutterRLengthOffset
        '
        Me.tulButtonCutterRLengthOffset.Location = New System.Drawing.Point(547, 397)
        Me.tulButtonCutterRLengthOffset.Name = "tulButtonCutterRLengthOffset"
        Me.tulButtonCutterRLengthOffset.Size = New System.Drawing.Size(144, 28)
        Me.tulButtonCutterRLengthOffset.TabIndex = 185
        Me.tulButtonCutterRLengthOffset.Text = "CutterRWearOffset"
        '
        'tulButtonCutterROffset
        '
        Me.tulButtonCutterROffset.Location = New System.Drawing.Point(547, 360)
        Me.tulButtonCutterROffset.Name = "tulButtonCutterROffset"
        Me.tulButtonCutterROffset.Size = New System.Drawing.Size(144, 28)
        Me.tulButtonCutterROffset.TabIndex = 184
        Me.tulButtonCutterROffset.Text = "CutterROffset"
        '
        'tulButtonLengthWearOffset
        '
        Me.tulButtonLengthWearOffset.Location = New System.Drawing.Point(547, 323)
        Me.tulButtonLengthWearOffset.Name = "tulButtonLengthWearOffset"
        Me.tulButtonLengthWearOffset.Size = New System.Drawing.Size(144, 28)
        Me.tulButtonLengthWearOffset.TabIndex = 183
        Me.tulButtonLengthWearOffset.Text = "LengthWearOffset"
        '
        'tulButtonLengthOffset
        '
        Me.tulButtonLengthOffset.Location = New System.Drawing.Point(547, 286)
        Me.tulButtonLengthOffset.Name = "tulButtonLengthOffset"
        Me.tulButtonLengthOffset.Size = New System.Drawing.Size(144, 28)
        Me.tulButtonLengthOffset.TabIndex = 182
        Me.tulButtonLengthOffset.Text = "LengthOffset"
        '
        'tulTo
        '
        Me.tulTo.Location = New System.Drawing.Point(614, 249)
        Me.tulTo.Name = "tulTo"
        Me.tulTo.Size = New System.Drawing.Size(77, 22)
        Me.tulTo.TabIndex = 181
        Me.tulTo.Text = "2"
        '
        'Label125
        '
        Me.Label125.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label125.Location = New System.Drawing.Point(557, 249)
        Me.Label125.Name = "Label125"
        Me.Label125.Size = New System.Drawing.Size(57, 19)
        Me.Label125.TabIndex = 180
        Me.Label125.Text = "To"
        '
        'tulFrom
        '
        Me.tulFrom.Location = New System.Drawing.Point(614, 222)
        Me.tulFrom.Name = "tulFrom"
        Me.tulFrom.Size = New System.Drawing.Size(77, 22)
        Me.tulFrom.TabIndex = 179
        Me.tulFrom.Text = "1"
        '
        'Label126
        '
        Me.Label126.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label126.Location = New System.Drawing.Point(557, 222)
        Me.Label126.Name = "Label126"
        Me.Label126.Size = New System.Drawing.Size(57, 18)
        Me.Label126.TabIndex = 178
        Me.Label126.Text = "From"
        '
        'tulResults
        '
        Me.tulResults.Location = New System.Drawing.Point(701, 222)
        Me.tulResults.Multiline = true
        Me.tulResults.Name = "tulResults"
        Me.tulResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tulResults.Size = New System.Drawing.Size(197, 212)
        Me.tulResults.TabIndex = 177
        '
        'tulAddToolLengthOffset
        '
        Me.tulAddToolLengthOffset.Location = New System.Drawing.Point(422, 323)
        Me.tulAddToolLengthOffset.Name = "tulAddToolLengthOffset"
        Me.tulAddToolLengthOffset.Size = New System.Drawing.Size(48, 28)
        Me.tulAddToolLengthOffset.TabIndex = 176
        Me.tulAddToolLengthOffset.Text = "Add"
        '
        'tulUpdToolGroupOrder
        '
        Me.tulUpdToolGroupOrder.Items.AddRange(New Object() {"True", "False"})
        Me.tulUpdToolGroupOrder.Location = New System.Drawing.Point(278, 268)
        Me.tulUpdToolGroupOrder.Name = "tulUpdToolGroupOrder"
        Me.tulUpdToolGroupOrder.Size = New System.Drawing.Size(144, 24)
        Me.tulUpdToolGroupOrder.TabIndex = 175
        '
        'tulUpdToolStatus
        '
        Me.tulUpdToolStatus.Items.AddRange(New Object() {"True", "False"})
        Me.tulUpdToolStatus.Location = New System.Drawing.Point(278, 240)
        Me.tulUpdToolStatus.Name = "tulUpdToolStatus"
        Me.tulUpdToolStatus.Size = New System.Drawing.Size(144, 24)
        Me.tulUpdToolStatus.TabIndex = 174
        '
        'tulUpdToolMode
        '
        Me.tulUpdToolMode.Location = New System.Drawing.Point(278, 129)
        Me.tulUpdToolMode.Name = "tulUpdToolMode"
        Me.tulUpdToolMode.Size = New System.Drawing.Size(144, 24)
        Me.tulUpdToolMode.TabIndex = 173
        '
        'tulToolNumber
        '
        Me.tulToolNumber.Location = New System.Drawing.Point(192, 13)
        Me.tulToolNumber.Name = "tulToolNumber"
        Me.tulToolNumber.Size = New System.Drawing.Size(77, 22)
        Me.tulToolNumber.TabIndex = 172
        Me.tulToolNumber.Text = "1"
        '
        'label100
        '
        Me.label100.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.label100.Location = New System.Drawing.Point(19, 9)
        Me.label100.Name = "label100"
        Me.label100.Size = New System.Drawing.Size(163, 19)
        Me.label100.TabIndex = 171
        Me.label100.Text = "Tool Number/Offset"
        '
        'Label81
        '
        Me.Label81.Location = New System.Drawing.Point(595, 175)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(96, 37)
        Me.Label81.TabIndex = 170
        Me.Label81.Text = "Values with no parameters :"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tulUpdateButtonNoParam
        '
        Me.tulUpdateButtonNoParam.Location = New System.Drawing.Point(797, 175)
        Me.tulUpdateButtonNoParam.Name = "tulUpdateButtonNoParam"
        Me.tulUpdateButtonNoParam.Size = New System.Drawing.Size(86, 28)
        Me.tulUpdateButtonNoParam.TabIndex = 169
        Me.tulUpdateButtonNoParam.Text = "Update"
        '
        'tulNoParam
        '
        Me.tulNoParam.Location = New System.Drawing.Point(624, 18)
        Me.tulNoParam.Multiline = true
        Me.tulNoParam.Name = "tulNoParam"
        Me.tulNoParam.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tulNoParam.Size = New System.Drawing.Size(298, 148)
        Me.tulNoParam.TabIndex = 168
        '
        'tulUpdateButton
        '
        Me.tulUpdateButton.Location = New System.Drawing.Point(278, 8)
        Me.tulUpdateButton.Name = "tulUpdateButton"
        Me.tulUpdateButton.Size = New System.Drawing.Size(68, 28)
        Me.tulUpdateButton.TabIndex = 167
        Me.tulUpdateButton.Text = "Update"
        '
        'tulSetToolLifeRemaining
        '
        Me.tulSetToolLifeRemaining.Location = New System.Drawing.Point(365, 406)
        Me.tulSetToolLifeRemaining.Name = "tulSetToolLifeRemaining"
        Me.tulSetToolLifeRemaining.Size = New System.Drawing.Size(48, 28)
        Me.tulSetToolLifeRemaining.TabIndex = 166
        Me.tulSetToolLifeRemaining.Text = "Set"
        '
        'tulUpdToolLifeRemaining
        '
        Me.tulUpdToolLifeRemaining.ForeColor = System.Drawing.Color.Red
        Me.tulUpdToolLifeRemaining.Location = New System.Drawing.Point(278, 406)
        Me.tulUpdToolLifeRemaining.Name = "tulUpdToolLifeRemaining"
        Me.tulUpdToolLifeRemaining.Size = New System.Drawing.Size(77, 22)
        Me.tulUpdToolLifeRemaining.TabIndex = 165
        Me.tulUpdToolLifeRemaining.Text = "0"
        '
        'tulToolLifeRemaining
        '
        Me.tulToolLifeRemaining.Location = New System.Drawing.Point(192, 406)
        Me.tulToolLifeRemaining.Name = "tulToolLifeRemaining"
        Me.tulToolLifeRemaining.Size = New System.Drawing.Size(77, 22)
        Me.tulToolLifeRemaining.TabIndex = 164
        Me.tulToolLifeRemaining.Text = "0"
        '
        'Label88
        '
        Me.Label88.Location = New System.Drawing.Point(19, 406)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(163, 19)
        Me.Label88.TabIndex = 163
        Me.Label88.Text = "Tool Life Remaining"
        '
        'tulSetToolLife
        '
        Me.tulSetToolLife.Location = New System.Drawing.Point(365, 378)
        Me.tulSetToolLife.Name = "tulSetToolLife"
        Me.tulSetToolLife.Size = New System.Drawing.Size(48, 28)
        Me.tulSetToolLife.TabIndex = 160
        Me.tulSetToolLife.Text = "Set"
        '
        'tulUpdToolLife
        '
        Me.tulUpdToolLife.ForeColor = System.Drawing.Color.Red
        Me.tulUpdToolLife.Location = New System.Drawing.Point(278, 378)
        Me.tulUpdToolLife.Name = "tulUpdToolLife"
        Me.tulUpdToolLife.Size = New System.Drawing.Size(77, 22)
        Me.tulUpdToolLife.TabIndex = 159
        Me.tulUpdToolLife.Text = "0"
        '
        'tulToolLife
        '
        Me.tulToolLife.Location = New System.Drawing.Point(192, 378)
        Me.tulToolLife.Name = "tulToolLife"
        Me.tulToolLife.Size = New System.Drawing.Size(77, 22)
        Me.tulToolLife.TabIndex = 158
        Me.tulToolLife.Text = "0"
        '
        'Label87
        '
        Me.Label87.Location = New System.Drawing.Point(19, 378)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(163, 19)
        Me.Label87.TabIndex = 157
        Me.Label87.Text = "Tool Life"
        '
        'tulCalToolLengthWearOffset
        '
        Me.tulCalToolLengthWearOffset.Location = New System.Drawing.Point(480, 351)
        Me.tulCalToolLengthWearOffset.Name = "tulCalToolLengthWearOffset"
        Me.tulCalToolLengthWearOffset.Size = New System.Drawing.Size(48, 27)
        Me.tulCalToolLengthWearOffset.TabIndex = 156
        Me.tulCalToolLengthWearOffset.Text = "Cal"
        '
        'tulAddToolLengthWearOffset
        '
        Me.tulAddToolLengthWearOffset.Location = New System.Drawing.Point(422, 351)
        Me.tulAddToolLengthWearOffset.Name = "tulAddToolLengthWearOffset"
        Me.tulAddToolLengthWearOffset.Size = New System.Drawing.Size(48, 27)
        Me.tulAddToolLengthWearOffset.TabIndex = 155
        Me.tulAddToolLengthWearOffset.Text = "Add"
        '
        'tulSetToolLengthWearOffset
        '
        Me.tulSetToolLengthWearOffset.Location = New System.Drawing.Point(365, 351)
        Me.tulSetToolLengthWearOffset.Name = "tulSetToolLengthWearOffset"
        Me.tulSetToolLengthWearOffset.Size = New System.Drawing.Size(48, 27)
        Me.tulSetToolLengthWearOffset.TabIndex = 154
        Me.tulSetToolLengthWearOffset.Text = "Set"
        '
        'tulUpdToolLengthWearOffset
        '
        Me.tulUpdToolLengthWearOffset.ForeColor = System.Drawing.Color.Red
        Me.tulUpdToolLengthWearOffset.Location = New System.Drawing.Point(278, 351)
        Me.tulUpdToolLengthWearOffset.Name = "tulUpdToolLengthWearOffset"
        Me.tulUpdToolLengthWearOffset.Size = New System.Drawing.Size(77, 22)
        Me.tulUpdToolLengthWearOffset.TabIndex = 153
        Me.tulUpdToolLengthWearOffset.Text = "0"
        '
        'tulToolLengthWearOffset
        '
        Me.tulToolLengthWearOffset.Location = New System.Drawing.Point(192, 351)
        Me.tulToolLengthWearOffset.Name = "tulToolLengthWearOffset"
        Me.tulToolLengthWearOffset.Size = New System.Drawing.Size(77, 22)
        Me.tulToolLengthWearOffset.TabIndex = 152
        Me.tulToolLengthWearOffset.Text = "0"
        '
        'Label86
        '
        Me.Label86.Location = New System.Drawing.Point(19, 351)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(163, 18)
        Me.Label86.TabIndex = 151
        Me.Label86.Text = "Tool Length Wear Offset"
        '
        'tulCalToolLengthOffset
        '
        Me.tulCalToolLengthOffset.Location = New System.Drawing.Point(480, 323)
        Me.tulCalToolLengthOffset.Name = "tulCalToolLengthOffset"
        Me.tulCalToolLengthOffset.Size = New System.Drawing.Size(48, 28)
        Me.tulCalToolLengthOffset.TabIndex = 150
        Me.tulCalToolLengthOffset.Text = "Cal"
        '
        'tulSetToolLengthOffset
        '
        Me.tulSetToolLengthOffset.Location = New System.Drawing.Point(365, 323)
        Me.tulSetToolLengthOffset.Name = "tulSetToolLengthOffset"
        Me.tulSetToolLengthOffset.Size = New System.Drawing.Size(48, 28)
        Me.tulSetToolLengthOffset.TabIndex = 148
        Me.tulSetToolLengthOffset.Text = "Set"
        '
        'tulUpdToolLengthOffset
        '
        Me.tulUpdToolLengthOffset.ForeColor = System.Drawing.Color.Red
        Me.tulUpdToolLengthOffset.Location = New System.Drawing.Point(278, 323)
        Me.tulUpdToolLengthOffset.Name = "tulUpdToolLengthOffset"
        Me.tulUpdToolLengthOffset.Size = New System.Drawing.Size(77, 22)
        Me.tulUpdToolLengthOffset.TabIndex = 147
        Me.tulUpdToolLengthOffset.Text = "0"
        '
        'tulToolLengthOffset
        '
        Me.tulToolLengthOffset.Location = New System.Drawing.Point(192, 323)
        Me.tulToolLengthOffset.Name = "tulToolLengthOffset"
        Me.tulToolLengthOffset.Size = New System.Drawing.Size(77, 22)
        Me.tulToolLengthOffset.TabIndex = 146
        Me.tulToolLengthOffset.Text = "0"
        '
        'Label85
        '
        Me.Label85.Location = New System.Drawing.Point(19, 323)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(163, 19)
        Me.Label85.TabIndex = 145
        Me.Label85.Text = "Tool Length Offset"
        '
        'tulToolKind
        '
        Me.tulToolKind.Location = New System.Drawing.Point(192, 295)
        Me.tulToolKind.Name = "tulToolKind"
        Me.tulToolKind.Size = New System.Drawing.Size(77, 22)
        Me.tulToolKind.TabIndex = 140
        Me.tulToolKind.Text = "0"
        '
        'Label84
        '
        Me.Label84.Location = New System.Drawing.Point(19, 295)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(163, 19)
        Me.Label84.TabIndex = 139
        Me.Label84.Text = "Tool Kind"
        '
        'tulSetToolGroupOrder
        '
        Me.tulSetToolGroupOrder.Location = New System.Drawing.Point(432, 268)
        Me.tulSetToolGroupOrder.Name = "tulSetToolGroupOrder"
        Me.tulSetToolGroupOrder.Size = New System.Drawing.Size(48, 27)
        Me.tulSetToolGroupOrder.TabIndex = 136
        Me.tulSetToolGroupOrder.Text = "Set"
        '
        'tulToolGroupOrder
        '
        Me.tulToolGroupOrder.Location = New System.Drawing.Point(192, 268)
        Me.tulToolGroupOrder.Name = "tulToolGroupOrder"
        Me.tulToolGroupOrder.Size = New System.Drawing.Size(77, 22)
        Me.tulToolGroupOrder.TabIndex = 134
        Me.tulToolGroupOrder.Text = "0"
        '
        'Label83
        '
        Me.Label83.Location = New System.Drawing.Point(19, 268)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(163, 18)
        Me.Label83.TabIndex = 133
        Me.Label83.Text = "Tool Group Order"
        '
        'tulSetToolStatus
        '
        Me.tulSetToolStatus.Location = New System.Drawing.Point(432, 240)
        Me.tulSetToolStatus.Name = "tulSetToolStatus"
        Me.tulSetToolStatus.Size = New System.Drawing.Size(48, 28)
        Me.tulSetToolStatus.TabIndex = 130
        Me.tulSetToolStatus.Text = "Set"
        '
        'tulToolStatus
        '
        Me.tulToolStatus.Location = New System.Drawing.Point(192, 240)
        Me.tulToolStatus.Name = "tulToolStatus"
        Me.tulToolStatus.Size = New System.Drawing.Size(77, 22)
        Me.tulToolStatus.TabIndex = 128
        Me.tulToolStatus.Text = "0"
        '
        'Label82
        '
        Me.Label82.Location = New System.Drawing.Point(19, 240)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(163, 18)
        Me.Label82.TabIndex = 127
        Me.Label82.Text = "Tool Status"
        '
        'tulSetReferenceToolOffset3
        '
        Me.tulSetReferenceToolOffset3.Location = New System.Drawing.Point(365, 212)
        Me.tulSetReferenceToolOffset3.Name = "tulSetReferenceToolOffset3"
        Me.tulSetReferenceToolOffset3.Size = New System.Drawing.Size(48, 28)
        Me.tulSetReferenceToolOffset3.TabIndex = 110
        Me.tulSetReferenceToolOffset3.Text = "Set"
        '
        'tulSetReferenceToolOffset2
        '
        Me.tulSetReferenceToolOffset2.Location = New System.Drawing.Point(365, 185)
        Me.tulSetReferenceToolOffset2.Name = "tulSetReferenceToolOffset2"
        Me.tulSetReferenceToolOffset2.Size = New System.Drawing.Size(48, 27)
        Me.tulSetReferenceToolOffset2.TabIndex = 109
        Me.tulSetReferenceToolOffset2.Text = "Set"
        '
        'tulSetToolMode
        '
        Me.tulSetToolMode.Location = New System.Drawing.Point(432, 129)
        Me.tulSetToolMode.Name = "tulSetToolMode"
        Me.tulSetToolMode.Size = New System.Drawing.Size(48, 28)
        Me.tulSetToolMode.TabIndex = 107
        Me.tulSetToolMode.Text = "Set"
        '
        'tulSetToolGroup
        '
        Me.tulSetToolGroup.Location = New System.Drawing.Point(365, 102)
        Me.tulSetToolGroup.Name = "tulSetToolGroup"
        Me.tulSetToolGroup.Size = New System.Drawing.Size(48, 27)
        Me.tulSetToolGroup.TabIndex = 106
        Me.tulSetToolGroup.Text = "Set"
        '
        'tulSetCutterRCompWearOffset
        '
        Me.tulSetCutterRCompWearOffset.Location = New System.Drawing.Point(365, 74)
        Me.tulSetCutterRCompWearOffset.Name = "tulSetCutterRCompWearOffset"
        Me.tulSetCutterRCompWearOffset.Size = New System.Drawing.Size(48, 28)
        Me.tulSetCutterRCompWearOffset.TabIndex = 104
        Me.tulSetCutterRCompWearOffset.Text = "Set"
        '
        'tulSetCutterRCompOffset
        '
        Me.tulSetCutterRCompOffset.Location = New System.Drawing.Point(365, 46)
        Me.tulSetCutterRCompOffset.Name = "tulSetCutterRCompOffset"
        Me.tulSetCutterRCompOffset.Size = New System.Drawing.Size(48, 28)
        Me.tulSetCutterRCompOffset.TabIndex = 103
        Me.tulSetCutterRCompOffset.Text = "Set"
        '
        'tulUpdReferenceToolOffset3
        '
        Me.tulUpdReferenceToolOffset3.ForeColor = System.Drawing.Color.Red
        Me.tulUpdReferenceToolOffset3.Location = New System.Drawing.Point(278, 212)
        Me.tulUpdReferenceToolOffset3.Name = "tulUpdReferenceToolOffset3"
        Me.tulUpdReferenceToolOffset3.Size = New System.Drawing.Size(77, 22)
        Me.tulUpdReferenceToolOffset3.TabIndex = 102
        Me.tulUpdReferenceToolOffset3.Text = "0"
        '
        'tulUpdReferenceToolOffset2
        '
        Me.tulUpdReferenceToolOffset2.ForeColor = System.Drawing.Color.Red
        Me.tulUpdReferenceToolOffset2.Location = New System.Drawing.Point(278, 185)
        Me.tulUpdReferenceToolOffset2.Name = "tulUpdReferenceToolOffset2"
        Me.tulUpdReferenceToolOffset2.Size = New System.Drawing.Size(77, 22)
        Me.tulUpdReferenceToolOffset2.TabIndex = 101
        Me.tulUpdReferenceToolOffset2.Text = "0"
        '
        'tulUpdToolGroup
        '
        Me.tulUpdToolGroup.ForeColor = System.Drawing.Color.Red
        Me.tulUpdToolGroup.Location = New System.Drawing.Point(278, 102)
        Me.tulUpdToolGroup.Name = "tulUpdToolGroup"
        Me.tulUpdToolGroup.Size = New System.Drawing.Size(77, 22)
        Me.tulUpdToolGroup.TabIndex = 99
        Me.tulUpdToolGroup.Text = "0"
        '
        'tulUpdCutterRCompWearOffset
        '
        Me.tulUpdCutterRCompWearOffset.ForeColor = System.Drawing.Color.Red
        Me.tulUpdCutterRCompWearOffset.Location = New System.Drawing.Point(278, 74)
        Me.tulUpdCutterRCompWearOffset.Name = "tulUpdCutterRCompWearOffset"
        Me.tulUpdCutterRCompWearOffset.Size = New System.Drawing.Size(77, 22)
        Me.tulUpdCutterRCompWearOffset.TabIndex = 96
        Me.tulUpdCutterRCompWearOffset.Text = "0"
        '
        'tulUpdCutterRCompOffset
        '
        Me.tulUpdCutterRCompOffset.ForeColor = System.Drawing.Color.Red
        Me.tulUpdCutterRCompOffset.Location = New System.Drawing.Point(278, 46)
        Me.tulUpdCutterRCompOffset.Name = "tulUpdCutterRCompOffset"
        Me.tulUpdCutterRCompOffset.Size = New System.Drawing.Size(77, 22)
        Me.tulUpdCutterRCompOffset.TabIndex = 95
        Me.tulUpdCutterRCompOffset.Text = "0"
        '
        'tulReferenceToolOffset3
        '
        Me.tulReferenceToolOffset3.Location = New System.Drawing.Point(192, 212)
        Me.tulReferenceToolOffset3.Name = "tulReferenceToolOffset3"
        Me.tulReferenceToolOffset3.Size = New System.Drawing.Size(77, 22)
        Me.tulReferenceToolOffset3.TabIndex = 94
        Me.tulReferenceToolOffset3.Text = "0"
        '
        'Label74
        '
        Me.Label74.Location = New System.Drawing.Point(19, 212)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(163, 19)
        Me.Label74.TabIndex = 93
        Me.Label74.Text = "Reference ToolOffset 3"
        '
        'tulReferenceToolOffset2
        '
        Me.tulReferenceToolOffset2.Location = New System.Drawing.Point(192, 185)
        Me.tulReferenceToolOffset2.Name = "tulReferenceToolOffset2"
        Me.tulReferenceToolOffset2.Size = New System.Drawing.Size(77, 22)
        Me.tulReferenceToolOffset2.TabIndex = 92
        Me.tulReferenceToolOffset2.Text = "0"
        '
        'Label75
        '
        Me.Label75.Location = New System.Drawing.Point(19, 185)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(163, 18)
        Me.Label75.TabIndex = 91
        Me.Label75.Text = "Reference ToolOffset 2"
        '
        'tulPotNumber
        '
        Me.tulPotNumber.Location = New System.Drawing.Point(192, 157)
        Me.tulPotNumber.Name = "tulPotNumber"
        Me.tulPotNumber.Size = New System.Drawing.Size(77, 22)
        Me.tulPotNumber.TabIndex = 90
        Me.tulPotNumber.Text = "0"
        '
        'Label76
        '
        Me.Label76.Location = New System.Drawing.Point(19, 157)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(163, 18)
        Me.Label76.TabIndex = 89
        Me.Label76.Text = "Pot Number"
        '
        'tulToolGroup
        '
        Me.tulToolGroup.Location = New System.Drawing.Point(192, 102)
        Me.tulToolGroup.Name = "tulToolGroup"
        Me.tulToolGroup.Size = New System.Drawing.Size(77, 22)
        Me.tulToolGroup.TabIndex = 88
        Me.tulToolGroup.Text = "0"
        '
        'Label77
        '
        Me.Label77.Location = New System.Drawing.Point(19, 102)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(163, 18)
        Me.Label77.TabIndex = 87
        Me.Label77.Text = "Tool Group"
        '
        'tulToolMode
        '
        Me.tulToolMode.Location = New System.Drawing.Point(192, 129)
        Me.tulToolMode.Name = "tulToolMode"
        Me.tulToolMode.Size = New System.Drawing.Size(77, 22)
        Me.tulToolMode.TabIndex = 86
        Me.tulToolMode.Text = "0"
        '
        'Label78
        '
        Me.Label78.Location = New System.Drawing.Point(19, 129)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(163, 19)
        Me.Label78.TabIndex = 85
        Me.Label78.Text = "Tool Mode"
        '
        'Label79
        '
        Me.Label79.Location = New System.Drawing.Point(19, 74)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(173, 18)
        Me.Label79.TabIndex = 84
        Me.Label79.Text = "Cutter R Comp Wear Offset"
        '
        'tulCutterRCompWearOffset
        '
        Me.tulCutterRCompWearOffset.Location = New System.Drawing.Point(192, 74)
        Me.tulCutterRCompWearOffset.Name = "tulCutterRCompWearOffset"
        Me.tulCutterRCompWearOffset.Size = New System.Drawing.Size(77, 22)
        Me.tulCutterRCompWearOffset.TabIndex = 81
        Me.tulCutterRCompWearOffset.Text = "0"
        '
        'Label80
        '
        Me.Label80.Location = New System.Drawing.Point(19, 46)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(163, 19)
        Me.Label80.TabIndex = 82
        Me.Label80.Text = "Cutter R Comp Offset"
        '
        'tulCutterRCompOffset
        '
        Me.tulCutterRCompOffset.Location = New System.Drawing.Point(192, 46)
        Me.tulCutterRCompOffset.Name = "tulCutterRCompOffset"
        Me.tulCutterRCompOffset.Size = New System.Drawing.Size(77, 22)
        Me.tulCutterRCompOffset.TabIndex = 79
        Me.tulCutterRCompOffset.Text = "0"
        '
        'tabAPILoggingService
        '
        Me.tabAPILoggingService.Controls.Add(Me.dgvLogging)
        Me.tabAPILoggingService.Controls.Add(Me.GroupBox40)
        Me.tabAPILoggingService.Location = New System.Drawing.Point(4, 25)
        Me.tabAPILoggingService.Name = "tabAPILoggingService"
        Me.tabAPILoggingService.Size = New System.Drawing.Size(1019, 498)
        Me.tabAPILoggingService.TabIndex = 28
        Me.tabAPILoggingService.Text = "API Logging Service"
        Me.tabAPILoggingService.UseVisualStyleBackColor = true
        '
        'dgvLogging
        '
        Me.dgvLogging.AllowUserToAddRows = false
        Me.dgvLogging.AllowUserToDeleteRows = false
        Me.dgvLogging.AutoGenerateColumns = false
        Me.dgvLogging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLogging.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateLoggedDataGridViewTextBoxColumn, Me.AppNameDataGridViewTextBoxColumn, Me.ClassNameDataGridViewTextBoxColumn, Me.MethodNameDataGridViewTextBoxColumn, Me.IOParametersDataGridViewTextBoxColumn, Me.LoggingLevelDataGridViewTextBoxColumn, Me.MessageDataGridViewTextBoxColumn})
        Me.dgvLogging.DataSource = Me.CLogRecordBindingSource
        Me.dgvLogging.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLogging.Location = New System.Drawing.Point(0, 149)
        Me.dgvLogging.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvLogging.Name = "dgvLogging"
        Me.dgvLogging.ReadOnly = true
        Me.dgvLogging.RowTemplate.Height = 24
        Me.dgvLogging.Size = New System.Drawing.Size(1019, 349)
        Me.dgvLogging.TabIndex = 2
        '
        'DateLoggedDataGridViewTextBoxColumn
        '
        Me.DateLoggedDataGridViewTextBoxColumn.DataPropertyName = "DateLogged"
        Me.DateLoggedDataGridViewTextBoxColumn.HeaderText = "DateLogged"
        Me.DateLoggedDataGridViewTextBoxColumn.Name = "DateLoggedDataGridViewTextBoxColumn"
        Me.DateLoggedDataGridViewTextBoxColumn.ReadOnly = true
        '
        'AppNameDataGridViewTextBoxColumn
        '
        Me.AppNameDataGridViewTextBoxColumn.DataPropertyName = "AppName"
        Me.AppNameDataGridViewTextBoxColumn.HeaderText = "AppName"
        Me.AppNameDataGridViewTextBoxColumn.Name = "AppNameDataGridViewTextBoxColumn"
        Me.AppNameDataGridViewTextBoxColumn.ReadOnly = true
        '
        'ClassNameDataGridViewTextBoxColumn
        '
        Me.ClassNameDataGridViewTextBoxColumn.DataPropertyName = "ClassName"
        Me.ClassNameDataGridViewTextBoxColumn.HeaderText = "ClassName"
        Me.ClassNameDataGridViewTextBoxColumn.Name = "ClassNameDataGridViewTextBoxColumn"
        Me.ClassNameDataGridViewTextBoxColumn.ReadOnly = true
        '
        'MethodNameDataGridViewTextBoxColumn
        '
        Me.MethodNameDataGridViewTextBoxColumn.DataPropertyName = "MethodName"
        Me.MethodNameDataGridViewTextBoxColumn.HeaderText = "MethodName"
        Me.MethodNameDataGridViewTextBoxColumn.Name = "MethodNameDataGridViewTextBoxColumn"
        Me.MethodNameDataGridViewTextBoxColumn.ReadOnly = true
        '
        'IOParametersDataGridViewTextBoxColumn
        '
        Me.IOParametersDataGridViewTextBoxColumn.DataPropertyName = "IOParameters"
        Me.IOParametersDataGridViewTextBoxColumn.HeaderText = "IOParameters"
        Me.IOParametersDataGridViewTextBoxColumn.Name = "IOParametersDataGridViewTextBoxColumn"
        Me.IOParametersDataGridViewTextBoxColumn.ReadOnly = true
        '
        'LoggingLevelDataGridViewTextBoxColumn
        '
        Me.LoggingLevelDataGridViewTextBoxColumn.DataPropertyName = "LoggingLevel"
        Me.LoggingLevelDataGridViewTextBoxColumn.HeaderText = "LoggingLevel"
        Me.LoggingLevelDataGridViewTextBoxColumn.Name = "LoggingLevelDataGridViewTextBoxColumn"
        Me.LoggingLevelDataGridViewTextBoxColumn.ReadOnly = true
        '
        'MessageDataGridViewTextBoxColumn
        '
        Me.MessageDataGridViewTextBoxColumn.DataPropertyName = "Message"
        Me.MessageDataGridViewTextBoxColumn.HeaderText = "Message"
        Me.MessageDataGridViewTextBoxColumn.Name = "MessageDataGridViewTextBoxColumn"
        Me.MessageDataGridViewTextBoxColumn.ReadOnly = true
        '
        'CLogRecordBindingSource
        '
        Me.CLogRecordBindingSource.DataSource = GetType(Okuma.Api.LogService.Data.CLogRecord)
        '
        'GroupBox40
        '
        Me.GroupBox40.Controls.Add(Me.txtLogMessage)
        Me.GroupBox40.Controls.Add(Me.lblMessage)
        Me.GroupBox40.Controls.Add(Me.txtLogIOParameters)
        Me.GroupBox40.Controls.Add(Me.lblIOParameters)
        Me.GroupBox40.Controls.Add(Me.txtLogFunctionName)
        Me.GroupBox40.Controls.Add(Me.lblFunctionName)
        Me.GroupBox40.Controls.Add(Me.txtLogClassName)
        Me.GroupBox40.Controls.Add(Me.lblClassName)
        Me.GroupBox40.Controls.Add(Me.txtLogAppName)
        Me.GroupBox40.Controls.Add(Me.lblAppName)
        Me.GroupBox40.Controls.Add(Me.btnDisplayLogRecords)
        Me.GroupBox40.Controls.Add(Me.Label326)
        Me.GroupBox40.Controls.Add(Me.cboLoggingLevel)
        Me.GroupBox40.Controls.Add(Me.Label327)
        Me.GroupBox40.Controls.Add(Me.Label328)
        Me.GroupBox40.Controls.Add(Me.dtpEndingDate)
        Me.GroupBox40.Controls.Add(Me.dtpStartingDate)
        Me.GroupBox40.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox40.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox40.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox40.Name = "GroupBox40"
        Me.GroupBox40.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox40.Size = New System.Drawing.Size(1019, 149)
        Me.GroupBox40.TabIndex = 1
        Me.GroupBox40.TabStop = false
        Me.GroupBox40.Text = "Log Information"
        '
        'txtLogMessage
        '
        Me.txtLogMessage.Location = New System.Drawing.Point(835, 110)
        Me.txtLogMessage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLogMessage.Name = "txtLogMessage"
        Me.txtLogMessage.Size = New System.Drawing.Size(175, 22)
        Me.txtLogMessage.TabIndex = 16
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = true
        Me.lblMessage.Location = New System.Drawing.Point(696, 112)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(99, 17)
        Me.lblMessage.TabIndex = 15
        Me.lblMessage.Text = "Message Like:"
        '
        'txtLogIOParameters
        '
        Me.txtLogIOParameters.Location = New System.Drawing.Point(517, 110)
        Me.txtLogIOParameters.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLogIOParameters.Name = "txtLogIOParameters"
        Me.txtLogIOParameters.Size = New System.Drawing.Size(141, 22)
        Me.txtLogIOParameters.TabIndex = 14
        '
        'lblIOParameters
        '
        Me.lblIOParameters.AutoSize = true
        Me.lblIOParameters.Location = New System.Drawing.Point(356, 110)
        Me.lblIOParameters.Name = "lblIOParameters"
        Me.lblIOParameters.Size = New System.Drawing.Size(137, 17)
        Me.lblIOParameters.TabIndex = 13
        Me.lblIOParameters.Text = "I/O Parameters Like:"
        '
        'txtLogFunctionName
        '
        Me.txtLogFunctionName.Location = New System.Drawing.Point(181, 110)
        Me.txtLogFunctionName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLogFunctionName.Name = "txtLogFunctionName"
        Me.txtLogFunctionName.Size = New System.Drawing.Size(141, 22)
        Me.txtLogFunctionName.TabIndex = 12
        '
        'lblFunctionName
        '
        Me.lblFunctionName.AutoSize = true
        Me.lblFunctionName.Location = New System.Drawing.Point(5, 110)
        Me.lblFunctionName.Name = "lblFunctionName"
        Me.lblFunctionName.Size = New System.Drawing.Size(137, 17)
        Me.lblFunctionName.TabIndex = 11
        Me.lblFunctionName.Text = "Function Name Like:"
        '
        'txtLogClassName
        '
        Me.txtLogClassName.Location = New System.Drawing.Point(517, 75)
        Me.txtLogClassName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLogClassName.Name = "txtLogClassName"
        Me.txtLogClassName.Size = New System.Drawing.Size(141, 22)
        Me.txtLogClassName.TabIndex = 10
        '
        'lblClassName
        '
        Me.lblClassName.AutoSize = true
        Me.lblClassName.Location = New System.Drawing.Point(356, 82)
        Me.lblClassName.Name = "lblClassName"
        Me.lblClassName.Size = New System.Drawing.Size(117, 17)
        Me.lblClassName.TabIndex = 9
        Me.lblClassName.Text = "Class Name Like:"
        '
        'txtLogAppName
        '
        Me.txtLogAppName.Location = New System.Drawing.Point(181, 82)
        Me.txtLogAppName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtLogAppName.Name = "txtLogAppName"
        Me.txtLogAppName.Size = New System.Drawing.Size(141, 22)
        Me.txtLogAppName.TabIndex = 8
        '
        'lblAppName
        '
        Me.lblAppName.AutoSize = true
        Me.lblAppName.Location = New System.Drawing.Point(5, 82)
        Me.lblAppName.Name = "lblAppName"
        Me.lblAppName.Size = New System.Drawing.Size(152, 17)
        Me.lblAppName.TabIndex = 7
        Me.lblAppName.Text = "Application Name Like:"
        '
        'btnDisplayLogRecords
        '
        Me.btnDisplayLogRecords.Location = New System.Drawing.Point(835, 18)
        Me.btnDisplayLogRecords.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnDisplayLogRecords.Name = "btnDisplayLogRecords"
        Me.btnDisplayLogRecords.Size = New System.Drawing.Size(173, 48)
        Me.btnDisplayLogRecords.TabIndex = 6
        Me.btnDisplayLogRecords.Text = "Display Log Records"
        Me.btnDisplayLogRecords.UseVisualStyleBackColor = true
        '
        'Label326
        '
        Me.Label326.AutoSize = true
        Me.Label326.Location = New System.Drawing.Point(696, 82)
        Me.Label326.Name = "Label326"
        Me.Label326.Size = New System.Drawing.Size(121, 17)
        Me.Label326.TabIndex = 5
        Me.Label326.Text = "Logging Level <=:"
        '
        'cboLoggingLevel
        '
        Me.cboLoggingLevel.FormattingEnabled = true
        Me.cboLoggingLevel.Location = New System.Drawing.Point(835, 80)
        Me.cboLoggingLevel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboLoggingLevel.Name = "cboLoggingLevel"
        Me.cboLoggingLevel.Size = New System.Drawing.Size(175, 24)
        Me.cboLoggingLevel.TabIndex = 4
        '
        'Label327
        '
        Me.Label327.AutoSize = true
        Me.Label327.Location = New System.Drawing.Point(356, 18)
        Me.Label327.Name = "Label327"
        Me.Label327.Size = New System.Drawing.Size(86, 17)
        Me.Label327.TabIndex = 3
        Me.Label327.Text = "Ending Date"
        '
        'Label328
        '
        Me.Label328.AutoSize = true
        Me.Label328.Location = New System.Drawing.Point(5, 25)
        Me.Label328.Name = "Label328"
        Me.Label328.Size = New System.Drawing.Size(91, 17)
        Me.Label328.TabIndex = 2
        Me.Label328.Text = "Starting Date"
        '
        'dtpEndingDate
        '
        Me.dtpEndingDate.CustomFormat = "MM/dd/yyyy HH:mm:ss"
        Me.dtpEndingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndingDate.Location = New System.Drawing.Point(356, 44)
        Me.dtpEndingDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpEndingDate.Name = "dtpEndingDate"
        Me.dtpEndingDate.Size = New System.Drawing.Size(303, 22)
        Me.dtpEndingDate.TabIndex = 1
        '
        'dtpStartingDate
        '
        Me.dtpStartingDate.CustomFormat = "MM/dd/yyyy HH:mm:ss"
        Me.dtpStartingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartingDate.Location = New System.Drawing.Point(5, 44)
        Me.dtpStartingDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpStartingDate.Name = "dtpStartingDate"
        Me.dtpStartingDate.Size = New System.Drawing.Size(303, 22)
        Me.dtpStartingDate.TabIndex = 0
        '
        'errorlog
        '
        Me.errorlog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.errorlog.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.errorlog.ForeColor = System.Drawing.Color.Red
        Me.errorlog.Location = New System.Drawing.Point(3, 536)
        Me.errorlog.Multiline = true
        Me.errorlog.Name = "errorlog"
        Me.errorlog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.errorlog.Size = New System.Drawing.Size(945, 88)
        Me.errorlog.TabIndex = 5
        '
        'clearLogButton
        '
        Me.clearLogButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.clearLogButton.Location = New System.Drawing.Point(954, 536)
        Me.clearLogButton.Name = "clearLogButton"
        Me.clearLogButton.Size = New System.Drawing.Size(76, 88)
        Me.clearLogButton.TabIndex = 5
        Me.clearLogButton.Text = "Clear"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 92.15876!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.841239!))
        Me.TableLayoutPanel1.Controls.Add(Me.MainTabControl, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.clearLogButton, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.errorlog, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.16747!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.83254!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1033, 627)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1033, 627)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.Name = "frmMain"
        Me.Text = "Sample THINC-API (Machining Centers)"
        Me.MainTabControl.ResumeLayout(false)
        Me.tabMain.ResumeLayout(false)
        Me.tabMain.PerformLayout
        Me.GroupBox39.ResumeLayout(false)
        Me.GroupBox39.PerformLayout
        Me.GroupBox34.ResumeLayout(false)
        Me.GroupBox34.PerformLayout
        Me.GroupBox29.ResumeLayout(false)
        Me.GroupBox37.ResumeLayout(false)
        Me.GroupBox37.PerformLayout
        Me.GroupBox30.ResumeLayout(false)
        Me.GroupBox30.PerformLayout
        Me.GroupBox27.ResumeLayout(false)
        Me.GroupBox27.PerformLayout
        Me.GroupBox28.ResumeLayout(false)
        Me.GroupBox28.PerformLayout
        Me.GroupBox31.ResumeLayout(false)
        Me.GroupBox31.PerformLayout
        Me.GroupBox32.ResumeLayout(false)
        Me.GroupBox32.PerformLayout
        Me.GroupBox35.ResumeLayout(false)
        Me.GroupBox35.PerformLayout
        Me.GroupBox36.ResumeLayout(false)
        Me.GroupBox36.PerformLayout
        Me.txtP300ToolGaugeStatusValue.ResumeLayout(false)
        Me.txtP300ToolGaugeStatusValue.PerformLayout
        Me.tab_atc.ResumeLayout(false)
        Me.tab_atc.PerformLayout
        Me.GroupBox13.ResumeLayout(false)
        Me.GroupBox13.PerformLayout
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.Panel2.ResumeLayout(false)
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        Me.tab_P300ATC.ResumeLayout(false)
        Me.GroupBox44.ResumeLayout(false)
        Me.GroupBox44.PerformLayout
        Me.GroupBox33.ResumeLayout(false)
        Me.GroupBox33.PerformLayout
        Me.tab_ATCSubPanel.ResumeLayout(false)
        Me.GroupBox43.ResumeLayout(false)
        Me.GroupBox43.PerformLayout
        Me.GroupBox42.ResumeLayout(false)
        Me.GroupBox42.PerformLayout
        Me.GroupBox41.ResumeLayout(false)
        Me.GroupBox41.PerformLayout
        Me.tab_machine.ResumeLayout(false)
        Me.tab_machine.PerformLayout
        Me.grpHourMeter.ResumeLayout(false)
        Me.grpHourMeter.PerformLayout
        Me.GroupBox8.ResumeLayout(false)
        Me.GroupBox8.PerformLayout
        Me.Panel11.ResumeLayout(false)
        Me.Panel11.PerformLayout
        Me.tab_workpiece.ResumeLayout(false)
        Me.tab_workpiece.PerformLayout
        Me.Panel9.ResumeLayout(false)
        Me.Panel9.PerformLayout
        Me.Panel10.ResumeLayout(false)
        Me.Panel10.PerformLayout
        Me.tab_OptionalParameter.ResumeLayout(false)
        Me.GroupBox12.ResumeLayout(false)
        Me.GroupBox12.PerformLayout
        Me.tab_spec.ResumeLayout(false)
        Me.tab_spec.PerformLayout
        Me.GroupBox26.ResumeLayout(false)
        Me.GroupBox26.PerformLayout
        Me.GroupBox10.ResumeLayout(false)
        Me.GroupBox10.PerformLayout
        Me.Tools2_2.ResumeLayout(false)
        Me.Tools2_2.PerformLayout
        Me.GroupBox21.ResumeLayout(false)
        Me.GroupBox21.PerformLayout
        Me.GroupBox19.ResumeLayout(false)
        Me.GroupBox19.PerformLayout
        Me.GroupBox18.ResumeLayout(false)
        Me.GroupBox18.PerformLayout
        Me.tab_coolant.ResumeLayout(false)
        Me.tab_coolant.PerformLayout
        Me.tab_MacManOperatingHistory.ResumeLayout(false)
        Me.tab_MacManOperatingHistory.PerformLayout
        Me.GroupBox5.ResumeLayout(false)
        Me.GroupBox5.PerformLayout
        Me.GroupBox4.ResumeLayout(false)
        Me.GroupBox4.PerformLayout
        Me.tab_MacManMachiningReport.ResumeLayout(false)
        Me.tab_MacManMachiningReport.PerformLayout
        CType(Me.grdMMMachiningReports,System.ComponentModel.ISupportInitialize).EndInit
        Me.tab_MacmanOperatingReport.ResumeLayout(false)
        Me.tab_MacmanOperatingReport.PerformLayout
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        Me.tab_MacManAlarmHistory.ResumeLayout(false)
        Me.tab_MacManAlarmHistory.PerformLayout
        CType(Me.grdMMAlarmHistory,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox9.ResumeLayout(false)
        Me.GroupBox9.PerformLayout
        Me.tab_MacmanOperationHistory.ResumeLayout(false)
        Me.tab_MacmanOperationHistory.PerformLayout
        Me.tab_CurrentAlarm.ResumeLayout(false)
        Me.GroupBox20.ResumeLayout(false)
        Me.GroupBox20.PerformLayout
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox3,System.ComponentModel.ISupportInitialize).EndInit
        Me.tab_Tools2_1.ResumeLayout(false)
        Me.tab_Tools2_1.PerformLayout
        Me.GroupBox16.ResumeLayout(false)
        Me.GroupBox16.PerformLayout
        Me.GroupBox17.ResumeLayout(false)
        Me.GroupBox17.PerformLayout
        Me.tab_Renishaw_2.ResumeLayout(false)
        Me.GroupBox22.ResumeLayout(false)
        Me.GroupBox22.PerformLayout
        Me.GroupBox25.ResumeLayout(false)
        Me.GroupBox25.PerformLayout
        Me.GroupBox24.ResumeLayout(false)
        Me.GroupBox24.PerformLayout
        Me.GroupBox23.ResumeLayout(false)
        Me.GroupBox23.PerformLayout
        Me.tab_axis.ResumeLayout(false)
        Me.tab_axis.PerformLayout
        Me.tab_Program2.ResumeLayout(false)
        Me.tab_Program2.PerformLayout
        Me.tab_MopTool.ResumeLayout(false)
        Me.tab_MopTool.PerformLayout
        Me.Panel6.ResumeLayout(false)
        Me.Panel6.PerformLayout
        Me.GroupBox6.ResumeLayout(false)
        Me.GroupBox6.PerformLayout
        Me.tab_spindle.ResumeLayout(false)
        Me.tab_spindle.PerformLayout
        Me.tab_axis2.ResumeLayout(false)
        Me.tab_axis2.PerformLayout
        Me.GroupBox38.ResumeLayout(false)
        Me.GroupBox38.PerformLayout
        Me.GroupBox11.ResumeLayout(false)
        Me.GroupBox11.PerformLayout
        Me.Tab_OptionCommonVariables.ResumeLayout(false)
        Me.Tab_OptionCommonVariables.PerformLayout
        Me.grpOptionalCommonVariable.ResumeLayout(false)
        Me.grpOptionalCommonVariable.PerformLayout
        Me.tab_program.ResumeLayout(false)
        Me.tab_program.PerformLayout
        Me.GroupBox15.ResumeLayout(false)
        Me.GroupBox15.PerformLayout
        Me.GroupBox14.ResumeLayout(false)
        Me.GroupBox14.PerformLayout
        Me.Panel8.ResumeLayout(false)
        Me.Panel8.PerformLayout
        Me.tab_Renishaw_1.ResumeLayout(false)
        Me.tab_Renishaw_1.PerformLayout
        Me.tab_variables.ResumeLayout(false)
        Me.tab_variables.PerformLayout
        Me.Tab_View.ResumeLayout(false)
        Me.Panel12.ResumeLayout(false)
        Me.Panel12.PerformLayout
        Me.tab_PLC.ResumeLayout(false)
        Me.grpUserTaskIOVariable.ResumeLayout(false)
        Me.grpUserTaskIOVariable.PerformLayout
        Me.grpIOVariables.ResumeLayout(false)
        Me.grpIOVariables.PerformLayout
        Me.tab_ballscrew.ResumeLayout(false)
        Me.tab_ballscrew.PerformLayout
        Me.tab_tools.ResumeLayout(false)
        Me.tab_tools.PerformLayout
        Me.tabAPILoggingService.ResumeLayout(false)
        CType(Me.dgvLogging,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.CLogRecordBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox40.ResumeLayout(false)
        Me.GroupBox40.PerformLayout
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        Me.ResumeLayout(false)

End Sub

#End Region




    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            globalTimer = New System.Windows.Forms.Timer

            cboLoggingLevel.DataSource = System.Enum.GetValues(GetType(Okuma.ApiLog2.LoggingLevelEnum))

            cboATCSubPanelOperationModes.DataSource = System.Enum.GetValues(GetType(ATCSubPanelOperationModeEnum))

            'init combos
            cboHourMeterCount.DataSource = System.Enum.GetValues(GetType(HourMeterEnum))
            cboHourMeterCountSet.DataSource = System.Enum.GetValues(GetType(HourMeterEnum))
            cboWorkpieceCounterSet.DataSource = System.Enum.GetValues(GetType(WorkpieceCounterEnum))

            cboHomePositionAxis.DataSource = System.Enum.GetValues(GetType(AxisIndexEnum))

            cboP300ToolKind2.DataSource = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.ToolKind2Enum))
            Me.cboP300DiameterKind.DataSource = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.DiameterKindEnum))
            Me.cboP300WeightKind.DataSource = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.WeightKindEnum))
            Me.cboP300HeightKind.DataSource = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.HeightKindEnum))

            cboP300ToolLifeStatus.DataSource = System.Enum.GetValues(GetType(Okuma.CMDATAPI.Enumerations.ToolLifeStatusEnum))

            Me.cboP300ToolsDataUnit.DataSource = System.Enum.GetValues(GetType(DataUnitEnum))

            Me.cboP300ToolCompensation.DataSource = System.Enum.GetValues(GetType(ToolCompensationEnum))

            Me.cboUserAlarm.DataSource = System.Enum.GetValues(GetType(UserAlarmEnum))
            Me.cboSlopeCoordAxisIndex.DataSource = System.Enum.GetValues(GetType(LinearAxisIndexEnum))


            Me.cboRotaryAxisStructure.DataSource = System.Enum.GetValues(GetType(RotaryAxisStructureEnum))
            Me.cboLinearAxisIndex.DataSource = System.Enum.GetValues(GetType(LinearAxisIndexEnum))
            Me.cboRotationCenters.DataSource = System.Enum.GetValues(GetType(RotationCenterSideEnum))
            Me.cboRotaryAxes.DataSource = System.Enum.GetValues(GetType(RotaryAxisIndexEnum))


            Me.cboSetUserTaskOutputVariable.DataSource = System.Enum.GetValues(GetType(OnOffStateEnum))
            Me.cboSetUserTaskOutputVariableProtected.DataSource = System.Enum.GetValues(GetType(OnOffStateEnum))


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


            '------------added by 
            Me.ballscrewDataUnitCombo.DataSource = System.Enum.GetValues(GetType(DataUnitEnum))
            Me.tulDataUnitCombo.DataSource = System.Enum.GetValues(GetType(DataUnitEnum))
            Me.wkDataUnitCombo.DataSource = System.Enum.GetValues(GetType(DataUnitEnum))
            Me.axisDataUnit.DataSource = System.Enum.GetValues(GetType(DataUnitEnum))
            Me.Cmb_rptPeriod.DataSource = System.Enum.GetValues(GetType(Okuma.CMDATAPI.Enumerations.ReportPeriodEnum))
            Me.Cmb_ChangeScreen.DataSource = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.PanelGroupEnum))
            '------------added by 

            ' init file read mod enum
            cboFileReadModeEnum.DataSource = System.Enum.GetValues(GetType(Okuma.CMCMDAPI.Enumerations.FileReadModeEnum))

            ' Try
            m_objMachine = New CMachine(System.Reflection.Assembly.GetExecutingAssembly().ToString())


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' It is important to create the DataAPI.CMachine object first and call the Init method to initialize the 
            ' communication with NC, explicitly.
            ' Before exiting the application, it can call m_objMachine.Close to close the communication with NC.
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            m_objMachine.Init()




            m_objAtc = New CATC
            m_objAxis = New CAxis
            m_objAxis2 = New CAxis
            m_objBS = New CBallScrew
            m_objCoolant = New CCoolant
            m_objCMOP = New CMOPTool
            m_objProgram = New CProgram
            m_objSpec = New CSpec
            m_objSpindle = New CSpindle
            m_objTools = New CTools
            m_objVariables = New CVariables
            m_objWorkPiece = New CWorkpiece
            m_objOptionalParameter = New COptionalParameter
            m_objIO = New CIO
            m_objToolID1 = New CTools2
            m_objToolID2 = New CTools2

            m_objCmdATC = New Okuma.CMCMDAPI.CommandAPI.CATC()
            m_objCmdATC2 = New Okuma.CMCMDAPI.CommandAPI.CATC2()
            m_objCmdATCPanel = New Okuma.CMCMDAPI.CommandAPI.CATCPanel()

            m_objAlarmHistory = New MacMan.CAlarmHistory
            m_objOperatingReport = New MacMan.COperatingReport
            m_objOperationHistory = New MacMan.COperationHistory
            m_objMachiningReport = New MacMan.CMachiningReport
            m_objOperatingHistory = New MacMan.COperatingHistory



            ' Add sample application version to form caption 
            Dim objVersion As System.Version
            Dim strVersion As String

            objVersion = [Assembly].GetExecutingAssembly.GetName().Version

            strVersion = String.Format("{0}.{1}.{2}.{3}", objVersion.Major.ToString, objVersion.Minor.ToString, objVersion.Build.ToString, objVersion.Revision.ToString)
            Me.Text = String.Format("{0} - {1}", "THINC Machining Center Sample Application", strVersion)


            cboAllLoggingLevel.DataSource = System.Enum.GetValues(GetType(Okuma.CMDATAPI.Enumerations.LoggingLevelEnum))

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
        m_objMachine.Close()
    End Sub
    Private Sub DisplayError(ByVal moduleName As String, ByVal errMsg As String)
        Me.errorlog.Text = Now() & " - " & moduleName & ": " & errMsg & vbCrLf & Me.errorlog.Text

    End Sub
    Private Sub clearLogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearLogButton.Click
        Me.errorlog.Text = ""
    End Sub


#Region "ATC tab"
    Private Sub btnGetPalletID_Click(sender As System.Object, e As System.EventArgs) Handles btnGetPalletID.Click
        Dim objcatc As Okuma.CMDATAPI.DataAPI.CATC
        Try
            objcatc = New Okuma.CMDATAPI.DataAPI.CATC
            txtPalletID.Text = objcatc.GetPalletID()
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try
    End Sub
    Private Sub atcButtonRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcButtonRegister.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC
            objcatc.RegisterToolPot(CInt(Me.atcCMDPotNumber.Text), CInt(Me.atcCMDToolNumber.Text))
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try
    End Sub

    Private Sub atcButtonRegisterAttribute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcButtonRegisterAttribute.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC
            objcatc.RegisterToolPot(CInt(Me.atcCMDPotNumber.Text), CInt(Me.atcCMDToolNumber.Text), Me.atcComboToolAttribute.SelectedValue)
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try
    End Sub

    Private Sub atcButtonUnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcButtonUnRegister.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC
            objcatc.UnRegisterToolPot(CInt(Me.atcCMDPotNumber.Text))
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
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try
    End Sub

    Private Sub atcUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcUpdateButton.Click
        Dim atcType As ATCTypeEnum
        Dim maxMagazines As Int32
        Dim magazineType As MagazineTypeEnum
        Dim maxPots As Int32
        Dim retTool As String = ""
        Dim retPotNo As String = ""
        Dim actTool As String = ""
        Dim nextTool As String = ""
        Dim intATCSequence As Integer


        Try

            atcType = m_objAtc.GetATCType
            maxMagazines = m_objAtc.GetMaxMagazines
            magazineType = m_objAtc.GetMagazineType
            maxPots = m_objAtc.GetMaxPots
            actTool = m_objAtc.GetActualTool
            nextTool = m_objAtc.GetNextTool
            intATCSequence = m_objAtc.GetATCSequence()


            retTool = m_objAtc.GetReturnTool
            retPotNo = m_objAtc.GetReturnPotNo()
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try

        Me.atcStatus.Text = "ATC Type: " & System.Enum.GetNames(GetType(ATCTypeEnum)).GetValue(atcType) & vbCrLf _
            & "Number of Magazines: " & maxMagazines & vbCrLf _
            & "Magazine Type: " & System.Enum.GetNames(GetType(MagazineTypeEnum)).GetValue(magazineType) & vbCrLf _
            & "Number of Pots: " & maxPots & vbCrLf _
            & "Return Tool: " & retTool & vbCrLf _
            & "Return Pot No: " & retPotNo & vbCrLf _
            & "Actual Tool: " & actTool & vbCrLf _
            & "Next Tool: " & nextTool & vbCrLf _
            & "ATC sequence: " & intATCSequence & vbCrLf


    End Sub
    Private Sub getMemoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles getMemoButton.Click
        Try
            Me.heavyToolMemo.Text = m_objAtc.GetHeavyToolMemo()
            Me.largeToolMemo.Text = m_objAtc.GetLargeToolMemo()
        Catch ex As Exception
            DisplayError("CATC: Heavy Tool Memo", ex.Message)
        End Try
    End Sub

    Private Sub getMagazineButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles getMagazineButton.Click
        Dim magProp As MagazineProperty

        Try
            Me.atcMagazinePosition.Text = m_objAtc.GetMagazinePosition(CInt(Me.magazineNumber.Text))
            magProp = m_objAtc.GetMagazineProperty(CInt(Me.magazineNumber.Text))
            Me.numberOfPots.Text = magProp.PotPerMagazine
            Me.startingPot.Text = magProp.StartingPotNumber
            Me.endingPot.Text = magProp.EndingPotNumber
        Catch ex As Exception
            DisplayError("CATC: Magazine Property", ex.Message)
        End Try
    End Sub

    Private Sub atcPotNumberButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcPotNumberButton.Click
        Dim toolProp As ToolProperty
        Try
            toolProp = m_objAtc.GetPotTool(CInt(Me.potNumber.Text))
            Me.potToolNumber.Text = toolProp.intToolNo
            Me.potToolKind.Text = toolProp.strToolKind
        Catch ex As Exception
            DisplayError("CATC: GetPotTool", ex.Message)
        End Try
    End Sub

    Private Sub atcSetHeavyToolMemo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcSetHeavyToolMemo.Click
        Try
            m_objAtc.SetHeavyToolMemo(Me.heavyToolMemo.Text)
            Me.heavyToolMemo.Text = m_objAtc.GetHeavyToolMemo()
            Me.largeToolMemo.Text = m_objAtc.GetLargeToolMemo()
        Catch ex As Exception
            DisplayError("CATC: GetPotTool", ex.Message)
        End Try
    End Sub

    Private Sub atcSetLargeToolMemo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles atcSetLargeToolMemo.Click
        Try
            m_objAtc.SetLargeToolMemo(Me.largeToolMemo.Text)
            Me.heavyToolMemo.Text = m_objAtc.GetHeavyToolMemo()
            Me.largeToolMemo.Text = m_objAtc.GetLargeToolMemo()
        Catch ex As Exception
            DisplayError("CATC: GetPotTool", ex.Message)
        End Try
    End Sub


    Private Sub cmdSetActualTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetActualTool.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC
            objcatc.SetActualTool(CInt(Me.atcCMDToolNumber.Text), atcComboToolAttribute.SelectedValue)
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try
    End Sub

    Private Sub cmdSetNextTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetNextTool.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC
            objcatc.SetNextTool(CInt(Me.atcCMDToolNumber.Text))
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try
    End Sub

    Private Sub cmdSetReturnPot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetReturnPot.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC
            objcatc.SetReturnPot(CInt(Me.atcCMDPotNumber.Text))
        Catch ex As Exception
            DisplayError("CATC", ex.Message)
        End Try
    End Sub
#End Region

#Region "Axis Tab"

    Private Sub axisUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles axisUpdateButton.Click
        refresh_axis_tab()
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

        Me.actualFeedrate.Text = m_objAxis.GetActualFeedrate(curFeedrateEnum)


        Me.apMachineCoord.Text = CDbl(m_objAxis.GetActualPositionMachineCoord(curAxisEnum))
        Me.apProgramCoord.Text = CDbl(m_objAxis.GetActualPositionProgramCoord(curAxisEnum))
        Me.apEncoderCoord.Text = CDbl(m_objAxis.GetActualPositionEncoderCoord(curAxisEnum))
        '---------added by 
        Me.txt_RelativeActualPositionProgramCoord.Text = CDbl(m_objAxis.GetRelativeActualPositionProgramCoord(curAxisEnum))
        Me.axisLoad.Text = m_objAxis.GetAxisLoad(curAxisEnum)
        Me.commandFeedRate.Text = m_objAxis.GetCommandFeedrate(curCommandFeedrateEnum)
        Me.distanceTarget.Text = m_objAxis.GetDistanceToTargetPosition(curAxisEnum)
        Me.targetPosition.Text = m_objAxis.GetTargetPosition(curAxisEnum)
        Me.axisName.Text = m_objAxis.GetAxisName(curAxisEnum)
        Me.axisType.Text = System.Enum.GetNames(GetType(AxisTypeEnum)).GetValue(m_objAxis.GetAxisType(curAxisEnum))
        Me.feedHold.Text = m_objAxis.GetFeedHold
        Me.feedrateOverride.Text = m_objAxis.GetFeedrateOverride
        Me.feedrateType.Text = System.Enum.GetNames(GetType(FeedrateTypeEnum)).GetValue(m_objAxis.GetFeedrateType)
        Me.maxFeedrateOverride.Text = m_objAxis.GetMaxFeedrateOverride
        Me.txtRapidFeedrateOverride.Text = m_objAxis.GetRapidFeedrateOverride()


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
        '
        Try
            m_objAxis.SetDataUnit(Me.axisDataUnit.SelectedValue)
            refresh_axis_tab()
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
        Dim enDataUnit As DataUnitEnum

        Try
            enDataUnit = ballscrewDataUnitCombo.SelectedItem

            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)

            m_objBS.SetDataUnit(enDataUnit)

            Me.bsDataPoint.Text = m_objBS.GetDataPoint(CInt(Me.bsPecPoint.Text), curAxisEnum)

            Me.bsInterval.Text = m_objBS.GetInterval(curAxisEnum)
            Me.bsMaxPitchPoints.Text = m_objBS.GetMaxPitchPoints(curAxisEnum)
            Me.bsStartPosition.Text = m_objBS.GetStartPositionInNDirection(curAxisEnum)
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
    Private Sub bsIntervalSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsIntervalSet.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            m_objBS.SetInterval(curAxisEnum, CInt(Me.bsIntervalUpdate.Text))
            ballscrewUpdate()
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
    Private Sub bsMaxPicthPointsSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsMaxPicthPointsSet.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            m_objBS.SetMaxPitchPoints(curAxisEnum, CInt(Me.bsMaxPitchPointsUpdate.Text))
            ballscrewUpdate()
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
    Private Sub bsStartPositionSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsStartPositionSet.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            m_objBS.SetStartPositionInNDirection(curAxisEnum, CDbl(Me.bsStartPositionUpdate.Text))
            ballscrewUpdate()
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
    Private Sub bsIntervalAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsIntervalAdd.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            m_objBS.AddInterval(curAxisEnum, CInt(Me.bsIntervalUpdate.Text))
            ballscrewUpdate()
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub

    Private Sub bsMaxPitchPointsAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsMaxPitchPointsAdd.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            m_objBS.AddMaxPitchPoints(curAxisEnum, CInt(Me.bsMaxPitchPointsUpdate.Text))
            ballscrewUpdate()
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub

    Private Sub bsStartPositionAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsStartPositionAdd.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            m_objBS.AddStartPositionInNDirection(curAxisEnum, CDbl(Me.bsStartPositionUpdate.Text))
            ballscrewUpdate()
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
    Private Sub bsDataPointSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsDataPointSet.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            m_objBS.SetDataPoint(CInt(Me.bsPecPoint.Text), curAxisEnum, CInt(Me.bsDataPointUpdate.Text))
            Me.bsDataPoint.Text = m_objBS.GetDataPoint(CInt(Me.bsPecPoint.Text), curAxisEnum)
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try




    End Sub

    Private Sub bsDataPointAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsDataPointAdd.Click
        Dim curAxisEnum As AxisIndexEnum
        Try
            curAxisEnum = System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.ballscrewAxisCombo.SelectedValue)
            m_objBS.AddDataPoint(CInt(Me.bsPecPoint.Text), curAxisEnum, CInt(Me.bsDataPointUpdate.Text))
            Me.bsDataPoint.Text = m_objBS.GetDataPoint(CInt(Me.bsPecPoint.Text), curAxisEnum)
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
    Private Sub bsDataUnitSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bsDataUnitSet.Click
        '
        Try
            m_objBS.SetDataUnit(Me.ballscrewDataUnitCombo.SelectedValue)
            ballscrewUpdate()
        Catch ex As Exception
            DisplayError("CBallScrew", ex.Message)
        End Try
    End Sub
#End Region


#Region "Machine tab"

    Private Sub machineUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles machineUpdateButton.Click
        DisplayMachineStatus()
    End Sub

    ' ''#If ____RENISHAW_API____ = True Then
    'Private Sub DisplayMachineStatus()
    '    Dim strMachine As String
    '    Try
    '        txtMachine.Text = ""
    '        strMachine = strMachine & "Execution Mode: " & System.Enum.GetName(GetType(ExecutionModeEnum), m_objMachine.GetExecutionMode) & vbCrLf
    '        strMachine = strMachine & "Operation Mode: " & System.Enum.GetName(GetType(OperationModeEnum), m_objMachine.GetOperationMode) & vbCrLf
    '        strMachine = strMachine & "Panel Mode: " & System.Enum.GetName(GetType(PanelModeEnum), m_objMachine.GetPanelMode) & vbCrLf
    '        strMachine = strMachine & "Display Unit System : " & m_objMachine.GetOperationUnitSystemDisplay() & vbCrLf
    '        strMachine = strMachine & "Power On time : " & m_objMachine.GetPowerOnTime & vbCrLf

    '        strMachine = strMachine & "NC Alarm Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), m_objMachine.GetNCStatus(NCStatusEnum.Alarm)) & vbCrLf
    '        strMachine = strMachine & "NC STM Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), m_objMachine.GetNCStatus(NCStatusEnum.STM)) & vbCrLf
    '        strMachine = strMachine & "NC LIMIT Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), m_objMachine.GetNCStatus(NCStatusEnum.Limit)) & vbCrLf
    '        strMachine = strMachine & "NC PROGRAM STOP Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), m_objMachine.GetNCStatus(NCStatusEnum.ProgramStop)) & vbCrLf
    '        strMachine = strMachine & "NC SLIDE HOLD Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), m_objMachine.GetNCStatus(NCStatusEnum.SlideHold)) & vbCrLf

    '        strMachine = strMachine & "Active alarm message: " & m_objMachine.GetCurrentAlarmMessage() & vbCrLf

    '        strMachine = strMachine & "NC Reset: " & m_objMachine.IsNCReset().ToString


    '        txtMachine.Text = strMachine

    '    Catch ex As Exception
    '        DisplayError("machineUpdateButton_Click", ex.Message)
    '    End Try
    'End Sub
    ' ''#Else
    Private Sub DisplayMachineStatus()
        Dim strMachine As String = ""
        Try
            txtMachine.Text = ""
            strMachine = strMachine & "Execution Mode: " & System.Enum.GetName(GetType(ExecutionModeEnum), m_objMachine.GetExecutionMode) & vbCrLf
            strMachine = strMachine & "Operation Mode: " & System.Enum.GetName(GetType(OperationModeEnum), m_objMachine.GetOperationMode) & vbCrLf
            strMachine = strMachine & "Panel Mode: " & System.Enum.GetName(GetType(PanelModeEnum), m_objMachine.GetPanelMode) & vbCrLf
            strMachine = strMachine & "Display Unit System : " & m_objMachine.GetOperationUnitSystemDisplay() & vbCrLf
            strMachine = strMachine & "Power On time : " & m_objMachine.GetPowerOnTime & vbCrLf

            strMachine = strMachine & "NC Alarm Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), m_objMachine.GetNCStatus(NCStatusEnum.Alarm)) & vbCrLf
            strMachine = strMachine & "NC STM Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), m_objMachine.GetNCStatus(NCStatusEnum.STM)) & vbCrLf
            strMachine = strMachine & "NC LIMIT Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), m_objMachine.GetNCStatus(NCStatusEnum.Limit)) & vbCrLf
            strMachine = strMachine & "NC PROGRAM STOP Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), m_objMachine.GetNCStatus(NCStatusEnum.ProgramStop)) & vbCrLf
            strMachine = strMachine & "NC SLIDE HOLD Status Light: " & System.Enum.GetName(GetType(OnOffStateEnum), m_objMachine.GetNCStatus(NCStatusEnum.SlideHold)) & vbCrLf
            strMachine = strMachine & "NC RUN LIGHT: " & System.Enum.GetName(GetType(OnOffStateEnum), m_objMachine.GetNCStatus(NCStatusEnum.Run)) & vbCrLf
            strMachine = strMachine & "NC Reset state: " & m_objMachine.GetNCReset().ToString() & vbCrLf

            strMachine = strMachine & "Active alarm message: " & m_objMachine.GetCurrentAlarmMessage() & vbCrLf

            txtMachine.Text = strMachine

        Catch ex As Exception
            DisplayError("machineUpdateButton_Click", ex.Message)
        End Try
    End Sub
    ''#End If


    Private Sub machinePowerOnTimeSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles machinePowerOnTimeSet.Click
        Try
            m_objMachine.SetPowerOnTime(CInt(Me.machinePowerOnTimeUpdate.Text))
            DisplayMachineStatus()
        Catch ex As Exception
            DisplayError("CMachine:", ex.Message)
        End Try
    End Sub

    Private Sub machinePowerOnTimeAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles machinePowerOnTimeAdd.Click
        Try
            m_objMachine.AddPowerOnTime(CInt(Me.machinePowerOnTimeUpdate.Text))
            DisplayMachineStatus()
        Catch ex As Exception
            DisplayError("CMachine:", ex.Message)
        End Try
    End Sub

#End Region

#Region "Coolant Tab"
    Private Sub coolantUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles coolantUpdateButton.Click
        Try
            Me.coolantChipCondition.Text = System.Enum.GetName(GetType(OnOffEnum), CInt(m_objCoolant.GetChipFlushCondition))
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

            Me.mopToolDataNumber.Text = m_objCMOP.GetToolDataNumber(CInt(mopCMDToolNumber.Text), CInt(mopCMDClassNumber.Text))
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

        Me.mopAdaptiveControl.Text = m_objCMOP.GetAdaptiveControl(curAxisEnum, curMopTool)
        Me.mopAircutOverride.Text = m_objCMOP.GetAirCutOverride(curMopTool)
        Me.mopAircutReduction.Text = m_objCMOP.GetAirCutReduction(curAxisEnum, curMopTool)
        Me.mopALVValue.Text = m_objCMOP.GetALVValue(curAxisEnum, curMopTool, posTypeEnum)
        Me.mopAlarms.Text = System.Enum.GetNames(GetType(MOPToolDataAlarm)).GetValue(m_objCMOP.GetAlarm(curAxisEnum, curMopTool))
        Me.mopAutoChange.Text = System.Enum.GetNames(GetType(OnOffEnum)).GetValue(m_objCMOP.GetAutoChange(curAxisEnum, curMopTool))
        Me.mopCuttingTime.Text = m_objCMOP.GetCuttingTime(curMopTool)
        Me.mopLimitValue.Text = m_objCMOP.GetLimitValue(curAxisEnum, curMopTool, posTypeEnum)
        Me.mopLLValue.Text = m_objCMOP.GetLLValue(curAxisEnum, curMopTool, posTypeEnum)
        Me.mopMaxOverride.Text = m_objCMOP.GetMaxOverride(curMopTool)
        Me.mopMinOverride.Text = m_objCMOP.GetMinOverride(curMopTool)
        Me.mopOverloadMonitor.Text = m_objCMOP.GetOverloadMonitor(curAxisEnum, curMopTool)
        Me.mopReferenceValue.Text = m_objCMOP.GetReferenceValue(curAxisEnum, curMopTool)
        Me.mopUnusualSignal.Text = m_objCMOP.GetAmountUnsualSignalChange(curMopTool)

        Me.mopToolDataInputMode.Text = System.Enum.GetNames(GetType(MOPToolInputModeEnum)).GetValue(m_objCMOP.GetToolDataInputMode)


        Me.mopUlValue.Text = m_objCMOP.GetULValue(curAxisEnum, curMopTool, posTypeEnum)
        Me.TXT_GetMaxMOPToolData.Text = CInt(m_objCMOP.GetMaxMOPToolData) '---------ADDED BY 


        'wait for kenji input
        Me.mopCuttingLoad.Text = m_objCMOP.GetCuttingLoadAtAlarm(curAxisEnum, curMopTool)
        Me.mopSignalDiffAlarm.Text = m_objCMOP.GetSignalDifferentAtAlarm(curAxisEnum, curMopTool)

        Exit Sub

sd:

        DisplayError("CMOP Tool", Err.Description)
        Resume Next
    End Sub

    Private Sub mopButtonAdaptiveControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonAdaptiveControl.Click
        Try
            m_objCMOP.SetAdaptiveControl(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CInt(Me.mopSetAdaptiveControl.Text))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try

    End Sub

    Private Sub mopButtonAircutOverride_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonAircutOverride.Click
        Try
            m_objCMOP.SetAirCutOverride(CInt(Me.mopToolNumber.Text), CInt(Me.mopSetAircutOverride.Text))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonAircutReduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonAircutReduction.Click
        Try
            m_objCMOP.SetAirCutReduction(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CInt(Me.mopSetAircutReduction.Text))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonALVValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonALVValue.Click
        Try
            m_objCMOP.SetALVValue(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CDbl(Me.mopSetALVValue.Text), CInt(Me.mopPositionTypeCombo.SelectedValue))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonUnusualSignalChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonUnusualSignalChange.Click
        Try
            m_objCMOP.SetAmountUnsualSignalChange(CInt(Me.mopAxisCombo.SelectedValue), CDbl(Me.mopSetUnusualSignal.Text))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopbuttonAutoChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopbuttonAutoChange.Click
        Try
            m_objCMOP.SetAutoChange(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CInt(Me.mopSetAutoChange.Text))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonCuttingTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonCuttingTime.Click
        Try
            m_objCMOP.SetCuttingTime(CInt(Me.mopToolNumber.Text), CDbl(Me.mopSetCuttingTime.Text))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonLimitValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonLimitValue.Click
        Try
            m_objCMOP.SetLimitValue(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CDbl(Me.mopSetLimitValue.Text), CInt(Me.mopPositionTypeCombo.SelectedValue))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonLLValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonLLValue.Click
        Try
            m_objCMOP.SetLLValue(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CDbl(Me.mopSetLLValue.Text), CInt(Me.mopPositionTypeCombo.SelectedValue))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonMaxOverride_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonMaxOverride.Click
        Try
            m_objCMOP.SetMaxOverride(CInt(Me.mopToolNumber.Text), CInt(Me.mopSetMaxOverride.Text))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonMinOverride_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonMinOverride.Click
        Try
            m_objCMOP.SetMinOverride(CInt(Me.mopToolNumber.Text), CInt(Me.mopSetMinOverride.Text))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonOverloadMonitor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonOverloadMonitor.Click
        Try
            m_objCMOP.SetOverloadMonitor(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CInt(Me.mopSetOverloadMonitor.Text))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonReferenceValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonReferenceValue.Click
        Try
            m_objCMOP.SetReferenceValue(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CDbl(Me.mopSetReferenceValue.Text))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonToolDataInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonToolDataInput.Click
        Try
            m_objCMOP.SetToolDataInputMode(CInt(Me.mopSetToolDataInputMode.Text))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub

    Private Sub mopButtonULValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mopButtonULValue.Click
        Try
            m_objCMOP.SetULValue(CInt(Me.mopAxisCombo.SelectedValue), CInt(Me.mopToolNumber.Text), CDbl(Me.mopSetULValue.Text), CInt(Me.mopPositionTypeCombo.SelectedValue))
            mopUpdate()
        Catch ex As Exception
            DisplayError("CMOP Tool", ex.Message)
        End Try
    End Sub
#End Region

#Region "Program Tab"



    Private Sub cmdReturnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSubProgramFileName.Click
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
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub

    ''#If ____RENISHAW_API____ Then




    'Private Sub progUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progUpdateButton.Click

    '    Dim activeProgramFname As String = ""
    '    Dim activeProgramName As String = ""
    '    Dim currentBlockNumber As Int32
    '    Dim defaultProgramPath As String = ""
    '    Dim execSequenceNumber As String = ""
    '    Dim gCodes As String = ""
    '    Dim mCodes As String = ""
    '    Dim currentProgram As String = ""
    '    Dim currentProgramFile As String = ""




    '    Try

    '        activeProgramFname = m_objProgram.GetActiveProgramFileName
    '        activeProgramName = m_objProgram.GetActiveProgramName
    '        currentBlockNumber = m_objProgram.GetCurrentBlockNumber
    '        defaultProgramPath = m_objProgram.GetDefaultProgramPath
    '        execSequenceNumber = m_objProgram.GetExecutedSequenceNumber
    '        gCodes = m_objProgram.GetGCodes
    '        mCodes = m_objProgram.GetMCodes

    '        currentProgram = m_objProgram.GetCurrentActiveProgramName
    '        currentProgramFile = m_objProgram.GetCurrentActiveProgramFileName



    '    Catch ae As ApplicationException
    '        DisplayError("CProgram", ae.Message)
    '        'Exit Sub
    '    Catch ex As Exception
    '        DisplayError("CProgram", ex.Message)
    '    End Try

    '    Me.progNoParams.Text = "Active Program Filename: " & activeProgramFname & vbCrLf _
    '        & "Active Program Name: " & activeProgramName & vbCrLf _
    '        & "Current Block Number: " & currentBlockNumber & vbCrLf _
    '        & "Default Program Path: " & defaultProgramPath & vbCrLf _
    '        & "Execution Sequence Number: " & execSequenceNumber & vbCrLf _
    '        & "G Codes: " & gCodes & vbCrLf _
    '        & "M Codes: " & mCodes & vbCrLf _
    '        & "current Active Program Name: " & currentProgram & vbCrLf _
    '        & "current Active Program File Name: " & currentProgramFile & vbCrLf
    'End Sub

    ''#Else
    Private Sub progUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progUpdateButton.Click

        Dim activeProgramFname As String = ""
        Dim activeProgramName As String = ""
        Dim currentBlockNumber As Int32
        Dim defaultProgramPath As String = ""
        Dim execSequenceNumber As String = ""
        Dim gCodes As String = ""
        Dim mCodes As String = ""
        Dim currentProgram As String = ""
        Dim currentProgramFile As String = ""
        Dim blnProgramCycleComplete As Boolean
        Dim blnScheduleProgramCycleComplete As Boolean
        Dim strScheduleProgramName As String = ""
        Dim enProgramRunningState As ProgramRunningStateEnum




        Try

            activeProgramFname = m_objProgram.GetActiveProgramFileName
            activeProgramName = m_objProgram.GetActiveProgramName
            currentBlockNumber = m_objProgram.GetCurrentBlockNumber
            defaultProgramPath = m_objProgram.GetDefaultProgramPath
            execSequenceNumber = m_objProgram.GetExecutedSequenceNumber
            enProgramRunningState = m_objProgram.GetProgramRunningState()

            gCodes = m_objProgram.GetGCodes
            mCodes = m_objProgram.GetMCodes

            blnProgramCycleComplete = m_objProgram.CycleComplete
            blnScheduleProgramCycleComplete = m_objProgram.ScheduleProgramCycleComplete

            strScheduleProgramName = m_objProgram.GetActiveScheduleProgramFileName


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
            & "M Codes: " & mCodes & vbCrLf _
            & "current Active Program Name: " & currentProgram & vbCrLf _
            & "current Active Program File Name: " & currentProgramFile & vbCrLf _
            & "Program Cycle complete: " & blnProgramCycleComplete & vbCrLf _
            & "Schedule Program Cycle complete: " & blnScheduleProgramCycleComplete & vbCrLf _
            & "Program Running State: " & enProgramRunningState & vbCrLf _
            & "Active Schedule Program Cycle name: " & strScheduleProgramName & vbCrLf
    End Sub

    ''#End If

    Private Sub progButtonExecBlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progButtonExecBlock.Click
        Dim curExecEnum As ExecuteBlockTypeEnum
        Try
            curExecEnum = System.Enum.GetValues(GetType(ExecuteBlockTypeEnum)).GetValue(Me.progExecCombo.SelectedValue)
            progExecutingBlock.Text = m_objProgram.GetExecuteBlock(curExecEnum)
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub

    Private Sub progButtonGetRunProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles progButtonGetRunProgram.Click
        Dim rp() As String
        Dim currp As String
        Dim rpoint As Int32
        Dim epoint As Int32


        Try
            progRunningPrograms.Clear()
            rp = m_objProgram.GetRunningProgram(CInt(Me.progRow.Text), CInt(Me.progColumn.Text), rpoint, epoint)

            Me.progExecutePoint.Text = epoint
            Me.progRead.Text = rpoint
            For Each currp In rp
                progRunningPrograms.Text += currp & vbCrLf
            Next
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
        Catch ex As Exception
            DisplayError("CMD Program", ex.Message)
        End Try
    End Sub

    Private Sub cmdSelectScheduleProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectScheduleProgram.Click
        Dim objcprogram As New Okuma.CMCMDAPI.CommandAPI.CProgram
        Try
            objcprogram.SelectScheduleProgram(prog1.Text)
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

            Me.specCode.Text = m_objSpec.GetOptionSpecCode(curSpecEnum)

            txtMachineName.Text = m_objSpec.GetMachineName
            txtMachineSerial.Text = m_objSpec.GetMachineSerialNumber

            txtControlType.Text = m_objSpec.GetControlType().ToString()
        Catch ex As Exception
            DisplayError("CSpec", ex.Message)
        End Try
    End Sub

    Private Sub cmdGetSpecCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetSpecCode.Click
        Try
            txtSpecCode.Text = m_objSpec.GetSpecCode(CInt(txtSpecCodeIndex.Text), CInt(txtSpecCodeBit.Text))
        Catch ex As Exception
            DisplayError("CSpec", ex.Message)
        End Try
    End Sub

    Private Sub cmdGetBSpecCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetBSpecCode.Click
        Try
            txtSpecCode.Text = m_objSpec.GetBSpecCode(CInt(txtSpecCodeIndex.Text), CInt(txtSpecCodeBit.Text))
        Catch ex As Exception
            DisplayError("CSpec", ex.Message)
        End Try
    End Sub

    Private Sub btnGetPLC3SpecCode_Click(sender As System.Object, e As System.EventArgs) Handles btnGetPLC3SpecCode.Click
        Try
            txtPLCSpecCode.Text = m_objSpec.GetPLCSpecCode3(CInt(txtPLCSpecCodeIndex.Text), CInt(txtPLCSpecCodeBit.Text))

        Catch ae As ApplicationException
            DisplayError("CSpec", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("CSpec", ne.Message)
        Catch ex As Exception
            DisplayError("CSpec", ex.Message)
        End Try
    End Sub

    Private Sub btnGetPLC2SpecCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPLC2SpecCode.Click
        Try
            txtPLCSpecCode.Text = m_objSpec.GetPLCSpecCode2(CInt(txtPLCSpecCodeIndex.Text), CInt(txtPLCSpecCodeBit.Text))
        Catch ex As Exception
            DisplayError("CSpec", ex.Message)
        End Try
    End Sub
    Private Sub btnGetPLCSpecCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPLCSpecCode.Click
        Try
            txtPLCSpecCode.Text = m_objSpec.GetPLCSpecCode(CInt(txtPLCSpecCodeIndex.Text), CInt(txtPLCSpecCodeBit.Text))
        Catch ex As Exception
            DisplayError("CSpec", ex.Message)
        End Try
    End Sub
#End Region

#Region "Spindle Tab"
    Private Sub spinUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spinUpdate.Click
        Try
            Me.spinActualRate.Text = m_objSpindle.GetActualSpindlerate
            Me.spinCommandRate.Text = m_objSpindle.GetCommandSpindlerate
            Me.spinLoad.Text = m_objSpindle.GetSpindleLoad
            Me.spinMaxOverrideRate.Text = m_objSpindle.GetMaxSpindlerateOverride
            Me.spinOilMist.Text = System.Enum.GetNames(GetType(OnOffEnum)).GetValue(m_objSpindle.GetOilMistCondition)
            Me.spinRateOverride.Text = m_objSpindle.GetSpindlerateOverride
            Me.spinState.Text = System.Enum.GetNames(GetType(SpindleStateEnum)).GetValue(m_objSpindle.GetSpindleState)
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
            dblResults = m_objTools.GetToolLengthOffset(CInt(Me.tulFrom.Text), CInt(Me.tulTo.Text))
            For Each dr In dblResults
                Me.tulResults.Text += dr & vbCrLf
            Next
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulButtonLengthWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulButtonLengthWearOffset.Click
        Dim dblResults As Double()
        Dim dr As Double

        Try
            Me.tulResults.Text = ""
            dblResults = m_objTools.GetToolLengthWearOffset(CInt(Me.tulFrom.Text), CInt(Me.tulTo.Text))
            For Each dr In dblResults
                Me.tulResults.Text += dr & vbCrLf
            Next
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try

    End Sub

    Private Sub tulButtonCutterROffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulButtonCutterROffset.Click
        Dim dblResults As Double()
        Dim dr As Double

        Try
            Me.tulResults.Text = ""
            dblResults = m_objTools.GetCutterRCompOffset(CInt(Me.tulFrom.Text), CInt(Me.tulTo.Text))
            For Each dr In dblResults
                Me.tulResults.Text += dr & vbCrLf
            Next
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulButtonCutterRLengthOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulButtonCutterRLengthOffset.Click
        Dim dblResults As Double()
        Dim dr As Double

        Try
            Me.tulResults.Text = ""
            dblResults = m_objTools.GetCutterRCompWearOffset(CInt(Me.tulFrom.Text), CInt(Me.tulTo.Text))
            For Each dr In dblResults
                Me.tulResults.Text += dr & vbCrLf
            Next
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



        On Error GoTo ErrorHandler

        CurrentCutterRCompOffsetNumber = m_objTools.GetCurrentCutterRCompOffsetNumber
        CurrentToolLengthOffsetNumber = m_objTools.GetCurrentToolLengthOffsetNumber
        CurrentToolNumber = m_objTools.GetCurrentToolNumber
        MaxTools = m_objTools.GetMaxTools

        Me.tulNoParam.Text = "Current Cutter R Comp Offset Number: " & CurrentCutterRCompOffsetNumber & vbCrLf _
            & "Current Tool Length Offset Number: " & CurrentToolLengthOffsetNumber & vbCrLf _
            & "Current Tool Number: " & CurrentToolNumber & vbCrLf _
            & "Max Tools: " & MaxTools

        Exit Sub

ErrorHandler:
        DisplayError("CTool", Err.Description)

        Resume Next



    End Sub

    Private Sub updateTools()
        On Error GoTo sd

        Dim toolNum As Integer
        toolNum = CInt(Me.tulToolNumber.Text)


        Me.tulCutterRCompOffset.Text = m_objTools.GetCutterRCompOffset(toolNum)
        Me.tulPotNumber.Text = m_objTools.GetPotNo(toolNum)
        Me.tulReferenceToolOffset2.Text = m_objTools.GetReferenceToolOffset2(toolNum)
        Me.tulReferenceToolOffset3.Text = m_objTools.GetReferenceToolOffset3(toolNum)
        Me.tulToolGroup.Text = m_objTools.GetGroupNo(toolNum)
        Me.tulToolGroupOrder.Text = System.Enum.GetNames(GetType(ToolGroupOrderEnum)).GetValue(m_objTools.GetToolGroupOrder(toolNum))
        Me.tulToolKind.Text = m_objTools.GetToolKind(toolNum)
        Me.tulToolLengthOffset.Text = m_objTools.GetToolLengthOffset(toolNum)
        Me.tulToolLife.Text = m_objTools.GetToolLife(toolNum)
        Me.tulToolLifeRemaining.Text = m_objTools.GetToolLifeRemaining(toolNum)
        Me.tulToolMode.Text = System.Enum.GetNames(GetType(ToolLifeModeEnum)).GetValue(m_objTools.GetMode(toolNum))
        Me.tulToolStatus.Text = System.Enum.GetName(GetType(Okuma.CMDATAPI.Enumerations.ToolLifeStatusEnum), m_objTools.GetStatus(toolNum))
        '
        Me.tulToolLifeRemainSec.Text = m_objTools.GetToolLifeRemainingTimeSecond(toolNum)



        Me.tulToolLengthWearOffset.Text = m_objTools.GetToolLengthWearOffset(toolNum)
        Me.tulCutterRCompWearOffset.Text = m_objTools.GetCutterRCompWearOffset(toolNum)

        Exit Sub

sd:

        DisplayError("CTool", Err.Description)
        Resume Next
    End Sub


    Private Sub tulSetCutterRCompOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetCutterRCompOffset.Click
        Try
            m_objTools.SetCutterRCompOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdCutterRCompOffset.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetCutterRCompWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetCutterRCompWearOffset.Click
        Try
            m_objTools.SetCutterRCompWearOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdCutterRCompWearOffset.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolGroup.Click
        Try
            m_objTools.SetGroupNo(CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdToolGroup.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolMode.Click
        Try
            m_objTools.SetMode(CInt(Me.tulToolNumber.Text), Me.tulUpdToolMode.SelectedValue)
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetReferenceToolOffset2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetReferenceToolOffset2.Click
        Try
            m_objTools.SetReferenceToolOffset2(CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdReferenceToolOffset2.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetReferenceToolOffset3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetReferenceToolOffset3.Click
        Try
            m_objTools.SetReferenceToolOffset3(CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdReferenceToolOffset3.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolStatus.Click
        Try
            Dim intToolNo As Integer
            Dim blnValue As Boolean
            intToolNo = CInt(Me.tulToolNumber.Text)
            blnValue = Me.tulUpdToolStatus.Text
            m_objTools.SetStatus(intToolNo, blnValue)
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolGroupOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolGroupOrder.Click
        Try
            m_objTools.SetToolGroupOrder(CInt(Me.tulToolNumber.Text), Me.tulUpdToolGroupOrder.SelectedValue)
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolLengthOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolLengthOffset.Click
        Try
            m_objTools.SetToolLengthOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdToolLengthOffset.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolLengthWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolLengthWearOffset.Click
        Try
            m_objTools.SetToolLengthWearOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdToolLengthWearOffset.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolLife_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolLife.Click
        Try
            m_objTools.SetToolLife(CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdToolLife.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulSetToolLifeRemaining_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetToolLifeRemaining.Click
        Try
            m_objTools.SetToolLifeRemaining(CInt(Me.tulToolNumber.Text), CInt(Me.tulUpdToolLifeRemaining.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub
    Private Sub tulAddToolLengthWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulAddToolLengthWearOffset.Click
        Try
            m_objTools.AddToolLengthWearOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdToolLengthWearOffset.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub
    Private Sub tulAddToolLengthOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulAddToolLengthOffset.Click
        Try
            m_objTools.AddToolLengthOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdToolLengthOffset.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulCalToolLengthWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulCalToolLengthWearOffset.Click
        Try
            m_objTools.CalToolLengthWearOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdToolLengthWearOffset.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulCalToolLengthOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulCalToolLengthOffset.Click
        Try
            m_objTools.CalToolLengthOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdToolLengthOffset.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub
    Private Sub tulSetDataUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulSetDataUnit.Click
        '
        Try
            m_objTools.SetDataUnit(Me.tulDataUnitCombo.SelectedValue)
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub
#End Region


#Region "Common Var Tab"



    Private Sub varUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles varUpdateButton.Click

        Try
            Me.varValue.Text = m_objVariables.GetCommonVariableValue(CInt(Me.varCommonVarNumber.Text))
            Me.varNumberOfVars.Text = m_objVariables.GetCommonVariableCount
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub

    Private Sub varSetValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles varSetValue.Click
        Try
            m_objVariables.SetCommonVariableValue(CInt(Me.varCommonVarNumber.Text), CDbl(Me.varValueUpdate.Text))
            Me.varValue.Text = m_objVariables.GetCommonVariableValue(CInt(Me.varCommonVarNumber.Text))
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub

    Private Sub varAddValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles varAddValue.Click
        Try
            m_objVariables.AddCommonVariableValue(CInt(Me.varCommonVarNumber.Text), CDbl(Me.varValueUpdate.Text))
            Me.varValue.Text = m_objVariables.GetCommonVariableValue(CInt(Me.varCommonVarNumber.Text))
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub

    Private Sub varGetAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles varGetAllButton.Click
        Dim varRes As Double()
        Dim curRes As Double

        Try
            Me.varGetAllResults.Text = ""
            varRes = m_objVariables.GetCommonVariableValues(CInt(Me.varBegin.Text), CInt(Me.varEnd.Text))
            For Each curRes In varRes
                Me.varGetAllResults.Text += curRes & vbCrLf
            Next
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub
#End Region

#Region "Workpiece Tab"

    Private Sub btnWPCounterSetGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWPCounterSetGet.Click
        Try
            txtWPCounterSet.Text = m_objWorkPiece.GetWorkpieceCounterSet(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(cboWorkpieceCounterSet.SelectedValue))
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub
    Private Sub btnWPCounterSetAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWPCounterSetAdd.Click
        Try
            m_objWorkPiece.AddWorkpieceCounterSet(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(cboWorkpieceCounterSet.SelectedValue), CInt(txtWPCounterSetValue.Text))
            txtWPCounterSet.Text = m_objWorkPiece.GetWorkpieceCounterSet(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(cboWorkpieceCounterSet.SelectedValue))
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub
    Private Sub btnWPCounterSetSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWPCounterSetSet.Click
        Try
            m_objWorkPiece.SetWorkpieceCounterSet(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(cboWorkpieceCounterSet.SelectedValue), CInt(txtWPCounterSetValue.Text))
            txtWPCounterSet.Text = m_objWorkPiece.GetWorkpieceCounterSet(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(cboWorkpieceCounterSet.SelectedValue))
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub


    Private Sub wkButtonGetCounter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkButtonGetCounter.Click
        Try
            wkCounterValue.Text = m_objWorkPiece.GetWorkpieceCounter(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(wkCounterCombo.SelectedValue))
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub
    Private Sub wkCounterSetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkCounterSetButton.Click
        Try
            m_objWorkPiece.SetWorkpieceCounter(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(wkCounterCombo.SelectedValue), CInt(Me.wkUpdateCounter.Text))
            wkCounterValue.Text = m_objWorkPiece.GetWorkpieceCounter(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(wkCounterCombo.SelectedValue))
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub


    Private Sub wkButtonZeroOffsetGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkButtonZeroOffsetGet.Click
        Try
            Me.wkZeroOffset.Text = m_objWorkPiece.GetZeroOffset(CInt(Me.wkOffsetNumber.Text), System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.wkAxisCombo.SelectedValue))
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub wkButtonZeroOffsetSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkButtonZeroOffsetSet.Click
        Try
            m_objWorkPiece.SetZeroOffset(CInt(Me.wkOffsetNumber.Text), System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.wkAxisCombo.SelectedValue), CDbl(Me.wkUpdateZeroOffset.Text))
            Me.wkZeroOffset.Text = m_objWorkPiece.GetZeroOffset(CInt(Me.wkOffsetNumber.Text), System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.wkAxisCombo.SelectedValue))
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub wkButtonZeroOffsetAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkButtonZeroOffsetAdd.Click
        Try
            m_objWorkPiece.AddZeroOffset(CInt(Me.wkOffsetNumber.Text), System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.wkAxisCombo.SelectedValue), CDbl(Me.wkUpdateZeroOffset.Text))
            Me.wkZeroOffset.Text = m_objWorkPiece.GetZeroOffset(CInt(Me.wkOffsetNumber.Text), System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.wkAxisCombo.SelectedValue))
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub

    Private Sub wkButtonZeroOffsetCal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkButtonZeroOffsetCal.Click
        Try
            m_objWorkPiece.CalZeroOffset(CInt(Me.wkOffsetNumber.Text), System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.wkAxisCombo.SelectedValue), CDbl(Me.wkUpdateZeroOffset.Text))
            Me.wkZeroOffset.Text = m_objWorkPiece.GetZeroOffset(CInt(Me.wkOffsetNumber.Text), System.Enum.GetValues(GetType(AxisIndexEnum)).GetValue(Me.wkAxisCombo.SelectedValue))
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

            MaxZeroOffset = m_objWorkPiece.GetMaxZeroOffset
            CurrentZeroOffsetNumber = m_objWorkPiece.GetCurrentZeroOffsetNumber
            ZeroResults = m_objWorkPiece.GetZeroOffsets(CInt(Me.wkZeroFrom.Text), CInt(Me.wkZeroTo.Text), CInt(wkAxisCombo.SelectedValue))
            For Each zr In ZeroResults
                Me.wkZeroResults.Text += zr & vbCrLf
            Next

        Catch ex As Exception
            DisplayError("Cworkpiece", ex.Message)
        End Try

        Me.wkValsWithoutParameters.Text = "Maximum Zero Offset : " & MaxZeroOffset & vbCrLf _
            & "Current Zero Offset Number: " & CurrentZeroOffsetNumber & vbCrLf
    End Sub
    '
    Private Sub wkSetDataUnitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkSetDataUnitButton.Click
        Try
            m_objWorkPiece.SetDataUnit(Me.wkDataUnitCombo.SelectedValue)
        Catch ex As Exception
            DisplayError("Cworkpiece", ex.Message)
        End Try
    End Sub
#End Region


#Region "Macman Alarm History Tab"

    Private Sub mahButtonResults_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mahButtonResults.Click
        Dim mohObjects As ArrayList

        Try
            mohObjects = m_objAlarmHistory.GetAlarms(CInt(Me.mahFrom.Text), CInt(Me.mahTo.Text))

            grdMMAlarmHistory.DataSource = mohObjects
            grdMMAlarmHistory.Refresh()
        Catch ex As Exception
            DisplayError("MacMan Alarm History", ex.Message)
        End Try
    End Sub

    Private Sub mahUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mahUpdateButton.Click
        UpdateMah()
    End Sub

    Private Sub UpdateMah()
        On Error GoTo sd
        Dim alarmIndex As Int32
        alarmIndex = CInt(Me.mahAlarmIndex.Text)
        Dim mahObject As MacMan.CAlarm
        mahObject = m_objAlarmHistory.GetAlarm(alarmIndex)

        Me.mahAlarmCount.Text = m_objAlarmHistory.GetCount
        Me.mahMaxAlarmCount.Text = m_objAlarmHistory.GetMaxCount

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

        Me.morNonoperatingCondition.Text = System.Enum.GetNames(GetType(NonOperatingConditionEnum)).GetValue(m_objOperatingReport.GetNonOperatingCondition)
        Me.morOperatingStatus.Text = System.Enum.GetNames(GetType(OperatingStatusEnum)).GetValue(m_objOperatingReport.GetOperatingStatus)

        Me.morDateOfOperatingReport.Text = m_objOperatingReport.GetTodayOperatingReportDate()
        Me.morMaxNoOfOpReport.Text = m_objOperatingReport.GetMaxCount()

        Me.morOperatingTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.OperatingTime)
        Me.morRunningTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.RunningTime)
        Me.morCuttingTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.CuttingTime)
        Me.morNonOPeratingTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.NonOperatingTime)
        Me.morInProSetupTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.InProcessSetupTime)
        Me.morNoOperatorTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.NoOperatorTime)
        Me.morPartWaitingTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.PartWaitingTime)
        Me.mormaintenanceTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.MaintenanceTime)
        Me.morOtherTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.OtherTime)
        Me.morSpindleRunTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.SpindleRunTime)
        Me.morExternalInputTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.ExternalInputTime)
        Me.morAlarmOnTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.AlarmOnTime)




        Me.morPrevDateOfOperatingRept.Text = m_objOperatingReport.GetPreviousOperatingReportDate()

        Me.morPrevAlarmOnTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.AlarmOnTime)
        Me.morPrevCuttingTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.CuttingTime)
        Me.morPrevInProSetupTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.InProcessSetupTime)
        Me.morPrevMaintenanceTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.MaintenanceTime)
        Me.morPrevNonOperatingTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.NonOperatingTime)
        Me.morPrevNoOperatorTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.NoOperatorTime)
        Me.morPrevOperatingTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.OperatingTime)
        Me.morPrevOtherTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.OtherTime)
        Me.morPrevPartwaitingTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.PartWaitingTime)
        Me.morPrevRunningTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.RunningTime)
        Me.morPrevSpindleRunTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.SpindleRunTime)
        Me.morPrevExternalInputTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.ExternalInputTime)


        Me.morPeriodDateOfOperatingReport.Text = m_objOperatingReport.GetPeriodOperatingReportDate()

        Me.morPeriodAlarmOnTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.AlarmOnTime)
        Me.morPeriodCuttingTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.CuttingTime)
        Me.morPeriodExternalInputTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.ExternalInputTime)
        Me.morPeriodInproSetupTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.InProcessSetupTime)
        Me.morPeriodMaintenanceTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.MaintenanceTime)
        Me.morPeriodNonOperatingTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.NonOperatingTime)
        Me.morPeriodNoOperatorTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.NoOperatorTime)
        Me.morPeriodOperatingTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.OperatingTime)
        Me.morPeriodOtherTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.OtherTime)
        Me.morPeriodPartWaitingTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.PartWaitingTime)
        Me.morPeriodRunningTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.RunningTime)
        Me.morPeriodSpindleRunTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.SpindleRunTime)

        Exit Sub
sd:

        DisplayError("MacmMan Operating Report", Err.Description)
        Resume Next
    End Sub

#End Region

#Region "Macman Operation History"
    Private Sub mohUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mohUpdateButton.Click
        On Error GoTo sd
        Dim opIndex As Int32
        Dim mohObject As MacMan.COperation

        opIndex = CInt(Me.mohOperationIndex.Text)

        mohObject = m_objOperationHistory.GetOperationHistory(opIndex)

        Me.mohOperationData.Text = mohObject.Data
        Me.mohOperationDate.Text = mohObject.Date
        Me.mohOperationTime.Text = mohObject.Time
        Me.mohOperationCount.Text = m_objOperationHistory.GetCount
        Me.mohOperationMaxCount.Text = m_objOperationHistory.GetMaxCount

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
            mohObjects = m_objOperationHistory.GetOperationHistory(CInt(Me.mohFrom.Text), CInt(Me.mohTo.Text))
            For Each mohObject In mohObjects
                Me.mohResults.Text += String.Format("{0:###}", intIndex.ToString()) & vbTab & mohObject.Date & vbTab & mohObject.Time & vbTab & mohObject.Data & vbCrLf
                intIndex = intIndex + 1
            Next
        Catch ex As Exception
            DisplayError("CWorkpiece", ex.Message)
        End Try
    End Sub
#End Region

#Region "Macman Operating History"
    '
    Private Sub objMopnhUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles objMopnhUpdateButton.Click
        On Error GoTo sd


        Me.mopnhAlarmOnTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.AlarmOnTime))
        Me.mopnhCuttingTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.CuttingTime))
        Me.mopnhExternalInputTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.ExternalInputTime))
        Me.mopnhInProSetupTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.InProcessSetupTime))
        Me.mopnhMaintenanceTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.MaintenanceTime))
        Me.mopnhNonOperatingReport.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.NonOperatingTime))
        Me.mopnhNoOperatorTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.NoOperatorTime))
        Me.mopnhOperatingTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.OperatingTime))
        Me.mopnhOtherTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.OtherTime))
        Me.mopnhPartWaitingTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.PartWaitingTime))
        Me.mopnhRunningTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.RunningTime))
        Me.mopnhSpindleRunTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.SpindleRunTime))

        Me.mopnhPrevAlarmonTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.AlarmOnTime))
        Me.mopnhPrevCuttingTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.CuttingTime))
        Me.mopnhPrevExternalInputTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.ExternalInputTime))
        Me.mopnhPrevInProSetupTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.InProcessSetupTime))
        Me.mopnhPrevMaintenanceTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.MaintenanceTime))
        Me.mopnhPrevNonOperatingTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.NonOperatingTime))
        Me.mopnhPrevNoOperatorTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.NoOperatorTime))
        Me.mopnhPrevOperatingTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.OperatingTime))
        Me.mopnhPrevOtherTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.OtherTime))
        Me.mopnhPrevPartWaitingTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.PartWaitingTime))
        Me.mopnhPrevRunningTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.RunningTime))
        Me.mopnhPrevSpindleRunTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.mopnhFrom.Text), CInt(Me.mopnhTo.Text), OperatingReportDataEnum.SpindleRunTime))

        Me.mopnhMaxNoofReports.Text = m_objOperatingHistory.GetMaxCount()
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
        Dim opIndex As Int32
        int_PeriodReport = CInt(Me.Cmb_rptPeriod.SelectedItem)
        opIndex = CInt(Me.MacReport_Index.Text)
        Mac_reportObject = m_objMachiningReport.GetMachiningReport(opIndex, int_PeriodReport)
        Me.MacReport_count.Text = m_objMachiningReport.GetCount(int_PeriodReport)
        Me.macreport_maxcount.Text = m_objMachiningReport.GetMaxCount(int_PeriodReport)

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
        Dim int_PeriodReport As Int32
        Dim mac_objects As ArrayList
        Dim opIndex As Int32

        Try
            int_PeriodReport = CInt(Me.Cmb_rptPeriod.SelectedItem)
            opIndex = CInt(Me.txtFrom.Text)
            mac_objects = m_objMachiningReport.GetMachiningReports(CInt(txtFrom.Text), CInt(txtto.Text), int_PeriodReport)

            grdMMMachiningReports.DataSource = mac_objects
            grdMMMachiningReports.Refresh()
        Catch ex As Exception
            DisplayError("MacMan Machining  Report", ex.Message)
        End Try
    End Sub

#End Region



    Private Sub cmd_ChangeScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_ChangeScreen.Click
        '----------------
        Dim objview As Okuma.CMCMDAPI.CommandAPI.CViews
        Dim int_panalenum As Int32
        Try
            int_panalenum = CInt(Cmb_ChangeScreen.SelectedItem)
            objview = New Okuma.CMCMDAPI.CommandAPI.CViews
            objview.ChangeScreen(int_panalenum, txt_screenname.Text)
        Catch ex As Exception
            DisplayError("Cview", ex.Message)
        End Try
    End Sub

    Private Sub cmd_InputMDI_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_InputMDI.Click
        '-------------------------------

        Dim objmac As Okuma.CMCMDAPI.CommandAPI.CMachine

        Try
            objmac = New Okuma.CMCMDAPI.CommandAPI.CMachine
            objmac.InputMDI(txtInputMDI.Text)
        Catch ex As Exception
            DisplayError("Cmachine", ex.Message)
        End Try
    End Sub

    Private Sub btnClearUserAlarmD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearUserAlarmD.Click
        Dim objmac As Okuma.CMCMDAPI.CommandAPI.CMachine

        Try
            objmac = New Okuma.CMCMDAPI.CommandAPI.CMachine
            objmac.ClearUserAlarmD()
        Catch ex As Exception
            DisplayError("Cmachine", ex.Message)
        End Try
    End Sub

    Private Sub btnSetUserAlarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetUserAlarm.Click
        Dim objmac As Okuma.CMCMDAPI.CommandAPI.CMachine

        Try
            objmac = New Okuma.CMCMDAPI.CommandAPI.CMachine
            objmac.SetUserAlarm(cboUserAlarm.SelectedValue, txtUserAlarmMessage.Text.Trim())

        Catch ex As Exception
            DisplayError("Cmachine", ex.Message)
        End Try
    End Sub
    Private Sub cmd_WorkpieceAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_WorkpieceAdd.Click

        Try
            m_objWorkPiece.AddWorkpieceCounter(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(wkCounterCombo.SelectedValue), CInt(Me.wkUpdateCounter.Text))
            wkCounterValue.Text = m_objWorkPiece.GetWorkpieceCounter(System.Enum.GetValues(GetType(WorkpieceCounterEnum)).GetValue(wkCounterCombo.SelectedValue))
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
            txtOutputMachineZeroOffset.Text = m_objMachine.GetZeroOffset(cboMachineZeroOffsetAxis.SelectedValue)
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub

    Private Sub cmdSetMachineZeroOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetMachineZeroOffset.Click
        Try
            m_objMachine.SetZeroOffset(cboMachineZeroOffsetAxis.SelectedValue, CDbl(txtInputMachineZeroOffset.Text))
            txtOutputMachineZeroOffset.Text = m_objMachine.GetZeroOffset(cboMachineZeroOffsetAxis.SelectedValue)
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub

    Private Sub cmdAddMachineZeroOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddMachineZeroOffset.Click
        Try
            m_objMachine.AddZeroOffset(cboMachineZeroOffsetAxis.SelectedValue, CDbl(txtInputMachineZeroOffset.Text))
            txtOutputMachineZeroOffset.Text = m_objMachine.GetZeroOffset(cboMachineZeroOffsetAxis.SelectedValue)
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub


    Private Sub cmdCalMachineZeroOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalMachineZeroOffset.Click
        Try
            m_objMachine.CalZeroOffset(cboMachineZeroOffsetAxis.SelectedValue, CDbl(txtInputMachineZeroOffset.Text))
            txtOutputMachineZeroOffset.Text = m_objMachine.GetZeroOffset(cboMachineZeroOffsetAxis.SelectedValue)
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub


    Private Sub cmdMachineDataUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMachineDataUnit.Click
        Try
            m_objMachine.SetDataUnit(cboMachineDataUnit.SelectedValue)
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
            m_objTools.AddCutterRCompOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdCutterRCompOffset.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

    Private Sub tulAddCutterRCompWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tulAddCutterRCompWearOffset.Click
        Try
            m_objTools.AddCutterRCompWearOffset(CInt(Me.tulToolNumber.Text), CDbl(Me.tulUpdCutterRCompWearOffset.Text))
            updateTools()
        Catch ex As Exception
            DisplayError("CTool", ex.Message)
        End Try
    End Sub

#Region "Optional Parameter"
    Private Sub cmdOptionalParameterBitGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOptionalParameterBitGet.Click
        Try
            Me.txtOptionalParameterBit.Text = m_objOptionalParameter.GetNCOptionalParameterBit(CInt(Me.txtOptionalParameterBitIndex.Text), CInt(Me.txtOptionalParameterBitNo.Text))
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdOptionalParameterWordGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOptionalParameterWordGet.Click
        Try
            txtOptionalParameterWord.Text = m_objOptionalParameter.GetNCOptionalParameterWord(CInt(Me.txtOptionalParameterWordIndex.Text))
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdOptionalParameterLongWordGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOptionalParameterLongWordGet.Click
        Try
            txtOptionalParameterLongWord.Text = m_objOptionalParameter.GetNCOptionalParameterLongWord(CInt(Me.txtOptionalParameterLongWordIndex.Text))
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub


    Private Sub cmdBitSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBitSet.Click
        Try
            m_objOptionalParameter.SetNCOptionalParameterBit(CInt(Me.txtOptionalParameterBitIndex.Text), CInt(Me.txtOptionalParameterBitNo.Text), CInt(txtBitInput.Text))
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdWordSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWordSet.Click
        Try
            m_objOptionalParameter.SetNCOptionalParameterWord(CInt(Me.txtOptionalParameterWordIndex.Text), CInt(txtWordInput.Text))
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdLongWordSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLongWordSet.Click
        Try
            m_objOptionalParameter.SetNCOptionalParameterLongWord(CInt(Me.txtOptionalParameterLongWordIndex.Text), CInt(txtLongWordInput.Text))
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdWordAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWordAdd.Click
        Try
            m_objOptionalParameter.AddNCOptionalParameterWord(CInt(Me.txtOptionalParameterWordIndex.Text), CInt(txtWordInput.Text))
        Catch ae As ApplicationException
            DisplayError("Optional Parameter", ae.Message)
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub

    Private Sub cmdLongWordAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLongWordAdd.Click
        Try
            m_objOptionalParameter.AddNCOptionalParameterLongWord(CInt(Me.txtOptionalParameterLongWordIndex.Text), CInt(txtLongWordInput.Text))
        Catch ex As Exception
            DisplayError("Optional Parameter", ex.Message)
        End Try
    End Sub
#End Region

#Region "PLC I/O"

    Private Sub btnGetIOLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetIOLabel.Click
        Try
            Dim objIOAddress As CIOAddress

            txtIOBitIndex.Text = ""
            txtIOBitNo.Text = ""
            txtIOBit.Text = ""
            txtIOWordIndex.Text = ""
            txtIOWord.Text = ""
            txtIOLongWordIndex.Text = ""
            txtIOLongWord.Text = ""

            objIOAddress = m_objIO.GetIO(txtIOLabel.Text)

            cboIOVariableTypes.SelectedIndex = (objIOAddress.IOType)

            Select Case objIOAddress.Size
                Case IOAddressSizeEnum.Bit
                    txtIOBitIndex.Text = objIOAddress.Address
                    txtIOBitNo.Text = objIOAddress.Bit
                    txtIOBit.Text = objIOAddress.Value

                Case IOAddressSizeEnum.Word
                    txtIOWordIndex.Text = objIOAddress.Address
                    txtIOWord.Text = objIOAddress.Value

                Case IOAddressSizeEnum.DWord
                    txtIOLongWordIndex.Text = objIOAddress.Address
                    txtIOLongWord.Text = objIOAddress.Value

                Case Else
                    DisplayError("I/O Variables", "Not found")


            End Select
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub

    Private Sub cmdIOGetBitByLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetBitByLabel.Click
        Try
            Dim objIOAddress As CIOAddress = New CIOAddress

            objIOAddress.Address = CInt(txtIOBitIndex.Text)
            objIOAddress.Bit = CInt(txtIOBitNo.Text)
            objIOAddress.IOType = cboIOVariableTypes.SelectedValue
            objIOAddress.Size = IOAddressSizeEnum.Bit

            txtIOBitLabel.Text = m_objIO.GetLabel(objIOAddress)
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub

    Private Sub cmdIOGetWordByLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetWordByLabel.Click
        Try
            Dim objIOAddress As CIOAddress = New CIOAddress

            objIOAddress.Address = CInt(txtIOWordIndex.Text)
            objIOAddress.Bit = 0
            objIOAddress.IOType = cboIOVariableTypes.SelectedValue
            objIOAddress.Size = IOAddressSizeEnum.Word

            txtIOWordLabel.Text = m_objIO.GetLabel(objIOAddress)
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub

    Private Sub cmdIOGetLongWordByLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetLongWordByLabel.Click
        Try
            Dim objIOAddress As CIOAddress = New CIOAddress

            objIOAddress.Address = CInt(txtIOLongWordIndex.Text)
            objIOAddress.Bit = 0
            objIOAddress.IOType = cboIOVariableTypes.SelectedValue
            objIOAddress.Size = IOAddressSizeEnum.DWord

            txtIOLongWordLabel.Text = m_objIO.GetLabel(objIOAddress)
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub

    Private Sub cmdIOGetBit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetBit.Click
        Try
            Me.txtIOBit.Text = m_objIO.GetBitIO(Me.cboIOVariableTypes.SelectedValue, CInt(Me.txtIOBitIndex.Text), CInt(Me.txtIOBitNo.Text))
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub
    Private Sub cmdIOGetWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetWord.Click
        Try
            Me.txtIOWord.Text = m_objIO.GetWordIO(Me.cboIOVariableTypes.SelectedValue, CInt(Me.txtIOWordIndex.Text))
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub
    Private Sub cmdIOGetLongWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetLongWord.Click
        Try
            Me.txtIOLongWord.Text = m_objIO.GetLongWordIO(Me.cboIOVariableTypes.SelectedValue, CInt(Me.txtIOLongWordIndex.Text))
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub



#Region "User Task I/O Variable"

    Private Sub btnGetUserTaskInputIOVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetUserTaskInputIOVariable.Click
        Try
            Me.txtUserTaskIOInputVariableValue.Text = m_objIO.GetUserTaskIOVariable(IOTypeEnum.Input, CInt(Me.txtUserTaskIOInputVariableIndex.Text))
        Catch ex As Exception
            DisplayError("User Task I/O Variables", ex.Message)
        End Try
    End Sub

    Private Sub btnGetProtectedUserTaskOutputVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetProtectedUserTaskOutputVariable.Click
        Try
            Me.txtGetProtectedUserTaskIOOutputVariableValue.Text = m_objIO.GetProtectedUserTaskOutputVariable(CInt(Me.txtGetProtectedUserTaskIOOutputVariableIndex.Text))
        Catch ex As Exception
            DisplayError("User Task I/O Variables", ex.Message)
        End Try
    End Sub

    Private Sub btnSetUserTaskOutputVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetUserTaskOutputVariable.Click
        Try
            Dim enValue As OnOffStateEnum
            If Me.cboSetUserTaskOutputVariable.SelectedValue = OnOffStateEnum.ON Then
                enValue = OnOffStateEnum.ON
            Else
                enValue = OnOffStateEnum.OFF
            End If

            m_objIO.SetUserTaskOutputVariable(CInt(Me.txtSetUserTaskIOOutputVariableIndex.Text), enValue)
        Catch ex As Exception
            DisplayError("User Task I/O Variables", ex.Message)
        End Try
    End Sub

    Private Sub btnGetUserTaskOutputIOVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetUserTaskOutputIOVariable.Click
        Try

            Me.txtUserTaskIOOutputVariableValue.Text = m_objIO.GetUserTaskIOVariable(IOTypeEnum.Output, CInt(Me.txtUserTaskIOOutputVariableIndex.Text))
        Catch ex As Exception
            DisplayError("User Task I/O Variables", ex.Message)
        End Try
    End Sub

    Private Sub btnSetProtectedUserTaskOutputVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetProtectedUserTaskOutputVariable.Click
        Try

            Dim enValue As OnOffStateEnum
            If Me.cboSetUserTaskOutputVariableProtected.SelectedValue = OnOffStateEnum.ON Then
                enValue = OnOffStateEnum.ON
            Else
                enValue = OnOffStateEnum.OFF
            End If

            m_objIO.SetProtectedUserTaskOutputVariable(CInt(Me.txtSetProtectedUserTaskIOOutputVariableIndex.Text), enValue)
        Catch ex As Exception
            DisplayError("User Task I/O Variables", ex.Message)
        End Try
    End Sub
#End Region
#End Region


#Region "Axis 2"
    Private Sub cmdAxis2DataUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAxis2DataUnit.Click
        Try
            m_objAxis2.SetDataUnit(Me.cboAxis2DataUnit.SelectedValue)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdUserParameterVariableLimitGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserParameterVariableLimitGet.Click
        Try
            Me.txtUserParameterLimit.Text = m_objAxis2.GetUserParameterVariableLimit(Me.cboUserParameterVariableLimitCoordinate.SelectedValue, Me.cboUserParameterVariableLimitAxis.SelectedValue)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub


    Private Sub cmdUserParameterVariableLimitSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserParameterVariableLimitSet.Click
        Try
            m_objAxis2.SetUserParameterVariableLimit(Me.cboUserParameterVariableLimitCoordinate.SelectedValue, Me.cboUserParameterVariableLimitAxis.SelectedValue, CDbl(Me.txtUserParameterLimitInput.Text))
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdUserParameterVariableLimitAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserParameterVariableLimitAdd.Click
        Try
            m_objAxis2.AddUserParameterVariableLimit(Me.cboUserParameterVariableLimitCoordinate.SelectedValue, Me.cboUserParameterVariableLimitAxis.SelectedValue, CDbl(Me.txtUserParameterLimitInput.Text))
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub
#End Region

#Region "Program 2 (G/M Code Macro)"
    Private Sub cmdGetProgramNameGCodeMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetProgramNameGCodeMod.Click
        Try
            txtProgramNameOutput.Text = m_objProgram.GetProgramGCodeMacro(CInt(txtGMCode.Text))
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub


    Private Sub cmdGetProgramNameMCodeCall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetProgramNameMCodeCall.Click
        Try
            txtProgramNameOutput.Text = m_objProgram.GetProgramMCodeMacro(CInt(txtGMCode.Text))
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub

    Private Sub cmdSetProgramNameGCodeMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetProgramNameGCodeMod.Click
        Try
            m_objProgram.SetProgramGCodeMacro(CInt(txtGMCode.Text), txtProgramNameInput.Text)
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub



    Private Sub cmdSetProgramNameMCodeCall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetProgramNameMCodeCall.Click
        Try
            m_objProgram.SetProgramMCodeMacro(CInt(txtGMCode.Text), txtProgramNameInput.Text)
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub
#End Region

#Region "Tools 2 - 1"
    Private Sub cmdToolID_DataUnit_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_DataUnit_Set.Click
        Try
            m_objToolID1.SetDataUnit(cboToolID_DataUnit.SelectedValue)
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
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolLifeRemaining_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolLifeRemaining_Set.Click
        Try
            m_objToolID1.SetToolLifeRemaining(CInt(txtToolID_PotNo.Text), CInt(txtToolID_ToolLifeRemainingValue.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LifeStatus_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LifeStatus_Set.Click
        Try
            m_objCmdATC2.SetToolLifeStatus(CInt(txtToolID_PotNo.Text), cboToolID_ToolLifeStatus.SelectedValue)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub


    Private Sub cmdToolID_ToolLifeMode_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolLifeMode_Set.Click
        Try
            m_objToolID1.SetMode(CInt(txtToolID_PotNo.Text), cboToolID_ToolLifeMode.SelectedValue)
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRCompOffset1_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompOffset1_Set.Click

        Try
            m_objToolID1.SetCutterRCompOffset1(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompOffset1Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub


    Private Sub cmdToolID_CutterRCompOffset1_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompOffset1_Add.Click

        Try
            m_objToolID1.AddCutterRCompOffset1(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompOffset1Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRCompOffset2_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompOffset2_Set.Click
        Try
            m_objToolID1.SetCutterRCompOffset2(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompOffset2Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRCompOffset2_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompOffset2_Add.Click
        Try
            m_objToolID1.AddCutterRCompOffset2(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompOffset2Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRCompOffset3_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompOffset3_Set.Click
        Try
            m_objToolID1.SetCutterRCompOffset3(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompOffset3Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRCompOffset3_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompOffset3_Add.Click
        Try
            m_objToolID1.AddCutterRCompOffset3(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompOffset3Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset1_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset1_Set.Click
        Try
            m_objToolID1.SetToolLengthOffset1(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset1Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset1_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset1_Add.Click
        Try
            m_objToolID1.AddToolLengthOffset1(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset1Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset1_Cal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset1_Cal.Click
        Try
            m_objToolID1.CalToolLengthOffset1(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset1Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset2_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset2_Set.Click
        Try
            m_objToolID1.SetToolLengthOffset2(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset2Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset2_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset2_Add.Click
        Try
            m_objToolID1.AddToolLengthOffset2(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset2Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset2_Cal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset2_Cal.Click
        Try
            m_objToolID1.CalToolLengthOffset2(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset2Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset3_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset3_Set.Click
        Try
            m_objToolID1.SetToolLengthOffset3(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset3Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset3_Cal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset3_Cal.Click
        Try
            m_objToolID1.CalToolLengthOffset3(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset3Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LengthOffset3_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthOffset3_Add.Click
        Try
            m_objToolID1.AddToolLengthOffset3(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_LengthOffset3Value.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolLengthWearOffset_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolLengthWearOffset_Set.Click
        Try
            m_objToolID1.SetToolLengthWearOffset(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_ToolLengthWearOffsetValue.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolLengthWearOffset_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolLengthWearOffset_Add.Click
        Try
            m_objToolID1.AddToolLengthWearOffset(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_ToolLengthWearOffsetValue.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRCompWearOffset_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompWearOffset_Set.Click
        Try
            m_objToolID1.SetCutterRCompWearOffset(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompWearOffsetValue.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRCompWearOffset_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRCompWearOffset_Add.Click
        Try
            m_objToolID1.AddCutterRCompWearOffset(CInt(txtToolID_PotNo.Text), CDbl(txtToolID_CutterRCompWearOffsetValue.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_LenghtOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LenghtOffset.Click

        Dim intFromPot As Integer
        Dim intToPot As Integer
        Dim arValues As ArrayList = Nothing


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
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterROffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterROffset.Click

        Dim intFromPot As Integer
        Dim intToPot As Integer
        Dim arValues As ArrayList = Nothing


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
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub


    Private Sub cmdToolID_LengthWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_LengthWearOffset.Click
        Dim intFromPot As Integer
        Dim intToPot As Integer
        Dim arValues As ArrayList


        Try


            lstToolID_Offset.DataSource = Nothing

            lstToolID_Offset.Items.Clear()

            intFromPot = CInt(txtToolID_FromPot.Text)
            intToPot = CInt(txtToolID_ToPot.Text)


            arValues = m_objToolID1.GetToolLengthWearOffset(intFromPot, intToPot)

            lstToolID_Offset.DataSource = arValues
        Catch ex As Exception
            DisplayError("Tools 2 - 1", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CutterRWearOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CutterRWearOffset.Click
        Dim intFromPot As Integer
        Dim intToPot As Integer
        Dim arValues As ArrayList


        Try


            lstToolID_Offset.DataSource = Nothing

            lstToolID_Offset.Items.Clear()

            intFromPot = CInt(txtToolID_FromPot.Text)
            intToPot = CInt(txtToolID_ToPot.Text)


            arValues = m_objToolID1.GetCutterRCompWearOffset(intFromPot, intToPot)

            lstToolID_Offset.DataSource = arValues
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
            enATCType = m_objAtc.GetATCType()
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
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_DataUnit_2_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_DataUnit_2_Set.Click
        Try
            m_objToolID2.SetDataUnit(cboToolID_DataUnit_2.SelectedValue)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_CarrierStatus_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_CarrierStatus_Set.Click
        Try
            m_objCmdATC2.SetToolCarrierStatus(CInt(txtToolID_PotNo_2.Text), cboToolID_CarrierStatus.SelectedValue)
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
            enATCType = m_objAtc.GetATCType()

            intGroupNo = CInt(txtToolID_GroupNoValue.Text)
            intSerialNo = CInt(txtToolID_SerialNoValue.Text)
            blnDummyTool = chkToolID_DummyTool.Checked
            strToolName = txtToolID_ToolNameValue.Text

            If enATCType = ATCTypeEnum.RandomAddress Then
                m_objCmdATC2.RegisterToolPot(CInt(txtToolID_PotNo_2.Text), CInt(txtToolID_RATC_PotNoValue.Text), intGroupNo, intSerialNo, blnDummyTool, strToolName)
            Else
                m_objCmdATC2.RegisterToolPot(CInt(txtToolID_PotNo_2.Text), intGroupNo, intSerialNo, blnDummyTool, strToolName)
            End If
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub


    Private Sub cmdToolID_UnRegisterToolPot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_UnRegisterToolPot.Click
        Dim enATCType As Okuma.CMDATAPI.Enumerations.ATCTypeEnum
        Try
            enATCType = m_objAtc.GetATCType()
            If enATCType = ATCTypeEnum.RandomAddress Then
                m_objCmdATC2.UnRegisterToolPot(CInt(Me.txtToolID_RATC_PotNoValue.Text), CInt(txtToolID_PotNo_2.Text), True)
            Else
                m_objCmdATC2.UnRegisterToolPot(CInt(Me.txtToolID_RATC_PotNoValue.Text), CInt(txtToolID_PotNo_2.Text), False)
            End If
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_PotInUse_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_PotInUse_Set.Click
        Try
            Me.m_objToolID2.SetToolInUse(CInt(txtToolID_PotNo_2.Text), cboYesNo_PotInUse.SelectedValue)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolKind_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolKind_Set.Click
        Try
            m_objCmdATC2.SetToolKind(CInt(txtToolID_PotNo_2.Text), cboToolID_ToolKind.SelectedValue)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_AdjustmentTool_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_AdjustmentTool_Set.Click
        Try
            Me.m_objToolID2.SetAdjustmentTool(CInt(txtToolID_PotNo_2.Text), cboYesNo_AdjustmentTool.SelectedValue)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_StandardTool_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_StandardTool_Set.Click
        Try
            Me.m_objToolID2.SetStandardTool(CInt(txtToolID_PotNo_2.Text), cboYesNo_StandardTool.SelectedValue)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolType_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolType_Set.Click
        Try
            Me.m_objToolID2.SetToolType(CInt(txtToolID_PotNo_2.Text), cboToolID_ToolType.SelectedValue)
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolAngle_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolAngle_Set.Click
        Try
            Me.m_objToolID2.SetToolAngle(CInt(txtToolID_PotNo_2.Text), CDbl(txtToolID_ToolAngleValue.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolDiameter_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolDiameter_Set.Click
        Try
            Me.m_objToolID2.SetToolDiameter(CInt(txtToolID_PotNo_2.Text), CDbl(txtToolID_ToolDiameterValue.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolNoseDiameter_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolNoseDiameter_Set.Click
        Try
            Me.m_objToolID2.SetToolNoseDiameter(CInt(txtToolID_PotNo_2.Text), CDbl(txtToolID_ToolNoseDiameterValue.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolDiameter_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolDiameter_Add.Click
        Try
            Me.m_objToolID2.AddToolDiameter(CInt(txtToolID_PotNo_2.Text), CDbl(txtToolID_ToolDiameterValue.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolAngle_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolAngle_Add.Click
        Try
            Me.m_objToolID2.AddToolAngle(CInt(txtToolID_PotNo_2.Text), CDbl(txtToolID_ToolAngleValue.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub

    Private Sub cmdToolID_ToolNoseDiameter_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToolID_ToolNoseDiameter_Add.Click
        Try
            Me.m_objToolID2.AddToolNoseDiameter(CInt(txtToolID_PotNo_2.Text), CDbl(txtToolID_ToolNoseDiameterValue.Text))
        Catch ex As Exception
            DisplayError("Tools 2 - 2", ex.Message)
        End Try
    End Sub
#End Region

#Region "Current Alarm"
    Private Sub cmdCurrentAlarm_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCurrentAlarm_Update.Click
        Dim objCurrentAlarm As CCurrentAlarm
        Try
            objCurrentAlarm = m_objMachine.GetCurrentAlarm()

            txtCurrentAlarm_AlarmNumber.Text = objCurrentAlarm.AlarmNumber()
            txtCurrentAlarm_ObjectNumber.Text = objCurrentAlarm.ObjectNumber
            txtCurrentAlarm_ObjectMessage.Text = objCurrentAlarm.ObjectMessage()
            txtCurrentAlarm_AlarmMessage.Text = objCurrentAlarm.AlarmMessage()
            txtCurrentAlarm_AlarmCharacterString.Text = objCurrentAlarm.AlarmCharacterString()
            txtCurrentAlarm_AlarmCode.Text = objCurrentAlarm.AlarmCode()
            txtCurrentAlarm_AlarmLevel.Text = System.Enum.GetName(GetType(OSPAlarmLevelEnum), objCurrentAlarm.AlarmLevel())
        Catch ex As Exception
            DisplayError("Current Alarm", ex.Message)
        End Try
    End Sub
#End Region


    ''#If ____RENISHAW_API____ Then

    ''#Region "BETA - Renishaw_1"
    Private Sub btnSelectSubProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectSubProgram.Click
        Try

            Dim m_objProgram As Okuma.CMCMDAPI.CommandAPI.CProgram
            m_objProgram = New Okuma.CMCMDAPI.CommandAPI.CProgram

            m_objProgram.SelectSubProgram(txtSelectSubProgram.Text)
        Catch ex As Exception
            DisplayError("Probe - SelectSubProgram", ex.Message)
        End Try
    End Sub

    Private Sub btnSelectSubProgram2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectSubProgram2.Click
        Try

            Dim m_objProgram As Okuma.CMCMDAPI.CommandAPI.CProgram
            m_objProgram = New Okuma.CMCMDAPI.CommandAPI.CProgram

            m_objProgram.SelectSubProgram(txtSelectSubProgram.Text, Okuma.CMCMDAPI.Enumerations.ReadModeEnum.A)
        Catch ex As Exception
            DisplayError("Probe - SelectSubProgram 2", ex.Message)
        End Try
    End Sub

    Private Sub btnProbeUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProbeUpdate.Click
        Dim objProbe As CProbe
        objProbe = New CProbe

        txtProbePositionX.Text = ""
        txtProbePositionZ.Text = ""
        txtProbePositionY.Text = ""
        txtProbePositionA.Text = ""
        txtProbePositionB.Text = ""
        txtProbePositionC.Text = ""

        On Error GoTo ProbeError

        txtProbePositionX.Text = objProbe.GetProbeSensorPosition(AxisIndexEnum.X_Axis).ToString()
        txtProbePositionZ.Text = objProbe.GetProbeSensorPosition(AxisIndexEnum.Y_Axis).ToString()
        txtProbePositionY.Text = objProbe.GetProbeSensorPosition(AxisIndexEnum.Z_Axis).ToString()
        txtProbePositionA.Text = objProbe.GetProbeSensorPosition(AxisIndexEnum.Fourth_Axis).ToString()
        txtProbePositionB.Text = objProbe.GetProbeSensorPosition(AxisIndexEnum.Fifth_Axis).ToString()
        txtProbePositionC.Text = objProbe.GetProbeSensorPosition(AxisIndexEnum.Sixth_Axis).ToString()

ProbeError:
        Resume Next
    End Sub


    Private Sub btnProbeSubProgramStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProbeSubProgramStatus.Click
        Try

            Dim objProbe As CProbe
            objProbe = New CProbe

            txtProbeSubProgramStatus.Text = objProbe.GetProbeSubProgramStatus().ToString()
        Catch ex As Exception
            DisplayError("Probe - ProbeSubProgramStatus", ex.Message)
        End Try
    End Sub

    Private Sub btnGetTouchProbeSignal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetTouchProbeSignal.Click
        Try

            Dim objProbe As CProbe
            objProbe = New CProbe

            txtTouchProbeSignal.Text = objProbe.GetTouchProbeSignal().ToString()
        Catch ex As Exception
            DisplayError("Probe - GetTouchProbeSignal", ex.Message)
        End Try
    End Sub



    ''#End Region

    ''#Region "BETA - Renishaw_2"
    Private Sub btnGetRotatyAxisName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetRotatyAxisName.Click
        Try
            Me.txtRotaryAxisName.Text = Me.m_objAxis2.GetRotaryAxisName(Me.cboRotaryAxes.SelectedValue)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub


    Private Sub btnRotaryAxisISO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotaryAxisISO.Click
        Try
            Me.txtRotaryAxisISO.Text = Me.m_objAxis2.IsISORotaryAxis(Me.cboRotaryAxes.SelectedValue).ToString()
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub


    Private Sub btnRotaryAxisSetupPosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotaryAxisSetupPosition.Click
        Try
            Me.txtRotaryAxisSetupPosition.Text = Me.m_objAxis2.GetRotaryAxisSetupPosition(Me.cboRotaryAxes.SelectedValue).ToString()
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub btnRotaryAxisSetupStructure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotaryAxisSetupStructure.Click
        Try
            Me.txtRotaryAxisSetupStructure.Text = Me.m_objAxis2.GetRotaryAxisSetupStructure(Me.cboRotaryAxes.SelectedValue).ToString()
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub btnGetRotationCenterSetupPosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetRotationCenterSetupPosition.Click
        Try
            Me.txtRotationCenterSetupPosition.Text = Me.m_objAxis2.GetRotationCenterSetupPosition(Me.cboRotationCenters.SelectedValue, Me.cboRotaryAxisStructure.SelectedValue, Me.cboLinearAxisIndex.SelectedValue).ToString()
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub btnGetShiftAmoutSC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetShiftAmoutSC.Click
        Try
            Me.txtShiftAmountSC.Text = Me.m_objAxis2.GetShiftAmountSlopeCoord(Me.cboSlopeCoordAxisIndex.SelectedValue).ToString()
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub btnGetRotateAmoutSC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetRotateAmoutSC.Click
        Try
            Me.txtRotateAmountSC.Text = Me.m_objAxis2.GetRotateAmountSlopeCoord(CInt(txtColumnMatrix.Text), CInt(txtRowMatrix.Text)).ToString()
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub btnGetRotateAmoutISC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetRotateAmoutISC.Click
        Try
            Me.txtRotateAmountISC.Text = Me.m_objAxis2.GetRotateAmountInverseSlopeCoord(CInt(txtColumnMatrix.Text), CInt(txtRowMatrix.Text)).ToString()
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub btnGetShiftAmoutISC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetShiftAmoutISC.Click
        Try
            Me.txtShiftAmountISC.Text = m_objAxis2.GetShiftAmountInverseSlopeCoord(Me.cboSlopeCoordAxisIndex.SelectedValue).ToString()
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub
    ''#End Region

    ''#Region "BETA - Renishaw_3"
    Private Sub btnCancelSubProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelSubProgram.Click
        Try
            Dim strSubProgramName As String
            strSubProgramName = txtSelectSubProgram.Text.Trim()
            m_objProgram.CancelSubProgram(strSubProgramName)
        Catch ex As Exception
            DisplayError("Program", ex.Message)
        End Try
    End Sub
    ''#End Region

    ''#Region "BETA - Renishaw_4"
    Private Sub btnGetSlopeConverting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetSlopeConverting.Click
        Try
            Me.txtSlopeConverting.Text = Me.m_objAxis2.GetSlopeConverting().ToString()
        Catch ae As ApplicationException
            DisplayError("Axis 2", ae.Message)
        Catch ex As Exception
            DisplayError("Axis 2", ex.Message)
        End Try
    End Sub


    Private Sub btnGetActiveProgramFilePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetActiveProgramFilePath.Click
        Try

            txtActiveProgramFilePath.Text = m_objProgram.GetCurrentActiveProgramFilePath()
        Catch ex As Exception
            DisplayError("Program", ex.Message)
        End Try
    End Sub
    ''#End Region


    ''#End If

#Region "P300 Tools"

#Region "Tool Offset"
    Private Sub btnGetToolOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300GetToolOffset.Click
        Try
            Dim intToolNo As Integer
            Dim enCompensation As ToolCompensationEnum
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enCompensation = cboP300ToolCompensation.SelectedItem()

            Me.txtP300ToolOffset.Text = m_objTools.GetToolOffset(intToolNo, enCompensation)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
    Private Sub btnP300SetToolOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300SetToolOffset.Click
        Try
            Dim intToolNo As Integer
            Dim enCompensation As ToolCompensationEnum
            Dim dblValue As Double
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enCompensation = cboP300ToolCompensation.SelectedItem()
            dblValue = CDbl(txtP300ToolOffsetSetValue.Text)

            m_objTools.SetToolOffset(intToolNo, enCompensation, dblValue)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
    Private Sub btnP300CalToolOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300CalToolOffset.Click
        Try
            Dim intToolNo As Integer
            Dim enCompensation As ToolCompensationEnum
            Dim dblValue As Double
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enCompensation = cboP300ToolCompensation.SelectedItem()
            dblValue = CDbl(txtP300ToolOffsetSetValue.Text)

            m_objTools.CalToolOffset(intToolNo, enCompensation, dblValue)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
    Private Sub btnP300AddToolOffset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300AddToolOffset.Click
        Try
            Dim intToolNo As Integer
            Dim enCompensation As ToolCompensationEnum
            Dim dblValue As Double
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enCompensation = cboP300ToolCompensation.SelectedItem()
            dblValue = CDbl(txtP300ToolOffsetSetValue.Text)

            m_objTools.AddToolOffset(intToolNo, enCompensation, dblValue)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
#End Region

#Region "Nose Radius Compensation"
    Private Sub btnP300AddNoseRComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300AddNoseRComp.Click
        Try
            Dim intToolNo As Integer
            Dim enCompensation As ToolCompensationEnum
            Dim dblValue As Double
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enCompensation = cboP300ToolCompensation.SelectedItem()
            dblValue = CDbl(txtP300NoseRCompSetValue.Text)

            m_objTools.AddCutterROffset(intToolNo, enCompensation, dblValue)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub

    Private Sub btnP300SetNoseRComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300SetNoseRComp.Click
        Try
            Dim intToolNo As Integer
            Dim enCompensation As ToolCompensationEnum
            Dim dblValue As Double
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enCompensation = cboP300ToolCompensation.SelectedItem()
            dblValue = CDbl(txtP300NoseRCompSetValue.Text)

            m_objTools.SetCutterROffset(intToolNo, enCompensation, dblValue)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub

    Private Sub btnP300GetNoseRComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300GetNoseRComp.Click
        Try
            Dim intToolNo As Integer
            Dim enCompensation As ToolCompensationEnum
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enCompensation = cboP300ToolCompensation.SelectedItem()

            Me.txtP300NoseRComp.Text = m_objTools.GetCutterROffset(intToolNo, enCompensation)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
#End Region

#Region "Cutter Radius Compensation Offset"
    Private Sub btnP300GetNoseRCompWear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300GetNoseRCompWear.Click
        Try
            Dim intToolNo As Integer
            Dim enCompensation As ToolCompensationEnum
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enCompensation = cboP300ToolCompensation.SelectedItem()

            Me.txtP300NoseRCompWear.Text = m_objTools.GetCutterRWearOffset(intToolNo, enCompensation)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
    Private Sub btnP300AddNoseRCompWear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300AddNoseRCompWear.Click
        Try
            Dim intToolNo As Integer
            Dim enCompensation As ToolCompensationEnum
            Dim dblValue As Double
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enCompensation = cboP300ToolCompensation.SelectedItem()
            dblValue = CDbl(txtP300NoseRCompWearSetValue.Text)

            m_objTools.AddCutterRWearOffset(intToolNo, enCompensation, dblValue)

        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
    Private Sub btnP300CalNoseRCompWear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300CalNoseRCompWear.Click
        Try
            Dim intToolNo As Integer
            Dim enCompensation As ToolCompensationEnum
            Dim dblValue As Double
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enCompensation = cboP300ToolCompensation.SelectedItem()
            dblValue = CDbl(txtP300ToolOffsetSetValue.Text)

            m_objTools.CalToolWearOffset(intToolNo, enCompensation, dblValue)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
    Private Sub btnP300SetNoseRCompWear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300SetNoseRCompWear.Click
        Try
            Dim intToolNo As Integer
            Dim enCompensation As ToolCompensationEnum
            Dim dblValue As Double
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enCompensation = cboP300ToolCompensation.SelectedItem()
            dblValue = CDbl(txtP300NoseRCompWearSetValue.Text)

            m_objTools.SetCutterRWearOffset(intToolNo, enCompensation, dblValue)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub

#End Region

#Region "Tool Length Wear Offset"
    Private Sub btnP300AddToolWear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300AddToolWear.Click
        Try
            Dim intToolNo As Integer
            Dim enCompensation As ToolCompensationEnum
            Dim dblValue As Double
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enCompensation = cboP300ToolCompensation.SelectedItem()
            dblValue = CDbl(txtP300ToolWearSetValue.Text)

            m_objTools.AddToolWearOffset(intToolNo, enCompensation, dblValue)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
    Private Sub btnP300SetToolWear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300SetToolWear.Click
        Try
            Dim intToolNo As Integer
            Dim enCompensation As ToolCompensationEnum
            Dim dblValue As Double
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enCompensation = cboP300ToolCompensation.SelectedItem()
            dblValue = CDbl(txtP300ToolWearSetValue.Text)

            m_objTools.SetToolWearOffset(intToolNo, enCompensation, dblValue)

        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
    Private Sub btnP300GetToolWear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300GetToolWear.Click
        Try
            Dim intToolNo As Integer
            Dim enCompensation As ToolCompensationEnum
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enCompensation = cboP300ToolCompensation.SelectedItem()
            txtP300ToolWear.Text = m_objTools.GetToolWearOffset(intToolNo, enCompensation)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
#End Region

#Region "Tool Life - SET"

    Private Sub btnP300GetToolLifeSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300GetToolLifeSet.Click
        Try
            Dim intToolNo As Integer
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            txtP300ToolLifeSet.Text = m_objTools.GetToolLife(intToolNo)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub

    Private Sub btnP300SetToolLifeSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300SetToolLifeSet.Click
        Try
            Dim intToolNo As Integer
            Dim intValue As Integer
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            intValue = CInt(txtP300ToolLifeSetValue.Text)

            m_objTools.SetToolLife(intToolNo, intValue)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub

#End Region

#Region "Tool Life - LEFT"

    Private Sub btnP300SetToolLifeLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300SetToolLifeLeft.Click
        Try
            Dim intToolNo As Integer
            Dim intValue As Integer
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            intValue = CInt(txtP300ToolLifeLeftValue.Text)

            m_objTools.SetToolLifeRemaining(intToolNo, intValue)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
    Private Sub btnP300GetToolLifeLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300GetToolLifeLeft.Click
        Try
            Dim intToolNo As Integer
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            txtP300ToolLifeLeft.Text = m_objTools.GetToolLifeRemaining(intToolNo)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try

    End Sub
#End Region

#Region "Tool Life - Status"

    Private Sub btnP300GetToolLifeStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300GetToolLifeStatus.Click
        Try
            Dim intToolNo As Integer
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            txtP300ToolLifeStatus.Text = m_objTools.GetStatus(intToolNo)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub


    Private Sub btnP300SetToolLifeStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300SetToolLifeStatus.Click
        Try
            Dim intToolNo As Integer
            Dim enToolLifeStatus As Okuma.CMDATAPI.Enumerations.ToolLifeStatusEnum

            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            enToolLifeStatus = cboP300ToolLifeStatus.SelectedValue

            m_objTools.SetStatus(intToolNo, enToolLifeStatus)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
#End Region

#Region "Tool Group No."
    Private Sub btnP300SetToolGroupNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300SetToolGroupNo.Click

        Try
            Dim intToolNo As Integer
            Dim intValue As Integer
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            intValue = CInt(txtP300ToolGroupNoValue.Text)
            m_objTools.SetGroupNo(intToolNo, intValue)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try

    End Sub
    Private Sub btnP300GetToolGroupNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300GetToolGroupNo.Click
        Try
            Dim intToolNo As Integer
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            txtP300ToolGroupNo.Text = m_objTools.GetGroupNo(intToolNo)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
#End Region


#Region "P300 Tools"

    Private Sub btnP300ToolSetDataUnit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300ToolSetDataUnit.Click
        m_objTools.SetDataUnit(cboP300ToolsDataUnit.SelectedItem)
    End Sub

    Private Sub btnP300ToolUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300ToolUpdate.Click
        On Error GoTo P300Tool

        Dim strValues As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim intToolNo As Integer
        Dim intGroupNo As Integer
        Dim strValue As String = ""
        Dim intCount As Integer


        intGroupNo = CInt(txtP300GroupNumber.Text)
        intToolNo = CInt(txtP300ToolNumber.Text)


        strValue = strValue & String.Format("Current Tool: {0}" & vbCrLf, m_objTools.GetCurrentToolNumber().ToString())


        strValue = strValue & strValues.ToString


        Me.txtP300ToolsUpdate.Text = strValue

        Exit Sub
P300Tool:
        DisplayError("OSP-P300 Tools", Err.Description)
        Resume Next
    End Sub
#End Region
#End Region

#Region "P300 Command API - CATC"


    Private Sub btnRegisterNextTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttachNextTool.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Dim intToolNo As Integer

        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC

            intToolNo = CInt(txtP300ATCToolNo.Text)
            objcatc.SetNextTool(intToolNo)
        Catch ex As Exception
            DisplayError("P300 CATC", ex.Message)
        End Try
    End Sub

    Private Sub btnP300DeleteTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300DeleteTool.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Dim intToolNo As Integer
        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC
            intToolNo = CInt(txtP300ATCToolNo.Text)
            objcatc.DeleteTool(intToolNo)
        Catch ex As Exception
            DisplayError("P300 CATC", ex.Message)
        End Try
    End Sub
    Private Sub btnP300UnregisterTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300UnregisterTool.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Dim intPotNo As Integer

        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC

            intPotNo = CInt(txtP300ATCPotNo.Text)

            objcatc.UnRegisterToolPot(intPotNo)
        Catch ex As Exception
            DisplayError("P300 CATC", ex.Message)
        End Try
    End Sub

    Private Sub btbP300RegisterTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btbP300RegisterTool.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Dim intToolNo As Integer
        Dim intPotNo As Integer
        Dim enToolKind As ToolKind2Enum
        Dim enDiameterKind As DiameterKindEnum
        Dim enWeightKind As WeightKindEnum
        Dim enHeightKind As HeightKindEnum
        Dim blnManualAttachmentToolATCType As Boolean
        Dim intMaxToolSpeed As Integer
        Dim blnThroughCoolantToolType As Boolean

        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC

            intToolNo = CInt(txtP300ATCToolNo.Text)
            intPotNo = CInt(txtP300ATCPotNo.Text)
            enDiameterKind = cboP300DiameterKind.SelectedValue
            enToolKind = cboP300ToolKind2.SelectedValue
            enWeightKind = cboP300WeightKind.SelectedValue
            enHeightKind = cboP300HeightKind.SelectedValue
            blnManualAttachmentToolATCType = chkP300ManualAttachmentToolATCType.Checked
            intMaxToolSpeed = CInt(txtP300MaxToolSpeed.Text)
            blnThroughCoolantToolType = chkP300ThroughCoolantToolType.Checked

            objcatc.RegisterTool(intToolNo, intPotNo, enToolKind, enDiameterKind, enWeightKind, enHeightKind, blnThroughCoolantToolType, intMaxToolSpeed, blnManualAttachmentToolATCType)

        Catch ex As Exception
            DisplayError("P300 CATC", ex.Message)
        End Try
    End Sub
#End Region


    Private Sub btnP300AttachActualTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300AttachActualTool.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Dim intToolNo As Integer

        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC

            intToolNo = CInt(txtP300ATCToolNo.Text)

            objcatc.SetActualTool(intToolNo)
        Catch ex As Exception
            DisplayError("P300 CATC", ex.Message)
        End Try
    End Sub

    Private Sub btnP300DetachTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Dim intPotNo As Integer

        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC

            intPotNo = CInt(txtP300ATCPotNo.Text)

            objcatc.UnRegisterToolPot(intPotNo)
        Catch ex As Exception
            DisplayError("P300 CATC", ex.Message)
        End Try
    End Sub

    Private Sub btnAttachTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttachTool.Click
        Dim objcatc As Okuma.CMCMDAPI.CommandAPI.CATC
        Dim intPotNo As Integer
        Dim intToolNo As Integer

        Try
            objcatc = New Okuma.CMCMDAPI.CommandAPI.CATC

            intPotNo = CInt(txtP300ATCPotNo.Text)
            intToolNo = CInt(txtP300ATCToolNo.Text)

            objcatc.AttachTool(intToolNo, intPotNo)
        Catch ex As Exception
            DisplayError("P300 CATC", ex.Message)
        End Try
    End Sub

    Private Sub btnP300GetToolType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300GetToolType.Click
        Try
            Dim intToolNo As Integer
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            Me.txtP300ToolType.Text = m_objTools.GetToolType(intToolNo)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub

    Private Sub btnP300SetToolMaxSpeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300SetToolMaxSpeed.Click
        Try
            Dim intToolNo As Integer
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            Me.txtP300ToolMaxSpeed.Text = m_objTools.GetToolMaxSpeed(intToolNo)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub
    Private Sub btnP300GetToolMaxSpeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300GetToolMaxSpeed.Click
        Try
            Dim intToolNo As Integer
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            m_objTools.SetToolMaxSpeed(intToolNo, CInt(txtP300ToolMaxSpeedValue.Text))
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub

#Region "Optional Commnon Variable"

    Private Sub btnGetAllOpCV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetAllOpCV.Click
        Dim dblValues As Double()
        Dim dblValue As Double

        Try
            Me.txtOpCVOutput.Text = ""
            dblValues = m_objVariables.GetOptionCommonVariableValues(CInt(txtOpCVIndex1.Text), CInt(txtOpCVIndex2.Text))
            For Each dblValue In dblValues
                Me.txtOpCVOutput.Text += dblValue & vbCrLf
            Next
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub

    Private Sub btnGetOpCV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetOpCV.Click
        Try
            txtOpCV.Text = m_objVariables.GetOptionCommonVariableValue(CInt(txtOpCVIndex.Text))

            Me.txtOpCVMax.Text = m_objVariables.GetOptionCommonVariableCount()
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub

    Private Sub btnSetOpCV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetOpCV.Click
        Try
            m_objVariables.SetOptionCommonVariableValue(CInt(txtOpCVIndex.Text), CDbl(Me.txtOpCVValue.Text))
            txtOpCV.Text = m_objVariables.GetOptionCommonVariableValue(CInt(txtOpCVIndex.Text))
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub

    Private Sub btnAddOpCV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddOpCV.Click
        Try
            m_objVariables.AddOptionCommonVariableValue(CInt(txtOpCVIndex.Text), CDbl(Me.txtOpCVValue.Text))
            txtOpCV.Text = m_objVariables.GetOptionCommonVariableValue(CInt(txtOpCVIndex.Text))
        Catch ex As Exception
            DisplayError("CVariable", ex.Message)
        End Try
    End Sub

#End Region



    Private Sub btnGetHomePositions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetHomePosition.Click

        Try
            txtHomePosition.Text = m_objAxis2.GetHomePosition(CInt(txtHomePositionIndex.Text), cboHomePositionAxis.SelectedIndex)
            txtHomePositionMovementOrder.Text = m_objAxis2.GetHomePositionMovementOrder(CInt(txtHomePositionIndex.Text), cboHomePositionAxis.SelectedIndex)

            txtHomePositionMax.Text = m_objAxis2.GetMaxHomePositions()
        Catch ex As Exception
            DisplayError("OSP-P300 Axis 2", ex.Message)
        End Try

    End Sub


    Private Sub btnGetHiCutProFeedrateUpperLimit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetHiCutProFeedrateUpperLimit.Click

        Try
            txtHiCutProFeedrateUpperLimit.Text = m_objAxis2.GetHiCutProFeedrateUpperLimit()
        Catch ex As Exception
            DisplayError("OSP-P300 Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub btnGetHiCutProMachiningTolerance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetHiCutProMachiningTolerance.Click
        Try
            txtHiCutProMachiningTolerance.Text = m_objAxis2.GetHiCutProMachiningTolerance()
        Catch ex As Exception
            DisplayError("OSP-P300 Axis 2", ex.Message)
        End Try
    End Sub

    Private Sub btnP300GetToolName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300GetToolName.Click
        Try
            Dim intToolNo As Integer
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            Me.txtP300ToolName.Text = m_objTools.GetToolName(intToolNo)
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub

    Private Sub btnP300SetToolName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnP300SetToolName.Click
        Try
            Dim intToolNo As Integer
            intToolNo = CInt(Me.txtP300ToolNumber.Text)
            m_objTools.SetToolName(intToolNo, txtP300ToolNameValue.Text.Trim())
        Catch ex As Exception
            DisplayError("OSP-P300 Tools", ex.Message)
        End Try
    End Sub

#Region "Hour Meter Count"

    Private Sub btnHourMeterCountGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHourMeterCountGet.Click
        GetHourMeterCount()
    End Sub

    Private Sub btnHourMeterCountSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHourMeterCountSet.Click
        SetHourMeterCount()
        GetHourMeterCount()
    End Sub

    Private Sub btnHourMeterCountAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHourMeterCountAdd.Click
        AddHourMeterCount()
        GetHourMeterCount()
    End Sub

    Private Function GetHourMeterCount() As Integer
        Try
            txtHourMeterCount.Text = m_objMachine.GetHourMeterCount(cboHourMeterCount.SelectedValue)
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Function

    Private Function SetHourMeterCount() As Integer
        Try
            m_objMachine.SetHourMeterCount(cboHourMeterCount.SelectedValue, CInt(txtHourMeterCountValue.Text))
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Function


    Private Function AddHourMeterCount() As Integer
        Try
            m_objMachine.AddHourMeterCount(cboHourMeterCount.SelectedValue, CInt(txtHourMeterCountValue.Text))
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Function
#End Region





#Region "Hour Meter Set"
    Private Sub btnHourMeterCountSetGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHourMeterCountSetGet.Click
        GetHourMeterSet()

    End Sub

    Private Sub btnHourMeterCountSetSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHourMeterCountSetSet.Click
        SetHourMeterSet()
        GetHourMeterSet()
    End Sub

    Private Sub btnHourMeterCountSetAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHourMeterCountSetAdd.Click
        AddHourMeterSet()
        GetHourMeterSet()
    End Sub


    Private Function GetHourMeterSet() As Integer
        Try
            txtHourMeterCountSet.Text = m_objMachine.GetHourMeterSet(cboHourMeterCountSet.SelectedValue)
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Function

    Private Function SetHourMeterSet() As Integer
        Try
            m_objMachine.SetHourMeterSet(cboHourMeterCountSet.SelectedValue, CInt(txtHourMeterCountSetValue.Text))
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Function


    Private Function AddHourMeterSet() As Integer
        Try
            m_objMachine.AddHourMeterSet(cboHourMeterCountSet.SelectedValue, CInt(txtHourMeterCountSetValue.Text))
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Function
#End Region

#Region " Logging Service"
    Private Sub btnDisplayLogRecords_Click(sender As System.Object, e As System.EventArgs) Handles btnDisplayLogRecords.Click
        Dim lstRecords As Generic.List(Of Okuma.Api.LogService.Data.CLogRecord)
        Dim objApiLog As Okuma.ApiLog2.CApiLog
        objApiLog = New Okuma.ApiLog2.CApiLog

        Dim strAppName As String
        Dim strClassName As String
        Dim strMethodName As String
        Dim strParameters As String
        Dim strMessage As String
        Dim enLoggingLevel As Okuma.ApiLog2.LoggingLevelEnum = Okuma.ApiLog2.LoggingLevelEnum.logAll

        Dim dtStartDate As Date
        Dim dtEnddate As Date

        dtStartDate = dtpStartingDate.Value
        dtEnddate = dtpEndingDate.Value
        strAppName = txtLogAppName.Text.Trim()
        strClassName = txtLogClassName.Text.Trim()
        strMethodName = txtLogFunctionName.Text.Trim()
        strParameters = txtLogIOParameters.Text.Trim()
        strMessage = txtLogMessage.Text.Trim()
        enLoggingLevel = cboLoggingLevel.SelectedItem


        lstRecords = objApiLog.GetLogs(dtStartDate, dtEnddate, strAppName, strClassName, strMethodName, strParameters, strMessage, enLoggingLevel)
        dgvLogging.DataSource = lstRecords


    End Sub


    Private Sub SetLoggingLevelAll()
        m_objAxis.SetLoggingLevelToAll()
        m_objSpindle.SetLoggingLevelToAll()
        m_objProgram.SetLoggingLevelToAll()
        m_objTools.SetLoggingLevelToAll()
        m_objWorkPiece.SetLoggingLevelToAll()
        m_objSpec.SetLoggingLevelToAll()
        m_objIO.SetLoggingLevelToAll()
        m_objVariables.SetLoggingLevelToAll()

        m_objOperationHistory.SetLoggingLevelToAll()
        m_objMachiningReport.SetLoggingLevelToAll()
        m_objOperatingReport.SetLoggingLevelToAll()
        m_objAlarmHistory.SetLoggingLevelToAll()
        m_objOperatingHistory.SetLoggingLevelToAll()

        m_objMachine.SetLoggingLevelToAll()
    End Sub

    Private Sub SetLoggingLevelGet()
        m_objAxis.SetLoggingLevelToGet()
        m_objSpindle.SetLoggingLevelToGet()
        m_objProgram.SetLoggingLevelToGet()
        m_objTools.SetLoggingLevelToGet()
        m_objWorkPiece.SetLoggingLevelToGet()
        m_objSpec.SetLoggingLevelToGet()
        m_objIO.SetLoggingLevelToGet()
        m_objVariables.SetLoggingLevelToGet()


        m_objOperationHistory.SetLoggingLevelToGet()
        m_objMachiningReport.SetLoggingLevelToGet()
        m_objOperatingReport.SetLoggingLevelToGet()
        m_objAlarmHistory.SetLoggingLevelToGet()
        m_objOperatingHistory.SetLoggingLevelToGet()

        m_objMachine.SetLoggingLevelToGet()
    End Sub

    Private Sub SetLoggingLevelSet()
        m_objAxis.SetLoggingLevelToSet()
        m_objSpindle.SetLoggingLevelToSet()
        m_objProgram.SetLoggingLevelToSet()
        m_objTools.SetLoggingLevelToSet()
        m_objWorkPiece.SetLoggingLevelToSet()
        m_objSpec.SetLoggingLevelToSet()
        m_objIO.SetLoggingLevelToSet()
        m_objVariables.SetLoggingLevelToSet()

        m_objOperationHistory.SetLoggingLevelToSet()
        m_objMachiningReport.SetLoggingLevelToSet()
        m_objOperatingReport.SetLoggingLevelToSet()
        m_objAlarmHistory.SetLoggingLevelToSet()
        m_objOperatingHistory.SetLoggingLevelToSet()

        m_objMachine.SetLoggingLevelToSet()
    End Sub
#End Region

    Private Sub cboAllLoggignLevel_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAllLoggingLevel.SelectedIndexChanged
        Dim enLoggigngLevel As Okuma.CMDATAPI.Enumerations.LoggingLevelEnum

        enLoggigngLevel = cboAllLoggingLevel.SelectedItem

        Select Case enLoggigngLevel
            Case Okuma.CMDATAPI.Enumerations.LoggingLevelEnum.logAll
                SetLoggingLevelAll()
            Case Okuma.CMDATAPI.Enumerations.LoggingLevelEnum.logGet
                SetLoggingLevelGet()
            Case Okuma.CMDATAPI.Enumerations.LoggingLevelEnum.logSet
                SetLoggingLevelSet()
            Case Else
                SetLoggingLevelSet()
        End Select
    End Sub

#Region "ATC Sub Panel"

    Private Sub btnATCSubSearchPotByGroupSerial_Click(sender As System.Object, e As System.EventArgs) Handles btnATCSubSearchPotByGroupSerial.Click
        Try
            Dim intGroupNo As Integer
            Dim intSerialNo As Integer
            Dim intPotNo As Integer

            intGroupNo = CInt(txtATCSubGroupNo.Text)
            intSerialNo = CInt(txtATCSubSerialNo.Text)

            intPotNo = m_objCmdATCPanel.SearchPotNo(intGroupNo, intSerialNo)

            txtATCSubReturnPotNo.Text = intPotNo
        Catch ex As Exception
            DisplayError("ATC Sub Panel", ex.Message)
        End Try
    End Sub
    Private Sub btnATCSubGetErrorCode_Click(sender As System.Object, e As System.EventArgs) Handles btnATCSubGetErrorCode.Click
        Try

            txtATCSubErrorCode.Text = m_objAtc.GetATCPanelErrorCode().ToString

        Catch ex As Exception
            DisplayError("ATC Sub Panel", ex.Message)
        End Try
    End Sub
    Private Sub btnATCGetPotNo_Click(sender As System.Object, e As System.EventArgs) Handles btnATCGetPotNo.Click
        Try

            txtATCSubPotNo.Text = m_objAtc.GetATCPanelPotNo.ToString
        Catch ex As Exception
            DisplayError("ATC Sub Panel", ex.Message)
        End Try
    End Sub
    Private Sub btnATCSubGetToolNo_Click(sender As System.Object, e As System.EventArgs) Handles btnATCSubGetToolNo.Click
        Try

            txtATCSubToolNo.Text = m_objAtc.GetATCPanelToolNo.ToString
        Catch ex As Exception
            DisplayError("ATC Sub Panel", ex.Message)
        End Try
    End Sub
    Private Sub btnATCSubGetOperationMode_Click(sender As System.Object, e As System.EventArgs) Handles btnATCSubGetOperationMode.Click
        Try

            txtATCSubOperationMode.Text = System.Enum.GetName(GetType(ATCSubPanelOperationModeEnum), m_objAtc.GetATCPanelOperationMode)

        Catch ex As Exception
            DisplayError("ATC Sub Panel", ex.Message)
        End Try
    End Sub
    Private Sub btnATCSubSetOperationMode_Click(sender As System.Object, e As System.EventArgs) Handles btnATCSubSetOperationMode.Click
        Try
            Dim enValue As ATCSubPanelOperationModeEnum

            enValue = cboATCSubPanelOperationModes.SelectedItem

            m_objAtc.SetATCPanelOperationMode(enValue)

        Catch ex As Exception
            DisplayError("ATC Sub Panel", ex.Message)
        End Try
    End Sub
    Private Sub btnATCSubSearchPotByToolName_Click(sender As System.Object, e As System.EventArgs) Handles btnATCSubSearchPotByToolName.Click
        Try
            Dim strToolName As String
            Dim intPotNo As Integer

            strToolName = (txtATCSubToolName.Text)

            intPotNo = m_objCmdATCPanel.SearchPotNo(strToolName)

            txtATCSubReturnPotNo.Text = intPotNo

        Catch ex As Exception
            DisplayError("ATC Sub Panel", ex.Message)
        End Try
    End Sub

    Private Sub btnATCSubClearError_Click(sender As System.Object, e As System.EventArgs) Handles btnATCSubClearError.Click
        Try
            m_objCmdATCPanel.ClearError()
        Catch ex As Exception
            DisplayError("ATC Sub Panel", ex.Message)
        End Try
    End Sub


    Private Sub btnATCPanelSetIndexToolNo_Click(sender As System.Object, e As System.EventArgs) Handles btnATCPanelSetIndexToolNo.Click
        Try
            Dim intPotNo As Integer
            intPotNo = CInt(txtATCPanelIndexPotNo.Text)
            m_objCmdATCPanel.SetIndexPotNo(intPotNo)
        Catch ex As Exception
            DisplayError("ATC Sub Panel", ex.Message)
        End Try
    End Sub

#End Region

    Private Sub DisplayToolList(ByRef intValues As Int32())
        Dim intCount As Integer
        Dim strValues As String = ""
        intCount = UBound(intValues) + 1

        For intIndex As Integer = 0 To intCount - 1
            strValues = String.Concat(strValues, String.Format("Index {0} = {1}" & vbCrLf, intIndex, intValues(intIndex)))
        Next

        If strValues.Trim().Length > 0 Then
            txtP300ToolsUpdate2.Text = strValues
        Else
            txtP300ToolsUpdate2.Text = "NONE"
        End If
    End Sub


    Private Sub btnP300GetAllToolList_Click(sender As System.Object, e As System.EventArgs) Handles btnP300GetAllToolList.Click
        Dim intValues As Int32()
        Try
            intValues = m_objTools.GetToolList(ToolListTypeEnum.AllTools)
            DisplayToolList(intValues)
        Catch ex As Exception
            DisplayError("P300 Tools", ex.Message)
        End Try
    End Sub

    Private Sub btnP300GetAttachedToolList_Click(sender As System.Object, e As System.EventArgs) Handles btnP300GetAttachedToolList.Click
        Dim intValues As Int32()
        Try
            intValues = m_objTools.GetToolList(ToolListTypeEnum.AttachedTools)
            DisplayToolList(intValues)
        Catch ex As Exception
            DisplayError("P300 Tools", ex.Message)
        End Try
    End Sub

    Private Sub btnP300GetRegisteredToolList_Click(sender As System.Object, e As System.EventArgs) Handles btnP300GetRegisteredToolList.Click
        Dim intValues As Int32()
        Try
            intValues = m_objTools.GetToolList(ToolListTypeEnum.RegisteredTools)
            DisplayToolList(intValues)
        Catch ex As Exception
            DisplayError("P300 Tools", ex.Message)
        End Try
    End Sub

#Region "P300ATC"
    Private Sub btnP300TLDataInput_Click(sender As System.Object, e As System.EventArgs) Handles btnP300TLDataInput.Click
        Dim intToolNo As Integer
        Dim strFolderPath As String = ""
        Dim blnOverwrite As Boolean = False
        Try
            intToolNo = CInt(txtLoadSaveToolNumber.Text.Trim)
            strFolderPath = txtLoadSaveFolderPath.Text.Trim
            blnOverwrite = chkP300TLDataOverwrite.Checked
            m_objCmdATC.ToolDataInput(intToolNo, strFolderPath, blnOverwrite)
        Catch ex As Exception
            DisplayError("P300ATC", ex.Message)
        End Try
    End Sub

    Private Sub btnP300TLDataOutput_Click(sender As System.Object, e As System.EventArgs) Handles btnP300TLDataOutput.Click
        Dim intToolNo As Integer
        Dim strFolderPath As String = ""
        Dim blnOverwrite As Boolean = False
        Try
            intToolNo = CInt(txtLoadSaveToolNumber.Text.Trim)
            strFolderPath = txtLoadSaveFolderPath.Text.Trim
            blnOverwrite = chkP300TLDataOverwrite.Checked
            m_objCmdATC.ToolDataOutput(intToolNo, strFolderPath, blnOverwrite)
        Catch ex As Exception
            DisplayError("P300ATC", ex.Message)
        End Try
    End Sub

#End Region


End Class
