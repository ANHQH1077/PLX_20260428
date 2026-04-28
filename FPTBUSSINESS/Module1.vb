Imports System.Data
Imports Microsoft.VisualBasic.FileIO
'Imports System.Web.Services
Imports System.IO
'Imports System.ServiceModel

Imports System.Data.OleDb
'Imports VFPOLEDBLib

Imports Microsoft.VisualBasic
'Imports Microsoft.Win3
Imports VFPOLEDBLib

'Imports System.Data.OracleClient
'Imports System.Data
Imports System.Xml
Imports System.Security.Cryptography
'Imports System.IO
Imports System.Windows.Forms

Module Module1

    Public Const g_ORAHOST_Key As String = "ORAHOST"
    Public Const g_ORAPORT_Key As String = "ORAPORT"
    Public Const g_SERVERNAME_Key As String = "SERVERNAME"
    Public Const g_ORAUSER_Key As String = "ORAUSER"
    Public Const g_ORAPASS_Key As String = "ORAPASS"
    Public Const g_DBTYPE_Key As String = "DBTYPE"

    Public g_ORAHOST As String
    Public g_ORAPORT As String
    Public g_SERVERNAME As String
    Public g_ORAUSER As String
    Public g_ORAPASS As String
    Public g_DBTYPE As String


    Public g_Company_Host As String
    Public g_Company_DB_Name As String

    Public g_Server As String
    Public g_UserName As String
    Public g_Password As String

    Const g_RowNum As Integer = 20
    Public g_DBPortInstance As String
    Public g_DB_Name As String

    Const g_KEY_DB_NAME As String = "DB_NAME"
    Const g_KEY_USER As String = "DB_USER"
    Const g_KEY_PASS As String = "DB_PASS"
    Const g_KEY_SERVER As String = "DB_IPADDRESS"
    Const g_KEY_PORT As String = "DB_PORT"
    Const g_Service As String = "Service"

    Public g_DataMap_cp As DataTable = Nothing
    Public g_DataMap_Line_cp As DataTable = Nothing
    Public g_TableToScadarBo As DataTable = Nothing
    Public g_TableToScadarThuy As DataTable = Nothing
    Public g_Table_Sys_Config As DataTable = Nothing
    Public g_TableToScadar_E5 As DataTable = Nothing
    Public g_TableMaHangHoaE5 As DataTable = Nothing
    Public g_TabletblConfig As DataTable = Nothing

    Public g_ConnectToScadar As String
    Public g_ConnectToScadar_E5 As String
    'Public g_DBTYPE As String = "SQL"
    'Public g_Terminal_E5 As String = ""
    Public g_MaTuDongHoa As String = "N" 'Neu ='Y' thi la FOX    'N' thi la SQL
    Public g_MaNgan_DD As String 'Do dai cua ma ngan

    Public g_User_ID As Integer
    Public g_Company_Code

    Private p_FunctionTableId As String

    Public g_StrConnectFox As String = "aaaaaa"
    Public g_PathFileFoxOut As String
    Public g_PathFileFoxIn As String

    Public g_PathFileFoxThuy As String
    Public g_PathFileFoxBo As String
    Public g_TypeConnet As String = "SQL"
    Public g_Wcf As Boolean = True




    Function ModReadFile1(ByVal FilePath As String, ByVal Position As Long, ByVal Count As Long, ByRef Exception As String) As Byte()
        Exception = ""
        Try
            Using FileStream As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
                FileStream.Seek(Position, SeekOrigin.Begin)
                Dim ByteToRead As Long
                If FileStream.Length - Position >= Count Then
                    ByteToRead = Count
                Else
                    ByteToRead = FileStream.Length - Position
                End If
                Dim Data(ByteToRead - 1) As Byte
                FileStream.Read(Data, 0, ByteToRead)
                Return Data
            End Using
        Catch ex As Exception
            Exception = ex.Message
            Return Nothing
        End Try
    End Function


    Public Function GetData1(ByVal value As Integer) As String
        Return String.Format("You entered: {0}", value)
    End Function






    Public Function GetDataTable1(ByVal sql As String) As DataTable
        Dim cm As OleDbCommand = Nothing
        Dim da As OleDbDataAdapter = Nothing
        Dim ds As New DataSet
        Dim dt As DataTable = Nothing
        Dim conn As OleDb.OleDbConnection
        conn = Sys_SQL_Connection()
        If conn.State = ConnectionState.Open Then
            Try
                cm = New OleDbCommand(sql, conn)
                cm.CommandTimeout = 60
                da = New OleDbDataAdapter(cm)
                Try
                    ds.Tables.Remove("Store")
                Catch ex As Exception
                End Try
                da.Fill(ds, "Store")
                dt = ds.Tables.Item("Store")
                cm.Dispose()
                da.Dispose()
                Return dt
            Catch ex As Exception
                cm.Dispose()
                da.Dispose()
                Return Nothing
            End Try
        End If
        Return Nothing
    End Function

    'ANHQH
    '21/11/2011
    'Ham kiem tra User va password
    Public Function SysLogin1(ByVal g_IP_Address As String, _
                                ByVal g_GetHostName As String, ByVal p_User As String, ByVal p_Pass As String, _
                                ByRef p_User_ID As Double) As String


        Dim p_OLEDataReader As OleDbDataReader  ' OleDbDataReader
        Dim p_OLEmyCommand As OleDbCommand
        Dim p_OLE_Connect As OleDbConnection
        Dim encoder As New System.Text.UTF8Encoding()
        Dim p_PassStr_Arr As Byte()
        Dim p_PassStr As String
        ' Dim connectionString As String
        Dim p_SQL As String
        Dim p_Status As String

        Dim md5Hasher As New System.Security.Cryptography.MD5CryptoServiceProvider()

        Dim p_ENCRYPTED_USER_PASSWORD As String = ""

        p_Status = "F"
        p_User_ID = 0
        p_SQL = "SELECT  user_id, User_Name, ENCRYPTED_USER_PASSWORD FROM sys_user WHERE upper(User_Name)='" & UCase(p_User) & _
            "'  AND CONVERT (date, GETDATE ()) BETWEEN ISNULL(START_DATE,CONVERT (date, GETDATE ())) AND ISNULL(END_DATE,CONVERT (date, GETDATE ()))"
        Try


            p_OLE_Connect = Sys_SQL_Connection()

            If p_OLE_Connect.State.ToString() = "Open" Then
                Using myRijndael = Rijndael.Create()
                    p_PassStr_Arr = md5Hasher.ComputeHash(encoder.GetBytes(p_Pass))
                    p_PassStr = Convert.ToBase64String(p_PassStr_Arr)
                End Using
                p_OLEmyCommand = New OleDbCommand(p_SQL, p_OLE_Connect)
                p_OLEDataReader = p_OLEmyCommand.ExecuteReader
                While p_OLEDataReader.Read()

                    p_User_ID = p_OLEDataReader(0)
                    p_ENCRYPTED_USER_PASSWORD = p_OLEDataReader(2)
                End While
                If p_User_ID > 0 And p_ENCRYPTED_USER_PASSWORD = p_PassStr Then
                    p_Status = "T"
                    p_SQL = "UPDATE SYS_USER SET LAST_LOGON_DATE=GETDATE ()," & _
                            "LOGIN_WORK_STATION='" & g_GetHostName & "', LOGIN_IP_ADDRESS='" & g_IP_Address & "' " & _
                            " WHERE user_id=" & p_User_ID
                    p_OLEmyCommand = New OleDbCommand(p_SQL, p_OLE_Connect)

                    p_OLEmyCommand.ExecuteNonQuery()
                End If
                p_OLEDataReader.Close()
            End If
            p_OLE_Connect.Close()
        Catch
            p_Status = "E"
            p_OLE_Connect = Nothing
        End Try
        SysLogin1 = p_Status
        p_OLE_Connect = Nothing
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



    Public Function Sys_SQL_ConnectionTest() As OleDb.OleDbConnection
        Dim p_Connect As New OleDbConnection()
        Dim connectionString As String
        connectionString = SysGetConnect()
        Try
            'Sys_SQL_ConnectionTest = 1
            'connectionString = "Provider=SQLOLEDB;Data Source=10.15.20.139;Persist Security Info=True;User ID=fes_AnhQH" & _
            '        ";Password=AnhQH@FES12345;Initial Catalog=FPTCUSTOMIZE"
            p_Connect = New OleDbConnection(connectionString)

            'Sys_SQL_ConnectionTest = 2
            p_Connect.Open()
            If p_Connect.State = ConnectionState.Open Then
                'p_Connect = con
                'Sys_SQL_ConnectionTest = 3
            Else
                'Sys_SQL_ConnectionTest = 5
            End If
            'Sys_SQL_Connection = con
        Catch ex As Exception
            'Sys_SQL_ConnectionTest = 4
        End Try
        Return p_Connect
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
        Dim g_PathXML As String
        Dim p_DataSet As New DataSet
        Dim g_Config_XMLDatatable As DataTable

        Dim p_PassEn As String = ""

        Try

            g_PathXML = Application.StartupPath & "\Config.xml"
            If Dir(g_PathXML) <> "" Then
                p_DataSet.ReadXml(g_PathXML)
                If Not p_DataSet Is Nothing Then
                    If p_DataSet.Tables.Count > 0 Then
                        g_Config_XMLDatatable = p_DataSet.Tables(0)
                        Try

                            'g_Wcf_Connect
                            If g_Config_XMLDatatable.Rows(0).Item("WCF").ToString.Trim = "TRUE" Then

                            End If

                            g_DB_Name = g_Config_XMLDatatable.Rows(0).Item(g_KEY_DB_NAME).ToString.Trim    'xml.GetAttribute(g_KEY_DB_NAME)
                            g_Server = g_Config_XMLDatatable.Rows(0).Item(g_KEY_SERVER).ToString.Trim  'xml.GetAttribute(g_KEY_SERVER)
                            g_UserName = g_Config_XMLDatatable.Rows(0).Item(g_KEY_USER).ToString.Trim  '   xml.GetAttribute(g_KEY_USER)
                            'g_UserName = "fes_AnhQH"
                            g_Password = g_Config_XMLDatatable.Rows(0).Item(g_KEY_PASS).ToString.Trim  '  xml.GetAttribute(g_KEY_PASS)
                            'g_Password = "AnhQH@FES12345"
                            g_DBPortInstance = g_Config_XMLDatatable.Rows(0).Item(g_KEY_PORT).ToString.Trim  '   xml.GetAttribute(g_KEY_PORT)

                            g_DBTYPE = g_Config_XMLDatatable.Rows(0).Item(g_DBTYPE_Key).ToString.Trim   'Xml.GetAttribute(g_DBTYPE_Key)
                        Catch ex As Exception

                        End Try
                        ' g_Config_XMLDatatable.WriteXml(p_PathXML)

                    End If

                End If
                '

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
    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataTable
    Public Function mod_SYS_GET_DATATABLE1(ByVal p_SQL As String) As System.Data.DataTable
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
    '26/06/2014
    'Ham 1 cau lenh SQL
    'Tra ve bien DataTable
    Public Function p_SYS_GET_DATATABLE_Des(ByVal p_SQL As String, ByRef p_DesErr As String) As DataTable
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

    Public Function p_SYS_GET_DATASET_Des(ByVal p_SQL As String, _
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
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL trong DataSet

    Public Function SysExecuteDataSet1(ByVal p_DataSet1 As DataSet, ByRef p_Desc As String) As Boolean

        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter

        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction

        SysExecuteDataSet1 = True

        Oleconnection = Sys_SQL_Connection()
        If Oleconnection.State <> ConnectionState.Open Then
            SysExecuteDataSet1 = False
            Exit Function
        End If
        p_Oletransaction = Oleconnection.BeginTransaction
        Olecommand = New OleDbCommand
        Try

            With Olecommand
                .Connection = Oleconnection
                .Transaction = p_Oletransaction
                .CommandType = CommandType.Text
                For p_Count = 0 To p_DataSet1.Tables(0).Rows.Count - 1
                    If p_DataSet1.Tables(0).Rows(p_Count).Item(0).ToString <> "" Then
                        .CommandText = p_DataSet1.Tables(0).Rows(p_Count).Item(0).ToString
                        .ExecuteNonQuery()
                    End If
                Next
            End With
            p_Oletransaction.Commit()
            Olecommand.Dispose()
            Oleconnection.Dispose()
            Oleconnection.Close()

        Catch ex As Exception
            SysExecuteDataSet1 = False
            p_Desc = ex.Message
            '  p_Oletransaction.Rollback()
            ' p_Oletransaction.Dispose()
            Olecommand.Dispose()
            Oleconnection.Dispose()
            Oleconnection.Close()
        End Try

    End Function



    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL trong DataSet

    Public Function SysExecuteDataSetTransaction1(ByVal p_DataTable As DataSet, ByRef p_Desc As String) As Boolean

        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter

        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction

        SysExecuteDataSetTransaction1 = True

        Oleconnection = Sys_SQL_Connection()
        If Oleconnection.State <> ConnectionState.Open Then
            SysExecuteDataSetTransaction1 = False
            Exit Function
        End If
        p_Oletransaction = Oleconnection.BeginTransaction
        Olecommand = New OleDbCommand
        Try

            With Olecommand
                .Connection = Oleconnection
                .Transaction = p_Oletransaction
                .CommandType = CommandType.Text
                For p_Count = 0 To p_DataTable.Tables(0).Rows.Count - 1
                    If p_DataTable.Tables(0).Rows(p_Count).Item(0).ToString <> "" Then
                        .CommandText = p_DataTable.Tables(0).Rows(p_Count).Item(0).ToString
                        .ExecuteNonQuery()
                    End If
                Next
            End With
            p_Oletransaction.Commit()
            Olecommand.Dispose()
            Oleconnection.Dispose()
            Oleconnection.Close()

        Catch ex As Exception
            SysExecuteDataSetTransaction1 = False
            p_Desc = ex.Message
            p_Oletransaction.Rollback()
            p_Oletransaction.Dispose()
            Olecommand.Dispose()
            Oleconnection.Dispose()
            Oleconnection.Close()
        End Try

    End Function

    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL 

    Public Function Sys_Execute_DataTable1(ByVal p_DataTable As DataTable, _
                                          ByRef p_Desc As String) As Boolean

        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter


        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction


        Sys_Execute_DataTable1 = True
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
            Olecommand.Dispose()
            Oleconnection.Close()
            Oleconnection.Dispose()
            Oleconnection = Nothing
        Catch
            p_Oletransaction.Rollback()
            p_Desc = Err.Description
            Sys_Execute_DataTable1 = False
            If Not Oleconnection Is Nothing Then
                Olecommand.Dispose()
                Oleconnection.Close()
                Oleconnection.Dispose()
                Oleconnection = Nothing
            End If
        End Try

    End Function


    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL 

    Public Function Sys_Execute_DataTbl1(ByVal p_DataTable1 As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean

        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter


        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction


        Sys_Execute_DataTbl1 = True
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
            Sys_Execute_DataTbl1 = False
            Olecommand.Dispose()
            Oleconnection.Close()
            Oleconnection.Dispose()
            Oleconnection = Nothing
        End Try

    End Function

    Public Function Execute_DataTbl_With_Connection1(ByVal p_Connection As String, ByVal p_DataTable1 As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean
        Execute_DataTbl_With_Connection1 = Sys_Execute_DataTbl_With_Connection(p_Connection, p_DataTable1, p_Desc)
    End Function

    Private Function Sys_Execute_DataTbl_With_Connection(ByVal p_Connection As String, ByVal p_DataTable1 As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean 'Implements IService.Sys_Execute_DataTbl_With_Connection

        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter


        Dim p_Oleconnection As New OleDbConnection(p_Connection)
        Dim p_Olecommand As New OleDbCommand
        Dim p_Oletransaction As OleDbTransaction


        Sys_Execute_DataTbl_With_Connection = True
        Try
            'p_Oleconnection.ConnectionString = p_Connection
            p_Oleconnection.Open()
            'Oleconnection = Sys_SQL_Connection()
            p_Oletransaction = p_Oleconnection.BeginTransaction
            p_Olecommand = New OleDbCommand
            With p_Olecommand
                .Connection = p_Oleconnection
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
            p_Oleconnection.Close()
            p_Oletransaction = Nothing
        Catch ex As Exception
            p_Oletransaction.Rollback()
            p_Oletransaction = Nothing
            p_Desc = Err.Number & "-Line " & p_Count + 1 & ":" & ex.Message
            Sys_Execute_DataTbl_With_Connection = False

        End Try

    End Function


    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL 

    'Public Function Sys_Execute_DataTbl_Oracle(ByVal p_DataTable1 As System.Data.DataTable, _
    '                                      ByRef p_Desc As String) As Boolean Implements IService.Sys_Execute_DataTbl_Oracle

    '    Dim p_Count As Integer
    '    Dim p_int As Integer = 0
    '    'Dim adapter As OracleDataAdapter


    '    Dim g_Oracle_Connection As OracleConnection
    '    Dim Command As OracleCommand
    '    Dim p_Oletransaction As OracleTransaction


    '    Sys_Execute_DataTbl_Oracle = True
    '    Try
    '        g_Oracle_Connection = New OracleConnection(SysGetConnect_Oracle)
    '        g_Oracle_Connection.Open()
    '        p_Oletransaction = g_Oracle_Connection.BeginTransaction
    '        Command = New OracleCommand
    '        With Command
    '            .Connection = g_Oracle_Connection
    '            .Transaction = p_Oletransaction
    '            .CommandType = CommandType.Text
    '            For p_Count = 0 To p_DataTable1.Rows.Count - 1
    '                If p_DataTable1.Rows(p_Count).Item(0).ToString <> "" Then
    '                    .CommandText = p_DataTable1.Rows(p_Count).Item(0).ToString
    '                    .ExecuteNonQuery()
    '                End If
    '            Next
    '        End With
    '        p_Oletransaction.Commit()
    '        p_Oletransaction.Dispose()
    '        Command.Dispose()
    '        g_Oracle_Connection.Close()
    '        p_Oletransaction = Nothing
    '    Catch ex As Exception
    '        p_Oletransaction.Rollback()
    '        p_Oletransaction.Dispose()
    '        Command.Dispose()
    '        g_Oracle_Connection = Nothing
    '        g_Oracle_Connection.Close()
    '        p_Desc = Err.Number & "-Line " & p_Count + 1 & ":" & ex.Message
    '        Sys_Execute_DataTbl_Oracle = False

    '    End Try

    'End Function

    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL 

    Public Function SysExecuteSqlArray1(ByVal p_SQLArray() As String, ByRef p_Desc As String) As Boolean

        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter


        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction


        SysExecuteSqlArray1 = True
        Try
            Oleconnection = Sys_SQL_Connection()
            p_Oletransaction = Oleconnection.BeginTransaction
            Olecommand = New OleDbCommand
            With Olecommand
                .Connection = Oleconnection
                .Transaction = p_Oletransaction
                .CommandType = CommandType.Text
                For p_Count = 0 To p_SQLArray.Length - 1
                    If p_SQLArray(p_Count).ToString <> "" Then
                        .CommandText = p_SQLArray(p_Count).ToString
                        .ExecuteNonQuery()
                    End If
                Next
            End With
            p_Oletransaction.Commit()
            Oleconnection.Close()

        Catch
            p_Desc = Err.Description
            SysExecuteSqlArray1 = False

        End Try

    End Function


    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL 

    Public Function Sys_Execute_DataTableNew1(ByVal p_DataTable As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean

        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter


        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction


        Sys_Execute_DataTableNew1 = True
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
            Sys_Execute_DataTableNew1 = False
            If Not Oleconnection Is Nothing Then
                Olecommand.Dispose()
                Oleconnection.Close()
                Oleconnection.Dispose()
                Oleconnection = Nothing
            End If
        End Try

    End Function

    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL theo Company

    Public Function Sys_Execute_Com1(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_SQL As String, _
                                              ByRef p_Desc As String) As Boolean

        'Dim p_Count As Integer
        'Dim p_int As Integer



        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        'Dim p_Oletransaction As OleDbTransaction


        Sys_Execute_Com1 = True
        Try

            Oleconnection = Sys_SQL_Connection_Com(p_CompanyHost, p_CompanyDB, _
                                           p_UsrB1, p_PassB1, p_Port)
            ' p_Oletransaction = Oleconnection.BeginTransaction
            Olecommand = New OleDbCommand
            With Olecommand
                .Connection = Oleconnection
                '   .Transaction = p_Oletransaction
                .CommandTimeout = 15
                .CommandType = CommandType.Text
                If p_SQL <> "" Then
                    .CommandText = p_SQL
                    .ExecuteNonQuery()
                End If

            End With
            'p_Oletransaction.Commit()
            Oleconnection.Close()
            Oleconnection = Nothing
        Catch ex As Exception
            p_Desc = ex.Message
            Sys_Execute_Com1 = False
            If Not Oleconnection Is Nothing Then
                Oleconnection.Close()
                Oleconnection = Nothing
            End If
        End Try

    End Function

    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL trong DataTable

    Public Function Sys_Execute1(ByVal p_SQL As String, _
                                          ByRef p_Desc As String) As Boolean

        ' Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter


        Dim Oleconnection As New OleDbConnection
        Dim Olecommand As OleDbCommand
        'Dim p_Oletransaction As OleDbTransaction

        Oleconnection = Sys_SQL_Connection()
        Sys_Execute1 = True
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
            Sys_Execute1 = False
            Olecommand.Dispose()
            ' Oleconnection.Dispose()
            Oleconnection.Close()
        End Try

    End Function


    Public Function SysGetBidingSource1(ByVal p_Module As String) As DataSet
        Dim p_SQL As String
        p_SQL = "SELECT [FORM_NAME], [VIEW_NAME],[TABLE_NAME], BIDINGNAVIGATOR FROM [BIDINGSOURCE] WHERE MODULE='" & p_Module & "' ORDER BY ID"
        SysGetBidingSource1 = mod_SYS_GET_DATASET1(p_SQL)
    End Function

    Public Function SysGetTrueGridSource1(ByVal p_Module As String) As DataSet
        Dim p_SQL As String
        p_SQL = "SELECT ID,MODULE,upper(FORM_NAME) as FORM_NAME,upper(GRID_NAME) as GRID_NAME,COL_NAME,ORDER_BY,ENABLE_FLAG,VISIBLE_FLAG" & _
                ",WIDTH,CAPTION,DATA_TYPE, Decimals, Digit,CheckBox, Required " & _
                " ,CFL,CFLSQL,CFLReturn1,CFLReturn2,CFLReturn3,CFLReturn4" & _
                ",ComboBox,ComboBoxSQL, CFLKeyField, DropDownRow, ShowLoadCFL, ColumnSum, AllowUpdate, ComboShowHeader ,DefaultButtonClick " & _
                "FROM GRID_PROPERTY WHERE MODULE='" & p_Module & "' ORDER BY MODULE, FORM_NAME, ORDER_BY"
        SysGetTrueGridSource1 = mod_SYS_GET_DATASET1(p_SQL)
    End Function

    Public Function SysGetTrueGridSourceForm1(ByVal p_Module As String, ByVal p_FormName As String) As DataSet
        Dim p_SQL As String
        p_SQL = "SELECT ID,MODULE,upper(FORM_NAME) as FORM_NAME,upper(GRID_NAME) as GRID_NAME,COL_NAME,ORDER_BY,ENABLE_FLAG,VISIBLE_FLAG" & _
                ",WIDTH,CAPTION,DATA_TYPE, Decimals, Digit,CheckBox, Required " & _
                " ,CFL,CFLSQL,CFLReturn1,CFLReturn2,CFLReturn3,CFLReturn4" & _
                ",ComboBox,ComboBoxSQL, CFLKeyField, DropDownRow, ShowLoadCFL , ColumnSum, AllowUpdate, ComboShowHeader, DefaultButtonClick " & _
                "FROM GRID_PROPERTY WHERE MODULE='" & p_Module & "' and upper(FORM_NAME) ='" & UCase(p_FormName) & "' ORDER BY MODULE, FORM_NAME, ORDER_BY"
        SysGetTrueGridSourceForm1 = mod_SYS_GET_DATASET1(p_SQL)
    End Function



    'ANHQH
    '29/11/2011
    'Ham thuc hien lay danh sach menu va Submenu
    Public Function Sys_Get_Menu_Submenu1(ByVal p_User As Double, ByRef p_MenuSet As DataSet, ByRef p_SubmenuSet As DataSet, _
                                         ByRef p_ErrDes As String, ByVal p_DBTYPE As String) As Boolean
        Dim p_SQLMnu As String
        Dim p_DataTemp As New DataSet
        Dim p_dataTable As New DataTable
        Dim p_Row As DataRow
        Dim p_Col1 As DataColumn

        Dim p_SQLSubMnu As String
        Dim p_Index As Integer
        Dim p_Index_Submenu As Integer
        Sys_Get_Menu_Submenu1 = True


        Try
            'If p_User = 0 Then
            'p_SQLMnu = "SELECT UNIQUE A3.MENU_ID, A3.MENU_NAME, A3.DESCRIPTION " & _
            '        "FROM SYS_USER A1, SYS_RESPONSIBILITY_MENU A2, SYS_MENU A3 " & _
            '        " WHERE(A1.USER_ID = A2.USER_ID) AND A2.MENU_ID = A3.MENU_ID AND A1.USER_ID =" & p_User & _
            '            "AND SYSDATE BETWEEN NVL(A2.FROM_DATE, SYSDATE) AND NVL(A2.TO_DATE, SYSDATE) " & _
            '                "ORDER BY A3.MENU_ID "
            'ModSys_GetParameterOracle(g_DBTYPE)
            g_DBTYPE = p_DBTYPE
            'p_ErrDes = g_DBTYPE
            'Exit Function
            If g_DBTYPE = "ORACLE" Then
                'p_SQLMnu = "select A.menu_id, B.menu_name,B.description, B.Menu_Code " & _
                '        "from sys_user_responds A,sys_menu B " & _
                '        "where(a.menu_id = b.menu_id And USER_ID IN (select USER_ID from  SYS_USER where USER_ID= " & p_User & ")) " & _
                '        " AND CONVERT (date, GETDATE ()) BETWEEN ISNULL(A.FROM_DATE,CONVERT (date, GETDATE ())) AND ISNULL(A.TO_DATE,CONVERT (date, GETDATE ()))" & _
                '        "order by  OrderBy"
                p_SQLMnu = "select A.menu_id, B.menu_name,B.description, B.Menu_Code from " & _
                            "sys_user_responds A,sys_menu B where(a.menu_id = b.menu_id And USER_ID " & _
                             "IN (select USER_ID from  SYS_USER where USER_ID= " & p_User & "))  " & _
                             "AND to_date ( sysdate) BETWEEN nvl(A.FROM_DATE,to_date ( sysdate)) " & _
                             "AND nvl(A.TO_DATE,to_date ( sysdate)) order by  a.Order_Num"      'OrderBy"

                'p_MenuSet = mod_SYS_GET_DATASET_Oracle(p_SQLMnu, p_ErrDes)
                p_ErrDes = p_SQLMnu
            ElseIf g_DBTYPE = "SQL" Then
                p_SQLMnu = "select A.menu_id, B.menu_name,B.description, B.Menu_Code, b.Icon_File " & _
                        "from sys_user_responds A,sys_menu B " & _
                        "where(a.menu_id = b.menu_id And USER_ID IN (select USER_ID from  SYS_USER where USER_ID= " & p_User & ")) " & _
                        " AND CONVERT (date, GETDATE ()) BETWEEN ISNULL(A.FROM_DATE,CONVERT (date, GETDATE ())) AND ISNULL(A.TO_DATE,CONVERT (date, GETDATE ()))" & _
                        "order by  a.Order_Num"    'OrderBy"

                p_MenuSet = mod_SYS_GET_DATASET1(p_SQLMnu)
            End If

            For p_Index = 0 To p_MenuSet.Tables(0).Rows.Count - 1
                If g_DBTYPE = "ORACLE" Then
                    p_SQLSubMnu = "SELECT A2.FUNCTION_ID,A2.FUNCTION_NAME,A2.DESCRIPTION,A3.FORM_NAME,A3.PROJECT_CODE FROM SYS_FUNCTION A2, " & _
                            "SYS_FORMS A3,  SYS_RESPONSIBILITY_MENU A4   WHERE(A2.FORM_ID = A3.FORM_ID) AND A4.MENU_CODE =" & _
                            "'" & p_MenuSet.Tables(0).Rows(p_Index).Item(3).ToString & "'  AND to_date (sysdate) " & _
                                "BETWEEN nvl(A2.FROM_DATE, to_date(sysdate)) And nvl(A2.TO_DATE, to_date(sysdate)) " & _
                                "AND a2.function_id=a4.function_id ORDER BY A4.ORDER_NUM"
                    ' p_DataTemp = mod_SYS_GET_DATASET_Oracle(p_SQLSubMnu, p_ErrDes)
                    p_ErrDes = p_SQLSubMnu
                ElseIf g_DBTYPE = "SQL" Then
                    p_SQLSubMnu = "SELECT A2.FUNCTION_ID,A2.FUNCTION_NAME,A2.DESCRIPTION,A3.FORM_NAME,A3.PROJECT_CODE " & _
                       "FROM SYS_FUNCTION A2, SYS_FORMS A3,  SYS_RESPONSIBILITY_MENU A4  " & _
                       " WHERE(A2.FORM_ID = A3.FORM_ID) AND A4.MENU_CODE ='" & p_MenuSet.Tables(0).Rows(p_Index).Item(3).ToString & "' " & _
                       " AND CONVERT (date, GETDATE ()) BETWEEN ISNULL(A2.FROM_DATE,CONVERT (date, GETDATE ())) AND ISNULL(A2.TO_DATE,CONVERT (date, GETDATE ())) " & _
                       " AND a2.function_id=a4.function_id ORDER BY A4.ORDER_NUM"
                    p_DataTemp = mod_SYS_GET_DATASET1(p_SQLSubMnu)
                End If



                If p_DataTemp.Tables(0).Rows.Count > 0 Then
                    p_dataTable = New DataTable
                    p_Col1 = New DataColumn
                    p_Col1.DataType = GetType(Double)
                    p_dataTable.Columns.Add(p_Col1)
                    p_Col1 = New DataColumn
                    p_Col1.DataType = GetType(String)
                    p_dataTable.Columns.Add(p_Col1)
                    p_Col1 = New DataColumn
                    p_Col1.DataType = GetType(String)
                    p_dataTable.Columns.Add(p_Col1)
                    p_Col1 = New DataColumn
                    p_Col1.DataType = GetType(String)
                    p_dataTable.Columns.Add(p_Col1)
                    p_Col1 = New DataColumn
                    p_Col1.DataType = GetType(String)
                    p_dataTable.Columns.Add(p_Col1)
                    p_SubmenuSet.Tables.Add(p_dataTable)
                    For p_Index_Submenu = 0 To p_DataTemp.Tables(0).Rows.Count - 1
                        p_Row = p_SubmenuSet.Tables(p_Index).NewRow
                        p_Row(0) = CType(p_DataTemp.Tables(0).Rows(p_Index_Submenu).Item(0), Double)
                        p_Row(1) = CType(p_DataTemp.Tables(0).Rows(p_Index_Submenu).Item(1), String)
                        p_Row(2) = CType(p_DataTemp.Tables(0).Rows(p_Index_Submenu).Item(2), String)
                        p_Row(3) = CType(p_DataTemp.Tables(0).Rows(p_Index_Submenu).Item(3), String)
                        p_Row(4) = CType(p_DataTemp.Tables(0).Rows(p_Index_Submenu).Item(4), String)
                        p_SubmenuSet.Tables(p_Index).Rows.Add(p_Row)
                    Next p_Index_Submenu
                Else
                    p_SubmenuSet.Tables.Add(New DataTable)
                End If
            Next p_Index
            'End If
        Catch ex As Exception
            ' p_ErrDes = ex.Message
            Sys_Get_Menu_Submenu1 = False
        End Try
    End Function





    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataSet

    Public Function mod_SYS_GET_DATASET1(ByVal p_SQL As String) As System.Data.DataSet
        'Dim dr As OleDbDataReader

        Dim Olecon As New OleDbConnection
        Dim OlemyCommand As OleDbCommand
        Dim p_OleAdapter As OleDbDataAdapter
        'Dim connectionString As String
        'Dim sSQL As String
        Dim p_Status As Boolean
        Dim p_DataTable As New System.Data.DataSet
        Dim p_Recorset As New Object
        Dim p_Int As Integer


        p_Status = True

        Try
            Olecon = Sys_SQL_Connection()
            If Olecon.State.ToString() = "Open" Then
                OlemyCommand = New OleDbCommand(p_SQL, Olecon)
                OlemyCommand.CommandTimeout = 300
                p_OleAdapter = New OleDbDataAdapter(OlemyCommand)

                p_Int = p_OleAdapter.Fill(p_DataTable)
            Else
                p_Status = False
            End If
            Olecon.Close()
            Return p_DataTable
        Catch
            p_Status = False
            Return Nothing
        End Try
        'mod_SYS_GET_DATASET1 = p_DataTable
    End Function

    'ANHQH
    '21/11/2011
    'Ham Tra ve chuoi ket noi voi CSDL
    Private Function SysGetConnect_Company(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String) As String
        Dim p_ConStr As String
        SysGetStrConnect()
        p_ConStr = ""

        'If g_Company_DB_Name <> "" Then
        'p_ConStr = "Provider=SQLOLEDB.1;Data Source=" & g_Company_Host & ";Persist Security Info=True;User ID=" & p_UsrB1 & ";Password=" & p_PassB1 & ";Initial Catalog=" & g_Company_DB_Name
        If p_Port.ToString.Trim = "" Then
            p_ConStr = "Provider=SQLOLEDB;Data Source=" & p_CompanyHost & ";Persist Security Info=True;User ID=" & _
                p_UsrB1 & ";Password=" & p_PassB1 & ";Initial Catalog=" & p_CompanyDB & ";Connect Timeout=300"
        Else
            p_ConStr = "Provider=SQLOLEDB;Server=" & p_CompanyHost & "," & p_Port & ";" & _
                    "Database=" & p_CompanyDB & ";User ID=" & p_UsrB1 & ";Password=" & p_PassB1 & ";" & _
                    "Trusted_Connection=False;Connect Timeout=300"
        End If
        'End If
        SysGetConnect_Company = p_ConStr
    End Function

    Private Function Sys_SQL_Connection_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String) As OleDbConnection
        Dim con As New OleDbConnection()
        Dim connectionString As String

        connectionString = SysGetConnect_Company(p_CompanyHost, p_CompanyDB, _
                                       p_UsrB1, p_PassB1, p_Port)
        Try
            con = New OleDbConnection(connectionString)
            con.Open()
            Return con
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL trong DataSet

    Public Function SysExecuteDataSet_Company(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_DataSet As DataSet) As Boolean
        Dim p_Count As Integer
        'Dim p_int As Integer
        'Dim adapter As OracleDataAdapter


        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction


        SysExecuteDataSet_Company = True
        Oleconnection = Sys_SQL_Connection_Com(p_CompanyHost, p_CompanyDB, _
                                       p_UsrB1, p_PassB1, p_Port)
        If Oleconnection.State <> ConnectionState.Open Then
            SysExecuteDataSet_Company = False
            Exit Function
        End If
        p_Oletransaction = Oleconnection.BeginTransaction
        Olecommand = New OleDbCommand
        Try
            With Olecommand
                .Connection = Oleconnection
                .Transaction = p_Oletransaction
                .CommandType = CommandType.Text
                For p_Count = 0 To p_DataSet.Tables(0).Rows.Count - 1
                    If p_DataSet.Tables(0).Rows(p_Count).Item(0).ToString <> "" Then
                        .CommandText = p_DataSet.Tables(0).Rows(p_Count).Item(0).ToString
                        .ExecuteNonQuery()
                    End If
                Next
            End With
            p_Oletransaction.Commit()
            Olecommand.Dispose()
            Oleconnection.Dispose()
            Oleconnection.Close()
        Catch
            SysExecuteDataSet_Company = False
            p_Oletransaction.Rollback()
            p_Oletransaction.Dispose()
            Olecommand.Dispose()
            Oleconnection.Dispose()
            Oleconnection.Close()
        End Try


    End Function

    'Public Function SysGetDataTableCom(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
    '                                      ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
    '                                      ByVal p_SQL As String) As System.Data.DataTable Implements IService.mod_SYS_GET_DATATABLE_Com
    '    ' p_User_Database = p_Class_User_Database
    '    SysGetDataTableCom = mod_SYS_GET_DATATABLE_Com(p_CompanyHost, p_CompanyDB, _
    '                                       p_UsrB1, p_PassB1, p_Port, _
    '                                      p_SQL)
    '    'SysGetDataTable = True
    'End Function

    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL trong DataTable

    Public Function Sys_Execute_DataTable_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_DataTable As DataTable, _
                                              ByRef p_Desc As String) As Boolean

        Dim p_Count As Integer
        'Dim p_int As Integer



        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction


        Sys_Execute_DataTable_Com = True
        Try

            Oleconnection = Sys_SQL_Connection_Com(p_CompanyHost, p_CompanyDB, _
                                           p_UsrB1, p_PassB1, p_Port)
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
            Oleconnection.Close()

        Catch
            p_Oletransaction.Rollback()
            p_Desc = Err.Description
            Sys_Execute_DataTable_Com = False

        End Try

    End Function
    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataTable
    Public Function mod_SYS_GET_DATATABLE_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_SQL As String) As System.Data.DataTable

        Dim sSQL As String
        Dim p_Status As Boolean
        Dim p_DataTable As New DataTable

        Dim p_DataSet As New DataSet
        Dim p_Recorset As New Object
        Dim p_Int As Integer

        Dim Olecon As New OleDbConnection
        Dim OlemyCommand As OleDbCommand
        Dim p_OleAdapter As OleDbDataAdapter
        p_Status = True

        sSQL = p_SQL

        Try

            Olecon = Sys_SQL_Connection_Com(p_CompanyHost, p_CompanyDB, _
                                           p_UsrB1, p_PassB1, p_Port)
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
            Return p_DataSet.Tables(0)



        Catch
            p_Status = False
            Return Nothing
        End Try

    End Function

    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataSet

    Public Function mod_SYS_GET_DATASET_Com1(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_SQL As String) As System.Data.DataSet

        Dim Olecon As New OleDbConnection
        Dim OlemyCommand As OleDbCommand
        Dim p_OleAdapter As OleDbDataAdapter
        'Dim connectionString As String
        'Dim sSQL As String
        Dim p_Status As Boolean
        Dim p_DataTable As New System.Data.DataSet
        Dim p_Recorset As New Object
        Dim p_Int As Integer


        p_Status = True

        Try
            'con.Open()

            Olecon = Sys_SQL_Connection_Com(p_CompanyHost, p_CompanyDB, _
                                           p_UsrB1, p_PassB1, p_Port)
            If Olecon.State.ToString() = "Open" Then
                OlemyCommand = New OleDbCommand(p_SQL, Olecon)
                OlemyCommand.CommandTimeout = 300
                p_OleAdapter = New OleDbDataAdapter(OlemyCommand)
                p_Int = p_OleAdapter.Fill(p_DataTable)
            Else
                p_Status = False
            End If
            Olecon.Close()
            Return p_DataTable
        Catch
            p_Status = False
            Return Nothing
        End Try

        Olecon = Nothing
        ' mod_SYS_GET_DATASET_Com1 = p_DataTable
    End Function


    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataSet  theo so page truyen vao
    'p_Page_Total: Tong so trang
    'p_RowNum: So line/page
    'p_PageNum: page hien thoi can lay du lieu
    Public Function mod_SYS_GET_DATASET_PAGE1(ByVal p_SQLTotalPage As String, _
                                          ByVal p_Table As String, ByVal p_FieldKey As String, _
                                          ByRef p_Page_Total As Integer, _
                                          Optional ByVal p_Where As String = "", _
                                             Optional ByVal p_RowNum As Integer = 0, _
                                             Optional ByVal p_PageNum As Integer = 1) As System.Data.DataSet


        Dim sSQL As String
        Dim p_Status As Boolean
        Dim p_DataSet As New System.Data.DataSet

        Dim p_DataSet_Page As New System.Data.DataSet
        Dim p_DataTable_Page As DataTable
        'Dim p_Recorset As New Object
        'Dim p_Int As Integer
        Dim p_LineOfPage As Integer
        Try

            p_Status = True
            p_Page_Total = 1
            If p_RowNum = 0 Then
                p_LineOfPage = 20
            Else
                p_LineOfPage = p_RowNum
            End If
            'Lay du lieu
            If p_Table <> "" And p_FieldKey <> "" Then
                sSQL = "SELECT * FROM (" & _
                                        " SELECT *, ROW_NUMBER() OVER (ORDER BY " & p_FieldKey & ") AS RowNum" & _
                                        " FROM " & p_Table & " with (nolock) " & p_Where & " " & _
                                    " ) AS MyDerivedTable " & _
                                    " WHERE MyDerivedTable.RowNum BETWEEN (" & p_PageNum & " -1)* " & p_LineOfPage & " +1  " & _
                                    " AND " & (p_PageNum * p_LineOfPage)
            Else
                sSQL = p_SQLTotalPage & "  " & p_Where & " "
            End If

            p_DataSet = mod_SYS_GET_DATASET1(sSQL)
            'Lay thong tin tong so page cua du lieu
            sSQL = "select   round(count(*)/" & p_LineOfPage & ",0) from ( " & p_SQLTotalPage & " ) A"
            p_DataTable_Page = mod_SYS_GET_DATATABLE1(sSQL)
            p_DataSet_Page = mod_SYS_GET_DATASET1(sSQL)
            If p_DataSet_Page.Tables(0).Rows.Count >= 0 Then
                p_Page_Total = p_DataSet_Page.Tables(0).Rows(0).Item(0).ToString
            End If
            Return p_DataSet
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataSet  theo so page truyen vao
    'p_Page_Total: Tong so trang
    'p_RowNum: So line/page
    'p_PageNum: page hien thoi can lay du lieu theo Company
    Public Function mod_SYS_GET_DATATABLE_PAGE_Com1(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_SQLTotalPage As String, _
                                          ByVal p_Table As String, ByVal p_FieldKey As String, _
                                          ByRef p_Page_Total As Integer, _
                                          Optional ByVal p_Where As String = "", _
                                             Optional ByVal p_RowNum As Integer = 0, _
                                             Optional ByVal p_PageNum As Integer = 1) As System.Data.DataTable
        'Dim dr As OleDbDataReader
        'Dim con As New OracleConnection ' OleDbConnection()
        ' Dim myCommand As OracleCommand ' OleDbCommand
        'Dim p_Adapter As OracleDataAdapter  'OleDbDataAdapter

        Dim sSQL As String
        Dim p_Status As Boolean
        Dim p_DataTable As New System.Data.DataTable

        Dim p_DataTable_Page As New System.Data.DataTable

        'Dim p_Recorset As New Object
        'Dim p_Int As Integer
        Dim p_LineOfPage As Integer
        Try

            p_Status = True
            p_Page_Total = 1
            If p_RowNum = 0 Then
                p_LineOfPage = 20
            Else
                p_LineOfPage = p_RowNum
            End If
            'Lay du lieu
            'sSQL = " SELECT * FROM (     SELECT *, ROW_NUMBER() OVER (ORDER BY CardCode) AS RowNum  FROM OCRD " & _
            '        ") AS MyDerivedTable WHERE MyDerivedTable.RowNum BETWEEN 21 AND 40   "

            If p_Table <> "" And p_FieldKey <> "" Then
                sSQL = "SELECT * FROM (" & _
                                        " SELECT *, ROW_NUMBER() OVER (ORDER BY " & p_FieldKey & ") AS RowNum" & _
                                        " FROM " & p_Table & " with (nolock) " & p_Where & " " & _
                                    " ) AS MyDerivedTable " & _
                                    " WHERE MyDerivedTable.RowNum BETWEEN (" & p_PageNum & " -1)* " & p_LineOfPage & " +1  " & _
                                    " AND " & (p_PageNum * p_LineOfPage)
            Else
                sSQL = p_SQLTotalPage
            End If

            p_DataTable = mod_SYS_GET_DATATABLE_Com(p_CompanyHost, p_CompanyDB, _
                                           p_UsrB1, p_PassB1, p_Port, _
                                          sSQL)
            'Lay thong tin tong so page cua du lieu
            'sSQL = "select   round(count(*)/" & p_LineOfPage & ") from " & p_SQLTotalPage & ") A"

            sSQL = "select   round(count(*)/" & p_LineOfPage & ",0) from ( " & p_SQLTotalPage & " ) A"
            p_DataTable_Page = mod_SYS_GET_DATATABLE_Com(p_CompanyHost, p_CompanyDB, _
                                           p_UsrB1, p_PassB1, p_Port, _
                                           sSQL)
            If p_DataTable_Page.Rows.Count >= 0 Then
                p_Page_Total = p_DataTable_Page.Rows(0).Item(0).ToString
            End If
            Return p_DataTable

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#Region "Ham get  Primakey cho bang"
    'anhqh
    '06/11/2013
    Public Function SysGetPrimary1(ByVal p_TableKey As String) As Double
        Dim p_Connect As New OleDb.OleDbConnection
        Dim p_Command As New OleDb.OleDbCommand
        SysGetPrimary1 = 0
        Try
            p_Connect = Sys_SQL_Connection()
            If p_Connect.State = ConnectionState.Open Then
                p_Command.Connection = p_Connect
                p_Command.CommandText = "FPT_GetPrimaryKey"
                p_Command.CommandType = CommandType.StoredProcedure
                p_Command.Parameters.Add("@pTable", OleDbType.VarChar, 50, ParameterDirection.Input).Value = p_TableKey.Trim

                p_Command.Parameters.Add("@ID", OleDbType.Numeric, 25)
                p_Command.Parameters("@ID").Direction = ParameterDirection.Output
                p_Command.ExecuteNonQuery()

                Integer.TryParse(p_Command.Parameters("@ID").Value.ToString.Trim, SysGetPrimary1)
            End If
            p_Command = Nothing
            p_Connect.Close()
            p_Connect = Nothing
        Catch ex As Exception
            SysGetPrimary1 = 0
        End Try
    End Function
#End Region

#Region "Check login B1"
    '08/11/2013
    'Public Function SysCheckLoginB1(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
    '                                      ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
    '                                      ByVal B1_User As String, ByVal B1Pass As String) As String
    '    Dim p_APICom As New SAPbobsCOM.Company
    '    Dim p_Number As Integer
    '    Dim lErrCode As Integer
    '    Dim sErrMsg As String


    '    Try
    '        SysCheckLoginB1 = ""
    '        p_APICom.Server = p_APIServer.Trim
    '        p_APICom.LicenseServer = p_LicenseServer
    '        p_APICom.language = SAPbobsCOM.BoSuppLangs.ln_English 'p_APILangue    'SAPbobsCOM.BoSuppLangs.ln_English ' change to your language
    '        p_APICom.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2008 'p_APISrvType ' SAPbobsCOM.BoDataServerTypes.dst_MSSQL2008
    '        p_APICom.UseTrusted = False
    '        p_APICom.DbUserName = p_DbUserName.Trim    ' p_DbUserName 'p_APIUser '' "sa"
    '        p_APICom.DbPassword = p_DbPassword.Trim    ' p_DbPassword ' "123456"

    '        p_APICom.CompanyDB = p_APIDatabase.Trim  ' "ASC_TEST"
    '        p_APICom.UserName = p_APIUser.Trim     ' p_APIUser
    '        p_APICom.Password = p_APIPass.Trim  ' p_APIPass

    '        'p_APICom.



    '        lRetCode = p_APICom.Connect()
    '        If lRetCode <> 0 Then ' if the connection failed

    '            p_APICom.GetLastError(lErrCode, sErrMsg)
    '            SaveLog("==========Error: (" & Date.Now.ToString & ") Lỗi khi connect API cho Company " & p_APIDatabase, sErrMsg, p_APIDatabase)
    '            p_APICom = Nothing
    '        Else
    '            ' SaveLog("==========Connected: " & p_APIDatabase, p_Path_Info)
    '            p_CompanyArray(p_Count) = p_APICom


    '            p_ConnectCompany(p_Count) = p_ConnectCom(p_APIServer, p_APIDatabase, p_DbUserName, p_DbPassword, p_DbPort)
    '            If mod_SYS_EXCUTE_SQL("UPDATE FPTUSER SET DateStart=getdate(),APIConnected='Y' where APIDatabase='" & p_APIDatabase & "'") = False Then

    '            End If

    '        End If

    '    Catch ex As Exception
    '        SysCheckLoginB1 = ""
    '    End Try

    'End Function
#End Region

#Region "ORACLE"
    '==============================================================================================
    '================================ORACLE==========================================
    '==============================================================================================
    'ANHQH
    '21/11/2011
    'Ham Tra ve chuoi ket noi voi CSDL
    Private Function SysGetConnect_Oracle() As String
        ' Dim p_ConStr As String
        SysGetStrConnect()
        SysGetConnect_Oracle = ""
        'If g_ORAHOST <> "" Then
        SysGetConnect_Oracle = "" & _
                        "Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" & _
                        "(HOST=" & g_ORAHOST & ")(PORT=" & g_ORAPORT & ")))(CONNECT_DATA=(SID=" & g_SERVERNAME & ")(SERVER=DEDICATED)));" & _
                            "User Id=" & g_ORAUSER & ";Password=" & g_ORAPASS & ";"

        ' End If

        ' SysGetConnect_Oracle = SysGetConnect_Oracle
    End Function


    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL trong DataTable

    'Public Function Sys_Execute_DataTable_Oracle(ByVal p_DataTable As DataTable, _
    '                                      ByRef p_Desc As String) As Boolean Implements IService.Sys_Execute_DataTable_Oracle

    '    Dim p_Count As Integer
    '    Dim p_int As Integer = 0

    '    Dim command As OracleCommand
    '    Dim g_Oracle_Connection As New OracleClient.OracleConnection
    '    Dim p_transaction As OracleTransaction = Nothing
    '    Dim dep_id As OracleParameter = New OracleParameter

    '    Try
    '        Sys_Execute_DataTable_Oracle = True
    '        Try
    '            g_Oracle_Connection = New OracleConnection(SysGetConnect_Oracle)
    '            g_Oracle_Connection.Open()

    '        Catch ex As Exception
    '            Sys_Execute_DataTable_Oracle = False
    '        End Try

    '        p_transaction = g_Oracle_Connection.BeginTransaction
    '        command = New OracleCommand
    '        With command
    '            .Connection = g_Oracle_Connection
    '            .Transaction = p_transaction
    '            .CommandType = CommandType.Text
    '            For p_Count = 0 To p_DataTable.Rows.Count - 1
    '                If p_DataTable.Rows(p_Count).Item(0).ToString <> "" Then
    '                    .CommandText = p_DataTable.Rows(p_Count).Item(0).ToString
    '                    .ExecuteNonQuery()
    '                End If
    '            Next
    '            '.CommandText = p_SQL
    '            .ExecuteNonQuery()
    '        End With
    '        p_transaction.Commit()
    '    Catch ex As Exception
    '        Sys_Execute_DataTable_Oracle = False
    '        ' p_Err = ex.Message
    '        p_transaction.Rollback()
    '    End Try

    'End Function



    'Public Function mod_SYS_GET_DATASET_Oracle(ByVal p_SQL As String, ByRef p_DescErr As String) As System.Data.DataSet Implements IService.mod_SYS_GET_DATASET_Oracle
    '    Dim g_Oracle_Connection As New OracleClient.OracleConnection
    '    Dim myCommand As OracleCommand ' OleDbCommand
    '    Dim p_Adapter As OracleDataAdapter ' OleDbDataAdapter

    '    Dim p_DataSet As New System.Data.DataSet
    '    Dim p_Int As Integer
    '    p_DescErr = ""
    '    Try
    '        g_Oracle_Connection = New OracleConnection(SysGetConnect_Oracle)
    '        g_Oracle_Connection.Open()

    '    Catch ex As Exception
    '        p_DescErr = ex.Message
    '        Return Nothing
    '    End Try

    '    Try
    '        myCommand = New OracleCommand(p_SQL, g_Oracle_Connection)
    '        p_Adapter = New OracleDataAdapter(myCommand)
    '        p_Int = p_Adapter.Fill(p_DataSet)
    '    Catch Ex1 As Exception
    '        p_DescErr = Ex1.Message
    '        Return Nothing
    '    End Try
    '    Return p_DataSet
    'End Function

    'Public Function Sys_Execute_SQL_Oracle(ByVal p_SQL As String, ByRef p_Err As String) As Boolean
    '    Dim command As OracleCommand
    '    Dim g_Oracle_Connection As New OracleClient.OracleConnection
    '    Dim p_transaction As OracleTransaction = Nothing
    '    Dim dep_id As OracleParameter = New OracleParameter

    '    Try
    '        Sys_Execute_SQL_Oracle = True
    '        Try
    '            g_Oracle_Connection = New OracleConnection(SysGetConnect_Oracle)
    '            g_Oracle_Connection.Open()

    '        Catch ex As Exception
    '            Sys_Execute_SQL_Oracle = False
    '        End Try

    '        p_transaction = g_Oracle_Connection.BeginTransaction
    '        command = New OracleCommand
    '        With command
    '            .Connection = g_Oracle_Connection
    '            .Transaction = p_transaction
    '            .CommandType = CommandType.Text
    '            .CommandText = p_SQL
    '            .ExecuteNonQuery()
    '        End With
    '        p_transaction.Commit()
    '    Catch ex As Exception
    '        Sys_Execute_SQL_Oracle = False
    '        p_Err = ex.Message
    '        p_transaction.Rollback()
    '    End Try

    'End Function

    Public Sub ModSys_GetParameterOracle(ByRef p_DBTYPE As String)
        SysGetStrConnect()
        p_DBTYPE = g_DBTYPE
    End Sub




    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataTable
    '    Public Function mod_SYS_GET_DATATABLE_oracle(ByVal p_SQL As String) As DataTable Implements IService.SYS_GET_DATATABLE_oracle
    '        Dim g_Oracle_Connection As New OracleConnection
    '        Dim myCommand As OracleCommand
    '        Dim p_Adapter As OracleDataAdapter

    '        Dim p_DataSet As New System.Data.DataSet
    '        Dim p_Int As Integer
    '        Try
    '            g_Oracle_Connection = New OracleConnection(SysGetConnect_Oracle)
    '            g_Oracle_Connection.Open()

    '        Catch ex As Exception
    '            Return Nothing
    '        End Try

    '        Try
    '            myCommand = New OracleCommand(p_SQL, g_Oracle_Connection)
    '            p_Adapter = New OracleDataAdapter(myCommand)
    '            p_Int = p_Adapter.Fill(p_DataSet)
    '            If p_DataSet Is Nothing Then
    '                Return Nothing
    '            End If
    '            If p_DataSet.Tables.Count <= 0 Then
    '                'Return Nothing
    '                mod_SYS_GET_DATATABLE_oracle = Nothing
    '                GoTo linekt
    '            End If
    '        Catch Ex As Exception
    '            'SaveLog("mod_SYS_GET_DATASETOracle(" & Date.Now.ToString & ")", Ex.Message, "")
    '            mod_SYS_GET_DATATABLE_oracle = Nothing
    '            GoTo linekt
    '        End Try
    '        Return p_DataSet.Tables(0)
    'linekt:
    '        If Not myCommand Is Nothing Then
    '            myCommand.Dispose()
    '        End If
    '        If Not g_Oracle_Connection Is Nothing Then
    '            If g_Oracle_Connection.State = ConnectionState.Open Then
    '                g_Oracle_Connection.Close()
    '            End If
    '        End If
    '    End Function


    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataTable
    '    Public Function mod_SYS_GET_DATATABLE_oracleDesc(ByVal p_SQL As String, ByRef p_DEsc As String) As DataTable Implements IService.mod_SYS_GET_DATATABLE_oracleDesc
    '        Dim g_Oracle_Connection As New OracleConnection
    '        Dim myCommand As OracleCommand
    '        Dim p_Adapter As OracleDataAdapter

    '        Dim p_DataSet As New System.Data.DataSet
    '        Dim p_Int As Integer
    '        p_DEsc = ""
    '        Try
    '            g_Oracle_Connection = New OracleConnection(SysGetConnect_Oracle)
    '            g_Oracle_Connection.Open()

    '        Catch ex As Exception
    '            p_DEsc = ex.Message
    '            Return Nothing
    '        End Try

    '        Try
    '            myCommand = New OracleCommand(p_SQL, g_Oracle_Connection)
    '            p_Adapter = New OracleDataAdapter(myCommand)
    '            p_Int = p_Adapter.Fill(p_DataSet)
    '            If p_DataSet Is Nothing Then
    '                Return Nothing
    '            End If
    '            If p_DataSet.Tables.Count <= 0 Then
    '                'Return Nothing
    '                mod_SYS_GET_DATATABLE_oracleDesc = Nothing
    '                GoTo linekt
    '            End If
    '        Catch Ex1 As Exception
    '            'SaveLog("mod_SYS_GET_DATASETOracle(" & Date.Now.ToString & ")", Ex.Message, "")
    '            p_DEsc = Ex1.Message
    '            mod_SYS_GET_DATATABLE_oracleDesc = Nothing
    '            GoTo linekt
    '        End Try
    '        Return p_DataSet.Tables(0)
    'linekt:
    '        If Not myCommand Is Nothing Then
    '            myCommand.Dispose()
    '        End If
    '        If Not g_Oracle_Connection Is Nothing Then
    '            If g_Oracle_Connection.State = ConnectionState.Open Then
    '                g_Oracle_Connection.Close()
    '            End If
    '        End If
    '    End Function

    '==============================================================================================
    '================================ORACLE==========================================
    '==============================================================================================

    'Public Function ModCheckConnect_Oracle(ByRef p_ConnectOracle As OracleConnection, ByRef p_ConnectStr As String) As Boolean Implements IService.CheckConnect_Oracle
    '    Dim g_Oracle_Connection As New OracleConnection
    '    Dim myCommand As OracleCommand ' OleDbCommand
    '    Dim p_Adapter As OracleDataAdapter ' OleDbDataAdapter

    '    Dim p_DataSet As New System.Data.DataSet
    '    Dim p_Int As Integer
    '    Try
    '        ModCheckConnect_Oracle = True
    '        p_ConnectStr = SysGetConnect_Oracle()
    '        g_Oracle_Connection.ConnectionString = p_ConnectStr ' = New OracleConnection(p_ConnectStr)
    '        g_Oracle_Connection.Open()

    '        p_ConnectOracle = g_Oracle_Connection

    '        'Catch ex As Exception
    '        '    'Return Nothing
    '        'End Try

    '        'Try
    '        '    myCommand = New OracleCommand(p_SQL, g_Oracle_Connection)
    '        '    p_Adapter = New OracleDataAdapter(myCommand)
    '        '    p_Int = p_Adapter.Fill(p_DataSet)
    '    Catch Ex As Exception
    '        p_ConnectOracle = Nothing
    '        p_ConnectStr = Ex.Message
    '        ModCheckConnect_Oracle = False
    '        'SaveLog("mod_SYS_GET_DATASETOracle(" & Date.Now.ToString & ")", Ex.Message, "")
    '        ' Return Nothing
    '    End Try
    '    ' Return p_DataSet
    'End Function
    '_
    '                                               
    'Public Sub CallFuntioncReturnCursorOralce(ByVal p_FunctionName As String, _
    '                                               ByRef p_DessErr As String, _
    '                                               ByVal p_ParameterArr() As OracleParameter, _
    '                                               ByRef p_TableReturn As DataTable) Implements IService.ModCallFuntioncReturnCursorOralce

    '    Dim g_Oracle_Connection As OracleConnection
    '    Dim myCommand As OracleCommand ' OleDbCommand
    '    Dim p_Adapter As OracleDataAdapter
    '    Dim p_Reader As OracleDataReader
    '    Dim p_ConnectStr As String
    '    Dim p_DataTable As New System.Data.DataTable
    '    Dim p_Int As Integer
    '    p_DessErr = ""
    '    Try
    '        '  Exit Function
    '        ' CallFuntioncReturnCursorOralce = Nothing
    '        If p_TableReturn Is Nothing Then
    '            p_TableReturn = New DataTable("TableReturn")
    '        End If

    '        p_ConnectStr = SysGetConnect_Oracle()
    '        'p_DessErr = p_ConnectStr
    '        'Exit Function
    '        g_Oracle_Connection = New OracleConnection(p_ConnectStr)
    '        '  p_DessErr = "AA111"


    '        g_Oracle_Connection.Open()

    '        myCommand = New OracleCommand '(g_Oracle_Connection)


    '        myCommand.Connection = g_Oracle_Connection
    '        myCommand.CommandType = CommandType.StoredProcedure
    '        myCommand.CommandText = p_FunctionName

    '        myCommand.Parameters.AddRange(p_ParameterArr)


    '        myCommand.Parameters.Add("p_ReturnCursor", OracleType.Cursor).Direction = ParameterDirection.ReturnValue
    '        p_Reader = myCommand.ExecuteReader

    '        p_TableReturn.Load(p_Reader)


    '        '  Return p_DataTable
    '    Catch Ex As Exception

    '        p_DessErr = Ex.Message
    '        '   Return Nothing

    '    End Try



    'End Sub
    'Public Function CallFuntioncReturnCursorOralce(ByVal p_SQL As String, ByRef p_DessErr As String) As DataTable Implements IService.CallFuntioncReturnCursorOralce

    '    Dim g_Oracle_Connection As New OracleConnection
    '    Dim myCommand As OracleCommand ' OleDbCommand
    '    Dim p_Adapter As OracleDataAdapter
    '    Dim p_Reader As OracleDataReader
    '    Dim p_ConnectStr As String
    '    Dim p_DataSet As New System.Data.DataSet
    '    Dim p_Int As Integer
    '    p_DessErr = ""
    '    Try
    '        CallFuntioncReturnCursorOralce = Nothing

    '        p_ConnectStr = SysGetConnect_Oracle()
    '        g_Oracle_Connection.ConnectionString = p_ConnectStr ' = New OracleConnection(p_ConnectStr)
    '        g_Oracle_Connection.Open()

    '        myCommand = New OracleCommand(p_SQL, g_Oracle_Connection)
    '        myCommand.CommandType = CommandType.Text
    '        '  myCommand.  .Properties("PLSQLRSet") = True
    '        p_Reader = myCommand.ExecuteReader()
    '        '    CallFuntioncReturnCursorOralce.Load(p_Reader)
    '        'p_Adapter.lo()
    '        'p_Adapter = New OracleDataAdapter(myCommand)


    '        ' myCommand.

    '        'myCommand = New OracleCommand()
    '        'myCommand.Connection = g_Oracle_Connection
    '        'myCommand.CommandText = p_SQL
    '        'myCommand.Parameters.Add("Ref_Return", OracleType.Cursor).Direction = ParameterDirection.ReturnValue
    '        'p_Adapter = myCommand.ExecuteReader

    '    Catch Ex As Exception

    '        p_DessErr = Ex.Message
    '        CallFuntioncReturnCursorOralce = Nothing

    '    End Try


    'End Function
#End Region
    '=============================================================================================================
#Region "Day du lieu tu HTTG sang Scadar"


    '1
    Public Function HTTG_To_Scadar(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_InsertToScadar As Boolean = True) As String
        Dim p_SQL As String
        Dim p_DataSet As DataSet
        Dim p_Eror As Boolean
        Dim p_Desc As String
        Dim p_ArrRow() As DataRow
        Try

            HTTG_To_Scadar = ""

            'p_SQL = "select * from tblMap_cp;" & _
            '    "select * from SYS_Map_cp_Line; " & _
            '    "select * from SYS_CONFIG; " & _
            '    "SELECT *  FROM [tblMap_MaHangHoa] where MaHangHoa_Sap='0201004';"
            p_SQL = "exec FPT_GetDataTableList"
            p_DataSet = p_SYS_GET_DATASET_Des(p_SQL, p_SQL)
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

            ModSys_GetParameterOracle(g_DBTYPE)

            '20150819
            If Not g_TabletblConfig Is Nothing Then
                If g_TabletblConfig.Rows.Count > 0 Then
                    g_TypeConnet = g_TabletblConfig.Rows(0).Item("optional").ToString.Trim()
                End If
            End If

            '20150819           

            '20150819
            If UCase(g_TypeConnet) = "FOX" Then
                If GetConnectFox(p_Desc, p_TypeIn, g_LoaiVanChuyen, p_Terminal) = False Then
                    HTTG_To_Scadar = p_Desc
                    p_Eror = True
                    Exit Function
                End If
            End If

            'If UCase(g_TypeConnet) = "FOX" Then
            '    If GetConnectFox(p_TypeIn, g_LoaiVanChuyen, p_Terminal) = False Then
            '        HTTG_To_Scadar = "Không xác định file Scadar"
            '        p_Eror = True
            '        Exit Function
            '    End If
            'End If



            getSQL_TableToScadar(p_TypeIn, g_LoaiVanChuyen, p_Terminal)


            If p_InsertToScadar = True Then
                If g_DBTYPE = "SQL" Then
                    'getSQL_TableToScadar("Thuy")

                    SQLGetDataToScadar(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Eror, p_Desc, p_Terminal)
                    If p_Eror = True Then
                        HTTG_To_Scadar = p_Desc
                    End If
                End If
            End If
        Catch ex As Exception
            HTTG_To_Scadar = ex.Message
        End Try
    End Function


    'Private Function GetConnectFox(ByVal p_TypeIn As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "") As Boolean
    '    Dim p_SQL As String
    '    Dim p_DataArr() As DataRow
    '    Dim p_FileType As String = ""
    '    Dim p_FileName As String = ""
    '    Dim p_DataTable As DataTable
    '    Dim p_Path As String = ""
    '    ' Dim p_Date As Date
    '    ' Dim p_Time As Integer
    '    GetConnectFox = True
    '    If g_Table_Sys_Config Is Nothing Then
    '        p_SQL = "SELECT * FROM SYS_CONFIG"
    '        g_Table_Sys_Config = New DataTable
    '        ' g_Table_Sys_Config = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

    '        g_Table_Sys_Config = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '        If g_Table_Sys_Config.Rows.Count > 0 Then
    '            p_DataArr = g_Table_Sys_Config.Select("KEYCODE='TYPEFOXNAME'")
    '            If p_DataArr.Length > 0 Then
    '                p_FileType = p_DataArr(0).Item("KEYVALUE").ToString.Trim
    '            End If
    '        End If
    '    Else
    '        p_DataArr = g_Table_Sys_Config.Select("KEYCODE='TYPEFOXNAME'")
    '        If p_DataArr.Length > 0 Then
    '            p_FileType = p_DataArr(0).Item("KEYVALUE").ToString.Trim
    '        End If
    '    End If

    '    If g_DataMap_cp Is Nothing Then
    '        ' Else
    '        p_SQL = "SELECT * FROM tblMap_cp"
    '        ' g_Table_Sys_Config = New DataTable
    '        ' g_Table_Sys_Config = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)
    '        g_DataMap_cp = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '    End If

    '    If g_DataMap_cp.Rows.Count > 0 Then
    '        p_DataArr = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & p_TypeIn & "') and Client='" & p_Terminal & "'")


    '        If p_DataArr.Length > 0 Then
    '            If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
    '                p_FileName = p_DataArr(0).Item("TableName").ToString.Trim

    '            ElseIf UCase(g_LoaiVanChuyen) = "THUY" Then

    '                p_FileName = p_DataArr(0).Item("TableName_Thuy").ToString.Trim
    '            End If

    '        End If

    '    End If

    '    If p_FileName = "[SPACE]" Or p_FileName = "SPACE" Then
    '        p_FileName = ""
    '    End If
    '    If p_FileType.ToString.Trim = "" Then

    '        GetConnectFox = False
    '        Exit Function
    '    End If

    '    p_SQL = "exec FPT_Get_FileName_Fox '" & UCase(p_FileType) & "'"
    '    p_DataTable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '    If Not p_DataTable Is Nothing Then
    '        If p_DataTable.Rows.Count > 0 Then
    '            p_FileName = p_FileName & p_DataTable.Rows(0).Item(0).ToString.Trim & ".dbf"
    '        End If
    '    End If
    '    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
    '        g_PathFileFoxBo = p_FileName
    '    Else
    '        g_PathFileFoxThuy = p_FileName
    '    End If
    '    p_SQL = "select * from SYS_FOXCONFIG"
    '    p_DataTable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '    '   g_StrConnectFox = "AAA"
    '    If Not p_DataTable Is Nothing Then
    '        If p_DataTable.Rows.Count > 0 Then
    '            If UCase(p_TypeIn) = "OUT" Then
    '                p_Path = Trim(p_DataTable.Rows(0).Item("FilePathOut"))

    '            End If
    '            If UCase(p_TypeIn) = "IN" Then
    '                p_Path = Trim(p_DataTable.Rows(0).Item("FilePathIn"))
    '            End If
    '            If p_Path = "" Then
    '                GetConnectFox = False


    '                '  g_StrConnectFox = "11111'"

    '                Exit Function
    '            End If

    '            If Right(p_Path, 1) = "\" Then
    '                p_FileName = p_Path & p_FileName
    '            Else
    '                p_FileName = p_Path & "\" & p_FileName
    '            End If
    '            If UCase(p_TypeIn) = "OUT" Then
    '                g_PathFileFoxOut = p_FileName
    '            End If
    '            If UCase(p_TypeIn) = "IN" Then
    '                g_PathFileFoxIn = p_FileName
    '            End If
    '            p_SQL = ""
    '            If CheckFileName(True, p_FileName, p_SQL) = False Then
    '                GetConnectFox = False
    '                'If Sys_Execute1("INSERT INTO AAAA (STR_SQL) VALUES ('33333333355:" & p_FileName & "') ", p_SQL) Then

    '                'End If


    '                Exit Function
    '            End If
    '            'Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\WCF3_5\DBFOX\out';Extended Properties=dBase 5.0
    '            g_StrConnectFox = "Provider=vfpoledb;Collating Sequence=general;Data Source=" & p_Path
    '            ' g_StrConnectFox = "Provider=vfpoledb;DSN=FoxE5;"
    '            'g_StrConnectFox = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & p_Path & "';Extended Properties=dBase 5.0"
    '            'Provider=vfpoledb;Collating Sequence=general;Data Source=C:\AAAAAATNB\TNB\Petro_VB_B12\Petro_VB
    '            'If Sys_Execute1("INSERT INTO AAAA (STR_SQL) VALUES ('Provider=Microsoft.ACE.OLEDB.12.0;Data Source=''" & p_Path & "'';Extended Properties=dBase 5.0') ", p_SQL) Then

    '            'End If
    '        End If
    '    End If

    'End Function


    Private Function GetConnectFox(ByRef p_DessErr As String, ByVal p_TypeIn As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "") As Boolean
        Dim p_SQL As String
        Dim p_DataArr() As DataRow
        Dim p_FileType As String = ""
        Dim p_FileName As String = ""
        Dim p_DataTable As DataTable
        Dim p_Path As String = ""
        ' Dim p_Date As Date
        ' Dim p_Time As Integer
        GetConnectFox = True
        p_DessErr = "Không xác định file Scadar"
        If g_Table_Sys_Config Is Nothing Then
            p_SQL = "SELECT * FROM SYS_CONFIG"
            g_Table_Sys_Config = New DataTable
            ' g_Table_Sys_Config = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

            g_Table_Sys_Config = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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

            g_DataMap_cp = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        End If
        If p_FileName = "[SPACE]" Or p_FileName = "SPACE" Then
            p_FileName = ""
        End If
        If p_FileType.ToString.Trim = "" Then
            GetConnectFox = False
            Exit Function
        End If

        p_SQL = "exec FPT_Get_FileName_Fox '" & UCase(p_FileType) & "'"
        p_DataTable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
        p_SQL = "select * from SYS_FOXCONFIG"
        p_DataTable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                If UCase(p_TypeIn) = "OUT" Then
                    p_Path = Trim(p_DataTable.Rows(0).Item("FilePathOut"))

                End If
                If UCase(p_TypeIn) = "IN" Then
                    p_Path = Trim(p_DataTable.Rows(0).Item("FilePathIn"))
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
                'Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\WCF3_5\DBFOX\out';Extended Properties=dBase 5.0
                'g_StrConnectFox = "Provider=vfpoledb;Collating Sequence=general;Data Source=" & p_Path
                ' g_StrConnectFox = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & p_Path & "';Extended Properties=dBase 5.0"
                g_StrConnectFox = "Provider=vfpoledb;Collating Sequence=general;Data Source=" & p_Path
                '  g_StrConnectFox = "Provider=vfpoledb;DSN=DBFox_E5;"
                'g_StrConnectFox = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" & p_Path & ";" & _
                '   "Exclusive=No;Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;"
            End If
        End If

    End Function

    '2
    Private Sub getSQL_TableToScadar(ByVal p_TypeIn As String, ByVal g_LoaiVanChuyen As String, ByVal p_Terminal As String)
        'g_LoaiVanChuyen: Bo,Thuy,Sat
        Dim p_SQL As String
        Dim p_Connect As String
        Dim p_DataRow() As DataRow
        Dim p_TableName As String = ""
        Dim p_DataTable As DataTable

        Dim p_TypeConnet As String = "SQL"

        If Not g_TabletblConfig Is Nothing Then
            If g_TabletblConfig.Rows.Count > 0 Then
                p_TypeConnet = g_TabletblConfig.Rows(0).Item("optional").ToString.Trim()
            End If
        End If

        If Not g_TableToScadarBo Is Nothing Then
            Exit Sub
        End If

        If g_DataMap_cp Is Nothing Then
            Exit Sub
        End If
        p_DataRow = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "') and Client='" & p_Terminal & "'")
        If p_DataRow.Length > 0 Then

            Select Case UCase(p_TypeConnet)
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


                        If Sys_Execute1("INSERT INTO AAAA (STR_SQL) VALUES ('CCCCCCC') ", p_SQL) Then

                        End If

                        p_DataTable = New DataTable

                        'p_DataTable = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                        p_DataTable = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                        If Sys_Execute1("INSERT INTO AAAA (STR_SQL) VALUES ('ccc:" & Replace(p_SQL, "'", "", 1) & "') ", p_SQL) Then

                        End If
                        If p_DataTable Is Nothing Then
                            If Sys_Execute1("INSERT INTO AAAA (STR_SQL) VALUES ('sdfdfsfsfsf') ", p_SQL) Then

                            End If
                        End If

                        If Sys_Execute1("INSERT INTO AAAA (STR_SQL) VALUES ('bbbb:') ", p_SQL) Then

                        End If

                        g_TableToScadarBo = GetStructTbaleScadar(p_DataTable)


                    Else




                        p_TableName = g_PathFileFoxThuy

                        p_DataTable = New DataTable
                        p_SQL = "select * from " & p_TableName & " where 1=0"
                        p_DataTable = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                        g_TableToScadarThuy = GetStructTbaleScadar(p_DataTable)
                    End If


                Case Else
                    Exit Sub
            End Select



            p_DataRow = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & p_TypeIn & "') and (Client='E5 Xitec' or Client='E5 XITEC' )")
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
        Dim p_ArmNo As Integer
        Dim p_TyTrongNenE5 As Double
        Dim p_TyTrongEthanolE5 As Double
        Dim p_StrExeE5 As String
        Dim p_Flag() As String


        'Dim p_DataRowHangHoaE5() As DataRow

        p_TableExec.Columns.Add("SQL_STR", GetType(String))
        p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
        If g_DataMap_cp Is Nothing Then
            Exit Sub
        End If
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "'  or Status='" & UCase(p_TypeIn) & "' ) and (Client='E5 Xitec' or Client='E5 XITEC' )")
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



        'If g_ConnectToScadar.ToString.Trim = "" Then
        '    p_Error = True
        '    p_Desc = "String kết nối đến máy chủ Scadar không xác định"
        '    Exit Sub
        'End If
        p_TableExec.Clear()
        '20150819
        If UCase(g_TypeConnet) = "FOX" Then

            If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                p_TableName = Replace(g_PathFileFoxBo, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)
                p_InsertTable = "INSERT INTO " & p_TableName & " "
                p_ValueTable = " VALUES "
            Else
                p_TableName = Replace(g_PathFileFoxThuy, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)
                p_InsertTable = "INSERT INTO " & p_TableName & " "
                p_ValueTable = " VALUES "
            End If

        End If


        p_InsertTable = "INSERT INTO " & p_TableName & " "
        p_ValueTable = " VALUES "

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
        p_DataHTTG = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, "E5 Xitec", p_HangHoaE5)
                    Else
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, p_Terminal, p_HangHoaE5)
                    End If

                    If p_FieldType.ToString.Trim <> "" Then

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




                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
                            If p_Where_Check.ToString.Trim = "" Then
                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                            Else
                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

                            End If
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
                        End If

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            'If p_Where_Check.ToString.Trim = "" Then
                            '    Select Case UCase(g_LoaiVanChuyen)
                            '        Case "BO"
                            '            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                            '        Case "THUY"
                            '            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                            '        Case "SAT"
                            '            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                            '    End Select
                            'Else
                            '    Select Case UCase(g_LoaiVanChuyen)
                            '        Case "BO"
                            '            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                            '        Case "THUY"
                            '            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                            '        Case "SAT"
                            '            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                            '    End Select
                            'End If
                            If UCase(g_TypeConnet) = "FOX" Then
                                If p_Where_Check.ToString.Trim = "" Then
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=#" & CDate(p_Value).ToString("MM/dd/yyyy") & "#"
                                        Case "THUY"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=#" & CDate(p_Value).ToString("MM/dd/yyyy") & "#"
                                        Case "SAT"
                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=#" & CDate(p_Value).ToString("MM/dd/yyyy") & "#"
                                    End Select
                                Else
                                    Select Case UCase(g_LoaiVanChuyen)
                                        Case "BO"
                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=#" & CDate(p_Value).ToString("MM/dd/yyyy") & "#"
                                        Case "THUY"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=#" & CDate(p_Value).ToString("MM/dd/yyyy") & "#"
                                        Case "SAT"
                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=#" & CDate(p_Value).ToString("MM/dd/yyyy") & "#"
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
                        End If
                        '
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
                            p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
                            'If g_MaTuDongHoa = "N" Then
                            If p_Value.ToString.Trim <> "" Then
                                p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                               p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                                    p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                        End If
                        'Tinh lai Ma lenh cua tu dong hoa

                        'Kiem tra trong Scadar co chua, neu co roi thi khong insert nua

                        'Select Case UCase(p_FieldType)
                        '    Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                        '        p_SQLValue = p_SQLValue & "," & p_Value
                        '    Case UCase("DateTime"), UCase("Date")
                        '        p_SQLValue = p_SQLValue & ",'" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                        '    Case UCase("String")
                        '        p_SQLValue = p_SQLValue & ",'" & p_Value & "'"
                        'End Select
                        '20150819
                        Select Case UCase(p_FieldType)
                            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                p_SQLValue = p_SQLValue & "," & CDec(IIf(p_Value.ToString.Trim = "", 0, p_Value))
                            Case UCase("DateTime"), UCase("Date")
                                If UCase(g_TypeConnet) = "SQL" Then
                                    p_SQLValue = p_SQLValue & ",'" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                End If
                                If UCase(g_TypeConnet) = "FOX" Then
                                    p_SQLValue = p_SQLValue & ",{d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                    ' p_SQLValue = p_SQLValue & ",#" & CDate(p_Value).ToString("MM/dd/yyyy") & "#"
                                    '{d '" & CDate(Ngay_Ctu.Text.ToString.Trim).ToString("yyyy-MM-dd") & "'} "
                                    'l_Nam = CDate(p_Value).ToString("yyyy")
                                    'l_Thang = CDate(p_Value).ToString("MM")
                                    'l_Ngay = CDate(p_Value).ToString("dd")
                                    'l_ngayxuat = New DateTime(l_Nam, l_Thang, l_Ngay)
                                    'p_SQLValue = p_SQLValue & ",'" & l_ngayxuat & "'"


                                End If
                            Case UCase("String")
                                p_SQLValue = p_SQLValue & ",'" & p_Value & "'"
                        End Select
                    End If
                Next

                'If p_Where_Check.ToString.Trim <> "" Then
                '    If p_HangHoaE5 = True Then
                '        p_SQL = "select 1 as STT  from " & p_TableName_E5 & " WHERE " & p_Where_Check
                '        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
                '        If Not p_DataTableCheckID Is Nothing Then
                '            If p_DataTableCheckID.Rows.Count > 0 Then
                '                Continue For
                '            End If

                '        End If
                '    Else
                '        p_SQL = "select 1 as STT from " & p_TableName & " WHERE " & p_Where_Check
                '        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                '        If Not p_DataTableCheckID Is Nothing Then
                '            If p_DataTableCheckID.Rows.Count > 0 Then
                '                Continue For
                '            End If

                '        End If

                '    End If

                'End If

                '20150819
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
                        p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check
                        If UCase(g_TypeConnet) = "FOX" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    Continue For
                                End If

                            End If

                        End If
                        If UCase(g_TypeConnet) = "SQL" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    Continue For
                                End If

                            End If

                        End If

                    End If

                End If



                If p_HangHoaE5 = True Then
                    'ByRef p_Tyle As Double, ByRef p_TyTrongNen As Double, ByRef p_TyTrongEthanol As Double
                    GetTyTrong_TyLeE5(p_DataRowHTTG.Item("TableID").ToString.Trim, _
                                        p_DataRowHTTG.Item("MaLenh").ToString.Trim, _
                                        CDate(p_DataRowHTTG.Item("NgayXuat")), _
                                        p_DataRowHTTG.Item("LineID").ToString.Trim, _
                                        p_TyleE5, _
                                        p_TyTrongNenE5, _
                                        p_TyTrongEthanolE5, p_ArmNo)
                    If p_TyleE5 = 0 Or p_TyTrongNenE5 = 0 Or p_TyTrongEthanolE5 = 0 Then
                        p_Desc = "Không xác định Tỷ lệ phối trộn hoặc tỷ trọng nền " & vbCrLf & "    hoặc tỷ trong Ethanol"
                        p_Error = True
                        Exit Sub
                    Else
                        p_SQLInsert = p_SQLInsert & ",TYLE_PRESET, TYTRONG_BASE, TYTRONG_E, MA_HONG "
                        p_SQLValue = p_SQLValue & "," & p_TyleE5 & "," & p_TyTrongNenE5 & "," & p_TyTrongEthanolE5 & "," & p_ArmNo
                    End If

                End If

                'Neu la FOX thi bo sung gia trij cho cac truong khong co trong danh sach
                If UCase(g_TypeConnet) = "FOX" Then

                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                        FoxGetExtraField(g_LoaiVanChuyen, p_STT, g_DataMap_Line_cp, g_TableToScadarBo, p_SQLInsert, p_SQLValue)
                    Else
                        FoxGetExtraField(g_LoaiVanChuyen, p_STT, g_DataMap_Line_cp, g_TableToScadarThuy, p_SQLInsert, p_SQLValue)
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
                        ModSys_GetParameterOracle(g_DBTYPE)
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
                                'Else

                            End If

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
                        ModSys_GetParameterOracle(g_DBTYPE)
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
            p_TableExec.Clear()
            p_DataRow = p_TableExec.NewRow
            p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set Status='3' where charindex(SoLenh,'" & p_SoLenh & "',1)>0 "
            p_TableExec.Rows.Add(p_DataRow)
            If p_TableExec.Rows.Count > 0 Then
                If g_DBTYPE = "ORACLE" Then
                    'If Sys_Execute_DataTbl_Oracle(p_TableExec, p_SQL) = False Then
                    '    'MsgBox(p_SQL)
                    '    p_Desc = p_SQL
                    '    p_Error = True
                    '    Exit Sub
                    'Else
                    'End If
                ElseIf g_DBTYPE = "SQL" Then
                    If Sys_Execute_DataTbl1(p_TableExec, p_SQL) = False Then
                        'MsgBox(p_SQL)
                        p_Desc = p_SQL
                        p_Error = True
                        Exit Sub

                    End If
                End If
            End If
        End If
    End Sub



    Private Sub GetTyTrong_TyLeE5(ByVal p_TableID As String, ByVal p_MaLenh As String, ByVal p_NgayThang As Date, ByVal p_LineID As String, _
                                  ByRef p_Tyle As Double, ByRef p_TyTrongNen As Double, ByRef p_TyTrongEthanol As Double, ByRef p_ArmNo As Integer)
        'TYLE_PRESET()
        'TYTRONG_BASE()
        'TYTRONG_E()
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        p_Tyle = 0
        p_TyTrongNen = 0
        p_TyTrongEthanol = 0
        p_ArmNo = 0
        p_SQL = "exec FPT_TyLe_TyTrong '" & p_TableID & "','" & p_MaLenh & "','" & CDate(p_NgayThang).ToString("yyyyMMdd") & "','" & p_LineID & "'"
        p_DataTable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                p_Tyle = p_DataTable.Rows(0).Item("ERate").ToString.Trim
                p_TyTrongNen = p_DataTable.Rows(0).Item("XangNen").ToString.Trim
                p_TyTrongEthanol = p_DataTable.Rows(0).Item("Ethanol").ToString.Trim
                p_ArmNo = p_DataTable.Rows(0).Item("ArmNo").ToString.Trim
            End If
        End If
    End Sub




    Private Sub SQLGetColumnType(ByVal p_TypeIn As String, ByVal g_LoaiVanChuyen As String, ByVal p_FileName As String, ByRef p_FieldTypeScadar As String, _
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
                p_FieldNameScadar = p_DataRow(0).Item("Bo").ToString.Trim
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
                    p_DataRow = g_TableToScadarBo.Select("FieldName='" & p_FieldNameScadar & "'")
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
        If Not p_DataTable Is Nothing Then
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
        End If

        Return p_DataTableOut
    End Function



    'Private Function Sys_Execute_DataTbl_With_Connection(ByVal p_Connection As String, ByVal p_DataTable1 As System.Data.DataTable, _
    '                                      ByRef p_Desc As String) As Boolean 'Implements IService.Sys_Execute_DataTbl_With_Connection

    '    Dim p_Count As Integer
    '    Dim p_int As Integer = 0
    '    'Dim adapter As OracleDataAdapter


    '    Dim Oleconnection As New OleDbConnection
    '    Dim Olecommand As OleDbCommand
    '    Dim p_Oletransaction As OleDbTransaction


    '    Sys_Execute_DataTbl_With_Connection = True
    '    Try
    '        Oleconnection.ConnectionString = p_Connection
    '        Oleconnection.Open()
    '        'Oleconnection = Sys_SQL_Connection()
    '        p_Oletransaction = Oleconnection.BeginTransaction
    '        Olecommand = New OleDbCommand
    '        With Olecommand
    '            .Connection = Oleconnection
    '            .Transaction = p_Oletransaction
    '            .CommandType = CommandType.Text
    '            For p_Count = 0 To p_DataTable1.Rows.Count - 1
    '                If p_DataTable1.Rows(p_Count).Item(0).ToString <> "" Then
    '                    .CommandText = p_DataTable1.Rows(p_Count).Item(0).ToString
    '                    .ExecuteNonQuery()
    '                End If
    '            Next
    '        End With
    '        p_Oletransaction.Commit()
    '        Oleconnection.Close()
    '        p_Oletransaction = Nothing
    '    Catch ex As Exception
    '        p_Oletransaction.Rollback()
    '        p_Oletransaction = Nothing
    '        p_Desc = Err.Number & "-Line " & p_Count + 1 & ":" & ex.Message
    '        Sys_Execute_DataTbl_With_Connection = False

    '    End Try

    'End Function

    Public Function GET_DATATABLE_With_Connect_Des1(ByVal p_ConnectStr As String, ByVal p_SQL As String, _
                                                ByRef p_DesErr As String) As DataTable
        GET_DATATABLE_With_Connect_Des1 = p_SYS_GET_DATATABLE_With_Connect_Des(p_ConnectStr, p_SQL, p_DesErr)
    End Function


    Private Function p_SYS_GET_DATATABLE_With_Connect_Des(ByVal p_ConnectStr As String, ByVal p_SQL As String, _
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


#End Region
    '=============================================================================================================

    '=============================================================================================================
#Region "Lay du lieu tu Scadar ve HTTG"
    '=============================================================================================================

    'p_TypeIn=out hoac in
    Public Function ScadarToHTTG(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True) As String
        Dim p_SQL As String
        Dim p_DataSet As DataSet
        Dim p_Eror As Boolean
        Dim p_Desc As String
        Dim p_ArrRow() As DataRow
        Try

            ScadarToHTTG = ""

            'p_SQL = "select * from tblMap_cp;" & _
            '    "select * from SYS_Map_cp_Line; " & _
            '    "select * from SYS_CONFIG; " & _
            '    "SELECT *  FROM [tblMap_MaHangHoa] where MaHangHoa_Sap='0201004';"
            p_SQL = "exec FPT_GetDataTableList"
            p_DataSet = p_SYS_GET_DATASET_Des(p_SQL, p_SQL)
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

            ModSys_GetParameterOracle(g_DBTYPE)


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
            p_DataRow = g_TableMaHangHoaE5.Select("MaHangHoa_Sap='" & p_MaHangHoa & "'")
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
        p_Datatatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
        Dim p_DataRowMap_cp_Old() As DataRow
        'Dim p_InsertTable_E5 As String = ""
        'Dim p_ValueTable_E5 As String = ""
        Dim p_TableScadar_E5 As DataTable
        Dim p_MaHangHoa As String
        Dim p_HangHoaE5 As Boolean
        Dim p_StatusType As String

        Dim p_Flag() As String
        Dim p_DataTableA92 As DataTable
        Dim p_DataRowCheck() As DataRow

        If g_DataMap_cp Is Nothing Then
            Exit Sub
        End If
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "') and (Client='E5 Xitec' or Client='E5 XITEC' )")
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
        p_DataHTTG = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataHTTG Is Nothing Then
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
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, "E5 Xitec", p_HangHoaE5)
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
                            '    Select Case UCase(g_LoaiVanChuyen)
                            '        Case "BO"
                            '            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "'" & p_Value & "'"
                            '        Case "THUY"
                            '            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "'" & p_Value & "'"
                            '        Case "SAT"
                            '            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "'" & p_Value & "'"
                            '        Case Else
                            '            Continue For
                            '    End Select

                            'Else
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
                                If UCase(g_TypeConnet) = "FOX" Then
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
                                If UCase(g_TypeConnet) = "FOX" Then
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
                            If g_MaTuDongHoa = "N" Then  'Ma tu dong hoa cho SQL la TableID
                                p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
                                'If g_MaTuDongHoa = "N" Then
                                If p_Value.ToString.Trim <> "" Then
                                    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                   p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                    p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                                        p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                            ElseIf g_MaTuDongHoa = "Y" Then  'Ma tu dong hoa cho FOX
                                p_SQL = "exec FPT_Key_TuDongHoa"
                                p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                                If Not p_DataTableCheckID Is Nothing Then
                                    If p_DataTableCheckID.Rows.Count > 0 Then
                                        p_Value = p_DataTableCheckID.Rows(0).Item("MaTuDongHoa").ToString.Trim
                                    End If
                                End If
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
                        If UCase(g_TypeConnet) = "FOX" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
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
                        If UCase(g_TypeConnet) = "SQL" Then
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
                        'p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                        'If Not p_DataTableCheckID Is Nothing Then
                        '    If p_DataTableCheckID.Rows.Count > 0 Then
                        '        If p_TableScadar Is Nothing Then
                        '            p_TableScadar = p_DataTableCheckID
                        '        Else
                        '            p_TableScadar.Merge(p_DataTableCheckID)
                        '        End If
                        '    End If

                        'End If

                    End If

                End If
            Next
            p_CountRow = 0

            p_DataTableA92 = SQLGetDataFromScadar_A92(p_DataHTTG, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
                                     p_Terminal)
            If Not p_DataTableA92 Is Nothing Then
                If p_TableScadar_E5 Is Nothing Then
                    p_TableScadar_E5 = p_DataTableA92
                Else
                    p_TableScadar_E5.Merge(p_DataTableA92)
                End If

            End If
            If Not p_TableScadar Is Nothing Then
                p_CountRow = p_CountRow + p_TableScadar.Rows.Count
                ' p_TableScadar.Columns.Add("MaBe")
            End If

            If Not p_TableScadar_E5 Is Nothing Then
                p_CountRow = p_CountRow + p_TableScadar_E5.Rows.Count
            End If



            If p_DataHTTG.Rows.Count = p_CountRow And p_CountRow > 0 Then
                UpdateFromScadarToHTTG(g_LoaiVanChuyen, p_DataRowMap_cp_E5, p_DataRowMap_cp_Old, p_DataHTTG, p_TableScadar, p_TableScadar_E5)
                'anhqh
                '20150817
                UpdateFromScadarToHTTG_A92(g_LoaiVanChuyen, p_DataRowMap_cp_E5, p_DataRowMap_cp_Old, p_DataHTTG, p_TableScadar, p_TableScadar_E5)
            Else
                p_Error = True
                p_Desc = "Chưa thực hiện bơm xuất"
                Exit Sub
            End If
        End If
    End Sub


    'anhqh
    '20150817
    'Ham thuc hien voi Hang hoa xang A92 khi xuat hong E5

    'anhqh
    '20150817
    'Ham thuc hien voi Hang hoa xang A92 khi xuat hong E5

    Private Function SQLGetDataFromScadar_A92(ByVal p_DataHTTG As DataTable, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, ByRef p_Error As Boolean, ByRef p_Desc As String, _
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
        If g_DataMap_cp Is Nothing Then
            Exit Function
        End If
        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "') and (Client='E5 Xitec' or Client='E5 XITEC' )")
        If p_DataRowMap_cp_Old.Length <= 0 Then
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
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, "E5 Xitec", p_HangHoaE5)
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
                                p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                               p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                                p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                                    p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                            p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_TableID & "','" & _
                           p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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


    Private Function UpdateFromScadarToHTTG(ByVal g_LoaiVanChuyen As String, ByVal p_DataRowMap_cp_E5() As DataRow, ByVal p_DataRowMap_cp_Old() As DataRow, ByVal p_DataTableHTTG As DataTable, _
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
                            p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_TableID & "','" & _
                           p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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

            UpdateFromScadarToHTTG = BuildTbaleUpdateHTTG(g_LoaiVanChuyen, p_DataTableWhere, p_DataTableHTTG, p_Scadar, p_ScadarE5, p_SQL)

        Catch ex As Exception
            UpdateFromScadarToHTTG = True
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
        Try
            BuildTbaleUpdateHTTG = False

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
                        BuildTbaleUpdateHTTG = True
                        Exit Function
                    End If
                    p_ArrayRow = p_ScadarE5.Select(p_CurrentRow.Item("STR_SCADAR").ToString.Trim)
                    p_HangHoaE5 = True
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
                    BuildTbaleUpdateHTTG = True
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
                            BuildTbaleUpdateHTTG = True
                            Exit Function
                    End Select

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

                    If p_Value.ToString.Trim = "" Then
                        Continue For
                    End If


                    If p_ColumnType = "" Then
                        BuildTbaleUpdateHTTG = True
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
                            BuildTbaleUpdateHTTG = True
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
                            BuildTbaleUpdateHTTG = True
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
                    'If Sys_Execute_DataTbl_Oracle(p_DataTableExe, p_SQL) = False Then
                    '    'MsgBox(p_SQL)
                    '    p_Desc = p_SQL
                    '    ' ShowMessageBox("", p_Desc)
                    '    BuildTbaleUpdateHTTG = True
                    '    Exit Function
                    'Else
                    'End If
                ElseIf g_DBTYPE = "SQL" Then
                    If Sys_Execute_DataTbl1(p_DataTableExe, p_SQL) = False Then
                        'MsgBox(p_SQL)
                        p_Desc = p_SQL
                        'ShowMessageBox("", p_Desc)
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


    Private Sub p_GetCurrentDate(ByRef p_Date As DateTime)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        p_SQL = "select  getdate() as SysDate"
        p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SysDate")

            End If
        End If
        p_Datatable = Nothing
    End Sub

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
        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "') and (Client='E5 Xitec' or Client='E5 XITEC' )")
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
        p_DataHTTG = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, "E5 Xitec", p_HangHoaE5)
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
                                    p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                                        p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                                p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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

                End If
                If p_SQLInsert.Trim <> "" Then
                    p_SQLInsert = Mid(p_SQLInsert, 2)
                End If

                If p_SQLInsert <> "" Then

                    p_StrExe = p_InsertTable & "(" & p_SQLInsert & ") "

                    p_DataRow = p_TableExec.NewRow
                    p_DataRow.Item(0) = p_StrExe
                    p_TableExec.Rows.Add(p_DataRow)
                End If

            Next

            If Not p_TableExec Is Nothing Then
                If p_TableExec.Rows.Count > 0 Then
                    If g_DBTYPE = "" Then
                        ModSys_GetParameterOracle(g_DBTYPE)
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

            'Cap nhat lai trang thai cua lenhXuat
            p_TableExec.Clear()
            p_DataRow = p_TableExec.NewRow
            p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set Status='3' where SoLenh='" & p_SoLenh & "'"
            p_TableExec.Rows.Add(p_DataRow)
            If Not p_TableExec Is Nothing Then
                If p_TableExec.Rows.Count > 0 Then
                    If g_DBTYPE = "" Then
                        ModSys_GetParameterOracle(g_DBTYPE)
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
                p_DataTable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

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


            l_dt = p_SYS_GET_DATATABLE_Des(l_sql, l_sql)

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

