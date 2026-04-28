Public Class frmImfor_HoaDon
    Private W_SoLenh As String
    Private TongTien As Int64 = 0
    Private W_ThueGTGT As Int64 = 0
    Private W_ChietKhau As Int64 = 0
    Private W_Ngay As String = String.Empty
    Private W_Thang As String = String.Empty
    Private W_Nam As String = String.Empty
    Private W_LineID As String = String.Empty
    Private W_dt_HoaDonCT As DataTable
    Private W_dt_HoaDonTT As DataTable
    Private W_ttHoaDon As New BSThongTinHoaDon
    Private W_Item As Integer = 0
    Private Err As String = String.Empty
    Private W_Time As Integer = 0
    Private W_Limit_Time As Integer = 5
    Private Provider As DataSet


    Private p_LoaiChungTu As String = "GTGT"
    Private p_SoLenh As String = ""

    Public Property sSoLenh As String
        Get
            Return p_SoLenh
        End Get
        Set(ByVal value As String)
            p_SoLenh = value
        End Set

    End Property


    Private Sub frmImfor_HoaDon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim p_SQL As String
            Dim p_Count As Integer
            Dim p_datetime As DateTime
            W_dt_HoaDonCT = Get_HoaDon_ChiTietNew(W_SoLenh)
            Dim p_Binding As New U_TextBox.U_BindingSource

            Dim p_ColNumber As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

            'reateFieldForm(Me)

            ' dgvProduct.DataSource = W_dt_HoaDonCT
            'dgvProduct.Columns(0).Visible = False
            'dgvProduct.Columns(2).Visible = False
            'dgvProduct.Columns(1).Width = 50
            'dgvProduct.Columns(1).ReadOnly = True
            'dgvProduct.Columns(3).ReadOnly = True
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
            Me.TrueDBGrid1.DataSource = p_Binding
            Me.TrueDBGrid1.Refresh()
            Me.GridView1.RefreshData()
            'GridView1.OptionsBehavior.ReadOnly = True
            If W_dt_HoaDonTT.Rows.Count > 0 Then
                txtSoHoaDon.Text = W_dt_HoaDonTT.Rows(0)(7).ToString() 'hieptd4 edit 20161206
            End If

            txtSoDO.Text = W_SoLenh 'hieptd4 add 20161206

            p_Binding.DataSource = W_dt_HoaDonCT


            For p_Count = 0 To GridView1.Columns.Count - 1
                ' p_SQL = GridView1.Columns(p_Count).FieldName.ToString.Trim
                Select Case UCase(GridView1.Columns(p_Count).FieldName.ToString.Trim)
                    Case "ĐƠNGIÁ"
                        p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
                        p_ColNumber.Buttons(0).Visible = False
                        p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        p_ColNumber.DisplayFormat.FormatString = "#,###0."
                        p_ColNumber.EditMask = "#,###0."
                        GridView1.Columns(p_Count).ColumnEdit = p_ColNumber
                        GridView1.Columns(p_Count).OptionsColumn.ReadOnly = False
                    Case "CHIẾTKHẤU"
                        p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
                        p_ColNumber.Buttons(0).Visible = False
                        p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        p_ColNumber.DisplayFormat.FormatString = "#,###0."
                        p_ColNumber.EditMask = "#,###0."
                        GridView1.Columns(p_Count).ColumnEdit = p_ColNumber
                        'GridView1.Columns(p_Count).OptionsColumn.ReadOnly = False
                    Case Else
                        GridView1.Columns(p_Count).OptionsColumn.ReadOnly = True
                End Select
            Next

            Provider = GetDataSet("exec sp_Reports_HoaDonE5 '" & W_SoLenh & "'", p_SQL)
            txtDonViMuaHang.Text = Provider.Tables(0).Rows(0).Item(4).ToString()
            txtDiChiDonViMuaHang.Text = Provider.Tables(0).Rows(0).Item(5).ToString()
            txtMaSoThue.Text = Provider.Tables(0).Rows(0).Item(6).ToString()
            p_GetCurrentDate(p_datetime)
            If Me.dtNgayXuat.Text = "" Then
                Me.dtNgayXuat.EditValue = p_datetime 'Now.Date 'hieptd4 edit 20161206
            End If
            'hieptd4 add 20161206
            If Me.dtBillingDate.Text = "" Then
                Me.dtBillingDate.EditValue = p_datetime
            End If
            If Me.dtNgayHoaDon.Text = "" Then
                Me.dtNgayHoaDon.EditValue = p_datetime
            End If
            'end hieptd4 add 20161206

            txtDonViBanHang.Text = Provider.Tables(0).Rows(0).Item(0).ToString()
            txtDiaChiDonViBanHang.Text = Provider.Tables(0).Rows(0).Item(1).ToString()
            txtMaSoThueDonViBanHang.Text = Provider.Tables(0).Rows(0).Item(2).ToString()

            Get_Data_Default()

            p_SQL = " Where SoLenh='" & p_SoLenh & "' and LoaiChungTu='" & p_LoaiChungTu & "'"
            Me.DefaultWhere = p_SQL

            Me.DefaultFormLoad = True
            Me.XtraForm1_Load()
            Me.DefaultFormLoad = False
            If Me.dtNgayHoaDon.Text = "" Then 'hieptd4 add 20161206
                Me.dtNgayHoaDon.EditValue = p_datetime
            End If
            p_SQL = ""
            If Not Me.SoLenh.EditValue Is Nothing Then
                p_SQL = Me.SoLenh.EditValue.ToString.Trim
            End If

            If p_SQL = "" Then
                Me.SoLenh.EditValue = p_SoLenh
            End If

            Me.GridView1.OptionsView.ColumnAutoWidth = False
            Me.GridView1.BestFitColumns()
        Catch ex As Exception
            ShowStatusMessage(True, "", ex.Message, 5)
        End Try
    End Sub

    Private Sub Get_Data_Default()
        Dim p_Date As Date
        Dim p_Time As Integer
        p_GetDateTime(p_Date, p_Time)
        Try
            If W_dt_HoaDonTT.Rows.Count > 0 Then
                txtPhuongThuc.Text = IIf(IsDBNull(W_dt_HoaDonTT.Rows(0).Item("PhuongThuc")), "", W_dt_HoaDonTT.Rows(0).Item("PhuongThuc"))
                'For i As Integer = 0 To dgvProduct.RowCount - 1
                'dgvProduct.Rows(i).Cells(4).Value = IIf(IsDBNull(W_dt_HoaDonTT.Rows(i).Item("DonGia")), 0, W_dt_HoaDonTT.Rows(i).Item("DonGia"))
                'dgvProduct.Rows(i).Cells(5).Value = IIf(IsDBNull(W_dt_HoaDonTT.Rows(i).Item("ChietKhau")), 0, W_dt_HoaDonTT.Rows(i).Item("ChietKhau"))
                'Next
            Else
                dtNgayXuat.EditValue = p_Date
                'txtThueGTGT.EditValue = 10
                'txtPhuongThuc.Text = String.Empty
                txtThueGTGT.EditValue = Provider.Tables(0).Rows(0).Item(15).ToString  'hieptd4 add 20161102
                txtPhuongThuc.Text = Provider.Tables(0).Rows(0).Item(16).ToString 'hieptd4 add 20161102
                txtThoiHanThanhToan.Text = Provider.Tables(0).Rows(0).Item(17).ToString 'hieptd4 add 20161102
                txtDonViCCVanTai.Text = Provider.Tables(0).Rows(0).Item(18).ToString 'hieptd4 add 20161102
            End If
            txtNguoiMuaHang.Focus()
        Catch ex As Exception
            ShowStatusMessage(True, "", ex.Message, 5)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        'If Check_in() Then
        '    Exit Sub
        'End If
        Dim dtSet As DataSet
        Dim DtTable As New DataTable
        Dim DtTable1 As New DataTable
        Dim DtTable2 As New DataTable
        Dim SubTable As New DataTable
        Dim srt_dt As String = String.Empty
        Dim srt_hhh As String = String.Empty
        ' Dim frmView As New frmPrint
        Dim p_SQL As String
        Dim p_RptHoasDon1 As New KV1_HoaDon
        Dim p_RptHoasDon_Sub1 As New KV1_HoaDon_Sub
        Dim p_RptHoasDon As New KV1_HoaDon  'KV2_HoaDonVCNB
        Dim p_RptHoasDon_Sub As New KV1_HoaDon_Sub  'KV2_HoaDonVCNB_Sub
        Dim p_Count As Integer
        Dim p_Date As DateTime


        p_GetCurrentDate(p_Date)


        Try
            If Me.Check_Control_Required = False Then
                Exit Sub
            End If


            If Me.FormStatus = True Then

                Me.DefaultSave = True
                Me.LoaiChungTu.EditValue = p_LoaiChungTu

                Me.UpdateToDatabase(Me, Nothing)

                Me.DefaultSave = False
            End If

            ' 01/02/2013 QueHV Sua lay lay du lieu DataSet
            p_SQL = "exec sp_Reports_HoaDonE5 '" & W_SoLenh & "'"
            'dtSet = Provider.GetDataSetProcedure("sp_Reports_HoaDonE5", New SqlParameter("@SoLenh", W_SoLenh))
            dtSet = GetDataSet(p_SQL, p_SQL)
            DtTable = dtSet.Tables(0)
            DtTable1 = dtSet.Tables(1)
            DtTable2 = dtSet.Tables(2)

            SubTable = Alter_Sub_Table(DtTable, DtTable1)
            If W_ChietKhau > 0 Then

                'rpt.Subreports(0).SetDataSource(SubTable)
                'p_RptHoasDon1.DataSource = DtTable1
                p_RptHoasDon_Sub1.DataSource = SubTable
                p_RptHoasDon1.XrSubreport1.ReportSource = p_RptHoasDon_Sub1

                srt_dt = Format(dtNgayHoaDon.EditValue, "dd/MM/yyyy").ToString 'srt_dt = Format(dtNgayXuat.EditValue, "dd/MM/yyyy").ToString
                p_RptHoasDon1.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
                p_RptHoasDon1.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
                p_RptHoasDon1.Parameters.Item("P_Nam").Value = srt_dt.Substring(6, 4)   ' Date.Now.Year
                'rpt.SetParameterValue("P_Nam", srt_dt.Substring(8, 2))

                p_RptHoasDon1.Parameters.Item("P_DonViBan").Value = Me.txtDonViBanHang.Text
                p_RptHoasDon1.Parameters.Item("P_DiaChi_BH").Value = Me.txtDiaChiDonViBanHang.Text
                p_RptHoasDon1.Parameters.Item("P_MaSoThue_BH").Value = Me.txtMaSoThueDonViBanHang.Text

                p_RptHoasDon1.Parameters.Item("P_DonViMua").Value = Me.txtDonViMuaHang.Text  ' DtTable.Rows(0).Item("TenKhachHang").ToString
                p_RptHoasDon1.Parameters.Item("P_NguoiMua").Value = txtNguoiMuaHang.Text

                p_RptHoasDon1.Parameters.Item("P_DiaChi_MH").Value = DtTable.Rows(0).Item("DiaChi").ToString
                p_RptHoasDon1.Parameters.Item("P_ThoiHanThanhToan").Value = txtThoiHanThanhToan.Text

                p_RptHoasDon1.Parameters.Item("P_MaSoThue_MH").Value = DtTable.Rows(0).Item("MaSoThue").ToString
                p_RptHoasDon1.Parameters.Item("P_TongCong").Value = Format(Convert.ToInt64(TongTien - W_ChietKhau), "n0").Replace(",", ".")

                ' 01/02/2013 QueHV Sua cach tinh thue GTGT theo cach tinh ma nghiep vu cung cap
                p_RptHoasDon1.Parameters.Item("P_ThueGTGT").Value = txtThueGTGT.Text.Trim
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
                'p_RptHoasDon1.Parameters.Item("P_MaTimKiem").Value = "HiepTD4 test Mã tìm kiếm" 'hieptd4 test
                p_RptHoasDon1.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
                p_RptHoasDon1.Parameters.Item("P_SoNiem").Value = DtTable.Rows(0).Item("Niem").ToString
                Dim times As Date = Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
                p_RptHoasDon1.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd/MM/yyyy}", times)
                p_RptHoasDon1.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString


                For Each r As DataRow In DtTable2.Rows
                    srt_hhh += "H" + r.Item("HHH").ToString + ";"
                Next

                p_RptHoasDon1.Parameters.Item("P_KhoangCachTamMuc").Value = srt_hhh
                p_RptHoasDon1.Parameters.Item("P_PhuongThucTT").Value = txtPhuongThuc.Text.Trim
                p_RptHoasDon1.Parameters.Item("P_DonViCungCapVanTai").Value = txtDonViCCVanTai.Text
                p_RptHoasDon1.Parameters.Item("P_ChietKhauThuongMai").Value = Format(W_ChietKhau, "n0").Replace(",", ".")
                For p_Count = 0 To p_RptHoasDon1.Parameters.Count - 1
                    p_RptHoasDon1.Parameters(p_Count).Visible = False
                Next
                p_RptHoasDon1.RequestParameters = False
                If chkCheck.Checked Then
                    p_RptHoasDon1.PrinterName = g_DefaultPrint
                    p_RptHoasDon.Print()
                Else
                    p_RptHoasDon1.ShowPreviewDialog()
                End If
            Else
                Try
                    p_RptHoasDon_Sub.DataSource = SubTable
                    p_RptHoasDon.XrSubreport1.ReportSource = p_RptHoasDon_Sub

                    srt_dt = Format(dtNgayHoaDon.EditValue, "dd/MM/yyyy").ToString 'srt_dt = Format(dtNgayXuat.EditValue, "dd/MM/yyyy").ToString
                    p_RptHoasDon.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
                    p_RptHoasDon.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
                    p_RptHoasDon.Parameters.Item("P_Nam").Value = srt_dt.Substring(6, 4)  'Date.Now.Year

                    p_RptHoasDon.Parameters.Item("P_DonViBan").Value = Me.txtDonViBanHang.Text
                    p_RptHoasDon.Parameters.Item("P_DiaChi_BH").Value = Me.txtDiaChiDonViBanHang.Text
                    p_RptHoasDon.Parameters.Item("P_MaSoThue_BH").Value = Me.txtMaSoThueDonViBanHang.Text
                    p_RptHoasDon.Parameters.Item("P_LenhXuat").Value = "( Theo lệnh xuất số " + DtTable.Rows(0).Item("SoLenh") + " - " + srt_dt + " )"

                    p_RptHoasDon.Parameters.Item("P_DonViMua").Value = Me.txtDonViMuaHang.Text '  DtTable.Rows(0).Item("TenKhachHang").ToString
                    p_RptHoasDon.Parameters.Item("P_NguoiMua").Value = txtNguoiMuaHang.Text

                    'p_RptHoasDon.Parameters.Item("P_DiaChi_MH").Value = DtTable.Rows(0).Item("DiaChi").ToString                   
                    p_RptHoasDon.Parameters.Item("P_DiaChi_MH").Value = txtDiChiDonViMuaHang.Text

                    p_RptHoasDon.Parameters.Item("P_ThoiHanThanhToan").Value = txtThoiHanThanhToan.Text

                    p_RptHoasDon.Parameters.Item("P_MaSoThue_MH").Value = DtTable.Rows(0).Item("MaSoThue").ToString
                    p_RptHoasDon.Parameters.Item("P_TongCong").Value = Format(Convert.ToInt64(TongTien - W_ChietKhau), "n0").Replace(",", ".")

                    ' 01/02/2013 QueHV Sua cach tinh thue GTGT theo cach tinh ma nghiep vu cung cap
                    p_RptHoasDon.Parameters.Item("P_ThueGTGT").Value = txtThueGTGT.Text.Trim
                    p_RptHoasDon.Parameters.Item("P_TienThueGTGT").Value = Format(CInt(W_ThueGTGT), "n0").Replace(",", ".")

                    'rpt.SetParameterValue("P_TienThueGTGT", Format((TongTien * Convert.ToInt64(txtThueGTGT.Text.Trim) / 100), "n0"))
                    'rpt.SetParameterValue("P_TienKhac", Format(CInt(txtTienKhac.Text.Trim), "n0"))
                    Dim TongThanhToan As Long = 0
                    TongThanhToan = TongTien - W_ChietKhau + W_ThueGTGT
                    'TongThanhToan = TongTien + TienPhiKhac + (TongTien * Convert.ToInt64(txtThueGTGT.Text.Trim) / 100)
                    p_RptHoasDon.Parameters.Item("P_TongThanhToan").Value = Format(TongThanhToan, "n0").Replace(",", ".")

                    p_RptHoasDon.Parameters.Item("P_TongBangChu").Value = mdlFunction.Number2Text(CLng(TongThanhToan)) + " đồng chẵn"
                    p_RptHoasDon.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
                    'p_RptHoasDon.Parameters.Item("P_MaKhachHang").Value = DtTable.Rows(0).Item("MaKhachHang").ToString
                    p_RptHoasDon.Parameters.Item("P_MaKhachHang").Value = DtTable.Rows(0).Item("MaKhachHang").Substring(DtTable.Rows(0).Item("MaKhachHang").Length - 6)
                    p_RptHoasDon.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
                    'p_RptHoasDon.Parameters.Item("P_MaTimKiem").Value = "HiepTD4 test Mã tìm kiếm" 'hieptd4 test
                    p_RptHoasDon.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
                    p_RptHoasDon.Parameters.Item("P_SoNiem").Value = DtTable.Rows(0).Item("Niem").ToString
                    Dim times As Date = p_Date   ' Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
                    p_RptHoasDon.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd/MM/yyyy}", times)
                    p_RptHoasDon.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString


                    For Each r As DataRow In DtTable2.Rows
                        srt_hhh += "H" + r.Item("HHH").ToString + ";"
                    Next

                    p_RptHoasDon.Parameters.Item("P_KhoangCachTamMuc").Value = srt_hhh
                    p_RptHoasDon.Parameters.Item("P_PhuongThucTT").Value = txtPhuongThuc.Text.Trim
                    p_RptHoasDon.Parameters.Item("P_DonViCungCapVanTai").Value = txtDonViCCVanTai.Text
                    'p_RptHoasDon.Parameters.Item("P_ChietKhauThuongMai").Value = Format(W_ChietKhau, "n0").Replace(",", ".")
                    For p_Count = 0 To p_RptHoasDon.Parameters.Count - 1
                        p_RptHoasDon.Parameters(p_Count).Visible = False
                    Next
                    p_RptHoasDon.RequestParameters = False
                    If chkCheck.Checked Then
                        p_RptHoasDon.PrinterName = g_DefaultPrint
                        p_RptHoasDon.Print()
                    Else
                        p_RptHoasDon.ShowPreviewDialog()
                    End If
                    'p_RptHoasDon.ShowPreviewDialog()
                Catch ex As Exception

                End Try

            End If

            Update_TTHoaDon()

            Exit Sub
            '------------------------------------------------------------
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ShowMessageBox("", ex.Message)
        End Try
    End Sub

    Private Function Check_in() As Boolean
        Dim p_DataRow As DataRow

        For index As Integer = 0 To Me.GridView1.RowCount - 1
            p_DataRow = Me.GridView1.GetDataRow(index)
            If IsNumeric(p_DataRow.Item(4).ToString().Trim()) = False Then
                'MessageBox.Show("Dữ liệu đơn giá sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ShowMessageBox("", "Dữ liệu đơn giá sai")
                Return True
                Exit For
            End If

            If IsNumeric(p_DataRow.Item(5).ToString().Trim()) = False Then
                'MessageBox.Show("Dữ liệu đơn giá sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ShowMessageBox("", "Dữ liệu nhập sai")
                Return True
                Exit For
            End If
        Next

        If IsNumeric(txtThueGTGT.Text.Trim) = False Then
            'MessageBox.Show("Dữ liệu thuế GTGT sai", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ShowMessageBox("", "Dữ liệu thuế GTGT sai")
            txtThueGTGT.Focus()
            Return True
        End If

        Return False
    End Function


    Private Sub Update_TTHoaDon()
        ' Check_in()
        Dim p_SQL As String
        Dim p_DataRow As DataRow
        Try

            For index As Integer = 0 To Me.GridView1.RowCount - 1
                p_DataRow = Me.GridView1.GetDataRow(index)
                p_SQL = "exec ThongTinHoaDonTransaction " & _
                    "N'" & Me.TxtSoLenh.Text.ToString.Trim & "'" & _
                    ",N'" & p_DataRow.Item(0).ToString.Trim & "'" & _
                    ",'" & CDate(dtNgayXuat.Text).ToString("yyyyMMdd") & "'" & _
                    "," & p_DataRow.Item(4).ToString.Trim & "" & _
                    "," & txtThueGTGT.Text & "" & _
                    "," & p_DataRow.Item(5).ToString.Trim & "" & _
                        ",N'" & txtPhuongThuc.Text & "'" & _
                    ",'" & txtSoDO.Text & "'" & _
                     "," & p_DataRow.Item(5).ToString.Trim
                If SQL_Execute(p_SQL, p_SQL) = False Then
                    ShowMessageBox("", p_SQL)
                    Exit Sub
                End If
            Next
            p_SQL = " exec KhachHangUpdateAddress '" & Provider.Tables(0).Rows(0).Item(3).ToString.Trim & "',N'" & txtDiChiDonViMuaHang.Text & "'"
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
        Dim SoLuong As Int64 = 0
        Dim SubTable As DataTable
        Dim dtRow As DataRow
        Dim l_ds_sub As New RpSub()
        Dim l_thanhtien As Int64
        Dim l_dongia As Int64
        Dim l_quantity As Decimal()
        Dim p_DataRow As DataRow
        l_dongia = 0
        TongTien = 0
        l_thanhtien = 0

        Try
            SubTable = l_ds_sub.Tables(1).Clone()

            SubTable.Columns.Remove("TongDuXuat")
            SubTable.Columns.Add("TongDuXuat")

            Dim index As Integer = 0
            W_ThueGTGT = 0
            W_ChietKhau = 0
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
                    l_quantity = Calculate_1(r.Item("LineID").ToString())
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

                'dtRow("TongDuXuat") = SoLuong
                dtRow("TongDuXuat") = Format(SoLuong, "n0").Replace(",", ".")
                p_DataRow = Me.GridView1.GetDataRow(index)
                l_dongia = CDec(IIf(p_DataRow(4).ToString.Trim = "", 0, p_DataRow(4).ToString()))
                l_thanhtien = Math.Round(l_dongia * SoLuong, 0)

                dtRow("DonGia") = Format(l_dongia, "n0").Replace(",", ".")
                dtRow("ThanhTien") = Format(l_thanhtien, "n0").Replace(",", ".")
                dtRow("Bottom") = ND_VCF(l_quantity(0), r.Item("MaHangHoa").ToString, r.Item("DonViTinh").ToString, index)
                SubTable.Rows.Add(dtRow)
                W_ChietKhau += CInt(p_DataRow(5).ToString().Trim())

                'W_ThueGTGT += Math.Round((((l_thanhtien - CDbl(dgvProduct.Rows(index).Cells(5).Value.ToString().Trim())) * CInt(txtThueGTGT.Text.Trim()) / 100)), 0)
                TongTien += l_thanhtien
                index += 1
            Next
            W_ThueGTGT = Math.Round(((TongTien - W_ChietKhau) * Convert.ToInt32(IIf(txtThueGTGT.Text.ToString.Trim = "", 0, txtThueGTGT.EditValue))) / 100, 0)
        Catch ex As Exception
            Return Nothing
        End Try
        Return SubTable
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

            l_quantity = mdlQCI_CalculateQCI_NS(l_soluong, "L", l_nhietdo, l_tytrong)  'l_quantity = mdlQCI_CalculateQCI(l_soluong, "L", l_vcf) 'hieptd4 edit 20161204
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
            '  ND = Format(CInt(ND), "n2").ToString 'hieptd4 add
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

                    If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
                        Hed = "Nhiệt độ TT/KG/L15/D15/VCF/WCF: " '+ vbCrLf

                        Full = Hed + ND + " / " + KG + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF

                        'Hed = "L15/Kg/to/D15/VCF/WCF: " + vbCrLf
                        'Full = Hed + L15 + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    End If

                    If InStr(g_HOADON2, productID.ToUpper, CompareMethod.Text) > 0 Then

                        Hed = "Nhiệt độ TT/KG/D15/VCF/WCF: " '+ vbCrLf
                        'Hed = "Kg/to/D15/VCF/WCF: " + vbCrLf

                        KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
                        Full = Hed + ND + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
                        'Full = Hed + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF
                    End If

                    'Select Case productID.ToUpper
                    '    Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
                    '        Hed = "Nhiệt độ TT/KG/L15/D15/VCF/WCF: " '+ vbCrLf

                    '        Full = Hed + ND + " / " + KG + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF

                    '        'Hed = "L15/Kg/to/D15/VCF/WCF: " + vbCrLf
                    '        'Full = Hed + L15 + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    '    Case "0701001", "0701002", "0701003"
                    '        Hed = "Nhiệt độ TT/KG/D15/VCF/WCF: " '+ vbCrLf
                    '        'Hed = "Kg/to/D15/VCF/WCF: " + vbCrLf

                    '        KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
                    '        Full = Hed + ND + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
                    '        'Full = Hed + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    'End Select
                Case "L15"

                    If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
                        Hed = "Nhiệt độ TT/LTT/KG/D15/VCF/WCF: " '+ vbCrLf
                        'Hed = "LTT/Kg/to/D15/VCF/WCF: " + vbCrLf

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
                        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add


                        Full = Hed + ND + " / " + TX + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
                        'Full = Hed + TX + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF
                    End If
                    'Select Case productID.ToUpper
                    '    Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
                    '        Hed = "Nhiệt độ TT/LTT/KG/D15/VCF/WCF: " '+ vbCrLf
                    '        'Hed = "LTT/Kg/to/D15/VCF/WCF: " + vbCrLf

                    '        'p_TongDuXuat
                    '        'If g_dtPara.Rows(16).Item("Value_nd").ToString().Trim() = "1" Then
                    '        '    TX = dgvProduct.Rows(dgvRow).Cells("TổngXuất").Value.ToString()
                    '        'Else
                    '        '    TX = dgvProduct.Rows(dgvRow).Cells("TổngDựXuất").Value.ToString()
                    '        'End If
                    '        If p_TongDuXuat = "0" Or p_TongDuXuat = "" Then
                    '            TX = p_DataRow.Item("TổngXuất").ToString()
                    '        Else
                    '            TX = p_DataRow.Item("TổngDựXuất").ToString()
                    '        End If
                    '        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add


                    '        Full = Hed + ND + " / " + TX + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
                    '        'Full = Hed + TX + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF
                    'End Select
                Case "KG"
                    If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
                        Hed = "Nhiệt độ TT/LTT/L15/D15/VCF/WCF: " '+ vbCrLf
                        'Hed = "LTT/L15/to/D15/VCF/WCF: " + vbCrLf

                        TX = p_DataRow.Item("TổngXuất").ToString()
                        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add

                        Full = Hed + ND + " / " + TX + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF
                        'Full = Hed + TX + " / " + L15 + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF
                    End If

                    If InStr(g_HOADON2, productID.ToUpper, CompareMethod.Text) > 0 Then
                        Hed = "Nhiệt độ TT/LTT/D15/VCF/WCF: " '+ vbCrLf
                        'Hed = "LTT/to/D15/VCF/WCF: " + vbCrLf

                        TX = p_DataRow.Item("TổngXuất").ToString()
                        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add

                        Full = Hed + ND + " / " + TX + " / " + D15 + " / " + VCF + " / " + WCF
                        'Full = Hed + TX + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF
                    End If
                    'Select Case productID.ToUpper
                    '    Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
                    '        Hed = "Nhiệt độ TT/LTT/L15/D15/VCF/WCF: " '+ vbCrLf
                    '        'Hed = "LTT/L15/to/D15/VCF/WCF: " + vbCrLf

                    '        TX = p_DataRow.Item("TổngXuất").ToString()
                    '        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add

                    '        Full = Hed + ND + " / " + TX + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF
                    '        'Full = Hed + TX + " / " + L15 + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    '    Case "0701001", "0701002", "0701003"
                    '        Hed = "Nhiệt độ TT/LTT/D15/VCF/WCF: " '+ vbCrLf
                    '        'Hed = "LTT/to/D15/VCF/WCF: " + vbCrLf

                    '        TX = p_DataRow.Item("TổngXuất").ToString()
                    '        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add

                    '        Full = Hed + ND + " / " + TX + " / " + D15 + " / " + VCF + " / " + WCF
                    '        'Full = Hed + TX + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    'End Select
            End Select

            Return Full
        Catch ex As Exception
            ShowStatusMessage(True, "", ex.Message, 5)
            Return Nothing
        End Try
    End Function
End Class