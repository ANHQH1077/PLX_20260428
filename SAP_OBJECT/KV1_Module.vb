Module KV1_Module



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

    Private Function CheckHangHoaE5(ByVal p_MaHangHoa As String) As Boolean
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
    'anhqh
    'Ham thuc hien lay du lieu chi tiet cua  Scadar capnhat cho HTTG
    Private Sub CheckSQLGetDataFromScadar(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, ByRef p_Error As Boolean, ByRef p_Desc As String, _
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
           
                If Not p_TableScadar Is Nothing Then
                    p_CountRow = p_CountRow + p_TableScadar.Rows.Count


                End If

                If Not p_TableScadar_E5 Is Nothing Then
                    p_CountRow = p_CountRow + p_TableScadar_E5.Rows.Count
                End If
            If p_DataHTTG.Rows.Count = p_CountRow And p_CountRow > 0 Then
                ''anhqh
                ''20160819
                'If UpdateFromScadarToHTTG(g_LoaiVanChuyen, p_DataRowMap_cp_E5, p_DataRowMap_cp_Old, p_DataHTTG, p_TableScadar, p_TableScadar_E5, p_Desc) = True Then
                '    ' p_Error = True
                '    ' Exit Sub
                'End If
                ''anhqh
                ''20150817
                'If g_HTTG_E5 = True Then
                '    UpdateFromScadarToHTTG_A92(g_LoaiVanChuyen, p_DataRowMap_cp_E5, p_DataRowMap_cp_Old, p_DataHTTG, p_TableScadar, p_TableScadar_E5)
                'End If
            Else
                p_Error = True
                p_Desc = "Chưa thực hiện bơm xuất"
                Exit Sub
            End If

        End If
    End Sub



    Public Function AutoCheckScadarToHTTG(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
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


            AutoCheckScadarToHTTG = ""
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
                    AutoCheckScadarToHTTG = p_Desc
                    p_Eror = True
                    Exit Function
                End If
            End If



            getSQL_TableToScadar(p_TypeIn, g_LoaiVanChuyen, p_Terminal)
            If p_GetScadarToHTTG = True Then
                If g_DBTYPE = "SQL" Then
                    CheckSQLGetDataFromScadar(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Eror, p_Desc, p_Terminal)
                    If p_Eror = True Then
                        AutoCheckScadarToHTTG = p_Desc

                    Else

                    End If
                End If
            End If
        Catch ex As Exception
            AutoCheckScadarToHTTG = ex.Message
        End Try
    End Function
End Module
