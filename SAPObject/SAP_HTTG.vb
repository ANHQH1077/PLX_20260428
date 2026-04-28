Module SAP_HTTG
    Private p_FunctionTableId As String

    Public Function mdlSyncDeliveries_SynSpecific(ByVal i_solenh As String, ByRef o_err As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_c2sapex As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SAP.Str_PhieuXuatTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_ret2ex As Connect2SapEx.BAPIRET2
        Dim l_err As String
        Dim l_f As Boolean = False

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String
        Dim p_TableConfig As DataTable
        Dim p_SapConnectionString As String = ""
        Dim p_TimeOut = New TimeSpan()
        Dim p_WareHouse As String = ""
        Dim p_ShPoint As String = ""
        Dim p_DataRowArr() As DataRow

        mdlSyncDeliveries_SynSpecific = False

        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG"

        p_TableConfig = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_DataRowArr = p_TableConfig.Select("KEYCODE='TABLEID'")
                If p_DataRowArr.Length > 0 Then
                    p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If
            End If
        End If



        p_SQL = "select * from tblConfig "

        p_TableConfig = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_SapConnectionString = p_TableConfig.Rows(0).Item("sapconnectionstring").ToString.Trim
                p_WareHouse = p_TableConfig.Rows(0).Item("warehouse").ToString.Trim
                p_ShPoint = p_TableConfig.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If
        If p_SapConnectionString = "" Then
            mdlSyncDeliveries_SynSpecific = True
            Exit Function
        End If

        'l_c2sapex = New Connect2SapEx.Connect2Sap(p_SapConnectionString)

        'l_ret2ex = New Connect2SapEx.BAPIRET2()
        ''-----------------------------------------------------------------
        'Try
        '    ' l_c2sapex.
        '    '  l_c2sapex.Connection.PrepareForPooling()
        '    l_c2sapex.Connection.Open()
        'Catch ex As Exception
        '    l_c2sapex.Dispose()
        '    o_err = ex.Message
        '    Return False
        'End Try

        Try
            l_c2sap = New Connect2SAP.Connect2SAP(p_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_PhieuXuatTable()
            l_err = String.Empty

            If p_TableConfig.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
                l_c2sap.GetPhieuXuat_Specific(i_solenh, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetPhieuXuat_Specific(i_solenh, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetPhieuXuat_Specific(l_async, l_ztb, l_ret2)
                End If
            End If

            If l_ztb.Count > 0 Then
                '------------------------------------------------------------------------------
                '   Kiểm tra thời hạn hiệu lực của hóa đơn
                '------------------------------------------------------------------------------
                'FES44
                '20141113
                If Not mdlSyncDeliveries_CheckStartTime(l_ztb.Item(0).Date_Nd) Then
                    o_err = "Lệnh xuất chưa được phép xuất hàng!"
                    Return False
                End If

                If Not mdlSyncDeliveries_CheckEndTime(l_ztb.Item(0).Date_E_Nd) Then
                    o_err = "Lệnh xuất đã hết hạn!"
                    Return False
                End If

                If l_ztb.Item(0).Plant <> p_WareHouse Then
                    o_err = "Kiểm tra thông tin Kho xuất hàng ghi trên lệnh xuất!"
                    Return False
                End If

                If l_ztb.Item(0).Shpoint = p_ShPoint Then
                    If l_ztb.Item(0).Storage <> String.Empty Then
                        If l_ztb.Item(0).Batch_Nd <> String.Empty Then
                            If mdlSyncDeliveries_SubModifyFromTable_new(l_ztb, o_err) = False Then
                                Return False
                            End If

                            o_err = "Đồng bộ dữ liệu thành công!"
                            Return True
                        Else
                            o_err = "Lệnh xuất chưa được phép xuất hàng!"
                        End If
                    Else
                        o_err = "Chưa có Storage Location nên không thể đồng bộ lệnh xuất này!"
                    End If
                Else
                    o_err = "Lệnh xuất khác Shipping Point nên không thể xuất hàng!"
                End If
            Else
                o_err = "Lệnh xuất không hợp lệ để thực hiện xuất hàng!"
            End If
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            'Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try

    End Function


    'FES KV2
    '20141016
    Private Function mdlSyncDeliveries_CheckStartTime(ByVal i_date As String) As Boolean
        Dim l_date_start As Date
        Dim l_date_now As Date

        Dim l_date, _
            l_month, _
            l_year As String

        If i_date = String.Empty Then
            Return True
        End If

        Try
            l_date_now = Date.Now
            l_date = i_date.Substring(i_date.Length - 2, 2)
            l_month = i_date.Substring(i_date.Length - 4, 2)
            l_year = i_date.Substring(0, 4)

            If Convert.ToInt32(l_date) = 0 Or _
               Convert.ToInt32(l_month) = 0 Or _
               Convert.ToInt32(l_year) = 0 Then
                Return True
                'Return False
            End If

            l_date_start = New Date(l_year, l_month, l_date)

            If l_date_start.Date > l_date_now.Date Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function mdlSyncDeliveries_CheckEndTime(ByVal i_date As String) As Boolean
        Dim l_date_end As Date
        Dim l_date_now As Date

        Dim l_date, _
            l_month, _
            l_year As String

        If i_date = String.Empty Then
            Return True
        End If

        Try
            l_date_now = Date.Now
            l_date = i_date.Substring(i_date.Length - 2, 2)
            l_month = i_date.Substring(i_date.Length - 4, 2)
            l_year = i_date.Substring(0, 4)

            If Convert.ToInt32(l_date) = 0 Or _
               Convert.ToInt32(l_month) = 0 Or _
               Convert.ToInt32(l_year) = 0 Then
                Return True
                'Return False
            End If

            l_date_end = New Date(l_year, l_month, l_date)

            If l_date_end.Date < l_date_now.Date Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Function mdlSyncDeliveries_SubModifyFromTable_new(ByVal i_lt_temp As Connect2SAP.Str_PhieuXuatTable, ByRef p_desc As String) As Boolean

        '-----------------------------------------------------------------
        'Các Bussiness
        '-----------------------------------------------------------------
        ' Dim l_bs_Header As BSTransaction_new
        'Dim l_bs_Detail As BSTransactionDetail_new

        '-----------------------------------------------------------------
        'Work Area
        '-----------------------------------------------------------------
        Dim l_wa As Connect2SAP.Str_PhieuXuat = New Connect2SAP.Str_PhieuXuat()

        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat        
        '-----------------------------------------------------------------
        Dim l_malenh, _
            l_solenh, _
            l_loaiphieu, _
            l_status _
            As String

        Dim l_ngayxuat _
            As String

        Dim l_sql, _
            l_err As String

        Dim l_dt_transaction As DataTable
        Dim p_Date As Date
        Dim p_Time As Integer
        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat_HangHoa
        '   Key:
        '       MaLenh
        '       NgayXuat
        '       SoLenh      - phục vụ tìm kiếm nhanh
        '-----------------------------------------------------------------
        Dim l_lineid _
            As String

        Dim l_tongxuat, _
            l_tongduxuat _
            As Decimal

        Dim l_date, _
            l_month, _
            l_year _
            As Integer
        Dim p_DateTime As String
        Dim l_count As Integer = 0

        Dim p_DataExec As New DataTable("Table001")
        p_DataExec.Columns.Add("STR_SQL")

        Dim p_DataExecLine As New DataTable("Table002")
        p_DataExecLine.Columns.Add("STR_SQL")

        Dim p_DataRow As DataRow

        p_GetDateTime(p_Date, p_Time)
        p_DateTime = CDate(p_Date).ToString("dd/MM/yyyy")
        '-----------------------------------------------------------------
        '   Kiểm tra số lệnh đã tồn tại trong hệ thống hay chưa?
        '   Kiểm tra trạng thái của lệnh đó
        '-----------------------------------------------------------------
        '   l_bs_Header = New BSTransaction_new()
        l_sql = "select Solenh, Status from tblLenhXuatE5 with (Nolock)   where SoLenh = '" & i_lt_temp.Item(0).Outbound.ToString() & "'"
        l_err = String.Empty
        l_status = String.Empty
        l_dt_transaction = GetDataTable(l_sql, l_err)
        If l_dt_transaction IsNot Nothing Then
            If l_dt_transaction.Rows.Count > 0 Then
                l_status = l_dt_transaction.Rows(0).Item("Status").ToString()
            End If
        Else
            l_status = String.Empty
        End If

        Select Case l_status.Trim()
            Case String.Empty
            Case "1"
            Case "2"
                'Case "3"
                'Case "31"
                'Case "4"
                'Case "5"
                'Case "X"
            Case Else
                Return False
        End Select
        '-----------------------------------------------------------------

        '-----------------------------------------------------------------
        'Đặt mã mới theo ngày                        
        '-----------------------------------------------------------------
        l_solenh = i_lt_temp.Item(0).Outbound.ToString()

        l_date = p_DateTime.Substring(0, 2)
        l_month = p_DateTime.Substring(3, 2)
        l_year = p_DateTime.Substring(6, 4)
        l_ngayxuat = New DateTime(l_year, l_month, l_date)
        l_loaiphieu = i_lt_temp.Item(0).Shnumber.ToString()
        If l_loaiphieu = String.Empty Then
            l_loaiphieu = "V144"
        End If


        l_status = i_lt_temp.Item(0).Status.ToString()
        'l_malenh = l_bs_Header.SelectMaLenh(l_err, l_ngayxuat)

        l_malenh = FPT_GetMaLenh()
        '-----------------------------------------------------------------
        '   Kiểm tra mã lệnh sau khi tính toán
        '-----------------------------------------------------------------
        If Not mdlSyncDeliveries_CheckMaLenh(l_malenh, l_ngayxuat) Then
            Return False
        End If
        '-----------------------------------hXuat------------------------------

        '-----------------------------------------------------------------
        '   1. Nếu (2) thành công thì Insert dữ liệu vào bảng tblLenhXuat
        '
        '   2. Insert dữ liệu vào bảng tblLenhXuatChiTiet (có TR)                       
        '
        '   3. Insert dữ liệu vào tblLenhXuat_HangHoa
        '
        '-----------------------------------------------------------------
        '-----------------------------------------------------------------
        '   1. Insert dữ liệu vào bảng tblLenhXuat
        '-----------------------------------------------------------------
        l_wa = i_lt_temp.Item(0)
        ' l_bs_Header = New BSTransaction_new()

        If Not mdlSyncDeliveries_SubModifyFromWorkArea(p_DataExec, l_wa, l_malenh, l_ngayxuat, g_Company_Code, p_desc) Then
            Return False
        End If
        If p_DataExec.Rows.Count > 0 Then
            p_DataRow = p_DataExec.NewRow
            p_DataRow.Item(0) = "DELETE FROM tblLenhXuat_HangHoaE5 where SoLenh='" & l_wa.Outbound.ToString() & "'"
            p_DataExec.Rows.Add(p_DataRow)
        End If


        '-----------------------------------------------------------------
        '   3. Insert dữ liệu vào tblLenhXuat_HangHoa
        '-----------------------------------------------------------------
        l_count = 0
        l_wa = i_lt_temp.Item(0)
        l_lineid = i_lt_temp.Item(0).Item_Nd.ToString()

        For i As Integer = 0 To i_lt_temp.Count - 1

            If l_wa.Item_Nd.ToString() <> i_lt_temp.Item(i).Item_Nd.ToString() Then
                l_tongxuat = 0
                l_tongduxuat = 0
                'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
                p_DataExecLine.Clear()
                If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine(p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty) Then
                    l_count = l_count + 1
                End If
                l_wa = i_lt_temp.Item(i)
                If p_DataExecLine.Rows.Count > 0 Then
                    p_DataExec.Merge(p_DataExecLine)
                End If
            End If

            If i = i_lt_temp.Count - 1 Then
                l_tongxuat = 0
                l_tongduxuat = 0
                'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
                p_DataExecLine.Clear()
                If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine(p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty) Then
                    l_count = l_count + 1
                End If
                If p_DataExecLine.Rows.Count > 0 Then
                    p_DataExec.Merge(p_DataExecLine)
                End If
            End If

        Next

        If l_count <> 0 Then
            l_err = String.Empty
            '  l_bs_Header.DeleteTransaction(l_err, l_solenh, l_ngayxuat)
            ' mdlSyncDeliveries_DeleteAllDetails_new(l_solenh)
            Return False
        End If
        If Not p_DataExec Is Nothing Then
            If g_Services.Sys_Execute_DataTbl(p_DataExec, p_desc) = False Then
                'MsgBox(p_SQL)
                g_Module.ModErrExceptionNew("", p_desc)
                Return False
            End If
        End If


        Return True
    End Function


    Private Function mdlSyncDeliveries_SubModifyFromWorkAreaLine(ByRef p_DataExec As DataTable, ByVal i_wa As Connect2SAP.Str_PhieuXuat, _
                                                           ByVal i_malenh As String, _
                                                           ByVal i_ngayxuat As String, _
                                                           ByVal i_solenh As String, _
                                                           ByVal i_tongxuat As Decimal, _
                                                           ByVal i_tongduxuat As Decimal, _
                                                           ByVal i_loaiphieu As String, _
                                                           ByVal i_tableid As String) As Boolean
        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat_HangHoa
        '   Key:
        '       MaLenh
        '       NgayXuat
        '       SoLenh      - phục vụ tìm kiếm nhanh
        '-----------------------------------------------------------------
        Dim l_mahanghoa, _
            l_donvitinh _
            As String

        '-----------------------------------------------------------------
        'Các biến Tính QCI
        '   l_out:      
        '   l_quantity: Tính lượng QCI trả ra
        '-----------------------------------------------------------------
        'Dim l_out As String()
        Dim l_quantity As Decimal() = New Decimal() {0, 0, 0, 0}
        Dim l_err As String
        Dim p_SQL As String
        'Dim p_DataTable As New DataTable("Table002")
        Dim p_DataTableCheck As DataTable
        Dim p_DataRow As DataRow
        Dim p_TBLTABLEID_ZT As Boolean = False
        Dim p_TableID As String

        p_SQL = "select Name from sys.all_objects where upper(Name)='TBLTABLEID_ZT'"
        p_DataTableCheck = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTableCheck Is Nothing Then
            If p_DataTableCheck.Rows.Count > 0 Then
                p_TBLTABLEID_ZT = True
            End If
        End If
        'p_DataTable.Columns.Add("STR_LINE")
        'p_SQL = "DELETE FROM tblLenhXuat_HangHoaE5 where SoLenh='" & i_solenh & "'"
        'p_DataRow = p_DataTable.NewRow
        'p_DataRow.Item(0) = p_SQL
        'p_DataTable.Rows.Add(p_DataRow)

        l_donvitinh = i_wa.Unit.ToString()
        mdlSyncDeliveries_SubModifyFromWorkAreaLine = True
        i_tongxuat = 0
        i_tongduxuat = Convert.ToDecimal(i_wa.Salequantity.ToString())

        '-----------------------------------------------------------------
        'Tính QCI
        '-----------------------------------------------------------------
       
        Try


            If i_wa.Material.Length > 7 Then
                l_mahanghoa = i_wa.Material.Substring(i_wa.Material.Length - 7, 7)
            Else
                l_mahanghoa = i_wa.Material.Substring(0, i_wa.Material.Length)
            End If

            l_err = String.Empty

            l_quantity = mdlQCI_CalculateQCI(i_tongduxuat, i_wa.Unit, 15, 0.688)
            If InsertQci(l_err, i_malenh, i_ngayxuat, i_wa.Item_Nd.ToString(), i_solenh, i_wa.Compartment.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3)) Then
                UpdateQci(l_err, i_solenh, i_wa.Compartment.ToString(), i_wa.Item_Nd.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3))
            End If
            '-----------------------------------------------------------------
            p_TableID = GetTableID()
            p_SQL = "INSERT INTO [tblLenhXuat_HangHoaE5] (LineID, MaLenh,NgayXuat, SoLenh,TongXuat, " & _
                "TongDuXuat, MaHangHoa, DonViTinh,BeXuat,TableID ,Createby,CreateDate) "
            p_SQL = p_SQL & " VALUES ('" & i_wa.Item_Nd.ToString() & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & i_solenh & "'" & _
                    "," & l_quantity(1) & "," & i_tongduxuat & ",'" & l_mahanghoa & "','" & l_donvitinh & "','','" & p_TableID & "'," & g_User_ID & ",getdate())"

            p_DataRow = p_DataExec.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataExec.Rows.Add(p_DataRow)

            If p_TBLTABLEID_ZT = True Then
                p_SQL = "INSERT INTO [TBLTABLEID_ZT](NgayXuat,TableID) VALUES ('" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & p_TableID & "')"
                p_DataRow = p_DataExec.NewRow
                p_DataRow.Item(0) = p_SQL
                p_DataExec.Rows.Add(p_DataRow)
            End If

        Catch ex As Exception
            mdlSyncDeliveries_SubModifyFromWorkAreaLine = False
        End Try
    End Function



    Private Function UpdateQci(ByRef err As String, ByVal i_solenh As String, ByVal i_mangan As String, ByVal i_lineid As String, _
                                        ByVal i_L As Decimal, ByVal i_L15 As Decimal, ByVal i_M15 As Decimal, ByVal i_KG As Decimal) As Boolean

        Dim p_SQL As String = ""
        p_SQL = "UPDATE [tblQci] SET  [L] = " & i_L & ", [KG] =" & i_KG & ",  [L15] = " & i_L15 & ", [M15] = " & i_M15 & " " & _
                    " WHERE    [SoLenh]= '" & i_solenh & "' and    [LineId]= '" & i_lineid & "' and    [MaNgan]= '" & i_mangan & "'"
        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

        End If

    End Function

    Private Function InsertQci(ByRef err As String, _
                              ByVal i_malenh As String, _
                              ByVal i_ngayxuat As Date, _
                              ByVal i_lineid As String, _
                              ByVal i_solenh As String, _
                              ByVal i_mangan As String, _
                              ByVal i_L As Decimal, _
                              ByVal i_L15 As Decimal, _
                              ByVal i_M15 As Decimal, _
                              ByVal i_KG As Decimal) As Boolean

        Dim p_SQL As String = ""
        p_SQL = "INSERT INTO [tblQci] ( [MaLenh], [NgayXuat],[LineId],[SoLenh],[MaNgan],[L],[KG],[L15],[M15]) "
        p_SQL = p_SQL & " VALUES('" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & i_lineid & "'" & _
                ",'" & i_solenh & "','" & i_mangan & "'," & i_L & "," & i_KG & "," & i_L15 & "," & i_M15 & ")"

        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

        End If
    End Function


    Private Function GetTableID() As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable

        p_SQL = " exec " & p_FunctionTableId
        GetTableID = ""
        Try
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTableID = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
        Catch ex As Exception
            GetTableID = ""
        End Try

    End Function


    Private Function mdlSyncDeliveries_CheckMaLenh(ByVal i_malenh As String, ByVal i_ngayxuat As String) As Boolean
        '-----------------------------------------------------------------
        '   Kiểm tra mã lệnh sau khi tính toán
        '-----------------------------------------------------------------
        Dim l_malenh As String
        Dim l_malenh_check As Char()
        Dim l_check As String
        Dim l_err As String = String.Empty

        l_malenh = i_malenh

        If l_malenh = String.Empty Then
            Return False
        End If

        Try
            Convert.ToInt32(l_malenh)

            l_malenh_check = l_malenh.ToCharArray()
            For i As Integer = 0 To l_malenh_check.Length - 1

                If l_malenh_check(i).ToString().Trim() = "." Then
                    Return False
                End If
            Next
            '-----------------------------------------------------------------
            '   Kiểm tra có trong db chưa
            '-----------------------------------------------------------------
            'Dim l_bs As BSTransaction_new
            'l_bs = New BSTransaction_new

            l_check = CheckMaLenh(l_err, i_malenh, i_ngayxuat)

            If l_check.Trim = "1" Then
                Return False
            End If

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Function mdlSyncDeliveries_SubModifyFromWorkArea(ByRef p_DataExec As DataTable, ByVal i_wa As Connect2SAP.Str_PhieuXuat, _
                                                            ByVal i_malenh As String, _
                                                            ByVal i_ngayxuat As String, ByVal p_CompanyCode As String, ByRef p_Desc As String) As Boolean

        Dim l_solenh, _
            l_madonvi, _
            l_manguon, _
            l_makho, _
            l_mavanchuyen, _
            l_maphuongtien, _
            l_nguoivanchuyen, _
            l_maphuongthucban, _
            l_maphuongthucxuat, _
            l_makhachhang, _
            l_loaiphieu, _
            l_ngayhieuluc, _
            l_status _
            As String
        Dim l_number As Integer
        Dim l_err As String

        Dim p_DataRow As DataRow
        Dim p_SQL As String

        l_err = String.Empty

        Try


            l_solenh = i_wa.Outbound.ToString()
            l_madonvi = p_CompanyCode
            'l_manguon = i_wa.Batch_Nd.ToString()
            l_manguon = i_wa.Resource_Nd.ToString()
            l_makho = i_wa.Plant.ToString()
            'l_mavanchuyen = i_wa.Veh_Mode.ToString()
            l_mavanchuyen = i_wa.Transmot.ToString()
            l_maphuongtien = i_wa.Vehicle.ToString()
            l_nguoivanchuyen = i_wa.Drivercode.ToString()
            l_maphuongthucban = i_wa.Method_Dc.ToString()
            l_maphuongthucxuat = i_wa.Method_Mt.ToString()
            l_makhachhang = i_wa.Customer.ToString()
            l_loaiphieu = i_wa.Shnumber.ToString()
            If l_loaiphieu = String.Empty Then
                l_loaiphieu = "V144"
                l_mavanchuyen = i_wa.Transmot.ToString()
            End If
            l_ngayhieuluc = i_wa.Date_E_Nd
            l_status = i_wa.Status.ToString()

            l_status = "1"
            l_number = 0
            p_SQL = ""
            If Check_SoLenh(l_err, l_solenh) = False Then   'Chua ton tai so lenh
                p_SQL = "INSERT INTO [tblLenhXuatE5] (SoLenhSAP,[MaLenh],[NgayXuat],[SoLenh],[MaDonVi],[MaNguon],[MaKho]," & _
                    "[MaVanChuyen],[MaPhuongTien],[NguoiVanChuyen],[MaPhuongThucBan],[MaPhuongThucXuat]," & _
                    "[MaKhachHang],[LoaiPhieu],[Niem],[LuongGiamDinh],[NhietDoTaiTau],[GhiChu],[NgayHieuLuc],[Status],[Number] ,Createby,CreateDate) "
                p_SQL = p_SQL & " VALUES ('" & l_solenh & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & l_solenh & "','" & l_madonvi & "','" & l_manguon & "'" & _
                        ",'" & l_makho & "','" & l_mavanchuyen & "','" & l_maphuongtien & "','" & l_nguoivanchuyen & "','" & l_maphuongthucban & "','" & l_maphuongthucxuat & "'" & _
                        ",'" & l_makhachhang & "','" & l_loaiphieu & "','','','','','" & l_ngayhieuluc.ToString.Trim & "','" & l_status & "'," & l_number & _
                        "," & g_User_ID & ",getdate())"
            Else  ''Da ton tai so lenh
                p_SQL = "UPDATE [dbo].[tblLenhXuatE5] SET  MaDonVi = '" & l_madonvi & "',MaNguon = '" & l_manguon & "', MaKho ='" & l_makho & "'" & _
                            ",MaVanChuyen = '" & l_mavanchuyen & "',MaPhuongTien='" & l_maphuongtien & "',NguoiVanChuyen='" & l_nguoivanchuyen & "',MaPhuongThucBan'" & l_maphuongthucban & "'" & _
                            ",MaPhuongThucXuat='" & l_maphuongthucxuat & "',MaKhachHang='" & l_makhachhang & "',LoaiPhieu='" & l_loaiphieu & "'" & _
                            ",NgayHieuLuc='" & l_ngayhieuluc.ToString.Trim & "',Status='" & l_status & "',Number=" & l_number & ", UpdatedBy=" & g_User_ID & ",UpdateDate=getdate() " & _
                            " WHERE   SoLenh ='" & l_solenh & "'"

            End If
            If p_SQL <> "" Then
                p_DataRow = p_DataExec.NewRow
                p_DataRow.Item(0) = p_SQL
                p_DataExec.Rows.Add(p_DataRow)
            End If
            Return True
        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try
    End Function


    Private Function Check_SoLenh(ByRef err As String, ByVal i_SoLenh As String) As Boolean
        Dim p_DataTable As DataTable
        Dim p_Err As String
        Check_SoLenh = False
        'Return g_c2SQL.ExeNonQuery("sp_Check_SoLenhE5", err, New SqlParameter("@SoLenh", i_SoLenh))
        p_DataTable = GetDataTable("exec sp_Check_SoLenhE5 '" & i_SoLenh & "'", p_Err)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Check_SoLenh = True
            End If
        End If
    End Function
End Module
