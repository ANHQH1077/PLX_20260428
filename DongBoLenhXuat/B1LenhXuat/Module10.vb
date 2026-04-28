Imports System.Data.OleDb
'Imports System.IO
Imports System.Xml
Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Module Module10
    Public flag(15) As Integer
    Public lw_mess(15) As String

    Public _dtVariable As DataTable
    Public _TimeOut = New TimeSpan()

    Public g_Connection As New OleDb.OleDbConnection
    Public p_DatatableRuning As New DataTable
    Public p_ConStr As String
    'Public p_CompanyArray() As SAPbobsCOM.Company
    Public p_ConnectCompany() As OleDb.OleDbConnection
    Public p_DatatableFPTUSER As New DataTable
    Public p_DatatableDB As New DataTable


    Public drConfigHO() As System.Data.DataRow = Nothing
    '  Public p_DatatablePutAPI As New DataTable
    Public p_Path As String
    ' Public p_Path_Err As String
    '  Public p_Path_Info As String

    ' Public oCompany As New SAPbobsCOM.Company
    ' Public p_APICom As New SAPbobsCOM.Company
    Public p_SrvRunning As Boolean = False
    Public p_BPRunning As Boolean = False
    Public p_PORunning As Boolean = False
    Public p_ReturnRunning As Boolean = False
    Public p_SplitPORunning As Boolean = False
    Public p_ClosePORunning As Boolean = False
    Public p_CloseRequestRunning As Boolean = False
    Public p_LCNBPORunning As Boolean = False
    Public p_InputPORunning As Boolean = False
    Public p_CreateTableElapsedTime As Boolean = False
    Public g_PathXML As String

    Public g_DAtaSetXML As New DataSet


    Public g_SapConnectionString As String = ""
    Public g_ShPoint As String = ""
    Public g_WareHouse As String = ""
    Public g_TimeOut As Integer = 25
    Public g_TblConfig, g_tblXML, g_SysConfig As DataTable
    Public g_TimeRun As Integer = 23

    Public g_DayBefore As Integer = 0
    Public g_Interval1 As Integer = 600000  ' 10 minute

    Public g_Interval1_Start As Boolean = False
    Public g_Interval2 As Integer = 60000  ' 1 minute
    Public g_Interval2_Start As Boolean = False


    Public g_Interval3 As Integer = 600000  ' 10 minute

    Public g_Interval4 As Integer = 600000  ' 10 minute
    Public g_Interval5 As Integer = 600000  ' 10 minute
    Public g_Interval6 As Integer = 600000  ' 10 minute
    Public g_Interval7 As Integer = 600000  ' 10 minute
    Public g_Interval8 As Integer = 600000  ' 10 minute

    Public g_Interval9 As Integer = 600000  ' 10 minute

    Public g_Interval3_Start As Boolean = False

    Public g_Interval4_Start As Boolean = False
    Public g_Interval5_Start As Boolean = False
    Public g_Interval6_Start As Boolean = False
    Public g_Interval7_Start As Boolean = False
    Public g_Interval8_Start As Boolean = False

    Public g_Interval9_Start As Boolean = False

    Public lRetCode As Integer
    Public lErrCode As String
    Public sErrMsg As String

    Public g_JobRunng As Boolean = False

    Public g_JobRunngHopDong As Boolean = False
    Public g_JobRunngSTO As Boolean = False
    Public g_JobRunngDonGia As Boolean = False
    Public g_JobRunngCustomize As Boolean = False
    Public g_JobRunngToKhai As Boolean = False
    Public g_JobRunngNhaCungCap As Boolean = False
    Public g_JobRunngTuyenDuong As Boolean = False

    Private g_TimeSynCustomer As Integer = 2

    'Sub Main1()
    '    ' p_Path = Windows.Forms.Application.StartupPath & "\B1Config.xml"
    '    p_GetSystemInfor()

    '    '  ExecRuntimeToKhai()

    '    ExecRuntimeLenhXuat()

    '    ' DongBoLenhXuat()
    '    ' ExecRuntimeDonGia()
    '    ' SynCustomer()

    '    '  ExecRuntimeNhaCungCap()
    '    'ExecRuntimeHopDong()
    '    'ExecRuntimeLenhXuat()
    '    'DongBoLenhXuat()
    '    ' DongBoTuyenDuong()
    '    'ExecRuntimeNhaCungCap()


    '    ' ExecRuntimeDonGia()



    '    Exit Sub

    '    ExecRuntimeSTO()

    '    DongBoTuyenDuong()
    '    ExecRuntimeHopDong()
    '    DongBoLenhXuat()


    '    ' p_PriceListSync()
    '    'p_PutAPIBP()
    '    ' p_GetSOPutAPI_Company()
    '    '  p_PutAPIBP()



    'End Sub


    Public Sub p_GetSystemInfor()
        Dim p_SQL As String
        'Dim p_Tabl, 
        Dim p_DataSet As DataSet
        Dim p_RowArr() As DataRow
        Dim p_Table As DataTable
        'Public g_SapConnectionString As String = ""
        'Public g_ShPoint As String = ""
        'Public g_TimeOut As Integer = 25

        g_PathXML = Windows.Forms.Application.StartupPath & "\Config.xml"
        If Dir(g_PathXML) <> "" Then
            g_DAtaSetXML.ReadXml(g_PathXML)
            If Not g_DAtaSetXML Is Nothing Then
                If g_DAtaSetXML.Tables.Count > 0 Then
                    g_tblXML = g_DAtaSetXML.Tables(0)
                End If
            End If
        End If

        p_SQL = "select * from tblConfig; select * from SYS_CONFIG; select KEYVALUE from SYS_CONFIG where upper(keyCode)='TIMEAUTO';"
        p_DataSet = Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                g_TblConfig = p_DataSet.Tables(0)
                g_SysConfig = p_DataSet.Tables(1)
                p_Table = p_DataSet.Tables(2)


                p_RowArr = g_SysConfig.Select(" KeyCode='MALUULUONGKE'")
                p_RowArr = g_SysConfig.Select("KEYCODE='MALUULUONGKE'")
                If p_RowArr.Length > 0 Then
                    If p_RowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_MALUULUONGKE = True
                    Else
                        p_MALUULUONGKE = False
                    End If
                End If

                p_L15_RESET = False

                p_RowArr = g_SysConfig.Select("KEYCODE='L15_RESET'")
                If p_RowArr.Length > 0 Then
                    If p_RowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_L15_RESET = True
                    End If
                End If


                p_TONGDUXUAT = 0
                p_RowArr = g_SysConfig.Select("KEYCODE='TONGDUXUAT'")
                If p_RowArr.Length > 0 Then

                    If p_RowArr(0).Item("KEYVALUE").ToString.Trim = "1" Then
                        p_TONGDUXUAT = 1
                    End If
                End If


                p_RowArr = g_SysConfig.Select("KEYCODE='TONGDUXUATTHUY'")
                If p_RowArr.Length > 0 Then
                    p_TONGDUXUATTHUY = p_RowArr(0).Item("KEYVALUE").ToString.Trim
                End If


                p_RowArr = g_SysConfig.Select("KeyCode ='TIMEDAYAUTO'")
                g_DayBefore = 0
                Try
                    If p_RowArr.Length > 0 Then
                        Integer.TryParse(p_RowArr(0).Item("KeyValue").ToString.Trim, g_DayBefore)

                    End If
                Catch ex As Exception

                End Try

                p_RowArr = g_SysConfig.Select("KeyCode ='TIMEINTEVAL1'")
                g_Interval1 = 0
                Try
                    If p_RowArr.Length > 0 Then
                        Integer.TryParse(p_RowArr(0).Item("KeyValue").ToString.Trim, g_Interval1)

                    End If
                Catch ex As Exception

                End Try

                If g_Interval1 = 0 Then
                    g_Interval1 = 600000
                End If


                p_RowArr = g_SysConfig.Select("KeyCode ='TIMEINTEVAL3'")
                g_Interval3 = 0
                Try
                    If p_RowArr.Length > 0 Then
                        Integer.TryParse(p_RowArr(0).Item("KeyValue").ToString.Trim, g_Interval3)

                    End If
                Catch ex As Exception

                End Try

                If g_Interval3 = 0 Then
                    g_Interval3 = 600000
                End If

                p_RowArr = g_SysConfig.Select("KeyCode ='TIMEINTEVAL2'")
                g_Interval2 = 0
                Try
                    If p_RowArr.Length > 0 Then
                        Integer.TryParse(p_RowArr(0).Item("KeyValue").ToString.Trim, g_Interval2)

                    End If
                Catch ex As Exception

                End Try

                If g_Interval2 = 0 Then
                    g_Interval2 = 180000
                End If


                p_RowArr = g_SysConfig.Select("KeyCode ='SAP_HTTG'")
                g_Interval1_Start = False
                Try
                    If p_RowArr.Length > 0 Then
                        'Integer.TryParse(p_RowArr(0).Item("KeyValue").ToString.Trim, g_Interval2)
                        If p_RowArr(0).Item("KeyValue").ToString.Trim = "Y" Then
                            g_Interval1_Start = True
                        End If
                    End If
                Catch ex As Exception

                End Try

                p_RowArr = g_SysConfig.Select("KeyCode ='TDH_HTTG'")
                g_Interval2_Start = False
                Try
                    If p_RowArr.Length > 0 Then
                        'Integer.TryParse(p_RowArr(0).Item("KeyValue").ToString.Trim, g_Interval2)
                        If p_RowArr(0).Item("KeyValue").ToString.Trim = "Y" Then
                            g_Interval2_Start = True
                        End If
                    End If
                Catch ex As Exception

                End Try


                p_RowArr = g_SysConfig.Select("KeyCode ='CUSTOMER'")
                g_Interval3_Start = False
                Try
                    If p_RowArr.Length > 0 Then
                        'Integer.TryParse(p_RowArr(0).Item("KeyValue").ToString.Trim, g_Interval2)
                        If p_RowArr(0).Item("KeyValue").ToString.Trim = "Y" Then
                            g_Interval3_Start = True
                        End If
                    End If
                Catch ex As Exception

                End Try

                p_RowArr = g_SysConfig.Select("KeyCode ='HOPDONG'")
                g_Interval4_Start = False
                Try
                    If p_RowArr.Length > 0 Then
                        'Integer.TryParse(p_RowArr(0).Item("KeyValue").ToString.Trim, g_Interval2)
                        If p_RowArr(0).Item("KeyValue").ToString.Trim = "Y" Then
                            g_Interval4_Start = True
                        End If
                    End If
                Catch ex As Exception

                End Try

                p_RowArr = g_SysConfig.Select("KeyCode ='TK_TOKHAI'")
                g_Interval5_Start = False
                Try
                    If p_RowArr.Length > 0 Then
                        'Integer.TryParse(p_RowArr(0).Item("KeyValue").ToString.Trim, g_Interval2)
                        If p_RowArr(0).Item("KeyValue").ToString.Trim = "Y" Then
                            g_Interval5_Start = True
                        End If
                    End If
                Catch ex As Exception

                End Try

                p_RowArr = g_SysConfig.Select("KeyCode ='TUYENDUONG'")
                g_Interval6_Start = False
                Try
                    If p_RowArr.Length > 0 Then
                        'Integer.TryParse(p_RowArr(0).Item("KeyValue").ToString.Trim, g_Interval2)
                        If p_RowArr(0).Item("KeyValue").ToString.Trim = "Y" Then
                            g_Interval6_Start = True
                        End If
                    End If
                Catch ex As Exception

                End Try

                p_RowArr = g_SysConfig.Select("KeyCode ='STO'")
                g_Interval7_Start = False
                Try
                    If p_RowArr.Length > 0 Then
                        'Integer.TryParse(p_RowArr(0).Item("KeyValue").ToString.Trim, g_Interval2)
                        If p_RowArr(0).Item("KeyValue").ToString.Trim = "Y" Then
                            g_Interval7_Start = True
                        End If
                    End If
                Catch ex As Exception

                End Try

                p_RowArr = g_SysConfig.Select("KeyCode ='DONGIA'")
                g_Interval8_Start = False
                Try
                    If p_RowArr.Length > 0 Then
                        'Integer.TryParse(p_RowArr(0).Item("KeyValue").ToString.Trim, g_Interval2)
                        If p_RowArr(0).Item("KeyValue").ToString.Trim = "Y" Then
                            g_Interval8_Start = True
                        End If
                    End If
                Catch ex As Exception

                End Try

                p_RowArr = g_SysConfig.Select("KeyCode ='NHACC'")
                g_Interval9_Start = False
                Try
                    If p_RowArr.Length > 0 Then
                        'Integer.TryParse(p_RowArr(0).Item("KeyValue").ToString.Trim, g_Interval2)
                        If p_RowArr(0).Item("KeyValue").ToString.Trim = "Y" Then
                            g_Interval9_Start = True
                        End If
                    End If
                Catch ex As Exception

                End Try


            End If
        End If

        If Not g_TblConfig Is Nothing Then
            If g_TblConfig.Rows.Count > 0 Then
                g_SapConnectionString = g_TblConfig.Rows(0).Item("sapconnectionstring").ToString.Trim
                g_ShPoint = g_TblConfig.Rows(0).Item("shippingpoint").ToString.Trim
                g_Company_Code = g_TblConfig.Rows(0).Item("CompanyCode").ToString.Trim
                g_WareHouse = g_TblConfig.Rows(0).Item("Warehouse").ToString.Trim


            End If
        End If
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                Try
                    Integer.TryParse(p_Table.Rows(0).Item(0).ToString.Trim, g_TimeRun)
                Catch ex As Exception

                End Try

            End If
            If g_TimeRun = 0 Then
                g_TimeRun = 23
            End If
        End If

        g_Services = New FPTBUSSINESS.Class1()
        g_SAP_OBJECT = New SAP_OBJECT.Class1(0, g_Company_Code, g_Services)
        Dim p_dt As DataTable
        g_SyncMaster = New SynMaster.Class1(False, g_Services, flag, lw_mess, "H",
                  p_dt, g_SapConnectionString, g_WareHouse, g_TblConfig, g_Company_Code, g_ShPoint)


        If Not g_SysConfig Is Nothing Then
            If g_SysConfig.Rows.Count > 0 Then
                SaveLog("connect to HTTG", "connect to HTTG", "")
            End If
        End If
    End Sub




    'Private Function p_CheckExistRecordAPI(ByVal p_DocNum As Integer, _
    '                                        ByVal p_APIDatabase As String, _
    '                                        ByVal p_ObjType As String) As Boolean
    '    Dim p_Data As DataTable
    '    p_CheckExistRecordAPI = False
    '    Try
    '        p_Data = mod_SYS_GET_DATASET("SELECT isnull(DocNum,0) as DocNum  FROM [FPTPUTAPI] where [DocNum]=" & p_DocNum & _
    '                                        " and [APIDatabase]='" & p_APIDatabase & "' and [ObjType]='" & p_ObjType & "'").Tables(0)
    '        If Not p_Data Is Nothing Then
    '            If p_Data.Rows.Count > 0 Then
    '                If p_Data.Rows(0).Item("DocNum") > 0 Then
    '                    p_CheckExistRecordAPI = True
    '                    Exit Function
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Function


    ''ANHQH
    ''21/11/2011
    ''Ham 1 cau lenh SQL
    ''Tra ve bien DataSet

    'Public Function mod_SYS_GET_DATASET(ByVal p_SQL As String) As System.Data.DataSet
    '    'Dim dr As OleDbDataReader

    '    Dim Olecon As New OleDbConnection
    '    Dim OlemyCommand As OleDbCommand
    '    Dim p_OleAdapter As OleDbDataAdapter
    '    'Dim connectionString As String
    '    'Dim sSQL As String
    '    Dim p_DataTable As New System.Data.DataSet
    '    ' Dim p_Recorset As New Object
    '    Dim p_Int As Integer
    '    Try
    '        OlemyCommand = New OleDbCommand(p_SQL, g_Connection)
    '        p_OleAdapter = New OleDbDataAdapter(OlemyCommand)
    '        p_Int = p_OleAdapter.Fill(p_DataTable)
    '    Catch Ex As Exception
    '        SaveLog("mod_SYS_GET_DATASET(" & Date.Now.ToString & ")", Ex.Message, "")
    '    End Try
    '    mod_SYS_GET_DATASET = p_DataTable
    'End Function

    Public Sub SaveLog(ByVal strData As String, ByVal p_Ex_Message As String, ByVal p_CompanyCode As String)
        Dim myCommand As OleDbCommand
        Dim p_Status As Boolean
        Dim p_SQL As String
        Dim p_Ex_Message123 As String = ""
        p_Status = True
        Try
            'If g_Connection.State.ToString() = "Open" Then
            p_SQL = "INSERT INTO [FPTAPIERR]  (RunDate,[StrSQL],[Err_Mess] ,[CompanyCode]) "
            p_SQL = p_SQL & " VALUES(getdate(),'" & Replace(strData, "'", "", 1) & "','" & Replace(p_Ex_Message, "'", "", 1) & "','" & p_CompanyCode & "')"
            If Sys_Execute(p_SQL, p_Ex_Message123) Then

            End If

            ' End If
            'Dim fs As New FileStream(FullPath, FileMode.OpenOrCreate, FileAccess.Write)
            'Dim sw As New StreamWriter(fs)




            'If mod_SYS_EXCUTE_SQL(p_SQL) = False Then

            'End If
            'sw.BaseStream.Seek(0, SeekOrigin.End)s
            'sw.WriteLine(strData)
            'sw.Flush()
            'sw.Close()
        Catch Ex As Exception

        End Try
    End Sub



    Sub ReadConfig()
        ' Create an XML reader.

        Dim p_DBServer As String = ""
        Dim p_DBPortInstance As String = ""
        Dim p_DBDatabase As String = ""
        Dim p_DbUserName As String = ""
        Dim p_DbPassword As String = ""

        Const g_KEY_DB_NAME As String = "DB_NAME"
        Const g_KEY_USER As String = "DB_USER"
        Const g_KEY_PASS As String = "DB_PASS"
        Const g_KEY_SERVER As String = "DB_IPADDRESS"
        Const g_KEY_PORT As String = "DB_PORT"
        Try
            Dim xml As XmlTextReader
            xml = New XmlTextReader(p_Path)
            xml.WhitespaceHandling = WhitespaceHandling.None
            While Not xml.EOF
                xml.Read()
                If Not xml.IsStartElement() Then
                    Exit While
                End If
                If xml.HasAttributes Then
                    p_DBDatabase = xml.GetAttribute(g_KEY_DB_NAME)
                    p_DBServer = xml.GetAttribute(g_KEY_SERVER)
                    p_DbUserName = xml.GetAttribute(g_KEY_USER)
                    p_DbPassword = xml.GetAttribute(g_KEY_PASS)
                    p_DBPortInstance = xml.GetAttribute(g_KEY_PORT)
                End If
            End While
            'close the reader
            xml.Close()
            Dim connectionString As String

            ' SysGetStrConnect()
            If p_DBPortInstance.ToString.Trim = "" Then
                connectionString = "Provider=SQLOLEDB;Data Source=" & p_DBServer & ";Persist Security Info=True;User ID=" &
                    p_DbUserName & ";Password=" & p_DbPassword & ";Initial Catalog=" & p_DBDatabase & ";Connect Timeout=300"
            Else
                connectionString = "Provider=SQLOLEDB;Server=" & p_DBServer & "," & p_DBPortInstance & ";" &
                        "Database=" & p_DBDatabase & ";User ID=" & p_DbUserName & ";Password=" & p_DbPassword & ";" &
                        "Trusted_Connection=False;Connect Timeout=300"
            End If
            ' Data Source=10.251.0.220;Initial Catalog=FRT_CUSTOMIZE;Persist Security Info=True;User ID=fes_AnhQH;Password=AnhQH@FES12345


            Try
                ' SaveLog("==========Get: Sys_SQL_Connection(" & Date.Now.ToString & ")", p_Path_Info)
                g_Connection = New OleDbConnection(connectionString)

                g_Connection.Open()
                ' SaveLog("==========Done: Sys_SQL_Connection(" & Date.Now.ToString & ")", p_Path_Info)

            Catch ex As Exception
                SaveLog("==========Error: Sys_SQL_Connection(" & Date.Now.ToString & ")", ex.Message, "")

            End Try
            'SaveLog("==========", p_Path_Info)
            'SaveLog(p_DBServer, p_Path_Info)
            'SaveLog(p_DBDatabase, p_Path_Info)
            'SaveLog(p_DbUserName, p_Path_Info)
            'SaveLog(p_DbPassword, p_Path_Info)
            'SaveLog("==========", p_Path_Info)

            ' Console.ReadKey()
            ' SaveLog("==========Done: ReadConfig(" & Date.Now.ToString & ")", p_Path_Info)
        Catch ex As Exception
            SaveLog("==========Error: ReadConfig(" & Date.Now.ToString & ")", ex.Message, "")
        End Try


    End Sub



    Public Sub SynCustomer()
        Dim p_Err As String
        Dim p_DataTable, p_Table, p_Table2 As DataTable
        Dim p_ConfigValue As String = "CUSTOMERTIMESYN"
        Dim p_Para As String = "CUSTOMER"

        Dim i_date As String = ""
        Dim i_dateTo As String = ""

        Dim p_DataGrid As New DataTable("Table")
        Dim p_DataSet As DataSet

        Dim p_SQL As String

        'Dim p_DateTime As 
        Dim p_Check As Boolean = False
        Dim p_desc As String = ""

        If g_SapConnectionString = "" Then
            SaveLog("Error: SAP to HTTG", "kết nối đến SAP", "")
            g_JobRunngCustomize = False
            Exit Sub
        End If

        g_JobRunngCustomize = True
        Try


            p_SQL = "GetTimeSyns '" & p_ConfigValue & "','" & p_Para & "'"
            p_DataSet = GetDataSet(p_SQL, p_SQL)
            If Not p_DataSet Is Nothing Then
                If p_DataSet.Tables.Count > 0 Then
                    p_Table = p_DataSet.Tables(0)
                    p_Table2 = p_DataSet.Tables(1)
                End If
            End If

            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    If p_Table.Rows(0).Item(0) = 0 Then
                        If p_Table2.Rows.Count > 0 Then
                            i_date = CDate(p_Table2.Rows(0).Item(0)).ToString("yyyy.MM.dd")
                        End If
                        If i_date <> "" Then
                            If mdlSyncMaster_SyncCustomer("H",
                                                         i_date, p_desc) = False Then
                                SaveLog("Service:Customer - ", p_desc, "")

                            Else
                                'SaveLog("CUSTOMER", p_desc, "")
                            End If
                        End If
                    Else
                        Exit Sub
                    End If
                End If

            End If

            'p_SQL = "select convert(date,getdate()-1) as dDate"
            'p_DataTable = GetDataTable(p_SQL, p_SQL)
            'i_date = ""
            'If Not p_DataTable Is Nothing Then
            '    If p_DataTable.Rows.Count > 0 Then
            '        i_date = CDate(p_DataTable.Rows(0).Item(0)).ToString("yyyy.MM.dd")
            '    End If
            'End If
            'If i_date <> "" Then
            '    If mdlSyncMaster_SyncCustomer("H",
            '                                 i_date, p_desc) = False Then
            '        SaveLog("Service:Customer - ", p_desc, "")

            '    Else
            '        'SaveLog("CUSTOMER", p_desc, "")
            '    End If
            'End If
