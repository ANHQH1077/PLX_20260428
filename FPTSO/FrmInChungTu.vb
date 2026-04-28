Public Class FrmInChungTu

    Private Sub FrmInChungTu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If g_Company_Code = "6610" Then
            Me.rdoHoaDonCT.Visible = True
        End If
    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim err As String = String.Empty
      

        Dim p_SoLenh As String = ""

        Dim l_err As String
        l_err = String.Empty
        If Me.rdoLenhXuat.Checked = True Then
            l_err = "LENHXUATKHO"
        End If


        If Me.rdoHoaDon.Checked = True Then
            l_err = "HOADON"
        End If

        If Me.rdoHoaDonCT.Checked = True Then
            l_err = "HOADONCT"
        End If

        If Me.rdoPXK.Checked = True Then
            l_err = "HOADONVCNB"
        End If

        If Me.rdoPXK_NBN.Checked = True Then
            l_err = "HOADONVCNB_NBN"
        End If
        If Me.rdoPXK_CIF.Checked = True Then
            l_err = "HOADONVCNB_CIF"
        End If

        If rdoPXKHanggiuho.Checked Then
            l_err = "HOADONGIUHO"
        End If

        If rdoTaiXuat.Checked Then
            l_err = "TAIXUAT"
        End If

        If rdoTaiXuatGTGT.Checked Then
            l_err = "TAIXUATGTGT"
        End If

        If rdoTaiXuatGTGT1.Checked Then
            l_err = "TAIXUATGTGT1"
        End If

        If Me.rdoLenhXKTheoPhoi.Checked Then
            l_err = "LENHXKTHEOPHOI"
        End If
        If Me.rdoLenhXuatKDD.Checked Then
            l_err = "LENHXUATKHOKDD"
        End If
        If Me.rdoLenhXuatKDDA4.Checked Then
            l_err = "LENHXUATKHOKDDA4"
        End If

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If

        If Check_SoLenh(err, p_SoLenh) = False Or p_SoLenh = "" Then
            ShowMessageBox("", "Không tồn tại số lệnh")
            Return
        End If


        If Me.rdoLenhXuat.Checked = False And Me.rdoLenhXKTheoPhoi.Checked = False And Me.rdoLenhXuatKDD.Checked = False Then
            If FPT_KiemTraKhiHoaDon(err, p_SoLenh) = True Then
                ShowMessageBox("", err)
                Return
            End If
        End If


        If l_err.ToString.Trim <> "" And p_SoLenh <> "" Then
            _Report_Object.clsInChungTu(Me.Owner, False, p_SoLenh, l_err)
        End If
      
    End Sub

    Private Sub rdoHoaDon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHoaDon.CheckedChanged

    End Sub

    Private Sub rdoPXKHanggiuho_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPXKHanggiuho.CheckedChanged

    End Sub

    Private Sub rdoTaiXuat_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoTaiXuat.CheckedChanged

    End Sub
End Class