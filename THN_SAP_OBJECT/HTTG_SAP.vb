Module HTTG_SAP
    Private _WareHouse As String
    Private _ShPoint As String
    Private _SapConnectionString As String
    Private p_TableConfig As DataTable
    Private p_Sys_Config As DataTable
    Private _TimeOut = New TimeSpan()
    Private g_dt_para As DataTable

    Private p_TONGDUXUAT As String = "0"
    Private p_TONGDUXUATTHUY As String = "0"

    Private p_XITEC_OPTION As Boolean = False

    Private p_NIEM_MM As Boolean = False
    Private p_KYHIEU_NIEM As String = "H"


    '    Public Function mdlSyncDeliveries_Httg2Sap(ByVal i_dt_Header As DataTable, ByVal i_dt_Material As DataTable, ByVal i_dt_Details As DataTable,
    '                                                ByRef p_Desc As String) As Boolean
    '        Dim l_c2sap As Connect2SAP.Connect2SAP
    '        Dim l_ztb As Connect2SAP.Str_PhieuXuatTable
    '        Dim l_ret2 As Connect2SAP.BAPIRET2

    '        Dim l_loaiphieu As String
    '        Dim l_solenh As String
    '        Dim l_started As String

    '        Dim p_SQL As String
    '        Dim p_DataRowArr() As DataRow

    '        Try



    '        p_SQL = "select * from tblPara "

    '        g_dt_para = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

    '        p_SQL = "select * from SYS_CONFIG "
    '        p_Sys_Config = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '        p_DataRowArr = p_Sys_Config.Select("KEYCODE='TONGDUXUAT'")
    '        If p_DataRowArr.Length > 0 Then
    '            p_TONGDUXUAT = p_DataRowArr(0).Item(1).ToString.Trim
    '        End If

    '        p_DataRowArr = p_Sys_Config.Select("KEYCODE='TONGDUXUATTHUY'")
    '        If p_DataRowArr.Length > 0 Then
    '            p_TONGDUXUATTHUY = p_DataRowArr(0).Item(1).ToString.Trim
    '        End If

    '            p_NIEM_MM = False
    '            p_DataRowArr = p_Sys_Config.Select("KEYCODE='NIEM_MM'")
    '            If p_DataRowArr.Length > 0 Then
    '                If p_DataRowArr(0).Item(1).ToString.Trim = "Y" Then
    '                    p_NIEM_MM = True
    '                End If
    '            End If

    '            p_XITEC_OPTION = False
    '            p_DataRowArr = p_Sys_Config.Select("KEYCODE='XITEC_OPTION'")
    '            If p_DataRowArr.Length > 0 Then
    '                If p_DataRowArr(0).Item(1).ToString.Trim = "Y" Then
    '                    p_XITEC_OPTION = True
    '                End If

    '            End If


    '            p_DataRowArr = p_Sys_Config.Select("KEYCODE='KYHIEU_NIEM'")
    '            If p_DataRowArr.Length > 0 Then
    '                If p_DataRowArr(0).Item(1).ToString.Trim <> "" Then
    '                    p_KYHIEU_NIEM = p_DataRowArr(0).Item(1).ToString.Trim
    '                End If

    '            End If

    '        p_SQL = "select * from tblConfig "

    '        p_TableConfig = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

    '        If Not p_TableConfig Is Nothing Then
    '            If p_TableConfig.Rows.Count > 0 Then
    '                _SapConnectionString = p_TableConfig.Rows(0).Item("sapconnectionstring").ToString.Trim
    '                _WareHouse = p_TableConfig.Rows(0).Item("warehouse").ToString.Trim
    '                _ShPoint = p_TableConfig.Rows(0).Item("shippingpoint").ToString.Trim
    '            End If

    '        End If
    '        If _SapConnectionString = "" Then
    '            p_Desc = "String kết nối đến SAP chưa khai báo"
    '            mdlSyncDeliveries_Httg2Sap = True
    '            Exit Function
    '        End If


    '        l_loaiphieu = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()

    '        l_ztb = New Connect2SAP.Str_PhieuXuatTable()
    '        '-----------------------------------------------------------------
    '        '   Kiểm tra xem có phải là tạo mới ở HTTG không
    '        '-----------------------------------------------------------------
    '        l_solenh = i_dt_Header.Rows(0).Item("SoLenh").ToString()
    '        l_started = l_solenh.Substring(0, 4)

    '        If l_started.Trim = _WareHouse And Char.IsLetter(l_solenh, 4) Then
    '            Return False
    '            If mdlSyncDeliveries_Created(i_dt_Header, i_dt_Material, i_dt_Details, l_ztb) Then
    '                GoTo Confirm
    '            End If
    '        End If

    '        '-----------------------------------------------------------------
    '        '   Kiểm tra loại phiếu TR hay no TR
    '        '-----------------------------------------------------------------
    '        If l_loaiphieu <> "V144" Then
    '            If mdlSyncDeliveries_Shipment(i_dt_Header, i_dt_Material, i_dt_Details, l_ztb) Then

    '            End If
    '        Else
    '            mdlSyncDeliveries_NoShipment(i_dt_Header, i_dt_Material, i_dt_Details, l_ztb)
    '        End If


    'Confirm:

    '        If l_ztb.Count > 0 Then
    '            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
    '            l_ret2 = New Connect2SAP.BAPIRET2()
    '                l_c2sap.ConfirmPhieuXuat(l_ztb, l_ret2)
    '            If l_ret2.Type = "E" Then
    '                Return False
    '            End If
    '            '----------------------Tank------------------------------------
    '            mdlExtras_UpdateTank(i_dt_Material, p_Desc)
    '            If p_Desc <> "" Then
    '                Return False
    '            End If
    '            '----------------------Tank------------------------------------
    '            'FES
    '            '20141003
    '            '----------------------E5--------------------------------------
    '            mdlExtras_ConfirmE5(l_solenh, i_dt_Details, p_Desc)
    '            If p_Desc <> "" Then
    '                Return False
    '            End If
    '            '----------------------E5--------------------------------------
    '        Else
    '            Return False
    '        End If

    '        l_c2sap.Connection.Close()
    '        l_c2sap.Dispose()

    '            Return True

    '        Catch ex As Exception
    '            p_Desc = ex.Message
    '            Return False
    '        End Try
    '    End Function

    'anhqh
    '20171225
    'Dung ham moi de đẩy thêm ngyà giờ bắt đầu bơm xuát

    Public Function mdlSyncDeliveries_Httg2Sap(ByVal i_dt_Header As DataTable, ByVal i_dt_Material As DataTable, ByVal i_dt_Details As DataTable,
                                                ByRef p_Desc As String, Optional ByVal p_THN_SoLenh As Boolean = False) As Boolean
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.Str_PhieuXuatTable
        Dim l_ztb_e5 As Connect2SapEx.STR_E5Table
        Dim l_ztb_ext As Connect2SapEx.STR_EXTTable
        Dim l_ret2 As Connect2SapEx.BAPIRET2

        Dim l_loaiphieu As String
        Dim l_solenh As String
        Dim l_started As String

        Dim p_V144 As Boolean = False
        Dim p_SQL As String
        Dim p_DataRowArr() As DataRow

        ' Dim t_do As Connect2SapEx.STR_E5Table

        Try



            p_SQL = "select * from tblPara "

            g_dt_para = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

            p_SQL = "select * from SYS_CONFIG "
            p_Sys_Config = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

            


            p_DataRowArr = p_Sys_Config.Select("KEYCODE='TONGDUXUAT'")
            If p_DataRowArr.Length > 0 Then
                p_TONGDUXUAT = p_DataRowArr(0).Item(1).ToString.Trim
            End If

            p_DataRowArr = p_Sys_Config.Select("KEYCODE='TONGDUXUATTHUY'")
            If p_DataRowArr.Length > 0 Then
                p_TONGDUXUATTHUY = p_DataRowArr(0).Item(1).ToString.Trim
            End If

            p_NIEM_MM = False
            p_DataRowArr = p_Sys_Config.Select("KEYCODE='NIEM_MM'")
            If p_DataRowArr.Length > 0 Then
                If p_DataRowArr(0).Item(1).ToString.Trim = "Y" Then
                    p_NIEM_MM = True
                End If
            End If

            p_XITEC_OPTION = False
            p_DataRowArr = p_Sys_Config.Select("KEYCODE='XITEC_OPTION'")
            If p_DataRowArr.Length > 0 Then
                If p_DataRowArr(0).Item(1).ToString.Trim = "Y" Then
                    p_XITEC_OPTION = True
                End If

            End If


            p_DataRowArr = p_Sys_Config.Select("KEYCODE='KYHIEU_NIEM'")
            If p_DataRowArr.Length > 0 Then
                If p_DataRowArr(0).Item(1).ToString.Trim <> "" Then
                    p_KYHIEU_NIEM = p_DataRowArr(0).Item(1).ToString.Trim
                End If

            End If

            p_V144 = False
            p_DataRowArr = p_Sys_Config.Select("KEYCODE='V144'")
            If p_DataRowArr.Length > 0 Then
                If p_DataRowArr(0).Item(1).ToString.Trim = "Y" Then
                    p_V144 = True
                End If

            End If


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

            l_ztb = New Connect2SapEx.Str_PhieuXuatTable()
            '-----------------------------------------------------------------
            '   Kiểm tra xem có phải là tạo mới ở HTTG không
            '-----------------------------------------------------------------
            l_solenh = i_dt_Header.Rows(0).Item("SoLenh").ToString()
            l_started = l_solenh.Substring(0, 4)


            '4535353543554345345
            'ggdgfdgdgdgdgd
            If p_THN_SoLenh = False Then
                If l_started.Trim = _WareHouse And Char.IsLetter(l_solenh, 4) Then
                    Return False
                    If mdlSyncDeliveries_Created(i_dt_Header, i_dt_Material, i_dt_Details, l_ztb) Then
                        GoTo Confirm
                    End If
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
                l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
                l_ret2 = New Connect2SapEx.BAPIRET2()

                p_Desc = ""
                l_ztb_e5 = mdlExtras_ConfirmE5(l_solenh, i_dt_Details, p_Desc)
                If p_Desc <> "" Then
                    Return False
                End If
                p_Desc = ""
                l_ztb_ext = mdlExtras_ConfirmExt(l_solenh, _
                                            i_dt_Header, i_dt_Material, _
                                             i_dt_Details, p_Desc)

                If p_Desc <> "" Then
                    Return False
                End If

                l_c2sap.ConfirmDO_EXT(l_ztb, l_ztb_e5, l_ztb_ext, l_ret2)
                If l_ret2.Type = "E" Then

                    p_Desc = "Lỗi khi thực hiện, đề nghị kiểm tra lệnh trên SAP"

                    Return False
                End If
                ''----------------------Tank------------------------------------
                'mdlExtras_UpdateTank(i_dt_Material, p_Desc)
                'If p_Desc <> "" Then
                '    Return False
                'End If
                ''----------------------Tank------------------------------------
                ''FES
                ''20141003
                ''----------------------E5--------------------------------------
                't_do = mdlExtras_ConfirmE5(l_solenh, i_dt_Details, p_Desc)
                'If p_Desc <> "" Then
                '    Return False
                'End If
                '----------------------E5--------------------------------------
            Else
                Return False
            End If

            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True

        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try
    End Function


    Sub mdlExtras_UpdateTank(ByVal i_dt As DataTable, ByRef p_Desc As String)

        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim t_do As Connect2SapEx.STR_TANKTable
        Dim s_do As Connect2SapEx.STR_TANK
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        p_Desc = ""
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
            '  MsgBox("Error: " & ex.Message)
            'ShowMessageBox(Err.Number.ToString, ex.Message)
            p_Desc = ex.Message
        End Try
    End Sub


    'Sub mdlExtras_ConfirmE5(ByVal i_solenh As String, ByVal ii_dt As DataTable, ByRef p_Desc As String)

    '    Dim l_c2sap As Connect2SapEx.Connect2Sap
    '    Dim lt_ret2 As Connect2SapEx.BAPIRET2Table
    '    Dim t_do As Connect2SapEx.STR_E5Table  '  Str_E5Table
    '    Dim s_do As Connect2SapEx.STR_E5 ' Str_E5
    '    Dim l_async As IAsyncResult
    '    Dim l_isCompleted As Boolean
    '    Dim p_Check As String
    '    Dim p_tbl As DataTable
    '    Dim p_SQL As String
    '    Dim i_dt As DataTable
    '    'Dim p_c2sql As Connect2SQL.Connect2SQL
    '    p_Desc = ""
    '    Try
    '        l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
    '        lt_ret2 = New Connect2SapEx.BAPIRET2Table()
    '        t_do = New Connect2SapEx.STR_E5Table()



    '        'p_SQL = "SELECT a.*,a1.MaHangHoa_Scada as Map_Scadar   FROM   tblLenhXuatChiTietE5 a with (nolock) ," & _
    '        '    " (select b.TableID, c.MaHangHoa_Scada   from  tblLenhXuat_HangHoaE5 b with (nolock), tblMap_MaHangHoa c  " & _
    '        '        " where b.MaHangHoa=c.MaHangHoa_Sap    and b.SoLenh='" & i_solenh & "') a1  " & _
    '        '        " where(a.TableID = a1.TableID)"



    '        p_SQL = "SELECT a.*,a1.MaHangHoa_Scada as Map_Scadar   FROM   fpt_tblLenhXuatChiTietE5_v a with (nolock) ," & _
    '            " (select b.TableID, solenh, c.MaHangHoa_Scada , NgayXuat  from  tblLenhXuat_HangHoaE5 b with (nolock), tblMap_MaHangHoa c  " & _
    '                " where b.MaHangHoa=c.MaHangHoa_Sap    and b.SoLenh='" & i_solenh & "') a1  " & _
    '                " where(a.TableID = a1.TableID and a.SoLenh =a1.solenh  and a.NgayXuat=a1.ngayxuat )"




    '        'If i_dt Is Nothing Then
    '        '    p_SQL = "SELECT a.*,a1.MaHangHoa_Scada as Map_Scadar   FROM   tblLenhXuatChiTietE5 a with (nolock) ," & _
    '        '        " (select b.TableID, c.MaHangHoa_Scada   from  tblLenhXuat_HangHoaE5 b with (nolock), tblMap_MaHangHoa c  " & _
    '        '            " where b.MaHangHoa=c.MaHangHoa_Sap    and b.SoLenh='" & i_solenh & "') a1  " & _
    '        '            " where(a.TableID = a1.TableID)"
    '        'Else
    '        '    If i_dt.Rows.Count <= 0 Then
    '        '        p_SQL = "SELECT a.*,a1.MaHangHoa_Scada as Map_Scadar   FROM   tblLenhXuatChiTietE5 a with (nolock) ," & _
    '        '            " (select b.TableID, c.MaHangHoa_Scada   from  tblLenhXuat_HangHoaE5 b with (nolock), tblMap_MaHangHoa c  " & _
    '        '                " where b.MaHangHoa=c.MaHangHoa_Sap    and b.SoLenh='" & i_solenh & "') a1  " & _
    '        '                " where(a.TableID = a1.TableID)"
    '        '    End If
    '        'End If

    '        i_dt = GetDataTable(p_SQL, p_SQL)


    '        For i As Integer = 0 To i_dt.Rows.Count - 1
    '            ' p_Check = CheckItemToScada2(i_dt.Rows(i).Item("NGAY_DKY").ToString().Trim)
    '            s_do = New Connect2SapEx.STR_E5()
    '            If i_dt.Rows(i).Item("MA_HHOA").ToString() = "" Then
    '                s_do.Ma_Hhoa = i_dt.Rows(i).Item("Map_Scadar").ToString()
    '            Else
    '                s_do.Ma_Hhoa = i_dt.Rows(i).Item("MA_HHOA").ToString()
    '            End If


    '            s_do.Outbound = i_solenh

    '            'NGAY_DKY,NGAY_BD,NGAY_KT,SO_CTU,MA_LENH,CARD_DATA,MA_NGAN,MA_HHOA,MA_HONG,MA_KHO,
    '            s_do.Ngay_Dky = IIf(i_dt.Rows(i).Item("NGAY_DKY").ToString.Trim = "", i_dt.Rows(i).Item("NGAY_DKY").ToString(), i_dt.Rows(i).Item("NGAY_DKY").ToString.Trim)
    '            s_do.Ngay_Bd = i_dt.Rows(i).Item("NGAY_BD").ToString()
    '            s_do.Ngay_Kt = i_dt.Rows(i).Item("NGAY_KT").ToString()
    '            s_do.Card_Data = i_dt.Rows(i).Item("CARD_DATA").ToString()

    '            'Integer.TryParse(i_dt.Rows(i).Item("MA_HONG").ToString.Trim, s_do.Ma_Hong)

    '            s_do.Compartment = i_dt.Rows(i).Item("MaNgan").ToString()
    '            s_do.Gv = i_dt.Rows(i).Item("GV").ToString()
    '            s_do.Gst = i_dt.Rows(i).Item("GST").ToString()
    '            s_do.Gvtotal_Start = i_dt.Rows(i).Item("GVTOTAL_START").ToString()
    '            s_do.Gvtotal_End = i_dt.Rows(i).Item("GVTOTAL_END").ToString()
    '            s_do.Gsttotal_Start = i_dt.Rows(i).Item("GSTTOTAL_START").ToString()
    '            s_do.Gsttotal_End = i_dt.Rows(i).Item("GSTTOTAL_END").ToString()
    '            s_do.Kf = i_dt.Rows(i).Item("KF").ToString()
    '            s_do.Kf_E = i_dt.Rows(i).Item("KF_E").ToString()
    '            s_do.Avg_Mf = i_dt.Rows(i).Item("AVG_MF").ToString()
    '            s_do.Avg_Mf_E = i_dt.Rows(i).Item("AVG_MF_E").ToString()
    '            'FES44
    '            '20141118
    '            s_do.Avg_Ctl = GetCTLE5(i_dt.Rows(i).Item("TableID").ToString())    ' i_dt.Rows(i).Item("AVG_CTL").ToString()
    '            s_do.Avg_Ctl_E = i_dt.Rows(i).Item("AVG_CTL_E").ToString()
    '            s_do.Avg_Ctl_Base = i_dt.Rows(i).Item("AVG_CTL_BASE").ToString()
    '            s_do.Rtd_Offset = i_dt.Rows(i).Item("RTD_OFFSET").ToString()
    '            s_do.Gv_E = i_dt.Rows(i).Item("GV_E").ToString()
    '            s_do.Gst_E = i_dt.Rows(i).Item("GST_E").ToString()
    '            s_do.Gvtotal_E_Start = i_dt.Rows(i).Item("GVTOTAL_E_START").ToString()
    '            s_do.Gvtotal_E_End = i_dt.Rows(i).Item("GVTOTAL_E_END").ToString()
    '            s_do.Gsttotal_E_Start = i_dt.Rows(i).Item("GSTTOTAL_E_START").ToString()
    '            s_do.Gsttotal_E_End = i_dt.Rows(i).Item("GSTTOTAL_E_END").ToString()
    '            s_do.Gv_Base = i_dt.Rows(i).Item("GV_BASE").ToString()
    '            s_do.Gst_Base = i_dt.Rows(i).Item("GST_BASE").ToString()
    '            s_do.Gvtotal_Base_Sta = i_dt.Rows(i).Item("GVTOTAL_BASE_START").ToString()
    '            s_do.Gvtotal_Base_End = i_dt.Rows(i).Item("GVTOTAL_BASE_END").ToString()
    '            s_do.Gsttotal_Base_St = i_dt.Rows(i).Item("GSTTOTAL_BASE_START").ToString()
    '            s_do.Gsttotal_Base_En = i_dt.Rows(i).Item("GSTTOTAL_BASE_END").ToString()
    '            s_do.Tyle_Tte = i_dt.Rows(i).Item("TYLE_TTE").ToString()
    '            s_do.V_Preset = i_dt.Rows(i).Item("V_PRESET").ToString()
    '            s_do.Tyle_Preset = i_dt.Rows(i).Item("TYLE_PRESET").ToString()
    '            s_do.Tytrong_Base = i_dt.Rows(i).Item("TYTRONG_BASE").ToString()
    '            s_do.Tytrong_E = i_dt.Rows(i).Item("TYTRONG_E").ToString()
    '            s_do.Ty_Trongtb = i_dt.Rows(i).Item("TY_TRONGTB").ToString()

    '            s_do.Ty_Trongtb_Base = i_dt.Rows(i).Item("TY_TRONGTB_BASE").ToString()
    '            s_do.Ty_Trongtb_E = i_dt.Rows(i).Item("TY_TRONGTB_E").ToString()
    '            s_do.Item_Nd = i_dt.Rows(i).Item("LineID").ToString()

    '            'FES99
    '            '20141226
    '            'Them cac thong tin ve KG
    '            s_do.Mass = i_dt.Rows(i).Item("MASS").ToString()
    '            s_do.Mass_Base = i_dt.Rows(i).Item("MASS_BASE").ToString()
    '            s_do.Mass_E = i_dt.Rows(i).Item("MASS_E").ToString()


    '            t_do.Add(s_do)
    '        Next

    '        If p_TableConfig.Rows(0).Item("TimeOut").ToString() = "25" Then
    '            l_c2sap.ConfirmE5(t_do, lt_ret2)
    '        Else
    '            l_async = l_c2sap.BeginConfirmE5(t_do, lt_ret2, Nothing, l_c2sap)
    '            l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

    '            If l_isCompleted Then
    '                l_c2sap.EndConfirmE5(l_async, t_do, lt_ret2)
    '            End If
    '        End If

    '        'anhqh
    '        '20161116
    '        'Them doan neu day thong tin E5 len SAP loi thi tra ve trang thai E
    '        Dim ret2 As Connect2SapEx.BAPIRET2
    '        Try
    '            ret2 = lt_ret2.Item(0)

    '            If ret2.Type.ToString.Trim = "E" Then
    '                p_Desc = "Lỗi khi đẩy thông tin E5 lên SAP. Đề nghị đưa lại lên SAP"
    '            End If
    '        Catch ex As Exception
    '            p_Desc = "Lỗi khi đẩy thông tin E5 lên SAP. Đề nghị đưa lại lên SAP"
    '        End Try



    '        l_c2sap.Connection.Close()
    '        l_c2sap.Connection.Dispose()

    '    Catch ex As Exception
    '        ' MsgBox("Error Confirm: " & ex.Message)
    '        p_Desc = ex.Message
    '    End Try
    'End Sub



    Private Function mdlExtras_ConfirmE5(ByVal i_solenh As String, ByVal ii_dt As DataTable, ByRef p_Desc As String) As Connect2SapEx.STR_E5Table

        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim lt_ret2 As Connect2SapEx.BAPIRET2Table
        Dim t_do As Connect2SapEx.STR_E5Table  '  Str_E5Table
        Dim s_do As Connect2SapEx.STR_E5 ' Str_E5
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_Check As String
        Dim p_tbl As DataTable
        Dim p_SQL As String
        Dim i_dt As DataTable
        'Dim p_GST_TDH As Double

        Dim p_GST_TDH As Double
        'Dim p_c2sql As Connect2SQL.Connect2SQL
        p_Desc = ""
        Try
            ' l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            'lt_ret2 = New Connect2SapEx.BAPIRET2Table()
            t_do = New Connect2SapEx.STR_E5Table()




            p_SQL = "SELECT a.*,a1.MaHangHoa_Scada as Map_Scadar   FROM   fpt_tblLenhXuatChiTietE5_v a with (nolock) ," & _
                " (select b.MaLenh, b.TableID, solenh, c.MaHangHoa_Scada , NgayXuat  , LIneID from  tblLenhXuat_HangHoaE5 b with (nolock), tblMap_MaHangHoa c  " & _
                    " where b.MaHangHoa=c.MaHangHoa_Sap    and b.SoLenh='" & i_solenh & "' and exists (select 1 from tblHangHoaE5 where MaHangHoa = b.MaHangHoa) ) a1  " & _
                    " where (a.TableID = a1.TableID and a.SoLenh =a1.solenh  and a.NgayXuat=a1.ngayxuat and  a.LIneID =a1.LIneID and a.MaLenh =a1.MaLenh ) " & _
                         "  and   isnull (TYLE_TTE,0) >1 "



            i_dt = GetDataTable(p_SQL, p_SQL)


            For i As Integer = 0 To i_dt.Rows.Count - 1
                ' p_Check = CheckItemToScada2(i_dt.Rows(i).Item("NGAY_DKY").ToString().Trim)
                s_do = New Connect2SapEx.STR_E5()
                If i_dt.Rows(i).Item("MA_HHOA").ToString() = "" Then
                    s_do.Ma_Hhoa = i_dt.Rows(i).Item("Map_Scadar").ToString()
                Else
                    s_do.Ma_Hhoa = i_dt.Rows(i).Item("MA_HHOA").ToString()
                End If


                s_do.Outbound = i_solenh

                'NGAY_DKY,NGAY_BD,NGAY_KT,SO_CTU,MA_LENH,CARD_DATA,MA_NGAN,MA_HHOA,MA_HONG,MA_KHO,
                s_do.Ngay_Dky = IIf(i_dt.Rows(i).Item("NGAY_DKY").ToString.Trim = "", i_dt.Rows(i).Item("NGAY_DKY").ToString(), i_dt.Rows(i).Item("NGAY_DKY").ToString.Trim)
                s_do.Ngay_Bd = i_dt.Rows(i).Item("NGAY_BD").ToString()
                s_do.Ngay_Kt = i_dt.Rows(i).Item("NGAY_KT").ToString()
                s_do.Card_Data = i_dt.Rows(i).Item("CARD_DATA").ToString()

                'Integer.TryParse(i_dt.Rows(i).Item("MA_HONG").ToString.Trim, s_do.Ma_Hong)

                s_do.Compartment = i_dt.Rows(i).Item("MaNgan").ToString()
                s_do.Gv = i_dt.Rows(i).Item("GV").ToString()

                s_do.Gst = i_dt.Rows(i).Item("GST").ToString()
                Try
                    Double.TryParse(i_dt.Rows(i).Item("GST_TDH").ToString.Trim, p_GST_TDH)
                    If p_GST_TDH > 0 Then
                        s_do.Gst = i_dt.Rows(i).Item("GST_TDH").ToString()
                    End If
                Catch ex As Exception
                    's_do.Gst = i_dt.Rows(i).Item("GST").ToString()
                End Try

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
                s_do.Avg_Ctl = GetCTLE5(i_dt.Rows(i).Item("TableID").ToString())    ' i_dt.Rows(i).Item("AVG_CTL").ToString()
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



            For i As Integer = 0 To i_dt.Rows.Count - 1
                p_SQL = "INSERT INTO [tblLenhXuatE5_ToSAP]  ([SoLenh] ,[TableID],[MaLenh],[LineID] ,[NgayXuat],MaNgan, Row_ID,[UserID],[CreateDate])" & _
                            "  VALUES(" & _
                            "'" & i_dt.Rows(i).Item("SoLenh").ToString() & "'" & _
                            ",'" & i_dt.Rows(i).Item("TableID").ToString() & "'" & _
                            ",'" & i_dt.Rows(i).Item("MaLenh").ToString() & "'" & _
                            ",'" & i_dt.Rows(i).Item("LineID").ToString() & "'" & _
                             ",'" & i_dt.Rows(i).Item("NgayXuat").ToString() & "'" & _
                             ",'" & i_dt.Rows(i).Item("MaNgan").ToString() & "'" & _
                             "," & i_dt.Rows(i).Item("Row_ID").ToString() & "" & _
                            ",'" & g_UserName & "'" & _
                            ",Getdate()" & _
                            ")"
                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                End If
            Next
            Return t_do

        Catch ex As Exception
            p_Desc = ex.Message
            Return Nothing
        End Try
    End Function


    Private Function mdlExtras_ConfirmExt(ByVal i_solenh As String, _
                                           ByVal i_dt_Header As DataTable, ByVal i_dt_Material As DataTable, _
                                           ByVal ii_dt As DataTable, ByRef p_Desc As String) As Connect2SapEx.STR_EXTTable

        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim lt_ret2 As Connect2SapEx.BAPIRET2Table
        Dim t_do As Connect2SapEx.STR_EXTTable  '  Str_E5Table
        Dim s_do As Connect2SapEx.STR_EXT ' Str_E5
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_Check As String
        Dim p_tbl As DataTable
        Dim p_SQL As String
        Dim i_dt As DataTable
        Dim p_Count As Integer

        Dim p_Value As Decimal
        Dim p_RowArr() As DataRow

        Dim p_RowArr22() As DataRow

        Dim p_SoBienBan As String = ""
        Dim p_TongSoNiem As Integer
        Dim p_StringValue1 As String = ""
        Dim p_NgayTichKe As Date
        Dim p_TichKe As String = ""
        Dim p_DataSet As DataSet

        p_Desc = ""
        Try

            t_do = New Connect2SapEx.STR_EXTTable()


            For i As Integer = 0 To i_dt_Material.Rows.Count - 1
                ' p_Check = CheckItemToScada2(i_dt.Rows(i).Item("NGAY_DKY").ToString().Trim)
                s_do = New Connect2SapEx.STR_EXT()
                s_do.Structure0 = "ZTB_LIPS_EXT"


                s_do.Valuepart1 = i_solenh
                s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
                s_do.Valuepart3 = "TANK"
                s_do.Valuepart4 = i_dt_Material.Rows(i).Item("BEXUAT").ToString()

                t_do.Add(s_do)
                p_RowArr = ii_dt.Select("LineID='" & i_dt_Material.Rows(i).Item("LineID").ToString() & "'", "ThoiGianDau ASC, ThoiGianCuoi ASC")

                If p_RowArr.Length > 0 Then

                    'THoi gian dau
                    s_do = New Connect2SapEx.STR_EXT()
                    s_do.Structure0 = "ZTB_LIPS_EXT"



                    s_do.Valuepart1 = i_solenh
                    s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
                    s_do.Valuepart3 = "ZZERTIM"
                    s_do.Valuepart4 = Format(p_RowArr(0).Item("ThoiGianDau"), "HHmmss")

                    t_do.Add(s_do)

                    s_do = New Connect2SapEx.STR_EXT()
                    s_do.Structure0 = "ZTB_LIPS_EXT"


                    s_do.Valuepart1 = i_solenh
                    s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
                    s_do.Valuepart3 = "ZZERDAT"
                    s_do.Valuepart4 = Format(p_RowArr(0).Item("ThoiGianDau"), "yyyyMMdd")

                    t_do.Add(s_do)

                    'Thoi gian cuoi

                    s_do = New Connect2SapEx.STR_EXT()
                    s_do.Structure0 = "ZTB_LIPS_EXT"
                    s_do.Valuepart1 = i_solenh
                    s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
                    s_do.Valuepart3 = "ZZAETIM"
                    s_do.Valuepart4 = Format(p_RowArr(p_RowArr.Length - 1).Item("ThoiGianCuoi"), "HHmmss")

                    t_do.Add(s_do)

                    s_do = New Connect2SapEx.STR_EXT()
                    s_do.Structure0 = "ZTB_LIPS_EXT"


                    s_do.Valuepart1 = i_solenh
                    s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
                    s_do.Valuepart3 = "ZZAEDAT"
                    s_do.Valuepart4 = Format(p_RowArr(p_RowArr.Length - 1).Item("ThoiGianCuoi"), "yyyyMMdd")

                    t_do.Add(s_do)


                End If



                p_RowArr = ii_dt.Select("", "ThoiGianDau ASC")
                If p_RowArr.Length > 0 Then
                    s_do = New Connect2SapEx.STR_EXT()
                    s_do.Structure0 = "ZTB_LIPS_EXT"
                    s_do.Valuepart1 = i_solenh
                    s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
                    s_do.Valuepart3 = "WADAT_IST"
                    s_do.Valuepart4 = Format(p_RowArr(0).Item("ThoiGianDau"), "yyyyMMdd")
                    t_do.Add(s_do)
                End If


                p_RowArr = ii_dt.Select("LineID='" & i_dt_Material.Rows(i).Item("LineID").ToString() & "'", "SL_llkebd ASC, SL_llkekt ASC")

                If p_RowArr.Length > 0 Then
                    Try
                        s_do = New Connect2SapEx.STR_EXT()
                        s_do.Structure0 = "ZTB_LIPS_EXT"
                        s_do.Valuepart1 = i_solenh
                        s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
                        s_do.Valuepart3 = "ZZMATER_F"
                        Decimal.TryParse(p_RowArr(0).Item("SL_llkebd").ToString.Trim, p_Value)
                        s_do.Valuepart4 = Math.Round(p_Value)
                        t_do.Add(s_do)
                    Catch ex As Exception

                    End Try


                    Try
                        s_do = New Connect2SapEx.STR_EXT()
                        s_do.Structure0 = "ZTB_LIPS_EXT"
                        s_do.Valuepart1 = i_solenh
                        s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
                        s_do.Valuepart3 = "ZZRACK_METER"
                        ' Decimal.TryParse(p_RowArr(0).Item("SL_llkebd").ToString.Trim, p_Value)
                        s_do.Valuepart4 = p_RowArr(0).Item("Maluuluongke").ToString.Trim
                        t_do.Add(s_do)

                    Catch ex As Exception

                    End Try

                    Try
                        s_do = New Connect2SapEx.STR_EXT()
                        s_do.Structure0 = "ZTB_LIPS_EXT"
                        s_do.Valuepart1 = i_solenh
                        s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
                        s_do.Valuepart3 = "ZZMATER_L"
                        Decimal.TryParse(p_RowArr(p_RowArr.Length - 1).Item("SL_llkekt").ToString.Trim, p_Value)
                        s_do.Valuepart4 = Math.Round(p_Value)
                        t_do.Add(s_do)
                    Catch ex As Exception

                    End Try

                End If
            Next






            'anhqh 
            '20191029
            'Them moi gia tri dung cho Bien ban giao nhan
            p_SQL = "select SoBienBan, SoTichKe, NgayTichKe from tblTichKe where SoLenh ='" & i_solenh & "' " &
                        "   and NgayTichKe = '" & CDate(i_dt_Header.Rows(0).Item("NgayTichKe")).ToString() & "'; " &
                        "   select SoLenh,  MaNgan, LineID, MaHangHoa,MaLuuLuongKe,MaEntry as HH   " &
                        "   ,SoLenh   +  LineID +  MaNgan as Value1  " &
                        "   from fpt_tblLenhXuatChiTietE5_V where SoLenh ='" & i_solenh & "';"
            p_DataSet = GetDataSet(p_SQL, p_SQL)

            If Not p_DataSet Is Nothing Then
                If p_DataSet.Tables.Count > 0 Then
                    p_tbl = p_DataSet.Tables(1)
                    If p_tbl.Rows.Count > 0 And p_DataSet.Tables(0).Rows.Count > 0 Then
                        p_NgayTichKe = CDate(p_DataSet.Tables(0).Rows(0).Item("NgayTichKe"))
                        p_SoBienBan = p_DataSet.Tables(0).Rows(0).Item("SoBienBan").ToString.Trim
                        p_TichKe = p_DataSet.Tables(0).Rows(0).Item("SoTichKe").ToString.Trim

                        For p_Count = 0 To p_tbl.Rows.Count - 1
                            Integer.TryParse(i_dt_Header.Rows(0).Item("TongSoNiem").ToString.Trim, p_TongSoNiem)
                            ' p_SoBienBan =
                            Try
                                '1. OUTBOUND (số lệnh)
                                s_do = New Connect2SapEx.STR_EXT()
                                s_do.Structure0 = "ZTB_BBGN_EXT"
                                s_do.Valuepart1 = p_tbl.Rows(p_Count).Item("Value1").ToString.Trim  '   i_solenh                            
                                s_do.Valuepart3 = "OUTBOUND"
                                s_do.Valuepart4 = i_solenh
                                t_do.Add(s_do)
                                '2. LineID (số thứ tự mặt hàng)
                                s_do = New Connect2SapEx.STR_EXT()
                                s_do.Structure0 = "ZTB_BBGN_EXT"
                                s_do.Valuepart1 = p_tbl.Rows(p_Count).Item("Value1").ToString.Trim  '   i_solenh
                                s_do.Valuepart3 = "LINEID"
                                s_do.Valuepart4 = p_tbl.Rows(p_Count).Item("LineID").ToString.Trim
                                t_do.Add(s_do)
                                '3. SoTichKe (số tích kê)
                                s_do = New Connect2SapEx.STR_EXT()
                                s_do.Structure0 = "ZTB_BBGN_EXT"
                                s_do.Valuepart1 = p_tbl.Rows(p_Count).Item("Value1").ToString.Trim  '   i_solenh
                                s_do.Valuepart3 = "SOTICHKE"
                                s_do.Valuepart4 = p_TichKe
                                t_do.Add(s_do)
                                '4. NGAYTICHKE (Ngày tích kê)
                                s_do = New Connect2SapEx.STR_EXT()
                                s_do.Structure0 = "ZTB_BBGN_EXT"
                                s_do.Valuepart1 = p_tbl.Rows(p_Count).Item("Value1").ToString.Trim  '   i_solenh
                                s_do.Valuepart3 = "NGAYTICHKE"
                                s_do.Valuepart4 = CDate(p_NgayTichKe).ToString("yyyyMMdd")
                                t_do.Add(s_do)

                                '5. MATERIAL (mã mặt hàng)
                                s_do = New Connect2SapEx.STR_EXT()
                                s_do.Structure0 = "ZTB_BBGN_EXT"
                                s_do.Valuepart1 = p_tbl.Rows(p_Count).Item("Value1").ToString.Trim  '   i_solenh
                                s_do.Valuepart3 = "MATERIAL"
                                s_do.Valuepart4 = p_tbl.Rows(p_Count).Item("MaHangHoa").ToString.Trim
                                t_do.Add(s_do)
                                '6. COMPARTMENT (mã ngăn)
                                s_do = New Connect2SapEx.STR_EXT()
                                s_do.Structure0 = "ZTB_BBGN_EXT"
                                s_do.Valuepart1 = p_tbl.Rows(p_Count).Item("Value1").ToString.Trim  '   i_solenh
                                s_do.Valuepart3 = "COMPARTMENT"
                                s_do.Valuepart4 = p_tbl.Rows(p_Count).Item("MaNgan").ToString.Trim
                                t_do.Add(s_do)
                                '7. CCHH (chiều cao hầm hàng)
                                s_do = New Connect2SapEx.STR_EXT()
                                s_do.Structure0 = "ZTB_BBGN_EXT"
                                s_do.Valuepart1 = p_tbl.Rows(p_Count).Item("Value1").ToString.Trim  '   i_solenh
                                s_do.Valuepart3 = "CCHH"
                                s_do.Valuepart4 = p_tbl.Rows(p_Count).Item("HH").ToString.Trim
                                t_do.Add(s_do)
                                '8. MAHONG (mã họng xuất)
                                s_do = New Connect2SapEx.STR_EXT()
                                s_do.Structure0 = "ZTB_BBGN_EXT"
                                s_do.Valuepart1 = p_tbl.Rows(p_Count).Item("Value1").ToString.Trim  '   i_solenh
                                s_do.Valuepart3 = "MAHONG"
                                s_do.Valuepart4 = p_tbl.Rows(p_Count).Item("MaLuuLuongKe").ToString.Trim
                                t_do.Add(s_do)
                                '9. TONG_NIEM (tổng số niêm)
                                s_do = New Connect2SapEx.STR_EXT()
                                s_do.Structure0 = "ZTB_BBGN_EXT"
                                s_do.Valuepart1 = p_tbl.Rows(p_Count).Item("Value1").ToString.Trim  '   i_solenh
                                s_do.Valuepart3 = "TONG_NIEM"
                                s_do.Valuepart4 = p_TongSoNiem
                                t_do.Add(s_do)

                                '10. SOBBMAU (Số biên bản mẫu)
                                s_do = New Connect2SapEx.STR_EXT()
                                s_do.Structure0 = "ZTB_BBGN_EXT"
                                s_do.Valuepart1 = p_tbl.Rows(p_Count).Item("Value1").ToString.Trim  '   i_solenh
                                s_do.Valuepart3 = "SOBBMAU"
                                s_do.Valuepart4 = i_dt_Header.Rows(0).Item("SoBienBanMau").ToString()
                                t_do.Add(s_do)
                                '11. DOIGN Đội giao nhận
                                s_do = New Connect2SapEx.STR_EXT()
                                s_do.Structure0 = "ZTB_BBGN_EXT"
                                s_do.Valuepart1 = p_tbl.Rows(p_Count).Item("Value1").ToString.Trim  '   i_solenh
                                s_do.Valuepart3 = "DOIGN"
                                s_do.Valuepart4 = i_dt_Header.Rows(0).Item("Client").ToString()
                                t_do.Add(s_do)
                            Catch ex As Exception

                            End Try
                        Next





                    End If
                End If
            End If




            Return t_do

        Catch ex As Exception
            p_Desc = ex.Message
            Return Nothing
        End Try
    End Function


    'Private Function mdlExtras_ConfirmExt(ByVal i_solenh As String, _
    '                                        ByVal i_dt_Header As DataTable, ByVal i_dt_Material As DataTable, _
    '                                        ByVal ii_dt As DataTable, ByRef p_Desc As String) As Connect2SapEx.STR_EXTTable

    '    Dim l_c2sap As Connect2SapEx.Connect2Sap
    '    Dim lt_ret2 As Connect2SapEx.BAPIRET2Table
    '    Dim t_do As Connect2SapEx.STR_EXTTable  '  Str_E5Table
    '    Dim s_do As Connect2SapEx.STR_EXT ' Str_E5
    '    Dim l_async As IAsyncResult
    '    Dim l_isCompleted As Boolean
    '    Dim p_Check As String
    '    Dim p_tbl As DataTable
    '    Dim p_SQL As String
    '    Dim i_dt As DataTable

    '    Dim p_Value As Decimal
    '    Dim p_RowArr() As DataRow

    '    Dim p_RowArr22() As DataRow

    '    'Dim p_c2sql As Connect2SQL.Connect2SQL
    '    p_Desc = ""
    '    Try
    '        ' l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
    '        'lt_ret2 = New Connect2SapEx.BAPIRET2Table()
    '        t_do = New Connect2SapEx.STR_EXTTable()


    '        For i As Integer = 0 To i_dt_Material.Rows.Count - 1
    '            ' p_Check = CheckItemToScada2(i_dt.Rows(i).Item("NGAY_DKY").ToString().Trim)
    '            s_do = New Connect2SapEx.STR_EXT()
    '            s_do.Structure0 = "ZTB_LIPS_EXT"


    '            s_do.Valuepart1 = i_solenh
    '            s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
    '            s_do.Valuepart3 = "TANK"
    '            s_do.Valuepart4 = i_dt_Material.Rows(i).Item("BEXUAT").ToString()

    '            t_do.Add(s_do)
    '            p_RowArr = ii_dt.Select("LineID='" & i_dt_Material.Rows(i).Item("LineID").ToString() & "'", "ThoiGianDau ASC, ThoiGianCuoi ASC")

    '            If p_RowArr.Length > 0 Then

    '                'THoi gian dau
    '                s_do = New Connect2SapEx.STR_EXT()
    '                s_do.Structure0 = "ZTB_LIPS_EXT"



    '                s_do.Valuepart1 = i_solenh
    '                s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
    '                s_do.Valuepart3 = "ZZERTIM"
    '                s_do.Valuepart4 = Format(p_RowArr(0).Item("ThoiGianDau"), "HHmmss")

    '                t_do.Add(s_do)

    '                s_do = New Connect2SapEx.STR_EXT()
    '                s_do.Structure0 = "ZTB_LIPS_EXT"


    '                s_do.Valuepart1 = i_solenh
    '                s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
    '                s_do.Valuepart3 = "ZZERDAT"
    '                s_do.Valuepart4 = Format(p_RowArr(0).Item("ThoiGianDau"), "yyyyMMdd")

    '                t_do.Add(s_do)

    '                'Thoi gian cuoi

    '                s_do = New Connect2SapEx.STR_EXT()
    '                s_do.Structure0 = "ZTB_LIPS_EXT"



    '                s_do.Valuepart1 = i_solenh
    '                s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
    '                s_do.Valuepart3 = "ZZAETIM"
    '                s_do.Valuepart4 = Format(p_RowArr(p_RowArr.Length - 1).Item("ThoiGianCuoi"), "HHmmss")

    '                t_do.Add(s_do)

    '                s_do = New Connect2SapEx.STR_EXT()
    '                s_do.Structure0 = "ZTB_LIPS_EXT"


    '                s_do.Valuepart1 = i_solenh
    '                s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
    '                s_do.Valuepart3 = "ZZAEDAT"
    '                s_do.Valuepart4 = Format(p_RowArr(p_RowArr.Length - 1).Item("ThoiGianCuoi"), "yyyyMMdd")

    '                t_do.Add(s_do)


    '            End If



    '            p_RowArr = ii_dt.Select("", "ThoiGianDau ASC")
    '            If p_RowArr.Length > 0 Then
    '                s_do = New Connect2SapEx.STR_EXT()
    '                s_do.Structure0 = "ZTB_LIPS_EXT"
    '                s_do.Valuepart1 = i_solenh
    '                s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
    '                s_do.Valuepart3 = "WADAT_IST"
    '                s_do.Valuepart4 = Format(p_RowArr(0).Item("ThoiGianDau"), "yyyyMMdd")
    '                t_do.Add(s_do)
    '            End If


    '            p_RowArr = ii_dt.Select("LineID='" & i_dt_Material.Rows(i).Item("LineID").ToString() & "'", "SL_llkebd ASC, SL_llkekt ASC")

    '            If p_RowArr.Length > 0 Then
    '                Try
    '                    s_do = New Connect2SapEx.STR_EXT()
    '                    s_do.Structure0 = "ZTB_LIPS_EXT"
    '                    s_do.Valuepart1 = i_solenh
    '                    s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
    '                    s_do.Valuepart3 = "ZZMATER_F"
    '                    Decimal.TryParse(p_RowArr(0).Item("SL_llkebd").ToString.Trim, p_Value)
    '                    s_do.Valuepart4 = Math.Round(p_Value)
    '                    t_do.Add(s_do)
    '                Catch ex As Exception

    '                End Try


    '                Try
    '                    s_do = New Connect2SapEx.STR_EXT()
    '                    s_do.Structure0 = "ZTB_LIPS_EXT"
    '                    s_do.Valuepart1 = i_solenh
    '                    s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
    '                    s_do.Valuepart3 = "ZZRACK_METER"
    '                    ' Decimal.TryParse(p_RowArr(0).Item("SL_llkebd").ToString.Trim, p_Value)
    '                    s_do.Valuepart4 = p_RowArr(0).Item("Maluuluongke").ToString.Trim
    '                    t_do.Add(s_do)

    '                Catch ex As Exception

    '                End Try

    '                Try
    '                    s_do = New Connect2SapEx.STR_EXT()
    '                    s_do.Structure0 = "ZTB_LIPS_EXT"
    '                    s_do.Valuepart1 = i_solenh
    '                    s_do.Valuepart2 = i_dt_Material.Rows(i).Item("LineID").ToString()
    '                    s_do.Valuepart3 = "ZZMATER_L"
    '                    Decimal.TryParse(p_RowArr(p_RowArr.Length - 1).Item("SL_llkekt").ToString.Trim, p_Value)
    '                    s_do.Valuepart4 = Math.Round(p_Value)
    '                    t_do.Add(s_do)
    '                Catch ex As Exception

    '                End Try

    '            End If
    '        Next







    '        Return t_do

    '    Catch ex As Exception
    '        p_Desc = ex.Message
    '        Return Nothing
    '    End Try
    'End Function



    'FES44
    '20141118
    Private Function GetCTLE5(ByVal p_TableID As String) As String
        'Private Function GetCTLE5(ByVal p_Date As Date, ByVal p_MaLenh As String, ByVal p_LineID As String) As String
        ' Dim l_c2sql As Connect2SQL.Connect2SQL
        Dim p_Value As Double
        Dim p_SQL As String
        Dim p_DataTable As DataTable

        GetCTLE5 = "0"
        p_Value = 0
        'FPT_fm_GetVCF_FromE5
        'p_SQL = "select dbo.fm_GetVCF_FromE5 ('" & p_Date.ToString("yyyyMMdd") & "','" & p_MaLenh.ToString.Trim & "','" & p_LineID & "') as VCF "

        p_SQL = "select dbo.FPT_fm_GetVCF_FromE5 ('" & p_TableID & "') as VCF "
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


    'Private Function mdlSyncDeliveries_Created(ByVal i_dt_Header As DataTable, _
    '                                          ByVal i_dt_Material As DataTable, _
    '                                          ByVal i_dt_Details As DataTable, _
    '                                          ByRef o_ztb_Temp As Connect2SAP.Str_PhieuXuatTable) As Boolean
    '    Dim l_loaiphieu As String

    '    Try
    '        l_loaiphieu = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()

    '        If l_loaiphieu = "V144" Then
    '            '-----------------------------------------------------------------
    '            '   Create ztb khi không có TR                
    '            '-----------------------------------------------------------------
    '            If i_dt_Details.Rows.Count > 0 Then
    '                If mdlSyncDeliveries_NoShipment(i_dt_Header, i_dt_Material, i_dt_Details, o_ztb_Temp) Then
    '                    Return True
    '                Else
    '                    Return False
    '                End If
    '            End If
    '        Else
    '            '-----------------------------------------------------------------
    '            '   Create ztb khi có TR                
    '            '-----------------------------------------------------------------
    '            If i_dt_Details.Rows.Count > 0 Then
    '                If mdlSyncDeliveries_Shipment(i_dt_Header, i_dt_Material, i_dt_Details, o_ztb_Temp) Then
    '                    Return True
    '                Else
    '                    Return False
    '                End If
    '            End If
    '        End If

    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function





    Private Function mdlSyncDeliveries_Created(ByVal i_dt_Header As DataTable, _
                                              ByVal i_dt_Material As DataTable, _
                                              ByVal i_dt_Details As DataTable, _
                                              ByRef o_ztb_Temp As Connect2SapEx.Str_PhieuXuatTable) As Boolean
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
                                               ByRef o_ztb_Temp As Connect2SapEx.Str_PhieuXuatTable) As Boolean
        Dim l_str As Connect2SapEx.Str_PhieuXuat
        Dim p_RowArr() As DataRow
        Dim l_lineid, _
            l_mangan, _
            l_chieucaohamhang, _
            l_loaiphieu _
            As String

        Dim l_quantity(), _
            l_quantity_conf(), _
            l_nhietdo(), _
            l_tytrong(), _
             l_nhietdoDuXuat(), _
            l_tytrongDuXuat(), _
            l_meter_s(), _
            l_meter_e() _
            As Decimal
        Dim p_NHietDoBQ22 As Decimal
        Dim p_TyTrongBQ22 As Decimal
        Dim l_meter_n() _
            As String

        Dim l_lineid_int As Integer

        Dim l_vanchuyen As String
        Dim l_count() As Integer

        Dim p_NhietDoBQ As Double
        Dim p_TyTrongBQ As Double
        Dim p_Str As String

        Dim p_Value As Decimal
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

            'anhqh 20190227 them gia tri luu tinh voi du xuat
            ReDim l_nhietdoDuXuat(l_item_max)
            ReDim l_tytrongDuXuat(l_item_max)


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


                l_nhietdoDuXuat(l_lineid_int) = l_nhietdoDuXuat(l_lineid_int) + _
                                         Convert.ToDecimal(i_dt_Details.Rows(i).Item("NhietDo").ToString()) * _
                                         Convert.ToDecimal(i_dt_Details.Rows(i).Item("SoLuongDuXuat").ToString())

                ' l_tytrong(l_lineid_int) = l_tytrong(l_lineid_int) + Convert.ToDecimal(i_dt_Details.Rows(i).Item("TyTrong_15").ToString())
                l_tytrong(l_lineid_int) = l_tytrong(l_lineid_int) + Convert.ToDecimal(i_dt_Details.Rows(i).Item("TyTrong_15").ToString()) * _
                                                                        Convert.ToDecimal(i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString())

                l_tytrongDuXuat(l_lineid_int) = l_tytrongDuXuat(l_lineid_int) + Convert.ToDecimal(i_dt_Details.Rows(i).Item("TyTrong_15").ToString()) * _
                                                                     Convert.ToDecimal(i_dt_Details.Rows(i).Item("SoLuongDuXuat").ToString())




                l_meter_n(l_lineid_int) = i_dt_Details.Rows(i).Item("MaLuuLuongKe").ToString()
                If i_dt_Details.Rows(i).Item("sl_llkebd").ToString() <> "" Then
                    If l_meter_s(l_lineid_int) > Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkebd").ToString()) Then
                        l_meter_s(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkebd").ToString())
                    Else
                        If l_meter_s(l_lineid_int) = 0 Then
                            l_meter_s(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkebd").ToString())
                        End If
                    End If

                Else
                    l_meter_s(l_lineid_int) = 0
                End If
                If i_dt_Details.Rows(i).Item("sl_llkekt").ToString() <> "" Then
                    If l_meter_e(l_lineid_int) < Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkekt").ToString()) Then
                        l_meter_e(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkekt").ToString())
                    Else
                        If l_meter_e(l_lineid_int) = 0 Then
                            l_meter_e(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkekt").ToString())
                        End If
                    End If
                Else
                    l_meter_e(l_lineid_int) = 0
                End If


                l_count(l_lineid_int) = l_count(l_lineid_int) + 1
                If p_NIEM_MM = True Then
                    p_Str = ""
                    If i_dt_Details.Rows(i).Item("MaEntry").ToString.ToString.Trim <> "" Then
                        If i_dt_Details.Rows(i).Item("MaEntry") > 0 Then
                            p_Str = "+"
                        End If
                    End If
                    l_chieucaohamhang = l_chieucaohamhang & p_KYHIEU_NIEM & Right(i_dt_Details.Rows(i).Item("MaNgan").ToString(), 1) & ": " & p_Str & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "mm; "
                Else
                    l_chieucaohamhang = l_chieucaohamhang & p_KYHIEU_NIEM & i_dt_Details.Rows(i).Item("MaNgan").ToString() & ": " & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "; "
                End If
                'l_chieucaohamhang = l_chieucaohamhang & "H" & i_dt_Details.Rows(i).Item("MaNgan").ToString() & ": " & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "; "
            Next

            For i As Integer = 0 To i_dt_Material.Rows.Count - 1
                l_str = New Connect2SapEx.Str_PhieuXuat()
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
                l_str.Vehicle = UCase(i_dt_Header.Rows(0).Item("MaPhuongTien").ToString())
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
                'If p_TONGDUXUAT = "1" Then
                '    l_str.Quantity = i_dt_Material.Rows(i).Item("TongDuXuat").ToString()
                'Else
                '    l_str.Quantity = i_dt_Material.Rows(i).Item("TongXuat").ToString()
                'End If
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
                If UCase(l_vanchuyen) = "BO" Or UCase(l_vanchuyen) = "SAT" Then
                    If p_TONGDUXUAT = "1" Then  'Lay theo du xuat
                        If p_XITEC_OPTION = True Then  'Dung cho B12
                            If i_dt_Header.Rows(0).Item("XITEC_OPTION").ToString() = "Y" Then   ''Lay theo thuc xuat
                                l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
                            Else   'Lay theo du xuat
                                l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                            End If
                            'l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
                        Else
                            l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                        End If

                    Else ' Lay theo thuc xuat
                        If p_XITEC_OPTION = True Then  'Dung cho B12
                            If i_dt_Header.Rows(0).Item("XITEC_OPTION").ToString() = "Y" Then   ''Lay theo du xuat
                                l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                            Else  ' Lay theo thuc xuat
                                l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
                            End If
                            'l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                        Else
                            l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
                        End If

                    End If
                    'l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                Else
                    'l_str.Quantity_Confirm = l_quantity_conf(Convert.ToDecimal(l_lineid))
                    If p_TONGDUXUATTHUY = "1" Then  'Lay theo du xuat
                        'If p_XITEC_OPTION = True Then  'Dung cho B12
                        '    l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
                        'Else
                        l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                        ' End If

                    Else ' Lay theo thuc xuat
                        'If p_XITEC_OPTION = True Then  'Dung cho B12
                        '    l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                        'Else
                        l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
                        'End If

                    End If
                End If


                Try
                    'anhqh
                    '20170313
                    'Them truong hop cua KV3 voi truong hop xuat FO thi lay gia tri thuc xuat
                    If Not p_HangHoa_SoLuongSAP Is Nothing Then
                        If p_HangHoa_SoLuongSAP.Rows.Count > 0 Then
                            Dim p_Datarow() As DataRow
                            p_Datarow = p_HangHoa_SoLuongSAP.Select("MaHangHoa='" & i_dt_Material.Rows(i).Item("MaHangHoa").ToString() & "'")
                            If p_Datarow.Length > 0 Then
                                If UCase(l_vanchuyen) = "BO" Or UCase(l_vanchuyen) = "SAT" Then
                                    If p_Datarow(0).Item("TONGDUXUAT").ToString.Trim = "1" Then  'Lay theo du xuat
                                        l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                                    Else ' Lay theo thuc xuat
                                        l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
                                    End If
                                    'l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                                Else
                                    'l_str.Quantity_Confirm = l_quantity_conf(Convert.ToDecimal(l_lineid))
                                    If p_Datarow(0).Item("TONGDUXUAT_THUY").ToString.Trim = "1" Then  'Lay theo du xuat
                                        l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                                    Else ' Lay theo thuc xuat
                                        l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
                                    End If
                                End If

                            End If
                        End If
                    End If
                Catch ex As Exception

                End Try

                Try
                    Double.TryParse(i_dt_Material(i).Item("NhietDo_BQGQ").ToString.Trim, p_NhietDoBQ)
                    Double.TryParse(i_dt_Material(i).Item("D15_BQGQ").ToString.Trim, p_TyTrongBQ)
                    If p_NhietDoBQ > 0 Then
                        l_str.Temp_Confirm = p_NhietDoBQ
                    Else

                        'anhqh 20190227  lay theo cau hinh
                        'xu ly loi cho TNB dua sai ty trong len SAP
                        If UCase(l_vanchuyen) = "BO" Or UCase(l_vanchuyen) = "SAT" Then
                            If p_TONGDUXUAT = "1" Then  'Lay theo du xuat
                                If p_XITEC_OPTION = True Then  'Dung cho B12
                                    If i_dt_Header.Rows(0).Item("XITEC_OPTION").ToString() = "Y" Then   ''Lay theo thuc xuat                                       
                                        p_NHietDoBQ22 = NhietDoLamTron(l_nhietdo(Convert.ToDecimal(l_lineid)), 0)
                                    Else   'Lay theo du xuat
                                        p_NHietDoBQ22 = NhietDoLamTron(l_nhietdoDuXuat(Convert.ToDecimal(l_lineid)), 0)
                                    End If
                                Else
                                    p_NHietDoBQ22 = NhietDoLamTron(l_nhietdoDuXuat(Convert.ToDecimal(l_lineid)), 0)
                                End If

                            Else ' Lay theo thuc xuat
                                If p_XITEC_OPTION = True Then  'Dung cho B12
                                    If i_dt_Header.Rows(0).Item("XITEC_OPTION").ToString() = "Y" Then   ''Lay theo du xuat
                                        p_NHietDoBQ22 = NhietDoLamTron(l_nhietdoDuXuat(Convert.ToDecimal(l_lineid)), 0)
                                    Else  ' Lay theo thuc xuat
                                        p_NHietDoBQ22 = NhietDoLamTron(l_nhietdo(Convert.ToDecimal(l_lineid)), 0)
                                    End If
                                Else
                                    p_NHietDoBQ22 = NhietDoLamTron(l_nhietdo(Convert.ToDecimal(l_lineid)), 0)
                                End If
                            End If
                        Else
                            'l_str.Quantity_Confirm = l_quantity_conf(Convert.ToDecimal(l_lineid))
                            If p_TONGDUXUATTHUY = "1" Then  'Lay theo du xuat                                
                                'l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                                p_NHietDoBQ22 = NhietDoLamTron(l_nhietdoDuXuat(Convert.ToDecimal(l_lineid)), 0)
                            Else ' Lay theo thuc xuat
                               
                                p_NHietDoBQ22 = NhietDoLamTron(l_nhietdo(Convert.ToDecimal(l_lineid)), 0)
                                
                            End If
                        End If

                        ' l_nhietdo(Convert.ToDecimal(l_lineid)) = NhietDoLamTron(l_nhietdo(Convert.ToDecimal(l_lineid)), 0)
                        l_str.Temp_Confirm = NhietDoLamTron(p_NHietDoBQ22 / l_str.Quantity_Confirm, 2)


                    End If

                    If p_TyTrongBQ > 0 Then
                        Try
                            If i_dt_Material(i).Item("D15Multi") <= 1 Then
                                l_str.Dens_Confirm = i_dt_Material(i).Item("D15Min")
                            Else
                                l_str.Dens_Confirm = p_TyTrongBQ
                            End If
                        Catch ex As Exception
                            l_str.Dens_Confirm = p_TyTrongBQ
                        End Try
                      
                    Else
                        'Convert.ToDecimal(l_lineid))
                        Try

                            'anhqh 20190227  lay theo cau hinh
                            'xu ly loi cho TNB dua sai ty trong len SAP
                            If UCase(l_vanchuyen) = "BO" Or UCase(l_vanchuyen) = "SAT" Then
                                If p_TONGDUXUAT = "1" Then  'Lay theo du xuat
                                    If p_XITEC_OPTION = True Then  'Dung cho B12
                                        If i_dt_Header.Rows(0).Item("XITEC_OPTION").ToString() = "Y" Then   ''Lay theo thuc xuat                                       
                                            p_TyTrongBQ22 = NhietDoLamTron(l_tytrong(Convert.ToDecimal(l_lineid)), 4)
                                        Else   'Lay theo du xuat
                                            p_TyTrongBQ22 = NhietDoLamTron(l_tytrongDuXuat(Convert.ToDecimal(l_lineid)), 4)
                                        End If
                                    Else
                                        p_TyTrongBQ22 = NhietDoLamTron(l_tytrongDuXuat(Convert.ToDecimal(l_lineid)), 4)
                                    End If

                                Else ' Lay theo thuc xuat
                                    If p_XITEC_OPTION = True Then  'Dung cho B12
                                        If i_dt_Header.Rows(0).Item("XITEC_OPTION").ToString() = "Y" Then   ''Lay theo du xuat
                                            p_TyTrongBQ22 = NhietDoLamTron(l_tytrongDuXuat(Convert.ToDecimal(l_lineid)), 4)
                                        Else  ' Lay theo thuc xuat
                                            p_TyTrongBQ22 = NhietDoLamTron(l_tytrong(Convert.ToDecimal(l_lineid)), 4)
                                        End If
                                    Else
                                        p_TyTrongBQ22 = NhietDoLamTron(l_tytrong(Convert.ToDecimal(l_lineid)), 4)
                                    End If
                                End If
                            Else
                                'l_str.Quantity_Confirm = l_quantity_conf(Convert.ToDecimal(l_lineid))
                                If p_TONGDUXUATTHUY = "1" Then  'Lay theo du xuat                                
                                    'l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                                    p_TyTrongBQ22 = NhietDoLamTron(l_tytrongDuXuat(Convert.ToDecimal(l_lineid)), 4)
                                Else ' Lay theo thuc xuat

                                    p_NHietDoBQ22 = NhietDoLamTron(l_nhietdo(Convert.ToDecimal(l_lineid)), 0)

                                End If
                            End If

                            l_str.Dens_Confirm = p_TyTrongBQ22 / l_str.Quantity_Confirm
                            ' l_str.Dens_Confirm = NhietDoLamTron(l_tytrong(Convert.ToDecimal(l_lineid)), 4) / l_str.Quantity_Confirm
                            l_str.Dens_Confirm = NhietDoLamTron(l_str.Dens_Confirm, 4)


                            If i_dt_Material(i).Item("D15Multi") <= 1 Then
                                l_str.Dens_Confirm = i_dt_Material(i).Item("D15Min")
                                'Else
                                ' l_str.Dens_Confirm = p_TyTrongBQ
                            End If
                        Catch ex As Exception
                            'l_str.Dens_Confirm = NhietDoLamTron(l_tytrong(Convert.ToDecimal(l_lineid)), 4) / l_str.Quantity_Confirm
                            'l_str.Dens_Confirm = NhietDoLamTron(l_str.Dens_Confirm, 4)
                        End Try

                        If l_str.Dens_Confirm <= 0 Then
                            l_str.Dens_Confirm = NhietDoLamTron(l_tytrong(Convert.ToDecimal(l_lineid)), 4) / l_str.Quantity_Confirm
                            l_str.Dens_Confirm = NhietDoLamTron(l_str.Dens_Confirm, 4)
                        End If
                        '' l_str.Dens_Confirm = NhietDoLamTron(l_tytrong(Convert.ToDecimal(l_lineid)), 0) / l_str.Quantity_Confirm
                        ''l_str.Dens_Confirm = NhietDoLamTron(l_str.Dens_Confirm, 4)
                        '  l_str.Dens_Confirm = NhietDoLamTron(NhietDoLamTron(l_tytrong(Convert.ToDecimal(l_lineid)), 0) / l_str.Quantity_Confirm, 4)
                    End If

                Catch ex As Exception
                    l_nhietdo(Convert.ToDecimal(l_lineid)) = NhietDoLamTron(l_nhietdo(Convert.ToDecimal(l_lineid)), 0)
                    l_str.Temp_Confirm = NhietDoLamTron(l_nhietdo(Convert.ToDecimal(l_lineid)) / l_quantity_conf(Convert.ToDecimal(l_lineid)), 2)  'Math.Round(l_nhietdo(Convert.ToDecimal(l_lineid)) / l_quantity_conf(Convert.ToDecimal(l_lineid)), 2)


                    l_str.Dens_Confirm = NhietDoLamTron(NhietDoLamTron(l_tytrong(Convert.ToDecimal(l_lineid)), 4) / l_str.Quantity_Confirm, 4)

                End Try


                'anhqh  
                '20181018
                'Ngày tháng lấy theo 

                p_RowArr = i_dt_Details.Select("", "ThoiGianDau asc")
                If p_RowArr.Length > 0 Then
                    l_str.Date_Nd = Format(p_RowArr(0).Item("ThoiGianDau"), "yyyy-MM-dd")
                    l_str.Time_Nd = Format(p_RowArr(0).Item("ThoiGianDau"), "HH:mm:ss")
                Else
                    If i_dt_Header.Rows(0).Item("NgayXuat") <= i_dt_Details.Rows(0).Item("ThoiGianDau") Then
                        l_str.Date_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "yyyy-MM-dd")
                    End If
                    l_str.Time_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "HH:mm:ss")
                End If

                '-----------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------------------------
                '   Tính lại số lưu lượng kế
                '-----------------------------------------------------------------------------------------
                l_str.Meter_No = l_meter_n(l_lineid)
                'anhqh  20180609
                p_Value = l_meter_s(l_lineid)
                l_str.Meter_Start = Math.Round(p_Value, 0) ' l_meter_s(l_lineid)  '' Convert.ToInt32(l_meter_s(l_lineid))
                p_Value = l_meter_e(l_lineid)
                l_str.Meter_End = Math.Round(p_Value, 0)  'l_meter_e(l_lineid) ' Convert.ToInt32(l_meter_e(l_lineid))
                '-----------------------------------------------------------------------------------------

                o_ztb_Temp.Add(l_str)
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function





    'Public Function mdlSyncDeliveries_NoShipment(ByVal i_dt_Header As DataTable, _
    '                                           ByVal i_dt_Material As DataTable, _
    '                                           ByVal i_dt_Details As DataTable, _
    '                                           ByRef o_ztb_Temp As Connect2SapEx.Str_PhieuXuatTable) As Boolean
    '    Dim l_str As Connect2SapEx.Str_PhieuXuat
    '    Dim l_lineid, _
    '        l_mangan, _
    '        l_chieucaohamhang, _
    '        l_loaiphieu _
    '        As String

    '    Dim l_quantity(), _
    '        l_quantity_conf(), _
    '        l_nhietdo(), _
    '        l_tytrong(), _
    '        l_meter_s(), _
    '        l_meter_e() _
    '        As Decimal

    '    Dim l_meter_n() _
    '        As String

    '    Dim l_lineid_int As Integer

    '    Dim l_vanchuyen As String
    '    Dim l_count() As Integer

    '    Dim p_NhietDoBQ As Double
    '    Dim p_TyTrongBQ As Double
    '    Dim p_Str As String

    '    Try
    '        '-----------------------------------------------------------------
    '        '   Tìm Item lớn nhất
    '        '-----------------------------------------------------------------
    '        Dim l_item_max As Integer
    '        l_item_max = 0
    '        Try
    '            For i As Integer = 0 To i_dt_Material.Rows.Count - 1
    '                If l_item_max <= Convert.ToInt32(i_dt_Material.Rows(i).Item("LineId").ToString()) Then
    '                    l_item_max = Convert.ToInt32(i_dt_Material.Rows(i).Item("LineId").ToString())
    '                End If
    '            Next
    '        Catch ex As Exception
    '            Return False
    '        End Try
    '        '-----------------------------------------------------------------
    '        '   Tính trung bình tỉ trọng
    '        '   Tính bình quân gia quyền nhiệt độ
    '        '-----------------------------------------------------------------
    '        ReDim l_quantity(l_item_max)
    '        ReDim l_quantity_conf(l_item_max)
    '        ReDim l_nhietdo(l_item_max)
    '        ReDim l_tytrong(l_item_max)
    '        ReDim l_count(l_item_max)
    '        ReDim l_meter_n(l_item_max)
    '        ReDim l_meter_s(l_item_max)
    '        ReDim l_meter_e(l_item_max)
    '        l_chieucaohamhang = String.Empty

    '        For i As Integer = 0 To i_dt_Details.Rows.Count - 1
    '            l_lineid_int = Convert.ToInt32(i_dt_Details.Rows(i).Item("LineID").ToString())

    '            l_quantity(l_lineid_int) = l_quantity(l_lineid_int) + Convert.ToDecimal(i_dt_Details.Rows(i).Item("SoLuongDuXuat").ToString())
    '            l_quantity_conf(l_lineid_int) = l_quantity_conf(l_lineid_int) + Convert.ToDecimal(i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString())
    '            l_nhietdo(l_lineid_int) = l_nhietdo(l_lineid_int) + _
    '                                      Convert.ToDecimal(i_dt_Details.Rows(i).Item("NhietDo").ToString()) * _
    '                                      Convert.ToDecimal(i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString())

    '            l_tytrong(l_lineid_int) = l_tytrong(l_lineid_int) + Convert.ToDecimal(i_dt_Details.Rows(i).Item("TyTrong_15").ToString())

    '            l_meter_n(l_lineid_int) = i_dt_Details.Rows(i).Item("MaLuuLuongKe").ToString()
    '            If i_dt_Details.Rows(i).Item("sl_llkebd").ToString() <> "" Then
    '                If l_meter_s(l_lineid_int) > Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkebd").ToString()) Then
    '                    l_meter_s(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkebd").ToString())
    '                Else
    '                    If l_meter_s(l_lineid_int) = 0 Then
    '                        l_meter_s(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkebd").ToString())
    '                    End If
    '                End If

    '            Else
    '                l_meter_s(l_lineid_int) = 0
    '            End If
    '            If i_dt_Details.Rows(i).Item("sl_llkekt").ToString() <> "" Then
    '                If l_meter_e(l_lineid_int) < Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkekt").ToString()) Then
    '                    l_meter_e(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkekt").ToString())
    '                Else
    '                    If l_meter_e(l_lineid_int) = 0 Then
    '                        l_meter_e(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkekt").ToString())
    '                    End If
    '                End If
    '            Else
    '                l_meter_e(l_lineid_int) = 0
    '            End If


    '            l_count(l_lineid_int) = l_count(l_lineid_int) + 1
    '            If p_NIEM_MM = True Then
    '                p_Str = ""
    '                If i_dt_Details.Rows(i).Item("MaEntry").ToString.ToString.Trim <> "" Then
    '                    If i_dt_Details.Rows(i).Item("MaEntry") > 0 Then
    '                        p_Str = "+"
    '                    End If
    '                End If
    '                l_chieucaohamhang = l_chieucaohamhang & p_KYHIEU_NIEM & Right(i_dt_Details.Rows(i).Item("MaNgan").ToString(), 1) & ": " & p_Str & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "mm; "
    '            Else
    '                l_chieucaohamhang = l_chieucaohamhang & p_KYHIEU_NIEM & i_dt_Details.Rows(i).Item("MaNgan").ToString() & ": " & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "; "
    '            End If
    '            'l_chieucaohamhang = l_chieucaohamhang & "H" & i_dt_Details.Rows(i).Item("MaNgan").ToString() & ": " & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "; "
    '        Next

    '        For i As Integer = 0 To i_dt_Material.Rows.Count - 1
    '            l_str = New Connect2SapEx.Str_PhieuXuat()
    '            '-----------------------------------------------------------------------------------------
    '            '   dữ liệu lấy từ i_dt_Header
    '            '-----------------------------------------------------------------------------------------
    '            l_str.Order_No = i_dt_Header.Rows(0).Item("Solenh").ToString()
    '            l_str.Outbound = i_dt_Header.Rows(0).Item("Solenh").ToString()
    '            l_str.Date_Nd = Format(i_dt_Header.Rows(0).Item("NgayXuat"), "yyyy-MM-dd")
    '            l_str.Plant = _WareHouse
    '            l_str.Batch_Nd = i_dt_Header.Rows(0).Item("MaNguon").ToString()
    '            l_str.Resource_Nd = i_dt_Header.Rows(0).Item("MaNguon").ToString()
    '            l_str.Method_Mt = i_dt_Header.Rows(0).Item("MaPhuongThucXuat").ToString()
    '            l_str.Method_Dc = i_dt_Header.Rows(0).Item("MaPhuongThucBan").ToString()
    '            l_str.Customer = i_dt_Header.Rows(0).Item("MaKhachHang").ToString()
    '            l_str.Shpoint = _ShPoint
    '            l_str.Transmot = i_dt_Header.Rows(0).Item("MaVanChuyen").ToString()
    '            l_str.Niem_Text = i_dt_Header.Rows(0).Item("Niem").ToString()
    '            l_str.Ngan_Text = l_chieucaohamhang
    '            l_str.Luong_Text = i_dt_Header.Rows(0).Item("LuongGiamDinh").ToString()
    '            l_str.Nhietdo_Text = i_dt_Header.Rows(0).Item("NhietDoTaiTau").ToString()
    '            '-----------------------------------------------------------------------------------------

    '            l_str.Veh_Mode = i_dt_Header.Rows(0).Item("MaVanChuyen").ToString()
    '            l_str.Vehicle = UCase(i_dt_Header.Rows(0).Item("MaPhuongTien").ToString())
    '            l_str.Drivercode = i_dt_Header.Rows(0).Item("NguoiVanChuyen").ToString()
    '            l_loaiphieu = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()
    '            '-----------------------------------------------------------------------------------------

    '            '-----------------------------------------------------------------------------------------
    '            '   Dữ liệu được lấy từ i_dt_Material
    '            '-----------------------------------------------------------------------------------------
    '            l_lineid = i_dt_Material.Rows(i).Item("LineID").ToString()
    '            l_mangan = "144"
    '            l_str.Lineid = l_lineid.Substring(3, 3)
    '            l_str.Compartment = l_mangan
    '            l_str.Item_Nd = l_lineid
    '            l_str.Material = i_dt_Material.Rows(i).Item("MaHangHoa").ToString()
    '            l_str.Unit = i_dt_Material.Rows(i).Item("DonViTinh").ToString()
    '            l_str.Salequantity = i_dt_Material.Rows(i).Item("TongDuXuat").ToString()
    '            'If p_TONGDUXUAT = "1" Then
    '            '    l_str.Quantity = i_dt_Material.Rows(i).Item("TongDuXuat").ToString()
    '            'Else
    '            '    l_str.Quantity = i_dt_Material.Rows(i).Item("TongXuat").ToString()
    '            'End If
    '            l_str.Quantity = i_dt_Material.Rows(i).Item("TongDuXuat").ToString()
    '            '-----------------------------------------------------------------------------------------

    '            '-----------------------------------------------------------------------------------------
    '            '   Dữ liệu được lấy từ i_dt_Details
    '            '-----------------------------------------------------------------------------------------
    '            '-----------------------------------------------------------------------------------------
    '            '   System Test KV2
    '            '       Lấy lượng thực xuất = lượng dự xuất với đường bộ
    '            '-----------------------------------------------------------------------------------------
    '            l_vanchuyen = mdlDelivery_CheckTransmot(l_str.Transmot, g_dt_para)
    '            If UCase(l_vanchuyen) = "BO" Or UCase(l_vanchuyen) = "SAT" Then
    '                If p_TONGDUXUAT = "1" Then  'Lay theo du xuat
    '                    If p_XITEC_OPTION = True Then  'Dung cho B12
    '                        l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
    '                    Else
    '                        l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
    '                    End If

    '                Else ' Lay theo thuc xuat
    '                    If p_XITEC_OPTION = True Then  'Dung cho B12
    '                        l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
    '                    Else
    '                        l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
    '                    End If

    '                End If
    '                'l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
    '            Else
    '                'l_str.Quantity_Confirm = l_quantity_conf(Convert.ToDecimal(l_lineid))
    '                If p_TONGDUXUATTHUY = "1" Then  'Lay theo du xuat
    '                    'If p_XITEC_OPTION = True Then  'Dung cho B12
    '                    '    l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
    '                    'Else
    '                    l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
    '                    ' End If

    '                Else ' Lay theo thuc xuat
    '                    'If p_XITEC_OPTION = True Then  'Dung cho B12
    '                    '    l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
    '                    'Else
    '                    l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
    '                    'End If

    '                End If
    '            End If


    '            Try
    '                'anhqh
    '                '20170313
    '                'Them truong hop cua KV3 voi truong hop xuat FO thi lay gia tri thuc xuat
    '                If Not p_HangHoa_SoLuongSAP Is Nothing Then
    '                    If p_HangHoa_SoLuongSAP.Rows.Count > 0 Then
    '                        Dim p_Datarow() As DataRow
    '                        p_Datarow = p_HangHoa_SoLuongSAP.Select("MaHangHoa='" & i_dt_Material.Rows(i).Item("MaHangHoa").ToString() & "'")
    '                        If p_Datarow.Length > 0 Then
    '                            If UCase(l_vanchuyen) = "BO" Or UCase(l_vanchuyen) = "SAT" Then
    '                                If p_Datarow(0).Item("TONGDUXUAT").ToString.Trim = "1" Then  'Lay theo du xuat
    '                                    l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
    '                                Else ' Lay theo thuc xuat
    '                                    l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
    '                                End If
    '                                'l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
    '                            Else
    '                                'l_str.Quantity_Confirm = l_quantity_conf(Convert.ToDecimal(l_lineid))
    '                                If p_Datarow(0).Item("TONGDUXUAT_THUY").ToString.Trim = "1" Then  'Lay theo du xuat
    '                                    l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
    '                                Else ' Lay theo thuc xuat
    '                                    l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
    '                                End If
    '                            End If

    '                        End If
    '                    End If
    '                End If
    '            Catch ex As Exception

    '            End Try

    '            Try
    '                Double.TryParse(i_dt_Material(i).Item("NhietDo_BQGQ").ToString.Trim, p_NhietDoBQ)
    '                Double.TryParse(i_dt_Material(i).Item("D15_BQGQ").ToString.Trim, p_TyTrongBQ)
    '                If p_NhietDoBQ > 0 Then
    '                    l_str.Temp_Confirm = p_NhietDoBQ
    '                Else

    '                    l_nhietdo(Convert.ToDecimal(l_lineid)) = NhietDoLamTron(l_nhietdo(Convert.ToDecimal(l_lineid)), 0)
    '                    l_str.Temp_Confirm = NhietDoLamTron(l_nhietdo(Convert.ToDecimal(l_lineid)) / l_str.Quantity_Confirm, 2)
    '                End If

    '                If p_TyTrongBQ > 0 Then
    '                    l_str.Dens_Confirm = p_TyTrongBQ
    '                Else
    '                    'Convert.ToDecimal(l_lineid))
    '                    l_str.Dens_Confirm = l_tytrong(Convert.ToDecimal(l_lineid)) / l_count(Convert.ToDecimal(l_lineid))
    '                End If

    '            Catch ex As Exception
    '                l_str.Temp_Confirm = NhietDoLamTron(l_nhietdo(Convert.ToDecimal(l_lineid)) / l_quantity_conf(Convert.ToDecimal(l_lineid)), 2)  'Math.Round(l_nhietdo(Convert.ToDecimal(l_lineid)) / l_quantity_conf(Convert.ToDecimal(l_lineid)), 2)
    '                l_str.Dens_Confirm = l_tytrong(Convert.ToDecimal(l_lineid)) / l_count(Convert.ToDecimal(l_lineid))
    '            End Try

    '            '  l_str.Temp_Confirm = NhietDoLamTron(l_nhietdo(Convert.ToDecimal(l_lineid)) / l_quantity_conf(Convert.ToDecimal(l_lineid)), 2)  'Math.Round(l_nhietdo(Convert.ToDecimal(l_lineid)) / l_quantity_conf(Convert.ToDecimal(l_lineid)), 2)
    '            '   l_str.Dens_Confirm = l_tytrong(Convert.ToDecimal(l_lineid)) / l_count(Convert.ToDecimal(l_lineid))

    '            '-----------------------------------------------------------------------------------------
    '            '   Đặt ngày giờ xuất hàng đưa lên SAP
    '            '-----------------------------------------------------------------------------------------
    '            Try
    '                If i_dt_Header.Rows(0).Item("NgayXuat") <= i_dt_Details.Rows(0).Item("ThoiGianDau") Then
    '                    l_str.Date_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "yyyy-MM-dd")
    '                End If
    '                l_str.Time_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "HH:mm:ss")
    '            Catch ex As Exception
    '                l_str.Date_Nd = Format(Now(), "yyyy-MM-dd")
    '                l_str.Time_Nd = Format(Now(), "HH:mm:ss")
    '            End Try
    '            '-----------------------------------------------------------------------------------------

    '            '-----------------------------------------------------------------------------------------
    '            '   Tính lại số lưu lượng kế
    '            '-----------------------------------------------------------------------------------------
    '            l_str.Meter_No = l_meter_n(l_lineid)
    '            l_str.Meter_Start = Convert.ToInt32(l_meter_s(l_lineid))
    '            l_str.Meter_End = Convert.ToInt32(l_meter_e(l_lineid))
    '            '-----------------------------------------------------------------------------------------

    '            o_ztb_Temp.Add(l_str)
    '        Next

    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    Public Function NhietDoLamTron(p_Value As Double, Optional p_Digits As Integer = 0) As Double

        Dim p_NhietDo As Double
        Dim p_SQL As String
        Dim p_Table As DataTable
        If p_Value.ToString.Trim = "" Then
            Return 0.0
        End If

        Double.TryParse(p_Value.ToString.Trim, p_NhietDo)

        p_SQL = "select dbo.FPT_ROUNDNUMBER (" & p_NhietDo & "," & p_Digits & ") as NhietDoBQ"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then

                NhietDoLamTron = p_Table.Rows(0).Item("NhietDoBQ")
                Return NhietDoLamTron
            End If
        End If

        NhietDoLamTron = Math.Round(p_NhietDo, p_Digits, MidpointRounding.AwayFromZero)

    End Function


    Public Function mdlDelivery_CheckTransmot(ByVal i_mavanchuyen As String, ByVal i_dt_para As DataTable) As String
        Dim l_bo, _
            l_thuy, _
            l_sat As String()
        Dim p_ArrRow() As DataRow
        Try
            '----------------------------------------------------------------
            '   Para:
            '       Index 0: Bo
            '       Index 1: Thuy
            '----------------------------------------------------------------
            p_ArrRow = i_dt_para.Select("Para='Bo' or Para='BO'")
            If p_ArrRow.Length > 0 Then
                l_bo = p_ArrRow(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            End If
            p_ArrRow = i_dt_para.Select("Para='Thuy' or Para='THUY'")
            If p_ArrRow.Length > 0 Then
                l_thuy = p_ArrRow(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            End If

            'l_bo = i_dt_para.Rows(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            'l_thuy = i_dt_para.Rows(1).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)

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


    Public Function mdlSyncDeliveries_Shipment(ByVal i_dt_Header As DataTable, _
                                                ByVal i_dt_Material As DataTable, _
                                                ByVal i_dt_Details As DataTable, _
                                                ByRef o_ztb_Temp As Connect2SapEx.Str_PhieuXuatTable) As Boolean
        Dim l_str As Connect2SapEx.Str_PhieuXuat
        Dim l_lineid, _
            l_mangan, _
            l_loaiphieu _
            As String
        Dim l_vanchuyen As String
        Dim p_RowArr() As DataRow
        Dim p_Str As String
        Try



            For i As Integer = 0 To i_dt_Details.Rows.Count - 1
                l_str = New Connect2SapEx.Str_PhieuXuat()
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

                'anhqh
                '20161010
                l_str.Transmot = i_dt_Header.Rows(0).Item("MaVanChuyen").ToString()

                l_str.Shnumber = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()
                l_str.Veh_Mode = i_dt_Header.Rows(0).Item("MaVanChuyen").ToString()
                l_str.Vehicle = UCase(i_dt_Header.Rows(0).Item("MaPhuongTien").ToString())
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


                'l_str.date
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
                If UCase(l_vanchuyen) = "BO" Or UCase(l_vanchuyen) = "SAT" Then
                    If p_TONGDUXUAT <> "1" Then
                        If i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString.Trim <> "" Then
                            If p_XITEC_OPTION = True Then  'Dung cho B12
                                If i_dt_Header.Rows(0).Item("XITEC_OPTION").ToString() = "Y" Then   'Lay theo du xuat
                                    l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongDuXuat"), 0)
                                Else   ' lay so thuc xuat
                                    l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
                                End If
                                ' l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongDuXuat"), 0)
                            Else
                                l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
                            End If

                        Else
                            l_str.Quantity = 0
                        End If
                    Else
                        If p_XITEC_OPTION = True Then  'Dung cho B12
                            If i_dt_Header.Rows(0).Item("XITEC_OPTION").ToString() = "Y" Then   'Lay theo thuc xuat
                                l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
                            Else  ' Lay theo du xuat
                                l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongDuXuat"), 0)
                            End If
                            'l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
                        End If
                    End If

                    l_str.Quantity_Confirm = l_str.Quantity
                Else
                    'l_str.Quantity_Confirm = i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString()
                    If p_TONGDUXUATTHUY <> "1" Then
                        If i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString.Trim <> "" Then
                            l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
                        Else
                            l_str.Quantity = 0
                        End If
                        'If p_XITEC_OPTION = True Then
                        '    l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongDuXuat"), 0)
                        'End If

                    Else  'Dung cho B12
                        'If p_XITEC_OPTION = True Then
                        '    l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
                        'End If
                    End If
                    l_str.Quantity_Confirm = l_str.Quantity
                End If

                Try
                    'anhqh
                    '20170313
                    'Them truong hop cua KV3 voi truong hop xuat FO thi lay gia tri thuc xuat
                    If Not p_HangHoa_SoLuongSAP Is Nothing Then
                        If p_HangHoa_SoLuongSAP.Rows.Count > 0 Then
                            Dim p_Datarow() As DataRow
                            p_Datarow = p_HangHoa_SoLuongSAP.Select("MaHangHoa='" & i_dt_Material.Rows(i).Item("MaHangHoa").ToString() & "'")
                            If p_Datarow.Length > 0 Then
                                If UCase(l_vanchuyen) = "BO" Or UCase(l_vanchuyen) = "SAT" Then
                                    If p_Datarow(0).Item("TONGDUXUAT").ToString.Trim <> "1" Then
                                        If i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString.Trim <> "" Then
                                            l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
                                        Else
                                            l_str.Quantity = 0
                                        End If
                                    End If
                                    l_str.Quantity_Confirm = l_str.Quantity
                                Else
                                    'l_str.Quantity_Confirm = i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString()
                                    If p_Datarow(0).Item("TONGDUXUAT_THUY").ToString.Trim <> "1" Then
                                        If i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString.Trim <> "" Then
                                            l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
                                        Else
                                            l_str.Quantity = 0
                                        End If
                                    End If
                                    l_str.Quantity_Confirm = l_str.Quantity
                                End If

                            End If
                        End If
                    End If

                Catch ex As Exception

                End Try

                l_str.Temp_Confirm = i_dt_Details.Rows(i).Item("NhietDo").ToString()
                l_str.Dens_Confirm = i_dt_Details.Rows(i).Item("TyTrong_15").ToString()

                '-----------------------------------------------------------------------------------------
                '   Đặt ngày giờ xuất hàng đưa lên SAP
                '-----------------------------------------------------------------------------------------
                Try
                    'anhqh  
                    '20181018
                    'Ngày tháng lấy theo 

                    p_RowArr = i_dt_Details.Select("", "ThoiGianDau asc")
                    If p_RowArr.Length > 0 Then
                        l_str.Date_Nd = Format(p_RowArr(0).Item("ThoiGianDau"), "yyyy-MM-dd")
                        l_str.Time_Nd = Format(p_RowArr(0).Item("ThoiGianDau"), "HH:mm:ss")
                    Else
                        If i_dt_Header.Rows(0).Item("NgayXuat") <= i_dt_Details.Rows(0).Item("ThoiGianDau") Then
                            l_str.Date_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "yyyy-MM-dd")
                        End If
                        l_str.Time_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "HH:mm:ss")
                    End If

                    'If i_dt_Header.Rows(0).Item("NgayXuat") <= i_dt_Details.Rows(0).Item("ThoiGianDau") Then
                    '    l_str.Date_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "yyyy-MM-dd")
                    'End If
                    'l_str.Time_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "HH:mm:ss")
                Catch ex As Exception
                    l_str.Date_Nd = Format(Now(), "yyyy-MM-dd")
                    l_str.Time_Nd = Format(Now(), "HH:mm:ss")
                End Try
                '-----------------------------------------------------------------------------------------

                Dim l_d_start, _
                    l_d_end _
                    As Decimal

                If i_dt_Details.Rows(i).Item("sl_llkebd").ToString.Trim <> "" Then
                    l_d_start = i_dt_Details.Rows(i).Item("sl_llkebd")
                Else
                    l_d_start = 0
                End If
                If i_dt_Details.Rows(i).Item("sl_llkekt").ToString.Trim <> "" Then
                    l_d_end = i_dt_Details.Rows(i).Item("sl_llkekt")
                Else
                    l_d_end = 0
                End If

                l_str.Meter_No = i_dt_Details.Rows(i).Item("MaLuuLuongKe").ToString()
                l_str.Meter_Start = Convert.ToInt64(l_d_start)
                l_str.Meter_End = Convert.ToInt64(l_d_end)

                If p_NIEM_MM = True Then
                    p_Str = ""
                    If i_dt_Details.Rows(i).Item("MaEntry").ToString.ToString.Trim <> "" Then
                        If i_dt_Details.Rows(i).Item("MaEntry") > 0 Then
                            p_Str = "+"
                        End If
                    End If
                    l_str.Ngan_Text = l_str.Ngan_Text & p_KYHIEU_NIEM & Right(i_dt_Details.Rows(i).Item("MaNgan").ToString(), 1) & ": " & p_Str & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "mm; "

                Else
                    l_str.Ngan_Text = l_str.Ngan_Text & p_KYHIEU_NIEM & i_dt_Details.Rows(i).Item("MaNgan").ToString() & ": " & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "; "

                End If

                'l_str.Ngan_Text = l_str.Ngan_Text & "H" & i_dt_Details.Rows(i).Item("MaNgan").ToString() & ": " & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "; "

                o_ztb_Temp.Add(l_str)
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function





    'Public Function mdlSyncDeliveries_Shipment(ByVal i_dt_Header As DataTable, _
    '                                            ByVal i_dt_Material As DataTable, _
    '                                            ByVal i_dt_Details As DataTable, _
    '                                            ByRef o_ztb_Temp As Connect2SapEx.Str_PhieuXuatTable) As Boolean
    '    Dim l_str As Connect2SapEx.Str_PhieuXuat
    '    Dim l_lineid, _
    '        l_mangan, _
    '        l_loaiphieu _
    '        As String
    '    Dim l_vanchuyen As String
    '    Dim p_Str As String
    '    Try

    '        For i As Integer = 0 To i_dt_Details.Rows.Count - 1
    '            l_str = New Connect2SapEx.Str_PhieuXuat()
    '            '-----------------------------------------------------------------------------------------
    '            '   dữ liệu lấy từ i_dt_Header
    '            '-----------------------------------------------------------------------------------------
    '            l_str.Order_No = i_dt_Header.Rows(0).Item("Solenh").ToString()
    '            l_str.Outbound = i_dt_Header.Rows(0).Item("Solenh").ToString()
    '            l_str.Date_Nd = Format(i_dt_Header.Rows(0).Item("NgayXuat"), "yyyy-MM-dd")
    '            l_str.Plant = _WareHouse
    '            'l_str.Storage = _
    '            l_str.Batch_Nd = i_dt_Header.Rows(0).Item("MaNguon").ToString()
    '            l_str.Resource_Nd = i_dt_Header.Rows(0).Item("MaNguon").ToString()
    '            l_str.Method_Mt = i_dt_Header.Rows(0).Item("MaPhuongThucXuat").ToString()
    '            l_str.Method_Dc = i_dt_Header.Rows(0).Item("MaPhuongThucBan").ToString()
    '            l_str.Customer = i_dt_Header.Rows(0).Item("MaKhachHang").ToString()
    '            l_str.Shpoint = _ShPoint

    '            'anhqh
    '            '20161010
    '            l_str.Transmot = i_dt_Header.Rows(0).Item("MaVanChuyen").ToString()

    '            l_str.Shnumber = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()
    '            l_str.Veh_Mode = i_dt_Header.Rows(0).Item("MaVanChuyen").ToString()
    '            l_str.Vehicle = UCase(i_dt_Header.Rows(0).Item("MaPhuongTien").ToString())
    '            l_str.Drivercode = i_dt_Header.Rows(0).Item("NguoiVanChuyen").ToString()
    '            l_str.Niem_Text = i_dt_Header.Rows(0).Item("Niem").ToString()
    '            l_str.Luong_Text = i_dt_Header.Rows(0).Item("LuongGiamDinh").ToString()
    '            l_str.Nhietdo_Text = i_dt_Header.Rows(0).Item("NhietDoTaiTau").ToString()
    '            l_loaiphieu = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()
    '            '-----------------------------------------------------------------------------------------
    '            '-----------------------------------------------------------------------------------------
    '            '   System Test KV2
    '            '       Lấy lượng thực xuất = lượng dự xuất với đường bộ
    '            '-----------------------------------------------------------------------------------------
    '            l_vanchuyen = mdlDelivery_CheckTransmot(l_str.Veh_Mode, g_dt_para)
    '            '-----------------------------------------------------------------------------------------
    '            '-----------------------------------------------------------------------------------------
    '            'Dữ liệu được lấy từ Details
    '            '-----------------------------------------------------------------------------------------
    '            l_lineid = i_dt_Details.Rows(i).Item("LineID").ToString()
    '            l_mangan = i_dt_Details.Rows(i).Item("MaNgan").ToString()
    '            l_str.Lineid = l_lineid.Substring(3, 3)
    '            l_str.Compartment = l_mangan
    '            l_str.Item_Nd = l_lineid
    '            '-----------------------------------------------------------------------------------------

    '            '-----------------------------------------------------------------------------------------
    '            '   Làm vòng lặp để kiểm tra lineid với i_dt_material
    '            '-----------------------------------------------------------------------------------------
    '            For j As Integer = 0 To i_dt_Material.Rows.Count - 1
    '                If i_dt_Material.Rows(j).Item("LineID").ToString() = l_lineid Then
    '                    l_str.Material = i_dt_Material.Rows(j).Item("MaHangHoa").ToString()
    '                    l_str.Unit = i_dt_Material.Rows(j).Item("DonViTinh").ToString()
    '                    l_str.Salequantity = i_dt_Material.Rows(j).Item("TongDuXuat").ToString()
    '                    Exit For
    '                End If
    '            Next
    '            '-----------------------------------------------------------------------------------------

    '            l_str.Quantity = i_dt_Details.Rows(i).Item("SoLuongDuXuat").ToString()
    '            'l_str.Quantity_Confirm = i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString()
    '            '-----------------------------------------------------------------------------------------
    '            '   System Test KV2
    '            '       Lấy lượng thực xuất = lượng dự xuất với đường bộ
    '            '-----------------------------------------------------------------------------------------
    '            If UCase(l_vanchuyen) = "BO" Or UCase(l_vanchuyen) = "SAT" Then
    '                If p_TONGDUXUAT <> "1" Then
    '                    If i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString.Trim <> "" Then
    '                        If p_XITEC_OPTION = True Then  'Dung cho B12
    '                            l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongDuXuat"), 0)
    '                        Else
    '                            l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
    '                        End If

    '                    Else
    '                        l_str.Quantity = 0
    '                    End If
    '                Else
    '                    If p_XITEC_OPTION = True Then  'Dung cho B12
    '                        l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
    '                    End If
    '                End If

    '                l_str.Quantity_Confirm = l_str.Quantity
    '            Else
    '                'l_str.Quantity_Confirm = i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString()
    '                If p_TONGDUXUATTHUY <> "1" Then
    '                    If i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString.Trim <> "" Then
    '                        l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
    '                    Else
    '                        l_str.Quantity = 0
    '                    End If
    '                    'If p_XITEC_OPTION = True Then
    '                    '    l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongDuXuat"), 0)
    '                    'End If

    '                Else  'Dung cho B12
    '                    'If p_XITEC_OPTION = True Then
    '                    '    l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
    '                    'End If
    '                End If
    '                l_str.Quantity_Confirm = l_str.Quantity
    '            End If

    '            Try
    '                'anhqh
    '                '20170313
    '                'Them truong hop cua KV3 voi truong hop xuat FO thi lay gia tri thuc xuat
    '                If Not p_HangHoa_SoLuongSAP Is Nothing Then
    '                    If p_HangHoa_SoLuongSAP.Rows.Count > 0 Then
    '                        Dim p_Datarow() As DataRow
    '                        p_Datarow = p_HangHoa_SoLuongSAP.Select("MaHangHoa='" & i_dt_Material.Rows(i).Item("MaHangHoa").ToString() & "'")
    '                        If p_Datarow.Length > 0 Then
    '                            If UCase(l_vanchuyen) = "BO" Or UCase(l_vanchuyen) = "SAT" Then
    '                                If p_Datarow(0).Item("TONGDUXUAT").ToString.Trim <> "1" Then
    '                                    If i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString.Trim <> "" Then
    '                                        l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
    '                                    Else
    '                                        l_str.Quantity = 0
    '                                    End If
    '                                End If
    '                                l_str.Quantity_Confirm = l_str.Quantity
    '                            Else
    '                                'l_str.Quantity_Confirm = i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString()
    '                                If p_Datarow(0).Item("TONGDUXUAT_THUY").ToString.Trim <> "1" Then
    '                                    If i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString.Trim <> "" Then
    '                                        l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
    '                                    Else
    '                                        l_str.Quantity = 0
    '                                    End If
    '                                End If
    '                                l_str.Quantity_Confirm = l_str.Quantity
    '                            End If

    '                        End If
    '                    End If
    '                End If

    '            Catch ex As Exception

    '            End Try




    '            l_str.Temp_Confirm = i_dt_Details.Rows(i).Item("NhietDo").ToString()
    '            l_str.Dens_Confirm = i_dt_Details.Rows(i).Item("TyTrong_15").ToString()

    '            '-----------------------------------------------------------------------------------------
    '            '   Đặt ngày giờ xuất hàng đưa lên SAP
    '            '-----------------------------------------------------------------------------------------
    '            Try
    '                If i_dt_Header.Rows(0).Item("NgayXuat") <= i_dt_Details.Rows(0).Item("ThoiGianDau") Then
    '                    l_str.Date_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "yyyy-MM-dd")
    '                End If
    '                l_str.Time_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "HH:mm:ss")
    '            Catch ex As Exception
    '                l_str.Date_Nd = Format(Now(), "yyyy-MM-dd")
    '                l_str.Time_Nd = Format(Now(), "HH:mm:ss")
    '            End Try
    '            '-----------------------------------------------------------------------------------------

    '            Dim l_d_start, _
    '                l_d_end _
    '                As Decimal

    '            If i_dt_Details.Rows(i).Item("sl_llkebd").ToString.Trim <> "" Then
    '                l_d_start = i_dt_Details.Rows(i).Item("sl_llkebd")
    '            Else
    '                l_d_start = 0
    '            End If
    '            If i_dt_Details.Rows(i).Item("sl_llkekt").ToString.Trim <> "" Then
    '                l_d_end = i_dt_Details.Rows(i).Item("sl_llkekt")
    '            Else
    '                l_d_end = 0
    '            End If

    '            l_str.Meter_No = i_dt_Details.Rows(i).Item("MaLuuLuongKe").ToString()
    '            l_str.Meter_Start = Convert.ToInt32(l_d_start)
    '            l_str.Meter_End = Convert.ToInt32(l_d_end)

    '            If p_NIEM_MM = True Then
    '                p_Str = ""
    '                If i_dt_Details.Rows(i).Item("MaEntry").ToString.ToString.Trim <> "" Then
    '                    If i_dt_Details.Rows(i).Item("MaEntry") > 0 Then
    '                        p_Str = "+"
    '                    End If
    '                End If
    '                l_str.Ngan_Text = l_str.Ngan_Text & p_KYHIEU_NIEM & Right(i_dt_Details.Rows(i).Item("MaNgan").ToString(), 1) & ": " & p_Str & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "mm; "

    '            Else
    '                l_str.Ngan_Text = l_str.Ngan_Text & p_KYHIEU_NIEM & i_dt_Details.Rows(i).Item("MaNgan").ToString() & ": " & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "; "

    '            End If

    '            'l_str.Ngan_Text = l_str.Ngan_Text & "H" & i_dt_Details.Rows(i).Item("MaNgan").ToString() & ": " & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "; "

    '            o_ztb_Temp.Add(l_str)
    '        Next

    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try

    'End Function
End Module
