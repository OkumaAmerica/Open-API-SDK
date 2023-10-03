Public Class CmdAPI_Samples
#Region "CATC.Load_AND_Save_Tool-Data"

    ''' <summary>
    ''' This sample will get a list of tools currently registered in the tool data table and save 
    ''' them into a folder.  It also restores all tools from the tool data files.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadSaveTools()
        Dim strFolderPath As String = "D:\MD1\TOOL-DATA"
        Dim blnOverwrite As Boolean = True
        Dim arToolList() As Integer
        Dim objTools As Okuma.CMDATAPI.DataAPI.CTools = New Okuma.CMDATAPI.DataAPI.CTools

        Try
            arToolList = objTools.GetToolList(Okuma.CMDATAPI.Enumerations.ToolListTypeEnum.AllTools)

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
    Public Sub LoadToolData(ByRef intToolNos() As Integer, ByVal strFolderPath As String, ByVal blnOverwrite As Boolean)
        Dim intToolNo As Integer
        Dim objCmdATC As New Okuma.CMCMDAPI.CommandAPI.CATC

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
    Public Sub SaveToolData(ByRef intToolNos() As Integer, ByVal strFolderPath As String, ByVal blnOverwrite As Boolean)
        Dim intToolNo As Integer
        Dim objCmdATC As New Okuma.CMCMDAPI.CommandAPI.CATC

        For Each intToolNo In intToolNos
            objCmdATC.ToolDataOutput(intToolNo, strFolderPath, blnOverwrite)
        Next

    End Sub
#End Region

End Class
