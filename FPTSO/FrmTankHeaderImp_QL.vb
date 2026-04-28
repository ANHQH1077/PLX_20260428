Public Class FrmTankHeaderImp_QL
    Public g_Approved As Boolean = False
    Public ViewAdmin As Boolean = False

    Public g_NgayThang As DateTime
    Public g_SoGiaoDich As Integer = 0
    Public g_ClientABC As String = ""

    Private Sub LoadData()
        Dim p_DocEntry As Integer = 0
        Dim p_NgayThang As Date
        Dim p_FromDate As String = ""
        Dim p_ToDate As String = ""
        Dim p_Client As String = ""
        Dim p_sType As String = ""
        Dim p_Where As String = ""
        Dim p_Status As String = ""
        If Not Me.DocEntry.EditValue Is Nothing Then
            Integer.TryParse(Me.DocEntry.EditValue.ToString.Trim, p_DocEntry)
        End If
        If p_DocEntry > 0 Then
            p_Where = "DocEntry =" & p_DocEntry
            Me.GridView1.Where = p_Where
            ReloadData()
            Exit Sub
        End If

        If Not Me.Client.EditValue Is Nothing Then
            p_Client = Me.Client.EditValue.ToString.Trim
        End If
        If p_Client <> "" Then
            p_Where = "Client='" & p_Client & "' "
        End If

        If ViewAdmin = False Then
            If p_Where <> "" Then
                p_Where = p_Where & " and isnull(Status,'') <> 'C' "
            Else
                p_Where = " isnull(Status,'') <> 'C' "
            End If
        End If

        If Not Me.sType.EditValue Is Nothing Then
            p_sType = Me.sType.EditValue.ToString.Trim
        End If
        If p_sType <> "" Then
            If p_Where <> "" Then
                p_Where = p_Where & " and sType='" & p_sType & "' "
            Else
                p_Where = "sType='" & p_sType & "' "
            End If
        End If


        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If
        If p_Status <> "" Then
            If p_Status = "S" Then
                If p_Where <> "" Then
                    p_Where = p_Where & " and isnull(Status,'')='S' "
                Else
                    p_Where = "isnull(Status,'')='S' "
                End If
            Else
                If p_Where <> "" Then
                    p_Where = p_Where & " and isnull(Status,'') <>'S'"
                Else
                    p_Where = "isnull(Status,'') <> 'S' "
                End If
            End If

        End If



        If Not Me.CreateDate.EditValue Is Nothing Then
            If Me.CreateDate.EditValue.ToString.Trim <> "" Then
                p_FromDate = CDate(Me.CreateDate.EditValue).ToString("yyyy-MM-dd")
            End If
        End If

        If p_FromDate <> "" Then
            If p_Where <> "" Then
                p_Where = p_Where & " and convert(date, FromDate) >='" & p_FromDate & "' "

            Else
                p_Where = " convert(date,FromDate) >='" & p_FromDate & "' "
            End If
        End If
        If Not Me.ToCreateDate.EditValue Is Nothing Then
            If Me.ToCreateDate.EditValue.ToString.Trim <> "" Then
                p_ToDate = CDate(Me.ToCreateDate.EditValue).ToString("yyyy-MM-dd")
            End If
        End If
        If p_ToDate <> "" Then
            If p_Where <> "" Then
                p_Where = p_Where & " and convert(date, FromDate) <='" & p_ToDate & "' "

            Else
                p_Where = " convert(date, FromDate) <='" & p_ToDate & "' "
            End If
        End If

        Me.GridView1.Where = p_Where
        ReloadData()

    End Sub
    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        LoadData()
       

    End Sub


    Private Sub ReloadData()
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False
    End Sub

    Private Sub TrueDBGrid1_Click(sender As System.Object, e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As System.EventArgs) Handles GridView1.DoubleClick
        Dim p_DataRow As DataRow

        If Me.GridView1.RowCount > 0 Then
            p_DataRow = Me.GridView1.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then
            
                Dim FrmATG As New FrmTankHeaderImp
                FrmATG.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                FrmATG.g_XtraServicesObj = g_XtraServicesObj
                FrmATG.g_Approved = g_Approved
                    'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim

                ' FrmLenhXuatAdd.READ_ONLY = Me.READ_ONLY
                FrmATG.ViewAdmin = Me.ViewAdmin
                FrmATG.p_XtraToolTripLabel = g_ToolStripStatus
                FrmATG.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                FrmATG.p_XtraMessageStatusl = g_MessageStatus
                FrmATG.g_TankHeaderCode = p_DataRow.Item("TankHeaderCode").ToString.Trim
                If p_DataRow.Item("sType").ToString.Trim = "M" Then
                    FrmATG.g_Auto = False
                End If
                FrmATG.ShowDialog(Me)
                End If

        End If
    End Sub

    Private Sub FrmTankHeaderImp_QL_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String = "select 'A' as Code , N'Thông tin ATG' as Name Union select 'M' as Code , N'Nhập tay' as Name union select '' as Code , N'Tất cả' as Name"
        Dim p_Table, p_Table1 As DataTable
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            Me.sType.Properties.DataSource = p_Table
            Me.sType.Properties.ValueMember = "Code"
            Me.sType.Properties.DisplayMember = "Name"
        End If

        p_SQL = Me.Status.SQL_String
        If p_SQL <> "" Then
            p_Table1 = GetDataTable(p_SQL, p_SQL)
            If Not p_Table1 Is Nothing Then
                Me.Status.Properties.DataSource = p_Table1
                Me.Status.Properties.ValueMember = "Code"
                Me.Status.Properties.DisplayMember = "Name"
            End If
        End If
        



        Me.Client.SqlString = "SELECT [Client]  FROM [FPT_Client_V] where charindex(Client,(select Terminal  from sys_USeR where upper(USER_NAME) =UPPER('" & g_UserName & "')),1)>0"

        Me.ControlResize = True
        FindAllControls(Me)
        Me.WindowState = FormWindowState.Maximized

        If g_SoGiaoDich > 0 Then
            Dim p_Count As Integer
            Dim p_Row As DataRow
            Me.CreateDate.EditValue = g_NgayThang
            Me.ToCreateDate.EditValue = g_NgayThang
            If Len(g_ClientABC) = 1 Then
                Me.Client.EditValue = g_ClientABC
            End If
            LoadData()
            If Me.GridView1.RowCount > 0 Then
                For p_Count = Me.GridView1.RowCount - 1 To 0 Step -1
                    p_Row = Me.GridView1.GetDataRow(p_Count)
                    If Not p_Row Is Nothing Then
                        If p_Row.Item("DocEntry") = g_SoGiaoDich Then
                            p_Row.Item("X") = "Y"
                        End If
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub U_ButtonCus1_Click(sender As System.Object, e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_Count As Integer
        Dim p_RowArr() As DataRow
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_Table As DataTable
        Dim p_value As String = ""
        Dim p_SQL As String
        Dim p_TableReport As DataTable


        Me.GridView1.UpdateCurrentRow()
        p_Binding = Me.TrueDBGrid1.DataSource
        p_Table = CType(p_Binding.DataSource, DataTable)
        If p_Table.Rows.Count > 0 Then
            p_RowArr = p_Table.Select("X='Y'")
            If p_RowArr.Length > 0 Then
                For p_Count = 0 To p_RowArr.Length - 1
                    p_value = p_value & "," & p_RowArr(p_Count).Item("DocEntry").ToString.Trim
                Next
                If p_value <> "" Then
                    p_SQL = "exec BienBanDoBe_ALL '" & p_value & "'"
                    p_TableReport = GetDataTable(p_SQL, p_SQL)

                    Dim p_Report_ShowForm As New ReportSetup.Class1(g_Config_XMLDatatable, g_Company_Code, g_WareHouse, g_Services, "", "", g_Port, _
                                                                "", p_User_Database, g_UserName, "", _
                                                                g_DBUser, g_DBPass, g_CompanyAPI, Nothing, g_MessageStatus, g_MenuIcon)
                    p_Report_ShowForm.kv2_BienBanDoBe_All(p_TableReport)
                End If
            Else
                ShowMessageBox("", "Giao dịch chưa được chọn")
            End If
        End If
    End Sub
End Class