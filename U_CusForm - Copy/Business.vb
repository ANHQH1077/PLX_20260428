Imports System.Windows.Forms
Imports System.Drawing

Module Business
    Public g_ValueType As Integer = 0
    Public g_Service As Object = Nothing
    Public g_Module As Object = Nothing
    'FPTModule
    Public g_ChooseRecordFromSearch As Boolean = False
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

    Public g_Form As U_CusForm.XtraCusForm1

    Private pv_Type_Column_Char As String = "C"  'Kieu du lieu cua column
    Private pv_Type_Column_Date As String = "D"  'Kieu du lieu cua column
    Private pv_Type_Column_Number As String = "N"  'Kieu du lieu cua column

    Public g_Format_Date As String = "MM/dd/yyyy"
    Public g_Format_DateTime As String = "MM/dd/yyyy hh:mm:ss tt"

    Public pv_Type_Date As String = ".U_DATEEDIT"

    Public pv_Type_ChectBox As String = ".U_CHECKBOX"

    Public pv_Type_TextBox As String = ".U_TEXTBOX"
    Public pv_Type_MemoEdit As String = UCase(".U_MemmoEdit")
    Public pv_Type_Num As String = ".U_NUMERICEDIT"
    Public pv_Type_Combo As String = ".U_COMBOBOX"
    Public pv_Type_Button As String = ".U_BUTTONEDIT"
    Public pv_Type_Tabpage As String = "TABCONTROL"
    Public pv_Type_PanelControl As String = "PANELCONTROL"
    'PanelControl
    Public pv_Type_MemoTextBox As String = ".U_MEMMOEDIT"
    Public pv_Type_TrueDBGrid As String = ".U_TRUEDBGRID"
    Public pv_Type_TrueDBGridNew As String = ".TRUEDBGRID"
    Public pv_Type_Navigator As String = UCase(".Navigator")

    Public g_TrueGirdName As New DataTable("TrueGird")


    Public pv_Type_BindingSource As String = UCase(".u_BindingSource")


    Public p_BindingSourceControl(15) As U_TextBox.U_BindingSource

    Public p_NavigatorName As New DataTable("NavigatorName")

    Public p_BindingSourceName As New DataTable("Sourcename")
    Public p_BindingSourceKey As New DataTable("SourceKey")
    Public p_BindingTableName As New DataTable("TableName")




    Public pv_Back_Color As System.Drawing.Color = System.Drawing.Color.White
    Public pv_Required_Back_Color As System.Drawing.Color = System.Drawing.Color.LightGoldenrodYellow
    Public pv_Locked_Back_Color As System.Drawing.Color = System.Drawing.Color.LightGray '   System.Drawing.Color.LightCyan



    Public g_Currency As String = "VND"
    Public g_CurrencyDtl As New DataTable
    Public g_CurrencyDecima As Integer = 0



    Public g_LineRemove As New DataTable("Table01")


    Public Sub ModDeleteHeaderRecord(ByRef p_Form As U_CusForm.XtraCusForm1)
        Dim p_Count As Integer
        Dim p_Row() As DataRow
        Dim p_TableName As String
        Dim p_FieldName As String
        Dim p_Value As String
        Dim p_Control() As Object
        Dim p_ControlName As String
        Dim p_RowID As Integer
        Dim p_SQL As String
        Dim p_DataRow As DataRow
        ' Dim p_RowControl() As 
        If p_BindingTableName.Columns.Count <= 0 Or p_BindingSourceKey.Columns.Count <= 0 Then

            Exit Sub
        End If

        If g_LineRemove.Columns.Count <= 0 Then
            g_LineRemove.Columns.Add("SQlDelete", GetType(String))
        End If
        g_LineRemove.Clear()
        For p_Count = 0 To p_BindingTableName.Rows.Count - 1
            p_TableName = p_BindingTableName.Rows(p_Count).Item(0).ToString.Trim
            If p_TableName = "" Then
                Continue For
            End If
            p_SQL = ""
            Try
                p_Row = p_BindingSourceKey.Select("TableName='" & p_TableName & "'")
                For p_RowID = 0 To p_Row.Length - 1
                    p_ControlName = p_Row(p_RowID).Item(1).ToString.Trim
                    If p_ControlName = "" Then Continue For
                    p_Control = p_Form.Controls.Find(p_ControlName, True)
                    If Not p_Control Is Nothing Then
                        If p_Control.Length > 0 Then
                            If Not p_Control(0).editvalue Is Nothing Then
                                p_FieldName = p_Control(0).FieldName
                                p_Value = p_Control(0).editvalue.ToString.Trim
                                If p_Value <> "" Then
                                    If p_SQL = "" Then
                                        If p_Control(0).FieldType = "C" Then
                                            p_SQL = " WHERE " & p_FieldName & "='" & p_Value & "'"
                                        ElseIf p_Control(0).FieldType = "N" Then
                                            p_SQL = " WHERE " & p_FieldName & "=" & p_Value
                                        End If

                                    Else
                                        If p_Control(0).FieldType = "C" Then
                                            p_SQL = p_SQL & " AND " & p_FieldName & "='" & p_Value & "'"
                                        ElseIf p_Control(0).FieldType = "N" Then
                                            p_SQL = p_SQL & " AND " & p_FieldName & "=" & p_Value
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
                If ModTrueGridRemoveLine(p_Form) = False Then
                    p_Form.ShowStatusMessage(True, "MS905", "Lỗi khi thực hiện", 10)
                Else
                    If p_SQL <> "" Then

                        p_SQL = "DELETE FROM " & p_TableName & " " & p_SQL
                        p_DataRow = g_LineRemove.NewRow
                        p_DataRow.Item(0) = p_SQL
                        g_LineRemove.Rows.Add(p_DataRow)
                        If p_Form.FormStatus = False Then
                            p_Form.FormStatus = True
                        End If
                    End If
                End If
            Catch ex As Exception
                p_SQL = ""
            End Try

        Next
    End Sub


    Public Function ModTrueGridRemoveLine(ByRef p_Form As U_CusForm.XtraCusForm1, _
                                          Optional ByVal p_RowHand As Integer = 0) As Boolean
        Dim p_TrueGrid As U_TextBox.TrueDBGrid
        Dim p_View As U_TextBox.GridView
        Dim p_Count As Integer
        'Dim p_Count As Integer
        Dim p_DataRow As DataRow
        Dim p_TrueGridName As String = ""
        Dim p_SQL As String = ""
        Dim p_Object() As Object
        Dim p_Value As String = ""

        Try
            If g_TrueGirdName.Columns.Count <= 0 Then
                Return True
            End If

            If g_LineRemove.Columns.Count <= 0 Then
                g_LineRemove.Columns.Add("LineRemove", GetType(String))
            End If
            For p_Count = 0 To g_TrueGirdName.Rows.Count - 1
                p_TrueGridName = g_TrueGirdName.Rows(p_Count).Item(0).ToString.Trim
                If p_TrueGridName <> "" Then
                    p_Object = p_Form.Controls.Find(p_TrueGridName, True)
                    If p_Object Is Nothing Then
                        Continue For
                    End If
                    If p_Object.Length <= 0 Then
                        Continue For
                    End If

                    p_TrueGrid = CType(p_Object(0), U_TextBox.TrueDBGrid)
                    If p_TrueGrid.Views.Count <= 0 Then
                        Continue For
                    End If
                    p_View = p_TrueGrid.Views(0)
                    If p_View.DefaultRemove = False Then
                        Continue For
                    End If
                    p_SQL = ""
                    If p_View.TableName.ToString.Trim <> "" Then
                        If p_View.ColumnKey.ToString.Trim <> "" And p_View.ColumnKeyType.ToString.Trim <> "" Then
                            If p_RowHand <> 0 Then  'Xoa dong hien tai
                                Try
                                    p_DataRow = p_View.GetDataRow(p_RowHand)
                                    Continue For
                                Catch ex1 As Exception

                                End Try
                                If p_DataRow.Item(p_View.ColumnKey.ToString.Trim).ToString.Trim <> "" Then
                                    If p_View.ColumnKeyType.ToString.Trim = "N" Then
                                        p_SQL = "DELETE FROM " & p_View.TableName.ToString.Trim & "  WHERE " & _
                                                    p_View.ColumnKey.ToString.Trim & "=" & _
                                                    p_DataRow.Item(p_View.ColumnKey.ToString.Trim).ToString.Trim
                                    ElseIf p_View.ColumnKeyType.ToString.Trim = "C" Then
                                        p_SQL = "DELETE FROM " & p_View.TableName.ToString.Trim & "  WHERE " & _
                                                    p_View.ColumnKey.ToString.Trim & "='" & _
                                                    p_DataRow.Item(p_View.ColumnKey.ToString.Trim).ToString.Trim & "'"
                                    End If
                                End If

                            Else  'Xoa tat ca 
                                If p_View.ParentItem.ToString.Trim <> "" Then
                                    p_Object = p_Form.Controls.Find(p_View.ParentItem.ToString.Trim, True)
                                    If p_Object Is Nothing Then
                                        Continue For
                                    End If
                                    If p_Object.Length <= 0 Then
                                        Continue For
                                    End If
                                    If p_Object(0).editvalue Is Nothing Then
                                        Continue For
                                    End If
                                    p_Value = p_Object(0).editvalue.ToString.Trim
                                    If p_Value = "" Then
                                        Continue For
                                    End If
                                    If p_Object(0).FieldName.ToString.Trim = "" Then
                                        Continue For
                                    End If
                                    If p_Object(0).FieldType.ToString.Trim = "N" Then
                                        p_SQL = "DELETE FROM " & p_View.TableName.ToString.Trim & "  WHERE " & _
                                                    p_Object(0).FieldName.ToString.Trim & "=" & _
                                                    p_Value
                                    End If
                                    If p_Object(0).FieldType.ToString.Trim = "C" Then
                                        p_SQL = "DELETE FROM " & p_View.TableName.ToString.Trim & "  WHERE " & _
                                                    p_Object(0).FieldName.ToString.Trim & "='" & _
                                                    p_Value & "'"
                                    End If
                                End If
                            End If
                        End If
                    End If
                    If p_SQL <> "" Then
                        p_DataRow = g_LineRemove.NewRow
                        p_DataRow.Item(0) = p_SQL
                        g_LineRemove.Rows.Add(p_DataRow)
                        If p_Form.FormStatus = False Then
                            p_Form.FormStatus = True
                        End If
                    End If

                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Function GetDecima(Optional ByVal p_Currency As String = "VND") As Integer
        Dim p_Row() As DataRow
        GetDecima = 0
        If g_CurrencyDtl.Columns.Count <= 0 Then Exit Function
        If g_CurrencyDtl.Rows.Count <= 0 Then Exit Function
        Try
            p_Row = g_CurrencyDtl.Select("Currency='" & p_Currency & "'")
            If p_Row.Length > 0 Then
                GetDecima = p_Row(0).Item(0)
            End If
        Catch ex As Exception

        End Try

    End Function


    Public Function ModSet_BindSource_ForForm(ByRef p_Form As U_CusForm.XtraCusForm1, Optional ByVal p_requery As Boolean = False) As Boolean
        Dim p_DBDataSet As New DataSet
        Dim p_DatatableCheckObj As DataTable
        Dim p_ViewName As String = ""
        Dim p_BindingSource As U_TextBox.U_BindingSource
        Dim p_TrueGrid As U_TextBox.TrueDBGrid
        Dim ctrl As Object
        Dim p_GetB1 As Boolean
        ModSet_BindSource_ForForm = True
        Dim p_SQL As String
        Dim p_Desc As String = ""
        Dim p_Status As Boolean
        Dim p_DataRow As DataRow

        If g_TrueGirdName.Columns.Count <= 0 Then
            g_TrueGirdName.Columns.Add("TrueGridName", GetType(String))
        End If
        g_TrueGirdName.Clear()

        g_Form = p_Form
        ' If p_requery = False Then
        If p_Control_DataField(p_Form, p_GetB1) = False Then
            GoTo Line_Err
        End If

        ' End If

        For Each ctrl In p_Form.Controls


            If InStr(UCase(ctrl.GetType.ToString), pv_Type_TrueDBGrid, CompareMethod.Text) > 0 _
                Or InStr(UCase(ctrl.GetType.ToString), pv_Type_TrueDBGridNew, CompareMethod.Text) > 0 Then



                p_TrueGrid = CType(ctrl, U_TextBox.TrueDBGrid)
                p_Status = True
                p_Status = p_Set_TrueGrid_Property(p_Form, p_TrueGrid, _
                                            p_requery, "")
            ElseIf InStr(UCase(ctrl.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                If p_Set_TrueGrid_Property_Page(p_Form,
                                      ctrl,
                                            p_requery) Then
                End If

            End If
        Next

        Exit Function
Line_Err:
        ModSet_BindSource_ForForm = False
    End Function


    Private Sub ControlKeyInsert(ByVal p_Control As Object)
        Dim p_DataRow As DataRow

        Dim p_ArrDataRow() As DataRow

        Dim p_TableName As String
        Dim p_ItemName As String
        If p_BindingSourceKey.Columns.Count <= 0 Then
            p_BindingSourceKey.Columns.Add("TableName", GetType(String))
            p_BindingSourceKey.Columns.Add("ItemName", GetType(String))
        End If

        If p_BindingTableName.Columns.Count <= 0 Then
            p_BindingTableName.Columns.Add("TableName", GetType(String))

        End If
        p_TableName = UCase(p_Control.tableName.ToString.Trim)
        p_ItemName = p_Control.Name.ToString.Trim

        If p_TableName = "" Or p_ItemName = "" Then Exit Sub

        If p_TableName <> "" Then
            p_ArrDataRow = p_BindingTableName.Select("TableName='" & p_TableName & "'")
            If p_ArrDataRow.Length <= 0 Then
                p_DataRow = p_BindingTableName.NewRow
                p_DataRow.Item(0) = p_TableName
                p_BindingTableName.Rows.Add(p_DataRow)
            End If
            p_ArrDataRow = p_BindingSourceKey.Select("TableName='" & p_TableName & "'")
            If p_ArrDataRow.Length <= 0 Then
                p_DataRow = p_BindingSourceKey.NewRow
                p_DataRow.Item(0) = p_TableName
                p_DataRow.Item(1) = p_ItemName
                p_BindingSourceKey.Rows.Add(p_DataRow)
            End If

        End If
    End Sub

    'ANHQH
    '01/01/2012
    'Ham thuc hien set Fieldname cho Item tren Form
    Private Function p_Control_DataField(ByRef p_Form As U_CusForm.XtraCusForm1, _
                                                                         Optional ByVal p_GetB1 As Boolean = True) As Boolean

        Dim p_Object As Object

        Dim p_ItemName As String
        ' Dim p_Rows() As DataRow
        Dim p_Count As Integer

        Dim p_View_Name As String

        Dim p_Value As String

        'Dim p_LocalCurrency As Boolean
        'Dim p_NumberDecimal As Integer
        Dim p_LocalDecimal As Integer
        'Dim p_DataRow() As DataRow
        Dim p_NumberFormat As String = "############"

        Dim p_LocalCurrency As Boolean
        Dim p_NumberDecimal As Integer


        Dim p_FormLock As Boolean = False


        Dim p_BindingSource As U_TextBox.U_BindingSource
        Dim p_DataRowSource() As DataRow
        Dim p_CountSource As Integer
        Dim p_SQL As String
        Dim p_Desc As String
        Dim p_DatatableCheckObj As DataTable
        Dim p_DataRow As DataRow

        If p_BindingSourceName.Columns.Count <= 0 Then
            p_BindingSourceName.Columns.Add("SourceName", GetType(String))
        End If

        If p_NavigatorName.Columns.Count <= 0 Then
            p_NavigatorName.Columns.Add("NavigatorName", GetType(String))
        End If


        Dim p_ControlKey As Boolean
        Dim p_DefaultWhere As String = ""

        p_Control_DataField = True
        '  p_CountObj = 0
        Try
            p_LocalDecimal = 0
            Try
                p_FormLock = p_Form.FormLock
            Catch ex As Exception

            End Try
            p_DefaultWhere = p_Form.DefaultWhere.ToString.Trim

            For p_CountSource = 0 To p_BindingSourceName.Rows.Count - 1
                p_BindingSourceControl(p_CountSource) = Nothing
            Next
            p_BindingSourceName.Clear()
            For Each ctrl As Control In p_Form.Controls

                p_Object = ctrl


                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoTextBox, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                         Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                     Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Navigator, CompareMethod.Text) > 0 Then

                    p_View_Name = ""
                    Try
                        p_View_Name = UCase(p_Object.ViewName)

                    Catch ex As Exception

                    End Try

                    If InStr(UCase(p_Object.GetType.ToString), pv_Type_Navigator, CompareMethod.Text) > 0 Then
                        p_DataRow = p_NavigatorName.NewRow
                        p_DataRow.Item(0) = p_Object.Name
                        p_NavigatorName.Rows.Add(p_DataRow)
                        Continue For
                    End If

                    If p_Object.Visible = True Then
                        p_Value = p_Object.Required
                        If p_Value = "Y" Then
                            p_Object.BackColor = pv_Required_Back_Color

                        End If

                    End If


                    p_ControlKey = False
                    Try
                        If p_Object.PrimaryKey.ToString.Trim = "Y" Then
                            p_ControlKey = True
                        End If
                    Catch ex As Exception

                    End Try

                    p_ItemName = p_Object.FieldName
                    If p_ItemName.ToString.Trim = "" Then
                        Continue For
                    End If

                    If p_View_Name <> "" Then
                        p_DataRowSource = p_BindingSourceName.Select("Sourcename='" & p_View_Name & "'")
                        If p_DataRowSource.Length > 0 Then
                            For p_CountSource = 0 To p_BindingSourceName.Rows.Count - 1
                                If p_BindingSourceName.Rows(p_CountSource).Item(0) = p_View_Name Then
                                    p_BindingSource = New U_TextBox.U_BindingSource


                                    p_BindingSource = p_BindingSourceControl(p_CountSource)

                                    If p_BindingSourceControl(p_CountSource) Is Nothing Then
                                        Continue For
                                    End If
                                    If p_ControlKey = True Then
                                        'p_BindingSourceKey(p_CountSource) = p_Object.FieldName.ToString.Trim
                                        ControlKeyInsert(p_Object)
                                    End If
                                    'sdfsdfsfs
                                End If
                            Next
                        Else
                            p_SQL = " Exec FPT_GetObjectType '" & p_View_Name & "'"
                            p_DatatableCheckObj = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Desc)
                            If Not p_DatatableCheckObj Is Nothing Then
                                If p_DatatableCheckObj.Rows.Count <= 0 Then
                                    Continue For
                                End If
                                p_SQL = "SELECT * FROM " & p_View_Name
                                If p_DefaultWhere <> "" Then
                                    If InStr(UCase(p_SQL), "WHERE", CompareMethod.Text) > 0 Then
                                        p_SQL = p_SQL & " " & p_DefaultWhere
                                    Else
                                        If InStr(UCase(p_DefaultWhere), "WHERE", CompareMethod.Text) > 0 Then
                                            p_SQL = p_SQL & "  " & p_DefaultWhere
                                        Else
                                            p_SQL = p_SQL & " WHERE " & p_DefaultWhere
                                        End If
                                    End If
                                End If

                                Try
                                    p_SQL = p_Parameter_Item(p_Form, p_SQL)
                                    p_DatatableCheckObj = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Desc)
                                Catch ex As Exception
                                    Continue For
                                End Try
                                If p_DatatableCheckObj Is Nothing Then
                                    Continue For
                                End If
                                p_BindingSource = New U_TextBox.U_BindingSource
                                p_BindingSource.Loading = True
                                p_BindingSource.DataSource = p_DatatableCheckObj

                                p_DataRow = p_BindingSourceName.NewRow
                                p_DataRow.Item(0) = p_View_Name
                                p_BindingSourceName.Rows.Add(p_DataRow)
                                p_BindingSource.Loading = False
                                p_BindingSource.FormName = UCase(p_Form.Name)

                                p_BindingSourceControl(p_BindingSourceName.Rows.Count - 1) = p_BindingSource

                                If p_ControlKey = True Then
                                    ControlKeyInsert(p_Object)
                                End If


                            Else
                                Continue For
                            End If
                        End If
                    End If



                    ' If UCase(p_Object.p_BindingSourceName) = UCase(p_BindingSource.BindingSourceName) And p_ItemName.Trim <> "" Then
                    'Me.SoLenh.DataBindings.RemoveAt 
                    If p_Object.DataBindings.count > 0 Then
                        p_Object.DataBindings.RemoveAt(0)
                    End If
                    If p_Object.DataBindings.count <= 0 Then
                        p_Object.DataBindings.Add("EditValue", p_BindingSource, p_ItemName)

                    End If

                    'End If
                    If InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 Then
                        If p_Set_Combo_PropertyNew(p_Form, p_Object, p_GetB1) = False Then
                            Exit Function
                        Else

                        End If
                    End If
                    If InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                        p_Object.Properties.ValueChecked = p_Object.CheckValue
                        p_Object.Properties.ValueUnchecked = p_Object.UnCheckValue
                    End If

                    If p_Object.Visible = True Then
                        p_Value = p_Object.Required
                        If p_Value = "Y" Then
                            p_Object.BackColor = pv_Required_Back_Color

                        End If

                    End If

                    If InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                        If p_Object.Digit = True Then
                            p_LocalCurrency = p_Object.LocalDecimal
                            p_Object.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                            'p_NumberDecimal = p_Object.NumberDecimal
                            'Me.U_NumericEdit1.Properties.Buttons(0).Visible = False
                           
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

                        p_Object.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

                        If p_Object.ShowCalc = False Then
                            p_Object.Properties.Buttons(0).Visible = False
                        End If
                    End If

                    If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 Then
                        If p_Object.ShowDateTime = True Then
                            'p_Object.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"
                            'p_Object.ma.FormatString = "dd/MM/yyyy hh:mm:ss tt"

                            p_Object.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"
                            p_Object.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                            p_Object.Properties.EditMask = "dd/MM/yyyy hh:mm:ss tt"

                        Else
                            p_Object.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
                            p_Object.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                            p_Object.Properties.EditMask = "dd/MM/yyyy"
                            p_Object.Properties.Mask.EditMask = "dd/MM/yyyy"
                        End If
                    End If
                    If p_Object.Width <= 0 Then
                        p_Object.TabStop = False
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
                    ' If
                End If


                If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    p_Control_DataField = p_Control_DataFieldPage(p_Form,
                                              p_Object,
                                       p_GetB1)
                    If p_Control_DataField = False Then
                        Exit Function
                    End If

                End If

            Next

            p_Control_DataField = SetNavigator(p_Form)
        Catch ex As Exception
            'MsgBox("Control Data Field: " & ex.Message)
            g_Module.ModErrExceptionNew(Err.Number, "Control Data Field: " & ex.Message)
            p_Control_DataField = False
        End Try

    End Function

    Private Function SetNavigator(ByVal p_Form As U_CusForm.XtraCusForm1) As Boolean
        Dim p_Object() As Object
        Dim p_Count As Integer
        Dim p_CountView As Integer
        Dim p_ObjName As String
        Dim p_NavigatorControl As U_TextBox.Navigator
        Try
            SetNavigator = True
            For p_Count = 0 To p_NavigatorName.Rows.Count - 1
                p_ObjName = p_NavigatorName.Rows(p_Count).Item(0).ToString.Trim
                If p_ObjName <> "" Then
                    p_Object = p_Form.Controls.Find(p_ObjName, True)
                    If p_Object.Length > 0 Then
                        p_NavigatorControl = CType(p_Object(0), U_TextBox.Navigator)
                        If p_NavigatorControl.ViewName.ToString.Trim <> "" Then
                            For p_CountView = 0 To p_BindingSourceName.Rows.Count - 1
                                If UCase(p_BindingSourceName.Rows(p_CountView).Item(0).ToString.Trim) = UCase(p_NavigatorControl.ViewName.ToString.Trim) Then
                                    p_NavigatorControl.DataSource = p_BindingSourceControl(p_CountView)
                                    Exit For
                                End If

                            Next
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            SetNavigator = False
        End Try
    End Function

    Private Function p_Control_DataFieldPage(ByRef p_Form As U_CusForm.XtraCusForm1, _
                                          ByRef p_Object As Object, _
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


        Dim p_BindingSource As U_TextBox.U_BindingSource
        Dim p_DataRowSource() As DataRow
        Dim p_CountSource As Integer
        Dim p_SQL As String
        Dim p_Desc As String
        Dim p_DatatableCheckObj As DataTable
        Dim p_DataRow As DataRow
        Dim p_DefaultWhere As String = ""
        Dim p_ControlKey As Boolean


        If p_BindingSourceName.Columns.Count <= 0 Then
            p_BindingSourceName.Columns.Add("SourceName", GetType(String))
        End If

        'If p_BindingSourceKey.Columns.Count <= 0 Then
        '    p_BindingSourceKey.Columns.Add("ItemKey", GetType(String))
        'End If

        p_Control_DataFieldPage = True

        Try
            p_FormLock = p_Form.FormLock
        Catch ex As Exception

        End Try

        p_DefaultWhere = p_Form.DefaultWhere.ToString.Trim

        If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
            Try

                For p_Count = p_Object.TabPages.Count - 1 To 0 Step -1
                    If p_Object.TabPages.Count > 1 Then
                        p_Object.SelectedTabPageIndex = p_TabControl_Ind
                    End If

                    p_Object_Item = p_Object.TabPages(p_Count)


                    If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                        p_Control_DataFieldPage = p_Control_DataFieldPage(p_Form,
                                              p_Object,
                                                    p_GetB1)
                        If p_Control_DataFieldPage = False Then Exit Function
                    Else
                        If InStr(UCase(p_Object_Item.GetType.ToString), "XtraTabPage", CompareMethod.Text) > 0 Then
                            p_TabPage = p_Object_Item
                            'For p_Count1 = 0 To p_TabPage.Controls.Count - 1
                            For Each p_Object_Item In p_TabPage.Controls

                                If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                                    p_Control_DataFieldPage = p_Control_DataFieldPage(p_Form,
                                                          p_Object_Item,
                                                                p_GetB1)
                                    If p_Control_DataFieldPage = False Then Exit Function
                                Else


                                    p_ControlKey = False



                                    If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                        Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                        Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                        Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_MemoTextBox, CompareMethod.Text) > 0 _
                                        Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                        Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Navigator, CompareMethod.Text) > 0 Then

                                        Try
                                            If p_Object_Item.PrimaryKey.ToString.Trim = "Y" Then
                                                p_ControlKey = True
                                            End If
                                        Catch ex As Exception

                                        End Try


                                        p_ItemName = p_Object_Item.fieldname

                                        If p_ItemName.ToString.Trim = "" Then
                                            Continue For
                                        End If


                                        p_Value = p_Object_Item.Required
                                        If p_Value = "Y" Then
                                            p_Object_Item.BackColor = pv_Required_Back_Color
                                        Else
                                            'p_Object_Item.BackColor = pv_Back_Color
                                        End If


                                        p_View_Name = ""
                                        Try
                                            p_View_Name = UCase(p_Object_Item.ViewName)

                                        Catch ex As Exception

                                        End Try

                                        If InStr(UCase(p_Object.GetType.ToString), pv_Type_Navigator, CompareMethod.Text) > 0 Then
                                            p_DataRow = p_NavigatorName.NewRow
                                            p_DataRow.Item(0) = p_Object_Item.Name
                                            p_NavigatorName.Rows.Add(p_DataRow)
                                            Continue For
                                        End If


                                        If p_View_Name <> "" Then
                                            p_DataRowSource = p_BindingSourceName.Select("Sourcename='" & p_View_Name & "'")
                                            If p_DataRowSource.Length > 0 Then
                                                For p_CountSource = 0 To p_BindingSourceName.Rows.Count - 1
                                                    If p_BindingSourceName.Rows(p_CountSource).Item(0) = p_View_Name Then
                                                        p_BindingSource = New U_TextBox.U_BindingSource
                                                        p_BindingSource = p_BindingSourceControl(p_CountSource)
                                                        If p_BindingSourceControl(p_CountSource) Is Nothing Then
                                                            Continue For
                                                        End If
                                                        'sdfsdfsfs

                                                        If p_ControlKey = True Then
                                                            ControlKeyInsert(p_Object_Item)
                                                        End If


                                                    End If
                                                Next
                                            Else
                                                p_SQL = " Exec FPT_GetObjectType '" & p_View_Name & "'"
                                                p_DatatableCheckObj = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Desc)
                                                If Not p_DatatableCheckObj Is Nothing Then
                                                    If p_DatatableCheckObj.Rows.Count <= 0 Then
                                                        Continue For
                                                    End If
                                                    p_SQL = "SELECT * FROM " & p_View_Name
                                                    If p_DefaultWhere <> "" Then
                                                        If InStr(UCase(p_SQL), "WHERE", CompareMethod.Text) > 0 Then
                                                            p_SQL = p_SQL & " " & p_DefaultWhere
                                                        Else
                                                            p_SQL = p_SQL & " WHERE " & p_DefaultWhere
                                                        End If

                                                    End If

                                                    Try
                                                        p_DatatableCheckObj = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Desc)
                                                    Catch ex As Exception
                                                        Continue For
                                                    End Try
                                                    If p_DatatableCheckObj Is Nothing Then
                                                        Continue For
                                                    End If
                                                    p_BindingSource = New U_TextBox.U_BindingSource
                                                    p_BindingSource.DataSource = p_DatatableCheckObj
                                                    p_DataRow = p_BindingSourceName.NewRow
                                                    p_DataRow.Item(0) = p_View_Name
                                                    p_BindingSourceName.Rows.Add(p_DataRow)
                                                    p_BindingSourceControl(p_BindingSourceName.Rows.Count - 1) = p_BindingSource

                                                    If p_ControlKey = True Then
                                                        ControlKeyInsert(p_Object_Item)
                                                    End If

                                                Else
                                                    Continue For
                                                End If
                                            End If
                                        End If

                                        If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 Then
                                            If p_Set_Combo_PropertyNew(p_Form, p_Object_Item, p_GetB1) = False Then
                                                Exit Function
                                            End If
                                        End If
                                        'If UCase(p_Object.p_BindingSourceName) = UCase(p_BindingSource.BindingSourceName) And p_ItemName.Trim <> "" Then

                                        If p_Object_Item.DataBindings.count > 0 Then
                                            p_Object_Item.DataBindings.RemoveAt(0)
                                        End If
                                        If p_Object_Item.DataBindings.count <= 0 Then
                                            p_Object_Item.DataBindings.Add("EditValue", p_BindingSource, p_ItemName)

                                        End If

                                        'Try
                                        '    p_Object_Item.DataBindings.Add("EditValue", p_BindingSource, p_ItemName)
                                        'Catch ex As Exception

                                        'End Try


                                        If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                            p_Object_Item.Properties.ValueChecked = p_Object_Item.CheckValue
                                            p_Object_Item.Properties.ValueUnchecked = p_Object_Item.UnCheckValue
                                        End If


                                        p_Value = p_Object_Item.Required
                                        If p_Value = "Y" Then
                                            p_Object_Item.BackColor = pv_Required_Back_Color
                                        Else
                                            'p_Object_Item.BackColor = pv_Back_Color
                                        End If

                                        If p_Object_Item.Width <= 0 Then
                                            p_Object_Item.TabStop = False
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
                                            If p_Object_Item.ShowCalc = False Then
                                                p_Object_Item.Properties.Buttons(0).Visible = False
                                            End If
                                        End If

                                        If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 Then
                                            If p_Object.ShowDateTime = True Then
                                                'p_Object.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"
                                                'p_Object.ma.FormatString = "dd/MM/yyyy hh:mm:ss tt"

                                                p_Object.Properties.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss tt"
                                                p_Object.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                                p_Object.Properties.EditMask = "dd/MM/yyyy hh:mm:ss tt"


                                            End If
                                        End If


                                        If p_FormLock = True Then
                                            p_Object_Item.Properties.ReadOnly = True
                                        Else
                                            If Not p_Object_Item.EditValue Is Nothing Then
                                                If p_Object_Item.EditValue.ToString.Trim <> "" And p_Object_Item.UpdateIfNull.ToString.Trim = "Y" Then
                                                    If p_Object_Item.FieldType = "N" Then
                                                        If p_Object_Item.EditValue <> 0 Then
                                                            Try
                                                                For p_Count123 = 0 To 100     'g_ChooseRecordFromSearch.
                                                                    If p_Form.g_ObjectUpdateIsNull(p_Count123) Is Nothing Then
                                                                        p_Form.g_ObjectUpdateIsNull(p_Count123) = p_Object_Item.Name
                                                                        p_Form.g_ObjectUpdateIsNullColor(p_Count123) = p_Object_Item.backcolor
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

                                        'End If
                                    End If
                                End If
                            Next

                        End If
                    End If
                    p_Object.TabPages(p_Count).Select()
                Next
            Catch ex As Exception
                g_Module.ModErrExceptionNew(Err.Number, "Control Data Field Page: " & ex.Message)
                p_Control_DataFieldPage = False
                ' MsgBox("Control Data Field Page: " & ex.Message)

            End Try


        End If
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

    'ANHHQ
    '21/11/2011
    'Ham thuc hien select ma fill du lieu vao p_BindingSource1 va set datafile  dung ca cho bien p_abc la C1Flex
    Private Function Mod_Get_Gird_ComboNew(ByVal p_SQL As String, _
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
                ' p_Mod_Get_Gird = g_Service.mod_SYS_GET_DATASET(p_SQL).Tables(0)
                p_Mod_Get_Gird = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)    '.Tables(0
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
    'anhqh
    '10/10/2012
    'Ham thuc hien replace cac string khai bao trong SQL thanh cac gia tri theo cac
    'Item tren form

    Public Function p_Parameter_Item(ByVal p_Form As Form, _
                                      ByVal p_SQL As String, Optional ByVal p_DataRow As DataRow = Nothing) As String
        Dim p_SQL_Tmp As String
        Dim p_Pos As Integer
        Dim p_SQL_Tmp1 As String
        Dim p_Parent_Item As String = ""
        Dim p_Parent_Obj As Object
        Dim p_SValue As String = ""
        Dim p_NValue As Integer = 0
        Dim p_ColumnValue As String = "COLUMN."
        Dim p_SQL_Tmp2 As String
        Dim p_Field As String

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
                    'End If
                End If
                If UCase(p_Parent_Item) = UCase(":GLOBAL.COMCODE") Then
                    p_SValue = g_CompanyCode
                    p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                ElseIf UCase(p_Parent_Item) = UCase(":GLOBAL.USERNAME") Then
                    p_SValue = g_UserName
                    p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                Else
                    If InStr(UCase(p_SQL_Tmp1), p_ColumnValue, CompareMethod.Text) > 0 Then
                        If Not p_DataRow Is Nothing Then
                            'p_SQL_Tmp2 = Mid(p_SQL_Tmp1, InStr(p_SQL_Tmp1, ".", CompareMethod.Text) + 1)
                            p_Field = Mid(p_SQL_Tmp1, InStr(p_SQL_Tmp1, ".", CompareMethod.Text) + 1)
                            p_SQL_Tmp2 = p_DataRow.Item(p_Field).ToString.Trim
                            'Continue For
                            'p_DataRow.Item(p_SQL_Tmp2).GetType.  

                            Select Case UCase(p_DataRow.Item(p_Field).GetType.Name)
                                Case UCase("String")
                                    p_SValue = p_SQL_Tmp2.ToString.Trim

                                    p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                                Case UCase("Decimal")
                                    If p_Parent_Obj(0).text = "" Then
                                        p_NValue = 0
                                    Else
                                        p_NValue = p_SQL_Tmp2.ToString.Trim
                                    End If
                                    ' p_NValue = p_Parent_Obj(0).text

                                    p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, p_NValue, 1)
                                Case UCase("DateTime")
                                    p_SValue = CDate(p_SQL_Tmp2).ToString("MM/dd/yyyy")

                                    p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "convert(date,'" & p_SValue & "')", 1)
                                Case Else
                                    Exit Function

                            End Select
                            GoTo Line_TT
                        Else
                            GoTo Line_KT1
                        End If
                    End If
                    p_Parent_Obj = p_Form.Controls.Find(p_Parent_Item, True)
                    If Not p_Parent_Obj Is Nothing Then
                        If p_Parent_Obj.length > 0 Then
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
                                        p_SValue = CDate(p_Parent_Obj(0).editvalue.ToString.Trim).ToString("yyyyMMdd")
                                        p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                                    Case Else
                                        Exit Function

                                End Select

                                ' End If

                            Else
                                p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                            End If
                        Else
                            Exit Function
                        End If
                    End If
                End If



            End If
