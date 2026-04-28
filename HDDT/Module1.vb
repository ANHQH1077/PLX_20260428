
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Module Module1
    Public g_SYS_COMPANY As DataTable

    Public g_Company_Code As String
    Public g_WareHouse As String
    Public g_WareHouseName As String

    'Public g_User_Database As String
    Public g_IP_Address As String
    Public g_GetHostName As String
    Public g_User_ID As Double

    Public p_Company_ID As Integer

    Public p_Company_Code As String
    Public p_Company_Name As String
    Public p_User_Database As String
    Public g_Company_Host As String
    Public g_Company_DBName As String

    Public g_UserName As String
    Public g_UsrB1 As String
    Public g_PassB1 As String
    Public g_Port As String

    Public g_DataApprove As New DataTable


    Public pv_Back_Color As System.Drawing.Color = Drawing.Color.White
    Public pv_Required_Back_Color As System.Drawing.Color = Drawing.Color.LightGoldenrodYellow
    Public pv_Locked_Back_Color As System.Drawing.Color = Drawing.Color.LightCyan
    Public g_Format_Date_Ora As String = "MM/DD/YYYY"
    Public g_Format_Date As String = "MM/dd/yyyy"

    Private pv_Type_Column_Char As String = "C"  'Kieu du lieu cua column
    Private pv_Type_Column_Date As String = "D"  'Kieu du lieu cua column
    Private pv_Type_Column_Number As String = "N"  'Kieu du lieu cua column

    Private pv_Type_Date As String = "DATEEDIT"
    Private pv_Type_TextBox As String = "C1TEXTBOX"
    Private pv_Type_Num As String = "C1NUMERICEDIT"
    Private pv_Type_Combo As String = "C1COMBO"

    Public pv_Message_Dataset As New DataSet

    Public p_Dataset_Binding As New DataSet
    Public p_DataSet_Combo_Source As New DataSet
    Public p_DataSet_TrueGird As New DataSet

    Public g_Services As Object
    Public g_Module As Object


    Public Const g_RowNum As Integer = 20
    Public g_CompanyAPI As New Object
    Public g_LicenceHost As String
    Public g_DBUser As String
    Public g_DBPass As String

    Public g_Currency As String = "VND"
    Public g_CurrencyDtl As New DataTable
    Public g_CurrencyDecima As Integer
    ' Public p_FptMod As FPTModule.Class1
    Public g_ApprovedList As DataTable

    Public Declare Function GlobalAlloc Lib "kernel32" (ByVal wFlags As Long, ByVal dwBytes As Long) As Long
    Public Declare Function GlobalFree Lib "kernel32" (ByVal hMem As Long) As Long

    'Copy from Memory?
    Public Declare Sub CopyMemoryPtrToBytes Lib "kernel32" Alias "RtlMoveMemory" ( _
                ByVal lpvDest As Byte, ByVal lpvSource As Long, ByVal cbCopy As Long)

    'Write to memory?
    Public Declare Sub CopyMemoryBytesToPtr Lib "kernel32" Alias "RtlMoveMemory" ( _
                ByVal lpvDest As Long, ByVal lpvSource As Byte, ByVal cbCopy As Long)
    'Public g_ToolStripStatus As System.Windows.Forms.ToolStripStatusLabel
    'Public g_MessageStatus As System.Windows.Forms.ToolStripStatusLabel
    'Public g_MenuIcon As ToolStrip


    Public g_HamGetMaLenh As String = ""
    Public g_LoaiPhieu As String = "V144"

    Public g_Config_XMLDatatable As New System.Data.DataTable

    Public g_DefaultPrint As String
    Public g_DefaultPrintVAT As String
    Public g_Terminal As String = ""

    Public g_PathXML As String = Application.StartupPath & "\Config.xml"

    Public g_HangHoaToScada2 As DataTable


    Public g_dt_para As DataTable
    Public g_SySConfig As DataTable

    Public g_TableDonvi As DataTable
    Public g_TenDonVi As String = ""

    Public g_HOADON2 As String = ""
    Public g_HOADON1 As String = ""

    Public p_SYS_MALENH_S As String = String.Empty

    Public g_SYS_CONFIG_RPT_PARA As DataTable
    Public g_SYS_CONFIG_RPT As DataTable
    Public g_SYS_CONFIG_RPT_FIELD As DataTable

    Public g_tblVCF As DataTable




    Public Sub p_Get_Message()
        'Dim p_Object As New SystemBatch.Class1
        Dim p_SQL As String
        On Error Resume Next
        If pv_Message_Dataset.Tables.Count > 1 Then Exit Sub
        p_SQL = "select h.message_name from SYS_MESSAGES  h where h.enable_flag='Y'  order by h.message_code"
        pv_Message_Dataset = g_Services.mod_SYS_GET_DATASET(p_SQL)
        'g_Services = Nothing
    End Sub

    Public Sub Mod_IPAddress()
        g_GetHostName = System.Net.Dns.GetHostName()
        Dim ipHostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        Dim ipAddress As System.Net.IPAddress
        Dim ipTmp As String = ""
        For Each ipAddress In ipHostInfo.AddressList
            'Only return IPv4 routable IPs
            If (ipAddress.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork) Then
                ipTmp = ipAddress.ToString
                Exit For
            End If
        Next
        If String.IsNullOrEmpty(ipTmp) Then
            ipTmp = ipHostInfo.AddressList(0).ToString
        End If
        g_IP_Address = ipTmp
        'g_IP_Address = System.Net.Dns.GetHostAddresses(g_GetHostName).GetValue(0).ToString    ' .GetHostByName(strHostName).ToString ' AddressList(0).ToString()                  

        'If g_IP_Address.LastIndexOf(".") <= 0 Then
        '    g_IP_Address = System.Net.Dns.GetHostAddresses(g_GetHostName).GetValue(1).ToString
        'End If
    End Sub





    Public Function CheckFormOpen(ByVal p_FormName As String) As Object

        Dim frmCollection As New FormCollection()

        CheckFormOpen = Nothing
        frmCollection = Application.OpenForms()
        CheckFormOpen = frmCollection.Item(p_FormName)

    End Function

    Public Sub FormClose(ByVal p_FormName As String, ByRef p_Cancel As Boolean)
        Dim p_FrmObj As Object
        p_FrmObj = CheckFormOpen(p_FormName)
        p_Cancel = False
        If Not p_FrmObj Is Nothing Then
            p_FrmObj.Close()
            p_Cancel = p_FrmObj.FormStatus
            p_FrmObj.focus()
        End If
    End Sub

    Public Function GetDataTable(ByVal p_SQL As String, ByRef p_Error As String) As DataTable
        Dim p_Datatable As DataTable
        Try
            p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message
            ShowMessageBox(Err.Number, p_Error)
            Return Nothing
        End Try
        Return p_Datatable

    End Function


    Public Function GetDataSet(ByVal p_SQL As String, ByRef p_Error As String) As DataSet
        Dim p_Datatable As DataSet
        Try
            p_Datatable = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message
            ShowMessageBox(Err.Number, p_Error)
            Return Nothing
        End Try
        Return p_Datatable

    End Function


    Public Sub ShowMessageBox(ByVal p_ErrorNum As String, ByVal p_StringMessage As String)
        g_Module.ModErrExceptionNew(p_ErrorNum, p_StringMessage)
    End Sub


    'Sys_Execute


    Public Function SQL_Execute(ByVal p_SQL As String, ByRef p_Error As String) As Boolean
        Dim pStatus As Boolean
        Try
            pStatus = False
            pStatus = g_Services.Sys_Execute(p_SQL, p_Error)
        Catch ex As Exception
            pStatus = True
        End Try
        Return pStatus

    End Function


    Public Sub p_GetDateTime(ByRef p_Date As Date, ByRef p_Time As Integer)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        p_SQL = "select  convert(date, getdate()) as SysDate, replace(CONVERT(VARCHAR(5),DATEADD(MINUTE,0 ,GETDATE()),108),':','') as SysTime"
        p_Datatable = g_Services.mod_SYS_GET_DATATABLE(p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SysDate")
                p_Time = p_Datatable.Rows(0).Item("SysTime")
            End If
        End If
        p_Datatable = Nothing
    End Sub

End Module
