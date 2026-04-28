Module Functions
    Public Function p_Convert_Date(ByVal p_Str_Date As String) As String
        'If p_Connect_Type = "SQL" Then
        '    p_Convert_Date = Format(Convert.ToDateTime(p_Str_Date))
        'Else
        If p_Str_Date = "" Then Return ""
        If g_DBTYPE = "ORACLE" Then
            'p_DateValue.ToString("dd-MMMM-yyyy")
            p_Convert_Date = Format(Convert.ToDateTime(p_Str_Date), "dd-MMMM-yyyy")
        ElseIf g_DBTYPE = "SQL" Then
            p_Convert_Date = Format(Convert.ToDateTime(p_Str_Date), g_Format_Date)
        End If

        'End If
    End Function


    Public Function p_Convert_DateTime(ByVal p_Str_Date As String) As String
        'If p_Connect_Type = "SQL" Then
        '    p_Convert_Date = Format(Convert.ToDateTime(p_Str_Date))
        'Else
        If p_Str_Date = "" Then Return ""
        p_Convert_DateTime = Format(Convert.ToDateTime(p_Str_Date), g_Format_DateTime)
       
        'End If
    End Function


    Public Sub p_GetDateTime(ByRef p_Date As Date, ByRef p_Time As Integer)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        If g_DBTYPE = "ORACLE" Then
            p_SQL = "SELECT to_date(SYSDATE) AS SYS_DATE, to_number(TO_CHAR(CURRENT_DATE, 'HH24MI')) AS SysTime FROM dual"
            p_Datatable = g_Service.clsGetDataTableOracle(p_SQL, p_SQL)
        ElseIf g_DBTYPE = "SQL" Then
            p_SQL = "select  convert(date, getdate()) as SYS_DATE, replace(CONVERT(VARCHAR(5),DATEADD(MINUTE,0 ,GETDATE()),108),':','') as SysTime"
            p_Datatable = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
        End If
        
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SYS_DATE")
                p_Time = p_Datatable.Rows(0).Item("SysTime")
            End If
        End If
        p_Datatable = Nothing
    End Sub

    Public Sub p_GetFullDateTime(ByRef p_Date As DateTime, ByRef p_Time As Integer)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable

        If g_DBTYPE = "ORACLE" Then
            p_SQL = "SELECT SYSDATE AS SYS_DATE, to_number(TO_CHAR(CURRENT_DATE, 'HH24MI')) AS SysTime FROM dual"
            p_Datatable = g_Service.clsGetDataTableOracle(p_SQL, p_SQL)
        ElseIf g_DBTYPE = "SQL" Then
            p_SQL = "select   getdate()  as SYS_DATE , replace(CONVERT(VARCHAR(5),DATEADD(MINUTE,0 ,GETDATE()),108),':','') as SysTime "
            p_Datatable = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
        End If




       

        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SYS_DATE")
                p_Time = p_Datatable.Rows(0).Item("SysTime")
            End If
        End If
        p_Datatable = Nothing
    End Sub



    'Lay cau truc cac bang duoi Db
    'ANHQH
    '01/01/2012

    Public Function p_TableStructure(ByVal p_TableHead As String, _
                                      ByRef p_DBDataSet As DataSet, _
                                        Optional ByVal p_GetB1 As Boolean = False) As Boolean
        Dim p_Table As New System.Data.DataTable("Table01")
        Dim p_Table1 As New System.Data.DataTable("Table02")
        Dim p_DataSet01 As New DataSet
        Dim p_SQL As String
        ' Dim p_Sysbatch As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        p_TableStructure = True
        p_TableHead = Replace(p_TableHead, "[", "", 1)
        p_TableHead = Replace(p_TableHead, "]", "", 1)
        Try
            If Not p_TableHead Is Nothing Then
                If g_DBTYPE = "ORACLE" Then
                    p_SQL = "SELECT upper(Table_Name) AS TABLE_NAME,NULL AS object_id, " & _
                        "COLUMN_NAME , CASE WHEN  DATA_TYPE ='VARCHAR2' THEN 'C' ELSE  " & _
                        "CASE WHEN  DATA_TYPE ='NUMBER' THEN 'N' ELSE 'D' END END AS COLUMN_TYPE " & _
                        "FROM all_tab_columns WHERE Table_Name='" & p_TableHead & "'"

                    p_DataSet01 = g_Service.clsGetDataSet_Oracle(p_SQL, p_SQL)

                ElseIf g_DBTYPE = "SQL" Then
                            p_SQL = "select upper(B.name) as TABLE_NAME,a.object_id  as COLUMN_ID, a.name as COLUMN_NAME," & _
                                    " case when  a.user_type_id In (231,175) then 'C' else case when  a.user_type_id in (61,40) then 'D' else 'N' end  end  as COLUMN_TYPE " & _
                               " from sys.all_columns A, sys.all_objects B Where a.object_id=b.object_id  and B.name='" & p_TableHead & "'"
                    If p_GetB1 = False Then
                        'p_Table1 = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
                        ' p_Table = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
                        p_DataSet01 = g_Service.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)
                    Else
                        p_Table1 = g_Service.mod_SYS_GET_DATATABLE_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQL)
                        ' p_Table = g_Service.mod_SYS_GET_DATATABLE_Com(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_SQL)


                    End If
                End If
                If Not p_DataSet01 Is Nothing Then
                    '  p_DBDataSet.Tables.Add(New DataTable)
                    ' p_Table1. = p_Table.
                    ' p_DataSet01.Tables.Add(p_Table)
                    p_DBDataSet = p_DataSet01
                    'p_DBDataSet.Tables.Add(p_Table1)
                    'p_DBDataSet.Tables.Add(p_Table)
                End If
                'p_Sysbatch = Nothing
            End If
        Catch ex As Exception
            p_TableStructure = False

        End Try
        '  p_Sysbatch = Nothing
    End Function

    'anhqh
    '26/03/2014
    'Ham thuc hien kiem tra xem banr ghi ton tai chua
    'Neu ton tai tra ve 1

    'Loi tra ve -1
    Public Function p_CheckRowExists(ByRef p_Desc As String, ByVal p_HeaderControlKey As Object, _
                                      ByVal p_ColumnKey As String, _
                                      ByVal p_TableName As String, _
                                      ByRef p_DataTable As DataTable) As Integer
        ' Dim p_Data As DataTable
        Dim p_SQL As String
        Dim p_Value As String
        Dim p_FieldName As String
        Dim p_FieldType As String
        p_CheckRowExists = False

        Try
            p_CheckRowExists = 1
            'p_ItemName = UCase(p_ControlKey.FieldName)
            p_FieldType = UCase(p_HeaderControlKey.FieldType)

            If p_HeaderControlKey.EditValue Is Nothing Then
                p_Value = ""
            Else
                p_Value = p_HeaderControlKey.EditValue.ToString
            End If
            If p_Value = "" Then
                p_CheckRowExists = -1
                p_Desc = "Giá trị Key không hợp lệ"
                Exit Function
            End If



            If p_FieldType <> "N" And p_FieldType <> "C" Then
                p_CheckRowExists = -1
                p_Desc = "FieldKeyType không hợp lệ"
                Exit Function
            End If
            If p_FieldType = "N" Then
                p_SQL = "Select " & p_ColumnKey & " from " & p_TableName & " With (Nolock) Where " & p_HeaderControlKey.FieldName & "=" & p_Value
            Else
                p_SQL = "Select " & p_ColumnKey & " from " & p_TableName & " With (Nolock) Where " & p_HeaderControlKey.FieldName & "='" & p_Value & "'"
            End If
            p_DataTable = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Desc)
            If p_Desc <> "" Then
                p_CheckRowExists = -1
                p_DataTable = Nothing
                Exit Function
            End If
        Catch ex As Exception
            p_Desc = ex.Message
            p_CheckRowExists = -1
        End Try
    End Function


End Module
