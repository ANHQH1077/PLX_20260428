'Imports System.Drawing.Printing
'Imports KeepAutomation
Imports DevExpress.XtraReports.UI
Module KV2




    Public Function mdlTichke_PrintTrans_new(ByVal i_Preview As Boolean, ByVal i_dt_trans As DataTable, _
                                             ByVal i_dt_sub As DataTable, _
                                             ByRef o_err As String) As Boolean
        Dim p_FormConfig As New FrmConfig
        Try
            '-------------------------------------------------------------------------
            '   Kiểm tra trạng thái máy in
            '-------------------------------------------------------------------------
            Dim l_boolPrint As Boolean
            ' MsgBox("123")
            For Each strPrinter As String In Printing.PrinterSettings.InstalledPrinters
                If strPrinter = g_DefaultPrint Then
                    l_boolPrint = True
                    Exit For
                Else
                    l_boolPrint = False
                End If
            Next strPrinter
            ' MsgBox("456")
            If Not l_boolPrint Then
                o_err = "Máy in " & g_DefaultPrint & " không tồn tại trên máy tính. Vui lòng thiết lập lại máy in"
                If MsgBox(o_err, MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
                    p_FormConfig.ShowDialog()
                Else
                    Return False
                End If
            End If

            ' MsgBox("789")
            '------------------------------------------------------------------
            '   Tính tổng xuất
            '------------------------------------------------------------------
            Dim l_TongXuat As Decimal = 0

            For i As Integer = 0 To i_dt_trans.Rows.Count - 1
                If i_dt_trans.Rows(i).Item("SoLuongDuXuat").ToString() <> String.Empty Then
                    l_TongXuat = l_TongXuat + Convert.ToDecimal(i_dt_trans.Rows(i).Item("SoLuongDuXuat").ToString())
                    'l_TongXuat = l_TongXuat + Convert.ToDecimal(i_dt_trans.Rows(i).Item("SoLuongDuXuat").ToString())
                    ' i_dt_trans.Rows(i).Item("SoLuongThucXuat") = Convert.ToInt32(i_dt_trans.Rows(i).Item("SoLuongDuXuat").ToString())
                End If
            Next
            '------------------------------------------------------------------
            Dim p_NgayXuat As Date
            Dim p_GioXuat As Integer
            Dim l_ngayxuat As String
            'MsgBox("11111")
            p_GetDateTime(p_NgayXuat, p_GioXuat)
            l_ngayxuat = Format(CDate(i_dt_trans.Rows(0).Item("NgayXuat").ToString()), "dd/MM/yyyy")


            'FES
            '20141006
            'vi thi thang _Date_Kv1 is nothing  nen thay lai nhu the
            'Can hoi lai VinhND
            'If Not _Date_Kv1 Is Nothing Then
            '    If _Date_Kv1.ToString.Trim = "" Then
            '        l_ngayxuat = i_dt_trans.Rows(0).Item(1) ' _Date_Kv1
            '    Else
            '        l_ngayxuat = _Date_Kv1
            '    End If
            'Else
            '    l_ngayxuat = i_dt_trans.Rows(0).Item(1) ' _Date_Kv1
            'End If
            Dim l_header() As String = New String() { _
                                                    l_ngayxuat, _
                                                    i_dt_trans.Rows(0).Item("SoLenh").ToString(), _
                                                    i_dt_trans.Rows(0).Item("MaTichKe").ToString(), _
                                                    i_dt_trans.Rows(0).Item("MaPhuongTien").ToString(), _
                                                    i_dt_trans.Rows(0).Item("NguoiVanChuyen").ToString(), _
                                                    mdlFunction_Convert2DecimalString(l_TongXuat)}

            '-------------------------------------------------------------------------
            '   In Ticke
            '-------------------------------------------------------------------------            
            'MsgBox("2222")
            If Not mdlTichke_new_PrintTrans(i_Preview, l_header, i_dt_trans, i_dt_sub, o_err) Then
                ' o_err = "m021"
                Return False
            End If
            ' MsgBox("3333")
            o_err = "m028"
            Return True
        Catch ex As Exception
            o_err = "m040"
            Return False
        End Try
    End Function

    'Page_Load()



    Public Function mdlTichke_new_PrintTrans(ByVal i_Preview As Boolean, _
                                        ByVal i_header() As String, _
                                        ByVal i_dt_trans As DataTable, _
                                        ByVal i_dt_sub As DataTable, ByRef p_Err As String) As Boolean
        ' Dim p_BarCode As Byte()


        Dim p_Rpt As New KV1_TichKe
        'Dim p_Rpt_Thuy As New KV1_Bill
        ' Dim p_DataSet As New DataSet("TichKe")
        'i_dt_trans.Rows(0).Item("MaKho") = "09070020:07092015"
        'p_Rpt.DataSource = i_dt_trans
        'p_Rpt.ShowPreviewDialog()
        ' Return True
        Try
            'MsgBox("Printer")

            p_Err = ""
            ' p_BarCode = Page_Load()
            ' p_DataSet.Tables.Add(i_dt_trans)
            'p_Rpt.PrinterName = g_DefaultPrint
            'p_Rpt.DataSource = i_dt_trans
            'p_Rpt.ShowPreviewDialog()
            'Return True
            If i_Preview Then
                ' MsgBox("Printer1")
                ' If i_dt_trans.Rows(0).Item("Bo").ToString().Trim() = "X" Then
                '_rptTicke_new = New rptTicke_Kv1_mul
                '_rptTicke_new.PrintOptions.PrinterName = g_DefaultPrint
                '_rptTicke_new.SetDataSource(i_dt_trans)
                ''_rptTicke_new.Subreports(0).SetDataSource(i_dt_sub)
                '_rptTicke_new.SetParameterValue("P_Ngay", i_header(0).Substring(0, 2))
                '_rptTicke_new.SetParameterValue("P_Thang", i_header(0).Substring(3, 2))
                '_rptTicke_new.SetParameterValue("P_Nam", i_header(0).Substring(6, 4))
                '_rptTicke_new.SetParameterValue("P_number", i_header(2))
                '_rptTicke_new.SetParameterValue("P_Vehicle", i_header(3))
                '_rptTicke_new.SetParameterValue("P_Driver", i_header(4))
                '_rptTicke_new.SetParameterValue("P_Sum", i_header(5))

                '_rptTicke_new.PrintOptions.PrinterName = g_DefaultPrint
                '_rptTicke_new.PrintToPrinter(1, False, 0, 0)
                ' p_Rpt.p_Day. = i_dt_trans.Rows(0).Item("NgayXuat").ToString.Trim

                p_Rpt.Parameters("sNgay").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat").ToString.Trim).Day
                p_Rpt.Parameters("sThang").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat").ToString.Trim).Month
                p_Rpt.Parameters("sNam").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat").ToString.Trim).Year
                p_Rpt.Parameters("sNgay").Visible = False
                p_Rpt.Parameters("sThang").Visible = False
                p_Rpt.Parameters("sNam").Visible = False
                p_Rpt.PrinterName = g_DefaultPrint
                p_Rpt.DataSource = i_dt_trans
                p_Rpt.Print()
                'Else
                '    '_rptTicke_thuy = New rptTicke_Thuy()
                '    ''_rptTicke_thuy.PrintOptions.PrinterName = g_DefaultPrint
                '    '_rptTicke_thuy.SetDataSource(i_dt_trans)
                '    '_rptTicke_thuy.SetParameterValue("P_Ngay", i_header(0).Substring(0, 2))
                '    '_rptTicke_thuy.SetParameterValue("P_Thang", i_header(0).Substring(3, 2))
                '    '_rptTicke_thuy.SetParameterValue("P_Nam", i_header(0).Substring(6, 4))
                '    '_rptTicke_thuy.SetParameterValue("P_number", i_header(2))
                '    '_rptTicke_thuy.SetParameterValue("P_Vehicle", i_header(3))
                '    '_rptTicke_thuy.SetParameterValue("P_Driver", i_header(4))
                '    '_rptTicke_thuy.SetParameterValue("P_Sum", i_header(5))

                '    '_rptTicke_thuy.PrintOptions.PrinterName = g_DefaultPrint
                '    '_rptTicke_thuy.PrintToPrinter(1, False, 0, 0)
                '    p_Rpt_Thuy.Parameters.Item("MaDonVi").Value = g_Company_Code
                '    'p_Rpt_Thuy.Parameters.Item("SoTichKe").Value = "bbbbb"
                '    p_Rpt_Thuy.Parameters.Item("MaDonVi").Visible = False
                '    'p_Rpt_Thuy.Parameters.Item("SoTichKe").Visible = False
                '    p_Rpt_Thuy.RequestParameters = False
                '    p_Rpt_Thuy.PrinterName = g_DefaultPrint
                '    p_Rpt_Thuy.DataSource = i_dt_trans
                '    p_Rpt.Print()
                'End If
            Else
                'If i_dt_trans.Rows(0).Item("Bo").ToString().Trim() = "X" Then

                ' MsgBox("eeeeeee")
                p_Rpt.Parameters("sNgay").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat").ToString.Trim).Day
                p_Rpt.Parameters("sThang").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat").ToString.Trim).Month
                p_Rpt.Parameters("sNam").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat").ToString.Trim).Year
                p_Rpt.Parameters("sNgay").Visible = False
                p_Rpt.Parameters("sThang").Visible = False
                p_Rpt.Parameters("sNam").Visible = False
                p_Rpt.PrinterName = g_DefaultPrint
                '  MsgBox("eeeeeee1")
                p_Rpt.DataSource = i_dt_trans

                'p_Rpt.Parameters.Item("GhiChu").Value = "test" 'hieptd4

                ' MsgBox("eeeeeee2")
                'Dim p_form As New Form1s
                ' MsgBox("Printer88888")
                p_Rpt.ShowPreviewDialog()
                ' MsgBox("eeeeeee3")
                'Else
                '    p_Rpt_Thuy.Parameters.Item("MaDonVi").Value = g_Company_Code
                '    'p_Rpt_Thuy.Parameters.Item("SoTichKe").Value = "bbbbb"
                '    p_Rpt_Thuy.Parameters.Item("MaDonVi").Visible = False
                '    'p_Rpt_Thuy.Parameters.Item("SoTichKe").Visible = False
                '    p_Rpt_Thuy.RequestParameters = False
                '    p_Rpt_Thuy.PrinterName = g_DefaultPrint
                '    p_Rpt_Thuy.DataSource = i_dt_trans
                '    p_Rpt_Thuy.ShowPreviewDialog()
                'End If
                ' Dim l_fprint As frmPrint = New frmPrint(1, i_dt_trans, i_dt_sub, i_header)
                ' l_fprint.ShowDialog()
                ' Dim p_FormIn As New FrmXem
                'p_FormIn.PrintControl1.DataBindings = p_Rpt_Thuy
            End If
            ' MsgBox("Printer3")
            Return True
        Catch ex As Exception
            p_Err = ex.Message
            Return False
        End Try
    End Function



    Public Function mdlFunction_Convert2DecimalString(ByVal i_decimal As Decimal) As String
        Dim l_dec_str As String
        Dim l_dec_str_arr As String()
        Dim l_dec_str_char As Char()
        Dim l_count As Integer

        l_dec_str = i_decimal.ToString()
        l_dec_str_arr = l_dec_str.Split(".")

        If l_dec_str_arr.Length = 0 Then
            Return l_dec_str
        End If

        l_dec_str_char = l_dec_str_arr(0).ToCharArray()
        l_count = 0
        l_dec_str = String.Empty

        For i As Integer = (l_dec_str_char.Length - 1) To 0 Step -1
            l_dec_str = l_dec_str_char(i).ToString() & l_dec_str
            l_count = l_count + 1

            If l_count = 3 And i <> 0 Then
                l_dec_str = "," & l_dec_str
                l_count = 0
            End If
        Next

        Return l_dec_str

    End Function

    Public Function mdlFunction_SplitDecimalString(ByVal i_decimal As Decimal) As String
        Dim l_dec_str As String
        Dim l_dec_str_arr As String()
        Dim l_dec_str_char As Char()

        Try

            l_dec_str = i_decimal.ToString()
            l_dec_str_arr = l_dec_str.Split(".")

            If l_dec_str_arr.Length = 0 Then
                Return l_dec_str
            End If

            l_dec_str_char = l_dec_str_arr(0).ToCharArray()

            Return l_dec_str_char
        Catch ex As Exception
            Return i_decimal.ToString()
        End Try
    End Function


End Module
