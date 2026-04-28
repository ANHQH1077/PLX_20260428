Public Class FrmTankBatch


    Private Sub FrmTankBatch_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        Dim p_Column As U_TextBox.GridColumn
        p_SQL = "select Name_nd as TankCode, Product_nd as MaHangHoa from tblTank " & _
                " where charindex ( left(name_nd,1),  (select terminal from sys_user where upper(user_name) = upper('" & g_UserName & "')),1) >0 and Product_nd in (select MahangHoa from tblHangHoa where mahanghoa like '01%')"

        If g_Filter_Terminal = True Then
            If g_Terminal <> "" Then
                Me.GridView1.Where = "  charindex ( left(TankCode,1),  (select terminal from sys_user where upper(user_name) = upper('" & g_UserName & "')),1) >0 "
            End If
        End If
        AddHandler Me.TrueDBGrid1.EmbeddedNavigator.ButtonClick, AddressOf TrueDBGrid1_EmbeddedNavigator_ButtonClick


        Me.TankCode.SqlString = p_SQL
        LoadData()
    End Sub
    Private Sub TrueDBGrid1_EmbeddedNavigator_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_DataTbl As DataTable
        Dim p_SQL As String
        Dim p_Row As DataRow
        Dim p_ValueMess As Windows.Forms.DialogResult

        p_ValueMess = g_Module.ShowMessage(Me, "", _
                                        "Bạn có chắn chắn muốn thực hiện không?", _
                                        True, _
                                         "Có", _
                                        True, _
                                        "Không", _
                                        False, _
                                        "", _
                                         0)
        If p_ValueMess = Windows.Forms.DialogResult.No Then
            ' Cursor = Cursors.Default
            e.Handled = True
            Exit Sub
        End If

        Dim p_Count As Integer

        Select Case e.Button.ButtonType
            Case DevExpress.XtraEditors.NavigatorButtonType.Remove
                p_Row = Me.GridView1.GetFocusedDataRow
                If Not p_Row Is Nothing Then
                    If p_Row.Item("ID").ToString.Trim <> "" Then
                        p_SQL = "delete from zTBLTANKBATCHS where id = " & p_Row.Item("ID").ToString.Trim
                        p_DataTbl = GetDataTable(p_SQL, p_SQL)
                        'If Not p_DataTbl Is Nothing Then
                        '    If p_DataTbl.Rows.Count > 0 Then
                        '        For p_Count = 0 To p_DataTbl.Rows.Count - 1
                        '            If p_DataTbl.Rows(p_Count).Item("Require") = 1 Then
                        '                ShowMessageBox("", p_DataTbl.Rows(p_Count).Item("DescName").ToString)
                        '                e.Handled = True
                        '                Exit Sub
                        '            Else
                        '                ShowMessageBox("", p_DataTbl.Rows(p_Count).Item("DescName").ToString)
                        '            End If
                        '        Next
                        '    End If
                        'End If
                    End If
                End If
            Case Else
        End Select
    End Sub


    Private Sub LoadData()
        'Me.DefaultWhere = "Where ID"
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False
        Me.TankCode.EditValue = ""
        Me.Add_Content.EditValue = ""
        Me.BatchNum.EditValue = ""
        ' Me.sda
        Me.TankCode.Focus()
    End Sub

    Private Sub ToolStripButton6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton6.Click
        Dim p_TankCode As String = ""
        If Not Me.TankCode.EditValue Is Nothing Then
            p_TankCode = Me.TankCode.EditValue.ToString.Trim
        End If
        If p_TankCode = "" Then
            ShowMessageBox("", "Bể xuất chưa nhập")
            Exit Sub
        End If
        Me.CrUser.EditValue = g_UserName
        Me.DefaultSave = True
        Me.UpdateToDatabase(Me)
        Me.DefaultSave = False
        LoadData()
    End Sub
End Class