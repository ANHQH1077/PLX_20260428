
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

    Private p_CIF As Boolean = False

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
            Dim p_Tax As Integer = 0
            Dim p_Data As DataTable

            Dim p_Where As String
            Dim p_NCCVanTai As String = ""

            p_Where = Me.GridView1.Where & " and LoaiChungTu ='" & p_LoaiChungTu & "'"
            'p_LoaiChungTu
            Me.GridView1.Where = p_Where

            p_SQL = "select VatCancel from  sys_User  where upper(User_name) =upper('" & g_UserName & "') and isnull(VatCancel,'') ='Y'"
            p_Data = GetDataTable(p_SQL, p_SQL)
            If Not p_Data Is Nothing Then
                If p_Data.Rows.Count > 0 Then
                    Me.ToolStripButton2.Visible = True
                    Me.ToolStripButton4.Visible = True
                End If
            End If

            W_dt_HoaDonCT = Get_HoaDon_ChiTietNew(W_SoLenh)
            Dim p_Binding As New U_TextBox.U_BindingSource

            p_datetime = Get_ThoiGianDau(W_SoLenh)
            Dim p_ColNumber As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

            Me.txtPXK.TabStop = False
            Me.txtPXK.TabIndex = 1000


            W_dt_HoaDonTT = W_ttHoaDon.Select_LenhXuatKho_BySoLenh(Err, W_SoLenh).Tables(0)
            'Me.TrueDBGrid1.DataSource = p_Binding
            'Me.TrueDBGrid1.Refresh()
            'Me.GridView1.RefreshData()
            'GridView1.OptionsBehavior.ReadOnly = True
            If W_dt_HoaDonTT.Rows.Count > 0 Then
                txtSoHoaDon.Text = W_dt_HoaDonTT.Rows(0)(7).ToString() 'hieptd4 edit 20161206
            End If

            txtSoDO.Text = W_SoLenh 'hieptd4 add 20161206

            'p_Binding.DataSource = W_dt_HoaDonCT


            Provider = GetDataSet("exec sp_Reports_HoaDonE5 '" & W_SoLenh & "'", p_SQL)
            txtDonViMuaHang.Text = Provider.Tables(0).Rows(0).Item(4).ToString()
            txtDiChiDonViMuaHang.Text = Provider.Tables(0).Rows(0).Item(5).ToString()
            txtMaSoThue.Text = Provider.Tables(0).Rows(0).Item(6).ToString()
            Integer.TryParse(Provider.Tables(0).Rows(0).Item("Tax").ToString(), p_Tax)


            p_NCCVanTai = Provider.Tables(0).Rows(0).Item("DonViCungCapVanTai").ToString()


            If Provider.Tables(0).Rows(0).Item("ChuyenVanChuyen").ToString().Trim = "Y" Then
                Me.txtPXK.Required = "Y"
                p_CIF = True
            Else
                Me.txtPXK.Required = "N"
                p_CIF = False
            End If
            'p_GetCurrentDate(p_datetime)
            If Me.dtNgayXuat.Text = "" Then
                Me.dtNgayXuat.EditValue = p_datetime 'Now.Date 'hieptd4 edit 20161206
            End If

            Me.dtBillingDate.EditValue = p_datetime.Date

            If Provider.Tables(0).Rows(0).Item("NgayHoaDon").ToString().Trim <> "" Then
                Me.dtNgayHoaDon.EditValue = CDate(Provider.Tables(0).Rows(0).Item("NgayHoaDon"))

            End If

            If Provider.Tables(0).Rows(0).Item("NgayHoaDon").ToString().Trim <> "" Then
                Me.txtNgayPXK.EditValue = CDate(Provider.Tables(0).Rows(0).Item("NgayHoaDon"))

            End If
            ' Me.dtNgayHoaDon.EditValue = p_datetime  ' W_DSET.Tables(0).Rows(0).Item("NgayXuat")



            'end hieptd4 add 20161206

            txtDonViBanHang.Text = Provider.Tables(0).Rows(0).Item("TenDonVi").ToString()
            txtDiaChiDonViBanHang.Text = Provider.Tables(0).Rows(0).Item("DiaChiDH").ToString()
            txtMaSoThueDonViBanHang.Text = Provider.Tables(0).Rows(0).Item("MaSoThueDH").ToString()

            Get_Data_Default()

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
            Me.DefaultFormLoad = False

            If Me.dtNgayXuat.Text = "" Then
                Me.dtNgayXuat.EditValue = p_datetime 'Now.Date 'hieptd4 edit 20161206
            End If
            'hieptd4 add 20161206
            If Me.dtBillingDate.Text = "" Then
                Me.dtBillingDate.EditValue = p_datetime
            End If
            If Me.dtNgayHoaDon.Text = "" Then
                If Provider.Tables(0).Rows(0).Item("NgayHoaDon").ToString().Trim <> "" Then
                    Me.dtNgayHoaDon.EditValue = CDate(Provider.Tables(0).Rows(0).Item("NgayHoaDon"))

                End If
            End If


            If Me.txtNgayPXK.Text = "" Then
                If Provider.Tables(0).Rows(0).Item("NgayHoaDon").ToString().Trim <> "" Then
                    Me.txtNgayPXK.EditValue = CDate(Provider.Tables(0).Rows(0).Item("NgayHoaDon"))

                End If
            End If


            p_SQL = ""
            If Not Me.SoLenh.EditValue Is Nothing Then
                p_SQL = Me.SoLenh.EditValue.ToString.Trim
            End If

            If p_SQL = "" Then
                Me.SoLenh.EditValue = p_SoLenh
            End If

            If Me.txtThueGTGT.Text = "" Or Me.txtThueGTGT.Text = "0" Then
                Me.txtThueGTGT.EditValue = p_Tax
            End If
            If Me.txtDonViCCVanTai.Text = "" Then
                txtDonViCCVanTai.Text = p_NCCVanTai
            End If
            'p_NCCVanTai

            p_SQL = ""
            If Not Me.MaTraCuu.EditValue Is Nothing Then
                p_SQL = Me.MaTraCuu.EditValue.ToString.Trim
            End If
            If p_SQL <> "" Then
                Me.FormEdit = False
                Me.GridView1.OptionsBehavior.ReadOnly = True
            End If

            ' Dim p_CIF As Boolean = False
            p_CIF = False
            p_SQL = "select 1 from tblLenhXuatE5  with (nolock) where SoLenh ='" & W_SoLenh & "' and Inco1='CIF' and MaNguon ='N30'"
            p_Data = GetDataTable(p_SQL, p_SQL)
            If Not p_Data Is Nothing Then
                If p_Data.Rows.Count > 0 Then
                    p_CIF = True
                End If
            End If

            If p_CIF = False Then
                Me.GridView1.Columns.Item("SoGhiNhan").VisibleIndex = -1
                Me.GridView1.Columns.Item("NhietDo").OptionsColumn.ReadOnly = True
                Me.GridView1.Columns.Item("NhietDo").OptionsColumn.ReadOnly = True
            Else
                Me.GridView1.Columns.Item("NhietDo").OptionsColumn.ReadOnly = False
                Me.GridView1.Columns.Item("NhietDo").OptionsColumn.ReadOnly = False
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

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


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
                    "," & IIf(txtThueGTGT.Text.ToString.Trim = "", 0, txtThueGTGT.Text) & "" & _
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


    Private Function ND_VCF(ByVal LTT As String, ByVal productID As String, ByVal unitID As String, ByVal dgvRow As Integer, Optional ByVal p_MaVanChuyen As String = "ZT") As String

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

        Dim p_SQL As String
        Dim p_Table As DataTable



        Try
            p_TongDuXuat = "0"
            p_ArrRow = g_SySConfig.Select("KEYCODE='TONGDUXUAT'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    p_TongDuXuat = p_ArrRow(0).Item("KEYVALUE").ToString.Trim
                End If
            End If


            p_DataRow = Me.GridView1.GetDataRow(dgvRow)
            ND = CDbl(p_DataRow.Item("NhiệtĐộ").ToString())


            p_SQL = "select dbo.FPT_LaySoThucXuat ('" & p_MaVanChuyen & "'," & p_DataRow.Item("TổngXuất").ToString() & "," & p_DataRow.Item("TổngDựXuất").ToString() & ",0) as ThucXuat "
            p_Table = GetDataTable(p_SQL, p_SQL)
            TX = "0"
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    TX = p_Table.Rows(0).Item("ThucXuat").ToString.Trim
                End If
            End If
            ' ND = Format(CInt(ND), "n2").ToString 'hieptd4 add

            'ND = Format(CInt(ND), "n2").ToString

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

            'FES
            '20141027
            Select Case unitID.ToUpper
                Case "L"

                    Hed = "Nhiệt độ TT/KG/L15/D15/VCF/WCF: " '+ vbCrLf

                    Full = Hed + ND + " / " + KG + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF


                Case "L15"

                    If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
                        Hed = "Nhiệt độ TT/KG/LTT/D15/VCF/WCF: " '+ vbCrLf

                        If TX = "0" Then
                            If p_TongDuXuat = "0" Or p_TongDuXuat = "" Then
                                TX = p_DataRow.Item("TổngXuất").ToString()
                            Else
                                TX = p_DataRow.Item("TổngDựXuất").ToString()
                            End If
                        End If

                        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add


                        Full = Hed + ND + " / " + KG + " / " + TX + " / " + D15 + " / " + VCF + " / " + WCF
                    End If


                Case "KG"

                    ' If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
                    Hed = "Nhiệt độ TT/LTT/L15/D15/VCF/WCF: " '+ vbCrLf
                    'Hed = "LTT/L15/to/D15/VCF/WCF: " + vbCrLf

                    ' TX = p_DataRow.Item("TổngXuất").ToString()
                    If TX = "0" Then
                        If p_TongDuXuat = "0" Or p_TongDuXuat = "" Then
                            TX = p_DataRow.Item("TổngXuất").ToString()
                        Else
                            TX = p_DataRow.Item("TổngDựXuất").ToString()
                        End If
                    End If
                    TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add

                    Full = Hed + ND + " / " + TX + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF

            End Select

            Return Full
        Catch ex As Exception
            ShowStatusMessage(True, "", ex.Message, 5)
            Return Nothing
        End Try
    End Function

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If Me.FormStatus = True Then
            LuuData()
        End If

        HoaDon(False)

    End Sub

    Private Sub HoaDon(ByVal p_XemHoaDon As Boolean)
        Dim p_SQL As String
        Dim p_SoLenh As String = ""
        Dim p_Matracuu As String = ""
        Dim p_Error As Boolean = False
        Dim p_SoHoaDon As String = ""
        Dim p_Table As DataTable
        If Not Me.txtSoDO.EditValue Is Nothing Then
            p_SoLenh = Me.txtSoDO.EditValue.ToString.Trim
        End If
        ' TaoMaTraCuu(g_UserName, p_SoLenh, p_Matracuu)
        p_SQL = ""
        If Not Me.txtThueGTGT.EditValue Is Nothing Then
            p_SQL = Me.txtThueGTGT.EditValue.ToString.Trim
        End If
        If p_SQL = "" Then
            ShowMessageBox("", "Thuế GTGT chưa nhập")
            Exit Sub
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
            ' Else

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

                If Not Me.txtSoDO.EditValue Is Nothing Then
                    p_SoLenh = Me.txtSoDO.EditValue.ToString.Trim
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

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        LuuData()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        'If Me.FormStatus = True Then
        '    LuuData()
        'End If

        Dim p_SoLenh As String = ""
        Dim p_Error As Boolean = False
        Dim p_StringError As String = ""
        If Not Me.TxtSoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.TxtSoLenh.EditValue.ToString.Trim
        End If
        If p_SoLenh = "" Then
            Exit Sub
        End If

        If MsgBox("Bạn có chắc chắn muốn thực hiện không", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Chú ý") = MsgBoxResult.No Then
            Exit Sub
        End If

        XoaChungTu(p_LoaiChungTu, p_SoLenh, p_Error, p_StringError)
        If p_StringError <> "" Then
            If p_Error = False Then
                ShowMessageBox("", p_StringError, 1)
                Me.Close()
            Else
                ShowMessageBox("", p_StringError)
            End If
        End If



    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_ShownEditor(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.ShownEditor

    End Sub

    Private Sub GridView1_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor

        Dim p_Row As DataRow
        Dim p_DonGia As Double = 0
        Dim p_SoLuong As Double = 0
        Dim p_ThanHTien As Double = 0
        Dim p_SoLuongNhan As Double = 0
        Dim p_NhietDo, p_TyTrong As Double
        Dim p_DonViTinh As String = "L"
        Dim p_SQL As String = ""
        Dim p_HangHoa As String = ""
        Dim p_ChietKhau As Double = 0

        If UCase(Me.GridView1.FocusedColumn.FieldName.ToString.Trim) = UCase("DonGia") Then

            p_Row = Me.GridView1.GetDataRow(Me.GridView1.FocusedRowHandle)
            If Not p_Row Is Nothing Then
                Double.TryParse(e.Value.ToString.Trim, p_DonGia)
                Double.TryParse(p_Row.Item("SoLuong").ToString.Trim, p_SoLuong)
                Double.TryParse(p_Row.Item("ChietKhau").ToString.Trim, p_ChietKhau)
                p_ChietKhau = p_ChietKhau / 100
                p_ThanHTien = p_SoLuong * (p_DonGia - (p_DonGia * p_ChietKhau))
                p_Row.Item("TongTIen") = p_ThanHTien
                p_Row.Item("CHECKUPD") = "Y"
            End If
            Exit Sub
        End If
        If UCase(Me.GridView1.FocusedColumn.FieldName.ToString.Trim) = UCase("SoGhiNhan") Or UCase(Me.GridView1.FocusedColumn.FieldName.ToString.Trim) = UCase("NhietDo") _
                Or UCase(Me.GridView1.FocusedColumn.FieldName.ToString.Trim) = UCase("TyTrong") Then
            p_Row = Me.GridView1.GetFocusedDataRow


            '   p_SoLuong = 0
            If Not p_Row Is Nothing Then
                Select Case UCase(Me.GridView1.FocusedColumn.FieldName.ToString.Trim)
                    Case UCase("TyTrong")

                        Double.TryParse(e.Value.ToString.Trim, p_TyTrong)
                        Double.TryParse(p_Row.Item("NhietDo").ToString.Trim, p_NhietDo)
                        Double.TryParse(p_Row.Item("SoGhiNhan").ToString.Trim, p_SoLuongNhan)
                        p_DonViTinh = p_Row.Item("DonViTinh").ToString.Trim
                        p_HangHoa = p_Row.Item("MaHangHoa").ToString.Trim

                    Case UCase("SoGhiNhan")
                        Double.TryParse(e.Value.ToString.Trim, p_SoLuongNhan)
                        Double.TryParse(p_Row.Item("NhietDo").ToString.Trim, p_NhietDo)
                        Double.TryParse(p_Row.Item("TyTrong").ToString.Trim, p_TyTrong)
                        p_DonViTinh = p_Row.Item("DonViTinh").ToString.Trim
                        p_HangHoa = p_Row.Item("MaHangHoa").ToString.Trim
                    Case UCase("NhietDo")

                        Double.TryParse(e.Value.ToString.Trim, p_NhietDo)
                        Double.TryParse(p_Row.Item("SoGhiNhan").ToString.Trim, p_SoLuongNhan)
                        Double.TryParse(p_Row.Item("TyTrong").ToString.Trim, p_TyTrong)
                        p_DonViTinh = p_Row.Item("DonViTinh").ToString.Trim
                        p_HangHoa = p_Row.Item("MaHangHoa").ToString.Trim

                End Select

                SetQCI(p_HangHoa, p_DonViTinh, p_SoLuongNhan, p_NhietDo, p_TyTrong, p_Row)

            End If


            Exit Sub
        End If
    End Sub

    Private Sub SetQCI(ByVal p_HangHoa As String, ByVal p_DonViTinh As String, ByVal p_SoLuong As Double, _
                       ByVal p_NhietDo As Double, ByVal p_TyTrong As Double, ByRef p_data As DataRow)
        Dim p_SQL As String = ""
        Dim p_VCF, p_WCF, p_L15, p_Ltt, p_KG, p_DonGia, p_ThanhTien As Double
        Dim p_DataTable As DataTable
        Dim p_SoLuongHD As Double = 0
        'If UCase(p_DonViTinh) = "L" Then
        p_SQL = "select  dbo.zzFPT_mdlQCI_GetVCF_NS('" & p_NhietDo & "', '" & p_TyTrong & "')  as VCF "
        ' "exec [dbo].[zzFPT_mdlQCI_CalculateQCI_NS_QC] " & p_SoLuong & ",'L'," & p_NhietDo & "," & p_TyTrong & ",'" & p_HangHoa & "',null"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        p_VCF = 0
        p_WCF = 0
        p_L15 = 0
        p_Ltt = 0
        p_KG = 0

        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Double.TryParse(p_DataTable.Rows(0).Item(0).ToString.Trim, p_VCF)
                If p_VCF > 0 Then
                    p_WCF = p_TyTrong - 0.0011
                    Select Case UCase(p_DonViTinh)
                        Case "L"
                            p_Ltt = p_SoLuong
                            p_L15 = p_Ltt * p_VCF
                            p_KG = p_L15 * p_WCF

                        Case "L15"
                            p_L15 = p_SoLuong
                            p_KG = p_L15 * p_WCF
                            p_Ltt = p_L15 / p_VCF
                        Case "KG"
                            p_KG = p_SoLuong
                            p_L15 = p_KG / p_WCF
                            p_Ltt = p_L15 / p_VCF
                    End Select
                    p_SQL = "select dbo.FPT_ROUNDNUMBER (" & p_L15 & ",0) as L15,  dbo.FPT_ROUNDNUMBER (" & p_KG & ",0) AS KG,  dbo.FPT_ROUNDNUMBER (" & p_Ltt & ",0) AS LTT"
                    p_DataTable = GetDataTable(p_SQL, p_SQL)
                    If Not p_DataTable Is Nothing Then
                        If p_DataTable.Rows.Count > 0 Then
                            Double.TryParse(p_DataTable.Rows(0).Item("L15").ToString.ToString, p_L15)
                            Double.TryParse(p_DataTable.Rows(0).Item("KG").ToString.ToString, p_KG)
                            Double.TryParse(p_DataTable.Rows(0).Item("LTT").ToString.ToString, p_Ltt)
                        End If
                    End If
                    Select Case UCase(p_DonViTinh)
                        Case "L"
                            p_SoLuongHD = p_Ltt
                        Case "L15"
                            p_SoLuongHD = p_L15
                        Case "KG"
                            p_SoLuongHD = p_KG
                    End Select
                    p_data.Item("KG") = p_KG
                    p_data.Item("L15") = p_L15
                    p_data.Item("SoLuong") = p_SoLuongHD
                    Double.TryParse(p_data.Item("DonGia").ToString.Trim, p_DonGia)
                    p_ThanhTien = p_SoLuongHD * p_DonGia
                    p_data.Item("TongTIen") = p_ThanHTien
                    p_data.Item("CHECKUPD") = "Y"

                End If
            End If
        End If
        'Else

        'End If

    End Sub

    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_SoLenh As String = ""
        Dim p_MaTraCuu As String = ""
        If Not Me.txtSoDO.EditValue Is Nothing Then
            p_SoLenh = Me.txtSoDO.EditValue.ToString.Trim

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

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        HoaDon(True)


    End Sub

    Private Sub dtNgayHoaDon_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtNgayHoaDon.EditValueChanged

    End Sub
End Class