Imports Okuma.CGDATAPI
Imports System.Reflection
Imports Okuma.CGDATAPI.Enumerations
Imports Okuma.CGDATAPI.DataApi
Imports System.Text
Imports Okuma.ApiLog2.CApiLog
Imports Okuma.Api.LogService.Data


Public Class frmMain
#Region "Private members"
    Private m_objMachine As Okuma.CGDATAPI.DataApi.CMachine
    Private m_objAxis As Okuma.CGDATAPI.DataApi.CAxis
    Private m_objSpindle As Okuma.CGDATAPI.DataApi.CSpindle
    Private m_objProgram As Okuma.CGDATAPI.DataApi.CProgram
    Private m_objWheel As Okuma.CGDATAPI.DataApi.CWheel
    Private m_objTools As Okuma.CGDATAPI.DataApi.CTools
    Private m_objWorkpiece As Okuma.CGDATAPI.DataApi.CWorkpiece
    Private m_objSpec As Okuma.CGDATAPI.DataApi.CSpec
    Private m_objIO As Okuma.CGDATAPI.DataApi.CIO
    Private m_objVariables As Okuma.CGDATAPI.DataApi.CVariables
    'Private m_objLoader As Okuma.CGDATAPI.DataApi.CLoader

    Private m_objCmdProgram As Okuma.CGCMDAPI.CommandAPI.CProgram


    Private m_objOperationHistory As Okuma.CGDATAPI.DataApi.MacMan.COperationHistory
    Private m_objMachiningReport As Okuma.CGDATAPI.DataApi.MacMan.CMachiningReport
    Private m_objOperatingReport As Okuma.CGDATAPI.DataApi.MacMan.COperatingReport
    Private m_objAlarmHistory As Okuma.CGDATAPI.DataApi.MacMan.CAlarmHistory
    Private m_objOperatingHistory As Okuma.CGDATAPI.DataApi.MacMan.COperatingHistory

    Private m_objIOAddress As CIOAddress
#End Region

#Region "Form Events"

    Private Sub frmMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ShutDown()
    End Sub

    Private Sub ShutDown()
        If m_objMachine IsNot Nothing Then

            m_objAxis = Nothing
            m_objSpindle = Nothing
            m_objProgram = Nothing
            m_objWheel = Nothing
            m_objTools = Nothing
            m_objWorkpiece = Nothing
            m_objSpec = Nothing
            m_objIO = Nothing
            m_objVariables = Nothing
            'm_objLoader = Nothing

            m_objCmdProgram = Nothing


            m_objOperationHistory = Nothing
            m_objMachiningReport = Nothing
            m_objOperatingReport = Nothing
            m_objAlarmHistory = Nothing
            m_objOperatingHistory = Nothing

            m_objMachine.Close()

            m_objMachine = Nothing

        End If
    End Sub

    Private Sub frmMain_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

    End Sub
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


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
        Try
            cboLoaderAxisPointData.DataSource = System.Enum.GetValues(GetType(Enumerations.LoaderAxisIndexEnum))

            wkCounterSetCombo.DataSource = System.Enum.GetValues(GetType(Enumerations.WorkpieceCounterEnum))
            wkCounterCombo.DataSource = System.Enum.GetValues(GetType(Enumerations.WorkpieceCounterEnum))

            cboWheelDataUnit.DataSource = System.Enum.GetValues(GetType(Enumerations.DataUnitEnum))

            cboAxes.DataSource = System.Enum.GetValues(GetType(Enumerations.AxisIndexEnum))
            cboWheelAxes.DataSource = System.Enum.GetValues(GetType(Enumerations.WheelAxisIndexEnum))
            cboAxisDataUnit.DataSource = System.Enum.GetValues(GetType(Enumerations.DataUnitEnum))
            cboSpindleDataUnit.DataSource = System.Enum.GetValues(GetType(Enumerations.DataUnitEnum))
            cboProgramCycleSelection.DataSource = System.Enum.GetValues(GetType(Enumerations.ProgramCycleEnum))
            cboProgramDataUnit.DataSource = System.Enum.GetValues(GetType(Enumerations.DataUnitEnum))
            cboProgramDataUnit.DataSource = System.Enum.GetValues(GetType(Enumerations.DataUnitEnum))
            cboWorkpieceDataUnit.DataSource = System.Enum.GetValues(GetType(Enumerations.DataUnitEnum))
            cboDiamondToolDataUnit.DataSource = System.Enum.GetValues(GetType(Enumerations.DataUnitEnum))

            cboToolOffsetAxis.DataSource = System.Enum.GetValues(GetType(Enumerations.AxisIndexEnum))
            cboDiamondNoseRCompAxis.DataSource = System.Enum.GetValues(GetType(Enumerations.AxisIndexEnum))

            cboZeroOffsetAxis.DataSource = System.Enum.GetValues(GetType(Enumerations.AxisIndexEnum))
            cboZeroShiftAxis.DataSource = System.Enum.GetValues(GetType(Enumerations.AxisIndexEnum))

            cboWorkOffsetLocatorNegativeSideEndFace.DataSource = System.Enum.GetValues(GetType(Enumerations.AxisIndex2Enum))
            cboWorkOffsetLocatorPositiveSideEndFace.DataSource = System.Enum.GetValues(GetType(Enumerations.AxisIndex2Enum))

            cboWorkOffsetCompMeasure.DataSource = System.Enum.GetValues(GetType(Enumerations.AxisIndexEnum))
            cboWorkOffsetMasterWork.DataSource = System.Enum.GetValues(GetType(Enumerations.AxisIndexEnum))

            cboPLCBit.DataSource = System.Enum.GetValues(GetType(Enumerations.IOTypeEnum))
            cboPLCWord.DataSource = System.Enum.GetValues(GetType(Enumerations.IOTypeEnum))
            cboPLCLongWord.DataSource = System.Enum.GetValues(GetType(Enumerations.IOTypeEnum))
            cboIOVariableTypes.DataSource = System.Enum.GetValues(GetType(Enumerations.IOTypeEnum))

            cboHMSet.DataSource = System.Enum.GetValues(GetType(Enumerations.HourMeterEnum))
            cboHMCount.DataSource = System.Enum.GetValues(GetType(Enumerations.HourMeterEnum))

            cboMachiningReportType.DataSource = System.Enum.GetValues(GetType(Enumerations.ReportPeriodEnum))
            cboLoggingLevel.DataSource = System.Enum.GetValues(GetType(LoggingLevelEnum))

            m_objMachine = New DataApi.CMachine()


            m_objMachine.Init()

            m_objAxis = New CAxis
            m_objSpindle = New CSpindle
            m_objProgram = New CProgram
            m_objWheel = New CWheel
            m_objTools = New CTools
            m_objWorkpiece = New CWorkpiece
            m_objSpec = New CSpec
            m_objIO = New CIO
            m_objVariables = New CVariables
            'm_objLoader = New CLoader

            m_objCmdProgram = New Okuma.CGCMDAPI.CommandAPI.CProgram


            m_objMachiningReport = New Okuma.CGDATAPI.DataApi.MacMan.CMachiningReport
            m_objOperationHistory = New Okuma.CGDATAPI.DataApi.MacMan.COperationHistory
            m_objOperatingReport = New Okuma.CGDATAPI.DataApi.MacMan.COperatingReport
            m_objAlarmHistory = New Okuma.CGDATAPI.DataApi.MacMan.CAlarmHistory
            m_objOperatingHistory = New Okuma.CGDATAPI.DataApi.MacMan.COperatingHistory

            m_objIOAddress = New CIOAddress

            ' Add sample application version to form caption 
            Dim objVersion As System.Version
            Dim strVersion As String

            objVersion = [Assembly].GetExecutingAssembly.GetName().Version

            strVersion = String.Format("{0}.{1}.{2}.{3}", objVersion.Major.ToString, objVersion.Minor.ToString, objVersion.Build.ToString, objVersion.Revision.ToString)
            Me.Text = String.Format("{0} - {1}", "THINC Grinder Sample Application", strVersion)

            cboAllLoggignLevel.DataSource = System.Enum.GetValues(GetType(Enumerations.LoggingLevelEnum))

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

            strTextMessage = String.Format("THINC Grinder Sample Application version {0}.{1}{2}", strVersion, ControlChars.CrLf + ControlChars.CrLf, ex.Message)
            objForm = New frmMessage(strLabelMessage, strTextMessage, MessageBoxIcon.Stop)
            objForm.ShowDialog()

            'Application.Exit()
        End Try
    End Sub

#End Region

#Region "Common routines"
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
    Private Sub DisplayError(ByVal strSource As String, ByVal errMsg As String)
        Me.ErrorLog.Text = Now() & " - " & strSource & ": " & errMsg & vbCrLf & Me.ErrorLog.Text

    End Sub

    Private Sub clearLogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearMessage.Click
        Me.ErrorLog.Text = ""
    End Sub
#End Region

#Region "Machine"

    Private Sub machineUpdateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles machineUpdateButton.Click
        UpdateMachineData()
    End Sub

    Private Sub UpdateMachineData()
        Dim strValues As New StringBuilder
        Try
            strValues.Append(String.Format("Current alarm message = {0}" & vbCrLf, m_objMachine.GetCurrentAlarmMessage()))
            strValues.Append(String.Format("Dry Run State = {0}" & vbCrLf, m_objMachine.GetDryRunState()))
            strValues.Append(String.Format("Execution mode = {0}" & vbCrLf, m_objMachine.GetExecutionMode()))
            strValues.Append(String.Format("Machine Lock state = {0}" & vbCrLf, m_objMachine.GetMachineLockState()))
            strValues.Append(String.Format("NC Status.Alarm: = {0}" & vbCrLf, m_objMachine.GetNCStatus(NCStatusEnum.Alarm)))
            strValues.Append(String.Format("NC Status.Limit: = {0}" & vbCrLf, m_objMachine.GetNCStatus(NCStatusEnum.Limit)))
            strValues.Append(String.Format("NC Status.ProgramStop: = {0}" & vbCrLf, m_objMachine.GetNCStatus(NCStatusEnum.ProgramStop)))
            strValues.Append(String.Format("NC Status.Run: = {0}" & vbCrLf, m_objMachine.GetNCStatus(NCStatusEnum.Run)))
            strValues.Append(String.Format("NC Status.SlideHold: = {0}" & vbCrLf, m_objMachine.GetNCStatus(NCStatusEnum.SlideHold)))
            strValues.Append(String.Format("NC Status.STM: = {0}" & vbCrLf, m_objMachine.GetNCStatus(NCStatusEnum.STM)))
            strValues.Append(String.Format("NC Status.TurretSelection: = {0}" & vbCrLf, m_objMachine.GetNCStatus(NCStatusEnum.TurretSelection)))
            strValues.Append(String.Format("Operation Mode = {0}" & vbCrLf, m_objMachine.GetOperationMode()))
            strValues.Append(String.Format("Single block state = {0}" & vbCrLf, m_objMachine.GetSingleBlockState()))
            strValues.Append(String.Format("NC Reset state = {0}" & vbCrLf, m_objMachine.GetNCReset()))


            txtMachine.Text = strValues.ToString

        Catch ae As ApplicationException
            DisplayError("machineUpdateButton_Click", ae.Message)
        Catch ex As Exception
            DisplayError("machineUpdateButton_Click", ex.Message)
        End Try

    End Sub


