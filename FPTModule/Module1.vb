Imports System.Windows.Forms
Imports DevExpress.LookAndFeel
Imports DevExpress.Utils
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing.Color

Imports DevExpress.XtraPrinting

Module Module1
    'FPTModule
    Public g_Service As Object
    Public Const g_RowNum As Integer = 20
    Public g_Company_Host As String
    Public g_Company_DB_Name As String
    Public g_UsrB1 As String
    Public g_PassB1 As String
    Public g_Port As String

    Public g_DBUsr As String
    Public g_DBPass As String

    Public g_UserName As String
    Public g_CompanyCode As String


    Private pv_Type_Column_Char As String = "C"  'Kieu du lieu cua column
    Private pv_Type_Column_Date As String = "D"  'Kieu du lieu cua column
    Private pv_Type_Column_Number As String = "N"  'Kieu du lieu cua column

    Public g_Format_Date As String = "MM/dd/yyyy"
    Private pv_Type_Date As String = ".U_DATEEDIT"

    Private pv_Type_ChectBox As String = ".U_CHECKBOX"

    Private pv_Type_TextBox As String = ".U_TEXTBOX"
    Private pv_Type_MemoEdit As String = UCase(".U_MemmoEdit")
    Private pv_Type_Num As String = ".U_NUMERICEDIT"
    Private pv_Type_Combo As String = ".U_COMBOBOX"
    Private pv_Type_Button As String = ".U_BUTTONEDIT"
    Private pv_Type_Tabpage As String = "TABCONTROL"
    Private pv_Type_PanelControl As String = "PANELCONTROL"
    'PanelControl
    Private pv_Type_MemoTextBox As String = ".U_MEMMOEDIT"
    Private pv_Type_TrueDBGrid As String = ".U_TRUEDBGRID"


    Public pv_Back_Color As System.Drawing.Color = System.Drawing.Color.White
    Public pv_Required_Back_Color As System.Drawing.Color = System.Drawing.Color.LightGoldenrodYellow
    Public pv_Locked_Back_Color As System.Drawing.Color = System.Drawing.Color.LightGray '   System.Drawing.Color.LightCyan



    Public g_Currency As String = "VND"
    Public g_CurrencyDtl As New DataTable
    Public g_CurrencyDecima As Integer = 0

    Public g_DBTYPE As String



    Public Function Get_ThoiGianDau(p_SoLenh As String) As DateTime
        Dim p_Max As Boolean = True

        Get_ThoiGianDau = Now
        Dim p_DataTable As DataTable
        Dim p_SQL As String
        Dim p_Row() As DataRow

        p_SQL = "SELECT * FROM SYS_CONFIG WHERE KeyCode='MAX_TIME'"

        p_DataTable = p_GET_DATATABLE_Des(p_SQL, p_SQL)

        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                'p_Row = p_DataTable.Select("KeyCode='MAX_TIME'")
                'If p_Row.Length > 0 Then
                If p_DataTable.Rows(0).Item("KeyValue").ToString.Trim = "Y" Then
                    p_Max = True
                Else
                    p_Max = False
                    ' End If
                End If
            End If
        End If

        If p_Max = True Then
            p_SQL = "select max(isnull( ThoiGianDau,getdate())) as ThoiGianDau from fpt_tbllenhxuatchitiete5_v where solenh='" & p_SoLenh & "'"
        Else
            p_SQL = "select min(isnull( ThoiGianDau,getdate())) as ThoiGianDau from fpt_tbllenhxuatchitiete5_v where solenh='" & p_SoLenh & "'"
        End If
        '  p_SQL = "select max(isnull( ThoiGianDau,getdate())) as ThoiGianDau from fpt_tbllenhxuatchitiete5_v where solenh='" & p_SoLenh & "'"

        p_DataTable = p_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Get_ThoiGianDau = p_DataTable.Rows(0).Item(0)
            End If
        End If
    End Function



    'ANHQH
    '01/01/2012
    'Ham thuc hien set Fieldname cho Item tren Form
    Public Function p_SetDefautCombobox(ByRef p_Form As Object) As Boolean

        Dim p_Object As Object
       
        Dim p_Combobox As U_TextBox.U_Combobox
    
        p_SetDefautCombobox = True
        '  p_CountObj = 0
        Try
           
            For Each ctrl As Control In p_Form.Controls

                p_Object = ctrl
                '

                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 Then
                    Try
                        p_Combobox = CType(p_Object, U_TextBox.U_Combobox)
                        'p_Combobox.ItemIndex = 0
                        '  If InStr(p_Combobox.SQL_String, ":", CompareMethod.Text) > 0 Then

                        '  Else
                        p_Combobox.ItemIndex = 0
                        ' End If
                    Catch ex As Exception

                    End Try

                End If
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    p_SetDefautCombobox = p_SetDefautComboboxPage(p_Form,
                                              p_Object)
                    If p_SetDefautCombobox = False Then Exit Function
                End If

            Next
        Catch ex As Exception
            MsgBox("SetDefautCombobox: " & ex.Message)
            p_SetDefautCombobox = False
        End Try

    End Function

    Private Function p_SetDefautComboboxPage(ByRef p_Form As Object, _
                                             ByRef p_Object As Object) As Boolean

        Dim p_Object_Item As Object
        'Dim p_Object_Value As Object

      
        Dim p_Count As Integer
        Dim p_TabControl_Ind As Integer
      
        Dim p_CountObj1 As Integer = Nothing

        Dim p_Combobox As U_TextBox.U_Combobox
       
        'Xu ly cho cac item tabpage
        Dim p_TabPage As Object

        p_SetDefautComboboxPage = True

        If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
            Try
                ' For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                For p_Count = p_Object.TabPages.Count - 1 To 0 Step -1
                    'For Each p_Control In p_Object.Controls

                    p_Object.SelectedTabPageIndex = p_TabControl_Ind

                    p_Object_Item = p_Object.TabPages(p_Count)
                   
                    If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                        p_SetDefautComboboxPage = p_SetDefautComboboxPage(p_Form,
                                              p_Object)
                        If p_SetDefautComboboxPage = False Then Exit Function
                    Else
                        If InStr(UCase(p_Object_Item.GetType.ToString), "XtraTabPage", CompareMethod.Text) > 0 Then
                            p_TabPage = p_Object_Item
                            'For p_Count1 = 0 To p_TabPage.Controls.Count - 1
                            For Each p_Object_Item In p_TabPage.Controls
                                'p_Object_Item = p_TabPage.Controls(p_Count1)
                                'If UCase(p_Object_Item.name.ToString.Trim) = UCase("U_Status") Then
                                '    MsgBox("sdfsdf")
                                'End If
                                If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                                    p_SetDefautComboboxPage = p_SetDefautComboboxPage(p_Form,
                                                          p_Object_Item)
                                    If p_SetDefautComboboxPage = False Then Exit Function
                                Else

                                    If  InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0  Then
                                        Try
                                            p_Combobox = CType(p_Object_Item, U_TextBox.U_Combobox)
                                            ' If InStr(p_Combobox.SQL_String, ":", CompareMethod.Text) > 0 Then

                                            ' Else
                                            p_Combobox.ItemIndex = 0
                                            '  End If

                                        Catch ex As Exception

                                        End Try
                                    End If
                                End If
                            Next

                        End If
                    End If
                    p_Object.TabPages(p_Count).Select()
                Next
            Catch ex As Exception

                p_SetDefautComboboxPage = False
                MsgBox("SetDefautComboboxPage: " & ex.Message)

            End Try


        End If
    End Function


    ' Public g_ItemCopyFrom As New DataTable("Table01")
    'Public Function p_ComboboxAddValueSQL(ByRef p_Form As Form, _
    '                                ByRef p_Combobox As U_TextBox.U_Combobox) As String
    '    Dim p_SQL As String
    '    Dim p_Count As Integer
    '    Dim p_Col1 As DataColumn
    '    Dim p_Datatable As DataTable = Nothing
    '    Dim p_ShowHead As Boolean
    '    p_ComboboxAddValueSQL = ""

    '    Try

    '        p_SQL = p_Combobox.SQL_String.ToString.Trim
    '        p_SQL = p_Parameter_Item(p_Form, p_SQL)
    '        p_ShowHead = p_Combobox.ShowHeader
    '        If p_SQL <> "" Then
    '            p_Datatable = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
    '        End If
    '        If Not p_Datatable Is Nothing Then
    '            p_Combobox.Properties.DataSource = p_Datatable
    '            p_Combobox.Properties.DisplayMember = p_Datatable.Columns(1).ColumnName
    '            p_Combobox.Properties.ValueMember = p_Datatable.Columns(0).ColumnName
    '        Else
    '            p_Datatable = New DataTable("Table0")
    '            p_Col1 = New DataColumn("Code")
    '            p_Col1.DataType = GetType(String)
    '            p_Datatable.Columns.Add(p_Col1)
    '            p_Col1 = New DataColumn("Name")
    '            p_Col1.DataType = GetType(String)
    '            p_Datatable.Columns.Add(p_Col1)

    '            p_Combobox.Properties.DataSource = p_Datatable
    '            p_Combobox.Properties.DisplayMember = "Name"
    '            p_Combobox.Properties.ValueMember = "Code"
    '        End If

    '        If p_ShowHead = False Then
    '            p_Combobox.Properties.ShowHeader = False
    '        End If

    '    Catch ex As Exception
    '        p_ComboboxAddValueSQL = ex.Message
    '    End Try
    'End Function
    Public Sub GetCurrencyList()
        Dim p_SQL As String
        Dim p_DataTbl As New DataTable
        Dim p_Desc As String = ""
        Try
            If g_CurrencyDtl Is Nothing Then
                p_SQL = "select CurrCode , CurrName ,Decimals  from FPTOCRN where Locked='N'"
                g_CurrencyDtl = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Desc)
            Else

                If g_CurrencyDtl.Rows.Count <= 0 Then
                    p_SQL = "select CurrCode , CurrName ,Decimals  from FPTOCRN where Locked='N'"
                    g_CurrencyDtl = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Desc)
                End If
            End If
        Catch ex As Exception

        End Try
        p_SQL = "select  Currency, Decimals   from SYS_COMPANIES   where   DB_Name='" & g_Company_DB_Name & "'"
        p_DataTbl = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Desc)
        If p_Desc = "" Then
            g_Currency = "VND"
            g_CurrencyDecima = 0
            If Not p_DataTbl Is Nothing Then
                If p_DataTbl.Rows.Count > 0 Then
                    g_Currency = p_DataTbl.Rows(0).Item(0).ToString.Trim
                    If p_DataTbl.Rows(0).Item(1).ToString.Trim <> "" Then
                        g_CurrencyDecima = p_DataTbl.Rows(0).Item(1).ToString.Trim
                    End If
                End If
            End If
        Else
            MsgBox("GetCurrencyList:" & p_Desc)
        End If
    End Sub

    Public Function p_CheckApproved(ByVal p_form As Form, ByVal p_Module As String, ByVal g_DataApprove As DataTable, _
                                     ByVal p_User_ID As Double, ByVal p_UserName As String, _
                                    ByVal p_CompanyCode As String, ByVal p_CompanyName As String) As Boolean
        Dim p_Control() As Control
        Dim p_ControlApp() As Control
        Dim p_DataRow() As DataRow
        Dim p_Count As Integer
        Dim p_SQL As String
        Dim p_AppItem As String
        Dim p_Object As Object
        Dim p_Value As Double
        Dim p_Desc As String = ""

        p_CheckApproved = True
        p_DataRow = g_DataApprove.Select("FormName='" & p_form.Name & "'")
        If Not p_DataRow Is Nothing Then
            For p_Count = 0 To p_DataRow.Length - 1
                Try
                    p_Object = p_form.Controls.Item(p_DataRow(p_Count).Item("ItemNameApp").trim) ' p_form.Controls.Item(p_DataRow(p_Count).Item("ItemNameApp").trim, True)
                    If Not p_Object.editvalue Is Nothing Then
                        If p_Object.editvalue.ToString.Trim = "Y" Then
                            Continue For
                        End If
                    End If
                Catch ex As Exception
                    p_CheckApproved = False
                    MsgBox("Không xác định được trường thông tin phê duyệt")
                    Exit Function
                End Try
               
                p_Control = p_form.Controls.Find(p_DataRow(p_Count).Item("ItemName").trim, True)
                If p_Control.Length > 0 Then

                    ' p_Approved = False
                    If p_Control(0).GetType.Name = "U_TrueDBGrid" Then
                    Else
                        p_AppItem = p_DataRow(p_Count).Item("ItemNameApp").ToString.Trim
                        If p_AppItem <> "" Then
                            p_ControlApp = p_form.Controls.Find(p_AppItem, True)
                            If p_ControlApp.Length > 0 Then
                                If p_ControlApp(0).Text = "Y" Then

                                Else
                                    Double.TryParse(p_Control(0).Text.ToString.Trim, p_Value)
                                    If p_Value <> 0 Then
                                        Select Case p_DataRow(p_Count).Item("FromOperator").trim
                                            Case "="
                                                If p_Value = p_DataRow(p_Count).Item("FromValue") Then
                                                    p_CheckApproved = False
                                                    p_Desc = p_DataRow(p_Count).Item("MessShow")
                                                    Exit For
                                                End If
                                            Case ">="
                                                If p_Value >= p_DataRow(p_Count).Item("FromValue") Then
                                                    p_CheckApproved = False
                                                    p_Desc = p_DataRow(p_Count).Item("MessShow")
                                                    Exit For
                                                End If
                                            Case "<="
                                                If p_Value <= p_DataRow(p_Count).Item("FromValue") Then
                                                    p_CheckApproved = False
                                                    p_Desc = p_DataRow(p_Count).Item("MessShow")
                                                    Exit For
                                                End If
                                        End Select
                                    End If
                                End If

                            End If
                        End If
                    End If
                End If
                ' If p_Control.GetType Then
            Next
        End If
        If p_CheckApproved = False Then
            If MsgBox(p_Desc, MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1) = MsgBoxResult.Yes Then

                p_SendForApproved("FPTSO", p_form, p_User_ID, p_UserName, p_CompanyCode, p_CompanyName)


            End If
        End If
    End Function

    Public Sub p_SendForApproved(ByVal p_Module As String, ByVal p_Form As Form, ByVal p_User_ID As Double, ByVal p_UserName As String,
                                    ByVal p_CompanyCode As String, ByVal p_CompanyName As String)
        Dim p_Control_Ind As Integer
        Dim p_Control_Ind1 As Integer
        Dim p_Object As Object
        Dim p_KeyObj As String
        Dim p_Value As String = ""
        Dim p_SQL As String
        Dim p_DataTable As New DataTable
        Dim p_ObjectEdit As Object
        Dim p_FormApp As New FrmSendAppr
        Dim p_TableName As String = ""
        For p_Control_Ind = 0 To p_Form.Controls.Count - 1
            p_Object = p_Form.Controls.Item(p_Control_Ind)

            'Tinh cho cac control khong tinh U_TrueDBGrid
            If p_Object.GetType.Name <> "U_TrueDBGrid" Then
                'p_Value = ""
                Try
                    p_KeyObj = p_Object.Primarykey
                    If p_KeyObj.ToString.Trim = "Y" Then
                        Try
                            If Not p_Object.editvalue Is Nothing Then
                                p_Value = p_Object.editvalue
                                p_TableName = p_Object.TableName
                                Exit For
                            End If
                        Catch ex As Exception

                        End Try
                    End If
                Catch ex As Exception

                End Try
            End If
        Next
        If p_Value.ToString.Trim <> "" Then
            p_SQL = "SELECT " & p_User_ID & " as USER_ID,N'" & p_UserName & "' as USER_NAME,'" & p_CompanyCode & "' as CompanyCode, " & _
                "N'" & p_CompanyName & "' as CompanyName,   " & _
                "'" & p_Value & "' as FieldValue, N'" & p_Form.Text & "' as FormTitle, a.IDApp ,[AppName]  ,[Module] as Module1,[FormName] ,[ItemName] ,[ColumnName],[FromOperator]" & _
                              ",[FromValue] ,[ToValue],[FromDis] ,[ToDis] ,[ToOperator] ,[ItemNameApp],[ColumnNameApp],[MessShow]," & _
                              "a.TableName, b.[Desc] as RollDesc,c.USER_ID as APPUSERID, USER_NAME as AppUser, C.DESCRIPTION as DescUser, C.EMAIL_ADDRESS as AppMail  " & _
                                " FROM  [FPTAPP]  A ,  FPTAPPUSRERROLL  B , SYS_USER c where a.IDApp=b.IDApp and B.USER_ID=c.USER_ID " & _
                                " and a.Module='" & p_Module & "' AND FormName='" & p_Form.Name & "'"

            p_DataTable = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    For p_Control_Ind1 = 0 To p_FormApp.Controls.Count - 1
                        Try
                            p_ObjectEdit = p_FormApp.Controls.Item(p_Control_Ind1)
                            'If p_ObjectEdit.name = "Module1" Then
                            '    MsgBox("dfgdg")
                            'End If
                            If p_DataTable.Rows(0).Item(p_ObjectEdit.name).ToString.Trim <> "" Then
                                p_ObjectEdit = p_FormApp.Controls.Item(p_Control_Ind1)
                                p_ObjectEdit.text = p_DataTable.Rows(0).Item(p_ObjectEdit.name).ToString.Trim
                            End If
                        Catch ex As Exception

                        End Try

                    Next
                End If
            End If
        Else
            MsgBox("Không xác định giao dịch")
            Exit Sub
        End If
        Try
            p_ObjectEdit = p_Form.Controls.Item(p_DataTable.Rows(0).Item("ItemName").ToString.Trim)
            If Not p_ObjectEdit.editvalue Is Nothing Then
                p_Value = p_ObjectEdit.editvalue
                p_ObjectEdit = p_FormApp.Controls.Item("ValueApp")
                p_ObjectEdit.text = p_Value

                p_ObjectEdit = p_FormApp.Controls.Item("CrDate")
                p_ObjectEdit.text = Date.Now


            End If

        Catch ex As Exception

        End Try


        ' End If
        ' Next
        p_FormApp.ShowDialog()
    End Sub


    Public Function p_GridExportToExcel(ByVal p_TrueDBGrid As U_TextBox.U_TrueDBGrid, _
                                                ByRef p_Err As String) As Boolean

        Dim myStream As Stream = Nothing
        Dim SaveFileDialog1 As New SaveFileDialog()
        Dim p_GridView As New DevExpress.XtraGrid.Views.Grid.GridView
        Dim p_Path As String = ""

        Try
            p_GridExportToExcel = True
            SaveFileDialog1.InitialDirectory = "c:\"
            SaveFileDialog1.Filter = "xls|*.xls|xlsx|*.xlsx"
            SaveFileDialog1.FilterIndex = 2
            SaveFileDialog1.RestoreDirectory = True

            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                p_Path = SaveFileDialog1.FileName
                If p_Path <> "" Then
                    If InStr(p_Path, ".xlsx", CompareMethod.Text) > 0 Then
                        p_GridView = p_TrueDBGrid.Views(0)
                        p_GridView.OptionsView.ColumnAutoWidth = False

                        p_GridView.OptionsPrint.AutoWidth = False
                        p_GridView.BestFitColumns()
                        'p_TrueDBGrid.ExportToXlsx(p_Path)
                    ElseIf InStr(p_Path, ".xls", CompareMethod.Text) > 0 Then
                        p_GridView = p_TrueDBGrid.Views(0)
                        p_GridView.OptionsView.ColumnAutoWidth = False

                        p_GridView.OptionsPrint.AutoWidth = False
                        p_GridView.BestFitColumns()
                        'p_TrueDBGrid.ExportToXls(p_Path)
                    Else
                        p_GridExportToExcel = False
                        p_Err = "Sai định dạng file excel"
                    End If
                End If
            End If




            'p_GridExportToExcel = True
            'If p_Path <> "" Then
            '    If InStr(p_Path, ".xlsx", CompareMethod.Text) > 0 Then
            '        p_TrueDBGrid.ExportToXlsx(p_Path)
            '    ElseIf InStr(p_Path, ".xls", CompareMethod.Text) > 0 Then
            '        p_TrueDBGrid.ExportToXls(p_Path)
            '    Else
            '        p_GridExportToExcel = False
            '        p_Err = "Sai định dạng file excel"
            '    End If
            'End If
        Catch ex As Exception
            p_GridExportToExcel = False
            p_Err = ex.Message
        End Try
    End Function


    Public Function p_GridExportToExcelNew(ByVal p_TrueDBGrid As U_TextBox.TrueDBGrid, _
                                                ByRef p_Err As String) As Boolean

        Dim myStream As Stream = Nothing
        Dim SaveFileDialog1 As New SaveFileDialog()
        Dim p_GridView As New DevExpress.XtraGrid.Views.Grid.GridView
        Dim p_Path As String = ""

        Try
            p_GridExportToExcelNew = True
            SaveFileDialog1.InitialDirectory = "c:\"
            SaveFileDialog1.Filter = "xls|*.xls|xlsx|*.xlsx"
            SaveFileDialog1.FilterIndex = 2
            SaveFileDialog1.RestoreDirectory = True



            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                p_Path = SaveFileDialog1.FileName
                If p_Path <> "" Then
                    If InStr(p_Path, ".xlsx", CompareMethod.Text) > 0 Then                        
                        p_GridView = p_TrueDBGrid.Views(0)
                        p_GridView.OptionsView.ColumnAutoWidth = False

                        p_GridView.OptionsPrint.AutoWidth = False
                        p_GridView.BestFitColumns()

                        p_GridView.ExportToXlsx(p_Path)
                        'grdExport.DataSource = ds;


                        'vOptions.TextExportMode = TextExportMode.Text;
                        'vOptions.ShowGridLines = true;
                        'vOptions.SheetName = "Test";

                        'prmFileName = "Test.xls";

                        'grdExport.ExportToXls(prmFileName, vOptions);

                        Dim result As Integer = MessageBox.Show("Do you want to open this file", "Message", MessageBoxButtons.YesNo) 'hieptd4 add 20161001
                        If result = DialogResult.No Then Exit Function 'hieptd4 add 20161001

                        Process.Start(p_Path)
                        'p_TrueDBGrid.ExportToXlsx(p_Path)
                    ElseIf InStr(p_Path, ".xls", CompareMethod.Text) > 0 Then
                        p_GridView = p_TrueDBGrid.Views(0)
                        p_GridView.OptionsView.ColumnAutoWidth = False
                        p_GridView.OptionsPrint.AutoWidth = False
                        p_GridView.BestFitColumns()
                        'p_TrueDBGrid.ExportToXls(p_Path)
                        Process.Start(p_Path)
                    Else
                        p_GridExportToExcelNew = False
                        p_Err = "Sai định dạng file excel"
                    End If
                End If
            End If




            'p_GridExportToExcel = True
            'If p_Path <> "" Then
            '    If InStr(p_Path, ".xlsx", CompareMethod.Text) > 0 Then
            '        p_TrueDBGrid.ExportToXlsx(p_Path)
            '    ElseIf InStr(p_Path, ".xls", CompareMethod.Text) > 0 Then
            '        p_TrueDBGrid.ExportToXls(p_Path)
            '    Else
            '        p_GridExportToExcel = False
            '        p_Err = "Sai định dạng file excel"
            '    End If
            'End If
        Catch ex As Exception
            p_GridExportToExcelNew = False
            p_Err = ex.Message
        End Try
    End Function
    'anhqh
    '10/10/2012
    'Ham thuc hien lay NextNumber trong bang NNM1 cua B1

    Public Function p_Get_NetNumber_B1(ByVal p_Series As Integer, ByVal p_Object_Code As String) As Integer
        Dim p_SQL As String = "SELECT NextNumber FROM NNM1 WHERE ObjectCode = '" & p_Object_Code & "' AND Series=" & p_Series
        Dim p_Table As DataTable
        ' Dim p_Sysbat As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        p_Get_NetNumber_B1 = 1
        p_Table = g_Service.mod_SYS_GET_DATATABLE_Com(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item(0).ToString = "" Then
                    p_Get_NetNumber_B1 = 0
                Else
                    p_Get_NetNumber_B1 = p_Table.Rows(0).Item(0).ToString
                End If

            End If
        End If
        ' p_Sysbat = Nothing
    End Function

    'anhqh
    '01/10/2012
    'Ham thuc hien kiem tra trung nhau cua 1 code
    Public Function p_CheckExist_Code(ByVal p_Item As Object, _
                                      Optional ByVal p_B1Get As Boolean = False) As Boolean
        p_CheckExist_Code = False
        Dim p_SQL As String = ""
        Dim p_TableName As String = ""
        Dim p_FieldName As String = ""
        Dim p_Value As String = ""
        Dim p_Type As String = ""
        'Dim p_sys As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        Dim p_table As New DataTable
        p_TableName = p_Item.TableName
        p_Value = p_Item.EditValue.ToString
        p_FieldName = p_Item.FieldName
        If p_Value Is Nothing Then
            Exit Function
        End If
        If p_Value.ToString = "" Or p_TableName = "" Then
            Exit Function
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
            If p_B1Get = True Then
                p_table = g_Service.mod_SYS_GET_DATATABLE_Com(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_SQL)
            Else
                p_table = g_Service.SysGetDataTable(p_SQL)
            End If
            If Not p_table Is Nothing Then
                If p_table.Rows.Count > 0 Then
                    p_CheckExist_Code = True
                End If
            End If
            p_table = Nothing
            ' p_sys = Nothing
        End If
    End Function

    'ANHQH
    '01/10/2012
    'Ham thuc hien chuyen di lieu tu Grid thanh SQL roi exec
    Public Function p_TrueDBGirdToDatabase(ByVal p_TrueDbGird As U_TextBox.U_TrueDBGrid, _
                                          ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                          ByRef p_TrueGirdLineAdd() As Boolean, _
                                          ByRef p_TrueGirdLineUpd() As Boolean, _
                                          ByRef p_TrueGirdLineDel() As String, _
                                          Optional ByVal p_GetB1 As Boolean = True _
                                           ) As String
        Dim p_ColumnKey As String = ""
        Dim p_SQL_Upd As String = ""
        Dim p_SQL_Del As String = ""
        Dim p_Where As String = ""
        Dim p_Field_Ins As String = ""
        Dim p_Field_Value As String = ""
        Dim p_DataSet As New DataSet
        Dim p_Count As Integer        'Dim p_Key As String
        Dim p_Col As Integer
        Dim p_String As String = UCase("System.String")
        Dim p_DateTime As String = UCase("System.DateTime")
        Dim p_Int As String = UCase("System.Int32,System.Int16,System.Decimal,System.Double")
        Dim p_DataType As String
        Dim p_FieldName As String
        Dim p_TableName As String
        Dim p_TblStructure As New DataSet
        Dim p_Rows() As DataRow
        'Dim p_DataSet As New DataSet
        Dim p_Table As New DataTable("TableTemp")
        Dim p_Col1 As New DataColumn("Column0")
        Dim p_Row As DataRow
        ' Dim p_FptModule As New FPTModule.Class1(g_UserName, g_Company_Code, g_Service, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DB_Name)
        Dim p_Desc As String
        Dim p_Done As Boolean
        Dim p_CellValue As String
        Dim p_ColumnKeyIns As String

        Dim p_ColumnEnableUpdate As String = ""
        Dim p_ColumnVisibleUpdate As String = ""
        Dim p_SQLExecute() As String

        p_Col1.DataType = GetType(String)
        p_Table.Columns.Add(p_Col1)
        p_TrueDBGirdToDatabase = "TRUE"
        If p_DataSet.Tables.Count > 0 Then
            p_DataSet.Tables.Remove("TableTemp")
        End If


        p_DataSet.Tables.Add(p_Table)



        Try
            p_ColumnKey = p_TrueDbGird.ColumnKey
            p_ColumnKeyIns = p_TrueDbGird.ColumnKeyIns

            p_ColumnEnableUpdate = p_TrueDbGird.ColumnEnableUpdate
            p_ColumnVisibleUpdate = p_TrueDbGird.ColumnVisibleUpdate

            If p_ColumnKey = "" Then
                p_TrueDBGirdToDatabase = "ColumnKey Chua co gia tri"
                Exit Function

            End If
            p_TableName = UCase(p_TrueDbGird.TableName)
            If p_TableStructure(p_TableName, p_TblStructure, p_GetB1) = False Then
                Exit Function
            End If
            If p_TblStructure.Tables.Count <= 0 Then
                p_TrueDBGirdToDatabase = "Không tìm được cấu trúc bảng " & p_TableName
                Exit Function
            End If

            If p_TblStructure.Tables(0).Rows.Count <= 0 Then
                p_TrueDBGirdToDatabase = "Không tìm được cấu trúc bảng " & p_TableName
                Exit Function
            End If

            'p_TrueDbGird.e()
            'p_Key = p_TrueDbGird.Columns.Item(p_ColumnKey).Value.ToString()
            ' p_GridView.MoveFirst()
            ReDim p_SQLExecute(0 To p_GridView.RowCount - 1)

            For p_Count = 0 To p_GridView.RowCount - 1
                p_SQL_Upd = ""
                'If p_Count = 31 Then
                '    MsgBox("sdfdsfsf")
                'End If
                p_Field_Value = ""
                p_Field_Ins = ""
                p_SQL_Del = ""
                If p_TrueGirdLineAdd(p_Count) = True Then
                    'INSERT
                    For p_Col = 0 To p_GridView.Columns.Count - 1


                        p_DataType = p_GridView.Columns(p_Col).ColumnType.ToString
                        p_FieldName = p_GridView.Columns(p_Col).FieldName.ToString
                        If p_FieldName <> "" Then

                            p_Rows = p_TblStructure.Tables(0).Select("COLUMN_NAME='" & p_FieldName & "'")
                            If p_Rows.Count > 0 Then
                                Try
                                    p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString

                                    p_CellValue = Replace(p_CellValue, "''''", """", 1)
                                    p_CellValue = Replace(p_CellValue, "'''", """", 1)
                                    p_CellValue = Replace(p_CellValue, "''", """", 1)
                                    p_CellValue = Replace(p_CellValue, "'", """", 1)


                                    If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                        'Number
                                        If (p_ColumnKey = p_FieldName And p_ColumnKeyIns = "N") Then
                                        Else
                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                            p_Field_Value = p_Field_Value & "," & _
                                                       IIf(p_CellValue = "", 0, p_CellValue)
                                        End If
                                    ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                        'String
                                        If p_ColumnKey = p_FieldName And p_ColumnKeyIns = "N" Then
                                        Else
                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                            p_Field_Value = p_Field_Value & ",N'" & _
                                                    p_CellValue & "'"
                                        End If
                                    ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                        'DateTime
                                        p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                        p_Field_Value = p_Field_Value & "," & _
                                          IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                                p_Convert_Date(p_CellValue) & "')")
                                    End If

                                Catch ex As Exception

                                End Try
                            End If
                        End If
                    Next
                ElseIf p_TrueGirdLineUpd(p_Count) = True Then
                    'Update
                    p_SQL_Upd = ""
                    p_Where = ""
                    For p_Col = 0 To p_GridView.Columns.Count - 1
                        'If p_Col = 54 Then
                        '    MsgBox("sdfdsfsf")
                        'End If
                        p_DataType = UCase(p_GridView.Columns(p_Col).ColumnType.ToString)
                        p_FieldName = p_GridView.Columns(p_Col).FieldName.ToString
                        p_Rows = p_TblStructure.Tables(0).Select("COLUMN_NAME='" & p_FieldName & "'")
                        If p_Rows.Count > 0 Then
                            p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                            p_CellValue = Replace(p_CellValue, "''''", """", 1)
                            p_CellValue = Replace(p_CellValue, "'''", """", 1)
                            p_CellValue = Replace(p_CellValue, "''", """", 1)
                            p_CellValue = Replace(p_CellValue, "'", """", 1)

                            If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                'Number
                                If p_ColumnKey = p_FieldName Then
                                    p_Where = " WHERE " & p_ColumnKey & "=" & IIf(p_CellValue = "", 0, _
                                            p_CellValue)
                                Else
                                    If (p_ColumnVisibleUpdate = "A" And p_ColumnEnableUpdate = "A") Or (p_ColumnVisibleUpdate = "" And p_ColumnEnableUpdate = "") Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                   IIf(p_CellValue = "", 0, p_CellValue)
                                        Continue For
                                    End If
                                    If (p_ColumnVisibleUpdate = "Y") And p_GridView.Columns(p_Col).Visible = True Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                   IIf(p_CellValue = "", 0, p_CellValue)
                                        Continue For
                                    End If
                                    If (p_ColumnEnableUpdate = "Y") And p_GridView.Columns(p_Col).OptionsColumn.AllowEdit = True And p_GridView.Columns(p_Col).Visible = True Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                   IIf(p_CellValue = "", 0, p_CellValue)
                                        Continue For
                                    End If
                                End If
                            ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                'String
                                If p_ColumnKey = p_FieldName Then
                                    p_Where = " WHERE " & p_ColumnKey & "=N'" & p_CellValue & "'"
                                Else
                                    'p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                    '        p_CellValue & "'"
                                    If (p_ColumnVisibleUpdate = "A" And p_ColumnEnableUpdate = "A") Or (p_ColumnVisibleUpdate = "" And p_ColumnEnableUpdate = "") Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                            p_CellValue & "'"
                                        Continue For
                                    End If
                                    If (p_ColumnVisibleUpdate = "Y") And p_GridView.Columns(p_Col).Visible = True Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                            p_CellValue & "'"
                                        Continue For
                                    End If
                                    If (p_ColumnEnableUpdate = "Y") And p_GridView.Columns(p_Col).OptionsColumn.AllowEdit = True And p_GridView.Columns(p_Col).Visible = True Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                            p_CellValue & "'"
                                        Continue For
                                    End If
                                End If
                            ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                'DateTime
                                'p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                '  IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                '        p_Convert_Date(p_CellValue) & "')")
                                If (p_ColumnVisibleUpdate = "A" And p_ColumnEnableUpdate = "A") Or (p_ColumnVisibleUpdate = "" And p_ColumnEnableUpdate = "") Then
                                    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                            p_Convert_Date(p_CellValue) & "')")
                                    Continue For
                                End If
                                If (p_ColumnVisibleUpdate = "Y") And p_GridView.Columns(p_Col).Visible = True Then
                                    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                            p_Convert_Date(p_CellValue) & "')")
                                    Continue For
                                End If
                                If (p_ColumnEnableUpdate = "Y") And p_GridView.Columns(p_Col).OptionsColumn.AllowEdit = True And p_GridView.Columns(p_Col).Visible = True Then
                                    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                            p_Convert_Date(p_CellValue) & "')")
                                    Continue For
                                End If
                            End If
                        End If

                    Next
                ElseIf Not p_TrueGirdLineDel(p_Count) Is Nothing Then
                    If p_TrueGirdLineDel(p_Count).ToString <> "" Then
                        For p_Col = 0 To p_GridView.Columns.Count - 1
                            p_DataType = UCase(p_GridView.Columns(p_Col).ColumnType.ToString)
                            p_FieldName = p_GridView.Columns(p_Col).FieldName.ToString
                            If p_ColumnKey = p_FieldName Then
                                If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                    p_SQL_Del = "DELETE " & p_TableName & " WHERE " & p_ColumnKey & "=" & p_TrueGirdLineDel(p_Count).ToString
                                ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                    p_SQL_Del = "DELETE " & p_TableName & " WHERE " & p_ColumnKey & "='" & p_TrueGirdLineDel(p_Count).ToString & "'"
                                End If
                            End If
                        Next

                    End If
                End If
                If p_SQL_Upd <> "" And p_Where <> "" Then
                    p_SQL_Upd = "UPDATE " & p_TableName & " SET " & Mid(p_SQL_Upd, 2) & p_Where
                    p_Row = p_DataSet.Tables(0).NewRow

                    p_Row("Column0") = p_SQL_Upd
                    p_DataSet.Tables("TableTemp").Rows.Add(p_Row)

                    p_SQLExecute(p_Count) = p_SQL_Upd
                ElseIf p_Field_Ins <> "" And p_Field_Value <> "" Then
                    p_Field_Ins = Mid(Trim(p_Field_Ins), 2)
                    p_Field_Value = Mid(Trim(p_Field_Value), 2)
                    p_Field_Ins = "INSERT INTO " & p_TableName & " (" & p_Field_Ins & ") VALUES (" & p_Field_Value & ")"
                    p_Row = p_DataSet.Tables(0).NewRow

                    p_Row("Column0") = p_Field_Ins
                    p_DataSet.Tables("TableTemp").Rows.Add(p_Row)

                    p_SQLExecute(p_Count) = p_Field_Ins
                ElseIf p_SQL_Del <> "" Then
                    p_Row = p_DataSet.Tables(0).NewRow
                    p_Row("Column0") = p_SQL_Del
                    p_DataSet.Tables("TableTemp").Rows.Add(p_Row)

                    p_SQLExecute(p_Count) = p_SQL_Del
                End If
                If p_DataSet.Tables(0).Rows.Count - 1 = 50 Then
                    'If p_DataSet.Tables.Count > 0 Then
                    'If p_DataSet.Tables(0).Rows.Count > 0 Then
                    If p_GetB1 = True Then
                        p_Done = g_Service.SysExecuteDataSet_Company(p_DataSet)
                    Else
                        p_Done = g_Service.Sys_Execute_DataTbl(p_DataSet.Tables(0), p_Desc)
                    End If
                    If p_Done = False Then
                        p_TrueDBGirdToDatabase = p_Desc
                        Exit Function
                    End If
                    'Else
                    '    p_Done = True
                    'End If
                    p_DataSet.Tables(0).Clear()
                End If

            Next
            If p_DataSet.Tables.Count > 0 Then
                If p_DataSet.Tables(0).Rows.Count > 0 Then
                    If p_GetB1 = True Then
                        p_Done = g_Service.SysExecuteDataSet_Company(p_DataSet)
                    Else
                        'p_Done = g_Service.SysExecuteDataSet(p_DataSet.Tables(0), p_Desc)
                        p_Done = g_Service.Sys_Execute_DataTbl(p_DataSet.Tables(0), p_Desc)
                        'SysExecuteSqlArray
                    End If
                Else
                    p_Done = True
                End If
            Else
                p_Done = True
            End If
            If p_Done = True Then
                For p_Count = 0 To UBound(p_TrueGirdLineAdd, 1)
                    p_TrueGirdLineAdd(p_Count) = False
                    p_TrueGirdLineUpd(p_Count) = False
                Next
            Else
                p_TrueDBGirdToDatabase = p_Desc
            End If
            'p_FptModule = Nothing
            'p_Sysbatch = Nothing
        Catch ex As Exception
            p_TrueDBGirdToDatabase = ex.Message.ToString
            'p_FptModule = Nothing
            'p_Sysbatch = Nothing
        End Try
    End Function


    'anhqh
    '26/03/2014
    'Ham thuc hien kiem tra xem banr ghi ton tai chua
    'Neu ton tai tra ve 1

    'Loi tra ve -1
    Private Function p_CheckRowExists(ByRef p_Desc As String, ByVal p_HeaderControlKey As Object, _
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

    'ANHQH
    '01/10/2012
    'Ham thuc hien chuyen di lieu tu Grid thanh SQL roi exec
    'Dungf cho form dang Header va Line
    Public Function p_CompileTrueDBGirdLineToSQL(ByVal p_RecordHist As Boolean, _
                                                 ByVal p_TrueDbGird As U_TextBox.U_TrueDBGrid, _
                                          ByVal p_GridViewIn As DevExpress.XtraGrid.Views.Grid.GridView, _
                                          ByVal p_HeaderControlKey As Object, _
                                          ByRef p_DataTable As DataTable, _
                                           ByVal p_GetB1 As Boolean, _
                                           Optional ByVal p_UserName As String = "") As String
        Dim p_ColumnCHECKUPDate As String = ""
        Dim p_ColumnKey As String = ""
        Dim p_SQL_Upd As String = ""
        Dim p_SQL_Del As String = ""
        Dim p_Where As String = ""
        Dim p_Field_Ins As String = ""
        Dim p_Field_Value As String = ""
        Dim p_DataSet As New DataSet
        Dim p_Count As Integer        'Dim p_Key As String
        Dim p_Col As Integer
        Dim p_String As String = UCase("System.String")
        Dim p_DateTime As String = UCase("System.DateTime, System.Date")
        Dim p_Int As String = UCase("System.Int32,System.Int16,System.Decimal,System.Double")
        Dim p_DataType As String
        Dim p_FieldName As String
        Dim p_TableName As String
        Dim p_TblStructure As New DataSet
        Dim p_Rows() As DataRow

        Dim p_RowsCheck() As DataRow
        'Dim p_DataSet As New DataSet
        'Dim p_Table As New DataTable("TableTemp")
        Dim p_Col1 As New DataColumn("Column0")
        Dim p_Row As DataRow
        '  Dim p_FptModule As New FPTModule.Class1(g_Service, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DB_Name)
        Dim p_Desc As String
        ' Dim p_Done As Boolean
        Dim p_CellValue As String
        Dim p_ColumnKeyIns As String

        Dim p_ColumnEnableUpdate As String = ""
        Dim p_ColumnVisibleUpdate As String = ""
        '  Dim p_SQLExecute() As String
        Dim p_HeaderKeyValue As String
        Dim p_Dt As DataTable
        'Dim p_ColumnKey As String
        Dim p_ColumnKeyType As String
        Dim p_Check As Integer
        Dim p_DataCheck As DataTable

        Dim p_Insert As Boolean
        Dim p_RowArr() As DataRow
        Dim p_TimeValue As Integer
        Dim p_DateValue As Date
        Dim p_Count1 As Integer
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView

        p_ColumnKeyType = p_TrueDbGird.ColumnKeyType
        If p_DataTable Is Nothing Then
            p_DataTable = New DataTable("Table0")
            p_Col1.DataType = GetType(String)
            p_DataTable.Columns.Add(p_Col1)
        Else
            If p_DataTable.Columns.Count <= 0 Then
                p_Col1.DataType = GetType(String)
                p_DataTable.Columns.Add(p_Col1)
            End If
        End If
        p_CompileTrueDBGirdLineToSQL = "TRUE"
        'If p_DataSet.Tables.Count > 0 Then
        '    p_DataSet.Tables.Remove("TableTemp")
        'End If
        p_ColumnKey = p_TrueDbGird.ColumnKey
        p_ColumnKeyIns = p_TrueDbGird.ColumnKeyIns
        p_TableName = UCase(p_TrueDbGird.TableName)
        'anhqh
        '26/06/2014
        'Lay các giá trị de tìm kiém
        p_Check = p_CheckRowExists(p_Desc, p_HeaderControlKey,
                                      p_ColumnKey,
                                       p_TableName,
                                       p_DataCheck)

        If p_Check = -1 Then
            p_DataTable = Nothing
            MsgBox(p_Desc)
            Exit Function
        End If

        p_HeaderKeyValue = p_HeaderControlKey.EditValue.ToString

        If p_ColumnKeyType.ToString <> "N" And p_ColumnKeyType.ToString <> "C" Then
            p_DataTable = Nothing
            MsgBox("Kiểu dữ liệu của Column Key chưa khai báo")
            Exit Function
        End If
        p_Desc = ""
        Try


            p_ColumnEnableUpdate = p_TrueDbGird.ColumnEnableUpdate
            p_ColumnVisibleUpdate = p_TrueDbGird.ColumnVisibleUpdate

            If p_ColumnKey = "" Then
                p_CompileTrueDBGirdLineToSQL = "ColumnKey chưa khai báo"
                Exit Function

            End If

            If p_TableStructure(p_TableName, p_TblStructure, p_GetB1) = False Then
                Exit Function
            End If
            If p_TblStructure.Tables.Count <= 0 Then
                p_CompileTrueDBGirdLineToSQL = "Không tìm được cấu trúc bảng " & p_TableName
                Exit Function
            End If

            If p_TblStructure.Tables(0).Rows.Count <= 0 Then
                p_CompileTrueDBGirdLineToSQL = "Không tìm được cấu trúc bảng " & p_TableName
                Exit Function
            End If

            'p_TrueDbGird.e()
            'p_Key = p_TrueDbGird.Columns.Item(p_ColumnKey).Value.ToString()
            ' p_GridView.MoveFirst()
            'ReDim p_SQLExecute(0 To p_GridView.RowCount - 1)

            p_GridView = p_GridViewIn

            Try
                p_ColumnCHECKUPDate = p_GridView.Columns.Item("CHECKUPD").FieldName.ToString.Trim
            Catch ex As Exception
                p_ColumnCHECKUPDate = ""
            End Try

            If p_ColumnCHECKUPDate <> "" Then
                p_GridView.ActiveFilterString = p_ColumnCHECKUPDate & "='Y'"
            End If

            If p_RecordHist = True Then
                p_Dt = g_Service.mod_SYS_GET_DATATABLE("exec  FPT_CheckFieldHist '" & p_TableName & "'")
            End If


            For p_Count = 0 To p_GridView.RowCount - 1


                p_Insert = True
                p_SQL_Upd = ""

                p_Field_Value = ""
                p_Field_Ins = ""
                p_SQL_Del = ""

                If p_GridView.IsDataRow(p_Count) = False Then
                    Continue For
                End If

                Try
                    p_CellValue = p_GridView.GetRowCellValue(p_Count, p_ColumnKey).ToString
                Catch ex As Exception
                    p_GridView.ClearColumnsFilter()
                    p_Desc = "CompileTrueDBGirdLineToSQL: " & p_ColumnKey & "-" & ex.Message
                    p_DataTable = Nothing
                    MsgBox(p_Desc)
                    Exit Function
                End Try

                If p_CellValue.Trim <> "" Then
                    If p_ColumnKeyType = "N" Then
                        p_RowsCheck = p_DataCheck.Select(p_ColumnKey & "=" & p_CellValue)
                    Else
                        p_RowsCheck = p_DataCheck.Select(p_ColumnKey & "='" & p_CellValue & "'")
                    End If
                    If p_RowsCheck.Length > 0 Then
                        p_Insert = False
                    End If
                End If
                If p_Insert = True Then
                    'INSERT
                    For p_Col = 0 To p_GridView.Columns.Count - 1


                        p_DataType = p_GridView.Columns(p_Col).ColumnType.ToString
                        p_FieldName = p_GridView.Columns(p_Col).FieldName.ToString
                        'If p_FieldName = "DocEntryReturn" Then
                        '    MsgBox("dff")
                        'End If
                        If p_FieldName <> "" Then
                            'If UCase(p_FieldName) = "DOCENTRY" Then
                            '    MsgBox("sdfsdfsd")
                            'End If

                            p_Rows = p_TblStructure.Tables(0).Select("COLUMN_NAME='" & p_FieldName & "'")
                            If p_Rows.Count > 0 Then
                                Try
                                    If UCase(p_HeaderControlKey.FieldName.ToString.Trim) = UCase(p_FieldName.Trim) Then
                                        p_CellValue = p_HeaderKeyValue
                                    Else
                                        p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                    End If

                                    p_CellValue = Replace(p_CellValue, "''''", """", 1)
                                    p_CellValue = Replace(p_CellValue, "'''", """", 1)
                                    p_CellValue = Replace(p_CellValue, "''", """", 1)
                                    p_CellValue = Replace(p_CellValue, "'", """", 1)


                                    If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                        'Number
                                        If (p_ColumnKey = p_FieldName And p_ColumnKeyIns = "N") Then
                                        Else
                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                            p_Field_Value = p_Field_Value & "," & _
                                                       IIf(p_CellValue = "", 0, p_CellValue)
                                        End If
                                    ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                        'String
                                        If p_ColumnKey = p_FieldName And p_ColumnKeyIns = "N" Then
                                        Else
                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                            p_Field_Value = p_Field_Value & ",N'" & _
                                                    p_CellValue & "'"
                                        End If
                                    ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                        'DateTime
                                        p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                        p_Field_Value = p_Field_Value & "," & _
                                          IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                                p_Convert_Date(p_CellValue) & "')")
                                    End If

                                Catch ex As Exception

                                End Try
                            End If
                        End If
                    Next
                Else
                    'Update
                    p_SQL_Upd = ""
                    p_Where = ""
                    For p_Col = 0 To p_GridView.Columns.Count - 1
                        'If p_Col = 54 Then
                        '    MsgBox("sdfdsfsf")
                        'End If
                        p_DataType = UCase(p_GridView.Columns(p_Col).ColumnType.ToString)
                        p_FieldName = p_GridView.Columns(p_Col).FieldName.ToString
                        p_Rows = p_TblStructure.Tables(0).Select("COLUMN_NAME='" & p_FieldName & "'")
                        If p_Rows.Count > 0 Then
                            p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                            p_CellValue = Replace(p_CellValue, "''''", """", 1)
                            p_CellValue = Replace(p_CellValue, "'''", """", 1)
                            p_CellValue = Replace(p_CellValue, "''", """", 1)
                            p_CellValue = Replace(p_CellValue, "'", """", 1)

                            If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                'Number
                                If p_ColumnKey = p_FieldName Then
                                    p_Where = " WHERE " & p_ColumnKey & "=" & IIf(p_CellValue = "", 0, _
                                            p_CellValue)
                                Else
                                    If (p_ColumnVisibleUpdate = "A" And p_ColumnEnableUpdate = "A") Or (p_ColumnVisibleUpdate = "" And p_ColumnEnableUpdate = "") Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                   IIf(p_CellValue = "", 0, p_CellValue)
                                        Continue For
                                    End If
                                    If (p_ColumnVisibleUpdate = "Y") And p_GridView.Columns(p_Col).Visible = True Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                   IIf(p_CellValue = "", 0, p_CellValue)
                                        Continue For
                                    End If
                                    If (p_ColumnEnableUpdate = "Y") And p_GridView.Columns(p_Col).OptionsColumn.AllowEdit = True And p_GridView.Columns(p_Col).Visible = True Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                   IIf(p_CellValue = "", 0, p_CellValue)
                                        Continue For
                                    End If
                                End If
                            ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                'String
                                If p_ColumnKey = p_FieldName Then
                                    p_Where = " WHERE " & p_ColumnKey & "=N'" & p_CellValue & "'"
                                Else
                                    'p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                    '        p_CellValue & "'"
                                    If (p_ColumnVisibleUpdate = "A" And p_ColumnEnableUpdate = "A") Or (p_ColumnVisibleUpdate = "" And p_ColumnEnableUpdate = "") Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                            p_CellValue & "'"
                                        Continue For
                                    End If
                                    If (p_ColumnVisibleUpdate = "Y") And p_GridView.Columns(p_Col).Visible = True Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                            p_CellValue & "'"
                                        Continue For
                                    End If
                                    If (p_ColumnEnableUpdate = "Y") And p_GridView.Columns(p_Col).OptionsColumn.AllowEdit = True And p_GridView.Columns(p_Col).Visible = True Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                            p_CellValue & "'"
                                        Continue For
                                    End If
                                End If
                            ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                'DateTime
                                'p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                '  IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                '        p_Convert_Date(p_CellValue) & "')")
                                If (p_ColumnVisibleUpdate = "A" And p_ColumnEnableUpdate = "A") Or (p_ColumnVisibleUpdate = "" And p_ColumnEnableUpdate = "") Then
                                    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                            p_Convert_Date(p_CellValue) & "')")
                                    Continue For
                                End If
                                If (p_ColumnVisibleUpdate = "Y") And p_GridView.Columns(p_Col).Visible = True Then
                                    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                            p_Convert_Date(p_CellValue) & "')")
                                    Continue For
                                End If
                                If (p_ColumnEnableUpdate = "Y") And p_GridView.Columns(p_Col).OptionsColumn.AllowEdit = True And p_GridView.Columns(p_Col).Visible = True Then
                                    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                            p_Convert_Date(p_CellValue) & "')")
                                    Continue For
                                End If
                            End If
                        End If

                    Next

                End If
                If p_SQL_Upd <> "" And p_Where <> "" Then
                    If p_RecordHist = True And Not p_Dt Is Nothing Then

                        p_RowArr = p_Dt.Select("ColumnName='UPDATEDATE' or ColumnName='UPDATETIME' Or ColumnName='UPDATEBY'")

                        p_GetDateTime(p_DateValue, p_TimeValue)
                        For p_Count1 = 0 To p_RowArr.Length - 1
                            If p_RowArr(p_Count1).Item(1) = 40 Or p_RowArr(p_Count1).Item(1) = 61 Then  'Date
                                'p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(1)
                                'p_Field_Value = p_Field_Value & ",'" & p_DateValue.ToString("yyyyMMdd") & "'"

                                p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "='" & p_DateValue.ToString("yyyyMMdd") & "'"
                            End If

                            If p_RowArr(p_Count1).Item(1) = 52 Or p_RowArr(p_Count1).Item(1) = 56 Then  'Time
                                'p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(1)
                                'p_Field_Value = p_Field_Value & "," & p_TimeValue

                                p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "=" & p_TimeValue
                            End If

                            If p_RowArr(p_Count1).Item(1) = 231 Or p_RowArr(p_Count1).Item(1) = 175 Then  'CreatedBy
                                'p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(1)
                                'p_Field_Value = p_Field_Value & ",'" & g_UserName & "'"

                                p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "='" & p_UserName & "'"
                            End If
                        Next
                    End If

                    p_SQL_Upd = "UPDATE " & p_TableName & " SET " & Mid(p_SQL_Upd, 2) & p_Where
                    p_Row = p_DataTable.NewRow

                    p_Row(0) = p_SQL_Upd
                    p_DataTable.Rows.Add(p_Row)

                    ' p_SQLExecute(p_Count) = p_SQL_Upd
                ElseIf p_Field_Ins <> "" And p_Field_Value <> "" Then
                    If p_RecordHist = True And Not p_Dt Is Nothing Then
                        p_RowArr = p_Dt.Select("ColumnName='CREATEDATE' or ColumnName='CREATETIME' Or ColumnName='CREATEDBY'")

                        p_GetDateTime(p_DateValue, p_TimeValue)
                        For p_Count1 = 0 To p_RowArr.Length - 1
                            If p_RowArr(p_Count1).Item(1) = 40 Or p_RowArr(p_Count1).Item(1) = 61 Then  'Date
                                p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count1).Item(0)
                                p_Field_Value = p_Field_Value & ",'" & p_DateValue.ToString("yyyyMMdd") & "'"
                            End If

                            If p_RowArr(p_Count1).Item(1) = 52 Or p_RowArr(p_Count1).Item(1) = 56 Then  'Time
                                p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count1).Item(0)
                                p_Field_Value = p_Field_Value & "," & p_TimeValue
                            End If

                            If p_RowArr(p_Count1).Item(1) = 231 Or p_RowArr(p_Count1).Item(1) = 175 Then  'CreatedBy
                                p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count1).Item(0)
                                p_Field_Value = p_Field_Value & ",'" & p_UserName & "'"
                            End If


                        Next
                    End If

                    p_Field_Ins = Mid(Trim(p_Field_Ins), 2)
                    p_Field_Value = Mid(Trim(p_Field_Value), 2)
                    p_Field_Ins = "INSERT INTO " & p_TableName & " (" & p_Field_Ins & ") VALUES (" & p_Field_Value & ")"
                    p_Row = p_DataTable.NewRow

                    p_Row(0) = p_Field_Ins
                    p_DataTable.Rows.Add(p_Row)

                End If


            Next
            p_GridViewIn.ClearColumnsFilter()
            'If p_Table.Rows.Count > 0 Then
            '    p_DataTable = p_Table
            'End If
            ' p_FptModule = Nothing
            'p_Sysbatch = Nothing
        Catch ex As Exception
            p_GridViewIn.ClearColumnsFilter()
            p_CompileTrueDBGirdLineToSQL = ex.Message.ToString
            '  p_FptModule = Nothing
            'p_Sysbatch = Nothing
        End Try
    End Function

    'ANHQH
    '01/10/2012
    'Ham thuc hien chuyen di lieu tu Grid thanh SQL roi exec

    Public Function p_CompileTrueDBGirdToSQL(ByVal p_DataSet_TrueGird As DataSet, _
                                             ByVal p_Form As Object, ByVal p_RecordHist As Boolean, _
                                             ByVal p_TrueDbGird As U_TextBox.U_TrueDBGrid, _
                                          ByVal p_GridViewIn As DevExpress.XtraGrid.Views.Grid.GridView, _
                                          ByRef p_DataTable As DataTable, _
                                           ByVal p_GetB1 As Boolean,
                                           Optional ByVal p_ColumnCHECKUPDate As String = "", _
                                           Optional ByVal p_UserName As String = "") As String
        Dim p_ColumnKey As String = ""
        Dim p_SQL_Upd As String = ""
        Dim p_SQL_Del As String = ""
        Dim p_Where As String = ""
        Dim p_Field_Ins As String = ""
        Dim p_Field_Value As String = ""
        ' Dim p_DataSet As New DataSet
        Dim p_Count As Integer        'Dim p_Key As String
        Dim p_Count1 As Integer
        Dim p_Col As Integer
        Dim p_String As String = UCase("System.String")
        Dim p_DateTime As String = UCase("System.DateTime")
        Dim p_Int As String = UCase("System.Int32,System.Int16,System.Decimal,System.Double")
        Dim p_DataType As String
        Dim p_FieldName As String
        Dim p_TableName As String
        Dim p_TblStructure As New DataSet
        Dim p_Rows() As DataRow
        Dim p_RowArr() As DataRow
        Dim p_TimeValue As Integer
        Dim p_DateValue As Date
        ' Dim p_RowsCheck() As DataRow
        'Dim p_DataSet As New DataSet
        'Dim p_Table As New DataTable("TableTemp")
        Dim p_Col1 As New DataColumn("Column0")
        Dim p_Row As DataRow
        ' Dim p_FptModule As New FPTModule.Class1(g_Service, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DB_Name)
        Dim p_Desc As String
        'Dim p_Done As Boolean
        Dim p_CellValue As String
        Dim p_ColumnKeyIns As String

        Dim p_ColumnEnableUpdate As String = ""
        Dim p_ColumnVisibleUpdate As String = ""
        'Dim p_SQLExecute() As String
        ' Dim p_HeaderKeyValue As String

        'Dim p_ColumnKey As String
        Dim p_ColumnKeyType As String
        Dim p_DataCheck As DataTable
        Dim p_Dt As DataTable
        ' Dim p_Check As Integer
        'Dim p_DataCheck As DataTable

        Dim p_SQL As String
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView

        Dim p_Insert As Integer    'Danh dau loai cap nhat(1:Addnew    2: Update     0: khong lam gi)
        ' Dim p_Dt As DataTable


        p_ColumnKeyType = p_TrueDbGird.ColumnKeyType
        If p_DataTable Is Nothing Then
            p_DataTable = New DataTable("Table0")
            p_Col1.DataType = GetType(String)
            p_DataTable.Columns.Add(p_Col1)
        Else
            If p_DataTable.Columns.Count <= 0 Then
                p_Col1.DataType = GetType(String)
                p_DataTable.Columns.Add(p_Col1)
            End If
        End If
        p_CompileTrueDBGirdToSQL = "TRUE"
        'If p_DataSet.Tables.Count > 0 Then
        '    p_DataSet.Tables.Remove("TableTemp")
        'End If
        p_ColumnKey = p_TrueDbGird.ColumnKey
        p_ColumnKeyIns = p_TrueDbGird.ColumnKeyIns
        p_TableName = UCase(p_TrueDbGird.TableName)
        'anhqh
        '26/06/2014
        'Lay các giá trị de tìm kiém

        If p_RecordHist = True Then
            p_Dt = g_Service.mod_SYS_GET_DATATABLE("exec  FPT_CheckFieldHist '" & p_TableName & "'")
        End If

        If p_ColumnKeyType.ToString <> "N" And p_ColumnKeyType.ToString <> "C" Then
            p_DataTable = Nothing
            MsgBox("Kiểu dữ liệu của Column Key chưa khai báo")
            Exit Function
        End If
        p_Desc = ""
        Try


            p_ColumnEnableUpdate = p_TrueDbGird.ColumnEnableUpdate
            p_ColumnVisibleUpdate = p_TrueDbGird.ColumnVisibleUpdate

            If p_ColumnKey = "" Then
                p_CompileTrueDBGirdToSQL = "ColumnKey chưa khai báo"
                Exit Function

            End If

            If p_TableStructure(p_TableName, p_TblStructure, p_GetB1) = False Then
                Exit Function
            End If
            If p_TblStructure.Tables.Count <= 0 Then
                p_CompileTrueDBGirdToSQL = "Không tìm được cấu trúc bảng " & p_TableName
                Exit Function
            End If

            If p_TblStructure.Tables(0).Rows.Count <= 0 Then
                p_CompileTrueDBGirdToSQL = "Không tìm được cấu trúc bảng " & p_TableName
                Exit Function
            End If

            'p_TrueDbGird.e()
            'p_Key = p_TrueDbGird.Columns.Item(p_ColumnKey).Value.ToString()
            ' p_GridView.MoveFirst()
            'ReDim p_SQLExecute(0 To p_GridView.RowCount - 1)

            p_GridView = p_GridViewIn



            If p_ColumnCHECKUPDate <> "" Then
                p_GridView.ActiveFilterString = p_ColumnCHECKUPDate & "='Y' Or " & p_ColumnCHECKUPDate & "='I'"
            End If

            If p_CheckRequiredGridView(p_Form.Name,
                                                     p_TrueDbGird.Name,
                                                   p_GridView,
                                                     p_DataSet_TrueGird) = False Then
                p_CompileTrueDBGirdToSQL = "ERROR"

                ' MsgBox(p_SQL)
                Exit Function
            End If
            For p_Count = 0 To p_GridView.RowCount - 1
                p_Insert = 0
                p_SQL_Upd = ""

                p_Field_Value = ""
                p_Field_Ins = ""
                p_SQL_Del = ""

                If p_GridView.IsDataRow(p_Count) = False Then
                    Continue For
                End If

                Try
                    p_CellValue = p_GridView.GetRowCellValue(p_Count, p_ColumnKey).ToString
                Catch ex As Exception
                    p_DataTable = Nothing
                    MsgBox(p_Desc)
                    Exit Function
                End Try
                p_Insert = 1
                If p_CellValue.ToString.Trim <> "" Then
                    If p_ColumnKeyType = "N" Then
                        'p_RowsCheck = p_DataCheck.Select(p_ColumnKey & "=" & p_CellValue)
                        p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_TableName & " Where " & p_ColumnKey & "=" & p_CellValue & "'"
                    Else
                        p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_TableName & " Where " & p_ColumnKey & "=''" & p_CellValue & "'''"
                    End If
                    p_DataCheck = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
                    If p_DataCheck.Rows.Count > 0 Then
                        p_Insert = 2
                        If p_GridView.GetRowCellValue(p_Count, "CHECKUPD").ToString.Trim = "I" Then
                            p_GridView.ClearColumnsFilter()
                            ErrException("MS0001", "Bản ghi đã tồn tại")
                            p_DataTable = Nothing
                            Exit Function
                        End If
                    End If
                    'If p_RowsCheck.Length > 0 Then
                    '    p_Insert = False
                    'End If
                    'If p_ColumnCHECKUPDate.Trim <> "" Then
                    '    Try
                    '        p_CellValue = p_GridView.GetRowCellValue(p_Count, p_ColumnCHECKUPDate.Trim).ToString
                    '        If p_CellValue.Trim = "Y" Then
                    '            p_Insert = 2
                    '        Else
                    '            p_Insert = 0
                    '        End If
                    '    Catch ex As Exception
                    '        p_DataTable = Nothing
                    '        MsgBox(p_Desc)
                    '        Exit Function
                    '    End Try
                    'Else
                    '    p_Insert = 2
                    'End If               
                End If
                If p_Insert = 1 Then
                    'INSERT
                    For p_Col = 0 To p_GridView.Columns.Count - 1


                        p_DataType = p_GridView.Columns(p_Col).ColumnType.ToString
                        p_FieldName = p_GridView.Columns(p_Col).FieldName.ToString
                        If p_FieldName <> "" Then
                            'If UCase(p_FieldName) = "DOCENTRY" Then
                            '    MsgBox("sdfsdfsd")
                            'End If

                            p_Rows = p_TblStructure.Tables(0).Select("COLUMN_NAME='" & p_FieldName & "'")
                            If p_Rows.Count > 0 Then
                                Try
                                    'If UCase(p_HeaderControlKey.FieldName.ToString.Trim) = UCase(p_FieldName.Trim) Then
                                    '    p_CellValue = p_HeaderKeyValue
                                    'Else
                                    p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                    'End If

                                    p_CellValue = Replace(p_CellValue, "''''", """", 1)
                                    p_CellValue = Replace(p_CellValue, "'''", """", 1)
                                    p_CellValue = Replace(p_CellValue, "''", """", 1)
                                    p_CellValue = Replace(p_CellValue, "'", """", 1)


                                    If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                        'Number
                                        If (p_ColumnKey = p_FieldName And p_ColumnKeyIns = "N") Then
                                        Else
                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                            p_Field_Value = p_Field_Value & "," & _
                                                       IIf(p_CellValue = "", 0, p_CellValue)
                                        End If
                                    ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                        'String
                                        If p_ColumnKey = p_FieldName And p_ColumnKeyIns = "N" Then
                                        Else
                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                            p_Field_Value = p_Field_Value & ",N'" & _
                                                    p_CellValue & "'"
                                        End If
                                    ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                        'DateTime
                                        p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                        p_Field_Value = p_Field_Value & "," & _
                                          IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                                p_Convert_Date(p_CellValue) & "')")
                                    End If

                                Catch ex As Exception

                                End Try
                            End If
                        End If
                    Next
                ElseIf p_Insert = 2 Then
                    'Update
                    p_SQL_Upd = ""
                    p_Where = ""
                    For p_Col = 0 To p_GridView.Columns.Count - 1
                        'If p_Col = 54 Then
                        '    MsgBox("sdfdsfsf")
                        'End If
                        p_DataType = UCase(p_GridView.Columns(p_Col).ColumnType.ToString)
                        p_FieldName = p_GridView.Columns(p_Col).FieldName.ToString
                        p_Rows = p_TblStructure.Tables(0).Select("COLUMN_NAME='" & p_FieldName & "'")
                        If p_Rows.Count > 0 Then
                            p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                            p_CellValue = Replace(p_CellValue, "''''", """", 1)
                            p_CellValue = Replace(p_CellValue, "'''", """", 1)
                            p_CellValue = Replace(p_CellValue, "''", """", 1)
                            p_CellValue = Replace(p_CellValue, "'", """", 1)

                            If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                'Number
                                If p_ColumnKey = p_FieldName Then
                                    p_Where = " WHERE " & p_ColumnKey & "=" & IIf(p_CellValue = "", 0, _
                                            p_CellValue)
                                Else
                                    If (p_ColumnVisibleUpdate = "A" And p_ColumnEnableUpdate = "A") Or (p_ColumnVisibleUpdate = "" And p_ColumnEnableUpdate = "") Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                   IIf(p_CellValue = "", 0, p_CellValue)
                                        Continue For
                                    End If
                                    If (p_ColumnVisibleUpdate = "Y") And p_GridView.Columns(p_Col).Visible = True Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                   IIf(p_CellValue = "", 0, p_CellValue)
                                        Continue For
                                    End If
                                    If (p_ColumnEnableUpdate = "Y") And p_GridView.Columns(p_Col).OptionsColumn.AllowEdit = True And p_GridView.Columns(p_Col).Visible = True Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                   IIf(p_CellValue = "", 0, p_CellValue)
                                        Continue For
                                    End If
                                End If
                            ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                'String
                                If p_ColumnKey = p_FieldName Then
                                    p_Where = " WHERE " & p_ColumnKey & "=N'" & p_CellValue & "'"
                                Else
                                    'p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                    '        p_CellValue & "'"
                                    If (p_ColumnVisibleUpdate = "A" And p_ColumnEnableUpdate = "A") Or (p_ColumnVisibleUpdate = "" And p_ColumnEnableUpdate = "") Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                            p_CellValue & "'"
                                        Continue For
                                    End If
                                    If (p_ColumnVisibleUpdate = "Y") And p_GridView.Columns(p_Col).Visible = True Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                            p_CellValue & "'"
                                        Continue For
                                    End If
                                    If (p_ColumnEnableUpdate = "Y") And p_GridView.Columns(p_Col).OptionsColumn.AllowEdit = True And p_GridView.Columns(p_Col).Visible = True Then
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                            p_CellValue & "'"
                                        Continue For
                                    End If
                                End If
                            ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                'DateTime
                                'p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                '  IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                '        p_Convert_Date(p_CellValue) & "')")
                                If (p_ColumnVisibleUpdate = "A" And p_ColumnEnableUpdate = "A") Or (p_ColumnVisibleUpdate = "" And p_ColumnEnableUpdate = "") Then
                                    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                            p_Convert_Date(p_CellValue) & "')")
                                    Continue For
                                End If
                                If (p_ColumnVisibleUpdate = "Y") And p_GridView.Columns(p_Col).Visible = True Then
                                    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                            p_Convert_Date(p_CellValue) & "')")
                                    Continue For
                                End If
                                If (p_ColumnEnableUpdate = "Y") And p_GridView.Columns(p_Col).OptionsColumn.AllowEdit = True And p_GridView.Columns(p_Col).Visible = True Then
                                    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                            p_Convert_Date(p_CellValue) & "')")
                                    Continue For
                                End If
                            End If
                        End If

                    Next

                End If
                If p_Insert = 1 Or p_Insert = 2 Then
                    If p_SQL_Upd <> "" And p_Where <> "" Then

                        If p_RecordHist = True And Not p_Dt Is Nothing Then

                            p_RowArr = p_Dt.Select("ColumnName='UPDATEDATE' or ColumnName='UPDATETIME' Or ColumnName='UPDATEBY'")

                            p_GetDateTime(p_DateValue, p_TimeValue)
                            For p_Count1 = 0 To p_RowArr.Length - 1
                                If p_RowArr(p_Count1).Item(1) = 40 Or p_RowArr(p_Count1).Item(1) = 61 Then  'Date
                                    'p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(1)
                                    'p_Field_Value = p_Field_Value & ",'" & p_DateValue.ToString("yyyyMMdd") & "'"

                                    p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "='" & p_DateValue.ToString("yyyyMMdd") & "'"
                                End If

                                If p_RowArr(p_Count1).Item(1) = 52 Or p_RowArr(p_Count1).Item(1) = 56 Then  'Time
                                    'p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(1)
                                    'p_Field_Value = p_Field_Value & "," & p_TimeValue

                                    p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "=" & p_TimeValue
                                End If

                                If p_RowArr(p_Count1).Item(1) = 231 Or p_RowArr(p_Count1).Item(1) = 175 Then  'CreatedBy
                                    'p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(1)
                                    'p_Field_Value = p_Field_Value & ",'" & g_UserName & "'"

                                    p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "='" & p_UserName & "'"
                                End If
                            Next
                        End If

                        p_SQL_Upd = "UPDATE " & p_TableName & " SET " & Mid(p_SQL_Upd, 2) & p_Where
                        p_Row = p_DataTable.NewRow

                        p_Row(0) = p_SQL_Upd
                        p_DataTable.Rows.Add(p_Row)

                        ' p_SQLExecute(p_Count) = p_SQL_Upd
                    ElseIf p_Field_Ins <> "" And p_Field_Value <> "" Then

                        If p_RecordHist = True And Not p_Dt Is Nothing Then
                            p_RowArr = p_Dt.Select("ColumnName='CREATEDATE' or ColumnName='CREATETIME' Or ColumnName='CREATEDBY'")

                            p_GetDateTime(p_DateValue, p_TimeValue)
                            For p_Count1 = 0 To p_RowArr.Length - 1
                                If p_RowArr(p_Count1).Item(1) = 40 Or p_RowArr(p_Count1).Item(1) = 61 Then  'Date
                                    p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count1).Item(0)
                                    p_Field_Value = p_Field_Value & ",'" & p_DateValue.ToString("yyyyMMdd") & "'"
                                End If

                                If p_RowArr(p_Count1).Item(1) = 52 Or p_RowArr(p_Count1).Item(1) = 56 Then  'Time
                                    p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count1).Item(0)
                                    p_Field_Value = p_Field_Value & "," & p_TimeValue
                                End If

                                If p_RowArr(p_Count1).Item(1) = 231 Or p_RowArr(p_Count1).Item(1) = 175 Then  'CreatedBy
                                    p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count1).Item(0)
                                    p_Field_Value = p_Field_Value & ",'" & p_UserName & "'"
                                End If


                            Next
                        End If

                        p_Field_Ins = Mid(Trim(p_Field_Ins), 2)
                        p_Field_Value = Mid(Trim(p_Field_Value), 2)
                        p_Field_Ins = "INSERT INTO " & p_TableName & " (" & p_Field_Ins & ") VALUES (" & p_Field_Value & ")"
                        p_Row = p_DataTable.NewRow

                        p_Row(0) = p_Field_Ins
                        p_DataTable.Rows.Add(p_Row)

                    End If
                End If

            Next

            'If p_Table.Rows.Count > 0 Then
            '    p_DataTable = p_Table
            'End If
            'p_FptModule = Nothing
            p_GridView.ClearColumnsFilter()
            'p_Sysbatch = Nothing
        Catch ex As Exception
            p_GridView.ClearColumnsFilter()
            p_CompileTrueDBGirdToSQL = ex.Message.ToString
            ' p_FptModule = Nothing
            'p_Sysbatch = Nothing
        End Try
    End Function

    'ANHQH
    '01/10/2012
    'Ham thuc hien chuyen di lieu tu Grid thanh p_TrueDBGirdToDataTable
    Public Function p_TrueDBGirdToDataTable(ByVal p_TrueDbGird As U_TextBox.U_TrueDBGrid, _
                                          ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                          ByRef p_TrueGirdLineAdd() As Boolean, _
                                          ByRef p_TrueGirdLineUpd() As Boolean, _
                                          ByRef p_TrueGirdLineDel() As String, _
                                          ByRef p_DataTable_Exe As DataTable, _
                                          Optional ByVal p_GetB1 As Boolean = False _
                                           ) As String
        Dim p_ColumnKey As String = ""
        Dim p_SQL_Upd As String = ""
        Dim p_SQL_Del As String = ""
        Dim p_Where As String = ""
        Dim p_Field_Ins As String = ""
        Dim p_Field_Value As String = ""
        Dim p_DataSet As New DataSet
        Dim p_Count As Integer        'Dim p_Key As String
        Dim p_Col As Integer
        Dim p_String As String = UCase("System.String")
        Dim p_DateTime As String = UCase("System.DateTime")
        Dim p_Int As String = UCase("System.Int32,System.Int16,System.Decimal")
        Dim p_DataType As String
        Dim p_FieldName As String
        Dim p_TableName As String
        Dim p_Table_Structure As New DataSet
        Dim p_Rows() As DataRow
        'Dim p_DataSet As New DataSet
        Dim p_Table As New DataTable("TableTemp")
        Dim p_Col1 As DataColumn
        Dim p_Row As DataRow
        ' Dim p_FptModule As New FPTModule.Class1(g_Service, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DB_Name)
        ' Dim p_Sysbatch As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        'Dim p_Done As Boolean
        Dim p_CellValue As String
        Dim p_ColumnKeyIns As String

        If p_DataTable_Exe.Columns.Count <= 0 Then
            p_Col1 = New DataColumn
            p_Col1.ColumnName = "Col1"
            p_Col1.DataType = GetType(String)
            p_DataTable_Exe.Columns.Add(p_Col1)

        End If
        p_Col1 = New DataColumn
        p_Col1.ColumnName = "Column0"
        p_Col1.DataType = GetType(String)
        p_Table.Columns.Add(p_Col1)
        p_TrueDBGirdToDataTable = "TRUE"
        If p_DataSet.Tables.Count > 0 Then
            p_DataSet.Tables.Remove("TableTemp")
        End If


        p_DataSet.Tables.Add(p_Table)



        Try
            p_ColumnKey = p_TrueDbGird.ColumnKey
            p_ColumnKeyIns = p_TrueDbGird.ColumnKeyIns
            If p_ColumnKey = "" Then
                p_TrueDBGirdToDataTable = "ColumnKey Chua co gia tri"
                Exit Function

            End If
            p_TableName = UCase(p_TrueDbGird.TableName)
            If p_TableStructure(p_TableName, p_Table_Structure, p_GetB1) = False Then
                Exit Function
            End If
            If p_Table_Structure.Tables.Count <= 0 Then
                p_TrueDBGirdToDataTable = "Không tìm được cấu trúc bảng " & p_TableName
                Exit Function
            End If

            If p_Table_Structure.Tables(0).Rows.Count <= 0 Then
                p_TrueDBGirdToDataTable = "Không tìm được cấu trúc bảng " & p_TableName
                Exit Function
            End If


            For p_Count = 0 To p_GridView.RowCount - 1
                p_SQL_Upd = ""
                p_Field_Value = ""
                p_Field_Ins = ""
                p_SQL_Del = ""
                If p_TrueGirdLineAdd(p_Count) = True Then
                    'INSERT
                    For p_Col = 0 To p_GridView.Columns.Count - 1
                        p_DataType = UCase(p_GridView.Columns(p_Col).ColumnType.ToString)
                        p_FieldName = UCase(p_GridView.Columns(p_Col).FieldName.ToString)
                        If p_FieldName <> "" Then
                            p_Rows = p_Table_Structure.Tables(0).Select("COLUMN_NAME='" & p_FieldName & "'")
                            If p_Rows.Count > 0 Then

                                p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString


                                If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                    'Number
                                    If (UCase(p_ColumnKey) = UCase(p_FieldName) And p_ColumnKeyIns = "N") Then
                                    Else
                                        p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                        p_Field_Value = p_Field_Value & "," & _
                                                   IIf(p_CellValue = "", 0, p_CellValue)
                                    End If
                                ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                    'String
                                    If UCase(p_ColumnKey) = UCase(p_FieldName) And p_ColumnKeyIns = "N" Then
                                    Else
                                        p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                        p_Field_Value = p_Field_Value & ",N'" & _
                                                p_CellValue & "'"
                                    End If
                                ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                    'DateTime
                                    p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                    p_Field_Value = p_Field_Value & "," & _
                                      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                            p_Convert_Date(p_CellValue) & "')")
                                End If
                            End If
                        End If
                    Next
                ElseIf p_TrueGirdLineUpd(p_Count) = True Then
                    'Update
                    p_SQL_Upd = ""
                    p_Where = ""
                    For p_Col = 0 To p_GridView.Columns.Count - 1
                        p_DataType = UCase(p_GridView.Columns(p_Col).ColumnType.ToString)
                        p_FieldName = UCase(p_GridView.Columns(p_Col).FieldName.ToString)
                        p_Rows = p_Table_Structure.Tables(0).Select("COLUMN_NAME='" & p_FieldName & "'")
                        If p_Rows.Count > 0 Then
                            p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                            If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                'Number
                                If UCase(p_ColumnKey) = UCase(p_FieldName) Then
                                    p_Where = " WHERE " & p_ColumnKey & "=" & IIf(p_CellValue = "", 0, _
                                            p_CellValue)
                                Else
                                    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                               IIf(p_CellValue = "", 0, p_CellValue)
                                End If

                            ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                'String
                                If UCase(p_ColumnKey) = UCase(p_FieldName) Then
                                    p_Where = " WHERE " & p_ColumnKey & "=N'" & p_CellValue & "'"
                                Else
                                    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                            p_CellValue & "'"
                                End If

                            ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                'DateTime
                                p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                  IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                        p_Convert_Date(p_CellValue) & "')")
                            End If
                        End If

                    Next
                ElseIf Not p_TrueGirdLineDel(p_Count) Is Nothing Then
                    If p_TrueGirdLineDel(p_Count).ToString <> "" Then
                        For p_Col = 0 To p_GridView.Columns.Count - 1
                            p_DataType = UCase(p_GridView.Columns(p_Col).ColumnType.ToString)
                            p_FieldName = UCase(p_GridView.Columns(p_Col).FieldName.ToString)
                            If UCase(p_ColumnKey) = UCase(p_FieldName) Then
                                If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                    p_SQL_Del = "DELETE " & p_TableName & " WHERE " & p_ColumnKey & "=" & p_TrueGirdLineDel(p_Count).ToString
                                ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                    p_SQL_Del = "DELETE " & p_TableName & " WHERE " & p_ColumnKey & "='" & p_TrueGirdLineDel(p_Count).ToString & "'"
                                End If
                            End If
                        Next

                    End If
                End If
                If p_SQL_Upd <> "" And p_Where <> "" Then
                    p_SQL_Upd = "UPDATE " & p_TableName & " SET " & Mid(p_SQL_Upd, 2) & p_Where
                    p_Row = p_DataSet.Tables(0).NewRow
                    p_Row("Column0") = p_SQL_Upd
                    p_DataSet.Tables("TableTemp").Rows.Add(p_Row)

                ElseIf p_Field_Ins <> "" And p_Field_Value <> "" Then
                    p_Field_Ins = Mid(Trim(p_Field_Ins), 2)
                    p_Field_Value = Mid(Trim(p_Field_Value), 2)
                    p_Field_Ins = "INSERT INTO " & p_TableName & " (" & p_Field_Ins & ") VALUES (" & p_Field_Value & ")"
                    p_Row = p_DataSet.Tables(0).NewRow
                    p_Row("Column0") = p_Field_Ins
                    p_DataSet.Tables("TableTemp").Rows.Add(p_Row)
                ElseIf p_SQL_Del <> "" Then
                    p_Row = p_DataSet.Tables(0).NewRow
                    p_Row("Column0") = p_SQL_Del
                    p_DataSet.Tables("TableTemp").Rows.Add(p_Row)
                End If
                '  p_GridView.MoveNext()
            Next
            If p_DataSet.Tables.Count > 0 Then
                For p_Count = 0 To p_DataSet.Tables(0).Rows.Count - 1
                    p_Row = p_DataTable_Exe.NewRow
                    p_Row(0) = p_DataSet.Tables(0).Rows(p_Count).Item(0).ToString
                    p_DataTable_Exe.Rows.Add(p_Row)
                Next
            End If

            ' p_FptModule = Nothing
        Catch ex As Exception
            p_TrueDBGirdToDataTable = ex.Message.ToString
            'p_FptModule = Nothing
        End Try
    End Function

    Public Function p_Set_TrueGrid_Property(ByRef p_Form As Object, _
                                            ByVal p_DataTrueGird As DataSet, _
                                            ByRef p_BindingSource As BindingSource, _
                                            ByRef p_TrueGird As U_TextBox.U_TrueDBGrid, _
                                                ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                                Optional ByVal B1Get As Boolean = True, _
                                                Optional ByVal p_Requery As Boolean = False, _
                                                Optional ByVal p_WhereExt As String = "") As Boolean
        Dim p_Count As Integer
        Dim p_CountTo As Integer
        Dim p_GirdName As String
        Dim p_Rows() As DataRow
        Dim p_FormName As String
        Dim p_Column As DevExpress.XtraGrid.Columns.GridColumn
        Dim p_Int As Integer
        Dim p_FieldNAme() As String
        Dim p_FieldCaption() As String
        Dim p_SQL As String = ""
        Dim p_ViewName As String = ""
        Dim p_NoCustomize As Boolean = False
        Dim p_FieldExist As Boolean = False
        Dim p_OrderBy As String
        Dim p_Page_Total As Integer
        Dim p_DataSet As New DataSet
        ' Dim p_DataSet As New DataSet
        Dim p_Count1 As Integer
        Dim p_Count2 As Integer
        Dim p_Allowinsert As String
        Dim p_Field As String
        Dim p_AutoColumnWidth As String
        Dim p_ColDate As New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        'Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Dim p_Where As String = ""
        Dim p_NumberFormat As String = "############"

        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

        ' Dim p_NumberDecimal As Integer
        Dim p_LocalDecimal As Integer

        Dim p_ColumnSum As Boolean = False

        Dim p_DataRow() As DataRow
        Dim p_FormLock As Boolean = False
        Dim p_SQLCombo As String = ""

        Try
            p_FormLock = p_Form.FormLock
        Catch ex As Exception

        End Try
        Try
            If p_BindingSource Is Nothing Then
                p_BindingSource = New BindingSource
            End If
            p_LocalDecimal = 0
            If Not g_CurrencyDtl Is Nothing Then
                If g_CurrencyDtl.Rows.Count <= 0 Then
                    GetCurrencyList()
                End If
                p_DataRow = g_CurrencyDtl.Select("CurrCode='" & g_Currency & "'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("Decimals") > 0 Then
                        p_LocalDecimal = p_DataRow(0).Item("Decimals")
                    End If
                End If
            End If

            p_GridView.OptionsBehavior.AllowAddRows = DefaultBoolean.True
            p_GridView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.True
            p_GridView.OptionsBehavior.Editable = True
            p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            p_GridView.OptionsNavigation.EnterMoveNextColumn = True

            p_FormName = UCase(p_Form.Name)
            p_GirdName = UCase(p_TrueGird.Name)
            p_ViewName = UCase(p_TrueGird.ViewName)
            p_OrderBy = UCase(p_TrueGird.OrderBy)
            p_Where = UCase(p_TrueGird.Where)
            p_AutoColumnWidth = UCase(p_TrueGird.ColumnAutoWidth)
            p_Allowinsert = UCase(p_TrueGird.AllowInsert)
            p_Set_TrueGrid_Property = True
            If p_ViewName = "" Then
                p_Set_TrueGrid_Property = False
                Exit Function
            End If
            If p_DataTrueGird Is Nothing Then
                MsgBox("p_DataTrueGird is nothing")
                p_Set_TrueGrid_Property = False
                Exit Function
            End If
            p_Rows = p_DataTrueGird.Tables(0).Select("FORM_NAME='" & p_FormName & _
                                                       "' AND GRID_NAME='" & p_GirdName & "'", "ORDER_BY")  '"FORM_NAME,Order_By")
            If p_Rows.Length > 0 Then
                For p_Count = 0 To p_Rows.Length - 1
                    If p_Field = "" Then
                        p_Field = p_Rows(p_Count).Item("COL_NAME").ToString
                    Else
                        p_Field = p_Field & "," & p_Rows(p_Count).Item("COL_NAME").ToString
                    End If
                Next
                p_SQL = "SELECT  " & p_Field & " FROM " & p_ViewName
            Else
                p_SQL = "SELECT  * FROM " & p_ViewName
            End If

            If p_Where <> "" Then
                p_SQL = p_SQL & " WHERE " & p_Where
                If p_WhereExt <> "" Then
                    p_SQL = p_SQL & " AND " & p_WhereExt
                End If
            Else
                If p_WhereExt <> "" Then
                    p_SQL = p_SQL & " WHERE " & p_WhereExt
                End If
            End If
            If p_OrderBy.ToString <> "" Then
                p_SQL = p_SQL & " ORDER BY " & p_OrderBy.ToString
            End If

            p_SQL = p_Parameter_Item(p_Form, p_SQL)
            Try
                p_TrueGird.LastQuery = p_SQL
            Catch ex As Exception

            End Try

            If B1Get = True Then
                p_BindingSource.DataSource = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQL).Tables(0)
            Else
                ' Dim p_DTSet As DataSet

                'p_DataSet = mod_SYS_GET_DATASET(p_SQL)
                'Dim dt As DataTable = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
                Dim dt As DataTable
                If g_DBTYPE = "ORACLE" Then
                    dt = g_Service.SYS_GET_DATATABLE_oracle(p_SQL)       'mod_SYS_GET_DATASET(p_SQL)
                ElseIf g_DBTYPE = "SQL" Then
                    dt = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)       'mod_SYS_GET_DATASET(p_SQL)
                End If

                If dt Is Nothing And p_SQL <> "" Then
                    MsgBox(p_SQL)
                    p_Set_TrueGrid_Property = False
                    Exit Function
                End If
                p_BindingSource.DataSource = dt  ' p_DataSet.Tables(0)  ' g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
            End If
            '  If p_BindingSource.Count <= 0 Then
            ' p_BindingSource.AddNew()
            '  End If

            If p_Requery = True Then
                p_BindingSource.ResetBindings(True)
                p_TrueGird.DataSource = p_BindingSource

                p_TrueGird.RefreshDataSource()
                p_GridView.RefreshData()
                Exit Function

            End If
            If p_DataTrueGird.Tables.Count > 0 Then
                p_Rows = p_DataTrueGird.Tables(0).Select("FORM_NAME='" & p_FormName & _
                                                         "' AND GRID_NAME='" & p_GirdName & "'", "FORM_NAME,GRID_NAME,Order_By")
            End If
            If p_Rows Is Nothing Then
                p_NoCustomize = False
            ElseIf p_Rows.Length <= 0 Then
                p_NoCustomize = False
            Else
                p_NoCustomize = True
            End If

            If p_NoCustomize = False Then
                'Cac Column khong duoc  khai bao trong bang GRID_PROPERTY

                ReDim p_FieldNAme(0 To p_GridView.Columns.Count - 1)
                ReDim p_FieldCaption(0 To p_GridView.Columns.Count - 1)
                For p_Count = 0 To p_GridView.Columns.Count - 1
                    p_FieldNAme(p_Count) = p_GridView.Columns(p_Count).FieldName
                    p_FieldCaption(p_Count) = p_GridView.Columns(p_Count).Caption

                Next
                p_TrueGird.DataSource = p_BindingSource
                p_BindingSource.ResetBindings(True)
                For p_Count = 0 To UBound(p_FieldNAme, 1)
                    p_GridView.Columns(p_Count).FieldName = p_FieldNAme(p_Count)
                    p_GridView.Columns(p_Count).Caption = p_FieldCaption(p_Count)

                Next
                p_TrueGird.Refresh()

            Else
                'Cac Column duoc khai bao trong bang GRID_PROPERTY
                p_TrueGird.DataSource = p_BindingSource
                p_BindingSource.ResetBindings(True)
                p_TrueGird.Refresh()

                'p_GridView.OptionsView.ColumnAutoWidth = False
                If p_AutoColumnWidth = "Y" Then
                    p_GridView.OptionsView.ColumnAutoWidth = True
                Else
                    p_GridView.OptionsView.ColumnAutoWidth = False
                End If
                For p_Count = 0 To p_Rows.Count - 1
                    Try

                        p_FieldExist = False
                        For p_Count1 = 0 To p_GridView.Columns.Count - 1
                            If UCase(p_GridView.Columns(p_Count1).FieldName) = UCase(p_Rows(p_Count).Item("COL_NAME").ToString) Then
                                p_FieldExist = True
                                Exit For

                            End If
                        Next
                        p_Int = p_Count1
                        If p_FieldExist = False Then
                            p_Column = New DevExpress.XtraGrid.Columns.GridColumn
                            p_Int = p_GridView.Columns.Add(p_Column)
                            p_GridView.Columns(p_Int).FieldName = p_Rows(p_Count).Item("COL_NAME").ToString
                        End If

                        If p_Rows(p_Count).Item("VISIBLE_FLAG").ToString = "N" Then
                            p_GridView.Columns(p_Int).Visible = False
                        Else
                            p_GridView.Columns(p_Int).Visible = True
                            If p_Rows(p_Count).Item("Required").ToString = "Y" Then
                                p_GridView.Columns(p_Int).AppearanceCell.BackColor = pv_Required_Back_Color
                                p_GridView.Columns(p_Int).AppearanceCell.BackColor2 = pv_Required_Back_Color
                            End If
                        End If
                        If p_Rows(p_Count).Item("CheckBox").ToString.Trim = "Y" Then
                            p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                            p_ColType.ValueChecked = "Y"
                            p_ColType.ValueUnchecked = "N"
                            p_GridView.Columns(p_Int).ColumnEdit = p_ColType
                        End If


                        If p_Rows(p_Count).Item("CAPTION").ToString <> "" Then
                            p_GridView.Columns(p_Int).Caption = p_Rows(p_Count).Item("CAPTION").ToString
                        Else
                            p_GridView.Columns(p_Int).Caption = p_Rows(p_Count).Item("COL_NAME").ToString
                        End If








                        p_GridView.Columns(p_Int).Name = p_Rows(p_Count).Item("COL_NAME").ToString
                        p_GridView.Columns(p_Int).OptionsColumn.AllowEdit = True

                        p_GridView.Columns(p_Int).Tag = p_Rows(p_Count).Item("DATA_TYPE").ToString


                        'p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
                        'p_TrueGird.RepositoryItems.Add(p_ColType)
                        'p_GridView.Columns("Nganh").ColumnEdit = p_ColType



                        If p_Rows(p_Count).Item("DATA_TYPE").ToString = "F" Or p_Rows(p_Count).Item("DATA_TYPE").ToString = "N" Then
                            If p_Rows(p_Count).Item("Digit").ToString.Trim = "Y" Then   'Co digit
                                If p_Rows(p_Count).Item("Decimals").ToString.Trim <> "" Then
                                    p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                    p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###0." & Left(p_NumberFormat, p_Rows(p_Count).Item("Decimals"))
                                Else
                                    p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                    p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###"

                                    ' p_GridView.Columns(p_Int).OptionsColumn.
                                End If
                            ElseIf p_Rows(p_Count).Item("Digit").ToString.Trim = "N" Then  'Khong digit
                                p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#############"
                            ElseIf p_Rows(p_Count).Item("Digit").ToString.Trim = "L" Then  'Khong digit   'LocalCurrency
                                p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###0." & Left(p_NumberFormat, p_LocalDecimal)

                            Else
                                p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###"
                            End If
                        End If



                        If p_Rows(p_Count).Item("DATA_TYPE").ToString = "D" Then
                            ' p_TrueGird.RepositoryItems.Add(p_ColDate)
                            p_GridView.Columns(p_Rows(p_Count).Item("COL_NAME").ToString).ColumnEdit = p_ColDate

                        End If
                        p_GridView.Columns(p_Int).ToolTip = p_Rows(p_Count).Item("COL_NAME").ToString  'p_Int


                        'If p_FormLock = True Then
                        '    p_GridView.Columns(p_Int).OptionsColumn.ReadOnly = True
                        'Else
                        If p_Rows(p_Count).Item("ENABLE_FLAG").ToString = "Y" Then
                            p_GridView.Columns(p_Int).OptionsColumn.ReadOnly = False
                        Else
                            p_GridView.Columns(p_Int).OptionsColumn.ReadOnly = True
                            p_GridView.Columns(p_Int).AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke
                        End If

                        ' End If

                        p_GridView.Columns(p_Int).OptionsColumn.AllowSize = True
                        If p_Rows(p_Count).Item("WIDTH").ToString <> "" Then
                            p_GridView.Columns(p_Int).Width = p_Rows(p_Count).Item("WIDTH").ToString
                            'Else
                        End If

                        'If p_Rows(p_Count).Item("CFL").ToString = "Y" Then
                        '    If p_Rows(p_Count).Item("ENABLE_FLAG").ToString = "Y" And p_Rows(p_Count).Item("VISIBLE_FLAG").ToString = "Y" Then
                        '        p_AddColumnTypeButtonEdit(p_TrueGird, p_GridView, p_Rows(p_Count).Item("COL_NAME").ToString)
                        '    End If
                        '    Continue For
                        'End If

                        If p_Rows(p_Count).Item("ComboBox").ToString = "Y" And p_Rows(p_Count).Item("ComboBoxSQL").ToString.Trim <> "" Then
                            ' If p_Rows(p_Count).Item("ENABLE_FLAG").ToString = "Y" And p_Rows(p_Count).Item("VISIBLE_FLAG").ToString = "Y" Then
                            p_SQLCombo = p_Rows(p_Count).Item("ComboBoxSQL").ToString.Trim
                            p_SQLCombo = p_Parameter_Item(p_Form, p_SQLCombo)
                            p_AddColumnTypeCombobox(p_TrueGird, p_GridView, p_Rows(p_Count).Item("COL_NAME").ToString,
                                                        p_SQLCombo,
                                                        p_Rows(p_Count).Item("ComboShowHeader").ToString.Trim,
                                                        p_Rows(p_Count).Item("DropDownRow").ToString.Trim)
                            'End If
                            Continue For
                        End If

                        'Them tổng cộng của Column
                        If p_Rows(p_Count).Item("ColumnSum").ToString.Trim = "Y" Then


                            If p_Rows(p_Count).Item("DATA_TYPE").ToString = "F" Or p_Rows(p_Count).Item("DATA_TYPE").ToString = "N" Then
                                Dim Totalitem As DevExpress.XtraGrid.GridColumnSummaryItem
                                If p_Rows(p_Count).Item("Digit").ToString.Trim = "Y" Then   'Co digit
                                    If p_Rows(p_Count).Item("Decimals").ToString.Trim <> "" Then

                                        Totalitem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, p_Rows(p_Count).Item("COL_NAME").ToString, "{0:n" & p_Rows(p_Count).Item("Decimals") & "}")
                                    Else

                                        Totalitem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, p_Rows(p_Count).Item("COL_NAME").ToString, "{0:n0}")
                                    End If
                                ElseIf p_Rows(p_Count).Item("Digit").ToString.Trim = "N" Then  'Khong digit
                                    Totalitem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, p_Rows(p_Count).Item("COL_NAME").ToString, "{0:n0}")
                                ElseIf p_Rows(p_Count).Item("Digit").ToString.Trim = "L" Then  'Khong digit   'LocalCurrency

                                    'Totalitem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, p_Rows(p_Count).Item("COL_NAME").ToString, "{0}")
                                    Totalitem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, p_Rows(p_Count).Item("COL_NAME").ToString, "{0:n" & p_LocalDecimal & "}")
                                Else
                                    Totalitem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, p_Rows(p_Count).Item("COL_NAME").ToString, "{0:n0}")
                                End If
                                If Not Totalitem Is Nothing Then
                                    'Totalitem.
                                    p_GridView.Columns(p_Rows(p_Count).Item("COL_NAME").ToString).Summary.Add(Totalitem)

                                    'p_GridView.Columns(p_Rows(p_Count).Item("COL_NAME").ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom

                                    p_ColumnSum = True
                                    'Totalitem = Nothing
                                End If
                            End If

                        End If


                        '

                    Catch ex As Exception

                    End Try
                Next

                For p_Count = 0 To p_GridView.Columns.Count - 1
                    Try
                        p_FieldExist = False
                        For p_Count1 = 0 To p_Rows.Count - 1
                            If UCase(p_GridView.Columns(p_Count).FieldName) = UCase(p_Rows(p_Count1).Item("COL_NAME").ToString) Then

                                p_FieldExist = True
                                Exit For
                            End If
                        Next
                        If p_FieldExist = False Then
                            p_GridView.Columns(p_Count).Visible = False
                        End If

                    Catch ex As Exception

                    End Try
                Next

                If p_Allowinsert = "N" Or p_FormLock = True Then
                    p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                Else
                    p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
                End If


                p_GridView.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll
                p_GridView.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveVertScroll
                p_GridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
                p_GridView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always

                If p_ColumnSum = True Then
                    p_GridView.OptionsView.ShowFooter = True
                    p_GridView.OptionsBehavior.SummariesIgnoreNullValues = True
                    p_GridView.OptionsBehavior.AutoUpdateTotalSummary = True

                End If

                If p_FormLock = True Then
                    p_GridView.OptionsBehavior.ReadOnly = True
                End If

                'p_TrueGird.Refresh()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            p_Set_TrueGrid_Property = False
        End Try



    End Function


    Public Function p_Get_TrueGrid_Property(ByRef p_Form As Form, _
                                            ByVal p_DataTrueGird As DataSet, _
                                            ByRef p_TrueGird As U_TextBox.U_TrueDBGrid, _
                                                ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Dim p_Count As Integer

        Dim p_GirdName As String
        Dim p_Rows() As DataRow
        Dim p_FormName As String
        Dim p_Column As DevExpress.XtraGrid.Columns.GridColumn
        Dim p_Int As Integer
        Dim p_SQL As String = ""
        Dim p_ViewName As String = ""
        Dim p_NoCustomize As Boolean = False
        Dim p_FieldExist As Boolean = False


        Dim p_Count1 As Integer

        Dim p_Allowinsert As String

        Dim p_AutoColumnWidth As String
        Dim p_ColDate As New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        'Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Dim p_Where As String = ""
        Dim p_NumberFormat As String = "############"

        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

        ' Dim p_NumberDecimal As Integer
        Dim p_LocalDecimal As Integer

        Dim p_ColumnSum As Boolean = False

        Dim p_DataRow() As DataRow


        Try
            p_Get_TrueGrid_Property = True
            p_FormName = p_Form.Name
            p_GirdName = p_TrueGird.Name
            p_LocalDecimal = 0
            p_AutoColumnWidth = p_TrueGird.ColumnAutoWidth
            If Not g_CurrencyDtl Is Nothing Then
                If g_CurrencyDtl.Rows.Count <= 0 Then
                    GetCurrencyList()
                End If
                p_DataRow = g_CurrencyDtl.Select("CurrCode='" & g_Currency & "'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("Decimals") > 0 Then
                        p_LocalDecimal = p_DataRow(0).Item("Decimals")
                    End If
                End If
            End If

            p_GridView.OptionsBehavior.AllowAddRows = DefaultBoolean.True
            p_GridView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.True
            p_GridView.OptionsBehavior.Editable = True
            p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            p_GridView.OptionsNavigation.EnterMoveNextColumn = True


            If p_DataTrueGird.Tables.Count > 0 Then
                p_Rows = p_DataTrueGird.Tables(0).Select("FORM_NAME='" & p_FormName & _
                                                         "' AND GRID_NAME='" & p_GirdName & "'", "Order_By")
            End If
            If p_Rows Is Nothing Then
                p_NoCustomize = False
            ElseIf p_Rows.Length <= 0 Then
                p_NoCustomize = False
            Else
                p_NoCustomize = True
            End If

            If p_NoCustomize = False Then
                Exit Function
            Else
                'Cac Column duoc khai bao trong bang GRID_PROPERTY

                'p_GridView.OptionsView.ColumnAutoWidth = False
                If p_AutoColumnWidth = "Y" Then
                    p_GridView.OptionsView.ColumnAutoWidth = True
                Else
                    p_GridView.OptionsView.ColumnAutoWidth = False
                End If
                For p_Count = 0 To p_Rows.Count - 1
                    Try

                        p_FieldExist = False
                        For p_Count1 = 0 To p_GridView.Columns.Count - 1
                            If UCase(p_GridView.Columns(p_Count1).FieldName) = UCase(p_Rows(p_Count).Item("COL_NAME").ToString) Then
                                p_FieldExist = True
                                Exit For

                            End If
                        Next
                        p_Int = p_Count1
                        If p_FieldExist = False Then
                            p_Column = New DevExpress.XtraGrid.Columns.GridColumn
                            p_Int = p_GridView.Columns.Add(p_Column)
                            p_GridView.Columns(p_Int).FieldName = p_Rows(p_Count).Item("COL_NAME").ToString
                        End If

                        If p_Rows(p_Count).Item("VISIBLE_FLAG").ToString = "N" Then
                            p_GridView.Columns(p_Int).Visible = False
                        Else
                            p_GridView.Columns(p_Int).Visible = True
                            If p_Rows(p_Count).Item("Required").ToString = "Y" Then
                                p_GridView.Columns(p_Int).AppearanceCell.BackColor = pv_Required_Back_Color
                                p_GridView.Columns(p_Int).AppearanceCell.BackColor2 = pv_Required_Back_Color
                            End If
                        End If
                        If p_Rows(p_Count).Item("CheckBox").ToString.Trim = "Y" Then
                            p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                            p_ColType.ValueChecked = "Y"
                            p_ColType.ValueUnchecked = "N"
                            p_GridView.Columns(p_Int).ColumnEdit = p_ColType
                        End If


                        If p_Rows(p_Count).Item("CAPTION").ToString <> "" Then
                            p_GridView.Columns(p_Int).Caption = p_Rows(p_Count).Item("CAPTION").ToString
                        Else
                            p_GridView.Columns(p_Int).Caption = p_Rows(p_Count).Item("COL_NAME").ToString
                        End If








                        p_GridView.Columns(p_Int).Name = p_Rows(p_Count).Item("COL_NAME").ToString
                        p_GridView.Columns(p_Int).OptionsColumn.AllowEdit = True

                        p_GridView.Columns(p_Int).Tag = p_Rows(p_Count).Item("DATA_TYPE").ToString


                        'p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
                        'p_TrueGird.RepositoryItems.Add(p_ColType)
                        'p_GridView.Columns("Nganh").ColumnEdit = p_ColType



                        If p_Rows(p_Count).Item("DATA_TYPE").ToString = "F" Or p_Rows(p_Count).Item("DATA_TYPE").ToString = "N" Then
                            If p_Rows(p_Count).Item("Digit").ToString.Trim = "Y" Then   'Co digit
                                If p_Rows(p_Count).Item("Decimals").ToString.Trim <> "" Then
                                    p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                    p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###0." & Left(p_NumberFormat, p_Rows(p_Count).Item("Decimals"))
                                Else
                                    p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                    p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###"

                                    ' p_GridView.Columns(p_Int).OptionsColumn.
                                End If
                            ElseIf p_Rows(p_Count).Item("Digit").ToString.Trim = "N" Then  'Khong digit
                                p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#############"
                            ElseIf p_Rows(p_Count).Item("Digit").ToString.Trim = "L" Then  'Khong digit   'LocalCurrency
                                p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###0." & Left(p_NumberFormat, p_LocalDecimal)

                            Else
                                p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###"
                            End If
                        End If



                        If p_Rows(p_Count).Item("DATA_TYPE").ToString = "D" Then
                            ' p_TrueGird.RepositoryItems.Add(p_ColDate)
                            p_GridView.Columns(p_Rows(p_Count).Item("COL_NAME").ToString).ColumnEdit = p_ColDate

                        End If
                        p_GridView.Columns(p_Int).ToolTip = p_Rows(p_Count).Item("COL_NAME").ToString  'p_Int

                        If p_Rows(p_Count).Item("ENABLE_FLAG").ToString = "Y" Then
                            p_GridView.Columns(p_Int).OptionsColumn.ReadOnly = False
                        Else
                            p_GridView.Columns(p_Int).OptionsColumn.ReadOnly = True
                            p_GridView.Columns(p_Int).AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke
                        End If
                        p_GridView.Columns(p_Int).OptionsColumn.AllowSize = True
                        If p_Rows(p_Count).Item("WIDTH").ToString <> "" Then
                            p_GridView.Columns(p_Int).Width = p_Rows(p_Count).Item("WIDTH").ToString
                            'Else
                        End If

                        'If p_Rows(p_Count).Item("CFL").ToString = "Y" Then
                        '    If p_Rows(p_Count).Item("ENABLE_FLAG").ToString = "Y" And p_Rows(p_Count).Item("VISIBLE_FLAG").ToString = "Y" Then
                        '        p_AddColumnTypeButtonEdit(p_TrueGird, p_GridView, p_Rows(p_Count).Item("COL_NAME").ToString)
                        '    End If
                        '    Continue For
                        'End If

                        If p_Rows(p_Count).Item("ComboBox").ToString = "Y" And p_Rows(p_Count).Item("ComboBoxSQL").ToString.Trim <> "" Then
                            ' If p_Rows(p_Count).Item("ENABLE_FLAG").ToString = "Y" And p_Rows(p_Count).Item("VISIBLE_FLAG").ToString = "Y" Then
                            p_AddColumnTypeCombobox(p_TrueGird, p_GridView, p_Rows(p_Count).Item("COL_NAME").ToString,
                                                        p_Rows(p_Count).Item("ComboBoxSQL").ToString.Trim,
                                                        p_Rows(p_Count).Item("ComboShowHeader").ToString.Trim,
                                                        p_Rows(p_Count).Item("DropDownRow").ToString.Trim)
                            'End If
                            Continue For
                        End If

                        'Them tổng cộng của Column
                        If p_Rows(p_Count).Item("ColumnSum").ToString.Trim = "Y" Then


                            If p_Rows(p_Count).Item("DATA_TYPE").ToString = "F" Or p_Rows(p_Count).Item("DATA_TYPE").ToString = "N" Then
                                Dim Totalitem As DevExpress.XtraGrid.GridColumnSummaryItem
                                If p_Rows(p_Count).Item("Digit").ToString.Trim = "Y" Then   'Co digit
                                    If p_Rows(p_Count).Item("Decimals").ToString.Trim <> "" Then

                                        Totalitem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, p_Rows(p_Count).Item("COL_NAME").ToString, "{0:n" & p_Rows(p_Count).Item("Decimals") & "}")
                                    Else

                                        Totalitem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, p_Rows(p_Count).Item("COL_NAME").ToString, "{0:n0}")
                                    End If
                                ElseIf p_Rows(p_Count).Item("Digit").ToString.Trim = "N" Then  'Khong digit
                                    Totalitem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, p_Rows(p_Count).Item("COL_NAME").ToString, "{0:n0}")
                                ElseIf p_Rows(p_Count).Item("Digit").ToString.Trim = "L" Then  'Khong digit   'LocalCurrency

                                    'Totalitem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, p_Rows(p_Count).Item("COL_NAME").ToString, "{0}")
                                    Totalitem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, p_Rows(p_Count).Item("COL_NAME").ToString, "{0:n" & p_LocalDecimal & "}")
                                Else
                                    Totalitem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, p_Rows(p_Count).Item("COL_NAME").ToString, "{0:n0}")
                                End If
                                If Not Totalitem Is Nothing Then

                                    p_GridView.Columns(p_Rows(p_Count).Item("COL_NAME").ToString).Summary.Add(Totalitem)

                                    'p_GridView.Columns(p_Rows(p_Count).Item("COL_NAME").ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom

                                    p_ColumnSum = True
                                    'Totalitem = Nothing
                                End If
                            End If

                        End If


                    Catch ex As Exception

                    End Try
                Next

                For p_Count = 0 To p_GridView.Columns.Count - 1
                    Try
                        p_FieldExist = False
                        For p_Count1 = 0 To p_Rows.Count - 1
                            If UCase(p_GridView.Columns(p_Count).FieldName) = UCase(p_Rows(p_Count1).Item("COL_NAME").ToString) Then

                                p_FieldExist = True
                                Exit For
                            End If
                        Next
                        If p_FieldExist = False Then
                            p_GridView.Columns(p_Count).Visible = False
                        End If

                    Catch ex As Exception

                    End Try
                Next
                If p_Allowinsert = "N" Then
                    p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                Else
                    p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
                End If


                p_GridView.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll
                p_GridView.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveVertScroll
                p_GridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
                p_GridView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always

                If p_ColumnSum = True Then
                    p_GridView.OptionsView.ShowFooter = True
                    p_GridView.OptionsBehavior.SummariesIgnoreNullValues = True
                    p_GridView.OptionsBehavior.AutoUpdateTotalSummary = True

                End If

                'p_TrueGird.Refresh()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            p_Get_TrueGrid_Property = False
        End Try



    End Function


    'Private Sub p_AddColumnTypeButtonEdit(ByRef p_TrueGird As U_TextBox.U_TrueDBGrid,
    '                                   ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView,
    '                                   ByVal p_ColumnIndex As String)
    '    Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    '    Dim p_DesError As String = ""
    '    Try
    '        'Tao Buttonedit cho column U_WhsCod
    '        p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    '        p_TrueGird.RepositoryItems.Add(p_ColType)
    '        p_GridView.Columns(p_ColumnIndex).ColumnEdit = p_ColType

    '        'AddHandler p_ColType.ButtonClick, AddressOf Day_Column_Button_Click(

    '        ' p_GridView.Columns("").
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub p_AddColumnTypeCombobox(ByRef p_TrueGird As U_TextBox.U_TrueDBGrid,
                                       ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView,
                                       ByVal p_ColumnIndex As String,
                                       ByVal p_SQL As String, _
                                       ByVal p_ShowHeader As String,
                                       ByVal p_RowList As String)
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

        Dim p_DropDownList As Integer
        Dim p_DesError As String = ""
        Dim p_DataTable As DataTable

        Try

            p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
            p_DataTable = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
            p_ColType.DataSource = p_DataTable
            If p_DataTable.Columns.Count > 1 Then
                p_ColType.ValueMember = p_DataTable.Columns.Item(0).ColumnName
                p_ColType.DisplayMember = p_DataTable.Columns.Item(1).ColumnName
            Else
                p_ColType.ValueMember = p_DataTable.Columns.Item(0).ColumnName
                p_ColType.DisplayMember = p_DataTable.Columns.Item(0).ColumnName

            End If
            p_ColType.NullText = ""
            p_ColType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            p_ColType.BestFit()



            If p_ShowHeader = "Y" Then
                p_ColType.ShowHeader = True
            Else
                p_ColType.ShowHeader = False


            End If
            Integer.TryParse(p_RowList, p_DropDownList)
            If p_DropDownList > 0 Then
                p_ColType.DropDownRows = p_DropDownList
            End If
            'p_TrueGird.RepositoryItems.Add(p_ColType)
            p_GridView.Columns(p_ColumnIndex).ColumnEdit = p_ColType
            'If p_ShowHeader = "Y" Then
            '    p_GridView.Columns(p_ColumnIndex).OptionsColumn.ShowCaption = True
            'Else
            '    p_GridView.Columns(p_ColumnIndex).OptionsColumn.ShowCaption = False
            'End If
            'colCombo.ShowHeader = true;  
            'colCombo.ShowFooter = false;  
            'colCombo.DataSource = dsRules.YOURTABLE;  
            'colCombo.DisplayMember = "DESCRIPTION";  
            'colCombo.ValueMember = "ID"; //Your DB column  
            'colCombo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;  
            'colCombo.NullText = ""; 

            'Tao Buttonedit cho column U_WhsCod
            'p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
            'p_TrueGird.RepositoryItems.Add(p_ColType)
            'p_DataTable = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
            'If Not p_DataTable Is Nothing Then
            '    For p_Count = 0 To p_DataTable.Rows.Count - 1
            '        If p_DataTable.Columns.Count > 1 Then
            '            ' p_ModComboboxAddValue(Me.U_Status
            '            p_ColType.

            '            ' p_ComboboxAddValue(p_ColType, p_DataTable.Rows(p_Count).Item(0), p_DataTable.Rows(p_Count).Item(0))
            '        Else

            '        End If
            '    Next
            'End If
            'p_GridView.Columns(p_ColumnIndex).ColumnEdit = p_ColType



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Function p_Set_TrueGrid_Property_PageNew(ByRef p_DesError As String, _
                                                 ByRef p_Form As Form, _
                                                 ByVal p_DataTrueGird As DataSet, _
                                                ByRef p_BindingSource As BindingSource, _
                                                ByRef p_TrueGird As U_TextBox.U_TrueDBGrid, _
                                                ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                                ByVal p_FieldKey As String, _
                                                ByVal p_PageNum As Integer, _
                                                ByVal p_LineOfPage As Integer, _
                                                ByRef p_PageTotal As Integer, _
                                                Optional ByVal B1Get As Boolean = True, _
                                                Optional ByVal p_LoadPage As Boolean = False,
                                                Optional ByVal p_Requery As Boolean = False, _
                                                Optional ByVal p_WhereExt As String = "", _
                                                Optional ByVal p_GetPageTotal As Boolean = False, _
                                                Optional ByVal p_SQLString As String = "") As Boolean
        Dim p_Count As Integer
        Dim p_GirdName As String
        Dim p_Rows() As DataRow
        Dim p_FormName As String
        Dim p_Column As DevExpress.XtraGrid.Columns.GridColumn
        Dim p_Int As Integer
        Dim p_FieldNAme() As String
        Dim p_FieldCaption() As String
        Dim p_SQL As String = ""
        Dim p_ViewName As String = ""
        Dim p_NoCustomize As Boolean = False
        Dim p_FieldExist As Boolean = False
        Dim p_OrderBy As String
        Dim p_DataSet As New DataSet
        Dim p_Count1 As Integer
        Dim p_Allowinsert As String

        Dim p_AutoColumnWidth As String

        Dim p_Where As String = ""
        Dim p_DataTmp As New DataTable
        Dim p_PageTotalTmp As Integer = 1
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

        Dim p_ColDate As New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Dim p_SQLTotal As String
        Dim p_NumberFormat As String = "############"
        Dim p_LocalDecimal As Integer

        Dim p_DataRow() As DataRow
        Dim p_Field As String = ""
        Try

            p_LocalDecimal = 0
            If Not g_CurrencyDtl Is Nothing Then
                If g_CurrencyDtl.Rows.Count <= 0 Then
                    GetCurrencyList()
                End If
                p_DataRow = g_CurrencyDtl.Select("CurrCode='" & g_Currency & "'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("Decimals") > 0 Then
                        p_LocalDecimal = p_DataRow(0).Item("Decimals")
                    End If
                End If
            End If

            p_GridView.OptionsBehavior.AllowAddRows = DefaultBoolean.True
            p_GridView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.True
            p_GridView.OptionsBehavior.Editable = True
            p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            p_GridView.OptionsNavigation.EnterMoveNextColumn = True

            p_FormName = UCase(p_Form.Name)
            p_GirdName = UCase(p_TrueGird.Name)
            p_ViewName = UCase(p_TrueGird.ViewName)
            p_OrderBy = UCase(p_TrueGird.OrderBy)
            p_Where = UCase(p_TrueGird.Where)
            p_AutoColumnWidth = UCase(p_TrueGird.ColumnAutoWidth)
            p_Allowinsert = UCase(p_TrueGird.AllowInsert)
            p_Set_TrueGrid_Property_PageNew = True
            If p_ViewName = "" And p_SQLString = "" Then
                p_DesError = "Chưa khai báo ViewName"
                p_Set_TrueGrid_Property_PageNew = False
                Exit Function
            End If

            If p_SQLString = "" Then
                p_Rows = p_DataTrueGird.Tables(0).Select("FORM_NAME='" & p_FormName & _
                                                           "' AND GRID_NAME='" & p_GirdName & "'", "ORDER_BY")  '"FORM_NAME,Order_By")
                If p_Rows.Length > 0 Then
                    For p_Count = 0 To p_Rows.Length - 1
                        If p_Field = "" Then
                            p_Field = p_Rows(p_Count).Item("COL_NAME").ToString
                        Else
                            p_Field = p_Field & "," & p_Rows(p_Count).Item("COL_NAME").ToString
                        End If
                    Next
                    p_SQL = "SELECT  " & p_Field & " FROM " & p_ViewName
                Else
                    p_SQL = "SELECT  * FROM " & p_ViewName
                End If

                If p_Where <> "" Then
                    p_SQL = p_SQL & " WHERE " & p_Where
                    If p_WhereExt <> "" Then
                        p_SQL = p_SQL & " AND " & p_WhereExt
                    End If
                Else
                    If p_WhereExt <> "" Then
                        p_SQL = p_SQL & " WHERE " & p_WhereExt
                    End If
                End If
                'If p_OrderBy.ToString <> "" Then
                '    p_SQL = p_SQL & " ORDER BY " & p_OrderBy.ToString
                'End If
                p_SQL = p_Parameter_Item(p_Form, p_SQL)

                p_SQLTotal = "select ceiling( COUNT(*)/CONVERT(float," & p_LineOfPage & "))  as TotalPage  from ( " & p_SQL & " ) A"
                If p_FieldKey <> "" And p_LoadPage = True Then

                    p_SQL = "SELECT * FROM (" & _
                                            " SELECT *, ROW_NUMBER() OVER (ORDER BY " & p_FieldKey & ") AS RowNum" & _
                                            " FROM (" & p_SQL & ") anhqh " & _
                                        " ) AS MyDerivedTable " & _
                                        " WHERE MyDerivedTable.RowNum BETWEEN (" & p_PageNum & " -1)* " & p_LineOfPage & " +1  " & _
                                        " AND " & (p_PageNum * p_LineOfPage)
                Else
                    'p_SQL = p_SQLString
                End If
            Else
                p_SQL = p_SQLString
            End If
            If B1Get = True Then
                p_BindingSource.DataSource = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQL).Tables(0)
                If p_GetPageTotal = True Then
                    p_DataTmp = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQLTotal).Tables(0)
                    If Not p_DataTmp Is Nothing Then
                        If p_DataTmp.Rows.Count > 0 Then
                            p_PageTotal = p_DataTmp.Rows(0).Item("TotalPage").ToString.Trim
                        End If
                    End If
                End If
            Else

                p_SQL = Replace(p_SQL, "'", "''")
                p_SQL = "FPT_SQLReturnDataTable '" & p_SQL & "'"
                p_DataSet = g_Service.mod_SYS_GET_DATASET(p_SQL)
                If p_GetPageTotal = True Then
                    p_DataTmp = g_Service.mod_SYS_GET_DATASET(p_SQLTotal).Tables(0)
                    If Not p_DataTmp Is Nothing Then
                        If p_DataTmp.Rows.Count > 0 Then
                            p_PageTotal = p_DataTmp.Rows(0).Item("TotalPage").ToString.Trim
                        End If
                    End If
                End If
                p_BindingSource.DataSource = p_DataSet.Tables(0)  ' g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
            End If
            '  If p_BindingSource.Count <= 0 Then
            ' p_BindingSource.AddNew()
            '  End If
            If p_Requery = True Then
                p_BindingSource.ResetBindings(True)
                p_TrueGird.Refresh()
                If p_Allowinsert = "N" Then
                    p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                Else
                    p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
                End If
                If p_AutoColumnWidth = "Y" Then
                    p_GridView.OptionsView.ColumnAutoWidth = True
                Else
                    p_GridView.OptionsView.ColumnAutoWidth = False
                End If

                Exit Function

            End If
            If p_DataTrueGird.Tables.Count > 0 Then
                p_Rows = p_DataTrueGird.Tables(0).Select("FORM_NAME='" & p_FormName & _
                                                         "' AND GRID_NAME='" & p_GirdName & "'", "FORM_NAME,GRID_NAME,Order_By")
            End If
            If p_Rows Is Nothing Then
                p_NoCustomize = False
            ElseIf p_Rows.Length <= 0 Then
                p_NoCustomize = False
            Else
                p_NoCustomize = True
            End If

            If p_NoCustomize = False Then
                'Cac Column khong duoc  khai bao trong bang GRID_PROPERTY

                ReDim p_FieldNAme(0 To p_GridView.Columns.Count - 1)
                ReDim p_FieldCaption(0 To p_GridView.Columns.Count - 1)
                For p_Count = 0 To p_GridView.Columns.Count - 1
                    p_FieldNAme(p_Count) = p_GridView.Columns(p_Count).FieldName
                    p_FieldCaption(p_Count) = p_GridView.Columns(p_Count).Caption

                Next
                p_TrueGird.DataSource = p_BindingSource
                p_BindingSource.ResetBindings(True)
                For p_Count = 0 To UBound(p_FieldNAme, 1)
                    p_GridView.Columns(p_Count).FieldName = p_FieldNAme(p_Count)
                    p_GridView.Columns(p_Count).Caption = p_FieldCaption(p_Count)

                Next
                p_TrueGird.Refresh()

            Else
                'Cac Column duoc khai bao trong bang GRID_PROPERTY
                p_TrueGird.DataSource = p_BindingSource
                p_BindingSource.ResetBindings(True)
                p_TrueGird.Refresh()


                If p_AutoColumnWidth = "Y" Then
                    p_GridView.OptionsView.ColumnAutoWidth = True
                Else
                    p_GridView.OptionsView.ColumnAutoWidth = False
                End If

                For p_Count = 0 To p_Rows.Count - 1
                    Try

                        p_FieldExist = False
                        For p_Count1 = 0 To p_GridView.Columns.Count - 1
                            If UCase(p_GridView.Columns(p_Count1).FieldName) = UCase(p_Rows(p_Count).Item("COL_NAME").ToString) Then
                                p_FieldExist = True
                                Exit For

                            End If
                        Next
                        p_Int = p_Count1
                        If p_FieldExist = False Then
                            p_Column = New DevExpress.XtraGrid.Columns.GridColumn
                            p_Int = p_GridView.Columns.Add(p_Column)
                            p_GridView.Columns(p_Int).FieldName = p_Rows(p_Count).Item("COL_NAME").ToString
                        Else
                            p_GridView.Columns(p_Int).FieldName = p_Rows(p_Count).Item("COL_NAME").ToString
                        End If

                        If p_Rows(p_Count).Item("VISIBLE_FLAG").ToString = "N" Then
                            p_GridView.Columns(p_Int).Visible = False
                        Else
                            p_GridView.Columns(p_Int).Visible = True
                        End If

                        If p_Rows(p_Count).Item("WIDTH").ToString <> "" Then
                            p_GridView.Columns(p_Int).Width = p_Rows(p_Count).Item("WIDTH").ToString
                        End If

                        If p_Rows(p_Count).Item("CAPTION").ToString <> "" Then
                            p_GridView.Columns(p_Int).Caption = p_Rows(p_Count).Item("CAPTION").ToString
                        Else
                            p_GridView.Columns(p_Int).Caption = p_Rows(p_Count).Item("COL_NAME").ToString
                        End If

                        p_GridView.Columns(p_Int).Name = p_Rows(p_Count).Item("COL_NAME").ToString
                        p_GridView.Columns(p_Int).OptionsColumn.AllowEdit = True

                        p_GridView.Columns(p_Int).Tag = p_Rows(p_Count).Item("DATA_TYPE").ToString
                        'If p_Rows(p_Count).Item("DATA_TYPE").ToString = "F" Then
                        '    p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        '    ' p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###.##" '"n2"  '#,##0.00
                        '    p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,##0.00" '"n2"  '#,##0.00
                        'End If

                        'If p_Rows(p_Count).Item("DATA_TYPE").ToString = "N" Then
                        '    p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        '    ' p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###.##" '"n2"  '#,##0.00
                        '    p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###" '"n2"  '#,##0.00
                        'End If
                        If p_Rows(p_Count).Item("DATA_TYPE").ToString = "F" Or p_Rows(p_Count).Item("DATA_TYPE").ToString = "N" Then
                            If p_Rows(p_Count).Item("Digit").ToString.Trim = "Y" Then   'Co digit
                                If p_Rows(p_Count).Item("Decimals").ToString.Trim <> "" Then
                                    p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                    p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###0." & Left(p_NumberFormat, p_Rows(p_Count).Item("Decimals"))
                                End If
                            ElseIf p_Rows(p_Count).Item("Digit").ToString.Trim = "N" Then  'Khong digit
                                p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#############"
                            ElseIf p_Rows(p_Count).Item("Digit").ToString.Trim = "L" Then  'Khong digit   'LocalCurrency
                                p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###0." & Left(p_NumberFormat, p_LocalDecimal)

                            Else
                                p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###"
                            End If
                        End If
                        If p_Rows(p_Count).Item("DATA_TYPE").ToString = "D" Then
                            p_GridView.Columns(p_Rows(p_Count).Item("COL_NAME").ToString).ColumnEdit = p_ColDate

                        End If
                        If p_Rows(p_Count).Item("CheckBox").ToString.Trim = "Y" Then
                            p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                            p_ColType.ValueChecked = "Y"
                            p_ColType.ValueUnchecked = "N"
                            p_GridView.Columns(p_Int).ColumnEdit = p_ColType
                        End If

                        p_GridView.Columns(p_Int).ToolTip = p_Int

                        If p_Rows(p_Count).Item("ENABLE_FLAG").ToString = "Y" Then
                            p_GridView.Columns(p_Int).OptionsColumn.AllowEdit = True
                        Else
                            p_GridView.Columns(p_Int).OptionsColumn.AllowEdit = False
                            p_GridView.Columns(p_Int).AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke
                        End If
                    Catch ex As Exception
                        p_DesError = ex.Message
                        p_Set_TrueGrid_Property_PageNew = False
                    End Try
                Next

                For p_Count = 0 To p_GridView.Columns.Count - 1
                    Try
                        p_FieldExist = False
                        For p_Count1 = 0 To p_Rows.Count - 1
                            If UCase(p_GridView.Columns(p_Count).FieldName) = UCase(p_Rows(p_Count1).Item("COL_NAME").ToString) Then

                                p_FieldExist = True
                                Exit For
                            End If
                        Next
                        If p_FieldExist = False Then
                            p_GridView.Columns(p_Count).Visible = False
                        End If

                    Catch ex As Exception
                        p_DesError = ex.Message
                        p_Set_TrueGrid_Property_PageNew = False
                    End Try
                Next
                If p_Allowinsert = "N" Then
                    p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                Else
                    p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
                End If


                p_GridView.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll
                p_GridView.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveVertScroll
                p_GridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
                p_GridView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
            End If


        Catch ex As Exception
            p_DesError = ex.Message
            p_Set_TrueGrid_Property_PageNew = False
        End Try



    End Function


    'anhqh
    'Dung cho item TrueDBGrid chi dr hien thi
    Public Function p_TrueGrid_OnlyView_Page(ByRef p_DesError As String, _
                                                 ByRef p_Form As Form, _
                                                 ByRef p_BindingSource As BindingSource, _
                                                ByRef p_TrueGird As U_TextBox.TrueDBGrid, _
                                                ByVal p_FieldKey As String, _
                                                ByVal p_PageNum As Integer, _
                                                ByVal p_LineOfPage As Integer, _
                                                ByRef p_PageTotal As Integer, _
                                                Optional ByVal B1Get As Boolean = True, _
                                                Optional ByVal p_LoadPage As Boolean = False,
                                                Optional ByVal p_Requery As Boolean = False, _
                                                Optional ByVal p_WhereExt As String = "", _
                                                Optional ByVal p_GetPageTotal As Boolean = False, _
                                                Optional ByVal p_SQLString As String = "") As Boolean
        Dim p_Count As Integer
        Dim p_GirdName As String
        ' Dim p_Rows() As DataRow
        Dim p_FormName As String
        'Dim p_Column As DevExpress.XtraGrid.Columns.GridColumn
        'Dim p_Int As Integer
        'Dim p_FieldNAme() As String
        'Dim p_FieldCaption() As String
        Dim p_SQL As String = ""
        Dim p_ViewName As String = ""
        Dim p_NoCustomize As Boolean = False
        Dim p_FieldExist As Boolean = False
        Dim p_OrderBy As String
        Dim p_DataSet As New DataSet
        ' Dim p_Count1 As Integer
        Dim p_Allowinsert As String

        Dim p_AutoColumnWidth As String

        Dim p_Where As String = ""
        Dim p_DataTmp As New DataTable
        Dim p_PageTotalTmp As Integer = 1

        ' Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

        Dim p_ColDate As New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Dim p_SQLTotal As String
        Dim p_NumberFormat As String = "############"
        Dim p_LocalDecimal As Integer

        Dim p_GridView As U_TextBox.GridView

        Dim p_DataRow() As DataRow
        Dim p_Field As String = ""

        Dim p_Column As U_TextBox.GridColumn


        Try

            p_LocalDecimal = 0
            If Not g_CurrencyDtl Is Nothing Then
                If g_CurrencyDtl.Rows.Count <= 0 Then
                    GetCurrencyList()
                End If
                p_DataRow = g_CurrencyDtl.Select("CurrCode='" & g_Currency & "'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("Decimals") > 0 Then
                        p_LocalDecimal = p_DataRow(0).Item("Decimals")
                    End If
                End If
            End If
            p_GridView = p_TrueGird.Views(0)

            '  p_GridView.OptionsBehavior.AllowAddRows = DefaultBoolean.True
            'p_GridView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.True
            'p_GridView.OptionsBehavior.Editable = True
            ' p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            p_GridView.OptionsNavigation.EnterMoveNextColumn = True

            p_FormName = UCase(p_Form.Name)
            p_GirdName = UCase(p_TrueGird.Name)
            p_ViewName = UCase(p_GridView.ViewName)
            p_OrderBy = UCase(p_GridView.OrderBy)
            p_Where = UCase(p_GridView.Where)
            p_AutoColumnWidth = UCase(p_GridView.ColumnAutoWidth)
            p_Allowinsert = UCase(p_GridView.AllowInsert)
            p_TrueGrid_OnlyView_Page = True



            If p_ViewName = "" And p_SQLString = "" Then
                p_DesError = "Chưa khai báo ViewName"
                p_TrueGrid_OnlyView_Page = False
                Exit Function
            End If


            p_Field = ""
            For Each p_Column In p_GridView.Columns
                If p_Column.FieldView.ToString.Trim <> "" Then
                    If p_Field = "" Then
                        p_Field = p_Column.FieldView.ToString
                    Else
                        p_Field = p_Field & "," & p_Column.FieldView.ToString
                    End If
                End If
            Next
            If p_Field = "" Then
                p_TrueGrid_OnlyView_Page = False
                Exit Function
            Else
                p_SQL = " SELECT " & p_Field & " FROM  " & p_ViewName & " "
            End If



            If p_SQLString = "" Then

                ' p_SQL = "SELECT  * FROM " & p_ViewName
                ' End If

                If p_Where <> "" Then
                    p_SQL = p_SQL & " WHERE " & p_Where
                    If p_WhereExt <> "" Then
                        p_SQL = p_SQL & " AND " & p_WhereExt
                    End If
                Else
                    If p_WhereExt <> "" Then
                        p_SQL = p_SQL & " WHERE " & p_WhereExt
                    End If
                End If
                'If p_OrderBy.ToString <> "" Then
                '    p_SQL = p_SQL & " ORDER BY " & p_OrderBy.ToString
                'End If
                p_SQL = p_Parameter_Item(p_Form, p_SQL)

                p_SQLTotal = "select ceiling( COUNT(*)/CONVERT(float," & p_LineOfPage & "))  as TotalPage  from ( " & p_SQL & " ) A"
                If p_FieldKey <> "" And p_LoadPage = True Then

                    p_SQL = "SELECT * FROM (" & _
                                            " SELECT *, ROW_NUMBER() OVER (ORDER BY " & p_FieldKey & ") AS RowNum" & _
                                            " FROM (" & p_SQL & ") anhqh " & _
                                        " ) AS MyDerivedTable " & _
                                        " WHERE MyDerivedTable.RowNum BETWEEN (" & p_PageNum & " -1)* " & p_LineOfPage & " +1  " & _
                                        " AND " & (p_PageNum * p_LineOfPage)
                Else
                    'p_SQL = p_SQLString
                End If
            Else
                p_SQL = p_SQLString
            End If
            If B1Get = True Then
                p_BindingSource.DataSource = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQL).Tables(0)
                If p_GetPageTotal = True Then
                    p_DataTmp = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQLTotal).Tables(0)
                    If Not p_DataTmp Is Nothing Then
                        If p_DataTmp.Rows.Count > 0 Then
                            p_PageTotal = p_DataTmp.Rows(0).Item("TotalPage").ToString.Trim
                        End If
                    End If
                End If
            Else

                p_SQL = Replace(p_SQL, "'", "''")
                p_SQL = "FPT_SQLReturnDataTable '" & p_SQL & "'"
                p_DataSet = g_Service.mod_SYS_GET_DATASET(p_SQL)
                If p_GetPageTotal = True Then
                    p_DataTmp = g_Service.mod_SYS_GET_DATASET(p_SQLTotal).Tables(0)
                    If Not p_DataTmp Is Nothing Then
                        If p_DataTmp.Rows.Count > 0 Then
                            p_PageTotal = p_DataTmp.Rows(0).Item("TotalPage").ToString.Trim
                        End If
                    End If
                End If
                p_BindingSource.DataSource = p_DataSet.Tables(0)  ' g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
            End If
            '  If p_BindingSource.Count <= 0 Then
            ' p_BindingSource.AddNew()
            '  End If
            'If p_Requery = True Then
            '    p_BindingSource.ResetBindings(True)
            '    p_TrueGird.Refresh()
            '    'If p_Allowinsert = "N" Then
            '    '    p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            '    'Else
            '    '    p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            '    'End If
            '    If p_AutoColumnWidth = "Y" Then
            '        p_GridView.OptionsView.ColumnAutoWidth = True
            '    Else
            '        p_GridView.OptionsView.ColumnAutoWidth = False
            '    End If

            '    Exit Function

            'End If
            p_TrueGird.DataSource = p_BindingSource
            p_BindingSource.ResetBindings(True)
            p_TrueGird.Refresh()
            For p_Count = 0 To p_GridView.Columns.Count - 1
                p_Column = p_GridView.Columns.Item(p_Count)

                If InStr(UCase(p_Column.ColumnType.FullName.ToString.Trim), UCase("System.Int"), CompareMethod.Text) > 0 _
                    Or InStr(UCase(p_Column.ColumnType.FullName.ToString.Trim), UCase("System.Decima"), CompareMethod.Text) > 0 Then
                    If p_Column.LocalDecimal = True Then
                        If p_Column.Digit = True Then
                            p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                            p_Column.DisplayFormat.FormatString = "#,###0." & Left(p_NumberFormat, p_LocalDecimal)
                        Else
                            p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                            p_Column.DisplayFormat.FormatString = "#,###0."
                        End If
                    Else
                        p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        p_Column.DisplayFormat.FormatString = "#############"
                    End If
                End If
                If InStr(UCase(p_Column.ColumnType.FullName.ToString.Trim), UCase("System.Date"), CompareMethod.Text) > 0 Then
                    p_Column.ColumnEdit = p_ColDate
                    If p_Column.DisplayFormat.FormatString.ToString.Trim = "" Or p_Column.DisplayFormat.FormatString.ToString.Trim = "d" Then
                        p_Column.DisplayFormat.FormatType = FormatType.DateTime
                    End If
                End If
                If p_Column.FieldView.ToString.Trim <> "" Then
                    p_Column.FieldName = p_Column.FieldView
                Else
                    p_Column.FieldName = p_DataSet.Tables(0).Columns(p_Count).ColumnName.ToString
                End If
                p_Column.OptionsColumn.AllowEdit = False

            Next
        Catch ex As Exception
            p_DesError = ex.Message
            p_TrueGrid_OnlyView_Page = False
        End Try



    End Function

    Public Function p_Set_SQLString_TrueGrid_Property(ByRef p_Form As Form, _
                                            ByVal p_DataTrueGird As DataSet, _
                                            ByRef p_BindingSource As BindingSource, _
                                            ByRef p_TrueGird As U_TextBox.U_TrueDBGrid, _
                                                ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                                Optional ByVal B1Get As Boolean = True, _
                                                Optional ByVal p_Requery As Boolean = False, _
                                                Optional ByVal p_SQL As String = "") As Boolean
        Dim p_Count As Integer
        'Dim p_CountTo As Integer
        Dim p_GirdName As String
        Dim p_Rows() As DataRow
        Dim p_FormName As String
        Dim p_Column As DevExpress.XtraGrid.Columns.GridColumn
        Dim p_Int As Integer
        Dim p_FieldNAme() As String
        Dim p_FieldCaption() As String
        'Dim p_SQL As String = ""
        Dim p_ViewName As String = ""
        Dim p_NoCustomize As Boolean = False
        Dim p_FieldExist As Boolean = False
        'Dim p_OrderBy As String
        ' Dim p_Page_Total As Integer
        Dim p_DataSet As New DataSet
        ' Dim p_DataSet As New DataSet
        Dim p_Count1 As Integer
        'Dim p_Count2 As Integer
        Dim p_Allowinsert As String
        Dim p_Where As String = ""
        ' Dim p_DataRowView As DataRowView
        Dim p_AutoColumnWidth As String
        Dim p_ColDate As New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        ' Dim p_sysbat As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        Try

            p_GridView.OptionsBehavior.AllowAddRows = DefaultBoolean.True
            p_GridView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.True
            p_GridView.OptionsBehavior.Editable = True
            p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            p_GridView.OptionsNavigation.EnterMoveNextColumn = True

            p_FormName = UCase(p_Form.Name)
            p_GirdName = UCase(p_TrueGird.Name)
            p_Allowinsert = UCase(p_TrueGird.AllowInsert)
            p_AutoColumnWidth = UCase(p_TrueGird.ColumnAutoWidth)

            'p_ViewName = UCase(p_TrueGird.ViewName)
            'p_OrderBy = UCase(p_TrueGird.OrderBy)
            'p_Where = UCase(p_TrueGird.Where)
            p_Set_SQLString_TrueGrid_Property = True
            'If p_ViewName = "" Then
            '    p_Set_SQLString_TrueGrid_Property = False
            '    Exit Function
            'End If


            p_SQL = p_Parameter_Item(p_Form, p_SQL)


            If B1Get = True Then
                p_BindingSource.DataSource = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQL).Tables(0)
            Else
                ' Dim p_DTSet As DataSet

                'p_DataSet = mod_SYS_GET_DATASET(p_SQL)
                'Dim dt As DataTable = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
                p_DataSet = g_Service.mod_SYS_GET_DATASET(p_SQL)

                p_BindingSource.DataSource = p_DataSet.Tables(0)  ' g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
            End If
            '  If p_BindingSource.Count <= 0 Then
            ' p_BindingSource.AddNew()
            '  End If

            If p_Requery = True Then
                p_BindingSource.ResetBindings(True)
                p_TrueGird.Refresh()
                Exit Function

            End If
            If p_DataTrueGird.Tables.Count > 0 Then
                p_Rows = p_DataTrueGird.Tables(0).Select("FORM_NAME='" & p_FormName & _
                                                         "' AND GRID_NAME='" & p_GirdName & "'", "FORM_NAME,GRID_NAME,Order_By")
            End If
            If p_Rows Is Nothing Then
                p_NoCustomize = False
            ElseIf p_Rows.Length <= 0 Then
                p_NoCustomize = False
            Else
                p_NoCustomize = True
            End If

            If p_NoCustomize = False Then
                'Cac Column khong duoc  khai bao trong bang GRID_PROPERTY

                ReDim p_FieldNAme(0 To p_GridView.Columns.Count - 1)
                ReDim p_FieldCaption(0 To p_GridView.Columns.Count - 1)
                For p_Count = 0 To p_GridView.Columns.Count - 1
                    p_FieldNAme(p_Count) = p_GridView.Columns(p_Count).FieldName
                    p_FieldCaption(p_Count) = p_GridView.Columns(p_Count).Caption

                Next
                p_TrueGird.DataSource = p_BindingSource
                p_BindingSource.ResetBindings(True)
                For p_Count = 0 To UBound(p_FieldNAme, 1)
                    p_GridView.Columns(p_Count).FieldName = p_FieldNAme(p_Count)
                    p_GridView.Columns(p_Count).Caption = p_FieldCaption(p_Count)

                Next
                p_TrueGird.Refresh()

            Else
                'Cac Column duoc khai bao trong bang GRID_PROPERTY
                p_TrueGird.DataSource = p_BindingSource
                p_BindingSource.ResetBindings(True)
                p_TrueGird.Refresh()

                If p_AutoColumnWidth = "Y" Then
                    p_GridView.OptionsView.ColumnAutoWidth = True
                Else
                    p_GridView.OptionsView.ColumnAutoWidth = False
                End If

                For p_Count = 0 To p_Rows.Count - 1
                    Try

                        p_FieldExist = False
                        For p_Count1 = 0 To p_GridView.Columns.Count - 1
                            If UCase(p_GridView.Columns(p_Count1).FieldName) = UCase(p_Rows(p_Count).Item("COL_NAME").ToString) Then
                                p_FieldExist = True
                                Exit For

                            End If
                        Next
                        p_Int = p_Count1
                        If p_FieldExist = False Then
                            p_Column = New DevExpress.XtraGrid.Columns.GridColumn
                            p_Int = p_GridView.Columns.Add(p_Column)
                            p_GridView.Columns(p_Int).FieldName = p_Rows(p_Count).Item("COL_NAME").ToString
                        End If


                        ' GridView1.Columns("U_DateEx").ColumnEdit = p_ColDate




                        If p_Rows(p_Count).Item("VISIBLE_FLAG").ToString = "N" Then
                            p_GridView.Columns(p_Int).Visible = False
                        Else
                            p_GridView.Columns(p_Int).Visible = True
                        End If

                        If p_Rows(p_Count).Item("WIDTH").ToString <> "" Then
                            p_GridView.Columns(p_Int).Width = p_Rows(p_Count).Item("WIDTH").ToString
                        End If

                        If p_Rows(p_Count).Item("CAPTION").ToString <> "" Then
                            p_GridView.Columns(p_Int).Caption = p_Rows(p_Count).Item("CAPTION").ToString
                        Else
                            p_GridView.Columns(p_Int).Caption = p_Rows(p_Count).Item("COL_NAME").ToString
                        End If



                        p_GridView.Columns(p_Int).Name = p_Rows(p_Count).Item("COL_NAME").ToString
                        p_GridView.Columns(p_Int).OptionsColumn.AllowEdit = True

                        p_GridView.Columns(p_Int).Tag = p_Rows(p_Count).Item("DATA_TYPE").ToString
                        If p_Rows(p_Count).Item("DATA_TYPE").ToString = "F" Then
                            p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                            p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###.##" '"n2"
                        End If

                        If p_Rows(p_Count).Item("DATA_TYPE").ToString = "D" Then
                            'p_ColDate.DisplayFormat = DevExpress.Utils.FormatType.DateTime
                            'Dim p_ColDate1 As New U_TextBox.U_DateEdit
                            p_ColDate.DisplayFormat.FormatString = "d"
                            p_ColDate.EditMask = "d"
                            p_ColDate.Mask.EditMask = "d"
                            '  p_ColDate.
                            'p_ColDate.EditFormat.FormatString = "d"
                            p_GridView.Columns(p_Rows(p_Count).Item("COL_NAME").ToString).ColumnEdit = p_ColDate
                            'p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                            'p_GridView.Columns(p_Int).DisplayFormat.FormatString = "d" '"n2"



                        End If

                        If p_Rows(p_Count).Item("DATA_TYPE").ToString = "N" Then
                            p_GridView.Columns(p_Int).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                            ' p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###.##" '"n2"  '#,##0.00
                            p_GridView.Columns(p_Int).DisplayFormat.FormatString = "#,###" '"n2"  '#,##0.00
                        End If
                        If p_Rows(p_Count).Item("CheckBox").ToString.Trim = "Y" Then
                            p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                            p_ColType.ValueChecked = "Y"
                            p_ColType.ValueUnchecked = "N"
                            p_GridView.Columns(p_Int).ColumnEdit = p_ColType
                        End If
                        p_GridView.Columns(p_Int).ToolTip = p_Int

                        If p_Rows(p_Count).Item("ENABLE_FLAG").ToString = "Y" Then
                            p_GridView.Columns(p_Int).OptionsColumn.AllowEdit = True
                        Else
                            p_GridView.Columns(p_Int).OptionsColumn.AllowEdit = False
                            p_GridView.Columns(p_Int).AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke
                        End If

                    Catch ex As Exception

                    End Try
                Next

                For p_Count = 0 To p_GridView.Columns.Count - 1
                    Try

                        p_FieldExist = False
                        For p_Count1 = 0 To p_Rows.Count - 1
                            If UCase(p_GridView.Columns(p_Count).FieldName) = UCase(p_Rows(p_Count1).Item("COL_NAME").ToString) Then

                                p_FieldExist = True
                                Exit For
                            End If
                        Next
                        If p_FieldExist = False Then
                            p_GridView.Columns(p_Count).Visible = False
                        End If

                    Catch ex As Exception

                    End Try
                Next
                If p_Allowinsert = "N" Then
                    p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                Else
                    p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
                End If

                '  p_GridView.OptionsView.ColumnAutoWidth = False

                If p_AutoColumnWidth = "Y" Then
                    p_GridView.OptionsView.ColumnAutoWidth = True
                Else
                    p_GridView.OptionsView.ColumnAutoWidth = False
                End If

                p_GridView.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll
                p_GridView.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveVertScroll
                p_GridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
                p_GridView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always


            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            p_Set_SQLString_TrueGrid_Property = False
        End Try



    End Function


    'Public Function mod_SYS_GET_DATASET(ByVal p_SQL As String) As System.Data.DataSet
    '    'Dim dr As OleDbDataReader

    '    Dim Olecon As New OleDbConnection
    '    Dim OlemyCommand As OleDbCommand
    '    Dim p_OleAdapter As OleDbDataAdapter
    '    Dim connectionString As String
    '    'Dim sSQL As String
    '    Dim p_Status As Boolean
    '    Dim p_DataTable As New System.Data.DataSet
    '    Dim p_Recorset As New Object
    '    Dim p_Int As Integer


    '    p_Status = True

    '    Try
    '        connectionString = "Provider=SQLOLEDB;Data Source=10.15.20.133;Persist Security Info=True;User ID=" & _
    '                 "fes_AnhQH;Password=123456a@;Initial Catalog=FPTCUSTOMIZE;Connect Timeout=300"
    '        Olecon.ConnectionString = connectionString
    '        Olecon = New OleDbConnection(connectionString)
    '        Olecon.Open()
    '        If Olecon.State.ToString() = "Open" Then
    '            OlemyCommand = New OleDbCommand(p_SQL, Olecon)
    '            OlemyCommand.CommandTimeout = 300

    '            p_OleAdapter = New OleDbDataAdapter(OlemyCommand)
    '            'p_OleAdapter.FillSchema
    '            p_Int = p_OleAdapter.Fill(p_DataTable)
    '        Else
    '            p_Status = False
    '        End If
    '        Olecon.Close()
    '        Return p_DataTable
    '    Catch
    '        p_Status = False
    '        Return Nothing
    '    End Try
    '    'mod_SYS_GET_DATASET = p_DataTable
    'End Function


    Public Function p_Set_TrueGrid_Property_Page(ByRef p_DesError As String, _
                                                 ByVal p_SQLString As String, _
                                                 ByRef p_Form As Form, _
                                                ByRef p_BindingSource As BindingSource, _
                                                ByRef p_TrueGird As U_TextBox.U_TrueDBGrid, _
                                                ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                                ByVal p_FieldKey As String, _
                                                ByVal p_PageNum As Integer, _
                                                ByVal p_LineOfPage As Integer, _
                                                Optional ByVal B1Get As Boolean = True, _
                                                Optional ByVal p_LoadPage As Boolean = False) As Boolean
        Dim p_Count As Integer
        Dim p_FieldNAme() As String
        Dim p_FieldCaption() As String
        Dim p_SQL As String = ""
        Dim p_ViewName As String = ""
        Dim p_NoCustomize As Boolean = False
        Dim p_Where As String = ""
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

        Try

            p_GridView.OptionsBehavior.AllowAddRows = DefaultBoolean.True
            p_GridView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False
            p_GridView.OptionsBehavior.Editable = False
            p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            p_GridView.OptionsNavigation.EnterMoveNextColumn = True


            p_Set_TrueGrid_Property_Page = True
            If p_SQLString = "" Then
                p_Set_TrueGrid_Property_Page = False
                Exit Function
            End If

            p_SQL = UCase(p_SQLString)

            If p_FieldKey <> "" And p_LoadPage = True Then
                p_SQL = "SELECT * FROM (" & _
                                        " SELECT *, ROW_NUMBER() OVER (ORDER BY " & p_FieldKey & ") AS RowNum" & _
                                        " FROM (" & p_SQLString & ") anhqh " & _
                                    " ) AS MyDerivedTable " & _
                                    " WHERE MyDerivedTable.RowNum BETWEEN (" & p_PageNum & " -1)* " & p_LineOfPage & " +1  " & _
                                    " AND " & (p_PageNum * p_LineOfPage)
            Else
                p_SQL = p_SQLString
            End If
            '  p_BindingSource.ResetBindings(True)
            ' p_TrueGird.Refresh()
            If B1Get = True Then
                p_BindingSource.DataSource = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQL).Tables(0)
            Else
                ' Dim p_DTSet As DataSet
                ' p_DTSet= g_Service.mod_SYS_GET_DATASET(p_SQL)
                p_BindingSource.DataSource = g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
            End If

            p_TrueGird.DataSource = p_BindingSource

            'Cac Column khong duoc  khai bao trong bang GRID_PROPERTY
            ReDim p_FieldNAme(0 To p_GridView.Columns.Count - 1)
            ReDim p_FieldCaption(0 To p_GridView.Columns.Count - 1)
            For p_Count = 0 To p_GridView.Columns.Count - 1
                p_FieldNAme(p_Count) = p_GridView.Columns(p_Count).FieldName
                p_FieldCaption(p_Count) = p_GridView.Columns(p_Count).Caption

                ' p_TrueGird.Columns(p_Count).DataField = p_TrueGird.Columns(p_Count).DataField
            Next

            'p_BindingSource.ResetBindings(True)
            For p_Count = 0 To UBound(p_FieldNAme, 1)
                p_GridView.Columns(p_Count).FieldName = p_FieldNAme(p_Count)
                p_GridView.Columns(p_Count).Caption = p_FieldCaption(p_Count)

            Next
            p_TrueGird.Refresh()

            Try
                'p_CountTo = p_Count
                'For p_Count = 0 To p_GridView.Columns.Count - p_CountTo
                '    If Not p_GridView.Columns(p_Count) Is Nothing Then
                '        If p_GridView.Columns(p_Count).FieldName.ToString = "" Then
                '            'p_GridView.Columns.RemoveAt(p_Count)
                '            p_Column = p_GridView.Columns(p_Count)
                '            p_GridView.Columns.Remove(p_Column)

                '        Else
                '            If p_Count >= p_CountTo Then
                '                'Else
                '                p_GridView.Columns(p_Count).Visible = False
                '            End If

                '        End If
                '    End If
                ' Next

            Catch ex As Exception
                p_DesError = ex.Message
                p_Set_TrueGrid_Property_Page = False
            End Try

        Catch ex As Exception
            p_DesError = ex.Message
            p_Set_TrueGrid_Property_Page = False
        End Try


    End Function

    Public Function p_Set_TrueGrid_Property_LoadPage(ByRef p_DesError As String, _
                                                 ByVal p_SQLString As String, _
                                                 ByRef p_Form As Form, _
                                                ByRef p_BindingSource As BindingSource, _
                                                ByRef p_TrueGird As U_TextBox.U_TrueDBGrid, _
                                                ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                                ByVal p_FieldKey As String, _
                                                ByVal p_PageNum As Integer, _
                                                ByVal p_LineOfPage As Integer, _
                                                 ByRef p_PageTotal As Integer, _
                                                Optional ByVal B1Get As Boolean = True, _
                                                Optional ByVal p_LoadPage As Boolean = False) As Boolean

        Dim p_Count As Integer
        Dim p_FieldNAme() As String
        Dim p_FieldCaption() As String
        Dim p_SQL As String = ""
        Dim p_ViewName As String = ""
        Dim p_NoCustomize As Boolean = False
        Dim p_Where As String = ""
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Dim p_DataTmp As DataTable
        Dim p_SQLTotal As String
        Try

            p_GridView.OptionsBehavior.AllowAddRows = DefaultBoolean.True
            p_GridView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False
            p_GridView.OptionsBehavior.Editable = False
            p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            p_GridView.OptionsNavigation.EnterMoveNextColumn = True


            p_Set_TrueGrid_Property_LoadPage = True
            If p_SQLString = "" Then
                p_Set_TrueGrid_Property_LoadPage = False
                Exit Function
            End If

            p_SQL = UCase(p_SQLString)

            p_SQLTotal = "select ceiling( COUNT(*)/CONVERT(float," & p_LineOfPage & "))  as TotalPage  from ( " & p_SQL & " ) A"

            If p_FieldKey <> "" And p_LoadPage = True Then
                p_SQL = "SELECT * FROM (" & _
                                        " SELECT *, ROW_NUMBER() OVER (ORDER BY " & p_FieldKey & ") AS RowNum" & _
                                        " FROM (" & p_SQLString & ") anhqh " & _
                                    " ) AS MyDerivedTable " & _
                                    " WHERE MyDerivedTable.RowNum BETWEEN (" & p_PageNum & " -1)* " & p_LineOfPage & " +1  " & _
                                    " AND " & (p_PageNum * p_LineOfPage)
            Else
                p_SQL = p_SQLString
            End If
            '  p_BindingSource.ResetBindings(True)
            ' p_TrueGird.Refresh()
            If B1Get = True Then
                p_BindingSource.DataSource = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQL).Tables(0)
                p_DataTmp = g_Service.mod_SYS_GET_DATASET(p_SQLTotal).Tables(0)
                If Not p_DataTmp Is Nothing Then
                    If p_DataTmp.Rows.Count > 0 Then
                        p_PageTotal = p_DataTmp.Rows(0).Item("TotalPage").ToString.Trim
                    End If
                End If
            Else
                ' Dim p_DTSet As DataSet
                ' p_DTSet= g_Service.mod_SYS_GET_DATASET(p_SQL)
                p_BindingSource.DataSource = g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
                If p_LoadPage = True Then
                    p_SQLTotal = "select ceiling( COUNT(*)/CONVERT(float," & p_LineOfPage & "))  as TotalPage  from ( " & p_SQLString & " ) A"
                    'If p_GetPageTotal = True Then
                    p_DataTmp = g_Service.mod_SYS_GET_DATASET(p_SQLTotal).Tables(0)
                    If Not p_DataTmp Is Nothing Then
                        If p_DataTmp.Rows.Count > 0 Then
                            p_PageTotal = p_DataTmp.Rows(0).Item("TotalPage").ToString.Trim
                        End If
                    End If
                    'End If
                End If
               
            End If

            p_TrueGird.DataSource = p_BindingSource

            'Cac Column khong duoc  khai bao trong bang GRID_PROPERTY
            ReDim p_FieldNAme(0 To p_GridView.Columns.Count - 1)
            ReDim p_FieldCaption(0 To p_GridView.Columns.Count - 1)
            For p_Count = 0 To p_GridView.Columns.Count - 1
                p_FieldNAme(p_Count) = p_GridView.Columns(p_Count).FieldName
                p_FieldCaption(p_Count) = p_GridView.Columns(p_Count).Caption

                ' p_TrueGird.Columns(p_Count).DataField = p_TrueGird.Columns(p_Count).DataField
            Next

            'p_BindingSource.ResetBindings(True)
            For p_Count = 0 To UBound(p_FieldNAme, 1)
                p_GridView.Columns(p_Count).FieldName = p_FieldNAme(p_Count)
                p_GridView.Columns(p_Count).Caption = p_FieldCaption(p_Count)

            Next
            p_TrueGird.Refresh()

            Try

            Catch ex As Exception
                p_DesError = ex.Message
                p_Set_TrueGrid_Property_LoadPage = False
            End Try

        Catch ex As Exception
            p_DesError = ex.Message
            p_Set_TrueGrid_Property_LoadPage = False
        End Try


    End Function


    Public Function p_Set_TrueGrid_Property_LoadPageNew(ByRef p_DesError As String, _
                                                 ByVal p_SQLString As String, _
                                                 ByRef p_Form As Form, _
                                                ByRef p_BindingSource As BindingSource, _
                                                ByRef p_TrueGird As U_TextBox.TrueDBGrid, _
                                                ByRef p_GridView As U_TextBox.GridView, _
                                                ByVal p_FieldKey As String, _
                                                ByVal p_PageNum As Integer, _
                                                ByVal p_LineOfPage As Integer, _
                                                 ByRef p_PageTotal As Integer, _
                                                Optional ByVal B1Get As Boolean = True, _
                                                Optional ByVal p_LoadPage As Boolean = False) As Boolean

        Dim p_Count As Integer
        Dim p_FieldNAme() As String
        Dim p_FieldCaption() As String
        Dim p_SQL As String = ""
        Dim p_ViewName As String = ""
        Dim p_NoCustomize As Boolean = False
        Dim p_Where As String = ""
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Dim p_Column As U_TextBox.GridColumn
        Dim p_DataTmp As DataTable
        Dim p_SQLTotal As String
        Try

            p_GridView.OptionsBehavior.AllowAddRows = DefaultBoolean.True
            p_GridView.OptionsBehavior.AllowDeleteRows = DefaultBoolean.False
            p_GridView.OptionsBehavior.Editable = False
            p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            p_GridView.OptionsNavigation.EnterMoveNextColumn = True


            p_Set_TrueGrid_Property_LoadPageNew = True
            If p_SQLString = "" Then
                p_Set_TrueGrid_Property_LoadPageNew = False
                Exit Function
            End If

            p_SQL = UCase(p_SQLString)

            p_SQLTotal = "select ceiling( COUNT(*)/CONVERT(float," & p_LineOfPage & "))  as TotalPage  from ( " & p_SQL & " ) A"

            If p_FieldKey <> "" And p_LoadPage = True Then
                p_SQL = "SELECT * FROM (" & _
                                        " SELECT *, ROW_NUMBER() OVER (ORDER BY " & p_FieldKey & ") AS RowNum" & _
                                        " FROM (" & p_SQLString & ") anhqh " & _
                                    " ) AS MyDerivedTable " & _
                                    " WHERE MyDerivedTable.RowNum BETWEEN (" & p_PageNum & " -1)* " & p_LineOfPage & " +1  " & _
                                    " AND " & (p_PageNum * p_LineOfPage)
            Else
                p_SQL = p_SQLString
            End If
            '  p_BindingSource.ResetBindings(True)
            ' p_TrueGird.Refresh()
            If B1Get = True Then
                p_BindingSource.DataSource = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQL).Tables(0)
                p_DataTmp = g_Service.mod_SYS_GET_DATASET(p_SQLTotal).Tables(0)
                If Not p_DataTmp Is Nothing Then
                    If p_DataTmp.Rows.Count > 0 Then
                        p_PageTotal = p_DataTmp.Rows(0).Item("TotalPage").ToString.Trim
                    End If
                End If
            Else
                ' Dim p_DTSet As DataSet
                ' p_DTSet= g_Service.mod_SYS_GET_DATASET(p_SQL)
                p_BindingSource.DataSource = g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
                p_SQLTotal = "select ceiling( COUNT(*)/CONVERT(float," & p_LineOfPage & "))  as TotalPage  from ( " & p_SQLString & " ) A"
                'If p_GetPageTotal = True Then
                p_DataTmp = g_Service.mod_SYS_GET_DATASET(p_SQLTotal).Tables(0)
                If Not p_DataTmp Is Nothing Then
                    If p_DataTmp.Rows.Count > 0 Then
                        p_PageTotal = p_DataTmp.Rows(0).Item("TotalPage").ToString.Trim
                    End If
                End If
                'End If
            End If

            p_TrueGird.DataSource = p_BindingSource

            'Cac Column khong duoc  khai bao trong bang GRID_PROPERTY
            'ReDim p_FieldNAme(0 To p_GridView.Columns.Count - 1)
            'ReDim p_FieldCaption(0 To p_GridView.Columns.Count - 1)
            For p_Count = 0 To p_GridView.Columns.Count - 1
                'p_FieldNAme(p_Count) = p_GridView.Columns(p_Count).FieldName
                'p_FieldCaption(p_Count) = p_GridView.Columns(p_Count).Caption
                p_Column = p_GridView.Columns(p_Count)
                If p_Column.FieldView.ToString.Trim <> "" Then

                    p_Column.FieldName = p_Column.FieldView
                End If
                ' p_TrueGird.Columns(p_Count).DataField = p_TrueGird.Columns(p_Count).DataField
            Next

            'p_BindingSource.ResetBindings(True)
            'For p_Count = 0 To UBound(p_FieldNAme, 1)
            '    p_GridView.Columns(p_Count).FieldName = p_FieldNAme(p_Count)
            '    p_GridView.Columns(p_Count).Caption = p_FieldCaption(p_Count)

            'Next
            p_TrueGird.Refresh()

            Try

            Catch ex As Exception
                p_DesError = ex.Message
                p_Set_TrueGrid_Property_LoadPageNew = False
            End Try

        Catch ex As Exception
            p_DesError = ex.Message
            p_Set_TrueGrid_Property_LoadPageNew = False
        End Try


    End Function

    Public Function p_ColumnEdit_Property(ByRef p_Form As Form, _
                                         ByVal p_DataTrueGird As DataSet, _
                                               ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                               ByVal p_ColumnEdit As String, _
                                               ByVal p_SQL As String, _
                                               Optional ByVal p_ListCount As Integer = 7, _
                                               Optional ByVal B1Get As Boolean = True) As Boolean
        Dim p_Count As Integer
        Dim p_Rows() As DataRow
        Dim p_FieldNAme() As String
        Dim p_FieldCaption() As String
        Dim p_ViewName As String = ""
        Dim p_Table As New DataTable

        Dim p_Abc As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Dim p_Col As DevExpress.XtraEditors.Controls.LookUpColumnInfo
        ' Dim p_sysbat As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        Try
            p_ColumnEdit_Property = True
            If B1Get = True Then
                'p_Table = p_sysbat.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_SQL).Tables(0)
                p_Abc.DataSource = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_SQL).Tables(0)
            Else
                p_Table = g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
                'p_Abc.DataSource = p_sysbat.mod_SYS_GET_DATASET(p_SQL).Tables(0)
            End If
            p_Abc.DataSource = p_Table


            If p_Table.Columns.Count > 0 Then
                ReDim p_FieldNAme(0 To p_Table.Columns.Count - 1)
                ReDim p_FieldCaption(0 To p_Table.Columns.Count - 1)
                For p_Count = 0 To p_Table.Columns.Count - 1
                    p_FieldNAme(p_Count) = UCase(p_Table.Columns(p_Count).ColumnName)

                Next
                For p_Count = 0 To UBound(p_FieldNAme, 1)
                    p_Col = New DevExpress.XtraEditors.Controls.LookUpColumnInfo
                    p_Abc.Columns.Add(p_Col)
                    p_Abc.Columns(p_Count).FieldName = p_FieldNAme(p_Count)
                    If p_DataTrueGird.Tables.Count > 0 Then
                        p_Rows = p_DataTrueGird.Tables(0).Select("FORM_NAME='" & UCase(p_Form.Name) & "' AND COL_NAME ='" & _
                                                    p_FieldNAme(p_Count) & "' AND GRID_NAME='" & UCase(p_ColumnEdit) & "'", "Order_By")

                        If p_Rows.Length > 0 Then
                            If p_Rows(0).Item("VISIBLE_FLAG").ToString = "N" Then
                                p_Abc.Columns(p_Count).Visible = False
                            Else
                                p_Abc.Columns(p_Count).Visible = True
                            End If



                            If p_Rows(p_Count).Item("WIDTH").ToString <> "" Then
                                p_Abc.Columns(p_Count).Width = p_Rows(p_Count).Item("WIDTH").ToString
                            End If

                            If p_Rows(p_Count).Item("CAPTION").ToString <> "" Then
                                p_Abc.Columns(p_Count).Caption = p_Rows(p_Count).Item("CAPTION").ToString
                            Else
                                p_Abc.Columns(p_Count).Caption = p_Rows(p_Count).Item("COL_NAME").ToString
                            End If
                        End If
                    End If
                Next
            Else
                Exit Function
            End If



            ' Next

            Try
                For p_Count = 0 To p_GridView.Columns.Count - 1
                    If Not p_GridView.Columns(p_Count) Is Nothing Then
                        If p_Abc.Columns(p_Count).FieldName.ToString = "" Then
                            p_Abc.Columns.RemoveAt(p_Count)
                            'Else
                            'p_Abc.Columns(p_Count).OptionsColumn.AllowEdit = True
                        End If
                    End If
                Next

            Catch ex As Exception

            End Try



            p_Abc.DropDownRows = p_ListCount
            If p_Table.Columns.Count = 1 Then
                'p_Abc.Columns.Add(p_Col)
                p_Abc.DisplayMember = p_Table.Columns(0).ColumnName
                p_Abc.ValueMember = p_ColumnEdit ' p_Table.Columns(0).ColumnName
                'p_Abc.Columns(0).FieldName = p_Table.Columns(0).ColumnName
                p_GridView.Columns(p_ColumnEdit).ColumnEdit = p_Abc
            ElseIf p_Table.Columns.Count > 1 Then
                'p_Abc.Columns.Add(p_Col)
                p_Abc.DisplayMember = p_Table.Columns(1).ColumnName
                p_Abc.ValueMember = p_ColumnEdit ' p_Table.Columns(0).ColumnName
                'p_Abc.Columns(0).FieldName = p_Table.Columns(0).ColumnName
                'p_Abc.Columns(1).FieldName = p_Table.Columns(1).ColumnName
                p_GridView.Columns(p_ColumnEdit).ColumnEdit = p_Abc
                ' p_GridView.Columns(p_GridView.Columns(p_ColumnEdit).FieldName).ColumnEdit = p_Abc
            End If

        Catch ex As Exception
            p_ColumnEdit_Property = False
        End Try
    End Function
    Public Function p_ColumnEdit_Property_BK(ByRef p_Form As Form, _
                                          ByVal p_DataTrueGird As DataSet, _
                                                ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                                ByVal p_ColumnEdit As String, _
                                                ByVal p_SQL As String, _
                                                Optional ByVal p_ListCount As Integer = 7, _
                                                Optional ByVal B1Get As Boolean = True) As Boolean
        Dim p_Count As Integer
        Dim p_Rows() As DataRow
        Dim p_FieldNAme() As String
        Dim p_FieldCaption() As String
        Dim p_ViewName As String = ""
        Dim p_Table As New DataTable

        Dim p_Abc As New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Dim p_Col As DevExpress.XtraEditors.Controls.LookUpColumnInfo
        ' Dim p_sysbat As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        Try
            p_ColumnEdit_Property_BK = True
            If B1Get = True Then
                'p_Table = p_sysbat.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_SQL).Tables(0)
                p_Abc.DataSource = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_SQL).Tables(0)
            Else
                p_Table = g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
                'p_Abc.DataSource = p_sysbat.mod_SYS_GET_DATASET(p_SQL).Tables(0)
            End If
            p_Abc.DataSource = p_Table


            If p_Table.Columns.Count > 0 Then
                ReDim p_FieldNAme(0 To p_Table.Columns.Count - 1)
                ReDim p_FieldCaption(0 To p_Table.Columns.Count - 1)
                For p_Count = 0 To p_Table.Columns.Count - 1
                    p_FieldNAme(p_Count) = UCase(p_Table.Columns(p_Count).ColumnName)

                Next
                For p_Count = 0 To UBound(p_FieldNAme, 1)
                    p_Col = New DevExpress.XtraEditors.Controls.LookUpColumnInfo
                    p_Abc.Columns.Add(p_Col)
                    p_Abc.Columns(p_Count).FieldName = p_FieldNAme(p_Count)
                    If p_DataTrueGird.Tables.Count > 0 Then
                        p_Rows = p_DataTrueGird.Tables(0).Select("FORM_NAME='" & UCase(p_Form.Name) & "' AND COL_NAME ='" & _
                                                    p_FieldNAme(p_Count) & "' AND GRID_NAME='" & UCase(p_ColumnEdit) & "'", "Order_By")

                        If p_Rows.Length > 0 Then
                            If p_Rows(0).Item("VISIBLE_FLAG").ToString = "N" Then
                                p_Abc.Columns(p_Count).Visible = False
                            Else
                                p_Abc.Columns(p_Count).Visible = True
                            End If

                            If p_Rows(p_Count).Item("WIDTH").ToString <> "" Then
                                p_Abc.Columns(p_Count).Width = p_Rows(p_Count).Item("WIDTH").ToString
                            End If

                            If p_Rows(p_Count).Item("CAPTION").ToString <> "" Then
                                p_Abc.Columns(p_Count).Caption = p_Rows(p_Count).Item("CAPTION").ToString
                            Else
                                p_Abc.Columns(p_Count).Caption = p_Rows(p_Count).Item("COL_NAME").ToString
                            End If
                        End If
                    End If
                Next
            Else
                Exit Function
            End If



            ' Next

            Try
                For p_Count = 0 To p_GridView.Columns.Count - 1
                    If Not p_GridView.Columns(p_Count) Is Nothing Then
                        If p_Abc.Columns(p_Count).FieldName.ToString = "" Then
                            p_Abc.Columns.RemoveAt(p_Count)
                            'Else
                            'p_Abc.Columns(p_Count).OptionsColumn.AllowEdit = True
                        End If
                    End If
                Next

            Catch ex As Exception

            End Try



            p_Abc.DropDownRows = p_ListCount
            If p_Table.Columns.Count = 1 Then
                'p_Abc.Columns.Add(p_Col)
                p_Abc.DisplayMember = p_Table.Columns(0).ColumnName
                p_Abc.ValueMember = p_ColumnEdit ' p_Table.Columns(0).ColumnName
                'p_Abc.Columns(0).FieldName = p_Table.Columns(0).ColumnName
                p_GridView.Columns(p_ColumnEdit).ColumnEdit = p_Abc
            ElseIf p_Table.Columns.Count > 1 Then
                'p_Abc.Columns.Add(p_Col)
                p_Abc.DisplayMember = p_Table.Columns(1).ColumnName
                p_Abc.ValueMember = p_ColumnEdit ' p_Table.Columns(0).ColumnName
                'p_Abc.Columns(0).FieldName = p_Table.Columns(0).ColumnName
                'p_Abc.Columns(1).FieldName = p_Table.Columns(1).ColumnName
                p_GridView.Columns(p_ColumnEdit).ColumnEdit = p_Abc
                ' p_GridView.Columns(p_GridView.Columns(p_ColumnEdit).FieldName).ColumnEdit = p_Abc
            End If

        Catch ex As Exception
            p_ColumnEdit_Property_BK = False
        End Try
    End Function


    Public Function p_Set_BindSource(ByRef p_Form As Form, _
                                     ByVal p_Dataset_Binding As DataSet, _
                                     ByVal p_Form_Name As String, _
                                     ByRef p_BindingNavigator1 As Object, _
                                     ByRef p_BindingSource() As BindingSource, _
                                     ByRef p_Page_Total As Integer, _
                                    ByVal p_PageNum As Integer, _
                                      Optional ByVal p_GetB1 As Boolean = True) As Boolean
        Dim p_Rows() As DataRow
        Dim p_TableHead As String
        Dim p_DBDataSet As New DataSet
        p_Set_BindSource = True

        p_Rows = p_Dataset_Binding.Tables(0).Select("FORM_NAME='" & UCase(p_Form_Name) & "'")
        If p_Rows.Count <= 0 Then Exit Function
        ReDim p_BindingSource(0 To p_Rows.Count - 1)
        For p_Count = 0 To p_Rows.Count - 1
            p_TableHead = p_Rows(p_Count).Item("VIEW_NAME").ToString

            If Mod_Get_BindingSource("SELECT * FROM  " & p_TableHead, p_BindingSource(p_Count), "", "", p_Page_Total, p_GetB1, "", g_RowNum, p_PageNum) = False Then
                GoTo Line_Err
            End If
            If p_Table_Structure(p_TableHead, p_DBDataSet, p_GetB1) = False Then
                GoTo Line_Err
            End If
            '======
            If p_Rows(p_Count).Item("BIDINGNAVIGATOR").ToString = "Y" Then
                p_BindingNavigator1.DataSource = p_BindingSource(p_Count)
            End If
            If p_Control_DataField(p_Form, p_BindingSource(p_Count), p_DBDataSet, _
                                   p_Count) = False Then
                GoTo Line_Err
            End If


        Next




        Exit Function
Line_Err:
        p_Set_BindSource = False
    End Function

    Public Function p_Set_BindSource_Header(ByVal p_SetSourceItem As Boolean, _
                                                ByRef p_Form As Form, _
                                      ByVal p_ViewName As String, _
                                      ByRef p_BingdingSource As BindingSource, _
                                      ByVal p_Table As String, ByVal p_FieldKey As String, _
                                        ByRef p_Page_Total As Integer, _
                                      Optional ByVal p_GetB1 As Boolean = True, _
                                     Optional ByVal p_Where As String = "", _
                                    Optional ByVal p_RowNum As Integer = 0, _
                                    Optional ByVal p_PageNum As Integer = 1) As Boolean
        Dim p_DBDataSet As New DataSet
        p_Set_BindSource_Header = True
        Dim p_SQL As String
        p_SQL = "SELECT * FROM  " & p_ViewName & " with (nolock) "

        If Mod_Get_BindingSource(p_SQL, p_BingdingSource, p_Table, p_FieldKey, p_Page_Total, p_GetB1, p_Where, p_RowNum, p_PageNum) = False Then
            GoTo Line_Err
        End If
        If p_TableStructure(p_ViewName, p_DBDataSet, p_GetB1) = False Then
            GoTo Line_Err
        End If
        '======
        If p_SetSourceItem = True Then
            If p_Control_DataField(p_Form, p_BingdingSource, p_DBDataSet, _
                                   0, p_GetB1) = False Then
                GoTo Line_Err
            End If

        End If
        'Next




        Exit Function
Line_Err:
        p_Set_BindSource_Header = False
    End Function



    'anhqh
    '14/10/2013
    'Ham thuc hien lay cac gia tri cua DataNavigator lam Source
    Public Function p_Set_BindSource_HeaderNew(ByRef p_DataNavigator As U_TextBox.Datanavigator,
                                               ByVal p_SetSourceItem As Boolean, _
                                                ByRef p_Form As Form, _
                                      ByRef p_BingdingSource As BindingSource, _
                                        ByRef p_Page_Total As Integer, _
                                      Optional ByVal p_GetB1 As Boolean = True, _
                                     Optional ByVal p_Where As String = "", _
                                    Optional ByVal p_PageNum As Integer = 1) As Boolean
        Dim p_DBDataSet As New DataSet
        p_Set_BindSource_HeaderNew = True
        Dim p_SQL As String

        Dim p_ViewName As String
        Dim p_Table As String
        Dim p_FieldKey As String
        Dim p_RowNum As Integer = 0
        Dim p_DataWhere As String

        p_ViewName = p_DataNavigator.ViewName

        p_FieldKey = p_DataNavigator.KeyField
        p_Table = p_DataNavigator.TableName
        p_RowNum = p_DataNavigator.RowNum
        p_DataWhere = p_DataNavigator.Where

        p_SQL = "SELECT * FROM  " & p_ViewName
        If p_DataWhere <> "" Then
            p_DataWhere = " WHERE " & p_Parameter_Item(p_Form, p_DataWhere)
        End If
        p_SQL = p_SQL & p_DataWhere
        If Mod_Get_BindingSource(p_SQL, p_BingdingSource, p_Table, p_FieldKey, p_Page_Total, p_GetB1, "", p_RowNum, p_PageNum) = False Then
            GoTo Line_Err
        End If
        p_DataNavigator.DataSource = p_BingdingSource
        If p_Table_Structure(p_ViewName, p_DBDataSet, p_GetB1) = False Then
            GoTo Line_Err
        End If
        '======
        If p_SetSourceItem = True Then
            If p_Control_DataField(p_Form, p_BingdingSource, p_DBDataSet, _
                                   0, p_GetB1) = False Then
                GoTo Line_Err
            End If

        End If
        'Next




        Exit Function
Line_Err:
        p_Set_BindSource_HeaderNew = False
    End Function


    'Lay cau truc cac bang duoi Db
    'ANHQH
    '01/01/2012

    Public Function p_TableStructure(ByVal p_TableHead As String, _
                                      ByRef p_DBDataSet As DataSet, _
                                        Optional ByVal p_GetB1 As Boolean = False) As Boolean
        Dim p_Table As New DataTable
        Dim p_SQL As String
        ' Dim p_Sysbatch As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        p_TableStructure = True
        p_TableHead = Replace(p_TableHead, "[", "", 1)
        p_TableHead = Replace(p_TableHead, "]", "", 1)
        Try
            If Not p_TableHead Is Nothing Then
                p_SQL = "select upper(B.name) as TABLE_NAME,a.object_id  as COLUMN_ID, a.name as COLUMN_NAME," & _
                    " case when  a.user_type_id In (231,175) then 'C' else case when  a.user_type_id in (61,40) then 'D' else 'N' end  end  as COLUMN_TYPE " & _
                        " from sys.all_columns A, sys.all_objects B Where a.object_id=b.object_id  and B.name='" & p_TableHead & "'"
                If p_GetB1 = False Then
                    p_Table = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
                Else
                    p_Table = g_Service.mod_SYS_GET_DATATABLE_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQL)
                    ' p_Table = g_Service.mod_SYS_GET_DATATABLE_Com(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_SQL)


                End If
                p_DBDataSet.Tables.Add(p_Table)
                'p_Sysbatch = Nothing
            End If
        Catch ex As Exception
            p_TableStructure = False

        End Try
        '  p_Sysbatch = Nothing
    End Function


    'ANHHQ
    '21/11/2011
    'Ham thuc hien select ma fill du lieu vao p_BindingSource1 va set datafile  dung ca cho bien p_abc la C1Flex
    Public Function Mod_Get_Gird_Combo(ByVal p_SQL As String, _
                                        ByRef p_BindingSource1 As Object, _
                                        ByRef p_abc As Object, _
                                        ByVal p_DisplayMember As String, _
                                       ByVal p_ValueMember As String, _
                                        Optional ByVal p_GetB1 As Boolean = False) As Boolean
        'Dim p_MnuSystem As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        Dim p_Mod_Get_Gird As New DataTable
        'Dim p_Col As New C1.Win.C1List.C1DataColumn
        Mod_Get_Gird_Combo = True
        Try

            ' = g_Company_Host
            'g_Service.g_Company_DB_Name = g_Company_DB_Name
            If p_GetB1 = False Then
                p_Mod_Get_Gird = g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
            Else
                p_Mod_Get_Gird = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_SQL).Tables(0)
            End If

            'p_BindingSource1.DataSource = p_Mod_Get_Gird

            p_abc.Properties.DataSource = p_Mod_Get_Gird



            'If p_abc.Columns.Count > 0 Then
            '    For p_Index = 0 To p_Mod_Get_Gird.Columns.Count - 1

            '        p_abc.Columns(p_Index).DataField = p_Mod_Get_Gird.Columns(p_Index).ToString
            '    Next p_Index


            'Else
            '    '    Dim p_Col As New C1.Win.C1List.C1DataColumn
            '    'p_Col.
            '    'Me.ShipType1.Columns.Add(
            '    'For p_Index = 0 To p_Mod_Get_Gird.Columns.Count - 1
            '    '    p_Col.DataField = p_Mod_Get_Gird.Columns(p_Index).ToString
            '    '    p_abc.Columns.Add(p_Col)
            '    '    'p_abc.Columns(p_Index).DataField = p_Mod_Get_Gird.Columns(p_Index).ToString
            '    'Next p_Index
            'End If


            '

            If p_DisplayMember.ToString <> "" Then
                p_abc.Properties.DisplayMember = p_DisplayMember
            Else
                p_abc.Properties.DisplayMember = p_Mod_Get_Gird.Columns(1).ToString
            End If
            If p_ValueMember.ToString <> "" Then
                p_abc.Properties.ValueMember = p_ValueMember
            Else
                p_abc.Properties.ValueMember = p_Mod_Get_Gird.Columns(0).ToString
            End If



            'p_abc.Properties.DisplayMember = p_Mod_Get_Gird.Columns(0).ToString
            'p_abc.Properties.ValueMember = p_Mod_Get_Gird.Columns(0).ToString


            'p_BindingSource1.ResetBindings(True)
            ' p_abc.Rebind(True)
            p_abc.AutoSize = True
            'If p_abc.Columns.Count > 0 Then
            '    p_abc.Columns(0).DataWidth = 10
            'End If
            ' p_abc.ColumnHeaders = False
        Catch ex As Exception
            Mod_Get_Gird_Combo = False
        End Try

        'Currency
    End Function

    'ANHHQ
    '21/11/2011
    'Ham thuc hien select ma fill du lieu vao p_BindingSource1 va set datafile  dung ca cho bien p_abc la C1Flex
    Public Function Mod_Get_Gird_ComboNew(ByVal p_SQL As String, _
                                        ByRef p_abc As Object, _
                                        ByVal p_DisplayMember As String, _
                                       ByVal p_ValueMember As String, _
                                        Optional ByVal p_GetB1 As Boolean = False) As Boolean
        'Dim p_MnuSystem As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        Dim p_Mod_Get_Gird As New DataTable
        'Dim p_Col As New C1.Win.C1List.C1DataColumn
        Mod_Get_Gird_ComboNew = True
        Try

            ' SystemBatch.g_Company_Host = g_Company_Host
            'SystemBatch.g_Company_DB_Name = g_Company_DB_Name
            If p_GetB1 = False Then
                p_Mod_Get_Gird = g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
            Else
                p_Mod_Get_Gird = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQL).Tables(0)
            End If


            p_abc.Properties.DataSource = p_Mod_Get_Gird


            If p_DisplayMember.ToString <> "" Then
                p_abc.Properties.DisplayMember = p_DisplayMember
            Else
                If p_Mod_Get_Gird.Columns.Count = 1 Then
                    p_abc.Properties.DisplayMember = p_Mod_Get_Gird.Columns(0).ToString
                Else
                    p_abc.Properties.DisplayMember = p_Mod_Get_Gird.Columns(1).ToString
                End If
                ' p_abc.Properties.DisplayMember = p_Mod_Get_Gird.Columns(1).ToString
            End If
            If p_ValueMember.ToString <> "" Then
                p_abc.Properties.ValueMember = p_ValueMember
            Else
                p_abc.Properties.ValueMember = p_Mod_Get_Gird.Columns(0).ToString
            End If
            p_abc.AutoSize = True
        Catch ex As Exception
            MsgBox("Mod_Get_Gird_ComboNew (" & p_abc.name & "): " & ex.Message)
            Mod_Get_Gird_ComboNew = False
        End Try

        'Currency
    End Function

    Public Sub p_ComboboxAddValue(ByRef p_Combobox As U_TextBox.U_Combobox, ByVal p_Code As String, ByVal p_Name As String)
        Dim p_Datatable As DataTable
        Dim p_Col1 As DataColumn '  New DataColumn("Column0")
        Dim p_DataRow As DataRow
        Dim p_SQL As String = ""
        Dim p_DisplayMember As String = "Name"
        Dim p_ValueMember As String = "Code"
        Try
            p_Datatable = p_Combobox.Properties.DataSource
            'p_DisplayMember = p_Combobox.DisplayField
            ' p_ValueMember = p_Combobox.ValueField
            If p_Datatable Is Nothing Then
                p_Datatable = New DataTable("Table0")
                p_Col1 = New DataColumn(p_ValueMember)
                p_Col1.DataType = GetType(String)
                p_Datatable.Columns.Add(p_Col1)
                p_Col1 = New DataColumn(p_DisplayMember)
                p_Col1.DataType = GetType(String)
                p_Datatable.Columns.Add(p_Col1)
            End If

            p_DataRow = p_Datatable.NewRow
            p_DataRow.Item(0) = p_Code
            p_DataRow.Item(1) = p_Name
            p_Datatable.Rows.Add(p_DataRow)

            p_Combobox.Properties.DataSource = p_Datatable
            p_Combobox.Properties.DisplayMember = p_DisplayMember
            p_Combobox.Properties.ValueMember = p_ValueMember
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub


    'ANHHQ
    '21/11/2011
    'Ham thuc hien select ma fill du lieu vao p_BindingSource1 va set datafile  dung ca cho bien p_abc la C1Flex
    Public Function Mod_Get_Gird(ByVal p_SQL As String, ByRef p_BindingSource1 As Object, _
                                        ByRef p_abc As Object, _
                                        Optional ByVal p_GetB1 As Boolean = False) As Boolean
        'Dim p_MnuSystem As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        Dim p_Mod_Get_Gird As New DataTable
        Dim p_Type As String = ""
        Mod_Get_Gird = True
        Try
            'SystemBatch.g_Company_Host = g_Company_Host
            'SystemBatch.g_Company_DB_Name = g_Company_DB_Name
            If p_GetB1 = False Then
                p_Mod_Get_Gird = g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
            Else
                p_Mod_Get_Gird = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_SQL).Tables(0)
            End If

            p_BindingSource1.DataSource = p_Mod_Get_Gird
            For p_Index = 0 To p_Mod_Get_Gird.Columns.Count - 1
                p_abc.Columns(p_Index).DataField = p_Mod_Get_Gird.Columns(p_Index).ToString
            Next p_Index
            p_BindingSource1.ResetBindings(True)
            p_abc.Refresh()
        Catch ex As Exception
            Mod_Get_Gird = False
        End Try



    End Function


    'ANHHQ
    '21/11/2011
    'Ham thuc hien select ma fill du lieu vao p_BindingSource1 
    Public Function Mod_Get_BindingSource(ByVal p_SQL As String, _
                                ByRef p_BindingSource1 As BindingSource, _
                                ByVal p_Table As String, ByVal p_FieldKey As String, _
                                ByRef p_Page_Total As Integer, _
                                Optional ByVal p_GetB1 As Boolean = False, _
                                 Optional ByVal p_Where As String = "", _
                                Optional ByVal p_RowNum As Integer = 0, _
                                Optional ByVal p_PageNum As Integer = 1) As Boolean
        'Dim p_MnuSystem As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        Dim p_Mod_Get_Gird As DataTable
        Dim p_DataSet As New DataSet
        ' Dim p_Page_Total As Integer
        Mod_Get_BindingSource = True
        'Dim sSQL As String
        Try
            If p_BindingSource1 Is Nothing Then
                p_BindingSource1 = New BindingSource
            End If
            If p_GetB1 = False Then
                p_Mod_Get_Gird = g_Service.mod_SYS_GET_DATASET_PAGE(p_SQL, p_Table, p_FieldKey, p_Page_Total, p_Where, p_RowNum, p_PageNum).tables(0)


                'Function mod_SYS_GET_DATASET_PAGE(ByVal p_SQLTotalPage As String, _
                '                          ByVal p_Table As String, ByVal p_FieldKey As String, _
                '                          ByRef p_Page_Total As Integer, _
                '                          Optional ByVal p_Where As String = "", _
                '                             Optional ByVal p_RowNum As Integer = 0, _
                '                             Optional ByVal p_PageNum As Integer = 1) As System.Data.DataSet

            Else
                p_Mod_Get_Gird = g_Service.mod_SYS_GET_DATATABLE_PAGE_Com(g_Company_Host, g_Company_DB_Name, _
                    g_DBUsr, g_DBPass, g_Port, p_SQL, p_Table, p_FieldKey, p_Page_Total, p_Where, p_RowNum, p_PageNum)

                'sSQL = " SELECT * FROM (     SELECT *, ROW_NUMBER() OVER (ORDER BY CardCode) AS RowNum  FROM OCRD " & _
                '   ") AS MyDerivedTable WHERE MyDerivedTable.RowNum BETWEEN 1 AND 20   "

                'p_Mod_Get_Gird = g_Service.mod_SYS_GET_DATATABLE_Com(g_Company_Host, g_Company_DB_Name, _
                '    g_UsrB1, g_PassB1, g_Port, sSQL) '"select top 10 * from OCRD ")
            End If
            '  If Not p_DataSet Is Nothing Then
            ' p_Mod_Get_Gird = p_DataSet.Tables(0)
            p_BindingSource1.DataSource = p_Mod_Get_Gird
            p_BindingSource1.ResetBindings(True)
            '  End If
        Catch ex As Exception
            Mod_Get_BindingSource = False
        End Try
    End Function


    ''ANHHQ
    ''21/11/2011
    ''Ham thuc hien select ma fill du lieu vao p_BindingSource1 
    'Public Function Mod_Get_BindingSource(ByVal p_SQL As String, _
    '                            ByRef p_BindingSource1 As BindingSource, _
    '                            Optional ByVal p_GetB1 As Boolean = False, _
    '                             Optional ByVal p_Where As String = "", _
    '                            Optional ByVal p_RowNum As Integer = 0, _
    '                            Optional ByVal p_PageNum As Integer = 1) As Boolean
    '    ' Dim p_MnuSystem As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
    '    Dim p_Mod_Get_Gird As New DataTable
    '    Dim p_Page_Total As Integer
    '    Mod_Get_BindingSource = True
    '    Try
    '        If p_BindingSource1 Is Nothing Then
    '            p_BindingSource1 = New BindingSource
    '        End If
    '        If p_GetB1 = False Then
    '            p_Mod_Get_Gird = g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
    '        Else
    '            p_Mod_Get_Gird = g_Service.mod_SYS_GET_DATATABLE_PAGE_Com(g_Company_Host, g_Company_DB_Name, _
    '                g_UsrB1, g_PassB1, g_Port, p_SQL, p_Page_Total, p_Where, p_RowNum, p_PageNum).Tables(0)
    '        End If
    '        p_BindingSource1.DataSource = p_Mod_Get_Gird
    '        p_BindingSource1.ResetBindings(True)
    '    Catch ex As Exception
    '        Mod_Get_BindingSource = False
    '    End Try
    'End Function

    'ANHQH
    '01/01/2012
    'Ham thuc hien Set  SelectValue cho Combobox
    Public Function p_ComboboxGetValue(ByRef p_Form As System.Windows.Forms.Form, ByVal p_ComboboxObj() As String, _
                                    ByVal p_ComboboxValue() As String) As Boolean
        Dim p_Count As Integer
        Dim p_ObjCombo As Object
        Dim p_ObjValue As Object
        p_ComboboxGetValue = True
        Try
            For p_Count = 0 To UBound(p_ComboboxObj, 1)
                If Not p_ComboboxObj(p_Count) Is Nothing Then
                    p_ObjCombo = p_Form.Controls.Find(p_ComboboxObj(p_Count), True)
                    p_ObjValue = p_Form.Controls.Find(p_ComboboxValue(p_Count), True)
                    If p_ObjCombo.length > 0 And p_ObjValue.length > 0 Then
                        p_ObjCombo(0).SelectedValue = p_ObjValue(0).Value.ToString
                    End If
                End If
            Next
        Catch ex As Exception
            p_ComboboxGetValue = False
        End Try

    End Function

    'ANHQH
    '01/01/2012
    'Ham thuc hien Check cho CheckBox
    Public Function p_CheckboxGetValue(ByRef p_Form As System.Windows.Forms.Form, ByVal p_CheckboxObj() As String, _
                                    ByVal p_CheckboxValue() As String) As Boolean
        Dim p_Count As Integer
        Dim p_ObjCombo As Object
        Dim p_ObjValue As Object
        p_CheckboxGetValue = True
        Try
            For p_Count = 0 To UBound(p_CheckboxObj, 1)
                If Not p_CheckboxObj(p_Count) Is Nothing Then
                    p_ObjCombo = p_Form.Controls.Find(p_CheckboxObj(p_Count), True)
                    p_ObjValue = p_Form.Controls.Find(p_CheckboxValue(p_Count), True)
                    If p_ObjCombo.length > 0 And p_ObjValue.length > 0 Then
                        If p_ObjValue(0).Value.ToString = "Y" Or p_ObjValue(0).Value.ToString = "1" Then
                            p_ObjCombo(0).Checked = True
                        Else
                            p_ObjCombo(0).Checked = False
                        End If

                    End If
                End If
            Next
        Catch ex As Exception
            p_CheckboxGetValue = False
        End Try


    End Function





    'ANHQH
    '01/01/2012
    'Ham thuc hien kiem tra cac item bat buoc nhap ma khong co gia tri
    Public Function p_Check_Control_Required(ByRef p_Form As Object, ByRef p_Des As String) As Boolean

        Dim p_Object As Object
        Dim p_Object_Item As Object
        ' Dim p_Object_Value As Object

        'Dim p_ItemName As String
        ' Dim p_Rows() As DataRow
        Dim p_Count As Integer
        Dim p_TabControl_Ind As Integer
        'Dim p_View_Name As String
        Dim p_Control_Ind As Integer
        Dim p_Value As String
        Dim p_CountObj As Integer
        Dim p_CountObj1 As Integer = Nothing

        p_Check_Control_Required = True
        p_Des = ""
        p_CountObj = 0
        Try
            For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                p_Object = p_Form.Controls.Item(p_Control_Ind)
                'If p_Object.name = "PanelControl1" Then
                '    MsgBox("sda")
                'End If
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                          Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                      Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then

                    p_Value = p_Object.Required
                    If p_Value = "Y" Then
                        If p_Object.EditValue Is Nothing Then
                            p_Value = ""
                        Else
                            p_Value = p_Object.EditValue.ToString
                        End If

                        If p_Value Is Nothing Then
                            p_Des = p_Object.Name & ":Thông tin nhập chưa đầy đủ"
                            p_Check_Control_Required = False
                            If p_Object.Visible = True Then
                                p_Object.Focus()
                                Exit Function
                            End If
                        ElseIf p_Value = "" Then
                            p_Des = p_Object.Name & ":Thông tin nhập chưa đầy đủ"
                            p_Check_Control_Required = False
                            If p_Object.Visible = True Then
                                p_Object.Focus()
                                Exit Function
                            End If
                        End If
                    End If

                    'End If
                End If


                'Xu ly cho cac item tabpage
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    If p_Check_Control_RequiredPage(p_Form,
                                                            p_Object,
                                                            p_Des) = False Then
                        p_Check_Control_Required = False
                        ' MsgBox(p_Des)
                        Exit Function
                    End If
                    '
                    'For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                    '    p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                    '    For p_Count = 0 To p_Object_Item.Controls.Count - 1
                    '        If InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                    '            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                    '            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                    '            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                    '             Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                    '              Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then
                    '            p_Value = p_Object_Item.Controls(p_Count).Required
                    '            If p_Value = "Y" Then
                    '                If p_Object_Item.Controls(p_Count).EditValue Is Nothing Then
                    '                    p_Value = ""
                    '                Else
                    '                    p_Value = p_Object_Item.Controls(p_Count).EditValue.ToString
                    '                End If

                    '                If p_Value Is Nothing Then
                    '                    p_Des = p_Object.Name & ":Thông tin nhập chưa đầy đủ"
                    '                    p_Check_Control_Required = False
                    '                    p_Object.SelectedIndex = p_TabControl_Ind
                    '                    If p_Object_Item.Controls(p_Count).Visible = True Then
                    '                        p_Object_Item.Controls(p_Count).Focus()
                    '                        Exit Function
                    '                    End If
                    '                ElseIf p_Value = "" Then
                    '                    p_Des = p_Object.Name & ":Thông tin nhập chưa đầy đủ"
                    '                    p_Check_Control_Required = False
                    '                    p_Object.SelectedIndex = p_TabControl_Ind
                    '                    If p_Object_Item.Controls(p_Count).Visible = True Then
                    '                        p_Object_Item.Controls(p_Count).Focus()
                    '                        Exit Function
                    '                    End If
                    '                End If
                    '            End If

                    '        End If

                    '    Next
                    'Next


                End If


                'Xu ly cho cac item PanelControl
                'If InStr(UCase(p_Object.GetType.ToString), pv_Type_PanelControl, CompareMethod.Text) > 0 Then
                '    '
                '    'For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                '    'p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                '    p_Object_Item = p_Object
                '    For p_Count = 0 To p_Object_Item.Controls.Count - 1
                '        If InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                '            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                '            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                '            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                '             Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                '             Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then
                '            p_Value = p_Object_Item.Controls(p_Count).Required
                '            'If p_Object_Item.Controls(p_Count).Name = "U_Nganh" Then
                '            '    MsgBox("dfgdgd")
                '            'End If
                '            If p_Value = "Y" Then
                '                If p_Object_Item.Controls(p_Count).EditValue Is Nothing Then
                '                    p_Value = ""
                '                Else
                '                    p_Value = p_Object_Item.Controls(p_Count).EditValue.ToString
                '                End If

                '                If p_Value Is Nothing Then
                '                    p_Des = p_Object.Name & ":Thông tin nhập chưa đầy đủ"
                '                    p_Check_Control_Required = False
                '                    'p_Object.SelectedIndex = p_TabControl_Ind
                '                    If p_Object_Item.Controls(p_Count).Visible = True Then
                '                        p_Object_Item.Controls(p_Count).Focus()
                '                        Exit Function
                '                    End If
                '                ElseIf p_Value = "" Then
                '                    p_Des = p_Object.Name & ":Thông tin nhập chưa đầy đủ"
                '                    p_Check_Control_Required = False
                '                    ' p_Object.SelectedIndex = p_TabControl_Ind
                '                    If p_Object_Item.Controls(p_Count).Visible = True Then
                '                        p_Object_Item.Controls(p_Count).Focus()
                '                        Exit Function
                '                    End If
                '                End If
                '            End If

                '        End If

                '    Next
                'Next


                'End If
            Next
        Catch ex As Exception
            'MsgBox("Err:" & p_Control_Ind)
            p_Check_Control_Required = False
            p_Des = ex.Message
        End Try

    End Function



    'ANHQH
    '01/01/2012
    'Ham thuc hien kiem tra cac item bat buoc nhap ma khong co gia tri
    Public Function p_Check_Control_RequiredPage(ByRef p_Form As Object, _
                                                            ByRef p_Object As Object, _
                                                            ByRef p_Des As String) As Boolean

        'Dim p_Object As Object
        Dim p_Object_Item As Object
        ' Dim p_Object_Value As Object

        'Dim p_ItemName As String
        ' Dim p_Rows() As DataRow
        Dim p_Count As Integer
        Dim p_TabControl_Ind As Integer
        'Dim p_View_Name As String
        Dim p_Control_Ind As Integer
        Dim p_Value As String
        Dim p_CountObj As Integer
        Dim p_CountObj1 As Integer = Nothing
        Dim p_TabPage As Object
        p_Check_Control_RequiredPage = True
        p_Des = ""
        p_CountObj = 0
        Try

            'Xu ly cho cac item tabpage
            If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                '
                For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                    p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                    If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                        If p_Check_Control_RequiredPage(p_Form,
                                                            p_Object,
                                                            p_Des) = False Then
                            Exit Function
                        End If
                    Else
                        If InStr(UCase(p_Object_Item.GetType.ToString), "XtraTabPage", CompareMethod.Text) > 0 Then
                            ' p_TabPage.Controls(p_Count1)
                            p_TabPage = p_Object_Item
                            For p_Count = 0 To p_TabPage.Controls.Count - 1
                                p_Object_Item = p_TabPage.Controls(p_Count)
                                'If p_Object_Item.name = "U_INV_TYPE" Then
                                '    MsgBox("sdfsfs")
                                'End If

                                '     For Each p_Object_Item In p_TabPage.Controls
                                If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                    Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                    Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                    Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                    Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                      Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then

                                    p_Value = p_Object_Item.Required
                                    If p_Value = "Y" Then
                                        If p_Object_Item.EditValue Is Nothing Then
                                            p_Value = ""
                                        Else
                                            p_Value = p_Object_Item.EditValue.ToString
                                        End If

                                        If p_Value Is Nothing Then
                                            p_Des = p_Object_Item.Name & ":Thông tin nhập chưa đầy đủ"
                                            p_Check_Control_RequiredPage = False
                                            'p_Object_Item.SelectedIndex = p_TabControl_Ind
                                            If p_Object_Item.Visible = True Then
                                                p_Object_Item.Focus()
                                                Exit Function
                                            End If
                                        ElseIf p_Value = "" Then
                                            p_Des = p_Object_Item.Name & ":Thông tin nhập chưa đầy đủ"
                                            p_Check_Control_RequiredPage = False
                                            'p_Object_Item.SelectedIndex = p_TabControl_Ind
                                            If p_Object_Item.Visible = True Then
                                                p_Object_Item.Focus()
                                                Exit Function
                                            End If
                                        End If
                                    End If

                                End If

                            Next
                        End If
                    End If
                Next


            End If



        Catch ex As Exception
            'MsgBox("Err:" & p_Control_Ind)
            p_Check_Control_RequiredPage = False
            p_Des = ex.Message
        End Try

    End Function

    'ANHQH
    '27/02/2014
    'Ham thuc Set thuoc tinh cho cac item bắt buộc nhập
    Public Function p_Set_Control_Required(ByRef p_Form As Object, ByRef p_Des As String) As Boolean

        Dim p_Object As Object
        Dim p_Object_Item As Object
        ' Dim p_Object_Value As Object

        'Dim p_ItemName As String
        ' Dim p_Rows() As DataRow
        Dim p_Count As Integer
        Dim p_TabControl_Ind As Integer
        'Dim p_View_Name As String
        Dim p_Control_Ind As Integer
        Dim p_Value As String
        Dim p_CountObj As Integer
        Dim p_CountObj1 As Integer = Nothing

        p_Set_Control_Required = True
        p_Des = ""
        p_CountObj = 0
        Try
            For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                p_Object = p_Form.Controls.Item(p_Control_Ind)
                'If p_Object.name = "PanelControl1" Then
                '    MsgBox("sda")
                'End If
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                      Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then

                    If p_Object.Visible = True Then
                        p_Value = p_Object.Required
                        If p_Value = "Y" Then
                            p_Object.BackColor = pv_Required_Back_Color
                        Else
                            'p_Object.BackColor = pv_Back_Color
                        End If

                    End If

                    'End If
                End If


                'Xu ly cho cac item tabpage
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    '
                    For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                        p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                        For p_Count = 0 To p_Object_Item.Controls.Count - 1
                            If InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                 Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                  Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then
                                p_Value = p_Object_Item.Controls(p_Count).Required

                                'If p_Object_Item.Controls(p_Count).Visible = True Then
                                'p_Value = p_Object.Required
                                If p_Value = "Y" Then
                                    p_Object_Item.Controls(p_Count).BackColor = pv_Required_Back_Color
                                Else
                                    'p_Object.BackColor = pv_Back_Color
                                End If

                                'End If

                            End If

                        Next
                    Next


                End If


                'Xu ly cho cac item PanelControl
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_PanelControl, CompareMethod.Text) > 0 Then
                    '
                    'For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                    'p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                    p_Object_Item = p_Object
                    For p_Count = 0 To p_Object_Item.Controls.Count - 1
                        If InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                            Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then
                            p_Value = p_Object_Item.Controls(p_Count).Required
                            'If p_Object_Item.Controls(p_Count).Name = "U_Nganh" Then
                            '    MsgBox("dfgdgd")
                            'End If
                            '  If p_Object_Item.Controls(p_Count).Visible = True Then
                            'p_Value = p_Object.Required
                            If p_Value = "Y" Then
                                p_Object_Item.Controls(p_Count).BackColor = pv_Required_Back_Color
                            Else
                                'p_Object.BackColor = pv_Back_Color
                            End If

                            'End If

                        End If

                    Next
                    'Next


                End If
            Next
        Catch ex As Exception
            'MsgBox("Err:" & p_Control_Ind)
            p_Set_Control_Required = False
            p_Des = ex.Message
        End Try

    End Function
    'ANHQH
    '01/01/2012
    'Ham thuc hien set Fieldname cho Item tren Form
    Public Function p_Control_UpdateIfNull(ByRef p_Form As Object, _
                                              Optional ByVal p_AddNew As Boolean = False) As Boolean

        Dim p_Object As Object
        Dim p_Object_Item As Object



        Dim p_Count As Integer
        Dim p_TabControl_Ind As Integer
        Dim p_Control_Ind As Integer
        Dim p_Value As String
        Dim p_CountObj As Integer
        Dim p_CountObj1 As Integer = Nothing

        p_Control_UpdateIfNull = True
        p_CountObj = 0
        Try
            For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                p_Object = p_Form.Controls.Item(p_Control_Ind)
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then

                    Try
                        p_Value = p_Object.UpdateIfNull
                        If p_Value = "Y" And p_Object.Visible = True Then
                            If p_AddNew = True Then
                                p_Object.Enabled = True
                            Else
                                If p_Object.EditValue.ToString <> "" Then
                                    p_Object.Enabled = False
                                Else
                                    p_Object.Enabled = True
                                End If
                            End If
                        Else
                            p_Object.Enabled = True
                        End If
                    Catch ex As Exception

                    End Try
                End If


                'Xu ly cho cac item tabpage
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                        p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                        For p_Count = 0 To p_Object_Item.Controls.Count - 1
                            If InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                 Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                                Try
                                    p_Value = p_Object_Item.Controls(p_Count).UpdateIfNull
                                    If p_Value = "Y" Then
                                        If p_Object_Item.Controls(p_Count).EditValue.ToString <> "" Then
                                            p_Object_Item.Controls(p_Count).Enable = False
                                        Else
                                            p_Object_Item.Controls(p_Count).Enable = True
                                        End If
                                    Else
                                        p_Object_Item.Controls(p_Count).Enable = True
                                    End If
                                Catch ex As Exception

                                End Try
                            End If

                        Next
                    Next


                End If
            Next
        Catch ex As Exception
            ' MsgBox("p_Object:" & p_Object.name)
            p_Control_UpdateIfNull = False
        End Try

    End Function

    'ANHQH
    '01/01/2012
    'Ham thuc hien set Fieldname cho Item tren Form
    Public Function p_Control_DataField(ByRef p_Form As Object, _
                                    ByVal p_BindingSource As Object, _
                                    ByVal p_DBDataSet As DataSet, ByVal p_TableID As Integer, _
                                      Optional ByVal p_GetB1 As Boolean = True) As Boolean

        Dim p_Object As Object

        Dim p_ItemName As String
        Dim p_Rows() As DataRow
        Dim p_Count As Integer

        Dim p_View_Name As String

        Dim p_Value As String

        Dim p_LocalCurrency As Boolean
        Dim p_NumberDecimal As Integer
        Dim p_LocalDecimal As Integer
        Dim p_DataRow() As DataRow
        Dim p_NumberFormat As String = "############"


        Dim p_FormLock As Boolean = False

        p_Control_DataField = True
        '  p_CountObj = 0
        Try
            p_LocalDecimal = 0
            Try
                p_FormLock = p_Form.FormLock
            Catch ex As Exception

            End Try



            If Not g_CurrencyDtl Is Nothing Then
                If g_CurrencyDtl.Rows.Count <= 0 Then
                    GetCurrencyList()
                End If
                p_LocalDecimal = g_CurrencyDecima
                'p_DataRow = g_CurrencyDtl.Select("CurrCode='" & g_Currency & "'")
                'If p_DataRow.Length > 0 Then
                '    If p_DataRow(0).Item("Decimals") > 0 Then
                '        p_LocalDecimal = p_DataRow(0).Item("Decimals")
                '    End If
                'End If
            Else
                GetCurrencyList()
                p_LocalDecimal = g_CurrencyDecima
            End If


            'For p_Control_Ind = 0 To p_Form.Controls.Count - 1
            'p_Object = p_Form.Controls.Find("U_PriLis", True)

            For Each ctrl As Control In p_Form.Controls

                p_Object = ctrl
                '
                ' For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                'p_Object = p_Form.Controls.Item(p_Control_Ind)
                'ghj()
                'If p_Object.FieldName = "U_ShpCod" Then
                '    MsgBox("sffs")
                'End If
                'If UCase(p_Object.name.ToString.Trim) = UCase("U_PriLis") Then
                '    MsgBox("dfsf")
                'End If

                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoTextBox, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then
                    p_ItemName = p_Object.FieldName
                    p_View_Name = UCase(p_Object.ViewName)

                    p_View_Name = Replace(p_View_Name, "[", "", 1)
                    p_View_Name = Replace(p_View_Name, "]", "", 1)



                    If InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 Then
                        If p_Set_Combo_PropertyNew(p_Form, p_Object, p_GetB1) = False Then
                            Exit Function
                        Else
                            '  p_Object.Properties.ShowHeader = False
                        End If
                    End If
                    p_Rows = p_DBDataSet.Tables(p_TableID).Select("COLUMN_NAME='" & p_ItemName & "' AND TABLE_NAME='" & p_View_Name & "'")
                    If p_Rows.Count > 0 Then
                        'p_Object.FieldName = p_Rows(0).Item("COLUMN_NAME").ToString
                        'p_Object.DataSource = p_BindingSource
                        p_Object.DataBindings.Add("EditValue", p_BindingSource, p_ItemName)
                        p_Object.FieldType = p_Rows(0).Item("COLUMN_TYPE").ToString
                        If InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                            p_Object.Properties.ValueChecked = p_Object.CheckValue
                            p_Object.Properties.ValueUnchecked = p_Object.UnCheckValue
                        End If

                        If p_Object.Visible = True Then
                            p_Value = p_Object.Required
                            If p_Value = "Y" Then
                                p_Object.BackColor = pv_Required_Back_Color
                            Else
                                'p_Object.BackColor = pv_Back_Color
                            End If

                        End If

                        If InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                            If p_Object.Digit = True Then
                                p_LocalCurrency = p_Object.LocalDecimal
                                p_Object.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                'p_NumberDecimal = p_Object.NumberDecimal
                                If p_LocalCurrency = False Then
                                    p_NumberDecimal = p_Object.NumberDecimal
                                    If p_NumberDecimal > 0 Then
                                        p_Object.Properties.DisplayFormat.FormatString = "#,###." & Left(p_NumberFormat, p_NumberDecimal)
                                    Else
                                        p_Object.Properties.DisplayFormat.FormatString = "#,###"
                                    End If
                                Else
                                    If p_LocalDecimal > 0 Then
                                        p_Object.Properties.DisplayFormat.FormatString = "#,###." & Left(p_NumberFormat, p_LocalDecimal)
                                    Else
                                        p_Object.Properties.DisplayFormat.FormatString = "#,###" & Left(p_NumberFormat, 6)
                                    End If
                                End If
                            Else
                                p_Object.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                p_Object.Properties.DisplayFormat.FormatString = "#############"
                            End If
                            'If p_NumberDecimal > 0 Then
                            '    p_Object.Properties.DisplayFormat.FormatString = "#,###." & Left(p_NumberFormat, p_NumberDecimal)
                            'Else
                            '    p_Object.Properties.DisplayFormat.FormatString = "#,###"
                            'End If
                        End If
                        If p_FormLock = True Then
                            p_Object.Properties.ReadOnly = True
                        Else
                            If Not p_Object.EditValue Is Nothing Then
                                If p_Object.EditValue.ToString.Trim <> "" And p_Object.UpdateIfNull.ToString.Trim = "Y" Then
                                    If p_Object.FieldType = "N" Then
                                        If p_Object.EditValue <> 0 Then
                                            Try

                                                For p_Count = 0 To 100     'g_ChooseRecordFromSearch.
                                                    If p_Form.g_ObjectUpdateIsNull(p_Count) Is Nothing Then
                                                        p_Form.g_ObjectUpdateIsNull(p_Count) = p_Object.Name
                                                        p_Form.g_ObjectUpdateIsNullColor(p_Count) = p_Object.backcolor
                                                        p_Object.backcolor = pv_Locked_Back_Color
                                                        Exit For
                                                    End If
                                                Next
                                                p_Object.Properties.ReadOnly = True

                                            Catch ex As Exception

                                            End Try
                                        End If
                                    Else
                                        If p_Object.EditValue.ToString.Trim <> "" Then
                                            Try
                                                For p_Count = 0 To 100     'g_ChooseRecordFromSearch.
                                                    If p_Form.g_ObjectUpdateIsNull(p_Count) Is Nothing Then
                                                        p_Form.g_ObjectUpdateIsNull(p_Count) = p_Object.Name
                                                        p_Form.g_ObjectUpdateIsNullColor(p_Count) = p_Object.backcolor
                                                        p_Object.backcolor = pv_Locked_Back_Color
                                                        Exit For
                                                        'ElseIf p_Form.g_ObjectUpdateIsNull(p_Count) Then
                                                        '    p_Form.g_ObjectUpdateIsNull(p_Count) = p_Object.Name
                                                        '    p_Form.g_ObjectUpdateIsNullColor(p_Count) = p_Object.backcolor
                                                        ' Exit For
                                                    End If
                                                Next
                                                p_Object.Properties.ReadOnly = True

                                            Catch ex As Exception

                                            End Try
                                        End If
                                    End If
                                End If
                                'đfdsdfdfsf
                            End If


                        End If
                    End If
                End If
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    p_Control_DataField = p_Control_DataFieldPage(p_Form,
                                              p_Object,
                                     p_BindingSource,
                                     p_DBDataSet,
                                     p_TableID,
                                       p_GetB1)
                    If p_Control_DataField = False Then Exit Function
                End If

            Next
        Catch ex As Exception
            MsgBox("Control Data Field: " & ex.Message)
            p_Control_DataField = False
        End Try

    End Function


    Private Function p_Control_DataFieldPage(ByRef p_Form As Object, _
                                             ByRef p_Object As Object, _
                                    ByVal p_BindingSource As Object, _
                                    ByVal p_DBDataSet As DataSet, ByVal p_TableID As Integer, _
                                      Optional ByVal p_GetB1 As Boolean = True) As Boolean

        Dim p_Object_Item As Object
        'Dim p_Object_Value As Object

        Dim p_ItemName As String
        Dim p_Rows() As DataRow
        Dim p_Count As Integer
        Dim p_TabControl_Ind As Integer
        Dim p_View_Name As String
        ' Dim p_Control_Ind As Integer
        Dim p_Value As String
        ' Dim p_CountObj As Integer
        Dim p_CountObj1 As Integer = Nothing

        Dim p_Count123 As Integer
        Dim p_LocalCurrency As Boolean
        Dim p_NumberDecimal As Integer
        Dim p_LocalDecimal As Integer
        ' Dim p_DataRow() As DataRow
        Dim p_NumberFormat As String = "############"
        Dim p_Count1 As Integer
        'Xu ly cho cac item tabpage
        Dim p_TabPage As Object
        Dim p_FormLock As Boolean = False

        p_Control_DataFieldPage = True

        Try
            p_FormLock = p_Form.FormLock
        Catch ex As Exception

        End Try

        If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
            Try
                ' For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                For p_Count = p_Object.TabPages.Count - 1 To 0 Step -1
                    'For Each p_Control In p_Object.Controls

                    p_Object.SelectedTabPageIndex = p_TabControl_Ind

                    p_Object_Item = p_Object.TabPages(p_Count)

                    'If p_Object_Item.name = "XtraTabPage7" Then
                    '    MsgBox("dfgdfgg")
                    'End If

                    'p_Object_Item = p_Object.Controls(p_Count)
                    If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                        p_Control_DataFieldPage = p_Control_DataFieldPage(p_Form,
                                              p_Object,
                                                 p_BindingSource,
                                                 p_DBDataSet, p_TableID,
                                                    p_GetB1)
                        If p_Control_DataFieldPage = False Then Exit Function
                    Else
                        If InStr(UCase(p_Object_Item.GetType.ToString), "XtraTabPage", CompareMethod.Text) > 0 Then
                            p_TabPage = p_Object_Item
                            'For p_Count1 = 0 To p_TabPage.Controls.Count - 1
                            For Each p_Object_Item In p_TabPage.Controls
                                'p_Object_Item = p_TabPage.Controls(p_Count1)
                                'If UCase(p_Object_Item.name.ToString.Trim) = UCase("U_Status") Then
                                '    MsgBox("sdfsdf")
                                'End If
                                If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                                    p_Control_DataFieldPage = p_Control_DataFieldPage(p_Form,
                                                          p_Object_Item,
                                                             p_BindingSource,
                                                             p_DBDataSet, p_TableID,
                                                                p_GetB1)
                                    If p_Control_DataFieldPage = False Then Exit Function
                                Else

                                    If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                        Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                        Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                        Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_MemoTextBox, CompareMethod.Text) > 0 _
                                        Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                        Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then
                                        p_ItemName = p_Object_Item.fieldname

                                        'If p_Object_Item.FieldName = "AccDownPay" Or p_Object_Item.FieldName = "MDownPay" Then
                                        '    MsgBox("sdfsf")
                                        'End If

                                        p_View_Name = UCase(p_Object_Item.ViewName)
                                        If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 Then
                                            If p_Set_Combo_PropertyNew(p_Form, p_Object_Item, p_GetB1) = False Then
                                                Exit Function
                                            End If
                                        End If

                                        p_Rows = p_DBDataSet.Tables(p_TableID).Select("COLUMN_NAME='" & p_ItemName & "' AND TABLE_NAME='" & p_View_Name & "'")
                                        If p_Rows.Count > 0 Then

                                            ''p_Object_Item.DataField = p_Rows(0).Item("COLUMN_NAME").ToString
                                            ''p_Object_Item.DataSource = p_BindingSource
                                            p_Object_Item.DataBindings.Add("EditValue", p_BindingSource, p_ItemName)
                                            p_Object_Item.FieldType = p_Rows(0).Item("COLUMN_TYPE").ToString
                                            If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                p_Object_Item.Properties.ValueChecked = p_Object_Item.CheckValue
                                                p_Object_Item.Properties.ValueUnchecked = p_Object_Item.UnCheckValue
                                            End If



                                            'If p_Object_Item.Visible = True Then
                                            p_Value = p_Object_Item.Required
                                            If p_Value = "Y" Then
                                                p_Object_Item.BackColor = pv_Required_Back_Color
                                            Else
                                                'p_Object_Item.BackColor = pv_Back_Color
                                            End If

                                            'End If

                                            If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                                                If p_Object_Item.Digit = True Then
                                                    p_LocalCurrency = p_Object_Item.LocalDecimal
                                                    p_Object_Item.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                                    'p_NumberDecimal = p_Object.NumberDecimal
                                                    If p_LocalCurrency = False Then
                                                        p_NumberDecimal = p_Object_Item.NumberDecimal
                                                        If p_NumberDecimal > 0 Then
                                                            p_Object_Item.Properties.DisplayFormat.FormatString = "#,###." & Left(p_NumberFormat, p_NumberDecimal)
                                                        Else
                                                            p_Object_Item.Properties.DisplayFormat.FormatString = "#,###"
                                                        End If
                                                    Else
                                                        If p_LocalDecimal > 0 Then
                                                            p_Object_Item.Properties.DisplayFormat.FormatString = "#,###." & Left(p_NumberFormat, p_LocalDecimal)
                                                        Else
                                                            p_Object_Item.Properties.DisplayFormat.FormatString = "#,###" & Left(p_NumberFormat, 6)
                                                        End If
                                                    End If
                                                Else
                                                    p_Object_Item.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                                    p_Object_Item.Properties.DisplayFormat.FormatString = "#############"
                                                End If
                                                'If p_NumberDecimal > 0 Then
                                                '    p_Object.Properties.DisplayFormat.FormatString = "#,###." & Left(p_NumberFormat, p_NumberDecimal)
                                                'Else
                                                '    p_Object.Properties.DisplayFormat.FormatString = "#,###"
                                                'End If
                                            End If

                                            'If p_FormLock = True Then
                                            '    p_Object_Item.Properties.ReadOnly = True
                                            'End If

                                            If p_FormLock = True Then
                                                p_Object_Item.Properties.ReadOnly = True
                                            Else
                                                If Not p_Object_Item.EditValue Is Nothing Then
                                                    If p_Object_Item.EditValue.ToString.Trim <> "" And p_Object_Item.UpdateIfNull.ToString.Trim = "Y" Then
                                                        If p_Object_Item.FieldType = "N" Then
                                                            If p_Object_Item.EditValue <> 0 Then
                                                                Try
                                                                    For p_Count123 = 0 To 50     'g_ChooseRecordFromSearch.
                                                                        If p_Form.g_ObjectUpdateIsNull(p_Count) Is Nothing Then
                                                                            p_Form.g_ObjectUpdateIsNull(p_Count) = p_Object_Item.Name
                                                                            p_Form.g_ObjectUpdateIsNullColor(p_Count) = p_Object_Item.backcolor
                                                                            p_Object_Item.backcolor = pv_Locked_Back_Color
                                                                            Exit For
                                                                        End If
                                                                    Next

                                                                    p_Object_Item.Properties.ReadOnly = True

                                                                Catch ex As Exception

                                                                End Try
                                                            End If
                                                        Else
                                                            If p_Object_Item.EditValue.ToString.Trim <> "" Then
                                                                Try
                                                                    For p_Count123 = 0 To 50     'g_ChooseRecordFromSearch.
                                                                        If p_Form.g_ObjectUpdateIsNull(p_Count) Is Nothing Then
                                                                            p_Form.g_ObjectUpdateIsNull(p_Count) = p_Object_Item.Name

                                                                            p_Form.g_ObjectUpdateIsNullColor(p_Count) = p_Object_Item.backcolor
                                                                            p_Object_Item.backcolor = pv_Locked_Back_Color

                                                                            Exit For
                                                                            'ElseIf p_Form.g_ObjectUpdateIsNull(p_Count) Then
                                                                            '    p_Form.g_ObjectUpdateIsNull(p_Count) = p_Object_Item.Name
                                                                            '    Exit For
                                                                        End If
                                                                    Next
                                                                    p_Object_Item.Properties.ReadOnly = True

                                                                Catch ex As Exception

                                                                End Try
                                                            End If
                                                        End If
                                                    End If
                                                End If


                                            End If



                                        End If
                                    End If
                                End If
                            Next

                        End If
                    End If
                    p_Object.TabPages(p_Count).Select()
                Next
            Catch ex As Exception

                p_Control_DataFieldPage = False
                MsgBox("Control Data Field Page: " & ex.Message)

            End Try


        End If
    End Function


    'ANHQH
    '01/01/2012
    'Ham thuc hien set Fieldname cho Item tren Form
    Public Function p_Control_DataFieldHeader(ByRef p_Form As Object, _
                                    ByVal p_BindingSource As Object, _
                                    ByVal p_DBDataSet As DataSet, ByVal p_TableID As Integer, _
                                      Optional ByVal p_GetB1 As Boolean = True) As Boolean

        Dim p_Object As Object
        Dim p_Object_Item As Object
        'Dim p_Object_Value As Object

        Dim p_ItemName As String
        Dim p_Rows() As DataRow
        Dim p_Count As Integer
        Dim p_TabControl_Ind As Integer
        Dim p_View_Name As String
        Dim p_Control_Ind As Integer
        Dim p_Value As String
        Dim p_CountObj As Integer
        Dim p_CountObj1 As Integer = Nothing


        Dim p_LocalCurrency As Boolean
        Dim p_NumberDecimal As Integer
        Dim p_LocalDecimal As Integer
        Dim p_DataRow() As DataRow
        Dim p_NumberFormat As String = "############"
        Dim p_Count1 As Integer

        p_Control_DataFieldHeader = True
        p_CountObj = 0
        Try
            p_LocalDecimal = 0
            If Not g_CurrencyDtl Is Nothing Then
                If g_CurrencyDtl.Rows.Count <= 0 Then
                    GetCurrencyList()
                End If
                p_DataRow = g_CurrencyDtl.Select("CurrCode='" & g_Currency & "'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("Decimals") > 0 Then
                        p_LocalDecimal = p_DataRow(0).Item("Decimals")
                    End If
                End If
            End If

            'p_Rows = p_DBDataSet.Tables(p_TableID).Select("TABLE_NAME='" & p_View_Name & "'")

            'For p_Count1 = 0 To p_Rows.Length - 1
            '    p_Object = p_Form.Controls.Find("", True)
            'Next






            For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                p_Object = p_Form.Controls.Item(p_Control_Ind)
                'ghj()
                'If p_Object.FieldName = "U_ShpCod" Then
                '    MsgBox("sffs")
                'End If
                If UCase(p_Object.name.ToString.Trim) = UCase("U_PriLis") Then
                    MsgBox("dfsf")
                End If

                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoTextBox, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then
                    p_ItemName = p_Object.FieldName
                    p_View_Name = UCase(p_Object.ViewName)

                    p_View_Name = Replace(p_View_Name, "[", "", 1)
                    p_View_Name = Replace(p_View_Name, "]", "", 1)



                    If InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 Then
                        If p_Set_Combo_PropertyNew(p_Form, p_Object, p_GetB1) = False Then
                            Exit Function
                        Else
                            '  p_Object.Properties.ShowHeader = False
                        End If
                    End If
                    p_Rows = p_DBDataSet.Tables(p_TableID).Select("COLUMN_NAME='" & p_ItemName & "' AND TABLE_NAME='" & p_View_Name & "'")
                    If p_Rows.Count > 0 Then
                        'p_Object.FieldName = p_Rows(0).Item("COLUMN_NAME").ToString
                        'p_Object.DataSource = p_BindingSource
                        p_Object.DataBindings.Add("EditValue", p_BindingSource, p_ItemName)
                        p_Object.FieldType = p_Rows(0).Item("COLUMN_TYPE").ToString
                        If InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                            p_Object.Properties.ValueChecked = p_Object.CheckValue
                            p_Object.Properties.ValueUnchecked = p_Object.UnCheckValue
                        End If

                        If p_Object.Visible = True Then
                            p_Value = p_Object.Required
                            If p_Value = "Y" Then
                                p_Object.BackColor = pv_Required_Back_Color
                            Else
                                'p_Object.BackColor = pv_Back_Color
                            End If

                        End If

                        If InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                            If p_Object.Digit = True Then
                                p_LocalCurrency = p_Object.LocalDecimal
                                p_Object.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                'p_NumberDecimal = p_Object.NumberDecimal
                                If p_LocalCurrency = False Then
                                    p_NumberDecimal = p_Object.NumberDecimal
                                    If p_NumberDecimal > 0 Then
                                        p_Object.Properties.DisplayFormat.FormatString = "#,###." & Left(p_NumberFormat, p_NumberDecimal)
                                    Else
                                        p_Object.Properties.DisplayFormat.FormatString = "#,###"
                                    End If
                                Else
                                    If p_LocalDecimal > 0 Then
                                        p_Object.Properties.DisplayFormat.FormatString = "#,###." & Left(p_NumberFormat, p_LocalDecimal)
                                    Else
                                        p_Object.Properties.DisplayFormat.FormatString = "#,###" & Left(p_NumberFormat, 6)
                                    End If
                                End If
                            Else
                                p_Object.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                p_Object.Properties.DisplayFormat.FormatString = "#############"
                            End If
                            'If p_NumberDecimal > 0 Then
                            '    p_Object.Properties.DisplayFormat.FormatString = "#,###." & Left(p_NumberFormat, p_NumberDecimal)
                            'Else
                            '    p_Object.Properties.DisplayFormat.FormatString = "#,###"
                            'End If
                        End If

                    End If
                End If


                'Xu ly cho cac item tabpage
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    Try
                        For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                            p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                            For p_Count = 0 To p_Object_Item.Controls.Count - 1
                                If InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                    Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                    Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                    Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_MemoTextBox, CompareMethod.Text) > 0 _
                                    Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                    Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                                    p_ItemName = p_Object_Item.Controls(p_Count).fieldname
                                    p_View_Name = UCase(p_Object_Item.Controls(p_Count).ViewName)
                                    If InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 Then
                                        If p_Set_Combo_PropertyNew(p_Form, p_Object_Item.Controls(p_Count), p_GetB1) = False Then
                                            Exit Function
                                        End If
                                    End If
                                    p_Rows = p_DBDataSet.Tables(p_TableID).Select("COLUMN_NAME='" & p_ItemName & "' AND TABLE_NAME='" & p_View_Name & "'")
                                    If p_Rows.Count > 0 Then

                                        ''p_Object_Item.Controls(p_Count).DataField = p_Rows(0).Item("COLUMN_NAME").ToString
                                        ''p_Object_Item.Controls(p_Count).DataSource = p_BindingSource
                                        p_Object_Item.Controls(p_Count).DataBindings.Add("EditValue", p_BindingSource, p_ItemName)
                                        p_Object_Item.Controls(p_Count).FieldType = p_Rows(0).Item("COLUMN_TYPE").ToString
                                        If InStr(UCase(p_Object_Item.Controls(p_Count).GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                            p_Object_Item.Controls(p_Count).Properties.ValueChecked = p_Object_Item.Controls(p_Count).CheckValue
                                            p_Object_Item.Controls(p_Count).Properties.ValueUnchecked = p_Object_Item.Controls(p_Count).UnCheckValue
                                        End If



                                        If p_Object_Item.Controls(p_Count).Visible = True Then
                                            p_Value = p_Object_Item.Controls(p_Count).Required
                                            If p_Value = "Y" Then
                                                p_Object_Item.Controls(p_Count).BackColor = pv_Required_Back_Color
                                            Else
                                                'p_Object_Item.Controls(p_Count).BackColor = pv_Back_Color
                                            End If

                                        End If

                                        If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                                            If p_Object_Item.Digit = True Then
                                                p_LocalCurrency = p_Object_Item.LocalDecimal
                                                p_Object_Item.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                                'p_NumberDecimal = p_Object.NumberDecimal
                                                If p_LocalCurrency = False Then
                                                    p_NumberDecimal = p_Object_Item.NumberDecimal
                                                    If p_NumberDecimal > 0 Then
                                                        p_Object_Item.Properties.DisplayFormat.FormatString = "#,###." & Left(p_NumberFormat, p_NumberDecimal)
                                                    Else
                                                        p_Object_Item.Properties.DisplayFormat.FormatString = "#,###"
                                                    End If
                                                Else
                                                    If p_LocalDecimal > 0 Then
                                                        p_Object_Item.Properties.DisplayFormat.FormatString = "#,###." & Left(p_NumberFormat, p_LocalDecimal)
                                                    Else
                                                        p_Object_Item.Properties.DisplayFormat.FormatString = "#,###" & Left(p_NumberFormat, 6)
                                                    End If
                                                End If
                                            Else
                                                p_Object_Item.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                                p_Object_Item.Properties.DisplayFormat.FormatString = "#############"
                                            End If
                                            'If p_NumberDecimal > 0 Then
                                            '    p_Object.Properties.DisplayFormat.FormatString = "#,###." & Left(p_NumberFormat, p_NumberDecimal)
                                            'Else
                                            '    p_Object.Properties.DisplayFormat.FormatString = "#,###"
                                            'End If
                                        End If

                                    End If
                                End If

                            Next
                        Next
                    Catch ex As Exception
                        'MsgBox("p_Object_Item:" & p_Object_Item.name)
                        p_Control_DataFieldHeader = False
                        Exit Function
                    End Try

                End If
            Next
        Catch ex As Exception
            ' MsgBox("p_Object:" & p_Object.name)
            p_Control_DataFieldHeader = False
        End Try

    End Function

    'anhqh
    '14/01/2014
    'Ham thuc hien fill gia tri cho Combobox where theo  1 gia tri
    Public Function p_FilComboboxParent(ByVal p_Form As Object, ByVal p_Combobox As U_TextBox.U_Combobox, Optional ByVal p_GetB1 As Boolean = False) As Boolean

        Dim p_Object As Object
        Dim p_Control_Ind As Integer
        Dim p_SQL As String = ""

        Try
            p_FilComboboxParent = True
            For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                p_Object = p_Form.Controls.Item(p_Control_Ind)
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    p_FilComboboxParent = p_FilComboboxParentPage(p_Form, p_Combobox,
                                            p_Object, p_GetB1)
                Else
                    If InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                        And UCase(p_Combobox.Name) <> UCase(p_Object.Name.ToString.Trim) Then
                        'And InStr(UCase(p_SQL), UCase(":" & p_Combobox.Name), CompareMethod.Text) > 0 Then
                        p_SQL = p_Object.SQL_String
                        If InStr(UCase(p_SQL), UCase(":" & p_Combobox.Name), CompareMethod.Text) > 0 Then
                            If p_Set_Combo_PropertyNew(p_Form, p_Object, p_GetB1) = False Then
                                MsgBox("Lỗi khi chèn Combobox " & p_Object.Name.ToString.Trim)
                                p_FilComboboxParent = False
                            Else
                                ' If p_Object.text.ToString.Trim <> "" Then
                                Try
                                    ' p_Object.ItemIndex = 0
                                    If p_Form.g_FormLoad = False Then
                                        If p_Form.FormLock = False Then
                                            If p_Form.FormEdit = True Then
                                                p_Object.ItemIndex = 0
                                            End If
                                        End If
                                    End If
                                Catch ex As Exception

                                End Try

                                'End If

                            End If
                        End If
                    End If
                End If


            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            p_FilComboboxParent = False
        End Try
    End Function

    'anhqh
    '14/01/2014
    'Ham thuc hien fill gia tri cho Combobox where theo  1 gia tri
    Public Function p_FilComboboxParentPage(ByVal p_Form As Object, ByVal p_Combobox As U_TextBox.U_Combobox, _
                                            ByVal p_TabControl As Object, Optional ByVal p_GetB1 As Boolean = False) As Boolean

        Dim p_Object As Object
        Dim p_Object_Tab As Object
        Dim p_Control_Ind As Integer
        Dim p_Control_TabIndex As Integer

        Dim p_SQL As String = ""
        'fsdfsfd()
        Try
            p_FilComboboxParentPage = True
            ' If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
            If InStr(UCase(p_TabControl.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                For p_Control_TabIndex = p_TabControl.TabPages.Count - 1 To 0 Step -1
                    ' For Each p_Control In p_Object.Controls
                    'p_Object.TabPages(p_TabControl_Ind).Select()
                    p_TabControl.SelectedTabPageIndex = p_Control_TabIndex
                    p_Object_Tab = p_TabControl.TabPages(p_Control_TabIndex) ' p_Control
                    'If InStr(UCase(p_Object_Tab.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    '    p_FilComboboxParentPage = p_FilComboboxParentPage(p_Form, p_Combobox,
                    '                    p_Object_Tab, p_GetB1)
                    'Else
                    'For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                    If InStr(UCase(p_Object_Tab.GetType.ToString), "XtraTabPage", CompareMethod.Text) > 0 Then
                        For Each p_Object In p_Object_Tab.Controls
                            ' p_Object = p_Form.Controls.Item(p_Control_Ind)
                            If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                                p_FilComboboxParentPage = p_FilComboboxParentPage(p_Form, p_Combobox,
                                                p_Object, p_GetB1)
                            Else
                                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                        And UCase(p_Combobox.Name) <> UCase(p_Object.Name.ToString.Trim) Then
                                    'And InStr(UCase(p_SQL), UCase(":" & p_Combobox.Name), CompareMethod.Text) > 0 Then
                                    p_SQL = p_Object.SQL_String
                                    If InStr(UCase(p_SQL), UCase(":" & p_Combobox.Name), CompareMethod.Text) > 0 Then
                                        If p_Set_Combo_PropertyNew(p_Form, p_Object, p_GetB1) = False Then
                                            MsgBox("Lỗi khi chèn Combobox " & p_Object.Name.ToString.Trim)
                                            p_FilComboboxParentPage = False
                                        Else
                                            ' If p_Object.text.ToString.Trim <> "" Then
                                            Try
                                                ' p_Object.ItemIndex = 0
                                            Catch ex As Exception

                                            End Try

                                            'End If

                                        End If
                                    End If
                                End If
                            End If
                        Next
                        ' End If
                    End If
                Next

                'Else
                '    For Each p_Object In p_Object_Tab.Controls
                '        ' p_Object = p_Form.Controls.Item(p_Control_Ind)

                '            If InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                '                    And UCase(p_Combobox.Name) <> UCase(p_Object.Name.ToString.Trim) Then
                '                'And InStr(UCase(p_SQL), UCase(":" & p_Combobox.Name), CompareMethod.Text) > 0 Then
                '                p_SQL = p_Object.SQL_String
                '                If InStr(UCase(p_SQL), UCase(":" & p_Combobox.Name), CompareMethod.Text) > 0 Then
                '                    If p_Set_Combo_PropertyNew(p_Form, p_Object, p_GetB1) = False Then
                '                        MsgBox("Lỗi khi chèn Combobox " & p_Object.Name.ToString.Trim)
                '                        p_FilComboboxParentPage = False
                '                    Else
                '                        ' If p_Object.text.ToString.Trim <> "" Then
                '                        Try
                '                            p_Object.ItemIndex = 0
                '                        Catch ex As Exception

                '                        End Try

                '                        'End If

                '                    End If
                '                End If
                '        End If
                '    Next
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            p_FilComboboxParentPage = False
        End Try
    End Function


    'ANHQH
    '01/01/2012
    'Ham thuc hien lay dulieu setupcho Combobox
    Public Function p_Get_Combobox_Source(ByVal p_Module As String, _
                                           ByRef p_DataSet As DataSet) As Boolean
        Dim p_SQL As String
        'Dim p_Sys As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)

        p_Get_Combobox_Source = True

        p_SQL = "SELECT * FROM COMBOSOURCE WHERE MODULES='" & p_Module & "' "

        p_DataSet = g_Service.mod_SYS_GET_DATASET(p_SQL)
        Try

        Catch ex As Exception
            p_Get_Combobox_Source = False
        End Try
    End Function



    'anhqh
    '10/10/2012
    'Ham thuc hien replace cac string khai bao trong SQL thanh cac gia tri theo cac
    'Item tren form

    Public Function p_Parameter_Item(ByVal p_Form As Form, _
                                      ByVal p_SQL As String) As String
        Dim p_SQL_Tmp As String
        Dim p_Pos As Integer
        Dim p_SQL_Tmp1 As String
        Dim p_Parent_Item As String = ""
        Dim p_Parent_Obj As Object
        Dim p_SValue As String = ""
        Dim p_NValue As Integer = 0

        p_Parameter_Item = ""

        p_SQL_Tmp = p_SQL
        While InStr(p_SQL_Tmp, ":", CompareMethod.Text) > 0


            p_Pos = InStr(p_SQL_Tmp, ":", CompareMethod.Text)
            If p_Pos > 0 Then

                If InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) = 0 Then
                    p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos)
                Else
                    If InStr(1, Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) - p_Pos), "=", CompareMethod.Text) > 0 Then
                        p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, "=", CompareMethod.Text) - p_Pos)
                    Else
                        p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) - p_Pos)
                    End If

                End If
                ' End If

                p_SQL_Tmp1 = Replace(p_SQL_Tmp1, ")", "", 1)
                p_SQL_Tmp1 = Replace(p_SQL_Tmp1, "(", "", 1)
                If p_SQL_Tmp1.Length > 0 Then
                    If UCase(p_SQL_Tmp1) = UCase(":GLOBAL.COMCODE") Or UCase(p_SQL_Tmp1) = UCase(":GLOBAL.USERNAME") Then
                        p_Parent_Item = p_SQL_Tmp1
                    Else
                        If InStr(p_SQL_Tmp1, ",", CompareMethod.Text) > 0 Then
                            p_Parent_Item = Mid(p_SQL_Tmp1, 2, InStr(p_SQL_Tmp1, ",", CompareMethod.Text) - 2)
                        Else
                            p_Parent_Item = Mid(p_SQL_Tmp1, 2)
                        End If
                    End If



                End If
                If UCase(p_Parent_Item) = UCase(":GLOBAL.COMCODE") Then
                    p_SValue = g_CompanyCode
                    p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                ElseIf UCase(p_Parent_Item) = UCase(":GLOBAL.USERNAME") Then
                    p_SValue = g_UserName
                    p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                Else
                    p_Parent_Obj = p_Form.Controls.Find(p_Parent_Item, True)
                    If Not p_Parent_Obj Is Nothing Then
                        If p_Parent_Obj.length > 0 Then
                            'End If
                            If Not p_Parent_Obj(0).editvalue Is Nothing Then
                                'If p_Parent_Obj(0).editvalue.ToString.Trim <> "" Then
                                Select Case p_Parent_Obj(0).FieldType
                                    Case "C"
                                        p_SValue = p_Parent_Obj(0).editvalue.ToString.Trim
                                        p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                                    Case "N"
                                        If p_Parent_Obj(0).text = "" Then
                                            p_NValue = 0
                                        Else
                                            p_NValue = p_Parent_Obj(0).editvalue.ToString.Trim
                                        End If
                                        ' p_NValue = p_Parent_Obj(0).text
                                        p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, p_NValue, 1)
                                    Case "D"
                                        If p_Parent_Obj(0).ShowDateTime = True Then
                                            p_SValue = p_Parent_Obj(0).editvalue.ToString.Trim
                                            p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)

                                        Else
                                            p_SValue = CDate(p_Parent_Obj(0).editvalue).ToString("yyyyMMdd")
                                            p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                                        End If
                                        'p_SValue = p_Parent_Obj(0).editvalue.ToString.Trim
                                        'p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                                    Case Else
                                        Exit Function

                                End Select

                                ' End If

                            Else
                                p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                            End If
                        End If
                    End If
                End If



            End If
            p_SQL_Tmp = p_SQL
        End While
        p_Parameter_Item = p_SQL
    End Function

    'anhqh
    '01/11/2012
    'Ham thu hien lay du lieu cua ItemCombobox khi gotFocus corang buoc item cha


    Public Function p_Focus_Set_Combo_Property(ByVal p_Form As Form, _
                                    ByRef p_Item As U_TextBox.U_Combobox, _
                                    Optional ByVal b1_Get As Boolean = False) As Boolean
        Dim p_DisplayName As String
        Dim p_ValueName As String
        Dim p_SQL As String
        Dim p_DataTable As New DataTable
        Dim p_Item_Name As String
        Dim p_Parent_Item As String = ""
        'Dim p_Pos As Integer
        'Dim p_SQL_Tmp As String
        'Dim p_SQL_Tmp1 As String

        'Dim p_SValue As String = ""
        'Dim p_NValue As Integer = 0
        'Dim p_Parent_Obj As Object
        ' U_TextBox.U_Combobox
        Try


            p_Item_Name = p_Item.Name
            p_DisplayName = p_Item.DisplayField
            p_ValueName = p_Item.ValueField

            p_SQL = p_Item.SQL_String
            p_Focus_Set_Combo_Property = True

            If p_SQL.ToString <> "" Then

                p_SQL = p_Parameter_Item(p_Form, p_SQL)
                If Mod_Get_Gird_ComboNew(p_SQL, p_Item, p_DisplayName, p_ValueName, b1_Get) = False Then
                    p_Focus_Set_Combo_Property = False
                    Exit Function
                End If
            End If

        Catch ex As Exception
            p_Focus_Set_Combo_Property = False
        End Try
    End Function



    Public Function p_Set_Form_Combo_Property(ByVal p_Form As Form, Optional ByVal b1_Get As Boolean = False) As Boolean
        Dim p_Form_Name As String
        Dim p_Object As Object
        For p_Control_Ind = 0 To p_Form.Controls.Count - 1
            p_Object = p_Form.Controls.Item(p_Control_Ind)
            If InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 Then
                p_Form_Name = p_Form.Name
                If p_Set_Combo_PropertyNew(p_Form, p_Object, b1_Get) = False Then

                End If
            End If
        Next
    End Function

    Public Function p_Set_Panel_Condition(ByVal p_Object As DevExpress.XtraEditors.PanelControl, ByRef p_WhereReturn As String, Optional ByVal p_FieldName As Boolean = False) As Boolean
        Dim p_Object_Tab_Item As Object
        p_Set_Panel_Condition = True
        Dim p_ItemName As String
        Dim p_FieldType As String
        Dim p_Value As String
        ' If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
        Try
            For p_Count = 0 To p_Object.Controls.Count - 1
                p_Object_Tab_Item = p_Object.Controls(p_Count)
                If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                    Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                 Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                    If Not p_Object_Tab_Item.EditValue Is Nothing Then
                        If p_Object_Tab_Item.EditValue.ToString <> "" Then
                            'INSERT
                            If p_FieldName = True Then
                                p_ItemName = UCase(p_Object_Tab_Item.FieldName)
                            Else
                                p_ItemName = UCase(p_Object_Tab_Item.Name)
                            End If
                            If p_ItemName <> "" Then
                                p_FieldType = UCase(p_Object_Tab_Item.FieldType)
                                If p_Object_Tab_Item.EditValue Is Nothing Then
                                    p_Value = ""
                                Else
                                    p_Value = p_Object_Tab_Item.EditValue.ToString
                                End If
                                If p_FieldType = "D" Then  'Ngay thang

                                    If p_WhereReturn = "" Then
                                        p_WhereReturn = " " & p_ItemName & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                    Else
                                        p_WhereReturn = p_WhereReturn & " AND " & p_ItemName & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                    End If

                                End If
                                If p_FieldType = "C" Then 'Text

                                    If p_WhereReturn = "" Then
                                        p_WhereReturn = " " & p_ItemName & " = N'" & Trim(p_Value) & "'"
                                    Else
                                        p_WhereReturn = p_WhereReturn & " AND " & p_ItemName & " = N'" & Trim(p_Value) & "'"
                                    End If

                                End If
                                If p_FieldType = "N" Then 'Number

                                    If p_WhereReturn = "" Then
                                        p_WhereReturn = " " & p_ItemName & " = " & p_Value
                                    Else
                                        p_WhereReturn = p_WhereReturn & " AND " & p_ItemName & " = " & p_Value
                                    End If
                                End If
                            End If
                        End If
                    End If

                End If
            Next

        Catch ex As Exception
            p_Set_Panel_Condition = False
            Exit Function
        End Try
        ' End If
    End Function
    Public Function p_Set_Form_Condition(ByVal p_Form As Form, ByRef p_WhereReturn As String, _
                                         Optional ByVal p_FieldName As Boolean = False, _
                                         Optional ByVal p_ParentName As String = "") As Boolean
        Dim p_Object As Object
        Dim p_Parent_Item As String = ""
        Dim p_ItemName As String
        Dim p_FieldType As String
        Dim p_Value As String
        p_WhereReturn = ""

        p_Set_Form_Condition = True
        Try
            For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                p_Object = p_Form.Controls.Item(p_Control_Ind)

                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoTextBox, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 Then
                    If p_ParentName.Trim <> "" And UCase(p_Object.Parent.Name) <> UCase(p_ParentName) Then
                        Continue For
                    End If
                    If Not p_Object.EditValue Is Nothing Then
                        If p_Object.EditValue.ToString <> "" Then
                            'INSERT
                            If p_FieldName = True Then
                                p_ItemName = UCase(p_Object.FieldName)
                            Else
                                p_ItemName = UCase(p_Object.Name)
                            End If
                            If p_ItemName <> "" Then
                                p_FieldType = UCase(p_Object.FieldType)
                                If p_Object.EditValue Is Nothing Then
                                    p_Value = ""
                                Else
                                    p_Value = p_Object.EditValue.ToString
                                End If
                                If p_Value <> "" Then
                                    If p_FieldType = "D" Then  'Ngay thang

                                        If p_WhereReturn = "" Then
                                            p_WhereReturn = " " & p_ItemName & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                        Else
                                            p_WhereReturn = p_WhereReturn & " AND " & p_ItemName & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                        End If
                                        '   p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                        'p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")

                                    End If
                                    If p_FieldType = "C" Then 'Text
                                        'p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                        'p_Field_Value = p_Field_Value & ",N'" & p_Value & "'"

                                        If p_WhereReturn = "" Then
                                            p_WhereReturn = " " & p_ItemName & " = N'" & Trim(p_Value) & "'"
                                        Else
                                            p_WhereReturn = p_WhereReturn & " AND " & p_ItemName & " = N'" & Trim(p_Value) & "'"
                                        End If

                                    End If
                                    If p_FieldType = "N" Then 'Number
                                        'p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                        'p_Field_Value = p_Field_Value & "," & p_Value & ""
                                        If p_WhereReturn = "" Then
                                            p_WhereReturn = " " & p_ItemName & " = " & p_Value
                                        Else
                                            p_WhereReturn = p_WhereReturn & " AND " & p_ItemName & " = " & p_Value
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            p_Set_Form_Condition = False
        End Try
    End Function

    'anhqh
    '01/11/2012
    'Ham thu hien lay du lieu cua ItemCombobox 
    Public Function p_Set_Combo_PropertyNew(ByVal p_Form As Form, _
                                     ByRef p_Item As U_TextBox.U_Combobox, _
                                     Optional ByVal b1_Get As Boolean = False) As Boolean
        Dim p_DisplayName As String
        Dim p_Form_Name As String
        Dim p_ValueName As String
        Dim p_SQL As String
        Dim p_DataTable As New DataTable
        Dim p_Item_Name As String
        Dim p_ShowHead As Boolean
        '  Dim p_DropDownRow As Integer
        Try

            p_Form_Name = p_Form.Name

            p_Item_Name = p_Item.Name
            p_DisplayName = p_Item.DisplayField
            p_ValueName = p_Item.ValueField
            'p_Form_Name = Replace(p_Form_Name, "[", "", 1)
            ' p_Form_Name = Replace(p_Form_Name, "]", "", 1)
            p_SQL = p_Item.SQL_String
            p_Set_Combo_PropertyNew = True
            p_Item.Properties.ShowHeader = False
            'p_Item.Properties.DropDownRows
            If p_Item.DropDownRow.ToString.Trim <> "" Then
                p_Item.Properties.DropDownRows = p_Item.DropDownRow
            End If
            If p_SQL.ToString <> "" Then
                If InStr(p_SQL, ":", CompareMethod.Text) > 0 Then
                    p_SQL = p_Parameter_Item(p_Form, p_SQL)
                End If
                If Mod_Get_Gird_ComboNew(p_SQL, p_Item, p_DisplayName, p_ValueName, b1_Get) = False Then
                    p_Set_Combo_PropertyNew = False
                    Exit Function
                End If
                Exit Function
            Else
                ' Dim p_SysBatch As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
                p_SQL = "SELECT SQL_COM,DISPLAYMEMBER,VALUEMEMBER ,ITEM_REF,SWHERE,SORDERBY " & _
                        "FROM(COMBOSOURCE) where FORM_NAME='" & p_Form_Name & "'  and COMBO_NAME='" & p_Item_Name & "' and ITEM_REF is null "
                If b1_Get = False Then
                    p_DataTable = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
                Else
                    p_DataTable = g_Service.mod_SYS_GET_DATATABLE_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQL)
                End If
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        'p_Item_Name = p_DataTable.Rows(0).Item("").ToString
                        p_SQL = p_DataTable.Rows(0).Item("SQL_COM").ToString

                        If InStr(p_SQL, ":", CompareMethod.Text) > 0 Then
                            p_SQL = p_Parameter_Item(p_Form, p_SQL)
                        End If
                        ' p_DisplayName = p_DataTable.Rows(0).Item("DISPLAYMEMBER").ToString
                        ' p_ValueName = p_DataTable.Rows(0).Item("VALUEMEMBER").ToString

                        If Mod_Get_Gird_ComboNew(p_SQL, p_Item, p_DisplayName, p_ValueName, b1_Get) = False Then
                            p_Set_Combo_PropertyNew = False
                            Exit Function
                        End If
                    End If
                End If
                'p_SysBatch = Nothing
            End If
            p_ShowHead = p_Item.ShowHeader
            If p_ShowHead = False Then
                p_Item.Properties.ShowHeader = False
            End If

        Catch ex As Exception
            MsgBox("Set_Combo_PropertyNe (" & p_Item.Name & "):" & ex.Message)
            p_Set_Combo_PropertyNew = False
        End Try
    End Function




    'anhqh
    '01/11/2012
    'Ham thu hien lay du lieu cua ItemCombobox 
    Private Function p_Set_Combo_Property(ByVal p_Form_Name As String, _
                                     ByRef p_Item As U_TextBox.U_Combobox, _
                                     Optional ByVal b1_Get As Boolean = False) As Boolean
        Dim p_DisplayName As String
        Dim p_ValueName As String
        Dim p_SQL As String
        Dim p_DataTable As New DataTable
        Dim p_Item_Name As String
        Try


            p_Item_Name = p_Item.Name
            p_DisplayName = p_Item.DisplayField
            p_ValueName = p_Item.ValueField
            'p_Form_Name = Replace(p_Form_Name, "[", "", 1)
            ' p_Form_Name = Replace(p_Form_Name, "]", "", 1)
            p_SQL = p_Item.SQL_String
            p_Set_Combo_Property = True
            If p_SQL.ToString <> "" Then
                If InStr(p_SQL, ":", CompareMethod.Text) > 0 Then
                    'p_Parameter_Item
                End If
                If Mod_Get_Gird_ComboNew(p_SQL, p_Item, p_DisplayName, p_ValueName, b1_Get) = False Then
                    p_Set_Combo_Property = False
                    Exit Function
                End If
                Exit Function
            Else
                ' Dim p_SysBatch As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
                p_SQL = "SELECT SQL_COM,DISPLAYMEMBER,VALUEMEMBER ,ITEM_REF,SWHERE,SORDERBY " & _
                        "FROM(COMBOSOURCE) where FORM_NAME='" & p_Form_Name & "'  and COMBO_NAME='" & p_Item_Name & "' and ITEM_REF is null "
                If b1_Get = False Then
                    p_DataTable = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
                Else
                    p_DataTable = g_Service.mod_SYS_GET_DATATABLE_Com(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_SQL)
                End If
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        'p_Item_Name = p_DataTable.Rows(0).Item("").ToString
                        p_DisplayName = p_DataTable.Rows(0).Item("DISPLAYMEMBER").ToString
                        p_ValueName = p_DataTable.Rows(0).Item("VALUEMEMBER").ToString
                        p_SQL = p_DataTable.Rows(0).Item("SQL_COM").ToString
                        If Mod_Get_Gird_Combo(p_SQL, p_Item, p_DisplayName, p_ValueName, b1_Get) = False Then
                            p_Set_Combo_Property = False
                            Exit Function
                        End If
                    End If
                End If
                'p_SysBatch = Nothing
            End If

        Catch ex As Exception
            p_Set_Combo_Property = False
        End Try
    End Function

    Public Function p_Set_Combo_Source(ByRef p_Form As System.Windows.Forms.Form, _
                                        ByVal p_Rows() As DataRow, _
                                        ByRef p_BindingSource() As BindingSource) As Boolean
        Dim p_Count As Integer
        Dim p_SQL As String = ""
        Dim p_Object_Com As Object
        Dim p_Item_Name As String = ""
        Dim p_DisplayMember As String = ""
        Dim p_ValueMember As String = ""
        Dim p_Where As String = ""
        Dim p_Orderby As String = ""
        p_Set_Combo_Source = True

        For p_Count = 0 To p_Rows.Count - 1
            p_Item_Name = p_Rows(p_Count).Item("COMBO_NAME").ToString
            p_Object_Com = p_Form.Controls.Find(p_Item_Name, True)
            'p_DisplayMember = p_Rows(p_Count).Item("DISPLAYMEMBER").ToString
            'p_ValueMember = p_Rows(p_Count).Item("VALUEMEMBER").ToString

            ' p_Where = p_Rows(p_Count).Item("SWHERE").ToString
            'p_Orderby = p_Rows(p_Count).Item("SORDERBY").ToString
            If p_Object_Com.length > 0 Then

                p_SQL = UCase(p_Rows(p_Count).Item("SQL_COM").ToString)
                If p_Where.ToString <> "" Then
                    p_Where = " WHERE " & p_Where
                End If
                If p_Orderby.ToString <> "" Then
                    p_Where = " ORDER BY " & p_Orderby
                End If
                If p_SQL <> "" Then
                    p_SQL = p_SQL & p_Where
                    If Mod_Get_Gird_Combo(p_SQL, p_BindingSource(p_Count), p_Object_Com(0), p_DisplayMember, p_ValueMember, True) = False Then
                        p_Set_Combo_Source = False
                        Exit Function
                    End If
                End If
            End If
        Next
        Try

        Catch ex As Exception
            p_Set_Combo_Source = False
        End Try

    End Function

    Private Function p_Convert_Date(ByVal p_Str_Date As String) As String
        'If p_Connect_Type = "SQL" Then
        '    p_Convert_Date = Format(Convert.ToDateTime(p_Str_Date))
        'Else
        If p_Str_Date = "" Then Return ""
        p_Convert_Date = Format(Convert.ToDateTime(p_Str_Date), g_Format_Date)
        'End If
    End Function

    'ANHQH
    '01/01/2012
    'Ham thuc hien Cap nhat len Database
    Public Function p_DataToDatabase(ByRef p_Form As Form, _
                                     ByVal p_Table_Name As String, _
                                    ByVal p_Insert_Type As Boolean, _
                                    Optional ByVal B1Get As Boolean = False) As Boolean

        Dim p_Object As Object
        Dim p_Object_Item As Object
        Dim p_Object_Tab_Item As Object

        Dim p_ItemName As String
        Dim p_Count As Integer
        Dim p_TabControl_Ind As Integer
        Dim p_Control_Ind As Integer
        Dim p_CountObj As Integer
        Dim p_Field_Ins As String = ""
        Dim p_Field_Value As String = ""
        Dim p_Where As String = ""
        Dim p_SQL_Upd As String = ""
        Dim p_NoUpdate As String = ""
        Dim p_KeyInsert As String
        Dim p_Err As String
        Dim p_DataUpd As New DataSet
        Dim p_Table As New DataTable("Table01")
        Dim p_Col As New DataColumn
        Dim p_Row As DataRow
        'Dim p_System As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        Dim p_FieldType As String
        Dim p_Value As String

        p_Col.ColumnName = "SQL_STR"
        p_Col.MaxLength = 4000
        p_Table.Columns.Add(p_Col)

        p_DataToDatabase = True
        p_CountObj = 0
        Dim p_Des As String = ""
        Try
            If p_Check_Control_Required(p_Form, p_Des) = False Then
                p_DataToDatabase = False
                MsgBox(p_Des)
                Exit Function
            End If

            For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                p_Object = p_Form.Controls.Item(p_Control_Ind)
                'If p_Object.Name = "Code" Then
                '    MsgBox("dfggdg")
                'End If
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                    Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then

                    If UCase(p_Object.TableName) = UCase(p_Table_Name) And Not p_Object.EditValue Is Nothing Then
                        If p_Insert_Type = True Then

                            If p_Object.EditValue.ToString <> "" Then
                                'INSERT
                                p_ItemName = UCase(p_Object.FieldName)
                                p_FieldType = UCase(p_Object.FieldType)
                                p_KeyInsert = UCase(p_Object.KeyInsert)
                                If p_Object.EditValue Is Nothing Then
                                    p_Value = ""
                                Else
                                    p_Value = p_Object.EditValue.ToString
                                End If
                                If InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                    If p_Value.Trim <> p_Object.CheckValue.ToString.Trim Then
                                        p_Value = p_Object.UnCheckValue.ToString.Trim
                                    End If
                                End If
                                'If p_Check_Item(p_ItemName, p_KeyInsert) = True Then
                                If p_KeyInsert = "Y" Or p_Object.PrimaryKey = "N" Or p_Object.PrimaryKey = "" Then
                                    'If p_Check_Item(p_ItemName, p_Object.NoUpdate) = True Then
                                    If p_FieldType = "D" Then  'Ngay thang

                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                        p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")

                                    End If

                                    If p_FieldType = "C" And p_KeyInsert <> "N" Then 'Text
                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                        p_Field_Value = p_Field_Value & ",N'" & p_Value & "'"
                                    End If
                                    If p_FieldType = "N" And p_KeyInsert <> "N" Then 'Number
                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                        p_Field_Value = p_Field_Value & "," & p_Value & ""
                                    End If
                                End If
                            End If
                        Else
                            'UPDATE
                            p_ItemName = UCase(p_Object.FieldName)
                            p_FieldType = UCase(p_Object.FieldType)
                            'If p_ItemName = "USER_ID" Then
                            '    MsgBox("GG")
                            'End If
                            If p_Object.EditValue Is Nothing Then
                                p_Value = ""
                            Else
                                p_Value = p_Object.EditValue.ToString
                            End If
                            p_NoUpdate = p_Object.NoUpdate
                            If p_Check_Item(p_ItemName, p_NoUpdate) = True Then
                                If p_FieldType = "D" Then  'Ngay thang

                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Convert_Date(p_Value) = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                End If

                                If p_FieldType = "C" Then 'Text
                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=N'" & p_Value & "'"
                                End If
                                If p_FieldType = "N" Then 'Number
                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                End If
                            Else
                                If p_Object.PrimaryKey = "Y" And p_FieldType = "C" Then
                                    If p_Where = "" Then
                                        p_Where = " " & p_ItemName & "=N'" & p_Value & "'"
                                    Else
                                        p_Where = p_Where & " AND " & p_ItemName & "=N'" & p_Value & "'"
                                    End If
                                ElseIf p_Object.PrimaryKey = "Y" And p_FieldType = "N" Then
                                    If p_Where = "" Then
                                        p_Where = " " & p_ItemName & "=" & p_Value
                                    Else
                                        p_Where = p_Where & " AND " & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
                'Xu ly cho cac item tabpage
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    Try
                        For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                            p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                            For p_Count = 0 To p_Object_Item.Controls.Count - 1
                                p_Object_Tab_Item = p_Object_Item.Controls(p_Count)
                                If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                    Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                                 Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                                    If UCase(p_Object_Tab_Item.TableName.ToString) = UCase(p_Table_Name) And Not p_Object_Tab_Item.EditValue Is Nothing Then
                                        p_FieldType = UCase(p_Object_Tab_Item.FieldType)

                                        If p_Insert_Type = True Then
                                            'INSERT
                                            If p_Object_Tab_Item.EditValue Is Nothing Then
                                                If p_Object_Tab_Item.Value.ToString <> "" Then
                                                    p_ItemName = UCase(p_Object_Tab_Item.FieldName)
                                                    'If p_Object_Tab_Item.EditValue Is Nothing Then
                                                    '    p_Value = ""
                                                    'Else
                                                    p_Value = p_Object_Tab_Item.EditValue.ToString
                                                    'End If
                                                    If p_Check_Item(p_ItemName, p_Object_Tab_Item.NoUpdate) = True Then
                                                        If p_FieldType = "D" Then
                                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                            p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                                        End If
                                                        If p_FieldType = "C" Then
                                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                            p_Field_Value = p_Field_Value & ",N'" & p_Value & "'"
                                                        End If
                                                        If p_FieldType = "N" Then 'Number
                                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                            p_Field_Value = p_Field_Value & "," & p_Value & ""
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Else
                                            'UPDATE
                                            p_ItemName = UCase(p_Object_Tab_Item.FieldName)
                                            'If p_ItemName = UCase("CntctPrsn") Then
                                            '    MsgBox("dd")
                                            'End If
                                            p_FieldType = UCase(p_Object_Tab_Item.FieldType)
                                            If p_Object_Tab_Item.EditValue Is Nothing Then
                                                p_Value = ""
                                            Else
                                                p_Value = p_Object_Tab_Item.EditValue.ToString
                                            End If
                                            If p_Check_Item(p_ItemName, p_Object_Tab_Item.NoUpdate) = True Then
                                                If p_FieldType = "D" Then  'Ngay thang
                                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                                End If
                                                If p_FieldType = "C" Then
                                                    If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Object_Tab_Item.Checked = True, "'" & p_Object_Tab_Item.CheckValue & "'", "'" & p_Object_Tab_Item.CheckValue & "'")
                                                    Else
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=N'" & p_Value & "'"
                                                    End If

                                                End If
                                                If p_FieldType = "N" Then
                                                    If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Object_Tab_Item.Checked = True, p_Object_Tab_Item.CheckValue, p_Object_Tab_Item.UnCheckValue)
                                                    Else
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                                    End If
                                                End If
                                            Else
                                                If p_Object_Tab_Item.PrimaryKey = "Y" And p_FieldType = "C" Then
                                                    If p_Where = "" Then
                                                        p_Where = " " & p_ItemName & "=N'" & p_Value & "'"
                                                    Else
                                                        p_Where = p_Where & " AND " & p_ItemName & "=N'" & p_Value & "'"
                                                    End If
                                                ElseIf p_Object_Tab_Item.PrimaryKey = "Y" And p_FieldType = "N" Then
                                                    If p_Where = "" Then
                                                        p_Where = " " & p_ItemName & "=" & p_Value
                                                    Else
                                                        p_Where = p_Where & " AND " & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                Else
                                    '===========
                                    'If p_Object_Tab_Item.PrimaryKey = "Y" And p_FieldType = "C" Then
                                    '    If p_Where = "" Then
                                    '        p_Where = " " & p_ItemName & "=N'" & p_Value & "'"
                                    '    Else
                                    '        p_Where = p_Where & " AND " & p_ItemName & "=N'" & p_Value & "'"
                                    '    End If
                                    'End If
                                    'If p_Object_Tab_Item.PrimaryKey = "Y" And p_FieldType = "N" Then
                                    '    If p_Where = "" Then
                                    '        p_Where = " " & p_ItemName & "=" & p_Value
                                    '    Else
                                    '        p_Where = p_Where & " AND " & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                    '    End If
                                    'End If
                                End If
                            Next

                        Next
                    Catch ex As Exception
                        '  MsgBox("Err:" & p_Control_Ind)
                        MsgBox(ex.Message)
                        p_DataToDatabase = False
                        Exit Function
                    End Try
                End If
                'End If
            Next
            If p_Insert_Type = True Then
                If p_Field_Ins <> "" Then
                    p_Field_Ins = Mid(Trim(p_Field_Ins), 2)
                    p_Field_Value = Mid(Trim(p_Field_Value), 2)
                    p_SQL_Upd = "INSERT INTO " & p_Table_Name & "(" & p_Field_Ins & ")  VALUES (" & p_Field_Value & ")"
                    If p_SQL_Upd <> "" Then
                        p_Row = p_Table.Rows.Add
                        p_Row(0) = p_SQL_Upd
                        p_DataUpd.Tables.Add(p_Table)
                        If B1Get = True Then
                            p_DataToDatabase = g_Service.SysExecuteDataSet_Company(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_DataUpd)
                        Else
                            p_DataToDatabase = g_Service.SysExecuteDataSet(p_DataUpd, p_Err)
                        End If
                    End If
                End If
            Else
                If p_SQL_Upd <> "" Then
                    p_SQL_Upd = Mid(Trim(p_SQL_Upd), 2)
                    p_SQL_Upd = "UPDATE " & p_Table_Name & " SET " & p_SQL_Upd
                    If p_Where <> "" Then
                        p_SQL_Upd = p_SQL_Upd & " WHERE " & p_Where
                    Else
                        p_Err = "Không xác định điều kiện where khi cập nhật"
                        p_DataToDatabase = False
                        GoTo line_KT
                    End If
                    p_Row = p_Table.Rows.Add
                    p_Row(0) = p_SQL_Upd
                    p_DataUpd.Tables.Add(p_Table)
                    If B1Get = True Then
                        p_DataToDatabase = g_Service.SysExecuteDataSet_Company(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_DataUpd)
                    Else
                        p_DataToDatabase = g_Service.SysExecuteDataSet(p_DataUpd, p_Err)
                    End If
                End If
            End If
line_KT:
            If p_DataToDatabase = False Then
                MsgBox(p_Err)
            End If
            ' p_System = Nothing
        Catch ex As Exception

            p_DataToDatabase = False
            MsgBox(ex.Message)
        End Try

    End Function


    'ANHQH
    '01/01/2012
    'Ham thuc hien tao cau lenh SQL roi tra ve 1 DataTable
    Public Function p_ControlToDataTable(ByRef p_Form As Form, _
                                     ByVal p_Table_Name As String, _
                                    ByVal p_Insert_Type As Boolean, _
                                    ByRef p_Table_Execute As DataTable, _
                                    Optional ByVal B1Get As Boolean = False) As Boolean

        Dim p_Object As Object
        Dim p_Object_Item As Object
        Dim p_Object_Tab_Item As Object

        Dim p_ItemName As String
        Dim p_Count As Integer
        Dim p_TabControl_Ind As Integer
        Dim p_Control_Ind As Integer
        Dim p_CountObj As Integer
        Dim p_Field_Ins As String = ""
        Dim p_Field_Value As String = ""
        Dim p_Where As String = ""
        Dim p_SQL_Upd As String = ""
        Dim p_NoUpdate As String = ""
        Dim p_KeyInsert As String

        Dim p_DataUpd As New DataSet
        Dim p_Table As New DataTable("Table01")
        Dim p_Col As DataColumn
        Dim p_Row As DataRow
        ' Dim p_System As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        Dim p_FieldType As String
        Dim p_Value As String

        If p_Table_Execute.Columns.Count <= 0 Then
            'p_ControlToDataTable = False
            'Exit Function
            p_Col = New DataColumn
            p_Col.ColumnName = "SQL_STR"
            p_Col.MaxLength = 4000
            p_Table_Execute.Columns.Add(p_Col)
        End If

        p_Col = New DataColumn
        p_Col.ColumnName = "SQL_STR"
        p_Col.MaxLength = 4000
        p_Table.Columns.Add(p_Col)

        p_ControlToDataTable = True
        p_CountObj = 0
        Try
            For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                p_Object = p_Form.Controls.Item(p_Control_Ind)

                If InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                    Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then

                    If UCase(p_Object.TableName.ToString) = UCase(p_Table_Name) Then
                        If p_Insert_Type = True Then
                            If p_Object.EditValue.ToString <> "" Then
                                'INSERT
                                p_ItemName = UCase(p_Object.FieldName)
                                p_FieldType = UCase(p_Object.FieldType)
                                p_KeyInsert = UCase(p_Object.KeyInsert)
                                If p_Object.EditValue Is Nothing Then
                                    p_Value = ""
                                Else
                                    p_Value = p_Object.EditValue.ToString
                                End If
                                If p_Check_Item(p_ItemName, p_Object.NoUpdate) = True Then
                                    If p_FieldType = "D" Then  'Ngay thang

                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                        p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")

                                    End If

                                    If p_FieldType = "C" And p_KeyInsert <> "N" Then 'Text
                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                        p_Field_Value = p_Field_Value & ",N'" & p_Value & "'"
                                    End If
                                    If p_FieldType = "N" And p_KeyInsert <> "N" Then 'Number
                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                        p_Field_Value = p_Field_Value & "," & p_Value & ""
                                    End If
                                End If
                            End If
                        Else
                            'UPDATE
                            p_ItemName = UCase(p_Object.FieldName)
                            p_FieldType = UCase(p_Object.FieldType)
                            'If p_ItemName = "USER_ID" Then
                            '    MsgBox("GG")
                            'End If
                            If p_Object.EditValue Is Nothing Then
                                p_Value = ""
                            Else
                                p_Value = p_Object.EditValue.ToString
                            End If
                            p_NoUpdate = p_Object.NoUpdate
                            If p_Check_Item(p_ItemName, p_NoUpdate) = True Then
                                If p_FieldType = "D" Then  'Ngay thang

                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Convert_Date(p_Value) = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                End If

                                If p_FieldType = "C" Then 'Text
                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=N'" & p_Value & "'"
                                End If
                                If p_FieldType = "N" Then 'Number
                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                End If
                            Else
                                If p_Object.PrimaryKey = "Y" And p_FieldType = "C" Then
                                    If p_Where = "" Then
                                        p_Where = " " & p_ItemName & "=N'" & p_Value & "'"
                                    Else
                                        p_Where = p_Where & " AND " & p_ItemName & "=N'" & p_Value & "'"
                                    End If
                                ElseIf p_Object.PrimaryKey = "Y" And p_FieldType = "N" Then
                                    If p_Where = "" Then
                                        p_Where = " " & p_ItemName & "=" & p_Value
                                    Else
                                        p_Where = p_Where & " AND " & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
                'Xu ly cho cac item tabpage
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    Try
                        For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                            p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                            For p_Count = 0 To p_Object_Item.Controls.Count - 1
                                p_Object_Tab_Item = p_Object_Item.Controls(p_Count)
                                If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                    Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                                 Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                                    If UCase(p_Object_Tab_Item.TableName.ToString) = UCase(p_Table_Name) Then
                                        p_FieldType = UCase(p_Object_Tab_Item.FieldType)
                                        If p_Insert_Type = True Then
                                            'INSERT
                                            If p_Object_Tab_Item.Value.ToString <> "" Then
                                                p_ItemName = UCase(p_Object_Tab_Item.FieldName)
                                                If p_Object_Tab_Item.EditValue Is Nothing Then
                                                    p_Value = ""
                                                Else
                                                    p_Value = p_Object_Tab_Item.EditValue.ToString
                                                End If
                                                If p_Check_Item(p_ItemName, p_Object_Tab_Item.NoUpdate) = True Then
                                                    If p_FieldType = "D" Then
                                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                        p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                                    End If
                                                    If p_FieldType = "C" Then
                                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                        p_Field_Value = p_Field_Value & ",N'" & p_Value & "'"
                                                    End If
                                                    If p_FieldType = "N" Then 'Number
                                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                        p_Field_Value = p_Field_Value & "," & p_Value & ""
                                                    End If
                                                End If
                                            End If
                                        Else
                                            'UPDATE
                                            p_ItemName = UCase(p_Object_Tab_Item.FieldName)
                                            'If p_ItemName = UCase("CntctPrsn") Then
                                            '    MsgBox("dd")
                                            'End If
                                            p_FieldType = UCase(p_Object_Tab_Item.FieldType)
                                            If p_Object_Tab_Item.EditValue Is Nothing Then
                                                p_Value = ""
                                            Else
                                                p_Value = p_Object_Tab_Item.EditValue.ToString
                                            End If
                                            If p_Check_Item(p_ItemName, p_Object_Tab_Item.NoUpdate) = True Then
                                                If p_FieldType = "D" Then  'Ngay thang
                                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                                End If
                                                If p_FieldType = "C" Then
                                                    If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Object_Tab_Item.Checked = True, "'" & p_Object_Tab_Item.CheckValue & "'", "'" & p_Object_Tab_Item.CheckValue & "'")
                                                    Else
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=N'" & p_Value & "'"
                                                    End If

                                                End If
                                                If p_FieldType = "N" Then
                                                    If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Object_Tab_Item.Checked = True, p_Object_Tab_Item.CheckValue, p_Object_Tab_Item.UnCheckValue)
                                                    Else
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                                    End If
                                                End If
                                            Else
                                                If p_Object_Tab_Item.PrimaryKey = "Y" And p_FieldType = "C" Then
                                                    If p_Where = "" Then
                                                        p_Where = " " & p_ItemName & "=N'" & p_Value & "'"
                                                    Else
                                                        p_Where = p_Where & " AND " & p_ItemName & "=N'" & p_Value & "'"
                                                    End If
                                                ElseIf p_Object_Tab_Item.PrimaryKey = "Y" And p_FieldType = "N" Then
                                                    If p_Where = "" Then
                                                        p_Where = " " & p_ItemName & "=" & p_Value
                                                    Else
                                                        p_Where = p_Where & " AND " & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                Else

                                End If
                            Next

                        Next
                    Catch ex As Exception
                        '  MsgBox("Err:" & p_Control_Ind)
                        p_ControlToDataTable = False
                        Exit Function
                    End Try
                End If
                'End If
            Next
            If p_Insert_Type = True Then
                If p_Field_Ins <> "" Then
                    p_Field_Ins = Mid(Trim(p_Field_Ins), 2)
                    p_Field_Value = Mid(Trim(p_Field_Value), 2)
                    p_SQL_Upd = "INSERT INTO " & p_Table_Name & "(" & p_Field_Ins & ")  VALUES (" & p_Field_Value & ")"
                    If p_SQL_Upd <> "" Then
                        p_Row = p_Table.Rows.Add
                        p_Row(0) = p_SQL_Upd
                        p_DataUpd.Tables.Add(p_Table)
                        'If B1Get = True Then
                        '    p_ControlToDataTable = p_System.SysExecuteDataSet_Company(p_DataUpd)
                        'Else
                        '    p_ControlToDataTable = p_System.SysExecuteDataSet(p_DataUpd)
                        'End If
                    End If
                End If
            Else
                If p_SQL_Upd <> "" Then
                    p_SQL_Upd = Mid(Trim(p_SQL_Upd), 2)
                    p_SQL_Upd = "UPDATE " & p_Table_Name & " SET " & p_SQL_Upd
                    If p_Where <> "" Then
                        p_SQL_Upd = p_SQL_Upd & " WHERE " & p_Where
                    Else
                        p_ControlToDataTable = False
                        Exit Function
                    End If
                    p_Row = p_Table.Rows.Add
                    p_Row(0) = p_SQL_Upd
                    p_DataUpd.Tables.Add(p_Table)
                    'If B1Get = True Then
                    '    p_ControlToDataTable = p_System.SysExecuteDataSet_Company(p_DataUpd)
                    'Else
                    '    p_ControlToDataTable = p_System.SysExecuteDataSet(p_DataUpd)
                    'End If
                End If
            End If
            ' p_System = Nothing

            For p_Count = 0 To p_DataUpd.Tables(0).Rows.Count - 1
                p_Row = p_Table_Execute.Rows.Add
                p_Row(0) = p_DataUpd.Tables(0).Rows(p_Count).Item(0).ToString
                ' p_Table_Execute.Rows.Add(p_Row)
            Next
        Catch ex As Exception
            p_ControlToDataTable = False
        End Try

    End Function


    'ANHQH
    'Ham thuc hien Fill gia tri cua ComBobox vao TextBox
    Private Sub p_ComboBoxToTextBox(ByRef p_Form As Form)
        'Xu ly cho Combobox
        'ANHQH
        Dim p_ItemName As String
        Dim p_Object As Object
        Dim p_Control_Ind As Integer
        Dim p_Object_Item As Object
        Dim p_Object_Combo_Value As Object
        Dim p_Object_Tab_Item As Object

        For p_Control_Ind = 0 To p_Form.Controls.Count - 1
            p_Object = p_Form.Controls.Item(p_Control_Ind)
            If InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 Then
                p_ItemName = UCase(p_Object.Tag)
                If Not p_Object.value Is Nothing Then
                    If Not p_ItemName Is Nothing Then
                        p_Object_Combo_Value = p_Form.Controls.Find(p_ItemName, True)
                        If p_Object_Combo_Value.length > 0 Then
                            p_Object_Combo_Value(0).value = p_Object.value.ToString
                        End If
                    End If
                End If
            End If

            If InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                p_ItemName = UCase(p_Object.Tag)
                If Not p_Object.value Is Nothing Then
                    If Not p_ItemName Is Nothing Then
                        p_Object_Combo_Value = p_Form.Controls.Find(p_ItemName, True)
                        If p_Object_Combo_Value.length > 0 Then
                            If p_Object.Checked = True Then
                                p_Object_Combo_Value(0).value = p_Object.CheckValue.ToString
                            Else
                                p_Object_Combo_Value(0).value = p_Object.UnCheckValue.ToString
                            End If

                        End If
                    End If
                End If
            End If

            If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                    p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                    For p_Count = 0 To p_Object_Item.Controls.Count - 1
                        p_Object_Tab_Item = p_Object_Item.Controls(p_Count)

                        If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 Then
                            If Not p_Object_Tab_Item.value Is Nothing Then
                                p_ItemName = UCase(p_Object_Tab_Item.Tag)
                                If Not p_ItemName Is Nothing Then
                                    p_Object_Combo_Value = p_Form.Controls.Find(p_ItemName, True)
                                    If p_Object_Combo_Value.length > 0 Then
                                        p_Object_Combo_Value(0).value = p_Object_Tab_Item.value.ToString
                                    End If
                                End If
                            End If
                        End If

                        If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                            p_ItemName = UCase(p_Object_Tab_Item.Tag)
                            If Not p_Object_Tab_Item.value Is Nothing Then
                                If Not p_ItemName Is Nothing Then
                                    p_Object_Combo_Value = p_Form.Controls.Find(p_ItemName, True)
                                    If p_Object_Combo_Value.length > 0 Then
                                        If p_Object_Tab_Item.Checked = True Then
                                            p_Object_Combo_Value(0).value = p_Object_Tab_Item.CheckValue.ToString
                                        Else
                                            p_Object_Combo_Value(0).value = p_Object_Tab_Item.UnCheckValue.ToString
                                        End If

                                    End If
                                End If
                            End If
                        End If

                    Next
                Next
            End If
        Next
    End Sub
    Private Function p_Check_Item(ByVal p_ItemName As String, ByVal p_Upd As String) As Boolean
        Try
            p_Check_Item = True
            If p_ItemName.ToString = "" Then
                p_Check_Item = False
                Exit Function
            End If
            If p_Upd Is Nothing Then
                ' p_Check_Item = p_Check_Item
                Exit Function
            End If
            If p_Upd.ToString = "Y" Then
                'p_Check_Item = True
                p_Check_Item = False
                Exit Function
            Else
                p_Check_Item = True
                Exit Function
            End If

        Catch ex As Exception
            p_Check_Item = False
            'MsgBox(p_ItemName)
        End Try

    End Function


#Region "Import from Excel to GridView"
    'Private p_TrueGirdLineAdd(0 To 2000) As Boolean  'Dung mảng để lưu các line number trong TrueGrid khi thêm bản ghi
    'Private p_TrueGirdLineUpd(0 To 2000) As Boolean


    Public Function ModImportFromExcelToGridView(ByRef p_TrueDBGrid As U_TextBox.U_TrueDBGrid, _
                                                 ByRef p_GridVew As DevExpress.XtraGrid.Views.Grid.GridView, _
                                                 ByRef p_BidingSource As System.Windows.Forms.BindingSource, _
                                                  ByVal p_SheetName As String, _
                                                 ByRef p_TrueGirdLineAdd() As Boolean, _
                                                 ByRef p_TrueGirdLineUpd() As Boolean, _
                                                     ByRef p_TrueGirdLineDel() As String, _
                                                            ByRef p_Err As String) As Boolean

        Dim myStream As Stream = Nothing
        Dim OpenFileDialog1 As New OpenFileDialog()
        Dim p_Path As String = ""
        Dim p_DataTableImp As New DataTable
        Dim p_DataTableSource As New DataTable
        Dim p_ID As String
        Dim p_Caption As String
        Dim p_Field As String
        Dim p_RowGrid As DataRow
        Dim p_RowImp() As DataRow

        Dim p_Count As Integer
        Dim p_Count1 As Integer
        Dim p_Count2 As Integer
        Dim p_Update As Boolean

        Dim p_RowAdd As Integer

        Try
            ModImportFromExcelToGridView = True
            p_DataTableSource = p_BidingSource.DataSource

            p_ID = p_TrueDBGrid.ColumnKey
            If p_ID.Trim = "" Then
                ModImportFromExcelToGridView = False
                p_Err = "Không xác định ColumnKey"
                Exit Function
            End If

            Try
                p_Caption = p_GridVew.Columns.Item(p_ID).Caption
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            ' p_Caption = p_GridVew.Columns.Item(p_ID).Caption

            OpenFileDialog1.InitialDirectory = "c:\"
            OpenFileDialog1.Filter = "xls|*.xls|xlsx|*.xlsx"
            OpenFileDialog1.FilterIndex = 2
            OpenFileDialog1.RestoreDirectory = True

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                p_Path = OpenFileDialog1.FileName
                If p_Path <> "" Then
                    If ImportFromExcelToGridView(p_Path, p_SheetName, p_DataTableImp, p_Err) = False Then
                        ModImportFromExcelToGridView = False
                        'MsgBox(p_Err)
                        Exit Function
                    Else
                        If p_DataTableImp.Rows.Count >= 1 Then
                            p_RowImp = p_DataTableImp.Select(p_Caption & " is  Null")
                            p_RowAdd = p_RowImp.Length

                            p_RowImp = p_DataTableImp.Select(p_Caption & " is not Null")
                            p_Update = False
                            'Neu khong co dong nao update thi thoi
                            ' ReDim p_TrueGirdLineUpd(0 To p_DataTableSource.Rows.Count)
                            If Not p_RowImp Is Nothing Then
                                If p_RowImp.Length > 0 Then
                                    p_Update = True
                                End If
                            End If

                            ReDim p_TrueGirdLineAdd(0 To p_DataTableSource.Rows.Count + p_DataTableImp.Rows.Count + 1)
                            ReDim p_TrueGirdLineUpd(0 To p_DataTableSource.Rows.Count + p_DataTableImp.Rows.Count + 1)
                            ReDim p_TrueGirdLineDel(0 To p_DataTableSource.Rows.Count + p_DataTableImp.Rows.Count + 1)

                            If p_Update = True Then
                                'If p_RowImp.Length > 0 Then

                                For p_Count = 0 To p_DataTableSource.Rows.Count - 1
                                    'If p_Count = 1000 Then
                                    '    MsgBox("dfdd")
                                    'End If
                                    'p_RowImp = Nothing
                                    ' p_RowImp.

                                    ' Dim p_RowImp() As DataRow
                                    p_RowImp = p_DataTableImp.Select(p_Caption & "=" & p_DataTableSource.Rows(p_Count).Item(p_ID).ToString.Trim)
                                    If p_RowImp.Length > 0 Then
                                        'Update
                                        For p_Count1 = 0 To p_DataTableImp.Columns.Count - 1
                                            'If p_Count = 1000 And p_Count1 = 13 Then
                                            '    MsgBox("dfdd")
                                            'End If

                                            If p_DataTableImp.Columns(p_Count1).ColumnName <> p_Caption Then
                                                p_Field = p_GetFieldName(p_GridVew, p_DataTableImp.Columns(p_Count1).ColumnName)
                                                If p_Field <> "" Then
                                                    If Not p_GridVew.Columns.Item(p_Field).ColumnEdit Is Nothing Then
                                                        If UCase(p_GridVew.Columns.Item(p_Field).ColumnEdit.EditorTypeName) = UCase("CheckEdit") Then
                                                            If p_RowImp(p_Count2).Item(p_DataTableImp.Columns(p_Count1).ColumnName).ToString.Trim = "Y" Then
                                                                p_DataTableSource.Rows(p_Count).Item(p_Field) = p_RowImp(p_Count2).Item(p_DataTableImp.Columns(p_Count1).ColumnName)
                                                            ElseIf UCase(p_RowImp(p_Count2).Item(p_DataTableImp.Columns(p_Count1).ColumnName).ToString.Trim) = UCase("Checked") Then
                                                                p_DataTableSource.Rows(p_Count).Item(p_Field) = "Y"
                                                            End If
                                                        Else
                                                            p_DataTableSource.Rows(p_Count).Item(p_Field) = p_RowImp(p_Count2).Item(p_DataTableImp.Columns(p_Count1).ColumnName)
                                                        End If
                                                    Else
                                                        p_DataTableSource.Rows(p_Count).Item(p_Field) = p_RowImp(p_Count2).Item(p_DataTableImp.Columns(p_Count1).ColumnName)
                                                    End If
                                                End If
                                            End If
                                        Next
                                    Else

                                    End If
                                    p_TrueGirdLineUpd(p_Count) = True
                                Next
                                'End If
                            End If
                            p_Count = p_DataTableSource.Rows.Count

                            p_RowImp = p_DataTableImp.Select(p_Caption & " is Null")
                            ' ReDim p_TrueGirdLineAdd(0 To p_DataTableSource.Rows.Count + p_RowImp.Length + 2)
                            For p_Count2 = 0 To p_RowImp.Length - 1
                                '  p_RowGrid=
                                If p_CheckAddnew(p_Count2, p_RowImp(p_Count2)) = True Then
                                    p_RowGrid = p_DataTableSource.NewRow
                                    For p_Count1 = 0 To p_DataTableImp.Columns.Count - 1
                                        If p_DataTableImp.Columns(p_Count1).ColumnName <> p_Caption Then

                                            p_Field = p_GetFieldName(p_GridVew, p_DataTableImp.Columns(p_Count1).ColumnName)
                                            If p_Field <> "" Then
                                                'p_RowGrid.Item(p_Field) = p_RowImp(p_Count2).Item(p_DataTableImp.Columns(p_Count1).ColumnName)
                                                'p_RowGrid.Item(p_Field) = p_RowImp(p_Count2).Item(p_DataTableImp.Columns(p_Count1).ColumnName)
                                                If Not p_GridVew.Columns.Item(p_Field).ColumnEdit Is Nothing Then
                                                    If UCase(p_GridVew.Columns.Item(p_Field).ColumnEdit.EditorTypeName) = UCase("CheckEdit") Then
                                                        If p_RowImp(p_Count2).Item(p_DataTableImp.Columns(p_Count1).ColumnName).ToString.Trim = "Y" Then
                                                            p_RowGrid.Item(p_Field) = p_RowImp(p_Count2).Item(p_DataTableImp.Columns(p_Count1).ColumnName)
                                                        ElseIf UCase(p_RowImp(p_Count2).Item(p_DataTableImp.Columns(p_Count1).ColumnName).ToString.Trim) = UCase("Checked") Then
                                                            p_RowGrid.Item(p_Field) = "Y"
                                                        End If
                                                    Else
                                                        p_RowGrid.Item(p_Field) = p_RowImp(p_Count2).Item(p_DataTableImp.Columns(p_Count1).ColumnName)
                                                    End If
                                                Else
                                                    p_RowGrid.Item(p_Field) = p_RowImp(p_Count2).Item(p_DataTableImp.Columns(p_Count1).ColumnName)
                                                End If

                                                'p_DataTableSource.Rows(p_Count).Item(p_Field) = p_RowImp(p_Count2).Item(p_DataTableImp.Columns(p_Count1).ColumnName)
                                            End If
                                        End If
                                    Next
                                    p_DataTableSource.Rows.Add(p_RowGrid)
                                    p_TrueGirdLineAdd(p_Count + p_Count2) = True
                                End If
                            Next
                        End If
                        p_BidingSource.DataSource = p_DataTableSource
                        p_BidingSource.ResetBindings(True)
                        p_TrueDBGrid.Refresh()


                    End If


                End If

            End If


        Catch ex As Exception
            ModImportFromExcelToGridView = False
            p_Err = ex.Message
        End Try
    End Function

    Private Function p_CheckAddnew(ByVal p_RowID As Integer, ByVal p_RowImp As DataRow) As Boolean
        Dim p_ColumnID As Integer
        p_CheckAddnew = False
        Try
            For p_ColumnID = 0 To p_RowImp.Table.Columns.Count - 1
                If p_RowImp.Item(p_ColumnID).ToString.Trim <> "" Then
                    p_CheckAddnew = True
                    Exit Function
                End If
            Next
        Catch ex As Exception
            p_CheckAddnew = False
        End Try

    End Function

    Private Function p_GetFieldName(ByVal p_GridVew As DevExpress.XtraGrid.Views.Grid.GridView, _
                                    ByVal p_Str As String) As String
        Dim p_Count As Integer

        Try
            p_GetFieldName = ""
            For p_Count = 0 To p_GridVew.Columns.Count - 1
                If p_GridVew.Columns.Item(p_Count).Caption = p_Str Then
                    p_GetFieldName = p_GridVew.Columns.Item(p_Count).FieldName
                    Exit Function
                End If
            Next
        Catch ex As Exception
            p_GetFieldName = ""
        End Try
    End Function



    Public Function ImportFromExcelToGridView(ByVal p_Path As String, _
                                              ByVal p_SheetName As String, _
                                              ByRef p_DataTableImp As DataTable, _
                                                ByRef p_Errdes As String
                                                  ) As Boolean
        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim DS As System.Data.DataSet

        Dim connect As System.Data.OleDb.OleDbConnection ' = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" & p_Path & ";Extended Properties=Excel 12.0")
        Dim adapter As System.Data.OleDb.OleDbDataAdapter ' = New System.Data.OleDb.OleDbDataAdapter("select ItemCode,Price,FromDate,ToDate,	FromHou	,ToHou, Status from [PriceList$] ", connect)


        Try
            ImportFromExcelToGridView = True
            DS = New System.Data.DataSet

            connect = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data source=" & p_Path & ";Extended Properties=Excel 12.0")
            connect.Open()
            adapter = New System.Data.OleDb.OleDbDataAdapter("select * from [" & p_SheetName & "$]", connect)
            adapter.Fill(DS)
            ImportFromExcelToGridView = True
            p_DataTableImp = DS.Tables(0)

            If Not adapter Is Nothing Then
                adapter.Dispose()
                adapter = Nothing
            End If
            If Not connect Is Nothing Then
                If connect.State = ConnectionState.Open Then
                    connect.Close()
                    connect.Dispose()
                End If
                connect = Nothing
            End If


        Catch ex As Exception
            If Not adapter Is Nothing Then
                adapter.Dispose()
                adapter = Nothing
            End If
            If Not connect Is Nothing Then
                If connect.State = ConnectionState.Open Then
                    connect.Close()
                    connect.Dispose()
                End If
                connect = Nothing
            End If


            p_Errdes = ex.Message
            ImportFromExcelToGridView = False
        End Try
    End Function
#End Region


    Public Function p_UpdateParentID(ByVal p_Item As U_TextBox.U_TextBox, ByVal GridView1 As DevExpress.XtraGrid.Views.Grid.GridView, _
                                   ByVal pv_TrueGirdLineAdd() As Boolean, ByRef p_Desc As String) As Boolean
        Dim p_Count As Integer
        Dim p_FieldName As String
        Dim p_Value As String

        p_Desc = ""
        p_UpdateParentID = True
        Try
            If Not p_Item.EditValue Is Nothing Then
                If p_Item.EditValue.ToString.Trim <> "" Then
                    p_FieldName = p_Item.FieldName
                    p_Value = p_Item.EditValue
                    For p_Count = 0 To pv_TrueGirdLineAdd.Length - 1
                        If pv_TrueGirdLineAdd(p_Count) = True Then
                            GridView1.SetRowCellValue(p_Count, p_Item.FieldName, p_Item.EditValue)
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            p_UpdateParentID = False
            p_Desc = ex.Message
        End Try

    End Function

    'ANHQH
    '29/11/2011
    'Ham thuc hien lay danh sach menu va Submenu
    Public Function p_Sys_Get_Menu_Submenu(ByVal p_User As Double, ByRef p_MenuSet As DataSet) As Boolean
        Dim p_SQLMnu As String
        Dim p_DataTemp As New DataSet
        Dim p_dataTable As New DataTable
        Dim p_Row As DataRow
        Dim p_Col1 As DataColumn

        Dim p_SQLSubMnu As String
        Dim p_Index As Integer
        Dim p_Index_Submenu As Integer
        p_Sys_Get_Menu_Submenu = True


        Try

            p_SQLMnu = "select A.menu_id, B.menu_name,B.description, B.Menu_Code " & _
                        "from sys_user_responds A,sys_menu B " & _
                        "where(a.menu_id = b.menu_id And USER_ID IN (select USER_ID from  SYS_USER where USER_ID= " & p_User & ")) " & _
                        " AND CONVERT (date, GETDATE ()) BETWEEN ISNULL(A.FROM_DATE,CONVERT (date, GETDATE ())) AND ISNULL(A.TO_DATE,CONVERT (date, GETDATE ()))" & _
                        "order by  menu_id"

            p_MenuSet = g_Service.mod_SYS_GET_DATASET(p_SQLMnu)

        Catch
            p_Sys_Get_Menu_Submenu = False
        End Try
    End Function


    'ANHQH
    '29/11/2011
    'Ham thuc hien lay danh sach menu va Submenu
    Public Function p_Sys_Get_Menu_SubmenuChild(ByVal p_User As Double, ByVal p_MenuParentCode As String, _
                                                ByRef p_SubmenuSet As DataSet, ByVal p_DBType As String) As Boolean

        Dim p_DataTemp As New DataSet
        Dim p_dataTable As New DataTable


        Dim p_SQLSubMnu As String

        p_Sys_Get_Menu_SubmenuChild = True
        Dim p_ErrDess As String = ""

        Try

            g_DBTYPE = p_DBType
            'anhqh
            '18/01/2014
            'p_SQLSubMnu = "SELECT A2.FUNCTION_ID,A2.FUNCTION_NAME,A2.DESCRIPTION,A3.FORM_NAME,A3.PROJECT_CODE " & _
            '        "FROM SYS_FUNCTION A2, SYS_FORMS A3,  SYS_RESPONSIBILITY_MENU A4  " & _
            '        " WHERE(A2.FORM_ID = A3.FORM_ID) AND A4.MENU_CODE ='" & p_MenuSet.Tables(0).Rows(p_Index).Item(3).ToString & "' " & _
            '        " AND CONVERT (date, GETDATE ()) BETWEEN ISNULL(A2.FROM_DATE,CONVERT (date, GETDATE ())) AND ISNULL(A2.TO_DATE,CONVERT (date, GETDATE ())) " & _
            '        " AND a2.function_id=a4.function_id ORDER BY A4.ORDER_NUM"
            If g_DBTYPE = "ORACLE" Then
                p_SQLSubMnu = "SELECT      A2.FUNCTION_ID, A2.FUNCTION_NAME, A2.DESCRIPTION, A3.FORM_NAME, A3.PROJECT_CODE, A4.SubMenu, A4.SubMenuName FROM   " & _
                     "SYS_FUNCTION  A2 INNER JOIN  SYS_FORMS  A3 ON A2.FORM_ID = A3.FORM_ID RIGHT OUTER JOIN " & _
                      "SYS_RESPONSIBILITY_MENU  A4 ON A2.FUNCTION_ID = A4.FUNCTION_ID  WHERE     (A4.MENU_CODE = '" & p_MenuParentCode & "')  " & _
                      "AND to_date(sysdate) BETWEEN nvl(to_date(A2.FROM_DATE), to_date('01-JAN-1900') ) " & _
                      "AND nvl(to_date(A2.TO_DATE),  to_date( sysdate)+10) AND to_date(sysdate) " & _
                      "BETWEEN nvl(to_date(A4.FROM_DATE), to_date( '01-JAN-1900')) " & _
                       "AND nvl(to_date(A4.TO_DATE),to_date(sysdate+10)) AND to_date(sysdate)  " & _
                       "BETWEEN nvl(to_date(A3.FROM_DATE), to_date('01-JAN-1900'))  " & _
                       "AND nvl(to_date(A3.TO_DATE),to_date(sysdate+10))  ORDER BY A4.ORDER_NUM "
                p_SubmenuSet = g_Service.mod_SYS_GET_DATASET_Oracle(p_SQLSubMnu, p_ErrDess)
            ElseIf g_DBTYPE = "SQL" Then
                p_SQLSubMnu = "SELECT      A2.FUNCTION_ID, A2.FUNCTION_NAME, A2.DESCRIPTION, A3.FORM_NAME, A3.PROJECT_CODE, " & _
                       "A4.SubMenu, A4.SubMenuName " & _
                       "FROM         dbo.SYS_FUNCTION AS A2 INNER JOIN " & _
                       " dbo.SYS_FORMS AS A3 ON A2.FORM_ID = A3.FORM_ID RIGHT OUTER JOIN " & _
                       " dbo.SYS_RESPONSIBILITY_MENU AS A4 ON A2.FUNCTION_ID = A4.FUNCTION_ID " & _
                   " WHERE     (A4.MENU_CODE = '" & p_MenuParentCode & "') AND (CONVERT(date, GETDATE()) BETWEEN ISNULL(CONVERT(date,A2.FROM_DATE), CONVERT(date,'01/01/1900')) AND ISNULL(CONVERT(date,A2.TO_DATE),  " & _
                           "CONVERT(date, GETDATE()+10))) " & _
                           "AND (CONVERT(date, GETDATE()) BETWEEN ISNULL(CONVERT(date,A4.FROM_DATE), CONVERT(date, '01/01/1900')) AND ISNULL(CONVERT(date,A4.TO_DATE),CONVERT(date, GETDATE()+10))) " & _
                           " and not exists (select 1 from SYS_USER_MENU_EXP aa where aa.FUNCTION_ID=a2.FUNCTION_ID " & _
                        " AND (CONVERT(date, GETDATE()) BETWEEN ISNULL(CONVERT(date,Aa.FROM_DATE), CONVERT(date, '01/01/1900')) AND ISNULL(CONVERT(date,Aa.TO_DATE),CONVERT(date, GETDATE()+10))) " & _
                        "and 	aa.USER_ID=" & p_User & ") " & _
                           " ORDER BY A4.ORDER_NUM"
                p_SubmenuSet = g_Service.mod_SYS_GET_DATASET(p_SQLSubMnu)
            End If


        Catch
            p_Sys_Get_Menu_SubmenuChild = False
            p_SubmenuSet = Nothing
        End Try
    End Function




    'ANHQH
    '29/11/2011
    'Ham thuc hien lay danh sach menu va Submenu
    Public Function p_Sys_Get_Menu_SubmenuChildNew(ByVal p_User As Double, ByVal p_DBType As String) As DataTable

        Dim p_DataTemp As New DataSet
        Dim p_dataTable As New DataTable


        Dim p_SQLSubMnu As String

        ' p_Sys_Get_Menu_SubmenuChildNew = True


        Try


            'anhqh
            '18/01/2014
            'p_SQLSubMnu = "SELECT A2.FUNCTION_ID, A2.FUNCTION_NAME, A2.DESCRIPTION, A3.FORM_NAME, A3.PROJECT_CODE, " & _
            '             "A4.SubMenu, A4.SubMenuName, A4.MENU_CODE  " & _
            '             "FROM         dbo.SYS_FUNCTION AS A2 INNER JOIN " & _
            '             " dbo.SYS_FORMS AS A3 ON A2.FORM_ID = A3.FORM_ID RIGHT OUTER JOIN " & _
            '             " dbo.SYS_RESPONSIBILITY_MENU AS A4 ON A2.FUNCTION_ID = A4.FUNCTION_ID " & _
            '         " WHERE    (CONVERT(date, GETDATE()) BETWEEN ISNULL(A2.FROM_DATE, CONVERT(date, GETDATE())) AND ISNULL(A2.TO_DATE,  " & _
            '                 "CONVERT(date, GETDATE()))) ORDER BY A4.ORDER_NUM"
            g_DBTYPE = p_DBType

            If g_DBTYPE = "ORACLE" Then
                p_SQLSubMnu = "SELECT      A2.FUNCTION_ID, A2.FUNCTION_NAME, A2.DESCRIPTION, A3.FORM_NAME, A3.PROJECT_CODE, A4.SubMenu, A4.SubMenuName ," & _
                        "A4.MENU_CODE  FROM         SYS_FUNCTION  A2 INNER JOIN  SYS_FORMS  A3 ON A2.FORM_ID = A3.FORM_ID " & _
                        "RIGHT OUTER JOIN  SYS_RESPONSIBILITY_MENU A4 ON A2.FUNCTION_ID = A4.FUNCTION_ID   " & _
                        "WHERE     exists (select 1 from SYS_USER_RESPONDS_V  where USER_ID =" & p_User & " and MENU_CODE =A4.MENU_CODE)  " & _
                            "AND (to_date(sysdate) BETWEEN nvl(to_date(A2.FROM_DATE), to_date('01-JAN-1900'))  " & _
                            "AND nvl(to_date(A2.TO_DATE),  to_date( sysdate+10)))  " & _
                            "AND (to_date( sysdate)   BETWEEN nvl(to_date(A4.FROM_DATE), to_date( '01-JAN-1900')) AND nvl(to_date(A4.TO_DATE), " & _
                            "to_date( sysdate+10))) AND (to_date(sysdate) BETWEEN nvl(to_date(A3.FROM_DATE), " & _
                            "to_date( '01-JAN-1900')) AND nvl(to_date(A3.TO_DATE),to_date(sysdate+10)))  ORDER BY A4.ORDER_NUM"

                p_Sys_Get_Menu_SubmenuChildNew = g_Service.SYS_GET_DATATABLE_oracle(p_SQLSubMnu)
            ElseIf g_DBTYPE = "SQL" Then
                p_SQLSubMnu = "SELECT      A2.FUNCTION_ID, A2.FUNCTION_NAME, A2.DESCRIPTION, A3.FORM_NAME, A3.PROJECT_CODE, " & _
                       "A4.SubMenu, A4.SubMenuName , A4.MENU_CODE, a3.Icon_File  " & _
                       "FROM         dbo.SYS_FUNCTION AS A2 INNER JOIN " & _
                       " dbo.SYS_FORMS AS A3 ON A2.FORM_ID = A3.FORM_ID RIGHT OUTER JOIN " & _
                       " dbo.SYS_RESPONSIBILITY_MENU AS A4 ON A2.FUNCTION_ID = A4.FUNCTION_ID " & _
                   " WHERE     exists (select 1 from SYS_USER_RESPONDS_V  where USER_ID =" & p_User & " and MENU_CODE =A4.MENU_CODE) " & _
                                " AND (CONVERT(date, GETDATE()) BETWEEN ISNULL(CONVERT(date,A2.FROM_DATE), CONVERT(date,'01/01/1900')) AND ISNULL(CONVERT(date,A2.TO_DATE),  " & _
                           "CONVERT(date, GETDATE()+10))) " & _
                           "AND (CONVERT(date, GETDATE()) BETWEEN ISNULL(CONVERT(date,A4.FROM_DATE), CONVERT(date, '01/01/1900')) AND ISNULL(CONVERT(date,A4.TO_DATE),CONVERT(date, GETDATE()+10))) " & _
                           "AND (CONVERT(date, GETDATE()) BETWEEN ISNULL(CONVERT(date,A3.FROM_DATE), CONVERT(date, '01/01/1900')) AND ISNULL(CONVERT(date,A3.TO_DATE),CONVERT(date, GETDATE()+10))) " & _
                    " and not exists (select 1 from SYS_USER_MENU_EXP aa where aa.FUNCTION_ID=a2.FUNCTION_ID " & _
                        " AND (CONVERT(date, GETDATE()) BETWEEN ISNULL(CONVERT(date,Aa.FROM_DATE), CONVERT(date, '01/01/1900')) AND ISNULL(CONVERT(date,Aa.TO_DATE),CONVERT(date, GETDATE()+10))) " & _
                        "and 	aa.USER_ID=" & p_User & ") " & _
                    " ORDER BY A4.ORDER_NUM"

                p_Sys_Get_Menu_SubmenuChildNew = g_Service.mod_SYS_GET_DATATable(p_SQLSubMnu)
            End If


        Catch ex As Exception
            p_Sys_Get_Menu_SubmenuChildNew = Nothing
            MsgBox(ex.Message)
            'p_SubmenuSet = Nothing
        End Try
    End Function


    Public Function p_GirdViewCheckRequiredBeforUpdate(ByVal p_DataSet_TrueGird As DataSet, ByVal p_FormName As String, _
                                                         ByRef p_TrueGrid As U_TextBox.U_TrueDBGrid, _
                                                         ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                                         ByRef p_DescError As String, _
                                                         Optional ByVal p_CheckAllRow As Boolean = True) As Boolean
        'p_DataSet_TrueGird
        Dim p_DataRow As DataRow
        Dim p_DataRowRequired() As DataRow

        Dim p_Count As Integer
        Dim p_ColumnName As String
        Try
            p_GirdViewCheckRequiredBeforUpdate = True
            If p_GridView.RowCount > 0 Then

                p_DataRowRequired = p_DataSet_TrueGird.Tables(0).Select("FORM_NAME='" & p_FormName.Trim & "' and GRID_NAME='" & p_TrueGrid.Name & "' and Required='Y'", "ORDER_BY")
                If p_CheckAllRow = True Then
                    p_GridView.MoveFirst()

                    If p_DataRowRequired.Length > 0 Then
                        While Not p_GridView.IsLastRow

                            p_DataRow = p_GridView.GetFocusedDataRow
                            If Not p_DataRow Is Nothing Then
                                For p_Count = 0 To p_DataRowRequired.Length - 1
                                    p_ColumnName = p_DataRowRequired(p_Count).Item("COL_NAME").ToString.Trim
                                    If p_DataRow.Item(p_ColumnName).ToString.Trim = "" Then
                                        p_DescError = p_DataRowRequired(p_Count).Item("CAPTION").ToString.Trim & "  không được trống"

                                        p_GirdViewCheckRequiredBeforUpdate = False
                                        Exit Function
                                    End If
                                Next
                            End If

                            p_GridView.MoveNext()
                        End While
                    End If
                    If p_GridView.IsLastRow = True And p_GridView.IsNewItemRow(p_GridView.FocusedRowHandle) = False Then
                        p_DataRow = p_GridView.GetFocusedDataRow
                        If Not p_DataRow Is Nothing Then
                            For p_Count = 0 To p_DataRowRequired.Length - 1
                                p_ColumnName = p_DataRowRequired(p_Count).Item("COL_NAME").ToString.Trim
                                If p_DataRow.Item(p_ColumnName).ToString.Trim = "" Then
                                    p_DescError = p_DataRowRequired(p_Count).Item("CAPTION").ToString.Trim & "  không được trống"

                                    p_GirdViewCheckRequiredBeforUpdate = False
                                    Exit Function
                                End If
                            Next
                        End If
                    End If
                Else
                    If p_GridView.IsNewItemRow(p_GridView.FocusedRowHandle) = False Then
                        p_DataRow = p_GridView.GetFocusedDataRow
                        If Not p_DataRow Is Nothing Then
                            For p_Count = 0 To p_DataRowRequired.Length - 1
                                'p_GridView.FocusedColumn.FieldName
                                p_ColumnName = p_DataRowRequired(p_Count).Item("COL_NAME").ToString.Trim
                                If p_DataRow.Item(p_ColumnName).ToString.Trim = "" Then
                                    p_DescError = p_DataRowRequired(p_Count).Item("CAPTION").ToString.Trim & "  không được trống"

                                    p_GirdViewCheckRequiredBeforUpdate = False
                                    Exit Function
                                End If
                            Next
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            p_DescError = ex.Message
            p_GirdViewCheckRequiredBeforUpdate = False
        End Try
    End Function


    Public Sub p_Edit_Button_Click(ByVal p_Item As U_TextBox.U_ButtonEdit, _
                                        ByRef p_RptForm As Object, _
                                        ByRef p_Commit1 As Boolean, _
                                         ByRef p_ButtonOK As Object, _
                                        ByVal p_CaptionUpd As String, Optional ByVal p_SmallFormSearch As Boolean = False)
        Dim p_Form As Object
        If p_SmallFormSearch = False Then
            p_Form = New FrmSearch
        Else
            p_Form = New FrmSearchLov
        End If

        Dim p_ShpCod As String = ""
        Dim p_Databale As New DataTable
        Dim p_EditText As New DevExpress.XtraEditors.TextEdit
        Dim p_SQL As String
        Dim p_OrderbyExt As String = ""

        'Dim p_FptMod As New FPTModule.Class1(g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName)

        If p_Item.SqlString <> "" And p_Item.SqlFielKey <> "" Then
            Try
                p_RptForm.g_ChooseRecordFromSearch = False
            Catch ex As Exception

            End Try
            p_SQL = p_Item.SqlString
            p_OrderbyExt = p_Item.OrderbyEx.ToString.Trim
            p_SQL = p_Parameter_Item(p_RptForm, p_SQL)
            p_Form.FptSQLString = p_SQL   'Replace(p_Item.SqlString, "@DATABASE", g_DatabaseName, 1)
            'p_Parameter_Item
            p_Form.FptFieldKey = p_Item.SqlFielKey
            p_Form.Fpt_Object = p_Item
            'p_Form.FptB1Get = False
            p_Form.FptPageNum = 1
            p_Form.FptLineOfPage = 1000
            p_Form.FptLoadPage = True
            p_Form.FptItemPosition = p_Item
            p_Form.FptTypePosition = "C"
            p_Form.FptParentForm = p_RptForm
            p_Form.FptShowLoad = p_Item.ShowLoad
            'p_Form.FptRowID = 0
            p_Form.p_OrderbyExt = p_OrderbyExt
            If p_OrderbyExt <> "" Then
                p_Form.FptLoadPage = False
            End If
            p_Form.p_ObjSearchReturn(0) = p_Item.Name

            If p_Item.ItemReturn1 <> "" Then
                p_Form.p_ObjSearchReturn(1) = p_Item.ItemReturn1
            End If
            If p_Item.ItemReturn2 <> "" Then
                p_Form.p_ObjSearchReturn(2) = p_Item.ItemReturn2
            End If

            If p_Item.ItemReturn3 <> "" Then
                p_Form.p_ObjSearchReturn(3) = p_Item.ItemReturn3
            End If

            If p_Item.AutoWidth = False Then
                p_Form.p_ColumnWidth(0) = "80"
                p_Form.p_ColumnWidth(1) = "150"
            End If

           
            p_Form.p_ChooseRecord = p_EditText
            p_Form.ShowDialog(p_RptForm)
            If Not p_ButtonOK Is Nothing Then
                If Not p_EditText.EditValue Is Nothing Then
                    If p_EditText.EditValue.ToString.Trim = "Y" Then
                        If p_Commit1 = True Then Exit Sub
                        If p_Commit1 = False Then
                            p_Commit1 = True
                            Try
                                p_RptForm.FormStatus = True
                                p_RptForm.g_ChooseRecordFromSearch = True
                            Catch ex As Exception

                            End Try
                            p_ButtonOK.Text = p_CaptionUpd
                        End If
                    End If
                End If
            Else
                If Not p_EditText.EditValue Is Nothing Then
                    If p_EditText.EditValue.ToString.Trim = "Y" Then
                        If p_Commit1 = True Then Exit Sub
                        If p_Commit1 = False Then
                            p_Commit1 = True
                            Try
                                p_RptForm.FormStatus = True
                                p_RptForm.g_ChooseRecordFromSearch = True
                            Catch ex As Exception

                            End Try
                            ' p_ButtonOK.Text = p_CaptionUpd
                        End If
                    End If
                End If
            End If
            If p_Item.UpdateWhenFormLock = True And p_RptForm.FormEdit = False Then
                If Not p_EditText.EditValue Is Nothing Then
                    If p_EditText.EditValue.ToString.Trim = "Y" Then
                        If p_Commit1 = True Then Exit Sub
                        If p_Commit1 = False Then
                            p_Commit1 = True
                            Try
                                p_RptForm.FormStatus = True
                                p_RptForm.g_ChooseRecordFromSearch = True
                            Catch ex As Exception

                            End Try
                            'p_ButtonOK.Text = p_CaptionUpd
                        End If
                    End If
                End If
            End If
        End If
        ' End Select
        'p_FptMod = Nothing
    End Sub

    Public Sub p_Gridview_Column_Button_Click(ByRef p_TrueGrid As U_TextBox.U_TrueDBGrid, _
                                               ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                                ByRef p_RptForm As Object, _
                                        ByRef p_Commit1 As Boolean, _
                                        ByRef p_ButtonOK As Object, _
                                        ByVal p_ColumnName As String, _
                                        ByVal p_DataSet_TrueGird As DataSet, _
                                        Optional ByVal p_StrSQL As String = "", _
                                        Optional ByVal p_AddNewRow As Boolean = True)
        Dim p_Form As New FrmSearch
        Dim p_ShpCod As String = ""
        Dim p_EditText As New DevExpress.XtraEditors.TextEdit
        Dim p_SQL As String
        ' Dim p_FptModule As New FPTModule.Class1(g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName)
        Dim p_RowArr() As DataRow
        'Dim p_Row As DataRow

        If p_GridView.RowCount >= 0 Then
            p_RowArr = p_DataSet_TrueGird.Tables(0).Select("COL_NAME='" & p_ColumnName & "' and FORM_NAME='" & p_RptForm.Name & "'")
            If p_RowArr.Length > 0 Then
                If p_StrSQL.Trim <> "" Then
                    p_SQL = p_StrSQL
                Else
                    p_SQL = p_RowArr(0).Item("CFLSQL").ToString.Trim
                End If

                If p_SQL = "" Then Exit Sub
                p_SQL = p_Parameter_Item(p_RptForm, p_SQL)

                p_Form.FptSQLString = p_SQL   ' "select  ItemCode as [Mã sản phẩm], ItemName as [Tên sản phẩm] from FPTOITM where SellItem='Y' "
                p_Form.FptFieldKey = p_RowArr(0).Item("CFLKeyField").ToString.Trim
                p_Form.Fpt_Object = p_GridView
                p_Form.FptB1Get = False
                p_Form.FptPageNum = 1
                p_Form.FptLineOfPage = 500
                p_Form.FptLoadPage = True
                p_Form.FptItemPosition = p_GridView
                p_Form.FptTypePosition = "C"
                p_Form.FptParentForm = p_RptForm
                If p_RowArr(0).Item("ShowLoadCFL").ToString.Trim = "Y" Then
                    p_Form.FptShowLoad = True
                Else
                    p_Form.FptShowLoad = False
                End If

                If p_GridView.FocusedRowHandle < 0 And p_AddNewRow = True Then
                    p_GridView.AddNewRow()
                End If
                p_Form.FptRowID = p_GridView.FocusedRowHandle
                p_Form.p_ObjSearchReturn(0) = p_ColumnName
                If p_RowArr(0).Item("CFLReturn1").ToString.Trim <> "" Then
                    p_Form.p_ObjSearchReturn(1) = p_RowArr(0).Item("CFLReturn1").ToString.Trim
                End If
                If p_RowArr(0).Item("CFLReturn2").ToString.Trim <> "" Then
                    p_Form.p_ObjSearchReturn(2) = p_RowArr(0).Item("CFLReturn2").ToString.Trim
                End If
                If p_RowArr(0).Item("CFLReturn3").ToString.Trim <> "" Then
                    p_Form.p_ObjSearchReturn(3) = p_RowArr(0).Item("CFLReturn3").ToString.Trim
                End If
                If p_RowArr(0).Item("CFLReturn4").ToString.Trim <> "" Then
                    p_Form.p_ObjSearchReturn(4) = p_RowArr(0).Item("CFLReturn4").ToString.Trim
                End If
                'p_Form.p_ObjSearchReturn(1) = "U_ItmName"
                p_Form.p_ColumnWidth(0) = "80"
                p_Form.p_ColumnWidth(1) = "150"

                p_Form.p_ChooseRecord = p_EditText

                p_Form.ShowDialog(p_RptForm)

                If Not p_EditText.EditValue Is Nothing Then
                    If p_EditText.EditValue.ToString.Trim = "Y" Then
                        If p_Commit1 = True Then
                            p_GridView.UpdateCurrentRow()
                            p_GridView.RefreshData()
                            Exit Sub
                        End If

                        If p_Commit1 = False Then
                            p_Commit1 = True
                            Try
                                p_ButtonOK.Text = p_RptForm.CaptionUpd
                            Catch ex As Exception
                                p_ButtonOK.Text = "Update"
                            End Try


                        End If
                        Try
                            p_RptForm.g_ChooseRecordFromSearch = True
                        Catch ex As Exception

                        End Try
                        p_GridView.UpdateCurrentRow()
                        p_GridView.RefreshData()
                    End If

                    p_EditText.EditValue = "N"
                End If
            End If
        End If

        '  p_FptModule = Nothing
    End Sub


    'anhqh
    '30/06/2014
    'Dungf cho cac tabcontrol
    'ByVal p_BindingSource As Object, _
    'ByVal p_DBDataSet As DataSet, ByVal p_TableID As Integer, _
    Public Function p_CompileControlHeader_PageToSQL(ByVal p_DataSet_TrueGird As DataSet, _
                                                     ByRef p_Form As Object, _
                                             ByVal p_Object As Object, _
                                    ByVal p_Table_Name As String, _
                                    ByVal p_Insert_Type As Boolean, _
                                     ByRef p_Field_Ins As String, _
                                            ByRef p_Field_Value As String, _
                                             ByRef p_SQL_Upd As String, _
                                             ByRef p_Where As String, _
                                             ByVal p_ControlKey As Object, _
                                                              ByRef p_Table As DataTable, _
                                                              Optional ByVal p_UserName As String = "") As Boolean
        Dim p_Object_Item As Object
        Dim p_Object_Tab As DevExpress.XtraTab.XtraTabPage
        Dim p_Object_Tab_Item As Object
        Dim p_FieldType As String
        Dim p_ItemName As String
        Dim p_Value As String
        ' Dim p_FieldType As String
        Dim p_KeyInsert As String
        Dim p_SQL As String
        Dim p_TrueDBGrid As U_TextBox.U_TrueDBGrid
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim p_Object1 As DevExpress.XtraTab.XtraTabControl

        p_CompileControlHeader_PageToSQL = True
        If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
            Try
                For p_TabControl_Ind = p_Object.TabPages.Count - 1 To 0 Step -1
                    ' For Each p_Control In p_Object.Controls
                    'p_Object.TabPages(p_TabControl_Ind).Select()
                    p_Object.SelectedTabPageIndex = p_TabControl_Ind
                    p_Object_Tab = p_Object.TabPages(p_TabControl_Ind) ' p_Control
                    ' p_Object_Tab.Select()
                    'If p_Object_Tab.name = "XtraTabPage7" Then
                    '    MsgBox("dfgdfgg")
                    'End If
                    ' p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                    ' For p_Count = 0 To p_Object_Item.Controls.Count - 1
                    'p_Object_Tab_Item = p_Object_Item.Controls(p_Count)
                    If InStr(UCase(p_Object_Tab.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                        If p_CompileControlHeader_PageToSQL(p_DataSet_TrueGird, p_Form,
                                                     p_Object_Tab,
                                                       p_Table_Name,
                                                       p_Insert_Type,
                                                         p_Field_Ins,
                                                         p_Field_Value,
                                                          p_SQL_Upd,
                                                          p_Where,
                                                          p_ControlKey, p_Table,
                                                          p_UserName) = False Then
                            p_CompileControlHeader_PageToSQL = False
                            Exit Function
                        End If
                    Else
                        If InStr(UCase(p_Object_Tab.GetType.ToString), "XtraTabPage", CompareMethod.Text) > 0 Then
                            For Each p_Object_Tab_Item In p_Object_Tab.Controls
                                If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                                    If p_CompileControlHeader_PageToSQL(p_DataSet_TrueGird, p_Form,
                                                                 p_Object_Tab_Item,
                                                                   p_Table_Name,
                                                                   p_Insert_Type,
                                                                     p_Field_Ins,
                                                                     p_Field_Value,
                                                                      p_SQL_Upd,
                                                                      p_Where,
                                                          p_ControlKey, p_Table,
                                                          p_UserName) = False Then
                                        p_CompileControlHeader_PageToSQL = False
                                        Exit Function
                                    End If
                                Else
                                    If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_TrueDBGrid, CompareMethod.Text) > 0 Then
                                        If p_Object_Tab_Item.ObjectChild = True Then
                                            Try

                                                p_TrueDBGrid = p_Object_Tab_Item
                                                p_GridView = p_TrueDBGrid.Views(0)
                                                If p_CheckRequiredGridView(p_Form.Name,
                                                       p_TrueDBGrid.Name,
                                                     p_GridView,
                                                       p_DataSet_TrueGird) = False Then
                                                    p_CompileControlHeader_PageToSQL = Nothing
                                                    ' MsgBox(p_SQL)
                                                    Exit Function
                                                End If

                                                p_SQL = p_CompileTrueDBGirdLineToSQL(True, p_TrueDBGrid,
                                                                  p_GridView,
                                                                  p_ControlKey,
                                                                  p_Table,
                                                                  False, p_UserName)
                                                If p_SQL <> "TRUE" Then
                                                    p_CompileControlHeader_PageToSQL = False
                                                    MsgBox(p_SQL)
                                                    Exit Function
                                                End If
                                            Catch ex As Exception
                                                MsgBox("CompileControlHeaderToSQL: " & ex.Message)
                                                p_CompileControlHeader_PageToSQL = False
                                                Exit Function
                                            End Try
                                        End If
                                        Continue For
                                        'sdsf()

                                    End If
                                    If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                        Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                                        If UCase(p_Object_Tab_Item.TableName.ToString) = UCase(p_Table_Name) And Not p_Object_Tab_Item.EditValue Is Nothing Then
                                            p_FieldType = UCase(p_Object_Tab_Item.FieldType)

                                            p_ItemName = UCase(p_Object_Tab_Item.FieldName)
                                            'If p_ItemName = UCase("U_INV3RD") Then
                                            '    MsgBox("sdfsf")
                                            '    'Else
                                            '    '    Continue For
                                            'End If

                                            'If p_ItemName.Trim = "" Then Continue For
                                            p_FieldType = UCase(p_Object_Tab_Item.FieldType)
                                            p_KeyInsert = UCase(p_Object_Tab_Item.KeyInsert)

                                            If p_Insert_Type = True Then
                                                'INSERT
                                                '  If Not p_Object_Tab_Item.EditValue Is Nothing Then
                                                If p_Object_Tab_Item.EditValue.ToString <> "" Then
                                                    p_ItemName = UCase(p_Object_Tab_Item.FieldName)

                                                    p_Value = p_Object_Tab_Item.EditValue.ToString

                                                    If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                        If p_Object_Tab_Item.checked = False Then
                                                            p_Value = p_Object_Tab_Item.UnCheckValue.ToString.Trim
                                                            '   p_Value.Trim = p_Object_Tab_Item.CheckValue.ToString.Trim
                                                        Else
                                                            p_Value = p_Object_Tab_Item.CheckValue.ToString.Trim
                                                        End If
                                                        'If p_Value.Trim <> p_Object_Tab_Item.CheckValue.ToString.Trim Then
                                                        '    p_Value = p_Object_Tab_Item.UnCheckValue.ToString.Trim
                                                        'End If
                                                    End If

                                                    If p_KeyInsert = "N" And p_Object_Tab_Item.PrimaryKey = "Y" Then

                                                    Else
                                                        If p_FieldType = "D" Then
                                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                            p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                                        End If
                                                        If p_FieldType = "C" Then
                                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                            p_Field_Value = p_Field_Value & ",N'" & p_Value & "'"
                                                        End If
                                                        If p_FieldType = "N" Then 'Number
                                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                            p_Field_Value = p_Field_Value & "," & p_Value & ""
                                                        End If
                                                    End If
                                                End If
                                                'If
                                            Else
                                                'UPDATE
                                                p_ItemName = UCase(p_Object_Tab_Item.FieldName)
                                                'If p_ItemName = UCase("ID") Then
                                                '    MsgBox("dd")
                                                'End If
                                                p_FieldType = UCase(p_Object_Tab_Item.FieldType)
                                                If p_Object_Tab_Item.EditValue Is Nothing Then
                                                    p_Value = ""
                                                Else
                                                    p_Value = p_Object_Tab_Item.EditValue.ToString
                                                End If


                                                If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                    If p_Object_Tab_Item.checked = False Then
                                                        p_Value = p_Object_Tab_Item.UnCheckValue.ToString.Trim
                                                        '   p_Value.Trim = p_Object_Tab_Item.CheckValue.ToString.Trim
                                                    Else
                                                        p_Value = p_Object_Tab_Item.CheckValue.ToString.Trim
                                                    End If
                                                    'If p_Value.Trim <> p_Object_Tab_Item.CheckValue.ToString.Trim Then
                                                    '    p_Value = p_Object_Tab_Item.UnCheckValue.ToString.Trim
                                                    'End If
                                                End If


                                                If p_Object_Tab_Item.PrimaryKey = "Y" Then
                                                    If p_Object_Tab_Item.PrimaryKey = "Y" And p_FieldType = "C" Then
                                                        If p_Where = "" Then
                                                            p_Where = " " & p_ItemName & "=N'" & p_Value & "'"
                                                        Else
                                                            p_Where = p_Where & " AND " & p_ItemName & "=N'" & p_Value & "'"
                                                        End If
                                                    ElseIf p_Object_Tab_Item.PrimaryKey = "Y" And p_FieldType = "N" Then
                                                        If p_Where = "" Then
                                                            p_Where = " " & p_ItemName & "=" & p_Value
                                                        Else
                                                            p_Where = p_Where & " AND " & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                                        End If
                                                    End If
                                                Else
                                                    If p_Object_Tab_Item.NoUpdate.trim <> "Y" Then
                                                        If p_FieldType = "D" Then  'Ngay thang
                                                            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                                        End If
                                                        If p_FieldType = "C" Then
                                                            If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                                p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Object_Tab_Item.Checked = True, "'" & p_Object_Tab_Item.CheckValue & "'", "'" & p_Object_Tab_Item.CheckValue & "'")
                                                            Else
                                                                p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=N'" & p_Value & "'"
                                                            End If

                                                        End If
                                                        If p_FieldType = "N" Then
                                                            If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                                p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Object_Tab_Item.Checked = True, p_Object_Tab_Item.CheckValue, p_Object_Tab_Item.UnCheckValue)
                                                            Else
                                                                p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                        'Else

                                    End If
                                End If
                            Next
                        End If
                    End If
                    'Next

                Next
            Catch ex As Exception
                '  MsgBox("Err:" & p_Control_Ind)
                MsgBox(ex.Message)
                p_CompileControlHeader_PageToSQL = False
                Exit Function
            End Try
        End If

    End Function

    Private Sub FillValueItemCopyFrom(ByRef p_Form As Object)
        Dim p_Control As Object
        Dim p_ControlCopy As Object
        Dim p_ControlArr() As Control

        For Each p_Control In p_Form.Controls
            'If p_Control.Name.ToString.Trim = "DocNum" Then
            '    MsgBox("sdfssf")
            'End If
            If InStr(UCase(p_Control.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                Or InStr(UCase(p_Control.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Control.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Control.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Control.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Control.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                Try
                    If p_Control.CopyFromItem.ToString.Trim <> "" Then

                        'If p_Control.name = "U_ComCode" Then
                        '    MsgBox("sfsdfs")
                        'End If

                        ' p_ControlCopy = p_Form.Controls.Item(p_Control.CopyFromItem.ToString.Trim)
                        p_ControlArr = p_Form.Controls.find(p_Control.CopyFromItem.ToString.Trim, True)
                        If p_ControlArr.Length > 0 Then
                            p_ControlCopy = p_ControlArr(0)
                            If Not p_ControlCopy Is Nothing Then
                                If InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                    Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                             Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                             Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                             Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                             Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                                         Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                                    If Not p_ControlCopy.editvalue Is Nothing Then
                                        p_Control.EditValue = p_ControlCopy.editvalue
                                    Else
                                        p_Control.EditValue = DBNull.Value
                                    End If
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            If InStr(UCase(p_Control.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                FillValueItemCopyFromPage(p_Form, p_Control)

            End If
        Next
    End Sub


    Private Sub FillValueItemCopyFromPage(ByRef p_Form As Form, ByVal p_Object As Object)
        Dim p_Control As Object
        Dim p_ControlCopy As Object
        Dim p_ControlArr() As Control
        Dim p_Object_Tab As Object
        Dim p_TabControl_Ind As Integer
        Dim p_Object_Tab_Item As Object
        Try

            If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                For Each p_Control In p_Form.Controls
                    For p_TabControl_Ind = p_Object.TabPages.Count - 1 To 0 Step -1

                        p_Object.SelectedTabPageIndex = p_TabControl_Ind
                        p_Object_Tab = p_Object.TabPages(p_TabControl_Ind) ' Tab Control
                        If InStr(UCase(p_Object_Tab.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                            FillValueItemCopyFromPage(p_Form, p_Object_Tab)
                        Else
                            If InStr(UCase(p_Object_Tab.GetType.ToString), "XtraTabPage", CompareMethod.Text) > 0 Then
                                For Each p_Object_Tab_Item In p_Object_Tab.Controls
                                    If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                        Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                                 Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                                 Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                                 Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                                 Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                                             Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                                        ' Try
                                        'If p_Object_Tab_Item.name = "U_ComCode" Then
                                        '    MsgBox("sfsdfs")
                                        'End If
                                        If p_Object_Tab_Item.CopyFromItem.ToString.Trim <> "" Then
                                            ' p_ControlCopy = p_Form.Controls.Item(p_Object_Tab_Item.CopyFromItem.ToString.Trim)
                                            p_ControlArr = p_Form.Controls.Find(p_Object_Tab_Item.CopyFromItem.ToString.Trim, True)
                                            If p_ControlArr.Length > 0 Then
                                                p_ControlCopy = p_ControlArr(0)
                                                If Not p_ControlCopy Is Nothing Then
                                                    If InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                                        Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                                                 Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                                                 Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                                                 Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                                                 Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                                                             Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                                                        If Not p_ControlCopy.editvalue Is Nothing Then
                                                            p_Object_Tab_Item.EditValue = p_ControlCopy.editvalue
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                    'vdfss()
                                Next

                            Else
                                If p_Object_Tab.CopyFromItem.ToString.Trim <> "" Then
                                    ' p_ControlCopy = p_Form.Controls.Item(p_Object_Tab_Item.CopyFromItem.ToString.Trim)
                                    p_ControlArr = p_Form.Controls.Find(p_Object_Tab.CopyFromItem.ToString.Trim, True)
                                    If p_ControlArr.Length > 0 Then
                                        p_ControlCopy = p_ControlArr(0)
                                        If Not p_ControlCopy Is Nothing Then
                                            If InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                                Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                                         Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                                         Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                                         Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                                         Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                                                     Or InStr(UCase(p_ControlCopy.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                                                If Not p_ControlCopy.editvalue Is Nothing Then
                                                    p_Object_Tab.EditValue = p_ControlCopy.editvalue
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next

            End If

        Catch ex As Exception

        End Try
    End Sub

    'anhqh
    '21/04/2014
    'fxfdssf
    Private Function p_TrueDBGirdToSQL(ByVal p_DataSet_TrueGird As DataSet, _
                                  ByRef p_Form As Object, _
                                  ByVal p_RecordHist As Boolean, _
                                  ByRef p_DataTable As DataTable, _
                                   ByVal p_GetB1 As Boolean, _
                                   Optional ByVal p_ColumnCHECKUPDate As String = "", _
                                           Optional ByVal p_UserName As String = "") As String
        Dim p_TrueDBGrid As U_TextBox.U_TrueDBGrid = Nothing
        Dim p_GirdView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim p_Object() As Object
        Dim p_TrueGridName As String = ""
        Dim p_DataTableGrid As DataTable
        Dim p_Count As Integer
        Dim p_Desc As String = ""
        Dim p_Module As String
        'Dim avvv As Object
        'avvv = p_Form
        Try

            p_TrueDBGirdToSQL = "TRUE"
            p_Module = UCase(p_Form.GetType.Module.Name)
            If InStr(p_Module, ".", CompareMethod.Text) > 0 Then
                p_Module = Left(p_Module, InStr(p_Module, ".", CompareMethod.Text) - 1)
            End If

            p_DataTableGrid = g_Service.Sys_SYS_GET_DATATABLE_Des("select  Distinct GRID_NAME  from GRID_PROPERTY Where MODULE ='" & p_Module & "' and FORM_NAME ='" & p_Form.Name & "'", p_Desc)
            If p_Desc <> "" Then
                p_TrueDBGirdToSQL = p_Desc
                Exit Function
            End If
            If Not p_DataTableGrid Is Nothing Then
                For p_Count = 0 To p_DataTableGrid.Rows.Count - 1
                    p_TrueGridName = p_DataTableGrid.Rows(p_Count).Item("GRID_NAME").ToString.Trim
                    p_Object = p_Form.Controls.Find(p_TrueGridName, True)
                    If p_Object.Length > 0 Then
                        p_TrueDBGrid = CType(p_Object(0), U_TextBox.U_TrueDBGrid)
                        If p_TrueDBGrid.ObjectChild = False Then
                            p_GirdView = p_TrueDBGrid.Views(0)

                            p_Desc = p_CompileTrueDBGirdToSQL(p_DataSet_TrueGird, p_Form, p_RecordHist, p_TrueDBGrid,
                                                  p_GirdView,
                                                  p_DataTable,
                                                  p_GetB1,
                                                  "CHECKUPD", g_UserName)

                            If p_Desc <> "TRUE" Then
                                ' MsgBox(p_SQL)
                                p_TrueDBGirdToSQL = p_Desc
                                Exit Function
                            End If

                        End If
                    End If

                Next
            End If

        Catch ex As Exception
            p_TrueDBGirdToSQL = "FALSE"
        End Try
    End Function

    'p_SQL = p_FptMod.p_ModCompileTrueDBGirdToSQL(p_DataSet_TrueGird, Me, True, Me.U_TrueDBGrid1,
    '                                      Me.GridView1,
    '                                      p_DataTable,
    '                                      False,
    '                                      "CHECKUPD", g_UserName)

    'ANHQH
    '26/06/2014
    'Ham thuc hien tao cau lenh SQL tu cac control tren form
    Public Function p_CompileControlHeaderToSQL(ByVal p_DataSet_TrueGird As DataSet, _
                                                ByVal p_RecordHist As Boolean, _
                                                ByRef p_Form As Form, _
                                        ByVal p_Table_Name As String, _
                                        ByRef p_ControlKey As Object, _
                                        ByVal p_AutoKeyName As String, _
                                        Optional ByRef p_ControlKey1 As Object = Nothing, _
                                        Optional ByVal p_AutoKeyName1 As String = "", _
                                        Optional ByVal p_UserName As String = "") As DataTable

        Dim p_Insert_Type As Boolean
        Dim p_Object As Object
        Dim p_Object_Item As Object
        Dim p_Object_Tab_Item As Object
        Dim p_SQL_Upd As String = ""
        Dim p_ItemName As String
        Dim p_Count As Integer
        Dim p_TabControl_Ind As Integer
        Dim p_Control_Ind As Integer
        Dim p_CountObj As Integer
        Dim p_Field_Ins As String = ""
        Dim p_Field_Value As String = ""
        Dim p_Where As String = ""
        ' Dim p_SQL_Upd As String = ""
        Dim p_NoUpdate As String = ""
        Dim p_KeyInsert As String
        Dim p_Err As String
        'Dim p_DataUpd As New DataSet
        Dim p_Table As New DataTable("Table01")
        Dim p_Col As New DataColumn
        Dim p_Row As DataRow
        Dim p_RowArr() As DataRow
        'Dim p_System As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        Dim p_FieldType As String
        Dim p_Value As String
        Dim p_SQL As String
        Dim p_Dt As DataTable

        Dim p_Des As String = ""
        Dim p_DataTableCheck As DataTable
        Dim p_DocEntry11 As Double

        Dim p_DateValue As Date
        Dim p_TimeValue As Integer
        Dim p_TrueDBGrid As U_TextBox.U_TrueDBGrid
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView

        'Dim p_ItemCopyFrom As New DataTable("Table001")
        'Dim p_Col1 As DataColumn
        'Dim p_RowItemCopyFrom As DataRow
        'p_Col1 = New DataColumn("Item")
        'p_Col1.DataType = GetType(String)
        'p_ItemCopyFrom.Columns.Add(p_Col1)

        'p_Col1 = New DataColumn("ItemCopy")
        'p_Col1.DataType = GetType(String)
        'p_ItemCopyFrom.Columns.Add(p_Col1)

        If p_Check_Control_Required(p_Form, p_Des) = False Then
            p_CompileControlHeaderToSQL = Nothing
            MsgBox(p_Des)
            Exit Function
        End If

        p_Col.ColumnName = "SQL_STR"
        p_Col.DataType = GetType(String)
        p_Col.MaxLength = 4000
        p_Table.Columns.Add(p_Col)


        If Not p_ControlKey Is Nothing Then
            p_ItemName = UCase(p_ControlKey.FieldName)
            p_FieldType = UCase(p_ControlKey.FieldType)

            If p_ControlKey.EditValue Is Nothing Then
                p_Value = ""
            Else
                p_Value = p_ControlKey.EditValue.ToString
            End If
            'If p_Value = "" Then
            '    p_CompileControlHeaderToSQL = Nothing
            '    MsgBox("Giá trị Key không hợp lệ")
            '    Exit Function
            'End If



            If p_FieldType <> "N" And p_FieldType <> "C" Then
                p_CompileControlHeaderToSQL = Nothing
                MsgBox("FieldKeyType không hợp lệ")
                Exit Function
            End If
            If p_Value.Trim <> "" Then
                If p_FieldType = "N" Then
                    p_SQL = "Select 1 from " & p_Table_Name & " With (Nolock) Where " & p_ItemName & "=" & p_Value
                Else
                    p_SQL = "Select 1 from " & p_Table_Name & " With (Nolock) Where " & p_ItemName & "='" & p_Value & "'"
                End If
                p_DataTableCheck = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Des)
                If p_Des <> "" Then
                    p_CompileControlHeaderToSQL = Nothing
                    MsgBox(p_Des)
                    Exit Function
                End If
            End If

            If p_DataTableCheck Is Nothing Then
                p_Insert_Type = True
            Else
                If p_DataTableCheck.Rows.Count > 0 Then
                    p_Insert_Type = False
                Else
                    p_Insert_Type = True
                End If
            End If
            If p_RecordHist = True Then
                p_Dt = g_Service.mod_SYS_GET_DATATABLE("exec  FPT_CheckFieldHist '" & p_Table_Name & "'")
            End If
            If p_Insert_Type = True Then
                'Lay Key cho truong DocEntry neu chua co
                If Not p_AutoKeyName Is Nothing Then
                    If p_AutoKeyName.Trim <> "" Then
                        If Not p_ControlKey.EditValue Is Nothing Then
                            If p_ControlKey.EditValue.ToString.Trim = "" Then
                                p_DocEntry11 = g_Service.SysGetPrimary(p_AutoKeyName.Trim)
                                p_ControlKey.EditValue = p_DocEntry11
                            ElseIf p_ControlKey.EditValue = 0 Then
                                p_DocEntry11 = g_Service.SysGetPrimary(p_AutoKeyName.Trim)
                                p_ControlKey.EditValue = p_DocEntry11
                            End If
                        Else
                            'If Me.DocEntry.EditValue = 0 Then
                            p_DocEntry11 = g_Service.SysGetPrimary(p_AutoKeyName.Trim)
                            p_ControlKey.EditValue = p_DocEntry11
                            '
                        End If

                        If p_ControlKey.EditValue <= 0 Then
                            MsgBox("Không xác định được key")
                            p_CompileControlHeaderToSQL = Nothing
                            Exit Function
                        End If

                        If p_AutoKeyName.Trim = p_AutoKeyName1.Trim Then
                            If Not p_ControlKey1 Is Nothing Then
                                p_ControlKey1.EditValue = p_ControlKey.editvalue
                            End If
                        ElseIf p_AutoKeyName1.Trim <> "" Then
                            Try
                                p_DocEntry11 = g_Service.SysGetPrimary(p_AutoKeyName1.Trim)
                                p_ControlKey1.EditValue = p_DocEntry11
                            Catch ex As Exception

                            End Try

                        End If
                    End If


                End If
            End If
            p_Des = ""


            'p_CompileControlHeaderToSQL = True
            p_CountObj = 0

            Try
                FillValueItemCopyFrom(p_Form)



                For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                    p_Object = p_Form.Controls.Item(p_Control_Ind)
                    'If p_Object.name = "U_CrdGrp" Then
                    '    MsgBox("dfsds")
                    'End If
                    If InStr(UCase(p_Object.GetType.ToString), pv_Type_TrueDBGrid, CompareMethod.Text) > 0 Then
                        If p_Object.ObjectChild = True Then
                            Try
                                p_TrueDBGrid = p_Object
                                p_GridView = p_TrueDBGrid.Views(0)

                                'Check dữ liệu bắt buộc nhập
                                If p_CheckRequiredGridView(p_Form.Name,
                                                            p_TrueDBGrid.Name,
                                                          p_GridView,
                                                            p_DataSet_TrueGird) = False Then
                                    p_CompileControlHeaderToSQL = Nothing
                                    ' MsgBox(p_SQL)
                                    Exit Function
                                End If
                                p_SQL = p_CompileTrueDBGirdLineToSQL(True, p_TrueDBGrid,
                                                  p_GridView,
                                                  p_ControlKey,
                                                  p_Table,
                                                  False, g_UserName)
                                If p_SQL <> "TRUE" Then
                                    p_CompileControlHeaderToSQL = Nothing
                                    MsgBox(p_SQL)
                                    Exit Function
                                End If
                            Catch ex As Exception
                                MsgBox("CompileControlHeaderToSQL: " & ex.Message)
                                p_CompileControlHeaderToSQL = Nothing
                                Exit Function
                            End Try
                        End If
                        Continue For
                        'sdsf()

                    End If


                    'If p_Object.Name = "U_SlpTmp" Then
                    '    MsgBox("dfggdg")
                    'End If
                    If InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                        Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                             Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then

                        If UCase(p_Object.TableName) = UCase(p_Table_Name) And Not p_Object.EditValue Is Nothing And p_Object.FieldName.trim <> "" Then

                            If p_Insert_Type = True Then

                                If p_Object.EditValue.ToString <> "" Then
                                    'INSERT
                                    p_ItemName = UCase(p_Object.FieldName)

                                    'If p_ItemName.Trim = "" Then Continue For
                                    p_FieldType = UCase(p_Object.FieldType)
                                    p_KeyInsert = UCase(p_Object.KeyInsert)
                                    If p_Object.EditValue Is Nothing Then
                                        p_Value = ""
                                    Else
                                        p_Value = p_Object.EditValue.ToString
                                    End If
                                    'If InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                    '    If p_Value.Trim <> p_Object.CheckValue.ToString.Trim Then
                                    '        p_Value = p_Object.UnCheckValue.ToString.Trim
                                    '    End If
                                    'End If

                                    If InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                        If p_Object.checked = False Then
                                            p_Value = p_Object.UnCheckValue.ToString.Trim
                                            '   p_Value.Trim = p_Object_Tab_Item.CheckValue.ToString.Trim
                                        Else
                                            p_Value = p_Object.CheckValue.ToString.Trim
                                        End If
                                        'If p_Value.Trim <> p_Object_Tab_Item.CheckValue.ToString.Trim Then
                                        '    p_Value = p_Object_Tab_Item.UnCheckValue.ToString.Trim
                                        'End If
                                    End If


                                    'If p_Check_Item(p_ItemName, p_KeyInsert) = True Then
                                    If p_KeyInsert = "N" And p_Object.PrimaryKey = "Y" Then

                                    Else
                                        'If p_Check_Item(p_ItemName, p_Object.NoUpdate) = True Then
                                        If p_FieldType = "D" Then  'Ngay thang

                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                            p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")

                                        End If

                                        If p_FieldType = "C" And p_KeyInsert <> "N" Then 'Text
                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                            p_Field_Value = p_Field_Value & ",N'" & p_Value & "'"
                                        End If
                                        If p_FieldType = "N" And p_KeyInsert <> "N" Then 'Number
                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                            p_Field_Value = p_Field_Value & "," & p_Value & ""
                                        End If
                                    End If
                                End If
                            Else
                                'UPDATE
                                p_ItemName = UCase(p_Object.FieldName)
                                p_FieldType = UCase(p_Object.FieldType)
                                'If UCase(p_ItemName) = "DOCENTRY" Then
                                '    MsgBox("GG")
                                'End If
                                If p_Object.EditValue Is Nothing Then
                                    p_Value = ""
                                Else
                                    p_Value = p_Object.EditValue.ToString
                                End If
                                p_NoUpdate = p_Object.NoUpdate

                                If p_Object.PrimaryKey = "Y" Then
                                    If p_Object.PrimaryKey = "Y" And p_FieldType = "C" Then
                                        If p_Where = "" Then
                                            p_Where = " " & p_ItemName & "=N'" & p_Value & "'"
                                        Else
                                            p_Where = p_Where & " AND " & p_ItemName & "=N'" & p_Value & "'"
                                        End If
                                    ElseIf p_Object.PrimaryKey = "Y" And p_FieldType = "N" Then
                                        If p_Where = "" Then
                                            p_Where = " " & p_ItemName & "=" & p_Value
                                        Else
                                            p_Where = p_Where & " AND " & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                        End If
                                    End If
                                Else
                                    If p_NoUpdate.Trim <> "Y" Then
                                        If p_FieldType = "D" Then  'Ngay thang

                                            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Convert_Date(p_Value) = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                        End If

                                        If p_FieldType = "C" Then 'Text
                                            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=N'" & p_Value & "'"
                                        End If
                                        If p_FieldType = "N" Then 'Number
                                            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                        If p_CompileControlHeader_PageToSQL(p_DataSet_TrueGird, p_Form,
                                                         p_Object,
                                                           p_Table_Name,
                                                           p_Insert_Type,
                                                             p_Field_Ins,
                                                             p_Field_Value,
                                                              p_SQL_Upd,
                                                              p_Where,
                                                              p_ControlKey,
                                                              p_Table,
                                                              p_UserName) = False Then
                            p_CompileControlHeaderToSQL = Nothing
                            Exit Function
                        End If
                    End If

                    'End If
                Next
                If p_Insert_Type = True Then
                    If p_Field_Ins <> "" Then
                        p_Field_Ins = Mid(Trim(p_Field_Ins), 2)
                        p_Field_Value = Mid(Trim(p_Field_Value), 2)
                        If p_RecordHist = True And Not p_Dt Is Nothing Then
                            p_RowArr = p_Dt.Select("ColumnName='CREATEDATE' or ColumnName='CREATETIME' Or ColumnName='CREATEDBY'")

                            p_GetDateTime(p_DateValue, p_TimeValue)
                            For p_Count = 0 To p_RowArr.Length - 1
                                If p_RowArr(p_Count).Item(1) = 40 Or p_RowArr(p_Count).Item(1) = 61 Then  'Date
                                    p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(0)
                                    p_Field_Value = p_Field_Value & ",'" & p_DateValue.ToString("yyyyMMdd") & "'"
                                End If

                                If p_RowArr(p_Count).Item(1) = 52 Or p_RowArr(p_Count).Item(1) = 56 Then  'Time
                                    p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(0)
                                    p_Field_Value = p_Field_Value & "," & p_TimeValue
                                End If

                                If p_RowArr(p_Count).Item(1) = 231 Or p_RowArr(p_Count).Item(1) = 175 Then  'CreatedBy
                                    p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(0)
                                    p_Field_Value = p_Field_Value & ",'" & p_UserName & "'"
                                End If


                            Next
                        End If
                        p_SQL_Upd = "INSERT INTO " & p_Table_Name & "(" & p_Field_Ins & ")  VALUES (" & p_Field_Value & ")"
                        If p_SQL_Upd <> "" Then
                            p_Row = p_Table.Rows.Add
                            p_Row(0) = p_SQL_Upd
                            p_CompileControlHeaderToSQL = p_Table
                            'p_DataUpd.Tables.Add(p_Table)
                            'If B1Get = True Then
                            '    p_CompileControlHeaderToSQL = g_Service.SysExecuteDataSet_Company(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_DataUpd)
                            'Else
                            '    p_CompileControlHeaderToSQL = g_Service.SysExecuteDataSet(p_DataUpd, p_Err)
                            'End If
                        End If
                    End If
                Else
                    If p_SQL_Upd <> "" Then
                        p_SQL_Upd = Mid(Trim(p_SQL_Upd), 2)
                        If p_RecordHist = True And Not p_Dt Is Nothing Then

                            p_RowArr = p_Dt.Select("ColumnName='UPDATEDATE' or ColumnName='UPDATETIME' Or ColumnName='UPDATEBY'")

                            p_GetDateTime(p_DateValue, p_TimeValue)
                            For p_Count = 0 To p_RowArr.Length - 1
                                If p_RowArr(p_Count).Item(1) = 40 Or p_RowArr(p_Count).Item(1) = 61 Then  'Date
                                    'p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(1)
                                    'p_Field_Value = p_Field_Value & ",'" & p_DateValue.ToString("yyyyMMdd") & "'"

                                    p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count).Item(0) & "='" & p_DateValue.ToString("yyyyMMdd") & "'"
                                End If

                                If p_RowArr(p_Count).Item(1) = 52 Or p_RowArr(p_Count).Item(1) = 56 Then  'Time
                                    'p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(1)
                                    'p_Field_Value = p_Field_Value & "," & p_TimeValue

                                    p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count).Item(0) & "=" & p_TimeValue
                                End If

                                If p_RowArr(p_Count).Item(1) = 231 Or p_RowArr(p_Count).Item(1) = 175 Then  'CreatedBy
                                    'p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(1)
                                    'p_Field_Value = p_Field_Value & ",'" & g_UserName & "'"

                                    p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count).Item(0) & "='" & p_UserName & "'"
                                End If
                            Next
                        End If
                        p_SQL_Upd = "UPDATE " & p_Table_Name & " SET " & p_SQL_Upd
                        If p_Where <> "" Then
                            p_SQL_Upd = p_SQL_Upd & " WHERE " & p_Where
                        Else
                            p_Err = "Không xác định điều kiện where khi cập nhật"
                            p_CompileControlHeaderToSQL = Nothing
                            GoTo line_KT
                        End If
                        p_Row = p_Table.Rows.Add
                        p_Row(0) = p_SQL_Upd
                        p_CompileControlHeaderToSQL = p_Table
                        'p_DataUpd.Tables.Add(p_Table)
                        'If B1Get = True Then
                        '    p_CompileControlHeaderToSQL = g_Service.SysExecuteDataSet_Company(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_DataUpd)
                        'Else
                        '    p_CompileControlHeaderToSQL = g_Service.SysExecuteDataSet(p_DataUpd, p_Err)
                        'End If
                    End If
                End If
line_KT:
                If p_CompileControlHeaderToSQL Is Nothing Then
                    MsgBox(p_Err)
                End If
                ' p_System = Nothing
            Catch ex As Exception

                p_CompileControlHeaderToSQL = Nothing
                MsgBox(ex.Message)
            End Try

        End If
        p_Err = "TRUE"
        p_Err = p_TrueDBGirdToSQL(p_DataSet_TrueGird,
                             p_Form,
                              p_RecordHist,
                              p_Table,
                               False,
                               "CHECKUPD", _
                                      p_UserName)
        If p_Err <> "TRUE" Then
            p_CompileControlHeaderToSQL = Nothing
            MsgBox("TrueDBGirdToSQL:" & p_Err)
            Exit Function
        End If
        p_CompileControlHeaderToSQL = p_Table
    End Function


    'ANHQH
    '26/06/2014
    'Ham thuc hien tao cau lenh SQL tu cac control tren form
    Public Function p_CompileControlHeaderToSQL_BackUp(ByVal p_RecordHist As Boolean, _
                                                ByRef p_Form As Form, _
                                        ByVal p_Table_Name As String, _
                                        ByRef p_ControlKey As Object, _
                                        ByVal p_AutoKeyName As String, _
                                        Optional ByRef p_ControlKey1 As Object = Nothing, _
                                        Optional ByVal p_AutoKeyName1 As String = "", _
                                        Optional ByVal p_UserName As String = "") As DataTable

        Dim p_Insert_Type As Boolean
        Dim p_Object As Object
        Dim p_Object_Item As Object
        Dim p_Object_Tab_Item As Object
        Dim p_SQL_Upd As String = ""
        Dim p_ItemName As String
        Dim p_Count As Integer
        Dim p_TabControl_Ind As Integer
        Dim p_Control_Ind As Integer
        Dim p_CountObj As Integer
        Dim p_Field_Ins As String = ""
        Dim p_Field_Value As String = ""
        Dim p_Where As String = ""
        ' Dim p_SQL_Upd As String = ""
        Dim p_NoUpdate As String = ""
        Dim p_KeyInsert As String
        Dim p_Err As String
        'Dim p_DataUpd As New DataSet
        Dim p_Table As New DataTable("Table01")
        Dim p_Col As New DataColumn
        Dim p_Row As DataRow
        Dim p_RowArr() As DataRow
        'Dim p_System As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        Dim p_FieldType As String
        Dim p_Value As String
        Dim p_SQL As String
        Dim p_Dt As DataTable

        Dim p_Des As String = ""
        Dim p_DataTableCheck As DataTable
        Dim p_DocEntry11 As Double

        Dim p_DateValue As Date
        Dim p_TimeValue As Integer

        p_ItemName = UCase(p_ControlKey.FieldName)
        p_FieldType = UCase(p_ControlKey.FieldType)

        If p_ControlKey.EditValue Is Nothing Then
            p_Value = ""
        Else
            p_Value = p_ControlKey.EditValue.ToString
        End If
        'If p_Value = "" Then
        '    p_CompileControlHeaderToSQL_BackUp = Nothing
        '    MsgBox("Giá trị Key không hợp lệ")
        '    Exit Function
        'End If

        If p_FieldType <> "N" And p_FieldType <> "C" Then
            p_CompileControlHeaderToSQL_BackUp = Nothing
            MsgBox("FieldKeyType không hợp lệ")
            Exit Function
        End If
        If p_Value.Trim <> "" Then
            If p_FieldType = "N" Then
                p_SQL = "Select 1 from " & p_Table_Name & " With (Nolock) Where " & p_ItemName & "=" & p_Value
            Else
                p_SQL = "Select 1 from " & p_Table_Name & " With (Nolock) Where " & p_ItemName & "='" & p_Value & "'"
            End If
            p_DataTableCheck = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Des)
            If p_Des <> "" Then
                p_CompileControlHeaderToSQL_BackUp = Nothing
                MsgBox(p_Des)
                Exit Function
            End If
        End If

        If p_DataTableCheck Is Nothing Then
            p_Insert_Type = True
        Else
            If p_DataTableCheck.Rows.Count > 0 Then
                p_Insert_Type = False
            Else
                p_Insert_Type = True
            End If
        End If
        If p_RecordHist = True Then
            p_Dt = g_Service.mod_SYS_GET_DATATABLE("exec  FPT_CheckFieldHist '" & p_Table_Name & "'")
        End If
        If p_Insert_Type = True Then
            'Lay Key cho truong DocEntry neu chua co
            If p_AutoKeyName.Trim <> "" Then
                If Not p_ControlKey Is Nothing Then
                    If p_ControlKey.EditValue.ToString.Trim = "" Then
                        p_DocEntry11 = g_Service.SysGetPrimary(p_AutoKeyName.Trim)
                        p_ControlKey.EditValue = p_DocEntry11
                    ElseIf p_ControlKey.EditValue = 0 Then
                        p_DocEntry11 = g_Service.SysGetPrimary(p_AutoKeyName.Trim)
                        p_ControlKey.EditValue = p_DocEntry11
                    End If
                Else
                    'If Me.DocEntry.EditValue = 0 Then
                    p_DocEntry11 = g_Service.SysGetPrimary(p_AutoKeyName.Trim)
                    p_ControlKey.EditValue = p_DocEntry11
                    '
                End If

                If p_ControlKey.EditValue <= 0 Then
                    MsgBox("Không xác định được key")
                    p_CompileControlHeaderToSQL_BackUp = Nothing
                    Exit Function
                End If

                If p_AutoKeyName.Trim = p_AutoKeyName1.Trim Then
                    If Not p_ControlKey1 Is Nothing Then
                        p_ControlKey1.EditValue = p_ControlKey.editvalue
                    End If
                ElseIf p_AutoKeyName1.Trim <> "" Then
                    Try
                        p_DocEntry11 = g_Service.SysGetPrimary(p_AutoKeyName1.Trim)
                        p_ControlKey1.EditValue = p_DocEntry11
                    Catch ex As Exception

                    End Try

                End If
            End If


        End If
        p_Des = ""

        p_Col.ColumnName = "SQL_STR"
        p_Col.MaxLength = 4000
        p_Table.Columns.Add(p_Col)

        'p_CompileControlHeaderToSQL_BackUp = True
        p_CountObj = 0

        Try
            If p_Check_Control_Required(p_Form, p_Des) = False Then
                p_CompileControlHeaderToSQL_BackUp = Nothing
                MsgBox(p_Des)
                Exit Function
            End If

            For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                p_Object = p_Form.Controls.Item(p_Control_Ind)


                'If p_Object.Name = "U_SlpTmp" Then
                '    MsgBox("dfggdg")
                'End If
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                    Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then

                    If UCase(p_Object.TableName) = UCase(p_Table_Name) And Not p_Object.EditValue Is Nothing And p_Object.FieldName.trim <> "" Then

                        If p_Insert_Type = True Then

                            If p_Object.EditValue.ToString <> "" Then
                                'INSERT
                                p_ItemName = UCase(p_Object.FieldName)

                                'If p_ItemName.Trim = "" Then Continue For
                                p_FieldType = UCase(p_Object.FieldType)
                                p_KeyInsert = UCase(p_Object.KeyInsert)
                                If p_Object.EditValue Is Nothing Then
                                    p_Value = ""
                                Else
                                    p_Value = p_Object.EditValue.ToString
                                End If
                                If InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                    If p_Value.Trim <> p_Object.CheckValue.ToString.Trim Then
                                        p_Value = p_Object.UnCheckValue.ToString.Trim
                                    End If
                                End If
                                'If p_Check_Item(p_ItemName, p_KeyInsert) = True Then
                                If p_KeyInsert = "N" And p_Object.PrimaryKey = "Y" Then

                                Else
                                    'If p_Check_Item(p_ItemName, p_Object.NoUpdate) = True Then
                                    If p_FieldType = "D" Then  'Ngay thang

                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                        p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")

                                    End If

                                    If p_FieldType = "C" And p_KeyInsert <> "N" Then 'Text
                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                        p_Field_Value = p_Field_Value & ",N'" & p_Value & "'"
                                    End If
                                    If p_FieldType = "N" And p_KeyInsert <> "N" Then 'Number
                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                        p_Field_Value = p_Field_Value & "," & p_Value & ""
                                    End If
                                End If
                            End If
                        Else
                            'UPDATE
                            p_ItemName = UCase(p_Object.FieldName)
                            p_FieldType = UCase(p_Object.FieldType)
                            'If UCase(p_ItemName) = "DOCENTRY" Then
                            '    MsgBox("GG")
                            'End If
                            If p_Object.EditValue Is Nothing Then
                                p_Value = ""
                            Else
                                p_Value = p_Object.EditValue.ToString
                            End If
                            p_NoUpdate = p_Object.NoUpdate
                            'If p_Check_Item(p_ItemName, p_NoUpdate) = True Then
                            '    If p_FieldType = "D" Then  'Ngay thang

                            '        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Convert_Date(p_Value) = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                            '    End If

                            '    If p_FieldType = "C" Then 'Text
                            '        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=N'" & p_Value & "'"
                            '    End If
                            '    If p_FieldType = "N" Then 'Number
                            '        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                            '    End If
                            'Else
                            If p_Object.PrimaryKey = "Y" Then
                                If p_Object.PrimaryKey = "Y" And p_FieldType = "C" Then
                                    If p_Where = "" Then
                                        p_Where = " " & p_ItemName & "=N'" & p_Value & "'"
                                    Else
                                        p_Where = p_Where & " AND " & p_ItemName & "=N'" & p_Value & "'"
                                    End If
                                ElseIf p_Object.PrimaryKey = "Y" And p_FieldType = "N" Then
                                    If p_Where = "" Then
                                        p_Where = " " & p_ItemName & "=" & p_Value
                                    Else
                                        p_Where = p_Where & " AND " & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                    End If
                                End If
                            Else
                                If p_NoUpdate.Trim <> "Y" Then
                                    If p_FieldType = "D" Then  'Ngay thang

                                        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Convert_Date(p_Value) = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                    End If

                                    If p_FieldType = "C" Then 'Text
                                        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=N'" & p_Value & "'"
                                    End If
                                    If p_FieldType = "N" Then 'Number
                                        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
                'Xu ly cho cac item tabpage
                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    Try
                        For p_TabControl_Ind = 0 To p_Object.TabPages.Count - 1
                            p_Object_Item = p_Object.TabPages(p_TabControl_Ind)
                            For p_Count = 0 To p_Object_Item.Controls.Count - 1
                                p_Object_Tab_Item = p_Object_Item.Controls(p_Count)
                                If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                    Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                                 Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                                    If UCase(p_Object_Tab_Item.TableName.ToString) = UCase(p_Table_Name) And Not p_Object_Tab_Item.EditValue Is Nothing Then
                                        p_FieldType = UCase(p_Object_Tab_Item.FieldType)

                                        If p_Insert_Type = True Then
                                            'INSERT
                                            If p_Object_Tab_Item.EditValue Is Nothing Then
                                                If p_Object_Tab_Item.Value.ToString <> "" Then
                                                    p_ItemName = UCase(p_Object_Tab_Item.FieldName)
                                                    'If p_Object_Tab_Item.EditValue Is Nothing Then
                                                    '    p_Value = ""
                                                    'Else
                                                    p_Value = p_Object_Tab_Item.EditValue.ToString
                                                    'End If
                                                    'If p_Check_Item(p_ItemName, p_Object_Tab_Item.NoUpdate) = True Then
                                                    'If p_Object_Tab_Item.NoUpdate.ToString.Trim <> "Y" Then
                                                    If p_KeyInsert = "N" And p_Object.PrimaryKey = "Y" Then

                                                    Else
                                                        If p_FieldType = "D" Then
                                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                            p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                                        End If
                                                        If p_FieldType = "C" Then
                                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                            p_Field_Value = p_Field_Value & ",N'" & p_Value & "'"
                                                        End If
                                                        If p_FieldType = "N" Then 'Number
                                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                            p_Field_Value = p_Field_Value & "," & p_Value & ""
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Else
                                            'UPDATE
                                            p_ItemName = UCase(p_Object_Tab_Item.FieldName)
                                            'If p_ItemName = UCase("ID") Then
                                            '    MsgBox("dd")
                                            'End If
                                            p_FieldType = UCase(p_Object_Tab_Item.FieldType)
                                            If p_Object_Tab_Item.EditValue Is Nothing Then
                                                p_Value = ""
                                            Else
                                                p_Value = p_Object_Tab_Item.EditValue.ToString
                                            End If
                                            'If p_Check_Item(p_ItemName, p_Object_Tab_Item.NoUpdate) = True Then
                                            '    If p_FieldType = "D" Then  'Ngay thang
                                            '        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                            '    End If
                                            '    If p_FieldType = "C" Then
                                            '        If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                            '            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Object_Tab_Item.Checked = True, "'" & p_Object_Tab_Item.CheckValue & "'", "'" & p_Object_Tab_Item.CheckValue & "'")
                                            '        Else
                                            '            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=N'" & p_Value & "'"
                                            '        End If

                                            '    End If
                                            '    If p_FieldType = "N" Then
                                            '        If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                            '            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Object_Tab_Item.Checked = True, p_Object_Tab_Item.CheckValue, p_Object_Tab_Item.UnCheckValue)
                                            '        Else
                                            '            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                            '        End If
                                            '    End If
                                            'Else
                                            If p_Object_Tab_Item.PrimaryKey = "Y" Then
                                                If p_Object_Tab_Item.PrimaryKey = "Y" And p_FieldType = "C" Then
                                                    If p_Where = "" Then
                                                        p_Where = " " & p_ItemName & "=N'" & p_Value & "'"
                                                    Else
                                                        p_Where = p_Where & " AND " & p_ItemName & "=N'" & p_Value & "'"
                                                    End If
                                                ElseIf p_Object_Tab_Item.PrimaryKey = "Y" And p_FieldType = "N" Then
                                                    If p_Where = "" Then
                                                        p_Where = " " & p_ItemName & "=" & p_Value
                                                    Else
                                                        p_Where = p_Where & " AND " & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                                    End If
                                                End If
                                            Else
                                                If p_Object_Tab_Item.NoUpdate.trim <> "Y" Then
                                                    If p_FieldType = "D" Then  'Ngay thang
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                                    End If
                                                    If p_FieldType = "C" Then
                                                        If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Object_Tab_Item.Checked = True, "'" & p_Object_Tab_Item.CheckValue & "'", "'" & p_Object_Tab_Item.CheckValue & "'")
                                                        Else
                                                            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=N'" & p_Value & "'"
                                                        End If

                                                    End If
                                                    If p_FieldType = "N" Then
                                                        If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Object_Tab_Item.Checked = True, p_Object_Tab_Item.CheckValue, p_Object_Tab_Item.UnCheckValue)
                                                        Else
                                                            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                Else
                                    '===========
                                    'If p_Object_Tab_Item.PrimaryKey = "Y" And p_FieldType = "C" Then
                                    '    If p_Where = "" Then
                                    '        p_Where = " " & p_ItemName & "=N'" & p_Value & "'"
                                    '    Else
                                    '        p_Where = p_Where & " AND " & p_ItemName & "=N'" & p_Value & "'"
                                    '    End If
                                    'End If
                                    'If p_Object_Tab_Item.PrimaryKey = "Y" And p_FieldType = "N" Then
                                    '    If p_Where = "" Then
                                    '        p_Where = " " & p_ItemName & "=" & p_Value
                                    '    Else
                                    '        p_Where = p_Where & " AND " & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                    '    End If
                                    'End If
                                End If
                            Next

                        Next
                    Catch ex As Exception
                        '  MsgBox("Err:" & p_Control_Ind)
                        MsgBox(ex.Message)
                        p_CompileControlHeaderToSQL_BackUp = Nothing
                        Exit Function
                    End Try
                End If
                'End If
            Next
            If p_Insert_Type = True Then
                If p_Field_Ins <> "" Then
                    p_Field_Ins = Mid(Trim(p_Field_Ins), 2)
                    p_Field_Value = Mid(Trim(p_Field_Value), 2)
                    If p_RecordHist = True And Not p_Dt Is Nothing Then
                        p_RowArr = p_Dt.Select("ColumnName='CREATEDATE' or ColumnName='CREATETIME' Or ColumnName='CREATEDBY'")

                        p_GetDateTime(p_DateValue, p_TimeValue)
                        For p_Count = 0 To p_RowArr.Length - 1
                            If p_RowArr(p_Count).Item(1) = 40 Or p_RowArr(p_Count).Item(1) = 61 Then  'Date
                                p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(0)
                                p_Field_Value = p_Field_Value & ",'" & p_DateValue.ToString("yyyyMMdd") & "'"
                            End If

                            If p_RowArr(p_Count).Item(1) = 52 Or p_RowArr(p_Count).Item(1) = 56 Then  'Time
                                p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(0)
                                p_Field_Value = p_Field_Value & "," & p_TimeValue
                            End If

                            If p_RowArr(p_Count).Item(1) = 231 Or p_RowArr(p_Count).Item(1) = 175 Then  'CreatedBy
                                p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(0)
                                p_Field_Value = p_Field_Value & ",'" & p_UserName & "'"
                            End If


                        Next
                    End If
                    p_SQL_Upd = "INSERT INTO " & p_Table_Name & "(" & p_Field_Ins & ")  VALUES (" & p_Field_Value & ")"
                    If p_SQL_Upd <> "" Then
                        p_Row = p_Table.Rows.Add
                        p_Row(0) = p_SQL_Upd
                        p_CompileControlHeaderToSQL_BackUp = p_Table
                        'p_DataUpd.Tables.Add(p_Table)
                        'If B1Get = True Then
                        '    p_CompileControlHeaderToSQL_BackUp = g_Service.SysExecuteDataSet_Company(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_DataUpd)
                        'Else
                        '    p_CompileControlHeaderToSQL_BackUp = g_Service.SysExecuteDataSet(p_DataUpd, p_Err)
                        'End If
                    End If
                End If
            Else
                If p_SQL_Upd <> "" Then
                    p_SQL_Upd = Mid(Trim(p_SQL_Upd), 2)
                    If p_RecordHist = True And Not p_Dt Is Nothing Then

                        p_RowArr = p_Dt.Select("ColumnName='UPDATEDATE' or ColumnName='UPDATETIME' Or ColumnName='UPDATEBY'")

                        p_GetDateTime(p_DateValue, p_TimeValue)
                        For p_Count = 0 To p_RowArr.Length - 1
                            If p_RowArr(p_Count).Item(1) = 40 Or p_RowArr(p_Count).Item(1) = 61 Then  'Date
                                'p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(1)
                                'p_Field_Value = p_Field_Value & ",'" & p_DateValue.ToString("yyyyMMdd") & "'"

                                p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count).Item(0) & "='" & p_DateValue.ToString("yyyyMMdd") & "'"
                            End If

                            If p_RowArr(p_Count).Item(1) = 52 Or p_RowArr(p_Count).Item(1) = 56 Then  'Time
                                'p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(1)
                                'p_Field_Value = p_Field_Value & "," & p_TimeValue

                                p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count).Item(0) & "=" & p_TimeValue
                            End If

                            If p_RowArr(p_Count).Item(1) = 231 Or p_RowArr(p_Count).Item(1) = 175 Then  'CreatedBy
                                'p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(1)
                                'p_Field_Value = p_Field_Value & ",'" & g_UserName & "'"

                                p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count).Item(0) & "='" & p_UserName & "'"
                            End If
                        Next
                    End If
                    p_SQL_Upd = "UPDATE " & p_Table_Name & " SET " & p_SQL_Upd
                    If p_Where <> "" Then
                        p_SQL_Upd = p_SQL_Upd & " WHERE " & p_Where
                    Else
                        p_Err = "Không xác định điều kiện where khi cập nhật"
                        p_CompileControlHeaderToSQL_BackUp = Nothing
                        GoTo line_KT
                    End If
                    p_Row = p_Table.Rows.Add
                    p_Row(0) = p_SQL_Upd
                    p_CompileControlHeaderToSQL_BackUp = p_Table
                    'p_DataUpd.Tables.Add(p_Table)
                    'If B1Get = True Then
                    '    p_CompileControlHeaderToSQL_BackUp = g_Service.SysExecuteDataSet_Company(g_Company_Host, g_Company_DB_Name, g_UsrB1, g_PassB1, g_Port, p_DataUpd)
                    'Else
                    '    p_CompileControlHeaderToSQL_BackUp = g_Service.SysExecuteDataSet(p_DataUpd, p_Err)
                    'End If
                End If
            End If
line_KT:
            If p_CompileControlHeaderToSQL_BackUp Is Nothing Then
                MsgBox(p_Err)
            End If
            ' p_System = Nothing
        Catch ex As Exception

            p_CompileControlHeaderToSQL_BackUp = Nothing
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub p_GetDateTime(ByRef p_Date As Date, ByRef p_Time As Integer)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        p_SQL = "select  convert(date, getdate()) as SysDate, replace(CONVERT(VARCHAR(5),DATEADD(MINUTE,0 ,GETDATE()),108),':','') as SysTime"
        p_Datatable = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SysDate")
                p_Time = p_Datatable.Rows(0).Item("SysTime")
            End If
        End If
        p_Datatable = Nothing
    End Sub


    'anhqh
    '01/07/2014
    'Ham gan Source cho cac Item trên form
    Public Function p_Set_BindSource_ForForm(ByVal p_DataSet_TrueGird As DataSet, _
                                             ByVal p_SetSourceItem As Boolean, _
                                                ByRef p_Form As Object, _
                                      ByVal p_ViewName As String, _
                                      ByRef p_BingdingSource As BindingSource, _
                                      ByVal p_Table As String, ByVal p_FieldKey As String, _
                                        ByRef p_Page_Total As Integer, _
                                      Optional ByVal p_GetB1 As Boolean = True, _
                                     Optional ByVal p_Where As String = "", _
                                    Optional ByVal p_RowNum As Integer = 0, _
                                    Optional ByVal p_PageNum As Integer = 1) As Boolean
        Dim p_DBDataSet As New DataSet
        'Dim p_BindingSourceLine As BindingSource
        'Dim p_DataTable As DataTable
        'Dim p_TrueDBGrid As U_TextBox.U_TrueDBGrid
        'Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
        'Dim p_Control() As Control
        Dim p_DatatableCheckObj As DataTable = Nothing
        Dim p_Errdes As String = ""
        p_Set_BindSource_ForForm = True
        Dim p_SQL As String
        Dim p_Desc As String = ""
        Dim p_OracleArr(0) As OracleClient.OracleParameter

        If p_ViewName.Trim <> "" Then
            '
            If g_DBTYPE = "ORACLE" Then
                p_OracleArr(0) = New OracleClient.OracleParameter
                p_OracleArr(0).ParameterName = "p_ObjectName"
                p_OracleArr(0).Value = p_ViewName

                p_OracleArr(0).OracleType = OracleClient.OracleType.NVarChar
                p_OracleArr(0).Direction = ParameterDirection.Input
                'p_DatatableCheckObj = g_Service.CallFuntioncReturnCursorOralce("FGetObjectType", p_Desc, p_OracleArr)
                ' p_DatatableCheckObj = CallFuntioncReturnCursorOralce("FGetObjectType", p_Desc, p_OracleArr)

                g_Service.ModCallFuntioncReturnCursorOralce("FGetObjectType", p_Desc, p_OracleArr, p_DatatableCheckObj)


            ElseIf g_DBTYPE = "SQL" Then



                p_SQL = " Exec FPT_GetObjectType '" & p_ViewName & "'"
                p_DatatableCheckObj = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Desc)
            End If
            '  p_SQL = "  FGetObjectType '" & p_ViewName & "'"
            'CallFuntioncReturnCursorOralce
            

            'p_DBDataSet = g_Service.mod_SYS_GET_DATASET_Oracle(p_SQL, p_Errdes)
           
            If p_Desc <> "" Then
                MsgBox(p_Desc)
                p_Set_BindSource_ForForm = False
                Exit Function
            End If
            If p_DatatableCheckObj Is Nothing Then
                MsgBox("Table hoặc View không xác định")
                p_Set_BindSource_ForForm = False
                Exit Function
            End If

            If p_DatatableCheckObj.Rows.Count <= 0 Then
                MsgBox("Table hoặc View không xác định")
                p_Set_BindSource_ForForm = False
                Exit Function
            End If
            If p_DatatableCheckObj.Rows(0).Item(0) = "VIEW" Then
                p_SQL = "SELECT * FROM  " & p_ViewName & " "
            Else
                p_SQL = "SELECT * FROM  " & p_ViewName & " with (nolock) "
            End If



            If Mod_Get_BindingSource(p_SQL, p_BingdingSource, p_Table, p_FieldKey, p_Page_Total, p_GetB1, p_Where, p_RowNum, p_PageNum) = False Then
                GoTo Line_Err
            End If
            If p_TableStructure(p_ViewName, p_DBDataSet, p_GetB1) = False Then
                GoTo Line_Err
            End If
            '======
            If p_SetSourceItem = True Then
                If p_Control_DataField(p_Form, p_BingdingSource, p_DBDataSet, _
                                       0, p_GetB1) = False Then
                    GoTo Line_Err
                End If

            End If
        End If
        'Next
        p_Set_BindSource_ForForm = SetTrueGridPropertyNew(p_DataSet_TrueGird, p_Form, False)
        'MsgBox("Set_BindSource_ForForm ")

        ''Gan Source cho Gird neu co
        'p_DataTable = g_Service.mod_SYS_GET_DATATABLE("select Distinct Grid_Name from GRID_PROPERTY where FORM_NAME='" & p_Form.Name & "'")
        'If Not p_DataTable Is Nothing Then
        '    For p_Count = 0 To p_DataTable.Rows.Count - 1
        '        Try
        '            p_Control = p_Form.Controls.Find(p_DataTable.Rows(p_Count).Item(0).ToString.Trim, True)
        '            If p_Control.Length > 0 Then
        '                p_TrueDBGrid = p_Control(0)
        '                p_GridView = p_TrueDBGrid.Views(0)
        '                p_BindingSourceLine = New BindingSource
        '                If p_Set_TrueGrid_Property(p_Form, p_DataSet_TrueGird, p_BindingSourceLine, _
        '                                                    p_TrueDBGrid, p_GridView, False, False, "") = False Then
        '                    'GoTo Line_Err
        '                    MsgBox("et_TrueGrid_Property Error")
        '                    p_Set_BindSource_ForForm = False
        '                    Exit Function
        '                End If

        '            End If
        '        Catch ex As Exception

        '        End Try
        '    Next
        'End If

        Exit Function
Line_Err:
        p_Set_BindSource_ForForm = False
    End Function

    Public Function SetTrueGridPropertyNew(ByVal p_DataSet_TrueGird As DataSet, ByRef p_Form As Form, _
                                           ByVal p_requery As Boolean) As Boolean

        Dim p_Control() As Control
        Dim p_BindingSourceLine As BindingSource
        Dim p_DataTable As DataTable
        Dim p_TrueDBGrid As U_TextBox.U_TrueDBGrid
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
        SetTrueGridPropertyNew = True

        If g_DBTYPE = "ORACLE" Then
            p_DataTable = g_Service.SYS_GET_DATATABLE_oracle("select Distinct Grid_Name from GRID_PROPERTY where FORM_NAME=upper('" & p_Form.Name & "')")
        ElseIf g_DBTYPE = "SQL" Then
            p_DataTable = g_Service.mod_SYS_GET_DATATABLE("select Distinct Grid_Name from GRID_PROPERTY with (nolock) where FORM_NAME='" & p_Form.Name & "'")
        End If

        If Not p_DataTable Is Nothing Then
            For p_Count = 0 To p_DataTable.Rows.Count - 1
                Try
                    p_Control = p_Form.Controls.Find(p_DataTable.Rows(p_Count).Item(0).ToString.Trim, True)
                    If p_Control.Length > 0 Then
                        p_TrueDBGrid = p_Control(0)
                        p_GridView = p_TrueDBGrid.Views(0)
                        p_BindingSourceLine = New BindingSource
                        If p_Set_TrueGrid_Property(p_Form, p_DataSet_TrueGird, p_BindingSourceLine, _
                                                            p_TrueDBGrid, p_GridView, False, p_requery, "") = False Then
                            'GoTo Line_Err
                            MsgBox("et_TrueGrid_Property Error")
                            SetTrueGridPropertyNew = False
                            Exit Function
                        End If

                    End If
                Catch ex As Exception

                End Try
            Next
        End If
    End Function

    Public Function p_CheckRequiredGridView(ByVal p_FormName As String, _
                                            ByVal p_TrueDBGridName As String, _
                                            ByVal p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                            ByVal p_DataSet_TrueGird As DataSet) As Boolean
        Dim p_Count As Integer
        Dim p_RowId As Integer
        Dim p_RowArr() As DataRow
        Dim p_DataRow As DataRow
        Try
            p_CheckRequiredGridView = True
            p_RowArr = p_DataSet_TrueGird.Tables(0).Select("FORM_NAME='" & p_FormName.Trim & _
                                                            "'  and Grid_Name='" & p_TrueDBGridName.Trim & "' and Required='Y'")
            For p_RowId = 0 To p_GridView.RowCount - 1
                If p_GridView.IsDataRow(p_RowId) Then
                    p_DataRow = p_GridView.GetDataRow(p_RowId)
                    If Not p_DataRow Is Nothing Then
                        For p_Count = 0 To p_RowArr.Length - 1
                            If p_DataRow.Item(p_RowArr(p_Count).Item("COL_NAME").ToString).ToString.Trim = "" Then
                                p_GridView.ClearColumnsFilter()
                                MsgBox("Giá trị " & p_RowArr(p_Count).Item("CAPTION").ToString & " không được trống")
                                '  p_GridView.ClearColumnsFilter()
                                p_CheckRequiredGridView = False
                                Exit Function
                            End If
                        Next
                    End If
                End If
            Next
        Catch ex As Exception
            p_GridView.ClearColumnsFilter()
            MsgBox(ex.Message)
            p_CheckRequiredGridView = False
        End Try

    End Function

    Public Function SetTrueGridEditColumn(ByVal p_EditColumn As Boolean, _
                                          ByRef p_TrueDBGrid As U_TextBox.U_TrueDBGrid, _
                                          ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView, _
                                          ByVal p_DataSet_TrueGird As DataSet, _
                                          ByVal p_FormName As String, _
                                          Optional ByVal p_SetAllColumn As Boolean = False) As Boolean
        Dim p_DataArr() As DataRow
        Dim p_Count As Integer
        Try
            SetTrueGridEditColumn = True
            If p_SetAllColumn = True Then
                p_DataArr = p_DataSet_TrueGird.Tables(0).Select("FORM_NAME='" & p_FormName.Trim & _
                                                            "'  and Grid_Name='" & p_TrueDBGrid.Name.Trim & "'")
            Else
                p_DataArr = p_DataSet_TrueGird.Tables(0).Select("FORM_NAME='" & p_FormName.Trim & _
                                                                "'  and Grid_Name='" & p_TrueDBGrid.Name.Trim & "' and AllowUpdate='N'")
            End If
            With p_DataArr
                If Not p_DataArr Is Nothing Then
                    For p_Count = 0 To .Length - 1
                        If p_DataArr(p_Count).Item("VISIBLE_FLAG").ToString = "Y" Then
                            If p_EditColumn = True Then
                                If p_DataArr(p_Count).Item("ENABLE_FLAG").ToString = "Y" Then
                                    p_GridView.Columns.Item(p_DataArr(p_Count).Item("COL_NAME").ToString.Trim).OptionsColumn.ReadOnly = Not p_EditColumn
                                End If
                            Else
                                p_GridView.Columns.Item(p_DataArr(p_Count).Item("COL_NAME").ToString.Trim).OptionsColumn.ReadOnly = Not p_EditColumn
                            End If
                        End If
                    Next
                End If
            End With
        Catch ex As Exception
            MsgBox("SetTrueGridEditColumn: " & ex.Message)
            SetTrueGridEditColumn = False
        End Try
    End Function

    Private Function p_Table_Structure(ByVal p_TableName As String, ByVal p_Table_Structure1 As DataSet, ByVal p_GetB1 As Boolean) As Boolean
        Throw New NotImplementedException
    End Function

    'ANHQH
    '26/06/2014
    'Ham 1 cau lenh SQL
    'Tra ve bien DataTable
    Public Function p_GET_DATATABLE_Des(ByVal p_SQL As String, _
                                                ByRef p_DesErr As String) As DataTable
        'Dim dr As OleDbDataReader 

        'Dim connectionString As String
        'Dim sSQL As String
        'Dim p_Status As Boolean
        Dim p_DataTable As New DataTable

        'Dim p_DataSet As New DataSet

        'Dim p_Recorset As New Object
        'Dim p_Int As Integer

        'Dim Olecon As New OleDb.OleDbConnection
        'Dim OlemyCommand As OleDb.OleDbCommand
        'Dim p_OleAdapter As OleDb.OleDbDataAdapter
        'Dim p_ConnectStr As String
        'p_Status = True


        p_DesErr = ""
        'p_DataTable.c()
        'sSQL = p_SQL
        Try
            'con.Open()
            'Olecon = Sys_SQL_Connection()
            ' p_ConnectStr = SysGetConnect()
            'Olecon.ConnectionString = p_ConnectStr
            'Olecon.Open()
            'If Olecon.State.ToString() = "Open" Then
            '    OlemyCommand = New OleDbCommand(sSQL, Olecon)

            '    OlemyCommand.CommandTimeout = 300
            '    p_OleAdapter = New OleDbDataAdapter(OlemyCommand)
            '    p_Int = p_OleAdapter.Fill(p_DataSet)
            'Else
            '    p_Status = False
            'End If
            'Olecon.Close()
            'Olecon = Nothing
            ''mod_SYS_GET_DATATABLE = p_DataTable
            'Return p_DataSet.Tables(0)
            p_DataTable = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_DesErr)
            Return p_DataTable
        Catch ex As Exception
            p_DesErr = ex.Message
            p_DataTable = Nothing
            'p_Status = False
            Return Nothing
        End Try

    End Function

    Public Sub ErrException(ByVal p_ErrNumber As String, Optional ByVal p_Message As String = "", _
                            Optional ByVal p_BtnYes As Boolean = False, _
                    Optional ByVal p_TextYes As String = "", _
                    Optional ByVal p_BtnNo As Boolean = False, _
                    Optional ByVal p_TextNo As String = "", _
                    Optional ByVal p_BtnCancel As Boolean = False, _
                    Optional ByVal p_TextCancel As String = "", _
                    Optional ByVal p_DefaultButton As Integer = 0, _
                    Optional ByVal p_Type As Integer = 0)
        'Dim p_Datatable As DataTable
        'Dim p_SQL As String
        Dim p_Form As New FrmShowMessage(p_ErrNumber, p_Message, p_BtnYes, p_TextYes, p_BtnNo, p_TextNo, p_BtnCancel, p_TextCancel, p_DefaultButton, p_Type)
        Try
            p_Form.ShowDialog()
            'p_SQL = "SELECT * FROM FPTMESSAGE WHERE ERRNUM=" & p_ErrNumber
            'p_Datatable = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            'If p_SQL = "" Then
            '    If Not p_Datatable Is Nothing Then
            '        If p_Datatable.Rows.Count > 0 Then

            '        End If
            '    End If
            'End If
        Catch ex As Exception

        End Try

    End Sub


    Public Sub StatusMessage(ByVal p_Error As Boolean, _
                            Optional ByVal p_ErrorNumber As String = "", _
                            Optional ByVal p_ErrorText As String = "", _
                            Optional ByVal p_TimeSeconds As Integer = 10, _
                            Optional ByRef p_MessageStatusl As System.Windows.Forms.ToolStripStatusLabel = Nothing)
        If p_MessageStatusl Is Nothing Then Exit Sub
        If p_Error = True Then
            p_MessageStatusl.ForeColor = Red
        Else
            p_MessageStatusl.ForeColor = Blue
        End If
        p_MessageStatusl.ToolTipText = p_TimeSeconds

        If p_ErrorNumber <> "" Then
            Dim p_Datatable As DataTable
            Dim p_SQL As String

            Try
                p_SQL = "SELECT * FROM SYS_MESSAGES WHERE MESSAGE_CODE='" & p_ErrorNumber & "'"
                p_Datatable = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If p_SQL = "" Then
                    If Not p_Datatable Is Nothing Then
                        If p_Datatable.Rows.Count > 0 Then
                            If p_Datatable.Rows(0).Item("MESSAGE_NAME").ToString.Trim <> "" Then
                                p_ErrorText = p_Datatable.Rows(0).Item("MESSAGE_NAME").ToString.Trim
                                p_MessageStatusl.Text = p_ErrorNumber & "-" & p_ErrorText
                            End If

                        Else
                            p_MessageStatusl.Text = p_ErrorNumber & "-" & p_ErrorText
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
            Exit Sub
        Else
            p_MessageStatusl.Text = p_ErrorNumber & "-" & p_ErrorText
        End If

    End Sub

End Module
