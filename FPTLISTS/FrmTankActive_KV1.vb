Public Class FrmTankActive_KV1
    Dim p_ConVert_Date As String
    Dim p_TblConfig As DataTable

    Private Sub FrmTankActiveNew_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            Save()
        End If
    End Sub
    Private Sub FrmTankActiveNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_DateValue As Date
        Dim p_TimeValue As Integer
        ' p_XtraUserName = g_User_ID
        p_GetDateTime(p_DateValue, p_TimeValue)
        p_ConVert_Date = p_DateValue.ToString("dd") & "/" & p_DateValue.ToString("MM") & "/" & p_DateValue.ToString("yyyy")

        If g_Filter_Terminal = True Then
            If g_Terminal <> "" Then
                Me.GridView2.Where = "Date_nd='" & p_ConVert_Date.ToString & "' and ( left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  ) "
                Me.GridView1.Where = "(left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "' )"
            End If
        Else
            Me.GridView2.Where = "Date_nd='" & p_ConVert_Date.ToString & "'"
        End If


        p_XtraUserName = g_UserName
        'Me.DefaultFormLoad = True
        'Me.Form1_Load(e, sender)
        Dim p_SQL As String = "Select * from tblMap_cp where  Client like '%E5%' and status='out'"
        p_TblConfig = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

        Me.DefaultFormLoad = True
        Me.Form1_Load(sender, e)
        Me.DefaultFormLoad = False
        'Me.GridView2.BestFitColumns()
        'Me.GridView1.BestFitColumns()
    End Sub

    Private Sub GridView2_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        Dim p_Row As DataRow
        p_Row = Me.GridView2.GetDataRow(e.RowHandle)
        If p_Row.Item("Date_nd").ToString.Trim = "" Then
            Me.GridView2.SetFocusedRowCellValue("Date_nd", p_ConVert_Date)
        End If
    End Sub

    Sub Save()
        Dim p_DataTable As DataTable
        Dim p_DataTable_Grid As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_ArrRow() As DataRow
        Dim p_CountH As Integer
        Dim p_Count As Integer
        Dim p_Connect As String
        Dim p_SQL As String

        Dim p_TblExeHTTG As New DataTable("Table01")
        Dim p_TblExeScadar As New DataTable("Table02")
        'Server=10.0.1.20;Database=AAScada2_Test_KV2;User ID=sa;Password=123456;Trusted_Connection=False;
        p_TblExeHTTG.Columns.Add("STR_SQL")
        p_TblExeScadar.Columns.Add("STR_SQL")
        Dim p_RowAdd As DataRow

        Me.GridView1.Focus()
        Me.GridView2.RefreshData()
        '  GridView2.SetFocusedRowModified()
        'GridView2.UpdateCurrentRow()
        'GridView2.RefreshEditor(True)
        Me.Focus()

        Dim p_Tytrong_Nen As Double
        Dim p_TyTrong_E As Double
        Dim p_TyLe As Double


        Dim p_BeXuat As String = ""
        ' If Asc(e.KeyChar) = 19 Then
        If Not p_TblConfig Is Nothing Then
            If p_TblConfig.Rows.Count > 0 Then
                p_Connect = "Provider=SQLOLEDB;Server=" & p_TblConfig.Rows(0).Item("ServerScada").ToString.Trim & _
                        ";Database=" & p_TblConfig.Rows(0).Item("DatabaseScada").ToString.Trim & _
                        ";User ID=" & p_TblConfig.Rows(0).Item("UidScada").ToString.Trim & _
                        ";Password=" & p_TblConfig.Rows(0).Item("PwdScada").ToString.Trim & _
                        ";Trusted_Connection=False"
                Me.TrueDBGrid2.Update()
                Me.GridView2.MoveFirst()
                p_Binding = Me.TrueDBGrid2.DataSource
                p_DataTable_Grid = CType(p_Binding.DataSource, DataTable)
                p_ArrRow = p_DataTable_Grid.Select("CHECKUPD='Y'")

                For p_CountH = 0 To p_ArrRow.Length - 1
                    p_SQL = "exec FPT_GetTankActiveUpdateToE5 '" & p_ArrRow(p_CountH).Item("Name_nd").ToString.Trim & "',0"   ' tblMeterE5"


                    p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                    If Not p_DataTable Is Nothing Then
                        With p_DataTable
                            For p_Count = 0 To p_DataTable.Rows.Count - 1

                                p_SQL = "INSERT INTO [tblMeterE5History]  ([ArmNo] ,[ERate],[TyTrongNen],[TyTrongE], Ma_Hhoa, " & _
                                        "TankID, TankE, UserCode, CreateDate)  "
                                p_SQL = p_SQL & " VALUES(" & _
                                                        .Rows(p_Count).Item("ArmNo").ToString.Trim & _
                                                        "," & .Rows(p_Count).Item("ERate").ToString.Trim & _
                                                        "," & IIf(p_ArrRow(p_CountH).Item("Name_nd").ToString.Trim = p_DataTable.Rows(p_Count).Item("TankID").ToString.Trim, p_ArrRow(p_CountH).Item("Dens_nd").ToString.Trim, .Rows(p_Count).Item("TyTrongNen").ToString.Trim) & _
                                                        "," & IIf(p_ArrRow(p_CountH).Item("Name_nd").ToString.Trim = p_DataTable.Rows(p_Count).Item("TankE").ToString.Trim, p_ArrRow(p_CountH).Item("Dens_nd").ToString.Trim, .Rows(p_Count).Item("TyTrongE").ToString.Trim) & _
                                                        ",'" & .Rows(p_Count).Item("Ma_Hhoa").ToString.Trim & "'" & _
                                                        ",'" & .Rows(p_Count).Item("TankID").ToString.Trim & "'" & _
                                                        ",'" & .Rows(p_Count).Item("TankE").ToString.Trim & "'" & _
                                                        ",'" & g_UserName & "', getdate()" & _
                                                        ")"
                                p_RowAdd = p_TblExeHTTG.NewRow
                                p_RowAdd.Item(0) = p_SQL
                                p_TblExeHTTG.Rows.Add(p_RowAdd)

                                'Insert sang TyTrongE5 cua Scadar

                                p_Tytrong_Nen = IIf(p_ArrRow(p_CountH).Item("Name_nd").ToString.Trim = p_DataTable.Rows(p_Count).Item("TankID").ToString.Trim, p_ArrRow(p_CountH).Item("Dens_nd").ToString.Trim, .Rows(p_Count).Item("TyTrongNen").ToString.Trim)
                                p_TyTrong_E = IIf(p_ArrRow(p_CountH).Item("Name_nd").ToString.Trim = p_DataTable.Rows(p_Count).Item("TankE").ToString.Trim, p_ArrRow(p_CountH).Item("Dens_nd").ToString.Trim, .Rows(p_Count).Item("TyTrongE").ToString.Trim)
                                Double.TryParse(.Rows(p_Count).Item("ERate").ToString.Trim, p_TyLe)

                                If p_TyLe = 0 Or p_TyTrong_E = 0 Or p_Tytrong_Nen = 0 Then
                                    ShowMessageBox("", "Thông tin Tỷ lệ phối trộn hoặc Tỷ trọng Nền hoặc Tỷ trọng Ethanol không xác định")
                                    Continue For
                                End If
                                p_SQL = "INSERT INTO [TYTRONGE5]  (Dateandtime, [Ma_hong] ,[Tyle],[Tytrong_Base],[Tytrong_E], Ma_Hhoa, Be_Base, Be_E)  "
                                p_SQL = p_SQL & " VALUES (getdate()," & _
                                                        .Rows(p_Count).Item("ArmNo").ToString.Trim & _
                                                        "," & .Rows(p_Count).Item("ERate").ToString.Trim & _
                                                         "," & IIf(p_ArrRow(p_CountH).Item("Name_nd").ToString.Trim = p_DataTable.Rows(p_Count).Item("TankID").ToString.Trim, p_ArrRow(p_CountH).Item("Dens_nd").ToString.Trim, .Rows(p_Count).Item("TyTrongNen").ToString.Trim) & _
                                                        "," & IIf(p_ArrRow(p_CountH).Item("Name_nd").ToString.Trim = p_DataTable.Rows(p_Count).Item("TankE").ToString.Trim, p_ArrRow(p_CountH).Item("Dens_nd").ToString.Trim, .Rows(p_Count).Item("TyTrongE").ToString.Trim) & _
                                                        ",'" & getHangHoaE5(.Rows(p_Count).Item("Ma_Hhoa").ToString.Trim) & "'" & _
                                                        ",'" & .Rows(p_Count).Item("TankID").ToString.Trim & "'" & _
                                                        ",'" & .Rows(p_Count).Item("TankE").ToString.Trim & "'" & _
                                                        ")"

                                p_RowAdd = p_TblExeScadar.NewRow
                                p_RowAdd.Item(0) = p_SQL
                                p_TblExeScadar.Rows.Add(p_RowAdd)
                            Next
                        End With
                    End If
                Next

                If p_TblExeHTTG.Rows.Count > 0 Then
                    If g_Services.Sys_Execute_DataTbl(p_TblExeHTTG, p_SQL) = False Then
                        ShowMessageBox("", p_SQL)
                        Exit Sub
                    End If
                End If


                'If p_TblExeScadar.Rows.Count > 0 Then
                '    If g_Services.Execute_DataTbl_With_Connection(p_Connect, p_TblExeScadar, p_SQL) = False Then
                '        ShowMessageBox("", p_SQL)
                '        Exit Sub
                '    End If
                'End If

                If Not p_TblConfig Is Nothing Then
                    If p_TblConfig.Rows.Count > 0 Then

                        For p_Count = 0 To p_TblConfig.Rows.Count - 1
                            If g_Filter_Terminal = True Then
                                If Mid(p_TblConfig.Rows(p_Count).Item("Client").ToString.Trim, 1, 1) = g_Terminal Then
                                    p_Connect = "Provider=SQLOLEDB;Server=" & p_TblConfig.Rows(p_Count).Item("ServerScada").ToString.Trim & _
                                       ";Database=" & p_TblConfig.Rows(p_Count).Item("DatabaseScada").ToString.Trim & _
                                       ";User ID=" & p_TblConfig.Rows(p_Count).Item("UidScada").ToString.Trim & _
                                       ";Password=" & p_TblConfig.Rows(p_Count).Item("PwdScada").ToString.Trim & _
                                       ";Trusted_Connection=False"
                                    'If Not p_DataTableExeE5 Is Nothing Then
                                    '    If p_DataTableExeE5.Rows.Count > 0 Then
                                    If g_Services.Execute_DataTbl_With_Connection(p_Connect, p_TblExeScadar, _
                                                                   p_SQL) = False Then
                                        ShowStatusMessage(True, "", "Lỗi khi cập nhật Tỷ trọng xăng nền và Ethanol xuống Tự động hóa", 10)
                                        ShowMessageBox("", p_SQL)
                                        Exit Sub
                                    End If
                                End If
                            Else
                                p_Connect = "Provider=SQLOLEDB;Server=" & p_TblConfig.Rows(p_Count).Item("ServerScada").ToString.Trim & _
                                        ";Database=" & p_TblConfig.Rows(p_Count).Item("DatabaseScada").ToString.Trim & _
                                        ";User ID=" & p_TblConfig.Rows(p_Count).Item("UidScada").ToString.Trim & _
                                        ";Password=" & p_TblConfig.Rows(p_Count).Item("PwdScada").ToString.Trim & _
                                        ";Trusted_Connection=False"
                                'If Not p_DataTableExeE5 Is Nothing Then
                                '    If p_DataTableExeE5.Rows.Count > 0 Then
                                If g_Services.Execute_DataTbl_With_Connection(p_Connect, p_TblExeScadar, _
                                                               p_SQL) = False Then
                                    ShowStatusMessage(True, "", "Lỗi khi cập nhật Tỷ trọng xăng nền và Ethanol xuống Tự động hóa", 10)
                                    ShowMessageBox("", p_SQL)
                                    Exit Sub
                                End If
                            End If

                            ' End If
                            ' End If
                        Next
                    End If
                End If

            End If
        End If
        Me.DefaultSave = True
        Me.UpdateToDatabase(Me, "")
        Me.DefaultSave = False
        ' End If
    End Sub

    'Public Function getHangHoaE5(ByVal p_MaHangHoa As String) As String
    '    Dim p_SQL As String
    '    Dim p_Table As DataTable
    '    getHangHoaE5 = p_MaHangHoa
    '    Try
    '        p_SQL = "select MaHangHoa_Scada  from tblMap_MaHangHoa where MaHangHoa_Sap='" & p_MaHangHoa & "'"
    '        p_Table = GetDataTable(p_SQL, p_SQL)
    '        If Not p_Table Is Nothing Then
    '            If p_Table.Rows.Count > 0 Then
    '                getHangHoaE5 = p_Table.Rows(0).Item("MaHangHoa_Scada").ToString.Trim
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try


    'End Function

    Private Sub GridView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView2.KeyDown
        If e.KeyCode = Keys.Delete Then
            Me.TrueDBGrid2.DefaultRemove = True
            Me.GridView2.DefaultRemove = True
            TankActive_Removed()
            Me.TrueDBGrid2.DefaultRemove = False
            Me.GridView2.DefaultRemove = False
        End If
    End Sub



    Private Sub GridView2_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView2.ValidatingEditor
        Dim p_Value As Double
        Dim p_String As String
        Dim p_Gridview As U_TextBox.GridView
        Dim p_DataRow As DataRow
        Try
            p_Gridview = CType(sender, U_TextBox.GridView)
            '  p_DataRow = p_Gridview.GetFocusedDataRow
            p_Value = 0
            'p_String = p_DataRow.Item("Dens_nd").ToString.Trim
            'p_Column_Name=p_Gridview.get
            If UCase(p_Gridview.FocusedColumn.FieldName.ToString.Trim) = UCase("Dens_nd") Then
                p_String = e.Value.ToString.Trim
                p_Value = Val(p_String)
                If p_Value < 0.5 Or p_Value > 1.5 Then
                    MsgBox("Giá trị không hợp lệ - trong khoảng 0.5 -> 1.5", MsgBoxStyle.Critical, "Thông báo")
                    e.Valid = False
                    Exit Sub
                    ' p_Gridview.InvalidateRowCell(e.RowHandle, e.Column)
                ElseIf p_Value = 1 Or p_Value = 0 Then
                    MsgBox("Giá trị không hợp lệ", MsgBoxStyle.Critical, "Thông báo")
                    e.Valid = False
                    Exit Sub
                End If
                p_String = Format(p_Value, "#0.###0").ToString
                e.Value = p_String

            End If

        Catch ex As Exception
            MsgBox("Nhập sai định dạng số", MsgBoxStyle.Critical, "Thông báo")
        End Try
    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        TankActive_Insert()
    End Sub

    Private Sub TankActive_Insert()
        Dim p_DataRow As DataRow
        Dim p_DataRowArr() As Integer
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_DataTable As DataTable
        Dim p_Array() As DataRow
        Dim p_Count As Integer

        If Me.GridView1.RowCount > 0 Then
            ' For p_Count = Me.GridView1.RowCount - 1 To 0 Step -1
            'If Me.GridView1.GetSelectedRow Then

            'End If
            p_DataRowArr = Me.GridView1.GetSelectedRows

            For p_Count = 0 To p_DataRowArr.Length - 1
                'p_DataRow = Me.GridView1.
                'If p_DataTable.Rows(p_DataTable.Rows.Count - 1).RowState = DataRowState.Deleted Then
                '    Continue For
                'End If
                p_DataRow = Me.GridView1.GetDataRow(p_DataRowArr(p_Count))
                If Not p_DataRow Is Nothing Then
                    Me.GridView2.RefreshData()
                    GridView2.MoveLast()
                    p_Binding = Me.TrueDBGrid2.DataSource
                    p_DataTable = CType(p_Binding.DataSource, DataTable)
                    If Not p_DataTable Is Nothing Then
                        p_Array = p_DataTable.Select("Name_nd='" & p_DataRow.Item("Name_nd").ToString.Trim & "'")
                        If p_Array.Length > 0 Then
                            ShowMessageBox("", "Bể xuất theo ngày đã tồn tại")
                            Exit Sub
                        End If
                    End If
                    If p_DataTable.Rows.Count >= 0 Then
                        Me.GridView2.AddNewRow()

                    Else
                        If p_DataTable.Rows(p_DataTable.Rows.Count - 1).RowState = DataRowState.Deleted Then
                            Me.GridView2.AddNewRow()
                        Else
                            If p_DataTable.Rows(p_DataTable.Rows.Count - 1).Item("Name_nd").ToString.Trim <> "" Then
                                Me.GridView2.AddNewRow()
                            End If
                        End If
                    End If

                    Me.GridView2.SetFocusedRowCellValue("Name_nd", p_DataRow.Item("Name_nd").ToString.Trim)
                    Me.GridView2.SetFocusedRowCellValue("Dens_nd", p_DataRow.Item("Dens_nd").ToString.Trim)
                    Me.GridView2.SetFocusedRowCellValue("Product_nd", p_DataRow.Item("Product_nd").ToString.Trim)
                    Me.GridView2.SetFocusedRowCellValue("TenHangHoa", p_DataRow.Item("TenHangHoa").ToString.Trim)
                    Me.GridView2.SetFocusedRowCellValue("CHECKUPD", "Y")


                End If
            Next
            Me.GridView1.DeleteSelectedRows()
            '  Next
        End If
    End Sub

    Private Sub TankActive_Removed()
        Dim p_DataTbl As DataTable
        Dim p_DataTblCheck As DataTable
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_SQL As String
        Dim p_Row As DataRow

        Dim p_Count As Integer
        Dim p_Count1 As Integer
        Dim p_RowArray() As Integer


        Dim Name_nd, Dens_nd, Product_nd, TenHangHoa As String

        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_DataRow As DataRow
        If Me.GridView2.RowCount <= 0 Then
            Exit Sub
            'p_DataRow = Me.GridView2.GetFocusedDataRow
        End If

        p_RowArray = Me.GridView2.GetSelectedRows

        If p_RowArray.Length <= 0 Then
            Exit Sub
        End If

        p_ValueMess = p_XtraModuleObj.ShowMessage(Me, "", _
                      "Bạn có chắc chắn muốn thực hiện không? ", _
                      True, _
                       "Có", _
                      True, _
                      "Không", _
                      False, _
                      "", _
                       0)
        If p_ValueMess = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        'If p_DataRow Is Nothing Then
        '    Exit Sub
        'End If

        If p_RowArray.Length > 0 Then
            p_Binding = Me.TrueDBGrid1.DataSource
            p_DataTbl = CType(p_Binding.DataSource, DataTable)


            For p_Count1 = 0 To p_RowArray.Length - 1 ' To 0 Step -1
                Me.GridView2.SelectRow(p_RowArray(p_Count1))
                p_DataRow = Me.GridView2.GetDataRow(p_RowArray(p_Count1))
                Name_nd = p_DataRow.Item("Name_nd").ToString.Trim
                Dens_nd = p_DataRow.Item("Dens_nd").ToString.Trim
                Product_nd = p_DataRow.Item("Product_nd").ToString.Trim
                TenHangHoa = p_DataRow.Item("TenHangHoa").ToString.Trim

                p_SQL = "exec FPT_CheckTankRemoved '" & p_DataRow.Item("Name_nd").ToString.Trim & "'," & IIf(g_E5 = True, 1, 0) & ",1"
                p_DataTblCheck = GetDataTable(p_SQL, p_SQL)
                If Not p_DataTblCheck Is Nothing Then
                    If p_DataTblCheck.Rows.Count > 0 Then
                        For p_Count = 0 To p_DataTblCheck.Rows.Count - 1
                            If p_DataTblCheck.Rows(p_Count).Item("Require") = 1 Then
                                ShowMessageBox("", p_DataTblCheck.Rows(p_Count).Item("DescName").ToString)
                                Exit Sub
                            Else
                                ShowMessageBox("", p_DataTblCheck.Rows(p_Count).Item("DescName").ToString)
                            End If
                        Next
                    End If
                End If





                p_DataRow = p_DataTbl.NewRow
                p_DataRow.Item("Name_nd") = Name_nd
                p_DataRow.Item("Dens_nd") = Dens_nd
                p_DataRow.Item("Product_nd") = Product_nd
                p_DataRow.Item("TenHangHoa") = TenHangHoa
                p_DataTbl.Rows.Add(p_DataRow)

            Next
            Me.GridView2.DefaultRemove = True
            Me.TrueDBGrid2.EmbeddedNavigator.Buttons.DoClick(Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Remove)
            Me.GridView2.DefaultRemove = False
            p_Binding.DataSource = p_DataTbl
            Me.TrueDBGrid1.DataSource = p_Binding
            Me.TrueDBGrid1.RefreshDataSource()
        End If
        'Me.GridView1.AddNewRow()
        'GridView1.MoveLast()
        'Me.GridView1.SetFocusedRowCellValue("Name_nd", Name_nd)
        'Me.GridView1.SetFocusedRowCellValue("Dens_nd", Dens_nd)
        'Me.GridView1.SetFocusedRowCellValue("Product_nd", Product_nd)
        'Me.GridView1.SetFocusedRowCellValue("TenHangHoa", TenHangHoa)


    End Sub

    Private Sub U_ButtonCus2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus2.Click
        TankActive_Removed()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Save()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub TrueDBGrid2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid2.Click

    End Sub
End Class