Module frmDongBoLenhXuat

    Public Sub DongBoLenhXuat()
        Dim l_ztb As New Connect2SapEx.Str_PhieuXuatTable
        Dim p_Err As String = ""
        ' Dim p_Count As Integer
        Dim p_DataTable As DataTable
        ' Dim p_Err As String
        Dim p_Datatable2 As DataTable
        Dim i_date As String = ""
        Dim i_dateTo As String = ""
        Dim p_Date As Date
        Dim p_DataGrid As New DataTable("Table")
        Dim p_Datarow As DataRow
        Dim p_Row() As DataRow
        Dim p_SQL As String
        Dim p_Date_ND As Boolean = False
        Dim g_KV1 As Boolean = False
        Dim p_Count As Integer

        Dim p_LaiNgay As String = "Y"

        If g_SapConnectionString = "" Then
            SaveLog("Error: SAP to HTTG", "kết nối đến SAP", "")
            g_JobRunng = False
            Exit Sub
        End If

        g_JobRunng = True
        Try



            p_SQL = "select KeyValue from sys_config where upper(KeyCode ) =upper('NgayHieuLuc')"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    If p_DataTable.Rows(0).Item(0).ToString.Trim = "Y" Then
                        p_Date_ND = True
                    End If
                End If
            End If

            g_KV1 = False

            p_SQL = "select KeyValue from sys_config where upper(KeyCode ) =upper('KV1')"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    If p_DataTable.Rows(0).Item(0).ToString.Trim = "Y" Then
                        g_KV1 = True
                    End If
                End If
            End If





            g_SyncMaster.clsHistStringSyn("SoLenh", True)

            p_SQL = " exec  DuLieuLenhXuat_Services"
            p_Datatable2 = Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If p_Datatable2 Is Nothing Then
                p_SQL = "select top 1 convert(date,getdate() - (" & g_DayBefore & " ) ) as fDate, convert(date,getdate()+  (" & g_DayBefore & " )  ) as dDate , " &
                 " datepart(hour,getdate())as tHour, datepart(minute,getdate()) as tTime  " &
                 " where   DatePart(Hour, getdate()) >= " & g_TimeRun & ""

                p_Datatable2 = Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            End If

            If Not p_Datatable2 Is Nothing Then
                If p_Datatable2.Rows.Count > 0 Then
                    p_Date = CDate(p_Datatable2.Rows(0).Item("fDate"))
                    i_date = p_Date.ToString("yyyy.MM.dd")
                    ' i_dateTo = p_Date.ToString("yyyy.MM.dd")

                    p_Date = CDate(p_Datatable2.Rows(0).Item("dDate"))
                    ' i_date = p_Date.ToString("yyyy.MM.dd")
                    i_dateTo = p_Date.ToString("yyyy.MM.dd")

                    l_ztb = New Connect2SapEx.Str_PhieuXuatTable

                    p_Err = ""
                    g_TimeOut = 50

                    SaveLog("A1", "", "")

                    If g_SAP_OBJECT.clsSyncDeliveries_DoListAuto(l_ztb, g_SapConnectionString, i_date, i_dateTo,
                                            g_ShPoint, g_TimeOut, p_DataTable,
                                            p_Err) = False Then
                        If p_Err <> "" Then
                            SaveLog("SoLenh clsSyncDeliveries_DoListAuto: ", p_Err, "")
                        End If
                        SaveLog("D1", "", "")
                    End If
                    ' p_DataTable.WriteXml("C:\tmp\kv2.xml")
                    ' p_DataTable.Select("", "Order_No")
                    ' p_Row = p_DataTable.Select("Resource_Nd='N05'")

                    'Dim p_ArrRow() As DataRow
                    'p_ArrRow = p_DataTable.Select("Order_No='2036880193'")
                    '  If p_DataGrid.Columns.Count = 0 Then
                    p_DataGrid.Columns.Add("X")
                    p_DataGrid.Columns.Add("SoLenh")
                    p_DataGrid.Columns.Add("NgayThang")
                    p_DataGrid.Columns.Add("sStatus")
                    p_DataGrid.Columns.Add("sDesc")
                    'End If
                    'p_DataTable.WriteXml("C:\tmp\KV21111.xml")
                    If Not p_DataTable Is Nothing Then
                        'p_DataTable.Select("", )
                        p_DataTable.DefaultView.Sort = "Date_Nd ASC, Order_No asc"
                        p_DataTable = p_DataTable.DefaultView.ToTable


                        For p_Count = 0 To p_DataTable.Rows.Count - 1
                            'If Check_SoLenh(p_Err, p_DataTable.Rows(p_Count).Item("Order_No").ToString.Trim) = False Then
                            'If p_DataTable.Rows(p_Count).Item("Order_No").ToString.Trim = "2036702350" Then
                            '    p_SQL = p_SQL
                            'End If
                            p_Row = p_DataGrid.Select("SoLenh='" & p_DataTable.Rows(p_Count).Item("Order_No").ToString.Trim & "'")
                            If p_Row.Length <= 0 Then
                                p_Datarow = p_DataGrid.NewRow
                                p_Datarow.Item("X") = "Y"
                                p_Datarow.Item("SoLenh") = p_DataTable.Rows(p_Count).Item("Order_No").ToString.Trim
                                'If p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim <> "" Then
                                '    p_Datarow.Item("NgayThang") = p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim

                                'End If
                                If p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim <> "" Then
                                    i_date = p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim

                                    'i_date = Mid(p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim, 5, 2)
                                    'i_date = i_date & "/" & Strings.Right(p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim, 2)
                                    'i_date = i_date & "/" & Strings.Left(p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim, 4)
                                    Try
                                        p_Datarow.Item("NgayThang") = i_date   ' CDate(i_date).ToString("MM/dd/yyyy")
                                    Catch ex As Exception

                                    End Try

                                End If

                                p_Datarow.Item("sStatus") = "N"
                                p_DataGrid.Rows.Add(p_Datarow)
                            End If

                            ' End If

                        Next
                        p_Err = ""
                        SaveLog("A2", "", "")
                        'p_DataGrid.WriteXml("C:\tmp\KV2.xml")
                        If p_DataGrid.Rows.Count > 0 Then
                            ' p_Row = p_DataTable.Select("Resource_Nd='N05'")

                            If LenhXuatAuto(g_KV1, p_Date_ND, CDate(i_date), "", g_User_ID, g_UserName, g_Company_Code,
                                       p_DataGrid, p_Err, p_LaiNgay) = False Then
                                SaveLog("SoLenh clsLenhXuatAuto: ", p_Err, "")
                            End If

                        End If

                        '  p_Row = p_DataTable.Select("Resource_Nd='N05'")

                    End If
                End If
            End If