#End Region
    '=============================================================================================================

#Region "Get VCF, Get WCF"

    '-----------------
    '0: Temp
    '1: Dens
    '-----------------
    Public Function mdlQCI_GetDefaultTank(ByVal i_mahanghoa As String) As String()
        Dim l_result As String() = New String() {String.Empty, String.Empty}
        Try
            ' Dim l_c2sql As Connect2SQL.Connect2SQL
            Dim l_dt As DataTable = New DataTable
            Dim p_SQL As String

            p_SQL = "Select top 10 * from tblTankActive where Product_nd = '" & i_mahanghoa & "' Order by ID desc"
            l_dt = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            ' l_c2sql = New Connect2SQL.Connect2SQL(_SQLConnectionString)
            ' l_dt = l_c2sql.getTableValue("Select top 10 * from tblTankActive where Product_nd = '" & i_mahanghoa & "' Order by ID desc")

            If l_dt.Rows.Count > 0 Then
                l_result(0) = "30.00"
                l_result(1) = l_dt.Rows(0).Item("Dens_nd").ToString()
            Else
                l_result(0) = "30.00"
                l_result(1) = "0.658"
            End If
        Catch ex As Exception

        End Try

        Return l_result

    End Function

    Public Function mdlQCI_GetVCFSub(ByVal i_connectionstring As String, _
                                     ByVal i_temp As String, _
                                     ByVal i_dens As String) As String
        'Dim l_dens As Decimal
        'Dim l_dens_in As Decimal

        'Dim l_dens_arr As String()
        'Dim l_dens_1, _
        '    l_dens_2 As Integer
        'Dim l_dens_1_dec, _
        '    l_dens_2_dec As Decimal

        'Dim l_c2sql As Connect2SQL.Connect2SQL
        'Dim l_dt As DataTable = New DataTable
        'Dim l_sql As String
        'Try

        '    l_dens_in = Convert.ToDecimal(i_dens)
        '    l_dens = Math.Round(l_dens_in, 3)
        '    l_dens_arr = l_dens.ToString().Split(".")
        '    l_dens_1 = Convert.ToInt32(l_dens_arr(1))

        '    l_dens_1 = l_dens_1 - 1
        '    l_dens_2 = l_dens_1 + 2

        '    l_dens_1_dec = Convert.ToDecimal(l_dens_arr(0) & "." & l_dens_1.ToString())
        '    If l_dens_2.ToString().Length > l_dens_1.ToString().Length Then
        '        l_dens_2 = Convert.ToInt32(l_dens_arr(0)) + 1
        '        l_dens_2_dec = Convert.ToDecimal(l_dens_2)
        '    Else
        '        l_dens_2_dec = Convert.ToDecimal(l_dens_arr(0) & "." & l_dens_2.ToString())
        '    End If

        '    l_sql = "select * from tblVCF where [Temp] = '" & i_temp & _
        '            "' and [Dens] in ('" & l_dens_1_dec.ToString() & "' , '" & l_dens_2_dec.ToString() & "') order by vcf"

        '    l_c2sql = New Connect2SQL.Connect2SQL(i_connectionstring)
        '    l_dt = l_c2sql.getTableValue(l_sql)

        '    If l_dt.Rows.Count <> 2 Then
        '        Return "0"
        '    End If

        '    Dim l_vcf_1, _
        '        l_vcf_2, _
        '        l_vcf _
        '        As Decimal

        '    l_vcf_1 = Convert.ToDecimal(l_dt.Rows(0).Item("VCF").ToString())
        '    l_vcf_2 = Convert.ToDecimal(l_dt.Rows(1).Item("VCF").ToString())

        '    l_vcf = Math.Abs(l_vcf_2 - l_vcf_1) / Math.Abs(l_dens_2_dec - l_dens_1_dec)
        '    l_vcf = l_vcf_1 + l_vcf * (l_dens_in - l_dens_1_dec)

        '    Return Math.Round(l_vcf, 4)
        'Catch ex As Exception
        '    Return "0"
        'End Try


    End Function

    Public Function mdlQCI_GetVCFSub_NS(ByVal i_connectionstring As String, _
                                     ByVal i_temp As String, _
                                     ByVal i_dens As String, _
                                     ByVal i_dens_1 As String, _
                                     ByVal i_dens_2 As String) As String
        Dim l_dens_in, _
            l_dens_1_dec, _
            l_dens_2_dec As Decimal

        ' Dim l_c2sql As Connect2SQL.Connect2SQL
        Dim l_dt As DataTable = New DataTable
        Dim l_sql As String

        Try

            l_dens_in = Convert.ToDecimal(i_dens)
            l_dens_1_dec = Convert.ToDecimal(i_dens_1)
            l_dens_2_dec = Convert.ToDecimal(i_dens_2)

            l_sql = "select * from tblVCF with (Nolock) where [Temp] = '" & i_temp & _
                    "' and [Dens] in ('" & l_dens_1_dec.ToString() & "' , '" & l_dens_2_dec.ToString() & "') order by vcf"

            'l_c2sql = New Connect2SQL.Connect2SQL(i_connectionstring)
            l_dt = p_SYS_GET_DATATABLE_Des(l_sql, l_sql)
            If l_dt Is Nothing Then
                Return "0"
            End If
            If l_dt.Rows.Count <> 2 Then
                Return "0"
            End If

            Dim l_vcf_1, _
                l_vcf_2, _
                l_vcf _
                As Decimal

            l_vcf_1 = Convert.ToDecimal(l_dt.Rows(0).Item("VCF").ToString())
            l_vcf_2 = Convert.ToDecimal(l_dt.Rows(1).Item("VCF").ToString())

            l_vcf = Math.Abs(l_vcf_2 - l_vcf_1) / Math.Abs(l_dens_2_dec - l_dens_1_dec)
            l_vcf = l_vcf_1 + l_vcf * (l_dens_in - l_dens_1_dec)

            Return Math.Round(l_vcf, 4)
        Catch ex As Exception
            Return "0"
        End Try

    End Function

    Public Function mdlQCI_GetVCF(ByVal i_temp As String, ByVal i_dens As String) As String
        Dim l_vcf As String
        'Dim l_c2sql As Connect2SQL.Connect2SQL = Nothing
        'Try
        '    l_c2sql = New Connect2SQL.Connect2SQL(_SQLConnectionString)

        '    l_vcf = l_c2sql.getDataValue("select VCF from tblVCF where [Dens] = '" & i_dens & "' and [Temp] = '" & i_temp & "'")
        '    If l_vcf = String.Empty Then
        '        l_vcf = "1"
        '    End If
        'Catch ex As Exception
        '    l_vcf = "1"
        'End Try

        Return l_vcf
    End Function

    Public Function mdlQCI_GetVCF_cp(ByVal i_connectionstring As String, _
                                     ByVal i_temp As String, _
                                     ByVal i_dens As String) As String
        Dim l_vcf As String
        'Dim l_c2sql As Connect2SQL.Connect2SQL = Nothing

        'Dim l_dens As String
        'Dim l_temp As String

        'If i_dens.Length > 6 Then
        '    l_dens = i_dens.Substring(0, 6)
        'Else
        '    l_dens = i_dens
        '    If i_dens.Length < 6 Then
        '        For i As Integer = 1 To 6 - i_dens.Length
        '            l_dens = l_dens & "0"
        '        Next
        '    End If
        'End If

        'l_dens = mdlQCI_ConvertDens(l_dens)

        'If i_temp.Length > 5 Then
        '    l_temp = i_temp.Substring(0, 5)
        'Else
        '    l_temp = i_temp
        '    If l_temp.Length = 2 Then
        '        l_temp = l_temp & ".00"
        '    Else

        '        If i_temp.Length < 5 Then
        '            For i As Integer = 1 To 5 - i_temp.Length
        '                l_temp = l_temp & "0"
        '            Next
        '        End If                
        '    End If
        'End If

        'l_temp = mdlQCI_ConvertTemp(l_temp)

        'Try
        '    l_c2sql = New Connect2SQL.Connect2SQL(i_connectionstring)

        '    l_vcf = l_c2sql.getDataValue("select VCF from tblVCF where [Dens] = '" & l_dens & "' and [Temp] = '" & l_temp & "'")
        '    If l_vcf = String.Empty Then                
        '        l_vcf = mdlQCI_GetVCFSub(i_connectionstring, l_temp, l_dens)
        '    End If
        'Catch ex As Exception
        '    l_vcf = "1"
        'End Try

        Return l_vcf
    End Function

    Public Function mdlQCI_GetVCF_NS(ByVal i_connectionstring As String, _
                                     ByVal i_temp As String, _
                                     ByVal i_dens As String) As String
        Dim l_vcf_1 As String
        ' Dim l_c2sql As Connect2SQL.Connect2SQL = Nothing

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

        l_dens_1 = mdlQCI_ConvertDens_1(l_dens)
        l_dens_2 = mdlQCI_ConvertDens_2(l_dens)

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
                p_SQL = "select VCF from tblVCF with (Nolock) where [Dens] = '" & l_dens_1 & "' and [Temp] = '" & l_temp & "'"
                p_DataTable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        l_vcf_1 = p_DataTable.Rows(0).Item("VCF").ToString.Trim
                    End If
                End If


                'l_vcf_1 = l_c2sql.getDataValue("select VCF from tblVCF where [Dens] = '" & l_dens_1 & "' and [Temp] = '" & l_temp & "'")
            Else
                l_vcf_1 = mdlQCI_GetVCFSub_NS(i_connectionstring, l_temp, i_dens, l_dens_1, l_dens_2)
            End If

            'l_c2sql = New Connect2SQL.Connect2SQL(i_connectionstring)

            'If l_dens_1 = l_dens_2 Then
            '    l_vcf_1 = l_c2sql.getDataValue("select VCF from tblVCF where [Dens] = '" & l_dens_1 & "' and [Temp] = '" & l_temp & "'")
            'Else
            '    l_vcf_1 = mdlQCI_GetVCFSub_NS(i_connectionstring, l_temp, i_dens, l_dens_1, l_dens_2)
            'End If
            'FES
            '20141028
            If l_vcf_1 = "" Then l_vcf_1 = "1"
        Catch ex As Exception
            l_vcf_1 = "1"
        End Try

        Return l_vcf_1
    End Function

    Public Function mdlQCI_GetVCF(ByVal i_mahanghoa As String) As String
        Dim l_vcf As String
        Dim l_out As String()
        Try
            l_out = mdlQCI_GetDefaultTank(i_mahanghoa)
            l_vcf = mdlQCI_GetVCF(l_out(0), l_out(1))
            If l_vcf = String.Empty Then
                l_vcf = "1"
            End If
        Catch ex As Exception
            l_vcf = "1"
        End Try

        Return l_vcf
    End Function

    Public Function mdlQCI_GetDens15(ByVal i_mahanghoa As String) As String
        Dim l_dens15 As String
        'Dim l_c2sql As Connect2SQL.Connect2SQL
        'Dim l_now As String = Format(Now(), "dd/MM/yyyy")
        'Try
        '    l_c2sql = New Connect2SQL.Connect2SQL(_SQLConnectionString)

        '    l_dens15 = l_c2sql.getDataValue("Select Dens_nd from tblDoBe where Name_Nd = '" & i_mahanghoa & _
        '                                    "' and Date_nd = '" & l_now & "'")
        '    If l_dens15 = String.Empty Then
        '        l_dens15 = "1"
        '    End If
        'Catch ex As Exception
        '    l_dens15 = "0.658"
        'End Try

        Return l_dens15
    End Function

    Public Function mdlQCI_GetWCF(ByVal i_dens15 As String) As String
        Dim l_wcf As Decimal
        Dim l_dens As Decimal = 0.0011

        l_wcf = Convert.ToDecimal(i_dens15)
        l_wcf = l_wcf - l_dens

        Return l_wcf.ToString()
    End Function

    '-----------------
    '0: L
    '1: L15
    '2: M15
    '3: Kg
    '-----------------

    Public Function mdlQCI_CalculateQCI(ByVal i_quantity As Decimal, ByVal i_donvitinh As String, ByVal i_temp As Decimal, ByVal i_dens As Decimal) As Decimal()
        Dim l_result As Decimal() = New Decimal() {0, 0, 0, 0}
        Dim l_temp, l_dens, l_vcf, l_wcf As String
        l_temp = i_temp.ToString()
        l_dens = i_dens.ToString()
        l_vcf = mdlQCI_GetVCF(i_temp, i_dens)
        l_wcf = mdlQCI_GetWCF(l_dens)

        Select Case i_donvitinh
            Case "L"
                l_result(0) = i_quantity
                l_result(1) = l_result(0) * Convert.ToDecimal(l_vcf)
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "L15"
                l_result(0) = i_quantity / Convert.ToDecimal(l_vcf)
                l_result(1) = i_quantity
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "M15"
                l_result(1) = i_quantity * 1000
                l_result(2) = i_quantity
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "KG"
                l_result(3) = i_quantity
                l_result(1) = l_result(3) / Convert.ToDecimal(l_wcf)
                l_result(2) = l_result(1) / 1000
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)

        End Select

        For i As Integer = 0 To l_result.Length - 1
            l_result(i) = Math.Round(l_result(i), 0)
        Next

        Return l_result
    End Function

    Public Function mdlQCI_CalculateQCI(ByVal i_connectionstring As String, ByVal i_quantity As Decimal, ByVal i_donvitinh As String, ByVal i_temp As Decimal, ByVal i_dens As Decimal) As Decimal()
        Dim l_result As Decimal() = New Decimal() {0, 0, 0, 0}
        Dim l_temp, l_dens, l_vcf, l_wcf As String
        Dim l_temp_str As String()

        l_temp = i_temp.ToString()
        l_dens = i_dens.ToString()

        l_temp_str = l_temp.ToString().Split(".")

        If l_temp_str.Length = 1 Then
            l_temp = l_temp_str(0) & ".00"
        End If

        l_vcf = mdlQCI_GetVCF_cp(i_connectionstring, l_temp, l_dens)
        l_wcf = mdlQCI_GetWCF(l_dens)

        Select Case i_donvitinh
            Case "L"
                l_result(0) = i_quantity
                l_result(1) = l_result(0) * Convert.ToDecimal(l_vcf)
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "L15"
                l_result(0) = i_quantity / Convert.ToDecimal(l_vcf)
                l_result(1) = i_quantity
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "M15"
                l_result(1) = i_quantity * 1000
                l_result(2) = i_quantity
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "KG"
                l_result(3) = i_quantity
                l_result(1) = l_result(3) / Convert.ToDecimal(l_wcf)
                l_result(2) = l_result(1) / 1000
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)

        End Select

        For i As Integer = 0 To l_result.Length - 1
            l_result(i) = Math.Round(l_result(i), 0)
        Next

        Return l_result
    End Function

    Public Function mdlQCI_CalculateQCI_NS(ByVal i_connectionstring As String, ByVal i_quantity As Decimal, ByVal i_donvitinh As String, ByVal i_temp As Decimal, ByVal i_dens As Decimal) As Decimal()
        Dim l_result As Decimal() = New Decimal() {0, 0, 0, 0}
        Dim l_temp, l_dens, l_vcf, l_wcf As String
        Dim l_temp_str As String()

        l_temp = i_temp.ToString()
        l_dens = i_dens.ToString()

        l_temp_str = l_temp.ToString().Split(".")

        If l_temp_str.Length = 1 Then
            l_temp = l_temp_str(0) & ".00"
        End If

        l_vcf = mdlQCI_GetVCF_NS(i_connectionstring, l_temp, l_dens)
        l_wcf = mdlQCI_GetWCF(l_dens)

        Select Case i_donvitinh
            Case "L"
                l_result(0) = i_quantity
                l_result(1) = l_result(0) * Convert.ToDecimal(l_vcf)
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "L15"
                l_result(0) = i_quantity / Convert.ToDecimal(l_vcf)
                l_result(1) = i_quantity
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "M15"
                l_result(1) = i_quantity * 1000
                l_result(2) = i_quantity
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "KG"
                l_result(3) = i_quantity
                l_result(1) = l_result(3) / Convert.ToDecimal(l_wcf)
                l_result(2) = l_result(1) / 1000
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)

        End Select

        For i As Integer = 0 To l_result.Length - 1
            l_result(i) = Math.Round(l_result(i), 0)
        Next

        Return l_result
    End Function

    Public Function mdlQCI_CalculateQCI(ByVal i_quantity As Decimal, ByVal i_donvitinh As String, ByVal i_vcf As Decimal) As Decimal()
        Dim l_result As Decimal() = New Decimal() {0, 0, 0, 0}
        Dim l_vcf, l_wcf As String
        l_vcf = i_vcf
        l_wcf = mdlQCI_GetWCF(l_vcf)

        Select Case i_donvitinh
            Case "L"
                l_result(0) = i_quantity
                l_result(1) = l_result(0) * Convert.ToDecimal(l_vcf)
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "L15"
                l_result(0) = i_quantity / Convert.ToDecimal(l_vcf)
                l_result(1) = i_quantity
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "M15"
                l_result(1) = i_quantity * 1000
                l_result(2) = i_quantity
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "KG"
                l_result(3) = i_quantity
                l_result(1) = l_result(3) / Convert.ToDecimal(l_wcf)
                l_result(2) = l_result(1) / 1000
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)

        End Select
        For i As Integer = 0 To l_result.Length - 1
            l_result(i) = Math.Round(l_result(i), 0)
        Next
        Return l_result
    End Function

    Public Function mdlQCI_ConvertTemp(ByVal i_temp As String) As String
        Try
            Dim l_temp As String()
            Dim l_dec0 As Integer
            Dim l_dec1 As Decimal
            Dim l_step_h As Decimal = 12.5

            l_temp = i_temp.Split(".")

            If l_temp.Length = 1 Then
                Return l_temp(0) & ".00"
            End If

            If l_temp.Length = 2 Then
                l_dec0 = l_temp(0)

                If l_temp(1).Length = 0 Then
                    l_temp(1) = "00"
                ElseIf l_temp(1).Length = 1 Then
                    l_temp(1) = l_temp(1) & "0"
                End If

                l_dec1 = l_temp(1)

                If (Convert.ToInt32(l_dec1) Mod 25) = 0 Then
                    Return i_temp
                End If

                l_dec1 = l_dec1 + 25

                If l_dec1 >= (100 + l_step_h) Then
                    l_temp(0) = (l_dec0 + 1).ToString()
                    l_temp(1) = "00"
                    Return l_temp(0) & "." & l_temp(1)
                End If

                If l_dec1 >= (75 + l_step_h) Then
                    Return l_temp(0) & ".75"
                End If

                If l_dec1 >= (50 + l_step_h) Then
                    Return l_temp(0) & ".50"
                End If

                If l_dec1 >= (25 + l_step_h) Then
                    Return l_temp(0) & ".25"
                End If

                Return l_temp(0) & ".00"
            End If

            Return i_temp

        Catch ex As Exception
            Return i_temp
        End Try
    End Function

    '----------------------------------
    '   Đầu vào luôn là 6 ký tự: 1.3456
    '   Đầu ra  luôn là 5 ký tự: 1.345
    '----------------------------------
    Public Function mdlQCI_ConvertDens(ByVal i_dens As String) As String
        Try
            Dim l_dens_0 As String
            Dim l_dens_11 As String
            Dim l_dens_12 As String
            Dim l_dens_1 As String
            Dim l_dens_2 As String
            Dim l_dens_3 As String

            l_dens_0 = i_dens

            If l_dens_0.Length < 6 Then
                For i As Integer = 1 To 6 - i_dens.Length
                    l_dens_0 = l_dens_0 & "0"
                Next
            End If

            '------------------------
            '   3 ký tự đầu
            '------------------------
            l_dens_11 = l_dens_0.Substring(0, 3)

            '------------------------
            '   Ký tự thứ 4
            '------------------------
            l_dens_12 = l_dens_0.Substring(3, 1)

            '------------------------
            '   4 ký tự đầu
            '------------------------
            l_dens_1 = l_dens_0.Substring(0, 4)

            '------------------------
            '   1 ký tự cuối
            '------------------------
            l_dens_2 = l_dens_0.Substring(5, 1)

            '------------------------
            '   1 ký tự áp chót
            '------------------------
            l_dens_3 = l_dens_0.Substring(4, 1)

            '----------------------------------------------------
            '   Nếu vị trí áp chót chẵn
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 Then
                Return l_dens_1 & l_dens_3
            End If

            '----------------------------------------------------
            '   Ngược lại: Nếu vị trí cuối >= 0
            '----------------------------------------------------
            If Convert.ToInt32(l_dens_2) >= 0 Then
                l_dens_3 = (Convert.ToInt32(l_dens_3) + 1).ToString()

                If Convert.ToInt32(l_dens_3) >= 10 Then
                    l_dens_3 = "0"
                    l_dens_12 = (Convert.ToInt32(l_dens_12) + 1).ToString()

                    If Convert.ToInt32(l_dens_12) >= 10 Then
                        l_dens_12 = "0"
                        l_dens_11 = Math.Round((Convert.ToDecimal(l_dens_11) + 0.1), 2).ToString()
                        Return l_dens_11 & l_dens_12 & l_dens_3
                    Else
                        Return l_dens_11 & l_dens_12 & l_dens_3
                    End If

                    Return l_dens_11 & l_dens_3
                End If

                Return l_dens_1 & l_dens_3
            End If

            Return i_dens

        Catch ex As Exception
            Return i_dens
        End Try
    End Function

    Public Function mdlQCI_ConvertDens_1(ByVal i_dens As String) As String
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
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 = "0" Then
                Return l_dens_1
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối = 0 và áp chót lẻ   : 1.2350 
            '   Đầu ra là                           : 1.235 - 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 = "0" Then
                l_dens_1_int = l_dens_1_int - l_step_1
                Return l_dens_1_int.ToString()
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót chẵn: 1.2346
            '   Đầu ra là                           : 1.234
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 <> "0" Then
                Return l_dens_1
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót lẻ  : 1.2351
            '   Đầu ra là                           : 1.235 - 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 <> "0" Then
                l_dens_1_int = l_dens_1_int - l_step_1
                Return l_dens_1_int.ToString()
            End If

            Return i_dens
        Catch ex As Exception
            Return i_dens
        End Try
    End Function

    Public Function mdlQCI_ConvertDens_2(ByVal i_dens As String) As String
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
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 = "0" Then
                Return l_dens_1
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối = 0 và áp chót lẻ   : 1.2350 
            '   Đầu ra là                           : 1.235 + 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 = "0" Then
                l_dens_1_int = l_dens_1_int + l_step_1
                Return l_dens_1_int.ToString()
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót chẵn: 1.2346
            '   Đầu ra là                           : 1.234 + 0.002
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 <> "0" Then
                l_dens_1_int = l_dens_1_int + l_step_2
                Return l_dens_1_int.ToString()
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót lẻ  : 1.2351
            '   Đầu ra là                           : 1.235 + 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 <> "0" Then
                l_dens_1_int = l_dens_1_int + l_step_1
                Return l_dens_1_int.ToString()
            End If

            Return i_dens
        Catch ex As Exception
            Return i_dens
        End Try
    End Function
