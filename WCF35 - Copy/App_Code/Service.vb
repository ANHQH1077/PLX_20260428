' NOTE: You can use the "Rename" command on the context menu to change the class name "Service" in code, svc and config file together.
Imports System.Data.OleDb

Imports Microsoft.VisualBasic
'Imports Microsoft.Win3
Imports VFPOLEDBLib

'Imports System.Data.OracleClient
Imports System.Data
Imports System.Xml
Imports System.Security.Cryptography
Imports System.IO



'Namespace Microsoft.ServiceModel.Samples
Public Class Service
    Implements IService
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

    Public p_TuDongHoa As Boolean = False

    Public g_Company_Host As String
    Public g_Company_DB_Name As String

    Public g_HTTG_E5 As Boolean = True

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

    Private p_SYS_MALENH_S As String = String.Empty
    Private p_TONGDUXUAT As String = "0"
    Private p_TONGDUXUATTHUY As String = "0"
    Private g_dt_para As DataTable

    Private _WareHouse As String
    Private _ShPoint As String
    Private _SapConnectionString As String
    Private p_TableConfig As DataTable
    Private p_Sys_Config As DataTable

    Private _TimeOut = New TimeSpan()

    Public p_QUYDOI_SAP As String = "N"

    Public g_KV1 As Boolean = False


    Public g_BATCHSLOG As Boolean = False
    Public g_METER_E5 As Boolean = True

    Public g_Client_E5_Upper As String = ""
    Public g_Client_E5 As String = ""

    Public Constant_P_Bo As String = "Bo"
    Public Constant_P_Thuy As String = "Thuy"
    Public Constant_P_eBo As String = "eBo"
    Public Constant_P_eThuy As String = "eThuy"
    Public Constant_P_Sat = "Sat"
    Public Constant_P_eSat = "eSat"

    Public p_MATUDONGHOA_PROD As String

    Public Function LenhXuatAuto(ByVal p_Date As Date, ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_User_Name As String, ByVal p_Company_Code As String, _
                                        ByRef p_DataTable As System.Data.DataTable, ByVal p_Desc As String) As Boolean Implements IService.clsLenhXuatAuto
        Dim p_DataRow, p_Row As System.Data.DataRow
        Dim p_Count As Integer
        Dim p_TblExe As New System.Data.DataTable("Table01")
        Dim p_SQL As String = ""
        Dim p_Error As String
        Dim p_Desc_OK As String = "Lệnh đã có trên hệ thống"
        Dim p_DateCrd As DateTime
        Try
            LenhXuatAuto = True
            p_TblExe.Columns.Add("SQL_STR")
            For p_Count = 0 To p_DataTable.Rows.Count - 1
                p_DataRow = p_DataTable.Rows(p_Count)
                'If p_DataRow.Item("X") = "Y" Then
                If Not p_DataRow Is Nothing Then
                    p_Error = ""
                    If Check_SoLenh(p_Error, p_DataRow.Item("SoLenh").ToString.Trim) = True Then
                        p_SQL = ""
                        'p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ([SoLenh],[NgayThang],[TrangThai],[Createby],[CreateDate],[sDesc],[StatusCode])" & _
                        '            " VALUES('" & p_DataRow.Item("SoLenh").ToString.Trim & "'" & _
                        '                    ",'" & Format(p_Date, "MM/dd/yyyy") & "','Y','" & p_User_Name & "', getdate(),'" & p_Desc_OK & "','Y')"
                        'p_Row = p_TblExe.NewRow
                        'p_Row.Item(0) = p_SQL
                        'p_TblExe.Rows.Add(p_Row)

                        p_DataTable.Rows(p_Count).Item("sDesc") = p_Desc_OK
                        p_DataTable.Rows(p_Count).Item("sStatus") = "Y"
                    Else
                        If mdlSyncDeliveries_SynSpecific(p_Client, p_User_ID, p_Company_Code, p_DataRow.Item("SoLenh").ToString.Trim, p_Error) = False Then
                            p_SQL = ""
                        Else
                            p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ([SoLenh],[NgayThang],[TrangThai],[Createby],[CreateDate],[sDesc],[StatusCode])" & _
                                    " VALUES('" & p_DataRow.Item("SoLenh").ToString.Trim & "'" & _
                                            ",'" & Format(p_Date, "MM/dd/yyyy") & "','Y','" & p_User_Name & "', getdate(),N'" & p_Error & "','Y')"


                            p_Row = p_TblExe.NewRow
                            p_Row.Item(0) = p_SQL
                            p_TblExe.Rows.Add(p_Row)

                            p_DataTable.Rows(p_Count).Item("sDesc") = p_Error
                            p_DataTable.Rows(p_Count).Item("sStatus") = "Y"
                        End If
                    End If
                End If
                'End If
            Next
        Catch ex As Exception
            LenhXuatAuto = False
        End Try

        If p_TblExe.Rows.Count > 0 Then
            If Sys_Execute_DataTbl(p_TblExe, _
                                           p_Desc) = False Then

            End If
        End If
    End Function


    Function ModReadFile(ByVal FilePath As String, ByVal Position As Long, ByVal Count As Long, ByRef Exception As String) As Byte() Implements IService.ModReadFile
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

    'Public Sub New(Optional ByVal p_Company_Host As String = "", Optional ByVal p_Company_DB_Name As String = "")
    '    g_Company_Host = p_Company_Host
    '    g_Company_DB_Name = p_Company_DB_Name
    'End Sub

    Public Sub New()

    End Sub

    'Public Property CompanyHost() As String
    '    Get
    '        Return g_Company_Host
    '    End Get
    '    Set(ByVal Value As String)
    '        g_Company_Host = Value
    '    End Set
    'End Property

    'Public Property CompanyDB() As String
    '    Get
    '        Return g_Company_DB_Name
    '    End Get
    '    Set(ByVal Value As String)
    '        g_Company_DB_Name = Value
    '    End Set
    'End Property

    Public Function GetData(ByVal value As Integer) As String Implements IService.GetData
        Return String.Format("You entered: {0}", value)
    End Function



    Public Function GetDataTable(ByVal p_SQL As String, ByVal p_Error As String) As DataTable
        Dim p_Datatable As DataTable
        Try
            p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message
            'ShowMessageBox(Err.Number, p_Error)
            Return Nothing
        End Try
        Return p_Datatable

    End Function


    Public Function GetDataTable1(ByVal sql As String) As DataTable Implements IService.GetDataTable
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
                                ByRef p_User_ID As Double) As String Implements IService.SysLogin


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



    Public Function Sys_SQL_ConnectionTest() As OleDb.OleDbConnection Implements IService.Sys_SQL_ConnectionTest
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
        Dim p_PassEn As String = ""
        Try
            ' p_Path = Windows.Forms.Application.StartupPath & "\B1Config.xml"
            p_Path = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath & "\B1Config.xml"
            Dim xml As XmlTextReader
            xml = New XmlTextReader(p_Path)
            xml.WhitespaceHandling = WhitespaceHandling.None
            While Not xml.EOF
                xml.Read()
                If Not xml.IsStartElement() Then
                    Exit While
                End If
                If xml.HasAttributes Then
                    g_DB_Name = xml.GetAttribute(g_KEY_DB_NAME)
                    g_Server = xml.GetAttribute(g_KEY_SERVER)
                    g_UserName = xml.GetAttribute(g_KEY_USER)
                    'g_UserName = "fes_AnhQH"
                    g_Password = xml.GetAttribute(g_KEY_PASS)
                    'g_Password = "AnhQH@FES12345"
                    g_DBPortInstance = xml.GetAttribute(g_KEY_PORT)



                    g_ORAHOST = xml.GetAttribute(g_ORAHOST_Key)
                    g_ORAPORT = xml.GetAttribute(g_ORAPORT_Key)
                    g_SERVERNAME = xml.GetAttribute(g_SERVERNAME_Key)
                    g_ORAUSER = xml.GetAttribute(g_ORAUSER_Key)
                    g_ORAPASS = xml.GetAttribute(g_ORAPASS_Key)

                    g_DBTYPE = xml.GetAttribute(g_DBTYPE_Key)
                    'p_Service = xml.GetAttribute(g_Service)

                    ' p_TopHour = xml.GetAttribute(g_HOUR)s
                    'p_TopMunite = xml.GetAttribute(g_MINUTE)
                End If
            End While
            'close the reader
            xml.Close()
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
    Public Function mod_SYS_GET_DATATABLE(ByVal p_SQL As String) As DataTable Implements IService.mod_SYS_GET_DATATABLE
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
                                                ByRef p_DesErr As String) As DataTable Implements IService.Sys_SYS_GET_DATATABLE_Des
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
                                                ByRef p_DesErr As String) As System.Data.DataSet Implements IService.Sys_SYS_GET_DATASET_Des
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

    Public Function SysExecuteDataSet(ByVal p_DataSet1 As DataSet, ByRef p_Desc As String) As Boolean Implements IService.SysExecuteDataSet

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

    Public Function SysExecuteDataSetTransaction(ByVal p_DataTable As DataSet, ByRef p_Desc As String) As Boolean Implements IService.SysExecuteDataSetTransaction

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
                                          ByRef p_Desc As String) As Boolean Implements IService.Sys_Execute_DataTable

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
            Olecommand.Dispose()
            Oleconnection.Close()
            Oleconnection.Dispose()
            Oleconnection = Nothing

        Catch
            p_Oletransaction.Rollback()
            p_Desc = Err.Description
            Sys_Execute_DataTable = False
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

    Public Function Sys_Execute_DataTbl(ByVal p_DataTable1 As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean Implements IService.Sys_Execute_DataTbl

        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter


        Dim Oleconnection As New OleDbConnection
        Dim Olecommand As New OleDbCommand
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
            'Oleconnection.Close()
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
            If Not Oleconnection Is Nothing Then
                Olecommand.Dispose()
                Oleconnection.Close()
                Oleconnection.Dispose()
                Oleconnection = Nothing
            End If
        End Try

    End Function

    'Public Function Execute_DataTbl_With_Connection(ByVal p_Connection As String, ByVal p_DataTable1 As System.Data.DataTable, _
    '                                      ByRef p_Desc As String) As Boolean Implements IService.Execute_DataTbl_With_Connection
    '    Execute_DataTbl_With_Connection = Sys_Execute_DataTbl_With_Connection(p_Connection, p_DataTable1, p_Desc)
    'End Function

    'Private Function Sys_Execute_DataTbl_With_Connection(ByVal p_Connection As String, ByVal p_DataTable1 As System.Data.DataTable, _
    '                                      ByRef p_Desc As String) As Boolean 'Implements IService.Sys_Execute_DataTbl_With_Connection

    '    Dim p_Count As Integer
    '    Dim p_int As Integer = 0
    '    'Dim adapter As OracleDataAdapter


    '    Dim Oleconnection As New OleDbConnection
    '    Dim Olecommand As New OleDbCommand
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
    '        Oleconnection.Dispose()
    '        p_Oletransaction = Nothing
    '    Catch ex As Exception
    '        p_Oletransaction.Rollback()
    '        p_Oletransaction = Nothing
    '        p_Desc = Err.Number & "-Line " & p_Count + 1 & ":" & ex.Message
    '        Sys_Execute_DataTbl_With_Connection = False
    '        If Not Oleconnection Is Nothing Then
    '            Olecommand.Dispose()
    '            Oleconnection.Close()
    '            Oleconnection.Dispose()
    '            Oleconnection = Nothing
    '        End If
    '    End Try

    'End Function


    Public Function Execute_DataTbl_With_Connection(ByVal p_Connection As String, ByVal p_DataTable1 As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean Implements IService.Execute_DataTbl_With_Connection
        Execute_DataTbl_With_Connection = Sys_Execute_DataTbl_With_Connection(p_Connection, p_DataTable1, p_Desc)
    End Function

    Private Function Sys_Execute_DataTbl_With_Connection(ByVal p_Connection As String, ByVal p_DataTable1 As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean 'Implements IService.Sys_Execute_DataTbl_With_Connection

        Dim p_Count As Integer
        Dim p_int As Integer = 0
        'Dim adapter As OracleDataAdapter


        Dim Oleconnection As New OleDbConnection
        Dim Olecommand As New OleDbCommand
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
            Oleconnection.Dispose()
            p_Oletransaction = Nothing
        Catch ex As Exception
            p_Oletransaction.Rollback()
            p_Oletransaction = Nothing
            p_Desc = Err.Number & "-Line " & p_Count + 1 & ":" & ex.Message
            Sys_Execute_DataTbl_With_Connection = False
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

    Public Function SysExecuteSqlArray(ByVal p_SQLArray() As String, ByRef p_Desc As String) As Boolean Implements IService.SysExecuteSqlArray

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
            Oleconnection.Dispose()
        Catch
            p_Desc = Err.Description
            SysExecuteSqlArray = False
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

    Public Function Sys_Execute_DataTableNew(ByVal p_DataTable As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean Implements IService.Sys_Execute_DataTableNew

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
            Oleconnection.Dispose()
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
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL theo Company

    Public Function Sys_Execute_Com(ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                          ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                          ByVal p_SQL As String, _
                                              ByRef p_Desc As String) As Boolean Implements IService.Sys_Execute_Com

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
                                          ByRef p_Desc As String) As Boolean Implements IService.Sys_Execute

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


    Public Function SysGetBidingSource(ByVal p_Module As String) As DataSet Implements IService.SysGetBidingSource
        Dim p_SQL As String
        p_SQL = "SELECT [FORM_NAME], [VIEW_NAME],[TABLE_NAME], BIDINGNAVIGATOR FROM [BIDINGSOURCE] WHERE MODULE='" & p_Module & "' ORDER BY ID"
        SysGetBidingSource = mod_SYS_GET_DATASET(p_SQL)
    End Function

    Public Function SysGetTrueGridSource(ByVal p_Module As String) As DataSet Implements IService.SysGetTrueGridSource
        Dim p_SQL As String
        p_SQL = "SELECT ID,MODULE,upper(FORM_NAME) as FORM_NAME,upper(GRID_NAME) as GRID_NAME,COL_NAME,ORDER_BY,ENABLE_FLAG,VISIBLE_FLAG" & _
                ",WIDTH,CAPTION,DATA_TYPE, Decimals, Digit,CheckBox, Required " & _
                " ,CFL,CFLSQL,CFLReturn1,CFLReturn2,CFLReturn3,CFLReturn4" & _
                ",ComboBox,ComboBoxSQL, CFLKeyField, DropDownRow, ShowLoadCFL, ColumnSum, AllowUpdate, ComboShowHeader ,DefaultButtonClick " & _
                "FROM GRID_PROPERTY WHERE MODULE='" & p_Module & "' ORDER BY MODULE, FORM_NAME, ORDER_BY"
        SysGetTrueGridSource = mod_SYS_GET_DATASET(p_SQL)
    End Function

    Public Function SysGetTrueGridSourceForm(ByVal p_Module As String, ByVal p_FormName As String) As DataSet Implements IService.SysGetTrueGridSourceForm
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
    'Public Function Sys_Get_Menu_Submenu(ByVal p_User As Double, ByRef p_MenuSet As DataSet, ByRef p_SubmenuSet As DataSet) As Boolean Implements IService.Sys_Get_Menu_Submenu
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
    '29/11/2011
    'Ham thuc hien lay danh sach menu va Submenu
    Public Function Sys_Get_Menu_Submenu(ByVal p_User As Double, ByRef p_MenuSet As DataSet, ByRef p_SubmenuSet As DataSet, _
                                         ByRef p_ErrDes As String, ByVal p_DBTYPE As String) As Boolean Implements IService.Sys_Get_Menu_Submenu
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
                p_SQLMnu = "select A.menu_id, B.menu_name,B.description, B.Menu_Code, b.Icon_File from " & _
                            "sys_user_responds A,sys_menu B where(a.menu_id = b.menu_id And USER_ID " & _
                             "IN (select USER_ID from  SYS_USER where USER_ID= " & p_User & "))  " & _
                             "AND to_date ( sysdate) BETWEEN nvl(A.FROM_DATE,to_date ( sysdate)) " & _
                             "AND nvl(A.TO_DATE,to_date ( sysdate)) order by  OrderBy"

                'p_MenuSet = mod_SYS_GET_DATASET_Oracle(p_SQLMnu, p_ErrDes)
                p_ErrDes = p_SQLMnu
            ElseIf g_DBTYPE = "SQL" Then
                p_SQLMnu = "select A.menu_id, B.menu_name,B.description, B.Menu_Code, b.Icon_File " & _
                        "from sys_user_responds A,sys_menu B " & _
                        "where(a.menu_id = b.menu_id And USER_ID IN (select USER_ID from  SYS_USER where USER_ID= " & p_User & ")) " & _
                        " AND CONVERT (date, GETDATE ()) BETWEEN ISNULL(A.FROM_DATE,CONVERT (date, GETDATE ())) AND ISNULL(A.TO_DATE,CONVERT (date, GETDATE ()))" & _
                        "order by  a.Order_Num" 'OrderBy"

                p_MenuSet = mod_SYS_GET_DATASET(p_SQLMnu)
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
        Catch ex As Exception
            ' p_ErrDes = ex.Message
            Sys_Get_Menu_Submenu = False
        End Try
    End Function





    'ANHQH
    '21/11/2011
    'Ham 1 cau lenh SQL
    'Tra ve bien DataSet

    Public Function mod_SYS_GET_DATASET(ByVal p_SQL As String) As System.Data.DataSet Implements IService.mod_SYS_GET_DATASET
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


    Public Function p_Exampe(ByVal p_SQL As String) As String Implements IService.p_Exampe
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
                                          ByVal p_DataSet As DataSet) As Boolean Implements IService.SysExecuteDataSet_Company

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
                                              ByRef p_Desc As String) As Boolean Implements IService.Sys_Execute_DataTable_Com

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
                                          ByVal p_SQL As String) As System.Data.DataTable Implements IService.mod_SYS_GET_DATATABLE_Com

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
                                          ByVal p_SQL As String) As System.Data.DataSet Implements IService.mod_SYS_GET_DATASET_Com

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
                                             Optional ByVal p_PageNum As Integer = 1) As System.Data.DataSet Implements IService.mod_SYS_GET_DATASET_PAGE


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
                                             Optional ByVal p_PageNum As Integer = 1) As System.Data.DataTable Implements IService.mod_SYS_GET_DATATABLE_PAGE_Com
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
    Public Function SysGetPrimary(ByVal p_TableKey As String) As Double Implements IService.SysGetPrimary
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

    Public Sub ModSys_GetParameterOracle(ByRef p_DBTYPE As String) Implements IService.Sys_GetParameterOracle
        SysGetStrConnect()
        p_DBTYPE = g_DBTYPE
    End Sub



    'ANHQH
    '21/11/2011
    'Ham kiem tra User va password
    Public Function SysLogin_Oracle(ByVal g_IP_Address As String, _
                                ByVal g_GetHostName As String, ByVal p_User As String, ByVal p_Pass As String, _
                                ByRef p_User_ID As Double) As String Implements IService.SysLogin_Oracle


        'Dim p_OLEDataReader As OracleClient.OracleDataReader 'OleDbDataReader  ' OleDbDataReader
        'Dim p_OLEmyCommand As OracleClient.OracleCommand  'OleDbCommand
        'Dim p_OLE_Connect As OracleClient.OracleConnection 'OleDbConnection
        'Dim encoder As New System.Text.UTF8Encoding()
        'Dim p_PassStr_Arr As Byte()
        'Dim p_PassStr As String
        '' Dim connectionString As String
        'Dim p_SQL As String
        'Dim p_Status As String

        'Dim md5Hasher As New System.Security.Cryptography.MD5CryptoServiceProvider()

        'Dim p_ENCRYPTED_USER_PASSWORD As String = ""

        'p_Status = "F"
        'p_User_ID = 0
        ''p_SQL = "SELECT  user_id, User_Name, ENCRYPTED_USER_PASSWORD FROM sys_user WHERE upper(User_Name)='" & UCase(p_User) & _
        ''    "'  AND CONVERT (date, GETDATE ()) BETWEEN ISNULL(START_DATE,CONVERT (date, GETDATE ())) AND ISNULL(END_DATE,CONVERT (date, GETDATE ()))"
        'p_SQL = "SELECT  user_id, User_Name, ENCRYPTED_USER_PASSWORD FROM sys_user WHERE upper(User_Name)='" & UCase(p_User) & "' " & _
        '        " AND to_date ( sysdate) BETWEEN nvl(START_DATE,to_date(sysdate)) " & _
        '        "AND nvl(END_DATE,to_date (sysdate)) "
        'Try


        '    'p_OLE_Connect = Sys_SQL_Connectio()
        '    Try
        '        '  p_OLE_Connect = New OracleConnection(SysGetConnect_Oracle)
        '        'p_OLE_Connect.Open()

        '    Catch ex As Exception
        '        Return "E"
        '    End Try

        '    If p_OLE_Connect.State.ToString() = "Open" Then
        '        Using myRijndael = Rijndael.Create()
        '            p_PassStr_Arr = md5Hasher.ComputeHash(encoder.GetBytes(p_Pass))
        '            p_PassStr = Convert.ToBase64String(p_PassStr_Arr)
        '        End Using
        '        p_OLEmyCommand = New OracleClient.OracleCommand(p_SQL, p_OLE_Connect)
        '        p_OLEDataReader = p_OLEmyCommand.ExecuteReader
        '        While p_OLEDataReader.Read()

        '            p_User_ID = p_OLEDataReader(0)
        '            p_ENCRYPTED_USER_PASSWORD = p_OLEDataReader(2)
        '        End While
        '        If p_User_ID > 0 And p_ENCRYPTED_USER_PASSWORD = p_PassStr Then
        '            p_Status = "T"
        '            p_SQL = "UPDATE SYS_USER SET LAST_LOGON_DATE=sysdate," & _
        '                    "LOGIN_WORK_STATION='" & g_GetHostName & "', LOGIN_IP_ADDRESS='" & g_IP_Address & "' " & _
        '                    " WHERE user_id=" & p_User_ID
        '            p_OLEmyCommand = New OracleClient.OracleCommand(p_SQL, p_OLE_Connect)

        '            p_OLEmyCommand.ExecuteNonQuery()
        '        End If
        '        p_OLEDataReader.Close()
        '    End If

        '    p_OLE_Connect.Close()
        'Catch
        '    p_Status = "E"
        '    p_OLE_Connect = Nothing
        'End Try
        'SysLogin_Oracle = p_Status
        'p_OLE_Connect = Nothing
    End Function



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


    Private Sub GetClient_E5(ByVal p_Client As String)
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
    Public Function HTTG_To_Scadar(ByVal p_UserName As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_InsertToScadar As Boolean = True) As String Implements IService.SYS_HTTG_To_Scadar
        Dim p_SQL As String
        Dim p_DataSet As DataSet
        Dim p_Eror As Boolean
        Dim p_Desc As String
        Dim p_ArrRow() As DataRow
        Try

            'anhqh  
            '20160810
            GetClient_E5(p_Terminal)



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
                    '    'getSQL_TableToScadar("Thuy")

                    '    SQLGetDataToScadar(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Eror, p_Desc, p_Terminal)
                    '    If p_Eror = True Then
                    '        HTTG_To_Scadar = p_Desc
                    '    End If
                    SQLGetDataToScadar(p_UserName, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Eror, p_Desc, p_Terminal)
                    If p_Eror = True Then
                        HTTG_To_Scadar = p_Desc
                    Else
                        'anhqh  
                        '20160607
                        p_Eror = False
                        SQLGetDataToScadar_InTichKe(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Eror, p_Desc, p_Terminal)
                        If p_Eror = True Then
                            HTTG_To_Scadar = "Lệnh xuất chưa được đẩy vào TĐH. Bạn hãy In tích kê lại."
                        End If
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
    '                'If Sys_Execute("INSERT INTO AAAA (STR_SQL) VALUES ('33333333355:" & p_FileName & "') ", p_SQL) Then

    '                'End If


    '                Exit Function
    '            End If
    '            'Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\WCF3_5\DBFOX\out';Extended Properties=dBase 5.0
    '            g_StrConnectFox = "Provider=vfpoledb;Collating Sequence=general;Data Source=" & p_Path
    '            ' g_StrConnectFox = "Provider=vfpoledb;DSN=FoxE5;"
    '            'g_StrConnectFox = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & p_Path & "';Extended Properties=dBase 5.0"
    '            'Provider=vfpoledb;Collating Sequence=general;Data Source=C:\AAAAAATNB\TNB\Petro_VB_B12\Petro_VB
    '            'If Sys_Execute("INSERT INTO AAAA (STR_SQL) VALUES ('Provider=Microsoft.ACE.OLEDB.12.0;Data Source=''" & p_Path & "'';Extended Properties=dBase 5.0') ", p_SQL) Then

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
                       

                        If Sys_Execute("INSERT INTO AAAA (STR_SQL) VALUES ('CCCCCCC') ", p_SQL) Then

                        End If

                        p_DataTable = New DataTable
                     
                        'p_DataTable = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                        p_DataTable = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
                        If Sys_Execute("INSERT INTO AAAA (STR_SQL) VALUES ('ccc:" & Replace(p_SQL, "'", "", 1) & "') ", p_SQL) Then

                        End If
                        If p_DataTable Is Nothing Then
                            If Sys_Execute("INSERT INTO AAAA (STR_SQL) VALUES ('sdfdfsfsfsf') ", p_SQL) Then

                            End If
                        End If

                        If Sys_Execute("INSERT INTO AAAA (STR_SQL) VALUES ('bbbb:') ", p_SQL) Then

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
    Private Sub SQLGetDataToScadar(ByVal p_UserName As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, ByRef p_Error As Boolean, ByRef p_Desc As String, _
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
                p_InsertTable = "INSERT INTO " & p_TableName & " "
                p_ValueTable = " VALUES "
            Else
                p_TableName = Replace(g_PathFileFoxThuy, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)
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
        p_DataHTTG = GetDataTable(p_SQL, p_SQL)   '  g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MALUULUONGKE" Then
                            If p_Value = "" Then
                                p_Value = "0"
                            End If
                        End If
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
                        End If
                        '
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
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

                                p_DataTableCheckID = GetDataTable(p_SQL, p_SQL)    ' g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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


                                    p_DataTableCheckID = GetDataTable(p_SQL, p_SQL)   ' g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
                        'Tinh lai Ma lenh cua tu dong hoa

                        'Kiem tra trong Scadar co chua, neu co roi thi khong insert nua

                        Select Case UCase(p_FieldType)
                            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                p_SQLValue = p_SQLValue & "," & CDec(IIf(p_Value.ToString.Trim = "", 0, p_Value))
                            Case UCase("DateTime"), UCase("Date")
                                If UCase(g_TypeConnet) = "SQL" Then
                                    p_SQLValue = p_SQLValue & ",'" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                End If
                                If UCase(g_TypeConnet) = "FOX" Then
                                    p_SQLValue = p_SQLValue & ",{d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                End If
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
                            If p_DataTableCheckID.Rows.Count > 0 Then
                                p_CheckData = True
                                Continue For
                            End If

                        End If
                    Else
                        p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check
                        If UCase(g_TypeConnet) = "FOX" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
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

                        End If
                        If UCase(g_TypeConnet) = "SQL" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count > 0 Then
                                    p_CheckData = True
                                    Continue For
                                End If

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
                    Dim p_HongXUat As Integer
                    'ByRef p_Tyle As Double, ByRef p_TyTrongNen As Double, ByRef p_TyTrongEthanol As Double
                    GetTyTrong_TyLeE5(p_DataRowHTTG.Item("TableID").ToString.Trim, _
                                        p_DataRowHTTG.Item("MaLenh").ToString.Trim, _
                                        CDate(p_DataRowHTTG.Item("NgayXuat")), _
                                        p_DataRowHTTG.Item("LineID").ToString.Trim, _
                                        p_TyleE5, _
                                        p_TyTrongNenE5, _
                                        p_TyTrongEthanolE5, p_HongXUat)

                    ' If p_TyleE5 = 0 Or p_TyTrongNenE5 = 0 Or p_TyTrongEthanolE5 = 0 Then
                    If (p_TyleE5 = 0 Or p_TyTrongNenE5 = 0 Or p_TyTrongEthanolE5 = 0) And g_METER_E5 = True Then
                        p_Desc = "Không xác định Tỷ lệ phối trộn hoặc tỷ trọng nền " & vbCrLf & "    hoặc tỷ trong Ethanol"
                        p_Error = True
                        Exit Sub
                    Else
                        p_SQLInsert = p_SQLInsert & ",TYLE_PRESET, TYTRONG_BASE, TYTRONG_E, MA_HONG"
                        p_SQLValue = p_SQLValue & "," & p_TyleE5 & "," & p_TyTrongNenE5 & "," & p_TyTrongEthanolE5 & "," & p_HongXUat
                    End If
                End If

                'Neu la FOX thi bo sung gia trij cho cac truong khong co trong danh sach
                If UCase(g_TypeConnet) = "FOX" And p_HangHoaE5 = False Then

                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                        FoxGetExtraField(g_LoaiVanChuyen, p_STT, g_DataMap_Line_cp, g_TableToScadarBo, p_SQLInsert, p_SQLValue)
                    Else
                        FoxGetExtraField(g_LoaiVanChuyen, p_STT, g_DataMap_Line_cp, g_TableToScadarThuy, p_SQLInsert, p_SQLValue)
                    End If

                End If

                If p_HangHoaE5 = False Then
                    Dim p_fieldname As String = ""
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
                    'If g_DBTYPE = "" Then
                    '    g_Services.Sys_GetParameterOracle(g_DBTYPE)
                    'End If

                    g_DBTYPE = "SQL"
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
                    'If g_DBTYPE = "" Then
                    '    g_Services.Sys_GetParameterOracle(g_DBTYPE)
                    'End If

                    g_DBTYPE = "SQL"
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
                p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set Status='3',UserTichKe='" & p_UserName & "', " & _
                " NgayTichKe=NgayXuat where charindex(',' + SoLenh + ',','" & p_SoLenh & ",',1)>0 "
            Else
                p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set Status='3',UserTichKe='" & p_UserName & "', " & _
                    " NgayTichKe=getdate() where charindex(',' + SoLenh + ',','" & p_SoLenh & ",',1)>0 "
            End If

            'p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set Status='3',UserTichKe='" & g_UserName & "', " & _
            '    " NgayTichKe=getdate() where charindex(',' + SoLenh + ',','" & p_SoLenh & ",',1)>0 "
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
                If Sys_Execute_DataTbl(p_TableExec, p_SQL) = False Then
                    'MsgBox(p_SQL)
                    p_Desc = p_SQL
                    p_Error = True
                    Exit Sub

                End If
                'End If
            End If
        End If
    End Sub



    'Private Sub GetTyTrong_TyLeE5(ByVal p_TableID As String, ByVal p_MaLenh As String, ByVal p_NgayThang As Date, ByVal p_LineID As String, _
    '                              ByRef p_Tyle As Double, ByRef p_TyTrongNen As Double, ByRef p_TyTrongEthanol As Double, ByRef p_ArmNo As Integer)
    '    'TYLE_PRESET()
    '    'TYTRONG_BASE()
    '    'TYTRONG_E()
    '    Dim p_SQL As String
    '    Dim p_DataTable As DataTable
    '    p_Tyle = 0
    '    p_TyTrongNen = 0
    '    p_TyTrongEthanol = 0
    '    p_ArmNo = 0
    '    p_SQL = "exec FPT_TyLe_TyTrong '" & p_TableID & "','" & p_MaLenh & "','" & CDate(p_NgayThang).ToString("yyyyMMdd") & "','" & p_LineID & "'"
    '    p_DataTable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '    If Not p_DataTable Is Nothing Then
    '        If p_DataTable.Rows.Count > 0 Then
    '            p_Tyle = p_DataTable.Rows(0).Item("ERate").ToString.Trim
    '            p_TyTrongNen = IIf(p_DataTable.Rows(0).Item("XangNen").ToString.Trim = "", 0, p_DataTable.Rows(0).Item("XangNen").ToString.Trim)
    '            p_TyTrongEthanol = IIf(p_DataTable.Rows(0).Item("Ethanol").ToString.Trim = "", 0, p_DataTable.Rows(0).Item("Ethanol").ToString.Trim)
    '            p_ArmNo = p_DataTable.Rows(0).Item("ArmNo").ToString.Trim
    '        End If
    '    End If
    'End Sub

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
        p_DataTable = GetDataTable(p_SQL, p_SQL)   ' Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                p_Tyle = p_DataTable.Rows(0).Item("ERate").ToString.Trim
                p_TyTrongNen = IIf(p_DataTable.Rows(0).Item("XangNen").ToString.Trim = "", 0, p_DataTable.Rows(0).Item("XangNen").ToString.Trim)
                p_TyTrongEthanol = IIf(p_DataTable.Rows(0).Item("Ethanol").ToString.Trim = "", 0, p_DataTable.Rows(0).Item("Ethanol").ToString.Trim)
                p_HongXuat = IIf(p_DataTable.Rows(0).Item("ArmNo").ToString.Trim = "", 0, p_DataTable.Rows(0).Item("ArmNo").ToString.Trim)
            End If
        End If
    End Sub


    'Private Sub SQLGetColumnType(ByVal p_TypeIn As String, ByVal g_LoaiVanChuyen As String, ByVal p_FileName As String, ByRef p_FieldTypeScadar As String, _
    '                             ByVal p_Terminal As String, ByVal p_HangHoaE5 As Boolean)
    '    Dim p_DataRowMap_cp() As DataRow
    '    Dim p_DataRow() As DataRow
    '    Dim p_FieldNameScadar As String
    '    p_FieldNameScadar = ""
    '    p_FieldTypeScadar = ""

    '    p_DataRowMap_cp = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and (Client='" & p_Terminal & "' or Client='" & UCase(p_Terminal) & "') ")
    '    If p_DataRowMap_cp.Length <= 0 Then
    '        Exit Sub
    '    End If
    '    If p_HangHoaE5 = True Then
    '        p_DataRow = g_DataMap_Line_cp.Select("STT=" & p_DataRowMap_cp(0).Item("STT") & " and FromField='" & p_FileName & "'")
    '        If p_DataRow.Length > 0 Then
    '            p_FieldNameScadar = p_DataRow(0).Item(g_LoaiVanChuyen).ToString.Trim
    '            p_DataRow = g_TableToScadar_E5.Select("FieldName='" & p_FieldNameScadar & "'")
    '            If p_DataRow.Length > 0 Then
    '                p_FieldTypeScadar = p_DataRow(0).Item("FieldType").ToString.Trim
    '            End If
    '        End If
    '        Exit Sub
    '    Else
    '        If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
    '            p_DataRow = g_DataMap_Line_cp.Select("STT=" & p_DataRowMap_cp(0).Item("STT") & " and FromField='" & p_FileName & "'")
    '            If p_DataRow.Length > 0 Then
    '                p_FieldNameScadar = p_DataRow(0).Item("Bo").ToString.Trim
    '                p_DataRow = g_TableToScadarBo.Select("FieldName='" & p_FieldNameScadar & "'")
    '                If p_DataRow.Length > 0 Then
    '                    p_FieldTypeScadar = p_DataRow(0).Item("FieldType").ToString.Trim
    '                End If
    '            End If
    '            Exit Sub
    '        End If
    '        If UCase(g_LoaiVanChuyen) = "THUY" Then
    '            p_DataRow = g_DataMap_Line_cp.Select("STT=" & p_DataRowMap_cp(0).Item("STT") & " and FromField='" & p_FileName & "'")
    '            If p_DataRow.Length > 0 Then
    '                p_FieldNameScadar = p_DataRow(0).Item("Thuy").ToString.Trim
    '                p_DataRow = g_TableToScadarThuy.Select("FieldName='" & p_FieldNameScadar & "'")
    '                If p_DataRow.Length > 0 Then
    '                    p_FieldTypeScadar = p_DataRow(0).Item("FieldType").ToString.Trim
    '                End If
    '            End If
    '            Exit Sub
    '        End If

    '    End If

    'End Sub


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

    Public Function GET_DATATABLE_With_Connect_Des(ByVal p_ConnectStr As String, ByVal p_SQL As String, _
                                                ByRef p_DesErr As String) As DataTable Implements IService.GET_DATATABLE_With_Connect_Des
        GET_DATATABLE_With_Connect_Des = p_SYS_GET_DATATABLE_With_Connect_Des(p_ConnectStr, p_SQL, p_DesErr)
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


    'anhqh
    '20160810

    'Public Sub GetClient_E5(ByVal p_Client As String)
    '    Dim p_SQL As String
    '    Dim p_DataTable As DataTable


    '    g_Client_E5_Upper = "E5 XITEC"
    '    g_Client_E5 = "E5 Xitec"

    '    p_SQL = "select KEYVALUE from SYS_CONFIG  where KEYCODE='FILTERKHO'"
    '    p_DataTable = GetDataTable(p_SQL, p_SQL)
    '    If Not p_DataTable Is Nothing Then
    '        If p_DataTable.Rows.Count > 0 Then
    '            If p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
    '                g_Client_E5_Upper = p_Client & g_Client_E5_Upper
    '                g_Client_E5 = p_Client & g_Client_E5
    '            End If
    '        End If
    '    End If
    'End Sub


    'p_TypeIn=out hoac in
    Public Function ScadarToHTTG(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True, _
                                   Optional ByVal p_E5 As Boolean = True) As String Implements IService.Sys_ScadarToHTTG
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



            ScadarToHTTG = ""

            g_HTTG_E5 = p_E5

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


    '    'anhqh
    '    'Ham thuc hien lay du lieu chi tiet cua  Scadar capnhat cho HTTG
    '    Private Sub SQLGetDataFromScadar(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, ByRef p_Error As Boolean, ByRef p_Desc As String, _
    '                                    ByVal p_Terminal As String)

    '        Dim p_SQL As String
    '        Dim p_DataHTTG As DataTable
    '        Dim p_CountRow As Integer
    '        Dim p_CountCol As Integer
    '        Dim p_Count As Integer
    '        Dim p_DataRowHTTG As DataRow
    '        Dim p_SQLInsert As String = ""
    '        Dim p_SQLValue As String = ""
    '        Dim p_DataRowMap_cp() As DataRow
    '        Dim p_FieldType As String

    '        Dim p_Value As String
    '        Dim p_TableName As String = ""
    '        Dim p_STT As Integer
    '        Dim p_TableScadar As DataTable
    '        Dim p_DataTableCheckID As DataTable
    '        Dim p_Where_Check As String  'Dung checkScadar

    '        Dim p_Where_Update As String  'Dung de update HTTG
    '        Dim p_TableIDHTTG As String

    '        Dim p_TableName_E5 As String = ""
    '        Dim p_DataRowMap_cp_E5() As DataRow
    '        Dim p_DataRowCheck() As DataRow
    '        Dim p_DataRowMap_cp_Old() As DataRow
    '        'Dim p_InsertTable_E5 As String = ""
    '        'Dim p_ValueTable_E5 As String = ""
    '        Dim p_TableScadar_E5 As DataTable
    '        Dim p_MaHangHoa As String
    '        Dim p_HangHoaE5 As Boolean
    '        Dim p_StatusType As String
    '        Dim p_FromField As String = ""

    '        Dim p_Flag() As String
    '        Dim p_DataTableA92 As DataTable



    '        'Dim p_TableID As Integer
    '        'Dim p_NgayXuat As DateTime
    '        'Dim p_MaNgan As Integer

    '        'anhqh
    '        '20160926
    '        Dim p_TableInE5 As DataTable
    '        Dim p_RowInE5 As DataRow
    '        Dim p_Xuat92 As Boolean
    '        Dim p_CountField As Integer



    '        If g_DataMap_cp Is Nothing Then
    '            Exit Sub
    '        End If
    '        p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
    '        p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "') and (Client='" & g_Client_E5_Upper & "' or Client='" & g_Client_E5 & "' )")
    '        If p_DataRowMap_cp_Old.Length <= 0 Then
    '            Exit Sub
    '        End If


    '        If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
    '            p_TableName = p_DataRowMap_cp_Old(0).Item("TableName").ToString.Trim
    '        End If
    '        If UCase(g_LoaiVanChuyen) = "THUY" Then
    '            p_TableName = p_DataRowMap_cp_Old(0).Item("TableName_Thuy").ToString.Trim
    '        End If
    '        If p_DataRowMap_cp_E5.Length > 0 Then
    '            p_TableName_E5 = p_DataRowMap_cp_E5(0).Item("TableName").ToString.Trim
    '        End If

    '        If p_TableName = "" Then
    '            Exit Sub
    '        End If
    '        p_Error = False
    '        p_Desc = ""
    '        'If g_ConnectToScadar.ToString.Trim = "" Then
    '        '    p_Error = True
    '        '    p_Desc = "String kết nối đến máy chủ Scadar không xác định"
    '        '    Exit Sub
    '        'End If

    '        '20150819
    '        'Them dieu kien FOX
    '        If UCase(g_TypeConnet) = "FOX" Then
    '            If g_StrConnectFox.ToString.Trim = "" Then
    '                p_Error = True
    '                p_Desc = "String kết nối đến máy chủ Scadar không xác định"
    '                Exit Sub
    '            End If
    '        Else
    '            If g_ConnectToScadar.ToString.Trim = "" Then
    '                p_Error = True
    '                p_Desc = "String kết nối đến máy chủ Scadar không xác định"
    '                Exit Sub
    '            End If
    '        End If

    '        If UCase(g_TypeConnet) = "FOX" Then
    '            If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
    '                p_TableName = Replace(g_PathFileFoxBo, ".dbf", "", 1)
    '                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)
    '            Else
    '                p_TableName = Replace(g_PathFileFoxThuy, ".dbf", "", 1)
    '                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)
    '            End If

    '        End If


    '        'lay chuoi select trong bang MaptblLine        
    '        p_SQL = "exec FPT_GetDataToScadar '" & p_SoLenh.Trim & "'"
    '        p_DataHTTG = GetDataTable(p_SQL, p_SQL)
    '        If Not p_DataHTTG Is Nothing Then
    '            For p_Count = 0 To p_DataHTTG.Rows.Count - 1
    '                p_DataRowHTTG = p_DataHTTG.Rows(p_Count)
    '                If g_TableMaHangHoaE5.Rows.Count <= 0 Then
    '                    Exit Sub
    '                End If
    '                p_HangHoaE5 = False
    '                p_MaHangHoa = p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
    '                If CheckHangHoaE5(p_MaHangHoa.ToString.Trim) = True Then
    '                    p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
    '                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
    '                    p_HangHoaE5 = True
    '                    If p_DataRowMap_cp.Length <= 0 Then
    '                        Exit Sub
    '                    End If
    '                Else
    '                    'p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
    '                    p_STT = p_DataRowMap_cp_Old(0).Item("STT").ToString.Trim
    '                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
    '                    If p_DataRowMap_cp.Length <= 0 Then
    '                        Exit Sub
    '                    End If
    '                End If
    '                p_SQLInsert = ""
    '                p_SQLValue = ""
    '                p_Where_Check = ""
    '                p_Where_Update = ""
    '                For p_CountRow = 0 To p_DataRowMap_cp.Length - 1
    '                    'Lay kieu du lieu
    '                    p_FieldType = ""

    '                    If UCase(g_LoaiVanChuyen) = "BO" And p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim = "" Then
    '                        Continue For
    '                    End If

    '                    If UCase(g_LoaiVanChuyen) = "THUY" And p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim = "" Then
    '                        Continue For
    '                    End If
    '                    If UCase(g_LoaiVanChuyen) = "SAT" And p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim = "" Then
    '                        Continue For

    '                    End If

    '                    If p_HangHoaE5 = True Then
    '                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, g_Client_E5, p_HangHoaE5)
    '                    Else
    '                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, p_Terminal, p_HangHoaE5)
    '                    End If

    '                    If p_FieldType.ToString.Trim <> "" Or UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "FLAG1" Then



    '                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "FLAG1" Then
    '                            If p_HangHoaE5 = True Then
    '                                p_Value = p_DataRowMap_cp_E5(0).Item("FlagFinish").ToString.Trim
    '                                p_Flag = p_Value.Split(".")
    '                                If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
    '                                    p_Value = p_Flag(0)
    '                                Else
    '                                    p_Value = p_Flag(1)
    '                                End If
    '                            Else
    '                                p_Value = p_DataRowMap_cp_Old(0).Item("FlagFinish").ToString.Trim
    '                                p_Flag = p_Value.Split(".")
    '                                If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
    '                                    p_Value = p_Flag(0)
    '                                Else
    '                                    p_Value = p_Flag(1)
    '                                End If
    '                            End If
    '                            p_StatusType = GetStatusType()


    '                            If p_Where_Check.ToString.Trim = "" Then
    '                                If UCase(g_TypeConnet) = "FOX" Then
    '                                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
    '                                        p_DataRowCheck = g_TableToScadarBo.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")
    '                                    Else
    '                                        p_DataRowCheck = g_TableToScadarThuy.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")

    '                                    End If
    '                                    If p_DataRowCheck.Length > 0 Then
    '                                        Select Case UCase(p_DataRowCheck(0).Item("FieldType").ToString.Trim)
    '                                            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
    '                                                p_Value = p_Value
    '                                            Case UCase("DateTime"), UCase("Date")
    '                                                p_Value = "{d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
    '                                            Case UCase("String")
    '                                                p_Value = "'" & p_Value & "'"
    '                                        End Select
    '                                        Select Case UCase(g_LoaiVanChuyen)
    '                                            Case "BO"
    '                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "" & p_Value & ""
    '                                            Case "THUY"
    '                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "" & p_Value & ""
    '                                            Case "SAT"
    '                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "" & p_Value & ""
    '                                            Case Else
    '                                                Continue For
    '                                        End Select
    '                                    End If
    '                                Else
    '                                    Select Case UCase(g_LoaiVanChuyen)
    '                                        Case "BO"
    '                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "'" & p_Value & "'"
    '                                        Case "THUY"
    '                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "'" & p_Value & "'"
    '                                        Case "SAT"
    '                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "'" & p_Value & "'"
    '                                        Case Else
    '                                            Continue For
    '                                    End Select
    '                                End If


    '                            Else
    '                                If UCase(g_TypeConnet) = "FOX" Then
    '                                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
    '                                        p_DataRowCheck = g_TableToScadarBo.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")
    '                                    Else
    '                                        p_DataRowCheck = g_TableToScadarThuy.Select("FieldName='" & p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim & "'")

    '                                    End If
    '                                    If p_DataRowCheck.Length > 0 Then
    '                                        Select Case UCase(p_DataRowCheck(0).Item("FieldType").ToString.Trim)
    '                                            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
    '                                                p_Value = p_Value
    '                                            Case UCase("DateTime"), UCase("Date")
    '                                                p_Value = "{d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
    '                                            Case UCase("String")
    '                                                p_Value = "'" & p_Value & "'"
    '                                        End Select
    '                                        Select Case UCase(g_LoaiVanChuyen)
    '                                            Case "BO"
    '                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "" & p_Value & ""
    '                                            Case "THUY"
    '                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "" & p_Value & ""
    '                                            Case "SAT"
    '                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "" & p_Value & ""
    '                                            Case Else
    '                                                Continue For
    '                                        End Select
    '                                    End If
    '                                Else
    '                                    Select Case UCase(g_LoaiVanChuyen)
    '                                        Case "BO"
    '                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "" & p_StatusType & "'" & p_Value & "'"
    '                                        Case "THUY"
    '                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "" & p_StatusType & "'" & p_Value & "'"
    '                                        Case "SAT"
    '                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "" & p_StatusType & "'" & p_Value & "'"
    '                                        Case Else
    '                                            Continue For
    '                                    End Select
    '                                End If

    '                            End If
    '                            Continue For
    '                        Else
    '                            'ThoiGianDau()
    '                            'ThoiGianCuoi()
    '                            p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim
    '                        End If

    '                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
    '                            If p_Where_Check.ToString.Trim = "" Then
    '                                'p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
    '                                p_Value = p_Value.Substring(1, g_MaNgan_DD)
    '                                Select Case UCase(g_LoaiVanChuyen)
    '                                    Case "BO"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
    '                                    Case "THUY"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
    '                                    Case "SAT"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
    '                                    Case Else
    '                                        Continue For
    '                                End Select

    '                            Else
    '                                p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
    '                                p_Value = p_Value.Substring(1, g_MaNgan_DD)
    '                                Select Case UCase(g_LoaiVanChuyen)
    '                                    Case "BO"
    '                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
    '                                    Case "THUY"
    '                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
    '                                    Case "SAT"
    '                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
    '                                    Case Else
    '                                        Continue For
    '                                End Select
    '                            End If
    '                        End If

    '                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
    '                            If p_Where_Check.ToString.Trim = "" Then
    '                                'p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                If UCase(g_TypeConnet) = "FOX" And p_HangHoaE5 = False Then
    '                                    Select Case UCase(g_LoaiVanChuyen)
    '                                        Case "BO"
    '                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
    '                                        Case "THUY"
    '                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
    '                                        Case "SAT"
    '                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
    '                                        Case Else
    '                                            Continue For
    '                                    End Select
    '                                Else
    '                                    Select Case UCase(g_LoaiVanChuyen)
    '                                        Case "BO"
    '                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                        Case "THUY"
    '                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                        Case "SAT"
    '                                            p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                        Case Else
    '                                            Continue For
    '                                    End Select

    '                                End If

    '                            Else
    '                                ' p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                If UCase(g_TypeConnet) = "FOX" And p_HangHoaE5 = False Then
    '                                    Select Case UCase(g_LoaiVanChuyen)
    '                                        Case "BO"
    '                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
    '                                        Case "THUY"
    '                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
    '                                        Case "SAT"
    '                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "={d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
    '                                        Case Else
    '                                            Continue For
    '                                    End Select
    '                                Else
    '                                    Select Case UCase(g_LoaiVanChuyen)
    '                                        Case "BO"
    '                                            p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                        Case "THUY"
    '                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                        Case "SAT"
    '                                            p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                        Case Else
    '                                            Continue For
    '                                    End Select
    '                                End If

    '                            End If
    '                        End If



    '                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
    '                            If p_Where_Check.ToString.Trim = "" Then
    '                                'p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
    '                                'p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
    '                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

    '                            Else
    '                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
    '                                'p_Where_Update = p_Where_Update & "  AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
    '                            End If
    '                        End If
    '                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
    '                            ' If g_MaTuDongHoa = "N" Then  'Ma tu dong hoa cho SQL la TableID
    '                            'anhqh
    '                            '20150831
    '                            'Them truong hop neu khong phai la hoang hoa pha che thi nhay vao day
    'HoangHoaPhaChe:
    '                            p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
    '                            'p_FromField = "TableID"
    '                            'If g_MaTuDongHoa = "N" Then
    '                            If p_Value.ToString.Trim <> "" Then
    '                                ' p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
    '                                'p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"

    '                                'anhqh
    '                                '20160704
    '                                'themdieu kien cho KV1
    '                                If GetScadarWagonKV1() = True Then
    '                                    p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
    '                                    p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & IIf(UCase(g_LoaiVanChuyen) = "SAT", "ZR", "AB") & "'"
    '                                Else
    '                                    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
    '                                    p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
    '                                End If

    '                                p_DataTableCheckID = GetDataTable(p_SQL, p_SQL)   ' g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '                                If Not p_DataTableCheckID Is Nothing Then
    '                                    If p_DataTableCheckID.Rows.Count > 0 Then
    '                                        p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
    '                                    End If
    '                                End If
    '                            Else
    '                                'H_TableID
    '                                p_Value = p_DataRowHTTG.Item("H_TableID").ToString.Trim
    '                                If p_Value.ToString.Trim <> "" Then
    '                                    ' p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
    '                                    'p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"

    '                                    'anhqh
    '                                    '20160704
    '                                    'themdieu kien cho KV1
    '                                    If GetScadarWagonKV1() = True Then
    '                                        p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
    '                                        p_DataRowHTTG.Item("MaNgan").ToString.Trim & "','" & IIf(UCase(g_LoaiVanChuyen) = "SAT", "ZR", "AB") & "'"
    '                                    Else
    '                                        p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
    '                                        p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
    '                                    End If

    '                                    p_DataTableCheckID = GetDataTable(p_SQL, p_SQL)   ' g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '                                    If Not p_DataTableCheckID Is Nothing Then
    '                                        If p_DataTableCheckID.Rows.Count > 0 Then
    '                                            p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
    '                                        End If
    '                                    End If
    '                                End If
    '                            End If
    '                            If p_Where_Check.ToString.Trim = "" Then
    '                                p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
    '                                Select Case UCase(g_LoaiVanChuyen)
    '                                    Case "BO"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
    '                                    Case "THUY"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
    '                                    Case "SAT"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
    '                                    Case Else
    '                                        Continue For
    '                                End Select
    '                            Else
    '                                ' p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
    '                                Select Case UCase(g_LoaiVanChuyen)
    '                                    Case "BO"
    '                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
    '                                    Case "THUY"
    '                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
    '                                    Case "SAT"
    '                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
    '                                    Case Else
    '                                        Continue For
    '                                End Select
    '                            End If

    '                            'End If
    '                            'ElseIf g_MaTuDongHoa = "Y" Then  'Ma tu dong hoa cho FOX
    '                            '    p_SQL = "exec FPT_Key_TuDongHoa"
    '                            '    p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '                            '    If Not p_DataTableCheckID Is Nothing Then
    '                            '        If p_DataTableCheckID.Rows.Count > 0 Then
    '                            '            p_Value = p_DataTableCheckID.Rows(0).Item("MaTuDongHoa").ToString.Trim
    '                            '        End If
    '                            '    End If
    '                            'End If

    '                        End If
    '                        'g_TypeConnet 
    '                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MATUDONGHOA" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then

    '                            p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim
    '                            If p_Where_Check.ToString.Trim = "" Then
    '                                Select Case UCase(g_LoaiVanChuyen)
    '                                    Case "BO"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
    '                                    Case "THUY"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
    '                                    Case "SAT"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
    '                                End Select
    '                            Else
    '                                Select Case UCase(g_LoaiVanChuyen)
    '                                    Case "BO"
    '                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "=" & p_Value & ""
    '                                    Case "THUY"
    '                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "=" & p_Value & ""
    '                                    Case "SAT"
    '                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "=" & p_Value & ""
    '                                End Select
    '                            End If
    '                        End If
    '                    End If
    '                Next

    '                If p_Where_Check.ToString.Trim <> "" Then
    '                    If p_HangHoaE5 = True Then
    '                        p_SQL = "select * from " & p_TableName_E5 & " WHERE " & p_Where_Check
    '                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
    '                        If Not p_DataTableCheckID Is Nothing Then
    '                            If p_DataTableCheckID.Rows.Count > 0 Then
    '                                If p_TableScadar_E5 Is Nothing Then
    '                                    p_TableScadar_E5 = p_DataTableCheckID
    '                                Else
    '                                    p_TableScadar_E5.Merge(p_DataTableCheckID)
    '                                End If
    '                            Else
    '                                'anhqh
    '                                '20160926
    '                                'Kiem tra neu co them o DB cua E5 thi loai di
    '                                Try
    '                                    If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
    '                                        p_TableInE5.Clear()
    '                                        p_RowInE5 = p_TableInE5.NewRow
    '                                        For p_CountField = 0 To p_TableInE5.Columns.Count - 1
    '                                            p_RowInE5.Item(p_CountField) = p_DataRowHTTG.Item(p_CountField)

    '                                        Next
    '                                        p_TableInE5.Rows.Add(p_RowInE5)

    '                                        p_DataTableA92 = SQLGetDataFromScadar_A92(p_TableInE5, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
    '                                                            p_Terminal)

    '                                        If Not p_DataTableA92 Is Nothing Then
    '                                            If p_TableScadar_E5 Is Nothing Then
    '                                                p_TableScadar_E5 = p_DataTableA92
    '                                            Else
    '                                                p_TableScadar_E5.Merge(p_DataTableA92)
    '                                            End If

    '                                        End If

    '                                    End If
    '                                Catch ex As Exception

    '                                End Try
    '                            End If

    '                        End If
    '                    Else
    '                        p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check

    '                        If UCase(g_TypeConnet) = "FOX" Then
    '                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
    '                            If Not p_DataTableCheckID Is Nothing Then
    '                                If p_DataTableCheckID.Rows.Count > 0 Then
    '                                    If p_TableScadar Is Nothing Then
    '                                        p_TableScadar = p_DataTableCheckID
    '                                    Else
    '                                        p_TableScadar.Merge(p_DataTableCheckID)
    '                                    End If

    '                                Else
    '                                    'anhqh
    '                                    '20160926
    '                                    'Kiem tra neu co them o DB cua E5 thi loai di
    '                                    Try
    '                                        If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
    '                                            p_TableInE5.Clear()
    '                                            p_RowInE5 = p_TableInE5.NewRow
    '                                            For p_CountField = 0 To p_TableInE5.Columns.Count - 1
    '                                                p_RowInE5.Item(p_CountField) = p_DataRowHTTG.Item(p_CountField)

    '                                            Next
    '                                            p_TableInE5.Rows.Add(p_RowInE5)

    '                                            p_DataTableA92 = SQLGetDataFromScadar_A92(p_TableInE5, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
    '                                                                p_Terminal)

    '                                            If Not p_DataTableA92 Is Nothing Then
    '                                                If p_TableScadar_E5 Is Nothing Then
    '                                                    p_TableScadar_E5 = p_DataTableA92
    '                                                Else
    '                                                    p_TableScadar_E5.Merge(p_DataTableA92)
    '                                                End If

    '                                            End If

    '                                        End If
    '                                    Catch ex As Exception

    '                                    End Try

    '                                End If
    '                            End If
    '                        End If
    '                        If UCase(g_TypeConnet) = "SQL" Then

    '                            'anhqh'
    '                            '20160926
    '                            ' p_Xuat92 = False

    '                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
    '                            If Not p_DataTableCheckID Is Nothing Then
    '                                If p_DataTableCheckID.Rows.Count > 0 Then

    '                                    If p_TableScadar Is Nothing Then
    '                                        p_TableScadar = p_DataTableCheckID
    '                                    Else
    '                                        p_TableScadar.Merge(p_DataTableCheckID)
    '                                    End If



    '                                Else

    '                                    'anhqh
    '                                    '20160926
    '                                    'Kiem tra neu co them o DB cua E5 thi loai di
    '                                    Try
    '                                        If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
    '                                            p_TableInE5.Clear()
    '                                            p_RowInE5 = p_TableInE5.NewRow
    '                                            For p_CountField = 0 To p_TableInE5.Columns.Count - 1
    '                                                p_RowInE5.Item(p_CountField) = p_DataRowHTTG.Item(p_CountField)

    '                                            Next
    '                                            p_TableInE5.Rows.Add(p_RowInE5)

    '                                            p_DataTableA92 = SQLGetDataFromScadar_A92(p_TableInE5, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
    '                                                                p_Terminal)

    '                                            If Not p_DataTableA92 Is Nothing Then
    '                                                If p_TableScadar_E5 Is Nothing Then
    '                                                    p_TableScadar_E5 = p_DataTableA92
    '                                                Else
    '                                                    p_TableScadar_E5.Merge(p_DataTableA92)
    '                                                End If

    '                                            End If

    '                                        End If
    '                                    Catch ex As Exception

    '                                    End Try

    '                                End If
    '                            End If
    '                        End If
    '                    End If
    '                    'If p_HangHoaE5 = True Then
    '                    '    p_SQL = "select * from " & p_TableName_E5 & " WHERE " & p_Where_Check
    '                    '    p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
    '                    '    If Not p_DataTableCheckID Is Nothing Then
    '                    '        If p_DataTableCheckID.Rows.Count > 0 Then
    '                    '            If p_TableScadar_E5 Is Nothing Then
    '                    '                p_TableScadar_E5 = p_DataTableCheckID
    '                    '            Else
    '                    '                p_TableScadar_E5.Merge(p_DataTableCheckID)
    '                    '            End If
    '                    '        End If
    '                    '    Else
    '                    '        'anhqh
    '                    '        '20160926
    '                    '        'Kiem tra neu co them o DB cua E5 thi loai di
    '                    '        Try
    '                    '            If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
    '                    '                p_TableInE5.Clear()
    '                    '                p_RowInE5 = p_TableInE5.NewRow
    '                    '                For p_CountField = 0 To p_TableInE5.Columns.Count - 1
    '                    '                    p_RowInE5.Item(p_CountField) = p_DataRowHTTG.Item(p_CountField)

    '                    '                Next
    '                    '                p_TableInE5.Rows.Add(p_RowInE5)

    '                    '                p_DataTableA92 = SQLGetDataFromScadar_A92(p_TableInE5, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
    '                    '                                    p_Terminal)

    '                    '                If Not p_DataTableA92 Is Nothing Then
    '                    '                    If p_TableScadar_E5 Is Nothing Then
    '                    '                        p_TableScadar_E5 = p_DataTableA92
    '                    '                    Else
    '                    '                        p_TableScadar_E5.Merge(p_DataTableA92)
    '                    '                    End If

    '                    '                End If

    '                    '            End If
    '                    '        Catch ex As Exception

    '                    '        End Try
    '                    '    End If
    '                    'Else
    '                    '    p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check

    '                    '    If UCase(g_TypeConnet) = "FOX" Then
    '                    '        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
    '                    '        If Not p_DataTableCheckID Is Nothing Then
    '                    '            If p_DataTableCheckID.Rows.Count > 0 Then
    '                    '                If p_TableScadar Is Nothing Then
    '                    '                    p_TableScadar = p_DataTableCheckID
    '                    '                Else
    '                    '                    p_TableScadar.Merge(p_DataTableCheckID)
    '                    '                End If
    '                    '            End If
    '                    '        Else
    '                    '            'anhqh
    '                    '            '20160926
    '                    '            'Kiem tra neu co them o DB cua E5 thi loai di
    '                    '            Try
    '                    '                If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
    '                    '                    p_TableInE5.Clear()
    '                    '                    p_RowInE5 = p_TableInE5.NewRow
    '                    '                    For p_CountField = 0 To p_TableInE5.Columns.Count - 1
    '                    '                        p_RowInE5.Item(p_CountField) = p_DataRowHTTG.Item(p_CountField)

    '                    '                    Next
    '                    '                    p_TableInE5.Rows.Add(p_RowInE5)

    '                    '                    p_DataTableA92 = SQLGetDataFromScadar_A92(p_TableInE5, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
    '                    '                                        p_Terminal)

    '                    '                    If Not p_DataTableA92 Is Nothing Then
    '                    '                        If p_TableScadar_E5 Is Nothing Then
    '                    '                            p_TableScadar_E5 = p_DataTableA92
    '                    '                        Else
    '                    '                            p_TableScadar_E5.Merge(p_DataTableA92)
    '                    '                        End If

    '                    '                    End If

    '                    '                End If
    '                    '            Catch ex As Exception

    '                    '            End Try
    '                    '        End If
    '                    '    End If
    '                    '    If UCase(g_TypeConnet) = "SQL" Then
    '                    '        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
    '                    '        If Not p_DataTableCheckID Is Nothing Then
    '                    '            If p_DataTableCheckID.Rows.Count > 0 Then
    '                    '                If p_TableScadar Is Nothing Then
    '                    '                    p_TableScadar = p_DataTableCheckID
    '                    '                Else
    '                    '                    p_TableScadar.Merge(p_DataTableCheckID)
    '                    '                End If
    '                    '            Else

    '                    '                'anhqh
    '                    '                '20160926
    '                    '                'Kiem tra neu co them o DB cua E5 thi loai di
    '                    '                Try
    '                    '                    If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
    '                    '                        p_TableInE5.Clear()
    '                    '                        p_RowInE5 = p_TableInE5.NewRow
    '                    '                        For p_CountField = 0 To p_TableInE5.Columns.Count - 1
    '                    '                            p_RowInE5.Item(p_CountField) = p_DataRowHTTG.Item(p_CountField)

    '                    '                        Next
    '                    '                        p_TableInE5.Rows.Add(p_RowInE5)

    '                    '                        p_DataTableA92 = SQLGetDataFromScadar_A92(p_TableInE5, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
    '                    '                                            p_Terminal)

    '                    '                        If Not p_DataTableA92 Is Nothing Then
    '                    '                            If p_TableScadar_E5 Is Nothing Then
    '                    '                                p_TableScadar_E5 = p_DataTableA92
    '                    '                            Else
    '                    '                                p_TableScadar_E5.Merge(p_DataTableA92)
    '                    '                            End If

    '                    '                        End If

    '                    '                    End If
    '                    '                Catch ex As Exception

    '                    '                End Try
    '                    '            End If
    '                    '        End If
    '                    '    End If
    '                    'End If
    '                End If
    '            Next
    '            p_CountRow = 0


    '            'If g_HTTG_E5 = True Then
    '            '    p_DataTableA92 = SQLGetDataFromScadar_A92(p_DataHTTG, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Error, p_Desc, _
    '            '                         p_Terminal)
    '            '    If Not p_DataTableA92 Is Nothing Then
    '            '        If p_TableScadar_E5 Is Nothing Then
    '            '            p_TableScadar_E5 = p_DataTableA92
    '            '        Else
    '            '            p_TableScadar_E5.Merge(p_DataTableA92)
    '            '        End If

    '            '    End If
    '            'Else
    '            '    p_TableScadar_E5 = Nothing
    '            'End If

    '            If Not p_TableScadar Is Nothing Then
    '                p_CountRow = p_CountRow + p_TableScadar.Rows.Count
    '                ' p_TableScadar.Columns.Add("MaBe")
    '            End If

    '            If Not p_TableScadar_E5 Is Nothing Then
    '                p_CountRow = p_CountRow + p_TableScadar_E5.Rows.Count
    '            End If



    '            If p_DataHTTG.Rows.Count = p_CountRow And p_CountRow > 0 Then
    '                'UpdateFromScadarToHTTG(g_LoaiVanChuyen, p_DataRowMap_cp_E5, p_DataRowMap_cp_Old, p_DataHTTG, p_TableScadar, p_TableScadar_E5)
    '                ''anhqh
    '                ''20150817

    '                'anhqh
    '                '20160819
    '                If UpdateFromScadarToHTTG(g_LoaiVanChuyen, p_DataRowMap_cp_E5, p_DataRowMap_cp_Old, p_DataHTTG, p_TableScadar, p_TableScadar_E5, p_Desc) = True Then
    '                    '   p_Error = True
    '                    '  Exit Sub
    '                End If


    '                If g_HTTG_E5 = True Then
    '                    UpdateFromScadarToHTTG_A92(g_LoaiVanChuyen, p_DataRowMap_cp_E5, p_DataRowMap_cp_Old, p_DataHTTG, p_TableScadar, p_TableScadar_E5)
    '                End If
    '            Else
    '                'If p_HangHoaE5 = True Then
    '                '    MsgBox("sdf")
    '                'End If
    '                p_Error = True
    '                p_Desc = "Chưa thực hiện bơm xuất"
    '                Exit Sub
    '            End If
    '        End If
    '    End Sub
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
        p_DataHTTG = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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
    End Sub

    'anhqh
    '20150817
    'Ham thuc hien voi Hang hoa xang A92 khi xuat hong E5

    'Private Function SQLGetDataFromScadar_A92(ByVal p_DataHTTG As DataTable, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, ByRef p_Error As Boolean, ByRef p_Desc As String, _
    '                                ByVal p_Terminal As String) As DataTable
    '    Dim p_SQL As String
    '    Dim p_CountRow As Integer
    '    Dim p_CountCol As Integer
    '    Dim p_Count As Integer
    '    Dim p_DataRowHTTG As DataRow
    '    Dim p_SQLInsert As String = ""
    '    Dim p_SQLValue As String = ""
    '    Dim p_DataRowMap_cp() As DataRow
    '    Dim p_FieldType As String

    '    Dim p_Value As String
    '    Dim p_TableName As String = ""
    '    Dim p_STT As Integer

    '    Dim p_DataTableCheckID As DataTable
    '    Dim p_Where_Check As String  'Dung checkScadar

    '    Dim p_Where_Update As String  'Dung de update HTTG

    '    Dim p_TableName_E5 As String = ""
    '    Dim p_DataRowMap_cp_E5() As DataRow
    '    Dim p_DataRowMap_cp_Old() As DataRow

    '    Dim p_TableScadar_E5 As New DataTable
    '    Dim p_MaHangHoa As String
    '    Dim p_HangHoaE5 As Boolean

    '    Dim p_Flag() As String

    '    p_TableExec.Columns.Add("SQL_STR", GetType(String))
    '    p_TableExec_E5.Columns.Add("SQL_STR", GetType(String))
    '    If g_DataMap_cp Is Nothing Then
    '        Exit Function
    '    End If
    '    p_DataRowMap_cp_Old = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "' ) and Client='" & p_Terminal & "'")
    '    p_DataRowMap_cp_E5 = g_DataMap_cp.Select("(Status='" & p_TypeIn & "' or Status='" & UCase(p_TypeIn) & "') and (Client='E5 Xitec' or Client='E5 XITEC' )")
    '    If p_DataRowMap_cp_Old.Length <= 0 Then
    '        Exit Function
    '    End If


    '    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
    '        p_TableName = p_DataRowMap_cp_Old(0).Item("TableName").ToString.Trim
    '    End If
    '    If UCase(g_LoaiVanChuyen) = "THUY" Then
    '        p_TableName = p_DataRowMap_cp_Old(0).Item("TableName_Thuy").ToString.Trim
    '    End If
    '    If p_DataRowMap_cp_E5.Length > 0 Then
    '        p_TableName_E5 = p_DataRowMap_cp_E5(0).Item("TableName").ToString.Trim
    '    End If

    '    If p_TableName = "" Then
    '        Exit Function
    '    End If
    '    p_Error = False
    '    p_Desc = ""
    '    If g_ConnectToScadar.ToString.Trim = "" Then
    '        p_Error = True
    '        p_Desc = "String kết nối đến máy chủ Scadar không xác định"
    '        Exit Function
    '    End If

    '    lay chuoi select trong bang MaptblLine        
    '    p_SQL = "exec FPT_GetDataToScadar '" & p_SoLenh.Trim & "'"
    '    p_DataHTTG = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '    If Not p_DataHTTG Is Nothing Then
    '        For p_Count = 0 To p_DataHTTG.Rows.Count - 1
    '            p_DataRowHTTG = p_DataHTTG.Rows(p_Count)
    '            If p_DataRowHTTG.Item("MaHangHoa").ToString.Trim <> "0201001" And p_DataRowHTTG.Item("MaHangHoa").ToString.Trim <> "020202" Then
    '                Continue For
    '            End If

    '            If g_TableMaHangHoaE5.Rows.Count <= 0 Then
    '                Exit Function
    '            End If
    '            p_HangHoaE5 = True
    '            p_MaHangHoa = p_DataRowHTTG.Item("MaHangHoa").ToString.Trim
    '            If p_MaHangHoa.ToString.Trim = g_TableMaHangHoaE5.Rows(0).Item("MaHangHoa_Scada").ToString.Trim Then
    '                p_HangHoaE5 = True
    '            End If

    '            If p_MaHangHoa.ToString.Trim = g_TableMaHangHoaE5.Rows(0).Item("MaHangHoa_Scada").ToString.Trim Then
    '                anhqh(20150817)
    '                If p_HangHoaE5 = True Then
    '                    p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
    '                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
    '                    p_HangHoaE5 = True
    '                    If p_DataRowMap_cp.Length <= 0 Then
    '                        Exit Function
    '                    End If
    '                Else
    '                    p_STT = p_DataRowMap_cp_E5(0).Item("STT").ToString.Trim
    '                    p_STT = p_DataRowMap_cp_Old(0).Item("STT").ToString.Trim
    '                    p_DataRowMap_cp = g_DataMap_Line_cp.Select("STT=" & p_STT)
    '                    If p_DataRowMap_cp.Length <= 0 Then
    '                        Exit Function
    '                    End If
    '                End If

    '                p_SQLInsert = ""
    '                p_SQLValue = ""
    '                p_Where_Check = ""
    '                p_Where_Update = ""
    '                For p_CountRow = 0 To p_DataRowMap_cp.Length - 1
    '                Lay kieu du lieu
    '                    p_FieldType = ""

    '                    If UCase(g_LoaiVanChuyen) = "BO" And p_DataRowMap_cp(p_CountRow).Item("Bo").ToString.Trim = "" Then
    '                        Continue For
    '                    End If

    '                    If UCase(g_LoaiVanChuyen) = "THUY" And p_DataRowMap_cp(p_CountRow).Item("Thuy").ToString.Trim = "" Then
    '                        Continue For
    '                    End If
    '                    If UCase(g_LoaiVanChuyen) = "SAT" And p_DataRowMap_cp(p_CountRow).Item("Sat").ToString.Trim = "" Then
    '                        Continue For

    '                    End If

    '                    If p_HangHoaE5 = True Then
    '                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, "E5 Xitec", p_HangHoaE5)
    '                    Else
    '                        SQLGetColumnType(p_TypeIn, g_LoaiVanChuyen, p_DataRowMap_cp(p_CountRow).Item("FromField").trim, p_FieldType, p_Terminal, p_HangHoaE5)
    '                    End If

    '                    If p_FieldType.ToString.Trim <> "" Then



    '                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "FLAG1" Then
    '                            If p_HangHoaE5 = True Then
    '                                p_Value = p_DataRowMap_cp_E5(0).Item("FlagFinish").ToString.Trim
    '                                p_Flag = p_Value.Split(".")
    '                                If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
    '                                    p_Value = p_Flag(0)
    '                                Else
    '                                    p_Value = p_Flag(1)
    '                                End If
    '                            Else
    '                                p_Value = p_DataRowMap_cp_Old(0).Item("FlagFinish").ToString.Trim
    '                                p_Flag = p_Value.Split(".")
    '                                If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
    '                                    p_Value = p_Flag(0)
    '                                Else
    '                                    p_Value = p_Flag(1)
    '                                End If
    '                            End If
    '                            Select Case UCase(g_LoaiVanChuyen)
    '                                Case "BO"
    '                                    p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
    '                                Case "THUY"
    '                                    p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
    '                                Case "SAT"
    '                                    p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
    '                                Case Else
    '                                    Continue For
    '                            End Select
    '                            Continue For
    '                        Else

    '                            p_Value = p_DataRowHTTG.Item(p_DataRowMap_cp(p_CountRow).Item("FromField").trim).ToString.Trim
    '                        End If


    '                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MANGAN" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
    '                            If p_Where_Check.ToString.Trim = "" Then
    '                                p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
    '                                p_Value = p_Value.Substring(1, g_MaNgan_DD)
    '                                Select Case UCase(g_LoaiVanChuyen)
    '                                    Case "BO"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
    '                                    Case "THUY"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
    '                                    Case "SAT"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
    '                                    Case Else
    '                                        Continue For
    '                                End Select

    '                            Else
    '                                p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_Value & "'"
    '                                p_Value = p_Value.Substring(1, g_MaNgan_DD)
    '                                Select Case UCase(g_LoaiVanChuyen)
    '                                    Case "BO"
    '                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
    '                                    Case "THUY"
    '                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
    '                                    Case "SAT"
    '                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
    '                                    Case Else
    '                                        Continue For
    '                                End Select
    '                            End If
    '                        End If

    '                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("NgayXuat") And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
    '                            If p_Where_Check.ToString.Trim = "" Then
    '                                p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                Select Case UCase(g_LoaiVanChuyen)
    '                                    Case "BO"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                    Case "THUY"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                    Case "SAT"
    '                                        p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                    Case Else
    '                                        Continue For
    '                                End Select
    '                            Else
    '                                p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                Select Case UCase(g_LoaiVanChuyen)
    '                                    Case "BO"
    '                                        p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                    Case "THUY"
    '                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                    Case "SAT"
    '                                        p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & CDate(p_Value).ToString("yyyyMMdd") & "'"
    '                                    Case Else
    '                                        Continue For
    '                                End Select
    '                            End If
    '                        End If



    '                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MAHANGHOA" And UCase(g_LoaiVanChuyen) = "SAT" Then
    '                            If p_Where_Check.ToString.Trim = "" Then
    '                                p_DataRowHTTG.Item("MaHangHoa").ToString.Trim()
    '                                p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
    '                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"

    '                            Else
    '                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
    '                                p_Where_Update = p_Where_Update & "  AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & p_DataRowHTTG.Item("MaHangHoa").ToString.Trim & "'"
    '                            End If
    '                        End If
    '                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
    '                            If g_MaTuDongHoa = "N" Then  'Ma tu dong hoa cho SQL la TableID
    '                                p_Value = p_DataRowHTTG.Item("TableID").ToString.Trim
    '                                If g_MaTuDongHoa = "N" Then
    '                                    If p_Value.ToString.Trim <> "" Then
    '                                        p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
    '                                       p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
    '                                        p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '                                        If Not p_DataTableCheckID Is Nothing Then
    '                                            If p_DataTableCheckID.Rows.Count > 0 Then
    '                                                p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
    '                                            End If
    '                                        End If
    '                                    Else
    '                                        H_TableID()
    '                                        p_Value = p_DataRowHTTG.Item("H_TableID").ToString.Trim
    '                                        If p_Value.ToString.Trim <> "" Then
    '                                            p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
    '                                           p_DataRowHTTG.Item("MaNgan").ToString.Trim & "'"
    '                                            p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '                                            If Not p_DataTableCheckID Is Nothing Then
    '                                                If p_DataTableCheckID.Rows.Count > 0 Then
    '                                                    p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
    '                                                End If
    '                                            End If
    '                                        End If
    '                                    End If
    '                                    If p_Where_Check.ToString.Trim = "" Then
    '                                        p_Where_Update = p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
    '                                        Select Case UCase(g_LoaiVanChuyen)
    '                                            Case "BO"
    '                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
    '                                            Case "THUY"
    '                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
    '                                            Case "SAT"
    '                                                p_Where_Check = p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
    '                                            Case Else
    '                                                Continue For
    '                                        End Select
    '                                    Else
    '                                        p_Where_Update = p_Where_Update & " AND " & p_DataRowMap_cp(p_CountRow).Item("FromField").trim & "='" & IIf(p_DataRowHTTG.Item("TableID").ToString.Trim <> "", p_DataRowHTTG.Item("TableID").ToString.Trim, p_DataRowHTTG.Item("H_TableID").ToString.Trim) & "'"
    '                                        Select Case UCase(g_LoaiVanChuyen)
    '                                            Case "BO"
    '                                                p_Where_Check = p_Where_Check & " AND " & p_DataRowMap_cp(p_CountRow).Item("Bo").trim & "='" & p_Value & "'"
    '                                            Case "THUY"
    '                                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Thuy").trim & "='" & p_Value & "'"
    '                                            Case "SAT"
    '                                                p_Where_Check = p_Where_Check & "  AND " & p_DataRowMap_cp(p_CountRow).Item("Sat").trim & "='" & p_Value & "'"
    '                                            Case Else
    '                                                Continue For
    '                                        End Select
    '                                    End If

    '                                End If
    '                            ElseIf g_MaTuDongHoa = "Y" Then  'Ma tu dong hoa cho FOX
    '                                p_SQL = "exec FPT_Key_TuDongHoa"
    '                                p_DataTableCheckID = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '                                If Not p_DataTableCheckID Is Nothing Then
    '                                    If p_DataTableCheckID.Rows.Count > 0 Then
    '                                        p_Value = p_DataTableCheckID.Rows(0).Item("MaTuDongHoa").ToString.Trim
    '                                    End If
    '                                End If
    '                            End If

    '                        End If

    '                    End If
    '                Next

    '                If p_Where_Check.ToString.Trim <> "" Then
    '                    If p_HangHoaE5 = True Then
    '                        p_SQL = "select * from " & p_TableName_E5 & " WHERE " & p_Where_Check
    '                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar_E5, p_SQL, p_SQL)
    '                        If Not p_DataTableCheckID Is Nothing Then
    '                            If p_DataTableCheckID.Rows.Count > 0 Then
    '                                If p_TableScadar_E5 Is Nothing Then
    '                                    p_TableScadar_E5 = p_DataTableCheckID
    '                                Else
    '                                    p_TableScadar_E5.Merge(p_DataTableCheckID)
    '                                End If
    '                            End If

    '                        End If
    '                    Else
    '                        p_SQL = "select * from " & p_TableName & " WHERE " & p_Where_Check
    '                        p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
    '                        If Not p_DataTableCheckID Is Nothing Then
    '                            If p_DataTableCheckID.Rows.Count > 0 Then
    '                                If p_TableScadar Is Nothing Then
    '                                    p_TableScadar = p_DataTableCheckID
    '                                Else
    '                                    p_TableScadar.Merge(p_DataTableCheckID)
    '                                End If
    '                            End If

    '                        End If

    '                    End If

    '                End If
    '        Next
    '    End If

    '    If Sys_Execute("INSERT INTO AAAA (STR_SQL) VALUES ('p_TableScadar_E5=" & p_TableScadar_E5.Rows.Count.ToString & "')", p_Desc) Then

    '    End If
    '    Return p_TableScadar_E5
    'End Function



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

            Next

            UpdateFromScadarToHTTG = BuildTbaleUpdateHTTG(g_LoaiVanChuyen, p_DataTableWhere, p_DataTableHTTG, p_Scadar, p_ScadarE5, p_SQL)
            p_desc = p_SQL
        Catch ex As Exception
            p_desc = ex.Message
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

        Dim p_ValueNumber As Double

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
                                End If
                                
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



                    '' If p_HangHoaE5 = True Then
                    ''p_FieldName = p_DataRowMap_cp(p_CountRow).Item("").ToString
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

                    If p_Value.ToString.Trim = "" Then
                        Continue For
                    End If

                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MALUULUONGKE" And p_HangHoaE5 = True Then
                        Continue For
                    End If


                    'If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("SoLuongThucXuat") And p_Value.ToString.Trim <> "" Then
                    '    p_Value = Math.Round(CDbl(p_Value), 0)
                    'End If


                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = UCase("SoLuongThucXuat") And p_Value.ToString.Trim <> "" Then
                        p_Value = Math.Round(CDbl(p_Value), 0, MidpointRounding.AwayFromZero)     ' Math.Round(CDbl(p_Value), 0)
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

                    'anhqh
                    '20160819

                    If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MA_HONG" And p_HangHoaE5 = True Then
                        p_Value = getMeter_E5(p_Value)
                        p_SQL = p_SQL & ",MaLuuLuongKe='" & p_Value & "'"
                    End If




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
                    'p_TyTrongUpd = ",TyTrong_15= isnull( (select (select top 1 Dens_nd from FPT_tblTankActive_V bb " & _
                    '          "where Date1 =CONVERT(date,getdate()) and Name_nd =aa.BeXuat  )  " & _
                    '                " from FPT_tblLenhXuatChiTietE5_V aa where " & p_CurrentRow.Item("STR_HTTG").ToString.Trim & "),0)"

                    'anhqh
                    '20160704
                    'Truong hop KV1 thi co them truong hop wagon
                    If GetScadarWagonKV1() = True Then
                        Select Case UCase(g_LoaiVanChuyen)
                            Case "SAT"
                                p_TyTrongUpd = ",TyTrong_15= isnull( (select (select top 1 Dens_nd from FPT_tblTankActive_V bb " & _
                                 "where Date1 =CONVERT(date,getdate()) and Name_nd =aa.BeXuat  )  " & _
                                       " from FPT_tblLenhXuatChiTietE5_V aa where exists (select 1 from fpt_tblLenhXuat_hangHoaE5_V aa1 , FPT_tblLenhXuatE5_V aa2 " & _
                                               " where(aa1.TableID = aa.TableID And aa1.NgayXuat = aa.NgayXuat And aa.SoLenh = aa1.SoLenh  " & _
                                                  " and aa1.SoLenh=aa2.SoLenh and aa2.MaVanChuyen ='ZR' )) and " & p_CurrentRow.Item("STR_HTTG").ToString.Trim & "),0)"
                            Case "THUY"
                                p_TyTrongUpd = ",TyTrong_15= isnull( (select (select top 1 Dens_nd from FPT_tblTankActive_V bb " & _
                                 "where Date1 =CONVERT(date,getdate()) and Name_nd =aa.BeXuat  )  " & _
                                       " from FPT_tblLenhXuatChiTietE5_V aa where exists (select 1 from fpt_tblLenhXuat_hangHoaE5_V aa1 , FPT_tblLenhXuatE5_V aa2 " & _
                                               " where(aa1.TableID = aa.TableID And aa1.NgayXuat = aa.NgayXuat And aa.SoLenh = aa1.SoLenh  " & _
                                                  " and aa1.SoLenh=aa2.SoLenh and aa2.MaVanChuyen  in ('ZB','ZM'))) and " & p_CurrentRow.Item("STR_HTTG").ToString.Trim & "),0)"
                            Case Else
                                p_TyTrongUpd = ",TyTrong_15= isnull( (select (select top 1 Dens_nd from FPT_tblTankActive_V bb " & _
                                 "where Date1 =CONVERT(date,getdate()) and Name_nd =aa.BeXuat  )  " & _
                                       " from FPT_tblLenhXuatChiTietE5_V aa where exists (select 1 from fpt_tblLenhXuat_hangHoaE5_V aa1 , FPT_tblLenhXuatE5_V aa2 " & _
                                               " where(aa1.TableID = aa.TableID And aa1.NgayXuat = aa.NgayXuat And aa.SoLenh = aa1.SoLenh  " & _
                                                  " and aa1.SoLenh=aa2.SoLenh and aa2.MaVanChuyen ='ZT' )) and " & p_CurrentRow.Item("STR_HTTG").ToString.Trim & "),0)"
                        End Select

                    Else
                        p_TyTrongUpd = ",TyTrong_15= isnull( (select (select top 1 Dens_nd from FPT_tblTankActive_V bb " & _
                                  "where Date1 =CONVERT(date,getdate()) and Name_nd =aa.BeXuat  )  " & _
                                        " from FPT_tblLenhXuatChiTietE5_V aa where " & p_CurrentRow.Item("STR_HTTG").ToString.Trim & "),0)"
                    End If

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
                    If Sys_Execute_DataTbl(p_DataTableExe, p_SQL) = False Then
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
        Catch ex As Exception
            Return ""
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
        Dim p_datatable As DataTable

        l_vcf = "select VCF from tblVCF where [Dens] = '" & i_dens & "' and [Temp] = '" & i_temp & "'"
        p_datatable = GetDataTable(l_vcf, l_vcf)
        l_vcf = "1"
        If Not p_datatable Is Nothing Then
            If p_datatable.Rows.Count > 0 Then
                l_vcf = p_datatable.Rows(0).Item("VCF").ToString.Trim
            End If
        End If
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
                l_result(1) = Math.Round(l_result(1))
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "L15"
                l_result(0) = i_quantity / Convert.ToDecimal(l_vcf)
                l_result(1) = i_quantity
                l_result(1) = Math.Round(l_result(1))
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "M15"
                l_result(1) = i_quantity * 1000
                l_result(2) = i_quantity
                l_result(1) = Math.Round(l_result(1))
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "KG"
                l_result(3) = i_quantity
                l_result(1) = l_result(3) / Convert.ToDecimal(l_wcf)
                l_result(1) = Math.Round(l_result(1))
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
                l_result(1) = Math.Round(l_result(1))
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "L15"
                l_result(0) = i_quantity / Convert.ToDecimal(l_vcf)
                l_result(1) = i_quantity
                l_result(1) = Math.Round(l_result(1))
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "M15"
                l_result(1) = i_quantity * 1000
                l_result(1) = Math.Round(l_result(1))
                l_result(2) = i_quantity
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "KG"
                l_result(3) = i_quantity
                l_result(1) = l_result(3) / Convert.ToDecimal(l_wcf)
                l_result(1) = Math.Round(l_result(1))
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
                        If Sys_Execute(l_str, l_str) = False Then

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

#Region "Tao file Scadar"


    Public Function MakeFileScadar(ByVal p_Teminal As String, ByRef p_Error As String) As Boolean Implements IService.MakeFileScadar
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        Dim p_FilePathOut As String = ""
        Dim p_FilePathIn As String = ""
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
                'If p_Datatable.Rows.Count > 0 Then
                '    p_FileName = p_Datatable.Rows(0).Item("TableName").ToString.Trim
                '    If p_FileName = "[SPACE]" Or p_FileName = "SPACE" Then
                '        p_FileName = ""
                '    End If
                '    p_FileName_Thuy = p_Datatable.Rows(0).Item("TableName_Thuy").ToString.Trim
                '    If p_FileName_Thuy = "[SPACE]" Or p_FileName = "SPACE" Then
                '        p_FileName_Thuy = ""
                '    End If
                'End If
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

            'If g_Wcf = True Then
            GetPathFileFox_DB(p_FilePathOut, p_FilePathIn, p_FilePathTemp)
            ' End If
            'If p_FilePathOut = "" Or p_FilePathIn = "" Or p_FilePathTemp = " Then" Then
            '    GetPathFileFox_XML(p_FilePathOut, p_FilePathIn, p_FilePathTemp)
            'End If

            'p_SQL = "select * from SYS_FOXCONFIG"
            'p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            'If Not p_Datatable Is Nothing Then
            '    If p_Datatable.Rows.Count > 0 Then
            '  p_FilePathTemp = p_Datatable.Rows(0).Item("FilePathTemp").ToString.Trim
            If CheckFileName(True, p_FilePathTemp, p_Error) = False Then
                p_Error = "Không xác định được file temp"
                MakeFileScadar = False
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

            'p_SQL = "select * from SYS_FOXCONFIG"
            'p_Datatable = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            'If Not p_Datatable Is Nothing Then
            '    If p_Datatable.Rows.Count > 0 Then
            '        p_FilePathTemp = p_Datatable.Rows(0).Item("FilePathTemp").ToString.Trim
            '        If CheckFileName(True, p_FilePathTemp, p_Error) = False Then
            '            p_Error = "Không xác định được file temp"
            '            MakeFileScadar = False
            '        End If

            '        p_FilePathOut = p_Datatable.Rows(0).Item("FilePathOut").ToString.Trim & "\" & p_FileName
            '        If CheckFileName(True, p_FilePathOut, p_Error) = False Then
            '            ' p_Error = "Không xác định được file Scadar"
            '            ' MakeFileScadar = False
            '            FileCopy(p_FilePathTemp, p_FilePathOut)
            '        End If

            '        If UCase(p_FileName) <> UCase(p_FileName_Thuy) Then
            '            p_FilePathOut = p_Datatable.Rows(0).Item("FilePathOut").ToString.Trim & "\" & p_FileName_Thuy
            '            If CheckFileName(True, p_FilePathOut, p_Error) = False Then
            '                ' p_Error = "Không xác định được file Scadar"
            '                ' MakeFileScadar = False
            '                Try
            '                    FileCopy(p_FilePathTemp, p_FilePathOut)
            '                Catch ex As Exception

            '                End Try

            '            End If
            '        End If
            '    End If
            'End If

        Catch ex As Exception
            p_Error = ex.Message
            MakeFileScadar = False
        End Try
    End Function


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

    Private Function CheckFileName(ByVal p_CheckFile As Boolean, ByVal p_PathFile As String, ByRef p_Err As String) As Boolean
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


    'Public Function BuildBarcode147(ByVal p_String As String) As String Implements IService.BuildBarcode147
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

#End Region

#Region "Sync Material"
    Public Function mdlSyncMaster_SyncMaterial(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                ByRef p_DataTablExe As System.Data.DataTable, ByVal i_getall As String,
                                                ByVal i_date As String,
                                                ByRef p_desc As String) As Boolean Implements IService.mdlSyncMaster_SyncMaterial
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_HangHoaTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        '   Dim l_bs As BSProduct
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim l_mahh As String
        Dim p_SQL As String
        Dim p_Row As DataRow

        Dim p_TableRun As New System.Data.DataTable("Table01")

        'Dim _SapConnectionString As String
        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            'Table.Columns.Add("Dosage", GetType(Integer))
            'Table.Columns.Add("Drug", GetType(String))
            'Table.Columns.Add("Patient", GetType(String))
            'Table.Columns.Add("Date", GetType(DateTime))
            p_desc = ""
            p_TableRun.Columns.Add("SQLSTRING", GetType(String))

            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_HangHoaTable()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetHangHoa(g_Company_Code, _ShPoint, i_getall, i_date, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetHangHoa(g_Company_Code, _WareHouse, i_getall, i_date, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)


                If l_isCompleted Then
                    l_c2sap.EndGetHangHoa(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                For i As Integer = 0 To l_ztb.Count - 1
                    ' l_bs = New BSProduct()
                    l_err = String.Empty
                    l_mahh = String.Empty

                    If l_ztb.Item(i).Mahh.Length > 7 Then
                        l_mahh = l_ztb.Item(i).Mahh.Substring(l_ztb.Item(i).Mahh.Length - 7, 7)
                    Else
                        l_mahh = l_ztb.Item(i).Mahh.Substring(0, l_ztb.Item(i).Mahh.Length)
                    End If

                    p_SQL = "MERGE tblhangHoa AS target " & _
                                            " USING (SELECT '" & l_mahh & "' as MaHangHoa," & _
                                                     "N'" & Replace(l_ztb.Item(i).Tenhh.ToString(), "'", "", 1) & "' as TenhangHoa," & _
                                                     "'" & Replace(l_ztb.Item(i).Donvt.ToString().Trim(), "'", "", 1) & "' as DonViTinh," & _
                                                    "'X' as Status) AS source (MaHangHoa, TenhangHoa, DonViTinh, Status) " & _
                                                    " ON (target.MaHangHoa = source.MaHangHoa) " & _
                                                " WHEN MATCHED  THEN UPDATE SET " & _
                                                        "TenhangHoa=source.TenhangHoa " & _
                                                        ",DonViTinh=source.DonViTinh " & _
                                                        ",Status=source.Status " & _
                                             " WHEN NOT MATCHED THEN " & _
                                                "INSERT  (MaHangHoa, TenhangHoa, DonViTinh, Status ) " & _
                                                    "VALUES (source.MaHangHoa,source.TenhangHoa,source.DonViTinh,source.Status ); "

                    'p_Row = p_DataTablExe.NewRow
                    'p_Row.Item(0) = p_SQL
                    'p_DataTablExe.Rows.Add(p_Row)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)
                  
                    l_dem = l_dem + 1
                Next
            End If

          
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            If p_DataTablExe.Rows.Count > 0 Then
                mdlSyncMaster_SyncMaterial = Sys_Execute_DataTbl(p_DataTablExe, p_desc)
                Return mdlSyncMaster_SyncMaterial
            End If

            Return True

        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try
    End Function
#End Region

#Region "Sync Customer"
    Public Function mdlSyncMaster_SyncCustomer(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByRef p_DataTablExe As DataTable, _
                                                    ByVal i_getall As String, ByVal i_date As String,
                                                    ByRef p_desc As String) As Boolean Implements IService.mdlSyncMaster_SyncCustomer
        'Dim l_c2sap As Connect2SAP.Connect2SAP
        'Dim l_ztb As Connect2SAP.Str_KhachHangTable
        'Dim l_ret2 As Connect2SAP.BAPIRET2
        'Dim l_async As IAsyncResult
        'Dim l_isCompleted As Boolean
        'Dim p_SQL As String

        'Dim l_err As String = String.Empty
        'Dim l_dem As Integer = 0
        'Dim p_Row As DataRow
        ''If p_DataTablExe Is Nothing Then
        ''    p_DataTablExe = New DataTable("Table001")
        ''    p_DataTablExe.Columns.Add("STR_SQL")

        ''End If
        'Dim p_TableRun As New System.Data.DataTable("Table01")

        'Try
        '    '----------------------------------------------------------------------------------------------
        '    '   Lấy các dữ liệu phương tiện từ SAP
        '    '----------------------------------------------------------------------------------------------

        '    p_desc = ""
        '    p_TableRun.Columns.Add("SQLSTRING", GetType(String))
        '    '----------------------------------------------------------------------------------------------
        '    '   Lấy các dữ liệu phương tiện từ SAP
        '    '----------------------------------------------------------------------------------------------
        '    l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
        '    l_ret2 = New Connect2SAP.BAPIRET2()
        '    l_ztb = New Connect2SAP.Str_KhachHangTable()

        '    If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
        '        l_c2sap.GetKhachHang(g_Company_Code, i_date, i_getall, l_ztb, l_ret2)
        '    Else
        '        l_async = l_c2sap.BeginGetKhachHang(g_Company_Code, i_date, i_getall, l_ztb, Nothing, l_c2sap)
        '        l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

        '        If l_isCompleted Then
        '            l_c2sap.EndGetKhachHang(l_async, l_ztb, l_ret2)
        '        End If
        '    End If

        '    '----------------------------------------------------------------------------------------------
        '    '   Đưa thông tin vào csdl SQL
        '    '----------------------------------------------------------------------------------------------
        '    l_dem = 0
        '    If l_ztb.Count > 0 Then
        '        For i As Integer = 0 To l_ztb.Count - 1
        '            'Cho dữ liệu vào CSDL SQL
        '            p_SQL = "MERGE tblKhachHang AS target " & _
        '                " USING (SELECT '" & Replace(l_ztb.Item(i).Makh.ToString(), "'", "", 1) & "' as MakhachHang ," & _
        '                         "N'" & Replace(l_ztb.Item(i).Tenkh.ToString(), "'", "", 1) & "'  as TenKhachHang," & _
        '                         "N'" & Replace(l_ztb.Item(i).Diachi.ToString(), "'", "", 1) & "'  as DiaChi ," & _
        '                         "'" & Replace(l_ztb.Item(i).Mst.ToString(), "'", "", 1) & "'  as MST, " & _
        '                        "'X' as Status) AS source (MakhachHang, TenKhachHang, DiaChi, MST, Status) " & _
        '                        " ON (target.MakhachHang = source.MakhachHang) " & _
        '                    " WHEN MATCHED  THEN UPDATE SET " & _
        '                            "TenKhachHang=source.TenKhachHang " & _
        '                            ",DiaChi=source.DiaChi " & _
        '                            ",MaSoThue=source.MST " & _
        '                            ",Status=source.Status " & _
        '                 " WHEN NOT MATCHED THEN " & _
        '                    "INSERT  (MaKhachhang,TenKhachhang,Diachi,MaSoThue,Status ) " & _
        '                        "VALUES (source.MaKhachhang,source.TenKhachhang,source.Diachi,source.MST,source.Status ) ;"
        '            ' p_SQL = Replace(p_SQL, "''", "'", 1)
        '            p_Row = p_TableRun.NewRow
        '            p_Row.Item(0) = p_SQL
        '            p_TableRun.Rows.Add(p_Row)

        '            l_dem = l_dem + 1
        '        Next
        '    End If



        '    l_c2sap.Connection.Close()
        '    l_c2sap.Dispose()

        '    If p_TableRun.Rows.Count > 0 Then
        '        mdlSyncMaster_SyncCustomer = Sys_Execute_DataTbl(p_TableRun, p_desc)
        '        Return mdlSyncMaster_SyncCustomer
        '    End If

        '    Return True

        'Catch ex As Exception
        '    p_desc = ex.Message
        '    Return False
        'End Try
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.STR_KH_NEWTable
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String

        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_Row As DataRow
        If p_DataTablExe Is Nothing Then
            p_DataTablExe = New DataTable("Table001")
            p_DataTablExe.Columns.Add("STR_SQL")

        End If
        Try
            p_desc = ""
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_ztb = New Connect2SapEx.STR_KH_NEWTable()

            g_Company_Code = _dtVariable.Rows(0).Item("companycode").ToString

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetKhachHang_new(g_Company_Code, i_date, i_getall, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetKhachHang_new(g_Company_Code, i_date, i_getall, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetKhachHang_new(l_async, l_ztb, l_ret2)
                End If
            End If

            'If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
            '    l_c2sap.GetKhachHang_new(g_Company_Code, i_date, i_getall, l_ztb, l_ret2)
            'Else
            '    l_async = l_c2sap.BeginGetKhachHang_new(g_Company_Code, i_date, i_getall, l_ztb, Nothing, l_c2sap)
            '    l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

            '    If l_isCompleted Then
            '        l_c2sap.EndGetKhachHang_new(l_async, l_ztb, l_ret2)
            '    End If
            'End If


            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                For i As Integer = 0 To l_ztb.Count - 1
                    'Cho dữ liệu vào CSDL SQL

                    p_SQL = "MERGE tblKhachHang AS target " & _
                        " USING (SELECT '" & Replace(l_ztb.Item(i).Makh.ToString(), "'", "", 1) & "' as MakhachHang ," & _
                                 "N'" & Replace(l_ztb.Item(i).Tenkh.ToString(), "'", "", 1) & "'  as TenKhachHang," & _
                                 "N'" & Replace(l_ztb.Item(i).Diachi.ToString(), "'", "", 1) & "'  as DiaChi ," & _
                                 "'" & Replace(l_ztb.Item(i).Mst.ToString(), "'", "", 1) & "'  as MST, " & _
                                "'X' as Status) AS source (MakhachHang, TenKhachHang, DiaChi, MST, Status) " & _
                                " ON (target.MakhachHang = source.MakhachHang) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "TenKhachHang=source.TenKhachHang " & _
                                    ",DiaChi=source.DiaChi " & _
                                    ",MaSoThue=source.MST " & _
                                    ",Status=source.Status " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (MaKhachhang,TenKhachhang,Diachi,MaSoThue,Status ) " & _
                                "VALUES (source.MaKhachhang,source.TenKhachhang,source.Diachi,source.MST,source.Status ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)


                    'p_SQL = "MERGE tblKhachHang AS target " & _
                    '    " USING (SELECT '" & Replace(l_ztb.Item(i).Makh.ToString(), "'", "", 1) & "' as MakhachHang ," & _
                    '             "N'" & Replace(l_ztb.Item(i).Tenkh.ToString(), "'", "", 1) & "'  as TenKhachHang," & _
                    '             "N'" & Replace(l_ztb.Item(i).Diachi.ToString(), "'", "", 1) & "'  as DiaChi ," & _
                    '             "'" & Replace(l_ztb.Item(i).Mst.ToString(), "'", "", 1) & "'  as MST, " & _
                    '            "'X' as Status) AS source (MakhachHang, TenKhachHang, DiaChi, MST, Status) " & _
                    '            " ON (target.MakhachHang = source.MakhachHang) " & _
                    '        " WHEN MATCHED  THEN UPDATE SET " & _
                    '                "TenKhachHang=source.TenKhachHang " & _
                    '                ",DiaChi=source.DiaChi " & _
                    '                ",MaSoThue=source.MST " & _
                    '                ",Status=source.Status " & _
                    '     " WHEN NOT MATCHED THEN " & _
                    '        "INSERT  (MaKhachhang,TenKhachhang,Diachi,MaSoThue,Status ) " & _
                    '            "VALUES (source.MaKhachhang,source.TenKhachhang,source.Diachi,source.MST,source.Status ) ;"
                    '' p_SQL = Replace(p_SQL, "''", "'", 1)
                    'p_Row = p_DataTablExe.NewRow
                    'p_Row.Item(0) = p_SQL
                    'p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            If p_DataTablExe.Rows.Count > 0 Then
                mdlSyncMaster_SyncCustomer = Sys_Execute_DataTbl(p_DataTablExe, p_Desc)
                'Return mdlSyncMaster_SyncVehicleDown
            End If


            Return True

        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try
    End Function
#End Region

#Region "Sync Mod/Trans."
    Public Function mdlSyncMaster_SyncTransport(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                                ByRef p_desc As String) As Boolean Implements IService.mdlSyncMaster_SyncTransport
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_VanChuyen_NoTDTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        'Dim l_bs As BSTranport
        Dim p_SQL As String
        Dim p_Row As DataRow
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_TableRun As New System.Data.DataTable("Table01")

        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            p_desc = ""
            p_TableRun.Columns.Add("SQLSTRING", GetType(String))
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_VanChuyen_NoTDTable()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetVanChuyen_NoTD(i_getall, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetVanChuyen_NoTD(i_getall, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetVanChuyen_NoTD(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Xóa csdl SQL đã có
            '----------------------------------------------------------------------------------------------
            'If l_ztb.Count > 0 Then
            '    If Not mdlSyncMaster_SynVanChuyen_Delete(l_ztb) Then
            '        Return False
            '    End If
            'End If
            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                For i As Integer = 0 To l_ztb.Count - 1
                    p_SQL = "MERGE tblVanChuyen AS target " & _
                                            " USING (SELECT '" & Replace(l_ztb.Item(i).Malhvc.ToString(), "'", "", 1) & "' as MaVanChuyen," & _
                                                     "N'" & Replace(l_ztb.Item(i).Tenlhvc.ToString(), "'", "", 1) & "' as TenVanChuyen," & _
                                                    "'X' as Status) AS source (MaVanChuyen, TenVanChuyen, Status) " & _
                                                    " ON (target.MaVanChuyen = source.MaVanChuyen) " & _
                                                " WHEN MATCHED  THEN UPDATE SET " & _
                                                        "TenVanChuyen=source.TenVanChuyen " & _
                                                        ",Status=source.Status " & _
                                             " WHEN NOT MATCHED THEN " & _
                                                "INSERT  (MaVanChuyen,TenVanChuyen,Status ) " & _
                                                    "VALUES (source.MaVanChuyen,source.TenVanChuyen,source.Status ); "

                    'p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_TableRun.NewRow
                    p_Row.Item(0) = p_SQL
                    p_TableRun.Rows.Add(p_Row)


                    l_dem = l_dem + 1
                Next
            End If

            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            If p_TableRun.Rows.Count > 0 Then
                mdlSyncMaster_SyncTransport = Sys_Execute_DataTbl(p_TableRun, p_desc)
                Return mdlSyncMaster_SyncTransport
            End If

            Return True

        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try

    End Function

#End Region


#Region "Nguon hang"
    'Public Function SynNguonHang(ByVal _SapConnectionString As String, _
    '                                            ByVal _dtVariable As System.Data.DataTable, _
    '                                            ByVal _ShPoint As String, _
    '                                                ByVal _WareHouse As String, _
    '                                                ByVal _TimeOut As System.TimeSpan, _
    '                                                ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, _
    '                                                ByRef p_desc As String) As Boolean Implements IService.SynNguonHang
    '    'Dim bs As BSProductSource = New BSProductSource()
    '    Dim ztb As Connect2SAP.Str_NguonTable = New Connect2SAP.Str_NguonTable()
    '    Dim ztb_value As Connect2SAP.Str_ValueTable = New Connect2SAP.Str_ValueTable()
    '    Dim c2sap = New Connect2SAP.Connect2SAP()
    '    Dim ret2 As Connect2SAP.BAPIRET2
    '    Dim async As IAsyncResult
    '    Dim isCompleted As Boolean
    '    Dim Err As String
    '    Dim p_SQL As String
    '    Dim p_Row As DataRow

    '    Dim p_TableRun As New System.Data.DataTable("Table01")

    '    Try
    '        '----------------------------------------------------------------------------------------------
    '        '   Lấy các dữ liệu phương tiện từ SAP
    '        '----------------------------------------------------------------------------------------------

    '        p_desc = ""
    '        p_TableRun.Columns.Add("SQLSTRING", GetType(String))


    '        'Try connect and get data from SAP
    '        c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)

    '        ret2 = New Connect2SAP.BAPIRET2()

    '        If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
    '            c2sap.GetNguon(g_Company_Code, _WareHouse, i_date, i_getall, ztb_value, ztb, ret2)
    '        Else
    '            async = c2sap.BeginGetNguon(g_Company_Code, _WareHouse, i_date, i_getall, ztb_value, ztb, Nothing, c2sap)
    '            isCompleted = async.AsyncWaitHandle.WaitOne(_TimeOut, False)

    '            If isCompleted Then
    '                c2sap.EndGetNguon(async, ztb_value, ztb, ret2)
    '            End If
    '        End If


    '        If ztb.Count > 0 Then
    '            For i As Integer = 0 To ztb.Count - 1
    '                'Cho dữ liệu vào CSDL SQL

    '                p_SQL = "MERGE tblNguon AS target " & _
    '                                        " USING (SELECT '" & Replace(ztb.Item(i).Manguon.ToString(), "'", "", 1) & "' as Manguon," & _
    '                                                "'X' as Status) AS source (Manguon,  Status) " & _
    '                                                " ON (target.Manguon = source.Manguon) " & _
    '                                            " WHEN MATCHED  THEN UPDATE SET " & _
    '                                                    "Status=source.Status " & _
    '                                         " WHEN NOT MATCHED THEN " & _
    '                                            "INSERT  (Manguon,Status ) " & _
    '                                                "VALUES (source.Manguon,source.Status ); "

    '                ' p_SQL = Replace(p_SQL, "''", "'", 1)
    '                p_Row = p_TableRun.NewRow
    '                p_Row.Item(0) = p_SQL
    '                p_TableRun.Rows.Add(p_Row)
    '            Next
    '        End If

    '        SynNguonHang = True

    '        If p_TableRun.Rows.Count > 0 Then
    '            SynNguonHang = Sys_Execute_DataTbl(p_TableRun, p_desc)
    '            ' Return mdlSyncMaster_SyncTransport()
    '        End If




    '    Catch ex As Exception
    '        SynNguonHang = False
    '    Finally
    '        c2sap.Connection.Close()
    '        c2sap.Dispose()
    '    End Try

    'End Function
    Public Function SynNguonHang(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                    ByVal _ShPoint As String, _
                                                        ByVal _WareHouse As String, _
                                                        ByVal _TimeOut As System.TimeSpan, _
                                                        ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, _
                                                        ByRef p_desc As String) As Boolean Implements IService.SynNguonHang
        'Dim bs As BSProductSource = New BSProductSource()
        Dim ztb As Connect2SapEx.STR_NguonTable = New Connect2SapEx.STR_NguonTable()
        Dim c2sap = New Connect2SapEx.Connect2Sap()
        Dim ret2 As Connect2SapEx.BAPIRET2
        Dim async As IAsyncResult
        Dim isCompleted As Boolean
        Dim Err As String
        Dim p_SQL As String
        Dim p_Row As DataRow

        'Try connect and get data from SAP
        p_Desc = ""

       
        c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
        Try
            ret2 = New Connect2SapEx.BAPIRET2()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                c2sap.GetNguon_New(ztb, ret2)
            Else
                async = c2sap.BeginGetNguon_New(ztb, Nothing, c2sap)
                isCompleted = async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If isCompleted Then
                    c2sap.EndGetNguon_New(async, ztb, ret2)
                End If
            End If


            If ztb.Count > 0 Then
                For i As Integer = 0 To ztb.Count - 1
                    'Cho dữ liệu vào CSDL SQL

                    p_SQL = "MERGE tblNguon AS target " & _
                                            " USING (SELECT '" & Replace(ztb.Item(i).Zmanguon.ToString(), "'", "", 1) & "' as Manguon," & _
                                                    "'X' as Status, N'" & ztb.Item(i).Ztennguon.ToString() & "' as TenNguon) AS source (Manguon,  Status, TenNguon) " & _
                                                    " ON (target.Manguon = source.Manguon) " & _
                                                " WHEN MATCHED  THEN UPDATE SET " & _
                                                        "Status=source.Status, TenNguon=source.TenNguon  " & _
                                             " WHEN NOT MATCHED THEN " & _
                                                "INSERT  (Manguon,Status, TenNguon ) " & _
                                                    "VALUES (source.Manguon,source.Status, source.TenNguon ); "

                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)
                Next
            End If


            If p_DataTablExe.Rows.Count > 0 Then
                SynNguonHang = Sys_Execute_DataTbl(p_DataTablExe, p_Desc)
                'Return mdlSyncMaster_SyncVehicleDown
            End If


            SynNguonHang = True

        Catch ex As Exception
            p_Desc = ex.Message
            SynNguonHang = False
        Finally
            c2sap.Connection.Close()
            c2sap.Dispose()
        End Try

    End Function
#End Region


#Region "Sync Vehicle"


    Public Function mdlSyncMaster_SyncVehicleDown(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByRef p_DataTablExe As DataTable, ByVal i_getAll As String, ByVal i_date As String,
                                                    ByRef p_Desc As String) As Boolean Implements IService.mdlSyncMaster_SyncVehicleDown
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_PhuongTienTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        'Dim l_bs_vehicle As BSVehicle
        'Dim l_bs_details As BSVehicleDetail
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_SQL As String
        Dim p_Row As DataRow

        Dim p_TableRun As New System.Data.DataTable("Table01")

        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            p_Desc = ""
            p_TableRun.Columns.Add("SQLSTRING", GetType(String))

            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ztb = New Connect2SAP.Str_PhuongTienTable()
            l_ret2 = New Connect2SAP.BAPIRET2()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetPhuongTien(i_date, i_getAll, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetPhuongTien(i_date, i_getAll, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetPhuongTien(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                'l_bs_details = New BSVehicleDetail()

                If i_getAll <> "H" Then                'Dong bo All
                    p_SQL = "DELETE FROM tblChiTietPhuongtien "
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)
                End If
                For i As Integer = 0 To l_ztb.Count - 1
                    If i_getAll = "H" Then                'Dong bo All
                        p_SQL = "DELETE FROM tblChiTietPhuongtien where MaPhuongTien='" & l_ztb.Item(i).Mapt.ToString() & "'"
                        p_Row = p_DataTablExe.NewRow
                        p_Row.Item(0) = p_SQL
                        p_DataTablExe.Rows.Add(p_Row)
                    End If

                    p_SQL = "MERGE tblPhuongtien AS target " & _
                        " USING (SELECT N'" & Replace(l_ztb.Item(i).Mapt.ToString(), "'", "", 1) & "' as MaPhuongTien ," & _
                                 "N'" & Replace(l_ztb.Item(i).Loaipt.ToString(), "'", "", 1) & "'  as LaiXe," & _
                                 "" & Convert.ToInt32(l_ztb.Item(i).Songan.ToString()) & "  as SoNgan ," & _
                                 "'" & Replace(l_ztb.Item(i).Ngaybatdau.ToString(), "'", "", 1) & "'  as Ngaybatdau, " & _
                                 "'" & Replace(l_ztb.Item(i).Ngayketthuc.ToString(), "'", "", 1) & "'  as NgayHieuLuc, " & _
                                "'S' as Status) AS source (MaPhuongTien, LaiXe, SoNgan, Ngaybatdau, NgayHieuLuc, Status) " & _
                                " ON (target.MaPhuongTien = source.MaPhuongTien) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "LaiXe=source.LaiXe " & _
                                    ",SoNgan=source.SoNgan " & _
                                    ",Ngaybatdau=source.Ngaybatdau " & _
                                    ",NgayHieuLuc=source.NgayHieuLuc " & _
                                    ",Status=source.Status, SyncDate=getdate()  " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (MaPhuongTien, LaiXe, SoNgan, Ngaybatdau, NgayHieuLuc, Status, SyncDate) " & _
                                "VALUES (source.MaPhuongTien,source.LaiXe,source.SoNgan,source.NgayHieuLuc,source.NgayHieuLuc,source.Status , getdate() ) ;"
                    'p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next

            End If

            mdlSyncMaster_SyncVehicleDetails(_SapConnectionString, _dtVariable, _ShPoint, _WareHouse, _TimeOut, p_DataTablExe, i_getAll, i_date, p_Desc)


            'If i_getAll <> "H" Then                'Dong bo All
            '    p_Row = p_DataTablExe.NewRow
            '    p_Row.Item(0) = "delete from tblChiTietPhuongTien where exists (select 1 from tblPhuongTien where ( Status is null or Status=''  or SyncDate is null)" & _
            '                  " and tblChiTietPhuongTien.MaPhuongTien=tblPhuongTien.MaPhuongTien)"
            '    p_DataTablExe.Rows.Add(p_Row)

            '    p_Row = p_DataTablExe.NewRow
            '    p_Row.Item(0) = "delete from tblPhuongTien where Status is null or Status=''  or SyncDate is null  "
            '    p_DataTablExe.Rows.Add(p_Row)


            'End If

            If i_getAll <> "H" Then                'Dong bo All
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = "delete from tblChiTietPhuongTien where exists (select 1 from tblPhuongTien where ( Status is null or Status=''  or  isnull(SyncDate,getdate()-10) < convert(date,getdate())  )" & _
                              " and tblChiTietPhuongTien.MaPhuongTien=tblPhuongTien.MaPhuongTien)"
                p_DataTablExe.Rows.Add(p_Row)

                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = "delete from tblPhuongTien where Status is null or Status='' or  isnull(SyncDate,getdate()-10) < convert(date,getdate()) "
                p_DataTablExe.Rows.Add(p_Row)


            End If

            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            If p_DataTablExe.Rows.Count > 0 Then
                mdlSyncMaster_SyncVehicleDown = Sys_Execute_DataTbl(p_DataTablExe, p_Desc)
                Return mdlSyncMaster_SyncVehicleDown
            End If


            Return True
        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try
    End Function

#End Region

#Region "Sync Vehicle Details"
    Private Function mdlSyncMaster_SyncVehicleDetails(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String,
                                                        ByRef p_Desc As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_ChiTietPhuongTienTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        ' Dim l_bs As BSVehicleDetail
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim l_mahh As String
        Dim p_SQL As String
        Dim p_Row As DataRow

        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            p_Desc = ""
            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_ChiTietPhuongTienTable()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetChiTietPhuongTien(i_date, i_getall, String.Empty, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetChiTietPhuongTien(i_date, i_getall, String.Empty, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetChiTietPhuongTien(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                If i_getall = "H" Then
                    mdlSyncMaster_SyncVehicleDetails_Upd(l_ztb, p_DataTablExe)
                End If

                For i As Integer = 0 To l_ztb.Count - 1
                    ' l_bs = New BSVehicleDetail()
                    l_err = String.Empty
                    l_mahh = String.Empty



                    p_SQL = "MERGE tblChiTietPhuongtien AS target " & _
                                           " USING (SELECT '" & Replace(l_ztb.Item(i).Mangan.ToString(), "'", "", 1) & "' as MaNgan," & _
                                                    "'" & Replace(l_ztb.Item(i).Mapt.ToString(), "'", "", 1) & "' as MaPhuongTien," & _
                                                    "" & Convert.ToDecimal(l_ztb.Item(i).Max_Nd.ToString()) & " as SoLuongMax," & _
                                                   "'S' as Status) AS source (MaNgan, MaPhuongTien, SoLuongMax, Status) " & _
                                                   " ON (target.MaPhuongTien = source.MaPhuongTien and target.MaNgan = source.MaNgan) " & _
                                               " WHEN MATCHED  THEN UPDATE SET " & _
                                                       "SoLuongMax=source.SoLuongMax " & _
                                                       ",Status=source.Status " & _
                                            " WHEN NOT MATCHED THEN " & _
                                               "INSERT  (MaNgan, MaPhuongTien, SoLuongMax, Status) " & _
                                                   "VALUES (source.MaNgan,source.MaPhuongTien,source.SoLuongMax,source.Status );"

                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If

            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True

        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try
    End Function
#End Region


    Public Function SynPhuongThuc(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                                    ByRef p_Desc As String) As Boolean Implements IService.SynPhuongThuc

        Dim ztbdc As Connect2SAP.Str_PhuongThucDCTable = New Connect2SAP.Str_PhuongThucDCTable()
        Dim ztbmt As Connect2SAP.Str_PhuongThucMTTable = New Connect2SAP.Str_PhuongThucMTTable()
        Dim p_SQL As String
        Dim p_Row As DataRow
        Dim c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_TankTable
        Dim ret2 As Connect2SAP.BAPIRET2
        Dim async As IAsyncResult
        Dim isCompleted As Boolean

        Dim p_TableRun As New System.Data.DataTable("Table01")

        Try


            p_Desc = ""
            p_TableRun.Columns.Add("SQLSTRING", GetType(String))

            c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            ret2 = New Connect2SAP.BAPIRET2()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                c2sap.GetPhuongThuc(i_getall, ztbdc, ztbmt, ret2)
            Else
                async = c2sap.BeginGetPhuongThuc(i_getall, ztbdc, ztbmt, Nothing, c2sap)
                isCompleted = async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If isCompleted Then
                    c2sap.EndGetPhuongThuc(async, ztbdc, ztbmt, ret2)
                End If
            End If


            If ztbmt.Count > 0 Then
                For i As Integer = 0 To ztbmt.Count - 1
                    'Cho dữ liệu vào CSDL SQL
                    'Phuong thuc xuat
                    p_SQL = "MERGE tblPhuongThucXuat AS target " & _
                        " USING (SELECT '" & Replace(ztbmt.Item(i).Maptxn.ToString(), "'", "", 1) & "' as MaPhuongThucXuat ," & _
                                 "N'" & Replace(ztbmt.Item(i).Tenptxn.ToString(), "'", "", 1) & "'  as TenPhuongThucXuat," & _
                                 "'" & Replace(ztbmt.Item(i).Status.ToString().Trim(), "'", "", 1) & "'  as Status ) AS source (MaPhuongThucXuat, TenPhuongThucXuat,  Status) " & _
                                " ON (target.MaPhuongThucXuat = source.MaPhuongThucXuat) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "TenPhuongThucXuat=source.TenPhuongThucXuat " & _
                                    ",Status=source.Status " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (MaPhuongThucXuat, TenPhuongThucXuat,  Status) " & _
                                "VALUES (source.MaPhuongThucXuat,source.TenPhuongThucXuat,source.Status ); "

                    '  p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_TableRun.NewRow
                    p_Row.Item(0) = p_SQL
                    p_TableRun.Rows.Add(p_Row)

                Next
            End If

            If ztbdc.Count > 0 Then
                For i As Integer = 0 To ztbdc.Count - 1
                    'Cho dữ liệu vào CSDL SQL
                    p_SQL = "MERGE tblPhuongThucBan AS target " & _
                        " USING (SELECT '" & Replace(ztbdc.Item(i).Maptb.ToString(), "'", "", 1) & "' as MaPhuongThucBan ," & _
                                 "N'" & Replace(ztbdc.Item(i).Tenptb.ToString(), "'", "", 1) & "'  as TenPhuongThucBan," & _
                                 "'" & Replace(ztbdc.Item(i).Status.ToString().Trim(), "'", "", 1) & "'  as Status ) AS source (MaPhuongThucBan, TenPhuongThucBan,  Status) " & _
                                " ON (target.MaPhuongThucBan = source.MaPhuongThucBan) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "TenPhuongThucBan=source.TenPhuongThucBan " & _
                                    ",Status=source.Status " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (MaPhuongThucBan, TenPhuongThucBan,  Status) " & _
                                "VALUES (source.MaPhuongThucBan,source.TenPhuongThucBan,source.Status ); "

                    p_Row = p_TableRun.NewRow
                    p_Row.Item(0) = p_SQL
                    p_TableRun.Rows.Add(p_Row)

                Next

            End If
            SynPhuongThuc = True

            If p_TableRun.Rows.Count > 0 Then
                SynPhuongThuc = Sys_Execute_DataTbl(p_TableRun, p_Desc)
                ' Return SynPhuongThuc()
            End If

        Catch ex As Exception
            p_Desc = ex.Message
            SynPhuongThuc = False
        Finally
            c2sap.Connection.Close()
            c2sap.Dispose()
        End Try

    End Function



    Public Function SynDonViTinh(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                    ByRef p_desc As String) As Boolean Implements IService.SynDonViTinh

        Dim ztb As Connect2SAP.Str_DonViTinhTable = New Connect2SAP.Str_DonViTinhTable()
        Dim c2sap As Connect2SAP.Connect2SAP
        'Try connect and get Data from SAP
        Dim l_ztb As Connect2SAP.Str_TankTable
        Dim ret2 As Connect2SAP.BAPIRET2
        Dim async As IAsyncResult
        Dim isCompleted As Boolean
        Dim p_SQL As String
        Dim p_Row As DataRow
        Dim p_TableRun As New System.Data.DataTable("Table01")

        Try


            p_desc = ""

            c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)

            ret2 = New Connect2SAP.BAPIRET2()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                c2sap.GetDonViTinh(i_getall, ztb, ret2)
            Else
                async = c2sap.BeginGetDonViTinh(i_getall, ztb, Nothing, c2sap)
                isCompleted = async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If isCompleted Then
                    c2sap.EndGetDonViTinh(async, ztb, ret2)
                End If
            End If

            ' dem = 0
            If ztb.Count > 0 Then
                For i As Integer = 0 To ztb.Count - 1
                    'Cho dữ liệu vào CSDL SQL
                    p_SQL = "MERGE tblDonViTinh AS target " & _
                        " USING (SELECT '" & Replace(ztb.Item(i).Madvt.ToString(), "'", "", 1) & "' as DonViTinh " & _
                                ") AS source (DonViTinh) " & _
                                " ON (target.DonViTinh = source.DonViTinh) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "DonViTinh=source.DonViTinh " & _
                                    " " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (DonViTinh) " & _
                                "VALUES (source.DonViTinh); "

                    '  p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                Next
            End If

            SynDonViTinh = True

            If p_DataTablExe.Rows.Count > 0 Then
                SynDonViTinh = Sys_Execute_DataTbl(p_DataTablExe, p_desc)
                ' Return SynPhuongThuc()
            End If


        Catch ex As Exception
            p_desc = ex.Message
            SynDonViTinh = False
        Finally
            c2sap.Connection.Close()
            c2sap.Dispose()
        End Try
    End Function



#Region "Sync Tank"
    Public Function mdlSyncMaster_SyncTank(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                           ByVal i_date As String, _
                                           ByVal i_plant As String, _
                                           ByRef p_Desc As String) As Boolean Implements IService.mdlSyncMaster_SyncTank
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_TankTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        ' Dim l_bs_tank As BSTank
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_SQL As String
        Dim p_Row As DataRow

        Dim p_TableRun As New System.Data.DataTable("Table01")

        Try


            p_Desc = ""
            '----------------------------------------------------------------------------------------------
            '   Lấy các loại phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ztb = New Connect2SAP.Str_TankTable()
            l_ret2 = New Connect2SAP.BAPIRET2()

            l_c2sap.Connection.Open()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetTank(i_date, i_getall, i_plant, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetTank(i_date, i_getall, i_plant, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetTank(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa dữ liệu vào hệ thống SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count <= 0 Then
                Return False
            End If
            '----------------------------------------------------------------------------------------------
            '   Đưa dữ liệu vào bảng Header
            '----------------------------------------------------------------------------------------------
            l_dem = l_ztb.Count
            For i As Integer = 0 To l_ztb.Count - 1
                'l_bs_tank = New BSTank()
                p_SQL = "MERGE tblTank AS target " & _
                                            " USING (SELECT '" & Replace(l_ztb.Item(i).Seqnr.ToString(), "'", "", 1) & "' as Name_nd " & _
                                                     ") AS source (Name_nd) " & _
                                                    " ON (target.Name_nd = source.Name_nd) " & _
                                                " WHEN MATCHED  THEN UPDATE SET " & _
                                                        "Name_nd=source.Name_nd " & _
                                                        " " & _
                                             " WHEN NOT MATCHED THEN " & _
                                                "INSERT  (Name_nd) " & _
                                                    "VALUES (source.Name_nd); "

                '  p_SQL = Replace(p_SQL, "''", "'", 1)
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)

            Next


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()
            If p_DataTablExe.Rows.Count > 0 Then
                mdlSyncMaster_SyncTank = Sys_Execute_DataTbl(p_DataTablExe, p_Desc)
                Return mdlSyncMaster_SyncTank
            End If

            Return True
        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try

    End Function
#End Region

#Region "Cac ham lien quan den lay lenh xuat tu SAP - 02-MAR-2016"



    'Private Function mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(ByVal l_ztb2 As Connect2SapEx.LIPSO2Table, _
    '                                                       ByRef p_DataExec As DataTable, _
    '                                                       ByVal i_wa As Connect2SAP.Str_PhieuXuat, _
    '                                                       ByVal i_malenh As String, _
    '                                                       ByVal i_ngayxuat As String, _
    '                                                       ByVal i_solenh As String, _
    '                                                       ByVal i_tongxuat As Decimal, _
    '                                                       ByVal i_tongduxuat As Decimal, _
    '                                                       ByVal i_loaiphieu As String, _
    '                                                       ByVal i_tableid As String, ByRef p_TableHangHoa As System.Data.DataTable) As Boolean
    '    '-----------------------------------------------------------------
    '    'Các biến cho vào bảng tblLenhXuat_HangHoa
    '    '   Key:
    '    '       MaLenh
    '    '       NgayXuat
    '    '       SoLenh      - phục vụ tìm kiếm nhanh
    '    '-----------------------------------------------------------------
    '    Dim l_mahanghoa, _
    '        l_donvitinh _
    '        As String

    '    '-----------------------------------------------------------------
    '    'Các biến Tính QCI
    '    '   l_out:      
    '    '   l_quantity: Tính lượng QCI trả ra
    '    '-----------------------------------------------------------------
    '    'Dim l_out As String()
    '    Dim l_quantity As Decimal() = New Decimal() {0, 0, 0, 0}
    '    Dim l_err As String
    '    Dim p_SQL As String
    '    'Dim p_DataTable As New DataTable("Table002")
    '    Dim p_DataTableCheck As DataTable
    '    Dim p_DataRow As DataRow
    '    Dim p_TBLTABLEID_ZT As Boolean = False
    '    Dim p_TableID As String
    '    Dim p_BeXuat As String

    '    Dim p_CountQCI As Integer
    '    Dim p_TongXuat As Decimal

    '    Dim p_RowHangHoa As System.Data.DataRow



    '    mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI = True





    '    p_SQL = "select Name from sys.all_objects where upper(Name)='TBLTABLEID_ZT'"
    '    p_DataTableCheck = GetDataTable(p_SQL, p_SQL)
    '    If Not p_DataTableCheck Is Nothing Then
    '        If p_DataTableCheck.Rows.Count > 0 Then
    '            p_TBLTABLEID_ZT = True
    '        End If
    '    End If

    '    l_donvitinh = i_wa.Unit.ToString()

    '    i_tongxuat = 0
    '    i_tongduxuat = Convert.ToDecimal(i_wa.Salequantity.ToString())

    '    '-----------------------------------------------------------------
    '    'Tính QCI
    '    '-----------------------------------------------------------------

    '    Try


    '        If i_wa.Material.Length > 7 Then
    '            l_mahanghoa = i_wa.Material.Substring(i_wa.Material.Length - 7, 7)
    '        Else
    '            l_mahanghoa = i_wa.Material.Substring(0, i_wa.Material.Length)
    '        End If

    '        l_err = String.Empty
    '        l_quantity(0) = 0
    '        l_quantity(1) = 0
    '        l_quantity(2) = 0
    '        l_quantity(3) = 0


    '        If p_QUYDOI_SAP = "Y" Then
    '            For p_CountQCI = 0 To l_ztb2.Count - 1
    '                'p_QUYDOI_SAP

    '                If l_ztb2(p_CountQCI).Posnr.ToString.Trim = i_wa.Item_Nd.ToString.Trim Then

    '                    Select Case UCase(l_ztb2(p_CountQCI).Msehi.ToString.Trim)
    '                        Case "L"
    '                            l_quantity(0) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(0), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
    '                            ' p_TongXuat = l_quantity(0)
    '                        Case "L15"
    '                            l_quantity(1) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(1), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
    '                            '  p_TongXuat = l_quantity(1)
    '                        Case "KG"
    '                            l_quantity(3) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(3), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
    '                            'p_TongXuat = l_quantity(2)
    '                        Case Else
    '                            l_quantity(2) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(2), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
    '                            '  p_TongXuat = l_quantity(3)
    '                    End Select
    '                End If
    '            Next

    '            'p_TongXuat = l_quantity(1)
    '            Select Case l_donvitinh
    '                Case "L"
    '                    p_TongXuat = i_tongduxuat 'l_quantity(0)
    '                Case "L15"
    '                    p_TongXuat = l_quantity(0)
    '                Case "KG"
    '                    p_TongXuat = l_quantity(0)
    '                Case Else
    '                    p_TongXuat = l_quantity(0)

    '            End Select

    '        Else
    '            l_quantity = mdlQCI_CalculateQCI(i_tongduxuat, i_wa.Unit, 15, 0.688)
    '            p_TongXuat = i_tongduxuat
    '        End If


    '        'Select Case l_donvitinh
    '        '    Case "L"
    '        '        p_TongXuat = l_quantity(0)
    '        '    Case "L15"
    '        '        p_TongXuat = l_quantity(1)
    '        '    Case "KG"
    '        '        p_TongXuat = l_quantity(3)
    '        '    Case Else
    '        '        p_TongXuat = l_quantity(2)

    '        'End Select

    '        If InsertQci(l_err, i_malenh, i_ngayxuat, i_wa.Item_Nd.ToString(), i_solenh, i_wa.Compartment.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3)) Then
    '            UpdateQci(l_err, i_solenh, i_wa.Compartment.ToString(), i_wa.Item_Nd.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3))
    '        End If
    '        p_BeXuat = ""
    '        p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat))
    '        '-----------------------------------------------------------------
    '        p_TableID = GetTableID()
    '        p_SQL = "INSERT INTO [tblLenhXuat_HangHoaE5] (LineID, MaLenh,NgayXuat, SoLenh,TongXuat, " & _
    '            "TongDuXuat, MaHangHoa, DonViTinh,BeXuat,TableID ,Createby,CreateDate) "
    '        p_SQL = p_SQL & " VALUES ('" & i_wa.Item_Nd.ToString() & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & i_solenh & "'" & _
    '                "," & p_TongXuat & "," & i_tongduxuat & ",'" & l_mahanghoa & "','" & l_donvitinh & "','" & p_BeXuat & "','" & p_TableID & "'," & g_User_ID & ",getdate())"

    '        p_DataRow = p_DataExec.NewRow
    '        p_DataRow.Item(0) = p_SQL
    '        p_DataExec.Rows.Add(p_DataRow)

    '        p_RowHangHoa = p_TableHangHoa.NewRow
    '        p_RowHangHoa.Item("TableID") = p_TableID
    '        p_RowHangHoa.Item("MaHangHoa") = l_mahanghoa
    '        p_RowHangHoa.Item("DonViTinh") = l_donvitinh
    '        p_RowHangHoa.Item("TongDuXuat") = i_tongduxuat
    '        p_RowHangHoa.Item("TongXuat") = p_TongXuat
    '        p_RowHangHoa.Item("BeXuat") = p_BeXuat
    '        p_RowHangHoa.Item("SoLenh") = i_solenh
    '        p_RowHangHoa.Item("MaLenh") = i_malenh
    '        p_RowHangHoa.Item("NgayXuat") = CDate(i_ngayxuat).ToString("yyyy/MM/dd")
    '        p_RowHangHoa.Item("LineID") = i_wa.Item_Nd.ToString()
    '        p_TableHangHoa.Rows.Add(p_RowHangHoa)

    '        If p_TBLTABLEID_ZT = True Then
    '            p_SQL = "INSERT INTO [TBLTABLEID_ZT](NgayXuat,TableID) VALUES ('" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & p_TableID & "')"
    '            p_DataRow = p_DataExec.NewRow
    '            p_DataRow.Item(0) = p_SQL
    '            p_DataExec.Rows.Add(p_DataRow)
    '        End If

    '    Catch ex As Exception
    '        mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI = False
    '    End Try
    'End Function


    ''anhqh 20160623
    'Private Function GetTableIDKV1(ByVal p_MaVanChuyen As String) As String
    '    Dim p_SQL As String
    '    Dim p_DataTable As DataTable

    '    p_SQL = " exec  FPT_GetTableID_KV1 '" & p_MaVanChuyen & "'"

    '    GetTableIDKV1 = ""
    '    Try
    '        p_DataTable = GetDataTable(p_SQL, p_SQL)
    '        If Not p_DataTable Is Nothing Then
    '            If p_DataTable.Rows.Count > 0 Then
    '                GetTableIDKV1 = p_DataTable.Rows(0).Item(0).ToString.Trim
    '            End If
    '        End If
    '    Catch ex As Exception
    '        GetTableIDKV1 = ""
    '    End Try

    'End Function

      'anhqh 20160920
    Private Function GetTableIDKV1(ByVal p_MaVanChuyen As String, ByVal p_date As Date, ByVal p_HangHoa As String) As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_Int As Integer
        ' p_SQL = " exec  FPT_GetTableID_KV1_NewNew '" & p_MaVanChuyen & "','" & p_date.ToString("yyyyMMdd") & "','" & p_HangHoa & "'"
        If p_MaVanChuyen = "ZR" Then
            p_SQL = " exec  FPT_GetTableID_KV1_NewNew '" & p_MaVanChuyen & "','" & p_date.ToString("yyyyMMdd") & "','" & p_HangHoa & "'"
        Else
            p_SQL = " exec  FPT_GetTableID_KV1_New '" & p_MaVanChuyen & "','" & p_date.ToString("yyyyMMdd") & "'"
        End If


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


    Private Function mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(ByVal p_Client As String, ByVal l_ztb2 As Connect2SapEx.LIPSO2Table, _
                                                           ByRef p_DataExec As DataTable, _
                                                           ByVal i_wa As Connect2SAP.Str_PhieuXuat, _
                                                           ByVal i_malenh As String, _
                                                           ByVal i_ngayxuat As String, _
                                                           ByVal i_solenh As String, _
                                                           ByVal i_tongxuat As Decimal, _
                                                           ByVal i_tongduxuat As Decimal, _
                                                           ByVal i_loaiphieu As String, _
                                                           ByVal i_tableid As String, ByRef p_TableHangHoa As System.Data.DataTable) As Boolean
        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat_HangHoa
        '   Key:
        '       MaLenh
        '       NgayXuat
        '       SoLenh      - phục vụ tìm kiếm nhanh
        '-----------------------------------------------------------------
        Dim l_mahanghoa, _
            l_donvitinh _
            As String

        '-----------------------------------------------------------------
        'Các biến Tính QCI
        '   l_out:      
        '   l_quantity: Tính lượng QCI trả ra
        '-----------------------------------------------------------------
        'Dim l_out As String()
        Dim l_quantity As Decimal() = New Decimal() {0, 0, 0, 0}

        Dim l_quantity2 As Decimal() = New Decimal() {0, 0, 0, 0}

        Dim p_NhietDoTemp As Double = 30
        Dim p_TyTrongBe As Double = 0.688

        Dim l_err As String
        Dim p_SQL As String
        'Dim p_DataTable As New DataTable("Table002")
        Dim p_DataTableCheck As DataTable
        Dim p_DataRow As DataRow
        Dim p_TBLTABLEID_ZT As Boolean = False
        Dim p_TableID As String
        Dim p_BeXuat As String

        Dim p_CountQCI As Integer
        Dim p_TongXuat As Decimal

        Dim p_TaiTrongKg As Decimal
        Dim p_LoaiVanChuyen As String = ""

        Dim p_Tank As String
        Dim p_RowHangHoa As System.Data.DataRow

        Dim p_CrdDate As Date

        mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI = True





        p_SQL = "select Name from sys.all_objects where upper(Name)='TBLTABLEID_ZT'"
        p_DataTableCheck = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTableCheck Is Nothing Then
            If p_DataTableCheck.Rows.Count > 0 Then
                p_TBLTABLEID_ZT = True
            End If
        End If

        l_donvitinh = i_wa.Unit.ToString()

        i_tongxuat = 0
        i_tongduxuat = Convert.ToDecimal(i_wa.Salequantity.ToString())

        '-----------------------------------------------------------------
        'Tính QCI
        '-----------------------------------------------------------------

        Try


            If i_wa.Material.Length > 7 Then
                l_mahanghoa = i_wa.Material.Substring(i_wa.Material.Length - 7, 7)
            Else
                l_mahanghoa = i_wa.Material.Substring(0, i_wa.Material.Length)
            End If

            l_err = String.Empty
            l_quantity(0) = 0
            l_quantity(1) = 0
            l_quantity(2) = 0
            l_quantity(3) = 0


            If p_QUYDOI_SAP = "Y" Then
                For p_CountQCI = 0 To l_ztb2.Count - 1
                    'p_QUYDOI_SAP

                    If l_ztb2(p_CountQCI).Posnr.ToString.Trim = i_wa.Item_Nd.ToString.Trim Then

                        Select Case UCase(l_ztb2(p_CountQCI).Msehi.ToString.Trim)
                            Case "L"
                                l_quantity(0) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(0), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                ' p_TongXuat = l_quantity(0)
                            Case "L15"
                                l_quantity(1) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(1), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                '  p_TongXuat = l_quantity(1)
                            Case "KG"
                                l_quantity(3) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(3), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                'p_TongXuat = l_quantity(2)
                            Case Else
                                l_quantity(2) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(2), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                '  p_TongXuat = l_quantity(3)
                        End Select
                    End If
                Next

                'p_TongXuat = l_quantity(1)
                Select Case l_donvitinh
                    Case "L"
                        p_TongXuat = i_tongduxuat 'l_quantity(0)
                    Case "L15"
                        p_TongXuat = l_quantity(0)
                    Case "KG"
                        p_TongXuat = l_quantity(0)
                    Case Else
                        p_TongXuat = l_quantity(0)

                End Select

            Else
                l_quantity = mdlQCI_CalculateQCI(i_tongduxuat, i_wa.Unit, 15, 0.688)
                p_TongXuat = i_tongduxuat
            End If


            'Select Case l_donvitinh
            '    Case "L"
            '        p_TongXuat = l_quantity(0)
            '    Case "L15"
            '        p_TongXuat = l_quantity(1)
            '    Case "KG"
            '        p_TongXuat = l_quantity(3)
            '    Case Else
            '        p_TongXuat = l_quantity(2)

            'End Select

            If InsertQci(l_err, i_malenh, i_ngayxuat, i_wa.Item_Nd.ToString(), i_solenh, i_wa.Compartment.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3)) Then
                UpdateQci(l_err, i_solenh, i_wa.Compartment.ToString(), i_wa.Item_Nd.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3))
            End If


            'p_BeXuat = ""
            ''anhqh  20160530
            'If CheckHangHoaE5(l_mahanghoa) = True Then
            '    p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat), "")
            '    p_BeXuat = GetTankActiveE5(p_BeXuat, CDate(i_ngayxuat))

            'Else
            '    p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat), p_Client)
            'End If

            p_BeXuat = ""
            p_Tank = ""


            p_LoaiVanChuyen = UCase(GetLoadingSite(i_wa.Transmot))

            'anhqh  20160530
            If CheckHangHoaE5(l_mahanghoa) = True Then
                p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat), p_Client, p_LoaiVanChuyen)
                p_Tank = GetTankActiveE5(p_BeXuat, CDate(i_ngayxuat))
            Else
                p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat), p_Client, p_LoaiVanChuyen)
                p_Tank = p_BeXuat
            End If

            '-----------------------------------------------------------------
            ''anhqh   20160623
            ''Ghep dac thu rieng cua KV1
            'If g_KV1 = True Then
            '    p_TableID = GetTableIDKV1(i_wa.Transmot.ToString())
            'Else
            '    p_TableID = GetTableID()
            'End If
            'anhqh   20160623
            'Ghep dac thu rieng cua KV1
            ' If g_Company_Code = "2110" Then
            If g_KV1 = True Then
                p_CrdDate = CDate(i_ngayxuat)
                p_TableID = GetTableIDKV1(i_wa.Transmot.ToString(), p_CrdDate, l_mahanghoa)
            Else
                p_TableID = GetTableID()
            End If

            ' p_TableID = GetTableID()

            'Tinh so KG tai trong  =========================================================================
            p_SQL = "select ISNULL((select NhietDo from tblNhietDo with (Nolock) where  " & _
                "CONVERT(date,crDate)=(select MAX(crDate) from tblNhietDo with (Nolock) )),30) as NhietDo," & _
                 "ISNULL((select top 1 Dens_nd from FPT_tblTankActive_V where Date1 =CONVERT(date,getdate()) " & _
                 "and Name_nd ='" & p_Tank & "'),0.688) as TyTrong"
            p_DataTableCheck = GetDataTable(p_SQL, p_SQL)


            l_quantity2(0) = 0
            l_quantity2(1) = 0
            l_quantity2(2) = 0
            l_quantity2(3) = 0

            If Not p_DataTableCheck Is Nothing Then
                If p_DataTableCheck.Rows.Count > 0 Then
                    p_NhietDoTemp = p_DataTableCheck.Rows(0).Item("NhietDo")
                    p_TyTrongBe = p_DataTableCheck.Rows(0).Item("TyTrong")

                End If
            End If





            If p_BeXuat.ToString.Trim <> "" And (p_LoaiVanChuyen = "BO" Or p_LoaiVanChuyen = "THUY") Then
                l_quantity2 = mdlQCI_CalculateQCI_NS("", p_TongXuat, "L", p_NhietDoTemp, p_TyTrongBe)
            End If


            p_TaiTrongKg = 0 ' l_quantity2(3)
            'Tinh so KG tai trong  =========================================================================


            p_SQL = "INSERT INTO [tblLenhXuat_HangHoaE5] (LineID, MaLenh,NgayXuat, SoLenh,TongXuat, " & _
                "TongDuXuat, MaHangHoa, DonViTinh,BeXuat,TableID ,Createby,CreateDate, QCI_KG, QCI_NhietDo, QCI_TyTrong) "
            p_SQL = p_SQL & " VALUES ('" & i_wa.Item_Nd.ToString() & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & i_solenh & "'" & _
                    "," & p_TongXuat & "," & i_tongduxuat & ",'" & l_mahanghoa & "','" & l_donvitinh & "','" & p_BeXuat & "','" & p_TableID & "'," & g_User_ID & ",getdate()" & _
                    "," & p_TaiTrongKg & "," & p_NhietDoTemp & "," & p_TyTrongBe & ")"

            p_DataRow = p_DataExec.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataExec.Rows.Add(p_DataRow)

            p_RowHangHoa = p_TableHangHoa.NewRow
            p_RowHangHoa.Item("TableID") = p_TableID
            p_RowHangHoa.Item("MaHangHoa") = l_mahanghoa
            p_RowHangHoa.Item("DonViTinh") = l_donvitinh
            p_RowHangHoa.Item("TongDuXuat") = i_tongduxuat
            p_RowHangHoa.Item("TongXuat") = p_TongXuat
            p_RowHangHoa.Item("BeXuat") = p_BeXuat
            p_RowHangHoa.Item("SoLenh") = i_solenh
            p_RowHangHoa.Item("MaLenh") = i_malenh
            p_RowHangHoa.Item("NgayXuat") = CDate(i_ngayxuat).ToString("yyyy/MM/dd")
            p_RowHangHoa.Item("LineID") = i_wa.Item_Nd.ToString()
            p_TableHangHoa.Rows.Add(p_RowHangHoa)

            If p_TBLTABLEID_ZT = True Then
                p_SQL = "INSERT INTO [TBLTABLEID_ZT](NgayXuat,TableID) VALUES ('" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & p_TableID & "')"
                p_DataRow = p_DataExec.NewRow
                p_DataRow.Item(0) = p_SQL
                p_DataExec.Rows.Add(p_DataRow)
            End If

        Catch ex As Exception
            mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI = False
        End Try
    End Function

    Private Function mdlSyncDeliveries_SynSpecific_QCI(ByRef p_NCC As String, _
                                                       ByRef l_ztb222 As Connect2SapEx.LIPSO2Table, _
                                                        ByVal p_SapConnectionString As String,
                                                        ByVal p_User_ID As Integer, ByVal p_Company_Code As String, _
                                                      ByVal i_solenh As String, ByRef o_err As String, ByVal p_Time As String) As Boolean
        '  Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_c2sapex As Connect2SapEx.Connect2Sap
        ' Dim l_ztb As Connect2SapEx.Str_PhieuXuatTable
        '  Dim l_ztb2 As Connect2SapEx.LIPSO2Table
        Dim l_ret2 As Connect2SapEx.BAPIRET2


        Dim l_err As String
        Dim l_f As Boolean = False

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        Dim p_TimeOut = New TimeSpan()




        Try

            mdlSyncDeliveries_SynSpecific_QCI = True
            l_c2sapex = New Connect2SapEx.Connect2Sap(p_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            ' l_ztb = New Connect2SapEx.Str_PhieuXuatTable()

            '            l_ztb2 = New Connect2SapEx.LIPSO2Table

            ' l_ztb As Connect2SapEx.LIPSO2Table
            l_err = String.Empty


            'anhqh
            '20160927
            'Them doan check tin dung
            '    Try
            Dim l_check As String
            l_check = String.Empty
            If p_Time = "25" Then
                l_c2sapex.CheckCredit(i_solenh, l_check, l_ret2)
            Else
                l_async = l_c2sapex.BeginCheckCredit(i_solenh, Nothing, l_c2sapex)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_Time, False)
                If l_isCompleted Then
                    l_c2sapex.EndCheckCredit(l_async, l_check, l_ret2)
                End If
            End If
            Select Case l_check.Trim.ToUpper()
                Case "E"
                    ' = "m117"
                    'Return False
                Case "C"
                    o_err = "Lệnh xuất đã vượt quá hạn mức tín dụng"
                    'o_err = "m220"
                    Return False
                Case "B"
                    'o_err = "m220"
                    o_err = "Lệnh xuất đã vượt quá hạn mức tín dụng"
                    Return False
                Case "Q"
                    'o_err = "m219"
                    'Return False
                    o_err = "Lệnh xuất chưa được gán TD!"
                    Return False


                Case Else
            End Select




            If p_Time = "25" Then
                ' l_c2sapex.(i_solenh, l_ztb, l_ret2)
                l_c2sapex.Select_LXQCI(i_solenh, p_NCC, l_ztb222, l_ret2)
            Else
                'l_async = l_c2sap.BeginGetPhieuXuat_Specific(i_solenh, l_ztb, Nothing, l_c2sap)
                l_async = l_c2sapex.BeginSelect_LXQCI(i_solenh, l_ztb222, Nothing, l_c2sapex)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    '=============================Hoi lai VinhND cho nay
                    l_c2sapex.EndSelect_LXQCI(l_async, p_NCC, l_ztb222, l_ret2)
                End If
            End If


        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try



    End Function



    'Public Function mdlSyncDeliveries_SynSpecific(ByVal p_User_ID As Integer, ByVal p_Company_Code As String, ByVal i_solenh As String, ByRef o_err As String) As Boolean Implements IService.mdlSyncDeliveries_SynSpecific
    '    Dim l_c2sap As Connect2SAP.Connect2SAP
    '    Dim l_c2sapex As Connect2SapEx.Connect2Sap
    '    Dim l_ztb As Connect2SAP.Str_PhieuXuatTable
    '    Dim l_ret2 As Connect2SAP.BAPIRET2
    '    Dim l_ret2ex As Connect2SapEx.BAPIRET2
    '    Dim l_err As String
    '    Dim l_f As Boolean = False

    '    Dim l_async As IAsyncResult
    '    Dim l_isCompleted As Boolean
    '    Dim p_SQL As String
    '    Dim p_TableConfig As DataTable
    '    Dim p_TableConfig1 As DataTable
    '    Dim p_SapConnectionString As String = ""
    '    Dim p_TimeOut = New TimeSpan()
    '    Dim p_WareHouse As String = ""
    '    Dim p_ShPoint As String = ""
    '    Dim p_DataRowArr() As DataRow

    '    Dim p_DataSet As New DataSet


    '    mdlSyncDeliveries_SynSpecific = False

    '    'p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG

    '    p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG; select * from tblConfig;"
    '    p_DataSet = p_SYS_GET_DATASET_Des(p_SQL, p_SQL)
    '    'p_TableConfig = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

    '    'If Not p_TableConfig Is Nothing Then
    '    '    If p_TableConfig.Rows.Count > 0 Then
    '    '        p_DataRowArr = p_TableConfig.Select("KEYCODE='TABLEID'")
    '    '        If p_DataRowArr.Length > 0 Then
    '    '            p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
    '    '        End If
    '    '    End If
    '    'End If

    '    If Not p_DataSet Is Nothing Then
    '        If p_DataSet.Tables.Count > 0 Then
    '            p_TableConfig = p_DataSet.Tables(0)
    '            p_TableConfig1 = p_DataSet.Tables(1)
    '        End If
    '    End If
    '    If Not p_TableConfig Is Nothing Then
    '        If p_TableConfig.Rows.Count > 0 Then
    '            p_DataRowArr = p_TableConfig.Select("KEYCODE='TABLEID'")
    '            If p_DataRowArr.Length > 0 Then
    '                p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
    '            End If


    '            p_DataRowArr = p_TableConfig.Select("KEYCODE='QUYDOI_SAP'")
    '            If p_DataRowArr.Length > 0 Then
    '                p_QUYDOI_SAP = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
    '            End If
    '        End If
    '    End If

    '    'p_SQL = "select * from tblConfig "

    '    'p_TableConfig = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

    '    If Not p_TableConfig1 Is Nothing Then
    '        If p_TableConfig1.Rows.Count > 0 Then
    '            p_SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
    '            p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
    '            p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
    '        End If

    '    End If
    '    If p_SapConnectionString = "" Then
    '        mdlSyncDeliveries_SynSpecific = True
    '        MsgBox("Loi ket noi")
    '        Exit Function
    '    End If


    '    Try
    '        l_c2sap = New Connect2SAP.Connect2SAP(p_SapConnectionString)
    '        l_ret2 = New Connect2SAP.BAPIRET2()
    '        l_ztb = New Connect2SAP.Str_PhieuXuatTable()
    '        l_err = String.Empty

    '        If p_TableConfig1.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
    '            l_c2sap.GetPhieuXuat_Specific(i_solenh, l_ztb, l_ret2)
    '        Else
    '            l_async = l_c2sap.BeginGetPhieuXuat_Specific(i_solenh, l_ztb, Nothing, l_c2sap)
    '            l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

    '            If l_isCompleted Then
    '                l_c2sap.EndGetPhieuXuat_Specific(l_async, l_ztb, l_ret2)
    '            End If
    '        End If

    '        If l_ztb.Count > 0 Then
    '            '------------------------------------------------------------------------------
    '            '   Kiểm tra thời hạn hiệu lực của hóa đơn
    '            '------------------------------------------------------------------------------
    '            'FES44
    '            '20141113
    '            If Not mdlSyncDeliveries_CheckStartTime(l_ztb.Item(0).Date_Nd) Then
    '                o_err = "Lệnh xuất chưa được phép xuất hàng!"
    '                Return False
    '            End If

    '            If Not mdlSyncDeliveries_CheckEndTime(l_ztb.Item(0).Date_E_Nd) Then
    '                o_err = "Lệnh xuất đã hết hạn!"
    '                Return False
    '            End If

    '            If l_ztb.Item(0).Plant <> p_WareHouse Then
    '                o_err = "Kiểm tra thông tin Kho xuất hàng ghi trên lệnh xuất!"
    '                Return False
    '            End If

    '            If l_ztb.Item(0).Shpoint = p_ShPoint Then
    '                If l_ztb.Item(0).Storage <> String.Empty Then
    '                    If l_ztb.Item(0).Batch_Nd <> String.Empty Then
    '                        If mdlSyncDeliveries_SubModifyFromTable_new(p_SapConnectionString, l_ztb, o_err) = False Then
    '                            l_c2sap.Connection.Close()
    '                            l_c2sap.Dispose()
    '                            Return False
    '                        End If

    '                        o_err = "Đồng bộ dữ liệu thành công!"
    '                        Return True
    '                    Else
    '                        o_err = "Lệnh xuất chưa được phép xuất hàng!"
    '                    End If
    '                Else
    '                    o_err = "Chưa có Storage Location nên không thể đồng bộ lệnh xuất này!"
    '                End If
    '            Else
    '                o_err = "Lệnh xuất khác Shipping Point nên không thể xuất hàng!"
    '            End If
    '        Else
    '            o_err = "Lệnh xuất không hợp lệ để thực hiện xuất hàng!"
    '        End If
    '        l_c2sap.Connection.Close()
    '        l_c2sap.Dispose()

    '        'Return True
    '    Catch ex As Exception
    '        o_err = ex.Message
    '        Return False
    '    End Try

    'End Function


    Private Function GetDiemTraHang(ByVal p_ChuyenVanTai As String, ByVal p_SapConnectionString As String,
                                        ByVal p_dtVariable As DataTable, ByVal p_TimeOut As TimeSpan) As String Implements IService.clsGetDiemTraHang
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.STR_DischardTable
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0

        ' Dim p_TimeOut = New TimeSpan()


        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy điểm trả hàng
            '----------------------------------------------------------------------------------------------
            l_c2sap = New Connect2SapEx.Connect2Sap(p_SapConnectionString)
            l_ztb = New Connect2SapEx.STR_DischardTable()
            l_ret2 = New Connect2SapEx.BAPIRET2()

            l_c2sap.Connection.Open()

            If p_dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetDischard(p_ChuyenVanTai, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetDischard(p_ChuyenVanTai, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetDischard(l_async, l_ztb, l_ret2)
                End If
            End If
            '----------------------------------------------------------------------------------------------
            '   Đóng kết nối với SAP
            '----------------------------------------------------------------------------------------------
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            '----------------------------------------------------------------------------------------------
            '   Kiểm tra dữ liệu đầu ra
            '----------------------------------------------------------------------------------------------

            If l_ztb.Count <= 0 Then
                Return ""
            End If

            '----------------------------------------------------------------------------------------------
            '   Phân tích điểm trả hàng
            '----------------------------------------------------------------------------------------------
            Dim l_routename As String
            Dim l_dischard As String()
            l_routename = l_ztb.Item(0).Routename.ToString()
            l_dischard = l_routename.Split("-")


            'If l_dischard Is Nothing Then
            '    Return String.Empty
            'End If

            Return l_dischard(l_dischard.Length - 1).Trim()
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function mdlSyncDeliveries_SynSpecific(ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_Company_Code As String, ByVal i_solenh As String, ByRef o_err As String) As Boolean Implements IService.mdlSyncDeliveries_SynSpecific
        Dim l_c2sap As Connect2SAP.Connect2SAP
        'Dim l_c2sapex As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SAP.Str_PhieuXuatTable
        ' Dim l_ztb As Connect2SapEx.LIPSO2Table
        Dim l_ret2 As Connect2SAP.BAPIRET2
        ' Dim l_ret2ex As Connect2SapEx.BAPIRET2
        Dim l_err As String
        Dim l_f As Boolean = False

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String
        Dim p_TableConfig As DataTable
        Dim p_TableConfig1 As DataTable
        Dim p_SapConnectionString As String = ""
        Dim p_TimeOut = New TimeSpan()
        Dim p_WareHouse As String = ""
        Dim p_ShPoint As String = ""
        Dim p_DataRowArr() As DataRow

        Dim p_DataSet As New DataSet



        Dim p_Batch As String
        Dim p_Slog As String
        Dim p_MaKhachHang As String
        Dim p_StringTmp As String = "0000000000"
        Dim p_SoLenh As String
        Dim p_Table As DataTable
        Dim p_DiemTraHang As String

        g_Company_Code = p_Company_Code

        mdlSyncDeliveries_SynSpecific = False
        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG; select * from tblConfig;"
        p_DataSet = p_SYS_GET_DATASET_Des(p_SQL, p_SQL)

        g_KV1 = False

        g_BATCHSLOG = False

        g_User_ID = p_User_ID

        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_TableConfig = p_DataSet.Tables(0)
                p_TableConfig1 = p_DataSet.Tables(1)
            End If
        End If


        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_DataRowArr = p_TableConfig.Select("KEYCODE='TABLEID'")
                If p_DataRowArr.Length > 0 Then
                    p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='QUYDOI_SAP'")
                If p_DataRowArr.Length > 0 Then
                    p_QUYDOI_SAP = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If


                p_DataRowArr = p_TableConfig.Select("KEYCODE='KV1'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_KV1 = True
                    Else
                        g_KV1 = False
                    End If
                End If


                p_DataRowArr = p_TableConfig.Select("KEYCODE='BATCHSLOG'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_BATCHSLOG = True
                    Else
                        g_BATCHSLOG = False
                    End If
                End If

                'MATUDONGHOA_PROD
                'anhqh
                '20161115
                p_DataRowArr = p_TableConfig.Select("KEYCODE='MATUDONGHOA_PROD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        p_MATUDONGHOA_PROD = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                    End If
                End If

            End If
        End If


        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                p_SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If
        If p_SapConnectionString = "" Then
            mdlSyncDeliveries_SynSpecific = True
            MsgBox("Loi ket noi")
            Exit Function
        End If


        Try
            l_c2sap = New Connect2SAP.Connect2SAP(p_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_PhieuXuatTable()
            ' l_ztb As Connect2SapEx.LIPSO2Table
            l_err = String.Empty

            If p_TableConfig1.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
                l_c2sap.GetPhieuXuat_Specific(i_solenh, l_ztb, l_ret2)

            Else
                l_async = l_c2sap.BeginGetPhieuXuat_Specific(i_solenh, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetPhieuXuat_Specific(l_async, l_ztb, l_ret2)
                End If
            End If

            If l_ztb.Count > 0 Then
                '------------------------------------------------------------------------------
                '   Kiểm tra thời hạn hiệu lực của hóa đơn
                '------------------------------------------------------------------------------
               

                'FES44
                '20141113
                'If Not mdlSyncDeliveries_CheckStartTime(l_ztb.Item(0).Date_Nd) Then
                '    o_err = "Lệnh xuất chưa được phép xuất hàng!"
                '    Return False
                'End If

                If g_KV1 = False Then
                    If Not mdlSyncDeliveries_CheckStartTime(l_ztb.Item(0).Date_Nd) Then
                        o_err = "Lệnh xuất chưa được phép xuất hàng!"
                        Return False
                    End If
                End If



                If Not mdlSyncDeliveries_CheckEndTime(l_ztb.Item(0).Date_E_Nd) Then
                    o_err = "Lệnh xuất đã hết hạn!"
                    Return False
                End If

                If l_ztb.Item(0).Plant <> p_WareHouse Then
                    o_err = "Kiểm tra thông tin Kho xuất hàng ghi trên lệnh xuất!"
                    Return False
                End If
                p_DiemTraHang = GetDiemTraHang(l_ztb(0).Shnumber.ToString.Trim, p_SapConnectionString,
                                      p_TableConfig1, p_TimeOut)


                If g_BATCHSLOG = True Then

                    For p_Count = 0 To l_ztb.Count - 1
                        'If l_ztb.Item(0).Resource_Nd = "N40" Or l_ztb.Item(0).Resource_Nd = "N45" Then
                        p_Batch = l_ztb.Item(p_Count).Batch_Nd
                        p_Slog = l_ztb.Item(p_Count).Storage
                        p_SoLenh = l_ztb.Item(p_Count).Order_No

                        p_MaKhachHang = Mid(p_Batch, 4)
                        p_MaKhachHang = Left(p_StringTmp, 10 - (Len(p_MaKhachHang))) & p_MaKhachHang

                        p_SQL = "exec FPT_CheckBatch '" & l_ztb.Item(p_Count).Order_No.ToString & "','" & l_ztb.Item(p_Count).Resource_Nd.ToString & _
                            "','" & p_Slog & "','" & l_ztb.Item(p_Count).Customer.ToString & "','" & p_MaKhachHang & "'"
                        p_Table = GetDataTable(p_SQL, p_SQL)
                        If Not p_Table Is Nothing Then
                            If p_Table.Rows.Count > 0 Then
                                o_err = p_Table.Rows(0).Item("Desc_Err").ToString.Trim
                                Return False
                            End If
                        End If
                    Next
                    ' If

                End If

                'If g_BATCHSLOG = True Then

                '    'If l_ztb.Item(0).Resource_Nd = "N40" Or l_ztb.Item(0).Resource_Nd = "N45" Then
                '    p_Batch = l_ztb.Item(0).Batch_Nd
                '    p_Slog = l_ztb.Item(0).Storage
                '    p_SoLenh = l_ztb.Item(0).Order_No

                '    p_MaKhachHang = Mid(p_Batch, 4)
                '    p_MaKhachHang = Left(p_StringTmp, 10 - (Len(p_MaKhachHang))) & p_MaKhachHang

                '    p_SQL = "exec FPT_CheckBatch '" & l_ztb.Item(0).Order_No.ToString & "','" & l_ztb.Item(0).Resource_Nd.ToString & _
                '        "','" & p_Slog & "','" & l_ztb.Item(0).Customer.ToString & "','" & p_MaKhachHang & "'"
                '    p_Table = GetDataTable(p_SQL, p_SQL)
                '    If Not p_Table Is Nothing Then
                '        If p_Table.Rows.Count > 0 Then
                '            o_err = p_Table.Rows(0).Item("Desc_Err").ToString.Trim
                '            Return False
                '        End If
                '    End If

                '    ' If

                'End If


                If l_ztb.Item(0).Shpoint = p_ShPoint Then
                    If l_ztb.Item(0).Storage <> String.Empty Then
                        If l_ztb.Item(0).Batch_Nd <> String.Empty Then

                            If mdlSyncDeliveries_SubModifyFromTable_new(p_Client, p_SapConnectionString, l_ztb, o_err, p_DiemTraHang) = False Then
                                l_c2sap.Connection.Close()
                                l_c2sap.Dispose()
                                Return False
                            End If
                            'hieptd4 add 20161102 
                            mdlSyncDeliveries_SynSpecific = mdlSyncDeliveries_SynSpecific_Ex(p_Client, p_User_ID, _
                                                                          p_Company_Code, i_solenh, o_err)

                            o_err = "Đồng bộ dữ liệu thành công!"
                            Return True
                        Else
                            o_err = "Lệnh xuất chưa được phép xuất hàng!"
                        End If
                    Else
                        o_err = "Chưa có Storage Location nên không thể đồng bộ lệnh xuất này!"
                    End If
                Else
                    o_err = "Lệnh xuất khác Shipping Point nên không thể xuất hàng!"
                End If
            Else
                o_err = "Lệnh xuất không hợp lệ để thực hiện xuất hàng!"
            End If
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            'Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try


    End Function

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


    'Private Function mdlSyncDeliveries_SubModifyFromTable_new(ByVal i_lt_temp As Connect2SAP.Str_PhieuXuatTable, ByRef p_desc As String) As Boolean

    '    '-----------------------------------------------------------------
    '    'Các Bussiness
    '    '-----------------------------------------------------------------
    '    ' Dim l_bs_Header As BSTransaction_new
    '    'Dim l_bs_Detail As BSTransactionDetail_new

    '    '-----------------------------------------------------------------
    '    'Work Area
    '    '-----------------------------------------------------------------
    '    Dim l_wa As Connect2SAP.Str_PhieuXuat = New Connect2SAP.Str_PhieuXuat()

    '    '-----------------------------------------------------------------
    '    'Các biến cho vào bảng tblLenhXuat        
    '    '-----------------------------------------------------------------
    '    Dim l_malenh, _
    '        l_solenh, _
    '        l_loaiphieu, _
    '        l_status _
    '        As String

    '    Dim l_ngayxuat _
    '        As String

    '    Dim l_sql, _
    '        l_err As String

    '    Dim l_dt_transaction As DataTable
    '    Dim p_Date As Date
    '    Dim p_Time As Integer
    '    '-----------------------------------------------------------------
    '    'Các biến cho vào bảng tblLenhXuat_HangHoa
    '    '   Key:
    '    '       MaLenh
    '    '       NgayXuat
    '    '       SoLenh      - phục vụ tìm kiếm nhanh
    '    '-----------------------------------------------------------------
    '    Dim l_lineid _
    '        As String

    '    Dim l_tongxuat, _
    '        l_tongduxuat _
    '        As Decimal

    '    Dim l_date, _
    '        l_month, _
    '        l_year _
    '        As Integer
    '    Dim p_DateTime As String
    '    Dim l_count As Integer = 0

    '    Dim p_DataExec As New DataTable("Table001")
    '    p_DataExec.Columns.Add("STR_SQL")

    '    Dim p_DataExecLine As New DataTable("Table002")
    '    p_DataExecLine.Columns.Add("STR_SQL")

    '    Dim p_DataRow As DataRow

    '    p_GetDateTime(p_Date, p_Time)
    '    p_DateTime = CDate(p_Date).ToString("dd/MM/yyyy")
    '    '-----------------------------------------------------------------
    '    '   Kiểm tra số lệnh đã tồn tại trong hệ thống hay chưa?
    '    '   Kiểm tra trạng thái của lệnh đó
    '    '-----------------------------------------------------------------
    '    '   l_bs_Header = New BSTransaction_new()
    '    l_sql = "select Solenh, Status from tblLenhXuatE5 with (Nolock)   where SoLenh = '" & i_lt_temp.Item(0).Outbound.ToString() & "'"
    '    l_err = String.Empty
    '    l_status = String.Empty
    '    l_dt_transaction = GetDataTable(l_sql, l_err)
    '    If l_dt_transaction IsNot Nothing Then
    '        If l_dt_transaction.Rows.Count > 0 Then
    '            l_status = l_dt_transaction.Rows(0).Item("Status").ToString()
    '        End If
    '    Else
    '        l_status = String.Empty
    '    End If


    '    Select Case l_status.Trim()
    '        Case String.Empty
    '        Case "1"
    '        Case "2"
    '            'Case "3"
    '            'Case "31"
    '            'Case "4"
    '            'Case "5"
    '            'Case "X"
    '        Case Else
    '            Return False
    '    End Select
    '    '-----------------------------------------------------------------

    '    '-----------------------------------------------------------------
    '    'Đặt mã mới theo ngày                        
    '    '-----------------------------------------------------------------
    '    l_solenh = i_lt_temp.Item(0).Outbound.ToString()

    '    l_date = p_DateTime.Substring(0, 2)
    '    l_month = p_DateTime.Substring(3, 2)
    '    l_year = p_DateTime.Substring(6, 4)
    '    l_ngayxuat = New DateTime(l_year, l_month, l_date)
    '    l_loaiphieu = i_lt_temp.Item(0).Shnumber.ToString()
    '    If l_loaiphieu = String.Empty Then
    '        l_loaiphieu = "V144"
    '    End If


    '    l_status = i_lt_temp.Item(0).Status.ToString()
    '    'l_malenh = l_bs_Header.SelectMaLenh(l_err, l_ngayxuat)

    '    'p_desc = "111"

    '    l_malenh = FPT_GetMaLenh(l_solenh)
    '    '-----------------------------------------------------------------
    '    '   Kiểm tra mã lệnh sau khi tính toán
    '    '-----------------------------------------------------------------
    '    If Not mdlSyncDeliveries_CheckMaLenh(l_malenh, l_ngayxuat) Then
    '        Return False
    '    End If
    '    '-----------------------------------hXuat------------------------------

    '    '-----------------------------------------------------------------
    '    '   1. Nếu (2) thành công thì Insert dữ liệu vào bảng tblLenhXuat
    '    '
    '    '   2. Insert dữ liệu vào bảng tblLenhXuatChiTiet (có TR)                       
    '    '
    '    '   3. Insert dữ liệu vào tblLenhXuat_HangHoa
    '    '
    '    '-----------------------------------------------------------------
    '    '-----------------------------------------------------------------
    '    '   1. Insert dữ liệu vào bảng tblLenhXuat
    '    '-----------------------------------------------------------------
    '    l_wa = i_lt_temp.Item(0)
    '    ' l_bs_Header = New BSTransaction_new()

    '    If Not mdlSyncDeliveries_SubModifyFromWorkArea(p_DataExec, l_wa, l_malenh, l_ngayxuat, g_Company_Code, p_desc) Then
    '        ' p_desc = "222"
    '        Return False
    '    End If
    '    If p_DataExec.Rows.Count > 0 Then
    '        p_DataRow = p_DataExec.NewRow
    '        p_DataRow.Item(0) = "DELETE FROM tblLenhXuat_HangHoaE5 where SoLenh='" & l_wa.Outbound.ToString() & "'"
    '        p_DataExec.Rows.Add(p_DataRow)
    '    End If

    '    ' p_desc = "333"

    '    '-----------------------------------------------------------------
    '    '   3. Insert dữ liệu vào tblLenhXuat_HangHoa
    '    '-----------------------------------------------------------------
    '    l_count = 0
    '    l_wa = i_lt_temp.Item(0)
    '    l_lineid = i_lt_temp.Item(0).Item_Nd.ToString()
    '    'p_desc = "i_lt_temp.Count=" & i_lt_temp.Count

    '    For i As Integer = 0 To i_lt_temp.Count - 1
    '        '  p_desc = "4445555"
    '        If l_wa.Item_Nd.ToString() <> i_lt_temp.Item(i).Item_Nd.ToString() Then
    '            l_tongxuat = 0
    '            l_tongduxuat = 0
    '            'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
    '            p_DataExecLine.Clear()


    '            If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine(p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_desc) Then
    '                l_count = l_count + 1
    '            End If
    '            l_wa = i_lt_temp.Item(i)
    '            If p_DataExecLine.Rows.Count > 0 Then
    '                p_DataExec.Merge(p_DataExecLine)
    '            End If
    '        End If

    '        If i = i_lt_temp.Count - 1 Then
    '            l_tongxuat = 0
    '            l_tongduxuat = 0
    '            'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
    '            p_DataExecLine.Clear()
    '            If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine(p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_desc) Then
    '                l_count = l_count + 1
    '                'p_desc = "gggggg"
    '            End If
    '            If p_DataExecLine.Rows.Count > 0 Then
    '                p_DataExec.Merge(p_DataExecLine)
    '            End If
    '        End If

    '    Next

    '    ' p_desc = "444"
    '    If l_count <> 0 Then
    '        l_err = String.Empty
    '        '  l_bs_Header.DeleteTransaction(l_err, l_solenh, l_ngayxuat)
    '        ' mdlSyncDeliveries_DeleteAllDetails_new(l_solenh)
    '        Return False
    '    End If

    '    If Not p_DataExec Is Nothing Then
    '        If Sys_Execute_DataTbl(p_DataExec, p_desc) = False Then
    '            'MsgBox(p_SQL)
    '            ' g_Module.ModErrExceptionNew("", p_desc)
    '            Return False
    '        End If
    '    End If

    '    ''p_desc = "666"

    '    Return True
    'End Function


    Private Sub SetHangHoaComParment(ByVal i_lt_temp As Connect2SAP.Str_PhieuXuatTable, ByRef p_TblHangHoa As DataTable)
        Dim p_Count As Integer
        Dim p_Count1 As Integer
        Dim p_Row As DataRow
        Dim p_Total As Double

        If p_TblHangHoa Is Nothing Then
            Exit Sub
        End If

        If p_TblHangHoa.Rows.Count <= 0 Then
            Exit Sub
        End If

        'anhqh
        '20161010
        If p_QUYDOI_SAP = "Y" Then
            Exit Sub
        End If

        For p_Count = 0 To p_TblHangHoa.Rows.Count - 1
            p_Row = p_TblHangHoa.Rows(p_Count)
            p_Total = 0
            If p_Row.Item("LineID").ToString.Trim <> "" Then
                For p_Count1 = 0 To i_lt_temp.Count - 1
                    If p_Row.Item("LineID").ToString.Trim = i_lt_temp(p_Count1).Item_Nd Then
                        p_Total = p_Total + i_lt_temp(p_Count1).Quantity
                    End If
                Next
            End If
            If p_Total > 0 Then
                p_TblHangHoa.Rows(p_Count).Item("TongXuat") = p_Total
                p_TblHangHoa.Rows(p_Count).Item("TongDuXuat") = p_Total
            End If
        Next

    End Sub


    Private Function mdlSyncDeliveries_SubModifyFromTable_new(ByVal p_Client As String, _
                                                                ByVal p_SapConnectionString As String, ByVal i_lt_temp As Connect2SAP.Str_PhieuXuatTable,
                                                              ByRef p_desc As String, ByVal p_DiemTraHang As String) As Boolean

        '-----------------------------------------------------------------
        'Các Bussiness
        '-----------------------------------------------------------------
        ' Dim l_bs_Header As BSTransaction_new
        'Dim l_bs_Detail As BSTransactionDetail_new

        '-----------------------------------------------------------------
        'Work Area
        '-----------------------------------------------------------------

        Dim p_MaTDH As Integer
        Dim l_wa As Connect2SAP.Str_PhieuXuat = New Connect2SAP.Str_PhieuXuat()

        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat        
        '-----------------------------------------------------------------
        Dim l_malenh, _
            l_solenh, _
            l_loaiphieu, _
            l_status _
            As String

        Dim l_ngayxuat _
            As String

        Dim l_sql, _
            l_err As String

        Dim l_dt_transaction As DataTable
        Dim p_Date As Date
        Dim p_Time As Integer
        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat_HangHoa
        '   Key:
        '       MaLenh
        '       NgayXuat
        '       SoLenh      - phục vụ tìm kiếm nhanh
        '-----------------------------------------------------------------
        Dim l_lineid _
            As String

        Dim l_tongxuat, _
            l_tongduxuat _
            As Decimal

        Dim l_date, _
            l_month, _
            l_year _
            As Integer
        Dim p_DateTime As String
        Dim l_count As Integer = 0

        Dim p_DataExec As New DataTable("Table001")
        p_DataExec.Columns.Add("STR_SQL")

        Dim p_DataExecLine As New DataTable("Table002")
        p_DataExecLine.Columns.Add("STR_SQL")

        Dim p_DataRow As DataRow
        Dim p_Count As Integer
        Dim l_ztb2 As Connect2SapEx.LIPSO2Table = New Connect2SapEx.LIPSO2Table()
        Dim p_NCC As String = ""
        Dim p_DUXUAT_TD As Boolean = False


        Dim p_MaVanChuyen As String = ""
        Dim p_table As DataTable
        Dim p_LOAIHINH_VT As Boolean = False
        Dim p_Array() As DataRow


        'Dim p_LibCustom As New LibCustom.Class1()


        l_sql = "select KEYCODE, KEYVALUE from SYS_CONFIG "
        p_table = GetDataTable(l_sql, l_err)
        If Not p_table Is Nothing Then
            If p_table.Rows.Count > 0 Then
                'If p_table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                '    p_TuDongHoa = True
                'End If
                p_TuDongHoa = False
                p_Array = p_table.Select("KEYCODE='MATUDONGHOA'")
                If p_Array.Length > 0 Then
                    If p_Array(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_TuDongHoa = True
                    End If
                End If

                p_DUXUAT_TD = False
                p_Array = p_table.Select("KEYCODE='DUXUAT_TD'")
                If p_Array.Length > 0 Then
                    If p_Array(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_DUXUAT_TD = True
                    End If
                End If

                p_LOAIHINH_VT = False
                p_Array = p_table.Select("KEYCODE='LOAIHINH_VT'")
                If p_Array.Length > 0 Then
                    If p_Array(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_LOAIHINH_VT = True
                    End If
                End If
            End If
        End If




        p_GetDateTime(p_Date, p_Time)
        p_DateTime = CDate(p_Date).ToString("dd/MM/yyyy")
        '-----------------------------------------------------------------
        '   Kiểm tra số lệnh đã tồn tại trong hệ thống hay chưa?
        '   Kiểm tra trạng thái của lệnh đó
        '-----------------------------------------------------------------
        '   l_bs_Header = New BSTransaction_new()
        l_sql = "select Solenh, Status from tblLenhXuatE5 with (Nolock)   where SoLenh = '" & i_lt_temp.Item(0).Outbound.ToString() & "'"
        l_err = String.Empty
        l_status = String.Empty
        l_dt_transaction = GetDataTable(l_sql, l_err)
        If l_dt_transaction IsNot Nothing Then
            If l_dt_transaction.Rows.Count > 0 Then
                l_status = l_dt_transaction.Rows(0).Item("Status").ToString()
            End If
        Else
            l_status = String.Empty
        End If

        Select Case l_status.Trim()
            Case String.Empty
            Case "1"
            Case "2"
                'Case "3"
                'Case "31"
                'Case "4"
                'Case "5"
                'Case "X"
            Case Else
                Return False
        End Select
        '-----------------------------------------------------------------

        '-----------------------------------------------------------------
        'Đặt mã mới theo ngày                        
        '-----------------------------------------------------------------
        l_solenh = i_lt_temp.Item(0).Outbound.ToString()

        l_date = p_DateTime.Substring(0, 2)
        l_month = p_DateTime.Substring(3, 2)
        l_year = p_DateTime.Substring(6, 4)
        ' l_ngayxuat = New DateTime(l_year, l_month, l_date)
        'anhqh
        '20160920
        If g_KV1 = True Then
            'i_lt_temp(0).Date_Nd
            l_date = i_lt_temp(0).Date_Nd.Substring(6, 2)
            l_month = i_lt_temp(0).Date_Nd.Substring(4, 2)
            l_year = i_lt_temp(0).Date_Nd.Substring(0, 4)
            l_ngayxuat = New DateTime(l_year, l_month, l_date)
        Else
            l_ngayxuat = New DateTime(l_year, l_month, l_date)
        End If

        l_loaiphieu = i_lt_temp.Item(0).Shnumber.ToString()
        If l_loaiphieu = String.Empty Then
            l_loaiphieu = "V144"
        End If


        l_status = i_lt_temp.Item(0).Status.ToString()
        'l_malenh = l_bs_Header.SelectMaLenh(l_err, l_ngayxuat)

        Dim p_Dem As Integer = 0
TaoMaLenh:

        ' l_malenh = FPT_GetMaLenh(l_solenh)
        If g_KV1 = True Then
            l_malenh = KV1_FPT_GetMaLenh(l_solenh, l_ngayxuat)
        Else
            l_malenh = FPT_GetMaLenh(l_solenh)
        End If


        '-----------------------------------------------------------------
        '   Kiểm tra mã lệnh sau khi tính toán
        '-----------------------------------------------------------------


        'anhqh
        '20160715
        'Sua lai nếu trùng mã lệnh  thì xóa trong bảng SYS_MALENH_S roi tạo lai
        If Not mdlSyncDeliveries_CheckMaLenh(l_malenh, l_ngayxuat) Then

            If p_Dem >= 3 Then
                p_desc = "Trùng Mã Lệnh=" & l_malenh
                Return False
            End If


            l_sql = ""

            l_sql = "delete  from SYS_MALENH_S where  SoLenh='" & l_solenh & "'"

            If Sys_Execute(l_sql, l_sql) = False Then

            End If

            p_Dem = p_Dem + 1

            GoTo taomalenh
        End If

        l_sql = ""




        'l_malenh = FPT_GetMaLenh(l_solenh)
        ''-----------------------------------------------------------------
        ''   Kiểm tra mã lệnh sau khi tính toán
        ''-----------------------------------------------------------------
        'If Not mdlSyncDeliveries_CheckMaLenh(l_malenh, l_ngayxuat) Then
        '    p_desc = "Trùng Mã Lệnh=" & l_malenh
        '    Return False
        'End If
        '-----------------------------------hXuat------------------------------

        '-----------------------------------------------------------------
        '   1. Nếu (2) thành công thì Insert dữ liệu vào bảng tblLenhXuat
        '
        '   2. Insert dữ liệu vào bảng tblLenhXuatChiTiet (có TR)                       
        '
        '   3. Insert dữ liệu vào tblLenhXuat_HangHoa
        '
        '-----------------------------------------------------------------
        '-----------------------------------------------------------------
        '   1. Insert dữ liệu vào bảng tblLenhXuat
        '-----------------------------------------------------------------

        'anhqh
        '20160918
        'Them lay loai hinh van tai theo ptien
        Dim p_MaPhuongTien As String
        Dim p_SQL As String

        If p_LOAIHINH_VT = True Then
            For p_Count = 0 To i_lt_temp.Count - 1
                If i_lt_temp(p_Count).Transmot.ToString.Trim = "" Then
                    p_MaPhuongTien = i_lt_temp(p_Count).Vehicle.ToString.Trim
                    p_SQL = "select LEFT(LaiXe,2) as LaiXe from tblPhuongTien with (nolock)  where   upper(MaPhuongTien)='" & UCase(p_MaPhuongTien) & "'"
                    p_table = GetDataTable(p_SQL, p_SQL)
                    If Not p_table Is Nothing Then
                        If p_table.Rows.Count > 0 Then
                            p_SQL = ""
                            p_SQL = p_table.Rows(0).Item(0).ToString.Trim
                            i_lt_temp(p_Count).Transmot = p_SQL
                        End If
                    End If
                End If
            Next
        End If



        l_wa = i_lt_temp.Item(0)
        ' l_bs_Header = New BSTransaction_new()

        If Not mdlSyncDeliveries_SubModifyFromWorkArea(p_Client, p_DataExec, l_wa, l_malenh, l_ngayxuat, g_Company_Code, p_desc, p_DiemTraHang) Then
            Return False
        End If
        If p_DataExec.Rows.Count > 0 Then
            p_DataRow = p_DataExec.NewRow
            p_DataRow.Item(0) = "DELETE FROM tblLenhXuat_HangHoaE5 where SoLenh='" & l_wa.Outbound.ToString() & "'"
            p_DataExec.Rows.Add(p_DataRow)
        End If


        ''Lay QCI 20160326 va kiem tra lay so dat hang hay so quy doi

        If mdlSyncDeliveries_SynSpecific_QCI(p_NCC, l_ztb2, p_SapConnectionString, g_User_ID, g_Company_Code, _
                                   l_wa.Outbound.ToString(), p_desc, 25) = False Then
            p_desc = p_desc
            Return False
        End If

        'NhaCungCap

        If p_DataExec.Rows.Count > 0 Then
            p_DataRow = p_DataExec.NewRow
            p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set NhaCungCap='" & p_NCC & "' where SoLenh='" & l_wa.Outbound.ToString() & "'"
            p_DataExec.Rows.Add(p_DataRow)
        End If


        'anhqh9999
        'Return True

        '-----------------------------------------------------------------
        '   3. Insert dữ liệu vào tblLenhXuat_HangHoa
        '-----------------------------------------------------------------
        l_count = 0
        l_wa = i_lt_temp.Item(0)
        l_lineid = i_lt_temp.Item(0).Item_Nd.ToString()


        Dim p_TableHangHoa As New DataTable
        Dim p_TableChiaNgan As New DataTable
        ' Dim p_SQL As String
        Dim p_dt_vehicle As DataTable

        p_SQL = "select MaNgan, SoLuongMax, 'X' as [Select] from FPT_tblChiTietPhuongTien_V where MaPhuongTien ='" & l_wa.Vehicle & "' ORDER By MaNgan"
        p_dt_vehicle = GetDataTable(p_SQL, p_SQL)

        'Dim p_Row As System.Data.DataRow
        p_SQL = "select TableID, MaHangHoa, TenHangHoa,DonViTinh,TongDuXuat,TongXuat, MeterID, BeXuat, SoLenh,MaLenh," & _
               "NgayXuat,LineID  from FPT_tblLenhXuat_hanghoaE5_v where solenh='" & l_wa.Order_No & "'"
        p_TableHangHoa = GetDataTable(p_SQL, p_SQL)
        p_TableHangHoa.Columns.Add("NhietDo")
        p_TableHangHoa.Columns.Add("TaiTrong")
        p_TableHangHoa.Columns.Add("TyTrong")
        p_TableHangHoa.Clear()
        'Dim p_LibCustom As New Class1()
        Dim p_PhuongTien As String = ""
        p_PhuongTien = l_wa.Vehicle
        ' p_LibCustom.clsLoadDefault(p_PhuongTien, p_TableHangHoa, p_TableChiaNgan)
        If g_KV1 = False Then


            For i As Integer = 0 To i_lt_temp.Count - 1

                If l_wa.Item_Nd.ToString() <> i_lt_temp.Item(i).Item_Nd.ToString() Then
                    l_tongxuat = 0
                    l_tongduxuat = 0
                    'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
                    p_DataExecLine.Clear()



                    'anhqh 20160530================================
                    If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, _
                                                                            l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa) Then
                        l_count = l_count + 1
                    End If


                    l_wa = i_lt_temp.Item(i)
                    If p_DataExecLine.Rows.Count > 0 Then
                        p_DataExec.Merge(p_DataExecLine)
                    End If
                End If

                If i = i_lt_temp.Count - 1 Then
                    l_tongxuat = 0
                    l_tongduxuat = 0
                    'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
                    p_DataExecLine.Clear()
                    'If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine(p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty) Then
                    '    l_count = l_count + 1
                    'End If

                    'anhqh 20160530================================================
                    If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa) Then
                        l_count = l_count + 1
                    End If
                    If p_DataExecLine.Rows.Count > 0 Then
                        p_DataExec.Merge(p_DataExecLine)
                    End If
                End If

            Next
        Else
            For i As Integer = 0 To i_lt_temp.Count - 1

                If l_wa.Item_Nd.ToString() <> i_lt_temp.Item(i).Item_Nd.ToString() Then
                    l_tongxuat = 0
                    l_tongduxuat = 0
                    'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
                    p_DataExecLine.Clear()


                    'If g_KV1 = True Then
                    '    'anhqh 20160530================================
                    '    If Not KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, _
                    '                                                            l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa) Then
                    '        l_count = l_count + 1
                    '    End If

                    '    KV1_GenScriptfromTbl(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, _
                    '                                                   l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa)
                    'Else
                    'anhqh 20160530================================
                    If Not KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, _
                                                                            l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa) Then
                        l_count = l_count + 1
                    End If

                    '   End If


                    'If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine(p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty) Then
                    '    l_count = l_count + 1
                    'End If
                    l_wa = i_lt_temp.Item(i)
                    If p_DataExecLine.Rows.Count > 0 Then
                        p_DataExec.Merge(p_DataExecLine)
                    End If
                End If

                If i = i_lt_temp.Count - 1 Then
                    l_tongxuat = 0
                    l_tongduxuat = 0
                    'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
                    p_DataExecLine.Clear()
                    'If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine(p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty) Then
                    '    l_count = l_count + 1
                    'End If

                    'anhqh 20160530================================================
                    If Not KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa) Then
                        l_count = l_count + 1
                    End If
                    If p_DataExecLine.Rows.Count > 0 Then
                        p_DataExec.Merge(p_DataExecLine)
                    End If
                End If

            Next

            KV1_GenScriptfromTbl(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa)
            If p_DataExecLine.Rows.Count > 0 Then
                p_DataExec.Merge(p_DataExecLine)
            End If


        End If
    

        l_ztb2 = Nothing
        If l_count <> 0 Then
            l_err = String.Empty
           
            Return False
        End If

        
        'l_sql = "select  KEYVALUE from SYS_CONFIG where KEYCODE='MATUDONGHOA'"
        'p_table = GetDataTable(l_sql, l_err)
        'If Not p_table Is Nothing Then
        '    If p_table.Rows.Count > 0 Then
        '        If p_table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
        '            p_TuDongHoa = True
        '        End If
        '    End If
        'End If


        ''anhqh
        ''20160915
        ''Cau hinh de lay du xuat theo TD dat tren SAP
        'l_sql = "select  KEYVALUE from SYS_CONFIG where KEYCODE='DUXUAT_TD'"
        'p_table = GetDataTable(l_sql, l_err)
        'If Not p_table Is Nothing Then
        '    If p_table.Rows.Count > 0 Then
        '        If p_table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
        '            p_DUXUAT_TD = True
        '        End If
        '    End If
        'End If

        If Not p_TableHangHoa Is Nothing Then
            If p_TableHangHoa.Rows.Count > 0 Then
                p_MaVanChuyen = l_wa.Transmot.ToString.Trim

                p_MaVanChuyen = GetLoadingSite(p_MaVanChuyen)

                'If p_DUXUAT_TD = True Then
                '    SetHangHoaComParment(i_lt_temp, p_TableHangHoa)
                'End If

                'anhqh
                '20161012
                'Ham tinh lai gia tri theo ngan tren TD
                If p_DUXUAT_TD = True Then    ' And UCase(p_MaVanChuyen) = "BO" Then
                    Dim p_Change As Boolean
                    Dim p_Error As Integer

                    If p_QUYDOI_SAP = "N" Then
                        'mdlKiemTraNganVaLuongDat(i_lt_temp, l_wa.Vehicle, p_TableHangHoa, p_Change)
                        mdlKiemTraNganVaLuongDat(i_lt_temp, l_wa.Vehicle, p_TableHangHoa, p_Change, p_Error, p_desc)
                        If p_Error = True Then
                            Return False
                        End If
                    End If
                    '  If p_Change = False Then
                    SetHangHoaComParment(i_lt_temp, p_TableHangHoa)
                    'End If
                    'SetHangHoaComParment(i_lt_temp, p_TableHangHoa)
                    p_SQL = "select MaNgan, SoLuongMax, 'X' as [Select] from FPT_tblChiTietPhuongTien_V where MaPhuongTien ='" & l_wa.Vehicle & "' ORDER By MaNgan"
                    p_dt_vehicle = GetDataTable(p_SQL, p_SQL)


                End If



                'anhqh
                '20161012
                Dim p_LibCustom As New LibCustom.Class1(Nothing)
                'p_LibCustom.LoadDefault(p_dt_vehicle, p_PhuongTien, p_TableHangHoa, p_TableChiaNgan, p_MaVanChuyen)
                p_LibCustom.clsLoadDefault(p_dt_vehicle, p_PhuongTien, p_TableHangHoa, p_TableChiaNgan, p_MaVanChuyen)

                If Not p_TableChiaNgan Is Nothing Then

                    If l_loaiphieu <> "V144" Then
                        If p_TableChiaNgan.Rows.Count > 0 Then
                            If SetComparment(p_TableHangHoa, p_dt_vehicle, i_lt_temp, p_TableChiaNgan) = False Then

                            End If

                        End If
                    End If

                    For p_Count = 0 To p_TableChiaNgan.Rows.Count - 1
                        p_DataRow = p_DataExec.NewRow
                        If p_TuDongHoa = True Then
                            p_MaTDH = GetMaTuDongHoa()
                            If p_MaTDH = 0 Then
                                p_desc = "Lỗi khi lấy mã tự đông hóa"
                                Return False
                            End If
                        Else
                            p_MaTDH = 0
                        End If
                        p_SQL = "INSERT INTO tblLenhXuatChiTietE5 (DungTichNgan,MaNgan , MaLenh ,NgayXuat , LineID , SoLuongDuXuat , TableID , MaTuDongHoa )"
                        p_SQL = p_SQL & " VALUES (" & p_TableChiaNgan.Rows(p_Count).Item("DungTichNgan").ToString.Trim & _
                                ",'" & p_TableChiaNgan.Rows(p_Count).Item("MaNgan").ToString.Trim & "'" & _
                                 ",'" & p_TableChiaNgan.Rows(p_Count).Item("MaLenh").ToString.Trim & "'" & _
                                 ",convert(date,'" & CDate(l_ngayxuat).ToString("yyyyMMdd") & "')" & _
                                 ",'" & p_TableChiaNgan.Rows(p_Count).Item("LineID").ToString.Trim & "'" & _
                                 "," & IIf(p_TableChiaNgan.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim = "", 0, p_TableChiaNgan.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim) & "" & _
                                 ",'" & p_TableChiaNgan.Rows(p_Count).Item("TableID").ToString.Trim & "'" & _
                                 ",'" & p_MaTDH & "'" & _
                                ")"
                        p_DataRow.Item(0) = p_SQL
                        p_DataExec.Rows.Add(p_DataRow)

                    Next

                End If
               
            End If
        End If
        If Not p_DataExec Is Nothing Then
            If Sys_Execute_DataTbl(p_DataExec, p_desc) = False Then
                'MsgBox(p_SQL)
                ' g_Module.ModErrExceptionNew("", p_desc)
                Return False
            End If
        End If

        If l_loaiphieu <> "V144" And p_DUXUAT_TD = True Then
            p_DataExec.Clear()
            If p_TableHangHoa.Rows.Count > 0 Then
                For p_Count = 0 To p_TableHangHoa.Rows.Count - 1
                    p_DataRow = p_DataExec.NewRow
                    p_DataRow.Item(0) = "update  tblLenhXuat_HangHoaE5  set TongXuat  =" & IIf(p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim = "", 0, p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim) & ",  " & _
                            " TongDuXuat  =" & IIf(p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim = "", 0, p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim) & " " & _
                            " where TableID='" & p_TableHangHoa.Rows(p_Count).Item("TableID").ToString.Trim & "' " & _
                            " and SoLenh='" & p_TableHangHoa.Rows(p_Count).Item("SoLenh").ToString.Trim & "' "
                    p_DataExec.Rows.Add(p_DataRow)
                Next
            End If
            If p_DataExec.Rows.Count > 0 Then
                If Sys_Execute_DataTbl(p_DataExec, p_desc) = False Then
                    'MsgBox(p_SQL)
                    ' g_Module.ModErrExceptionNew("", p_desc)
                    Return False
                End If
            End If
        End If

        Return True
    End Function


    'anhqh
    '20161012
    'Ham kiem tra luong dat va dung tich ngan va Ngan cos khớp không, nếu không thì reser lại theo ngăn
    Private Sub mdlKiemTraNganVaLuongDat(ByRef i_lt_temp As Connect2SAP.Str_PhieuXuatTable, _
                                            ByVal p_MaPhuongTien As String, _
                                            ByRef p_TableHangHoa As DataTable, _
                                            ByRef p_Change As Boolean, ByRef p_Error As Boolean, ByRef p_DEsc As String)
        Dim p_Count As Integer
        Dim p_HangHoa As String
        Dim p_DungTichNgan As Integer
        Dim p_TblPhuongTien As DataTable
        Dim p_ArrRow() As DataRow
        Dim p_SQL As String
        '  Dim p_Desc As String
        Dim p_STT As Integer
        Dim p_NganHH As String = ""
        Dim p_STT1 As Integer = 0
        Dim p_Tmp As Integer

        Dim p_SaleQuantity As Integer
        '  Dim p_DungTichNgan As Integer
        Dim p_Reload As Boolean = False

        If i_lt_temp.Count <= 0 Then
            Exit Sub
        End If
        p_Change = False

        p_Error = False

        'i_lt_temp(p_Count).Quantity   Lượng theo ngăn phương tiện
        'i_lt_temp(p_Count).Salequantity   Lượng theo DO

        p_SQL = "select * from tblChiTietPhuongTien where MaPhuongTien='" & p_MaPhuongTien & "'"
        p_TblPhuongTien = GetDataTable(p_SQL, p_SQL)
        If p_TblPhuongTien Is Nothing Then
            Exit Sub
        End If
        For p_Count = 0 To i_lt_temp.Count - 1
            p_SaleQuantity = 0
            'p_SaleQuantity = i_lt_temp(p_Count).Salequantity
            p_SaleQuantity = i_lt_temp(p_Count).Quantity
            p_NganHH = i_lt_temp(p_Count).Compartment

            p_ArrRow = p_TblPhuongTien.Select("MaNgan='" & p_NganHH & "' AND SoLuongMax=" & p_SaleQuantity)
            If p_ArrRow.Length <= 0 Then
                p_Reload = True
                Exit For

            End If

        Next

        If p_Reload = True Then
            If mdlSyncMaster_SyncVehicleDown1(p_MaPhuongTien, p_STT, p_Desc) = False Then
            End If
            If p_STT = 0 Then
                ' Continue For
            End If
        End If

        p_SQL = "select * from tblChiTietPhuongTien where MaPhuongTien='" & p_MaPhuongTien & "'"
        p_TblPhuongTien = GetDataTable(p_SQL, p_SQL)
        If p_TblPhuongTien Is Nothing Then
            Exit Sub
        End If
        p_SaleQuantity = 0
        'Kiem tra tong luong theo ngan phai <= luong dat trong DO
        For p_Count = 0 To i_lt_temp.Count - 1
            p_NganHH = i_lt_temp(p_Count).Compartment
            'p_SaleQuantity = i_lt_temp(p_Count).Salequantity

            p_SaleQuantity = p_SaleQuantity + i_lt_temp(p_Count).Quantity

            p_ArrRow = p_TblPhuongTien.Select("MaNgan='" & p_NganHH & "'")
            'p_SaleQuantity=
            If p_ArrRow.Length > 0 Then
                Integer.TryParse(p_ArrRow(0).Item("SoLuongMax").ToString.Trim, p_Tmp)
                p_DungTichNgan = p_DungTichNgan + p_Tmp
            End If
        Next

        If p_SaleQuantity < p_DungTichNgan Then
            p_DEsc = "Lượng đặt hàng nhỏ hơn dung tích ngăn của phương tiện"
            p_Error = True
            Exit Sub
        End If

        For p_Count = 0 To i_lt_temp.Count - 1
            p_NganHH = i_lt_temp(p_Count).Compartment
            p_SaleQuantity = i_lt_temp(p_Count).Quantity
            p_ArrRow = p_TblPhuongTien.Select("MaNgan='" & p_NganHH & "'")
            'p_SaleQuantity=
            If p_ArrRow.Length > 0 Then
                Integer.TryParse(p_ArrRow(0).Item("SoLuongMax").ToString.Trim, p_DungTichNgan)
                '  If p_DungTichNgan <= p_SaleQuantity Or p_LoaiVanChuyen.ToString.Trim <> "BO" Then

                i_lt_temp(p_Count).Quantity = p_DungTichNgan
                'End If
            End If
        Next

    End Sub

    'anhqh
    '20161012
    'Ham kiem tra luong dat va dung tich ngan va Ngan cos khớp không, nếu không thì reser lại theo ngăn
    Private Sub mdlKiemTraNganVaLuongDat_Backup(ByRef i_lt_temp As Connect2SAP.Str_PhieuXuatTable, _
                                            ByVal p_MaPhuongTien As String, _
                                            ByRef p_TableHangHoa As DataTable, _
                                            ByRef p_Change As Boolean)
        Dim p_Count As Integer
        Dim p_HangHoa As String
        Dim p_DungTichNgan As Integer
        Dim p_TblPhuongTien As DataTable
        Dim p_ArrRow() As DataRow
        Dim p_SQL As String
        Dim p_Desc As String
        Dim p_STT As Integer
        Dim p_NganHH As String = ""

        Dim p_SaleQuantity As Integer
        Dim p_Reload As Boolean = False

        If i_lt_temp.Count <= 0 Then
            Exit Sub
        End If
        p_Change = False
        p_MaPhuongTien = i_lt_temp(0).Vehicle.ToString.Trim
        p_SQL = "select * from tblChiTietPhuongTien where MaPhuongTien='" & p_MaPhuongTien & "'"
        p_TblPhuongTien = GetDataTable(p_SQL, p_SQL)
        If p_TblPhuongTien Is Nothing Then
            Exit Sub
        End If
        For p_Count = 0 To i_lt_temp.Count - 1
            p_SaleQuantity = 0
            p_SaleQuantity = i_lt_temp(p_Count).Salequantity
            p_NganHH = i_lt_temp(p_Count).Compartment

            p_ArrRow = p_TblPhuongTien.Select("MaNgan='" & p_NganHH & "' AND SoLuongMax=" & p_SaleQuantity)
            If p_ArrRow.Length <= 0 Then
                p_Reload = True
                Exit For
            End If

        Next

        If p_Reload = True Then
            If mdlSyncMaster_SyncVehicleDown1(p_MaPhuongTien, p_STT, p_Desc) = False Then
            End If
            If p_STT = 0 Then
                ' Continue For
            End If
        End If

        p_SQL = "select * from tblChiTietPhuongTien where MaPhuongTien='" & p_MaPhuongTien & "'"
        p_TblPhuongTien = GetDataTable(p_SQL, p_SQL)
        If p_TblPhuongTien Is Nothing Then
            Exit Sub
        End If
        For p_Count = 0 To i_lt_temp.Count - 1
            p_NganHH = i_lt_temp(p_Count).Compartment
            p_ArrRow = p_TblPhuongTien.Select("MaNgan='" & p_NganHH & "'")
            'p_SaleQuantity=

            If p_ArrRow.Length > 0 Then
                Integer.TryParse(p_ArrRow(0).Item("SoLuongMax").ToString.Trim, p_SaleQuantity)
                i_lt_temp(p_Count).Quantity = p_SaleQuantity
            End If
        Next

    End Sub




    'anhqh
    '20170725
    'Dong bo rieng phuong tien
    Public Function mdlSyncMaster_SyncVehicleDown1(ByVal i_vehicle As String, ByRef p_Count As Integer, ByRef p_Desc As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_ChiTietPhuongTienTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String

        Dim p_Row As DataRow
        Dim p_DataTablExe As New System.Data.DataTable("Table0")

        Dim l_err As String = String.Empty
        Dim l_dem As Integer
        Dim p_dtVariable As DataTable
        Dim p_SapConnectionString As String
        Dim p_TimeOut As New TimeSpan()

        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            ''----------------------------------------------------------------------------------------------
            'If g_WcfE5 = True Then

            '    mdlSyncMaster_SyncVehicleDown1 = g_Services.ClsSyncMaster_SyncVehicleDownNew(_SapConnectionString, _
            '                                     _dtVariable, _
            '                                     _ShPoint, _
            '                                         _WareHouse, _
            '                                         _TimeOut, _
            '                                         i_vehicle, p_Count, p_Desc)

            '    Exit Function
            'End If


            p_SQL = "Select * from tblconfig"
            p_dtVariable = GetDataTable(p_SQL, p_SQL)

            p_SapConnectionString = p_dtVariable.Rows(0).Item("sapconnectionstring").ToString.Trim

            p_DataTablExe.Columns.Add("STR_SQL")
            l_c2sap = New Connect2SAP.Connect2SAP(p_SapConnectionString)
            l_ztb = New Connect2SAP.Str_ChiTietPhuongTienTable()
            l_ret2 = New Connect2SAP.BAPIRET2()

            l_c2sap.Connection.Open()





            If p_dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetChiTietPhuongTien(String.Empty, String.Empty, i_vehicle.ToUpper(), l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetChiTietPhuongTien(i_vehicle.ToUpper(), String.Empty, String.Empty, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetChiTietPhuongTien(l_async, l_ztb, l_ret2)
                End If
            End If

            p_Count = 0
            '----------------------------------------------------------------------------------------------
            '   Đưa dữ liệu vào hệ thống SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            l_dem = l_ztb.Count
            p_Count = l_ztb.Count
            If l_ztb.Count > 0 Then
                'l_bs_details = New BSVehicleDetail()

                ' For i As Integer = 0 To l_ztb.Count - 1
                p_SQL = "MERGE tblPhuongtien AS target " & _
                    " USING (SELECT N'" & Replace(l_ztb.Item(0).Mapt.ToString(), "'", "", 1) & "' as MaPhuongTien ," & _
                             "N'" & Replace(l_ztb.Item(0).Loaipt.ToString(), "'", "", 1) & "'  as LaiXe," & _
                             "" & Convert.ToInt32(l_dem) & "  as SoNgan ," & _
                             "'" & Replace(l_ztb.Item(0).Ngaybatdau.ToString(), "'", "", 1) & "'  as Ngaybatdau, " & _
                             "'" & Replace(l_ztb.Item(0).Ngayketthuc.ToString(), "'", "", 1) & "'  as NgayHieuLuc, " & _
                            "'S' as Status) AS source (MaPhuongTien, LaiXe, SoNgan, Ngaybatdau, NgayHieuLuc, Status) " & _
                            " ON (target.MaPhuongTien = source.MaPhuongTien) " & _
                        " WHEN MATCHED  THEN UPDATE SET " & _
                                "LaiXe=source.LaiXe " & _
                                ",SoNgan=source.SoNgan " & _
                                ",Ngaybatdau=source.Ngaybatdau " & _
                                ",NgayHieuLuc=source.NgayHieuLuc " & _
                                ",Status=source.Status " & _
                     " WHEN NOT MATCHED THEN " & _
                        "INSERT  (MaPhuongTien, LaiXe, SoNgan, Ngaybatdau, NgayHieuLuc, Status) " & _
                            "VALUES (source.MaPhuongTien,source.LaiXe,source.SoNgan,source.NgayHieuLuc,source.NgayHieuLuc,source.Status ) ;"
                'p_SQL = Replace(p_SQL, "''", "'", 1)
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)


                p_SQL = "DELETE FROM tblChiTietPhuongtien where MaPhuongTien='" & Replace(l_ztb.Item(0).Mapt.ToString(), "'", "", 1) & "'"
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)
                'l_dem = l_dem + 1

                For i As Integer = 0 To l_ztb.Count - 1
                    ' l_bs = New BSVehicleDetail()
                    l_err = String.Empty
                    ' l_mahh = String.Empty
                    p_SQL = "MERGE tblChiTietPhuongtien AS target " & _
                                           " USING (SELECT '" & Replace(l_ztb.Item(i).Mangan.ToString(), "'", "", 1) & "' as MaNgan," & _
                                                    "'" & Replace(l_ztb.Item(i).Mapt.ToString(), "'", "", 1) & "' as MaPhuongTien," & _
                                                    "" & Convert.ToDecimal(l_ztb.Item(i).Max_Nd.ToString()) & " as SoLuongMax," & _
                                                   "'S' as Status) AS source (MaNgan, MaPhuongTien, SoLuongMax, Status) " & _
                                                   " ON (target.MaPhuongTien = source.MaPhuongTien and target.MaNgan = source.MaNgan) " & _
                                               " WHEN MATCHED  THEN UPDATE SET " & _
                                                       "SoLuongMax=source.SoLuongMax " & _
                                                       ",Status=source.Status " & _
                                            " WHEN NOT MATCHED THEN " & _
                                               "INSERT  (MaNgan, MaPhuongTien, SoLuongMax, Status) " & _
                                                   "VALUES (source.MaNgan,source.MaPhuongTien,source.SoLuongMax,source.Status );"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next

                ' Next

                If p_DataTablExe.Rows.Count > 0 Then
                    If Sys_Execute_DataTableNew(p_DataTablExe, _
                                          p_SQL) = False Then
                        p_Desc = p_SQL
                        Return False
                    End If
                End If
            End If

            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True
        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try
    End Function



    'Private Function GetMaTuDongHoa() As Integer
    '    Dim p_SQL As String
    '    Dim p_DataTable As DataTable
    '    p_SQL = " exec FPT_Key_TuDongHoa"
    '    GetMaTuDongHoa = 0
    '    Try
    '        p_DataTable = GetDataTable(p_SQL, p_SQL)
    '        If Not p_DataTable Is Nothing Then
    '            If p_DataTable.Rows.Count > 0 Then
    '                GetMaTuDongHoa = p_DataTable.Rows(0).Item(0).ToString.Trim
    '            End If
    '        End If
    '    Catch ex As Exception
    '        GetMaTuDongHoa = 0
    '    End Try
    'End Function


    'anhqh
    '20161115
    Function GetMaTuDongHoa() As Integer
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_Pro_TuDongHoa As String
        Dim p_ArrRow() As DataRow
        'p_ArrRow = p_TableConfig.Select("KEYCODE='MATUDONGHOA_PROD'")
        'If p_ArrRow.Length > 0 Then
        '    p_Pro_TuDongHoa = p_ArrRow(0).Item("KEYVALUE").ToString.Trim
        'End If
        p_Pro_TuDongHoa = p_MATUDONGHOA_PROD
        p_SQL = " exec " & p_Pro_TuDongHoa
        GetMaTuDongHoa = 0
        Try
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetMaTuDongHoa = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
        Catch ex As Exception
            GetMaTuDongHoa = 0
        End Try
    End Function



    Private Function GetLoadingSite(ByVal p_MaVanChuyen As String) As String
        Dim p_SQL As String
        Dim p_DAtaTable As DataTable
        Try
            p_SQL = "select * from tblPara where CHARINDEX ('" & p_MaVanChuyen & "',Value_nd,1)>0"
            p_DAtaTable = GetDataTable(p_SQL, p_SQL)
            If p_DAtaTable.Rows.Count <= 0 Then
                Return "BO"
            End If
            Return p_DAtaTable.Rows(0).Item("Para").ToString.Trim
        Catch ex As Exception
            Return "BO"
        End Try


    End Function

    Private Function FPT_GetMaLenh(ByVal p_SoLenh As String) As String
        Dim p_ValueTmp As String = "0000"
        Dim p_SQL As String = ""
        Dim p_Value As Integer = 0
        Dim p_DataTable As DataTable
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
            p_SQL = "exec FPT_Get_SYS_MALENH '" & p_SoLenh & "'"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
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
    Private Function mdlSyncDeliveries_SubModifyFromWorkAreaLine(ByRef p_DataExec As DataTable, ByVal i_wa As Connect2SAP.Str_PhieuXuat, _
                                                           ByVal i_malenh As String, _
                                                           ByVal i_ngayxuat As String, _
                                                           ByVal i_solenh As String, _
                                                           ByVal i_tongxuat As Decimal, _
                                                           ByVal i_tongduxuat As Decimal, _
                                                           ByVal i_loaiphieu As String, _
                                                           ByVal i_tableid As String,
                                                           ByRef p_Desc As String) As Boolean
        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat_HangHoa
        '   Key:
        '       MaLenh
        '       NgayXuat
        '       SoLenh      - phục vụ tìm kiếm nhanh
        '-----------------------------------------------------------------
        Dim l_mahanghoa, _
            l_donvitinh _
            As String

        '-----------------------------------------------------------------
        'Các biến Tính QCI
        '   l_out:      
        '   l_quantity: Tính lượng QCI trả ra
        '-----------------------------------------------------------------
        'Dim l_out As String()
        Dim l_quantity As Decimal() = New Decimal() {0, 0, 0, 0}
        Dim l_err As String
        Dim p_SQL As String
        'Dim p_DataTable As New DataTable("Table002")
        Dim p_DataTableCheck As DataTable
        Dim p_DataRow As DataRow
        Dim p_TBLTABLEID_ZT As Boolean = False
        Dim p_TableID As String
        Dim p_BeXuat As String

        p_Desc = ""
        p_SQL = "select Name from sys.all_objects where upper(Name)='TBLTABLEID_ZT'"
        p_DataTableCheck = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTableCheck Is Nothing Then
            If p_DataTableCheck.Rows.Count > 0 Then
                p_TBLTABLEID_ZT = True
            End If
        End If
        'p_DataTable.Columns.Add("STR_LINE")
        'p_SQL = "DELETE FROM tblLenhXuat_HangHoaE5 where SoLenh='" & i_solenh & "'"
        'p_DataRow = p_DataTable.NewRow
        'p_DataRow.Item(0) = p_SQL
        'p_DataTable.Rows.Add(p_DataRow)

        l_donvitinh = i_wa.Unit.ToString()
        mdlSyncDeliveries_SubModifyFromWorkAreaLine = True
        i_tongxuat = 0
        i_tongduxuat = Convert.ToDecimal(i_wa.Salequantity.ToString())

        '-----------------------------------------------------------------
        'Tính QCI
        '-----------------------------------------------------------------

        Try


            If i_wa.Material.Length > 7 Then
                l_mahanghoa = i_wa.Material.Substring(i_wa.Material.Length - 7, 7)
            Else
                l_mahanghoa = i_wa.Material.Substring(0, i_wa.Material.Length)
            End If

            l_err = String.Empty

            l_quantity = mdlQCI_CalculateQCI(i_tongduxuat, i_wa.Unit, 15, 0.688)
            If InsertQci(l_err, i_malenh, i_ngayxuat, i_wa.Item_Nd.ToString(), i_solenh, i_wa.Compartment.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3)) Then
                UpdateQci(l_err, i_solenh, i_wa.Compartment.ToString(), i_wa.Item_Nd.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3))
            End If
            p_BeXuat = ""
            p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat))
            '-----------------------------------------------------------------
            p_TableID = GetTableID()
            p_SQL = "INSERT INTO [tblLenhXuat_HangHoaE5] (LineID, MaLenh,NgayXuat, SoLenh,TongXuat, " & _
                "TongDuXuat, MaHangHoa, DonViTinh,BeXuat,TableID ,Createby,CreateDate) "
            p_SQL = p_SQL & " VALUES ('" & i_wa.Item_Nd.ToString() & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & i_solenh & "'" & _
                    "," & l_quantity(1) & "," & i_tongduxuat & ",'" & l_mahanghoa & "','" & l_donvitinh & "','" & p_BeXuat & "','" & p_TableID & "'," & g_User_ID & ",getdate())"

            p_DataRow = p_DataExec.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataExec.Rows.Add(p_DataRow)

            If p_TBLTABLEID_ZT = True Then
                p_SQL = "INSERT INTO [TBLTABLEID_ZT](NgayXuat,TableID) VALUES ('" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & p_TableID & "')"
                p_DataRow = p_DataExec.NewRow
                p_DataRow.Item(0) = p_SQL
                p_DataExec.Rows.Add(p_DataRow)
            End If

        Catch ex As Exception
            p_Desc = ex.Message
            mdlSyncDeliveries_SubModifyFromWorkAreaLine = False
        End Try
    End Function


    'Private Function GetTankActive(ByVal p_MaHangHoa As String, ByVal p_Date As Date) As String
    '    Dim p_SQL As String
    '    Dim p_DataTable As DataTable
    '    Dim p_DateValue As String
    '    p_DateValue = p_Date.ToString("dd") & "/" & p_Date.ToString("MM") & "/" & p_Date.ToString("yyyy")
    '    GetTankActive = ""
    '    Try
    '        p_SQL = "SELECT Name_nd FROM [FPT_tblTankActive_V] where [Date_nd]='" & p_DateValue & "' and   Product_nd ='" & p_MaHangHoa & "'"
    '        p_DataTable = GetDataTable(p_SQL, p_SQL)
    '        If Not p_DataTable Is Nothing Then
    '            If p_DataTable.Rows.Count > 0 Then
    '                GetTankActive = p_DataTable.Rows(0).Item("Name_nd").ToString.Trim
    '            End If

    '        End If
    '    Catch ex As Exception
    '        GetTankActive = ""
    '    End Try
    'End Function

    Private Function GetTankActiveE5(ByVal p_TankE5 As String, ByVal p_Date As Date) As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_DateValue As String
        ' p_DateValue = p_Date.ToString("dd") & "/" & p_Date.ToString("MM") & "/" & p_Date.ToString("yyyy")
        GetTankActiveE5 = ""
        Try

            p_SQL = "SELECT Name_nd FROM [FPT_tblTankActive_V] where Date1='" & Format(p_Date.ToString("yyyyMMdd") & "' ") & _
                    " and Name_nd in (select top 1  TankID   from  FPT_tblMeterE5_V	where TankE5='" & p_TankE5 & "')"

            ' p_SQL = String.Format("SELECT Name_nd FROM [FPT_tblTankActive_V] where [Date_nd]='{0}' and   Product_nd ='{1}'", p_DateValue, p_MaHangHoa)
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTankActiveE5 = p_DataTable.Rows(0).Item("Name_nd").ToString.Trim
                End If

            End If
        Catch ex As Exception
            GetTankActiveE5 = ""
        End Try


    End Function


    Private Function GetTankActive(ByVal p_MaHangHoa As String, ByVal p_Date As Date, Optional ByVal p_Client As String = "", _
                                    Optional ByVal p_LoaiXuat As String = "BO") As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_DateValue As String
        Dim p_FILTERKHO As Boolean = False

        p_SQL = "SELECT  [KEYVALUE]  FROM [SYS_CONFIG] where KEYCODE='FILTERKHO'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                If p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    p_FILTERKHO = True
                End If
                'GetTankActive = p_DataTable.Rows(0).Item("Name_nd").ToString.Trim

            End If
        End If


        p_DateValue = p_Date.ToString("dd") & "/" & p_Date.ToString("MM") & "/" & p_Date.ToString("yyyy")
        GetTankActive = ""
        Try
            'If p_FILTERKHO = False Then
            '    p_SQL = "SELECT Name_nd FROM [FPT_tblTankActive_V] where Date1='" & Format(p_Date.ToString("yyyyMMdd") & "' and Product_nd ='" & p_MaHangHoa & "'")
            'Else
            '    p_SQL = "SELECT Name_nd FROM [FPT_tblTankActive_V] where Date1='" & Format(p_Date.ToString("yyyyMMdd") & _
            '            "' and Product_nd ='" & p_MaHangHoa & "' and  LEFT(Name_nd,LEN('" & p_Client & "'))='" & p_Client & "'  order by  ID Desc ")
            'End If

            If p_FILTERKHO = False Then
                p_SQL = "SELECT Name_nd FROM [FPT_tblTankActive_V] where Date1='" & Format(p_Date.ToString("yyyyMMdd") & "' and Product_nd ='" & p_MaHangHoa & "'") & _
                        " and  (loadingSite ='" & p_LoaiXuat & "'  or  loadingSite is null or loadingSite='') order by Len(loadingSite)"

                ' " and  upper(isnull(loadingSite,'BO'))='" & p_LoaiXuat & "'"
            Else
                p_SQL = "SELECT Name_nd FROM [FPT_tblTankActive_V] where Date1='" & Format(p_Date.ToString("yyyyMMdd")) & _
                        "' and Product_nd ='" & p_MaHangHoa & "' and  LEFT(Name_nd,LEN('" & p_Client & "'))='" & p_Client & "'  " & _
                        " and  (loadingSite ='" & p_LoaiXuat & "'  or  loadingSite is null or loadingSite='') order by Len(loadingSite)"
                'and  upper(isnull(loadingSite,'BO'))='" & p_LoaiXuat & "'  order by  ID Desc "
            End If

            ' p_SQL = String.Format("SELECT Name_nd FROM [FPT_tblTankActive_V] where [Date_nd]='{0}' and   Product_nd ='{1}'", p_DateValue, p_MaHangHoa)
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTankActive = p_DataTable.Rows(0).Item("Name_nd").ToString.Trim
                End If

            End If
        Catch ex As Exception
            GetTankActive = ""
        End Try
    End Function

    Private Function UpdateQci(ByRef err As String, ByVal i_solenh As String, ByVal i_mangan As String, ByVal i_lineid As String, _
                                        ByVal i_L As Decimal, ByVal i_L15 As Decimal, ByVal i_M15 As Decimal, ByVal i_KG As Decimal) As Boolean

        Dim p_SQL As String = ""
        p_SQL = "UPDATE [tblQci] SET  [L] = " & i_L & ", [KG] =" & i_KG & ",  [L15] = " & i_L15 & ", [M15] = " & i_M15 & " " & _
                    " WHERE    [SoLenh]= '" & i_solenh & "' and    [LineId]= '" & i_lineid & "' and    [MaNgan]= '" & i_mangan & "'"
        If Sys_Execute(p_SQL, p_SQL) = False Then

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

        If Sys_Execute(p_SQL, p_SQL) = False Then

        End If
    End Function


    Private Function GetTableID() As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable

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
            p_DataTable = GetDataTable(p_SQL, p_SQL)
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



    Private Function mdlSyncDeliveries_SubModifyFromWorkArea(ByVal p_Client As String, ByRef p_DataExec As DataTable, ByVal i_wa As Connect2SAP.Str_PhieuXuat, _
                                                            ByVal i_malenh As String, _
                                                            ByVal i_ngayxuat As String, ByVal p_CompanyCode As String, ByRef p_Desc As String,
                                                            ByVal p_DiemTraHang As String) As Boolean

        Dim l_solenh, _
            l_madonvi, _
            l_manguon, _
            l_makho, _
            l_mavanchuyen, _
            l_maphuongtien, _
            l_nguoivanchuyen, _
            l_maphuongthucban, _
            l_maphuongthucxuat, _
            l_makhachhang, _
            l_loaiphieu, _
            l_ngayhieuluc, _
            l_status _
            As String
        Dim l_number As Integer
        Dim l_err As String

        Dim p_DataRow As DataRow
        Dim p_SQL As String
        Dim p_MaHangHoa As String

        Dim NgayHetHieuLuc As Date

        Dim p_Count As Integer
        l_err = String.Empty
        Dim p_Slog As String = ""
        Dim p_Table As System.Data.DataTable
        Try


            l_solenh = i_wa.Outbound.ToString()
            l_madonvi = p_CompanyCode
            'l_manguon = i_wa.Batch_Nd.ToString()
            l_manguon = i_wa.Resource_Nd.ToString()
            l_makho = i_wa.Plant.ToString()
            'l_mavanchuyen = i_wa.Veh_Mode.ToString()
            l_mavanchuyen = i_wa.Transmot.ToString()
            l_maphuongtien = i_wa.Vehicle.ToString()
            l_nguoivanchuyen = i_wa.Drivercode.ToString()
            l_maphuongthucban = i_wa.Method_Dc.ToString()
            l_maphuongthucxuat = i_wa.Method_Mt.ToString()
            l_makhachhang = i_wa.Customer.ToString()
            l_loaiphieu = i_wa.Shnumber.ToString()

            p_MaHangHoa = Right(i_wa.Material.ToString(), 7)

            p_Slog = i_wa.Storage.ToString
            If l_loaiphieu = String.Empty Then
                l_loaiphieu = "V144"
                l_mavanchuyen = i_wa.Transmot.ToString()
            End If
            l_ngayhieuluc = i_wa.Date_E_Nd
            l_status = i_wa.Status.ToString()

            l_status = "1"
            l_number = 0
            p_SQL = ""

            If g_KV1 = True Then
                If Mid(p_MaHangHoa, 1, 2) = "07" Then
                    'anhqh
                    '20160628
                    p_Client = "FO"
                End If
            End If

            'anhqh  20160609
            'Them truong hop cau hinh cho KV1
            p_SQL = "SELECT * FROM SYS_CONFIG WHERE KEYCODE='" & l_mavanchuyen.ToString.Trim & "'"

            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    p_Client = p_Table.Rows(0).Item("KEYVALUE").ToString.Trim
                End If

            End If


            'anhqh
            '20160630
            NgayHetHieuLuc = CDate("01/01/1900")

            If l_ngayhieuluc.ToString.Trim <> "00000000" And l_ngayhieuluc <> "" Then
                Try
                    NgayHetHieuLuc = CDate(Mid(l_ngayhieuluc, 5, 2) & "/" & Right(l_ngayhieuluc, 2) & "/" & Left(l_ngayhieuluc, 4))
                Catch ex As Exception

                End Try

            End If


            If l_nguoivanchuyen = "" Then
                p_SQL = "select HoVaTen , sDefault  from dbo.tblPhuongTien_LaiXe where Maphuongtien='" & l_maphuongtien & "'"

                p_Table = GetDataTable(p_SQL, p_SQL)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        For p_Count = 0 To p_Table.Rows.Count - 1
                            If p_Table.Rows(p_Count).Item("sDefault").ToString.Trim = "Y" Then
                                l_nguoivanchuyen = p_Table.Rows(p_Count).Item("HoVaTen").ToString.Trim
                                Exit For
                            End If
                        Next
                        If l_nguoivanchuyen = "" Then
                            l_nguoivanchuyen = p_Table.Rows(0).Item("HoVaTen").ToString.Trim
                        End If
                    End If
                End If
            End If

            If Check_SoLenh(l_err, l_solenh) = False Then   'Chua ton tai so lenh
                'p_SQL = "INSERT INTO [tblLenhXuatE5] (Slog,Client, SoLenhSAP,[MaLenh],[NgayXuat],[SoLenh],[MaDonVi],[MaNguon],[MaKho]," & _
                '    "[MaVanChuyen],[MaPhuongTien],[NguoiVanChuyen],[MaPhuongThucBan],[MaPhuongThucXuat]," & _
                '    "[MaKhachHang],[LoaiPhieu],[Niem],[LuongGiamDinh],[NhietDoTaiTau],[GhiChu],[NgayHieuLuc],[Status],[Number] ,Createby,CreateDate) "
                'p_SQL = p_SQL & " VALUES ('" & p_Slog & "','" & p_Client & "','" & l_solenh & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & l_solenh & "','" & l_madonvi & "','" & l_manguon & "'" & _
                '        ",'" & l_makho & "','" & l_mavanchuyen & "','" & l_maphuongtien & "',N'" & l_nguoivanchuyen & "','" & l_maphuongthucban & "','" & l_maphuongthucxuat & "'" & _
                '        ",'" & l_makhachhang & "','" & l_loaiphieu & "','','','','','" & l_ngayhieuluc.ToString.Trim & "','" & l_status & "'," & l_number & _
                '        "," & g_User_ID & ",getdate())"

                'anhqh
                '20160630
                If NgayHetHieuLuc <> CDate("01/01/1900") Then
                    p_SQL = "INSERT INTO [tblLenhXuatE5] (DiemTraHang, NgayHetHieuLuc, Slog, Client, SoLenhSAP,[MaLenh],[NgayXuat],[SoLenh],[MaDonVi],[MaNguon],[MaKho]," & _
                    "[MaVanChuyen],[MaPhuongTien],[NguoiVanChuyen],[MaPhuongThucBan],[MaPhuongThucXuat]," & _
                    "[MaKhachHang],[LoaiPhieu],[Niem],[LuongGiamDinh],[NhietDoTaiTau],[GhiChu],[NgayHieuLuc],[Status],[Number] ,Createby,CreateDate) "
                    p_SQL = p_SQL & " VALUES (N'" & p_DiemTraHang & "','" & CDate(NgayHetHieuLuc).ToString("yyyyMMdd") & "','" & p_Slog & "','" & p_Client & "','" & l_solenh & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & l_solenh & "','" & l_madonvi & "','" & l_manguon & "'" & _
                            ",'" & l_makho & "','" & l_mavanchuyen & "','" & l_maphuongtien & "',N'" & l_nguoivanchuyen & "','" & l_maphuongthucban & "','" & l_maphuongthucxuat & "'" & _
                            ",'" & l_makhachhang & "','" & l_loaiphieu & "','','','','','" & l_ngayhieuluc.ToString.Trim & "','" & l_status & "'," & l_number & _
                            "," & g_User_ID & ",getdate())"
                Else
                    p_SQL = "INSERT INTO [tblLenhXuatE5] (DiemTraHang, NgayHetHieuLuc, Slog, Client, SoLenhSAP,[MaLenh],[NgayXuat],[SoLenh],[MaDonVi],[MaNguon],[MaKho]," & _
                        "[MaVanChuyen],[MaPhuongTien],[NguoiVanChuyen],[MaPhuongThucBan],[MaPhuongThucXuat]," & _
                        "[MaKhachHang],[LoaiPhieu],[Niem],[LuongGiamDinh],[NhietDoTaiTau],[GhiChu],[NgayHieuLuc],[Status],[Number] ,Createby,CreateDate) "
                    p_SQL = p_SQL & " VALUES (N'" & p_DiemTraHang & "',null,'" & p_Slog & "','" & p_Client & "','" & l_solenh & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & l_solenh & "','" & l_madonvi & "','" & l_manguon & "'" & _
                            ",'" & l_makho & "','" & l_mavanchuyen & "','" & l_maphuongtien & "',N'" & l_nguoivanchuyen & "','" & l_maphuongthucban & "','" & l_maphuongthucxuat & "'" & _
                            ",'" & l_makhachhang & "','" & l_loaiphieu & "','','','','','" & l_ngayhieuluc.ToString.Trim & "','" & l_status & "'," & l_number & _
                            "," & g_User_ID & ",getdate())"
                End If
            Else  ''Da ton tai so lenh
                p_SQL = "UPDATE [dbo].[tblLenhXuatE5] SET DiemTraHang =N'" & p_DiemTraHang & "', NgayHetHieuLuc='" & CDate(NgayHetHieuLuc).ToString("yyyyMMdd") & "', Slog='" & p_Slog & "', Client='" & p_Client & "',MaDonVi = '" & l_madonvi & "',MaNguon = '" & l_manguon & "', MaKho ='" & l_makho & "'" & _
                             ",MaVanChuyen = '" & l_mavanchuyen & "',MaPhuongTien='" & l_maphuongtien & "',NguoiVanChuyen=N'" & l_nguoivanchuyen & "',MaPhuongThucBan'" & l_maphuongthucban & "'" & _
                             ",MaPhuongThucXuat='" & l_maphuongthucxuat & "',MaKhachHang='" & l_makhachhang & "',LoaiPhieu='" & l_loaiphieu & "'" & _
                             ",NgayHieuLuc='" & l_ngayhieuluc.ToString.Trim & "',Status='" & l_status & "',Number=" & l_number & ", UpdatedBy=" & g_User_ID & ",UpdateDate=getdate() " & _
                             " WHERE   SoLenh ='" & l_solenh & "'"


            End If
            If p_SQL <> "" Then
                p_DataRow = p_DataExec.NewRow
                p_DataRow.Item(0) = p_SQL
                p_DataExec.Rows.Add(p_DataRow)
            End If
            Return True
        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try
    End Function

    Private Function Check_SoLenh(ByRef err As String, ByVal i_SoLenh As String) As Boolean
        Dim p_DataTable As DataTable
        Dim p_Err As String
        Check_SoLenh = False
        'Return g_c2SQL.ExeNonQuery("sp_Check_SoLenhE5", err, New SqlParameter("@SoLenh", i_SoLenh))
        p_DataTable = GetDataTable("exec sp_Check_SoLenhE5 '" & i_SoLenh & "'", p_Err)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Check_SoLenh = True
            End If
        End If
    End Function
#End Region

#Region "Cac ham thuc hien day du lieu tu HTTG->SAP    02-MAR-2016"

    Public Function mdlSyncDeliveries_Httg2Sap(ByVal i_dt_Header As DataTable, ByVal i_dt_Material As DataTable, ByVal i_dt_Details As DataTable,
                                                ByRef p_Desc As String) As Boolean Implements IService.mdlSyncDeliveries_Httg2Sap
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_PhieuXuatTable
        Dim l_ret2 As Connect2SAP.BAPIRET2

        Dim l_loaiphieu As String
        Dim l_solenh As String
        Dim l_started As String

        Dim p_SQL As String
        Dim p_DataRowArr() As DataRow
        'Dim p_Sys_Config As New DataTable
        'Dim p_TableConfig1 As New DataTable

        Dim p_dataset As DataSet

        Try

            p_SQL = "select * from tblPara ;select * from SYS_CONFIG;select * from tblConfig "

            p_dataset = p_SYS_GET_DATASET_Des(p_SQL, p_SQL)

            If p_dataset Is Nothing Then
                p_Desc = "Lỗi khi lấy thông tin cấu hình"
                mdlSyncDeliveries_Httg2Sap = True
                Exit Function
            ElseIf (p_dataset.Tables.Count <= 0) Then
                p_Desc = "Lỗi khi lấy thông tin cấu hình"
                mdlSyncDeliveries_Httg2Sap = True
                Exit Function
            End If

            g_dt_para = p_dataset.Tables(0)
            p_Sys_Config = p_dataset.Tables(1)
            p_TableConfig = p_dataset.Tables(2)


            'p_SQL = "select * from tblPara "

            'g_dt_para = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)


            'p_SQL = "select * from SYS_CONFIG "
            'p_Sys_Config = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)


            p_DataRowArr = p_Sys_Config.Select("KEYCODE='TONGDUXUAT'")
            If p_DataRowArr.Length > 0 Then
                p_TONGDUXUAT = p_DataRowArr(0).Item(1).ToString.Trim
            End If

            p_DataRowArr = p_Sys_Config.Select("KEYCODE='TONGDUXUATTHUY'")
            If p_DataRowArr.Length > 0 Then
                p_TONGDUXUATTHUY = p_DataRowArr(0).Item(1).ToString.Trim
            End If

            'p_SQL = "select * from tblConfig "

            'p_TableConfig = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

            If Not p_TableConfig Is Nothing Then
                If p_TableConfig.Rows.Count > 0 Then
                    _SapConnectionString = p_TableConfig.Rows(0).Item("sapconnectionstring").ToString.Trim
                    _WareHouse = p_TableConfig.Rows(0).Item("warehouse").ToString.Trim
                    _ShPoint = p_TableConfig.Rows(0).Item("shippingpoint").ToString.Trim
                End If

            End If
            If _SapConnectionString = "" Then
                p_Desc = "String kết nối đến SAP chưa khai báo"
                mdlSyncDeliveries_Httg2Sap = True
                Exit Function
            End If


            l_loaiphieu = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()

            l_ztb = New Connect2SAP.Str_PhieuXuatTable()
            '-----------------------------------------------------------------
            '   Kiểm tra xem có phải là tạo mới ở HTTG không
            '-----------------------------------------------------------------
            l_solenh = i_dt_Header.Rows(0).Item("SoLenh").ToString()
            l_started = l_solenh.Substring(0, 4)

            If l_started.Trim = _WareHouse And Char.IsLetter(l_solenh, 4) Then
                Return False
                If mdlSyncDeliveries_Created(i_dt_Header, i_dt_Material, i_dt_Details, l_ztb) Then
                    GoTo Confirm
                End If
            End If

            '-----------------------------------------------------------------
            '   Kiểm tra loại phiếu TR hay no TR
            '-----------------------------------------------------------------
            If l_loaiphieu <> "V144" Then
                If mdlSyncDeliveries_Shipment(i_dt_Header, i_dt_Material, i_dt_Details, l_ztb) Then

                End If
            Else
                mdlSyncDeliveries_NoShipment(i_dt_Header, i_dt_Material, i_dt_Details, l_ztb)
            End If


Confirm:

            If l_ztb.Count > 0 Then
                l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
                l_ret2 = New Connect2SAP.BAPIRET2()
                l_c2sap.ConfirmPhieuXuat(l_ztb, l_ret2)
                If l_ret2.Type = "E" Then
                    Return False
                End If
                '----------------------Tank------------------------------------
                mdlExtras_UpdateTank(i_dt_Material, p_Desc)
                If p_Desc <> "" Then
                    Return False
                End If
                '----------------------Tank------------------------------------
                'FES
                '20141003
                '----------------------E5--------------------------------------
                mdlExtras_ConfirmE5(l_solenh, i_dt_Details, p_Desc)
                If p_Desc <> "" Then
                    Return False
                End If
                '----------------------E5--------------------------------------
            Else
                Return False
            End If

            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            p_SQL = "Update tblLenhXuatE5 set Status='5' where SoLenh='" & l_solenh & "'"
            If Sys_Execute(p_SQL, p_SQL) = False Then
                Return False
            End If
            Return True

        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try
    End Function

    Sub mdlExtras_UpdateTank(ByVal i_dt As DataTable, ByRef p_Desc As String)

        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim t_do As Connect2SapEx.STR_TANKTable
        Dim s_do As Connect2SapEx.STR_TANK
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        p_Desc = ""
        Try
            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            t_do = New Connect2SapEx.STR_TANKTable()

            For i As Integer = 0 To i_dt.Rows.Count - 1
                s_do = New Connect2SapEx.STR_TANK()

                s_do.Outbound = i_dt.Rows(i).Item("Solenh").ToString()
                s_do.Item_Nd = i_dt.Rows(i).Item("LineID").ToString()
                s_do.Tank = i_dt.Rows(i).Item("BeXuat").ToString()
                t_do.Add(s_do)
            Next

            If p_TableConfig.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
                l_c2sap.Update_Tank(t_do, l_ret2)
            Else
                l_async = l_c2sap.BeginUpdate_Tank(t_do, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndUpdate_Tank(l_async, t_do, l_ret2)
                End If
            End If

            l_c2sap.Connection.Close()
            l_c2sap.Connection.Dispose()

        Catch ex As Exception
            '  MsgBox("Error: " & ex.Message)
            'ShowMessageBox(Err.Number.ToString, ex.Message)
            p_Desc = ex.Message
        End Try
    End Sub


    Sub mdlExtras_ConfirmE5(ByVal i_solenh As String, ByVal ii_dt As DataTable, ByRef p_Desc As String)

        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim lt_ret2 As Connect2SapEx.BAPIRET2Table
        Dim t_do As Connect2SapEx.STR_E5Table  '  Str_E5Table
        Dim s_do As Connect2SapEx.STR_E5 ' Str_E5
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_Check As String

        Dim p_SQL As String
        Dim i_dt As DataTable
        'Dim p_c2sql As Connect2SQL.Connect2SQL
        p_Desc = ""
        Try
            l_c2sap = New Connect2SapEx.Connect2Sap(_SapConnectionString)
            lt_ret2 = New Connect2SapEx.BAPIRET2Table()
            t_do = New Connect2SapEx.STR_E5Table()


            'p_SQL = "SELECT * FROM   tblLenhXuatChiTietE5  a with (nolock)  WHERE  exists (select 1 from  tblLenhXuat_HangHoaE5 b with (nolock), tblHangHoaE5 c " & _
            '                " where b.MaHangHoa=c.MaHangHoa and   a.LineID =b.LineID " & _
            '                    " and a.MaLenh=b.MaLenh  and b.SoLenh='" & i_solenh & "'  and a.NgayXuat =b.NgayXuat)"
            ' i_dt = GetDataTable(p_SQL, p_SQL)
            p_SQL = "SELECT a.*,a1.MaHangHoa_Scada as Map_Scadar   FROM   fpt_tblLenhXuatChiTietE5_v a with (nolock) ," & _
               " (select b.TableID, solenh, c.MaHangHoa_Scada   from  tblLenhXuat_HangHoaE5 b with (nolock), tblMap_MaHangHoa c  " & _
                   " where b.MaHangHoa=c.MaHangHoa_Sap    and b.SoLenh='" & i_solenh & "') a1  " & _
                   " where(a.TableID = a1.TableID and a.SoLenh =a1.solenh  )"


            '  i_dt = GetDataTable(p_SQL, p_SQL)

            If i_dt Is Nothing Then
                p_SQL = "SELECT a.*,a1.MaHangHoa_Scada as Map_Scadar   FROM   tblLenhXuatChiTietE5 a with (nolock) ," & _
                    " (select b.TableID, c.MaHangHoa_Scada   from  tblLenhXuat_HangHoaE5 b with (nolock), tblMap_MaHangHoa c  " & _
                        " where b.MaHangHoa=c.MaHangHoa_Sap    and b.SoLenh='" & i_solenh & "') a1  " & _
                        " where(a.TableID = a1.TableID)"
            Else
                If i_dt.Rows.Count <= 0 Then
                    p_SQL = "SELECT a.*,a1.MaHangHoa_Scada as Map_Scadar   FROM   tblLenhXuatChiTietE5 a with (nolock) ," & _
                        " (select b.TableID, c.MaHangHoa_Scada   from  tblLenhXuat_HangHoaE5 b with (nolock), tblMap_MaHangHoa c  " & _
                            " where b.MaHangHoa=c.MaHangHoa_Sap    and b.SoLenh='" & i_solenh & "') a1  " & _
                            " where(a.TableID = a1.TableID)"
                End If
            End If

            i_dt = GetDataTable(p_SQL, p_SQL)



            For i As Integer = 0 To i_dt.Rows.Count - 1
                ' p_Check = CheckItemToScada2(i_dt.Rows(i).Item("NGAY_DKY").ToString().Trim)
                If i_dt.Rows(i).Item("MA_HHOA").ToString() = "" Then
                    Continue For
                End If
                s_do = New Connect2SapEx.STR_E5()

                s_do.Outbound = i_solenh

                'NGAY_DKY,NGAY_BD,NGAY_KT,SO_CTU,MA_LENH,CARD_DATA,MA_NGAN,MA_HHOA,MA_HONG,MA_KHO,
                s_do.Ngay_Dky = i_dt.Rows(i).Item("NGAY_DKY").ToString()
                s_do.Ngay_Bd = i_dt.Rows(i).Item("NGAY_BD").ToString()
                s_do.Ngay_Kt = i_dt.Rows(i).Item("NGAY_KT").ToString()
                s_do.Card_Data = i_dt.Rows(i).Item("CARD_DATA").ToString()
                s_do.Ma_Hhoa = i_dt.Rows(i).Item("MA_HHOA").ToString()
                'Integer.TryParse(i_dt.Rows(i).Item("MA_HONG").ToString.Trim, s_do.Ma_Hong)

                s_do.Compartment = i_dt.Rows(i).Item("MaNgan").ToString()
                s_do.Gv = i_dt.Rows(i).Item("GV").ToString()
                s_do.Gst = i_dt.Rows(i).Item("GST").ToString()
                s_do.Gvtotal_Start = i_dt.Rows(i).Item("GVTOTAL_START").ToString()
                s_do.Gvtotal_End = i_dt.Rows(i).Item("GVTOTAL_END").ToString()
                s_do.Gsttotal_Start = i_dt.Rows(i).Item("GSTTOTAL_START").ToString()
                s_do.Gsttotal_End = i_dt.Rows(i).Item("GSTTOTAL_END").ToString()
                s_do.Kf = i_dt.Rows(i).Item("KF").ToString()
                s_do.Kf_E = i_dt.Rows(i).Item("KF_E").ToString()
                s_do.Avg_Mf = i_dt.Rows(i).Item("AVG_MF").ToString()
                s_do.Avg_Mf_E = i_dt.Rows(i).Item("AVG_MF_E").ToString()
                'FES44
                '20141118
                s_do.Avg_Ctl = GetCTLE5(i_dt.Rows(i).Item("NGAY_DKY").ToString(), i_dt.Rows(i).Item("MaLenh").ToString(), i_dt.Rows(i).Item("LineID").ToString())    ' i_dt.Rows(i).Item("AVG_CTL").ToString()
                s_do.Avg_Ctl_E = i_dt.Rows(i).Item("AVG_CTL_E").ToString()
                s_do.Avg_Ctl_Base = i_dt.Rows(i).Item("AVG_CTL_BASE").ToString()
                s_do.Rtd_Offset = i_dt.Rows(i).Item("RTD_OFFSET").ToString()
                s_do.Gv_E = i_dt.Rows(i).Item("GV_E").ToString()
                s_do.Gst_E = i_dt.Rows(i).Item("GST_E").ToString()
                s_do.Gvtotal_E_Start = i_dt.Rows(i).Item("GVTOTAL_E_START").ToString()
                s_do.Gvtotal_E_End = i_dt.Rows(i).Item("GVTOTAL_E_END").ToString()
                s_do.Gsttotal_E_Start = i_dt.Rows(i).Item("GSTTOTAL_E_START").ToString()
                s_do.Gsttotal_E_End = i_dt.Rows(i).Item("GSTTOTAL_E_END").ToString()
                s_do.Gv_Base = i_dt.Rows(i).Item("GV_BASE").ToString()
                s_do.Gst_Base = i_dt.Rows(i).Item("GST_BASE").ToString()
                s_do.Gvtotal_Base_Sta = i_dt.Rows(i).Item("GVTOTAL_BASE_START").ToString()
                s_do.Gvtotal_Base_End = i_dt.Rows(i).Item("GVTOTAL_BASE_END").ToString()
                s_do.Gsttotal_Base_St = i_dt.Rows(i).Item("GSTTOTAL_BASE_START").ToString()
                s_do.Gsttotal_Base_En = i_dt.Rows(i).Item("GSTTOTAL_BASE_END").ToString()
                s_do.Tyle_Tte = i_dt.Rows(i).Item("TYLE_TTE").ToString()
                s_do.V_Preset = i_dt.Rows(i).Item("V_PRESET").ToString()
                s_do.Tyle_Preset = i_dt.Rows(i).Item("TYLE_PRESET").ToString()
                s_do.Tytrong_Base = i_dt.Rows(i).Item("TYTRONG_BASE").ToString()
                s_do.Tytrong_E = i_dt.Rows(i).Item("TYTRONG_E").ToString()
                s_do.Ty_Trongtb = i_dt.Rows(i).Item("TY_TRONGTB").ToString()

                s_do.Ty_Trongtb_Base = i_dt.Rows(i).Item("TY_TRONGTB_BASE").ToString()
                s_do.Ty_Trongtb_E = i_dt.Rows(i).Item("TY_TRONGTB_E").ToString()
                s_do.Item_Nd = i_dt.Rows(i).Item("LineID").ToString()

                'FES99
                '20141226
                'Them cac thong tin ve KG
                s_do.Mass = i_dt.Rows(i).Item("MASS").ToString()
                s_do.Mass_Base = i_dt.Rows(i).Item("MASS_BASE").ToString()
                s_do.Mass_E = i_dt.Rows(i).Item("MASS_E").ToString()


                t_do.Add(s_do)
            Next

            If p_TableConfig.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.ConfirmE5(t_do, lt_ret2)
            Else
                l_async = l_c2sap.BeginConfirmE5(t_do, lt_ret2, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndConfirmE5(l_async, t_do, lt_ret2)
                End If
            End If

            'anhqh
            '20161116
            'Them doan neu day thong tin E5 len SAP loi thi tra ve trang thai E
            Dim ret2 As Connect2SapEx.BAPIRET2
            Try
                ret2 = lt_ret2.Item(0)

                If ret2.Type.ToString.Trim = "E" Then
                    p_Desc = "Lỗi khi đẩy thông tin E5 lên SAP. Đề nghị đưa lại lên SAP"
                End If
            Catch ex As Exception
                p_Desc = "Lỗi khi đẩy thông tin E5 lên SAP. Đề nghị đưa lại lên SAP"
            End Try


            l_c2sap.Connection.Close()
            l_c2sap.Connection.Dispose()

        Catch ex As Exception
            ' MsgBox("Error Confirm: " & ex.Message)
            p_Desc = ex.Message
        End Try
    End Sub

    'FES44
    '20141118
    Private Function GetCTLE5(ByVal p_Date As Date, ByVal p_MaLenh As String, ByVal p_LineID As String) As String
        ' Dim l_c2sql As Connect2SQL.Connect2SQL
        Dim p_Value As Double
        Dim p_SQL As String
        Dim p_DataTable As DataTable

        GetCTLE5 = "0"
        p_Value = 0

        p_SQL = "select dbo.fm_GetVCF_FromE5 ('" & p_Date.ToString("yyyyMMdd") & "','" & p_MaLenh.ToString.Trim & "','" & p_LineID & "') as VCF "
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                If p_DataTable.Rows(0).Item("VCF").ToString.Trim <> "" Then
                    p_Value = p_DataTable.Rows(0).Item("VCF").ToString.Trim
                End If

            End If
        End If
        'p_Value = l_c2sql.getDataValue("select dbo.fm_GetVCF_FromE5 ('" & p_Date.ToString("yyyyMMdd") & "','" & p_MaLenh.ToString.Trim & "','" & p_LineID & "') ")

        GetCTLE5 = p_Value.ToString.Trim
    End Function


    Private Function mdlSyncDeliveries_Created(ByVal i_dt_Header As DataTable, _
                                              ByVal i_dt_Material As DataTable, _
                                              ByVal i_dt_Details As DataTable, _
                                              ByRef o_ztb_Temp As Connect2SAP.Str_PhieuXuatTable) As Boolean
        Dim l_loaiphieu As String

        Try
            l_loaiphieu = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()

            If l_loaiphieu = "V144" Then
                '-----------------------------------------------------------------
                '   Create ztb khi không có TR                
                '-----------------------------------------------------------------
                If i_dt_Details.Rows.Count > 0 Then
                    If mdlSyncDeliveries_NoShipment(i_dt_Header, i_dt_Material, i_dt_Details, o_ztb_Temp) Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            Else
                '-----------------------------------------------------------------
                '   Create ztb khi có TR                
                '-----------------------------------------------------------------
                If i_dt_Details.Rows.Count > 0 Then
                    If mdlSyncDeliveries_Shipment(i_dt_Header, i_dt_Material, i_dt_Details, o_ztb_Temp) Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function mdlSyncDeliveries_NoShipment(ByVal i_dt_Header As DataTable, _
                                               ByVal i_dt_Material As DataTable, _
                                               ByVal i_dt_Details As DataTable, _
                                               ByRef o_ztb_Temp As Connect2SAP.Str_PhieuXuatTable) As Boolean
        Dim l_str As Connect2SAP.Str_PhieuXuat
        Dim l_lineid, _
            l_mangan, _
            l_chieucaohamhang, _
            l_loaiphieu _
            As String

        Dim l_quantity(), _
            l_quantity_conf(), _
            l_nhietdo(), _
            l_tytrong(), _
            l_meter_s(), _
            l_meter_e() _
            As Decimal

        Dim l_meter_n() _
            As String

        Dim l_lineid_int As Integer

        Dim l_vanchuyen As String
        Dim l_count() As Integer

        Try
            '-----------------------------------------------------------------
            '   Tìm Item lớn nhất
            '-----------------------------------------------------------------
            Dim l_item_max As Integer
            l_item_max = 0
            Try
                For i As Integer = 0 To i_dt_Material.Rows.Count - 1
                    If l_item_max <= Convert.ToInt32(i_dt_Material.Rows(i).Item("LineId").ToString()) Then
                        l_item_max = Convert.ToInt32(i_dt_Material.Rows(i).Item("LineId").ToString())
                    End If
                Next
            Catch ex As Exception
                Return False
            End Try
            '-----------------------------------------------------------------
            '   Tính trung bình tỉ trọng
            '   Tính bình quân gia quyền nhiệt độ
            '-----------------------------------------------------------------
            ReDim l_quantity(l_item_max)
            ReDim l_quantity_conf(l_item_max)
            ReDim l_nhietdo(l_item_max)
            ReDim l_tytrong(l_item_max)
            ReDim l_count(l_item_max)
            ReDim l_meter_n(l_item_max)
            ReDim l_meter_s(l_item_max)
            ReDim l_meter_e(l_item_max)
            l_chieucaohamhang = String.Empty

            For i As Integer = 0 To i_dt_Details.Rows.Count - 1
                l_lineid_int = Convert.ToInt32(i_dt_Details.Rows(i).Item("LineID").ToString())

                l_quantity(l_lineid_int) = l_quantity(l_lineid_int) + Convert.ToDecimal(i_dt_Details.Rows(i).Item("SoLuongDuXuat").ToString())
                l_quantity_conf(l_lineid_int) = l_quantity_conf(l_lineid_int) + Convert.ToDecimal(i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString())
                l_nhietdo(l_lineid_int) = l_nhietdo(l_lineid_int) + _
                                          Convert.ToDecimal(i_dt_Details.Rows(i).Item("NhietDo").ToString()) * _
                                          Convert.ToDecimal(i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString())

                l_tytrong(l_lineid_int) = l_tytrong(l_lineid_int) + Convert.ToDecimal(i_dt_Details.Rows(i).Item("TyTrong_15").ToString())

                l_meter_n(l_lineid_int) = i_dt_Details.Rows(i).Item("MaLuuLuongKe").ToString()

                If i_dt_Details.Rows(i).Item("sl_llkebd").ToString().ToString.Trim <> "" Then
                    If l_meter_s(l_lineid_int) > Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkebd").ToString()) Then
                        l_meter_s(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkebd").ToString())
                    Else
                        If l_meter_s(l_lineid_int) = 0 Then
                            l_meter_s(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkebd").ToString())
                        End If
                    End If
                Else
                    l_meter_s(l_lineid_int) = 0
                End If

                If i_dt_Details.Rows(i).Item("sl_llkekt").ToString.Trim <> "" Then
                    If l_meter_e(l_lineid_int) < Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkekt").ToString()) Then
                        l_meter_e(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkekt").ToString())
                    Else
                        If l_meter_e(l_lineid_int) = 0 Then
                            l_meter_e(l_lineid_int) = Convert.ToDecimal(i_dt_Details.Rows(i).Item("sl_llkekt").ToString())
                        End If
                    End If
                Else
                    l_meter_e(l_lineid_int) = 0
                End If



                l_count(l_lineid_int) = l_count(l_lineid_int) + 1
                l_chieucaohamhang = l_chieucaohamhang & "H" & i_dt_Details.Rows(i).Item("MaNgan").ToString() & ": " & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "; "
            Next

            For i As Integer = 0 To i_dt_Material.Rows.Count - 1
                l_str = New Connect2SAP.Str_PhieuXuat()
                '-----------------------------------------------------------------------------------------
                '   dữ liệu lấy từ i_dt_Header
                '-----------------------------------------------------------------------------------------
                l_str.Order_No = i_dt_Header.Rows(0).Item("Solenh").ToString()
                l_str.Outbound = i_dt_Header.Rows(0).Item("Solenh").ToString()
                l_str.Date_Nd = Format(i_dt_Header.Rows(0).Item("NgayXuat"), "yyyy-MM-dd")
                l_str.Plant = _WareHouse
                l_str.Batch_Nd = i_dt_Header.Rows(0).Item("MaNguon").ToString()
                l_str.Resource_Nd = i_dt_Header.Rows(0).Item("MaNguon").ToString()
                l_str.Method_Mt = i_dt_Header.Rows(0).Item("MaPhuongThucXuat").ToString()
                l_str.Method_Dc = i_dt_Header.Rows(0).Item("MaPhuongThucBan").ToString()
                l_str.Customer = i_dt_Header.Rows(0).Item("MaKhachHang").ToString()
                l_str.Shpoint = _ShPoint
                l_str.Transmot = i_dt_Header.Rows(0).Item("MaVanChuyen").ToString()
                l_str.Niem_Text = i_dt_Header.Rows(0).Item("Niem").ToString()
                l_str.Ngan_Text = l_chieucaohamhang
                l_str.Luong_Text = i_dt_Header.Rows(0).Item("LuongGiamDinh").ToString()
                l_str.Nhietdo_Text = i_dt_Header.Rows(0).Item("NhietDoTaiTau").ToString()
                '-----------------------------------------------------------------------------------------

                l_str.Veh_Mode = i_dt_Header.Rows(0).Item("MaVanChuyen").ToString()
                l_str.Vehicle = UCase(i_dt_Header.Rows(0).Item("MaPhuongTien").ToString())
                l_str.Drivercode = i_dt_Header.Rows(0).Item("NguoiVanChuyen").ToString()
                l_loaiphieu = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()
                '-----------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------------------------
                '   Dữ liệu được lấy từ i_dt_Material
                '-----------------------------------------------------------------------------------------
                l_lineid = i_dt_Material.Rows(i).Item("LineID").ToString()
                l_mangan = "144"
                l_str.Lineid = l_lineid.Substring(3, 3)
                l_str.Compartment = l_mangan
                l_str.Item_Nd = l_lineid
                l_str.Material = i_dt_Material.Rows(i).Item("MaHangHoa").ToString()
                l_str.Unit = i_dt_Material.Rows(i).Item("DonViTinh").ToString()
                l_str.Salequantity = i_dt_Material.Rows(i).Item("TongDuXuat").ToString()
                'If p_TONGDUXUAT = "1" Then
                '    l_str.Quantity = i_dt_Material.Rows(i).Item("TongDuXuat").ToString()
                'Else
                '    l_str.Quantity = i_dt_Material.Rows(i).Item("TongXuat").ToString()
                'End If
                l_str.Quantity = i_dt_Material.Rows(i).Item("TongDuXuat").ToString()
                '-----------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------------------------
                '   Dữ liệu được lấy từ i_dt_Details
                '-----------------------------------------------------------------------------------------
                '-----------------------------------------------------------------------------------------
                '   System Test KV2
                '       Lấy lượng thực xuất = lượng dự xuất với đường bộ
                '-----------------------------------------------------------------------------------------
                'l_vanchuyen = mdlDelivery_CheckTransmot(l_str.Transmot, g_dt_para)
                'If UCase(l_vanchuyen) = "BO" Or UCase(l_vanchuyen) = "SAT" Then
                '    If p_TONGDUXUAT = "1" Then  'Lay theo du xuat
                '        l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                '    Else ' Lay theo thuc xuat
                '        l_str.Quantity_Confirm = l_quantity_conf(Convert.ToDecimal(l_lineid))
                '    End If
                '    'l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                'Else
                '    'l_str.Quantity_Confirm = l_quantity_conf(Convert.ToDecimal(l_lineid))
                '    If p_TONGDUXUATTHUY = "1" Then  'Lay theo du xuat
                '        l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                '    Else ' Lay theo thuc xuat
                '        l_str.Quantity_Confirm = l_quantity_conf(Convert.ToDecimal(l_lineid))
                '    End If
                'End If

                l_vanchuyen = mdlDelivery_CheckTransmot(l_str.Transmot, g_dt_para)
                If UCase(l_vanchuyen) = "BO" Or UCase(l_vanchuyen) = "SAT" Then
                    If p_TONGDUXUAT = "1" Then  'Lay theo du xuat
                        l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                    Else ' Lay theo thuc xuat
                        l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
                    End If
                    'l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                Else
                    'l_str.Quantity_Confirm = l_quantity_conf(Convert.ToDecimal(l_lineid))
                    If p_TONGDUXUATTHUY = "1" Then  'Lay theo du xuat
                        l_str.Quantity_Confirm = l_quantity(Convert.ToDecimal(l_lineid))
                    Else ' Lay theo thuc xuat
                        l_str.Quantity_Confirm = Math.Round(l_quantity_conf(Convert.ToDecimal(l_lineid)), 0)
                    End If
                End If



                l_str.Temp_Confirm = Math.Round(l_nhietdo(Convert.ToDecimal(l_lineid)) / l_quantity_conf(Convert.ToDecimal(l_lineid)), 2)
                l_str.Dens_Confirm = l_tytrong(Convert.ToDecimal(l_lineid)) / l_count(Convert.ToDecimal(l_lineid))

                '-----------------------------------------------------------------------------------------
                '   Đặt ngày giờ xuất hàng đưa lên SAP
                '-----------------------------------------------------------------------------------------
                Try
                    If i_dt_Header.Rows(0).Item("NgayXuat") <= i_dt_Details.Rows(0).Item("ThoiGianDau") Then
                        l_str.Date_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "yyyy-MM-dd")
                    End If
                    l_str.Time_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "HH:mm:ss")
                Catch ex As Exception
                    l_str.Date_Nd = Format(Now(), "yyyy-MM-dd")
                    l_str.Time_Nd = Format(Now(), "HH:mm:ss")
                End Try
                '-----------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------------------------
                '   Tính lại số lưu lượng kế
                '-----------------------------------------------------------------------------------------
                l_str.Meter_No = l_meter_n(l_lineid)
                l_str.Meter_Start = Convert.ToInt32(l_meter_s(l_lineid))
                l_str.Meter_End = Convert.ToInt32(l_meter_e(l_lineid))
                '-----------------------------------------------------------------------------------------

                o_ztb_Temp.Add(l_str)
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function



    Public Function mdlDelivery_CheckTransmot(ByVal i_mavanchuyen As String, ByVal i_dt_para As DataTable) As String
        Dim l_bo, _
            l_thuy, _
            l_sat As String()
        Dim p_ArrRow() As DataRow
        Try
            '----------------------------------------------------------------
            '   Para:
            '       Index 0: Bo
            '       Index 1: Thuy
            '----------------------------------------------------------------
            p_ArrRow = i_dt_para.Select("Para='Bo' or Para='BO'")
            If p_ArrRow.Length > 0 Then
                l_bo = p_ArrRow(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            End If
            p_ArrRow = i_dt_para.Select("Para='Thuy' or Para='THUY'")
            If p_ArrRow.Length > 0 Then
                l_thuy = p_ArrRow(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            End If

            'l_bo = i_dt_para.Rows(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            'l_thuy = i_dt_para.Rows(1).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)

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


    Public Function mdlSyncDeliveries_Shipment(ByVal i_dt_Header As DataTable, _
                                                ByVal i_dt_Material As DataTable, _
                                                ByVal i_dt_Details As DataTable, _
                                                ByRef o_ztb_Temp As Connect2SAP.Str_PhieuXuatTable) As Boolean
        Dim l_str As Connect2SAP.Str_PhieuXuat
        Dim l_lineid, _
            l_mangan, _
            l_loaiphieu _
            As String
        Dim l_vanchuyen As String

        Try

            For i As Integer = 0 To i_dt_Details.Rows.Count - 1
                l_str = New Connect2SAP.Str_PhieuXuat()
                '-----------------------------------------------------------------------------------------
                '   dữ liệu lấy từ i_dt_Header
                '-----------------------------------------------------------------------------------------
                l_str.Order_No = i_dt_Header.Rows(0).Item("Solenh").ToString()
                l_str.Outbound = i_dt_Header.Rows(0).Item("Solenh").ToString()
                l_str.Date_Nd = Format(i_dt_Header.Rows(0).Item("NgayXuat"), "yyyy-MM-dd")
                l_str.Plant = _WareHouse
                'l_str.Storage = _
                l_str.Batch_Nd = i_dt_Header.Rows(0).Item("MaNguon").ToString()
                l_str.Resource_Nd = i_dt_Header.Rows(0).Item("MaNguon").ToString()
                l_str.Method_Mt = i_dt_Header.Rows(0).Item("MaPhuongThucXuat").ToString()
                l_str.Method_Dc = i_dt_Header.Rows(0).Item("MaPhuongThucBan").ToString()
                l_str.Customer = i_dt_Header.Rows(0).Item("MaKhachHang").ToString()
                l_str.Shpoint = _ShPoint

                'anhqh
                '20161010
                l_str.Transmot = i_dt_Header.Rows(0).Item("MaVanChuyen").ToString()

                l_str.Shnumber = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()
                l_str.Veh_Mode = i_dt_Header.Rows(0).Item("MaVanChuyen").ToString()
                l_str.Vehicle = UCase(i_dt_Header.Rows(0).Item("MaPhuongTien").ToString())
                l_str.Drivercode = i_dt_Header.Rows(0).Item("NguoiVanChuyen").ToString()
                l_str.Niem_Text = i_dt_Header.Rows(0).Item("Niem").ToString()
                l_str.Luong_Text = i_dt_Header.Rows(0).Item("LuongGiamDinh").ToString()
                l_str.Nhietdo_Text = i_dt_Header.Rows(0).Item("NhietDoTaiTau").ToString()
                l_loaiphieu = i_dt_Header.Rows(0).Item("LoaiPhieu").ToString()
                '-----------------------------------------------------------------------------------------
                '-----------------------------------------------------------------------------------------
                '   System Test KV2
                '       Lấy lượng thực xuất = lượng dự xuất với đường bộ
                '-----------------------------------------------------------------------------------------
                l_vanchuyen = mdlDelivery_CheckTransmot(l_str.Veh_Mode, g_dt_para)
                '-----------------------------------------------------------------------------------------
                '-----------------------------------------------------------------------------------------
                'Dữ liệu được lấy từ Details
                '-----------------------------------------------------------------------------------------
                l_lineid = i_dt_Details.Rows(i).Item("LineID").ToString()
                l_mangan = i_dt_Details.Rows(i).Item("MaNgan").ToString()
                l_str.Lineid = l_lineid.Substring(3, 3)
                l_str.Compartment = l_mangan
                l_str.Item_Nd = l_lineid
                '-----------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------------------------
                '   Làm vòng lặp để kiểm tra lineid với i_dt_material
                '-----------------------------------------------------------------------------------------
                For j As Integer = 0 To i_dt_Material.Rows.Count - 1
                    If i_dt_Material.Rows(j).Item("LineID").ToString() = l_lineid Then
                        l_str.Material = i_dt_Material.Rows(j).Item("MaHangHoa").ToString()
                        l_str.Unit = i_dt_Material.Rows(j).Item("DonViTinh").ToString()
                        l_str.Salequantity = i_dt_Material.Rows(j).Item("TongDuXuat").ToString()
                        Exit For
                    End If
                Next
                '-----------------------------------------------------------------------------------------

                l_str.Quantity = i_dt_Details.Rows(i).Item("SoLuongDuXuat").ToString()
                'l_str.Quantity_Confirm = i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString()
                '-----------------------------------------------------------------------------------------
                '   System Test KV2
                '       Lấy lượng thực xuất = lượng dự xuất với đường bộ
                '-----------------------------------------------------------------------------------------
                'If UCase(l_vanchuyen) = "BO" Or UCase(l_vanchuyen) = "SAT" Then
                '    If p_TONGDUXUAT <> "1" Then
                '        l_str.Quantity = i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString()
                '    End If
                '    l_str.Quantity_Confirm = l_str.Quantity
                'Else
                '    'l_str.Quantity_Confirm = i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString()
                '    If p_TONGDUXUATTHUY <> "1" Then
                '        l_str.Quantity = i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString()
                '    End If
                '    l_str.Quantity_Confirm = l_str.Quantity
                'End If

                If UCase(l_vanchuyen) = "BO" Or UCase(l_vanchuyen) = "SAT" Then
                    If p_TONGDUXUAT <> "1" Then
                        If i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString.Trim <> "" Then
                            l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
                        Else
                            l_str.Quantity = 0
                        End If
                    End If
                    l_str.Quantity_Confirm = l_str.Quantity
                Else
                    'l_str.Quantity_Confirm = i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString()
                    If p_TONGDUXUATTHUY <> "1" Then
                        If i_dt_Details.Rows(i).Item("SoLuongThucXuat").ToString.Trim <> "" Then
                            l_str.Quantity = Math.Round(i_dt_Details.Rows(i).Item("SoLuongThucXuat"), 0)
                        Else
                            l_str.Quantity = 0
                        End If
                    End If
                    l_str.Quantity_Confirm = l_str.Quantity
                End If



                l_str.Temp_Confirm = i_dt_Details.Rows(i).Item("NhietDo").ToString()
                l_str.Dens_Confirm = i_dt_Details.Rows(i).Item("TyTrong_15").ToString()

                '-----------------------------------------------------------------------------------------
                '   Đặt ngày giờ xuất hàng đưa lên SAP
                '-----------------------------------------------------------------------------------------
                Try
                    If i_dt_Header.Rows(0).Item("NgayXuat") <= i_dt_Details.Rows(0).Item("ThoiGianDau") Then
                        l_str.Date_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "yyyy-MM-dd")
                    End If
                    l_str.Time_Nd = Format(i_dt_Details.Rows(0).Item("ThoiGianDau"), "HH:mm:ss")
                Catch ex As Exception
                    l_str.Date_Nd = Format(Now(), "yyyy-MM-dd")
                    l_str.Time_Nd = Format(Now(), "HH:mm:ss")
                End Try
                '-----------------------------------------------------------------------------------------

                Dim l_d_start, _
                    l_d_end _
                    As Decimal

                If i_dt_Details.Rows(i).Item("sl_llkebd").ToString.Trim <> "" Then
                    l_d_start = i_dt_Details.Rows(i).Item("sl_llkebd")
                Else
                    l_d_start = 0
                End If
                If i_dt_Details.Rows(i).Item("sl_llkekt").ToString.Trim <> "" Then
                    l_d_end = i_dt_Details.Rows(i).Item("sl_llkekt")
                Else
                    l_d_end = 0
                End If

                l_str.Meter_No = i_dt_Details.Rows(i).Item("MaLuuLuongKe").ToString()
                l_str.Meter_Start = Convert.ToInt32(l_d_start)
                l_str.Meter_End = Convert.ToInt32(l_d_end)
                l_str.Ngan_Text = l_str.Ngan_Text & "H" & i_dt_Details.Rows(i).Item("MaNgan").ToString() & ": " & i_dt_Details.Rows(i).Item("MaEntry").ToString() & "; "

                o_ztb_Temp.Add(l_str)
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

#End Region

#Region "Dong bo phuong tien len SAP"
    Public Function mdlSyncMaster_SyncVehicleUp(ByVal i_number As String, ByVal i_tutype As String, ByVal i_dt_compartment As DataTable) As Boolean Implements IService.clsSyncMaster_SyncVehicleUp
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_ChiTietPhuongTienTable
        Dim l_str As Connect2SAP.Str_ChiTietPhuongTien
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_SQL As String

        Try
            '----------------------------------------------------------------------------------------------
            '   Chuyển dữ liệu từ Datatable -> Str_ChiTietPhuongTienTable
            '----------------------------------------------------------------------------------------------
            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_ChiTietPhuongTienTable()

            l_c2sap.Connection.Open()

            For i As Integer = 0 To i_dt_compartment.Rows.Count - 1
                l_str = New Connect2SAP.Str_ChiTietPhuongTien()
                l_str.Mapt = i_number
                l_str.Mangan = mdlFunction_Convert2StringKey(i_dt_compartment.Rows(i).Item("MaNgan").ToString(), 3)
                l_str.Max_Nd = i_dt_compartment.Rows(i).Item("SoluongMax")

                l_ztb.Add(l_str)
            Next

            'Dim l_frm As frmTest = New frmTest(l_ztb)
            'l_frm.ShowDialog()
            'Exit Function
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện đưa lên SAP
            '----------------------------------------------------------------------------------------------

            'If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
            l_c2sap.CreateVehicle(i_number.ToUpper(), i_tutype, l_ztb, l_ret2)
            'Else
            '    l_async = l_c2sap.BeginCreateVehicle(i_number.ToUpper(), i_tutype, l_ztb, Nothing, l_c2sap)
            '    l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

            '    If l_isCompleted Then
            '        l_c2sap.EndCreateVehicle(l_async, l_ztb, l_ret2)
            '    End If
            'End If

            If l_ret2.Type = "E" Then
                Return False
            End If
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            p_SQL = "Update tblphuongtien set Status='S' where Maphuongtien='" & i_number & "'"
            If Sys_Execute(p_SQL, p_SQL) = False Then

            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function mdlFunction_Convert2StringKey(ByVal i_string As String, ByVal i_length As Integer) As String
        Dim l_string As String

        l_string = i_string

        If l_string.Length < i_length Then
            For i As Integer = 1 To i_length - l_string.Length
                l_string = "0" & l_string
            Next
        End If

        Return l_string

    End Function

#End Region



    Function CheckSAPConnection(ByVal p_SapConnectionString As String, ByRef p_Desc As String) As Boolean Implements IService.clsCheckSAPConnection
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim p_ExSapConnectionString As String
        Dim p_Data As DataTable
        Dim p_SQL As String
        Try
            CheckSAPConnection = True
            p_ExSapConnectionString = p_SapConnectionString
            If p_ExSapConnectionString = "" Then
                p_SQL = "select * from tblconfig"
                p_Data = GetDataTable(p_SQL, p_SQL)
                p_ExSapConnectionString = p_Data.Rows(0).Item("sapconnectionstring").ToString.Trim
            End If
            p_Desc = ""
            l_c2sap = New Connect2SAP.Connect2SAP(p_ExSapConnectionString)
            l_c2sap.Connection.Open()

            l_c2sap.Connection.Close()
            l_c2sap.Connection.Dispose()
        Catch ex As Exception
            p_Desc = ex.Message
            CheckSAPConnection = False
        End Try
    End Function



    Private Function SetComparment(ByVal p_TableHangHoa As DataTable, ByVal p_dt_vehicle As DataTable, ByVal i_lt_temp As Connect2SAP.Str_PhieuXuatTable, ByRef p_Table As System.Data.DataTable) As Boolean
        Dim p_Count As Integer
        Dim p_RowArr() As DataRow
        Dim p_Row As DataRow
        Dim p_CountHH As Integer
        Dim p_TableTmp As DataTable
        Dim l_wa As Connect2SAP.Str_PhieuXuat = New Connect2SAP.Str_PhieuXuat()
        Dim p_Count1 As Integer
        SetComparment = True

        p_TableTmp = p_Table.Clone


        Try
            For p_CountHH = 0 To p_TableHangHoa.Rows.Count - 1
                For p_Count = 0 To i_lt_temp.Count - 1
                    l_wa = i_lt_temp(p_Count)
                    If l_wa.Item_Nd.ToString.Trim = p_TableHangHoa.Rows(p_CountHH).Item("LineID").ToString.Trim Then
                        p_RowArr = p_dt_vehicle.Select("MaNgan='" & l_wa.Compartment.ToString.Trim & "' and  SoLuongMax=" & l_wa.Quantity)
                        If p_RowArr.Length > 0 Then
                            p_Row = p_TableTmp.NewRow
                            p_Row.Item("MaNgan") = l_wa.Compartment.ToString.Trim
                            p_Row.Item("SoLenh") = p_TableHangHoa.Rows(p_CountHH).Item("SoLenh").ToString.Trim
                            p_Row.Item("LineID") = p_TableHangHoa.Rows(p_CountHH).Item("LineID").ToString.Trim
                            p_Row.Item("TableID") = p_TableHangHoa.Rows(p_CountHH).Item("TableID").ToString.Trim
                            p_Row.Item("SoLuongDuXuat") = l_wa.Quantity
                            p_Row.Item("MaHangHoa") = p_TableHangHoa.Rows(p_CountHH).Item("MaHangHoa").ToString.Trim
                            p_Row.Item("MaLenh") = p_TableHangHoa.Rows(p_CountHH).Item("MaLenh").ToString.Trim
                            p_Row.Item("DungTichNgan") = p_RowArr(0).Item("SoLuongMax").ToString.Trim
                            p_TableTmp.Rows.Add(p_Row)
                        End If
                    End If

                Next
            Next

            If p_TableTmp.Rows.Count > 0 Then
                p_Table.Clear()
                p_Table.Merge(p_TableTmp)
            End If
        Catch ex As Exception
            SetComparment = False
        End Try
    End Function

    Public Function mdlQCI_CalculateQCIThuy(
                                         ByVal i_plant As String, _
                                         ByVal i_batch As String, _
                                         ByRef i_dgv_QCI As System.Data.DataTable,
                                         ByRef p_Desc As String) As Boolean Implements IService.clsQCI_CalculateQCIThuy
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_str As Connect2SAP.Str_PhieuXuat
        Dim l_ztb_addqty As Connect2SAP.Str_AddqtyTable
        Dim l_ret2 As Connect2SAP.BAPIRET2Table
        Dim p_SQL As String
        Dim p_DataRow As System.Data.DataRow
        Dim i_connectionstring As String = ""
        Dim p_TableConfig1 As DataTable


        p_SQL = "select * from tblConfig;"
        p_TableConfig1 = GetDataTable(p_SQL, p_SQL)



        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                i_connectionstring = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim

            End If

        End If

        l_c2sap = New Connect2SAP.Connect2SAP(i_connectionstring)
        l_str = New Connect2SAP.Str_PhieuXuat




        If i_connectionstring = "" Then
            p_Desc = "Lỗi kết nối SAP"
            Return False
            'mdlSyncDeliveries_SynSpecific = True
            'MsgBox("Loi ket noi")
            'Exit Function
        End If

        '  mdlQCI_CalculateQCI = True

        l_str.Plant = i_plant
        l_str.Batch_Nd = i_batch
        l_str.Resource_Nd = i_batch

        For i As Integer = 0 To i_dgv_QCI.Rows.Count - 1
            Try
                p_DataRow = i_dgv_QCI.Rows(i)

                l_str.Material = p_DataRow.Item("MaHangHoa").ToString.Trim
                For j As Integer = 1 To 18 - p_DataRow.Item("MaHangHoa").ToString().Trim.Length
                    l_str.Material = "0" & l_str.Material
                Next
                l_str.Quantity = p_DataRow.Item("SoLuong").ToString.Trim
                l_str.Unit = "L"   ' p_DataRow.Item("DVT").ToString()
                l_str.Temp_Confirm = p_DataRow.Item("Nhietdo").ToString()
                l_str.Dens_Confirm = p_DataRow.Item("TyTrong").ToString()

                l_ret2 = New Connect2SAP.BAPIRET2Table()
                l_ztb_addqty = New Connect2SAP.Str_AddqtyTable()

                l_c2sap.Fm_Qci(l_str, l_ztb_addqty, l_ret2)
                'If l_ret2.Count <> 0 Then
                '    i_dgv_QCI.Rows(i).DefaultCellStyle.BackColor = Color.Red
                '    Continue For
                'End If

                For j As Integer = 0 To l_ztb_addqty.Count - 1

                    Select Case l_ztb_addqty.Item(j).Msehi.Trim()
                        Case "L"
                            i_dgv_QCI.Rows(i).Item("Ltt") = Convert.ToInt32(l_ztb_addqty.Item(j).Adqnt)

                        Case "L15"
                            i_dgv_QCI.Rows(i).Item("L15") = Convert.ToInt32(l_ztb_addqty.Item(j).Adqnt)

                        Case "M15"
                            i_dgv_QCI.Rows(i).Item("M15") = Convert.ToInt32(l_ztb_addqty.Item(j).Adqnt)

                        Case "KG"
                            i_dgv_QCI.Rows(i).Item("KG") = Convert.ToInt32(l_ztb_addqty.Item(j).Adqnt)

                        Case Else

                    End Select

                Next

                ' i_dgv_QCI.Rows(i).DefaultCellStyle.BackColor = Color.White

            Catch ex As Exception
                p_Desc = ex.Message
                Return False
            End Try
        Next

        Return True
    End Function


    Public Function mdlTestConnectSAP(ByVal p_Connect As Boolean, ByVal p_ASHOST As String, ByVal p_SYSNR As String, ByVal p_Client As String, _
                                    ByVal p_User As String, ByVal p_Pass As String, ByRef p_Desc As String) As Boolean Implements IService.clsTestConnectSAP
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim i_SapConnectionstring As String
        Dim p_SQL As String
        i_SapConnectionstring = "ASHOST=" & p_ASHOST & ";SYSNR=" & p_SYSNR & _
                            ";CLIENT=" & p_Client & ";USER=" & p_User & ";PASSWD=" & p_Pass

        If p_Connect = True Then
            l_c2sap = New Connect2SapEx.Connect2Sap(i_SapConnectionstring)  '(_SAPConnectionString_bxtd)
            '-----------------------------------------------------------------
            'Kiểm tra kết nối với SAP xem có lấy đc dữ liệu ko
            '-----------------------------------------------------------------
            Try
                l_c2sap.Connection.Open()
                l_c2sap.Connection.Close()
            Catch ex As Exception
                p_Desc = ex.Message
                l_c2sap.Dispose()
                Return False
            End Try
        Else
            p_SQL = "update tblConfig set sapconnectionstring='" & i_SapConnectionstring & "'"
            If Sys_Execute(p_SQL, _
                                          p_Desc) = False Then
                Return False
            End If
        End If

        Return True
    End Function


    Public Function mdlSyncDeliveries_DoList(ByVal i_SapConnectionstring As String, ByVal i_date As String, _
                                             ByVal _ShPoint As String, ByVal i_TimeOut As String, ByRef o_table As DataTable, _
                                             ByRef o_err As String) As Boolean Implements IService.clsSyncDeliveries_DoList
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.Str_PhieuXuatTable
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_lasttime As Connect2SapEx.ZTB_INT_TIME '  Str_Time
        Dim l_now As Connect2SapEx.ZTB_INT_TIME   '   .Str_Time
        Dim l_err As String
        Dim l_f As Boolean = False
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        Dim p_Error As String
        Dim p_Count As Integer

        l_ret2 = New Connect2SapEx.BAPIRET2()
        l_c2sap = New Connect2SapEx.Connect2Sap(i_SapConnectionstring)  '(_SAPConnectionString_bxtd)
        l_ztb = New Connect2SapEx.Str_PhieuXuatTable()
        l_err = String.Empty
        '-----------------------------------------------------------------
        'Kiểm tra kết nối với SAP xem có lấy đc dữ liệu ko
        '-----------------------------------------------------------------
        Try
            l_c2sap.Connection.Open()
        Catch ex As Exception
            l_c2sap.Dispose()
            o_err = "m038"
            Return False
        End Try
        '-----------------------------------------------------------------
        '   Nếu dữ liệu lấy ra mà không có => Không hợp lệ
        '   Nếu dữ liệu lấy ra mà khác Shipping Point => Không hợp lệ
        '-----------------------------------------------------------------
        Try
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_lasttime = New Connect2SapEx.ZTB_INT_TIME
            l_now = New Connect2SapEx.ZTB_INT_TIME
            l_lasttime.Lastdate = i_date
            l_lasttime.Lasttime = "00:00:00"
            l_now.Lastdate = i_date
            l_now.Lasttime = "23:59:59"
            If i_TimeOut = "25" Then
                l_c2sap.GetDoList(l_lasttime, l_now, _ShPoint, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetDoList(l_lasttime, l_now, _ShPoint, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(i_TimeOut, False)
                If l_isCompleted Then
                    l_c2sap.EndGetDoList(l_async, l_ztb, l_ret2)
                End If
            End If
            If l_ztb.Count > 0 Then
                o_table = l_ztb.ToADODataTable()

                For p_Count = o_table.Rows.Count - 1 To 0 Step -1
                    If Check_SoLenh(p_Error, o_table.Rows(p_Count).Item("Order_No").ToString.Trim) = True Then
                        o_table.Rows.RemoveAt(p_Count)
                    End If
                Next
                Return True
            Else
                o_err = "Không có lệnh xuất"
                Return False
            End If
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()
            Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try
    End Function




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
                p_InsertTable = "INSERT INTO " & p_TableName & " "
                p_ValueTable = " VALUES "
            Else
                p_TableName = Replace(g_PathFileFoxThuy, ".dbf", "", 1)
                p_TableName = Replace(p_TableName, UCase(".dbf"), "", 1)
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
        p_DataHTTG = GetDataTable(p_SQL, p_SQL)
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

                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "MALUULUONGKE" Then
                            If p_Value = "" Then
                                p_Value = "0"
                            End If
                        End If
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
                        End If
                        '
                        If UCase(p_DataRowMap_cp(p_CountRow).Item("FromField").trim) = "TABLEID" And p_DataRowMap_cp(p_CountRow).Item("SWhere").ToString.Trim = "Y" Then
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

                                p_DataTableCheckID = GetDataTable(p_SQL, p_SQL)
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

                                    p_DataTableCheckID = GetDataTable(p_SQL, p_SQL)
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
                        'Tinh lai Ma lenh cua tu dong hoa

                        'Kiem tra trong Scadar co chua, neu co roi thi khong insert nua

                        Select Case UCase(p_FieldType)
                            Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                                p_SQLValue = p_SQLValue & "," & CDec(IIf(p_Value.ToString.Trim = "", 0, p_Value))
                            Case UCase("DateTime"), UCase("Date")
                                If UCase(g_TypeConnet) = "SQL" Then
                                    p_SQLValue = p_SQLValue & ",'" & CDate(p_Value).ToString("yyyyMMdd") & "'"
                                End If
                                If UCase(g_TypeConnet) = "FOX" Then
                                    p_SQLValue = p_SQLValue & ",{d '" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                                End If
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
                        If UCase(g_TypeConnet) = "FOX" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_StrConnectFox, p_SQL, p_SQL)
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

                        End If
                        If UCase(g_TypeConnet) = "SQL" Then
                            p_DataTableCheckID = p_SYS_GET_DATATABLE_With_Connect_Des(g_ConnectToScadar, p_SQL, p_SQL)
                            If Not p_DataTableCheckID Is Nothing Then
                                If p_DataTableCheckID.Rows.Count <= 0 Then
                                    p_Error = True
                                    Exit Sub
                                End If
                            Else
                                p_Error = True
                                Exit Sub
                            End If

                        End If

                    End If

                End If


            Next


        End If
    End Sub

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

    Public Function mdlSyncMaster_SyncVehicleDown1(ByVal _SapConnectionString As String, _
                                                ByVal _dtVariable As System.Data.DataTable, _
                                                ByVal _ShPoint As String, _
                                                    ByVal _WareHouse As String, _
                                                    ByVal _TimeOut As System.TimeSpan, _
                                                    ByVal i_vehicle As String, ByRef p_Count As Integer, ByRef p_Desc As String) As Boolean Implements IService.ClsSyncMaster_SyncVehicleDownNew
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_ChiTietPhuongTienTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String

        Dim p_Row As DataRow
        Dim p_DataTablExe As New System.Data.DataTable("Table0")

        Dim l_err As String = String.Empty
        Dim l_dem As Integer

        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------
            p_DataTablExe.Columns.Add("STR_SQL")
            l_c2sap = New Connect2SAP.Connect2SAP(_SapConnectionString)
            l_ztb = New Connect2SAP.Str_ChiTietPhuongTienTable()
            l_ret2 = New Connect2SAP.BAPIRET2()

            l_c2sap.Connection.Open()

            If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetChiTietPhuongTien(String.Empty, String.Empty, i_vehicle.ToUpper(), l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetChiTietPhuongTien(i_vehicle.ToUpper(), String.Empty, String.Empty, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetChiTietPhuongTien(l_async, l_ztb, l_ret2)
                End If
            End If

            p_Count = 0
            '----------------------------------------------------------------------------------------------
            '   Đưa dữ liệu vào hệ thống SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            l_dem = l_ztb.Count
            p_Count = l_ztb.Count
            If l_ztb.Count > 0 Then
                'l_bs_details = New BSVehicleDetail()

                ' For i As Integer = 0 To l_ztb.Count - 1
                p_SQL = "MERGE tblPhuongtien AS target " & _
                    " USING (SELECT N'" & Replace(l_ztb.Item(0).Mapt.ToString(), "'", "", 1) & "' as MaPhuongTien ," & _
                             "N'" & Replace(l_ztb.Item(0).Loaipt.ToString(), "'", "", 1) & "'  as LaiXe," & _
                             "" & Convert.ToInt32(l_dem) & "  as SoNgan ," & _
                             "'" & Replace(l_ztb.Item(0).Ngaybatdau.ToString(), "'", "", 1) & "'  as Ngaybatdau, " & _
                             "'" & Replace(l_ztb.Item(0).Ngayketthuc.ToString(), "'", "", 1) & "'  as NgayHieuLuc, " & _
                            "'S' as Status) AS source (MaPhuongTien, LaiXe, SoNgan, Ngaybatdau, NgayHieuLuc, Status) " & _
                            " ON (target.MaPhuongTien = source.MaPhuongTien) " & _
                        " WHEN MATCHED  THEN UPDATE SET " & _
                                "LaiXe=source.LaiXe " & _
                                ",SoNgan=source.SoNgan " & _
                                ",Ngaybatdau=source.Ngaybatdau " & _
                                ",NgayHieuLuc=source.NgayHieuLuc " & _
                                ",Status=source.Status " & _
                     " WHEN NOT MATCHED THEN " & _
                        "INSERT  (MaPhuongTien, LaiXe, SoNgan, Ngaybatdau, NgayHieuLuc, Status) " & _
                            "VALUES (source.MaPhuongTien,source.LaiXe,source.SoNgan,source.NgayHieuLuc,source.NgayHieuLuc,source.Status ) ;"
                'p_SQL = Replace(p_SQL, "''", "'", 1)
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)


                p_SQL = "DELETE FROM tblChiTietPhuongtien where MaPhuongTien='" & Replace(l_ztb.Item(0).Mapt.ToString(), "'", "", 1) & "'"
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)
                'l_dem = l_dem + 1

                For i As Integer = 0 To l_ztb.Count - 1
                    ' l_bs = New BSVehicleDetail()
                    l_err = String.Empty
                    ' l_mahh = String.Empty
                    p_SQL = "MERGE tblChiTietPhuongtien AS target " & _
                                           " USING (SELECT '" & Replace(l_ztb.Item(i).Mangan.ToString(), "'", "", 1) & "' as MaNgan," & _
                                                    "'" & Replace(l_ztb.Item(i).Mapt.ToString(), "'", "", 1) & "' as MaPhuongTien," & _
                                                    "" & Convert.ToDecimal(l_ztb.Item(i).Max_Nd.ToString()) & " as SoLuongMax," & _
                                                   "'S' as Status) AS source (MaNgan, MaPhuongTien, SoLuongMax, Status) " & _
                                                   " ON (target.MaPhuongTien = source.MaPhuongTien and target.MaNgan = source.MaNgan) " & _
                                               " WHEN MATCHED  THEN UPDATE SET " & _
                                                       "SoLuongMax=source.SoLuongMax " & _
                                                       ",Status=source.Status " & _
                                            " WHEN NOT MATCHED THEN " & _
                                               "INSERT  (MaNgan, MaPhuongTien, SoLuongMax, Status) " & _
                                                   "VALUES (source.MaNgan,source.MaPhuongTien,source.SoLuongMax,source.Status );"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next

                ' Next

                If p_DataTablExe.Rows.Count > 0 Then
                    If Sys_Execute_DataTableNew(p_DataTablExe, _
                                          p_SQL) = False Then
                        p_Desc = p_SQL
                        Return False
                    End If
                End If
            End If

            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True
        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try
    End Function



    'anhqh
    '20160803
    'Ham xu lus delete ngăn và update phuong tiên
    Private Sub mdlSyncMaster_SyncVehicleDetails_Upd(ByVal l_ztb As Connect2SAP.Str_ChiTietPhuongTienTable, _
                                                            ByRef p_DataTablExe As DataTable)
        Dim p_Count As Integer
        Dim p_RowArr() As DataRow
        Dim p_Row As DataRow
        Dim p_Table As New System.Data.DataTable("Table001")
        Dim p_MaPhuongTien As String
        p_Table.Columns.Add("SQL_STR")
        p_Table.Columns.Add("SoNgan", Type.GetType("System.Int32"))
        Try
            For p_Count = 0 To l_ztb.Count - 1
                p_MaPhuongTien = l_ztb(p_Count).Mapt.ToString.Trim
                p_RowArr = p_Table.Select("SQL_STR='" & p_MaPhuongTien & "'")
                If p_RowArr.Length <= 0 Then
                    p_Row = p_Table.NewRow
                    p_Row(0) = p_MaPhuongTien ' "DELETE FROM tblChiTietPhuongTien where MaPhuongTien='" & p_MaPhuongTien & "'"
                    p_Row(1) = 1
                    p_Table.Rows.Add(p_Row)
                Else

                    p_RowArr(0).Item(1) = p_RowArr(0).Item(1) + 1
                    'p_Row = p_Table.NewRow
                    'p_Row(0) = p_MaPhuongTien ' "DELETE FROM tblChiTietPhuongTien where MaPhuongTien='" & p_MaPhuongTien & "'"
                    'p_Row(1) = p_RowArr.Length + 1
                    'p_Table.Rows.Add(p_Row)
                End If
            Next

            For p_Count = 0 To p_Table.Rows.Count - 1
                p_Row = p_DataTablExe.NewRow
                p_Row(0) = "DELETE FROM tblChiTietPhuongTien where MaPhuongTien='" & p_Table.Rows(p_Count).Item(0).ToString.Trim & "'"
                p_DataTablExe.Rows.Add(p_Row)

                p_Row = p_DataTablExe.NewRow
                p_Row(0) = "UPDATE tblPhuongTien set SoNgan= " & p_Table.Rows(p_Count).Item(1).ToString.Trim & " where MaPhuongTien='" & p_Table.Rows(p_Count).Item(0).ToString.Trim & "'"
                p_DataTablExe.Rows.Add(p_Row)


            Next

        Catch ex As Exception

        End Try


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


    Private Sub GetMaVanChuyen(ByVal p_maphuongtien As String, ByVal p_MaVanChuyen As String, ByRef l_mavanchuyen As String)
        Dim p_SQL As String = "select * from tblPara"
        Dim l_mavanchuyen_convert As String
        Dim i_dt_para As DataTable
        i_dt_para = GetDataTable(p_SQL, p_SQL)

        l_mavanchuyen = p_MaVanChuyen
        l_mavanchuyen_convert = mdlDelivery_CheckTransmot(l_mavanchuyen, i_dt_para)
        If l_mavanchuyen_convert = "Thuy" Then
            If mdlFunction_GetParaValue(Constant_P_eThuy, i_dt_para) = "0" Then
                l_mavanchuyen = p_maphuongtien
            Else
                l_mavanchuyen = mdlFunction_GetParaValue(Constant_P_eThuy, i_dt_para)
            End If
        ElseIf l_mavanchuyen_convert = "Bo" Then
            If mdlFunction_GetParaValue(Constant_P_eBo, i_dt_para) = "0" Then
                l_mavanchuyen = p_maphuongtien
            Else
                l_mavanchuyen = mdlFunction_GetParaValue(Constant_P_eBo, i_dt_para)
            End If
        ElseIf l_mavanchuyen_convert = "Sat" Then
            If mdlFunction_GetParaValue(Constant_P_eSat, i_dt_para) = "0" Then
                l_mavanchuyen = p_maphuongtien
            Else
                l_mavanchuyen = mdlFunction_GetParaValue(Constant_P_eSat, i_dt_para)
            End If
        End If


    End Sub

    Private Function mdlFunction_GetParaValue(ByVal i_paraname As String, ByVal i_dt_para As DataTable) As String
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



    '20160920
    'anhqh
    'Them rieng cho KV1
    Public Function kv1clsSyncDeliveries_SynSpecific(ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_Company_Code As String, ByVal p_SoLenh As String, _
                                                        ByRef p_Desc As String, ByVal p_CrDate As Date) As Boolean Implements IService.kv1clsSyncDeliveries_SynSpecific
        'Select Case p_Company_Code
        '    Case "6610"  'KV2
        '        Dim p_SAP_KV2 As New K4810.Class1(g_Config_XMLDatatable, _
        '                                                  g_Company_Code, _
        '                                                  g_WareHouse, g_Services, "", "", "", g_Company_Host, _
        '                                                  g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
        '                                                  g_DBPass, g_CompanyAPI)
        '        mdlSyncDeliveries_SynSpecificNew = p_SAP_KV2.ClsSyncDeliveries_SynSpecific(p_SoLenh, p_Desc)
        '        Exit Function
        'End Select
        kv1clsSyncDeliveries_SynSpecific = KV1mdlSyncDeliveries_SynSpecific(p_Client, p_User_ID, p_Company_Code, p_SoLenh, p_Desc, p_CrDate)
    End Function


    Private Function KV1mdlSyncDeliveries_SynSpecific(ByVal p_Client As String, ByVal p_User_ID As Integer, _
                                                    ByVal p_Company_Code As String, ByVal i_solenh As String, ByRef o_err As String, _
                                                    ByVal p_crdDate As Date) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP

        ' Dim l_c2sap111 As Connect2SAP.


        'Dim l_c2sapex As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SAP.Str_PhieuXuatTable
        ' Dim l_ztb As Connect2SapEx.LIPSO2Table
        Dim l_ret2 As Connect2SAP.BAPIRET2
        ' Dim l_ret2ex As Connect2SapEx.BAPIRET2
        Dim l_err As String
        Dim l_f As Boolean = False

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String
        Dim p_TableConfig As DataTable
        Dim p_TableConfig1 As DataTable
        Dim p_SapConnectionString As String = ""
        Dim p_TimeOut = New TimeSpan()
        Dim p_WareHouse As String = ""
        Dim p_ShPoint As String = ""
        Dim p_DataRowArr() As DataRow

        Dim p_DataSet As New DataSet
        Dim p_Batch As String
        Dim p_Slog As String
        Dim p_MaKhachHang As String
        Dim p_StringTmp As String = "0000000000"
        Dim p_SoLenh As String
        Dim p_Table As DataTable
        Dim p_DiemTraHang As String

        Dim p_Count As Integer

        g_Company_Code = p_Company_Code

        KV1mdlSyncDeliveries_SynSpecific = False
        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG; select * from tblConfig;"
        p_DataSet = p_SYS_GET_DATASET_Des(p_SQL, p_SQL)

        g_KV1 = False

        g_User_ID = p_User_ID


        g_BATCHSLOG = False

        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_TableConfig = p_DataSet.Tables(0)
                p_TableConfig1 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_DataRowArr = p_TableConfig.Select("KEYCODE='TABLEID'")
                If p_DataRowArr.Length > 0 Then
                    p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='QUYDOI_SAP'")
                If p_DataRowArr.Length > 0 Then
                    p_QUYDOI_SAP = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KV1'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_KV1 = True
                    Else
                        g_KV1 = False
                    End If
                End If


                p_DataRowArr = p_TableConfig.Select("KEYCODE='BATCHSLOG'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_BATCHSLOG = True
                    Else
                        g_BATCHSLOG = False
                    End If
                End If



            End If
        End If



        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                p_SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If
        If p_SapConnectionString = "" Then
            KV1mdlSyncDeliveries_SynSpecific = True
            MsgBox("Loi ket noi")
            Exit Function
        End If


        Try
            l_c2sap = New Connect2SAP.Connect2SAP(p_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_PhieuXuatTable()
            ' l_ztb As Connect2SapEx.LIPSO2Table
            l_err = String.Empty



            If p_TableConfig1.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
                l_c2sap.GetPhieuXuat_Specific(i_solenh, l_ztb, l_ret2)

            Else
                l_async = l_c2sap.BeginGetPhieuXuat_Specific(i_solenh, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetPhieuXuat_Specific(l_async, l_ztb, l_ret2)
                End If
            End If



            If l_ztb.Count > 0 Then

                'anhqh
                '20161020
                'Kiem tra lenh di chuyen khong TD
                p_SQL = "exec FPT_KiemTraDiChuyenKhongGanTD '" & l_ztb(0).Batch_Nd.ToString.Trim & "','" & _
                                    l_ztb(0).Shnumber.ToString.Trim & "','" & _
                                    l_ztb(0).Saleorder.ToString.Trim & "'"
                p_Table = GetDataTable(p_SQL, p_SQL)

                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        If p_Table.Rows(0).Item(0).ToString.Trim = "1" Then
                            o_err = "Lệnh xuất chưa được gán TD!"
                            Return False
                        End If
                    End If
                End If

                'If g_KV1 = True Then
                For p_Count = 0 To l_ztb.Count - 1
                    l_ztb(p_Count).Date_Nd = p_crdDate.ToString("yyyyMMdd")
                Next
                'End If
                '------------------------------------------------------------------------------
                '   Kiểm tra thời hạn hiệu lực của hóa đơn
                '------------------------------------------------------------------------------
                'FES44
                '20141113
                If g_KV1 = False Then
                    If Not mdlSyncDeliveries_CheckStartTime(l_ztb.Item(0).Date_Nd) Then
                        o_err = "Lệnh xuất chưa được phép xuất hàng!"
                        Return False
                    End If
                End If


                If Not mdlSyncDeliveries_CheckEndTime(l_ztb.Item(0).Date_E_Nd) Then
                    o_err = "Lệnh xuất đã hết hạn!"
                    Return False
                End If

                If l_ztb.Item(0).Plant <> p_WareHouse Then
                    o_err = "Kiểm tra thông tin Kho xuất hàng ghi trên lệnh xuất!"
                    Return False
                End If
                p_DiemTraHang = GetDiemTraHang(l_ztb(0).Shnumber.ToString.Trim, p_SapConnectionString,
                                       p_TableConfig1, p_TimeOut)


                If g_BATCHSLOG = True Then

                    'If l_ztb.Item(0).Resource_Nd = "N40" Or l_ztb.Item(0).Resource_Nd = "N45" Then
                    p_Batch = l_ztb.Item(0).Batch_Nd
                    p_Slog = l_ztb.Item(0).Storage
                    p_SoLenh = l_ztb.Item(0).Order_No

                    p_MaKhachHang = Mid(p_Batch, 4)
                    p_MaKhachHang = Left(p_StringTmp, 10 - (Len(p_MaKhachHang))) & p_MaKhachHang

                    p_SQL = "exec FPT_CheckBatch '" & l_ztb.Item(0).Order_No.ToString & "','" & l_ztb.Item(0).Resource_Nd.ToString & _
                        "','" & p_Slog & "','" & l_ztb.Item(0).Customer.ToString & "','" & p_MaKhachHang & "'"
                    p_Table = GetDataTable(p_SQL, p_SQL)
                    If Not p_Table Is Nothing Then
                        If p_Table.Rows.Count > 0 Then
                            o_err = p_Table.Rows(0).Item("Desc_Err").ToString.Trim
                            Return False
                        End If
                    End If

                    ' If

                End If


                If l_ztb.Item(0).Shpoint = p_ShPoint Then
                    If l_ztb.Item(0).Storage <> String.Empty Then
                        If l_ztb.Item(0).Batch_Nd <> String.Empty Then

                            If mdlSyncDeliveries_SubModifyFromTable_new(p_Client, p_SapConnectionString, l_ztb, o_err, p_DiemTraHang) = False Then
                                l_c2sap.Connection.Close()
                                l_c2sap.Dispose()
                                Return False
                            End If

                            'hieptd4 add 20161102 
                            KV1mdlSyncDeliveries_SynSpecific = mdlSyncDeliveries_SynSpecific_Ex(p_Client, p_User_ID, _
                                                                          p_Company_Code, i_solenh, o_err)


                            o_err = "Đồng bộ dữ liệu thành công!"
                            Return True
                        Else
                            o_err = "Lệnh xuất chưa được phép xuất hàng!"
                        End If
                    Else
                        o_err = "Chưa có Storage Location nên không thể đồng bộ lệnh xuất này!"
                    End If
                Else
                    o_err = "Lệnh xuất khác Shipping Point nên không thể xuất hàng!"
                End If
            Else
                o_err = "Lệnh xuất không hợp lệ để thực hiện xuất hàng!"
            End If
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            'Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try


    End Function


    Private Function KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(ByVal p_Client As String, ByVal l_ztb2 As Connect2SapEx.LIPSO2Table, _
                                                           ByRef p_DataExec As DataTable, _
                                                           ByVal i_wa As Connect2SAP.Str_PhieuXuat, _
                                                           ByVal i_malenh As String, _
                                                           ByVal i_ngayxuat As String, _
                                                           ByVal i_solenh As String, _
                                                           ByVal i_tongxuat As Decimal, _
                                                           ByVal i_tongduxuat As Decimal, _
                                                           ByVal i_loaiphieu As String, _
                                                           ByVal i_tableid As String, _
                                                           ByRef p_TableHangHoa As System.Data.DataTable) As Boolean
        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat_HangHoa
        '   Key:
        '       MaLenh
        '       NgayXuat
        '       SoLenh      - phục vụ tìm kiếm nhanh
        '-----------------------------------------------------------------
        Dim l_mahanghoa, _
            l_donvitinh _
            As String

        '-----------------------------------------------------------------
        'Các biến Tính QCI
        '   l_out:      
        '   l_quantity: Tính lượng QCI trả ra
        '-----------------------------------------------------------------
        'Dim l_out As String()
        Dim l_quantity As Decimal() = New Decimal() {0, 0, 0, 0}

        Dim l_quantity2 As Decimal() = New Decimal() {0, 0, 0, 0}

        Dim p_NhietDoTemp As Double = 30
        Dim p_TyTrongBe As Double = 0.688

        Dim l_err As String
        Dim p_SQL As String
        'Dim p_DataTable As New DataTable("Table002")
        Dim p_DataTableCheck As DataTable
        Dim p_DataRow As DataRow
        Dim p_TBLTABLEID_ZT As Boolean = False
        Dim p_TableID As String
        Dim p_BeXuat As String

        Dim p_CountQCI As Integer
        Dim p_TongXuat As Decimal

        Dim p_TaiTrongKg As Decimal


        Dim p_LoaiVanChuyen As String = ""

        Dim p_RowHangHoa As System.Data.DataRow

        Dim p_Tank As String

        Dim p_Sum As Double
        Dim p_Count As Integer
        Dim p_CrdDate As Date

        '   For  p_Count = 0 To 

        KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI = True





        p_SQL = "select Name from sys.all_objects where upper(Name)='TBLTABLEID_ZT'"
        p_DataTableCheck = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTableCheck Is Nothing Then
            If p_DataTableCheck.Rows.Count > 0 Then
                p_TBLTABLEID_ZT = True
            End If
        End If

        l_donvitinh = i_wa.Unit.ToString()

        i_tongxuat = 0
        i_tongduxuat = Convert.ToDecimal(i_wa.Salequantity.ToString())

        '-----------------------------------------------------------------
        'Tính QCI
        '-----------------------------------------------------------------

        Try


            If i_wa.Material.Length > 7 Then
                l_mahanghoa = i_wa.Material.Substring(i_wa.Material.Length - 7, 7)
            Else
                l_mahanghoa = i_wa.Material.Substring(0, i_wa.Material.Length)
            End If

            l_err = String.Empty
            l_quantity(0) = 0
            l_quantity(1) = 0
            l_quantity(2) = 0
            l_quantity(3) = 0


            If p_QUYDOI_SAP = "Y" Then
                For p_CountQCI = 0 To l_ztb2.Count - 1
                    'p_QUYDOI_SAP

                    If l_ztb2(p_CountQCI).Posnr.ToString.Trim = i_wa.Item_Nd.ToString.Trim Then

                        Select Case UCase(l_ztb2(p_CountQCI).Msehi.ToString.Trim)
                            Case "L"
                                l_quantity(0) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(0), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                ' p_TongXuat = l_quantity(0)
                            Case "L15"
                                l_quantity(1) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(1), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                '  p_TongXuat = l_quantity(1)
                            Case "KG"
                                l_quantity(3) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(3), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                'p_TongXuat = l_quantity(2)
                            Case Else
                                l_quantity(2) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(2), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                '  p_TongXuat = l_quantity(3)
                        End Select
                    End If
                Next

                'p_TongXuat = l_quantity(1)
                Select Case l_donvitinh
                    Case "L"
                        p_TongXuat = i_tongduxuat 'l_quantity(0)
                    Case "L15"
                        p_TongXuat = l_quantity(0)
                    Case "KG"
                        p_TongXuat = l_quantity(0)
                    Case Else
                        p_TongXuat = l_quantity(0)

                End Select

            Else
                l_quantity = mdlQCI_CalculateQCI(i_tongduxuat, i_wa.Unit, 15, 0.688)
                p_TongXuat = i_tongduxuat
            End If


            'Select Case l_donvitinh
            '    Case "L"
            '        p_TongXuat = l_quantity(0)
            '    Case "L15"
            '        p_TongXuat = l_quantity(1)
            '    Case "KG"
            '        p_TongXuat = l_quantity(3)
            '    Case Else
            '        p_TongXuat = l_quantity(2)

            'End Select

            If InsertQci(l_err, i_malenh, i_ngayxuat, i_wa.Item_Nd.ToString(), i_solenh, i_wa.Compartment.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3)) Then
                UpdateQci(l_err, i_solenh, i_wa.Compartment.ToString(), i_wa.Item_Nd.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3))
            End If
            p_BeXuat = ""
            p_Tank = ""

            'anhqh
            '20160628
            p_LoaiVanChuyen = UCase(GetLoadingSite(i_wa.Transmot))

            'anhqh  20160530
            If CheckHangHoaE5(l_mahanghoa) = True Then
                p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat), p_Client, p_LoaiVanChuyen)
                p_Tank = GetTankActiveE5(p_BeXuat, CDate(i_ngayxuat))
            Else
                p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat), p_Client, p_LoaiVanChuyen)
                p_Tank = p_BeXuat
            End If

            '-----------------------------------------------------------------

            'anhqh   20160623
            'Ghep dac thu rieng cua KV1
            ' If g_Company_Code = "2110" Then

            ' p_TableID = GetTableIDKV1()
            ' End If
            'p_TableID = GetTableID()

            If g_KV1 = True Then
                p_CrdDate = CDate(i_ngayxuat)
                p_TableID = GetTableIDKV1(i_wa.Transmot.ToString(), p_CrdDate, l_mahanghoa)
            Else
                p_TableID = GetTableID()
            End If


            'Tinh so KG tai trong  =========================================================================
            p_SQL = "select ISNULL((select NhietDo from tblNhietDo with (Nolock) where  " & _
                "CONVERT(date,crDate)=(select MAX(crDate) from tblNhietDo with (Nolock) )),30) as NhietDo," & _
                 "ISNULL((select top 1 Dens_nd from FPT_tblTankActive_V where Date1 =CONVERT(date,getdate()) " & _
                 "and Name_nd ='" & p_Tank & "'),0.688) as TyTrong"
            p_DataTableCheck = GetDataTable(p_SQL, p_SQL)


            l_quantity2(0) = 0
            l_quantity2(1) = 0
            l_quantity2(2) = 0
            l_quantity2(3) = 0

            If Not p_DataTableCheck Is Nothing Then
                If p_DataTableCheck.Rows.Count > 0 Then
                    p_NhietDoTemp = p_DataTableCheck.Rows(0).Item("NhietDo")
                    p_TyTrongBe = p_DataTableCheck.Rows(0).Item("TyTrong")

                End If
            End If




            If p_BeXuat.ToString.Trim <> "" And p_LoaiVanChuyen = "BO" Then
                ' mdlQCI_CalculateQCI_NS("", p_SoLuong, "L", p_NhietDoN, IIf(p_DataRow(0).Item("TyTrong").ToString.Trim = "", 0.688, p_DataRow(0).Item("TyTrong").ToString.Trim))
                l_quantity2 = mdlQCI_CalculateQCI("", p_TongXuat, "L", p_NhietDoTemp, p_TyTrongBe)
            End If


            p_TaiTrongKg = 0 ' l_quantity2(3)
            'Tinh so KG tai trong  =========================================================================


            'p_SQL = "INSERT INTO [tblLenhXuat_HangHoaE5] (LineID, MaLenh,NgayXuat, SoLenh,TongXuat, " & _
            '    "TongDuXuat, MaHangHoa, DonViTinh,BeXuat,TableID ,Createby,CreateDate, QCI_KG, QCI_NhietDo, QCI_TyTrong) "
            'p_SQL = p_SQL & " VALUES ('" & i_wa.Item_Nd.ToString() & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & i_solenh & "'" & _
            '        "," & p_TongXuat & "," & i_tongduxuat & ",'" & l_mahanghoa & "','" & l_donvitinh & "','" & p_BeXuat & "','" & p_TableID & "'," & g_User_ID & ",getdate()" & _
            '        "," & p_TaiTrongKg & "," & p_NhietDoTemp & "," & p_TyTrongBe & ")"

            'p_DataRow = p_DataExec.NewRow
            'p_DataRow.Item(0) = p_SQL
            'p_DataExec.Rows.Add(p_DataRow)

            p_RowHangHoa = p_TableHangHoa.NewRow
            p_RowHangHoa.Item("TableID") = p_TableID
            p_RowHangHoa.Item("MaHangHoa") = l_mahanghoa
            p_RowHangHoa.Item("DonViTinh") = l_donvitinh
            p_RowHangHoa.Item("TongDuXuat") = i_tongduxuat
            p_RowHangHoa.Item("TongXuat") = p_TongXuat
            p_RowHangHoa.Item("BeXuat") = p_BeXuat
            p_RowHangHoa.Item("SoLenh") = i_solenh
            p_RowHangHoa.Item("MaLenh") = i_malenh
            p_RowHangHoa.Item("NgayXuat") = CDate(i_ngayxuat).ToString("yyyy/MM/dd")
            p_RowHangHoa.Item("LineID") = i_wa.Item_Nd.ToString()

            p_RowHangHoa.Item("NhietDo") = p_NhietDoTemp
            p_RowHangHoa.Item("TaiTrong") = p_TaiTrongKg
            p_RowHangHoa.Item("TyTrong") = p_TyTrongBe
            p_TableHangHoa.Rows.Add(p_RowHangHoa)

            'If p_TBLTABLEID_ZT = True Then
            '    p_SQL = "INSERT INTO [TBLTABLEID_ZT](NgayXuat,TableID) VALUES ('" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & p_TableID & "')"
            '    p_DataRow = p_DataExec.NewRow
            '    p_DataRow.Item(0) = p_SQL
            '    p_DataExec.Rows.Add(p_DataRow)
            'End If

        Catch ex As Exception
            KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI = False
        End Try
    End Function


    'Private Sub KV1_GenScriptfromTbl(ByVal p_Client As String, ByVal l_ztb2 As Connect2SapEx.LIPSO2Table, _
    '                                                       ByRef p_DataExec As DataTable, _
    '                                                       ByVal i_wa As Connect2SAP.Str_PhieuXuat, _
    '                                                       ByVal i_malenh As String, _
    '                                                       ByVal i_ngayxuat As String, _
    '                                                       ByVal i_solenh As String, _
    '                                                       ByVal i_tongxuat As Decimal, _
    '                                                       ByVal i_tongduxuat As Decimal, _
    '                                                       ByVal i_loaiphieu As String, _
    '                                                       ByVal i_tableid As String, _
    '                                                       ByRef p_TableHangHoa As System.Data.DataTable)
    '    Dim p_DataRow As DataRow
    '    Dim p_Count As Integer
    '    Dim p_SQL As String
    '    Dim p_TBLTABLEID_ZT As Boolean = False
    '    Dim p_TableID As String
    '    Dim p_BeXuat As String

    '    Dim p_CountQCI As Integer
    '    Dim p_TongXuat As Decimal

    '    Dim p_TaiTrongKg As Decimal
    '    Dim l_mahanghoa, l_donvitinh, p_NhietDoTemp, p_TyTrongBe As String

    '    Dim p_LoaiVanChuyen As String = ""

    '    Dim p_RowHangHoa As System.Data.DataRow

    '    Dim p_Tank As String

    '    Dim p_TableID_number As Integer

    '    If p_TableHangHoa.Rows.Count > 0 Then
    '        Integer.TryParse(p_TableHangHoa.Rows(0).Item("TableID").ToString.Trim, p_TableID_number)
    '        If p_TableID_number > 0 Then


    '            For p_Count = 0 To p_TableHangHoa.Rows.Count - 1
    '                p_TableID_number = p_TableID_number + 1
    '                p_TableID = p_TableID_number.ToString.Trim
    '                If Len(p_TableID) = 7 Then
    '                    p_TableID = "0" & p_TableID
    '                End If

    '                p_TableHangHoa.Rows(p_Count).Item("TableID") = p_TableID
    '                p_SQL = "INSERT INTO [tblLenhXuat_HangHoaE5] (LineID, MaLenh,NgayXuat, SoLenh,TongXuat, " & _
    '                    "TongDuXuat, MaHangHoa, DonViTinh,BeXuat,TableID ,Createby,CreateDate, QCI_KG, QCI_NhietDo, QCI_TyTrong) "
    '                p_SQL = p_SQL & " VALUES ('" & p_TableHangHoa.Rows(p_Count).Item("LineID").ToString.Trim & "','" & _
    '                            p_TableHangHoa.Rows(p_Count).Item("MaLenh").ToString.Trim & "','" & _
    '                            CDate(p_TableHangHoa.Rows(p_Count).Item("NgayXuat").ToString.Trim).ToString("yyyyMMdd") & "','" & _
    '                            p_TableHangHoa.Rows(p_Count).Item("SoLenh").ToString.Trim & "'" & _
    '                        "," & p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim & "," & p_TableHangHoa.Rows(p_Count).Item("TongDuXuat").ToString.Trim & ",'" & _
    '                            p_TableHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & "','" & _
    '                            p_TableHangHoa.Rows(p_Count).Item("DonViTinh").ToString.Trim & "','" & _
    '                            p_TableHangHoa.Rows(p_Count).Item("BeXuat").ToString.Trim & "','" & p_TableID & "'," & g_User_ID & ",getdate()" & _
    '                        "," & p_TableHangHoa.Rows(p_Count).Item("TaiTrong").ToString.Trim & "," & _
    '                        p_TableHangHoa.Rows(p_Count).Item("NhietDo").ToString.Trim & "," & p_TableHangHoa.Rows(p_Count).Item("TyTrong").ToString.Trim & ")"

    '                p_DataRow = p_DataExec.NewRow
    '                p_DataRow.Item(0) = p_SQL
    '                p_DataExec.Rows.Add(p_DataRow)
    '            Next
    '        End If

    '    End If

    'End Sub



    Private Sub KV1_GenScriptfromTbl(ByVal p_Client As String, ByVal l_ztb2 As Connect2SapEx.LIPSO2Table, _
                                                           ByRef p_DataExec As DataTable, _
                                                           ByVal i_wa As Connect2SAP.Str_PhieuXuat, _
                                                           ByVal i_malenh As String, _
                                                           ByVal i_ngayxuat As String, _
                                                           ByVal i_solenh As String, _
                                                           ByVal i_tongxuat As Decimal, _
                                                           ByVal i_tongduxuat As Decimal, _
                                                           ByVal i_loaiphieu As String, _
                                                           ByVal i_tableid As String, _
                                                           ByRef p_TableHangHoa As System.Data.DataTable)
        Dim p_DataRow As DataRow
        Dim p_Count As Integer
        Dim p_SQL As String
        Dim p_TBLTABLEID_ZT As Boolean = False
        Dim p_TableID As String
        Dim p_BeXuat As String

        Dim p_CountQCI As Integer
        Dim p_TongXuat As Decimal

        Dim p_TaiTrongKg As Decimal
        Dim l_mahanghoa, l_donvitinh, p_NhietDoTemp, p_TyTrongBe As String

        Dim p_LoaiVanChuyen As String = ""

        Dim p_RowHangHoa As System.Data.DataRow

        Dim p_Tank As String

        Dim p_TableID_number As Integer

        If p_TableHangHoa.Rows.Count > 0 Then
            Integer.TryParse(p_TableHangHoa.Rows(0).Item("TableID").ToString.Trim, p_TableID_number)
            If p_TableID_number > 0 Then


                For p_Count = 0 To p_TableHangHoa.Rows.Count - 1
                    p_TableID_number = p_TableID_number + 1
                    p_TableID = p_TableID_number.ToString.Trim
                    If Len(p_TableID) = 7 Then
                        p_TableID = "0" & p_TableID
                    End If

                    'p_TableHangHoa.Rows(p_Count).Item("TableID") = p_TableID
                    p_SQL = "INSERT INTO [tblLenhXuat_HangHoaE5] (LineID, MaLenh,NgayXuat, SoLenh,TongXuat, " & _
                        "TongDuXuat, MaHangHoa, DonViTinh,BeXuat,TableID ,Createby,CreateDate, QCI_KG, QCI_NhietDo, QCI_TyTrong) "
                    p_SQL = p_SQL & " VALUES ('" & p_TableHangHoa.Rows(p_Count).Item("LineID").ToString.Trim & "','" & _
                                p_TableHangHoa.Rows(p_Count).Item("MaLenh").ToString.Trim & "','" & _
                                CDate(p_TableHangHoa.Rows(p_Count).Item("NgayXuat").ToString.Trim).ToString("yyyyMMdd") & "','" & _
                                p_TableHangHoa.Rows(p_Count).Item("SoLenh").ToString.Trim & "'" & _
                            "," & p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim & "," & p_TableHangHoa.Rows(p_Count).Item("TongDuXuat").ToString.Trim & ",'" & _
                                p_TableHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & "','" & _
                                p_TableHangHoa.Rows(p_Count).Item("DonViTinh").ToString.Trim & "','" & _
                                p_TableHangHoa.Rows(p_Count).Item("BeXuat").ToString.Trim & "','" & p_TableHangHoa.Rows(p_Count).Item("TableId").ToString.Trim & "'," & g_User_ID & ",getdate()" & _
                            "," & p_TableHangHoa.Rows(p_Count).Item("TaiTrong").ToString.Trim & "," & _
                            p_TableHangHoa.Rows(p_Count).Item("NhietDo").ToString.Trim & "," & p_TableHangHoa.Rows(p_Count).Item("TyTrong").ToString.Trim & ")"

                    p_DataRow = p_DataExec.NewRow
                    p_DataRow.Item(0) = p_SQL
                    p_DataExec.Rows.Add(p_DataRow)
                Next
            End If

        End If

    End Sub


    Public Function KV1_FPT_GetMaLenh(ByVal p_SoLenh As String, ByVal p_Date As Date) As String
        Dim p_ValueTmp As String = "0000"
        Dim p_SQL As String = ""
        Dim p_Value As Integer = 0
        Dim p_DataTable As DataTable
        Try
            If p_SYS_MALENH_S.ToString.Trim = "" Then
                p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG where KEYCODE='SYS_MALENH_S'"
                p_DataTable = GetDataTable(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        p_SYS_MALENH_S = p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim

                    End If
                End If
            End If

            p_DataTable = Nothing
            KV1_FPT_GetMaLenh = "0000"
            p_SQL = "exec FPT_Get_SYS_MALENH11 '" & p_SoLenh & "','" & p_Date.ToString("yyyyMMdd") & "'"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_Value = p_DataTable.Rows(0).Item(0)
                End If
            End If
            If p_Value > 0 Then
                If Len(p_Value.ToString.Trim) < 4 Then
                    KV1_FPT_GetMaLenh = Mid(p_ValueTmp, 1, Len(KV1_FPT_GetMaLenh.ToString.Trim) - Len(p_Value.ToString.Trim) - Len(p_SYS_MALENH_S)) & p_Value.ToString.Trim
                    If Len(KV1_FPT_GetMaLenh) = 3 Then
                        KV1_FPT_GetMaLenh = p_SYS_MALENH_S & KV1_FPT_GetMaLenh
                    End If
                Else
                    KV1_FPT_GetMaLenh = p_Value.ToString.Trim
                End If
            End If
        Catch ex As Exception
            KV1_FPT_GetMaLenh = "0000"
        End Try

    End Function




    Public Function CheckScadarToHTTG(ByRef p_TableScadar As DataTable, _
                                        ByRef p_TableScadar_E5 As DataTable, _
                                        ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                Optional ByVal p_Terminal As String = "", _
                                  Optional ByVal p_GetScadarToHTTG As Boolean = True, _
                                  Optional ByVal p_E5 As Boolean = True) As String Implements IService.CheckClsScadarToHTTG
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
        p_DataHTTG = p_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
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

    'anhqh
    '20161108  --Ham day du lieu xuong Scadar cho Fox
    Public Function HTTG_To_ScadarFox(ByVal p_UserName As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "", _
                                 Optional ByVal p_InsertToScadar As Boolean = True) As String Implements IService.SYS_HTTG_To_ScadarFox
        Dim p_ObjectFox As New HTTG_SCADAR_FOX

        HTTG_To_ScadarFox = p_ObjectFox.mdlHTTG_To_Scadar(p_UserName, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, _
                                     p_Terminal, _
                                     p_InsertToScadar, _
                                     True)
    End Function

    ''anhqh
    ''20161108  --Ham lay du lieu tu Scadar cho Fox ve HTTG
    'Public Function Sys_ScadarToHTTGFox(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "", _
    '                               Optional ByVal p_GetScadarToHTTG As Boolean = True, _
    '                               Optional ByVal p_E5 As Boolean = True) As String Implements IService.ClsScadarToHTTG_Fox

    '    Dim p_ObjectFox2 As New SCADAR_HTTG_FOX

    '    Sys_ScadarToHTTGFox = p_ObjectFox2.ScadarToHTTG(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, _
    '                             p_Terminal, _
    '                               p_GetScadarToHTTG, _
    '                               p_E5)
    'End Function


    Public Sub GetPathFileFox_DB1(ByRef p_FoxOut As String, ByRef p_FoxIn As String, ByRef p_FoxTemp As String) Implements IService.GetPathFileFox_DB
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




    Public Function ScadarToHTTG_Fox(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                 Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True, _
                                   Optional ByVal p_E5 As Boolean = True) As String Implements IService.ClsScadarToHTTG_Fox

        Dim p_FoxObject As New SCADAR_HTTG_FOX
        ScadarToHTTG_Fox = p_FoxObject.ScadarToHTTG(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, _
                                 p_Terminal, _
                                   p_GetScadarToHTTG, _
                                   p_E5)
    End Function

    Public Function clsScadar_HuyTichKe_fox(ByVal p_WareHouse As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "") As String Implements IService.clsScadar_HuyTichKe_fox
        Dim p_FoxObjectHuy As New HuyTichKeFox
        clsScadar_HuyTichKe_fox = p_FoxObjectHuy.Scadar_HuyTichKe(p_WareHouse, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Terminal)
    End Function

    Public Function clsHTTG_To_ScadarAccess(ByVal p_UserName As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                  Optional ByVal p_Terminal As String = "", _
                                  Optional ByVal p_InsertToScadar As Boolean = True,
                                  Optional ByVal p_E5 As Boolean = True) As String Implements IService.clsHTTG_To_ScadarAccess

        Dim p_AccessObject As New HTTG_SCADAR_ACC
        clsHTTG_To_ScadarAccess = p_AccessObject.mdlHTTG_To_Scadar(p_UserName, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, _
                                     p_Terminal, _
                                     p_InsertToScadar, _
                                     p_E5)


    End Function

    Public Function ClsScadarToHTTG_Access(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                 Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True, _
                                   Optional ByVal p_E5 As Boolean = True) As String Implements IService.ClsScadarToHTTG_Access

        Dim p_SCADAR_HTTG_ACC As New SCADAR_HTTG_ACC

        ClsScadarToHTTG_Access = p_SCADAR_HTTG_ACC.ScadarToHTTG(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, _
                                 p_Terminal, _
                                   p_GetScadarToHTTG, _
                                   p_E5)
    End Function



    'Private 
    'hieptd4 add 20161102
    Public Function mdlSyncDeliveries_SynSpecific_Ex(ByVal p_Client As String, ByVal p_User_ID As Integer, _
                                                    ByVal p_Company_Code As String, ByVal i_solenh As String, ByRef o_err As String) As Boolean

        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb_hd As Connect2SapEx.STR_HEADER_THNTable
        Dim l_ztb_it As Connect2SapEx.STR_ITEM_THNTable
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_err As String
        Dim l_f As Boolean = False

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String
        Dim p_TableConfig As DataTable
        Dim p_TableConfig1 As DataTable
        Dim p_SapConnectionString As String = ""
        Dim p_TimeOut = New TimeSpan()
        Dim p_WareHouse As String = ""
        Dim p_ShPoint As String = ""
        Dim p_DataRowArr() As DataRow

        Dim p_DataSet As New DataSet
        Dim p_Batch As String
        Dim p_Slog As String
        Dim p_MaKhachHang As String
        Dim p_StringTmp As String = "0000000000"
        Dim p_SoLenh As String
        Dim p_Table As DataTable
        Dim p_DiemTraHang As String

        Dim p_Count As Integer
        Dim l_dem As Integer = 0
        Dim p_DataTablExe As New DataTable("Table001")
        Dim p_Row As DataRow

        g_Company_Code = p_Company_Code

        'If p_DataTablExe Is Nothing Then
        p_DataTablExe = New DataTable("Table001")
        p_DataTablExe.Columns.Add("STR_SQL")
        'End If

        mdlSyncDeliveries_SynSpecific_Ex = False
        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG; select * from tblConfig;"
        p_DataSet = p_SYS_GET_DATASET_Des(p_SQL, p_SQL)

        g_KV1 = False

        g_User_ID = p_User_ID


        g_BATCHSLOG = False

        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_TableConfig = p_DataSet.Tables(0)
                p_TableConfig1 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_DataRowArr = p_TableConfig.Select("KEYCODE='TABLEID'")
                If p_DataRowArr.Length > 0 Then
                    p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='QUYDOI_SAP'")
                If p_DataRowArr.Length > 0 Then
                    p_QUYDOI_SAP = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KV1'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_KV1 = True
                    Else
                        g_KV1 = False
                    End If
                End If


                p_DataRowArr = p_TableConfig.Select("KEYCODE='BATCHSLOG'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_BATCHSLOG = True
                    Else
                        g_BATCHSLOG = False
                    End If
                End If



            End If
        End If



        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                p_SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If
        If p_SapConnectionString = "" Then
            mdlSyncDeliveries_SynSpecific_Ex = True
            MsgBox("Loi ket noi")
            Exit Function
        End If



        Try
            l_c2sap = New Connect2SapEx.Connect2Sap(p_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_ztb_hd = New Connect2SapEx.STR_HEADER_THNTable()
            l_ztb_it = New Connect2SapEx.STR_ITEM_THNTable()

            ' l_ztb As Connect2SapEx.LIPSO2Table
            l_err = String.Empty



            If p_TableConfig1.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
                l_c2sap.GetDO_THN(i_solenh, l_ztb_hd, l_ztb_it, l_ret2)

            Else
                l_async = l_c2sap.BeginGetDO_THN(i_solenh, l_ztb_hd, l_ztb_it, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetDO_THN(l_async, l_ztb_hd, l_ztb_it, l_ret2)
                End If
            End If

            l_dem = 0
            If l_ztb_hd.Count > 0 Then
                For i As Integer = 0 To l_ztb_hd.Count - 1
                    If l_ztb_hd.Item(i).Guebg.ToString() = "00000000" Then
                        l_ztb_hd.Item(i).Guebg = ""
                    End If
                    If l_ztb_hd.Item(i).Lddate.ToString() = "00000000" Then
                        l_ztb_hd.Item(i).Lddate = ""
                    End If
                    If l_ztb_hd.Item(i).Kurrf <> 0 Then
                        'l_ztb_hd.Item(i).Kurrf = 21.23
                        l_ztb_hd.Item(i).Kurrf = l_ztb_hd.Item(i).Kurrf * 1000
                    End If
                    p_SQL = "MERGE tblDO_Header AS target " & _
                        " USING (SELECT '" & Replace(l_ztb_hd.Item(i).Vbeln.ToString(), "'", "", 1) & "' as SoLenh ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Customer.ToString(), "'", "", 1) & "'  as MaKhachHang ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Long_Name.ToString(), "'", "", 1) & "'  as TenKhachHang ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Adress.ToString(), "'", "", 1) & "'  as DiaChiKH ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Contract.ToString(), "'", "", 1) & "'  as SoHopDong ," & _
                            IIf(l_ztb_hd.Item(i).Guebg.ToString.Trim = "", "null", "'" & l_ztb_hd.Item(i).Guebg.ToString() & "'") & "  as NgayHopDong ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Werks.ToString(), "'", "", 1) & "'  as MaKhoXuat ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Name1.ToString(), "'", "", 1) & "'  as TenKhoXuat ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Knota.ToString(), "'", "", 1) & "'  as LoadingPoint ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Loading_Point.ToString(), "'", "", 1) & "'  as DesLoadingPoint ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Knotz.ToString(), "'", "", 1) & "'  as DischargePoint ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Discharg_Point.ToString(), "'", "", 1) & "'  as DesDischargePoint ," & _
                                  Replace(l_ztb_hd.Item(i).Vat.ToString(), "'", "", 1) & "  as VAT ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Unit.ToString(), "'", "", 1) & "'  as DVT ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Zlsch.ToString(), "'", "", 1) & "'  as PaymentMethod ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Text1.ToString(), "'", "", 1) & "'  as DesPaymentMethod ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Zterm.ToString(), "'", "", 1) & "'  as Term ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Vtext.ToString(), "'", "", 1) & "'  as DesTerm ," & _
                                  Replace(l_ztb_hd.Item(i).Kurrf.ToString(), "'", "", 1) & "  as TyGia ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Tk_Number.ToString(), "'", "", 1) & "'  as SoTKHQNhap ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Tktx.ToString(), "'", "", 1) & "'  as SoTKHQXuat ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Carrier.ToString(), "'", "", 1) & "'  as MaNhaCungCap ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Lifnr_Name.ToString(), "'", "", 1) & "'  as TenNhaCungCap ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Route.ToString(), "'", "", 1) & "'  as MaTuyenDuong ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Werks_Nhap.ToString(), "'", "", 1) & "'  as MaKhoNhap ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Kho_Nhap.ToString(), "'", "", 1) & "'  as TenKhoNhap ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Phieu_Xuat.ToString(), "'", "", 1) & "'  as SoPXK ," & _
                        IIf(l_ztb_hd.Item(i).Lddate.ToString.Trim = "", "null", "'" & l_ztb_hd.Item(i).Lddate.ToString() & "'") & "  as NgayPXK " & _
                                " ) AS source (SoLenh,MaKhachHang,TenKhachHang,DiaChiKH,SoHopDong,NgayHopDong,MaKhoXuat,TenKhoXuat,LoadingPoint,DesLoadingPoint,DischargePoint,DesDischargePoint,VAT,DVT,PaymentMethod,DesPaymentMethod,Term,DesTerm,TyGia,SoTKHQNhap,SoTKHQXuat,MaNhaCungCap,TenNhaCungCap,MaTuyenDuong,MaKhoNhap,TenKhoNhap,SoPXK,NgayPXK ) " & _
                                " ON (target.SoLenh = source.SoLenh)" & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "MaKhachHang=source.MaKhachHang , " & _
                                    "TenKhachHang=source.TenKhachHang ," & _
                                    "DiaChiKH=source.DiaChiKH ," & _
                                    "SoHopDong=source.SoHopDong ," & _
                                    "NgayHopDong=source.NgayHopDong ," & _
                                    "MaKhoXuat=source.MaKhoXuat ," & _
                                    "TenKhoXuat=source.TenKhoXuat ," & _
                                    "LoadingPoint=source.LoadingPoint ," & _
                                    "DesLoadingPoint=source.DesLoadingPoint ," & _
                                    "DischargePoint=source.DischargePoint ," & _
                                    "DesDischargePoint=source.DesDischargePoint ," & _
                                    "VAT=source.VAT ," & _
                                    "DVT=source.DVT ," & _
                                    "PaymentMethod=source.PaymentMethod ," & _
                                    "DesPaymentMethod=source.DesPaymentMethod ," & _
                                    "Term=source.Term ," & _
                                    "DesTerm=source.DesTerm ," & _
                                    "TyGia=source.TyGia ," & _
                                    "SoTKHQNhap=source.SoTKHQNhap ," & _
                                    "SoTKHQXuat=source.SoTKHQXuat ," & _
                                    "MaNhaCungCap=source.MaNhaCungCap ," & _
                                    "TenNhaCungCap=source.TenNhaCungCap ," & _
                                    "MaTuyenDuong=source.MaTuyenDuong ," & _
                                    "MaKhoNhap=source.MaKhoNhap ," & _
                                    "TenKhoNhap=source.TenKhoNhap ," & _
                                    "SoPXK=source.SoPXK ," & _
                                    "NgayPXK=source.NgayPXK " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (SoLenh,MaKhachHang,TenKhachHang,DiaChiKH,SoHopDong,NgayHopDong,MaKhoXuat,TenKhoXuat,LoadingPoint,DesLoadingPoint,DischargePoint,DesDischargePoint,VAT,DVT,PaymentMethod,DesPaymentMethod,Term,DesTerm,TyGia,SoTKHQNhap,SoTKHQXuat,MaNhaCungCap,TenNhaCungCap,MaTuyenDuong,MaKhoNhap,TenKhoNhap,SoPXK,NgayPXK ) " & _
                            "VALUES (source.SoLenh,source.MaKhachHang,source.TenKhachHang,source.DiaChiKH,source.SoHopDong,source.NgayHopDong,source.MaKhoXuat,source.TenKhoXuat,source.LoadingPoint,source.DesLoadingPoint,source.DischargePoint,source.DesDischargePoint,source.VAT,source.DVT,source.PaymentMethod,source.DesPaymentMethod,source.Term,source.DesTerm,source.TyGia,source.SoTKHQNhap,source.SoTKHQXuat,source.MaNhaCungCap,source.TenNhaCungCap,source.MaTuyenDuong,source.MaKhoNhap,source.TenKhoNhap,source.SoPXK,source.NgayPXK ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If
            'If p_DataTablExe.Rows.Count > 0 Then
            '    If g_Services.Sys_Execute_DataTbl(p_DataTablExe, p_SQL) = False Then
            '        Exit Function
            '    End If
            'End If
            'p_DataTablExe.Clear()

            l_dem = 0
            If l_ztb_it.Count > 0 Then
                For i As Integer = 0 To l_ztb_it.Count - 1
                    'If l_ztb_it.Item(i).Koein.ToString() = "VND" Then  'da xu ly tren SAP
                    '    l_ztb_it.Item(i).Kbetr = l_ztb_it.Item(i).Kbetr * 100
                    'End If

                    p_SQL = "MERGE tblDO_Item_Material AS target " & _
                        " USING (SELECT '" & Replace(l_ztb_it.Item(i).Vbeln.ToString(), "'", "", 1) & "' as SoLenh ," & _
                                  Replace(l_ztb_it.Item(i).Posnr.ToString(), "'", "", 1) & "  as LineID ," & _
                                  Replace(l_ztb_it.Item(i).Kbetr.ToString(), "'", "", 1) & "  as DonGia ," & _
                                  "'" & Replace(l_ztb_it.Item(i).Koein.ToString(), "'", "", 1) & "'  as CurrencyKey " & _
                                " ) AS source (SoLenh, LineID, DonGia, CurrencyKey ) " & _
                                " ON (target.SoLenh = source.SoLenh and " & _
                                    " target.LineID = source.LineID ) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "DonGia=source.DonGia , " & _
                                    "CurrencyKey=source.CurrencyKey " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (SoLenh, LineID, DonGia, CurrencyKey) " & _
                            "VALUES (source.SoLenh, source.LineID, source.DonGia, source.CurrencyKey ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If


            p_SQL = "exec FPT_UpdateDO '" & i_solenh & "'"
            p_Row = p_DataTablExe.NewRow
            p_Row.Item(0) = p_SQL
            p_DataTablExe.Rows.Add(p_Row)

            If p_DataTablExe.Rows.Count > 0 Then
                If Sys_Execute_DataTbl(p_DataTablExe, p_SQL) = False Then
                    Return False
                    Exit Function
                End If
            End If
            p_DataTablExe.Clear()

            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True

        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try


    End Function


    Public Function ClsSyncMaster_SyncPrice(ByRef p_DataTablExe As DataTable, ByVal i_date As String, ByRef p_desc As String) As Boolean Implements IService.ClsSyncMaster_SyncPrice
        Dim p_DongBoNew As New MnuDongBoNew
        ClsSyncMaster_SyncPrice = p_DongBoNew.mdlSyncMaster_SyncPrice(p_DataTablExe, i_date, p_desc)
    End Function
    Public Function ClsSyncMaster_SyncPaymentTerm(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean Implements IService.ClsSyncMaster_SyncPaymentTerm
        Dim p_DongBoNew As New MnuDongBoNew
        ClsSyncMaster_SyncPaymentTerm = p_DongBoNew.mdlSyncMaster_SyncPaymentTerm(p_DataTablExe, p_desc)
    End Function
    Public Function ClsSyncMaster_SyncDischard(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean Implements IService.ClsSyncMaster_SyncDischard
        Dim p_DongBoNew As New MnuDongBoNew
        ClsSyncMaster_SyncDischard = p_DongBoNew.mdlSyncMaster_SyncDischard(p_DataTablExe, p_desc)
    End Function
    Public Function ClsSyncMaster_SyncRoute(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean Implements IService.ClsSyncMaster_SyncRoute
        Dim p_DongBoNew As New MnuDongBoNew
        ClsSyncMaster_SyncRoute = p_DongBoNew.mdlSyncMaster_SyncRoute(p_DataTablExe, p_desc)
    End Function
    Public Function ClsSyncMaster_SyncVendor(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, ByRef p_desc As String) As Boolean Implements IService.ClsSyncMaster_SyncVendor
        Dim p_DongBoNew As New MnuDongBoNew
        ClsSyncMaster_SyncVendor = p_DongBoNew.mdlSyncMaster_SyncVendor(p_DataTablExe, i_getall, i_date, p_desc)
    End Function


End Class
'End Namespace