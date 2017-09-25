Imports Okuma.ApiLog2

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabLoggingService = New System.Windows.Forms.TabPage()
        Me.pnlLoggingGridView = New System.Windows.Forms.Panel()
        Me.dgvLogging = New System.Windows.Forms.DataGridView()
        Me.DateLoggedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AppNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClassNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MethodNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IOParametersDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LoggingLevelDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MessageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLogRecordBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox35 = New System.Windows.Forms.GroupBox()
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
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cboLoggingLevel = New System.Windows.Forms.ComboBox()
        Me.LoggingLevelEnumBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpEndingDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartingDate = New System.Windows.Forms.DateTimePicker()
        Me.tabAxis = New System.Windows.Forms.TabPage()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.txtCommandFeedrate = New System.Windows.Forms.TextBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.txtFeedrateOverride = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.cboWheelAxes = New System.Windows.Forms.ComboBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.txtActualPositionWheelCoordinate = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboAxisDataUnit = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFeedrateType = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAxisFeedrate = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPathFeedrate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAxisLoad = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtActualPositionMachineCoordinate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtActualPositionProgramCoordinate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboAxes = New System.Windows.Forms.ComboBox()
        Me.btnAxisUpdate = New System.Windows.Forms.Button()
        Me.tabMachine = New System.Windows.Forms.TabPage()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.cboAllLoggignLevel = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnHMCount_Add = New System.Windows.Forms.Button()
        Me.Label333 = New System.Windows.Forms.Label()
        Me.btnHMCount_Set = New System.Windows.Forms.Button()
        Me.txtHMCount = New System.Windows.Forms.TextBox()
        Me.txtHMCountValue = New System.Windows.Forms.TextBox()
        Me.btnHMCount_Get = New System.Windows.Forms.Button()
        Me.cboHMCount = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnHMSet_Add = New System.Windows.Forms.Button()
        Me.Label332 = New System.Windows.Forms.Label()
        Me.btnHMSet_Set = New System.Windows.Forms.Button()
        Me.txtHMSet = New System.Windows.Forms.TextBox()
        Me.txtHMSetValue = New System.Windows.Forms.TextBox()
        Me.btnHMSet_Get = New System.Windows.Forms.Button()
        Me.cboHMSet = New System.Windows.Forms.ComboBox()
        Me.txtMachine = New System.Windows.Forms.TextBox()
        Me.Label165 = New System.Windows.Forms.Label()
        Me.machineUpdateButton = New System.Windows.Forms.Button()
        Me.tabPLCIO = New System.Windows.Forms.TabPage()
        Me.GroupBox36 = New System.Windows.Forms.GroupBox()
        Me.btnGetIOLabel = New System.Windows.Forms.Button()
        Me.Label297 = New System.Windows.Forms.Label()
        Me.txtIOLabel = New System.Windows.Forms.TextBox()
        Me.cboIOVariableTypes = New System.Windows.Forms.ComboBox()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.txtULongWordValue = New System.Windows.Forms.TextBox()
        Me.btnSetULongWord = New System.Windows.Forms.Button()
        Me.txtULongWordData = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.btnGetULongWord = New System.Windows.Forms.Button()
        Me.txtULongWordAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.txtUWordValue = New System.Windows.Forms.TextBox()
        Me.btnSetUWord = New System.Windows.Forms.Button()
        Me.txtUWordData = New System.Windows.Forms.TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.btnGetUWord = New System.Windows.Forms.Button()
        Me.txtUWordAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.txtUBitValue = New System.Windows.Forms.TextBox()
        Me.btnSetUBit = New System.Windows.Forms.Button()
        Me.txtUBitData = New System.Windows.Forms.TextBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.txtUBit = New System.Windows.Forms.TextBox()
        Me.btnGetUBit = New System.Windows.Forms.Button()
        Me.txtUBitAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.txtGLongWordValue = New System.Windows.Forms.TextBox()
        Me.btnSetGLongWord = New System.Windows.Forms.Button()
        Me.txtGLongWordData = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.btnGetGLongWord = New System.Windows.Forms.Button()
        Me.txtGLongWordAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.txtGWordValue = New System.Windows.Forms.TextBox()
        Me.btnSetGWord = New System.Windows.Forms.Button()
        Me.txtGWordData = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.btnGetGWord = New System.Windows.Forms.Button()
        Me.txtGWordAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.txtGBitValue = New System.Windows.Forms.TextBox()
        Me.btnSetGBit = New System.Windows.Forms.Button()
        Me.txtGBitData = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.txtGBit = New System.Windows.Forms.TextBox()
        Me.btnGetGBit = New System.Windows.Forms.Button()
        Me.txtGBitAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.txtIOLongWordLabel = New System.Windows.Forms.TextBox()
        Me.cmdIOGetLongWordByLabel = New System.Windows.Forms.Button()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.txtPLCLongWordData = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.cboPLCLongWord = New System.Windows.Forms.ComboBox()
        Me.btnGetLongWord = New System.Windows.Forms.Button()
        Me.txtPLCLongWordAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.txtIOWordLabel = New System.Windows.Forms.TextBox()
        Me.cmdIOGetWordByLabel = New System.Windows.Forms.Button()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.txtPLCWordData = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.cboPLCWord = New System.Windows.Forms.ComboBox()
        Me.btnGetWord = New System.Windows.Forms.Button()
        Me.txtPLCWordAddress = New System.Windows.Forms.TextBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.txtIOBitLabel = New System.Windows.Forms.TextBox()
        Me.cmdIOGetBitByLabel = New System.Windows.Forms.Button()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.txtPLCBitData = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtPLCBit = New System.Windows.Forms.TextBox()
        Me.cboPLCBit = New System.Windows.Forms.ComboBox()
        Me.btnGetBit = New System.Windows.Forms.Button()
        Me.txtPLCBitAddress = New System.Windows.Forms.TextBox()
        Me.tabProgram = New System.Windows.Forms.TabPage()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.txtLoadPartProgramNameValue = New System.Windows.Forms.TextBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.txtLoadPartSystemSubProgramNameValue = New System.Windows.Forms.TextBox()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.txtLoadSubPartProgramFileNameValue = New System.Windows.Forms.TextBox()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.lstProgramOutput = New System.Windows.Forms.ListBox()
        Me.btnGetMCodes = New System.Windows.Forms.GroupBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtProgramCycleSelectionProgramFileName = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtProgramCycleSelectionProgramName = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cboProgramCycleSelection = New System.Windows.Forms.ComboBox()
        Me.txtActiveIndexProgram = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtProgramCurrentCycleSelection = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtLoadSchedulePartProgramValue = New System.Windows.Forms.TextBox()
        Me.btnLoadSchedulePartProgram = New System.Windows.Forms.Button()
        Me.txtLoadPartProgramFileNameValue = New System.Windows.Forms.TextBox()
        Me.btnLoadPartProgram = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtProgramRunningState = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtProgramExecuteSequenceNumber = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtProgramBlockNumber = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtActiveScheduleProgramFileName = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtActiveProgramName = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtActiveProgramFileName = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.cboProgramDataUnit = New System.Windows.Forms.ComboBox()
        Me.btnProgramUpdate = New System.Windows.Forms.Button()
        Me.tabSpec = New System.Windows.Forms.TabPage()
        Me.txtMachineName = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnSpecUpdate = New System.Windows.Forms.Button()
        Me.txtOSPControlType = New System.Windows.Forms.TextBox()
        Me.Label346 = New System.Windows.Forms.Label()
        Me.txtMachineSerial = New System.Windows.Forms.TextBox()
        Me.Label168 = New System.Windows.Forms.Label()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.txtNCSpec2 = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtNCSpec2BitValue = New System.Windows.Forms.TextBox()
        Me.btnGetNCSpec2 = New System.Windows.Forms.Button()
        Me.txtNCSpec2AddressValue = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txtNCSpec = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txtNCSpecBitValue = New System.Windows.Forms.TextBox()
        Me.btnGetNCSpec = New System.Windows.Forms.Button()
        Me.txtNCSpecAddressValue = New System.Windows.Forms.TextBox()
        Me.tabSpindle = New System.Windows.Forms.TabPage()
        Me.GroupBox24 = New System.Windows.Forms.GroupBox()
        Me.btntxtCommandSpindlerateSet = New System.Windows.Forms.Button()
        Me.txtCommandSpindlerate = New System.Windows.Forms.TextBox()
        Me.btntxtCommandSpindlerateAdd = New System.Windows.Forms.Button()
        Me.txtCommandSpindlerateValue = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSpindlSurfaceSpeed = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSpindlerRateOverride = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSpindleLoad = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSpindleActualSpeedRate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboSpindleDataUnit = New System.Windows.Forms.ComboBox()
        Me.btnSpindleUpdate = New System.Windows.Forms.Button()
        Me.tabTools = New System.Windows.Forms.TabPage()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.txtCurrentTool = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtDiamondToolIndex = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboDiamondNoseRCompAxis = New System.Windows.Forms.ComboBox()
        Me.btnDiamondToolNoseRCompSet = New System.Windows.Forms.Button()
        Me.txtDiamondNoseRComp = New System.Windows.Forms.TextBox()
        Me.btnDiamondToolNoseRCompAdd = New System.Windows.Forms.Button()
        Me.txtDiamondNoseRCompValue = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cboToolOffsetAxis = New System.Windows.Forms.ComboBox()
        Me.btnToolOffsetSet = New System.Windows.Forms.Button()
        Me.txtToolOffset = New System.Windows.Forms.TextBox()
        Me.btnToolOffsetAdd = New System.Windows.Forms.Button()
        Me.txtToolOffsetValue = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cboDiamondToolDataUnit = New System.Windows.Forms.ComboBox()
        Me.btnDiamondTool = New System.Windows.Forms.Button()
        Me.tabVariables = New System.Windows.Forms.TabPage()
        Me.GroupBox19 = New System.Windows.Forms.GroupBox()
        Me.btnSetCommonVariables = New System.Windows.Forms.Button()
        Me.txtCommonVariableEndingIndex = New System.Windows.Forms.TextBox()
        Me.txtCommonVariableStartingIndex = New System.Windows.Forms.TextBox()
        Me.txtCommonVariableValue = New System.Windows.Forms.TextBox()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.txtCommonVariable = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.btnGetCommonVariable = New System.Windows.Forms.Button()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.txtCommonVariableData = New System.Windows.Forms.TextBox()
        Me.btnCommonVariableUpdate = New System.Windows.Forms.Button()
        Me.btnGetCommonVariables = New System.Windows.Forms.Button()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.txtCommonVariablesCount = New System.Windows.Forms.TextBox()
        Me.btnAddCommonVariables = New System.Windows.Forms.Button()
        Me.Label246 = New System.Windows.Forms.Label()
        Me.txtCommonVarialbesData = New System.Windows.Forms.TextBox()
        Me.tabWheel = New System.Windows.Forms.TabPage()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtWheelMaxWheels = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboWheelDataUnit = New System.Windows.Forms.ComboBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.txtWheelType = New System.Windows.Forms.TextBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.txtWheelShape = New System.Windows.Forms.TextBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.txtMaxWheelData = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtWheelDataNo = New System.Windows.Forms.TextBox()
        Me.GroupBox23 = New System.Windows.Forms.GroupBox()
        Me.btnWheelSurfaceSpeedSetupSet = New System.Windows.Forms.Button()
        Me.txtWheelSurfaceSpeedSetup = New System.Windows.Forms.TextBox()
        Me.btnWheelSurfaceSpeedSetupAdd = New System.Windows.Forms.Button()
        Me.txtWheelSurfaceSpeedSetupValue = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtWheelPPCLoad = New System.Windows.Forms.TextBox()
        Me.lstWheelData = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnWheelDiamondToolOffsetNumberSet = New System.Windows.Forms.Button()
        Me.txtWheelDiamondToolOffsetNumber = New System.Windows.Forms.TextBox()
        Me.btnWheelDiamondToolOffsetNumberAdd = New System.Windows.Forms.Button()
        Me.txtWheelDiamondToolOffsetNumberValue = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnWheelDataNumberSet = New System.Windows.Forms.Button()
        Me.txtWheelDataNumber = New System.Windows.Forms.TextBox()
        Me.btnWheelDataNumberAdd = New System.Windows.Forms.Button()
        Me.txtWheelDataNumberValue = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnReferencePositionSet = New System.Windows.Forms.Button()
        Me.txtWheelReferencePosition = New System.Windows.Forms.TextBox()
        Me.btnReferencePositionAdd = New System.Windows.Forms.Button()
        Me.txtWheelReferencePositionValue = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtWheelSpindleRateOverride = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtWheelOLLoad = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtWheelGAPLoad = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtWheelEffectLoad = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtWheelMeasureLoad = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtWheelSpindleSurfaceSpeed = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtWheelCommandSpindleRate = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtWheelActualSpindleRate = New System.Windows.Forms.TextBox()
        Me.btnWheel = New System.Windows.Forms.Button()
        Me.tabWorkpiece = New System.Windows.Forms.TabPage()
        Me.GroupBox30 = New System.Windows.Forms.GroupBox()
        Me.cboWorkOffsetLocatorPositiveSideEndFace = New System.Windows.Forms.ComboBox()
        Me.btnWorkLocatorPositiveSideEndFaceSet = New System.Windows.Forms.Button()
        Me.txtWorkLocatorPositiveSideEndFace = New System.Windows.Forms.TextBox()
        Me.btnWorkLocatorPositiveSideEndFaceAdd = New System.Windows.Forms.Button()
        Me.txtWorkLocatorPositiveSideEndFaceValue = New System.Windows.Forms.TextBox()
        Me.GroupBox29 = New System.Windows.Forms.GroupBox()
        Me.cboWorkOffsetLocatorNegativeSideEndFace = New System.Windows.Forms.ComboBox()
        Me.btnWorkLocatorNegativeSideEndFaceSet = New System.Windows.Forms.Button()
        Me.txtWorkLocatorNegativeSideEndFace = New System.Windows.Forms.TextBox()
        Me.btnWorkLocatorNegativeSideEndFaceAdd = New System.Windows.Forms.Button()
        Me.txtWorkLocatorNegativeSideEndFaceValue = New System.Windows.Forms.TextBox()
        Me.GroupBox28 = New System.Windows.Forms.GroupBox()
        Me.cboWorkOffsetCompMeasure = New System.Windows.Forms.ComboBox()
        Me.btnCompMeasureSet = New System.Windows.Forms.Button()
        Me.txtCompMeasure = New System.Windows.Forms.TextBox()
        Me.btnCompMeasureAdd = New System.Windows.Forms.Button()
        Me.txtCompMeasureValue = New System.Windows.Forms.TextBox()
        Me.GroupBox27 = New System.Windows.Forms.GroupBox()
        Me.cboWorkOffsetMasterWork = New System.Windows.Forms.ComboBox()
        Me.btnMasterWorkOffsetSet = New System.Windows.Forms.Button()
        Me.txtMasterWorkOffset = New System.Windows.Forms.TextBox()
        Me.btnMasterWorkOffsetAdd = New System.Windows.Forms.Button()
        Me.txtMasterWorkOffsetValue = New System.Windows.Forms.TextBox()
        Me.GroupBox26 = New System.Windows.Forms.GroupBox()
        Me.btnWPCounterSet_Add = New System.Windows.Forms.Button()
        Me.wkCounterSetCombo = New System.Windows.Forms.ComboBox()
        Me.btnWPCounterSet_Get = New System.Windows.Forms.Button()
        Me.btnWPCounterSet_Set = New System.Windows.Forms.Button()
        Me.txtWPCounterSetValue = New System.Windows.Forms.TextBox()
        Me.txtWPCounterSet = New System.Windows.Forms.TextBox()
        Me.GroupBox25 = New System.Windows.Forms.GroupBox()
        Me.cmd_addWorkpiece = New System.Windows.Forms.Button()
        Me.wkUpdateCounter = New System.Windows.Forms.TextBox()
        Me.wkCounterCombo = New System.Windows.Forms.ComboBox()
        Me.wkSetCounterValue = New System.Windows.Forms.Button()
        Me.wkGetCounterValue = New System.Windows.Forms.Button()
        Me.wkCounterValue = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cboZeroShiftAxis = New System.Windows.Forms.ComboBox()
        Me.btnZeroShiftSet = New System.Windows.Forms.Button()
        Me.txtZeroShift = New System.Windows.Forms.TextBox()
        Me.btnZeroShiftAdd = New System.Windows.Forms.Button()
        Me.txtZeroShiftValue = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cboZeroOffsetAxis = New System.Windows.Forms.ComboBox()
        Me.btnZeroOffsetSetSet = New System.Windows.Forms.Button()
        Me.txtZeroOffset = New System.Windows.Forms.TextBox()
        Me.btnZeroOffsetAdd = New System.Windows.Forms.Button()
        Me.txtZeroOffsetValue = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cboWorkpieceDataUnit = New System.Windows.Forms.ComboBox()
        Me.btnUpdateWorkpiece = New System.Windows.Forms.Button()
        Me.tabMacManAlarmHistory = New System.Windows.Forms.TabPage()
        Me.lstAlarms = New System.Windows.Forms.ListBox()
        Me.txtAlarmHistoryEndIndex = New System.Windows.Forms.TextBox()
        Me.Label137 = New System.Windows.Forms.Label()
        Me.txtAlarmHistoryFromIndex = New System.Windows.Forms.TextBox()
        Me.Label138 = New System.Windows.Forms.Label()
        Me.btnAlarmHistoryUpdates = New System.Windows.Forms.Button()
        Me.txtAlarmObject = New System.Windows.Forms.TextBox()
        Me.Label135 = New System.Windows.Forms.Label()
        Me.btnAlarmHistoryUpdate = New System.Windows.Forms.Button()
        Me.txtAlarmIndex = New System.Windows.Forms.TextBox()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.txtMaxAlarmCount = New System.Windows.Forms.TextBox()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.txtAlarmCount = New System.Windows.Forms.TextBox()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.txtAlarmTime = New System.Windows.Forms.TextBox()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.txtAlarmNumber = New System.Windows.Forms.TextBox()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.txtAlarmMessage = New System.Windows.Forms.TextBox()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.txtAlarmDate = New System.Windows.Forms.TextBox()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.txtAlarmCode = New System.Windows.Forms.TextBox()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.tabMacManMachiningReport = New System.Windows.Forms.TabPage()
        Me.grdMachiningReports = New System.Windows.Forms.DataGrid()
        Me.txtMachiningReportNoOfWork = New System.Windows.Forms.TextBox()
        Me.Label144 = New System.Windows.Forms.Label()
        Me.txtMachiningReportStartTime = New System.Windows.Forms.TextBox()
        Me.Label245 = New System.Windows.Forms.Label()
        Me.txtMachiningReportToIndex = New System.Windows.Forms.TextBox()
        Me.Label221 = New System.Windows.Forms.Label()
        Me.txtMachiningReportFromIndex = New System.Windows.Forms.TextBox()
        Me.Label222 = New System.Windows.Forms.Label()
        Me.btnMacManMachiningReportUpdates = New System.Windows.Forms.Button()
        Me.Label216 = New System.Windows.Forms.Label()
        Me.cboMachiningReportType = New System.Windows.Forms.ComboBox()
        Me.txtMachiningReportProgramName = New System.Windows.Forms.TextBox()
        Me.Label217 = New System.Windows.Forms.Label()
        Me.txtMachiningReportMainProgram = New System.Windows.Forms.TextBox()
        Me.Label218 = New System.Windows.Forms.Label()
        Me.txtMachiningReportCount = New System.Windows.Forms.TextBox()
        Me.Label219 = New System.Windows.Forms.Label()
        Me.btnMacManMachiningReportUpdate = New System.Windows.Forms.Button()
        Me.txtMacManReportIndex = New System.Windows.Forms.TextBox()
        Me.Label220 = New System.Windows.Forms.Label()
        Me.txtMachiningReportOperatingTime = New System.Windows.Forms.TextBox()
        Me.Label225 = New System.Windows.Forms.Label()
        Me.txtMachiningReportRunningTime = New System.Windows.Forms.TextBox()
        Me.Label226 = New System.Windows.Forms.Label()
        Me.txtMachiningReportStartDate = New System.Windows.Forms.TextBox()
        Me.Label227 = New System.Windows.Forms.Label()
        Me.txtMachiningReportMaxCount = New System.Windows.Forms.TextBox()
        Me.Label228 = New System.Windows.Forms.Label()
        Me.txtMachiningReportCuttingTime = New System.Windows.Forms.TextBox()
        Me.Label229 = New System.Windows.Forms.Label()
        Me.tabMacManOperatingHistory = New System.Windows.Forms.TabPage()
        Me.Label191 = New System.Windows.Forms.Label()
        Me.txtMacManOperatingHistoryMaxCount = New System.Windows.Forms.TextBox()
        Me.btnMacManOperatingHistoryUpdate = New System.Windows.Forms.Button()
        Me.Label212 = New System.Windows.Forms.Label()
        Me.Label213 = New System.Windows.Forms.Label()
        Me.txtMacManOperatingHistoryToIndex = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryFromIndex = New System.Windows.Forms.TextBox()
        Me.GroupBox31 = New System.Windows.Forms.GroupBox()
        Me.txtMacManOperatingHistoryPrevAlarmonTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryPrevExternalInputTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryPrevSpindleRunTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryPrevOtherTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryPrevMaintenanceTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryPrevPartWaitingTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryPrevNoOperatorTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryPrevInProSetupTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryPrevNonOperatingTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryPrevCuttingTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryPrevOperatingTime = New System.Windows.Forms.TextBox()
        Me.Label223 = New System.Windows.Forms.Label()
        Me.Label247 = New System.Windows.Forms.Label()
        Me.Label250 = New System.Windows.Forms.Label()
        Me.Label251 = New System.Windows.Forms.Label()
        Me.Label255 = New System.Windows.Forms.Label()
        Me.Label257 = New System.Windows.Forms.Label()
        Me.Label258 = New System.Windows.Forms.Label()
        Me.Label259 = New System.Windows.Forms.Label()
        Me.Label260 = New System.Windows.Forms.Label()
        Me.Label261 = New System.Windows.Forms.Label()
        Me.Label262 = New System.Windows.Forms.Label()
        Me.Label263 = New System.Windows.Forms.Label()
        Me.txtMacManOperatingHistoryPrevRunningTime = New System.Windows.Forms.TextBox()
        Me.GroupBox32 = New System.Windows.Forms.GroupBox()
        Me.txtMacManOperatingHistoryAlarmOnTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryExternalInputTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistorySpindleRunTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryOtherTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryMaintenanceTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryPartWaitingTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryNoOperatorTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryInProSetupTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryNonOperatingReport = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryCuttingTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryOperatingTime = New System.Windows.Forms.TextBox()
        Me.txtMacManOperatingHistoryRunningTime = New System.Windows.Forms.TextBox()
        Me.Label200 = New System.Windows.Forms.Label()
        Me.Label201 = New System.Windows.Forms.Label()
        Me.Label202 = New System.Windows.Forms.Label()
        Me.Label203 = New System.Windows.Forms.Label()
        Me.Label204 = New System.Windows.Forms.Label()
        Me.Label205 = New System.Windows.Forms.Label()
        Me.Label206 = New System.Windows.Forms.Label()
        Me.Label207 = New System.Windows.Forms.Label()
        Me.Label208 = New System.Windows.Forms.Label()
        Me.Label209 = New System.Windows.Forms.Label()
        Me.Label210 = New System.Windows.Forms.Label()
        Me.Label211 = New System.Windows.Forms.Label()
        Me.tabMacManOperatingReport = New System.Windows.Forms.TabPage()
        Me.txtMaxNoOfOpReport = New System.Windows.Forms.TextBox()
        Me.Label288 = New System.Windows.Forms.Label()
        Me.btnOperatingReportUpdate = New System.Windows.Forms.Button()
        Me.GroupBox20 = New System.Windows.Forms.GroupBox()
        Me.Label145 = New System.Windows.Forms.Label()
        Me.txtPrevExternalInputTime = New System.Windows.Forms.TextBox()
        Me.txtPrevDateOfOperatingRept = New System.Windows.Forms.TextBox()
        Me.txtPrevAlarmOnTime = New System.Windows.Forms.TextBox()
        Me.txtPrevSpindleRunTime = New System.Windows.Forms.TextBox()
        Me.txtPrevOtherTime = New System.Windows.Forms.TextBox()
        Me.txtPrevMaintenanceTime = New System.Windows.Forms.TextBox()
        Me.txtPrevPartwaitingTime = New System.Windows.Forms.TextBox()
        Me.txtPrevNoOperatorTime = New System.Windows.Forms.TextBox()
        Me.txtPrevInProSetupTime = New System.Windows.Forms.TextBox()
        Me.txtPrevNonOperatingTime = New System.Windows.Forms.TextBox()
        Me.txtPrevCuttingTime = New System.Windows.Forms.TextBox()
        Me.txtPrevRunningTime = New System.Windows.Forms.TextBox()
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
        Me.txtPrevOperatingTime = New System.Windows.Forms.TextBox()
        Me.GroupBox21 = New System.Windows.Forms.GroupBox()
        Me.Label240 = New System.Windows.Forms.Label()
        Me.txtOperatingTime = New System.Windows.Forms.TextBox()
        Me.Label264 = New System.Windows.Forms.Label()
        Me.Label265 = New System.Windows.Forms.Label()
        Me.Label266 = New System.Windows.Forms.Label()
        Me.Label267 = New System.Windows.Forms.Label()
        Me.Label268 = New System.Windows.Forms.Label()
        Me.Label269 = New System.Windows.Forms.Label()
        Me.txtRunningTime = New System.Windows.Forms.TextBox()
        Me.txtCuttingTime = New System.Windows.Forms.TextBox()
        Me.txtNonOPeratingTime = New System.Windows.Forms.TextBox()
        Me.txtInProSetupTime = New System.Windows.Forms.TextBox()
        Me.txtNoOperatorTime = New System.Windows.Forms.TextBox()
        Me.txtPartWaitingTime = New System.Windows.Forms.TextBox()
        Me.Label270 = New System.Windows.Forms.Label()
        Me.txtmaintenanceTime = New System.Windows.Forms.TextBox()
        Me.Label271 = New System.Windows.Forms.Label()
        Me.txtOtherTime = New System.Windows.Forms.TextBox()
        Me.Label272 = New System.Windows.Forms.Label()
        Me.txtSpindleRunTime = New System.Windows.Forms.TextBox()
        Me.Label273 = New System.Windows.Forms.Label()
        Me.txtExternalInputTime = New System.Windows.Forms.TextBox()
        Me.txtAlarmOnTime = New System.Windows.Forms.TextBox()
        Me.Label274 = New System.Windows.Forms.Label()
        Me.txtDateOfOperatingReport = New System.Windows.Forms.TextBox()
        Me.Label275 = New System.Windows.Forms.Label()
        Me.GroupBox22 = New System.Windows.Forms.GroupBox()
        Me.txtPeriodDateOfOperatingReport = New System.Windows.Forms.TextBox()
        Me.txtPeriodAlarmOnTime = New System.Windows.Forms.TextBox()
        Me.txtPeriodExternalInputTime = New System.Windows.Forms.TextBox()
        Me.txtPeriodSpindleRunTime = New System.Windows.Forms.TextBox()
        Me.txtPeriodOtherTime = New System.Windows.Forms.TextBox()
        Me.txtPeriodMaintenanceTime = New System.Windows.Forms.TextBox()
        Me.txtPeriodNoOperatorTime = New System.Windows.Forms.TextBox()
        Me.txtPeriodPartWaitingTime = New System.Windows.Forms.TextBox()
        Me.txtPeriodInproSetupTime = New System.Windows.Forms.TextBox()
        Me.txtPeriodNonOperatingTime = New System.Windows.Forms.TextBox()
        Me.txtPeriodCuttingTime = New System.Windows.Forms.TextBox()
        Me.txtPeriodRunningTime = New System.Windows.Forms.TextBox()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.Label133 = New System.Windows.Forms.Label()
        Me.Label234 = New System.Windows.Forms.Label()
        Me.Label235 = New System.Windows.Forms.Label()
        Me.Label236 = New System.Windows.Forms.Label()
        Me.Label237 = New System.Windows.Forms.Label()
        Me.Label238 = New System.Windows.Forms.Label()
        Me.txtPeriodOperatingTime = New System.Windows.Forms.TextBox()
        Me.Label239 = New System.Windows.Forms.Label()
        Me.tabMacManOperationHistory = New System.Windows.Forms.TabPage()
        Me.lstOperationHistory = New System.Windows.Forms.ListBox()
        Me.txtOperationHistoryToIndex = New System.Windows.Forms.TextBox()
        Me.Label139 = New System.Windows.Forms.Label()
        Me.txtOperationHistoryFromIndex = New System.Windows.Forms.TextBox()
        Me.Label140 = New System.Windows.Forms.Label()
        Me.btnOperationHistoryUpdates = New System.Windows.Forms.Button()
        Me.btnOperationHistoryUpdate = New System.Windows.Forms.Button()
        Me.txtOperationHistoryIndex = New System.Windows.Forms.TextBox()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.txtOperationHistoryTime = New System.Windows.Forms.TextBox()
        Me.Label116 = New System.Windows.Forms.Label()
        Me.txtOperationHistoryDate = New System.Windows.Forms.TextBox()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.txtOperationHistoryData = New System.Windows.Forms.TextBox()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.txtOperationHistoryMaxCount = New System.Windows.Forms.TextBox()
        Me.Label119 = New System.Windows.Forms.Label()
        Me.txtOperationHistoryCount = New System.Windows.Forms.TextBox()
        Me.Label120 = New System.Windows.Forms.Label()
        Me.tabLoader = New System.Windows.Forms.TabPage()
        Me.GroupBox34 = New System.Windows.Forms.GroupBox()
        Me.txtRegisterDataIndex = New System.Windows.Forms.TextBox()
        Me.btnRegisterDataGet = New System.Windows.Forms.Button()
        Me.btnRegisterDataSet = New System.Windows.Forms.Button()
        Me.txtRegisterData = New System.Windows.Forms.TextBox()
        Me.btnRegisterDataAdd = New System.Windows.Forms.Button()
        Me.txtRegisterDataValue = New System.Windows.Forms.TextBox()
        Me.GroupBox33 = New System.Windows.Forms.GroupBox()
        Me.txtPointDataIndex = New System.Windows.Forms.TextBox()
        Me.btnPointDataGet = New System.Windows.Forms.Button()
        Me.cboLoaderAxisPointData = New System.Windows.Forms.ComboBox()
        Me.btnPointDataSet = New System.Windows.Forms.Button()
        Me.txtPointData = New System.Windows.Forms.TextBox()
        Me.btnPointDataAdd = New System.Windows.Forms.Button()
        Me.txtPointDataValue = New System.Windows.Forms.TextBox()
        Me.ErrorLog = New System.Windows.Forms.TextBox()
        Me.btnClearMessage = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TabControl1.SuspendLayout()
        Me.tabLoggingService.SuspendLayout()
        Me.pnlLoggingGridView.SuspendLayout()
        CType(Me.dgvLogging, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLogRecordBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox35.SuspendLayout()
        CType(Me.LoggingLevelEnumBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAxis.SuspendLayout()
        Me.tabMachine.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.tabPLCIO.SuspendLayout()
        Me.GroupBox36.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.tabProgram.SuspendLayout()
        Me.btnGetMCodes.SuspendLayout()
        Me.tabSpec.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.tabSpindle.SuspendLayout()
        Me.GroupBox24.SuspendLayout()
        Me.tabTools.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.tabVariables.SuspendLayout()
        Me.GroupBox19.SuspendLayout()
        Me.tabWheel.SuspendLayout()
        Me.GroupBox23.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabWorkpiece.SuspendLayout()
        Me.GroupBox30.SuspendLayout()
        Me.GroupBox29.SuspendLayout()
        Me.GroupBox28.SuspendLayout()
        Me.GroupBox27.SuspendLayout()
        Me.GroupBox26.SuspendLayout()
        Me.GroupBox25.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.tabMacManAlarmHistory.SuspendLayout()
        Me.tabMacManMachiningReport.SuspendLayout()
        CType(Me.grdMachiningReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMacManOperatingHistory.SuspendLayout()
        Me.GroupBox31.SuspendLayout()
        Me.GroupBox32.SuspendLayout()
        Me.tabMacManOperatingReport.SuspendLayout()
        Me.GroupBox20.SuspendLayout()
        Me.GroupBox21.SuspendLayout()
        Me.GroupBox22.SuspendLayout()
        Me.tabMacManOperationHistory.SuspendLayout()
        Me.GroupBox34.SuspendLayout()
        Me.GroupBox33.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabAxis)
        Me.TabControl1.Controls.Add(Me.tabMachine)
        Me.TabControl1.Controls.Add(Me.tabPLCIO)
        Me.TabControl1.Controls.Add(Me.tabProgram)
        Me.TabControl1.Controls.Add(Me.tabSpec)
        Me.TabControl1.Controls.Add(Me.tabSpindle)
        Me.TabControl1.Controls.Add(Me.tabTools)
        Me.TabControl1.Controls.Add(Me.tabVariables)
        Me.TabControl1.Controls.Add(Me.tabWheel)
        Me.TabControl1.Controls.Add(Me.tabWorkpiece)
        Me.TabControl1.Controls.Add(Me.tabMacManAlarmHistory)
        Me.TabControl1.Controls.Add(Me.tabMacManMachiningReport)
        Me.TabControl1.Controls.Add(Me.tabMacManOperatingHistory)
        Me.TabControl1.Controls.Add(Me.tabMacManOperationHistory)
        Me.TabControl1.Controls.Add(Me.tabMacManOperatingReport)
        Me.TabControl1.Controls.Add(Me.tabLoggingService)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(4, 4)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1020, 584)
        Me.TabControl1.TabIndex = 0
        '
        'tabLoggingService
        '
        Me.tabLoggingService.Controls.Add(Me.pnlLoggingGridView)
        Me.tabLoggingService.Controls.Add(Me.GroupBox35)
        Me.tabLoggingService.Location = New System.Drawing.Point(4, 25)
        Me.tabLoggingService.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tabLoggingService.Name = "tabLoggingService"
        Me.tabLoggingService.Size = New System.Drawing.Size(1012, 555)
        Me.tabLoggingService.TabIndex = 16
        Me.tabLoggingService.Text = "API Logging Service"
        Me.tabLoggingService.UseVisualStyleBackColor = True
        '
        'pnlLoggingGridView
        '
        Me.pnlLoggingGridView.Controls.Add(Me.dgvLogging)
        Me.pnlLoggingGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLoggingGridView.Location = New System.Drawing.Point(0, 149)
        Me.pnlLoggingGridView.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlLoggingGridView.Name = "pnlLoggingGridView"
        Me.pnlLoggingGridView.Size = New System.Drawing.Size(1012, 406)
        Me.pnlLoggingGridView.TabIndex = 1
        '
        'dgvLogging
        '
        Me.dgvLogging.AllowUserToAddRows = False
        Me.dgvLogging.AllowUserToDeleteRows = False
        Me.dgvLogging.AutoGenerateColumns = False
        Me.dgvLogging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLogging.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateLoggedDataGridViewTextBoxColumn, Me.AppNameDataGridViewTextBoxColumn, Me.ClassNameDataGridViewTextBoxColumn, Me.MethodNameDataGridViewTextBoxColumn, Me.IOParametersDataGridViewTextBoxColumn, Me.LoggingLevelDataGridViewTextBoxColumn, Me.MessageDataGridViewTextBoxColumn})
        Me.dgvLogging.DataSource = Me.CLogRecordBindingSource
        Me.dgvLogging.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLogging.Location = New System.Drawing.Point(0, 0)
        Me.dgvLogging.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvLogging.Name = "dgvLogging"
        Me.dgvLogging.ReadOnly = True
        Me.dgvLogging.RowTemplate.Height = 24
        Me.dgvLogging.Size = New System.Drawing.Size(1012, 406)
        Me.dgvLogging.TabIndex = 0
        '
        'DateLoggedDataGridViewTextBoxColumn
        '
        Me.DateLoggedDataGridViewTextBoxColumn.DataPropertyName = "DateLogged"
        Me.DateLoggedDataGridViewTextBoxColumn.HeaderText = "Date Logged"
        Me.DateLoggedDataGridViewTextBoxColumn.Name = "DateLoggedDataGridViewTextBoxColumn"
        Me.DateLoggedDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AppNameDataGridViewTextBoxColumn
        '
        Me.AppNameDataGridViewTextBoxColumn.DataPropertyName = "AppName"
        Me.AppNameDataGridViewTextBoxColumn.HeaderText = "Application Name"
        Me.AppNameDataGridViewTextBoxColumn.Name = "AppNameDataGridViewTextBoxColumn"
        Me.AppNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ClassNameDataGridViewTextBoxColumn
        '
        Me.ClassNameDataGridViewTextBoxColumn.DataPropertyName = "ClassName"
        Me.ClassNameDataGridViewTextBoxColumn.HeaderText = "Class Name"
        Me.ClassNameDataGridViewTextBoxColumn.Name = "ClassNameDataGridViewTextBoxColumn"
        Me.ClassNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MethodNameDataGridViewTextBoxColumn
        '
        Me.MethodNameDataGridViewTextBoxColumn.DataPropertyName = "MethodName"
        Me.MethodNameDataGridViewTextBoxColumn.HeaderText = "Method Name"
        Me.MethodNameDataGridViewTextBoxColumn.Name = "MethodNameDataGridViewTextBoxColumn"
        Me.MethodNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IOParametersDataGridViewTextBoxColumn
        '
        Me.IOParametersDataGridViewTextBoxColumn.DataPropertyName = "IOParameters"
        Me.IOParametersDataGridViewTextBoxColumn.HeaderText = "I/O Parameters"
        Me.IOParametersDataGridViewTextBoxColumn.Name = "IOParametersDataGridViewTextBoxColumn"
        Me.IOParametersDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LoggingLevelDataGridViewTextBoxColumn
        '
        Me.LoggingLevelDataGridViewTextBoxColumn.DataPropertyName = "LoggingLevel"
        Me.LoggingLevelDataGridViewTextBoxColumn.HeaderText = "Logging Level"
        Me.LoggingLevelDataGridViewTextBoxColumn.Name = "LoggingLevelDataGridViewTextBoxColumn"
        Me.LoggingLevelDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MessageDataGridViewTextBoxColumn
        '
        Me.MessageDataGridViewTextBoxColumn.DataPropertyName = "Message"
        Me.MessageDataGridViewTextBoxColumn.HeaderText = "Message"
        Me.MessageDataGridViewTextBoxColumn.Name = "MessageDataGridViewTextBoxColumn"
        Me.MessageDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CLogRecordBindingSource
        '
        Me.CLogRecordBindingSource.DataSource = GetType(Okuma.Api.LogService.Data.CLogRecord)
        '
        'GroupBox35
        '
        Me.GroupBox35.Controls.Add(Me.txtLogMessage)
        Me.GroupBox35.Controls.Add(Me.lblMessage)
        Me.GroupBox35.Controls.Add(Me.txtLogIOParameters)
        Me.GroupBox35.Controls.Add(Me.lblIOParameters)
        Me.GroupBox35.Controls.Add(Me.txtLogFunctionName)
        Me.GroupBox35.Controls.Add(Me.lblFunctionName)
        Me.GroupBox35.Controls.Add(Me.txtLogClassName)
        Me.GroupBox35.Controls.Add(Me.lblClassName)
        Me.GroupBox35.Controls.Add(Me.txtLogAppName)
        Me.GroupBox35.Controls.Add(Me.lblAppName)
        Me.GroupBox35.Controls.Add(Me.btnDisplayLogRecords)
        Me.GroupBox35.Controls.Add(Me.Label42)
        Me.GroupBox35.Controls.Add(Me.cboLoggingLevel)
        Me.GroupBox35.Controls.Add(Me.Label23)
        Me.GroupBox35.Controls.Add(Me.Label11)
        Me.GroupBox35.Controls.Add(Me.dtpEndingDate)
        Me.GroupBox35.Controls.Add(Me.dtpStartingDate)
        Me.GroupBox35.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox35.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox35.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox35.Name = "GroupBox35"
        Me.GroupBox35.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox35.Size = New System.Drawing.Size(1012, 149)
        Me.GroupBox35.TabIndex = 0
        Me.GroupBox35.TabStop = False
        Me.GroupBox35.Text = "Log Information"
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
        Me.lblMessage.AutoSize = True
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
        Me.lblIOParameters.AutoSize = True
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
        Me.lblFunctionName.AutoSize = True
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
        Me.lblClassName.AutoSize = True
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
        Me.lblAppName.AutoSize = True
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
        Me.btnDisplayLogRecords.UseVisualStyleBackColor = True
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(696, 82)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(121, 17)
        Me.Label42.TabIndex = 5
        Me.Label42.Text = "Logging Level <=:"
        '
        'cboLoggingLevel
        '
        Me.cboLoggingLevel.DataSource = Me.LoggingLevelEnumBindingSource
        Me.cboLoggingLevel.FormattingEnabled = True
        Me.cboLoggingLevel.Location = New System.Drawing.Point(835, 80)
        Me.cboLoggingLevel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboLoggingLevel.Name = "cboLoggingLevel"
        Me.cboLoggingLevel.Size = New System.Drawing.Size(175, 24)
        Me.cboLoggingLevel.TabIndex = 4
        '
        'LoggingLevelEnumBindingSource
        '
        Me.LoggingLevelEnumBindingSource.DataSource = GetType(Okuma.ApiLog2.LoggingLevelEnum)
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(356, 18)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(86, 17)
        Me.Label23.TabIndex = 3
        Me.Label23.Text = "Ending Date"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(5, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 17)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Starting Date"
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
        'tabAxis
        '
        Me.tabAxis.Controls.Add(Me.Label78)
        Me.tabAxis.Controls.Add(Me.txtCommandFeedrate)
        Me.tabAxis.Controls.Add(Me.Label77)
        Me.tabAxis.Controls.Add(Me.txtFeedrateOverride)
        Me.tabAxis.Controls.Add(Me.Label76)
        Me.tabAxis.Controls.Add(Me.cboWheelAxes)
        Me.tabAxis.Controls.Add(Me.Label75)
        Me.tabAxis.Controls.Add(Me.txtActualPositionWheelCoordinate)
        Me.tabAxis.Controls.Add(Me.Label9)
        Me.tabAxis.Controls.Add(Me.cboAxisDataUnit)
        Me.tabAxis.Controls.Add(Me.Label7)
        Me.tabAxis.Controls.Add(Me.txtFeedrateType)
        Me.tabAxis.Controls.Add(Me.Label6)
        Me.tabAxis.Controls.Add(Me.txtAxisFeedrate)
        Me.tabAxis.Controls.Add(Me.Label5)
        Me.tabAxis.Controls.Add(Me.txtPathFeedrate)
        Me.tabAxis.Controls.Add(Me.Label4)
        Me.tabAxis.Controls.Add(Me.txtAxisLoad)
        Me.tabAxis.Controls.Add(Me.Label3)
        Me.tabAxis.Controls.Add(Me.txtActualPositionMachineCoordinate)
        Me.tabAxis.Controls.Add(Me.Label2)
        Me.tabAxis.Controls.Add(Me.txtActualPositionProgramCoordinate)
        Me.tabAxis.Controls.Add(Me.Label1)
        Me.tabAxis.Controls.Add(Me.cboAxes)
        Me.tabAxis.Controls.Add(Me.btnAxisUpdate)
        Me.tabAxis.Location = New System.Drawing.Point(4, 25)
        Me.tabAxis.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabAxis.Name = "tabAxis"
        Me.tabAxis.Size = New System.Drawing.Size(1012, 555)
        Me.tabAxis.TabIndex = 2
        Me.tabAxis.Text = "Axis"
        Me.tabAxis.UseVisualStyleBackColor = True
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(13, 489)
        Me.Label78.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(132, 17)
        Me.Label78.TabIndex = 274
        Me.Label78.Text = "Command Feedrate"
        '
        'txtCommandFeedrate
        '
        Me.txtCommandFeedrate.Location = New System.Drawing.Point(269, 489)
        Me.txtCommandFeedrate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCommandFeedrate.Name = "txtCommandFeedrate"
        Me.txtCommandFeedrate.Size = New System.Drawing.Size(132, 22)
        Me.txtCommandFeedrate.TabIndex = 273
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(16, 433)
        Me.Label77.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(124, 17)
        Me.Label77.TabIndex = 272
        Me.Label77.Text = "Feedrate Override"
        '
        'txtFeedrateOverride
        '
        Me.txtFeedrateOverride.Location = New System.Drawing.Point(268, 433)
        Me.txtFeedrateOverride.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFeedrateOverride.Name = "txtFeedrateOverride"
        Me.txtFeedrateOverride.Size = New System.Drawing.Size(132, 22)
        Me.txtFeedrateOverride.TabIndex = 271
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(565, 54)
        Me.Label76.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(77, 17)
        Me.Label76.TabIndex = 270
        Me.Label76.Text = "Wheel Axis"
        '
        'cboWheelAxes
        '
        Me.cboWheelAxes.Location = New System.Drawing.Point(819, 54)
        Me.cboWheelAxes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboWheelAxes.Name = "cboWheelAxes"
        Me.cboWheelAxes.Size = New System.Drawing.Size(132, 24)
        Me.cboWheelAxes.TabIndex = 269
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(563, 113)
        Me.Label75.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(218, 17)
        Me.Label75.TabIndex = 268
        Me.Label75.Text = "Actual Position Wheel Coordinate"
        '
        'txtActualPositionWheelCoordinate
        '
        Me.txtActualPositionWheelCoordinate.Location = New System.Drawing.Point(819, 113)
        Me.txtActualPositionWheelCoordinate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtActualPositionWheelCoordinate.Name = "txtActualPositionWheelCoordinate"
        Me.txtActualPositionWheelCoordinate.Size = New System.Drawing.Size(132, 22)
        Me.txtActualPositionWheelCoordinate.TabIndex = 267
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(480, 4)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 17)
        Me.Label9.TabIndex = 266
        Me.Label9.Text = "Data Unit"
        '
        'cboAxisDataUnit
        '
        Me.cboAxisDataUnit.Location = New System.Drawing.Point(649, 7)
        Me.cboAxisDataUnit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboAxisDataUnit.Name = "cboAxisDataUnit"
        Me.cboAxisDataUnit.Size = New System.Drawing.Size(171, 24)
        Me.cboAxisDataUnit.TabIndex = 265
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 375)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 17)
        Me.Label7.TabIndex = 262
        Me.Label7.Text = "Feedrate Type"
        '
        'txtFeedrateType
        '
        Me.txtFeedrateType.Location = New System.Drawing.Point(269, 375)
        Me.txtFeedrateType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFeedrateType.Name = "txtFeedrateType"
        Me.txtFeedrateType.Size = New System.Drawing.Size(132, 22)
        Me.txtFeedrateType.TabIndex = 261
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 322)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(163, 17)
        Me.Label6.TabIndex = 260
        Me.Label6.Text = "Actual Feedrate Per Axis"
        '
        'txtAxisFeedrate
        '
        Me.txtAxisFeedrate.Location = New System.Drawing.Point(269, 322)
        Me.txtAxisFeedrate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAxisFeedrate.Name = "txtAxisFeedrate"
        Me.txtAxisFeedrate.Size = New System.Drawing.Size(132, 22)
        Me.txtAxisFeedrate.TabIndex = 259
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 270)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 17)
        Me.Label5.TabIndex = 258
        Me.Label5.Text = "Path Feedrate"
        '
        'txtPathFeedrate
        '
        Me.txtPathFeedrate.Location = New System.Drawing.Point(269, 270)
        Me.txtPathFeedrate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPathFeedrate.Name = "txtPathFeedrate"
        Me.txtPathFeedrate.Size = New System.Drawing.Size(132, 22)
        Me.txtPathFeedrate.TabIndex = 257
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 217)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 17)
        Me.Label4.TabIndex = 256
        Me.Label4.Text = "Axis Load"
        '
        'txtAxisLoad
        '
        Me.txtAxisLoad.Location = New System.Drawing.Point(269, 217)
        Me.txtAxisLoad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAxisLoad.Name = "txtAxisLoad"
        Me.txtAxisLoad.Size = New System.Drawing.Size(132, 22)
        Me.txtAxisLoad.TabIndex = 255
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 161)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(231, 17)
        Me.Label3.TabIndex = 254
        Me.Label3.Text = "Actual Position Machine Coordinate"
        '
        'txtActualPositionMachineCoordinate
        '
        Me.txtActualPositionMachineCoordinate.Location = New System.Drawing.Point(268, 161)
        Me.txtActualPositionMachineCoordinate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtActualPositionMachineCoordinate.Name = "txtActualPositionMachineCoordinate"
        Me.txtActualPositionMachineCoordinate.Size = New System.Drawing.Size(132, 22)
        Me.txtActualPositionMachineCoordinate.TabIndex = 253
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 108)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(232, 17)
        Me.Label2.TabIndex = 252
        Me.Label2.Text = "Actual Position Program Coordinate"
        '
        'txtActualPositionProgramCoordinate
        '
        Me.txtActualPositionProgramCoordinate.Location = New System.Drawing.Point(268, 108)
        Me.txtActualPositionProgramCoordinate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtActualPositionProgramCoordinate.Name = "txtActualPositionProgramCoordinate"
        Me.txtActualPositionProgramCoordinate.Size = New System.Drawing.Size(132, 22)
        Me.txtActualPositionProgramCoordinate.TabIndex = 251
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 54)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 17)
        Me.Label1.TabIndex = 250
        Me.Label1.Text = "Axis"
        '
        'cboAxes
        '
        Me.cboAxes.Location = New System.Drawing.Point(268, 54)
        Me.cboAxes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboAxes.Name = "cboAxes"
        Me.cboAxes.Size = New System.Drawing.Size(132, 24)
        Me.cboAxes.TabIndex = 249
        '
        'btnAxisUpdate
        '
        Me.btnAxisUpdate.Location = New System.Drawing.Point(4, 4)
        Me.btnAxisUpdate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAxisUpdate.Name = "btnAxisUpdate"
        Me.btnAxisUpdate.Size = New System.Drawing.Size(107, 34)
        Me.btnAxisUpdate.TabIndex = 248
        Me.btnAxisUpdate.Text = "Update"
        '
        'tabMachine
        '
        Me.tabMachine.Controls.Add(Me.Label79)
        Me.tabMachine.Controls.Add(Me.cboAllLoggignLevel)
        Me.tabMachine.Controls.Add(Me.Panel5)
        Me.tabMachine.Controls.Add(Me.Panel3)
        Me.tabMachine.Controls.Add(Me.txtMachine)
        Me.tabMachine.Controls.Add(Me.Label165)
        Me.tabMachine.Controls.Add(Me.machineUpdateButton)
        Me.tabMachine.Location = New System.Drawing.Point(4, 25)
        Me.tabMachine.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabMachine.Name = "tabMachine"
        Me.tabMachine.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabMachine.Size = New System.Drawing.Size(1012, 555)
        Me.tabMachine.TabIndex = 0
        Me.tabMachine.Text = "Machine"
        Me.tabMachine.UseVisualStyleBackColor = True
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(624, 257)
        Me.Label79.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(215, 17)
        Me.Label79.TabIndex = 253
        Me.Label79.Text = "Set Loggign Level To All objects:"
        '
        'cboAllLoggignLevel
        '
        Me.cboAllLoggignLevel.FormattingEnabled = True
        Me.cboAllLoggignLevel.Location = New System.Drawing.Point(624, 281)
        Me.cboAllLoggignLevel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboAllLoggignLevel.Name = "cboAllLoggignLevel"
        Me.cboAllLoggignLevel.Size = New System.Drawing.Size(215, 24)
        Me.cboAllLoggignLevel.TabIndex = 252
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.btnHMCount_Add)
        Me.Panel5.Controls.Add(Me.Label333)
        Me.Panel5.Controls.Add(Me.btnHMCount_Set)
        Me.Panel5.Controls.Add(Me.txtHMCount)
        Me.Panel5.Controls.Add(Me.txtHMCountValue)
        Me.Panel5.Controls.Add(Me.btnHMCount_Get)
        Me.Panel5.Controls.Add(Me.cboHMCount)
        Me.Panel5.Location = New System.Drawing.Point(612, 137)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(383, 83)
        Me.Panel5.TabIndex = 251
        '
        'btnHMCount_Add
        '
        Me.btnHMCount_Add.Location = New System.Drawing.Point(317, 9)
        Me.btnHMCount_Add.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnHMCount_Add.Name = "btnHMCount_Add"
        Me.btnHMCount_Add.Size = New System.Drawing.Size(57, 27)
        Me.btnHMCount_Add.TabIndex = 176
        Me.btnHMCount_Add.Text = "Add"
        '
        'Label333
        '
        Me.Label333.Location = New System.Drawing.Point(0, 18)
        Me.Label333.Name = "Label333"
        Me.Label333.Size = New System.Drawing.Size(181, 18)
        Me.Label333.TabIndex = 175
        Me.Label333.Text = "Hour Meter Count:"
        '
        'btnHMCount_Set
        '
        Me.btnHMCount_Set.Location = New System.Drawing.Point(259, 9)
        Me.btnHMCount_Set.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnHMCount_Set.Name = "btnHMCount_Set"
        Me.btnHMCount_Set.Size = New System.Drawing.Size(48, 28)
        Me.btnHMCount_Set.TabIndex = 167
        Me.btnHMCount_Set.Text = "Set"
        '
        'txtHMCount
        '
        Me.txtHMCount.Enabled = False
        Me.txtHMCount.Location = New System.Drawing.Point(11, 46)
        Me.txtHMCount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtHMCount.Name = "txtHMCount"
        Me.txtHMCount.ReadOnly = True
        Me.txtHMCount.Size = New System.Drawing.Size(76, 22)
        Me.txtHMCount.TabIndex = 166
        Me.txtHMCount.Text = "0"
        '
        'txtHMCountValue
        '
        Me.txtHMCountValue.ForeColor = System.Drawing.Color.Red
        Me.txtHMCountValue.Location = New System.Drawing.Point(107, 46)
        Me.txtHMCountValue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtHMCountValue.Name = "txtHMCountValue"
        Me.txtHMCountValue.Size = New System.Drawing.Size(76, 22)
        Me.txtHMCountValue.TabIndex = 164
        Me.txtHMCountValue.Text = "0"
        '
        'btnHMCount_Get
        '
        Me.btnHMCount_Get.Location = New System.Drawing.Point(203, 9)
        Me.btnHMCount_Get.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnHMCount_Get.Name = "btnHMCount_Get"
        Me.btnHMCount_Get.Size = New System.Drawing.Size(48, 28)
        Me.btnHMCount_Get.TabIndex = 174
        Me.btnHMCount_Get.Text = "Get"
        '
        'cboHMCount
        '
        Me.cboHMCount.Location = New System.Drawing.Point(203, 46)
        Me.cboHMCount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboHMCount.Name = "cboHMCount"
        Me.cboHMCount.Size = New System.Drawing.Size(172, 24)
        Me.cboHMCount.TabIndex = 163
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnHMSet_Add)
        Me.Panel3.Controls.Add(Me.Label332)
        Me.Panel3.Controls.Add(Me.btnHMSet_Set)
        Me.Panel3.Controls.Add(Me.txtHMSet)
        Me.Panel3.Controls.Add(Me.txtHMSetValue)
        Me.Panel3.Controls.Add(Me.btnHMSet_Get)
        Me.Panel3.Controls.Add(Me.cboHMSet)
        Me.Panel3.Location = New System.Drawing.Point(612, 44)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(383, 83)
        Me.Panel3.TabIndex = 250
        '
        'btnHMSet_Add
        '
        Me.btnHMSet_Add.Location = New System.Drawing.Point(317, 9)
        Me.btnHMSet_Add.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnHMSet_Add.Name = "btnHMSet_Add"
        Me.btnHMSet_Add.Size = New System.Drawing.Size(57, 27)
        Me.btnHMSet_Add.TabIndex = 176
        Me.btnHMSet_Add.Text = "Add"
        '
        'Label332
        '
        Me.Label332.Location = New System.Drawing.Point(0, 18)
        Me.Label332.Name = "Label332"
        Me.Label332.Size = New System.Drawing.Size(181, 18)
        Me.Label332.TabIndex = 175
        Me.Label332.Text = "Hour Meter Set:"
        '
        'btnHMSet_Set
        '
        Me.btnHMSet_Set.Location = New System.Drawing.Point(259, 9)
        Me.btnHMSet_Set.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnHMSet_Set.Name = "btnHMSet_Set"
        Me.btnHMSet_Set.Size = New System.Drawing.Size(48, 28)
        Me.btnHMSet_Set.TabIndex = 167
        Me.btnHMSet_Set.Text = "Set"
        '
        'txtHMSet
        '
        Me.txtHMSet.Enabled = False
        Me.txtHMSet.Location = New System.Drawing.Point(11, 46)
        Me.txtHMSet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtHMSet.Name = "txtHMSet"
        Me.txtHMSet.ReadOnly = True
        Me.txtHMSet.Size = New System.Drawing.Size(76, 22)
        Me.txtHMSet.TabIndex = 166
        Me.txtHMSet.Text = "0"
        '
        'txtHMSetValue
        '
        Me.txtHMSetValue.ForeColor = System.Drawing.Color.Red
        Me.txtHMSetValue.Location = New System.Drawing.Point(107, 46)
        Me.txtHMSetValue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtHMSetValue.Name = "txtHMSetValue"
        Me.txtHMSetValue.Size = New System.Drawing.Size(76, 22)
        Me.txtHMSetValue.TabIndex = 164
        Me.txtHMSetValue.Text = "0"
        '
        'btnHMSet_Get
        '
        Me.btnHMSet_Get.Location = New System.Drawing.Point(203, 9)
        Me.btnHMSet_Get.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnHMSet_Get.Name = "btnHMSet_Get"
        Me.btnHMSet_Get.Size = New System.Drawing.Size(48, 28)
        Me.btnHMSet_Get.TabIndex = 174
        Me.btnHMSet_Get.Text = "Get"
        '
        'cboHMSet
        '
        Me.cboHMSet.Location = New System.Drawing.Point(203, 46)
        Me.cboHMSet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboHMSet.Name = "cboHMSet"
        Me.cboHMSet.Size = New System.Drawing.Size(172, 24)
        Me.cboHMSet.TabIndex = 163
        '
        'txtMachine
        '
        Me.txtMachine.Location = New System.Drawing.Point(4, 44)
        Me.txtMachine.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtMachine.Multiline = True
        Me.txtMachine.Name = "txtMachine"
        Me.txtMachine.Size = New System.Drawing.Size(601, 494)
        Me.txtMachine.TabIndex = 249
        '
        'Label165
        '
        Me.Label165.Location = New System.Drawing.Point(-135, 31)
        Me.Label165.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label165.Name = "Label165"
        Me.Label165.Size = New System.Drawing.Size(121, 20)
        Me.Label165.TabIndex = 246
        Me.Label165.Text = "Sub System : "
        '
        'machineUpdateButton
        '
        Me.machineUpdateButton.Location = New System.Drawing.Point(8, 7)
        Me.machineUpdateButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.machineUpdateButton.Name = "machineUpdateButton"
        Me.machineUpdateButton.Size = New System.Drawing.Size(151, 30)
        Me.machineUpdateButton.TabIndex = 245
        Me.machineUpdateButton.Text = "Update"
        '
        'tabPLCIO
        '
        Me.tabPLCIO.Controls.Add(Me.GroupBox36)
        Me.tabPLCIO.Controls.Add(Me.GroupBox16)
        Me.tabPLCIO.Controls.Add(Me.GroupBox17)
        Me.tabPLCIO.Controls.Add(Me.GroupBox18)
        Me.tabPLCIO.Controls.Add(Me.GroupBox15)
        Me.tabPLCIO.Controls.Add(Me.GroupBox14)
        Me.tabPLCIO.Controls.Add(Me.GroupBox13)
        Me.tabPLCIO.Controls.Add(Me.GroupBox12)
        Me.tabPLCIO.Controls.Add(Me.GroupBox11)
        Me.tabPLCIO.Controls.Add(Me.GroupBox9)
        Me.tabPLCIO.Location = New System.Drawing.Point(4, 25)
        Me.tabPLCIO.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tabPLCIO.Name = "tabPLCIO"
        Me.tabPLCIO.Size = New System.Drawing.Size(1012, 555)
        Me.tabPLCIO.TabIndex = 8
        Me.tabPLCIO.Text = "PLC I/O"
        Me.tabPLCIO.UseVisualStyleBackColor = True
        '
        'GroupBox36
        '
        Me.GroupBox36.Controls.Add(Me.btnGetIOLabel)
        Me.GroupBox36.Controls.Add(Me.Label297)
        Me.GroupBox36.Controls.Add(Me.txtIOLabel)
        Me.GroupBox36.Controls.Add(Me.cboIOVariableTypes)
        Me.GroupBox36.Location = New System.Drawing.Point(603, 11)
        Me.GroupBox36.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox36.Name = "GroupBox36"
        Me.GroupBox36.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox36.Size = New System.Drawing.Size(413, 103)
        Me.GroupBox36.TabIndex = 376
        Me.GroupBox36.TabStop = False
        Me.GroupBox36.Text = "PLC I/O by Label"
        '
        'btnGetIOLabel
        '
        Me.btnGetIOLabel.Location = New System.Drawing.Point(5, 66)
        Me.btnGetIOLabel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGetIOLabel.Name = "btnGetIOLabel"
        Me.btnGetIOLabel.Size = New System.Drawing.Size(179, 28)
        Me.btnGetIOLabel.TabIndex = 372
        Me.btnGetIOLabel.Text = "Get I/O Value by label"
        '
        'Label297
        '
        Me.Label297.Location = New System.Drawing.Point(9, 21)
        Me.Label297.Name = "Label297"
        Me.Label297.Size = New System.Drawing.Size(144, 28)
        Me.Label297.TabIndex = 375
        Me.Label297.Text = "I/O Variables Type:"
        '
        'txtIOLabel
        '
        Me.txtIOLabel.ForeColor = System.Drawing.Color.Blue
        Me.txtIOLabel.Location = New System.Drawing.Point(193, 66)
        Me.txtIOLabel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtIOLabel.Name = "txtIOLabel"
        Me.txtIOLabel.Size = New System.Drawing.Size(115, 22)
        Me.txtIOLabel.TabIndex = 373
        '
        'cboIOVariableTypes
        '
        Me.cboIOVariableTypes.Location = New System.Drawing.Point(193, 21)
        Me.cboIOVariableTypes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboIOVariableTypes.Name = "cboIOVariableTypes"
        Me.cboIOVariableTypes.Size = New System.Drawing.Size(196, 24)
        Me.cboIOVariableTypes.TabIndex = 374
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.Label65)
        Me.GroupBox16.Controls.Add(Me.txtULongWordValue)
        Me.GroupBox16.Controls.Add(Me.btnSetULongWord)
        Me.GroupBox16.Controls.Add(Me.txtULongWordData)
        Me.GroupBox16.Controls.Add(Me.Label66)
        Me.GroupBox16.Controls.Add(Me.btnGetULongWord)
        Me.GroupBox16.Controls.Add(Me.txtULongWordAddress)
        Me.GroupBox16.Location = New System.Drawing.Point(501, 430)
        Me.GroupBox16.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox16.Size = New System.Drawing.Size(491, 85)
        Me.GroupBox16.TabIndex = 371
        Me.GroupBox16.TabStop = False
        Me.GroupBox16.Text = "U Long Word"
        Me.GroupBox16.Visible = False
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(299, 18)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(44, 17)
        Me.Label65.TabIndex = 349
        Me.Label65.Text = "Value"
        '
        'txtULongWordValue
        '
        Me.txtULongWordValue.ForeColor = System.Drawing.Color.Red
        Me.txtULongWordValue.Location = New System.Drawing.Point(301, 49)
        Me.txtULongWordValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtULongWordValue.Name = "txtULongWordValue"
        Me.txtULongWordValue.Size = New System.Drawing.Size(140, 22)
        Me.txtULongWordValue.TabIndex = 348
        Me.txtULongWordValue.Text = "0"
        '
        'btnSetULongWord
        '
        Me.btnSetULongWord.Location = New System.Drawing.Point(59, 49)
        Me.btnSetULongWord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSetULongWord.Name = "btnSetULongWord"
        Me.btnSetULongWord.Size = New System.Drawing.Size(47, 30)
        Me.btnSetULongWord.TabIndex = 347
        Me.btnSetULongWord.Text = "Set"
        '
        'txtULongWordData
        '
        Me.txtULongWordData.ForeColor = System.Drawing.Color.Blue
        Me.txtULongWordData.Location = New System.Drawing.Point(117, 49)
        Me.txtULongWordData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtULongWordData.Name = "txtULongWordData"
        Me.txtULongWordData.ReadOnly = True
        Me.txtULongWordData.Size = New System.Drawing.Size(92, 22)
        Me.txtULongWordData.TabIndex = 346
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(213, 18)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(60, 17)
        Me.Label66.TabIndex = 344
        Me.Label66.Text = "Address"
        '
        'btnGetULongWord
        '
        Me.btnGetULongWord.Location = New System.Drawing.Point(5, 49)
        Me.btnGetULongWord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGetULongWord.Name = "btnGetULongWord"
        Me.btnGetULongWord.Size = New System.Drawing.Size(47, 30)
        Me.btnGetULongWord.TabIndex = 340
        Me.btnGetULongWord.Text = "Get"
        '
        'txtULongWordAddress
        '
        Me.txtULongWordAddress.ForeColor = System.Drawing.Color.Red
        Me.txtULongWordAddress.Location = New System.Drawing.Point(217, 49)
        Me.txtULongWordAddress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtULongWordAddress.Name = "txtULongWordAddress"
        Me.txtULongWordAddress.Size = New System.Drawing.Size(76, 22)
        Me.txtULongWordAddress.TabIndex = 324
        Me.txtULongWordAddress.Text = "0"
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.Label67)
        Me.GroupBox17.Controls.Add(Me.txtUWordValue)
        Me.GroupBox17.Controls.Add(Me.btnSetUWord)
        Me.GroupBox17.Controls.Add(Me.txtUWordData)
        Me.GroupBox17.Controls.Add(Me.Label68)
        Me.GroupBox17.Controls.Add(Me.btnGetUWord)
        Me.GroupBox17.Controls.Add(Me.txtUWordAddress)
        Me.GroupBox17.Location = New System.Drawing.Point(501, 342)
        Me.GroupBox17.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox17.Size = New System.Drawing.Size(491, 85)
        Me.GroupBox17.TabIndex = 370
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "U Word"
        Me.GroupBox17.Visible = False
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(299, 18)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(44, 17)
        Me.Label67.TabIndex = 349
        Me.Label67.Text = "Value"
        '
        'txtUWordValue
        '
        Me.txtUWordValue.ForeColor = System.Drawing.Color.Red
        Me.txtUWordValue.Location = New System.Drawing.Point(301, 49)
        Me.txtUWordValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUWordValue.Name = "txtUWordValue"
        Me.txtUWordValue.Size = New System.Drawing.Size(140, 22)
        Me.txtUWordValue.TabIndex = 348
        Me.txtUWordValue.Text = "0"
        '
        'btnSetUWord
        '
        Me.btnSetUWord.Location = New System.Drawing.Point(59, 49)
        Me.btnSetUWord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSetUWord.Name = "btnSetUWord"
        Me.btnSetUWord.Size = New System.Drawing.Size(47, 30)
        Me.btnSetUWord.TabIndex = 347
        Me.btnSetUWord.Text = "Set"
        '
        'txtUWordData
        '
        Me.txtUWordData.ForeColor = System.Drawing.Color.Blue
        Me.txtUWordData.Location = New System.Drawing.Point(117, 49)
        Me.txtUWordData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUWordData.Name = "txtUWordData"
        Me.txtUWordData.ReadOnly = True
        Me.txtUWordData.Size = New System.Drawing.Size(92, 22)
        Me.txtUWordData.TabIndex = 346
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(213, 18)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(60, 17)
        Me.Label68.TabIndex = 344
        Me.Label68.Text = "Address"
        '
        'btnGetUWord
        '
        Me.btnGetUWord.Location = New System.Drawing.Point(5, 49)
        Me.btnGetUWord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGetUWord.Name = "btnGetUWord"
        Me.btnGetUWord.Size = New System.Drawing.Size(47, 30)
        Me.btnGetUWord.TabIndex = 340
        Me.btnGetUWord.Text = "Get"
        '
        'txtUWordAddress
        '
        Me.txtUWordAddress.ForeColor = System.Drawing.Color.Red
        Me.txtUWordAddress.Location = New System.Drawing.Point(217, 49)
        Me.txtUWordAddress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUWordAddress.Name = "txtUWordAddress"
        Me.txtUWordAddress.Size = New System.Drawing.Size(76, 22)
        Me.txtUWordAddress.TabIndex = 324
        Me.txtUWordAddress.Text = "0"
        '
        'GroupBox18
        '
        Me.GroupBox18.Controls.Add(Me.Label69)
        Me.GroupBox18.Controls.Add(Me.txtUBitValue)
        Me.GroupBox18.Controls.Add(Me.btnSetUBit)
        Me.GroupBox18.Controls.Add(Me.txtUBitData)
        Me.GroupBox18.Controls.Add(Me.Label70)
        Me.GroupBox18.Controls.Add(Me.Label71)
        Me.GroupBox18.Controls.Add(Me.txtUBit)
        Me.GroupBox18.Controls.Add(Me.btnGetUBit)
        Me.GroupBox18.Controls.Add(Me.txtUBitAddress)
        Me.GroupBox18.Location = New System.Drawing.Point(501, 256)
        Me.GroupBox18.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox18.Size = New System.Drawing.Size(491, 85)
        Me.GroupBox18.TabIndex = 369
        Me.GroupBox18.TabStop = False
        Me.GroupBox18.Text = "U Bit"
        Me.GroupBox18.Visible = False
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(387, 18)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(44, 17)
        Me.Label69.TabIndex = 349
        Me.Label69.Text = "Value"
        '
        'txtUBitValue
        '
        Me.txtUBitValue.ForeColor = System.Drawing.Color.Red
        Me.txtUBitValue.Location = New System.Drawing.Point(389, 49)
        Me.txtUBitValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUBitValue.Name = "txtUBitValue"
        Me.txtUBitValue.Size = New System.Drawing.Size(92, 22)
        Me.txtUBitValue.TabIndex = 348
        Me.txtUBitValue.Text = "0"
        '
        'btnSetUBit
        '
        Me.btnSetUBit.Location = New System.Drawing.Point(59, 49)
        Me.btnSetUBit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSetUBit.Name = "btnSetUBit"
        Me.btnSetUBit.Size = New System.Drawing.Size(47, 30)
        Me.btnSetUBit.TabIndex = 347
        Me.btnSetUBit.Text = "Set"
        '
        'txtUBitData
        '
        Me.txtUBitData.ForeColor = System.Drawing.Color.Blue
        Me.txtUBitData.Location = New System.Drawing.Point(117, 49)
        Me.txtUBitData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUBitData.Name = "txtUBitData"
        Me.txtUBitData.ReadOnly = True
        Me.txtUBitData.Size = New System.Drawing.Size(92, 22)
        Me.txtUBitData.TabIndex = 346
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(299, 18)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(24, 17)
        Me.Label70.TabIndex = 345
        Me.Label70.Text = "Bit"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(213, 18)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(60, 17)
        Me.Label71.TabIndex = 344
        Me.Label71.Text = "Address"
        '
        'txtUBit
        '
        Me.txtUBit.ForeColor = System.Drawing.Color.Red
        Me.txtUBit.Location = New System.Drawing.Point(301, 49)
        Me.txtUBit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUBit.Name = "txtUBit"
        Me.txtUBit.Size = New System.Drawing.Size(76, 22)
        Me.txtUBit.TabIndex = 343
        Me.txtUBit.Text = "0"
        '
        'btnGetUBit
        '
        Me.btnGetUBit.Location = New System.Drawing.Point(5, 49)
        Me.btnGetUBit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGetUBit.Name = "btnGetUBit"
        Me.btnGetUBit.Size = New System.Drawing.Size(47, 30)
        Me.btnGetUBit.TabIndex = 340
        Me.btnGetUBit.Text = "Get"
        '
        'txtUBitAddress
        '
        Me.txtUBitAddress.ForeColor = System.Drawing.Color.Red
        Me.txtUBitAddress.Location = New System.Drawing.Point(217, 49)
        Me.txtUBitAddress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUBitAddress.Name = "txtUBitAddress"
        Me.txtUBitAddress.Size = New System.Drawing.Size(76, 22)
        Me.txtUBitAddress.TabIndex = 324
        Me.txtUBitAddress.Text = "0"
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.Label61)
        Me.GroupBox15.Controls.Add(Me.txtGLongWordValue)
        Me.GroupBox15.Controls.Add(Me.btnSetGLongWord)
        Me.GroupBox15.Controls.Add(Me.txtGLongWordData)
        Me.GroupBox15.Controls.Add(Me.Label64)
        Me.GroupBox15.Controls.Add(Me.btnGetGLongWord)
        Me.GroupBox15.Controls.Add(Me.txtGLongWordAddress)
        Me.GroupBox15.Location = New System.Drawing.Point(4, 430)
        Me.GroupBox15.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox15.Size = New System.Drawing.Size(491, 85)
        Me.GroupBox15.TabIndex = 368
        Me.GroupBox15.TabStop = False
        Me.GroupBox15.Text = "G Long Word"
        Me.GroupBox15.Visible = False
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(299, 18)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(44, 17)
        Me.Label61.TabIndex = 349
        Me.Label61.Text = "Value"
        '
        'txtGLongWordValue
        '
        Me.txtGLongWordValue.ForeColor = System.Drawing.Color.Red
        Me.txtGLongWordValue.Location = New System.Drawing.Point(301, 49)
        Me.txtGLongWordValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtGLongWordValue.Name = "txtGLongWordValue"
        Me.txtGLongWordValue.Size = New System.Drawing.Size(129, 22)
        Me.txtGLongWordValue.TabIndex = 348
        Me.txtGLongWordValue.Text = "0"
        '
        'btnSetGLongWord
        '
        Me.btnSetGLongWord.Location = New System.Drawing.Point(59, 49)
        Me.btnSetGLongWord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSetGLongWord.Name = "btnSetGLongWord"
        Me.btnSetGLongWord.Size = New System.Drawing.Size(47, 30)
        Me.btnSetGLongWord.TabIndex = 347
        Me.btnSetGLongWord.Text = "Set"
        '
        'txtGLongWordData
        '
        Me.txtGLongWordData.ForeColor = System.Drawing.Color.Blue
        Me.txtGLongWordData.Location = New System.Drawing.Point(117, 49)
        Me.txtGLongWordData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtGLongWordData.Name = "txtGLongWordData"
        Me.txtGLongWordData.ReadOnly = True
        Me.txtGLongWordData.Size = New System.Drawing.Size(92, 22)
        Me.txtGLongWordData.TabIndex = 346
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(213, 18)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(60, 17)
        Me.Label64.TabIndex = 344
        Me.Label64.Text = "Address"
        '
        'btnGetGLongWord
        '
        Me.btnGetGLongWord.Location = New System.Drawing.Point(5, 49)
        Me.btnGetGLongWord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGetGLongWord.Name = "btnGetGLongWord"
        Me.btnGetGLongWord.Size = New System.Drawing.Size(47, 30)
        Me.btnGetGLongWord.TabIndex = 340
        Me.btnGetGLongWord.Text = "Get"
        '
        'txtGLongWordAddress
        '
        Me.txtGLongWordAddress.ForeColor = System.Drawing.Color.Red
        Me.txtGLongWordAddress.Location = New System.Drawing.Point(217, 49)
        Me.txtGLongWordAddress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtGLongWordAddress.Name = "txtGLongWordAddress"
        Me.txtGLongWordAddress.Size = New System.Drawing.Size(76, 22)
        Me.txtGLongWordAddress.TabIndex = 324
        Me.txtGLongWordAddress.Text = "0"
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.Label58)
        Me.GroupBox14.Controls.Add(Me.txtGWordValue)
        Me.GroupBox14.Controls.Add(Me.btnSetGWord)
        Me.GroupBox14.Controls.Add(Me.txtGWordData)
        Me.GroupBox14.Controls.Add(Me.Label63)
        Me.GroupBox14.Controls.Add(Me.btnGetGWord)
        Me.GroupBox14.Controls.Add(Me.txtGWordAddress)
        Me.GroupBox14.Location = New System.Drawing.Point(4, 342)
        Me.GroupBox14.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox14.Size = New System.Drawing.Size(491, 85)
        Me.GroupBox14.TabIndex = 367
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "G Word"
        Me.GroupBox14.Visible = False
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(299, 18)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(44, 17)
        Me.Label58.TabIndex = 349
        Me.Label58.Text = "Value"
        '
        'txtGWordValue
        '
        Me.txtGWordValue.ForeColor = System.Drawing.Color.Red
        Me.txtGWordValue.Location = New System.Drawing.Point(301, 49)
        Me.txtGWordValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtGWordValue.Name = "txtGWordValue"
        Me.txtGWordValue.Size = New System.Drawing.Size(129, 22)
        Me.txtGWordValue.TabIndex = 348
        Me.txtGWordValue.Text = " 0"
        '
        'btnSetGWord
        '
        Me.btnSetGWord.Location = New System.Drawing.Point(59, 49)
        Me.btnSetGWord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSetGWord.Name = "btnSetGWord"
        Me.btnSetGWord.Size = New System.Drawing.Size(47, 30)
        Me.btnSetGWord.TabIndex = 347
        Me.btnSetGWord.Text = "Set"
        '
        'txtGWordData
        '
        Me.txtGWordData.ForeColor = System.Drawing.Color.Blue
        Me.txtGWordData.Location = New System.Drawing.Point(117, 49)
        Me.txtGWordData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtGWordData.Name = "txtGWordData"
        Me.txtGWordData.ReadOnly = True
        Me.txtGWordData.Size = New System.Drawing.Size(92, 22)
        Me.txtGWordData.TabIndex = 346
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(213, 18)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(60, 17)
        Me.Label63.TabIndex = 344
        Me.Label63.Text = "Address"
        '
        'btnGetGWord
        '
        Me.btnGetGWord.Location = New System.Drawing.Point(5, 49)
        Me.btnGetGWord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGetGWord.Name = "btnGetGWord"
        Me.btnGetGWord.Size = New System.Drawing.Size(47, 30)
        Me.btnGetGWord.TabIndex = 340
        Me.btnGetGWord.Text = "Get"
        '
        'txtGWordAddress
        '
        Me.txtGWordAddress.ForeColor = System.Drawing.Color.Red
        Me.txtGWordAddress.Location = New System.Drawing.Point(217, 49)
        Me.txtGWordAddress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtGWordAddress.Name = "txtGWordAddress"
        Me.txtGWordAddress.Size = New System.Drawing.Size(76, 22)
        Me.txtGWordAddress.TabIndex = 324
        Me.txtGWordAddress.Text = "0"
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.Label62)
        Me.GroupBox13.Controls.Add(Me.txtGBitValue)
        Me.GroupBox13.Controls.Add(Me.btnSetGBit)
        Me.GroupBox13.Controls.Add(Me.txtGBitData)
        Me.GroupBox13.Controls.Add(Me.Label59)
        Me.GroupBox13.Controls.Add(Me.Label60)
        Me.GroupBox13.Controls.Add(Me.txtGBit)
        Me.GroupBox13.Controls.Add(Me.btnGetGBit)
        Me.GroupBox13.Controls.Add(Me.txtGBitAddress)
        Me.GroupBox13.Location = New System.Drawing.Point(4, 256)
        Me.GroupBox13.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox13.Size = New System.Drawing.Size(491, 85)
        Me.GroupBox13.TabIndex = 366
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "G Bit"
        Me.GroupBox13.Visible = False
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(387, 18)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(44, 17)
        Me.Label62.TabIndex = 349
        Me.Label62.Text = "Value"
        '
        'txtGBitValue
        '
        Me.txtGBitValue.ForeColor = System.Drawing.Color.Red
        Me.txtGBitValue.Location = New System.Drawing.Point(389, 49)
        Me.txtGBitValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtGBitValue.Name = "txtGBitValue"
        Me.txtGBitValue.Size = New System.Drawing.Size(92, 22)
        Me.txtGBitValue.TabIndex = 348
        Me.txtGBitValue.Text = "0"
        '
        'btnSetGBit
        '
        Me.btnSetGBit.Location = New System.Drawing.Point(59, 49)
        Me.btnSetGBit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSetGBit.Name = "btnSetGBit"
        Me.btnSetGBit.Size = New System.Drawing.Size(47, 30)
        Me.btnSetGBit.TabIndex = 347
        Me.btnSetGBit.Text = "Set"
        '
        'txtGBitData
        '
        Me.txtGBitData.ForeColor = System.Drawing.Color.Blue
        Me.txtGBitData.Location = New System.Drawing.Point(117, 49)
        Me.txtGBitData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtGBitData.Name = "txtGBitData"
        Me.txtGBitData.ReadOnly = True
        Me.txtGBitData.Size = New System.Drawing.Size(92, 22)
        Me.txtGBitData.TabIndex = 346
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(299, 18)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(24, 17)
        Me.Label59.TabIndex = 345
        Me.Label59.Text = "Bit"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(213, 18)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(60, 17)
        Me.Label60.TabIndex = 344
        Me.Label60.Text = "Address"
        '
        'txtGBit
        '
        Me.txtGBit.ForeColor = System.Drawing.Color.Red
        Me.txtGBit.Location = New System.Drawing.Point(301, 49)
        Me.txtGBit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtGBit.Name = "txtGBit"
        Me.txtGBit.Size = New System.Drawing.Size(76, 22)
        Me.txtGBit.TabIndex = 343
        Me.txtGBit.Text = "0"
        '
        'btnGetGBit
        '
        Me.btnGetGBit.Location = New System.Drawing.Point(5, 49)
        Me.btnGetGBit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGetGBit.Name = "btnGetGBit"
        Me.btnGetGBit.Size = New System.Drawing.Size(47, 30)
        Me.btnGetGBit.TabIndex = 340
        Me.btnGetGBit.Text = "Get"
        '
        'txtGBitAddress
        '
        Me.txtGBitAddress.ForeColor = System.Drawing.Color.Red
        Me.txtGBitAddress.Location = New System.Drawing.Point(217, 49)
        Me.txtGBitAddress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtGBitAddress.Name = "txtGBitAddress"
        Me.txtGBitAddress.Size = New System.Drawing.Size(76, 22)
        Me.txtGBitAddress.TabIndex = 324
        Me.txtGBitAddress.Text = "0"
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.txtIOLongWordLabel)
        Me.GroupBox12.Controls.Add(Me.cmdIOGetLongWordByLabel)
        Me.GroupBox12.Controls.Add(Me.Label56)
        Me.GroupBox12.Controls.Add(Me.txtPLCLongWordData)
        Me.GroupBox12.Controls.Add(Me.Label57)
        Me.GroupBox12.Controls.Add(Me.cboPLCLongWord)
        Me.GroupBox12.Controls.Add(Me.btnGetLongWord)
        Me.GroupBox12.Controls.Add(Me.txtPLCLongWordAddress)
        Me.GroupBox12.Location = New System.Drawing.Point(4, 172)
        Me.GroupBox12.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox12.Size = New System.Drawing.Size(592, 85)
        Me.GroupBox12.TabIndex = 365
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "PLC IO Long Word"
        '
        'txtIOLongWordLabel
        '
        Me.txtIOLongWordLabel.ForeColor = System.Drawing.Color.Blue
        Me.txtIOLongWordLabel.Location = New System.Drawing.Point(497, 50)
        Me.txtIOLongWordLabel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtIOLongWordLabel.Name = "txtIOLongWordLabel"
        Me.txtIOLongWordLabel.ReadOnly = True
        Me.txtIOLongWordLabel.Size = New System.Drawing.Size(88, 22)
        Me.txtIOLongWordLabel.TabIndex = 349
        '
        'cmdIOGetLongWordByLabel
        '
        Me.cmdIOGetLongWordByLabel.Location = New System.Drawing.Point(497, 15)
        Me.cmdIOGetLongWordByLabel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdIOGetLongWordByLabel.Name = "cmdIOGetLongWordByLabel"
        Me.cmdIOGetLongWordByLabel.Size = New System.Drawing.Size(85, 27)
        Me.cmdIOGetLongWordByLabel.TabIndex = 348
        Me.cmdIOGetLongWordByLabel.Text = "Get label"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(269, 18)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(62, 17)
        Me.Label56.TabIndex = 347
        Me.Label56.Text = "I/O Type"
        '
        'txtPLCLongWordData
        '
        Me.txtPLCLongWordData.ForeColor = System.Drawing.Color.Blue
        Me.txtPLCLongWordData.Location = New System.Drawing.Point(59, 50)
        Me.txtPLCLongWordData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPLCLongWordData.Name = "txtPLCLongWordData"
        Me.txtPLCLongWordData.ReadOnly = True
        Me.txtPLCLongWordData.Size = New System.Drawing.Size(115, 22)
        Me.txtPLCLongWordData.TabIndex = 346
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(184, 20)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(60, 17)
        Me.Label57.TabIndex = 344
        Me.Label57.Text = "Address"
        '
        'cboPLCLongWord
        '
        Me.cboPLCLongWord.Location = New System.Drawing.Point(272, 50)
        Me.cboPLCLongWord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboPLCLongWord.Name = "cboPLCLongWord"
        Me.cboPLCLongWord.Size = New System.Drawing.Size(127, 24)
        Me.cboPLCLongWord.TabIndex = 342
        '
        'btnGetLongWord
        '
        Me.btnGetLongWord.Location = New System.Drawing.Point(5, 46)
        Me.btnGetLongWord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGetLongWord.Name = "btnGetLongWord"
        Me.btnGetLongWord.Size = New System.Drawing.Size(47, 30)
        Me.btnGetLongWord.TabIndex = 340
        Me.btnGetLongWord.Text = "Get"
        '
        'txtPLCLongWordAddress
        '
        Me.txtPLCLongWordAddress.ForeColor = System.Drawing.Color.Red
        Me.txtPLCLongWordAddress.Location = New System.Drawing.Point(187, 50)
        Me.txtPLCLongWordAddress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPLCLongWordAddress.Name = "txtPLCLongWordAddress"
        Me.txtPLCLongWordAddress.Size = New System.Drawing.Size(76, 22)
        Me.txtPLCLongWordAddress.TabIndex = 324
        Me.txtPLCLongWordAddress.Text = "0"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.txtIOWordLabel)
        Me.GroupBox11.Controls.Add(Me.cmdIOGetWordByLabel)
        Me.GroupBox11.Controls.Add(Me.Label53)
        Me.GroupBox11.Controls.Add(Me.txtPLCWordData)
        Me.GroupBox11.Controls.Add(Me.Label54)
        Me.GroupBox11.Controls.Add(Me.cboPLCWord)
        Me.GroupBox11.Controls.Add(Me.btnGetWord)
        Me.GroupBox11.Controls.Add(Me.txtPLCWordAddress)
        Me.GroupBox11.Location = New System.Drawing.Point(4, 89)
        Me.GroupBox11.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox11.Size = New System.Drawing.Size(592, 85)
        Me.GroupBox11.TabIndex = 364
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "PLC IO Word"
        '
        'txtIOWordLabel
        '
        Me.txtIOWordLabel.ForeColor = System.Drawing.Color.Blue
        Me.txtIOWordLabel.Location = New System.Drawing.Point(497, 50)
        Me.txtIOWordLabel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtIOWordLabel.Name = "txtIOWordLabel"
        Me.txtIOWordLabel.ReadOnly = True
        Me.txtIOWordLabel.Size = New System.Drawing.Size(87, 22)
        Me.txtIOWordLabel.TabIndex = 349
        '
        'cmdIOGetWordByLabel
        '
        Me.cmdIOGetWordByLabel.Location = New System.Drawing.Point(497, 14)
        Me.cmdIOGetWordByLabel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdIOGetWordByLabel.Name = "cmdIOGetWordByLabel"
        Me.cmdIOGetWordByLabel.Size = New System.Drawing.Size(85, 28)
        Me.cmdIOGetWordByLabel.TabIndex = 348
        Me.cmdIOGetWordByLabel.Text = "Get label"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(269, 21)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(62, 17)
        Me.Label53.TabIndex = 347
        Me.Label53.Text = "I/O Type"
        '
        'txtPLCWordData
        '
        Me.txtPLCWordData.ForeColor = System.Drawing.Color.Blue
        Me.txtPLCWordData.Location = New System.Drawing.Point(59, 50)
        Me.txtPLCWordData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPLCWordData.Name = "txtPLCWordData"
        Me.txtPLCWordData.ReadOnly = True
        Me.txtPLCWordData.Size = New System.Drawing.Size(115, 22)
        Me.txtPLCWordData.TabIndex = 346
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(184, 20)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(60, 17)
        Me.Label54.TabIndex = 344
        Me.Label54.Text = "Address"
        '
        'cboPLCWord
        '
        Me.cboPLCWord.Location = New System.Drawing.Point(272, 50)
        Me.cboPLCWord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboPLCWord.Name = "cboPLCWord"
        Me.cboPLCWord.Size = New System.Drawing.Size(127, 24)
        Me.cboPLCWord.TabIndex = 342
        '
        'btnGetWord
        '
        Me.btnGetWord.Location = New System.Drawing.Point(5, 46)
        Me.btnGetWord.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGetWord.Name = "btnGetWord"
        Me.btnGetWord.Size = New System.Drawing.Size(47, 30)
        Me.btnGetWord.TabIndex = 340
        Me.btnGetWord.Text = "Get"
        '
        'txtPLCWordAddress
        '
        Me.txtPLCWordAddress.ForeColor = System.Drawing.Color.Red
        Me.txtPLCWordAddress.Location = New System.Drawing.Point(187, 50)
        Me.txtPLCWordAddress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPLCWordAddress.Name = "txtPLCWordAddress"
        Me.txtPLCWordAddress.Size = New System.Drawing.Size(76, 22)
        Me.txtPLCWordAddress.TabIndex = 324
        Me.txtPLCWordAddress.Text = "0"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.txtIOBitLabel)
        Me.GroupBox9.Controls.Add(Me.cmdIOGetBitByLabel)
        Me.GroupBox9.Controls.Add(Me.Label55)
        Me.GroupBox9.Controls.Add(Me.txtPLCBitData)
        Me.GroupBox9.Controls.Add(Me.Label47)
        Me.GroupBox9.Controls.Add(Me.Label44)
        Me.GroupBox9.Controls.Add(Me.txtPLCBit)
        Me.GroupBox9.Controls.Add(Me.cboPLCBit)
        Me.GroupBox9.Controls.Add(Me.btnGetBit)
        Me.GroupBox9.Controls.Add(Me.txtPLCBitAddress)
        Me.GroupBox9.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox9.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox9.Size = New System.Drawing.Size(592, 85)
        Me.GroupBox9.TabIndex = 363
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "PLC IO Bit"
        '
        'txtIOBitLabel
        '
        Me.txtIOBitLabel.ForeColor = System.Drawing.Color.Blue
        Me.txtIOBitLabel.Location = New System.Drawing.Point(497, 48)
        Me.txtIOBitLabel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtIOBitLabel.Name = "txtIOBitLabel"
        Me.txtIOBitLabel.ReadOnly = True
        Me.txtIOBitLabel.Size = New System.Drawing.Size(87, 22)
        Me.txtIOBitLabel.TabIndex = 350
        '
        'cmdIOGetBitByLabel
        '
        Me.cmdIOGetBitByLabel.Location = New System.Drawing.Point(497, 12)
        Me.cmdIOGetBitByLabel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmdIOGetBitByLabel.Name = "cmdIOGetBitByLabel"
        Me.cmdIOGetBitByLabel.Size = New System.Drawing.Size(85, 28)
        Me.cmdIOGetBitByLabel.TabIndex = 349
        Me.cmdIOGetBitByLabel.Text = "Get label"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(351, 18)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(62, 17)
        Me.Label55.TabIndex = 348
        Me.Label55.Text = "I/O Type"
        '
        'txtPLCBitData
        '
        Me.txtPLCBitData.ForeColor = System.Drawing.Color.Blue
        Me.txtPLCBitData.Location = New System.Drawing.Point(59, 49)
        Me.txtPLCBitData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPLCBitData.Name = "txtPLCBitData"
        Me.txtPLCBitData.ReadOnly = True
        Me.txtPLCBitData.Size = New System.Drawing.Size(115, 22)
        Me.txtPLCBitData.TabIndex = 346
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(269, 18)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(24, 17)
        Me.Label47.TabIndex = 345
        Me.Label47.Text = "Bit"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(184, 18)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(60, 17)
        Me.Label44.TabIndex = 344
        Me.Label44.Text = "Address"
        '
        'txtPLCBit
        '
        Me.txtPLCBit.ForeColor = System.Drawing.Color.Red
        Me.txtPLCBit.Location = New System.Drawing.Point(272, 50)
        Me.txtPLCBit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPLCBit.Name = "txtPLCBit"
        Me.txtPLCBit.Size = New System.Drawing.Size(76, 22)
        Me.txtPLCBit.TabIndex = 343
        Me.txtPLCBit.Text = "0"
        '
        'cboPLCBit
        '
        Me.cboPLCBit.Location = New System.Drawing.Point(355, 48)
        Me.cboPLCBit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboPLCBit.Name = "cboPLCBit"
        Me.cboPLCBit.Size = New System.Drawing.Size(127, 24)
        Me.cboPLCBit.TabIndex = 342
        '
        'btnGetBit
        '
        Me.btnGetBit.Location = New System.Drawing.Point(5, 46)
        Me.btnGetBit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGetBit.Name = "btnGetBit"
        Me.btnGetBit.Size = New System.Drawing.Size(47, 30)
        Me.btnGetBit.TabIndex = 340
        Me.btnGetBit.Text = "Get"
        '
        'txtPLCBitAddress
        '
        Me.txtPLCBitAddress.ForeColor = System.Drawing.Color.Red
        Me.txtPLCBitAddress.Location = New System.Drawing.Point(187, 50)
        Me.txtPLCBitAddress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPLCBitAddress.Name = "txtPLCBitAddress"
        Me.txtPLCBitAddress.Size = New System.Drawing.Size(76, 22)
        Me.txtPLCBitAddress.TabIndex = 324
        Me.txtPLCBitAddress.Text = "0"
        '
        'tabProgram
        '
        Me.tabProgram.Controls.Add(Me.Label83)
        Me.tabProgram.Controls.Add(Me.txtLoadPartProgramNameValue)
        Me.tabProgram.Controls.Add(Me.Label82)
        Me.tabProgram.Controls.Add(Me.txtLoadPartSystemSubProgramNameValue)
        Me.tabProgram.Controls.Add(Me.Label81)
        Me.tabProgram.Controls.Add(Me.txtLoadSubPartProgramFileNameValue)
        Me.tabProgram.Controls.Add(Me.Label80)
        Me.tabProgram.Controls.Add(Me.lstProgramOutput)
        Me.tabProgram.Controls.Add(Me.btnGetMCodes)
        Me.tabProgram.Controls.Add(Me.txtLoadSchedulePartProgramValue)
        Me.tabProgram.Controls.Add(Me.btnLoadSchedulePartProgram)
        Me.tabProgram.Controls.Add(Me.txtLoadPartProgramFileNameValue)
        Me.tabProgram.Controls.Add(Me.btnLoadPartProgram)
        Me.tabProgram.Controls.Add(Me.Label29)
        Me.tabProgram.Controls.Add(Me.txtProgramRunningState)
        Me.tabProgram.Controls.Add(Me.Label24)
        Me.tabProgram.Controls.Add(Me.txtProgramExecuteSequenceNumber)
        Me.tabProgram.Controls.Add(Me.Label17)
        Me.tabProgram.Controls.Add(Me.txtProgramBlockNumber)
        Me.tabProgram.Controls.Add(Me.Label18)
        Me.tabProgram.Controls.Add(Me.txtActiveScheduleProgramFileName)
        Me.tabProgram.Controls.Add(Me.Label19)
        Me.tabProgram.Controls.Add(Me.txtActiveProgramName)
        Me.tabProgram.Controls.Add(Me.Label20)
        Me.tabProgram.Controls.Add(Me.txtActiveProgramFileName)
        Me.tabProgram.Controls.Add(Me.Label22)
        Me.tabProgram.Controls.Add(Me.cboProgramDataUnit)
        Me.tabProgram.Controls.Add(Me.btnProgramUpdate)
        Me.tabProgram.Location = New System.Drawing.Point(4, 25)
        Me.tabProgram.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabProgram.Name = "tabProgram"
        Me.tabProgram.Size = New System.Drawing.Size(1012, 555)
        Me.tabProgram.TabIndex = 4
        Me.tabProgram.Text = "Program"
        Me.tabProgram.UseVisualStyleBackColor = True
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Location = New System.Drawing.Point(884, 209)
        Me.Label83.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(103, 17)
        Me.Label83.TabIndex = 323
        Me.Label83.Text = "Program Name"
        '
        'txtLoadPartProgramNameValue
        '
        Me.txtLoadPartProgramNameValue.Location = New System.Drawing.Point(887, 230)
        Me.txtLoadPartProgramNameValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLoadPartProgramNameValue.Name = "txtLoadPartProgramNameValue"
        Me.txtLoadPartProgramNameValue.Size = New System.Drawing.Size(132, 22)
        Me.txtLoadPartProgramNameValue.TabIndex = 322
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Location = New System.Drawing.Point(656, 209)
        Me.Label82.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(208, 17)
        Me.Label82.TabIndex = 321
        Me.Label82.Text = "System Sub Program File Name"
        '
        'txtLoadPartSystemSubProgramNameValue
        '
        Me.txtLoadPartSystemSubProgramNameValue.Location = New System.Drawing.Point(659, 230)
        Me.txtLoadPartSystemSubProgramNameValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLoadPartSystemSubProgramNameValue.Name = "txtLoadPartSystemSubProgramNameValue"
        Me.txtLoadPartSystemSubProgramNameValue.Size = New System.Drawing.Size(132, 22)
        Me.txtLoadPartSystemSubProgramNameValue.TabIndex = 320
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(489, 209)
        Me.Label81.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(158, 17)
        Me.Label81.TabIndex = 319
        Me.Label81.Text = "Sub Program File Name"
        '
        'txtLoadSubPartProgramFileNameValue
        '
        Me.txtLoadSubPartProgramFileNameValue.Location = New System.Drawing.Point(492, 230)
        Me.txtLoadSubPartProgramFileNameValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLoadSubPartProgramFileNameValue.Name = "txtLoadSubPartProgramFileNameValue"
        Me.txtLoadSubPartProgramFileNameValue.Size = New System.Drawing.Size(132, 22)
        Me.txtLoadSubPartProgramFileNameValue.TabIndex = 318
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Location = New System.Drawing.Point(789, 145)
        Me.Label80.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(129, 17)
        Me.Label80.TabIndex = 317
        Me.Label80.Text = "Program File Name"
        '
        'lstProgramOutput
        '
        Me.lstProgramOutput.FormattingEnabled = True
        Me.lstProgramOutput.ItemHeight = 16
        Me.lstProgramOutput.Location = New System.Drawing.Point(479, 334)
        Me.lstProgramOutput.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lstProgramOutput.Name = "lstProgramOutput"
        Me.lstProgramOutput.Size = New System.Drawing.Size(520, 212)
        Me.lstProgramOutput.TabIndex = 316
        '
        'btnGetMCodes
        '
        Me.btnGetMCodes.Controls.Add(Me.Label30)
        Me.btnGetMCodes.Controls.Add(Me.txtProgramCycleSelectionProgramFileName)
        Me.btnGetMCodes.Controls.Add(Me.Label27)
        Me.btnGetMCodes.Controls.Add(Me.txtProgramCycleSelectionProgramName)
        Me.btnGetMCodes.Controls.Add(Me.Label26)
        Me.btnGetMCodes.Controls.Add(Me.cboProgramCycleSelection)
        Me.btnGetMCodes.Controls.Add(Me.txtActiveIndexProgram)
        Me.btnGetMCodes.Controls.Add(Me.Label21)
        Me.btnGetMCodes.Controls.Add(Me.txtProgramCurrentCycleSelection)
        Me.btnGetMCodes.Controls.Add(Me.Label28)
        Me.btnGetMCodes.Location = New System.Drawing.Point(5, 257)
        Me.btnGetMCodes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGetMCodes.Name = "btnGetMCodes"
        Me.btnGetMCodes.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGetMCodes.Size = New System.Drawing.Size(457, 260)
        Me.btnGetMCodes.TabIndex = 315
        Me.btnGetMCodes.TabStop = False
        Me.btnGetMCodes.Text = "Cycle Select"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(11, 129)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(162, 17)
        Me.Label30.TabIndex = 310
        Me.Label30.Text = "Cycle Selection Program"
        '
        'txtProgramCycleSelectionProgramFileName
        '
        Me.txtProgramCycleSelectionProgramFileName.Location = New System.Drawing.Point(259, 175)
        Me.txtProgramCycleSelectionProgramFileName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtProgramCycleSelectionProgramFileName.Name = "txtProgramCycleSelectionProgramFileName"
        Me.txtProgramCycleSelectionProgramFileName.Size = New System.Drawing.Size(189, 22)
        Me.txtProgramCycleSelectionProgramFileName.TabIndex = 299
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(11, 181)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(229, 17)
        Me.Label27.TabIndex = 300
        Me.Label27.Text = "Cycle Selection Program File Name"
        '
        'txtProgramCycleSelectionProgramName
        '
        Me.txtProgramCycleSelectionProgramName.Location = New System.Drawing.Point(259, 225)
        Me.txtProgramCycleSelectionProgramName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtProgramCycleSelectionProgramName.Name = "txtProgramCycleSelectionProgramName"
        Me.txtProgramCycleSelectionProgramName.Size = New System.Drawing.Size(189, 22)
        Me.txtProgramCycleSelectionProgramName.TabIndex = 301
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(11, 233)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(203, 17)
        Me.Label26.TabIndex = 302
        Me.Label26.Text = "Cycle Selection Program Name"
        '
        'cboProgramCycleSelection
        '
        Me.cboProgramCycleSelection.Location = New System.Drawing.Point(259, 123)
        Me.cboProgramCycleSelection.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboProgramCycleSelection.Name = "cboProgramCycleSelection"
        Me.cboProgramCycleSelection.Size = New System.Drawing.Size(189, 24)
        Me.cboProgramCycleSelection.TabIndex = 309
        '
        'txtActiveIndexProgram
        '
        Me.txtActiveIndexProgram.Location = New System.Drawing.Point(259, 76)
        Me.txtActiveIndexProgram.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtActiveIndexProgram.Name = "txtActiveIndexProgram"
        Me.txtActiveIndexProgram.Size = New System.Drawing.Size(189, 22)
        Me.txtActiveIndexProgram.TabIndex = 287
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(11, 76)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(141, 17)
        Me.Label21.TabIndex = 288
        Me.Label21.Text = "Active Index Program"
        '
        'txtProgramCurrentCycleSelection
        '
        Me.txtProgramCurrentCycleSelection.Location = New System.Drawing.Point(259, 23)
        Me.txtProgramCurrentCycleSelection.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtProgramCurrentCycleSelection.Name = "txtProgramCurrentCycleSelection"
        Me.txtProgramCurrentCycleSelection.Size = New System.Drawing.Size(189, 22)
        Me.txtProgramCurrentCycleSelection.TabIndex = 297
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(11, 27)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(155, 17)
        Me.Label28.TabIndex = 298
        Me.Label28.Text = "Current Cycle Selection"
        '
        'txtLoadSchedulePartProgramValue
        '
        Me.txtLoadSchedulePartProgramValue.Location = New System.Drawing.Point(793, 284)
        Me.txtLoadSchedulePartProgramValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLoadSchedulePartProgramValue.Name = "txtLoadSchedulePartProgramValue"
        Me.txtLoadSchedulePartProgramValue.Size = New System.Drawing.Size(132, 22)
        Me.txtLoadSchedulePartProgramValue.TabIndex = 314
        '
        'btnLoadSchedulePartProgram
        '
        Me.btnLoadSchedulePartProgram.Location = New System.Drawing.Point(492, 284)
        Me.btnLoadSchedulePartProgram.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnLoadSchedulePartProgram.Name = "btnLoadSchedulePartProgram"
        Me.btnLoadSchedulePartProgram.Size = New System.Drawing.Size(217, 30)
        Me.btnLoadSchedulePartProgram.TabIndex = 313
        Me.btnLoadSchedulePartProgram.Text = "Load schedule part program"
        '
        'txtLoadPartProgramFileNameValue
        '
        Me.txtLoadPartProgramFileNameValue.Location = New System.Drawing.Point(793, 166)
        Me.txtLoadPartProgramFileNameValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLoadPartProgramFileNameValue.Name = "txtLoadPartProgramFileNameValue"
        Me.txtLoadPartProgramFileNameValue.Size = New System.Drawing.Size(223, 22)
        Me.txtLoadPartProgramFileNameValue.TabIndex = 312
        '
        'btnLoadPartProgram
        '
        Me.btnLoadPartProgram.Location = New System.Drawing.Point(492, 162)
        Me.btnLoadPartProgram.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnLoadPartProgram.Name = "btnLoadPartProgram"
        Me.btnLoadPartProgram.Size = New System.Drawing.Size(177, 30)
        Me.btnLoadPartProgram.TabIndex = 311
        Me.btnLoadPartProgram.Text = "Load part program"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(489, 108)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(156, 17)
        Me.Label29.TabIndex = 308
        Me.Label29.Text = "Program Running State"
        '
        'txtProgramRunningState
        '
        Me.txtProgramRunningState.Location = New System.Drawing.Point(793, 108)
        Me.txtProgramRunningState.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtProgramRunningState.Name = "txtProgramRunningState"
        Me.txtProgramRunningState.Size = New System.Drawing.Size(132, 22)
        Me.txtProgramRunningState.TabIndex = 307
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(489, 58)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(180, 17)
        Me.Label24.TabIndex = 306
        Me.Label24.Text = "Execute Sequence Number"
        '
        'txtProgramExecuteSequenceNumber
        '
        Me.txtProgramExecuteSequenceNumber.Location = New System.Drawing.Point(793, 58)
        Me.txtProgramExecuteSequenceNumber.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtProgramExecuteSequenceNumber.Name = "txtProgramExecuteSequenceNumber"
        Me.txtProgramExecuteSequenceNumber.Size = New System.Drawing.Size(132, 22)
        Me.txtProgramExecuteSequenceNumber.TabIndex = 305
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 214)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 17)
        Me.Label17.TabIndex = 296
        Me.Label17.Text = "Block Number"
        '
        'txtProgramBlockNumber
        '
        Me.txtProgramBlockNumber.Location = New System.Drawing.Point(264, 209)
        Me.txtProgramBlockNumber.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtProgramBlockNumber.Name = "txtProgramBlockNumber"
        Me.txtProgramBlockNumber.Size = New System.Drawing.Size(132, 22)
        Me.txtProgramBlockNumber.TabIndex = 295
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 162)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(234, 17)
        Me.Label18.TabIndex = 294
        Me.Label18.Text = "Active Schedule Program File Name"
        '
        'txtActiveScheduleProgramFileName
        '
        Me.txtActiveScheduleProgramFileName.Location = New System.Drawing.Point(264, 159)
        Me.txtActiveScheduleProgramFileName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtActiveScheduleProgramFileName.Name = "txtActiveScheduleProgramFileName"
        Me.txtActiveScheduleProgramFileName.Size = New System.Drawing.Size(132, 22)
        Me.txtActiveScheduleProgramFileName.TabIndex = 293
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 111)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(145, 17)
        Me.Label19.TabIndex = 292
        Me.Label19.Text = "Active Program Name"
        '
        'txtActiveProgramName
        '
        Me.txtActiveProgramName.Location = New System.Drawing.Point(264, 108)
        Me.txtActiveProgramName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtActiveProgramName.Name = "txtActiveProgramName"
        Me.txtActiveProgramName.Size = New System.Drawing.Size(132, 22)
        Me.txtActiveProgramName.TabIndex = 291
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 59)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(171, 17)
        Me.Label20.TabIndex = 290
        Me.Label20.Text = "Active Program File Name"
        '
        'txtActiveProgramFileName
        '
        Me.txtActiveProgramFileName.Location = New System.Drawing.Point(264, 58)
        Me.txtActiveProgramFileName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtActiveProgramFileName.Name = "txtActiveProgramFileName"
        Me.txtActiveProgramFileName.Size = New System.Drawing.Size(132, 22)
        Me.txtActiveProgramFileName.TabIndex = 289
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(476, 5)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 17)
        Me.Label22.TabIndex = 286
        Me.Label22.Text = "Data Unit"
        '
        'cboProgramDataUnit
        '
        Me.cboProgramDataUnit.Location = New System.Drawing.Point(640, 9)
        Me.cboProgramDataUnit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboProgramDataUnit.Name = "cboProgramDataUnit"
        Me.cboProgramDataUnit.Size = New System.Drawing.Size(171, 24)
        Me.cboProgramDataUnit.TabIndex = 285
        '
        'btnProgramUpdate
        '
        Me.btnProgramUpdate.Location = New System.Drawing.Point(4, 4)
        Me.btnProgramUpdate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnProgramUpdate.Name = "btnProgramUpdate"
        Me.btnProgramUpdate.Size = New System.Drawing.Size(107, 30)
        Me.btnProgramUpdate.TabIndex = 282
        Me.btnProgramUpdate.Text = "Update"
        '
        'tabSpec
        '
        Me.tabSpec.Controls.Add(Me.txtMachineName)
        Me.tabSpec.Controls.Add(Me.Label15)
        Me.tabSpec.Controls.Add(Me.btnSpecUpdate)
        Me.tabSpec.Controls.Add(Me.txtOSPControlType)
        Me.tabSpec.Controls.Add(Me.Label346)
        Me.tabSpec.Controls.Add(Me.txtMachineSerial)
        Me.tabSpec.Controls.Add(Me.Label168)
        Me.tabSpec.Controls.Add(Me.GroupBox10)
        Me.tabSpec.Controls.Add(Me.GroupBox8)
        Me.tabSpec.Location = New System.Drawing.Point(4, 25)
        Me.tabSpec.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabSpec.Name = "tabSpec"
        Me.tabSpec.Size = New System.Drawing.Size(1012, 555)
        Me.tabSpec.TabIndex = 9
        Me.tabSpec.Text = "Spec"
        Me.tabSpec.UseVisualStyleBackColor = True
        '
        'txtMachineName
        '
        Me.txtMachineName.BackColor = System.Drawing.SystemColors.Control
        Me.txtMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtMachineName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMachineName.Location = New System.Drawing.Point(189, 98)
        Me.txtMachineName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMachineName.Name = "txtMachineName"
        Me.txtMachineName.Size = New System.Drawing.Size(326, 36)
        Me.txtMachineName.TabIndex = 377
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 98)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(115, 18)
        Me.Label15.TabIndex = 376
        Me.Label15.Text = "Machine Name:"
        '
        'btnSpecUpdate
        '
        Me.btnSpecUpdate.Location = New System.Drawing.Point(3, 2)
        Me.btnSpecUpdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSpecUpdate.Name = "btnSpecUpdate"
        Me.btnSpecUpdate.Size = New System.Drawing.Size(93, 28)
        Me.btnSpecUpdate.TabIndex = 375
        Me.btnSpecUpdate.Text = "Update"
        '
        'txtOSPControlType
        '
        Me.txtOSPControlType.Location = New System.Drawing.Point(189, 153)
        Me.txtOSPControlType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOSPControlType.Name = "txtOSPControlType"
        Me.txtOSPControlType.Size = New System.Drawing.Size(211, 22)
        Me.txtOSPControlType.TabIndex = 374
        '
        'Label346
        '
        Me.Label346.Location = New System.Drawing.Point(8, 153)
        Me.Label346.Name = "Label346"
        Me.Label346.Size = New System.Drawing.Size(163, 18)
        Me.Label346.TabIndex = 373
        Me.Label346.Text = "OSP Control Type"
        '
        'txtMachineSerial
        '
        Me.txtMachineSerial.BackColor = System.Drawing.SystemColors.Control
        Me.txtMachineSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMachineSerial.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold)
        Me.txtMachineSerial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMachineSerial.Location = New System.Drawing.Point(189, 48)
        Me.txtMachineSerial.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMachineSerial.Name = "txtMachineSerial"
        Me.txtMachineSerial.Size = New System.Drawing.Size(326, 36)
        Me.txtMachineSerial.TabIndex = 369
        '
        'Label168
        '
        Me.Label168.Location = New System.Drawing.Point(8, 48)
        Me.Label168.Name = "Label168"
        Me.Label168.Size = New System.Drawing.Size(115, 18)
        Me.Label168.TabIndex = 367
        Me.Label168.Text = "Machine Serial:"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.txtNCSpec2)
        Me.GroupBox10.Controls.Add(Me.Label51)
        Me.GroupBox10.Controls.Add(Me.Label52)
        Me.GroupBox10.Controls.Add(Me.txtNCSpec2BitValue)
        Me.GroupBox10.Controls.Add(Me.btnGetNCSpec2)
        Me.GroupBox10.Controls.Add(Me.txtNCSpec2AddressValue)
        Me.GroupBox10.Location = New System.Drawing.Point(5, 274)
        Me.GroupBox10.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox10.Size = New System.Drawing.Size(468, 85)
        Me.GroupBox10.TabIndex = 365
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Get NC Spec 2"
        '
        'txtNCSpec2
        '
        Me.txtNCSpec2.ForeColor = System.Drawing.Color.Red
        Me.txtNCSpec2.Location = New System.Drawing.Point(88, 49)
        Me.txtNCSpec2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNCSpec2.Name = "txtNCSpec2"
        Me.txtNCSpec2.ReadOnly = True
        Me.txtNCSpec2.Size = New System.Drawing.Size(115, 22)
        Me.txtNCSpec2.TabIndex = 346
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(339, 18)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(24, 17)
        Me.Label51.TabIndex = 345
        Me.Label51.Text = "Bit"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(207, 18)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(60, 17)
        Me.Label52.TabIndex = 344
        Me.Label52.Text = "Address"
        '
        'txtNCSpec2BitValue
        '
        Me.txtNCSpec2BitValue.ForeColor = System.Drawing.Color.Red
        Me.txtNCSpec2BitValue.Location = New System.Drawing.Point(341, 49)
        Me.txtNCSpec2BitValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNCSpec2BitValue.Name = "txtNCSpec2BitValue"
        Me.txtNCSpec2BitValue.Size = New System.Drawing.Size(115, 22)
        Me.txtNCSpec2BitValue.TabIndex = 343
        '
        'btnGetNCSpec2
        '
        Me.btnGetNCSpec2.Location = New System.Drawing.Point(17, 46)
        Me.btnGetNCSpec2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGetNCSpec2.Name = "btnGetNCSpec2"
        Me.btnGetNCSpec2.Size = New System.Drawing.Size(47, 30)
        Me.btnGetNCSpec2.TabIndex = 340
        Me.btnGetNCSpec2.Text = "Get"
        '
        'txtNCSpec2AddressValue
        '
        Me.txtNCSpec2AddressValue.ForeColor = System.Drawing.Color.Red
        Me.txtNCSpec2AddressValue.Location = New System.Drawing.Point(211, 49)
        Me.txtNCSpec2AddressValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNCSpec2AddressValue.Name = "txtNCSpec2AddressValue"
        Me.txtNCSpec2AddressValue.Size = New System.Drawing.Size(115, 22)
        Me.txtNCSpec2AddressValue.TabIndex = 324
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.txtNCSpec)
        Me.GroupBox8.Controls.Add(Me.Label49)
        Me.GroupBox8.Controls.Add(Me.Label50)
        Me.GroupBox8.Controls.Add(Me.txtNCSpecBitValue)
        Me.GroupBox8.Controls.Add(Me.btnGetNCSpec)
        Me.GroupBox8.Controls.Add(Me.txtNCSpecAddressValue)
        Me.GroupBox8.Location = New System.Drawing.Point(5, 182)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox8.Size = New System.Drawing.Size(468, 85)
        Me.GroupBox8.TabIndex = 364
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Get NC Spec"
        '
        'txtNCSpec
        '
        Me.txtNCSpec.ForeColor = System.Drawing.Color.Red
        Me.txtNCSpec.Location = New System.Drawing.Point(88, 49)
        Me.txtNCSpec.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNCSpec.Name = "txtNCSpec"
        Me.txtNCSpec.ReadOnly = True
        Me.txtNCSpec.Size = New System.Drawing.Size(115, 22)
        Me.txtNCSpec.TabIndex = 346
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(339, 18)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(24, 17)
        Me.Label49.TabIndex = 345
        Me.Label49.Text = "Bit"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(207, 18)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(60, 17)
        Me.Label50.TabIndex = 344
        Me.Label50.Text = "Address"
        '
        'txtNCSpecBitValue
        '
        Me.txtNCSpecBitValue.ForeColor = System.Drawing.Color.Red
        Me.txtNCSpecBitValue.Location = New System.Drawing.Point(341, 49)
        Me.txtNCSpecBitValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNCSpecBitValue.Name = "txtNCSpecBitValue"
        Me.txtNCSpecBitValue.Size = New System.Drawing.Size(115, 22)
        Me.txtNCSpecBitValue.TabIndex = 343
        '
        'btnGetNCSpec
        '
        Me.btnGetNCSpec.Location = New System.Drawing.Point(17, 46)
        Me.btnGetNCSpec.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnGetNCSpec.Name = "btnGetNCSpec"
        Me.btnGetNCSpec.Size = New System.Drawing.Size(47, 30)
        Me.btnGetNCSpec.TabIndex = 340
        Me.btnGetNCSpec.Text = "Get"
        '
        'txtNCSpecAddressValue
        '
        Me.txtNCSpecAddressValue.ForeColor = System.Drawing.Color.Red
        Me.txtNCSpecAddressValue.Location = New System.Drawing.Point(211, 50)
        Me.txtNCSpecAddressValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNCSpecAddressValue.Name = "txtNCSpecAddressValue"
        Me.txtNCSpecAddressValue.Size = New System.Drawing.Size(115, 22)
        Me.txtNCSpecAddressValue.TabIndex = 324
        '
        'tabSpindle
        '
        Me.tabSpindle.Controls.Add(Me.GroupBox24)
        Me.tabSpindle.Controls.Add(Me.Label12)
        Me.tabSpindle.Controls.Add(Me.txtSpindlSurfaceSpeed)
        Me.tabSpindle.Controls.Add(Me.Label13)
        Me.tabSpindle.Controls.Add(Me.txtSpindlerRateOverride)
        Me.tabSpindle.Controls.Add(Me.Label14)
        Me.tabSpindle.Controls.Add(Me.txtSpindleLoad)
        Me.tabSpindle.Controls.Add(Me.Label16)
        Me.tabSpindle.Controls.Add(Me.txtSpindleActualSpeedRate)
        Me.tabSpindle.Controls.Add(Me.Label10)
        Me.tabSpindle.Controls.Add(Me.cboSpindleDataUnit)
        Me.tabSpindle.Controls.Add(Me.btnSpindleUpdate)
        Me.tabSpindle.Location = New System.Drawing.Point(4, 25)
        Me.tabSpindle.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabSpindle.Name = "tabSpindle"
        Me.tabSpindle.Size = New System.Drawing.Size(1012, 555)
        Me.tabSpindle.TabIndex = 3
        Me.tabSpindle.Text = "Spindle"
        Me.tabSpindle.UseVisualStyleBackColor = True
        '
        'GroupBox24
        '
        Me.GroupBox24.Controls.Add(Me.btntxtCommandSpindlerateSet)
        Me.GroupBox24.Controls.Add(Me.txtCommandSpindlerate)
        Me.GroupBox24.Controls.Add(Me.btntxtCommandSpindlerateAdd)
        Me.GroupBox24.Controls.Add(Me.txtCommandSpindlerateValue)
        Me.GroupBox24.Location = New System.Drawing.Point(483, 52)
        Me.GroupBox24.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox24.Name = "GroupBox24"
        Me.GroupBox24.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox24.Size = New System.Drawing.Size(247, 62)
        Me.GroupBox24.TabIndex = 357
        Me.GroupBox24.TabStop = False
        Me.GroupBox24.Text = "Command Spindle rate"
        '
        'btntxtCommandSpindlerateSet
        '
        Me.btntxtCommandSpindlerateSet.Location = New System.Drawing.Point(17, 23)
        Me.btntxtCommandSpindlerateSet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btntxtCommandSpindlerateSet.Name = "btntxtCommandSpindlerateSet"
        Me.btntxtCommandSpindlerateSet.Size = New System.Drawing.Size(47, 30)
        Me.btntxtCommandSpindlerateSet.TabIndex = 340
        Me.btntxtCommandSpindlerateSet.Text = "Set"
        '
        'txtCommandSpindlerate
        '
        Me.txtCommandSpindlerate.Location = New System.Drawing.Point(120, 26)
        Me.txtCommandSpindlerate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCommandSpindlerate.Name = "txtCommandSpindlerate"
        Me.txtCommandSpindlerate.ReadOnly = True
        Me.txtCommandSpindlerate.Size = New System.Drawing.Size(52, 22)
        Me.txtCommandSpindlerate.TabIndex = 324
        '
        'btntxtCommandSpindlerateAdd
        '
        Me.btntxtCommandSpindlerateAdd.Location = New System.Drawing.Point(63, 23)
        Me.btntxtCommandSpindlerateAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btntxtCommandSpindlerateAdd.Name = "btntxtCommandSpindlerateAdd"
        Me.btntxtCommandSpindlerateAdd.Size = New System.Drawing.Size(47, 30)
        Me.btntxtCommandSpindlerateAdd.TabIndex = 339
        Me.btntxtCommandSpindlerateAdd.Text = "Add"
        '
        'txtCommandSpindlerateValue
        '
        Me.txtCommandSpindlerateValue.ForeColor = System.Drawing.Color.Red
        Me.txtCommandSpindlerateValue.Location = New System.Drawing.Point(183, 26)
        Me.txtCommandSpindlerateValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCommandSpindlerateValue.Name = "txtCommandSpindlerateValue"
        Me.txtCommandSpindlerateValue.Size = New System.Drawing.Size(52, 22)
        Me.txtCommandSpindlerateValue.TabIndex = 341
        Me.txtCommandSpindlerateValue.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 202)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(153, 17)
        Me.Label12.TabIndex = 281
        Me.Label12.Text = "Spindle Surface Speed"
        '
        'txtSpindlSurfaceSpeed
        '
        Me.txtSpindlSurfaceSpeed.Location = New System.Drawing.Point(260, 202)
        Me.txtSpindlSurfaceSpeed.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSpindlSurfaceSpeed.Name = "txtSpindlSurfaceSpeed"
        Me.txtSpindlSurfaceSpeed.Size = New System.Drawing.Size(132, 22)
        Me.txtSpindlSurfaceSpeed.TabIndex = 280
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 149)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(148, 17)
        Me.Label13.TabIndex = 279
        Me.Label13.Text = "Spindle Rate Override"
        '
        'txtSpindlerRateOverride
        '
        Me.txtSpindlerRateOverride.Location = New System.Drawing.Point(260, 149)
        Me.txtSpindlerRateOverride.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSpindlerRateOverride.Name = "txtSpindlerRateOverride"
        Me.txtSpindlerRateOverride.Size = New System.Drawing.Size(132, 22)
        Me.txtSpindlerRateOverride.TabIndex = 278
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(8, 97)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(91, 17)
        Me.Label14.TabIndex = 277
        Me.Label14.Text = "Spindle Load"
        '
        'txtSpindleLoad
        '
        Me.txtSpindleLoad.Location = New System.Drawing.Point(260, 97)
        Me.txtSpindleLoad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSpindleLoad.Name = "txtSpindleLoad"
        Me.txtSpindleLoad.Size = New System.Drawing.Size(132, 22)
        Me.txtSpindleLoad.TabIndex = 276
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 52)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(127, 17)
        Me.Label16.TabIndex = 273
        Me.Label16.Text = "Actual Spindle rate"
        '
        'txtSpindleActualSpeedRate
        '
        Me.txtSpindleActualSpeedRate.Location = New System.Drawing.Point(260, 52)
        Me.txtSpindleActualSpeedRate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSpindleActualSpeedRate.Name = "txtSpindleActualSpeedRate"
        Me.txtSpindleActualSpeedRate.Size = New System.Drawing.Size(132, 22)
        Me.txtSpindleActualSpeedRate.TabIndex = 272
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(480, 4)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 17)
        Me.Label10.TabIndex = 271
        Me.Label10.Text = "Data Unit"
        '
        'cboSpindleDataUnit
        '
        Me.cboSpindleDataUnit.Location = New System.Drawing.Point(644, 7)
        Me.cboSpindleDataUnit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboSpindleDataUnit.Name = "cboSpindleDataUnit"
        Me.cboSpindleDataUnit.Size = New System.Drawing.Size(171, 24)
        Me.cboSpindleDataUnit.TabIndex = 270
        '
        'btnSpindleUpdate
        '
        Me.btnSpindleUpdate.Location = New System.Drawing.Point(4, 4)
        Me.btnSpindleUpdate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSpindleUpdate.Name = "btnSpindleUpdate"
        Me.btnSpindleUpdate.Size = New System.Drawing.Size(107, 30)
        Me.btnSpindleUpdate.TabIndex = 267
        Me.btnSpindleUpdate.Text = "Update"
        '
        'tabTools
        '
        Me.tabTools.Controls.Add(Me.Label48)
        Me.tabTools.Controls.Add(Me.txtCurrentTool)
        Me.tabTools.Controls.Add(Me.Label43)
        Me.tabTools.Controls.Add(Me.txtDiamondToolIndex)
        Me.tabTools.Controls.Add(Me.GroupBox4)
        Me.tabTools.Controls.Add(Me.GroupBox5)
        Me.tabTools.Controls.Add(Me.Label33)
        Me.tabTools.Controls.Add(Me.cboDiamondToolDataUnit)
        Me.tabTools.Controls.Add(Me.btnDiamondTool)
        Me.tabTools.Location = New System.Drawing.Point(4, 25)
        Me.tabTools.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabTools.Name = "tabTools"
        Me.tabTools.Size = New System.Drawing.Size(1012, 555)
        Me.tabTools.TabIndex = 6
        Me.tabTools.Text = "Tools"
        Me.tabTools.UseVisualStyleBackColor = True
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(297, 54)
        Me.Label48.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(195, 17)
        Me.Label48.TabIndex = 357
        Me.Label48.Text = "Current Tool (Wheel Number)"
        '
        'txtCurrentTool
        '
        Me.txtCurrentTool.Location = New System.Drawing.Point(511, 49)
        Me.txtCurrentTool.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCurrentTool.Name = "txtCurrentTool"
        Me.txtCurrentTool.ReadOnly = True
        Me.txtCurrentTool.Size = New System.Drawing.Size(64, 22)
        Me.txtCurrentTool.TabIndex = 356
        Me.txtCurrentTool.Text = "0"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(8, 52)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(179, 17)
        Me.Label43.TabIndex = 355
        Me.Label43.Text = "Diamond Tool Offset Index:"
        '
        'txtDiamondToolIndex
        '
        Me.txtDiamondToolIndex.Location = New System.Drawing.Point(208, 48)
        Me.txtDiamondToolIndex.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDiamondToolIndex.Name = "txtDiamondToolIndex"
        Me.txtDiamondToolIndex.Size = New System.Drawing.Size(64, 22)
        Me.txtDiamondToolIndex.TabIndex = 354
        Me.txtDiamondToolIndex.Text = "1"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboDiamondNoseRCompAxis)
        Me.GroupBox4.Controls.Add(Me.btnDiamondToolNoseRCompSet)
        Me.GroupBox4.Controls.Add(Me.txtDiamondNoseRComp)
        Me.GroupBox4.Controls.Add(Me.btnDiamondToolNoseRCompAdd)
        Me.GroupBox4.Controls.Add(Me.txtDiamondNoseRCompValue)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 175)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(571, 62)
        Me.GroupBox4.TabIndex = 353
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Diamond Nose-R Compensation"
        '
        'cboDiamondNoseRCompAxis
        '
        Me.cboDiamondNoseRCompAxis.Location = New System.Drawing.Point(385, 23)
        Me.cboDiamondNoseRCompAxis.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboDiamondNoseRCompAxis.Name = "cboDiamondNoseRCompAxis"
        Me.cboDiamondNoseRCompAxis.Size = New System.Drawing.Size(171, 24)
        Me.cboDiamondNoseRCompAxis.TabIndex = 342
        '
        'btnDiamondToolNoseRCompSet
        '
        Me.btnDiamondToolNoseRCompSet.Location = New System.Drawing.Point(17, 23)
        Me.btnDiamondToolNoseRCompSet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDiamondToolNoseRCompSet.Name = "btnDiamondToolNoseRCompSet"
        Me.btnDiamondToolNoseRCompSet.Size = New System.Drawing.Size(47, 30)
        Me.btnDiamondToolNoseRCompSet.TabIndex = 340
        Me.btnDiamondToolNoseRCompSet.Text = "Set"
        '
        'txtDiamondNoseRComp
        '
        Me.txtDiamondNoseRComp.Location = New System.Drawing.Point(120, 26)
        Me.txtDiamondNoseRComp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDiamondNoseRComp.Name = "txtDiamondNoseRComp"
        Me.txtDiamondNoseRComp.ReadOnly = True
        Me.txtDiamondNoseRComp.Size = New System.Drawing.Size(115, 22)
        Me.txtDiamondNoseRComp.TabIndex = 324
        '
        'btnDiamondToolNoseRCompAdd
        '
        Me.btnDiamondToolNoseRCompAdd.Location = New System.Drawing.Point(63, 23)
        Me.btnDiamondToolNoseRCompAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDiamondToolNoseRCompAdd.Name = "btnDiamondToolNoseRCompAdd"
        Me.btnDiamondToolNoseRCompAdd.Size = New System.Drawing.Size(47, 30)
        Me.btnDiamondToolNoseRCompAdd.TabIndex = 339
        Me.btnDiamondToolNoseRCompAdd.Text = "Add"
        '
        'txtDiamondNoseRCompValue
        '
        Me.txtDiamondNoseRCompValue.ForeColor = System.Drawing.Color.Red
        Me.txtDiamondNoseRCompValue.Location = New System.Drawing.Point(252, 25)
        Me.txtDiamondNoseRCompValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDiamondNoseRCompValue.Name = "txtDiamondNoseRCompValue"
        Me.txtDiamondNoseRCompValue.Size = New System.Drawing.Size(124, 22)
        Me.txtDiamondNoseRCompValue.TabIndex = 341
        Me.txtDiamondNoseRCompValue.Text = "0"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboToolOffsetAxis)
        Me.GroupBox5.Controls.Add(Me.btnToolOffsetSet)
        Me.GroupBox5.Controls.Add(Me.txtToolOffset)
        Me.GroupBox5.Controls.Add(Me.btnToolOffsetAdd)
        Me.GroupBox5.Controls.Add(Me.txtToolOffsetValue)
        Me.GroupBox5.Location = New System.Drawing.Point(4, 91)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox5.Size = New System.Drawing.Size(571, 62)
        Me.GroupBox5.TabIndex = 352
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Diamond Tool Offset"
        '
        'cboToolOffsetAxis
        '
        Me.cboToolOffsetAxis.Location = New System.Drawing.Point(385, 23)
        Me.cboToolOffsetAxis.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboToolOffsetAxis.Name = "cboToolOffsetAxis"
        Me.cboToolOffsetAxis.Size = New System.Drawing.Size(171, 24)
        Me.cboToolOffsetAxis.TabIndex = 342
        '
        'btnToolOffsetSet
        '
        Me.btnToolOffsetSet.Location = New System.Drawing.Point(17, 23)
        Me.btnToolOffsetSet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnToolOffsetSet.Name = "btnToolOffsetSet"
        Me.btnToolOffsetSet.Size = New System.Drawing.Size(47, 30)
        Me.btnToolOffsetSet.TabIndex = 340
        Me.btnToolOffsetSet.Text = "Set"
        '
        'txtToolOffset
        '
        Me.txtToolOffset.Location = New System.Drawing.Point(120, 26)
        Me.txtToolOffset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtToolOffset.Name = "txtToolOffset"
        Me.txtToolOffset.ReadOnly = True
        Me.txtToolOffset.Size = New System.Drawing.Size(115, 22)
        Me.txtToolOffset.TabIndex = 324
        '
        'btnToolOffsetAdd
        '
        Me.btnToolOffsetAdd.Location = New System.Drawing.Point(63, 23)
        Me.btnToolOffsetAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnToolOffsetAdd.Name = "btnToolOffsetAdd"
        Me.btnToolOffsetAdd.Size = New System.Drawing.Size(47, 30)
        Me.btnToolOffsetAdd.TabIndex = 339
        Me.btnToolOffsetAdd.Text = "Add"
        '
        'txtToolOffsetValue
        '
        Me.txtToolOffsetValue.ForeColor = System.Drawing.Color.Red
        Me.txtToolOffsetValue.Location = New System.Drawing.Point(252, 25)
        Me.txtToolOffsetValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtToolOffsetValue.Name = "txtToolOffsetValue"
        Me.txtToolOffsetValue.Size = New System.Drawing.Size(124, 22)
        Me.txtToolOffsetValue.TabIndex = 341
        Me.txtToolOffsetValue.Text = "0"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(440, 4)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(67, 17)
        Me.Label33.TabIndex = 276
        Me.Label33.Text = "Data Unit"
        '
        'cboDiamondToolDataUnit
        '
        Me.cboDiamondToolDataUnit.Location = New System.Drawing.Point(537, 4)
        Me.cboDiamondToolDataUnit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboDiamondToolDataUnit.Name = "cboDiamondToolDataUnit"
        Me.cboDiamondToolDataUnit.Size = New System.Drawing.Size(171, 24)
        Me.cboDiamondToolDataUnit.TabIndex = 275
        '
        'btnDiamondTool
        '
        Me.btnDiamondTool.Location = New System.Drawing.Point(4, 4)
        Me.btnDiamondTool.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDiamondTool.Name = "btnDiamondTool"
        Me.btnDiamondTool.Size = New System.Drawing.Size(107, 30)
        Me.btnDiamondTool.TabIndex = 272
        Me.btnDiamondTool.Text = "Update"
        '
        'tabVariables
        '
        Me.tabVariables.Controls.Add(Me.GroupBox19)
        Me.tabVariables.Controls.Add(Me.Label246)
        Me.tabVariables.Controls.Add(Me.txtCommonVarialbesData)
        Me.tabVariables.Location = New System.Drawing.Point(4, 25)
        Me.tabVariables.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tabVariables.Name = "tabVariables"
        Me.tabVariables.Size = New System.Drawing.Size(1012, 555)
        Me.tabVariables.TabIndex = 10
        Me.tabVariables.Text = "Variables"
        Me.tabVariables.UseVisualStyleBackColor = True
        '
        'GroupBox19
        '
        Me.GroupBox19.Controls.Add(Me.btnSetCommonVariables)
        Me.GroupBox19.Controls.Add(Me.txtCommonVariableEndingIndex)
        Me.GroupBox19.Controls.Add(Me.txtCommonVariableStartingIndex)
        Me.GroupBox19.Controls.Add(Me.txtCommonVariableValue)
        Me.GroupBox19.Controls.Add(Me.Label91)
        Me.GroupBox19.Controls.Add(Me.txtCommonVariable)
        Me.GroupBox19.Controls.Add(Me.Label92)
        Me.GroupBox19.Controls.Add(Me.btnGetCommonVariable)
        Me.GroupBox19.Controls.Add(Me.Label90)
        Me.GroupBox19.Controls.Add(Me.txtCommonVariableData)
        Me.GroupBox19.Controls.Add(Me.btnCommonVariableUpdate)
        Me.GroupBox19.Controls.Add(Me.btnGetCommonVariables)
        Me.GroupBox19.Controls.Add(Me.Label89)
        Me.GroupBox19.Controls.Add(Me.txtCommonVariablesCount)
        Me.GroupBox19.Controls.Add(Me.btnAddCommonVariables)
        Me.GroupBox19.Location = New System.Drawing.Point(3, 2)
        Me.GroupBox19.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox19.Name = "GroupBox19"
        Me.GroupBox19.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox19.Size = New System.Drawing.Size(652, 194)
        Me.GroupBox19.TabIndex = 238
        Me.GroupBox19.TabStop = False
        Me.GroupBox19.Text = "Common Variables"
        '
        'btnSetCommonVariables
        '
        Me.btnSetCommonVariables.Location = New System.Drawing.Point(469, 111)
        Me.btnSetCommonVariables.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSetCommonVariables.Name = "btnSetCommonVariables"
        Me.btnSetCommonVariables.Size = New System.Drawing.Size(48, 27)
        Me.btnSetCommonVariables.TabIndex = 177
        Me.btnSetCommonVariables.Text = "Set"
        '
        'txtCommonVariableEndingIndex
        '
        Me.txtCommonVariableEndingIndex.Location = New System.Drawing.Point(403, 158)
        Me.txtCommonVariableEndingIndex.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCommonVariableEndingIndex.Name = "txtCommonVariableEndingIndex"
        Me.txtCommonVariableEndingIndex.Size = New System.Drawing.Size(77, 22)
        Me.txtCommonVariableEndingIndex.TabIndex = 76
        Me.txtCommonVariableEndingIndex.Text = "10"
        '
        'txtCommonVariableStartingIndex
        '
        Me.txtCommonVariableStartingIndex.Location = New System.Drawing.Point(211, 158)
        Me.txtCommonVariableStartingIndex.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCommonVariableStartingIndex.Name = "txtCommonVariableStartingIndex"
        Me.txtCommonVariableStartingIndex.Size = New System.Drawing.Size(77, 22)
        Me.txtCommonVariableStartingIndex.TabIndex = 73
        Me.txtCommonVariableStartingIndex.Text = "1"
        '
        'txtCommonVariableValue
        '
        Me.txtCommonVariableValue.ForeColor = System.Drawing.Color.Red
        Me.txtCommonVariableValue.Location = New System.Drawing.Point(309, 111)
        Me.txtCommonVariableValue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCommonVariableValue.Name = "txtCommonVariableValue"
        Me.txtCommonVariableValue.Size = New System.Drawing.Size(77, 22)
        Me.txtCommonVariableValue.TabIndex = 71
        Me.txtCommonVariableValue.Text = "0"
        '
        'Label91
        '
        Me.Label91.Location = New System.Drawing.Point(19, 74)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(183, 18)
        Me.Label91.TabIndex = 72
        Me.Label91.Text = "Common Variable Number"
        '
        'txtCommonVariable
        '
        Me.txtCommonVariable.Location = New System.Drawing.Point(211, 71)
        Me.txtCommonVariable.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCommonVariable.Name = "txtCommonVariable"
        Me.txtCommonVariable.Size = New System.Drawing.Size(77, 22)
        Me.txtCommonVariable.TabIndex = 69
        Me.txtCommonVariable.Text = "1"
        '
        'Label92
        '
        Me.Label92.Location = New System.Drawing.Point(307, 158)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(80, 18)
        Me.Label92.TabIndex = 70
        Me.Label92.Text = "Between"
        '
        'btnGetCommonVariable
        '
        Me.btnGetCommonVariable.Location = New System.Drawing.Point(403, 111)
        Me.btnGetCommonVariable.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGetCommonVariable.Name = "btnGetCommonVariable"
        Me.btnGetCommonVariable.Size = New System.Drawing.Size(59, 27)
        Me.btnGetCommonVariable.TabIndex = 187
        Me.btnGetCommonVariable.Text = "Get"
        '
        'Label90
        '
        Me.Label90.Location = New System.Drawing.Point(19, 111)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(183, 18)
        Me.Label90.TabIndex = 185
        Me.Label90.Text = "Common Variable Value"
        '
        'txtCommonVariableData
        '
        Me.txtCommonVariableData.Location = New System.Drawing.Point(211, 111)
        Me.txtCommonVariableData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCommonVariableData.Name = "txtCommonVariableData"
        Me.txtCommonVariableData.ReadOnly = True
        Me.txtCommonVariableData.Size = New System.Drawing.Size(77, 22)
        Me.txtCommonVariableData.TabIndex = 184
        Me.txtCommonVariableData.Text = "1"
        '
        'btnCommonVariableUpdate
        '
        Me.btnCommonVariableUpdate.Location = New System.Drawing.Point(499, 28)
        Me.btnCommonVariableUpdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCommonVariableUpdate.Name = "btnCommonVariableUpdate"
        Me.btnCommonVariableUpdate.Size = New System.Drawing.Size(144, 27)
        Me.btnCommonVariableUpdate.TabIndex = 183
        Me.btnCommonVariableUpdate.Text = "Update"
        '
        'btnGetCommonVariables
        '
        Me.btnGetCommonVariables.Location = New System.Drawing.Point(499, 151)
        Me.btnGetCommonVariables.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGetCommonVariables.Name = "btnGetCommonVariables"
        Me.btnGetCommonVariables.Size = New System.Drawing.Size(85, 28)
        Me.btnGetCommonVariables.TabIndex = 182
        Me.btnGetCommonVariables.Text = "Get All -->"
        '
        'Label89
        '
        Me.Label89.Location = New System.Drawing.Point(317, 74)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(163, 18)
        Me.Label89.TabIndex = 181
        Me.Label89.Text = "Number of Common Variables(Count)"
        '
        'txtCommonVariablesCount
        '
        Me.txtCommonVariablesCount.Location = New System.Drawing.Point(508, 74)
        Me.txtCommonVariablesCount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCommonVariablesCount.Name = "txtCommonVariablesCount"
        Me.txtCommonVariablesCount.ReadOnly = True
        Me.txtCommonVariablesCount.Size = New System.Drawing.Size(68, 22)
        Me.txtCommonVariablesCount.TabIndex = 180
        Me.txtCommonVariablesCount.Text = "0"
        '
        'btnAddCommonVariables
        '
        Me.btnAddCommonVariables.Location = New System.Drawing.Point(528, 111)
        Me.btnAddCommonVariables.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAddCommonVariables.Name = "btnAddCommonVariables"
        Me.btnAddCommonVariables.Size = New System.Drawing.Size(48, 27)
        Me.btnAddCommonVariables.TabIndex = 178
        Me.btnAddCommonVariables.Text = "Add"
        '
        'Label246
        '
        Me.Label246.Location = New System.Drawing.Point(661, 2)
        Me.Label246.Name = "Label246"
        Me.Label246.Size = New System.Drawing.Size(229, 28)
        Me.Label246.TabIndex = 237
        Me.Label246.Text = "Common variable Values:"
        '
        'txtCommonVarialbesData
        '
        Me.txtCommonVarialbesData.Location = New System.Drawing.Point(665, 33)
        Me.txtCommonVarialbesData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCommonVarialbesData.Multiline = True
        Me.txtCommonVarialbesData.Name = "txtCommonVarialbesData"
        Me.txtCommonVarialbesData.Size = New System.Drawing.Size(240, 512)
        Me.txtCommonVarialbesData.TabIndex = 236
        '
        'tabWheel
        '
        Me.tabWheel.Controls.Add(Me.Label46)
        Me.tabWheel.Controls.Add(Me.txtWheelMaxWheels)
        Me.tabWheel.Controls.Add(Me.Label25)
        Me.tabWheel.Controls.Add(Me.cboWheelDataUnit)
        Me.tabWheel.Controls.Add(Me.Label74)
        Me.tabWheel.Controls.Add(Me.txtWheelType)
        Me.tabWheel.Controls.Add(Me.Label73)
        Me.tabWheel.Controls.Add(Me.txtWheelShape)
        Me.tabWheel.Controls.Add(Me.Label72)
        Me.tabWheel.Controls.Add(Me.txtMaxWheelData)
        Me.tabWheel.Controls.Add(Me.Label31)
        Me.tabWheel.Controls.Add(Me.txtWheelDataNo)
        Me.tabWheel.Controls.Add(Me.GroupBox23)
        Me.tabWheel.Controls.Add(Me.Label32)
        Me.tabWheel.Controls.Add(Me.txtWheelPPCLoad)
        Me.tabWheel.Controls.Add(Me.lstWheelData)
        Me.tabWheel.Controls.Add(Me.GroupBox3)
        Me.tabWheel.Controls.Add(Me.GroupBox2)
        Me.tabWheel.Controls.Add(Me.GroupBox1)
        Me.tabWheel.Controls.Add(Me.Label41)
        Me.tabWheel.Controls.Add(Me.txtWheelSpindleRateOverride)
        Me.tabWheel.Controls.Add(Me.Label36)
        Me.tabWheel.Controls.Add(Me.txtWheelOLLoad)
        Me.tabWheel.Controls.Add(Me.Label37)
        Me.tabWheel.Controls.Add(Me.txtWheelGAPLoad)
        Me.tabWheel.Controls.Add(Me.Label38)
        Me.tabWheel.Controls.Add(Me.txtWheelEffectLoad)
        Me.tabWheel.Controls.Add(Me.Label39)
        Me.tabWheel.Controls.Add(Me.txtWheelMeasureLoad)
        Me.tabWheel.Controls.Add(Me.Label40)
        Me.tabWheel.Controls.Add(Me.txtWheelSpindleSurfaceSpeed)
        Me.tabWheel.Controls.Add(Me.Label34)
        Me.tabWheel.Controls.Add(Me.txtWheelCommandSpindleRate)
        Me.tabWheel.Controls.Add(Me.Label35)
        Me.tabWheel.Controls.Add(Me.txtWheelActualSpindleRate)
        Me.tabWheel.Controls.Add(Me.btnWheel)
        Me.tabWheel.Location = New System.Drawing.Point(4, 25)
        Me.tabWheel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabWheel.Name = "tabWheel"
        Me.tabWheel.Size = New System.Drawing.Size(1012, 555)
        Me.tabWheel.TabIndex = 5
        Me.tabWheel.Text = "Wheel"
        Me.tabWheel.UseVisualStyleBackColor = True
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(460, 103)
        Me.Label46.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(88, 17)
        Me.Label46.TabIndex = 368
        Me.Label46.Text = "Max Wheels:"
        '
        'txtWheelMaxWheels
        '
        Me.txtWheelMaxWheels.Location = New System.Drawing.Point(603, 103)
        Me.txtWheelMaxWheels.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelMaxWheels.Name = "txtWheelMaxWheels"
        Me.txtWheelMaxWheels.Size = New System.Drawing.Size(132, 22)
        Me.txtWheelMaxWheels.TabIndex = 367
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(431, 12)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(67, 17)
        Me.Label25.TabIndex = 366
        Me.Label25.Text = "Data Unit"
        '
        'cboWheelDataUnit
        '
        Me.cboWheelDataUnit.Location = New System.Drawing.Point(563, 12)
        Me.cboWheelDataUnit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboWheelDataUnit.Name = "cboWheelDataUnit"
        Me.cboWheelDataUnit.Size = New System.Drawing.Size(171, 24)
        Me.cboWheelDataUnit.TabIndex = 365
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(19, 361)
        Me.Label74.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(84, 17)
        Me.Label74.TabIndex = 364
        Me.Label74.Text = "Wheel Type"
        '
        'txtWheelType
        '
        Me.txtWheelType.Location = New System.Drawing.Point(269, 363)
        Me.txtWheelType.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelType.Name = "txtWheelType"
        Me.txtWheelType.Size = New System.Drawing.Size(132, 22)
        Me.txtWheelType.TabIndex = 363
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(19, 325)
        Me.Label73.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(93, 17)
        Me.Label73.TabIndex = 362
        Me.Label73.Text = "Wheel Shape"
        '
        'txtWheelShape
        '
        Me.txtWheelShape.Location = New System.Drawing.Point(269, 327)
        Me.txtWheelShape.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelShape.Name = "txtWheelShape"
        Me.txtWheelShape.Size = New System.Drawing.Size(132, 22)
        Me.txtWheelShape.TabIndex = 361
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(19, 290)
        Me.Label72.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(111, 17)
        Me.Label72.TabIndex = 360
        Me.Label72.Text = "Max Wheel Data"
        '
        'txtMaxWheelData
        '
        Me.txtMaxWheelData.Location = New System.Drawing.Point(269, 292)
        Me.txtMaxWheelData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtMaxWheelData.Name = "txtMaxWheelData"
        Me.txtMaxWheelData.Size = New System.Drawing.Size(132, 22)
        Me.txtMaxWheelData.TabIndex = 359
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(548, 50)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(108, 17)
        Me.Label31.TabIndex = 358
        Me.Label31.Text = "Wheel Data No."
        '
        'txtWheelDataNo
        '
        Me.txtWheelDataNo.ForeColor = System.Drawing.Color.Red
        Me.txtWheelDataNo.Location = New System.Drawing.Point(685, 48)
        Me.txtWheelDataNo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelDataNo.Name = "txtWheelDataNo"
        Me.txtWheelDataNo.Size = New System.Drawing.Size(48, 22)
        Me.txtWheelDataNo.TabIndex = 357
        Me.txtWheelDataNo.Text = "1"
        '
        'GroupBox23
        '
        Me.GroupBox23.Controls.Add(Me.btnWheelSurfaceSpeedSetupSet)
        Me.GroupBox23.Controls.Add(Me.txtWheelSurfaceSpeedSetup)
        Me.GroupBox23.Controls.Add(Me.btnWheelSurfaceSpeedSetupAdd)
        Me.GroupBox23.Controls.Add(Me.txtWheelSurfaceSpeedSetupValue)
        Me.GroupBox23.Location = New System.Drawing.Point(264, 407)
        Me.GroupBox23.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox23.Name = "GroupBox23"
        Me.GroupBox23.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox23.Size = New System.Drawing.Size(259, 62)
        Me.GroupBox23.TabIndex = 355
        Me.GroupBox23.TabStop = False
        Me.GroupBox23.Text = "Wheel Surface Speed Setup"
        '
        'btnWheelSurfaceSpeedSetupSet
        '
        Me.btnWheelSurfaceSpeedSetupSet.Location = New System.Drawing.Point(17, 23)
        Me.btnWheelSurfaceSpeedSetupSet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWheelSurfaceSpeedSetupSet.Name = "btnWheelSurfaceSpeedSetupSet"
        Me.btnWheelSurfaceSpeedSetupSet.Size = New System.Drawing.Size(47, 30)
        Me.btnWheelSurfaceSpeedSetupSet.TabIndex = 340
        Me.btnWheelSurfaceSpeedSetupSet.Text = "Set"
        '
        'txtWheelSurfaceSpeedSetup
        '
        Me.txtWheelSurfaceSpeedSetup.Location = New System.Drawing.Point(120, 26)
        Me.txtWheelSurfaceSpeedSetup.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelSurfaceSpeedSetup.Name = "txtWheelSurfaceSpeedSetup"
        Me.txtWheelSurfaceSpeedSetup.ReadOnly = True
        Me.txtWheelSurfaceSpeedSetup.Size = New System.Drawing.Size(52, 22)
        Me.txtWheelSurfaceSpeedSetup.TabIndex = 324
        '
        'btnWheelSurfaceSpeedSetupAdd
        '
        Me.btnWheelSurfaceSpeedSetupAdd.Location = New System.Drawing.Point(63, 23)
        Me.btnWheelSurfaceSpeedSetupAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWheelSurfaceSpeedSetupAdd.Name = "btnWheelSurfaceSpeedSetupAdd"
        Me.btnWheelSurfaceSpeedSetupAdd.Size = New System.Drawing.Size(47, 30)
        Me.btnWheelSurfaceSpeedSetupAdd.TabIndex = 339
        Me.btnWheelSurfaceSpeedSetupAdd.Text = "Add"
        '
        'txtWheelSurfaceSpeedSetupValue
        '
        Me.txtWheelSurfaceSpeedSetupValue.ForeColor = System.Drawing.Color.Red
        Me.txtWheelSurfaceSpeedSetupValue.Location = New System.Drawing.Point(183, 26)
        Me.txtWheelSurfaceSpeedSetupValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelSurfaceSpeedSetupValue.Name = "txtWheelSurfaceSpeedSetupValue"
        Me.txtWheelSurfaceSpeedSetupValue.Size = New System.Drawing.Size(52, 22)
        Me.txtWheelSurfaceSpeedSetupValue.TabIndex = 341
        Me.txtWheelSurfaceSpeedSetupValue.Text = "0"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(19, 257)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(115, 17)
        Me.Label32.TabIndex = 354
        Me.Label32.Text = "Wheel PPC Load"
        '
        'txtWheelPPCLoad
        '
        Me.txtWheelPPCLoad.Location = New System.Drawing.Point(269, 258)
        Me.txtWheelPPCLoad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelPPCLoad.Name = "txtWheelPPCLoad"
        Me.txtWheelPPCLoad.Size = New System.Drawing.Size(132, 22)
        Me.txtWheelPPCLoad.TabIndex = 353
        '
        'lstWheelData
        '
        Me.lstWheelData.FormattingEnabled = True
        Me.lstWheelData.ItemHeight = 16
        Me.lstWheelData.Location = New System.Drawing.Point(743, 6)
        Me.lstWheelData.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lstWheelData.Name = "lstWheelData"
        Me.lstWheelData.Size = New System.Drawing.Size(264, 532)
        Me.lstWheelData.TabIndex = 351
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnWheelDiamondToolOffsetNumberSet)
        Me.GroupBox3.Controls.Add(Me.txtWheelDiamondToolOffsetNumber)
        Me.GroupBox3.Controls.Add(Me.btnWheelDiamondToolOffsetNumberAdd)
        Me.GroupBox3.Controls.Add(Me.txtWheelDiamondToolOffsetNumberValue)
        Me.GroupBox3.Location = New System.Drawing.Point(264, 485)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(259, 62)
        Me.GroupBox3.TabIndex = 350
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Wheel Diamond Tool Offset Number"
        '
        'btnWheelDiamondToolOffsetNumberSet
        '
        Me.btnWheelDiamondToolOffsetNumberSet.Location = New System.Drawing.Point(17, 23)
        Me.btnWheelDiamondToolOffsetNumberSet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWheelDiamondToolOffsetNumberSet.Name = "btnWheelDiamondToolOffsetNumberSet"
        Me.btnWheelDiamondToolOffsetNumberSet.Size = New System.Drawing.Size(47, 30)
        Me.btnWheelDiamondToolOffsetNumberSet.TabIndex = 340
        Me.btnWheelDiamondToolOffsetNumberSet.Text = "Set"
        '
        'txtWheelDiamondToolOffsetNumber
        '
        Me.txtWheelDiamondToolOffsetNumber.Location = New System.Drawing.Point(120, 26)
        Me.txtWheelDiamondToolOffsetNumber.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelDiamondToolOffsetNumber.Name = "txtWheelDiamondToolOffsetNumber"
        Me.txtWheelDiamondToolOffsetNumber.ReadOnly = True
        Me.txtWheelDiamondToolOffsetNumber.Size = New System.Drawing.Size(52, 22)
        Me.txtWheelDiamondToolOffsetNumber.TabIndex = 324
        '
        'btnWheelDiamondToolOffsetNumberAdd
        '
        Me.btnWheelDiamondToolOffsetNumberAdd.Location = New System.Drawing.Point(63, 23)
        Me.btnWheelDiamondToolOffsetNumberAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWheelDiamondToolOffsetNumberAdd.Name = "btnWheelDiamondToolOffsetNumberAdd"
        Me.btnWheelDiamondToolOffsetNumberAdd.Size = New System.Drawing.Size(47, 30)
        Me.btnWheelDiamondToolOffsetNumberAdd.TabIndex = 339
        Me.btnWheelDiamondToolOffsetNumberAdd.Text = "Add"
        '
        'txtWheelDiamondToolOffsetNumberValue
        '
        Me.txtWheelDiamondToolOffsetNumberValue.ForeColor = System.Drawing.Color.Red
        Me.txtWheelDiamondToolOffsetNumberValue.Location = New System.Drawing.Point(183, 26)
        Me.txtWheelDiamondToolOffsetNumberValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelDiamondToolOffsetNumberValue.Name = "txtWheelDiamondToolOffsetNumberValue"
        Me.txtWheelDiamondToolOffsetNumberValue.Size = New System.Drawing.Size(52, 22)
        Me.txtWheelDiamondToolOffsetNumberValue.TabIndex = 341
        Me.txtWheelDiamondToolOffsetNumberValue.Text = "0"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnWheelDataNumberSet)
        Me.GroupBox2.Controls.Add(Me.txtWheelDataNumber)
        Me.GroupBox2.Controls.Add(Me.btnWheelDataNumberAdd)
        Me.GroupBox2.Controls.Add(Me.txtWheelDataNumberValue)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 407)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(247, 62)
        Me.GroupBox2.TabIndex = 349
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Wheel Data Number"
        '
        'btnWheelDataNumberSet
        '
        Me.btnWheelDataNumberSet.Location = New System.Drawing.Point(17, 23)
        Me.btnWheelDataNumberSet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWheelDataNumberSet.Name = "btnWheelDataNumberSet"
        Me.btnWheelDataNumberSet.Size = New System.Drawing.Size(47, 30)
        Me.btnWheelDataNumberSet.TabIndex = 340
        Me.btnWheelDataNumberSet.Text = "Set"
        '
        'txtWheelDataNumber
        '
        Me.txtWheelDataNumber.Location = New System.Drawing.Point(120, 26)
        Me.txtWheelDataNumber.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelDataNumber.Name = "txtWheelDataNumber"
        Me.txtWheelDataNumber.ReadOnly = True
        Me.txtWheelDataNumber.Size = New System.Drawing.Size(52, 22)
        Me.txtWheelDataNumber.TabIndex = 324
        '
        'btnWheelDataNumberAdd
        '
        Me.btnWheelDataNumberAdd.Location = New System.Drawing.Point(63, 23)
        Me.btnWheelDataNumberAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWheelDataNumberAdd.Name = "btnWheelDataNumberAdd"
        Me.btnWheelDataNumberAdd.Size = New System.Drawing.Size(47, 30)
        Me.btnWheelDataNumberAdd.TabIndex = 339
        Me.btnWheelDataNumberAdd.Text = "Add"
        '
        'txtWheelDataNumberValue
        '
        Me.txtWheelDataNumberValue.ForeColor = System.Drawing.Color.Red
        Me.txtWheelDataNumberValue.Location = New System.Drawing.Point(183, 26)
        Me.txtWheelDataNumberValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelDataNumberValue.Name = "txtWheelDataNumberValue"
        Me.txtWheelDataNumberValue.Size = New System.Drawing.Size(52, 22)
        Me.txtWheelDataNumberValue.TabIndex = 341
        Me.txtWheelDataNumberValue.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnReferencePositionSet)
        Me.GroupBox1.Controls.Add(Me.txtWheelReferencePosition)
        Me.GroupBox1.Controls.Add(Me.btnReferencePositionAdd)
        Me.GroupBox1.Controls.Add(Me.txtWheelReferencePositionValue)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 485)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(247, 62)
        Me.GroupBox1.TabIndex = 348
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reference Position"
        '
        'btnReferencePositionSet
        '
        Me.btnReferencePositionSet.Location = New System.Drawing.Point(15, 23)
        Me.btnReferencePositionSet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnReferencePositionSet.Name = "btnReferencePositionSet"
        Me.btnReferencePositionSet.Size = New System.Drawing.Size(47, 30)
        Me.btnReferencePositionSet.TabIndex = 340
        Me.btnReferencePositionSet.Text = "Set"
        '
        'txtWheelReferencePosition
        '
        Me.txtWheelReferencePosition.Location = New System.Drawing.Point(117, 26)
        Me.txtWheelReferencePosition.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelReferencePosition.Name = "txtWheelReferencePosition"
        Me.txtWheelReferencePosition.ReadOnly = True
        Me.txtWheelReferencePosition.Size = New System.Drawing.Size(52, 22)
        Me.txtWheelReferencePosition.TabIndex = 324
        '
        'btnReferencePositionAdd
        '
        Me.btnReferencePositionAdd.Location = New System.Drawing.Point(60, 23)
        Me.btnReferencePositionAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnReferencePositionAdd.Name = "btnReferencePositionAdd"
        Me.btnReferencePositionAdd.Size = New System.Drawing.Size(47, 30)
        Me.btnReferencePositionAdd.TabIndex = 339
        Me.btnReferencePositionAdd.Text = "Add"
        '
        'txtWheelReferencePositionValue
        '
        Me.txtWheelReferencePositionValue.ForeColor = System.Drawing.Color.Red
        Me.txtWheelReferencePositionValue.Location = New System.Drawing.Point(180, 26)
        Me.txtWheelReferencePositionValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelReferencePositionValue.Name = "txtWheelReferencePositionValue"
        Me.txtWheelReferencePositionValue.Size = New System.Drawing.Size(52, 22)
        Me.txtWheelReferencePositionValue.TabIndex = 341
        Me.txtWheelReferencePositionValue.Text = "0"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(19, 78)
        Me.Label41.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(192, 17)
        Me.Label41.TabIndex = 337
        Me.Label41.Text = "Wheel Spindle Rate Override"
        '
        'txtWheelSpindleRateOverride
        '
        Me.txtWheelSpindleRateOverride.Location = New System.Drawing.Point(269, 79)
        Me.txtWheelSpindleRateOverride.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelSpindleRateOverride.Name = "txtWheelSpindleRateOverride"
        Me.txtWheelSpindleRateOverride.Size = New System.Drawing.Size(132, 22)
        Me.txtWheelSpindleRateOverride.TabIndex = 336
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(19, 228)
        Me.Label36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(107, 17)
        Me.Label36.TabIndex = 335
        Me.Label36.Text = "Wheel OL Load"
        '
        'txtWheelOLLoad
        '
        Me.txtWheelOLLoad.Location = New System.Drawing.Point(269, 229)
        Me.txtWheelOLLoad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelOLLoad.Name = "txtWheelOLLoad"
        Me.txtWheelOLLoad.Size = New System.Drawing.Size(132, 22)
        Me.txtWheelOLLoad.TabIndex = 334
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(19, 197)
        Me.Label37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(117, 17)
        Me.Label37.TabIndex = 333
        Me.Label37.Text = "Wheel GAP Load"
        '
        'txtWheelGAPLoad
        '
        Me.txtWheelGAPLoad.Location = New System.Drawing.Point(269, 199)
        Me.txtWheelGAPLoad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelGAPLoad.Name = "txtWheelGAPLoad"
        Me.txtWheelGAPLoad.Size = New System.Drawing.Size(132, 22)
        Me.txtWheelGAPLoad.TabIndex = 332
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(19, 167)
        Me.Label38.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(124, 17)
        Me.Label38.TabIndex = 331
        Me.Label38.Text = "Wheel Effect Load"
        '
        'txtWheelEffectLoad
        '
        Me.txtWheelEffectLoad.Location = New System.Drawing.Point(269, 169)
        Me.txtWheelEffectLoad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelEffectLoad.Name = "txtWheelEffectLoad"
        Me.txtWheelEffectLoad.Size = New System.Drawing.Size(132, 22)
        Me.txtWheelEffectLoad.TabIndex = 330
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(19, 138)
        Me.Label39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(143, 17)
        Me.Label39.TabIndex = 329
        Me.Label39.Text = "Wheel Measure Load"
        '
        'txtWheelMeasureLoad
        '
        Me.txtWheelMeasureLoad.Location = New System.Drawing.Point(269, 139)
        Me.txtWheelMeasureLoad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelMeasureLoad.Name = "txtWheelMeasureLoad"
        Me.txtWheelMeasureLoad.Size = New System.Drawing.Size(132, 22)
        Me.txtWheelMeasureLoad.TabIndex = 328
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(19, 108)
        Me.Label40.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(197, 17)
        Me.Label40.TabIndex = 327
        Me.Label40.Text = "Wheel Spindle Surface Speed"
        '
        'txtWheelSpindleSurfaceSpeed
        '
        Me.txtWheelSpindleSurfaceSpeed.Location = New System.Drawing.Point(269, 110)
        Me.txtWheelSpindleSurfaceSpeed.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelSpindleSurfaceSpeed.Name = "txtWheelSpindleSurfaceSpeed"
        Me.txtWheelSpindleSurfaceSpeed.Size = New System.Drawing.Size(132, 22)
        Me.txtWheelSpindleSurfaceSpeed.TabIndex = 326
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(19, 48)
        Me.Label34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(195, 17)
        Me.Label34.TabIndex = 319
        Me.Label34.Text = "Command Wheel Spindle rate"
        '
        'txtWheelCommandSpindleRate
        '
        Me.txtWheelCommandSpindleRate.Location = New System.Drawing.Point(269, 49)
        Me.txtWheelCommandSpindleRate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelCommandSpindleRate.Name = "txtWheelCommandSpindleRate"
        Me.txtWheelCommandSpindleRate.Size = New System.Drawing.Size(132, 22)
        Me.txtWheelCommandSpindleRate.TabIndex = 318
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(19, 16)
        Me.Label35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(171, 17)
        Me.Label35.TabIndex = 317
        Me.Label35.Text = "Actual Wheel Spindle rate"
        '
        'txtWheelActualSpindleRate
        '
        Me.txtWheelActualSpindleRate.Location = New System.Drawing.Point(269, 17)
        Me.txtWheelActualSpindleRate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWheelActualSpindleRate.Name = "txtWheelActualSpindleRate"
        Me.txtWheelActualSpindleRate.Size = New System.Drawing.Size(132, 22)
        Me.txtWheelActualSpindleRate.TabIndex = 316
        '
        'btnWheel
        '
        Me.btnWheel.Location = New System.Drawing.Point(429, 49)
        Me.btnWheel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWheel.Name = "btnWheel"
        Me.btnWheel.Size = New System.Drawing.Size(107, 30)
        Me.btnWheel.TabIndex = 311
        Me.btnWheel.Text = "Update"
        '
        'tabWorkpiece
        '
        Me.tabWorkpiece.Controls.Add(Me.GroupBox30)
        Me.tabWorkpiece.Controls.Add(Me.GroupBox29)
        Me.tabWorkpiece.Controls.Add(Me.GroupBox28)
        Me.tabWorkpiece.Controls.Add(Me.GroupBox27)
        Me.tabWorkpiece.Controls.Add(Me.GroupBox26)
        Me.tabWorkpiece.Controls.Add(Me.GroupBox25)
        Me.tabWorkpiece.Controls.Add(Me.GroupBox6)
        Me.tabWorkpiece.Controls.Add(Me.GroupBox7)
        Me.tabWorkpiece.Controls.Add(Me.Label45)
        Me.tabWorkpiece.Controls.Add(Me.cboWorkpieceDataUnit)
        Me.tabWorkpiece.Controls.Add(Me.btnUpdateWorkpiece)
        Me.tabWorkpiece.Location = New System.Drawing.Point(4, 25)
        Me.tabWorkpiece.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabWorkpiece.Name = "tabWorkpiece"
        Me.tabWorkpiece.Size = New System.Drawing.Size(1012, 555)
        Me.tabWorkpiece.TabIndex = 7
        Me.tabWorkpiece.Text = "Workpiece"
        Me.tabWorkpiece.UseVisualStyleBackColor = True
        '
        'GroupBox30
        '
        Me.GroupBox30.Controls.Add(Me.cboWorkOffsetLocatorPositiveSideEndFace)
        Me.GroupBox30.Controls.Add(Me.btnWorkLocatorPositiveSideEndFaceSet)
        Me.GroupBox30.Controls.Add(Me.txtWorkLocatorPositiveSideEndFace)
        Me.GroupBox30.Controls.Add(Me.btnWorkLocatorPositiveSideEndFaceAdd)
        Me.GroupBox30.Controls.Add(Me.txtWorkLocatorPositiveSideEndFaceValue)
        Me.GroupBox30.Location = New System.Drawing.Point(5, 370)
        Me.GroupBox30.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox30.Name = "GroupBox30"
        Me.GroupBox30.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox30.Size = New System.Drawing.Size(612, 62)
        Me.GroupBox30.TabIndex = 370
        Me.GroupBox30.TabStop = False
        Me.GroupBox30.Text = "Work Locator Positive Side End Face"
        '
        'cboWorkOffsetLocatorPositiveSideEndFace
        '
        Me.cboWorkOffsetLocatorPositiveSideEndFace.Location = New System.Drawing.Point(428, 23)
        Me.cboWorkOffsetLocatorPositiveSideEndFace.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboWorkOffsetLocatorPositiveSideEndFace.Name = "cboWorkOffsetLocatorPositiveSideEndFace"
        Me.cboWorkOffsetLocatorPositiveSideEndFace.Size = New System.Drawing.Size(171, 24)
        Me.cboWorkOffsetLocatorPositiveSideEndFace.TabIndex = 342
        '
        'btnWorkLocatorPositiveSideEndFaceSet
        '
        Me.btnWorkLocatorPositiveSideEndFaceSet.Location = New System.Drawing.Point(17, 23)
        Me.btnWorkLocatorPositiveSideEndFaceSet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWorkLocatorPositiveSideEndFaceSet.Name = "btnWorkLocatorPositiveSideEndFaceSet"
        Me.btnWorkLocatorPositiveSideEndFaceSet.Size = New System.Drawing.Size(47, 30)
        Me.btnWorkLocatorPositiveSideEndFaceSet.TabIndex = 340
        Me.btnWorkLocatorPositiveSideEndFaceSet.Text = "Set"
        '
        'txtWorkLocatorPositiveSideEndFace
        '
        Me.txtWorkLocatorPositiveSideEndFace.Location = New System.Drawing.Point(163, 26)
        Me.txtWorkLocatorPositiveSideEndFace.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWorkLocatorPositiveSideEndFace.Name = "txtWorkLocatorPositiveSideEndFace"
        Me.txtWorkLocatorPositiveSideEndFace.ReadOnly = True
        Me.txtWorkLocatorPositiveSideEndFace.Size = New System.Drawing.Size(115, 22)
        Me.txtWorkLocatorPositiveSideEndFace.TabIndex = 324
        '
        'btnWorkLocatorPositiveSideEndFaceAdd
        '
        Me.btnWorkLocatorPositiveSideEndFaceAdd.Location = New System.Drawing.Point(63, 23)
        Me.btnWorkLocatorPositiveSideEndFaceAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWorkLocatorPositiveSideEndFaceAdd.Name = "btnWorkLocatorPositiveSideEndFaceAdd"
        Me.btnWorkLocatorPositiveSideEndFaceAdd.Size = New System.Drawing.Size(47, 30)
        Me.btnWorkLocatorPositiveSideEndFaceAdd.TabIndex = 339
        Me.btnWorkLocatorPositiveSideEndFaceAdd.Text = "Add"
        '
        'txtWorkLocatorPositiveSideEndFaceValue
        '
        Me.txtWorkLocatorPositiveSideEndFaceValue.ForeColor = System.Drawing.Color.Red
        Me.txtWorkLocatorPositiveSideEndFaceValue.Location = New System.Drawing.Point(295, 25)
        Me.txtWorkLocatorPositiveSideEndFaceValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWorkLocatorPositiveSideEndFaceValue.Name = "txtWorkLocatorPositiveSideEndFaceValue"
        Me.txtWorkLocatorPositiveSideEndFaceValue.Size = New System.Drawing.Size(124, 22)
        Me.txtWorkLocatorPositiveSideEndFaceValue.TabIndex = 341
        Me.txtWorkLocatorPositiveSideEndFaceValue.Text = "0"
        '
        'GroupBox29
        '
        Me.GroupBox29.Controls.Add(Me.cboWorkOffsetLocatorNegativeSideEndFace)
        Me.GroupBox29.Controls.Add(Me.btnWorkLocatorNegativeSideEndFaceSet)
        Me.GroupBox29.Controls.Add(Me.txtWorkLocatorNegativeSideEndFace)
        Me.GroupBox29.Controls.Add(Me.btnWorkLocatorNegativeSideEndFaceAdd)
        Me.GroupBox29.Controls.Add(Me.txtWorkLocatorNegativeSideEndFaceValue)
        Me.GroupBox29.Location = New System.Drawing.Point(5, 309)
        Me.GroupBox29.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox29.Name = "GroupBox29"
        Me.GroupBox29.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox29.Size = New System.Drawing.Size(612, 62)
        Me.GroupBox29.TabIndex = 369
        Me.GroupBox29.TabStop = False
        Me.GroupBox29.Text = "Work Locator Negative Side End Face"
        '
        'cboWorkOffsetLocatorNegativeSideEndFace
        '
        Me.cboWorkOffsetLocatorNegativeSideEndFace.Location = New System.Drawing.Point(428, 23)
        Me.cboWorkOffsetLocatorNegativeSideEndFace.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboWorkOffsetLocatorNegativeSideEndFace.Name = "cboWorkOffsetLocatorNegativeSideEndFace"
        Me.cboWorkOffsetLocatorNegativeSideEndFace.Size = New System.Drawing.Size(171, 24)
        Me.cboWorkOffsetLocatorNegativeSideEndFace.TabIndex = 342
        '
        'btnWorkLocatorNegativeSideEndFaceSet
        '
        Me.btnWorkLocatorNegativeSideEndFaceSet.Location = New System.Drawing.Point(17, 23)
        Me.btnWorkLocatorNegativeSideEndFaceSet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWorkLocatorNegativeSideEndFaceSet.Name = "btnWorkLocatorNegativeSideEndFaceSet"
        Me.btnWorkLocatorNegativeSideEndFaceSet.Size = New System.Drawing.Size(47, 30)
        Me.btnWorkLocatorNegativeSideEndFaceSet.TabIndex = 340
        Me.btnWorkLocatorNegativeSideEndFaceSet.Text = "Set"
        '
        'txtWorkLocatorNegativeSideEndFace
        '
        Me.txtWorkLocatorNegativeSideEndFace.Location = New System.Drawing.Point(163, 26)
        Me.txtWorkLocatorNegativeSideEndFace.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWorkLocatorNegativeSideEndFace.Name = "txtWorkLocatorNegativeSideEndFace"
        Me.txtWorkLocatorNegativeSideEndFace.ReadOnly = True
        Me.txtWorkLocatorNegativeSideEndFace.Size = New System.Drawing.Size(115, 22)
        Me.txtWorkLocatorNegativeSideEndFace.TabIndex = 324
        '
        'btnWorkLocatorNegativeSideEndFaceAdd
        '
        Me.btnWorkLocatorNegativeSideEndFaceAdd.Location = New System.Drawing.Point(63, 23)
        Me.btnWorkLocatorNegativeSideEndFaceAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnWorkLocatorNegativeSideEndFaceAdd.Name = "btnWorkLocatorNegativeSideEndFaceAdd"
        Me.btnWorkLocatorNegativeSideEndFaceAdd.Size = New System.Drawing.Size(47, 30)
        Me.btnWorkLocatorNegativeSideEndFaceAdd.TabIndex = 339
        Me.btnWorkLocatorNegativeSideEndFaceAdd.Text = "Add"
        '
        'txtWorkLocatorNegativeSideEndFaceValue
        '
        Me.txtWorkLocatorNegativeSideEndFaceValue.ForeColor = System.Drawing.Color.Red
        Me.txtWorkLocatorNegativeSideEndFaceValue.Location = New System.Drawing.Point(295, 25)
        Me.txtWorkLocatorNegativeSideEndFaceValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtWorkLocatorNegativeSideEndFaceValue.Name = "txtWorkLocatorNegativeSideEndFaceValue"
        Me.txtWorkLocatorNegativeSideEndFaceValue.Size = New System.Drawing.Size(124, 22)
        Me.txtWorkLocatorNegativeSideEndFaceValue.TabIndex = 341
        Me.txtWorkLocatorNegativeSideEndFaceValue.Text = "0"
        '
        'GroupBox28
        '
        Me.GroupBox28.Controls.Add(Me.cboWorkOffsetCompMeasure)
        Me.GroupBox28.Controls.Add(Me.btnCompMeasureSet)
        Me.GroupBox28.Controls.Add(Me.txtCompMeasure)
        Me.GroupBox28.Controls.Add(Me.btnCompMeasureAdd)
        Me.GroupBox28.Controls.Add(Me.txtCompMeasureValue)
        Me.GroupBox28.Location = New System.Drawing.Point(7, 116)
        Me.GroupBox28.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox28.Name = "GroupBox28"
        Me.GroupBox28.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox28.Size = New System.Drawing.Size(612, 62)
        Me.GroupBox28.TabIndex = 368
        Me.GroupBox28.TabStop = False
        Me.GroupBox28.Text = "Work Zero Compensation Measurement"
        '
        'cboWorkOffsetCompMeasure
        '
        Me.cboWorkOffsetCompMeasure.Location = New System.Drawing.Point(428, 23)
        Me.cboWorkOffsetCompMeasure.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboWorkOffsetCompMeasure.Name = "cboWorkOffsetCompMeasure"
        Me.cboWorkOffsetCompMeasure.Size = New System.Drawing.Size(171, 24)
        Me.cboWorkOffsetCompMeasure.TabIndex = 342
        '
        'btnCompMeasureSet
        '
        Me.btnCompMeasureSet.Location = New System.Drawing.Point(17, 23)
        Me.btnCompMeasureSet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCompMeasureSet.Name = "btnCompMeasureSet"
        Me.btnCompMeasureSet.Size = New System.Drawing.Size(47, 30)
        Me.btnCompMeasureSet.TabIndex = 340
        Me.btnCompMeasureSet.Text = "Set"
        '
        'txtCompMeasure
        '
        Me.txtCompMeasure.Location = New System.Drawing.Point(163, 26)
        Me.txtCompMeasure.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCompMeasure.Name = "txtCompMeasure"
        Me.txtCompMeasure.ReadOnly = True
        Me.txtCompMeasure.Size = New System.Drawing.Size(115, 22)
        Me.txtCompMeasure.TabIndex = 324
        '
        'btnCompMeasureAdd
        '
        Me.btnCompMeasureAdd.Location = New System.Drawing.Point(63, 23)
        Me.btnCompMeasureAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCompMeasureAdd.Name = "btnCompMeasureAdd"
        Me.btnCompMeasureAdd.Size = New System.Drawing.Size(47, 30)
        Me.btnCompMeasureAdd.TabIndex = 339
        Me.btnCompMeasureAdd.Text = "Add"
        '
        'txtCompMeasureValue
        '
        Me.txtCompMeasureValue.ForeColor = System.Drawing.Color.Red
        Me.txtCompMeasureValue.Location = New System.Drawing.Point(295, 25)
        Me.txtCompMeasureValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCompMeasureValue.Name = "txtCompMeasureValue"
        Me.txtCompMeasureValue.Size = New System.Drawing.Size(124, 22)
        Me.txtCompMeasureValue.TabIndex = 341
        Me.txtCompMeasureValue.Text = "0"
        '
        'GroupBox27
        '
        Me.GroupBox27.Controls.Add(Me.cboWorkOffsetMasterWork)
        Me.GroupBox27.Controls.Add(Me.btnMasterWorkOffsetSet)
        Me.GroupBox27.Controls.Add(Me.txtMasterWorkOffset)
        Me.GroupBox27.Controls.Add(Me.btnMasterWorkOffsetAdd)
        Me.GroupBox27.Controls.Add(Me.txtMasterWorkOffsetValue)
        Me.GroupBox27.Location = New System.Drawing.Point(7, 54)
        Me.GroupBox27.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox27.Name = "GroupBox27"
        Me.GroupBox27.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox27.Size = New System.Drawing.Size(612, 62)
        Me.GroupBox27.TabIndex = 367
        Me.GroupBox27.TabStop = False
        Me.GroupBox27.Text = "Master Work"
        '
        'cboWorkOffsetMasterWork
        '
        Me.cboWorkOffsetMasterWork.Location = New System.Drawing.Point(428, 23)
        Me.cboWorkOffsetMasterWork.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboWorkOffsetMasterWork.Name = "cboWorkOffsetMasterWork"
        Me.cboWorkOffsetMasterWork.Size = New System.Drawing.Size(171, 24)
        Me.cboWorkOffsetMasterWork.TabIndex = 342
        '
        'btnMasterWorkOffsetSet
        '
        Me.btnMasterWorkOffsetSet.Location = New System.Drawing.Point(17, 23)
        Me.btnMasterWorkOffsetSet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnMasterWorkOffsetSet.Name = "btnMasterWorkOffsetSet"
        Me.btnMasterWorkOffsetSet.Size = New System.Drawing.Size(47, 30)
        Me.btnMasterWorkOffsetSet.TabIndex = 340
        Me.btnMasterWorkOffsetSet.Text = "Set"
        '
        'txtMasterWorkOffset
        '
        Me.txtMasterWorkOffset.Location = New System.Drawing.Point(163, 26)
        Me.txtMasterWorkOffset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtMasterWorkOffset.Name = "txtMasterWorkOffset"
        Me.txtMasterWorkOffset.ReadOnly = True
        Me.txtMasterWorkOffset.Size = New System.Drawing.Size(115, 22)
        Me.txtMasterWorkOffset.TabIndex = 324
        '
        'btnMasterWorkOffsetAdd
        '
        Me.btnMasterWorkOffsetAdd.Location = New System.Drawing.Point(63, 23)
        Me.btnMasterWorkOffsetAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnMasterWorkOffsetAdd.Name = "btnMasterWorkOffsetAdd"
        Me.btnMasterWorkOffsetAdd.Size = New System.Drawing.Size(47, 30)
        Me.btnMasterWorkOffsetAdd.TabIndex = 339
        Me.btnMasterWorkOffsetAdd.Text = "Add"
        '
        'txtMasterWorkOffsetValue
        '
        Me.txtMasterWorkOffsetValue.ForeColor = System.Drawing.Color.Red
        Me.txtMasterWorkOffsetValue.Location = New System.Drawing.Point(295, 25)
        Me.txtMasterWorkOffsetValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtMasterWorkOffsetValue.Name = "txtMasterWorkOffsetValue"
        Me.txtMasterWorkOffsetValue.Size = New System.Drawing.Size(124, 22)
        Me.txtMasterWorkOffsetValue.TabIndex = 341
        Me.txtMasterWorkOffsetValue.Text = "0"
        '
        'GroupBox26
        '
        Me.GroupBox26.Controls.Add(Me.btnWPCounterSet_Add)
        Me.GroupBox26.Controls.Add(Me.wkCounterSetCombo)
        Me.GroupBox26.Controls.Add(Me.btnWPCounterSet_Get)
        Me.GroupBox26.Controls.Add(Me.btnWPCounterSet_Set)
        Me.GroupBox26.Controls.Add(Me.txtWPCounterSetValue)
        Me.GroupBox26.Controls.Add(Me.txtWPCounterSet)
        Me.GroupBox26.Location = New System.Drawing.Point(623, 135)
        Me.GroupBox26.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox26.Name = "GroupBox26"
        Me.GroupBox26.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox26.Size = New System.Drawing.Size(360, 80)
        Me.GroupBox26.TabIndex = 366
        Me.GroupBox26.TabStop = False
        Me.GroupBox26.Text = "Workpiece Counter Set:"
        '
        'btnWPCounterSet_Add
        '
        Me.btnWPCounterSet_Add.Location = New System.Drawing.Point(296, 18)
        Me.btnWPCounterSet_Add.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnWPCounterSet_Add.Name = "btnWPCounterSet_Add"
        Me.btnWPCounterSet_Add.Size = New System.Drawing.Size(57, 27)
        Me.btnWPCounterSet_Add.TabIndex = 176
        Me.btnWPCounterSet_Add.Text = "Add"
        '
        'wkCounterSetCombo
        '
        Me.wkCounterSetCombo.Location = New System.Drawing.Point(171, 50)
        Me.wkCounterSetCombo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.wkCounterSetCombo.Name = "wkCounterSetCombo"
        Me.wkCounterSetCombo.Size = New System.Drawing.Size(172, 24)
        Me.wkCounterSetCombo.TabIndex = 163
        '
        'btnWPCounterSet_Get
        '
        Me.btnWPCounterSet_Get.Location = New System.Drawing.Point(181, 18)
        Me.btnWPCounterSet_Get.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnWPCounterSet_Get.Name = "btnWPCounterSet_Get"
        Me.btnWPCounterSet_Get.Size = New System.Drawing.Size(48, 28)
        Me.btnWPCounterSet_Get.TabIndex = 174
        Me.btnWPCounterSet_Get.Text = "Get"
        '
        'btnWPCounterSet_Set
        '
        Me.btnWPCounterSet_Set.Location = New System.Drawing.Point(237, 18)
        Me.btnWPCounterSet_Set.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnWPCounterSet_Set.Name = "btnWPCounterSet_Set"
        Me.btnWPCounterSet_Set.Size = New System.Drawing.Size(48, 28)
        Me.btnWPCounterSet_Set.TabIndex = 167
        Me.btnWPCounterSet_Set.Text = "Set"
        '
        'txtWPCounterSetValue
        '
        Me.txtWPCounterSetValue.ForeColor = System.Drawing.Color.Red
        Me.txtWPCounterSetValue.Location = New System.Drawing.Point(88, 50)
        Me.txtWPCounterSetValue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtWPCounterSetValue.Name = "txtWPCounterSetValue"
        Me.txtWPCounterSetValue.Size = New System.Drawing.Size(76, 22)
        Me.txtWPCounterSetValue.TabIndex = 164
        Me.txtWPCounterSetValue.Text = "0"
        '
        'txtWPCounterSet
        '
        Me.txtWPCounterSet.Enabled = False
        Me.txtWPCounterSet.Location = New System.Drawing.Point(5, 50)
        Me.txtWPCounterSet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtWPCounterSet.Name = "txtWPCounterSet"
        Me.txtWPCounterSet.ReadOnly = True
        Me.txtWPCounterSet.Size = New System.Drawing.Size(76, 22)
        Me.txtWPCounterSet.TabIndex = 166
        Me.txtWPCounterSet.Text = "0"
        '
        'GroupBox25
        '
        Me.GroupBox25.Controls.Add(Me.cmd_addWorkpiece)
        Me.GroupBox25.Controls.Add(Me.wkUpdateCounter)
        Me.GroupBox25.Controls.Add(Me.wkCounterCombo)
        Me.GroupBox25.Controls.Add(Me.wkSetCounterValue)
        Me.GroupBox25.Controls.Add(Me.wkGetCounterValue)
        Me.GroupBox25.Controls.Add(Me.wkCounterValue)
        Me.GroupBox25.Location = New System.Drawing.Point(623, 54)
        Me.GroupBox25.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox25.Name = "GroupBox25"
        Me.GroupBox25.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox25.Size = New System.Drawing.Size(360, 80)
        Me.GroupBox25.TabIndex = 365
        Me.GroupBox25.TabStop = False
        Me.GroupBox25.Text = "Workpiece Counter Count:"
        '
        'cmd_addWorkpiece
        '
        Me.cmd_addWorkpiece.Location = New System.Drawing.Point(293, 17)
        Me.cmd_addWorkpiece.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmd_addWorkpiece.Name = "cmd_addWorkpiece"
        Me.cmd_addWorkpiece.Size = New System.Drawing.Size(57, 27)
        Me.cmd_addWorkpiece.TabIndex = 176
        Me.cmd_addWorkpiece.Text = "Add"
        '
        'wkUpdateCounter
        '
        Me.wkUpdateCounter.ForeColor = System.Drawing.Color.Red
        Me.wkUpdateCounter.Location = New System.Drawing.Point(88, 50)
        Me.wkUpdateCounter.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.wkUpdateCounter.Name = "wkUpdateCounter"
        Me.wkUpdateCounter.Size = New System.Drawing.Size(76, 22)
        Me.wkUpdateCounter.TabIndex = 164
        Me.wkUpdateCounter.Text = "0"
        '
        'wkCounterCombo
        '
        Me.wkCounterCombo.Location = New System.Drawing.Point(171, 50)
        Me.wkCounterCombo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.wkCounterCombo.Name = "wkCounterCombo"
        Me.wkCounterCombo.Size = New System.Drawing.Size(180, 24)
        Me.wkCounterCombo.TabIndex = 163
        '
        'wkSetCounterValue
        '
        Me.wkSetCounterValue.Location = New System.Drawing.Point(235, 17)
        Me.wkSetCounterValue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.wkSetCounterValue.Name = "wkSetCounterValue"
        Me.wkSetCounterValue.Size = New System.Drawing.Size(48, 28)
        Me.wkSetCounterValue.TabIndex = 167
        Me.wkSetCounterValue.Text = "Set"
        '
        'wkGetCounterValue
        '
        Me.wkGetCounterValue.Location = New System.Drawing.Point(181, 17)
        Me.wkGetCounterValue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.wkGetCounterValue.Name = "wkGetCounterValue"
        Me.wkGetCounterValue.Size = New System.Drawing.Size(48, 28)
        Me.wkGetCounterValue.TabIndex = 174
        Me.wkGetCounterValue.Text = "Get"
        '
        'wkCounterValue
        '
        Me.wkCounterValue.Enabled = False
        Me.wkCounterValue.Location = New System.Drawing.Point(5, 50)
        Me.wkCounterValue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.wkCounterValue.Name = "wkCounterValue"
        Me.wkCounterValue.ReadOnly = True
        Me.wkCounterValue.Size = New System.Drawing.Size(76, 22)
        Me.wkCounterValue.TabIndex = 166
        Me.wkCounterValue.Text = "0"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cboZeroShiftAxis)
        Me.GroupBox6.Controls.Add(Me.btnZeroShiftSet)
        Me.GroupBox6.Controls.Add(Me.txtZeroShift)
        Me.GroupBox6.Controls.Add(Me.btnZeroShiftAdd)
        Me.GroupBox6.Controls.Add(Me.txtZeroShiftValue)
        Me.GroupBox6.Location = New System.Drawing.Point(7, 245)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox6.Size = New System.Drawing.Size(612, 62)
        Me.GroupBox6.TabIndex = 362
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Zero Shift"
        '
        'cboZeroShiftAxis
        '
        Me.cboZeroShiftAxis.Location = New System.Drawing.Point(428, 23)
        Me.cboZeroShiftAxis.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboZeroShiftAxis.Name = "cboZeroShiftAxis"
        Me.cboZeroShiftAxis.Size = New System.Drawing.Size(171, 24)
        Me.cboZeroShiftAxis.TabIndex = 342
        '
        'btnZeroShiftSet
        '
        Me.btnZeroShiftSet.Location = New System.Drawing.Point(17, 23)
        Me.btnZeroShiftSet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnZeroShiftSet.Name = "btnZeroShiftSet"
        Me.btnZeroShiftSet.Size = New System.Drawing.Size(47, 30)
        Me.btnZeroShiftSet.TabIndex = 340
        Me.btnZeroShiftSet.Text = "Set"
        '
        'txtZeroShift
        '
        Me.txtZeroShift.Location = New System.Drawing.Point(163, 26)
        Me.txtZeroShift.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtZeroShift.Name = "txtZeroShift"
        Me.txtZeroShift.ReadOnly = True
        Me.txtZeroShift.Size = New System.Drawing.Size(115, 22)
        Me.txtZeroShift.TabIndex = 324
        '
        'btnZeroShiftAdd
        '
        Me.btnZeroShiftAdd.Location = New System.Drawing.Point(61, 23)
        Me.btnZeroShiftAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnZeroShiftAdd.Name = "btnZeroShiftAdd"
        Me.btnZeroShiftAdd.Size = New System.Drawing.Size(47, 30)
        Me.btnZeroShiftAdd.TabIndex = 339
        Me.btnZeroShiftAdd.Text = "Add"
        '
        'txtZeroShiftValue
        '
        Me.txtZeroShiftValue.ForeColor = System.Drawing.Color.Red
        Me.txtZeroShiftValue.Location = New System.Drawing.Point(295, 25)
        Me.txtZeroShiftValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtZeroShiftValue.Name = "txtZeroShiftValue"
        Me.txtZeroShiftValue.Size = New System.Drawing.Size(124, 22)
        Me.txtZeroShiftValue.TabIndex = 341
        Me.txtZeroShiftValue.Text = "0"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cboZeroOffsetAxis)
        Me.GroupBox7.Controls.Add(Me.btnZeroOffsetSetSet)
        Me.GroupBox7.Controls.Add(Me.txtZeroOffset)
        Me.GroupBox7.Controls.Add(Me.btnZeroOffsetAdd)
        Me.GroupBox7.Controls.Add(Me.txtZeroOffsetValue)
        Me.GroupBox7.Location = New System.Drawing.Point(7, 185)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox7.Size = New System.Drawing.Size(612, 62)
        Me.GroupBox7.TabIndex = 361
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Zero Offset"
        '
        'cboZeroOffsetAxis
        '
        Me.cboZeroOffsetAxis.Location = New System.Drawing.Point(428, 23)
        Me.cboZeroOffsetAxis.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboZeroOffsetAxis.Name = "cboZeroOffsetAxis"
        Me.cboZeroOffsetAxis.Size = New System.Drawing.Size(171, 24)
        Me.cboZeroOffsetAxis.TabIndex = 342
        '
        'btnZeroOffsetSetSet
        '
        Me.btnZeroOffsetSetSet.Location = New System.Drawing.Point(17, 23)
        Me.btnZeroOffsetSetSet.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnZeroOffsetSetSet.Name = "btnZeroOffsetSetSet"
        Me.btnZeroOffsetSetSet.Size = New System.Drawing.Size(47, 30)
        Me.btnZeroOffsetSetSet.TabIndex = 340
        Me.btnZeroOffsetSetSet.Text = "Set"
        '
        'txtZeroOffset
        '
        Me.txtZeroOffset.Location = New System.Drawing.Point(163, 26)
        Me.txtZeroOffset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtZeroOffset.Name = "txtZeroOffset"
        Me.txtZeroOffset.ReadOnly = True
        Me.txtZeroOffset.Size = New System.Drawing.Size(115, 22)
        Me.txtZeroOffset.TabIndex = 324
        '
        'btnZeroOffsetAdd
        '
        Me.btnZeroOffsetAdd.Location = New System.Drawing.Point(63, 23)
        Me.btnZeroOffsetAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnZeroOffsetAdd.Name = "btnZeroOffsetAdd"
        Me.btnZeroOffsetAdd.Size = New System.Drawing.Size(47, 30)
        Me.btnZeroOffsetAdd.TabIndex = 339
        Me.btnZeroOffsetAdd.Text = "Add"
        '
        'txtZeroOffsetValue
        '
        Me.txtZeroOffsetValue.ForeColor = System.Drawing.Color.Red
        Me.txtZeroOffsetValue.Location = New System.Drawing.Point(295, 25)
        Me.txtZeroOffsetValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtZeroOffsetValue.Name = "txtZeroOffsetValue"
        Me.txtZeroOffsetValue.Size = New System.Drawing.Size(124, 22)
        Me.txtZeroOffsetValue.TabIndex = 341
        Me.txtZeroOffsetValue.Text = "0"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(457, 7)
        Me.Label45.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(67, 17)
        Me.Label45.TabIndex = 360
        Me.Label45.Text = "Data Unit"
        '
        'cboWorkpieceDataUnit
        '
        Me.cboWorkpieceDataUnit.Location = New System.Drawing.Point(549, 4)
        Me.cboWorkpieceDataUnit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboWorkpieceDataUnit.Name = "cboWorkpieceDataUnit"
        Me.cboWorkpieceDataUnit.Size = New System.Drawing.Size(171, 24)
        Me.cboWorkpieceDataUnit.TabIndex = 359
        '
        'btnUpdateWorkpiece
        '
        Me.btnUpdateWorkpiece.Location = New System.Drawing.Point(4, 4)
        Me.btnUpdateWorkpiece.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUpdateWorkpiece.Name = "btnUpdateWorkpiece"
        Me.btnUpdateWorkpiece.Size = New System.Drawing.Size(107, 30)
        Me.btnUpdateWorkpiece.TabIndex = 356
        Me.btnUpdateWorkpiece.Text = "Update"
        '
        'tabMacManAlarmHistory
        '
        Me.tabMacManAlarmHistory.Controls.Add(Me.lstAlarms)
        Me.tabMacManAlarmHistory.Controls.Add(Me.txtAlarmHistoryEndIndex)
        Me.tabMacManAlarmHistory.Controls.Add(Me.Label137)
        Me.tabMacManAlarmHistory.Controls.Add(Me.txtAlarmHistoryFromIndex)
        Me.tabMacManAlarmHistory.Controls.Add(Me.Label138)
        Me.tabMacManAlarmHistory.Controls.Add(Me.btnAlarmHistoryUpdates)
        Me.tabMacManAlarmHistory.Controls.Add(Me.txtAlarmObject)
        Me.tabMacManAlarmHistory.Controls.Add(Me.Label135)
        Me.tabMacManAlarmHistory.Controls.Add(Me.btnAlarmHistoryUpdate)
        Me.tabMacManAlarmHistory.Controls.Add(Me.txtAlarmIndex)
        Me.tabMacManAlarmHistory.Controls.Add(Me.Label107)
        Me.tabMacManAlarmHistory.Controls.Add(Me.txtMaxAlarmCount)
        Me.tabMacManAlarmHistory.Controls.Add(Me.Label98)
        Me.tabMacManAlarmHistory.Controls.Add(Me.txtAlarmCount)
        Me.tabMacManAlarmHistory.Controls.Add(Me.Label101)
        Me.tabMacManAlarmHistory.Controls.Add(Me.txtAlarmTime)
        Me.tabMacManAlarmHistory.Controls.Add(Me.Label102)
        Me.tabMacManAlarmHistory.Controls.Add(Me.txtAlarmNumber)
        Me.tabMacManAlarmHistory.Controls.Add(Me.Label103)
        Me.tabMacManAlarmHistory.Controls.Add(Me.txtAlarmMessage)
        Me.tabMacManAlarmHistory.Controls.Add(Me.Label104)
        Me.tabMacManAlarmHistory.Controls.Add(Me.txtAlarmDate)
        Me.tabMacManAlarmHistory.Controls.Add(Me.Label105)
        Me.tabMacManAlarmHistory.Controls.Add(Me.txtAlarmCode)
        Me.tabMacManAlarmHistory.Controls.Add(Me.Label106)
        Me.tabMacManAlarmHistory.Location = New System.Drawing.Point(4, 25)
        Me.tabMacManAlarmHistory.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tabMacManAlarmHistory.Name = "tabMacManAlarmHistory"
        Me.tabMacManAlarmHistory.Size = New System.Drawing.Size(1012, 555)
        Me.tabMacManAlarmHistory.TabIndex = 13
        Me.tabMacManAlarmHistory.Text = "MacMan - Alarm History"
        Me.tabMacManAlarmHistory.UseVisualStyleBackColor = True
        '
        'lstAlarms
        '
        Me.lstAlarms.FormattingEnabled = True
        Me.lstAlarms.ItemHeight = 16
        Me.lstAlarms.Location = New System.Drawing.Point(420, 54)
        Me.lstAlarms.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lstAlarms.Name = "lstAlarms"
        Me.lstAlarms.Size = New System.Drawing.Size(576, 484)
        Me.lstAlarms.TabIndex = 241
        '
        'txtAlarmHistoryEndIndex
        '
        Me.txtAlarmHistoryEndIndex.Location = New System.Drawing.Point(667, 18)
        Me.txtAlarmHistoryEndIndex.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAlarmHistoryEndIndex.Name = "txtAlarmHistoryEndIndex"
        Me.txtAlarmHistoryEndIndex.Size = New System.Drawing.Size(77, 22)
        Me.txtAlarmHistoryEndIndex.TabIndex = 240
        Me.txtAlarmHistoryEndIndex.Text = "2"
        '
        'Label137
        '
        Me.Label137.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label137.Location = New System.Drawing.Point(599, 18)
        Me.Label137.Name = "Label137"
        Me.Label137.Size = New System.Drawing.Size(59, 18)
        Me.Label137.TabIndex = 239
        Me.Label137.Text = "To"
        '
        'txtAlarmHistoryFromIndex
        '
        Me.txtAlarmHistoryFromIndex.Location = New System.Drawing.Point(484, 18)
        Me.txtAlarmHistoryFromIndex.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAlarmHistoryFromIndex.Name = "txtAlarmHistoryFromIndex"
        Me.txtAlarmHistoryFromIndex.Size = New System.Drawing.Size(77, 22)
        Me.txtAlarmHistoryFromIndex.TabIndex = 238
        Me.txtAlarmHistoryFromIndex.Text = "1"
        '
        'Label138
        '
        Me.Label138.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label138.Location = New System.Drawing.Point(417, 18)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(57, 18)
        Me.Label138.TabIndex = 237
        Me.Label138.Text = "From"
        '
        'btnAlarmHistoryUpdates
        '
        Me.btnAlarmHistoryUpdates.Location = New System.Drawing.Point(909, 14)
        Me.btnAlarmHistoryUpdates.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAlarmHistoryUpdates.Name = "btnAlarmHistoryUpdates"
        Me.btnAlarmHistoryUpdates.Size = New System.Drawing.Size(85, 27)
        Me.btnAlarmHistoryUpdates.TabIndex = 235
        Me.btnAlarmHistoryUpdates.Text = "Update"
        '
        'txtAlarmObject
        '
        Me.txtAlarmObject.Location = New System.Drawing.Point(184, 249)
        Me.txtAlarmObject.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAlarmObject.Name = "txtAlarmObject"
        Me.txtAlarmObject.Size = New System.Drawing.Size(172, 22)
        Me.txtAlarmObject.TabIndex = 234
        '
        'Label135
        '
        Me.Label135.Location = New System.Drawing.Point(11, 249)
        Me.Label135.Name = "Label135"
        Me.Label135.Size = New System.Drawing.Size(125, 18)
        Me.Label135.TabIndex = 233
        Me.Label135.Text = "Alarm Object :"
        '
        'btnAlarmHistoryUpdate
        '
        Me.btnAlarmHistoryUpdate.Location = New System.Drawing.Point(269, 14)
        Me.btnAlarmHistoryUpdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAlarmHistoryUpdate.Name = "btnAlarmHistoryUpdate"
        Me.btnAlarmHistoryUpdate.Size = New System.Drawing.Size(85, 28)
        Me.btnAlarmHistoryUpdate.TabIndex = 229
        Me.btnAlarmHistoryUpdate.Text = "Update"
        '
        'txtAlarmIndex
        '
        Me.txtAlarmIndex.Location = New System.Drawing.Point(184, 14)
        Me.txtAlarmIndex.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAlarmIndex.Name = "txtAlarmIndex"
        Me.txtAlarmIndex.Size = New System.Drawing.Size(76, 22)
        Me.txtAlarmIndex.TabIndex = 228
        Me.txtAlarmIndex.Text = "1"
        '
        'Label107
        '
        Me.Label107.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label107.Location = New System.Drawing.Point(11, 14)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(163, 18)
        Me.Label107.TabIndex = 227
        Me.Label107.Text = "Alarm Index :"
        '
        'txtMaxAlarmCount
        '
        Me.txtMaxAlarmCount.Location = New System.Drawing.Point(184, 220)
        Me.txtMaxAlarmCount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMaxAlarmCount.Name = "txtMaxAlarmCount"
        Me.txtMaxAlarmCount.Size = New System.Drawing.Size(172, 22)
        Me.txtMaxAlarmCount.TabIndex = 226
        '
        'Label98
        '
        Me.Label98.Location = New System.Drawing.Point(11, 220)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(125, 18)
        Me.Label98.TabIndex = 225
        Me.Label98.Text = "Max Alarm Count :"
        '
        'txtAlarmCount
        '
        Me.txtAlarmCount.Location = New System.Drawing.Point(184, 192)
        Me.txtAlarmCount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAlarmCount.Name = "txtAlarmCount"
        Me.txtAlarmCount.Size = New System.Drawing.Size(172, 22)
        Me.txtAlarmCount.TabIndex = 224
        '
        'Label101
        '
        Me.Label101.Location = New System.Drawing.Point(11, 192)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(125, 18)
        Me.Label101.TabIndex = 223
        Me.Label101.Text = "Alarm Count :"
        '
        'txtAlarmTime
        '
        Me.txtAlarmTime.Location = New System.Drawing.Point(184, 165)
        Me.txtAlarmTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAlarmTime.Name = "txtAlarmTime"
        Me.txtAlarmTime.Size = New System.Drawing.Size(172, 22)
        Me.txtAlarmTime.TabIndex = 222
        '
        'Label102
        '
        Me.Label102.Location = New System.Drawing.Point(11, 165)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(125, 18)
        Me.Label102.TabIndex = 221
        Me.Label102.Text = "Alarm Time :"
        '
        'txtAlarmNumber
        '
        Me.txtAlarmNumber.Location = New System.Drawing.Point(184, 137)
        Me.txtAlarmNumber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAlarmNumber.Name = "txtAlarmNumber"
        Me.txtAlarmNumber.Size = New System.Drawing.Size(172, 22)
        Me.txtAlarmNumber.TabIndex = 220
        '
        'Label103
        '
        Me.Label103.Location = New System.Drawing.Point(11, 137)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(125, 18)
        Me.Label103.TabIndex = 219
        Me.Label103.Text = "Alarm Number :"
        '
        'txtAlarmMessage
        '
        Me.txtAlarmMessage.Location = New System.Drawing.Point(184, 110)
        Me.txtAlarmMessage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAlarmMessage.Name = "txtAlarmMessage"
        Me.txtAlarmMessage.Size = New System.Drawing.Size(172, 22)
        Me.txtAlarmMessage.TabIndex = 218
        '
        'Label104
        '
        Me.Label104.Location = New System.Drawing.Point(11, 110)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(125, 18)
        Me.Label104.TabIndex = 217
        Me.Label104.Text = "Alarm Message :"
        '
        'txtAlarmDate
        '
        Me.txtAlarmDate.Location = New System.Drawing.Point(184, 81)
        Me.txtAlarmDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAlarmDate.Name = "txtAlarmDate"
        Me.txtAlarmDate.Size = New System.Drawing.Size(172, 22)
        Me.txtAlarmDate.TabIndex = 216
        '
        'Label105
        '
        Me.Label105.Location = New System.Drawing.Point(11, 81)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(125, 18)
        Me.Label105.TabIndex = 215
        Me.Label105.Text = "Alarm Date :"
        '
        'txtAlarmCode
        '
        Me.txtAlarmCode.Location = New System.Drawing.Point(184, 54)
        Me.txtAlarmCode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAlarmCode.Name = "txtAlarmCode"
        Me.txtAlarmCode.Size = New System.Drawing.Size(172, 22)
        Me.txtAlarmCode.TabIndex = 214
        '
        'Label106
        '
        Me.Label106.Location = New System.Drawing.Point(11, 54)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(125, 18)
        Me.Label106.TabIndex = 213
        Me.Label106.Text = "Alarm Code :"
        '
        'tabMacManMachiningReport
        '
        Me.tabMacManMachiningReport.Controls.Add(Me.grdMachiningReports)
        Me.tabMacManMachiningReport.Controls.Add(Me.txtMachiningReportNoOfWork)
        Me.tabMacManMachiningReport.Controls.Add(Me.Label144)
        Me.tabMacManMachiningReport.Controls.Add(Me.txtMachiningReportStartTime)
        Me.tabMacManMachiningReport.Controls.Add(Me.Label245)
        Me.tabMacManMachiningReport.Controls.Add(Me.txtMachiningReportToIndex)
        Me.tabMacManMachiningReport.Controls.Add(Me.Label221)
        Me.tabMacManMachiningReport.Controls.Add(Me.txtMachiningReportFromIndex)
        Me.tabMacManMachiningReport.Controls.Add(Me.Label222)
        Me.tabMacManMachiningReport.Controls.Add(Me.btnMacManMachiningReportUpdates)
        Me.tabMacManMachiningReport.Controls.Add(Me.Label216)
        Me.tabMacManMachiningReport.Controls.Add(Me.cboMachiningReportType)
        Me.tabMacManMachiningReport.Controls.Add(Me.txtMachiningReportProgramName)
        Me.tabMacManMachiningReport.Controls.Add(Me.Label217)
        Me.tabMacManMachiningReport.Controls.Add(Me.txtMachiningReportMainProgram)
        Me.tabMacManMachiningReport.Controls.Add(Me.Label218)
        Me.tabMacManMachiningReport.Controls.Add(Me.txtMachiningReportCount)
        Me.tabMacManMachiningReport.Controls.Add(Me.Label219)
        Me.tabMacManMachiningReport.Controls.Add(Me.btnMacManMachiningReportUpdate)
        Me.tabMacManMachiningReport.Controls.Add(Me.txtMacManReportIndex)
        Me.tabMacManMachiningReport.Controls.Add(Me.Label220)
        Me.tabMacManMachiningReport.Controls.Add(Me.txtMachiningReportOperatingTime)
        Me.tabMacManMachiningReport.Controls.Add(Me.Label225)
        Me.tabMacManMachiningReport.Controls.Add(Me.txtMachiningReportRunningTime)
        Me.tabMacManMachiningReport.Controls.Add(Me.Label226)
        Me.tabMacManMachiningReport.Controls.Add(Me.txtMachiningReportStartDate)
        Me.tabMacManMachiningReport.Controls.Add(Me.Label227)
        Me.tabMacManMachiningReport.Controls.Add(Me.txtMachiningReportMaxCount)
        Me.tabMacManMachiningReport.Controls.Add(Me.Label228)
        Me.tabMacManMachiningReport.Controls.Add(Me.txtMachiningReportCuttingTime)
        Me.tabMacManMachiningReport.Controls.Add(Me.Label229)
        Me.tabMacManMachiningReport.Location = New System.Drawing.Point(4, 25)
        Me.tabMacManMachiningReport.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabMacManMachiningReport.Name = "tabMacManMachiningReport"
        Me.tabMacManMachiningReport.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tabMacManMachiningReport.Size = New System.Drawing.Size(1012, 555)
        Me.tabMacManMachiningReport.TabIndex = 1
        Me.tabMacManMachiningReport.Text = "MacMan - Machining Report"
        Me.tabMacManMachiningReport.UseVisualStyleBackColor = True
        '
        'grdMachiningReports
        '
        Me.grdMachiningReports.DataMember = ""
        Me.grdMachiningReports.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdMachiningReports.Location = New System.Drawing.Point(3, 165)
        Me.grdMachiningReports.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grdMachiningReports.Name = "grdMachiningReports"
        Me.grdMachiningReports.PreferredColumnWidth = 80
        Me.grdMachiningReports.ReadOnly = True
        Me.grdMachiningReports.Size = New System.Drawing.Size(901, 374)
        Me.grdMachiningReports.TabIndex = 335
        '
        'txtMachiningReportNoOfWork
        '
        Me.txtMachiningReportNoOfWork.Location = New System.Drawing.Point(480, 90)
        Me.txtMachiningReportNoOfWork.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMachiningReportNoOfWork.Name = "txtMachiningReportNoOfWork"
        Me.txtMachiningReportNoOfWork.ReadOnly = True
        Me.txtMachiningReportNoOfWork.Size = New System.Drawing.Size(105, 22)
        Me.txtMachiningReportNoOfWork.TabIndex = 333
        '
        'Label144
        '
        Me.Label144.Location = New System.Drawing.Point(480, 53)
        Me.Label144.Name = "Label144"
        Me.Label144.Size = New System.Drawing.Size(107, 18)
        Me.Label144.TabIndex = 332
        Me.Label144.Text = "No. Of Work"
        '
        'txtMachiningReportStartTime
        '
        Me.txtMachiningReportStartTime.Location = New System.Drawing.Point(365, 90)
        Me.txtMachiningReportStartTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMachiningReportStartTime.Name = "txtMachiningReportStartTime"
        Me.txtMachiningReportStartTime.ReadOnly = True
        Me.txtMachiningReportStartTime.Size = New System.Drawing.Size(105, 22)
        Me.txtMachiningReportStartTime.TabIndex = 328
        '
        'Label245
        '
        Me.Label245.Location = New System.Drawing.Point(356, 53)
        Me.Label245.Name = "Label245"
        Me.Label245.Size = New System.Drawing.Size(105, 18)
        Me.Label245.TabIndex = 327
        Me.Label245.Text = "Start Time:"
        '
        'txtMachiningReportToIndex
        '
        Me.txtMachiningReportToIndex.Location = New System.Drawing.Point(459, 130)
        Me.txtMachiningReportToIndex.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMachiningReportToIndex.Name = "txtMachiningReportToIndex"
        Me.txtMachiningReportToIndex.Size = New System.Drawing.Size(77, 22)
        Me.txtMachiningReportToIndex.TabIndex = 326
        Me.txtMachiningReportToIndex.Text = "2"
        '
        'Label221
        '
        Me.Label221.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label221.Location = New System.Drawing.Point(391, 130)
        Me.Label221.Name = "Label221"
        Me.Label221.Size = New System.Drawing.Size(57, 18)
        Me.Label221.TabIndex = 325
        Me.Label221.Text = "To"
        '
        'txtMachiningReportFromIndex
        '
        Me.txtMachiningReportFromIndex.Location = New System.Drawing.Point(275, 130)
        Me.txtMachiningReportFromIndex.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMachiningReportFromIndex.Name = "txtMachiningReportFromIndex"
        Me.txtMachiningReportFromIndex.Size = New System.Drawing.Size(77, 22)
        Me.txtMachiningReportFromIndex.TabIndex = 324
        Me.txtMachiningReportFromIndex.Text = "1"
        '
        'Label222
        '
        Me.Label222.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label222.Location = New System.Drawing.Point(208, 130)
        Me.Label222.Name = "Label222"
        Me.Label222.Size = New System.Drawing.Size(59, 18)
        Me.Label222.TabIndex = 323
        Me.Label222.Text = "From"
        '
        'btnMacManMachiningReportUpdates
        '
        Me.btnMacManMachiningReportUpdates.Location = New System.Drawing.Point(7, 130)
        Me.btnMacManMachiningReportUpdates.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMacManMachiningReportUpdates.Name = "btnMacManMachiningReportUpdates"
        Me.btnMacManMachiningReportUpdates.Size = New System.Drawing.Size(85, 28)
        Me.btnMacManMachiningReportUpdates.TabIndex = 322
        Me.btnMacManMachiningReportUpdates.Text = "Update"
        '
        'Label216
        '
        Me.Label216.Location = New System.Drawing.Point(291, 7)
        Me.Label216.Name = "Label216"
        Me.Label216.Size = New System.Drawing.Size(85, 18)
        Me.Label216.TabIndex = 321
        Me.Label216.Text = "Period Time"
        '
        'cboMachiningReportType
        '
        Me.cboMachiningReportType.Location = New System.Drawing.Point(387, 7)
        Me.cboMachiningReportType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboMachiningReportType.Name = "cboMachiningReportType"
        Me.cboMachiningReportType.Size = New System.Drawing.Size(124, 24)
        Me.cboMachiningReportType.TabIndex = 320
        '
        'txtMachiningReportProgramName
        '
        Me.txtMachiningReportProgramName.Location = New System.Drawing.Point(135, 90)
        Me.txtMachiningReportProgramName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMachiningReportProgramName.Name = "txtMachiningReportProgramName"
        Me.txtMachiningReportProgramName.ReadOnly = True
        Me.txtMachiningReportProgramName.Size = New System.Drawing.Size(105, 22)
        Me.txtMachiningReportProgramName.TabIndex = 319
        '
        'Label217
        '
        Me.Label217.Location = New System.Drawing.Point(135, 53)
        Me.Label217.Name = "Label217"
        Me.Label217.Size = New System.Drawing.Size(105, 27)
        Me.Label217.TabIndex = 318
        Me.Label217.Text = "Main program name"
        '
        'txtMachiningReportMainProgram
        '
        Me.txtMachiningReportMainProgram.Location = New System.Drawing.Point(3, 90)
        Me.txtMachiningReportMainProgram.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMachiningReportMainProgram.Name = "txtMachiningReportMainProgram"
        Me.txtMachiningReportMainProgram.ReadOnly = True
        Me.txtMachiningReportMainProgram.Size = New System.Drawing.Size(105, 22)
        Me.txtMachiningReportMainProgram.TabIndex = 317
        '
        'Label218
        '
        Me.Label218.Location = New System.Drawing.Point(3, 53)
        Me.Label218.Name = "Label218"
        Me.Label218.Size = New System.Drawing.Size(127, 37)
        Me.Label218.TabIndex = 316
        Me.Label218.Text = "Main program file name"
        '
        'txtMachiningReportCount
        '
        Me.txtMachiningReportCount.Location = New System.Drawing.Point(789, 7)
        Me.txtMachiningReportCount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMachiningReportCount.Name = "txtMachiningReportCount"
        Me.txtMachiningReportCount.ReadOnly = True
        Me.txtMachiningReportCount.Size = New System.Drawing.Size(77, 22)
        Me.txtMachiningReportCount.TabIndex = 315
        '
        'Label219
        '
        Me.Label219.Location = New System.Drawing.Point(723, 7)
        Me.Label219.Name = "Label219"
        Me.Label219.Size = New System.Drawing.Size(57, 18)
        Me.Label219.TabIndex = 314
        Me.Label219.Text = "Count"
        '
        'btnMacManMachiningReportUpdate
        '
        Me.btnMacManMachiningReportUpdate.Location = New System.Drawing.Point(3, 7)
        Me.btnMacManMachiningReportUpdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMacManMachiningReportUpdate.Name = "btnMacManMachiningReportUpdate"
        Me.btnMacManMachiningReportUpdate.Size = New System.Drawing.Size(85, 27)
        Me.btnMacManMachiningReportUpdate.TabIndex = 313
        Me.btnMacManMachiningReportUpdate.Text = "Update"
        '
        'txtMacManReportIndex
        '
        Me.txtMacManReportIndex.Location = New System.Drawing.Point(204, 7)
        Me.txtMacManReportIndex.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManReportIndex.Name = "txtMacManReportIndex"
        Me.txtMacManReportIndex.Size = New System.Drawing.Size(77, 22)
        Me.txtMacManReportIndex.TabIndex = 312
        Me.txtMacManReportIndex.Text = "1"
        '
        'Label220
        '
        Me.Label220.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label220.Location = New System.Drawing.Point(108, 7)
        Me.Label220.Name = "Label220"
        Me.Label220.Size = New System.Drawing.Size(77, 18)
        Me.Label220.TabIndex = 311
        Me.Label220.Text = "Index :"
        '
        'txtMachiningReportOperatingTime
        '
        Me.txtMachiningReportOperatingTime.Location = New System.Drawing.Point(701, 90)
        Me.txtMachiningReportOperatingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMachiningReportOperatingTime.Name = "txtMachiningReportOperatingTime"
        Me.txtMachiningReportOperatingTime.ReadOnly = True
        Me.txtMachiningReportOperatingTime.Size = New System.Drawing.Size(105, 22)
        Me.txtMachiningReportOperatingTime.TabIndex = 310
        '
        'Label225
        '
        Me.Label225.Location = New System.Drawing.Point(701, 53)
        Me.Label225.Name = "Label225"
        Me.Label225.Size = New System.Drawing.Size(107, 37)
        Me.Label225.TabIndex = 309
        Me.Label225.Text = "Operating Time (ms)"
        '
        'txtMachiningReportRunningTime
        '
        Me.txtMachiningReportRunningTime.Location = New System.Drawing.Point(596, 90)
        Me.txtMachiningReportRunningTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMachiningReportRunningTime.Name = "txtMachiningReportRunningTime"
        Me.txtMachiningReportRunningTime.ReadOnly = True
        Me.txtMachiningReportRunningTime.Size = New System.Drawing.Size(96, 22)
        Me.txtMachiningReportRunningTime.TabIndex = 308
        '
        'Label226
        '
        Me.Label226.Location = New System.Drawing.Point(596, 53)
        Me.Label226.Name = "Label226"
        Me.Label226.Size = New System.Drawing.Size(105, 37)
        Me.Label226.TabIndex = 307
        Me.Label226.Text = "Running Time (ms)"
        '
        'txtMachiningReportStartDate
        '
        Me.txtMachiningReportStartDate.Location = New System.Drawing.Point(251, 90)
        Me.txtMachiningReportStartDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMachiningReportStartDate.Name = "txtMachiningReportStartDate"
        Me.txtMachiningReportStartDate.ReadOnly = True
        Me.txtMachiningReportStartDate.Size = New System.Drawing.Size(105, 22)
        Me.txtMachiningReportStartDate.TabIndex = 306
        '
        'Label227
        '
        Me.Label227.Location = New System.Drawing.Point(251, 53)
        Me.Label227.Name = "Label227"
        Me.Label227.Size = New System.Drawing.Size(96, 18)
        Me.Label227.TabIndex = 305
        Me.Label227.Text = "Start Date:"
        '
        'txtMachiningReportMaxCount
        '
        Me.txtMachiningReportMaxCount.Location = New System.Drawing.Point(627, 7)
        Me.txtMachiningReportMaxCount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMachiningReportMaxCount.Name = "txtMachiningReportMaxCount"
        Me.txtMachiningReportMaxCount.ReadOnly = True
        Me.txtMachiningReportMaxCount.Size = New System.Drawing.Size(76, 22)
        Me.txtMachiningReportMaxCount.TabIndex = 304
        '
        'Label228
        '
        Me.Label228.Location = New System.Drawing.Point(521, 7)
        Me.Label228.Name = "Label228"
        Me.Label228.Size = New System.Drawing.Size(85, 18)
        Me.Label228.TabIndex = 303
        Me.Label228.Text = "Max Count :"
        '
        'txtMachiningReportCuttingTime
        '
        Me.txtMachiningReportCuttingTime.Location = New System.Drawing.Point(816, 90)
        Me.txtMachiningReportCuttingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMachiningReportCuttingTime.Name = "txtMachiningReportCuttingTime"
        Me.txtMachiningReportCuttingTime.ReadOnly = True
        Me.txtMachiningReportCuttingTime.Size = New System.Drawing.Size(105, 22)
        Me.txtMachiningReportCuttingTime.TabIndex = 302
        '
        'Label229
        '
        Me.Label229.Location = New System.Drawing.Point(816, 53)
        Me.Label229.Name = "Label229"
        Me.Label229.Size = New System.Drawing.Size(107, 37)
        Me.Label229.TabIndex = 301
        Me.Label229.Text = "Cutting Time (ms)"
        '
        'tabMacManOperatingHistory
        '
        Me.tabMacManOperatingHistory.Controls.Add(Me.Label191)
        Me.tabMacManOperatingHistory.Controls.Add(Me.txtMacManOperatingHistoryMaxCount)
        Me.tabMacManOperatingHistory.Controls.Add(Me.btnMacManOperatingHistoryUpdate)
        Me.tabMacManOperatingHistory.Controls.Add(Me.Label212)
        Me.tabMacManOperatingHistory.Controls.Add(Me.Label213)
        Me.tabMacManOperatingHistory.Controls.Add(Me.txtMacManOperatingHistoryToIndex)
        Me.tabMacManOperatingHistory.Controls.Add(Me.txtMacManOperatingHistoryFromIndex)
        Me.tabMacManOperatingHistory.Controls.Add(Me.GroupBox31)
        Me.tabMacManOperatingHistory.Controls.Add(Me.GroupBox32)
        Me.tabMacManOperatingHistory.Location = New System.Drawing.Point(4, 25)
        Me.tabMacManOperatingHistory.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tabMacManOperatingHistory.Name = "tabMacManOperatingHistory"
        Me.tabMacManOperatingHistory.Size = New System.Drawing.Size(1012, 555)
        Me.tabMacManOperatingHistory.TabIndex = 15
        Me.tabMacManOperatingHistory.Text = "MacMan - Operating History"
        Me.tabMacManOperatingHistory.UseVisualStyleBackColor = True
        '
        'Label191
        '
        Me.Label191.Location = New System.Drawing.Point(589, 2)
        Me.Label191.Name = "Label191"
        Me.Label191.Size = New System.Drawing.Size(201, 28)
        Me.Label191.TabIndex = 276
        Me.Label191.Text = "Maximum no of operating history"
        '
        'txtMacManOperatingHistoryMaxCount
        '
        Me.txtMacManOperatingHistoryMaxCount.Location = New System.Drawing.Point(811, 2)
        Me.txtMacManOperatingHistoryMaxCount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryMaxCount.Name = "txtMacManOperatingHistoryMaxCount"
        Me.txtMacManOperatingHistoryMaxCount.Size = New System.Drawing.Size(87, 22)
        Me.txtMacManOperatingHistoryMaxCount.TabIndex = 275
        Me.txtMacManOperatingHistoryMaxCount.Text = "0"
        '
        'btnMacManOperatingHistoryUpdate
        '
        Me.btnMacManOperatingHistoryUpdate.Location = New System.Drawing.Point(417, 2)
        Me.btnMacManOperatingHistoryUpdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnMacManOperatingHistoryUpdate.Name = "btnMacManOperatingHistoryUpdate"
        Me.btnMacManOperatingHistoryUpdate.Size = New System.Drawing.Size(91, 27)
        Me.btnMacManOperatingHistoryUpdate.TabIndex = 274
        Me.btnMacManOperatingHistoryUpdate.Text = "Update"
        '
        'Label212
        '
        Me.Label212.Location = New System.Drawing.Point(231, 2)
        Me.Label212.Name = "Label212"
        Me.Label212.Size = New System.Drawing.Size(37, 27)
        Me.Label212.TabIndex = 273
        Me.Label212.Text = "To"
        '
        'Label213
        '
        Me.Label213.Location = New System.Drawing.Point(4, 2)
        Me.Label213.Name = "Label213"
        Me.Label213.Size = New System.Drawing.Size(63, 27)
        Me.Label213.TabIndex = 272
        Me.Label213.Text = "From"
        '
        'txtMacManOperatingHistoryToIndex
        '
        Me.txtMacManOperatingHistoryToIndex.Location = New System.Drawing.Point(269, 2)
        Me.txtMacManOperatingHistoryToIndex.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryToIndex.Name = "txtMacManOperatingHistoryToIndex"
        Me.txtMacManOperatingHistoryToIndex.Size = New System.Drawing.Size(120, 22)
        Me.txtMacManOperatingHistoryToIndex.TabIndex = 271
        Me.txtMacManOperatingHistoryToIndex.Text = "2"
        '
        'txtMacManOperatingHistoryFromIndex
        '
        Me.txtMacManOperatingHistoryFromIndex.Location = New System.Drawing.Point(87, 2)
        Me.txtMacManOperatingHistoryFromIndex.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryFromIndex.Name = "txtMacManOperatingHistoryFromIndex"
        Me.txtMacManOperatingHistoryFromIndex.Size = New System.Drawing.Size(120, 22)
        Me.txtMacManOperatingHistoryFromIndex.TabIndex = 270
        Me.txtMacManOperatingHistoryFromIndex.Text = "1"
        '
        'GroupBox31
        '
        Me.GroupBox31.Controls.Add(Me.txtMacManOperatingHistoryPrevAlarmonTime)
        Me.GroupBox31.Controls.Add(Me.txtMacManOperatingHistoryPrevExternalInputTime)
        Me.GroupBox31.Controls.Add(Me.txtMacManOperatingHistoryPrevSpindleRunTime)
        Me.GroupBox31.Controls.Add(Me.txtMacManOperatingHistoryPrevOtherTime)
        Me.GroupBox31.Controls.Add(Me.txtMacManOperatingHistoryPrevMaintenanceTime)
        Me.GroupBox31.Controls.Add(Me.txtMacManOperatingHistoryPrevPartWaitingTime)
        Me.GroupBox31.Controls.Add(Me.txtMacManOperatingHistoryPrevNoOperatorTime)
        Me.GroupBox31.Controls.Add(Me.txtMacManOperatingHistoryPrevInProSetupTime)
        Me.GroupBox31.Controls.Add(Me.txtMacManOperatingHistoryPrevNonOperatingTime)
        Me.GroupBox31.Controls.Add(Me.txtMacManOperatingHistoryPrevCuttingTime)
        Me.GroupBox31.Controls.Add(Me.txtMacManOperatingHistoryPrevOperatingTime)
        Me.GroupBox31.Controls.Add(Me.Label223)
        Me.GroupBox31.Controls.Add(Me.Label247)
        Me.GroupBox31.Controls.Add(Me.Label250)
        Me.GroupBox31.Controls.Add(Me.Label251)
        Me.GroupBox31.Controls.Add(Me.Label255)
        Me.GroupBox31.Controls.Add(Me.Label257)
        Me.GroupBox31.Controls.Add(Me.Label258)
        Me.GroupBox31.Controls.Add(Me.Label259)
        Me.GroupBox31.Controls.Add(Me.Label260)
        Me.GroupBox31.Controls.Add(Me.Label261)
        Me.GroupBox31.Controls.Add(Me.Label262)
        Me.GroupBox31.Controls.Add(Me.Label263)
        Me.GroupBox31.Controls.Add(Me.txtMacManOperatingHistoryPrevRunningTime)
        Me.GroupBox31.Location = New System.Drawing.Point(531, 39)
        Me.GroupBox31.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox31.Name = "GroupBox31"
        Me.GroupBox31.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox31.Size = New System.Drawing.Size(475, 379)
        Me.GroupBox31.TabIndex = 269
        Me.GroupBox31.TabStop = False
        Me.GroupBox31.Text = "Previousday Operating History"
        '
        'txtMacManOperatingHistoryPrevAlarmonTime
        '
        Me.txtMacManOperatingHistoryPrevAlarmonTime.Location = New System.Drawing.Point(144, 332)
        Me.txtMacManOperatingHistoryPrevAlarmonTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryPrevAlarmonTime.Name = "txtMacManOperatingHistoryPrevAlarmonTime"
        Me.txtMacManOperatingHistoryPrevAlarmonTime.Size = New System.Drawing.Size(324, 22)
        Me.txtMacManOperatingHistoryPrevAlarmonTime.TabIndex = 45
        Me.txtMacManOperatingHistoryPrevAlarmonTime.Text = "0"
        '
        'txtMacManOperatingHistoryPrevExternalInputTime
        '
        Me.txtMacManOperatingHistoryPrevExternalInputTime.Location = New System.Drawing.Point(144, 305)
        Me.txtMacManOperatingHistoryPrevExternalInputTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryPrevExternalInputTime.Name = "txtMacManOperatingHistoryPrevExternalInputTime"
        Me.txtMacManOperatingHistoryPrevExternalInputTime.Size = New System.Drawing.Size(324, 22)
        Me.txtMacManOperatingHistoryPrevExternalInputTime.TabIndex = 44
        Me.txtMacManOperatingHistoryPrevExternalInputTime.Text = "0"
        '
        'txtMacManOperatingHistoryPrevSpindleRunTime
        '
        Me.txtMacManOperatingHistoryPrevSpindleRunTime.Location = New System.Drawing.Point(144, 277)
        Me.txtMacManOperatingHistoryPrevSpindleRunTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryPrevSpindleRunTime.Name = "txtMacManOperatingHistoryPrevSpindleRunTime"
        Me.txtMacManOperatingHistoryPrevSpindleRunTime.Size = New System.Drawing.Size(324, 22)
        Me.txtMacManOperatingHistoryPrevSpindleRunTime.TabIndex = 43
        Me.txtMacManOperatingHistoryPrevSpindleRunTime.Text = "0"
        '
        'txtMacManOperatingHistoryPrevOtherTime
        '
        Me.txtMacManOperatingHistoryPrevOtherTime.Location = New System.Drawing.Point(144, 249)
        Me.txtMacManOperatingHistoryPrevOtherTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryPrevOtherTime.Name = "txtMacManOperatingHistoryPrevOtherTime"
        Me.txtMacManOperatingHistoryPrevOtherTime.Size = New System.Drawing.Size(324, 22)
        Me.txtMacManOperatingHistoryPrevOtherTime.TabIndex = 42
        Me.txtMacManOperatingHistoryPrevOtherTime.Text = "0"
        '
        'txtMacManOperatingHistoryPrevMaintenanceTime
        '
        Me.txtMacManOperatingHistoryPrevMaintenanceTime.Location = New System.Drawing.Point(144, 222)
        Me.txtMacManOperatingHistoryPrevMaintenanceTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryPrevMaintenanceTime.Name = "txtMacManOperatingHistoryPrevMaintenanceTime"
        Me.txtMacManOperatingHistoryPrevMaintenanceTime.Size = New System.Drawing.Size(324, 22)
        Me.txtMacManOperatingHistoryPrevMaintenanceTime.TabIndex = 41
        Me.txtMacManOperatingHistoryPrevMaintenanceTime.Text = "0"
        '
        'txtMacManOperatingHistoryPrevPartWaitingTime
        '
        Me.txtMacManOperatingHistoryPrevPartWaitingTime.Location = New System.Drawing.Point(144, 194)
        Me.txtMacManOperatingHistoryPrevPartWaitingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryPrevPartWaitingTime.Name = "txtMacManOperatingHistoryPrevPartWaitingTime"
        Me.txtMacManOperatingHistoryPrevPartWaitingTime.Size = New System.Drawing.Size(324, 22)
        Me.txtMacManOperatingHistoryPrevPartWaitingTime.TabIndex = 40
        Me.txtMacManOperatingHistoryPrevPartWaitingTime.Text = "0"
        '
        'txtMacManOperatingHistoryPrevNoOperatorTime
        '
        Me.txtMacManOperatingHistoryPrevNoOperatorTime.Location = New System.Drawing.Point(144, 166)
        Me.txtMacManOperatingHistoryPrevNoOperatorTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryPrevNoOperatorTime.Name = "txtMacManOperatingHistoryPrevNoOperatorTime"
        Me.txtMacManOperatingHistoryPrevNoOperatorTime.Size = New System.Drawing.Size(324, 22)
        Me.txtMacManOperatingHistoryPrevNoOperatorTime.TabIndex = 39
        Me.txtMacManOperatingHistoryPrevNoOperatorTime.Text = "0"
        '
        'txtMacManOperatingHistoryPrevInProSetupTime
        '
        Me.txtMacManOperatingHistoryPrevInProSetupTime.Location = New System.Drawing.Point(144, 138)
        Me.txtMacManOperatingHistoryPrevInProSetupTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryPrevInProSetupTime.Name = "txtMacManOperatingHistoryPrevInProSetupTime"
        Me.txtMacManOperatingHistoryPrevInProSetupTime.Size = New System.Drawing.Size(324, 22)
        Me.txtMacManOperatingHistoryPrevInProSetupTime.TabIndex = 38
        Me.txtMacManOperatingHistoryPrevInProSetupTime.Text = "0"
        '
        'txtMacManOperatingHistoryPrevNonOperatingTime
        '
        Me.txtMacManOperatingHistoryPrevNonOperatingTime.Location = New System.Drawing.Point(144, 111)
        Me.txtMacManOperatingHistoryPrevNonOperatingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryPrevNonOperatingTime.Name = "txtMacManOperatingHistoryPrevNonOperatingTime"
        Me.txtMacManOperatingHistoryPrevNonOperatingTime.Size = New System.Drawing.Size(324, 22)
        Me.txtMacManOperatingHistoryPrevNonOperatingTime.TabIndex = 37
        Me.txtMacManOperatingHistoryPrevNonOperatingTime.Text = "0"
        '
        'txtMacManOperatingHistoryPrevCuttingTime
        '
        Me.txtMacManOperatingHistoryPrevCuttingTime.Location = New System.Drawing.Point(144, 82)
        Me.txtMacManOperatingHistoryPrevCuttingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryPrevCuttingTime.Name = "txtMacManOperatingHistoryPrevCuttingTime"
        Me.txtMacManOperatingHistoryPrevCuttingTime.Size = New System.Drawing.Size(324, 22)
        Me.txtMacManOperatingHistoryPrevCuttingTime.TabIndex = 36
        Me.txtMacManOperatingHistoryPrevCuttingTime.Text = "0"
        '
        'txtMacManOperatingHistoryPrevOperatingTime
        '
        Me.txtMacManOperatingHistoryPrevOperatingTime.Location = New System.Drawing.Point(144, 55)
        Me.txtMacManOperatingHistoryPrevOperatingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryPrevOperatingTime.Name = "txtMacManOperatingHistoryPrevOperatingTime"
        Me.txtMacManOperatingHistoryPrevOperatingTime.Size = New System.Drawing.Size(324, 22)
        Me.txtMacManOperatingHistoryPrevOperatingTime.TabIndex = 35
        Me.txtMacManOperatingHistoryPrevOperatingTime.Text = "0"
        '
        'Label223
        '
        Me.Label223.Location = New System.Drawing.Point(37, 332)
        Me.Label223.Name = "Label223"
        Me.Label223.Size = New System.Drawing.Size(135, 27)
        Me.Label223.TabIndex = 34
        Me.Label223.Text = "Alarm on Time"
        '
        'Label247
        '
        Me.Label247.Location = New System.Drawing.Point(19, 305)
        Me.Label247.Name = "Label247"
        Me.Label247.Size = New System.Drawing.Size(135, 26)
        Me.Label247.TabIndex = 33
        Me.Label247.Text = "External input Time"
        '
        'Label250
        '
        Me.Label250.Location = New System.Drawing.Point(37, 249)
        Me.Label250.Name = "Label250"
        Me.Label250.Size = New System.Drawing.Size(120, 27)
        Me.Label250.TabIndex = 32
        Me.Label250.Text = "Other Time"
        '
        'Label251
        '
        Me.Label251.Location = New System.Drawing.Point(19, 222)
        Me.Label251.Name = "Label251"
        Me.Label251.Size = New System.Drawing.Size(120, 26)
        Me.Label251.TabIndex = 31
        Me.Label251.Text = "Maintenance Time"
        '
        'Label255
        '
        Me.Label255.Location = New System.Drawing.Point(19, 194)
        Me.Label255.Name = "Label255"
        Me.Label255.Size = New System.Drawing.Size(120, 26)
        Me.Label255.TabIndex = 30
        Me.Label255.Text = "Part waiting time"
        '
        'Label257
        '
        Me.Label257.Location = New System.Drawing.Point(19, 166)
        Me.Label257.Name = "Label257"
        Me.Label257.Size = New System.Drawing.Size(120, 27)
        Me.Label257.TabIndex = 29
        Me.Label257.Text = "No Operator Time"
        '
        'Label258
        '
        Me.Label258.Location = New System.Drawing.Point(19, 138)
        Me.Label258.Name = "Label258"
        Me.Label258.Size = New System.Drawing.Size(120, 27)
        Me.Label258.TabIndex = 28
        Me.Label258.Text = "In-Pro set up Time"
        '
        'Label259
        '
        Me.Label259.Location = New System.Drawing.Point(19, 111)
        Me.Label259.Name = "Label259"
        Me.Label259.Size = New System.Drawing.Size(125, 26)
        Me.Label259.TabIndex = 27
        Me.Label259.Text = "Non operating Time"
        '
        'Label260
        '
        Me.Label260.Location = New System.Drawing.Point(19, 82)
        Me.Label260.Name = "Label260"
        Me.Label260.Size = New System.Drawing.Size(120, 27)
        Me.Label260.TabIndex = 26
        Me.Label260.Text = "Cutting TIme"
        '
        'Label261
        '
        Me.Label261.Location = New System.Drawing.Point(19, 55)
        Me.Label261.Name = "Label261"
        Me.Label261.Size = New System.Drawing.Size(120, 27)
        Me.Label261.TabIndex = 25
        Me.Label261.Text = "Operating Time"
        '
        'Label262
        '
        Me.Label262.Location = New System.Drawing.Point(19, 28)
        Me.Label262.Name = "Label262"
        Me.Label262.Size = New System.Drawing.Size(96, 26)
        Me.Label262.TabIndex = 24
        Me.Label262.Text = "Running Time"
        '
        'Label263
        '
        Me.Label263.Location = New System.Drawing.Point(19, 277)
        Me.Label263.Name = "Label263"
        Me.Label263.Size = New System.Drawing.Size(120, 26)
        Me.Label263.TabIndex = 24
        Me.Label263.Text = "Spindle run Time"
        '
        'txtMacManOperatingHistoryPrevRunningTime
        '
        Me.txtMacManOperatingHistoryPrevRunningTime.Location = New System.Drawing.Point(144, 28)
        Me.txtMacManOperatingHistoryPrevRunningTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryPrevRunningTime.Name = "txtMacManOperatingHistoryPrevRunningTime"
        Me.txtMacManOperatingHistoryPrevRunningTime.Size = New System.Drawing.Size(324, 22)
        Me.txtMacManOperatingHistoryPrevRunningTime.TabIndex = 24
        Me.txtMacManOperatingHistoryPrevRunningTime.Text = "0"
        '
        'GroupBox32
        '
        Me.GroupBox32.Controls.Add(Me.txtMacManOperatingHistoryAlarmOnTime)
        Me.GroupBox32.Controls.Add(Me.txtMacManOperatingHistoryExternalInputTime)
        Me.GroupBox32.Controls.Add(Me.txtMacManOperatingHistorySpindleRunTime)
        Me.GroupBox32.Controls.Add(Me.txtMacManOperatingHistoryOtherTime)
        Me.GroupBox32.Controls.Add(Me.txtMacManOperatingHistoryMaintenanceTime)
        Me.GroupBox32.Controls.Add(Me.txtMacManOperatingHistoryPartWaitingTime)
        Me.GroupBox32.Controls.Add(Me.txtMacManOperatingHistoryNoOperatorTime)
        Me.GroupBox32.Controls.Add(Me.txtMacManOperatingHistoryInProSetupTime)
        Me.GroupBox32.Controls.Add(Me.txtMacManOperatingHistoryNonOperatingReport)
        Me.GroupBox32.Controls.Add(Me.txtMacManOperatingHistoryCuttingTime)
        Me.GroupBox32.Controls.Add(Me.txtMacManOperatingHistoryOperatingTime)
        Me.GroupBox32.Controls.Add(Me.txtMacManOperatingHistoryRunningTime)
        Me.GroupBox32.Controls.Add(Me.Label200)
        Me.GroupBox32.Controls.Add(Me.Label201)
        Me.GroupBox32.Controls.Add(Me.Label202)
        Me.GroupBox32.Controls.Add(Me.Label203)
        Me.GroupBox32.Controls.Add(Me.Label204)
        Me.GroupBox32.Controls.Add(Me.Label205)
        Me.GroupBox32.Controls.Add(Me.Label206)
        Me.GroupBox32.Controls.Add(Me.Label207)
        Me.GroupBox32.Controls.Add(Me.Label208)
        Me.GroupBox32.Controls.Add(Me.Label209)
        Me.GroupBox32.Controls.Add(Me.Label210)
        Me.GroupBox32.Controls.Add(Me.Label211)
        Me.GroupBox32.Location = New System.Drawing.Point(4, 39)
        Me.GroupBox32.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox32.Name = "GroupBox32"
        Me.GroupBox32.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox32.Size = New System.Drawing.Size(488, 379)
        Me.GroupBox32.TabIndex = 268
        Me.GroupBox32.TabStop = False
        Me.GroupBox32.Text = "Today Operating History"
        '
        'txtMacManOperatingHistoryAlarmOnTime
        '
        Me.txtMacManOperatingHistoryAlarmOnTime.Location = New System.Drawing.Point(155, 332)
        Me.txtMacManOperatingHistoryAlarmOnTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryAlarmOnTime.Name = "txtMacManOperatingHistoryAlarmOnTime"
        Me.txtMacManOperatingHistoryAlarmOnTime.Size = New System.Drawing.Size(325, 22)
        Me.txtMacManOperatingHistoryAlarmOnTime.TabIndex = 23
        Me.txtMacManOperatingHistoryAlarmOnTime.Text = "0"
        '
        'txtMacManOperatingHistoryExternalInputTime
        '
        Me.txtMacManOperatingHistoryExternalInputTime.Location = New System.Drawing.Point(155, 305)
        Me.txtMacManOperatingHistoryExternalInputTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryExternalInputTime.Name = "txtMacManOperatingHistoryExternalInputTime"
        Me.txtMacManOperatingHistoryExternalInputTime.Size = New System.Drawing.Size(325, 22)
        Me.txtMacManOperatingHistoryExternalInputTime.TabIndex = 22
        Me.txtMacManOperatingHistoryExternalInputTime.Text = "0"
        '
        'txtMacManOperatingHistorySpindleRunTime
        '
        Me.txtMacManOperatingHistorySpindleRunTime.Location = New System.Drawing.Point(155, 277)
        Me.txtMacManOperatingHistorySpindleRunTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistorySpindleRunTime.Name = "txtMacManOperatingHistorySpindleRunTime"
        Me.txtMacManOperatingHistorySpindleRunTime.Size = New System.Drawing.Size(325, 22)
        Me.txtMacManOperatingHistorySpindleRunTime.TabIndex = 21
        Me.txtMacManOperatingHistorySpindleRunTime.Text = "0"
        '
        'txtMacManOperatingHistoryOtherTime
        '
        Me.txtMacManOperatingHistoryOtherTime.Location = New System.Drawing.Point(155, 249)
        Me.txtMacManOperatingHistoryOtherTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryOtherTime.Name = "txtMacManOperatingHistoryOtherTime"
        Me.txtMacManOperatingHistoryOtherTime.Size = New System.Drawing.Size(325, 22)
        Me.txtMacManOperatingHistoryOtherTime.TabIndex = 20
        Me.txtMacManOperatingHistoryOtherTime.Text = "0"
        '
        'txtMacManOperatingHistoryMaintenanceTime
        '
        Me.txtMacManOperatingHistoryMaintenanceTime.Location = New System.Drawing.Point(155, 222)
        Me.txtMacManOperatingHistoryMaintenanceTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryMaintenanceTime.Name = "txtMacManOperatingHistoryMaintenanceTime"
        Me.txtMacManOperatingHistoryMaintenanceTime.Size = New System.Drawing.Size(325, 22)
        Me.txtMacManOperatingHistoryMaintenanceTime.TabIndex = 19
        Me.txtMacManOperatingHistoryMaintenanceTime.Text = "0"
        '
        'txtMacManOperatingHistoryPartWaitingTime
        '
        Me.txtMacManOperatingHistoryPartWaitingTime.Location = New System.Drawing.Point(155, 194)
        Me.txtMacManOperatingHistoryPartWaitingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryPartWaitingTime.Name = "txtMacManOperatingHistoryPartWaitingTime"
        Me.txtMacManOperatingHistoryPartWaitingTime.Size = New System.Drawing.Size(325, 22)
        Me.txtMacManOperatingHistoryPartWaitingTime.TabIndex = 18
        Me.txtMacManOperatingHistoryPartWaitingTime.Text = "0"
        '
        'txtMacManOperatingHistoryNoOperatorTime
        '
        Me.txtMacManOperatingHistoryNoOperatorTime.Location = New System.Drawing.Point(155, 166)
        Me.txtMacManOperatingHistoryNoOperatorTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryNoOperatorTime.Name = "txtMacManOperatingHistoryNoOperatorTime"
        Me.txtMacManOperatingHistoryNoOperatorTime.Size = New System.Drawing.Size(325, 22)
        Me.txtMacManOperatingHistoryNoOperatorTime.TabIndex = 17
        Me.txtMacManOperatingHistoryNoOperatorTime.Text = "0"
        '
        'txtMacManOperatingHistoryInProSetupTime
        '
        Me.txtMacManOperatingHistoryInProSetupTime.Location = New System.Drawing.Point(155, 138)
        Me.txtMacManOperatingHistoryInProSetupTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryInProSetupTime.Name = "txtMacManOperatingHistoryInProSetupTime"
        Me.txtMacManOperatingHistoryInProSetupTime.Size = New System.Drawing.Size(325, 22)
        Me.txtMacManOperatingHistoryInProSetupTime.TabIndex = 16
        Me.txtMacManOperatingHistoryInProSetupTime.Text = "0"
        '
        'txtMacManOperatingHistoryNonOperatingReport
        '
        Me.txtMacManOperatingHistoryNonOperatingReport.Location = New System.Drawing.Point(155, 111)
        Me.txtMacManOperatingHistoryNonOperatingReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryNonOperatingReport.Name = "txtMacManOperatingHistoryNonOperatingReport"
        Me.txtMacManOperatingHistoryNonOperatingReport.Size = New System.Drawing.Size(325, 22)
        Me.txtMacManOperatingHistoryNonOperatingReport.TabIndex = 15
        Me.txtMacManOperatingHistoryNonOperatingReport.Text = "0"
        '
        'txtMacManOperatingHistoryCuttingTime
        '
        Me.txtMacManOperatingHistoryCuttingTime.Location = New System.Drawing.Point(155, 82)
        Me.txtMacManOperatingHistoryCuttingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryCuttingTime.Name = "txtMacManOperatingHistoryCuttingTime"
        Me.txtMacManOperatingHistoryCuttingTime.Size = New System.Drawing.Size(325, 22)
        Me.txtMacManOperatingHistoryCuttingTime.TabIndex = 14
        Me.txtMacManOperatingHistoryCuttingTime.Text = "0"
        '
        'txtMacManOperatingHistoryOperatingTime
        '
        Me.txtMacManOperatingHistoryOperatingTime.Location = New System.Drawing.Point(155, 55)
        Me.txtMacManOperatingHistoryOperatingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryOperatingTime.Name = "txtMacManOperatingHistoryOperatingTime"
        Me.txtMacManOperatingHistoryOperatingTime.Size = New System.Drawing.Size(325, 22)
        Me.txtMacManOperatingHistoryOperatingTime.TabIndex = 13
        Me.txtMacManOperatingHistoryOperatingTime.Text = "0"
        '
        'txtMacManOperatingHistoryRunningTime
        '
        Me.txtMacManOperatingHistoryRunningTime.Location = New System.Drawing.Point(155, 28)
        Me.txtMacManOperatingHistoryRunningTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMacManOperatingHistoryRunningTime.Name = "txtMacManOperatingHistoryRunningTime"
        Me.txtMacManOperatingHistoryRunningTime.Size = New System.Drawing.Size(325, 22)
        Me.txtMacManOperatingHistoryRunningTime.TabIndex = 12
        Me.txtMacManOperatingHistoryRunningTime.Text = "0"
        '
        'Label200
        '
        Me.Label200.Location = New System.Drawing.Point(11, 332)
        Me.Label200.Name = "Label200"
        Me.Label200.Size = New System.Drawing.Size(133, 27)
        Me.Label200.TabIndex = 11
        Me.Label200.Text = "Alarm on Time"
        '
        'Label201
        '
        Me.Label201.Location = New System.Drawing.Point(11, 305)
        Me.Label201.Name = "Label201"
        Me.Label201.Size = New System.Drawing.Size(133, 26)
        Me.Label201.TabIndex = 10
        Me.Label201.Text = "External input Time"
        '
        'Label202
        '
        Me.Label202.Location = New System.Drawing.Point(11, 277)
        Me.Label202.Name = "Label202"
        Me.Label202.Size = New System.Drawing.Size(120, 26)
        Me.Label202.TabIndex = 9
        Me.Label202.Text = "Spindle run Time"
        '
        'Label203
        '
        Me.Label203.Location = New System.Drawing.Point(11, 258)
        Me.Label203.Name = "Label203"
        Me.Label203.Size = New System.Drawing.Size(120, 27)
        Me.Label203.TabIndex = 8
        Me.Label203.Text = "Other Time"
        '
        'Label204
        '
        Me.Label204.Location = New System.Drawing.Point(11, 231)
        Me.Label204.Name = "Label204"
        Me.Label204.Size = New System.Drawing.Size(120, 26)
        Me.Label204.TabIndex = 7
        Me.Label204.Text = "Maintenance Time"
        '
        'Label205
        '
        Me.Label205.Location = New System.Drawing.Point(11, 203)
        Me.Label205.Name = "Label205"
        Me.Label205.Size = New System.Drawing.Size(120, 27)
        Me.Label205.TabIndex = 6
        Me.Label205.Text = "Part waiting time"
        '
        'Label206
        '
        Me.Label206.Location = New System.Drawing.Point(11, 175)
        Me.Label206.Name = "Label206"
        Me.Label206.Size = New System.Drawing.Size(120, 27)
        Me.Label206.TabIndex = 5
        Me.Label206.Text = "No Operator Time"
        '
        'Label207
        '
        Me.Label207.Location = New System.Drawing.Point(11, 148)
        Me.Label207.Name = "Label207"
        Me.Label207.Size = New System.Drawing.Size(120, 26)
        Me.Label207.TabIndex = 4
        Me.Label207.Text = "In-Pro set up Time"
        '
        'Label208
        '
        Me.Label208.Location = New System.Drawing.Point(11, 121)
        Me.Label208.Name = "Label208"
        Me.Label208.Size = New System.Drawing.Size(124, 27)
        Me.Label208.TabIndex = 3
        Me.Label208.Text = "Non operating Time"
        '
        'Label209
        '
        Me.Label209.Location = New System.Drawing.Point(11, 92)
        Me.Label209.Name = "Label209"
        Me.Label209.Size = New System.Drawing.Size(120, 27)
        Me.Label209.TabIndex = 2
        Me.Label209.Text = "Cutting TIme"
        '
        'Label210
        '
        Me.Label210.Location = New System.Drawing.Point(11, 65)
        Me.Label210.Name = "Label210"
        Me.Label210.Size = New System.Drawing.Size(120, 26)
        Me.Label210.TabIndex = 1
        Me.Label210.Text = "Operating Time"
        '
        'Label211
        '
        Me.Label211.Location = New System.Drawing.Point(11, 37)
        Me.Label211.Name = "Label211"
        Me.Label211.Size = New System.Drawing.Size(120, 26)
        Me.Label211.TabIndex = 0
        Me.Label211.Text = "Running Time"
        '
        'tabMacManOperatingReport
        '
        Me.tabMacManOperatingReport.Controls.Add(Me.txtMaxNoOfOpReport)
        Me.tabMacManOperatingReport.Controls.Add(Me.Label288)
        Me.tabMacManOperatingReport.Controls.Add(Me.btnOperatingReportUpdate)
        Me.tabMacManOperatingReport.Controls.Add(Me.GroupBox20)
        Me.tabMacManOperatingReport.Controls.Add(Me.GroupBox21)
        Me.tabMacManOperatingReport.Controls.Add(Me.GroupBox22)
        Me.tabMacManOperatingReport.Location = New System.Drawing.Point(4, 25)
        Me.tabMacManOperatingReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tabMacManOperatingReport.Name = "tabMacManOperatingReport"
        Me.tabMacManOperatingReport.Size = New System.Drawing.Size(1012, 555)
        Me.tabMacManOperatingReport.TabIndex = 12
        Me.tabMacManOperatingReport.Text = "MacMan - Operating Report"
        Me.tabMacManOperatingReport.UseVisualStyleBackColor = True
        '
        'txtMaxNoOfOpReport
        '
        Me.txtMaxNoOfOpReport.Location = New System.Drawing.Point(792, 10)
        Me.txtMaxNoOfOpReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMaxNoOfOpReport.Name = "txtMaxNoOfOpReport"
        Me.txtMaxNoOfOpReport.Size = New System.Drawing.Size(115, 22)
        Me.txtMaxNoOfOpReport.TabIndex = 323
        Me.txtMaxNoOfOpReport.Text = "0"
        '
        'Label288
        '
        Me.Label288.Location = New System.Drawing.Point(581, 10)
        Me.Label288.Name = "Label288"
        Me.Label288.Size = New System.Drawing.Size(201, 28)
        Me.Label288.TabIndex = 322
        Me.Label288.Text = "Maximum no of operating report"
        '
        'btnOperatingReportUpdate
        '
        Me.btnOperatingReportUpdate.Location = New System.Drawing.Point(801, 459)
        Me.btnOperatingReportUpdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOperatingReportUpdate.Name = "btnOperatingReportUpdate"
        Me.btnOperatingReportUpdate.Size = New System.Drawing.Size(107, 39)
        Me.btnOperatingReportUpdate.TabIndex = 321
        Me.btnOperatingReportUpdate.Text = "Update"
        '
        'GroupBox20
        '
        Me.GroupBox20.Controls.Add(Me.Label145)
        Me.GroupBox20.Controls.Add(Me.txtPrevExternalInputTime)
        Me.GroupBox20.Controls.Add(Me.txtPrevDateOfOperatingRept)
        Me.GroupBox20.Controls.Add(Me.txtPrevAlarmOnTime)
        Me.GroupBox20.Controls.Add(Me.txtPrevSpindleRunTime)
        Me.GroupBox20.Controls.Add(Me.txtPrevOtherTime)
        Me.GroupBox20.Controls.Add(Me.txtPrevMaintenanceTime)
        Me.GroupBox20.Controls.Add(Me.txtPrevPartwaitingTime)
        Me.GroupBox20.Controls.Add(Me.txtPrevNoOperatorTime)
        Me.GroupBox20.Controls.Add(Me.txtPrevInProSetupTime)
        Me.GroupBox20.Controls.Add(Me.txtPrevNonOperatingTime)
        Me.GroupBox20.Controls.Add(Me.txtPrevCuttingTime)
        Me.GroupBox20.Controls.Add(Me.txtPrevRunningTime)
        Me.GroupBox20.Controls.Add(Me.Label276)
        Me.GroupBox20.Controls.Add(Me.Label277)
        Me.GroupBox20.Controls.Add(Me.Label278)
        Me.GroupBox20.Controls.Add(Me.Label279)
        Me.GroupBox20.Controls.Add(Me.Label280)
        Me.GroupBox20.Controls.Add(Me.Label281)
        Me.GroupBox20.Controls.Add(Me.Label282)
        Me.GroupBox20.Controls.Add(Me.Label283)
        Me.GroupBox20.Controls.Add(Me.Label284)
        Me.GroupBox20.Controls.Add(Me.Label285)
        Me.GroupBox20.Controls.Add(Me.Label286)
        Me.GroupBox20.Controls.Add(Me.Label287)
        Me.GroupBox20.Controls.Add(Me.txtPrevOperatingTime)
        Me.GroupBox20.Location = New System.Drawing.Point(619, 47)
        Me.GroupBox20.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox20.Name = "GroupBox20"
        Me.GroupBox20.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox20.Size = New System.Drawing.Size(288, 406)
        Me.GroupBox20.TabIndex = 316
        Me.GroupBox20.TabStop = False
        Me.GroupBox20.Text = "Previous Day Operating Report"
        '
        'Label145
        '
        Me.Label145.Location = New System.Drawing.Point(11, 305)
        Me.Label145.Name = "Label145"
        Me.Label145.Size = New System.Drawing.Size(124, 26)
        Me.Label145.TabIndex = 219
        Me.Label145.Text = "External Input Time"
        '
        'txtPrevExternalInputTime
        '
        Me.txtPrevExternalInputTime.Location = New System.Drawing.Point(163, 295)
        Me.txtPrevExternalInputTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPrevExternalInputTime.Name = "txtPrevExternalInputTime"
        Me.txtPrevExternalInputTime.Size = New System.Drawing.Size(120, 22)
        Me.txtPrevExternalInputTime.TabIndex = 220
        Me.txtPrevExternalInputTime.Text = "0"
        '
        'txtPrevDateOfOperatingRept
        '
        Me.txtPrevDateOfOperatingRept.Location = New System.Drawing.Point(163, 351)
        Me.txtPrevDateOfOperatingRept.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPrevDateOfOperatingRept.Name = "txtPrevDateOfOperatingRept"
        Me.txtPrevDateOfOperatingRept.Size = New System.Drawing.Size(120, 22)
        Me.txtPrevDateOfOperatingRept.TabIndex = 218
        Me.txtPrevDateOfOperatingRept.Text = "0"
        '
        'txtPrevAlarmOnTime
        '
        Me.txtPrevAlarmOnTime.Location = New System.Drawing.Point(163, 322)
        Me.txtPrevAlarmOnTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPrevAlarmOnTime.Name = "txtPrevAlarmOnTime"
        Me.txtPrevAlarmOnTime.Size = New System.Drawing.Size(120, 22)
        Me.txtPrevAlarmOnTime.TabIndex = 217
        Me.txtPrevAlarmOnTime.Text = "0"
        '
        'txtPrevSpindleRunTime
        '
        Me.txtPrevSpindleRunTime.Location = New System.Drawing.Point(163, 268)
        Me.txtPrevSpindleRunTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPrevSpindleRunTime.Name = "txtPrevSpindleRunTime"
        Me.txtPrevSpindleRunTime.Size = New System.Drawing.Size(120, 22)
        Me.txtPrevSpindleRunTime.TabIndex = 216
        Me.txtPrevSpindleRunTime.Text = "0"
        '
        'txtPrevOtherTime
        '
        Me.txtPrevOtherTime.Location = New System.Drawing.Point(163, 240)
        Me.txtPrevOtherTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPrevOtherTime.Name = "txtPrevOtherTime"
        Me.txtPrevOtherTime.Size = New System.Drawing.Size(120, 22)
        Me.txtPrevOtherTime.TabIndex = 215
        Me.txtPrevOtherTime.Text = "0"
        '
        'txtPrevMaintenanceTime
        '
        Me.txtPrevMaintenanceTime.Location = New System.Drawing.Point(163, 212)
        Me.txtPrevMaintenanceTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPrevMaintenanceTime.Name = "txtPrevMaintenanceTime"
        Me.txtPrevMaintenanceTime.Size = New System.Drawing.Size(120, 22)
        Me.txtPrevMaintenanceTime.TabIndex = 214
        Me.txtPrevMaintenanceTime.Text = "0"
        '
        'txtPrevPartwaitingTime
        '
        Me.txtPrevPartwaitingTime.Location = New System.Drawing.Point(163, 185)
        Me.txtPrevPartwaitingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPrevPartwaitingTime.Name = "txtPrevPartwaitingTime"
        Me.txtPrevPartwaitingTime.Size = New System.Drawing.Size(120, 22)
        Me.txtPrevPartwaitingTime.TabIndex = 213
        Me.txtPrevPartwaitingTime.Text = "0"
        '
        'txtPrevNoOperatorTime
        '
        Me.txtPrevNoOperatorTime.Location = New System.Drawing.Point(163, 158)
        Me.txtPrevNoOperatorTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPrevNoOperatorTime.Name = "txtPrevNoOperatorTime"
        Me.txtPrevNoOperatorTime.Size = New System.Drawing.Size(120, 22)
        Me.txtPrevNoOperatorTime.TabIndex = 212
        Me.txtPrevNoOperatorTime.Text = "0"
        '
        'txtPrevInProSetupTime
        '
        Me.txtPrevInProSetupTime.Location = New System.Drawing.Point(163, 129)
        Me.txtPrevInProSetupTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPrevInProSetupTime.Name = "txtPrevInProSetupTime"
        Me.txtPrevInProSetupTime.Size = New System.Drawing.Size(120, 22)
        Me.txtPrevInProSetupTime.TabIndex = 211
        Me.txtPrevInProSetupTime.Text = "0"
        '
        'txtPrevNonOperatingTime
        '
        Me.txtPrevNonOperatingTime.Location = New System.Drawing.Point(163, 102)
        Me.txtPrevNonOperatingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPrevNonOperatingTime.Name = "txtPrevNonOperatingTime"
        Me.txtPrevNonOperatingTime.Size = New System.Drawing.Size(120, 22)
        Me.txtPrevNonOperatingTime.TabIndex = 210
        Me.txtPrevNonOperatingTime.Text = "0"
        '
        'txtPrevCuttingTime
        '
        Me.txtPrevCuttingTime.Location = New System.Drawing.Point(163, 74)
        Me.txtPrevCuttingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPrevCuttingTime.Name = "txtPrevCuttingTime"
        Me.txtPrevCuttingTime.Size = New System.Drawing.Size(120, 22)
        Me.txtPrevCuttingTime.TabIndex = 209
        Me.txtPrevCuttingTime.Text = "0"
        '
        'txtPrevRunningTime
        '
        Me.txtPrevRunningTime.Location = New System.Drawing.Point(163, 46)
        Me.txtPrevRunningTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPrevRunningTime.Name = "txtPrevRunningTime"
        Me.txtPrevRunningTime.Size = New System.Drawing.Size(120, 22)
        Me.txtPrevRunningTime.TabIndex = 208
        Me.txtPrevRunningTime.Text = "0"
        '
        'Label276
        '
        Me.Label276.Location = New System.Drawing.Point(11, 18)
        Me.Label276.Name = "Label276"
        Me.Label276.Size = New System.Drawing.Size(105, 27)
        Me.Label276.TabIndex = 203
        Me.Label276.Text = "Operating Time"
        '
        'Label277
        '
        Me.Label277.Location = New System.Drawing.Point(11, 46)
        Me.Label277.Name = "Label277"
        Me.Label277.Size = New System.Drawing.Size(120, 27)
        Me.Label277.TabIndex = 203
        Me.Label277.Text = "Runing Time"
        '
        'Label278
        '
        Me.Label278.Location = New System.Drawing.Point(11, 74)
        Me.Label278.Name = "Label278"
        Me.Label278.Size = New System.Drawing.Size(120, 26)
        Me.Label278.TabIndex = 203
        Me.Label278.Text = "Cutting Time"
        '
        'Label279
        '
        Me.Label279.Location = New System.Drawing.Point(11, 102)
        Me.Label279.Name = "Label279"
        Me.Label279.Size = New System.Drawing.Size(144, 26)
        Me.Label279.TabIndex = 203
        Me.Label279.Text = "Non Operating Time"
        '
        'Label280
        '
        Me.Label280.Location = New System.Drawing.Point(11, 129)
        Me.Label280.Name = "Label280"
        Me.Label280.Size = New System.Drawing.Size(120, 27)
        Me.Label280.TabIndex = 203
        Me.Label280.Text = "In Pro Setup Time"
        '
        'Label281
        '
        Me.Label281.Location = New System.Drawing.Point(11, 158)
        Me.Label281.Name = "Label281"
        Me.Label281.Size = New System.Drawing.Size(120, 26)
        Me.Label281.TabIndex = 203
        Me.Label281.Text = "No Operator Time"
        '
        'Label282
        '
        Me.Label282.Location = New System.Drawing.Point(11, 185)
        Me.Label282.Name = "Label282"
        Me.Label282.Size = New System.Drawing.Size(120, 26)
        Me.Label282.TabIndex = 203
        Me.Label282.Text = "Part waiting Time"
        '
        'Label283
        '
        Me.Label283.Location = New System.Drawing.Point(11, 222)
        Me.Label283.Name = "Label283"
        Me.Label283.Size = New System.Drawing.Size(120, 26)
        Me.Label283.TabIndex = 203
        Me.Label283.Text = "Maintenance Time"
        '
        'Label284
        '
        Me.Label284.Location = New System.Drawing.Point(11, 249)
        Me.Label284.Name = "Label284"
        Me.Label284.Size = New System.Drawing.Size(120, 27)
        Me.Label284.TabIndex = 203
        Me.Label284.Text = "Other Time"
        '
        'Label285
        '
        Me.Label285.Location = New System.Drawing.Point(11, 277)
        Me.Label285.Name = "Label285"
        Me.Label285.Size = New System.Drawing.Size(120, 26)
        Me.Label285.TabIndex = 203
        Me.Label285.Text = "Spindle Run Time"
        '
        'Label286
        '
        Me.Label286.Location = New System.Drawing.Point(11, 332)
        Me.Label286.Name = "Label286"
        Me.Label286.Size = New System.Drawing.Size(96, 27)
        Me.Label286.TabIndex = 203
        Me.Label286.Text = "Alarm On Time"
        '
        'Label287
        '
        Me.Label287.Location = New System.Drawing.Point(11, 359)
        Me.Label287.Name = "Label287"
        Me.Label287.Size = New System.Drawing.Size(133, 37)
        Me.Label287.TabIndex = 203
        Me.Label287.Text = "Date Of Operating report"
        '
        'txtPrevOperatingTime
        '
        Me.txtPrevOperatingTime.Location = New System.Drawing.Point(163, 18)
        Me.txtPrevOperatingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPrevOperatingTime.Name = "txtPrevOperatingTime"
        Me.txtPrevOperatingTime.Size = New System.Drawing.Size(120, 22)
        Me.txtPrevOperatingTime.TabIndex = 207
        Me.txtPrevOperatingTime.Text = "0"
        '
        'GroupBox21
        '
        Me.GroupBox21.Controls.Add(Me.Label240)
        Me.GroupBox21.Controls.Add(Me.txtOperatingTime)
        Me.GroupBox21.Controls.Add(Me.Label264)
        Me.GroupBox21.Controls.Add(Me.Label265)
        Me.GroupBox21.Controls.Add(Me.Label266)
        Me.GroupBox21.Controls.Add(Me.Label267)
        Me.GroupBox21.Controls.Add(Me.Label268)
        Me.GroupBox21.Controls.Add(Me.Label269)
        Me.GroupBox21.Controls.Add(Me.txtRunningTime)
        Me.GroupBox21.Controls.Add(Me.txtCuttingTime)
        Me.GroupBox21.Controls.Add(Me.txtNonOPeratingTime)
        Me.GroupBox21.Controls.Add(Me.txtInProSetupTime)
        Me.GroupBox21.Controls.Add(Me.txtNoOperatorTime)
        Me.GroupBox21.Controls.Add(Me.txtPartWaitingTime)
        Me.GroupBox21.Controls.Add(Me.Label270)
        Me.GroupBox21.Controls.Add(Me.txtmaintenanceTime)
        Me.GroupBox21.Controls.Add(Me.Label271)
        Me.GroupBox21.Controls.Add(Me.txtOtherTime)
        Me.GroupBox21.Controls.Add(Me.Label272)
        Me.GroupBox21.Controls.Add(Me.txtSpindleRunTime)
        Me.GroupBox21.Controls.Add(Me.Label273)
        Me.GroupBox21.Controls.Add(Me.txtExternalInputTime)
        Me.GroupBox21.Controls.Add(Me.txtAlarmOnTime)
        Me.GroupBox21.Controls.Add(Me.Label274)
        Me.GroupBox21.Controls.Add(Me.txtDateOfOperatingReport)
        Me.GroupBox21.Controls.Add(Me.Label275)
        Me.GroupBox21.Location = New System.Drawing.Point(312, 47)
        Me.GroupBox21.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox21.Name = "GroupBox21"
        Me.GroupBox21.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox21.Size = New System.Drawing.Size(297, 406)
        Me.GroupBox21.TabIndex = 315
        Me.GroupBox21.TabStop = False
        Me.GroupBox21.Text = "Today Operating report"
        '
        'Label240
        '
        Me.Label240.Location = New System.Drawing.Point(11, 18)
        Me.Label240.Name = "Label240"
        Me.Label240.Size = New System.Drawing.Size(105, 27)
        Me.Label240.TabIndex = 176
        Me.Label240.Text = "Operating Time"
        '
        'txtOperatingTime
        '
        Me.txtOperatingTime.Location = New System.Drawing.Point(173, 18)
        Me.txtOperatingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOperatingTime.Name = "txtOperatingTime"
        Me.txtOperatingTime.Size = New System.Drawing.Size(115, 22)
        Me.txtOperatingTime.TabIndex = 179
        Me.txtOperatingTime.Text = "0"
        '
        'Label264
        '
        Me.Label264.Location = New System.Drawing.Point(11, 46)
        Me.Label264.Name = "Label264"
        Me.Label264.Size = New System.Drawing.Size(120, 27)
        Me.Label264.TabIndex = 177
        Me.Label264.Text = "Runing Time"
        '
        'Label265
        '
        Me.Label265.Location = New System.Drawing.Point(11, 74)
        Me.Label265.Name = "Label265"
        Me.Label265.Size = New System.Drawing.Size(120, 26)
        Me.Label265.TabIndex = 178
        Me.Label265.Text = "Cutting Time"
        '
        'Label266
        '
        Me.Label266.Location = New System.Drawing.Point(11, 102)
        Me.Label266.Name = "Label266"
        Me.Label266.Size = New System.Drawing.Size(144, 26)
        Me.Label266.TabIndex = 182
        Me.Label266.Text = "Non Operating Time"
        '
        'Label267
        '
        Me.Label267.Location = New System.Drawing.Point(11, 129)
        Me.Label267.Name = "Label267"
        Me.Label267.Size = New System.Drawing.Size(120, 27)
        Me.Label267.TabIndex = 183
        Me.Label267.Text = "In Pro Setup Time"
        '
        'Label268
        '
        Me.Label268.Location = New System.Drawing.Point(11, 158)
        Me.Label268.Name = "Label268"
        Me.Label268.Size = New System.Drawing.Size(120, 26)
        Me.Label268.TabIndex = 184
        Me.Label268.Text = "No Operator Time"
        '
        'Label269
        '
        Me.Label269.Location = New System.Drawing.Point(11, 185)
        Me.Label269.Name = "Label269"
        Me.Label269.Size = New System.Drawing.Size(120, 26)
        Me.Label269.TabIndex = 188
        Me.Label269.Text = "Part waiting Time"
        '
        'txtRunningTime
        '
        Me.txtRunningTime.Location = New System.Drawing.Point(173, 46)
        Me.txtRunningTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtRunningTime.Name = "txtRunningTime"
        Me.txtRunningTime.Size = New System.Drawing.Size(115, 22)
        Me.txtRunningTime.TabIndex = 180
        Me.txtRunningTime.Text = "0"
        '
        'txtCuttingTime
        '
        Me.txtCuttingTime.Location = New System.Drawing.Point(173, 74)
        Me.txtCuttingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtCuttingTime.Name = "txtCuttingTime"
        Me.txtCuttingTime.Size = New System.Drawing.Size(115, 22)
        Me.txtCuttingTime.TabIndex = 181
        Me.txtCuttingTime.Text = "0"
        '
        'txtNonOPeratingTime
        '
        Me.txtNonOPeratingTime.Location = New System.Drawing.Point(173, 102)
        Me.txtNonOPeratingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNonOPeratingTime.Name = "txtNonOPeratingTime"
        Me.txtNonOPeratingTime.Size = New System.Drawing.Size(115, 22)
        Me.txtNonOPeratingTime.TabIndex = 185
        Me.txtNonOPeratingTime.Text = "0"
        '
        'txtInProSetupTime
        '
        Me.txtInProSetupTime.Location = New System.Drawing.Point(173, 129)
        Me.txtInProSetupTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtInProSetupTime.Name = "txtInProSetupTime"
        Me.txtInProSetupTime.Size = New System.Drawing.Size(115, 22)
        Me.txtInProSetupTime.TabIndex = 186
        Me.txtInProSetupTime.Text = "0"
        '
        'txtNoOperatorTime
        '
        Me.txtNoOperatorTime.Location = New System.Drawing.Point(173, 158)
        Me.txtNoOperatorTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNoOperatorTime.Name = "txtNoOperatorTime"
        Me.txtNoOperatorTime.Size = New System.Drawing.Size(115, 22)
        Me.txtNoOperatorTime.TabIndex = 187
        Me.txtNoOperatorTime.Text = "0"
        '
        'txtPartWaitingTime
        '
        Me.txtPartWaitingTime.Location = New System.Drawing.Point(173, 185)
        Me.txtPartWaitingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPartWaitingTime.Name = "txtPartWaitingTime"
        Me.txtPartWaitingTime.Size = New System.Drawing.Size(115, 22)
        Me.txtPartWaitingTime.TabIndex = 191
        Me.txtPartWaitingTime.Text = "0"
        '
        'Label270
        '
        Me.Label270.Location = New System.Drawing.Point(11, 212)
        Me.Label270.Name = "Label270"
        Me.Label270.Size = New System.Drawing.Size(120, 27)
        Me.Label270.TabIndex = 189
        Me.Label270.Text = "Maintenance Time"
        '
        'txtmaintenanceTime
        '
        Me.txtmaintenanceTime.Location = New System.Drawing.Point(173, 212)
        Me.txtmaintenanceTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtmaintenanceTime.Name = "txtmaintenanceTime"
        Me.txtmaintenanceTime.Size = New System.Drawing.Size(115, 22)
        Me.txtmaintenanceTime.TabIndex = 192
        Me.txtmaintenanceTime.Text = "0"
        '
        'Label271
        '
        Me.Label271.Location = New System.Drawing.Point(11, 240)
        Me.Label271.Name = "Label271"
        Me.Label271.Size = New System.Drawing.Size(120, 27)
        Me.Label271.TabIndex = 190
        Me.Label271.Text = "Other Time"
        '
        'txtOtherTime
        '
        Me.txtOtherTime.Location = New System.Drawing.Point(173, 240)
        Me.txtOtherTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOtherTime.Name = "txtOtherTime"
        Me.txtOtherTime.Size = New System.Drawing.Size(115, 22)
        Me.txtOtherTime.TabIndex = 193
        Me.txtOtherTime.Text = "0"
        '
        'Label272
        '
        Me.Label272.Location = New System.Drawing.Point(11, 268)
        Me.Label272.Name = "Label272"
        Me.Label272.Size = New System.Drawing.Size(120, 26)
        Me.Label272.TabIndex = 194
        Me.Label272.Text = "Spindle Run Time"
        '
        'txtSpindleRunTime
        '
        Me.txtSpindleRunTime.Location = New System.Drawing.Point(173, 268)
        Me.txtSpindleRunTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtSpindleRunTime.Name = "txtSpindleRunTime"
        Me.txtSpindleRunTime.Size = New System.Drawing.Size(115, 22)
        Me.txtSpindleRunTime.TabIndex = 199
        Me.txtSpindleRunTime.Text = "0"
        '
        'Label273
        '
        Me.Label273.Location = New System.Drawing.Point(11, 295)
        Me.Label273.Name = "Label273"
        Me.Label273.Size = New System.Drawing.Size(124, 27)
        Me.Label273.TabIndex = 195
        Me.Label273.Text = "External Input Time"
        '
        'txtExternalInputTime
        '
        Me.txtExternalInputTime.Location = New System.Drawing.Point(173, 295)
        Me.txtExternalInputTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtExternalInputTime.Name = "txtExternalInputTime"
        Me.txtExternalInputTime.Size = New System.Drawing.Size(115, 22)
        Me.txtExternalInputTime.TabIndex = 200
        Me.txtExternalInputTime.Text = "0"
        '
        'txtAlarmOnTime
        '
        Me.txtAlarmOnTime.Location = New System.Drawing.Point(173, 322)
        Me.txtAlarmOnTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAlarmOnTime.Name = "txtAlarmOnTime"
        Me.txtAlarmOnTime.Size = New System.Drawing.Size(115, 22)
        Me.txtAlarmOnTime.TabIndex = 201
        Me.txtAlarmOnTime.Text = "0"
        '
        'Label274
        '
        Me.Label274.Location = New System.Drawing.Point(11, 322)
        Me.Label274.Name = "Label274"
        Me.Label274.Size = New System.Drawing.Size(120, 27)
        Me.Label274.TabIndex = 196
        Me.Label274.Text = "Alarm On Time"
        '
        'txtDateOfOperatingReport
        '
        Me.txtDateOfOperatingReport.Location = New System.Drawing.Point(173, 351)
        Me.txtDateOfOperatingReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDateOfOperatingReport.Name = "txtDateOfOperatingReport"
        Me.txtDateOfOperatingReport.Size = New System.Drawing.Size(115, 22)
        Me.txtDateOfOperatingReport.TabIndex = 202
        Me.txtDateOfOperatingReport.Text = "0"
        '
        'Label275
        '
        Me.Label275.Location = New System.Drawing.Point(11, 351)
        Me.Label275.Name = "Label275"
        Me.Label275.Size = New System.Drawing.Size(133, 46)
        Me.Label275.TabIndex = 197
        Me.Label275.Text = "Date Of Operating report"
        '
        'GroupBox22
        '
        Me.GroupBox22.Controls.Add(Me.txtPeriodDateOfOperatingReport)
        Me.GroupBox22.Controls.Add(Me.txtPeriodAlarmOnTime)
        Me.GroupBox22.Controls.Add(Me.txtPeriodExternalInputTime)
        Me.GroupBox22.Controls.Add(Me.txtPeriodSpindleRunTime)
        Me.GroupBox22.Controls.Add(Me.txtPeriodOtherTime)
        Me.GroupBox22.Controls.Add(Me.txtPeriodMaintenanceTime)
        Me.GroupBox22.Controls.Add(Me.txtPeriodNoOperatorTime)
        Me.GroupBox22.Controls.Add(Me.txtPeriodPartWaitingTime)
        Me.GroupBox22.Controls.Add(Me.txtPeriodInproSetupTime)
        Me.GroupBox22.Controls.Add(Me.txtPeriodNonOperatingTime)
        Me.GroupBox22.Controls.Add(Me.txtPeriodCuttingTime)
        Me.GroupBox22.Controls.Add(Me.txtPeriodRunningTime)
        Me.GroupBox22.Controls.Add(Me.Label84)
        Me.GroupBox22.Controls.Add(Me.Label108)
        Me.GroupBox22.Controls.Add(Me.Label109)
        Me.GroupBox22.Controls.Add(Me.Label110)
        Me.GroupBox22.Controls.Add(Me.Label111)
        Me.GroupBox22.Controls.Add(Me.Label112)
        Me.GroupBox22.Controls.Add(Me.Label133)
        Me.GroupBox22.Controls.Add(Me.Label234)
        Me.GroupBox22.Controls.Add(Me.Label235)
        Me.GroupBox22.Controls.Add(Me.Label236)
        Me.GroupBox22.Controls.Add(Me.Label237)
        Me.GroupBox22.Controls.Add(Me.Label238)
        Me.GroupBox22.Controls.Add(Me.txtPeriodOperatingTime)
        Me.GroupBox22.Controls.Add(Me.Label239)
        Me.GroupBox22.Location = New System.Drawing.Point(5, 47)
        Me.GroupBox22.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox22.Name = "GroupBox22"
        Me.GroupBox22.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox22.Size = New System.Drawing.Size(297, 406)
        Me.GroupBox22.TabIndex = 314
        Me.GroupBox22.TabStop = False
        Me.GroupBox22.Text = "Period Operating Report"
        '
        'txtPeriodDateOfOperatingReport
        '
        Me.txtPeriodDateOfOperatingReport.Location = New System.Drawing.Point(173, 342)
        Me.txtPeriodDateOfOperatingReport.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPeriodDateOfOperatingReport.Name = "txtPeriodDateOfOperatingReport"
        Me.txtPeriodDateOfOperatingReport.Size = New System.Drawing.Size(115, 22)
        Me.txtPeriodDateOfOperatingReport.TabIndex = 216
        Me.txtPeriodDateOfOperatingReport.Text = "0"
        '
        'txtPeriodAlarmOnTime
        '
        Me.txtPeriodAlarmOnTime.Location = New System.Drawing.Point(173, 314)
        Me.txtPeriodAlarmOnTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPeriodAlarmOnTime.Name = "txtPeriodAlarmOnTime"
        Me.txtPeriodAlarmOnTime.Size = New System.Drawing.Size(115, 22)
        Me.txtPeriodAlarmOnTime.TabIndex = 215
        Me.txtPeriodAlarmOnTime.Text = "0"
        '
        'txtPeriodExternalInputTime
        '
        Me.txtPeriodExternalInputTime.Location = New System.Drawing.Point(173, 286)
        Me.txtPeriodExternalInputTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPeriodExternalInputTime.Name = "txtPeriodExternalInputTime"
        Me.txtPeriodExternalInputTime.Size = New System.Drawing.Size(115, 22)
        Me.txtPeriodExternalInputTime.TabIndex = 214
        Me.txtPeriodExternalInputTime.Text = "0"
        '
        'txtPeriodSpindleRunTime
        '
        Me.txtPeriodSpindleRunTime.Location = New System.Drawing.Point(173, 258)
        Me.txtPeriodSpindleRunTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPeriodSpindleRunTime.Name = "txtPeriodSpindleRunTime"
        Me.txtPeriodSpindleRunTime.Size = New System.Drawing.Size(115, 22)
        Me.txtPeriodSpindleRunTime.TabIndex = 213
        Me.txtPeriodSpindleRunTime.Text = "0"
        '
        'txtPeriodOtherTime
        '
        Me.txtPeriodOtherTime.Location = New System.Drawing.Point(173, 231)
        Me.txtPeriodOtherTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPeriodOtherTime.Name = "txtPeriodOtherTime"
        Me.txtPeriodOtherTime.Size = New System.Drawing.Size(115, 22)
        Me.txtPeriodOtherTime.TabIndex = 212
        Me.txtPeriodOtherTime.Text = "0"
        '
        'txtPeriodMaintenanceTime
        '
        Me.txtPeriodMaintenanceTime.Location = New System.Drawing.Point(173, 203)
        Me.txtPeriodMaintenanceTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPeriodMaintenanceTime.Name = "txtPeriodMaintenanceTime"
        Me.txtPeriodMaintenanceTime.Size = New System.Drawing.Size(115, 22)
        Me.txtPeriodMaintenanceTime.TabIndex = 211
        Me.txtPeriodMaintenanceTime.Text = "0"
        '
        'txtPeriodNoOperatorTime
        '
        Me.txtPeriodNoOperatorTime.Location = New System.Drawing.Point(173, 148)
        Me.txtPeriodNoOperatorTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPeriodNoOperatorTime.Name = "txtPeriodNoOperatorTime"
        Me.txtPeriodNoOperatorTime.Size = New System.Drawing.Size(115, 22)
        Me.txtPeriodNoOperatorTime.TabIndex = 209
        Me.txtPeriodNoOperatorTime.Text = "0"
        '
        'txtPeriodPartWaitingTime
        '
        Me.txtPeriodPartWaitingTime.Location = New System.Drawing.Point(173, 175)
        Me.txtPeriodPartWaitingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPeriodPartWaitingTime.Name = "txtPeriodPartWaitingTime"
        Me.txtPeriodPartWaitingTime.Size = New System.Drawing.Size(115, 22)
        Me.txtPeriodPartWaitingTime.TabIndex = 208
        Me.txtPeriodPartWaitingTime.Text = "0"
        '
        'txtPeriodInproSetupTime
        '
        Me.txtPeriodInproSetupTime.Location = New System.Drawing.Point(173, 121)
        Me.txtPeriodInproSetupTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPeriodInproSetupTime.Name = "txtPeriodInproSetupTime"
        Me.txtPeriodInproSetupTime.Size = New System.Drawing.Size(115, 22)
        Me.txtPeriodInproSetupTime.TabIndex = 207
        Me.txtPeriodInproSetupTime.Text = "0"
        '
        'txtPeriodNonOperatingTime
        '
        Me.txtPeriodNonOperatingTime.Location = New System.Drawing.Point(173, 92)
        Me.txtPeriodNonOperatingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPeriodNonOperatingTime.Name = "txtPeriodNonOperatingTime"
        Me.txtPeriodNonOperatingTime.Size = New System.Drawing.Size(115, 22)
        Me.txtPeriodNonOperatingTime.TabIndex = 206
        Me.txtPeriodNonOperatingTime.Text = "0"
        '
        'txtPeriodCuttingTime
        '
        Me.txtPeriodCuttingTime.Location = New System.Drawing.Point(173, 65)
        Me.txtPeriodCuttingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPeriodCuttingTime.Name = "txtPeriodCuttingTime"
        Me.txtPeriodCuttingTime.Size = New System.Drawing.Size(115, 22)
        Me.txtPeriodCuttingTime.TabIndex = 205
        Me.txtPeriodCuttingTime.Text = "0"
        '
        'txtPeriodRunningTime
        '
        Me.txtPeriodRunningTime.Location = New System.Drawing.Point(173, 37)
        Me.txtPeriodRunningTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPeriodRunningTime.Name = "txtPeriodRunningTime"
        Me.txtPeriodRunningTime.Size = New System.Drawing.Size(115, 22)
        Me.txtPeriodRunningTime.TabIndex = 204
        Me.txtPeriodRunningTime.Text = "0"
        '
        'Label84
        '
        Me.Label84.Location = New System.Drawing.Point(11, 18)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(105, 27)
        Me.Label84.TabIndex = 203
        Me.Label84.Text = "Operating Time"
        '
        'Label108
        '
        Me.Label108.Location = New System.Drawing.Point(11, 46)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(120, 27)
        Me.Label108.TabIndex = 203
        Me.Label108.Text = "Runing Time"
        '
        'Label109
        '
        Me.Label109.Location = New System.Drawing.Point(11, 74)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(120, 26)
        Me.Label109.TabIndex = 203
        Me.Label109.Text = "Cutting Time"
        '
        'Label110
        '
        Me.Label110.Location = New System.Drawing.Point(11, 102)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(144, 26)
        Me.Label110.TabIndex = 203
        Me.Label110.Text = "Non Operating Time"
        '
        'Label111
        '
        Me.Label111.Location = New System.Drawing.Point(11, 129)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(120, 27)
        Me.Label111.TabIndex = 203
        Me.Label111.Text = "In Pro Setup Time"
        '
        'Label112
        '
        Me.Label112.Location = New System.Drawing.Point(11, 158)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(120, 26)
        Me.Label112.TabIndex = 203
        Me.Label112.Text = "No Operator Time"
        '
        'Label133
        '
        Me.Label133.Location = New System.Drawing.Point(11, 185)
        Me.Label133.Name = "Label133"
        Me.Label133.Size = New System.Drawing.Size(133, 26)
        Me.Label133.TabIndex = 203
        Me.Label133.Text = "Part waiting Time"
        '
        'Label234
        '
        Me.Label234.Location = New System.Drawing.Point(11, 212)
        Me.Label234.Name = "Label234"
        Me.Label234.Size = New System.Drawing.Size(120, 27)
        Me.Label234.TabIndex = 203
        Me.Label234.Text = "Maintenance Time"
        '
        'Label235
        '
        Me.Label235.Location = New System.Drawing.Point(11, 240)
        Me.Label235.Name = "Label235"
        Me.Label235.Size = New System.Drawing.Size(120, 27)
        Me.Label235.TabIndex = 203
        Me.Label235.Text = "Other Time"
        '
        'Label236
        '
        Me.Label236.Location = New System.Drawing.Point(11, 268)
        Me.Label236.Name = "Label236"
        Me.Label236.Size = New System.Drawing.Size(120, 26)
        Me.Label236.TabIndex = 203
        Me.Label236.Text = "Spindle Run Time"
        '
        'Label237
        '
        Me.Label237.Location = New System.Drawing.Point(11, 295)
        Me.Label237.Name = "Label237"
        Me.Label237.Size = New System.Drawing.Size(124, 27)
        Me.Label237.TabIndex = 203
        Me.Label237.Text = "External Input Time"
        '
        'Label238
        '
        Me.Label238.Location = New System.Drawing.Point(19, 322)
        Me.Label238.Name = "Label238"
        Me.Label238.Size = New System.Drawing.Size(120, 27)
        Me.Label238.TabIndex = 203
        Me.Label238.Text = "Alarm On Time"
        '
        'txtPeriodOperatingTime
        '
        Me.txtPeriodOperatingTime.Location = New System.Drawing.Point(173, 9)
        Me.txtPeriodOperatingTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPeriodOperatingTime.Name = "txtPeriodOperatingTime"
        Me.txtPeriodOperatingTime.Size = New System.Drawing.Size(115, 22)
        Me.txtPeriodOperatingTime.TabIndex = 203
        Me.txtPeriodOperatingTime.Text = "0"
        '
        'Label239
        '
        Me.Label239.Location = New System.Drawing.Point(11, 351)
        Me.Label239.Name = "Label239"
        Me.Label239.Size = New System.Drawing.Size(144, 37)
        Me.Label239.TabIndex = 203
        Me.Label239.Text = "Date Of Operating report"
        '
        'tabMacManOperationHistory
        '
        Me.tabMacManOperationHistory.Controls.Add(Me.lstOperationHistory)
        Me.tabMacManOperationHistory.Controls.Add(Me.txtOperationHistoryToIndex)
        Me.tabMacManOperationHistory.Controls.Add(Me.Label139)
        Me.tabMacManOperationHistory.Controls.Add(Me.txtOperationHistoryFromIndex)
        Me.tabMacManOperationHistory.Controls.Add(Me.Label140)
        Me.tabMacManOperationHistory.Controls.Add(Me.btnOperationHistoryUpdates)
        Me.tabMacManOperationHistory.Controls.Add(Me.btnOperationHistoryUpdate)
        Me.tabMacManOperationHistory.Controls.Add(Me.txtOperationHistoryIndex)
        Me.tabMacManOperationHistory.Controls.Add(Me.Label113)
        Me.tabMacManOperationHistory.Controls.Add(Me.txtOperationHistoryTime)
        Me.tabMacManOperationHistory.Controls.Add(Me.Label116)
        Me.tabMacManOperationHistory.Controls.Add(Me.txtOperationHistoryDate)
        Me.tabMacManOperationHistory.Controls.Add(Me.Label117)
        Me.tabMacManOperationHistory.Controls.Add(Me.txtOperationHistoryData)
        Me.tabMacManOperationHistory.Controls.Add(Me.Label118)
        Me.tabMacManOperationHistory.Controls.Add(Me.txtOperationHistoryMaxCount)
        Me.tabMacManOperationHistory.Controls.Add(Me.Label119)
        Me.tabMacManOperationHistory.Controls.Add(Me.txtOperationHistoryCount)
        Me.tabMacManOperationHistory.Controls.Add(Me.Label120)
        Me.tabMacManOperationHistory.Location = New System.Drawing.Point(4, 25)
        Me.tabMacManOperationHistory.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tabMacManOperationHistory.Name = "tabMacManOperationHistory"
        Me.tabMacManOperationHistory.Size = New System.Drawing.Size(1012, 555)
        Me.tabMacManOperationHistory.TabIndex = 11
        Me.tabMacManOperationHistory.Text = "MacMan - Operation History"
        Me.tabMacManOperationHistory.UseVisualStyleBackColor = True
        '
        'lstOperationHistory
        '
        Me.lstOperationHistory.FormattingEnabled = True
        Me.lstOperationHistory.ItemHeight = 16
        Me.lstOperationHistory.Location = New System.Drawing.Point(467, 70)
        Me.lstOperationHistory.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lstOperationHistory.Name = "lstOperationHistory"
        Me.lstOperationHistory.Size = New System.Drawing.Size(529, 468)
        Me.lstOperationHistory.TabIndex = 235
        '
        'txtOperationHistoryToIndex
        '
        Me.txtOperationHistoryToIndex.Location = New System.Drawing.Point(727, 14)
        Me.txtOperationHistoryToIndex.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOperationHistoryToIndex.Name = "txtOperationHistoryToIndex"
        Me.txtOperationHistoryToIndex.Size = New System.Drawing.Size(77, 22)
        Me.txtOperationHistoryToIndex.TabIndex = 234
        Me.txtOperationHistoryToIndex.Text = "2"
        '
        'Label139
        '
        Me.Label139.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label139.Location = New System.Drawing.Point(661, 14)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(57, 18)
        Me.Label139.TabIndex = 233
        Me.Label139.Text = "To"
        '
        'txtOperationHistoryFromIndex
        '
        Me.txtOperationHistoryFromIndex.Location = New System.Drawing.Point(543, 14)
        Me.txtOperationHistoryFromIndex.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOperationHistoryFromIndex.Name = "txtOperationHistoryFromIndex"
        Me.txtOperationHistoryFromIndex.Size = New System.Drawing.Size(77, 22)
        Me.txtOperationHistoryFromIndex.TabIndex = 232
        Me.txtOperationHistoryFromIndex.Text = "1"
        '
        'Label140
        '
        Me.Label140.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label140.Location = New System.Drawing.Point(464, 14)
        Me.Label140.Name = "Label140"
        Me.Label140.Size = New System.Drawing.Size(59, 18)
        Me.Label140.TabIndex = 231
        Me.Label140.Text = "From"
        '
        'btnOperationHistoryUpdates
        '
        Me.btnOperationHistoryUpdates.Location = New System.Drawing.Point(884, 9)
        Me.btnOperationHistoryUpdates.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOperationHistoryUpdates.Name = "btnOperationHistoryUpdates"
        Me.btnOperationHistoryUpdates.Size = New System.Drawing.Size(111, 44)
        Me.btnOperationHistoryUpdates.TabIndex = 229
        Me.btnOperationHistoryUpdates.Text = "Update"
        '
        'btnOperationHistoryUpdate
        '
        Me.btnOperationHistoryUpdate.Location = New System.Drawing.Point(317, 14)
        Me.btnOperationHistoryUpdate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOperationHistoryUpdate.Name = "btnOperationHistoryUpdate"
        Me.btnOperationHistoryUpdate.Size = New System.Drawing.Size(131, 41)
        Me.btnOperationHistoryUpdate.TabIndex = 225
        Me.btnOperationHistoryUpdate.Text = "Update"
        '
        'txtOperationHistoryIndex
        '
        Me.txtOperationHistoryIndex.Location = New System.Drawing.Point(179, 18)
        Me.txtOperationHistoryIndex.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOperationHistoryIndex.Name = "txtOperationHistoryIndex"
        Me.txtOperationHistoryIndex.Size = New System.Drawing.Size(77, 22)
        Me.txtOperationHistoryIndex.TabIndex = 224
        Me.txtOperationHistoryIndex.Text = "1"
        '
        'Label113
        '
        Me.Label113.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label113.Location = New System.Drawing.Point(5, 18)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(163, 18)
        Me.Label113.TabIndex = 223
        Me.Label113.Text = "Operation History Index :"
        '
        'txtOperationHistoryTime
        '
        Me.txtOperationHistoryTime.Location = New System.Drawing.Point(228, 126)
        Me.txtOperationHistoryTime.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOperationHistoryTime.Name = "txtOperationHistoryTime"
        Me.txtOperationHistoryTime.Size = New System.Drawing.Size(221, 22)
        Me.txtOperationHistoryTime.TabIndex = 222
        '
        'Label116
        '
        Me.Label116.Location = New System.Drawing.Point(5, 126)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(192, 18)
        Me.Label116.TabIndex = 221
        Me.Label116.Text = "Operation Time :"
        '
        'txtOperationHistoryDate
        '
        Me.txtOperationHistoryDate.Location = New System.Drawing.Point(228, 98)
        Me.txtOperationHistoryDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOperationHistoryDate.Name = "txtOperationHistoryDate"
        Me.txtOperationHistoryDate.Size = New System.Drawing.Size(221, 22)
        Me.txtOperationHistoryDate.TabIndex = 220
        '
        'Label117
        '
        Me.Label117.Location = New System.Drawing.Point(5, 98)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(192, 18)
        Me.Label117.TabIndex = 219
        Me.Label117.Text = "Operation Date :"
        '
        'txtOperationHistoryData
        '
        Me.txtOperationHistoryData.Location = New System.Drawing.Point(228, 70)
        Me.txtOperationHistoryData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOperationHistoryData.Name = "txtOperationHistoryData"
        Me.txtOperationHistoryData.Size = New System.Drawing.Size(221, 22)
        Me.txtOperationHistoryData.TabIndex = 218
        '
        'Label118
        '
        Me.Label118.Location = New System.Drawing.Point(5, 70)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(192, 18)
        Me.Label118.TabIndex = 217
        Me.Label118.Text = "Operation Data :"
        '
        'txtOperationHistoryMaxCount
        '
        Me.txtOperationHistoryMaxCount.Location = New System.Drawing.Point(228, 181)
        Me.txtOperationHistoryMaxCount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOperationHistoryMaxCount.Name = "txtOperationHistoryMaxCount"
        Me.txtOperationHistoryMaxCount.Size = New System.Drawing.Size(221, 22)
        Me.txtOperationHistoryMaxCount.TabIndex = 216
        '
        'Label119
        '
        Me.Label119.Location = New System.Drawing.Point(5, 181)
        Me.Label119.Name = "Label119"
        Me.Label119.Size = New System.Drawing.Size(192, 18)
        Me.Label119.TabIndex = 215
        Me.Label119.Text = "Operation History Max Count :"
        '
        'txtOperationHistoryCount
        '
        Me.txtOperationHistoryCount.Location = New System.Drawing.Point(228, 153)
        Me.txtOperationHistoryCount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtOperationHistoryCount.Name = "txtOperationHistoryCount"
        Me.txtOperationHistoryCount.Size = New System.Drawing.Size(221, 22)
        Me.txtOperationHistoryCount.TabIndex = 214
        '
        'Label120
        '
        Me.Label120.Location = New System.Drawing.Point(5, 153)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(192, 18)
        Me.Label120.TabIndex = 213
        Me.Label120.Text = "Operation History Count :"
        '
        'tabLoader
        '
        Me.tabLoader.Location = New System.Drawing.Point(0, 0)
        Me.tabLoader.Name = "tabLoader"
        Me.tabLoader.Size = New System.Drawing.Size(200, 100)
        Me.tabLoader.TabIndex = 0
        '
        'GroupBox34
        '
        Me.GroupBox34.Controls.Add(Me.txtRegisterDataIndex)
        Me.GroupBox34.Controls.Add(Me.btnRegisterDataGet)
        Me.GroupBox34.Controls.Add(Me.btnRegisterDataSet)
        Me.GroupBox34.Controls.Add(Me.txtRegisterData)
        Me.GroupBox34.Controls.Add(Me.btnRegisterDataAdd)
        Me.GroupBox34.Controls.Add(Me.txtRegisterDataValue)
        Me.GroupBox34.Enabled = False
        Me.GroupBox34.Location = New System.Drawing.Point(4, 74)
        Me.GroupBox34.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox34.Name = "GroupBox34"
        Me.GroupBox34.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox34.Size = New System.Drawing.Size(867, 62)
        Me.GroupBox34.TabIndex = 363
        Me.GroupBox34.TabStop = False
        Me.GroupBox34.Text = "Register Data"
        '
        'txtRegisterDataIndex
        '
        Me.txtRegisterDataIndex.Location = New System.Drawing.Point(305, 26)
        Me.txtRegisterDataIndex.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRegisterDataIndex.Name = "txtRegisterDataIndex"
        Me.txtRegisterDataIndex.Size = New System.Drawing.Size(115, 22)
        Me.txtRegisterDataIndex.TabIndex = 345
        Me.txtRegisterDataIndex.Text = "1"
        '
        'btnRegisterDataGet
        '
        Me.btnRegisterDataGet.Location = New System.Drawing.Point(8, 23)
        Me.btnRegisterDataGet.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRegisterDataGet.Name = "btnRegisterDataGet"
        Me.btnRegisterDataGet.Size = New System.Drawing.Size(47, 30)
        Me.btnRegisterDataGet.TabIndex = 344
        Me.btnRegisterDataGet.Text = "Get"
        '
        'btnRegisterDataSet
        '
        Me.btnRegisterDataSet.Location = New System.Drawing.Point(53, 23)
        Me.btnRegisterDataSet.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRegisterDataSet.Name = "btnRegisterDataSet"
        Me.btnRegisterDataSet.Size = New System.Drawing.Size(47, 30)
        Me.btnRegisterDataSet.TabIndex = 340
        Me.btnRegisterDataSet.Text = "Set"
        '
        'txtRegisterData
        '
        Me.txtRegisterData.Location = New System.Drawing.Point(155, 26)
        Me.txtRegisterData.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRegisterData.Name = "txtRegisterData"
        Me.txtRegisterData.ReadOnly = True
        Me.txtRegisterData.Size = New System.Drawing.Size(115, 22)
        Me.txtRegisterData.TabIndex = 324
        Me.txtRegisterData.Text = "0"
        '
        'btnRegisterDataAdd
        '
        Me.btnRegisterDataAdd.Location = New System.Drawing.Point(100, 23)
        Me.btnRegisterDataAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRegisterDataAdd.Name = "btnRegisterDataAdd"
        Me.btnRegisterDataAdd.Size = New System.Drawing.Size(47, 30)
        Me.btnRegisterDataAdd.TabIndex = 339
        Me.btnRegisterDataAdd.Text = "Add"
        '
        'txtRegisterDataValue
        '
        Me.txtRegisterDataValue.ForeColor = System.Drawing.Color.Red
        Me.txtRegisterDataValue.Location = New System.Drawing.Point(733, 26)
        Me.txtRegisterDataValue.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRegisterDataValue.Name = "txtRegisterDataValue"
        Me.txtRegisterDataValue.Size = New System.Drawing.Size(124, 22)
        Me.txtRegisterDataValue.TabIndex = 341
        Me.txtRegisterDataValue.Text = "0"
        '
        'GroupBox33
        '
        Me.GroupBox33.Controls.Add(Me.txtPointDataIndex)
        Me.GroupBox33.Controls.Add(Me.btnPointDataGet)
        Me.GroupBox33.Controls.Add(Me.cboLoaderAxisPointData)
        Me.GroupBox33.Controls.Add(Me.btnPointDataSet)
        Me.GroupBox33.Controls.Add(Me.txtPointData)
        Me.GroupBox33.Controls.Add(Me.btnPointDataAdd)
        Me.GroupBox33.Controls.Add(Me.txtPointDataValue)
        Me.GroupBox33.Enabled = False
        Me.GroupBox33.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox33.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox33.Name = "GroupBox33"
        Me.GroupBox33.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox33.Size = New System.Drawing.Size(867, 62)
        Me.GroupBox33.TabIndex = 362
        Me.GroupBox33.TabStop = False
        Me.GroupBox33.Text = "Point Data"
        '
        'txtPointDataIndex
        '
        Me.txtPointDataIndex.Location = New System.Drawing.Point(305, 26)
        Me.txtPointDataIndex.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPointDataIndex.Name = "txtPointDataIndex"
        Me.txtPointDataIndex.Size = New System.Drawing.Size(115, 22)
        Me.txtPointDataIndex.TabIndex = 344
        Me.txtPointDataIndex.Text = "1"
        '
        'btnPointDataGet
        '
        Me.btnPointDataGet.Location = New System.Drawing.Point(8, 23)
        Me.btnPointDataGet.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPointDataGet.Name = "btnPointDataGet"
        Me.btnPointDataGet.Size = New System.Drawing.Size(47, 30)
        Me.btnPointDataGet.TabIndex = 343
        Me.btnPointDataGet.Text = "Get"
        '
        'cboLoaderAxisPointData
        '
        Me.cboLoaderAxisPointData.Location = New System.Drawing.Point(449, 26)
        Me.cboLoaderAxisPointData.Margin = New System.Windows.Forms.Padding(4)
        Me.cboLoaderAxisPointData.Name = "cboLoaderAxisPointData"
        Me.cboLoaderAxisPointData.Size = New System.Drawing.Size(171, 25)
        Me.cboLoaderAxisPointData.TabIndex = 342
        '
        'btnPointDataSet
        '
        Me.btnPointDataSet.Location = New System.Drawing.Point(53, 23)
        Me.btnPointDataSet.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPointDataSet.Name = "btnPointDataSet"
        Me.btnPointDataSet.Size = New System.Drawing.Size(47, 30)
        Me.btnPointDataSet.TabIndex = 340
        Me.btnPointDataSet.Text = "Set"
        '
        'txtPointData
        '
        Me.txtPointData.Location = New System.Drawing.Point(155, 26)
        Me.txtPointData.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPointData.Name = "txtPointData"
        Me.txtPointData.ReadOnly = True
        Me.txtPointData.Size = New System.Drawing.Size(115, 22)
        Me.txtPointData.TabIndex = 324
        Me.txtPointData.Text = "0"
        '
        'btnPointDataAdd
        '
        Me.btnPointDataAdd.Location = New System.Drawing.Point(100, 23)
        Me.btnPointDataAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPointDataAdd.Name = "btnPointDataAdd"
        Me.btnPointDataAdd.Size = New System.Drawing.Size(47, 30)
        Me.btnPointDataAdd.TabIndex = 339
        Me.btnPointDataAdd.Text = "Add"
        '
        'txtPointDataValue
        '
        Me.txtPointDataValue.ForeColor = System.Drawing.Color.Red
        Me.txtPointDataValue.Location = New System.Drawing.Point(733, 26)
        Me.txtPointDataValue.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPointDataValue.Name = "txtPointDataValue"
        Me.txtPointDataValue.Size = New System.Drawing.Size(124, 22)
        Me.txtPointDataValue.TabIndex = 341
        Me.txtPointDataValue.Text = "0"
        '
        'ErrorLog
        '
        Me.ErrorLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ErrorLog.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ErrorLog.ForeColor = System.Drawing.Color.Red
        Me.ErrorLog.Location = New System.Drawing.Point(4, 4)
        Me.ErrorLog.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ErrorLog.Multiline = True
        Me.ErrorLog.Name = "ErrorLog"
        Me.ErrorLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ErrorLog.Size = New System.Drawing.Size(911, 93)
        Me.ErrorLog.TabIndex = 7
        '
        'btnClearMessage
        '
        Me.btnClearMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnClearMessage.Location = New System.Drawing.Point(923, 4)
        Me.btnClearMessage.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnClearMessage.Name = "btnClearMessage"
        Me.btnClearMessage.Size = New System.Drawing.Size(95, 93)
        Me.btnClearMessage.TabIndex = 6
        Me.btnClearMessage.Text = "Clear Message"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(12, 155)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(833, 91)
        Me.Label8.TabIndex = 364
        Me.Label8.Text = "NOT AVAILABLE YET"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TabControl1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1028, 697)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnClearMessage, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ErrorLog, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 594)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1022, 101)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 697)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmMain"
        Me.Text = "THINC-API For Grinder"
        Me.TabControl1.ResumeLayout(False)
        Me.tabLoggingService.ResumeLayout(False)
        Me.pnlLoggingGridView.ResumeLayout(False)
        CType(Me.dgvLogging, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLogRecordBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox35.ResumeLayout(False)
        Me.GroupBox35.PerformLayout()
        CType(Me.LoggingLevelEnumBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAxis.ResumeLayout(False)
        Me.tabAxis.PerformLayout()
        Me.tabMachine.ResumeLayout(False)
        Me.tabMachine.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.tabPLCIO.ResumeLayout(False)
        Me.GroupBox36.ResumeLayout(False)
        Me.GroupBox36.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.tabProgram.ResumeLayout(False)
        Me.tabProgram.PerformLayout()
        Me.btnGetMCodes.ResumeLayout(False)
        Me.btnGetMCodes.PerformLayout()
        Me.tabSpec.ResumeLayout(False)
        Me.tabSpec.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.tabSpindle.ResumeLayout(False)
        Me.tabSpindle.PerformLayout()
        Me.GroupBox24.ResumeLayout(False)
        Me.GroupBox24.PerformLayout()
        Me.tabTools.ResumeLayout(False)
        Me.tabTools.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.tabVariables.ResumeLayout(False)
        Me.tabVariables.PerformLayout()
        Me.GroupBox19.ResumeLayout(False)
        Me.GroupBox19.PerformLayout()
        Me.tabWheel.ResumeLayout(False)
        Me.tabWheel.PerformLayout()
        Me.GroupBox23.ResumeLayout(False)
        Me.GroupBox23.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tabWorkpiece.ResumeLayout(False)
        Me.tabWorkpiece.PerformLayout()
        Me.GroupBox30.ResumeLayout(False)
        Me.GroupBox30.PerformLayout()
        Me.GroupBox29.ResumeLayout(False)
        Me.GroupBox29.PerformLayout()
        Me.GroupBox28.ResumeLayout(False)
        Me.GroupBox28.PerformLayout()
        Me.GroupBox27.ResumeLayout(False)
        Me.GroupBox27.PerformLayout()
        Me.GroupBox26.ResumeLayout(False)
        Me.GroupBox26.PerformLayout()
        Me.GroupBox25.ResumeLayout(False)
        Me.GroupBox25.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.tabMacManAlarmHistory.ResumeLayout(False)
        Me.tabMacManAlarmHistory.PerformLayout()
        Me.tabMacManMachiningReport.ResumeLayout(False)
        Me.tabMacManMachiningReport.PerformLayout()
        CType(Me.grdMachiningReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMacManOperatingHistory.ResumeLayout(False)
        Me.tabMacManOperatingHistory.PerformLayout()
        Me.GroupBox31.ResumeLayout(False)
        Me.GroupBox31.PerformLayout()
        Me.GroupBox32.ResumeLayout(False)
        Me.GroupBox32.PerformLayout()
        Me.tabMacManOperatingReport.ResumeLayout(False)
        Me.tabMacManOperatingReport.PerformLayout()
        Me.GroupBox20.ResumeLayout(False)
        Me.GroupBox20.PerformLayout()
        Me.GroupBox21.ResumeLayout(False)
        Me.GroupBox21.PerformLayout()
        Me.GroupBox22.ResumeLayout(False)
        Me.GroupBox22.PerformLayout()
        Me.tabMacManOperationHistory.ResumeLayout(False)
        Me.tabMacManOperationHistory.PerformLayout()
        Me.GroupBox34.ResumeLayout(False)
        Me.GroupBox34.PerformLayout()
        Me.GroupBox33.ResumeLayout(False)
        Me.GroupBox33.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabMachine As System.Windows.Forms.TabPage
    Friend WithEvents tabMacManMachiningReport As System.Windows.Forms.TabPage
    Friend WithEvents txtMachine As System.Windows.Forms.TextBox
    Friend WithEvents Label165 As System.Windows.Forms.Label
    Friend WithEvents machineUpdateButton As System.Windows.Forms.Button
    Friend WithEvents ErrorLog As System.Windows.Forms.TextBox
    Friend WithEvents btnClearMessage As System.Windows.Forms.Button
    Friend WithEvents tabAxis As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboAxes As System.Windows.Forms.ComboBox
    Friend WithEvents btnAxisUpdate As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtActualPositionMachineCoordinate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtActualPositionProgramCoordinate As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAxisLoad As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFeedrateType As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAxisFeedrate As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPathFeedrate As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboAxisDataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents tabSpindle As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboSpindleDataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents btnSpindleUpdate As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSpindlSurfaceSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSpindlerRateOverride As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtSpindleLoad As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSpindleActualSpeedRate As System.Windows.Forms.TextBox
    Friend WithEvents tabProgram As System.Windows.Forms.TabPage
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtProgramBlockNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtActiveScheduleProgramFileName As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtActiveProgramName As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtActiveProgramFileName As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtActiveIndexProgram As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cboProgramDataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents btnProgramUpdate As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtProgramExecuteSequenceNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtProgramCycleSelectionProgramName As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtProgramCycleSelectionProgramFileName As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtProgramCurrentCycleSelection As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtProgramRunningState As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cboProgramCycleSelection As System.Windows.Forms.ComboBox
    Friend WithEvents tabWheel As System.Windows.Forms.TabPage
    Friend WithEvents btnWheel As System.Windows.Forms.Button
    Friend WithEvents txtWheelReferencePosition As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtWheelCommandSpindleRate As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtWheelActualSpindleRate As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents txtWheelOLLoad As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtWheelGAPLoad As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents txtWheelEffectLoad As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtWheelMeasureLoad As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents txtWheelSpindleSurfaceSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtWheelSpindleRateOverride As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnWheelDataNumberSet As System.Windows.Forms.Button
    Friend WithEvents txtWheelDataNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnWheelDataNumberAdd As System.Windows.Forms.Button
    Friend WithEvents txtWheelDataNumberValue As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReferencePositionSet As System.Windows.Forms.Button
    Friend WithEvents btnReferencePositionAdd As System.Windows.Forms.Button
    Friend WithEvents txtWheelReferencePositionValue As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnWheelDiamondToolOffsetNumberSet As System.Windows.Forms.Button
    Friend WithEvents txtWheelDiamondToolOffsetNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnWheelDiamondToolOffsetNumberAdd As System.Windows.Forms.Button
    Friend WithEvents txtWheelDiamondToolOffsetNumberValue As System.Windows.Forms.TextBox
    Friend WithEvents lstWheelData As System.Windows.Forms.ListBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtWheelPPCLoad As System.Windows.Forms.TextBox
    Friend WithEvents tabTools As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnToolOffsetSet As System.Windows.Forms.Button
    Friend WithEvents txtToolOffset As System.Windows.Forms.TextBox
    Friend WithEvents btnToolOffsetAdd As System.Windows.Forms.Button
    Friend WithEvents txtToolOffsetValue As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cboDiamondToolDataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents btnDiamondTool As System.Windows.Forms.Button
    Friend WithEvents cboToolOffsetAxis As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDiamondNoseRCompAxis As System.Windows.Forms.ComboBox
    Friend WithEvents btnDiamondToolNoseRCompSet As System.Windows.Forms.Button
    Friend WithEvents txtDiamondNoseRComp As System.Windows.Forms.TextBox
    Friend WithEvents btnDiamondToolNoseRCompAdd As System.Windows.Forms.Button
    Friend WithEvents txtDiamondNoseRCompValue As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtDiamondToolIndex As System.Windows.Forms.TextBox
    Friend WithEvents tabWorkpiece As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents cboZeroShiftAxis As System.Windows.Forms.ComboBox
    Friend WithEvents btnZeroShiftSet As System.Windows.Forms.Button
    Friend WithEvents txtZeroShift As System.Windows.Forms.TextBox
    Friend WithEvents btnZeroShiftAdd As System.Windows.Forms.Button
    Friend WithEvents txtZeroShiftValue As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cboZeroOffsetAxis As System.Windows.Forms.ComboBox
    Friend WithEvents btnZeroOffsetSetSet As System.Windows.Forms.Button
    Friend WithEvents txtZeroOffset As System.Windows.Forms.TextBox
    Friend WithEvents btnZeroOffsetAdd As System.Windows.Forms.Button
    Friend WithEvents txtZeroOffsetValue As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cboWorkpieceDataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents btnUpdateWorkpiece As System.Windows.Forms.Button
    Friend WithEvents txtLoadPartProgramFileNameValue As System.Windows.Forms.TextBox
    Friend WithEvents btnLoadPartProgram As System.Windows.Forms.Button
    Friend WithEvents txtLoadSchedulePartProgramValue As System.Windows.Forms.TextBox
    Friend WithEvents btnLoadSchedulePartProgram As System.Windows.Forms.Button
    Friend WithEvents tabPLCIO As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents cboPLCBit As System.Windows.Forms.ComboBox
    Friend WithEvents btnGetBit As System.Windows.Forms.Button
    Friend WithEvents txtPLCBitAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtPLCBit As System.Windows.Forms.TextBox
    Friend WithEvents txtPLCBitData As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtCurrentTool As System.Windows.Forms.TextBox
    Friend WithEvents tabSpec As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNCSpec2 As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtNCSpec2BitValue As System.Windows.Forms.TextBox
    Friend WithEvents btnGetNCSpec2 As System.Windows.Forms.Button
    Friend WithEvents txtNCSpec2AddressValue As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNCSpec As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents txtNCSpecBitValue As System.Windows.Forms.TextBox
    Friend WithEvents btnGetNCSpec As System.Windows.Forms.Button
    Friend WithEvents txtNCSpecAddressValue As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents txtGWordValue As System.Windows.Forms.TextBox
    Friend WithEvents btnSetGWord As System.Windows.Forms.Button
    Friend WithEvents txtGWordData As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents btnGetGWord As System.Windows.Forms.Button
    Friend WithEvents txtGWordAddress As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents txtGBitValue As System.Windows.Forms.TextBox
    Friend WithEvents btnSetGBit As System.Windows.Forms.Button
    Friend WithEvents txtGBitData As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents txtGBit As System.Windows.Forms.TextBox
    Friend WithEvents btnGetGBit As System.Windows.Forms.Button
    Friend WithEvents txtGBitAddress As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents txtPLCLongWordData As System.Windows.Forms.TextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents cboPLCLongWord As System.Windows.Forms.ComboBox
    Friend WithEvents btnGetLongWord As System.Windows.Forms.Button
    Friend WithEvents txtPLCLongWordAddress As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents txtPLCWordData As System.Windows.Forms.TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents cboPLCWord As System.Windows.Forms.ComboBox
    Friend WithEvents btnGetWord As System.Windows.Forms.Button
    Friend WithEvents txtPLCWordAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents txtGLongWordValue As System.Windows.Forms.TextBox
    Friend WithEvents btnSetGLongWord As System.Windows.Forms.Button
    Friend WithEvents txtGLongWordData As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents btnGetGLongWord As System.Windows.Forms.Button
    Friend WithEvents txtGLongWordAddress As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents txtULongWordValue As System.Windows.Forms.TextBox
    Friend WithEvents btnSetULongWord As System.Windows.Forms.Button
    Friend WithEvents txtULongWordData As System.Windows.Forms.TextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents btnGetULongWord As System.Windows.Forms.Button
    Friend WithEvents txtULongWordAddress As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents txtUWordValue As System.Windows.Forms.TextBox
    Friend WithEvents btnSetUWord As System.Windows.Forms.Button
    Friend WithEvents txtUWordData As System.Windows.Forms.TextBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents btnGetUWord As System.Windows.Forms.Button
    Friend WithEvents txtUWordAddress As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents txtUBitValue As System.Windows.Forms.TextBox
    Friend WithEvents btnSetUBit As System.Windows.Forms.Button
    Friend WithEvents txtUBitData As System.Windows.Forms.TextBox
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents txtUBit As System.Windows.Forms.TextBox
    Friend WithEvents btnGetUBit As System.Windows.Forms.Button
    Friend WithEvents txtUBitAddress As System.Windows.Forms.TextBox
    Friend WithEvents tabVariables As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox19 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetCommonVariables As System.Windows.Forms.Button
    Friend WithEvents txtCommonVariableEndingIndex As System.Windows.Forms.TextBox
    Friend WithEvents txtCommonVariableStartingIndex As System.Windows.Forms.TextBox
    Friend WithEvents txtCommonVariableValue As System.Windows.Forms.TextBox
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents txtCommonVariable As System.Windows.Forms.TextBox
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents btnGetCommonVariable As System.Windows.Forms.Button
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents txtCommonVariableData As System.Windows.Forms.TextBox
    Friend WithEvents btnCommonVariableUpdate As System.Windows.Forms.Button
    Friend WithEvents btnGetCommonVariables As System.Windows.Forms.Button
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents txtCommonVariablesCount As System.Windows.Forms.TextBox
    Friend WithEvents btnAddCommonVariables As System.Windows.Forms.Button
    Friend WithEvents Label246 As System.Windows.Forms.Label
    Friend WithEvents txtCommonVarialbesData As System.Windows.Forms.TextBox
    Friend WithEvents grdMachiningReports As System.Windows.Forms.DataGrid
    Friend WithEvents txtMachiningReportNoOfWork As System.Windows.Forms.TextBox
    Friend WithEvents Label144 As System.Windows.Forms.Label
    Friend WithEvents txtMachiningReportStartTime As System.Windows.Forms.TextBox
    Friend WithEvents Label245 As System.Windows.Forms.Label
    Friend WithEvents txtMachiningReportToIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label221 As System.Windows.Forms.Label
    Friend WithEvents txtMachiningReportFromIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label222 As System.Windows.Forms.Label
    Friend WithEvents btnMacManMachiningReportUpdates As System.Windows.Forms.Button
    Friend WithEvents Label216 As System.Windows.Forms.Label
    Friend WithEvents cboMachiningReportType As System.Windows.Forms.ComboBox
    Friend WithEvents txtMachiningReportProgramName As System.Windows.Forms.TextBox
    Friend WithEvents Label217 As System.Windows.Forms.Label
    Friend WithEvents txtMachiningReportMainProgram As System.Windows.Forms.TextBox
    Friend WithEvents Label218 As System.Windows.Forms.Label
    Friend WithEvents txtMachiningReportCount As System.Windows.Forms.TextBox
    Friend WithEvents Label219 As System.Windows.Forms.Label
    Friend WithEvents btnMacManMachiningReportUpdate As System.Windows.Forms.Button
    Friend WithEvents txtMacManReportIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label220 As System.Windows.Forms.Label
    Friend WithEvents txtMachiningReportOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents Label225 As System.Windows.Forms.Label
    Friend WithEvents txtMachiningReportRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents Label226 As System.Windows.Forms.Label
    Friend WithEvents txtMachiningReportStartDate As System.Windows.Forms.TextBox
    Friend WithEvents Label227 As System.Windows.Forms.Label
    Friend WithEvents txtMachiningReportMaxCount As System.Windows.Forms.TextBox
    Friend WithEvents Label228 As System.Windows.Forms.Label
    Friend WithEvents txtMachiningReportCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents Label229 As System.Windows.Forms.Label
    Friend WithEvents tabMacManOperationHistory As System.Windows.Forms.TabPage
    Friend WithEvents lstOperationHistory As System.Windows.Forms.ListBox
    Friend WithEvents txtOperationHistoryToIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label139 As System.Windows.Forms.Label
    Friend WithEvents txtOperationHistoryFromIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label140 As System.Windows.Forms.Label
    Friend WithEvents btnOperationHistoryUpdates As System.Windows.Forms.Button
    Friend WithEvents btnOperationHistoryUpdate As System.Windows.Forms.Button
    Friend WithEvents txtOperationHistoryIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents txtOperationHistoryTime As System.Windows.Forms.TextBox
    Friend WithEvents Label116 As System.Windows.Forms.Label
    Friend WithEvents txtOperationHistoryDate As System.Windows.Forms.TextBox
    Friend WithEvents Label117 As System.Windows.Forms.Label
    Friend WithEvents txtOperationHistoryData As System.Windows.Forms.TextBox
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents txtOperationHistoryMaxCount As System.Windows.Forms.TextBox
    Friend WithEvents Label119 As System.Windows.Forms.Label
    Friend WithEvents txtOperationHistoryCount As System.Windows.Forms.TextBox
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents tabMacManOperatingReport As System.Windows.Forms.TabPage
    Friend WithEvents txtMaxNoOfOpReport As System.Windows.Forms.TextBox
    Friend WithEvents Label288 As System.Windows.Forms.Label
    Friend WithEvents btnOperatingReportUpdate As System.Windows.Forms.Button
    Friend WithEvents GroupBox20 As System.Windows.Forms.GroupBox
    Friend WithEvents Label145 As System.Windows.Forms.Label
    Friend WithEvents txtPrevExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPrevDateOfOperatingRept As System.Windows.Forms.TextBox
    Friend WithEvents txtPrevAlarmOnTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPrevSpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPrevOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPrevMaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPrevPartwaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPrevNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPrevInProSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPrevNonOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPrevCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPrevRunningTime As System.Windows.Forms.TextBox
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
    Friend WithEvents txtPrevOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox21 As System.Windows.Forms.GroupBox
    Friend WithEvents Label240 As System.Windows.Forms.Label
    Friend WithEvents txtOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents Label264 As System.Windows.Forms.Label
    Friend WithEvents Label265 As System.Windows.Forms.Label
    Friend WithEvents Label266 As System.Windows.Forms.Label
    Friend WithEvents Label267 As System.Windows.Forms.Label
    Friend WithEvents Label268 As System.Windows.Forms.Label
    Friend WithEvents Label269 As System.Windows.Forms.Label
    Friend WithEvents txtRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents txtCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents txtNonOPeratingTime As System.Windows.Forms.TextBox
    Friend WithEvents txtInProSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents txtNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPartWaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents Label270 As System.Windows.Forms.Label
    Friend WithEvents txtmaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents Label271 As System.Windows.Forms.Label
    Friend WithEvents txtOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents Label272 As System.Windows.Forms.Label
    Friend WithEvents txtSpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents Label273 As System.Windows.Forms.Label
    Friend WithEvents txtExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents txtAlarmOnTime As System.Windows.Forms.TextBox
    Friend WithEvents Label274 As System.Windows.Forms.Label
    Friend WithEvents txtDateOfOperatingReport As System.Windows.Forms.TextBox
    Friend WithEvents Label275 As System.Windows.Forms.Label
    Friend WithEvents GroupBox22 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPeriodDateOfOperatingReport As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodAlarmOnTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodSpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodMaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodPartWaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodInproSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodNonOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriodRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents Label108 As System.Windows.Forms.Label
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents Label133 As System.Windows.Forms.Label
    Friend WithEvents Label234 As System.Windows.Forms.Label
    Friend WithEvents Label235 As System.Windows.Forms.Label
    Friend WithEvents Label236 As System.Windows.Forms.Label
    Friend WithEvents Label237 As System.Windows.Forms.Label
    Friend WithEvents Label238 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents Label239 As System.Windows.Forms.Label
    Friend WithEvents tabMacManAlarmHistory As System.Windows.Forms.TabPage
    Friend WithEvents txtAlarmHistoryEndIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label137 As System.Windows.Forms.Label
    Friend WithEvents txtAlarmHistoryFromIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label138 As System.Windows.Forms.Label
    Friend WithEvents btnAlarmHistoryUpdates As System.Windows.Forms.Button
    Friend WithEvents txtAlarmObject As System.Windows.Forms.TextBox
    Friend WithEvents Label135 As System.Windows.Forms.Label
    Friend WithEvents btnAlarmHistoryUpdate As System.Windows.Forms.Button
    Friend WithEvents txtAlarmIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label107 As System.Windows.Forms.Label
    Friend WithEvents txtMaxAlarmCount As System.Windows.Forms.TextBox
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents txtAlarmCount As System.Windows.Forms.TextBox
    Friend WithEvents Label101 As System.Windows.Forms.Label
    Friend WithEvents txtAlarmTime As System.Windows.Forms.TextBox
    Friend WithEvents Label102 As System.Windows.Forms.Label
    Friend WithEvents txtAlarmNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label103 As System.Windows.Forms.Label
    Friend WithEvents txtAlarmMessage As System.Windows.Forms.TextBox
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents txtAlarmDate As System.Windows.Forms.TextBox
    Friend WithEvents Label105 As System.Windows.Forms.Label
    Friend WithEvents txtAlarmCode As System.Windows.Forms.TextBox
    Friend WithEvents Label106 As System.Windows.Forms.Label
    Friend WithEvents lstAlarms As System.Windows.Forms.ListBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnHMCount_Add As System.Windows.Forms.Button
    Friend WithEvents Label333 As System.Windows.Forms.Label
    Friend WithEvents btnHMCount_Set As System.Windows.Forms.Button
    Friend WithEvents txtHMCount As System.Windows.Forms.TextBox
    Friend WithEvents txtHMCountValue As System.Windows.Forms.TextBox
    Friend WithEvents btnHMCount_Get As System.Windows.Forms.Button
    Friend WithEvents cboHMCount As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnHMSet_Add As System.Windows.Forms.Button
    Friend WithEvents Label332 As System.Windows.Forms.Label
    Friend WithEvents btnHMSet_Set As System.Windows.Forms.Button
    Friend WithEvents txtHMSet As System.Windows.Forms.TextBox
    Friend WithEvents txtHMSetValue As System.Windows.Forms.TextBox
    Friend WithEvents btnHMSet_Get As System.Windows.Forms.Button
    Friend WithEvents cboHMSet As System.Windows.Forms.ComboBox
    Friend WithEvents btnWPCounterSet_Add As System.Windows.Forms.Button
    Friend WithEvents btnWPCounterSet_Set As System.Windows.Forms.Button
    Friend WithEvents txtWPCounterSet As System.Windows.Forms.TextBox
    Friend WithEvents txtWPCounterSetValue As System.Windows.Forms.TextBox
    Friend WithEvents btnWPCounterSet_Get As System.Windows.Forms.Button
    Friend WithEvents wkCounterSetCombo As System.Windows.Forms.ComboBox
    Friend WithEvents cmd_addWorkpiece As System.Windows.Forms.Button
    Friend WithEvents wkSetCounterValue As System.Windows.Forms.Button
    Friend WithEvents wkCounterValue As System.Windows.Forms.TextBox
    Friend WithEvents wkUpdateCounter As System.Windows.Forms.TextBox
    Friend WithEvents wkGetCounterValue As System.Windows.Forms.Button
    Friend WithEvents wkCounterCombo As System.Windows.Forms.ComboBox
    Friend WithEvents tabLoader As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox23 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox26 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox25 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox30 As System.Windows.Forms.GroupBox
    Friend WithEvents cboWorkOffsetLocatorPositiveSideEndFace As System.Windows.Forms.ComboBox
    Friend WithEvents btnWorkLocatorPositiveSideEndFaceSet As System.Windows.Forms.Button
    Friend WithEvents txtWorkLocatorPositiveSideEndFace As System.Windows.Forms.TextBox
    Friend WithEvents btnWorkLocatorPositiveSideEndFaceAdd As System.Windows.Forms.Button
    Friend WithEvents txtWorkLocatorPositiveSideEndFaceValue As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox29 As System.Windows.Forms.GroupBox
    Friend WithEvents cboWorkOffsetLocatorNegativeSideEndFace As System.Windows.Forms.ComboBox
    Friend WithEvents btnWorkLocatorNegativeSideEndFaceSet As System.Windows.Forms.Button
    Friend WithEvents txtWorkLocatorNegativeSideEndFace As System.Windows.Forms.TextBox
    Friend WithEvents btnWorkLocatorNegativeSideEndFaceAdd As System.Windows.Forms.Button
    Friend WithEvents txtWorkLocatorNegativeSideEndFaceValue As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox28 As System.Windows.Forms.GroupBox
    Friend WithEvents cboWorkOffsetCompMeasure As System.Windows.Forms.ComboBox
    Friend WithEvents btnCompMeasureSet As System.Windows.Forms.Button
    Friend WithEvents txtCompMeasure As System.Windows.Forms.TextBox
    Friend WithEvents btnCompMeasureAdd As System.Windows.Forms.Button
    Friend WithEvents txtCompMeasureValue As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox27 As System.Windows.Forms.GroupBox
    Friend WithEvents cboWorkOffsetMasterWork As System.Windows.Forms.ComboBox
    Friend WithEvents btnMasterWorkOffsetSet As System.Windows.Forms.Button
    Friend WithEvents txtMasterWorkOffset As System.Windows.Forms.TextBox
    Friend WithEvents btnMasterWorkOffsetAdd As System.Windows.Forms.Button
    Friend WithEvents txtMasterWorkOffsetValue As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtWheelDataNo As System.Windows.Forms.TextBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents txtMaxWheelData As System.Windows.Forms.TextBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents txtWheelShape As System.Windows.Forms.TextBox
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents txtWheelType As System.Windows.Forms.TextBox
    Friend WithEvents tabMacManOperatingHistory As System.Windows.Forms.TabPage
    Friend WithEvents Label191 As System.Windows.Forms.Label
    Friend WithEvents txtMacManOperatingHistoryMaxCount As System.Windows.Forms.TextBox
    Friend WithEvents btnMacManOperatingHistoryUpdate As System.Windows.Forms.Button
    Friend WithEvents Label212 As System.Windows.Forms.Label
    Friend WithEvents Label213 As System.Windows.Forms.Label
    Friend WithEvents txtMacManOperatingHistoryToIndex As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryFromIndex As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox31 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMacManOperatingHistoryPrevAlarmonTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryPrevExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryPrevSpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryPrevOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryPrevMaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryPrevPartWaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryPrevNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryPrevInProSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryPrevNonOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryPrevCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryPrevOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents Label223 As System.Windows.Forms.Label
    Friend WithEvents Label247 As System.Windows.Forms.Label
    Friend WithEvents Label250 As System.Windows.Forms.Label
    Friend WithEvents Label251 As System.Windows.Forms.Label
    Friend WithEvents Label255 As System.Windows.Forms.Label
    Friend WithEvents Label257 As System.Windows.Forms.Label
    Friend WithEvents Label258 As System.Windows.Forms.Label
    Friend WithEvents Label259 As System.Windows.Forms.Label
    Friend WithEvents Label260 As System.Windows.Forms.Label
    Friend WithEvents Label261 As System.Windows.Forms.Label
    Friend WithEvents Label262 As System.Windows.Forms.Label
    Friend WithEvents Label263 As System.Windows.Forms.Label
    Friend WithEvents txtMacManOperatingHistoryPrevRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox32 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMacManOperatingHistoryAlarmOnTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryExternalInputTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistorySpindleRunTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryOtherTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryMaintenanceTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryPartWaitingTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryNoOperatorTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryInProSetupTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryNonOperatingReport As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryCuttingTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryOperatingTime As System.Windows.Forms.TextBox
    Friend WithEvents txtMacManOperatingHistoryRunningTime As System.Windows.Forms.TextBox
    Friend WithEvents Label200 As System.Windows.Forms.Label
    Friend WithEvents Label201 As System.Windows.Forms.Label
    Friend WithEvents Label202 As System.Windows.Forms.Label
    Friend WithEvents Label203 As System.Windows.Forms.Label
    Friend WithEvents Label204 As System.Windows.Forms.Label
    Friend WithEvents Label205 As System.Windows.Forms.Label
    Friend WithEvents Label206 As System.Windows.Forms.Label
    Friend WithEvents Label207 As System.Windows.Forms.Label
    Friend WithEvents Label208 As System.Windows.Forms.Label
    Friend WithEvents Label209 As System.Windows.Forms.Label
    Friend WithEvents Label210 As System.Windows.Forms.Label
    Friend WithEvents Label211 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents txtActualPositionWheelCoordinate As System.Windows.Forms.TextBox
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents cboWheelAxes As System.Windows.Forms.ComboBox
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents txtFeedrateOverride As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox34 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRegisterDataSet As System.Windows.Forms.Button
    Friend WithEvents txtRegisterData As System.Windows.Forms.TextBox
    Friend WithEvents btnRegisterDataAdd As System.Windows.Forms.Button
    Friend WithEvents txtRegisterDataValue As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox33 As System.Windows.Forms.GroupBox
    Friend WithEvents cboLoaderAxisPointData As System.Windows.Forms.ComboBox
    Friend WithEvents btnPointDataSet As System.Windows.Forms.Button
    Friend WithEvents txtPointData As System.Windows.Forms.TextBox
    Friend WithEvents btnPointDataAdd As System.Windows.Forms.Button
    Friend WithEvents txtPointDataValue As System.Windows.Forms.TextBox
    Friend WithEvents btnRegisterDataGet As System.Windows.Forms.Button
    Friend WithEvents btnPointDataGet As System.Windows.Forms.Button
    Friend WithEvents btnSpecUpdate As System.Windows.Forms.Button
    Friend WithEvents txtOSPControlType As System.Windows.Forms.TextBox
    Friend WithEvents Label346 As System.Windows.Forms.Label
    Friend WithEvents txtMachineSerial As System.Windows.Forms.TextBox
    Friend WithEvents Label168 As System.Windows.Forms.Label
    Friend WithEvents btnGetMCodes As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox24 As System.Windows.Forms.GroupBox
    Friend WithEvents btntxtCommandSpindlerateSet As System.Windows.Forms.Button
    Friend WithEvents txtCommandSpindlerate As System.Windows.Forms.TextBox
    Friend WithEvents btntxtCommandSpindlerateAdd As System.Windows.Forms.Button
    Friend WithEvents txtCommandSpindlerateValue As System.Windows.Forms.TextBox
    Friend WithEvents btnWheelSurfaceSpeedSetupSet As System.Windows.Forms.Button
    Friend WithEvents txtWheelSurfaceSpeedSetup As System.Windows.Forms.TextBox
    Friend WithEvents btnWheelSurfaceSpeedSetupAdd As System.Windows.Forms.Button
    Friend WithEvents txtWheelSurfaceSpeedSetupValue As System.Windows.Forms.TextBox
    Friend WithEvents txtIOBitLabel As System.Windows.Forms.TextBox
    Friend WithEvents cmdIOGetBitByLabel As System.Windows.Forms.Button
    Friend WithEvents txtIOWordLabel As System.Windows.Forms.TextBox
    Friend WithEvents cmdIOGetWordByLabel As System.Windows.Forms.Button
    Friend WithEvents txtIOLongWordLabel As System.Windows.Forms.TextBox
    Friend WithEvents cmdIOGetLongWordByLabel As System.Windows.Forms.Button
    Friend WithEvents txtIOLabel As System.Windows.Forms.TextBox
    Friend WithEvents btnGetIOLabel As System.Windows.Forms.Button
    Friend WithEvents GroupBox36 As System.Windows.Forms.GroupBox
    Friend WithEvents Label297 As System.Windows.Forms.Label
    Friend WithEvents cboIOVariableTypes As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lstProgramOutput As System.Windows.Forms.ListBox
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents txtCommandFeedrate As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboWheelDataUnit As System.Windows.Forms.ComboBox
    Friend WithEvents txtMachineName As System.Windows.Forms.TextBox
    Friend WithEvents txtPointDataIndex As System.Windows.Forms.TextBox
    Friend WithEvents txtRegisterDataIndex As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tabLoggingService As System.Windows.Forms.TabPage
    Friend WithEvents pnlLoggingGridView As System.Windows.Forms.Panel
    Friend WithEvents dgvLogging As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox35 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDisplayLogRecords As System.Windows.Forms.Button
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents cboLoggingLevel As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpEndingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartingDate As System.Windows.Forms.DateTimePicker
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
    Friend WithEvents LoggingLevelEnumBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DateLoggedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AppNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClassNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MethodNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IOParametersDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoggingLevelDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MessageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLogRecordBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtWheelMaxWheels As System.Windows.Forms.TextBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents cboAllLoggignLevel As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents txtLoadSubPartProgramFileNameValue As System.Windows.Forms.TextBox
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents txtLoadPartProgramNameValue As System.Windows.Forms.TextBox
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents txtLoadPartSystemSubProgramNameValue As System.Windows.Forms.TextBox

End Class