Line_KT:
            g_JobRunngCustomize = False

        Catch ex As Exception
            SaveLog("Service:Customer - ", ex.Message, "")
            g_JobRunngCustomize = False
        End Try
    End Sub


    '    Public Sub SynCustomer()
    '        Dim p_Err As String
    '        Dim p_DataTable, p_Datatable2 As DataTable
    '        Dim i_date As String = ""
    '        Dim i_dateTo As String = ""
    '        Dim p_Date As Date
    '        Dim p_Count As Integer
    '        Dim p_Datarow As DataRow
    '        Dim l_ztb As Connect2SapEx.Str_PhieuXuatTable
    '        Dim p_Column As Integer
    '        Dim p_DataGrid As New DataTable("Table")

    '        Dim p_Row() As DataRow
    '        Dim p_SQL As String
    '        Dim p_SQL22 As String
    '        'Dim p_DateTime As 
    '        Dim p_Check As Boolean = False
    '        Dim p_desc As String = ""

    '        If g_SapConnectionString = "" Then
    '            SaveLog("Error: SAP to HTTG", "kết nối đến SAP", "")
    '            g_JobRunngCustomize = False
    '            Exit Sub
    '        End If

    '        g_JobRunngCustomize = True
    '        Try
    '            p_SQL = "select KeyValue from SYS_CONFIG where KeyCode='CUSTOMERTIMESYN'"
    '            p_DataTable = GetDataTable(p_SQL, p_SQL)
    '            If Not p_DataTable Is Nothing Then
    '                If p_DataTable.Rows.Count > 0 Then
    '                    Integer.TryParse(p_DataTable.Rows(0).Item(0).ToString.Trim, g_TimeSynCustomer)
    '                End If
    '            End If
    '            If g_TimeSynCustomer = 0 Then
    '                g_TimeSynCustomer = 2
    '            End If
    '            p_SQL = "  Select  distinct datepart(hour,dDate) As RunDate  from tblLogSyn_Hist " &
    '                        " where Para ='CUSTOMER' and convert(date,dDate) =convert(date, getdate())  " &
    '                            " And (DatePart(Hour, dDate) >= " & g_TimeSynCustomer & ")"
    '            'p_SQL = "select  distinct datepart(hour,RunDate) as RunDate from FPTAPIERR where strsql='CUSTOMER' and convert(date,runDate) =convert(date, getdate()) " &
    '            '        " and ( datepart(hour,RunDate()) >=" & g_TimeSynCustomer & ")"

    '            p_DataTable = GetDataTable(p_SQL, p_SQL)
    '            If Not p_DataTable Is Nothing Then
    '                If p_DataTable.Rows.Count >= 0 Then
    '                    p_Check = True
    '                End If
    '            End If

    '            If p_Check = True Then   '''Neu da thuc hien dong bo roi thi thoat ra ngoai
    '                g_JobRunngCustomize = False
    '                Exit Sub

    '            Else   'Kiem tra xem da chay 1 lan chua

    '                p_SQL = "  Select Case distinct datepart(hour,dDate) As RunDate  from tblLogSyn_Hist " &
    '                        " where Para ='CUSTOMER' and convert(date,dDate) =convert(date, getdate())  " &
    '                            " And (DatePart(Hour, dDate) = " & g_TimeSynCustomer & ")"
    '                'p_SQL = "Select  distinct datepart(hour, RunDate) As RunDate  from FPTAPIERR where strsql='CUSTOMER' and convert(date,runDate) =convert(date, getdate()) " &
    '                '    " and ( datepart(hour,RunDate()) =" & g_TimeSynCustomer & ")"

    '                p_DataTable = GetDataTable(p_SQL, p_SQL)
    '                If Not p_DataTable Is Nothing Then
    '                    If p_DataTable.Rows.Count > 0 Then
    '                        If p_DataTable.Rows(0).Item(0) = g_TimeSynCustomer Then
    '                            g_JobRunngCustomize = False
    '                            Exit Sub

    '                            ' p_Check = True
    '                        End If

    '                    End If
    '                End If
    '            End If

    '            'If p_Check = True Then  ''Neu da co chay 1 lan thi kiem tra xem thoi gian co > hon g_TimeSynCustomer
    '            '    p_SQL = "select datepart(hour,getdate())  as nHour  where   datepart(hour,getdate()) =" & g_TimeSynCustomer
    '            '    p_DataTable = GetDataTable(p_SQL, p_SQL)
    '            '    If Not p_DataTable Is Nothing Then
    '            '        If p_DataTable.Rows.Count > 0 Then
    '            '            g_JobRunngCustomize = False
    '            '            Exit Sub

    '            '        End If
    '            '    End If
    '            'End If



    '            p_SQL = "select convert(date,getdate()-1) as dDate"
    '            p_DataTable = GetDataTable(p_SQL, p_SQL)
    '            i_date = ""
    '            If Not p_DataTable Is Nothing Then
    '                If p_DataTable.Rows.Count > 0 Then
    '                    i_date = CDate(p_DataTable.Rows(0).Item(0)).ToString("yyyy.MM.dd")
    '                End If
    '            End If
    '            If i_date <> "" Then
    '                If mdlSyncMaster_SyncCustomer("H",
    '                                             i_date, p_desc) = False Then
    '                    SaveLog("Service:Customer - ", p_desc, "")

    '                Else
    '                    'SaveLog("CUSTOMER", p_desc, "")
    '                End If
    '            End If
    'Line_KT:
    '            g_JobRunngCustomize = False

    '        Catch ex As Exception
    '            SaveLog("Service:Customer - ", ex.Message, "")
    '            g_JobRunngCustomize = False
    '        End Try
    '    End Sub



    Public Function mdlSyncMaster_SyncCustomer(ByVal i_getall As String,
                                               ByVal i_date As String, ByRef p_desc As String) As Boolean
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.STR_KH_NEWTable
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String
        Dim p_TenKhach, p_DiaChi, p_MST As String
        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0
        Dim p_DataTablExe As DataTable
        Dim p_Row As DataRow
        '  If p_DataTablExe Is Nothing Then
        p_DataTablExe = New DataTable("Table001")
        p_DataTablExe.Columns.Add("STR_SQL")

        'End If
        Try
            p_desc = ""
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            '----------------------------------------------------------------------------------------------

            g_SyncMaster.clsHistStringSyn("CUSTOMER", True)

            l_c2sap = New Connect2SapEx.Connect2Sap(g_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_ztb = New Connect2SapEx.STR_KH_NEWTable()

            If g_TimeOut = "25" Then
                'If _dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetKhachHang_new(g_Company_Code, i_date, i_getall, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetKhachHang_new(g_Company_Code, i_date, i_getall, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(g_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetKhachHang_new(l_async, l_ztb, l_ret2)
                End If
            End If

            '----------------------------------------------------------------------------------------------
            '   Đưa thông tin vào csdl SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            If l_ztb.Count > 0 Then
                For i As Integer = 0 To l_ztb.Count - 1
                    'Cho dữ liệu vào CSDL SQL

                    If l_ztb.Item(i).Makh.ToString() = "0000318552" Then
                        p_SQL = ""
                    End If

                    p_TenKhach = l_ztb.Item(i).Tenkh.ToString()
                    If p_TenKhach <> "" Then
                        p_TenKhach = Replace(p_TenKhach, "'", "", 1)
                    End If


                    p_DiaChi = l_ztb.Item(i).Diachi.ToString()
                    If p_DiaChi <> "" Then
                        p_DiaChi = Replace(p_DiaChi, "'", "", 1)
                    End If
                    p_MST = l_ztb.Item(i).Mst.ToString()
                    If p_MST <> "" Then
                        p_MST = Replace(p_MST, "'", "", 1)
                    End If

                    p_SQL = "MERGE tblKhachHang AS target " &
                        " USING (SELECT '" & Replace(l_ztb.Item(i).Makh.ToString(), "'", "", 1) & "' as MakhachHang ," &
                                 "N'" & p_TenKhach & "'  as TenKhachHang," &
                                 "N'" & p_DiaChi & "'  as DiaChi ," &
                                 "'" & p_MST & "'  as MST, " &
                                "'X' as Status) AS source (MakhachHang, TenKhachHang, DiaChi, MST, Status) " &
                                " ON (target.MakhachHang = source.MakhachHang) " &
                            " WHEN MATCHED  THEN UPDATE SET " &
                                    "TenKhachHang=source.TenKhachHang " &
                                    ",DiaChi=source.DiaChi " &
                                     ",DiaChiFull=source.DiaChi " &
                                    ",MaSoThue=source.MST " &
                                    ",Status=source.Status " &
                         " WHEN NOT MATCHED THEN " &
                            "INSERT  (MaKhachhang,TenKhachhang,Diachi,MaSoThue,Status, DiaChiFull ) " &
                                "VALUES (source.MaKhachhang,source.TenKhachhang,source.Diachi,source.MST,source.Status, source.DiaChi ) ;"
                    '   p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)
                    'If Sys_Execute(p_SQL, p_desc) = False Then

                    'End If
                    l_dem = l_dem + 1
                Next
            End If

            If p_DataTablExe.Rows.Count > 0 Then
                If Sys_Execute_DataTbl(p_DataTablExe, p_desc) = False Then
                    p_SQL = p_desc
                    'p_SQL = "INSERT INTO [FPTAPIERR] ([RunDate] ,[StrSQL] )"
                    'p_SQL = p_SQL & " VALUES (getdate(),'CUSTOMER' )"
                    'If Sys_Execute(p_SQL, p_SQL) = False Then
                    SaveLog("mdlSyncMaster_SyncCustomer", p_desc, "")
                    'End If
                End If
            End If
            ' g_SyncMaster.clsHistStringSyn("CUSTOMER", True)
            g_SyncMaster.clsHistStringSyn("CUSTOMER: " & p_DataTablExe.Rows.Count, False)


            l_c2sap.Connection.Close()
            l_c2sap.Dispose()


            Return True

        Catch ex As Exception
            p_desc = ex.Message
            Return False
        End Try
    End Function

    Public Sub DongBoMaterData()
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_RowArr() As DataRow
        Dim p_ListTime As String = "23"
        If Not g_TblConfig Is Nothing Then
            p_RowArr = g_TblConfig.Select("KeyCode ='9BangGia'")
            If p_RowArr.Length > 0 Then
                p_RowArr = g_TblConfig.Select("KeyCode ='9BangGia_Time'")
                If p_RowArr.Length > 0 Then
                    p_ListTime = p_RowArr(0).Item("KeyValue").ToString.Trim
                End If
            End If
        End If
    End Sub

    'Anhqh
    '20200320
    'Dong bo Bang Gia
    Public Sub DongBoMaterData2(p_Code As String)
        Dim p_pPriStatus As String = ""
        Dim p_SQL As String = ""
        Dim p_Date As String
        Dim p_Tp_DataTablExeable As New DataTable
        '  Dim p_ConnectSapString As String = ""
        Dim p_TimeOut As String = "60"
        ' Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim lw_str = "Đồng bộ dữ liệu"
        Dim lw_failed = "thất bại"
        Dim lw_ok = "thành công"
        Dim p_desc As String = ""
        Dim l_date As String = String.Empty
        Dim p_DataExec As New DataTable("table001")
        'Dim p_Date As Date
        'Dim p_time As Integer
        'Dim p_SQL As String = ""
        Dim p_Datatable, g_dt As DataTable
        'Dim p_Desc As String
        Dim isGetAll As String = "H"
        Dim _TimeOut = New TimeSpan()
        p_DataExec.Columns.Add("STR_SQL")
        'p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(g_SapConnectionString, "EN", p_TimeOut)
        'g_SapConnectionString = g_TblConfig.Rows(0).Item("sapconnectionstring").ToString.Trim
        'g_ShPoint = g_TblConfig.Rows(0).Item("shippingpoint").ToString.Trim
        'g_Company_Code = g_TblConfig.Rows(0).Item("CompanyCode").ToString.Trim
        'g_WareHouse = g_TblConfig.Rows(0).Item("Warehouse").ToString.Trim

        If g_SapConnectionString = "" Then
            p_GetSystemInfor()
        End If
        Dim p_SyncMaster As New SynMaster.Class1(False, Nothing, flag, lw_mess, isGetAll,
                  g_dt, g_SapConnectionString, g_WareHouse, _dtVariable, g_Company_Code, g_ShPoint)
        Select Case p_Code
            Case "DonGia"
                p_Date = p_SyncMaster.clsGetDateLog(p_Code)

                If p_SyncMaster.ClsSyncMaster_SyncPrice(p_DataExec, p_Date, p_desc) = False Then

                End If
            Case Else
        End Select

        If p_DataExec.Rows.Count > 0 Then
            If Sys_Execute_DataTableNew(p_DataExec, p_desc) = False Then
                SaveLog("Dong bo " & p_Code, p_desc, "")
            End If

        End If


    End Sub

    '    'anhqh
    '    '20180601
    '    'ham lay lenh tren SAP xuong
    '    Public Sub modGetDataFromSAP()
    '        Dim p_Err As String
    '        Dim p_DataTable, p_Datatable2 As DataTable
    '        Dim i_date As String = ""
    '        Dim i_dateTo As String = ""
    '        Dim p_Date As Date
    '        Dim p_Count As Integer
    '        Dim p_Datarow As DataRow
    '        Dim l_ztb As Connect2SapEx.Str_PhieuXuatTable
    '        Dim p_Column As Integer
    '        Dim p_DataGrid As New DataTable("Table")

    '        Dim p_Row() As DataRow
    '        Dim p_SQL As String
    '        Dim p_SQL22 As String
    '        'Dim p_DateTime As 



    '        If g_SapConnectionString = "" Then
    '            SaveLog("Error: SAP to HTTG", "kết nối đến SAP", "")

    '            Exit Sub
    '        End If

    '        g_JobRunng = True
    '        Try

    '            'p_SQL = "select  convert(date,getdate()) as dDate, datepart(hour,getdate())as tHour, datepart(minute,getdate()) as tTime" & _
    '            '                "  where(DatePart(Hour, getdate()) >=" & g_TimeRun & ")  "    ''and not exists (select 1 from FPTSapToHTTG where convert(date,RunDate) =convert(date,getdate()))"

    '            'p_SQL = "select top 1 convert(date,getdate()) as dDate, convert(date,getdate()-" & g_DayBefore & ") as fDate, " & _
    '            '        " datepart(hour,getdate())as tHour, datepart(minute,getdate()) as tTime  " & _
    '            '        " where(DatePart(Hour, getdate()) >= 10) and convert(date,getdate())  > = convert(date,getdate()-" & g_DayBefore & ") "
    '            'CurrentDate - (TIMEDAYAUTO - 1)
    '            p_SQL = "select top 1 convert(date,getdate() - (" & g_DayBefore & " - 1) ) as fDate, convert(date,getdate()  + " & g_DayBefore & ") as dDate , " &
    '                   " datepart(hour,getdate())as tHour, datepart(minute,getdate()) as tTime  " &
    '                   " where   DatePart(Hour, getdate()) >= " & g_TimeRun & ""


    '            p_Datatable2 = Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '            If Not p_Datatable2 Is Nothing Then
    '                If p_Datatable2.Rows.Count > 0 Then

    '                    'p_SQL22 = "INSERT INTO AAAA (sSQL) VALUES ('" & p_SQL & "')"
    '                    'If Sys_Execute(p_SQL22, p_SQL22) Then

    '                    'End If



    '                    p_Date = CDate(p_Datatable2.Rows(0).Item("fDate"))
    '                    i_date = p_Date.ToString("yyyy.MM.dd")
    '                    ' i_dateTo = p_Date.ToString("yyyy.MM.dd")

    '                    p_Date = CDate(p_Datatable2.Rows(0).Item("dDate"))
    '                    ' i_date = p_Date.ToString("yyyy.MM.dd")
    '                    i_dateTo = p_Date.ToString("yyyy.MM.dd")

    '                    l_ztb = New Connect2SapEx.Str_PhieuXuatTable

    '                    '  Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

    '                    'If mdlSyncDeliveries_DoListAuto(l_ztb, g_SapConnectionString, i_date, i_dateTo,
    '                    '                                      g_ShPoint, g_TimeOut, p_DataTable,
    '                    '                                      p_Err) = False Then

    '                    '    'SaveLog("Error: SAP to HTTG", p_Err, "")

    '                    '    'GoTo Line_KT


    '                    'End If
    '                    p_DataGrid = p_DataTable.Clone
    '                    For p_Count = 0 To p_DataTable.Rows.Count - 1

    '                        If Check_SoLenh(p_Err, p_DataTable.Rows(p_Count).Item("Order_No").ToString.Trim) = False Then
    '                            p_Row = p_DataGrid.Select("Order_No='" & p_DataTable.Rows(p_Count).Item("Order_No").ToString.Trim & "'")
    '                            If p_Row.Length <= 0 Then
    '                                p_Datarow = p_DataGrid.NewRow
    '                                For p_Column = 0 To p_DataTable.Columns.Count - 1
    '                                    p_Datarow.Item(p_Column) = p_DataTable.Rows(p_Count).Item(p_Column)
    '                                Next
    '                                p_DataGrid.Rows.Add(p_Datarow)
    '                            End If

    '                        End If

    '                    Next

    '                    'If LenhXuatAuto(p_Date, "", g_User_ID, g_UserName, g_Company_Code,
    '                    '                         p_DataGrid, p_SQL) = False Then
    '                    '    g_JobRunng = False
    '                    '    Exit Sub

    '                    'End If


    '                End If
    '            End If
    'Line_KT:
    '            g_JobRunng = False

    '        Catch ex As Exception
    '            g_JobRunng = False
    '        End Try
    '    End Sub


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



    Public Sub GetSoLenhBomXuat()
        Dim p_SQL As String
        Dim p_Datatable, p_DatatableExe As DataTable
        Dim p_DataTableL15 As DataTable
        Dim p_SoLenh, p_LoaiHinhVanChuyen As String
        Dim p_Terminal As String
        Dim p_SQLErr As String
        Dim p_Count As Integer
        Dim p_Count_Header As Integer
        Dim p_Row_ID As Integer
        Dim p_NhietDo, p_TyTrong_15, p_SoLuongThucXuat, p_SoLuongDuXuat, p_Lit15, p_SoLuongXuat As Double

        Try


            p_SQL = "exec FPT_GetAutoLenh_Ngay"

            p_Datatable = GetDataTable(p_SQL, p_SQL)




            ' p_Datatable_Ins = p_Datatable.Clone

            '  p_Binding.DataSource = p_Datatable_Ins
            '  Me.TrueDBGrid1.DataSource = p_Binding
            p_SQLErr = ""
            If Not p_Datatable Is Nothing Then
                For p_Count_Header = p_Datatable.Rows.Count - 1 To 0 Step -1
                    p_SoLenh = p_Datatable.Rows(p_Count_Header).Item("SoLenh").ToString.Trim
                    p_LoaiHinhVanChuyen = p_Datatable.Rows(p_Count_Header).Item("MavanChuyen").ToString.Trim
                    p_Terminal = p_Datatable.Rows(p_Count_Header).Item("Client").ToString.Trim


                    'p_SQLErr = ScadarToHTTG("in", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal, True, True)



                    'p_SQLErr = p_SAP_Obj.AutoClsScadarToHTTG("in", p_SoLenh, p_LoaiHinhVanChuyen, g_Terminal, True, g_E5)

                    'If p_SoLenh = "2023289926" Then
                    '    p_SoLenh = p_SoLenh
                    'End If
                    If p_SQLErr.ToString.Trim <> "" Then
                        ' ShowMessageBox("", p_SQLErr)
                        'p_Datatable.Rows.RemoveAt(p_Count)
                    Else
                        'anhqh
                        '20160828
                        If p_MALUULUONGKE = True Then
                            p_SQLErr = "exec FPT_CapNhatLenhXuat '" & p_SoLenh & "'"
                            p_DatatableExe = GetDataTable(p_SQLErr, p_SQLErr)
                        End If



                        'anhqh
                        '20170705
                        'Cap nhạt lai L15 cho nhữg mặt hàng pha chế Intank xuất họng E5

                        'If g_INTANK_E5 = True And p_L15_RESET = False Then

                        '    p_SQL = "select a.Row_ID, a.TyTrong_15,a.SoLuongThucXuat, a.SoLuongDuXuat, " &
                        '            "dbo.FPT_ROUNDNUMBER(  (select sum(NhietDo)/sum(LuongXuat) as NhietDo from (select " &
                        '                " isnull(NhietDo,0)  *  dbo.FPT_LaySoThucXuat ( (select top 1 mavanchuyen from tbllenhXuate5 where solenh=a.solenh)  " &
                        '                " ,SoLuongThucXuat, SoLuongDuXuat,0)   as NhietDo " &
                        '                                        " ,dbo.FPT_LaySoThucXuat ( (select top 1 mavanchuyen from tbllenhXuate5 where solenh=a.solenh)  " &
                        '                " ,SoLuongThucXuat, SoLuongDuXuat,0) as LuongXuat	 " &
                        '                                     " from fpt_tbllenhxuatchitiete5_v a11 where solenh='" & p_SoLenh & "' " &
                        '                                     "  and Row_ID in (select a.row_id from FPT_tblLenhXuatChiTietE5_V  a,tblLenhXuatChiTietE5 b " &
                        '                                    " where  a.Row_ID=b.Row_ID and a.SoLenh='" & p_SoLenh & "' " &
                        '                                         " and  isnull(  b.FlagTankLine,0) =0 and   (   isnull(b.GST,0) <=0  or  ('" & IIf(True = True, "TRUE", "FALSE") & "' ='FALSE' and isnull(b.GST,0) >=0  ))  and a.MaHangHoa  in (select MaHangHoa from tblHangHoaE5)) " &
                        '                                        ") abc	 " &
                        '                                  " having sum(LuongXuat) <> 0 ),2)  as NhietDo  " &
                        '        " from FPT_tblLenhXuatChiTietE5_V  a,tblLenhXuatChiTietE5 b " &
                        '        " where  a.Row_ID=b.Row_ID and a.SoLenh='" & p_SoLenh & "' " &
                        '             " and isnull( a.TyLe_TTe ,0) <=1 and  isnull(  b.FlagTankLine,0) =0 and   (   isnull(b.GST,0) <=0  or  ('" & IIf(True = True, "TRUE", "FALSE") & "' ='FALSE' and isnull(b.GST,0) >=0  ))  and a.MaHangHoa  in (select MaHangHoa from tblHangHoaE5)"
                        '    p_Datatable = GetDataTable(p_SQL, p_SQL)
                        '    If Not p_Datatable Is Nothing Then
                        '        For p_Count = 0 To p_Datatable.Rows.Count - 1
                        '            Integer.TryParse(p_Datatable.Rows(p_Count).Item("Row_ID").ToString.Trim, p_Row_ID)
                        '            Double.TryParse(p_Datatable.Rows(p_Count).Item("NhietDo").ToString.Trim, p_NhietDo)
                        '            Double.TryParse(p_Datatable.Rows(p_Count).Item("TyTrong_15").ToString.Trim, p_TyTrong_15)
                        '            Double.TryParse(p_Datatable.Rows(p_Count).Item("SoLuongThucXuat").ToString.Trim, p_SoLuongThucXuat)
                        '            Double.TryParse(p_Datatable.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim, p_SoLuongDuXuat)



                        '            If UCase(p_LoaiHinhVanChuyen) = "THUY" Then

                        '                If p_TONGDUXUATTHUY = "1" Then   'Lay theo du xuat
                        '                    p_SoLuongXuat = p_SoLuongDuXuat
                        '                Else   'Lay theo thuc xuat

                        '                    p_SoLuongXuat = p_SoLuongThucXuat
                        '                End If
                        '            Else

                        '                If p_TONGDUXUAT = "1" Then   'Lay theo du xuat

                        '                    p_SoLuongXuat = p_SoLuongDuXuat
                        '                Else   'Lay theo thuc xuat

                        '                    p_SoLuongXuat = p_SoLuongThucXuat
                        '                End If
                        '            End If
                        '            p_SQL = "exec dbo.zzFPT_mdlQCI_CalculateQCI_NS_QC " &
                        '                          p_SoLuongXuat & "," &
                        '                          "'L'," &
                        '                          p_NhietDo & "," & p_TyTrong_15 & ",'','' "
                        '            p_DataTableL15 = GetDataTable(p_SQL, p_SQL)

                        '            ' p_Vcf = ""
                        '            p_Lit15 = 0

                        '            If Not p_DataTableL15 Is Nothing Then
                        '                If p_DataTableL15.Rows.Count > 0 Then
                        '                    Double.TryParse(p_DataTableL15.Rows(0).Item(1).ToString.Trim, p_Lit15)

                        '                End If
                        '            End If
                        '            Try
                        '                p_Lit15 = NhietDoLamTron(p_Lit15, 0)
                        '            Catch ex As Exception

                        '            End Try

                        '            p_SQL = "update  tblLenhXuatChiTietE5 set    GST = " & p_Lit15 & " where Row_ID=" & p_Row_ID
                        '            If Sys_Execute(p_SQL,
                        '                                  p_SQLErr) = False Then
                        '                'ShowMessageBox("", p_SQLErr)
                        '            End If
                        '        Next
                        '    End If


                        'End If



                        p_SQLErr = "update tblLenhXuatE5 set Status='31' where solenh= '" & p_SoLenh & "'"
                        If Sys_Execute(p_SQLErr,
                                                      p_SQLErr) = False Then

                        End If

                        p_SQL = "exec FPT_UPDATE_GVE '" & p_SoLenh & "'"
                        If Sys_Execute(p_SQL,
                                                      p_SQL) = False Then
                            'ShowMessageBox("", p_SQLErr)
                        End If



                        p_SQL = "update tbllenhxuatchitiete5  set GST_TDH =GST " &
                             "  where row_ID in (select row_id from fpt_tbllenhxuatchitiete5_v where solenh ='" & p_SoLenh & "')"
                        If Sys_Execute(p_SQL,
                                                      p_SQL) = False Then
                            'ShowMessageBox("", p_SQLErr)
                        End If



                        p_SQL = "exec FPT_TinhL15_Intank '" & p_SoLenh & "'"
                        If Sys_Execute(p_SQL,
                                                      p_SQL) = False Then
                            'ShowMessageBox("", p_SQLErr)
                        End If
                        ''========================================================================

                    End If

                Next
            End If
        Catch ex As Exception
            SaveLog("GetSoLenhBomXuat: " & p_SoLenh.ToString.Trim & " - ", ex.Message, "")
        End Try

    End Sub




    Public Function NhietDoLamTron(p_Value As Double, Optional p_Digits As Integer = 0) As Decimal

        Dim p_NhietDo As Decimal

        Dim p_NhietDo1 As Decimal

        Dim p_Table As DataTable
        Dim p_SQL As String


        Decimal.TryParse(p_Value.ToString.Trim, p_NhietDo)
        ' NhietDoLamTron = Math.Round(p_NhietDo, p_Digits, MidpointRounding.AwayFromZero)

        Double.TryParse(p_Value.ToString.Trim, p_NhietDo1)

        NhietDoLamTron = 0

        p_SQL = "select dbo.FPT_ROUNDNUMBER (" & p_NhietDo1 & "," & p_Digits & ") as nValue"
        p_Table = GetDataTable(p_SQL, p_SQL)
        Try
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    ' NhietDoLamTron = p_Table.Rows(0).Item(0)
                    Double.TryParse(p_Table.Rows(0).Item(0).ToString.Trim, NhietDoLamTron)

                End If
            End If
        Catch ex As Exception

        End Try

        If NhietDoLamTron <= 0 Then
            NhietDoLamTron = Math.Round(p_NhietDo1, p_Digits, MidpointRounding.AwayFromZero)
        End If

    End Function


End Module
