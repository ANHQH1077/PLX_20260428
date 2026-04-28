Module ChungTuHoaDon

    Public Sub In_HoaDon(ByVal p_Form As Object, ByVal W_SoLenh As String, _
                      ByRef DtTable As DataTable, _
                        ByRef DtTable1 As DataTable, _
                        ByRef DtTable2 As DataTable,
                        ByRef SubTable As DataTable, _
                        ByVal W_ChietKhau As Long)
        'If Check_in() Then
        '    Exit Sub
        'End If



        Dim srt_dt As String = String.Empty
        Dim srt_hhh As String = String.Empty
        ' Dim frmView As New frmPrint
        Dim p_SQL As String
        Dim p_RptHoasDon1 As New KV2_HoaDon
        Dim p_RptHoasDon_Sub1 As New KV2_HoaDon_Sub
        Dim p_RptHoasDon As New KV2_HoaDon  'KV2_HoaDonVCNB
        Dim p_RptHoasDon_Sub As New KV2_HoaDon_Sub  'KV2_HoaDonVCNB_Sub
        Dim p_Count As Integer
        Dim p_Date As DateTime




        p_GetCurrentDate(p_Date)


        Try

            If W_ChietKhau > 0 Then

                'rpt.Subreports(0).SetDataSource(SubTable)
                'p_RptHoasDon1.DataSource = DtTable1
                p_RptHoasDon_Sub1.DataSource = SubTable
                p_RptHoasDon1.XrSubreport1.ReportSource = p_RptHoasDon_Sub1

                srt_dt = Format(p_Form.dtNgayXuat.EditValue, "dd/MM/yyyy").ToString
                p_RptHoasDon1.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
                p_RptHoasDon1.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
                p_RptHoasDon1.Parameters.Item("P_Nam").Value = srt_dt.Substring(6, 4)   ' Date.Now.Year
                'rpt.SetParameterValue("P_Nam", srt_dt.Substring(8, 2))

                'p_RptHoasDon1.Parameters.Item("P_DonViBan").Value = Me.txtDonViBanHang.Text 'hieptd4: tren phoi da in san thong tin nay
                'p_RptHoasDon1.Parameters.Item("P_DiaChi_BH").Value = Me.txtDiaChiDonViBanHang.Text 'hieptd4: tren phoi da in san thong tin nay
                'p_RptHoasDon1.Parameters.Item("P_MaSoThue_BH").Value = Me.txtMaSoThueDonViBanHang.Text 'hieptd4: tren phoi da in san thong tin nay

                p_RptHoasDon1.Parameters.Item("P_DonViMua").Value = p_Form.txtDonViMuaHang.Text  ' DtTable.Rows(0).Item("TenKhachHang").ToString
                p_RptHoasDon1.Parameters.Item("P_NguoiMua").Value = p_Form.txtNguoiMuaHang.Text

                p_RptHoasDon1.Parameters.Item("P_DiaChi_MH").Value = DtTable.Rows(0).Item("DiaChi").ToString
                p_RptHoasDon1.Parameters.Item("P_ThoiHanThanhToan").Value = p_Form.txtThoiHanThanhToan.Text

                p_RptHoasDon1.Parameters.Item("P_MaSoThue_MH").Value = DtTable.Rows(0).Item("MaSoThue").ToString
                p_RptHoasDon1.Parameters.Item("P_TongCong").Value = Format(Convert.ToInt64(p_Form.TongTien - W_ChietKhau), "n0").Replace(",", ".")

                ' 01/02/2013 QueHV Sua cach tinh thue GTGT theo cach tinh ma nghiep vu cung cap
                p_RptHoasDon1.Parameters.Item("P_ThueGTGT").Value = p_Form.txtThueGTGT.Text.Trim
                p_RptHoasDon1.Parameters.Item("P_TienThueGTGT").Value = Format(CInt(p_Form.W_ThueGTGT), "n0").Replace(",", ".")

                'rpt.SetParameterValue("P_TienThueGTGT", Format((TongTien * Convert.ToInt64(txtThueGTGT.Text.Trim) / 100), "n0"))
                'rpt.SetParameterValue("P_TienKhac", Format(CInt(txtTienKhac.Text.Trim), "n0"))
                Dim TongThanhToan As Long = 0
                TongThanhToan = p_Form.TongTien - W_ChietKhau + p_Form.W_ThueGTGT
                'TongThanhToan = TongTien + TienPhiKhac + (TongTien * Convert.ToInt64(txtThueGTGT.Text.Trim) / 100)
                p_RptHoasDon1.Parameters.Item("P_TongThanhToan").Value = Format(TongThanhToan, "n0").Replace(",", ".")

                p_RptHoasDon1.Parameters.Item("P_TongBangChu").Value = mdlFunction.Number2Text(CLng(TongThanhToan)) + " đồng chẵn"
                p_RptHoasDon1.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
                'p_RptHoasDon1.Parameters.Item("P_MaKhachHang").Value = DtTable.Rows(0).Item("MaKhachHang").ToString
                p_RptHoasDon1.Parameters.Item("P_MaKhachHang").Value = DtTable.Rows(0).Item("MaKhachHang").Substring(DtTable.Rows(0).Item("MaKhachHang").Length - 6)
                p_RptHoasDon1.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
                p_RptHoasDon1.Parameters.Item("P_MaTimKiem").Value = DtTable.Rows(0).Item("MaTimKiem").ToString ' "HiepTD4 test Mã tìm kiếm" 'hieptd4 test
                p_RptHoasDon1.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
                p_RptHoasDon1.Parameters.Item("P_SoNiem").Value = DtTable.Rows(0).Item("Niem").ToString
                Dim times As Date = Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
                p_RptHoasDon1.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd/MM/yyyy}", times)
                p_RptHoasDon1.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString


                For Each r As DataRow In DtTable2.Rows
                    'srt_hhh += "N" + r.Item("HHH").ToString + ";"
                    srt_hhh += "H" + r.Item("HHH").ToString + ";"
                Next

                p_RptHoasDon1.Parameters.Item("P_KhoangCachTamMuc").Value = srt_hhh
                p_RptHoasDon1.Parameters.Item("P_PhuongThucTT").Value = p_Form.txtPhuongThuc.Text.Trim
                p_RptHoasDon1.Parameters.Item("P_DonViCungCapVanTai").Value = p_Form.txtDonViCCVanTai.Text
                p_RptHoasDon1.Parameters.Item("P_ChietKhauThuongMai").Value = Format(W_ChietKhau, "n0").Replace(",", ".")
                For p_Count = 0 To p_RptHoasDon1.Parameters.Count - 1
                    p_RptHoasDon1.Parameters(p_Count).Visible = False
                Next
                p_RptHoasDon1.RequestParameters = False
                If p_Form.chkCheck.Checked Then
                    p_RptHoasDon1.PrinterName = g_DefaultPrint
                    p_RptHoasDon.Print()
                Else
                    p_RptHoasDon1.ShowPreviewDialog()
                End If
            Else
                Try
                    p_RptHoasDon_Sub.DataSource = SubTable
                    p_RptHoasDon.XrSubreport1.ReportSource = p_RptHoasDon_Sub

                    srt_dt = Format(p_Form.dtNgayXuat.EditValue, "dd/MM/yyyy").ToString
                    p_RptHoasDon.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
                    p_RptHoasDon.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
                    p_RptHoasDon.Parameters.Item("P_Nam").Value = srt_dt.Substring(6, 4)  'Date.Now.Year

                    'p_RptHoasDon.Parameters.Item("P_DonViBan").Value = Me.txtDonViBanHang.Text 'hieptd4: tren phoi da in san thong tin nay
                    'p_RptHoasDon.Parameters.Item("P_DiaChi_BH").Value = Me.txtDiaChiDonViBanHang.Text 'hieptd4: tren phoi da in san thong tin nay
                    'p_RptHoasDon.Parameters.Item("P_MaSoThue_BH").Value = Me.txtMaSoThueDonViBanHang.Text 'hieptd4: tren phoi da in san thong tin nay
                    p_RptHoasDon.Parameters.Item("P_LenhXuat").Value = "( Theo lệnh xuất số " + DtTable.Rows(0).Item("SoLenh") + " - " + srt_dt + " )"

                    p_RptHoasDon.Parameters.Item("P_DonViMua").Value = p_Form.Me.txtDonViMuaHang.Text '  DtTable.Rows(0).Item("TenKhachHang").ToString
                    p_RptHoasDon.Parameters.Item("P_NguoiMua").Value = p_Form.txtNguoiMuaHang.Text

                    'p_RptHoasDon.Parameters.Item("P_DiaChi_MH").Value = DtTable.Rows(0).Item("DiaChi").ToString                   
                    p_RptHoasDon.Parameters.Item("P_DiaChi_MH").Value = p_Form.txtDiChiDonViMuaHang.Text

                    p_RptHoasDon.Parameters.Item("P_ThoiHanThanhToan").Value = p_Form.txtThoiHanThanhToan.Text

                    p_RptHoasDon.Parameters.Item("P_MaSoThue_MH").Value = DtTable.Rows(0).Item("MaSoThue").ToString
                    p_RptHoasDon.Parameters.Item("P_TongCong").Value = Format(Convert.ToInt64(p_Form.TongTien - W_ChietKhau), "n0").Replace(",", ".")

                    ' 01/02/2013 QueHV Sua cach tinh thue GTGT theo cach tinh ma nghiep vu cung cap
                    p_RptHoasDon.Parameters.Item("P_ThueGTGT").Value = p_Form.txtThueGTGT.Text.Trim
                    p_RptHoasDon.Parameters.Item("P_TienThueGTGT").Value = Format(CInt(p_Form.W_ThueGTGT), "n0").Replace(",", ".")

                    'rpt.SetParameterValue("P_TienThueGTGT", Format((TongTien * Convert.ToInt64(txtThueGTGT.Text.Trim) / 100), "n0"))
                    'rpt.SetParameterValue("P_TienKhac", Format(CInt(txtTienKhac.Text.Trim), "n0"))
                    Dim TongThanhToan As Long = 0
                    TongThanhToan = p_Form.TongTien - W_ChietKhau + p_Form.W_ThueGTGT
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
                    Dim times As Date = p_Date   ' Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
                    p_RptHoasDon.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd/MM/yyyy}", times)
                    p_RptHoasDon.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString


                    For Each r As DataRow In DtTable2.Rows
                        'srt_hhh += "N" + r.Item("HHH").ToString + ";"
                        srt_hhh += "H" + r.Item("HHH").ToString + ";"
                    Next

                    p_RptHoasDon.Parameters.Item("P_KhoangCachTamMuc").Value = srt_hhh
                    p_RptHoasDon.Parameters.Item("P_PhuongThucTT").Value = p_Form.txtPhuongThuc.Text.Trim
                    p_RptHoasDon.Parameters.Item("P_DonViCungCapVanTai").Value = p_Form.txtDonViCCVanTai.Text
                    'p_RptHoasDon.Parameters.Item("P_ChietKhauThuongMai").Value = Format(W_ChietKhau, "n0").Replace(",", ".")
                    For p_Count = 0 To p_RptHoasDon.Parameters.Count - 1
                        p_RptHoasDon.Parameters(p_Count).Visible = False
                    Next
                    p_RptHoasDon.RequestParameters = False
                    If p_Form.chkCheck.Checked Then
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


End Module
