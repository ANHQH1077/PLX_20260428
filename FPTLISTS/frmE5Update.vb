Public Class frmE5Update

    Private Sub frmE5Update_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            saverecord()
        End If
    End Sub
    Private Sub saverecord()
        Me.DefaultSave = True
        UpdateToDatabase(Me, "")
        Me.DefaultSave = False
    End Sub

    Private Sub frmE5Update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        p_XtraUserName = g_User_ID
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        saverecord()
    End Sub
End Class