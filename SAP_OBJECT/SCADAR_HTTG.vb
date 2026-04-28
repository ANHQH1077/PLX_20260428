Module SCADAR_HTTG
    'p_TypeIn=out hoac in

    Public Function ScadarToHTTG(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                 Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True, _
                                   Optional ByVal p_E5 As Boolean = True) As String
        Dim p_SQL As String
        Dim p_DataSet As DataSet
        Dim p_Eror As Boolean
        Dim p_Desc As String
        Dim p_ArrRow() As DataRow
        Dim p_DataTable As DataTable

        Try

            GetClient_E5(p_Terminal)

            p_SQL = "SELECT * from SYS_CONFIG"
            p_DataTable = GetDataTable(p_SQL, p_SQL)

            p_ArrRow = p_DataTable.Select("KEYCODE='KV1'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    g_KV1 = True
                Else
                    g_KV1 = False
                End If
            End If

            g_INTANK_E5 = False
            p_ArrRow = p_DataTable.Select("KEYCODE='INTANK_E5'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    g_INTANK_E5 = True
                Else
                    g_INTANK_E5 = False
                End If
            End If

            p_SQL = "select * from tblDecimaNumberE5 with (Nolock) "
            g_ConfigDecima = GetDataTable(p_SQL, p_SQL)


            ScadarToHTTG = ""
            g_HTTG_E5 = p_E5
            'p_SQL = "select * from tblMap_cp;" & _
            '    "select * from SYS_Map_cp_Line; " & _
            '    "select * from SYS_CONFIG; " & _
            '    "SELECT *  FROM [tblMap_MaHangHoa] where MaHangHoa_Sap='0201004';"
            p_SQL = "exec FPT_GetDataTableList"
            p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)
            If Not p_DataSet Is Nothing Then
                If p_DataSet.Tables.Count > 0 Then
                    g_DataMap_cp = p_DataSet.Tables(0)
                    g_DataMap_Line_cp = p_DataSet.Tables(1)
                    g_Table_Sys_Config = p_DataSet.Tables(2)
                    g_TableMaHangHoaE5 = p_DataSet.Tables(3)
                    'anhqh 20150819
                    g_TabletblConfig = p_DataSet.Tables(4)

                    p_ArrRow = g_Table_Sys_Config.Select("KEYCODE='MATUDONGHOA'")
                    If p_ArrRow.Length > 0 Then
                        g_MaTuDongHoa = IIf(p_ArrRow(0).Item("KEYVALUE").ToString.Trim = "", "N", p_ArrRow(0).Item("KEYVALUE").ToString.Trim)
                    End If
                    p_ArrRow = g_Table_Sys_Config.Select("KEYCODE='MANGAN_DD'")
                    If p_ArrRow.Length > 0 Then
                        g_MaNgan_DD = IIf(p_ArrRow(0).Item("KEYVALUE").ToString.Trim = "", "N", p_ArrRow(0).Item("KEYVALUE").ToString.Trim)
                    End If

                    'anhqh
                    '20170911
                    g_GetScadarDetail = False
                    p_ArrRow = g_Table_Sys_Config.Select("KEYCODE='SCADAR_DETAIL'")
                    If p_ArrRow.Length > 0 Then
                        If p_ArrRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                            g_GetScadarDetail = True
                        End If
                        '' g_MaNgan_DD = IIf(p_ArrRow(0).Item("KEYVALUE").ToString.Trim = "", "N", p_ArrRow(0).Item("KEYVALUE").ToString.Trim)
                    End If


                End If
            End If

            g_Services.Sys_GetParameterOracle(g_DBTYPE)

            '20150819
            If Not g_TabletblConfig Is Nothing Then
                If g_TabletblConfig.Rows.Count > 0 Then
                    g_TypeConnet = g_TabletblConfig.Rows(0).Item("optional").ToString.Trim()
                End If
            End If

            '20150819
            If UCase(g_TypeConnet) = "FOX" Then
                If GetConnectFox(p_Desc, p_TypeIn, g_LoaiVanChuyen, p_Terminal) = False Then
                    ScadarToHTTG = p_Desc
                    p_Eror = True
                    Exit Function
                End If
            End If



            getSQL_TableToScadar(p_TypeIn, g_LoaiVanChuyen, p_Terminal)
            If p_GetScadarToHTTG = True Then
                If g_DBTYPE = "SQL" Then
                    SQLGetDataFromScadar(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Eror, p_Desc, p_Terminal)
                    If p_Eror = True Then
                        ScadarToHTTG = p_Desc

                    Else

                    End If
                End If
            End If
        Catch ex As Exception
            ScadarToHTTG = ex.Message
        End Try
    End Function


    Function CheckHangHoaE5(ByVal p_MaHangHoa As String) As Boolean
        '  Dim p_Count As Integer
        Dim p_DataRow() As DataRow

        CheckHangHoaE5 = False
        Try
            'If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
            '    Return True
            'End If
            p_DataRow = g_TableMaHangHoaE5.Select("MaHangHoa_Sap='" & p_MaHangHoa & "' or MaHangHoa_Scada='" & p_MaHangHoa & "'  ")
            If p_DataRow.Length > 0 Then
                Return True
            End If
        Catch ex As Exception

        End Try

    End Function

    Private Function GetStatusType() As String
        Dim p_Datatatable As DataTable
        Dim p_SQL As String
        GetStatusType = "="
        p_SQL = "select * from SYS_CONFIG  where KEYCODE='TRANGTHAI'"
        p_Datatatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_Datatatable Is Nothing Then
            If p_Datatatable.Rows.Count > 0 Then
                GetStatusType = p_Datatatable.Rows(0).Item("KEYVALUE").ToString.Trim
                If InStr(",=,>=,<=,>,<,", "," & GetStatusType & ",", CompareMethod.Text) > 0 Then

                Else
                    GetStatusType = "="
                End If
              
            End If
        End If

        Try

        Catch ex As Exception

        End Try
    End Function


    'anhqh
    'Ham thuc hien lay du lieu chi tiet cua  Scadar capnhat cho HTTG
    Private Sub SQLGetDataFromScadar(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, ByRef p_Error As Boolean, ByRef p_Desc As String, _
                                    ByVal p_Terminal As String)
        Dim p_SQL As String
        Dim p_DataHTTG As DataTable
        Dim p_CountRow As Integer
        Dim p_CountCol As Integer
        Dim p_Count As Integer
        Dim p_DataRowHTTG As DataRow
        Dim p_SQLInsert As String = ""
        Dim p_SQLValue As String = ""
        Dim p_DataRowMap_cp() As DataRow
        Dim p_FieldType As String

        Dim p_Value As String
        Dim p_TableName As String = ""
        Dim p_STT As Integer
        Dim p_TableScadar As DataTable
        Dim p_DataTableCheckID As DataTable
        Dim p_Where_Check As String  'Dung checkScadar

        Dim p_Where_Update As String  'Dung de update HTTG
        Dim p_TableIDHTTG As String

        Dim p_TableName_E5 As String = ""
        Dim p_DataRowMap_cp_E5() As DataRow
        Dim p_DataRowCheck() As DataRow
        Dim p_DataRowMap_cp_Old() As DataRow
        'Dim p_InsertTable_E5 As String = ""
        'Dim p_ValueTable_E5 As String = ""
        Dim p_TableScadar_E5 As DataTable
        Dim p_MaHangHoa As String
        Dim p_HangHoaE5 As Boolean
        Dim p_StatusType As String
        Dim p_FromField As String = ""
       
        Dim p_Flag() As String
        Dim p_DataTableA92 As DataTable

        Dim p_TableID As Integer
        Dim p_NgayXuat As DateTime
        Dim p_MaNgan As Integer

        If g_DataMap_cp Is Nothing Then
            Exit Sub
        End If

        'anhqh
        '20160926
        Dim p_TableInE5 As DataTable
        Dim p_RowInE5 As DataRow
        Dim p_Xuat92 As Boolean
        Dim p_CountField As Integer

        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "') and (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "' )")
        If p_DataRowMap_cp_Old.Length <= 0 Then
            Exit Sub
        End If


        If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
            p_TableName = p_DataRowMap_cp_Old(0).Item("TableName").ToString.Trim
        End If
        If UCase(g_LoaiVanChuyen) = "THUY" Then
            p_TableName = p_DataRowMap_cp_Old(0).Item("TableName_Thuy").ToString.Trim
        End If
        If p_DataRowMap_cp_E5.Length > 0 Then
            p_TableName_E5 = p_DataRowMap_cp_E5(0).Item("TableName").ToString.Trim
        End If

        If p_TableName = "" Then
            Exit Sub
        End If
        p_Error = False
        p_Desc = ""
        'If g_ConnectToScadar.ToString.Trim = "" Then
        '    p_Error = True
        '    p_Desc = "String kết nối đến máy chủ Scadar không xác định"
        '    Exit Sub
        'End If

        '20150819
        'Them dieu kien FOX
        If UCase(g_TypeConnet) = "FOX" Then
            If g_StrConnectFox.ToString.Trim = "" Then
                p_Error = True
                p_Desc = "String kết nối đến máy chủ Scadar không xác định"
                Exit Sub
            End If
        Else
            If g_ConnectToScadar.ToString.Trim = "" Then
                p_Error = True
                p_Desc = "String kết nối đến máy chủ Scadar không xác định"
                Exit Sub
            End If
        End If

        If UCase(g_TypeConnet) = "FOX" Then
            If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                p_TableName = Replace(g_PathFileFoxBo, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)
            Else
                p_TableName = Replace(g_PathFileFoxThuy, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)
            End If

        End If


        'lay chuoi select trong bang MaptblLine        
        p_SQL = "exec FPT_GetDataToScadar '" & p_SoLenh.Trim & "'"
        p_DataHTTG = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataHTTG Is Nothing Then

            'anhqh
            '20160926
            p_TableInE5 = p_DataHTTG.Clone

            For p_Count = 0 To p_DataHTTG.Rows.Count - 1

                '20170519================================================
                'g_INTANK_E5 
                'g_INTANK_E5=TRUE kho  co phoi tron san xang E5
                If g_INTANK_E5 = True Then
                    If CheckHangHoaE5(p_DataHTTG.Rows(p_Count).Item("MaHangHoa").ToString.Trim) = True Then
                        p_DataHTTG.Rows(p_Count).Item("MaHangHoa") = "0201001"
                    End If
                End If
                '20170519================================================

                p_DataRowHTTG = p_DataHTTG.Rows(p_Count)
                If g_TableMaHangHoaE5.Rows.Count <= 0 Then
                    Exit Sub
                End If
                p_HangHoaE5 = False
                p_MaHangHoa = p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                If CheckHangHoaE5(p_MaHangHoa.ToString.Trim) = True Then
                    p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    p_HangHoaE5 = True
                    If p_DataRowMap_cp.Length <= 0 Then
                        Exit Sub
                    End If
                Else
                    'p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_STT = p_DataRowMap_cp_Old(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    If p_DataRowMap_cp.Length <= 0 Then
                        Exit Sub
                    End If
                End If
                p_SQLInsert = ""
                p_SQLValue = ""
                p_Where_Check = ""
                p_Where_Update = ""
                For p_CountRow = 0 To p_DataRowMap_cp.Length - 1
                    'Lay kieu du lieu
                    p_FieldType = ""


                    'If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" Then
                    '    MsgBox("dfggd")
                    'End If


                    If UCase(g_LoaiVanChuyen) = "BO" And p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim = "" Then
                        Continue For
                    End If

                    If UCase(g_LoaiVanChuyen) = "THUY" And p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim = "" Then
                        Continue For
                    End If
                    If UCase(g_LoaiVanChuyen) = "SAT" And p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim = "" Then
                        Continue For

                    End If

                    If p_HangHoaE5 = True Then
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, g_Client_E5, p_HangHoaE5)
                    Else
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, p_Terminal, p_HangHoaE5)
                    End If

                    If p_FieldType.ToString.Trim <> "" Or UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "FLAG1" Then



                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "FLAG1" Then
                            If p_HangHoaE5 = True Then
                                p_Value = p_DataRowMap_cp_E5(0).Item("FlagFinish").ToString.Trim
                                p_Flag = p_Value.Split(".")
                                If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                    p_Value = p_Flag(0)
                                Else
                                    p_Value = p_Flag(1)
                                End If
                            Else
                                p_Value = p_DataRowMap_cp_Old(0).Item("FlagFinish").ToString.Trim
                                p_Flag = p_Value.Split(".")
                                If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                    p_Value = p_Flag(0)
                                Else
                                    p_Value = p_Flag(1)
                                End If
                            End If
                            p_StatusType = GetStatusType()


                            If p_Where_Check.ToString.Trim = "" Then
                                If UCase(g_TypeConnet) = "FOX" Then
                                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                        p_DataRowCheck = g_TableToScadarBo.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")
                                    Else
                                        p_DataRowCheck = g_TableToScadarThuy.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")

                                    End If
                                    If p_DataRowCheck.Length > 0 Then
                                        Select Case UCase(p_DataRowCheck(0).Item("FieldType").ToString.Trim)
                                            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                                p_Value = p_Value
                                            Case UCase("DateTime"), UCase("Date")
                                                p_Value = "{d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                            Case UCase("String")
                                                p_Value = "'" & p_Value & "'"
                                        End Select
                                        Select Case UCase(g_LoaiVanChuyen)
                                            Case "BO"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case "THUY"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case "SAT"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case Else
                                                Continue For
                                        End Select
                                    End If
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case Else
                                            Continue For
                                    End Select
                                End If


                            Else
                                If UCase(g_TypeConnet) = "FOX" Then
                                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                        p_DataRowCheck = g_TableToScadarBo.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")
                                    Else
                                        p_DataRowCheck = g_TableToScadarThuy.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")

                                    End If
                                    If p_DataRowCheck.Length > 0 Then
                                        Select Case UCase(p_DataRowCheck(0).Item("FieldType").ToString.Trim)
                                            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                                p_Value = p_Value
                                            Case UCase("DateTime"), UCase("Date")
                                                p_Value = "{d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                            Case UCase("String")
                                                p_Value = "'" & p_Value & "'"
                                        End Select
                                        Select Case UCase(g_LoaiVanChuyen)
                                            Case "BO"
                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case "THUY"
                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case "SAT"
                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case Else
                                                Continue For
                                        End Select
                                    End If
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case Else
                                            Continue For
                                    End Select
                                End If

                            End If
                            Continue For
                        Else
                            'ThoiGianDau()
                            'ThoiGianCuoi()
                            p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim
                        End If

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                'p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                p_Value = p_Value.Substring(1, g_MaNgan_DD)
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select

                            Else
                                p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                p_Value = p_Value.Substring(1, g_MaNgan_DD)
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select
                            End If
                        End If

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                'p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                If UCase(g_TypeConnet) = "FOX" And p_HangHoaE5 = False Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case Else
                                            Continue For
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case Else
                                            Continue For
                                    End Select

                                End If

                            Else
                                ' p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                If UCase(g_TypeConnet) = "FOX" And p_HangHoaE5 = False Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case Else
                                            Continue For
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case Else
                                            Continue For
                                    End Select
                                End If

                            End If
                        End If



                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then


                            If p_Where_Check.ToString.Trim = "" Then
                                'p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                                'p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                            Else
                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                'p_Where_Update = p_Where_Update & "  AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
                            End If
                        End If
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            ' If g_MaTuDongHoa = "N" Then  'Ma tu dong hoa cho SQL la TableID
                            'anhqh
                            '20150831
                            'Them truong hop neu khong phai la hoang hoa pha che thi nhay vao day
