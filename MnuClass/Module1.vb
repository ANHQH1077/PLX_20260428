Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Net

Module Module1
    Public g_IP_Address As String
    Public g_GetHostName As String
    Public g_User_ID As Double

    Public p_Company_ID As Integer
    Public p_Company_Code As String
    Public p_Company_Name As String
    Public p_User_Database As String
    Public g_Company_Host As String

    Public g_UserName As String
    Public g_UsrB1 As String
    Public g_PassB1 As String
    Public g_Port As String

    Public g_Company_DBName As String

    Public pv_Back_Color As System.Drawing.Color = Drawing.Color.White
    Public pv_Required_Back_Color As System.Drawing.Color = Drawing.Color.Yellow
    Public pv_Locked_Back_Color As System.Drawing.Color = Drawing.Color.LightCyan
    Public g_Format_Date_Ora As String = "MM/DD/YYYY"
    Public g_Format_Date As String = "MM/dd/yyyy"

    Private pv_Type_Column_Char As String = "C"  'Kieu du lieu cua column
    Private pv_Type_Column_Date As String = "D"  'Kieu du lieu cua column
    Private pv_Type_Column_Number As String = "N"  'Kieu du lieu cua column


    Private pv_Type_Date As String = "DATEEDIT"
    Private pv_Type_TextBox As String = "C1TEXTBOX"
    Private pv_Type_Num As String = "C1NUMERICEDIT"
    Private pv_Type_Combo As String = "C1COMBO"

    Public pv_Message_Dataset As New DataSet

    Public p_Dataset_Binding As New DataSet
    Public p_DataSet_Combo_Source As New DataSet
    Public p_DataSet_TrueGird As New DataSet

    Public g_Services As Object

    Public g_DBTYPE As String

    Public Const g_RowNum As Integer = 20

    Public g_ToolStripStatus As System.Windows.Forms.ToolStripStatusLabel
    Public g_CompanyAPI As New Object
    Public g_LicenceHost As String
    Public g_Company_Code As String
    Public g_DBUser As String
    Public g_DBPass As String
    Public g_Currency As String = "VND"
    Public g_CurrencyDtl As New DataTable
    Public g_CurrencyDecima As Integer
    Public g_User_Database As String = ""
    Public g_MessageStatus As System.Windows.Forms.ToolStripStatusLabel

    Public Function GetDataTable(ByVal p_SQL As String, ByVal p_Error As String) As DataTable
        Dim p_Datatable As DataTable
        Try
            p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message
            'ShowMessageBox(Err.Number, p_Error)
            MsgBox(ex.Message)
            Return Nothing
        End Try
        Return p_Datatable

    End Function

    Public Function GetDataSet(ByVal p_SQL As String, ByVal p_Error As String) As DataSet
        Dim p_Datatable As DataSet
        Try
            p_Datatable = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message
            MsgBox(ex.Message)

            Return Nothing
        End Try
        Return p_Datatable

    End Function


    Public Sub p_GetDateTime(ByRef p_Date As Date, ByRef p_Time As Integer)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        p_SQL = "select  convert(date, getdate()) as SysDate, replace(CONVERT(VARCHAR(5),DATEADD(MINUTE,0 ,GETDATE()),108),':','') as SysTime"
        p_Datatable = GetDataTable(p_SQL, p_SQL)  ' g_Services.mod_SYS_GET_DATATABLE(p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SysDate")
                p_Time = p_Datatable.Rows(0).Item("SysTime")
            End If
        End If
        p_Datatable = Nothing
    End Sub

    Public Function GetTimeServerClient() As String
        Dim p_DT As New System.Data.DataTable
        Dim p_FptModule1 As New FPTModule.Class1(g_UserName, "", g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_User_Database)
        GetTimeServerClient = Now.ToString
        p_DT = g_Services.mod_SYS_GET_DATATABLE("select convert(varchar,GETDATE(),121) as SrvTime ")
        If Not p_DT Is Nothing Then
            If p_DT.Rows.Count > 0 Then
                GetTimeServerClient = p_DT.Rows(0).Item("SrvTime").ToString
            End If
        End If
        p_DT = Nothing
        p_FptModule1 = Nothing
    End Function

    Public Function p_CheckExist_Code(ByVal p_Item As Object) As Boolean
        p_CheckExist_Code = False
        Dim p_SQL As String = ""
        Dim p_TableName As String = ""
        Dim p_FieldName As String = ""
        Dim p_Value As String = ""
        Dim p_Type As String = ""
        ' Dim p_sys As New SystemBatch.Class1(g_Company_Host, g_User_Database)
        Dim p_table As New DataTable
        p_TableName = p_Item.TableName
        p_Value = p_Item.EditValue
        p_FieldName = p_Item.FieldName
        If p_Value Is Nothing Then
            p_CheckExist_Code = True
        End If
        If p_Value.ToString = "" Or p_TableName = "" Then
            p_CheckExist_Code = True
        End If
        p_Type = p_Item.FieldType
        p_SQL = ""


        Select Case p_Type
            Case "C"
                p_SQL = "SELECT  1 FROM  " & p_TableName & " WHERE " & p_FieldName & "='" & p_Value & "'"

            Case "N"
                p_SQL = "SELECT  1 FROM  " & p_TableName & " WHERE " & p_FieldName & "=" & p_Value & ""
        End Select
        If p_SQL <> "" Then
            p_table = g_Services.mod_SYS_GET_DATATABLE(p_SQL)  '(g_Company_Host, g_User_Database, g_UsrB1, g_PassB1, g_Port, p_SQL)
            If Not p_table Is Nothing Then
                If p_table.Rows.Count > 0 Then
                    p_CheckExist_Code = True
                End If
            End If
            p_table = Nothing
            '  p_sys = Nothing
        End If
    End Function

    'ANHHQ
    '21/11/2011
    'Ham thuc hien select ma fill du lieu vao p_BindingSource1 va set datafile  dung ca cho bien p_abc la C1Flex
    Sub Mod_Get_Gird(ByVal p_SQL As String, ByRef p_BindingSource1 As Windows.Forms.BindingSource, ByRef p_abc As Object)
        'Dim p_MnuSystem As New SystemBatch.Class1
        Dim p_Mod_Get_Gird As New DataTable
        Dim p_Type As String

        p_Type = p_abc.Styles.ToString
        If InStr(p_Type, UCase("C1FlexGrid"), CompareMethod.Text) > 0 Then  'Dung cho C1Flex
            p_abc.AutoGenerateColumns = False
        End If
        'Dim p_Status As Boolean
        p_Mod_Get_Gird = g_Services.mod_SYS_GET_DATASET(p_SQL).Tables(0)
        p_BindingSource1.DataSource = p_Mod_Get_Gird
        'p_abc.DataSource = p_BindingSource1

        If InStr(p_Type, UCase("C1FlexGrid"), CompareMethod.Text) > 0 Then  'Dung cho C1Flex
            For p_Index = 1 To p_Mod_Get_Gird.Columns.Count - 1
                p_abc.Cols(p_Index).Name = p_Mod_Get_Gird.Columns(p_Index).ToString
            Next p_Index
        Else
            For p_Index = 0 To p_Mod_Get_Gird.Columns.Count - 1
                p_abc.Columns(p_Index).DataField = p_Mod_Get_Gird.Columns(p_Index).ToString
            Next p_Index
        End If

        p_BindingSource1.ResetBindings(True)
        p_abc.Rebind(True)
        'p_abc.Refresh()


    End Sub


    'ANHHQ
    '21/11/2011
    'Ham thuc hien select ma fill du lieu vao DataSet va set datafile  dung ca cho bien p_abc la C1Flex
    Sub Mod_Get_DataSet_To_Gird(ByVal p_SQL As String, ByRef p_Dataset As DataSet, ByRef p_abc As Object)
        ' Dim p_MnuSystem As New SystemBatch.Class1
        'Dim p_Mod_Get_Gird As New DataTable
        'Dim p_Type As String


        'Dim p_Status As Boolean
        p_Dataset = g_Services.mod_SYS_GET_DATASET(p_SQL)


        For p_Index = 0 To p_Dataset.Tables(0).Columns.Count - 1
            p_abc.Columns(p_Index).DataField = p_Dataset.Tables(0).Columns(p_Index).ColumnName.ToString
        Next p_Index


        'p_BindingSource1.ResetBindings(True)
        p_abc.datasource = p_Dataset.Tables(0)
        p_abc.Rebind(True)
        'p_abc.Refresh()


    End Sub
    'ANHHQ
    '21/11/2011
    'Ham thuc hien select ma fill du lieu vao p_BindingSource1 
    Sub Mod_Get_BindingSource(ByVal p_SQL As String, ByRef p_BindingSource1 As Windows.Forms.BindingSource)
        ' Dim p_MnuSystem As New SystemBatch.Class1
        Dim p_Mod_Get_Gird As New DataTable
        'Dim p_Type As String

        'Dim p_Status As Boolean
        p_Mod_Get_Gird = g_Services.mod_SYS_GET_DATASET(p_SQL).Tables(0)
        p_BindingSource1.DataSource = p_Mod_Get_Gird
        'p_abc.DataSource = p_BindingSource1
        p_BindingSource1.ResetBindings(True)

    End Sub

    'ANHHQ
    '21/11/2011
    'Ham thuc hien select ma fill du lieu vao p_BindingSource1 va set datafile  dung ca cho bien p_abc la C1Flex
    Sub Mod_Get_Gird_DevExpress(ByVal p_SQL As String, ByRef p_BindingSource1 As Windows.Forms.BindingSource, ByRef p_abc As Object)
        ' Dim p_MnuSystem As New SystemBatch.Class1
        Dim p_Mod_Get_Gird As New DataTable
        'Dim p_Type As String


        'Dim p_Status As Boolean
        p_Mod_Get_Gird = g_Services.mod_SYS_GET_DATASET(p_SQL).Tables(0)
        p_BindingSource1.DataSource = p_Mod_Get_Gird
        'p_abc.DataSource = p_BindingSource1


        For p_Index = 0 To p_Mod_Get_Gird.Columns.Count - 1
            p_abc.Columns(p_Index).FieldName = p_Mod_Get_Gird.Columns(p_Index).ToString
        Next p_Index


        p_BindingSource1.ResetBindings(True)
        p_abc.RefreshData()
        'p_abc.Refresh()


    End Sub
    Public Sub Mod_IPAddress()
        g_GetHostName = System.Net.Dns.GetHostName()
        Dim ipHostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        Dim ipAddress As System.Net.IPAddress
        Dim ipTmp As String = ""
        For Each ipAddress In ipHostInfo.AddressList
            'Only return IPv4 routable IPs
            If (ipAddress.AddressFamily = Sockets.AddressFamily.InterNetwork) Then
                ipTmp = ipAddress.ToString
                Exit For
            End If
        Next
        If String.IsNullOrEmpty(ipTmp) Then
            ipTmp = ipHostInfo.AddressList(0).ToString
        End If
        g_IP_Address = ipTmp
        'g_IP_Address = System.Net.Dns.GetHostAddresses(g_GetHostName).GetValue(0).ToString    ' .GetHostByName(strHostName).ToString ' AddressList(0).ToString()                  

        'If g_IP_Address.LastIndexOf(".") <= 0 Then
        '    g_IP_Address = System.Net.Dns.GetHostAddresses(g_GetHostName).GetValue(1).ToString
        'End If
    End Sub

    'ANHQH
    'Ham chuyen du lieu tu Grid toi Dataset
    ' Bao gom ca Array del
    Public Sub p_Fill_Grid_To_DataSet(ByRef p_DataSet As DataSet, _
                                      ByVal p_Aray_Del As String(), _
                                        ByVal p_C1TrueDBGrid As Object, _
                                        ByVal p_C1TrueDBGrid_Last_Col As Integer)
        Dim p_Count As Integer
        Dim p_Row As DataRow
        'Dim p_svr As New SystemBatch.Class1
        Dim p_Table As New DataTable("TableTemp")
        Dim p_Col1 As New DataColumn("Column0")
        p_DataSet.Clear()
        p_Col1.DataType = GetType(String)
        p_Table.Columns.Add(p_Col1)

        If p_DataSet.Tables.Count > 0 Then
            p_DataSet.Tables.Remove("TableTemp")
        End If


        p_DataSet.Tables.Add(p_Table)
        p_C1TrueDBGrid.MoveFirst()
        For p_Count = 0 To p_C1TrueDBGrid.RowCount - 1
            If p_C1TrueDBGrid.Columns(p_C1TrueDBGrid_Last_Col).Value.ToString <> "" Then
                p_Row = p_DataSet.Tables("TableTemp").NewRow
                p_Row("Column0") = p_C1TrueDBGrid.Columns(p_C1TrueDBGrid_Last_Col).Value
                p_DataSet.Tables("TableTemp").Rows.Add(p_Row)
            End If
            p_C1TrueDBGrid.MoveNext()
        Next
        If p_Aray_Del Is Nothing Then
        Else
            For p_Count = 0 To UBound(p_Aray_Del, 1) - 1
                If p_Aray_Del(p_Count) Is Nothing Then
                    Exit For
                Else
                    p_Row = p_DataSet.Tables("TableTemp").NewRow
                    p_Row("Column0") = p_Aray_Del(p_Count)
                    p_DataSet.Tables("TableTemp").Rows.Add(p_Row)
                End If
            Next
        End If
    End Sub


    


    'ANHQH
    '23/12/2011
    'Hàm thực hiện thêm noi dung p_DataSet_Source vào p_DataSet
    'Chu ý: Hàm này chỉ thực hiện cho dataset có 1 column
    Public Sub p_Fill_DataSet_To_DataSet(ByRef p_DataSet As DataSet, _
                                      ByVal p_DataSet_Source As DataSet)
        'Dim p_Count As Integer
        'Dim p_Row As DataRow
        'Dim p_svr As New SystemBatch.Class1
        'Dim p_Table As New DataTable("TableTemp")
        'Dim p_Col1 As New DataColumn("Column0")
        ' p_DataSet.Clear()
        ' p_Col1.DataType = GetType(String)
        'p_Table.Columns.Add(p_Col1)

        'For p_Count = 0 To p_DataSet_Source.Tables(0).Rows.Count - 1
        '    If p_DataSet_Source.Tables(0).Rows(p_Count).Item(0).ToString <> "" Then
        '        p_Row = p_DataSet.Tables(0).NewRow
        '        p_Row(0) = p_DataSet_Source.Tables(0).Rows(p_Count).Item(0).ToString
        '        p_DataSet.Tables(0).Rows.Add(p_Row)
        '    End If
        'Next p_Count
        p_DataSet.Merge(p_DataSet_Source)
    End Sub


    'ANHQH
    '23/12/2011
    'Hàm thực hiện thêm noi dung SQL vào p_DataSet
    'Chu ý: Hàm này chỉ thực hiện cho dataset có 1 column
    Public Sub p_Fill_SQL_To_DataSet(ByRef p_DataSet As DataSet, _
                                      ByVal p_SQL As String)
        'Dim p_Row As DataRow
        'p_Row = p_DataSet.Tables(0).NewRow
        'p_Row(0) = p_SQL
        'p_DataSet.Tables(0).Rows.Add(p_Row)
        'Dim p_Count As Integer
        Dim p_Row As DataRow

        Dim p_Table As New DataTable("TableTemp")
        Dim p_Col1 As New DataColumn("Column0")
        If p_SQL <> "" Then
            ' p_DataSet.Clear()

            If p_DataSet.Tables.Count > 0 Then
                'p_DataSet.Tables.Remove("TableTemp")
            Else
                p_Col1.DataType = GetType(String)
                p_Table.Columns.Add(p_Col1)
                p_DataSet.Tables.Add(p_Table)
            End If
            p_Row = p_DataSet.Tables(0).NewRow
            p_Row(0) = p_SQL
            p_DataSet.Tables(0).Rows.Add(p_Row)
        End If
    End Sub

    'ANHHQ
    '10/12/2011
    'Hàm thực hiện chuyển Array thành DataSet
    Public Sub p_Fill_Array_To_DataSet(ByRef p_DataSet As DataSet, ByVal p_Array_Str As String(), ByVal p_Index As Integer)
        Dim p_Count As Integer
        Dim p_Row As DataRow
        ' Dim p_svr As New SystemBatch.Class1
        Dim p_Table As New DataTable("TableTemp")
        'Dim p_DataSet As New DataSet("DataSetTemp0")
        Dim p_Col1 As New DataColumn("Column0")
        p_DataSet.Clear()
        p_Col1.DataType = GetType(String)
        p_Table.Columns.Add(p_Col1)
        p_DataSet.Tables.Add(p_Table)
        For p_Count = 0 To p_Index
            If p_Array_Str(p_Count) Is Nothing Then

            Else
                If p_Array_Str(p_Count).ToString <> "" Then
                    p_Row = p_DataSet.Tables("TableTemp").NewRow
                    p_Row("Column0") = p_Array_Str(p_Count).ToString
                    p_DataSet.Tables("TableTemp").Rows.Add(p_Row)
                End If
            End If
        Next
    End Sub





    Public Function p_Show_Mess(ByVal p_Message_String As String, _
                                  ByVal p_Show_OK_Button As Boolean, _
                                    ByVal p_OK_Button_Text As String, _
                                    ByVal p_Show_CanCel_Button As Boolean, _
                                    ByVal p_Cancel_Button_Text As String, _
                                    ByVal p_Window_Title As String) As Integer
        Dim p_Form As New FrmMessage
        Dim p_Result As DialogResult
        p_Form.p_Show_OK = p_Show_OK_Button
        p_Form.p_Show_Cancel = p_Show_CanCel_Button

        p_Form.p_Message_Text = p_Message_String
        p_Form.p_Show_OK_Text = p_OK_Button_Text
        p_Form.p_Show_Cancel_Text = p_Cancel_Button_Text
        p_Form.p_Window_Title = p_Window_Title
        p_Result = p_Form.ShowDialog
        p_Show_Mess = p_Form.p_Value_Return
    End Function


   

    'ANHQH
    'Ham get các thông báo hệ thống vào DataSet
    Public Sub p_Get_Message()
        ' Dim p_Object As New SystemBatch.Class1
        Dim p_SQL As String
        p_SQL = "select h.message_name from SYS_MESSAGES  h where h.enable_flag='Y'  order by h.message_code"
        pv_Message_Dataset = g_Services.mod_SYS_GET_DATASET(p_SQL)
        ' p_Object = Nothing
    End Sub


    Public Function p_Convert_Date(ByVal p_Str_Date As String) As String
        'If p_Connect_Type = "SQL" Then
        '    p_Convert_Date = Format(Convert.ToDateTime(p_Str_Date))
        'Else

        p_Convert_Date = Format(Convert.ToDateTime(p_Str_Date), g_Format_Date)
        'End If
    End Function

    'ANHQH
    '19/12/2011
    'Ham kiem tra doi chieu gia tri
    'Du lieu gom DataTable, Cot thu i va gia tri can so sanh
    Public Function p_Check_Value(ByVal p_DataTable As DataTable, ByVal p_Col As Integer, ByVal p_Value As String) As Boolean
        Dim p_Count As Integer
        p_Check_Value = False
        For p_Count = 0 To p_DataTable.Rows.Count - 1
            If UCase(p_Value) = UCase(p_DataTable.Rows(p_Count).Item(p_Col).ToString) Then
                p_Check_Value = True
                Exit For
            End If
        Next
    End Function


    Public Function p_Set_Relation(ByRef p_Data_Master As DataSet, ByVal p_Link_Key As String) As String
        Dim p_relCustOrd As DataRelation
        Dim p_colMaster1 As DataColumn
        Dim p_colDetail1 As DataColumn
        'Dim p_Relation_NAme As String
        p_Set_Relation = p_Data_Master.Tables(0).TableName.ToString & "Relation"
        p_colMaster1 = p_Data_Master.Tables(0).Columns(p_Link_Key)
        p_colDetail1 = p_Data_Master.Tables(1).Columns(p_Link_Key)
        p_relCustOrd = New System.Data.DataRelation(p_Set_Relation, p_colMaster1, p_colDetail1, True)
        p_Data_Master.Relations.Add(p_relCustOrd)
        'p_Data_Master.Tables(1).ChildRelations.Item(0).ChildTable.
    End Function



    Public Sub DataNavigator1_Button(ByRef DataNavigator1 As DevExpress.XtraEditors.DataNavigator, ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs, _
                                          ByRef pv_Header_Status As String, ByVal pv_INS_KEY As String, _
                                          ByRef SimpleButton1 As DevExpress.XtraEditors.SimpleButton, _
                                          ByRef p_CommitForm As Boolean)
        'Dim p_UserID As Double
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Append Then

            pv_Header_Status = pv_INS_KEY

            SimpleButton1.Text = "Update"

            
        Else
            If pv_Header_Status <> "" And SimpleButton1.Text = "Update" Then
                If MsgBox("Bản ghi chưa được lưu, bạn có muốn lưu lại không?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1) = MsgBoxResult.Yes Then
                    ' DataNavigator1_ButtonClick(sender, e.Button.ButtonType.CancelEdit)
                    e.Handled = True
                    Exit Sub
                Else
                    Dim p_Button As DevExpress.XtraEditors.DataNavigatorButtons
                    pv_Header_Status = ""
                    SimpleButton1.Text = "Ok"
                    p_Button = DataNavigator1.Buttons
                    p_Button.DoClick(DataNavigator1.Buttons.CancelEdit)
                    p_CommitForm = False
                End If
            End If

            pv_Header_Status = ""
            SimpleButton1.Text = "Ok"
            p_CommitForm = False


        End If

    End Sub

    'hieptd4 add 20160718
    Public Function CheckFormOpen(ByVal p_FormName As String) As Object

        Dim frmCollection As New FormCollection()

        CheckFormOpen = Nothing
        frmCollection = Application.OpenForms()
        CheckFormOpen = frmCollection.Item(p_FormName)

    End Function

End Module
