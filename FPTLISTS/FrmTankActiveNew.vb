Public Class FrmTankActiveNew
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


        If g_Terminal <> "" Then
            Me.GridView2.Where = "Date_nd='" & p_ConVert_Date.ToString & "' and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'"
            Me.GridView1.Where = "left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'"
        End If

        p_XtraUserName = g_UserName
        'Me.DefaultFormLoad = True
        'Me.Form1_Load(e, sender)
        Dim p_SQL As String = "Select * from tblMap_cp where  Client like '%E5%' and status='out'"
        p_TblConfig = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

        Me.DefaultFormLoad = True
        Me.Form1_Load(sender, e)
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
                                                        "," & .Rows(p_Count).Item("TyTrongNen").ToString.Trim & _
                                                        "," & .Rows(p_Count).Item("TyTrongE").ToString.Trim & _
                                                        ",'" & .Rows(p_Count).Item("Ma_Hhoa").ToString.Trim & "'" & _
                                                        ",'" & .Rows(p_Count).Item("TankID").ToString.Trim & "'" & _
                                                        ",'" & .Rows(p_Count).Item("TankE").ToString.Trim & "'" & _
                                                        ",'" & g_UserName & "', getdate()" & _
                                                        ")"
                                p_RowAdd = p_TblExeHTTG.NewRow
                                p_RowAdd.Item(0) = p_SQL
                                p_TblExeHTTG.Rows.Add(p_RowAdd)

                                'Insert sang TyTrongE5 cua Scadar

                                p_SQL = "INSERT INTO [TYTRONGE5]  (Dateandtime, [Ma_hong] ,[Tyle],[Tytrong_Base],[Tytrong_E], Ma_Hhoa, Be_Base, Be_E)  "
                                p_SQL = p_SQL & " VALUES (getdate()," & _
                                                        .Rows(p_Count).Item("ArmNo").ToString.Trim & _
                                                        "," & .Rows(p_Count).Item("ERate").ToString.Trim & _
                                                        "," & .Rows(p_Count).Item("TyTrongNen").ToString.Trim & _
                                                        "," & .Rows(p_Count).Item("TyTrongE").ToString.Trim & _
                                                        ",'" & .Rows(p_Count).Item("Ma_Hhoa").ToString.Trim & "'" & _
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

                If p_TblExeScadar.Rows.Count > 0 Then
                    If g_Services.Execute_DataTbl_With_Connection(p_Connect, p_TblExeScadar, p_SQL) = False Then
                        ShowMessageBox("", p_SQL)
                        Exit Sub
                    End If
                End If

            End If
        End If
        Me.DefaultSave = True
        Me.UpdateToDatabase(Me, "")
        Me.DefaultSave = False
        ' End If
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
                    ' p_Gridview.InvalidateRowCell(e.RowHandle, e.Column)
                ElseIf p_Value = 1 Or p_Value = 0 Then
                    MsgBox("Giá trị không hợp lệ", MsgBoxStyle.Critical, "Thông báo")
                    e.Valid = False
                End If
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
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_DataTable As DataTable
        Dim p_Array() As DataRow
        If Me.GridView1.RowCount > 0 Then
            
            p_DataRow = Me.GridView1.GetFocusedDataRow

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
                If p_DataTable.Rows(p_DataTable.Rows.Count - 1).Item("Name_nd").ToString.Trim <> "" Then
                    Me.GridView2.AddNewRow()
                End If

                Me.GridView2.SetFocusedRowCellValue("Name_nd", p_DataRow.Item("Name_nd").ToString.Trim)
                Me.GridView2.SetFocusedRowCellValue("Dens_nd", p_DataRow.Item("Dens_nd").ToString.Trim)
                Me.GridView2.SetFocusedRowCellValue("Product_nd", p_DataRow.Item("Product_nd").ToString.Trim)
            End If
        End If
    End Sub

    Private Sub TankActive_Removed()
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_DataRow As DataRow
        If Me.GridView1.RowCount > 0 Then

            p_DataRow = Me.GridView1.GetFocusedDataRow
        End If
        If p_DataRow Is Nothing Then
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
       
        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.DoClick(Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Remove)
    End Sub

    Private Sub U_ButtonCus2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus2.Click
        TankActive_Removed()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Save()
    End Sub
End Class