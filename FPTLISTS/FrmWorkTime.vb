Public Class FrmWorkTime

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SaveRecord()
    End Sub

    Private Sub SaveRecord()
        Me.DefaultSave = True
        Me.UpdateToDatabase(Me, Nothing)
        Me.DefaultSave = False
    End Sub

    Private Sub FrmWorkTime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub FrmWorkTime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            SaveRecord()
        End If
    End Sub

    Private Sub FrmWorkTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class