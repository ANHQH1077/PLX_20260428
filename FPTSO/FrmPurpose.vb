Public Class FrmPurpose

    Private Sub FrmTankATG_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String = ""
        p_SQL = " charindex(Client,(select Terminal from sys_user  where upper(user_name ) =upper('" & g_UserName & "')),1) >0"
        Me.GridView1.Where = p_SQL
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        Dim p_ValueMess As Windows.Forms.DialogResult

        p_ValueMess = g_Module.ShowMessage(Me, "", _
                                    "Bạn có chắn chắn muốn lấy lại lệnh từ SAP không?", _
                                    True, _
                                        "Có", _
                                    True, _
                                    "Không", _
                                    False, _
                                    "", _
                                        0)

        If p_ValueMess = Windows.Forms.DialogResult.No Then
            ' Cursor = Cursors.Default
            Exit Sub
        End If
    End Sub
End Class