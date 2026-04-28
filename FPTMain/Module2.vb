Imports System.Data.OleDb

Imports System.Data.OracleClient
Imports System.Data
Imports System.Xml
Imports System.Security.Cryptography
Imports System.IO
Imports System.Web
Imports System.Windows.Forms

Module Module2
    ' NOTE: You can use the "Rename" command on the context menu to change the class name "Service" in code, svc and config file together.


    Public Const g_ORAHOST_Key As String = "ORAHOST"
    Public Const g_ORAPORT_Key As String = "ORAPORT"
    Public Const g_SERVERNAME_Key As String = "SERVERNAME"
    Public Const g_ORAUSER_Key As String = "ORAUSER"
    Public Const g_ORAPASS_Key As String = "ORAPASS"

    Public g_ORAHOST As String
    Public g_ORAPORT As String
    Public g_SERVERNAME As String
    Public g_ORAUSER As String
    Public g_ORAPASS As String
    Public g_DBTYPE As String


    Public g_Company_Host As String
    Public g_Company_DB_Name As String

    Public g_Server As String
    Public gg_UserName As String
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
    Public Const g_DBTYPE_Key As String = "DBTYPE"

   


    Function ModReadFile(ByVal FilePath As String, ByVal Position As Long, ByVal Count As Long, ByRef Exception As String) As Byte()
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

    
    Public Function GetData(ByVal value As Integer) As String
        Return String.Format("You entered: {0}", value)
    End Function






    Public Function GetDataTable(ByVal sql As String) As DataTable
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
    Public Function SysLogin(ByVal g_IP_Address As String, _
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
        SysLogin = p_Status
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
                    gg_UserName & ";Password=" & g_Password & ";Initial Catalog=" & g_DB_Name & ";Connect Timeout=300"
            Else
                p_ConStr = "Provider=SQLOLEDB;Server=" & g_Server & "," & g_DBPortInstance & ";" & _
                        "Database=" & g_DB_Name & ";User ID=" & gg_UserName & ";Password=" & g_Password & ";" & _
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
                            gg_UserName = g_Config_XMLDatatable.Rows(0).Item(g_KEY_USER).ToString.Trim  '   xml.GetAttribute(g_KEY_USER)
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

    

    ''ANHQH
    ''24/11/2011
    ''Ham lay thong tin ket noi may chu tren Register
    'Private Sub SysGetStrConnect()
    '    Dim p_Path As String

    '    Try
    '        p_Path = Windows.Forms.Application.StartupPath & "\Config.xml"
    '        '  p_Path = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath & "\B1Config.xml"
    '        Dim xml As XmlTextReader
    '        xml = New XmlTextReader(p_Path)
    '        xml.WhitespaceHandling = WhitespaceHandling.None
    '        While Not xml.EOF
    '            xml.Read()
    '            If Not xml.IsStartElement() Then
    '                Exit While
    '            End If
    '            If xml.HasAttributes Then
    '                g_DB_Name = xml.GetAttribute(g_KEY_DB_NAME)
    '                g_Server = xml.GetAttribute(g_KEY_SERVER)
    '                g_UserName = xml.GetAttribute(g_KEY_USER)
    '                'g_UserName = "fes_AnhQH"
    '                g_Password = xml.GetAttribute(g_KEY_PASS)
    '                'g_Password = "AnhQH@FES12345"
    '                g_DBPortInstance = xml.GetAttribute(g_KEY_PORT)



    '                g_ORAHOST = xml.GetAttribute(g_ORAHOST_Key)
    '                g_ORAPORT = xml.GetAttribute(g_ORAPORT_Key)
    '                g_SERVERNAME = xml.GetAttribute(g_SERVERNAME_Key)
    '                g_ORAUSER = xml.GetAttribute(g_ORAUSER_Key)
    '                g_ORAPASS = xml.GetAttribute(g_ORAPASS_Key)
    '                'p_Service = xml.GetAttribute(g_Service)

    '                ' p_TopHour = xml.GetAttribute(g_HOUR)s
    '                'p_TopMunite = xml.GetAttribute(g_MINUTE)
    '            End If
    '        End While
    '        'close the reader
    '        xml.Close()
    '    Catch ex As Exception

    '    End Try
    'End Sub


    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataTable
    Public Function mod_SYS_GET_DATATABLE(ByVal p_SQL As String) As DataTable
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
            Return p_DataSet.Tables(0)


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
    Public Function p_SYS_GET_DATATABLE_Des(ByVal p_SQL As String, _
                                                ByRef p_DesErr As String) As DataTable 

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
            Olecon.Close()
            Olecon = Nothing
            'mod_SYS_GET_DATATABLE = p_DataTable
            Return p_DataSet.Tables(0)


        Catch ex As Exception
            p_DesErr = ex.Message
            p_DataTable = Nothing
            p_Status = False
            Return Nothing
        End Try

    End Function




    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL trong DataSet

    Public Function SysExecuteDataSet(ByVal p_DataSet1 As DataSet, ByRef p_Desc As String) As Boolean 
        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter

        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction

        SysExecuteDataSet = True

        Oleconnection = Sys_SQL_Connection()
        If Oleconnection.State <> ConnectionState.Open Then
            SysExecuteDataSet = False
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
            SysExecuteDataSet = False
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

    Public Function SysExecuteDataSetTransaction(ByVal p_DataTable As DataSet, ByRef p_Desc As String) As Boolean
        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter

        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction

        SysExecuteDataSetTransaction = True

        Oleconnection = Sys_SQL_Connection()
        If Oleconnection.State <> ConnectionState.Open Then
            SysExecuteDataSetTransaction = False
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
            SysExecuteDataSetTransaction = False
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

    Public Function Sys_Execute_DataTable(ByVal p_DataTable As DataTable, _
                                          ByRef p_Desc As String) As Boolean

        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter


        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction


        Sys_Execute_DataTable = True
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
            Oleconnection.Close()

        Catch
            p_Oletransaction.Rollback()
            p_Desc = Err.Description
            Sys_Execute_DataTable = False

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
            p_Oletransaction = Nothing
        Catch ex As Exception
            p_Oletransaction.Rollback()
            p_Oletransaction = Nothing
            p_Desc = Err.Number & "-Line " & p_Count + 1 & ":" & ex.Message
            Sys_Execute_DataTbl = False

        End Try

    End Function




    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL 

    Public Function SysExecuteSqlArray(ByVal p_SQLArray() As String, ByRef p_Desc As String) As Boolean 
        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter


        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        Dim p_Oletransaction As OleDbTransaction


        SysExecuteSqlArray = True
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
            SysExecuteSqlArray = False

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
            Oleconnection.Close()

        Catch
            p_Oletransaction.Rollback()
            p_Desc = Err.Description
            Sys_Execute_DataTableNew = False

        End Try

    End Function

    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL theo Company

    Public Function Sys_Execute_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_SQL As String, _
                                              ByRef p_Desc As String) As Boolean

        'Dim p_Count As Integer
        'Dim p_int As Integer



        Dim Oleconnection As OleDbConnection
        Dim Olecommand As OleDbCommand
        'Dim p_Oletransaction As OleDbTransaction


        Sys_Execute_Com = True
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

        Catch ex As Exception
            p_Desc = ex.Message
            Sys_Execute_Com = False
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


        Dim Oleconnection As OleDbConnection
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


    Public Function SysGetBidingSource(ByVal p_Module As String) As DataSet
        Dim p_SQL As String
        p_SQL = "SELECT [FORM_NAME], [VIEW_NAME],[TABLE_NAME], BIDINGNAVIGATOR FROM [BIDINGSOURCE] WHERE MODULE='" & p_Module & "' ORDER BY ID"
        SysGetBidingSource = mod_SYS_GET_DATASET(p_SQL)
    End Function

    Public Function SysGetTrueGridSource(ByVal p_Module As String) As DataSet
        Dim p_SQL As String
        p_SQL = "SELECT ID,MODULE,upper(FORM_NAME) as FORM_NAME,upper(GRID_NAME) as GRID_NAME,COL_NAME,ORDER_BY,ENABLE_FLAG,VISIBLE_FLAG" & _
                ",WIDTH,CAPTION,DATA_TYPE, Decimals, Digit,CheckBox, Required " & _
                " ,CFL,CFLSQL,CFLReturn1,CFLReturn2,CFLReturn3,CFLReturn4" & _
                ",ComboBox,ComboBoxSQL, CFLKeyField, DropDownRow, ShowLoadCFL, ColumnSum, AllowUpdate, ComboShowHeader ,DefaultButtonClick " & _
                "FROM GRID_PROPERTY WHERE MODULE='" & p_Module & "' ORDER BY MODULE, FORM_NAME, ORDER_BY"
        SysGetTrueGridSource = mod_SYS_GET_DATASET(p_SQL)
    End Function

    Public Function SysGetTrueGridSourceForm(ByVal p_Module As String, ByVal p_FormName As String) As DataSet
        Dim p_SQL As String
        p_SQL = "SELECT ID,MODULE,upper(FORM_NAME) as FORM_NAME,upper(GRID_NAME) as GRID_NAME,COL_NAME,ORDER_BY,ENABLE_FLAG,VISIBLE_FLAG" & _
                ",WIDTH,CAPTION,DATA_TYPE, Decimals, Digit,CheckBox, Required " & _
                " ,CFL,CFLSQL,CFLReturn1,CFLReturn2,CFLReturn3,CFLReturn4" & _
                ",ComboBox,ComboBoxSQL, CFLKeyField, DropDownRow, ShowLoadCFL , ColumnSum, AllowUpdate, ComboShowHeader, DefaultButtonClick " & _
                "FROM GRID_PROPERTY WHERE MODULE='" & p_Module & "' and upper(FORM_NAME) ='" & UCase(p_FormName) & "' ORDER BY MODULE, FORM_NAME, ORDER_BY"
        SysGetTrueGridSourceForm = mod_SYS_GET_DATASET(p_SQL)
    End Function

    'ANHQH
    '29/11/2011
    'Ham thuc hien lay danh sach menu va Submenu
    'Public Function Sys_Get_Menu_Submenu(ByVal p_User As Double, ByRef p_MenuSet As DataSet, ByRef p_SubmenuSet As DataSet) As Boolean
    '    Dim p_SQLMnu As String
    '    Dim p_DataTemp As New DataSet
    '    Dim p_dataTable As New DataTable
    '    Dim p_Row As DataRow
    '    Dim p_Col1 As DataColumn

    '    Dim p_SQLSubMnu As String
    '    Dim p_Index As Integer
    '    Dim p_Index_Submenu As Integer
    '    Sys_Get_Menu_Submenu = True


    '    Try
    '        'If p_User = 0 Then
    '        'p_SQLMnu = "SELECT UNIQUE A3.MENU_ID, A3.MENU_NAME, A3.DESCRIPTION " & _
    '        '        "FROM SYS_USER A1, SYS_RESPONSIBILITY_MENU A2, SYS_MENU A3 " & _
    '        '        " WHERE(A1.USER_ID = A2.USER_ID) AND A2.MENU_ID = A3.MENU_ID AND A1.USER_ID =" & p_User & _
    '        '            "AND SYSDATE BETWEEN NVL(A2.FROM_DATE, SYSDATE) AND NVL(A2.TO_DATE, SYSDATE) " & _
    '        '                "ORDER BY A3.MENU_ID "

    '        p_SQLMnu = "select A.menu_id, B.menu_name,B.description, B.Menu_Code " & _
    '                    "from sys_user_responds A,sys_menu B " & _
    '                    "where(a.menu_id = b.menu_id And USER_ID IN (select USER_ID from  SYS_USER where USER_ID= " & p_User & ")) " & _
    '                    " AND CONVERT (date, GETDATE ()) BETWEEN ISNULL(A.FROM_DATE,CONVERT (date, GETDATE ())) AND ISNULL(A.TO_DATE,CONVERT (date, GETDATE ()))" & _
    '                    "order by  OrderBy"

    '        p_MenuSet = mod_SYS_GET_DATASET(p_SQLMnu)
    '        For p_Index = 0 To p_MenuSet.Tables(0).Rows.Count - 1
    '            'p_SQLSubMnu = "SELECT SUB_MENU_ID,SUB_MENU_NAME,DESCRIPTION , form_name,MODULE_CODE FROM SYS_SUB_MENU " & _
    '            '        " WHERE MENU_ID=" & CType(p_MenuSet.Tables(0).Rows(p_Index).Item(0), Double) & _
    '            '        " AND SYSDATE BETWEEN nvl(from_date,SYSDATE) AND nvl(to_date,SYSDATE) order by SUB_MENU_ID "
    '            p_SQLSubMnu = "SELECT A2.FUNCTION_ID,A2.FUNCTION_NAME,A2.DESCRIPTION,A3.FORM_NAME,A3.PROJECT_CODE " & _
    '                    "FROM SYS_FUNCTION A2, SYS_FORMS A3,  SYS_RESPONSIBILITY_MENU A4  " & _
    '                    " WHERE(A2.FORM_ID = A3.FORM_ID) AND A4.MENU_CODE ='" & p_MenuSet.Tables(0).Rows(p_Index).Item(3).ToString & "' " & _
    '                    " AND CONVERT (date, GETDATE ()) BETWEEN ISNULL(A2.FROM_DATE,CONVERT (date, GETDATE ())) AND ISNULL(A2.TO_DATE,CONVERT (date, GETDATE ())) " & _
    '                    " AND a2.function_id=a4.function_id ORDER BY A4.ORDER_NUM"
    '            p_DataTemp = mod_SYS_GET_DATASET(p_SQLSubMnu)
    '            If p_DataTemp.Tables(0).Rows.Count > 0 Then
    '                p_dataTable = New DataTable
    '                p_Col1 = New DataColumn
    '                p_Col1.DataType = GetType(Double)
    '                p_dataTable.Columns.Add(p_Col1)
    '                p_Col1 = New DataColumn
    '                p_Col1.DataType = GetType(String)
    '                p_dataTable.Columns.Add(p_Col1)
    '                p_Col1 = New DataColumn
    '                p_Col1.DataType = GetType(String)
    '                p_dataTable.Columns.Add(p_Col1)
    '                p_Col1 = New DataColumn
    '                p_Col1.DataType = GetType(String)
    '                p_dataTable.Columns.Add(p_Col1)
    '                p_Col1 = New DataColumn
    '                p_Col1.DataType = GetType(String)
    '                p_dataTable.Columns.Add(p_Col1)
    '                p_SubmenuSet.Tables.Add(p_dataTable)
    '                For p_Index_Submenu = 0 To p_DataTemp.Tables(0).Rows.Count - 1
    '                    p_Row = p_SubmenuSet.Tables(p_Index).NewRow
    '                    p_Row(0) = CType(p_DataTemp.Tables(0).Rows(p_Index_Submenu).Item(0), Double)
    '                    p_Row(1) = CType(p_DataTemp.Tables(0).Rows(p_Index_Submenu).Item(1), String)
    '                    p_Row(2) = CType(p_DataTemp.Tables(0).Rows(p_Index_Submenu).Item(2), String)
    '                    p_Row(3) = CType(p_DataTemp.Tables(0).Rows(p_Index_Submenu).Item(3), String)
    '                    p_Row(4) = CType(p_DataTemp.Tables(0).Rows(p_Index_Submenu).Item(4), String)
    '                    p_SubmenuSet.Tables(p_Index).Rows.Add(p_Row)
    '                Next p_Index_Submenu
    '            Else
    '                p_SubmenuSet.Tables.Add(New DataTable)
    '            End If
    '        Next p_Index
    '        'End If
    '    Catch
    '        Sys_Get_Menu_Submenu = False
    '    End Try
    'End Function

    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataSet

    Public Function mod_SYS_GET_DATASET(ByVal p_SQL As String) As System.Data.DataSet
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
        'mod_SYS_GET_DATASET = p_DataTable
    End Function


    Public Function p_Exampe(ByVal p_SQL As String) As String
        Return "anhqh : " & p_SQL 'System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath
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

    Public Function mod_SYS_GET_DATASET_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
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
        ' mod_SYS_GET_DATASET_Com = p_DataTable
    End Function


    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataSet  theo so page truyen vao
    'p_Page_Total: Tong so trang
    'p_RowNum: So line/page
    'p_PageNum: page hien thoi can lay du lieu
    Public Function mod_SYS_GET_DATASET_PAGE(ByVal p_SQLTotalPage As String, _
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

            p_DataSet = mod_SYS_GET_DATASET(sSQL)
            'Lay thong tin tong so page cua du lieu
            sSQL = "select   round(count(*)/" & p_LineOfPage & ",0) from ( " & p_SQLTotalPage & " ) A"
            p_DataTable_Page = mod_SYS_GET_DATATABLE(sSQL)
            p_DataSet_Page = mod_SYS_GET_DATASET(sSQL)
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
    Public Function mod_SYS_GET_DATATABLE_PAGE_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_SQLTotalPage As String, _
                                          ByVal p_Table As String, ByVal p_FieldKey As String, _
                                          ByRef p_Page_Total As Integer, _
                                          Optional ByVal p_Where As String = "", _
                                             Optional ByVal p_RowNum As Integer = 0, _
                                             Optional ByVal p_PageNum As Integer = 1) As System.Data.DataTable 

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
    Public Function SysGetPrimary(ByVal p_TableKey As String) As Double
        Dim p_Connect As New OleDb.OleDbConnection
        Dim p_Command As New OleDb.OleDbCommand
        SysGetPrimary = 0
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

                Integer.TryParse(p_Command.Parameters("@ID").Value.ToString.Trim, SysGetPrimary)
            End If
            p_Command = Nothing
            p_Connect.Close()
            p_Connect = Nothing
        Catch ex As Exception
            SysGetPrimary = 0
        End Try
    End Function
#End Region

#Region "Check login B1"
    