HoangHoaPhaChe:
                            p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
                            'p_FromField = "TableID"
                            'If g_MaTuDongHoa = "N" Then
                            If p_Value.ToString.Trim <> "" Then
                                'anhqh  20160623  Sua them dung rieng cho KV1   FPT_GetMaTuDongHoa_KV1
                                'If g_Company_Code = "2110" Then
                                '    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & GetMaVanChuyenLenhXuat(p_SoLenh) & "'"
                                'Else
                                '    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                'End If

                                'anhqh
                                '20160704
                                'themdieu kien cho KV1
                                If GetScadarWagonKV1() = True Then
                                    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & IIf(UCase(g_LoaiVanChuyen) = "SAT", "ZR", "AB") & "'"
                                Else
                                    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                End If

                                ' p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                'p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                                If Not p_DataTableCheckID Is Nothing Then
                                    If p_DataTableCheckID.Rows.Count > 0 Then
                                        p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                                    End If
                                End If
                            Else
                                'H_TableID
                                p_Value = p_DataRowHTTG.Item("H_TableID").ToString.Trim
                                If p_Value.ToString.Trim <> "" Then
                                    ' p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    'p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"

                                    'anhqh
                                    '20160704
                                    'themdieu kien cho KV1
                                    If GetScadarWagonKV1() = True Then
                                        p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                        p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & IIf(UCase(g_LoaiVanChuyen) = "SAT", "ZR", "AB") & "'"
                                    Else
                                        p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                        p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                    End If



                                    'anhqh  20160623  Sua them dung rieng cho KV1   FPT_GetMaTuDongHoa_KV1
                                    'If g_Company_Code = "2110" Then
                                    '    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & GetMaVanChuyenLenhXuat(p_SoLenh) & "'"
                                    'Else
                                    '    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                    'End If
                                    p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                                    If Not p_DataTableCheckID Is Nothing Then
                                        If p_DataTableCheckID.Rows.Count > 0 Then
                                            p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                                        End If
                                    End If
                                End If
                            End If


                            '20170519======================================================================================
                            'Them doan nay dung cho trương hop kho phoi tron san E5   INTANK_E5=true
                            'khi dó phải kiểm tra va chuyen key sang số
                            '20170519======================================================================================
                            If g_INTANK_E5 = True Then
                                If p_Where_Check.ToString.Trim = "" Then
                                    p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value
                                        Case Else
                                            Continue For
                                    End Select
                                Else
                                    ' p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value
                                        Case Else
                                            Continue For
                                    End Select
                                End If
                            Else
                                If p_Where_Check.ToString.Trim = "" Then
                                    p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                        Case Else
                                            Continue For
                                    End Select
                                Else
                                    ' p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                        Case Else
                                            Continue For
                                    End Select
                                End If
                            End If
                            'If p_Where_Check.ToString.Trim = "" Then
                            '    p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
                            '    Select Case UCase(g_LoaiVanChuyen)
                            '        Case "BO"
                            '            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                            '        Case "THUY"
                            '            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                            '        Case "SAT"
                            '            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            '        Case Else
                            '            Continue For
                            '    End Select
                            'Else
                            '    ' p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
                            '    Select Case UCase(g_LoaiVanChuyen)
                            '        Case "BO"
                            '            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                            '        Case "THUY"
                            '            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                            '        Case "SAT"
                            '            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            '        Case Else
                            '            Continue For
                            '    End Select
                            'End If



                        End If
                        'g_TypeConnet 
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MATUDONGHOA" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then

                            p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim
                            If p_Where_Check.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
                                End Select
                            End If
                        End If
                    End If
                Next

                If p_Where_Check.ToString.Trim <> "" Then

                    If p_HangHoaE5 = True Then
                        p_SQL = "select * from " & p_TableName_E5 & " WHERE " & p_Where_Check
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count > 0 Then
                                If p_TableScadar_E5 Is Nothing Then
                                    p_TableScadar_E5 = p_DataTableCheckID
                                Else
                                    p_TableScadar_E5.Merge(p_DataTableCheckID)
                                End If
                            Else
                                'anhqh
                                '20160926
                                'Kiem tra neu co them o DB cua E5 thi loai di
                                Try
                                    If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
                                        p_TableInE5.Clear()
                                        p_RowInE5 = p_TableInE5.NewRow
                                        For p_CountField = 0 To p_TableInE5.Columns.Count - 1
                                            p_RowInE5.Item(p_CountField) = p_DataRowHTTG.Item(p_CountField)

                                        Next
                                        p_TableInE5.Rows.Add(p_RowInE5)

                                        p_DataTableA92 = SQLGetDataFromScadar_A92(p_TableInE5, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
                                                            p_Terminal)

                                        If Not p_DataTableA92 Is Nothing Then
                                            If p_TableScadar_E5 Is Nothing Then
                                                p_TableScadar_E5 = p_DataTableA92
                                            Else
                                                p_TableScadar_E5.Merge(p_DataTableA92)
                                            End If

                                        End If

                                    End If
                                Catch ex As Exception

                                End Try
                            End If

                        End If
                    Else
                        p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check

                        If UCase(g_TypeConnet) = "FOX" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    If p_TableScadar Is Nothing Then
                                        p_TableScadar = p_DataTableCheckID
                                    Else
                                        p_TableScadar.Merge(p_DataTableCheckID)
                                    End If

                                Else
                                    'anhqh
                                    '20160926
                                    'Kiem tra neu co them o DB cua E5 thi loai di
                                    Try
                                        If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
                                            p_TableInE5.Clear()
                                            p_RowInE5 = p_TableInE5.NewRow
                                            For p_CountField = 0 To p_TableInE5.Columns.Count - 1
                                                p_RowInE5.Item(p_CountField) = p_DataRowHTTG.Item(p_CountField)

                                            Next
                                            p_TableInE5.Rows.Add(p_RowInE5)

                                            p_DataTableA92 = SQLGetDataFromScadar_A92(p_TableInE5, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
                                                                p_Terminal)

                                            If Not p_DataTableA92 Is Nothing Then
                                                If p_TableScadar_E5 Is Nothing Then
                                                    p_TableScadar_E5 = p_DataTableA92
                                                Else
                                                    p_TableScadar_E5.Merge(p_DataTableA92)
                                                End If

                                            End If

                                        End If
                                    Catch ex As Exception

                                    End Try

                                End If
                            End If
                        End If
                        If UCase(g_TypeConnet) = "SQL" Then

                            'anhqh'
                            '20160926
                            ' p_Xuat92 = False

                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then

                                    If p_TableScadar Is Nothing Then
                                        p_TableScadar = p_DataTableCheckID
                                    Else
                                        p_TableScadar.Merge(p_DataTableCheckID)
                                    End If



                                Else

                                    'anhqh
                                    '20160926
                                    'Kiem tra neu co them o DB cua E5 thi loai di
                                    Try
                                        If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
                                            p_TableInE5.Clear()
                                            p_RowInE5 = p_TableInE5.NewRow
                                            For p_CountField = 0 To p_TableInE5.Columns.Count - 1
                                                p_RowInE5.Item(p_CountField) = p_DataRowHTTG.Item(p_CountField)

                                            Next
                                            p_TableInE5.Rows.Add(p_RowInE5)

                                            p_DataTableA92 = SQLGetDataFromScadar_A92(p_TableInE5, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
                                                                p_Terminal)

                                            If Not p_DataTableA92 Is Nothing Then
                                                If p_TableScadar_E5 Is Nothing Then
                                                    p_TableScadar_E5 = p_DataTableA92
                                                Else
                                                    p_TableScadar_E5.Merge(p_DataTableA92)
                                                End If

                                            End If

                                        End If
                                    Catch ex As Exception
                                        p_MaHangHoa = p_MaHangHoa
                                    End Try

                                End If
                            End If
                        End If
                    End If
                End If
            Next
            p_CountRow = 0


            'If g_HTTG_E5 = True Then
            '    p_DataTableA92 = SQLGetDataFromScadar_A92(p_DataHTTG, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
            '                         p_Terminal)
            '    If Not p_DataTableA92 Is Nothing Then
            '        If p_TableScadar_E5 Is Nothing Then
            '            p_TableScadar_E5 = p_DataTableA92
            '        Else
            '            p_TableScadar_E5.Merge(p_DataTableA92)
            '        End If

            '    End If
            'Else
            '    p_TableScadar_E5 = Nothing
            'End If


            'anhqh
            '20170911
            'Lay chi tiet theo ngan
            If g_GetScadarDetail = True Then
                'anhqh
                '20160819
                If UpdateFromScadarToHTTG(g_LoaiVanChuyen, p_DataRowMap_cp_E5, p_DataRowMap_cp_Old, p_DataHTTG, p_TableScadar, p_TableScadar_E5, p_Desc) = True Then
                    ' p_Error = True
                    ' Exit Sub
                End If
                'anhqh
                '20150817
                If g_HTTG_E5 = True Then
                    UpdateFromScadarToHTTG_A92(g_LoaiVanChuyen, p_DataRowMap_cp_E5, p_DataRowMap_cp_Old, p_DataHTTG, p_TableScadar, p_TableScadar_E5)
                End If
            Else


                If Not p_TableScadar Is Nothing Then
                    p_CountRow = p_CountRow + p_TableScadar.Rows.Count


                End If

                If Not p_TableScadar_E5 Is Nothing Then
                    p_CountRow = p_CountRow + p_TableScadar_E5.Rows.Count
                End If




                If p_DataHTTG.Rows.Count = p_CountRow And p_CountRow > 0 Then
                    'anhqh
                    '20160819
                    If UpdateFromScadarToHTTG(g_LoaiVanChuyen, p_DataRowMap_cp_E5, p_DataRowMap_cp_Old, p_DataHTTG, p_TableScadar, p_TableScadar_E5, p_Desc) = True Then
                        ' p_Error = True
                        ' Exit Sub
                    End If
                    'anhqh
                    '20150817
                    If g_HTTG_E5 = True Then
                        UpdateFromScadarToHTTG_A92(g_LoaiVanChuyen, p_DataRowMap_cp_E5, p_DataRowMap_cp_Old, p_DataHTTG, p_TableScadar, p_TableScadar_E5)
                    End If
                Else
                    p_Error = True
                    p_Desc = "Chưa thực hiện bơm xuất"
                    Exit Sub
                End If
            End If
        End If
    End Sub


    Private Sub XuLyXang92XuatHongE5(ByVal p_Terminal As String, ByVal g_LoaiVanChuyen As String, ByVal p_TableScadar As DataTable, ByRef p_TableScadar_E5 As DataTable, ByVal p_TypeIn As String)
        Dim p_count As Integer
        Dim p_Tbl1 As DataTable
        Dim p_Tbl1_E5 As DataTable
        Dim p_SQL As String
        Dim p_DataSet As DataSet
        Dim p_Arr() As DataRow
        Dim p_FromField As String
        Dim p_ToField As String

        Dim p_Field As String
        Dim p_FieldE5 As String

        If p_TableScadar_E5 Is Nothing Then
            Exit Sub
        End If
        If p_TableScadar_E5.Rows.Count <= 0 Then
            Exit Sub
        End If

        p_SQL = "select FromField,Bo,Thuy,Sat from SYS_Map_cp_Line a " & _
                 "where exists (select 1 from tblMap_cp  b where  a.stt=b.stt  " & _
                "  and (Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "')  " & _
                 " and  upper(a.FromField) in ( 'TABLEID','NGAYXUAT','MANGAN') and SWhere='Y'"
        p_Tbl1 = GetDataTable(p_SQL, p_SQL)

        p_SQL = " select FromField,Bo,Thuy,Sat from SYS_Map_cp_Line a  " & _
                                "where exists (select 1 from tblMap_cp  b where  a.stt=b.stt  " & _
                             "and (Status='" & p_TypeIn & "'  or Status='" & UCase(p_TypeIn) & "' ) and " & _
                               " (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "'	))  " & _
                             "and  upper(a.FromField) in ( 'TABLEID','NGAYXUAT','MANGAN') and SWhere='Y'"
        p_Tbl1_E5 = GetDataTable(p_SQL, p_SQL)

        Try
            If Not p_Tbl1 Is Nothing And Not p_Tbl1_E5 Is Nothing Then
                For p_count = 0 To p_Tbl1.Rows.Count - 1
                    p_FromField = p_Tbl1.Rows(p_count).Item("FromField").ToString.Trim
                    Select Case UCase(g_LoaiVanChuyen)
                        Case "BO"
                            p_Field = p_Tbl1.Rows(p_count).Item("Bo").ToString.Trim
                        Case "THUY"
                            p_Field = p_Tbl1.Rows(p_count).Item("Thuy").ToString.Trim
                        Case "SAT"
                            p_Field = p_Tbl1.Rows(p_count).Item("Sat").ToString.Trim
                    End Select
                    p_Arr = p_Tbl1_E5.Select("FromField='" & p_FromField & "'")
                    If p_Arr.Length Then

                    End If
                Next

            End If

        Catch ex As Exception

        End Try
     
       

        'p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        'p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "') and (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "' )")
        'If p_DataRowMap_cp_Old.Length <= 0 Then
        '    Exit Sub
        'End If


    End Sub





    'anhqh
    '20150817
    'Ham thuc hien voi Hang hoa xang A92 khi xuat hong E5

    Public Function SQLGetDataFromScadar_A92(ByVal p_DataHTTG As DataTable, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, ByRef p_Error As Boolean, ByRef p_Desc As String, _
                                    ByVal p_Terminal As String) As DataTable
        Dim p_SQL As String
        Dim p_CountRow As Integer
        Dim p_CountCol As Integer
        Dim p_Count As Integer
        Dim p_DataRowHTTG As DataRow
        Dim p_SQLInsert As String = ""
        Dim p_SQLValue As String = ""
        Dim p_DataRowMap_cp() As DataRow
        Dim p_FieldType As String

        Dim p_Value As String
        Dim p_TableName As String = ""
        Dim p_STT As Integer
        Dim p_TableScadar As DataTable
        Dim p_DataTableCheckID As DataTable
        Dim p_Where_Check As String  'Dung checkScadar

        Dim p_Where_Update As String  'Dung de update HTTG

        Dim p_TableName_E5 As String = ""
        Dim p_DataRowMap_cp_E5() As DataRow
        Dim p_DataRowMap_cp_Old() As DataRow
        Dim p_InsertTable_E5 As String = ""
        Dim p_ValueTable_E5 As String = ""
        Dim p_TableScadar_E5 As DataTable
        Dim p_MaHangHoa As String
        Dim p_HangHoaE5 As Boolean
        Dim p_TyleE5 As Double
        Dim p_TyTrongNenE5 As Double
        Dim p_TyTrongEthanolE5 As Double
        Dim p_StrExeE5 As String
        Dim p_Flag() As String
        'Dim p_DataRowHangHoaE5() As DataRow
        Dim p_Value_HTTG As String
        Dim p_StatusType As String
        Dim p_DataRowCheck() As DataRow

        'p_TableExec.Columns.Add("SQL_STR", GetType(String))
        'p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))


        ' Exit Function

        If g_DataMap_cp Is Nothing Then
            Exit Function
        End If
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "') and (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "' )")
        If p_DataRowMap_cp_Old.Length <= 0 Then
            Exit Function
        End If

        If p_DataRowMap_cp_E5.Length <= 0 Then
            Exit Function
        End If

        If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
            p_TableName = p_DataRowMap_cp_Old(0).Item("TableName").ToString.Trim
        End If
        If UCase(g_LoaiVanChuyen) = "THUY" Then
            p_TableName = p_DataRowMap_cp_Old(0).Item("TableName_Thuy").ToString.Trim
        End If
        If p_DataRowMap_cp_E5.Length > 0 Then
            p_TableName_E5 = p_DataRowMap_cp_E5(0).Item("TableName").ToString.Trim
        End If

        If p_TableName = "" Then
            Exit Function
        End If

        If UCase(g_TypeConnet) = "FOX" Then

            If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                p_TableName = Replace(g_PathFileFoxBo, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)

            Else
                p_TableName = Replace(g_PathFileFoxThuy, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)

            End If

        End If


        p_Error = False
        p_Desc = ""
        '20150819
        'Them dieu kien FOX
        If UCase(g_TypeConnet) = "FOX" Then
            If g_StrConnectFox.ToString.Trim = "" Then
                p_Error = True
                p_Desc = "String kết nối đến máy chủ Scadar không xác định"
                Exit Function
            End If
        Else
            If g_ConnectToScadar.ToString.Trim = "" Then
                p_Error = True
                p_Desc = "String kết nối đến máy chủ Scadar không xác định"
                Exit Function
            End If
        End If


        'lay chuoi select trong bang MaptblLine        
        'p_SQL = "exec FPT_GetDataToScadar '" & p_SoLenh.Trim & "'"
        'p_DataHTTG = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataHTTG Is Nothing Then
            For p_Count = 0 To p_DataHTTG.Rows.Count - 1
                p_DataRowHTTG = p_DataHTTG.Rows(p_Count)
                If p_DataRowHTTG.Item("MaHangHoa").ToString.Trim <> "0201001" And p_DataRowHTTG.Item("MaHangHoa").ToString.Trim <> "020202" Then
                    Continue For
                End If

                'If g_TableMaHangHoaE5.Rows.Count <= 0 Then
                '    Exit Function
                'End If
                p_HangHoaE5 = True
                p_MaHangHoa = p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                'If p_MaHangHoa.ToString.Trim = g_TableMaHangHoaE5.Rows(0).Item("MaHangHoa_Scada").ToString.Trim Then
                '    p_HangHoaE5 = True
                'End If

                'If p_MaHangHoa.ToString.Trim = g_TableMaHangHoaE5.Rows(0).Item("MaHangHoa_Scada").ToString.Trim Then
                'anhqh  20150817
                If p_HangHoaE5 = True Then
                    p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    '  p_HangHoaE5 = True
                    If p_DataRowMap_cp.Length <= 0 Then
                        Exit Function
                    End If
                Else
                    'p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_STT = p_DataRowMap_cp_Old(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    If p_DataRowMap_cp.Length <= 0 Then
                        Exit Function
                    End If
                End If

                p_SQLInsert = ""
                p_SQLValue = ""
                p_Where_Check = ""
                p_Where_Update = ""
                For p_CountRow = 0 To p_DataRowMap_cp.Length - 1
                    'Lay kieu du lieu
                    p_FieldType = ""
                    'If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" Then
                    '    p_FieldType = ""
                    'End If
                    If UCase(g_LoaiVanChuyen) = "BO" And p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim = "" Then
                        Continue For
                    End If

                    If UCase(g_LoaiVanChuyen) = "THUY" And p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim = "" Then
                        Continue For
                    End If
                    If UCase(g_LoaiVanChuyen) = "SAT" And p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim = "" Then
                        Continue For

                    End If

                    If p_HangHoaE5 = True Then
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, g_Client_E5, p_HangHoaE5)
                    Else
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, p_Terminal, p_HangHoaE5)
                    End If

                    If p_FieldType.ToString.Trim <> "" Then



                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "FLAG1" Then
                            If p_HangHoaE5 = True Then
                                p_Value = p_DataRowMap_cp_E5(0).Item("FlagFinish").ToString.Trim
                                p_Flag = p_Value.Split(".")
                                If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                    p_Value = p_Flag(0)
                                Else
                                    p_Value = p_Flag(1)
                                End If
                            Else
                                p_Value = p_DataRowMap_cp_Old(0).Item("FlagFinish").ToString.Trim
                                p_Flag = p_Value.Split(".")
                                If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                    p_Value = p_Flag(0)
                                Else
                                    p_Value = p_Flag(1)
                                End If
                            End If
                            p_StatusType = ">= "    '" GetStatusType()"


                            If p_Where_Check.ToString.Trim = "" Then
                                If UCase(g_TypeConnet) = "FOX" Then
                                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                        p_DataRowCheck = g_TableToScadarBo.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")
                                    Else
                                        p_DataRowCheck = g_TableToScadarThuy.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")

                                    End If
                                    If p_DataRowCheck.Length > 0 Then
                                        Select Case UCase(p_DataRowCheck(0).Item("FieldType").ToString.Trim)
                                            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                                p_Value = p_Value
                                            Case UCase("DateTime"), UCase("Date")
                                                p_Value = "{d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                            Case UCase("String")
                                                p_Value = "'" & p_Value & "'"
                                        End Select
                                        Select Case UCase(g_LoaiVanChuyen)
                                            Case "BO"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case "THUY"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case "SAT"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case Else
                                                Continue For
                                        End Select
                                    End If
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case Else
                                            Continue For
                                    End Select
                                End If


                            Else
                                If UCase(g_TypeConnet) = "FOX" Then
                                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                        p_DataRowCheck = g_TableToScadarBo.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")
                                    Else
                                        p_DataRowCheck = g_TableToScadarThuy.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")

                                    End If
                                    If p_DataRowCheck.Length > 0 Then
                                        Select Case UCase(p_DataRowCheck(0).Item("FieldType").ToString.Trim)
                                            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                                p_Value = p_Value
                                            Case UCase("DateTime"), UCase("Date")
                                                p_Value = "{d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                            Case UCase("String")
                                                p_Value = "'" & p_Value & "'"
                                        End Select
                                        Select Case UCase(g_LoaiVanChuyen)
                                            Case "BO"
                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case "THUY"
                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case "SAT"
                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case Else
                                                Continue For
                                        End Select
                                    End If
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & " " & p_StatusType & "'" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & " " & p_StatusType & "'" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & " " & p_StatusType & "'" & p_Value & "'"
                                        Case Else
                                            Continue For
                                    End Select
                                End If

                            End If
                            Continue For
                        Else

                            p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim


                        End If


                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                'p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                p_Value = p_Value.Substring(1, g_MaNgan_DD)
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select

                            Else
                                p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                p_Value = p_Value.Substring(1, g_MaNgan_DD)
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select
                            End If
                        End If

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                'p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"

                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    Case Else
                                        Continue For
                                End Select



                            Else
                                ' p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"

                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    Case Else
                                        Continue For
                                End Select
                                ' End If

                            End If
                        End If



                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                'p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                                'p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                            Else
                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                'p_Where_Update = p_Where_Update & "  AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
                            End If
                        End If
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            ' If g_MaTuDongHoa = "N" Then  'Ma tu dong hoa cho SQL la TableID
                            p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
                            'If g_MaTuDongHoa = "N" Then
                            If p_Value.ToString.Trim <> "" Then
                                ' p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                'p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                'anhqh
                                '20160704
                                'themdieu kien cho KV1
                                If GetScadarWagonKV1() = True Then
                                    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & IIf(UCase(g_LoaiVanChuyen) = "SAT", "ZR", "AB") & "'"
                                Else
                                    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                End If



                                'anhqh  20160623  Sua them dung rieng cho KV1   FPT_GetMaTuDongHoa_KV1
                                'If g_Company_Code = "2110" Then
                                '    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & GetMaVanChuyenLenhXuat(p_SoLenh) & "'"
                                'Else
                                '    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                'End If
                                p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                                If Not p_DataTableCheckID Is Nothing Then
                                    If p_DataTableCheckID.Rows.Count > 0 Then
                                        p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                                    End If
                                End If
                            Else
                                'H_TableID
                                p_Value = p_DataRowHTTG.Item("H_TableID").ToString.Trim
                                If p_Value.ToString.Trim <> "" Then
                                    ' p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    'p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"

                                    'anhqh
                                    '20160704
                                    'themdieu kien cho KV1
                                    If GetScadarWagonKV1() = True Then
                                        p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                        p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & IIf(UCase(g_LoaiVanChuyen) = "SAT", "ZR", "AB") & "'"
                                    Else
                                        p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                        p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                    End If



                                    'anhqh  20160623  Sua them dung rieng cho KV1   FPT_GetMaTuDongHoa_KV1
                                    'If g_Company_Code = "2110" Then
                                    '    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & GetMaVanChuyenLenhXuat(p_SoLenh) & "'"
                                    'Else
                                    '    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                    'End If
                                    p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                                    If Not p_DataTableCheckID Is Nothing Then
                                        If p_DataTableCheckID.Rows.Count > 0 Then
                                            p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                                        End If
                                    End If
                                End If
                            End If
                            If p_Where_Check.ToString.Trim = "" Then
                                p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select
                            Else
                                ' p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select
                            End If

                            'End If
                            ' ElseIf g_MaTuDongHoa = "Y" Then  'Ma tu dong hoa cho FOX
                            'p_SQL = "exec FPT_Key_TuDongHoa"
                            'p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                            'If Not p_DataTableCheckID Is Nothing Then
                            '    If p_DataTableCheckID.Rows.Count > 0 Then
                            '        p_Value = p_DataTableCheckID.Rows(0).Item("MaTuDongHoa").ToString.Trim
                            '    End If
                            'End If
                            ' p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim

                            ' End If

                        End If
                        'g_TypeConnet 
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MATUDONGHOA" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim
                            If p_Where_Check.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
                                End Select
                            End If
                        End If
                    End If
                Next

                If p_Where_Check.ToString.Trim <> "" Then
                    If p_HangHoaE5 = True Then
                        p_SQL = "select * from " & p_TableName_E5 & " WHERE " & p_Where_Check
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count > 0 Then
                                If p_TableScadar_E5 Is Nothing Then
                                    p_TableScadar_E5 = p_DataTableCheckID
                                Else
                                    p_TableScadar_E5.Merge(p_DataTableCheckID)
                                End If
                            End If

                        End If
                    Else
                        p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count > 0 Then
                                If p_TableScadar Is Nothing Then
                                    p_TableScadar = p_DataTableCheckID
                                Else
                                    p_TableScadar.Merge(p_DataTableCheckID)
                                End If
                            End If

                        End If

                    End If

                End If
            Next
        End If
        Return p_TableScadar_E5
    End Function


    Private Function UpdateFromScadarToHTTG(ByVal g_LoaiVanChuyen As String, ByVal p_DataRowMap_cp_E5() As DataRow, ByVal p_DataRowMap_cp_Old() As DataRow, ByVal p_DataTableHTTG As DataTable, _
                                                ByVal p_Scadar As DataTable, _
                                                ByVal p_ScadarE5 As DataTable, ByRef p_desc As String) As Boolean
        Dim p_DataRow As DataRow
        Dim p_CountRow As Integer
        Dim p_CountHTTG As Integer
        Dim p_STT As Integer
        Dim p_DataRowMap_cp() As DataRow
        Dim p_HangHoaE5 As Boolean
        Dim p_MaHangHoa As String
        Dim p_DataRowHTTG As DataRow
        Dim p_DataRowHangHoa() As DataRow

        Dim p_DataRowScadar() As DataRow

        Dim p_WhereUpdate As String
        Dim p_SQLUpdate As String
        Dim p_Value As String
        Dim p_ValueScadar As String
        ' Dim p_FileName As String
        'Dim p_DataRowMap_cp As DataRow
        Dim p_TableID As String
        Dim p_DataTableCheckID As DataTable
        Dim p_SQL As String
        Dim p_ColumnType As String
        Dim p_FieldScadar As String
        Dim p_DataTableWhere As New DataTable("TblWhere")
        Dim p_Where_Scadar As String

        p_DataTableWhere.Columns.Add("STR_HTTG", GetType(String))
        p_DataTableWhere.Columns.Add("STR_SCADAR", GetType(String))
        p_DataTableWhere.Columns.Add("STR_TYPE", GetType(String))
        p_DataTableWhere.Columns.Add("STT", GetType(String))

        UpdateFromScadarToHTTG = False
        If p_DataTableHTTG Is Nothing Then

            Exit Function
        End If
        If p_DataTableHTTG.Rows.Count <= 0 Then
            Exit Function
        End If




        Try
            p_DataTableWhere.Clear()
            For p_CountHTTG = 0 To p_DataTableHTTG.Rows.Count - 1
                p_WhereUpdate = ""
                p_SQLUpdate = ""
                p_Where_Scadar = ""

                p_DataRowHTTG = p_DataTableHTTG.Rows(p_CountHTTG)
                p_HangHoaE5 = False
                p_MaHangHoa = p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                'p_DataRowHangHoa = g_TableMaHangHoaE5.Select("MaHangHoa_Scada='" & p_MaHangHoa & "'")
                'If p_DataRowHangHoa.Length > 0 Then

                If CheckHangHoaE5(p_MaHangHoa) Then
                    'End If
                    p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    p_HangHoaE5 = True
                    If p_DataRowMap_cp.Length <= 0 Then
                        Exit Function
                    End If
                Else
                    p_STT = p_DataRowMap_cp_Old(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    If p_DataRowMap_cp.Length <= 0 Then
                        Exit Function
                    End If
                End If

                For p_CountRow = 0 To p_DataRowMap_cp.Length - 1
                    p_ColumnType = ""
                    p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).ToString.Trim


                    If (UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") Or UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" Then
                            p_ValueScadar = p_Value.Substring(1, g_MaNgan_DD)
                        Else
                            p_ValueScadar = p_Value
                        End If
                        '==================================================================================================
                        If p_Where_Scadar.ToString.Trim = "" Then
                            'Doan lay Where cho Scadar
                            If p_HangHoaE5 = True Then
                                If p_ScadarE5 Is Nothing Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))   ' UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                                Select Case UCase(p_ColumnType)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_Where_Scadar = p_FieldScadar & "=" & p_ValueScadar & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        p_Where_Scadar = p_FieldScadar & "='" & CDate(p_ValueScadar).ToString("yyyy/MM/dd") & "'"
                                    Case UCase("String")
                                        p_Where_Scadar = p_FieldScadar & "='" & p_ValueScadar & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select

                            Else
                                If p_Scadar Is Nothing Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))  ' UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))  ' UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))  'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                               

                                Select Case UCase(p_ColumnType)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_Where_Scadar = p_FieldScadar & "=" & p_ValueScadar & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        'If UCase(g_TypeConnet) = "FOX" Then
                                        '    p_Where_Scadar = p_FieldScadar & "={d '" & CDate(p_ValueScadar.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        'Else
                                        p_Where_Scadar = p_FieldScadar & "='" & CDate(p_ValueScadar).ToString("yyyy/MM/dd") & "'"
                                        '  End If

                                    Case UCase("String")
                                        p_Where_Scadar = p_FieldScadar & "='" & p_ValueScadar & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select
                            End If
                        Else
                            'Doan lay Where cho Scadar
                            If p_HangHoaE5 = True Then
                                If p_ScadarE5 Is Nothing Then
                                    If g_GetScadarDetail = True Then
                                        '  Continue For
                                        GoTo Line_TT
                                    End If
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                                Select Case UCase(p_ColumnType)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "=" & p_ValueScadar & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & CDate(p_ValueScadar).ToString("yyyy/MM/dd") & "'"
                                    Case UCase("String")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select

                            Else
                                If p_Scadar Is Nothing Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))  ' UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))  ' UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))  'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                                Select Case UCase(p_ColumnType)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "=" & p_ValueScadar & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & CDate(p_ValueScadar).ToString("yyyy/MM/dd") & "'"
                                    Case UCase("String")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select
                            End If


                            End If
                            '==================================================================================================
                            If p_WhereUpdate.ToString.Trim = "" Then
                                Select Case UCase(p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).GetType.Name)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "=" & IIf(p_Value.ToString.Trim = "", 0, p_Value) & ""
                                    Case UCase("DateTime"), UCase("Date")

                                        p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyy/MM/dd") & "'"

                                    Case UCase("String")
                                        p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select


                                'Continue For
                            Else
                                Select Case UCase(p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).GetType.Name)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "=" & p_Value & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyy/MM/dd") & "'"
                                    Case UCase("String")
                                        p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select
                            End If
                            Continue For
                    End If

                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                        If g_KV1 = True Then

                        Else
                            If p_WhereUpdate.ToString.Trim = "" Then
                                'p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                                'p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
                                p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                            Else
                                p_WhereUpdate = p_WhereUpdate & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                'p_Where_Update = p_Where_Update & "  AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
                            End If
                        End If

                       
                        Continue For
                    End If

                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                        ' p_WhereUpdate = p_WhereUpdate

                        p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
                        p_TableID = p_Value
                        ' If g_MaTuDongHoa = "N" Then
                        If p_TableID.ToString.Trim <> "" Then


                        Else
                            'H_TableID
                            p_Value = p_DataRowHTTG.Item("H_TableID").ToString.Trim
                            p_TableID = p_Value
                        End If

                        If p_TableID.ToString.Trim <> "" Then
                            ' p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_TableID & "','" & _
                            'p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"


                            'anhqh
                            '20160704
                            'themdieu kien cho KV1
                            If GetScadarWagonKV1() = True Then
                                p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & IIf(UCase(g_LoaiVanChuyen) = "SAT", "ZR", "AB") & "'"
                            Else
                                p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                            End If

                            'anhqh  20160623  Sua them dung rieng cho KV1   FPT_GetMaTuDongHoa_KV1

                            'If g_Company_Code = "2110" Then
                            '    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                            '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & GetMaVanChuyenLenhXuat(p_SoLenh) & "'"
                            'Else
                            '    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                            '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                            'End If
                            p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    p_TableID = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                                End If
                            End If
                        End If
                        p_ValueScadar = p_TableID
                        '========================================================================================
                        If p_Where_Scadar.ToString.Trim = "" Then
                            If p_HangHoaE5 = True Then
                                If p_ScadarE5 Is Nothing Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim)) 'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim)) 'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim)) 'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                                Select Case UCase(p_ColumnType)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_Where_Scadar = p_FieldScadar & "=" & p_ValueScadar & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        p_Where_Scadar = p_FieldScadar & "='" & CDate(p_ValueScadar).ToString("yyyy/MM/dd") & "'"
                                    Case UCase("String")
                                        p_Where_Scadar = p_FieldScadar & "='" & p_ValueScadar & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select

                            Else
                                If p_Scadar Is Nothing Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))  'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))  'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))  'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If

                                '=============================================================================
                                '20170519
                                'anhqh
                                'them trường hợp kho xuất INTANK_E5
                                '=============================================================================
                                If g_INTANK_E5 = True Then
                                    Select Case UCase(p_ColumnType)
                                        Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                            p_Where_Scadar = p_FieldScadar & "=" & p_ValueScadar & ""
                                        Case UCase("DateTime"), UCase("Date")
                                            p_Where_Scadar = p_FieldScadar & "='" & CDate(p_ValueScadar).ToString("yyyy/MM/dd") & "'"
                                        Case UCase("String")
                                            p_Where_Scadar = p_FieldScadar & "=" & p_ValueScadar
                                        Case Else
                                            UpdateFromScadarToHTTG = True
                                            Exit Function
                                    End Select
                                Else
                                    Select Case UCase(p_ColumnType)
                                        Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                            p_Where_Scadar = p_FieldScadar & "=" & p_ValueScadar & ""
                                        Case UCase("DateTime"), UCase("Date")
                                            p_Where_Scadar = p_FieldScadar & "='" & CDate(p_ValueScadar).ToString("yyyy/MM/dd") & "'"
                                        Case UCase("String")
                                            p_Where_Scadar = p_FieldScadar & "='" & p_ValueScadar & "'"
                                        Case Else
                                            UpdateFromScadarToHTTG = True
                                            Exit Function
                                    End Select
                                End If
                               
                            End If
                        Else
                            If p_HangHoaE5 = True Then
                                If p_ScadarE5 Is Nothing Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                                Select Case UCase(p_ColumnType)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "=" & p_ValueScadar & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & CDate(p_ValueScadar).ToString("yyyy/MM/dd") & "'"
                                    Case UCase("String")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select

                            Else
                                If p_Scadar Is Nothing Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))   ' UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))  'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))   'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                                End If
                                If g_INTANK_E5 = True Then
                                    Select Case UCase(p_ColumnType)
                                        Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                            p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "=" & p_ValueScadar & ""
                                        Case UCase("DateTime"), UCase("Date")
                                            p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & CDate(p_ValueScadar).ToString("yyyy/MM/dd") & "'"
                                        Case UCase("String")
                                            p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "=" & p_ValueScadar
                                        Case Else
                                            UpdateFromScadarToHTTG = True
                                            Exit Function
                                    End Select
                                Else
                                    Select Case UCase(p_ColumnType)
                                        Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                            p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "=" & p_ValueScadar & ""
                                        Case UCase("DateTime"), UCase("Date")
                                            p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & CDate(p_ValueScadar).ToString("yyyy/MM/dd") & "'"
                                        Case UCase("String")
                                            p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar & "'"
                                        Case Else
                                            UpdateFromScadarToHTTG = True
                                            Exit Function
                                    End Select
                                End If
                                
                            End If
                        End If
                        '========================================================================================



                        If p_WhereUpdate.ToString.Trim = "" Then
                            Select Case UCase(p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).GetType.Name)
                                Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "=" & p_Value & ""
                                Case UCase("DateTime"), UCase("Date")
                                    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyy/MM/dd") & "'"
                                Case UCase("String")
                                    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                Case Else
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                            End Select
                            ' Continue For
                        Else
                            Select Case UCase(p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).GetType.Name)
                                Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "=" & p_Value & ""
                                Case UCase("DateTime"), UCase("Date")
                                    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyy/MM/dd") & "'"
                                Case UCase("String")
                                    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                Case Else
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                            End Select


                        End If
                    'If p_WhereUpdate.ToString.Trim = "" Then
                    '    Select Case UCase(p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).GetType.Name)
                    '        Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                    '            p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "=" & p_Value & ""
                    '        Case UCase("DateTime"), UCase("Date")
                    '            p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyy/MM/dd") & "'"
                    '        Case UCase("String")
                    '            p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                    '        Case Else
                    '            UpdateFromScadarToHTTG = True
                    '            Exit Function
                    '    End Select
                    '    ' Continue For
                    'Else
                    '    Select Case UCase(p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).GetType.Name)
                    '        Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                    '            p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "=" & p_Value & ""
                    '        Case UCase("DateTime"), UCase("Date")
                    '            p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyy/MM/dd") & "'"
                    '        Case UCase("String")
                    '            p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                    '        Case Else
                    '            UpdateFromScadarToHTTG = True
                    '            Exit Function
                    '    End Select




                    'End If


                    Continue For
                    End If
                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MATUDONGHOA" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                        If p_Scadar Is Nothing Then
                            UpdateFromScadarToHTTG = True
                            Exit Function
                        End If
                        p_ValueScadar = p_DataRowHTTG.Item("MATUDONGHOA").ToString.Trim
                        Select Case UCase(g_LoaiVanChuyen)
                            Case "BO"
                                p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))   ' UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                            Case "THUY"
                                p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))  'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                            Case "SAT"
                                p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))   'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                            Case Else
                                UpdateFromScadarToHTTG = True
                                Exit Function
                        End Select
                        If p_ColumnType = "" Then
                            UpdateFromScadarToHTTG = True
                            Exit Function
                        End If
                        If p_Where_Scadar.ToString.Trim = "" Then
                            Select Case UCase(p_ColumnType)
                                Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                    p_Where_Scadar = p_FieldScadar & "=" & p_ValueScadar & ""
                                Case UCase("DateTime"), UCase("Date")
                                    p_Where_Scadar = p_FieldScadar & "='" & CDate(p_ValueScadar).ToString("yyyy/MM/dd") & "'"
                                Case UCase("String")
                                    p_Where_Scadar = p_FieldScadar & "='" & p_ValueScadar & "'"
                                Case Else
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                            End Select
                        Else
                            Select Case UCase(p_ColumnType)
                                Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                    p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "=" & p_ValueScadar & ""
                                    'Case UCase("DateTime"), UCase("Date")
                                    '    p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar.ToString.Trim & "'"
                                Case UCase("String")
                                    p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar & "'"
                                Case Else
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                            End Select

                        End If

                        '========================================================================================
                        If p_WhereUpdate.ToString.Trim = "" Then
                            Select Case UCase(p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).GetType.Name)
                                Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "=" & p_ValueScadar & ""
                                    'Case UCase("DateTime"), UCase("Date")
                                    '    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_ValueScadar).ToString("yyyyMMdd") & "'"
                                Case UCase("String")
                                    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_ValueScadar & "'"
                                Case Else
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                            End Select
                            ' Continue For
                        Else
                            Select Case UCase(p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).GetType.Name)
                                Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "=" & p_ValueScadar & ""
                                    'Case UCase("DateTime"), UCase("Date")
                                    '    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_ValueScadar).ToString("yyyyMMdd") & "'"
                                Case UCase("String")
                                    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_ValueScadar & "'"
                                Case Else
                                    UpdateFromScadarToHTTG = True
                                    Exit Function
                            End Select
                        End If
                        Continue For
                    End If

                Next

                If p_WhereUpdate.ToString.Trim = "" Or p_Where_Scadar.ToString.Trim = "" Then
                    UpdateFromScadarToHTTG = True
                    Exit Function
                End If
                'If p_WhereUpdate.ToString.Trim <> "" Then
                If g_KV1 = True Then
                    
                    If p_DataTableHTTG.Rows(p_CountHTTG).Item("PhuongTien").ToString.Trim = "ZR" Then
                        p_WhereUpdate = p_WhereUpdate & " and  LineID='" & p_DataTableHTTG.Rows(p_CountHTTG).Item("LineID").ToString.Trim & "'"
                        p_WhereUpdate = p_WhereUpdate & " and  MaLenh='" & p_DataTableHTTG.Rows(p_CountHTTG).Item("MaLenh").ToString.Trim & "'"
                    End If
                End If
                p_DataRow = p_DataTableWhere.NewRow
                p_DataRow(0) = p_WhereUpdate
                p_DataRow(1) = p_Where_Scadar
                If p_HangHoaE5 = True Then
                    p_DataRow(2) = "Y"
                    p_DataRow(3) = p_STT
                Else
                    p_DataRow(2) = "N"
                    p_DataRow(3) = p_STT
                End If
                p_DataTableWhere.Rows.Add(p_DataRow)
                'End If
