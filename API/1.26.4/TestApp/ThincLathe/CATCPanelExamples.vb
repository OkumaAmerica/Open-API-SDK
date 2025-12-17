Imports Okuma.CLCMDAPI.Enumerations
Imports Okuma.CLDATAPI.Enumerations

Public Class CATCPanelExamples


#Region "CATCPanel Examples"
    Public Shared Function GetATCPanelInfo(ByVal intPotNo As Integer, ByVal intToolNo As Integer, ByVal intLocationNo As Integer, ByVal enATCToolLocation As ATCToolLocationEnum) As String

        Dim strValues As String = ""
        Dim sToolSetupInfo As Okuma.CLDATAPI.Structures.ATCPanelToolSetupInfo
        Dim sToolPot As Okuma.CLDATAPI.Structures.ToolPotProperty
        Dim sSettableToolAttributes As Okuma.CLDATAPI.Structures.SettableToolAttributes
        sToolPot = m_objATC.GetToolPot(intToolNo)

        sToolSetupInfo = m_objATC.GetATCPanelToolSetupInfo()
        sSettableToolAttributes = m_objATC.GetSettableToolAttributes(intPotNo)

        strValues = strValues + String.Format("Get ATC Executing state = {0}" & vbCrLf, m_objATC.GetATCExecutingState())
        strValues = strValues + String.Format("Get ATC Panel CHIP Preparation Mode = {0}" & vbCrLf, m_objATC.GetATCPanelChipPreparationMode())
        strValues = strValues + String.Format("Get ATC Panel Error Code = {0}" & vbCrLf, m_objATC.GetATCPanelErrorCode())
        strValues = strValues + String.Format("Get ATC Panel Index number = {0} " & vbCrLf, m_objATC.GetATCPanelIndexNumber())
        strValues = strValues + String.Format("Get ATC Panel Magazine Manual Interrupt Mode = {0} " & vbCrLf, m_objATC.GetATCPanelMagazineManualInterruptMode())
        strValues = strValues + String.Format("Get ATC Panel Operation Mode = {0}" & vbCrLf, m_objATC.GetATCPanelOperationMode())
        strValues = strValues + String.Format("Get ATC Panel Tool Setup Info: Tool/Serial No. = {0}, Group No. = {1}, Kind = {2}, Size = {3} " & vbCrLf, sToolSetupInfo.intToolSerialNo, sToolSetupInfo.intGroupNo, sToolSetupInfo.enToolKind, sToolSetupInfo.enToolSize)
        strValues = strValues + String.Format("Get ATC Panel Sequence Number = {0}" & vbCrLf, m_objATC.GetATCPanelSequenceNumber())
        strValues = strValues + String.Format("Get ATC Panel Usage state of shared stations = {0}" & vbCrLf, m_objATC.GetUsageStateOfSharedStation())
        strValues = strValues + String.Format("Get ATC Tool Pot for tool number {0}: Tool/Pot = {1}, Location= {2}" & vbCrLf, intToolNo, sToolPot.intPotNo, sToolPot.enToolLocation)
        strValues = strValues + String.Format("Get ATC Tool Number by location number {0} and ATC Tool Location {1}, Tool Number = {2}" & vbCrLf, intLocationNo, enATCToolLocation, m_objATC.GetToolNo(intLocationNo, enATCToolLocation))
        strValues = strValues + String.Format("Get settable tool kind attribute by pot number {0}: DummyTool = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolKinds.DummyTool)
        strValues = strValues + String.Format("Get settable tool kind attribute by pot number {0}: GrindingTool = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolKinds.GrindingTool)
        strValues = strValues + String.Format("Get settable tool kind attribute by pot number {0}: LMDNozzle = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolKinds.LMDNozzle)
        strValues = strValues + String.Format("Get settable tool kind attribute by pot number {0}: LTool = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolKinds.LTool)
        strValues = strValues + String.Format("Get settable tool kind attribute by pot number {0}: MTool = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolKinds.MTool)
        strValues = strValues + String.Format("Get settable tool kind attribute by pot number {0}: SensorTool = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolKinds.SensorTool)
        strValues = strValues + String.Format("Get settable tool size attribute by pot number {0}: B_Tool = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolSizes.B_Tool)
        strValues = strValues + String.Format("Get settable tool size attribute by pot number {0}: BR_Tool = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolSizes.BR_Tool)
        strValues = strValues + String.Format("Get settable tool size attribute by pot number {0}: E_Tool = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolSizes.E_Tool)
        strValues = strValues + String.Format("Get settable tool size attribute by pot number {0}: H_Tool = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolSizes.H_Tool)
        strValues = strValues + String.Format("Get settable tool size attribute by pot number {0}: ME_Tool = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolSizes.ME_Tool)
        strValues = strValues + String.Format("Get settable tool size attribute by pot number {0}: ML_Tool = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolSizes.ML_Tool)
        strValues = strValues + String.Format("Get settable tool size attribute by pot number {0}: MR_Tool = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolSizes.MR_Tool)
        strValues = strValues + String.Format("Get settable tool size attribute by pot number {0}: SL_Tool = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolSizes.SL_Tool)
        strValues = strValues + String.Format("Get settable tool size attribute by pot number {0}: Standard = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolSizes.Standard)
        strValues = strValues + String.Format("Get settable tool size attribute by pot number {0}: SpecialTool  = {1}" & vbCrLf, intPotNo, sSettableToolAttributes.SettableToolSizes.SpecialTool)


        Return strValues

    End Function

    ''' <summary>
    ''' Call Tool using CHIP PREP mode ON
    ''' </summary>
    ''' <remarks>
    ''' Chip preparation mode:
    ''' This mode allows you to perform the following operation sequences:
    ''' 1/ call the tool mounted in the tool rack to the tool setup,
    ''' 2/ clean and change the chip, and
    ''' 3/ store the tool back to the original tool rack.
    ''' </remarks>
    Public Shared Sub CallToolByPotWithChipPreparationModeOn(ByVal intPotNo As Integer)
        Try
            'Check CHIP Preparation mode
            If m_objATC.GetATCPanelChipPreparationMode = Okuma.CLDATAPI.Enumerations.OnOffStateEnum.OFF Then
                SetATCPanelChipPreparationMode(Okuma.CLCMDAPI.Enumerations.OnOffStateEnum.ON)
            End If

            '1/ call the tool mounted in the tool rack to the tool setup,
            CallTool(intPotNo)

            '2/ Manually clean and change the chip

            '3/ store the tool back to the original tool rack. 
            StoreTool()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    ''' <summary>
    ''' Call Tool using CHIP PREP mode ON
    ''' </summary>
    ''' <remarks>
    ''' Chip preparation mode:
    ''' This mode allows you to perform the following operation sequences:
    ''' 1/ call the tool mounted in the tool rack to the tool setup,
    ''' 2/ clean and change the chip, and
    ''' 3/ store the tool back to the original tool rack.
    ''' </remarks>
    Public Shared Sub CallToolByToolNoWithChipPreparationModeOn(ByVal intToolNo As Integer)
        Try
            'Check CHIP Preparation mode
            If m_objATC.GetATCPanelChipPreparationMode = Okuma.CLDATAPI.Enumerations.OnOffStateEnum.OFF Then
                SetATCPanelChipPreparationMode(Okuma.CLCMDAPI.Enumerations.OnOffStateEnum.ON)
            End If

            '1/ call the tool mounted in the tool rack to the tool setup,
            CallTool(intToolNo, 0)

            '2/ Manually clean and change the chip

            '3/ store the tool back to the original tool rack. 
            StoreTool()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    ''' <summary>
    ''' Store tool in Setup location using CHIP PREP mode OFF and TOOL-ID spec OFF
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StoreSetupToolWithChipPreparationModeOff(ByVal intPotNo As Integer, ByVal intToolNo As Integer, ByVal enToolKind As SettingToolKindEnum, ByVal enToolSize As SettingToolSizeEnum)
        Try
            'Check TOOL-ID spec
            If m_objSpec.GetSpecCode(32, 6) = False Then
                StoreTool(intPotNo, intToolNo, enToolKind, enToolSize)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
        End Try
    End Sub

    ''' <summary>
    ''' Transfer a tool to Setup location given pot number.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub CallTool(ByVal intPotNo As Integer)
        m_objCmdATCPanel.CallTool(intPotNo)
    End Sub

    ''' <summary>
    ''' <para>Call tool by Tool number when Tool ID spec (32,6) is OFF .  Group number is zero in this case.</para>
    ''' <para>Call tool by Tool Serial number and Group number when Tool ID spec is ON</para>
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub CallTool(ByVal intToolSerialNo As Integer, ByVal intGroupNo As Integer)
        If m_objSpec.GetSpecCode(32, 6) = False Then
            m_objCmdATCPanel.CallTool(intToolSerialNo, 0)
        Else
            m_objCmdATCPanel.CallTool(intToolSerialNo, intGroupNo)
        End If
    End Sub

    ''' <summary>
    ''' Clear error on ATC Panel if any
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub ClearError()
        m_objCmdATCPanel.ClearError()
    End Sub

    ''' <summary>
    ''' Perform the following procedure to call (collect) the NG tool 
    ''' that has been returned to the NG tool
    ''' buffer station or magazine tool rack to the tool setup.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub CollectNGTools()
        m_objCmdATCPanel.CollectNGTools()
    End Sub

    ''' <summary>
    ''' Restart ATC operation
    ''' [How to use]
    ''' 1.	turn on the magazine MID AUTO MANUAL MODE
    ''' 2.	execute ATC command (ATC command stops)
    ''' 3.	turn off the MG MID AUTO MANUAL MODE
    ''' 4.	execute the function RestartATCOperations
    ''' </summary>
    ''' <remarks>
    ''' 1.	This function can be used only in the above [How to use].
    ''' 2.	This function does not support the magazine operation command.
    ''' </remarks>
    Public Shared Sub RestartATCOperations()
        m_objCmdATCPanel.RestartATCOperations()
    End Sub

    ''' <summary>
    ''' Set ATC Panel CHIP Preparation Mode 
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SetATCPanelChipPreparationMode(ByVal enValue As Okuma.CLCMDAPI.Enumerations.OnOffStateEnum)
        m_objCmdATCPanel.SetATCPanelChipPreparationMode(enValue)
    End Sub

    ''' <summary>
    ''' Set ATC Panel Magazine Interrupted mode 
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub SetATCPanelMagazineManualInterruptMode(ByVal enValue As Okuma.CLCMDAPI.Enumerations.OnOffStateEnum)
        m_objCmdATCPanel.SetATCPanelMagazineManualInterruptMode(enValue)
    End Sub

    ''' <summary>
    ''' The function will transfer tools currently in the temporary stations back to its designate pot
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StoreAllToolInTemporaryStations()
        m_objCmdATCPanel.StoreAllToolInTemporaryStations()
    End Sub

    ''' <summary>
    ''' For CHIP Preparation Mode ON:
    ''' The function will transfer tool back to its original pot
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StoreTool()
        If m_objATC.GetATCPanelChipPreparationMode = Okuma.CLDATAPI.Enumerations.OnOffStateEnum.ON Then
            m_objCmdATCPanel.StoreTool()
        Else
            MsgBox("CHIP Prep. Mode is not ON")
        End If
    End Sub

    ''' <summary>
    ''' When CHIP Preparation Mode is OFF or TOOL ID spec is OFF:
    ''' The function will transfer tool number from the Setup location to the specified pot number. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub StoreTool(ByVal intPotNo As Integer, ByVal intToolNo As Integer, ByVal enToolKind As SettingToolKindEnum, ByVal enToolSize As SettingToolSizeEnum)
        If m_objATC.GetATCPanelChipPreparationMode = Okuma.CLDATAPI.Enumerations.OnOffStateEnum.OFF Then
            m_objCmdATCPanel.StoreTool(intPotNo, intToolNo, enToolKind, enToolSize)
        Else
            MsgBox("CHIP Prep. Mode is not OFF")
        End If
    End Sub

    ''' <summary>
    ''' Set ATC Panel Operation Write mode ON/OFF
    ''' </summary>
    ''' <remarks>The setting of this parameter requires rebooting machine to be effective.</remarks>
    Public Shared Sub SetATCPanelOperationWriteMode(ByVal enValue As Okuma.CLDATAPI.Enumerations.OnOffStateEnum)
        'Enable/Disable ATC Panel 
        m_objOptionalParameter.SetNCOptionalParameterBit(77, 5, enValue)
    End Sub

#End Region

#Region "CATC.Load_AND_Save_Tool-Data"

    ''' <summary>
    ''' This sample will get a list of tools currently registered in the tool data table and save 
    ''' them into a folder.  It also restores all tools from the tool data files.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub LoadSaveTools()
        Dim strFolderPath As String = "D:\MD1\TOOL-DATA"
        Dim blnOverwrite As Boolean = True
        Dim arToolList() As Integer
        Dim objTools As Okuma.CLDATAPI.DataAPI.CTools = New Okuma.CLDATAPI.DataAPI.CTools

        Try
            arToolList = objTools.GetToolList(Okuma.CLDATAPI.Enumerations.ToolListTypeEnum.AllTools)

            'Save all tools data to the folder 
            SaveToolData(arToolList, strFolderPath, blnOverwrite)
            'Load all tools data from the foler
            LoadToolData(arToolList, strFolderPath, blnOverwrite)
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.ToString)
        End Try

    End Sub

    ''' <summary>
    ''' Load tool data from tool data files
    ''' </summary>
    ''' <param name="intToolNos">an array of tools to be loaded into NC</param>
    ''' <param name="strFolderPath">full path folder name where tool data files are stored</param>
    ''' <param name="blnOverwrite">Overwrite tool data if it is set to TRUE</param>
    ''' <remarks>Sample codes only. It does not detect all specifications of each machine</remarks>
    Public Shared Sub LoadToolData(ByRef intToolNos() As Integer, ByVal strFolderPath As String, ByVal blnOverwrite As Boolean)
        Dim intToolNo As Integer
        Dim objCmdATC As New Okuma.CLCMDAPI.CommandAPI.CATC

        For Each intToolNo In intToolNos
            objCmdATC.ToolDataInput(intToolNo, strFolderPath, blnOverwrite)
        Next

    End Sub

    ''' <summary>
    ''' Save tool data give tool list
    ''' </summary>
    ''' <param name="intToolNos">an array of tools to be saved to files</param>
    ''' <param name="strFolderPath">full path folder name where tool data files are stored</param>
    ''' <param name="blnOverwrite">Overwrite tool data if it is set to TRUE</param>
    ''' <remarks>Sample codes only. It does not detect all specifications of each machine</remarks>
    Public Shared Sub SaveToolData(ByRef intToolNos() As Integer, ByVal strFolderPath As String, ByVal blnOverwrite As Boolean)
        Dim intToolNo As Integer
        Dim objCmdATC As New Okuma.CLCMDAPI.CommandAPI.CATC

        For Each intToolNo In intToolNos
            objCmdATC.ToolDataOutput(intToolNo, strFolderPath, blnOverwrite)
        Next

    End Sub
#End Region

End Class