#Region "Machine - Hour Meter"
#Region "Hour Meter Count"

    Private Sub btnHMCount_Get_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHMCount_Get.Click
        Try
            Dim intValue As Int32
            txtHMCount.Text = m_objMachine.GetHourMeterCount(cboHMCount.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("CMachine", ae.Message)
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub

    Private Sub btnHMCount_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHMCount_Set.Click
        Try
            Dim intValue As Int32 = CInt(txtHMCountValue.Text)
            m_objMachine.SetHourMeterCount(cboHMCount.SelectedValue, intValue)
        Catch ae As ApplicationException
            DisplayError("CMachine", ae.Message)
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub

    Private Sub btnHMCount_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHMCount_Add.Click
        Try
            Dim intValue As Int32 = CInt(txtHMCountValue.Text)
            m_objMachine.AddHourMeterCount(cboHMCount.SelectedValue, intValue)
        Catch ae As ApplicationException
            DisplayError("CMachine", ae.Message)
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub

#End Region

#Region "Hour Meter Set"
    Private Sub btnHMSet_Get_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHMSet_Get.Click
        Try
            Dim intValue As Int32
            Me.txtHMSet.Text = m_objMachine.GetHourMeterSet(cboHMSet.SelectedValue)
        Catch ae As ApplicationException
            DisplayError("CMachine", ae.Message)
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub

    Private Sub btnHMSet_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHMSet_Set.Click
        Try
            Dim intValue As Int32 = CInt(txtHMSetValue.Text)
            m_objMachine.SetHourMeterSet(cboHMSet.SelectedValue, intValue)
        Catch ae As ApplicationException
            DisplayError("CMachine", ae.Message)
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub

    Private Sub btnHMSet_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHMSet_Add.Click
        Try
            Dim intValue As Int32 = CInt(txtHMSetValue.Text)
            m_objMachine.AddHourMeterSet(cboHMSet.SelectedValue, intValue)
        Catch ae As ApplicationException
            DisplayError("CMachine", ae.Message)
        Catch ex As Exception
            DisplayError("CMachine", ex.Message)
        End Try
    End Sub
#End Region

#End Region
#End Region

#Region "Axis"

    Private Sub btnAxisUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnAxisUpdate.Click
        Try

            UpdateAxis()

        Catch ae As ApplicationException
            DisplayError("btnAxisUpdate_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnAxisUpdate_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnAxisUpdate_Click", ex.ToString)
        End Try
    End Sub

    Private Sub UpdateAxis()

        Dim enAxisIndex As AxisIndexEnum
        Dim enWheelAxisIndex As WheelAxisIndexEnum

        Dim enDataUnit As DataUnitEnum


        enAxisIndex = cboAxes.SelectedValue()
        enWheelAxisIndex = cboWheelAxes.SelectedValue()
        enDataUnit = cboAxisDataUnit.SelectedValue()

        m_objAxis.SetDataUnit(enDataUnit)


        txtActualPositionMachineCoordinate.Text = m_objAxis.GetActualPositionMachineCoord(enAxisIndex)
        txtActualPositionProgramCoordinate.Text = m_objAxis.GetActualPositionProgramCoord(enAxisIndex)
        txtAxisFeedrate.Text = m_objAxis.GetActualFeedrate(enAxisIndex)
        txtPathFeedrate.Text = m_objAxis.GetActualFeedrate()
        txtAxisLoad.Text = m_objAxis.GetAxisLoad(enAxisIndex)
        txtFeedrateType.Text = System.Enum.GetName(GetType(FeedrateTypeEnum), m_objAxis.GetFeedrateType())

        txtFeedrateOverride.Text = m_objAxis.GetFeedrateOverride()
        txtActualPositionWheelCoordinate.Text = m_objAxis.GetActualPositionWheelCoord(enWheelAxisIndex)


        txtCommandFeedrate.Text = m_objAxis.GetCommandFeedrate()
    End Sub

#End Region

#Region "Spindle"

    Private Sub btnSpindleUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnSpindleUpdate.Click
        Try
            UpdateSpindles()

        Catch ae As ApplicationException
            DisplayError("btnSpindleUpdate_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnSpindleUpdate_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnSpindleUpdate_Click", ex.ToString)
        End Try
    End Sub

    Private Sub UpdateSpindles()

        Dim enDataUnit As DataUnitEnum


        enDataUnit = cboSpindleDataUnit.SelectedValue()

        m_objSpindle.SetDataUnit(enDataUnit)

        txtSpindleLoad.Text = m_objSpindle.GetSpindleLoad()
        txtSpindlerRateOverride.Text = m_objSpindle.GetSpindlerateOverride()
        txtSpindlSurfaceSpeed.Text = m_objSpindle.GetSpindleSurfaceSpeed()
        txtSpindleActualSpeedRate.Text = m_objSpindle.GetActualSpindlerate()
        txtCommandSpindlerate.Text = m_objSpindle.GetCommandSpindlerate()
    End Sub
    Private Sub btnSpindleSpeedSetupAdd_Click(sender As System.Object, e As System.EventArgs) Handles btntxtCommandSpindlerateAdd.Click
        Try
            m_objSpindle.AddCommandSpindlerate(CInt(txtCommandSpindlerateValue.Text))
            txtCommandSpindlerate.Text = m_objSpindle.GetCommandSpindlerate()
        Catch ae As ApplicationException
            DisplayError("btnSpindleSpeedSetupAdd_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnSpindleSpeedSetupAdd_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnSpindleSpeedSetupAdd_Click", ex.ToString)
        End Try
    End Sub
    Private Sub btnSpindleSpeedSetupSet_Click(sender As System.Object, e As System.EventArgs) Handles btntxtCommandSpindlerateSet.Click
        Try
            m_objSpindle.SetCommandSpindlerate(CInt(txtCommandSpindlerateValue.Text))
            txtCommandSpindlerate.Text = m_objSpindle.GetCommandSpindlerate()
        Catch ae As ApplicationException
            DisplayError("btnSpindleSpeedSetupSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnSpindleSpeedSetupSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnSpindleSpeedSetupSet_Click", ex.ToString)
        End Try
    End Sub

#End Region

#Region "Program"

    Private Sub btnLoadPartProgram_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadPartProgram.Click
        LoadPartProgramThreadProc
    End Sub

    Private Sub LoadPartProgramThreadProc()

        Try
            Dim strMainProgramFileName As String = ""
            Dim strSubProgramFileName As String = ""
            Dim strSystemSubProgramName As String = ""
            Dim strProgramName As String = ""


            strMainProgramFileName = txtLoadPartProgramFileNameValue.Text.Trim()
            strSubProgramFileName = txtLoadSubPartProgramFileNameValue.Text.Trim()
            strSystemSubProgramName = txtLoadPartSystemSubProgramNameValue.Text.Trim()
            strProgramName = txtLoadPartProgramNameValue.Text.Trim()

            m_objCmdProgram.SelectMainProgram(strMainProgramFileName, strSubProgramFileName, strSystemSubProgramName, strProgramName)

        Catch ae As ApplicationException
            DisplayError("btnLoadPartProgram_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnLoadPartProgram_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnLoadPartProgram_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnLoadSchedulePartProgram_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadSchedulePartProgram.Click
        Try
            m_objCmdProgram.SelectScheduleProgram(txtLoadSchedulePartProgramValue.Text.Trim)
        Catch ae As ApplicationException
            DisplayError("btnLoadSchedulePartProgram_Click", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("btnLoadSchedulePartProgram_Click", ne.Message)
        Catch ex As Exception
            DisplayError("btnLoadSchedulePartProgram_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnProgramUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnProgramUpdate.Click
        Try
            UpdatePrograms()

        Catch ae As ApplicationException
            DisplayError("btnProgramUpdate_Click", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("btnProgramUpdate_Click", ne.Message)
        Catch ex As Exception
            DisplayError("btnProgramUpdate_Click", ex.ToString)
        End Try
    End Sub

    Private Sub UpdatePrograms()

        Dim enDataUnit As DataUnitEnum
        Dim enProgramCycle As ProgramCycleEnum
        Dim strValues As String

        Try


            enDataUnit = cboSpindleDataUnit.SelectedValue()
            enProgramCycle = cboProgramCycleSelection.SelectedValue()


            txtProgramBlockNumber.Text = m_objProgram.GetCurrentBlockNumber()
            txtActiveIndexProgram.Text = m_objProgram.GetActiveIndexProgram()
            txtActiveProgramFileName.Text = m_objProgram.GetActiveProgramFileName()
            txtActiveProgramName.Text = m_objProgram.GetActiveProgramName()
            txtActiveScheduleProgramFileName.Text = m_objProgram.GetActiveScheduleProgramFileName()

            txtProgramRunningState.Text = System.Enum.GetName(GetType(ProgramRunningStateEnum), m_objProgram.GetProgramRunningState())
            txtProgramCurrentCycleSelection.Text = m_objProgram.GetCurrentCycleSelection().ToString
            txtProgramCycleSelectionProgramFileName.Text = m_objProgram.GetCycleSelectProgramFileName(enProgramCycle)
            txtProgramCycleSelectionProgramName.Text = m_objProgram.GetCycleSelectProgramName(enProgramCycle)
            txtProgramExecuteSequenceNumber.Text = m_objProgram.GetExecutedSequenceNumber()
            txtActiveScheduleProgramFileName.Text = m_objProgram.GetActiveScheduleProgramFileName()

            strValues = "Execute Block: " & m_objProgram.GetExecuteBlock & vbCrLf _
                & "MCode Line 1: " & m_objProgram.GetMCodes(MCodesEnum.MCodes_Line1) & vbCrLf _
                & "MCode Line 2: " & m_objProgram.GetMCodes(MCodesEnum.MCodes_Line2) & vbCrLf _
                & "MCode Line 3: " & m_objProgram.GetMCodes(MCodesEnum.MCodes_Line3) & vbCrLf _
                & "Cycle Complete: " & m_objProgram.CycleComplete() & vbCrLf

            lstProgramOutput.Items.Clear()

            For Each strValue As String In Split(strValues, vbCrLf)
                lstProgramOutput.Items.Add(strValue)
            Next


        Catch ae As ApplicationException
            DisplayError("CProgram", ae.Message)
            'Exit Sub
        Catch ex As Exception
            DisplayError("CProgram", ex.Message)
        End Try
    End Sub
#End Region

#Region "Wheel"

    Private Sub btnWheel_Click(sender As System.Object, e As System.EventArgs) Handles btnWheel.Click
        Try
            UpdateWheelData()

            GetWheelData()

        Catch ae As ApplicationException
            DisplayError("btnWheel_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnWheel_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnWheel_Click", ex.ToString)
        End Try
    End Sub

    Private Sub UpdateWheelData()

        Dim intWheelDataNo As Integer

        Dim enDataUnit As DataUnitEnum

        enDataUnit = cboWheelDataUnit.SelectedValue()

        m_objWheel.SetDataUnit(enDataUnit)

        intWheelDataNo = CInt(txtWheelDataNo.Text)


        txtWheelActualSpindleRate.Text = m_objWheel.GetActualWheelrate
        txtWheelCommandSpindleRate.Text = m_objWheel.GetCommandWheelrate
        txtWheelDataNumber.Text = m_objWheel.GetCurrentWheelDataNumber
        txtWheelDiamondToolOffsetNumber.Text = m_objWheel.GetCurrentDiamondToolOffsetNumber
        txtWheelEffectLoad.Text = m_objWheel.GetWheelLoad(WheelLoadEnum.EffectLoad)
        txtWheelGAPLoad.Text = m_objWheel.GetWheelLoad(WheelLoadEnum.GAPLoad)
        txtWheelMeasureLoad.Text = m_objWheel.GetWheelLoad(WheelLoadEnum.MeasureLoad)
        txtWheelOLLoad.Text = m_objWheel.GetWheelLoad(WheelLoadEnum.OLLoad)
        txtWheelPPCLoad.Text = m_objWheel.GetWheelLoad(WheelLoadEnum.PPCLoad)
        txtWheelReferencePosition.Text = m_objWheel.GetWheelReferencePosition
        txtWheelSpindleRateOverride.Text = m_objWheel.GetWheelrateOverride()
        txtWheelSpindleSurfaceSpeed.Text = m_objWheel.GetWheelSurfaceSpeed()
        txtWheelSurfaceSpeedSetup.Text = m_objWheel.GetWheelSurfaceSpeedSetup()
        txtWheelCommandSpindleRate.Text = m_objWheel.GetCommandWheelrate()

        txtMaxWheelData.Text = m_objWheel.GetMaxWheelData()

        txtWheelType.Text = m_objWheel.GetWheelType(intWheelDataNo)
        txtWheelShape.Text = m_objWheel.GetWheelShape(intWheelDataNo)

        txtWheelMaxWheels.Text = m_objWheel.GetMaxWheels()

    End Sub

    Private Sub GetWheelData()
        Dim strValues As StringBuilder = New StringBuilder
        Dim objWheelData As CWheelData

        objWheelData = m_objWheel.GetWheelData(CInt(txtWheelDataNo.Text))

        lstWheelData.Items.Clear()

        lstWheelData.Items.Add(String.Format("InsideDiameter: {0}", objWheelData.InsideDiameter.ToString()))
        lstWheelData.Items.Add(String.Format("LengthPeriphery: {0}", objWheelData.LengthPeriphery.ToString()))
        lstWheelData.Items.Add(String.Format("LengthSideFace: {0}", objWheelData.LengthSideFace.ToString()))
        lstWheelData.Items.Add(String.Format("MaximumOperatingSpeed: {0}", objWheelData.MaximumOperatingSpeed.ToString()))
        lstWheelData.Items.Add(String.Format("OutSideDiameter: {0}", objWheelData.OutSideDiameter.ToString()))
        lstWheelData.Items.Add(String.Format("OutSideDiameterChange: {0}", objWheelData.OutSideDiameterChange.ToString()))
        lstWheelData.Items.Add(String.Format("OutSideDiameterForcast: {0}", objWheelData.OutSideDiameterForeCast.ToString()))
        lstWheelData.Items.Add(String.Format("OutSideDiameterIntial: {0}", objWheelData.OutSideDiameterInitial.ToString()))
        lstWheelData.Items.Add(String.Format("RadiusLeft: {0}", objWheelData.RadiusLeft.ToString()))
        lstWheelData.Items.Add(String.Format("RadiusRight: {0}", objWheelData.RadiusRight.ToString()))
        lstWheelData.Items.Add(String.Format("SlopeAngleLeft: {0}", objWheelData.SlopeAngleLeft.ToString()))
        lstWheelData.Items.Add(String.Format("SlopeAngleRight: {0}", objWheelData.SlopeAngleRight.ToString()))
        lstWheelData.Items.Add(String.Format("TaperAngleLeft: {0}", objWheelData.TaperAngleLeft.ToString()))
        lstWheelData.Items.Add(String.Format("TaperAnglePeriphery: {0}", objWheelData.TaperAnglePeriphery.ToString()))
        lstWheelData.Items.Add(String.Format("TaperAngleRight: {0}", objWheelData.TaperAngleRight.ToString()))
        lstWheelData.Items.Add(String.Format("TaperLengthLeft: {0}", objWheelData.TaperLengthLeft.ToString()))
        lstWheelData.Items.Add(String.Format("TaperLengthRight: {0}", objWheelData.TaperLengthRight.ToString()))
        lstWheelData.Items.Add(String.Format("TiltAngle: {0}", objWheelData.TiltAngle.ToString()))
        lstWheelData.Items.Add(String.Format("WidthLeftChange: {0}", objWheelData.WidthLeftChange.ToString()))
        lstWheelData.Items.Add(String.Format("WidthLeftForeCast: {0}", objWheelData.WidthLeftForeCast.ToString()))
        lstWheelData.Items.Add(String.Format("WidthLeftInitial: {0}", objWheelData.WidthLeftInitial.ToString()))
        lstWheelData.Items.Add(String.Format("WidthPeriphery: {0}", objWheelData.WidthPeriphery.ToString()))
        lstWheelData.Items.Add(String.Format("WidthPeripheryInitial: {0}", objWheelData.WidthPeripheryInitial.ToString()))
        lstWheelData.Items.Add(String.Format("WidthRight: {0}", objWheelData.WidthRight.ToString()))
        lstWheelData.Items.Add(String.Format("WidthRightChange: {0}", objWheelData.WidthRightChange.ToString()))
        lstWheelData.Items.Add(String.Format("WidthRightForeCast: {0}", objWheelData.WidthRightForeCast.ToString()))
        lstWheelData.Items.Add(String.Format("WidthRightInitial: {0}", objWheelData.WidthRightInitial.ToString()))
        lstWheelData.Items.Add(String.Format("WidthSideFace: {0}", objWheelData.WidthSideFace.ToString()))
        lstWheelData.Items.Add(String.Format("WidthSideFaceInitial: {0}", objWheelData.WidthSideFaceInitial.ToString()))
        lstWheelData.Items.Add(String.Format("X Offset: {0}", objWheelData.XOffset.ToString()))
        lstWheelData.Items.Add(String.Format("Z Offset: {0}", objWheelData.ZOffset.ToString()))




    End Sub

    Private Sub btnReferencePositionSet_Click(sender As System.Object, e As System.EventArgs) Handles btnReferencePositionSet.Click
        Try
            m_objWheel.SetWheelReferencePosition(CInt(txtWheelReferencePositionValue.Text))
            txtWheelReferencePosition.Text = m_objWheel.GetWheelReferencePosition()
        Catch ae As ApplicationException
            DisplayError("btnReferencePositionSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnReferencePositionSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnReferencePositionSet_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnWheelDiamondToolOffsetNumberSet_Click(sender As System.Object, e As System.EventArgs) Handles btnWheelDiamondToolOffsetNumberSet.Click
        Try
            Dim enDataUnit As DataUnitEnum

            enDataUnit = cboWheelDataUnit.SelectedValue()

            m_objWheel.SetDataUnit(enDataUnit)
            m_objWheel.SetCurrentDiamondToolOffsetNumber(CInt(txtWheelDiamondToolOffsetNumberValue.Text))
            txtWheelDiamondToolOffsetNumber.Text = m_objWheel.GetCurrentDiamondToolOffsetNumber()
        Catch ae As ApplicationException
            DisplayError("btnWheelDiamondToolOffsetNumberSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnWheelDiamondToolOffsetNumberSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnWheelDiamondToolOffsetNumberSet_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnWheelDataNumberAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnWheelDataNumberAdd.Click
        Try
            m_objWheel.AddCurrentWheelDataNumber(CInt(txtWheelDataNumberValue.Text))
            txtWheelDataNumber.Text = m_objWheel.GetCurrentWheelDataNumber()
        Catch ae As ApplicationException
            DisplayError("btnWheelDataNumberAdd_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnWheelDataNumberAdd_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnWheelDataNumberAdd_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnWheelDataNumberSet_Click(sender As System.Object, e As System.EventArgs) Handles btnWheelDataNumberSet.Click
        Try
            m_objWheel.SetCurrentWheelDataNumber(CInt(txtWheelDataNumberValue.Text))
            txtWheelDataNumber.Text = m_objWheel.GetCurrentWheelDataNumber()
        Catch ae As ApplicationException
            DisplayError("btnWheelDataNumberSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnWheelDataNumberSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnWheelDataNumberSet_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnReferencePositionAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnReferencePositionAdd.Click
        Try
            m_objWheel.AddWheelReferencePosition(CInt(txtWheelReferencePositionValue.Text))
            txtWheelReferencePosition.Text = m_objWheel.GetWheelReferencePosition()
        Catch ae As ApplicationException
            DisplayError("btnReferencePositionAdd_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnReferencePositionAdd_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnReferencePositionAdd_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnWheelDiamondToolOffsetNumberAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnWheelDiamondToolOffsetNumberAdd.Click
        Try
            Dim enDataUnit As DataUnitEnum

            enDataUnit = cboWheelDataUnit.SelectedValue()

            m_objWheel.SetDataUnit(enDataUnit)
            m_objWheel.AddCurrentDiamondToolOffsetNumber(CInt(txtWheelDiamondToolOffsetNumberValue.Text))
            txtWheelDiamondToolOffsetNumber.Text = m_objWheel.GetCurrentDiamondToolOffsetNumber()
        Catch ae As ApplicationException
            DisplayError("btnWheelDiamondToolOffsetNumberAdd_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnWheelDiamondToolOffsetNumberAdd_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnWheelDiamondToolOffsetNumberAdd_Click", ex.ToString)
        End Try
    End Sub



    Private Sub btnCommandWheelSurfaceSpeedSet_Click(sender As System.Object, e As System.EventArgs)
        Try
            m_objWheel.SetWheelSurfaceSpeedSetup(CInt(txtWheelSurfaceSpeedSetupValue.Text))
            txtWheelSurfaceSpeedSetup.Text = m_objWheel.GetWheelSurfaceSpeedSetup()
        Catch ae As ApplicationException
            DisplayError("btnCommandWheelSurfaceSpeedSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnCommandWheelSurfaceSpeedSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnCommandWheelSurfaceSpeedSet_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnCommandWheelSurfaceSpeedAdd_Click(sender As System.Object, e As System.EventArgs)
        Try
            m_objWheel.AddWheelSurfaceSpeedSetup(CInt(txtWheelSurfaceSpeedSetupValue.Text))
            txtWheelSurfaceSpeedSetup.Text = m_objWheel.GetWheelSurfaceSpeedSetup()
        Catch ae As ApplicationException
            DisplayError("btnCommandWheelSurfaceSpeedAdd_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnCommandWheelSurfaceSpeedAdd_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnCommandWheelSurfaceSpeedAdd_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnWheelSurfaceSpeedSetupSet_Click(sender As System.Object, e As System.EventArgs) Handles btnWheelSurfaceSpeedSetupSet.Click
        Try
            Dim enDataUnit As DataUnitEnum

            enDataUnit = cboWheelDataUnit.SelectedValue()

            m_objWheel.SetDataUnit(enDataUnit)
            m_objWheel.SetWheelSurfaceSpeedSetup(CInt(txtWheelSurfaceSpeedSetupValue.Text))
            txtWheelSurfaceSpeedSetup.Text = m_objWheel.GetWheelSurfaceSpeedSetup()
        Catch ae As ApplicationException
            DisplayError("btnWheelSurfaceSpeedSetupSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnWheelSurfaceSpeedSetupSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnWheelSurfaceSpeedSetupSet_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnWheelSurfaceSpeedSetupAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnWheelSurfaceSpeedSetupAdd.Click
        Try
            Dim enDataUnit As DataUnitEnum

            enDataUnit = cboWheelDataUnit.SelectedValue()

            m_objWheel.SetDataUnit(enDataUnit)
            m_objWheel.AddWheelSurfaceSpeedSetup(CInt(txtWheelSurfaceSpeedSetupValue.Text))
            txtWheelSurfaceSpeedSetup.Text = m_objWheel.GetWheelSurfaceSpeedSetup()
        Catch ae As ApplicationException
            DisplayError("btnWheelSurfaceSpeedSetupAdd_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnWheelSurfaceSpeedSetupAdd_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnWheelSurfaceSpeedSetupAdd_Click", ex.ToString)
        End Try
    End Sub

#End Region

#Region "Tool Offset"

    Private Sub btnDiamondTool_Click(sender As System.Object, e As System.EventArgs) Handles btnDiamondTool.Click
        Try

            UpdateTools()

        Catch ae As ApplicationException
            DisplayError("btnDiamondTool_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnDiamondTool_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnDiamondTool_Click", ex.ToString)
        End Try
    End Sub


    Private Sub UpdateTools()

        Dim enDataUnit As DataUnitEnum
        Dim intIndex As Integer
        Dim enToolOffsetAxisIndex As AxisIndexEnum
        Dim enNoseRCompAxisIndex As AxisIndexEnum


        enDataUnit = cboDiamondToolDataUnit.SelectedValue()

        m_objTools.SetDataUnit(enDataUnit)

        intIndex = CInt(txtDiamondToolIndex.Text)

        enToolOffsetAxisIndex = cboToolOffsetAxis.SelectedValue
        enNoseRCompAxisIndex = cboDiamondNoseRCompAxis.SelectedValue


        txtToolOffset.Text = m_objTools.GetToolOffset(intIndex, enToolOffsetAxisIndex)
        txtDiamondNoseRComp.Text = m_objTools.GetNoseRCompensation(intIndex, enNoseRCompAxisIndex)

        txtCurrentTool.Text = m_objTools.GetCurrentToolNumber()

    End Sub

    Private Sub btnToolOffsetSet_Click(sender As System.Object, e As System.EventArgs) Handles btnToolOffsetSet.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim intIndex As Integer
            Dim enToolOffsetAxisIndex As AxisIndexEnum


            enDataUnit = cboDiamondToolDataUnit.SelectedValue()
            enToolOffsetAxisIndex = cboToolOffsetAxis.SelectedValue

            m_objTools.SetDataUnit(enDataUnit)

            intIndex = CInt(txtDiamondToolIndex.Text)
            m_objTools.SetToolOffset(intIndex, enToolOffsetAxisIndex, CDbl(txtToolOffsetValue.Text))
            txtToolOffset.Text = m_objTools.GetToolOffset(intIndex, enToolOffsetAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnToolOffsetSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnToolOffsetSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnToolOffsetSet_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnToolOffsetAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnToolOffsetAdd.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim intIndex As Integer
            Dim enToolOffsetAxisIndex As AxisIndexEnum


            enDataUnit = cboDiamondToolDataUnit.SelectedValue()
            enToolOffsetAxisIndex = cboToolOffsetAxis.SelectedValue

            m_objTools.SetDataUnit(enDataUnit)

            intIndex = CInt(txtDiamondToolIndex.Text)
            m_objTools.AddToolOffset(intIndex, enToolOffsetAxisIndex, CDbl(txtToolOffsetValue.Text))
            txtToolOffset.Text = m_objTools.GetToolOffset(intIndex, enToolOffsetAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnToolOffsetSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnToolOffsetSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnToolOffsetSet_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnDiamondToolNoseRCompSet_Click(sender As System.Object, e As System.EventArgs) Handles btnDiamondToolNoseRCompSet.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim intIndex As Integer
            Dim enNoseRCompAxisIndex As AxisIndexEnum


            enDataUnit = cboDiamondToolDataUnit.SelectedValue()

            enNoseRCompAxisIndex = cboDiamondNoseRCompAxis.SelectedValue

            m_objTools.SetDataUnit(enDataUnit)

            intIndex = CInt(txtDiamondToolIndex.Text)
            m_objTools.SetNoseRCompensation(intIndex, enNoseRCompAxisIndex, CDbl(txtDiamondNoseRCompValue.Text))
            txtDiamondNoseRComp.Text = m_objTools.GetNoseRCompensation(intIndex, enNoseRCompAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnDiamondToolNoseRCompSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnDiamondToolNoseRCompSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnDiamondToolNoseRCompSet_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnDiamondToolNoseRCompAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnDiamondToolNoseRCompAdd.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim intIndex As Integer
            Dim enNoseRCompAxisIndex As AxisIndexEnum


            enDataUnit = cboDiamondToolDataUnit.SelectedValue()

            enNoseRCompAxisIndex = cboDiamondNoseRCompAxis.SelectedValue

            m_objTools.SetDataUnit(enDataUnit)

            intIndex = CInt(txtDiamondToolIndex.Text)
            m_objTools.AddNoseRCompensation(intIndex, enNoseRCompAxisIndex, CDbl(txtDiamondNoseRCompValue.Text))
            txtDiamondNoseRComp.Text = m_objTools.GetNoseRCompensation(intIndex, enNoseRCompAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnDiamondToolNoseRCompAdd_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnDiamondToolNoseRCompAdd_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnDiamondToolNoseRCompAdd_Click", ex.ToString)
        End Try
    End Sub

#End Region

#Region "Workpiece"
    Private Sub btnUpdateWorkpiece_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdateWorkpiece.Click
        Try

            UpdateWorkpiece()

        Catch ae As ApplicationException
            DisplayError("btnUpdateWorkpiece_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnUpdateWorkpiece_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnUpdateWorkpiece_Click", ex.ToString)
        End Try
    End Sub

    Private Sub UpdateWorkpiece()

        Dim enDataUnit As DataUnitEnum
        Dim enZeroOffsetAxisIndex As AxisIndexEnum
        Dim enZeroShiftAxisIndex As AxisIndexEnum
        Dim enAxisIndex As AxisIndexEnum


        enDataUnit = cboWorkpieceDataUnit.SelectedValue()

        m_objWorkpiece.SetDataUnit(enDataUnit)

        enZeroOffsetAxisIndex = cboZeroOffsetAxis.SelectedValue
        enZeroShiftAxisIndex = cboZeroShiftAxis.SelectedValue


        txtZeroOffset.Text = m_objWorkpiece.GetZeroOffset(enZeroOffsetAxisIndex)
        txtZeroShift.Text = m_objWorkpiece.GetZeroShift(enZeroShiftAxisIndex)

        enAxisIndex = cboWorkOffsetMasterWork.SelectedValue
        txtMasterWorkOffset.Text = m_objWorkpiece.GetWorkpieceMasterWork(enAxisIndex)


        enAxisIndex = cboWorkOffsetCompMeasure.SelectedValue
        txtCompMeasure.Text = m_objWorkpiece.GetWorkpieceCompensationMeasure(enAxisIndex)

        enAxisIndex = cboWorkOffsetLocatorNegativeSideEndFace.SelectedValue
        txtWorkLocatorNegativeSideEndFace.Text = m_objWorkpiece.GetWorkLocatorOffsetNegativeSideEndFace(enAxisIndex)

        enAxisIndex = cboWorkOffsetLocatorPositiveSideEndFace.SelectedValue
        txtWorkLocatorPositiveSideEndFace.Text = m_objWorkpiece.GetWorkLocatorOffsetPositiveSideEndFace(enAxisIndex)


    End Sub


    Private Sub btnZeroShiftAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnZeroShiftAdd.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim dblValue As Double
            Dim enAxisIndex As AxisIndexEnum


            enDataUnit = cboWorkpieceDataUnit.SelectedValue()

            enAxisIndex = cboZeroShiftAxis.SelectedValue

            m_objWorkpiece.SetDataUnit(enDataUnit)
            dblValue = CDbl(txtZeroShiftValue.Text)

            m_objWorkpiece.AddZeroShift(enAxisIndex, dblValue)
            txtZeroShift.Text = m_objWorkpiece.GetZeroShift(enAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnZeroShiftAdd_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnZeroShiftAdd_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnZeroShiftAdd_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnZeroShiftSet_Click(sender As System.Object, e As System.EventArgs) Handles btnZeroShiftSet.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim dblValue As Double
            Dim enAxisIndex As AxisIndexEnum


            enDataUnit = cboWorkpieceDataUnit.SelectedValue()

            enAxisIndex = cboZeroShiftAxis.SelectedValue

            m_objWorkpiece.SetDataUnit(enDataUnit)
            dblValue = CDbl(txtZeroShiftValue.Text)

            m_objWorkpiece.SetZeroShift(enAxisIndex, dblValue)
            txtZeroShift.Text = m_objWorkpiece.GetZeroShift(enAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnZeroShiftAdd_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnZeroShiftAdd_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnZeroShiftAdd_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnZeroOffsetAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnZeroOffsetAdd.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim dblValue As Double
            Dim enAxisIndex As AxisIndexEnum


            enDataUnit = cboWorkpieceDataUnit.SelectedValue()

            enAxisIndex = cboZeroOffsetAxis.SelectedValue

            m_objWorkpiece.SetDataUnit(enDataUnit)
            dblValue = CDbl(txtZeroOffsetValue.Text)

            m_objWorkpiece.AddZeroOffset(enAxisIndex, dblValue)
            txtZeroOffset.Text = m_objWorkpiece.GetZeroOffset(enAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnZeroOffsetAdd_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnZeroOffsetAdd_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnZeroOffsetAdd_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnZeroOffsetSetSet_Click(sender As System.Object, e As System.EventArgs) Handles btnZeroOffsetSetSet.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim dblValue As Double
            Dim enAxisIndex As AxisIndexEnum


            enDataUnit = cboWorkpieceDataUnit.SelectedValue()

            enAxisIndex = cboZeroOffsetAxis.SelectedValue

            m_objWorkpiece.SetDataUnit(enDataUnit)
            dblValue = CDbl(txtZeroOffsetValue.Text)

            m_objWorkpiece.SetZeroOffset(enAxisIndex, dblValue)
            txtZeroOffset.Text = m_objWorkpiece.GetZeroOffset(enAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnZeroOffsetSetSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnZeroOffsetSetSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnZeroOffsetSetSet_Click", ex.ToString)
        End Try
    End Sub

    'Private Sub btnZeroOffsetCal_Click(sender As System.Object, e As System.EventArgs)
    '    Try

    '        Dim enDataUnit As DataUnitEnum
    '        Dim dblValue As Double
    '        Dim enAxisIndex As AxisIndexEnum


    '        enDataUnit = cboWorkpieceDataUnit.SelectedValue()

    '        enAxisIndex = cboZeroOffsetAxis.SelectedValue

    '        m_objWorkpiece.SetDataUnit(enDataUnit)
    '        dblValue = CDbl(txtZeroOffsetValue.Text)

    '        m_objWorkpiece.CalZeroOffset(enAxisIndex, dblValue)
    '        txtZeroOffset.Text = m_objWorkpiece.GetZeroOffset(enAxisIndex)


    '    Catch ae As ApplicationException
    '        DisplayError("btnZeroOffsetCal_Click", ae.Message)
    '    Catch ex As NotSupportedException
    '        DisplayError("btnZeroOffsetCal_Click", ex.Message)
    '    Catch ex As Exception
    '        DisplayError("btnZeroOffsetCal_Click", ex.ToString)
    '    End Try
    'End Sub

    'Private Sub btnZeroShiftCal_Click(sender As System.Object, e As System.EventArgs)
    '    Try

    '        Dim enDataUnit As DataUnitEnum
    '        Dim dblValue As Double
    '        Dim enAxisIndex As AxisIndexEnum


    '        enDataUnit = cboWorkpieceDataUnit.SelectedValue()

    '        enAxisIndex = cboZeroShiftAxis.SelectedValue

    '        m_objWorkpiece.SetDataUnit(enDataUnit)
    '        dblValue = CDbl(txtZeroShiftValue.Text)

    '        m_objWorkpiece.CalZeroShift(enAxisIndex, dblValue)
    '        txtZeroShift.Text = m_objWorkpiece.GetZeroShift(enAxisIndex)


    '    Catch ae As ApplicationException
    '        DisplayError("btnZeroShiftCal_Click", ae.Message)
    '    Catch ex As NotSupportedException
    '        DisplayError("btnZeroShiftCal_Click", ex.Message)
    '    Catch ex As Exception
    '        DisplayError("btnZeroShiftCal_Click", ex.ToString)
    '    End Try
    'End Sub


#Region "Work Locator - Negative Side End Face"
    Private Sub btnWorkLocatorNegativeSideEndFaceSet_Click(sender As System.Object, e As System.EventArgs) Handles btnWorkLocatorNegativeSideEndFaceSet.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim dblValue As Double
            Dim enAxisIndex As AxisIndexEnum


            enDataUnit = cboWorkpieceDataUnit.SelectedValue()

            enAxisIndex = cboWorkOffsetLocatorNegativeSideEndFace.SelectedValue

            m_objWorkpiece.SetDataUnit(enDataUnit)
            dblValue = CDbl(txtWorkLocatorNegativeSideEndFaceValue.Text)

            m_objWorkpiece.SetWorkLocatorOffsetNegativeSideEndFace(enAxisIndex, dblValue)
            txtWorkLocatorNegativeSideEndFace.Text = m_objWorkpiece.GetWorkLocatorOffsetNegativeSideEndFace(enAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnWorkLocatorNegativeSideEndFaceSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnWorkLocatorNegativeSideEndFaceSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnWorkLocatorNegativeSideEndFaceSet_Click", ex.ToString)
        End Try
    End Sub

    'Private Sub btnWorkLocatorNegativeSideEndFaceCal_Click(sender As System.Object, e As System.EventArgs)
    '    Try

    '        Dim enDataUnit As DataUnitEnum
    '        Dim dblValue As Double
    '        Dim enAxisIndex As AxisIndexEnum


    '        enDataUnit = cboWorkpieceDataUnit.SelectedValue()

    '        enAxisIndex = cboWorkOffsetLocatorNegativeSideEndFace.SelectedValue

    '        m_objWorkpiece.SetDataUnit(enDataUnit)
    '        dblValue = CDbl(txtWorkLocatorNegativeSideEndFaceValue.Text)

    '        m_objWorkpiece.CalWorkLocatorOffsetNegativeSideEndFace(enAxisIndex, dblValue)
    '        txtWorkLocatorNegativeSideEndFace.Text = m_objWorkpiece.GetWorkLocatorOffsetNegativeSideEndFace(enAxisIndex)


    '    Catch ae As ApplicationException
    '        DisplayError("btnWorkLocatorNegativeSideEndFaceCal_Click", ae.Message)
    '    Catch ex As NotSupportedException
    '        DisplayError("btnWorkLocatorNegativeSideEndFaceCal_Click", ex.Message)
    '    Catch ex As Exception
    '        DisplayError("btnWorkLocatorNegativeSideEndFaceCal_Click", ex.ToString)
    '    End Try
    'End Sub

    Private Sub btnWorkLocatorNegativeSideEndFaceAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnWorkLocatorNegativeSideEndFaceAdd.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim dblValue As Double
            Dim enAxisIndex As AxisIndexEnum


            enDataUnit = cboWorkpieceDataUnit.SelectedValue()

            enAxisIndex = cboWorkOffsetLocatorNegativeSideEndFace.SelectedValue

            m_objWorkpiece.SetDataUnit(enDataUnit)
            dblValue = CDbl(txtWorkLocatorNegativeSideEndFaceValue.Text)

            m_objWorkpiece.AddWorkLocatorOffsetNegativeSideEndFace(enAxisIndex, dblValue)
            txtWorkLocatorNegativeSideEndFace.Text = m_objWorkpiece.GetWorkLocatorOffsetNegativeSideEndFace(enAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnWorkLocatorNegativeSideEndFaceAdd_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnWorkLocatorNegativeSideEndFaceAdd_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnWorkLocatorNegativeSideEndFaceAdd_Click", ex.ToString)
        End Try
    End Sub

#End Region

#Region "Work Locator - Positive Side End Face"
    Private Sub btnWorkLocatorPositiveSideEndFaceAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnWorkLocatorPositiveSideEndFaceAdd.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim dblValue As Double
            Dim enAxisIndex As AxisIndexEnum


            enDataUnit = cboWorkpieceDataUnit.SelectedValue()

            enAxisIndex = cboWorkOffsetLocatorPositiveSideEndFace.SelectedValue

            m_objWorkpiece.SetDataUnit(enDataUnit)
            dblValue = CDbl(txtWorkLocatorPositiveSideEndFaceValue.Text)

            m_objWorkpiece.AddWorkLocatorOffsetPositiveSideEndFace(enAxisIndex, dblValue)
            txtWorkLocatorPositiveSideEndFace.Text = m_objWorkpiece.GetWorkLocatorOffsetPositiveSideEndFace(enAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnWorkLocatorPositiveSideEndFaceAdd_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnWorkLocatorPositiveSideEndFaceAdd_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnWorkLocatorPositiveSideEndFaceAdd_Click", ex.ToString)
        End Try
    End Sub
    Private Sub btnWorkLocatorPositiveSideEndFaceSet_Click(sender As System.Object, e As System.EventArgs) Handles btnWorkLocatorPositiveSideEndFaceSet.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim dblValue As Double
            Dim enAxisIndex As AxisIndexEnum


            enDataUnit = cboWorkpieceDataUnit.SelectedValue()

            enAxisIndex = cboWorkOffsetLocatorPositiveSideEndFace.SelectedValue

            m_objWorkpiece.SetDataUnit(enDataUnit)
            dblValue = CDbl(txtWorkLocatorPositiveSideEndFaceValue.Text)

            m_objWorkpiece.SetWorkLocatorOffsetPositiveSideEndFace(enAxisIndex, dblValue)
            txtWorkLocatorPositiveSideEndFace.Text = m_objWorkpiece.GetWorkLocatorOffsetPositiveSideEndFace(enAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnWorkLocatorPositiveSideEndFaceSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnWorkLocatorPositiveSideEndFaceSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnWorkLocatorPositiveSideEndFaceSet_Click", ex.ToString)
        End Try
    End Sub

    'Private Sub btnWorkLocatorPositiveSideEndFaceCal_Click(sender As System.Object, e As System.EventArgs)
    '    Try

    '        Dim enDataUnit As DataUnitEnum
    '        Dim dblValue As Double
    '        Dim enAxisIndex As AxisIndexEnum


    '        enDataUnit = cboWorkpieceDataUnit.SelectedValue()

    '        enAxisIndex = cboWorkOffsetLocatorPositiveSideEndFace.SelectedValue

    '        m_objWorkpiece.SetDataUnit(enDataUnit)
    '        dblValue = CDbl(txtWorkLocatorPositiveSideEndFaceValue.Text)

    '        m_objWorkpiece.CalWorkLocatorOffsetPositiveSideEndFace(enAxisIndex, dblValue)
    '        txtWorkLocatorPositiveSideEndFace.Text = m_objWorkpiece.GetWorkLocatorOffsetPositiveSideEndFace(enAxisIndex)


    '    Catch ae As ApplicationException
    '        DisplayError("btnWorkLocatorPositiveSideEndFaceCal_Click", ae.Message)
    '    Catch ex As NotSupportedException
    '        DisplayError("btnWorkLocatorPositiveSideEndFaceCal_Click", ex.Message)
    '    Catch ex As Exception
    '        DisplayError("btnWorkLocatorPositiveSideEndFaceCal_Click", ex.ToString)
    '    End Try
    'End Sub

#End Region

#Region "Workpiece Counter Set"
    Private Sub btnWPCounterSet_Get_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWPCounterSet_Get.Click
        Try
            Dim cnt As Int32
            cnt = m_objWorkpiece.GetWorkpieceCounterSet(wkCounterSetCombo.SelectedValue)
            Me.txtWPCounterSet.Text = cnt
        Catch ae As ApplicationException
            DisplayError("btnWPCounterSet_Get_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnWPCounterSet_Get_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnWPCounterSet_Get_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnWPCounterSet_Set_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWPCounterSet_Set.Click
        Try
            m_objWorkpiece.SetWorkpieceCounterSet(Me.wkCounterSetCombo.SelectedValue, CInt(Me.txtWPCounterSetValue.Text))
            Dim cnt As Int32
            cnt = m_objWorkpiece.GetWorkpieceCounterSet(wkCounterSetCombo.SelectedValue)
            Me.txtWPCounterSet.Text = cnt
        Catch ae As ApplicationException
            DisplayError("btnWPCounterSet_Set_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnWPCounterSet_Set_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnWPCounterSet_Set_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnWPCounterSet_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWPCounterSet_Add.Click
        Try
            m_objWorkpiece.AddWorkpieceCounterSet(Me.wkCounterSetCombo.SelectedValue, CInt(Me.txtWPCounterSetValue.Text))
            Dim cnt As Int32
            cnt = m_objWorkpiece.GetWorkpieceCounterSet(wkCounterSetCombo.SelectedValue)
            Me.txtWPCounterSet.Text = cnt
        Catch ae As ApplicationException
            DisplayError("btnWPCounterSet_Add_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnWPCounterSet_Add_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnWPCounterSet_Add_Click", ex.ToString)
        End Try
    End Sub
#End Region
#Region "Workpiece Counter Count"
    Private Sub cmd_addWorkpiece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_addWorkpiece.Click
        Try
            m_objWorkpiece.AddWorkpieceCounter(Me.wkCounterCombo.SelectedValue, CInt(Me.wkUpdateCounter.Text))
            Dim cnt As Int32
            cnt = m_objWorkpiece.GetWorkpieceCounter(wkCounterCombo.SelectedValue)
            Me.wkCounterValue.Text = cnt
        Catch ae As ApplicationException
            DisplayError("cmd_addWorkpiece_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("cmd_addWorkpiece_Click", ex.Message)
        Catch ex As Exception
            DisplayError("cmd_addWorkpiece_Click", ex.ToString)
        End Try
    End Sub

    Private Sub wkGetCounterValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkGetCounterValue.Click
        Try
            Dim cnt As Int32
            cnt = m_objWorkpiece.GetWorkpieceCounter(wkCounterCombo.SelectedValue)
            Me.wkCounterValue.Text = cnt
        Catch ae As ApplicationException
            DisplayError("wkGetCounterValue_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("wkGetCounterValue_Click", ex.Message)
        Catch ex As Exception
            DisplayError("wkGetCounterValue_Click", ex.ToString)
        End Try
    End Sub


    Private Sub wkSetCounterValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wkSetCounterValue.Click
        Try
            m_objWorkpiece.SetWorkpieceCounter(Me.wkCounterCombo.SelectedValue, CInt(Me.wkUpdateCounter.Text))
            Dim cnt As Int32
            cnt = m_objWorkpiece.GetWorkpieceCounter(wkCounterCombo.SelectedValue)
            Me.wkCounterValue.Text = cnt
        Catch ae As ApplicationException
            DisplayError("wkSetCounterValue_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("wkSetCounterValue_Click", ex.Message)
        Catch ex As Exception
            DisplayError("wkSetCounterValue_Click", ex.ToString)
        End Try
    End Sub
#End Region


    Private Sub btnMasterWorkOffsetSet_Click(sender As System.Object, e As System.EventArgs) Handles btnMasterWorkOffsetSet.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim dblValue As Double
            Dim enAxisIndex As AxisIndexEnum


            enDataUnit = cboWorkpieceDataUnit.SelectedValue()

            enAxisIndex = cboWorkOffsetMasterWork.SelectedValue

            m_objWorkpiece.SetDataUnit(enDataUnit)
            dblValue = CDbl(txtMasterWorkOffsetValue.Text)

            m_objWorkpiece.SetWorkpieceMasterWork(enAxisIndex, dblValue)
            txtMasterWorkOffset.Text = m_objWorkpiece.GetWorkpieceMasterWork(enAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnMasterWorkOffsetSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnMasterWorkOffsetSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnMasterWorkOffsetSet_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnMasterWorkOffsetAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnMasterWorkOffsetAdd.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim dblValue As Double
            Dim enAxisIndex As AxisIndexEnum


            enDataUnit = cboWorkpieceDataUnit.SelectedValue()

            enAxisIndex = cboWorkOffsetMasterWork.SelectedValue

            m_objWorkpiece.SetDataUnit(enDataUnit)
            dblValue = CDbl(txtMasterWorkOffsetValue.Text)

            m_objWorkpiece.AddWorkpieceMasterWork(enAxisIndex, dblValue)
            txtMasterWorkOffset.Text = m_objWorkpiece.GetWorkpieceMasterWork(enAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnMasterWorkOffsetSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnMasterWorkOffsetSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnMasterWorkOffsetSet_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnCompMeasureSet_Click(sender As System.Object, e As System.EventArgs) Handles btnCompMeasureSet.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim dblValue As Double
            Dim enAxisIndex As AxisIndexEnum


            enDataUnit = cboWorkpieceDataUnit.SelectedValue()

            enAxisIndex = cboWorkOffsetCompMeasure.SelectedValue

            m_objWorkpiece.SetDataUnit(enDataUnit)
            dblValue = CDbl(txtCompMeasureValue.Text)

            m_objWorkpiece.SetWorkpieceCompensationMeasure(enAxisIndex, dblValue)
            txtCompMeasure.Text = m_objWorkpiece.GetWorkpieceCompensationMeasure(enAxisIndex)



        Catch ae As ApplicationException
            DisplayError("btnCompMeasureAdd_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnCompMeasureAdd_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnCompMeasureAdd_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnCompMeasureAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnCompMeasureAdd.Click
        Try

            Dim enDataUnit As DataUnitEnum
            Dim dblValue As Double
            Dim enAxisIndex As AxisIndexEnum


            enDataUnit = cboWorkpieceDataUnit.SelectedValue()

            enAxisIndex = cboWorkOffsetCompMeasure.SelectedValue

            m_objWorkpiece.SetDataUnit(enDataUnit)
            dblValue = CDbl(txtCompMeasureValue.Text)

            m_objWorkpiece.AddWorkpieceCompensationMeasure(enAxisIndex, dblValue)
            txtCompMeasure.Text = m_objWorkpiece.GetWorkpieceCompensationMeasure(enAxisIndex)


        Catch ae As ApplicationException
            DisplayError("btnCompMeasureAdd_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnCompMeasureAdd_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnCompMeasureAdd_Click", ex.ToString)
        End Try
    End Sub

#End Region

#Region "PLC I/O"
    Private Sub btnGetBit_Click(sender As System.Object, e As System.EventArgs) Handles btnGetBit.Click
        Try
            Dim enValue As IOTypeEnum
            enValue = cboPLCBit.SelectedValue

            txtPLCBitData.Text = m_objIO.GetBitIO(enValue, CInt(txtPLCBitAddress.Text), CInt(txtPLCBit.Text)).ToString
        Catch ae As ApplicationException
            DisplayError("btnGetBit_Click", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("btnGetBit_Click", ne.Message)
        Catch ex As Exception
            DisplayError("btnGetBit_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnGetWord_Click(sender As System.Object, e As System.EventArgs) Handles btnGetWord.Click
        Try
            Dim enValue As IOTypeEnum
            enValue = cboPLCWord.SelectedValue

            txtPLCWordData.Text = m_objIO.GetWordIO(enValue, CInt(txtPLCWordAddress.Text)).ToString
        Catch ae As ApplicationException
            DisplayError("btnGetWord_Click", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("btnGetWord_Click", ne.Message)
        Catch ex As Exception
            DisplayError("btnGetWord_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnGetLongWord_Click(sender As System.Object, e As System.EventArgs) Handles btnGetLongWord.Click
        Try
            Dim enValue As IOTypeEnum
            enValue = cboPLCLongWord.SelectedValue

            txtPLCLongWordData.Text = m_objIO.GetLongWordIO(enValue, CInt(txtPLCLongWordAddress.Text)).ToString
        Catch ae As ApplicationException
            DisplayError("btnGetLongWord_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnGetLongWord_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnGetLongWord_Click", ex.ToString)
        End Try
    End Sub

    Private Sub cmdIOGetBitByLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetBitByLabel.Click
        Try
            Dim objIOAddress As CIOAddress = New CIOAddress

            objIOAddress.Address = CInt(txtPLCBitAddress.Text)
            objIOAddress.Bit = CInt(txtPLCBit.Text)
            objIOAddress.IOType = cboPLCBit.SelectedValue
            objIOAddress.Size = IOAddressSizeEnum.Bit

            txtIOBitLabel.Text = m_objIO.GetLabel(objIOAddress)


        Catch ae As ApplicationException
            DisplayError("I/O Variables", ae.Message)
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub

    Private Sub cmdIOGetWordByLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetWordByLabel.Click
        Try
            Dim objIOAddress As CIOAddress = New CIOAddress

            objIOAddress.Address = CInt(txtPLCWordAddress.Text)
            objIOAddress.Bit = 0
            objIOAddress.IOType = cboPLCWord.SelectedValue
            objIOAddress.Size = IOAddressSizeEnum.Word

            txtIOWordLabel.Text = m_objIO.GetLabel(objIOAddress)


        Catch ae As ApplicationException
            DisplayError("I/O Variables", ae.Message)
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub

    Private Sub cmdIOGetLongWordByLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIOGetLongWordByLabel.Click
        Try
            Dim objIOAddress As CIOAddress = New CIOAddress

            objIOAddress.Address = CInt(txtPLCLongWordAddress.Text)
            objIOAddress.Bit = 0
            objIOAddress.IOType = cboPLCLongWord.SelectedValue
            objIOAddress.Size = IOAddressSizeEnum.DWord

            txtIOLongWordLabel.Text = m_objIO.GetLabel(objIOAddress)


        Catch ae As ApplicationException
            DisplayError("I/O Variables", ae.Message)
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub

    Private Sub btnGetIOLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetIOLabel.Click
        Try
            Dim objIOAddress As CIOAddress

            txtPLCBitAddress.Text = ""
            txtPLCBit.Text = ""
            txtPLCBitData.Text = ""
            txtPLCWordData.Text = ""
            txtPLCWordAddress.Text = ""
            txtPLCLongWordAddress.Text = ""
            txtPLCLongWordData.Text = ""

            objIOAddress = m_objIO.GetIO(txtIOLabel.Text)

            Dim t As Threading.Thread

            t = New Threading.Thread(AddressOf GetIOThread)
            t.SetApartmentState(Threading.ApartmentState.STA)

            t.Start()

            cboIOVariableTypes.SelectedIndex = objIOAddress.IOType

            Select Case objIOAddress.Size
                Case IOAddressSizeEnum.Bit
                    txtPLCBitAddress.Text = objIOAddress.Address
                    txtPLCBit.Text = objIOAddress.Bit
                    txtPLCBitData.Text = objIOAddress.Value

                Case IOAddressSizeEnum.Word
                    txtPLCWordAddress.Text = objIOAddress.Address
                    txtPLCWordData.Text = objIOAddress.Value

                Case IOAddressSizeEnum.DWord
                    txtPLCLongWordAddress.Text = objIOAddress.Address
                    txtPLCLongWordData.Text = objIOAddress.Value

                Case Else
                    DisplayError("I/O Variables", "Not found")
            End Select

        Catch ae As ApplicationException
            DisplayError("I/O Variables", ae.Message)
        Catch ex As Exception
            DisplayError("I/O Variables", ex.Message)
        End Try
    End Sub

    Private Sub GetIOThread()
        Try
            m_objIOAddress = m_objIO.GetIO("ipNTS_B")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

#End Region

#If GU_FUNCTIONS Then
#Region "G Operations"
    Private Sub btnGetGBit_Click(sender As System.Object, e As System.EventArgs) Handles btnGetGBit.Click
        Try
            txtGBitData.Text = m_objIO.GetGBit(CInt(txtGBitAddress.Text), CInt(txtGBit.Text)).ToString
        Catch ae As ApplicationException
            DisplayError("btnGetGBit_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnGetGBit_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnGetGBit_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnSetGBit_Click(sender As System.Object, e As System.EventArgs) Handles btnSetGBit.Click
        Try
            m_objIO.SetGBit(CInt(txtGBitAddress.Text), CInt(txtGBit.Text), CInt(txtGBitValue.Text))
            txtGBitData.Text = m_objIO.GetGBit(CInt(txtGBitAddress.Text), CInt(txtGBit.Text)).ToString
        Catch ae As ApplicationException
            DisplayError("btnSetGBit_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnSetGBit_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnSetGBit_Click", ex.ToString)
        End Try
    End Sub


    Private Sub btnGetGWord_Click(sender As System.Object, e As System.EventArgs) Handles btnGetGWord.Click
        Try
            txtGWordData.Text = m_objIO.GetGWord(CInt(txtGWordAddress.Text)).ToString
        Catch ae As ApplicationException
            DisplayError("btnGetGWord_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnGetGWord_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnGetGWord_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnSetGWord_Click(sender As System.Object, e As System.EventArgs) Handles btnSetGWord.Click
        Try
            m_objIO.SetGWord(CInt(txtGWordAddress.Text), CInt(txtGWordValue.Text))
            txtGWordData.Text = m_objIO.GetGWord(CInt(txtGWordAddress.Text)).ToString
        Catch ae As ApplicationException
            DisplayError("btnSetGWord_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnSetGWord_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnSetGWord_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnGetGLongWord_Click(sender As System.Object, e As System.EventArgs) Handles btnGetGLongWord.Click
        Try
            txtGLongWordData.Text = m_objIO.GetGLongWord(CInt(txtGLongWordAddress.Text)).ToString
        Catch ae As ApplicationException
            DisplayError("btnGetGLongWord_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnGetGLongWord_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnGetGLongWord_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnSetGLongWord_Click(sender As System.Object, e As System.EventArgs) Handles btnSetGLongWord.Click
        Try
            m_objIO.SetGLongWord(CInt(txtGLongWordAddress.Text), CLng(txtGLongWordValue.Text))
            txtGLongWordData.Text = m_objIO.GetGLongWord(CInt(txtGLongWordAddress.Text)).ToString

        Catch ae As ApplicationException
            DisplayError("btnSetGLongWord_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnSetGLongWord_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnSetGLongWord_Click", ex.ToString)
        End Try
    End Sub
#End Region

#Region "U Operations"
    Private Sub btnGetUBit_Click(sender As System.Object, e As System.EventArgs) Handles btnGetUBit.Click
        Try
            txtUBitData.Text = m_objIO.GetUBit(CInt(txtUBitAddress.Text), CInt(txtUBit.Text)).ToString
        Catch ae As ApplicationException
            DisplayError("btnGetUBit_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnGetUBit_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnGetUBit_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnSetUBit_Click(sender As System.Object, e As System.EventArgs) Handles btnSetUBit.Click
        Try
            m_objIO.SetUBit(CInt(txtUBitAddress.Text), CInt(txtUBit.Text), CInt(txtUBitValue.Text))
        Catch ae As ApplicationException
            DisplayError("btnSetUBit_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnSetUBit_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnSetUBit_Click", ex.ToString)
        End Try
    End Sub


    Private Sub btnGetUWord_Click(sender As System.Object, e As System.EventArgs) Handles btnGetUWord.Click
        Try
            txtUWordData.Text = m_objIO.GetUWord(CInt(txtUWordAddress.Text)).ToString
        Catch ae As ApplicationException
            DisplayError("btnGetUWord_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnGetUWord_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnGetUWord_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnSetUWord_Click(sender As System.Object, e As System.EventArgs) Handles btnSetUWord.Click
        Try
            m_objIO.SetUWord(CInt(txtUWordAddress.Text), CInt(txtUWordValue.Text))
        Catch ae As ApplicationException
            DisplayError("btnSetUWord_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnSetUWord_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnSetUWord_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnGetULongWord_Click(sender As System.Object, e As System.EventArgs) Handles btnGetULongWord.Click
        Try
            txtULongWordData.Text = m_objIO.GetULongWord(CInt(txtULongWordAddress.Text)).ToString
        Catch ae As ApplicationException
            DisplayError("btnGetULongWord_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnGetULongWord_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnGetULongWord_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnSetULongWord_Click(sender As System.Object, e As System.EventArgs) Handles btnSetULongWord.Click
        Try
            m_objIO.SetULongWord(CInt(txtULongWordAddress.Text), CLng(txtULongWordValue.Text))
        Catch ae As ApplicationException
            DisplayError("btnSetULongWord_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnSetULongWord_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnSetULongWord_Click", ex.ToString)
        End Try
    End Sub
#End Region
#End If


#Region "CVariables"

    Private Sub btnCommonVariableUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnCommonVariableUpdate.Click
        Try
            txtCommonVariableData.Text = m_objVariables.GetCommonVariableValue(CInt(Me.txtCommonVariable.Text))
            txtCommonVariablesCount.Text = m_objVariables.GetCommonVariableCount

        Catch ae As ApplicationException
            DisplayError("btnCommonVariableUpdate_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnCommonVariableUpdate_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnCommonVariableUpdate_Click", ex.ToString)
        End Try
    End Sub
    Private Sub btnAddCommonVariables_Click(sender As System.Object, e As System.EventArgs) Handles btnAddCommonVariables.Click
        Try

            m_objVariables.AddCommonVariableValue(CInt(Me.txtCommonVariable.Text), CDbl(txtCommonVariableValue.Text))
            txtCommonVariableData.Text = m_objVariables.GetCommonVariableValue(CInt(Me.txtCommonVariable.Text))

        Catch ae As ApplicationException
            DisplayError("btnAddCommonVariables_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnAddCommonVariables_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnAddCommonVariables_Click", ex.ToString)
        End Try
    End Sub
    Private Sub btnSetCommonVariables_Click(sender As System.Object, e As System.EventArgs) Handles btnSetCommonVariables.Click
        Try
            m_objVariables.SetCommonVariableValue(CInt(Me.txtCommonVariable.Text), CDbl(txtCommonVariableValue.Text))
            txtCommonVariableData.Text = m_objVariables.GetCommonVariableValue(CInt(Me.txtCommonVariable.Text))

        Catch ae As ApplicationException
            DisplayError("btnSetCommonVariables_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnSetCommonVariables_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnSetCommonVariables_Click", ex.ToString)
        End Try
    End Sub
    Private Sub btnGetCommonVariable_Click(sender As System.Object, e As System.EventArgs) Handles btnGetCommonVariable.Click
        Try
            txtCommonVariableData.Text = m_objVariables.GetCommonVariableValue(CInt(Me.txtCommonVariable.Text))

        Catch ae As ApplicationException
            DisplayError("btnGetCommonVariable_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnGetCommonVariable_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnGetCommonVariable_Click", ex.ToString)
        End Try
    End Sub
    Private Sub btnGetCommonVariables_Click(sender As System.Object, e As System.EventArgs) Handles btnGetCommonVariables.Click
        Try
            Dim strValues As New StringBuilder
            Dim dblValue As Double
            Dim arValues() As Double
            Dim intStartingIndex As Integer
            Dim intEndingIndex As Integer
            Dim intIndex As Integer

            intStartingIndex = CInt(txtCommonVariableStartingIndex.Text)
            intEndingIndex = CInt(txtCommonVariableEndingIndex.Text)

            arValues = m_objVariables.GetCommonVariableValues(intStartingIndex, intEndingIndex)

            intIndex = intStartingIndex

            For Each dblValue In arValues
                strValues.Append(String.Format("Index {0}: {1}" + vbCrLf, intIndex.ToString, dblValue))
                intIndex = intIndex + 1
            Next

            txtCommonVarialbesData.Text = strValues.ToString

        Catch ae As ApplicationException
            DisplayError("btnGetCommonVariables_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnGetCommonVariables_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnGetCommonVariables_Click", ex.ToString)
        End Try
    End Sub

#End Region

#Region "MacMan - Machining Reports"
    Private Sub btnMacManMachiningReportUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnMacManMachiningReportUpdate.Click

        Try

            Dim objMachining As MacMan.CMachining
            Dim enReport As ReportPeriodEnum
            Dim intReportIndex As Int16

            enReport = cboMachiningReportType.SelectedItem
            intReportIndex = CInt(txtMacManReportIndex.Text)
            objMachining = m_objMachiningReport.GetMachiningReport(intReportIndex, enReport)

            txtMachiningReportCount.Text = m_objMachiningReport.GetCount(enReport)
            txtMachiningReportMaxCount.Text = m_objMachiningReport.GetMaxCount(enReport)

            txtMachiningReportStartTime.Text = objMachining.StartTime
            Me.txtMachiningReportStartDate.Text = objMachining.StartDate

            txtMachiningReportCuttingTime.Text = objMachining.CuttingTime
            txtMachiningReportOperatingTime.Text = objMachining.OperatingTime
            Me.txtMachiningReportRunningTime.Text = objMachining.RunningTime
            txtMachiningReportProgramName.Text = objMachining.MainProgramFileName
            txtMachiningReportMainProgram.Text = objMachining.MainProgramName
            txtMachiningReportNoOfWork.Text = objMachining.NumberOfWork

        Catch ae As ApplicationException
            DisplayError("btnMacManMachiningReportUpdate_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnMacManMachiningReportUpdate_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnMacManMachiningReportUpdate_Click", ex.ToString)
        End Try

    End Sub

    Private Sub btnMacManMachiningReportUpdates_Click(sender As System.Object, e As System.EventArgs) Handles btnMacManMachiningReportUpdates.Click
        Dim enReport As ReportPeriodEnum
        Dim intReportStartIndex As Int16
        Dim intReportEndIndex As Int16


        Dim arMachining As ArrayList

        Try
            enReport = cboMachiningReportType.SelectedItem
            intReportStartIndex = CInt(txtMachiningReportFromIndex.Text)
            intReportEndIndex = CInt(txtMachiningReportToIndex.Text)
            arMachining = m_objMachiningReport.GetMachiningReports(intReportStartIndex, intReportEndIndex, enReport)


            grdMachiningReports.DataSource = arMachining
            grdMachiningReports.Refresh()


        Catch ae As ApplicationException
            DisplayError("btnMacManMachiningReportUpdates_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnMacManMachiningReportUpdates_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnMacManMachiningReportUpdates_Click", ex.ToString)
        End Try
    End Sub
#End Region

#Region "MacMan - Operation History"
    Private Sub btnOperationHistoryUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnOperationHistoryUpdate.Click
        Try
            Dim opIndex As Int16
            Dim objOperationHisotry As DataApi.MacMan.COperation

            opIndex = CInt(txtOperationHistoryIndex.Text)

            objOperationHisotry = m_objOperationHistory.GetOperationHistory(opIndex)

            txtOperationHistoryData.Text = objOperationHisotry.Data
            txtOperationHistoryDate.Text = objOperationHisotry.Date
            txtOperationHistoryTime.Text = objOperationHisotry.Time
            txtOperationHistoryCount.Text = m_objOperationHistory.GetCount
            txtOperationHistoryMaxCount.Text = m_objOperationHistory.GetMaxCount
        Catch ae As ApplicationException
            DisplayError("btnOperationHistoryUpdate_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnOperationHistoryUpdate_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnOperationHistoryUpdate_Click", ex.ToString)
        End Try

    End Sub
    Private Sub btnOperationHistoryUpdates_Click(sender As System.Object, e As System.EventArgs) Handles btnOperationHistoryUpdates.Click
        Dim objOperation As DataApi.MacMan.COperation
        Dim arOperations As ArrayList

        Try
            lstOperationHistory.Items.Clear()
            arOperations = m_objOperationHistory.GetOperationHistory(CInt(txtOperationHistoryFromIndex.Text), CInt(txtOperationHistoryToIndex.Text))
            For Each objOperation In arOperations
                lstOperationHistory.Items.Add(objOperation.Date & vbTab & objOperation.Time & vbTab & objOperation.Data)
            Next
        Catch ae As ApplicationException
            DisplayError("btnOperationHistoryUpdates_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnOperationHistoryUpdates_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnOperationHistoryUpdates_Click", ex.ToString)
        End Try

    End Sub
#End Region

#Region "MacMan - Operating Report"
    Private Sub btnOperatingReportUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnOperatingReportUpdate.Click
        Try

            Me.txtDateOfOperatingReport.Text = m_objOperatingReport.GetTodayOperatingReportDate()
            Me.txtMaxNoOfOpReport.Text = m_objOperatingReport.GetMaxCount()

            Me.txtOperatingTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.OperatingTime)
            Me.txtRunningTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.RunningTime)
            Me.txtCuttingTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.CuttingTime)
            Me.txtNonOPeratingTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.NonOperatingTime)
            Me.txtInProSetupTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.InProcessSetupTime)
            Me.txtNoOperatorTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.NoOperatorTime)
            Me.txtPartWaitingTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.PartWaitingTime)
            Me.txtmaintenanceTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.MaintenanceTime)
            Me.txtOtherTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.OtherTime)
            Me.txtSpindleRunTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.SpindleRunTime)
            Me.txtExternalInputTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.ExternalInputTime)
            Me.txtAlarmOnTime.Text = m_objOperatingReport.GetTodayOperatingReport(OperatingReportDataEnum.AlarmOnTime)

            Me.txtPrevDateOfOperatingRept.Text = m_objOperatingReport.GetPreviousOperatingReportDate()

            Me.txtPrevAlarmOnTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.AlarmOnTime)
            Me.txtPrevCuttingTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.CuttingTime)
            Me.txtPrevInProSetupTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.InProcessSetupTime)
            Me.txtPrevMaintenanceTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.MaintenanceTime)
            Me.txtPrevNonOperatingTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.NonOperatingTime)
            Me.txtPrevNoOperatorTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.NoOperatorTime)
            Me.txtPrevOperatingTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.OperatingTime)
            Me.txtPrevOtherTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.OtherTime)
            Me.txtPrevPartwaitingTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.PartWaitingTime)
            Me.txtPrevRunningTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.RunningTime)
            Me.txtPrevSpindleRunTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.SpindleRunTime)
            Me.txtPrevExternalInputTime.Text = m_objOperatingReport.GetPreviousOperatingReport(OperatingReportDataEnum.ExternalInputTime)


            Me.txtPeriodDateOfOperatingReport.Text = m_objOperatingReport.GetPeriodOperatingReportDate()

            Me.txtPeriodAlarmOnTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.AlarmOnTime)
            Me.txtPeriodCuttingTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.CuttingTime)
            Me.txtPeriodExternalInputTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.ExternalInputTime)
            Me.txtPeriodInproSetupTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.InProcessSetupTime)
            Me.txtPeriodMaintenanceTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.MaintenanceTime)
            Me.txtPeriodNonOperatingTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.NonOperatingTime)
            Me.txtPeriodNoOperatorTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.NoOperatorTime)
            Me.txtPeriodOperatingTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.OperatingTime)
            Me.txtPeriodOtherTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.OtherTime)
            Me.txtPeriodPartWaitingTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.PartWaitingTime)
            Me.txtPeriodRunningTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.RunningTime)
            Me.txtPeriodSpindleRunTime.Text = m_objOperatingReport.GetPeriodOperatingReport(OperatingReportDataEnum.SpindleRunTime)

        Catch ae As ApplicationException
            DisplayError("btnOperatingReportUpdate_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnOperatingReportUpdate_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnOperatingReportUpdate_Click", ex.ToString)
        End Try
    End Sub
#End Region

#Region "MacMan - Operating History"
    Private Sub btnAlarmHistoryUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnAlarmHistoryUpdate.Click
        Try
            Dim intAlarmIndex As Integer
            Dim objAlarm As DataApi.MacMan.CAlarm
            intAlarmIndex = CInt(Me.txtAlarmIndex.Text)
            objAlarm = m_objAlarmHistory.GetAlarm(intAlarmIndex)

            Me.txtAlarmCode.Text = objAlarm.Code
            Me.txtAlarmDate.Text = objAlarm.Date
            Me.txtAlarmMessage.Text = objAlarm.Message
            Me.txtAlarmNumber.Text = objAlarm.Number
            Me.txtAlarmTime.Text = objAlarm.Time
            Me.txtAlarmObject.Text = objAlarm.Object

            Me.txtMaxAlarmCount.Text = m_objAlarmHistory.GetMaxCount
            Me.txtAlarmCount.Text = m_objAlarmHistory.GetCount

        Catch ae As ApplicationException
            DisplayError("btnAlarmHistoryUpdate_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnAlarmHistoryUpdate_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnAlarmHistoryUpdate_Click", ex.ToString)
        End Try


    End Sub
    Private Sub btnAlarmHistoryUpdates_Click(sender As System.Object, e As System.EventArgs) Handles btnAlarmHistoryUpdates.Click
        Dim objAlarm As DataApi.MacMan.CAlarm
        Dim arAlarms As ArrayList
        Dim intIndex As Integer

        Try
            arAlarms = m_objAlarmHistory.GetAlarms(CInt(Me.txtAlarmHistoryFromIndex.Text), CInt(Me.txtAlarmHistoryEndIndex.Text))
            intIndex = CInt(Me.txtAlarmHistoryFromIndex.Text)
            For Each objAlarm In arAlarms
                lstAlarms.Items.Add(intIndex.ToString & vbTab & objAlarm.Date & vbTab & objAlarm.Time & vbTab & objAlarm.Number & vbTab & objAlarm.Object & vbTab & objAlarm.Code & vbTab & objAlarm.Message)
                intIndex = intIndex + 1
            Next

        Catch ae As ApplicationException
            DisplayError("btnAlarmHistoryUpdates_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnAlarmHistoryUpdates_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnAlarmHistoryUpdates_Click", ex.ToString)
        End Try
    End Sub
#End Region

#Region "Spec"
    Private Sub btnGetNCSpec2_Click(sender As System.Object, e As System.EventArgs) Handles btnGetNCSpec2.Click
        Try
            txtNCSpec2.Text = m_objSpec.GetBSpecCode(CInt(txtNCSpec2AddressValue.Text), CInt(txtNCSpec2BitValue.Text)).ToString
        Catch ae As ApplicationException
            DisplayError("btnGetNCSpec2_Click", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("btnGetNCSpec2_Click", ne.Message)
        Catch ex As Exception
            DisplayError("btnGetNCSpec2_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnGetNCSpec_Click(sender As System.Object, e As System.EventArgs) Handles btnGetNCSpec.Click
        Try
            txtNCSpec.Text = m_objSpec.GetSpecCode(CInt(txtNCSpecAddressValue.Text), CInt(txtNCSpecBitValue.Text)).ToString
        Catch ae As ApplicationException
            DisplayError("btnGetNCSpec_Click", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("btnGetNCSpec_Click", ne.Message)
        Catch ex As Exception
            DisplayError("btnGetNCSpec_Click", ex.ToString)
        End Try
    End Sub

    Private Sub btnSpecUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnSpecUpdate.Click
        Try
            txtMachineName.Text = m_objSpec.GetMachineName()
            txtMachineSerial.Text = m_objSpec.GetMachineSerialNumber()

            txtOSPControlType.Text = System.Enum.GetName(GetType(ControlTypeEnum), m_objSpec.GetControlType())

        Catch ae As ApplicationException
            DisplayError("btnSpecUpdate_Click", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("btnSpecUpdate_Click", ne.Message)
        Catch ex As Exception
            DisplayError("btnSpecUpdate_Click", ex.ToString)
        End Try
    End Sub

#End Region

#Region "MacMan - Operating History"
    Private Sub btnMacManOperatingHistoryUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnMacManOperatingHistoryUpdate.Click
        Try

            txtMacManOperatingHistoryAlarmOnTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.AlarmOnTime))
            txtMacManOperatingHistoryCuttingTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.CuttingTime))
            txtMacManOperatingHistoryExternalInputTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.ExternalInputTime))
            txtMacManOperatingHistoryInProSetupTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.InProcessSetupTime))
            txtMacManOperatingHistoryMaintenanceTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.MaintenanceTime))
            txtMacManOperatingHistoryNonOperatingReport.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.NonOperatingTime))
            txtMacManOperatingHistoryNoOperatorTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.NoOperatorTime))
            txtMacManOperatingHistoryOperatingTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.OperatingTime))
            txtMacManOperatingHistoryOtherTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.OtherTime))
            txtMacManOperatingHistoryPartWaitingTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.PartWaitingTime))
            txtMacManOperatingHistoryRunningTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.RunningTime))
            txtMacManOperatingHistorySpindleRunTime.Text = ArrayToString(m_objOperatingHistory.GetTodayOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.SpindleRunTime))

            txtMacManOperatingHistoryPrevAlarmonTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.AlarmOnTime))
            txtMacManOperatingHistoryPrevCuttingTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.CuttingTime))
            txtMacManOperatingHistoryPrevExternalInputTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.ExternalInputTime))
            txtMacManOperatingHistoryPrevInProSetupTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.InProcessSetupTime))
            txtMacManOperatingHistoryPrevMaintenanceTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.MaintenanceTime))
            txtMacManOperatingHistoryPrevNonOperatingTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.NonOperatingTime))
            txtMacManOperatingHistoryPrevNoOperatorTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.NoOperatorTime))
            txtMacManOperatingHistoryPrevOperatingTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.OperatingTime))
            txtMacManOperatingHistoryPrevOtherTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.OtherTime))
            txtMacManOperatingHistoryPrevPartWaitingTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.PartWaitingTime))
            txtMacManOperatingHistoryPrevRunningTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.RunningTime))
            txtMacManOperatingHistoryPrevSpindleRunTime.Text = ArrayToString(m_objOperatingHistory.GetPreviousOperatingHistory(CInt(Me.txtMacManOperatingHistoryFromIndex.Text), CInt(Me.txtMacManOperatingHistoryToIndex.Text), OperatingReportDataEnum.SpindleRunTime))

            txtMacManOperatingHistoryMaxCount.Text = m_objOperatingHistory.GetMaxCount()
        Catch ae As ApplicationException
            DisplayError("btnMacManOperatingHistoryUpdate_Click", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("btnMacManOperatingHistoryUpdate_Click", ne.Message)
        Catch ex As Exception
            DisplayError("btnMacManOperatingHistoryUpdate_Click", ex.ToString)
        End Try




    End Sub
#End Region
#If LOADER_FUNCTIONS Then
#Region "Loader"
    Private Sub btnRegisterDataGet_Click(sender As System.Object, e As System.EventArgs) Handles btnRegisterDataGet.Click
        Try
            txtRegisterData.Text = m_objLoader.GetRegisterData(CInt(txtRegisterDataIndex.Text)).ToString
        Catch ae As ApplicationException
            DisplayError("btnRegisterDataGet_Click", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("btnRegisterDataGet_Click", ne.Message)
        Catch ex As Exception
            DisplayError("btnRegisterDataGet_Click", ex.ToString)
        End Try
    End Sub
    Private Sub btnPointDataGet_Click(sender As System.Object, e As System.EventArgs) Handles btnPointDataGet.Click
        Try
            txtPointData.Text = m_objLoader.GetPointData(CInt(txtPointDataIndex.Text), cboLoaderAxisPointData.SelectedValue).ToString
        Catch ae As ApplicationException
            DisplayError("btnPointDataGet_Click", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("btnPointDataGet_Click", ne.Message)
        Catch ex As Exception
            DisplayError("btnPointDataGet_Click", ex.ToString)
        End Try
    End Sub
    Private Sub btnPointDataSet_Click(sender As System.Object, e As System.EventArgs) Handles btnPointDataSet.Click
        Try
            m_objLoader.SetPointData(CInt(txtPointDataIndex.Text), cboLoaderAxisPointData.SelectedValue, CDbl(txtPointDataValue.Text))
            txtPointData.Text = m_objLoader.GetPointData(CInt(txtPointDataIndex.Text), cboLoaderAxisPointData.SelectedValue).ToString

        Catch ae As ApplicationException
            DisplayError("btnPointDataSet_Click", ae.Message)
        Catch ex As NotSupportedException
            DisplayError("btnPointDataSet_Click", ex.Message)
        Catch ex As Exception
            DisplayError("btnPointDataSet_Click", ex.ToString)
        End Try
    End Sub
    Private Sub btnRegisterDataSet_Click(sender As System.Object, e As System.EventArgs) Handles btnRegisterDataSet.Click
        Try
            m_objLoader.SetRegisterData(CInt(txtRegisterDataIndex.Text), CInt(txtRegisterDataValue.Text))
            txtRegisterData.Text = m_objLoader.GetRegisterData(CInt(txtRegisterDataIndex.Text)).ToString

        Catch ae As ApplicationException
            DisplayError("btnRegisterDataSet_Click", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("btnRegisterDataSet_Click", ne.Message)
        Catch ex As Exception
            DisplayError("btnRegisterDataSet_Click", ex.ToString)
        End Try
    End Sub
    Private Sub btnPointDataAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnPointDataAdd.Click
        Try
            m_objLoader.AddPointData(CInt(txtPointDataIndex.Text), cboLoaderAxisPointData.SelectedValue, CDbl(txtPointDataValue.Text))
            txtPointData.Text = m_objLoader.GetPointData(CInt(txtPointDataIndex.Text), cboLoaderAxisPointData.SelectedValue).ToString

        Catch ae As ApplicationException
            DisplayError("btnPointDataAdd_Click", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("btnPointDataAdd_Click", ne.Message)
        Catch ex As Exception
            DisplayError("btnPointDataAdd_Click", ex.ToString)
        End Try
    End Sub
    Private Sub btnRegisterDataAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnRegisterDataAdd.Click
        Try
            m_objLoader.AddRegisterData(CInt(txtRegisterDataIndex.Text), CInt(txtRegisterDataValue.Text))
            txtRegisterData.Text = m_objLoader.GetRegisterData(CInt(txtRegisterDataIndex.Text)).ToString

        Catch ae As ApplicationException
            DisplayError("btnRegisterDataSet_Click", ae.Message)
        Catch ne As NotSupportedException
            DisplayError("btnRegisterDataSet_Click", ne.Message)
        Catch ex As Exception
            DisplayError("btnRegisterDataSet_Click", ex.ToString)
        End Try
    End Sub
#End Region

#End If


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.



    End Sub

#Region " Logging Service"
    Private Sub btnDisplayLogRecords_Click(sender As System.Object, e As System.EventArgs) Handles btnDisplayLogRecords.Click
        Dim lstRecords As List(Of CLogRecord)
        Dim objApiLog As Okuma.ApiLog2.CApiLog
        objApiLog = New Okuma.ApiLog2.CApiLog

        Dim strAppName As String
        Dim strClassName As String
        Dim strMethodName As String
        Dim strParameters As String
        Dim strMessage As String
        Dim enLoggingLevel As LoggingLevelEnum = LoggingLevelEnum.logAll

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
#End Region

    Private Sub cboAllLoggignLevel_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAllLoggignLevel.SelectedIndexChanged
        Dim enLoggigngLevel As LoggingLevelEnum

        enLoggigngLevel = cboAllLoggignLevel.SelectedItem

        Select Case enLoggigngLevel
            Case LoggingLevelEnum.logAll
                SetLoggingLevelAll()
            Case LoggingLevelEnum.logGet
                SetLoggingLevelGet()
            Case LoggingLevelEnum.logSet
                SetLoggingLevelSet()
            Case Else
                SetLoggingLevelSet()
        End Select
    End Sub

    Private Sub SetLoggingLevelAll()
        m_objAxis.SetLoggingLevelToAll()
        m_objSpindle.SetLoggingLevelToAll()
        m_objProgram.SetLoggingLevelToAll()
        m_objWheel.SetLoggingLevelToAll()
        m_objTools.SetLoggingLevelToAll()
        m_objWorkpiece.SetLoggingLevelToAll()
        m_objSpec.SetLoggingLevelToAll()
        m_objIO.SetLoggingLevelToAll()
        m_objVariables.SetLoggingLevelToAll()
        'm_objLoader = Nothing

        m_objCmdProgram.SetLoggingLevelToAll()


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
        m_objWheel.SetLoggingLevelToGet()
        m_objTools.SetLoggingLevelToGet()
        m_objWorkpiece.SetLoggingLevelToGet()
        m_objSpec.SetLoggingLevelToGet()
        m_objIO.SetLoggingLevelToGet()
        m_objVariables.SetLoggingLevelToGet()

        m_objCmdProgram.SetLoggingLevelToGet()


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
        m_objWheel.SetLoggingLevelToSet()
        m_objTools.SetLoggingLevelToSet()
        m_objWorkpiece.SetLoggingLevelToSet()
        m_objSpec.SetLoggingLevelToSet()
        m_objIO.SetLoggingLevelToSet()
        m_objVariables.SetLoggingLevelToSet()
        'm_objLoader = Nothing

        m_objCmdProgram.SetLoggingLevelToSet()


        m_objOperationHistory.SetLoggingLevelToSet()
        m_objMachiningReport.SetLoggingLevelToSet()
        m_objOperatingReport.SetLoggingLevelToSet()
        m_objAlarmHistory.SetLoggingLevelToSet()
        m_objOperatingHistory.SetLoggingLevelToSet()

        m_objMachine.SetLoggingLevelToSet()
    End Sub

End Class
