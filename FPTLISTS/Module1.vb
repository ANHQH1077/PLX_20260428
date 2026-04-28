Imports System.Net

Imports System.IO

Module Module1
    'FPTLISTS
    Public g_Filter_Terminal As Boolean = False

    Public g_IP_Address As String
    Public g_GetHostName As String
    Public g_User_ID As Double

    Public p_Company_ID As Integer
    Public p_Company_Code As String
    Public p_Company_Name As String
    Public p_User_Database As String
    Public g_Company_Host As String

    Public g_UserName As String
    Public g_UsrB1 As String
    Public g_PassB1 As String
    Public g_Port As String

    Public g_Terminal As String = ""
    Public g_Config_XMLDatatable As DataTable
    Public g_Wcf_Connect As Boolean
    Public g_PathXML As String

    Public g_Company_DBName As String

    Public pv_Back_Color As System.Drawing.Color = Drawing.Color.White
    Public pv_Required_Back_Color As System.Drawing.Color = Drawing.Color.Yellow
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


    Public Const g_RowNum As Integer = 20

    Public g_ToolStripStatus As System.Windows.Forms.ToolStripStatusLabel
    Public g_CompanyAPI As New Object
    Public g_LicenceHost As String
    Public g_Company_Code As String
    Public g_DBUser As String
    Public g_DBPass As String
    Public g_Currency As String = "VND"
    Public g_CurrencyDtl As New DataTable
    Public g_CurrencyDecima As Integer

    Public g_MessageStatus As System.Windows.Forms.ToolStripStatusLabel

    Public g_DBTYPE As String = "SQL"
    Public g_WCF As Boolean = False

    Public g_E5 As Boolean = False
    ' Public g_FptModule As New Object

    Public g_CONGTOBEXUAT As Boolean = True

    Public g_KV1 As Boolean = False
    Public p_TYTRONG_PTANG As Boolean = False

    Public g_DataPrintList As DataTable

    Public g_Module As Object

    Public Sub DongBoChiTietPT_Show()

        Dim FrmLenhXuatAdd As New FrmVehicleDetail
        FrmLenhXuatAdd.p_XtraModuleObj = g_Module ' p_FptModule
        FrmLenhXuatAdd.g_XtraServicesObj = g_Services
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
        'FrmLenhXuatAdd.g_FormAddnew = False
        'FrmLenhXuatAdd.READ_ONLY = Me.READ_ONLY
        FrmLenhXuatAdd.FormStatus = False
        FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
        FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
        FrmLenhXuatAdd.p_XtraUserName = g_UserName

        FrmLenhXuatAdd.ShowDialog()
    End Sub



    Public Sub THN_DendsToSAP(ByVal P_dATAtABLE As DataTable, ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_Table3 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_Desc As String = ""
        Dim p_Count As Integer
        Dim p_MaPhuongThucBan As String
        Dim p_Vbeln As String = ""
        Dim p_Plant As String = ""
        Dim p_CompanyCode As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_CompanyCode = p_Table2.Rows(0).Item("companycode").ToString.Trim
                '   p_Plant = p_Table2.Rows(0).Item("Plant_DB").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, p_CompanyCode)
                p_ECCDestinationConfig.clsTHN_DensToSap(P_dATAtABLE, o_err)
               


            End If
        End If



    End Sub

    Public Function GetConfigPrintFromXML() As Boolean
        ' Dim p_PathXML As String
        Dim p_DataSet As New DataSet


        Try
            g_PathXML = Windows.Forms.Application.StartupPath & "\ConfigPrint.xml"
            If Dir(g_PathXML) <> "" Then
                p_DataSet.ReadXml(g_PathXML)
                If Not p_DataSet Is Nothing Then
                    If p_DataSet.Tables.Count > 0 Then
                        g_DataPrintList = p_DataSet.Tables(0)
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
                '
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function



    Public Function mdlConfig_GetConfigFromXML() As Boolean
        ' Dim p_PathXML As String
        Dim p_DataSet As New DataSet


        Try
            g_PathXML = Windows.Forms.Application.StartupPath & "\Config.xml"
            If Dir(g_PathXML) <> "" Then
                p_DataSet.ReadXml(g_PathXML)
                If Not p_DataSet Is Nothing Then
                    If p_DataSet.Tables.Count > 0 Then
                        g_Config_XMLDatatable = p_DataSet.Tables(0)
                        Try
                            If g_Config_XMLDatatable.Rows(0).Item("CLIENT").ToString.Trim <> "" Then

                                g_Terminal = g_Config_XMLDatatable.Rows(0).Item("CLIENT").ToString.Trim

                            End If
                            'g_Wcf_Connect
                            If g_Config_XMLDatatable.Rows(0).Item("WCF").ToString.Trim = "TRUE" Then
                                g_Wcf_Connect = True
                            End If



                        Catch ex As Exception

                        End Try
                        ' g_Config_XMLDatatable.WriteXml(p_PathXML)
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
                '
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetDataTable(ByVal p_SQL As String, ByVal p_Error As String) As DataTable
        Dim p_Datatable As DataTable
        Try
            p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message
            ' ShowMessageBox(Err.Number, p_Error)
            Return Nothing
        End Try
        Return p_Datatable

    End Function


    Public Function GetDataSet(ByVal p_SQL As String, ByVal p_Error As String) As DataSet
        Dim p_Datatable As DataSet
        Try
            p_Datatable = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message
            'ShowMessageBox(Err.Number, p_Error)
            Return Nothing
        End Try
        Return p_Datatable

    End Function

    Public Function GetTypeConnectWCF() As Boolean
        Dim g_PathXML As String
        Dim p_DataSet As New DataSet
        Dim g_Config_XMLDatatable As DataTable

        Try
            GetTypeConnectWCF = False
            g_PathXML = Application.StartupPath & "\Config.xml"
            If Dir(g_PathXML) <> "" Then
                p_DataSet.ReadXml(g_PathXML)
                If Not p_DataSet Is Nothing Then
                    If p_DataSet.Tables.Count > 0 Then
                        g_Config_XMLDatatable = p_DataSet.Tables(0)
                        Try

                            'g_Wcf_Connect
                            If g_Config_XMLDatatable.Rows(0).Item("WCF").ToString.Trim = "TRUE" Then
                                GetTypeConnectWCF = True
                            End If

                        Catch ex As Exception

                        End Try
                        ' g_Config_XMLDatatable.WriteXml(p_PathXML)
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
                '
            Else
                Return False
            End If
            Return GetTypeConnectWCF
        Catch ex As Exception
            Return False
        End Try
    End Function

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


    Public Sub p_GetDateTime(ByRef p_Date As Date, ByRef p_Time As Integer)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        If g_DBTYPE = "ORACLE" Then
            p_SQL = "SELECT to_date(SYSDATE) AS SYS_DATE, to_number(TO_CHAR(CURRENT_DATE, 'HHMI')) AS SysTime FROM dual"
            p_Datatable = g_Services.SYS_GET_DATATABLE_oracle(p_SQL)
        ElseIf g_DBTYPE = "SQL" Then
            p_SQL = "select  convert(date, getdate()) as SYS_DATE, replace(CONVERT(VARCHAR(5),DATEADD(MINUTE,0 ,GETDATE()),108),':','') as SysTime"
            p_Datatable = g_Services.mod_SYS_GET_DATATABLE(p_SQL)
        End If

        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SYS_DATE")
                p_Time = p_Datatable.Rows(0).Item("SysTime")
            End If
        End If
        p_Datatable = Nothing
    End Sub



    Public Sub p_GetCurrentDate(ByRef p_Date As DateTime)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        p_SQL = "select  getdate() as SysDate"
        ' p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SysDate")

            End If
        End If
        p_Datatable = Nothing
    End Sub

    Public Function CheckFileName(ByVal p_CheckFile As Boolean, ByVal p_PathFile As String, ByRef p_Err As String) As Boolean
        CheckFileName = False
        p_Err = ""
        Try
            If p_PathFile = "" Then
                p_Err = "Đường dẫn không xác định"
                Exit Function
            End If
            If p_CheckFile = True Then
                CheckFileName = File.Exists(p_PathFile)
            Else
                CheckFileName = Directory.Exists(p_PathFile)

            End If
        Catch ex As Exception
            CheckFileName = False
            p_Err = ex.Message
        End Try
    End Function

    'hieptd4 add 20160718
    Public Function CheckFormOpen(ByVal p_FormName As String) As Object

        Dim frmCollection As New FormCollection()

        CheckFormOpen = Nothing
        frmCollection = Application.OpenForms()
        CheckFormOpen = frmCollection.Item(p_FormName)

    End Function


    Public Function getHangHoaE5(ByVal p_MaHangHoa As String) As String
        Dim p_SQL As String
        Dim p_Table As DataTable
        getHangHoaE5 = p_MaHangHoa
        Try
            p_SQL = "select MaHangHoa_Scada  from tblMap_MaHangHoa where MaHangHoa_Sap='" & p_MaHangHoa & "'"
            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    getHangHoaE5 = p_Table.Rows(0).Item("MaHangHoa_Scada").ToString.Trim
                End If
            End If
        Catch ex As Exception

        End Try


    End Function

    Public Sub CapNhatLichSuTaiTrongPhanTang(ByRef p_TableExec As DataTable, _
                                                    ByVal p_ArmNo_Table As Integer, _
                                                     ByVal p_MeterID As String, _
                                                     ByVal p_ArmNo As Integer, _
                                                     ByVal p_Name_ND As String, _
                                                     ByVal p_Dens As Double, _
                                                     ByVal p_LoadingSite As String, _
                                                     ByVal p_ProductCode As String, _
                                                     ByVal p_User_Name As String, ByVal p_DateTime As DateTime)
        Dim p_SQL As String
        Dim p_Row As DataRow

        If g_KV1 = True Or p_TYTRONG_PTANG = True Then
            If p_TableExec Is Nothing Then
                p_TableExec.Columns.Add("STR_SQL")
            End If
            If p_TableExec.Columns.Count <= 0 Then
                p_TableExec.Columns.Add("STR_SQL")
            End If

            p_SQL = " exec FPT_TankActive_Arm_Hist " & _
                 p_ArmNo_Table & _
               IIf(p_MeterID.ToString.Trim = "", ", Null", ",'" & p_MeterID.ToString.Trim & "'") & _
                 IIf(p_ArmNo.ToString.Trim = "", ", Null", "," & p_ArmNo.ToString.Trim & "") & _
                 IIf(p_Name_ND.ToString.Trim = "", ", Null", ",'" & p_Name_ND.ToString.Trim & "'") & _
                    IIf(p_Dens.ToString.Trim = "", ", Null", "," & p_Dens.ToString.Trim & "") & _
                    IIf(p_LoadingSite.ToString.Trim = "", ", Null", ",'" & p_LoadingSite.ToString.Trim & "'") & _
                    IIf(p_ProductCode.ToString.Trim = "", ", Null", ",'" & p_ProductCode.ToString.Trim & "'") & _
                    ",'" & p_User_Name & "','" & CDate(p_DateTime).ToString("MM/dd/yyyy hh:mm:ss tt") & "'"
            p_Row = p_TableExec.NewRow
            p_Row.Item(0) = p_SQL
            p_TableExec.Rows.Add(p_Row)
        End If
    End Sub



    Public Function DataTableRunExecBigData(ByVal p_DataTable As DataTable, ByRef p_Desc As String) As Boolean
        Dim p_DataExec As DataTable
        Dim p_Count As Integer
        Dim p_Int As Integer = 0
        Dim p_Row As DataRow
        Dim p_Count1 As Integer = 0

        Try
            p_DataExec = New DataTable
        Catch ex As Exception
            p_Desc = ex.Message
        End Try

        p_DataExec = p_DataTable.Clone

        p_Desc = ""
        If p_DataTable.Rows.Count >= 50 Then

            For p_Count = 0 To p_DataTable.Rows.Count - 1
                p_Row = p_DataExec.NewRow
                p_Row(0) = p_DataTable.Rows(p_Count).Item(0)
                p_DataExec.Rows.Add(p_Row)
                p_Int = p_Int + 1
                'p_Count1 = p_Count1 + 1
                'If p_Count1 = 1330 Then
                '    MsgBox("sffsdfs")
                'End If
                If p_Int = 50 Then
                    DataTableRunExecBigData = g_Services.Sys_Execute_DataTbl(p_DataExec, p_Desc)
                    If DataTableRunExecBigData = False Then
                        p_DataExec.Clear()
                        Exit Function
                    End If
                    p_DataExec.Clear()
                    p_Int = 0
                    '   Else

                    'p_Row = p_DataExec.Copy.Rows(p_Count)
                End If

            Next
            If p_DataExec.Rows.Count > 0 Then
                DataTableRunExecBigData = g_Services.Sys_Execute_DataTbl(p_DataExec, p_Desc)
                If DataTableRunExecBigData = False Then
                    p_DataExec.Clear()
                    Exit Function
                End If
                p_DataExec.Clear()
            End If
        Else
            DataTableRunExecBigData = g_Services.Sys_Execute_DataTbl(p_DataTable, p_Desc)
            If DataTableRunExecBigData = False Then
                Exit Function
            End If
        End If
    End Function




End Module
