Public Class FrmXacNhanThucXuat
    Private p_SoLenh As String
    Private p_Header As DataTable
    Private p_Line As DataTable
    Private p_LineDetail As DataTable
    Private p_GridLine As New DataTable("p_GridLine")
    Public p_Status As Boolean
    Public g_mavanchuyen As String = ""

    Private g_solenh, _
        g_masothue, _
        g_madonvi, _
        g_ngaylap, _
        g_khachhang, _
        g_ngayhieuluc, _
        g_manguon, _
        g_nguoivanchuyen, _
        g_maphuongtien, _
        g_khoxuathang, _
        g_mabe, _
        g_macto, _
        g_gioxuathang, _
        g_phutxuathang, _
        g_ngayxuathang, _
        g_luongxuatthucte, _
        g_donvitinh, _
        g_vcf, _
         g_Wcf_E5, _
        g_luongquychuan, _
        g_Kg, _
        g_niemso _
        As String

    Private g_tytrong, _
        g_nhietdo, _
        g_nhietdo_cal, _
        g_soctodau, _
        g_soctocuoi As Decimal

    Private p_TONGDUXUAT As String = "0"
    Private p_TONGDUXUAT_Thuy As String = "0"
    Private p_SysConfig As DataTable
    Private p_L15_RESET As String = "N"

    ' Private g_MavanChuyen As String = ""

    Private Sub FrmXacNhanThucXuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        Dim p_DataSet As DataSet
        Dim p_DataRow() As DataRow
        p_XtraUserName = g_User_ID
        'p_SQL = "select * from FPT_tblLenhXuatE5_V where SoLenh='" & p_SoLenh & "';"
        ''p_SQL = p_SQL & "select * from FPT_LenhXuat_TongHop_v where solenh='" & p_SoLenh & "';"
        'p_SQL = p_SQL & " select LineID, BeXuat, TableID, MaHangHoa, TenHangHoa,DonViTinh, (select Sum(SoLuongDuXuat) " & _
        '     " from FPT_tbllenhxuatchitietE5_v where H_TableID=a.TableID) as  SoLuongDuXuat " & _
        '     ", (select Sum(SoLuongThucXuat) " & _
        '     " from FPT_tbllenhxuatchitietE5_v where H_TableID=a.TableID) as  SoLuongThucXuat " & _
        '     ",(select Sum(isnull(GST,0)) " & _
        '         "from FPT_tbllenhxuatchitietE5_v where H_TableID=a.TableID) as  TongLit15 " & _
        '        " from FPT_tblLenhXuat_HangHoaE5_V a where solenh='" & p_SoLenh & "';"
        'p_SQL = p_SQL & "select * from FPT_LenhXuat_TongHop_v where solenh='" & p_SoLenh & "';"


        p_SQL = "SELECT * FROM SYS_CONFIG"
        p_SysConfig = GetDataTable(p_SQL, p_SQL)
        'p_SQL = p_SQL & "select * from SYS_CONFIG;"
        p_DataRow = p_SysConfig.Select("KEYCODE='L15_RESET'")
        If p_DataRow.Length > 0 Then
            p_L15_RESET = p_DataRow(0).Item(1).ToString.Trim
        End If




        If p_L15_RESET = "Y" Then
            p_SQL = "exec FPT_XacNhanHoanThien_E5Reset '" & p_SoLenh & "'"
        Else
            p_SQL = "exec FPT_XacNhanHoanThien '" & p_SoLenh & "'"
        End If

        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            p_Header = p_DataSet.Tables(0)
            p_Line = p_DataSet.Tables(1)
            p_LineDetail = p_DataSet.Tables(2)
            ' p_SysConfig = p_DataSet.Tables(3)
            FillHeader()

            If p_L15_RESET = "Y" Then
                FillLine_E5_Reset()
            Else
                FillLine()
            End If

            p_DataRow = p_SysConfig.Select("KEYCODE='TONGDUXUAT'")
            If p_DataRow.Length > 0 Then
                p_TONGDUXUAT = p_DataRow(0).Item(1).ToString.Trim
            End If

            p_DataRow = p_SysConfig.Select("KEYCODE='TONGDUXUATTHUY'")
            If p_DataRow.Length > 0 Then
                p_TONGDUXUAT_Thuy = p_DataRow(0).Item(1).ToString.Trim
            End If


        

            If Me.GridView1.RowCount > 0 Then
                GetGlobalData(0)
            End If
           
        End If
        p_Status = False
    End Sub

    Sub FillHeader()
        If Not p_Header Is Nothing Then
            If p_Header.Rows.Count > 0 Then
                Me.SoLenh.EditValue = p_SoLenh
                Me.MaDonVi.EditValue = p_Header.Rows(0).Item("MaDonVi").ToString.Trim
                Me.NgayHieuLuc.EditValue = p_Header.Rows(0).Item("NgayHieuLuc").ToString.Trim
                Me.NgayLap.EditValue = p_Header.Rows(0).Item("NgayXuat").ToString.Trim
                Me.TenKhachHang.EditValue = p_Header.Rows(0).Item("MaKhachHang").ToString.Trim & " - " & p_Header.Rows(0).Item("TenKhachHang").ToString.Trim
                Me.NguoiVanChuyen.EditValue = p_Header.Rows(0).Item("NguoiVanChuyen").ToString.Trim
                Me.MaNguon.EditValue = p_Header.Rows(0).Item("MaNguon").ToString.Trim
                Me.NguoiVanChuyen.EditValue = p_Header.Rows(0).Item("NguoiVanChuyen").ToString.Trim
                Me.MaVanChuyen.EditValue = p_Header.Rows(0).Item("MaVanChuyen").ToString.Trim & " - " & p_Header.Rows(0).Item("TenMaVanChuyen").ToString.Trim
                '   g_mavanchuyen = p_Header.Rows(0).Item("MaVanChuyen").ToString.Trim

                Me.MaPhuongTien.EditValue = p_Header.Rows(0).Item("MaPhuongTien").ToString.Trim
                Me.Niem.EditValue = p_Header.Rows(0).Item("Niem").ToString.Trim
                Me.KhoXuat.EditValue = p_Header.Rows(0).Item("MaKho").ToString.Trim
            End If
        End If
    End Sub



    Sub FillLine()
        Dim p_Count As Integer
        Dim p_DataRow As DataRow
        Dim p_Binding As New U_TextBox.U_BindingSource

        Dim p_Column As U_TextBox.GridColumn

        If p_Line Is Nothing Then
            Exit Sub
        End If

        p_GridLine = p_Line

        'p_GridLine.Columns.Add("STT", GetType(String))
        'p_GridLine.Columns.Add("MaHangHoa", GetType(String))
        'p_GridLine.Columns.Add("TenHangHoa", GetType(String))
        'p_GridLine.Columns.Add("DVT", GetType(String))
        'p_GridLine.Columns.Add("SoDuXuat", GetType(Double))
        'p_GridLine.Columns.Add("TableID", GetType(String))
        'p_GridLine.Columns.Add("BeXuat", GetType(String))
        'p_GridLine.Columns.Add("LineID", GetType(String))
        'p_GridLine.Columns.Add("SoThucTe", GetType(String))
        'For p_Count = 0 To p_Line.Rows.Count - 1
        '    p_DataRow = p_GridLine.NewRow
        '    p_DataRow.Item("STT") = p_Count + 1
        '    p_DataRow.Item("MaHangHoa") = p_Line.Rows(p_Count).Item("MaHangHoa").ToString.Trim
        '    p_DataRow.Item("TenHangHoa") = p_Line.Rows(p_Count).Item("TenHangHoa").ToString.Trim
        '    p_DataRow.Item("DVT") = p_Line.Rows(p_Count).Item("DonViTinh").ToString.Trim
        '    p_DataRow.Item("SoDuXuat") = p_Line.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim
        '    p_DataRow.Item("TableID") = p_Line.Rows(p_Count).Item("TableID").ToString.Trim
        '    p_DataRow.Item("BeXuat") = p_Line.Rows(p_Count).Item("BeXuat").ToString.Trim
        '    p_DataRow.Item("LineID") = p_Line.Rows(p_Count).Item("LineID").ToString.Trim
        '    p_DataRow.Item("SoThucTe") = p_Line.Rows(p_Count).Item("SoLuongThucXuat").ToString.Trim
        '    p_GridLine.Rows.Add(p_DataRow)
        'Next



        p_Binding.DataSource = p_GridLine
        Me.TrueDBGrid1.DataSource = p_Binding
        p_Binding.ResetBindings(True)

        Try
            Me.GridView1.Columns.Item(0).FieldName = "STT"
            Me.GridView1.Columns.Item(1).FieldName = "MaHangHoa"
            Me.GridView1.Columns.Item(2).FieldName = "TenHangHoa"
            Me.GridView1.Columns.Item(3).FieldName = "DVT"
            If p_GridLine.Columns.IndexOf("SoDuXuat") > 0 Then
                Me.GridView1.Columns.Item(4).FieldName = "SoDuXuat"
            Else
                Me.GridView1.Columns.Item(4).FieldName = "SoLuongDuXuat"
            End If

            Me.GridView1.Columns.Item(5).FieldName = "TableID"
            Me.GridView1.Columns.Item(6).FieldName = "BeXuat"
            Me.GridView1.Columns.Item(7).FieldName = "LineID"
            If p_GridLine.Columns.IndexOf("SoThucTe") > 0 Then
                Me.GridView1.Columns.Item(8).FieldName = "SoThucTe"
            Else
                Me.GridView1.Columns.Item(8).FieldName = "SoLuongThucXuat"
            End If
            'Me.GridView1.Columns.Item(8).FieldName = "SoThucTe"


            'Try
            '    p_Column = New U_TextBox.GridColumn
            '    p_Column.FieldName = "MultiD15"
            '    'p_Column.VisibleIndex = Me.GridView1.Columns.Count
            '    Me.GridView1.Columns.Add(p_Column)
            '    Me.GridView1.OptionsBehavior.ReadOnly = True
            'Catch ex As Exception

            'End Try

            Me.GridView1.OptionsBehavior.ReadOnly = True
        Catch ex As Exception

        End Try
        

        

    End Sub



    Sub FillLine_E5_Reset()
        Dim p_Count As Integer
        Dim p_DataRow As DataRow
        Dim p_Column As U_TextBox.GridColumn

        Dim p_Binding As New U_TextBox.U_BindingSource
        If p_Line Is Nothing Then
            Exit Sub
        End If

        p_GridLine = p_Line

        'p_GridLine.Columns.Add("STT", GetType(String))
        'p_GridLine.Columns.Add("MaHangHoa", GetType(String))
        'p_GridLine.Columns.Add("TenHangHoa", GetType(String))
        'p_GridLine.Columns.Add("DVT", GetType(String))
        'p_GridLine.Columns.Add("SoDuXuat", GetType(Double))
        'p_GridLine.Columns.Add("TableID", GetType(String))
        'p_GridLine.Columns.Add("BeXuat", GetType(String))
        'p_GridLine.Columns.Add("LineID", GetType(String))
        'p_GridLine.Columns.Add("SoThucTe", GetType(String))

        'p_GridLine.Columns.Add("VCF", GetType(Double))
        'p_GridLine.Columns.Add("WCF", GetType(Double))
        'p_GridLine.Columns.Add("KG", GetType(Double))
        'p_GridLine.Columns.Add("NhietDo_BQGQ", GetType(Double))
        'p_GridLine.Columns.Add("D15_BQGQ", GetType(Double))

        'For p_Count = 0 To p_Line.Rows.Count - 1
        '    p_DataRow = p_GridLine.NewRow
        '    p_DataRow.Item("STT") = p_Count + 1
        '    p_DataRow.Item("MaHangHoa") = p_Line.Rows(p_Count).Item("MaHangHoa").ToString.Trim
        '    p_DataRow.Item("TenHangHoa") = p_Line.Rows(p_Count).Item("TenHangHoa").ToString.Trim
        '    p_DataRow.Item("DVT") = p_Line.Rows(p_Count).Item("DonViTinh").ToString.Trim
        '    p_DataRow.Item("SoDuXuat") = p_Line.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim
        '    p_DataRow.Item("TableID") = p_Line.Rows(p_Count).Item("TableID").ToString.Trim
        '    p_DataRow.Item("BeXuat") = p_Line.Rows(p_Count).Item("BeXuat").ToString.Trim
        '    p_DataRow.Item("LineID") = p_Line.Rows(p_Count).Item("LineID").ToString.Trim
        '    p_DataRow.Item("SoThucTe") = p_Line.Rows(p_Count).Item("SoLuongThucXuat").ToString.Trim

        '    p_GridLine.Rows.Add(p_DataRow)
        'Next
        p_Binding.DataSource = p_Line
        Me.TrueDBGrid1.DataSource = p_Binding
        p_Binding.ResetBindings(True)

        Try
            Me.GridView1.Columns.Item(0).FieldName = "STT"
            Me.GridView1.Columns.Item(1).FieldName = "MaHangHoa"
            Me.GridView1.Columns.Item(2).FieldName = "TenHangHoa"
            Me.GridView1.Columns.Item(3).FieldName = "DVT"
            Me.GridView1.Columns.Item(4).FieldName = "SoDuXuat"
            Me.GridView1.Columns.Item(5).FieldName = "TableID"
            Me.GridView1.Columns.Item(6).FieldName = "BeXuat"
            Me.GridView1.Columns.Item(7).FieldName = "LineID"
            Me.GridView1.Columns.Item(8).FieldName = "SoThucTe"

            p_Column = New U_TextBox.GridColumn
            p_Column.FieldName = "VCF"
            'p_Column.VisibleIndex = Me.GridView1.Columns.Count
            Me.GridView1.Columns.Add(p_Column)

            p_Column = New U_TextBox.GridColumn
            p_Column.FieldName = "WCF"
            'p_Column.VisibleIndex = Me.GridView1.Columns.Count
            Me.GridView1.Columns.Add(p_Column)

            p_Column = New U_TextBox.GridColumn
            p_Column.FieldName = "KG"
            'p_Column.VisibleIndex = Me.GridView1.Columns.Count
            Me.GridView1.Columns.Add(p_Column)

            p_Column = New U_TextBox.GridColumn
            p_Column.FieldName = "L15"
            'p_Column.VisibleIndex = Me.GridView1.Columns.Count
            Me.GridView1.Columns.Add(p_Column)


            p_Column = New U_TextBox.GridColumn
            p_Column.FieldName = "NhietDo"
            'p_Column.VisibleIndex = Me.GridView1.Columns.Count
            Me.GridView1.Columns.Add(p_Column)


            p_Column = New U_TextBox.GridColumn
            p_Column.FieldName = "TyTrong"
            'p_Column.VisibleIndex = Me.GridView1.Columns.Count
            Me.GridView1.Columns.Add(p_Column)

            p_Column = New U_TextBox.GridColumn
            p_Column.FieldName = "MultiD15"
            'p_Column.VisibleIndex = Me.GridView1.Columns.Count
            Me.GridView1.Columns.Add(p_Column)
            Me.GridView1.OptionsBehavior.ReadOnly = True
        Catch ex As Exception

        End Try




    End Sub


    Public Sub New(ByVal i_SoLenh As String)

        ' This call is required by the designer.
        InitializeComponent()

        p_SoLenh = i_SoLenh
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub GetGlobalData(ByVal i_index As Integer)
        Dim l_dem As Integer = 0
        Dim l_binhquangiaquyen As Decimal
        Dim l_luongduxuat As Decimal
        Dim l_nhietdo As Decimal
        Dim l_soctodau As Decimal
        Dim l_soctocuoi As Decimal
        Dim p_DataRow As DataRow
        Dim p_ArrDataRow() As DataRow
        Dim p_MaHangHoa As String
        Dim p_TongLit15 As Double = 0
        Dim p_Date As Date
        Dim l_binhquanD15 As Decimal

        Dim p_Table As DataTable
        Dim p_SQL As String
        Dim p_Xitec_Option As String

        Dim p_VCF As Double = 0

        Dim p_MultiD15 As Integer = 1

        p_Xitec_Option = "N"
        p_SQL = "SELECT XITEC_OPTION from tbllenhxuate5 where solenh ='" & p_SoLenh & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("XITEC_OPTION").ToString.Trim = "Y" Then
                    p_Xitec_Option = "Y"
                End If
            End If
        End If
        p_DataRow = Me.GridView1.GetDataRow(i_index)
        p_MaHangHoa = p_DataRow.Item("MaHangHoa").ToString.Trim
        g_mabe = p_DataRow.Item("BeXuat").ToString()
        Try
            Integer.TryParse(p_DataRow.Item("MultiD15").ToString.Trim, p_MultiD15)

        Catch ex As Exception

        End Try
        If p_Xitec_Option = "N" Then   'Lay theo cau hinh
            If UCase(g_mavanchuyen) = "THUY" Then
                If p_TONGDUXUAT_Thuy = "1" Then
                    Try
                        g_luongxuatthucte = p_DataRow("SoDuXuat").ToString()
                    Catch ex As Exception
                        g_luongxuatthucte = p_DataRow("SoLuongDuXuat").ToString()
                    End Try

                Else
                    Try
                        g_luongxuatthucte = p_DataRow("SoThucTe").ToString()
                    Catch ex As Exception
                        g_luongxuatthucte = p_DataRow("SoLuongThucXuat").ToString()
                    End Try

                End If

            Else
                If p_TONGDUXUAT = "1" Then
                    Try
                        g_luongxuatthucte = p_DataRow("SoDuXuat").ToString()
                    Catch ex As Exception
                        g_luongxuatthucte = p_DataRow("SoLuongDuXuat").ToString()
                    End Try
                    ' g_luongxuatthucte = p_DataRow("SoDuXuat").ToString()
                Else
                    Try
                        g_luongxuatthucte = p_DataRow("SoThucTe").ToString()
                    Catch ex As Exception
                        g_luongxuatthucte = p_DataRow("SoLuongThucXuat").ToString()
                    End Try
                    ' g_luongxuatthucte = p_DataRow("SoThucTe").ToString()
                End If
            End If
        Else   'Dao nguoc theo gia tri cau hinh
            If UCase(g_mavanchuyen) = "THUY" Then
                If p_TONGDUXUAT_Thuy = "1" Then
                    Try
                        g_luongxuatthucte = p_DataRow("SoThucTe").ToString()
                    Catch ex As Exception
                        g_luongxuatthucte = p_DataRow("SoLuongThucXuat").ToString()
                    End Try

                Else
                    Try
                        g_luongxuatthucte = p_DataRow("SoDuXuat").ToString()
                    Catch ex As Exception
                        g_luongxuatthucte = p_DataRow("SoLuongDuXuat").ToString()
                    End Try

                End If

            Else
                If p_TONGDUXUAT = "1" Then
                    Try
                        g_luongxuatthucte = p_DataRow("SoThucTe").ToString()
                    Catch ex As Exception
                        g_luongxuatthucte = p_DataRow("SoLuongThucXuat").ToString()
                    End Try
                    ' g_luongxuatthucte = p_DataRow("SoDuXuat").ToString()
                Else
                    Try
                        g_luongxuatthucte = p_DataRow("SoDuXuat").ToString()
                    Catch ex As Exception
                        g_luongxuatthucte = p_DataRow("SoLuongDuXuat").ToString()
                    End Try
                    ' g_luongxuatthucte = p_DataRow("SoThucTe").ToString()
                End If
            End If
        End If
       

        Try
            g_donvitinh = p_DataRow.Item("DVT").ToString()
        Catch ex As Exception
            g_donvitinh = p_DataRow.Item("DonViTinh").ToString()
        End Try


        l_binhquangiaquyen = 0
        l_luongduxuat = 0
        g_nhietdo = 0
        g_tytrong = 0
        g_soctodau = 0
        l_binhquanD15 = 0
        g_soctocuoi = 0
        p_ArrDataRow = p_LineDetail.Select("LineID='" & p_DataRow.Item("LineID").ToString.Trim & "'")
        For i As Integer = 0 To p_ArrDataRow.Length - 1
            ' If g_dt_details.Rows(i).Item("LineID").ToString() = g_dt_material.Rows(i_index).Item("LineID").ToString() Then

            g_macto = p_ArrDataRow(i).Item("MaLuuLuongKe").ToString()
            If p_ArrDataRow(i).Item("ThoiGianDau").ToString.Trim <> "" Then
                g_ngayxuathang = CDate(p_ArrDataRow(i).Item("ThoiGianDau")).ToString("MM/dd/yyyy")
                p_Date = p_ArrDataRow(i).Item("ThoiGianDau")
                g_gioxuathang = Format(p_ArrDataRow(i).Item("ThoiGianDau"), "HH")
                g_phutxuathang = Format(p_ArrDataRow(i).Item("ThoiGianDau"), "mm")
            Else
                g_ngayxuathang = ""
                g_gioxuathang = ""
                g_phutxuathang = ""
            End If
            p_TongLit15 = p_TongLit15 + IIf(p_ArrDataRow(i).Item("GST").ToString.Trim = "", 0, p_ArrDataRow(i).Item("GST").ToString.Trim)
            

            Try
                l_soctodau = Convert.ToDecimal(p_ArrDataRow(i).Item("Sl_llkebd").ToString())
                l_soctocuoi = Convert.ToDecimal(p_ArrDataRow(i).Item("Sl_llkekt").ToString())
            Catch ex As Exception
                l_soctodau = 0
                l_soctocuoi = 0
            End Try


            If l_dem = 0 Then
                g_soctodau = l_soctodau
                g_soctocuoi = l_soctocuoi
            Else
                If g_soctodau > l_soctodau Then
                    g_soctodau = l_soctodau
                End If

                If g_soctocuoi < l_soctocuoi Then
                    g_soctocuoi = l_soctocuoi
                End If
            End If

            '  g_tytrong = g_tytrong + Convert.ToDecimal(p_ArrDataRow(i).Item("TyTrong_15").ToString())
            g_nhietdo = Convert.ToDecimal(p_ArrDataRow(i).Item("NhietDo").ToString())


            If UCase(g_mavanchuyen) = "THUY" Then
                If p_TONGDUXUAT_Thuy = "1" Then
                    l_luongduxuat = Convert.ToDecimal(p_ArrDataRow(i).Item("SoLuongDuXuat").ToString()) ''p_DataRow("SoDuXuat").ToString()
                Else
                    l_luongduxuat = Convert.ToDecimal(p_ArrDataRow(i).Item("SoLuongThucXuat").ToString()) 'p_DataRow("SoThucTe").ToString()
                End If

            Else
                If p_TONGDUXUAT = "1" Then
                    l_luongduxuat = Convert.ToDecimal(p_ArrDataRow(i).Item("SoLuongDuXuat").ToString())  'p_DataRow("SoDuXuat").ToString()
                Else
                    l_luongduxuat = Convert.ToDecimal(p_ArrDataRow(i).Item("SoLuongThucXuat").ToString())  'p_DataRow("SoThucTe").ToString()
                End If
            End If



            '  l_luongduxuat = Convert.ToDecimal(p_ArrDataRow(i).Item("SoLuongThucXuat").ToString())
            l_binhquangiaquyen = l_binhquangiaquyen + g_nhietdo * l_luongduxuat

            l_binhquanD15 = l_binhquanD15 + Convert.ToDecimal(p_ArrDataRow(i).Item("TyTrong_15").ToString()) * l_luongduxuat

            l_dem = l_dem + 1
            'End If
        Next
        Try
            Double.TryParse(p_DataRow("VCF"), p_VCF)
        Catch ex As Exception

        End Try



        If l_dem <> 0 Then
            If p_L15_RESET = "Y" And p_VCF > 0 Then   'And CheckItemToScada2(p_MaHangHoa) = "Y" Then

                g_tytrong = NhietDoLamTron(p_DataRow("TyTrong"), 4)
                g_nhietdo = NhietDoLamTron(p_DataRow("NhietDo"), 2)
                g_vcf = NhietDoLamTron(p_DataRow("VCF"), 4)
                g_Wcf_E5 = NhietDoLamTron(p_DataRow("WCF"), 4)

                g_Kg = p_DataRow("KG")

                p_TongLit15 = p_DataRow("TongLit15")
                g_luongquychuan = p_TongLit15

                If (g_nhietdo Mod 0.25) = 0 Then
                    g_nhietdo_cal = mdlQCI_ConvertTemp(g_nhietdo)
                    GoTo Line_TT
                    ' Return
                End If


                l_nhietdo = NhietDoLamTron(g_nhietdo, 0)   'Math.Round(g_nhietdo, 0)
                If l_nhietdo = g_nhietdo Then
                    GoTo Line_TT
                    'Return
                End If

                g_nhietdo_cal = mdlQCI_ConvertTemp(g_nhietdo)


            Else

                If p_MultiD15 = 1 Then
                    l_binhquanD15 = Convert.ToDecimal(p_ArrDataRow(0).Item("TyTrong_15").ToString())
                    g_tytrong = l_binhquanD15
                Else
                    l_binhquanD15 = NhietDoLamTron(l_binhquanD15, 0)
                    g_tytrong = NhietDoLamTron(l_binhquanD15 / g_luongxuatthucte, 4)   ' g_tytrong / l_dem
                End If


                ' g_tytrong = Math.Round(g_tytrong, 4)

                g_nhietdo = NhietDoLamTron(l_binhquangiaquyen / g_luongxuatthucte, 2)  ' Math.Round(l_binhquangiaquyen / g_luongxuatthucte, 2)



                If (g_nhietdo Mod 0.25) = 0 Then
                    g_nhietdo_cal = mdlQCI_ConvertTemp(g_nhietdo)
                    GoTo Line_TT
                    ' Return
                End If


                l_nhietdo = NhietDoLamTron(g_nhietdo, 0)   'Math.Round(g_nhietdo, 0)
                If l_nhietdo = g_nhietdo Then
                    GoTo Line_TT
                    'Return
                End If

                g_nhietdo_cal = mdlQCI_ConvertTemp(g_nhietdo)

            End If


        End If
