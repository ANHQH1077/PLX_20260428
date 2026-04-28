Public Class FrmQciKg

    Public FrmQciKg_NhietDo As Double = 30

    Private Sub FrmQciKg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.NhietDo.EditValue = FrmQciKg_NhietDo + 0.0
    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_T As Double = 0
        If Not Me.NhietDo.EditValue Then
            p_T = Me.NhietDo.EditValue
        Else
            ShowMessageBox("", "Nhiệt độ không hợp lệ")
            Exit Sub
        End If
        FrmQciKg_NhietDo = p_T
        Me.Close()
    End Sub
End Class