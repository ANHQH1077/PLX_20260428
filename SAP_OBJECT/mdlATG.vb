Imports Newtonsoft.Json.Linq
Imports System.ServiceModel

Imports System.Net
Imports System.IO

Module mdlATG

    Private g_TableConfigATGLine As DataTable
    Private g_TableConfigATGHeader As DataTable



    Private g_TableTank As DataTable

    Private g_ProdLevelField As String = "ProdLevel"
    Private g_ProdTempField As String = "ProdTemp"
    Private g_DateTimeField As String = "Datetime"
    Private g_TankATGField As String = "Be"



    Private Sub GetProdFieldName()
        Dim p_Value As String
        Dim p_SQL As String
        Dim p_datatale As DataTable
        p_SQL = "Select ProdLevel, ProdTemp, Datetime, TankId from tblATGConfig"
        p_datatale = GetDataTable(p_SQL, p_SQL)
        If Not p_datatale Is Nothing Then
            If p_datatale.Rows.Count > 0 Then
                If p_datatale.Rows(0).Item("ProdLevel").ToString.Trim <> "" Then
                    g_ProdLevelField = p_datatale.Rows(0).Item("ProdLevel").ToString.Trim
                End If
                If p_datatale.Rows(0).Item("ProdTemp").ToString.Trim <> "" Then
                    g_ProdTempField = p_datatale.Rows(0).Item("ProdTemp").ToString.Trim
                End If
                If p_datatale.Rows(0).Item("Datetime").ToString.Trim <> "" Then
                    g_DateTimeField = p_datatale.Rows(0).Item("Datetime").ToString.Trim
                End If

                If p_datatale.Rows(0).Item("TankId").ToString.Trim <> "" Then
                    g_TankATGField = p_datatale.Rows(0).Item("TankId").ToString.Trim
                End If

            End If
        End If
    End Sub

    Public Sub GetTankATG_Search(ByVal p_datetime As DateTime, ByRef p_error As Boolean, ByRef p_DesError As String, _
                                 ByVal p_TankList As String, ByRef p_ProdLevel As Double, ByRef p_ProdTemp As Double, ByVal p_DateTimeATG As DateTime)
        Dim p_Check As Boolean = False
        Dim p_Dataset As DataSet
        Dim p_SQL As String
        Dim p_TableExec As New DataTable("TblExe")
        Dim p_Row As DataRow
        Dim p_Count As Integer
        'Dim p_ProdLevel As Double
        Dim p_ConnectATG As String = ""
        Dim p_ATG_IP As String = ""
        Dim p_TableATG As String = ""
        Dim p_Table As DataTable
        Dim p_ATG_USER As String = ""
        Dim p_ATG_PASS As String = ""
        Dim p_ATG_DBNAME As String = ""
        Dim TankListATG = ""
        p_SQL = " select (SELECT ','+  Map_SAP  FROM tblTank  as ST1	 where charindex (Name_nd,  '" & p_TankList & "',1) >0   " & _
            "  ORDER BY ST1.Name_nd   FOR XML PATH ('')    ) as TankList"

        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                TankListATG = p_Table.Rows(0).Item(0).ToString.Trim
            End If
        End If


        p_SQL = "select KeyValue from sys_config where KeyCode ='ATG_IP'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_ATG_IP = p_Table.Rows(0).Item(0).ToString.Trim
            End If
        End If

        p_SQL = "select KeyValue from sys_config where KeyCode ='ATG_USER'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_ATG_USER = p_Table.Rows(0).Item(0).ToString.Trim
            End If
        End If

        p_SQL = "select KeyValue from sys_config where KeyCode ='ATG_PASS'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_ATG_PASS = p_Table.Rows(0).Item(0).ToString.Trim
            End If
        End If
        p_SQL = "select KeyValue from sys_config where KeyCode ='ATG_TABLE'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_TableATG = p_Table.Rows(0).Item(0).ToString.Trim
            End If
        End If

        p_SQL = "select KeyValue from sys_config where KeyCode ='ATG_DBNAME'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_ATG_DBNAME = p_Table.Rows(0).Item(0).ToString.Trim
            End If
        End If
        If p_ATG_IP = "" Or p_ATG_DBNAME = "" Or p_ATG_PASS = "" Or p_ATG_USER = "" Then
            p_ConnectATG = ""
        Else
            p_ConnectATG = "Provider=SQLOLEDB;Data Source=" & p_ATG_IP & ";Persist Security Info=True;User ID=" & _
                p_ATG_USER & ";Password=" & p_ATG_PASS & ";Initial Catalog=" & p_ATG_DBNAME & ";Connect Timeout=300"
        End If


        If p_ConnectATG = "" Then
            p_DesError = "Thông tin kết n ATG không xác định"
            p_error = True
            Exit Sub
        End If

        Try

            'p_TankList


            ' mdlSynATG(p_Client, p_datetime, p_ConnectATG, p_TableATG, TankListATG)
            mdlSynATGSearch(p_datetime, p_ConnectATG, p_TableATG, TankListATG, p_ProdLevel, p_ProdTemp, p_DateTimeATG)

            Exit Sub
        Catch ex As Exception
            p_error = True
            p_DesError = ex.Message
        End Try

    End Sub



    Public Sub mdlSynATGSearch(ByVal p_date As DateTime, ByVal p_ConnectATG As String, ByVal p_TableATG As String, ByVal p_TankList As String, _
                               ByRef ProdLevel As Double, ByRef ProdTemp As Double, ByRef p_DateTime As DateTime)
        Dim p_SQL As String


        Dim p_Count As Integer
        Dim p_ATG_Upper = New DataTable
        Dim p_ATG_Lower = New DataTable
        Dim p_ATG_Tmp = New DataTable

        Dim p_ATG_Upper_Row() As DataRow
        Dim p_ATG_Lower_Row() As DataRow
        Dim p_ATG_Tmp_Row() As DataRow

        ' Dim p_ATG_LowerTmp = New DataTable
        Dim p_DateUpper As DateTime
        Dim p_DateLower As DateTime
        Dim p_Upper As Boolean = False
        Dim p_Lower As Boolean = False
        Dim p_Row_Upper As DataRow
        Dim p_RowLower As DataRow
        Dim p_DesError As String = ""

        Dim p_SourceTableATG As DataTable
        Dim p_RowATG As DataRow
        Try
            ProdLevel = 0
            ProdTemp = 0
            '  If Not g_TableTank Is Nothing Then
            If g_Company_Code <> "6610" Then
                ''''Ngoai tru KV2 cac kho khac chayj theo ham moi duoc cau hinh field cua ATG
                mdlSynATGSearch_MapNew(p_date, p_ConnectATG, p_TableATG, p_TankList, _
                                ProdLevel, ProdTemp, p_DateTime)
                Exit Sub
            End If

            If p_TankList.ToString.Trim <> "" Then
                p_SQL = " select * from " & p_TableATG & "  with (nolock)  where Datetime <= dateadd(Hour,+2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  " & _
                    " and Datetime >= dateadd(Hour,-2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  and charindex (tankID,  '" & p_TankList & "',1) >0 " ' and client  ='" & p_Client & "'"

            Else
                p_SQL = " select * from " & p_TableATG & "  with (nolock)  where Datetime <= dateadd(Hour,+2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  " & _
                                        " and Datetime >= dateadd(Hour,-2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  "

            End If
            p_SourceTableATG = g_Services.GET_DATATABLE_With_Connect_Des(p_ConnectATG, p_SQL, p_DesError)

            '  For p_Count = 0 To g_TableTank.Rows.Count - 1

            p_Lower = False
            p_Upper = False
            p_ATG_Lower_Row = p_SourceTableATG.Select("Datetime <='" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "'", "datetime desc")
            If p_ATG_Lower_Row.Length > 0 Then
                p_Lower = True
            End If

            p_ATG_Upper_Row = p_SourceTableATG.Select("Datetime >='" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "'", "datetime asc")
            If p_ATG_Upper_Row.Length > 0 Then
                p_Upper = True
            End If

            If p_Upper = False And p_Lower = False Then
                Exit Sub
            End If

            If p_Lower = False And p_Upper = True Then

                ProdLevel = p_ATG_Upper_Row(0).Item("ProdLevel") ' p_ATG_Tmp.Rows(0).Item("ProdLevel")
                ProdTemp = p_ATG_Upper_Row(0).Item("ProdTemp") '  p_ATG_Tmp.Rows(0).Item("ProdTemp")
                p_DateTime = p_ATG_Upper_Row(0).Item("Datetime")
                Exit Sub
            End If

            If p_Lower = True And p_Upper = False Then

                ProdLevel = p_ATG_Lower_Row(0).Item("ProdLevel") ' p_ATG_Tmp.Rows(0).Item("ProdLevel")
                ProdTemp = p_ATG_Lower_Row(0).Item("ProdTemp") '  p_ATG_Tmp.Rows(0).Item("ProdTemp")
                p_DateTime = p_ATG_Lower_Row(0).Item("Datetime")

                Exit Sub
            End If
            p_Row_Upper = Nothing
            p_RowLower = Nothing
            If p_Lower = True And p_Upper = True Then


                'p_SQL = "select case when DateUpper - CurrentDate >  CurrentDate -DateLower  then 1 else 0 end  as nValue  from  ( "
                'p_SQL = p_SQL & "select convert(datetime,'" & p_RowLower.Item("DateTime") & "')  as DateLower,  convert(datetime,'" & p_Row_Upper.Item("DateTime") & "')  as DateUpper " & _
                '            ", convert(datetime,'" & p_date & "')  as CurrentDate ) anhqh "
                p_SQL = "select case when DateUpper - CurrentDate >  CurrentDate -DateLower  then 1 else 0 end  as nValue  from  ( "
                p_SQL = p_SQL & "select convert(datetime,'" & p_ATG_Lower_Row(0).Item("DateTime") & "')  as DateLower,  convert(datetime,'" & p_ATG_Upper_Row(0).Item("DateTime") & "')  as DateUpper " & _
                            ", convert(datetime,'" & p_date & "')  as CurrentDate ) anhqh "

                p_ATG_Tmp = GetDataTable(p_SQL, p_SQL)
                If Not p_ATG_Tmp Is Nothing Then
                    If p_ATG_Tmp.Rows.Count > 0 Then
                        If p_ATG_Tmp.Rows(0).Item(0) = 1 Then   'Lay giá trị theo tiẹm cận dưới
                            ProdLevel = p_ATG_Lower_Row(0).Item("ProdLevel")
                            ProdTemp = p_ATG_Lower_Row(0).Item("ProdTemp")
                            p_DateTime = p_ATG_Lower_Row(0).Item("Datetime")
                        ElseIf p_ATG_Tmp.Rows(0).Item(0) = 0 Then  'Lay giá trị theo tiẹm cận trên
                            ProdLevel = p_ATG_Upper_Row(0).Item("ProdLevel")
                            ProdTemp = p_ATG_Upper_Row(0).Item("ProdTemp")
                            p_DateTime = p_ATG_Upper_Row(0).Item("Datetime")
                        End If
                    End If
                End If
                ' Continue For
            End If
            ' Next
            ' End If



        Catch ex As Exception
            p_SQL = ex.Message
        End Try


    End Sub



    Public Sub mdlSynATGSearch_MapNew(ByVal p_date As DateTime, ByVal p_ConnectATG As String, ByVal p_TableATG As String, ByVal p_TankList As String, _
                               ByRef ProdLevel As Double, ByRef ProdTemp As Double, ByRef p_DateTime As DateTime)
        Dim p_SQL As String


        Dim p_Count As Integer
        Dim p_ATG_Upper = New DataTable
        Dim p_ATG_Lower = New DataTable
        Dim p_ATG_Tmp = New DataTable

        Dim p_ATG_Upper_Row() As DataRow
        Dim p_ATG_Lower_Row() As DataRow
        Dim p_ATG_Tmp_Row() As DataRow

        ' Dim p_ATG_LowerTmp = New DataTable
        Dim p_DateUpper As DateTime
        Dim p_DateLower As DateTime
        Dim p_Upper As Boolean = False
        Dim p_Lower As Boolean = False
        Dim p_Row_Upper As DataRow
        Dim p_RowLower As DataRow
        Dim p_DesError As String = ""

        Dim p_SourceTableATG As DataTable
        Dim p_RowATG As DataRow
        Try
            ProdLevel = 0
            ProdTemp = 0
            '  If Not g_TableTank Is Nothing Then
            GetProdFieldName()
            If p_TankList.ToString.Trim <> "" Then
                p_SQL = " select * from " & p_TableATG & "  with (nolock)  where Datetime <= dateadd(Hour,+2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  " & _
                    " and Datetime >= dateadd(Hour,-2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  and charindex (tankID,  '" & p_TankList & "',1) >0 " ' and client  ='" & p_Client & "'"

            Else
                p_SQL = " select * from " & p_TableATG & "  with (nolock)  where Datetime <= dateadd(Hour,+2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  " & _
                                        " and Datetime >= dateadd(Hour,-2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  "

            End If
            p_SourceTableATG = g_Services.GET_DATATABLE_With_Connect_Des(p_ConnectATG, p_SQL, p_DesError)

            '  For p_Count = 0 To g_TableTank.Rows.Count - 1

            p_Lower = False
            p_Upper = False
            p_ATG_Lower_Row = p_SourceTableATG.Select("Datetime <='" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "'", "datetime desc")
            If p_ATG_Lower_Row.Length > 0 Then
                p_Lower = True
            End If

            p_ATG_Upper_Row = p_SourceTableATG.Select("Datetime >='" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "'", "datetime asc")
            If p_ATG_Upper_Row.Length > 0 Then
                p_Upper = True
            End If

            If p_Upper = False And p_Lower = False Then
                Exit Sub
            End If

            If p_Lower = False And p_Upper = True Then

                ProdLevel = p_ATG_Upper_Row(0).Item(g_ProdLevelField) ' p_ATG_Tmp.Rows(0).Item("ProdLevel")
                ProdTemp = p_ATG_Upper_Row(0).Item(g_ProdTempField) '  p_ATG_Tmp.Rows(0).Item("ProdTemp")
                p_DateTime = p_ATG_Upper_Row(0).Item(g_DateTimeField)
                Exit Sub
            End If

            If p_Lower = True And p_Upper = False Then

                ProdLevel = p_ATG_Lower_Row(0).Item(g_ProdLevelField) ' p_ATG_Tmp.Rows(0).Item("ProdLevel")
                ProdTemp = p_ATG_Lower_Row(0).Item(g_ProdTempField) '  p_ATG_Tmp.Rows(0).Item("ProdTemp")
                p_DateTime = p_ATG_Lower_Row(0).Item(g_DateTimeField)

                Exit Sub
            End If
            p_Row_Upper = Nothing
            p_RowLower = Nothing
            If p_Lower = True And p_Upper = True Then


                'p_SQL = "select case when DateUpper - CurrentDate >  CurrentDate -DateLower  then 1 else 0 end  as nValue  from  ( "
                'p_SQL = p_SQL & "select convert(datetime,'" & p_RowLower.Item("DateTime") & "')  as DateLower,  convert(datetime,'" & p_Row_Upper.Item("DateTime") & "')  as DateUpper " & _
                '            ", convert(datetime,'" & p_date & "')  as CurrentDate ) anhqh "
                p_SQL = "select case when DateUpper - CurrentDate >  CurrentDate -DateLower  then 1 else 0 end  as nValue  from  ( "
                p_SQL = p_SQL & "select convert(datetime,'" & p_ATG_Lower_Row(0).Item("DateTime") & "')  as DateLower,  convert(datetime,'" & p_ATG_Upper_Row(0).Item("DateTime") & "')  as DateUpper " & _
                            ", convert(datetime,'" & p_date & "')  as CurrentDate ) anhqh "

                p_ATG_Tmp = GetDataTable(p_SQL, p_SQL)
                If Not p_ATG_Tmp Is Nothing Then
                    If p_ATG_Tmp.Rows.Count > 0 Then
                        If p_ATG_Tmp.Rows(0).Item(0) = 1 Then   'Lay giá trị theo tiẹm cận dưới
                            ProdLevel = p_ATG_Lower_Row(0).Item(g_ProdLevelField)
                            ProdTemp = p_ATG_Lower_Row(0).Item(g_ProdTempField)
                            p_DateTime = p_ATG_Lower_Row(0).Item(g_DateTimeField)
                        ElseIf p_ATG_Tmp.Rows(0).Item(0) = 0 Then  'Lay giá trị theo tiẹm cận trên
                            ProdLevel = p_ATG_Upper_Row(0).Item(g_ProdLevelField)
                            ProdTemp = p_ATG_Upper_Row(0).Item(g_ProdTempField)
                            p_DateTime = p_ATG_Upper_Row(0).Item(g_DateTimeField)
                        End If
                    End If
                End If
                ' Continue For
            End If
            ' Next
            ' End If



        Catch ex As Exception
            p_SQL = ex.Message
        End Try


    End Sub



    Public Sub GetTankATG(ByVal p_PurposeCode As String, ByVal p_TankHeaderCode As String, ByVal p_Client As String, ByVal p_datetime As DateTime, ByRef p_error As Boolean, ByRef p_DesError As String, ByVal p_TankList As String)
        Dim p_Check As Boolean = False
        Dim p_Dataset As DataSet
        Dim p_SQL As String
        Dim p_TableExec As New DataTable("TblExe")
        Dim p_Row As DataRow
        Dim p_Count As Integer
        Dim p_ProdLevel As Double
        Dim p_ConnectATG As String = ""
        Dim p_ATG_IP As String = ""
        Dim p_TableATG As String = ""
        Dim p_Table As DataTable
        Dim p_ATG_USER As String = ""
        Dim p_ATG_PASS As String = ""
        Dim p_ATG_DBNAME As String = ""
        Dim TankListATG = ""
        Dim p_Filter_Terminal As Boolean = False
        Dim p_TANK_GROUP As Boolean = False


        p_SQL = "select KEYVALUE  from sys_config  where UPPER (Keycode) ='TANK_GROUP' "
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    p_TANK_GROUP = True
                End If
            End If
        End If



        p_SQL = "select * from sys_Config where upper( KeyCode)='FILTERKHO'  "
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    p_Filter_Terminal = True
                End If
            End If
        End If

        If p_Filter_Terminal = True Then
            p_SQL = " select (SELECT ','+  Map_SAP  FROM tblTank  as ST1	 where charindex (Name_nd,  '" & p_TankList & "',1) >0   " & _
           "  ORDER BY ST1.Name_nd   FOR XML PATH ('')    ) as TankList"

            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    TankListATG = p_Table.Rows(0).Item(0).ToString.Trim
                End If
            End If
        Else
            If p_TankList = "" Then
                p_SQL = " select (SELECT ','+  Map_SAP  FROM tblTank  as ST1  " & _
                        "  ORDER BY ST1.Name_nd   FOR XML PATH ('')    ) as TankList"
                p_Table = GetDataTable(p_SQL, p_SQL)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        TankListATG = p_Table.Rows(0).Item(0).ToString.Trim
                    End If
                End If
            Else
                p_SQL = " select (SELECT ','+  Map_SAP  FROM tblTank  as ST1	 where charindex (Name_nd,  '" & p_TankList & "',1) >0   " & _
                          "  ORDER BY ST1.Name_nd   FOR XML PATH ('')    ) as TankList"
                p_Table = GetDataTable(p_SQL, p_SQL)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        TankListATG = p_Table.Rows(0).Item(0).ToString.Trim
                    End If
                End If
            End If
        End If
       


        p_SQL = "select KeyValue from sys_config where KeyCode ='ATG_IP'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_ATG_IP = p_Table.Rows(0).Item(0).ToString.Trim
            End If
        End If

        p_SQL = "select KeyValue from sys_config where KeyCode ='ATG_USER'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_ATG_USER = p_Table.Rows(0).Item(0).ToString.Trim
            End If
        End If

        p_SQL = "select KeyValue from sys_config where KeyCode ='ATG_PASS'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_ATG_PASS = p_Table.Rows(0).Item(0).ToString.Trim
            End If
        End If
        p_SQL = "select KeyValue from sys_config where KeyCode ='ATG_TABLE'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_TableATG = p_Table.Rows(0).Item(0).ToString.Trim
            End If
        End If

        p_SQL = "select KeyValue from sys_config where KeyCode ='ATG_DBNAME'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_ATG_DBNAME = p_Table.Rows(0).Item(0).ToString.Trim
            End If
        End If
        If p_ATG_IP = "" Or p_ATG_DBNAME = "" Or p_ATG_PASS = "" Or p_ATG_USER = "" Then
            p_ConnectATG = ""
        Else
            p_ConnectATG = "Provider=SQLOLEDB;Data Source=" & p_ATG_IP & ";Persist Security Info=True;User ID=" & _
                p_ATG_USER & ";Password=" & p_ATG_PASS & ";Initial Catalog=" & p_ATG_DBNAME & ";Connect Timeout=300"
        End If


        If p_ConnectATG = "" And g_Company_Code <> "2610" Then
            p_DesError = "Thông tin kết n ATG không xác định"
            p_error = True
            Exit Sub
        End If

        Try

            'p_TankList

            p_error = False
            If p_Filter_Terminal = False Then
                p_Client = ""
            End If
            If p_TankList.ToString.Trim <> "" Then
                If p_Client <> "" Then
                    p_SQL = "SELECT  getdate() as DateTime, '" & p_TankHeaderCode & "' as TankHeaderCode,( select top 1 Map_Sap  from tblTank b  where Name_nd = a.TankCode) as  TankCode " & _
                                ",[Product],[CrDate] ,[CrUser],[Client], 0*1000.22 as ProdLevel, 0*35.4111 as ProdTemp, a.TankCode as TankCode_HTTG, 0.0 as WaterHeight  FROM [zTankListATG] a where TankCode like '" & p_Client & "%' " & _
                                 "  and charindex (rtrim(a.TankCode),'" & p_TankList & "',1) >0 "
                Else
                    p_SQL = "SELECT  getdate() as DateTime,'" & p_TankHeaderCode & "' as TankHeaderCode, ( select top 1  Map_Sap  from tblTank b  where Name_nd = a.TankCode)  TankCode " & _
                                ",[Product],[CrDate] ,[CrUser],[Client],  0*1000.22 as ProdLevel, 0*35.4111 as ProdTemp, a.TankCode as TankCode_HTTG , 0.0 as WaterHeight FROM [zTankListATG]  a" & _
                                "  where  charindex (rtrim(a.TankCode),'" & p_TankList & "',1) >0 "
                End If
            Else
                If p_Client <> "" Then
                    p_SQL = "SELECT  getdate() as DateTime, '" & p_TankHeaderCode & "' as TankHeaderCode,( select top 1 Map_Sap  from tblTank b  where Name_nd = a.TankCode) as  TankCode " & _
                                ",[Product],[CrDate] ,[CrUser],[Client], 0*1000.22 as ProdLevel, 0*35.4111 as ProdTemp, a.TankCode as TankCode_HTTG, 0.0 as WaterHeight  FROM [zTankListATG] a where TankCode like '" & p_Client & "%' "
                Else
                    p_SQL = "SELECT  getdate() as DateTime,'" & p_TankHeaderCode & "' as TankHeaderCode, ( select top 1  Map_Sap  from tblTank b  where Name_nd = a.TankCode)  TankCode " & _
                                ",[Product],[CrDate] ,[CrUser],[Client],  0*1000.22 as ProdLevel, 0*35.4111 as ProdTemp, a.TankCode as TankCode_HTTG, 0.0 as WaterHeight FROM [zTankListATG]  a  where 1=1 "
                End If

                p_SQL = p_SQL & " and  not exists (select 1  from dbo.zTankListATG_AM  h  where  '" & CDate(p_datetime).ToString("yyyyMMdd HH:mm:ss") & "' >=   isnull(FROMDATE,getdate()-5) " & _
                             " and '" & CDate(p_datetime).ToString("yyyyMMdd HH:mm:ss") & "'  <= isnull(ToDATE,getdate()+5)  and h.TankCode =a.TankCode ) "

                p_SQL = p_SQL & " and  not exists (select 1  from dbo.zTankListATG_M  h  where  '" & CDate(p_datetime).ToString("yyyyMMdd HH:mm:ss") & "' >=   isnull(FROMDATE,getdate()-5) " & _
                              " and '" & CDate(p_datetime).ToString("yyyyMMdd HH:mm:ss") & "'  <= isnull(ToDATE,getdate()+5)  and h.TankCode =a.TankCode ) "
            End If




            g_TableTank = GetDataTable(p_SQL, p_SQL) 'g_Services.GET_DATATABLE_With_Connect_Des(p_ConnectATG, p_SQL,  p_DesError)


            mdlSynATG(p_Client, p_datetime, p_ConnectATG, p_TableATG, TankListATG)

            If Not g_TableTank Is Nothing Then
                p_TableExec.Columns.Add("STR_SQL")
                For p_Count = 0 To g_TableTank.Rows.Count - 1
                    Double.TryParse(g_TableTank.Rows(p_Count).Item("ProdLevel").ToString.Trim, p_ProdLevel)
                    ' If p_ProdLevel > 0 Then

                    If p_TANK_GROUP = True Then  'Nhom be 20250106
                        p_SQL = "MERGE ztblTankLineImp AS target USING (" & _
                                " select '" & p_PurposeCode & "' as PurposeCode , left('" & g_TableTank.Rows(p_Count).Item("TankCode").ToString.Trim & "',1) as Client ,'" & CDate(g_TableTank.Rows(p_Count).Item("DateTime")).ToString("yyyy-MM-dd hh:mm:ss tt") & "' as CrDate" & _
                                    ",'" & g_TableTank.Rows(p_Count).Item("TankCode_HTTG").ToString.Trim & "' as TankCode" & _
                                     ",'" & g_TableTank.Rows(p_Count).Item("Product").ToString.Trim & "' as ProductCode" & _
                                     "," & g_TableTank.Rows(p_Count).Item("ProdLevel").ToString.Trim & " as TankHeight" & _
                                      "," & g_TableTank.Rows(p_Count).Item("ProdTemp").ToString.Trim & " as TankTemp" & _
                                       "," & g_TableTank.Rows(p_Count).Item("WaterHeight").ToString.Trim & " as WaterHeight" & _
                                      ",getdate() as SynDate " & _
                                      ",'" & g_UserName & "' as SynUser " & _
                                       ",'" & p_TankHeaderCode & "' as TankHeaderCode,(select top 1 TankGroup  from tblTankGroup where  getdate() >=  FromDate  and getdate ()  <= ToDate  and Name_nd = '" & g_TableTank.Rows(p_Count).Item("TankCode_HTTG").ToString.Trim & "' ) as  TankGroup " & _
                                    ") AS source ON (target.PurposeCode = source.PurposeCode and target.TankCode = source.TankCode  and  target.TankHeaderCode ='" & p_TankHeaderCode & "')   "
                        p_SQL = p_SQL & " WHEN NOT MATCHED   then " & _
                                    " INSERT  (PurposeCode, Client, CrDate,TankCode,ProductCode,TankHeight,TankTemp,SynDate,SynUser, TankHeaderCode,WaterHeight, NhomBeXuat) " & _
                                    " VALUES (source.PurposeCode, source.Client, source.CrDate,source.TankCode,source.ProductCode,source.TankHeight,source.TankTemp,source.SynDate,source.SynUser, source.TankHeaderCode, source.WaterHeight, source.TankGroup );"
                    Else

                        p_SQL = "MERGE ztblTankLineImp AS target USING (" & _
                                " select '" & p_PurposeCode & "' as PurposeCode , left('" & g_TableTank.Rows(p_Count).Item("TankCode").ToString.Trim & "',1) as Client ,'" & CDate(g_TableTank.Rows(p_Count).Item("DateTime")).ToString("yyyy-MM-dd hh:mm:ss tt") & "' as CrDate" & _
                                    ",'" & g_TableTank.Rows(p_Count).Item("TankCode_HTTG").ToString.Trim & "' as TankCode" & _
                                     ",'" & g_TableTank.Rows(p_Count).Item("Product").ToString.Trim & "' as ProductCode" & _
                                     "," & g_TableTank.Rows(p_Count).Item("ProdLevel").ToString.Trim & " as TankHeight" & _
                                      "," & g_TableTank.Rows(p_Count).Item("ProdTemp").ToString.Trim & " as TankTemp" & _
                                       "," & g_TableTank.Rows(p_Count).Item("WaterHeight").ToString.Trim & " as WaterHeight" & _
                                      ",getdate() as SynDate " & _
                                      ",'" & g_UserName & "' as SynUser " & _
                                       ",'" & p_TankHeaderCode & "' as TankHeaderCode " & _
                                    ") AS source ON (target.PurposeCode = source.PurposeCode and target.TankCode = source.TankCode  and  target.TankHeaderCode ='" & p_TankHeaderCode & "')   "
                        p_SQL = p_SQL & " WHEN NOT MATCHED   then " & _
                                    " INSERT  (PurposeCode, Client, CrDate,TankCode,ProductCode,TankHeight,TankTemp,SynDate,SynUser, TankHeaderCode,WaterHeight) " & _
                                    " VALUES (source.PurposeCode, source.Client, source.CrDate,source.TankCode,source.ProductCode,source.TankHeight,source.TankTemp,source.SynDate,source.SynUser, source.TankHeaderCode, source.WaterHeight);"

                    End If
                    p_Row = p_TableExec.NewRow

                    p_Row.Item(0) = p_SQL

                    p_TableExec.Rows.Add(p_Row)

                    ' End If
                Next


                If p_TableExec.Rows.Count > 0 Then
                    ' If p_TblExe.Rows.Count > 0 Then
                    p_SQL = ""
                    If g_Services.Sys_Execute_DataTbl(p_TableExec, _
                                                   p_SQL) = False Then

                    End If
                    'End If
                End If


            End If


            Exit Sub
        Catch ex As Exception
            p_error = True
            p_DesError = ex.Message
        End Try


        'p_SQL = "SELECT  [ID],[FromField] ,[ToField] ,[FieldType] ,[FieldKey] ,[CrDate],[UpdDate]," & _
        '         "[UpdUser],[Client] FROM [ztblConfigATGLine]"
        ''p_SQL = p_SQL & "SELECT [ID],[FromTable],[ToTable],[ServerIP] ,[DBName] ,[sPort] ,[sUser],[sPass] FROM [ztblConfigATGHeader] ;"
        'If Not g_TableConfigATGLine Is Nothing Then
        '    If g_TableConfigATGLine.Rows.Count > 0 Then
        '        p_Check = True
        '    End If
        'End If
        'If p_Check = False Then
        '    p_SQL = "SELECT  [ID],[FromField] ,[ToField] ,[FieldType] ,[FieldKey] ,[CrDate],[UpdDate]," & _
        '         "[UpdUser],[Client] FROM [ztblConfigATGLine]"
        '    g_TableConfigATGLine = GetDataTable(p_SQL, p_SQL)


        '    p_SQL = "SELECT [ID],[FromTable],[ToTable],[ServerIP] ,[DBName] ,[sPort] ,[sUser],[sPass] FROM [ztblConfigATGHeader]"
        '    g_TableConfigATGHeader = GetDataTable(p_SQL, p_SQL)
        'End If
    End Sub

    Public Sub mdlSynATG(ByVal p_Client As String, ByVal p_date As DateTime, ByVal p_ConnectATG As String, ByVal p_TableATG As String, ByVal p_TankList As String)
        Dim p_SQL As String


        Dim p_Count As Integer
        Dim p_ATG_Upper = New DataTable
        Dim p_ATG_Lower = New DataTable
        Dim p_ATG_Tmp = New DataTable

        Dim p_ATG_Upper_Row() As DataRow
        Dim p_ATG_Lower_Row() As DataRow
        Dim p_ATG_Tmp_Row() As DataRow

        ' Dim p_ATG_LowerTmp = New DataTable
        Dim p_DateUpper As DateTime
        Dim p_DateLower As DateTime
        Dim p_Upper As Boolean = False
        Dim p_Lower As Boolean = False
        Dim p_Row_Upper As DataRow
        Dim p_RowLower As DataRow
        Dim p_DesError As String = ""

        Dim p_SourceTableATG As DataTable
        Dim p_RowATG As DataRow
        Try
            If g_Company_Code <> "6610" Then
                ''''Ngoai tru KV2 cac kho khac chayj theo ham moi duoc cau hinh field cua ATG
                mdlSynATG_MapNew(p_Client, p_date, p_ConnectATG, p_TableATG, p_TankList)
                Exit Sub
            End If
            If Not g_TableTank Is Nothing Then

                If p_TankList.ToString.Trim <> "" Then
                    p_SQL = " select * from " & p_TableATG & "  with (nolock)  where Datetime <= dateadd(Hour,+2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  " & _
                        " and Datetime >= dateadd(Hour,-2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  and charindex (tankID,  '" & p_TankList & "',1) >0 " ' and client  ='" & p_Client & "'"

                Else
                    p_SQL = " select * from " & p_TableATG & "  with (nolock)  where Datetime <= dateadd(Hour,+2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  " & _
                                            " and Datetime >= dateadd(Hour,-2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  "

                End If
                p_SourceTableATG = g_Services.GET_DATATABLE_With_Connect_Des(p_ConnectATG, p_SQL, p_DesError)

                For p_Count = 0 To g_TableTank.Rows.Count - 1

                    p_Lower = False
                    p_Upper = False
                    p_ATG_Lower_Row = p_SourceTableATG.Select("Datetime <='" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' and  tankid ='" & g_TableTank.Rows(p_Count).Item("TankCode").ToString.Trim & "'", "datetime desc")
                    If p_ATG_Lower_Row.Length > 0 Then
                        p_Lower = True
                    End If

                    p_ATG_Upper_Row = p_SourceTableATG.Select("Datetime >='" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' and  tankid ='" & g_TableTank.Rows(p_Count).Item("TankCode").ToString.Trim & "'", "datetime asc")
                    If p_ATG_Upper_Row.Length > 0 Then
                        p_Upper = True
                    End If

                    If p_Upper = False And p_Lower = False Then
                        Continue For
                    End If

                    If p_Lower = False And p_Upper = True Then

                        g_TableTank.Rows(p_Count).Item("ProdLevel") = p_ATG_Upper_Row(0).Item("ProdLevel") ' p_ATG_Tmp.Rows(0).Item("ProdLevel")
                        g_TableTank.Rows(p_Count).Item("ProdTemp") = p_ATG_Upper_Row(0).Item("ProdTemp") '  p_ATG_Tmp.Rows(0).Item("ProdTemp")
                        g_TableTank.Rows(p_Count).Item("DateTime") = p_ATG_Upper_Row(0).Item("Datetime")
                        Continue For
                    End If

                    If p_Lower = True And p_Upper = False Then

                        g_TableTank.Rows(p_Count).Item("ProdLevel") = p_ATG_Lower_Row(0).Item("ProdLevel") ' p_ATG_Tmp.Rows(0).Item("ProdLevel")
                        g_TableTank.Rows(p_Count).Item("ProdTemp") = p_ATG_Lower_Row(0).Item("ProdTemp") '  p_ATG_Tmp.Rows(0).Item("ProdTemp")
                        g_TableTank.Rows(p_Count).Item("DateTime") = p_ATG_Lower_Row(0).Item("Datetime")

                        Continue For
                    End If
                    p_Row_Upper = Nothing
                    p_RowLower = Nothing
                    If p_Lower = True And p_Upper = True Then


                        'p_SQL = "select case when DateUpper - CurrentDate >  CurrentDate -DateLower  then 1 else 0 end  as nValue  from  ( "
                        'p_SQL = p_SQL & "select convert(datetime,'" & p_RowLower.Item("DateTime") & "')  as DateLower,  convert(datetime,'" & p_Row_Upper.Item("DateTime") & "')  as DateUpper " & _
                        '            ", convert(datetime,'" & p_date & "')  as CurrentDate ) anhqh "
                        p_SQL = "select case when DateUpper - CurrentDate >  CurrentDate -DateLower  then 1 else 0 end  as nValue  from  ( "
                        p_SQL = p_SQL & "select convert(datetime,'" & p_ATG_Lower_Row(0).Item("DateTime") & "')  as DateLower,  convert(datetime,'" & p_ATG_Upper_Row(0).Item("DateTime") & "')  as DateUpper " & _
                                    ", convert(datetime,'" & p_date & "')  as CurrentDate ) anhqh "

                        p_ATG_Tmp = GetDataTable(p_SQL, p_SQL)
                        If Not p_ATG_Tmp Is Nothing Then
                            If p_ATG_Tmp.Rows.Count > 0 Then
                                If p_ATG_Tmp.Rows(0).Item(0) = 1 Then   'Lay giá trị theo tiẹm cận dưới
                                    g_TableTank.Rows(p_Count).Item("ProdLevel") = p_ATG_Lower_Row(0).Item("ProdLevel")
                                    g_TableTank.Rows(p_Count).Item("ProdTemp") = p_ATG_Lower_Row(0).Item("ProdTemp")
                                    g_TableTank.Rows(p_Count).Item("DateTime") = p_ATG_Lower_Row(0).Item("Datetime")
                                ElseIf p_ATG_Tmp.Rows(0).Item(0) = 0 Then  'Lay giá trị theo tiẹm cận trên
                                    g_TableTank.Rows(p_Count).Item("ProdLevel") = p_ATG_Upper_Row(0).Item("ProdLevel")
                                    g_TableTank.Rows(p_Count).Item("ProdTemp") = p_ATG_Upper_Row(0).Item("ProdTemp")
                                    g_TableTank.Rows(p_Count).Item("DateTime") = p_ATG_Upper_Row(0).Item("Datetime")
                                End If
                            End If
                        End If
                        Continue For
                    End If
                Next
            End If



        Catch ex As Exception
            p_SQL = ex.Message
        End Try


    End Sub



    Public Sub mdlSynATG_MapNew(ByVal p_Client As String, ByVal p_date As DateTime, ByVal p_ConnectATG As String, ByVal p_TableATG As String, ByVal p_TankList As String)
        Dim p_SQL As String


        Dim p_Count As Integer
        Dim p_ATG_Upper = New DataTable
        Dim p_ATG_Lower = New DataTable
        Dim p_ATG_Tmp = New DataTable

        Dim p_ATG_Upper_Row() As DataRow
        Dim p_ATG_Lower_Row() As DataRow
        Dim p_ATG_Tmp_Row() As DataRow

        ' Dim p_ATG_LowerTmp = New DataTable
        Dim p_DateUpper As DateTime
        Dim p_DateLower As DateTime
        Dim p_Upper As Boolean = False
        Dim p_Lower As Boolean = False
        Dim p_Row_Upper As DataRow
        Dim p_RowLower As DataRow
        Dim p_DesError As String = ""

        Dim p_SourceTableATG As DataTable
        Dim p_RowATG As DataRow
        Try

            If g_Company_Code = "2610" Then
                mdlSynATG_MapNewAPI(p_Client, p_date, p_ConnectATG, p_TableATG, p_TankList)
                Exit Sub
            End If
            GetProdFieldName()

            If Not g_TableTank Is Nothing Then

                If p_TankList.ToString.Trim <> "" Then
                    p_SQL = " select * from " & p_TableATG & "  with (nolock)  where " & g_DateTimeField & " <= dateadd(Hour,+2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  " & _
                        " and " & g_DateTimeField & "  >= dateadd(Hour,-2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  and charindex (" & g_TankATGField & ",  '" & p_TankList & "',1) >0 " ' and client  ='" & p_Client & "'"

                Else
                    p_SQL = " select * from " & p_TableATG & "  with (nolock)  where " & g_DateTimeField & "  <= dateadd(Hour,+2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  " & _
                                            " and " & g_DateTimeField & "  >= dateadd(Hour,-2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  "

                End If
                p_SourceTableATG = g_Services.GET_DATATABLE_With_Connect_Des(p_ConnectATG, p_SQL, p_DesError)

                For p_Count = 0 To g_TableTank.Rows.Count - 1

                    p_Lower = False
                    p_Upper = False
                    p_ATG_Lower_Row = p_SourceTableATG.Select("" & g_DateTimeField & " <='" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' and  " & g_TankATGField & " ='" & g_TableTank.Rows(p_Count).Item("TankCode").ToString.Trim & "'", "" & g_DateTimeField & " desc")
                    If p_ATG_Lower_Row.Length > 0 Then
                        p_Lower = True
                    End If

                    p_ATG_Upper_Row = p_SourceTableATG.Select("" & g_DateTimeField & " >='" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' and  " & g_TankATGField & "  ='" & g_TableTank.Rows(p_Count).Item("TankCode").ToString.Trim & "'", "" & g_DateTimeField & " asc")
                    If p_ATG_Upper_Row.Length > 0 Then
                        p_Upper = True
                    End If

                    If p_Upper = False And p_Lower = False Then
                        Continue For
                    End If

                    If p_Lower = False And p_Upper = True Then

                        g_TableTank.Rows(p_Count).Item("ProdLevel") = p_ATG_Upper_Row(0).Item(g_ProdLevelField) ' p_ATG_Tmp.Rows(0).Item("ProdLevel")
                        g_TableTank.Rows(p_Count).Item("ProdTemp") = p_ATG_Upper_Row(0).Item(g_ProdTempField) '  p_ATG_Tmp.Rows(0).Item("ProdTemp")
                        g_TableTank.Rows(p_Count).Item("DateTime") = p_ATG_Upper_Row(0).Item(g_DateTimeField)
                        Continue For
                    End If

                    If p_Lower = True And p_Upper = False Then

                        g_TableTank.Rows(p_Count).Item("ProdLevel") = p_ATG_Lower_Row(0).Item(g_ProdLevelField) ' p_ATG_Tmp.Rows(0).Item("ProdLevel")
                        g_TableTank.Rows(p_Count).Item("ProdTemp") = p_ATG_Lower_Row(0).Item(g_ProdTempField) '  p_ATG_Tmp.Rows(0).Item("ProdTemp")
                        g_TableTank.Rows(p_Count).Item("DateTime") = p_ATG_Lower_Row(0).Item(g_DateTimeField)

                        Continue For
                    End If
                    p_Row_Upper = Nothing
                    p_RowLower = Nothing
                    If p_Lower = True And p_Upper = True Then


                        'p_SQL = "select case when DateUpper - CurrentDate >  CurrentDate -DateLower  then 1 else 0 end  as nValue  from  ( "
                        'p_SQL = p_SQL & "select convert(datetime,'" & p_RowLower.Item("DateTime") & "')  as DateLower,  convert(datetime,'" & p_Row_Upper.Item("DateTime") & "')  as DateUpper " & _
                        '            ", convert(datetime,'" & p_date & "')  as CurrentDate ) anhqh "
                        p_SQL = "select case when DateUpper - CurrentDate >  CurrentDate -DateLower  then 1 else 0 end  as nValue  from  ( "
                        p_SQL = p_SQL & "select convert(datetime,'" & p_ATG_Lower_Row(0).Item(g_DateTimeField) & "')  as DateLower,  convert(datetime,'" & p_ATG_Upper_Row(0).Item(g_DateTimeField) & "')  as DateUpper " & _
                                    ", convert(datetime,'" & p_date & "')  as CurrentDate ) anhqh "

                        p_ATG_Tmp = GetDataTable(p_SQL, p_SQL)
                        If Not p_ATG_Tmp Is Nothing Then
                            If p_ATG_Tmp.Rows.Count > 0 Then
                                If p_ATG_Tmp.Rows(0).Item(0) = 1 Then   'Lay giá trị theo tiẹm cận dưới
                                    g_TableTank.Rows(p_Count).Item("ProdLevel") = p_ATG_Lower_Row(0).Item(g_ProdLevelField)
                                    g_TableTank.Rows(p_Count).Item("ProdTemp") = p_ATG_Lower_Row(0).Item(g_ProdTempField)
                                    g_TableTank.Rows(p_Count).Item("DateTime") = p_ATG_Lower_Row(0).Item(g_DateTimeField)
                                ElseIf p_ATG_Tmp.Rows(0).Item(0) = 0 Then  'Lay giá trị theo tiẹm cận trên
                                    g_TableTank.Rows(p_Count).Item("ProdLevel") = p_ATG_Upper_Row(0).Item(g_ProdLevelField)
                                    g_TableTank.Rows(p_Count).Item("ProdTemp") = p_ATG_Upper_Row(0).Item(g_ProdTempField)
                                    g_TableTank.Rows(p_Count).Item("DateTime") = p_ATG_Upper_Row(0).Item(g_DateTimeField)
                                End If
                            End If
                        End If
                        Continue For
                    End If
                Next
            End If



        Catch ex As Exception
            p_SQL = ex.Message
        End Try


    End Sub

    Public Sub GetATG_API(ByVal p_Date As Date, ByVal p_MaBe As String,
                        ByRef p_thoidiem As String,
                      ByRef p_TankCode As String,
                      ByRef p_ChieuCao As Double,
                      ByRef p_NhietDo As Double,
                      ByRef p_TrongBe As Double, ByRef p_ChieuCaoNuoc As Double
                      )
        Dim p_String As String = ""
        Dim p_SQL As String = ""
        Dim p_Datatable As DataTable
        Dim p_Plant As String = ""
        'Dim p_JsonStr As String = ""
        Try
            p_SQL = "select * from tblConfig"
            p_Datatable = GetDataTable(p_SQL, p_SQL)
            If Not p_Datatable Is Nothing Then
                If p_Datatable.Rows.Count > 0 Then
                    p_Plant = p_Datatable.Rows(0).Item("Plant_DB").ToString.Trim
                End If

            End If
            'Dim g_1EndPointAddress As String = "http://203.162.247.20/tichhoptrungtam/Service/ServiceATG.svc"

            'Dim remoteAddress = New System.ServiceModel.EndpointAddress(New Uri(g_1EndPointAddress))

            'Dim p_Binding As System.ServiceModel.BasicHttpBinding
            'If InStr(UCase(g_1EndPointAddress), UCase("https"), CompareMethod.Text) > 0 Then
            '    p_Binding = New System.ServiceModel.BasicHttpBinding(BasicHttpSecurityMode.Transport)
            'Else
            '    p_Binding = New System.ServiceModel.BasicHttpBinding()
            '    ' p_Binding.Security.Mode = BasicHttpSecurityMode.None
            'End If
            '' '' p_Binding, remoteAddress
            '' Dim p_SvrB121 As B12.ServiceATGClient(p_Binding, g_1EndPointAddress)



            Dim p_SvrB121 As New B12.ServiceATGClient

            '' Khai báo biến link từ nguồn bất kỳ (DB, AppSettings, v.v.)
            'Dim myServiceUrl As String = "http://b12petroleum.com.vn/tichhoptrungtam/Service/ServiceATG.svc"
            '' Khởi tạo Client với EndpointAddress mới
            'Dim remoteAddress As New System.ServiceModel.EndpointAddress(myServiceUrl)
            'Dim p_SvrB121 As New B12.ServiceATGClient("BasicHttpBinding_IServiceATG", remoteAddress)



            '' 1. Khai báo URL động
            'Dim serviceUrl As String = "http://b12petroleum.com.vn/tichhoptrungtam/Service/ServiceATG.svc"

            '' 2. Khởi tạo Binding (phải khớp với phía Server, thường là BasicHttpBinding)
            'Dim binding As New System.ServiceModel.BasicHttpBinding()
            'binding.MaxReceivedMessageSize = 2147483647 ' Tăng limit nếu dữ liệu SAP lớn

            '' 3. Khởi tạo Endpoint Address
            'Dim address As New System.ServiceModel.EndpointAddress(serviceUrl)

            '' 4. Khởi tạo Client mà KHÔNG cần tên endpoint trong config
            '' B12.ServiceATGClient là class proxy của bạn
            'Dim client As New B12.ServiceATGClient(binding, address)




            p_thoidiem = ""
            p_TankCode = ""
            p_ChieuCao = 0
            p_NhietDo = 0
            p_TrongBe = 0
            p_SQL = ""
            'p_String = client.LayDoMucKhoBe(p_Date, p_Plant, p_MaBe)

            p_String = p_SvrB121.LayDoMuc(p_Date, p_MaBe)

            Dim jResults As New JArray
            Dim p_JToken As JToken
            Dim p_Object As JObject
            Try
                jResults = JArray.Parse(p_String)
                If jResults.Count > 0 Then
                    p_Object = jResults(0)
                    p_Object.CreateReader()
                    p_thoidiem = p_Object.GetValue("thoidiem").ToString
                    p_TankCode = p_Object.GetValue("Ma_be").ToString
                    Double.TryParse(p_Object.GetValue("ChieuCaoBe").ToString, p_ChieuCao)
                    Double.TryParse(p_Object.GetValue("NhietDo").ToString, p_NhietDo)
                    Double.TryParse(p_Object.GetValue("TrongBe").ToString, p_TrongBe)
                    Double.TryParse(p_Object.GetValue("ChieuCaoNuoc").ToString, p_ChieuCaoNuoc)
                End If
            Catch ex As Exception
                p_SQL = ex.Message
            End Try

        Catch ex2 As Exception
            p_SQL = ex2.Message
        End Try
        If p_SQL <> "" Then
            MsgBox(p_SQL)
        End If
    End Sub


    Public Sub mdlSynATG_MapNewAPI(ByVal p_Client As String, ByVal p_date As DateTime, ByVal p_ConnectATG As String, ByVal p_TableATG As String, ByVal p_TankList As String)
        Dim p_SQL As String
        Dim p_thoidiem As String
        Dim p_TankCode As String
        Dim p_ChieuCao As Double
        Dim p_NhietDo As Double
        Dim p_TrongBe As Double
        Dim p_ChieuCaoNuoc As Double

        Dim p_Count As Integer
        Dim p_Count1 As Integer
        'Dim p_ATG_Upper = New DataTable
        'Dim p_ATG_Lower = New DataTable
        Dim p_ATG_Tmp = New DataTable

        'Dim p_ATG_Upper_Row() As DataRow
        'Dim p_ATG_Lower_Row() As DataRow
        'Dim p_ATG_Tmp_Row() As DataRow

        '' Dim p_ATG_LowerTmp = New DataTable
        'Dim p_DateUpper As DateTime
        'Dim p_DateLower As DateTime
        'Dim p_Upper As Boolean = False
        'Dim p_Lower As Boolean = False
        'Dim p_Row_Upper As DataRow
        'Dim p_RowLower As DataRow
        'Dim p_DesError As String = ""
        ''Dim p_Count As Integer
        'Dim p_SourceTableATG As DataTable
        'Dim p_RowATG As DataRow
        ' Dim p_TankArr() As String
        Try

            If Not g_TableTank Is Nothing Then

                If g_Company_Code = "2610" Then
                    'Dim p_2610 As New K2610.Class1(Nothing, _
                    '                                         g_Company_Code, _
                    '                                         "", g_Services, "", "", "", "", _
                    '                                         "")

                    p_SQL = "select Map_Sap1, Name_Nd, Map_Sap from tblTank where CHARINDEX ( Map_SAP,'" & p_TankList & "',1) >0"
                    p_ATG_Tmp = GetDataTable(p_SQL, p_SQL)
                    ' p_TankArr = p_TankList.Split(",")
                    If Not p_ATG_Tmp Is Nothing Then
                        For p_Count1 = 0 To p_ATG_Tmp.Rows.Count - 1
                            If p_ATG_Tmp.Rows(p_Count1).Item("Map_Sap").ToString.Trim = "" Then
                                Continue For
                            End If
                            p_thoidiem = ""
                            p_TankCode = ""
                            p_ChieuCao = 0
                            p_NhietDo = 0
                            p_TrongBe = 0
                            GetATG_API(p_date, p_ATG_Tmp.Rows(p_Count1).Item("Map_Sap1").ToString.Trim,
                                 p_thoidiem,
                               p_TankCode,
                               p_ChieuCao,
                               p_NhietDo,
                               p_TrongBe,
                               p_ChieuCaoNuoc
                              )
                            If p_TankCode = "" Then
                                Continue For
                            End If
                            For p_Count = 0 To g_TableTank.Rows.Count - 1
                                If g_TableTank.Rows(p_Count).Item("TankCode_HTTG").ToString.Trim = p_ATG_Tmp.Rows(p_Count1).Item("Map_Sap1").ToString.Trim Then
                                    g_TableTank.Rows(p_Count).Item("ProdLevel") = p_ChieuCao
                                    g_TableTank.Rows(p_Count).Item("ProdTemp") = p_NhietDo
                                    g_TableTank.Rows(p_Count).Item("DateTime") = p_thoidiem
                                    g_TableTank.Rows(p_Count).Item("WaterHeight") = p_ChieuCaoNuoc
                                End If
                            Next
                        Next
                    End If
                   
                End If
            End If

            Exit Sub
            'If p_TankList.ToString.Trim <> "" Then
            '    p_SQL = " select * from " & p_TableATG & "  with (nolock)  where " & g_DateTimeField & " <= dateadd(Hour,+2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  " & _
            '        " and " & g_DateTimeField & "  >= dateadd(Hour,-2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  and charindex (" & g_TankATGField & ",  '" & p_TankList & "',1) >0 " ' and client  ='" & p_Client & "'"

            'Else
            '    p_SQL = " select * from " & p_TableATG & "  with (nolock)  where " & g_DateTimeField & "  <= dateadd(Hour,+2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  " & _
            '                            " and " & g_DateTimeField & "  >= dateadd(Hour,-2, convert(datetime, '" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' ))  "

            'End If
            'p_SourceTableATG = g_Services.GET_DATATABLE_With_Connect_Des(p_ConnectATG, p_SQL, p_DesError)

            'For p_Count = 0 To g_TableTank.Rows.Count - 1

            '    p_Lower = False
            '    p_Upper = False
            '    p_ATG_Lower_Row = p_SourceTableATG.Select("" & g_DateTimeField & " <='" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' and  " & g_TankATGField & " ='" & g_TableTank.Rows(p_Count).Item("TankCode").ToString.Trim & "'", "" & g_DateTimeField & " desc")
            '    If p_ATG_Lower_Row.Length > 0 Then
            '        p_Lower = True
            '    End If

            '    p_ATG_Upper_Row = p_SourceTableATG.Select("" & g_DateTimeField & " >='" & p_date.ToString("yyyy-MM-dd hh:mm:ss tt") & "' and  " & g_TankATGField & "  ='" & g_TableTank.Rows(p_Count).Item("TankCode").ToString.Trim & "'", "" & g_DateTimeField & " asc")
            '    If p_ATG_Upper_Row.Length > 0 Then
            '        p_Upper = True
            '    End If

            '    If p_Upper = False And p_Lower = False Then
            '        Continue For
            '    End If

            '    If p_Lower = False And p_Upper = True Then

            '        g_TableTank.Rows(p_Count).Item("ProdLevel") = p_ATG_Upper_Row(0).Item(g_ProdLevelField) ' p_ATG_Tmp.Rows(0).Item("ProdLevel")
            '        g_TableTank.Rows(p_Count).Item("ProdTemp") = p_ATG_Upper_Row(0).Item(g_ProdTempField) '  p_ATG_Tmp.Rows(0).Item("ProdTemp")
            '        g_TableTank.Rows(p_Count).Item("DateTime") = p_ATG_Upper_Row(0).Item(g_DateTimeField)
            '        Continue For
            '    End If

            '    If p_Lower = True And p_Upper = False Then

            '        g_TableTank.Rows(p_Count).Item("ProdLevel") = p_ATG_Lower_Row(0).Item(g_ProdLevelField) ' p_ATG_Tmp.Rows(0).Item("ProdLevel")
            '        g_TableTank.Rows(p_Count).Item("ProdTemp") = p_ATG_Lower_Row(0).Item(g_ProdTempField) '  p_ATG_Tmp.Rows(0).Item("ProdTemp")
            '        g_TableTank.Rows(p_Count).Item("DateTime") = p_ATG_Lower_Row(0).Item(g_DateTimeField)

            '        Continue For
            '    End If
            '    p_Row_Upper = Nothing
            '    p_RowLower = Nothing
            '    If p_Lower = True And p_Upper = True Then


            '        'p_SQL = "select case when DateUpper - CurrentDate >  CurrentDate -DateLower  then 1 else 0 end  as nValue  from  ( "
            '        'p_SQL = p_SQL & "select convert(datetime,'" & p_RowLower.Item("DateTime") & "')  as DateLower,  convert(datetime,'" & p_Row_Upper.Item("DateTime") & "')  as DateUpper " & _
            '        '            ", convert(datetime,'" & p_date & "')  as CurrentDate ) anhqh "
            '        p_SQL = "select case when DateUpper - CurrentDate >  CurrentDate -DateLower  then 1 else 0 end  as nValue  from  ( "
            '        p_SQL = p_SQL & "select convert(datetime,'" & p_ATG_Lower_Row(0).Item(g_DateTimeField) & "')  as DateLower,  convert(datetime,'" & p_ATG_Upper_Row(0).Item(g_DateTimeField) & "')  as DateUpper " & _
            '                    ", convert(datetime,'" & p_date & "')  as CurrentDate ) anhqh "

            '        p_ATG_Tmp = GetDataTable(p_SQL, p_SQL)
            '        If Not p_ATG_Tmp Is Nothing Then
            '            If p_ATG_Tmp.Rows.Count > 0 Then
            '                If p_ATG_Tmp.Rows(0).Item(0) = 1 Then   'Lay giá trị theo tiẹm cận dưới
            '                    g_TableTank.Rows(p_Count).Item("ProdLevel") = p_ATG_Lower_Row(0).Item(g_ProdLevelField)
            '                    g_TableTank.Rows(p_Count).Item("ProdTemp") = p_ATG_Lower_Row(0).Item(g_ProdTempField)
            '                    g_TableTank.Rows(p_Count).Item("DateTime") = p_ATG_Lower_Row(0).Item(g_DateTimeField)
            '                ElseIf p_ATG_Tmp.Rows(0).Item(0) = 0 Then  'Lay giá trị theo tiẹm cận trên
            '                    g_TableTank.Rows(p_Count).Item("ProdLevel") = p_ATG_Upper_Row(0).Item(g_ProdLevelField)
            '                    g_TableTank.Rows(p_Count).Item("ProdTemp") = p_ATG_Upper_Row(0).Item(g_ProdTempField)
            '                    g_TableTank.Rows(p_Count).Item("DateTime") = p_ATG_Upper_Row(0).Item(g_DateTimeField)
            '                End If
            '            End If
            '        End If
            '        Continue For
            '    End If
            'Next
            ''



        Catch ex As Exception
            p_SQL = ex.Message
        End Try


    End Sub



    Public Function B12_ThongTinHamHang(ByVal p_Do As String) As DataTable
        Dim requestUrl As String = "" ' = "http://www.b12petroleum.com.vn/TDHKhoBeAPI/api/DuongAmTamMuc?do_sap=" & p_Do
        '"http://www.b12petroleum.com.vn/TDHKhoBeAPI/api/DuongAmTamMuc?do_sap=2055500198"
        Dim p_SQL As String
        Dim jResults As JObject
        Dim p_Array1 As String()
        Dim p_Array2 As String()
        Dim p_Int, pInt1 As Integer
        Dim p_Table As New DataTable("HH")
        Dim p_Row As DataRow

        Dim p_tbl As DataTable
        Try
            p_SQL = "select KeyValue from sys_config where upper(KeyCode) =upper('TAMMUCLINK')"
            p_tbl = GetDataTable(p_SQL, p_SQL)
            If Not p_tbl Is Nothing Then
                If p_tbl.Rows.Count > 0 Then
                    requestUrl = p_tbl.Rows(0).Item(0).ToString.Trim & "=" & p_Do
                End If
            End If
            If requestUrl = "" Then
                'requestUrl = "http://www.b12petroleum.com.vn/TDHKhoBeAPI/api/DuongAmTamMuc?do_sap=" & p_Do
                MessageBox.Show("Link web tấm mức không xác định")
                Return Nothing
            End If
            Dim http As HttpWebRequest = CType(HttpWebRequest.Create(requestUrl), HttpWebRequest)
            ' h() 'ttp.Referer = referrer
            Dim response As HttpWebResponse = CType(http.GetResponse(), HttpWebResponse)
            p_Table.Columns.Add("MaNgan")
            p_Table.Columns.Add("HH")
            Using sr As StreamReader = New StreamReader(response.GetResponseStream())
                Dim responseJson As String = sr.ReadToEnd()
                ' Dim jResults As JObject = JObject.Parse(responseJson)
                jResults = JObject.Parse(responseJson)
                ' jResults = JArray.Parse(responseJson)
                If jResults.Count > 0 Then
                    If jResults.Item("hh").ToString <> "" Then

                        'p_SQL = jResults.Item("hh").Value
                        p_Array1 = Split(jResults.Item("hh").ToString, ";")
                        For p_Int = 0 To p_Array1.Length - 1
                            p_Array2 = Split(p_Array1(p_Int).ToString, ":")
                            If p_Array2.ToString <> "" Then
                                Try
                                    p_Row = p_Table.NewRow
                                    p_Row.Item(0) = Mid(p_Array2(0).ToString.Trim, 2).Trim
                                    p_Row.Item(1) = p_Array2(1).ToString.Trim
                                    p_Table.Rows.Add(p_Row)
                                Catch ex As Exception

                                End Try

                            End If
                        Next
                    End If

                End If





            End Using
            Return p_Table
        Catch ex As Exception
            'Return String.Empty
            p_SQL = ex.Message

            Return Nothing

        End Try
    End Function

End Module