Line_TT:
        ShowDetails(p_MaHangHoa, p_TongLit15)
    End Sub


    Public Sub ShowDetails(ByVal p_MaHangHoa As String, ByVal p_Lit15 As Double)

        Dim p_Count As Integer
        Dim wcf As String
        Dim kg As String
        Dim p_Kg As Double

        'FES44
        '20141122
        'Them kiem tra neu xang  E5 thi lay lai so L15
        MaBe.Text = g_mabe
        CongTo.Text = g_macto
        GioXuat.Text = g_gioxuathang & ":" & g_phutxuathang
        ' lblPhutXuatHang.Text = g_phutxuathang
        If g_ngayxuathang.ToString.Trim <> "" Then
            NgayXuat.EditValue = CDate(g_ngayxuathang)
        End If

        CongToDau.Text = mdlFunction_SplitDecimalString(g_soctodau)
        CongToCuoi.Text = mdlFunction_SplitDecimalString(g_soctocuoi)
        TyTrong15.Text = g_tytrong
        Try
            If Len(TyTrong15.Text) = 5 Then
                TyTrong15.Text = TyTrong15.Text & "0"
            End If

            If Len(TyTrong15.Text) = 4 Then
                TyTrong15.Text = TyTrong15.Text & "00"
            End If
            If Len(TyTrong15.Text) = 3 Then
                TyTrong15.Text = TyTrong15.Text & "000"
            End If
        Catch ex As Exception

        End Try
       
        NhietDo.Text = NhietDoLamTron(g_nhietdo, 2) ' Math.Round(Convert.ToDecimal(g_nhietdo), 2)

        If InStr(NhietDo.Text, ".") > 0 Then
            If Len(Mid(NhietDo.Text, InStr(NhietDo.Text, "."))) = 2 Then
                NhietDo.Text = NhietDo.Text & "0"
            Else
                If Len(Mid(NhietDo.Text, InStr(NhietDo.Text, "."))) = 1 Then
                    NhietDo.Text = NhietDo.Text & "00"
                End If
            End If
        Else
            NhietDo.Text = NhietDo.Text & ".00"
        End If

        Dim l_luongquychuan As Decimal()

        If g_vcf Is Nothing Then
            g_vcf = ""
        End If
        If p_L15_RESET = "Y" And g_vcf.ToString.Trim <> "" Then  ' And CheckItemToScada2(p_MaHangHoa) = "Y" Then

            'l_luongquychuan = mdlQCI_CalculateQCI_NS("", g_luongxuatthucte, "L", g_nhietdo, g_tytrong)

            '   g_luongquychuan = l_luongquychuan(1)

            'l_luongquychuan = mdlQCI_CalculateQCI_NS("", g_luongxuatthucte, "L", g_nhietdo, g_tytrong)

            'g_luongquychuan = l_luongquychuan(1)


            XuatThucTe.Text = mdlFunction_SplitDecimalString(g_luongxuatthucte)
            VCF.Text = g_vcf


            wcf = g_Wcf_E5 ' mdlQCI_GetWCF(IIf(g_tytrong.ToString.Trim = "", 0, g_tytrong))

            kg = g_Kg

            Double.TryParse(kg.ToString.Trim, p_Kg)
            Me.KG.Text = p_Kg  'Math.Ceiling(p_Kg - 0.5) '& " L15"
            Me.WCF.Text = wcf

            Double.TryParse(g_luongquychuan, p_Lit15)
            QuyChuan.Text = Math.Ceiling(p_Lit15 - 0.5) '& " L15"
            QuyChuanE5.Text = QuyChuan.Text



        Else
            If CheckItemToScada2(p_MaHangHoa) = "Y" And p_Lit15 > 0 Then
                'anhqh   20180322
                If g_vcf = "" Then
                    g_vcf = Math.Round((Math.Round(p_Lit15) / g_luongxuatthucte), 4)
                End If
                ' g_vcf = Math.Round((Math.Round(p_Lit15) / g_luongxuatthucte), 4)
            Else
                g_vcf = mdlQCI_GetVCF_NS("", g_nhietdo_cal.ToString(), g_tytrong.ToString())
            End If



            l_luongquychuan = mdlQCI_CalculateQCI_NS("", g_luongxuatthucte, "L", g_nhietdo, g_tytrong)

            g_luongquychuan = l_luongquychuan(1)


            XuatThucTe.Text = mdlFunction_SplitDecimalString(g_luongxuatthucte)
            VCF.Text = g_vcf


            wcf = mdlQCI_GetWCF(IIf(g_tytrong.ToString.Trim = "", 0, g_tytrong))

            'If _dtPara.Rows(16).Item("Value_nd").ToString().Trim() = "1" Then
            Dim _L15 As Decimal() = mdlQCI_CalculateQCI_NS("", Decimal.Parse(IIf(g_luongxuatthucte.ToString.Trim = "", 0, g_luongxuatthucte)), "L", Decimal.Parse(IIf(g_nhietdo.ToString.Trim = "", 0, g_nhietdo)), g_tytrong.ToString)
            '  l15 = _L15(1).ToString
            kg = _L15(3).ToString

            Double.TryParse(kg.ToString.Trim, p_Kg)
            Me.KG.Text = Math.Ceiling(p_Kg - 0.5) '& " L15"
            Me.WCF.Text = wcf

            If CheckItemToScada2(p_MaHangHoa) = "Y" Then
                If p_Lit15 > 0 Then
                    QuyChuan.Text = Math.Round(p_Lit15, 0, MidpointRounding.AwayFromZero)  ' Math.Ceiling(p_Lit15 - 0.5) ' & " L15"
                    QuyChuanE5.Text = QuyChuan.Text   'p_Lit15.ToString.Trim '& " L15"


                Else
                    Double.TryParse(g_luongquychuan, p_Lit15)
                    QuyChuan.Text = Math.Ceiling(p_Lit15 - 0.5) '& " L15"
                    QuyChuanE5.Text = QuyChuan.Text

                End If


            Else
                'lblLuongQuyChuan.Text = mdlFunction_SplitDecimalString(g_luongquychuan) & " L15"
                Double.TryParse(g_luongquychuan, p_Lit15)
                QuyChuan.Text = Math.Ceiling(p_Lit15 - 0.5) '& " L15"
                QuyChuanE5.Text = ""
            End If


        End If


        Try
            If Len(VCF.Text) = 5 Then
                VCF.Text = VCF.Text & "0"
            End If

            If Len(VCF.Text) = 4 Then
                VCF.Text = VCF.Text & "00"
            End If
            If Len(VCF.Text) = 3 Then
                VCF.Text = VCF.Text & "000"
            End If
        Catch ex As Exception

        End Try

        Try
            If Len(Me.WCF.Text) = 5 Then
                Me.WCF.Text = Me.WCF.Text & "0"
            End If

            If Len(Me.WCF.Text) = 4 Then
                Me.WCF.Text = Me.WCF.Text & "00"
            End If
            If Len(Me.WCF.Text) = 3 Then
                Me.WCF.Text = Me.WCF.Text & "000"
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_RowClick(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick

    End Sub

    Private Sub GridView1_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridView1.ShowingEditor

    End Sub

    Private Sub GridView1_ShownEditor(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.ShownEditor
        Dim p_GridView As U_TextBox.GridView
        Dim p_Index As Integer
        p_GridView = CType(sender, U_TextBox.GridView)
        p_Index = p_GridView.FocusedRowHandle
        GetGlobalData(p_Index)
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ToolStripButton2.Click
        Dim p_SoLenh As String = ""
        Dim p_Desc As String = ""
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If KiemTraThongTinLenh(p_SoLenh, p_Desc) = True Then
            ShowMessageBox("", p_Desc)
            Exit Sub
        End If
        p_Status = True
        Me.Close()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.Close()
    End Sub

End Class