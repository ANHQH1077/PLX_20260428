Imports System.Data.OleDb
Imports System.Xml
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Module Module2
    Public Constant_P_Bo = "Bo"
    Public Constant_P_Thuy = "Thuy"
    Public Constant_P_eBo = "eBo"
    Public Constant_P_eThuy = "eThuy"
    Public Constant_P_HeSoCongTo = "HeSoCongTo"
    Public Constant_P_eTimeStop = "eTimeStop"
    Public Constant_P_eTimeFlagBo = "eTimeFlagBo"
    Public Constant_P_eTimeFlagThuy = "eTimeFlagThuy"
    Public Constant_P_eTimeDefault = "eTimeDefault"
    Public Constant_P_eMapMaHangHoa = "eMapMaHangHoa"
    Public Constant_P_CheckMetter = "CheckMetter"
    Public Constant_P_MaTuDongHoa = "MaTuDongHoa"
    Public Constant_P_Sat = "Sat"
    Public Constant_P_upThucXuat = "upThucXuat"
    Public Constant_P_eSat = "eSat"
    Public Constant_P_MeterDens = "MeterDens"
    Public Constant_P_FO = "FO"
    Public Constant_P_Password = "Password"
    Public g_Client_E5_Upper As String = ""
    Public g_Client_E5 As String = ""
    Dim i_dt_para As New DataTable


    Const g_KEY_DB_NAME As String = "DB_NAME"
    Const g_KEY_USER As String = "DB_USER"
    Const g_KEY_PASS As String = "DB_PASS"
    Const g_KEY_SERVER As String = "DB_IPADDRESS"
    Const g_KEY_PORT As String = "DB_PORT"
    Const g_Service As String = "Service"



    Public g_UserName As String = ""

    'anhqh
    '20160810


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


                    'anhqh
                    '20170622

                    g_Client_E5_Upper = p_Client & g_Client_E5_Upper
                    g_Client_E5 = p_Client & g_Client_E5

                    'g_Client_E5_Upper = "A" & g_Client_E5_Upper
                    'g_Client_E5 = "A" & g_Client_E5

                End If
            End If
        End If
    End Sub



    Public Sub GetMaVanChuyen(ByVal p_maphuongtien As String, ByVal p_MaVanChuyen As String, ByRef l_mavanchuyen As String)
        Dim p_SQL As String = "select * from tblPara"
        Dim l_mavanchuyen_convert As String

        i_dt_para = GetDataTable(p_SQL, p_SQL)

        l_mavanchuyen = p_MaVanChuyen
        l_mavanchuyen_convert = mdlDelivery_CheckTransmot(l_mavanchuyen, i_dt_para)
        If l_mavanchuyen_convert = "Thuy" Then
            If mdlFunction_GetParaValue(Constant_P_eThuy) = "0" Then
                l_mavanchuyen = p_maphuongtien
            Else
                l_mavanchuyen = mdlFunction_GetParaValue(Constant_P_eThuy)
            End If
        ElseIf l_mavanchuyen_convert = "Bo" Then
            If mdlFunction_GetParaValue(Constant_P_eBo) = "0" Then
                l_mavanchuyen = p_maphuongtien
            Else
                l_mavanchuyen = mdlFunction_GetParaValue(Constant_P_eBo)
            End If
        ElseIf l_mavanchuyen_convert = "Sat" Then
            If mdlFunction_GetParaValue(Constant_P_eSat) = "0" Then
                l_mavanchuyen = p_maphuongtien
            Else
                l_mavanchuyen = mdlFunction_GetParaValue(Constant_P_eSat)
            End If
        End If


    End Sub


    Public Function mdlDelivery_CheckTransmot(ByVal i_mavanchuyen As String, ByVal i_dt_para As DataTable) As String
        Dim l_bo, _
            l_thuy, _
            l_sat As String()

        Try
            '----------------------------------------------------------------
            '   Para:
            '       Index 0: Bo
            '       Index 1: Thuy
            '----------------------------------------------------------------
            l_bo = i_dt_para.Rows(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            l_thuy = i_dt_para.Rows(1).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)

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

    Public Function mdlFunction_GetParaValue(ByVal i_paraname As String) As String
        Try
            Dim l_dr As DataRow()
            l_dr = i_dt_para.Select("Para = '" & i_paraname & "'")

            If l_dr.Length > 0 Then
                Return l_dr(0).Item("Value_nd").ToString().Trim()
            End If

            Return String.Empty
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function



    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL trong DataTable

    Public Function Sys_Execute(ByVal p_SQL As String, _
                                          ByRef p_Desc As String) As Boolean

        ' Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter


        Dim Oleconnection As New OleDbConnection
        Dim Olecommand As OleDbCommand
        'Dim p_Oletransaction As OleDbTransaction

        Oleconnection = Sys_SQL_Connection()
        Sys_Execute = True
        Olecommand = New OleDbCommand
        Try
            ' p_Oletransaction = Oleconnection.BeginTransaction
            With Olecommand
                .Connection = Oleconnection
                ' .Transaction = p_Oletransaction
                .CommandTimeout = 600
                .CommandType = CommandType.Text
                If p_SQL <> "" Then
                    .CommandText = p_SQL
                    .ExecuteNonQuery()
                End If
            End With
            ' p_Oletransaction.Commit()
            Olecommand.Dispose()
            Oleconnection.Dispose()
            Oleconnection.Close()

        Catch ex As Exception
            p_Desc = ex.Message
            Sys_Execute = False
            Olecommand.Dispose()
            Oleconnection.Dispose()
            Oleconnection.Close()
        End Try


    End Function


    'Tao Connection den DB
    Private Function Sys_SQL_Connection() As OleDbConnection 'Implements IService.Sys_SQL_Connection
        Dim con As New OleDbConnection()
        Dim connectionString As String
        connectionString = SysGetConnect()
        Try
            'connectionString = "Provider=SQLOLEDB;Data Source=10.15.20.139;Persist Security Info=True;User ID=fes_AnhQH" & _
            '        ";Password=AnhQH@FES12345;Initial Catalog=FPTCUSTOMIZE"
            Sys_SQL_Connection = New OleDbConnection(connectionString)
            Sys_SQL_Connection.Open()
            'Sys_SQL_Connection = con
        Catch ex As Exception
            Sys_SQL_Connection = Nothing
        End Try
    End Function

    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL 

    Public Function Sys_Execute_DataTableNew(ByVal p_DataTable As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean

        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter


        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction


        Sys_Execute_DataTableNew = True
        Try
            Oleconnection = Sys_SQL_Connection()
            p_Oletransaction = Oleconnection.BeginTransaction
            Olecommand = New OleDbCommand
            With Olecommand
                .Connection = Oleconnection
                .Transaction = p_Oletransaction
                .CommandType = CommandType.Text
                For p_Count = 0 To p_DataTable.Rows.Count - 1
                    If p_DataTable.Rows(p_Count).Item(0).ToString <> "" Then
                        .CommandText = p_DataTable.Rows(p_Count).Item(0).ToString
                        .ExecuteNonQuery()
                    End If
                Next
            End With
            p_Oletransaction.Commit()
            'Oleconnection.Close()
            Olecommand.Dispose()
            Oleconnection.Close()
            Oleconnection.Dispose()
            Oleconnection = Nothing

        Catch
            p_Oletransaction.Rollback()
            p_Desc = Err.Description
            Sys_Execute_DataTableNew = False
            If Not Oleconnection Is Nothing Then
                Olecommand.Dispose()
                Oleconnection.Close()
                Oleconnection.Dispose()
                Oleconnection = Nothing
            End If
        End Try

    End Function


    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataTable
    Public Function mod_SYS_GET_DATATABLE(ByVal p_SQL As String) As System.Data.DataTable
        'Dim dr As OleDbDataReader 

        'Dim connectionString As String
        Dim sSQL As String
        Dim p_Status As Boolean
        Dim p_DataTable As New System.Data.DataTable

        Dim p_DataSet As New System.Data.DataSet

        Dim p_Recorset As New Object
        Dim p_Int As Integer

        Dim Olecon As New OleDb.OleDbConnection
        Dim OlemyCommand As OleDb.OleDbCommand
        Dim p_OleAdapter As OleDb.OleDbDataAdapter
        Dim p_ConnectStr As String
        p_Status = True



        'p_DataTable.c()
        sSQL = p_SQL
        Try
            'con.Open()
            'Olecon = Sys_SQL_Connection()
            p_ConnectStr = SysGetConnect()
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
            p_DataTable = p_DataSet.Tables(0)
            Return p_DataTable


        Catch
            p_DataTable = Nothing
            p_Status = False
            Return Nothing
        End Try

    End Function


    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL 

    Public Function Sys_Execute_DataTbl(ByVal p_DataTable1 As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean

        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter


        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction


        Sys_Execute_DataTbl = True
        Try

            Oleconnection = New OleDbConnection
            Olecommand = New OleDbCommand

            Oleconnection = Sys_SQL_Connection()
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
            Olecommand.Dispose()
            Oleconnection.Close()
            Oleconnection.Dispose()
            Oleconnection = Nothing
            p_Oletransaction = Nothing
        Catch ex As Exception
            p_Oletransaction.Rollback()
            p_Oletransaction = Nothing
            p_Desc = Err.Number & "-Line " & p_Count + 1 & ":" & ex.Message
            Sys_Execute_DataTbl = False
            Olecommand.Dispose()
            Oleconnection.Close()
            Oleconnection.Dispose()
            Oleconnection = Nothing
        End Try

    End Function


    Public Sub ModSys_GetParameterOracle(ByRef p_DBTYPE As String)
        SysGetStrConnect()
        p_DBTYPE = g_DBTYPE
    End Sub



    'ANHQH
    '26/06/2014
    'Ham 1 cau lenh SQL
    'Tra ve bien DataTable
    Public Function Sys_SYS_GET_DATATABLE_Des(ByVal p_SQL As String, _
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
        Dim p_ConnectStr As String
        p_Status = True


        p_DesErr = ""
        'p_DataTable.c()
        sSQL = p_SQL
        Try
            'con.Open()
            'Olecon = Sys_SQL_Connection()
            p_ConnectStr = SysGetConnect()
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
            OlemyCommand.Dispose()
            Olecon.Close()
            Olecon = Nothing
            'mod_SYS_GET_DATATABLE = p_DataTable
            Return p_DataSet.Tables(0)


        Catch ex As Exception
            p_DesErr = ex.Message
            p_DataTable = Nothing
            p_Status = False
            If Not Olecon Is Nothing Then

                If Olecon.State = ConnectionState.Open Then
                    OlemyCommand.Dispose()
                    Olecon.Close()
                    Olecon = Nothing
                End If
            End If

            Return Nothing
        End Try

    End Function


    Public Function Sys_SYS_GET_DATASET_Des(ByVal p_SQL As String, _
                                                ByRef p_DesErr As String) As System.Data.DataSet
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
        Dim p_ConnectStr As String
        p_Status = True


        p_DesErr = ""
        'p_DataTable.c()
        sSQL = p_SQL
        Try
            'con.Open()
            'Olecon = Sys_SQL_Connection()
            p_ConnectStr = SysGetConnect()
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
            OlemyCommand.Dispose()
            Olecon.Close()
            Olecon = Nothing
            'mod_SYS_GET_DATATABLE = p_DataTable
            Return p_DataSet


        Catch ex As Exception
            p_DesErr = ex.Message
            'p_DataTable = Nothing
            p_Status = False
            If Not Olecon Is Nothing Then
                If Olecon.State = ConnectionState.Open Then
                    OlemyCommand.Dispose()
                    Olecon.Close()
                    Olecon = Nothing
                End If
            End If
            Return Nothing
        End Try

    End Function



    'ANHQH
    '21/11/2011
    'Ham Tra ve chuoi ket noi voi CSDL
    Private Function SysGetConnect() As String
        Dim p_ConStr As String
        SysGetStrConnect()
        p_ConStr = ""
        If g_DB_Name <> "" Then
            If g_DBPortInstance.ToString.Trim = "" Then
                p_ConStr = "Provider=SQLOLEDB;Data Source=" & g_Server & ";Persist Security Info=True;User ID=" & _
                    g_UserName & ";Password=" & g_Password & ";Initial Catalog=" & g_DB_Name & ";Connect Timeout=300"
            Else
                p_ConStr = "Provider=SQLOLEDB;Server=" & g_Server & "," & g_DBPortInstance & ";" & _
                        "Database=" & g_DB_Name & ";User ID=" & g_UserName & ";Password=" & g_Password & ";" & _
                        "Trusted_Connection=False;Connect Timeout=300"
            End If

        End If

        SysGetConnect = p_ConStr
    End Function



    'ANHQH
    '24/11/2011
    'Ham lay thong tin ket noi may chu tren Register
    Private Sub SysGetStrConnect()
        Dim p_Path As String

        ' Try

        Dim p_DataSet As New DataSet
        Dim g_Config_XMLDatatable As DataTable

        Dim p_PassEn As String = ""

        Try
            If Not g_tblXML Is Nothing Then
                If g_tblXML.Rows.Count > 0 Then
                    g_DB_Name = g_tblXML.Rows(0).Item(g_KEY_DB_NAME).ToString.Trim    'xml.GetAttribute(g_KEY_DB_NAME)
                    g_Server = g_tblXML.Rows(0).Item(g_KEY_SERVER).ToString.Trim  'xml.GetAttribute(g_KEY_SERVER)
                    g_UserName = g_tblXML.Rows(0).Item(g_KEY_USER).ToString.Trim  '   xml.GetAttribute(g_KEY_USER)
                    'g_UserName = "fes_AnhQH"
                    g_Password = g_tblXML.Rows(0).Item(g_KEY_PASS).ToString.Trim  '  xml.GetAttribute(g_KEY_PASS)
                    'g_Password = "AnhQH@FES12345"
                    g_DBPortInstance = g_tblXML.Rows(0).Item(g_KEY_PORT).ToString.Trim  '   xml.GetAttribute(g_KEY_PORT)

                    g_DBTYPE = g_tblXML.Rows(0).Item(g_DBTYPE_Key).ToString.Trim   'Xml.GetAttribute(g_DBTYPE_Key)
                End If
            End If
        Catch ex As Exception

        End Try

        p_PassEn = mdlCryptor_Decrypt(g_Password, g_UserName)
        If p_PassEn Is Nothing Then
            p_PassEn = p_PassEn
        End If
        g_Password = p_PassEn

    End Sub



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

End Module