Line_TT:
            p_SQL_Tmp = p_SQL
        End While
Line_KT1:
        p_Parameter_Item = p_SQL
    End Function


    'Public Function p_Parameter_Item(ByVal p_Form As Form, _
    '                                  ByVal p_SQL As String) As String
    '    Dim p_SQL_Tmp As String
    '    Dim p_Pos As Integer
    '    Dim p_SQL_Tmp1 As String
    '    Dim p_Parent_Item As String = ""
    '    Dim p_Parent_Obj As Object
    '    Dim p_SValue As String = ""
    '    Dim p_NValue As Integer = 0

    '    p_Parameter_Item = ""

    '    p_SQL_Tmp = p_SQL
    '    While InStr(p_SQL_Tmp, ":", CompareMethod.Text) > 0


    '        p_Pos = InStr(p_SQL_Tmp, ":", CompareMethod.Text)
    '        If p_Pos > 0 Then

    '            If InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) = 0 Then
    '                p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos)
    '            Else
    '                If InStr(1, Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) - p_Pos), "=", CompareMethod.Text) > 0 Then
    '                    p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, "=", CompareMethod.Text) - p_Pos)
    '                Else
    '                    p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) - p_Pos)
    '                End If

    '            End If
    '            ' End If

    '            p_SQL_Tmp1 = Replace(p_SQL_Tmp1, ")", "", 1)
    '            p_SQL_Tmp1 = Replace(p_SQL_Tmp1, "(", "", 1)
    '            If p_SQL_Tmp1.Length > 0 Then
    '                If UCase(p_SQL_Tmp1) = UCase(":GLOBAL.COMCODE") Or UCase(p_SQL_Tmp1) = UCase(":GLOBAL.USERNAME") Then
    '                    p_Parent_Item = p_SQL_Tmp1
    '                Else
    '                    If InStr(p_SQL_Tmp1, ",", CompareMethod.Text) > 0 Then
    '                        p_Parent_Item = Mid(p_SQL_Tmp1, 2, InStr(p_SQL_Tmp1, ",", CompareMethod.Text) - 2)
    '                    Else
    '                        p_Parent_Item = Mid(p_SQL_Tmp1, 2)
    '                    End If
    '                End If



    '            End If
    '            If UCase(p_Parent_Item) = UCase(":GLOBAL.COMCODE") Then
    '                p_SValue = g_CompanyCode
    '                p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
    '            ElseIf UCase(p_Parent_Item) = UCase(":GLOBAL.USERNAME") Then
    '                p_SValue = g_UserName
    '                p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
    '            Else
    '                p_Parent_Obj = p_Form.Controls.Find(p_Parent_Item, True)
    '                If Not p_Parent_Obj Is Nothing Then
    '                    If Not p_Parent_Obj(0).editvalue Is Nothing Then
    '                        'If p_Parent_Obj(0).editvalue.ToString.Trim <> "" Then
    '                        Select Case p_Parent_Obj(0).FieldType
    '                            Case "C"
    '                                p_SValue = p_Parent_Obj(0).editvalue.ToString.Trim
    '                                p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
    '                            Case "N"
    '                                If p_Parent_Obj(0).text = "" Then
    '                                    p_NValue = 0
    '                                Else
    '                                    p_NValue = p_Parent_Obj(0).editvalue.ToString.Trim
    '                                End If
    '                                ' p_NValue = p_Parent_Obj(0).text
    '                                p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, p_NValue, 1)
    '                            Case "D"
    '                                p_SValue = p_Parent_Obj(0).editvalue.ToString.Trim
    '                                p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
    '                            Case Else
    '                                Exit Function

    '                        End Select

    '                        ' End If

    '                    Else
    '                        p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
    '                    End If
    '                End If
    '            End If



    '        End If
    '        p_SQL_Tmp = p_SQL
    '    End While
    '    p_Parameter_Item = p_SQL
    'End Function
    'Lay cau truc cac bang duoi Db
    'ANHQH
    '01/01/2012

    Private Function p_TableStructure(ByVal p_TableHead As String, _
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
                    'p_Table = g_Service.mod_SYS_GET_DATATABLE_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQL)


                End If
                p_DBDataSet.Tables.Add(p_Table)
                'p_Sysbatch = Nothing
            End If
        Catch ex As Exception
            g_Module.ModErrExceptionNew(Err.Number, ex.Message)
            p_TableStructure = False

        End Try
        '  p_Sysbatch = Nothing
    End Function




    'ANHHQ
    '21/11/2011
    'Ham thuc hien select ma fill du lieu vao p_BindingSource1 
    Private Function Mod_Get_BindingSource(ByVal p_SQL As String, _
                                ByRef p_BindingSource1 As BindingSource, _
                                ByVal p_Table As String, ByVal p_FieldKey As String, _
                                ByRef p_Page_Total As Integer, _
                                Optional ByVal p_GetB1 As Boolean = False, _
                                 Optional ByVal p_Where As String = "", _
                                Optional ByVal p_RowNum As Integer = 0, _
                                Optional ByVal p_PageNum As Integer = 1) As Boolean
        'Dim p_MnuSystem As New SystemBatch.Class1(g_Company_Host, g_Company_DB_Name)
        Dim p_Mod_Get_Gird As DataTable = Nothing
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

            Else

            End If
            If Not p_Mod_Get_Gird Is Nothing Then Exit Function
            p_BindingSource1.DataSource = p_Mod_Get_Gird
            p_BindingSource1.ResetBindings(True)

        Catch ex As Exception
            g_Module.ModErrExceptionNew(Err.Number, ex.Message)
            Mod_Get_BindingSource = False
        End Try
    End Function


    Public Function p_Set_TrueGrid_Property_Page(ByRef p_Form As U_CusForm.XtraCusForm1, _
                                         ByRef p_Object As Object, Optional ByVal p_Requery As Boolean = False) As Boolean

        Dim p_Object_Item As Object

        ' Dim p_ItemName As String

        Dim p_Count As Integer
        Dim p_TabControl_Ind As Integer



        'Dim p_Count1 As Integer

        Dim p_TabPage As Object
        Dim p_FormLock As Boolean = False

        Dim p_TrueGrid As U_TextBox.TrueDBGrid


        '  Dim p_ControlKey As Boolean



        p_Set_TrueGrid_Property_Page = True

        Try
            p_FormLock = p_Form.FormLock
        Catch ex As Exception

        End Try


        '  If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
        Try

            For p_Count = 0 To p_Object.TabPages.Count - 1 'To 0 Step -1
                If p_Object.TabPages.Count > 1 Then
                    p_Object.SelectedTabPageIndex = p_TabControl_Ind
                End If


                p_Object_Item = p_Object.TabPages(p_Count)


                If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    p_Set_TrueGrid_Property_Page = p_Set_TrueGrid_Property_Page(p_Form,
                                          p_Object_Item,
                                                )
                    If p_Set_TrueGrid_Property_Page = False Then Exit Function
                Else
                    'If InStr(UCase(p_Object_Item.GetType.ToString), "XtraTabPage", CompareMethod.Text) > 0 Then
                    p_TabPage = p_Object_Item
                    'For p_Count1 = 0 To p_TabPage.Controls.Count - 1
                    For Each p_Object_Item In p_TabPage.Controls

                        If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                            p_Set_TrueGrid_Property_Page = p_Set_TrueGrid_Property_Page(p_Form,
                                                  p_Object_Item,
                                                        p_Requery)
                            If p_Set_TrueGrid_Property_Page = False Then Exit Function
                        Else
                            If InStr(UCase(p_Object_Item.GetType.ToString), pv_Type_TrueDBGridNew, CompareMethod.Text) > 0 Then
                                p_TrueGrid = CType(p_Object_Item, U_TextBox.TrueDBGrid)
                                p_Set_TrueGrid_Property(p_Form, p_TrueGrid, _
                                                            p_Requery, "")






                            End If
                        End If





                    Next

                    'End If
                End If
                p_Object.TabPages(p_Count).Select()
            Next
        Catch ex As Exception
            g_Module.ModErrExceptionNew(Err.Number, "Control Data Field Page: " & ex.Message)
            p_Set_TrueGrid_Property_Page = False
            ' MsgBox("Control Data Field Page: " & ex.Message)

        End Try


        '   End If
    End Function



    Public Function p_Set_TrueGrid_Property(ByRef p_Form As Object, _
                                              ByRef p_TrueGird As U_TextBox.TrueDBGrid, _
                                                   Optional ByVal p_Requery As Boolean = False, _
                                                   Optional ByVal p_WhereExt As String = "") As Boolean
        Dim p_GirdName As String
        Dim p_Rows() As DataRow
        Dim p_RowsNew As DataRow
        Dim p_FormName As String
        Dim p_Column As U_TextBox.GridColumn
        Dim p_SQL As String = ""
        Dim p_ViewName As String = ""
        Dim p_NoCustomize As Boolean = False
        Dim p_FieldExist As Boolean = False
        Dim p_OrderBy As String
        Dim p_DataSet As New DataSet
        Dim p_Allowinsert As String
        Dim p_Field As String
        Dim p_AutoColumnWidth As String
        '        Dim p_ColDate As New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Dim p_ColDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit

        Dim p_ColNumber As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit


        Dim p_ColTypeButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Dim p_ButtonEditTbl As New DataTable("ButtonEdit")
        Dim p_ButtonComboboxTbl As New DataTable("ButtonCombo")
        Dim p_Where As String = ""
        Dim p_NumberFormat As String = "############"
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Dim p_LocalDecimal As Integer
        Dim p_ColumnSum As Boolean = False
        Dim p_Row As DataRow
        Dim p_FormLock As Boolean = False
        Dim p_SQLCombo As String = ""
        Dim p_GridView As U_TextBox.GridView
        Dim p_BindingSource As New U_TextBox.U_BindingSource
        Dim p_B1Get As Boolean
        Dim p_CHECKUPD As Boolean = False
        Dim p_Count As Integer
        Dim p_Decimal As Integer
        Dim p_Column_Count As Integer = 0

        p_ButtonEditTbl.Columns.Add("ButtonEdit", GetType(Integer))
        p_ButtonComboboxTbl.Columns.Add("ButtonCombo", GetType(Integer))
        Try
            p_FormLock = p_Form.FormLock
        Catch ex As Exception

        End Try
        p_ButtonEditTbl.Clear()
        Try
            If g_TrueGirdName.Columns.Count > 0 Then
                p_Rows = g_TrueGirdName.Select("TrueGridName='" & UCase(p_TrueGird.Name) & "'")
                If p_Rows.Length <= 0 Then
                    p_Row = g_TrueGirdName.NewRow
                    p_Row.Item(0) = UCase(p_TrueGird.Name)
                    g_TrueGirdName.Rows.Add(p_Row)
                End If
            End If
            p_LocalDecimal = GetDecima(g_Currency)
            p_FormName = UCase(p_Form.Name)
            p_GirdName = UCase(p_TrueGird.Name)
            p_GridView = p_TrueGird.Views(0)
            p_GridView.OptionsBehavior.Editable = True

            p_GridView.OptionsNavigation.EnterMoveNextColumn = True
            p_B1Get = p_GridView.GetB1
            p_ViewName = UCase(p_GridView.ViewName)
            p_OrderBy = UCase(p_GridView.OrderBy)
            p_Where = UCase(p_GridView.Where)
            p_AutoColumnWidth = UCase(p_GridView.ColumnAutoWidth)
            p_Allowinsert = UCase(p_GridView.AllowInsert)
            p_Set_TrueGrid_Property = True
            If p_ViewName = "" Then
                p_Set_TrueGrid_Property = False
                Exit Function
            End If
            p_Field = ""
            If p_GridView.Columns.Count > 0 Then
                p_Column_Count = p_GridView.Columns.Count
            End If
            If p_Column_Count > 0 Then
                For Each p_Column In p_GridView.Columns
                    If p_Column.FieldView.ToString.Trim <> "" Then
                        If p_Field = "" Then
                            p_Field = p_Column.FieldView.ToString
                        Else
                            p_Field = p_Field & "," & p_Column.FieldView.ToString
                        End If
                    End If

                    'If UCase(p_Column.FieldView) = "CHECKUPD" Then
                    '    p_Column.Visible = False
                    'End If

                    'If p_Column.AllowUpdate = False Then
                    '    p_Column.OptionsColumn.AllowEdit = False
                    'End If
                Next
            End If

            If p_Field = "" Then
                ' p_Set_TrueGrid_Property = False
                'Exit Function
                p_SQL = " SELECT *  FROM  " & p_ViewName & " "

            Else
                p_SQL = " SELECT " & p_Field & " FROM  " & p_ViewName & " "
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
                p_GridView.LastQuery = p_SQL
            Catch ex As Exception

            End Try

            p_BindingSource.GridSource = True
            p_BindingSource.ViewName = p_ViewName

            If p_B1Get = True Then
                p_BindingSource.DataSource = g_Service.mod_SYS_GET_DATASET_Com(g_Company_Host, g_Company_DB_Name, g_DBUsr, g_DBPass, g_Port, p_SQL).Tables(0)
            Else
                Dim dt As DataTable
                If g_DBTYPE = "" Then
                    g_Service.Sys_GetParameterOracle(g_DBTYPE)
                End If
                If g_DBTYPE = "ORACLE" Then
                    dt = g_Service.SYS_GET_DATATABLE_Oracle(p_SQL)
                ElseIf g_DBTYPE = "SQL" Then
                    dt = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                End If

                If dt Is Nothing And p_SQL <> "" Then
                    MsgBox(p_SQL)
                    p_Set_TrueGrid_Property = False
                    Exit Function
                End If
                If p_GridView.AllowInsert = True Then

                    'anhqh
                    '20160609
                    '  p_RowsNew = dt.NewRow()
                    ' dt.Rows.Add(p_RowsNew)
                    p_GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
                End If

                p_BindingSource.DataSource = dt
            End If
            p_BindingSource.Loading = False
            If p_Requery = True Then
                p_BindingSource.ResetBindings(True)
                p_TrueGird.DataSource = p_BindingSource

                p_TrueGird.RefreshDataSource()
                p_GridView.RefreshData()
                Exit Function
            End If
            p_BindingSource.FormName = UCase(p_Form.name)
            p_TrueGird.DataSource = p_BindingSource
            p_BindingSource.ResetBindings(True)
            p_TrueGird.Refresh()
            If p_GridView.AllowInsert = True Then
                'p_GridView.AddNewRow()
            End If
            If p_Column_Count <= 0 Then
                Exit Function
            End If
            For p_Count = 0 To p_GridView.Columns.Count - 1
                p_Column = p_GridView.Columns.Item(p_Count)
                If InStr(UCase(p_Column.ColumnType.FullName.ToString.Trim), UCase("System.Int"), CompareMethod.Text) > 0 _
                    Or InStr(UCase(p_Column.ColumnType.FullName.ToString.Trim), UCase("System.Decima"), CompareMethod.Text) > 0 _
                                        Or p_Column.FieldType = "N" Or p_Column.FieldType = "F" Then


                    If p_Column.FormarNumber = True Then
                        If p_Column.LocalDecimal = True Then
                            If p_Column.Digit = True Then
                                p_Decimal = p_Column.NumberDecimal
                                If p_Decimal > 0 Then

                                    p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                                    p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                                    'p_ColNumber.

                                    If p_Column.ShowCalc = False Then
                                        p_ColNumber.Buttons(0).Visible = False
                                    End If


                                    p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                    p_ColNumber.DisplayFormat.FormatString = "#,###0." & Left(p_NumberFormat, p_Decimal - 1) & "0"
                                    p_ColNumber.EditMask = "#,###,###,###0." & Left(p_NumberFormat, p_Decimal - 1) & "0"
                                    p_Column.ColumnEdit = p_ColNumber


                                    'p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                                    p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                    'p_Column.DisplayFormat.FormatString = "c2"
                                    p_Column.DisplayFormat.FormatString = "#,###0." & Left(p_NumberFormat, p_Decimal - 1) & "0"

                                Else


                                    p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                                    p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True
                                    If p_Column.ShowCalc = False Then
                                        p_ColNumber.Buttons(0).Visible = False
                                    End If

                                    p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                    p_ColNumber.DisplayFormat.FormatString = "#,###0." & Left(p_NumberFormat, p_Decimal)
                                    p_ColNumber.EditMask = "#,###,###,###0." & Left(p_NumberFormat, p_Decimal)
                                    p_Column.ColumnEdit = p_ColNumber


                                    p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                    p_Column.DisplayFormat.FormatString = "#,###0." & Left(p_NumberFormat, p_Decimal)
                                End If

                            Else




                                p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
                                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                                p_ColNumber.AllowNullInput = DevExpress.Utils.DefaultBoolean.True

                                If p_Column.ShowCalc = False Then
                                    p_ColNumber.Buttons(0).Visible = False
                                End If

                                Try
                                    If p_Decimal.ToString.Trim <> "" Then
                                        p_ColNumber.DisplayFormat.FormatString = "#,###0." & Left(p_NumberFormat, p_Decimal - 1) & "0"
                                        p_ColNumber.EditMask = "#,###,###,###0." & Left(p_NumberFormat, p_Decimal - 1) & "0"
                                        p_Column.ColumnEdit = p_ColNumber


                                        p_Column.DisplayFormat.FormatString = "#,###0." & Left(p_NumberFormat, p_Decimal - 1) & "0"
                                    Else
                                        p_ColNumber.DisplayFormat.FormatString = "#,###0."
                                        p_ColNumber.EditMask = "#,###,###,###0."
                                        p_Column.ColumnEdit = p_ColNumber

                                        p_Column.DisplayFormat.FormatString = "#,###0."
                                    End If
                                Catch ex As Exception
                                    p_Column.DisplayFormat.FormatString = "#,###0."
                                End Try


                            End If
                        Else

                            p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

                            If p_Column.ShowCalc = False Then
                                p_ColNumber.Buttons(0).Visible = False
                            End If



                            p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            p_ColNumber.DisplayFormat.FormatString = "#############"
                            p_ColNumber.EditMask = "#############"
                            p_Column.ColumnEdit = p_ColNumber
                            p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            p_Column.DisplayFormat.FormatString = "#############"

                        End If
                    End If
                End If
                If p_Column.FieldView.ToString.Trim <> "" Then
                    p_Column.FieldName = p_Column.FieldView
                End If
                If UCase(p_Column.FieldView) = UCase("CHECKUPD") Then
                    p_CHECKUPD = True
                    p_Column.OptionsColumn.AllowEdit = False
                    ' p_Column.Visible = False
                End If

                If InStr(UCase(p_Column.ColumnType.FullName.ToString.Trim), UCase("System.Date"), CompareMethod.Text) > 0 Or p_Column.FieldType = "D" Then
                    p_ColDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
                    If p_Column.ShowDataTime = False Then
                        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy"
                        p_ColDate.EditMask = "dd/MM/yyyy"
                        p_Column.ColumnEdit = p_ColDate
                        p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        p_Column.DisplayFormat.FormatString = "dd/MM/yyyy"

                    Else
                        If p_Column.ShowOnlyTime = True Then
                            'p_ColDate.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
                            p_ColDate.Buttons.Item(0).Visible = False
                            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            p_ColDate.DisplayFormat.FormatString = "HH:mm:ss"
                            ' p_ColDate.DisplayFormat.FormatString = "u"
                            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                            ' p_ColDate.DisplayFormat.

                            ' p_ColDate.EditMask = "u"

                            p_ColDate.EditFormat.FormatString = "HH:mm:ss"
                            p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                            'p_ColDate.Mask.EditMask = "u"
                            p_ColDate.EditMask = "HH:mm:ss"
                            ' p_ColDate.FormatString = "G"
                            ' p_ColDate.Mask.UseMaskAsDisplayFormat = True

                            p_Column.ColumnEdit = p_ColDate
                            p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            p_Column.DisplayFormat.FormatString = "HH:mm:ss"
                        Else

                            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
                            ' p_ColDate.DisplayFormat.FormatString = "u"
                            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                            ' p_ColDate.DisplayFormat.

                            ' p_ColDate.EditMask = "u"

                            p_ColDate.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
                            p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                            'p_ColDate.Mask.EditMask = "u"
                            p_ColDate.EditMask = "dd/MM/yyyy HH:mm:ss"
                            ' p_ColDate.FormatString = "G"
                            ' p_ColDate.Mask.UseMaskAsDisplayFormat = True

                            p_Column.ColumnEdit = p_ColDate
                            p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            p_Column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
                        End If




                        ' p_Column.
                        ' p_Column.DisplayFormat.F
                        'p_Column.ShowBut()
                    End If


                End If

                If p_Column.Required = True Then
                    p_Column.AppearanceCell.BackColor = pv_Required_Back_Color
                    p_Column.AppearanceCell.BackColor2 = pv_Required_Back_Color
                End If
                If InStr(UCase(p_Column.ColumnEditName), UCase("RepositoryItemComboBox"), CompareMethod.Text) >= 1 Then
                    ColumnCombobox(p_Form, p_Column, p_B1Get)
                    'p_Row = p_ButtonComboboxTbl.NewRow
                    'p_Row.Item(0) = p_Count
                    'p_ButtonComboboxTbl.Rows.Add(p_Row)


                    Continue For
                End If
                If InStr(UCase(p_Column.ColumnEditName), UCase("RepositoryItemLookUpEdit"), CompareMethod.Text) >= 1 Then
                    p_AddColumnTypeCombobox(p_Form, p_Column, p_B1Get)


                    Continue For
                End If

                If InStr(UCase(p_Column.ColumnEditName), UCase("RepositoryItemCheckEdit"), CompareMethod.Text) >= 1 Then
                    'p_AddColumnTypeCombobox(p_Form, p_Column, p_B1Get)
                    p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                    p_ColType.ValueChecked = "Y"
                    p_ColType.ValueUnchecked = "N"
                    p_Column.ColumnEdit = p_ColType
                    Continue For
                End If


                If InStr(UCase(p_Column.ColumnEditName), UCase("RepositoryItemGridLookUpEdit"), CompareMethod.Text) >= 1 Then
                    p_AddColumntemGridLookUpEdit(p_Form, p_Column, p_B1Get)


                    Continue For
                End If


                If InStr(UCase(p_Column.ColumnEditName), UCase("RepositoryItemButtonEdit"), CompareMethod.Text) >= 1 Then
                    p_Row = p_ButtonEditTbl.NewRow
                    p_Row.Item(0) = p_Count
                    p_ButtonEditTbl.Rows.Add(p_Row)
                    ' p_AddColumnTypeButtonEditView1(p_TrueGird, p_GridView, p_Column.Name)
                    Continue For
                End If
                If p_Form.formEdit = False Then
                    p_Column.OptionsColumn.ReadOnly = True
                End If
            Next
            AddHandler p_GridView.FocusedColumnChanged, AddressOf GridView1_FocusedColumnChanged
            AddHandler p_GridView.ValidatingEditor, AddressOf GridView_ValidatingEditor
            AddHandler p_GridView.InitNewRow, AddressOf GridView1_InitNewRow

            AddHandler p_GridView.KeyPress, AddressOf GridView_KeyPress

            AddHandler p_GridView.CellValueChanged, AddressOf GridView1_CellValueChanged

            AddHandler p_GridView.CellValueChanging, AddressOf GridView1_CellValueChanging

            For p_Count = 0 To p_ButtonEditTbl.Rows.Count - 1
                If p_ButtonEditTbl.Rows(p_Count).Item(0).ToString.Trim <> "" Then
                    p_ColTypeButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
                    If p_Form.formEdit = False Then
                        p_ColTypeButtonEdit.ReadOnly = True
                    End If
                    p_ColTypeButtonEdit.Appearance.BackColor = Color.LightGray
                    p_ColTypeButtonEdit.Appearance.BackColor2 = Color.LightGray

                    p_TrueGird.RepositoryItems.Add(p_ColTypeButtonEdit)


                    AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Gridview_Column_Button_Click

                    AddHandler p_ColTypeButtonEdit.Validating, AddressOf Gridview_Column_EditValueChanged

                    AddHandler p_ColTypeButtonEdit.KeyPress, AddressOf GridView_KeyPress


                    'GridView_KeyPress
                    p_GridView.Columns(CInt(p_ButtonEditTbl.Rows(p_Count).Item(0).ToString.Trim)).ColumnEdit = p_ColTypeButtonEdit
                    p_GridView.Columns(CInt(p_ButtonEditTbl.Rows(p_Count).Item(0).ToString.Trim)).AppearanceCell.BackColor = Color.LightGray
                    p_GridView.Columns(CInt(p_ButtonEditTbl.Rows(p_Count).Item(0).ToString.Trim)).AppearanceCell.BackColor2 = Color.LightGray
                End If
            Next

            If p_Form.formEdit = False Then
                p_GridView.OptionsBehavior.ReadOnly = True
            End If

            p_GridView.BestFitColumns()
        Catch ex As Exception
            ' MsgBox(ex.Message)
            g_Module.ModErrExceptionNew(Err.Number, ex.Message)
            p_Set_TrueGrid_Property = False
        End Try



    End Function


    Private Sub GridView_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles GridView1.KeyPress
        Dim p_Column As U_TextBox.GridColumn
        Dim p_Grid As U_TextBox.GridView
        Try
            p_Grid = CType(sender, U_TextBox.GridView)
            p_Column = p_Grid.FocusedColumn
            If p_Column.ChangeFormStatus = False Then
                Exit Sub
            End If
        Catch ex As Exception

        End Try

        If e.Handled = False Then
            g_ValueType = 2
        End If
        If Asc(e.KeyChar) = 12 Then
            Column_Button_Click(sender)
        End If

        'Try
        '    If 
        'Catch ex As Exception

        'End Try
    End Sub




    Private Sub GridView1_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Dim p_Column As U_TextBox.GridColumn
        Dim p_Grid As U_TextBox.GridView
        Dim p_Form As U_CusForm.XtraCusForm1
        Dim p_trueGrid As U_TextBox.TrueDBGrid

        Try
            p_Grid = CType(sender, U_TextBox.GridView)
            p_Column = p_Grid.FocusedColumn
            p_trueGrid = p_Grid.GridControl
            p_Form = p_trueGrid.FindForm
            If p_Form.FormStatus = True Or p_Form.FormEdit = False Or p_Form.g_FormLoad = True Then
                Exit Sub
            End If
            p_Form.FormStatus = True
            p_Form.GridViewTableEdit(p_Grid)
            If p_Grid.CheckUpd = True Then
                p_Grid.SetFocusedRowCellValue("CHECKUPD", "Y")
            End If
            ''If p_Column.UpdateIfNull = "Y" Then
            ''    p_Grid.InvalidateRowCell(e.RowHandle, p_Column)
            ''End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub GridView_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) 'Handles GridView1.CellValueChanged

        If (g_ValueType = 2) Then
            Dim p_Form As Object
            Dim p_OldValue As String = ""
            Dim p_NewValue As String = ""
            Dim p_DataTable As DataTable
            Dim p_SQL As String = ""
            Dim p_Field As String = ""
            Dim p_Exist As Boolean = False
            Dim p_ButtonArr() As Object
            Dim p_ButtonOK As Object = Nothing
            Dim p_ItemBtn As String = ""
            Dim p_TrueGrid As U_TextBox.TrueDBGrid
            Dim p_GridView As U_TextBox.GridView
            Dim p_Count As Integer
            'Dim p_DataRow As DataRow
            Dim p_RowHandle As Integer
            Dim p_Column As U_TextBox.GridColumn
            Dim p_DataArr() As DataRow

            Dim p_ColumnInt As Boolean = False
            Dim dt As New DataTable
            Dim p_BindingSourceTmp As New U_TextBox.U_BindingSource
            Dim p_DataRow As DataRow
            Dim p_CellValue As String
            ' Dim p_DataCheck As DataTable
            Dim p_ColumnName As String
            Dim p_WhereNew As String
            Dim p_Error As Boolean
            Try
                'Dim p_Column As U_TextBox.GridColumn
                Dim p_Grid As U_TextBox.GridView
                p_Grid = CType(sender, U_TextBox.GridView)
                If e.Value.ToString.Trim = "" Then Exit Sub

                p_Column = p_Grid.FocusedColumn
                If p_Column.ChangeFormStatus = False Then
                    Exit Sub
                End If


                If g_Form.FormLock = True Then Exit Sub
                If e.Valid = False Then Exit Sub
                p_GridView = CType(sender, U_TextBox.GridView)
                p_TrueGrid = p_GridView.GridControl

                p_RowHandle = p_GridView.FocusedRowHandle
                p_Column = p_GridView.FocusedColumn
                p_RowHandle = p_GridView.FocusedRowHandle
                'If UCase(p_Column.Name) = UCase(p_GridView.ColumnKey) Then
                ' If p_Column.ColumnKey = True Then
                ' p_FieldName = p_GridView.FocusedColumn.FieldName

                p_DataRow = p_GridView.GetDataRow(p_RowHandle)
                If p_DataRow.Item("CHECKUPD").ToString.Trim = "I" Then
                    Try
                        p_CellValue = e.Value   ' p_DataRow.Item(p_TrueGrid.ColumnKey).ToString
                    Catch ex As Exception
                        p_DataTable = Nothing
                        g_Module.ErrException(Err.Number, ex.Message)
                        Exit Sub
                    End Try
                    ' If p_GridView.ColumnKey.ToString.Trim = "" Then Exit Sub

                    p_WhereNew = get_Where_Config(Nothing, p_GridView, p_RowHandle, p_Error)

                    If p_Error = True Then
                        e.Valid = False
                        dt = Nothing
                        Exit Sub
                    End If

                    ' If p_CellValue.ToString.Trim <> "" Then
                    If p_WhereNew <> "" Then
                        If UCase(p_GridView.Columns.Item(p_GridView.ColumnKey.ToString.Trim).ColumnType.Name) <> UCase("String") Then
                            'p_RowsCheck = p_DataCheck.Select(p_ColumnKey & "=" & p_CellValue)
                            p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_GridView.TableName & p_WhereNew
                        Else
                            p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_GridView.TableName & p_WhereNew & "'"
                        End If
                        dt = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
                        If dt.Rows.Count > 0 Then

                            p_GridView.ClearColumnsFilter()

                            e.ErrorText = p_CellValue & "- Đã tồn tại trong hệ thống"
                            e.Valid = False
                            dt = Nothing
                            Exit Sub
                            'End If
                        End If
                    End If
                    'End If
                End If
                ' End If
                If p_Column.Name <> "CHECKUPD" Then
                    g_Form.FormStatus = True

                    Try
                        If g_Form.ButtonSave.ToString.Trim <> "" Then
                            p_ItemBtn = g_Form.ButtonSave
                        End If
                    Catch ex As Exception

                    End Try
                    If p_ItemBtn.ToString.Trim <> "" Then
                        p_ButtonArr = g_Form.Controls.Find(p_ItemBtn, True)
                        If Not p_ButtonArr Is Nothing Then
                            If p_ButtonArr.Length > 0 Then
                                p_ButtonOK = p_ButtonArr(0)
                                p_ButtonOK.Text = g_Form.CaptionUpd
                            End If
                        End If
                    End If
                    p_DataRow = p_GridView.GetDataRow(p_RowHandle)
                    If Not p_DataRow Is Nothing Then
                        If Not p_DataRow.Item("CHECKUPD") Is Nothing Then
                            If p_DataRow.Item("CHECKUPD").ToString.Trim <> "I" And p_DataRow.Item("CHECKUPD").ToString.Trim <> "Y" _
                                    And p_DataRow.Item("CHECKUPD").ToString.Trim <> "R" And g_Form.FormEdit = True Then
                                p_GridView.SetRowCellValue(p_RowHandle, "CHECKUPD", "Y")
                            End If
                        End If
                    End If



                End If

                Try
                    If p_GridView.Columns(p_Column.Name).ColumnEdit Is Nothing Then Exit Sub
                Catch ex As Exception
                    If p_GridView.Columns(p_Column.FieldName).ColumnEdit Is Nothing Then Exit Sub
                End Try
                '   If p_GridView.Columns(p_Column.Name).ColumnEdit Is Nothing Then Exit Sub

                If e.Value.ToString.Trim = "" Then

                    p_BindingSourceTmp = p_GridView.DataSource
                    dt = CType(p_BindingSourceTmp.DataSource, DataTable)


                    ' For p_Count = 1 To 4
                    p_ColumnName = p_Column.CFLReturn1 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    If p_ColumnName <> "" Then
                        If UCase(dt.Columns.Item(p_ColumnName).DataType.Name) = "STRING" Then
                            dt.Rows(p_RowHandle).Item(p_ColumnName) = vbNullString
                        Else
                            dt.Rows(p_RowHandle).Item(p_ColumnName) = 0
                        End If
                    End If
                    p_ColumnName = p_Column.CFLReturn2 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    If p_ColumnName <> "" Then
                        If UCase(dt.Columns.Item(p_ColumnName).DataType.Name) = "STRING" Then
                            dt.Rows(p_RowHandle).Item(p_ColumnName) = vbNullString
                        Else
                            dt.Rows(p_RowHandle).Item(p_ColumnName) = 0
                        End If
                    End If

                    p_ColumnName = p_Column.CFLReturn3 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    If p_ColumnName <> "" Then
                        If UCase(dt.Columns.Item(p_ColumnName).DataType.Name) = "STRING" Then
                            dt.Rows(p_RowHandle).Item(p_ColumnName) = vbNullString
                        Else
                            dt.Rows(p_RowHandle).Item(p_ColumnName) = 0
                        End If
                    End If
                    p_ColumnName = p_Column.CFLReturn4 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    If p_ColumnName <> "" Then
                        If UCase(dt.Columns.Item(p_ColumnName).DataType.Name) = "STRING" Then
                            dt.Rows(p_RowHandle).Item(p_ColumnName) = vbNullString
                        Else
                            dt.Rows(p_RowHandle).Item(p_ColumnName) = 0
                        End If
                    End If

                    p_ColumnName = p_Column.CFLReturn5 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    If p_ColumnName <> "" Then
                        If UCase(dt.Columns.Item(p_ColumnName).DataType.Name) = "STRING" Then
                            dt.Rows(p_RowHandle).Item(p_ColumnName) = vbNullString
                        Else
                            dt.Rows(p_RowHandle).Item(p_ColumnName) = 0
                        End If
                    End If

                    p_ColumnName = p_Column.CFLReturn6 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    If p_ColumnName <> "" Then
                        If UCase(dt.Columns.Item(p_ColumnName).DataType.Name) = "STRING" Then
                            dt.Rows(p_RowHandle).Item(p_ColumnName) = vbNullString
                        Else
                            dt.Rows(p_RowHandle).Item(p_ColumnName) = 0
                        End If
                    End If

                    p_ColumnName = p_Column.CFLReturn7 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    If p_ColumnName <> "" Then
                        If UCase(dt.Columns.Item(p_ColumnName).DataType.Name) = "STRING" Then
                            dt.Rows(p_RowHandle).Item(p_ColumnName) = vbNullString
                        Else
                            dt.Rows(p_RowHandle).Item(p_ColumnName) = 0
                        End If
                    End If
                    'Next
                End If
                p_SQL = p_Column.SQLString ' p_DataArr(0).Item("CFLSQL").ToString.Trim

                If p_SQL = "" Then Exit Sub

                Dim p_ValueCheck As String


                p_ValueCheck = e.Value.ToString.Trim
                p_SQL = g_Module.Parameter_Item(g_Form, p_SQL)
                If p_ValueCheck = "" Then Exit Sub
                If UCase(p_GridView.Columns(p_Column.FieldView).ColumnType.Name.ToString.Trim) <> "STRING" Then
                    p_ColumnInt = True
                End If
                If p_ColumnInt = True Then
                    p_SQL = "SELECT * FROM (" & p_SQL & ") ABC WHERE " & p_Column.FieldView & "=" & p_ValueCheck
                Else
                    p_SQL = "SELECT * FROM (" & p_SQL & ") ABC WHERE " & p_Column.FieldView & "=N'" & p_ValueCheck & "'"
                End If

                p_DataTable = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)



                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        p_Exist = True
                    End If
                End If

                If p_Exist = True Then   ''Da co trong he thong danh muc

                    p_BindingSourceTmp = p_GridView.DataSource

                    dt = CType(p_BindingSourceTmp.DataSource, DataTable)

                    If p_RowHandle < 0 Then
                        p_GridView.UpdateCurrentRow()
                        ' p_GridView.RefreshData()
                        ' p_GridView.MoveNext()
                        ' p_GridView.MovePrev()
                        p_RowHandle = p_GridView.FocusedRowHandle
                    End If
                    'dt = CType(p_BindingSourceTmp.DataSource, DataTable)

                    p_GridView.SetRowCellValue(p_RowHandle, p_Column.FieldView, p_DataTable.Rows(0).Item(0).ToString.Trim)


                    p_ColumnName = p_Column.CFLReturn1 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    If p_ColumnName <> "" Then
                        ' dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(1).ToString.Trim
                        p_GridView.SetRowCellValue(p_RowHandle, p_ColumnName, p_DataTable.Rows(0).Item(1).ToString.Trim)
                    End If

                    p_ColumnName = p_Column.CFLReturn2 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    If p_ColumnName <> "" Then
                        ' dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(1).ToString.Trim
                        p_GridView.SetRowCellValue(p_RowHandle, p_ColumnName, p_DataTable.Rows(0).Item(2).ToString.Trim)
                    End If

                    p_ColumnName = p_Column.CFLReturn3 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    If p_ColumnName <> "" Then
                        ' dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(1).ToString.Trim
                        p_GridView.SetRowCellValue(p_RowHandle, p_ColumnName, p_DataTable.Rows(0).Item(3).ToString.Trim)
                    End If


                    p_ColumnName = p_Column.CFLReturn4 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    If p_ColumnName <> "" Then
                        ' dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(1).ToString.Trim
                        p_GridView.SetRowCellValue(p_RowHandle, p_ColumnName, p_DataTable.Rows(0).Item(4).ToString.Trim)
                    End If

                    p_ColumnName = p_Column.CFLReturn5 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    If p_ColumnName <> "" Then
                        ' dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(1).ToString.Trim
                        p_GridView.SetRowCellValue(p_RowHandle, p_ColumnName, p_DataTable.Rows(0).Item(5).ToString.Trim)
                    End If

                    p_ColumnName = p_Column.CFLReturn6 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    If p_ColumnName <> "" Then
                        ' dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(1).ToString.Trim
                        p_GridView.SetRowCellValue(p_RowHandle, p_ColumnName, p_DataTable.Rows(0).Item(6).ToString.Trim)
                    End If

                    p_ColumnName = p_Column.CFLReturn7 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    If p_ColumnName <> "" Then
                        ' dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(1).ToString.Trim
                        p_GridView.SetRowCellValue(p_RowHandle, p_ColumnName, p_DataTable.Rows(0).Item(7).ToString.Trim)
                    End If


                    'If dt.Rows.Count > 0 Then
                    '    dt.Rows(p_RowHandle).Item(p_Column.FieldView) = p_DataTable.Rows(0).Item(0).ToString.Trim
                    '    ' For p_Count = 1 To 4
                    '    p_ColumnName = p_Column.CFLReturn1 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    '    If p_ColumnName <> "" Then
                    '        dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(1).ToString.Trim
                    '    End If
                    '    p_ColumnName = p_Column.CFLReturn2 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    '    If p_ColumnName <> "" Then
                    '        dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(2).ToString.Trim
                    '    End If

                    '    p_ColumnName = p_Column.CFLReturn3 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    '    If p_ColumnName <> "" Then
                    '        dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(3).ToString.Trim

                    '    End If

                    '    p_ColumnName = p_Column.CFLReturn4 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                    '    If p_ColumnName <> "" Then
                    '        dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(4).ToString.Trim
                    '    End If


                    '    '  Next

                    'End If
                Else    'Chua co trong danh muc
                    ' MsgBox("Giá tri không hợp lệ")
                    If p_Column.ValidateValue = True Then
                        e.ErrorText = "Giá trị không hợp lệ"
                        e.Valid = False
                        Exit Sub
                    End If


                End If
                g_ValueType = 0

            Catch ex As Exception

            End Try

        End If
    End Sub




    Public Sub GridNavigatorButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_DesError As String = ""
        If e.Handled = True Then Exit Sub
        Dim p_Control As DevExpress.XtraGrid.GridControlNavigator
        Dim p_TrueGrid As U_TextBox.U_TrueDBGrid
        Dim p_SQL As String = ""
        Dim p_Table As String = ""
        Dim p_ColumnKey As String = ""
        Dim p_FieldType As String = ""
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim p_DataRow As DataRow
        Dim p_dataTbl As DataTable
        Dim p_BindingSource As System.Windows.Forms.BindingSource

        Dim p_Desc As String = ""
        'If e.Handled = False Then Exit Sub

        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            'e.Handled = True
            p_Control = sender
            p_TrueGrid = CType(p_Control.Parent, U_TextBox.U_TrueDBGrid)
            If p_TrueGrid.DefaultRemove = False Then Exit Sub
            If g_Module.ShowMessage(g_Form,
                                       "MS0002",
                    "Bạn có chắc chắn muốn thực hiện không?",
                    True,
                    "Có",
                    True,
                    "Không",
                     False,
                    "",
                   2) = Windows.Forms.DialogResult.No Then
                e.Handled = True
                Exit Sub
            End If
            Try

                p_Table = p_TrueGrid.TableName.ToString.Trim
                p_ColumnKey = p_TrueGrid.ColumnKey.ToString.Trim
                p_FieldType = p_TrueGrid.ColumnKeyType.ToString.Trim
                p_GridView = p_TrueGrid.Views(0)
                If p_GridView.FocusedRowHandle >= 0 Then

                    p_DataRow = p_GridView.GetDataRow(p_GridView.FocusedRowHandle)
                    If (p_FieldType = "N" Or p_FieldType = "C") And p_ColumnKey <> "" And p_Table <> "" Then

                        p_BindingSource = p_TrueGrid.DataSource
                        p_dataTbl = CType(p_BindingSource.DataSource, DataTable)
                        If p_DataRow.Item(p_ColumnKey).ToString.Trim <> "" Then
                            If p_FieldType = "N" Then
                                p_SQL = "DELETE FROM " & p_Table & " WHERE " & p_ColumnKey & "=" & p_DataRow.Item(p_ColumnKey)
                            Else
                                p_SQL = "DELETE FROM " & p_Table & " WHERE " & p_ColumnKey & "='" & p_DataRow.Item(p_ColumnKey) & "'"
                            End If
                            p_DataRow = Nothing

                            p_DataRow = g_LineRemove.NewRow
                            p_DataRow.Item(0) = p_SQL
                            g_LineRemove.Rows.Add(p_DataRow)
                            p_dataTbl.Rows.RemoveAt(p_GridView.FocusedRowHandle)
                        Else
                            p_dataTbl.Rows.RemoveAt(p_GridView.FocusedRowHandle)
                        End If

                        If g_Form.FormStatus = False Then
                            Dim p_ButtonSave() As Object
                            p_ButtonSave = g_Form.Controls.Find(g_Form.ButtonSave, True)
                            g_Form.FormStatus = True
                            If p_ButtonSave.Length > 0 Then
                                p_ButtonSave(0).text = g_Form.CaptionUpd
                            End If

                        End If

                        e.Handled = True
                        p_TrueGrid.Refresh()

                        'If g_XtraServicesObj.Sys_Execute(p_SQL, p_Desc) = False Then
                        '    p_XtraModuleObj.ModErrExceptionNew("", p_Desc)
                        '    e.Handled = True
                        '    Exit Sub
                        'End If
                    Else
                        g_Module.ModErrExceptionNew("MS0003", "")
                        e.Handled = True
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                g_Module.ModErrExceptionNew(Err.Number, ex.Message)
                e.Handled = True
                Exit Sub
            End Try

        End If

    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        Dim p_Form As U_CusForm.XtraCusForm1
        Dim p_GridView As U_TextBox.GridView
        Dim p_DataRow As DataRow
        Dim p_ButtonArr() As Control

        Dim p_ButtonOK As Control
        Dim p_Column As U_TextBox.GridColumn
        Dim p_Grid As U_TextBox.GridView
        p_Grid = CType(sender, U_TextBox.GridView)
        p_Column = p_Grid.FocusedColumn
        If p_Column.ChangeFormStatus = False Then
            GoTo Line_TT
        End If

        Dim p_DataTable As DataTable
        Dim p_Dinding As BindingSource

        ' Dim p_TrueGrid As U_TextBox.TrueDBGrid
        'If e. = False Then
        'p_TrueGrid = 
        p_GridView = CType(sender, U_TextBox.GridView)
        ' p_Dinding = p_GridView.DataSource
        ' p_DataTable = CType(p_Dinding.DataSource, DataTable)
        p_Form = sender.GridControl.FindForm()
        ' p_Form = p_TrueGrid.FindForm()
        If p_Form.FormLock = False Then
            p_DataRow = p_GridView.GetDataRow(p_GridView.FocusedRowHandle)
            If Not p_DataRow Is Nothing And p_GridView.CheckUpd = True Then
                Try
                    If Not p_DataRow.Item("CHECKUPD") Is Nothing Then
                        If p_DataRow.Item("CHECKUPD").ToString.Trim <> "I" And p_DataRow.Item("CHECKUPD").ToString.Trim <> "Y" _
                            And p_DataRow.Item("CHECKUPD").ToString.Trim <> "R" And p_Form.FormEdit = True Then
                            p_GridView.SetRowCellValue(p_GridView.FocusedRowHandle, "CHECKUPD", "Y")


                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Không xác định trường CheckUpd")
                End Try

            End If
            p_Form.GridViewTableEdit(p_GridView)
            p_Form.FormStatus = True
            g_ValueType = 2
            If p_Form.ButtonSave.ToString.Trim <> "" Then
                p_ButtonArr = g_Form.Controls.Find(p_Form.ButtonSave.ToString.Trim, True)
                If Not p_ButtonArr Is Nothing Then
                    If p_ButtonArr.Length > 0 Then
                        p_ButtonOK = p_ButtonArr(0)
                        p_ButtonOK.Text = g_Form.CaptionUpd
                    End If
                End If
            End If
        End If
