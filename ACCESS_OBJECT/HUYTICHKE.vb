
Imports System.Data.OleDb
Imports System.IO
Module HUYTICHKE
    'Public g_DataMap_cp As DataTable = Nothing
    'Public g_DataMap_Line_cp As DataTable = Nothing
    'Public g_TableToScadarBo As DataTable = Nothing
    'Public g_TableToScadarThuy As DataTable = Nothing
    'Public g_Table_Sys_Config As DataTable = Nothing
    'Public g_TableToScadar_E5 As DataTable = Nothing
    'Public g_TableMaHangHoaE5 As DataTable = Nothing
    'Public g_TabletblConfig As DataTable = Nothing

    'Public g_ConnectToScadar As String
    'Public g_ConnectToScadar_E5 As String
    'Public g_DBTYPE As String = "SQL"
    ''Public g_Terminal_E5 As String = ""
    'Public g_MaTuDongHoa As String = "N" 'Neu ='Y' thi la FOX    'N' thi la SQL
    'Public g_MaNgan_DD As String 'Do dai cua ma ngan

    'Public g_StrConnectFox As String
    'Public g_PathFileFoxOut As String
    'Public g_PathFileFoxIn As String

    'Public g_PathFileFoxThuy As String
    'Public g_PathFileFoxBo As String
    'Public g_TypeConnet As String = "SQL"



    'Public g_Client_E5_Upper As String = ""
    'Public g_Client_E5 As String = ""



    '1
    Public Function Scadar_HuyTichKe(ByVal p_WareHouse As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "") As String
        Dim p_SQL As String
        Dim p_DataSet As DataSet
        Dim p_Eror As Boolean
        Dim p_Desc As String
        Dim p_ArrRow() As DataRow
        Dim p_Type As String
        Dim p_DataTable As DataTable

        'p_SQL = "select Client from tbllenhxuatE5 where SoLenh='" & p_SoLenh & "'"
        'p_DataTable = GetDataTable(p_SQL, p_SQL)
        Try

            Scadar_HuyTichKe = ""

            GetClient_E5(p_Terminal)
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
            ' If UCase(g_TypeConnet) = "FOX" Then
            If GetConnectAccess(p_Desc, p_TypeIn, g_LoaiVanChuyen, p_Terminal) = False Then
                Scadar_HuyTichKe = p_Desc
                p_Eror = True
                Exit Function
            End If
            '  End If

            getSQL_TableToScadar(p_TypeIn, g_LoaiVanChuyen, p_Terminal)
            If g_DBTYPE = "SQL" Then
                'getSQL_TableToScadar("Thuy")
                If g_KV1 = True Then
                    KV1modHuyTichKe(p_WareHouse, "out", p_SoLenh, g_LoaiVanChuyen, p_Eror, p_Desc, p_Terminal)
                Else
                    modHuyTichKe(p_WareHouse, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Eror, p_Desc, p_Terminal)
                End If

                If p_Eror = True Then
                    Scadar_HuyTichKe = p_Desc

                End If
            End If

        Catch ex As Exception
            Scadar_HuyTichKe = "HTTG_To_Scadar: " & ex.Message
        End Try
    End Function




    'anhqh
    '20180206
    'Ham thuc hien cap nhat lai cac thong tin cho TĐH sau khi xác nhận thực xuất
    Public Function B12_UpdateScadar(ByVal p_WareHouse As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "") As String
        Dim p_SQL As String
        Dim p_DataSet As DataSet
        Dim p_Eror As Boolean
        Dim p_Desc As String
        Dim p_ArrRow() As DataRow
        Dim p_Type As String
        Dim p_DataTable As DataTable

        'p_SQL = "select Client from tbllenhxuatE5 where SoLenh='" & p_SoLenh & "'"
        'p_DataTable = GetDataTable(p_SQL, p_SQL)
        Try

            B12_UpdateScadar = ""

            GetClient_E5(p_Terminal)
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
            ' If UCase(g_TypeConnet) = "FOX" Then
            If GetConnectAccess(p_Desc, p_TypeIn, g_LoaiVanChuyen, p_Terminal) = False Then
                B12_UpdateScadar = p_Desc
                p_Eror = True
                Exit Function
            End If
            '  End If

            getSQL_TableToScadar(p_TypeIn, g_LoaiVanChuyen, p_Terminal)
            If g_DBTYPE = "SQL" Then
                'getSQL_TableToScadar("Thuy")
              
                B12UpdateToTDH(p_WareHouse, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Eror, p_Desc, p_Terminal)
              
                If p_Eror = True Then
                    B12_UpdateScadar = p_Desc
                End If
            End If

        Catch ex As Exception
            B12_UpdateScadar = "B12_UpdateScadar: " & ex.Message
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

    Private Sub modHuyTichKe(ByVal p_WareHouse As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                             ByRef p_Error As Boolean, ByRef p_Desc As String, _
                              ByVal p_Terminal As String)
        Dim p_SQL As String
        Dim p_DataHTTG As DataTable
        Dim p_CountRow As Integer
        'Dim p_CountCol As Integer
        Dim p_Count As Integer
        Dim p_DataRowHTTG As DataRow
        Dim p_SQLInsert As String = ""
        Dim p_SQLValue As String = ""
        Dim p_DataRowMap_cp() As DataRow
        Dim p_FieldType As String
        Dim p_Value As String
        Dim p_TableName As String = ""
        Dim p_STT As Integer
        Dim p_StrExe As String
        Dim p_TableExec As New DataTable("Table01")
        Dim p_DataRow As DataRow
        Dim p_DataTableCheckID As DataTable
        Dim p_Where_Check As String  'Dung checkScadar
        Dim p_TableName_E5 As String = ""
        Dim p_DataRowMap_cp_E5() As DataRow
        Dim p_DataRowMap_cp_Old() As DataRow
        Dim p_TableExec_E5 As New DataTable("Table01")
        Dim p_MaHangHoa As String
        Dim p_HangHoaE5 As Boolean
        Dim p_StrExeE5 As String
        Dim p_Flag() As String
        Dim p_StatusType As String
        Dim p_DataRowCheck() As DataRow

        Dim p_2Scadar As Boolean = False
        Dim p_2ScadarE5 As Boolean = False
        Dim p_whereDelete As String = ""

        If p_TableExec Is Nothing Then
            p_TableExec.Columns.Add("SQL_STR", GetType(String))
        Else
            If p_TableExec.Columns.Count <= 0 Then
                p_TableExec.Columns.Add("SQL_STR", GetType(String))
            End If
        End If

        If p_TableExec_E5 Is Nothing Then
            p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
        Else
            If p_TableExec_E5.Columns.Count <= 0 Then
                p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
            End If
        End If

        If g_DataMap_cp Is Nothing Then
            Exit Sub
        End If
        '========================================================================================================
        'Kiem tra xem he thong co tact thanh 2 bang scadar khong
        'Neu co phai kiem tra o 2 noi
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "')")

        p_TableName_E5 = ""
        For p_Count = 0 To p_DataRowMap_cp_Old.Length - 1
            If p_TableName_E5 = "" Then
                p_TableName_E5 = UCase(p_DataRowMap_cp_Old(p_Count).Item("TableName").ToString.Trim)
            Else
                If p_TableName_E5 <> UCase(p_DataRowMap_cp_Old(p_Count).Item("TableName").ToString.Trim) Then
                    p_2Scadar = True
                End If
            End If
        Next
        p_TableName_E5 = ""
        For p_Count = 0 To p_DataRowMap_cp_E5.Length - 1
            If p_TableName_E5 = "" Then
                p_TableName_E5 = UCase(p_DataRowMap_cp_E5(p_Count).Item("TableName").ToString.Trim)
            Else
                If p_TableName_E5 <> UCase(p_DataRowMap_cp_E5(p_Count).Item("TableName").ToString.Trim) Then
                    p_2ScadarE5 = True
                End If
            End If
        Next

        If p_2Scadar = True Or p_2ScadarE5 = True Then

            'If g_KV1 = True Then
            '    KV1_modHuyTichKe_2(p_WareHouse, "in", p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, p_Terminal, p_TableExec, p_TableExec_E5)
            'Else
            modHuyTichKe_2(p_WareHouse, "in", p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, p_Terminal, p_TableExec, p_TableExec_E5)
            ' End If

            If p_Error = True Then
                Exit Sub
            End If
            If p_TableExec.Rows.Count > 0 Or p_TableExec_E5.Rows.Count > 0 Then
                p_Desc = "Không hủy được tích kê đã được đẩy sang TĐH in"
                p_Error = True
                Exit Sub
            End If

        End If
        p_TableExec.Clear()
        p_TableExec_E5.Clear()
        '========================================================================================================

        p_TableName_E5 = ""
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "'  or Status='" & UCase(p_TypeIn) & "' ) and (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "')")
        If p_DataRowMap_cp_Old.Length <= 0 Then
            p_Error = True
            p_Desc = "Không có thông tin Map"
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
            p_Error = True
            p_Desc = "Không có thông tin tên bảng Map"
            Exit Sub
        End If
        p_Error = False
        p_Desc = ""

        '20150819
        'Them dieu kien FOX
        '    If UCase(g_TypeConnet) = "FOX" Then
        If g_StrConnectAccess.ToString.Trim = "" Then
            p_Error = True
            p_Desc = "String kết nối đến máy chủ Scadar không xác định"
            Exit Sub
        End If
       
        '  End If

        'If UCase(g_TypeConnet) = "FOX" Then
        '    If g_StrConnectFox.ToString.Trim = "" Then
        '        p_Error = True
        '        p_Desc = "String kết nối đến máy chủ Scadar không xác định"
        '        Exit Sub
        '    End If
        'Else
        '    If g_ConnectToScadar.ToString.Trim = "" Then
        '        p_Error = True
        '        p_Desc = "String kết nối đến máy chủ Scadar không xác định"
        '        Exit Sub
        '    End If
        'End If

        p_TableExec.Clear()
        'If UCase(g_TypeConnet) = "FOX" Then

        '    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
        '        p_TableName = Replace(g_PathFileFoxBo, ".dbf", "", 1)
        '        p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)

        '    Else
        '        p_TableName = Replace(g_PathFileFoxThuy, ".dbf", "", 1)
        '        p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)

        '    End If

        'End If

        If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
            p_TableName = g_PathFileFoxBo
            'p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)

        Else
            p_TableName = g_PathFileFoxThuy
            ' p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)

        End If


        p_TableExec_E5.Clear()

        p_SQL = "exec FPT_GetDataToScadar '" & p_SoLenh.Trim & "'"
        p_DataHTTG = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataHTTG Is Nothing Then
            For p_Count = 0 To p_DataHTTG.Rows.Count - 1

                p_DataRowHTTG = p_DataHTTG.Rows(p_Count)
                If g_TableMaHangHoaE5.Rows.Count <= 0 Then
                    p_Error = True
                    p_Desc = "Không có thông tin lệnh xuất"
                    Exit Sub
                End If
                p_HangHoaE5 = False
                p_MaHangHoa = p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                If p_MaHangHoa.ToString.Trim = g_TableMaHangHoaE5.Rows(0).Item("MaHangHoa_Scada").ToString.Trim And p_DataRowMap_cp_E5.Length > 0 Then
                    p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    p_HangHoaE5 = True
                    If p_DataRowMap_cp.Length <= 0 Then
                        p_Error = True
                        p_Desc = "Không có thông tin bảng Map"
                        Exit Sub
                    End If
                Else
                    'p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_STT = p_DataRowMap_cp_Old(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    If p_DataRowMap_cp.Length <= 0 Then
                        p_Error = True
                        p_Desc = "Không có thông tin bảng Map"
                        Exit Sub
                    End If
                End If

                p_Where_Check = ""
                p_whereDelete = ""

                For p_CountRow = 0 To p_DataRowMap_cp.Length - 1
                    'Lay kieu du lieu
                    p_FieldType = ""
                    'If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim) = "TABLEID" Then
                    '    MsgBox("")
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
                        p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim

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
                            If p_Value = "" Then
                                p_Value = "0"
                            End If
                            p_StatusType = "<>"
                            If p_Where_Check.ToString.Trim = "" Then
                                'If UCase(g_TypeConnet) = "FOX" Then
                                '    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                '        p_DataRowCheck = g_TableToScadarBo.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")
                                '    Else
                                '        p_DataRowCheck = g_TableToScadarThuy.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")
                                '    End If
                                '    If p_DataRowCheck.Length > 0 Then
                                '        Select Case UCase(p_DataRowCheck(0).Item("FieldType").ToString.Trim)
                                '            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                '                p_Value = p_Value
                                '            Case UCase("String")
                                '                p_Value = "'" & p_Value & "'"
                                '        End Select
                                '        Select Case UCase(g_LoaiVanChuyen)
                                '            Case "BO"
                                '                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "" & p_Value & ""
                                '            Case "THUY"
                                '                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "" & p_Value & ""
                                '            Case "SAT"
                                '                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "" & p_Value & ""
                                '            Case Else
                                '                Continue For
                                '        End Select
                                '    End If
                                'Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select
                                '  End If


                            Else
                                'If UCase(g_TypeConnet) = "FOX" Then
                                '    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                '        p_DataRowCheck = g_TableToScadarBo.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")
                                '    Else
                                '        p_DataRowCheck = g_TableToScadarThuy.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")

                                '    End If
                                '    If p_DataRowCheck.Length > 0 Then
                                '        Select Case UCase(p_DataRowCheck(0).Item("FieldType").ToString.Trim)
                                '            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                '                p_Value = p_Value
                                '            Case UCase("String")
                                '                p_Value = "'" & p_Value & "'"
                                '        End Select
                                '        Select Case UCase(g_LoaiVanChuyen)
                                '            Case "BO"
                                '                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "" & p_Value & ""
                                '            Case "THUY"
                                '                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "" & p_Value & ""
                                '            Case "SAT"
                                '                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "" & p_Value & ""
                                '            Case Else
                                '                Continue For
                                '        End Select
                                '    End If
                                'Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select
                                '  End If

                            End If
                        Continue For
                    End If


                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            Else
                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            End If

                            If p_whereDelete.ToString.Trim = "" Then
                                p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            Else
                                p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            End If


                            Continue For
                        End If
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            p_Value = p_Value.Substring(1, g_MaNgan_DD)
                            If p_Where_Check.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            End If

                            If p_whereDelete.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            End If

                            Continue For
                        End If

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            If UCase(g_TypeConnet) = "ACC" Or p_HangHoaE5 = False Then
                                If p_Where_Check.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "= #" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                    End Select
                                End If

                                If p_whereDelete.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "THUY"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "SAT"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "THUY"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "SAT"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                    End Select
                                End If

                            Else
                                ' End If
                                If p_Where_Check.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    End Select
                                End If
                                If p_whereDelete.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    End Select
                                End If

                            End If
                            Continue For
                        End If
                        '
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
                            'If g_MaTuDongHoa = "N" Then
                            If p_Value.ToString.Trim <> "" Then
                                p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                               p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
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
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            End If

                            If p_whereDelete.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            End If

                            'End If
                            Continue For
                        End If
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MATUDONGHOA" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim

                            If UCase(p_FieldType) = "STRING" Then
                                If p_Where_Check.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    End Select
                                End If

                                If p_whereDelete.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    End Select
                                End If



                            Else
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

                                If p_whereDelete.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
                                        Case "THUY"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
                                        Case "SAT"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
                                        Case "THUY"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
                                        Case "SAT"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
                                    End Select
                                End If

                            End If
                            
                           
                        End If
                        Continue For
                    End If
                Next

                If p_Where_Check.ToString.Trim <> "" Then
                    If p_HangHoaE5 = True Then
                        p_SQL = "select *  from " & p_TableName_E5 & " WHERE " & p_Where_Check
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count > 0 Then
                                p_Desc = "Tích kê đã thực hiện bơm hàng nên không hủy được"
                                p_Error = True
                                Exit Sub
                            End If
                            p_StrExeE5 = "delete from " & p_TableName_E5 & " WHERE " & p_whereDelete
                            p_DataRow = p_TableExec_E5.NewRow
                            p_DataRow.Item(0) = p_StrExeE5
                            p_TableExec_E5.Rows.Add(p_DataRow)
                            Continue For
                        Else
                            p_Desc = p_SQL
                            p_Error = True
                            Exit Sub
                        End If
                    Else
                        p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check
                        'If UCase(g_TypeConnet) = "FOX" Then
                        '    p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                        '    If Not p_DataTableCheckID Is Nothing Then
                        '        If p_DataTableCheckID.Rows.Count > 0 Then
                        '            ' Continue For
                        '            p_Desc = "Tích kê đã thực hiện bơm hàng nên không hủy được"
                        '            p_Error = True
                        '            Exit Sub
                        '        End If
                        '        p_StrExe = "delete * from " & p_TableName & " WHERE " & p_whereDelete
                        '        p_DataRow = p_TableExec.NewRow
                        '        p_DataRow.Item(0) = p_StrExe
                        '        p_TableExec.Rows.Add(p_DataRow)
                        '        Continue For
                        '    Else
                        '        p_Desc = p_SQL
                        '        p_Error = True
                        '        Exit Sub
                        '    End If

                        'End If
                        If UCase(g_TypeConnet) = "ACC" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectAccess, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    ' Continue For
                                    p_Desc = "Tích kê đã thực hiện bơm hàng nên không hủy được"
                                    p_Error = True
                                    Exit Sub
                                End If
                                p_StrExe = "delete * from " & p_TableName & " WHERE " & p_whereDelete
                                p_DataRow = p_TableExec.NewRow
                                p_DataRow.Item(0) = p_StrExe
                                p_TableExec.Rows.Add(p_DataRow)
                                Continue For
                            Else
                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub
                            End If

                        End If
                        If UCase(g_TypeConnet) = "SQL" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    'Continue For
                                    p_Desc = "Tích kê đã thực hiện bơm hàng nên không hủy được"
                                    p_Error = True
                                    Exit Sub
                                End If
                                p_StrExe = "delete  from " & p_TableName & " WHERE " & p_whereDelete
                                p_DataRow = p_TableExec.NewRow
                                p_DataRow.Item(0) = p_StrExe
                                p_TableExec.Rows.Add(p_DataRow)
                                Continue For
                            Else
                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub
                            End If

                        End If

                    End If

                End If
            Next



            If Not p_TableExec Is Nothing Then
                If p_TableExec.Rows.Count > 0 Then
                    If g_DBTYPE = "" Then
                        g_Services.Sys_GetParameterOracle(g_DBTYPE)
                    End If
                    If p_TableExec.Rows.Count > 0 Then
                        If UCase(g_TypeConnet) = "SQL" Then
                            If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar, p_TableExec, p_SQL) = False Then

                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub
                                'Else

                            End If
                        End If

                        If UCase(g_TypeConnet) = "FOX" Then
                            If Sys_Execute_DataTbl_With_Connection(g_StrConnectFox, p_TableExec, p_SQL) = False Then

                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub

                            End If

                        End If
                        If UCase(g_TypeConnet) = "ACC" Then
                            If Sys_Execute_DataTbl_With_Connection(g_StrConnectAccess, p_TableExec, p_SQL) = False Then

                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub

                            End If

                        End If
                    End If
                End If
            End If

            If Not p_TableExec_E5 Is Nothing Then
                If p_TableExec_E5.Rows.Count > 0 Then
                    If g_DBTYPE = "" Then
                        g_Services.Sys_GetParameterOracle(g_DBTYPE)
                    End If
                    If g_DBTYPE = "ORACLE" Then
                        If g_Services.Execute_DataTbl_With_Connection(g_ConnectToScadar, p_TableExec_E5, p_SQL) = False Then
                            'MsgBox(p_SQL)
                            'g_Module.ModErrExceptionNew("", p_SQL)
                            p_Desc = p_SQL
                            p_Error = True
                            Exit Sub
                            ' Else

                        End If
                    ElseIf g_DBTYPE = "SQL" Then
                        If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar_E5, p_TableExec_E5, p_SQL) = False Then
                            'MsgBox(p_SQL)
                            'g_Module.ModErrExceptionNew("", p_SQL)
                            p_Desc = p_SQL
                            p_Error = True
                            Exit Sub
                            'Else
                        End If
                    End If

                End If
            End If

            p_TableExec.Clear()

            p_DataRow = p_TableExec.NewRow
            p_DataRow.Item(0) = "delete from tblTichke where SoLenh='" & p_SoLenh & "'"
            p_TableExec.Rows.Add(p_DataRow)

            ' ReTableID(p_SoLenh, p_TableExec)

            If Left(p_SoLenh, Len(p_WareHouse)) = p_WareHouse Then
                ReTableID(p_SoLenh, p_TableExec)
            End If



            'p_DataRow = p_TableExec.NewRow

            'If Left(p_SoLenh, Len(p_WareHouse)) = p_WareHouse Then
            '    p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set Status='2',UpdatedBy='" & g_UserName & "', GhiChu=N'Hủy tích kê' where SoLenh='" & p_SoLenh & "'"
            'Else
            '    p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set Status='1' , UpdatedBy='" & g_UserName & "', GhiChu=N'Hủy tích kê'  where SoLenh='" & p_SoLenh & "'"
            'End If

            'p_TableExec.Rows.Add(p_DataRow)


            If g_Services.Sys_Execute_DataTbl(p_TableExec, p_SQL) = False Then
                'MsgBox(p_SQL)
                p_Desc = p_SQL
                p_Error = True
                Exit Sub

            End If
            p_TableExec.Clear()

            If Left(p_SoLenh, Len(p_WareHouse)) = p_WareHouse Then
                p_DataRow = p_TableExec.NewRow

                p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set MaPhuongTien=null,NguoiVanChuyen=null , Status='2',UpdatedBy='" & g_UserName & "'  where SoLenh='" & p_SoLenh & "'"

                p_TableExec.Rows.Add(p_DataRow)

                p_DataRow = p_TableExec.NewRow

                p_DataRow.Item(0) = "DELETE FROM  tblLenhXuatChiTietE5  where exists (select 1 from FPT_tblLenhXuat_HangHoaE5_V b " & _
                                        " where (tblLenhXuatChiTietE5.TableID = b.TableID And tblLenhXuatChiTietE5.NgayXuat = b.NgayXuat) 	and b.SoLenh ='" & p_SoLenh & "')"

                p_TableExec.Rows.Add(p_DataRow)


            Else
                'Xoa lenh 
                p_DataRow = p_TableExec.NewRow
                p_SQL = "delete from tblLenhXuatChiTietE5  where " & _
                    " exists (select 1 from tblLenhXuat_HangHoaE5  where tableid=  tblLenhXuatChiTietE5.tableid " & _
                         " and SoLenh='" & p_SoLenh & "')"
                p_DataRow.Item(0) = p_SQL
                p_TableExec.Rows.Add(p_DataRow)
                p_DataRow = p_TableExec.NewRow
                p_SQL = "delete from tblLenhXuat_HangHoaE5  where SoLenh='" & p_SoLenh & "'"
                p_DataRow.Item(0) = p_SQL
                p_TableExec.Rows.Add(p_DataRow)
                p_DataRow = p_TableExec.NewRow
                p_SQL = "delete from tblLenhXuatE5  where SoLenh='" & p_SoLenh & "'"
                p_DataRow.Item(0) = p_SQL
                p_TableExec.Rows.Add(p_DataRow)

            End If

            If g_Services.Sys_Execute_DataTbl(p_TableExec, p_SQL) = False Then
                'MsgBox(p_SQL)
                p_Desc = p_SQL
                p_Error = True
                Exit Sub

            End If
            p_TableExec.Clear()


            'If p_TableExec.Rows.Count > 0 Then
            '    If g_DBTYPE = "ORACLE" Then
            '        If g_Services.Sys_Execute_DataTbl_Oracle(p_TableExec, p_SQL) = False Then
            '            'MsgBox(p_SQL)
            '            p_Desc = p_SQL
            '            p_Error = True
            '            Exit Sub
            '        Else
            '        End If
            '    ElseIf g_DBTYPE = "SQL" Then
            '        If g_Services.Sys_Execute_DataTbl(p_TableExec, p_SQL) = False Then
            '            'MsgBox(p_SQL)
            '            p_Desc = p_SQL
            '            p_Error = True
            '            Exit Sub

            '        End If
            '    End If
            'End If
        End If
    End Sub



    'anhqh
    '20180206
    'Ham thuc hien day them thong tin vao TDH 
    Private Sub B12UpdateToTDH(ByVal p_WareHouse As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                             ByRef p_Error As Boolean, ByRef p_Desc As String, _
                              ByVal p_Terminal As String)
        Dim p_SQL As String
        Dim p_DataHTTG As DataTable
        Dim p_CountRow As Integer
        'Dim p_CountCol As Integer
        Dim p_Count As Integer
        Dim p_DataRowHTTG As DataRow
        Dim p_SQLInsert As String = ""
        Dim p_SQLValue As String = ""
        Dim p_DataRowMap_cp() As DataRow
        Dim p_FieldType As String
        Dim p_Value As String
        Dim p_TableName As String = ""
        Dim p_STT As Integer
        Dim p_StrExe As String
        Dim p_TableExec As New DataTable("Table01")
        Dim p_DataRow As DataRow
        Dim p_DataTableCheckID As DataTable
        Dim p_Where_Check As String  'Dung checkScadar
        Dim p_TableName_E5 As String = ""
        Dim p_DataRowMap_cp_E5() As DataRow
        Dim p_DataRowMap_cp_Old() As DataRow
        Dim p_TableExec_E5 As New DataTable("Table01")
        Dim p_MaHangHoa As String
        Dim p_HangHoaE5 As Boolean
        Dim p_StrExeE5 As String
        Dim p_Flag() As String
        Dim p_StatusType As String
        Dim p_DataRowCheck() As DataRow

        Dim p_2Scadar As Boolean = False
        Dim p_2ScadarE5 As Boolean = False
        Dim p_whereDelete As String = ""

        Dim p_NhietDo As Decimal
        Dim p_TyTrong As Decimal
        Dim p_L15 As Decimal
        Dim p_VCF As Decimal
        Dim p_ThucXuat As Decimal
        Dim p_DuXuat As Decimal
        Dim p_SoLuongTinh As Decimal
        Dim p_Xitec As String = "N"
        Dim p_Bo As String = "0"
        Dim p_Thuy As String = "0"
        Dim p_TblTmp As DataTable
        Dim p_HH As String

        Dim p_TableHangHoa As DataTable
        Dim p_TableLenh As DataTable

        Dim p_DataSet As DataSet

        p_DataRowCheck = g_Table_Sys_Config.Select("KeyCode='TONGDUXUAT'")
        If p_DataRowCheck.Length > 0 Then
            If p_DataRowCheck(0).Item("KEYVALUE").ToString.Trim <> "" Then
                p_Bo = p_DataRowCheck(0).Item("KEYVALUE").ToString.Trim
            End If
        End If


        p_DataRowCheck = g_Table_Sys_Config.Select("KeyCode='TONGDUXUATTHUY'")
        If p_DataRowCheck.Length > 0 Then
            If p_DataRowCheck(0).Item("KEYVALUE").ToString.Trim <> "" Then
                p_Thuy = p_DataRowCheck(0).Item("KEYVALUE").ToString.Trim
            End If
        End If


        If p_TableExec Is Nothing Then
            p_TableExec.Columns.Add("SQL_STR", GetType(String))
        Else
            If p_TableExec.Columns.Count <= 0 Then
                p_TableExec.Columns.Add("SQL_STR", GetType(String))
            End If
        End If

        If p_TableExec_E5 Is Nothing Then
            p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
        Else
            If p_TableExec_E5.Columns.Count <= 0 Then
                p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
            End If
        End If

        If g_DataMap_cp Is Nothing Then
            Exit Sub
        End If
        '========================================================================================================
        'Kiem tra xem he thong co tact thanh 2 bang scadar khong
        'Neu co phai kiem tra o 2 noi
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "')")

        p_TableName_E5 = ""
        For p_Count = 0 To p_DataRowMap_cp_Old.Length - 1
            If p_TableName_E5 = "" Then
                p_TableName_E5 = UCase(p_DataRowMap_cp_Old(p_Count).Item("TableName").ToString.Trim)
            Else
                If p_TableName_E5 <> UCase(p_DataRowMap_cp_Old(p_Count).Item("TableName").ToString.Trim) Then
                    p_2Scadar = True
                End If
            End If
        Next
        p_TableName_E5 = ""
        For p_Count = 0 To p_DataRowMap_cp_E5.Length - 1
            If p_TableName_E5 = "" Then
                p_TableName_E5 = UCase(p_DataRowMap_cp_E5(p_Count).Item("TableName").ToString.Trim)
            Else
                If p_TableName_E5 <> UCase(p_DataRowMap_cp_E5(p_Count).Item("TableName").ToString.Trim) Then
                    p_2ScadarE5 = True
                End If
            End If
        Next

        
        p_TableExec.Clear()
        p_TableExec_E5.Clear()
        '========================================================================================================

        p_TableName_E5 = ""
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "'  or Status='" & UCase(p_TypeIn) & "' ) and (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "')")
        If p_DataRowMap_cp_Old.Length <= 0 Then
            p_Error = True
            p_Desc = "Không có thông tin Map"
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
            p_Error = True
            p_Desc = "Không có thông tin tên bảng Map"
            Exit Sub
        End If
        p_Error = False
        p_Desc = ""

        '20150819
        'Them dieu kien FOX
        '    If UCase(g_TypeConnet) = "FOX" Then
        If g_StrConnectAccess.ToString.Trim = "" Then
            p_Error = True
            p_Desc = "String kết nối đến máy chủ Scadar không xác định"
            Exit Sub
        End If

        p_TableExec.Clear()
     

        If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
            p_TableName = g_PathFileFoxBo
            'p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)

        Else
            p_TableName = g_PathFileFoxThuy
            ' p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)

        End If


        p_TableExec_E5.Clear()


        'AAAAAAAAAAAAAÂ=============================================================================
        'p_SQL = "exec FPT_GetDataToScadar '" & p_SoLenh.Trim & "'"
        'p_DataHTTG = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        p_SQL = "exec FPT_GetDataToScadar '" & p_SoLenh.Trim & _
                "'; select a.*,  (select sum(SoLuongDuXuat) from fpt_tblLenhXuatChiTietE5_V b where a.SoLenh=b.SoLenh " & _
                         " and a.TableId=b.TableID and a.ngayxuat =b.ngayxuat) as TongDuXuat99 " & _
                         " , (select sum(SoLuongThucXuat) from fpt_tblLenhXuatChiTietE5_V b where a.SoLenh=b.SoLenh  " & _
                          " and a.TableId=b.TableID and a.ngayxuat =b.ngayxuat) as TongThucXuat99  " & _
                        " from tbllenhxuat_HangHoae5 a  with (nolock) where  solenh='" & p_SoLenh.Trim & "'" & _
                "; select SoLenh, Xitec_Option, dbo.FPT_GetLoadingSite(MaVanchuyen) as MaVanchuyen   from tbllenhxuate5 with (nolock) where solenh='" & p_SoLenh.Trim & "';"

        '"; select SoLenh, dbo.FPT_GetLoadingSite(MaVanChuyen) as MaVanChuyen, XITEC_OPTION from tbllenhxuate5  with (nolock) where solenh='" & p_SoLenh.Trim & "'"
        p_DataSet = g_Services.Sys_SYS_GET_DATASet_Des(p_SQL, p_SQL)

        p_DataHTTG = p_DataSet.Tables(0)

        If p_DataHTTG.Columns.Contains("VCF") = False Then
            p_DataHTTG.Columns.Add("VCF", GetType(Double))
        End If

        If p_DataHTTG.Columns.Contains("WCF") = False Then
            p_DataHTTG.Columns.Add("WCF", GetType(Double))
        End If

        If p_DataHTTG.Columns.Contains("NhietDo_BQGQ") = False Then
            p_DataHTTG.Columns.Add("NhietDo_BQGQ", GetType(Double))
        End If
        If p_DataHTTG.Columns.Contains("D15_BQGQ") = False Then
            p_DataHTTG.Columns.Add("D15_BQGQ", GetType(Double))
        End If
        If p_DataHTTG.Columns.Contains("KG") = False Then
            p_DataHTTG.Columns.Add("KG", GetType(Double))
        End If
        If p_DataHTTG.Columns.Contains("L15") = False Then
            p_DataHTTG.Columns.Add("L15", GetType(Double))
        End If
        If p_DataHTTG.Columns.Contains("Ltt") = False Then
            p_DataHTTG.Columns.Add("Ltt", GetType(Double))
        End If
        If p_DataHTTG.Columns.Contains("HH") = False Then
            p_DataHTTG.Columns.Add("HH", GetType(String))
        End If
        'p_DataHTTG.Columns.Add("VCF", GetType(Double))
        'p_DataHTTG.Columns.Add("WCF", GetType(Double))
        'p_DataHTTG.Columns.Add("NhietDo_BQGQ", GetType(Double))
        'p_DataHTTG.Columns.Add("D15_BQGQ", GetType(Double))
        'p_DataHTTG.Columns.Add("KG", GetType(Double))
        'p_DataHTTG.Columns.Add("L15", GetType(Double))
        'p_DataHTTG.Columns.Add("Ltt", GetType(Double))
        'p_DataHTTG.Columns.Add("HH", GetType(String))

        p_TableLenh = p_DataSet.Tables(2)
        p_TableHangHoa = p_DataSet.Tables(1)

        p_HH = ""
        For p_CountRow = 0 To p_DataHTTG.Rows.Count - 1
            p_HH = p_HH & "H" & p_DataHTTG.Rows(p_CountRow).Item("MaNgan").ToString.Trim & ":" & p_DataHTTG.Rows(p_CountRow).Item("MaEntry").ToString.Trim & "; "

        Next

        For p_Count = 0 To p_TableHangHoa.Rows.Count - 1
            p_ThucXuat = 0
            p_DuXuat = 0
            p_SoLuongTinh = 0

            p_DuXuat = p_TableHangHoa.Rows(p_Count).Item("TongDuXuat99").ToString
            p_ThucXuat = p_TableHangHoa.Rows(p_Count).Item("TongThucXuat99").ToString
            If p_TableLenh.Rows(0).Item("Xitec_Option").ToString.Trim = "Y" Then
                If p_TableLenh.Rows(0).Item("MaVanchuyen").ToString.Trim = "THUY" Then
                    If p_Thuy = "0" Then
                        p_SoLuongTinh = p_DuXuat
                    Else
                        p_SoLuongTinh = p_ThucXuat

                    End If
                Else
                    If p_Bo = "0" Then
                        p_SoLuongTinh = p_DuXuat
                    Else
                        p_SoLuongTinh = p_ThucXuat

                    End If
                End If
            Else
                If p_TableLenh.Rows(0).Item("MaVanchuyen").ToString.Trim = "THUY" Then
                    If p_Thuy = "0" Then
                        p_SoLuongTinh = p_ThucXuat
                    Else
                        p_SoLuongTinh = p_DuXuat

                    End If
                Else
                    If p_Bo = "0" Then
                        p_SoLuongTinh = p_ThucXuat
                    Else
                        p_SoLuongTinh = p_DuXuat

                    End If
                End If
            End If


            For p_CountRow = 0 To p_DataHTTG.Rows.Count - 1
                If p_DataHTTG.Rows(p_CountRow).Item("MaLenh").ToString = p_TableHangHoa.Rows(p_Count).Item("MaLenh").ToString _
                    And p_DataHTTG.Rows(p_CountRow).Item("TableID").ToString = p_TableHangHoa.Rows(p_Count).Item("TableID").ToString _
                    And p_DataHTTG.Rows(p_CountRow).Item("LineID").ToString = p_TableHangHoa.Rows(p_Count).Item("LineID").ToString _
                     And p_DataHTTG.Rows(p_CountRow).Item("NgayXuat") = p_TableHangHoa.Rows(p_Count).Item("NgayXuat") Then

                    Decimal.TryParse(p_TableHangHoa.Rows(p_Count).Item("NhietDo_BQGQ").ToString, p_NhietDo)
                    p_DataHTTG.Rows(p_CountRow).Item("NhietDo_BQGQ") = p_NhietDo

                    Decimal.TryParse(p_TableHangHoa.Rows(p_Count).Item("D15_BQGQ").ToString, p_NhietDo)
                    p_DataHTTG.Rows(p_CountRow).Item("D15_BQGQ") = p_NhietDo

                    Decimal.TryParse(p_TableHangHoa.Rows(p_Count).Item("VCF").ToString, p_NhietDo)
                    p_DataHTTG.Rows(p_CountRow).Item("VCF") = p_NhietDo

                    Decimal.TryParse(p_TableHangHoa.Rows(p_Count).Item("WCF").ToString, p_NhietDo)
                    p_DataHTTG.Rows(p_CountRow).Item("WCF") = p_NhietDo

                    Decimal.TryParse(p_TableHangHoa.Rows(p_Count).Item("KG").ToString, p_NhietDo)
                    p_DataHTTG.Rows(p_CountRow).Item("KG") = p_NhietDo

                    Decimal.TryParse(p_TableHangHoa.Rows(p_Count).Item("L15").ToString, p_NhietDo)
                    p_DataHTTG.Rows(p_CountRow).Item("L15") = p_NhietDo

                    p_DataHTTG.Rows(p_CountRow).Item("Ltt") = p_SoLuongTinh

                    p_DataHTTG.Rows(p_CountRow).Item("HH") = p_HH
                End If
            Next

            
        Next




        If Not p_DataHTTG Is Nothing Then
            
            For p_Count = 0 To p_DataHTTG.Rows.Count - 1

                p_DataRowHTTG = p_DataHTTG.Rows(p_Count)
                If g_TableMaHangHoaE5.Rows.Count <= 0 Then
                    p_Error = True
                    p_Desc = "Không có thông tin lệnh xuất"
                    Exit Sub
                End If
                p_HangHoaE5 = False
                p_MaHangHoa = p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                If p_MaHangHoa.ToString.Trim = g_TableMaHangHoaE5.Rows(0).Item("MaHangHoa_Scada").ToString.Trim Then
                    p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    p_HangHoaE5 = True
                    If p_DataRowMap_cp.Length <= 0 Then
                        p_Error = True
                        p_Desc = "Không có thông tin bảng Map"
                        Exit Sub
                    End If
                Else
                    'p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_STT = p_DataRowMap_cp_Old(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    If p_DataRowMap_cp.Length <= 0 Then
                        p_Error = True
                        p_Desc = "Không có thông tin bảng Map"
                        Exit Sub
                    End If
                End If

                p_Where_Check = ""
                p_whereDelete = ""

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
                        p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim

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
                            If p_Value = "" Then
                                p_Value = "0"
                            End If
                            p_StatusType = "<>"
                            If p_Where_Check.ToString.Trim = "" Then

                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select
                                '  End If


                            Else

                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                    Case Else
                                        Continue For
                                End Select
                                '  End If

                            End If
                            Continue For
                        End If


                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            Else
                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            End If

                            If p_whereDelete.ToString.Trim = "" Then
                                p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            Else
                                p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            End If


                            Continue For
                        End If
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            p_Value = p_Value.Substring(1, g_MaNgan_DD)
                            If p_Where_Check.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            End If

                            If p_whereDelete.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            End If

                            Continue For
                        End If

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            If UCase(g_TypeConnet) = "ACC" Or p_HangHoaE5 = False Then
                                If p_Where_Check.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "= #" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                    End Select
                                End If

                                If p_whereDelete.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "THUY"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "SAT"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "THUY"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                        Case "SAT"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=#" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "#"
                                    End Select
                                End If

                            Else
                                ' End If
                                If p_Where_Check.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    End Select
                                End If
                                If p_whereDelete.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    End Select
                                End If

                            End If
                            Continue For
                        End If
                        '
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
                            'If g_MaTuDongHoa = "N" Then
                            If p_Value.ToString.Trim <> "" Then
                                p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                               p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
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
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            End If

                            If p_whereDelete.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            End If

                            'End If
                            Continue For
                        End If
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MATUDONGHOA" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim

                            If UCase(p_FieldType) = "STRING" Then
                                If p_Where_Check.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    End Select
                                End If

                                If p_whereDelete.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    End Select
                                End If



                            Else
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

                                If p_whereDelete.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
                                        Case "THUY"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
                                        Case "SAT"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
                                        Case "THUY"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
                                        Case "SAT"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
                                    End Select
                                End If

                            End If


                        End If
                        Continue For
                    End If
                Next

                If p_Where_Check.ToString.Trim <> "" Then
                    If p_HangHoaE5 = True Then
                        p_SQL = "select *  from " & p_TableName_E5 & " WHERE " & p_Where_Check
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count > 0 Then

                                'anhqh 
                                '20180207
                                '=================================================================================================
                                '' p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim
                                'p_DataHTTG.Columns.Add("VCF", GetType(Double))
                                'p_DataHTTG.Columns.Add("WCF", GetType(Double))
                                'p_DataHTTG.Columns.Add("NhietDo_BQGQ", GetType(Double))
                                'p_DataHTTG.Columns.Add("D15_BQGQ", GetType(Double))
                                'p_DataHTTG.Columns.Add("KG", GetType(Double))
                                'p_DataHTTG.Columns.Add("L15", GetType(Double))
                                p_StrExe = "Update " & p_TableName_E5 & " set " & _
                                            " VCF =" & p_DataRowHTTG.Item("VCF").ToString.Trim & _
                                            ", WCF =" & p_DataRowHTTG.Item("WCF").ToString.Trim & _
                                             ", T0_BQGQ =" & p_DataRowHTTG.Item("NhietDo_BQGQ").ToString.Trim & _
                                             ", D15_BQGQ =" & p_DataRowHTTG.Item("D15_BQGQ").ToString.Trim & _
                                             ", KG =" & p_DataRowHTTG.Item("KG").ToString.Trim & _
                                             ", L15 =" & p_DataRowHTTG.Item("L15").ToString.Trim & _
                                              ", Ltt =" & p_DataRowHTTG.Item("Ltt").ToString.Trim & _
                                              ", HH ='" & p_DataRowHTTG.Item("HH").ToString.Trim & "'" & _
                                                " WHERE " & p_whereDelete


                                ' p_StrExeE5 = "delete from " & p_TableName_E5 & " WHERE " & p_whereDelete
                                p_DataRow = p_TableExec_E5.NewRow
                                p_DataRow.Item(0) = p_StrExe
                                p_TableExec_E5.Rows.Add(p_DataRow)
                                Continue For
                                '  Exit Sub
                            End If
                            
                        Else
                            p_Desc = p_SQL
                            p_Error = True
                            Exit Sub
                        End If
                    Else
                        p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check

                        ' If UCase(g_TypeConnet) = "ACC" Then
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectAccess, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count > 0 Then

                                'anhqh 
                                '20180207
                                '=================================================================================================
                                '' p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim
                                'p_DataHTTG.Columns.Add("VCF", GetType(Double))
                                'p_DataHTTG.Columns.Add("WCF", GetType(Double))
                                'p_DataHTTG.Columns.Add("NhietDo_BQGQ", GetType(Double))
                                'p_DataHTTG.Columns.Add("D15_BQGQ", GetType(Double))
                                'p_DataHTTG.Columns.Add("KG", GetType(Double))
                                'p_DataHTTG.Columns.Add("L15", GetType(Double))
                                p_StrExe = "Update " & p_TableName & " set " & _
                                            " VCF =" & p_DataRowHTTG.Item("VCF").ToString.Trim & _
                                            ", WCF =" & p_DataRowHTTG.Item("WCF").ToString.Trim & _
                                             ", T0_BQGQ =" & p_DataRowHTTG.Item("NhietDo_BQGQ").ToString.Trim & _
                                             ", D15_BQGQ =" & p_DataRowHTTG.Item("D15_BQGQ").ToString.Trim & _
                                             ", KG =" & p_DataRowHTTG.Item("KG").ToString.Trim & _
                                             ", L15 =" & p_DataRowHTTG.Item("L15").ToString.Trim & _
                                             ", Ltt =" & p_DataRowHTTG.Item("Ltt").ToString.Trim & _
                                              ", HH ='" & p_DataRowHTTG.Item("HH").ToString.Trim & "'" & _
                                                " WHERE " & p_whereDelete
                                'p_StrExe = "delete * from " & p_TableName & " WHERE " & p_whereDelete
                                p_DataRow = p_TableExec.NewRow
                                p_DataRow.Item(0) = p_StrExe
                                p_TableExec.Rows.Add(p_DataRow)
                                Continue For
                            End If
                        Else
                            p_Desc = p_SQL
                            p_Error = True
                            Exit Sub
                        End If

                        'If


                    End If

                End If
            Next



            If Not p_TableExec Is Nothing Then
                If p_TableExec.Rows.Count > 0 Then
                    If g_DBTYPE = "" Then
                        g_Services.Sys_GetParameterOracle(g_DBTYPE)
                    End If
                    If p_TableExec.Rows.Count > 0 Then
                        If UCase(g_TypeConnet) = "SQL" Then
                            If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar, p_TableExec, p_SQL) = False Then

                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub
                                'Else

                            End If
                        End If

                        If UCase(g_TypeConnet) = "FOX" Then
                            If Sys_Execute_DataTbl_With_Connection(g_StrConnectFox, p_TableExec, p_SQL) = False Then

                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub

                            End If

                        End If
                        If UCase(g_TypeConnet) = "ACC" Then
                            If Sys_Execute_DataTbl_With_Connection(g_StrConnectAccess, p_TableExec, p_SQL) = False Then

                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub

                            End If

                        End If
                    End If
                End If
            End If

            If Not p_TableExec_E5 Is Nothing Then
                If p_TableExec_E5.Rows.Count > 0 Then
                    If g_DBTYPE = "" Then
                        g_Services.Sys_GetParameterOracle(g_DBTYPE)
                    End If
                    If g_DBTYPE = "ORACLE" Then
                        If g_Services.Execute_DataTbl_With_Connection(g_ConnectToScadar, p_TableExec_E5, p_SQL) = False Then
                            'MsgBox(p_SQL)
                            'g_Module.ModErrExceptionNew("", p_SQL)
                            p_Desc = p_SQL
                            p_Error = True
                            Exit Sub
                            ' Else

                        End If
                    ElseIf g_DBTYPE = "SQL" Then
                        If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar_E5, p_TableExec_E5, p_SQL) = False Then
                            'MsgBox(p_SQL)
                            'g_Module.ModErrExceptionNew("", p_SQL)
                            p_Desc = p_SQL
                            p_Error = True
                            Exit Sub
                            'Else
                        End If
                    End If

                End If
            End If

            p_TableExec.Clear()
          
        End If
    End Sub


    Private Sub KV1modHuyTichKe(ByVal p_WareHouse As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                             ByRef p_Error As Boolean, ByRef p_Desc As String, _
                              ByVal p_Terminal As String)
        Dim p_SQL As String
        Dim p_DataHTTG As DataTable
        Dim p_CountRow As Integer
        'Dim p_CountCol As Integer
        Dim p_Count As Integer
        Dim p_DataRowHTTG As DataRow
        Dim p_SQLInsert As String = ""
        Dim p_SQLValue As String = ""
        Dim p_DataRowMap_cp() As DataRow
        Dim p_FieldType As String
        Dim p_Value As String
        Dim p_TableName As String = ""
        Dim p_STT As Integer
        Dim p_StrExe As String
        Dim p_TableExec As New DataTable("Table01")
        Dim p_DataRow As DataRow
        Dim p_DataTableCheckID As DataTable
        Dim p_Where_Check As String  'Dung checkScadar
        Dim p_TableName_E5 As String = ""
        Dim p_DataRowMap_cp_E5() As DataRow
        Dim p_DataRowMap_cp_Old() As DataRow
        Dim p_TableExec_E5 As New DataTable("Table01")
        Dim p_MaHangHoa As String
        Dim p_HangHoaE5 As Boolean
        Dim p_StrExeE5 As String
        Dim p_Flag() As String
        Dim p_StatusType As String
        Dim p_DataRowCheck() As DataRow

        Dim p_2Scadar As Boolean = False
        Dim p_2ScadarE5 As Boolean = False
        Dim p_whereDelete As String = ""

        If p_TableExec Is Nothing Then
            p_TableExec.Columns.Add("SQL_STR", GetType(String))
        Else
            If p_TableExec.Columns.Count <= 0 Then
                p_TableExec.Columns.Add("SQL_STR", GetType(String))
            End If
        End If

        If p_TableExec_E5 Is Nothing Then
            p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
        Else
            If p_TableExec_E5.Columns.Count <= 0 Then
                p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
            End If
        End If

        If g_DataMap_cp Is Nothing Then
            Exit Sub
        End If
        '========================================================================================================
        'Kiem tra xem he thong co tact thanh 2 bang scadar khong
        'Neu co phai kiem tra o 2 noi
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "')")

        p_TableName_E5 = ""
        For p_Count = 0 To p_DataRowMap_cp_Old.Length - 1
            If p_TableName_E5 = "" Then
                p_TableName_E5 = UCase(p_DataRowMap_cp_Old(p_Count).Item("TableName").ToString.Trim)
            Else
                If p_TableName_E5 <> UCase(p_DataRowMap_cp_Old(p_Count).Item("TableName").ToString.Trim) Then
                    p_2Scadar = True
                End If
            End If
        Next
        p_TableName_E5 = ""
        For p_Count = 0 To p_DataRowMap_cp_E5.Length - 1
            If p_TableName_E5 = "" Then
                p_TableName_E5 = UCase(p_DataRowMap_cp_E5(p_Count).Item("TableName").ToString.Trim)
            Else
                If p_TableName_E5 <> UCase(p_DataRowMap_cp_E5(p_Count).Item("TableName").ToString.Trim) Then
                    p_2ScadarE5 = True
                End If
            End If
        Next

        If p_2Scadar = True Or p_2ScadarE5 = True Then

            'If g_KV1 = True Then
            '    KV1_modHuyTichKe_2(p_WareHouse, "in", p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, p_Terminal, p_TableExec, p_TableExec_E5)
            'Else
            KV1_modHuyTichKe_2(p_WareHouse, "in", p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, p_Terminal, p_TableExec, p_TableExec_E5)
            ' End If

            If p_Error = True Then
                Exit Sub
            End If
            If p_TableExec.Rows.Count > 0 Or p_TableExec_E5.Rows.Count > 0 Then
                p_Desc = "Không hủy được tích kê đã được đẩy sang TĐH in"
                p_Error = True
                Exit Sub
            End If

        End If
        p_TableExec.Clear()
        p_TableExec_E5.Clear()
        '========================================================================================================
        'p_TypeIn = "in"
        p_TableName_E5 = ""
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "'  or Status='" & UCase(p_TypeIn) & "' ) and (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "')")
        If p_DataRowMap_cp_Old.Length <= 0 Then
            p_Error = True
            p_Desc = "Không có thông tin Map"
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
            p_Error = True
            p_Desc = "Không có thông tin tên bảng Map"
            Exit Sub
        End If
        p_Error = False
        p_Desc = ""

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


        p_TableExec.Clear()
        If UCase(g_TypeConnet) = "FOX" Then

            If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                p_TableName = Replace(g_PathFileFoxBo, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)

            Else
                p_TableName = Replace(g_PathFileFoxThuy, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)

            End If

        End If


        p_TableExec_E5.Clear()

        p_SQL = "exec FPT_GetDataToScadar '" & p_SoLenh.Trim & "'"
        p_DataHTTG = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataHTTG Is Nothing Then
            For p_Count = 0 To p_DataHTTG.Rows.Count - 1

                p_DataRowHTTG = p_DataHTTG.Rows(p_Count)
                If g_TableMaHangHoaE5.Rows.Count <= 0 Then
                    p_Error = True
                    p_Desc = "Không có thông tin lệnh xuất"
                    Exit Sub
                End If
                p_HangHoaE5 = False
                p_MaHangHoa = p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                If p_MaHangHoa.ToString.Trim = g_TableMaHangHoaE5.Rows(0).Item("MaHangHoa_Scada").ToString.Trim Then
                    p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    p_HangHoaE5 = True
                    If p_DataRowMap_cp.Length <= 0 Then
                        p_Error = True
                        p_Desc = "Không có thông tin bảng Map"
                        Exit Sub
                    End If
                Else
                    'p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_STT = p_DataRowMap_cp_Old(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    If p_DataRowMap_cp.Length <= 0 Then
                        p_Error = True
                        p_Desc = "Không có thông tin bảng Map"
                        Exit Sub
                    End If
                End If

                p_Where_Check = ""
                p_whereDelete = ""

                For p_CountRow = 0 To p_DataRowMap_cp.Length - 1
                    'Lay kieu du lieu
                    p_FieldType = ""
                    'If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").ToString.Trim) = "TABLEID" Then
                    '    MsgBox("")
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
                        p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "FLAG1" Then
                            If p_HangHoaE5 = True Then
                                p_Value = p_DataRowMap_cp_E5(0).Item("FlagBegin").ToString.Trim
                                p_Flag = p_Value.Split(".")
                                If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                    p_Value = p_Flag(0)
                                Else
                                    p_Value = p_Flag(1)
                                End If
                                If p_Value = "" Then
                                    p_Value = "0"
                                End If
                                p_StatusType = "<>"
                            Else
                                p_Value = "3"
                                ' Continue For
                                'p_Value = p_DataRowMap_cp_Old(0).Item("FlagBegin").ToString.Trim
                                'p_Flag = p_Value.Split(".")
                                'If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                                '    p_Value = p_Flag(0)
                                'Else
                                '    p_Value = p_Flag(1)
                                'End If
                                If p_Value = "" Then
                                    p_Value = "0"
                                End If
                                p_StatusType = "="
                            End If
                           
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
                                            p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "))" & p_StatusType & "'" & p_Value & "'"
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
                                            p_Where_Check = p_Where_Check & " AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                        Case Else
                                            Continue For
                                    End Select
                                End If

                            End If
                            Continue For
                        End If


                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            Else
                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            End If

                            If p_whereDelete.ToString.Trim = "" Then
                                p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            Else
                                p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                            End If


                            Continue For
                        End If
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            p_Value = p_Value.Substring(1, g_MaNgan_DD)
                            If p_Where_Check.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            End If

                            If p_whereDelete.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            End If

                            Continue For
                        End If

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            If UCase(g_TypeConnet) = "FOX" And p_HangHoaE5 = False Then
                                If p_Where_Check.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                    End Select
                                End If

                                If p_whereDelete.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "THUY"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "SAT"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "THUY"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "SAT"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                    End Select
                                End If

                            Else
                                ' End If
                                If p_Where_Check.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    End Select
                                End If
                                If p_whereDelete.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    End Select
                                End If

                            End If
                            Continue For
                        End If
                        '
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
                            'If g_MaTuDongHoa = "N" Then
                            If p_Value.ToString.Trim <> "" Then

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


                                '   p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                ' p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
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
                                    '  p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
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

                                    p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                                    If Not p_DataTableCheckID Is Nothing Then
                                        If p_DataTableCheckID.Rows.Count > 0 Then
                                            p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                                        End If
                                    End If
                                End If
                            End If
                            If p_Where_Check.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            End If

                            If p_whereDelete.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            End If

                            'End If
                            Continue For
                        End If
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
                            If p_whereDelete.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
                                    Case "THUY"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
                                    Case "SAT"
                                        p_whereDelete = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_whereDelete = p_whereDelete & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
                                    Case "THUY"
                                        p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
                                    Case "SAT"
                                        p_whereDelete = p_whereDelete & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
                                End Select
                            End If

                        End If
                        Continue For
                    End If
                Next

                If p_Where_Check.ToString.Trim <> "" Then
                    If p_HangHoaE5 = True Then
                        p_SQL = "select *  from " & p_TableName_E5 & " WHERE " & p_Where_Check
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count > 0 Then
                                p_Desc = "Tích kê đã thực hiện bơm hàng nên không hủy được"
                                p_Error = True
                                Exit Sub
                            End If
                            p_StrExeE5 = "delete from " & p_TableName_E5 & " WHERE " & p_whereDelete
                            p_DataRow = p_TableExec_E5.NewRow
                            p_DataRow.Item(0) = p_StrExeE5
                            p_TableExec_E5.Rows.Add(p_DataRow)
                            Continue For
                        Else
                            p_Desc = p_SQL
                            p_Error = True
                            Exit Sub
                        End If
                    Else
                        p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check
                        If UCase(g_TypeConnet) = "FOX" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    ' Continue For
                                    p_Desc = "Tích kê đã thực hiện bơm hàng nên không hủy được"
                                    p_Error = True
                                    Exit Sub
                                End If
                                p_StrExe = "delete * from " & p_TableName & " WHERE " & p_whereDelete
                                p_DataRow = p_TableExec.NewRow
                                p_DataRow.Item(0) = p_StrExe
                                p_TableExec.Rows.Add(p_DataRow)
                                Continue For
                            Else
                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub
                            End If

                        End If
                        If UCase(g_TypeConnet) = "SQL" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    'Continue For
                                    p_Desc = "Tích kê đã thực hiện bơm hàng nên không hủy được"
                                    p_Error = True
                                    Exit Sub
                                End If
                                p_StrExe = "delete  from " & p_TableName & " WHERE " & p_whereDelete
                                p_DataRow = p_TableExec.NewRow
                                p_DataRow.Item(0) = p_StrExe
                                p_TableExec.Rows.Add(p_DataRow)
                                Continue For
                            Else
                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub
                            End If

                        End If

                    End If

                End If
            Next



            If Not p_TableExec Is Nothing Then
                If p_TableExec.Rows.Count > 0 Then
                    If g_DBTYPE = "" Then
                        g_Services.Sys_GetParameterOracle(g_DBTYPE)
                    End If
                    If p_TableExec.Rows.Count > 0 Then
                        If UCase(g_TypeConnet) = "SQL" Then
                            If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar, p_TableExec, p_SQL) = False Then

                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub
                                'Else

                            End If
                        End If

                        If UCase(g_TypeConnet) = "FOX" Then
                            If Sys_Execute_DataTbl_With_Connection(g_StrConnectFox, p_TableExec, p_SQL) = False Then

                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub

                            End If

                        End If

                    End If
                End If
            End If

            If Not p_TableExec_E5 Is Nothing Then
                If p_TableExec_E5.Rows.Count > 0 Then
                    If g_DBTYPE = "" Then
                        g_Services.Sys_GetParameterOracle(g_DBTYPE)
                    End If
                    If g_DBTYPE = "ORACLE" Then
                        If g_Services.Execute_DataTbl_With_Connection(g_ConnectToScadar, p_TableExec_E5, p_SQL) = False Then
                            'MsgBox(p_SQL)
                            'g_Module.ModErrExceptionNew("", p_SQL)
                            p_Desc = p_SQL
                            p_Error = True
                            Exit Sub
                            ' Else

                        End If
                    ElseIf g_DBTYPE = "SQL" Then
                        If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar_E5, p_TableExec_E5, p_SQL) = False Then
                            'MsgBox(p_SQL)
                            'g_Module.ModErrExceptionNew("", p_SQL)
                            p_Desc = p_SQL
                            p_Error = True
                            Exit Sub
                            'Else
                        End If
                    End If

                End If
            End If

            p_TableExec.Clear()

            p_DataRow = p_TableExec.NewRow
            p_DataRow.Item(0) = "delete from tblTichke where SoLenh='" & p_SoLenh & "'"
            p_TableExec.Rows.Add(p_DataRow)

            If Left(p_SoLenh, Len(p_WareHouse)) = p_WareHouse Then
                ReTableID(p_SoLenh, p_TableExec)
            End If

            'p_DataRow = p_TableExec.NewRow

            'If Left(p_SoLenh, Len(p_WareHouse)) = p_WareHouse Then
            '    p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set Status='2',UpdatedBy='" & g_UserName & "', GhiChu=N'Hủy tích kê' where SoLenh='" & p_SoLenh & "'"
            'Else
            '    p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set Status='1' , UpdatedBy='" & g_UserName & "', GhiChu=N'Hủy tích kê'  where SoLenh='" & p_SoLenh & "'"
            'End If

            'p_TableExec.Rows.Add(p_DataRow)


            If g_Services.Sys_Execute_DataTbl(p_TableExec, p_SQL) = False Then
                'MsgBox(p_SQL)
                p_Desc = p_SQL
                p_Error = True
                Exit Sub

            End If
            p_TableExec.Clear()

            If Left(p_SoLenh, Len(p_WareHouse)) = p_WareHouse Then
                p_DataRow = p_TableExec.NewRow
                p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set MaPhuongTien=null,NguoiVanChuyen=null , Status='2',UpdatedBy='" & g_UserName & "'  where SoLenh='" & p_SoLenh & "'"

                p_TableExec.Rows.Add(p_DataRow)

                p_DataRow = p_TableExec.NewRow

                p_DataRow.Item(0) = "DELETE FROM  tblLenhXuatChiTietE5  where exists (select 1 from FPT_tblLenhXuat_HangHoaE5_V b " & _
                                        " where (tblLenhXuatChiTietE5.TableID = b.TableID And tblLenhXuatChiTietE5.NgayXuat = b.NgayXuat) 	and b.SoLenh ='" & p_SoLenh & "')"

                p_TableExec.Rows.Add(p_DataRow)


            Else
                'Xoa lenh 
                p_DataRow = p_TableExec.NewRow
                p_SQL = "delete from tblLenhXuatChiTietE5  where " & _
                    " exists (select 1 from tblLenhXuat_HangHoaE5  where tableid=  tblLenhXuatChiTietE5.tableid " & _
                         " and SoLenh='" & p_SoLenh & "')"
                p_DataRow.Item(0) = p_SQL
                p_TableExec.Rows.Add(p_DataRow)
                p_DataRow = p_TableExec.NewRow
                p_SQL = "delete from tblLenhXuat_HangHoaE5  where SoLenh='" & p_SoLenh & "'"
                p_DataRow.Item(0) = p_SQL
                p_TableExec.Rows.Add(p_DataRow)
                p_DataRow = p_TableExec.NewRow
                p_SQL = "delete from tblLenhXuatE5  where SoLenh='" & p_SoLenh & "'"
                p_DataRow.Item(0) = p_SQL
                p_TableExec.Rows.Add(p_DataRow)

            End If

            If g_Services.Sys_Execute_DataTbl(p_TableExec, p_SQL) = False Then
                'MsgBox(p_SQL)
                p_Desc = p_SQL
                p_Error = True
                Exit Sub

            End If
            p_TableExec.Clear()


            'If p_TableExec.Rows.Count > 0 Then
            '    If g_DBTYPE = "ORACLE" Then
            '        If g_Services.Sys_Execute_DataTbl_Oracle(p_TableExec, p_SQL) = False Then
            '            'MsgBox(p_SQL)
            '            p_Desc = p_SQL
            '            p_Error = True
            '            Exit Sub
            '        Else
            '        End If
            '    ElseIf g_DBTYPE = "SQL" Then
            '        If g_Services.Sys_Execute_DataTbl(p_TableExec, p_SQL) = False Then
            '            'MsgBox(p_SQL)
            '            p_Desc = p_SQL
            '            p_Error = True
            '            Exit Sub

            '        End If
            '    End If
            'End If
        End If
    End Sub


    Sub ReTableID(ByVal p_SoLenh As String, ByRef p_ExeTable As System.Data.DataTable)
        Dim p_DataTable As DataTable
        Dim p_DataTable1 As DataTable
        Dim p_DataTable_Row As DataTable

        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_Count_Row As Integer
        Dim p_TableID As String
        Dim l_malenh As String
        ' Dim p_ExeTable As New DataTable("Table01")
        Dim p_Row As DataRow
        Dim p_DataSet As DataSet

        p_SQL = "SELECT  TableID, LineID,NgayXuat,MaLenh FROM tblLenhXuat_HangHoaE5 with (nolock) WHERE SoLenh='" & p_SoLenh.ToString.Trim & "';" & _
                             "select * from tblLenhXuatE5 where SoLenh='" & p_SoLenh.ToString.Trim & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If p_DataSet Is Nothing Then
            Exit Sub
        End If
        'p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        p_DataTable = p_DataSet.Tables(0)
        p_DataTable1 = p_DataSet.Tables(1)
        If Not p_DataTable Is Nothing Then
            For p_Count = 0 To p_DataTable.Rows.Count - 1
                If g_KV1 = True Then
                    p_TableID = GetTableIDKV1(p_DataTable1.Rows(0).Item("MaVanChuyen").ToString.Trim, p_DataTable1.Rows(0).Item("NgayXuat"))
                Else
                    p_TableID = GetTableID()
                End If

                'p_SQL = "SELECT  TableID FROM tblLenhXuatChiTietE5 with (nolock) WHERE TableID='" & p_DataTable.Rows(p_Count).Item("TableID").ToString.Trim & "'"
                'p_DataTable_Row = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                'If Not p_DataTable_Row Is Nothing Then

                'End If
                If p_TableID.ToString.Trim <> "" Then
                    p_Row = p_ExeTable.NewRow
                    p_Row.Item(0) = "Update tblLenhXuatChiTietE5 set TableID='" & p_TableID & "' where TableID='" & p_DataTable.Rows(p_Count).Item("TableID").ToString.Trim & "'" & _
                                        " and LineID ='" & p_DataTable.Rows(p_Count).Item("LineID").ToString.Trim & "' " & _
                                        " and MaLenh ='" & p_DataTable.Rows(p_Count).Item("MaLenh").ToString.Trim & "' " & _
                                        " and NgayXuat ='" & p_DataTable.Rows(p_Count).Item("NgayXuat").ToString.Trim & "' " & _
                                        " "
                    p_ExeTable.Rows.Add(p_Row)
                    p_Row = p_ExeTable.NewRow
                    p_Row.Item(0) = "Update tblLenhXuat_HangHoaE5 set TableID='" & p_TableID & "' where TableID='" & p_DataTable.Rows(p_Count).Item("TableID").ToString.Trim & "'" & _
                                     " and LineID ='" & p_DataTable.Rows(p_Count).Item("LineID").ToString.Trim & "' " & _
                                        " and MaLenh ='" & p_DataTable.Rows(p_Count).Item("MaLenh").ToString.Trim & "' " & _
                                        " and NgayXuat ='" & p_DataTable.Rows(p_Count).Item("NgayXuat").ToString.Trim & "' "
                    p_ExeTable.Rows.Add(p_Row)
                End If

            Next
            'l_malenh = FPT_GetMaLenh(p_SoLenh.ToString.Trim)

            'p_Row = p_ExeTable.NewRow
            'p_Row.Item(0) = "Update tblLenhXuat_HangHoaE5 set TableID='" & p_TableID & "' where TableID='" & p_DataTable.Rows(p_Count).Item("TableID").ToString.Trim & "'"
            'p_ExeTable.Rows.Add(p_Row)
            'If p_ExeTable.Rows.Count > 0 Then

            'End If
        End If
    End Sub

    Sub ReTableID_backup20171201(ByVal p_SoLenh As String, ByRef p_ExeTable As System.Data.DataTable)
        Dim p_DataTable As DataTable
        Dim p_DataTable1 As DataTable
        Dim p_DataTable_Row As DataTable

        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_Count_Row As Integer
        Dim p_TableID As String
        Dim l_malenh As String
        ' Dim p_ExeTable As New DataTable("Table01")
        Dim p_Row As DataRow
        Dim p_DataSet As DataSet

        p_SQL = "SELECT  TableID FROM tblLenhXuat_HangHoaE5 with (nolock) WHERE SoLenh='" & p_SoLenh.ToString.Trim & "';" & _
                             "select * from tblLenhXuatE5 where SoLenh='" & p_SoLenh.ToString.Trim & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If p_DataSet Is Nothing Then
            Exit Sub
        End If
        'p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        p_DataTable = p_DataSet.Tables(0)
        p_DataTable1 = p_DataSet.Tables(1)
        If Not p_DataTable Is Nothing Then
            For p_Count = 0 To p_DataTable.Rows.Count - 1
                If g_KV1 = True Then
                    p_TableID = GetTableIDKV1(p_DataTable1.Rows(0).Item("MaVanChuyen").ToString.Trim, p_DataTable1.Rows(0).Item("NgayXuat"))
                Else
                    p_TableID = GetTableID()
                End If

                'p_SQL = "SELECT  TableID FROM tblLenhXuatChiTietE5 with (nolock) WHERE TableID='" & p_DataTable.Rows(p_Count).Item("TableID").ToString.Trim & "'"
                'p_DataTable_Row = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                'If Not p_DataTable_Row Is Nothing Then

                'End If
                If p_TableID.ToString.Trim <> "" Then
                    p_Row = p_ExeTable.NewRow
                    p_Row.Item(0) = "Update tblLenhXuatChiTietE5 set TableID='" & p_TableID & "' where TableID='" & p_DataTable.Rows(p_Count).Item("TableID").ToString.Trim & "'"
                    p_ExeTable.Rows.Add(p_Row)
                    p_Row = p_ExeTable.NewRow
                    p_Row.Item(0) = "Update tblLenhXuat_HangHoaE5 set TableID='" & p_TableID & "' where TableID='" & p_DataTable.Rows(p_Count).Item("TableID").ToString.Trim & "'"
                    p_ExeTable.Rows.Add(p_Row)
                End If

            Next
            'l_malenh = FPT_GetMaLenh(p_SoLenh.ToString.Trim)

            'p_Row = p_ExeTable.NewRow
            'p_Row.Item(0) = "Update tblLenhXuat_HangHoaE5 set TableID='" & p_TableID & "' where TableID='" & p_DataTable.Rows(p_Count).Item("TableID").ToString.Trim & "'"
            'p_ExeTable.Rows.Add(p_Row)
            'If p_ExeTable.Rows.Count > 0 Then

            'End If
        End If
    End Sub
    '2
    Private Function GetTableID() As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_FunctionTableId As String = ""

        p_SQL = "select * from SYS_CONFIG where KEYCODE='TABLEID'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                p_FunctionTableId = p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim
            End If
        End If

        p_SQL = " exec " & p_FunctionTableId
        GetTableID = ""
        Try
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTableID = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
        Catch ex As Exception
            GetTableID = ""
        End Try

    End Function




    'anhqh 20160920
    Private Function GetTableIDKV1(ByVal p_MaVanChuyen As String, ByVal p_date As Date) As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable

        p_SQL = " exec  FPT_GetTableID_KV1_New '" & p_MaVanChuyen & "','" & p_date.ToString("yyyyMMdd") & "'"

        GetTableIDKV1 = ""
        Try
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTableIDKV1 = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
        Catch ex As Exception
            GetTableIDKV1 = ""
        End Try

    End Function



    'Dung kien tra file Scadar voi truong hop 1 so don vi co 2 table scadar TDH mot bang, ghi nhan thuc xuat 1 bang
    Private Sub modHuyTichKe_2(ByVal p_WareHouse As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                             ByRef p_Error As Boolean, ByRef p_Desc As String, _
                              ByVal p_Terminal As String, ByRef p_TableExec As DataTable, ByRef p_TableExec_E5 As DataTable)
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
        Dim p_StrExe As String
        'Dim p_TableExec As New DataTable("Table01")
        Dim p_DataRow As DataRow
        Dim p_DataTableCheckID As DataTable
        Dim p_Where_Check As String  'Dung checkScadar
        Dim p_TableName_E5 As String = ""
        Dim p_DataRowMap_cp_E5() As DataRow
        Dim p_DataRowMap_cp_Old() As DataRow
        'Dim p_TableExec_E5 As New DataTable("Table01")
        Dim p_MaHangHoa As String
        Dim p_HangHoaE5 As Boolean
        Dim p_StrExeE5 As String
        Dim p_Flag() As String
        Dim p_StatusType As String
        Dim p_DataRowCheck() As DataRow

        'Dim p_DataRowHangHoaE5() As DataRow

        If p_TableExec Is Nothing Then
            p_TableExec.Columns.Add("SQL_STR", GetType(String))
        Else
            If p_TableExec.Columns.Count <= 0 Then
                p_TableExec.Columns.Add("SQL_STR", GetType(String))
            End If
        End If

        If p_TableExec_E5 Is Nothing Then
            p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
        Else
            If p_TableExec_E5.Columns.Count <= 0 Then
                p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
            End If
        End If

        If g_DataMap_cp Is Nothing Then
            Exit Sub
        End If
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "'  or Status='" & UCase(p_TypeIn) & "' ) and (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "' )")
        If p_DataRowMap_cp_Old.Length <= 0 Then
            p_Error = True
            p_Desc = "Không có thông tin Map"
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
            p_Error = True
            p_Desc = "Không có thông tin tên bảng Map"
            Exit Sub
        End If
        p_Error = False
        p_Desc = ""

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


        p_TableExec.Clear()
        If UCase(g_TypeConnet) = "FOX" Then

            If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                p_TableName = Replace(g_PathFileFoxBo, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)

            Else
                p_TableName = Replace(g_PathFileFoxThuy, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)

            End If

        End If


        p_TableExec_E5.Clear()

        p_SQL = "exec FPT_GetDataToScadar '" & p_SoLenh.Trim & "'"
        p_DataHTTG = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataHTTG Is Nothing Then
            For p_Count = 0 To p_DataHTTG.Rows.Count - 1

                p_DataRowHTTG = p_DataHTTG.Rows(p_Count)
                If g_TableMaHangHoaE5.Rows.Count <= 0 Then
                    p_Error = True
                    p_Desc = "Không có thông tin lệnh xuất"
                    Exit Sub
                End If
                p_HangHoaE5 = False
                p_MaHangHoa = p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                If p_MaHangHoa.ToString.Trim = g_TableMaHangHoaE5.Rows(0).Item("MaHangHoa_Scada").ToString.Trim Then
                    p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    p_HangHoaE5 = True
                    If p_DataRowMap_cp.Length <= 0 Then
                        p_Error = True
                        p_Desc = "Không có thông tin bảng Map"
                        Exit Sub
                    End If
                Else
                    'p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_STT = p_DataRowMap_cp_Old(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    If p_DataRowMap_cp.Length <= 0 Then
                        p_Error = True
                        p_Desc = "Không có thông tin bảng Map"
                        Exit Sub
                    End If
                End If



                p_SQLInsert = ""
                p_SQLValue = ""
                p_Where_Check = ""
                For p_CountRow = 0 To p_DataRowMap_cp.Length - 1
                    Try
                        'If p_CountRow >= 69 Then
                        '    MsgBox("fggd")
                        'End If

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
                        p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                            Else
                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                            End If
                            Continue For
                        End If
                        ''''''========================================anhqh
                        '20160713 them dieu kien kiem tra theo
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
                            If p_Value = "" Then
                                p_Value = "0"
                            End If
                            p_StatusType = "<>"
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
                                            p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "))" & p_StatusType & "'" & p_Value & "'"
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
                                            p_Where_Check = p_Where_Check & " AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                        Case Else
                                            Continue For
                                    End Select
                                End If

                            End If
                            Continue For
                        End If
                        '=====================================================================

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            p_Value = p_Value.Substring(1, g_MaNgan_DD)

                            If p_Where_Check.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            End If
                            Continue For
                        End If

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then

                            If UCase(g_TypeConnet) = "FOX" And p_HangHoaE5 = False Then
                                If p_Where_Check.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                    End Select
                                End If
                            Else
                                ' End If
                                If p_Where_Check.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                    End Select
                                End If
                            End If
                            Continue For
                        End If
                        '
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
                            'If g_MaTuDongHoa = "N" Then
                            If p_Value.ToString.Trim <> "" Then
                                p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                               p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
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
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                End Select
                            End If

                            'End If
                            Continue For
                        End If
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
                        Continue For
                        End If
                    Catch ex As Exception
                        p_Where_Check = p_Where_Check
                    End Try
                Next

                If p_Where_Check.ToString.Trim <> "" Then
                    If p_HangHoaE5 = True Then
                        p_SQL = "select *  from " & p_TableName_E5 & " WHERE " & p_Where_Check
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count > 0 Then
                                p_StrExeE5 = "delete * from " & p_TableName_E5 & " WHERE " & p_Where_Check
                                p_DataRow = p_TableExec_E5.NewRow
                                p_DataRow.Item(0) = p_StrExeE5
                                p_TableExec_E5.Rows.Add(p_DataRow)

                                Continue For
                            End If

                        End If
                    Else
                        p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check
                        If UCase(g_TypeConnet) = "FOX" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    p_StrExe = "delete * from " & p_TableName & " WHERE " & p_Where_Check
                                    p_DataRow = p_TableExec.NewRow
                                    p_DataRow.Item(0) = p_StrExe
                                    p_TableExec.Rows.Add(p_DataRow)

                                End If
                            Else
                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub
                            End If

                        End If
                        If UCase(g_TypeConnet) = "SQL" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    p_StrExe = "delete  from " & p_TableName & " WHERE " & p_Where_Check
                                    p_DataRow = p_TableExec.NewRow
                                    p_DataRow.Item(0) = p_StrExe
                                    p_TableExec.Rows.Add(p_DataRow)
                                    Continue For
                                End If

                            End If

                        End If

                    End If

                End If
            Next

        End If
    End Sub




    'Dung kien tra file Scadar voi truong hop 1 so don vi co 2 table scadar TDH mot bang, ghi nhan thuc xuat 1 bang
    Private Sub KV1_modHuyTichKe_2(ByVal p_WareHouse As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                             ByRef p_Error As Boolean, ByRef p_Desc As String, _
                              ByVal p_Terminal As String, ByRef p_TableExec As DataTable, ByRef p_TableExec_E5 As DataTable)
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
        Dim p_StrExe As String
        'Dim p_TableExec As New DataTable("Table01")
        Dim p_DataRow As DataRow
        Dim p_DataTableCheckID As DataTable
        Dim p_Where_Check As String  'Dung checkScadar
        Dim p_TableName_E5 As String = ""
        Dim p_DataRowMap_cp_E5() As DataRow
        Dim p_DataRowMap_cp_Old() As DataRow
        'Dim p_TableExec_E5 As New DataTable("Table01")
        Dim p_MaHangHoa As String
        Dim p_HangHoaE5 As Boolean
        Dim p_StrExeE5 As String
        Dim p_Flag() As String
        Dim p_StatusType As String
        Dim p_DataRowCheck() As DataRow

        'Dim p_DataRowHangHoaE5() As DataRow

        If p_TableExec Is Nothing Then
            p_TableExec.Columns.Add("SQL_STR", GetType(String))
        Else
            If p_TableExec.Columns.Count <= 0 Then
                p_TableExec.Columns.Add("SQL_STR", GetType(String))
            End If
        End If

        If p_TableExec_E5 Is Nothing Then
            p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
        Else
            If p_TableExec_E5.Columns.Count <= 0 Then
                p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
            End If
        End If

        If g_DataMap_cp Is Nothing Then
            Exit Sub
        End If
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "'  or Status='" & UCase(p_TypeIn) & "' ) and (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "' )")
        If p_DataRowMap_cp_Old.Length <= 0 Then
            p_Error = True
            p_Desc = "Không có thông tin Map"
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
            p_Error = True
            p_Desc = "Không có thông tin tên bảng Map"
            Exit Sub
        End If
        p_Error = False
        p_Desc = ""

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


        p_TableExec.Clear()
        If UCase(g_TypeConnet) = "FOX" Then

            If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                p_TableName = Replace(g_PathFileFoxBo, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)

            Else
                p_TableName = Replace(g_PathFileFoxThuy, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)

            End If

        End If


        p_TableExec_E5.Clear()

        p_SQL = "exec FPT_GetDataToScadar '" & p_SoLenh.Trim & "'"
        p_DataHTTG = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataHTTG Is Nothing Then
            For p_Count = 0 To p_DataHTTG.Rows.Count - 1

                p_DataRowHTTG = p_DataHTTG.Rows(p_Count)
                If g_TableMaHangHoaE5.Rows.Count <= 0 Then
                    p_Error = True
                    p_Desc = "Không có thông tin lệnh xuất"
                    Exit Sub
                End If
                p_HangHoaE5 = False
                p_MaHangHoa = p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
                If p_MaHangHoa.ToString.Trim = g_TableMaHangHoaE5.Rows(0).Item("MaHangHoa_Scada").ToString.Trim Then
                    p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    p_HangHoaE5 = True
                    If p_DataRowMap_cp.Length <= 0 Then
                        p_Error = True
                        p_Desc = "Không có thông tin bảng Map"
                        Exit Sub
                    End If
                Else
                    'p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
                    p_STT = p_DataRowMap_cp_Old(0).Item("STT").ToString.Trim
                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
                    If p_DataRowMap_cp.Length <= 0 Then
                        p_Error = True
                        p_Desc = "Không có thông tin bảng Map"
                        Exit Sub
                    End If
                End If



                p_SQLInsert = ""
                p_SQLValue = ""
                p_Where_Check = ""
                For p_CountRow = 0 To p_DataRowMap_cp.Length - 1
                    Try
                        'If p_CountRow >= 69 Then
                        '    MsgBox("fggd")
                        'End If

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
                            p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim

                            If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                                If p_Where_Check.ToString.Trim = "" Then
                                    p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                                Else
                                    p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                                End If
                                Continue For
                            End If
                            ''''''========================================anhqh
                            '20160713 them dieu kien kiem tra theo
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
                                If p_Value = "" Then
                                    p_Value = "0"
                                End If
                                p_StatusType = "<>"
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
                                                p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                            Case "THUY"
                                                p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                            Case "SAT"
                                                p_Where_Check = "RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "))" & p_StatusType & "'" & p_Value & "'"
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
                                                p_Where_Check = p_Where_Check & " AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                            Case "THUY"
                                                p_Where_Check = p_Where_Check & "  AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                            Case "SAT"
                                                p_Where_Check = p_Where_Check & "  AND RTRIM(ltrim(" & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "))" & p_StatusType & "'" & p_Value & "'"
                                            Case Else
                                                Continue For
                                        End Select
                                    End If

                                End If
                                Continue For
                            End If
                            '=====================================================================

                            If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                                p_Value = p_Value.Substring(1, g_MaNgan_DD)

                                If p_Where_Check.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    End Select
                                End If
                                Continue For
                            End If

                            If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then

                                If UCase(g_TypeConnet) = "FOX" And p_HangHoaE5 = False Then
                                    If p_Where_Check.ToString.Trim = "" Then
                                        Select Case UCase(g_LoaiVanChuyen)
                                            Case "BO"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                            Case "THUY"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                            Case "SAT"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        End Select
                                    Else
                                        Select Case UCase(g_LoaiVanChuyen)
                                            Case "BO"
                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                            Case "THUY"
                                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                            Case "SAT"
                                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                        End Select
                                    End If
                                Else
                                    ' End If
                                    If p_Where_Check.ToString.Trim = "" Then
                                        Select Case UCase(g_LoaiVanChuyen)
                                            Case "BO"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                            Case "THUY"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                            Case "SAT"
                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        End Select
                                    Else
                                        Select Case UCase(g_LoaiVanChuyen)
                                            Case "BO"
                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                            Case "THUY"
                                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                            Case "SAT"
                                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                        End Select
                                    End If
                                End If
                                Continue For
                            End If
                            '
                            If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                                p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
                                'If g_MaTuDongHoa = "N" Then
                                If p_Value.ToString.Trim <> "" Then
                                    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                   p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
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
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
                                    End Select
                                End If

                                'End If
                                Continue For
                            End If
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
                            Continue For
                        End If
                    Catch ex As Exception
                        p_Where_Check = p_Where_Check
                    End Try
                Next

                If p_Where_Check.ToString.Trim <> "" Then
                    If p_HangHoaE5 = True Then
                        p_SQL = "select *  from " & p_TableName_E5 & " WHERE " & p_Where_Check
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count > 0 Then
                                p_StrExeE5 = "delete * from " & p_TableName_E5 & " WHERE " & p_Where_Check
                                p_DataRow = p_TableExec_E5.NewRow
                                p_DataRow.Item(0) = p_StrExeE5
                                p_TableExec_E5.Rows.Add(p_DataRow)

                                Continue For
                            End If

                        End If
                    Else
                        p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check
                        If UCase(g_TypeConnet) = "FOX" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    p_StrExe = "delete * from " & p_TableName & " WHERE " & p_Where_Check
                                    p_DataRow = p_TableExec.NewRow
                                    p_DataRow.Item(0) = p_StrExe
                                    p_TableExec.Rows.Add(p_DataRow)

                                End If
                            Else
                                p_Desc = p_SQL
                                p_Error = True
                                Exit Sub
                            End If

                        End If
                        If UCase(g_TypeConnet) = "SQL" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If g_KV1 = True Then
                                    If p_DataTableCheckID.Rows.Count > 0 Then
                                        p_Error = True
                                        p_Desc = "Lệnh đã thực hiện bơm xuất"
                                        Exit Sub
                                    Else

                                        'p_StrExe = "delete  from " & p_TableName & " WHERE " & p_Where_Check
                                        'p_DataRow = p_TableExec.NewRow
                                        'p_DataRow.Item(0) = p_StrExe
                                        'p_TableExec.Rows.Add(p_DataRow)
                                        Continue For
                                    End If
                                Else
                                    If p_DataTableCheckID.Rows.Count > 0 Then

                                        p_StrExe = "delete  from " & p_TableName & " WHERE " & p_Where_Check
                                        p_DataRow = p_TableExec.NewRow
                                        p_DataRow.Item(0) = p_StrExe
                                        p_TableExec.Rows.Add(p_DataRow)
                                        Continue For
                                    End If
                                End If
                                

                            End If

                        End If

                    End If

                End If
            Next

        End If
    End Sub


    Private Function GetStructTbaleScadar(ByVal p_DataTable As DataTable) As DataTable
        Dim p_DataTableOut As New DataTable("Table01")
        Dim p_DataRow As DataRow
        Dim p_Count As Integer
        Dim p_FieldName As String
        Dim p_FieldType As String
        p_DataTableOut.Columns.Add("FieldName")
        p_DataTableOut.Columns.Add("FieldType")
        For p_Count = 0 To p_DataTable.Columns.Count - 1
            p_FieldName = p_DataTable.Columns.Item(p_Count).ColumnName
            p_FieldType = p_DataTable.Columns.Item(p_Count).DataType.Name
            p_DataRow = p_DataTableOut.NewRow
            p_DataRow.Item("FieldName") = p_FieldName
            p_DataRow.Item("FieldType") = p_FieldType
            p_DataTableOut.Rows.Add(p_DataRow)
        Next
        Return p_DataTableOut
    End Function




End Module
