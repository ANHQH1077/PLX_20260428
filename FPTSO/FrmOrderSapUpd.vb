Public Class FrmOrderSapUpd

    Private Sub CmdSMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSMO.Click
        Dim p_FromDate As String = ""
        Dim p_ToDate As String = ""
        Dim p_SoLenh As String = ""
        Dim p_Error As String = ""

        Dim p_ValueMess As Windows.Forms.DialogResult

        If Not Me.FromDate.EditValue Is Nothing Then
            p_FromDate = CDate(Me.FromDate.EditValue).ToString("yyyyMMdd")
        End If
        If Not Me.ToDate.EditValue Is Nothing Then
            p_ToDate = CDate(Me.ToDate.EditValue).ToString("yyyyMMdd")
        End If

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If

        If p_FromDate = "" Or p_ToDate = "" Then
            ShowMessageBox("", "Ngày tháng chưa nhập")
            Exit Sub
        End If

        p_ValueMess = g_Module.ShowMessage(Me, "", _
                        "Bạn có chắc chắn muốn thực hiện không? ", _
                        True, _
                         "Có", _
                        True, _
                        "Không", _
                        False, _
                        "", _
                         0)
        If p_ValueMess = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        CapNhatTrangThaiDongBo(p_FromDate, p_ToDate, p_SoLenh, p_Error)

        If p_Error = "" Then
            ShowMessageBox("", "Đã thực hện xong", 1)
        Else
            ShowMessageBox("", p_Error)
        End If
    End Sub
End Class