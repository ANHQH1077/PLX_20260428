Public Class FrmKhachHang2

    Private Sub FrmKhachHang2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            SaveRecode()
        End If
    End Sub

    Private Sub FrmKhachHang2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SaveRecode()
        If Me.FormStatus = True Then
            Me.DefaultFormLoad = True
            Me.UpdateToDatabase(Me, "")
            Me.DefaultFormLoad = False
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SaveRecode()
    End Sub
End Class