Imports System.Drawing.Printing
Module KV2

    Public Function InMauHoaNghiem(ByVal i_Preview As Boolean, ByVal i_dt_trans As DataTable, ByRef o_err As String) As Boolean
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_Rpt As New rptHoaNghiem

        Dim p_FormConfig As New FrmConfig
        Try
            '-------------------------------------------------------------------------
            '   Kiểm tra trạng thái máy in
            '-------------------------------------------------------------------------
            Dim l_boolPrint As Boolean

            'For Each strPrinter As String In Printing.PrinterSettings.InstalledPrinters
            '    If strPrinter = g_DefaultPrint Then
            '        l_boolPrint = True
            '        Exit For
            '    Else
            '        l_boolPrint = False
            '    End If
            'Next strPrinter

            'If Not l_boolPrint Then
            '    o_err = "Máy in " & g_DefaultPrint & " không tồn tại trên máy tính. Vui lòng thiết lập lại máy in"
            '    If MsgBox(o_err, MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
            '        p_FormConfig.ShowDialog()
            '    Else
            '        Return False
            '    End If
            'End If


            If i_Preview Then


                p_Rpt.PrinterName = g_DefaultPrint
                p_Rpt.DataSource = i_dt_trans
                p_Rpt.Print()

            Else

                p_Rpt.PrinterName = g_DefaultPrint
                p_Rpt.DataSource = i_dt_trans
                p_Rpt.ShowPreviewDialog()

            End If

            Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try

    End Function



    Public Function mdlTichke_PrintTrans_new(ByVal i_Preview As Boolean, ByVal i_dt_trans As DataTable, _
                                             ByVal i_dt_sub As DataTable, _
                                             ByRef o_err As String) As Boolean
        Dim p_FormConfig As New FrmConfig




        Try
            '-------------------------------------------------------------------------
            '   Kiểm tra trạng thái máy in
            '-------------------------------------------------------------------------
            Dim l_boolPrint As Boolean

            For Each strPrinter As String In Printing.PrinterSettings.InstalledPrinters
                If strPrinter = g_DefaultPrint Then
                    l_boolPrint = True
                    Exit For
                Else
                    l_boolPrint = False
                End If
            Next strPrinter

            If Not l_boolPrint Then
                o_err = "Máy in " & g_DefaultPrint & " không tồn tại trên máy tính. Vui lòng thiết lập lại máy in"
                If MsgBox(o_err, MsgBoxStyle.OkCancel, "Thông báo") = MsgBoxResult.Ok Then
                    p_FormConfig.ShowDialog()
                Else
                    Return False
                End If
            End If

            '------------------------------------------------------------------
            '   Tính tổng xuất
            '------------------------------------------------------------------
            Dim l_TongXuat As Decimal = 0

            For i As Integer = 0 To i_dt_trans.Rows.Count - 1
                If i_dt_trans.Rows(i).Item("SoLuongDuXuat").ToString() <> String.Empty Then
                    l_TongXuat = l_TongXuat + Convert.ToDecimal(i_dt_trans.Rows(i).Item("SoLuongDuXuat").ToString())
                End If
            Next
            '------------------------------------------------------------------
            Dim p_NgayXuat As Date
            Dim p_GioXuat As Integer
            Dim l_ngayxuat As String

            p_GetDateTime(p_NgayXuat, p_GioXuat)
            l_ngayxuat = Format(CDate(p_NgayXuat), "dd/MM/yyyy")


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

            'If g_WareHouse = "264A" Then

            '    If Not mdlTichke_new_PrintTrans_K130(i_Preview, l_header, i_dt_trans, i_dt_sub, o_err) Then
            '        ' o_err = "m021"
            '        Return False
            '    End If

            'Else

            If Not mdlTichke_new_PrintTrans(i_Preview, l_header, i_dt_trans, i_dt_sub, o_err) Then
                ' o_err = "m021"
                Return False
            End If

            'End If

            'If Not mdlTichke_new_PrintTrans(i_Preview, l_header, i_dt_trans, i_dt_sub, o_err) Then
            '    ' o_err = "m021"
            '    Return False
            'End If

            o_err = "m028"
            Return True
        Catch ex As Exception
            o_err = "m040"
            Return False
        End Try
    End Function


    Public Function mdlTichke_new_PrintTrans(ByVal i_Preview As Boolean, _
                                        ByVal i_header() As String, _
                                        ByVal i_dt_trans As DataTable, _
                                        ByVal i_dt_sub As DataTable, ByRef p_Err As String) As Boolean
        Dim p_Rpt As New KV2_TichKe_XuatBo
        Dim p_Rpt_A3 As New KV2_TichKe_A322
        Dim p_RptThuy As New KV2_TichKe_Thuy
        Dim p_K130_Rpt_A3 As New K130_TichKe_A3
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_TICHKE_A3 As Boolean = False
        Dim p_GhiChu As String = ""

        Dim p_CongTy As String = ""
        Dim p_Address As String = ""
        p_SQL = "select * from tblDonvi   where madonvi  in (select top 1 companycode  from tblConfig  )"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_Address = p_Table.Rows(0).Item("DiaChi").ToString.Trim
                p_CongTy = p_Table.Rows(0).Item("TenDonVi").ToString.Trim
            End If
        End If


        p_SQL = "select GhiChu from tblLenhXuatE5 where SoLenh='" & i_header(1) & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_GhiChu = p_Table.Rows(0).Item("GhiChu").ToString.Trim


            End If

        End If


        'p_SQL = "select * from SYS_CONFIG where KeyCode='TICHKE_A3'"
        'p_Table = GetDataTable(p_SQL, p_SQL)

        'If Not p_Table Is Nothing Then
        '    If p_Table.Rows.Count > 0 Then
        '        If p_Table.Rows(0).Item("KeyValue").ToString.Trim = "Y" Then
        '            p_TICHKE_A3 = True
        '        End If
        '    End If

        'End If
        Try

            'Try
            '    If p_Address <> "" Then
            '        p_Rpt.XrLabel60.Text = p_Address
            '    End If
            'Catch ex As Exception

            'End Try
            Try
                If p_CongTy <> "" Then
                    'p_Rpt.XrLabel56.Text = p_CongTy
                End If
            Catch ex As Exception

            End Try

            p_Rpt.Parameters.Item("p_Day").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("dd")
            p_Rpt.Parameters.Item("p_Month").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("MM")
            p_Rpt.Parameters.Item("p_Year").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("yyyy")
            p_Rpt.Parameters.Item("p_CompanyName").Value = "Đơn vị: " & g_TenDonVi
            p_Rpt.Parameters.Item("CongTy").Value = p_CongTy
            p_Rpt.Parameters.Item("DiemTraHang").Value = i_dt_trans.Rows(0).Item("DiemtraHang").ToString

            'p_Rpt.Parameters.Item("p_Day").Visible = False
            'p_Rpt.Parameters.Item("p_Year").Visible = False
            p_Rpt.Parameters.Item("DiemTraHang").Visible = False
            p_Rpt.RequestParameters = False


            Try
                If p_CongTy <> "" Then
                    p_Rpt_A3.XrLabel56.Text = p_CongTy
                End If
            Catch ex As Exception

            End Try

            p_Rpt_A3.Parameters.Item("p_Day").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("dd")
            p_Rpt_A3.Parameters.Item("p_Month").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("MM")
            p_Rpt_A3.Parameters.Item("p_Year").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("yyyy")
            'p_Rpt_A3.Parameters.Item("p_CompanyName").Value = "Đơn vị: " & g_TenDonVi
            p_Rpt_A3.Parameters.Item("p_CompanyName").Value = g_TenDonVi
            p_Rpt_A3.Parameters.Item("DiemTraHang").Value = i_dt_trans.Rows(0).Item("DiemtraHang").ToString

            'p_Rpt.Parameters.Item("p_Day").Visible = False
            'p_Rpt.Parameters.Item("p_Year").Visible = False
            p_Rpt_A3.Parameters.Item("DiemTraHang").Visible = False
            p_Rpt_A3.RequestParameters = False


            p_RptThuy.Parameters.Item("p_Day").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("dd")
            p_RptThuy.Parameters.Item("p_Month").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("MM")
            p_RptThuy.Parameters.Item("p_Year").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("yyyy")
            p_RptThuy.Parameters.Item("p_CompanyName").Value = g_TenDonVi

            p_RptThuy.Parameters.Item("GhiChu").Value = p_GhiChu
            p_RptThuy.Parameters.Item("GhiChu").Visible = False
            'p_Rpt.Parameters.Item("p_Day").Visible = False
            'p_Rpt.Parameters.Item("p_Year").Visible = False
            'p_Rpt.Parameters.Item("p_Month").Visible = False
            p_RptThuy.RequestParameters = False


            If i_Preview Then
                If i_dt_trans.Rows(0).Item("Bo").ToString().Trim() = "X" Then
                    If p_TICHKE_A3 = False Then
                        p_Rpt.PrinterName = g_DefaultPrint
                        p_Rpt.DataSource = i_dt_trans
                        p_Rpt.Print()
                    Else
                        p_Rpt_A3.PrinterName = g_DefaultPrint
                        p_Rpt_A3.DataSource = i_dt_trans
                        p_Rpt_A3.Print()
                    End If

                Else
                    p_RptThuy.PrinterName = g_DefaultPrint
                    p_RptThuy.DataSource = i_dt_trans
                    p_RptThuy.Print()
                End If
            Else
                If i_dt_trans.Rows(0).Item("Bo").ToString().Trim() = "X" Then
                    If p_TICHKE_A3 = False Then
                        p_Rpt.PrinterName = g_DefaultPrint
                        p_Rpt.DataSource = i_dt_trans
                        p_Rpt.ShowPreviewDialog()
                    Else
                        p_Rpt_A3.PrinterName = g_DefaultPrint
                        p_Rpt_A3.DataSource = i_dt_trans
                        p_Rpt_A3.ShowPreviewDialog()
                    End If
                Else
                    p_RptThuy.PrinterName = g_DefaultPrint
                    p_RptThuy.DataSource = i_dt_trans
                    p_RptThuy.ShowPreviewDialog()
                End If
            End If


            Return True
        Catch ex As Exception
            p_Err = ex.Message
            Return False
        End Try
    End Function



    Public Function mdlTichke_new_PrintTrans_20260325(ByVal i_Preview As Boolean, _
                                        ByVal i_header() As String, _
                                        ByVal i_dt_trans As DataTable, _
                                        ByVal i_dt_sub As DataTable, ByRef p_Err As String) As Boolean
        Dim p_Rpt As New KV2_TichKe_XuatBo 'KV2_TichKe_New22
        Dim p_Rpt_A3 As New KV2_TichKe_A322
        Dim p_RptThuy As New KV2_TichKe_Thuy
        Dim p_K130_Rpt_A3 As New K130_TichKe_A3
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_TICHKE_A3 As Boolean = False
        Dim p_GhiChu As String = ""

        Dim p_CongTy As String = ""
        Dim p_Address As String = ""
        p_SQL = "select * from tblDonvi   where madonvi  in (select top 1 companycode  from tblConfig  )"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_Address = p_Table.Rows(0).Item("DiaChi").ToString.Trim
                p_CongTy = p_Table.Rows(0).Item("TenDonVi").ToString.Trim
            End If
        End If


        p_SQL = "select GhiChu from tblLenhXuatE5 where SoLenh='" & i_header(1) & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_GhiChu = p_Table.Rows(0).Item("GhiChu").ToString.Trim


            End If

        End If


        p_SQL = "select * from SYS_CONFIG where KeyCode='TICHKE_A3'"
        p_Table = GetDataTable(p_SQL, p_SQL)

        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("KeyValue").ToString.Trim = "Y" Then
                    p_TICHKE_A3 = True
                End If
            End If

        End If
        Try

            'Try
            '    If p_Address <> "" Then
            '        p_Rpt.XrLabel60.Text = p_Address
            '    End If
            'Catch ex As Exception

            'End Try
            Try
                If p_CongTy <> "" Then
                    p_Rpt.XrLabel56.Text = p_CongTy
                End If
            Catch ex As Exception

            End Try

            p_Rpt.Parameters.Item("p_Day").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("dd")
            p_Rpt.Parameters.Item("p_Month").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("MM")
            p_Rpt.Parameters.Item("p_Year").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("yyyy")
            p_Rpt.Parameters.Item("p_CompanyName").Value = g_TenDonVi
            p_Rpt.Parameters.Item("DiemTraHang").Value = i_dt_trans.Rows(0).Item("DiemtraHang").ToString

            'p_Rpt.Parameters.Item("p_Day").Visible = False
            'p_Rpt.Parameters.Item("p_Year").Visible = False
            p_Rpt.Parameters.Item("DiemTraHang").Visible = False
            p_Rpt.RequestParameters = False


            Try
                If p_CongTy <> "" Then
                    p_Rpt_A3.XrLabel56.Text = p_CongTy
                End If
            Catch ex As Exception

            End Try

            p_Rpt_A3.Parameters.Item("p_Day").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("dd")
            p_Rpt_A3.Parameters.Item("p_Month").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("MM")
            p_Rpt_A3.Parameters.Item("p_Year").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("yyyy")
            'p_Rpt_A3.Parameters.Item("p_CompanyName").Value = "Đơn vị: " & g_TenDonVi
            p_Rpt_A3.Parameters.Item("p_CompanyName").Value = g_TenDonVi
            p_Rpt_A3.Parameters.Item("DiemTraHang").Value = i_dt_trans.Rows(0).Item("DiemtraHang").ToString

            'p_Rpt.Parameters.Item("p_Day").Visible = False
            'p_Rpt.Parameters.Item("p_Year").Visible = False
            p_Rpt_A3.Parameters.Item("DiemTraHang").Visible = False
            p_Rpt_A3.RequestParameters = False


            p_RptThuy.Parameters.Item("p_Day").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("dd")
            p_RptThuy.Parameters.Item("p_Month").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("MM")
            p_RptThuy.Parameters.Item("p_Year").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("yyyy")
            p_RptThuy.Parameters.Item("p_CompanyName").Value = g_TenDonVi

            p_RptThuy.Parameters.Item("GhiChu").Value = p_GhiChu
            p_RptThuy.Parameters.Item("GhiChu").Visible = False
            'p_Rpt.Parameters.Item("p_Day").Visible = False
            'p_Rpt.Parameters.Item("p_Year").Visible = False
            'p_Rpt.Parameters.Item("p_Month").Visible = False
            p_RptThuy.RequestParameters = False


            If i_Preview Then
                If i_dt_trans.Rows(0).Item("Bo").ToString().Trim() = "X" Then
                    If p_TICHKE_A3 = False Then
                        p_Rpt.PrinterName = g_DefaultPrint
                        p_Rpt.DataSource = i_dt_trans
                        p_Rpt.Print()
                    Else
                        p_Rpt_A3.PrinterName = g_DefaultPrint
                        p_Rpt_A3.DataSource = i_dt_trans
                        p_Rpt_A3.Print()
                    End If

                Else
                    p_RptThuy.PrinterName = g_DefaultPrint
                    p_RptThuy.DataSource = i_dt_trans
                    p_RptThuy.Print()
                End If
            Else
                If i_dt_trans.Rows(0).Item("Bo").ToString().Trim() = "X" Then
                    If p_TICHKE_A3 = False Then
                        p_Rpt.PrinterName = g_DefaultPrint
                        p_Rpt.DataSource = i_dt_trans
                        p_Rpt.ShowPreviewDialog()
                    Else
                        p_Rpt_A3.PrinterName = g_DefaultPrint
                        p_Rpt_A3.DataSource = i_dt_trans
                        p_Rpt_A3.ShowPreviewDialog()
                    End If
                Else
                    p_RptThuy.PrinterName = g_DefaultPrint
                    p_RptThuy.DataSource = i_dt_trans
                    p_RptThuy.ShowPreviewDialog()
                End If
            End If


            Return True
        Catch ex As Exception
            p_Err = ex.Message
            Return False
        End Try
    End Function


    Public Function mdlTichke_new_PrintTrans_K130(ByVal i_Preview As Boolean, _
                                        ByVal i_header() As String, _
                                        ByVal i_dt_trans As DataTable, _
                                        ByVal i_dt_sub As DataTable, ByRef p_Err As String) As Boolean
        Dim p_Rpt As New KV2_TichKe_XuatBo 'KV2_TichKe_New22
        Dim p_Rpt_A3 As New KV2_TichKe_A322 ' K130_TichKe_A3
        Dim p_RptThuy As New KV2_TichKe_Thuy
        'Dim p_K130_Rpt_A3 As New K130_TichKe_A3
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_TICHKE_A3 As Boolean = False
        Dim p_GhiChu As String = ""
        p_SQL = "select GhiChu from tblLenhXuatE5 where SoLenh='" & i_header(1) & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_GhiChu = p_Table.Rows(0).Item("GhiChu").ToString.Trim


            End If

        End If


        p_SQL = "select * from SYS_CONFIG where KeyCode='TICHKE_A3'"
        p_Table = GetDataTable(p_SQL, p_SQL)

        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("KeyValue").ToString.Trim = "Y" Then
                    p_TICHKE_A3 = True
                End If
            End If

        End If
        Try

            p_Rpt.Parameters.Item("p_Day").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("dd")
            p_Rpt.Parameters.Item("p_Month").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("MM")
            p_Rpt.Parameters.Item("p_Year").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("yyyy")
            p_Rpt.Parameters.Item("p_CompanyName").Value = g_TenDonVi
            p_Rpt.Parameters.Item("DiemTraHang").Value = i_dt_trans.Rows(0).Item("DiemtraHang").ToString

            'p_Rpt.Parameters.Item("p_Day").Visible = False
            'p_Rpt.Parameters.Item("p_Year").Visible = False
            p_Rpt.Parameters.Item("DiemTraHang").Visible = False
            p_Rpt.RequestParameters = False



            p_Rpt_A3.Parameters.Item("p_Day").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("dd")
            p_Rpt_A3.Parameters.Item("p_Month").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("MM")
            p_Rpt_A3.Parameters.Item("p_Year").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("yyyy")
            p_Rpt_A3.Parameters.Item("p_CompanyName").Value = g_TenDonVi
            p_Rpt_A3.Parameters.Item("DiemTraHang").Value = i_dt_trans.Rows(0).Item("DiemtraHang").ToString

            'p_Rpt.Parameters.Item("p_Day").Visible = False
            'p_Rpt.Parameters.Item("p_Year").Visible = False
            p_Rpt_A3.Parameters.Item("DiemTraHang").Visible = False
            p_Rpt_A3.RequestParameters = False




            p_RptThuy.Parameters.Item("p_Day").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("dd")
            p_RptThuy.Parameters.Item("p_Month").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("MM")
            p_RptThuy.Parameters.Item("p_Year").Value = CDate(i_dt_trans.Rows(0).Item("NgayXuat")).ToString("yyyy")
            p_RptThuy.Parameters.Item("p_CompanyName").Value = g_TenDonVi

            p_RptThuy.Parameters.Item("GhiChu").Value = p_GhiChu
            p_RptThuy.Parameters.Item("GhiChu").Visible = False
            'p_Rpt.Parameters.Item("p_Day").Visible = False
            'p_Rpt.Parameters.Item("p_Year").Visible = False
            'p_Rpt.Parameters.Item("p_Month").Visible = False
            p_RptThuy.RequestParameters = False


            If i_Preview Then
                If i_dt_trans.Rows(0).Item("Bo").ToString().Trim() = "X" Then
                    If p_TICHKE_A3 = False Then
                        p_Rpt.PrinterName = g_DefaultPrint
                        p_Rpt.DataSource = i_dt_trans
                        p_Rpt.Print()
                    Else
                        p_Rpt_A3.PrinterName = g_DefaultPrint
                        p_Rpt_A3.DataSource = i_dt_trans
                        p_Rpt_A3.Print()
                    End If

                Else
                    p_RptThuy.PrinterName = g_DefaultPrint
                    p_RptThuy.DataSource = i_dt_trans
                    p_RptThuy.Print()
                End If
            Else
                If i_dt_trans.Rows(0).Item("Bo").ToString().Trim() = "X" Then
                    If p_TICHKE_A3 = False Then
                        p_Rpt.PrinterName = g_DefaultPrint
                        p_Rpt.DataSource = i_dt_trans
                        p_Rpt.ShowPreviewDialog()
                    Else
                        p_Rpt_A3.PrinterName = g_DefaultPrint
                        p_Rpt_A3.DataSource = i_dt_trans
                        p_Rpt_A3.ShowPreviewDialog()
                    End If
                Else
                    p_RptThuy.PrinterName = g_DefaultPrint
                    p_RptThuy.DataSource = i_dt_trans
                    p_RptThuy.ShowPreviewDialog()
                End If
            End If


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
