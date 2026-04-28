Imports Microsoft.VisualBasic
Imports System.Data.OleDb


'Imports Microsoft.Win3
Imports VFPOLEDBLib

Imports System
'Imports System.Data.OracleClient
Imports System.Data
Imports System.Xml
Imports System.Security.Cryptography
Imports System.IO
Public Class ConnectHTTG

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



    'ANHQH
    '26/06/2014
    'Ham 1 cau lenh SQL
    'Tra ve bien DataTable
    Public Function p_SYS_GET_DATATABLE_Des(ByVal p_SQL As String, _
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


    ''ANHQH
    ''24/11/2011
    ''Ham lay thong tin ket noi may chu tren Register
    'Private Sub SysGetStrConnect()
    '    Dim p_Path As String
    '    Dim p_PassEn As String = ""
    '    Try
    '        ' p_Path = Windows.Forms.Application.StartupPath & "\B1Config.xml"
    '        p_Path = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath & "\B1Config.xml"
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

    '                g_DBTYPE = xml.GetAttribute(g_DBTYPE_Key)
    '                'p_Service = xml.GetAttribute(g_Service)

    '                ' p_TopHour = xml.GetAttribute(g_HOUR)s
    '                'p_TopMunite = xml.GetAttribute(g_MINUTE)
    '            End If
    '        End While
    '        'close the reader
    '        xml.Close()
    '    Catch ex As Exception

    '    End Try

    '    p_PassEn = mdlCryptor_Decrypt(g_Password, g_UserName)
    '    If p_PassEn Is Nothing Then
    '        p_PassEn = p_PassEn
    '    End If
    '    g_Password = p_PassEn


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


    Public Sub Sys_GetParameterOracle(ByRef p_DBTYPE As String)
        SysGetStrConnect()
        p_DBTYPE = g_DBTYPE
    End Sub

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



    'ANHQH
    '28/11/2011
    'Ham thuc hien Execute cac cau lenh SQL 

    Public Function Sys_Execute_DataTbl(ByVal p_DataTable1 As System.Data.DataTable, _
                                          ByRef p_Desc As String) As Boolean

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
End Class
