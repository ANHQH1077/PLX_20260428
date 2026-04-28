Module DongBoMasterData



    Public Sub THN_LenhXuat_Infor(ByVal p_TableHeader As DataTable, ByVal p_TableHangHoa As DataTable,
                                        ByVal p_TableChiTiet As DataTable, ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
                p_Table = p_ECCDestinationConfig.clsTHN_LenhXuat_Infor(p_TableHeader, p_TableHangHoa, p_TableChiTiet, o_err)
            End If
        End If



    End Sub




    Public Sub THN_Hoa_Infor(ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_SQL = "insert into  tblLogSyn_Hist  (Para, dDate) VALUES ('HoaDon', getdate())"

                If Sys_Execute(p_SQL, p_SQL) = True Then

                End If
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
                p_Table = p_ECCDestinationConfig.clsGet_HoaDon_Infor(o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""

                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then
                            ' Return False
                            'Exit Sub
                        End If
                    End If
                    'If g_Services.Then Then

                    'End If
                    '    If g_Services.Sys_Execute(p_SQL, o_err) = False Then


                    '    End If
                    'End If
                End If
            End If
        End If



    End Sub



    Public Sub THN_CongTy_Infor(ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
                p_Table = p_ECCDestinationConfig.clsGet_CongTy_Infor(o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""
                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        End If
                    End If
                End If
            End If
        End If



    End Sub




    Public Sub THN_HopDong_Infor(ByVal p_CompanyCode As String, ByVal i_date As String, ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_Table3, p_DataTable As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_Desc As String = ""
        Dim p_Count As Integer
        '  Dim p_MaPhuongThucBan As String
        Dim p_DataSet As DataSet

        Dim p_Vbeln As String = ""
        Dim p_SQL As String
        Dim p_GetAll As Boolean = False

        p_SQL = "select KeyValue from sys_config  where upper(KeyCode) =upper('ALL_PROJECT')"

        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                If p_DataTable.Rows(0).Item(0).ToString.Trim = "Y" Then
                    p_GetAll = True
                End If
            End If
        End If



        p_SQL = "select * from tblconfig;" &
                "select MaDonVi  from tblDonVi  where  left(MaDonVi,2)   " &
                        " in (select top 1 left(CompanyCode,2) as CompanyCode  from tblConfig )  order By MaDonVi ;"


        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            p_Table2 = p_DataSet.Tables(0)
            p_Table3 = p_DataSet.Tables(1)
        End If
        'p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_SQL = "insert into  tblLogSyn_Hist  (Para, dDate) VALUES ('HopDong', getdate())"
                If Sys_Execute(p_SQL, p_SQL) = True Then
                End If
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, p_CompanyCode)
                If Not p_Table3 Is Nothing Then
                    For p_Count = 0 To p_Table3.Rows.Count - 1
                        p_CompanyCode = p_Table3.Rows(p_Count).Item("MaDonVi").ToString.Trim
                        o_err = ""
                        p_Table = p_ECCDestinationConfig.clsDongBoHopDong(p_CompanyCode, i_date, g_UserName, o_err, p_GetAll)
                    Next
                End If


                '10001'
                g_SyncMaster.clsCapNhatLog("HopDong", 0)
                g_SyncMaster.clsHistStringSyn("HopDong", False)
            End If
        End If



    End Sub

    Public Sub THN_Kho_Infor(ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
                p_Table = p_ECCDestinationConfig.clsGet_Kho_Infor(o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""

                        ' p_SQL = "delete from tblKHo  "
                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        End If
                    End If
                End If
            End If
        End If
    End Sub



    Public Sub THN_NhaCungCap_Infor(ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_tblCompanyCode As DataTable
        Dim p_SQLCompany As String
        Dim p_Count As Integer
        Dim p_ComCode As String = ""
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim

                p_SQLCompany = "select MaDonVi from  tblDonVi  where left (MaDonVi,2)  " &
                        " in (  select top 1 left(Companycode,2)  from tblConfig  where isnull(Companycode,'') <> '' ) "
                p_tblCompanyCode = GetDataTable(p_SQLCompany, p_SQLCompany)
                If Not p_tblCompanyCode Is Nothing Then
                    For p_Count = 0 To p_tblCompanyCode.Rows.Count - 1
                        p_ComCode = p_tblCompanyCode.Rows(p_Count).Item("MaDonVi").ToString.Trim
                        p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, p_ComCode)
                        p_Table = p_ECCDestinationConfig.clsGet_NhaCungCap_Infor(o_err)
                        If Not p_Table Is Nothing Then
                            If p_Table.Rows.Count > 0 Then
                                o_err = ""
                                If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                                End If
                            End If
                        End If
                    Next
                End If

            End If
        End If



    End Sub





    Public Sub ExecRuntimeSTO()
        Dim p_ConfigValue As String = "TimeSTO"
        Dim p_Para As String = "STO"
        Dim p_SQL As String = ""
        Dim p_DataSet As DataSet
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_iDate As String = ""
        Dim o_err As String = ""

        g_JobRunngSTO = True

        p_SQL = "GetTimeSyns '" & p_ConfigValue & "','" & p_Para & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_Table = p_DataSet.Tables(0)
                p_Table2 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_iDate = p_Table2.Rows(0).Item(0).ToString.Trim
            End If
        End If
        If p_iDate = "" Then
            Exit Sub
        End If
        p_iDate = Replace(p_iDate, ".", "-")
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item(0) = 0 Then
                    THN_STO_Infor()
                Else
                    Exit Sub
                End If
            End If

        End If
    End Sub
    Public Sub THN_STO_Infor()
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim o_err As String
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        ' g_JobRunngSTO = True
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
                p_Table = p_ECCDestinationConfig.clsGet_STO_Infor(o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""

                        ' p_SQL = "delete from tblKHo  "
                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        End If
                    End If
                End If
            End If
        End If



    End Sub



    'Public Sub THN_TyGia_Infor(ByVal p_DateIn As String, ByRef o_err As String)
    '    Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
    '    Dim p_Table As DataTable
    '    Dim p_Table2 As DataTable
    '    Dim p_ConnectSapString, p_TimeOut As String
    '    Dim p_SQL As String = "select * from tblconfig"
    '    p_Table2 = GetDataTable(p_SQL, p_SQL)
    '    If Not p_Table2 Is Nothing Then
    '        If p_Table2.Rows.Count > 0 Then

    '            p_SQL = "insert into  tblLogSyn_Hist  (Para, dDate) VALUES ('TyGia', getdate())"

    '            If Sys_Execute(p_SQL, p_SQL) = True Then

    '            End If

    '            p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
    '            p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
    '            p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
    '            p_Table = p_ECCDestinationConfig.clsGet_TyGia_Infor(p_DateIn, o_err)
    '            If Not p_Table Is Nothing Then
    '                If p_Table.Rows.Count > 0 Then
    '                    '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
    '                    o_err = ""

    '                    ' p_SQL = "delete from tblKHo  "
    '                    If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


    '                    End If
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub



    Public Sub THN_DonGia_Infor(ByVal p_DateIn As String, ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then

                p_SQL = "insert into  tblLogSyn_Hist  (Para, dDate) VALUES ('DonGia', getdate())"

                If Sys_Execute(p_SQL, p_SQL) = True Then

                End If



                If g_SyncMaster.ClsSyncMaster_SyncPrice(p_Table, p_DateIn, o_err) Then
                End If

                'p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                'p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                'p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
                'p_Table = p_ECCDestinationConfig.clsGet_TyGia_Infor(p_DateIn, o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""

                        ' p_SQL = "delete from tblKHo  "
                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        End If

                        p_SQL = "insert into  tblLogSyn_Hist  (Para, ToDate) VALUES ('DonGia', getdate())"

                        If Sys_Execute(p_SQL, p_SQL) = True Then

                        End If

                    End If
                End If

                p_SQL = "insert into  tblLogSyn_Hist  (Para, ToDate) VALUES ('DonGia', getdate())"

                If Sys_Execute(p_SQL, p_SQL) = True Then

                End If
            End If
        End If
    End Sub


    Public Sub ExecRuntimeTyGia()
        Dim p_ConfigValue As String = "TimeTyGia"
        Dim p_Para As String = "TyGia"
        Dim p_SQL As String = ""
        Dim p_DataSet As DataSet
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_iDate As String = ""
        Dim o_err As String = ""
        p_SQL = "GetTimeSyns '" & p_ConfigValue & "','" & p_Para & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_Table = p_DataSet.Tables(0)
                p_Table2 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_iDate = p_Table2.Rows(0).Item(0).ToString.Trim
            End If
        End If
        If p_iDate = "" Then
            Exit Sub
        End If
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item(0) = 0 Then
                    THN_TyGia_Infor(p_iDate, o_err)
                Else
                    Exit Sub
                End If
            End If

        End If
    End Sub


    Public Sub ExecRuntimeNhaCungCap()
        Dim p_ConfigValue As String = "TimeNhaCC"
        Dim p_Para As String = "NhaCC"
        Dim p_SQL As String = ""
        Dim p_DataSet As DataSet
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_iDate As String = ""
        Dim o_err As String = ""


        g_JobRunngNhaCungCap = True
        p_SQL = "GetTimeSyns '" & p_ConfigValue & "','" & p_Para & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_Table = p_DataSet.Tables(0)
                p_Table2 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_iDate = p_Table2.Rows(0).Item(0).ToString.Trim
            End If
        End If
        If p_iDate = "" Then
            Exit Sub
        End If
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item(0) = 0 Then
                    THN_NhaCungCap_Infor(o_err)
                Else
                    Exit Sub
                End If
            End If

        End If
    End Sub


    Public Sub ExecRuntimeHopDong()
        Dim p_ConfigValue As String = "TimeHopDong"
        Dim p_Para As String = "HopDong"
        Dim p_SQL As String = ""
        Dim p_DataSet As DataSet
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_iDate As String = ""
        Dim o_err As String = ""

        g_JobRunngHopDong = True

        p_SQL = "GetTimeSyns '" & p_ConfigValue & "','" & p_Para & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_Table = p_DataSet.Tables(0)
                p_Table2 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_iDate = p_Table2.Rows(0).Item(0).ToString.Trim
            End If
        End If
        If p_iDate = "" Then
            Exit Sub
        End If
        p_iDate = Replace(p_iDate, ".", "-")
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item(0) = 0 Then
                    THN_HopDong_Infor(g_Company_Code, p_iDate, o_err)
                Else
                    Exit Sub
                End If
            End If

        End If
    End Sub


    Public Sub ExecRuntimeToKhai()
        Dim p_ConfigValue As String = "TimeToKhai"
        Dim p_Para As String = "ToKhai"
        Dim p_SQL As String = ""
        Dim p_DataSet As DataSet
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_iDate As String = ""
        Dim o_err As String = ""

        g_JobRunngToKhai = True

        'p_SQL = "GetTimeSyns '" & p_ConfigValue & "','" & p_Para & "'"
        'p_DataSet = GetDataSet(p_SQL, p_SQL)
        'If Not p_DataSet Is Nothing Then
        '    If p_DataSet.Tables.Count > 0 Then
        '        p_Table = p_DataSet.Tables(0)
        '        p_Table2 = p_DataSet.Tables(1)
        '    End If
        'End If
        'If Not p_Table2 Is Nothing Then
        '    If p_Table2.Rows.Count > 0 Then
        '        p_iDate = p_Table2.Rows(0).Item(0).ToString.Trim
        '    End If
        'End If
        'If p_iDate = "" Then
        '    Exit Sub
        'End If
        'p_iDate = Replace(p_iDate, ".", "-")
        ToKhaiTaiXuat_Infor()

        'If Not p_Table Is Nothing Then
        '    If p_Table.Rows.Count > 0 Then
        '        If p_Table.Rows(0).Item(0) = 0 Then
        '            ()
        '        Else
        '            Exit Sub
        '        End If
        '    End If

        'End If
    End Sub

    Public Sub DongBoTuyenDuong()
        Dim p_DataExec As New DataTable("Table01")
        Dim p_Desc As String = ""
        Dim p_Table, p_Table2 As DataTable
        Dim p_DataSet As DataSet
        Dim p_ConfigValue As String = "TimeTuyenDuong"
        Dim p_Para As String = "TuyenDuong"
        Dim p_SQL As String = ""


        g_JobRunngTuyenDuong = True
        p_DataExec.Columns.Add("STR_SQL")


        p_SQL = "GetTimeSyns '" & p_ConfigValue & "','" & p_Para & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_Table = p_DataSet.Tables(0)
                p_Table2 = p_DataSet.Tables(1)
            End If
        End If
        'If Not p_Table2 Is Nothing Then
        '    If p_Table2.Rows.Count > 0 Then
        '        p_iDate = p_Table2.Rows(0).Item(0).ToString.Trim
        '    End If
        'End If
        'If p_iDate = "" Then
        '    Exit Sub
        'End If
        ' p_iDate = Replace(p_iDate, ".", "-")

        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item(0) = 0 Then

                    g_SyncMaster.clsHistStringSyn("TuyenDuong", True)
                    If g_SyncMaster.ClsSyncMaster_SyncDischard(p_DataExec, p_Desc) Then

                    End If
                    If p_DataExec.Rows.Count > 0 Then
                        p_Desc = ""
                        If g_Services.Sys_Execute_DataTbl(p_DataExec, p_Desc) = False Then


                        End If
                    End If
                    g_SyncMaster.clsHistStringSyn("TuyenDuong: " & p_DataExec.Rows.Count, False)

                Else
                    Exit Sub
                End If
            End If

        End If

    End Sub




    'anhqh
    '20200901
    'Ham dong bo to khai tai xuat
    Private Sub ToKhaiTaiXuat_Infor()
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        Dim i_date As String
        Dim isGetAll As String = "H"
        Dim o_err As String
        Dim g_dt As DataTable
        Dim p_Check As Boolean = False
        g_JobRunngToKhai = True
        p_SQL = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)

                p_Table = p_ECCDestinationConfig.clsGet_ToKhaiTaiXuat_Infor(g_Company_Code, i_date, g_UserName, o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""
                        p_Check = True
                        ' p_SQL = "delete from tblKHo  "
                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        End If
                    End If
                End If
                If p_Check = False Then
                    ' SaveLog("")
                    SaveLog("ToKhaiTaiXuat", o_err, "")
                End If
            End If
        End If



    End Sub




    Public Sub ExecRuntimeHoaDon()
        Dim p_ConfigValue As String = "TimeHoaDon"
        Dim p_Para As String = "HoaDon"
        Dim p_SQL As String = ""
        Dim p_DataSet As DataSet
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_iDate As String = ""
        Dim o_err As String = ""
        p_SQL = "GetTimeSyns '" & p_ConfigValue & "','" & p_Para & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_Table = p_DataSet.Tables(0)
                p_Table2 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_iDate = p_Table2.Rows(0).Item(0).ToString.Trim
            End If
        End If
        If p_iDate = "" Then
            Exit Sub
        End If
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item(0) = 0 Then
                    THN_Hoa_Infor(o_err)
                Else
                    Exit Sub
                End If
            End If

        End If
    End Sub


    'Public Sub ExecRuntimeDonGia()
    '    Dim p_ConfigValue As String = "TimeDonGia"
    '    Dim p_Para As String = "DonGia"
    '    Dim p_SQL As String = ""
    '    Dim p_DataSet As DataSet
    '    Dim p_Table As DataTable
    '    Dim p_Table2 As DataTable
    '    Dim p_iDate As String = ""
    '    Dim o_err As String = ""
    '    g_JobRunngDonGia = True
    '    p_SQL = "GetTimeSyns '" & p_ConfigValue & "','" & p_Para & "'"
    '    p_DataSet = GetDataSet(p_SQL, p_SQL)
    '    If Not p_DataSet Is Nothing Then
    '        If p_DataSet.Tables.Count > 0 Then
    '            p_Table = p_DataSet.Tables(0)
    '            p_Table2 = p_DataSet.Tables(1)
    '        End If
    '    End If
    '    If Not p_Table2 Is Nothing Then
    '        If p_Table2.Rows.Count > 0 Then
    '            p_iDate = p_Table2.Rows(0).Item(0).ToString.Trim
    '        End If
    '    End If
    '    If p_iDate = "" Then
    '        Exit Sub
    '    End If
    '    If Not p_Table Is Nothing Then
    '        If p_Table.Rows.Count > 0 Then
    '            If p_Table.Rows(0).Item(0) = 0 Then
    '                THN_DonGia_Infor(p_iDate, o_err)
    '            Else
    '                Exit Sub
    '            End If
    '        End If

    '    End If
    'End Sub


    Public Sub DongBoDonGia_TyGia()
        Dim p_DataExec As New DataTable("Table001")
        Dim p_Desc As String = ""
        Dim l_date As String = ""
        Dim o_err As String = ""

        p_DataExec.Columns.Add("STR_SQL")
        l_date = g_SyncMaster.clsGetDateLog("DonGia")
        l_date = Replace(l_date, ".", "-")
        ' p_Date = p_

        g_SyncMaster.clsHistStringSyn("DonGia", True)

        If g_SyncMaster.ClsSyncMaster_SyncPrice(p_DataExec, l_date, p_Desc) Then

        End If
        If p_DataExec.Rows.Count > 0 Then
            o_err = ""

            ' p_SQL = "delete from tblKHo  "
            If g_Services.Sys_Execute_DataTbl(p_DataExec, o_err) = False Then


            End If
        End If
        g_SyncMaster.clsHistStringSyn("DonGia", False)
        THN_TyGia_Infor(l_date, o_err)

    End Sub


    Private Sub THN_TyGia_Infor(ByVal p_DateIn As String, ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
                p_Table = p_ECCDestinationConfig.clsGet_TyGia_Infor(p_DateIn, o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""

                        ' p_SQL = "delete from tblKHo  "
                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        End If
                    End If
                End If
            End If
        End If



    End Sub



    Public Sub ExecRuntimeDonGia()
        Dim p_ConfigValue As String = "TimeDonGia"
        Dim p_Para As String = "DonGia"
        Dim p_SQL As String = ""
        Dim p_DataSet As DataSet
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_iDate As String = ""
        Dim o_err As String = ""
        p_SQL = "GetTimeSyns '" & p_ConfigValue & "','" & p_Para & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_Table = p_DataSet.Tables(0)
                p_Table2 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_iDate = p_Table2.Rows(0).Item(0).ToString.Trim
            End If
        End If
        If p_iDate = "" Then
            Exit Sub
        End If
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item(0) = 0 Then
                    'DongBoDonGia_TyGia()
                    ' DongBoLenhXuatServices()
                    THN_DonGia_Infor(p_iDate, o_err)
                Else
                    Exit Sub
                End If
            End If

        End If
    End Sub


End Module
