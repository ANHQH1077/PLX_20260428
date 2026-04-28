Public Class FrmLyDo
    Public g_LyDoHuy As String
    Private Sub FrmLyDo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        g_LyDoHuy = ""
    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        If Not Me.GhiChu.EditValue Is Nothing Then
            g_LyDoHuy = Me.GhiChu.EditValue.ToString.Trim
        End If
        If g_LyDoHuy = "" Then
            ShowMessageBox("", "Lý do hủy không được trống.")
            Exit Sub
        End If
        Me.Close()
    End Sub
End Class