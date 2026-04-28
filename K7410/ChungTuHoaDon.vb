Module ChungTuHoaDon

    Public p_dtpDieuDong As Date
    Public p_dtNgayXuat As Date

    Public p_dtNgayHoaDon As Date

    Public p_txtThueGTGT As String = ""
    Public p_txtDonViMuaHang As String = ""
    Public p_txtNguoiMuaHang As String = ""
    Public p_txtDiChiDonViMuaHang As String = ""
    Public p_txtThoiHanThanhToan As String = ""
    Public txtPhuongThuc As String = ""
    Public txtDonViCCVanTai As String = ""
    Public p_txtSoLenh As String = ""

    Public p_txtDonViGiaoHang As String = ""
    Public p_txtDiaChiDonViGiaoHang As String = ""
    Public p_txtDonViNhanHang As String = ""
    Public p_txtDiaChiDonViNhanHang As String = ""
    Public p_txtDiemGiaoHang As String = ""
    Public p_txtKhoNhap As String = ""
    Public p_txtDonViCungCapVanTai As String = ""
    Public TongTien As Decimal = 0
    Public W_ThueGTGT As Int64 = 0
    Public p_txtMST As String = ""
    Public p_txtMST2 As String = ""
    Public p_txtSoTaiKhoan1 As String = ""
    Public p_txtSoTaiKhoan2 As String = ""
    Public p_txtNgayHopDong As String = ""


    Public p_txtDonViCCVanTai As String = ""
    Public p_txtDiemNhanHang As String = ""
    Public p_txtPhuongThuc As String = ""

    Public p_txtTygia As String = ""
    Public p_txtToKhaiHQ As String = ""
    Public p_txtSoTK As String = ""

    Public p_txtSoHopDong As String = ""

    Public p_txtSoPXK As String = ""
    Public p_txtNgayPXK As Date

    Public p_txtCompany As String = ""


    Public p_Txt_DaiLy As String = ""
    Public p_Txt_DaiLy_DiaChi As String = ""


    Public Sub In_HoaDon(ByVal p_Form As Object, ByVal W_SoLenh As String, _
                      ByRef DtTable As DataTable, _
                        ByRef DtTable1 As DataTable, _
                        ByRef DtTable2 As DataTable,
                        ByRef SubTable As DataTable, _
                        ByVal W_ChietKhau As Long, ByVal p_Checked As Boolean)
        'If Check_in() Then
        '    Exit Sub
        'End If



        Dim srt_dt As String = String.Empty
        Dim srt_hhh As String = String.Empty
        ' Dim frmView As New frmPrint
        Dim p_SQL As String
        Dim p_RptHoasDon1 As New KV2_HoaDon1
        Dim p_RptHoasDon_Sub1 As New KV2_HoaDon_Sub1
        Dim p_RptHoasDon As New KV2_HoaDon  'KV2_HoaDonVCNB
        Dim p_RptHoasDon_Sub As New KV2_HoaDon_Sub  'KV2_HoaDonVCNB_Sub
        Dim p_Count As Integer
        Dim p_Date As DateTime

        Dim p_Form1 As U_CusForm.XtraCusForm1




        'Dim p_dtNgayXuat As Date
        'Dim p_txtThueGTGT As String
        'Dim p_txtDonViMuaHang As String
        'Dim p_txtNguoiMuaHang As String
        'Dim p_txtDiChiDonViMuaHang As String
        'Dim p_txtThoiHanThanhToan As String
        'Dim txtPhuongThuc As String
        'Dim txtDonViCCVanTai As String

        GetValue(p_Form, W_ChietKhau, SubTable)






        p_Form1 = p_Form
        p_GetCurrentDate(p_Date)


        Try

            If W_ChietKhau > 0 Then

                'rpt.Subreports(0).SetDataSource(SubTable)
                'p_RptHoasDon1.DataSource = DtTable1
                p_RptHoasDon_Sub1.DataSource = SubTable
                p_RptHoasDon1.XrSubreport1.ReportSource = p_RptHoasDon_Sub1

                ' srt_dt = Format(p_Form.dtNgayXuat.EditValue, "dd/MM/yyyy").ToString
                srt_dt = CDate(p_dtNgayHoaDon).ToString("dd/MM/yyyy")  '   Format(p_Find_Controls_Value(p_Form, "dtNgayXuat"), "dd/MM/yyyy").ToString
                p_RptHoasDon1.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
                p_RptHoasDon1.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
                p_RptHoasDon1.Parameters.Item("P_Nam").Value = srt_dt.Substring(6, 4)   ' Date.Now.Year
                'rpt.SetParameterValue("P_Nam", srt_dt.Substring(8, 2))

                'p_RptHoasDon1.Parameters.Item("P_DonViBan").Value = Me.txtDonViBanHang.Text 'hieptd4: tren phoi da in san thong tin nay
                'p_RptHoasDon1.Parameters.Item("P_DiaChi_BH").Value = Me.txtDiaChiDonViBanHang.Text 'hieptd4: tren phoi da in san thong tin nay
                'p_RptHoasDon1.Parameters.Item("P_MaSoThue_BH").Value = Me.txtMaSoThueDonViBanHang.Text 'hieptd4: tren phoi da in san thong tin nay

                p_RptHoasDon1.Parameters.Item("P_DonViMua").Value = p_txtDonViMuaHang ' DtTable.Rows(0).Item("TenKhachHang").ToString
                p_RptHoasDon1.Parameters.Item("P_NguoiMua").Value = p_txtNguoiMuaHang

                p_RptHoasDon1.Parameters.Item("P_DiaChi_MH").Value = DtTable.Rows(0).Item("DiaChi").ToString
                p_RptHoasDon1.Parameters.Item("P_ThoiHanThanhToan").Value = p_txtThoiHanThanhToan

                p_RptHoasDon1.Parameters.Item("P_MaSoThue_MH").Value = DtTable.Rows(0).Item("MaSoThue").ToString
                p_RptHoasDon1.Parameters.Item("P_TongCong").Value = Format(Convert.ToInt64(TongTien - W_ChietKhau), "n0").Replace(",", ".")

                ' 01/02/2013 QueHV Sua cach tinh thue GTGT theo cach tinh ma nghiep vu cung cap
                p_RptHoasDon1.Parameters.Item("P_ThueGTGT").Value = p_txtThueGTGT
                p_RptHoasDon1.Parameters.Item("P_TienThueGTGT").Value = Format(CInt(W_ThueGTGT), "n0").Replace(",", ".")

                'rpt.SetParameterValue("P_TienThueGTGT", Format((TongTien * Convert.ToInt64(txtThueGTGT.Text.Trim) / 100), "n0"))
                'rpt.SetParameterValue("P_TienKhac", Format(CInt(txtTienKhac.Text.Trim), "n0"))
                Dim TongThanhToan As Long = 0
                TongThanhToan = TongTien - W_ChietKhau + W_ThueGTGT
                'TongThanhToan = TongTien + TienPhiKhac + (TongTien * Convert.ToInt64(txtThueGTGT.Text.Trim) / 100)
                p_RptHoasDon1.Parameters.Item("P_TongThanhToan").Value = Format(TongThanhToan, "n0").Replace(",", ".")

                p_RptHoasDon1.Parameters.Item("P_TongBangChu").Value = mdlFunction.Number2Text(CLng(TongThanhToan)) + " đồng chẵn"
                p_RptHoasDon1.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
                'p_RptHoasDon1.Parameters.Item("P_MaKhachHang").Value = DtTable.Rows(0).Item("MaKhachHang").ToString
                p_RptHoasDon1.Parameters.Item("P_MaKhachHang").Value = DtTable.Rows(0).Item("MaKhachHang").Substring(DtTable.Rows(0).Item("MaKhachHang").Length - 6)
                p_RptHoasDon1.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
                '  p_RptHoasDon1.Parameters.Item("P_MaTimKiem").Value = DtTable.Rows(0).Item("MaTimKiem").ToString ' "HiepTD4 test Mã tìm kiếm" 'hieptd4 test
                p_RptHoasDon1.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
                p_RptHoasDon1.Parameters.Item("P_SoNiem").Value = DtTable.Rows(0).Item("Niem").ToString
                Dim times As DateTime = Get_ThoiGianDau(DtTable.Rows(0).Item("SoLenh"))     'p_Date 'Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
                p_RptHoasDon1.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd/MM/yyyy}", times)
                p_RptHoasDon1.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString


                For Each r As DataRow In DtTable2.Rows
                    'srt_hhh += "N" + r.Item("HHH").ToString + ";"
                    srt_hhh += "H" + r.Item("HHH").ToString + ";"
                Next

                p_RptHoasDon1.Parameters.Item("P_KhoangCachTamMuc").Value = srt_hhh
                p_RptHoasDon1.Parameters.Item("P_PhuongThucTT").Value = txtPhuongThuc
                p_RptHoasDon1.Parameters.Item("P_DonViCungCapVanTai").Value = txtDonViCCVanTai
                p_RptHoasDon1.Parameters.Item("P_ChietKhauThuongMai").Value = Format(W_ChietKhau, "n0").Replace(",", ".")
                For p_Count = 0 To p_RptHoasDon1.Parameters.Count - 1
                    p_RptHoasDon1.Parameters(p_Count).Visible = False
                Next
                p_RptHoasDon1.RequestParameters = False
                If p_Form.chkCheck.Checked Then
                    p_RptHoasDon1.PrinterName = g_DefaultPrint
                    p_RptHoasDon1.Print()
                Else
                    p_RptHoasDon1.ShowPreviewDialog()
                End If
            Else
                Try
                    p_RptHoasDon_Sub.DataSource = SubTable
                    p_RptHoasDon.XrSubreport1.ReportSource = p_RptHoasDon_Sub

                    srt_dt = CDate(p_dtNgayHoaDon).ToString("dd/MM/yyyy")

                    p_RptHoasDon.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
                    p_RptHoasDon.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
                    p_RptHoasDon.Parameters.Item("P_Nam").Value = srt_dt.Substring(6, 4)  'Date.Now.Year

                    'p_RptHoasDon.Parameters.Item("P_DonViBan").Value = Me.txtDonViBanHang.Text 'hieptd4: tren phoi da in san thong tin nay
                    'p_RptHoasDon.Parameters.Item("P_DiaChi_BH").Value = Me.txtDiaChiDonViBanHang.Text 'hieptd4: tren phoi da in san thong tin nay
                    'p_RptHoasDon.Parameters.Item("P_MaSoThue_BH").Value = Me.txtMaSoThueDonViBanHang.Text 'hieptd4: tren phoi da in san thong tin nay
                    p_RptHoasDon.Parameters.Item("P_LenhXuat").Value = "( Theo lệnh xuất số " + DtTable.Rows(0).Item("SoLenh") + " - " + srt_dt + " )"

                    p_RptHoasDon.Parameters.Item("P_DonViMua").Value = p_txtDonViMuaHang ',   ' p_Form.Me.txtDonViMuaHang.Text '  DtTable.Rows(0).Item("TenKhachHang").ToString
                    p_RptHoasDon.Parameters.Item("P_NguoiMua").Value = p_txtNguoiMuaHang  'p_Form.txtNguoiMuaHang.Text

                    'p_RptHoasDon.Parameters.Item("P_DiaChi_MH").Value = DtTable.Rows(0).Item("DiaChi").ToString                   
                    p_RptHoasDon.Parameters.Item("P_DiaChi_MH").Value = p_txtDiChiDonViMuaHang  ' p_Form.txtDiChiDonViMuaHang.Text
                    '
                    p_RptHoasDon.Parameters.Item("P_ThoiHanThanhToan").Value = p_txtThoiHanThanhToan   'p_Form.txtThoiHanThanhToan.Text

                    p_RptHoasDon.Parameters.Item("P_MaSoThue_MH").Value = DtTable.Rows(0).Item("MaSoThue").ToString
                    p_RptHoasDon.Parameters.Item("P_TongCong").Value = Format(Convert.ToInt64(Convert.ToInt64(TongTien) - W_ChietKhau), "n0").Replace(",", ".")

                    ' 01/02/2013 QueHV Sua cach tinh thue GTGT theo cach tinh ma nghiep vu cung cap
                    Try
                        p_RptHoasDon.Parameters.Item("P_ThueGTGT").Value = CInt(p_txtThueGTGT) ' p_Form.txtThueGTGT.Text.Trim
                        p_RptHoasDon.Parameters.Item("P_TienThueGTGT").Value = Format(CInt(W_ThueGTGT), "n0").Replace(",", ".")
                    Catch ex As Exception

                    End Try
                    

                    'rpt.SetParameterValue("P_TienThueGTGT", Format((TongTien * Convert.ToInt64(txtThueGTGT.Text.Trim) / 100), "n0"))
                    'rpt.SetParameterValue("P_TienKhac", Format(CInt(txtTienKhac.Text.Trim), "n0"))
                    Dim TongThanhToan As Long = 0
                    TongThanhToan = TongTien - W_ChietKhau + CInt(W_ThueGTGT)  ''p_Form.W_ThueGTGT
                    'TongThanhToan = TongTien + TienPhiKhac + (TongTien * Convert.ToInt64(txtThueGTGT.Text.Trim) / 100)
                    p_RptHoasDon.Parameters.Item("P_TongThanhToan").Value = Format(TongThanhToan, "n0").Replace(",", ".")

                    p_RptHoasDon.Parameters.Item("P_TongBangChu").Value = mdlFunction.Number2Text(CLng(TongThanhToan)) + " đồng chẵn"
                    p_RptHoasDon.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
                    'p_RptHoasDon.Parameters.Item("P_MaKhachHang").Value = DtTable.Rows(0).Item("MaKhachHang").ToString
                    p_RptHoasDon.Parameters.Item("P_MaKhachHang").Value = DtTable.Rows(0).Item("MaKhachHang").Substring(DtTable.Rows(0).Item("MaKhachHang").Length - 6)
                    p_RptHoasDon.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
                    p_RptHoasDon.Parameters.Item("P_MaTimKiem").Value = DtTable.Rows(0).Item("MaTimKiem").ToString ' "HiepTD4 test Mã tìm kiếm" 'hieptd4 test
                    p_RptHoasDon.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
                    p_RptHoasDon.Parameters.Item("P_SoNiem").Value = DtTable.Rows(0).Item("Niem").ToString
                    Dim times As DateTime = Get_ThoiGianDau(DtTable.Rows(0).Item("SoLenh"))    ' p_Date   ' Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
                    p_RptHoasDon.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd/MM/yyyy}", times)
                    p_RptHoasDon.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString


                    For Each r As DataRow In DtTable2.Rows
                        'srt_hhh += "N" + r.Item("HHH").ToString + ";"
                        srt_hhh += "H" + r.Item("HHH").ToString + ";"
                    Next

                    p_RptHoasDon.Parameters.Item("P_KhoangCachTamMuc").Value = srt_hhh
                    p_RptHoasDon.Parameters.Item("P_PhuongThucTT").Value = txtPhuongThuc
                    p_RptHoasDon.Parameters.Item("P_DonViCungCapVanTai").Value = txtDonViCCVanTai
                    'p_RptHoasDon.Parameters.Item("P_ChietKhauThuongMai").Value = Format(W_ChietKhau, "n0").Replace(",", ".")
                    For p_Count = 0 To p_RptHoasDon.Parameters.Count - 1
                        p_RptHoasDon.Parameters(p_Count).Visible = False
                    Next
                    p_RptHoasDon.RequestParameters = False
                    If p_Checked = True Then
                        p_RptHoasDon.PrinterName = g_DefaultPrint
                        p_RptHoasDon.Print()
                    Else
                        p_RptHoasDon.ShowPreviewDialog()
                    End If
                    'p_RptHoasDon.ShowPreviewDialog()
                Catch ex As Exception

                End Try

            End If


            Exit Sub
            '------------------------------------------------------------
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ShowMessageBox("", ex.Message)
        End Try
    End Sub


    Private Function p_Find_Controls_Value(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_ControlName As String) As String
        Dim p_Control() As Object
        Try
            p_Find_Controls_Value = ""
            p_Control = p_Form.Controls.Find(p_ControlName.ToString.Trim, True)

            If p_Control.Length > 0 Then
                If Not p_Control(0).editvalue Is Nothing Then
                    p_Find_Controls_Value = p_Control(0).editvalue.ToString.Trim
                End If

            End If
        Catch ex As Exception

        End Try
    End Function


    Private Sub GetValue(ByVal p_Form As Object, ByVal W_ChietKhau As Long, ByVal SubTable As DataTable)

        On Error Resume Next


        ' p_dtpDieuDong As Date
        ' p_dtNgayXuat As Date
        ' p_txtThueGTGT As String = ""
        ' p_txtDonViMuaHang As String = ""
        ' p_txtNguoiMuaHang As String = ""
        ' p_txtDiChiDonViMuaHang As String = ""
        ' p_txtThoiHanThanhToan As String = ""
        'Public txtPhuongThuc As String = ""
        'Public txtDonViCCVanTai As String = ""
        'Public p_txtSoLenh As String = ""

        'Public p_txtDonViGiaoHang As String = ""
        'Public p_txtDiaChiDonViGiaoHang As String = ""
        'Public p_txtDonViNhanHang As String = ""
        'Public p_txtDiaChiDonViNhanHang As String = ""
        'Public p_txtDiemGiaoHang As String = ""
        'Public p_txtKhoNhap As String = ""
        'Public p_txtDonViCungCapVanTai As String = ""
        'Public TongTien As Decimal = 0
        'Public W_ThueGTGT As Int64 = 0
        'Public p_txtMST As String = ""
        'Public p_txtMST2 As String = ""
        'Public p_txtSoTaiKhoan1 As String = ""
        'Public p_txtSoTaiKhoan2 As String = ""
        'Public p_txtNgayHopDong As String = ""


        'Public p_txtDonViCCVanTai As String = ""
        'Public p_txtDiemNhanHang As String = ""
        'Public p_txtPhuongThuc As String = ""

        'Public p_txtTygia As String = ""
        'Public p_txtToKhaiHQ As String = ""
        'Public p_txtSoTK As String = ""

        'Public p_txtSoHopDong As String = ""

        'Public p_txtSoPXK As String = ""
        'Public p_txtNgayPXK As Date

        'Public p_txtCompany As String = ""


        p_dtNgayXuat = Now.Date
        p_dtpDieuDong = Now.Date
     

        p_dtNgayXuat = CDate(p_Find_Controls_Value(p_Form, "dtNgayXuat"))
        p_dtNgayHoaDon = CDate(p_Find_Controls_Value(p_Form, "dtNgayHoaDon"))

        p_dtpDieuDong = CDate(p_Find_Controls_Value(p_Form, "dtpDieuDong"))
        p_txtThueGTGT = p_Find_Controls_Value(p_Form, "txtThueGTGT")
        ' p_txtThueGTGT = Convert.ToInt64(p_txtThueGTGT)
        p_txtDonViMuaHang = p_Find_Controls_Value(p_Form, "txtDonViMuaHang")
        p_txtNguoiMuaHang = p_Find_Controls_Value(p_Form, "txtNguoiMuaHang")
        p_txtDiChiDonViMuaHang = p_Find_Controls_Value(p_Form, "txtDiChiDonViMuaHang")
        p_txtThoiHanThanhToan = p_Find_Controls_Value(p_Form, "txtThoiHanThanhToan")
        txtPhuongThuc = p_Find_Controls_Value(p_Form, "txtPhuongThuc")
        txtDonViCCVanTai = p_Find_Controls_Value(p_Form, "txtDonViCCVanTai")
        p_txtSoLenh = p_Find_Controls_Value(p_Form, "txtSoLenh")
        p_txtDonViGiaoHang = p_Find_Controls_Value(p_Form, "txtDonViGiaoHang")
        '   TongTien = Format(TongTien, "n0").Replace(",", ".")
        p_txtDiaChiDonViGiaoHang = p_Find_Controls_Value(p_Form, "txtDiaChiDonViGiaoHang")
        p_txtDonViNhanHang = p_Find_Controls_Value(p_Form, "txtDonViNhanHang")
        p_txtDiaChiDonViNhanHang = p_Find_Controls_Value(p_Form, "txtDiaChiDonViNhanHang")
        p_txtDiemGiaoHang = p_Find_Controls_Value(p_Form, "txtDiemGiaoHang")

        p_txtKhoNhap = p_Find_Controls_Value(p_Form, "txtKhoNhap")
        p_txtDonViCungCapVanTai = p_Find_Controls_Value(p_Form, "txtDonViCungCapVanTai")

        p_txtMST = p_Find_Controls_Value(p_Form, "txtMST")
        p_txtMST2 = p_Find_Controls_Value(p_Form, "txtMST2")


        p_txtSoTaiKhoan1 = p_Find_Controls_Value(p_Form, "txtSoTaiKhoan1")
        p_txtSoTaiKhoan2 = p_Find_Controls_Value(p_Form, "txtSoTaiKhoan2")
        p_txtNgayHopDong = p_Find_Controls_Value(p_Form, "txtNgayHopDong")

        p_txtDonViCCVanTai = p_Find_Controls_Value(p_Form, "txtDonViCCVanTai")
        p_txtDiemNhanHang = p_Find_Controls_Value(p_Form, "txtDiemNhanHang")
        p_txtPhuongThuc = p_Find_Controls_Value(p_Form, "txtPhuongThuc")


        p_txtTygia = p_Find_Controls_Value(p_Form, "txtTygia")
        p_txtToKhaiHQ = p_Find_Controls_Value(p_Form, "txtToKhaiHQ")
        p_txtSoTK = p_Find_Controls_Value(p_Form, "txtSoTK")

        p_txtSoHopDong = p_Find_Controls_Value(p_Form, "txtSoHopDong")

        p_txtCompany = p_Find_Controls_Value(p_Form, "txtCompany")

        p_txtSoPXK = p_Find_Controls_Value(p_Form, "txtSoPXK")
        p_txtNgayPXK = CDate(p_Find_Controls_Value(p_Form, "txtNgayPXK")).ToString("dd/MM/yyyy")


        p_Txt_DaiLy = p_Find_Controls_Value(p_Form, "TextBox2")
        p_Txt_DaiLy_DiaChi = p_Find_Controls_Value(p_Form, "TextBox1")


        TongTien = 0
        For p_Count = 0 To SubTable.Rows.Count - 1
            TongTien = TongTien + SubTable.Rows(p_Count).Item("nThanhTien")  ' CDbl(SubTable.Rows(p_Count).Item("ThanhTien").Replace(",", "."))
        Next



        'p_dtNgayXuat = CDate(p_Find_Controls_Value(p_Form, "dtNgayXuat")).ToString("dd/MM/yyyy")
        'p_txtThueGTGT = p_Find_Controls_Value(p_Form, "txtThueGTGT")
        '' p_txtThueGTGT = Convert.ToInt64(p_txtThueGTGT)
        'p_txtDonViMuaHang = p_Find_Controls_Value(p_Form, "txtDonViMuaHang")
        'p_txtNguoiMuaHang = p_Find_Controls_Value(p_Form, "txtNguoiMuaHang")
        'p_txtDiChiDonViMuaHang = p_Find_Controls_Value(p_Form, "txtDiChiDonViMuaHang")
        'p_txtThoiHanThanhToan = p_Find_Controls_Value(p_Form, "txtThoiHanThanhToan")
        'txtPhuongThuc = p_Find_Controls_Value(p_Form, "txtPhuongThuc")
        'txtDonViCCVanTai = p_Find_Controls_Value(p_Form, "txtDonViCCVanTai")


        '   TongTien = Format(TongTien, "n0").Replace(",", ".")


        W_ThueGTGT = Math.Round(((TongTien - W_ChietKhau) * CDbl(IIf(p_txtThueGTGT.ToString.Trim = "", 0, p_txtThueGTGT.ToString.Trim))) / 100, 0)






    End Sub


    Public Sub In_HoaDon_HangGiuHo(ByVal p_Form As Object, ByVal W_SoLenh As String, _
                      ByRef DtTable As DataTable, _
                        ByRef DtTable1 As DataTable, _
                        ByRef DtTable2 As DataTable,
                        ByRef SubTable As DataTable, _
                        ByVal W_ChietKhau As Long, ByVal p_Checked As Boolean)

        Dim srt_dt As String = String.Empty
        Dim srt_hhh As String = String.Empty
        Dim srt_dieudong As String = String.Empty
        Dim rpt As New KV2_HoaDonHangGiuHo
        Dim rpt_sub As New KV2_HoaDonHangGiuHo_Sub
        Dim p_Count As Integer

        Dim p_Date As DateTime

        Try

            p_GetCurrentDate(p_Date)


            GetValue(p_Form, W_ChietKhau, SubTable)


            'rpt.DataSource = SubTable
            rpt_sub.DataSource = SubTable
            rpt.XrSubreport1.ReportSource = rpt_sub

            ' rpt.Parameters.Item("CongTy").Value = "CÔNG TY XĂNG DẦU TÂY NAM BỘ" 'ToUpper()

            srt_dt = Format(p_dtNgayXuat).ToString
            srt_dieudong = p_dtpDieuDong.ToString("dd-MM-yyyy")
            rpt.Parameters.Item("P_Ngay").Value = srt_dieudong.Substring(0, 2)
            rpt.Parameters.Item("P_Thang").Value = srt_dieudong.Substring(3, 2)
            rpt.Parameters.Item("P_Nam").Value = Right(srt_dieudong.ToString.Trim, 4)   ' srt_dieudong.Substring(6, 4)

            rpt.Parameters.Item("P_NgayDieuDong").Value = srt_dieudong.Substring(0, 2)
            rpt.Parameters.Item("P_ThangDieuDong").Value = srt_dieudong.Substring(3, 2)
            rpt.Parameters.Item("P_NamDieuDong").Value = Right(srt_dieudong.ToString.Trim, 4)

            'rpt.SetParameterValue("P_Nam", srt_dt.Substring(8, 2))

            rpt.Parameters.Item("P_SoLenh").Value = p_txtSoLenh
            rpt.Parameters.Item("P_CuaDonVi").Value = DtTable.Rows(0).Item("TenDonVi").ToString  'hieptd4 add for test
            rpt.Parameters.Item("P_DonViGiaoHang").Value = p_txtDonViGiaoHang
            rpt.Parameters.Item("P_DonViGiaoHangDiaChi").Value = p_txtDiaChiDonViGiaoHang
            rpt.Parameters.Item("P_DonViMua").Value = p_txtDonViNhanHang
            rpt.Parameters.Item("P_DiaChi_MH").Value = p_txtDiaChiDonViNhanHang
            'rpt.SetParameterValue("P_DonViMua", DtTable.Rows(0).Item("TenKhachHang").ToString)
            'rpt.SetParameterValue("P_DiaChi_MH", DtTable.Rows(0).Item("DiaChi").ToString)

            rpt.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            'rpt.SetParameterValue("P_MaTienKiem", DtTable.Rows(0).Item("SoLenh").ToString)
            rpt.Parameters.Item("P_MaTimKiem").Value = DtTable.Rows(0).Item("MaTimKiem").ToString
            rpt.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
            rpt.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
            rpt.Parameters.Item("P_SoNiem").Value = DtTable.Rows(0).Item("Niem").ToString
            rpt.Parameters.Item("P_DiemGiaoHang").Value = p_txtDiemGiaoHang
            rpt.Parameters.Item("P_KhoNhap").Value = p_txtKhoNhap
            rpt.Parameters.Item("P_DonViCCVanTai").Value = p_txtDonViCungCapVanTai

            For Each r As DataRow In DtTable2.Rows
                'srt_hhh += "N" + r.Item("HHH").ToString + ";"
                srt_hhh += "H" + r.Item("HHH").ToString + ";"
            Next

            rpt.Parameters.Item("P_KhoangCachTamMuc").Value = srt_hhh

            Dim times As DateTime = p_Date   'Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
            rpt.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd.MM.yyyy}", times)
            'rpt.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString
            rpt.Parameters.Item("P_NgayGiaoDich").Value += "/" & String.Format("{0}:{1}", times.Hour, times.Minute)

            'Update Dữ liệu vào bảng tblThongTinHoaDon
            For p_Count = 0 To rpt.Parameters.Count - 1
                rpt.Parameters.Item(p_Count).Visible = False
            Next
            '----------------------
            If p_Checked = True Then
                rpt.PrinterName = g_DefaultPrint
                rpt.Print()
            Else
                rpt.ShowPreviewDialog()
            End If

        Catch ex As Exception

        End Try
    End Sub



    Public Sub HoaDonTaiXuat(ByVal p_Form As Object, ByVal W_SoLenh As String, _
                      ByRef DtTable As DataTable, _
                        ByRef DtTable1 As DataTable, _
                        ByRef DtTable2 As DataTable,
                        ByRef SubTable As DataTable, _
                        ByVal W_ChietKhau As Long, ByVal p_Checked As Boolean)

        Dim srt_dt As String = String.Empty
        Dim srt_hhh As String = String.Empty
        Dim srt_dieudong As String = String.Empty
        Dim dtSet As DataSet
        Dim p_SQL As String
        Dim p_Count As Integer
        'Dim frmView As New frmPrint
        Try


            Dim rpt As New KV2_HoaDonTaiXuat
            Dim rptsub As New KV2_HoaDonTaiXuat_Sub

            Dim p_Date As DateTime


            p_GetCurrentDate(p_Date)




            GetValue(p_Form, W_ChietKhau, SubTable)

            'rpt.Subreports(0).SetDataSource(SubTable)

            'For p_Count = 0 To rpt.Parameters.Count - 1
            '    rpt.Parameters.Item(p_Count).Visible = False
            'Next
            rptsub.DataSource = SubTable
            rpt.XrSubreport1.ReportSource = rptsub

            srt_dt = Format(p_dtNgayXuat, "dd/MM/yyyy").ToString
            srt_dieudong = Format(p_dtNgayXuat, "dd/MM/yyyy").ToString

            rpt.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)

            rpt.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
            rpt.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
            rpt.Parameters.Item("P_Nam").Value = srt_dieudong.Substring(6, 4)

            rpt.Parameters.Item("P_NguoiBan").Value = p_txtDonViGiaoHang
            rpt.Parameters.Item("P_DiaChi_BH").Value = p_txtDiaChiDonViGiaoHang
            rpt.Parameters.Item("P_MST_BH").Value = p_txtMST
            rpt.Parameters.Item("P_DonViMua").Value = p_txtDonViNhanHang
            rpt.Parameters.Item("P_DiaChi_MH").Value = p_txtDiaChiDonViNhanHang
            rpt.Parameters.Item("P_MaSoThue_MH").Value = p_txtMST2  ' "MST(Tax code): " & txtMST2.Text
            rpt.Parameters.Item("P_SoTaiKhoan_BH").Value = p_txtSoTaiKhoan1
            rpt.Parameters.Item("P_SoTaiKhoan_MH").Value = p_txtSoTaiKhoan2
            rpt.Parameters.Item("P_NgayHopDong").Value = p_txtNgayHopDong

            rpt.Parameters.Item("P_TongCong").Value = Format(TongTien, "n0").Replace(",", ".") ' Format(TongTien, "n0").Replace(").Value = ").Value =  ".")
            rpt.Parameters.Item("P_TongBangChu").Value = mdlFunction.Number2Text(CLng(TongTien)) & " Đô la Mỹ chẵn" & " (" & mdlFunction.Number2Text_EN(CLng(TongTien)) & ")"

            rpt.Parameters.Item("P_NgayVanDon").Value = srt_dt
            rpt.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
            rpt.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
            rpt.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            rpt.Parameters.Item("P_DonViCungCapVanTai").Value = p_txtDonViCCVanTai
            rpt.Parameters.Item("P_DiemNhanHang").Value = p_txtDiemNhanHang
            rpt.Parameters.Item("P_PhuongThucTT").Value = p_txtPhuongThuc
            rpt.Parameters.Item("P_ThoiHanThanhToan").Value = p_txtThoiHanThanhToan
            rpt.Parameters.Item("P_TyGia").Value = p_txtTygia
            rpt.Parameters.Item("P_TKHQ").Value = p_txtToKhaiHQ
            rpt.Parameters.Item("P_STK").Value = p_txtSoTK

            Dim times As DateTime = p_Date   'Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
            rpt.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd.MM.yyyy}", times)  'String.Format("{0:dd.MM.yyyy}").Value =  times)
            rpt.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString

            'Update Dữ liệu vào bảng tblThongTinHoaDon

            '----------------------
            'If Me.U_CheckBox1.Checked Then
            '    rpt.PrintOptions.PrinterName = _DefaultPrint
            '    rpt.PrintToPrinter(1, False, 0, 0)
            'Else
            '    frmView.crViewer.ReportSource = rpt
            '    frmView.ShowDialog()
            'End If
            For p_Count = 0 To rpt.Parameters.Count - 1
                rpt.Parameters(p_Count).Visible = False
            Next
            rpt.RequestParameters = False

            If p_Checked = True Then
                rpt.PrinterName = g_DefaultPrint
                rpt.Print()
            Else
                rpt.ShowPreviewDialog()
            End If

        Catch ex As Exception
            ShowMessageBox("", ex.Message)
        End Try


    End Sub







    Public Sub HoaDonTaiXuat_En(ByVal p_Form As Object, ByVal W_SoLenh As String, _
                      ByRef DtTable As DataTable, _
                        ByRef DtTable1 As DataTable, _
                        ByRef DtTable2 As DataTable,
                        ByRef SubTable As DataTable, _
                        ByVal W_ChietKhau As Long, ByVal p_Checked As Boolean)



        Dim srt_dt As String = String.Empty
        Dim srt_hhh As String = String.Empty
        Dim srt_dieudong As String = String.Empty
        Dim dtSet As DataSet
        Dim p_SQL As String
        Dim p_Count As Integer
        'Dim frmView As New frmPrint
        Dim p_Date As DateTime

        Try

            Dim rpt As New KV2_HoaDonTaiXuat_EN
            Dim rptsub As New KV2_HoaDonTaiXuat_Sub_EN

            p_GetCurrentDate(p_Date)
            GetValue(p_Form, W_ChietKhau, SubTable)




            rptsub.DataSource = SubTable
            rpt.XrSubreport1.ReportSource = rptsub

            srt_dt = Format(p_dtNgayHoaDon, "dd/MM/yyyy").ToString
            srt_dieudong = Format(p_dtNgayXuat, "dd/MM/yyyy").ToString

            rpt.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)

            rpt.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
            rpt.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
            rpt.Parameters.Item("P_Nam").Value = srt_dieudong.Substring(6, 4)

            'rpt.Parameters.Item("P_NguoiBan").Value = txtDonViGiaoHang.Text
            'rpt.Parameters.Item("P_DiaChi_BH").Value = txtDiaChiDonViGiaoHang.Text
            'rpt.Parameters.Item("P_MST_BH").Value = txtMST1.Text
            rpt.Parameters.Item("P_DonViMua").Value = p_txtDonViNhanHang
            rpt.Parameters.Item("P_DiaChi_MH").Value = p_txtDiaChiDonViNhanHang
            rpt.Parameters.Item("P_MaSoThue_MH").Value = p_txtMST2  ' "MST(Tax code): " & txtMST2.Text
            rpt.Parameters.Item("P_SoTaiKhoan_BH").Value = p_txtSoTaiKhoan1
            rpt.Parameters.Item("P_SoTaiKhoan_MH").Value = p_txtSoTaiKhoan2
            rpt.Parameters.Item("p_SoHopDong").Value = p_txtSoHopDong
            rpt.Parameters.Item("P_NgayHopDong").Value = p_txtNgayHopDong.Replace("/", ".")

            'rpt.Parameters.Item("P_TongCong").Value = Format(TongTien, "n0").Replace(",", ".") ' Format(TongTien, "n0").Replace(").Value = ").Value =  ".")
            rpt.Parameters.Item("P_TongCong").Value = Format(TongTien, "n2").Replace(".", "@")
            rpt.Parameters.Item("P_TongCong").Value = rpt.Parameters.Item("P_TongCong").Value.Replace(",", ".")
            rpt.Parameters.Item("P_TongCong").Value = rpt.Parameters.Item("P_TongCong").Value.Replace("@", ",")
            rpt.Parameters.Item("p_TongThanhToan").Value = rpt.Parameters.Item("P_TongCong").Value + rpt.Parameters.Item("p_TienThue").Value
            'rpt.Parameters.Item("P_TongBangChu").Value = mdlFunction.Number2Text(CLng(TongTien)) & " Đô la Mỹ chẵn" & " (" & mdlFunction.Number2Text_EN(CLng(TongTien)) & ")"
            'rpt.Parameters.Item("P_TongBangChu").Value = mdlFunction.Number2Text_EN(CLng(TongTien))
            rpt.Parameters.Item("P_TongBangChu").Value = mdlFunction.Number2Text_EN(TongTien)
            rpt.Parameters.Item("P_NgayVanDon").Value = srt_dt.Replace("/", ".")
            rpt.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
            rpt.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
            rpt.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            rpt.Parameters.Item("P_DonViCungCapVanTai").Value = p_txtDonViCCVanTai
            'rpt.Parameters.Item("P_DiemGiaoHang").Value =  txtDiemGiaoHang.Text)
            rpt.Parameters.Item("P_DiemNhanHang").Value = p_txtDiemNhanHang
            rpt.Parameters.Item("P_PhuongThucTT").Value = p_txtPhuongThuc
            rpt.Parameters.Item("P_ThoiHanThanhToan").Value = p_txtThoiHanThanhToan
            rpt.Parameters.Item("P_TyGia").Value = p_txtTygia
            rpt.Parameters.Item("P_TKHQ").Value = p_txtToKhaiHQ
            rpt.Parameters.Item("P_STK").Value = p_txtSoTK
            rpt.Parameters.Item("p_PXK").Value = "According to PXK no. " + p_txtSoPXK + " - " + Format(p_txtNgayPXK, "ddMMyyyy").ToString

            'Dim times As Date = Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
            'rpt.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd.MM.yyyy}", times)  'String.Format("{0:dd.MM.yyyy}").Value =  times)
            'rpt.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString
            Dim times As DateTime = p_Date   ' DtTable.Rows(0).Item("NgayXuat").ToString
            rpt.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd.MM.yyyy}", times)
            rpt.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString

            'Update Dữ liệu vào bảng tblThongTinHoaDon

            '----------------------
            'If Me.U_CheckBox1.Checked Then
            '    rpt.PrintOptions.PrinterName = _DefaultPrint
            '    rpt.PrintToPrinter(1, False, 0, 0)
            'Else
            '    frmView.crViewer.ReportSource = rpt
            '    frmView.ShowDialog()
            'End If
            For p_Count = 0 To rpt.Parameters.Count - 1
                rpt.Parameters(p_Count).Visible = False
            Next
            rpt.RequestParameters = False

            If p_Checked = True Then
                rpt.PrinterName = g_DefaultPrint
                rpt.Print()
            Else
                rpt.ShowPreviewDialog()
            End If



        Catch ex As Exception
            ShowMessageBox("", ex.Message)
        End Try

    End Sub





    Public Sub HoaDonTaiXuat_VN(ByVal p_Form As Object, ByVal W_SoLenh As String, _
                      ByRef DtTable As DataTable, _
                        ByRef DtTable1 As DataTable, _
                        ByRef DtTable2 As DataTable,
                        ByRef SubTable As DataTable, _
                        ByVal W_ChietKhau As Long, ByVal p_Checked As Boolean)


        Dim srt_dt As String = String.Empty
        Dim srt_hhh As String = String.Empty
        Dim srt_dieudong As String = String.Empty
        Dim dtSet As DataSet
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim DecimalPlace As Integer
        Dim p_Date As DateTime
        'Dim frmView As New frmPrint
        Try

            p_GetCurrentDate(p_Date)

            Dim rpt As New KV2_HoaDonTaiXuat_VN
            Dim rptsub As New KV2_HoaDonTaiXuat_Sub_VN

            GetValue(p_Form, W_ChietKhau, SubTable)


            rptsub.DataSource = SubTable
            rpt.XrSubreport1.ReportSource = rptsub

            srt_dt = Format(p_dtNgayHoaDon, "dd/MM/yyyy").ToString
            srt_dieudong = Format(p_dtNgayXuat, "dd/MM/yyyy").ToString

            rpt.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)

            rpt.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
            rpt.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
            rpt.Parameters.Item("P_Nam").Value = srt_dieudong.Substring(6, 4)

            'rpt.Parameters.Item("P_NguoiBan").Value = txtDonViGiaoHang.Text
            'rpt.Parameters.Item("P_DiaChi_BH").Value = txtDiaChiDonViGiaoHang.Text
            'rpt.Parameters.Item("P_MST_BH").Value = txtMST1.Text
            rpt.Parameters.Item("P_DonViMua").Value = p_txtDonViNhanHang
            rpt.Parameters.Item("P_DiaChi_MH").Value = p_txtDiaChiDonViNhanHang
            rpt.Parameters.Item("P_MaSoThue_MH").Value = p_txtMST2
            rpt.Parameters.Item("P_SoTaiKhoan_BH").Value = p_txtSoTaiKhoan1
            rpt.Parameters.Item("P_SoTaiKhoan_MH").Value = p_txtSoTaiKhoan2
            rpt.Parameters.Item("p_SoHopDong").Value = p_txtSoHopDong

            rpt.Parameters.Item("p_DaiLy").Value = p_Txt_DaiLy
            rpt.Parameters.Item("p_DaiLy_DiaChi").Value = p_Txt_DaiLy_DiaChi

            Try
                rpt.Parameters.Item("P_NgayHopDong").Value = CDate(p_txtNgayHopDong).ToString("dd/MM/yyyy")   '.ToString  '.Replace("/", ".")
            Catch ex As Exception

            End Try


            'rpt.Parameters.Item("P_TongCong").Value = Format(TongTien, "n0").Replace(",", ".") ' Format(TongTien, "n0").Replace(").Value = ").Value =  ".")
            rpt.Parameters.Item("P_TongCong").Value = Format(TongTien, "n2").Replace(".", "@")
            rpt.Parameters.Item("P_TongCong").Value = rpt.Parameters.Item("P_TongCong").Value.Replace(",", ".")
            rpt.Parameters.Item("P_TongCong").Value = rpt.Parameters.Item("P_TongCong").Value.Replace("@", ",")
            rpt.Parameters.Item("p_TongThanhToan").Value = rpt.Parameters.Item("P_TongCong").Value + rpt.Parameters.Item("p_TienThue").Value
            'rpt.Parameters.Item("P_TongBangChu").Value = mdlFunction.Number2Text(CLng(TongTien)) & " Đô la Mỹ chẵn" & " (" & mdlFunction.Number2Text_EN(CLng(TongTien)) & ")"
            DecimalPlace = (TongTien - Int(TongTien)) * 100 '(TongTien - CLng(TongTien)) * 100
            If DecimalPlace > 0 Then
                rpt.Parameters.Item("P_TongBangChu").Value = mdlFunction.Number2Text(Int(TongTien)) & " Đô la Mỹ và " & mdlFunction.Number2Text(Int(DecimalPlace)) & " xu chẵn"
            Else
                rpt.Parameters.Item("P_TongBangChu").Value = mdlFunction.Number2Text(Int(TongTien)) & " Đô la Mỹ chẵn"
            End If


            rpt.Parameters.Item("P_NgayVanDon").Value = srt_dt.Replace("/", ".")
            rpt.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
            rpt.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
            rpt.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            rpt.Parameters.Item("P_DonViCungCapVanTai").Value = p_txtDonViCCVanTai
            rpt.Parameters.Item("p_MaTimKiem").Value = DtTable.Rows(0).Item("MaTimKiem").ToString
            rpt.Parameters.Item("P_DiemGiaoHang").Value = p_txtDiemGiaoHang
            rpt.Parameters.Item("P_DiemNhanHang").Value = p_txtDiemNhanHang
            rpt.Parameters.Item("P_PhuongThucTT").Value = p_txtPhuongThuc
            rpt.Parameters.Item("P_ThoiHanThanhToan").Value = p_txtThoiHanThanhToan
            rpt.Parameters.Item("P_TyGia").Value = p_txtTygia
            rpt.Parameters.Item("P_TKHQ").Value = p_txtToKhaiHQ
            rpt.Parameters.Item("P_STK").Value = p_txtSoTK
            rpt.Parameters.Item("p_PXK").Value = "Theo PXK số " + p_txtSoPXK + " - " + Format(p_txtNgayPXK, "ddMMyyyy").ToString

            'Dim times As Date = Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
            'rpt.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd.MM.yyyy}", times)  
            'rpt.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString
            Dim times As DateTime = Get_ThoiGianDau(DtTable.Rows(0).Item("SoLenh").ToString)    ' p_Date  ' DtTable.Rows(0).Item("NgayXuat").ToString
            rpt.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd.MM.yyyy}", times)
            rpt.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString

            'Update Dữ liệu vào bảng tblThongTinHoaDon

            '----------------------
            'If Me.U_CheckBox1.Checked Then
            '    rpt.PrintOptions.PrinterName = _DefaultPrint
            '    rpt.PrintToPrinter(1, False, 0, 0)
            'Else
            '    frmView.crViewer.ReportSource = rpt
            '    frmView.ShowDialog()
            'End If
            For p_Count = 0 To rpt.Parameters.Count - 1
                rpt.Parameters(p_Count).Visible = False
            Next
            rpt.RequestParameters = False

            If p_Checked = True Then
                rpt.PrinterName = g_DefaultPrint
                rpt.Print()
            Else
                rpt.ShowPreviewDialog()
            End If

        Catch ex As Exception
            ShowMessageBox("", ex.Message)
        End Try

    End Sub



    Public Sub HoaDonTaiXuat_VCNB(ByVal p_Form As Object, ByVal W_SoLenh As String, _
                      ByRef DtTable As DataTable, _
                        ByRef DtTable1 As DataTable, _
                        ByRef DtTable2 As DataTable,
                        ByRef SubTable As DataTable, _
                        ByVal W_ChietKhau As Long, ByVal p_Checked As Boolean)

        Dim srt_dt As String = String.Empty
        Dim srt_hhh As String = String.Empty
        Dim srt_dieudong As String = String.Empty
        Dim p_Count As Integer
        Dim p_RpHoaDonVCNB As New KV2_HoaDonVCNB
        Dim p_RpHoaDonVCNB_Sub As New KV2_HoaDonVCNB_Sub
        Dim p_Date As DateTime


        p_GetCurrentDate(p_Date)

        'Dim frmView As New frmPrint
        Try

            GetValue(p_Form, W_ChietKhau, SubTable)

            '  Dim rpt As New rptHoaDonVCNB

            p_RpHoaDonVCNB_Sub.DataSource = SubTable
            p_RpHoaDonVCNB.XrSubreport1.ReportSource = p_RpHoaDonVCNB_Sub
            ' rpt.SetDataSource(SubTable)
            srt_dt = Format(p_dtNgayXuat, "dd/MM/yyyy").ToString
            srt_dieudong = Format(p_dtpDieuDong, "dd/MM/yyyy").ToString
            p_RpHoaDonVCNB.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
            p_RpHoaDonVCNB.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
            p_RpHoaDonVCNB.Parameters.Item("P_Nam").Value = srt_dieudong.Substring(6, 4)

            p_RpHoaDonVCNB.Parameters.Item("P_NgayDieuDong").Value = srt_dieudong.Substring(0, 2)
            p_RpHoaDonVCNB.Parameters.Item("P_ThangDieuDong").Value = srt_dieudong.Substring(3, 2)
            p_RpHoaDonVCNB.Parameters.Item("P_NamDieuDong").Value = srt_dieudong.Substring(6, 4)

            'rpt.SetParameterValue("P_Nam", srt_dt.Substring(8, 2))

            p_RpHoaDonVCNB.Parameters.Item("P_SoLenh").Value = p_txtSoLenh
            p_RpHoaDonVCNB.Parameters.Item("P_CuaDonVi").Value = p_txtCompany
            p_RpHoaDonVCNB.Parameters.Item("P_DonViGiaoHang").Value = p_txtDonViGiaoHang
            p_RpHoaDonVCNB.Parameters.Item("P_DonViGiaoHangDiaChi").Value = p_txtDiaChiDonViGiaoHang
            p_RpHoaDonVCNB.Parameters.Item("P_DonViMua").Value = p_txtDonViNhanHang
            p_RpHoaDonVCNB.Parameters.Item("P_DiaChi_MH").Value = p_txtDiaChiDonViNhanHang
            'rpt.SetParameterValue("P_DonViMua", DtTable.Rows(0).Item("TenKhachHang").ToString)
            'rpt.SetParameterValue("P_DiaChi_MH", DtTable.Rows(0).Item("DiaChi").ToString)

            p_RpHoaDonVCNB.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            'rpt.SetParameterValue("P_MaTienKiem", DtTable.Rows(0).Item("SoLenh").ToString)
            p_RpHoaDonVCNB.Parameters.Item("P_MaTimKiem").Value = DtTable.Rows(0).Item("MaTimKiem").ToString
            p_RpHoaDonVCNB.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
            p_RpHoaDonVCNB.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
            p_RpHoaDonVCNB.Parameters.Item("P_SoNiem").Value = DtTable.Rows(0).Item("Niem").ToString
            p_RpHoaDonVCNB.Parameters.Item("P_DiemGiaoHang").Value = p_txtDiemGiaoHang
            p_RpHoaDonVCNB.Parameters.Item("P_KhoNhap").Value = p_txtKhoNhap
            p_RpHoaDonVCNB.Parameters.Item("P_DonViCCVanTai").Value = p_txtDonViCungCapVanTai

            For Each r As DataRow In DtTable2.Rows
                'srt_hhh += "N" + r.Item("HHH").ToString + ";"
                srt_hhh += "H" + r.Item("HHH").ToString + ";"
            Next

            p_RpHoaDonVCNB.Parameters.Item("P_KhoangCachTamMuc").Value = srt_hhh

            Dim times As DateTime = Get_ThoiGianDau(p_txtSoLenh)   ' Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
            p_RpHoaDonVCNB.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd.MM.yyyy}", times)

            p_RpHoaDonVCNB.Parameters.Item("P_GioXuatHang").Value = String.Format("{0}:{1}:{2}", times.Hour, times.Minute, times.Second)
            p_RpHoaDonVCNB.Parameters.Item("P_NgayGiaoDich").Value = p_RpHoaDonVCNB.Parameters.Item("P_NgayGiaoDich").Value & "/" & p_RpHoaDonVCNB.Parameters.Item("P_GioXuatHang").Value
            'Update Dữ liệu vào bảng tblThongTinHoaDon
            For p_Count = 0 To p_RpHoaDonVCNB.Parameters.Count - 1
                p_RpHoaDonVCNB.Parameters(p_Count).Visible = False
            Next
            '----------------------
            If p_Checked = True Then
                p_RpHoaDonVCNB.PrinterName = g_DefaultPrint
                p_RpHoaDonVCNB.Print()

            Else
                p_RpHoaDonVCNB.ShowPreviewDialog()
            End If

        Catch ex As Exception
            ShowMessageBox("", ex.Message)
        End Try
    End Sub
    Public Sub HoaDon_VCNB_CIF(ByVal p_Form As Object, ByVal W_SoLenh As String, _
                          ByRef DtTable As DataTable, _
                            ByRef DtTable1 As DataTable, _
                            ByRef DtTable2 As DataTable,
                            ByRef SubTable As DataTable, _
                            ByVal W_ChietKhau As Long, ByVal p_Checked As Boolean)

        Dim srt_dt As String = String.Empty
        Dim srt_hhh As String = String.Empty
        Dim srt_dieudong As String = String.Empty
        Dim p_Count As Integer
        Dim p_RpHoaDonVCNB As New KV2_HoaDonVCNB_CIF
        Dim p_RpHoaDonVCNB_Sub As New KV2_HoaDonVCNB_CIF_Sub
        Dim p_Date As DateTime


        p_GetCurrentDate(p_Date)


        GetValue(p_Form, W_ChietKhau, SubTable)
        'Dim frmView As New frmPrint
        Try


            '  Dim rpt As New rptHoaDonVCNB

            p_RpHoaDonVCNB_Sub.DataSource = SubTable
            p_RpHoaDonVCNB.XrSubreport1.ReportSource = p_RpHoaDonVCNB_Sub
            ' rpt.SetDataSource(SubTable)
            srt_dt = Format(p_dtNgayXuat, "dd/MM/yyyy").ToString
            srt_dieudong = Format(p_dtpDieuDong, "dd/MM/yyyy").ToString
            p_RpHoaDonVCNB.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
            p_RpHoaDonVCNB.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
            p_RpHoaDonVCNB.Parameters.Item("P_Nam").Value = srt_dieudong.Substring(6, 4)

            p_RpHoaDonVCNB.Parameters.Item("P_NgayDieuDong").Value = srt_dieudong.Substring(0, 2)
            p_RpHoaDonVCNB.Parameters.Item("P_ThangDieuDong").Value = srt_dieudong.Substring(3, 2)
            p_RpHoaDonVCNB.Parameters.Item("P_NamDieuDong").Value = srt_dieudong.Substring(6, 4)

            'rpt.SetParameterValue("P_Nam", srt_dt.Substring(8, 2))

            p_RpHoaDonVCNB.Parameters.Item("P_SoLenh").Value = p_txtSoLenh
            p_RpHoaDonVCNB.Parameters.Item("P_CuaDonVi").Value = p_txtCompany
            p_RpHoaDonVCNB.Parameters.Item("P_DonViGiaoHang").Value = p_txtDonViGiaoHang
            p_RpHoaDonVCNB.Parameters.Item("P_DonViGiaoHangDiaChi").Value = p_txtDiaChiDonViGiaoHang
            p_RpHoaDonVCNB.Parameters.Item("P_DonViMua").Value = p_txtDonViNhanHang
            p_RpHoaDonVCNB.Parameters.Item("P_DiaChi_MH").Value = p_txtDiaChiDonViNhanHang
            'rpt.SetParameterValue("P_DonViMua", DtTable.Rows(0).Item("TenKhachHang").ToString)
            'rpt.SetParameterValue("P_DiaChi_MH", DtTable.Rows(0).Item("DiaChi").ToString)

            p_RpHoaDonVCNB.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            'rpt.SetParameterValue("P_MaTienKiem", DtTable.Rows(0).Item("SoLenh").ToString)
            p_RpHoaDonVCNB.Parameters.Item("P_MaTimKiem").Value = DtTable.Rows(0).Item("MaTimKiem").ToString
            p_RpHoaDonVCNB.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
            p_RpHoaDonVCNB.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
            p_RpHoaDonVCNB.Parameters.Item("P_SoNiem").Value = DtTable.Rows(0).Item("Niem").ToString
            p_RpHoaDonVCNB.Parameters.Item("P_DiemGiaoHang").Value = p_txtDiemGiaoHang
            p_RpHoaDonVCNB.Parameters.Item("P_KhoNhap").Value = p_txtKhoNhap
            p_RpHoaDonVCNB.Parameters.Item("P_DonViCCVanTai").Value = p_txtDonViCungCapVanTai

            For Each r As DataRow In DtTable2.Rows
                'srt_hhh += "N" + r.Item("HHH").ToString + ";"
                srt_hhh += "H" + r.Item("HHH").ToString + ";"
            Next

            p_RpHoaDonVCNB.Parameters.Item("P_KhoangCachTamMuc").Value = srt_hhh

            Dim times As DateTime = Get_ThoiGianDau(p_txtSoLenh)    ' p_Date   ' Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
            p_RpHoaDonVCNB.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd/MM/yyyy}", times)
            p_RpHoaDonVCNB.Parameters.Item("P_GioXuatHang").Value = String.Format("{0}:{1}:{2}", times.Hour, times.Minute, times.Second)

            'Update Dữ liệu vào bảng tblThongTinHoaDon
            For p_Count = 0 To p_RpHoaDonVCNB.Parameters.Count - 1
                p_RpHoaDonVCNB.Parameters(p_Count).Visible = False
            Next
            '----------------------
            If p_Checked = True Then
                p_RpHoaDonVCNB.PrinterName = g_DefaultPrint
                p_RpHoaDonVCNB.Print()

            Else
                p_RpHoaDonVCNB.ShowPreviewDialog()
            End If

        Catch ex As Exception
            ShowMessageBox("", ex.Message)
        End Try
    End Sub

    Public Sub HoaDon_VCNB_DCCH(ByVal p_Form As Object, ByVal W_SoLenh As String, _
                        ByRef DtTable As DataTable, _
                          ByRef DtTable1 As DataTable, _
                          ByRef DtTable2 As DataTable,
                          ByRef SubTable As DataTable, _
                          ByVal W_ChietKhau As Long, ByVal p_Checked As Boolean)

        Dim srt_dt As String = String.Empty
        Dim srt_hhh As String = String.Empty
        Dim srt_dieudong As String = String.Empty
        Dim p_Count As Integer
        Dim p_RpHoaDonVCNB As New KV2_HoaDonVCNB
        Dim p_RpHoaDonVCNB_Sub As New KV2_HoaDonVCNB_Sub
        Dim p_Date As DateTime


        p_GetCurrentDate(p_Date)


        GetValue(p_Form, W_ChietKhau, SubTable)

        p_RpHoaDonVCNB_Sub.DataSource = SubTable
        p_RpHoaDonVCNB.XrSubreport1.ReportSource = p_RpHoaDonVCNB_Sub
        ' rpt.SetDataSource(SubTable)
        srt_dt = Format(p_dtNgayXuat, "dd/MM/yyyy").ToString
        srt_dieudong = Format(p_dtpDieuDong, "dd/MM/yyyy").ToString
        p_RpHoaDonVCNB.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
        p_RpHoaDonVCNB.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
        p_RpHoaDonVCNB.Parameters.Item("P_Nam").Value = srt_dieudong.Substring(6, 4)

        p_RpHoaDonVCNB.Parameters.Item("P_NgayDieuDong").Value = srt_dieudong.Substring(0, 2)
        p_RpHoaDonVCNB.Parameters.Item("P_ThangDieuDong").Value = srt_dieudong.Substring(3, 2)
        p_RpHoaDonVCNB.Parameters.Item("P_NamDieuDong").Value = srt_dieudong.Substring(6, 4)

        'rpt.SetParameterValue("P_Nam", srt_dt.Substring(8, 2))

        p_RpHoaDonVCNB.Parameters.Item("P_SoLenh").Value = p_txtSoLenh
        p_RpHoaDonVCNB.Parameters.Item("P_CuaDonVi").Value = p_txtCompany
        p_RpHoaDonVCNB.Parameters.Item("P_DonViGiaoHang").Value = p_txtDonViGiaoHang
        p_RpHoaDonVCNB.Parameters.Item("P_DonViGiaoHangDiaChi").Value = p_txtDiaChiDonViGiaoHang
        p_RpHoaDonVCNB.Parameters.Item("P_DonViMua").Value = p_txtDonViNhanHang
        p_RpHoaDonVCNB.Parameters.Item("P_DiaChi_MH").Value = p_txtDiaChiDonViNhanHang
        'rpt.SetParameterValue("P_DonViMua", DtTable.Rows(0).Item("TenKhachHang").ToString)
        'rpt.SetParameterValue("P_DiaChi_MH", DtTable.Rows(0).Item("DiaChi").ToString)

        p_RpHoaDonVCNB.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
        'rpt.SetParameterValue("P_MaTienKiem", DtTable.Rows(0).Item("SoLenh").ToString)
        p_RpHoaDonVCNB.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
        p_RpHoaDonVCNB.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
        p_RpHoaDonVCNB.Parameters.Item("P_SoNiem").Value = DtTable.Rows(0).Item("Niem").ToString
        p_RpHoaDonVCNB.Parameters.Item("P_DiemGiaoHang").Value = p_Form.txtDiemGiaoHang.Text
        p_RpHoaDonVCNB.Parameters.Item("P_KhoNhap").Value = p_txtKhoNhap
        p_RpHoaDonVCNB.Parameters.Item("P_DonViCCVanTai").Value = p_txtDonViCungCapVanTai

        For Each r As DataRow In DtTable2.Rows
            srt_hhh += "N" + r.Item("HHH").ToString + ";"
        Next

        p_RpHoaDonVCNB.Parameters.Item("P_KhoangCachTamMuc").Value = srt_hhh

        Dim times As DateTime = Get_ThoiGianDau(p_txtSoLenh)    ' p_Date   ' Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
        p_RpHoaDonVCNB.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd/MM/yyyy}", times)
        p_RpHoaDonVCNB.Parameters.Item("P_GioXuatHang").Value = String.Format("{0}:{1}:{2}", times.Hour, times.Minute, times.Second)

        'Update Dữ liệu vào bảng tblThongTinHoaDon
        For p_Count = 0 To p_RpHoaDonVCNB.Parameters.Count - 1
            p_RpHoaDonVCNB.Parameters(p_Count).Visible = False
        Next
        '----------------------
        If p_Checked = True Then
            p_RpHoaDonVCNB.PrinterName = g_DefaultPrint
            p_RpHoaDonVCNB.Print()

        Else
            p_RpHoaDonVCNB.ShowPreviewDialog()
        End If



    End Sub



    Public Sub HoaDon_VCNB_NBN(ByVal p_Form As Object, ByVal W_SoLenh As String, _
                        ByRef DtTable As DataTable, _
                          ByRef DtTable1 As DataTable, _
                          ByRef DtTable2 As DataTable,
                          ByRef SubTable As DataTable, _
                          ByVal W_ChietKhau As Long, ByVal p_Checked As Boolean)

        Dim srt_dt As String = String.Empty
        Dim srt_hhh As String = String.Empty
        Dim srt_dieudong As String = String.Empty
        Dim p_Count As Integer
        Dim p_RpHoaDonVCNB As New KV2_HoaDonVCNB
        Dim p_RpHoaDonVCNB_Sub As New KV2_HoaDonVCNB_Sub
        Dim p_Date As DateTime


        p_GetCurrentDate(p_Date)


        GetValue(p_Form, W_ChietKhau, SubTable)
        '  Dim rpt As New rptHoaDonVCNB

        p_RpHoaDonVCNB_Sub.DataSource = SubTable
        p_RpHoaDonVCNB.XrSubreport1.ReportSource = p_RpHoaDonVCNB_Sub
        ' rpt.SetDataSource(SubTable)
        srt_dt = Format(p_dtNgayXuat, "dd/MM/yyyy").ToString
        srt_dieudong = Format(p_dtpDieuDong, "dd/MM/yyyy").ToString
        p_RpHoaDonVCNB.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
        p_RpHoaDonVCNB.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
        p_RpHoaDonVCNB.Parameters.Item("P_Nam").Value = srt_dieudong.Substring(6, 4)

        p_RpHoaDonVCNB.Parameters.Item("P_NgayDieuDong").Value = srt_dieudong.Substring(0, 2)
        p_RpHoaDonVCNB.Parameters.Item("P_ThangDieuDong").Value = srt_dieudong.Substring(3, 2)
        p_RpHoaDonVCNB.Parameters.Item("P_NamDieuDong").Value = srt_dieudong.Substring(6, 4)

        'rpt.SetParameterValue("P_Nam", srt_dt.Substring(8, 2))

        p_RpHoaDonVCNB.Parameters.Item("P_SoLenh").Value = p_txtSoLenh
        p_RpHoaDonVCNB.Parameters.Item("P_CuaDonVi").Value = p_txtCompany
        p_RpHoaDonVCNB.Parameters.Item("P_DonViGiaoHang").Value = p_txtDonViGiaoHang
        p_RpHoaDonVCNB.Parameters.Item("P_DonViGiaoHangDiaChi").Value = p_txtDiaChiDonViGiaoHang
        p_RpHoaDonVCNB.Parameters.Item("P_DonViMua").Value = p_txtDonViNhanHang
        p_RpHoaDonVCNB.Parameters.Item("P_DiaChi_MH").Value = p_txtDiaChiDonViNhanHang
        'rpt.SetParameterValue("P_DonViMua", DtTable.Rows(0).Item("TenKhachHang").ToString)
        'rpt.SetParameterValue("P_DiaChi_MH", DtTable.Rows(0).Item("DiaChi").ToString)

        p_RpHoaDonVCNB.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
        'rpt.SetParameterValue("P_MaTienKiem", DtTable.Rows(0).Item("SoLenh").ToString)
        p_RpHoaDonVCNB.Parameters.Item("P_MaTimKiem").Value = DtTable.Rows(0).Item("MaTimKiem").ToString
        p_RpHoaDonVCNB.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
        p_RpHoaDonVCNB.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
        p_RpHoaDonVCNB.Parameters.Item("P_SoNiem").Value = DtTable.Rows(0).Item("Niem").ToString
        p_RpHoaDonVCNB.Parameters.Item("P_DiemGiaoHang").Value = p_txtDiemGiaoHang
        p_RpHoaDonVCNB.Parameters.Item("P_KhoNhap").Value = p_txtKhoNhap
        p_RpHoaDonVCNB.Parameters.Item("P_DonViCCVanTai").Value = p_txtDonViCungCapVanTai

        For Each r As DataRow In DtTable2.Rows
            'srt_hhh += "N" + r.Item("HHH").ToString + ";"
            srt_hhh += "H" + r.Item("HHH").ToString + ";"
        Next

        p_RpHoaDonVCNB.Parameters.Item("P_KhoangCachTamMuc").Value = srt_hhh

        Dim times As DateTime = Get_ThoiGianDau(p_txtSoLenh)     ' p_Date   ' Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
        p_RpHoaDonVCNB.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd.MM.yyyy}", times)
        'p_RpHoaDonVCNB.Parameters.Item("P_GioXuatHang").Value = String.Format("{0}:{1}:{2}", times.Hour, times.Minute, times.Second)
        p_RpHoaDonVCNB.Parameters.Item("P_NgayGiaoDich").Value += "/" & String.Format("{0}:{1}", times.Hour, times.Minute)

        'Update Dữ liệu vào bảng tblThongTinHoaDon
        For p_Count = 0 To p_RpHoaDonVCNB.Parameters.Count - 1
            p_RpHoaDonVCNB.Parameters(p_Count).Visible = False
        Next
        '----------------------
        If p_Checked = True Then
            p_RpHoaDonVCNB.PrinterName = g_DefaultPrint
            p_RpHoaDonVCNB.Print()

        Else
            p_RpHoaDonVCNB.ShowPreviewDialog()
        End If

    End Sub



End Module


