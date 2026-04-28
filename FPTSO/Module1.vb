Module Module1
    'FPTLISTS
    Public g_SYS_COMPANY As DataTable
    Public g_Filter_Terminal As Boolean = False
    'CONGTOBEXUAT
    Public g_CONGTOBEXUAT As Boolean = True

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

    Public _Report_Object As ReportSetup.Class1

    Public _HDDT_Object As HDDT.Class1

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

    Public g_WhsTypePromotions As String = "02"   'Lưu giá trị loại kho khuyến mại
    Public g_VatCodePromotions As String = "OP 0%" 'Lưu giá trị mã thuế VAT dành cho hàng khuyến mại

    Public Declare Function GlobalAlloc Lib "kernel32" (ByVal wFlags As Long, ByVal dwBytes As Long) As Long
    Public Declare Function GlobalFree Lib "kernel32" (ByVal hMem As Long) As Long

    'Copy from Memory?
    Public Declare Sub CopyMemoryPtrToBytes Lib "kernel32" Alias "RtlMoveMemory" ( _
                ByVal lpvDest As Byte, ByVal lpvSource As Long, ByVal cbCopy As Long)

    'Write to memory?
    Public Declare Sub CopyMemoryBytesToPtr Lib "kernel32" Alias "RtlMoveMemory" ( _
                ByVal lpvDest As Long, ByVal lpvSource As Byte, ByVal cbCopy As Long)
    Public g_ToolStripStatus As System.Windows.Forms.ToolStripStatusLabel
    Public g_MessageStatus As System.Windows.Forms.ToolStripStatusLabel
    Public g_MenuIcon As ToolStrip


    Public g_HamGetMaLenh As String = ""
    Public g_LoaiPhieu As String = "V144"

    Public g_Config_XMLDatatable As New System.Data.DataTable

    Public g_Terminal As String = ""
    Public g_HangHoaToScada2 As DataTable

    Public _getAllSyn As String = "A"
    Public _getHaftSyn As String = "H"

    Public g_WCF As Boolean = False
    Public g_E5 As Boolean = False

    Public g_App_Grid As Boolean = False
    Public g_App_Scadar As Boolean = False

    Public g_FieldExtra As DataTable
    Public g_StrFieldExtra As String

    Public g_AppN30 As String = "N"

    Public g_KIEMTRAGHEP_PT As Boolean = True

    Public g_TAITRONGKG As Boolean = False

    Public g_KV1 As Boolean = False

    Public g_TICHKE_A3 As Boolean = False
    Public g_DefaultPrint As String

    Public g_LinkServicesSMO As String = ""
    Public g_UserNameSMO As String = ""
    Public g_PassSMO As String = ""

    Public g_NhomBeXuat As Boolean = False

    Public g_PhuongThucXuat As DataTable
    'Public g_DBTYPE As String
    'Public g_TypeConnet As String

    Public Function RoundAmount(ByVal p_Amount As Double, ByVal p_Currency As String) As Double
        Dim p_Digit As Integer = 0
        Dim p_DataRowDigit() As DataRow

        RoundAmount = p_Amount
        'If p_Currency <> "" And p_Currency <> g_Currency Then
        Try
            If Not g_CurrencyDtl Is Nothing Then
                If g_CurrencyDtl.Rows.Count > 0 Then
                    p_DataRowDigit = g_CurrencyDtl.Select("CurrCode='" & p_Currency & "'")
                    If p_DataRowDigit.Length > 0 Then
                        p_Digit = p_DataRowDigit(0).Item("Decimals")
                    End If
                End If
            End If
            If p_Digit < 0 Then p_Digit = 0
            RoundAmount = Math.Round(p_Amount, p_Digit)
        Catch ex As Exception

        End Try
        'End If
    End Function

    Public Function CheckApprovedData(ByVal p_form As Form, ByRef p_Desc As String) As Boolean
        Dim p_RowArr() As DataRow
        Dim p_Count As Integer
        Dim p_TrueGrid As U_TextBox.U_TrueDBGrid
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim p_RowIndex As Integer
        Dim p_DataRow As DataRow
        p_Desc = ""
        Dim p_Value As Double = 0
        Dim p_FromValue As Double = 0
        Dim p_ToValue As Double = 0
        Dim p_Object() As Object
        Dim p_ObjectApp() As Object
        Try
            p_RowArr = g_ApprovedList.Select("FormName='" & p_form.Name & "'")
            CheckApprovedData = False

            If Not p_RowArr Is Nothing Then
                For p_Count = 0 To p_RowArr.Length - 1
                    If p_RowArr(p_Count).Item("GridName").ToString.Trim <> "" Then   'Grid
                        p_Object = p_form.Controls.Find(p_RowArr(p_Count).Item("GridName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            p_TrueGrid = CType(p_Object(0), U_TextBox.U_TrueDBGrid)
                            p_GridView = p_TrueGrid.Views.Item(0)
                            For p_RowIndex = 0 To p_GridView.RowCount - 1
                                p_Value = 0
                                If p_GridView.IsDataRow(p_RowIndex) Then
                                    p_DataRow = p_GridView.GetDataRow(p_RowIndex)
                                    If p_DataRow.Item(p_RowArr(p_Count).Item("ColumnName").ToString.Trim).ToString.Trim <> "" Then
                                        p_Value = p_DataRow.Item(p_RowArr(p_Count).Item("ColumnName").ToString.Trim).ToString.Trim
                                        If p_Value <> 0 Then
                                            p_FromValue = 0
                                            p_ToValue = 0
                                            If p_RowArr(p_Count).Item("AppRate").ToString.Trim = "Y" Then
                                                If p_RowArr(p_Count).Item("FromRate").ToString.Trim <> "" Then
                                                    p_FromValue = p_RowArr(p_Count).Item("FromRate").ToString.Trim
                                                End If

                                                If p_RowArr(p_Count).Item("ToRate").ToString.Trim <> "" Then
                                                    p_ToValue = p_RowArr(p_Count).Item("ToRate").ToString.Trim
                                                End If
                                                If p_Value >= p_FromValue And p_Value <= p_ToValue Then
                                                    If p_DataRow.Item(p_RowArr(p_Count).Item("FieldApp").ToString.Trim).ToString.Trim <> "Y" Then
                                                        p_Desc = p_RowArr(p_Count).Item("DescShow").ToString.Trim
                                                        CheckApprovedData = True
                                                        Exit Function

                                                    End If
                                                End If
                                            Else
                                                If p_RowArr(p_Count).Item("FromAmount").ToString.Trim <> "" Then
                                                    p_FromValue = p_RowArr(p_Count).Item("FromAmount").ToString.Trim <> ""
                                                End If

                                                If p_RowArr(p_Count).Item("ToAmount").ToString.Trim <> "" Then
                                                    p_ToValue = p_RowArr(p_Count).Item("ToAmount").ToString.Trim
                                                End If
                                                If p_Value >= p_FromValue And p_Value <= p_ToValue Then
                                                    If p_DataRow.Item(p_RowArr(p_Count).Item("FieldApp").ToString.Trim).ToString.Trim <> "Y" Then
                                                        p_Desc = p_RowArr(p_Count).Item("DescShow").ToString.Trim
                                                        CheckApprovedData = True
                                                        Exit Function

                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    ElseIf p_RowArr(p_Count).Item("ItemName").ToString.Trim <> "" Then   ''Item tren form
                        p_Object = p_form.Controls.Find(p_RowArr(p_Count).Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            If Not p_Object(0).EditValue Is Nothing Then
                                p_Value = p_Object(0).EditValue
                                If p_Value <> 0 Then
                                    p_FromValue = 0
                                    p_ToValue = 0
                                    p_ObjectApp = p_form.Controls.Find(p_RowArr(p_Count).Item("FieldApp").ToString.Trim, True)
                                    If p_ObjectApp.Length > 0 Then
                                        If Not p_ObjectApp(0).editvalue Is Nothing Then
                                            If p_RowArr(p_Count).Item("AppRate").ToString.Trim = "Y" Then
                                                If p_RowArr(p_Count).Item("FromRate").ToString.Trim <> "" Then
                                                    p_FromValue = p_RowArr(p_Count).Item("FromRate").ToString.Trim
                                                End If

                                                If p_RowArr(p_Count).Item("ToRate").ToString.Trim <> "" Then
                                                    p_ToValue = p_RowArr(p_Count).Item("ToRate").ToString.Trim
                                                End If
                                                If p_Value >= p_FromValue And p_Value <= p_ToValue Then
                                                    If p_ObjectApp(0).editvalue.ToString.Trim <> "Y" Then
                                                        p_Desc = p_RowArr(p_Count).Item("DescShow").ToString.Trim
                                                        CheckApprovedData = True
                                                        Exit Function

                                                    End If
                                                End If
                                            Else
                                                If p_RowArr(p_Count).Item("FromAmount").ToString.Trim <> "" Then
                                                    p_FromValue = p_RowArr(p_Count).Item("FromAmount").ToString.Trim
                                                End If

                                                If p_RowArr(p_Count).Item("ToAmount").ToString.Trim <> "" Then
                                                    p_ToValue = p_RowArr(p_Count).Item("ToAmount").ToString.Trim
                                                End If
                                                If p_Value >= p_FromValue And p_Value <= p_ToValue Then
                                                    If p_ObjectApp(0).editvalue.ToString.Trim <> "Y" Then
                                                        p_Desc = p_RowArr(p_Count).Item("DescShow").ToString.Trim
                                                        CheckApprovedData = True
                                                        Exit Function

                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            CheckApprovedData = True
            p_Desc = ex.Message
            'MsgBox(p_Desc)
        End Try
    End Function

    Public Sub GetApprovedList(ByVal p_Module As String)
        Dim p_Data As DataTable = Nothing
        Dim p_Des As String
        Exit Sub
        Try

            Dim p_SQL As String = "SELECT [Code],[FormName],[ItemName],[GridName],[ColumnName],[FromRate],[ToRate],[FromAmount],[ToAmount]" & _
                    ",[FromDate],[ToDate] ,[AppRate],[SQLCheck],[FieldAppUser] ,[FieldAppDate],[FieldApp], DescShow " & _
                    " FROM [SYS_APPROVE_LISTS] " & _
                    " where CONVERT(date, GETDATE())>=ISNULL(FromDate,'19000101')  " & _
                            " and  CONVERT(date, GETDATE())<=ISNULL(ToDate,GETDATE()+10)  And Module='" & p_Module & "'"
            g_ApprovedList = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Des)
            
        Catch ex As Exception

        End Try
    End Sub




    'FPT_GetExchangeRate
    Function p_GetExchangeRate(ByVal p_Date As Date, ByVal p_Currency As String) As Double
        Dim p_Data As New DataTable
        p_GetExchangeRate = 0
        Try
            p_Data = g_Services.mod_SYS_GET_DATATABLE("Exec FPT_GetExchangeRate '" & p_Date.ToString("yyyyMMdd") & "','" & p_Currency & "'")
            If p_Data.Rows.Count > 0 Then
                p_GetExchangeRate = p_Data.Rows(0).Item(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            p_GetExchangeRate = 0
        End Try
    End Function

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

    Public Sub p_GetApproved()
        Dim p_SQL As String = "select * from FPTAPP where Module='FPTSO'"
        g_DataApprove = g_Services.mod_SYS_GET_DATATABLE(p_SQL)

    End Sub

    Public Sub p_Get_Message()
        'Dim p_Object As New SystemBatch.Class1
        Dim p_SQL As String
        On Error Resume Next
        If pv_Message_Dataset.Tables.Count > 1 Then Exit Sub
        p_SQL = "select h.message_name from SYS_MESSAGES  h where h.enable_flag='Y'  order by h.message_code"
        pv_Message_Dataset = g_Services.mod_SYS_GET_DATASET(p_SQL)
        'g_Services = Nothing
    End Sub

    'Ham set biding cho cac Combobox
    Public Sub p_Set_Binding_Combo(ByVal p_FptModule As Object, ByRef p_Form As System.Windows.Forms.Form, ByVal p_BindingSourceCombobox() As BindingSource)
        Dim p_Rows() As DataRow
        Dim p_Count As Integer
        Dim p_FptModule1 As New FPTModule.Class1(g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, p_User_Database)
        p_Rows = p_DataSet_Combo_Source.Tables(0).Select("FORM_NAME='" & UCase(p_Form.Name) & "'")
        If p_Rows.Count > 0 Then
            ReDim p_BindingSourceCombobox(0 To p_Rows.Count - 1)
            For p_Count = 0 To p_Rows.Count - 1
                p_BindingSourceCombobox(p_Count) = New BindingSource
            Next

            If p_FptModule1.p_Mod_Combo_Source(p_Form, p_Rows, p_BindingSourceCombobox) = False Then

            End If
        End If
        p_FptModule1 = Nothing
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





    'Public Sub p_Gridview_Column_Button_Click(ByRef p_TrueGrid As U_TextBox.U_TrueDBGrid, _
    '                                           ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
    '                                            ByRef p_RptForm As System.Windows.Forms.Form, _
    '                                    ByRef p_Commit1 As Boolean, _
    '                                    ByRef pv_Header_Status1 As String, _
    '                                    ByRef p_ButtonOK As Object, _
    '                                    ByVal pv_UPD_KEY1 As String, _
    '                                    ByVal p_ColumnName As String)
    '    Dim p_Form As New FrmSearch
    '    Dim p_ShpCod As String = ""
    '    Dim p_EditText As New DevExpress.XtraEditors.TextEdit
    '    Dim p_SQL As String
    '    Dim p_FptModule As New FPTModule.Class1(g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName)
    '    Dim p_RowArr() As DataRow
    '    'Dim p_Row As DataRow

    '    If p_GridView.RowCount >= 0 Then
    '        p_RowArr = p_DataSet_TrueGird.Tables(0).Select("COL_NAME='" & p_ColumnName & "'")
    '        If p_RowArr.Length > 0 Then
    '            p_SQL = p_RowArr(0).Item("CFLSQL").ToString.Trim
    '            If p_SQL = "" Then Exit Sub
    '            p_SQL = p_FptModule.Parameter_Item(p_RptForm, p_SQL)

    '            p_Form.FptSQLString = p_SQL   ' "select  ItemCode as [Mã sản phẩm], ItemName as [Tên sản phẩm] from FPTOITM where SellItem='Y' "
    '            p_Form.FptFieldKey = p_RowArr(0).Item("CFLKeyField").ToString.Trim
    '            p_Form.Fpt_Object = p_GridView
    '            p_Form.FptB1Get = False
    '            p_Form.FptPageNum = 1
    '            p_Form.FptLineOfPage = 500
    '            p_Form.FptLoadPage = True
    '            p_Form.FptItemPosition = p_GridView
    '            p_Form.FptTypePosition = "C"
    '            p_Form.FptParentForm = p_RptForm
    '            If p_RowArr(0).Item("ShowLoadCFL").ToString.Trim = "Y" Then
    '                p_Form.FptShowLoad = True
    '            Else
    '                p_Form.FptShowLoad = False
    '            End If

    '            If p_GridView.FocusedRowHandle < 0 Then
    '                p_GridView.AddNewRow()
    '            End If
    '            p_Form.FptRowID = p_GridView.FocusedRowHandle
    '            p_Form.p_ObjSearchReturn(0) = p_ColumnName
    '            If p_RowArr(0).Item("CFLReturn1").ToString.Trim <> "" Then
    '                p_Form.p_ObjSearchReturn(1) = p_RowArr(0).Item("CFLReturn1").ToString.Trim
    '            End If
    '            If p_RowArr(0).Item("CFLReturn2").ToString.Trim <> "" Then
    '                p_Form.p_ObjSearchReturn(2) = p_RowArr(0).Item("CFLReturn2").ToString.Trim
    '            End If
    '            If p_RowArr(0).Item("CFLReturn3").ToString.Trim <> "" Then
    '                p_Form.p_ObjSearchReturn(3) = p_RowArr(0).Item("CFLReturn3").ToString.Trim
    '            End If
    '            If p_RowArr(0).Item("CFLReturn4").ToString.Trim <> "" Then
    '                p_Form.p_ObjSearchReturn(4) = p_RowArr(0).Item("CFLReturn4").ToString.Trim
    '            End If
    '            'p_Form.p_ObjSearchReturn(1) = "U_ItmName"
    '            p_Form.p_ColumnWidth(0) = "20"
    '            p_Form.p_ColumnWidth(1) = "80"

    '            p_Form.p_ChooseRecord = p_EditText

    '            p_Form.ShowDialog(p_RptForm)

    '            If Not p_EditText.EditValue Is Nothing Then
    '                If p_EditText.EditValue.ToString.Trim = "Y" Then
    '                    If p_Commit1 = True Then
    '                        p_GridView.UpdateCurrentRow()
    '                        p_GridView.RefreshData()
    '                        Exit Sub
    '                    End If

    '                    If p_Commit1 = False Then
    '                        p_Commit1 = True
    '                        If pv_Header_Status1 = "" Then
    '                            pv_Header_Status1 = pv_UPD_KEY1
    '                        End If
    '                        p_ButtonOK.Text = "Update"

    '                    End If
    '                End If
    '                p_GridView.UpdateCurrentRow()
    '                p_GridView.RefreshData()
    '                p_EditText.EditValue = "N"
    '            End If
    '        End If
    '    End If

    '    p_FptModule = Nothing
    'End Sub


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

    Public Function GetDataTable(ByVal p_SQL As String, ByVal p_Error As String) As DataTable
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


    Public Function GetDataSet(ByVal p_SQL As String, ByVal p_Error As String) As DataSet
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


    Sub ShowMessageBox(ByVal p_ErrorNum As String, ByVal p_StringMessage As String, Optional ByVal p_Status As Integer = 3)
        g_Module.ModErrExceptionNew(p_ErrorNum, p_StringMessage, p_Status)
    End Sub


    Public Sub SoLenh_THN_Show()
        Dim FrmLenhXuatAdd As New FrmSoLenh_THN
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



    Public Sub KiemKe_Show()
        Dim FrmLenhXuatAdd As New FrmKiemKe
        FrmLenhXuatAdd.p_XtraModuleObj = g_Module ' p_FptModule
        FrmLenhXuatAdd.g_XtraServicesObj = g_Services
        FrmLenhXuatAdd.FormStatus = False
        FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
        FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
        FrmLenhXuatAdd.p_XtraUserName = g_UserName
        FrmLenhXuatAdd.ShowDialog()
    End Sub


End Module
