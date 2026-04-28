Public Class FrmInChungTu_HDDT

    Private p_SoLenhHDDT As String = ""
    Private p_MaNguon As String = ""

    Public Property SoLenhHDDT As String
        Get
            Return p_SoLenhHDDT
        End Get
        Set(ByVal value As String)
            p_SoLenhHDDT = value
        End Set
    End Property


    Public Property MaNguon As String
        Get
            Return p_MaNguon
        End Get
        Set(ByVal value As String)
            p_MaNguon = value
        End Set
    End Property

    Private Sub FrmInChungTu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If g_Company_Code = "6610" Then
        '    Me.rdoHoaDonCT.Visible = True
        'End If

        If p_SoLenhHDDT <> "" Then
            Me.SoLenh.EditValue = p_SoLenhHDDT
            If p_MaNguon <> "" Then
                Select Case UCase(p_MaNguon)
                    Case "N30", "N35"   'GTGT
                        Me.rdoHoaDon.Checked = True
                    Case "N40", "N45", "N05"   'VCNB
                        Me.rdoPXK.Checked = True
                    Case Else
                End Select
            End If
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

     
        'If Me.rdoLenhXuat.Checked = False And Me.rdoLenhXKTheoPhoi.Checked = False And Me.rdoLenhXuatKDD.Checked = False Then
        If FPT_KiemTraKhiHoaDonDienTu(l_err, err, p_SoLenh) = True Then
            ShowMessageBox("", err)
            Return
        End If
        'End If

        If l_err = "TAIXUATGTGT1" Then   'Hiẹn KV2 vẫn đang dùng in hóa đơn giấy
            If l_err.ToString.Trim <> "" And p_SoLenh <> "" Then
                _Report_Object.clsInChungTu(Me.Owner, False, p_SoLenh, l_err)
            End If
        Else
            If l_err.ToString.Trim <> "" And p_SoLenh <> "" Then
                _HDDT_Object.clsInChungTu(Me.Owner, False, p_SoLenh, l_err)
            End If
        End If




    End Sub

    Private Sub rdoHoaDon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoHoaDon.CheckedChanged

    End Sub

    Private Sub rdoPXKHanggiuho_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPXKHanggiuho.CheckedChanged

    End Sub

    Private Sub rdoTaiXuat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoTaiXuat.CheckedChanged

    End Sub
End Class