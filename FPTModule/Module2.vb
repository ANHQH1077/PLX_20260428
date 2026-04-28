Imports System.Data.OracleClient
Imports System.Xml
Imports System.Web
Module Module2

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
    'Public g_DBTYPE As String


    'Public g_Company_Host As String
    'Public g_Company_DB_Name As String

    Public g_Server As String
    'Public g_UserName As String
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
    'ANHQH
    '24/11/2011
    'Ham lay thong tin ket noi may chu tren Register
    Private Sub SysGetStrConnect()
        Dim p_Path As String

        Try
            p_Path = Windows.Forms.Application.StartupPath & "\B1Config.xml"
            '  p_Path = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath & "\B1Config.xml"
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
    End Sub



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

    Public Function CallFuntioncReturnCursorOralce(ByVal p_FunctionName As String, ByRef p_DessErr As String, ByVal p_ParameterArr() As OracleParameter) As DataTable

        Dim g_Oracle_Connection As New OracleConnection
        Dim myCommand As OracleCommand ' OleDbCommand
        Dim p_Adapter As OracleDataAdapter
        Dim p_Reader As OracleDataReader
        Dim p_ConnectStr As String
        Dim p_DataTable As New System.Data.DataTable
        Dim p_Int As Integer
        p_DessErr = ""
        Try
            CallFuntioncReturnCursorOralce = Nothing

            p_ConnectStr = SysGetConnect_Oracle()
            g_Oracle_Connection.ConnectionString = p_ConnectStr ' = New OracleConnection(p_ConnectStr)
            g_Oracle_Connection.Open()

            myCommand = New OracleCommand '(g_Oracle_Connection)
            myCommand.Connection = g_Oracle_Connection
            myCommand.CommandType = CommandType.StoredProcedure
            myCommand.CommandText = p_FunctionName
            '   myCommand.Parameters.Add("p_ObjectName", OracleType.NVarChar).Value = "SYS_FORMS_V"
            '  myCommand.  .Properties("PLSQLRSet") = True
            myCommand.Parameters.AddRange(p_ParameterArr)

            myCommand.Parameters.Add("p_ReturnCursor", OracleType.Cursor).Direction = ParameterDirection.ReturnValue
            p_Reader = myCommand.ExecuteReader
            p_DataTable.Load(p_Reader)
            'p_Adapter.lo()
            'p_Adapter = New OracleDataAdapter(myCommand)


            ' myCommand.

            'myCommand = New OracleCommand()
            'myCommand.Connection = g_Oracle_Connection
            'myCommand.CommandText = p_SQL
            'myCommand.Parameters.Add("Ref_Return", OracleType.Cursor).Direction = ParameterDirection.ReturnValue
            'p_Adapter = myCommand.ExecuteReader
            CallFuntioncReturnCursorOralce = p_DataTable
        Catch Ex As Exception

            p_DessErr = Ex.Message
            CallFuntioncReturnCursorOralce = Nothing

        End Try


    End Function
End Module