#End Region

    '==============================================================================================
    '================================ORACLE==========================================
    '==============================================================================================
    'ANHQH
    '21/11/2011
    'Ham Tra ve chuoi ket noi voi CSDL
    Private Function SysGetConnect_Oracle() As String
        Dim p_ConStr As String
        SysGetStrConnect()
        p_ConStr = ""
        '  If g_ORAHOST <> "" Then


        SysGetConnect_Oracle = "Data Source=TEST;Persist Security Info=True;User ID=hcsn;Password=123456;Unicode=True"
        SysGetConnect_Oracle = "" & _
                        "Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" & _
                        "(HOST=" & g_ORAHOST & ")(PORT=" & g_ORAPORT & ")))(CONNECT_DATA=(SID=" & g_SERVERNAME & ")(SERVER=DEDICATED)));" & _
                            "User Id=" & g_ORAUSER & ";Password=" & g_ORAPASS & ";"

        ' End If

        ' SysGetConnect_Oracle = p_ConStr
    End Function


    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL trong DataTable

    Public Function Sys_Execute_DataTable_Oracle(ByVal p_DataTable As DataTable, _
                                          ByRef p_Desc As String) As Boolean

        Dim p_Count As Integer
        Dim p_int As Integer = 0

        Dim command As OracleCommand
        Dim g_Oracle_Connection As New OracleClient.OracleConnection
        Dim p_transaction As OracleTransaction = Nothing
        Dim dep_id As OracleParameter = New OracleParameter

        Try
            Sys_Execute_DataTable_Oracle = True
            Try
                g_Oracle_Connection = New OracleConnection(SysGetConnect_Oracle)
                g_Oracle_Connection.Open()

            Catch ex As Exception
                Sys_Execute_DataTable_Oracle = False
            End Try

            p_transaction = g_Oracle_Connection.BeginTransaction
            command = New OracleCommand
            With command
                .Connection = g_Oracle_Connection
                .Transaction = p_transaction
                .CommandType = CommandType.Text
                For p_Count = 0 To p_DataTable.Rows.Count - 1
                    If p_DataTable.Rows(p_Count).Item(0).ToString <> "" Then
                        .CommandText = p_DataTable.Rows(p_Count).Item(0).ToString
                        .ExecuteNonQuery()
                    End If
                Next
                '.CommandText = p_SQL
                .ExecuteNonQuery()
            End With
            p_transaction.Commit()
        Catch ex As Exception
            Sys_Execute_DataTable_Oracle = False
            ' p_Err = ex.Message
            p_transaction.Rollback()
        End Try

    End Function



    Public Function mod_SYS_GET_DATASET_Oracle(ByVal p_SQL As String) As System.Data.DataSet
        Dim g_Oracle_Connection As New OracleClient.OracleConnection
        Dim myCommand As OracleCommand ' OleDbCommand
        Dim p_Adapter As OracleDataAdapter ' OleDbDataAdapter

        Dim p_DataSet As New System.Data.DataSet
        Dim p_Int As Integer
        Try
            g_Oracle_Connection = New OracleConnection(SysGetConnect_Oracle)
            g_Oracle_Connection.Open()

        Catch ex As Exception
            Return Nothing
        End Try

        Try
            myCommand = New OracleCommand(p_SQL, g_Oracle_Connection)
            p_Adapter = New OracleDataAdapter(myCommand)
            p_Int = p_Adapter.Fill(p_DataSet)
        Catch Ex As Exception
            'SaveLog("mod_SYS_GET_DATASETOracle(" & Date.Now.ToString & ")", Ex.Message, "")
            Return Nothing
        End Try
        Return p_DataSet
    End Function

    Public Function Sys_Execute_SQL_Oracle(ByVal p_SQL As String, ByRef p_Err As String) As Boolean
        Dim command As OracleCommand
        Dim g_Oracle_Connection As New OracleClient.OracleConnection
        Dim p_transaction As OracleTransaction = Nothing
        Dim dep_id As OracleParameter = New OracleParameter

        Try
            Sys_Execute_SQL_Oracle = True
            Try
                g_Oracle_Connection = New OracleConnection(SysGetConnect_Oracle)
                g_Oracle_Connection.Open()

            Catch ex As Exception
                Sys_Execute_SQL_Oracle = False
            End Try

            p_transaction = g_Oracle_Connection.BeginTransaction
            command = New OracleCommand
            With command
                .Connection = g_Oracle_Connection
                .Transaction = p_transaction
                .CommandType = CommandType.Text
                .CommandText = p_SQL
                .ExecuteNonQuery()
            End With
            p_transaction.Commit()
        Catch ex As Exception
            Sys_Execute_SQL_Oracle = False
            p_Err = ex.Message
            p_transaction.Rollback()
        End Try

    End Function






    '==============================================================================================
    '================================ORACLE==========================================
    '==============================================================================================



    'ANHQH
    '29/11/2011
    'Ham thuc hien lay danh sach menu va Submenu
    Public Function Sys_Get_Menu_Submenu(ByVal p_User As Double, ByRef p_MenuSet As DataSet, ByRef p_SubmenuSet As DataSet) As Boolean 'sImplements IService.Sys_Get_Menu_Submenu
        Dim p_SQLMnu As String
        Dim p_DataTemp As New DataSet
        Dim p_dataTable As New DataTable
        Dim p_Row As DataRow
        Dim p_Col1 As DataColumn

        Dim p_SQLSubMnu As String
        Dim p_Index As Integer
        Dim p_Index_Submenu As Integer
        Sys_Get_Menu_Submenu = True


        Try
            'If p_User = 0 Then
            'p_SQLMnu = "SELECT UNIQUE A3.MENU_ID, A3.MENU_NAME, A3.DESCRIPTION " & _
            '        "FROM SYS_USER A1, SYS_RESPONSIBILITY_MENU A2, SYS_MENU A3 " & _
            '        " WHERE(A1.USER_ID = A2.USER_ID) AND A2.MENU_ID = A3.MENU_ID AND A1.USER_ID =" & p_User & _
            '            "AND SYSDATE BETWEEN NVL(A2.FROM_DATE, SYSDATE) AND NVL(A2.TO_DATE, SYSDATE) " & _
            '                "ORDER BY A3.MENU_ID "

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
                             "AND nvl(A.TO_DATE,to_date ( sysdate))order by  OrderBy"
                p_MenuSet = mod_SYS_GET_DATASET_Oracle(p_SQLMnu)
            ElseIf g_DBTYPE = "SQL" Then
                p_SQLMnu = "select A.menu_id, B.menu_name,B.description, B.Menu_Code " & _
                        "from sys_user_responds A,sys_menu B " & _
                        "where(a.menu_id = b.menu_id And USER_ID IN (select USER_ID from  SYS_USER where USER_ID= " & p_User & ")) " & _
                        " AND CONVERT (date, GETDATE ()) BETWEEN ISNULL(A.FROM_DATE,CONVERT (date, GETDATE ())) AND ISNULL(A.TO_DATE,CONVERT (date, GETDATE ()))" & _
                        "order by  OrderBy"

                p_MenuSet = mod_SYS_GET_DATASET(p_SQLMnu)
            End If
            
            For p_Index = 0 To p_MenuSet.Tables(0).Rows.Count - 1
                If g_DBTYPE = "ORACLE" Then
                    p_SQLSubMnu = "SELECT A2.FUNCTION_ID,A2.FUNCTION_NAME,A2.DESCRIPTION,A3.FORM_NAME,A3.PROJECT_CODE FROM SYS_FUNCTION A2, " & _
                            "SYS_FORMS A3,  SYS_RESPONSIBILITY_MENU A4   WHERE(A2.FORM_ID = A3.FORM_ID) AND A4.MENU_CODE =" & _
                            "'" & p_MenuSet.Tables(0).Rows(p_Index).Item(3).ToString & "'  AND to_date (sysdate) " & _
                                "BETWEEN nvl(A2.FROM_DATE, to_date(sysdate)) And nvl(A2.TO_DATE, to_date(sysdate)) " & _
                                "AND a2.function_id=a4.function_id ORDER BY A4.ORDER_NUM"
                    p_DataTemp = mod_SYS_GET_DATASET_Oracle(p_SQLSubMnu)
                ElseIf g_DBTYPE = "SQL" Then
                    p_SQLSubMnu = "SELECT A2.FUNCTION_ID,A2.FUNCTION_NAME,A2.DESCRIPTION,A3.FORM_NAME,A3.PROJECT_CODE " & _
                       "FROM SYS_FUNCTION A2, SYS_FORMS A3,  SYS_RESPONSIBILITY_MENU A4  " & _
                       " WHERE(A2.FORM_ID = A3.FORM_ID) AND A4.MENU_CODE ='" & p_MenuSet.Tables(0).Rows(p_Index).Item(3).ToString & "' " & _
                       " AND CONVERT (date, GETDATE ()) BETWEEN ISNULL(A2.FROM_DATE,CONVERT (date, GETDATE ())) AND ISNULL(A2.TO_DATE,CONVERT (date, GETDATE ())) " & _
                       " AND a2.function_id=a4.function_id ORDER BY A4.ORDER_NUM"
                    p_DataTemp = mod_SYS_GET_DATASET(p_SQLSubMnu)
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
        Catch
            Sys_Get_Menu_Submenu = False
        End Try
    End Function


    Public Function ModCheckConnect_Oracle(ByRef p_ConnectOracle As OracleConnection, ByRef p_ConnectStr As String) As Boolean
        Dim g_Oracle_Connection As New OracleConnection
        Dim myCommand As OracleCommand ' OleDbCommand
        Dim p_Adapter As OracleDataAdapter ' OleDbDataAdapter

        Dim p_DataSet As New System.Data.DataSet
        Dim p_Int As Integer
        Try
            ModCheckConnect_Oracle = True
            p_ConnectStr = SysGetConnect_Oracle()
            g_Oracle_Connection.ConnectionString = p_ConnectStr ' = New OracleConnection(p_ConnectStr)
            g_Oracle_Connection.Open()

            p_ConnectOracle = g_Oracle_Connection

            'Catch ex As Exception
            '    'Return Nothing
            'End Try

            'Try
            '    myCommand = New OracleCommand(p_SQL, g_Oracle_Connection)
            '    p_Adapter = New OracleDataAdapter(myCommand)
            '    p_Int = p_Adapter.Fill(p_DataSet)
        Catch Ex As Exception
            p_ConnectOracle = Nothing
            p_ConnectStr = Ex.Message
            ModCheckConnect_Oracle = False
            'SaveLog("mod_SYS_GET_DATASETOracle(" & Date.Now.ToString & ")", Ex.Message, "")
            ' Return Nothing
        End Try
        ' Return p_DataSet
    End Function


    Public Function MakeFileScadar(ByVal p_Teminal As String, ByRef p_Error As String) As Boolean
        Dim p_SQL As String
        Dim p_Datatable As DataTable
        Dim p_FilePathOut As String = ""
        Dim p_FilePathTemp As String = ""
        Dim p_FileName As String = ""
        Dim p_FileName_Thuy As String = ""
        Dim p_FileType As String = ""
        Dim p_TableSysConfig As DataTable
        Dim p_DataArr() As DataRow

        MakeFileScadar = True
        Try
            p_SQL = "SELECT * FROM tblConfig"
            p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If p_Datatable.Rows.Count > 0 Then
                If UCase(p_Datatable.Rows(0).Item("optional").ToString.Trim) <> "FOX" Then
                    Exit Function
                End If
            End If
            p_SQL = "SELECT * FROM SYS_CONFIG"
            p_TableSysConfig = g_Services.Sys_SYS_GET_DATATable_Des(p_SQL, p_SQL)
            If p_TableSysConfig.Rows.Count > 0 Then
                p_DataArr = p_TableSysConfig.Select("KEYCODE='TYPEFOXNAME'")
                If p_DataArr.Length > 0 Then
                    p_FileType = p_DataArr(0).Item("KEYVALUE").ToString.Trim
                End If
            End If

            p_SQL = "select * from tblMap_cp where Client='" & p_Teminal & "' and (Status='out' or Status='OUT'  )"
            p_Datatable = g_Services.Sys_SYS_GET_DATATable_Des(p_SQL, p_SQL)
            If Not p_Datatable Is Nothing Then
                If p_Datatable.Rows.Count > 0 Then
                    p_FileName = p_Datatable.Rows(0).Item("TableName").ToString.Trim
                    If p_FileName = "[SPACE]" Or p_FileName = "SPACE" Then
                        p_FileName = ""
                    End If
                    p_FileName_Thuy = p_Datatable.Rows(0).Item("TableName_Thuy").ToString.Trim
                    If p_FileName_Thuy = "[SPACE]" Or p_FileName = "SPACE" Then
                        p_FileName_Thuy = ""
                    End If
                End If
            End If

            p_SQL = "exec FPT_Get_FileName_Fox '" & UCase(p_FileType) & "'"
            p_Datatable = g_Services.Sys_SYS_GET_DATATable_Des(p_SQL, p_SQL)
            If Not p_Datatable Is Nothing Then
                If p_Datatable.Rows.Count > 0 Then
                    p_FileName = p_FileName & p_Datatable.Rows(0).Item(0).ToString.Trim & ".dbf"
                    p_FileName_Thuy = p_FileName_Thuy & p_Datatable.Rows(0).Item(0).ToString.Trim & ".dbf"
                End If
            End If

            p_SQL = "select * from SYS_FOXCONFIG"
            p_Datatable = g_Services.Sys_SYS_GET_DATATable_Des(p_SQL, p_SQL)
            If Not p_Datatable Is Nothing Then
                p_FilePathTemp = p_Datatable.Rows(0).Item("FilePathTemp").ToString.Trim
                If CheckFileName(True, p_FilePathTemp, p_Error) = False Then
                    p_Error = "Không xác định được file temp"
                    MakeFileScadar = False
                End If

                p_FilePathOut = p_Datatable.Rows(0).Item("FilePathOut").ToString.Trim & "\" & p_FileName
                If CheckFileName(True, p_FilePathOut, p_Error) = False Then
                    ' p_Error = "Không xác định được file Scadar"
                    ' MakeFileScadar = False
                    FileCopy(p_FilePathTemp, p_FilePathOut)
                End If

                If UCase(p_FileName) <> UCase(p_FileName_Thuy) Then
                    p_FilePathOut = p_Datatable.Rows(0).Item("FilePathOut").ToString.Trim & "\" & p_FileName_Thuy
                    If CheckFileName(True, p_FilePathOut, p_Error) = False Then
                        ' p_Error = "Không xác định được file Scadar"
                        ' MakeFileScadar = False
                        Try
                            FileCopy(p_FilePathTemp, p_FilePathOut)
                        Catch ex As Exception

                        End Try

                    End If
                End If

            End If

        Catch ex As Exception
            p_Error = ex.Message
            MakeFileScadar = False
        End Try
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





    Public Sub UpdateFile(ByVal p_DataTable As DataTable)
        '  Dim p_DataTable As DataTable
        Dim p_Count As Integer
        Dim p_Row As DataRow
        Dim p_FromFile As String
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_Err As String
        Dim p_DtbExec As New DataTable("Table0")
        Dim p_Insert As String
        Dim p_Exists As Integer = 0
        p_DtbExec.Columns.Add("STR_SQL")

        Dim p_toFilePath As String   '= p_toDirectoryFilePath & "\" & p_DataTable.Rows(p_Count).Item("FileName").ToString.Trim
        Try
            'Cursor = Cursors.WaitCursor

            p_toFilePath = Application.StartupPath

            '  p_DataTable = CType(p_Binding.DataSource, DataTable)
            For p_Count = 0 To p_DataTable.Rows.Count - 1
                p_Row = p_DataTable.Rows(p_Count)
                ' If p_Row.Item("X").ToString.Trim = "Y" Then
                p_Exists = p_Exists + 1
                p_FromFile = p_Row.Item("FilePath").ToString.Trim
                p_toFilePath = p_toFilePath & "\" & p_Row.Item("FileName").ToString.Trim
                If p_GetFile(p_FromFile, p_toFilePath, p_Err) = False Then

                    Exit Sub
                Else
                    p_Insert = "INSERT INTO [SYS_VERSION_HIST] ([FileName],[FilePath] ,[FileMajor] ,[FileMinor] ,[FileBuild] ," & _
                            "[FileRevision],[PC_Name],[PC_IP],[UpdData])"
                    p_Insert = p_Insert & " VALUES ('" & p_Row.Item("FileName").ToString.Trim & "'" & _
                                ",'" & p_Row.Item("FilePath").ToString.Trim & "'" & _
                                "," & p_Row.Item("FileMajor").ToString.Trim & "" & _
                                "," & p_Row.Item("FileMinor").ToString.Trim & "" & _
                                "," & p_Row.Item("FileBuild").ToString.Trim & "" & _
                                "," & p_Row.Item("FileRevision").ToString.Trim & "" & _
                                ",'" & UCase(g_GetHostName) & "','" & g_IP_Address & "' , getdate()" & _
                                ")"

                    p_Row = p_DtbExec.NewRow
                    p_Row.Item(0) = p_Insert
                    p_DtbExec.Rows.Add(p_Row)
                End If
                ' End If
            Next

            If p_DtbExec.Rows.Count > 0 Then
                If g_Services.Sys_Execute_DataTbl(p_DtbExec, p_Err) = False Then
                    'MsgBox(p_SQL)

                    ' MsgBox(p_Err)
                    Exit Sub
                End If
            End If


        Catch ex As Exception

            'MsgBox(ex.Message)

        End Try

    End Sub



    Public Function p_GetFile(ByVal FromFile As String, ByVal ToSaveFile As String, ByRef p_Err As String) As Boolean
        Try
            Dim p_Count As Long = 10240

            p_GetFile = True

            Using FileStream As New FileStream(ToSaveFile, FileMode.Create, FileAccess.Write)

                Dim Position As New Long
                Dim Data() As Byte

                'Data = g_Service.ModReadFile("C:\FRT\FrtUpdate\web.config", Position, 102400, p_Err)
                Data = g_Services.ModReadFile(FromFile, Position, p_Count, p_Err)

                If p_Err = "" Then
                    While Data.LongLength > 0
                        FileStream.Write(Data, 0, Data.LongLength)
                        Position += Data.LongLength
                        Data = g_Services.ModReadFile(FromFile, Position, p_Count, p_Err)
                    End While
                Else
                    p_GetFile = False
                    Exit Function

                End If
            End Using

            If p_Err = String.Empty Then
                'MessageBox.Show("Update successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            p_GetFile = False
            p_Err = ex.Message
            'MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function



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



    Public Function mdlCryptor_Encrypt(ByVal Text As String, ByVal Key As String) As String

        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(Key))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = System.Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(Text)
            encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return encrypted
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function BuildPass(ByVal p_String As String) As String
        Dim e2md5 As New Encrypt2MD5()

    End Function


    'anhqh
    '20181104
    '
    Public Sub CreateTableTank()

    End Sub


    Public Sub CreateField()
        Dim p_SQL As String
        Dim p_Error As String = ""
        Dim p_Table As DataTable

        ''20260318 bang lien quan de thoi gian kiem ke
        p_Error = ""
        p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE upper(name)= upper('tblThoiGianKiemke') AND xtype='U') " & _
             "  begin CREATE TABLE [dbo].[tblThoiGianKiemke]( " & _
                         "[ID] [int] IDENTITY(1,1) NOT NULL,[NgayGio] [datetime] NOT NULL,[GhiChu] [nvarchar](500) NULL, " & _
                         "[CREATEBY] [nvarchar](100) NULL,[CreateDate] [datetime] default getdate(), " & _
                         "[UPDATEDBY] [nvarchar](100) NULL,[UpdateDate] [datetime] NULL, " & _
                            "CONSTRAINT [PK_tblThoiGianKiemke] PRIMARY KEY CLUSTERED " & _
                            "([ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, " & _
                            "ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY] ) ON [PRIMARY]; end;"
        If g_Services.Sys_Execute(p_SQL, _
                                  p_Error) = False Then

        End If
        p_Error = ""
        p_SQL = "create view fpt_tblThoiGianKiemke_v as " & _
            "SELECT [ID],[NgayGio],[GhiChu],[CREATEBY],[CreateDate] " & _
            ",[UPDATEDBY],[UpdateDate], 'N' as CHECKUPD FROM [dbo].[tblThoiGianKiemke]"
        If g_Services.Sys_Execute(p_SQL, _
                                  p_Error) = False Then

        End If


        p_Error = "" '
        p_SQL = " if  COL_LENGTH('tblMap_MaHangHoa','ID') is null " & _
           "  begin alter table  tblMap_MaHangHoa add [ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL  " & _
               "  end;"
        If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If

         
            '
        p_SQL = " if  COL_LENGTH('tbllenhxuate5','DO_Process') is null " & _
         "  begin  alter table [dbo].[tbllenhxuate5] add DO_Process nvarchar(30) " & _
             "  end;"
        If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If


        p_SQL = " if  COL_LENGTH('SYS_USER','U_HOADON') is null " & _
          "  begin  alter table [dbo].[SYS_USER] add U_HOADON varchar(5) " & _
              "  end;"
        If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If



        p_SQL = " if  COL_LENGTH('tblSO_PO_Type','VTWEG_CHK') is null " & _
          "  begin  alter table [dbo].[tblSO_PO_Type] add VTWEG_CHK varchar(5) " & _
              "  end;"
        If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If


        p_Error = "" '
        p_SQL = " if  COL_LENGTH('tblTankActive','HS_GianNo') is null " & _
          "  begin  alter table [dbo].[tblTankActive] add HS_GianNo decimal(10,6) " & _
              "  end;"
        If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If
        p_Error = ""
        p_SQL = "CREATE view [dbo].[FPT_tblTankActiveE_V] as SELECT " & _
                    "dbo.tblTankActive.ID, dbo.tblTankActive.Date_nd, dbo.tblTankActive.Name_nd, dbo.tblTankActive.Dens_nd, dbo.tblTankActive.Product_nd, 'N' AS CHECKUPD, " & _
                    "dbo.tblHangHoa.TenHangHoa, CONVERT(date, RIGHT(dbo.tblTankActive.Date_nd, 4) + SUBSTRING(dbo.tblTankActive.Date_nd, 4, 2) " & _
                    "+ LEFT(dbo.tblTankActive.Date_nd, 2)) AS Date1, dbo.tblTankActive.LoadingSite, dbo.tblTankActive.FromDate, dbo.tblTankActive.Tank_App " & _
                    ", tblTankActive.HS_GianNo " & _
                    "FROM    dbo.tblTankActive INNER JOIN  dbo.tblHangHoa ON dbo.tblTankActive.Product_nd = dbo.tblHangHoa.MaHangHoa;"
        If g_Services.Sys_Execute(p_SQL, _
                                    p_Error) = False Then

            End If



        p_Error = "" '
        p_SQL = " if  COL_LENGTH('tblHangHoaE5','ID') is null " & _
           "  begin alter table  tblHangHoaE5 add [ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL  " & _
               "  end;"
        If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If



        p_Error = "" '
        p_SQL = "INSERT INTO SYS_CONFIG ( KeyCode, KeyValue, [DESC]) VALUES ('KHONG_TDH','N', N'Kho không có TĐH') ;"
        p_SQL = p_SQL & "INSERT INTO SYS_CONFIG ( KeyCode, KeyValue, [DESC]) VALUES ('CHIEUCAO_MD','N', N'Nhập chiều cao mức dầu thay cho CCHH') ;"
        p_SQL = p_SQL & "INSERT INTO SYS_CONFIG ( KeyCode, KeyValue, [DESC]) VALUES ('NHIETDOXE_CHXD','N', N'Cập nhật nhiệt độ xe=nhiệt độ TĐH cho lệnh không phải di chuyển cho CHXD') ;"
        If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If



        p_SQL = "MERGE INTO sys_config  AS target " & _
                        "USING (select 'API_SAP_LINK' as KeyCode , 'http://erp.petrolimex.com.vn:8001/prd/lims/plx/api/' as KeyValue, N'Link API SAP' as sDesc " & _
                          "union all select 'API_SAP_USER' as KeyCode,  'PLX_LIMS' as KeyValue, N'User API của SAP' as sDesc " & _
                          "union all select 'API_SAP_PASS' as   KeyCode, 'PLX_LIMS@!23' as KeyValue , N'Pass API' as sDesc " & _
                          "union select 'SAP_API_FLAG' as KeyCode, 'Y' as KeyValue , N'Trang thai tắt/bật' as sDesc) AS source " & _
                            "ON target.KeyCode = source.KeyCode " & _
                        "WHEN NOT MATCHED BY TARGET THEN     INSERT (KeyCode, KeyValue, [Desc] ) VALUES (source.KeyCode, source.KeyValue, source.sDesc);"
        If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If


        p_SQL = "MERGE INTO sys_config  AS target " & _
                        "USING (select 'SAP_LMS' as KeyCode , 'Y' as KeyValue, N'Đồng bộ thông tin tỷ trong trên SAP' as sDesc " & _
                         "union all select 'SAP_LMS_GNTX' as KeyCode,  'N' as KeyValue, N'Lấy tỷ trọng từ LMS SAP khi Ghi nhận thực xuất' as sDesc " & _
                          ") AS source " & _
                            "ON target.KeyCode = source.KeyCode " & _
                        "WHEN NOT MATCHED BY TARGET THEN     INSERT (KeyCode, KeyValue, [Desc] ) VALUES (source.KeyCode, source.KeyValue, source.sDesc);"
        If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If

    End Sub
    Public Sub CreateTable()
        Dim p_SQL As String
        Dim p_Error As String = ""
        Dim p_Table As DataTable
        Try
            

            ''20251104 tao cac bang THN
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblLenhXuatE5_THN_HIST' AND xtype='U') " & _
                 "  begin create table tblLenhXuatE5_THN_HIST (SoLenh nvarchar(100),sDesc nvarchar(500),CreateDate datetime default getdate(),STATUS varchar(1)); end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

            End If
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblLenhXuatE5_THN' AND xtype='U') " & _
                 "  begin CREATE TABLE [dbo].[tblLenhXuatE5_THN](	[MaLenh] [nvarchar](4) NULL,[NgayXuat] [datetime] NOT NULL,[SoLenh] [nvarchar](10) NOT NULL, " & _
                     "[MaDonVi] [nvarchar](4) NULL,[MaNguon] [nvarchar](10) NULL,[MaKho] [nvarchar](4) NULL,[MaVanChuyen] [nvarchar](10) NULL, " & _
                     "[MaPhuongTien] [nvarchar](10) NULL,[NguoiVanChuyen] [nvarchar](100) NULL,[MaPhuongThucBan] [nvarchar](2) NULL, " & _
                     "[MaPhuongThucXuat] [nvarchar](3) NULL,[MaKhachHang] [nvarchar](10) NULL,[LoaiPhieu] [nvarchar](10) NULL, " & _
                     "[Niem] [nvarchar](300) NULL,[LuongGiamDinh] [nvarchar](50) NULL,[NhietDoTaiTau] [nvarchar](5) NULL, " & _
                     "[GhiChu] [nvarchar](1000) NULL,[NgayHieuLuc] [nvarchar](10) NULL,[Status] [char](2) NULL, " & _
                     "[Number] [int] NULL,[Createby] [nvarchar](30) NULL,[UpdatedBy] [nvarchar](30) NULL,[CreateDate] [datetime] NULL, " & _
                     "[UpdateDate] [datetime] NULL,[SoLenhSAP] [nvarchar](10) NULL,[Client] [nvarchar](50) NULL,[HTTG] [nvarchar](2) NULL, " & _
                     "[Approved] [nvarchar](2) NULL,[User_Approve] [nvarchar](50) NULL,[Date_Approve] [datetime] NULL, " & _
                     "[EditApprove] [nvarchar](2) NULL,[NhaCungCap] [nvarchar](500) NULL,[AppDesc] [nvarchar](1000) NULL, " & _
                     "[AppN30] [varchar](1) NULL,[AppN30Date] [datetime] NULL,[AppN30User] [nvarchar](200) NULL, " & _
                     "[QCI_KG] [decimal](18, 2) NULL,[QCI_NhietDo] [decimal](5, 2) NULL,[Slog] [varchar](100) NULL, " & _
                     "[NgayHetHieuLuc] [datetime] NULL,[NgayTichKe] [datetime] NULL,[STO] [nvarchar](250) NULL, " & _
                     "[NguoiDaiDien] [nvarchar](250) NULL,[DonViCungCapVanTai] [nvarchar](250) NULL,[UserTichKe] [nvarchar](250) NULL, " & _
                     "[DiemTraHang] [nvarchar](500) NULL,[Tax] [decimal](3, 0) NULL,[PaymentMethod] [varchar](1) NULL, " & _
                     "[Term] [varchar](4) NULL,[MaKhoNhap] [nvarchar](4) NULL,[SoHopDong] [varchar](10) NULL,[NgayHopDong] [datetime] NULL, " & _
                     "[TyGia] [decimal](10, 2) NULL,[SoTKHQNhap] [varchar](20) NULL,[SoTKHQXuat] [varchar](20) NULL, " & _
                     "[SelfShipping] [varchar](1) NULL,[PriceGroup] [varchar](2) NULL,[Inco1] [varchar](3) NULL,[Inco2] [nvarchar](28) NULL, " & _
                     "[SoPXK] [nvarchar](150) NULL,[NgayPXK] [datetime] NULL,[MaTuyenDuong] [varchar](6) NULL, " & _
                     "[XuatHangGui] [nvarchar](500) NULL,[So_TKTN] [nvarchar](500) NULL,[So_TKTX] [nvarchar](500) NULL, " & _
                     "[Ngay_TKTX] [datetime] NULL,[PTXuat_ID] [int] NULL,[DischargePoint] [nvarchar](50) NULL,[DesDischargePoint] [nvarchar](1500) NULL, " & _
                     "[BSART] [nvarchar](50) NULL,[BWART] [nvarchar](50) NULL,[VTWEG] [nvarchar](50) NULL,[TenKhoNhap] [nvarchar](500) NULL, " & _
                     "[Xitec_Option] [nvarchar](10) NULL,[SoLenhGoc] [nvarchar](50) NULL,[Dem] [nvarchar](50) NULL,[PTIEN] [nvarchar](50) NULL, " & _
                     "[SCHUYEN] [int] NULL,[NgayVaoKho] [datetime] NULL,[SMO_ID] [int] NULL,[CardNum] [nvarchar](100) NULL, " & _
                     "[CardData] [nvarchar](100) NULL,[MaTraCuu] [nvarchar](200) NULL,[TongSoNiem] [int] NULL,[SoBienBanMau] [nvarchar](150) NULL, " & _
                     "[DO1_SoLenh] [nvarchar](50) NULL,[DO1_MaKhach] [nvarchar](2000) NULL,[SoBienBan] [nvarchar](150) NULL, " & _
                     "[NgayLapBienBan] [datetime] NULL,[SOType] [nvarchar](50) NULL,[PrcingDate] [datetime] NULL,[POType] [nvarchar](50) NULL, " & _
                     "[FromSoLenh] [nvarchar](50) NULL,[PriceGroupDO1] [nvarchar](100) NULL,[LXLoai] [nvarchar](100) NULL,[LXPhieu] [nvarchar](100) NULL, " & _
                     "[SO_POType] [nvarchar](50) NULL,[Prcing] [datetime] NULL,[DOCT] [nvarchar](1000) NULL,[HDChuyen] [nvarchar](100) NULL, " & _
                     "[BatchNum] [nvarchar](100) NULL,[DO1_MaNguon] [nvarchar](100) NULL,[CrSysDate] [datetime] NULL,[PriceSynDate] [datetime] NULL, " & _
                     "[NOTE_LX] [nvarchar](100) NULL,[SO_CHUYEN] [int] NULL,[LOAI_KH] [nvarchar](2) NULL,[NOTE_SMO] [nvarchar](100) NULL, " & _
                     "[NhomBeXuat] [nvarchar](20) NULL,[NhomBeAPP] [nvarchar](20) NULL,[NhomBeAPPU] [nvarchar](100) NULL, " & _
                     "[NhomBeAPPD] [datetime] NULL,[ThongTinTDH] [nvarchar](20) NULL,[trangthai] [nvarchar](20) NULL, " & _
                     "[TK_SynDate] [datetime] NULL,[R_KWMENG2] [int] NULL, " & _
                        "CONSTRAINT [PK_tblLenhXuatE5_THN] PRIMARY KEY CLUSTERED ( " & _
                     "[SoLenh] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,  " & _
                     "ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]) ON [PRIMARY] " & _
                               "  " & _
                    "ALTER TABLE [dbo].[tblLenhXuatE5_THN] ADD  CONSTRAINT [DF__tblLenhXuatE5_THN__2E20C9B8]  DEFAULT (getdate()) FOR [CrSysDate] ; end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

            End If
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblLenhXuatChiTietE5_THN' AND xtype='U') " & _
                 "  begin CREATE TABLE [dbo].[tblLenhXuatChiTietE5_THN]([MaNgan] [nvarchar](3) NOT NULL,[MaLenh] [nvarchar](4) NULL, " & _
                     "[NgayXuat] [datetime] NOT NULL,[LineID] [nvarchar](6) NOT NULL,[SoLuongDuXuat] [decimal](18, 2) NULL, " & _
                     "[SoLuongThucXuat] [decimal](18, 2) NULL,[ThoiGianDau] [datetime] NULL,[ThoiGianCuoi] [datetime] NULL, " & _
                     "[Sl_llkebd] [decimal](18, 2) NULL,[Sl_llkekt] [decimal](18, 2) NULL,[HeSo_k] [decimal](6, 4) NULL, " & _
                     "[NhietDo] [decimal](5, 2) NULL,[TyTrong_15] [decimal](6, 4) NULL,[MaDanXuat] [nvarchar](2) NULL, " & _
                     "[MaLoi] [nvarchar](6) NULL,[TrangThai] [nvarchar](2) NULL,[MaLuuLuongKe] [nvarchar](30) NULL, " & _
                     "[MaEntry] [decimal](6, 0) NULL,[MaLo] [decimal](6, 0) NULL,[GhiChu] [nvarchar](50) NULL,[Status] [char](2) NULL, " & _
                     "[ERate] [nvarchar](6) NULL,[Createby] [nvarchar](30) NULL,[UpdatedBy] [nvarchar](30) NULL,[CreateDate] [datetime] NULL, " & _
                     "[UpdateDate] [datetime] NULL,[DungTichNgan] [int] NULL,[TableID] [varchar](8) NULL,[MaTuDongHoa] [varchar](8) NULL, " & _
                     "[Row_id] [int] IDENTITY(1,1) NOT NULL,[PhuongTien] [nvarchar](50) NULL,[Record_Status] [nvarchar](50) NULL, " & _
                     "[SO_TT] [int] NULL,[FlagTankLine] [nvarchar](1) NULL,[GST_TDH] [decimal](18, 2) NULL,[CardNum] [nvarchar](100) NULL, " & _
                     "[CardData] [nvarchar](100) NULL,[BatchNum] [nvarchar](100) NULL,[L15] [decimal](18, 3) NULL, " & _
                     "[KG] [decimal](18, 3) NULL,[BQGQ_NhietDo] [decimal](18, 2) NULL,[BQGQ_D15] [decimal](18, 4) NULL, " & _
                     "[VCF] [decimal](18, 4) NULL,[WCF] [decimal](18, 4) NULL,[NhomBeXuat] [nvarchar](20) NULL, " & _
                     "[BeXuat] [nvarchar](20) NULL,[ThongTinTDH] [nvarchar](20) NULL,[NhietDoXe] [decimal](5, 2) NULL,SoLenhLine varchar(20) NULL, " & _
                     "CONSTRAINT [PK_tblLenhXuatChiTietE5_THN] PRIMARY KEY CLUSTERED  " & _
                    "([Row_id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, " & _
                     "OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]) ON [PRIMARY] ; end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

            End If
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblLenhXuat_HangHoaE5_THN' AND xtype='U') " & _
                 "  begin CREATE TABLE [dbo].[tblLenhXuat_HangHoaE5_THN]([LineID] [nvarchar](6) NOT NULL,[MaLenh] [nvarchar](4) NULL, " & _
                     "[NgayXuat] [datetime] NOT NULL,[SoLenh] [nvarchar](10) NULL,[TongXuat] [decimal](18, 2) NULL, " & _
                     "[TongDuXuat] [decimal](18, 2) NULL,[MaHangHoa] [nvarchar](18) NULL,[DonViTinh] [nvarchar](3) NULL, " & _
                     "[BeXuat] [nvarchar](20) NULL,[TableID] [nvarchar](8) NOT NULL,[MeterId] [char](4) NULL, " & _
                     "[Createby] [nvarchar](30) NULL,[UpdatedBy] [nvarchar](30) NULL,[CreateDate] [datetime] NULL, " & _
                     "[UpdateDate] [datetime] NULL,[QCI_KG] [decimal](18, 2) NULL,[QCI_NhietDo] [decimal](5, 2) NULL, " & _
                     "[QCI_TyTrong] [decimal](10, 4) NULL,[DonGia] [decimal](18, 6) NULL,[CurrencyKey] [varchar](5) NULL, " & _
                     "[VCF] [decimal](6, 4) NULL,[WCF] [decimal](6, 4) NULL,[NhietDo_BQGQ] [decimal](6, 4) NULL, " & _
                     "[D15_BQGQ] [decimal](6, 4) NULL,[KG] [decimal](18, 2) NULL,[L15] [decimal](18, 2) NULL, " & _
                     "[GiaCty] [decimal](18, 6) NULL,[PhiVT] [decimal](18, 6) NULL,[TheBVMT] [decimal](18, 6) NULL, " & _
                     "[ChietKhau] [decimal](15, 4) NULL,[Z001_PER] [decimal](18, 3) NULL,[Z003_PER] [decimal](18, 3) NULL, " & _
                     "[Z009_PER] [decimal](18, 3) NULL,[QCI_L15] [decimal](18, 2) NULL,[TongSoTien] [decimal](18, 6) NULL, " & _
                     "[BatchNum] [nvarchar](200) NULL,[NhomBeXuat] [nvarchar](20) NULL,[ID] [int] IDENTITY(1,1) NOT NULL, " & _
                     "CONSTRAINT [PK_tblLenhXuat_HangHoaE5_THN] PRIMARY KEY CLUSTERED  " & _
                    "([ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,  " & _
                     "ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]) ON [PRIMARY]; end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

            End If

            p_Error = ""
            p_SQL = "alter table  tblLenhXuatE5 add BatchNum nvarchar(100);"

            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If
            p_Error = ""
            p_SQL = "alter table  tblLenhXuatE5 add  NgayVaoKho date ;"

            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If
            p_Error = ""
            p_SQL = "alter table  tblLenhXuatE5 add SMO_ID nvarchar(300);"

            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If
            p_Error = ""
            p_SQL = "alter table  tblLenhXuatE5 add SoBienBan nvarchar(300);"

            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If
            p_Error = ""
            p_SQL = "alter table  tblLenhXuatE5 add  NgayLapBienBan nvarchar(200);"

            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If
            p_Error = ""
            p_SQL = "alter table  tblLenhXuatE5 add CrSysDate datetime;"

            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If
            p_Error = ""
            p_SQL = "alter table  tblLenhXuat_HangHoaE5 add BatchNum nvarchar(100);"

            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If
            p_Error = ""
            p_SQL = "alter table  tblLenhXuatChiTietE5 add BatchNum nvarchar(100);"

            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
            End If


            p_Error = ""
            p_SQL = "create  view tblLenhXuatE5_THN_HIST_V as " & _
                "select a.SoLenh, a.sDesc, a.CreateDate, b.NgayXuat,c.TenKhachHang ,  b.MaPhuongTien, b.NguoiVanChuyen " & _
                 "from tblLenhXuatE5_THN_HIST a left join  tblLenhXuatE5 b on a.solenh =b.solenh " & _
                  "left join tblKhachHang c on b.MaKhachHang =c.MaKhachHang;"
            If g_Services.Sys_Execute(p_SQL, _
                                        p_Error) = False Then

                End If


                '===============================================

                '20250317
                'Exit Sub

            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblLogToSap' AND xtype='U') " & _
                 "  begin CREATE TABLE [dbo].[tblLogToSap]([ID] [int] IDENTITY(1,1) NOT NULL,[CrDate] [datetime] NULL, " & _
                     "[FuncName] [nvarchar](150) NULL,[UserCode] [nvarchar](150) NULL,[CompanyCode] [nvarchar](50) NULL, " & _
                     "[KeySAP] [nvarchar](150) NULL,[Client] [nvarchar](50) NULL,CONSTRAINT [PK_tblLogToSap] PRIMARY KEY CLUSTERED  " & _
                    "([ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] " & _
                    ") ON [PRIMARY] ; ALTER TABLE [dbo].[tblLogToSap] ADD  CONSTRAINT [DF_tblLogToSap_CrDate]  DEFAULT (getdate()) FOR [CrDate]; end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""
            p_SQL = "begin  if not exists (select 1 from SYS_CONFIG   where  upper( KEYCODE )='NHIETDO_XE' ) " & _
                "begin INSERT INTO SYS_CONFIG (KEYCODE, KEYVALUE, [DESC]) VALUES('NHIETDO_XE','Y', N'Y: Kiểm tra quá thời gian cho pháp thì phải nhập Nhiệt độ Ptien') End  " & _
                " if not exists (select 1 from SYS_CONFIG   where  upper( KEYCODE )='NHIETDO_TIME' )  " & _
                    " begin  INSERT INTO SYS_CONFIG (KEYCODE, KEYVALUE,[DESC]) VALUES('NHIETDO_TIME',30, N'Số phút cần kiểm tra nhập bổ sung nhiệt độ PTien') End end ;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If



            p_Error = ""
            p_SQL = " if  COL_LENGTH('tblConfig','Plant_DB') is null " & _
                    "  begin alter table tblConfig  add Plant_DB nvarchar(50) end;"

            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If
            p_Error = ""
            p_SQL = " if  COL_LENGTH('tbllenhxuate5','ThongTinTDH') is null " & _
               "  begin alter table  tbllenhxuate5 add ThongTinTDH nvarchar(20)  " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If

            p_Error = ""
            p_SQL = " if  COL_LENGTH('tbllenhxuate5','trangthai') is null " & _
               "  begin alter table  tbllenhxuate5 add trangthai nvarchar(20)  " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If


            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblLenhXuatChiTietE5','ThongTinTDH') is null " & _
               "  begin alter table  tblLenhXuatChiTietE5 add ThongTinTDH nvarchar(20)  " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If


            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblChiTietPhuongTien','LTT_CM') is null " & _
               "  begin alter table  tblChiTietPhuongTien add LTT_CM  decimal(15,2), NHAP_MM decimal(15,2) , DUONGSINH decimal(15,2)  " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If
            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblChiTietPhuongTien_Hist','LTT_CM') is null " & _
               "  begin alter table  tblChiTietPhuongTien_Hist add LTT_CM  decimal(15,2), NHAP_MM decimal(15,2) , DUONGSINH decimal(15,2)  " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If

            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblChiTietPhuongTien','ID') is null " & _
               "  begin alter table  tblChiTietPhuongTien add [ID] [decimal](18, 0) IDENTITY(1,1) NOT NULL  " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If


            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblPhuongTien','REG_NO') is null " & _
               "  begin alter table  tblPhuongTien add REG_NO nvarchar(20) " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If

            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblPhuongTien_Hist','REG_NO') is null " & _
               "  begin alter table  tblPhuongTien_Hist add REG_NO nvarchar(20) " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If

            p_Error = ""
            p_SQL = "create VIEW [dbo].[FPT_tblChiTietPhuongTien_V1] AS " & _
                   "SELECT MaNgan, MaPhuongTien, SoLuongMax, Status, 'N' AS CHECKUPD, LTT_CM, NHAP_MM, DUONGSINH, ID FROM     dbo.tblChiTietPhuongTien;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If
            p_Error = ""
            p_SQL = "CREATE VIEW [dbo].[FPT_tblPhuongTien_V1] AS " & _
                                "SELECT        dbo.tblPhuongTien.MaPhuongTien, dbo.tblPhuongTien.LaiXe, dbo.tblTu.TuText, dbo.tblPhuongTien.SoNgan, dbo.tblPhuongTien.NgayBatDau, dbo.tblPhuongTien.NgayHieuLuc, dbo.tblPhuongTien.Status, CONVERT(date, " & _
                                                         "CASE WHEN dbo.tblPhuongTien.NgayBatDau = '00000000' THEN NULL ELSE CONVERT(date, dbo.tblPhuongTien.NgayBatDau) END) AS NgayBatDau2, CONVERT(date, " & _
                                                         "CASE WHEN dbo.tblPhuongTien.NgayHieuLuc = '00000000' THEN NULL ELSE CONVERT(date, dbo.tblPhuongTien.NgayHieuLuc) END) AS NgayHieuLuc2, 'N' AS CHECKUPD, dbo.tblPhuongTien.iweight, CONVERT(date, " & _
                                                         "CASE WHEN dbo.tblPhuongTien.NgayBatDau = '00000000' THEN CONVERT(nvarchar(20), getdate() + 100, 112) ELSE CONVERT(date, dbo.tblPhuongTien.NgayBatDau) END) AS NgayBatDau1, CONVERT(date, " & _
                                                         "CASE WHEN dbo.tblPhuongTien.NgayHieuLuc = '00000000' THEN CONVERT(nvarchar(20), getdate() - 100, 112) ELSE CONVERT(date, dbo.tblPhuongTien.NgayHieuLuc) END) AS NgayHieuLuc1, dbo.tblPhuongTien.REG_NO " & _
                                " FROM  dbo.tblTu INNER JOIN     dbo.tblPhuongTien ON dbo.tblTu.TuType = dbo.tblPhuongTien.LaiXe;"
            If g_Services.Sys_Execute(p_SQL, _
                                        p_Error) = False Then

                End If

                'p_Error = ""
                'p_SQL = "CREATE PROCEDURE ZZPhuongTien_To_SAP  @p_MaPhuongTien nvarchar(100) AS BEGIN " & _
                ' "select aa.*," & _
                '   "(select top 1 HoVaTen from tblPhuongTien_LaiXe abc where MaPhuongTien  =aa.[MaPhuongTien] " & _
                '    "and convert(date,getdate())  > =  convert(date,isnull(FromDate,getdate()-1)) and  " & _
                '    "convert(date,getdate())  < =  convert(date,isnull(ToDate ,getdate()+1))) as DIRVER 	from  [FPT_tblPhuongTien_V] aa " & _
                '     "where MaPhuongTien = @p_MaPhuongTien;" & _
                ' "select * from  tblChiTietPhuongTien  where   MaPhuongTien = @p_MaPhuongTien;End"
                'If g_Services.Sys_Execute(p_SQL, _
                '                          p_Error) = False Then

                'End If

                '=================================================


            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblLenhXuatChiTietE5','NhietDoXe') is null " & _
               "  begin alter table  tblLenhXuatChiTietE5 add NhietDoXe decimal(5,2) " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If


            p_Error = "" '
            p_SQL = " if  COL_LENGTH('ztblTankLineImp','NhomBeXuat') is null " & _
               "  begin alter table  ztblTankLineImp add NhomBeXuat nvarchar(20) " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If


            p_Error = "" '
            p_SQL = " if  COL_LENGTH('ztblTankBatchs','SDA_Amount') is null " & _
               "  begin alter table  ztblTankBatchs add SDA_Amount nvarchar(20) " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If


            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblLenhXuatE5','NhomBeXuat') is null " & _
               "  begin alter table  tblLenhXuatE5 add NhomBeXuat nvarchar(20) " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If

            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblLenhXuatE5','NhomBeAPP') is null " & _
               "  begin alter table  tblLenhXuatE5 add NhomBeAPP nvarchar(20), NhomBeAPPU nvarchar(100), NhomBeAPPD datetime" & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If

            p_Error = "" '
            p_SQL = " if  COL_LENGTH('SYS_USER','NhomBeAPP') is null " & _
               "  begin alter table  SYS_USER add NhomBeAPP nvarchar(20) " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If




            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblLenhXuat_HangHoaE5','NhomBeXuat') is null " & _
               "  begin alter table  tblLenhXuat_HangHoaE5 add NhomBeXuat nvarchar(20) " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If

            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblLenhXuatChiTietE5','NhomBeXuat') is null " & _
               "  begin alter table  tblLenhXuatChiTietE5 add NhomBeXuat nvarchar(20), BeXuat nvarchar(20) " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If

            p_Error = "" '
            p_SQL = " if  COL_LENGTH('SYS_USER','NhomBeXuat') is null " & _
               "  begin alter table  SYS_USER add NhomBeXuat nvarchar(2), BeXuat nvarchar(2) " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If

            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblLenhXuatE5','TK_SynDate') is null " & _
               "  begin alter table  tblLenhXuatE5 add TK_SynDate datetime, R_KWMENG2 int " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If

            p_Error = ""
            p_SQL = " if  COL_LENGTH('tblLenhXuat_HangHoaE5','Z001_PER') is null " & _
               "  begin alter table tblLenhXuat_HangHoaE5 add  Z001_PER decimal(18,3) , Z003_PER decimal(18,3) , Z009_PER decimal(18,3)     end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If


            p_Error = ""
            p_SQL = " if  COL_LENGTH('tblLenhXuatE5','PriceSynDate') is null " & _
               "  begin alter table tblLEnhXuatE5 add PriceSynDate datetime, LXLoai nvarchar(200), LXPhieu nvarchar(200), SO_POType nvarchar(100) " & _
                    ",Prcing  datetime, DOCT nvarchar(100)   end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If

            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblSO_PO_Type' AND xtype='U') " & _
                 "  begin CREATE TABLE [dbo].[tblSO_PO_Type]([Code] [nvarchar](50) NOT NULL,[sName] [nvarchar](2550) NULL, " & _
                         "[Status] [nvarchar](50) NULL,[sDesc] [nvarchar](2550) NULL,[sType] [nvarchar](2550) NULL, " & _
                         "[CreateDate] [datetime] NULL,[UpdateDate] [datetime] NULL,[CreateBy] [nvarchar](150) NULL, " & _
                         "[UpdatedBy] [nvarchar](150) NULL, CONSTRAINT [PK_tblSO_PO_Type] PRIMARY KEY CLUSTERED  " & _
                            "([Code] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, " & _
                            "ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]) ON [PRIMARY] end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_SQL = "select a.object_id  from sys.all_columns b, sys.all_objects a  where  a.object_id = b.object_id " & _
                     "and UPPER (a.Name) = upper('FPT_tblLenhXuat_HangHoaE5_New_V') and upper(b.name) = upper('QCI_L15')"
            If ObjectCheckExists(p_SQL) = False Then
                p_Error = ""
                p_SQL = "ALTER VIEW [dbo].[FPT_tblLenhXuat_HangHoaE5_New_V] AS " & _
                            "SELECT     LineID, MaLenh, NgayXuat, SoLenh, TongXuat, TongDuXuat, MaHangHoa, " & _
                            "(SELECT     TOP (1) TenHangHoa  FROM dbo.tblHangHoa WHERE      (MaHangHoa = dbo.tblLenhXuat_HangHoaE5.MaHangHoa)) AS TenHangHoa, " & _
                            "DonViTinh, BeXuat, TableID, MeterId, Createby, UpdatedBy, CreateDate, UpdateDate, 'N' AS CHECKUPD, " & _
                            "QCI_KG, QCI_NhietDo, QCI_TyTrong, DonGia, CurrencyKey, VCF, WCF, NhietDo_BQGQ, D15_BQGQ, KG, L15, GiaCty, PhiVT, " & _
                            "TheBVMT, ChietKhau, Z001_PER, Z003_PER, Z009_PER, QCI_L15  FROM dbo.tblLenhXuat_HangHoaE5 WITH (nolock)"

                If g_Services.Sys_Execute(p_SQL, _
                                          p_Error) = False Then

                    End If
                End If

                'Bo sung nhombexuat
            p_SQL = "select a.object_id  from sys.all_columns b, sys.all_objects a  where  a.object_id = b.object_id " & _
                     "and UPPER (a.Name) = upper('FPT_tblLenhXuatE5_New_V') and upper(b.name) = upper('NhomBeXuat')"
            If ObjectCheckExists(p_SQL) = False Then

                p_Error = ""
                p_SQL = "ALTER VIEW [dbo].[FPT_tblLenhXuatE5_New_V] AS  " & _
                        "SELECT        A.MaLenh, A.NgayXuat, A.SoLenh, A.MaDonVi, A.MaNguon, " & _
                            "(SELECT        TOP (1) TenNguon FROM            dbo.tblNguon AS a1 WHERE        (MaNguon = A.MaNguon)) AS TenNguon, A.MaKho, " & _
                            "(SELECT        TenKho FROM            dbo.tblKho AS h1 WITH (Nolock) WHERE        (MaKho = A.MaKho)) AS TenKhoXuat, CASE WHEN isnull(a.TenKhoNhap, '') = '' THEN h.TenKho ELSE a.TenKhoNhap END AS TenKho, A.MaVanChuyen, " & _
                            "(SELECT        TOP (1) TenVanChuyen FROM            dbo.tblVanChuyen WHERE        (MaVanChuyen = A.MaVanChuyen)) AS TenMaVanChuyen, " & _
                            "(SELECT        TOP (1) TenVanChuyen FROM   dbo.tblVanChuyen AS tblVanChuyen_1 WHERE  (MaVanChuyen = A.MaVanChuyen)) AS Expr1, A.MaPhuongTien, A.NguoiVanChuyen, A.MaPhuongThucBan, " & _
                            "(SELECT        TOP (1) TenPhuongThucBan FROM dbo.tblPhuongThucBan WHERE  (MaPhuongThucBan = A.MaPhuongThucBan)) AS TenPhuongThucBan, A.MaPhuongThucXuat, A.MaKhachHang, " & _
                            "(SELECT        TOP (1) TenKhachHang FROM  dbo.tblKhachHang WHERE   (MaKhachHang = A.MaKhachHang)) AS TenKhachHang, A.LoaiPhieu, A.Niem, A.LuongGiamDinh, " & _
                         "A.NhietDoTaiTau, A.GhiChu, A.NgayHieuLuc, RTRIM(LTRIM(A.Status)) AS Status, A.Number, A.Createby, A.UpdatedBy, " & _
                         "A.CreateDate, A.UpdateDate, A.SoLenhSAP, CASE WHEN LoaiPhieu = 'V144' THEN 'N' ELSE 'Y' END AS ChuyenVanChuyen, A.Client, A.HTTG, A.Approved,  " & _
                         "A.User_Approve, A.Date_Approve, A.EditApprove, A.NhaCungCap,(SELECT  Name  FROM  dbo.FPT_TrangThaiLenh_V AS a2 WHERE (Status = RTRIM(LTRIM(A.Status)))) AS Status_Name, 'N' AS CHECKUPD, " & _
                            "(SELECT TOP (1) SoTichKe FROM   dbo.tblTichke AS B WHERE        (SoLenh = A.SoLenh)) AS SoTichKe, A.AppDesc, A.Slog, A.NgayHetHieuLuc, A.NgayTichKe, A.STO, " & _
                            "A.NguoiDaiDien, b.TenPhuongThucXuat, A.DiemTraHang, c.TenNhaCungCap, A.Tax, A.PaymentMethod, " & _
                         "d.NoiDung AS PhuongThucThanhToan, A.Term, e.GhiChu AS ThoiHanThanhToan, A.MaTuyenDuong, g.DGTuyenDuong AS TenTuyenDuong, A.MaKhoNhap, " & _
                         "A.MaKhoNhap + ' - ' + CASE WHEN isnull(a.TenKhoNhap, '') = '' THEN h.TenKho ELSE a.TenKhoNhap END AS TenKhoNhap, A.SoHopDong, A.NgayHopDong, " & _
                            "A.TyGia, A.SoTKHQNhap, A.SoTKHQXuat, A.SelfShipping, A.PriceGroup, pg.PriceGroupName, A.Inco1, A.Inco2, A.XuatHangGui, " & _
                            "A.So_TKTN, A.So_TKTX, A.Ngay_TKTX, A.DischargePoint, A.DesDischargePoint, A.BSART, b.Ma_Map, g.DGDiemDen, " & _
                         "b.Ma_Map + '-' + b.BWART + '-' + b.TenPhuongThucXuat AS TenPhuongThucXuat1, " & _
                         "A.TenKhoNhap AS TenKhoNhap11, A.LXLoai, A.LXPhieu, A.SO_POType, A.Prcing, A.PriceGroupDO1, " & _
                            "(SELECT  TOP (1) sName FROM  dbo.tblSO_PO_Type AS bc WHERE   (Code = A.SOType)) AS SOTypeName, " & _
                            "(SELECT TOP (1) sName FROM  dbo.tblSO_PO_Type AS bc WHERE  (Code = A.POType)) AS POTypeName, A.PrcingDate, A.SOType, A.POType, " & _
                         "A.BatchNum, A.HDChuyen, A.DO1_SoLenh, A.DOCT, a.PriceSynDate,a.NhomBeXuat, a.TK_SynDate, R_KWMENG2 " & _
                        "FROM dbo.tblLenhXuatE5 AS A WITH (Nolock) LEFT OUTER JOIN " & _
                            "dbo.tblPhuongThucXuat AS b WITH (Nolock) ON b.BWART = A.MaPhuongThucXuat AND b.VTWEG = A.MaPhuongThucBan AND ISNULL(b.BSART, N'') = ISNULL(A.BSART, N'') LEFT OUTER JOIN " & _
                            "dbo.tblNhaCungCap AS c WITH (Nolock) ON c.MaNhaCungCap = A.NhaCungCap LEFT OUTER JOIN " & _
                            "dbo.tblPhuongThucThanhToan AS d WITH (Nolock) ON d.MaPhuongThuc = A.PaymentMethod LEFT OUTER JOIN " & _
                            "dbo.tblThoiHanThanhToan AS e WITH (Nolock) ON e.TermKey = A.Term LEFT OUTER JOIN " & _
                            "dbo.tblGiaoNhan AS g WITH (Nolock) ON g.MaTuyenDuong = A.MaTuyenDuong AND g.DiemDen = A.DischargePoint LEFT OUTER JOIN " & _
                            "dbo.tblKho AS h WITH (Nolock) ON h.MaKho = A.MaKhoNhap LEFT OUTER JOIN " & _
                            "dbo.tblPriceGroup AS pg WITH (nolock) ON pg.PriceGroup = A.PriceGroup "
                If g_Services.Sys_Execute(p_SQL, _
                                          p_Error) = False Then

                    End If

                End If
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblCongToNhomBe' AND xtype='U')" & _
                 "  begin Create table tblCongToNhomBe(ID int IDENTITY(1,1) NOT NULL,MeterId	nvarchar(10),Valid_from	DateTime,Valid_to	DateTime,Bexuat	nvarchar(20),TankGroup	nvarchar(10)," & _
                   " TankGroup_Name	nvarchar(140),MaHangHoa	nvarchar(18),TenHangHoa	nvarchar(40),Push_TDH	nvarchar(2),Push_XTTD	nvarchar(2),User_Push_TDH	nvarchar(120) " & _
                    ",Date_Push_TDH	DateTime,User_Push_XTTD	nvarchar(120),Date_Push_XTTD	DateTime , CreateUser nvarchar(100)," & _
                    " CreateDate datetime default getdate() , UpdateUser nvarchar(100), UpdateDate datetime default getdate(), TankValidfrom datetime ,TankValid_to datetime ) end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblCongToNhomBe_Hist' AND xtype='U')" & _
                 "  begin Create table tblCongToNhomBe_Hist(ID int NULL,MeterId	nvarchar(10),Valid_from	DateTime,Valid_to	DateTime,Bexuat	nvarchar(20),TankGroup	nvarchar(10)," & _
                   " TankGroup_Name	nvarchar(140),MaHangHoa	nvarchar(18),TenHangHoa	nvarchar(40),Push_TDH	nvarchar(2),Push_XTTD	nvarchar(2),User_Push_TDH	nvarchar(120) " & _
                    ",Date_Push_TDH	DateTime,User_Push_XTTD	nvarchar(120),Date_Push_XTTD	DateTime , CreateUser nvarchar(100)," & _
                    " CreateDate datetime default getdate() , UpdateUser nvarchar(100), UpdateDate datetime default getdate(), sType nvarchar(2), TankValidfrom datetime ,TankValid_to datetime ) end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblCongToNhomBe_TDH' AND xtype='U')" & _
                 "  begin Create table tblCongToNhomBe_TDH (IDLINE int IDENTITY(1,1) NOT NULL,ID int NULL,MeterId	nvarchar(10),Valid_from	DateTime,Valid_to	DateTime,Bexuat	nvarchar(20),TankGroup	nvarchar(10)," & _
                   " TankGroup_Name	nvarchar(140),MaHangHoa	nvarchar(18),TenHangHoa	nvarchar(40),Push_TDH	nvarchar(2),Push_XTTD	nvarchar(2),User_Push_TDH	nvarchar(120) " & _
                    ",Date_Push_TDH	DateTime,User_Push_XTTD	nvarchar(120),Date_Push_XTTD	DateTime , CreateUser nvarchar(100)," & _
                    " CreateDate datetime default getdate() , UpdateUser nvarchar(100), UpdateDate datetime default getdate(), sType nvarchar(2), TankValidfrom datetime ,TankValid_to datetime ) end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblCongToNhomBe_TDH_HIST' AND xtype='U')" & _
                 "  begin Create table tblCongToNhomBe_TDH_HIST (IDLINE int ,ID int NULL,MeterId	nvarchar(10),Valid_from	DateTime,Valid_to	DateTime,Bexuat	nvarchar(20),TankGroup	nvarchar(10)," & _
                   " TankGroup_Name	nvarchar(140),MaHangHoa	nvarchar(18),TenHangHoa	nvarchar(40),Push_TDH	nvarchar(2),Push_XTTD	nvarchar(2),User_Push_TDH	nvarchar(120) " & _
                    ",Date_Push_TDH	DateTime,User_Push_XTTD	nvarchar(120),Date_Push_XTTD	DateTime , CreateUser nvarchar(100)," & _
                    " CreateDate datetime default getdate() , UpdateUser nvarchar(100), UpdateDate datetime default getdate(), sType nvarchar(2), " & _
                    " TankValidfrom datetime ,TankValid_to datetime , CurrentDate datetime default getdate(),[OldValid_from] [datetime] NULL,[OldValid_to] [datetime] NULL) end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblTankGroup' AND xtype='U')" & _
                 "  begin CREATE TABLE [tblTankGroup](	id int IDENTITY(1,1)  NOT NULL,[Name_nd] [nvarchar](20) NOT NULL,[Product_nd] [nvarchar](18) not NULL," & _
               "  [TankGroup] [nvarchar](18) not NULL,FromDate datetime,ToDate datetime,CreateUser [nvarchar](100),CreateDate datetime default getdate()," & _
               "  UpdateUser [nvarchar](100),UpdateDate datetime default getdate(),ID_SAP nvarchar(100)), [TichHop] [nvarchar](10)  end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblTankGroup_HIST' AND xtype='U')" & _
                 "  begin CREATE TABLE [tblTankGroup_HIST](	id int  NULL,[Name_nd] [nvarchar](20)  NULL,[Product_nd] [nvarchar](18)  NULL," & _
             "[TankGroup] [nvarchar](18)  NULL,FromDate datetime,ToDate datetime,CreateUser [nvarchar](100),CreateDate datetime ," & _
             "UpdateUser [nvarchar](100),UpdateDate datetime ,ID_SAP nvarchar(100), sType nvarchar(10), CrDate datetime default getdate()) , [TichHop] [nvarchar](10)  end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_SQL = "create view tblTankGroup_V as SELECT a.id,a.Name_nd,a.Product_nd,b.TenHangHoa,a.TankGroup " & _
                          ",a.FromDate,a.ToDate,a.CreateUser ,a.CreateDate,a.UpdateUser,a.UpdateDate,a.ID_SAP " & _
                     ", 'N' as CHECKUPD, a.TichHop FROM dbo.tblTankGroup a, tblHangHoa b where a.Product_nd = b.MaHangHoa;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_SQL = "create view tblTankGroupList_V as select 'TD' as Code, N'Tập đoàn' as GrpName union all  select 'KH' as Code, N'Khách hàng' as GrpName;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_SQL = "create view  tblCongToNhomBe_V as select  MeterId,Valid_from,Valid_to,Bexuat," & _
                    "TankGroup,TankGroup_Name,MaHangHoa,TenHangHoa,Push_TDH,Push_XTTD,User_Push_TDH," & _
                    "Date_Push_TDH,User_Push_XTTD,Date_Push_XTTD,ID,'N' as CHECKUPD, 'N' as X , TankValidfrom, TankValid_to,TankValidfrom, TankValid_to, (select top 1 MaHangHoa_Scada  from tblMap_MaHangHoa b where b.MaHangHoa_Sap = a.MaHangHoa ) MaHangHoaTDH " & _
                        " from  tblCongToNhomBe a ;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If



            p_Error = "" '
            p_SQL = " if  COL_LENGTH('SYS_USER','Excel_Rpt') is null " & _
               "  begin alter table  SYS_USER add Excel_Rpt nvarchar(2) " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If



            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tbllenhxuate5','NOTE_SMO') is null " & _
               "  begin alter table  tbllenhxuate5 add NOTE_SMO nvarchar(100) " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If

            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tbllenhxuate5','SO_CHUYEN') is null " & _
               "  begin alter table  tbllenhxuate5 add SO_CHUYEN int " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If

            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tbllenhxuate5','LOAI_KH') is null " & _
               "  begin alter table  tbllenhxuate5 add LOAI_KH nvarchar(2) " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, p_Error) = False Then
                End If

            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tbllenhxuate5','NOTE_LX') is null " & _
               "  begin alter table  tbllenhxuate5 add NOTE_LX nvarchar(100) " & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then


                End If

            p_Error = "" '
            p_SQL = " if  COL_LENGTH('ztblTankLineImp','BAREM_HEIGHT') is null " & _
               "  begin alter table  ztblTankLineImp add BAREM_HEIGHT [nvarchar](50) NULL,  BAREM_WATER nvarchar(50)" & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then


                End If
            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblPhuongTien_LaiXe','UpdUser') is null " & _
               "  begin alter table  tblPhuongTien_LaiXe add UpdUser [nvarchar](150) NULL,  UpdDate Datetime null" & _
                   "  end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then


                End If



                '=========20250327======================================================================================================
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblATGConfig' AND xtype='U')" & _
                 "  begin CREATE TABLE [dbo].[tblATGConfig]([ID] int IDENTITY(1,1) NOT NULL,ProdLevel nvarchar(100), ProdTemp nvarchar(100), Datetime nvarchar(100)" & _
                    ", TankID nvarchar(100), CONSTRAINT [PK_tblATGConfig] PRIMARY KEY CLUSTERED  " & _
                                    "([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,  " & _
                                    "ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] end;"
            If g_Services.Sys_Execute(p_SQL, _
                  p_Error) = False Then

                End If

            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblTichke_Hist' AND xtype='U')" & _
                 "  begin CREATE TABLE [dbo].[tblTichke_Hist](" & _
                                 "[SoTichKe] [nvarchar](4) NOT NULL," & _
                                 "[NgayXuat] [nvarchar](10) NOT NULL," & _
                                 "[SoLenh] [nvarchar](500) NOT NULL," & _
                                 "[MaNgan] [nvarchar](3) NOT NULL," & _
                                 "[TableId] [nvarchar](8) NOT NULL," & _
                                 "[NgayTichKe] [date] NULL," & _
                                 "[SoBienBan] [nvarchar](150) NULL " & _
                                 ", UpdUser [nvarchar](150) NULL " & _
                                 ",CrDate datetime default getdate()) ON [PRIMARY] end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblTime' AND xtype='U')" & _
                 "  begin CREATE TABLE [dbo].[tblTime](	[ID] [int] IDENTITY(1,1) NOT NULL,	[TimeDefault] nvarchar(20)," & _
                    "[FromTime] [datetime] NULL,[ToTime] [datetime] NULL,TimeCheck nvarchar(10)," & _
                    "[Createdate] [datetime] NULL,CreateUser nvarchar(100),[Updatedate] [datetime] NULL,UpdateUser nvarchar(100)," & _
                                "CONSTRAINT [PK_tblTime] PRIMARY KEY CLUSTERED (	[ID] ASC " & _
                                ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON," & _
                                "ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] " & _
                                "ALTER TABLE [dbo].[tblTime] ADD  CONSTRAINT [DF_tblTime_Createdate]  DEFAULT (getdate()) FOR [Createdate] end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblTankMapSAP' AND xtype='U')" & _
                 "  begin CREATE TABLE [dbo].[tblTankMapSAP](	[ID] [int] IDENTITY(1,1) NOT NULL,	[Plant] [nvarchar](50) NULL," & _
                             "[TankSAP] [nvarchar](50) NULL,	[TankHTTG] [nvarchar](50) NULL,	[Createdate] [datetime] NULL,CreateUser nvarchar(100)," & _
                                "CONSTRAINT [PK_tblTankMapSAP] PRIMARY KEY CLUSTERED (	[ID] ASC " & _
                                ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON," & _
                                "ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] " & _
                                "ALTER TABLE [dbo].[tblTankMapSAP] ADD  CONSTRAINT [DF_tblTankMapSAP_Createdate]  DEFAULT (getdate()) FOR [Createdate] end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblToKhaiTaiXuat' AND xtype='U')" & _
                 "  begin CREATE TABLE [dbo].[tblToKhaiTaiXuat]([ID] int IDENTITY(1,1) NOT NULL,[BUKRS] [nvarchar](50) NULL," & _
                                 "[TK_NUMBER] [nvarchar](150) NULL,[R_KWMENG1] [decimal](18, 2) NULL,[R_KWMENG2] [decimal](18, 2) NULL," & _
                                 "[USER_F_DATE] [datetime] NULL,[USER_T_DATE] [datetime] NULL,[MEINS] [nvarchar](50) NULL," & _
                                 "[SYNDATE] [datetime] NULL,[SYNUSER] [nvarchar](50) NULL,[MaHangHoa] [nvarchar](50) NULL, CONSTRAINT [PK_tblToKhaiTaiXuat] PRIMARY KEY CLUSTERED  " & _
                                    "([ID] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON,  " & _
                                    "ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] end;"
            If g_Services.Sys_Execute(p_SQL, _
                  p_Error) = False Then

                End If

            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblKhachHang','CHECK_TD') is null " & _
               "  begin alter table  tblKhachHang add CHECK_TD [nvarchar](50) NULL " & _
                   "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then


                End If

            p_Error = "" '
            p_SQL = " if  COL_LENGTH('ztblTankLineImp','WaterHeight') is null " & _
               "  begin alter table  ztblTankLineImp add WaterHeight decimal(18,4) default 0 " & _
                   "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then


                End If


            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblDO_Header','Inco1') is null " & _
               "  begin alter table  tblDO_Header add MaNguon  [nvarchar](50) NULL, Inco1 [nvarchar](50) NULL " & _
                   "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then


                End If

            p_Error = "" '

            p_SQL = " if  COL_LENGTH('tblLenhXuatChiTietE5','L15') is null " & _
                 "  begin alter table  tblLenhXuatChiTietE5 add L15 decimal(18,3), " & _
                        "KG decimal(18,3), BQGQ_NhietDo  decimal(18,2), BQGQ_D15  decimal(18,4) ,  VCF  decimal(18,4),  WCF decimal(18,4)" & _
                     "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then


                End If



            p_Error = "" '

            p_SQL = " if  COL_LENGTH('tblLenhXuat_HangHoaE5','BatchNum') is null " & _
                    "  begin alter table  tblLenhXuat_HangHoaE5 add BatchNum nvarchar(200) " & _
                        "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then


                End If


            p_Error = "" '

            p_SQL = " if  COL_LENGTH('tblSTO','BEDAT') is null " & _
                    "  begin alter table  tblSTO add BEDAT DateTime, EINDT datetime " & _
                        "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then


                End If

            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblDonGia','UpdateDate') is null " & _
                    "  begin alter table  tblDonGia add UpdateDate DateTime" & _
                        "  end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then


                End If
            p_Error = "" '
            p_SQL = " if  COL_LENGTH('tblDonGia_EX','UpdateDate') is null " & _
                    "  begin alter table  tblDonGia_EX add UpdateDate DateTime" & _
                        "  end;"
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then


                End If


            p_Error = "" '

            p_SQL = " if  COL_LENGTH('tblDO_Header','DO1_MaNguon') is null " & _
                    "  begin alter table  tblDO_Header add DO1_MaNguon nvarchar(100) " & _
                        "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then


                End If

            p_Error = "" 'tblLenhXuate5

            p_SQL = " if  COL_LENGTH('tblLenhXuate5','DO1_MaNguon') is null " & _
                    "  begin alter table  tblLenhXuate5 add DO1_MaNguon nvarchar(100) " & _
                        "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then


                End If


            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblChungTu','sDesc') is null " & _
                    "  begin alter table  tblChungTu add sDesc nvarchar(1000) " & _
                        "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblProjects','ZLSCH') is null " & _
                    "  begin alter table  tblProjects add ZLSCH nvarchar(100) " & _
                        ", ZTERM nvarchar(100) ,  INCO2 nvarchar(100)   end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblHangHoa','CardNumber') is null " & _
                    "  begin alter table  tblHangHoa add CardNumber nvarchar(100) " & _
                        "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

                'KBETR
                ''============20200924 
            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblDonGia_ex','DonGiaPer') is null " & _
                    "  begin alter table  tblDonGia_ex add DonGiaPer  decimal(18,6) " & _
                        "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If
                'tblLenhXuat_HangHoae5
            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblLenhXuat_HangHoae5','TongSoTien') is null " & _
                                "  begin alter table  tblLenhXuat_HangHoae5 add TongSoTien  decimal(18,6) " & _
                        "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If
                'tblDO_Item_Material
            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblDO_Item_Material','TongSoTien') is null " & _
                                "  begin alter table  tblDO_Item_Material add TongSoTien  decimal(18,6) " & _
                        "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If
                'tblChungTuLine
            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblChungTuLine','TongSoTien') is null " & _
                                "  begin alter table  tblChungTuLine add TongSoTien  decimal(18,6) " & _
                        "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If
                '============================================================================

            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblProjects','PriceGroup') is null " & _
                    "  begin alter table  tblProjects add PriceGroup nvarchar(100) " & _
                        "  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblLenhXuatE5','HDChuyen') is null " & _
                    "  begin alter table  tblLenhXuatE5 add HDChuyen nvarchar(100), BatchNum nvarchar(100)   end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblLenhXuat_HangHoaE5','QCI_L15') is null " & _
                    "  begin alter table  tblLenhXuat_HangHoaE5 add QCI_L15 decimal(18,2)  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

                '20210803   Tao bang dung cho B12=================================
            p_Error = ""

            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblLenhXuatE5Ext' AND xtype='U')" & _
                 "  begin " & _
                     " CREATE TABLE [dbo].[tblLenhXuatE5Ext]([SoLenh] [nvarchar](50) NULL,[SoGiaoNhan] [nvarchar](4000) NULL," & _
                            "[GiaoNhanDH] [nvarchar](4000) NULL,[GiaoNhanBe] [nvarchar](4000) NULL, [NhietKeSenSor] [nvarchar](4000) NULL,[MaSoTN] [nvarchar](4000) NULL," & _
                            "[CamKetCL] [nvarchar](4000) NULL,[KetTN] [nvarchar](1000) NULL,[KetTrai] [nvarchar](1000) NULL," & _
                            "[KetPhai] [nvarchar](1000) NULL,[KetBoong] [nvarchar](1000) NULL,[SoNiem] [nvarchar](2000) NULL,[SoNiemCon] [nvarchar](2000) NULL," & _
                            "[CreateDate] [datetime] NULL,[ID] [int] IDENTITY(1,1) NOT NULL," & _
                            " CONSTRAINT [PK_tblLenhXuatE5Ext] PRIMARY KEY CLUSTERED ([ID] ASC)WITH (PAD_INDEX = OFF, " & _
                            " STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] " & _
                            "   ALTER TABLE [dbo].[tblLenhXuatE5Ext] ADD  CONSTRAINT [DF__tblLenhXu__Creat__4F19E1C8] " & _
                            " DEFAULT (getdate()) FOR [CreateDate]   " & _
                "end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_Error = ""

            p_SQL = " Create view FPT_tblLenhXuatE5Ext_V as SELECT [SoLenh],[SoGiaoNhan],[GiaoNhanDH],[GiaoNhanBe], [NhietKeSenSor],[MaSoTN] " & _
                          ",[CamKetCL],[KetTN],[KetTrai],[KetPhai],[KetBoong],[SoNiem],[CreateDate],[ID],'N' as CHECKUPD,SoNiemCon " & _
                             " FROM [tblLenhXuatE5Ext] ;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

                '======================================================================

                'select * from sys.all_objects  where upper(name) =upper('ThongTinBBGN_SAP')
            p_Error = ""

            p_SQL = " create PROCEDURE [dbo].[ThongTinBBGN_SAP_UPD] @p_User nvarchar(100),@p_Solenh nvarchar(50) AS BEGIN " & _
             "select  @p_User as UsrName, convert(nvarchar (20),getdate(),113)  as Sysdate, b.MaNgan,  b.SoLenh as ORDER_NO, b.LineID  as LINEID , " & _
                                "convert(nvarchar (10),ThoiGianDau ,112) as ZZERDAT, replace (convert(nvarchar (20),ThoiGianDau,108),':','')  as ZZERTIM " & _
                                ", convert(nvarchar (10),ThoiGianCuoi ,112) as ZZAEDAT, replace (convert(nvarchar (20),ThoiGianCuoi,108),':','')  as ZZAETIM " & _
                                ",MaEntry , a.MaPhuongTien, a.NguoiVanChuyen, b.TrangThai as FLG_HTTG, b.HeSo_k as  NhietDoXe, " & _
                                "(select top 1  ThongTinTDH from tblLenhXuatChiTietE5  k with ( nolock)  where k.Row_id=b.Row_id  ) as FLG_RUT_TDH " & _
                                ", a.BatchNum as BATCH_ND, SUBSTRING(REPLICATE('0', 18),1,18 - LEN(b.MaHangHoa)) + b.MaHangHoa  as MATNR, a.MaKhachHang  as CUSTOMER, a.MaPhuongTien as VEHICLE, b.MaLuuLuongKe  as METER_NO " & _
                                    ", convert(float , b.Sl_llkebd )  as  METER_START, convert(float, b.Sl_llkekt) as METER_END, b.SoLuongThucXuat as QUANTITY_CONFIRM " & _
                                    ", b.NhietDo as TEMP_CONFIRM ,  b.TyTrong_15 as DENS_COMFIRM, a.Niem as NIEM_TEXT " & _
                                                             "from FPT_tblLenhXuatChiTietE5_V b , tblLenhXuatE5 a  where b.SoLenh = @p_Solenh and a.SoLenh =b.SoLenh and a.Status ='5' END "

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""

            p_SQL = " create PROCEDURE [dbo].[ThongTinBBGN_SAP] @p_User nvarchar(100),@p_Solenh nvarchar(50) AS BEGIN " & _
             "select  @p_User as UsrName, convert(nvarchar (20),getdate(),113)  as Sysdate, b.MaNgan,  b.SoLenh as ORDER_NO, b.LineID  as LINEID , " & _
                                "convert(nvarchar (10),ThoiGianDau ,112) as ZZERDAT, replace (convert(nvarchar (20),ThoiGianDau,108),':','')  as ZZERTIM " & _
                                ", convert(nvarchar (10),ThoiGianCuoi ,112) as ZZAEDAT, replace (convert(nvarchar (20),ThoiGianCuoi,108),':','')  as ZZAETIM " & _
                                ",MaEntry , a.MaPhuongTien, a.NguoiVanChuyen, b.TrangThai as FLG_HTTG, b.HeSo_k as  NhietDoXe, " & _
                                "(select top 1  ThongTinTDH from tblLenhXuatChiTietE5  k with ( nolock)  where k.Row_id=b.Row_id  ) as FLG_RUT_TDH " & _
                                                             "from FPT_tblLenhXuatChiTietE5_V b , tblLenhXuatE5 a  where b.SoLenh = @p_Solenh and a.SoLenh =b.SoLenh and a.Status ='5' END "

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""

            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblLogSyn_Hist' AND xtype='U')" & _
                 "  begin CREATE TABLE [dbo].[tblLogSyn_Hist]([ID] [int] IDENTITY(1,1) NOT NULL, " & _
                        " [Para] [nvarchar](50) NULL,[SynDate] [nvarchar](10) NULL,[SynCount] [int] NULL, " & _
                        " [dDate] [datetime] NULL,[ToDate] [datetime] NULL,[sType] [nvarchar](10) NULL, " & _
                            " CONSTRAINT [PK_tblLogSyn_Hist] PRIMARY KEY CLUSTERED  " & _
                            " ([ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF " & _
                            " , ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If




            p_Error = ""

            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblKhachHang_TD' AND xtype='U')" & _
                 "  begin CREATE TABLE [dbo].[tblKhachHang_TD](	[ID] [int] IDENTITY(1,1) NOT NULL," & _
                            "[MaKhachHang] [nvarchar](150) NULL,	[MaTuyenDuong] [nvarchar](150) NULL," & _
                            "[CreateDate] [datetime] NULL,	[UpdateDate] [datetime] NULL,[CreateBy] [nvarchar](150) NULL," & _
                            "[UpdatedBy] [nvarchar](150) NULL,[Status] [nvarchar](50) NULL," & _
                            "CONSTRAINT [PK_tblKhachHang_TD] PRIMARY KEY CLUSTERED " & _
                            "(	[ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, " & _
                            "ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""

            p_SQL = " Create View FPT_tblKhachHang_TD_V as " & _
                            "SELECT A.[ID],A.[MaKhachHang],b.TenKhachHang , A.[MaTuyenDuong]," & _
                              " A.[CreateDate],A.[UpdateDate],A.[CreateBy],A.[UpdatedBy],A.[Status], 'N' as CHECKUPD" & _
                              " FROM [dbo].[tblKhachHang_TD] A, tblKhachHang b with (nolock) " & _
                             "	where a.MaKhachHang=b.MaKhachHang ;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


                ''Tao them field,  table
                ''SYS_USER
                '20200221
                ' 
                'alter table  tblLenhXuatE5 add PriceGroupDO1 nvarchar(100)
            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblLenhXuatE5','PriceGroupDO1') is null " & _
                    "  begin alter table  tblLenhXuatE5 add PriceGroupDO1 nvarchar(100)  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblLogSyn','dDate') is null " & _
                    "  begin alter table  tblLogSyn add dDate datetime  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblLenhXuat_hanghoaE5','ChietKhau') is null " & _
                    "  begin alter table  tblLenhXuat_hanghoaE5 add ChietKhau Decimal(15,4)  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If



            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblLenhXuatE5','SOType') is null " & _
                    "  begin alter  table  tblLenhXuatE5 add SOType nvarchar(50), PrcingDate datetime,  POType nvarchar(50), FromSoLenh nvarchar(50)    end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblLenhXuatE5','SCHUYEN') is null " & _
                    "  begin alter   table tblLenhXuatE5 add [PTXuat_ID] int , PTIEN nvarchar(200), SCHUYEN nvarchar(200)   end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""

            p_SQL = " if  COL_LENGTH('tbldonvi','HOUSE_UM') is null " & _
                    "  begin alter   table tbldonvi add HOUSE_UM nvarchar(200), STREET nvarchar(200) " & _
                        ", CITY nvarchar(200)  , COUNTRY nvarchar(200)   end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""

            p_SQL = " if  COL_LENGTH('tblDonVi','TenDonViHD') is null " & _
                    "  begin alter  table  tblDonVi add TenDonViHD nvarchar(2000), DiaChiHD nvarchar(2000)  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""

            p_SQL = " if  COL_LENGTH('SYS_USER','VatCancel') is null " & _
                    "  begin alter table SYS_USER add VatCancel nvarchar(20)  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If
            p_Error = ""
                '  p_SQL = "IF OBJECT_ID ('FPT_tblApprove_Mess_V', 'V') IS  NULL " & _
            p_SQL = " if  COL_LENGTH('tblChungTu','KeyCode') is null " & _
                 "  begin alter table tblChungTu add KeyCode nvarchar(200), ChietKhau decimal(10,4) , MaTraCuu nvarchar(200), " & _
                    "  MauSoHoaDon  nvarchar(200), KyHieuHoaDon  nvarchar(200), NgayVanDon datetime, SoVanDon nvarchar(500) end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

                'Tao table Ty gia
            p_Error = ""

            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblTyGia' AND xtype='U')" & _
                 "  begin CREATE TABLE [dbo].[tblTyGia]([ID] [int] IDENTITY(1,1) NOT NULL,[MANDT] [nvarchar](100) NULL, " & _
                                 "[KURST_CURR] [nvarchar](50) NULL,[FCURR_CURR] [nvarchar](50) NULL,[TCURR_CURR] [nvarchar](50) NULL, " & _
                                 "[GDATU_INV] [nvarchar](50) NULL,[UKURS_CURR] [decimal](18, 5) NULL,[FFAC_CURR] [decimal](18, 5) NULL, " & _
                                 "[TFACT_CURR] [decimal](18, 5) NULL,[CreatDate] [datetime] NULL,[UpdateDate] [datetime] NULL, " & _
                                 "[CreateUser] [nvarchar](150) NULL,[UpdateUser] [nvarchar](150) NULL, " & _
                                 "CONSTRAINT [PK_tblTyGia] PRIMARY KEY CLUSTERED ([ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF,  " & _
                                 "IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_Error = ""
            p_SQL = " if  COL_LENGTH('tblChungTu','TienThueGTGT') is null " & _
                    "  begin alter table tblChungTu add  " & _
                        " " & _
                        " TienThueGTGT decimal(16,2), TongTienTruocThue decimal(18,2), TongTienSauThue decimal(18,2)  end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""
                '  p_SQL = "IF OBJECT_ID ('FPT_tblApprove_Mess_V', 'V') IS  NULL " & _
            p_SQL = " if  COL_LENGTH('tblLenhXuatE5','DO1_SoLenh') is null " & _
                    "  begin alter table  tblLenhXuatE5 add DO1_SoLenh nvarchar(200), DO1_MaKhach nvarchar(2000) end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


            p_Error = ""
                '  p_SQL = "IF OBJECT_ID ('FPT_tblApprove_Mess_V', 'V') IS  NULL " & _
            p_SQL = " if  COL_LENGTH('ztblTankBarem','SyncDate') is null " & _
                    "  begin alter table ztblTankBarem  add SyncDate datetime end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_Error = ""
                '  p_SQL = "IF OBJECT_ID ('FPT_tblApprove_Mess_V', 'V') IS  NULL " & _
            p_SQL = " if  COL_LENGTH('ztblTankBarem','SyncUser') is null " & _
                    "  begin alter table ztblTankBarem  add SyncUser nvarchar(50) end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

            p_Error = ""
                '  p_SQL = "IF OBJECT_ID ('FPT_tblApprove_Mess_V', 'V') IS  NULL " & _
            p_SQL = " if  COL_LENGTH('tblConfig','CompanyName') is null " & _
                    "  begin alter table tblConfig  add CompanyName nvarchar(500) end;"

            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If
                '=============================================

                'select * into tblChungTuHuy from tblChungTu where 1=0 
            p_Error = ""

            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblChungTuHuy' AND xtype='U')" & _
               " begin select * , getdate () as NgayHuy, convert(nvarchar(200),'') as NguoiHuy, convert(nvarchar(2000),'') as LyDoHuy  into tblChungTuHuy from tblChungTu where 1=0  end; "
            If g_Services.Sys_Execute(p_SQL, _
                                    p_Error) = False Then

                End If

            p_Error = ""

            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblMaTraCuu' AND xtype='U')" & _
               " begin  CREATE TABLE [dbo].[tblMaTraCuu]([ID] [int] IDENTITY(1,1) NOT NULL," & _
                             "[MaTraCuu] [nvarchar](50) NULL,[SoLenh] [nvarchar](50) NULL," & _
                             "[CreateDate] [datetime] NULL,[CreateUser] [nvarchar](50) NULL,SyncStatus nvarchar(20), SyncDate datetime," & _
                            " MauSoHoaDon nvarchar(200),  KyHieuHoaDon nvarchar(200),  SoHoaDon nvarchar(200), CONSTRAINT [PK_tblMaTraCuu] PRIMARY KEY CLUSTERED " & _
                            "([ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF " & _
                            ", ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] end; "
            If g_Services.Sys_Execute(p_SQL, _
                                    p_Error) = False Then

                End If
                '====================================================



            p_Error = ""

            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblKyHieuHoaDon' AND xtype='U')" & _
               " begin  CREATE TABLE [dbo].[tblKyHieuHoaDon]([LoaiHD] [nvarchar](50) NOT NULL, " & _
             "[MauSo] [nvarchar](50) NOT NULL,[KyHieu] [nvarchar](50) NOT NULL," & _
             "[KyHieuKLT] [nvarchar](50) NULL) ON [PRIMARY] end; "
            If g_Services.Sys_Execute(p_SQL, _
                                    p_Error) = False Then

                End If
                '====================================================
            p_Error = ""

            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblStructureView' AND xtype='U')" & _
               " begin  CREATE TABLE [dbo].[tblStructureView]([UserName] [nvarchar](50) NOT NULL, " & _
             "[FormName] [nvarchar](500) NOT NULL,[TrueGridName] [nvarchar](500) NOT NULL," & _
             "[GridViewName] [nvarchar](500) not NULL, GridXml nvarchar(max), CreateUser nvarchar(200), UpdateDate datetime ) ON [PRIMARY] end; "
            If g_Services.Sys_Execute(p_SQL, _
                                    p_Error) = False Then

                End If

                '====================================================
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblThongTinHoaDonDT' AND xtype='U')" & _
               " begin  CREATE TABLE [dbo].[tblThongTinHoaDonDT]([ID] [int] NOT NULL," & _
                              "[SoLenh] [nvarchar](50) NULL,[MaTraCuu] [nvarchar](50) NULL," & _
                              "[SoHD] [nvarchar](50) NULL,[KyHieu] [nvarchar](50) NULL," & _
                              "[sSerial] [nvarchar](50) NULL,[sForm] [nvarchar](50) NULL," & _
                              "[NgayHD] [datetime] NULL,[CreateDate] [datetime] NULL," & _
                              "[CreateUser] [nvarchar](50) NULL, CONSTRAINT [PK_tblThongTinHoaDonDT] PRIMARY KEY CLUSTERED  " & _
                             "([ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, " & _
                             "ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] end; "
            If g_Services.Sys_Execute(p_SQL, _
                                    p_Error) = False Then

                End If


                '====================================================
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblHDDT_Messages' AND xtype='U')" & _
               " begin  CREATE TABLE [dbo].[tblHDDT_Messages]([ID] [int] IDENTITY(1,1) NOT NULL,[Code] [nvarchar](500) NULL, " & _
                     "[sDescription] [nvarchar](max) NULL,[sNote] [nvarchar](max) NULL,[FunctionName] [nvarchar](500) NULL, " & _
                     "CONSTRAINT [PK_tblHDDT_Messages] PRIMARY KEY CLUSTERED ([ID] ASC " & _
                    ")WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON " & _
                    ", ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] end; "
            If g_Services.Sys_Execute(p_SQL, _
                                    p_Error) = False Then

                End If


                '====================================================
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblGiaoNhan_HangHoa' AND xtype='U')" & _
               " begin  CREATE TABLE [dbo].[tblGiaoNhan_HangHoa]([ID] [int] IDENTITY(1,1) NOT NULL," & _
                         " [MaTuyenDuong] [nvarchar](50) NOT NULL,[MaHangHoa] [nvarchar](50) NOT NULL," & _
                         " [Status] [nvarchar](50) NULL,[CreateDate] [datetime] NULL," & _
                         " [CreateUser] [nvarchar](50) NULL, CONSTRAINT [PK_tblGiaoNhan_HangHoa] PRIMARY KEY CLUSTERED  " & _
                        " ([ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, " & _
                        " ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] " & _
                        " ALTER TABLE [dbo].[tblGiaoNhan_HangHoa] ADD  CONSTRAINT [DF_tblGiaoNhan_HangHoa_CreateDate] " & _
                          " DEFAULT (getdate()) FOR [CreateDate] end ;"
                'p_SQL = p_SQL & "CREATE VIEW [dbo].[tblGiaoNhan_HangHoa_V] AS  " & _
                '                    " SELECT        a.ID, a.MaTuyenDuong, b.DGDiemDen, a.MaHangHoa, c.TenHangHoa, a.Status, 'N' AS CHECKUPD " & _
                '                    " FROM            dbo.tblGiaoNhan_HangHoa AS a INNER JOIN " & _
                '                    " dbo.tblGiaoNhan AS b ON a.MaTuyenDuong = b.MaTuyenDuong INNER JOIN " & _
                '                    " dbo.tblHangHoa AS c ON a.MaHangHoa = c.MaHangHoa;"
            If g_Services.Sys_Execute(p_SQL, _
                                    p_Error) = False Then

                End If
                '====================================================
            p_Error = ""
                '  p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblGiaoNhan_HangHoa_V' AND xtype='U')"
                '" begin  CREATE TABLE [dbo].[tblGiaoNhan_HangHoa]([ID] [int] IDENTITY(1,1) NOT NULL," & _
                '          " [MaTuyenDuong] [nvarchar](50) NOT NULL,[MaHangHoa] [nvarchar](50) NOT NULL," & _
                '          " [Status] [nvarchar](50) NULL,[CreateDate] [datetime] NULL," & _
                '          " [CreateUser] [nvarchar](50) NULL, CONSTRAINT [PK_tblGiaoNhan_HangHoa] PRIMARY KEY CLUSTERED  " & _
                '         " ([ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, " & _
                '         " ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY] " & _
                '         " ALTER TABLE [dbo].[tblGiaoNhan_HangHoa] ADD  CONSTRAINT [DF_tblGiaoNhan_HangHoa_CreateDate] " & _
                '           " DEFAULT (getdate()) FOR [CreateDate]; end "
            p_SQL = " CREATE VIEW [dbo].[tblGiaoNhan_HangHoa_V] AS  " & _
                                " SELECT        a.ID, a.MaTuyenDuong, b.DGDiemDen, a.MaHangHoa, c.TenHangHoa, a.Status, 'N' AS CHECKUPD " & _
                                " FROM            dbo.tblGiaoNhan_HangHoa AS a INNER JOIN " & _
                                " dbo.tblGiaoNhan AS b ON a.MaTuyenDuong = b.MaTuyenDuong INNER JOIN " & _
                                " dbo.tblHangHoa AS c ON a.MaHangHoa = c.MaHangHoa "
            If g_Services.Sys_Execute(p_SQL, _
                                    p_Error) = False Then

                End If


            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblChungTuLine' AND xtype='U')" & _
              " begin CREATE TABLE [dbo].[tblChungTuLine]([SoLenh] [nvarchar](20) NULL," & _
                     "[TableID] [nvarchar](200) NULL,[LineID] [nvarchar](20) NULL," & _
                     "[MaHangHoa] [nvarchar](100) NULL,[TenHangHoa] [nvarchar](2000) NULL," & _
                     "[DonViTinh] [nvarchar](10) NULL,[SoLuongDuXuat] [decimal](18, 2) NULL," & _
                     "[SoLuongThucXuat] [decimal](18, 2) NULL,[L15] [decimal](18, 2) NULL," & _
                     "[KG] [decimal](18, 2) NULL,[VCF] [decimal](6, 4) NULL,[WCF] [decimal](6, 4) NULL," & _
                     "[NhietDo] [decimal](8, 2) NULL,[TyTrong] [decimal](6, 4) NULL,[DonGia] [decimal](18, 6) NULL," & _
                     "[TongTIen] [decimal](18, 2) NULL,[KeyCode] [nvarchar](50) NULL,[MaVanChuyen] [nvarchar](50) NULL," & _
                     "[XITEC_OPTION] [nvarchar](50) NULL,[ChietKhau] [decimal](18, 6) NULL,[NgayXuat] [datetime] NULL," & _
                     "[MaLenh] [nvarchar](10) NULL,[LoaiTien] [nvarchar](50) NULL,[SoLuong] [decimal](18, 2) NULL, [Row_ID] [int] IDENTITY(1,1) NOT NULL," & _
                        "CONSTRAINT [PK_tblChungTuLine] PRIMARY KEY CLUSTERED " & _
                        "([Row_ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, " & _
                        "ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] end; "
            If g_Services.Sys_Execute(p_SQL, _
                                    p_Error) = False Then

                End If



            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblChungTuLineHuy' AND xtype='U')" & _
              " begin CREATE TABLE [dbo].[tblChungTuLine]([SoLenh] [nvarchar](20) NULL," & _
                     "[TableID] [nvarchar](200) NULL,[LineID] [nvarchar](20) NULL," & _
                     "[MaHangHoa] [nvarchar](100) NULL,[TenHangHoa] [nvarchar](2000) NULL," & _
                     "[DonViTinh] [nvarchar](10) NULL,[SoLuongDuXuat] [decimal](18, 2) NULL," & _
                     "[SoLuongThucXuat] [decimal](18, 2) NULL,[L15] [decimal](18, 2) NULL," & _
                     "[KG] [decimal](18, 2) NULL,[VCF] [decimal](6, 4) NULL,[WCF] [decimal](6, 4) NULL," & _
                     "[NhietDo] [decimal](8, 2) NULL,[TyTrong] [decimal](6, 4) NULL,[DonGia] [decimal](18, 6) NULL," & _
                     "[TongTIen] [decimal](18, 2) NULL,[KeyCode] [nvarchar](50) NULL,[MaVanChuyen] [nvarchar](50) NULL," & _
                     "[XITEC_OPTION] [nvarchar](50) NULL,[ChietKhau] [decimal](18, 6) NULL,[NgayXuat] [datetime] NULL," & _
                     "[MaLenh] [nvarchar](10) NULL,[LoaiTien] [nvarchar](50) NULL,[SoLuong] [decimal](18, 2) NULL, [Row_ID] [int] IDENTITY(1,1) NOT NULL," & _
                        "CONSTRAINT [PK_tblChungTuLine] PRIMARY KEY CLUSTERED " & _
                        "([Row_ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, " & _
                        "ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] end; "
            If g_Services.Sys_Execute(p_SQL, _
                                    p_Error) = False Then

                End If
                '====================================================
                '====================================================
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblHoaDonDienTuKey' AND xtype='U') " & _
               " begin CREATE TABLE [dbo].[tblHoaDonDienTuKey]([KeyCode] [uniqueidentifier] NOT NULL," & _
                         "[CreateDate] [datetime] NULL,[CreatUser] [nvarchar](50) NULL, " & _
                         "[SoLenh] [nvarchar](50) NULL, CONSTRAINT [PK_tblHoaDonDienTuKey] PRIMARY KEY CLUSTERED  " & _
                        "([KeyCode] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,  " & _
                        "ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] end; "
            If g_Services.Sys_Execute(p_SQL, _
                                    p_Error) = False Then

                End If
                '====================================================

            p_Error = ""

            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblApprove_Mess' AND xtype='U')" & _
               " begin  CREATE TABLE [dbo].[tblApprove_Mess](" & _
            "[Createby] [nvarchar](30) NULL,[UpdatedBy] [nvarchar](30) NULL," & _
           "[CreateDate] [datetime] NULL,	[UpdateDate] [datetime] NULL, [sDesc] [nvarchar](800) NOT NULL,[ID] [int] IDENTITY(1,1) NOT NULL," & _
               " CONSTRAINT [PK_tbl_name] PRIMARY KEY CLUSTERED ( [ID] Asc" & _
               " ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] " & _
               ") ON [PRIMARY] end; "
            If g_Services.Sys_Execute(p_SQL, _
                                    p_Error) = False Then

                End If
                'anhqh 20190411
                'Tao them 2 bang luu thong tin phan quyen bao cao cho KV2
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='SYS_CONFIG_RPT_GROUP' AND xtype='U') begin" & _
                 " create table SYS_CONFIG_RPT_GROUP (Code nvarchar(50) not null, Name nvarchar(500) " & _
                        ",Status nvarchar(10), CreateDate datetime, UpdateDate datetime " & _
                        ",Createby nvarchar(100), UpdatedBy nvarchar(100)); " & _
                " create table SYS_CONFIG_RPT_GROUP1 ([Row_id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL, " & _
                        " Code nvarchar(50) not null, ReportCode nvarchar(100) " & _
                        ",fromdate datetime, ToDate datetime, CreateDate datetime, UpdateDate datetime " & _
                        ",Createby nvarchar(100), UpdatedBy nvarchar(100), sDesc nvarchar(2000)); " & _
                    "  end; "
            If g_Services.Sys_Execute(p_SQL, _
                                    p_Error) = False Then

                End If


            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblNhietDo' AND xtype='U') begin" & _
                " CREATE TABLE [dbo].[tblNhietDo](" & _
                    " [ID] [int] IDENTITY(1,1) NOT NULL, [NhietDo] [decimal](10, 3) NULL, " & _
                    "[CrDate]  [datetime] NULL,[Createby] [nvarchar](200) NULL,[UpdatedBy] [nvarchar](200) NULL," & _
                " [CreateDate] [datetime] NULL,[UpdateDate] [datetime] NULL," & _
                   "CONSTRAINT [PK_tblNhietDo] PRIMARY KEY CLUSTERED (	[ID] ASC " & _
                   ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY] " & _
                   "  end; "
            p_Error = ""
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If


                '20190520
                'them bang luu thong tin Danh mục bể TBĐMTĐ chuyển sang đo tay
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='zTankListATG_AM' AND xtype='U') begin" & _
                    " CREATE TABLE [dbo].[zTankListATG_AM]([ID] [int] IDENTITY(1,1) NOT NULL," & _
                     "[TankCode] [nvarchar](50) NULL,	[CrDate] [datetime] NULL  DEFAULT (getdate())," & _
                     "[CrUser] [nvarchar](50) NULL,[UpdDate] [datetime] NULL,[UpdUser] [nvarchar](500) NULL," & _
                     "[FromDate] [datetime] NULL,[ToDate] [datetime] NULL,[UpdateDate] [datetime] NULL," & _
                     "[UpdatedBy] [nvarchar](100) NULL,[Createby] [nvarchar](100) NULL," & _
                     "[Product] [nvarchar](100) NULL, CONSTRAINT [PK_zTankListATG_AM] PRIMARY KEY CLUSTERED " & _
                    "([ID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON," & _
                     "ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY] end; "

            p_Error = ""
            If g_Services.Sys_Execute(p_SQL, _
                                     p_Error) = False Then

                End If
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='zTankListATG_AM_HIST' AND xtype='U') begin  " & _
                    "CREATE TABLE [dbo].[zTankListATG_AM_HIST]( [ID] [int] NULL," & _
                         " [TankCode] [nvarchar](50) NULL,[CrDate] [datetime] NULL,[CrUser] [nvarchar](50) NULL," & _
                         " [UpdDate] [datetime] NULL,[UpdUser] [nvarchar](500) NULL,[FromDate] [datetime] NULL," & _
                         " [ToDate] [datetime] NULL,[sStatus] [nvarchar](10) NULL,[dDate] [datetime] NULL," & _
                         " [UpdateDate] [datetime] NULL,[UpdatedBy] [nvarchar](100) NULL,[Createby] [nvarchar](100) NULL," & _
                         " [Product] [nvarchar](100) NULL) end ; "
            p_Error = ""
            If g_Services.Sys_Execute(p_SQL, _
                                     p_Error) = False Then

                End If
                '============================================================
                '  p_SQL = "IF OBJECT_ID ('FPT_tblApprove_Mess_V', 'V') IS  NULL " & _
            p_SQL = " if  COL_LENGTH('ztblTankBarem','SyncUser') is null " & _
                    "  begin alter table ztblTankBarem  add SyncUser nvarchar(50) end;"
            p_Error = ""
            If g_Services.Sys_Execute(p_SQL, _
                                        p_Error) = False Then

                End If
                '20190411
                'anhqh
                'Them truong de phan quyen theo bao cao
            p_SQL = " if  COL_LENGTH('SYS_USER','ReportGroup') is null " & _
                  "  begin alter table SYS_USER  add ReportGroup nvarchar(2000) end;"
            p_Error = ""
            If g_Services.Sys_Execute(p_SQL, _
                                        p_Error) = False Then

                End If

                'anhqh
                '20171116
                'tam bo di
                'p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblNhietDo' AND xtype='U') begin" & _
                '    " CREATE TABLE [dbo].[tblNhietDo](" & _
                '        " [ID] [int] IDENTITY(1,1) NOT NULL, [NhietDo] [decimal](10, 3) NULL, " & _
                '        "[Createby] [nvarchar](200) NULL,[UpdatedBy] [nvarchar](200) NULL," & _
                '    " [CrDate]  [datetime] NULL,[CreateDate] [datetime] NULL,[UpdateDate] [datetime] NULL," & _
                '       "CONSTRAINT [PK_tblNhietDo] PRIMARY KEY CLUSTERED (	[ID] ASC " & _
                '       ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY] " & _
                '       "  end; "




                'p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblPhuongTien_Infor' AND xtype='U')  " & _
                '            " begin  CREATE TABLE [dbo].[tblPhuongTien_Infor](" & _
                '             " [ID] [int] IDENTITY(1,1) NOT NULL,	[MaPhuongTien] [nvarchar](50) NULL, " & _
                '             " [NoiDung] [nvarchar](500) NULL,	[FromDate] [datetime] NULL, " & _
                '             " [ToDate] [datetime] NULL,	[sType] [nvarchar](5) NULL, " & _
                '                " CONSTRAINT [PK_tblPhuongTien_Infor] PRIMARY KEY CLUSTERED  (	[ID] ASC " & _
                '                " )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, " & _
                '                " ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]  end;"

                'p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblPhuongTien_LaiXe' AND xtype='U')  " & _
                '            "begin  CREATE TABLE [dbo].[tblPhuongTien_LaiXe](" & _
                '         " [ID] [int] IDENTITY(1,1) NOT NULL,	[MaPhuongTien] [nvarchar](50) NULL, " & _
                '         " [HoVaTen] [nvarchar](500) NULL,	[NoiDung] [nvarchar](500) NULL," & _
                '            " [FromDate] [datetime] NULL,	[ToDate] [datetime] NULL,[sType] [nvarchar](5) NULL,[sDefault] [nvarchar](5) NULL," & _
                '                " CONSTRAINT [PK_tblPhuongTien_LaiXe] PRIMARY KEY CLUSTERED " & _
                '                "(	[ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, " & _
                '                " ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]  end;"


                'p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblPhuongTien_TaiTrong' AND xtype='U')  " & _
                '        " begin CREATE TABLE [dbo].[tblPhuongTien_TaiTrong]([MaPhuongTien] [nvarchar](50) NULL, [ID] [int] IDENTITY(1,1) NOT NULL,  [TuNgay] [datetime] NULL,   " & _
                '             " [DenNgay] [datetime] NULL,[TaiTrong] [numeric](18, 0) NULL,[Createby] [nvarchar](50) NULL, [UpdatedBy] [nvarchar](50) NULL," & _
                '             "[CreateDate] [datetime] NULL,[UpdateDate] [datetime] NULL, CONSTRAINT [PK_tblPhuongTien_TaiTrong] PRIMARY KEY CLUSTERED " & _
                '            " (	[ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, " & _
                '            " ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]   end;"


                'p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='SYS_TABLEID_NEW' AND xtype='U')  " & _
                '                    " begin CREATE TABLE [dbo].[SYS_TABLEID_NEW]( " & _
                '                     "[TableID] [nvarchar](50) NULL, " & _
                '                     "[CrdDate] [date] NULL, " & _
                '                     "[SoLenh] [nvarchar](50) NULL, " & _
                '                     "[ID] [int] IDENTITY(1,1) NOT NULL, " & _
                '                        "CONSTRAINT [PK_SYS_TABLEID_NEW] PRIMARY KEY CLUSTERED  " & _
                '                        "(	[ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, " & _
                '                        "ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY]   end;"

                ''anhqh
                ''20170926
                ''Them bang luu Purchasing Org

                'p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE upper(name)=upper('tblKhachHang_Org') AND xtype='U')  " & _
                '                    " begin CREATE TABLE [tblKhachHang_Org]([Purchasing_Org] [nvarchar](50) NOT NULL," & _
                '                     "[Desciption] [nvarchar](500) NOT NULL) ON [PRIMARY]   end;"


                ''anhqh
                ''2011116
                ''Them bang luu lich su thay doi phuong tien

                'p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE upper(name)=upper('tblPhuongTien_Hist') AND xtype='U')  " & _
                '                    " begin " & _
                '                    " CREATE TABLE [dbo].[tblPhuongTien_Hist]([MaPhuongTien] [nvarchar](10)  NULL," & _
                '                     " [LaiXe] [nvarchar](30) NULL,[SoNgan] [int] NULL,[NgayBatDau] [nvarchar](10) NULL, " & _
                '                     " [NgayHieuLuc] [nvarchar](10) NULL,[Status] [char](2) NULL,[SyncDate] [datetime] NULL, " & _
                '                     " [iweight] [int] NULL,[Createby] [nvarchar](30) NULL,[UpdatedBy] [nvarchar](30) NULL," & _
                '                     " [CreateDate] [datetime] NULL,[UpdateDate] [datetime] NULL,UpdStatus [nvarchar](5))  " & _
                '                    " end;"



                ''anhqh
                ''20170926
                ''Them bang luu tblProjects va tblProject_Details

                'p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE upper(name)=upper('tblProjects') AND xtype='U')  " & _
                '                    " begin CREATE TABLE [tblProjects]([Auart] [nvarchar](50) NULL,[Guebg] [nvarchar](50) NULL," & _
                '                     "[Gueen] [nvarchar](50) NULL,[Inco1] [nvarchar](50) NULL,[Kunnr] [nvarchar](50) NULL," & _
                '                     "[Matnr] [nvarchar](50) NULL,[Meins] [nvarchar](50) NULL,[Posnr] [nvarchar](50) NULL," & _
                '                     "[Spart] [nvarchar](50) NULL,[Vbeln] [nvarchar](50) NOT NULL,[Vbtyp] [nvarchar](50) NULL," & _
                '                     "[Vkorg] [nvarchar](50) NULL,[Vtweg] [nvarchar](50) NULL," & _
                '                        "CONSTRAINT [PK_tblProjects] PRIMARY KEY CLUSTERED " & _
                '                        "([Vbeln] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, " & _
                '                    "ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] end;"

                'p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE upper(name)=upper('tblProject_Details') AND xtype='U')  " & _
                '                   " begin CREATE TABLE [tblProject_Details]([Auart] [nvarchar](50) NULL,[Guebg] [nvarchar](50) NULL," & _
                '                    "[Gueen] [nvarchar](50) NULL,[Inco1] [nvarchar](50) NULL,[Kunnr] [nvarchar](50) NULL," & _
                '                    "[Matnr] [nvarchar](50) NULL,[Meins] [nvarchar](50) NULL,[Posnr] [nvarchar](50) NULL," & _
                '                    "[Spart] [nvarchar](50) NULL,[Vbeln] [nvarchar](50) NOT NULL,[Vbtyp] [nvarchar](50) NULL," & _
                '                    "[Vkorg] [nvarchar](50) NULL,[Vtweg] [nvarchar](50) NULL)  ON [PRIMARY] end;"

                ''anhqh
                ''20170313
                ''Them bang luu chi tiet gia tri thuc xuat, du xuat day len SAP theo hang hoa 
                'p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblHangHoa_SoLuongSAP' AND xtype='U') begin" & _
                '     " create table tblHangHoa_SoLuongSAP (MaHangHoa nvarchar(50), TONGDUXUAT int,TONGDUXUAT_THUY	int) end; "
                ''anhqh
                ''20170313
                ''Them bang luu chi tiet gia tri thuc xuat, du xuat day len SAP theo hang hoa 
                'p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblKhachHang_SoLuongSAP' AND xtype='U') begin" & _
                '     " create table tblKhachHang_SoLuongSAP (MaKhachHang nvarchar(50), TONGDUXUAT int,TONGDUXUAT_THUY	int) end; "
                ''===========================================


                'p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblTankActive_Arm_Hist' AND xtype='U')  " & _
                '                    " begin CREATE TABLE [dbo].[tblTankActive_Arm_Hist]( " & _
                '                    " [MeterId] [varchar](50) NULL, " & _
                '                    "  [LoadingSite] [nvarchar](50) NULL, " & _
                '                     " [ArmNo] [int] NULL, " & _
                '                     " [ProductCode] [nvarchar](50) NULL, " & _
                '                     " [Name_ND] [nvarchar](50) NULL, " & _
                '                     " [CrdDate] [datetime] NULL, " & _
                '                     " [UserName] [nvarchar](50) NULL, " & _
                '                     " [RecordDel] [nvarchar](10) NULL, " & _
                '                     " [Dens] [decimal](18, 4) NULL, ArmNo_Table int ) ON [PRIMARY]   end;"


                'p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblBatchSlog' AND xtype='U')  "
                'p_SQL = p_SQL & "begin CREATE TABLE [dbo].[tblBatchSlog](" & _
                '             "[ID] [int] IDENTITY(1,1) NOT NULL," & _
                '             "[BatchCode] [nvarchar](50) NULL," & _
                '             "[SlogValue] [nvarchar](50) NULL," & _
                '             "CONSTRAINT [PK_tblBatchSlog] PRIMARY KEY CLUSTERED " & _
                '            "([ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, " & _
                '            "ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] end;"
                'p_SQL = p_SQL & " IF  EXISTS (SELECT * FROM sysobjects WHERE name='tblBatchSlog' AND xtype='U')  " & _
                '         "CREATE UNIQUE NONCLUSTERED INDEX [BatchSlog_Ind] ON [dbo].[tblBatchSlog] " & _
                '            "(	[BatchCode] ASC,[SlogValue] ASC " & _
                '            ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]"

                'If g_Services.Sys_Execute(p_SQL, _
                '                             p_Error) = False Then

                'End If
                '20190416
                'Bang luu lich su login
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='SYS_USER_Login' AND xtype='U')  "
            p_SQL = p_SQL & "begin "
            p_SQL = p_SQL & "CREATE TABLE [dbo].[SYS_USER_Login](" & _
                             "[id] [numeric](18, 0) IDENTITY(1,1) NOT NULL, " & _
                             "[USER_NAME] [nvarchar](200) NULL, " & _
                             "[LAST_LOGON_DATE] [datetime] NULL, " & _
                             "[IP_ADDRESS] [nvarchar](200) NULL, " & _
                             "[LOGIN_WORK_STATION] [nvarchar](200) NULL, " & _
                             "[LOGIN_IP_ADDRESS] [nvarchar](200) NULL, " & _
                             "CONSTRAINT [PK_SYS_USER_Login] PRIMARY KEY CLUSTERED (	[id] ASC " & _
                                ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, " & _
                             "ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY] end;"

            If g_Services.Sys_Execute(p_SQL, _
                                         p_Error) = False Then

                End If




            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblChiTietPhuongTien_Hist' AND xtype='U')  "
            p_SQL = p_SQL & "begin "
            p_SQL = p_SQL & " CREATE TABLE [dbo].[tblChiTietPhuongTien_Hist](	[MaNgan] [nvarchar](3)  NULL," & _
                             "[MaPhuongTien] [nvarchar](10)  NULL,[SoLuongMax] [decimal](18, 0) NULL," & _
                             "[Createby] [nvarchar](30) NULL,[UpdatedBy] [nvarchar](30) NULL,[CreateDate] [datetime] NULL,[UpdateDate] [datetime] NULL," & _
                             "[Status] [char](2) NULL,[SyncDate] [datetime] NULL	,[UpdStatus] nvarchar(2)) end;"

            If g_Services.Sys_Execute(p_SQL, _
                                         p_Error) = False Then

                End If

            p_Error = ""
                'anhqh
                '20180320
                'them bang lay them bang gia phi van tai  tblDonGia_Ex
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblDonGia_Ex' AND xtype='U')  "
            p_SQL = p_SQL & "begin "
            p_SQL = p_SQL & " CREATE TABLE [dbo].[tblDonGia_Ex](	[IID] [int] IDENTITY(1,1) NOT NULL," & _
                     " [KAPPL] [nvarchar](50) NULL,[KSCHL] [nvarchar](50) NULL,[BUKRS] [nvarchar](50) NULL," & _
                     " [VSART] [nvarchar](50) NULL,[TDLNR] [nvarchar](50) NULL,[KNOTA] [nvarchar](50) NULL," & _
                     " [OIGKNOTD] [nvarchar](50) NULL,[MATNR] [nvarchar](50) NULL,[VRKME] [nvarchar](50) NULL," & _
                     " [KFRST] [nvarchar](50) NULL,[DATBI] [datetime] NULL,[DATAB] [datetime] NULL," & _
                     " [KBSTAT] [nvarchar](50) NULL,[KNUMH] [nvarchar](50) NULL,[KBETR] [numeric](18, 6) NULL," & _
                     " [WAERS] [nvarchar](50) NULL,[KPEIN] [numeric](18, 0) NULL,[KMEIN] [nvarchar](50) NULL," & _
                     " [ALAND] [nvarchar](50) NULL,[KONDA] [nvarchar](50) NULL,[INCO1] [nvarchar](50) NULL," & _
                     " [INCO2] [nvarchar](50) NULL, [sUser] [nvarchar](50) NULL, [dDate] DateTime NULL,  CONSTRAINT [PK_tblDonGia_Ex] PRIMARY KEY CLUSTERED (	[IID] ASC" & _
                        " ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, " & _
                        " ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] end;"

            If g_Services.Sys_Execute(p_SQL, _
                                        p_Error) = False Then

                End If
                'anhqh
                '20180320   
                'them bang lay them bang luu ma tra cuu hoa don dien tu  tblHoaDonDienTu
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblHoaDonDienTu' AND xtype='U')  "
            p_SQL = p_SQL & "begin "
            p_SQL = p_SQL & " CREATE TABLE [dbo].[tblHoaDonDienTu](	[ID] [int] NOT NULL,[VBELN] [nvarchar](50) NULL, " & _
                     " [POSNR] [int] NULL,[SEQ_NMBR] [nvarchar](50) NULL,[CUSNAME] [nvarchar](1500) NULL, " & _
                     " [DIACHI] [nvarchar](1500) NULL,[MST] [nvarchar](50) NULL,[MATNR] [nvarchar](50) NULL, " & _
                     " [SOHOADON] [nvarchar](50) NULL,[LTT] [decimal](18, 2) NULL,[LTT_DES] [nvarchar](50) NULL, " & _
                     " [MATRACUU] [nvarchar](50) NULL, [sUser] [nvarchar](50) NULL, [dDate] DateTime NULL,  CONSTRAINT [PK_tblHoaDonDienTu] PRIMARY KEY CLUSTERED  " & _
                    " ([ID] ASC ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, " & _
                     " ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] end;"
            If g_Services.Sys_Execute(p_SQL, _
                                        p_Error) = False Then

                End If


            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblPhuongTien_Hist' AND xtype='U')  "
            p_SQL = p_SQL & "begin "
            p_SQL = p_SQL & " CREATE TABLE [dbo].[tblPhuongTien_Hist]([MaPhuongTien] [nvarchar](10) NULL," & _
                        " [LaiXe] [nvarchar](30) NULL,[SoNgan] [int] NULL,[NgayBatDau] [nvarchar](10) NULL," & _
                     " [NgayHieuLuc] [nvarchar](10) NULL,[Status] [char](2) NULL,[SyncDate] [datetime] NULL," & _
                     " [iweight] [int] NULL,[Createby] [nvarchar](30) NULL,[UpdatedBy] [nvarchar](30) NULL," & _
                     " [CreateDate] [datetime] NULL,[UpdateDate] [datetime] NULL,[UpdStatus] [nvarchar](5) NULL) ON [PRIMARY] end;"

            If g_Services.Sys_Execute(p_SQL, _
                                         p_Error) = False Then

                End If


                'anhqh
                '20180123
                'bang tạm lưu thông tin giá trị line đẩy lên sap nội dung pha chế
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblLenhXuatE5_ToSAP' AND xtype='U')  "
            p_SQL = p_SQL & "begin "
            p_SQL = p_SQL & " CREATE TABLE [dbo].[tblLenhXuatE5_ToSAP](SoLenh nvarchar(50), TableID nvarchar(50), MaLenh nvarchar(20)" & _
                                                ", LineID nvarchar(10), NgayXuat nvarchar(150), UserID nvarchar(50), [CreateDate] [datetime] " & _
                                                ", Row_ID int, MaNgan nvarchar(20),ID int IDENTITY(1,1) NOT NULL  CONSTRAINT [PK_tblLenhXuatE5_ToSAP] PRIMARY KEY CLUSTERED " & _
                                                    "( [ID] Asc )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, " & _
                                                        " ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] ) ON [PRIMARY] end;"

            If g_Services.Sys_Execute(p_SQL, _
                                         p_Error) = False Then

                End If

                'anhqh
                '20180601
                'Them bang luu log chay services FPTAPIERR
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='FPTAPIERR' AND xtype='U')  "
            p_SQL = p_SQL & "begin "
            p_SQL = p_SQL & " CREATE TABLE [dbo].[FPTAPIERR](	RunDate datetime," & _
                             "[StrSQL] [nvarchar](4000)  NULL,[Err_Mess] [nvarchar](4000) NULL,[CompanyCode] [nvarchar](4000))end;"

            If g_Services.Sys_Execute(p_SQL, _
                                         p_Error) = False Then

                End If


                'anhqh
                '20180601
                'Them bang luu log chay services FPTAPIERR
            p_Error = ""
            p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='FPTSapToHTTG' AND xtype='U')  "
            p_SQL = p_SQL & "begin "
            p_SQL = p_SQL & " CREATE TABLE [dbo].[FPTSapToHTTG](RunDate datetime," & _
                             "SynStatus nvarchar(10), SynStartDate datetime, SynEndDate datetime) end;"

            If g_Services.Sys_Execute(p_SQL, _
                                         p_Error) = False Then

                End If



                ''Tao view
            p_Error = ""
            p_SQL = ""

            p_Error = "F"

            p_SQL = "  select  COL_LENGTH('SYS_FUNCTION_V','PARVALUE')  as sCol  "

            p_Table = g_Services.Sys_SYS_GET_DATATable_Des(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    If p_Table.Rows(0).Item(0).ToString.Trim <> "" Then
                        p_Error = "T"
                        End If

                    End If
                End If
            If p_Error = "F" Then
                p_Error = ""
                p_SQL = "   ALTER VIEW [dbo].[SYS_FUNCTION_V] AS " & _
                   "SELECT     A.FUNCTION_ID, A.FORM_ID, A.FUNCTION_NAME, B.FORM_NAME, A.DESCRIPTION, A.FROM_DATE, A.TO_DATE, A.WORK_STATION, A.IP_ADDRESS, 'N' AS CheckUpd, " & _
                   "B.PROJECT_CODE, A.PARVALUE FROM  dbo.SYS_FUNCTION AS A INNER JOIN dbo.SYS_FORMS AS B ON A.FORM_ID = B.FORM_ID;"
                If g_Services.Sys_Execute(p_SQL, _
                                             p_Error) = False Then

                    End If
                End If



            p_Error = ""
            p_SQL = " CREATE VIEW [dbo].[FPT_tblApprove_Mess_V] as  " & _
            "SELECT [Createby],[UpdatedBy],[CreateDate],[UpdateDate],[sDesc],[ID],'N' as CHECKUPD " & _
                " FROM [tblApprove_Mess]  GO "
            If g_Services.Sys_Execute(p_SQL, _
                                         p_Error) = False Then

                End If

                '20190520
                'Them View
            p_Error = ""
            p_SQL = "CREATE VIEW [dbo].[zTankListATG_AM_V] AS SELECT     ID, TankCode, Product, CrDate, CrUser, UpdDate," & _
                    "UpdUser, FromDate, ToDate, 'N' AS CHECKUPD FROM         dbo.zTankListATG_AM  "
            If g_Services.Sys_Execute(p_SQL, _
                                       p_Error) = False Then

                End If

            p_Error = ""
            p_SQL = "CREATE view  [dbo].[zTankListATG_AM_Hist_v] as select a.*, b.TenHangHoa, 'N' as CHECKUPD  " & _
                    " from zTankListATG_AM_Hist a , tblHangHoa b where a.Product =b.MaHangHoa   "
            If g_Services.Sys_Execute(p_SQL, _
                                      p_Error) = False Then

                End If

                ''=====================================================================

            p_Error = ""
            p_SQL = " create view  tblChiTietPhuongTien_Hist_V as " & _
                    " SELECT ROW_NUMBER() OVER(ORDER BY SyncDate Asc) AS Row#,* " & _
                    " FROM tblChiTietPhuongTien_Hist "
            If g_Services.Sys_Execute(p_SQL, _
                                                   p_Error) = False Then

                End If



            p_Error = ""
            p_SQL = "create view tblPhuongTien_Hist_V as " & _
                    " SELECT     ROW_NUMBER() OVER (ORDER BY SyncDate Asc) AS Row#, * " & _
                    ", case when (NgayBatDau) <> '00000000' and isnull(NgayBatDau,'') <>'' then CONVERT(date, NgayBatDau) else null end AS NgayBatDau1 " & _
                    " , case when (NgayHieuLuc) <> '00000000' and isnull(NgayHieuLuc,'') <>'' then CONVERT(date, NgayHieuLuc) else null end AS NgayHieuLuc1 " & _
                    " ,(select convert(date,Max(ThoiGianDau))  from fpt_tbllenhxuatchitiete5_v  A, tbllenhxuate5 B with (nolock) where a.solenh=b.solenh " & _
                    " and b.Maphuongtien =aa.Maphuongtien and a.ThoiGianDau  is not null and ThoiGianDau <=aa.SyncDate) as Date22   " & _
                    " FROM         tblPhuongTien_Hist aa"
            If g_Services.Sys_Execute(p_SQL, _
                                                   p_Error) = False Then

                End If


                '20190411
                'anhqh
                'Tao view cho line phan quyen bao cao
            p_Error = ""
            p_SQL = "create view FPT_SYS_CONFIG_RPT_GROUP1_v as  " & _
                        " select a.Row_id, a.Code, a.ReportCode, b.ReportName, a.fromdate, a.ToDate, a.sDesc, 'N' as CHECKUPD " & _
                        " from SYS_CONFIG_RPT_GROUP1 a, dbo.SYS_CONFIG_RPT b where a.ReportCode = b.ReportCode;"
            If g_Services.Sys_Execute(p_SQL, _
                                                   p_Error) = False Then

                End If

            p_Error = ""
            p_SQL = "create view FPT_SYS_CONFIG_RPT_GROUP_V as  " & _
                        " select a.Code, a.Name, a.Status, 'N' as X   from    SYS_CONFIG_RPT_GROUP a;"
            If g_Services.Sys_Execute(p_SQL, _
                                                   p_Error) = False Then

                End If




            p_Error = ""
            p_SQL = " CREATE VIEW [dbo].[FPT_tblNhietDo_V] as  " & _
            " SELECT   [ID],[NhietDo],[Createby],[UpdatedBy],CrDate, [CreateDate],[UpdateDate], 'N' as CHECKUPD" & _
                " FROM [tblNhietDo]  GO "
            If g_Services.Sys_Execute(p_SQL, _
                                         p_Error) = False Then

                End If

            p_Error = ""
            p_SQL = " create view FPT_tblPhuongTien_Infor_V as " & _
                        "SELECT  [ID] ,[MaPhuongTien],[NoiDung] ,[FromDate] ,[ToDate] " & _
                        ",[sType] ,'N' as CHECKUPD  FROM [tblPhuongTien_Infor]  GO "
            If g_Services.Sys_Execute(p_SQL, _
                                         p_Error) = False Then

                End If

            p_Error = ""
            p_SQL = " create view  FPT_tblPhuongTien_LaiXe_V as " & _
                    "SELECT  [ID] ,[MaPhuongTien] ,[HoVaTen] ,[NoiDung] ,[FromDate] " & _
                    " ,[ToDate],[sType],[sDefault], 'N' as CHECKUPD " & _
                    " FROM [tblPhuongTien_LaiXe]  GO "
            If g_Services.Sys_Execute(p_SQL, _
                                         p_Error) = False Then

                End If
                'anhqh
                '20181010 sua lai View
            p_Error = ""
            p_SQL = " if  COL_LENGTH('FPT_tblPhuongTien_LaiXe_V','Dem') is null " & _
                   "  begin alter table tblLenhXuatE5  add AppDesc nvarchar(1000) end;"

            p_SQL = " ALTER VIEW [FPT_tblPhuongTien_LaiXe_V] AS " & _
                          "  SELECT     ID, MaPhuongTien, HoVaTen, NoiDung, FromDate, ToDate, sType, sDefault, 'N' AS CHECKUPD, Dem, " & _
                             " (SELECT     '1' AS Expr1  FROM          dbo.FPT_tblPhuongTien_V AS a " & _
                              "  WHERE      (MaPhuongTien = b.MaPhuongTien) AND (CONVERT(date, GETDATE()) >= CONVERT(date, ISNULL(NgayBatDau1, GETDATE() - 5)))  " & _
                                 " AND (CONVERT(date, GETDATE()) <= CONVERT(date,ISNULL(NgayHieuLuc1, GETDATE() + 5)))) AS X " & _
                            " FROM         dbo.tblPhuongTien_LaiXe AS b ;  "
            If g_Services.Sys_Execute(p_SQL, _
                                         p_Error) = False Then

                End If




            p_Error = ""
            p_SQL = " CREATE VIEW tblKhachHang_SoLuongSAP_V as " & _
                        " Select MAKHACHHANG, (select Tenkhachhang from tblKhachHang where MaKhachHang=a.MaKhachHang) as TENKHACHHANG, " & _
                     " TONGDUXUAT, TONGDUXUAT_THUY, 'N' as CHECKUPD from  dbo.tblKhachHang_SoLuongSAP A GO "
            If g_Services.Sys_Execute(p_SQL, _
                                         p_Error) = False Then

                End If


            p_Error = ""
            p_SQL = " ALTER VIEW [dbo].[FPT_tblPhuongTien_V] AS " & _
                "SELECT     dbo.tblPhuongTien.MaPhuongTien, dbo.tblPhuongTien.LaiXe, dbo.tblTu.TuText, dbo.tblPhuongTien.SoNgan, dbo.tblPhuongTien.NgayBatDau, " & _
                     " dbo.tblPhuongTien.NgayHieuLuc, dbo.tblPhuongTien.Status, CONVERT(date, CASE WHEN dbo.tblPhuongTien.NgayBatDau = '00000000' THEN NULL  " & _
                      "ELSE CONVERT(date, dbo.tblPhuongTien.NgayBatDau) END) AS NgayBatDau1, CONVERT(date, CASE WHEN " & _
                       "dbo.tblPhuongTien.NgayHieuLuc = '00000000' THEN convert(date,'1900-01-01') " & _
                                      " ELSE CONVERT(date, dbo.tblPhuongTien.NgayHieuLuc) END) AS NgayHieuLuc1, 'N' AS CHECKUPD, dbo.tblPhuongTien.iweight " & _
                      ", tblPhuongTIen.NhaCungCap ,(select top  1 TenNhaCungCap from tblNhaCungCap a with (nolock) " & _
                      "where a.MaNhaCungCap= tblPhuongTIen.NhaCungCap ) as TenNhaCungCap , tblPhuongTien.REG_NO " & _
                       "FROM  dbo.tblTu INNER JOIN  dbo.tblPhuongTien ON dbo.tblTu.TuType = dbo.tblPhuongTien.LaiXe "
            If g_Services.Sys_Execute(p_SQL, _
                                         p_Error) = False Then

                End If



                ''Tao them field
            p_Error = ""
                '  p_SQL = "IF OBJECT_ID ('FPT_tblApprove_Mess_V', 'V') IS  NULL " & _
            p_SQL = " if  COL_LENGTH('tblLenhXuatE5','AppDesc') is null " & _
                    "  begin alter table tblLenhXuatE5  add AppDesc nvarchar(1000) end;"

            p_SQL = " if  COL_LENGTH('tblLenhXuatE5','Xitec_Option') is null " & _
                   "  begin alter table tblLenhXuatE5  add Xitec_Option nvarchar(10) end;"


            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatE5','QCI_KG') is null " & _
                    "  begin alter table tblLenhXuatE5  add QCI_KG decimal(18,2) , QCI_NhietDo decimal(5,2) end;"

                'anhqh
                '20190808  tblTankActive
                'Them truogn quan ly phê duyệt cho KV2 với các bể xuất đầu ngày
            p_SQL = p_SQL & " if  COL_LENGTH('SYS_USER','Tank_App') is null " & _
                 "  begin alter table SYS_USER  add Tank_App nvarchar(10) end;"
            p_SQL = p_SQL & " if  COL_LENGTH('tblTankActive','Tank_App') is null " & _
                 "  begin alter table tblTankActive  add Tank_App nvarchar(10) end;"
            p_SQL = p_SQL & " if  COL_LENGTH('tblTankActive_Hist','Tank_App') is null " & _
                "  begin alter table tblTankActive_Hist  add Tank_App nvarchar(10) end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuat_HangHoaE5','QCI_KG') is null " & _
                   "  begin alter table tblLenhXuat_HangHoaE5  add QCI_KG decimal(18,2) , QCI_NhietDo decimal(5,2), QCI_TyTrong decimal(10,4) end;"


            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatE5','AppN30') is null " & _
                    "  begin alter table tblLenhXuatE5  add AppN30 varchar(1), AppN30Date Datetime, AppN30User nvarchar(200)  end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatE5','NgayHetHieuLuc') is null " & _
                   "  begin alter table tblLenhXuatE5  add NgayHetHieuLuc Datetime   end;"

            p_SQL = p_SQL & " if  COL_LENGTH('SYS_USER','AppN30') is null " & _
                    "  begin alter table SYS_USER  add AppN30 varchar(1) end;"

            p_SQL = p_SQL & " if  COL_LENGTH('SYS_USER','Sl_llkebd_Thuy') is null " & _
                    "  begin alter table SYS_USER  add Sl_llkebd_Thuy varchar(1) ,Sl_llkekt_Thuy varchar(1) end;"


            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatE5','Slog') is null " & _
                    "  begin alter table tblLenhXuatE5  add Slog varchar(100) end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatE5','NgayTichKe') is null " & _
                   "  begin alter table tblLenhXuatE5  add NgayTichKe DateTime end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatE5','UserTichKe') is null " & _
                   "  begin alter table tblLenhXuatE5  add UserTichKe nvarchar(250) end;"


            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatE5','STO') is null " & _
                   "  begin alter table tblLenhXuatE5  add STO nvarchar(250), NguoiDaiDien nvarchar(250), DonViCungCapVanTai nvarchar(250) end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblNguon','TenNguon') is null " & _
                    "  begin alter table tblNguon  add TenNguon nvarchar(500) end;"


            p_SQL = p_SQL & " if  COL_LENGTH('SYS_ROLL1','LoadingSite') is null " & _
                  "  begin alter table SYS_ROLL1  add LoadingSite nvarchar(50) end;"



            p_SQL = p_SQL & " if  COL_LENGTH('tblPhuongTien','iweight') is null " & _
                 "  begin alter table tblPhuongTien  add iweight int end;"

            p_SQL = p_SQL & " if  COL_LENGTH('SYS_MENU','Icon_File') is null " & _
                 "  begin alter table SYS_MENU  add Icon_File nvarchar(50) end;"

            p_SQL = p_SQL & " if  COL_LENGTH('SYS_USER','Terminal') is null " & _
                 "  begin alter table SYS_USER  add Terminal nvarchar(50) end;"
                '

            p_SQL = p_SQL & " if  COL_LENGTH('SYS_CONFIG_RPT','RptAdmin') is null " & _
                 "  begin alter table SYS_CONFIG_RPT  add RptAdmin nvarchar(50) end;"

            p_SQL = p_SQL & " if  COL_LENGTH('SYS_CONFIG_RPT_PARA','MultiSelect') is null " & _
                 "  begin alter table SYS_CONFIG_RPT_PARA  add MultiSelect varchar(1) end;" 'hieptd4 add 20160926

            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatChiTietE5','Record_Status') is null " & _
                 "  begin alter table tblLenhXuatChiTietE5  add Record_Status nvarchar(50) end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatChiTietE5','SO_TT') is null " & _
               "  begin alter table tblLenhXuatChiTietE5  add SO_TT int end;"


            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatE5','DiemTraHang') is null " & _
                 "  begin alter table tblLenhXuatE5  add DiemTraHang nvarchar(500) end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblTankActive','HistDate') is null " & _
                "  begin alter table tblTankActive  add HistDate datetime end;"


            p_SQL = p_SQL & " if  COL_LENGTH('SYS_USER','App3000') is null " & _
                "  begin alter table SYS_USER  add App3000 nvarchar(5) end;"


            p_SQL = p_SQL & " if  COL_LENGTH('tblMeter','FromDate') is null " & _
               "  begin alter table tblMeter  add FromDate datetime end;"
            p_SQL = p_SQL & " if  COL_LENGTH('tblTankActive','FromDate') is null " & _
              "  begin alter table tblTankActive  add FromDate datetime end;"

                'anhqh
                '20170115===========================
                '
            p_SQL = p_SQL & " if  COL_LENGTH('tblChungTu','txtDaiSoHoaDon') is null " & _
              "  begin alter table tblChungTu  add txtDaiSoHoaDon	nvarchar(500), dtBillingDate	datetime, dtNgayHoaDon	datetime, txtSoDO  nvarchar(500)  end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatE5','XuatHangGui') is null " & _
              "  begin alter table tblLenhXuatE5  add XuatHangGui	nvarchar(500)  end;"
                '====================================
                '20170215=======================
            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatE5','Ngay_TKTX') is null " & _
             "  begin alter table tblLenhXuatE5  add So_TKTN	nvarchar(500) ,So_TKTX	nvarchar(500)  ,Ngay_TKTX Datetime   end;"
                '===============================================

                '20170518=======================
            p_SQL = p_SQL & " if  COL_LENGTH('tblChungTu','Ngay_TKTX') is null " & _
             "  begin alter table tblChungTu  add Ngay_TKTX Datetime   end;"
                '===============================================


                '20170518=======================
            p_SQL = p_SQL & " if  COL_LENGTH('tblKhachHang','TenVietTat') is null " & _
             "  begin alter table tblKhachHang  add TenVietTat nvarchar(500)    end;"
                '===============================================
                '20170627
                '
            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatChiTietE5','FlagTankLine') is null " & _
                         "  begin alter table tblLenhXuatChiTietE5  add FlagTankLine nvarchar(1)    end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatChiTietE5','GST_TDH') is null " & _
                        "  begin alter table tblLenhXuatChiTietE5  add GST_TDH  decimal (18,2)   end;"

                '==========================

                'anhqh
                '20170815
                'them truong 
            p_SQL = p_SQL & " if  COL_LENGTH('tblPhuongThucXuat','BWART') is null " & _
           "  begin alter table tblPhuongThucXuat  add BWART nvarchar(50), VTWEG nvarchar(50)    end;"

                'Exit Sub
                '==========================

            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuate5','DischargePoint') is null " & _
          "  begin alter table tblLenhXuate5  add DischargePoint nvarchar(50), DesDischargePoint nvarchar(1500)    end;"

                'tblDO_Header
                'anhhq
                '20170822 --them truong lay ve PO type
            p_SQL = p_SQL & " if  COL_LENGTH('tblDO_Header','BSART') is null " & _
                        "  begin alter table tblDO_Header  add BSART nvarchar(50),  BWART  nvarchar(50), VTWEG  nvarchar(50)   end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuate5','BSART') is null " & _
                       "  begin alter table tblLenhXuate5  add BSART nvarchar(50),  BWART  nvarchar(50), VTWEG  nvarchar(50) end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblPhuongThucXuat','BSART') is null " & _
                       "  begin alter table tblPhuongThucXuat  add BSART nvarchar(50)  end;"


                '20180323=======================   Them sô phiếu XKKVCNB
            p_SQL = p_SQL & " if  COL_LENGTH('tblChungTu','XKKVCNB') is null " & _
             "  begin alter table tblChungTu  add XKKVCNB nvarchar(150)   end;"
                '===============================================


                '==========================

            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuate5','TenKhoNhap') is null " & _
                      "  begin alter table tblLenhXuate5  add TenKhoNhap nvarchar(500)  end;"
                '20190830
                'anhqh thêm Field CardNum
            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatChiTietE5','CardNum') is null " & _
                    "  begin alter table tblLenhXuatChiTietE5  add CardNum nvarchar(100)  end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatE5','CardNum') is null " & _
                  "  begin alter table tblLenhXuatE5  add CardNum nvarchar(100)  end;"


                '20190917
                'anhqh thêm Field CardNum
            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatChiTietE5','CardData') is null " & _
                    "  begin alter table tblLenhXuatChiTietE5  add CardData nvarchar(100)  end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatE5','CardData') is null " & _
                  "  begin alter table tblLenhXuatE5  add CardData nvarchar(100)  end;"


                'anhqh
                '20170915
                'tblPhuongThucXuat where  sDefault='Y'
            p_SQL = p_SQL & " if  COL_LENGTH('tblPhuongThucXuat','sDefault') is null " & _
                       "  begin alter table tblPhuongThucXuat  add sDefault nvarchar(1)  end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblPhuongThucXuat','Ma_Map') is null " & _
                       "  begin alter table tblPhuongThucXuat  add Ma_Map nvarchar(100)  end;"
                'anhqh
                '20171116
                'Them cac truong thong tin cap nhat lich su
            p_SQL = p_SQL & " if  COL_LENGTH('tblPhuongTien','UpdatedBy') is null " & _
                       "  begin alter table tblPhuongTien  add [Createby] [nvarchar](30) NULL, [UpdatedBy] [nvarchar](30) NULL, " & _
                                " [CreateDate] [datetime] NULL, [UpdateDate] [datetime] NULL end;"


                'anqh
                '20180108
                'Them 1 so truong dung cho tinh L15
            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuat_HangHoaE5','VCF') is null " & _
                   "  begin alter table tblLenhXuat_HangHoaE5  add VCF decimal(6,4) , WCF decimal(6,4), NhietDo_BQGQ decimal(6,4), " & _
                        " D15_BQGQ decimal(6,4),  KG decimal(18,2), L15 decimal(18,2)  end;"
                '20180418
                'them truong xác định SAP off
                'p_SQL = p_SQL & " if  COL_LENGTH('SYS_CONFIG','SapOff') is null " & _
                '       "  begin alter table SYS_CONFIG  add SapOff [nvarchar] (10) NULL " & _
                '            "  end;"




                'anqh
                '20180320
                'Them 1 so truong dung cho thue 
            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuat_HangHoaE5','GiaCty') is null " & _
                   "  begin alter table tblLenhXuat_HangHoaE5  add GiaCty decimal(18,6) , PhiVT decimal(18,6), TheBVMT decimal(18,6)" & _
                        "  end;"


                'anqh
                '20180503
                'Them truong luu so lenh gốc được copy
            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatE5','SoLenhGoc') is null " & _
                   "  begin alter table tblLenhXuatE5  add SoLenhGoc nvarchar(50) " & _
                        "  end;"
                'anhqh
                '20180510
                'Them truong danh dau user duoc phep huy tich ke cho nhung tich ke ghep ma co bat ky ngan hang cua lenh xuat khac da duoc bom
                'anqh
                '20180503
                'Them truong luu so lenh gốc được copy
            p_SQL = p_SQL & " if  COL_LENGTH('SYS_USER','HuyLenh') is null " & _
                   "  begin alter table SYS_USER  add HuyLenh nvarchar(50), HuyLenhEnd datetime " & _
                        "  end;"


                'anhqh
                '20181009
                'them Lay ngay lai  dem va lenh ngay , lenh dem
            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuatE5','Dem') is null " & _
                "  begin alter table tblLenhXuatE5  add Dem nvarchar(50) " & _
                     "  end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblPhuongTien_LaiXe','Dem') is null " & _
                    "  begin alter table tblPhuongTien_LaiXe  add Dem nvarchar(50) end;"


            p_SQL = p_SQL & " if  COL_LENGTH('ztblTankHeaderImp','TankList') is null " & _
                 "  begin alter table ztblTankHeaderImp  add  TankList nvarchar(2000) end;"


            p_SQL = p_SQL & " if  COL_LENGTH('ztblTankHeaderImp','SyncUser') is null " & _
                 "  begin alter table ztblTankHeaderImp  add  SyncUser nvarchar(50) end;"


            p_SQL = p_SQL & " if  COL_LENGTH('ztblTankHeaderImp','SyncDate') is null " & _
                 "  begin alter table ztblTankHeaderImp  add   SyncDate datetime end;"




            p_SQL = p_SQL & " if  COL_LENGTH('ztblTankLineImp','SyncDate1') is null " & _
                 "  begin alter table ztblTankLineImp  add   SyncDate1 datetime end;"
            p_SQL = p_SQL & " if  COL_LENGTH('ztblTankLineImp','SyncUser1') is null " & _
                "  begin alter table ztblTankLineImp  add  SyncUser1 nvarchar(50) end;"
            p_SQL = p_SQL & " if  COL_LENGTH('ztblTankLineImp','SyncStatus1') is null " & _
                "  begin alter table ztblTankLineImp  add  SyncStatus1 nvarchar(50) end;"
            p_SQL = p_SQL & " if  COL_LENGTH('ztblTankLineImp','SyncSDesc1') is null " & _
                "  begin alter table ztblTankLineImp  add  SyncSDesc1 nvarchar(1500) end;"



            p_SQL = p_SQL & " if  COL_LENGTH('tblTank','Map_SAP') is null " & _
                "  begin alter table tblTank  add Map_SAP nvarchar(50) " & _
                     "  end;"


                'anhqh
                '20180526
                'txtDonViMuaHang
            p_SQL = p_SQL & " if  COL_LENGTH('tblChungTu','txtMaDonViMuaHang') is null " & _
                 "  begin alter table tblChungTu  add txtMaDonViMuaHang nvarchar(50) " & _
                      "  end;"

            p_SQL = p_SQL & " if  COL_LENGTH('tblTankActive','LoadingSite') is null " & _
                    "  begin alter table tblTankActive  add LoadingSite nvarchar(50) end;"


            p_SQL = p_SQL & " if  COL_LENGTH('tblConfig','Plant_DB') is null " & _
                    "  begin alter table tblConfig  add Plant_DB nvarchar(50) end;"


            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuate5','NgayVaoKho') is null " & _
                  "  begin alter table tblLenhXuate5  add NgayVaoKho datetime, SMO_ID int end;"

                '

            p_SQL = p_SQL & " if  COL_LENGTH('SYS_USER_Login','Client') is null " & _
                 "  begin alter table SYS_USER_Login  add Client nvarchar(20) end;"


            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuate5','PTIEN') is null " & _
                    "  begin alter table tblLenhXuate5  add PTIEN nvarchar(50) end;"
            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuate5','SCHUYEN') is null " & _
                   "  begin alter table tblLenhXuate5  add SCHUYEN Int end;"


            If g_Services.Sys_Execute(p_SQL, _
                                         p_Error) = False Then

                End If

                '20191014
                'anhqh
            p_Error = ""
            p_SQL = " if  COL_LENGTH('tblLenhXuate5','MaTraCuu') is null " & _
                 "  begin alter table tblLenhXuate5  add MaTraCuu nvarchar(200) end;"
                ' p_Error = ""
            p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuate5','TongSoNiem') is null " & _
                 "  begin alter table tblLenhXuate5  add TongSoNiem int , SoBienBanMau nvarchar(150) end;"

            If g_Services.Sys_Execute(p_SQL, _
                                        p_Error) = False Then

                End If


                'anhqh
                '20190808
                'Kiem tra neu View khong co truong Tank_App thi alter lai cai view
            p_Error = "F"
            p_SQL = " select COL_LENGTH('fpt_tblTankActive_V','Tank_App')  as sCol "
            p_Table = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    If p_Table.Rows(0).Item(0).ToString.Trim <> "" Then
                        p_Error = "T"
                        End If
                    End If
                End If
            If p_Error = "F" Then
                p_Error = ""
                p_SQL = "ALTER view [dbo].[fpt_tblTankActive_V] as " & _
                         "SELECT        dbo.tblTankActive.ID, dbo.tblTankActive.Date_nd, dbo.tblTankActive.Name_nd, dbo.tblTankActive.Dens_nd, dbo.tblTankActive.Product_nd, 'N' AS CHECKUPD, " & _
                         " dbo.tblHangHoa.TenHangHoa, CONVERT(date, RIGHT(dbo.tblTankActive.Date_nd, 4) + SUBSTRING(dbo.tblTankActive.Date_nd, 4, 2) " & _
                        "  + LEFT(dbo.tblTankActive.Date_nd, 2)) AS Date1, dbo.tblTankActive.LoadingSite, dbo.tblTankActive.FromDate, dbo.tblTankActive.Tank_App " & _
                        "   FROM    dbo.tblTankActive INNER JOIN  dbo.tblHangHoa ON dbo.tblTankActive.Product_nd = dbo.tblHangHoa.MaHangHoa"

                If g_Services.Sys_Execute(p_SQL, _
                                            p_Error) = False Then

                    End If
                End If



                'anhqh
                '20161123
                'Ham Alter View 
            p_Error = "F"
            p_SQL = " select   COL_LENGTH('FPT_tblMeter_v','FromDate')  as sCol "
            p_Table = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    If p_Table.Rows(0).Item(0).ToString.Trim <> "" Then
                        p_Error = "T"
                        End If
                    End If
                End If

            If p_Error = "F" Then
                p_Error = ""
                p_SQL = "ALTER view [dbo].[FPT_tblMeter_v] as " & _
                        " SELECT     dbo.tblMeter.MeterId, dbo.tblMeter.LoadingSite, dbo.tblMeter.ArmNo, dbo.tblMeter.ProductCode," & _
                        " dbo.tblHangHoa.TenHangHoa, 'N' AS CHECKUPD, dbo.tblMeter.Name_ND, dbo.tblMeter.FromDate " & _
                        " FROM         dbo.tblMeter INNER JOIN " & _
                        "  dbo.tblHangHoa ON dbo.tblMeter.ProductCode = dbo.tblHangHoa.MaHangHoa "
                If g_Services.Sys_Execute(p_SQL, _
                                            p_Error) = False Then

                    End If
                End If


            p_Error = "F"
            p_SQL = " select   COL_LENGTH('FPT_tblTankActive_V','FromDate')  as sCol "
            p_Table = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    If p_Table.Rows(0).Item(0).ToString.Trim <> "" Then
                        p_Error = "T"
                        End If
                    End If
                End If

            If p_Error = "F" Then
                p_Error = ""
                p_SQL = "ALTER VIEW [dbo].[FPT_tblTankActive_V] AS " & _
                    " SELECT     dbo.tblTankActive.ID, dbo.tblTankActive.Date_nd, dbo.tblTankActive.Name_nd, dbo.tblTankActive.Dens_nd, dbo.tblTankActive.Product_nd, 'N' AS CHECKUPD, " & _
                    " dbo.tblHangHoa.TenHangHoa, CONVERT(date, RIGHT(dbo.tblTankActive.Date_nd, 4) + SUBSTRING(dbo.tblTankActive.Date_nd, 4, 2) + LEFT(dbo.tblTankActive.Date_nd, " & _
                    " 2)) AS Date1, dbo.tblTankActive.LoadingSite, dbo.tblTankActive.FromDate " & _
                    " FROM         dbo.tblTankActive INNER JOIN dbo.tblHangHoa ON dbo.tblTankActive.Product_nd = dbo.tblHangHoa.MaHangHoa "

                If g_Services.Sys_Execute(p_SQL, _
                                            p_Error) = False Then

                    End If
                End If


            Hieptd_Sub()

            MsgBox("Đã thực hiện xong")

        Catch ex As Exception

        End Try

    End Sub


    Private Sub Hieptd_Sub()
        Dim p_Error As String
        Dim p_SQL As String

        'hieptd4 add
        p_Error = ""

        p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblDonGia' AND xtype='U') begin" & _
             " CREATE TABLE [dbo].[tblDonGia](" & _
                 " [KAPPL] [varchar](2) NULL, [KSCHL] [varchar](4) NULL," & _
                 " [VKORG] [varchar](4) NULL, [VTWEG] [varchar](2) NULL, [KUNNR] [varchar](10) NULL," & _
                 " [MATNR] [varchar](18) NULL, [VRKME] [varchar](3) NULL," & _
                 " [ZTERM] [varchar](4) NULL, [KFRST] [varchar](1) NULL," & _
                 " [DATBI] [date] NULL, [DATAB] [date] NULL, [KBSTAT] [varchar](2) NULL," & _
                 " [KNUMH] [varchar](10) NULL, [KBETR] [decimal](11,2) NULL, [WAERS] [varchar](5) NULL," & _
                 " [KPEIN] [decimal](5, 0) NULL, [KMEIN] [varchar](3) NULL," & _
                 " [DonGia] [decimal](18, 6) NULL," & _
                 " [ALAND] [varchar](3) NULL, [KONDA] [varchar](2) NULL," & _
                 " [Inco1] [varchar](3) NULL, [Inco2] [nvarchar](28) NULL" & _
                 " ) ON [PRIMARY]" & _
                "  end; "

        p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblGiaoNhan' AND xtype='U') begin" & _
                " CREATE TABLE [dbo].[tblGiaoNhan](" & _
                " [MaTuyenDuong] [varchar](6) NOT NULL, [DiemKhoiHanh] [varchar](10) NULL," & _
                " [DiemDen] [varchar](10) NOT NULL, [DGTuyenDuong] [nvarchar](40) NULL," & _
                " [DGDiemKhoiHanh] [nvarchar](30) NULL, [DGDiemDen] [nvarchar](30) NULL," & _
                " CONSTRAINT [PK_tblGiaoNhan] PRIMARY KEY CLUSTERED ( [MaTuyenDuong] ASC, [DiemDen] ASC" & _
                " )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]" & _
                "  end; "

        p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblNhaCungCap' AND xtype='U') begin" & _
                " CREATE TABLE [dbo].[tblNhaCungCap](" & _
                " [MaNhaCungCap] [varchar](10) NOT NULL, [TenNhaCungCap] [nvarchar](35) NULL, [MaSoThue] [varchar](20) NULL," & _
                " CONSTRAINT [PK_tblNhaCungCap] PRIMARY KEY CLUSTERED ( [MaNhaCungCap] ASC" & _
                " )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]" & _
                "  end; "

        p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblPhuongThucThanhToan' AND xtype='U') begin" & _
                " CREATE TABLE [dbo].[tblPhuongThucThanhToan](" & _
                " [MaPhuongThuc] [varchar](1) NOT NULL,[NoiDung] [nvarchar](50) NULL," & _
                " CONSTRAINT [PK_tblPhuongThucThanhToan] PRIMARY KEY CLUSTERED ( [MaPhuongThuc] ASC" & _
                " )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]" & _
                "  end; "

        p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblThoiHanThanhToan' AND xtype='U') begin" & _
                " CREATE TABLE [dbo].[tblThoiHanThanhToan](" & _
                " [TermKey] [varchar](4) NOT NULL, [BaselineDate] [int] NULL, [DueDate] [int] NULL, [GhiChu] [nvarchar](50) NULL," & _
                " CONSTRAINT [PK_tblThoiHanThanhToan] PRIMARY KEY CLUSTERED ([TermKey] ASC" & _
                " )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]" & _
                "  end; "

        p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblPriceGroup' AND xtype='U') begin" & _
                " CREATE TABLE [dbo].[tblPriceGroup](" & _
                " [PriceGroup] [varchar](2) NOT NULL, [PriceGroupName] [nvarchar](50) NULL," & _
                " CONSTRAINT [PK_tblPriceGroup] PRIMARY KEY CLUSTERED ([PriceGroup] ASC" & _
                ") WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]" & _
                "  end; "

        p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblDO_Header' AND xtype='U') begin" & _
                " CREATE TABLE [dbo].[tblDO_Header](" & _
                " [SoLenh] [varchar](10) NOT NULL, [MaKhachHang] [varchar](10) NULL, [TenKhachHang] [nvarchar](120) NULL," & _
                " [DiaChiKH] [nvarchar](70) NULL, [SoHopDong] [varchar](10) NULL, [NgayHopDong] [datetime] NULL," & _
                " [MaKhoXuat] [varchar](4) NULL, [TenKhoXuat] [nvarchar](30) NULL, [LoadingPoint] [varchar](10) NULL," & _
                " [DesLoadingPoint] [nvarchar](30) NULL, [DischargePoint] [varchar](10) NULL, [DesDischargePoint] [nvarchar](30) NULL," & _
                " [VAT] [decimal](11, 2) NULL, [DVT] [varchar](5) NULL, [PaymentMethod] [varchar](1) NULL," & _
                " [DesPaymentMethod] [nvarchar](30) NULL, [Term] [varchar](4) NULL, [DesTerm] [nvarchar](30) NULL," & _
                " [TyGia] [decimal](10, 5) NULL, [SoTKHQNhap] [varchar](20) NULL, [SoTKHQXuat] [varchar](20) NULL," & _
                " [MaNhaCungCap] [varchar](10) NULL, [TenNhaCungCap] [nvarchar](35) NULL, [MaTuyenDuong] [varchar](6) NULL," & _
                " [MaKhoNhap] [varchar](4) NULL, [TenKhoNhap] [nvarchar](30) NULL, [SoPXK] [nvarchar](150) NULL," & _
                " [NgayPXK] [datetime] NULL," & _
                " CONSTRAINT [PK_DO_Header] PRIMARY KEY CLUSTERED ([SoLenh] ASC" & _
                " )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]" & _
                "  end; "

        p_SQL = p_SQL & " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='tblDO_Item_Material' AND xtype='U') begin" & _
                " CREATE TABLE [dbo].[tblDO_Item_Material](" & _
                " [SoLenh] [varchar](10) NOT NULL, [LineID] [int] NOT NULL," & _
                " [DonGia] [decimal](18, 6) NULL, [CurrencyKey] [varchar](5) NULL," & _
                " CONSTRAINT [PK_DO_Item_Material] PRIMARY KEY CLUSTERED ([SoLenh] ASC, [LineID] ASC" & _
                " )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]" & _
                "  end; "


        If g_Services.Sys_Execute(p_SQL, _
                                     p_Error) = False Then

        End If
        'end hieptd4 add


        'hieptd4 add
        p_Error = ""
        p_SQL = " create view [dbo].[fpt_Inco1_v] as " & _
                " SELECT 'FOB' AS Inco1 " & _
                " UNION ALL " & _
                " SELECT 'CIF' AS Inco1"
        If g_Services.Sys_Execute(p_SQL, _
                                     p_Error) = False Then
        End If

        p_Error = ""
        p_SQL = " CREATE VIEW [dbo].[FPT_tblDonGia_V] AS " & _
                " SELECT TOP (100) PERCENT KSCHL, VKORG, VTWEG, KUNNR, MATNR, VRKME, ZTERM, DATBI, DATAB, ALAND, KONDA, Inco1, Inco2, DonGia, WAERS " & _
                " FROM dbo.tblDonGia ORDER BY DATAB DESC "
        If g_Services.Sys_Execute(p_SQL, _
                                     p_Error) = False Then
        End If
        'end hieptd4 add

        'hieptd4 add
        p_Error = ""

        p_SQL = " if  COL_LENGTH('tblLenhXuatE5','Tax') is null " & _
                "  begin alter table tblLenhXuatE5  add Tax decimal(3,0) , PaymentMethod varchar(1), Term varchar(4), " & _
                " MaKhoNhap nvarchar(4), SoHopDong varchar(10), NgayHopDong datetime, TyGia	decimal(10,2), " & _
                " SoTKHQNhap varchar(20), SoTKHQXuat varchar(20), SelfShipping varchar(1), PriceGroup varchar(2), " & _
                " Inco1 varchar(3), Inco2 nvarchar(28), SoPXK nvarchar(150), NgayPXK datetime, MaTuyenDuong varchar(6) end;"

        p_SQL = p_SQL & " if  COL_LENGTH('tblLenhXuat_HangHoaE5','DonGia') is null " & _
               "  begin alter table tblLenhXuat_HangHoaE5  add DonGia decimal(18,6) , CurrencyKey varchar(5) end;"

        If g_Services.Sys_Execute(p_SQL, _
                                     p_Error) = False Then

        End If
        'end hieptd4 add

        'hieptd4 add
        p_Error = ""
        p_SQL = " IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='FPT_UpdateDO' AND xtype='P')  " & _
                           " exec ('CREATE PROCEDURE [dbo].[FPT_UpdateDO] @p_SoLenh varchar(10) AS " & _
                " BEGIN " & _
                " update A " & _
                " set Tax = b.VAT, " & _
                " PaymentMethod = b.PaymentMethod, " & _
                " Term = b.Term, " & _
                " MaKhoNhap = b.MaKhoNhap, " & _
                " SoHopDong = b.SoHopDong, " & _
                " NgayHopDong = b.NgayHopDong, " & _
                " TyGia = b.TyGia, " & _
                " SoTKHQNhap = b.SoTKHQNhap, " & _
                " SoTKHQXuat = b.SoTKHQXuat, " & _
                " SoPXK  = b.SoPXK, " & _
                " NgayPXK = b.NgayPXK, " & _
                " MaTuyenDuong = b.MaTuyenDuong " & _
                " from tblLenhXuatE5 A, " & _
                " ( select top(1) SoLenh, VAT, PaymentMethod, Term, MaKhoNhap, " & _
                " SoHopDong, NgayHopDong, TyGia, SoTKHQNhap, SoTKHQXuat, SoPXK, NgayPXK, MaTuyenDuong " & _
                " from tblDO_Header where SoLenh = @p_SoLenh) b " & _
                " where a.SoLenh = b.solenh AND A.SoLenh = @p_SoLenh " & _
                " declare @p_lineID int " & _
                " declare @p_DonGia decimal(18, 6) " & _
                " declare @p_CurrencyKey varchar(5) " & _
                " DECLARE p_Cursor CURSOR FOR " & _
                " select LineID, DonGia, CurrencyKey from tblDO_Item_Material where SoLenh = @p_SoLenh " & _
                " OPEN p_Cursor " & _
                " FETCH NEXT FROM p_Cursor INTO @p_LineID,@p_DonGia, @p_CurrencyKey " & _
                " WHILE @@FETCH_STATUS = 0 " & _
                " BEGIN " & _
                " update tblLenhXuat_HangHoaE5 " & _
                " set DonGia = @p_DonGia, CurrencyKey = @p_CurrencyKey " & _
                " where SoLenh = @p_SoLenh and LineID = @p_lineID " & _
                " FETCH NEXT FROM p_Cursor INTO  @p_LineID, @p_DonGia, @p_CurrencyKey " & _
                " End " & _
                " CLOSE p_Cursor " & _
                " DEALLOCATE p_Cursor " & _
                "  End'); "

        If g_Services.Sys_Execute(p_SQL, _
                                     p_Error) = False Then

        End If
        'end hieptd4 add


    End Sub

    Private Function ObjectCheckExists(ByVal p_SQL As String) As Boolean
        Dim p_Table As DataTable
        'Dim p_SQL As String = "select 1 as nNumber from  "
        Try
            ObjectCheckExists = False

            p_Table = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)


            ' p_Table = GetDataTable(p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    ObjectCheckExists = True
                End If
            End If
        Catch ex As Exception
            ObjectCheckExists = True
        End Try
    End Function

End Module