Line_TT:
            Next

            'anhqh
            '20180819
            UpdateFromScadarToHTTG = BuildTbaleUpdateHTTG(g_LoaiVanChuyen, p_DataTableWhere, p_DataTableHTTG, p_Scadar, p_ScadarE5, p_SQL)
            p_desc = p_SQL
        Catch ex As Exception
            p_desc = ex.Message
            UpdateFromScadarToHTTG = True
        End Try
    End Function



    'anhqh 20150817
    'Ham thuc hien xu ly voi xang A92 xuat hong E5
    Private Function UpdateFromScadarToHTTG_A92(ByVal g_LoaiVanChuyen As String, ByVal p_DataRowMap_cp_E5() As DataRow, ByVal p_DataRowMap_cp_Old() As DataRow, ByVal p_DataTableHTTG As DataTable, _
                                                ByVal p_Scadar As DataTable, _
                                                ByVal p_ScadarE5 As DataTable) As Boolean
        Dim p_DataRow As DataRow
        Dim p_CountRow As Integer
        Dim p_CountHTTG As Integer
        Dim p_STT As Integer
        Dim p_DataRowMap_cp() As DataRow
        Dim p_HangHoaE5 As Boolean
        Dim p_MaHangHoa As String
        Dim p_DataRowHTTG As DataRow
        Dim p_DataRowHangHoa() As DataRow

        Dim p_DataRowScadar() As DataRow

        Dim p_WhereUpdate As String
        Dim p_SQLUpdate As String
        Dim p_Value As String
        Dim p_ValueScadar As String
        ' Dim p_FileName As String
        'Dim p_DataRowMap_cp As DataRow
        Dim p_TableID As String
        Dim p_DataTableCheckID As DataTable
        Dim p_SQL As String
        Dim p_ColumnType As String
        Dim p_FieldScadar As String
        Dim p_DataTableWhere As New DataTable("TblWhere")
        Dim p_Where_Scadar As String

        p_DataTableWhere.Columns.Add("STR_HTTG", GetType(String))
        p_DataTableWhere.Columns.Add("STR_SCADAR", GetType(String))
        p_DataTableWhere.Columns.Add("STR_TYPE", GetType(String))
        p_DataTableWhere.Columns.Add("STT", GetType(String))

        UpdateFromScadarToHTTG_A92 = False
        If p_DataTableHTTG Is Nothing Then

            Exit Function
        End If
        If p_DataTableHTTG.Rows.Count <= 0 Then
            Exit Function
        End If




        Try
            p_DataTableWhere.Clear()
            For p_CountHTTG = 0 To p_DataTableHTTG.Rows.Count - 1
                p_WhereUpdate = ""
                p_SQLUpdate = ""
                p_Where_Scadar = ""

                p_DataRowHTTG = p_DataTableHTTG.Rows(p_CountHTTG)
                p_HangHoaE5 = True
                p_MaHangHoa = p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                'p_DataRowHangHoa = g_TableMaHangHoaE5.Select("MaHangHoa_Scada='" & p_MaHangHoa & "'")
                'If p_DataRowHangHoa.Length > 0 Then

                If p_HangHoaE5 = True Then
                    'End If
                    p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    p_HangHoaE5 = True
                    If p_DataRowMap_cp.Length <= 0 Then
                        Exit Function
                    End If
                Else
                    p_STT = p_DataRowMap_cp_Old(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    If p_DataRowMap_cp.Length <= 0 Then
                        Exit Function
                    End If
                End If

                For p_CountRow = 0 To p_DataRowMap_cp.Length - 1
                    p_ColumnType = ""
                    p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).ToString.Trim


                    If (UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") Or UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" Then
                            p_ValueScadar = p_Value.Substring(1, g_MaNgan_DD)
                        Else
                            p_ValueScadar = p_Value
                        End If
                        '==================================================================================================
                        If p_Where_Scadar.ToString.Trim = "" Then
                            'Doan lay Where cho Scadar
                            If p_HangHoaE5 = True Then
                                If p_ScadarE5 Is Nothing Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))   ' UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(p_ColumnType)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_Where_Scadar = p_FieldScadar & "=" & p_ValueScadar & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        p_Where_Scadar = p_FieldScadar & "='" & p_ValueScadar.ToString.Trim & "'"
                                    Case UCase("String")
                                        p_Where_Scadar = p_FieldScadar & "='" & p_ValueScadar & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select

                            Else
                                If p_Scadar Is Nothing Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))  ' UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))  ' UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))  'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(p_ColumnType)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_Where_Scadar = p_FieldScadar & "=" & p_ValueScadar & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        p_Where_Scadar = p_FieldScadar & "='" & p_ValueScadar.ToString.Trim & "'"
                                    Case UCase("String")
                                        p_Where_Scadar = p_FieldScadar & "='" & p_ValueScadar & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select
                            End If
                        Else
                            'Doan lay Where cho Scadar
                            If p_HangHoaE5 = True Then
                                If p_ScadarE5 Is Nothing Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(p_ColumnType)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "=" & p_ValueScadar & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar.ToString.Trim & "'"
                                    Case UCase("String")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select

                            Else
                                If p_Scadar Is Nothing Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))  ' UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))  ' UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))  'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(p_ColumnType)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "=" & p_ValueScadar & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar.ToString.Trim & "'"
                                    Case UCase("String")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select
                            End If


                        End If
                        '==================================================================================================
                        If p_WhereUpdate.ToString.Trim = "" Then
                            Select Case UCase(p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).GetType.Name)
                                Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "=" & p_Value & ""
                                Case UCase("DateTime"), UCase("Date")
                                    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                Case UCase("String")
                                    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                Case Else
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                            End Select


                            'Continue For
                        Else
                            Select Case UCase(p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).GetType.Name)
                                Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "=" & p_Value & ""
                                Case UCase("DateTime"), UCase("Date")
                                    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                Case UCase("String")
                                    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                Case Else
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                            End Select
                        End If
                        Continue For
                    End If

                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                        If p_WhereUpdate.ToString.Trim = "" Then
                            'p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                            'p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
                            p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                        Else
                            p_WhereUpdate = p_WhereUpdate & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            'p_Where_Update = p_Where_Update & "  AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
                        End If
                        Continue For
                    End If

                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                        ' p_WhereUpdate = p_WhereUpdate

                        p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
                        p_TableID = p_Value
                        ' If g_MaTuDongHoa = "N" Then
                        If p_TableID.ToString.Trim <> "" Then


                        Else
                            'H_TableID
                            p_Value = p_DataRowHTTG.Item("H_TableID").ToString.Trim
                            p_TableID = p_Value
                        End If

                        If p_TableID.ToString.Trim <> "" Then
                            ' p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_TableID & "','" & _
                            'p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"

                            'anhqh
                            '20160704
                            'themdieu kien cho KV1
                            If GetScadarWagonKV1() = True Then
                                p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & IIf(UCase(g_LoaiVanChuyen) = "SAT", "ZR", "AB") & "'"
                            Else
                                p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                            End If


                            'anhqh  20160623  Sua them dung rieng cho KV1   FPT_GetMaTuDongHoa_KV1
                            'If g_Company_Code = "2110" Then
                            '    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                            '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & GetMaVanChuyenLenhXuat(p_SoLenh) & "'"
                            'Else
                            '    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                            '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                            'End If
                            p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    p_TableID = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                                End If
                            End If
                        End If
                        p_ValueScadar = p_TableID
                        '========================================================================================
                        If p_Where_Scadar.ToString.Trim = "" Then
                            If p_HangHoaE5 = True Then
                                If p_ScadarE5 Is Nothing Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim)) 'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim)) 'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim)) 'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(p_ColumnType)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_Where_Scadar = p_FieldScadar & "=" & p_ValueScadar & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        p_Where_Scadar = p_FieldScadar & "='" & p_ValueScadar.ToString.Trim & "'"
                                    Case UCase("String")
                                        p_Where_Scadar = p_FieldScadar & "='" & p_ValueScadar & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select

                            Else
                                If p_Scadar Is Nothing Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))  'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))  'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))  'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(p_ColumnType)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_Where_Scadar = p_FieldScadar & "=" & p_ValueScadar & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        p_Where_Scadar = p_FieldScadar & "='" & p_ValueScadar.ToString.Trim & "'"
                                    Case UCase("String")
                                        p_Where_Scadar = p_FieldScadar & "='" & p_ValueScadar & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select
                            End If
                        Else
                            If p_HangHoaE5 = True Then
                                If p_ScadarE5 Is Nothing Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))   'UCase(p_ScadarE5.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(p_ColumnType)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "=" & p_ValueScadar & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar.ToString.Trim & "'"
                                    Case UCase("String")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select

                            Else
                                If p_Scadar Is Nothing Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))   ' UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                                    Case "THUY"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))  'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                                    Case "SAT"
                                        p_ColumnType = GetCoumnTypeTable(p_Scadar.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))   'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                        p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select
                                If p_ColumnType = "" Then
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                                End If
                                Select Case UCase(p_ColumnType)
                                    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "=" & p_ValueScadar & ""
                                    Case UCase("DateTime"), UCase("Date")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar.ToString.Trim & "'"
                                    Case UCase("String")
                                        p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar & "'"
                                    Case Else
                                        UpdateFromScadarToHTTG_A92 = True
                                        Exit Function
                                End Select
                            End If
                        End If
                        '========================================================================================
                        If p_WhereUpdate.ToString.Trim = "" Then
                            Select Case UCase(p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).GetType.Name)
                                Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "=" & p_Value & ""
                                Case UCase("DateTime"), UCase("Date")
                                    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                Case UCase("String")
                                    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                Case Else
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                            End Select
                            ' Continue For
                        Else
                            Select Case UCase(p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).GetType.Name)
                                Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "=" & p_Value & ""
                                Case UCase("DateTime"), UCase("Date")
                                    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                Case UCase("String")
                                    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                Case Else
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                            End Select




                        End If


                        Continue For
                    End If
                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MATUDONGHOA" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                        p_Value = p_Value
                        If p_ScadarE5 Is Nothing Then
                            UpdateFromScadarToHTTG_A92 = True
                            Exit Function
                        End If
                        p_ValueScadar = p_DataRowHTTG.Item("MATUDONGHOA").ToString.Trim
                        Select Case UCase(g_LoaiVanChuyen)
                            Case "BO"
                                p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim))   ' UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).GetType.Name)
                                p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim
                            Case "THUY"
                                p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim))  'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).GetType.Name)
                                p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim
                            Case "SAT"
                                p_ColumnType = GetCoumnTypeTable(p_ScadarE5.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim))   'UCase(p_Scadar.Rows(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).GetType.Name)
                                p_FieldScadar = p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim
                            Case Else
                                UpdateFromScadarToHTTG_A92 = True
                                Exit Function
                        End Select
                        If p_ColumnType = "" Then
                            UpdateFromScadarToHTTG_A92 = True
                            Exit Function
                        End If
                        If p_Where_Scadar.ToString.Trim = "" Then
                            Select Case UCase(p_ColumnType)
                                Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                    p_Where_Scadar = p_FieldScadar & "=" & p_ValueScadar & ""
                                Case UCase("DateTime"), UCase("Date")
                                    p_Where_Scadar = p_FieldScadar & "='" & CDate(p_ValueScadar).ToString("yyyy/MM/dd") & "'"
                                Case UCase("String")
                                    p_Where_Scadar = p_FieldScadar & "='" & p_ValueScadar & "'"
                                Case Else
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                            End Select
                        Else
                            Select Case UCase(p_ColumnType)
                                Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                    p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "=" & p_ValueScadar & ""
                                    'Case UCase("DateTime"), UCase("Date")
                                    '    p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar.ToString.Trim & "'"
                                Case UCase("String")
                                    p_Where_Scadar = p_Where_Scadar & " AND " & p_FieldScadar & "='" & p_ValueScadar & "'"
                                Case Else
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                            End Select

                        End If

                        '========================================================================================
                        If p_WhereUpdate.ToString.Trim = "" Then
                            Select Case UCase(p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).GetType.Name)
                                Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "=" & p_ValueScadar & ""
                                    'Case UCase("DateTime"), UCase("Date")
                                    '    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_ValueScadar).ToString("yyyyMMdd") & "'"
                                Case UCase("String")
                                    p_WhereUpdate = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_ValueScadar & "'"
                                Case Else
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                            End Select
                            ' Continue For
                        Else
                            Select Case UCase(p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).GetType.Name)
                                Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "=" & p_ValueScadar & ""
                                    'Case UCase("DateTime"), UCase("Date")
                                    '    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_ValueScadar).ToString("yyyyMMdd") & "'"
                                Case UCase("String")
                                    p_WhereUpdate = p_WhereUpdate & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_ValueScadar & "'"
                                Case Else
                                    UpdateFromScadarToHTTG_A92 = True
                                    Exit Function
                            End Select
                        End If
                        Continue For
                    End If

                Next

                If p_WhereUpdate.ToString.Trim = "" Or p_Where_Scadar.ToString.Trim = "" Then
                    UpdateFromScadarToHTTG_A92 = True
                    Exit Function
                End If
                'If p_WhereUpdate.ToString.Trim <> "" Then
                p_DataRow = p_DataTableWhere.NewRow
                p_DataRow(0) = p_WhereUpdate
                p_DataRow(1) = p_Where_Scadar
                If p_HangHoaE5 = True Then
                    p_DataRow(2) = "Y"
                    p_DataRow(3) = p_STT
                Else
                    p_DataRow(2) = "N"
                    p_DataRow(3) = p_STT
                End If
                p_DataTableWhere.Rows.Add(p_DataRow)
                'End If

            Next

            UpdateFromScadarToHTTG_A92 = BuildTbaleUpdateHTTG(g_LoaiVanChuyen, p_DataTableWhere, p_DataTableHTTG, p_Scadar, p_ScadarE5, p_SQL)

        Catch ex As Exception
            UpdateFromScadarToHTTG_A92 = True
        End Try
    End Function


    Private Function GetCoumnTypeTable(ByVal p_Column As DataColumn) As String
        GetCoumnTypeTable = ""
        Try
            GetCoumnTypeTable = p_Column.DataType.Name.ToString.Trim
        Catch ex As Exception
            GetCoumnTypeTable = ""
        End Try

    End Function




    Private Function BuildTbaleUpdateHTTG(ByVal g_LoaiVanChuyen As String, _
                                                ByVal p_DataTableWhere As DataTable, _
                                                ByVal p_DataTableHTTG As DataTable, _
                                                ByVal p_Scadar As DataTable, _
                                                ByVal p_ScadarE5 As DataTable, _
                                                ByRef p_Desc As String) As Boolean
        Dim p_Count As Integer
        Dim p_ArrayRow() As DataRow
        Dim p_DataRowMap_cp() As DataRow
        Dim p_CurrentRow As DataRow
        Dim p_DataTableExe As New DataTable("Table01")
        Dim p_SQL As String
        Dim p_FieldName As String
        Dim p_FieldType As String
        Dim p_Value As String
        Dim p_CountRow As Integer
        Dim p_HangHoaE5 As Boolean
        Dim p_ColumnType As String
        Dim p_STT As Integer
        Dim p_NhietDo As String
        Dim p_TyTrongTT As String
        Dim p_TyTrongUpd As String
        Dim p_TyTrong As String
        Dim p_ValueNumber As Double
        Dim cl_HTTG_COMMON As New HTTG_COMMON.CL_HTTG_COMMON

        Try
            BuildTbaleUpdateHTTG = False

            p_DataTableExe.Columns.Add("STR_SQL", GetType(String))

            Dim p_Date As Date
            Dim p_Time As Integer
            p_GetDateTime(p_Date, p_Time)

            For p_Count = 0 To p_DataTableWhere.Rows.Count - 1
                p_SQL = ""
                p_CurrentRow = p_DataTableWhere.Rows(p_Count)
                p_STT = p_CurrentRow.Item("STT").ToString.Trim
                If p_CurrentRow.Item("STR_TYPE").ToString.Trim = "Y" Then
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)

                    If p_DataRowMap_cp.Length <= 0 Then
                        BuildTbaleUpdateHTTG = True
                        Exit Function
                    End If
                    'anhqh 20251104
                    If Not p_ScadarE5 Is Nothing Then
                        p_ArrayRow = p_ScadarE5.Select(p_CurrentRow.Item("STR_SCADAR").ToString.Trim)
                        p_HangHoaE5 = True
                    End If
                    
                Else
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    If p_DataRowMap_cp.Length <= 0 Then
                        BuildTbaleUpdateHTTG = True
                        Exit Function
                    End If
                    p_ArrayRow = p_Scadar.Select(p_CurrentRow.Item("STR_SCADAR").ToString.Trim)
                    p_HangHoaE5 = False
                End If
                If p_ArrayRow.Length <= 0 Then

                    'anhqh
                    '20160927
                    Continue For
                    ' BuildTbaleUpdateHTTG = True
                    'Exit Function
                End If
                p_NhietDo = ""
                p_TyTrongTT = ""

                For p_CountRow = 0 To p_DataRowMap_cp.Length - 1
                    p_ColumnType = ""
                    p_FieldName = ""
                    p_Value = ""

                    'If p_CountRow = 35 Then
                    '    p_Value = p_Value
                    'End If
                    If (UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") Or UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN") Then
                        Continue For
                    End If

                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                        Continue For
                    End If

                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" Then
                        Continue For
                    End If
                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MATUDONGHOA" Then
                        Continue For
                    End If

                    If p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim.ToString.Trim = "" _
                            And p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim = "" _
                            And p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim = "" Then
                        Continue For
                    End If

                    p_ColumnType = ""
                    p_ColumnType = GetCoumnTypeTable(p_DataTableHTTG.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim))  ' p_DataTableHTTG.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).DataType.Name.Trim
                    p_FieldName = p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim



                    If p_HangHoaE5 = True Then
                        If UCase(p_FieldName) = UCase("NhietDo") Then
                            Select Case UCase(g_LoaiVanChuyen)
                                Case "BO"
                                    p_NhietDo = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).ToString.Trim
                                Case "THUY"
                                    p_NhietDo = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).ToString.Trim
                                Case "SAT"
                                    p_NhietDo = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).ToString.Trim
                            End Select
                        End If
                        If UCase(p_FieldName) = UCase("TyTrong_15") Then
                            Select Case UCase(g_LoaiVanChuyen)
                                Case "BO"
                                    p_TyTrongTT = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).ToString.Trim
                                Case "THUY"
                                    p_TyTrongTT = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).ToString.Trim
                                Case "SAT"
                                    p_TyTrongTT = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).ToString.Trim
                            End Select
                            Continue For
                        End If
                    End If

                    If UCase(p_FieldName) = UCase("Flag1") Then
                        Continue For
                    End If


                    If UCase(p_FieldName) = UCase("Sl_llkebd") Or UCase(p_FieldName) = UCase("Sl_llkekt") Then
                        p_FieldName = p_FieldName
                    End If


                    ' If p_HangHoaE5 = True Then
                    'p_FieldName = p_DataRowMap_cp(p_CountRow).Item("").ToString

                    If UCase(p_ColumnType) = UCase("Int32") Or UCase(p_ColumnType) = UCase("Single") Or _
                          UCase(p_ColumnType) = UCase("Double") Or UCase(p_ColumnType) = UCase("byte") Or UCase(p_ColumnType) = UCase("decimal") Then

                        'Dim p_Temp As Long

                        'Dim p_aaa As Decimal
                        'Dim p_ggg As Double

                        ' p_Temp = 0
                        Select Case UCase(g_LoaiVanChuyen)

                            Case "BO"
                                'p_ValueNumber = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim) ' p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).ToString.Trim
                                If p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).ToString.Trim = "" Then
                                    p_ValueNumber = 0
                                Else
                                    p_ValueNumber = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim)
                                    ' Double.TryParse(p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim), p_ValueNumber)
                                End If
                                '  p_ValueNumber = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim)

                                ' Double.TryParse(p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).ToString.Trim, p_ValueNumber)
                                'p_Temp = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim)
                                ''Decimal.TryParse(p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).ToString.Trim, p_ValueNumber)
                                'p_aaa = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim)
                                'p_ggg = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim)
                                p_Value = p_ValueNumber.ToString
                            Case "THUY"
                                'p_ValueNumber = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).ToString.Trim
                                'Double.TryParse(p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).ToString.Trim, p_ValueNumber)
                                If p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).ToString.Trim = "" Then
                                    p_ValueNumber = 0
                                Else
                                    p_ValueNumber = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim)
                                End If
                                p_Value = p_ValueNumber.ToString
                            Case "SAT"
                                'p_ValueNumber = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).ToString.Trim
                                'Double.TryParse(p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).ToString.Trim, p_ValueNumber)
                                If p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).ToString.Trim = "" Then
                                    p_ValueNumber = 0
                                Else
                                    p_ValueNumber = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim)
                                End If
                                p_Value = p_ValueNumber.ToString
                            Case Else
                                BuildTbaleUpdateHTTG = True
                                Exit Function
                        End Select
                    Else
                        Select Case UCase(g_LoaiVanChuyen)

                            Case "BO"
                                p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).ToString.Trim
                            Case "THUY"
                                p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).ToString.Trim
                            Case "SAT"
                                p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).ToString.Trim
                            Case Else
                                BuildTbaleUpdateHTTG = True
                                Exit Function
                        End Select

                    End If

                    'Select Case UCase(g_LoaiVanChuyen)

                    '    Case "BO"
                    '        p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).ToString.Trim
                    '    Case "THUY"
                    '        p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).ToString.Trim
                    '    Case "SAT"
                    '        p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).ToString.Trim
                    '    Case Else
                    '        BuildTbaleUpdateHTTG = True
                    '        Exit Function
                    'End Select
                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim) = UCase("ThoiGianDau") Or _
                            UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim) = UCase("ThoiGianCuoi") Then

                        Select Case UCase(g_LoaiVanChuyen)
                            Case "BO"
                                p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).ToString.Trim
                            Case "THUY"
                                p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).ToString.Trim
                            Case "SAT"
                                p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).ToString.Trim
                            Case Else
                                BuildTbaleUpdateHTTG = True
                                Exit Function
                        End Select
                        If p_Value.ToString.Trim = "" Then
                            p_Value = p_Date
                        End If

                    End If
                    'Else
                    '    Select Case UCase(g_LoaiVanChuyen)
                    '        Case "BO"
                    '            p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).ToString.Trim
                    '        Case "THUY"
                    '            p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).ToString.Trim
                    '        Case "SAT"
                    '            p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).ToString.Trim
                    '        Case Else
                    '            BuildTbaleUpdateHTTG = True
                    '            Exit Function
                    '    End Select
                    'End If

                    If UCase(p_FieldName) = UCase("BeXuat") Then
                        p_FieldName = p_FieldName
                    Else
                        If p_Value.ToString.Trim = "" Then
                            Continue For
                        End If

                    End If




                    If p_ColumnType = "" Then
                        BuildTbaleUpdateHTTG = True
                        Exit Function
                    End If
                    'If p_CountRow = 68 Then
                    '    MsgBox("dfdf")
                    'End If



                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MALUULUONGKE" And p_HangHoaE5 = True Then
                        Continue For
                    End If

                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("SoLuongThucXuat") And p_Value.ToString.Trim <> "" Then
                        p_Value = Math.Round(CDbl(p_Value), 0, MidpointRounding.AwayFromZero)     ' Math.Round(CDbl(p_Value), 0)
                    End If

                    'anhqh===========================================================================
                    '20171025
                    'THem doan lam tron cho L15
                    'Try
                    '    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("GST") And p_Value.ToString.Trim <> "" Then
                    '        p_Value = Math.Round(CDbl(p_Value), 0, MidpointRounding.AwayFromZero)     ' Math.Round(CDbl(p_Value), 0)
                    '    End If

                    '    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("AVG_CTL") And p_Value.ToString.Trim <> "" Then
                    '        p_Value = Math.Round(CDbl(p_Value), 4, MidpointRounding.AwayFromZero)     ' Math.Round(CDbl(p_Value), 0)
                    '    End If

                    'Catch ex As Exception

                    'End Try

                    '===========================================================================================================================



                    Select Case UCase(p_ColumnType)
                        Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                            p_SQL = p_SQL & "," & p_FieldName & "=" & CDbl(p_Value) & ""
                        Case UCase("DateTime"), UCase("Date")
                            p_SQL = p_SQL & "," & p_FieldName & "='" & CDate(p_Value).ToString("yyyyMMdd hh:mm:ss tt") & "'"
                        Case UCase("String")
                            p_SQL = p_SQL & "," & p_FieldName & "='" & p_Value & "'"
                        Case Else
                            BuildTbaleUpdateHTTG = True
                            Exit Function
                    End Select

                    'anhqh
                    '20160819

                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MA_HONG" And p_HangHoaE5 = True Then
                        p_Value = getMeter_E5(p_Value)
                        p_SQL = p_SQL & ",MaLuuLuongKe='" & p_Value & "'"
                    End If




                Next

                cl_HTTG_COMMON.getSYS_CONFIG()
                If p_HangHoaE5 = True And (cl_HTTG_COMMON.g_LMS.ToString = "N" Or cl_HTTG_COMMON.g_LMS.ToString = "") Then
                    p_Value = mdlQCI_GetD15_NS(p_HangHoaE5, p_NhietDo, p_TyTrongTT)
                    p_ColumnType = p_DataTableHTTG.Columns.Item("TyTrong_15").DataType.Name.Trim
                    Select Case UCase(p_ColumnType)
                        Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                            p_SQL = p_SQL & ",TyTrong_15=" & p_Value & ""
                        Case UCase("DateTime"), UCase("Date")
                            p_SQL = p_SQL & ",TyTrong_15='" & CDate(p_Value).ToString("yyyyMMdd hh:mm:ss tt") & "'"
                        Case UCase("String")
                            p_SQL = p_SQL & ",TyTrong_15='" & p_Value & "'"
                        Case Else
                            BuildTbaleUpdateHTTG = True
                            Exit Function
                    End Select
                Else

                    'anhqh
                    '20160704
                    'Truong hop KV1 thi co them truong hop wagon
                    If GetScadarWagonKV1() = True Then

                        'Select Case UCase(g_LoaiVanChuyen)
                        '    Case "SAT"
                        '        p_TyTrongUpd = ",TyTrong_15= isnull( (select (select top 1 Dens_nd from FPT_tblTankActive_V bb " & _
                        '         "where Date1 =CONVERT(date,getdate()) and Name_nd =aa.BeXuat  )  " & _
                        '               " from FPT_tblLenhXuatChiTietE5_V aa where exists (select 1 from fpt_tblLenhXuat_hangHoaE5_V aa1 , FPT_tblLenhXuatE5_V aa2 " & _
                        '                       " where(aa1.TableID = aa.TableID And aa1.NgayXuat = aa.NgayXuat And aa.SoLenh = aa1.SoLenh  " & _
                        '                          " and aa1.SoLenh=aa2.SoLenh and aa2.MaVanChuyen ='ZR' )) and " & p_CurrentRow.Item("STR_HTTG").ToString.Trim & "),0)"
                        '    Case "THUY"
                        '        p_TyTrongUpd = ",TyTrong_15= isnull( (select (select top 1 Dens_nd from FPT_tblTankActive_V bb " & _
                        '         "where Date1 =CONVERT(date,getdate()) and Name_nd =aa.BeXuat  )  " & _
                        '               " from FPT_tblLenhXuatChiTietE5_V aa where exists (select 1 from fpt_tblLenhXuat_hangHoaE5_V aa1 , FPT_tblLenhXuatE5_V aa2 " & _
                        '                       " where(aa1.TableID = aa.TableID And aa1.NgayXuat = aa.NgayXuat And aa.SoLenh = aa1.SoLenh  " & _
                        '                          " and aa1.SoLenh=aa2.SoLenh and aa2.MaVanChuyen  in ('ZB','ZM'))) and " & p_CurrentRow.Item("STR_HTTG").ToString.Trim & "),0)"
                        '    Case Else
                        '        p_TyTrongUpd = ",TyTrong_15= isnull( (select (select top 1 Dens_nd from FPT_tblTankActive_V bb " & _
                        '         "where Date1 =CONVERT(date,getdate()) and Name_nd =aa.BeXuat  )  " & _
                        '               " from FPT_tblLenhXuatChiTietE5_V aa where exists (select 1 from fpt_tblLenhXuat_hangHoaE5_V aa1 , FPT_tblLenhXuatE5_V aa2 " & _
                        '                       " where(aa1.TableID = aa.TableID And aa1.NgayXuat = aa.NgayXuat And aa.SoLenh = aa1.SoLenh  " & _
                        '                          " and aa1.SoLenh=aa2.SoLenh and aa2.MaVanChuyen ='ZT' )) and " & p_CurrentRow.Item("STR_HTTG").ToString.Trim & "),0)"
                        'End Select



                    Else
                        p_TyTrongUpd = ",TyTrong_15= isnull( (select (select top 1 Dens_nd from FPT_tblTankActive_V bb " & _
                                  "where Date1 =CONVERT(date,getdate()) and Name_nd =aa.BeXuat  )  " & _
                                        " from FPT_tblLenhXuatChiTietE5_V aa where " & p_CurrentRow.Item("STR_HTTG").ToString.Trim & "),0)"
                    End If
                    'p_TyTrongUpd = ",TyTrong_15= isnull( (select (select top 1 Dens_nd from FPT_tblTankActive_V bb " & _
                    '          "where Date1 =CONVERT(date,getdate()) and Name_nd =aa.BeXuat  )  " & _
                    '                " from FPT_tblLenhXuatChiTietE5_V aa where " & p_CurrentRow.Item("STR_HTTG").ToString.Trim & "),0)"
                    If p_SQL <> "" Then
                        p_SQL = p_SQL & p_TyTrongUpd
                    End If
                End If


                If p_SQL <> "" Then
                    p_SQL = Mid(p_SQL, 2)
                    p_SQL = "UPDATE tblLenhXuatChiTietE5 Set  " & p_SQL & " Where " & p_CurrentRow.Item("STR_HTTG").ToString.Trim
                    p_CurrentRow = p_DataTableExe.NewRow
                    p_CurrentRow(0) = p_SQL
                    p_DataTableExe.Rows.Add(p_CurrentRow)
                End If
            Next


            If p_DataTableExe.Rows.Count > 0 Then
                If g_DBTYPE = "ORACLE" Then
                    If g_Services.Sys_Execute_DataTbl_Oracle(p_DataTableExe, p_SQL) = False Then
                        'MsgBox(p_SQL)
                        p_Desc = p_SQL
                        ' ShowMessageBox("", p_Desc)
                        BuildTbaleUpdateHTTG = True
                        Exit Function
                    Else
                    End If
                ElseIf g_DBTYPE = "SQL" Then

                    'p_SQL = "UPDATE tblLenhXuatE5 Set  " & p_SQL & " Where " & p_CurrentRow.Item("STR_HTTG").ToString.Trim
                    'p_CurrentRow = p_DataTableExe.NewRow
                    'p_CurrentRow(0) = p_SQL
                    'p_DataTableExe.Rows.Add(p_CurrentRow)

                    If g_Services.Sys_Execute_DataTbl(p_DataTableExe, p_SQL) = False Then
                        'MsgBox(p_SQL)
                        p_Desc = p_SQL
                        ' ShowMessageBox("", p_Desc)
                        BuildTbaleUpdateHTTG = True
                        Exit Function

                    End If
                End If
            End If


        Catch ex As Exception
            p_Desc = "BuildTbaleUpdateHTTG:" & ex.Message
            BuildTbaleUpdateHTTG = True
        End Try
    End Function



    '    Public Function RoundNumber(ByVal p_FIeld As String, ByVal p_Value As String) As Double
    '        Dim p_DataRow() As DataRow
    '        Dim p_Decima As Integer
    '        Try

    '            If p_Value.ToString.Trim = "" Then
    '                Return 0
    '            End If

    '            If IsNumeric(p_Value) Then
    '                p_DataRow = g_ConfigDecima.Select("ClolumnName='" & p_FIeld & "'")
    '                If p_DataRow.Length <= 0 Then
    '                    Return CDbl(p_Value)
    '                End If

    '                If p_DataRow(0).Item("DecimaNumber").ToString.Trim = "" Then
    '                    Return CDbl(p_Value)
    '                End If
    '                p_Decima = p_DataRow(0).Item("DecimaNumber").ToString.Trim()

    '                Return Math.Round(CDbl(p_Value), p_Decima)
    '            Else
    '                Return 0
    '            End If
    '        Catch ex As Exception
    '            Return CDbl(p_Value)
    '        End Try
    '    End Function



    'g_c2sql = New Connect2SQL.Connect2SQL(_SQLConnectionString)
    '            l_str = "select * from tblDecimaNumberE5 with (Nolock) "
    '            g_ConfigDecima = g_c2sql.getTableValue(l_str)


    Private Function getMeter_E5(ByVal p_HongXuat As String) As String
        Dim p_SQL As String = ""
        Dim p_Table As DataTable
        Try
            If p_HongXuat = "" Then
                Return ""
            End If

            p_SQL = "exec FPT_GetMeter_E5  " & p_HongXuat
            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    Return p_Table.Rows(0).Item("MeterID").ToString.Trim
                End If
            End If
            Return p_HongXuat
        Catch ex As Exception
            Return ""
        End Try

    End Function



    Private Function BuildTbaleUpdateHTTG_A92(ByVal g_LoaiVanChuyen As String, _
                                                ByVal p_DataTableWhere As DataTable, _
                                                ByVal p_DataTableHTTG As DataTable, _
                                                ByVal p_Scadar As DataTable, _
                                                ByVal p_ScadarE5 As DataTable, _
                                                ByRef p_Desc As String) As Boolean
        Dim p_Count As Integer
        Dim p_ArrayRow() As DataRow
        Dim p_DataRowMap_cp() As DataRow
        Dim p_CurrentRow As DataRow
        Dim p_DataTableExe As New DataTable("Table01")
        Dim p_SQL As String
        Dim p_FieldName As String
        Dim p_FieldType As String
        Dim p_Value As String
        Dim p_CountRow As Integer
        Dim p_HangHoaE5 As Boolean
        Dim p_ColumnType As String
        Dim p_STT As Integer
        Dim p_NhietDo As String
        Dim p_TyTrongTT As String
        Dim p_TyTrongUpd As String
        Dim p_TyTrong As String
        Try
            BuildTbaleUpdateHTTG_A92 = False


            '     Exit Function

            p_DataTableExe.Columns.Add("STR_SQL", GetType(String))

            Dim p_Date As Date
            p_GetCurrentDate(p_Date)

            For p_Count = 0 To p_DataTableWhere.Rows.Count - 1
                p_SQL = ""
                p_CurrentRow = p_DataTableWhere.Rows(p_Count)
                p_STT = p_CurrentRow.Item("STT").ToString.Trim
                If p_CurrentRow.Item("STR_TYPE").ToString.Trim = "Y" Then
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)

                    If p_DataRowMap_cp.Length <= 0 Then
                        BuildTbaleUpdateHTTG_A92 = True
                        Exit Function
                    End If
                    p_ArrayRow = p_ScadarE5.Select(p_CurrentRow.Item("STR_SCADAR").ToString.Trim)
                    p_HangHoaE5 = True
                Else
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    If p_DataRowMap_cp.Length <= 0 Then
                        BuildTbaleUpdateHTTG_A92 = True
                        Exit Function
                    End If
                    p_ArrayRow = p_Scadar.Select(p_CurrentRow.Item("STR_SCADAR").ToString.Trim)
                    p_HangHoaE5 = False
                End If
                If p_ArrayRow.Length <= 0 Then
                    BuildTbaleUpdateHTTG_A92 = True
                    Exit Function
                End If
                p_NhietDo = ""
                p_TyTrongTT = ""

                For p_CountRow = 0 To p_DataRowMap_cp.Length - 1
                    p_ColumnType = ""
                    p_FieldName = ""
                    p_Value = ""


                    If (UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") Or UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN") Then
                        Continue For
                    End If

                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                        Continue For
                    End If

                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" Then
                        Continue For
                    End If
                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MATUDONGHOA" Then
                        Continue For
                    End If



                    If p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim.ToString.Trim = "" _
                            And p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim = "" _
                            And p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim = "" Then
                        Continue For
                    End If

                    p_ColumnType = ""
                    p_ColumnType = GetCoumnTypeTable(p_DataTableHTTG.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim))  ' p_DataTableHTTG.Columns.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim).DataType.Name.Trim
                    p_FieldName = p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim
                    If p_HangHoaE5 = True Then
                        If UCase(p_FieldName) = UCase("NhietDo") Then
                            Select Case UCase(g_LoaiVanChuyen)
                                Case "BO"
                                    p_NhietDo = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).ToString.Trim
                                Case "THUY"
                                    p_NhietDo = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).ToString.Trim
                                Case "SAT"
                                    p_NhietDo = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).ToString.Trim
                            End Select
                        End If
                        If UCase(p_FieldName) = UCase("TyTrong_15") Then
                            Select Case UCase(g_LoaiVanChuyen)
                                Case "BO"
                                    p_TyTrongTT = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).ToString.Trim
                                Case "THUY"
                                    p_TyTrongTT = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).ToString.Trim
                                Case "SAT"
                                    p_TyTrongTT = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).ToString.Trim
                            End Select
                            Continue For
                        End If
                    End If

                    If UCase(p_FieldName) = UCase("Flag1") Then
                        Continue For
                    End If
                    ' If p_HangHoaE5 = True Then
                    'p_FieldName = p_DataRowMap_cp(p_CountRow).Item("").ToString
                    Select Case UCase(g_LoaiVanChuyen)
                        Case "BO"
                            p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).ToString.Trim
                        Case "THUY"
                            p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).ToString.Trim
                        Case "SAT"
                            p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).ToString.Trim
                        Case Else
                            BuildTbaleUpdateHTTG_A92 = True
                            Exit Function
                    End Select
                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim) = UCase("ThoiGianDau") Or _
                            UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim) = UCase("ThoiGianCuoi") Then
                        p_Value = p_Date
                    End If
                    'Else
                    '    Select Case UCase(g_LoaiVanChuyen)
                    '        Case "BO"
                    '            p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim).ToString.Trim
                    '        Case "THUY"
                    '            p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim).ToString.Trim
                    '        Case "SAT"
                    '            p_Value = p_ArrayRow(0).Item(p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim).ToString.Trim
                    '        Case Else
                    '            BuildTbaleUpdateHTTG = True
                    '            Exit Function
                    '    End Select
                    'End If
                    If p_Value.ToString.Trim = "" Then
                        Continue For
                    End If


                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("SoLuongThucXuat") And p_Value.ToString.Trim <> "" Then
                        p_Value = Math.Round(CDbl(p_Value), 0, MidpointRounding.AwayFromZero)
                    End If
                    'anhqh===========================================================================
                    '20171025
                    'THem doan lam tron cho L15
                    'Try
                    '    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("GST") And p_Value.ToString.Trim <> "" Then
                    '        p_Value = Math.Round(CDbl(p_Value), 0, MidpointRounding.AwayFromZero)     ' Math.Round(CDbl(p_Value), 0)
                    '    End If

                    '    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("AVG_CTL") And p_Value.ToString.Trim <> "" Then
                    '        p_Value = Math.Round(CDbl(p_Value), 4, MidpointRounding.AwayFromZero)     ' Math.Round(CDbl(p_Value), 0)
                    '    End If

                    'Catch ex As Exception

                    'End Try

                    '===========================================================================================================================



                    If p_ColumnType = "" Then
                        BuildTbaleUpdateHTTG_A92 = True
                        Exit Function
                    End If
                    Select Case UCase(p_ColumnType)
                        Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                            p_SQL = p_SQL & "," & p_FieldName & "=" & p_Value & ""
                        Case UCase("DateTime"), UCase("Date")
                            p_SQL = p_SQL & "," & p_FieldName & "='" & CDate(p_Value).ToString("yyyyMMdd hh:mm:ss tt") & "'"
                        Case UCase("String")
                            p_SQL = p_SQL & "," & p_FieldName & "='" & p_Value & "'"
                        Case Else
                            BuildTbaleUpdateHTTG_A92 = True
                            Exit Function
                    End Select
                Next

                If p_HangHoaE5 = True Then
                    p_Value = mdlQCI_GetD15_NS(p_HangHoaE5, p_NhietDo, p_TyTrongTT)
                    p_ColumnType = p_DataTableHTTG.Columns.Item("TyTrong_15").DataType.Name.Trim
                    Select Case UCase(p_ColumnType)
                        Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                            p_SQL = p_SQL & ",TyTrong_15=" & p_Value & ""
                        Case UCase("DateTime"), UCase("Date")
                            p_SQL = p_SQL & ",TyTrong_15='" & CDate(p_Value).ToString("yyyyMMdd hh:mm:ss tt") & "'"
                        Case UCase("String")
                            p_SQL = p_SQL & ",TyTrong_15='" & p_Value & "'"
                        Case Else
                            BuildTbaleUpdateHTTG_A92 = True
                            Exit Function
                    End Select
                Else
                    p_TyTrongUpd = ",TyTrong_15= isnull( (select (select top 1 Dens_nd from FPT_tblTankActive_V bb " & _
                              "where Date1 =CONVERT(date,getdate()) and Name_nd =aa.BeXuat  )  " & _
                                    " from FPT_tblLenhXuatChiTietE5_V aa where " & p_CurrentRow.Item("STR_HTTG").ToString.Trim & "),0)"
                    If p_SQL <> "" Then
                        p_SQL = p_SQL & p_TyTrongUpd
                    End If
                End If


                If p_SQL <> "" Then
                    p_SQL = Mid(p_SQL, 2)
                    p_SQL = "UPDATE tblLenhXuatChiTietE5 Set  " & p_SQL & " Where " & p_CurrentRow.Item("STR_HTTG").ToString.Trim
                    p_CurrentRow = p_DataTableExe.NewRow
                    p_CurrentRow(0) = p_SQL
                    p_DataTableExe.Rows.Add(p_CurrentRow)
                End If
            Next


            If p_DataTableExe.Rows.Count > 0 Then
                If g_DBTYPE = "ORACLE" Then
                    If g_Services.Sys_Execute_DataTbl_Oracle(p_DataTableExe, p_SQL) = False Then
                        'MsgBox(p_SQL)
                        p_Desc = p_SQL
                        ' ShowMessageBox("", p_Desc)
                        BuildTbaleUpdateHTTG_A92 = True
                        Exit Function
                    Else
                    End If
                ElseIf g_DBTYPE = "SQL" Then
                    If g_Services.Sys_Execute_DataTbl(p_DataTableExe, p_SQL) = False Then
                        'MsgBox(p_SQL)
                        p_Desc = p_SQL
                        ' ShowMessageBox("", p_Desc)
                        BuildTbaleUpdateHTTG_A92 = True
                        Exit Function

                    End If
                End If
            End If


        Catch ex As Exception
            p_Desc = "BuildTbaleUpdateHTTG:" & ex.Message
            BuildTbaleUpdateHTTG_A92 = True
        End Try
    End Function


    Private Sub SQLGetDataFromScadar_BK(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, ByRef p_Error As Boolean, ByRef p_Desc As String, _
                                    ByVal p_Terminal As String)
        Dim p_SQL As String
        Dim p_DataHTTG As DataTable
        Dim p_CountRow As Integer
        Dim p_CountCol As Integer
        Dim p_Count As Integer
        Dim p_DataRowHTTG As DataRow
        Dim p_SQLInsert As String = ""
        Dim p_SQLValue As String = ""
        Dim p_DataRowMap_cp() As DataRow
        Dim p_FieldType As String

        Dim p_Value As String
        Dim p_TableName As String = ""
        Dim p_STT As Integer
        Dim p_InsertTable As String = ""
        Dim p_ValueTable As String = ""
        Dim p_StrExe As String
        Dim p_TableExec As New DataTable("Table01")
        Dim p_DataRow As DataRow
        Dim p_DataTableCheckID As DataTable
        Dim p_Where_Check As String  'Dung checkScadar

        Dim p_Where_Update As String  'Dung de update HTTG
        Dim p_TableIDHTTG As String

        Dim p_TableName_E5 As String = ""
        Dim p_DataRowMap_cp_E5() As DataRow
        Dim p_DataRowMap_cp_Old() As DataRow
        Dim p_InsertTable_E5 As String = ""
        Dim p_ValueTable_E5 As String = ""
        Dim p_TableExec_E5 As New DataTable("Table02")
        Dim p_MaHangHoa As String
        Dim p_HangHoaE5 As Boolean
        Dim p_TyleE5 As Double
        Dim p_TyTrongNenE5 As Double
        Dim p_TyTrongEthanolE5 As Double
        Dim p_StrExeE5 As String
        Dim p_Flag() As String
        'Dim p_DataRowHangHoaE5() As DataRow
        Dim p_Value_HTTG As String

        p_TableExec.Columns.Add("SQL_STR", GetType(String))
        p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
        If g_DataMap_cp Is Nothing Then
            Exit Sub
        End If
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "') and (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "' )")
        If p_DataRowMap_cp_Old.Length <= 0 Then
            Exit Sub
        End If


        If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
            p_TableName = p_DataRowMap_cp_Old(0).Item("TableName").ToString.Trim
        End If
        If UCase(g_LoaiVanChuyen) = "THUY" Then
            p_TableName = p_DataRowMap_cp_Old(0).Item("TableName_Thuy").ToString.Trim
        End If
        If p_DataRowMap_cp_E5.Length > 0 Then
            p_TableName_E5 = p_DataRowMap_cp_E5(0).Item("TableName").ToString.Trim
        End If

        If p_TableName = "" Then
            Exit Sub
        End If
        p_Error = False
        p_Desc = ""
        If g_ConnectToScadar.ToString.Trim = "" Then
            p_Error = True
            p_Desc = "String kết nối đến máy chủ Scadar không xác định"
            Exit Sub
        End If
        p_TableExec.Clear()





        'lay chuoi select trong bang MaptblLine        
        p_SQL = "exec FPT_GetDataToScadar '" & p_SoLenh.Trim & "'"
        p_DataHTTG = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataHTTG Is Nothing Then
            For p_Count = 0 To p_DataHTTG.Rows.Count - 1

                p_DataRowHTTG = p_DataHTTG.Rows(p_Count)
                If g_TableMaHangHoaE5.Rows.Count <= 0 Then
                    Exit Sub
                End If
                p_HangHoaE5 = False
                p_MaHangHoa = p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                If p_MaHangHoa.ToString.Trim = g_TableMaHangHoaE5.Rows(0).Item("MaHangHoa_Scada").ToString.Trim Then
                    p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    p_HangHoaE5 = True
                    If p_DataRowMap_cp.Length <= 0 Then
                        Exit Sub
                    End If
                Else
                    'p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_STT = p_DataRowMap_cp_Old(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    If p_DataRowMap_cp.Length <= 0 Then
                        Exit Sub
                    End If
                End If



                p_SQLInsert = ""
                p_SQLValue = ""
                p_Where_Check = ""
                p_Where_Update = ""
                For p_CountRow = 0 To p_DataRowMap_cp.Length - 1
                    'Lay kieu du lieu
                    p_FieldType = ""

                    If UCase(g_LoaiVanChuyen) = "BO" And p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim = "" Then
                        Continue For
                    End If

                    If UCase(g_LoaiVanChuyen) = "THUY" And p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim = "" Then
                        Continue For
                    End If
                    If UCase(g_LoaiVanChuyen) = "SAT" And p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim = "" Then
                        Continue For

                    End If

                    If p_HangHoaE5 = True Then
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, g_Client_E5, p_HangHoaE5)
                    Else
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, p_Terminal, p_HangHoaE5)
                    End If

                    If p_FieldType.ToString.Trim <> "" Then



                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "FLAG1" Then
                            If p_HangHoaE5 = True Then
                                p_Value = p_DataRowMap_cp_E5(0).Item("FlagBegin").ToString.Trim
                                p_Flag = p_Value.Split(".")
                                If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                    p_Value = p_Flag(0)
                                Else
                                    p_Value = p_Flag(1)
                                End If
                            Else
                                p_Value = p_DataRowMap_cp_Old(0).Item("FlagBegin").ToString.Trim
                                p_Flag = p_Value.Split(".")
                                If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                    p_Value = p_Flag(0)
                                Else
                                    p_Value = p_Flag(1)
                                End If
                            End If
                        Else
                            p_Value_HTTG = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim
                            Select Case UCase(g_LoaiVanChuyen)
                                Case "BO"
                                    p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("Bo").trim).ToString.Trim
                                Case "THUY"
                                    p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("Thuy").trim).ToString.Trim
                                Case "SAT"
                                    p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("Sat").trim).ToString.Trim
                                Case Else
                                    Continue For
                            End Select

                        End If






                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" Then


                            If p_Where_Check.ToString.Trim = "" Then
                                p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                p_Value = p_Value.Substring(1, g_MaNgan_DD)
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select

                            Else
                                p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                p_Value = p_Value.Substring(1, g_MaNgan_DD)
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select
                            End If
                        End If

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") Then
                            If p_Where_Check.ToString.Trim = "" Then
                                p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    Case Else
                                        Continue For
                                End Select
                            Else
                                p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    Case Else
                                        Continue For
                                End Select
                            End If
                        End If



                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                'p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                                p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                            Else
                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                p_Where_Update = p_Where_Update & "  AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
                            End If
                        End If
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MALENH" Then
                            If g_MaTuDongHoa = "N" Then  'Ma tu dong hoa cho SQL la TableID
                                p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
                                'If g_MaTuDongHoa = "N" Then
                                If p_Value.ToString.Trim <> "" Then
                                    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                   p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                    'anhqh  20160623  Sua them dung rieng cho KV1   FPT_GetMaTuDongHoa_KV1
                                    'If g_Company_Code = "2110" Then
                                    '    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & GetMaVanChuyenLenhXuat(p_SoLenh) & "'"
                                    'Else
                                    '    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                    'End If
                                    p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                                    If Not p_DataTableCheckID Is Nothing Then
                                        If p_DataTableCheckID.Rows.Count > 0 Then
                                            p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                                        End If
                                    End If
                                Else
                                    'H_TableID
                                    p_Value = p_DataRowHTTG.Item("H_TableID").ToString.Trim
                                    If p_Value.ToString.Trim <> "" Then
                                        p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                       p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"

                                        p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                                        If Not p_DataTableCheckID Is Nothing Then
                                            If p_DataTableCheckID.Rows.Count > 0 Then
                                                p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                                            End If
                                        End If
                                    End If
                                End If
                                If p_Where_Check.ToString.Trim = "" Then
                                    p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                        Case Else
                                            Continue For
                                    End Select
                                Else
                                    p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                        Case Else
                                            Continue For
                                    End Select
                                End If

                                'End If
                            ElseIf g_MaTuDongHoa = "Y" Then  'Ma tu dong hoa cho FOX
                                p_SQL = "exec FPT_Key_TuDongHoa"
                                p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                                If Not p_DataTableCheckID Is Nothing Then
                                    If p_DataTableCheckID.Rows.Count > 0 Then
                                        p_Value = p_DataTableCheckID.Rows(0).Item("MaTuDongHoa").ToString.Trim
                                    End If
                                End If
                            End If

                        End If
                        'Tinh lai Ma lenh cua tu dong hoa


                        Select Case UCase(g_LoaiVanChuyen)
                            Case "BO"
                                p_SQLInsert = p_SQLInsert & "," & p_DataRowMap_cp(p_CountRow).Item("Bo").trim
                            Case "THUY"
                                p_SQLInsert = p_SQLInsert & "," & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim
                            Case "SAT"
                                p_SQLInsert = p_SQLInsert & "," & p_DataRowMap_cp(p_CountRow).Item("Sat").trim
                            Case Else
                                Continue For
                        End Select

                        Select Case UCase(p_FieldType)
                            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                ' p_SQLValue = p_SQLValue & "," & p_Value
                                p_SQLInsert = p_SQLInsert & "=" & p_Value
                            Case UCase("DateTime"), UCase("Date")
                                'p_SQLValue = p_SQLValue & ",'" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                p_SQLInsert = p_SQLInsert & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                            Case UCase("String")
                                'p_SQLValue = p_SQLValue & ",'" & p_Value & "'"
                                p_SQLInsert = p_SQLInsert & "='" & p_Value & "'"
                            Case Else
                                Continue For
                        End Select
                    End If
                Next

                If p_Where_Check.ToString.Trim <> "" Then
                    If p_HangHoaE5 = True Then
                        p_SQL = "select 1 as STT  from " & p_TableName_E5 & " WHERE " & p_Where_Check
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count > 0 Then
                                Continue For
                            End If

                        End If
                    Else
                        p_SQL = "select 1 as STT from " & p_TableName & " WHERE " & p_Where_Check
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count > 0 Then
                                Continue For
                            End If

                        End If

                    End If

                End If

                If p_HangHoaE5 = True Then
                    'ByRef p_Tyle As Double, ByRef p_TyTrongNen As Double, ByRef p_TyTrongEthanol As Double
                    'GetTyTrong_TyLeE5(p_DataRowHTTG.Item("TableID").ToString.Trim, _
                    '                    p_DataRowHTTG.Item("MaLenh").ToString.Trim, _
                    '                    CDate(p_DataRowHTTG.Item("NgayXuat")), _
                    '                    p_DataRowHTTG.Item("LineID").ToString.Trim, _
                    '                    p_TyleE5, _
                    '                    p_TyTrongNenE5, _
                    '                    p_TyTrongEthanolE5)
                    'If p_TyleE5 = 0 Or p_TyTrongNenE5 = 0 Or p_TyTrongEthanolE5 = 0 Then
                    '    p_Desc = "Không xác định Tỷ lệ phối trộn hoặc tỷ trọng nền hoặc tỷ trong Ethanol"
                    '    p_Error = True
                    '    Exit Sub
                    'Else

                    'End If
                    'p_SQLInsert = p_SQLInsert & ",TYLE_PRESET, TYTRONG_BASE, TYTRONG_E"
                    'p_SQLValue = p_SQLValue & "," & p_TyleE5 & "," & p_TyTrongNenE5 & "," & p_TyTrongEthanolE5
                End If
                If p_SQLInsert.Trim <> "" Then
                    p_SQLInsert = Mid(p_SQLInsert, 2)
                End If
                'If p_SQLValue.Trim <> "" Then
                '    p_SQLValue = Mid(p_SQLValue, 2)
                'End If
                If p_SQLInsert <> "" Then
                    'p_StrExe = p_InsertTable & "(" & p_SQLInsert & ") "
                    'p_StrExe = p_StrExe & p_ValueTable & "(" & p_SQLValue & ")"

                    'If p_HangHoaE5 = True Then
                    '    p_StrExeE5 = p_InsertTable_E5 & "(" & p_SQLInsert & ") "
                    '    p_StrExeE5 = p_StrExeE5 & p_ValueTable & "(" & p_SQLValue & ")"
                    '    p_DataRow = p_TableExec_E5.NewRow
                    '    p_DataRow.Item(0) = p_StrExeE5
                    '    p_TableExec_E5.Rows.Add(p_DataRow)
                    'Else
                    '    p_StrExe = p_InsertTable & "(" & p_SQLInsert & ") "
                    '    p_StrExe = p_StrExe & p_ValueTable & "(" & p_SQLValue & ")"
                    '    p_DataRow = p_TableExec.NewRow
                    '    p_DataRow.Item(0) = p_StrExe
                    '    p_TableExec.Rows.Add(p_DataRow)
                    'End If
                    p_StrExe = p_InsertTable & "(" & p_SQLInsert & ") "

                    p_DataRow = p_TableExec.NewRow
                    p_DataRow.Item(0) = p_StrExe
                    p_TableExec.Rows.Add(p_DataRow)
                End If

            Next

            If Not p_TableExec Is Nothing Then
                If p_TableExec.Rows.Count > 0 Then
                    If g_DBTYPE = "" Then
                        g_Services.Sys_GetParameterOracle(g_DBTYPE)
                    End If
                    If p_TableExec.Rows.Count > 0 Then
                        If g_DBTYPE = "ORACLE" Then
                            If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar, p_TableExec, p_SQL) = False Then
                                'MsgBox(p_SQL)
                                'g_Module.ModErrExceptionNew("", p_SQL)
                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub
                                ' Else

                            End If
                        ElseIf g_DBTYPE = "SQL" Then
                            If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar, p_TableExec, p_SQL) = False Then
                                'MsgBox(p_SQL)
                                'g_Module.ModErrExceptionNew("", p_SQL)
                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub
                                'Else

                            End If
                        End If
                    Else
                        'MsgBox("Không xác định được dữ liệu cần cập nhật")
                        'g_Module.ModErrExceptionNew("MS0004", "Lỗi khi cập nhật")
                        ' Exit Sub
                        p_Desc = "Không xác định dữ liệu đẩy Scadar"
                        p_Error = True
                        Exit Sub
                    End If
                End If
            End If

            'If Not p_TableExec_E5 Is Nothing Then
            '    If p_TableExec_E5.Rows.Count > 0 Then
            '        If g_DBTYPE = "" Then
            '            g_Services.Sys_GetParameterOracle(g_DBTYPE)
            '        End If
            '        If p_TableExec_E5.Rows.Count > 0 Then
            '            If g_DBTYPE = "ORACLE" Then
            '                If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar, p_TableExec_E5, p_SQL) = False Then
            '                    'MsgBox(p_SQL)
            '                    'g_Module.ModErrExceptionNew("", p_SQL)
            '                    p_Desc = p_SQL
            '                    p_Error = True
            '                    Exit Sub
            '                    ' Else

            '                End If
            '            ElseIf g_DBTYPE = "SQL" Then
            '                If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar_E5, p_TableExec_E5, p_SQL) = False Then
            '                    'MsgBox(p_SQL)
            '                    'g_Module.ModErrExceptionNew("", p_SQL)
            '                    p_Desc = p_SQL
            '                    p_Error = True
            '                    Exit Sub
            '                    'Else

            '                End If
            '            End If
            '        Else
            '            'MsgBox("Không xác định được dữ liệu cần cập nhật")
            '            'g_Module.ModErrExceptionNew("MS0004", "Lỗi khi cập nhật")
            '            ' Exit Sub
            '            p_Desc = "Không xác định dữ liệu đẩy Scadar E5"
            '            p_Error = True
            '            Exit Sub
            '        End If
            '    End If
            'End If
            'Cap nhat lai trang thai cua lenhXuat
            p_TableExec.Clear()
            p_DataRow = p_TableExec.NewRow
            p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set Status='3' where SoLenh='" & p_SoLenh & "'"
            p_TableExec.Rows.Add(p_DataRow)
            If Not p_TableExec Is Nothing Then
                If p_TableExec.Rows.Count > 0 Then
                    If g_DBTYPE = "" Then
                        g_Services.Sys_GetParameterOracle(g_DBTYPE)
                    End If
                    If p_TableExec.Rows.Count > 0 Then
                        If g_DBTYPE = "ORACLE" Then
                            If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar, p_TableExec, p_SQL) = False Then
                                'MsgBox(p_SQL)
                                'g_Module.ModErrExceptionNew("", p_SQL)
                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub
                                ' Else

                            End If
                        ElseIf g_DBTYPE = "SQL" Then
                            If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar, p_TableExec, p_SQL) = False Then
                                'MsgBox(p_SQL)
                                'g_Module.ModErrExceptionNew("", p_SQL)
                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub
                                'Else

                            End If
                        End If
                    Else
                        'MsgBox("Không xác định được dữ liệu cần cập nhật")
                        'g_Module.ModErrExceptionNew("MS0004", "Lỗi khi cập nhật")
                        ' Exit Sub
                        p_Desc = "Lỗi khi cập nhật trạng thái của Lệnh xuất"
                        p_Error = True
                        Exit Sub
                    End If
                End If
            End If
        End If
    End Sub

    'Cac  ham dung cho viec tinh D15 cua E5

    Private Function mdlQCI_GetD15_NS(ByVal p_HangHoaE5 As Boolean, ByVal i_temp As String, _
                                         ByVal i_dens As String, Optional ByVal p_BeXuat As String = "") As String
        Dim l_vcf_1 As String


        Dim l_dens As String
        Dim l_dens_1 As String
        Dim l_dens_2 As String
        Dim l_temp As String
        Dim p_DataTable As DataTable
        Dim p_SQL As String

        If i_dens.Length > 6 Then
            l_dens = i_dens.Substring(0, 6)
        Else
            l_dens = i_dens
        End If

        l_dens_1 = mdlQCI_ConvertDens_1E5(l_dens)
        l_dens_2 = mdlQCI_ConvertDens_2E5(l_dens)

        If i_temp.Length > 5 Then
            l_temp = i_temp.Substring(0, 5)
        Else
            l_temp = i_temp
            If l_temp.Length = 2 Then
                l_temp = l_temp & ".00"
            Else

                If i_temp.Length < 5 Then
                    For i As Integer = 1 To 5 - i_temp.Length
                        l_temp = l_temp & "0"
                    Next
                End If
            End If
        End If

        l_temp = mdlQCI_ConvertTemp(l_temp)

        Try

            If l_dens_1 = l_dens_2 Then

                p_SQL = "select top 1 TyTrong15 from tblTyTrong15E5 with (Nolock) where NhietDoTT=" & l_temp & " and TyTrongTT=" & l_dens_1
                p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        l_vcf_1 = p_DataTable.Rows(0).Item("TyTrong15").ToString.Trim
                    End If
                End If
                'l_vcf_1 = l_c2sql.getDataValue("select top 1 TyTrong15 from tblTyTrong15E5 with (Nolock) where NhietDoTT=" & l_temp & " and TyTrongTT=" & l_dens_1)
                '
            Else
                l_vcf_1 = mdlQCI_GetVCFSub_NSE5(l_temp, i_dens, l_dens_1, l_dens_2)
            End If
            'FES
            '20141028
            If l_vcf_1 = "" Then l_vcf_1 = "1"
        Catch ex As Exception
            l_vcf_1 = "1"
        End Try

        Return l_vcf_1
    End Function

    'Ham tinh cho tỷ trong 15 của hàng phối trộn    

    Public Sub mdlQCI_GetD15_Inline(ByVal i_temp As String, ByVal i_dens As String, _
                                         ByRef r_temp As String, ByRef r_dens_1 As String, ByRef r_dens_2 As String, ByRef r_dens As String)
        Dim l_vcf_1 As String


        Dim l_dens As String
        Dim l_dens_1 As String
        Dim l_dens_2 As String

        Dim l_dens15_1 As String
        Dim l_dens15_2 As String

        Dim l_temp As String
        Dim p_DataTable As DataTable
        Dim p_SQL As String

        If i_dens.Length > 6 Then
            l_dens = i_dens.Substring(0, 6)
        Else
            l_dens = i_dens
        End If

        l_dens_1 = mdlQCI_ConvertDens_1E5(l_dens)
        l_dens_2 = mdlQCI_ConvertDens_2E5(l_dens)

        If i_temp.Length > 5 Then
            l_temp = i_temp.Substring(0, 5)
        Else
            l_temp = i_temp
            If l_temp.Length = 2 Then
                l_temp = l_temp & ".00"
            Else

                If i_temp.Length < 5 Then
                    For i As Integer = 1 To 5 - i_temp.Length
                        l_temp = l_temp & "0"
                    Next
                End If
            End If
        End If

        l_temp = mdlQCI_ConvertTemp(l_temp)

        Try

            If l_dens_1 = l_dens_2 Then

                p_SQL = "select top 1 TyTrong15 from tblTyTrong15E5 with (Nolock) where NhietDoTT=" & l_temp & " and TyTrongTT=" & l_dens_1
                p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        l_vcf_1 = p_DataTable.Rows(0).Item("TyTrong15").ToString.Trim
                    End If
                End If
                'l_vcf_1 = l_c2sql.getDataValue("select top 1 TyTrong15 from tblTyTrong15E5 with (Nolock) where NhietDoTT=" & l_temp & " and TyTrongTT=" & l_dens_1)
                '
            Else
                l_vcf_1 = mdlQCI_GetVCFSub_NSE5_Inline(l_temp, i_dens, l_dens_1, l_dens_2, l_dens15_1, l_dens15_2)
            End If
            'FES
            '20141028
            If l_vcf_1 = "" Then l_vcf_1 = "1"
        Catch ex As Exception
            l_vcf_1 = "1"
        End Try

        'Return l_vcf_1
        r_temp = l_temp
        r_dens_1 = l_dens15_1
        r_dens_2 = l_dens15_2
        r_dens = l_vcf_1
    End Sub




    Private Function mdlQCI_GetVCFSub_NSE5(ByVal i_temp As String, _
                                    ByVal i_dens As String, _
                                    ByVal i_dens_1 As String, _
                                    ByVal i_dens_2 As String) As String
        Dim l_dens_in, _
            l_dens_1_dec, _
            l_dens_2_dec As Decimal
        Dim l_dt As DataTable = New DataTable
        Dim l_sql As String

        Try

            l_dens_in = Convert.ToDecimal(i_dens)
            l_dens_1_dec = Convert.ToDecimal(i_dens_1)
            l_dens_2_dec = Convert.ToDecimal(i_dens_2)

            'l_sql = "select * from tblVCF where [Temp] = '" & i_temp & _
            '        "' and [Dens] in ('" & l_dens_1_dec.ToString() & "' , '" & l_dens_2_dec.ToString() & "') order by vcf"

            l_sql = "select  TyTrong15 from tblTyTrong15E5 with (Nolock) where " & _
                "NhietDoTT=" & i_temp & " and TyTrongTT in (" & l_dens_1_dec.ToString() & " , " & l_dens_2_dec.ToString() & ") order by TyTrong15"


            l_dt = g_Services.Sys_SYS_GET_DATATABLE_Des(l_sql, l_sql)

            If l_dt.Rows.Count <> 2 Then
                Return "0"
            End If

            Dim l_vcf_1, _
                l_vcf_2, _
                l_vcf _
                As Decimal

            l_vcf_1 = Convert.ToDecimal(l_dt.Rows(0).Item("TyTrong15").ToString())
            l_vcf_2 = Convert.ToDecimal(l_dt.Rows(1).Item("TyTrong15").ToString())

            l_vcf = Math.Abs(l_vcf_2 - l_vcf_1) / Math.Abs(l_dens_2_dec - l_dens_1_dec)
            l_vcf = l_vcf_1 + l_vcf * (l_dens_in - l_dens_1_dec)

            Return Math.Round(l_vcf, 4)
        Catch ex As Exception
            Return "0"
        End Try

    End Function




    Private Function mdlQCI_GetVCFSub_NSE5_Inline(ByVal i_temp As String, _
                                    ByVal i_dens As String, _
                                    ByVal i_dens_1 As String, _
                                    ByVal i_dens_2 As String, _
                                    ByRef r_dens_1 As String, _
                                    ByRef r_dens_2 As String) As String
        Dim l_dens_in, _
            l_dens_1_dec, _
            l_dens_2_dec As Decimal
        Dim l_dt As DataTable = New DataTable
        Dim l_sql As String

        Try

            l_dens_in = Convert.ToDecimal(i_dens)
            l_dens_1_dec = Convert.ToDecimal(i_dens_1)
            l_dens_2_dec = Convert.ToDecimal(i_dens_2)

            'l_sql = "select * from tblVCF where [Temp] = '" & i_temp & _
            '        "' and [Dens] in ('" & l_dens_1_dec.ToString() & "' , '" & l_dens_2_dec.ToString() & "') order by vcf"

            l_sql = "select  TyTrong15 from tblTyTrong15E5 with (Nolock) where " & _
                "NhietDoTT=" & i_temp & " and TyTrongTT in (" & l_dens_1_dec.ToString() & " , " & l_dens_2_dec.ToString() & ") order by TyTrong15"


            l_dt = g_Services.Sys_SYS_GET_DATATABLE_Des(l_sql, l_sql)

            If l_dt.Rows.Count <> 2 Then
                Return "0"
            End If

            Dim l_vcf_1, _
                l_vcf_2, _
                l_vcf _
                As Decimal

            l_vcf_1 = Convert.ToDecimal(l_dt.Rows(0).Item("TyTrong15").ToString())
            l_vcf_2 = Convert.ToDecimal(l_dt.Rows(1).Item("TyTrong15").ToString())

            r_dens_1 = l_vcf_1
            r_dens_2 = l_vcf_2
            l_vcf = Math.Abs(l_vcf_2 - l_vcf_1) / Math.Abs(l_dens_2_dec - l_dens_1_dec)
            l_vcf = l_vcf_1 + l_vcf * (l_dens_in - l_dens_1_dec)

            Return Math.Round(l_vcf, 4)
        Catch ex As Exception
            Return "0"
        End Try

    End Function


    Private Function mdlQCI_ConvertDens_1E5(ByVal i_dens As String) As String
        Try
            Dim l_dens_0 As String
            Dim l_dens_1 As String
            Dim l_dens_2 As String
            Dim l_dens_3 As String

            Dim l_dens_1_int As Decimal
            Dim l_step_1 As Decimal = 0.001

            l_dens_0 = i_dens

            If l_dens_0.Length < 6 Then
                For i As Integer = 1 To 6 - i_dens.Length
                    l_dens_0 = l_dens_0 & "0"
                Next
            End If

            '------------------------
            '   5 ký tự đầu
            '------------------------
            l_dens_1 = l_dens_0.Substring(0, 5)
            l_dens_1_int = l_dens_1
            '------------------------
            '   1 ký tự cuối
            '------------------------
            l_dens_2 = l_dens_0.Substring(5, 1)

            '------------------------
            '   1 ký tự áp chót
            '------------------------
            l_dens_3 = l_dens_0.Substring(4, 1)

            '----------------------------------------------------
            '   Nếu vị trí cuối = 0 và áp chót chẵn : 1.2340
            '   Đầu ra là                           : 1.234
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 = "0" Then
                Return l_dens_1
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối = 0 và áp chót lẻ   : 1.2350 
            '   Đầu ra là                           : 1.235 - 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 = "0" Then
                l_dens_1_int = l_dens_1_int - l_step_1
                Return l_dens_1_int.ToString()
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót chẵn: 1.2346
            '   Đầu ra là                           : 1.234
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 <> "0" Then
                Return l_dens_1
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót lẻ  : 1.2351
            '   Đầu ra là                           : 1.235 - 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 <> "0" Then
                l_dens_1_int = l_dens_1_int - l_step_1
                Return l_dens_1_int.ToString()
            End If

            Return i_dens
        Catch ex As Exception
            Return i_dens
        End Try
    End Function


    Private Function mdlQCI_ConvertDens_2E5(ByVal i_dens As String) As String
        Try
            Dim l_dens_0 As String
            Dim l_dens_1 As String
            Dim l_dens_2 As String
            Dim l_dens_3 As String

            Dim l_dens_1_int As Decimal
            Dim l_step_1 As Decimal = 0.001
            Dim l_step_2 As Decimal = 0.002

            l_dens_0 = i_dens

            If l_dens_0.Length < 6 Then
                For i As Integer = 1 To 6 - i_dens.Length
                    l_dens_0 = l_dens_0 & "0"
                Next
            End If

            '------------------------
            '   5 ký tự đầu
            '------------------------
            l_dens_1 = l_dens_0.Substring(0, 5)
            l_dens_1_int = l_dens_1
            '------------------------
            '   1 ký tự cuối
            '------------------------
            l_dens_2 = l_dens_0.Substring(5, 1)

            '------------------------
            '   1 ký tự áp chót
            '------------------------
            l_dens_3 = l_dens_0.Substring(4, 1)

            '----------------------------------------------------
            '   Nếu vị trí cuối = 0 và áp chót chẵn : 1.2340
            '   Đầu ra là                           : 1.234
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 = "0" Then
                Return l_dens_1
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối = 0 và áp chót lẻ   : 1.2350 
            '   Đầu ra là                           : 1.235 + 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 = "0" Then
                l_dens_1_int = l_dens_1_int + l_step_1
                Return l_dens_1_int.ToString()
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót chẵn: 1.2346
            '   Đầu ra là                           : 1.234 + 0.002
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 <> "0" Then
                l_dens_1_int = l_dens_1_int + l_step_2
                Return l_dens_1_int.ToString()
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót lẻ  : 1.2351
            '   Đầu ra là                           : 1.235 + 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 <> "0" Then
                l_dens_1_int = l_dens_1_int + l_step_1
                Return l_dens_1_int.ToString()
            End If

            Return i_dens
        Catch ex As Exception
            Return i_dens
        End Try
    End Function

    Private Sub p_GetCurrentDate(ByRef p_Date As DateTime)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        p_SQL = "select  getdate() as SysDate"
        ' p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SysDate")

            End If
        End If
        p_Datatable = Nothing
    End Sub




    Public Function CheckScadarToHTTG(ByRef p_TableScadar As DataTable, _
                                        ByRef p_TableScadar_E5 As DataTable, _
                                        ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                Optional ByVal p_Terminal As String = "", _
                                  Optional ByVal p_GetScadarToHTTG As Boolean = True, _
                                  Optional ByVal p_E5 As Boolean = True) As String
        Dim p_SQL As String
        Dim p_DataSet As DataSet
        Dim p_Eror As Boolean
        Dim p_Desc As String
        Dim p_ArrRow() As DataRow
        Try

            GetClient_E5(p_Terminal)

            CheckScadarToHTTG = ""
            g_HTTG_E5 = p_E5
            'p_SQL = "select * from tblMap_cp;" & _
            '    "select * from SYS_Map_cp_Line; " & _
            '    "select * from SYS_CONFIG; " & _
            '    "SELECT *  FROM [tblMap_MaHangHoa] where MaHangHoa_Sap='0201004';"
            p_SQL = "exec FPT_GetDataTableList"
            p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)
            If Not p_DataSet Is Nothing Then
                If p_DataSet.Tables.Count > 0 Then
                    g_DataMap_cp = p_DataSet.Tables(0)
                    g_DataMap_Line_cp = p_DataSet.Tables(1)
                    g_Table_Sys_Config = p_DataSet.Tables(2)
                    g_TableMaHangHoaE5 = p_DataSet.Tables(3)
                    'anhqh 20150819
                    g_TabletblConfig = p_DataSet.Tables(4)

                    p_ArrRow = g_Table_Sys_Config.Select("KEYCODE='MATUDONGHOA'")
                    If p_ArrRow.Length > 0 Then
                        g_MaTuDongHoa = IIf(p_ArrRow(0).Item("KEYVALUE").ToString.Trim = "", "N", p_ArrRow(0).Item("KEYVALUE").ToString.Trim)
                    End If
                    p_ArrRow = g_Table_Sys_Config.Select("KEYCODE='MANGAN_DD'")
                    If p_ArrRow.Length > 0 Then
                        g_MaNgan_DD = IIf(p_ArrRow(0).Item("KEYVALUE").ToString.Trim = "", "N", p_ArrRow(0).Item("KEYVALUE").ToString.Trim)
                    End If

                End If
            End If

            g_Services.Sys_GetParameterOracle(g_DBTYPE)

            '20150819
            If Not g_TabletblConfig Is Nothing Then
                If g_TabletblConfig.Rows.Count > 0 Then
                    g_TypeConnet = g_TabletblConfig.Rows(0).Item("optional").ToString.Trim()
                End If
            End If

            '20150819
            If UCase(g_TypeConnet) = "FOX" Then
                If GetConnectFox(p_Desc, p_TypeIn, g_LoaiVanChuyen, p_Terminal) = False Then
                    CheckScadarToHTTG = p_Desc
                    p_Eror = True
                    Exit Function
                End If
            End If



            getSQL_TableToScadar(p_TypeIn, g_LoaiVanChuyen, p_Terminal)
            If p_GetScadarToHTTG = True Then
                If g_DBTYPE = "SQL" Then
                    CheckSQLGetDataFromScadar(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Eror, p_Desc, p_Terminal, p_TableScadar, p_TableScadar_E5)
                    If p_Eror = True Then
                        CheckScadarToHTTG = p_Desc

                    Else

                    End If
                End If
            End If
        Catch ex As Exception
            CheckScadarToHTTG = ex.Message
        End Try
    End Function





    'anhqh
    'Ham thuc hien lay du lieu chi tiet cua  Scadar capnhat cho HTTG
    Private Sub CheckSQLGetDataFromScadar(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, ByRef p_Error As Boolean, ByRef p_Desc As String, _
                                    ByVal p_Terminal As String, ByRef p_TableScadar As DataTable, _
                                        ByRef p_TableScadar_E5 As DataTable)
        Dim p_SQL As String
        Dim p_DataHTTG As DataTable
        Dim p_CountRow As Integer
        Dim p_CountCol As Integer
        Dim p_Count As Integer
        Dim p_DataRowHTTG As DataRow
        Dim p_SQLInsert As String = ""
        Dim p_SQLValue As String = ""
        Dim p_DataRowMap_cp() As DataRow
        Dim p_FieldType As String

        Dim p_Value As String
        Dim p_TableName As String = ""
        Dim p_STT As Integer
        ' Dim p_TableScadar As DataTable
        Dim p_DataTableCheckID As DataTable
        Dim p_Where_Check As String  'Dung checkScadar

        Dim p_Where_Update As String  'Dung de update HTTG
        Dim p_TableIDHTTG As String

        Dim p_TableName_E5 As String = ""
        Dim p_DataRowMap_cp_E5() As DataRow
        Dim p_DataRowCheck() As DataRow
        Dim p_DataRowMap_cp_Old() As DataRow
        'Dim p_InsertTable_E5 As String = ""
        'Dim p_ValueTable_E5 As String = ""
        'Dim p_TableScadar_E5 As DataTable
        Dim p_MaHangHoa As String
        Dim p_HangHoaE5 As Boolean
        Dim p_StatusType As String
        Dim p_FromField As String = ""

        Dim p_Flag() As String
        Dim p_DataTableA92 As DataTable

        Dim p_TableID As Integer
        Dim p_NgayXuat As DateTime
        Dim p_MaNgan As Integer

        If g_DataMap_cp Is Nothing Then
            Exit Sub
        End If

        'anhqh
        '20160926
        Dim p_TableInE5 As DataTable
        Dim p_RowInE5 As DataRow
        Dim p_Xuat92 As Boolean
        Dim p_CountField As Integer

        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "') and (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "' )")
        If p_DataRowMap_cp_Old.Length <= 0 Then
            Exit Sub
        End If


        If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
            p_TableName = p_DataRowMap_cp_Old(0).Item("TableName").ToString.Trim
        End If
        If UCase(g_LoaiVanChuyen) = "THUY" Then
            p_TableName = p_DataRowMap_cp_Old(0).Item("TableName_Thuy").ToString.Trim
        End If
        If p_DataRowMap_cp_E5.Length > 0 Then
            p_TableName_E5 = p_DataRowMap_cp_E5(0).Item("TableName").ToString.Trim
        End If

        If p_TableName = "" Then
            Exit Sub
        End If
        p_Error = False
        p_Desc = ""
        'If g_ConnectToScadar.ToString.Trim = "" Then
        '    p_Error = True
        '    p_Desc = "String kết nối đến máy chủ Scadar không xác định"
        '    Exit Sub
        'End If

        '20150819
        'Them dieu kien FOX
        If UCase(g_TypeConnet) = "FOX" Then
            If g_StrConnectFox.ToString.Trim = "" Then
                p_Error = True
                p_Desc = "String kết nối đến máy chủ Scadar không xác định"
                Exit Sub
            End If
        Else
            If g_ConnectToScadar.ToString.Trim = "" Then
                p_Error = True
                p_Desc = "String kết nối đến máy chủ Scadar không xác định"
                Exit Sub
            End If
        End If

        If UCase(g_TypeConnet) = "FOX" Then
            If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                p_TableName = Replace(g_PathFileFoxBo, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)
            Else
                p_TableName = Replace(g_PathFileFoxThuy, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)
            End If

        End If


        'lay chuoi select trong bang MaptblLine        
        p_SQL = "exec FPT_GetDataToScadar '" & p_SoLenh.Trim & "'"
        p_DataHTTG = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataHTTG Is Nothing Then

            'anhqh
            '20160926
            p_TableInE5 = p_DataHTTG.Clone

            For p_Count = 0 To p_DataHTTG.Rows.Count - 1
                p_DataRowHTTG = p_DataHTTG.Rows(p_Count)
                If g_TableMaHangHoaE5.Rows.Count <= 0 Then
                    Exit Sub
                End If
                p_HangHoaE5 = False
                p_MaHangHoa = p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                If CheckHangHoaE5(p_MaHangHoa.ToString.Trim) = True Then
                    p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    p_HangHoaE5 = True
                    If p_DataRowMap_cp.Length <= 0 Then
                        Exit Sub
                    End If
                Else
                    'p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_STT = p_DataRowMap_cp_Old(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    If p_DataRowMap_cp.Length <= 0 Then
                        Exit Sub
                    End If
                End If
                p_SQLInsert = ""
                p_SQLValue = ""
                p_Where_Check = ""
                p_Where_Update = ""
                For p_CountRow = 0 To p_DataRowMap_cp.Length - 1
                    'Lay kieu du lieu
                    p_FieldType = ""

                    If UCase(g_LoaiVanChuyen) = "BO" And p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim = "" Then
                        Continue For
                    End If

                    If UCase(g_LoaiVanChuyen) = "THUY" And p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim = "" Then
                        Continue For
                    End If
                    If UCase(g_LoaiVanChuyen) = "SAT" And p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim = "" Then
                        Continue For

                    End If

                    If p_HangHoaE5 = True Then
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, g_Client_E5, p_HangHoaE5)
                    Else
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, p_Terminal, p_HangHoaE5)
                    End If

                    If p_FieldType.ToString.Trim <> "" Or UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "FLAG1" Then



                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "FLAG1" Then
                            If p_HangHoaE5 = True Then
                                p_Value = p_DataRowMap_cp_E5(0).Item("FlagFinish").ToString.Trim
                                p_Flag = p_Value.Split(".")
                                If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                    p_Value = p_Flag(0)
                                Else
                                    p_Value = p_Flag(1)
                                End If
                            Else
                                p_Value = p_DataRowMap_cp_Old(0).Item("FlagFinish").ToString.Trim
                                p_Flag = p_Value.Split(".")
                                If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                    p_Value = p_Flag(0)
                                Else
                                    p_Value = p_Flag(1)
                                End If
                            End If
                            p_StatusType = GetStatusType()


                            If p_Where_Check.ToString.Trim = "" Then
                                If UCase(g_TypeConnet) = "FOX" Then
                                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                        p_DataRowCheck = g_TableToScadarBo.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")
                                    Else
                                        p_DataRowCheck = g_TableToScadarThuy.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")

                                    End If
                                    If p_DataRowCheck.Length > 0 Then
                                        Select Case UCase(p_DataRowCheck(0).Item("FieldType").ToString.Trim)
                                            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                                p_Value = p_Value
                                            Case UCase("DateTime"), UCase("Date")
                                                p_Value = "{d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                            Case UCase("String")
                                                p_Value = "'" & p_Value & "'"
                                        End Select
                                        Select Case UCase(g_LoaiVanChuyen)
                                            Case "BO"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case "THUY"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case "SAT"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case Else
                                                Continue For
                                        End Select
                                    End If
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case Else
                                            Continue For
                                    End Select
                                End If


                            Else
                                If UCase(g_TypeConnet) = "FOX" Then
                                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                        p_DataRowCheck = g_TableToScadarBo.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")
                                    Else
                                        p_DataRowCheck = g_TableToScadarThuy.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")

                                    End If
                                    If p_DataRowCheck.Length > 0 Then
                                        Select Case UCase(p_DataRowCheck(0).Item("FieldType").ToString.Trim)
                                            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                                p_Value = p_Value
                                            Case UCase("DateTime"), UCase("Date")
                                                p_Value = "{d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                            Case UCase("String")
                                                p_Value = "'" & p_Value & "'"
                                        End Select
                                        Select Case UCase(g_LoaiVanChuyen)
                                            Case "BO"
                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case "THUY"
                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case "SAT"
                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "" & p_Value & ""
                                            Case Else
                                                Continue For
                                        End Select
                                    End If
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "'" & p_Value & "'"
                                        Case Else
                                            Continue For
                                    End Select
                                End If

                            End If
                            Continue For
                        Else
                            'ThoiGianDau()
                            'ThoiGianCuoi()
                            p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim
                        End If

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                'p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                p_Value = p_Value.Substring(1, g_MaNgan_DD)
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select

                            Else
                                p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
                                p_Value = p_Value.Substring(1, g_MaNgan_DD)
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select
                            End If
                        End If

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                'p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                If UCase(g_TypeConnet) = "FOX" And p_HangHoaE5 = False Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case Else
                                            Continue For
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case Else
                                            Continue For
                                    End Select

                                End If

                            Else
                                ' p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                If UCase(g_TypeConnet) = "FOX" And p_HangHoaE5 = False Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case Else
                                            Continue For
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case Else
                                            Continue For
                                    End Select
                                End If

                            End If
                        End If



                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                'p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                                'p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                            Else
                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                'p_Where_Update = p_Where_Update & "  AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
                            End If
                        End If
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            ' If g_MaTuDongHoa = "N" Then  'Ma tu dong hoa cho SQL la TableID
                            'anhqh
                            '20150831
                            'Them truong hop neu khong phai la hoang hoa pha che thi nhay vao day
