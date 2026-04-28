Public Class FrmGhiNhanThucXuatExt
    Public pv_SoLenh As String = ""
    Private Sub FrmGhiNhanThucXuatExt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.DefaultWhere = " WHere SoLenh ='" & pv_SoLenh & "'"
        'Me.DefaultFormLoad = True
        'Me.LoadDataToForm()
        'Me.DefaultFormLoad = False

    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        If Me.FormStatus = True Then
            Dim p_SoLenh As String = ""
            If Not Me.SoLenh.EditValue Is Nothing Then
                p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
            End If
            If p_SoLenh = "" Then
                Me.SoLenh.EditValue = pv_SoLenh
            End If
            ' Me.DefaultSave = True
            Me.UpdateToDatabase(Me)
            ' Me.DefaultSave = False
        End If
    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click

    End Sub
End Class