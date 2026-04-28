Module HTTG_SAP
    Private _WareHouse As String
    Private _ShPoint As String
    Private _SapConnectionString As String
    Private p_TableConfig As DataTable
    Private _TimeOut = New TimeSpan()

    Public Function mdlSyncDeliveries_Httg2Sap(ByVal i_dt_Header As DataTable, ByVal i_dt_Material As DataTable, ByVal i_dt_Details As DataTable,
                                                ByRef p_Desc As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_PhieuXuatTable
        Dim l_ret2 As Connect2SAP.BAPIRET2

        Dim l_loaiphieu As String
        Dim l_solenh As String
        Dim l_started As String

        Dim p_SQL As String
        Dim p_DataRowArr() As DataRow



        p_SQL = "select * from tblConfig "

        p_TableConfig = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                _SapConnectionString = p_TableConfig.Rows(0).Item("sapconnectionstring").ToString.Trim
                _WareHouse = p_TableConfig.Rows(0).Item("warehouse").ToString.Trim
                _ShPoint = p_TableConfig.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If
        If _SapConnectionString = "" Then
            p_Desc = "String kết nối đến SAP chưa khai báo"
            mdlSyncDeliveries_Httg2Sap = True
            Exit Function
        End If


        l_loaiphieu = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()

        l_ztb = New Connect2SAP.Str_PhieuXuatTable()
        '-----------------------------------------------------------------
        '   Kiểm tra xem có phải là tạo mới ở HTTG không
        '-----------------------------------------------------------------
        l_solenh = i_dt_Header.Rows(0).Item("SoLenh").ToString()
        l_started = l_solenh.Substring(0, 4)

        If l_started.Trim = _WareHouse And Char.IsLetter(l_solenh, 4) Then
            Return False
            If mdlSyncDeliveries_Created(i_dt_Header, i_dt_Material, i_dt_Details, l_ztb) Then
                GoTo Confirm
            End If
        End If

        '-----------------------------------------------------------------
        '   Kiểm tra loại phiếu TR hay no TR
        '-----------------------------------------------------------------
        If l_loaiphieu <> "V144" Then
            If mdlSyncDeliveries_Shipment(i_dt_Header, i_dt_Material, i_dt_Details, l_ztb) Then

            End If
        Else
            mdlSyncDeliveries_NoShipment(i_dt_Header, i_dt_Material, i_dt_Details, l_ztb)
        End If


Confirm:

        If l_ztb.Count > 0 Then
            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_c2sap.ConfirmPhieuXuat(l_ztb, l_ret2)
            If l_ret2.Type = "E" Then
                Return False
            End If
            '----------------------Tank------------------------------------
            mdlExtras_UpdateTank(i_dt_Material)
            '----------------------Tank------------------------------------
            'FES
            '20141003
            '----------------------E5--------------------------------------
            mdlExtras_ConfirmE5(l_solenh, i_dt_Details)
            '----------------------E5--------------------------------------
        Else
            Return False
        End If

        l_c2sap.Connection.Close()
        l_c2sap.Dispose()

        Return True
    End Function

    Sub mdlExtras_UpdateTank(ByVal i_dt As DataTable)

        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim t_do As Connect2SapEx.STR_TANKTable
        Dim s_do As Connect2SapEx.STR_TANK
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        Try
            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            t_do = New Connect2SapEx.STR_TANKTable()

            For i As Integer = 0 To i_dt.Rows.Count - 1
                s_do = New Connect2SapEx.STR_TANK()

                s_do.Outbound = i_dt.Rows(i).Item("Solenh").ToString()
                s_do.Item_Nd = i_dt.Rows(i).Item("LineID").ToString()
                s_do.Tank = i_dt.Rows(i).Item("BeXuat").ToString()
                t_do.Add(s_do)
            Next

            If p_TableConfig.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
                l_c2sap.Update_Tank(t_do, l_ret2)
            Else
                l_async = l_c2sap.BeginUpdate_Tank(t_do, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndUpdate_Tank(l_async, t_do, l_ret2)
                End If
            End If

            l_c2sap.Connection.Close()
            l_c2sap.Connection.Dispose()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub


    Sub mdlExtras_ConfirmE5(ByVal i_solenh As String, ByVal ii_dt As DataTable)

        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim lt_ret2 As Connect2SapEx.BAPIRET2Table
        Dim t_do As Connect2SapEx.STR_E5Table  '  Str_E5Table
        Dim s_do As Connect2SapEx.STR_E5 ' Str_E5
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_Check As String

        Dim p_SQL As String
        Dim i_dt As DataTable
        'Dim p_c2sql As Connect2SQL.Connect2SQL

        Try
            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            lt_ret2 = New Connect2SapEx.BAPIRET2Table()
            t_do = New Connect2SapEx.STR_E5Table()


            p_SQL = "SELECT * FROM   tblLenhXuatChiTietE5  a with (nolock)  WHERE  exists (select 1 from  tblLenhXuat_HangHoaE5 b with (nolock), tblHangHoaE5 c " & _
                            " where b.MaHangHoa=c.MaHangHoa and   a.LineID =b.LineID " & _
                                " and a.MaLenh=b.MaLenh  and b.SoLenh='" & i_solenh & "'  and a.NgayXuat =b.NgayXuat)"
            i_dt = GetDataTable(p_SQL, p_SQL)



            For i As Integer = 0 To i_dt.Rows.Count - 1
                ' p_Check = CheckItemToScada2(i_dt.Rows(i).Item("NGAY_DKY").ToString().Trim)

                s_do = New Connect2SapEx.STR_E5()

                s_do.Outbound = i_solenh

                'NGAY_DKY,NGAY_BD,NGAY_KT,SO_CTU,MA_LENH,CARD_DATA,MA_NGAN,MA_HHOA,MA_HONG,MA_KHO,
                s_do.Ngay_Dky = i_dt.Rows(i).Item("NGAY_DKY").ToString()
                s_do.Ngay_Bd = i_dt.Rows(i).Item("NGAY_BD").ToString()
                s_do.Ngay_Kt = i_dt.Rows(i).Item("NGAY_KT").ToString()
                s_do.Card_Data = i_dt.Rows(i).Item("CARD_DATA").ToString()
                s_do.Ma_Hhoa = i_dt.Rows(i).Item("MA_HHOA").ToString()
                'Integer.TryParse(i_dt.Rows(i).Item("MA_HONG").ToString.Trim, s_do.Ma_Hong)

                s_do.Compartment = i_dt.Rows(i).Item("MaNgan").ToString()
                s_do.Gv = i_dt.Rows(i).Item("GV").ToString()
                s_do.Gst = i_dt.Rows(i).Item("GST").ToString()
                s_do.Gvtotal_Start = i_dt.Rows(i).Item("GVTOTAL_START").ToString()
                s_do.Gvtotal_End = i_dt.Rows(i).Item("GVTOTAL_END").ToString()
                s_do.Gsttotal_Start = i_dt.Rows(i).Item("GSTTOTAL_START").ToString()
                s_do.Gsttotal_End = i_dt.Rows(i).Item("GSTTOTAL_END").ToString()
                s_do.Kf = i_dt.Rows(i).Item("KF").ToString()
                s_do.Kf_E = i_dt.Rows(i).Item("KF_E").ToString()
                s_do.Avg_Mf = i_dt.Rows(i).Item("AVG_MF").ToString()
                s_do.Avg_Mf_E = i_dt.Rows(i).Item("AVG_MF_E").ToString()
                'FES44
                '20141118
                s_do.Avg_Ctl = GetCTLE5(i_dt.Rows(i).Item("NGAY_DKY").ToString(), i_dt.Rows(i).Item("MaLenh").ToString(), i_dt.Rows(i).Item("LineID").ToString())    ' i_dt.Rows(i).Item("AVG_CTL").ToString()
                s_do.Avg_Ctl_E = i_dt.Rows(i).Item("AVG_CTL_E").ToString()
                s_do.Avg_Ctl_Base = i_dt.Rows(i).Item("AVG_CTL_BASE").ToString()
                s_do.Rtd_Offset = i_dt.Rows(i).Item("RTD_OFFSET").ToString()
                s_do.Gv_E = i_dt.Rows(i).Item("GV_E").ToString()
                s_do.Gst_E = i_dt.Rows(i).Item("GST_E").ToString()
                s_do.Gvtotal_E_Start = i_dt.Rows(i).Item("GVTOTAL_E_START").ToString()
                s_do.Gvtotal_E_End = i_dt.Rows(i).Item("GVTOTAL_E_END").ToString()
                s_do.Gsttotal_E_Start = i_dt.Rows(i).Item("GSTTOTAL_E_START").ToString()
                s_do.Gsttotal_E_End = i_dt.Rows(i).Item("GSTTOTAL_E_END").ToString()
                s_do.Gv_Base = i_dt.Rows(i).Item("GV_BASE").ToString()
                s_do.Gst_Base = i_dt.Rows(i).Item("GST_BASE").ToString()
                s_do.Gvtotal_Base_Sta = i_dt.Rows(i).Item("GVTOTAL_BASE_START").ToString()
                s_do.Gvtotal_Base_End = i_dt.Rows(i).Item("GVTOTAL_BASE_END").ToString()
                s_do.Gsttotal_Base_St = i_dt.Rows(i).Item("GSTTOTAL_BASE_START").ToString()
                s_do.Gsttotal_Base_En = i_dt.Rows(i).Item("GSTTOTAL_BASE_END").ToString()
                s_do.Tyle_Tte = i_dt.Rows(i).Item("TYLE_TTE").ToString()
                s_do.V_Preset = i_dt.Rows(i).Item("V_PRESET").ToString()
                s_do.Tyle_Preset = i_dt.Rows(i).Item("TYLE_PRESET").ToString()
                s_do.Tytrong_Base = i_dt.Rows(i).Item("TYTRONG_BASE").ToString()
                s_do.Tytrong_E = i_dt.Rows(i).Item("TYTRONG_E").ToString()
                s_do.Ty_Trongtb = i_dt.Rows(i).Item("TY_TRONGTB").ToString()

                s_do.Ty_Trongtb_Base = i_dt.Rows(i).Item("TY_TRONGTB_BASE").ToString()
                s_do.Ty_Trongtb_E = i_dt.Rows(i).Item("TY_TRONGTB_E").ToString()
                s_do.Item_Nd = i_dt.Rows(i).Item("LineID").ToString()

                'FES99
                '20141226
                'Them cac thong tin ve KG
                s_do.Mass = i_dt.Rows(i).Item("MASS").ToString()
                s_do.Mass_Base = i_dt.Rows(i).Item("MASS_BASE").ToString()
                s_do.Mass_E = i_dt.Rows(i).Item("MASS_E").ToString()


                t_do.Add(s_do)
            Next

            If p_TableConfig.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.ConfirmE5(t_do, lt_ret2)
            Else
                l_async = l_c2sap.BeginConfirmE5(t_do, lt_ret2, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndConfirmE5(l_async, t_do, lt_ret2)
                End If
            End If

            l_c2sap.Connection.Close()
            l_c2sap.Connection.Dispose()

        Catch ex As Exception
            MsgBox("Error Confirm: " & ex.Message)
        End Try
    End Sub

    'FES44
    '20141118
    Private Function GetCTLE5(ByVal p_Date As Date, ByVal p_MaLenh As String, ByVal p_LineID As String) As String
        ' Dim l_c2sql As Connect2SQL.Connect2SQL
        Dim p_Value As Double
        Dim p_SQL As String
        Dim p_DataTable As DataTable

        GetCTLE5 = "0"
        p_Value = 0

        p_SQL = "select dbo.fm_GetVCF_FromE5 ('" & p_Date.ToString("yyyyMMdd") & "','" & p_MaLenh.ToString.Trim & "','" & p_LineID & "') as VCF "
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                If p_DataTable.Rows(0).Item("VCF").ToString.Trim <> "" Then
                    p_Value = p_DataTable.Rows(0).Item("VCF").ToString.Trim
                End If

            End If
        End If
        'p_Value = l_c2sql.getDataValue("select dbo.fm_GetVCF_FromE5 ('" & p_Date.ToString("yyyyMMdd") & "','" & p_MaLenh.ToString.Trim & "','" & p_LineID & "') ")

        GetCTLE5 = p_Value.ToString.Trim
    End Function


    Private Function mdlSyncDeliveries_Created(ByVal i_dt_Header As DataTable, _
                                              ByVal i_dt_Material As DataTable, _
                                              ByVal i_dt_Details As DataTable, _
                                              ByRef o_ztb_Temp As Connect2SAP.Str_PhieuXuatTable) As Boolean
        Dim l_loaiphieu As String

        Try
            l_loaiphieu = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()

            If l_loaiphieu = "V144" Then
                '-----------------------------------------------------------------
                '   Create ztb khi không có TR                
                '-----------------------------------------------------------------
                If i_dt_Details.Rows.Count > 0 Then
                    If mdlSyncDeliveries_NoShipment(i_dt_Header, i_dt_Material, i_dt_Details, o_ztb_Temp) Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            Else
                '-----------------------------------------------------------------
                '   Create ztb khi có TR                
                '-----------------------------------------------------------------
                If i_dt_Details.Rows.Count > 0 Then
                    If mdlSyncDeliveries_Shipment(i_dt_Header, i_dt_Material, i_dt_Details, o_ztb_Temp) Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function mdlSyncDeliveries_NoShipment(ByVal i_dt_Header As DataTable, _
                                               ByVal i_dt_Material As DataTable, _
                                               ByVal i_dt_Details As DataTable, _
                                               ByRef o_ztb_Temp As Connect2SAP.Str_PhieuXuatTable) As Boolean
        Dim l_str As Connect2SAP.Str_PhieuXuat
        Dim l_lineid, _
            l_mangan, _
            l_chieucaohamhang, _
            l_loaiphieu _
            As String

        Dim l_quantity(), _
            l_quantity_conf(), _
            l_nhietdo(), _
            l_tytrong(), _
            l_meter_s(), _
            l_meter_e() _
            As Decimal

        Dim l_meter_n() _
            As String

        Dim l_lineid_int As Integer

        Dim l_vanchuyen As String
        Dim l_count() As Integer

        Try
            '-----------------------------------------------------------------
            '   Tìm Item lớn nhất
            '-----------------------------------------------------------------
            Dim l_item_max As Integer
            l_item_max = 0
            Try
                For i As Integer = 0 To i_dt_Material.Rows.Count - 1
                    If l_item_max <= Convert.ToInt32(i_dt_Material.Rows(i).Item("LineId").ToString()) Then
                        l_item_max = Convert.ToInt32(i_dt_Material.Rows(i).Item("LineId").ToString())
                    End If
                Next
            Catch ex As Exception
                Return False
            End Try
            '-----------------------------------------------------------------
            '   Tính trung bình tỉ trọng
            '   Tính bình quân gia quyền nhiệt độ
            '-----------------------------------------------------------------
            ReDim l_quantity(l_item_max)
            ReDim l_quantity_conf(l_item_max)
            ReDim l_nhietdo(l_item_max)
            ReDim l_tytrong(l_item_max)
            ReDim l_count(l_item_max)
            ReDim l_meter_n(l_item_max)
            ReDim l_meter_s(l_item_max)
            ReDim l_meter_e(l_item_max)
            l_chieucaohamhang = String.Empty

            For i As Integer = 0 To i_dt_Details.Rows.Count - 1
                l_lineid_int = Convert.ToInt32(i_dt_Details.Rows(i).Item("LineID").ToString())

                l_quantity(l_lineid_int) = l_quantity(l_lineid_int) + Convert.ToDecimal(i_dt_Details.Rows(i).Item("SoLuongDuXuat").ToString())
                l_quantity_conf(l_lineid_int) = l_quantity_conf(l_lineid_int) + Convert.ToDecimal(i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString())
                l_nhietdo(l_lineid_int) = l_nhietdo(l_lineid_int) + _
                                          Convert.ToDecimal(i_dt_Details.Rows(i).Item("NhietDo").ToString()) * _
                                          Convert.ToDecimal(i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString())

                l_tytrong(l_lineid_int) = l_tytrong(l_lineid_int) + Convert.ToDecimal(i_dt_Details.Rows(i).Item("TyTrong_15").ToString())

                l_meter_n(l_lineid_int) = i_dt_Details.Rows(i).Item("MaLuuLuongKe").ToString()
                If l_meter_s(l_lineid_int) > Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkebd").ToString()) Then
                    l_meter_s(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkebd").ToString())
                Else
                    If l_meter_s(l_lineid_int) = 0 Then
                        l_meter_s(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkebd").ToString())
                    End If
                End If

                If l_meter_e(l_lineid_int) < Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkekt").ToString()) Then
                    l_meter_e(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkekt").ToString())
                Else
                    If l_meter_e(l_lineid_int) = 0 Then
                        l_meter_e(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkekt").ToString())
                    End If
                End If

                l_count(l_lineid_int) = l_count(l_lineid_int) + 1
                l_chieucaohamhang = l_chieucaohamhang & "H" & i_dt_Details.Rows(i).Item("MaNgan").ToString() & ": " & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "; "
            Next

            For i As Integer = 0 To i_dt_Material.Rows.Count - 1
                l_str = New Connect2SAP.Str_PhieuXuat()
                '-----------------------------------------------------------------------------------------
                '   dữ liệu lấy từ i_dt_Header
                '-----------------------------------------------------------------------------------------
                l_str.Order_No = i_dt_Header.Rows(0).Item("Solenh").ToString()
                l_str.Outbound = i_dt_Header.Rows(0).Item("Solenh").ToString()
                l_str.Date_Nd = Format(i_dt_Header.Rows(0).Item("NgayXuat"), "yyyy-MM-dd")
                l_str.Plant = _WareHouse
                l_str.Batch_Nd = i_dt_Header.Rows(0).Item("MaNguon").ToString()
                l_str.Resource_Nd = i_dt_Header.Rows(0).Item("MaNguon").ToString()
                l_str.Method_Mt = i_dt_Header.Rows(0).Item("MaPhuongThucXuat").ToString()
                l_str.Method_Dc = i_dt_Header.Rows(0).Item("MaPhuongThucBan").ToString()
                l_str.Customer = i_dt_Header.Rows(0).Item("MaKhachHang").ToString()
                l_str.Shpoint = _ShPoint
                l_str.Transmot = i_dt_Header.Rows(0).Item("MaVanChuyen").ToString()
                l_str.Niem_Text = i_dt_Header.Rows(0).Item("Niem").ToString()
                l_str.Ngan_Text = l_chieucaohamhang
                l_str.Luong_Text = i_dt_Header.Rows(0).Item("LuongGiamDinh").ToString()
                l_str.Nhietdo_Text = i_dt_Header.Rows(0).Item("NhietDoTaiTau").ToString()
                '-----------------------------------------------------------------------------------------

                l_str.Veh_Mode = i_dt_Header.Rows(0).Item("MaVanChuyen").ToString()
                l_str.Vehicle = i_dt_Header.Rows(0).Item("MaPhuongTien").ToString()
                l_str.Drivercode = i_dt_Header.Rows(0).Item("NguoiVanChuyen").ToString()
                l_loaiphieu = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()
                '-----------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------------------------
                '   Dữ liệu được lấy từ i_dt_Material
                '-----------------------------------------------------------------------------------------
                l_lineid = i_dt_Material.Rows(i).Item("LineID").ToString()
                l_mangan = "144"
                l_str.Lineid = l_lineid.Substring(3, 3)
                l_str.Compartment = l_mangan
                l_str.Item_Nd = l_lineid
                l_str.Material = i_dt_Material.Rows(i).Item("MaHangHoa").ToString()
                l_str.Unit = i_dt_Material.Rows(i).Item("DonViTinh").ToString()
                l_str.Salequantity = i_dt_Material.Rows(i).Item("TongDuXuat").ToString()
                l_str.Quantity = i_dt_Material.Rows(i).Item("TongDuXuat").ToString()
                '-----------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------------------------
                '   Dữ liệu được lấy từ i_dt_Details
                '-----------------------------------------------------------------------------------------
                '-----------------------------------------------------------------------------------------
                '   System Test KV2
                '       Lấy lượng thực xuất = lượng dự xuất với đường bộ
                '-----------------------------------------------------------------------------------------
                l_vanchuyen = mdlDelivery_CheckTransmot(l_str.Transmot, g_dt_para)
                If l_vanchuyen = "Bo" Then
                    l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                Else
                    l_str.Quantity_Confirm = l_quantity_conf(Convert.ToDecimal(l_lineid))
                End If

                l_str.Temp_Confirm = Math.Round(l_nhietdo(Convert.ToDecimal(l_lineid)) / l_quantity_conf(Convert.ToDecimal(l_lineid)), 2)
                l_str.Dens_Confirm = l_tytrong(Convert.ToDecimal(l_lineid)) / l_count(Convert.ToDecimal(l_lineid))

                '-----------------------------------------------------------------------------------------
                '   Đặt ngày giờ xuất hàng đưa lên SAP
                '-----------------------------------------------------------------------------------------
                Try
                    If i_dt_Header.Rows(0).Item("NgayXuat") <= i_dt_Details.Rows(0).Item("ThoiGianDau") Then
                        l_str.Date_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "yyyy-MM-dd")
                    End If
                    l_str.Time_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "HH:mm:ss")
                Catch ex As Exception
                    l_str.Date_Nd = Format(Now(), "yyyy-MM-dd")
                    l_str.Time_Nd = Format(Now(), "HH:mm:ss")
                End Try
                '-----------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------------------------
                '   Tính lại số lưu lượng kế
                '-----------------------------------------------------------------------------------------
                l_str.Meter_No = l_meter_n(l_lineid)
                l_str.Meter_Start = Convert.ToInt32(l_meter_s(l_lineid))
                l_str.Meter_End = Convert.ToInt32(l_meter_e(l_lineid))
                '-----------------------------------------------------------------------------------------

                o_ztb_Temp.Add(l_str)
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function mdlSyncDeliveries_Shipment(ByVal i_dt_Header As DataTable, _
                                                ByVal i_dt_Material As DataTable, _
                                                ByVal i_dt_Details As DataTable, _
                                                ByRef o_ztb_Temp As Connect2SAP.Str_PhieuXuatTable) As Boolean
        Dim l_str As Connect2SAP.Str_PhieuXuat
        Dim l_lineid, _
            l_mangan, _
            l_loaiphieu _
            As String
        Dim l_vanchuyen As String

        Try

            For i As Integer = 0 To i_dt_Details.Rows.Count - 1
                l_str = New Connect2SAP.Str_PhieuXuat()
                '-----------------------------------------------------------------------------------------
                '   dữ liệu lấy từ i_dt_Header
                '-----------------------------------------------------------------------------------------
                l_str.Order_No = i_dt_Header.Rows(0).Item("Solenh").ToString()
                l_str.Outbound = i_dt_Header.Rows(0).Item("Solenh").ToString()
                l_str.Date_Nd = Format(i_dt_Header.Rows(0).Item("NgayXuat"), "yyyy-MM-dd")
                l_str.Plant = _WareHouse
                'l_str.Storage = _
                l_str.Batch_Nd = i_dt_Header.Rows(0).Item("MaNguon").ToString()
                l_str.Resource_Nd = i_dt_Header.Rows(0).Item("MaNguon").ToString()
                l_str.Method_Mt = i_dt_Header.Rows(0).Item("MaPhuongThucXuat").ToString()
                l_str.Method_Dc = i_dt_Header.Rows(0).Item("MaPhuongThucBan").ToString()
                l_str.Customer = i_dt_Header.Rows(0).Item("MaKhachHang").ToString()
                l_str.Shpoint = _ShPoint
                'l_str.Transmot = i_dt_Header.Rows(0).Item("MaVanChuyen").ToString()
                l_str.Shnumber = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()
                l_str.Veh_Mode = i_dt_Header.Rows(0).Item("MaVanChuyen").ToString()
                l_str.Vehicle = i_dt_Header.Rows(0).Item("MaPhuongTien").ToString()
                l_str.Drivercode = i_dt_Header.Rows(0).Item("NguoiVanChuyen").ToString()
                l_str.Niem_Text = i_dt_Header.Rows(0).Item("Niem").ToString()
                l_str.Luong_Text = i_dt_Header.Rows(0).Item("LuongGiamDinh").ToString()
                l_str.Nhietdo_Text = i_dt_Header.Rows(0).Item("NhietDoTaiTau").ToString()
                l_loaiphieu = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()
                '-----------------------------------------------------------------------------------------
                '-----------------------------------------------------------------------------------------
                '   System Test KV2
                '       Lấy lượng thực xuất = lượng dự xuất với đường bộ
                '-----------------------------------------------------------------------------------------
                l_vanchuyen = mdlDelivery_CheckTransmot(l_str.Veh_Mode, g_dt_para)
                '-----------------------------------------------------------------------------------------
                '-----------------------------------------------------------------------------------------
                'Dữ liệu được lấy từ Details
                '-----------------------------------------------------------------------------------------
                l_lineid = i_dt_Details.Rows(i).Item("LineID").ToString()
                l_mangan = i_dt_Details.Rows(i).Item("MaNgan").ToString()
                l_str.Lineid = l_lineid.Substring(3, 3)
                l_str.Compartment = l_mangan
                l_str.Item_Nd = l_lineid
                '-----------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------------------------
                '   Làm vòng lặp để kiểm tra lineid với i_dt_material
                '-----------------------------------------------------------------------------------------
                For j As Integer = 0 To i_dt_Material.Rows.Count - 1
                    If i_dt_Material.Rows(j).Item("LineID").ToString() = l_lineid Then
                        l_str.Material = i_dt_Material.Rows(j).Item("MaHangHoa").ToString()
                        l_str.Unit = i_dt_Material.Rows(j).Item("DonViTinh").ToString()
                        l_str.Salequantity = i_dt_Material.Rows(j).Item("TongDuXuat").ToString()
                        Exit For
                    End If
                Next
                '-----------------------------------------------------------------------------------------
                l_str.Quantity = i_dt_Details.Rows(i).Item("SoLuongDuXuat").ToString()
                'l_str.Quantity_Confirm = i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString()
                '-----------------------------------------------------------------------------------------
                '   System Test KV2
                '       Lấy lượng thực xuất = lượng dự xuất với đường bộ
                '-----------------------------------------------------------------------------------------
                If l_vanchuyen = "Bo" Then
                    l_str.Quantity_Confirm = l_str.Quantity
                Else
                    l_str.Quantity_Confirm = i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString()
                End If

                l_str.Temp_Confirm = i_dt_Details.Rows(i).Item("NhietDo").ToString()
                l_str.Dens_Confirm = i_dt_Details.Rows(i).Item("TyTrong_15").ToString()

                '-----------------------------------------------------------------------------------------
                '   Đặt ngày giờ xuất hàng đưa lên SAP
                '-----------------------------------------------------------------------------------------
                Try
                    If i_dt_Header.Rows(0).Item("NgayXuat") <= i_dt_Details.Rows(0).Item("ThoiGianDau") Then
                        l_str.Date_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "yyyy-MM-dd")
                    End If
                    l_str.Time_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "HH:mm:ss")
                Catch ex As Exception
                    l_str.Date_Nd = Format(Now(), "yyyy-MM-dd")
                    l_str.Time_Nd = Format(Now(), "HH:mm:ss")
                End Try
                '-----------------------------------------------------------------------------------------

                Dim l_d_start, _
                    l_d_end _
                    As Decimal
                l_d_start = i_dt_Details.Rows(i).Item("sl_llkebd")
                l_d_end = i_dt_Details.Rows(i).Item("sl_llkekt")
                l_str.Meter_No = i_dt_Details.Rows(i).Item("MaLuuLuongKe").ToString()
                l_str.Meter_Start = Convert.ToInt32(l_d_start)
                l_str.Meter_End = Convert.ToInt32(l_d_end)
                l_str.Ngan_Text = l_str.Ngan_Text & "H" & i_dt_Details.Rows(i).Item("MaNgan").ToString() & ": " & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "; "

                o_ztb_Temp.Add(l_str)
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

End Module
