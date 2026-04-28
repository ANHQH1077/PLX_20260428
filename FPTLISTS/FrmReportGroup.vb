Public Class FrmReportGroup

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        SaveData()
    End Sub

    Private Sub SaveData()
        Dim p_Status As String = ""
        If Not Me.txtStatus.EditValue Is Nothing Then
            p_Status = Me.txtStatus.EditValue.ToString.Trim
        End If
        If p_Status = "" Then
            Me.txtStatus.EditValue = "Y"
        End If
        Me.DefaultSave = True
        Me.UpdateToDatabase(Me)
        Me.DefaultSave = False
    End Sub

    Private Sub FrmReportGroup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class