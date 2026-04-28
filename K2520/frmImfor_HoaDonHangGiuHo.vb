Public Class frmImfor_HoaDonHangGiuHo
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
    Private Provider As DataTable

    Private p_LoaiChungTu As String = "GTGT_GIUHO"
    Private p_SoLenh As String = ""



    Private Sub frmImfor_HoaDonHangGiuHo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String

        Dim p_Date As Date
        Dim p_Time As Integer
        Dim p_Binding As New U_TextBox.U_BindingSource
        p_GetDateTime(p_Date, p_Time)
        '  CreateFieldForm(Me)

        W_dt_HoaDonCT = Get_HoaDon_ChiTietNew(W_SoLenh)

        'dgvProduct.DataSource = W_dt_HoaDonCT

        'dgvProduct.Columns(0).Visible = False
        'dgvProduct.Columns(2).Visible = False
        'dgvProduct.Columns(4).Visible = False
        'dgvProduct.Columns(5).Visible = False
        'dgvProduct.Columns(1).Width = 50
        'dgvProduct.Columns(1).ReadOnly = True
        'dgvProduct.Columns(3).ReadOnly = True
        'dgvProduct.Columns(4).ReadOnly = True
        'dgvProduct.Columns(5).ReadOnly = True
        'dgvProduct.Columns(6).ReadOnly = True
        'dgvProduct.Columns(7).ReadOnly = True
        'dgvProduct.Columns(8).ReadOnly = True
        'dgvProduct.Columns(9).ReadOnly = True
        'dgvProduct.Columns(10).ReadOnly = True
        'dgvProduct.Columns(11).ReadOnly = True
        'dgvProduct.Columns(12).ReadOnly = True
        'dgvProduct.Columns(13).ReadOnly = True
        'dgvProduct.Columns(14).ReadOnly = True

        W_dt_HoaDonTT = W_ttHoaDon.Select_LenhXuatKho_BySoLenh(Err, W_SoLenh).Tables(0)


        Provider = GetDataTable("InforHoaDonHangGiuHo", p_SQL)
        If Provider.Rows.Count > 0 Then
            txtCompany.Text = Provider.Rows(0).Item(0).ToString()
            'txtDonViGiaoHang.Text = Provider.Rows(0).Item(0).ToString()
            'txtDiaChiDonViGiaoHang.Text = Provider.Rows(0).Item(1).ToString()
            'txtCompany.Text = "Cty Xăng dầu KVII - TNHH MTV"
            txtDonViGiaoHang.Text = "Tổng Kho Xăng dầu Nhà Bè"
            txtDiaChiDonViGiaoHang.Text = "Khu phố 6, đường Huỳnh Tấn Phát, thị trấn Nhà Bè, Hồ Chí Minh"
        End If
        p_SQL = "exec sp_Reports_HoaDonE5 '" & W_SoLenh & "'"
        W_DSET = GetDataSet(p_SQL, p_SQL)
        ' W_DSET = Provider.GetDataSetProcedure("sp_Reports_HoaDonE5", New SqlParameter("@SoLenh", txtSoLenh.Text))

        p_SQL = "exec KhachHangGetByID '" & W_DSET.Tables(0).Rows(0).Item(3).ToString() & "'"
        Provider = GetDataTable(p_SQL, p_SQL)

        'Provider.GetDataTableProcedure("KhachHangGetByID", New SqlParameter("@MaKhachHang", Provider.DSet.Tables(0).Rows(0).Item(3).ToString()))
        If Provider.Rows.Count > 0 Then
            'txtDonViNhanHang.Text = Provider.Rows(0).Item(1).ToString()
            txtDonViNhanHang.Text = Provider.Rows(0).Item(0).ToString.Trim(New Char() {"0"c}) + " - " + Provider.Rows(0).Item(1).ToString()
            txtDiaChiDonViNhanHang.Text = Provider.Rows(0).Item(5).ToString()

        End If

        p_Binding.DataSource = W_dt_HoaDonCT
        Me.TrueDBGrid1.DataSource = p_Binding
        Me.TrueDBGrid1.Refresh()
        Me.GridView1.RefreshData()
        GridView1.OptionsBehavior.ReadOnly = True
        Me.dtNgayXuat.EditValue = p_Date
        Me.dtpDieuDong.EditValue = p_Date


        p_SQL = " Where SoLenh='" & p_SoLenh & "' and LoaiChungTu='" & p_LoaiChungTu & "'"
        Me.DefaultWhere = p_SQL

        Me.DefaultFormLoad = True
        Me.XtraForm1_Load()
        Me.DefaultFormLoad = False

        'txtCompany.Text = "CTy xăng dầu KVII - TNHH MTV" 'hieptd4 add for test

        p_SQL = ""
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SQL = Me.SoLenh.EditValue.ToString.Trim
        End If

        If p_SQL = "" Then
            Me.SoLenh.EditValue = p_SoLenh
        End If



    End Sub

    Public Sub New(ByVal i_SoLenh As String)

        ' This call is required by the designer.
        InitializeComponent()
        W_SoLenh = i_SoLenh
        txtSoLenh.EditValue = i_SoLenh
        p_SoLenh = i_SoLenh

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
        Dim rpt As New KV2_HoaDonHangGiuHo
        Dim rpt_sub As New KV2_HoaDonHangGiuHo_Sub
        Dim p_Count As Integer
        'Dim frmView As New frmPrint
        Try
            If Me.Check_Control_Required = False Then
                Exit Sub
            End If


            If Me.FormStatus = True Then
                Me.LoaiChungTu.EditValue = p_LoaiChungTu
                Me.DefaultSave = True
                Me.UpdateToDatabase(Me, Nothing)
                Me.DefaultSave = False
            End If


            DtTable = W_DSET.Tables(0)
            DtTable1 = W_DSET.Tables(1)
            DtTable2 = W_DSET.Tables(2)

            'rpt.PrintOptions.PrinterName = _DefaultPrint
            SubTable = Alter_Sub_Table(DtTable, DtTable1)

            ' Dim rpt As New rptHoaDonVCNB



            'rpt.DataSource = SubTable
            rpt_sub.DataSource = SubTable
            rpt.XrSubreport1.ReportSource = rpt_sub

            srt_dt = Format(dtNgayXuat.EditValue, "dd/MM/yyyy").ToString
            srt_dieudong = Format(dtpDieuDong.EditValue, "dd/MM/yyyy").ToString
            rpt.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
            rpt.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
            rpt.Parameters.Item("P_Nam").Value = srt_dieudong.Substring(6, 4)

            rpt.Parameters.Item("P_NgayDieuDong").Value = srt_dieudong.Substring(0, 2)
            rpt.Parameters.Item("P_ThangDieuDong").Value = srt_dieudong.Substring(3, 2)
            rpt.Parameters.Item("P_NamDieuDong").Value = srt_dieudong.Substring(6, 4)

            'rpt.SetParameterValue("P_Nam", srt_dt.Substring(8, 2))

            rpt.Parameters.Item("P_SoLenh").Value = txtSoLenh.Text.Trim()
            'rpt.Parameters.Item("P_CuaDonVi").Value = "CTy xăng dầu KVII - TNHH MTV" 'txtCompany.Text  hieptd4 add for test
            rpt.Parameters.Item("P_DonViGiaoHang").Value = txtDonViGiaoHang.Text
            rpt.Parameters.Item("P_DonViGiaoHangDiaChi").Value = txtDiaChiDonViGiaoHang.Text
            rpt.Parameters.Item("P_DonViMua").Value = txtDonViNhanHang.Text
            rpt.Parameters.Item("P_DiaChi_MH").Value = txtDiaChiDonViNhanHang.Text
            'rpt.SetParameterValue("P_DonViMua", DtTable.Rows(0).Item("TenKhachHang").ToString)
            'rpt.SetParameterValue("P_DiaChi_MH", DtTable.Rows(0).Item("DiaChi").ToString)

            rpt.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            'rpt.SetParameterValue("P_MaTienKiem", DtTable.Rows(0).Item("SoLenh").ToString)
            rpt.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
            rpt.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
            rpt.Parameters.Item("P_SoNiem").Value = DtTable.Rows(0).Item("Niem").ToString
            rpt.Parameters.Item("P_DiemGiaoHang").Value = txtDiemGiaoHang.Text
            rpt.Parameters.Item("P_KhoNhap").Value = txtKhoNhap.Text
            rpt.Parameters.Item("P_DonViCCVanTai").Value = txtDonViCungCapVanTai.Text

            For Each r As DataRow In DtTable2.Rows
                srt_hhh += "N" + r.Item("HHH").ToString + ";"
            Next

            rpt.Parameters.Item("P_KhoangCachTamMuc").Value = srt_hhh

            Dim times As Date = Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
            rpt.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd.MM.yyyy}", times)
            'rpt.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString
            rpt.Parameters.Item("P_NgayGiaoDich").Value += "/" & String.Format("{0}:{1}", times.Hour, times.Minute)

            'Update Dữ liệu vào bảng tblThongTinHoaDon
            For p_Count = 0 To rpt.Parameters.Count - 1
                rpt.Parameters.Item(p_Count).Visible = False
            Next
            '----------------------
            If chkCheck.Checked Then
                rpt.PrinterName = g_DefaultPrint
                rpt.Print()
            Else
                rpt.ShowPreviewDialog()
            End If

            Update_TTHoaDon()

        Catch ex As Exception
            'mdlMessage.mdlMessage_SendMessage(False, "m021", lblMess)
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
                    "'" & Me.txtSoLenh.Text.ToString.Trim & "'" & _
                    ",'" & p_DataRow.Item(0).ToString.Trim & "'" & _
                    ",'" & CDate(dtNgayXuat.Text).ToString("yyyyMMdd") & "'" & _
                    ",0" & _
                    ",0" & _
                    ",0" & _
                        ",''" & _
                    ",'" & Me.txtSoLenh.Text & "'" & _
                     "," & p_DataRow.Item(5).ToString.Trim
                If SQL_Execute(p_SQL, p_SQL) = False Then
                    ShowMessageBox("", p_SQL)
                    Exit Sub
                End If
            Next

            p_SQL = " exec DonViUpdateAddress N'" & txtDiaChiDonViGiaoHang.Text & "'"
            If SQL_Execute(p_SQL, p_SQL) = False Then
                ShowMessageBox("", p_SQL)
                Exit Sub
            End If

            'Dim sqlPara() As SqlParameter = New SqlParameter(1) {}
            'sqlPara(0) = New SqlParameter("@MaKhachHang", Provider.DSet.Tables(0).Rows(0).Item(3).ToString())
            'sqlPara(1) = New SqlParameter("@DiaChiFull", txtDiaChiDonViNhanHang.Text)
            'Provider.ExecuteSqlQuery("KhachHangUpdateAddress", sqlPara)


            p_SQL = " exec KhachHangUpdateAddress '" & Provider.Rows(0).Item(3).ToString.Trim & "',N'" & txtDiaChiDonViNhanHang.Text & "'"
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
        Dim l_quantity As Decimal()

        TongTien = 0
        Try
            SubTable = l_ds_sub.Tables(1).Clone()
            Dim index As Integer = 0

            l_mavanchuyen = dtTable0.Rows(0)("MaVanChuyen").ToString()
            l_thuybo = mdlDelivery_CheckTransmot(l_mavanchuyen, g_dt_para)

            If dtTable.Rows.Count > 0 Then
                For Each r As DataRow In dtTable.Rows
                    dtRow = SubTable.NewRow
                    dtRow("MaHangHoa") = r.Item("MaHangHoa").ToString
                    dtRow("TenHangHoa") = r.Item("TenHangHoa").ToString
                    dtRow("DonViTinh") = r.Item("DonViTinh").ToString

                    If l_thuybo.ToUpper() = "THUY" Then
                        l_quantity = Calculate_1(r.Item("LineID").ToString())
                    Else
                        l_quantity = Calculate_1(r.Item("LineID").ToString())
                    End If

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

                    dtRow("Bottom") = ND_VCF(l_quantity(0).ToString(), r.Item("MaHangHoa").ToString, r.Item("DonViTinh").ToString, index)
                    SubTable.Rows.Add(dtRow)
                    index += 1
                Next
            End If

        Catch ex As Exception
            Return Nothing
        End Try
        Return SubTable
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
            ND = Format(CInt(ND), "n2").ToString 'hieptd4 add
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

            KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0") '.Replace(",", ".")
            L15 = Format(CInt(p_DataRow.Item("L15").ToString()), "n0") '.Replace(",", ".")

            'FES
            '20141027
            Select Case unitID.ToUpper
                Case "L"
                    Select Case productID.ToUpper
                        Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
                            'Hed = "Nhiệt độ TT/KG/L15/D15/VCF/WCF: "

                            'Full = Hed + ND + " / " + KG + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF

                            Hed = "L15/Kg/to/D15/VCF/WCF  " '+ vbCrLf
                            Full = Hed + L15 + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                        Case "0701001", "0701002", "0701003"
                            'Hed = "Nhiệt độ TT/KG/D15/VCF/WCF: "
                            Hed = "Kg/to/D15/VCF/WCF  " '+ vbCrLf

                            KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
                            'Full = Hed + ND + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
                            Full = Hed + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    End Select
                Case "L15"
                    Select Case productID.ToUpper
                        Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
                            'Hed = "Nhiệt độ TT/LTT/KG/D15/VCF/WCF: "
                            Hed = "LTT/Kg/to/D15/VCF/WCF  " '+ vbCrLf

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

                            'Full = Hed + ND + " / " + TX + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
                            Full = Hed + TX + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF
                    End Select
                Case "KG"
                    Select Case productID.ToUpper
                        Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
                            'Hed = "Nhiệt độ TT/LTT/L15/D15/VCF/WCF: "
                            Hed = "LTT/L15/to/D15/VCF/WCF  " '+ vbCrLf

                            TX = p_DataRow.Item("TổngXuất").ToString()

                            'Full = Hed + ND + " / " + TX + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF
                            Full = Hed + TX + " / " + L15 + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                        Case "0701001", "0701002", "0701003"
                            'Hed = "Nhiệt độ TT/LTT/D15/VCF/WCF: "
                            Hed = "LTT/to/D15/VCF/WCF  " '+ vbCrLf

                            TX = p_DataRow.Item("TổngXuất").ToString()

                            'Full = Hed + ND + " / " + TX + " / " + D15 + " / " + VCF + " / " + WCF
                            Full = Hed + TX + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    End Select
            End Select

            Return Full
        Catch ex As Exception
            ShowStatusMessage(True, "", ex.Message, 5)
            Return Nothing
        End Try
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

End Class