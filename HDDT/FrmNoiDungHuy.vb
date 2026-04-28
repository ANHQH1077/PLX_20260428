Public Class FrmNoiDungHuy
    Public g_NoiDung As String = ""
    Public g_MaTarCuu As String = ""
    Public g_LoaiChungTu As String = ""
    Public g_SoLenh As String = ""
    Private g_ErrorStatus As Boolean
    Public Property G_Error As Boolean
        Get
            Return g_ErrorStatus
        End Get
        Set(ByVal value As Boolean)
            g_ErrorStatus = value
        End Set
    End Property
    Private Sub FrmNoiDungHuy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_ErrorStr As String = ""
        If Not Me.U_MemmoEdit1.EditValue Is Nothing Then
            g_NoiDung = Me.U_MemmoEdit1.EditValue.ToString.Trim
        End If

        If g_NoiDung <> "" Then

            If MsgBox("Bạn có chắc chắn muốn thực hiện không", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Chú ý") = MsgBoxResult.Yes Then



                'p_ValueMess = g_Module.ShowMessage(Me, "", _
                '                                     "Bạn có chắc chắn thực hiện không?", _
                '                                     True, _
                '                                      "Có", _
                '                                     True, _
                '                                     "Không", _
                '                                     False, _
                '                                     "", _
                '                                      0)
                '   If p_ValueMess = Windows.Forms.DialogResult.Yes Then
                HDDT_Cancel(g_LoaiChungTu, g_MaTarCuu, g_SoLenh, g_NoiDung, g_ErrorStatus, p_ErrorStr)
                If g_ErrorStatus = True Then
                    ShowMessageBox("", p_ErrorStr)
                    Exit Sub
                Else
                    Me.Close()
                End If
            End If
        Else
            ShowMessageBox("", "Bạn chưa nhập nội dung hủy")
        End If

    End Sub
End Class