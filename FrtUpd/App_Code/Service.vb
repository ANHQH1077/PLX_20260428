' NOTE: You can use the "Rename" command on the context menu to change the class name "Service" in code, svc and config file together.
Imports System.IO
Imports System.Xml
Imports System.Data.OleDb
Public Class Service
    Implements IService

    Const g_KEY_DB_NAME As String = "DB_NAME"
    Const g_KEY_USER As String = "DB_USER"
    Const g_KEY_PASS As String = "DB_PASS"
    Const g_KEY_SERVER As String = "DB_IPADDRESS"
    Const g_KEY_PORT As String = "DB_PORT"
    Const g_Service As String = "Service"

    Public g_Company_Host As String
    Public g_Company_DB_Name As String

    Public g_Server As String
    Public g_UserName As String
    Public g_Password As String

    Const g_RowNum As Integer = 20
    Public g_DBPortInstance As String
    Public g_DB_Name As String


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
                    ' g_UserName = "fes_AnhQH"
                    g_Password = xml.GetAttribute(g_KEY_PASS)
                    'g_Password = "AnhQH@FES12345"
                    g_DBPortInstance = xml.GetAttribute(g_KEY_PORT)



                    'g_ORAHOST = xml.GetAttribute(g_ORAHOST_Key)
                    'g_ORAPORT = xml.GetAttribute(g_ORAPORT_Key)
                    'g_SERVERNAME = xml.GetAttribute(g_SERVERNAME_Key)
                    'g_ORAUSER = xml.GetAttribute(g_ORAUSER_Key)
                    'g_ORAPASS = xml.GetAttribute(g_ORAPASS_Key)
                    'p_Service = xml.GetAttribute(g_Service)

                    ' p_TopHour = xml.GetAttribute(g_HOUR)s
                    'p_TopMunite = xml.GetAttribute(g_MINUTE)
                End If
            End While
            'close the reader
            xml.Close()
        Catch ex As Exception

        End Try
    End Sub


End Class