HoangHoaPhaChe:
                            p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
                            'p_FromField = "TableID"
                            'If g_MaTuDongHoa = "N" Then
                            If p_Value.ToString.Trim <> "" Then
                                'anhqh  20160623  Sua them dung rieng cho KV1   FPT_GetMaTuDongHoa_KV1
                                'If g_Company_Code = "2110" Then
                                '    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & GetMaVanChuyenLenhXuat(p_SoLenh) & "'"
                                'Else
                                '    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                'End If

                                'anhqh
                                '20160704
                                'themdieu kien cho KV1
                                If GetScadarWagonKV1() = True Then
                                    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & IIf(UCase(g_LoaiVanChuyen) = "SAT", "ZR", "AB") & "'"
                                Else
                                    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                End If

                                ' p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                'p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                                If Not p_DataTableCheckID Is Nothing Then
                                    If p_DataTableCheckID.Rows.Count > 0 Then
                                        p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                                    End If
                                End If
                            Else
                                'H_TableID
                                p_Value = p_DataRowHTTG.Item("H_TableID").ToString.Trim
                                If p_Value.ToString.Trim <> "" Then
                                    ' p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    'p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"

                                    'anhqh
                                    '20160704
                                    'themdieu kien cho KV1
                                    If GetScadarWagonKV1() = True Then
                                        p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                        p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & IIf(UCase(g_LoaiVanChuyen) = "SAT", "ZR", "AB") & "'"
                                    Else
                                        p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                        p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                    End If



                                    'anhqh  20160623  Sua them dung rieng cho KV1   FPT_GetMaTuDongHoa_KV1
                                    'If g_Company_Code = "2110" Then
                                    '    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & GetMaVanChuyenLenhXuat(p_SoLenh) & "'"
                                    'Else
                                    '    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                    'End If
                                    p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                                    If Not p_DataTableCheckID Is Nothing Then
                                        If p_DataTableCheckID.Rows.Count > 0 Then
                                            p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                                        End If
                                    End If
                                End If
                            End If
                            If p_Where_Check.ToString.Trim = "" Then
                                p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select
                            Else
                                ' p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select
                            End If

                            'End If
                            'ElseIf g_MaTuDongHoa = "Y" Then  'Ma tu dong hoa cho FOX
                            '    p_SQL = "exec FPT_Key_TuDongHoa"
                            '    p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                            '    If Not p_DataTableCheckID Is Nothing Then
                            '        If p_DataTableCheckID.Rows.Count > 0 Then
                            '            p_Value = p_DataTableCheckID.Rows(0).Item("MaTuDongHoa").ToString.Trim
                            '        End If
                            '    End If
                            'End If

                        End If
                        'g_TypeConnet 
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MATUDONGHOA" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then

                            p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim
                            If p_Where_Check.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
                                End Select
                            End If
                        End If
                    End If
                Next

                If p_Where_Check.ToString.Trim <> "" Then
                    If p_HangHoaE5 = True Then
                        p_SQL = "select * from " & p_TableName_E5 & " WHERE " & p_Where_Check
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count > 0 Then
                                If p_TableScadar_E5 Is Nothing Then
                                    p_TableScadar_E5 = p_DataTableCheckID
                                Else
                                    p_TableScadar_E5.Merge(p_DataTableCheckID)
                                End If
                            Else
                                'anhqh
                                '20160926
                                'Kiem tra neu co them o DB cua E5 thi loai di
                                Try
                                    If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
                                        p_TableInE5.Clear()
                                        p_RowInE5 = p_TableInE5.NewRow
                                        For p_CountField = 0 To p_TableInE5.Columns.Count - 1
                                            p_RowInE5.Item(p_CountField) = p_DataRowHTTG.Item(p_CountField)

                                        Next
                                        p_TableInE5.Rows.Add(p_RowInE5)

                                        p_DataTableA92 = SQLGetDataFromScadar_A92(p_TableInE5, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
                                                            p_Terminal)

                                        If Not p_DataTableA92 Is Nothing Then
                                            If p_TableScadar_E5 Is Nothing Then
                                                p_TableScadar_E5 = p_DataTableA92
                                            Else
                                                p_TableScadar_E5.Merge(p_DataTableA92)
                                            End If

                                        End If

                                    End If
                                Catch ex As Exception

                                End Try
                            End If

                        End If
                    Else
                        p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check

                        If UCase(g_TypeConnet) = "FOX" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    If p_TableScadar Is Nothing Then
                                        p_TableScadar = p_DataTableCheckID
                                    Else
                                        p_TableScadar.Merge(p_DataTableCheckID)
                                    End If

                                Else
                                    'anhqh
                                    '20160926
                                    'Kiem tra neu co them o DB cua E5 thi loai di
                                    Try
                                        If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
                                            p_TableInE5.Clear()
                                            p_RowInE5 = p_TableInE5.NewRow
                                            For p_CountField = 0 To p_TableInE5.Columns.Count - 1
                                                p_RowInE5.Item(p_CountField) = p_DataRowHTTG.Item(p_CountField)

                                            Next
                                            p_TableInE5.Rows.Add(p_RowInE5)

                                            p_DataTableA92 = SQLGetDataFromScadar_A92(p_TableInE5, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
                                                                p_Terminal)

                                            If Not p_DataTableA92 Is Nothing Then
                                                If p_TableScadar_E5 Is Nothing Then
                                                    p_TableScadar_E5 = p_DataTableA92
                                                Else
                                                    p_TableScadar_E5.Merge(p_DataTableA92)
                                                End If

                                            End If

                                        End If
                                    Catch ex As Exception

                                    End Try

                                End If
                            End If
                        End If
                        If UCase(g_TypeConnet) = "SQL" Then

                            'anhqh'
                            '20160926
                            ' p_Xuat92 = False

                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then

                                    If p_TableScadar Is Nothing Then
                                        p_TableScadar = p_DataTableCheckID
                                    Else
                                        p_TableScadar.Merge(p_DataTableCheckID)
                                    End If



                                Else

                                    'anhqh
                                    '20160926
                                    'Kiem tra neu co them o DB cua E5 thi loai di
                                    Try
                                        If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
                                            p_TableInE5.Clear()
                                            p_RowInE5 = p_TableInE5.NewRow
                                            For p_CountField = 0 To p_TableInE5.Columns.Count - 1
                                                p_RowInE5.Item(p_CountField) = p_DataRowHTTG.Item(p_CountField)

                                            Next
                                            p_TableInE5.Rows.Add(p_RowInE5)

                                            p_DataTableA92 = SQLGetDataFromScadar_A92(p_TableInE5, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
                                                                p_Terminal)

                                            If Not p_DataTableA92 Is Nothing Then
                                                If p_TableScadar_E5 Is Nothing Then
                                                    p_TableScadar_E5 = p_DataTableA92
                                                Else
                                                    p_TableScadar_E5.Merge(p_DataTableA92)
                                                End If

                                            End If

                                        End If
                                    Catch ex As Exception

                                    End Try

                                End If
                            End If
                        End If
                    End If
                End If
            Next
            p_CountRow = 0


            'If g_HTTG_E5 = True Then
            '    p_DataTableA92 = SQLGetDataFromScadar_A92(p_DataHTTG, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
            '                         p_Terminal)
            '    If Not p_DataTableA92 Is Nothing Then
            '        If p_TableScadar_E5 Is Nothing Then
            '            p_TableScadar_E5 = p_DataTableA92
            '        Else
            '            p_TableScadar_E5.Merge(p_DataTableA92)
            '        End If

            '    End If
            'Else
            '    p_TableScadar_E5 = Nothing
            'End If



            If Not p_TableScadar Is Nothing Then
                p_CountRow = p_CountRow + p_TableScadar.Rows.Count


            End If

            If Not p_TableScadar_E5 Is Nothing Then
                p_CountRow = p_CountRow + p_TableScadar_E5.Rows.Count
            End If




        End If
    End Sub



    'FES99
    '20141224
    'Ham lam tron
    Public Function RoundNumber(ByVal p_FIeld As String, ByVal p_Value As String) As Double
        Dim p_DataRow() As DataRow
        Dim p_Decima As Integer = 0
        Try

            If p_Value.ToString.Trim = "" Then
                Return 0
            End If

            If IsNumeric(p_Value) Then
                p_DataRow = g_ConfigDecima.Select("ClolumnName='" & p_FIeld & "'")
                If p_DataRow.Length <= 0 Then
                    Return CDbl(p_Value)
                End If

                If p_DataRow(0).Item("DecimaNumber").ToString.Trim = "" Then
                    Return CDbl(p_Value)
                End If
                p_Decima = p_DataRow(0).Item("DecimaNumber").ToString.Trim()

                Return Math.Round(CDbl(p_Value), p_Decima)
            Else
                Return 0
            End If
        Catch ex As Exception
            Return CDbl(p_Value)
        End Try
    End Function

End Module
