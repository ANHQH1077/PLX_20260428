Module Module1
    Public _TimeOut = New TimeSpan()
    Public flag As Integer()
    Public lw_mess As String()
    Public isGetAll As String
    Public g_dt As DataTable
    Public _SapConnectionString As String
    Public _WareHouse As String
    Public _dtVariable As DataTable
    Public g_Company_Code As String
    Public _ShPoint As String

    Public g_Services As Object
    Public g_WcfE5 As Boolean = False

    Private p_PTienAo As String = ""
    Public g_userName As String = ""

   

#Region "Sync TuType"

#End Region

#Region "Sync Vehicle"


    Public Function mdlSyncMaster_SyncVehicleDown(ByRef p_DataTablExe As DataTable, ByVal i_getAll As String, _
                                                  ByVal i_date As String, _
                                                  ByRef p_Desc As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_PhuongTienTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        'Dim l_bs_vehicle As BSVehicle
        'Dim l_bs_details As BSVehicleDetail
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_SQL As String
        Dim p_Row As DataRow

        Dim p_PTienAo_SMO As String = ""
        Dim p_Table As DataTable


        p_PTienAo = ""
        p_SQL = "select KeyValue from sys_config where keycode ='PTIEN_AO'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_PTienAo = p_Table.Rows(0).Item("KeyValue").ToString.Trim
            End If
        End If

        p_PTienAo_SMO = ""
        p_SQL = "select KeyValue from sys_config where keycode ='PTIEN_AO_SMO'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_PTienAo_SMO = p_Table.Rows(0).Item("KeyValue").ToString.Trim
            End If
        End If


        Try



            ' mdlSyncMaster_SyncVehicleDown1("62C00826", l_dem, l_err)
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            p_Desc = ""
            'If g_WcfE5 = True Then

            '    mdlSyncMaster_SyncVehicleDown = g_Services.mdlSyncMaster_SyncVehicleDown(_SapConnectionString, _
            '                                     _dtVariable, _
            '                                     _ShPoint, _
            '                                         _WareHouse, _
            '                                         _TimeOut, _
            '                                     p_DataTablExe, i_getAll, i_date, p_Desc)

            '    Return mdlSyncMaster_SyncVehicleDown
            'End If


            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ztb = New Connect2SAP.Str_PhuongTienTable()
            l_ret2 = New Connect2SAP.BAPIRET2()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetPhuongTien(i_date, i_getAll, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetPhuongTien(i_date, i_getAll, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetPhuongTien(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                'l_bs_details = New BSVehicleDetail()
                If i_getAll <> "H" Then                'Dong bo All
                    p_SQL = "DELETE FROM tblChiTietPhuongtien "
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)
                End If
                For i As Integer = 0 To l_ztb.Count - 1
                    ''p_SQL = "DELETE FROM tblChiTietPhuongtien where MaPhuongTien='" & l_ztb.Item(i).Mapt.ToString() & "'"
                    ''p_Row = p_DataTablExe.NewRow
                    ''p_Row.Item(0) = p_SQL
                    ''p_DataTablExe.Rows.Add(p_Row)

                    If i_getAll = "H" Then                'Dong bo All
                        p_SQL = "DELETE FROM tblChiTietPhuongtien where MaPhuongTien='" & l_ztb.Item(i).Mapt.ToString() & "'"
                        p_Row = p_DataTablExe.NewRow
                        p_Row.Item(0) = p_SQL
                        p_DataTablExe.Rows.Add(p_Row)
                    End If

                    If InStr(p_PTienAo & "," & p_PTienAo_SMO, Replace(l_ztb.Item(i).Mapt.ToString(), "'", "", 1), CompareMethod.Text) > 0 Then
                        Continue For
                    End If
                    p_SQL = "MERGE tblPhuongtien AS target " & _
                        " USING (SELECT N'" & Replace(l_ztb.Item(i).Mapt.ToString(), "'", "", 1) & "' as MaPhuongTien ," & _
                                 "N'" & Replace(l_ztb.Item(i).Loaipt.ToString(), "'", "", 1) & "'  as LaiXe," & _
                                 "" & Convert.ToInt32(l_ztb.Item(i).Songan.ToString()) & "  as SoNgan ," & _
                                 "'" & Replace(l_ztb.Item(i).Ngaybatdau.ToString(), "'", "", 1) & "'  as Ngaybatdau, " & _
                                 "'" & Replace(l_ztb.Item(i).Ngayketthuc.ToString(), "'", "", 1) & "'  as NgayHieuLuc, " & _
                                "'S' as Status) AS source (MaPhuongTien, LaiXe, SoNgan, Ngaybatdau, NgayHieuLuc, Status) " & _
                                " ON (target.MaPhuongTien = source.MaPhuongTien) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "LaiXe=source.LaiXe " & _
                                    ",SoNgan=source.SoNgan " & _
                                    ",Ngaybatdau=source.Ngaybatdau " & _
                                    ",NgayHieuLuc=source.NgayHieuLuc " & _
                                    ",Status=source.Status, SyncDate=getdate() " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (MaPhuongTien, LaiXe, SoNgan, Ngaybatdau, NgayHieuLuc, Status, SyncDate) " & _
                                "VALUES (source.MaPhuongTien,source.LaiXe,source.SoNgan,source.NgayHieuLuc,source.NgayHieuLuc,source.Status, getdate() ) ;"
                    'p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)



                    l_dem = l_dem + 1
                Next

            End If
            mdlSyncMaster_SyncVehicleDetails(p_DataTablExe, isGetAll, i_date)

            If i_getAll <> "H" Then                'Dong bo All
                'p_Row = p_DataTablExe.NewRow
                'p_Row.Item(0) = "delete from tblChiTietPhuongTien where exists (select 1 from tblPhuongTien where ( Status is null or Status=''  or  isnull(SyncDate,getdate()-10) < convert(date,getdate())  )" & _
                '              " and tblChiTietPhuongTien.MaPhuongTien=tblPhuongTien.MaPhuongTien)"
                'p_DataTablExe.Rows.Add(p_Row)

                'p_Row = p_DataTablExe.NewRow
                'p_Row.Item(0) = "delete from tblPhuongTien where Status is null or Status='' or  isnull(SyncDate,getdate()-10) < convert(date,getdate()) "
                'p_DataTablExe.Rows.Add(p_Row)


            End If
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True
        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try
    End Function

#End Region

#Region "Sync Vehicle Details"
    Public Function mdlSyncMaster_SyncVehicleDetails(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_ChiTietPhuongTienTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        ' Dim l_bs As BSVehicleDetail
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim l_mahh As String
        Dim p_SQL As String
        Dim p_Row As DataRow

        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_ChiTietPhuongTienTable()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetChiTietPhuongTien(i_date, i_getall, String.Empty, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetChiTietPhuongTien(i_date, i_getall, String.Empty, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetChiTietPhuongTien(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then

                'If i_getall = "H" Then
                '    p_SQL = "DELETE FROM tblChiTietPhuongtien where MaPhuongTien='" & Replace(l_ztb.Item(0).Mapt.ToString(), "'", "", 1) & "'"
                '    p_Row = p_DataTablExe.NewRow
                '    p_Row.Item(0) = p_SQL
                '    p_DataTablExe.Rows.Add(p_Row)
                'End If
                If i_getall = "H" Then
                    mdlSyncMaster_SyncVehicleDetails_Upd(l_ztb, p_DataTablExe)
                End If


                For i As Integer = 0 To l_ztb.Count - 1
                    ' l_bs = New BSVehicleDetail()
                    l_err = String.Empty
                    l_mahh = String.Empty

                    If InStr(p_PTienAo, Replace(l_ztb.Item(i).Mapt.ToString(), "'", "", 1), CompareMethod.Text) > 0 Then
                        Continue For
                    End If

                    p_SQL = "MERGE tblChiTietPhuongtien AS target " & _
                                           " USING (SELECT '" & Replace(l_ztb.Item(i).Mangan.ToString(), "'", "", 1) & "' as MaNgan," & _
                                                    "'" & Replace(l_ztb.Item(i).Mapt.ToString(), "'", "", 1) & "' as MaPhuongTien," & _
                                                    "" & Convert.ToDecimal(l_ztb.Item(i).Max_Nd.ToString()) & " as SoLuongMax," & _
                                                   "'S' as Status) AS source (MaNgan, MaPhuongTien, SoLuongMax, Status) " & _
                                                   " ON (target.MaPhuongTien = source.MaPhuongTien and target.MaNgan = source.MaNgan) " & _
                                               " WHEN MATCHED  THEN UPDATE SET " & _
                                                       "SoLuongMax=source.SoLuongMax " & _
                                                       ",Status=source.Status " & _
                                            " WHEN NOT MATCHED THEN " & _
                                               "INSERT  (MaNgan, MaPhuongTien, SoLuongMax, Status) " & _
                                                   "VALUES (source.MaNgan,source.MaPhuongTien,source.SoLuongMax,source.Status );"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)
                    'l_bs.InsertVehicleDetail(l_err, _
                    '                         l_ztb.Item(i).Mangan.ToString(), _
                    '                         l_ztb.Item(i).Mapt.ToString(), _
                    '                         Convert.ToDecimal(l_ztb.Item(i).Max_Nd.ToString()), _
                    '                         "S")
                    'If l_err <> "" Then
                    '    l_err = String.Empty
                    '    l_bs.UpdateVehicleDetail(l_err, _
                    '                             l_ztb.Item(i).Mangan.ToString(), _
                    '                             l_ztb.Item(i).Mapt.ToString(), _
                    '                             Convert.ToDecimal(l_ztb.Item(i).Max_Nd.ToString()), _
                    '                             "S")
                    'End If
                    l_dem = l_dem + 1
                Next

                'If i_getall = "H" Then
                '    p_SQL = "Update  tblPhuongtien set SoNgan= where MaPhuongTien='" & Replace(l_ztb.Item(0).Mapt.ToString(), "'", "", 1) & "'"
                '    p_Row = p_DataTablExe.NewRow
                '    p_Row.Item(0) = p_SQL
                '    p_DataTablExe.Rows.Add(p_Row)
                'End If



            End If



            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

    'anhqh
    '20160803
    'Ham xu lus delete ngăn và update phuong tiên
    Private Sub mdlSyncMaster_SyncVehicleDetails_Upd(ByVal l_ztb As Connect2SAP.Str_ChiTietPhuongTienTable, _
                                                            ByRef p_DataTablExe As DataTable)
        Dim p_Count As Integer
        Dim p_RowArr() As DataRow
        Dim p_Row As DataRow
        Dim p_Table As New System.Data.DataTable("Table001")
        Dim p_MaPhuongTien As String
        p_Table.Columns.Add("SQL_STR")
        p_Table.Columns.Add("SoNgan", Type.GetType("System.Int32"))
        Try
            For p_Count = 0 To l_ztb.Count - 1
                p_MaPhuongTien = l_ztb(p_Count).Mapt.ToString.Trim
                p_RowArr = p_Table.Select("SQL_STR='" & p_MaPhuongTien & "'")
                If p_RowArr.Length <= 0 Then
                    p_Row = p_Table.NewRow
                    p_Row(0) = p_MaPhuongTien ' "DELETE FROM tblChiTietPhuongTien where MaPhuongTien='" & p_MaPhuongTien & "'"
                    p_Row(1) = 1
                    p_Table.Rows.Add(p_Row)
                Else

                    p_RowArr(0).Item(1) = p_RowArr(0).Item(1) + 1
                    'p_Row = p_Table.NewRow
                    'p_Row(0) = p_MaPhuongTien ' "DELETE FROM tblChiTietPhuongTien where MaPhuongTien='" & p_MaPhuongTien & "'"
                    'p_Row(1) = p_RowArr.Length + 1
                    'p_Table.Rows.Add(p_Row)
                End If
            Next

            For p_Count = 0 To p_Table.Rows.Count - 1
                p_Row = p_DataTablExe.NewRow
                p_Row(0) = "DELETE FROM tblChiTietPhuongTien where MaPhuongTien='" & p_Table.Rows(p_Count).Item(0).ToString.Trim & "'"
                p_DataTablExe.Rows.Add(p_Row)

                p_Row = p_DataTablExe.NewRow
                p_Row(0) = "UPDATE tblPhuongTien set SoNgan= " & p_Table.Rows(p_Count).Item(1).ToString.Trim & " where MaPhuongTien='" & p_Table.Rows(p_Count).Item(0).ToString.Trim & "'"
                p_DataTablExe.Rows.Add(p_Row)


            Next

        Catch ex As Exception

        End Try


    End Sub

    'Đồng bộ mục đích đo
    Public Function mdlSyncPurpose(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                             ByVal i_date As String, ByRef p_desc As String) As Boolean
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.STR_TANKTable
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
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            'If g_WcfE5 = True Then

            '    mdlSyncMaster_SyncCustomer = g_Services.mdlSyncMaster_SyncCustomer(_SapConnectionString, _
            '                                     _dtVariable, _
            '                                     _ShPoint, _
            '                                         _WareHouse, _
            '                                         _TimeOut, _
            '                                     p_DataTablExe, i_getall, i_date, p_desc)

            '    Return mdlSyncMaster_SyncCustomer
            'End If

            'l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            'l_ret2 = New Connect2SapEx.BAPIRET2()
            'l_ztb = New Connect2SapEx.STR_TANKTable


            '' Connect2SapEx.STR_TANKTable()
            'If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
            '    l_c2sap.    '(GetKhachHang_new(g_Company_Code, i_date, i_getall, l_ztb, l_ret2))
            'Else
            '    l_async = l_c2sap.BeginGetKhachHang_new(g_Company_Code, i_date, i_getall, l_ztb, Nothing, l_c2sap)
            '    l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

            '    If l_isCompleted Then
            '        l_c2sap.EndGetKhachHang_new(l_async, l_ztb, l_ret2)
            '    End If
            'End If

            ''----------------------------------------------------------------------------------------------
            ''   Đưa thông tin vào csdl SQL
            ''----------------------------------------------------------------------------------------------
            'l_dem = 0
            'If l_ztb.Count > 0 Then
            '    For i As Integer = 0 To l_ztb.Count - 1
            '        'Cho dữ liệu vào CSDL SQL

            '        If l_ztb.Item(i).Makh.ToString() = "0000317248" Then
            '            MsgBox("sdfds")
            '        End If
            '        p_SQL = "MERGE tblKhachHang AS target " & _
            '            " USING (SELECT '" & Replace(l_ztb.Item(i).Makh.ToString(), "'", "", 1) & "' as MakhachHang ," & _
            '                     "N'" & Replace(l_ztb.Item(i).Tenkh.ToString(), "'", "", 1) & "'  as TenKhachHang," & _
            '                     "N'" & Replace(l_ztb.Item(i).Diachi.ToString(), "'", "", 1) & "'  as DiaChi ," & _
            '                     "'" & Replace(l_ztb.Item(i).Mst.ToString(), "'", "", 1) & "'  as MST, " & _
            '                    "'X' as Status) AS source (MakhachHang, TenKhachHang, DiaChi, MST, Status) " & _
            '                    " ON (target.MakhachHang = source.MakhachHang) " & _
            '                " WHEN MATCHED  THEN UPDATE SET " & _
            '                        "TenKhachHang=source.TenKhachHang " & _
            '                        ",DiaChi=source.DiaChi " & _
            '                        ",MaSoThue=source.MST " & _
            '                        ",Status=source.Status " & _
            '             " WHEN NOT MATCHED THEN " & _
            '                "INSERT  (MaKhachhang,TenKhachhang,Diachi,MaSoThue,Status ) " & _
            '                    "VALUES (source.MaKhachhang,source.TenKhachhang,source.Diachi,source.MST,source.Status ) ;"
            '        ' p_SQL = Replace(p_SQL, "''", "'", 1)
            '        p_Row = p_DataTablExe.NewRow
            '        p_Row.Item(0) = p_SQL
            '        p_DataTablExe.Rows.Add(p_Row)

            '        l_dem = l_dem + 1
            '    Next
            'End If


            'l_c2sap.Connection.Close()
            'l_c2sap.Dispose()

            Return True

        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try
    End Function


#Region "Sync Customer"
    Public Function mdlSyncMaster_SyncCustomer(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                               ByVal i_date As String, ByRef p_desc As String) As Boolean
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.STR_KH_NEWTable
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
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            'If g_WcfE5 = True Then

            '    mdlSyncMaster_SyncCustomer = g_Services.mdlSyncMaster_SyncCustomer(_SapConnectionString, _
            '                                     _dtVariable, _
            '                                     _ShPoint, _
            '                                         _WareHouse, _
            '                                         _TimeOut, _
            '                                     p_DataTablExe, i_getall, i_date, p_desc)

            '    Return mdlSyncMaster_SyncCustomer
            'End If

            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_ztb = New Connect2SapEx.STR_KH_NEWTable()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetKhachHang_new(g_Company_Code, i_date, i_getall, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetKhachHang_new(g_Company_Code, i_date, i_getall, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetKhachHang_new(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                For i As Integer = 0 To l_ztb.Count - 1
                    'Cho dữ liệu vào CSDL SQL

                  
                    p_SQL = "MERGE tblKhachHang AS target " & _
                        " USING (SELECT '" & Replace(l_ztb.Item(i).Makh.ToString(), "'", "", 1) & "' as MakhachHang ," & _
                                 "N'" & Replace(l_ztb.Item(i).Tenkh.ToString(), "'", "", 1) & "'  as TenKhachHang," & _
                                 "N'" & Replace(l_ztb.Item(i).Diachi.ToString(), "'", "", 1) & "'  as DiaChi ," & _
                                 "'" & Replace(l_ztb.Item(i).Mst.ToString(), "'", "", 1) & "'  as MST, " & _
                                "'X' as Status) AS source (MakhachHang, TenKhachHang, DiaChi, MST, Status) " & _
                                " ON (target.MakhachHang = source.MakhachHang) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "TenKhachHang=source.TenKhachHang " & _
                                    ",DiaChi=source.DiaChi " & _
                                     ",DiaChiFull=source.DiaChi " & _
                                    ",MaSoThue=source.MST " & _
                                    ",Status=source.Status " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (MaKhachhang,TenKhachhang,Diachi,MaSoThue,Status , DiaChiFull) " & _
                                "VALUES (source.MaKhachhang,source.TenKhachhang,source.Diachi,source.MST,source.Status, source.DiaChi ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True

        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try
    End Function
#End Region



    Public Function SynHopDong(ByVal p_Company As String, ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, _
                                 ByRef p_Desc As String) As Boolean
        'Dim bs As BSWareHouse = New Connect2SapEx.BSWareHouse()

        Dim c2sap As Connect2SapEx.Connect2Sap
        Dim ztb As New Connect2SapEx.STR_CONTRACTTable
        Dim ret2 As Connect2SapEx.BAPIRET2
        Dim async As IAsyncResult
        Dim isCompleted As Boolean
        Dim p_SQL As String
        Dim p_Row As DataRow
        Dim p_Table As DataTable
        Dim p_count As Integer

        ' Dim p_SQL As String = ""
        '  Dim ztb As Connect2SAP.Str_KhoTable = New Connect2SAP.Str_KhoTable()

        'Try connect and get Data from SAP
        c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
        p_SQL = "select MaPhuongThucBan from tblPhuongThucBan"

        p_Table = GetDataTable(p_SQL, p_SQL)


        Try
            ret2 = New Connect2SapEx.BAPIRET2()
            For p_count = 0 To p_Table.Rows.Count - 1
                'sale(org)
                'i_dc()
                'và(i_division
                '   )
                If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                    c2sap.GetContract("", "", "", i_date, p_Table.Rows(p_count).Item("MaPhuongThucBan").ToString.Trim, "00", p_Company, ztb, ret2)     '(GetKho(g_Company_Code, _WareHouse, i_getall, ztb, ret2))
                Else
                    async = c2sap.BeginGetContract("", "", "", i_date, p_Table.Rows(p_count).Item("MaPhuongThucBan").ToString.Trim, "00", p_Company, ztb, Nothing, ret2) '(g_Company_Code, _WareHouse, i_getall, ztb, Nothing, c2sap)
                    isCompleted = async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                    If isCompleted Then
                        c2sap.EndGetContract(async, ztb, ret2)
                    End If
                End If

                If ztb.Count > 0 Then
                    For i As Integer = 0 To ztb.Count - 1

                        'If Replace(ztb.Item(i).Vbeln.ToString(), "'", "", 1) = "0040041214" Then
                        '    MsgBox("dfghj")
                        'End If

                        p_SQL = "MERGE tblProjects AS target " & _
                           " USING (SELECT N'" & Replace(ztb.Item(i).Auart.ToString(), "'", "", 1) & "' as Auart ," & _
                                    "N'" & Replace(ztb.Item(i).Guebg.ToString(), "'", "", 1) & "'  as Guebg," & _
                                     "N'" & Replace(ztb.Item(i).Gueen.ToString(), "'", "", 1) & "'  as Gueen," & _
                                      "N'" & Replace(ztb.Item(i).Inco1.ToString(), "'", "", 1) & "'  as Inco1," & _
                                       "N'" & Replace(ztb.Item(i).Kunnr.ToString(), "'", "", 1) & "'  as Kunnr," & _
                                        "N'" & Replace(ztb.Item(i).Matnr.ToString(), "'", "", 1) & "'  as Matnr," & _
                                         "N'" & Replace(ztb.Item(i).Meins.ToString(), "'", "", 1) & "'  as Meins," & _
                                          "N'" & Replace(ztb.Item(i).Posnr.ToString(), "'", "", 1) & "'  as Posnr," & _
                                      "N'" & Replace(ztb.Item(i).Spart.ToString(), "'", "", 1) & "'  as Spart," & _
                                      "N'" & Replace(ztb.Item(i).Vbeln.ToString(), "'", "", 1) & "'  as Vbeln," & _
                                      "N'" & Replace(ztb.Item(i).Vbtyp.ToString(), "'", "", 1) & "'  as Vbtyp," & _
                                      "N'" & Replace(ztb.Item(i).Vkorg.ToString(), "'", "", 1) & "'  as Vkorg," & _
                                       "N'" & Replace(ztb.Item(i).Vtweg.ToString(), "'", "", 1) & "'  as Vtweg" & _
                                   ") AS source (Auart,Guebg,Gueen,Inco1,Kunnr,Matnr,Meins,Posnr,Spart,Vbeln,Vbtyp ,Vkorg,Vtweg) " & _
                                   " ON (target.Vbeln = source.Vbeln) " & _
                               " WHEN MATCHED  THEN UPDATE SET " & _
                                       "Auart=source.Auart,Guebg=source.Guebg,Gueen=source.Gueen,Inco1=source.Inco1," & _
                                        "Kunnr=source.Kunnr,Matnr=source.Matnr,Meins=source.Meins,Posnr=source.Posnr," & _
                                        "Spart=source.Spart,Vbtyp=source.Vbtyp ,Vkorg=source.Vkorg,Vtweg=source.Vtweg" & _
                            " WHEN NOT MATCHED THEN " & _
                               "INSERT  (Auart,Guebg,Gueen,Inco1,Kunnr,Matnr,Meins,Posnr,Spart,Vbeln,Vbtyp ,Vkorg,Vtweg ) " & _
                                   "VALUES (source.Auart,source.Guebg,source.Gueen,source.Inco1,source.Kunnr,source.Matnr," & _
                                   "source.Meins,source.Posnr,source.Spart,source.Vbeln,source.Vbtyp ,source.Vkorg,source.Vtweg) ;"

                        p_Row = p_DataTablExe.NewRow
                        p_Row.Item(0) = p_SQL
                        p_DataTablExe.Rows.Add(p_Row)


                        SynHopDong = SynHopDong_Detail(p_Company, p_DataTablExe, Replace(ztb.Item(i).Vbeln.ToString(), "'", "", 1), i_date, p_Desc, _
                                                        p_Table.Rows(p_count).Item("MaPhuongThucBan").ToString.Trim)

                        If SynHopDong = False Then
                            Return SynHopDong
                        End If
                    Next
                End If

            Next

            SynHopDong = True
        Catch ex As Exception
            p_Desc = ex.Message
            SynHopDong = False
        Finally
            c2sap.Connection.Close()
            c2sap.Dispose()
        End Try

    End Function




    Public Function SynHopDong_Detail(ByVal p_Company As String, ByRef p_DataTablExe As DataTable, ByVal p_Vbeln As String, ByVal i_date As String, _
                                 ByRef p_Desc As String, ByVal p_MaPhuongThucBan As String) As Boolean
        'Dim bs As BSWareHouse = New Connect2SapEx.BSWareHouse()

        Dim c2sap As Connect2SapEx.Connect2Sap
        Dim ztb As New Connect2SapEx.STR_CONTRACTTable
        Dim ret2 As Connect2SapEx.BAPIRET2
        Dim async As IAsyncResult
        Dim isCompleted As Boolean
        Dim p_SQL As String
        Dim p_Row As DataRow
        Dim p_Table As DataTable
        Dim p_count As Integer

        ' Dim p_SQL As String = ""
        '  Dim ztb As Connect2SAP.Str_KhoTable = New Connect2SAP.Str_KhoTable()

        'Try connect and get Data from SAP
        c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
        '   p_SQL = "select MaPhuongThucBan from tblPhuongThucBan"

        'p_Table = GetDataTable(p_SQL, p_SQL)


        Try
            ret2 = New Connect2SapEx.BAPIRET2()
            ' For p_count = 0 To p_Table.Rows.Count - 1
            'sale(org)
            'i_dc()
            'và(i_division
            '   )
            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                c2sap.GetContract(p_Vbeln, "", "", i_date, p_MaPhuongThucBan, "00", p_Company, ztb, ret2)     '(GetKho(g_Company_Code, _WareHouse, i_getall, ztb, ret2))
            Else
                async = c2sap.BeginGetContract(p_Vbeln, "", "", i_date, p_MaPhuongThucBan, "00", p_Company, ztb, Nothing, ret2) '(g_Company_Code, _WareHouse, i_getall, ztb, Nothing, c2sap)
                isCompleted = async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If isCompleted Then
                    c2sap.EndGetContract(async, ztb, ret2)
                End If
            End If

            If ztb.Count > 0 Then
                For i As Integer = 0 To ztb.Count - 1
                    p_SQL = "MERGE tblProject_Details  AS target " & _
                       " USING (SELECT N'" & Replace(ztb.Item(i).Auart.ToString(), "'", "", 1) & "' as Auart ," & _
                                "N'" & Replace(ztb.Item(i).Guebg.ToString(), "'", "", 1) & "'  as Guebg," & _
                                 "N'" & Replace(ztb.Item(i).Gueen.ToString(), "'", "", 1) & "'  as Gueen," & _
                                  "N'" & Replace(ztb.Item(i).Inco1.ToString(), "'", "", 1) & "'  as Inco1," & _
                                   "N'" & Replace(ztb.Item(i).Kunnr.ToString(), "'", "", 1) & "'  as Kunnr," & _
                                    "N'" & Right(Replace(ztb.Item(i).Matnr.ToString(), "'", "", 1), 7) & "'  as Matnr," & _
                                     "N'" & Replace(ztb.Item(i).Meins.ToString(), "'", "", 1) & "'  as Meins," & _
                                      "N'" & Replace(ztb.Item(i).Posnr.ToString(), "'", "", 1) & "'  as Posnr," & _
                                  "N'" & Replace(ztb.Item(i).Spart.ToString(), "'", "", 1) & "'  as Spart," & _
                                  "N'" & Replace(ztb.Item(i).Vbeln.ToString(), "'", "", 1) & "'  as Vbeln," & _
                                  "N'" & Replace(ztb.Item(i).Vbtyp.ToString(), "'", "", 1) & "'  as Vbtyp," & _
                                  "N'" & Replace(ztb.Item(i).Vkorg.ToString(), "'", "", 1) & "'  as Vkorg," & _
                                   "N'" & Replace(ztb.Item(i).Vtweg.ToString(), "'", "", 1) & "'  as Vtweg" & _
                               ") AS source (Auart,Guebg,Gueen,Inco1,Kunnr,Matnr,Meins,Posnr,Spart,Vbeln,Vbtyp ,Vkorg,Vtweg) " & _
                               " ON (target.Vbeln = source.Vbeln   and   target.Matnr = source.Matnr ) " & _
                           " WHEN MATCHED  THEN UPDATE SET " & _
                                   "Auart=source.Auart,Guebg=source.Guebg,Gueen=source.Gueen,Inco1=source.Inco1," & _
                                    "Kunnr=source.Kunnr,Matnr=source.Matnr,Meins=source.Meins,Posnr=source.Posnr," & _
                                    "Spart=source.Spart,Vbtyp=source.Vbtyp ,Vkorg=source.Vkorg,Vtweg=source.Vtweg" & _
                        " WHEN NOT MATCHED THEN " & _
                           "INSERT  (Auart,Guebg,Gueen,Inco1,Kunnr,Matnr,Meins,Posnr,Spart,Vbeln,Vbtyp ,Vkorg,Vtweg ) " & _
                               "VALUES (source.Auart,source.Guebg,source.Gueen,source.Inco1,source.Kunnr,source.Matnr," & _
                               "source.Meins,source.Posnr,source.Spart,source.Vbeln,source.Vbtyp ,source.Vkorg,source.Vtweg) ;"

                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)
                Next
            End If

            'Next

            SynHopDong_Detail = True
        Catch ex As Exception
            p_Desc = ex.Message
            SynHopDong_Detail = False
        Finally
            c2sap.Connection.Close()
            c2sap.Dispose()
        End Try

    End Function


    Public Function SynKho(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, _
                                 ByRef p_Desc As String) As Boolean
        'Dim bs As BSWareHouse = New Connect2SapEx.BSWareHouse()

        Dim c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SapEx.STR_KH_NEWTable
        Dim ret2 As Connect2SAP.BAPIRET2
        Dim async As IAsyncResult
        Dim isCompleted As Boolean
        Dim p_SQL As String
        Dim p_Row As DataRow
        Dim ztb As Connect2SAP.Str_KhoTable = New Connect2SAP.Str_KhoTable()

        'Try connect and get Data from SAP
        c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
        Try
            ret2 = New Connect2SAP.BAPIRET2()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                c2sap.GetKho(g_Company_Code, _WareHouse, i_getall, ztb, ret2)
            Else
                async = c2sap.BeginGetKho(g_Company_Code, _WareHouse, i_getall, ztb, Nothing, c2sap)
                isCompleted = async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If isCompleted Then
                    c2sap.EndGetKho(async, ztb, ret2)
                End If
            End If

            If ztb.Count > 0 Then
                For i As Integer = 0 To ztb.Count - 1
                    p_SQL = "MERGE tblKho AS target " & _
                       " USING (SELECT N'" & Replace(ztb.Item(i).Makho.ToString(), "'", "", 1) & "' as MaKho ," & _
                                "N'" & Replace(ztb.Item(i).Tenkho.ToString(), "'", "", 1) & "'  as TenKho," & _
                                "N'" & g_Company_Code & "'  as MaDonVi ," & _
                               "'S' as Status) AS source (MaKho, TenKho, MaDonVi,  Status) " & _
                               " ON (target.MaKho = source.MaKho) " & _
                           " WHEN MATCHED  THEN UPDATE SET " & _
                                   "TenKho=source.TenKho " & _
                                   ",MaDonVi=source.MaDonVi " & _
                                   ",Status=source.Status " & _
                        " WHEN NOT MATCHED THEN " & _
                           "INSERT  (MaKho,TenKho,MaDonVi,Status ) " & _
                               "VALUES (source.MaKho,source.TenKho,source.MaDonVi,source.Status ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)
                Next
            End If
            'If ztb.Count > 0 Then
            '    For i As Integer = 0 To ztb.Count - 1
            '        'Cho dữ liệu vào CSDL SQL
            '        err = ""
            '        bs.InsertWareHouse(err, ztb.Item(i).Makho.ToString(), _CompanyCode, ztb.Item(i).Tenkho.ToString(), "")
            '        If err <> "" Then
            '            err = ""
            '            If ztb.Item(i).Makho.ToString() = _WareHouse Then
            '                bs.UpdateWareHouse(err, ztb.Item(i).Makho.ToString(), _CompanyCode, ztb.Item(i).Tenkho.ToString(), "X")
            '            Else
            '                bs.UpdateWareHouse(err, ztb.Item(i).Makho.ToString(), _CompanyCode, ztb.Item(i).Tenkho.ToString(), "")
            '            End If
            '        End If
            '        dem = dem + 1
            '    Next
            'End If

            ''Đưa thông tin vào bảng Log trong SQL
            'Dim l_date As String = Now().Day.ToString()
            'If (l_date.Length < 2) Then
            '    l_date = "0" & l_date
            'End If

            'Dim l_month As String = Now().Month.ToString()
            'If (l_month.Length < 2) Then
            '    l_month = "0" & l_month
            'End If

            'Dim l_year As String = Now().Year.ToString()

            'l_date = l_year & "." & l_month & "." & l_date


            'bslog.UpdateLogSyn(Err, "Kho", l_date, dem)


            SynKho = True
        Catch ex As Exception
            p_Desc = ex.Message
            SynKho = False
        Finally
            c2sap.Connection.Close()
            c2sap.Dispose()
        End Try

    End Function


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
        Dim p_Time As Integer

        Dim p_Date As Date
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_Row As DataRow
        Dim p_Count22 As Integer
        Dim p_CompantCode As String = ""
        Dim p_DataCompany As DataTable
        If p_DataTablExe Is Nothing Then
            p_DataTablExe = New DataTable("Table001")
            p_DataTablExe.Columns.Add("STR_SQL")

        End If
        Try
            p_desc = ""
            p_GetDateTime(p_Date, p_Time)

            i_date = p_Date.ToString("yyyy.MM.dd")
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            ' p_CompantCode = g_Company_Code
            p_SQL = "select distinct MaDonVi from (" & _
                    " select  MaDOnVi from tblKHo  where MaDonVi like '" & Strings.Left(g_Company_Code, 2) & "%' " & _
                    " union all select '6610' as  MaDOnVi  )  abc order by MaDonVi"
            p_DataCompany = GetDataTable(p_SQL, p_SQL)
            If Not p_DataCompany Is Nothing Then
                l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
                l_ret2 = New Connect2SapEx.BAPIRET2()
                l_ztb = New Connect2SapEx.STR_VK13Table()


                For p_Count22 = 0 To p_DataCompany.Rows.Count - 1
                    p_CompantCode = p_DataCompany.Rows(p_Count22).Item(0).ToString.Trim

                    'If g_WcfE5 = True Then

                    '    mdlSyncMaster_SyncPrice = g_Services.ClsSyncMaster_SyncPrice(p_DataTablExe, i_date, p_desc)

                    '    Return mdlSyncMaster_SyncPrice
                    'End If


                    If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                        l_c2sap.GetVk13(i_date, String.Empty, String.Empty, p_CompantCode, l_ret2, l_ztb)
                    Else
                        l_async = l_c2sap.BeginGetVk13(i_date, String.Empty, String.Empty, p_CompantCode, l_ztb, Nothing, l_c2sap)
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
                            p_DonGia = 0
                            If l_ztb.Item(i).Kpein > 0 Then
                                p_DonGia = l_ztb.Item(i).Kbetr / l_ztb.Item(i).Kpein
                            End If


                            If Integer.TryParse(l_ztb.Item(i).Matnr, Nothing) Then
                                l_ztb.Item(i).Matnr = l_ztb.Item(i).Matnr.Substring(l_ztb.Item(i).Matnr.Length - 7)
                            End If

                            '
                            'If l_ztb.Item(i).Knumh.ToString().Trim = "0001693769" Then
                            '    MsgBox("sdsdd")
                            'End If

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
                                        ",getdate() as UpdateDate ) AS source (KAPPL, KSCHL, VKORG, VTWEG, KUNNR, MATNR, VRKME, ZTERM, KFRST, DATBI, DATAB, KBSTAT, KNUMH, KBETR, WAERS, KPEIN, KMEIN, DonGia, ALAND, KONDA, Inco1, Inco2, UpdateDate ) " & _
                                        " ON (target.KNUMH = source.KNUMH)  " & _
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
                                            "Inco2=source.Inco2, " & _
                                             "UpdateDate=source.UpdateDate " & _
                                 " WHEN NOT MATCHED THEN " & _
                                    "INSERT  (KAPPL, KSCHL, VKORG, VTWEG, KUNNR, MATNR, VRKME, ZTERM, KFRST, DATBI, DATAB, KBSTAT, KNUMH, KBETR, WAERS, KPEIN, KMEIN, DonGia, ALAND, KONDA, Inco1, Inco2 ) " & _
                                    "VALUES (source.KAPPL, source.KSCHL, source.VKORG, source.VTWEG, source.KUNNR, source.MATNR, source.VRKME, source.ZTERM, source.KFRST, source.DATBI, source.DATAB, source.KBSTAT, source.KNUMH, source.KBETR, source.WAERS, source.KPEIN, source.KMEIN, source.DonGia, source.ALAND, source.KONDA, source.Inco1, source.Inco2 ) ;"
                            ' p_SQL = Replace(p_SQL, "''", "'", 1)
                            p_Row = p_DataTablExe.NewRow
                            p_Row.Item(0) = p_SQL
                            p_DataTablExe.Rows.Add(p_Row)

                            l_dem = l_dem + 1
                        Next

                        If mdlSyncMaster_SyncPrice_Ex(p_DataTablExe, i_date, p_desc, p_CompantCode) = False Then
                            p_desc = "mdlSyncMaster_SyncPrice_Ex:" & p_desc
                            Return False
                        End If
                        If p_DataTablExe.Rows.Count > 0 Then
                            p_SQL = ""
                            p_SQL = getStringSyn("DonGia", p_DataTablExe.Rows.Count)
                            If p_SQL <> "" Then
                                p_Row = p_DataTablExe.NewRow
                                p_Row.Item(0) = p_SQL
                                p_DataTablExe.Rows.Add(p_Row)
                            End If

                        
                        End If

                    End If






                    p_desc = ""
                    If p_DataTablExe.Rows.Count > 0 Then
                        g_Services.Sys_Execute_DataTbl(p_DataTablExe, p_desc)
                    End If
                    p_DataTablExe.Clear()
                    If p_desc <> "" Then
                        l_c2sap.Connection.Close()
                        l_c2sap.Dispose()
                        Return False
                    End If
                Next
                l_c2sap.Connection.Close()
                l_c2sap.Dispose()
            End If
            Return True



        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try
    End Function

    Private Function getStringSyn(ByVal p_Para As String, ByVal p_Count As Integer) As String
        Dim p_SQL As String = ""
        Try
            p_SQL = "MERGE tblLogSyn AS target " & _
                       " USING (	SELECT 0 as [Stt] ,'" & p_Para & "' as [Para] ,convert(nvarchar(20),getdate(),102) as [SynDate]  ," & p_Count & " as [SynCount]  " & _
                        " ) AS source ([Stt] ,[Para] ,[SynDate]  , [SynCount] ) on  (target.Para =Source.Para )  " & _
                        " WHEN MATCHED  THEN UPDATE SET SynDate =source.SynDate , dDate =getdate() " & _
                        " WHEN NOT MATCHED THEN  " & _
                    " Insert([Stt], [Para], [SynDate], [SynCount], dDate) " & _
                        " VALUES ((select isnull( max(stt),0) +1 from tblLogSyn), Source.Para,source.SynDate, Source.SynCount, getdate() ) ;"
        Catch ex As Exception
            p_SQL = ""
        End Try
        Return p_SQL
    End Function

#End Region
#Region "Bang gia phi van tai"
    Public Function mdlSyncMaster_SyncPrice_Ex(ByRef p_DataTablExe As DataTable, ByVal i_date As String, ByRef p_desc As String, Optional ByVal p_CompanyCode2 As String = "") As Boolean
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.STR_TK13Table
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String
        Dim p_DonGia As Decimal = 0
        Dim p_Time As Integer

        Dim p_Date As Date
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_Row As DataRow

        Dim p_Price As Double

        If p_DataTablExe Is Nothing Then
            p_DataTablExe = New DataTable("Table001")
            p_DataTablExe.Columns.Add("STR_SQL")

        End If
        Try
            p_desc = ""
            p_GetDateTime(p_Date, p_Time)

            i_date = p_Date.ToString("yyyy.MM.dd")
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            'If g_WcfE5 = True Then

            '    mdlSyncMaster_SyncPrice_Ex = g_Services.ClsSyncMaster_SyncPrice(p_DataTablExe, i_date, p_desc)

            '    Return mdlSyncMaster_SyncPrice_Ex
            'End If

            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_ztb = New Connect2SapEx.STR_TK13Table()
            If p_CompanyCode2 = "" Then
                p_CompanyCode2 = g_Company_Code
            End If
            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetTk13(i_date, String.Empty, p_CompanyCode2, l_ret2, l_ztb)
            Else
                l_async = l_c2sap.BeginGetTk13(i_date, String.Empty, p_CompanyCode2, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetTk13(l_async, l_ret2, l_ztb)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                For i As Integer = 0 To l_ztb.Count - 1
                    'If l_ztb.Item(i).Waers.ToString() = "VND" Then
                    '    l_ztb.Item(i).Kbetr = l_ztb.Item(i).Kbetr * 100
                    'End If

                    p_DonGia = 0
                    If l_ztb.Item(i).Kpein > 0 Then
                        p_DonGia = l_ztb.Item(i).Kbetr / l_ztb.Item(i).Kpein
                    End If

                    'p_Price()

                    'Cho dữ liệu vào CSDL SQL
                    p_SQL = "MERGE tblDonGia_Ex AS target " & _
                        " USING (SELECT '" & Replace(l_ztb.Item(i).Kappl.ToString(), "'", "", 1) & "' as KAPPL ," & _
                                  "'" & Replace(l_ztb.Item(i).Kschl.ToString(), "'", "", 1) & "'  as KSCHL ," & _
                                  "'" & Replace(l_ztb.Item(i).Bukrs.ToString(), "'", "", 1) & "'  as BUKRS ," & _
                                  "'" & Replace(l_ztb.Item(i).Vsart.ToString(), "'", "", 1) & "'  as VSART ," & _
                                  "'" & Replace(l_ztb.Item(i).Tdlnr.ToString(), "'", "", 1) & "'  as TDLNR ," & _
                                  "'" & Replace(l_ztb.Item(i).Knota.ToString(), "'", "", 1) & "'  as KNOTA ," & _
                                  "'" & Replace(l_ztb.Item(i).Oigknotd.ToString(), "'", "", 1) & "'  as OIGKNOTD ," & _
                                  "'" & Replace(l_ztb.Item(i).Matnr.ToString(), "'", "", 1) & "'  as MATNR ," & _
                                  "'" & Replace(l_ztb.Item(i).Vrkme.ToString(), "'", "", 1) & "'  as VRKME ," & _
                                  "'" & Replace(l_ztb.Item(i).Kfrst.ToString(), "'", "", 1) & "'  as KFRST ," & _
                                  "'" & CDate(Mid(l_ztb.Item(i).Datbi.ToString(), 5, 2) & "-" & Right(l_ztb.Item(i).Datbi.ToString(), 2) & "-" & Left(l_ztb.Item(i).Datbi.ToString(), 4)).ToString("MM-dd-yyyy") & "'  as DATBI ," & _
                                  "'" & CDate(Mid(l_ztb.Item(i).Datab.ToString(), 5, 2) & "-" & Right(l_ztb.Item(i).Datab.ToString(), 2) & "-" & Left(l_ztb.Item(i).Datab.ToString(), 4)).ToString("MM-dd-yyyy") & "'  as DATAB ," & _
                                  "'" & Replace(l_ztb.Item(i).Kbstat.ToString(), "'", "", 1) & "'  as KBSTAT ," & _
                                  Replace(l_ztb.Item(i).Knumh.ToString(), "'", "", 1) & "  as KNUMH ," & _
                                  "" & Replace(p_DonGia.ToString(), "'", "", 1) & "  as KBETR ," & _
                                  "'" & Replace(l_ztb.Item(i).Waers.ToString(), "'", "", 1) & "'  as WAERS ," & _
                                  "" & Replace(l_ztb.Item(i).Kpein.ToString(), "'", "", 1) & "  as KPEIN ," & _
                                  "'" & Replace(l_ztb.Item(i).Kmein.ToString(), "'", "", 1) & "'  as KMEIN ," & _
                                  "'" & Replace(l_ztb.Item(i).Aland.ToString(), "'", "", 1) & "'  as ALAND ," & _
                                  "'" & Replace(l_ztb.Item(i).Konda.ToString(), "'", "", 1) & "'  as KONDA ," & _
                                     "'" & Replace(l_ztb.Item(i).Inco1.ToString(), "'", "", 1) & "'  as INCO1, " & _
                                  "'" & Replace(l_ztb.Item(i).Inco2.ToString(), "'", "", 1) & "'  as Inco2, " & _
                                  "" & Replace(l_ztb.Item(i).Kbetr.ToString(), "'", "", 1) & "  as DonGiaPer " & _
                                "  ) AS source (KAPPL,KSCHL,BUKRS,VSART,TDLNR, KNOTA,OIGKNOTD,MATNR,VRKME,KFRST,DATBI,DATAB, " & _
                                    " KBSTAT, KNUMH, KBETR, WAERS, KPEIN, KMEIN, ALAND,KONDA, INCO1,INCO2, DonGiaPer) " & _
                                " ON (target.KNUMH = source.KNUMH ) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    " KAPPL = source.KAPPL , " & _
                                    " KSCHL = source.KSCHL,  " & _
                                    " BUKRS = source.BUKRS,  " & _
                                    " VSART = source.VSART , " & _
                                    " TDLNR = source.TDLNR,  " & _
                                    " KNOTA = source.KNOTA,  " & _
                                    " OIGKNOTD = source.OIGKNOTD,  " & _
                                    " MATNR = source.MATNR,  " & _
                                    " VRKME = source.VRKME , " & _
                                    " KFRST = source.KFRST, " & _
                                    " DATBI = source.DATBI , " & _
                                    " DATAB = source.DATAB,  " & _
                                    " KBSTAT = source.KBSTAT,  " & _
                                    " KNUMH = source.KNUMH,  " & _
                                    " KBETR = source.KBETR,  " & _
                                    " WAERS = source.WAERS , " & _
                                    " KPEIN = source.KPEIN , " & _
                                    " KMEIN = source.KMEIN,  " & _
                                    " ALAND = source.ALAND , " & _
                                    " KONDA = source.KONDA , " & _
                                     " INCO1 = source.INCO1 , " & _
                                    " INCO2 = source.INCO2,  " & _
                                    " DonGiaPer =source.DonGiaPer ," & _
                                      " dDate = getdate()   " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (KAPPL,KSCHL,BUKRS,VSART,TDLNR, KNOTA,OIGKNOTD,MATNR,VRKME,KFRST,DATBI,DATAB, " & _
                                    " KBSTAT, KNUMH, KBETR, WAERS, KPEIN, KMEIN, ALAND,KONDA, INCO1,INCO2, dDate, DonGiaPer) " & _
                            "VALUES (source.KAPPL,source.KSCHL,source.BUKRS,source.VSART,source.TDLNR, source.KNOTA,source.OIGKNOTD,source.MATNR,source.VRKME,source.KFRST,source.DATBI,source.DATAB, " & _
                                    " source.KBSTAT, source.KNUMH, source.KBETR, source.WAERS, source.KPEIN, source.KMEIN, source.ALAND,source.KONDA, source.INCO1,source.INCO2, getdate(), source.DonGiaPer ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

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
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            If g_WcfE5 = True Then

                mdlSyncMaster_SyncPaymentTerm = g_Services.ClsSyncMaster_SyncPaymentTerm(p_DataTablExe, p_desc)

                Return mdlSyncMaster_SyncPaymentTerm
            End If

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
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            If g_WcfE5 = True Then

                mdlSyncMaster_SyncDischard = g_Services.ClsSyncMaster_SyncDischard(p_DataTablExe, p_desc)

                Return mdlSyncMaster_SyncDischard
            End If

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
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            If g_WcfE5 = True Then
                mdlSyncMaster_SyncRoute = g_Services.ClsSyncMaster_SyncRoute(p_DataTablExe, p_desc)

                Return mdlSyncMaster_SyncRoute
            End If

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
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            If g_WcfE5 = True Then

                mdlSyncMaster_SyncVendor = g_Services.ClsSyncMaster_SyncVendor(p_DataTablExe, i_getall, _
                                                 i_date, p_desc)

                Return mdlSyncMaster_SyncVendor
            End If

            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_ztb = New Connect2SapEx.STR_VENDORTable

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetVendor(g_Company_Code, i_date, i_getall, l_ztb, l_ret2)
                ' l_c2sap.GetVk13(i_date, "", "", g_Company_Code, l_ret2, l_ztb)
            Else
                l_async = l_c2sap.BeginGetVendor(g_Company_Code, i_date, i_getall, l_ztb, Nothing, l_c2sap)

                'l_async = l_c2sap.BeginGetVk13(i_date, "", "", g_Company_Code, l_ztb, Nothing, l_c2sap)


                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetVendor(l_async, l_ztb, l_ret2)
                    ' l_c2sap.EndGetVk13(l_async, l_ret2, l_ztb)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                For i As Integer = 0 To l_ztb.Count - 1


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

            Return True

        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try
    End Function
#End Region
    'end hieptd4 add 20161027
#Region "Sync Material"
    Public Function mdlSyncMaster_SyncMaterial(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                               ByVal i_date As String, _
                                                ByRef p_desc As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_HangHoaTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        '   Dim l_bs As BSProduct
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim l_mahh As String
        Dim p_SQL As String
        Dim p_Row As DataRow

        Try
            p_desc = ""
            If g_WcfE5 = True Then
                'Function mdlSyncMaster_SyncMaterial(ByVal _SapConnectionString As String, ByVal _dtVariable As System.Data.DataTable, 
                '    ByVal _ShPoint As String, ByVal _WareHouse As String, ByVal _TimeOut As String, ByRef p_DataTablExe As System.Data.DataTable,
                '    ByVal i_getall As String, ByVal i_date As String) As Boolean
                mdlSyncMaster_SyncMaterial = g_Services.mdlSyncMaster_SyncMaterial(_SapConnectionString, _
                                                 _dtVariable, _
                                                 _ShPoint, _
                                                     _WareHouse, _
                                                     _TimeOut, _
                                                 p_DataTablExe, i_getall, i_date, p_desc)

                Exit Function
            End If

            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_HangHoaTable()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetHangHoa(g_Company_Code, _ShPoint, i_getall, i_date, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetHangHoa(g_Company_Code, _WareHouse, i_getall, i_date, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetHangHoa(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                For i As Integer = 0 To l_ztb.Count - 1
                    ' l_bs = New BSProduct()
                    l_err = String.Empty
                    l_mahh = String.Empty

                    If l_ztb.Item(i).Mahh.Length > 7 Then
                        l_mahh = l_ztb.Item(i).Mahh.Substring(l_ztb.Item(i).Mahh.Length - 7, 7)
                    Else
                        l_mahh = l_ztb.Item(i).Mahh.Substring(0, l_ztb.Item(i).Mahh.Length)
                    End If

                    p_SQL = "MERGE tblhangHoa AS target " & _
                                            " USING (SELECT '" & l_mahh & "' as MaHangHoa," & _
                                                     "N'" & Replace(l_ztb.Item(i).Tenhh.ToString(), "'", "", 1) & "' as TenhangHoa," & _
                                                     "'" & Replace(l_ztb.Item(i).Donvt.ToString().Trim(), "'", "", 1) & "' as DonViTinh," & _
                                                    "'X' as Status) AS source (MaHangHoa, TenhangHoa, DonViTinh, Status) " & _
                                                    " ON (target.MaHangHoa = source.MaHangHoa) " & _
                                                " WHEN MATCHED  THEN UPDATE SET " & _
                                                        "TenhangHoa=source.TenhangHoa " & _
                                                        ",DonViTinh=source.DonViTinh " & _
                                                        ",Status=source.Status " & _
                                             " WHEN NOT MATCHED THEN " & _
                                                "INSERT  (MaHangHoa, TenhangHoa, DonViTinh, Status ) " & _
                                                    "VALUES (source.MaHangHoa,source.TenhangHoa,source.DonViTinh,source.Status ); "
                    'p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    'l_bs.InsertProduct(l_err, l_mahh, l_ztb.Item(i).Tenhh.ToString(), l_ztb.Item(i).Donvt.ToString().Trim(), "X")
                    'If l_err <> "" Then
                    '    l_err = ""
                    '    l_bs.UpdateProduct(l_err, l_mahh, l_ztb.Item(i).Tenhh.ToString(), l_ztb.Item(i).Donvt.ToString().Trim(), "X")
                    'End If
                    l_dem = l_dem + 1
                Next
            End If

            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True

        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try
    End Function
#End Region

#Region "Nguon hang"
    Public Function SynNguonHang(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, _
                                 ByRef p_Desc As String) As Boolean
        'Dim bs As BSProductSource = New BSProductSource()
        Dim ztb As Connect2SapEx.STR_NguonTable = New Connect2SapEx.STR_NguonTable()
        Dim c2sap = New Connect2SapEx.Connect2Sap()
        Dim ret2 As Connect2SapEx.BAPIRET2
        Dim async As IAsyncResult
        Dim isCompleted As Boolean
        Dim Err As String
        Dim p_SQL As String
        Dim p_Row As DataRow

        'Try connect and get data from SAP
        p_Desc = ""

        If g_WcfE5 = True Then

            SynNguonHang = g_Services.SynNguonHang(_SapConnectionString, _
                                             _dtVariable, _
                                             _ShPoint, _
                                                 _WareHouse, _
                                                 _TimeOut, _
                                             p_DataTablExe, i_getall, i_date, p_Desc)

            Return SynNguonHang
        End If
        c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
        Try
            ret2 = New Connect2SapEx.BAPIRET2()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                c2sap.GetNguon_New(ztb, ret2)
            Else
                'async = c2sap.BeginGetNguon_New(ztb, Nothing, c2sap)
                'isCompleted = async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                'If isCompleted Then
                '    c2sap.EndGetNguon_New(async, ztb, ret2)
                'End If
            End If


            If ztb.Count > 0 Then
                For i As Integer = 0 To ztb.Count - 1
                    'Cho dữ liệu vào CSDL SQL

                    p_SQL = "MERGE tblNguon AS target " & _
                                            " USING (SELECT '" & Replace(ztb.Item(i).Zmanguon.ToString(), "'", "", 1) & "' as Manguon," & _
                                                    "'X' as Status, N'" & ztb.Item(i).Ztennguon.ToString() & "' as TenNguon) AS source (Manguon,  Status, TenNguon) " & _
                                                    " ON (target.Manguon = source.Manguon) " & _
                                                " WHEN MATCHED  THEN UPDATE SET " & _
                                                        "Status=source.Status, TenNguon=source.TenNguon  " & _
                                             " WHEN NOT MATCHED THEN " & _
                                                "INSERT  (Manguon,Status, TenNguon ) " & _
                                                    "VALUES (source.Manguon,source.Status, source.TenNguon ); "

                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)
                Next
            End If

            SynNguonHang = True

        Catch ex As Exception
            p_Desc = ex.Message
            SynNguonHang = False
        Finally
            c2sap.Connection.Close()
            c2sap.Dispose()
        End Try

    End Function

#End Region

#Region "Sync Mod/Trans."
    Public Function mdlSyncMaster_SyncTransport(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByRef p_Desc As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_VanChuyen_NoTDTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        'Dim l_bs As BSTranport
        Dim p_SQL As String
        Dim p_Row As DataRow
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0

        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            p_Desc = ""
            If g_WcfE5 = True Then

                mdlSyncMaster_SyncTransport = g_Services.mdlSyncMaster_SyncTransport(_SapConnectionString, _
                                                 _dtVariable, _
                                                 _ShPoint, _
                                                     _WareHouse, _
                                                     _TimeOut, _
                                                 p_DataTablExe, i_getall, p_Desc)

                Return mdlSyncMaster_SyncTransport
            End If


            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_VanChuyen_NoTDTable()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetVanChuyen_NoTD(i_getall, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetVanChuyen_NoTD(i_getall, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetVanChuyen_NoTD(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Xóa csdl SQL đã có
            '----------------------------------------------------------------------------------------------
            'If l_ztb.Count > 0 Then
            '    If Not mdlSyncMaster_SynVanChuyen_Delete(l_ztb) Then
            '        Return False
            '    End If
            'End If
            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                For i As Integer = 0 To l_ztb.Count - 1
                    p_SQL = "MERGE tblVanChuyen AS target " & _
                                            " USING (SELECT '" & Replace(l_ztb.Item(i).Malhvc.ToString(), "'", "", 1) & "' as MaVanChuyen," & _
                                                     "N'" & Replace(l_ztb.Item(i).Tenlhvc.ToString(), "'", "", 1) & "' as TenVanChuyen," & _
                                                    "'X' as Status) AS source (MaVanChuyen, TenVanChuyen, Status) " & _
                                                    " ON (target.MaVanChuyen = source.MaVanChuyen) " & _
                                                " WHEN MATCHED  THEN UPDATE SET " & _
                                                        "TenVanChuyen=source.TenVanChuyen " & _
                                                        ",Status=source.Status " & _
                                             " WHEN NOT MATCHED THEN " & _
                                                "INSERT  (MaVanChuyen,TenVanChuyen,Status ) " & _
                                                    "VALUES (source.MaVanChuyen,source.TenVanChuyen,source.Status ); "

                    'p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)


                    l_dem = l_dem + 1
                Next
            End If

            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True

        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try

    End Function

#End Region

#Region "Sync Meter"
#End Region

#Region "Sync Tank"
    Public Function mdlSyncMaster_SyncTank(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                           ByVal i_date As String, _
                                           ByVal i_plant As String, ByRef p_desc As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_TankTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        ' Dim l_bs_tank As BSTank
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_SQL As String
        Dim p_Row As DataRow
        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy các loại phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            p_desc = ""

            If g_WcfE5 = True Then

                mdlSyncMaster_SyncTank = g_Services.mdlSyncMaster_SyncTank(_SapConnectionString, _
                                                 _dtVariable, _
                                                 _ShPoint, _
                                                     _WareHouse, _
                                                     _TimeOut, _
                                                 p_DataTablExe, i_getall, i_date, i_plant, p_desc)

                Return mdlSyncMaster_SyncTank
            End If


            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ztb = New Connect2SAP.Str_TankTable()
            l_ret2 = New Connect2SAP.BAPIRET2()

            l_c2sap.Connection.Open()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetTank(i_date, i_getall, i_plant, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetTank(i_date, i_getall, i_plant, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetTank(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa dữ liệu vào hệ thống SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count <= 0 Then
                Return False
            End If
            '----------------------------------------------------------------------------------------------
            '   Đưa dữ liệu vào bảng Header
            '----------------------------------------------------------------------------------------------
            l_dem = l_ztb.Count
            For i As Integer = 0 To l_ztb.Count - 1
                'l_bs_tank = New BSTank()
                p_SQL = "MERGE tblTank AS target " & _
                                            " USING (SELECT '" & Replace(l_ztb.Item(i).Seqnr.ToString(), "'", "", 1) & "' as Name_nd " & _
                                                     ") AS source (Name_nd) " & _
                                                    " ON (target.Name_nd = source.Name_nd) " & _
                                                " WHEN MATCHED  THEN UPDATE SET " & _
                                                        "Map_Sap1=source.Name_nd " & _
                                                        " " & _
                                             " WHEN NOT MATCHED THEN " & _
                                                "INSERT  (Name_nd, Map_Sap1) " & _
                                                    "VALUES (source.Name_nd,source.Name_nd); "

                '  p_SQL = Replace(p_SQL, "''", "'", 1)
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)

            Next


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True
        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try

    End Function
#End Region
    Public Function mdlSyncMaster_SyncTank_ATG(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                         ByVal i_date As String, _
                                         ByVal i_plant As String, ByRef p_desc As String, ByVal l_Time As String) As Boolean

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        ' Dim l_bs_tank As BSTank
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_SQL As String
        Dim p_Row As DataRow
        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy các loại phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            p_desc = ""


            Dim l_c2sap As Connect2SapEx.Connect2Sap
            Dim l_ztb As Connect2SapEx.STR_TANKTable
            Dim l_ret2 As Connect2SapEx.BAPIRET2
            Dim l_barem As Connect2SapEx.ZST_OIISLVCPOTable
            Dim l_evk As Connect2SapEx.DD07TTable
            Dim l_Tooil As Connect2SapEx.ZST_OIISOCISLTable


            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ztb = New Connect2SapEx.STR_TANKTable()
            l_ret2 = New Connect2SapEx.BAPIRET2()

            l_barem = New Connect2SapEx.ZST_OIISLVCPOTable
            l_evk = New Connect2SapEx.DD07TTable
            l_Tooil = New Connect2SapEx.ZST_OIISOCISLTable


            l_c2sap.Connection.Open()

            'l_Option: 1 Lay be va barem  2 lay EVK   3: Barem;
            Dim l_Option As String = "1"
            Dim l_Seqnr As String = ""   'Ma be

            ' If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
            l_c2sap.GetOiisocisl(i_date, l_Option, i_plant, l_Seqnr, l_Time, l_barem, l_evk, l_Tooil, l_ret2)
            'Else
            'l_async = l_c2sap.BeginGetTank(i_date, i_getall, i_plant, l_ztb, Nothing, l_c2sap)
            'l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

            'If l_isCompleted Then
            '    l_c2sap.EndGetTank(l_async, l_ztb, l_ret2)
            'End If
            'End If

            '----------------------------------------------------------------------------------------------
            '   Đưa dữ liệu vào hệ thống SQL
            '----------------------------------------------------------------------------------------------
            'l_dem = 0
            'If l_ztb.Count <= 0 Then
            '    Return False
            'End If
            ''----------------------------------------------------------------------------------------------
            ''   Đưa dữ liệu vào bảng Header
            ''----------------------------------------------------------------------------------------------
            'l_dem = l_ztb.Count
            For i As Integer = 0 To l_Tooil.Count - 1
                'l_bs_tank = New BSTank()

                '                CCX = Chiều cao an toàn
                'CCx_Min = Chiều cao xuất min
                'DTX = Thể tích an toàn
                'DTX_MIN = Thể tích xuất min
                'Giao_nhận = Đội giao nhận
                'Lgort = Mã bể
                'Loaibe = Loại bể
                'Matnr = Mặt hàng theo bể 
                'Motabe = Mô tả bể

                If Replace(l_Tooil.Item(i).Lgort.ToString(), "'", "", 1) = "D097" Then
                    '  MsgBox("sfghgfjhg")
                End If
                p_SQL = "MERGE ztblTankInfor AS target " & _
                                            " USING (SELECT '" & Replace(l_Tooil.Item(i).Ccx.ToString(), "'", "", 1) & "' as SafeHeight " & _
                                                    ",'" & Replace(l_Tooil.Item(i).Ccx_Min.ToString(), "'", "", 1) & "' as MinHeight " & _
                                                    ",'" & Replace(l_Tooil.Item(i).Dtx.ToString(), "'", "", 1) & "' as SafeVolume " & _
                                                    ",'" & Replace(l_Tooil.Item(i).Dtx_Min.ToString(), "'", "", 1) & "' as MinVolume " & _
                                                     ",'" & Replace(l_Tooil.Item(i).Giao_Nhan.ToString(), "'", "", 1) & "' as Client " & _
                                                     ",'" & Replace(l_Tooil.Item(i).Lgort.ToString(), "'", "", 1) & "' as TankCode " & _
                                                      ",'" & Replace(l_Tooil.Item(i).Loaibe.ToString(), "'", "", 1) & "' as sType " & _
                                                       ",'" & Replace(l_Tooil.Item(i).Matnr.ToString(), "'", "", 1) & "' as Matnr " & _
                                                        ",N'" & Replace(l_Tooil.Item(i).Motabe.ToString(), "'", "", 1) & "' as Description " & _
                                                     ") AS source (SafeHeight,MinHeight, SafeVolume, MinVolume, Client, TankCode, sType , Matnr , Description) " & _
                                                    " ON (target.TankCode = source.TankCode) " & _
                                                " WHEN MATCHED  THEN UPDATE SET " & _
                                                        "SafeHeight=source.SafeHeight " & _
                                                        ",MinHeight=source.MinHeight " & _
                                                        ",SafeVolume=source.SafeVolume " & _
                                                        ",MinVolume=source.MinVolume " & _
                                                        ",Client=source.Client " & _
                                                        ",sType=source.sType " & _
                                                        ",Description=source.Description,SynDate =getdate(), SynUser='" & g_userName & "' " & _
                                                        " " & _
                                             " WHEN NOT MATCHED THEN " & _
                                                "INSERT  (SafeHeight,MinHeight, SafeVolume, MinVolume, Client, TankCode, sType , Matnr , Description, SynDate, SynUser) " & _
                                                    "VALUES (source.SafeHeight,source.MinHeight, source.SafeVolume, source.MinVolume, " & _
                                                        "source.Client, source.TankCode, source.sType , source.Matnr , source.Description, getdate() , '" & g_userName & "'); "

                '  p_SQL = Replace(p_SQL, "''", "'", 1)
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)

            Next


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True
        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try

    End Function


    Public Function mdlSyncMaster_SyncTank_Barem(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                         ByVal i_date As String, _
                                         ByVal i_plant As String, ByRef p_desc As String, ByVal l_Time As String, ByVal p_TankName As String) As Boolean

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        ' Dim l_bs_tank As BSTank
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_SQL As String
        Dim p_Row As DataRow
        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy các loại phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            p_desc = ""


            Dim l_c2sap As Connect2SapEx.Connect2Sap
            Dim l_ztb As Connect2SapEx.STR_TANKTable
            Dim l_ret2 As Connect2SapEx.BAPIRET2
            Dim l_barem As Connect2SapEx.ZST_OIISLVCPOTable
            Dim l_evk As Connect2SapEx.DD07TTable
            Dim l_Tooil As Connect2SapEx.ZST_OIISOCISLTable


            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ztb = New Connect2SapEx.STR_TANKTable()
            l_ret2 = New Connect2SapEx.BAPIRET2()

            l_barem = New Connect2SapEx.ZST_OIISLVCPOTable
            l_evk = New Connect2SapEx.DD07TTable
            l_Tooil = New Connect2SapEx.ZST_OIISOCISLTable


            l_c2sap.Connection.Open()

            'l_Option: 1 Lay be va barem  2 lay EVK   3: Barem;
            Dim l_Option As String = "3"
            Dim l_Seqnr As String = ""   'Ma be


            l_Seqnr = p_TankName
            ' If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
            l_c2sap.GetOiisocisl(i_date, l_Option, i_plant, l_Seqnr, l_Time, l_barem, l_evk, l_Tooil, l_ret2)
            'Else
            'l_async = l_c2sap.GetOiisocisl(i_date, l_Option, i_plant, l_Seqnr, l_Time, l_barem, l_evk, l_Tooil, l_ret2)
            'l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

            'If l_isCompleted Then
            '    l_c2sap.endOiisocisl(l_async, l_ztb, l_ret2)
            'End If
            'End If

            '----------------------------------------------------------------------------------------------
            '   Đưa dữ liệu vào hệ thống SQL
            '----------------------------------------------------------------------------------------------
            'l_dem = 0
            'If l_ztb.Count <= 0 Then
            '    Return False
            'End If
            ''----------------------------------------------------------------------------------------------
            ''   Đưa dữ liệu vào bảng Header
            ''----------------------------------------------------------------------------------------------
            'l_dem = l_ztb.Count
            If l_barem.Count <= 0 Then
                p_desc = "Barem không xác định"
                Return False
            End If
            If p_TankName = "" Then
                p_SQL = "truncate table ztblTankBarem"
                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then
                    p_desc = p_SQL
                    Return False
                End If
            Else
                p_SQL = "delete ztblTankBarem where Seqnr='" & p_TankName & "'"
                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then
                    p_desc = p_SQL
                    Return False
                End If
            End If

            For i As Integer = 0 To l_barem.Count - 1
                'l_bs_tank = New BSTank()

                '                CCX = Chiều cao an toàn
                'CCx_Min = Chiều cao xuất min
                'DTX = Thể tích an toàn
                'DTX_MIN = Thể tích xuất min
                'Giao_nhận = Đội giao nhận
                'Lgort = Mã bể
                'Loaibe = Loại bể
                'Matnr = Mặt hàng theo bể 
                'Motabe = Mô tả bể
                p_SQL = "INSERT INTO [dbo].[ztblTankBarem] ([WERKS],[SEQNR],[LINCON],[VOLCON], SyncDate, SyncUser) " & _
                            " VALUES('" & Replace(l_barem.Item(i).Werks.ToString(), "'", "", 1) & "'" & _
                                    ",'" & Replace(l_barem.Item(i).Seqnr.ToString(), "'", "", 1) & "'" & _
                                    "," & Replace(l_barem.Item(i).Lincon.ToString(), "'", "", 1) & "" & _
                                    "," & Replace(l_barem.Item(i).Volcon.ToString(), "'", "", 1) & "" & _
                                            ", getdate(),'" & g_userName & "')"
                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then
                    p_desc = p_SQL
                    Return False
                End If


            Next


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True
        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try

    End Function


    Public Function mdlSyncMaster_SyncTank_New(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                         ByVal i_date As String, _
                                         ByVal i_plant As String, ByRef p_desc As String, ByVal l_Time As String) As Boolean

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        Dim p_SQL2 As String
        ' Dim l_bs_tank As BSTank
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_SQL As String
        Dim p_Row As DataRow
        Dim p_MaHH As String = ""
        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy các loại phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            p_desc = ""


            Dim l_c2sap As Connect2SapEx.Connect2Sap
            Dim l_ztb As Connect2SapEx.STR_TANKTable
            Dim l_ret2 As Connect2SapEx.BAPIRET2
            Dim l_barem As Connect2SapEx.ZST_OIISLVCPOTable
            Dim l_evk As Connect2SapEx.DD07TTable
            Dim l_Tooil As Connect2SapEx.ZST_OIISOCISLTable


            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ztb = New Connect2SapEx.STR_TANKTable()
            l_ret2 = New Connect2SapEx.BAPIRET2()

            l_barem = New Connect2SapEx.ZST_OIISLVCPOTable
            l_evk = New Connect2SapEx.DD07TTable
            l_Tooil = New Connect2SapEx.ZST_OIISOCISLTable


            l_c2sap.Connection.Open()

            'l_Option: 1 Lay be va barem  2 lay EVK   3: Barem;
            Dim l_Option As String = "1"
            Dim l_Seqnr As String = ""   'Ma be

            ' If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
            l_c2sap.GetOiisocisl("", l_Option, i_plant, l_Seqnr, l_Time, l_barem, l_evk, l_Tooil, l_ret2)


            '----------------------------------------------------------------------------------------------
            '   Đưa dữ liệu vào hệ thống SQL
            '----------------------------------------------------------------------------------------------
            'l_dem = 0
            'If l_ztb.Count <= 0 Then
            '    Return False
            'End If
            ''----------------------------------------------------------------------------------------------
            ''   Đưa dữ liệu vào bảng Header
            ''----------------------------------------------------------------------------------------------
            'l_dem = l_ztb.Count
            If l_Tooil.Count <= 0 Then
                p_desc = "Bể không xác định"
                Return False
            End If
            'p_SQL = "truncate table ztblTankBarem"
            'If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then
            '    p_desc = p_SQL
            '    Return False
            'End If
            For i As Integer = 0 To l_Tooil.Count - 1
                'l_bs_tank = New BSTank()

                If Replace(l_Tooil.Item(i).Lgort.ToString(), "'", "", 1) = "D097" Then
                    p_SQL = p_SQL
                End If
                p_MaHH = Replace(l_Tooil.Item(i).Matnr.ToString(), "'", "", 1)
                p_MaHH = Right(p_MaHH, 7)

                p_SQL2 = "  case  when  isnull( (select top 1 TankHTTG from [tblTankMapSAP] h1 " & _
                            "where h1.TankSAP = '" & Replace(l_Tooil.Item(i).Lgort.ToString(), "'", "", 1) & "'),'') ='' " & _
                                    "then '" & Replace(l_Tooil.Item(i).Lgort.ToString(), "'", "", 1) & "'  else  (select top 1 TankHTTG from [tblTankMapSAP] h1 " & _
                                        "where h1.TankSAP = '" & Replace(l_Tooil.Item(i).Lgort.ToString(), "'", "", 1) & "')  end  as Name_nd "
                p_SQL = "MERGE tblTank AS target " & _
                                            " USING (SELECT " & p_SQL2 & " " & _
                                                    ",'" & p_MaHH & "' as Product_nd " & _
                                                     ") AS source (Name_nd, Product_nd) " & _
                                                    " ON (target.Name_nd = source.Name_nd) " & _
                                                " WHEN MATCHED  THEN UPDATE SET " & _
                                                        "Name_nd=source.Name_nd,  Product_nd=source.Product_nd,Map_Sap1 = source.Name_nd " & _
                                                        " " & _
                                             " WHEN NOT MATCHED THEN " & _
                                                "INSERT  (Name_nd, Product_nd, Map_Sap1) " & _
                                                    "VALUES (source.Name_nd, Product_nd, source.Name_nd); "
                'p_SQL = "MERGE tblTank AS target " & _
                '                            " USING (SELECT '" & Replace(l_Tooil.Item(i).Lgort.ToString(), "'", "", 1) & "' as Name_nd " & _
                '                                    ",'" & p_MaHH & "' as Product_nd " & _
                '                                     ") AS source (Name_nd, Product_nd) " & _
                '                                    " ON (target.Name_nd = source.Name_nd) " & _
                '                                " WHEN MATCHED  THEN UPDATE SET " & _
                '                                        "Name_nd=source.Name_nd,  Product_nd=source.Product_nd,Map_Sap1 = source.Name_nd " & _
                '                                        " " & _
                '                             " WHEN NOT MATCHED THEN " & _
                '                                "INSERT  (Name_nd, Product_nd, Map_Sap1) " & _
                '                                    "VALUES (source.Name_nd, Product_nd, source.Name_nd); "

                '  p_SQL = Replace(p_SQL, "''", "'", 1)
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)

            Next
        
            If Not p_DataTablExe Is Nothing Then
                If p_DataTablExe.Rows.Count > 0 Then
                    p_SQL = "update [dbo].[tblTank]  set Map_Sap1 =(select top 1  TankSap from [tblTankMapSAP] h1 " & _
                           " where h1.TankHTTG =  [tblTank].Name_ND)   where  " & _
                           "   exists (select 1  from [tblTankMapSAP] h2 where h2.TankHTTG = [tblTank].Name_ND) "
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)
                End If

            End If
           


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True
        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try

    End Function


    Public Function mdlSyncMaster_SyncPurpose_ATG(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                         ByVal i_date As String, _
                                         ByVal i_plant As String, ByRef p_desc As String, ByVal l_Time As String) As Boolean

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        ' Dim l_bs_tank As BSTank
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_SQL As String
        Dim p_Row As DataRow
        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy các loại phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            p_desc = ""


            Dim l_c2sap As Connect2SapEx.Connect2Sap
            Dim l_ztb As Connect2SapEx.STR_TANKTable
            Dim l_ret2 As Connect2SapEx.BAPIRET2
            Dim l_barem As Connect2SapEx.ZST_OIISLVCPOTable
            Dim l_evk As Connect2SapEx.DD07TTable
            Dim l_Tooil As Connect2SapEx.ZST_OIISOCISLTable


            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ztb = New Connect2SapEx.STR_TANKTable()
            l_ret2 = New Connect2SapEx.BAPIRET2()

            l_barem = New Connect2SapEx.ZST_OIISLVCPOTable
            l_evk = New Connect2SapEx.DD07TTable
            l_Tooil = New Connect2SapEx.ZST_OIISOCISLTable


            l_c2sap.Connection.Open()

            'l_Option: 1 Lay be va barem  2 lay EVK   3: Barem;
            Dim l_Option As String = "2"
            Dim l_Seqnr As String = ""   'Ma be

            ' If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
            l_c2sap.GetOiisocisl(i_date, l_Option, i_plant, l_Seqnr, l_Time, l_barem, l_evk, l_Tooil, l_ret2)

            For i As Integer = 0 To l_evk.Count - 1
                'l_bs_tank = New BSTank()
                If Replace(l_evk.Item(i).Domvalue_L.ToString(), "'", "", 1) = "" Then
                    Continue For
                End If
                '                CCX = Chiều cao an toàn
                'CCx_Min = Chiều cao xuất min
                'DTX = Thể tích an toàn
                'DTX_MIN = Thể tích xuất min
                'Giao_nhận = Đội giao nhận
                'Lgort = Mã bể
                'Loaibe = Loại bể
                'Matnr = Mặt hàng theo bể 
                'Motabe = Mô tả bể

                p_SQL = "MERGE zPurpose AS target " & _
                                            " USING (SELECT '" & Replace(l_evk.Item(i).Domvalue_L.ToString(), "'", "", 1) & "' as Code " & _
                                                    ",N'" & Replace(l_evk.Item(i).Ddtext.ToString(), "'", "", 1) & "' as Name " & _
                                                    ") AS source (Code, Name) " & _
                                                    " ON (target.Code = source.Code) " & _
                                                " WHEN MATCHED  THEN UPDATE SET " & _
                                                        "Name=source.Name " & _
                                                        ",SynDate =getdate(), SynUser='" & g_userName & "' " & _
                                                        " " & _
                                             " WHEN NOT MATCHED THEN " & _
                                                "INSERT  (Code, Name, SynDate, SynUser) " & _
                                                    "VALUES (source.Code,source.Name, getdate() , '" & g_userName & "'); "


                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)

            Next


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True
        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try

    End Function

    Public Function SynDonViTinh(ByRef p_DataTablExe As DataTable, ByVal i_getall As String,
                                 ByRef p_Desc As String) As Boolean

        Dim ztb As Connect2SAP.Str_DonViTinhTable = New Connect2SAP.Str_DonViTinhTable()
        Dim c2sap As Connect2SAP.Connect2SAP
        'Try connect and get Data from SAP
        Dim l_ztb As Connect2SAP.Str_TankTable
        Dim ret2 As Connect2SAP.BAPIRET2
        Dim async As IAsyncResult
        Dim isCompleted As Boolean
        Dim p_SQL As String
        Dim p_Row As DataRow


        p_Desc = ""
        If g_WcfE5 = True Then

            SynDonViTinh = g_Services.SynDonViTinh(_SapConnectionString, _
                                             _dtVariable, _
                                             _ShPoint, _
                                                 _WareHouse, _
                                                 _TimeOut, _
                                             p_DataTablExe, i_getall, p_Desc)

            Return SynDonViTinh
        End If

        c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
        Try
            ret2 = New Connect2SAP.BAPIRET2()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                c2sap.GetDonViTinh(i_getall, ztb, ret2)
            Else
                async = c2sap.BeginGetDonViTinh(i_getall, ztb, Nothing, c2sap)
                isCompleted = async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If isCompleted Then
                    c2sap.EndGetDonViTinh(async, ztb, ret2)
                End If
            End If

            ' dem = 0
            If ztb.Count > 0 Then
                For i As Integer = 0 To ztb.Count - 1
                    'Cho dữ liệu vào CSDL SQL
                    p_SQL = "MERGE tblDonViTinh AS target " & _
                        " USING (SELECT '" & Replace(ztb.Item(i).Madvt.ToString(), "'", "", 1) & "' as DonViTinh " & _
                                ") AS source (DonViTinh) " & _
                                " ON (target.DonViTinh = source.DonViTinh) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "DonViTinh=source.DonViTinh " & _
                                    " " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (DonViTinh) " & _
                                "VALUES (source.DonViTinh); "

                    '  p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                Next
            End If

            SynDonViTinh = True

        Catch ex As Exception
            p_Desc = ex.Message
            SynDonViTinh = False
        Finally
            c2sap.Connection.Close()
            c2sap.Dispose()
        End Try
    End Function

    Public Function SynPhuongThuc(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByRef p_desc As String) As Boolean

        Dim ztbdc As Connect2SAP.Str_PhuongThucDCTable = New Connect2SAP.Str_PhuongThucDCTable()
        Dim ztbmt As Connect2SAP.Str_PhuongThucMTTable = New Connect2SAP.Str_PhuongThucMTTable()
        Dim p_SQL As String
        Dim p_Row As DataRow
        Dim c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_TankTable
        Dim ret2 As Connect2SAP.BAPIRET2
        Dim async As IAsyncResult
        Dim isCompleted As Boolean

        Dim p_STT As Integer = 0
        Dim p_MaPTX As String = ""
        p_desc = ""

        If g_WcfE5 = True Then

            SynPhuongThuc = g_Services.SynPhuongThuc(_SapConnectionString, _
                                             _dtVariable, _
                                             _ShPoint, _
                                                 _WareHouse, _
                                                 _TimeOut, _
                                             p_DataTablExe, i_getall, p_desc)

            Return SynPhuongThuc
        End If
        'Try connect and get data from SAP
        c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
        Try
            ret2 = New Connect2SAP.BAPIRET2()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                c2sap.GetPhuongThuc(i_getall, ztbdc, ztbmt, ret2)
            Else
                async = c2sap.BeginGetPhuongThuc(i_getall, ztbdc, ztbmt, Nothing, c2sap)
                isCompleted = async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If isCompleted Then
                    c2sap.EndGetPhuongThuc(async, ztbdc, ztbmt, ret2)
                End If
            End If

            'anhqh
            '20170815
            'Bo di vi chi import thôi

            'If ztbmt.Count > 0 Then
            '    'anhqh
            '    '20170815
            '    'Xoa het noi dung cua PT Xuat di dong bo lai tat ca
            '    'Do PT xuat co nhieu MaPT xuat trung nhau la 601 nhung ten PTX lai khac nhau
            '    p_SQL = "DELETE FROM tblPhuongThucXuat "

            '    If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then
            '        p_SQL = ""
            '    End If

            '    For i As Integer = 0 To ztbmt.Count - 1

            '        p_SQL = "MERGE tblPhuongThucXuat AS target " & _
            '            " USING (SELECT '" & Replace(ztbmt.Item(i).Maptxn.ToString(), "'", "", 1) & "' as MaPhuongThucXuat ," & _
            '                     "N'" & Replace(ztbmt.Item(i).Tenptxn.ToString(), "'", "", 1) & "'  as TenPhuongThucXuat," & _
            '                     "'" & Replace(ztbmt.Item(i).Status.ToString().Trim(), "'", "", 1) & "'  as Status ) AS source (MaPhuongThucXuat, TenPhuongThucXuat,  Status) " & _
            '                    " ON (target.MaPhuongThucXuat = source.MaPhuongThucXuat) " & _
            '                " WHEN MATCHED  THEN UPDATE SET " & _
            '                        "TenPhuongThucXuat=source.TenPhuongThucXuat " & _
            '                        ",Status=source.Status " & _
            '             " WHEN NOT MATCHED THEN " & _
            '                "INSERT  (MaPhuongThucXuat, TenPhuongThucXuat,  Status) " & _
            '                    "VALUES (source.MaPhuongThucXuat,source.TenPhuongThucXuat,source.Status ); "

            '        '  p_SQL = Replace(p_SQL, "''", "'", 1)
            '        p_Row = p_DataTablExe.NewRow
            '        p_Row.Item(0) = p_SQL
            '        p_DataTablExe.Rows.Add(p_Row)

            '    Next
            'End If

            If ztbdc.Count > 0 Then
                For i As Integer = 0 To ztbdc.Count - 1
                    'Cho dữ liệu vào CSDL SQL
                    p_SQL = "MERGE tblPhuongThucBan AS target " & _
                        " USING (SELECT '" & Replace(ztbdc.Item(i).Maptb.ToString(), "'", "", 1) & "' as MaPhuongThucBan ," & _
                                 "N'" & Replace(ztbdc.Item(i).Tenptb.ToString(), "'", "", 1) & "'  as TenPhuongThucBan," & _
                                 "'" & Replace(ztbdc.Item(i).Status.ToString().Trim(), "'", "", 1) & "'  as Status ) AS source (MaPhuongThucBan, TenPhuongThucBan,  Status) " & _
                                " ON (target.MaPhuongThucBan = source.MaPhuongThucBan) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "TenPhuongThucBan=source.TenPhuongThucBan " & _
                                    ",Status=source.Status " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (MaPhuongThucBan, TenPhuongThucBan,  Status) " & _
                                "VALUES (source.MaPhuongThucBan,source.TenPhuongThucBan,source.Status ); "

                    'p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    'Err = ""
                    'bsdc.InsertSaleMethod(Err, ztbdc.Item(i).Maptb.ToString(), ztbdc.Item(i).Tenptb.ToString(), ztbdc.Item(i).Status.ToString().Trim())
                    'If Err() <> "" Then
                    '    Err = ""
                    '    bsdc.UpdateSaleMethod(Err, ztbdc.Item(i).Maptb.ToString(), ztbdc.Item(i).Tenptb.ToString(), ztbdc.Item(i).Status.ToString().Trim())
                    'End If
                    'dem = dem + 1
                Next
            End If

            SynPhuongThuc = True

        Catch ex As Exception
            p_desc = ex.Message
            SynPhuongThuc = False
        Finally
            c2sap.Connection.Close()
            c2sap.Dispose()
        End Try

    End Function


    'anhqh
    '20170725
    'Dong bo rieng phuong tien
    Public Function mdlSyncMaster_SyncVehicleDown1(ByVal i_vehicle As String, ByRef p_Count As Integer, _
                                                    ByRef p_Desc As String,
                                                    ByVal g_User As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_ChiTietPhuongTienTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String

        Dim p_Row As DataRow
        Dim p_DataTablExe As New System.Data.DataTable("Table0")

        Dim l_err As String = String.Empty
        Dim l_dem As Integer

        Try

            Dim p_PTienAo_SMO As String = ""
            Dim p_Table As DataTable


            p_PTienAo = ""
            p_SQL = "select KeyValue from sys_config where keycode ='PTIEN_AO'"
            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    p_PTienAo = p_Table.Rows(0).Item("KeyValue").ToString.Trim
                End If
            End If

            p_PTienAo_SMO = ""
            p_SQL = "select KeyValue from sys_config where keycode ='PTIEN_AO_SMO'"
            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    p_PTienAo_SMO = p_Table.Rows(0).Item("KeyValue").ToString.Trim
                End If
            End If

            If InStr(p_PTienAo & "," & p_PTienAo_SMO, i_vehicle, CompareMethod.Text) > 0 Then
                p_Desc = "Phương tiện không hợp lệ"
                Return False
            End If


            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            If g_WcfE5 = True Then

                mdlSyncMaster_SyncVehicleDown1 = g_Services.ClsSyncMaster_SyncVehicleDownNew(_SapConnectionString, _
                                                 _dtVariable, _
                                                 _ShPoint, _
                                                     _WareHouse, _
                                                     _TimeOut, _
                                                     i_vehicle, p_Count, p_Desc)

                Exit Function
            End If





            p_DataTablExe.Columns.Add("STR_SQL")
            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ztb = New Connect2SAP.Str_ChiTietPhuongTienTable()
            l_ret2 = New Connect2SAP.BAPIRET2()

            l_c2sap.Connection.Open()





            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetChiTietPhuongTien(String.Empty, String.Empty, i_vehicle.ToUpper(), l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetChiTietPhuongTien(i_vehicle.ToUpper(), String.Empty, String.Empty, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetChiTietPhuongTien(l_async, l_ztb, l_ret2)
                End If
            End If

            p_Count = 0
            '----------------------------------------------------------------------------------------------
            '   Đưa dữ liệu vào hệ thống SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            l_dem = l_ztb.Count
            p_Count = l_ztb.Count
            If l_ztb.Count > 0 Then
                'l_bs_details = New BSVehicleDetail()

                ' For i As Integer = 0 To l_ztb.Count - 1
                p_SQL = "MERGE tblPhuongtien AS target " & _
                    " USING (SELECT N'" & Replace(l_ztb.Item(0).Mapt.ToString(), "'", "", 1) & "' as MaPhuongTien ," & _
                             "N'" & Replace(l_ztb.Item(0).Loaipt.ToString(), "'", "", 1) & "'  as LaiXe," & _
                             "" & Convert.ToInt32(l_dem) & "  as SoNgan ," & _
                             "'" & Replace(l_ztb.Item(0).Ngaybatdau.ToString(), "'", "", 1) & "'  as Ngaybatdau, " & _
                             "'" & Replace(l_ztb.Item(0).Ngayketthuc.ToString(), "'", "", 1) & "'  as NgayHieuLuc, " & _
                            "'S' as Status) AS source (MaPhuongTien, LaiXe, SoNgan, Ngaybatdau, NgayHieuLuc, Status) " & _
                            " ON (target.MaPhuongTien = source.MaPhuongTien) " & _
                        " WHEN MATCHED  THEN UPDATE SET " & _
                                "LaiXe=source.LaiXe " & _
                                ",SoNgan=source.SoNgan " & _
                                ",Ngaybatdau=source.Ngaybatdau " & _
                                ",NgayHieuLuc=source.NgayHieuLuc " & _
                                ",Status=source.Status " & _
                     " WHEN NOT MATCHED THEN " & _
                        "INSERT  (MaPhuongTien, LaiXe, SoNgan, Ngaybatdau, NgayHieuLuc, Status) " & _
                            "VALUES (source.MaPhuongTien,source.LaiXe,source.SoNgan,source.NgayHieuLuc,source.NgayHieuLuc,source.Status ) ;"
                'p_SQL = Replace(p_SQL, "''", "'", 1)
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)




                p_SQL = "INSERT INTO [tblPhuongTien_Hist] ([MaPhuongTien],[LaiXe]" & _
                            " ,[SoNgan],[NgayBatDau],[NgayHieuLuc] ,[Status],[SyncDate] " & _
                            " ,[Createby] ,[UpdatedBy] ,[CreateDate],[UpdateDate],[UpdStatus])"

                p_SQL = p_SQL & " VALUES (N'" & Replace(l_ztb.Item(0).Mapt.ToString(), "'", "", 1) & "'," & _
                                        "N'" & Replace(l_ztb.Item(0).Loaipt.ToString(), "'", "", 1) & "', " & _
                                        "" & Convert.ToInt32(l_dem) & " ," & _
                                         "'" & Replace(l_ztb.Item(0).Ngaybatdau.ToString(), "'", "", 1) & "'  , " & _
                                         "'" & Replace(l_ztb.Item(0).Ngayketthuc.ToString(), "'", "", 1) & "' , " & _
                                         "'S', getdate()," & _
                                           "'" & g_User & "', '" & g_User & "',getdate(), getdate(),'I'" & _
                                            ")"
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)




                p_SQL = "DELETE FROM tblChiTietPhuongtien where MaPhuongTien='" & Replace(l_ztb.Item(0).Mapt.ToString(), "'", "", 1) & "'"
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)
                'l_dem = l_dem + 1

                For i As Integer = 0 To l_ztb.Count - 1
                    ' l_bs = New BSVehicleDetail()
                    l_err = String.Empty
                    ' l_mahh = String.Empty
                    p_SQL = "MERGE tblChiTietPhuongtien AS target " & _
                                           " USING (SELECT '" & Replace(l_ztb.Item(i).Mangan.ToString(), "'", "", 1) & "' as MaNgan," & _
                                                    "'" & Replace(l_ztb.Item(i).Mapt.ToString(), "'", "", 1) & "' as MaPhuongTien," & _
                                                    "" & Convert.ToDecimal(l_ztb.Item(i).Max_Nd.ToString()) & " as SoLuongMax," & _
                                                   "'S' as Status) AS source (MaNgan, MaPhuongTien, SoLuongMax, Status) " & _
                                                   " ON (target.MaPhuongTien = source.MaPhuongTien and target.MaNgan = source.MaNgan) " & _
                                               " WHEN MATCHED  THEN UPDATE SET " & _
                                                       "SoLuongMax=source.SoLuongMax " & _
                                                       ",Status=source.Status " & _
                                            " WHEN NOT MATCHED THEN " & _
                                               "INSERT  (MaNgan, MaPhuongTien, SoLuongMax, Status) " & _
                                                   "VALUES (source.MaNgan,source.MaPhuongTien,source.SoLuongMax,source.Status );"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)



                    p_SQL = "INSERT INTO [tblChiTietPhuongTien_Hist]([MaNgan],[MaPhuongTien],[SoLuongMax] " & _
                            " ,[Createby],[UpdatedBy],[CreateDate],[UpdateDate],[Status],[SyncDate],[UpdStatus])"
                    p_SQL = p_SQL & " VALUES ( '" & Replace(l_ztb.Item(i).Mangan.ToString(), "'", "", 1) & "' ," & _
                                                    "'" & Replace(l_ztb.Item(i).Mapt.ToString(), "'", "", 1) & "' ," & _
                                                    "" & Convert.ToDecimal(l_ztb.Item(i).Max_Nd.ToString()) & " ," & _
                                                    "'" & g_User & "', '" & g_User & "',getdate(), getdate(),'S', getdate(), 'I'" & _
                                                    ")"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)


                    l_dem = l_dem + 1
                Next

                ' Next

                If p_DataTablExe.Rows.Count > 0 Then
                    If g_Services.Sys_Execute_DataTableNew(p_DataTablExe, _
                                          p_SQL) = False Then
                        p_Desc = p_SQL
                        Return False
                    End If
                End If
            End If

            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True
        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try
    End Function


#Region "Dong bo phuong tien len SAP"
    Public Function mdlSyncMaster_SyncVehicleUp(ByVal i_number As String, ByVal i_tutype As String, ByVal i_dt_compartment As DataTable) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_ChiTietPhuongTienTable
        Dim l_str As Connect2SAP.Str_ChiTietPhuongTien
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_SQL As String

        Try
            '----------------------------------------------------------------------------------------------
            '   Chuyển dữ liệu từ Datatable -> Str_ChiTietPhuongTienTable
            '----------------------------------------------------------------------------------------------
            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_ChiTietPhuongTienTable()

            l_c2sap.Connection.Open()

            For i As Integer = 0 To i_dt_compartment.Rows.Count - 1
                l_str = New Connect2SAP.Str_ChiTietPhuongTien()
                l_str.Mapt = i_number
                l_str.Mangan = mdlFunction_Convert2StringKey(i_dt_compartment.Rows(i).Item("MaNgan").ToString(), 3)
                l_str.Max_Nd = i_dt_compartment.Rows(i).Item("SoluongMax")

                l_ztb.Add(l_str)
            Next

            'Dim l_frm As frmTest = New frmTest(l_ztb)
            'l_frm.ShowDialog()
            'Exit Function
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện đưa lên SAP
            '----------------------------------------------------------------------------------------------

            '  If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
            l_c2sap.CreateVehicle(i_number.ToUpper(), i_tutype, l_ztb, l_ret2)
            'Else
            '    l_async = l_c2sap.BeginCreateVehicle(i_number.ToUpper(), i_tutype, l_ztb, Nothing, l_c2sap)
            '    l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

            '    If l_isCompleted Then
            '        l_c2sap.EndCreateVehicle(l_async, l_ztb, l_ret2)
            '    End If
            ' End If

            If l_ret2.Type = "E" Then
                Return False
            End If
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            p_SQL = "Update tblphuongtien set Status='S' where Maphuongtien='" & i_number & "'"
            If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function mdlFunction_Convert2StringKey(ByVal i_string As String, ByVal i_length As Integer) As String
        Dim l_string As String

        l_string = i_string

        If l_string.Length < i_length Then
            For i As Integer = 1 To i_length - l_string.Length
                l_string = "0" & l_string
            Next
        End If

        Return l_string

    End Function

#End Region
    Public Sub CapNhatLog(ByVal p_Para As String, ByVal p_Count As Integer)
        Dim p_SQL As String
        Dim p_Date As Date
        Dim p_Time As Integer
        Dim p_DateStr As String

        p_GetDateTime(p_Date, p_Time)
        p_DateStr = p_Date.ToString("yyyy.MM.dd")
        p_SQL = "update tblLogSyn set  SynDate= '" & p_DateStr & "'  where upper(Para)='" & UCase(p_Para) & "'"


        If g_Services.Sys_Execute(p_SQL, p_SQL) Then

        End If
    End Sub



    Public Function GetDateLog(ByVal p_Para As String) As String
        Dim p_DataTable As DataTable
        Dim p_SQL As String
        Dim p_Date As Date
        Dim p_Time As Integer


        GetDateLog = ""
        p_SQL = "select * from tblLogSyn where upper(Para)='" & UCase(p_Para) & "'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                GetDateLog = p_DataTable.Rows(0).Item("SynDate").ToString.Trim
            End If
        End If
        If GetDateLog = "" Then
            p_GetDateTime(p_Date, p_Time)
            p_Date = DateAdd(DateInterval.Year, -5, p_Date)
            GetDateLog = p_Date.ToString("yyyy.MM.dd")
        End If

    End Function


    Private Sub p_GetDateTime(ByRef p_Date As Date, ByRef p_Time As Integer)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        p_SQL = "select  convert(date, getdate()) as SysDate, replace(CONVERT(VARCHAR(5),DATEADD(MINUTE,0 ,GETDATE()),108),':','') as SysTime"
        p_Datatable = g_Services.mod_SYS_GET_DATATABLE(p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SysDate")
                p_Time = p_Datatable.Rows(0).Item("SysTime")
            End If
        End If
        p_Datatable = Nothing
    End Sub

    Private Function GetDataTable(ByVal p_SQL As String, ByVal p_Error As String) As DataTable
        Dim p_Datatable As DataTable
        Try
            p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message
            Return Nothing
        End Try
        Return p_Datatable

    End Function

    Private Sub abc()
        Dim l_ret2 As Connect2SapEx.Str_PhieuXuat
        Dim l_Addqty As Connect2SapEx.T_QCITable
        Dim l_VcfTable As Connect2SapEx.T_VCFTable
        Dim l_ReTable As Connect2SapEx.BAPIRET2Table
        Dim i_connectionstring As String
        Dim p_TableConfig1 As DataTable
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim p_SQL As String

        p_SQL = "select * from tblConfig;"
        p_TableConfig1 = GetDataTable(p_SQL, p_SQL)



        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                i_connectionstring = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                ' p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                'p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If

        l_c2sap = New Connect2SapEx.Connect2Sap(i_connectionstring)

        l_ret2 = New Connect2SapEx.Str_PhieuXuat

        l_c2sap.CalculateQCI(l_ret2, l_Addqty, l_VcfTable, l_ReTable)

        '  l_ztb_addqty = New Connect2SAP.Str_AddqtyTable()

        ' l_c2sap.


        'l_c2sap.Fm_Qci(l_str, l_ztb_addqty, l_ret2)

    End Sub


    'anhqh
    '20191015
    'Ham thuc hien lay thong tin Hoa don VAT tren SAP ve HTTG
    Public Function mdlSyncHoaDonVAT(ByVal p_SoLenhIn As String, ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.STR_HDDTCODETable
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        Dim p_Int As Integer
        Dim p_SQL As String

        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_Row As DataRow
        Dim p_SoLenh As String = ""
        Dim p_Count As Integer

        ' Dim p_SQL As String = ""
        Dim p_Datatable As DataTable

        p_SQL = "select Distinct SoLenh from tblTichke a where  exists " & _
                  " (select 1   from tblTichKe  b where SoLenh ='" & p_SoLenhIn & "' and a.SoTichKe =b.SoTichKe and  a.NgayTichKe =b.NgayTichKe ) " & _
                  " and exists (select 1 from tbllenhxuate5  h1  with (nolock) where h1.SoLenh =a.SoLenh  and isnull(MaTraCuu,'') ='' )"
        p_Datatable = GetDataTable(p_SQL, p_SQL)

        If p_Datatable Is Nothing Then
            p_desc = "Số lệnh không có trong bảng tích kê"
            Return False
        End If
        'If p_Datatable.Rows.Count <= 0 Then
        '    p_desc = "Số lệnh không có trong bảng tích kê"
        '    Return False
        'End If

        If p_DataTablExe Is Nothing Then
            p_DataTablExe = New DataTable("Table001")
            p_DataTablExe.Columns.Add("STR_SQL")

        End If
        Try
            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            For p_Count = 0 To p_Datatable.Rows.Count - 1
                p_desc = ""
                p_SoLenh = p_Datatable.Rows(p_Count).Item("SoLenh").ToString.Trim
                '----------------------------------------------------------------------------------------------
                '   Lấy các dữ liệu phương tiện từ SAP
                '----------------------------------------------------------------------------------------------



                l_ret2 = New Connect2SapEx.BAPIRET2()
                l_ztb = New Connect2SapEx.STR_HDDTCODETable

                If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then

                    l_c2sap.GET_Hddtcode(g_Company_Code, p_SoLenh, l_ret2, l_ztb)

                    'l_c2sap.GetVendor(g_Company_Code, i_date, i_getall, l_ztb, l_ret2)
                    ' l_c2sap.GetVk13(i_date, "", "", g_Company_Code, l_ret2, l_ztb)
                Else
                    l_async = l_c2sap.BeginGET_Hddtcode(g_Company_Code, p_SoLenh, l_ztb, Nothing, l_c2sap)

                    'l_async = l_c2sap.BeginGetVk13(i_date, "", "", g_Company_Code, l_ztb, Nothing, l_c2sap)


                    l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                    If l_isCompleted Then
                        l_c2sap.EndGET_Hddtcode(l_async, l_ret2, l_ztb)
                        ' l_c2sap.EndGetVk13(l_async, l_ret2, l_ztb)
                    End If
                End If

                '----------------------------------------------------------------------------------------------
                '   Đưa thông tin vào csdl SQL
                '----------------------------------------------------------------------------------------------
                l_dem = 0
                If l_ztb.Count > 0 Then
                    For i As Integer = 0 To l_ztb.Count - 1

                        Integer.TryParse(Replace(l_ztb.Item(i).Posnr.ToString(), "'", "", 1), p_Int)
                        p_SQL = "MERGE tblHoaDonDienTu AS target " & _
                            " USING (SELECT '" & Replace(l_ztb.Item(i).Vbeln.ToString(), "'", "", 1) & "' as Vbeln " & _
                                     "," & p_Int & "  as POSNR" & _
                                     ",N'" & Replace(l_ztb.Item(i).Seq_Nmbr.ToString(), "'", "", 1) & "'  as SEQ_NMBR " & _
                                     ",N'" & Replace(l_ztb.Item(i).Cusname.ToString(), "'", "", 1) & "'  as CUSNAME" & _
                                     ",N'" & Replace(l_ztb.Item(i).Diachi.ToString(), "'", "", 1) & "'  as DIACHI " & _
                                     ",N'" & Replace(l_ztb.Item(i).Mst.ToString(), "'", "", 1) & "'  as MST " & _
                                     ",N'" & Replace(l_ztb.Item(i).Matnr.ToString(), "'", "", 1) & "'  as Matnr" & _
                                     ",N'" & Replace(l_ztb.Item(i).Ltt_Des.ToString(), "'", "", 1) & "'  as LTT_DES " & _
                                     ",N'" & Replace(l_ztb.Item(i).Matracuu.ToString(), "'", "", 1) & "'  as MATRACUU " & _
                                      ",N'" & Replace(l_ztb.Item(i).Sohoadon.ToString(), "'", "", 1) & "'  as SOHOADON " & _
                                     ",'" & g_userName & "'  as sUser " & _
                                     ",getdate()  as dDate " & _
                                       "," & Replace(l_ztb.Item(i).Ltt.ToString(), "'", "", 1) & "  as LTT" & _
                                    " ) AS source (Vbeln, POSNR, SEQ_NMBR, CUSNAME,DIACHI,MST,Matnr, LTT_DES,MATRACUU, SOHOADON, sUser, dDate, Ltt ) " & _
                                    " ON (target.Vbeln = source.Vbeln  and target.Matnr = source.Matnr ) " & _
                        " WHEN NOT MATCHED THEN " & _
                                "INSERT  (Vbeln, POSNR, SEQ_NMBR, CUSNAME,DIACHI,MST,Matnr, LTT_DES,MATRACUU, SOHOADON, sUser, dDate, Ltt  ) " & _
                                    " VALUES (source.Vbeln, source.POSNR, source.SEQ_NMBR, source.CUSNAME" & _
                                 " ,source.DIACHI,source.MST,Matnr, source.LTT_DES,source.MATRACUU, source.SOHOADON, source.sUser, source.dDate, source.Ltt) ;"


                        'p_SQL = "MERGE tblLenhXuatE5 AS target " & _
                        '    " USING (SELECT '" & Replace(l_ztb.Item(i)..ToString(), "'", "", 1) & "' as MaNhaCungCap ," & _
                        '             "N'" & Replace(l_ztb.Item(i).Vendorname.ToString(), "'", "", 1) & "'  as TenNhaCungCap," & _
                        '             "N'" & Replace(l_ztb.Item(i).Vendorvat.ToString(), "'", "", 1) & "'  as MaSoThue " & _
                        '            " ) AS source (MaNhaCungCap, TenNhaCungCap, MaSoThue) " & _
                        '            " ON (target.MaNhaCungCap = source.MaNhaCungCap) " & _
                        '        " WHEN MATCHED  THEN UPDATE SET " & _
                        '                "TenNhaCungCap=source.TenNhaCungCap " & _
                        '                ",MaSoThue=source.MaSoThue " & _
                        '     " WHEN NOT MATCHED THEN " & _
                        '        "INSERT  (MaNhaCungCap,TenNhaCungCap,MaSoThue ) " & _
                        '            "VALUES (source.MaNhaCungCap,source.TenNhaCungCap,source.MaSoThue ) ;"
                        ' p_SQL = Replace(p_SQL, "''", "'", 1)
                        p_Row = p_DataTablExe.NewRow
                        p_Row.Item(0) = p_SQL
                        p_DataTablExe.Rows.Add(p_Row)

                        l_dem = l_dem + 1
                    Next
                End If

            Next
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()
            Return True

        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try
    End Function



    Public Sub HistStringSyn(ByVal p_Para As String, ByVal p_From As Boolean)
        Dim p_SQL As String = ""
        Try
            If p_From = True Then
                p_SQL = "INSERT INTO [dbo].[tblLogSyn_Hist]([Para],[dDate])  VALUES ('" & p_Para & "',getdate());"
            Else
                p_SQL = "INSERT INTO [dbo].[tblLogSyn_Hist]([Para],[ToDate])  VALUES ('" & p_Para & "',getdate());"
            End If

            If g_Services.Sys_Execute(p_SQL, p_SQL) Then

            End If

        Catch ex As Exception
            p_SQL = ""
        End Try

    End Sub
End Module
