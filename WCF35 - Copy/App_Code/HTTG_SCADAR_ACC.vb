Imports System.Data.OleDb
Imports System.IO
Imports System.Data


Public Class HTTG_SCADAR_ACC
    Private g_KV1 As Boolean = False

    Private g_ConnectHTTG As New ConnectHTTG


    Private g_BATCHSLOG As Boolean = False

    Private g_ObjectFox As New HTTG_SCADAR_FOX


    Private g_User_ID As Integer
    'Public g_Module As Object
    Private g_Company_Code As String

    Private p_SYS_MALENH_S As String = String.Empty

    Private p_QUYDOI_SAP As String = "N"


    Private Constant_P_Bo = "Bo"
    Private Constant_P_Thuy = "Thuy"
    Private Constant_P_eBo = "eBo"
    Private Constant_P_eThuy = "eThuy"
    Private Constant_P_HeSoCongTo = "HeSoCongTo"
    Private Constant_P_eTimeStop = "eTimeStop"
    Private Constant_P_eTimeFlagBo = "eTimeFlagBo"
    Private Constant_P_eTimeFlagThuy = "eTimeFlagThuy"
    Private Constant_P_eTimeDefault = "eTimeDefault"
    Private Constant_P_eMapMaHangHoa = "eMapMaHangHoa"
    Private Constant_P_CheckMetter = "CheckMetter"
    Private Constant_P_MaTuDongHoa = "MaTuDongHoa"
    Private Constant_P_Sat = "Sat"
    Private Constant_P_upThucXuat = "upThucXuat"
    Private Constant_P_eSat = "eSat"
    Private Constant_P_MeterDens = "MeterDens"
    Private Constant_P_FO = "FO"
    Private Constant_P_Password = "Password"
    Private g_Client_E5_Upper As String = ""
    Private g_Client_E5 As String = ""
    Private i_dt_para As New DataTable

    Private g_UserName As String = ""


    Private g_DataMap_cp As DataTable = Nothing
    Private g_DataMap_Line_cp As DataTable = Nothing
    Private g_TableToScadarBo As DataTable = Nothing
    Private g_TableToScadarThuy As DataTable = Nothing
    Private g_Table_Sys_Config As DataTable = Nothing
    Private g_TableToScadar_E5 As DataTable = Nothing
    Private g_TableMaHangHoaE5 As DataTable = Nothing
    Private g_TabletblConfig As DataTable = Nothing
    Private g_ConfigDecima As DataTable = Nothing

    Private g_ConnectToScadar As String
    Private g_ConnectToScadar_E5 As String
    Private g_DBTYPE As String = "SQL"
    'Public g_Terminal_E5 As String = ""
    Private g_MaTuDongHoa As String = "N" 'Neu ='Y' thi la FOX    'N' thi la SQL
    Private g_MaNgan_DD As String 'Do dai cua ma ngan

    Private g_StrConnectFox As String
    Private g_PathFileFoxOut As String
    Private g_PathFileFoxIn As String

    Private g_PathFileFoxThuy As String
    Private g_PathFileFoxBo As String
    Private g_TypeConnet As String = "SQL"
    Private g_HTTG_E5 As Boolean = True
    Private g_METER_E5 As Boolean = True

    Private g_StrConnectAccess As String
    Private g_PathFileAccess As String
    Private g_ACCESS_PASS As String = ""
    Private g_ACCESS_USER As String = ""


    '1
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
                    g_Client_E5_Upper = p_Client & g_Client_E5_Upper
                    g_Client_E5 = p_Client & g_Client_E5
                End If
            End If
        End If
    End Sub




    Public Function mdlHTTG_To_Scadar(ByVal p_UserName As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                   Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_InsertToScadar As Boolean = True,
                                   Optional ByVal p_E5 As Boolean = True) As String
        Dim p_SQL As String
        Dim p_DataSet As DataSet
        Dim p_Eror As Boolean
        Dim p_Desc As String
        Dim p_ArrRow() As DataRow
        Try

            g_UserName = p_UserName
            'anhqh  
            '20160810
            GetClient_E5(p_Terminal)



            mdlHTTG_To_Scadar = ""
            g_HTTG_E5 = p_E5
            'p_SQL = "select * from tblMap_cp;" & _
            '    "select * from SYS_Map_cp_Line; " & _
            '    "select * from SYS_CONFIG; " & _
            '    "SELECT *  FROM [tblMap_MaHangHoa] where MaHangHoa_Sap='0201004';"
            p_SQL = "exec FPT_GetDataTableList"
            p_DataSet = g_ConnectHTTG.p_SYS_GET_DATASET_Des(p_SQL, p_SQL)

            g_METER_E5 = True
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
                    '20160630
                    p_ArrRow = g_Table_Sys_Config.Select("KEYCODE='METER_E5'")
                    If p_ArrRow.Length > 0 Then
                        'g_MaNgan_DD = IIf(p_ArrRow(0).Item("KEYVALUE").ToString.Trim = "", "N", p_ArrRow(0).Item("KEYVALUE").ToString.Trim)
                        If p_ArrRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                            g_METER_E5 = True
                        Else
                            g_METER_E5 = False
                        End If
                    End If

                    p_ArrRow = g_Table_Sys_Config.Select("KEYCODE='KV1'")
                    If p_ArrRow.Length > 0 Then
                        If p_ArrRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                            g_KV1 = True
                        Else
                            g_KV1 = False
                        End If
                    End If


                    p_ArrRow = g_Table_Sys_Config.Select("KEYCODE='ACCESS_PASS'")
                    If p_ArrRow.Length > 0 Then
                        If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                            g_ACCESS_PASS = p_ArrRow(0).Item("KEYVALUE").ToString.Trim
                        End If
                    End If



                    p_ArrRow = g_Table_Sys_Config.Select("KEYCODE='ACCESS_USER'")
                    If p_ArrRow.Length > 0 Then
                        If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                            g_ACCESS_USER = p_ArrRow(0).Item("KEYVALUE").ToString.Trim
                        End If
                    End If

                    If g_ACCESS_PASS <> "" Then
                        g_ACCESS_PASS = mdlCryptor_Decrypt(g_ACCESS_PASS, g_ACCESS_USER)
                    End If

                    If g_ACCESS_PASS Is Nothing Then
                        g_ACCESS_PASS = ""
                    End If

                End If
            End If

            g_ConnectHTTG.Sys_GetParameterOracle(g_DBTYPE)
            '20150819
            If Not g_TabletblConfig Is Nothing Then
                If g_TabletblConfig.Rows.Count > 0 Then
                    g_TypeConnet = g_TabletblConfig.Rows(0).Item("optional").ToString.Trim()
                End If
            End If

            ''20150819
            'If UCase(g_TypeConnet) = "FOX" Then
            '    If GetConnectFox(p_Desc, p_TypeIn, g_LoaiVanChuyen, p_Terminal) = False Then
            '        mdlHTTG_To_Scadar = p_Desc
            '        p_Eror = True
            '        Exit Function
            '    End If
            'End If

            '20150819
            If UCase(g_TypeConnet) = "ACC" Then
                If GetConnectAccess(p_Desc, p_TypeIn, g_LoaiVanChuyen, p_Terminal) = False Then
                    mdlHTTG_To_Scadar = p_Desc
                    p_Eror = True
                    Exit Function
                End If

            Else
                mdlHTTG_To_Scadar = "Không xác định scadar"
                p_Eror = True
                Exit Function
            End If


            getSQL_TableToScadar(p_TypeIn, g_LoaiVanChuyen, p_Terminal)
            If p_InsertToScadar = True Then
                If g_DBTYPE = "SQL" Then
                    'getSQL_TableToScadar("Thuy")
                    SQLGetDataToScadar(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Eror, p_Desc, p_Terminal)
                    If p_Eror = True Then
                        mdlHTTG_To_Scadar = p_Desc
                    Else
                        'anhqh  
                        '20160607
                        p_Eror = False
                        SQLGetDataToScadar_InTichKe(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Eror, p_Desc, p_Terminal)
                        If p_Eror = True Then
                            mdlHTTG_To_Scadar = "Lệnh xuất chưa được đẩy vào TĐH. Bạn hãy In tích kê lại."
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            mdlHTTG_To_Scadar = "HTTG_To_Scadar: " & ex.Message
        End Try
    End Function


    '2
    Public Sub getSQL_TableToScadar(ByVal p_TypeIn As String, ByVal g_LoaiVanChuyen As String, ByVal p_Terminal As String)
        'g_LoaiVanChuyen: Bo,Thuy,Sat
        Dim p_SQL As String
        Dim p_Connect As String
        Dim p_DataRow() As DataRow
        Dim p_TableName As String = ""
        Dim p_DataTable As DataTable





        'If Not g_TableToScadarBo Is Nothing Then
        '    Exit Sub
        'End If

        'If g_DataMap_cp Is Nothing Then
        '    Exit Sub
        'End If
        p_DataRow = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & p_TypeIn & "') and Client='" & p_Terminal & "'")
        If p_DataRow.Length > 0 Then

            If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                p_TableName = g_PathFileFoxBo
                p_SQL = "select * from " & p_TableName & " where 1=0"
                p_DataTable = New DataTable
                'p_DataTable = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                p_DataTable = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectAccess, p_SQL, p_SQL)

                '  Exit Sub
                g_TableToScadarBo = GetStructTbaleScadar(p_DataTable)


            Else
                p_TableName = g_PathFileFoxThuy
                p_SQL = "select * from " & p_TableName & " where 1=0"
                p_DataTable = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectAccess, p_SQL, p_SQL)
                g_TableToScadarThuy = GetStructTbaleScadar(p_DataTable)
            End If


            p_DataRow = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & p_TypeIn & "') and (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "' )")
            If p_DataRow.Length > 0 Then
                g_ConnectToScadar_E5 = "Provider=SQLOLEDB;Data Source=" & p_DataRow(0).Item("ServerScada").ToString.Trim & ";Persist Security Info=True;User ID=" & _
                p_DataRow(0).Item("UidScada").ToString.Trim & ";Password=" & p_DataRow(0).Item("PwdScada").ToString.Trim & _
                ";Initial Catalog=" & p_DataRow(0).Item("DatabaseScada").ToString.Trim & ";Connect Timeout=300"
                p_TableName = p_DataRow(0).Item("TableName").ToString.Trim
                p_SQL = "select * from [" & p_TableName & "] where 1=0"
                p_DataTable = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
                g_TableToScadar_E5 = GetStructTbaleScadar(p_DataTable)
            End If

        End If
        Exit Sub
        ' End If

    End Sub



    Private Function GetStatusType() As String
        Dim p_Datatatable As DataTable
        Dim p_SQL As String
        GetStatusType = "="
        p_SQL = "select * from SYS_CONFIG  where KEYCODE='TRANGTHAI'"
        p_Datatatable = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
    'Ham thuc hien lay du lieu chi tiet cua HTTG de day sang Scadar
    Private Sub SQLGetDataToScadar(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, ByRef p_Error As Boolean, ByRef p_Desc As String, _
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

        Dim p_TableName_E5 As String = ""
        Dim p_DataRowMap_cp_E5() As DataRow
        Dim p_DataRowMap_cp_Old() As DataRow
        Dim p_InsertTable_E5 As String = ""
        Dim p_ValueTable_E5 As String = ""
        Dim p_TableExec_E5 As New DataTable("Table01")
        Dim p_MaHangHoa As String
        Dim p_HangHoaE5 As Boolean
        Dim p_TyleE5 As Double
        Dim p_TyTrongNenE5 As Double
        Dim p_TyTrongEthanolE5 As Double
        Dim p_StrExeE5 As String
        Dim p_Flag() As String
        Dim p_StatusType As String

        Dim l_ngayxuat As String
        Dim l_Nam, l_Thang, l_Ngay As String
        Dim p_CheckData As Boolean = False

        'Dim p_DataRowHangHoaE5() As DataRow

        p_TableExec.Columns.Add("SQL_STR", GetType(String))
        p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
        If g_DataMap_cp Is Nothing Then
            Exit Sub
        End If
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "'  or Status='" & UCase(p_TypeIn) & "' ) and (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "' )")
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

        '20150819
        'Them dieu kien FOX
        If UCase(g_TypeConnet) = "ACC" Then
            If g_StrConnectAccess.ToString.Trim = "" Then
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
        If UCase(g_TypeConnet) = "ACC" Then

            If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                p_TableName = g_PathFileFoxBo

                p_InsertTable = "INSERT INTO " & p_TableName & " "
                p_ValueTable = " VALUES "
            Else
                p_TableName = g_PathFileFoxThuy

                p_InsertTable = "INSERT INTO " & p_TableName & " "
                p_ValueTable = " VALUES "
            End If

        End If

        If UCase(g_TypeConnet) = "SQL" Then
            p_InsertTable = "INSERT INTO " & p_TableName & " "
            p_ValueTable = " VALUES "
        End If


        p_TableExec_E5.Clear()
        p_InsertTable_E5 = "INSERT INTO " & p_TableName_E5 & " "
        p_ValueTable_E5 = " VALUES "


        'lay chuoi select trong bang MaptblLine

        'p_SQL = "select aa.*, bb.MaHangHoa as MaHangHoaTG, " & _
        '        "(select top 1 MaHangHoa_Scada  from tblMap_MaHangHoa where MaHangHoa_Sap =bb.MaHangHoa) as MaHangHoa  " & _
        '        ",(select top 1 MaPhuongTien   from tblLenhXuatE5 with (nolock) where SoLenh  =bb.SoLenh ) as PhuongTien " & _
        '    "from tblLenhXuatChiTietE5 aa with (Nolock), tblLenhXuat_HangHoaE5 bb with (Nolock) " & _
        '    " where bb.LineID=aa.LineID and bb.NgayXuat=aa.NgayXuat and aa.MaLenh=bb.MaLenh and bb.SoLenh='" & p_SoLenh.Trim & "'"
        p_SQL = "exec FPT_GetDataToScadar '" & p_SoLenh.Trim & "'"
        p_DataHTTG = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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

                    'If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "GATEFLAG" Then
                    '    p_Value = GetTimeEnd(g_LoaiVanChuyen)
                    '    p_FieldType = "Int32"
                    'Else
                    If p_HangHoaE5 = True Then
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, g_Client_E5, p_HangHoaE5)
                    Else
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, p_Terminal, p_HangHoaE5)
                    End If
                    'End If



                    If p_FieldType.ToString.Trim <> "" Or UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "FLAG1" Then

                        Select Case UCase(g_LoaiVanChuyen)
                            Case "BO"
                                p_SQLInsert = p_SQLInsert & "," & p_DataRowMap_cp(p_CountRow).Item("Bo").trim
                            Case "THUY"
                                p_SQLInsert = p_SQLInsert & "," & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim
                            Case "SAT"
                                p_SQLInsert = p_SQLInsert & "," & p_DataRowMap_cp(p_CountRow).Item("Sat").trim
                        End Select

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
                            'If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "GATEFLAG" Then

                            'Else
                            p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim
                            ' End If

                        End If

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MALUULUONGKE" Then
                            If p_Value = "" Then
                                p_Value = "0"
                            End If
                        End If





                        'GetTimeEnd


                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                            Else
                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                            End If
                        End If



                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then

                            If p_Value.ToString.Length <= 1 Then
                                p_Error = True
                                p_Desc = "Mã ngăn không hợp lệ"
                                Exit Sub
                            End If
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
                        End If

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            'If UCase(g_TypeConnet) = "FOX" Then
                            'p_SQLValue = p_SQLValue & ",'" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                            'l_Nam = CDate(p_Value).ToString("yyyy")
                            'l_Thang = CDate(p_Value).ToString("MM")
                            'l_Ngay = CDate(p_Value).ToString("dd")
                            'l_ngayxuat = New DateTime(l_Nam, l_Thang, l_Ngay)
                            'p_SQLValue = p_SQLValue & ",'" & l_ngayxuat & "'"
                            'If UCase(g_TypeConnet) = "FOX" And p_HangHoaE5 = False Then
                            '    If p_Where_Check.ToString.Trim = "" Then
                            '        Select Case UCase(g_LoaiVanChuyen)
                            '            Case "BO"
                            '                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                            '            Case "THUY"
                            '                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                            '            Case "SAT"
                            '                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                            '        End Select
                            '    Else
                            '        Select Case UCase(g_LoaiVanChuyen)
                            '            Case "BO"
                            '                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                            '            Case "THUY"
                            '                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                            '            Case "SAT"
                            '                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                            '        End Select
                            '    End If
                            'Else
                            ' End If
                            If p_Where_Check.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=#" & CDate(p_Value).ToString("yyyy-MM-dd") & "#"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=#" & CDate(p_Value).ToString("yyyy-MM-dd") & "#"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=#" & CDate(p_Value).ToString("yyyy-MM-dd") & "#"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=#" & CDate(p_Value).ToString("yyyy-MM-dd") & "#"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=#" & CDate(p_Value).ToString("yyyy-MM-dd") & "#"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=#" & CDate(p_Value).ToString("yyyy-MM-dd") & "#"
                                End Select
                            End If
                            ' End If
                        End If
                        '
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
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
                                'p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                'p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                p_DataTableCheckID = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                                If Not p_DataTableCheckID Is Nothing Then
                                    If p_DataTableCheckID.Rows.Count > 0 Then
                                        p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                                    End If
                                End If
                            Else
                                'H_TableID
                                p_Value = p_DataRowHTTG.Item("H_TableID").ToString.Trim
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
                                    p_DataTableCheckID = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                            End If
                            'If p_Where_Check.ToString.Trim = "" Then
                            '    Select Case UCase(g_LoaiVanChuyen)
                            '        Case "BO"
                            '            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
                            '        Case "THUY"
                            '            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
                            '        Case "SAT"
                            '            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
                            '    End Select
                            'Else
                            '    Select Case UCase(g_LoaiVanChuyen)
                            '        Case "BO"
                            '            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
                            '        Case "THUY"
                            '            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
                            '        Case "SAT"
                            '            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
                            '    End Select
                            'End If
                        End If
                        'Tinh lai Ma lenh cua tu dong hoa

                        'Kiem tra trong Scadar co chua, neu co roi thi khong insert nua

                        Select Case UCase(p_FieldType)
                            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                p_SQLValue = p_SQLValue & "," & CDec(IIf(p_Value.ToString.Trim = "", 0, p_Value))
                            Case UCase("DateTime"), UCase("Date")
                                '  If UCase(g_TypeConnet) = "SQL" Then
                                p_SQLValue = p_SQLValue & ",'" & CDate(p_Value).ToString("yyyy-MM-dd") & "'"
                                '   End If
                                'If UCase(g_TypeConnet) = "FOX" Then
                                '    p_SQLValue = p_SQLValue & ",{d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                'End If
                            Case UCase("String")
                                p_SQLValue = p_SQLValue & ",'" & p_Value & "'"
                        End Select

                        'If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "GATEFLAG" Then
                        '    p_Value = GetTimeEnd(g_LoaiVanChuyen)
                        '    p_FieldType = "Int32"
                        'End If

                    End If
                Next

                If p_Where_Check.ToString.Trim <> "" Then
                    If p_HangHoaE5 = True Then
                        p_SQL = "select 1 as STT  from " & p_TableName_E5 & " WHERE " & p_Where_Check
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count > 0 Then
                                p_CheckData = True
                                Continue For
                            End If

                        End If
                    Else
                        p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check
                        'If UCase(g_TypeConnet) = "FOX" Then
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectAccess, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count > 0 Then
                                p_CheckData = True
                                Continue For
                            End If
                            'Else
                            '    p_Desc = p_SQL
                            '    p_Error = True
                            '    Exit Sub
                        End If

                        'End If

                    End If

                End If
                If p_HangHoaE5 = True Then
                    Dim p_HongXUat As Integer
                    'ByRef p_Tyle As Double, ByRef p_TyTrongNen As Double, ByRef p_TyTrongEthanol As Double
                    GetTyTrong_TyLeE5(p_DataRowHTTG.Item("TableID").ToString.Trim, _
                                        p_DataRowHTTG.Item("MaLenh").ToString.Trim, _
                                        CDate(p_DataRowHTTG.Item("NgayXuat")), _
                                        p_DataRowHTTG.Item("LineID").ToString.Trim, _
                                        p_TyleE5, _
                                        p_TyTrongNenE5, _
                                        p_TyTrongEthanolE5, p_HongXUat)
                    If (p_TyleE5 = 0 Or p_TyTrongNenE5 = 0 Or p_TyTrongEthanolE5 = 0) And g_METER_E5 = True Then
                        p_Desc = "Không xác định Tỷ lệ phối trộn hoặc tỷ trọng nền " & vbCrLf & "    hoặc tỷ trong Ethanol"
                        p_Error = True
                        Exit Sub
                    Else
                        p_SQLInsert = p_SQLInsert & ",TYLE_PRESET, TYTRONG_BASE, TYTRONG_E, MA_HONG "
                        p_SQLValue = p_SQLValue & "," & p_TyleE5 & "," & p_TyTrongNenE5 & "," & p_TyTrongEthanolE5 & "," & p_HongXUat
                    End If
                End If

                'Neu la FOX thi bo sung gia trij cho cac truong khong co trong danh sach
                'If UCase(g_TypeConnet) = "ACC" And p_HangHoaE5 = False Then

                '    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                '        FoxGetExtraField(g_LoaiVanChuyen, p_STT, g_DataMap_Line_cp, g_TableToScadarBo, p_SQLInsert, p_SQLValue)
                '    Else
                '        FoxGetExtraField(g_LoaiVanChuyen, p_STT, g_DataMap_Line_cp, g_TableToScadarThuy, p_SQLInsert, p_SQLValue)
                '    End If

                'End If


                If p_HangHoaE5 = False Then
                    Dim p_fieldname As String
                    p_Value = GetTimeEnd(g_LoaiVanChuyen, p_fieldname)

                    If p_fieldname <> "" Then
                        p_SQLInsert = p_SQLInsert & "," & p_fieldname
                        p_SQLValue = p_SQLValue & "," & p_Value
                    End If
                End If
                If p_SQLInsert.Trim <> "" Then
                    p_SQLInsert = Mid(p_SQLInsert, 2)
                End If
                If p_SQLValue.Trim <> "" Then
                    p_SQLValue = Mid(p_SQLValue, 2)
                End If


                'p_StrExe = p_InsertTable & "(" & p_SQLInsert & ") "
                'p_StrExe = p_StrExe & p_ValueTable & "(" & p_SQLValue & ")"

                If p_HangHoaE5 = True Then
                    If p_SQLInsert <> "" And p_SQLValue <> "" Then
                        p_StrExeE5 = p_InsertTable_E5 & "(" & p_SQLInsert & ") "
                        p_StrExeE5 = p_StrExeE5 & p_ValueTable & "(" & p_SQLValue & ")"
                        p_DataRow = p_TableExec_E5.NewRow
                        p_DataRow.Item(0) = p_StrExeE5
                        p_TableExec_E5.Rows.Add(p_DataRow)
                    End If
                Else
                    If p_SQLInsert <> "" And p_SQLValue <> "" Then
                        p_StrExe = p_InsertTable & "(" & p_SQLInsert & ") "
                        p_StrExe = p_StrExe & p_ValueTable & "(" & p_SQLValue & ")"
                        p_DataRow = p_TableExec.NewRow
                        p_DataRow.Item(0) = p_StrExe
                        p_TableExec.Rows.Add(p_DataRow)
                    End If
                End If

                ' End If

            Next

            If Not p_TableExec Is Nothing Then
                If p_TableExec.Rows.Count > 0 Then
                    If g_DBTYPE = "" Then
                        g_ConnectHTTG.Sys_GetParameterOracle(g_DBTYPE)
                    End If
                    If p_TableExec.Rows.Count > 0 Then



                        If Sys_Execute_DataTbl_With_Connection(g_StrConnectAccess, p_TableExec, p_SQL) = False Then

                            p_Desc = p_SQL
                            p_Error = True
                            Exit Sub
                            'Else

                        End If


                        ' End If
                    Else

                        p_Desc = "Không xác định dữ liệu đẩy Scadar"
                        p_Error = True
                        Exit Sub
                    End If
                End If
            End If

            If Not p_TableExec_E5 Is Nothing Then
                If p_TableExec_E5.Rows.Count > 0 Then
                    If g_DBTYPE = "" Then
                        g_ConnectHTTG.Sys_GetParameterOracle(g_DBTYPE)
                    End If
                    If p_TableExec_E5.Rows.Count > 0 Then
                        If g_DBTYPE = "ORACLE" Then
                            If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar, p_TableExec_E5, p_SQL) = False Then
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
                    Else
                        'MsgBox("Không xác định được dữ liệu cần cập nhật")
                        'g_Module.ModErrExceptionNew("MS0004", "Lỗi khi cập nhật")
                        ' Exit Sub
                        p_Desc = "Không xác định dữ liệu đẩy Scadar E5"
                        p_Error = True
                        Exit Sub
                    End If
                End If
            End If
            'Cap nhat lai trang thai cua lenhXuat
            If p_TableExec.Rows.Count <= 0 And p_TableExec_E5.Rows.Count <= 0 And p_CheckData = False Then
                p_Desc = "Không có dữ liệu đẩy sang Scadar"
                p_Error = True
                Exit Sub
            End If
            p_TableExec.Clear()
            p_DataRow = p_TableExec.NewRow
            If g_KV1 = True Then
                p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set Status='3',UserTichKe='" & g_UserName & "', " & _
                " NgayTichKe=NgayXuat where charindex(',' + SoLenh + ',','" & p_SoLenh & ",',1)>0 "
            Else
                p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set Status='3',UserTichKe='" & g_UserName & "', " & _
                    " NgayTichKe=getdate() where charindex(',' + SoLenh + ',','" & p_SoLenh & ",',1)>0 "
            End If

            p_TableExec.Rows.Add(p_DataRow)
            If p_TableExec.Rows.Count > 0 Then
                'If g_DBTYPE = "ORACLE" Then
                '    If g_Services.Sys_Execute_DataTbl_Oracle(p_TableExec, p_SQL) = False Then
                '        'MsgBox(p_SQL)
                '        p_Desc = p_SQL
                '        p_Error = True
                '        Exit Sub
                '    Else
                '    End If
                'ElseIf g_DBTYPE = "SQL" Then
                If g_ConnectHTTG.Sys_Execute_DataTbl(p_TableExec, p_SQL) = False Then
                    'MsgBox(p_SQL)
                    p_Desc = p_SQL
                    p_Error = True
                    Exit Sub

                End If
                ' End If
            End If
        End If
    End Sub


    Function GetTimeEnd(ByVal p_MaVanChuyen As String, ByRef p_Insert As String) As Integer
        Dim p_Date As Date
        Dim p_Time As Integer
        Dim p_SQL As String = "exec FPT_GetWorkTime '" & p_MaVanChuyen & "'"
        '"select KeyValue from SYS_CONFIG where KeyCode='GATEFLAG'"
        Dim p_DataTable As DataTable

        p_SQL = "select KeyValue from SYS_CONFIG where KeyCode='GATEFLAG'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                If p_DataTable.Rows(0).Item(0).ToString.Trim <> "" Then
                    p_Insert = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
        End If

        If p_Insert = "" Then
            Exit Function
        End If

        p_SQL = "exec FPT_GetWorkTime '" & p_MaVanChuyen & "'"
        GetTimeEnd = 0
        Try
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    If p_DataTable.Rows(0).Item(0).ToString.Trim <> "" Then
                        If IsNumeric(p_DataTable.Rows(0).Item(0).ToString.Trim) = True Then
                            Integer.TryParse(p_DataTable.Rows(0).Item(0).ToString.Trim, GetTimeEnd)
                        End If
                    End If

                End If
            End If
            ' p_Value = GetTimeEnd
        Catch ex As Exception
            GetTimeEnd = 0
        End Try

    End Function


    'anhqh
    '20160704
    'Ham kiem tra truong hop Wagon cua KV1
    Public Function GetScadarWagonKV1() As Boolean
        Dim p_SQL As String = " exec FPT_GetScadarWagonKV1"
        Dim p_DataTable As DataTable
        Try
            GetScadarWagonKV1 = False
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    If p_DataTable.Rows(0).Item("Code").ToString.Trim = "Y" Then
                        GetScadarWagonKV1 = True
                    End If
                End If
            End If
        Catch ex As Exception
            GetScadarWagonKV1 = False
        End Try
    End Function


    'Public Function GetMaVanChuyenLenhXuat(ByVal p_SoLenh As String) As String
    '    Dim p_SQL As String
    '    Dim p_Table As DataTable

    '    GetMaVanChuyenLenhXuat = ""

    '    Try
    '        p_SQL = "select MaVanChuyen from tblLenhXuatE5  where SoLenh='" & p_SoLenh & "'"
    '        p_Table = GetDataTable(p_SQL, p_SQL)
    '        If Not p_Table Is Nothing Then
    '            If p_Table.Rows.Count > 0 Then
    '                GetMaVanChuyenLenhXuat = p_Table.Rows(0).Item("MaVanChuyen").ToString.Trim
    '            End If
    '        End If
    '    Catch ex As Exception
    '        GetMaVanChuyenLenhXuat = ""
    '    End Try
    'End Function




    'anhqh
    'Ham thuc hien lay du lieu chi tiet cua HTTG de day sang Scadar
    'Kiem tra lai Scadar trươc khi in tich ke
    Private Sub SQLGetDataToScadar_InTichKe(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, ByRef p_Error As Boolean, ByRef p_Desc As String, _
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

        Dim p_TableName_E5 As String = ""
        Dim p_DataRowMap_cp_E5() As DataRow
        Dim p_DataRowMap_cp_Old() As DataRow
        Dim p_InsertTable_E5 As String = ""
        Dim p_ValueTable_E5 As String = ""
        Dim p_TableExec_E5 As New DataTable("Table01")
        Dim p_MaHangHoa As String
        Dim p_HangHoaE5 As Boolean
        Dim p_TyleE5 As Double
        Dim p_TyTrongNenE5 As Double
        Dim p_TyTrongEthanolE5 As Double
        Dim p_StrExeE5 As String
        Dim p_Flag() As String
        Dim p_StatusType As String

        Dim l_ngayxuat As String
        Dim l_Nam, l_Thang, l_Ngay As String

        'Dim p_DataRowHangHoaE5() As DataRow

        p_TableExec.Columns.Add("SQL_STR", GetType(String))
        p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
        If g_DataMap_cp Is Nothing Then
            p_Error = True
            Exit Sub
        End If
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "'  or Status='" & UCase(p_TypeIn) & "' ) and (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "' )")
        If p_DataRowMap_cp_Old.Length <= 0 Then
            p_Error = True
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
            Exit Sub
        End If
        p_Error = False
        p_Desc = ""

        '20150819
        'Them dieu kien FOX
        If UCase(g_TypeConnet) = "ACC" Then
            If g_StrConnectAccess.ToString.Trim = "" Then
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
        ' If UCase(g_TypeConnet) = "FOX" Then

        If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
            p_TableName = g_PathFileFoxBo

            p_InsertTable = "INSERT INTO " & p_TableName & " "
            p_ValueTable = " VALUES "
        Else
            p_TableName = g_PathFileFoxThuy

            p_InsertTable = "INSERT INTO " & p_TableName & " "
            p_ValueTable = " VALUES "
        End If

        '  End If

        If UCase(g_TypeConnet) = "SQL" Then
            p_InsertTable = "INSERT INTO " & p_TableName & " "
            p_ValueTable = " VALUES "
        End If


        p_TableExec_E5.Clear()
        p_InsertTable_E5 = "INSERT INTO " & p_TableName_E5 & " "
        p_ValueTable_E5 = " VALUES "


        'lay chuoi select trong bang MaptblLine

        'p_SQL = "select aa.*, bb.MaHangHoa as MaHangHoaTG, " & _
        '        "(select top 1 MaHangHoa_Scada  from tblMap_MaHangHoa where MaHangHoa_Sap =bb.MaHangHoa) as MaHangHoa  " & _
        '        ",(select top 1 MaPhuongTien   from tblLenhXuatE5 with (nolock) where SoLenh  =bb.SoLenh ) as PhuongTien " & _
        '    "from tblLenhXuatChiTietE5 aa with (Nolock), tblLenhXuat_HangHoaE5 bb with (Nolock) " & _
        '    " where bb.LineID=aa.LineID and bb.NgayXuat=aa.NgayXuat and aa.MaLenh=bb.MaLenh and bb.SoLenh='" & p_SoLenh.Trim & "'"
        p_SQL = "exec FPT_GetDataToScadar '" & p_SoLenh.Trim & "'"
        p_DataHTTG = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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

                        Select Case UCase(g_LoaiVanChuyen)
                            Case "BO"
                                p_SQLInsert = p_SQLInsert & "," & p_DataRowMap_cp(p_CountRow).Item("Bo").trim
                            Case "THUY"
                                p_SQLInsert = p_SQLInsert & "," & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim
                            Case "SAT"
                                p_SQLInsert = p_SQLInsert & "," & p_DataRowMap_cp(p_CountRow).Item("Sat").trim
                        End Select

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
                            p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim
                        End If

                        'If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MALUULUONGKE" Then
                        '    If p_Value = "" Then
                        '        p_Value = "0"
                        '    End If
                        'End If
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                            Else
                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                            End If
                        End If



                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then

                            If p_Value.ToString.Length <= 1 Then
                                p_Error = True
                                p_Desc = "Mã ngăn không hợp lệ"
                                Exit Sub
                            End If
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
                        End If

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            'If UCase(g_TypeConnet) = "FOX" Then
                            'p_SQLValue = p_SQLValue & ",'" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                            'l_Nam = CDate(p_Value).ToString("yyyy")
                            'l_Thang = CDate(p_Value).ToString("MM")
                            'l_Ngay = CDate(p_Value).ToString("dd")
                            'l_ngayxuat = New DateTime(l_Nam, l_Thang, l_Ngay)
                            'p_SQLValue = p_SQLValue & ",'" & l_ngayxuat & "'"

                            If p_Where_Check.ToString.Trim = "" Then
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=#" & CDate(p_Value).ToString("yyyy-MM-dd") & "#"
                                    Case "THUY"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=#" & CDate(p_Value).ToString("yyyy-MM-dd") & "#"
                                    Case "SAT"
                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=#" & CDate(p_Value).ToString("yyyy-MM-dd") & "#"
                                End Select
                            Else
                                Select Case UCase(g_LoaiVanChuyen)
                                    Case "BO"
                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=#" & CDate(p_Value).ToString("yyyy-MM-dd") & "#"
                                    Case "THUY"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=#" & CDate(p_Value).ToString("yyyy-MM-dd") & "#"
                                    Case "SAT"
                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=#" & CDate(p_Value).ToString("yyyy-MM-dd") & "#"
                                End Select
                            End If
                            ' End If
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


                                ' p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                'p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                'anhqh  20160623  Sua them dung rieng cho KV1   FPT_GetMaTuDongHoa_KV1
                                'If g_Company_Code = "2110" Then
                                '    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & GetMaVanChuyenLenhXuat(p_SoLenh) & "'"
                                'Else
                                '    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                'End If

                                p_DataTableCheckID = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                                If Not p_DataTableCheckID Is Nothing Then
                                    If p_DataTableCheckID.Rows.Count > 0 Then
                                        p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                                    End If
                                End If
                            Else
                                'H_TableID
                                p_Value = p_DataRowHTTG.Item("H_TableID").ToString.Trim
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


                                    ' p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    'p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                    'anhqh  20160623  Sua them dung rieng cho KV1   FPT_GetMaTuDongHoa_KV1
                                    'If g_Company_Code = "2110" Then
                                    '    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & GetMaVanChuyenLenhXuat(p_SoLenh) & "'"
                                    'Else
                                    '    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    '            p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                    'End If

                                    p_DataTableCheckID = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                            End If

                        End If
                        'Tinh lai Ma lenh cua tu dong hoa

                        'Kiem tra trong Scadar co chua, neu co roi thi khong insert nua

                        Select Case UCase(p_FieldType)
                            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                p_SQLValue = p_SQLValue & "," & CDec(IIf(p_Value.ToString.Trim = "", 0, p_Value))
                            Case UCase("DateTime"), UCase("Date")
                                'If UCase(g_TypeConnet) = "SQL" Then
                                p_SQLValue = p_SQLValue & ",#" & CDate(p_Value).ToString("yyyy-MM-dd") & "#"
                                ' End If

                            Case UCase("String")
                                p_SQLValue = p_SQLValue & ",'" & p_Value & "'"
                        End Select
                    End If
                Next

                If p_Where_Check.ToString.Trim <> "" Then
                    If p_HangHoaE5 = True Then
                        p_SQL = "select 1 as STT  from " & p_TableName_E5 & " WHERE " & p_Where_Check
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count <= 0 Then
                                p_Error = True
                                Exit Sub
                            End If

                        Else
                            p_Error = True
                            Exit Sub
                        End If
                    Else
                        p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check
                        ' If UCase(g_TypeConnet) = "FOX" Then
                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectAccess, p_SQL, p_SQL)
                        If Not p_DataTableCheckID Is Nothing Then
                            If p_DataTableCheckID.Rows.Count <= 0 Then
                                'Continue For
                                p_Error = True
                                Exit Sub
                            End If
                        Else
                            'p_Desc = p_SQL
                            p_Error = True
                            Exit Sub
                        End If
                        'End If

                    End If

                End If


            Next


        End If
    End Sub

    Private Sub FoxGetExtraField(ByVal p_LoaiVanChuyen As String, ByVal p_STT As Integer, ByVal p_DataMapCpLine As DataTable, ByVal p_DataTableFox As DataTable, _
                         ByRef p_SQLInsert As String, ByRef p_SQLValue As String)
        Dim p_Count As Integer
        Dim p_ArrRow() As DataRow
        Dim p_Field As String
        Dim p_InsSQL As String = ""
        Dim p_ValueSQL As String = ""
        Dim p_DataRow As DataRow
        Dim p_ColumnType As String
        Try
            For p_Count = 0 To p_DataTableFox.Rows.Count - 1
                p_ArrRow = Nothing
                p_Field = p_DataTableFox.Rows(p_Count).Item("FieldName").ToString.Trim
                p_ColumnType = p_DataTableFox.Rows(p_Count).Item("FieldType").ToString.Trim

                If UCase(p_LoaiVanChuyen) = "BO" Then
                    p_ArrRow = p_DataMapCpLine.Select("STT=" & p_STT & " and Bo='" & p_Field & "'")
                End If
                If UCase(p_LoaiVanChuyen) = "THUY" Then
                    p_ArrRow = p_DataMapCpLine.Select("STT=" & p_STT & " and Thuy='" & p_Field & "'")
                End If
                If UCase(p_LoaiVanChuyen) = "SAT" Then
                    p_ArrRow = p_DataMapCpLine.Select("STT=" & p_STT & " and Sat='" & p_Field & "'")
                End If
                If Not p_ArrRow Is Nothing Then
                    If p_ArrRow.Length = 0 Then
                        If UCase(p_ColumnType) = UCase("Int32") Or UCase(p_ColumnType) = UCase("Single") Or UCase(p_ColumnType) = UCase("Double") _
                       Or UCase(p_ColumnType) = UCase("byte") Or UCase(p_ColumnType) = UCase("decimal") Then
                            p_InsSQL = p_InsSQL & "," & p_Field
                            p_ValueSQL = p_ValueSQL & ",0"
                        End If
                        If UCase(p_ColumnType) = UCase("String") Then
                            p_InsSQL = p_InsSQL & "," & p_Field
                            p_ValueSQL = p_ValueSQL & ",''"
                        End If
                        If UCase(p_ColumnType) = UCase("DateTime") Or UCase(p_ColumnType) = UCase("Date") Then

                            p_InsSQL = p_InsSQL & "," & p_Field
                            p_ValueSQL = p_ValueSQL & ",{d '" & CDate(Now.Date).ToString("yyyy-MM-dd") & "'}"



                        End If
                    End If
                End If
                ' End If

            Next
            p_SQLInsert = p_SQLInsert & p_InsSQL
            p_SQLValue = p_SQLValue & p_ValueSQL
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetTyTrong_TyLeE5(ByVal p_TableID As String, ByVal p_MaLenh As String, ByVal p_NgayThang As Date, ByVal p_LineID As String, _
                                  ByRef p_Tyle As Double, ByRef p_TyTrongNen As Double, ByRef p_TyTrongEthanol As Double, ByRef p_HongXuat As Integer)
        'TYLE_PRESET()
        'TYTRONG_BASE()
        'TYTRONG_E()
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        p_Tyle = 0
        p_TyTrongNen = 0
        p_TyTrongEthanol = 0
        p_SQL = "exec FPT_TyLe_TyTrong '" & p_TableID & "','" & p_MaLenh & "','" & CDate(p_NgayThang).ToString("yyyyMMdd") & "','" & p_LineID & "'"
        p_DataTable = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                p_Tyle = p_DataTable.Rows(0).Item("ERate").ToString.Trim
                p_TyTrongNen = IIf(p_DataTable.Rows(0).Item("XangNen").ToString.Trim = "", 0, p_DataTable.Rows(0).Item("XangNen").ToString.Trim)
                p_TyTrongEthanol = IIf(p_DataTable.Rows(0).Item("Ethanol").ToString.Trim = "", 0, p_DataTable.Rows(0).Item("Ethanol").ToString.Trim)

                p_HongXuat = IIf(p_DataTable.Rows(0).Item("ArmNo").ToString.Trim = "", 0, p_DataTable.Rows(0).Item("ArmNo").ToString.Trim)

            End If
        End If
    End Sub




    Public Sub SQLGetColumnType(ByVal p_TypeIn As String, ByVal g_LoaiVanChuyen As String, ByVal p_FileName As String, ByRef p_FieldTypeScadar As String, _
                                 ByVal p_Terminal As String, ByVal p_HangHoaE5 As Boolean)
        Dim p_DataRowMap_cp() As DataRow
        Dim p_DataRow() As DataRow
        Dim p_FieldNameScadar As String
        p_FieldNameScadar = ""
        p_FieldTypeScadar = ""

        p_DataRowMap_cp = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and (Client='" & p_Terminal & "' or Client='" & UCase(p_Terminal) & "') ")
        If p_DataRowMap_cp.Length <= 0 Then
            Exit Sub
        End If
        If p_HangHoaE5 = True Then
            p_DataRow = g_DataMap_Line_cp.Select("STT=" & p_DataRowMap_cp(0).Item("STT") & " and FromField='" & p_FileName & "'")
            If p_DataRow.Length > 0 Then
                p_FieldNameScadar = p_DataRow(0).Item(g_LoaiVanChuyen).ToString.Trim
                p_DataRow = g_TableToScadar_E5.Select("FieldName='" & p_FieldNameScadar & "'")
                If p_DataRow.Length > 0 Then
                    p_FieldTypeScadar = p_DataRow(0).Item("FieldType").ToString.Trim
                End If
            End If
            Exit Sub
        Else
            If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                p_DataRow = g_DataMap_Line_cp.Select("STT=" & p_DataRowMap_cp(0).Item("STT") & " and FromField='" & p_FileName & "'")
                If p_DataRow.Length > 0 Then
                    p_FieldNameScadar = p_DataRow(0).Item("Bo").ToString.Trim
                    p_DataRow = g_TableToScadarBo.Select("FieldName='" & p_FieldNameScadar & "'")
                    If p_DataRow.Length > 0 Then
                        p_FieldTypeScadar = p_DataRow(0).Item("FieldType").ToString.Trim
                    End If
                End If
                Exit Sub
            End If
            If UCase(g_LoaiVanChuyen) = "THUY" Then
                p_DataRow = g_DataMap_Line_cp.Select("STT=" & p_DataRowMap_cp(0).Item("STT") & " and FromField='" & p_FileName & "'")
                If p_DataRow.Length > 0 Then
                    p_FieldNameScadar = p_DataRow(0).Item("Thuy").ToString.Trim
                    p_DataRow = g_TableToScadarThuy.Select("FieldName='" & p_FieldNameScadar & "'")
                    If p_DataRow.Length > 0 Then
                        p_FieldTypeScadar = p_DataRow(0).Item("FieldType").ToString.Trim
                    End If
                End If
                Exit Sub
            End If

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



    Public Function Sys_Execute_DataTbl_With_Connection(ByVal p_Connection As String, ByVal p_DataTable1 As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean 'Implements IService.Sys_Execute_DataTbl_With_Connection

        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter


        Dim Oleconnection As New OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction


        Sys_Execute_DataTbl_With_Connection = True
        Try
            Oleconnection.ConnectionString = p_Connection
            Oleconnection.Open()
            'Oleconnection = Sys_SQL_Connection()
            p_Oletransaction = Oleconnection.BeginTransaction
            Olecommand = New OleDbCommand
            With Olecommand
                .Connection = Oleconnection
                .Transaction = p_Oletransaction
                .CommandType = CommandType.Text
                For p_Count = 0 To p_DataTable1.Rows.Count - 1
                    If p_DataTable1.Rows(p_Count).Item(0).ToString <> "" Then
                        .CommandText = p_DataTable1.Rows(p_Count).Item(0).ToString
                        .ExecuteNonQuery()
                    End If
                Next
            End With
            p_Oletransaction.Commit()
            Oleconnection.Close()
            Oleconnection = Nothing
            p_Oletransaction = Nothing
        Catch ex As Exception
            p_Oletransaction.Rollback()
            p_Oletransaction = Nothing
            Oleconnection.Close()
            Oleconnection = Nothing
            p_Desc = Err.Number & "-Line " & p_Count + 1 & ":" & ex.Message
            Sys_Execute_DataTbl_With_Connection = False

        End Try

    End Function

    Public Function p_SYS_GET_DATATABLE_With_Connect_Des(ByVal p_ConnectStr As String, ByVal p_SQL As String, _
                                                ByRef p_DesErr As String) As DataTable
        'Dim dr As OleDbDataReader 

        'Dim connectionString As String
        Dim sSQL As String
        Dim p_Status As Boolean
        Dim p_DataTable As New DataTable

        Dim p_DataSet As New DataSet

        Dim p_Recorset As New Object
        Dim p_Int As Integer

        Dim Olecon As New OleDb.OleDbConnection
        Dim OlemyCommand As OleDb.OleDbCommand
        Dim p_OleAdapter As OleDb.OleDbDataAdapter
        ' Dim p_ConnectStr As String
        p_Status = True


        p_DesErr = ""
        'p_DataTable.c()
        sSQL = p_SQL
        Try
            'con.Open()
            'Olecon = Sys_SQL_Connection()
            'p_ConnectStr = SysGetConnect()
            Olecon.ConnectionString = p_ConnectStr
            Olecon.Open()
            If Olecon.State.ToString() = "Open" Then
                OlemyCommand = New OleDbCommand(sSQL, Olecon)

                OlemyCommand.CommandTimeout = 300
                p_OleAdapter = New OleDbDataAdapter(OlemyCommand)
                p_Int = p_OleAdapter.Fill(p_DataSet)
            Else
                p_Status = False
            End If

            Olecon.Close()
            Olecon = Nothing
            'mod_SYS_GET_DATATABLE = p_DataTable
            Return p_DataSet.Tables(0)


        Catch ex As Exception
            p_DesErr = "p_SYS_GET_DATATABLE_With_Connect_Des: " & ex.Message
            p_DataTable = Nothing
            Olecon = Nothing
            p_Status = False
            Return Nothing
        End Try

    End Function


    Private Sub GetPathFileFox(ByRef p_Path_Out As String, ByRef p_Path_In As String)
        Dim p_PathXml As String


    End Sub

    Public Function GetConnectFox(ByRef p_DessErr As String, ByVal p_TypeIn As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "") As Boolean
        Dim p_SQL As String
        Dim p_DataArr() As DataRow
        Dim p_FileType As String = ""
        Dim p_FileName As String = ""
        Dim p_DataTable As DataTable
        Dim p_Path As String = ""
        Dim p_FilePathOut, p_FilePathIn, p_FilePathTemp As String
        ' Dim p_Date As Date
        ' Dim p_Time As Integer
        GetConnectFox = True
        p_DessErr = "Không xác định file Scadar"
        If g_Table_Sys_Config Is Nothing Then
            p_SQL = "SELECT * FROM SYS_CONFIG"
            g_Table_Sys_Config = New DataTable
            ' g_Table_Sys_Config = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

            g_Table_Sys_Config = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If g_Table_Sys_Config.Rows.Count > 0 Then
                p_DataArr = g_Table_Sys_Config.Select("KEYCODE='TYPEFOXNAME'")
                If p_DataArr.Length > 0 Then
                    p_FileType = p_DataArr(0).Item("KEYVALUE").ToString.Trim
                End If
            End If
        Else
            p_DataArr = g_Table_Sys_Config.Select("KEYCODE='TYPEFOXNAME'")
            If p_DataArr.Length > 0 Then
                p_FileType = p_DataArr(0).Item("KEYVALUE").ToString.Trim
            End If
        End If

        If Not g_DataMap_cp Is Nothing Then
            If g_DataMap_cp.Rows.Count > 0 Then
                p_DataArr = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & p_TypeIn & "') and Client='" & p_Terminal & "'")
                If p_DataArr.Length > 0 Then

                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                        p_FileName = p_DataArr(0).Item("TableName").ToString.Trim
                    ElseIf UCase(g_LoaiVanChuyen) = "THUY" Then
                        p_FileName = p_DataArr(0).Item("TableName_Thuy").ToString.Trim
                    End If

                End If

            End If
        Else
            p_SQL = "SELECT * FROM tblMap_cp"
            ' g_Table_Sys_Config = New DataTable
            ' g_Table_Sys_Config = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

            g_DataMap_cp = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        End If
        If p_FileName = "[SPACE]" Or p_FileName = "SPACE" Then
            p_FileName = ""
        End If
        If p_FileType.ToString.Trim = "" Then
            GetConnectFox = False
            Exit Function
        End If

        p_SQL = "exec FPT_Get_FileName_Fox '" & UCase(p_FileType) & "'"
        p_DataTable = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                p_FileName = p_FileName & p_DataTable.Rows(0).Item(0).ToString.Trim & ".dbf"
            End If
        End If
        If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
            g_PathFileFoxBo = p_FileName
        Else
            g_PathFileFoxThuy = p_FileName
        End If

        GetPathFileFox_DB(p_FilePathOut, p_FilePathIn, p_FilePathTemp)

        'If p_FilePathOut = "" Or p_FilePathIn = "" Or p_FilePathTemp = " Then" Then
        '    GetPathFileFox_XML(p_FilePathOut, p_FilePathIn, p_FilePathTemp)
        'End If
        If UCase(p_TypeIn) = "OUT" Then
            p_Path = p_FilePathOut

        End If
        If UCase(p_TypeIn) = "IN" Then
            p_Path = p_FilePathIn
        End If
        If p_Path = "" Then
            GetConnectFox = False
            Exit Function
        End If

        If Right(p_Path, 1) = "\" Then
            p_FileName = p_Path & p_FileName
        Else
            p_FileName = p_Path & "\" & p_FileName
        End If
        If UCase(p_TypeIn) = "OUT" Then
            g_PathFileFoxOut = p_FileName
        End If
        If UCase(p_TypeIn) = "IN" Then
            g_PathFileFoxIn = p_FileName
        End If
        p_SQL = ""
        If CheckFileName(True, p_FileName, p_SQL) = False Then
            GetConnectFox = False
            Exit Function
        End If

        g_StrConnectFox = "Provider=vfpoledb;Collating Sequence=general;Data Source=" & p_Path


    End Function


    Public Function GetConnectAccess(ByRef p_DessErr As String, ByVal p_TypeIn As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "") As Boolean
        Dim p_SQL As String
        Dim p_DataArr() As DataRow
        Dim p_FileType As String = ""

        Dim p_FileType_thuy As String = ""

        Dim p_PathFileAcc As String = ""
        Dim p_UserFileAcc As String = ""
        Dim p_PassFileAcc As String = ""

        Dim p_FileName As String = ""
        Dim p_DataTable As DataTable
        Dim p_Path As String = ""
        Dim p_FilePathOut, p_FilePathIn, p_FilePathTemp As String
        ' Dim p_Date As Date
        ' Dim p_Time As Integer
        GetConnectAccess = True
        p_DessErr = "Không xác định file Scadar"
        If g_Table_Sys_Config Is Nothing Then
            p_SQL = "SELECT * FROM SYS_CONFIG"
            g_Table_Sys_Config = New DataTable
            ' g_Table_Sys_Config = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

            g_Table_Sys_Config = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If g_Table_Sys_Config.Rows.Count > 0 Then
                p_DataArr = g_Table_Sys_Config.Select("KEYCODE='TYPEACCNAME'")
                If p_DataArr.Length > 0 Then
                    p_FileType = p_DataArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataArr = g_Table_Sys_Config.Select("KEYCODE='TYPEACCNAME_THUY'")
                If p_DataArr.Length > 0 Then
                    p_FileType_thuy = p_DataArr(0).Item("KEYVALUE").ToString.Trim
                End If





            End If
        Else
            p_DataArr = g_Table_Sys_Config.Select("KEYCODE='TYPEACCNAME'")
            If p_DataArr.Length > 0 Then
                p_FileType = p_DataArr(0).Item("KEYVALUE").ToString.Trim
            End If
            p_DataArr = g_Table_Sys_Config.Select("KEYCODE='TYPEACCNAME_THUY'")
            If p_DataArr.Length > 0 Then
                p_FileType_thuy = p_DataArr(0).Item("KEYVALUE").ToString.Trim
            End If





        End If


        'p_FilePathOut = p_PathFileAcc
        'p_FilePathIn = p_PathFileAcc
        'p_FilePathTemp = p_PathFileAcc


        If Not g_DataMap_cp Is Nothing Then
            If g_DataMap_cp.Rows.Count > 0 Then
                p_DataArr = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & p_TypeIn & "') and Client='" & p_Terminal & "'")
                If p_DataArr.Length > 0 Then

                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                        p_FileName = p_DataArr(0).Item("TableName").ToString.Trim
                    ElseIf UCase(g_LoaiVanChuyen) = "THUY" Then
                        p_FileName = p_DataArr(0).Item("TableName_Thuy").ToString.Trim
                    End If

                End If

            End If
        Else
            p_SQL = "SELECT * FROM tblMap_cp"
            ' g_Table_Sys_Config = New DataTable
            ' g_Table_Sys_Config = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

            g_DataMap_cp = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        End If
        If p_FileName = "[SPACE]" Or p_FileName = "SPACE" Then
            p_FileName = ""
        End If
        If UCase(g_LoaiVanChuyen) = "THUY" Then
            p_FileType = p_FileType_thuy
        End If
        If p_FileType.ToString.Trim = "" Then
            GetConnectAccess = False
            Exit Function
        End If

        p_SQL = "exec FPT_Get_FileName_Access '" & UCase(p_FileType) & "'"
        p_DataTable = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                p_FileName = p_FileName & p_DataTable.Rows(0).Item(0).ToString.Trim
            End If
        End If
        If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
            g_PathFileFoxBo = p_FileName
        Else
            g_PathFileFoxThuy = p_FileName
        End If



        GetPathFileAccess_DB(p_FilePathOut, p_FilePathIn, p_FilePathTemp, p_UserFileAcc, p_PassFileAcc)

        'If p_FilePathOut = "" Or p_FilePathIn = "" Or p_FilePathTemp = " Then" Then
        '    GetPathFileAccess_XML(p_FilePathOut, p_FilePathIn, p_FilePathTemp, p_UserFileAcc, p_PassFileAcc)
        ' End If
        If UCase(p_TypeIn) = "OUT" Then
            p_Path = p_FilePathOut

        End If
        If UCase(p_TypeIn) = "IN" Then
            p_Path = p_FilePathIn
        End If
        If p_Path = "" Then
            GetConnectAccess = False
            Exit Function
        End If

        'If Right(p_Path, 1) = "\" Then
        '    p_FileName = p_Path & p_FileName
        'Else
        '    p_FileName = p_Path & "\" & p_FileName
        'End If
        If UCase(p_TypeIn) = "OUT" Then
            g_PathFileAccess = p_Path
        End If
        If UCase(p_TypeIn) = "IN" Then
            g_PathFileAccess = p_Path
        End If
        p_SQL = ""
        If CheckFileName(True, p_Path, p_SQL) = False Then
            GetConnectAccess = False
            Exit Function
        End If
        g_StrConnectAccess = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & g_PathFileAccess & ";Persist Security Info=True;Jet OLEDB:Database Password=" & p_PassFileAcc
        ' g_StrConnectAccess = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & g_PathFileAccess    ' "Provider=vfpoledb;Collating Sequence=general;Data Source=" & p_Path


    End Function


    Public Function CheckFileName(ByVal p_CheckFile As Boolean, ByVal p_PathFile As String, ByRef p_Err As String) As Boolean
        CheckFileName = False
        p_Err = ""
        Try
            If p_PathFile = "" Then
                p_Err = "Đường dẫn không xác định"
                Exit Function
            End If
            If p_CheckFile = True Then
                CheckFileName = File.Exists(p_PathFile)
            Else
                CheckFileName = Directory.Exists(p_PathFile)

            End If
        Catch ex As Exception
            CheckFileName = False
            p_Err = ex.Message
        End Try
    End Function




    Public Sub GetPathFileFox_DB(ByRef p_FoxOut As String, ByRef p_FoxIn As String, ByRef p_FoxTemp As String)
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_DataArr() As DataRow

        p_SQL = "SELECT * FROM SYS_CONFIG"
        p_Table = GetDataTable(p_SQL, p_SQL)
        p_FoxOut = ""
        p_FoxIn = ""
        p_FoxTemp = ""
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_DataArr = p_Table.Select("KEYCODE='FOX_IN'")
                If p_DataArr.Length > 0 Then
                    p_FoxIn = p_DataArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataArr = p_Table.Select("KEYCODE='FOX_OUT'")
                If p_DataArr.Length > 0 Then
                    p_FoxOut = p_DataArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataArr = p_Table.Select("KEYCODE='FOX_TEMP'")
                If p_DataArr.Length > 0 Then
                    p_FoxTemp = p_DataArr(0).Item("KEYVALUE").ToString.Trim
                End If
            End If
        End If
    End Sub


    'Public Sub GetPathFileFox_XML(ByRef p_FoxOut As String, ByRef p_FoxIn As String, ByRef p_FoxTemp As String)
    '    Dim p_SQL As String
    '    Dim p_Table As New DataTable
    '    Dim p_DAtaSet As New DataSet
    '    Dim p_DataArr() As DataRow
    '    Dim p_PathXML As String
    '    On Error Resume Next

    '    p_PathXML = Windows.Forms.Application.StartupPath & "\Config.xml"
    '    If Dir(p_PathXML) <> "" Then
    '        p_DAtaSet.ReadXml(p_PathXML)

    '        p_FoxOut = ""
    '        p_FoxIn = ""
    '        p_FoxTemp = ""
    '        If Not p_DAtaSet Is Nothing Then
    '            If p_DAtaSet.Tables.Count > 0 Then
    '                p_Table = p_DAtaSet.Tables(0)
    '            End If
    '        End If
    '        If Not p_Table Is Nothing Then
    '            If p_Table.Rows.Count > 0 Then

    '                p_FoxIn = p_Table.Rows(0).Item("FOXIN").ToString.Trim


    '                p_FoxOut = p_Table.Rows(0).Item("FOXOUT").ToString.Trim



    '                p_FoxTemp = p_Table.Rows(0).Item("FOXTEMP").ToString.Trim

    '            End If
    '        End If
    '    End If
    'End Sub







    Public Sub GetPathFileAccess_DB(ByRef p_FoxOut As String, ByRef p_FoxIn As String, ByRef p_FoxTemp As String, ByRef pUser As String, ByRef p_Pass As String)
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_DataArr() As DataRow
        Dim p_PathFileAcc As String = ""
        Dim p_UserFileAcc As String = ""
        Dim p_PassFileAcc As String = ""

        p_SQL = "SELECT * FROM SYS_CONFIG"
        p_Table = GetDataTable(p_SQL, p_SQL)
        p_FoxOut = ""
        p_FoxIn = ""
        p_FoxTemp = ""
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then


                p_DataArr = g_Table_Sys_Config.Select("KEYCODE='ACCESS_PATH'")
                If p_DataArr.Length > 0 Then
                    p_PathFileAcc = p_DataArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataArr = g_Table_Sys_Config.Select("KEYCODE='ACCESS_USER'")
                If p_DataArr.Length > 0 Then
                    p_UserFileAcc = p_DataArr(0).Item("KEYVALUE").ToString.Trim
                End If


                p_DataArr = g_Table_Sys_Config.Select("KEYCODE='ACCESS_PASS'")
                If p_DataArr.Length > 0 Then
                    p_PassFileAcc = p_DataArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_PassFileAcc = mdlCryptor_Decrypt(p_PassFileAcc, p_UserFileAcc)
                If p_PassFileAcc Is Nothing Then
                    p_PassFileAcc = ""
                End If

                p_FoxOut = p_PathFileAcc
                p_FoxIn = p_PathFileAcc
                p_FoxTemp = p_PathFileAcc
                pUser = p_UserFileAcc
                p_Pass = p_PassFileAcc


            End If
        End If
    End Sub


    'Public Sub GetPathFileAccess_XML(ByRef p_FoxOut As String, ByRef p_FoxIn As String, ByRef p_FoxTemp As String, ByRef pUser As String, ByRef p_Pass As String)
    '    Dim p_SQL As String
    '    Dim p_Table As New DataTable
    '    Dim p_DAtaSet As New DataSet
    '    Dim p_DataArr() As DataRow
    '    Dim p_PathXML As String

    '    Dim p_PathFileAcc As String = ""
    '    Dim p_UserFileAcc As String = ""
    '    Dim p_PassFileAcc As String = ""


    '    On Error Resume Next

    '    p_PathXML = Windows.Forms.Application.StartupPath & "\Config.xml"
    '    If Dir(p_PathXML) <> "" Then
    '        p_DAtaSet.ReadXml(p_PathXML)

    '        p_FoxOut = ""
    '        p_FoxIn = ""
    '        p_FoxTemp = ""
    '        If Not p_DAtaSet Is Nothing Then
    '            If p_DAtaSet.Tables.Count > 0 Then
    '                p_Table = p_DAtaSet.Tables(0)
    '            End If
    '        End If
    '        If Not p_Table Is Nothing Then
    '            If p_Table.Rows.Count > 0 Then


    '                p_PathFileAcc = p_Table.Rows(0).Item("ACCTEMP").ToString.Trim


    '                p_UserFileAcc = p_Table.Rows(0).Item("ACCUSER").ToString.Trim



    '                p_PassFileAcc = p_Table.Rows(0).Item("ACCPASS").ToString.Trim

    '                p_PassFileAcc = mdlCryptor_Decrypt(p_PassFileAcc, p_UserFileAcc)
    '                If p_PassFileAcc Is Nothing Then
    '                    p_PassFileAcc = ""
    '                End If
    '                p_FoxOut = p_PathFileAcc
    '                p_FoxIn = p_PathFileAcc
    '                p_FoxTemp = p_PathFileAcc
    '                pUser = p_UserFileAcc
    '                p_Pass = p_PassFileAcc
    '            End If
    '        End If
    '    End If
    'End Sub


    Public Function mdlCryptor_Decrypt(ByVal cipherText As String, ByVal Key As String) As String

        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(Key))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = System.Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(cipherText)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    Public Function GetDataSet(ByVal p_SQL As String, ByVal p_Error As String) As DataSet
        Dim p_Datatable As DataSet
        Try
            p_Datatable = g_ConnectHTTG.p_SYS_GET_DATASET_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message


            Return Nothing
        End Try
        Return p_Datatable

    End Function


    Public Function GetDataTable(ByVal p_SQL As String, ByVal p_Error As String) As DataTable
        Dim p_Datatable As DataTable
        Try
            p_Datatable = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message
            'ShowMessageBox(Err.Number, p_Error)
            Return Nothing
        End Try
        Return p_Datatable

    End Function



End Class