Line_TT:
        'End If
    End Sub

    'Private Sub GridView_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles GridView1.KeyPress
    '    Dim p_Form As U_CusForm.XtraCusForm1
    '    If e.Handled = False Then
    '        p_Form = sender.findform()
    '        If p_Form.FormLock = False Then
    '            p_Form.FormStatus = True
    '            g_ValueType = 2
    '        End If

    '    End If
    '    'Try
    '    '    If 
    '    'Catch ex As Exception

    '    'End Try
    'End Sub

    Private Sub Gridview_Column_GridLookUpEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles GridView1.InitNewRow
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView

        'Dim p_GridView11 As DevExpress.XtraGrid.Views.Grid.co
        'DataGridViewComboBoxCell
        Dim p_RowID As Integer
        Dim p_Datarow As DataRow
        Dim p_Column As U_TextBox.GridColumn
        Try
            Dim p_Item As DevExpress.XtraEditors.GridLookUpEdit
            Dim p_TrueGrid As U_TextBox.TrueDBGrid

            p_Item = CType(sender, DevExpress.XtraEditors.GridLookUpEdit)

            p_TrueGrid = CType(p_Item.Parent, U_TextBox.TrueDBGrid)

            p_GridView = p_TrueGrid.Views(0)
            p_Column = p_GridView.FocusedColumn
            p_Datarow = p_GridView.GetFocusedDataRow
            ' p_AddColumntemGridLookUpEdit(g_Form, p_Column, False, p_Datarow)

        Catch ex As Exception

        End Try
    End Sub


    Private Sub Gridview_Column_LookUpEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles GridView1.InitNewRow
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim p_RowID As Integer
        Dim p_Datarow As DataRow
        Dim p_Column As U_TextBox.GridColumn
        Try
            Dim p_Item As DevExpress.XtraEditors.LookUpEdit
            Dim p_TrueGrid As U_TextBox.TrueDBGrid

            p_Item = CType(sender, DevExpress.XtraEditors.LookUpEdit)

            p_TrueGrid = CType(p_Item.Parent, U_TextBox.TrueDBGrid)

            p_GridView = p_TrueGrid.Views(0)
            p_Column = p_GridView.FocusedColumn
            p_Datarow = p_GridView.GetFocusedDataRow
            ' p_AddColumntemGridLookUpEdit(g_Form, p_Column, False, p_Datarow)

        Catch ex As Exception

        End Try
    End Sub



    Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) ' Handles GridView1.InitNewRow
        Dim p_GridView As U_TextBox.GridView

        Dim p_RowID As Integer


        Dim p_Form As Object 'System.Windows.Forms.Form
        Dim p_TrueGrid As U_TextBox.TrueDBGrid

        Try


            p_GridView = CType(sender, U_TextBox.GridView)
            p_TrueGrid = p_GridView.GridControl
            p_Form = p_TrueGrid.Parent
            If p_Form.formedit = True And p_GridView.CheckUpd = True Then

                'End If
                p_RowID = p_GridView.FocusedRowHandle

                p_GridView.SetRowCellValue(p_GridView.FocusedRowHandle, "CHECKUPD", "I")
            End If
        Catch ex As Exception

        End Try
    End Sub

    ' Private Sub GridView_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) 'Handles GridView1.MouseMove
    Private Sub GridView1_FocusedColumnChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs)


        Dim p_Table_Name As String = ""
        Dim p_Field_Name As String = ""
        Dim p_View_Name As String = ""
        Dim p_Form As Object 'System.Windows.Forms.Form
        Dim GridView As U_TextBox.GridView
        Dim p_TrueGrid As U_TextBox.TrueDBGrid

        GridView = CType(sender, U_TextBox.GridView)
        p_TrueGrid = GridView.GridControl

        p_Table_Name = GridView.TableName
        'p_Field_Name = Me.FieldName
        p_View_Name = GridView.ViewName
        p_Form = p_TrueGrid.Parent

        Try
            If Not p_Form.p_XtraToolTripLabel Is Nothing Then
                ' Me.ToolTip = "NAME(" & Me.Name & ") VIEW(" & p_View_Name & ") TAB(" & p_Table_Name & ") FIELD (" & p_Field_Name & ")"
                ' Try
                ' p_Form.p_XtraToolTripLabel.Text = " Name(" & p_TrueGrid.Name & ") View(" & p_View_Name & ") Table(" & p_Table_Name & ") Col (" & GridView.FocusedColumn.Name & ")"
                '        Catch ex As Exception

                'End Try

            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub p_AddColumnTypeButtonEditView1(ByRef p_TrueGird As U_TextBox.TrueDBGrid,
                                      ByRef p_GridView As U_TextBox.GridView,
                                      ByVal p_ColumnIndex As String)
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Dim p_DesError As String = ""
        Dim p_Object() As Object
        Dim p_GridView11 As U_TextBox.GridView
        Try
            ' p_Object =
            p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
            p_TrueGird.RepositoryItems.Add(p_ColType)
            ' p_TrueGird.RepositoryItems.Item(0) = p_ColType
            p_GridView.Columns(p_ColumnIndex).ColumnEdit = p_ColType
            AddHandler p_ColType.ButtonClick, AddressOf Gridview_Column_Button_Click


            ' p_GridView.Columns(p_ColumnIndex).ColumnEdit = p_ColType

        Catch ex As Exception
            g_Module.ModErrExceptionNew(Err.Number, ex.Message)
        End Try
    End Sub


    'Public Sub Gridview_Column_Combo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim p_Column As U_TextBox.GridColumn
    '    Dim p_TrueGrid As U_TextBox.TrueDBGrid
    '    Dim p_GridView As U_TextBox.GridView
    '    Dim p_ButtonEdit As DevExpress.XtraEditors.ComboBoxEdit
    '    Dim p_DataRow As DataRow
    '    Dim p_BindingSource As U_TextBox.U_BindingSource
    '    Dim p_Datatable As DataTable
    '    Dim p_SQL As String

    '    p_ButtonEdit = CType(sender, DevExpress.XtraEditors.ComboBoxEdit)

    '    p_TrueGrid = CType(p_ButtonEdit.Parent, U_TextBox.TrueDBGrid)
    '    p_GridView = p_TrueGrid.Views(0)
    '    p_Column = p_GridView.FocusedColumn
    '    If p_Column.RefreshSource = False Then
    '        Exit Sub
    '    End If

    '    'p_SQL = "select MeterId  from vwMeterAll where LoadingSite='Bo' and ProductCode='0201001'"
    '    ''Try
    '    'p_Datatable = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
    '    ''Catch ex As Exception

    '    ''End Try

    '    'p_BindingSource = New U_TextBox.U_BindingSource
    '    'p_BindingSource.Loading = True
    '    'p_BindingSource.DataSource = p_Datatable

    '    'If p_ButtonEdit.DataBindings.Count > 0 Then
    '    '    p_ButtonEdit.DataBindings.RemoveAt(0)
    '    'End If
    '    'p_ButtonEdit.DataBindings.Add("EditValue", p_BindingSource, "MeterId")
    '    'p_Object.DataBindings.Add("EditValue", p_BindingSource, p_ItemName)


    '    'p_ButtonEdit.

    '    p_DataRow = p_GridView.GetFocusedDataRow
    '    'p_Column = p_GridView.FocusedColumn
    '    If p_Column.OptionsColumn.ReadOnly = True Then Exit Sub
    '    If p_Column.RefreshSource = False Then Exit Sub

    '    ColumnCombobox(g_Form, p_Column, False, True, p_DataRow)
    'End Sub

    Public Sub Gridview_Column_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_Abc As String

        Dim p_ButtonEdit As DevExpress.XtraEditors.ButtonEdit
        Dim p_Gridview As U_TextBox.GridView
        Dim p_True As U_TextBox.TrueDBGrid
        Dim p_Column As U_TextBox.GridColumn
        Dim p_Datarow As DataRow
        ' Dim p_ColumnName As String
        Dim p_BindingSourceTmp As U_TextBox.U_BindingSource
        Dim dt As DataTable
        Dim p_RowHandle As Integer
        Dim p_SQL As String
        Dim p_ColumnInt As Boolean
        Dim p_Exist As Boolean = False
        'Dim p_Form As U_CusForm.XtraCusForm1


        p_ButtonEdit = CType(sender, DevExpress.XtraEditors.ButtonEdit)
        p_True = p_ButtonEdit.Parent
        p_Gridview = p_True.Views(0)
        p_RowHandle = p_Gridview.FocusedRowHandle
        p_BindingSourceTmp = p_Gridview.DataSource
        p_Column = p_Gridview.FocusedColumn
        p_Datarow = p_Gridview.GetFocusedDataRow
        If p_Datarow Is Nothing Then
            Exit Sub
        End If
        p_Abc = ""
        'If e.Value.ToString.Trim = "" Then

        '    p_BindingSourceTmp = p_GridView.DataSource
        'dt = CType(p_BindingSourceTmp.DataSource, DataTable)


        '' For p_Count = 1 To 4
        'p_ColumnName = p_Column.CFLReturn1 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
        'If p_ColumnName <> "" Then
        '    If UCase(dt.Columns.Item(p_ColumnName).DataType.Name) = "STRING" Then
        '        dt.Rows(p_RowHandle).Item(p_ColumnName) = vbNullString
        '    Else
        '        dt.Rows(p_RowHandle).Item(p_ColumnName) = 0
        '    End If
        'End If
        'p_ColumnName = p_Column.CFLReturn2 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
        'If p_ColumnName <> "" Then
        '    If UCase(dt.Columns.Item(p_ColumnName).DataType.Name) = "STRING" Then
        '        dt.Rows(p_RowHandle).Item(p_ColumnName) = vbNullString
        '    Else
        '        dt.Rows(p_RowHandle).Item(p_ColumnName) = 0
        '    End If
        'End If

        'p_ColumnName = p_Column.CFLReturn3 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
        'If p_ColumnName <> "" Then
        '    If UCase(dt.Columns.Item(p_ColumnName).DataType.Name) = "STRING" Then
        '        dt.Rows(p_RowHandle).Item(p_ColumnName) = vbNullString
        '    Else
        '        dt.Rows(p_RowHandle).Item(p_ColumnName) = 0
        '    End If
        'End If
        'p_ColumnName = p_Column.CFLReturn4 ' p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
        'If p_ColumnName <> "" Then
        '    If UCase(dt.Columns.Item(p_ColumnName).DataType.Name) = "STRING" Then
        '        dt.Rows(p_RowHandle).Item(p_ColumnName) = vbNullString
        '    Else
        '        dt.Rows(p_RowHandle).Item(p_ColumnName) = 0
        '    End If
        'End If
        ' Next
        'End If
        p_SQL = p_Column.SQLString ' p_DataArr(0).Item("CFLSQL").ToString.Trim

        If p_SQL = "" Then Exit Sub

        Dim p_ValueCheck As String

        '  p_Form = g_Form
        If Not p_ButtonEdit.EditValue Is Nothing Then
            p_ValueCheck = p_ButtonEdit.EditValue.ToString.Trim
        Else
            Exit Sub
        End If

        If p_Column.ValidateValue = False Then
            Exit Sub
        End If

        p_SQL = p_Parameter_Item(g_Form, p_SQL, p_Datarow) 'g_Module.Parameter_Item(g_Form, p_SQL, p_Datarow)
        If p_ValueCheck = "" Then Exit Sub
        If UCase(p_Gridview.Columns(p_Column.Name).ColumnType.Name.ToString.Trim) <> "STRING" Then
            p_ColumnInt = True
        End If
        If p_ColumnInt = True Then
            p_SQL = "SELECT * FROM (" & p_SQL & ") ABC WHERE " & p_Column.FieldView & "=" & p_ValueCheck
        Else
            p_SQL = "SELECT * FROM (" & p_SQL & ") ABC WHERE " & p_Column.FieldView & "=N'" & p_ValueCheck & "'"
        End If

        dt = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)



        If Not dt Is Nothing Then
            If dt.Rows.Count > 0 Then
                p_Exist = True
            End If
        End If

        If p_Exist = False Then
            ' p_XtraModuleObj.ModErrExceptionNew("MS008", "Gia tri không hợp lệ")
            g_Module.ModErrExceptionNew("MS008", "Giá trị không hợp lệ.")
            ' p_ButtonEdit.ErrorText = "Giá trị không hợp lệ"
            'p_Gridview.InvalidateRow(p_Gridview.FocusedRowHandle)
            p_ButtonEdit.EditValue = p_Datarow.Item(p_Column.FieldView).ToString.Trim
            'p_ButtonEdit.Undo()
            Exit Sub
        End If


    End Sub



    Public Sub Column_Button_Click(ByVal Sender As Object)

        Dim p_TrueGrid As U_TextBox.TrueDBGrid
        Dim p_GridView As U_TextBox.GridView
        Dim p_ButtonArr() As Object
        Dim p_ButtonOK As Object = Nothing
        Dim p_ItemBtn As String = ""
        Dim p_Column As U_TextBox.GridColumn
        Dim p_ButtonEdit As DevExpress.XtraEditors.ButtonEdit
        Dim p_StrSQL As String = ""
        Dim p_DataRow As DataRow
        Try


            p_ItemBtn = g_Form.ButtonSave
        Catch ex As Exception

        End Try
        If p_ItemBtn.ToString.Trim <> "" Then
            p_ButtonArr = g_Form.Controls.Find(p_ItemBtn, True)
            If Not p_ButtonArr Is Nothing Then
                If p_ButtonArr.Length > 0 Then
                    p_ButtonOK = p_ButtonArr(0)
                End If
            End If
        End If
        If Sender.GetType.Name = "GridView" Then
            Exit Sub
        End If
        p_ButtonEdit = CType(sender, DevExpress.XtraEditors.ButtonEdit)
        p_TrueGrid = CType(p_ButtonEdit.Parent, U_TextBox.TrueDBGrid)
        p_GridView = p_TrueGrid.Views(0)
        p_Column = p_GridView.FocusedColumn

        If p_Column.ButtonClick = False Then
            Exit Sub
        End If
        If p_Column.OptionsColumn.ReadOnly = True Or p_GridView.OptionsBehavior.ReadOnly = True Then Exit Sub

        'anhqh
        '20160609 xu ly de khong bi them dòng
        p_DataRow = p_GridView.GetFocusedDataRow
        If Not p_DataRow Is Nothing Then
            If p_GridView.FocusedRowHandle < 0 And p_DataRow.RowState <> DataRowState.Detached Then
                p_GridView.AddNewRow()
            End If
        Else
            p_GridView.AddNewRow()
        End If

        p_StrSQL = p_Column.SQLString
        p_Gridview_Column_Button_Click(p_TrueGrid, _
                                                       p_GridView, _
                                                        g_Form, _
                                                g_Form.FormStatus, _
                                                 p_ButtonOK, _
                                                 p_Column,
                                                  p_StrSQL, False, p_ButtonEdit.Location.X, p_ButtonEdit.Location.Y)
        If g_ChooseRecordFromSearch = True Then
            g_ValueType = 1

            If p_Column.Name <> "CHECKUPD" Then
                g_Form.FormStatus = True

                Try
                    p_ItemBtn = g_Form.ButtonSave
                Catch ex As Exception

                End Try
                If p_ItemBtn.ToString.Trim <> "" Then
                    p_ButtonArr = g_Form.Controls.Find(p_ItemBtn, True)
                    If Not p_ButtonArr Is Nothing Then
                        If p_ButtonArr.Length > 0 Then
                            p_ButtonOK = p_ButtonArr(0)
                            p_ButtonOK.Text = g_Form.CaptionUpd
                        End If
                    End If
                End If
                p_DataRow = p_GridView.GetDataRow(p_GridView.FocusedRowHandle)
                If Not p_DataRow Is Nothing And p_GridView.CheckUpd = True Then

                    If Not p_DataRow.Item("CHECKUPD") Is Nothing Then
                        If p_DataRow.Item("CHECKUPD").ToString.Trim <> "I" And p_DataRow.Item("CHECKUPD").ToString.Trim <> "Y" And p_DataRow.Item("CHECKUPD").ToString.Trim <> "R" Then
                            p_GridView.SetRowCellValue(p_GridView.FocusedRowHandle, "CHECKUPD", "Y")
                        End If
                    End If
                End If



            End If


            ' GridView_KeyPress()
        End If

    End Sub



    Public Sub Gridview_Column_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Column_Button_Click(sender)
        'Dim p_TrueGrid As U_TextBox.TrueDBGrid
        'Dim p_GridView As U_TextBox.GridView
        'Dim p_ButtonArr() As Object
        'Dim p_ButtonOK As Object = Nothing
        'Dim p_ItemBtn As String = ""
        'Dim p_Column As U_TextBox.GridColumn
        'Dim p_ButtonEdit As DevExpress.XtraEditors.ButtonEdit
        'Dim p_StrSQL As String = ""
        'Dim p_DataRow As DataRow
        'Try
        '    p_ItemBtn = g_Form.ButtonSave
        'Catch ex As Exception

        'End Try
        'If p_ItemBtn.ToString.Trim <> "" Then
        '    p_ButtonArr = g_Form.Controls.Find(p_ItemBtn, True)
        '    If Not p_ButtonArr Is Nothing Then
        '        If p_ButtonArr.Length > 0 Then
        '            p_ButtonOK = p_ButtonArr(0)
        '        End If
        '    End If
        'End If
        'p_ButtonEdit = CType(sender, DevExpress.XtraEditors.ButtonEdit)
        'p_TrueGrid = CType(p_ButtonEdit.Parent, U_TextBox.TrueDBGrid)
        'p_GridView = p_TrueGrid.Views(0)
        'p_Column = p_GridView.FocusedColumn
        'If p_Column.OptionsColumn.ReadOnly = True Or p_GridView.OptionsBehavior.ReadOnly = True Then Exit Sub
        'If p_GridView.FocusedRowHandle < 0 Then
        '    p_GridView.AddNewRow()
        'End If
        'p_StrSQL = p_Column.SQLString
        'p_Gridview_Column_Button_Click(p_TrueGrid, _
        '                                               p_GridView, _
        '                                                g_Form, _
        '                                        g_Form.FormStatus, _
        '                                         p_ButtonOK, _
        '                                         p_Column,
        '                                          p_StrSQL, False, p_ButtonEdit.Location.X, p_ButtonEdit.Location.Y)
        'If g_ChooseRecordFromSearch = True Then
        '    g_ValueType = 1

        '    If p_Column.Name <> "CHECKUPD" Then
        '        g_Form.FormStatus = True

        '        Try
        '            p_ItemBtn = g_Form.ButtonSave
        '        Catch ex As Exception

        '        End Try
        '        If p_ItemBtn.ToString.Trim <> "" Then
        '            p_ButtonArr = g_Form.Controls.Find(p_ItemBtn, True)
        '            If Not p_ButtonArr Is Nothing Then
        '                If p_ButtonArr.Length > 0 Then
        '                    p_ButtonOK = p_ButtonArr(0)
        '                    p_ButtonOK.Text = g_Form.CaptionUpd
        '                End If
        '            End If
        '        End If
        '        p_DataRow = p_GridView.GetDataRow(p_GridView.FocusedRowHandle)
        '        If Not p_DataRow Is Nothing Then
        '            If Not p_DataRow.Item("CHECKUPD") Is Nothing Then
        '                If p_DataRow.Item("CHECKUPD").ToString.Trim <> "I" And p_DataRow.Item("CHECKUPD").ToString.Trim <> "Y" And p_DataRow.Item("CHECKUPD").ToString.Trim <> "R" Then
        '                    p_GridView.SetRowCellValue(p_GridView.FocusedRowHandle, "CHECKUPD", "Y")
        '                End If
        '            End If
        '        End If



        '    End If


        '    ' GridView_KeyPress()
        'End If

    End Sub



    Public Sub p_Gridview_Column_Button_Click(ByRef p_TrueGrid As U_TextBox.TrueDBGrid, _
                                               ByRef p_GridView As U_TextBox.GridView, _
                                                ByRef p_RptForm As Object, _
                                        ByRef p_Commit1 As Boolean, _
                                        ByRef p_ButtonOK As Object, _
                                        ByVal p_Column As U_TextBox.GridColumn, _
                                        Optional ByVal p_StrSQL As String = "", _
                                        Optional ByVal p_AddNewRow As Boolean = True, Optional ByVal p_X As Integer = 0, Optional ByVal p_Y As Integer = 0)
        '        Dim p_Form As New FrmSearch
        Dim p_Form As New Object
        Dim p_ShpCod As String = ""
        Dim p_EditText As New DevExpress.XtraEditors.TextEdit
        Dim p_SQL As String
        Dim p_ButtonEdit As U_TextBox.U_ButtonEdit

        If p_Column.FormList = False Then
            p_Form = New FrmSearch
        Else
            p_Form = New FrmSearchLov
        End If
        ' Dim p_RowArr() As DataRow
        Dim p_Row As DataRow
        Dim p_Left As Integer
        Dim p_Top As Integer

        If p_GridView.RowCount >= 0 Then
            ' p_RowArr = p_DataSet_TrueGird.Tables(0).Select("COL_NAME='" & p_ColumnName & "' and FORM_NAME='" & p_RptForm.Name & "'")
            ' If p_RowArr.Length > 0 Then

            'p_ButtonEdit = p_Column.


            If p_StrSQL.Trim <> "" Then
                p_SQL = p_StrSQL
            Else
                p_SQL = p_Column.SQLString
            End If

            If p_SQL = "" Then Exit Sub
            p_Row = p_GridView.GetFocusedDataRow
            p_SQL = p_Parameter_Item(p_RptForm, p_SQL, p_Row)


            If p_Column.FormList = True Then
                p_Top = g_Form.MousePosition.Y
                p_Left = g_Form.MousePosition.X - p_Form.width ' / 2
            Else
                p_Top = p_RptForm.top + p_TrueGrid.Top
                p_Left = p_RptForm.left + p_TrueGrid.Left + (p_TrueGrid.Width / 2)
            End If

            p_Form.Location = New System.Drawing.Point(p_Left, p_Top)


            p_Form.FptSQLString = p_SQL   ' "select  ItemCode as [Mã sản phẩm], ItemName as [Tên sản phẩm] from FPTOITM where SellItem='Y' "
            p_Form.FptFieldKey = p_Column.CFLKeyField ' p_RowArr(0).Item("CFLKeyField").ToString.Trim
            p_Form.Fpt_Object = p_GridView
            p_Form.FptB1Get = False
            p_Form.FptPageNum = 1
            p_Form.FptLineOfPage = 500
            p_Form.FptLoadPage = True
            p_Form.FptItemPosition = p_GridView
            p_Form.FptTypePosition = "C"
            p_Form.FptParentForm = p_RptForm

            p_Form.FptShowLoad = p_Column.CFLShowLoad

            p_Form.p_CFLColumnHide = p_Column.CFLColumnHide

            If p_GridView.FocusedRowHandle < 0 And p_AddNewRow = True Then
                p_GridView.AddNewRow()
            End If
            p_Form.FptRowID = p_GridView.FocusedRowHandle
            p_Form.p_ObjSearchReturn(0) = p_Column.FieldView
            If p_Column.CFLReturn0.ToString.Trim <> "" Then
                p_Form.p_ObjSearchReturn(0) = p_Column.CFLReturn0.ToString.Trim
            End If

            If p_Column.CFLReturn1.ToString.Trim <> "" Then
                p_Form.p_ObjSearchReturn(1) = p_Column.CFLReturn1.ToString.Trim
            End If
            If p_Column.CFLReturn2.ToString.Trim <> "" Then
                p_Form.p_ObjSearchReturn(2) = p_Column.CFLReturn2.ToString.Trim
            End If
            If p_Column.CFLReturn3.ToString.Trim <> "" Then
                p_Form.p_ObjSearchReturn(3) = p_Column.CFLReturn3.ToString.Trim
            End If
            If p_Column.CFLReturn4.ToString.Trim <> "" Then
                p_Form.p_ObjSearchReturn(4) = p_Column.CFLReturn4.ToString.Trim
            End If

            If p_Column.CFLReturn5.ToString.Trim <> "" Then
                p_Form.p_ObjSearchReturn(5) = p_Column.CFLReturn5.ToString.Trim
            End If
            If p_Column.CFLReturn6.ToString.Trim <> "" Then
                p_Form.p_ObjSearchReturn(6) = p_Column.CFLReturn6.ToString.Trim
            End If
            If p_Column.CFLReturn7.ToString.Trim <> "" Then
                p_Form.p_ObjSearchReturn(7) = p_Column.CFLReturn7.ToString.Trim
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
                            If Not p_ButtonOK Is Nothing Then
                                p_ButtonOK.Text = p_RptForm.CaptionUpd
                            End If
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
            'End If
        End If

        '  p_FptModule = Nothing
    End Sub





    Private Sub ColumnCombobox(ByRef p_Form As Object, ByRef p_Column As U_TextBox.GridColumn, ByVal p_GetB1 As Boolean,
                               Optional ByVal p_Refresh As Boolean = False, Optional ByVal p_datarow As DataRow = Nothing)
        Dim p_SQL As String
        Dim p_Datatable As DataTable
        Dim p_Count As Integer
        Dim p_Combobox As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox

        p_Combobox = p_Column.ColumnEdit
        p_Combobox.AppearanceDropDown.Font = New Font("Tahoma", 12)

        If p_Column.RefreshSource = True Then
            ' GoTo Line_TT
            Exit Sub
        End If


        p_SQL = p_Column.SQLString.ToString.Trim
        If p_SQL = "" Then Exit Sub

        p_SQL = p_Parameter_Item(p_Form, p_SQL, p_datarow)

        If g_DBTYPE = "ORACLE" Then
            p_Datatable = g_Service.SYS_GET_DATATABLE_Oracle(p_SQL)
        ElseIf g_DBTYPE = "SQL" Then
            p_Datatable = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        End If

        If p_Datatable Is Nothing And p_SQL <> "" Then
            MsgBox("Column " & p_Column.Name & ":" & p_SQL)
            Exit Sub
        End If

        'For p_Count =p_Combobox.Items.
        For p_Count = 0 To p_Datatable.Rows.Count - 1
            If p_Datatable.Rows(p_Count).Item(0).ToString.Trim <> "" Then
                p_Combobox.Items.Add(p_Datatable.Rows(p_Count).Item(0).ToString.Trim)
            End If
        Next
