Imports Microsoft.VisualBasic

Imports System.Data
Imports System

Public Class MnuDongBoNew


    Private _SapConnectionString As String = ""
    Private _dtVariable As System.Data.DataTable
    Private _ShPoint As String = ""
    Private _WareHouse As String = ""
    Private _TimeOut As System.TimeSpan
    Private g_Company_Code As String = ""


    Private Sub GetParameter()
        Dim p_SQL As String
        Dim p_ConnectHTTG As New ConnectHTTG

        ' Dim p_Table As DataTable
        p_SQL = "select * from tblConfig;"
        _dtVariable = p_ConnectHTTG.GetDataTable(p_SQL, p_SQL)
        If Not _dtVariable Is Nothing Then
            If _dtVariable.Rows.Count > 0 Then
                _SapConnectionString = _dtVariable.Rows(0).Item("sapconnectionstring").ToString.Trim

                _WareHouse = _dtVariable.Rows(0).Item("warehouse").ToString.Trim

                _ShPoint = _dtVariable.Rows(0).Item("shippingpoint").ToString.Trim
                g_Company_Code = _dtVariable.Rows(0).Item("companycode").ToString.Trim
            End If
        End If

    End Sub


    'hieptd4 add 20161027
    Public Function ClsSyncMaster_SyncPrice(ByRef p_DataTablExe As DataTable, ByVal i_date As String, ByRef p_desc As String) As Boolean
        ClsSyncMaster_SyncPrice = mdlSyncMaster_SyncPrice(p_DataTablExe, i_date, p_desc)
    End Function
    Public Function ClsSyncMaster_SyncPaymentTerm(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean
        ClsSyncMaster_SyncPaymentTerm = mdlSyncMaster_SyncPaymentTerm(p_DataTablExe, p_desc)
    End Function
    Public Function ClsSyncMaster_SyncDischard(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean
        ClsSyncMaster_SyncDischard = mdlSyncMaster_SyncDischard(p_DataTablExe, p_desc)
    End Function
    Public Function ClsSyncMaster_SyncRoute(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean
        ClsSyncMaster_SyncRoute = mdlSyncMaster_SyncRoute(p_DataTablExe, p_desc)
    End Function
    Public Function ClsSyncMaster_SyncVendor(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, ByRef p_desc As String) As Boolean
        ClsSyncMaster_SyncVendor = mdlSyncMaster_SyncVendor(p_DataTablExe, i_getall, i_date, p_desc)
    End Function
    'end hieptd4 add 20161027


    'hieptd4 add 20161027
#Region "Price"
    Public Function mdlSyncMaster_SyncPrice(ByRef p_DataTablExe As DataTable, ByVal i_date As String, ByRef p_desc As String) As Boolean
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.STR_VK13Table
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String
        Dim p_DonGia As Decimal = 0

        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_Row As DataRow
        If p_DataTablExe Is Nothing Then
            p_DataTablExe = New DataTable("Table001")
            p_DataTablExe.Columns.Add("STR_SQL")

        End If
        Try
            p_desc = ""

            GetParameter()
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            'If g_WcfE5 = True Then

            '    mdlSyncMaster_SyncVendor = g_Services.mdlSyncMaster_SyncVendor(_SapConnectionString, _
            '                                     _dtVariable, _
            '                                     _ShPoint, _
            '                                         _WareHouse, _
            '                                         _TimeOut, _
            '                                     p_DataTablExe, i_getall, p_desc)

            '    Return mdlSyncMaster_SyncVendor()
            'End If

            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_ztb = New Connect2SapEx.STR_VK13Table()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetVk13(i_date, String.Empty, String.Empty, g_Company_Code, l_ret2, l_ztb)
            Else
                l_async = l_c2sap.BeginGetVk13(i_date, String.Empty, String.Empty, g_Company_Code, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetVk13(l_async, l_ret2, l_ztb)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                For i As Integer = 0 To l_ztb.Count - 1
                    If l_ztb.Item(i).Waers.ToString() = "VND" Then
                        l_ztb.Item(i).Kbetr = l_ztb.Item(i).Kbetr * 100
                    End If
                    p_DonGia = l_ztb.Item(i).Kbetr / l_ztb.Item(i).Kpein

                    If Integer.TryParse(l_ztb.Item(i).Matnr, Nothing) Then
                        l_ztb.Item(i).Matnr = l_ztb.Item(i).Matnr.Substring(l_ztb.Item(i).Matnr.Length - 7)
                    End If

                    'Cho dữ liệu vào CSDL SQL
                    p_SQL = "MERGE tblDonGia AS target " & _
                        " USING (SELECT '" & Replace(l_ztb.Item(i).Kappl.ToString(), "'", "", 1) & "' as KAPPL ," & _
                                  "'" & Replace(l_ztb.Item(i).Kschl.ToString(), "'", "", 1) & "'  as KSCHL ," & _
                                  "'" & Replace(l_ztb.Item(i).Vkorg.ToString(), "'", "", 1) & "'  as VKORG ," & _
                                  "'" & Replace(l_ztb.Item(i).Vtweg.ToString(), "'", "", 1) & "'  as VTWEG ," & _
                                  "'" & Replace(l_ztb.Item(i).Kunnr.ToString(), "'", "", 1) & "'  as KUNNR ," & _
                                  "'" & Replace(l_ztb.Item(i).Matnr.ToString(), "'", "", 1) & "'  as MATNR ," & _
                                  "'" & Replace(l_ztb.Item(i).Vrkme.ToString(), "'", "", 1) & "'  as VRKME ," & _
                                  "'" & Replace(l_ztb.Item(i).Zterm.ToString(), "'", "", 1) & "'  as ZTERM ," & _
                                  "'" & Replace(l_ztb.Item(i).Kfrst.ToString(), "'", "", 1) & "'  as KFRST ," & _
                                  "'" & Replace(l_ztb.Item(i).Datbi.ToString(), "'", "", 1) & "'  as DATBI ," & _
                                  "'" & Replace(l_ztb.Item(i).Datab.ToString(), "'", "", 1) & "'  as DATAB ," & _
                                  "'" & Replace(l_ztb.Item(i).Kbstat.ToString(), "'", "", 1) & "'  as KBSTAT ," & _
                                  "'" & Replace(l_ztb.Item(i).Knumh.ToString(), "'", "", 1) & "'  as KNUMH ," & _
                                  Replace(l_ztb.Item(i).Kbetr.ToString(), "'", "", 1) & "  as KBETR ," & _
                                  "'" & Replace(l_ztb.Item(i).Waers.ToString(), "'", "", 1) & "'  as WAERS ," & _
                                  Replace(l_ztb.Item(i).Kpein.ToString(), "'", "", 1) & "  as KPEIN ," & _
                                  "'" & Replace(l_ztb.Item(i).Kmein.ToString(), "'", "", 1) & "'  as KMEIN ," & _
                                  Replace(p_DonGia.ToString(), "'", "", 1) & "  as DonGia ," & _
                                  "'" & Replace(l_ztb.Item(i).Aland.ToString(), "'", "", 1) & "'  as ALAND ," & _
                                  "'" & Replace(l_ztb.Item(i).Konda.ToString(), "'", "", 1) & "'  as KONDA ," & _
                                  "'" & Replace(l_ztb.Item(i).Inco1.ToString(), "'", "", 1) & "'  as Inco1 ," & _
                                  "'" & Replace(l_ztb.Item(i).Inco2.ToString(), "'", "", 1) & "'  as Inco2 " & _
                                " ) AS source (KAPPL, KSCHL, VKORG, VTWEG, KUNNR, MATNR, VRKME, ZTERM, KFRST, DATBI, DATAB, KBSTAT, KNUMH, KBETR, WAERS, KPEIN, KMEIN, DonGia, ALAND, KONDA, Inco1, Inco2 ) " & _
                                " ON (target.KAPPL = source.KAPPL and " & _
                                    " target.KSCHL = source.KSCHL and " & _
                                    " target.VKORG = source.VKORG and " & _
                                    " target.VTWEG = source.VTWEG and " & _
                                    " target.KUNNR = source.KUNNR and " & _
                                    " target.MATNR = source.MATNR and " & _
                                    " target.VRKME = source.VRKME and " & _
                                    " target.ZTERM = source.ZTERM and " & _
                                    " target.KFRST = source.KFRST and " & _
                                    " target.DATBI = source.DATBI ) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "DATAB=source.DATAB , " & _
                                    "KBSTAT=source.KBSTAT ," & _
                                    "KNUMH=source.KNUMH ," & _
                                    "KBETR=source.KBETR ," & _
                                    "WAERS=source.WAERS ," & _
                                    "KPEIN=source.KPEIN ," & _
                                    "KMEIN=source.KMEIN ," & _
                                    "DonGia=source.DonGia ," & _
                                    "ALAND=source.ALAND ," & _
                                    "KONDA=source.KONDA ," & _
                                    "Inco1=source.Inco1 ," & _
                                    "Inco2=source.Inco2 " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (KAPPL, KSCHL, VKORG, VTWEG, KUNNR, MATNR, VRKME, ZTERM, KFRST, DATBI, DATAB, KBSTAT, KNUMH, KBETR, WAERS, KPEIN, KMEIN, DonGia, ALAND, KONDA, Inco1, Inco2 ) " & _
                            "VALUES (source.KAPPL, source.KSCHL, source.VKORG, source.VTWEG, source.KUNNR, source.MATNR, source.VRKME, source.ZTERM, source.KFRST, source.DATBI, source.DATAB, source.KBSTAT, source.KNUMH, source.KBETR, source.WAERS, source.KPEIN, source.KMEIN, source.DonGia, source.ALAND, source.KONDA, source.Inco1, source.Inco2 ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            If p_DataTablExe.Rows.Count > 0 Then
                Dim p_ConnectHTTG As New ConnectHTTG
                mdlSyncMaster_SyncPrice = p_ConnectHTTG.Sys_Execute_DataTbl(p_DataTablExe, p_desc)
                'Return mdlSyncMaster_SyncVehicleDown
            End If



            Return True

        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try
    End Function
#End Region

#Region "Payment term"
    Public Function mdlSyncMaster_SyncPaymentTerm(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.STR_PAYMENTTERMTable
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String

        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_Row As DataRow
        If p_DataTablExe Is Nothing Then
            p_DataTablExe = New DataTable("Table001")
            p_DataTablExe.Columns.Add("STR_SQL")

        End If
        Try
            p_desc = ""
            GetParameter()
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            'If g_WcfE5 = True Then

            '    mdlSyncMaster_SyncVendor = g_Services.mdlSyncMaster_SyncVendor(_SapConnectionString, _
            '                                     _dtVariable, _
            '                                     _ShPoint, _
            '                                         _WareHouse, _
            '                                         _TimeOut, _
            '                                     p_DataTablExe, i_getall, p_desc)

            '    Return mdlSyncMaster_SyncVendor()
            'End If

            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_ztb = New Connect2SapEx.STR_PAYMENTTERMTable()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetPaymentterm(String.Empty, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetPaymentterm(String.Empty, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetPaymentterm(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                For i As Integer = 0 To l_ztb.Count - 1
                    'Cho dữ liệu vào CSDL SQL

                    p_SQL = "MERGE tblThoiHanThanhToan AS target " & _
                        " USING (SELECT '" & Replace(l_ztb.Item(i).Zterm.ToString(), "'", "", 1) & "' as TermKey ," & _
                                   Replace(l_ztb.Item(i).Ztag1.ToString(), "'", "", 1) & "  as BaselineDate ," & _
                                   Replace(l_ztb.Item(i).Zstg1.ToString(), "'", "", 1) & "  as DueDate ," & _
                                 "N'" & Replace(l_ztb.Item(i).Text1.ToString(), "'", "", 1) & "'  as GhiChu " & _
                                " ) AS source (TermKey, BaselineDate, DueDate, GhiChu ) " & _
                                " ON (target.TermKey = source.TermKey) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "BaselineDate=source.BaselineDate ," & _
                                    "DueDate=source.DueDate ," & _
                                    "GhiChu=source.GhiChu " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (TermKey,BaselineDate,DueDate,GhiChu ) " & _
                                "VALUES (source.TermKey,source.BaselineDate,source.DueDate,source.GhiChu ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            If p_DataTablExe.Rows.Count > 0 Then
                Dim p_ConnectHTTG As New ConnectHTTG
                mdlSyncMaster_SyncPaymentTerm = p_ConnectHTTG.Sys_Execute_DataTbl(p_DataTablExe, p_desc)
                'Return mdlSyncMaster_SyncVehicleDown
            End If


            Return True

        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try
    End Function
#End Region

#Region "Sync Dischard"
    Public Function mdlSyncMaster_SyncDischard(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.STR_DISCHARD_MDTable
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String

        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_Row As DataRow
        If p_DataTablExe Is Nothing Then
            p_DataTablExe = New DataTable("Table001")
            p_DataTablExe.Columns.Add("STR_SQL")

        End If
        Try
            p_desc = ""
            GetParameter()
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            'If g_WcfE5 = True Then

            '    mdlSyncMaster_SyncVendor = g_Services.mdlSyncMaster_SyncVendor(_SapConnectionString, _
            '                                     _dtVariable, _
            '                                     _ShPoint, _
            '                                         _WareHouse, _
            '                                         _TimeOut, _
            '                                     p_DataTablExe, i_getall, p_desc)

            '    Return mdlSyncMaster_SyncVendor()
            'End If

            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_ztb = New Connect2SapEx.STR_DISCHARD_MDTable()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetDischard_MD(_WareHouse, String.Empty, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetDischard_MD(_WareHouse, String.Empty, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetDischard_MD(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                For i As Integer = 0 To l_ztb.Count - 1
                    'Cho dữ liệu vào CSDL SQL

                    p_SQL = "MERGE tblGiaoNhan AS target " & _
                        " USING (SELECT '" & Replace(l_ztb.Item(i).Route.ToString(), "'", "", 1) & "' as MaTuyenDuong ," & _
                                  "'" & Replace(l_ztb.Item(i).Knanf.ToString(), "'", "", 1) & "'  as DiemKhoiHanh ," & _
                                  "'" & Replace(l_ztb.Item(i).Knend.ToString(), "'", "", 1) & " '  as DiemDen ," & _
                                 "N'" & Replace(l_ztb.Item(i).Bezei.ToString(), "'", "", 1) & "'  as DGTuyenDuong ," & _
                                 "N'" & Replace(l_ztb.Item(i).Bezei_F.ToString(), "'", "", 1) & "'  as DGDiemKhoiHanh ," & _
                                 "N'" & Replace(l_ztb.Item(i).Bezei_T.ToString(), "'", "", 1) & "'  as DGDiemDen " & _
                                " ) AS source (MaTuyenDuong, DiemKhoiHanh, DiemDen, DGTuyenDuong, DGDiemKhoiHanh, DGDiemDen ) " & _
                                " ON (target.MaTuyenDuong = source.MaTuyenDuong and " & _
                                     "target.DiemDen = source.DiemDen ) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "DiemKhoiHanh=source.DiemKhoiHanh ," & _
                                    "DGTuyenDuong=source.DGTuyenDuong ," & _
                                    "DGDiemKhoiHanh=source.DGDiemKhoiHanh ," & _
                                    "DGDiemDen=source.DGDiemDen " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (MaTuyenDuong,DiemKhoiHanh,DiemDen,DGTuyenDuong,DGDiemKhoiHanh,DGDiemDen ) " & _
                                "VALUES (source.MaTuyenDuong,source.DiemKhoiHanh,source.DiemDen,source.DGTuyenDuong,source.DGDiemKhoiHanh,source.DGDiemDen ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()


            If p_DataTablExe.Rows.Count > 0 Then
                Dim p_ConnectHTTG As New ConnectHTTG
                mdlSyncMaster_SyncDischard = p_ConnectHTTG.Sys_Execute_DataTbl(p_DataTablExe, p_desc)
                'Return mdlSyncMaster_SyncVehicleDown
            End If


            Return True

        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try
    End Function
#End Region

#Region "Sync Route"
    Public Function mdlSyncMaster_SyncRoute(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.STR_DischardTable
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String

        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_Row As DataRow
        If p_DataTablExe Is Nothing Then
            p_DataTablExe = New DataTable("Table001")
            p_DataTablExe.Columns.Add("STR_SQL")

        End If
        Try
            p_desc = ""
            GetParameter()
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            'If g_WcfE5 = True Then

            '    mdlSyncMaster_SyncVendor = g_Services.mdlSyncMaster_SyncVendor(_SapConnectionString, _
            '                                     _dtVariable, _
            '                                     _ShPoint, _
            '                                         _WareHouse, _
            '                                         _TimeOut, _
            '                                     p_DataTablExe, i_getall, p_desc)

            '    Return mdlSyncMaster_SyncVendor()
            'End If

            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_ztb = New Connect2SapEx.STR_DischardTable()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetRoute(g_Company_Code, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetRoute(g_Company_Code, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetRoute(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                For i As Integer = 0 To l_ztb.Count - 1
                    'Cho dữ liệu vào CSDL SQL

                    p_SQL = "MERGE tblTuyenDuong AS target " & _
                        " USING (SELECT '" & Replace(l_ztb.Item(i).Routecode.ToString(), "'", "", 1) & "' as MaTuyenDuong ," & _
                                 "N'" & Replace(l_ztb.Item(i).Routename.ToString(), "'", "", 1) & "'  as TenTuyenDuong" & _
                                " ) AS source (MaTuyenDuong, TenTuyenDuong) " & _
                                " ON (target.MaTuyenDuong = source.MaTuyenDuong) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "TenTuyenDuong=source.TenTuyenDuong " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (MaTuyenDuong,TenTuyenDuong ) " & _
                                "VALUES (source.MaTuyenDuong,source.TenTuyenDuong ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()


            If p_DataTablExe.Rows.Count > 0 Then
                Dim p_ConnectHTTG As New ConnectHTTG
                mdlSyncMaster_SyncRoute = p_ConnectHTTG.Sys_Execute_DataTbl(p_DataTablExe, p_desc)
                'Return mdlSyncMaster_SyncVehicleDown
            End If


            Return True

        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try
    End Function
#End Region

#Region "Sync Vendor"
    Public Function mdlSyncMaster_SyncVendor(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                                ByVal i_date As String, ByRef p_desc As String) As Boolean
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.STR_VENDORTable
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String

        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_Row As DataRow
        If p_DataTablExe Is Nothing Then
            p_DataTablExe = New DataTable("Table001")
            p_DataTablExe.Columns.Add("STR_SQL")

        End If
        Try
            p_desc = ""
            GetParameter()
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            'If g_WcfE5 = True Then

            '    mdlSyncMaster_SyncVendor = g_Services.mdlSyncMaster_SyncVendor(_SapConnectionString, _
            '                                     _dtVariable, _
            '                                     _ShPoint, _
            '                                         _WareHouse, _
            '                                         _TimeOut, _
            '                                     p_DataTablExe, i_getall, p_desc)

            '    Return mdlSyncMaster_SyncVendor()
            'End If

            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_ztb = New Connect2SapEx.STR_VENDORTable()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetVendor(g_Company_Code, i_date, i_getall, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetVendor(g_Company_Code, i_date, i_getall, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetVendor(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                For i As Integer = 0 To l_ztb.Count - 1
                    'Cho dữ liệu vào CSDL SQL
                    'If l_ztb.Item(i).Vendorcode = "0000100100" Then
                    '    MsgBox("found")
                    'End If

                    p_SQL = "MERGE tblNhaCungCap AS target " & _
                        " USING (SELECT '" & Replace(l_ztb.Item(i).Vendorcode.ToString(), "'", "", 1) & "' as MaNhaCungCap ," & _
                                 "N'" & Replace(l_ztb.Item(i).Vendorname.ToString(), "'", "", 1) & "'  as TenNhaCungCap," & _
                                 "N'" & Replace(l_ztb.Item(i).Vendorvat.ToString(), "'", "", 1) & "'  as MaSoThue " & _
                                " ) AS source (MaNhaCungCap, TenNhaCungCap, MaSoThue) " & _
                                " ON (target.MaNhaCungCap = source.MaNhaCungCap) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "TenNhaCungCap=source.TenNhaCungCap " & _
                                    ",MaSoThue=source.MaSoThue " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (MaNhaCungCap,TenNhaCungCap,MaSoThue ) " & _
                                "VALUES (source.MaNhaCungCap,source.TenNhaCungCap,source.MaSoThue ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()


            If p_DataTablExe.Rows.Count > 0 Then
                Dim p_ConnectHTTG As New ConnectHTTG
                mdlSyncMaster_SyncVendor = p_ConnectHTTG.Sys_Execute_DataTbl(p_DataTablExe, p_desc)
                'Return mdlSyncMaster_SyncVehicleDown
            End If



            Return True

        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try
    End Function
#End Region
    'end hieptd4 add 20161027
End Class
