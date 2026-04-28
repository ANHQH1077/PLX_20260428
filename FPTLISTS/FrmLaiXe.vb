Public Class FrmLaiXe

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        SaveRecord()
    End Sub

    Private Sub SaveRecord()
        Me.DefaultSave = True
        Me.UpdateToDatabase(Me, Nothing)
        Me.DefaultSave = False
    End Sub
End Class