Public Class FrmSendAppr

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If MsgBox("Bạn có chắc chắn muốn thực hiện không", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
            If p_DataToDatabase(Me, "FPTAPPUSER", True, False) = False Then
                MsgBox("Lỗi khi cập nhật dữ liệu")
                Exit Sub
            Else
                Me.Close()
                MsgBox("Yêu cầu phê duyệt đã được gửi")
            End If
        End If
    End Sub
End Class