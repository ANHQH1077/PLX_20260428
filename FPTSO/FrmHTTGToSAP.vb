Public Class FrmHTTGToSAP
    Public g_Approved As Boolean = False
    Public ViewAdmin As Boolean = False

    Public g_NgayThang As DateTime
    Public g_SoGiaoDich As Integer = 0
    Public g_ClientABC As String = ""
    Private p_DataSet As DataSet
    Private p_SAP_Obj As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)



    Private Sub LoadData()
        
        Dim p_FromDate As String = ""
        Dim p_ToDate As String = ""
        Dim p_Client As String = "ALL"
        Dim p_sType As String = "Y"
       
        Dim p_SoLenh As String = ""
        Dim p_SQL As String = ""
        Dim p_Table As DataTable

        Dim p_Count As Integer

        If Not Me.txtSoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.txtSoLenh.EditValue.ToString.Trim
        End If
        If p_SoLenh = "" Then
           
        End If
        If Not Me.Client.EditValue Is Nothing Then
            p_Client = Me.Client.EditValue.ToString.Trim
        End If
      


        If Not Me.CreateDate.EditValue Is Nothing Then
            If Me.CreateDate.EditValue.ToString.Trim <> "" Then
                p_FromDate = CDate(Me.CreateDate.EditValue).ToString("yyyy-MM-dd")
            End If
        End If

      
        If Not Me.ToCreateDate.EditValue Is Nothing Then
            If Me.ToCreateDate.EditValue.ToString.Trim <> "" Then
                p_ToDate = CDate(Me.ToCreateDate.EditValue).ToString("yyyy-MM-dd")
            End If
        End If

        If Not Me.sType.EditValue Is Nothing Then
            p_sType = Me.sType.EditValue.ToString.Trim
        End If
        If p_SoLenh <> "" Then
            If p_FromDate = "" Then
                p_FromDate = "20000101"
            End If
            If p_ToDate = "" Then
                p_ToDate = Now.Date.ToString("yyyyMMdd")
            End If
        Else
            If p_FromDate = "" Or p_ToDate = "" Then
                ShowMessageBox("", "Ngày tháng không được trống")
                Exit Sub
            End If
        End If
      
        p_SQL = "  exec  [FPT_GetData_THN]  " & IIf(p_SoLenh = "", "NULL", "'" & p_SoLenh & "'") & _
                ", '" & p_FromDate & "','" & p_ToDate & "', '" & p_sType & "', '" & p_Client & "'"

        p_DataSet = GetDataSet(p_SQL, p_SQL)

        If Not p_DataSet Is Nothing Then
            Me.TrueDBGrid1.DataSource = p_DataSet.Tables(0)
            For p_Count = 0 To Me.GridView1.Columns.Count - 1
                Me.GridView1.Columns.Item(p_Count).FieldName = Me.GridView1.Columns.Item(p_Count).Name.ToString
            Next
        End If
        Me.U_CheckBox1.Checked = True


        Dim p_ColDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Dim p_Column As U_TextBox.GridColumn
        p_Column = GridView1.Columns.Item("NgayXuat")
        p_ColDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit

        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy"
        p_ColDate.EditMask = "dd/MM/yyyy"
        p_Column.ColumnEdit = p_ColDate
        p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        p_Column.DisplayFormat.FormatString = "dd/MM/yyyy"


    End Sub
    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        LoadData()


    End Sub


    Private Sub ReloadData()
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False
    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub


    Private Sub FrmTankHeaderImp_QL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String = "select 'A' as Code , N'Tất cả' as Name Union all select 'Y' as Code , N'Lệnh tạo trên HTTG' as Name Union select 'N' as Code , N'Lệnh đồng bộ SAP' as Name"
        Dim p_Table, p_Table1 As DataTable

        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            Me.sType.Properties.DataSource = p_Table
            Me.sType.Properties.ValueMember = "Code"
            Me.sType.Properties.DisplayMember = "Name"
            Me.sType.ItemIndex = 0
        End If

        Me.Client.SqlString = "SELECT [Client]  FROM [FPT_Client_V] where charindex(Client,(select Terminal  from sys_USeR where upper(USER_NAME) =UPPER('" & g_UserName & "')),1)>0"

        Me.ControlResize = True
        FindAllControls(Me)
        Me.U_CheckBox1.Checked = True
        '  Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim p_TableHeader As DataTable
        Dim p_TableHangHoa As DataTable
        Dim p_TableLine As DataTable
        Dim p_Table, p_table1, p_table2 As DataTable
        Dim p_Row, p_RowHH, p_RowLine As DataRow
        Dim p_SoLenh As String = ""
        Dim p_RowArr() As DataRow
        Dim p_RowArrHH() As DataRow
        Dim p_RowArrLine() As DataRow
        Dim p_Count, p_RowID As Integer
        Dim p_SQL As String
        Dim p_Count1, p_RowID1 As Integer
        Dim p_Error As String = ""
        Dim p_Count2, p_RowID2 As Integer

        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                Me.GridView1.MoveNext()
                Me.GridView1.MovePrev()

                p_Table = p_DataSet.Tables(0)
                p_table1 = p_DataSet.Tables(1)
                p_table2 = p_DataSet.Tables(2)

                p_TableHeader = p_Table.Clone
                p_TableHangHoa = p_table1.Clone
                p_TableLine = p_table2.Clone

                For p_Count = p_TableHeader.Columns.Count - 1 To 0 Step -1
                    If Strings.Left(p_TableHeader.Columns(p_Count).ColumnName.ToString.Trim, 2) = "ZZ" Or p_TableHeader.Columns(p_Count).ColumnName.ToString.Trim = "X" Then
                        p_TableHeader.Columns.Remove(p_TableHeader.Columns(p_Count).ColumnName.ToString.Trim)
                    End If
                Next

                p_RowArr = p_Table.Select("X='Y'")
                For p_RowID = 0 To p_RowArr.Length - 1
                    p_Row = p_TableHeader.NewRow
                    For p_Count = 0 To p_TableHeader.Columns.Count - 1
                        p_Row.Item(p_TableHeader.Columns(p_Count).ColumnName.ToString) = p_RowArr(p_RowID).Item(p_TableHeader.Columns(p_Count).ColumnName.ToString)
                    Next
                    p_TableHeader.Rows.Add(p_Row)
                    'Hang hoa E5
                    p_SoLenh = p_RowArr(p_RowID).Item("SoLenh")
                    p_RowArrHH = p_table1.Select("SoLenh='" & p_SoLenh & "'")
                    For p_RowID1 = 0 To p_RowArrHH.Length - 1
                        p_RowHH = p_TableHangHoa.NewRow
                        For p_Count1 = 0 To p_TableHangHoa.Columns.Count - 1
                            p_RowHH.Item(p_TableHangHoa.Columns(p_Count1).ColumnName.ToString) = p_RowArrHH(p_RowID1).Item(p_TableHangHoa.Columns(p_Count1).ColumnName.ToString)
                        Next
                        p_TableHangHoa.Rows.Add(p_RowHH)
                    Next
                    'Hang hoa Chi tiet E5
                    'p_SoLenh = p_RowArr(p_RowID).Item("SoLenh")
                    p_RowArrLine = p_table2.Select("SoLenh='" & p_SoLenh & "'")
                    For p_RowID2 = 0 To p_RowArrLine.Length - 1
                        p_RowLine = p_TableLine.NewRow
                        For p_Count2 = 0 To p_TableLine.Columns.Count - 1
                            p_RowLine.Item(p_TableLine.Columns(p_Count2).ColumnName.ToString) = p_RowArrLine(p_RowID2).Item(p_TableLine.Columns(p_Count2).ColumnName.ToString)
                        Next
                        p_TableLine.Rows.Add(p_RowLine)
                    Next
                Next
                If p_TableHeader.Rows.Count <= 0 Then
                    'THN_LenhXuat_Infor
                    ShowMessageBox("", "Lệnh xuất chưa được chọn")
                    Exit Sub
                End If
                p_Error = ""
                THN_LenhXuat_Infor(p_TableHeader, p_TableHangHoa, p_TableLine, p_Error)
                If p_Error = "" Then
                    For p_Count = 0 To p_TableHeader.Rows.Count - 1
                        p_SoLenh = p_TableHeader.Rows(p_Count).Item("SoLenh").ToString.Trim

                        ' HTTG_To_Sap(p_SoLenh, p_Error)
                       
                        p_SQL = "update  tblLenhXuatE5 set Status ='5'  where SoLenh ='" & p_SoLenh & "'"
                        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                        End If
                    Next
                    ShowMessageBox("", "Đã thực hiện xong", 1)
                    LoadData()
                Else
                    ShowMessageBox("", p_Error)
                End If
            End If
        End If
    End Sub



    Private Sub HTTG_To_Sap(ByVal p_SoLenh As String, ByRef p_Error As String)
        Dim p_SQL As String = ""
        Dim p_DataSet As DataSet
        Dim p_dt_Header, p_dt_Material, p_dt_Details As DataTable



        p_Error = ""
        p_SQL = "exec FPT_GetDataToSAP '" & p_SoLenh & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_dt_Header = p_DataSet.Tables(0)
                p_dt_Material = p_DataSet.Tables(1)
                p_dt_Details = p_DataSet.Tables(2)
                Try

                    If p_SAP_Obj.ClsSyncDeliveries_Httg2Sap(p_dt_Header, p_dt_Material, p_dt_Details, p_Error, True) Then

                        p_SQL = "Update tblLenhXuatE5 set Status='5' where SoLenh='" & p_SoLenh & "'"
                        If g_Services.Sys_Execute(p_SQL, p_Error) = False Then

                        Else
                            'StatusMessage(False, "", "Đồng bộ thực xuất lên SAP thành công!", 120)
                            p_Error = ""
                        End If
                    Else

                    End If

                Catch ex As Exception
                    p_Error = ex.Message
                End Try
            End If
        End If


    End Sub

    Private Sub U_CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_CheckBox1.CheckedChanged
        Dim p_Count As Integer
        Dim p_Value As String = "N"
        If Me.U_CheckBox1.Checked = True Then
            p_Value = "Y"
        End If
        For p_Count = Me.GridView1.RowCount - 1 To 0 Step -1
            GridView1.SetRowCellValue(p_Count, "X", p_Value)
        Next
    End Sub
End Class