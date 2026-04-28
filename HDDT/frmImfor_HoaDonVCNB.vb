Public Class frmImfor_HoaDonVCNB
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
    Private Provider_TK As DataTable

    Private p_LoaiChungTu As String = "GTGT_VCNB"
    Private p_SoLenh As String = ""
    Private Sub frmImfor_HoaDonVCNB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        Dim p_Date As Date
        '  Dim p_Dataset As DataSet
        Dim p_Time As Integer
        Dim p_Binding As New U_TextBox.U_BindingSource
        ' p_GetDateTime(p_Date, p_Time)
        Dim p_txtCompany As String
        Dim p_Dataset As New DataSet

        Dim p_Data As DataTable


        Dim p_Where As String

        p_Where = Me.GridView2.Where & " and LoaiChungTu ='" & p_LoaiChungTu & "'"
        'p_LoaiChungTu
        Me.GridView2.Where = p_Where



        'p_SQL = "select top 1 * from tblLenhXUate5 with (nolock) where SoLenh='662AA00872'  and " & _
        '                "(( isnull(BSART,'')   in  ('P222','P250') and isnull(HTTG,'N') ='Y') or  (LXPhieu='DICHUYEN' and isnull(LXLOAI,'')='TD') ); " & _
        '                "select top 1 * from tblLenhXUate5 with (nolock) where SoLenh='662AA00872'  and  " & _
        '                "(( isnull(BSART,'')   in  ('P223') and isnull(HTTG,'N') ='N' ) or  (LXPhieu='DICHUYEN' and isnull(LXLOAI,'') <> 'TD') );"
        'p_SQL = "select top 1 * from tblLenhXUate5 with (nolock) where SoLenh='" & p_SoLenh & "'  and  " & _
        '               "(( isnull(BSART,'')   in  ('P223') and isnull(HTTG,'N') ='N' ) or  (LXPhieu='DICHUYEN' and isnull(LXLOAI,'') <> 'TD') );"

        'p_Data = GetDataTable(p_SQL, p_SQL)
        'If Not p_Data Is Nothing Then

        '    If p_Data.Rows.Count > 0 Then
        '        TxtXKKVCNB.Required = "N"
        '    End If

        'End If
        p_SQL = "select VatCancel from  sys_User  where upper(User_name) =upper('" & g_UserName & "') and isnull(VatCancel,'') ='Y'"
        p_Data = GetDataTable(p_SQL, p_SQL)
        If Not p_Data Is Nothing Then
            If p_Data.Rows.Count > 0 Then
                Me.ToolStripButton2.Visible = True
                Me.ToolStripButton5.Visible = True
            End If
        End If

        '  CreateFieldForm(Me)
        Dim p_txtDonViGiaoHang, p_txtDiaChiDonViGiaoHang As String
        Me.txtSoLenh.Text = W_SoLenh
        W_dt_HoaDonCT = Get_HoaDon_ChiTietNew(W_SoLenh)


        p_Date = Get_ThoiGianDau(W_SoLenh)

        W_dt_HoaDonTT = W_ttHoaDon.Select_LenhXuatKho_BySoLenh(Err, W_SoLenh).Tables(0)


        p_Dataset = GetDataSet("exec InforHoaDonVCNB", p_SQL)
        Provider = p_Dataset.Tables(0) '= GetDataTable("exec InforHoaDonVCNB", p_SQL)
        Provider_TK = p_Dataset.Tables(1) '

        txtCompany.Text = Provider.Rows(0).Item(0).ToString()
        p_txtCompany = Provider.Rows(0).Item(0).ToString()


        p_txtDonViGiaoHang = Provider.Rows(0).Item(0).ToString()
        p_txtDiaChiDonViGiaoHang = Provider.Rows(0).Item("DiaChiFull").ToString()



        W_DSET = GetDataSet("exec sp_Reports_HoaDonVCNBNew '" & W_SoLenh & "'", p_SQL)
        'p_Binding.DataSource = W_dt_HoaDonCT
        'Me.TrueDBGrid1.DataSource = p_Binding
        'Me.TrueDBGrid1.Refresh()
        'Me.GridView1.RefreshData()
        'GridView1.OptionsBehavior.ReadOnly = True

        If W_DSET.Tables(0).Rows(0).Item("ChuyenVanChuyen").ToString() <> "Y" Then
            p_txtCompany = p_txtCompany  'Provider.Rows(0).Item(0).ToString()
        End If



        'If W_DSET.Tables(0).Rows(0).Item("ChuyenVanChuyen").ToString() = "Y" Then
        p_txtDonViGiaoHang = p_txtDonViGiaoHang
        ' End If

        If txtDiemGiaoHang.Text = "" Then
            txtDiemGiaoHang.EditValue = W_DSET.Tables(0).Rows(0).Item("DiemtraHang").ToString() 'hieptd4 add 20161102
        End If
        If txtDonViCungCapVanTai.Text = "" Then
            txtDonViCungCapVanTai.EditValue = W_DSET.Tables(0).Rows(0).Item("DonViCungCapVanTai").ToString() 'hieptd4 add 20161102
        End If


       
        'hieptd4 add 20161102

        ' W_DSET = Provider.GetDataSetProcedure("sp_Reports_HoaDonE5", New SqlParameter("@SoLenh", txtSoLenh.Text))


        '  Me.dtNgayXuat.EditValue = p_Date
        ' Me.dtpDieuDong.EditValue = p_Date

        ' p_Date = Get_ThoiGianDau(Me.txtSoLenh.Text)

        'Me.dtNgayXuat.EditValue = p_Date

        Dim p_Table As DataTable
        Dim p_KeyCode As String = ""
        If Not Me.KeyCode.EditValue Is Nothing Then
            p_KeyCode = Me.KeyCode.EditValue.ToString.Trim
        End If

        p_SQL = " Exec  [sp_Reports_TaoHoaDonDienTu]  '" & p_SoLenh & "', '" & g_UserName & "','" & p_KeyCode & "', '" & p_LoaiChungTu & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)

        p_SQL = " Where SoLenh='" & p_SoLenh & "' and LoaiChungTu='" & p_LoaiChungTu & "'"
        Me.DefaultWhere = p_SQL

        Me.DefaultFormLoad = True
        Me.XtraForm1_Load()


        p_SQL = W_DSET.Tables(0).Rows(0).Item(3).ToString()
        p_SQL = "exec KhachHangGetByID '" & p_SQL & "'"
        Provider = GetDataTable(p_SQL, p_SQL)
        'If Provider.Rows.Count > 0 Then
        '    txtDonViNhanHang.Text = Provider.Rows(0).Item(1).ToString()
        '    txtDiaChiDonViNhanHang.Text = Provider.Rows(0).Item(2).ToString()

        'End If

        'If Me.dtNgayXuat.Text = "" Then
        Me.dtNgayXuat.EditValue = CDate(W_DSET.Tables(0).Rows(0).Item("NgayHoaDon")) ' p_Date 'Now.Date 'hieptd4 edit 20161206
        ' End If
        ' Me.dtNgayXuat.EditValue = p_Date
        If Me.dtpDieuDong.EditValue Is Nothing Then
            If W_DSET.Tables(0).Rows(0).Item("NgayHieuLuc").ToString.Trim <> "" Then
                Me.dtpDieuDong.EditValue = CDate(W_DSET.Tables(0).Rows(0).Item("NgayHieuLuc"))
            End If

        End If

        If Me.txtKhoNhap.Text = "" Then
            'KhoNhapVCNB
            txtKhoNhap.EditValue = W_DSET.Tables(0).Rows(0).Item("KhoNhapVCNB").ToString()
        End If


        txtDonViGiaoHang.Text = W_DSET.Tables(0).Rows(0).Item("DonViGiaoHang").ToString()  'p_txtDonViGiaoHang ' Provider.Rows(0).Item(0).ToString()
        txtDiaChiDonViGiaoHang.Text = W_DSET.Tables(0).Rows(0).Item("DonViGiaoHangDiaChi").ToString() 'p_txtDiaChiDonViGiaoHang ' Provider.Rows(0).Item("DiaChiFull").ToString()

        If txtDiemGiaoHang.Text = "" Then
            txtDiemGiaoHang.EditValue = W_DSET.Tables(0).Rows(0).Item("DiemtraHang").ToString() 'hieptd4 add 20161102
        End If
        If txtDonViCungCapVanTai.Text = "" Then
            txtDonViCungCapVanTai.EditValue = W_DSET.Tables(0).Rows(0).Item("DonViCungCapVanTai").ToString() 'hieptd4 add 20161102
        End If
        If txtDonViNhanHang.Text = "" Then
            txtDonViNhanHang.Text = W_DSET.Tables(0).Rows(0).Item("DonViNhanHang").ToString()
        End If

        If txtDiaChiDonViNhanHang.Text = "" Then
            txtDiaChiDonViNhanHang.Text = W_DSET.Tables(0).Rows(0).Item("DonViNhanHangDiaChi").ToString()
        End If




        'txtDiemGiaoHang.EditValue = W_DSET.Tables(0).Rows(0).Item(19).ToString() 'hieptd4 add 20161102
        'txtDonViCungCapVanTai.EditValue = W_DSET.Tables(0).Rows(0).Item(18).ToString() 'hieptd4 add 20161102
        ' txtKhoNhap.EditValue = W_DSET.Tables(0).Rows(0).Item(20).ToString() 'hieptd4 add 20161102

        Me.DefaultFormLoad = False
        p_SQL = ""
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SQL = Me.SoLenh.EditValue.ToString.Trim
        End If

        If p_SQL = "" Then
            Me.SoLenh.EditValue = p_SoLenh
        End If

        txtCompany.Text = W_DSET.Tables(0).Rows(0).Item("DonViDieuDong").ToString()   'p_txtCompany

        p_SQL = ""
        If Not Me.MaTraCuu.EditValue Is Nothing Then
            p_SQL = Me.MaTraCuu.EditValue.ToString.Trim
        End If
        If p_SQL <> "" Then
            Me.FormEdit = False
            Me.GridView2.OptionsBehavior.ReadOnly = True
        End If

        ' GridView1.BestFitColumns()


    End Sub

    'Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
    '    Dim DtTable As New DataTable
    '    Dim DtTable1 As New DataTable
    '    Dim DtTable2 As New DataTable
    '    Dim SubTable As New DataTable
    '    Dim srt_dt As String = String.Empty
    '    Dim srt_hhh As String = String.Empty
    '    Dim srt_dieudong As String = String.Empty
    '    Dim p_Count As Integer
    '    Dim p_RpHoaDonVCNB As New KV2_HoaDonVCNB_New
    '    Dim p_RpHoaDonVCNB_Sub As New KV2_HoaDonVCNB_SubNew
    '    Dim p_Date As DateTime
    '    Dim p_Row As DataRow

    '    p_GetCurrentDate(p_Date)

    '    'Dim frmView As New frmPrint
    '    Try

    '        If Me.Check_Control_Required = False Then
    '            Exit Sub
    '        End If


    '        If Me.FormStatus = True Then



    '            Me.DefaultSave = True
    '            Me.LoaiChungTu.EditValue = p_LoaiChungTu

    '            Me.UpdateToDatabase(Me, Nothing)

    '            Me.DefaultSave = False
    '        End If


    '        DtTable = W_DSET.Tables(0)
    '        DtTable1 = W_DSET.Tables(1)
    '        DtTable2 = W_DSET.Tables(2)

    '        'rpt.PrintOptions.PrinterName = _DefaultPrint
    '        SubTable = Alter_Sub_Table(DtTable, DtTable1)

    '        '  Dim rpt As New rptHoaDonVCNB

    '        For p_Count2 = 0 To SubTable.Rows.Count - 1
    '            SubTable.Rows(p_Count2).Item("STT") = p_Count2 + 1


    '        Next
    '        For p_Count2 = 2 * SubTable.Rows.Count To 6
    '            p_Row = SubTable.NewRow
    '            SubTable.Rows.Add(p_Row)
    '        Next


    '        p_RpHoaDonVCNB_Sub.DataSource = SubTable
    '        p_RpHoaDonVCNB.XrSubreport1.ReportSource = p_RpHoaDonVCNB_Sub
    '        ' rpt.SetDataSource(SubTable)
    '        srt_dt = Format(dtNgayXuat.EditValue, "dd/MM/yyyy").ToString
    '        srt_dieudong = Format(dtpDieuDong.EditValue, "dd/MM/yyyy").ToString
    '        p_RpHoaDonVCNB.Parameters.Item("P_Ngay").Value = srt_dt.Substring(0, 2)
    '        p_RpHoaDonVCNB.Parameters.Item("P_Thang").Value = srt_dt.Substring(3, 2)
    '        p_RpHoaDonVCNB.Parameters.Item("P_Nam").Value = srt_dieudong.Substring(6, 4)

    '        p_RpHoaDonVCNB.Parameters.Item("P_NgayDieuDong").Value = srt_dieudong.Substring(0, 2)
    '        p_RpHoaDonVCNB.Parameters.Item("P_ThangDieuDong").Value = srt_dieudong.Substring(3, 2)
    '        p_RpHoaDonVCNB.Parameters.Item("P_NamDieuDong").Value = srt_dieudong.Substring(6, 4)

    '        'rpt.SetParameterValue("P_Nam", srt_dt.Substring(8, 2))

    '        p_RpHoaDonVCNB.Parameters.Item("P_SoLenh").Value = txtSoLenh.Text.Trim()
    '        p_RpHoaDonVCNB.Parameters.Item("P_CuaDonVi").Value = txtCompany.Text
    '        p_RpHoaDonVCNB.Parameters.Item("P_DonViGiaoHang").Value = txtDonViGiaoHang.Text
    '        p_RpHoaDonVCNB.Parameters.Item("P_DonViGiaoHangDiaChi").Value = txtDiaChiDonViGiaoHang.Text
    '        p_RpHoaDonVCNB.Parameters.Item("P_DonViMua").Value = txtDonViNhanHang.Text
    '        p_RpHoaDonVCNB.Parameters.Item("P_DiaChi_MH").Value = txtDiaChiDonViNhanHang.Text
    '        'rpt.SetParameterValue("P_DonViMua", DtTable.Rows(0).Item("TenKhachHang").ToString)
    '        'rpt.SetParameterValue("P_DiaChi_MH", DtTable.Rows(0).Item("DiaChi").ToString)

    '        p_RpHoaDonVCNB.Parameters.Item("P_SoPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
    '        'rpt.SetParameterValue("P_MaTienKiem", DtTable.Rows(0).Item("SoLenh").ToString)
    '        p_RpHoaDonVCNB.Parameters.Item("P_MaTimKiem").Value = DtTable.Rows(0).Item("MaTimKiem").ToString
    '        p_RpHoaDonVCNB.Parameters.Item("P_KhoXuat").Value = DtTable.Rows(0).Item("MaKho").ToString
    '        p_RpHoaDonVCNB.Parameters.Item("P_NguoiVanTai").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString
    '        p_RpHoaDonVCNB.Parameters.Item("P_SoNiem").Value = DtTable.Rows(0).Item("Niem").ToString
    '        p_RpHoaDonVCNB.Parameters.Item("P_DiemGiaoHang").Value = txtDiemGiaoHang.Text
    '        p_RpHoaDonVCNB.Parameters.Item("P_KhoNhap").Value = txtKhoNhap.Text
    '        p_RpHoaDonVCNB.Parameters.Item("P_DonViCCVanTai").Value = txtDonViCungCapVanTai.Text

    '        For Each r As DataRow In DtTable2.Rows
    '            'srt_hhh += "N" + r.Item("HHH").ToString + ";"
    '            srt_hhh += "H" + r.Item("HHH").ToString + ";"
    '        Next

    '        p_RpHoaDonVCNB.Parameters.Item("P_KhoangCachTamMuc").Value = srt_hhh

    '        Dim times As Date = Get_ThoiGianDau(W_SoLenh) ' p_Date   ' Convert.ToDateTime(DtTable.Rows(0).Item("NgayXuat").ToString)
    '        p_RpHoaDonVCNB.Parameters.Item("P_NgayGiaoDich").Value = String.Format("{0:dd.MM.yyyy}", times)
    '        p_RpHoaDonVCNB.Parameters.Item("P_GioXuatHang").Value = Format(times, "HH:mm:ss") '  String.Format("{0}:{1}:{2}", times.Hour.ToString, times.Minute.ToString, times.Second)
    '        p_RpHoaDonVCNB.Parameters.Item("P_NgayGiaoDich").Value = p_RpHoaDonVCNB.Parameters.Item("P_NgayGiaoDich").Value & "/" & p_RpHoaDonVCNB.Parameters.Item("P_GioXuatHang").Value
    '        'Update Dữ liệu vào bảng tblThongTinHoaDon
    '        For p_Count = 0 To p_RpHoaDonVCNB.Parameters.Count - 1
    '            p_RpHoaDonVCNB.Parameters(p_Count).Visible = False
    '        Next
    '        '----------------------
    '        If chkCheck.Checked Then
    '            p_RpHoaDonVCNB.PrinterName = g_DefaultPrint
    '            p_RpHoaDonVCNB.Print()

    '        Else
    '            p_RpHoaDonVCNB.ShowPreviewDialog()
    '        End If

    '        Update_TTHoaDon()

    '    Catch ex As Exception
    '        ShowStatusMessage(True, "", ex.Message, 5)
    '    End Try
    'End Sub



    'Private Sub Update_TTHoaDon()
    '    ' Check_in()
    '    Dim p_SQL As String
    '    Dim p_DataRow As DataRow
    '    Try

    '        For index As Integer = 0 To Me.GridView1.RowCount - 1
    '            p_DataRow = Me.GridView1.GetDataRow(index)
    '            p_SQL = "exec ThongTinHoaDonTransaction " & _
    '                "'" & Me.txtSoLenh.Text.ToString.Trim & "'" & _
    '                ",'" & p_DataRow.Item(0).ToString.Trim & "'" & _
    '                ",'" & CDate(dtNgayXuat.Text).ToString("yyyyMMdd") & "'" & _
    '                ",0" & _
    '                ",0" & _
    '                ",0" & _
    '                    ",''" & _
    '                ",'" & Me.txtSoLenh.Text & "'" & _
    '                 "," & p_DataRow.Item(5).ToString.Trim
    '            If SQL_Execute(p_SQL, p_SQL) = False Then
    '                ShowMessageBox("", p_SQL)
    '                Exit Sub
    '            End If
    '        Next

    '        p_SQL = " exec DonViUpdateAddress N'" & txtDiaChiDonViGiaoHang.Text & "'"
    '        If SQL_Execute(p_SQL, p_SQL) = False Then
    '            ShowMessageBox("", p_SQL)
    '            Exit Sub
    '        End If

    '        'Dim sqlPara() As SqlParameter = New SqlParameter(1) {}
    '        'sqlPara(0) = New SqlParameter("@MaKhachHang", Provider.DSet.Tables(0).Rows(0).Item(3).ToString())
    '        'sqlPara(1) = New SqlParameter("@DiaChiFull", txtDiaChiDonViNhanHang.Text)
    '        'Provider.ExecuteSqlQuery("KhachHangUpdateAddress", sqlPara)


    '        p_SQL = " exec KhachHangUpdateAddress '" & Provider.Rows(0).Item(3).ToString.Trim & "',N'" & txtDiaChiDonViNhanHang.Text & "'"
    '        If SQL_Execute(p_SQL, p_SQL) = False Then
    '            ShowMessageBox("", p_SQL)
    '            Exit Sub
    '        End If
    '    Catch ex As Exception
    '        ShowStatusMessage(True, "", ex.Message, 5)
    '    End Try
    'End Sub

    'Private Function Alter_Sub_Table(ByVal dtTable0 As DataTable, ByVal dtTable As DataTable) As DataTable
    '    Dim l_mavanchuyen As String
    '    Dim l_thuybo As String

    '    Dim SoLuong As Int64 = 0
    '    Dim SubTable As DataTable
    '    Dim dtRow As DataRow
    '    Dim l_ds_sub As New RpSub()
    '    Dim l_quantity As Decimal()

    '    TongTien = 0
    '    Try
    '        SubTable = l_ds_sub.Tables(1).Clone()

    '        SubTable.Columns.Remove("TongDuXuat")
    '        SubTable.Columns.Add("TongDuXuat")

    '        Dim index As Integer = 0

    '        l_mavanchuyen = dtTable0.Rows(0)("MaVanChuyen").ToString()
    '        l_thuybo = mdlDelivery_CheckTransmot(l_mavanchuyen, g_dt_para)

    '        If dtTable.Rows.Count > 0 Then
    '            For Each r As DataRow In dtTable.Rows
    '                dtRow = SubTable.NewRow
    '                dtRow("MaHangHoa") = r.Item("MaHangHoa").ToString
    '                dtRow("TenHangHoa") = r.Item("TenHangHoa").ToString
    '                dtRow("DonViTinh") = r.Item("DonViTinh").ToString

    '                If l_thuybo.ToUpper() = "THUY" Then
    '                    l_quantity = Calculate_1(r.Item("LineID").ToString())
    '                Else
    '                    l_quantity = Calculate_1(r.Item("LineID").ToString())
    '                End If

    '                Select Case r.Item("DonViTinh").ToString().ToUpper()
    '                    Case "L"
    '                        SoLuong = l_quantity(0)
    '                    Case "L15"
    '                        SoLuong = l_quantity(1)
    '                    Case "M15"
    '                        SoLuong = l_quantity(2)
    '                    Case "KG"
    '                        SoLuong = l_quantity(3)
    '                    Case Else
    '                        SoLuong = l_quantity(0)
    '                End Select

    '                ' dtRow("TongDuXuat") = SoLuong
    '                dtRow("TongDuXuat") = Format(SoLuong, "n0").Replace(",", ".")

    '                dtRow("Bottom") = ND_VCF(l_quantity(0).ToString(), r.Item("MaHangHoa").ToString, r.Item("DonViTinh").ToString, index, l_mavanchuyen)
    '                '20170809
    '                'anhqh

    '                'dtRow("Bottom") = ND_VCF_New(Me.GridView1, l_quantity(0).ToString(), r.Item("MaHangHoa").ToString, r.Item("DonViTinh").ToString, index)
    '                SubTable.Rows.Add(dtRow)
    '                index += 1
    '            Next
    '        End If

    '    Catch ex As Exception
    '        Return Nothing
    '    End Try
    '    Return SubTable
    'End Function


    'Private Function ND_VCF(ByVal LTT As String, ByVal productID As String, ByVal unitID As String, ByVal dgvRow As Integer, Optional p_MaVanChuyen As String = "ZT") As String
    '    '01/02/2013 QUEHV - Sua cac trinh tu thong tin theo don vi ban va hang hoa
    '    Dim Hed As String = String.Empty
    '    Dim ND As String = "" 'String.Empty
    '    Dim TX As String = String.Empty
    '    Dim D15 As String = String.Empty
    '    Dim VCF As String = String.Empty
    '    Dim L15 As String = String.Empty
    '    Dim KG As String = String.Empty
    '    Dim WCF As String = String.Empty
    '    Dim Full As String = String.Empty
    '    Dim p_TongDuXuat As String
    '    Dim p_ArrRow() As DataRow
    '    Dim p_DataRow As DataRow

    '    Try
    '        p_TongDuXuat = "0"
    '        p_ArrRow = g_SySConfig.Select("KEYCODE='TONGDUXUAT'")
    '        If p_ArrRow.Length > 0 Then
    '            If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
    '                p_TongDuXuat = p_ArrRow(0).Item("KEYVALUE").ToString.Trim
    '            End If
    '        End If

    '        p_DataRow = GridView1.GetDataRow(dgvRow)
    '        ' ND = "0"
    '        ND = p_DataRow.Item("NhiệtĐộ").ToString()

    '        Dim p_SQL As String
    '        Dim p_Table As DataTable
    '        p_SQL = "select dbo.FPT_LaySoThucXuat ('" & p_MaVanChuyen & "'," & p_DataRow.Item("TổngXuất").ToString() & "," & p_DataRow.Item("TổngDựXuất").ToString() & ",0) as ThucXuat "
    '        p_Table = GetDataTable(p_SQL, p_SQL)
    '        TX = "0"
    '        If Not p_Table Is Nothing Then
    '            If p_Table.Rows.Count > 0 Then
    '                TX = p_Table.Rows(0).Item("ThucXuat").ToString.Trim
    '            End If
    '        End If

    '        If ND.Contains(".") Then
    '            If Len(Mid(ND, InStr(ND, ".") + 1, Len(ND) - InStr(ND, "."))) <= 1 Then
    '                ND = ND.Replace(".", ",") & "0"
    '            Else
    '                ND = ND.Replace(".", ",")
    '            End If

    '        Else
    '            ND = ND + ",00"
    '        End If
    '        Dim _D15 As Double = IIf(IsDBNull(p_DataRow.Item("TỷTrọng").ToString()), 0, p_DataRow.Item("TỷTrọng").ToString())
    '        D15 = Format(_D15, "0.0000").ToString
    '        If D15.Contains(".") Then
    '            D15 = D15.Replace(".", ",")
    '        End If

    '        Dim _VCF As Double = p_DataRow.Item("VCF").ToString()


    '        VCF = Format(_VCF, "0.0000").ToString
    '        If VCF.Contains(".") Then
    '            VCF = VCF.Replace(".", ",")
    '        End If

    '        Dim _WCF As Double = p_DataRow.Item("WCF").ToString()
    '        WCF = Format(_WCF, "0.0000").ToString
    '        If WCF.Contains(".") Then
    '            WCF = WCF.Replace(".", ",")
    '        End If

    '        KG = CInt(p_DataRow.Item("KG").ToString()) '.Replace(",", ".")
    '        L15 = CInt(p_DataRow.Item("L15").ToString()) '.Replace(",", ".")

    '        KG = Format(CInt(KG.ToString()), "n0").Replace(",", ".")

    '        L15 = Format(CInt(L15.ToString()), "n0").Replace(",", ".")

    '        'KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0") '.Replace(",", ".")
    '        'L15 = Format(CInt(p_DataRow.Item("L15").ToString()), "n0") '.Replace(",", ".")
    '        'FES
    '        '20141027
    '        'Select Case unitID.ToUpper
    '        '    Case "L"
    '        '        Select Case productID.ToUpper
    '        '            Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
    '        '                'Hed = "Nhiệt độ TT/KG/L15/D15/VCF/WCF: "

    '        '                'Full = Hed + ND + " / " + KG + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF

    '        '                Hed = "L15/Kg/to/D15/VCF/WCF  " '+ vbCrLf
    '        '                Full = Hed + L15 + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

    '        '            Case "0701001", "0701002", "0701003"
    '        '                'Hed = "Nhiệt độ TT/KG/D15/VCF/WCF: "
    '        '                Hed = "Kg/to/D15/VCF/WCF  " '+ vbCrLf

    '        '                KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
    '        '                'Full = Hed + ND + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
    '        '                Full = Hed + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

    '        '        End Select
    '        '    Case "L15"
    '        '        Select Case productID.ToUpper
    '        '            Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
    '        '                'Hed = "Nhiệt độ TT/LTT/KG/D15/VCF/WCF: "
    '        '                Hed = "LTT/Kg/to/D15/VCF/WCF  " '+ vbCrLf

    '        '                'p_TongDuXuat
    '        '                'If g_dtPara.Rows(16).Item("Value_nd").ToString().Trim() = "1" Then
    '        '                '    TX = dgvProduct.Rows(dgvRow).Cells("TổngXuất").Value.ToString()
    '        '                'Else
    '        '                '    TX = dgvProduct.Rows(dgvRow).Cells("TổngDựXuất").Value.ToString()
    '        '                'End If
    '        '                If p_TongDuXuat = "0" Or p_TongDuXuat = "" Then
    '        '                    TX = p_DataRow.Item("TổngXuất").ToString()
    '        '                Else
    '        '                    TX = p_DataRow.Item("TổngDựXuất").ToString()
    '        '                End If

    '        '                'Full = Hed + ND + " / " + TX + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
    '        '                Full = Hed + TX + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF
    '        '        End Select
    '        '    Case "KG"
    '        '        Select Case productID.ToUpper
    '        '            Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
    '        '                'Hed = "Nhiệt độ TT/LTT/L15/D15/VCF/WCF: "
    '        '                Hed = "LTT/L15/to/D15/VCF/WCF  " '+ vbCrLf

    '        '                TX = p_DataRow.Item("TổngXuất").ToString()

    '        '                'Full = Hed + ND + " / " + TX + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF
    '        '                Full = Hed + TX + " / " + L15 + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

    '        '            Case "0701001", "0701002", "0701003"
    '        '                'Hed = "Nhiệt độ TT/LTT/D15/VCF/WCF: "
    '        '                Hed = "LTT/to/D15/VCF/WCF  " '+ vbCrLf

    '        '                TX = p_DataRow.Item("TổngXuất").ToString()

    '        '                'Full = Hed + ND + " / " + TX + " / " + D15 + " / " + VCF + " / " + WCF
    '        '                Full = Hed + TX + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

    '        '        End Select
    '        'End Select


    '        Select Case unitID.ToUpper
    '            Case "L"

    '                'End Select
    '                ' If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
    '                'Hed = "Nhiệt độ TT/KG/L15/D15/VCF/WCF: " '+ vbCrLf

    '                'Full = Hed + ND + " / " + KG + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF

    '                Hed = "L15/Kg/to/D15/VCF/WCF: "
    '                Full = Hed + L15 + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

    '                'ElseIf InStr(g_HOADON2, productID.ToUpper, CompareMethod.Text) > 0 Then
    '                '    'Hed = "Nhiệt độ TT/KG/D15/VCF/WCF: " '+ vbCrLf
    '                '    'KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
    '                '    'Full = Hed + ND + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
    '                '    'anhqh
    '                '    '20170809
    '                '    'sắp xếp lại theo yêu cầu
    '                '    'L15 /KG/t0/D15/VCF/WCF
    '                '    Hed = "L15 /KG/t0/D15/VCF/WCF: " '+ vbCrLf
    '                '    'KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
    '                '    Full = Hed + L15 + "/" + KG + "/" + ND + " / " + D15 + " / " + VCF + " / " + WCF

    '                '    'Full = Hed + ND + " / " + L15 + "/" + KG + "/" + ND + " / " + D15 + " / " + VCF + " / " + WCF



    '                'End If
    '            Case "L15"

    '                If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then

    '                    Hed = "Ltt/Kg/t0/D15/VCF/WCF: "

    '                    'Hed = "Nhiệt độ TT/LTT/KG/D15/VCF/WCF: " '+ vbCrLf

    '                    If TX = "0" Then
    '                        If p_TongDuXuat = "0" Or p_TongDuXuat = "" Then
    '                            TX = p_DataRow.Item("TổngXuất").ToString()
    '                        Else
    '                            TX = p_DataRow.Item("TổngDựXuất").ToString()
    '                        End If
    '                    End If
    '                    TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add


    '                    Full = Hed + TX + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF
    '                    'Full = Hed + TX + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF
    '                End If
    '            Case "KG"


    '                'If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
    '                ' Hed = "Nhiệt độ TT/LTT/L15/D15/VCF/WCF: " '+ vbCrLf
    '                Hed = "LTT/L15/to/D15/VCF/WCF: "

    '                'TX = p_DataRow.Item("TổngXuất").ToString()
    '                If TX = "0" Then
    '                    If p_TongDuXuat = "0" Or p_TongDuXuat = "" Then
    '                        TX = p_DataRow.Item("TổngXuất").ToString()
    '                    Else
    '                        TX = p_DataRow.Item("TổngDựXuất").ToString()
    '                    End If
    '                End If
    '                TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add

    '                'Full = Hed + ND + " / " + TX + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF
    '                Full = Hed + TX + " / " + L15 + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

    '                'ElseIf InStr(g_HOADON2, productID.ToUpper, CompareMethod.Text) > 0 Then
    '                '    'Hed = "Nhiệt độ TT/LTT/D15/VCF/WCF: " '+ vbCrLf

    '                '    TX = p_DataRow.Item("TổngXuất").ToString()
    '                '    TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add

    '                '    'Full = Hed + ND + " / " + TX + " / " + D15 + " / " + VCF + " / " + WCF

    '                '    'anhqh
    '                '    '20170809
    '                '    'sắp xếp lại theo yêu cầu
    '                '    ' LTT/L15/t0/D15/VCF/WCF
    '                '    Hed = "LTT/L15/t0/D15/VCF/WCF: " '+ vbCrLf
    '                '    KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
    '                '    'Full = Hed + ND + " / " + L15 + "/" + KG + "/" + ND + " / " + D15 + " / " + VCF + " / " + WCF
    '                '    Full = Hed + TX + " / " + L15 + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

    '                'End If

    '        End Select


    '        Return Full
    '    Catch ex As Exception
    '        'ShowStatusMessage(True, "", ex.Message, 5)
    '        Return Nothing
    '    End Try
    'End Function

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


    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        LuuData()
    End Sub


    Private Sub LuuData()

        Dim p_SQL As String

        Dim p_Date As DateTime


        Dim p_KeyCode As String = ""
        p_GetCurrentDate(p_Date)
        Dim p_Table As DataTable
        ' Dim p_SQL As String
        Dim p_SoLenh As String = ""
        Try
            If Me.Check_Control_Required = False Then
                Exit Sub
            End If


            If Me.FormStatus = True Then
                If Not Me.KeyCode.EditValue Is Nothing Then
                    p_KeyCode = Me.KeyCode.EditValue.ToString.Trim
                End If

                If Not Me.txtSoLenh.EditValue Is Nothing Then
                    p_SoLenh = Me.txtSoLenh.EditValue.ToString.Trim
                End If
                If p_SoLenh = "" Then
                    ShowMessageBox("", "Số Lệnh xuất không xác định")
                    Exit Sub
                End If
                If p_KeyCode = "" Then
                    p_SQL = " exec  TaoChuoiKeyCode '" & p_SoLenh & "','" & g_UserName & "'"
                    p_Table = GetDataTable(p_SQL, p_SQL)
                    If Not p_Table Is Nothing Then
                        If p_Table.Rows.Count > 0 Then
                            p_KeyCode = p_Table.Rows(0).Item(0).ToString.Trim
                            Me.KeyCode.EditValue = p_KeyCode
                        End If
                    End If
                End If
                Me.DefaultSave = True
                Me.LoaiChungTu.EditValue = p_LoaiChungTu

                Me.UpdateToDatabase(Me, Nothing)

                Me.DefaultSave = False
            End If


            '------------------------------------------------------------
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ShowMessageBox("", ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_SoLenh As String = ""
        Dim p_MaTraCuu As String = ""
        If Not Me.txtSoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.txtSoLenh.EditValue.ToString.Trim

        End If
        If p_SoLenh = "" Then

            ShowMessageBox("", "Số lệnh không xác định")
            Exit Sub
        End If
        If Not Me.MaTraCuu.EditValue Is Nothing Then
            p_MaTraCuu = Me.MaTraCuu.EditValue.ToString.Trim
        End If
        If p_MaTraCuu = "" Then
            ShowMessageBox("", "Mã tra cứu không xác định")
            Exit Sub
        End If
        Dim p_ShowForm As New FrmNoiDungHuy
        p_ShowForm.g_MaTarCuu = p_MaTraCuu
        p_ShowForm.g_SoLenh = p_SoLenh
        p_ShowForm.g_LoaiChungTu = p_LoaiChungTu

        p_ShowForm.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        p_ShowForm.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim

        ' p_ShowForm.p_XtraToolTripLabel = g_ToolStripStatus

        ' p_ShowForm.p_XtraMessageStatusl = g_MessageStatus


        p_ShowForm.G_Error = False
        p_ShowForm.ShowDialog(Me)
        If p_ShowForm.G_Error = True Then

        Else
            Me.DefaultFormLoad = True
            Me.LoadDataToForm()
            ShowMessageBox("", "Đã thực hiện xong", 1)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If Me.FormStatus = True Then
            LuuData()
        End If

        HoaDon(False)
        Exit Sub


        Dim p_SQL As String
        Dim p_SoLenh As String = ""
        Dim p_Matracuu As String = ""
        Dim p_Error As Boolean = False

        Dim p_Table As DataTable

        If Not Me.txtSoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.txtSoLenh.EditValue.ToString.Trim
        End If

       
        If p_SoLenh <> "" Then
            p_SQL = "sp_Reports_HoaDonDienTu_KiemTra '" & p_SoLenh & "','" & p_LoaiChungTu & "'"
            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    ShowMessageBox("", p_Table.Rows(0).Item("sDesc").ToString.Trim)
                    If p_Table.Rows(0).Item("nError") > 0 Then
                        Exit Sub
                    End If
                End If
            End If
            TaoHoaDon(False, g_UserName, p_SoLenh, p_LoaiChungTu, p_Error)
            If p_Error = False Then

                Me.DefaultFormLoad = True
                Me.XtraForm1_Load()
                Me.DefaultFormLoad = False

            End If
        End If
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        
        Dim p_SoLenh As String = ""
        Dim p_Error As Boolean = False
        Dim p_StringError As String = ""
        If Not Me.txtSoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.txtSoLenh.EditValue.ToString.Trim
        End If
        If p_SoLenh = "" Then
            Exit Sub
        End If

        If MsgBox("Bạn có chắc chắn muốn thực hiện không", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Chú ý") = MsgBoxResult.No Then
            Exit Sub
        End If

        XoaChungTu(p_LoaiChungTu, p_SoLenh, p_Error, p_StringError)
        If p_StringError <> "" Then
            If p_Error = True Then
                ShowMessageBox("", p_StringError)

            Else
                ShowMessageBox("", p_StringError, 1)
                Me.Close()
            End If
        End If
       
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        HoaDon(True)
    End Sub



    Private Sub HoaDon(ByVal p_XemHoaDon As Boolean)
        Dim p_SQL As String
        Dim p_SoLenh As String = ""
        Dim p_Matracuu As String = ""
        Dim p_Error As Boolean = False

        Dim p_Table As DataTable
        If Not Me.txtSoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.txtSoLenh.EditValue.ToString.Trim
        End If
       

        If p_SoLenh <> "" Then
            If p_XemHoaDon = False Then
                p_SQL = "sp_Reports_HoaDonDienTu_KiemTra '" & p_SoLenh & "','" & p_LoaiChungTu & "'"
                p_Table = GetDataTable(p_SQL, p_SQL)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        ShowMessageBox("", p_Table.Rows(0).Item("sDesc").ToString.Trim)
                        If p_Table.Rows(0).Item("nError") > 0 Then
                            Exit Sub
                        End If
                    End If
                End If
            End If

            Dim p_SoHoaDon As String = ""
            If Not Me.MaTraCuu.EditValue Is Nothing Then
                p_Matracuu = Me.MaTraCuu.EditValue.ToString.Trim

            End If
            If Not Me.txtSoHoaDon.EditValue Is Nothing Then
                p_SoHoaDon = Me.txtSoHoaDon.EditValue.ToString.Trim
            End If
            If p_Matracuu <> "" And p_SoHoaDon <> "" Then
                HTTP_Open(p_Matracuu)
                Exit Sub
            End If


            TaoHoaDon(p_XemHoaDon, g_UserName, p_SoLenh, p_LoaiChungTu, p_Error)
            If p_XemHoaDon = False Then
                If p_Error = False Then
                    Me.DefaultFormLoad = True
                    Me.XtraForm1_Load()
                    Me.DefaultFormLoad = False

                End If
            End If

        End If

    End Sub
End Class