Line_TT:
        If p_Refresh = False Then
            'AddHandler p_Combobox.ButtonClick, AddressOf Gridview_Column_Combo_Click
        End If
    End Sub


    Private Sub p_AddColumnTypeCombobox(ByRef p_Form As Object, ByRef p_Column As U_TextBox.GridColumn, ByVal p_GetB1 As Boolean,
                                        Optional ByVal p_Datarow As DataRow = Nothing)
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
        Dim p_SQL As String
        Dim p_DropDownList As Integer
        Dim p_DesError As String = ""
        Dim p_DataTable As DataTable

        Try

            p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit

            p_SQL = p_Column.SQLString.ToString.Trim
            If p_SQL = "" Then Exit Sub

            p_SQL = p_Parameter_Item(p_Form, p_SQL, p_Datarow)

            p_DataTable = g_Service.mod_SYS_GET_DATATABLE(p_SQL)

            If Not p_DataTable Is Nothing Then
                p_ColType.DataSource = p_DataTable

                If p_DataTable.Columns.Count > 1 Then
                    p_ColType.ValueMember = p_DataTable.Columns.Item(0).ColumnName
                    p_ColType.DisplayMember = p_DataTable.Columns.Item(1).ColumnName
                Else
                    p_ColType.ValueMember = p_DataTable.Columns.Item(0).ColumnName
                    p_ColType.DisplayMember = p_DataTable.Columns.Item(0).ColumnName

                End If
            End If

            p_ColType.NullText = ""
            p_ColType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            p_ColType.BestFit()

            p_ColType.AppearanceDropDown.Font = New Font("Tahoma", 12)


            p_ColType.ShowHeader = False

            Integer.TryParse(p_Column.ComboLine.ToString.Trim, p_DropDownList)
            If p_DropDownList > 0 Then
                p_ColType.DropDownRows = p_DropDownList
            End If


            ' p_GridView.Columns(p_Column.Name.ToString).ColumnEdit = p_ColType
            'If p_Form.g_formLoad = True Then
            'AddHandler p_ColType.ButtonClick, AddressOf Gridview_Column_LookUpEdit_Click
            AddHandler p_ColType.Click, AddressOf Gridview_Column_LookUpEdit_Click
            'End If
            p_Column.ColumnEdit = p_ColType
        Catch ex As Exception
            'MsgBox(ex.Message)
            g_Module.ModErrExceptionNew(Err.Number, ex.Message)
        End Try
    End Sub



    Private Sub p_AddColumntemGridLookUpEdit(ByRef p_Form As Object, ByRef p_Column As U_TextBox.GridColumn, ByVal p_GetB1 As Boolean,
                                        Optional ByVal p_Datarow As DataRow = Nothing)
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
        Dim p_SQL As String
        Dim p_DropDownList As Integer
        Dim p_DesError As String = ""
        Dim p_DataTable As DataTable

        Try

            p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit

            p_SQL = p_Column.SQLString.ToString.Trim
            If p_SQL = "" Then Exit Sub

            p_SQL = p_Parameter_Item(p_Form, p_SQL, p_Datarow)

            p_DataTable = g_Service.mod_SYS_GET_DATATABLE(p_SQL)

            If Not p_DataTable Is Nothing Then
                p_ColType.DataSource = p_DataTable

                If p_DataTable.Columns.Count > 1 Then
                    p_ColType.ValueMember = p_DataTable.Columns.Item(0).ColumnName
                    p_ColType.DisplayMember = p_DataTable.Columns.Item(1).ColumnName
                Else
                    p_ColType.ValueMember = p_DataTable.Columns.Item(0).ColumnName
                    p_ColType.DisplayMember = p_DataTable.Columns.Item(0).ColumnName

                End If
            End If

            p_ColType.AppearanceDropDown.Font = New Font("Tahoma", 12)
            p_ColType.NullText = ""
            ' p_ColType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
            ' p_ColType.BestFit()

            '   p_ColType.


            ' p_ColType.ShowHeader = False

            Integer.TryParse(p_Column.ComboLine.ToString.Trim, p_DropDownList)
            If p_DropDownList > 0 Then
                p_ColType.ShowDropDown = p_DropDownList
            End If


            ' p_GridView.Columns(p_Column.Name.ToString).ColumnEdit = p_ColType
            'If p_Form.g_formLoad = True Then
            'AddHandler p_ColType.ButtonClick, AddressOf Gridview_Column_LookUpEdit_Click
            AddHandler p_ColType.ButtonClick, AddressOf Gridview_Column_GridLookUpEdit_Click
            'End If
            p_Column.ColumnEdit = p_ColType
        Catch ex As Exception
            'MsgBox(ex.Message)
            g_Module.ModErrExceptionNew(Err.Number, ex.Message)
        End Try
    End Sub

End Module