#End Region

#Region "Temp, Dens, VCF"

    Private Function mdlQCI_FindTable(ByVal i_datatime As String) As DataTable
        Dim l_dt As DataTable = Nothing
        'Dim l_c2sql As Connect2SQL.Connect2SQL = Nothing
        Dim l_str As String = String.Empty
        Dim l_res As String = String.Empty
        Try

            l_str = "select * from tblDoBe where Date_nd = '" & i_datatime & "' and status = 'X'"
            l_dt = p_SYS_GET_DATATABLE_Des(l_str, l_str)
        Catch ex As Exception
            l_dt = Nothing

        End Try

        Return l_dt
    End Function


    Private Function mdlQCI_FindTable() As DataTable
        Dim l_dt As DataTable = Nothing
        'Dim l_c2sql As Connect2SQL.Connect2SQL = Nothing
        Dim l_str As String = String.Empty
        Dim l_res As String = String.Empty
        Try

            l_str = "select Date_nd from tblDoBe order by [ID] desc"
            l_dt = p_SYS_GET_DATATABLE_Des(l_str, l_str)
            l_res = String.Empty
            If Not l_dt Is Nothing Then
                If l_dt.Rows.Count > 0 Then
                    l_res = l_dt.Rows(0).Item("Date_nd").ToString.Trim
                End If
            End If
            ' l_res = l_c2sql.getDataValue(l_str)

            If l_res = String.Empty Then
                l_dt = Nothing
            Else
                l_str = "select * from tblDoBe where Date_nd = '" & l_res & "' and status = 'X'"
                l_dt = p_SYS_GET_DATATABLE_Des(l_str, l_str)
            End If

        Catch ex As Exception
            l_dt = Nothing

        End Try

        Return l_dt
    End Function

    Private Function mdlQCI_CreateVCF() As DataTable
        Dim l_dt As DataTable
        Dim l_now As String

        l_dt = New DataTable
        l_now = Format(Now(), "dd/MM/yyyy")

        l_dt = mdlQCI_FindTable(l_now)

        Try
            If l_dt Is Nothing Then
                l_dt = mdlQCI_FindTable()

                If l_dt IsNot Nothing And l_dt.Rows.Count > 0 Then

                    Dim l_str As String = String.Empty
                    Dim l_err As String = String.Empty

                    For i As Integer = 0 To l_dt.Rows.Count - 1
                        l_err = String.Empty

                        l_str = "Insert into tblDoBe (Date_nd, Name_nd, Temp_nd, Dens_nd, Vcf_nd, Status) values('" & _
                            l_now & "',N'" & _
                            l_dt.Rows(i).Item("Name_Nd").ToString() & "',N'" & _
                            l_dt.Rows(i).Item("Temp_Nd").ToString() & "',N'" & _
                            l_dt.Rows(i).Item("Dens_Nd").ToString() & "',N'" & _
                            l_dt.Rows(i).Item("Vcf_nd").ToString() & "','X')"
                        'l_c2sql = New Connect2SQL.Connect2SQL(_SQLConnectionString)
                        'l_c2sql.ExeNonQuery(l_str, l_err)
                        If Sys_Execute1(l_str, l_str) = False Then

                        End If
                    Next
                    Return l_dt
                Else
                    Return Nothing
                End If
            Else
                Return l_dt
            End If

        Catch ex As Exception
            Return Nothing
        End Try
    End Function



    Private Sub p_GetDateTime(ByRef p_Date As Date, ByRef p_Time As Integer)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        p_SQL = "select  convert(date, getdate()) as SysDate, replace(CONVERT(VARCHAR(5),DATEADD(MINUTE,0 ,GETDATE()),108),':','') as SysTime"
        p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SysDate")
                p_Time = p_Datatable.Rows(0).Item("SysTime")
            End If
        End If
        p_Datatable = Nothing
    End Sub


