Module Module2
    Public Constant_P_Bo = "Bo"
    Public Constant_P_Thuy = "Thuy"
    Public Constant_P_eBo = "eBo"
    Public Constant_P_eThuy = "eThuy"
    Public Constant_P_HeSoCongTo = "HeSoCongTo"
    Public Constant_P_eTimeStop = "eTimeStop"
    Public Constant_P_eTimeFlagBo = "eTimeFlagBo"
    Public Constant_P_eTimeFlagThuy = "eTimeFlagThuy"
    Public Constant_P_eTimeDefault = "eTimeDefault"
    Public Constant_P_eMapMaHangHoa = "eMapMaHangHoa"
    Public Constant_P_CheckMetter = "CheckMetter"
    Public Constant_P_MaTuDongHoa = "MaTuDongHoa"
    Public Constant_P_Sat = "Sat"
    Public Constant_P_upThucXuat = "upThucXuat"
    Public Constant_P_eSat = "eSat"
    Public Constant_P_MeterDens = "MeterDens"
    Public Constant_P_FO = "FO"
    Public Constant_P_Password = "Password"
    Public g_Client_E5_Upper As String = ""
    Public g_Client_E5 As String = ""
    Dim i_dt_para As New DataTable

    Public g_UserName As String = ""

    'anhqh
    '20160810

    Public Sub GetClient_E5(ByVal p_Client As String)
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        

        g_Client_E5_Upper = "E5 XITEC"
        g_Client_E5 = "E5 Xitec"

        p_SQL = "select KEYVALUE from SYS_CONFIG  where KEYCODE='FILTERKHO'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then

                If p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then


                    'anhqh
                    '20170622

                    g_Client_E5_Upper = p_Client & g_Client_E5_Upper
                    g_Client_E5 = p_Client & g_Client_E5

                    'g_Client_E5_Upper = "A" & g_Client_E5_Upper
                    'g_Client_E5 = "A" & g_Client_E5

                End If
            End If
        End If
    End Sub



    Public Sub GetMaVanChuyen(ByVal p_maphuongtien As String, ByVal p_MaVanChuyen As String, ByRef l_mavanchuyen As String)
        Dim p_SQL As String = "select * from tblPara"
        Dim l_mavanchuyen_convert As String

        i_dt_para = GetDataTable(p_SQL, p_SQL)

        l_mavanchuyen = p_MaVanChuyen
        l_mavanchuyen_convert = mdlDelivery_CheckTransmot(l_mavanchuyen, i_dt_para)
        If l_mavanchuyen_convert = "Thuy" Then
            If mdlFunction_GetParaValue(Constant_P_eThuy) = "0" Then
                l_mavanchuyen = p_maphuongtien
            Else
                l_mavanchuyen = mdlFunction_GetParaValue(Constant_P_eThuy)
            End If
        ElseIf l_mavanchuyen_convert = "Bo" Then
            If mdlFunction_GetParaValue(Constant_P_eBo) = "0" Then
                l_mavanchuyen = p_maphuongtien
            Else
                l_mavanchuyen = mdlFunction_GetParaValue(Constant_P_eBo)
            End If
        ElseIf l_mavanchuyen_convert = "Sat" Then
            If mdlFunction_GetParaValue(Constant_P_eSat) = "0" Then
                l_mavanchuyen = p_maphuongtien
            Else
                l_mavanchuyen = mdlFunction_GetParaValue(Constant_P_eSat)
            End If
        End If


    End Sub

    
    Public Function mdlDelivery_CheckTransmot(ByVal i_mavanchuyen As String, ByVal i_dt_para As DataTable) As String
        Dim l_bo, _
            l_thuy, _
            l_sat As String()

        Try
            '----------------------------------------------------------------
            '   Para:
            '       Index 0: Bo
            '       Index 1: Thuy
            '----------------------------------------------------------------
            l_bo = i_dt_para.Rows(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            l_thuy = i_dt_para.Rows(1).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)

            'FES KV2
            '20141014
            '            l_sat = i_dt_para.Rows(12).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)

            For i As Integer = 0 To l_bo.Length - 1
                If l_bo(i).Trim() = i_mavanchuyen.Trim() Then
                    Return "Bo"
                End If
            Next

            For i As Integer = 0 To l_thuy.Length - 1
                If l_thuy(i).Trim() = i_mavanchuyen.Trim() Then
                    Return "Thuy"
                End If
            Next

            For i As Integer = 0 To l_sat.Length - 1
                If l_sat(i).Trim() = i_mavanchuyen.Trim() Then
                    Return "Sat"
                End If
            Next

            Return String.Empty

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function mdlFunction_GetParaValue(ByVal i_paraname As String) As String
        Try
            Dim l_dr As DataRow()
            l_dr = i_dt_para.Select("Para = '" & i_paraname & "'")

            If l_dr.Length > 0 Then
                Return l_dr(0).Item("Value_nd").ToString().Trim()
            End If

            Return String.Empty
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function


    Public Sub GET_HTTG_GET_LX_STAGING_AUTO()
        Dim p_SQL As String
        Dim p_DataExec As DataTable
        Dim p_desc As String = ""
        Dim p_SoLenhTbl As DataTable
        Dim l_ztb As Connect2SapEx.Str_PhieuXuatTable
        Dim p_SapConnectionString As String = ""
        Dim p_WareHouse As String = ""
        Dim p_ShPoint As String = ""
        Dim p_TimeOut As String = "0"
        Dim i_date As String = ""
        Dim i_dateTo As String = Now().ToString("yyyyMMdd")
        Dim p_DataTable As DataTable
        Dim p_Count As Integer
        Dim p_SoLenh As String
        Dim p_Day As Integer = 0
        Dim p_Date_KV1 As Date
        Dim p_TableCheck As DataTable
        Dim p_Error As String = ""
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        'TIMEDAYAUTO


        g_Services = New FPTBUSSINESS.Class1
        g_KV1 = False
        p_SQL = "select keyvalue  from sys_config where upper(Keycode) = 'KV1'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                If p_DataTable.Rows(0).Item("KeyValue").ToString.Trim = "Y" Then
                    g_KV1 = True
                Else
                    g_KV1 = False
                End If
            End If
        End If
        
        p_SQL = "select keyvalue  from sys_config where upper(Keycode) = 'TIMEDAYAUTO'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Integer.TryParse(p_DataTable.Rows(0).Item("keyvalue").ToString.Trim, p_Day)
            End If
        End If
        i_date = DateAdd(DateInterval.Day, -1 * p_Day, Now.Date).ToString("yyyyMMdd")
        l_ztb = New Connect2SapEx.Str_PhieuXuatTable


        p_SQL = "select *,  getdate() as CurrentDate from tblconfig"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                p_SapConnectionString = p_DataTable.Rows(0).Item("SapConnectionString").ToString.Trim
                Try
                    p_TimeOut = p_DataTable.Rows(0).Item("Timeout").ToString.Trim
                Catch ex As Exception

                End Try
                If p_TimeOut = "" Then
                    p_TimeOut = "60"
                End If

                g_Company_Code = p_DataTable.Rows(0).Item("companycode").ToString.Trim
                p_Date_KV1 = CDate(p_DataTable.Rows(0).Item("CurrentDate"))
            End If
        End If


        'Dim p_SAP_Object As New THN_SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

        mdlSyncDeliveries_DoListAuto(l_ztb, p_SapConnectionString, i_date, i_dateTo, _
                                              p_ShPoint, p_TimeOut, p_SoLenhTbl, _
                                              p_desc)


        'End If

        p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_SapConnectionString, "EN", p_TimeOut, g_Company_Code)

        If Not p_SoLenhTbl Is Nothing Then
            For p_Count = 0 To p_SoLenhTbl.Rows.Count - 1

                p_SoLenh = p_SoLenhTbl.Rows(p_Count).Item("Order_No").ToString
                ''''Kiem tra lenh ton tai chua
                p_SQL = "select soLenh from [dbo].[tblLenhXuatE5] with (nolock) where soLenh = '" & p_SoLenh & "' " & _
                    "union all select soLenh from [dbo].[tblLenhXuatE5_THN] with (nolock)  where soLenh = '" & p_SoLenh & "'"
                p_TableCheck = GetDataTable(p_SQL, p_SQL)
                If Not p_TableCheck Is Nothing Then
                    If p_TableCheck.Rows.Count > 0 Then
                        Continue For
                    End If
                End If
                p_Error = ""
                If g_KV1 = True Then
                    If KV1mdlSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_SoLenh, p_Error, p_Date_KV1, "Y") = False Then

                        p_SQL = "MERGE INTO tblLenhXuatE5_THN_HIST   AS target " & _
                            " USING (select  '" & p_SoLenh & "' as SOLenh, N'" & p_Error & "' as sDesc , 'N' as STATUS ) AS source " & _
                               " ON target.SoLenh = source.SoLenh " & _
                            " WHEN MATCHED THEN  " & _
                               " UPDATE SET target.sDesc = source.sDesc,STATUS = source.STATUS, CreateDate =getdate()  " & _
                            " WHEN NOT MATCHED BY TARGET THEN " & _
                                    " INSERT(SoLenh, sDesc, STATUS) " & _
                                " VALUES (source.SoLenh, source.sDesc, source.STATUS);"
                    Else
                        p_SQL = "MERGE INTO tblLenhXuatE5_THN_HIST   AS target " & _
                            " USING (select  '" & p_SoLenh & "' as SOLenh, N'" & p_Error & "' as sDesc , 'Y' as STATUS ) AS source " & _
                               " ON target.SoLenh = source.SoLenh " & _
                            " WHEN MATCHED THEN  " & _
                               " UPDATE SET target.sDesc = source.sDesc ,STATUS = source.STATUS, CreateDate =getdate()  " & _
                            " WHEN NOT MATCHED BY TARGET THEN " & _
                                    " INSERT(SoLenh, sDesc, STATUS ) " & _
                                " VALUES (source.SoLenh, source.sDesc, source.STATUS);"
                    End If
                Else
                    If mdlSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_SoLenh, p_Error, p_Date_KV1) = False Then
                        p_SQL = "MERGE INTO tblLenhXuatE5_THN_HIST   AS target " & _
                           " USING (select  '" & p_SoLenh & "' as SOLenh, N'" & p_Error & "' as sDesc , 'N' as STATUS ) AS source " & _
                              " ON target.SoLenh = source.SoLenh " & _
                           " WHEN MATCHED THEN  " & _
                              " UPDATE SET target.sDesc = source.sDesc,STATUS = source.STATUS , CreateDate =getdate() " & _
                           " WHEN NOT MATCHED BY TARGET THEN " & _
                                   " INSERT(SoLenh, sDesc, STATUS) " & _
                               " VALUES (source.SoLenh, source.sDesc, source.STATUS);"
                    Else
                        p_SQL = "MERGE INTO tblLenhXuatE5_THN_HIST   AS target " & _
                            " USING (select  '" & p_SoLenh & "' as SOLenh, N'" & p_Error & "' as sDesc , 'Y' as STATUS ) AS source " & _
                               " ON target.SoLenh = source.SoLenh " & _
                            " WHEN MATCHED THEN  " & _
                               " UPDATE SET target.sDesc = source.sDesc ,STATUS = source.STATUS, CreateDate =getdate()  " & _
                            " WHEN NOT MATCHED BY TARGET THEN " & _
                                    " INSERT(SoLenh, sDesc, STATUS ) " & _
                                " VALUES (source.SoLenh, source.sDesc, source.STATUS);"
                    End If
                End If

                
                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                End If


            Next
        End If




    End Sub

    Public Sub GetLenhXuat(ByVal l_solenh As String, ByVal l_ngayxuat As Date, ByRef p_desc As String)
        Dim l_malenh As String
        Dim p_SQL As String
        Dim p_Dem As Integer = 0
        Dim p_TableCheck As DataTable
        Dim p_Count As Integer
        Dim p_Table As DataTable
        Dim p_TableID As String
        Dim l_mahanghoa As String
        Dim p_Transmot As String
        Dim p_DataSet As DataSet
        Dim p_Row As DataRow
        'p_FunctionTableId
        Dim p_DataRowArr() As DataRow
        Dim p_TableConfig, p_TableConfig1, p_TableExe As DataTable

        p_TableExe = New DataTable("TableExe")
        p_TableExe.Columns.Add("STRSQL")
        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG; select * from tblConfig;"
        p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

        g_KV1 = False

        'g_User_ID = p_User_ID


        g_BATCHSLOG = False

        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_TableConfig = p_DataSet.Tables(0)
                p_TableConfig1 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_DataRowArr = p_TableConfig.Select("KEYCODE='TABLEID'")
                If p_DataRowArr.Length > 0 Then
                    p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='QUYDOI_SAP'")
                If p_DataRowArr.Length > 0 Then
                    p_QUYDOI_SAP = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KV1'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_KV1 = True
                    Else
                        g_KV1 = False
                    End If
                End If


                p_ThamSoNgay = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='THAMSONGAY'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_ThamSoNgay = True
                    Else
                        p_ThamSoNgay = False
                    End If
                End If



                p_DataRowArr = p_TableConfig.Select("KEYCODE='BATCHSLOG'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_BATCHSLOG = True
                    Else
                        g_BATCHSLOG = False
                    End If
                End If

                'MATUDONGHOA_PROD
                'anhqh
                '20161115
                p_DataRowArr = p_TableConfig.Select("KEYCODE='MATUDONGHOA_PROD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        p_MATUDONGHOA_PROD = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                    End If
                End If


                'anhqh
                '20170414
                'Tham so kiem tra han muc
                p_KiemTraHanMuc = True

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KIEMTRAHANMUC'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_KiemTraHanMuc = False
                    End If
                End If

                'anhqh
                '20170419
                'Tham so kiem tra TD co duoc gan tren SAP khoong
                p_KIEMTRA_TD = True
                p_DataRowArr = p_TableConfig.Select("KEYCODE='KIEMTRA_TD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_KIEMTRA_TD = False
                    End If
                End If


                'CONGTO_BEXUAT
                p_CONGTO_BEXUAT = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='CONGTO_BEXUAT'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_CONGTO_BEXUAT = True
                    End If
                End If


                p_KiemTraDiChuyen_TD = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='KT_DICHUYEN_TD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_KiemTraDiChuyen_TD = True
                    End If
                End If

            End If
        End If



        p_SQL = "select sDesc from [tblLenhXuatE5_THN_HIST] b where  b.SoLenh ='" & l_solenh & "' and isnull(Status,'N') ='N'"
        p_TableCheck = GetDataTable(p_SQL, p_SQL)
        If Not p_TableCheck Is Nothing Then
            If p_TableCheck.Rows.Count > 0 Then
                p_desc = p_TableCheck.Rows(0).Item("sDesc").ToString
                Exit Sub
            End If
        End If

        'Kiểm tra hiệu lực của lệnh xuất
        p_SQL = "select SoLenh from [dbo].[tblLenhXuatE5_THN]  a where exists (select 1 from [tblLenhXuatE5_THN_HIST] b where a.SoLenh = b.SoLenh and isnull(Status,'N') ='Y')" & _
          " and  convert(date,'" & l_ngayxuat.ToString("yyyyMMdd") & "') >= convert(date,NgayHieuLuc)  and  convert(date, '" & l_ngayxuat.ToString("yyyyMMdd") & "') <=   convert(date,NgayHetHieuLuc) "
        p_TableCheck = GetDataTable(p_SQL, p_SQL)
        If Not p_TableCheck Is Nothing Then
            If p_TableCheck.Rows.Count > 0 Then
TaoMaLenh:

                If g_KV1 = True Then
                    l_malenh = KV1_FPT_GetMaLenh(l_solenh, l_ngayxuat)
                Else
                    l_malenh = FPT_GetMaLenh(l_solenh)
                End If

                'anhqh
                '20160715
                'Sua lai nếu trùng mã lệnh  thì xóa trong bảng SYS_MALENH_S roi tạo lai
                If Not mdlSyncDeliveries_CheckMaLenh(l_malenh, l_ngayxuat) Then

                    If p_Dem >= 3 Then
                        p_desc = "Trùng Mã Lệnh=" & l_malenh
                        Exit Sub
                    End If


                    p_SQL = ""

                    p_SQL = "delete  from SYS_MALENH_S where  SoLenh='" & l_solenh & "'"

                    If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                    End If

                    p_Dem = p_Dem + 1

                    GoTo taomalenh
                End If


                'Cap nhat Ngày xuất và MaLenh
                p_SQL = "update  tblLenhXuatE5_THN  set NgayXuat = '" & l_ngayxuat.ToString("yyyyMMdd") & "'  , MaLenh ='" & l_malenh & "'  where SoLenh ='" & l_solenh & "'"
                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                End If
                p_SQL = "update  tblLenhXuat_HangHoaE5_THN  set NgayXuat = '" & l_ngayxuat.ToString("yyyyMMdd") & "'  , MaLenh ='" & l_malenh & "'  where SoLenh ='" & l_solenh & "'"
                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                End If
                p_SQL = "update  tblLenhXuatChiTietE5_THN  set NgayXuat = '" & l_ngayxuat.ToString("yyyyMMdd") & "'  , MaLenh ='" & l_malenh & "'  where SoLenhLine ='" & l_solenh & "'"
                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                End If

                'Cập nhật Tableid cho bảng hàng hóa
                p_SQL = "select a1.SoLenh, a1.MaVanChuyen , a2.MaHangHoa, a2.LineID  from [tblLenhXuatE5_THN] a1 with (nolock), [tblLenhXuat_HangHoaE5_THN] a2 with (nolock) " & _
                     " where a1.SoLenh  =a2.SoLenh  and a1.SoLenh ='" & l_solenh & "'"
                p_Table = GetDataTable(p_SQL, p_SQL)
                If Not p_Table Is Nothing Then
                    For p_Count = 0 To p_Table.Rows.Count - 1

                        p_TableID = ""
                        p_Transmot = p_Table.Rows(p_Count).Item("MaVanChuyen").ToString.Trim
                        l_mahanghoa = p_Table.Rows(p_Count).Item("MaHangHoa").ToString.Trim
                        If g_KV1 = True Then
                            p_TableID = GetTableIDKV1(p_Transmot, l_ngayxuat, l_mahanghoa)
                        Else
                            p_TableID = GetTableID()
                        End If
                        p_SQL = "update  tblLenhXuat_HangHoaE5_THN set tableid = '" & p_TableID & "'  where  solenh ='" & l_solenh & "'  and LineID ='" & p_Table.Rows(p_Count).Item("LineID").ToString.Trim & "' "
                        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                        End If

                        p_SQL = "update  tblLenhXuatChiTietE5_THN set tableid = '" & p_TableID & "'  where  solenhLine ='" & l_solenh & "'  and LineID ='" & p_Table.Rows(p_Count).Item("LineID").ToString.Trim & "' "
                        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                        End If

                    Next
                End If

                p_SQL = "INSERT INTO [dbo].[tblLenhXuatE5]([MaLenh],[NgayXuat],[SoLenh],[MaDonVi],[MaNguon],[MaKho],[MaVanChuyen] " & _
                           ",[MaPhuongTien],[NguoiVanChuyen],[MaPhuongThucBan],[MaPhuongThucXuat],[MaKhachHang],[LoaiPhieu] " & _
                           ",[Niem],[LuongGiamDinh] ,[NhietDoTaiTau],[GhiChu],[NgayHieuLuc],[Status],[Number],[Createby] " & _
                           ",[UpdatedBy],[CreateDate],[UpdateDate],[SoLenhSAP],[Client],[HTTG],[Approved] ,[User_Approve],[Date_Approve] " & _
                           ",[EditApprove],[NhaCungCap],[AppDesc],[AppN30],[AppN30Date],[AppN30User],[QCI_KG],[QCI_NhietDo] " & _
                           ",[Slog],[NgayHetHieuLuc],[NgayTichKe],[STO],[NguoiDaiDien],[DonViCungCapVanTai],[UserTichKe] " & _
                           ",[DiemTraHang],[Tax],[PaymentMethod],[Term],[MaKhoNhap],[SoHopDong],[NgayHopDong],[TyGia] " & _
                           ",[SoTKHQNhap],[SoTKHQXuat],[SelfShipping],[PriceGroup],[Inco1],[Inco2],[SoPXK],[NgayPXK] " & _
                           ",[MaTuyenDuong],[XuatHangGui],[So_TKTN],[So_TKTX],[Ngay_TKTX],[PTXuat_ID],[DischargePoint] " & _
                           ",[DesDischargePoint],[BSART],[BWART],[VTWEG],[TenKhoNhap],[Xitec_Option],[SoLenhGoc],[Dem],[PTIEN] " & _
                           ",[SCHUYEN],[NgayVaoKho],[SMO_ID],[CardNum] ,[CardData],[MaTraCuu],[TongSoNiem],[SoBienBanMau] " & _
                           ",[DO1_SoLenh],[DO1_MaKhach],[SoBienBan],[NgayLapBienBan],[SOType],[PrcingDate],[POType],[FromSoLenh] " & _
                           ",[PriceGroupDO1],[LXLoai],[LXPhieu],[SO_POType],[Prcing],[DOCT],[HDChuyen],[BatchNum],[DO1_MaNguon] " & _
                           ",[CrSysDate],[PriceSynDate],[NOTE_LX],[SO_CHUYEN],[LOAI_KH],[NOTE_SMO],[NhomBeXuat] " & _
                           ",[NhomBeAPP],[NhomBeAPPU],[NhomBeAPPD],[ThongTinTDH],[trangthai],[TK_SynDate],[R_KWMENG2]) " & _
                     "SELECT    [MaLenh],[NgayXuat],[SoLenh],[MaDonVi],[MaNguon],[MaKho],[MaVanChuyen] " & _
                           ",[MaPhuongTien],[NguoiVanChuyen],[MaPhuongThucBan],[MaPhuongThucXuat],[MaKhachHang],[LoaiPhieu] " & _
                           ",[Niem],[LuongGiamDinh] ,[NhietDoTaiTau],[GhiChu],[NgayHieuLuc],[Status],[Number]," & g_User_ID & " as [Createby] " & _
                           "," & g_User_ID & " as  [UpdatedBy], getdate() as [CreateDate], getdate() as [UpdateDate],[SoLenhSAP],[Client],[HTTG],[Approved] ,[User_Approve],[Date_Approve] " & _
                           ",[EditApprove],[NhaCungCap],[AppDesc],[AppN30],[AppN30Date],[AppN30User],[QCI_KG],[QCI_NhietDo] " & _
                           ",[Slog],[NgayHetHieuLuc],[NgayTichKe],[STO],[NguoiDaiDien],[DonViCungCapVanTai],[UserTichKe] " & _
                           ",[DiemTraHang],[Tax],[PaymentMethod],[Term],[MaKhoNhap],[SoHopDong],[NgayHopDong],[TyGia] " & _
                           ",[SoTKHQNhap],[SoTKHQXuat],[SelfShipping],[PriceGroup],[Inco1],[Inco2],[SoPXK],[NgayPXK] " & _
                           ",[MaTuyenDuong],[XuatHangGui],[So_TKTN],[So_TKTX],[Ngay_TKTX],[PTXuat_ID],[DischargePoint] " & _
                           ",[DesDischargePoint],[BSART],[BWART],[VTWEG],[TenKhoNhap],[Xitec_Option],[SoLenhGoc],[Dem],[PTIEN] " & _
                           ",[SCHUYEN],[NgayVaoKho],[SMO_ID],[CardNum] ,[CardData],[MaTraCuu],[TongSoNiem],[SoBienBanMau] " & _
                           ",[DO1_SoLenh],[DO1_MaKhach],[SoBienBan],[NgayLapBienBan],[SOType],[PrcingDate],[POType],[FromSoLenh] " & _
                           ",[PriceGroupDO1],[LXLoai],[LXPhieu],[SO_POType],[Prcing],[DOCT],[HDChuyen],[BatchNum],[DO1_MaNguon] " & _
                           ",[CrSysDate],[PriceSynDate],[NOTE_LX],[SO_CHUYEN],[LOAI_KH],[NOTE_SMO],[NhomBeXuat] " & _
                           ",[NhomBeAPP],[NhomBeAPPU],[NhomBeAPPD],[ThongTinTDH],[trangthai],[TK_SynDate],[R_KWMENG2] " & _
                            " from tblLenhXuatE5_THN where solenh ='" & l_solenh & "' "
                p_Row = p_TableExe.NewRow
                p_Row(0) = p_SQL
                p_TableExe.Rows.Add(p_Row)

                p_SQL = "INSERT INTO [dbo].[tblLenhXuat_HangHoaE5] ([LineID],[MaLenh],[NgayXuat] ,[SoLenh],[TongXuat],[TongDuXuat] " & _
                               ",[MaHangHoa],[DonViTinh],[BeXuat],[TableID],[MeterId], [Createby], [UpdatedBy], [CreateDate] " & _
                               ",[UpdateDate],[QCI_KG],[QCI_NhietDo],[QCI_TyTrong],[DonGia],[CurrencyKey],[VCF],[WCF] " & _
                               ",[NhietDo_BQGQ],[D15_BQGQ],[KG],[L15],[GiaCty],[PhiVT],[TheBVMT],[ChietKhau],[Z001_PER] " & _
                               ",[Z003_PER],[Z009_PER] ,[QCI_L15],[TongSoTien],[BatchNum],[NhomBeXuat]) " & _
                     "select [LineID],[MaLenh],[NgayXuat] ,[SoLenh],[TongXuat],[TongDuXuat] " & _
                               ",[MaHangHoa],[DonViTinh],[BeXuat],[TableID],[MeterId]," & g_User_ID & " as  [Createby], " & g_User_ID & " as  [UpdatedBy],getdate() as  [CreateDate] " & _
                               ", getdate() as  [UpdateDate],[QCI_KG],[QCI_NhietDo],[QCI_TyTrong],[DonGia],[CurrencyKey],[VCF],[WCF] " & _
                               ",[NhietDo_BQGQ],[D15_BQGQ],[KG],[L15],[GiaCty],[PhiVT],[TheBVMT],[ChietKhau],[Z001_PER] " & _
                               ",[Z003_PER],[Z009_PER] ,[QCI_L15],[TongSoTien],[BatchNum],[NhomBeXuat] " & _
                         "from  [tblLenhXuat_HangHoaE5_THN]  where solenh ='" & l_solenh & "'"
                p_Row = p_TableExe.NewRow
                p_Row(0) = p_SQL
                p_TableExe.Rows.Add(p_Row)


                p_SQL = "INSERT INTO [dbo].[tblLenhXuatChiTietE5]([MaNgan],[MaLenh],[NgayXuat],[LineID],[SoLuongDuXuat],[SoLuongThucXuat] " & _
                                   ",[NhietDo],[TyTrong_15] ,[TrangThai],[MaLuuLuongKe],[MaEntry],[Status],[ERate] " & _
                                   ",[Createby],[UpdatedBy],[CreateDate],[UpdateDate],[DungTichNgan],[TableID],[MaTuDongHoa] " & _
                                   ",[PhuongTien],[Record_Status],[SO_TT],[FlagTankLine],[GST_TDH],[CardNum] ,[CardData] " & _
                                   ",[BatchNum],[L15] ,[KG],[BQGQ_NhietDo],[BQGQ_D15] ,[VCF],[WCF],[NhomBeXuat],[BeXuat] " & _
                                   ",[ThongTinTDH],[NhietDoXe]) " & _
                        "SELECT [MaNgan],[MaLenh],[NgayXuat],[LineID],[SoLuongDuXuat],[SoLuongThucXuat] " & _
                                   ",[NhietDo],[TyTrong_15] ,[TrangThai],[MaLuuLuongKe],[MaEntry],[Status],[ERate] " & _
                                   ", " & g_User_ID & " as [Createby], " & g_User_ID & " as [UpdatedBy],getdate() as [CreateDate],getdate() as  [UpdateDate],[DungTichNgan],[TableID],[MaTuDongHoa] " & _
                                   ",[PhuongTien],[Record_Status],[SO_TT],[FlagTankLine],[GST_TDH],[CardNum] ,[CardData] " & _
                                   ",[BatchNum],[L15] ,[KG],[BQGQ_NhietDo],[BQGQ_D15] ,[VCF],[WCF],[NhomBeXuat],[BeXuat] " & _
                                   ",[ThongTinTDH],[NhietDoXe] " & _
                             "from [tblLenhXuatChiTietE5_THN]  where SoLenhLine ='" & l_solenh & "'"
                p_Row = p_TableExe.NewRow
                p_Row(0) = p_SQL
                p_TableExe.Rows.Add(p_Row)

                If Not p_TableExe Is Nothing Then
                    ' p_DataExec.WriteXml(p_PathXml)

                    If g_Services.Sys_Execute_DataTbl(p_TableExe, p_desc) = False Then
                        
                        Exit Sub
                    End If
                End If


                p_SQL = "select solenh from tblLenhXuatE5 with (nolock) where SoLenh ='" & l_solenh & "'"
                p_Table = GetDataTable(p_SQL, p_SQL)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        p_desc = ""
                        Exit Sub
                    End If
                End If

                p_desc = "Lệnh xuất không xác định."
                Exit Sub
            End If
        End If
        p_desc = "Lệnh xuất không xác định"

    End Sub




End Module
