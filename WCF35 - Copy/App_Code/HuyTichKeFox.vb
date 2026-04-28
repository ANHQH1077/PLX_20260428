Imports Microsoft.VisualBasic

Imports System.Data.OleDb
Imports System.IO
Imports System.Data


Public Class HuyTichKeFox

    Private g_KV1 As Boolean = False
    Private g_BATCHSLOG As Boolean = False

    ' Private g_ObjectFox As New HTTG_SCADAR_FOX
    Private g_ConnectHTTG As New ConnectHTTG

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
            p_DataSet = g_ConnectHTTG.p_SYS_GET_DATASET_Des(p_SQL, p_SQL)
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

            g_ConnectHTTG.Sys_GetParameterOracle(g_DBTYPE)
            '20150819
            If Not g_TabletblConfig Is Nothing Then
                If g_TabletblConfig.Rows.Count > 0 Then
                    g_TypeConnet = g_TabletblConfig.Rows(0).Item("optional").ToString.Trim()
                End If
            End If

            '20150819
            ' If UCase(g_TypeConnet) = "FOX" Then
            If GetConnectFox(p_Desc, p_TypeIn, g_LoaiVanChuyen, p_Terminal) = False Then
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
            Select Case UCase(g_TypeConnet)
                Case "SQL"
                    g_ConnectToScadar = "Provider=SQLOLEDB;Data Source=" & p_DataRow(0).Item("ServerScada").ToString.Trim & ";Persist Security Info=True;User ID=" & _
                         p_DataRow(0).Item("UidScada").ToString.Trim & ";Password=" & p_DataRow(0).Item("PwdScada").ToString.Trim & _
                                ";Initial Catalog=" & p_DataRow(0).Item("DatabaseScada").ToString.Trim & ";Connect Timeout=300"
                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                        p_TableName = p_DataRow(0).Item("TableName").ToString.Trim
                        p_SQL = "select * from [" & p_TableName & "] where 1=0"
                        p_DataTable = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                        g_TableToScadarBo = GetStructTbaleScadar(p_DataTable)
                    End If
                    If UCase(g_LoaiVanChuyen) = "THUY" Then
                        p_TableName = p_DataRow(0).Item("TableName_Thuy").ToString.Trim
                        p_SQL = "select * from [" & p_TableName & "] where 1=0"
                        p_DataTable = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                        g_TableToScadarThuy = GetStructTbaleScadar(p_DataTable)
                    End If
                Case "FOX"
                    '20150819
                    ' dfgdg()

                    '
                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                        p_TableName = g_PathFileFoxBo
                        p_SQL = "select * from " & p_TableName & " where 1=0"
                        p_DataTable = New DataTable
                        'p_DataTable = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                        p_DataTable = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)

                        '  Exit Sub
                        g_TableToScadarBo = GetStructTbaleScadar(p_DataTable)


                    Else
                        p_TableName = g_PathFileFoxThuy
                        p_SQL = "select * from " & p_TableName & " where 1=0"
                        p_DataTable = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                        g_TableToScadarThuy = GetStructTbaleScadar(p_DataTable)
                    End If


                Case Else
                    Exit Sub
            End Select

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
        If g_StrConnectFox.ToString.Trim = "" Then
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
        p_DataHTTG = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                            If UCase(g_TypeConnet) = "FOX" Or p_HangHoaE5 = False Then
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
                                p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                               p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
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
                                    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                   p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
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
                        If UCase(g_TypeConnet) = "FOX" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    ' Continue For
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
                        g_ConnectHTTG.Sys_GetParameterOracle(g_DBTYPE)
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
                        'If UCase(g_TypeConnet) = "ACC" Then
                        '    If Sys_Execute_DataTbl_With_Connection(g_StrConnectAccess, p_TableExec, p_SQL) = False Then

                        '        p_Desc = p_SQL
                        '        p_Error = True
                        '        Exit Sub

                        '    End If

                        'End If
                    End If
                End If
            End If

            If Not p_TableExec_E5 Is Nothing Then
                If p_TableExec_E5.Rows.Count > 0 Then
                    If g_DBTYPE = "" Then
                        g_ConnectHTTG.Sys_GetParameterOracle(g_DBTYPE)
                    End If
                    'If g_DBTYPE = "ORACLE" Then
                    '    If g_ConnectHTTG.Execute_DataTbl_With_Connection(g_ConnectToScadar, p_TableExec_E5, p_SQL) = False Then
                    '        'MsgBox(p_SQL)
                    '        'g_Module.ModErrExceptionNew("", p_SQL)
                    '        p_Desc = p_SQL
                    '        p_Error = True
                    '        Exit Sub
                    '        ' Else

                    '    End If
                    'ElseIf g_DBTYPE = "SQL" Then
                    If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar_E5, p_TableExec_E5, p_SQL) = False Then
                        'MsgBox(p_SQL)
                        'g_Module.ModErrExceptionNew("", p_SQL)
                        p_Desc = p_SQL
                        p_Error = True
                        Exit Sub
                        'Else
                    End If
                    ' End If

                End If
            End If

            p_TableExec.Clear()

            p_DataRow = p_TableExec.NewRow
            p_DataRow.Item(0) = "delete from tblTichke where SoLenh='" & p_SoLenh & "'"
            p_TableExec.Rows.Add(p_DataRow)

            '  ReTableID(p_SoLenh, p_TableExec)

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


            If g_ConnectHTTG.Sys_Execute_DataTbl(p_TableExec, p_SQL) = False Then
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

            If g_ConnectHTTG.Sys_Execute_DataTbl(p_TableExec, p_SQL) = False Then
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
        p_DataHTTG = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                                'If GetScadarWagonKV1() = True Then
                                '    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                '    p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & IIf(UCase(g_LoaiVanChuyen) = "SAT", "ZR", "AB") & "'"
                                'Else
                                p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                ' End If


                                '   p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                ' p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
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
                                    '  p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    'p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                    'anhqh
                                    '20160704
                                    'themdieu kien cho KV1
                                    'If GetScadarWagonKV1() = True Then
                                    '    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    '    p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & IIf(UCase(g_LoaiVanChuyen) = "SAT", "ZR", "AB") & "'"
                                    'Else
                                    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                    p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                    ' End If

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
                        g_ConnectHTTG.Sys_GetParameterOracle(g_DBTYPE)
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
                        g_ConnectHTTG.Sys_GetParameterOracle(g_DBTYPE)
                    End If
                    'If g_DBTYPE = "ORACLE" Then
                    '    If Execute_DataTbl_With_Connection(g_ConnectToScadar, p_TableExec_E5, p_SQL) = False Then
                    '        'MsgBox(p_SQL)
                    '        'g_Module.ModErrExceptionNew("", p_SQL)
                    '        p_Desc = p_SQL
                    '        p_Error = True
                    '        Exit Sub
                    '        ' Else

                    '    End If
                    'ElseIf g_DBTYPE = "SQL" Then
                    If Sys_Execute_DataTbl_With_Connection(g_ConnectToScadar_E5, p_TableExec_E5, p_SQL) = False Then
                        'MsgBox(p_SQL)
                        'g_Module.ModErrExceptionNew("", p_SQL)
                        p_Desc = p_SQL
                        p_Error = True
                        Exit Sub
                        'Else
                    End If
                    '  End If

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


            If g_ConnectHTTG.Sys_Execute_DataTbl(p_TableExec, p_SQL) = False Then
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

            If g_ConnectHTTG.Sys_Execute_DataTbl(p_TableExec, p_SQL) = False Then
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



    Public Function GetDataSet(ByVal p_SQL As String, ByVal p_Error As String) As DataSet
        Dim p_Datatable As DataSet
        Try
            p_Datatable = g_ConnectHTTG.p_SYS_GET_DATASET_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message

            '  ShowMessageBox(Err.Number, p_Error)
            Return Nothing
        End Try
        Return p_Datatable

    End Function



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
        p_DataHTTG = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                                        p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                       p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
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
        p_DataHTTG = g_ConnectHTTG.p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                                        p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                       p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
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


End Class