#End Region
    '====================================================================================================
#Region "Lay thong tin lenh xuat tu SAP ve HTTG"


    'FES KV2
    '20141016
    Private Function mdlSyncDeliveries_CheckStartTime(ByVal i_date As String) As Boolean
        Dim l_date_start As Date
        Dim l_date_now As Date

        Dim l_date, _
            l_month, _
            l_year As String

        If i_date = String.Empty Then
            Return True
        End If

        Try
            l_date_now = Date.Now
            l_date = i_date.Substring(i_date.Length - 2, 2)
            l_month = i_date.Substring(i_date.Length - 4, 2)
            l_year = i_date.Substring(0, 4)

            If Convert.ToInt32(l_date) = 0 Or _
               Convert.ToInt32(l_month) = 0 Or _
               Convert.ToInt32(l_year) = 0 Then
                Return True
                'Return False
            End If

            l_date_start = New Date(l_year, l_month, l_date)

            If l_date_start.Date > l_date_now.Date Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function mdlSyncDeliveries_CheckEndTime(ByVal i_date As String) As Boolean
        Dim l_date_end As Date
        Dim l_date_now As Date

        Dim l_date, _
            l_month, _
            l_year As String

        If i_date = String.Empty Then
            Return True
        End If

        Try
            l_date_now = Date.Now
            l_date = i_date.Substring(i_date.Length - 2, 2)
            l_month = i_date.Substring(i_date.Length - 4, 2)
            l_year = i_date.Substring(0, 4)

            If Convert.ToInt32(l_date) = 0 Or _
               Convert.ToInt32(l_month) = 0 Or _
               Convert.ToInt32(l_year) = 0 Then
                Return True
                'Return False
            End If

            l_date_end = New Date(l_year, l_month, l_date)

            If l_date_end.Date < l_date_now.Date Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function



    Private Function FPT_GetMaLenh() As String
        Dim p_ValueTmp As String = "0000"
        Dim p_SQL As String = ""
        Dim p_Value As Integer = 0
        Dim p_DataTable As DataTable
        Dim p_SYS_MALENH_S As String
        Try
            If p_SYS_MALENH_S.ToString.Trim = "" Then
                p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG where KEYCODE='SYS_MALENH_S'"
                p_DataTable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        p_SYS_MALENH_S = p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim

                    End If
                End If
            End If

            p_DataTable = Nothing
            FPT_GetMaLenh = "0000"
            p_SQL = "exec FPT_Get_SYS_MALENH_S"
            p_DataTable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_Value = p_DataTable.Rows(0).Item(0)
                End If
            End If
            If p_Value > 0 Then
                If Len(p_Value.ToString.Trim) < 4 Then
                    FPT_GetMaLenh = Mid(p_ValueTmp, 1, Len(FPT_GetMaLenh.ToString.Trim) - Len(p_Value.ToString.Trim) - Len(p_SYS_MALENH_S)) & p_Value.ToString.Trim
                    If Len(FPT_GetMaLenh) = 3 Then
                        FPT_GetMaLenh = p_SYS_MALENH_S & FPT_GetMaLenh
                    End If
                Else
                    FPT_GetMaLenh = p_Value.ToString.Trim
                End If
            End If
        Catch ex As Exception
            FPT_GetMaLenh = "0000"
        End Try

    End Function


    Private Function UpdateQci(ByRef err As String, ByVal i_solenh As String, ByVal i_mangan As String, ByVal i_lineid As String, _
                                        ByVal i_L As Decimal, ByVal i_L15 As Decimal, ByVal i_M15 As Decimal, ByVal i_KG As Decimal) As Boolean

        Dim p_SQL As String = ""
        p_SQL = "UPDATE [tblQci] SET  [L] = " & i_L & ", [KG] =" & i_KG & ",  [L15] = " & i_L15 & ", [M15] = " & i_M15 & " " & _
                    " WHERE    [SoLenh]= '" & i_solenh & "' and    [LineId]= '" & i_lineid & "' and    [MaNgan]= '" & i_mangan & "'"
        If Sys_Execute1(p_SQL, p_SQL) = False Then

        End If

    End Function

    Private Function InsertQci(ByRef err As String, _
                              ByVal i_malenh As String, _
                              ByVal i_ngayxuat As Date, _
                              ByVal i_lineid As String, _
                              ByVal i_solenh As String, _
                              ByVal i_mangan As String, _
                              ByVal i_L As Decimal, _
                              ByVal i_L15 As Decimal, _
                              ByVal i_M15 As Decimal, _
                              ByVal i_KG As Decimal) As Boolean

        Dim p_SQL As String = ""
        p_SQL = "INSERT INTO [tblQci] ( [MaLenh], [NgayXuat],[LineId],[SoLenh],[MaNgan],[L],[KG],[L15],[M15]) "
        p_SQL = p_SQL & " VALUES('" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & i_lineid & "'" & _
                ",'" & i_solenh & "','" & i_mangan & "'," & i_L & "," & i_KG & "," & i_L15 & "," & i_M15 & ")"

        If Sys_Execute1(p_SQL, p_SQL) = False Then

        End If
    End Function


    Private Function GetTableID() As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable

        p_SQL = " exec " & p_FunctionTableId
        GetTableID = ""
        Try
            p_DataTable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTableID = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
        Catch ex As Exception
            GetTableID = ""
        End Try

    End Function


    Private Function mdlSyncDeliveries_CheckMaLenh(ByVal i_malenh As String, ByVal i_ngayxuat As String) As Boolean
        '-----------------------------------------------------------------
        '   Kiểm tra mã lệnh sau khi tính toán
        '-----------------------------------------------------------------
        Dim l_malenh As String
        Dim l_malenh_check As Char()
        Dim l_check As String
        Dim l_err As String = String.Empty

        l_malenh = i_malenh

        If l_malenh = String.Empty Then
            Return False
        End If

        Try
            Convert.ToInt32(l_malenh)

            l_malenh_check = l_malenh.ToCharArray()
            For i As Integer = 0 To l_malenh_check.Length - 1

                If l_malenh_check(i).ToString().Trim() = "." Then
                    Return False
                End If
            Next
            '-----------------------------------------------------------------
            '   Kiểm tra có trong db chưa
            '-----------------------------------------------------------------
            'Dim l_bs As BSTransaction_new
            'l_bs = New BSTransaction_new

            l_check = CheckMaLenh(l_err, i_malenh, i_ngayxuat)

            If l_check.Trim = "1" Then
                Return False
            End If

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Function CheckMaLenh(ByRef err As String, ByVal i_malenh As String, ByVal i_ngay As Date) As String

        Dim p_DataTable As DataTable
        Dim p_SQL As String
        Try
            CheckMaLenh = ""
            p_SQL = "select DBO.FPT_CheckMaLenh_E5('" & i_malenh & "','" & i_ngay & "') as MaLenh "
            '_c2SQL = New Connect2SQL.Connect2SQL(_SQLConnectionString)
            'Return _c2SQL.getDataValue("select DBO.fm_CheckMaLenh_KV2E5('" & i_malenh & "','" & i_ngay & "')")
            p_DataTable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    CheckMaLenh = p_DataTable.Rows(0).Item("MaLenh").ToString.Trim
                End If
            End If
            ' Return _c2SQL.getDataValue("exec CheckMaLenh_KV2E5('" & i_malenh & "','" & i_ngay & "')")

        Catch ex As Exception
            Return "1"
            err = ex.Message
        End Try
    End Function


    Private Function Check_SoLenh(ByRef err As String, ByVal i_SoLenh As String) As Boolean
        Dim p_DataTable As DataTable
        Dim p_Err As String
        Check_SoLenh = False
        'Return g_c2SQL.ExeNonQuery("sp_Check_SoLenhE5", err, New SqlParameter("@SoLenh", i_SoLenh))
        p_DataTable = p_SYS_GET_DATATABLE_Des("exec sp_Check_SoLenhE5 '" & i_SoLenh & "'", err)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Check_SoLenh = True
            End If
        End If
    End Function
