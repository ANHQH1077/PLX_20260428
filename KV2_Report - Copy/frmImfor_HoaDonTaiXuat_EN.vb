Public Class frmImfor_HoaDonTaiXuat_EN
    Private W_SoLenh As String
    'Private TongTien As Int64 = 0
    Private TongTien As Decimal
    'Private W_ThueGTGT As Int64 = 0
    Private W_ChietKhau As Int64 = 0
    'Private W_Ngay As String = String.Empty
    'Private W_Thang As String = String.Empty
    'Private W_Nam As String = String.Empty
    'Private W_LineID As String = String.Empty
    Private W_dt_HoaDonCT As DataTable
    Private W_dt_HoaDonTT As DataTable
    Private W_ttHoaDon As New BSThongTinHoaDon
    'Private W_Item As Integer = 0
    Private Err As String = String.Empty
    'Private W_Time As Integer = 0
    'Private W_Limit_Time As Integer = 5
    ' Private Provider As DataSet
    Private W_DSET As DataSet

    Private p_LoaiChungTu As String = "GTGT_GIUHO"
    Private p_SoLenh As String = ""

    Dim p_DataTable As New DataTable


    Private Sub frmImfor_HoaDonTaiXuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_ColNumber As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        Dim p_Date As Date

        Dim p_txtDonViGiaoHang As String
        Dim p_txtDiaChiDonViGiaoHang As String

        Dim p_txtDonViNhanHang As String
        Dim p_txtDiaChiDonViNhanHang As String

        If GTGT_EN = False Then
            p_LoaiChungTu = "HDTX_VN"
        Else
            p_LoaiChungTu = "HDTX_EN"
        End If


        W_dt_HoaDonCT = Get_HoaDon_ChiTietNew(W_SoLenh)

        p_Date = Get_ThoiGianDau(W_SoLenh)

        W_dt_HoaDonTT = W_ttHoaDon.Select_LenhXuatKho_BySoLenh(Err, W_SoLenh).Tables(0)

        'anhqh 
        '12-08-2017
        'Xu ly DO tính theo tấn nên đơn giá  phải chia 1000

        '   For p_Count=0 to


        p_Binding.DataSource = W_dt_HoaDonCT
        Me.TrueDBGrid1.DataSource = p_Binding
        Me.TrueDBGrid1.Refresh()
        Me.GridView1.RefreshData()
        'GridView1.OptionsBehavior.ReadOnly = True
        For p_Count = 0 To GridView1.Columns.Count - 1
            'For p_Count = 0 To GridView1.Columns.Count - 1
            ' p_SQL = GridView1.Columns(p_Count).FieldName.ToString.Trim
            Select Case UCase(GridView1.Columns(p_Count).FieldName.ToString.Trim)
                Case "ĐƠNGIÁ"
                    p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
                    p_ColNumber.Buttons(0).Visible = False
                    p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    p_ColNumber.DisplayFormat.FormatString = "#,###0.######"
                    p_ColNumber.EditMask = "#,###0.######"
                    GridView1.Columns(p_Count).ColumnEdit = p_ColNumber
                    GridView1.Columns(p_Count).OptionsColumn.ReadOnly = False
                Case "CHIẾTKHẤU"

                    GridView1.Columns(p_Count).VisibleIndex = -1
                Case Else
                    GridView1.Columns(p_Count).OptionsColumn.ReadOnly = True
            End Select
            'Next
        Next

        ' W_dt_HoaDonTT = W_ttHoaDon.Select_LenhXuatKho_BySoLenh(Err, W_SoLenh).Tables(0)

        'Provider = New SqlDataProvider(_SQLConnectionString)
        'W_DSET = Provider.GetDataSetProcedure("sp_Reports_HoaDonTaiXuatE5", New SqlParameter("@SoLenh", W_SoLenh))

        p_SQL = "exec sp_Reports_HoaDonTaiXuatE5 '" & W_SoLenh & "'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)

        txtDonViGiaoHang.EditValue = p_DataTable.Rows(0).Item(0).ToString()
        txtDiaChiDonViGiaoHang.EditValue = p_DataTable.Rows(0).Item(1).ToString()
        txtMST1.EditValue = p_DataTable.Rows(0).Item(2).ToString()
        txtDonViNhanHang.EditValue = p_DataTable.Rows(0).Item(4).ToString()
        txtDiaChiDonViNhanHang.EditValue = p_DataTable.Rows(0).Item(5).ToString()


        p_txtDonViGiaoHang = p_DataTable.Rows(0).Item(0).ToString()
        p_txtDiaChiDonViGiaoHang = p_DataTable.Rows(0).Item(1).ToString()

        p_txtDonViNhanHang = p_DataTable.Rows(0).Item(4).ToString()
        p_txtDiaChiDonViNhanHang = p_DataTable.Rows(0).Item(5).ToString()


        txtMST2.EditValue = p_DataTable.Rows(0).Item(6).ToString()

        txtSoHopDong.EditValue = p_DataTable.Rows(0).Item(13).ToString()
        txtNgayHopDong.EditValue = p_DataTable.Rows(0).Item(14).ToString()
        'txtNgayHopDong.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"    'hieptd4 add
        txtToKhaiHQ.EditValue = p_DataTable.Rows(0).Item(15).ToString()
        txtSoTK.EditValue = p_DataTable.Rows(0).Item(16).ToString()
        txtTygia.EditValue = p_DataTable.Rows(0).Item(17).ToString()
        txtDiemGiaoHang.EditValue = p_DataTable.Rows(0).Item("MaKho").ToString() '  p_DataTable.Rows(0).Item(18).ToString()
        txtDiemNhanHang.EditValue = p_DataTable.Rows(0).Item(25).ToString()
        txtPhuongThuc.EditValue = p_DataTable.Rows(0).Item(19).ToString()
        txtThoiHanThanhToan.EditValue = p_DataTable.Rows(0).Item(20).ToString()
        txtDonViCCVanTai.EditValue = p_DataTable.Rows(0).Item(21).ToString()
        txtSoPXK.EditValue = p_DataTable.Rows(0).Item(23).ToString()
        txtNgayPXK.EditValue = p_DataTable.Rows(0).Item(24).ToString()

        Get_Data_Default()
        txtNgayHopDong.Focus()

        p_SQL = " Where SoLenh='" & p_SoLenh & "' and LoaiChungTu='" & p_LoaiChungTu & "'"
        Me.DefaultWhere = p_SQL

        Me.DefaultFormLoad = True
        Me.XtraForm1_Load()
        Me.DefaultFormLoad = False
        p_SQL = ""
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SQL = Me.SoLenh.EditValue.ToString.Trim
        End If

        If p_SQL = "" Then
            Me.SoLenh.EditValue = p_SoLenh
        End If


        txtDonViGiaoHang.EditValue = p_txtDonViGiaoHang
        txtDiaChiDonViGiaoHang.EditValue = p_txtDiaChiDonViGiaoHang

        txtDonViNhanHang.EditValue = p_txtDonViNhanHang
        txtDiaChiDonViNhanHang.EditValue = p_txtDiaChiDonViNhanHang



        Me.dtNgayXuat.EditValue = p_Date
        txtToKhaiHQ.EditValue = p_DataTable.Rows(0).Item(15).ToString()
        txtSoTK.EditValue = p_DataTable.Rows(0).Item(16).ToString()
        ' Me.GridView1.OptionsView.ShowHorzLines = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.BestFitColumns()
    End Sub

    Private Sub Get_Data_Default()
        Try
            If W_dt_HoaDonTT.Rows.Count > 0 Then
                txtPhuongThuc.Text = IIf(IsDBNull(W_dt_HoaDonTT.Rows(0).Item("PhuongThuc")), "", W_dt_HoaDonTT.Rows(0).Item("PhuongThuc"))
                txtTygia.Text = IIf(IsDBNull(W_dt_HoaDonTT.Rows(0).Item("TienKhac")), "", W_dt_HoaDonTT.Rows(0).Item("TienKhac"))
                'For i As Integer = 0 To dgvProduct.RowCount - 1
                '    dgvProduct.Rows(i).Cells(4).Value = IIf(IsDBNull(W_dt_HoaDonTT.Rows(i).Item("DonGia")), 0, W_dt_HoaDonTT.Rows(i).Item("DonGia"))
                'Next
            Else
                dtNgayXuat.EditValue = Now.Date
                'txtPhuongThuc.Text = String.Empty
            End If
        Catch ex As Exception
            ShowMessageBox("", ex.Message)
            'mdlMessage.mdlMessage_SendMessage(False, "m021", lblMess)
        End Try
    End Sub


    Public Sub New(ByVal i_SoLenh As String)

        ' This call is required by the designer.
        InitializeComponent()
        ' txtSoHoaDon.Text = i_SoLenh
        ' txtSoLenh.Text = i_SoLenh
        W_SoLenh = i_SoLenh
        p_SoLenh = i_SoLenh
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If Me.Check_Control_Required = False Then
            Exit Sub
        End If


        If Me.FormStatus = True Then

         

            Me.DefaultSave = True
            Me.LoaiChungTu.EditValue = p_LoaiChungTu

            Me.UpdateToDatabase(Me, Nothing)

            Me.DefaultSave = False
        End If



        Dim DtTable As New DataTable
        Dim DtTable1 As New DataTable
        Dim DtTable2 As New DataTable
        Dim SubTable As New DataTable
        Dim srt_dt As String = String.Empty
        Dim srt_hhh As String = String.Empty
        Dim srt_dieudong As String = String.Empty
        Dim dtSet As DataSet
        Dim p_SQL As String
        Dim p_Count As Integer
        'Dim frmView As New frmPrint
        Try
            If GTGT_EN = False Then
                HoaDonGTGT_VN()
                Exit Sub
            End If
            p_SQL = "exec sp_Reports_HoaDonTaiXuatE5 '" & W_SoLenh & "'"
            'dtSet = Provider.GetDataSetProcedure("sp_Reports_HoaDonE5").Value =  New SqlParameter("@SoLenh").Value =  W_SoLenh))
            dtSet = GetDataSet(p_SQL, p_SQL)
            DtTable = dtSet.Tables(0)
            DtTable1 = dtSet.Tables(1)
            ' DtTable2 = dtSet.Tables(2)

            'DtTable = W_DSET.Tables(0)
            ' DtTable1 = W_DSET.Tables(1)
            'FES ANNV 10/11 sua in hoa don tai xuat
            'DtTable2 = W_DSET.Tables(2)

            'rpt.PrintOptions.PrinterName = _DefaultPrint
            SubTable = Alter_Sub_Table(DtTable, DtTable1)

           
            Dim rpt As New KV2_HoaDonTaiXuat_EN
            Dim rptsub As New KV2_HoaDonTaiXuat_Sub_EN

            'If GTGT_EN = True Then
            '    rpt = New KV2_HoaDonTaiXuat_EN
            '    rptsub = New KV2_HoaDonTaiXuat_Sub
            'Else
            '    rpt = New KV2_HoaDonTaiXuat
            '    rptsub = New KV2_HoaDonTaiXuat_Sub
            'End If
            'rpt.Subreports(0).SetDataSource(SubTable)

            'For p_Count = 0 To rpt.Parameters.Count - 1
            '    rpt.Parameters.Item(p_Count).Visible = False
            'Next
            rptsub.DataSource = SubTable
            rpt.XrSubreport1.ReportSource = rptsub

            srt_dt = Format(dtNgayXuat.EditValue, "dd/MM/yyyy").ToString
            srt_dieudong = Format(dtNgayXuat.EditValue, "dd/MM/yyyy").ToString

            rpt.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)

            rpt.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
            rpt.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
            rpt.Parameters.Item("P_Nam").Value = srt_dieudong.Substring(6, 4)

            'rpt.Parameters.Item("P_NguoiBan").Value = txtDonViGiaoHang.Text
            'rpt.Parameters.Item("P_DiaChi_BH").Value = txtDiaChiDonViGiaoHang.Text
            'rpt.Parameters.Item("P_MST_BH").Value = txtMST1.Text
            rpt.Parameters.Item("P_DonViMua").Value = txtDonViNhanHang.Text
            rpt.Parameters.Item("P_DiaChi_MH").Value = txtDiaChiDonViNhanHang.Text
            rpt.Parameters.Item("P_MaSoThue_MH").Value = txtMST2.Text  ' "MST(Tax code): " & txtMST2.Text
            rpt.Parameters.Item("P_SoTaiKhoan_BH").Value = txtSoTaiKhoan1.Text
            rpt.Parameters.Item("P_SoTaiKhoan_MH").Value = txtSoTaiKhoan2.Text
            rpt.Parameters.Item("p_SoHopDong").Value = txtSoHopDong.Text
            rpt.Parameters.Item("P_NgayHopDong").Value = txtNgayHopDong.Text.Replace("/", ".")

            'rpt.Parameters.Item("P_TongCong").Value = Format(TongTien, "n0").Replace(",", ".") ' Format(TongTien, "n0").Replace(").Value = ").Value =  ".")
            rpt.Parameters.Item("P_TongCong").Value = Format(TongTien, "n2").Replace(".", "@")
            rpt.Parameters.Item("P_TongCong").Value = rpt.Parameters.Item("P_TongCong").Value.Replace(",", ".")
            rpt.Parameters.Item("P_TongCong").Value = rpt.Parameters.Item("P_TongCong").Value.Replace("@", ",")
            rpt.Parameters.Item("p_TongThanhToan").Value = rpt.Parameters.Item("P_TongCong").Value + rpt.Parameters.Item("p_TienThue").Value
            'rpt.Parameters.Item("P_TongBangChu").Value = mdlFunction.Number2Text(CLng(TongTien)) & " Đô la Mỹ chẵn" & " (" & mdlFunction.Number2Text_EN(CLng(TongTien)) & ")"
            'rpt.Parameters.Item("P_TongBangChu").Value = mdlFunction.Number2Text_EN(CLng(TongTien))
            rpt.Parameters.Item("P_TongBangChu").Value = mdlFunction.Number2Text_EN(TongTien)


            'anhqh  20180525 sua theo yeu cau
            ' rpt.Parameters.Item("P_NgayVanDon").Value = srt_dt.Replace("/", ".")
            rpt.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
            rpt.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
            rpt.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            rpt.Parameters.Item("P_DonViCungCapVanTai").Value = txtDonViCCVanTai.Text
            rpt.Parameters.Item("p_MaTimKiem").Value = DtTable.Rows(0).Item("MaTimKiem").ToString
            rpt.Parameters.Item("P_DiemGiaoHang").Value = txtDiemGiaoHang.Text
            rpt.Parameters.Item("P_DiemNhanHang").Value = txtDiemNhanHang.Text
            rpt.Parameters.Item("P_PhuongThucTT").Value = txtPhuongThuc.Text
            rpt.Parameters.Item("P_ThoiHanThanhToan").Value = txtThoiHanThanhToan.Text
            rpt.Parameters.Item("P_TyGia").Value = txtTygia.Text
            rpt.Parameters.Item("P_TKHQ").Value = txtToKhaiHQ.Text
            rpt.Parameters.Item("P_STK").Value = txtSoTK.Text


            If DtTable.Rows(0).Item("MaTimKiem") = "V144" Then
                rpt.Parameters.Item("p_PXK").Value = txtSoPXK.Text
                rpt.Parameters.Item("p_MaTimKiem").Value = ""
            Else
                rpt.Parameters.Item("p_PXK").Value = "According to PXK no. " + txtSoPXK.Text
            End If

            'rpt.Parameters.Item("p_PXK").Value = "According to PXK no. " + txtSoPXK.Text
            Try
                If txtNgayPXK.EditValue.ToString.Trim <> "" Then
                    rpt.Parameters.Item("p_PXK").Value = rpt.Parameters.Item("p_PXK").Value + " - " + Format(txtNgayPXK.EditValue, "ddMMyyyy").ToString
                End If
            Catch ex As Exception

            End Try
            '

            'Dim times As Date = Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
            'rpt.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd.MM.yyyy}", times)  'String.Format("{0:dd.MM.yyyy}").Value =  times)
            'rpt.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString
            Dim times As Date = Get_ThoiGianDau(W_SoLenh) ' DtTable.Rows(0).Item("NgayXuat").ToString
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

            If U_CheckBox1.Checked Then
                rpt.PrinterName = g_DefaultPrint
                rpt.Print()
            Else
                rpt.ShowPreviewDialog()
            End If

            Update_TTHoaDon()

        Catch ex As Exception
            ShowMessageBox("", ex.Message)
        End Try

    End Sub


    Sub HoaDonGTGT_VN()
        If Me.Check_Control_Required = False Then
            Exit Sub
        End If

        Dim DtTable As New DataTable
        Dim DtTable1 As New DataTable
        Dim DtTable2 As New DataTable
        Dim SubTable As New DataTable
        Dim srt_dt As String = String.Empty
        Dim srt_hhh As String = String.Empty
        Dim srt_dieudong As String = String.Empty
        Dim dtSet As DataSet
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim DecimalPlace As Integer
        'Dim frmView As New frmPrint
        Try

            p_SQL = "exec sp_Reports_HoaDonTaiXuatE5 '" & W_SoLenh & "'"
            'dtSet = Provider.GetDataSetProcedure("sp_Reports_HoaDonE5").Value =  New SqlParameter("@SoLenh").Value =  W_SoLenh))
            dtSet = GetDataSet(p_SQL, p_SQL)
            DtTable = dtSet.Tables(0)
            DtTable1 = dtSet.Tables(1)
            ' DtTable2 = dtSet.Tables(2)

            'DtTable = W_DSET.Tables(0)
            ' DtTable1 = W_DSET.Tables(1)
            'FES ANNV 10/11 sua in hoa don tai xuat
            'DtTable2 = W_DSET.Tables(2)

            'rpt.PrintOptions.PrinterName = _DefaultPrint
            SubTable = Alter_Sub_Table(DtTable, DtTable1)

            
            Dim rpt As New KV2_HoaDonTaiXuat_VN
            Dim rptsub As New KV2_HoaDonTaiXuat_Sub_VN

            'If GTGT_EN = True Then
            '    rpt = New KV2_HoaDonTaiXuat_EN
            '    rptsub = New KV2_HoaDonTaiXuat_Sub
            'Else
            '    rpt = New KV2_HoaDonTaiXuat
            '    rptsub = New KV2_HoaDonTaiXuat_Sub
            'End If
            'rpt.Subreports(0).SetDataSource(SubTable)

            'For p_Count = 0 To rpt.Parameters.Count - 1
            '    rpt.Parameters.Item(p_Count).Visible = False
            'Next
            rptsub.DataSource = SubTable
            rpt.XrSubreport1.ReportSource = rptsub

            srt_dt = Format(dtNgayXuat.EditValue, "dd/MM/yyyy").ToString
            srt_dieudong = Format(dtNgayXuat.EditValue, "dd/MM/yyyy").ToString

            rpt.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)

            rpt.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
            rpt.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
            rpt.Parameters.Item("P_Nam").Value = srt_dieudong.Substring(6, 4)

            'rpt.Parameters.Item("P_NguoiBan").Value = txtDonViGiaoHang.Text
            'rpt.Parameters.Item("P_DiaChi_BH").Value = txtDiaChiDonViGiaoHang.Text
            'rpt.Parameters.Item("P_MST_BH").Value = txtMST1.Text
            rpt.Parameters.Item("P_DonViMua").Value = txtDonViNhanHang.Text
            rpt.Parameters.Item("P_DiaChi_MH").Value = txtDiaChiDonViNhanHang.Text
            rpt.Parameters.Item("P_MaSoThue_MH").Value = txtMST2.Text  ' "MST(Tax code): " & txtMST2.Text
            rpt.Parameters.Item("P_SoTaiKhoan_BH").Value = txtSoTaiKhoan1.Text
            rpt.Parameters.Item("P_SoTaiKhoan_MH").Value = txtSoTaiKhoan2.Text
            rpt.Parameters.Item("p_SoHopDong").Value = txtSoHopDong.Text
            rpt.Parameters.Item("P_NgayHopDong").Value = txtNgayHopDong.Text.Replace("/", ".")

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


            'rpt.Parameters.Item("P_NgayVanDon").Value = srt_dt.Replace("/", ".")
            rpt.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
            rpt.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
            rpt.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            rpt.Parameters.Item("P_DonViCungCapVanTai").Value = txtDonViCCVanTai.Text
            If DtTable.Rows(0).Item("MaTimKiem").ToString = "V144" Then
                rpt.Parameters.Item("p_MaTimKiem").Value = ""
            Else
                rpt.Parameters.Item("p_MaTimKiem").Value = DtTable.Rows(0).Item("MaTimKiem").ToString
            End If

            rpt.Parameters.Item("P_DiemGiaoHang").Value = txtDiemGiaoHang.Text
            rpt.Parameters.Item("P_DiemNhanHang").Value = txtDiemNhanHang.Text
            rpt.Parameters.Item("P_PhuongThucTT").Value = txtPhuongThuc.Text
            rpt.Parameters.Item("P_ThoiHanThanhToan").Value = txtThoiHanThanhToan.Text
            rpt.Parameters.Item("P_TyGia").Value = txtTygia.Text
            rpt.Parameters.Item("P_TKHQ").Value = txtToKhaiHQ.Text
            rpt.Parameters.Item("P_STK").Value = txtSoTK.Text

            rpt.Parameters.Item("p_PXK").Value = txtSoPXK.Text
            Try
                If txtNgayPXK.EditValue.ToString.Trim <> "" Then
                    rpt.Parameters.Item("p_PXK").Value = rpt.Parameters.Item("p_PXK").Value + " - " + Format(txtNgayPXK.EditValue, "ddMMyyyy").ToString
                End If
            Catch ex As Exception

            End Try
           


            'Dim times As Date = Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
            'rpt.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd.MM.yyyy}", times)  
            'rpt.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString
            Dim times As Date = Get_ThoiGianDau(W_SoLenh)   'DtTable.Rows(0).Item("NgayXuat").ToString
            rpt.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd.MM.yyyy}", times)           
            rpt.Parameters.Item("P_GioXuatHang").Value = times.Hour.ToString + ":" + times.Minute.ToString + ":" + times.Second.ToString


            rpt.XrLabel37.Text = ""
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

            If U_CheckBox1.Checked Then
                rpt.PrinterName = g_DefaultPrint
                rpt.Print()
            Else
                rpt.ShowPreviewDialog()
            End If

            Update_TTHoaDon()

        Catch ex As Exception
            ShowMessageBox("", ex.Message)
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
                    "," & CDbl("0") & "" & _
                    "," & p_DataRow.Item(5).ToString.Trim & "" & _
                        ",'" & txtPhuongThuc.Text & "'" & _
                    ",'" & W_SoLenh.ToString.Trim & "'" & _
                     "," & p_DataRow.Item(5).ToString.Trim
                If SQL_Execute(p_SQL, p_SQL) = False Then
                    ShowMessageBox("", p_SQL)
                    Exit Sub
                End If
            Next
            p_SQL = " exec KhachHangUpdateAddress '" & p_DataTable.Rows(0).Item(3).ToString.Trim & "',N'" & txtDiaChiDonViNhanHang.EditValue.ToString & "'"
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
        'Dim l_thanhtien As Int64
        Dim l_thanhtien As Decimal
        'Dim l_dongia As Int64
        Dim l_dongia As Decimal
        Dim l_quantity As Decimal()
        Dim p_DataRow As DataRow
        Dim p_STT As Integer


        'Dim l_ds_sub11 As New RpSub


        l_dongia = 0
        TongTien = 0
        l_thanhtien = 0

        Try
            SubTable = l_ds_sub.Tables(1).Clone()
            Dim index As Integer = 0
            Try
                SubTable.Columns.Add("STT", GetType(Integer))
            Catch ex As Exception

            End Try
            l_mavanchuyen = dtTable0.Rows(0)("MaVanChuyen").ToString()
            l_thuybo = mdlDelivery_CheckTransmot(l_mavanchuyen, g_dt_para)


            SubTable.Columns.Remove("TongDuXuat")
            SubTable.Columns.Add("TongDuXuat")


            For Each r As DataRow In dtTable.Rows
                dtRow = SubTable.NewRow
                p_STT += 1
                dtRow("STT") = p_STT
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
                'l_dongia = CDec(dgvProduct.Rows(index).Cells(4).Value.ToString())
                'l_thanhtien = l_dongia * SoLuong

                'dtRow("DonGia") = Format(l_dongia, "n0").Replace(",", ".")
                'dtRow("ThanhTien") = Format(l_thanhtien, "n0").Replace(",", ".")
                'dtRow("Bottom") = ND_VCF(l_quantity(0), r.Item("MaHangHoa").ToString, r.Item("DonViTinh").ToString, index)
                'SubTable.Rows.Add(dtRow)
                'TongTien += l_thanhtien
                'index += 1

                dtRow("TongDuXuat") = Format(SoLuong, "n0").Replace(",", ".")
                p_DataRow = Me.GridView1.GetDataRow(index)
                l_dongia = CDec(IIf(p_DataRow(4).ToString.Trim = "", 0, p_DataRow(4).ToString())).ToString("N6")
                'l_thanhtien = Math.Round(l_dongia * SoLuong, 0)
                '  l_dongia = Math.Round(l_dongia, 2)
                l_thanhtien = Math.Round(l_dongia * SoLuong, 2)

                'dtRow("DonGia") = Format(l_dongia, "n0").Replace(",", ".")
                'dtRow("ThanhTien") = Format(l_thanhtien, "n0").Replace(",", ".")
                dtRow("DonGia") = Format(l_dongia, "n6").Replace(".", "@")
                dtRow("DonGia") = dtRow("DonGia").Replace(",", ".")
                dtRow("DonGia") = dtRow("DonGia").Replace("@", ",")
                dtRow("ThanhTien") = Format(l_thanhtien, "n2").Replace(".", "@")
                dtRow("ThanhTien") = dtRow("ThanhTien").Replace(",", ".")
                dtRow("ThanhTien") = dtRow("ThanhTien").Replace("@", ",")
                dtRow("Bottom") = ND_VCF(l_quantity(0), r.Item("MaHangHoa").ToString, r.Item("DonViTinh").ToString, index, l_mavanchuyen)
                SubTable.Rows.Add(dtRow)
                W_ChietKhau += CInt(p_DataRow(5).ToString().Trim())

                'W_ThueGTGT += Math.Round((((l_thanhtien - CDbl(dgvProduct.Rows(index).Cells(5).Value.ToString().Trim())) * CInt(txtThueGTGT.Text.Trim()) / 100)), 0)
                TongTien += l_thanhtien
                index += 1


            Next
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
            Decimal.TryParse(W_dt_HoaDonCT.Rows(i).Item("TổngXuất").ToString(), l_soluong)
            Decimal.TryParse(W_dt_HoaDonCT.Rows(i).Item("Nhiệtđộ").ToString(), l_nhietdo)
            Decimal.TryParse(W_dt_HoaDonCT.Rows(i).Item("TỷTrọng").ToString(), l_tytrong)

            l_vcf = mdlQCI_GetVCF_NS(l_nhietdo, l_tytrong)
            l_wcf = mdlQCI_GetWCF(l_tytrong)

            l_quantity = mdlQCI_CalculateQCI_NS(l_soluong, "L", l_nhietdo, l_tytrong) 'l_quantity = mdlQCI_CalculateQCI(l_soluong, "L", l_vcf) 'hieptd4 edit 20161204
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

    Private Function ND_VCF(ByVal LTT As String, ByVal productID As String, ByVal unitID As String, ByVal dgvRow As Integer, Optional p_MaVanChuyen As String = "ZT") As String

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


            Dim p_SQL As String
            Dim p_Table As DataTable
            p_SQL = "select dbo.FPT_LaySoThucXuat ('" & p_MaVanChuyen & "'," & p_DataRow.Item("TổngXuất").ToString() & "," & p_DataRow.Item("TổngDựXuất").ToString() & ",0) as ThucXuat "
            p_Table = GetDataTable(p_SQL, p_SQL)
            TX = "0"
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    TX = p_Table.Rows(0).Item("ThucXuat").ToString.Trim
                End If
            End If



            '  ND = Format(CInt(ND), "n2").ToString 'hieptd4 add
            'If ND.Contains(".") Then
            '    ND = ND.Replace(".", ",")
            'End If

            If ND.Contains(".") Then
                If Len(Mid(ND, InStr(ND, ".") + 1, Len(ND) - InStr(ND, "."))) <= 1 Then
                    ND = ND.Replace(".", ",") & "0"
                Else
                    ND = ND.Replace(".", ",")
                End If

            Else
                ND = ND + ",00"
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

            Select Case unitID.ToUpper
                Case "L"



                    'End Select
                    ' If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
                    Hed = "Nhiệt độ TT/KG/D15/VCF/WCF/L15: " '+ vbCrLf

                    Full = Hed + ND + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF + " / " + L15

                    'Hed = "L15/Kg/to/D15/VCF/WCF: " + vbCrLf
                    'Full = Hed + L15 + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    'ElseIf InStr(g_HOADON2, productID.ToUpper, CompareMethod.Text) > 0 Then
                    '    Hed = "Nhiệt độ TT/KG/D15/VCF/WCF: " '+ vbCrLf
                    '    'Hed = "Kg/to/D15/VCF/WCF: " + vbCrLf

                    '    KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
                    '    Full = Hed + ND + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
                    '    'Full = Hed + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    'End If
                Case "L15"

                    If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
                        Hed = "Nhiệt độ TT/LTT/KG/D15/VCF/WCF: " '+ vbCrLf

                        If TX = "0" Then
                            If p_TongDuXuat = "0" Or p_TongDuXuat = "" Then
                                TX = p_DataRow.Item("TổngXuất").ToString()
                            Else
                                TX = p_DataRow.Item("TổngDựXuất").ToString()
                            End If
                        End If
                        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add


                        Full = Hed + ND + " / " + TX + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
                        'Full = Hed + TX + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF
                    End If
                Case "KG"


                    '    If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
                    '  Hed = "Nhiệt độ TT/LTT/L15/D15/VCF/WCF: " '+ vbCrLf
                    Hed = "LTT/L15/to/VCF/WCF/D15: " + vbCrLf

                    ' TX = p_DataRow.Item("TổngXuất").ToString()
                    If TX = "0" Then
                        If p_TongDuXuat = "0" Or p_TongDuXuat = "" Then
                            TX = p_DataRow.Item("TổngXuất").ToString()
                        Else
                            TX = p_DataRow.Item("TổngDựXuất").ToString()
                        End If
                    End If
                    TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add

                    'Full = Hed + ND + " / " + TX + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF
                    Full = Hed + TX + " / " + L15 + " / " + ND + " / " + VCF + " / " + WCF + " / " + D15

                    'ElseIf InStr(g_HOADON2, productID.ToUpper, CompareMethod.Text) > 0 Then
                    'Hed = "Nhiệt độ TT/LTT/D15/VCF/WCF: " '+ vbCrLf
                    ''Hed = "LTT/to/D15/VCF/WCF: " + vbCrLf

                    'TX = p_DataRow.Item("TổngXuất").ToString()
                    'TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add

                    'Full = Hed + ND + " / " + TX + " / " + D15 + " / " + VCF + " / " + WCF
                    ''Full = Hed + TX + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    'End If

            End Select

            Return Full
        Catch ex As Exception
            ShowStatusMessage(True, "", ex.Message, 5)
            Return Nothing
        End Try
    End Function

End Class