Line_KT:
            g_SyncMaster.clsHistStringSyn("SoLenh", False)
            g_JobRunng = False

        Catch ex As Exception

            SaveLog("SoLenh", ex.Message, "")

            g_JobRunng = False
        End Try



    End Sub



    Private Function Check_SoLenh(ByRef err As String, ByVal i_SoLenh As String) As Boolean
        Dim p_DataTable, p_TableExec As DataTable
        Dim p_Err As String
        Dim p_DataRow As DataRow
        Check_SoLenh = False
        Dim p_SQL As String = ""
        p_TableExec = New DataTable("Tbl001")
        p_TableExec.Columns.Add("STR_SQL")
        'Return g_c2SQL.ExeNonQuery("sp_Check_SoLenhE5", err, New SqlParameter("@SoLenh", i_SoLenh))
        p_SQL = "Select SoLenh from tblLenhXuatE5 with (nolock) where SoLenh ='" & i_SoLenh & "' and isnull(Status,'1') ='1' "
        p_DataTable = GetDataTable(p_SQL, p_Err) ' ("exec sp_Check_SoLenhE5 '" & i_SoLenh & "'", p_Err)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                'Check_SoLenh = True
                p_SQL = "delete from tblLenhXuatChiTietE5  where " &
                            " exists (select 1 from FPT_tblLenhXuatChiTietE5_V a  where " &
                                      " a.SoLenh='" & i_SoLenh & "'  and a.Row_id=tblLenhXuatChiTietE5.Row_id)"
                p_DataRow = p_TableExec.NewRow
                p_DataRow.Item(0) = p_SQL
                p_TableExec.Rows.Add(p_DataRow)

                p_DataRow = p_TableExec.NewRow
                p_SQL = "delete from tblLenhXuat_HangHoaE5  where SoLenh='" & i_SoLenh & "'"
                p_DataRow.Item(0) = p_SQL
                p_TableExec.Rows.Add(p_DataRow)

                p_DataRow = p_TableExec.NewRow
                p_SQL = "delete from tblLenhXuatE5  where SoLenh='" & i_SoLenh & "'"
                p_DataRow.Item(0) = p_SQL
                p_TableExec.Rows.Add(p_DataRow)
                If Sys_Execute_DataTableNew(p_TableExec, p_Err) = False Then
                    Check_SoLenh = True
                End If
            End If
        End If
    End Function


    Private Function Check_SoLenh_Old(ByRef err As String, ByVal i_SoLenh As String) As Boolean
        Dim p_DataTable As DataTable
        Dim p_Err As String
        Check_SoLenh_Old = False
        'Return g_c2SQL.ExeNonQuery("sp_Check_SoLenhE5", err, New SqlParameter("@SoLenh", i_SoLenh))
        p_DataTable = GetDataTable("exec sp_Check_SoLenhE5 '" & i_SoLenh & "'", p_Err)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Check_SoLenh_Old = True
            End If
        End If
    End Function

    'Sys_Execute







    Public Function LenhXuatAuto(p_KV1 As Boolean, p_Date_ND As Boolean, ByVal p_Date As Date, ByVal p_Client As String,
                                 ByVal p_User_ID As Integer, ByVal p_User_Name As String, ByVal p_Company_Code As String,
                                        ByRef p_DataTable As System.Data.DataTable, ByRef p_Desc As String, p_LaiNgay As String) As Boolean
        Dim p_DataRow, p_Row As System.Data.DataRow
        Dim p_Count As Integer
        Dim p_TblExe As New System.Data.DataTable("Table01")
        Dim p_SQL As String = ""
        Dim p_Error As String
        Dim p_Desc_OK As String = "Lệnh đã có trên hệ thống"
        'Dim p_DateCrd As DateTime
        ' Dim p_Date_ND As Boolean = False
        'Dim p_DataTableTmp As DataTable
        'Dim p_NgayHieuLuc As String
        Dim p_NgayHieuLuc As String = ""
        Dim p_TblPost As DataTable
        Try
            LenhXuatAuto = True
            'If p_DataTable.Rows.Count > 0 Then
            '    p_NgayHieuLuc = CDate(p_DataTable.Rows(0).Item("NgayThang")).ToString("yyyy/MM/dd")
            '    If g_SAP_OBJECT.clsLenhXuatAuto_HTTG(p_NgayHieuLuc, "", 0, "sysadmin", g_Company_Code, p_DataTable, p_Error) = False Then

            '    End If
            'End If

            ' p_TblExe.Columns.Add("SQL_STR")
            p_TblPost = p_DataTable.Clone
            For p_Count = 0 To p_DataTable.Rows.Count - 1
                'If p_Count >= 50 Then
                '    Exit For
                'End If
                p_DataRow = p_DataTable.Rows(p_Count)
                If p_DataRow.Item("X") = "Y" Then
                    If Not p_DataRow Is Nothing Then
                        If Check_SoLenh(p_Error, p_DataRow.Item("SoLenh").ToString.Trim) = False Then
                            p_Error = ""
                            If p_DataRow.Item("NgayThang").ToString.Trim <> "" Then
                                p_NgayHieuLuc = CDate(p_DataRow.Item("NgayThang")).ToString("yyyy/MM/dd")
                            Else
                                p_NgayHieuLuc = CDate(p_Date).ToString("yyyy/MM/dd")
                            End If

                            If g_SAP_OBJECT.clsSyncDeliveries_SynSpecificServices(p_Date_ND, p_KV1, "", 0, g_Company_Code, p_DataRow.Item("SoLenh").ToString.Trim, p_Error, p_Date, p_LaiNgay, True) = False Then
                                p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ([SoLenh],[NgayThang],[TrangThai],[Createby],[CreateDate],[sDesc])" &
                                           " VALUES('" & p_DataRow.Item("SoLenh").ToString.Trim & "'" &
                                                   ",'" & p_NgayHieuLuc & "','Y','" & p_User_Name & "', getdate(),N'" & p_Error & "')"

                                SaveLog("D2", "", "")
                            Else
                                p_Row = p_TblPost.NewRow
                                p_Row.Item("SoLenh") = p_DataRow.Item("SoLenh").ToString.Trim
                                p_TblPost.Rows.Add(p_Row)
                                SaveLog("A3", "", "")

                                p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ([SoLenh],[NgayThang],[TrangThai],[Createby],[CreateDate],[sDesc],[StatusCode])" &
                                           " VALUES('" & p_DataRow.Item("SoLenh").ToString.Trim & "'" &
                                                   ",'" & p_NgayHieuLuc & "','Y','" & p_User_Name & "', getdate(),N'" & p_Error & "','Y')"
                            End If

                            ' If CheckMessage(p_Error) = True Then

                            ' End If
                            p_Desc = ""
                            g_Services.Sys_Execute(p_SQL, p_Desc)
                            If p_Desc <> "" Then
                                SaveLog("Services SoLenh:" & p_DataRow.Item("SoLenh").ToString.Trim, Replace(p_Desc, "'", ""), Replace(p_SQL, "'", ""))
                            End If

                            If p_TblPost.Rows.Count > 10 Then
                                Post_LenhXuatAuto(p_TblPost, p_Error)
                                p_TblPost.Clear()
                            End If

                        End If
                    End If
                End If
            Next
            If p_TblPost.Rows.Count > 0 Then
                Post_LenhXuatAuto(p_TblPost, p_Error)
            End If
        Catch ex As Exception
            p_Desc = ex.Message
            LenhXuatAuto = False
        End Try

        'If p_TblExe.Rows.Count > 0 Then
        '    If g_Services.Sys_Execute_DataTbl(p_TblExe,
        '                                   p_Desc) = False Then

        '    End If
        'End If

        LenhXuatAuto = True


    End Function


    Public Function CheckMessage(p_Message As String) As Boolean
        Dim p_Table As DataTable
        Dim p_SQL As String = ""
        Dim p_TmpStr As String = ""
        CheckMessage = True
        If p_Message = "" Then
            Exit Function
        End If
        p_SQL = "select count(1) as nCount from  FPT_CheckMessage  where charindex (upper(Code), upper('" & p_Message & "'),1)  >0"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item(0) > 0 Then
                    Return False
                End If
            End If
        End If
    End Function

    Private Sub Post_LenhXuatAuto(p_TableChiTiet As DataTable, ByRef o_err As String)
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
                o_err = ""
                p_ECCDestinationConfig.clsPost_LenhXuatAuto(p_TableChiTiet, o_err)
            End If
        End If



    End Sub










    Public Function ThongTinLenhXuat_Services(ByRef o_err As String) As DataTable
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_Table3 As DataTable
        Dim p_Date As String = ""
        Dim p_DataSet As DataSet
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select *, convert(nvarchar(10),getdate() ,111) as Sys_Date from tblconfig; select KeyValue from sys_config  where upper( KEYCODE) ='NGAYHIEULUC'"

        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            p_Table2 = p_DataSet.Tables(0)
            p_Table3 = p_DataSet.Tables(1)
        End If
        ' p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then

                p_Date = p_Table2.Rows(0).Item("Sys_Date").ToString.Trim
                If Not p_Table3 Is Nothing Then
                    If p_Table3.Rows.Count > 0 Then
                        If p_Table3.Rows(0).Item("KeyValue") = "Y" Then
                            p_Date = ""
                        End If
                    End If
                End If
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
                p_Table = p_ECCDestinationConfig.clsThongTinLenhXuat_Services(o_err, p_Date)
                'If Not p_Table Is Nothing Then
                '    If p_Table.Rows.Count > 0 Then
                '        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                '        o_err = ""
                '        'If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                '        'End If
                '    End If
                'End If
            End If
        End If
        Return p_Table
    End Function



    Public Sub DongBoLenhXuatServices()
        Dim l_ztb As New Connect2SapEx.Str_PhieuXuatTable
        Dim p_Err As String = ""
        ' Dim p_Count As Integer
        Dim p_DataTable As DataTable
        ' Dim p_Err As String
        Dim p_Datatable2 As DataTable
        Dim i_date As String = ""
        Dim i_dateTo As String = ""
        Dim p_Date As Date
        Dim p_DataGrid As New DataTable("Table")
        Dim p_Datarow As DataRow
        Dim p_Row() As DataRow
        Dim p_SQL As String
        Dim p_Date_ND As Boolean = False
        Dim g_KV1 As Boolean = False
        Dim p_Count As Integer

        Dim p_LaiNgay As String = "Y"

        If g_SapConnectionString = "" Then
            SaveLog("Error: SAP to HTTG", "kết nối đến SAP", "")
            g_JobRunng = False
            Exit Sub
        End If

        g_JobRunng = True
        Try



            p_SQL = "select KeyValue from sys_config where upper(KeyCode ) =upper('NgayHieuLuc')"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    If p_DataTable.Rows(0).Item(0).ToString.Trim = "Y" Then
                        p_Date_ND = True
                    End If
                End If
            End If

            g_KV1 = False

            p_SQL = "select KeyValue from sys_config where upper(KeyCode ) =upper('KV1')"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    If p_DataTable.Rows(0).Item(0).ToString.Trim = "Y" Then
                        g_KV1 = True
                    End If
                End If
            End If

            g_SyncMaster.clsHistStringSyn("SoLenh", True)
            'p_SQL = " exec  DuLieuLenhXuat_Services"
            'p_Datatable2 = Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            'If p_Datatable2 Is Nothing Then
            '    p_SQL = "select top 1 convert(date,getdate() - (" & g_DayBefore & " ) ) as fDate, convert(date,getdate()+  (" & g_DayBefore & " )  ) as dDate , " &
            '     " datepart(hour,getdate())as tHour, datepart(minute,getdate()) as tTime  " &
            '     " where   DatePart(Hour, getdate()) >= " & g_TimeRun & ""

            '    p_Datatable2 = Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            'End If

            'If Not p_Datatable2 Is Nothing Then
            '    If p_Datatable2.Rows.Count > 0 Then
            'p_Date = CDate(p_Datatable2.Rows(0).Item("fDate"))
            'i_date = p_Date.ToString("yyyy.MM.dd")
            '' i_dateTo = p_Date.ToString("yyyy.MM.dd")

            'p_Date = CDate(p_Datatable2.Rows(0).Item("dDate"))
            '' i_date = p_Date.ToString("yyyy.MM.dd")
            'i_dateTo = p_Date.ToString("yyyy.MM.dd")

            'l_ztb = New Connect2SapEx.Str_PhieuXuatTable

            'p_Err = ""
            'If g_SAP_OBJECT.clsSyncDeliveries_DoListAuto(l_ztb, g_SapConnectionString, i_date, i_dateTo,
            '                        g_ShPoint, g_TimeOut, p_DataTable,
            '                        p_Err) = False Then
            '    If p_Err <> "" Then
            '        SaveLog("SoLenh clsSyncDeliveries_DoListAuto: ", p_Err, "")
            '    End If

            'End If
            p_Err = ""
            p_DataGrid = ThongTinLenhXuat_Services(p_Err)
            If Not p_DataGrid Is Nothing Then
                If p_DataGrid.Rows.Count > 0 Then
                    If LenhXuatAuto(g_KV1, False, Now.Date, "", g_User_ID, g_UserName, g_Company_Code,
                            p_DataGrid, p_Err, p_LaiNgay) = False Then
                        SaveLog("SoLenh clsLenhXuatAuto: ", p_Err, "")
                    End If
                End If
            End If
            '  If p_DataGrid.Columns.Count = 0 Then
            'p_DataGrid.Columns.Add("X")
            'p_DataGrid.Columns.Add("SoLenh")
            'p_DataGrid.Columns.Add("NgayThang")
            'p_DataGrid.Columns.Add("sStatus")
            'p_DataGrid.Columns.Add("sDesc")
            'End If

            'If Not p_DataTable Is Nothing Then
            '    'p_DataTable.Select("", )
            '    p_DataTable.DefaultView.Sort = "Date_Nd ASC, Order_No asc"
            '    p_DataTable = p_DataTable.DefaultView.ToTable
            '    For p_Count = 0 To p_DataTable.Rows.Count - 1

            '        If Check_SoLenh(p_Err, p_DataTable.Rows(p_Count).Item("Order_No").ToString.Trim) = False Then
            '            p_Row = p_DataGrid.Select("SoLenh='" & p_DataTable.Rows(p_Count).Item("Order_No").ToString.Trim & "'")
            '            If p_Row.Length <= 0 Then
            '                p_Datarow = p_DataGrid.NewRow
            '                p_Datarow.Item("X") = "Y"
            '                p_Datarow.Item("SoLenh") = p_DataTable.Rows(p_Count).Item("Order_No").ToString.Trim
            '                'If p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim <> "" Then
            '                '    p_Datarow.Item("NgayThang") = p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim

            '                'End If
            '                If p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim <> "" Then
            '                    i_date = Mid(p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim, 5, 2)
            '                    i_date = i_date & "/" & Strings.Right(p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim, 2)
            '                    i_date = i_date & "/" & Strings.Left(p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim, 4)
            '                    Try
            '                        p_Datarow.Item("NgayThang") = i_date   ' CDate(i_date).ToString("MM/dd/yyyy")
            '                    Catch ex As Exception

            '                    End Try

            '                End If

            '                p_Datarow.Item("sStatus") = "N"
            '                p_DataGrid.Rows.Add(p_Datarow)
            '            End If

            '        End If

            '    Next
            '    p_Err = ""
            '    If p_DataGrid.Rows.Count > 0 Then
            '        If LenhXuatAuto(g_KV1, p_Date_ND, CDate(i_date), "", g_User_ID, g_UserName, g_Company_Code,
            '                   p_DataGrid, p_Err, p_LaiNgay) = False Then
            '            SaveLog("SoLenh clsLenhXuatAuto: ", p_Err, "")
            '        End If

            '    End If



            'End If
            '    End If
            'End If
Line_KT:
            g_SyncMaster.clsHistStringSyn("SoLenh", False)
            g_JobRunng = False

        Catch ex As Exception

            SaveLog("SoLenh", ex.Message, "")

            g_JobRunng = False
        End Try



    End Sub



    Public Sub ExecRuntimeLenhXuat()
        Dim p_ConfigValue As String = "TIMEAUTO"
        Dim p_Para As String = "SoLenh"
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
                    ' DongBoLenhXuatServices()
                    DongBoLenhXuat()
                Else
                    Exit Sub
                End If
            End If

        End If
    End Sub



End Module