#End Region
    '==========================================================================================================

    Public Sub GetPathFileFox_DB(ByRef p_FoxOut As String, ByRef p_FoxIn As String, ByRef p_FoxTemp As String)
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_DataArr() As DataRow
        'Dim p_Wcf As Boolean = False

        p_SQL = "SELECT * FROM SYS_CONFIG"
        p_Table = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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


    Public Sub GetPathFileFox_XML(ByRef p_FoxOut As String, ByRef p_FoxIn As String, ByRef p_FoxTemp As String, ByVal g_LoaiVanChuyen As String)
        Dim p_SQL As String
        Dim p_Table As New DataTable
        Dim p_DAtaSet As New DataSet
        Dim p_DataArr() As DataRow
        Dim p_PathXML As String
        On Error Resume Next

        p_PathXML = Windows.Forms.Application.StartupPath & "\Config.xml"
        If Dir(p_PathXML) <> "" Then
            p_DAtaSet.ReadXml(p_PathXML)

            p_FoxOut = ""
            p_FoxIn = ""
            p_FoxTemp = ""
            If Not p_DAtaSet Is Nothing Then
                If p_DAtaSet.Tables.Count > 0 Then
                    p_Table = p_DAtaSet.Tables(0)
                End If
            End If
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then

                    Select Case UCase(g_LoaiVanChuyen)
                        Case "THUY"
                            p_FoxIn = p_Table.Rows(0).Item("FOXIN_THUY").ToString.Trim


                            p_FoxOut = p_Table.Rows(0).Item("FOXOUT_THUY").ToString.Trim



                            p_FoxTemp = p_Table.Rows(0).Item("FOXTEMP_THUY").ToString.Trim
                        Case "BO"
                            p_FoxIn = p_Table.Rows(0).Item("FOXIN").ToString.Trim


                            p_FoxOut = p_Table.Rows(0).Item("FOXOUT").ToString.Trim



                            p_FoxTemp = p_Table.Rows(0).Item("FOXTEMP").ToString.Trim
                        Case "SAT"
                            p_FoxIn = p_Table.Rows(0).Item("FOXIN_WAGON").ToString.Trim


                            p_FoxOut = p_Table.Rows(0).Item("FOXOUT_WAGON").ToString.Trim



                            p_FoxTemp = p_Table.Rows(0).Item("FOXTEMP_WAGON").ToString.Trim
                    End Select


                End If
            End If
        End If
    End Sub




     

    Public Function MakeFileScadar1(ByVal p_Teminal As String, ByRef p_Error As String) As Boolean
        Dim p_SQL As String
        Dim p_Datatable As DataTable
        Dim p_FilePathOut As String = ""
        Dim p_FilePathIn As String = ""
        Dim p_FilePathTemp As String = ""
        Dim p_FileName As String = ""
        Dim p_FileName_Thuy As String = ""
        Dim p_FileType As String = ""
        Dim p_TableSysConfig As DataTable
        Dim p_DataArr() As DataRow





        MakeFileScadar1 = True
        Try
            p_SQL = "SELECT * FROM tblConfig"
            p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If p_Datatable.Rows.Count > 0 Then
                If UCase(p_Datatable.Rows(0).Item("optional").ToString.Trim) <> "FOX" Then
                    Exit Function
                End If
            End If

            p_SQL = "SELECT * FROM SYS_CONFIG"
            p_TableSysConfig = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If p_TableSysConfig.Rows.Count > 0 Then
                p_DataArr = p_TableSysConfig.Select("KEYCODE='TYPEFOXNAME'")
                If p_DataArr.Length > 0 Then
                    p_FileType = p_DataArr(0).Item("KEYVALUE").ToString.Trim
                End If
            End If

            p_SQL = "select * from tblMap_cp where Client='" & p_Teminal & "' and (Status='out' or Status='OUT'  )"
            p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_Datatable Is Nothing Then
                If p_Datatable.Rows.Count > 0 Then
                    p_FileName = p_Datatable.Rows(0).Item("TableName").ToString.Trim
                    If p_FileName = "[SPACE]" Or p_FileName = "SPACE" Then
                        p_FileName = ""
                    Else
                        p_FileName = p_Datatable.Rows(0).Item("TableName").ToString.Trim
                    End If
                    p_FileName_Thuy = p_Datatable.Rows(0).Item("TableName_Thuy").ToString.Trim
                    If p_FileName_Thuy = "[SPACE]" Or p_FileName = "SPACE" Then
                        p_FileName_Thuy = ""
                    Else
                        p_FileName_Thuy = p_Datatable.Rows(0).Item("TableName").ToString.Trim
                    End If
                End If
            End If

            p_SQL = "exec FPT_Get_FileName_Fox '" & UCase(p_FileType) & "'"
            p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_Datatable Is Nothing Then
                If p_Datatable.Rows.Count > 0 Then
                    p_FileName = p_FileName & p_Datatable.Rows(0).Item(0).ToString.Trim & ".dbf"
                    p_FileName_Thuy = p_FileName_Thuy & p_Datatable.Rows(0).Item(0).ToString.Trim & ".dbf"
                End If
            End If

            If g_Wcf = True Then
                GetPathFileFox_DB(p_FilePathOut, p_FilePathIn, p_FilePathTemp)
            End If
            If p_FilePathOut = "" Or p_FilePathIn = "" Or p_FilePathTemp = " Then" Then
                GetPathFileFox_XML(p_FilePathOut, p_FilePathIn, p_FilePathTemp, "BO")
            End If

            'p_SQL = "select * from SYS_FOXCONFIG"
            'p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            'If Not p_Datatable Is Nothing Then
            '    If p_Datatable.Rows.Count > 0 Then
            '  p_FilePathTemp = p_Datatable.Rows(0).Item("FilePathTemp").ToString.Trim
            If CheckFileName(True, p_FilePathTemp, p_Error) = False Then
                p_Error = "Không xác định được file temp"
                MakeFileScadar1 = False
                Exit Function
            End If

            p_FilePathOut = p_FilePathOut & "\" & p_FileName
            If CheckFileName(True, p_FilePathOut, p_Error) = False Then
                ' p_Error = "Không xác định được file Scadar"
                ' MakeFileScadar = False
                FileCopy(p_FilePathTemp, p_FilePathOut)
            End If

            If UCase(p_FileName) <> UCase(p_FileName_Thuy) Then
                p_FilePathOut = p_FilePathOut & "\" & p_FileName_Thuy
                If CheckFileName(True, p_FilePathOut, p_Error) = False Then
                    ' p_Error = "Không xác định được file Scadar"
                    ' MakeFileScadar = False
                    Try
                        FileCopy(p_FilePathTemp, p_FilePathOut)
                    Catch ex As Exception

                    End Try

                End If
            End If

            MakeFileScadar1_Thuy(p_Teminal, p_Error)
            MakeFileScadar1_Wagon(p_Teminal, p_Error)
            '    End If
            'End If
        Catch ex As Exception
            p_Error = ex.Message
            MakeFileScadar1 = False
        End Try
    End Function




    Public Function MakeFileScadar1_Thuy(ByVal p_Teminal As String, ByRef p_Error As String) As Boolean
        Dim p_SQL As String
        Dim p_Datatable As DataTable
        Dim p_FilePathOut As String = ""
        Dim p_FilePathIn As String = ""
        Dim p_FilePathTemp As String = ""
        Dim p_FileName As String = ""
        Dim p_FileName_Thuy As String = ""
        Dim p_FileType As String = ""
        Dim p_TableSysConfig As DataTable
        Dim p_DataArr() As DataRow





        MakeFileScadar1_Thuy = True
        Try
            p_SQL = "SELECT * FROM tblConfig"
            p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If p_Datatable.Rows.Count > 0 Then
                If UCase(p_Datatable.Rows(0).Item("optional").ToString.Trim) <> "FOX" Then
                    Exit Function
                End If
            End If

            p_SQL = "SELECT * FROM SYS_CONFIG"
            p_TableSysConfig = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If p_TableSysConfig.Rows.Count > 0 Then
                p_DataArr = p_TableSysConfig.Select("KEYCODE='TYPEFOXNAME'")
                If p_DataArr.Length > 0 Then
                    p_FileType = p_DataArr(0).Item("KEYVALUE").ToString.Trim
                End If
            End If

            p_SQL = "select * from tblMap_cp where Client='" & p_Teminal & "' and (Status='out' or Status='OUT'  )"
            p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_Datatable Is Nothing Then
                If p_Datatable.Rows.Count > 0 Then
                    p_FileName = p_Datatable.Rows(0).Item("TableName").ToString.Trim
                    If p_FileName = "[SPACE]" Or p_FileName = "SPACE" Then
                        p_FileName = ""
                    Else
                        p_FileName = p_Datatable.Rows(0).Item("TableName").ToString.Trim
                    End If
                    p_FileName_Thuy = p_Datatable.Rows(0).Item("TableName_Thuy").ToString.Trim
                    If p_FileName_Thuy = "[SPACE]" Or p_FileName = "SPACE" Then
                        p_FileName_Thuy = ""
                    Else
                        p_FileName_Thuy = p_Datatable.Rows(0).Item("TableName").ToString.Trim
                    End If
                End If
            End If

            p_SQL = "exec FPT_Get_FileName_Fox '" & UCase(p_FileType) & "'"
            p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_Datatable Is Nothing Then
                If p_Datatable.Rows.Count > 0 Then
                    p_FileName = p_FileName & p_Datatable.Rows(0).Item(0).ToString.Trim & ".dbf"
                    p_FileName_Thuy = p_FileName_Thuy & p_Datatable.Rows(0).Item(0).ToString.Trim & ".dbf"
                End If
            End If

            If g_Wcf = True Then
                GetPathFileFox_DB(p_FilePathOut, p_FilePathIn, p_FilePathTemp)
            End If
            If p_FilePathOut = "" Or p_FilePathIn = "" Or p_FilePathTemp = " Then" Then
                GetPathFileFox_XML(p_FilePathOut, p_FilePathIn, p_FilePathTemp, "THUY")
            End If

            'p_SQL = "select * from SYS_FOXCONFIG"
            'p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            'If Not p_Datatable Is Nothing Then
            '    If p_Datatable.Rows.Count > 0 Then
            '  p_FilePathTemp = p_Datatable.Rows(0).Item("FilePathTemp").ToString.Trim
            If CheckFileName(True, p_FilePathTemp, p_Error) = False Then
                p_Error = "Không xác định được file temp"
                MakeFileScadar1_Thuy = False
                Exit Function
            End If

            p_FilePathOut = p_FilePathOut & "\" & p_FileName
            If CheckFileName(True, p_FilePathOut, p_Error) = False Then
                ' p_Error = "Không xác định được file Scadar"
                ' MakeFileScadar = False
                FileCopy(p_FilePathTemp, p_FilePathOut)
            End If

            If UCase(p_FileName) <> UCase(p_FileName_Thuy) Then
                p_FilePathOut = p_FilePathOut & "\" & p_FileName_Thuy
                If CheckFileName(True, p_FilePathOut, p_Error) = False Then
                    ' p_Error = "Không xác định được file Scadar"
                    ' MakeFileScadar = False
                    Try
                        FileCopy(p_FilePathTemp, p_FilePathOut)
                    Catch ex As Exception

                    End Try

                End If
            End If

            '    End If
            'End If
        Catch ex As Exception
            p_Error = ex.Message
            MakeFileScadar1_Thuy = False
        End Try
    End Function




    Public Function MakeFileScadar1_Wagon(ByVal p_Teminal As String, ByRef p_Error As String) As Boolean
        Dim p_SQL As String
        Dim p_Datatable As DataTable
        Dim p_FilePathOut As String = ""
        Dim p_FilePathIn As String = ""
        Dim p_FilePathTemp As String = ""
        Dim p_FileName As String = ""
        Dim p_FileName_Thuy As String = ""
        Dim p_FileType As String = ""
        Dim p_TableSysConfig As DataTable
        Dim p_DataArr() As DataRow





        MakeFileScadar1_Wagon = True
        Try
            p_SQL = "SELECT * FROM tblConfig"
            p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If p_Datatable.Rows.Count > 0 Then
                If UCase(p_Datatable.Rows(0).Item("optional").ToString.Trim) <> "FOX" Then
                    Exit Function
                End If
            End If

            p_SQL = "SELECT * FROM SYS_CONFIG"
            p_TableSysConfig = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If p_TableSysConfig.Rows.Count > 0 Then
                p_DataArr = p_TableSysConfig.Select("KEYCODE='TYPEFOXNAME'")
                If p_DataArr.Length > 0 Then
                    p_FileType = p_DataArr(0).Item("KEYVALUE").ToString.Trim
                End If
            End If

            p_SQL = "select * from tblMap_cp where Client='" & p_Teminal & "' and (Status='out' or Status='OUT'  )"
            p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_Datatable Is Nothing Then
                If p_Datatable.Rows.Count > 0 Then
                    p_FileName = p_Datatable.Rows(0).Item("TableName").ToString.Trim
                    If p_FileName = "[SPACE]" Or p_FileName = "SPACE" Then
                        p_FileName = ""
                    Else
                        p_FileName = p_Datatable.Rows(0).Item("TableName").ToString.Trim
                    End If
                    p_FileName_Thuy = p_Datatable.Rows(0).Item("TableName_Thuy").ToString.Trim
                    If p_FileName_Thuy = "[SPACE]" Or p_FileName = "SPACE" Then
                        p_FileName_Thuy = ""
                    Else
                        p_FileName_Thuy = p_Datatable.Rows(0).Item("TableName").ToString.Trim
                    End If
                End If
            End If

            p_SQL = "exec FPT_Get_FileName_Fox '" & UCase(p_FileType) & "'"
            p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_Datatable Is Nothing Then
                If p_Datatable.Rows.Count > 0 Then
                    p_FileName = p_FileName & p_Datatable.Rows(0).Item(0).ToString.Trim & ".dbf"
                    p_FileName_Thuy = p_FileName_Thuy & p_Datatable.Rows(0).Item(0).ToString.Trim & ".dbf"
                End If
            End If

            If g_Wcf = True Then
                GetPathFileFox_DB(p_FilePathOut, p_FilePathIn, p_FilePathTemp)
            End If
            If p_FilePathOut = "" Or p_FilePathIn = "" Or p_FilePathTemp = " Then" Then
                GetPathFileFox_XML(p_FilePathOut, p_FilePathIn, p_FilePathTemp, "SAT")
            End If

            'p_SQL = "select * from SYS_FOXCONFIG"
            'p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            'If Not p_Datatable Is Nothing Then
            '    If p_Datatable.Rows.Count > 0 Then
            '  p_FilePathTemp = p_Datatable.Rows(0).Item("FilePathTemp").ToString.Trim
            If CheckFileName(True, p_FilePathTemp, p_Error) = False Then
                p_Error = "Không xác định được file temp wagon"
                MakeFileScadar1_Wagon = False
                Exit Function
            End If

            p_FilePathOut = p_FilePathOut & "\" & p_FileName
            If CheckFileName(True, p_FilePathOut, p_Error) = False Then
                ' p_Error = "Không xác định được file Scadar"
                ' MakeFileScadar = False
                FileCopy(p_FilePathTemp, p_FilePathOut)
            End If

            If UCase(p_FileName) <> UCase(p_FileName_Thuy) Then
                p_FilePathOut = p_FilePathOut & "\" & p_FileName_Thuy
                If CheckFileName(True, p_FilePathOut, p_Error) = False Then
                    ' p_Error = "Không xác định được file Scadar"
                    ' MakeFileScadar = False
                    Try
                        FileCopy(p_FilePathTemp, p_FilePathOut)
                    Catch ex As Exception

                    End Try

                End If
            End If

            '    End If
            'End If
        Catch ex As Exception
            p_Error = ex.Message
            MakeFileScadar1_Wagon = False
        End Try
    End Function


    Private Function CheckFileName(ByVal p_CheckFile As Boolean, ByVal p_PathFile As String, ByRef p_Err As String) As Boolean
        CheckFileName = False
        p_Err = ""
        CheckFileName = False
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


    'Public Function BuildBarcode147(ByVal p_String As String) As String
    '    Try
    '        Dim l_pdf As PDF417Lib.PDF
    '        BuildBarcode147 = p_String
    '        If p_String = "" Then
    '            Exit Function
    '        End If
    '        l_pdf = New PDF417Lib.PDF()
    '        l_pdf.FontEncode(p_String, 0, 0, 0, 0, 0, 0, BuildBarcode147)
    '    Catch ex As Exception
    '        BuildBarcode147 = p_String
    '    End Try

    'End Function


End Module
