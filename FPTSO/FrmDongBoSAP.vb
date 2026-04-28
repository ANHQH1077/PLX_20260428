Public Class FrmDongBoSAP
    Private flag As Integer()
    Private lw_mess As String()

    Private isGetAll As String
    Private g_dt As DataTable
    Private _TimeOut = New TimeSpan()

    Private _SapConnectionString As String
    Private _WareHouse As String
    Dim _dtVariable As DataTable
    Private _ShPoint As String
    'Dim g_BSLog As BSLogSyn

    Private Sub FrmDongBoSAP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim p_SQL As String
        ReDim flag(15)   'ReDim flag(8)  'hieptd4 edit
        ReDim lw_mess(15) 'ReDim lw_mess(8) 'hieptd4 edit
        p_SQL = "select * from tblConfig"
        _dtVariable = GetDataTable(p_SQL, p_SQL)
        If Not _dtVariable Is Nothing Then
            If _dtVariable.Rows.Count > 0 Then
                _SapConnectionString = _dtVariable.Rows(0).Item("sapconnectionstring").ToString.Trim
                _WareHouse = _dtVariable.Rows(0).Item("WareHouse").ToString.Trim
                _ShPoint = _dtVariable.Rows(0).Item("shippingpoint").ToString.Trim
            End If
        End If
        '<<<<<<< .mine
        ''Me.rAll.Checked = True
        rHaft.Checked = True
        '||||||| .r1118
        ' Me.rAll.Checked = True
        '=======
        'Me.rAll.Checked = True
        '  Me.rHaft.Checked = True
        '>>>>>>> .r1178
    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Cursor = Cursors.WaitCursor
        Try

            'Kiểm tra xem chọn getAll hay ko?
            If rAll.Checked = True Then
                isGetAll = _getAllSyn
            Else
                If rHaft.Checked = True Then
                    isGetAll = _getHaftSyn
                End If
            End If

            BackgroundWorker1_DoWork()

            'rAll.Enabled = False
            'rHaft.Enabled = False
            'chkDonViTinh.Enabled = False
            'chkHangHoa.Enabled = False
            'chkKhachHang.Enabled = False
            'chkNguonHang.Enabled = False
            'chkPhuongThuc.Enabled = False
            'chkPhuongTien.Enabled = False
            'chkVanChuyen.Enabled = False
            'chkCongTo.Enabled = False
            'chkBeXuat.Enabled = False
        Catch ex As Exception
            Cursor = Cursors.Default
            ShowStatusMessage(True, "", ex.Message, 7)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub chkSoHoaDon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSoHoaDon.CheckedChanged
        If chkSoHoaDon.Checked = True Then
            chkDonViTinh.Enabled = False
            chkHangHoa.Enabled = False
            chkKhachHang.Enabled = False
            chkNguonHang.Enabled = False
            chkPhuongThuc.Enabled = False
            chkPhuongTien.Enabled = False
            chkVanChuyen.Enabled = False
            chkCongTo.Enabled = False
            chkBeXuat.Enabled = False
        Else
            chkDonViTinh.Enabled = True
            chkHangHoa.Enabled = True
            chkKhachHang.Enabled = True
            chkNguonHang.Enabled = True
            chkPhuongThuc.Enabled = True
            chkPhuongTien.Enabled = True
            chkVanChuyen.Enabled = True
            chkCongTo.Enabled = True
            chkBeXuat.Enabled = True
        End If
    End Sub

    Private Function BackgroundWorker1_DoWork() As Boolean
        Dim lw_str = "Đồng bộ dữ liệu"
        Dim lw_failed = "thất bại"
        Dim lw_ok = "thành công"
        Dim l_date As String = String.Empty
        Dim p_DataExec As New DataTable("table001")
        Dim p_Date As Date
        Dim p_time As Integer
        Dim p_SQL As String = ""
        Dim p_Datatable As DataTable
        Dim p_Desc As String

        Dim p_Message As String = " không có dữ liệu đồng bộ"

        'Dim p_SQL As String
        p_DataExec.Columns.Add("STR_SQL")
        '  p_GetDateTime(p_Date, p_time)
        BackgroundWorker1_DoWork = False

        Dim p_SyncMaster As New SynMaster.Class1(g_WCF, g_Services, flag, lw_mess, isGetAll, _
                  g_dt, _SapConnectionString, _WareHouse, _dtVariable, g_Company_Code, _ShPoint)


        p_SQL = "SELECT * FROM SYS_CONFIG where KEYCODE='WEBSERVER64'"
        p_Datatable = GetDataTable(p_SQL, p_SQL)
        p_SQL = "Y"
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_SQL = p_Datatable.Rows(0).Item("KEYVALUE").ToString.Trim
            End If
        End If

        Cursor = Cursors.WaitCursor

        'hieptd4 add 20161027
        'Chọn đồng bộ Đơn giá ==============================================================
        If flag(13) = 1 Then
            l_date = p_SyncMaster.clsGetDateLog("DonGia")
            ' p_Date = p_
            If p_SyncMaster.ClsSyncMaster_SyncPrice(p_DataExec, l_date, p_Desc) Then
                lw_mess(0) = lw_str & " " & "Đơn giá" & " " & lw_ok
                'If g_WCF = True Then
                '    p_SyncMaster.clsCapNhatLog("DonGia", 0)
                'End If
            Else
                lw_mess(0) = p_Desc  ' lw_str & " " & "Đơn giá" & " " & lw_failed
                ShowStatusMessage(True, "", lw_mess(0), 7)
                BackgroundWorker1_DoWork = True
                p_DataExec.Clear()
                Cursor = Cursors.Default
                '  Exit Function
            End If

            If g_WCF = False Then
                'If p_DataExec.Rows.Count > 0 Then
                ' If DataTableRunExecBigData(p_DataExec, p_SQL) = False Then
                'MsgBox(p_SQL)
                'lw_mess(0) = lw_str & " " & "Đơn giá" & " " & p_SQL
                'ShowStatusMessage(True, "", lw_mess(0), 7)
                'BackgroundWorker1_DoWork = True
                'p_DataExec.Clear()
                'Cursor = Cursors.Default
                ' Exit Function
                ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
                '  End If
                ' End If
                lw_mess(0) = lw_str & " " & "Đơn giá" & " " & lw_ok
                ShowStatusMessage(False, "", lw_mess(0), 7)
                p_DataExec.Clear()
                p_SyncMaster.clsCapNhatLog("DonGia", 0)
            Else
                lw_mess(0) = lw_str & " " & "Đơn gián" & " " & lw_ok
                ShowStatusMessage(False, "", lw_mess(0), 7)
                p_DataExec.Clear()
                p_SyncMaster.clsCapNhatLog("DonGia", 0)
            End If

            p_SQL = ""
            l_date = ""
            l_date = p_SyncMaster.clsGetDateLog("TyGia")
            THN_TyGia_Infor(l_date, p_SQL)
            If p_SQL <> "" Then
                ShowStatusMessage(False, "", p_SQL, 7)
            Else

                ShowStatusMessage(False, "", "Đồng bộ thành công", 7)
            End If
        End If
                'Chọn đồng bộ Thời hạn thanh toán ==============================================================
                If flag(12) = 1 Then
                    'l_date = p_SyncMaster.clsGetDateLog("TuyenDuong")

                    If p_SyncMaster.ClsSyncMaster_SyncPaymentTerm(p_DataExec, p_Desc) Then
                        lw_mess(0) = lw_str & " " & "Thời hạn thanh toán" & " " & lw_ok
                        'If g_WCF = True Then
                        '    p_SyncMaster.clsCapNhatLog("KhachHang", 0)
                        'End If
                    Else
                        lw_mess(0) = p_Desc  'lw_str & " " & "Thời hạn thanh toán" & " " & lw_failed
                        ShowStatusMessage(True, "", lw_mess(0), 7)
                        BackgroundWorker1_DoWork = True
                        p_DataExec.Clear()
                        Cursor = Cursors.Default
                        Exit Function
                    End If

                    If g_WCF = False Then
                        If p_DataExec.Rows.Count > 0 Then
                            If DataTableRunExecBigData(p_DataExec, p_SQL) = False Then
                                'MsgBox(p_SQL)
                                lw_mess(0) = lw_str & " " & "Thời hạn thanh toán" & " " & lw_failed
                                ShowStatusMessage(True, "", lw_mess(0), 7)
                                BackgroundWorker1_DoWork = True
                                p_DataExec.Clear()
                                Cursor = Cursors.Default
                                Exit Function
                                ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
                            End If
                        End If
                        lw_mess(0) = lw_str & " " & "Thời hạn thanh toán" & " " & lw_ok
                        ShowStatusMessage(False, "", lw_mess(0), 7)
                        p_DataExec.Clear()
                        'p_SyncMaster.clsCapNhatLog("TuyenDuong", 0)
                    Else
                        lw_mess(0) = lw_str & " " & "Thời hạn thanh toán" & " " & lw_ok
                        ShowStatusMessage(False, "", lw_mess(0), 7)
                        p_DataExec.Clear()
                        'p_SyncMaster.clsCapNhatLog("TuyenDuong", 0)
                    End If
                End If
                'Chọn đồng bộ Map Tuyến đường - Điểm giao nhận ==============================================================
                If flag(11) = 1 Then
                    'l_date = p_SyncMaster.clsGetDateLog("TuyenDuong")

                    If p_SyncMaster.ClsSyncMaster_SyncDischard(p_DataExec, p_Desc) Then
                        lw_mess(0) = lw_str & " " & "Tuyến đường - Điểm giao nhận" & " " & lw_ok
                        'If g_WCF = True Then
                        '    p_SyncMaster.clsCapNhatLog("KhachHang", 0)
                        'End If
                    Else
                        lw_mess(0) = p_Desc   ' lw_str & " " & "Tuyến đường - Điểm giao nhận" & " " & lw_failed
                        ShowStatusMessage(True, "", lw_mess(0), 7)
                        BackgroundWorker1_DoWork = True
                        p_DataExec.Clear()
                        Cursor = Cursors.Default
                        Exit Function
                    End If

                    If g_WCF = False Then
                        If p_DataExec.Rows.Count > 0 Then
                            If DataTableRunExecBigData(p_DataExec, p_SQL) = False Then
                                'MsgBox(p_SQL)
                                lw_mess(0) = lw_str & " " & "Tuyến đường - Điểm giao nhận" & " " & lw_failed
                                ShowStatusMessage(True, "", lw_mess(0), 7)
                                BackgroundWorker1_DoWork = True
                                p_DataExec.Clear()
                                Cursor = Cursors.Default
                                Exit Function
                                ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
                            End If
                        End If
                        lw_mess(0) = lw_str & " " & "Tuyến đường - Điểm giao nhận" & " " & lw_ok
                        ShowStatusMessage(False, "", lw_mess(0), 7)
                        p_DataExec.Clear()
                        'p_SyncMaster.clsCapNhatLog("TuyenDuong", 0)
                    Else
                        lw_mess(0) = lw_str & " " & "Tuyến đường - Điểm giao nhận" & " " & lw_ok
                        ShowStatusMessage(False, "", lw_mess(0), 7)
                        p_DataExec.Clear()
                        'p_SyncMaster.clsCapNhatLog("TuyenDuong", 0)
                    End If
                End If
                'Chọn đồng bộ Tuyến đường ==============================================================
                If flag(10) = 1 Then
                    'l_date = p_SyncMaster.clsGetDateLog("TuyenDuong")

                    If p_SyncMaster.ClsSyncMaster_SyncRoute(p_DataExec, p_Desc) Then
                        lw_mess(0) = lw_str & " " & "Tuyến đường" & " " & lw_ok
                        'If g_WCF = True Then
                        '    p_SyncMaster.clsCapNhatLog("KhachHang", 0)
                        'End If
                    Else
                        lw_mess(0) = p_Desc  ' lw_str & " " & "Tuyến đường" & " " & lw_failed
                        ShowStatusMessage(True, "", lw_mess(0), 7)
                        BackgroundWorker1_DoWork = True
                        p_DataExec.Clear()
                        Cursor = Cursors.Default
                        Exit Function
                    End If

                    If g_WCF = False Then
                        If p_DataExec.Rows.Count > 0 Then
                            If DataTableRunExecBigData(p_DataExec, p_SQL) = False Then
                                'MsgBox(p_SQL)
                                lw_mess(0) = lw_str & " " & "Tuyến đường" & " " & lw_failed
                                ShowStatusMessage(True, "", lw_mess(0), 7)
                                BackgroundWorker1_DoWork = True
                                p_DataExec.Clear()
                                Cursor = Cursors.Default
                                Exit Function
                                ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
                            End If
                        End If
                        lw_mess(0) = lw_str & " " & "Tuyến đường" & " " & lw_ok
                        ShowStatusMessage(False, "", lw_mess(0), 7)
                        p_DataExec.Clear()
                        'p_SyncMaster.clsCapNhatLog("TuyenDuong", 0)
                    Else
                        lw_mess(0) = lw_str & " " & "Tuyến đường" & " " & lw_ok
                        ShowStatusMessage(False, "", lw_mess(0), 7)
                        p_DataExec.Clear()
                        'p_SyncMaster.clsCapNhatLog("TuyenDuong", 0)
                    End If
                End If

                'end hieptd4 add 20161027

                'Chọn đồng bộ khách hàng    ==============================================================
                If flag(0) = 1 Then
                    l_date = p_SyncMaster.clsGetDateLog("KhachHang")  '  CDate(p_Date).ToString("yyyy.MM.dd")  ' g_dt.Rows(0).Item("SynDate").ToString()

                    'If syndm.SynKhachHang(isGetAll, l_date) Then
                    If p_SyncMaster.ClsSyncMaster_SyncCustomer(p_DataExec, isGetAll, l_date, p_Desc) Then
                        lw_mess(0) = lw_str & " " & "Khách hàng" & " " & lw_ok

                        If g_WCF = True Then
                            p_SyncMaster.clsCapNhatLog("KhachHang", 0)
                        End If

                    Else
                        lw_mess(0) = p_Desc   'lw_str & " " & "Khách hàng" & " " & lw_failed & " " & p_Desc

                    End If

                    If g_WCF = False Then
                        If p_DataExec.Rows.Count > 0 Then
                            If DataTableRunExecBigData(p_DataExec, p_SQL) = False Then
                                'MsgBox(p_SQL)
                                MsgBox(p_Desc)

                                lw_mess(0) = lw_str & " " & "Khách hàng" & " " & lw_failed
                                ShowStatusMessage(True, "", lw_mess(0), 7)
                                BackgroundWorker1_DoWork = True
                                p_DataExec.Clear()
                                Cursor = Cursors.Default
                                Exit Function
                                ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
                            End If
                        End If
                        lw_mess(0) = lw_str & " " & "Khách hàng" & " " & lw_ok
                        ShowStatusMessage(False, "", lw_mess(0), 7)
                        p_DataExec.Clear()
                        p_SyncMaster.clsCapNhatLog("KhachHang", 0)
                    Else
                        lw_mess(0) = lw_str & " " & "Khách hàng" & " " & lw_ok
                        ShowStatusMessage(False, "", lw_mess(0), 7)
                        p_DataExec.Clear()
                        'p_SyncMaster.clsCapNhatLog("KhachHang", 0)
                    End If

                End If

                'Chọn đồng bộ vận chuyển  =====================================================
                If flag(1) = 1 Then
                    l_date = p_SyncMaster.clsGetDateLog("VanChuyen")  '  CDate(p_Date).ToString("yyyy.MM.dd")
                    'syndm.SynVanChuyen(isGetAll)
                    If p_SyncMaster.ClsSyncMaster_SyncTransport(p_DataExec, isGetAll, p_Desc) Then
                        lw_mess(1) = lw_str & " " & "Vận chuyển" & " " & lw_ok
                        If g_WCF = True Then
                            p_SyncMaster.clsCapNhatLog("VanChuyen", 0)
                        End If
                    Else
                        lw_mess(1) = p_Desc   ' lw_str & " " & "Vận chuyển" & " " & lw_failed
                    End If
                    If g_WCF = False Then
                        If p_DataExec.Rows.Count > 0 Then
                            If DataTableRunExecBigData(p_DataExec, p_SQL) = False Then
                                'MsgBox(p_SQL)
                                lw_mess(1) = lw_str & " " & "Vận chuyển" & " " & lw_failed
                                ShowStatusMessage(True, "", lw_mess(1), 7)
                                BackgroundWorker1_DoWork = True
                                p_DataExec.Clear()
                                Cursor = Cursors.Default
                                Exit Function
                                ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
                            End If

                        End If
                        lw_mess(1) = lw_str & " " & "Vận chuyển" & " " & lw_ok
                        ShowStatusMessage(False, "", lw_mess(1), 7)
                        p_DataExec.Clear()
                        p_SyncMaster.clsCapNhatLog("VanChuyen", 0)
                    Else
                        ShowStatusMessage(False, "", lw_mess(1), 7)
                        p_DataExec.Clear()
                        ' p_SyncMaster.clsCapNhatLog("VanChuyen", 0)
                    End If
                End If
                'Chọn đồng bộ Nguồn hàng =========================================
                If flag(2) = 1 Then
                    l_date = p_SyncMaster.clsGetDateLog("NguonHang")  ' CDate(p_Date).ToString("yyyy.MM.dd")
                    If p_SyncMaster.ClsSynNguonHang(p_DataExec, isGetAll, l_date, p_Desc) Then
                        lw_mess(2) = lw_str & " " & "Nguồn hàng" & " " & lw_ok

                        If g_WCF = True Then
                            p_SyncMaster.clsCapNhatLog("NguonHang", 0)
                        End If


                    Else
                        lw_mess(2) = p_Desc  ' lw_str & " " & "Nguồn hàng" & " " & lw_failed
                    End If
                    If g_WCF = False Then
                        If p_DataExec.Rows.Count > 0 Then
                            If DataTableRunExecBigData(p_DataExec, p_SQL) = False Then
                                'MsgBox(p_SQL)
                                lw_mess(2) = lw_str & " " & "Nguồn hàng" & " " & lw_failed
                                ShowStatusMessage(True, "", lw_mess(2), 7)
                                BackgroundWorker1_DoWork = True
                                p_DataExec.Clear()
                                Cursor = Cursors.Default
                                Exit Function
                                ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
                            End If

                        End If
                        lw_mess(2) = lw_str & " " & "Nguồn hàng" & " " & lw_ok
                        ShowStatusMessage(False, "", lw_mess(2), 7)
                        p_DataExec.Clear()
                        p_SyncMaster.clsCapNhatLog("NguonHang", 0)
                    Else
                        ShowStatusMessage(False, "", lw_mess(2), 7)
                        p_DataExec.Clear()
                        'p_SyncMaster.clsCapNhatLog("NguonHang", 0)
                    End If
                End If

                'Chọn đồng bộ hàng hóa  ==========================================================================
                If flag(3) = 1 Then
                    l_date = p_SyncMaster.clsGetDateLog("HangHoa")  ' CDate(p_Date).ToString("yyyy.MM.dd")

                    If p_SyncMaster.ClsSyncMaster_SyncMaterial(p_DataExec, isGetAll, l_date, p_Desc) Then
                        lw_mess(3) = lw_str & " " & "Hàng hóa" & " " & lw_ok

                        If g_WCF = True Then
                            p_SyncMaster.clsCapNhatLog("HangHoa", 0)
                        End If


                    Else
                        lw_mess(3) = p_Desc   ' lw_str & " " & "Hàng hóa" & " " & lw_failed

                        ShowStatusMessage(True, "", lw_mess(0), 7)
                        BackgroundWorker1_DoWork = True
                        p_DataExec.Clear()
                        Cursor = Cursors.Default
                        Exit Function

                    End If
                    If g_WCF = False Then
                        If p_DataExec.Rows.Count > 0 Then
                            If DataTableRunExecBigData(p_DataExec, p_SQL) = False Then
                                'MsgBox(p_SQL)
                                lw_mess(3) = lw_str & " " & "Hàng hóa" & " " & lw_failed
                                ShowStatusMessage(True, "", lw_mess(3), 7)
                                BackgroundWorker1_DoWork = True
                                p_DataExec.Clear()
                                Cursor = Cursors.Default
                                Exit Function
                                ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
                            End If
                            lw_mess(3) = lw_str & " " & "Hàng hóa" & " " & lw_ok
                            ShowStatusMessage(False, "", lw_mess(3), 7)
                            p_DataExec.Clear()
                            p_SyncMaster.clsCapNhatLog("HangHoa", 0)
                        Else
                            lw_mess(3) = lw_str & " " & "Hàng hóa" & " " & lw_ok
                            ShowStatusMessage(False, "", lw_mess(3), 7)
                            p_DataExec.Clear()

                        End If
                    Else
                        ShowStatusMessage(False, "", lw_mess(3), 7)
                        p_DataExec.Clear()
                        ' p_SyncMaster.clsCapNhatLog("HangHoa", 0)
                    End If

                End If

                'Chọn đồng bộ phương tiện================================================
        If flag(4) = 1 Then
            Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
            Dim p_Table As DataTable
            Dim p_ConnectSapString, p_TimeOut As String
            Dim p_TableLine, p_TableHeader As DataTable
            p_SQL = "select * from tblConfig "
            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    p_ConnectSapString = p_Table.Rows(0).Item("SapConnectionString").ToString.Trim
                    Try
                        p_TimeOut = p_Table.Rows(0).Item("Timeout").ToString.Trim
                    Catch ex As Exception
                    End Try

                    If p_TimeOut = "" Then
                        p_TimeOut = "60"
                    End If
                End If
            End If
            If isGetAll = "H" Then
                l_date = p_SyncMaster.clsGetDateLog("PhuongTien")
                l_date = Replace(l_date, ".", "")
            Else
                l_date = "19890101"
            End If
            'l_date = p_SyncMaster.clsGetDateLog("PhuongTien")  '   CDate(p_Date).ToString("yyyy.MM.dd")

            'l_date = p_SyncMaster.clsGetDateLog("PhuongTien")

            p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)

            If p_ECCDestinationConfig.clsSyncVEHICLE(l_date, "", p_Desc, p_TableLine, p_TableHeader, isGetAll) = True Then

                'p_SQL = "delete from tblChiTietPhuongTien"
                'If g_Services.Sys_Execute(p_SQL, _
                '                 p_SQL) = False Then
                '    ShowMessageBox("", p_SQL)
                'End If


                
                p_SQL = ""
                If DataTableRunExecBigData(p_TableHeader, p_SQL) = False Then

                End If


                p_SQL = ""
                If DataTableRunExecBigData(p_TableLine, p_SQL) = False Then

                End If
                p_SQL = "update tblPhuongTien set SoNgan = 	(select Count(1) from tblChiTietPhuongTien  kk where kk.MaPhuongTien =tblPhuongTien.MaPhuongTien and isnull(MaNgan,'') <> ''  ) "
                If g_Services.Sys_Execute(p_SQL, _
                                 p_SQL) = False Then
                    ShowMessageBox("", p_SQL)
                End If



                lw_mess(4) = lw_str & " " & "Phương tiện" & " " & lw_ok
                p_SyncMaster.clsCapNhatLog("PhuongTien", 0)

                ShowStatusMessage(False, "", lw_mess(4), 7)
                Exit Function
                ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
                'End If

            Else
                lw_mess(4) = lw_str & " " & "Phương tiện: " & " " & p_Desc
                ShowStatusMessage(False, "", lw_mess(4), 7)
            End If


        End If

        'Chọn đồng bộ phương thức
        If flag(5) = 1 Then
            If p_SyncMaster.ClsSynPhuongThuc(p_DataExec, isGetAll, p_Desc) Then
                lw_mess(5) = lw_str & " " & "Phương thức" & " " & lw_ok


                If g_WCF = True Then
                    p_SyncMaster.clsCapNhatLog("PhuongThuc", 0)
                End If



            Else
                lw_mess(5) = p_Desc ''' lw_str & " " & "Phương thức" & " " & lw_failed
                ShowStatusMessage(False, "", lw_mess(5), 7)
                BackgroundWorker1_DoWork = True
                p_DataExec.Clear()
                Cursor = Cursors.Default
                Exit Function
            End If
            If g_WCF = False Then
                If p_DataExec.Rows.Count > 0 Then
                    If DataTableRunExecBigData(p_DataExec, p_SQL) = False Then
                        'MsgBox(p_SQL)
                        lw_mess(5) = lw_str & " " & "Phương thức" & " " & lw_failed
                        ShowStatusMessage(True, "", lw_mess(5), 7)
                        BackgroundWorker1_DoWork = True
                        p_DataExec.Clear()
                        Cursor = Cursors.Default
                        Exit Function
                        ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
                    End If

                End If
                lw_mess(5) = lw_str & " " & "Phương thức" & " " & lw_ok
                ShowStatusMessage(False, "", lw_mess(5), 7)
                p_DataExec.Clear()
                p_SyncMaster.clsCapNhatLog("PhuongThuc", 0)
            Else
                ShowStatusMessage(False, "", lw_mess(5), 7)
                p_DataExec.Clear()
                ' p_SyncMaster.clsCapNhatLog("PhuongThuc", 0)
            End If
        End If

        'Chọn đồng bộ Đơn vị tính
        If flag(6) = 1 Then
            l_date = CDate(p_Date).ToString("yyyy.MM.dd")
            If p_SyncMaster.ClsSynDonViTinh(p_DataExec, isGetAll, p_Desc) Then
                lw_mess(6) = lw_str & " " & "Đơn vị tính" & " " & lw_ok

                If g_WCF = True Then
                    p_SyncMaster.clsCapNhatLog("DonViTinh", 0)
                End If


            Else
                lw_mess(6) = p_Desc  ' lw_str & " " & "Đơn vị tính" & " " & lw_failed

                ShowStatusMessage(True, "", lw_mess(6), 7)
                BackgroundWorker1_DoWork = True
                p_DataExec.Clear()
                Cursor = Cursors.Default
                Exit Function


            End If
            If g_WCF = False Then
                If p_DataExec.Rows.Count > 0 Then
                    If DataTableRunExecBigData(p_DataExec, p_SQL) = False Then
                        'MsgBox(p_SQL)
                        lw_mess(6) = lw_str & " " & "Đơn vị tính" & " " & lw_failed
                        ShowStatusMessage(True, "", lw_mess(6), 7)
                        BackgroundWorker1_DoWork = True
                        p_DataExec.Clear()
                        Cursor = Cursors.Default
                        Exit Function
                        ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
                    End If

                End If
                lw_mess(6) = lw_str & " " & "Đơn vị tính" & " " & lw_ok
                ShowStatusMessage(False, "", lw_mess(6), 7)
                p_DataExec.Clear()
                p_SyncMaster.clsCapNhatLog("DonViTinh", 0)
            Else
                ShowStatusMessage(False, "", lw_mess(6), 7)
                p_DataExec.Clear()
                'p_SyncMaster.clsCapNhatLog("DonViTinh", 0)
            End If
        End If


        'Chọn đồng bộ Công tơ
        'If flag(7) = 1 Then
        '    l_date = g_dt.Rows(7).Item("SynDate").ToString()
        '    If mdlSyncMaster_SyncMeter(_SapConnectionString, _SQLConnectionString, isGetAll, l_date, _WareHouse) Then
        '        lw_mess(7) = lw_str & " " & "Công tơ" & " " & lw_ok
        '    Else
        '        lw_mess(7) = lw_str & " " & "Công tơ" & " " & lw_failed
        '    End If

        'End If

        'Chọn đồng bộ Bể xuất
        If flag(8) = 1 Then

            Get_TankMapSAP_Infor(g_Company_Code, p_Desc)

            l_date = p_SyncMaster.clsGetDateLog("BeXuat")  '      CDate(p_Date).ToString("yyyy.MM.dd")
            If p_SyncMaster.ClsSyncMaster_SyncTank(p_DataExec, isGetAll, l_date, _WareHouse, p_Desc) Then
                lw_mess(8) = lw_str & " " & "Bể xuất" & " " & lw_ok


                If g_WCF = True Then
                    p_SyncMaster.clsCapNhatLog("BeXuat", 0)
                End If


            Else
                lw_mess(8) = p_Desc  ' lw_str & " " & "Bể xuất" & " " & lw_failed
                ShowStatusMessage(True, "", lw_mess(8), 7)
                BackgroundWorker1_DoWork = True
                p_DataExec.Clear()
                Cursor = Cursors.Default
                Exit Function
            End If
            If g_WCF = False Then
                If p_DataExec.Rows.Count > 0 Then
                    If DataTableRunExecBigData(p_DataExec, p_SQL) = False Then
                        'MsgBox(p_SQL)
                        lw_mess(8) = lw_str & " " & "Bể xuất" & " " & lw_failed
                        ShowStatusMessage(True, "", lw_mess(8), 7)
                        BackgroundWorker1_DoWork = True
                        p_DataExec.Clear()
                        Cursor = Cursors.Default
                        Exit Function
                        ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
                    Else
                        p_SQL = "update  dbo.zTankListATG set Product= (select top 1 Product_nd from tbltank h " & _
                         " where h.Name_nd=zTankListATG.tankCode )  "
                        If g_Services.Sys_Execute(p_SQL, _
                                                  p_SQL) = False Then
                            'ShowMessageBox("", p_SQLErr)
                        End If
                    End If


                    'p_SQL = "update [dbo].[tblTank]  set Name_nd =(select  TankHTTG from [tblTankMapSAP] h1 " & _
                    '    " where h1.TankSAP =  [tblTank].Map_Sap1)   where  " & _
                    '    "   exists (select 1  from [tblTankMapSAP] h2 where h2.TankSAP = [tblTank].Map_Sap1) "

                    'If g_Services.Sys_Execute(p_SQL, _
                    '                              p_SQL) = False Then
                    '    'ShowMessageBox("", p_SQLErr)
                    'End If
                End If
                lw_mess(8) = lw_str & " " & "Bể xuất" & " " & lw_ok
                ShowStatusMessage(False, "", lw_mess(8), 7)
                p_DataExec.Clear()
                p_SyncMaster.clsCapNhatLog("BeXuat", 0)
            Else
                ShowStatusMessage(False, "", lw_mess(8), 7)
                p_DataExec.Clear()
                ' p_SyncMaster.clsCapNhatLog("BeXuat", 0)
            End If
        End If




        'Chọn đồng bộ Hợp đồng
        If flag(15) = 1 Then
            l_date = p_SyncMaster.clsGetDateLog("HopDong")
            ' l_date = CDate(p_Date).ToString("yyyy.MM.dd")

            Dim p_Count As Integer
            Dim p_CompanyCode As String = ""
            p_SQL = "select MaDonVi from tblDonVi  where MaDonVi like '" & Strings.Left(g_Company_Code, 2) & "%' order by MaDonVi"
            p_Datatable = GetDataTable(p_SQL, p_SQL)

            l_date = Replace(l_date, ".", "-")
            If Not p_Datatable Is Nothing Then
                For p_Count = 0 To p_Datatable.Rows.Count - 1
                    p_CompanyCode = p_Datatable.Rows(p_Count).Item(0).ToString.Trim
                    p_SQL = ""
                    THN_HopDong_Infor(p_SyncMaster, p_CompanyCode, l_date, p_SQL, isGetAll)

                Next

                p_SyncMaster.clsCapNhatLog("HopDong", 0)
                p_SyncMaster.clsHistStringSyn("HopDong", False)

                lw_mess(15) = lw_str & " " & "Danh sách hợp đồng" & " " & lw_ok
                ShowStatusMessage(False, "", lw_mess(15), 7)

                p_SyncMaster.clsCapNhatLog("HopDong", 0)

            End If
            'If p_SyncMaster.clsSynHopDong(g_Company_Code, p_DataExec, isGetAll, l_date, p_Desc) Then
            '    lw_mess(15) = lw_str & " " & "Danh sách hợp đồng" & " " & lw_ok

            '    If g_WCF = True Then
            '        p_SyncMaster.clsCapNhatLog("HopDong", 0)
            '    End If


            'Else
            '    lw_mess(15) = p_Desc  ' lw_str & " " & "Danh sách hợp đồng" & " " & lw_failed
            '    ShowStatusMessage(True, "", lw_mess(15), 7)
            '    BackgroundWorker1_DoWork = True
            '    p_DataExec.Clear()
            '    Cursor = Cursors.Default
            '    Exit Function
            'End If
            'If g_WCF = False Then
            '    If p_DataExec.Rows.Count > 0 Then
            '        If DataTableRunExecBigData(p_DataExec, p_SQL) = False Then
            '            'MsgBox(p_SQL)
            '            lw_mess(15) = lw_str & " " & "Danh sách hợp đồng" & " " & lw_failed
            '            ShowStatusMessage(True, "", lw_mess(15), 7)
            '            BackgroundWorker1_DoWork = True
            '            p_DataExec.Clear()
            '            Cursor = Cursors.Default
            '            Exit Function
            '            ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
            '        End If

            '    End If
            '    lw_mess(15) = lw_str & " " & "Danh sách hợp đồng" & " " & lw_ok
            '    ShowStatusMessage(False, "", lw_mess(15), 7)
            '    p_DataExec.Clear()
            '    p_SyncMaster.clsCapNhatLog("HopDong", 0)
            'Else
            '    ShowStatusMessage(False, "", lw_mess(15), 7)
            '    p_DataExec.Clear()
            '    'p_SyncMaster.clsCapNhatLog("DonViTinh", 0)
            'End If
        End If

        p_SQL = ""
        If Me.HoaDon.Checked = True Then
            p_SQL = ""
            THN_Hoa_Infor(p_SQL)
            If p_SQL <> "" Then
                ShowStatusMessage(False, "", p_SQL, 7)
            Else

                ShowStatusMessage(False, "", "Đồng bộ thành công", 7)
            End If
        End If

        p_SQL = ""
        If Me.CongTy.Checked = True Then
            p_SQL = ""
            THN_CongTy_Infor(p_SQL)
            If p_SQL <> "" Then
                ShowStatusMessage(False, "", p_SQL, 7)
            Else

                ShowStatusMessage(False, "", "Đồng bộ thành công", 7)
            End If
        End If

        If Me.chkKho.Checked = True Then
            p_SQL = ""
            THN_Kho_Infor(p_SQL)
            If p_SQL <> "" Then
                ShowStatusMessage(False, "", p_SQL, 7)
            Else

                ShowStatusMessage(False, "", "Đồng bộ thành công", 7)
            End If
        End If

        If Me.STO.Checked = True Then
            p_SQL = ""
            THN_STO_Infor(p_SQL)
            If p_SQL <> "" Then
                ShowStatusMessage(False, "", p_SQL, 7)
            Else

                ShowStatusMessage(False, "", "Đồng bộ thành công", 7)
            End If
        End If

        If Me.chkNhaCungCap.Checked = True Then
            p_SQL = ""
            THN_NhaCungCap_Infor(p_SQL)
            If p_SQL <> "" Then
                ShowStatusMessage(False, "", p_SQL, 7)
            Else

                ShowStatusMessage(False, "", "Đồng bộ thành công", 7)
            End If
        End If

        If Me.ToKhai.Checked = True Then
            p_SQL = ""
            l_date = p_SyncMaster.clsGetDateLog("ToKhai")
            ToKhaiTaiXuat_Infor(l_date, p_SQL)
            If p_SQL <> "" Then
                ShowStatusMessage(False, "", p_SQL, 7)
            Else

                ShowStatusMessage(False, "", "Đồng bộ thành công", 7)
            End If
        End If


        If Me.SO_PO_Type.Checked = True Then
            p_SQL = ""
            THN_SO_PO_Type_Infor(p_SQL)
            If p_SQL <> "" Then
                ShowStatusMessage(False, "", p_SQL, 7)
            Else

                ShowStatusMessage(False, "", "Đồng bộ thành công", 7)
            End If
        End If

        Cursor = Cursors.Default
    End Function


#Region "Checked Changed"
    Private Sub chkKhachHang_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkKhachHang.CheckedChanged
        If chkKhachHang.Checked Then
            flag(0) = 1
        Else
            flag(0) = 0
        End If
    End Sub

    Private Sub chkVanChuyen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVanChuyen.CheckedChanged
        If chkVanChuyen.Checked Then
            flag(1) = 1
        Else
            flag(1) = 0
        End If
    End Sub

    Private Sub chkNguonHang_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNguonHang.CheckedChanged
        If chkNguonHang.Checked Then
            flag(2) = 1
        Else
            flag(2) = 0
        End If
    End Sub

    Private Sub chkHangHoa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHangHoa.CheckedChanged
        If chkHangHoa.Checked Then
            flag(3) = 1
        Else
            flag(3) = 0
        End If
    End Sub

    Private Sub chkPhuongTien_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPhuongTien.CheckedChanged
        If chkPhuongTien.Checked Then
            flag(4) = 1
        Else
            flag(4) = 0
        End If
    End Sub

    Private Sub chkPhuongThuc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPhuongThuc.CheckedChanged
        If chkPhuongThuc.Checked Then
            flag(5) = 1
        Else
            flag(5) = 0
        End If
    End Sub

    Private Sub chkDonViTinh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDonViTinh.CheckedChanged
        If chkDonViTinh.Checked Then
            flag(6) = 1
        Else
            flag(6) = 0
        End If
    End Sub


    Private Sub chkCongTo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCongTo.CheckedChanged
        If chkCongTo.Checked Then
            flag(7) = 1
        Else
            flag(7) = 0
        End If
    End Sub

    Private Sub chkBexuat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBeXuat.CheckedChanged
        If chkBeXuat.Checked Then
            flag(8) = 1
        Else
            flag(8) = 0
        End If
    End Sub
#End Region

    Private Sub chkNhaCungCap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNhaCungCap.CheckedChanged
        If chkNhaCungCap.Checked Then
            flag(9) = 1
        Else
            flag(9) = 0
        End If
    End Sub

    Private Sub chkTuyenDuong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTuyenDuong.CheckedChanged
        If chkTuyenDuong.Checked Then
            flag(10) = 1
        Else
            flag(10) = 0
        End If
    End Sub

    Private Sub chkGiaoNhan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkGiaoNhan.CheckedChanged
        If chkGiaoNhan.Checked Then
            flag(11) = 1
        Else
            flag(11) = 0
        End If
    End Sub

    Private Sub chkThoiHanThanhToan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkThoiHanThanhToan.CheckedChanged
        If chkThoiHanThanhToan.Checked Then
            flag(12) = 1
        Else
            flag(12) = 0
        End If
    End Sub

    Private Sub chkDonGia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDonGia.CheckedChanged
        If chkDonGia.Checked Then
            flag(13) = 1
        Else
            flag(13) = 0
        End If
    End Sub

    Private Sub chkKho_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkKho.CheckedChanged
        If chkKho.Checked Then
            flag(14) = 1
        Else
            flag(14) = 0
        End If
    End Sub

    Private Sub Project_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Project.CheckedChanged
        If Project.Checked Then
            flag(15) = 1
        Else
            flag(15) = 0
        End If
    End Sub

    Private Sub ToKhai_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToKhai.CheckedChanged

    End Sub

    Private Sub STO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STO.CheckedChanged

    End Sub

    Private Sub rAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rAll.CheckedChanged

    End Sub
End Class