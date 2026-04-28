Public Class frmImfor_HoaDonTaiXuat
    Private W_SoLenh As String
    Private TongTien As Integer = 0
    Private W_Ngay As String = String.Empty
    Private W_Thang As String = String.Empty
    Private W_Nam As String = String.Empty
    Private W_LineID As String = String.Empty
    Private W_dt_HoaDonCT As DataTable
    Private W_dt_HoaDonTT As DataTable
    'Private W_dt_Ngan As DataTable
    Private W_ttHoaDon As New BSThongTinHoaDon
    Private W_Item As Integer = 0
    Private Err As String = String.Empty
    Private W_Time As Integer = 0
    Private W_Limit_Time As Integer = 5
    Private W_DSET As DataSet
    ' Private Provider As SqlDataProvider

    Private Sub frmImfor_HoaDonTaiXuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String

        Dim p_Date As Date
        Dim p_Time As Integer
        Dim p_Binding As New U_TextBox.U_BindingSource
        p_GetDateTime(p_Date, p_Time)


        W_dt_HoaDonCT = Get_HoaDon_ChiTietNew(W_SoLenh)


       W_dt_HoaDonTT = W_ttHoaDon.Select_LenhXuatKho_BySoLenh(Err, W_SoLenh).Tables(0)


        ' Provider = New SqlDataProvider(_SQLConnectionString)
        p_SQL = "exec FPT_Reports_HoaDonTaiXuatE5 '" & W_SoLenh & "'"
        'W_DSET = Provider.GetDataSetProcedure("FPT_Reports_HoaDonTaiXuatE5", New SqlParameter("@SoLenh", W_SoLenh))
        W_DSET = GetDataSet(p_SQL, p_SQL)
        If W_DSET Is Nothing Then
            Exit Sub
        End If
        If W_DSET.Tables.Count <= 0 Then
            Exit Sub
        End If
        If W_DSET.Tables(0).Rows.Count <= 0 Then
            Exit Sub
        End If

        p_Binding.DataSource = W_dt_HoaDonCT
        Me.TrueDBGrid1.DataSource = p_Binding
        Me.TrueDBGrid1.Refresh()
        Me.GridView1.RefreshData()
        GridView1.OptionsBehavior.ReadOnly = True

        txtDonViGiaoHang.EditValue = W_DSET.Tables(0).Rows(0).Item(0).ToString()
        txtDiaChiDonViGiaoHang.EditValue = W_DSET.Tables(0).Rows(0).Item(1).ToString()
        txtMST1.EditValue = W_DSET.Tables(0).Rows(0).Item(2).ToString()
        txtDonViNhanHang.EditValue = W_DSET.Tables(0).Rows(0).Item(4).ToString()
        txtDiaChiDonViNhanHang.EditValue = W_DSET.Tables(0).Rows(0).Item(5).ToString()
        txtMST2.EditValue = W_DSET.Tables(0).Rows(0).Item(6).ToString()

        Get_Data_Default()
        txtNgayHopDong.Focus()
    End Sub

    Private Sub Get_Data_Default()
        Dim p_Value As Double
        Try
            If W_dt_HoaDonTT.Rows.Count > 0 Then
                txtPhuongThuc.Text = IIf(IsDBNull(W_dt_HoaDonTT.Rows(0).Item("PhuongThuc")), "", W_dt_HoaDonTT.Rows(0).Item("PhuongThuc"))
                txtTygia.Text = IIf(IsDBNull(W_dt_HoaDonTT.Rows(0).Item("TienKhac")), "", W_dt_HoaDonTT.Rows(0).Item("TienKhac"))
                For i As Integer = 0 To Me.GridView1.RowCount - 1
                    '  GridView1.Rows(i).ite(4).Value = IIf(IsDBNull(W_dt_HoaDonTT.Rows(i).Item("DonGia")), 0, W_dt_HoaDonTT.Rows(i).Item("DonGia"))
                    p_Value = IIf(IsDBNull(W_dt_HoaDonTT.Rows(i).Item(4)), 0, W_dt_HoaDonTT.Rows(i).Item(4))
                    Me.GridView1.SetRowCellValue(i, "DonGia", IIf(IsDBNull(W_dt_HoaDonTT.Rows(i).Item("DonGia")), 0, W_dt_HoaDonTT.Rows(i).Item("DonGia")))
                Next
            Else
                dtNgayXuat.EditValue = Now.Date
                txtPhuongThuc.Text = String.Empty
            End If
        Catch ex As Exception
            ShowStatusMessage(True, "", ex.Message, 5)
        End Try
    End Sub


    Sub New(ByVal i_SoLenh As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        W_SoLenh = i_SoLenh
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim DtTable As New DataTable
        Dim DtTable1 As New DataTable
        Dim DtTable2 As New DataTable
        Dim SubTable As New DataTable
        Dim srt_dt As String = String.Empty
        Dim srt_hhh As String = String.Empty
        Dim srt_dieudong As String = String.Empty


        Dim frmView As New frmPrint
        Try
            If Me.Check_Control_Required = False Then
                Exit Sub
            End If
            DtTable = W_DSET.Tables(0)
            DtTable1 = W_DSET.Tables(1)
            'FES ANNV 10/11 sua in hoa don tai xuat
            'DtTable2 = W_DSET.Tables(2)

            'rpt.PrintOptions.PrinterName = _DefaultPrint
            SubTable = Alter_Sub_Table(DtTable, DtTable1)


            Dim rpt As New rptHoaDonTaiXuat
            rpt.SetDataSource(SubTable)
            rpt.Subreports(0).SetDataSource(SubTable)
            srt_dt = Format(CDate(dtNgayXuat.EditValue), "dd/MM/yyyy").ToString
            srt_dieudong = Format(CDate(dtNgayXuat.EditValue), "dd/MM/yyyy").ToString
            rpt.SetParameterValue("P_Ngay", srt_dt.Substring(0, 2))
            rpt.SetParameterValue("P_Thang", srt_dt.Substring(3, 2))
            rpt.SetParameterValue("P_Nam", srt_dieudong.Substring(6, 4))

            rpt.SetParameterValue("P_NguoiBan", txtDonViGiaoHang.Text)
            rpt.SetParameterValue("P_DiaChi_BH", txtDiaChiDonViGiaoHang.Text)
            rpt.SetParameterValue("P_MST_BH", txtMST1.Text)
            rpt.SetParameterValue("P_DonViMua", txtDonViNhanHang.Text)
            rpt.SetParameterValue("P_DiaChi_MH", txtDiaChiDonViNhanHang.Text)
            rpt.SetParameterValue("P_MaSoThue_MH", "MST(Tax code): " & txtMST2.Text)
            rpt.SetParameterValue("P_SoTaiKhoan_BH", txtSoTaiKhoan1.Text)
            rpt.SetParameterValue("P_SoTaiKhoan_MH", txtSoTaiKhoan2.Text)
            rpt.SetParameterValue("P_NgayHopDong", txtNgayHopDong.Text)

            rpt.SetParameterValue("P_TongCong", Format(TongTien, "n0").Replace(",", "."))
            rpt.SetParameterValue("P_TongBangChu", mdlFunction.Number2Text(CLng(TongTien)) & " Đô la Mỹ chẵn" & " (" & mdlFunction.Number2Text_EN(CLng(TongTien)) & ")")

            rpt.SetParameterValue("P_NgayVanDon", srt_dt)
            rpt.SetParameterValue("P_KhoXuat", DtTable.Rows(0).Item("MaKho").ToString)
            rpt.SetParameterValue("P_NguoiVanTai", DtTable.Rows(0).Item("NguoiVanChuyen").ToString)
            rpt.SetParameterValue("P_SoPhuongTien", DtTable.Rows(0).Item("MaPhuongTien").ToString)
            rpt.SetParameterValue("P_DonViCungCapVanTai", txtDonViCCVanTai.Text)
            'rpt.SetParameterValue("P_DiemGiaoHang", txtDiemGiaoHang.Text)
            rpt.SetParameterValue("P_DiemNhanHang", txtDiemNhanHang.Text)
            rpt.SetParameterValue("P_PhuongThucTT", txtPhuongThuc.Text)
            rpt.SetParameterValue("P_ThoiHanThanhToan", txtThoiHanThanhToan.Text)
            rpt.SetParameterValue("P_TyGia", txtTygia.Text)
            rpt.SetParameterValue("P_TKHQ", txtToKhaiHQ.Text)
            rpt.SetParameterValue("P_STK", txtSoTK.Text)

            Dim times As Date = Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
            rpt.SetParameterValue("P_NgayGiaoDich", String.Format("{0:dd.MM.yyyy}", times))
            rpt.SetParameterValue("P_GioXuatHang", times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString)

            'Update Dữ liệu vào bảng tblThongTinHoaDon

            '----------------------
            If U_CheckBox1.Checked Then
                rpt.PrintOptions.PrinterName = g_DefaultPrint
                rpt.PrintToPrinter(1, False, 0, 0)
            Else
                frmView.crViewer.ReportSource = rpt
                frmView.ShowDialog()
            End If

            Update_TTHoaDon()

        Catch ex As Exception
            ShowStatusMessage(True, "", ex.Message, 5)
        End Try
    End Sub


    Private Sub Update_TTHoaDon()
        ' Check_in()
        Dim p_SQL As String
        Dim p_DataRow As DataRow
        Try

            For index As Integer = 0 To Me.GridView1.RowCount - 1
                p_DataRow = Me.GridView1.GetDataRow(index)
                p_SQL = "exec ThongTinHoaDonTransaction " & _
                    "'" & W_SoLenh.ToString.Trim & "'" & _
                    ",'" & p_DataRow.Item(0).ToString.Trim & "'" & _
                    ",'" & CDate(dtNgayXuat.Text).ToString("yyyyMMdd") & "'" & _
                    "," & p_DataRow.Item(4).ToString.Trim & "" & _
                    ",0" & _
                    "," & p_DataRow.Item(5).ToString.Trim & "" & _
                        ",'" & txtPhuongThuc.Text & "'" & _
                    ",'" & W_SoLenh.ToString.Trim & "'" & _
                     "," & p_DataRow.Item(5).ToString.Trim
                If SQL_Execute(p_SQL, p_SQL) = False Then
                    ShowMessageBox("", p_SQL)
                    Exit Sub
                End If
            Next
            p_SQL = " exec KhachHangUpdateAddress '" & W_DSET.Tables(0).Rows(0).Item(3).ToString.Trim & "','" & txtDiaChiDonViGiaoHang.Text & "'"
            If SQL_Execute(p_SQL, p_SQL) = False Then
                ShowMessageBox("", p_SQL)
                Exit Sub
            End If
        Catch ex As Exception
            ShowStatusMessage(True, "", ex.Message, 5)
        End Try
    End Sub


    Private Function Alter_Sub_Table(ByVal dtTable0 As DataTable, ByVal dtTable As DataTable) As DataTable
        Dim l_mavanchuyen As String
        Dim l_thuybo As String
        Dim SoLuong As Integer = 0
        Dim SubTable As DataTable
        Dim dtRow As DataRow
        Dim l_ds_sub As New RpSub()
        Dim l_thanhtien As Int64
        Dim l_dongia As Int64
        Dim l_quantity As Decimal()
        Dim index As Integer = 0
        Dim p_DataRow As DataRow

        l_dongia = 0
        TongTien = 0
        l_thanhtien = 0

        Try
            SubTable = l_ds_sub.Tables(1).Clone()
            l_mavanchuyen = dtTable0.Rows(0)("MaVanChuyen").ToString()
            l_thuybo = mdlDelivery_CheckTransmot(l_mavanchuyen, g_dt_para)

            For Each r As DataRow In dtTable.Rows
                dtRow = SubTable.NewRow
                dtRow("MaHangHoa") = r.Item("MaHangHoa").ToString
                dtRow("TenHangHoa") = r.Item("TenHangHoa").ToString
                dtRow("DonViTinh") = r.Item("DonViTinh").ToString

                If l_thuybo.ToUpper() = "THUY" Then
                    l_quantity = Calculate_1(r.Item("LineID").ToString())
                Else
                    l_quantity = Calculate_0(r.Item("LineID").ToString())
                End If

                'SoLuong = IIf(IsDBNull(r.Item("TongXuat")), 0, r.Item("TongXuat"))
                'dtRow("TongDuXuat") = Format(CInt(r.Item("TongXuat")), "n0").Replace(",", ".")

                'dtRow("TongDuXuat") = Format(CInt(r.Item("TongDuXuat")), "n0").Replace(",", ".")


                Select Case r.Item("DonViTinh").ToString().ToUpper()
                    Case "L"
                        SoLuong = l_quantity(0)
                    Case "L15"
                        SoLuong = l_quantity(1)
                    Case "M15"
                        SoLuong = l_quantity(2)
                    Case "KG"
                        SoLuong = l_quantity(3)
                    Case Else
                        SoLuong = l_quantity(0)
                End Select

                dtRow("TongDuXuat") = SoLuong
                'l_dongia = CDec(dgvProduct.Rows(index).Cells(4).Value.ToString())
                p_DataRow = Me.GridView1.GetDataRow(index)
                l_dongia = CDec(IIf(p_DataRow(4).ToString.Trim = "", 0, p_DataRow(4).ToString()))
                l_thanhtien = l_dongia * SoLuong

                dtRow("DonGia") = Format(l_dongia, "n0").Replace(",", ".")
                dtRow("ThanhTien") = Format(l_thanhtien, "n0").Replace(",", ".")
                dtRow("Bottom") = ND_VCF(l_quantity(0), r.Item("MaHangHoa").ToString, r.Item("DonViTinh").ToString, index)
                SubTable.Rows.Add(dtRow)
                TongTien += l_thanhtien
                index += 1

            Next
        Catch ex As Exception
            Return Nothing
        End Try
        Return SubTable
    End Function



    Private Function Calculate_0(ByVal i_iteam As String) As Decimal()
        Dim l_soluong As Decimal
        Dim l_nhietdo As Decimal
        Dim l_tytrong As Decimal
        Dim l_vcf As String
        Dim l_wcf As String
        Dim l_quantity As Decimal()

        l_soluong = 0
        l_nhietdo = 0
        l_tytrong = 0
        l_vcf = String.Empty
        l_wcf = String.Empty
        l_quantity = New Decimal() {0, 0, 0, 0}

        For i As Integer = 0 To W_dt_HoaDonCT.Rows.Count - 1
            If W_dt_HoaDonCT.Rows(i).Item("LineID").ToString() <> i_iteam Then
                Continue For
            End If
            l_soluong = Convert.ToDecimal(W_dt_HoaDonCT.Rows(i).Item("TổngDựXuất").ToString())
            l_nhietdo = Convert.ToDecimal(W_dt_HoaDonCT.Rows(i).Item("Nhiệtđộ").ToString())
            l_tytrong = Convert.ToDecimal(W_dt_HoaDonCT.Rows(i).Item("TỷTrọng").ToString())

            l_vcf = mdlQCI_GetVCF_NS(l_nhietdo, l_tytrong)
            l_wcf = mdlQCI_GetWCF(l_tytrong)

            l_quantity = mdlQCI_CalculateQCI(l_soluong, "L", l_vcf)
            l_quantity(3) = l_quantity(1) * Convert.ToDecimal(l_wcf)

            W_dt_HoaDonCT.Rows(i).Item("L15") = l_quantity(1)
            W_dt_HoaDonCT.Rows(i).Item("KG") = l_quantity(3)
        Next

        Return l_quantity
    End Function



    Private Function Calculate_1(ByVal i_iteam As String) As Decimal()
        Dim l_soluong As Decimal
        Dim l_nhietdo As Decimal
        Dim l_tytrong As Decimal
        Dim l_vcf As String
        Dim l_wcf As String
        Dim l_quantity As Decimal()

        l_soluong = 0
        l_nhietdo = 0
        l_tytrong = 0
        l_vcf = String.Empty
        l_wcf = String.Empty
        l_quantity = New Decimal() {0, 0, 0, 0}

        For i As Integer = 0 To W_dt_HoaDonCT.Rows.Count - 1
            If W_dt_HoaDonCT.Rows(i).Item("LineID").ToString() <> i_iteam Then
                Continue For
            End If
            l_soluong = Convert.ToDecimal(W_dt_HoaDonCT.Rows(i).Item("TổngXuất").ToString())
            l_nhietdo = Convert.ToDecimal(W_dt_HoaDonCT.Rows(i).Item("Nhiệtđộ").ToString())
            l_tytrong = Convert.ToDecimal(W_dt_HoaDonCT.Rows(i).Item("TỷTrọng").ToString())

            l_vcf = mdlQCI_GetVCF_NS(l_nhietdo, l_tytrong)
            l_wcf = mdlQCI_GetWCF(l_tytrong)

            l_quantity = mdlQCI_CalculateQCI(l_soluong, "L", l_vcf)
            l_quantity(3) = l_quantity(1) * Convert.ToDecimal(l_wcf)

            'W_dt_HoaDonCT.Rows(i).Item("L15") = l_quantity(1)
            'FES
            '20141017
            If CheckItemToScada2(W_dt_HoaDonCT.Rows(i).Item("MãHàngHóa")) <> "Y" Then
                W_dt_HoaDonCT.Rows(i).Item("L15") = l_quantity(1)
            Else
                l_quantity(1) = W_dt_HoaDonCT.Rows(i).Item("L15")
            End If
            W_dt_HoaDonCT.Rows(i).Item("KG") = l_quantity(3)
        Next

        Return l_quantity

    End Function


    Private Function ND_VCF(ByVal LTT As String, ByVal productID As String, ByVal unitID As String, ByVal dgvRow As Integer) As String

        '01/02/2013 QUEHV - Sua cac trinh tu thong tin theo don vi ban va hang hoa
        Dim Hed As String = String.Empty
        Dim ND As String = String.Empty
        Dim TX As String = String.Empty
        Dim D15 As String = String.Empty
        Dim VCF As String = String.Empty
        Dim L15 As String = String.Empty
        Dim KG As String = String.Empty
        Dim WCF As String = String.Empty
        Dim Full As String = String.Empty
        Dim p_TongDuXuat As String
        Dim p_ArrRow() As DataRow
        Dim p_DataRow As DataRow

        Try
            p_TongDuXuat = "0"
            p_ArrRow = g_SySConfig.Select("KEYCODE='TONGDUXUAT'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    p_TongDuXuat = p_ArrRow(0).Item("KEYVALUE").ToString.Trim
                End If
            End If

            p_DataRow = Me.GridView1.GetDataRow(dgvRow)
            ND = p_DataRow.Item("NhiệtĐộ").ToString()
            If ND.Contains(".") Then
                ND = ND.Replace(".", ",")
            End If

            Dim _D15 As Double = IIf(IsDBNull(p_DataRow.Item("TỷTrọng").ToString()), 0, p_DataRow.Item("TỷTrọng").ToString())
            D15 = Format(_D15, "0.0000").ToString
            If D15.Contains(".") Then
                D15 = D15.Replace(".", ",")
            End If

            Dim _VCF As Double = p_DataRow.Item("VCF").ToString()


            VCF = Format(_VCF, "0.0000").ToString
            If VCF.Contains(".") Then
                VCF = VCF.Replace(".", ",")
            End If

            Dim _WCF As Double = p_DataRow.Item("WCF").ToString()
            WCF = Format(_WCF, "0.0000").ToString
            If WCF.Contains(".") Then
                WCF = WCF.Replace(".", ",")
            End If

            KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
            L15 = Format(CInt(p_DataRow.Item("L15").ToString()), "n0").Replace(",", ".")

            'FES
            '20141027
            Select Case unitID.ToUpper
                Case "L"
                    Select Case productID.ToUpper
                        Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
                            Hed = "Nhiệt độ TT/KG/L15/D15/VCF/WCF: "

                            Full = Hed + ND + " / " + KG + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF

                        Case "0701001", "0701002", "0701003"
                            Hed = "Nhiệt độ TT/KG/D15/VCF/WCF: "

                            KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
                            Full = Hed + ND + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF

                    End Select
                Case "L15"
                    Select Case productID.ToUpper
                        Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
                            Hed = "Nhiệt độ TT/LTT/KG/D15/VCF/WCF: "
                            'p_TongDuXuat
                            'If g_dtPara.Rows(16).Item("Value_nd").ToString().Trim() = "1" Then
                            '    TX = dgvProduct.Rows(dgvRow).Cells("TổngXuất").Value.ToString()
                            'Else
                            '    TX = dgvProduct.Rows(dgvRow).Cells("TổngDựXuất").Value.ToString()
                            'End If
                            If p_TongDuXuat = "0" Or p_TongDuXuat = "" Then
                                TX = p_DataRow.Item("TổngXuất").ToString()
                            Else
                                TX = p_DataRow.Item("TổngDựXuất").ToString()
                            End If

                            Full = Hed + ND + " / " + TX + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
                    End Select
                Case "KG"
                    Select Case productID.ToUpper
                        Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
                            Hed = "Nhiệt độ TT/LTT/L15/D15/VCF/WCF: "

                            TX = p_DataRow.Item("TổngXuất").ToString()

                            Full = Hed + ND + " / " + TX + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF

                        Case "0701001", "0701002", "0701003"
                            Hed = "Nhiệt độ TT/LTT/D15/VCF/WCF: "

                            TX = p_DataRow.Item("TổngXuất").ToString()

                            Full = Hed + ND + " / " + TX + " / " + D15 + " / " + VCF + " / " + WCF

                    End Select
            End Select

            Return Full
        Catch ex As Exception
            ShowStatusMessage(True, "", ex.Message, 5)
            Return Nothing
        End Try
    End Function
End Class