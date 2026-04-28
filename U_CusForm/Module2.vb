Imports System.Windows.Forms
Module Module2
    Public g_DBTYPE As String
    Public Sub p_UpdateToDatabase(byref p_Form As Object, Optional ByVal p_BtnSave As String = "")
        Dim p_DataTable As DataTable

        Dim p_DataTableUpd As DataTable
        Dim p_SQL As String = ""
        Dim p_DataRow As DataRow
        'Dim p_Form As Object
        Dim p_ControlArr() As Object
        Dim p_ItemKey As Object = Nothing
        Dim p_ItemBtn As String = ""
        Dim p_Count As Integer
        Dim p_Error As Boolean
        If p_Form.FormLock = True Then Exit Sub
        If p_Form.FormStatus = False Then Exit Sub

        If g_Service Is Nothing Then
            'MsgBox("g_XtraServicesObj Is Nothing")
            g_Module.ModErrExceptionNew("", "g_XtraServicesObj Is Nothing")
            Exit Sub
        End If
        If Not p_Form.FormItemKey Is Nothing Then
            If p_Form.FormItemKey.ToString.Trim <> "" Then

                p_ControlArr = p_Form.Controls.Find(p_Form.FormItemKey.ToString.Trim, True)
                If p_ControlArr.Length > 0 Then
                    p_ItemKey = p_ControlArr(0)
                End If
            End If
        End If

        p_Form.ErrorSave = False
        If g_DBTYPE = "" Then
            g_Service.Sys_GetParameterOracle(g_DBTYPE)
        End If

        p_Error = False
       
        p_DataTableUpd = p_Form.CompileControlHeaderToSQL(p_Error, True, p_Form, p_Form.HeaderSource, p_ItemKey, p_Form.SequenceName, Nothing, p_Form.SequenceName, p_Form.p_XtraUserName)
        'If p_DataTable Is Nothing Then
        '    Exit Sub
        'End If
        p_Form.ErrorSave = p_Error

        If p_Error = True Then Exit Sub

        If Not p_Form.pv_LineRemove Is Nothing Then
            'If Not p_Form.pv_LineRemove Is Nothing Then
            '    If p_Form.pv_LineRemove.rows.couunt > 0 Then

            '    End If
            'End If
            p_DataTable = p_Form.pv_LineRemove

            If g_Service.Sys_Execute_DataTbl(p_DataTable, p_SQL) = False Then
                g_Module.ModErrExceptionNew("", p_SQL)
                Exit Sub
            End If
            p_DataTable.Clear()
        End If
        If Not p_DataTableUpd Is Nothing Then   'Or Not p_Form.pv_LineRemove Is Nothing Then
            'If Not p_Form.pv_LineRemove Is Nothing Then
            If p_DataTable.Columns.Count <= 0 Then
                p_DataTable.Columns.Add("STR_SQL")
            End If
            For p_Count = 0 To p_DataTableUpd.Rows.Count - 1
                If p_DataTableUpd.Rows(p_Count).Item(0).ToString.Trim <> "" Then
                    p_DataRow = p_DataTable.NewRow
                    p_DataRow.Item(0) = p_DataTableUpd.Rows(p_Count).Item(0).ToString.Trim
                    p_DataTable.Rows.Add(p_DataRow)
                End If
            Next
            'End If
            If Not p_DataTable Is Nothing Then
                If g_DBTYPE = "" Then
                    g_Service.Sys_GetParameterOracle(g_DBTYPE)
                End If
                If p_DataTable.Rows.Count > 0 Then
                    If g_DBTYPE = "ORACLE" Then
                       
                    ElseIf g_DBTYPE = "SQL" Then
                        If g_Service.Sys_Execute_DataTbl(p_DataTable, p_SQL) = False Then
                            'MsgBox(p_SQL)
                            g_Module.ModErrExceptionNew("", p_SQL)
                            Exit Sub
                        Else
                            'g_LineRemove.Clear()
                            'p_Form.pv_LineRemove.clear()
                            'p_Form.pv_TableEdit.clear()
                            'Try
                            '    p_Form.SetmenuIcon(False)
                            'Catch ex As Exception

                            'End Try

                            p_Form.LockObjectIsNull()

                            If p_Form.RefreshAfterSave = True Then
                                If ModSet_BindSource_ForForm(p_Form, True) Then

                                End If
                            Else

                            End If
                            p_DataTable.Clear()

                            p_DataTableUpd.Clear()

                            'p_Form.Clear_pv_TableEdit()


                            p_Form.pv_LineRemove.Clear()

                            If p_Form.FormStatus = True Then
                                p_Form.FormStatus = False
                                p_Form.g_FormAddnew = False
                            End If
                            ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
                            p_Form.ShowStatusMessage(False, "MS901", "Lưu thành công", g_TimeInfor)
                        End If
                    End If

                Else
                    p_Form.ShowStatusMessage(False, "MS901", "Không có thông tin thay đổi", 5)
                End If
            End If
        Else
            g_Module.ModErrExceptionNew("MS0004", "Lỗi khi cập nhật")
            Exit Sub
        End If


        p_Form.FormStatus = False

        p_Form.SetValueType()

        Try
            p_Form.g_FormAddnew = False
        Catch ex As Exception

        End Try
        If p_BtnSave.ToString.Trim <> "" Then
            p_ControlArr = p_Form.Controls.Find(p_BtnSave.ToString.Trim, True)
            If p_ControlArr.Length > 0 Then
                'If Not p_BtnSave Is Nothing Then
                p_ControlArr(0).Text = p_Form.CaptionAdd
                'End If
            End If
        End If

        'If p_Form.p_XtraModuleObj.ModSetTrueGridPropertyNew(p_Form.p_XtraDataSet_TrueGird, p_Form, True) Then
        '    MsgBox("aa")
        'End If


        p_Form.g_FormAddnew = False



    End Sub


    Function ExecuteDataTable(ByVal p_DataTable As DataTable, ByRef p_SQL As String) As Boolean
        Dim p_Table As New DataTable("Table01")
        Dim p_Count As Integer = 0
        Dim p_RowID As Integer = 0
        Dim p_Row As DataRow
        Dim p_RowFrom As DataRow
        Dim p_Col As Integer
        ' Dim p_SQL As String
        'p_Table.Columns.Add("STR_SQL")
        p_SQL = ""
        Try

            p_Count = 0
            p_Table = p_DataTable.Clone
            For p_RowID = 0 To p_DataTable.Rows.Count - 1

                p_RowFrom = p_DataTable.Rows(p_RowID)
                p_Row = p_Table.NewRow
                For p_Col = 0 To p_DataTable.Columns.Count - 1
                    p_Row.Item(p_Col) = p_RowFrom.Item(p_Col)
                Next
                'p_Row = p_RowFrom
                p_Table.Rows.Add(p_Row)

                If p_Count >= 100 Then
                    If g_Service.Sys_Execute_DataTbl(p_Table, p_SQL) = False Then
                        Return False
                    End If
                    p_Count = 0
                    p_Table.Clear()
                Else
                    'p_RowFrom = p_DataTable.Rows(p_RowID)
                    'p_Row = p_Table.NewRow
                    'For p_Col = 0 To p_DataTable.Columns.Count - 1
                    '    p_Row.Item(p_Col) = p_RowFrom.Item(p_Col)
                    'Next
                    ''p_Row = p_RowFrom
                    'p_Table.Rows.Add(p_Row)
                    ''If g_Service.Sys_Execute_DataTbl(p_DataTable, p_SQL) = False Then

                    ''End If
                    p_Count = p_Count + 1
                End If

            Next
            If p_Table.Rows.Count > 0 Then
                If g_Service.Sys_Execute_DataTbl(p_Table, p_SQL) = False Then
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            p_SQL = ex.Message.ToString
            Return False
        End Try
    End Function


    Public Function BindingSourceAddNewRow() As Boolean
        Dim p_BindingSource As U_TextBox.U_BindingSource
        Dim p_Status As Boolean = False
        BindingSourceAddNewRow = True
        Try
            For p_CountSource = 0 To p_BindingSourceName.Rows.Count - 1
                p_BindingSource = New U_TextBox.U_BindingSource
                p_BindingSource = p_BindingSourceControl(p_CountSource)
                If Not p_BindingSource Is Nothing Then
                    p_BindingSource.AddNew()
                    p_Status = True
                End If
            Next

            BindingSourceAddNewRow = p_Status
        Catch ex As Exception
            BindingSourceAddNewRow = False
        End Try
        
    End Function



    Public Function BindingSourceCancelEdit(ByVal p_Navigator As U_TextBox.Navigator) As Boolean
        BindingSourceCancelEdit = True
        Try
            For p_CountSource = 0 To p_BindingSourceName.Rows.Count - 1
                If UCase(p_Navigator.ViewName.ToString.Trim) = UCase(p_BindingSourceName.Rows(p_CountSource).Item(0).ToString.Trim) Then
                    p_BindingSourceControl(p_CountSource).CancelEdit()
                    ' p_BindingSourceControl(p_CountSource).EndEdit()

                    ' p_BindingSourceControl(p_CountSource).ResumeBinding()

                    ' p_BindingSourceControl(p_CountSource).ResetBindings(True)
                    Exit Function
                End If
            Next
        Catch ex As Exception
            BindingSourceCancelEdit = False
        End Try

    End Function


    'anhqh
    '20161028
    'Ham cap nhat la cac header de luu dư lieu tren form

    Public Sub SetValueToSource(ByVal p_TableName As String, ByVal p_TableID As String)
        Dim p_RowArr() As DataRow
        Dim p_Row As DataRow

        On Error Resume Next

        p_RowArr = p_BindingTableName.Select("")
        If p_RowArr.Length <= 0 Then
            p_Row = p_BindingTableName.NewRow
            p_Row.Item(0) = p_TableName
            p_BindingTableName.Rows.Add(p_Row)
        End If

        p_RowArr = p_BindingSourceKey.Select("TableName='" & p_TableName & "'")
        If p_RowArr.Length <= 0 Then
            p_Row = p_BindingSourceKey.NewRow
            p_Row.Item(0) = p_TableName
            p_BindingSourceKey.Rows.Add(p_Row)
        End If
    End Sub


    'ANHQH
    '26/06/2014
    'Ham thuc hien tao cau lenh SQL tu cac control tren form
    Public Function p_CompileControlHeaderToSQL(ByRef p_Error As Boolean, ByVal p_RecordHist As Boolean, _
                                                ByRef p_Form As U_CusForm.XtraCusForm1, _
                                                Optional ByVal p_UserName As String = "") As DataTable

        Dim p_Insert_Type As Boolean
        Dim p_Object As Object
        ' Dim p_Object_Item As Object
        '  Dim p_Object_Tab_Item As Object
        Dim p_SQL_Upd As String = ""
        Dim p_ItemName As String
        Dim p_Count As Integer
        '  Dim p_TabControl_Ind As Integer
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
        Dim p_TrueDBGrid As U_TextBox.TrueDBGrid
        Dim p_GridView As U_TextBox.GridView

        Dim p_CountTable As Integer


        Dim p_Table_Name As String
        Dim p_ControlKey As Object
        Dim p_ArrControlKey() As Object
        Dim p_ArrDataRow() As DataRow
        Dim p_CountArr As Integer
        Dim p_CountColtrol As Integer

        Dim p_AutoKeyName As String
        Dim p_AllowInsert As Boolean
        Dim p_AllowUpdate As Boolean
        Dim p_AutoKeyFix As String
        Dim p_AutoKeyString As String
        Dim p_DefaultValue As String = ""
        '  Dim p_AllowInsert As Boolean = False
        '        Dim p_WhereKey As String

        Dim p_ValueTmp As String

        Dim p_ValueNumber As Double
        Dim p_ValueDate As Date

        Dim p_TableNameUpd As DataTable

        If GetTableInForm_ALL(p_Form, p_TableNameUpd) Then

        End If

        If p_TableNameUpd Is Nothing Then
            p_CompileControlHeaderToSQL = Nothing
            p_Form.ShowStatusMessage(True, "MS902", "Không xác định Tablename", g_TimeError)
            ' MsgBox(p_Des)
            Exit Function
        End If

        FillValueItemCopyFrom(p_Form)

        If p_Form.pv_TableEdit.Rows.Count > 0 Or p_Form.FormStatus = True Then
            If p_Check_Control_Required(p_Form, p_Des) = False Then
                p_Error = True
                p_CompileControlHeaderToSQL = Nothing
                p_Form.ShowStatusMessage(True, "MS902", p_Des, g_TimeError)
                ' MsgBox(p_Des)
                Exit Function
            End If
        End If

        p_Col.ColumnName = "SQL_STR"
        p_Col.DataType = GetType(String)
        p_Col.MaxLength = 4000
        p_Table.Columns.Add(p_Col)

        'Clear_pv_TableEdit'
        For p_CountTable = 0 To p_TableNameUpd.Rows.Count - 1
            If p_TableNameUpd.Rows(p_CountTable).Item(0).ToString.Trim <> "" Then
                p_Table_Name = p_TableNameUpd.Rows(p_CountTable).Item(0).ToString.Trim
                'For p_CountTable = 0 To p_BindingTableName.Rows.Count - 1
                '    If p_BindingTableName.Rows(p_CountTable).Item(0).ToString.Trim <> "" Then
                '        p_Table_Name = p_BindingTableName.Rows(p_CountTable).Item(0).ToString.Trim
                p_ArrDataRow = p_BindingSourceKey.Select("TableName='" & p_Table_Name & "'")

                If UCase(g_DBTYPE) = "ORACLE" Then
                    p_SQL = "Select 1 from " & p_Table_Name & " Nolock "
                Else
                    p_SQL = "Select 1 from " & p_Table_Name & " With (Nolock) "
                End If

                'p_SQL = "Select 1 from " & p_Table_Name & " With (Nolock) "
                p_Where = ""
                If p_ArrDataRow.Length <= 0 Then Continue For
                For p_CountArr = 0 To p_ArrDataRow.Length - 1
                    p_ArrControlKey = p_Form.Controls.Find(p_ArrDataRow(p_CountArr).Item("ItemName").ToString.Trim, True)
                    If p_ArrControlKey.Length > 0 Then
                        For p_CountColtrol = 0 To p_ArrControlKey.Length - 1
                            p_ControlKey = p_ArrControlKey(p_CountColtrol)
                            p_ItemName = UCase(p_ControlKey.FieldName)
                            p_FieldType = UCase(p_ControlKey.FieldType)
                            If p_ControlKey.EditValue Is Nothing Then
                                p_Value = ""
                            Else
                                p_Value = p_ControlKey.EditValue.ToString
                            End If
                            If p_FieldType <> "N" And p_FieldType <> "C" Then
                                p_CompileControlHeaderToSQL = Nothing
                                MsgBox("Control " & p_ControlKey.Name & " FieldType không hợp lệ")
                                Exit Function
                            End If
                            If p_Value.Trim <> "" Then
                                If p_FieldType = "N" Then
                                    If p_Where = "" Then
                                        p_Where = " Where " & p_ItemName & "=" & p_Value
                                    Else
                                        p_Where = p_Where & " and " & p_ItemName & "=" & p_Value
                                    End If
                                    'p_SQL = "Select 1 from " & p_Table_Name & " With (Nolock) Where " & p_ItemName & "=" & p_Value
                                Else
                                    'p_SQL = "Select 1 from " & p_Table_Name & " With (Nolock) Where " & p_ItemName & "='" & p_Value & "'"
                                    If p_Where = "" Then
                                        p_Where = " Where " & p_ItemName & "='" & p_Value & "'"
                                    Else
                                        p_Where = p_Where & " and " & p_ItemName & "='" & p_Value & "'"
                                    End If
                                End If
                            Else
                                p_Insert_Type = True
                            End If
                        Next
                    End If
                Next

                If p_Where = "" And p_Insert_Type = False Then Continue For
                If p_Insert_Type = False Then
                    p_SQL = p_SQL & " " & p_Where

                    If UCase(g_DBTYPE) = "ORACLE" Then
                        p_DataTableCheck = g_Service.clsGetDataTableOracle(p_SQL, p_Des)
                    Else
                        p_DataTableCheck = g_Service.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Des)
                    End If

                    If p_Des <> "" Then
                        p_CompileControlHeaderToSQL = Nothing
                        MsgBox(p_Des)
                        Exit Function
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
                End If
                If p_RecordHist = True Then

                    If UCase(g_DBTYPE) = "ORACLE" Then
                        p_SQL = "select COLUMN_NAME AS ColumnName, 0 AS user_type_id from dba_tab_cols WHERE Table_name='" & p_Table_Name & "'" & _
                        "AND   UPPER ( COLUMN_NAME) in (upper('CreateDate'),upper('CreateTime'),upper('UpdateDate'),upper('UpdateTime'),upper('CreateBy'),upper('UpdatedBy'))"
                        p_Dt = g_Service.clsGetDataTableOracle(p_SQL, p_SQL)
                    Else
                        p_Dt = g_Service.mod_SYS_GET_DATATABLE("exec  FPT_CheckFieldHist '" & p_Table_Name & "'")
                    End If

                End If
                'If p_Insert_Type = True Then
                '    'Lay Key cho truong DocEntry neu chua co

                'End If
                p_Des = ""


                'p_CompileControlHeaderToSQL = True
                p_CountObj = 0

                Try



                    For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                        p_Object = p_Form.Controls.Item(p_Control_Ind)

                        'If p_Object.Name.ToString.Trim = "USER_ID" Then
                        '    MsgBox("dfd")
                        'End If

                        If InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                            Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                 Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                 Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                 Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                 Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                             Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then

                            If UCase(p_Object.TableName) = UCase(p_Table_Name) And p_Object.FieldName.trim <> "" Then


                                p_AllowInsert = p_Object.AllowInsert
                                p_AllowUpdate = p_Object.AllowUpdate
                                p_FieldType = UCase(p_Object.FieldType)
                                If p_Insert_Type = True Then
                                    If p_AllowInsert = True Then
                                        '    p_FieldType = UCase(p_Object.FieldType)
                                        'If UCase(p_Object.name) = "MENU_ID" Then
                                        '    MsgBox("fdfdgd")
                                        'End If

                                        If p_Object.PrimaryKey = "Y" Then
                                            If p_Object.EditValue Is Nothing Then
                                                p_Value = ""
                                            Else
                                                'p_Value = p_Object.EditValue.ToString
                                                Select Case p_FieldType
                                                    Case "D"
                                                        If p_Object.EditValue.ToString <> "" Then
                                                            p_ValueDate = p_Object.EditValue.ToString
                                                            p_Value = p_ValueDate.ToString(g_Format_DateTime, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                        Else
                                                            p_Value = ""
                                                        End If
                                                    Case "N"
                                                        Double.TryParse(p_Object.EditValue.ToString, p_ValueNumber)
                                                        p_Value = p_ValueNumber.ToString("#############.######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                        If p_Value = "" Then
                                                            p_Value = "0"
                                                        End If
                                                    Case "F"
                                                        Double.TryParse(p_Object.EditValue.ToString, p_ValueNumber)
                                                        p_Value = p_ValueNumber.ToString("#############.######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                        If p_Value = "" Then
                                                            p_Value = "0"
                                                        End If
                                                    Case Else
                                                        p_Value = p_Object.EditValue.ToString
                                                End Select

                                            End If




                                            If p_Value.ToString.Trim = "" Then
                                                ' If Not p_AutoKeyName Is Nothing Then
                                                Try
                                                    p_AutoKeyName = p_Object.AutoKeyName
                                                    p_AutoKeyFix = p_Object.AutoKeyFix
                                                    If p_AutoKeyName.Trim <> "" Then
                                                        'If Me.DocEntry.EditValue = 0 Then
                                                        If UCase(g_DBTYPE) = "ORACLE" Then
                                                            p_DocEntry11 = g_Service.clsSysGetPrimaryOracle(p_AutoKeyName.Trim)
                                                        Else
                                                            p_DocEntry11 = g_Service.SysGetPrimary(p_AutoKeyName.Trim)
                                                        End If


                                                        p_ValueTmp = p_DocEntry11.ToString
                                                        If p_AutoKeyFix.ToString.Trim <> "" And p_FieldType = "C" Then
                                                            p_AutoKeyString = Left(p_AutoKeyFix, Len(p_AutoKeyFix) - Len(p_ValueTmp)) & p_ValueTmp
                                                            p_Object.EditValue = p_AutoKeyString
                                                        Else
                                                            p_Object.EditValue = p_DocEntry11
                                                        End If

                                                    Else
                                                        GoTo Continue_For
                                                    End If
                                                Catch ex As Exception

                                                End Try
                                            End If
                                        Else
                                            If Not p_Object.GetType.GetProperty("AutoKeyName") Is Nothing Then
                                                p_AutoKeyName = p_Object.AutoKeyName
                                                p_AutoKeyFix = p_Object.AutoKeyFix
                                                If p_AutoKeyName.Trim <> "" Then
                                                    'If Me.DocEntry.EditValue = 0 Then
                                                    If UCase(g_DBTYPE) = "ORACLE" Then
                                                        p_DocEntry11 = g_Service.clsSysGetPrimaryOracle(p_AutoKeyName.Trim)
                                                    Else
                                                        p_DocEntry11 = g_Service.SysGetPrimary(p_AutoKeyName.Trim)
                                                    End If


                                                    p_ValueTmp = p_DocEntry11.ToString
                                                    If p_AutoKeyFix.ToString.Trim <> "" And p_FieldType = "C" Then
                                                        p_AutoKeyString = Left(p_AutoKeyFix, Len(p_AutoKeyFix) - Len(p_ValueTmp)) & p_ValueTmp
                                                        p_Object.EditValue = p_AutoKeyString
                                                    Else
                                                        p_Object.EditValue = p_DocEntry11
                                                    End If

                                                End If
                                            End If

                                        End If

                                        If Not p_Object.EditValue Is Nothing Then
                                            If p_Object.EditValue.ToString <> "" Then
                                                'INSERT



                                                p_ItemName = UCase(p_Object.FieldName)

                                                'If p_ItemName.Trim = "" Then Continue For
                                                p_FieldType = UCase(p_Object.FieldType)
                                                p_KeyInsert = UCase(p_Object.KeyInsert)
                                                If p_Object.EditValue Is Nothing Then
                                                    p_Value = ""
                                                Else
                                                    'p_Value = p_Object.EditValue.ToString


                                                    Select Case p_FieldType
                                                        Case "D"
                                                            If p_Object.EditValue.ToString <> "" Then
                                                                p_ValueDate = p_Object.EditValue.ToString
                                                                p_Value = p_ValueDate.ToString(g_Format_DateTime, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                            Else
                                                                p_Value = ""
                                                            End If
                                                        Case "N"
                                                            Double.TryParse(p_Object.EditValue.ToString, p_ValueNumber)
                                                            p_Value = p_ValueNumber.ToString("#############.######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                            If p_Value = "" Then
                                                                p_Value = "0"
                                                            End If
                                                        Case "F"
                                                            Double.TryParse(p_Object.EditValue.ToString, p_ValueNumber)
                                                            p_Value = p_ValueNumber.ToString("#############.######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                            If p_Value = "" Then
                                                                p_Value = "0"
                                                            End If
                                                        Case Else
                                                            p_Value = p_Object.EditValue.ToString
                                                    End Select



                                                End If


                                                If InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                    If p_Object.checked = False Then
                                                        p_Value = p_Object.UnCheckValue.ToString.Trim

                                                    Else
                                                        p_Value = p_Object.CheckValue.ToString.Trim
                                                    End If

                                                End If

                                                If p_Value <> "" Then
                                                    p_Value = Replace(p_Value, "'", "")
                                                End If


                                                '  End If
                                                'Else
                                                'If p_Check_Item(p_ItemName, p_Object.NoUpdate) = True Then


                                                If p_FieldType = "D" Then  'Ngay thang

                                                    If p_Value = "" Then
                                                        If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 Then
                                                            If p_Object.ShowDateTime = False Then
                                                                p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                p_Field_Value = p_Field_Value & ",null"
                                                            Else
                                                                p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                p_Field_Value = p_Field_Value & ",null"
                                                            End If
                                                        Else
                                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                            p_Field_Value = p_Field_Value & ",null"
                                                        End If
                                                    Else
                                                        If UCase(g_DBTYPE) = "ORACLE" Then
                                                            If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 Then
                                                                If p_Object.ShowDateTime = False Then
                                                                    p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                    p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "to_date('" & CDate(p_Value).ToString("yyyy/MM/dd") & "','YYYY/MM/DD')")
                                                                Else
                                                                    p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                    p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "to_date('" & p_Value & "', 'yyyy/mm/dd hh:mi:ss AM')")
                                                                End If
                                                            Else
                                                                p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "to_date('" & CDate(p_Value).ToString("yyyy/MM/dd") & "','YYYY/MM/DD')")
                                                            End If
                                                        Else
                                                            If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 Then
                                                                If p_Object.ShowDateTime = False Then
                                                                    p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                    p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                                Else
                                                                    p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                    p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                                End If
                                                            Else
                                                                p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                            End If
                                                        End If


                                                    End If



                                                    'p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                    'p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")

                                                End If

                                                'anhqh
                                                '20150819  
                                                'If p_FieldType = "C" And p_KeyInsert <> "N" Then 'Text
                                                If p_FieldType = "C" Then 'Text
                                                    p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                    p_Field_Value = p_Field_Value & ",N'" & p_Value & "'"
                                                End If
                                                ' If p_FieldType = "N" And p_KeyInsert <> "N" Then 'Number
                                                If p_FieldType = "N" Then 'Number
                                                    p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                    p_Field_Value = p_Field_Value & "," & p_Value & ""
                                                End If
                                                ' End If
                                            End If
                                        End If
                                    End If
                                ElseIf p_AllowUpdate = True Then
                                    'UPDATE
                                    'Kiem tra neu nhu co update cua Tbale thi moi thực hiện tiếp
                                    p_RowArr = p_Form.pv_TableEdit.Select("TableEdit='" & UCase(p_Table_Name) & "'")
                                    If p_RowArr.Length > 0 Then
                                        If p_AllowUpdate = True Then
                                            p_ItemName = UCase(p_Object.FieldName)
                                            p_FieldType = UCase(p_Object.FieldType)
                                            'If UCase(p_ItemName) = "DOCENTRY" Then
                                            '    MsgBox("GG")
                                            'End If
                                            If p_Object.EditValue Is Nothing Then
                                                p_Value = ""
                                            Else
                                                'p_Value = p_Object.EditValue.ToString
                                                Select Case p_FieldType
                                                    Case "D"
                                                        If p_Object.EditValue.ToString.ToString <> "" Then
                                                            p_ValueDate = p_Object.EditValue.ToString.ToString
                                                            p_Value = p_ValueDate.ToString(g_Format_DateTime, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                        Else
                                                            p_Value = ""
                                                        End If
                                                    Case "N"
                                                        Double.TryParse(p_Object.EditValue.ToString, p_ValueNumber)
                                                        p_Value = p_ValueNumber.ToString("#############.######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                    Case "F"
                                                        Double.TryParse(p_Object.EditValue.ToString, p_ValueNumber)
                                                        p_Value = p_ValueNumber.ToString("#############.######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                    Case Else
                                                        p_Value = p_Object.EditValue.ToString
                                                End Select


                                            End If
                                            p_NoUpdate = p_Object.NoUpdate

                                            If p_Value <> "" Then
                                                p_Value = Replace(p_Value, "'", "")
                                            End If


                                            If p_Object.PrimaryKey = "Y" Then

                                            Else

                                                If p_FieldType = "D" Then  'Ngay thang

                                                    If UCase(g_DBTYPE) = "ORACLE" Then
                                                        If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 Then
                                                            If p_Value = "" Then
                                                                p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=null"
                                                            Else
                                                                If p_Object.ShowDateTime = False Then
                                                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", "to_date('" & CDate(p_Value).ToString("yyyy/MM/dd") & "','YYYY/MM/DD')")
                                                                Else
                                                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", "to_date('" & p_Value & "', 'yyyy/mm/dd hh:mi:ss AM')")
                                                                End If

                                                            End If

                                                        Else
                                                            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Convert_Date(p_Value) = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                        End If
                                                    Else
                                                        If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 Then
                                                            If p_Value = "" Then
                                                                '  If p_Object.ShowDateTime = False Then
                                                                p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=null"
                                                                'Else
                                                                ' p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=null"
                                                                ' End If
                                                            Else
                                                                If p_Object.ShowDateTime = False Then
                                                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Convert_Date(p_Value) = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                                Else
                                                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Convert_Date(p_Value) = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                                End If

                                                            End If

                                                        Else
                                                            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Convert_Date(p_Value) = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                        End If

                                                    End If



                                                End If
                                                If p_FieldType = "C" Then 'Text
                                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=N'" & p_Value & "'"
                                                End If
                                                If p_FieldType = "N" Then 'Number
                                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", p_Value)
                                                End If
                                                ' End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                            Continue For
                        End If
                        If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                            If p_CompileControlHeader_PageToSQLNew(p_Form,
                                                             p_Object,
                                                               p_Table_Name,
                                                               p_Insert_Type,
                                                                 p_Field_Ins,
                                                                 p_Field_Value,
                                                                  p_SQL_Upd,
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
                                p_RowArr = p_Dt.Select("ColumnName='CREATEDATE' or ColumnName='CREATETIME' Or ColumnName='CREATEBY'")

                                p_GetDateTime(p_DateValue, p_TimeValue)
                                For p_Count = 0 To p_RowArr.Length - 1
                                    If p_RowArr(p_Count).Item(1) = 40 Or p_RowArr(p_Count).Item(1) = 61 Then  'Date
                                        p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count).Item(0)
                                        p_Field_Value = p_Field_Value & ",getdate() " '& p_DateValue.ToString(g_Format_DateTime, System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) & "'"
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

                            End If
                        End If
                    Else
                        If p_SQL_Upd <> "" Then
                            p_SQL_Upd = Mid(Trim(p_SQL_Upd), 2)
                            If p_RecordHist = True And Not p_Dt Is Nothing Then

                                p_RowArr = p_Dt.Select("ColumnName='UPDATEDATE' or ColumnName='UPDATETIME' Or ColumnName='UPDATEDBY'  Or ColumnName='UPDATEBY'")

                                p_GetDateTime(p_DateValue, p_TimeValue)
                                For p_Count = 0 To p_RowArr.Length - 1
                                    If p_RowArr(p_Count).Item(1) = 40 Or p_RowArr(p_Count).Item(1) = 61 Then  'Date

                                        p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count).Item(0) & "='" & p_DateValue.ToString(g_Format_DateTime, System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) & "'"
                                    End If

                                    If p_RowArr(p_Count).Item(1) = 52 Or p_RowArr(p_Count).Item(1) = 56 Then  'Time

                                        p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count).Item(0) & "=" & p_TimeValue
                                    End If

                                    If p_RowArr(p_Count).Item(1) = 231 Or p_RowArr(p_Count).Item(1) = 175 Then  'CreatedBy

                                        p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count).Item(0) & "='" & p_UserName & "'"
                                    End If
                                Next
                            End If
                            p_SQL_Upd = "UPDATE " & p_Table_Name & " SET " & p_SQL_Upd
                            If p_Where <> "" Then
                                p_SQL_Upd = p_SQL_Upd & "  " & p_Where
                            Else
                                p_Err = "Không xác định điều kiện where khi cập nhật"
                                p_CompileControlHeaderToSQL = Nothing
                                p_Error = True
                                GoTo line_KT1
                            End If
                            p_Row = p_Table.Rows.Add
                            p_Row(0) = p_SQL_Upd
                            p_CompileControlHeaderToSQL = p_Table

                        End If
                    End If
line_KT1:
                    If p_CompileControlHeaderToSQL Is Nothing And p_Error = True Then
                        MsgBox(p_Err)
                    End If
                    ' p_System = Nothing
                Catch ex As Exception

                    p_CompileControlHeaderToSQL = Nothing
                    MsgBox(ex.Message)
                End Try

            Else
                Continue For
            End If
Continue_For:
        Next


        If ModTrueDBGirdToSQL(p_Form,
                              p_RecordHist,
                              p_Table,
                               False,
                               p_Err,
                               "CHECKUPD", _
                                      p_UserName) = False Then
            p_Error = True
            p_CompileControlHeaderToSQL = Nothing
            Exit Function
            'MsgBox(p_Err)
        End If


        'p_Err = "TRUE"
        'p_Err = p_TrueDBGirdToSQL(p_Form,
        '                      p_RecordHist,
        '                      p_Table,
        '                       False,
        '                       "CHECKUPD", _
        '                              p_UserName)
        'If p_Err <> "TRUE" Then
        '    p_CompileControlHeaderToSQL = Nothing
        '    MsgBox("TrueDBGirdToSQL:" & p_Err)
        '    Exit Function
        'End If
        p_CompileControlHeaderToSQL = p_Table
    End Function


    Public Function ModTrueDBGirdToSQL(ByRef p_Form As U_CusForm.XtraCusForm1, _
                                  ByVal p_RecordHist As Boolean, _
                                  ByRef p_DataTable As DataTable, _
                                   ByVal p_GetB1 As Boolean, _
                                   ByRef p_Desc As String, _
                                   Optional ByVal p_ColumnCHECKUPDate As String = "", _
                                           Optional ByVal p_UserName As String = "") As Boolean
        Dim p_Count As Integer
        Dim p_TrueGrid As U_TextBox.TrueDBGrid
        Dim p_GridView As U_TextBox.GridView
        Dim p_Object() As Object

        Dim p_DataTableGrid As DataTable
        Dim pDataRow As DataRow
        Dim p_SQL As String



        ModTrueDBGirdToSQL = True
        p_Desc = ""
        If p_Form.pv_GridViewEdit.Columns.Count <= 0 Then Exit Function
        Try
            p_DataTableGrid = p_Form.pv_GridViewEdit
            For p_Count = 0 To p_DataTableGrid.Rows.Count - 1
                p_SQL = ""
                If p_DataTableGrid.Rows(p_Count).Item(0).ToString.Trim <> "" Then
                    p_Object = p_Form.Controls.Find(p_DataTableGrid.Rows(p_Count).Item(0).ToString.Trim, True)
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

                    p_GridView = p_TrueGrid.Views(0)
                    'p_GridView.

                    p_Desc = p_CompileTrueDBGirdToSQLNew(p_Form, p_RecordHist, p_TrueGrid,
                                         p_GridView,
                                         p_DataTable,
                                         p_GetB1,
                                         "CHECKUPD", g_UserName)

                    If p_Desc <> "TRUE" Then
                        ModTrueDBGirdToSQL = False
                        Exit Function
                    End If

                End If
            Next
        Catch ex As Exception
            ModTrueDBGirdToSQL = False
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
                                'If UCase(p_Object_Item.name) = "U_FORPAY" Then
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
    '01/01/2012
    'Ham thuc hien kiem tra cac item bat buoc nhap ma khong co gia tri
    Public Function p_Check_Control_Required(ByRef p_Form As U_CusForm.XtraCusForm1, ByRef p_Des As String) As Boolean

        Dim p_Object As Object
        Dim p_LinkObject() As Object
        Dim p_Control_Ind As Integer
        Dim p_Value As String
        Dim p_CountObj As Integer
        Dim p_CountObj1 As Integer = Nothing
        Dim p_LinkLabel As String = ""

        p_Check_Control_Required = True
        p_Des = ""
        p_CountObj = 0
        Try
            For p_Control_Ind = 0 To p_Form.Controls.Count - 1
                p_Object = p_Form.Controls.Item(p_Control_Ind)
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
                            p_LinkLabel = p_Object.LinkLabel.ToString.Trim
                            If p_LinkLabel <> "" Then
                                p_LinkObject = p_Form.Controls.Find(p_LinkLabel, True)
                                If p_LinkObject.Length > 0 Then
                                    p_Des = p_LinkObject(0).text & " không được trống"
                                Else
                                    p_Des = p_Object.Name & " không được trống"
                                End If
                            Else
                                p_Des = p_Object.Name & " không được trống"
                            End If

                            p_Check_Control_Required = False
                            If p_Object.Visible = True Then
                                p_Object.Focus()
                                Exit Function
                            End If
                        ElseIf p_Value = "" Then
                            ' p_Des = p_Object.Name & ":Thông tin nhập chưa đầy đủ"
                            p_LinkLabel = p_Object.LinkLabel.ToString.Trim
                            If p_LinkLabel <> "" Then
                                p_LinkObject = p_Form.Controls.Find(p_LinkLabel, True)
                                If p_LinkObject.Length > 0 Then
                                    p_Des = p_LinkObject(0).text & " không được trống"
                                Else
                                    p_Des = p_Object.Name & " không được trống"
                                End If
                            Else
                                p_Des = p_Object.Name & " không được trống"
                            End If

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

                End If


            Next
        Catch ex As Exception
            'MsgBox("Err:" & p_Control_Ind)
            p_Check_Control_Required = False
            p_Des = ex.Message
        End Try

    End Function

    Public Sub FillValueItemCopyFromPage(ByRef p_Form As Form, ByVal p_Object As Object)
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
                        If p_Object.TabPages.Count > 1 Then
                            p_Object.SelectedTabPageIndex = p_TabControl_Ind
                        End If
                        'p_Object.SelectedTabPageIndex = p_TabControl_Ind
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



    Public Sub FillValueItemCopyFrom(ByRef p_Form As Object)
        Dim p_Control As Object
        Dim p_ControlCopy As Object
        Dim p_ControlArr() As Control

        For Each p_Control In p_Form.Controls

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


    Public Function p_CheckRequiredGridView(ByVal p_FormName As String, _
                                           ByVal p_TrueDBGridName As String, _
                                           ByVal p_GridView As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Dim p_Count As Integer
        Dim p_RowId As Integer
        ' Dim p_RowArr() As DataRow
        Dim p_DataRow As DataRow
        Dim p_Column As U_TextBox.GridColumn
        Try
            p_CheckRequiredGridView = True
            'p_RowArr = p_DataSet_TrueGird.Tables(0).Select("FORM_NAME='" & p_FormName.Trim & _
            '                                                "'  and Grid_Name='" & p_TrueDBGridName.Trim & "' and Required='Y'")
            For p_RowId = 0 To p_GridView.RowCount - 1
                If p_GridView.IsDataRow(p_RowId) Then
                    p_DataRow = p_GridView.GetDataRow(p_RowId)
                    If Not p_DataRow Is Nothing Then
                        For Each p_Column In p_GridView.Columns
                            If p_Column.Required = True Then
                                '  For p_Count = 0 To p_GridView.Columns.Count - 1
                                If p_DataRow.Item(p_Column.FieldView.ToString).ToString.Trim = "" Then
                                    p_GridView.ClearColumnsFilter()
                                    'MsgBox("Giá trị " & p_Column.Caption & " không được trống")
                                    g_Module.ModErrExceptionNew("MS0081", "Giá trị " & p_Column.Caption & " không được trống")
                                    '  p_GridView.ClearColumnsFilter()
                                    p_CheckRequiredGridView = False
                                    Exit Function
                                End If
                                ' Next
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





    'anhqh
    '21/04/2014
    'fxfdssf
    Public Function p_TrueDBGirdToSQL(ByRef p_Form As Object, _
                                  ByVal p_RecordHist As Boolean, _
                                  ByRef p_DataTable As DataTable, _
                                   ByVal p_GetB1 As Boolean, _
                                   Optional ByVal p_ColumnCHECKUPDate As String = "", _
                                           Optional ByVal p_UserName As String = "") As String
        Dim p_TrueDBGrid As U_TextBox.TrueDBGrid = Nothing
        Dim p_GirdView As U_TextBox.GridView
        Dim p_Object() As Object
        Dim p_TrueGridName As String = ""
        'Dim p_DataTableGrid As DataTable
        Dim p_Count As Integer
        Dim p_Desc As String = ""
        ' Dim p_Module As String
        'Dim avvv As Object
        Dim p_Status As Boolean
        'avvv = p_Form
        Try

            p_TrueDBGirdToSQL = "TRUE"
            If g_TrueGirdName.Columns.Count > 0 Then
                For p_Count = 0 To g_TrueGirdName.Rows.Count - 1
                    p_TrueGridName = g_TrueGirdName.Rows(p_Count).Item(0).ToString.Trim
                    If p_TrueGridName <> "" Then
                        p_Object = p_Form.controls.find(p_TrueGridName, True)
                        If Not p_Object Is Nothing Then
                            If p_Object.Length > 0 Then
                                p_TrueDBGrid = CType(p_Object(0), U_TextBox.TrueDBGrid)
                                p_GirdView = p_TrueDBGrid.Views(0)
                                p_Desc = p_CompileTrueDBGirdToSQLNew(p_Form, p_RecordHist, p_TrueDBGrid,
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
                    End If
                Next
                Exit Function
            End If
            For Each ctrl As Control In p_Form.Controls
                'p_Object = ctrl
                If InStr(UCase(ctrl.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    p_Status = p_CompileTrueDBGirdToSQL_Page(p_Form, ctrl, p_RecordHist,
                                                                                    p_DataTable, p_GetB1, p_ColumnCHECKUPDate, p_UserName)
                    If p_Status = False Then Exit Function
                    Continue For
                End If

                If InStr(UCase(ctrl.GetType.ToString), pv_Type_TrueDBGridNew, CompareMethod.Text) > 0 Then

                    p_TrueDBGrid = CType(ctrl, U_TextBox.TrueDBGrid)


                    ' If p_TrueDBGrid.ObjectChild = False Then
                    p_GirdView = p_TrueDBGrid.Views(0)

                    p_Desc = p_CompileTrueDBGirdToSQLNew(p_Form, p_RecordHist, p_TrueDBGrid,
                                          p_GirdView,
                                          p_DataTable,
                                          p_GetB1,
                                          "CHECKUPD", g_UserName)

                    If p_Desc <> "TRUE" Then
                        ' MsgBox(p_SQL)
                        p_TrueDBGirdToSQL = p_Desc
                        Exit Function
                    End If

                    'End If
                    '  End If
                End If
            Next
        Catch ex As Exception
            p_TrueDBGirdToSQL = "FALSE"
        End Try
    End Function

    'ANHQH
    '01/10/2012
    'Ham thuc hien chuyen di lieu tu Grid thanh SQL roi exec

    Public Function p_CompileTrueDBGirdToSQL_Page(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_Object As Object, _
                                                  ByVal p_RecordHist As Boolean, _
                                                ByRef p_DataTable As DataTable, _
                                              ByVal p_GetB1 As Boolean,
                                              Optional ByVal p_ColumnCHECKUPDate As String = "", _
                                              Optional ByVal p_UserName As String = "") As Boolean
        Dim p_Count As Integer
        Dim p_Object_Item As Object
        Dim p_TrueDBGrid As U_TextBox.TrueDBGrid
        Dim p_GirdView As U_TextBox.GridView
        Dim p_Desc As String
        p_CompileTrueDBGirdToSQL_Page = True
        For p_Count = 0 To p_Object.TabPages.Count - 1
            p_Object_Item = p_Object.TabPages(p_Count)
            For Each p_Control In p_Object_Item.Controls
                If InStr(UCase(p_Control.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                    p_CompileTrueDBGirdToSQL_Page = p_CompileTrueDBGirdToSQL_Page(p_Form, p_Control, p_RecordHist,
                                                                                    p_DataTable, p_GetB1, p_ColumnCHECKUPDate, p_UserName)
                    If p_CompileTrueDBGirdToSQL_Page = False Then Exit Function
                    Continue For
                End If

                If InStr(UCase(p_Control.GetType.ToString), pv_Type_TrueDBGridNew, CompareMethod.Text) > 0 Then
                    p_Desc = ""

                    p_TrueDBGrid = CType(p_Control, U_TextBox.TrueDBGrid)


                    ' If p_TrueDBGrid.ObjectChild = False Then
                    p_GirdView = p_TrueDBGrid.Views(0)

                    p_Desc = p_CompileTrueDBGirdToSQLNew(p_Form, p_RecordHist, p_TrueDBGrid,
                                          p_GirdView,
                                          p_DataTable,
                                          p_GetB1,
                                          "CHECKUPD", g_UserName)

                    If p_Desc <> "TRUE" Then

                        p_CompileTrueDBGirdToSQL_Page = False
                        Exit Function
                    End If

                End If

            Next
        Next
        Try

        Catch ex As Exception
            p_CompileTrueDBGirdToSQL_Page = False
        End Try
    End Function
    'ANHQH
    '01/10/2012
    'Ham thuc hien chuyen di lieu tu Grid thanh SQL roi exec

    Public Function p_CompileTrueDBGirdToSQL(ByVal p_Form As Object, ByVal p_RecordHist As Boolean, _
                                             ByVal p_TrueDbGird As U_TextBox.U_TrueDBGrid, _
                                              ByVal p_GridViewIn As U_TextBox.GridView, _
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

        Dim p_Col1 As New DataColumn("Column0")
        Dim p_Row As DataRow

        Dim p_Desc As String

        Dim p_CellValue As String
        '  Dim p_ColumnKeyIns As Boolean

        Dim p_ColumnEnableUpdate As String = ""
        Dim p_ColumnVisibleUpdate As String = ""

        Dim p_ColumnKeyType As String
        Dim p_DataCheck As DataTable
        Dim p_Dt As DataTable

        Dim p_SQL As String
        Dim p_GridView As U_TextBox.GridView

        Dim p_Insert As Integer    'Danh dau loai cap nhat(1:Addnew    2: Update     0: khong lam gi)

        Dim p_Column As U_TextBox.GridColumn

        Dim p_ColumnInsert As Boolean
        Dim p_ColumnUpdate As Boolean

        Try
            p_Column = p_GridViewIn.Columns.Item(p_GridViewIn.ColumnKey.ToString.Trim)
        Catch ex As Exception
            p_Column = Nothing
        End Try
        If Not p_Column Is Nothing Then
            p_ColumnKeyType = p_Column.FieldType ' p_GridView.column
        End If
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

        p_ColumnKey = p_GridViewIn.ColumnKey
        ' p_ColumnKeyIns = p_GridView.ColumnKeyIns
        p_TableName = UCase(p_GridViewIn.TableName)
        If p_TableName.ToString.Trim = "" Then Exit Function

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
                                                   p_GridView) = False Then
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
                        p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_TableName & " with (nolock) Where " & p_ColumnKey & "=" & p_CellValue & "'"
                    Else
                        p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_TableName & "  with (nolock) Where " & p_ColumnKey & "=''" & p_CellValue & "'''"
                    End If
                    p_DataCheck = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
                    If p_DataCheck.Rows.Count > 0 Then
                        p_Insert = 2
                        If p_GridView.GetRowCellValue(p_Count, "CHECKUPD").ToString.Trim = "I" Then
                            p_GridView.ClearColumnsFilter()
                            g_Module.ModErrExceptionNew("MS0001", "Bản ghi đã tồn tại")
                            p_DataTable = Nothing
                            Exit Function
                        End If
                    End If

                End If
                If p_Insert = 1 Then
                    'INSERT
                    For p_Col = 0 To p_GridView.Columns.Count - 1

                        p_Column = p_GridView.Columns.Item(p_Col)
                        If p_Column.AllowInsert = True Then
                            p_DataType = p_Column.ColumnType.ToString               ' p_GridView.Columns(p_Col).ColumnType.ToString
                            p_FieldName = p_Column.FieldName.ToString            ' p_GridView.Columns(p_Col).FieldName.ToString
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

                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                            p_Field_Value = p_Field_Value & "," & _
                                                       IIf(p_CellValue = "", 0, p_CellValue)

                                        ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                            'String

                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                            p_Field_Value = p_Field_Value & ",N'" & _
                                                    p_CellValue & "'"

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
                        End If
                    Next
                ElseIf p_Insert = 2 Then
                    'Update
                    p_SQL_Upd = ""
                    p_Where = ""
                    For p_Col = 0 To p_GridView.Columns.Count - 1
                        p_Column = p_GridView.Columns.Item(p_Col)
                        If p_Column.AllowUpdate = True Or p_Column.ColumnKey = True Then
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
                                    If p_Column.ColumnKey = True Then ' p_ColumnKey = p_FieldName Then
                                        p_Where = " WHERE " & p_ColumnKey & "=" & IIf(p_CellValue = "", 0, _
                                                p_CellValue)
                                    Else
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                   IIf(p_CellValue = "", 0, p_CellValue)

                                    End If
                                ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                    'String
                                    If p_Column.ColumnKey = True Then   ' p_ColumnKey = p_FieldName Then
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

                                    p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "='" & p_DateValue.ToString("yyyyMMdd") & "'"
                                End If

                                If p_RowArr(p_Count1).Item(1) = 52 Or p_RowArr(p_Count1).Item(1) = 56 Then  'Time

                                    p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "=" & p_TimeValue
                                End If

                                If p_RowArr(p_Count1).Item(1) = 231 Or p_RowArr(p_Count1).Item(1) = 175 Then  'CreatedBy

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

    'anhqh
    '20150706
    'Doan code lay where theo config

    Public Function get_Where_Config(ByVal p_Table As DataTable, ByVal p_GridView As U_TextBox.GridView, _
                                ByVal p_RowID As Integer, ByRef p_Err As Boolean) As String
        Dim p_ReturnValue As String = ""
        Dim p_ColumnKey As U_TextBox.GridColumn
        Dim p_Value As String
        Dim p_DataRow() As DataRow
        Dim p_Count As Integer
        Dim p_FielName As String
        Dim p_DataType As String
        Dim p_String As String = UCase("System.String")
        Dim p_DateTime As String = UCase("System.DateTime")
        Dim p_Int As String = UCase("System.Int32,System.Int16,System.Decimal,System.Double")
        Try
            p_Err = False
            With p_GridView
                For p_Count = 0 To .Columns.Count - 1
                    p_ColumnKey = .Columns(p_Count)
                    If p_ColumnKey.ColumnKey = True Then
                        If Not p_Table Is Nothing Then
                            p_DataRow = p_Table.Select("COLUMN_NAME='" & p_ColumnKey.FieldView & "'")
                            If p_DataRow.Length <= 0 Then
                                Continue For
                            End If
                        End If

                        p_Value = p_GridView.GetRowCellValue(p_RowID, p_ColumnKey.FieldView).ToString
                        p_Value = Replace(p_Value, "''''", """", 1)
                        p_Value = Replace(p_Value, "'''", """", 1)
                        p_Value = Replace(p_Value, "''", """", 1)
                        p_Value = Replace(p_Value, "'", """", 1)
                        p_DataType = UCase(p_ColumnKey.ColumnType.ToString)
                        If p_Value <> "" Then


                            If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                'Number
                                If p_ReturnValue = "" Then

                                    p_ReturnValue = " " & p_ColumnKey.FieldView & "=" & p_Value
                                Else

                                    p_ReturnValue = p_ReturnValue & " AND " & p_ColumnKey.FieldView & "=" & p_Value
                                End If

                            ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                'String

                                If p_ReturnValue = "" Then

                                    p_ReturnValue = " " & p_ColumnKey.FieldView & "='" & p_Value & "'"
                                Else

                                    p_ReturnValue = p_ReturnValue & " AND " & p_ColumnKey.FieldView & "='" & p_Value & "'"
                                End If

                            ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                'DateTime
                                If p_ReturnValue = "" Then
                                    p_ReturnValue = " " & p_ColumnKey.FieldView & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & _
                                        p_Convert_Date(p_Value) & "')") & ""
                                Else
                                    p_ReturnValue = p_ReturnValue & " AND " & p_ColumnKey.FieldView & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & _
                                        p_Convert_Date(p_Value) & "')") & ""
                                End If
                            End If
                        Else
                            p_ReturnValue = ""
                            Return p_ReturnValue
                        End If
                        'End If

                    End If
                Next
            End With
        Catch ex As Exception
            g_Module.ModErrExceptionNew(Err.Number, ex.Message)
            p_Err = True
            p_ReturnValue = ""
        End Try
        If p_ReturnValue <> "" Then
            p_ReturnValue = " WHERE " & p_ReturnValue
        End If
        Return p_ReturnValue
    End Function



    Public Function get_Where_Config111(ByVal p_Table As DataTable, ByVal p_GridView As U_TextBox.GridView, _
                                        ByVal p_dataTable As DataTable, _
                                ByVal p_RowID As Integer, ByRef p_Err As Boolean) As String
        Dim p_ReturnValue As String = ""
        Dim p_ColumnKey As U_TextBox.GridColumn
        Dim p_Value As String
        Dim p_DataRow() As DataRow
        Dim p_Count As Integer
        Dim p_FielName As String
        Dim p_DataType As String
        Dim p_String As String = UCase("System.String")
        Dim p_DateTime As String = UCase("System.DateTime")
        Dim p_Int As String = UCase("System.Int32,System.Int16,System.Decimal,System.Double")
        Try
            p_Err = False
            With p_GridView
                For p_Count = 0 To .Columns.Count - 1
                    p_ColumnKey = .Columns(p_Count)
                    If p_ColumnKey.ColumnKey = True Then
                        If Not p_Table Is Nothing Then
                            p_DataRow = p_Table.Select("COLUMN_NAME='" & p_ColumnKey.FieldView & "'")
                            If p_DataRow.Length <= 0 Then
                                Continue For
                            End If
                        End If

                        ' p_Value = p_GridView.GetRowCellValue(p_RowID, p_ColumnKey.FieldView).ToString
                        p_Value = p_dataTable.Rows(p_RowID).Item(p_ColumnKey.FieldView).ToString
                        p_Value = Replace(p_Value, "''''", """", 1)
                        p_Value = Replace(p_Value, "'''", """", 1)
                        p_Value = Replace(p_Value, "''", """", 1)
                        p_Value = Replace(p_Value, "'", """", 1)
                        p_DataType = UCase(p_ColumnKey.ColumnType.ToString)
                        If p_Value <> "" Then


                            If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                'Number
                                If p_ReturnValue = "" Then

                                    p_ReturnValue = " " & p_ColumnKey.FieldView & "=" & p_Value
                                Else

                                    p_ReturnValue = p_ReturnValue & " AND " & p_ColumnKey.FieldView & "=" & p_Value
                                End If

                            ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                'String

                                If p_ReturnValue = "" Then

                                    p_ReturnValue = " " & p_ColumnKey.FieldView & "='" & p_Value & "'"
                                Else

                                    p_ReturnValue = p_ReturnValue & " AND " & p_ColumnKey.FieldView & "='" & p_Value & "'"
                                End If

                            ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                'DateTime
                                If p_ReturnValue = "" Then
                                    p_ReturnValue = " " & p_ColumnKey.FieldView & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & _
                                        p_Convert_Date(p_Value) & "')") & ""
                                Else
                                    p_ReturnValue = p_ReturnValue & " AND " & p_ColumnKey.FieldView & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & _
                                        p_Convert_Date(p_Value) & "')") & ""
                                End If
                            End If
                        Else
                            p_ReturnValue = ""
                            Return p_ReturnValue
                        End If
                        'End If

                    End If
                Next
            End With
        Catch ex As Exception
            g_Module.ModErrExceptionNew(Err.Number, ex.Message)
            p_Err = True
            p_ReturnValue = ""
        End Try
        If p_ReturnValue <> "" Then
            p_ReturnValue = " WHERE " & p_ReturnValue
        End If
        Return p_ReturnValue
    End Function


    Public Function p_CompileTrueDBGirdToSQLNew1111(ByVal p_Form As Object, ByVal p_RecordHist As Boolean, _
                                            ByVal p_TrueDbGird As U_TextBox.TrueDBGrid, _
                                             ByVal p_GridViewIn As U_TextBox.GridView, _
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
        Dim p_DateTime As String = UCase("System.DateTime,System.Date")
        Dim p_Int As String = UCase("System.Int32,System.Int16,System.Decimal,System.Double,System.single")
        Dim p_DataType As String
        Dim p_FieldName As String
        Dim p_TableName As String
        Dim p_TblStructure As New System.Data.DataSet
        Dim p_Rows() As DataRow
        Dim p_RowArr() As DataRow
        Dim p_TimeValue As Integer
        Dim p_DateValue As Date
        Dim p_DateValue_Hist As DateTime

        Dim p_Col1 As New DataColumn("Column0")
        Dim p_Row As DataRow

        Dim p_Desc As String

        Dim p_CellValue As String
        '  Dim p_ColumnKeyIns As Boolean

        Dim p_ColumnEnableUpdate As String = ""
        Dim p_ColumnVisibleUpdate As String = ""

        Dim p_ColumnKeyType As String
        Dim p_DataCheck As DataTable
        Dim p_Dt As DataTable

        Dim p_SQL As String
        Dim p_GridView As U_TextBox.GridView

        Dim p_Insert As Integer    'Danh dau loai cap nhat(1:Addnew    2: Update     0: khong lam gi)

        Dim p_Column As U_TextBox.GridColumn

        Dim p_WhereNew As String = ""
        Dim p_Error As Boolean
        Dim p_AllowInsert As Boolean

        Dim p_DataTableUpdate As System.Data.DataTable
        Dim p_BindingSource As New U_TextBox.U_BindingSource
        Dim p_ValueNumber As Double
        Dim p_ValueDate As Date

        Try
            p_Column = p_GridViewIn.Columns.Item(p_GridViewIn.ColumnKey.ToString.Trim)
        Catch ex As Exception
            p_Column = Nothing
        End Try
        If Not p_Column Is Nothing Then
            p_ColumnKeyType = p_Column.FieldType ' p_GridView.column
        End If
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

        p_CompileTrueDBGirdToSQLNew1111 = "TRUE"

        'p_GridViewIn.UpdateCurrentRow()


        p_TableName = UCase(p_GridViewIn.TableName)
        If p_TableName.ToString.Trim = "" Then Exit Function

        'anhqh
        '26/06/2014
        'Lay các giá trị de tìm kiém
        p_AllowInsert = p_GridViewIn.AllowInsert


        If p_RecordHist = True Then
            If g_DBTYPE = "ORACLE" Then
               p_SQL = "select COLUMN_NAME AS ColumnName, 0 AS user_type_id from dba_tab_cols WHERE Table_name='" & p_TableName & "'" & _
                         "AND   UPPER ( COLUMN_NAME) in (upper('CreateDate'),upper('CreateTime'),upper('UpdateDate'),upper('UpdateTime'),upper('CreateBy'),upper('UpdatedBy'))"
                p_Dt = g_Service.clsGetDataTableOracle(p_SQL, p_SQL)
                'FPT_CheckFieldHist
            ElseIf g_DBTYPE = "SQL" Then
                p_Dt = g_Service.mod_SYS_GET_DATATABLE("exec  FPT_CheckFieldHist '" & p_TableName & "'")
            End If

        End If

        p_Desc = ""
        Try



            If p_TableStructure(p_TableName, p_TblStructure, p_GetB1) = False Then
                Exit Function
            End If
            If p_TblStructure.Tables.Count <= 0 Then
                p_CompileTrueDBGirdToSQLNew1111 = "Không tìm được cấu trúc bảng " & p_TableName
                Exit Function
            End If

            If p_TblStructure.Tables(0).Rows.Count <= 0 Then
                p_CompileTrueDBGirdToSQLNew1111 = "Không tìm được cấu trúc bảng " & p_TableName
                Exit Function
            End If




            p_GridView = p_GridViewIn

            'anhqh
            '20160701
            'Chuyen code khi update hoac addnew thi khong  can truong CheckUpd nua
            ' p_TrueDbGird.RefreshDataSource()
            p_BindingSource = p_TrueDbGird.DataSource
            p_DataTableUpdate = CType(p_BindingSource.DataSource, DataTable)


            If p_CheckRequiredGridView(p_Form.Name,
                                                     p_TrueDbGird.Name,
                                                   p_GridView) = False Then
                p_CompileTrueDBGirdToSQLNew1111 = "ERROR"

                ' MsgBox(p_SQL)
                Exit Function
            End If
            'p_GridView.EndUpdate()
            ' p_GridView.EndSelection
            'p_GridView.MoveLast()
            For p_Count = 0 To p_DataTableUpdate.Rows.Count - 1 ' p_GridView.RowCount - 1
                p_Insert = 0
                p_SQL_Upd = ""

                p_Field_Value = ""
                p_Field_Ins = ""
                p_SQL_Del = ""


                'If p_DataTableUpdate.Rows(p_Count).RowState = DataRowState.Unchanged _
                '   Or p_DataTableUpdate.Rows(p_Count).RowState = DataRowState.Detached Then
                '    Continue For
                'End If


                If p_DataTableUpdate.Rows(p_Count).RowState = DataRowState.Deleted Or p_DataTableUpdate.Rows(p_Count).RowState = DataRowState.Unchanged _
                    Or p_DataTableUpdate.Rows(p_Count).RowState = DataRowState.Detached Then
                    Continue For
                End If

                p_WhereNew = get_Where_Config111(p_TblStructure.Tables(0), p_GridView, p_DataTableUpdate, p_Count, p_Error)

                'If p_DataTableUpdate.Rows(p_Count).RowState = DataRowState.Deleted Then
                '    MsgBox("delete")
                'End If

                If p_Error = True Then
                    p_DataTable = Nothing
                    Exit Function
                End If
                'p_Insert = 1

                If p_DataTableUpdate.Rows(p_Count).RowState = DataRowState.Added Then
                    p_Insert = 1
                Else
                    p_Insert = 2
                End If

                If p_WhereNew <> "" Then
                    If g_DBTYPE = "ORACLE" Then
                        'If p_ColumnKeyType = "N" Then
                        '    p_SQL = "Select 1 from " & p_TableName & " nolock " & get_Where_Config(p_TblStructure.Tables(0), p_GridView)
                        'Else
                        p_SQL = "Select 1 from " & p_TableName & "  nolock " & p_WhereNew
                        'End If
                        p_DataCheck = g_Service.clsGetDataTableOracle(p_SQL, p_SQL)
                    ElseIf g_DBTYPE = "SQL" Then
                        'If p_ColumnKeyType = "N" Then
                        '    'p_RowsCheck = p_DataCheck.Select(p_ColumnKey & "=" & p_CellValue)
                        '    p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_TableName & " with (nolock) " & get_Where_Config(p_TblStructure.Tables(0), p_GridView)
                        'Else

                        'p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_TableName & "  with (nolock) " & p_WhereNew & "'"

                        p_SQL = "Select 1 from " & p_TableName & "  with (nolock) " & p_WhereNew
                        'End If
                        p_DataCheck = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
                    End If

                    If p_DataCheck.Rows.Count > 0 Then
                        '   p_Insert = 2
                        If p_DataTableUpdate.Rows(p_Count).RowState = DataRowState.Added Then

                            g_Module.ModErrExceptionNew("MS0001", "Bản ghi đã tồn tại")
                            p_DataTable = Nothing
                            Exit Function
                        End If
                        'If p_GridView.GetRowCellValue(p_Count, "CHECKUPD").ToString.Trim = "R" Then
                        '    p_Insert = 1
                        'End If
                    End If

                End If
                'If p_AllowInsert = False And p_Insert = 1 Then
                '    p_Insert = 2
                'End If
                If p_Insert = 1 Then
                    'INSERT
                    If p_AllowInsert = True Then
                        For p_Col = 0 To p_GridView.Columns.Count - 1

                            p_Column = p_GridView.Columns.Item(p_Col)
                            If p_Column.AllowInsert = True Then
                                p_DataType = p_Column.ColumnType.ToString               ' p_GridView.Columns(p_Col).ColumnType.ToString
                                p_FieldName = p_Column.FieldName.ToString            ' p_GridView.Columns(p_Col).FieldName.ToString
                                If p_FieldName <> "" Then
                                    p_Rows = p_TblStructure.Tables(0).Select("COLUMN_NAME='" & p_FieldName & "'")
                                    If p_Rows.Count > 0 Then
                                        Try

                                            'p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                            If p_Column.CopyFromItem.ToString.Trim <> "" Then
                                                'CopyFromItem
                                                p_CellValue = CopyFromItem(p_Form, p_Column.CopyFromItem.ToString.Trim)
                                            Else


                                                If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                                    ' p_ValueNumber = p_GridView.GetRowCellValue(p_Count, p_FieldName)

                                                    Double.TryParse(p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString, p_ValueNumber)
                                                    p_CellValue = p_ValueNumber.ToString("#############.######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                    If p_CellValue = "" Then
                                                        p_CellValue = "0"
                                                    End If
                                                ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                                    If p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString <> "" Then
                                                        p_ValueDate = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                                        p_CellValue = p_ValueDate.ToString(g_Format_DateTime, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                    Else
                                                        p_CellValue = ""
                                                    End If

                                                Else
                                                    p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                                End If
                                                'p_CellValue = p_DataTableUpdate.Rows(p_Count).Item(p_FieldName).ToString   'p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                            End If


                                            ''anhqh
                                            '20161220
                                            'Can luu y khi dung cho SQLServer vi truong key dung AutoNumber
                                            If UCase(g_DBTYPE) = "ORACLE" And p_Column.ColumnKey = True Then
                                                Dim p_SequenName As String = ""
                                                If Not p_Column.SequenceName Is Nothing Then
                                                    p_SequenName = p_Column.SequenceName.ToString.Trim
                                                End If
                                                If p_SequenName <> "" Then
                                                    p_SQL = "SELECT " & p_SequenName & ".nextval as Auto_ID from dual"
                                                    'End If
                                                    p_DataCheck = g_Service.clsGetDataTableOracle(p_SQL, p_SQL)
                                                    If Not p_DataCheck Is Nothing Then
                                                        If p_DataCheck.Rows.Count > 0 Then
                                                            p_CellValue = p_DataCheck.Rows(0).Item(0)
                                                        End If
                                                    End If
                                                End If
                                            End If


                                            p_CellValue = Replace(p_CellValue, "''''", """", 1)
                                            p_CellValue = Replace(p_CellValue, "'''", """", 1)
                                            p_CellValue = Replace(p_CellValue, "''", """", 1)
                                            p_CellValue = Replace(p_CellValue, "'", """", 1)

                                            If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                                'Number

                                                p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                p_Field_Value = p_Field_Value & "," & _
                                                           IIf(p_CellValue = "", 0, p_CellValue)

                                            ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                                'String

                                                p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                p_Field_Value = p_Field_Value & ",N'" & _
                                                        p_CellValue & "'"

                                            ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                               

                                                'If p_Column.ShowDataTime = False Then
                                                '    p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                '    p_Field_Value = p_Field_Value & "," & _
                                                '      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                                '            p_Convert_Date(p_CellValue) & "')")
                                                'Else
                                                '    p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                '    p_Field_Value = p_Field_Value & "," & _
                                                '      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                                '            p_Convert_DateTime(p_CellValue) & "')")
                                                'End If
                                                If p_CellValue <> "" Then
                                                    If UCase(g_DBTYPE) = "ORACLE" Then
                                                        If p_Column.ShowDataTime = False Then
                                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                            p_Field_Value = p_Field_Value & "," & IIf(p_CellValue = "", "Null", "to_date('" & CDate(p_CellValue).ToString("yyyy/MM/dd") & "','YYYY/MM/DD')")
                                                        Else
                                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                            p_Field_Value = p_Field_Value & "," & IIf(p_CellValue = "", "Null", "to_date('" & p_CellValue & "', 'yyyy/mm/dd hh:mi:ss AM')")
                                                        End If

                                                    Else
                                                        If p_Column.ShowDataTime = False Then
                                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                            p_Field_Value = p_Field_Value & "," & _
                                                              IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                                                    p_CellValue & "')")
                                                        Else
                                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                            p_Field_Value = p_Field_Value & "," & _
                                                              IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                                                    p_CellValue & "')")
                                                        End If
                                                    End If
                                                Else

                                                    p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                    p_Field_Value = p_Field_Value & ",null"
                                                End If
                                            End If

                                        Catch ex As Exception

                                        End Try
                                    End If
                                End If
                            End If
                        Next
                    End If
                ElseIf p_Insert = 2 Then
                    'Update
                    p_SQL_Upd = ""
                    p_Where = ""
                    For p_Col = 0 To p_GridView.Columns.Count - 1
                        p_Column = p_GridView.Columns.Item(p_Col)
                        If p_Column.AllowUpdate = True Or p_Column.ColumnKey = True Then
                            p_DataType = UCase(p_GridView.Columns(p_Col).ColumnType.ToString)
                            p_FieldName = p_GridView.Columns(p_Col).FieldName.ToString
                            p_Rows = p_TblStructure.Tables(0).Select("COLUMN_NAME='" & p_FieldName & "'")
                            If p_Rows.Count > 0 Then
                                If p_Column.CopyFromItem.ToString.Trim <> "" Then
                                    'CopyFromItem
                                    p_CellValue = CopyFromItem(p_Form, p_Column.CopyFromItem.ToString.Trim)
                                Else

                                    If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                        ' p_ValueNumber = p_GridView.GetRowCellValue(p_Count, p_FieldName)

                                        Double.TryParse(p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString, p_ValueNumber)
                                        p_CellValue = p_ValueNumber.ToString("#############.######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                        If p_CellValue = "" Then
                                            p_CellValue = "0"
                                        End If
                                    ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                        If p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString <> "" Then
                                            p_ValueDate = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                            p_CellValue = p_ValueDate.ToString(g_Format_DateTime, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                        Else
                                            p_CellValue = ""
                                        End If

                                    Else
                                        p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                    End If

                                    'p_CellValue = p_DataTableUpdate.Rows(p_Count).Item(p_FieldName).ToString    ' p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                End If

                                p_CellValue = Replace(p_CellValue, "''''", """", 1)
                                p_CellValue = Replace(p_CellValue, "'''", """", 1)
                                p_CellValue = Replace(p_CellValue, "''", """", 1)
                                p_CellValue = Replace(p_CellValue, "'", """", 1)
                                If p_CellValue Is Nothing Then
                                    p_CellValue = ""
                                End If
                                If Not p_CellValue Is Nothing Then
                                    If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                        'Number
                                        If p_Column.ColumnKey = False Then ' p_ColumnKey = p_FieldName Then
                                            '    p_Where = " WHERE " & p_ColumnKey & "=" & IIf(p_CellValue = "", 0, _
                                            '            p_CellValue)
                                            'Else
                                            p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                       IIf(p_CellValue = "", 0, p_CellValue)

                                        End If
                                    ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                        'String
                                        If p_Column.ColumnKey = False Then   ' p_ColumnKey = p_FieldName Then
                                            '    p_Where = " WHERE " & p_ColumnKey & "=N'" & p_CellValue & "'"
                                            'Else

                                            p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                                p_CellValue & "'"

                                        End If
                                    ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                        'DateTime                                   
                                        If p_Column.ColumnKey = False Then
                                            'If p_Column.ShowDataTime = False Then
                                            '    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                            '                      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                            '                            p_Convert_Date(p_CellValue) & "')")
                                            'Else
                                            '    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                            '                      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                            '                            p_Convert_DateTime(p_CellValue) & "')")
                                            'End If

                                            If p_Column.ColumnKey = False Then
                                                If p_Column.ShowDataTime = False Then
                                                    If UCase(g_DBTYPE) = "ORACLE" Then
                                                        If p_CellValue <> "" Then
                                                            p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                                     IIf(p_CellValue = "", "Null", "to_date('" & CDate(p_CellValue).ToString("yyyy/MM/dd") & "','YYYY/MM/DD')")
                                                        Else
                                                            p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=null"
                                                        End If

                                                    Else
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                                      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                                                            p_CellValue & "')")
                                                    End If


                                                Else
                                                    If UCase(g_DBTYPE) = "ORACLE" Then
                                                        If p_CellValue <> "" Then
                                                            p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                                      IIf(p_CellValue = "", "Null", "to_date('" & p_CellValue & "', 'yyyy/mm/dd hh:mi:ss AM')")
                                                        Else
                                                            p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=null"
                                                        End If

                                                    Else
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                                          IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                                                                p_CellValue & "')")
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
                If p_Insert = 1 Or p_Insert = 2 Then
                    If p_SQL_Upd <> "" And p_WhereNew <> "" Then

                        If p_RecordHist = True And Not p_Dt Is Nothing Then

                            p_RowArr = p_Dt.Select("ColumnName='UPDATEDATE' or ColumnName='UPDATETIME' Or ColumnName='UPDATEDBY' OR ColumnName='CREATEBY' OR ColumnName='CREATEDATE'")

                            'p_GetDateTime(p_DateValue, p_TimeValue)
                            p_GetFullDateTime(p_DateValue_Hist, p_TimeValue)
                            For p_Count1 = 0 To p_RowArr.Length - 1

                                If g_DBTYPE = "SQL" Then
                                    If p_RowArr(p_Count1).Item(1) = 40 Or p_RowArr(p_Count1).Item(1) = 61 Then  'Date

                                        p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "='" & p_DateValue_Hist.ToString(g_Format_DateTime) & "'"
                                    End If

                                    If p_RowArr(p_Count1).Item(1) = 52 Or p_RowArr(p_Count1).Item(1) = 56 Then  'Time

                                        p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "=" & p_TimeValue
                                    End If

                                    If p_RowArr(p_Count1).Item(1) = 231 Or p_RowArr(p_Count1).Item(1) = 175 Then  'CreatedBy

                                        p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "='" & p_UserName & "'"
                                    End If
                                End If
                            Next
                        End If

                        p_SQL_Upd = "UPDATE " & p_TableName & " SET " & Mid(p_SQL_Upd, 2) & p_WhereNew
                        p_Row = p_DataTable.NewRow

                        p_Row(0) = p_SQL_Upd
                        p_DataTable.Rows.Add(p_Row)

                        ' p_SQLExecute(p_Count) = p_SQL_Upd
                    ElseIf p_Field_Ins <> "" And p_Field_Value <> "" Then

                        If p_RecordHist = True And Not p_Dt Is Nothing Then
                            p_RowArr = p_Dt.Select("ColumnName='UPDATEDATE' or ColumnName='UPDATETIME' Or ColumnName='UPDATEDBY' OR ColumnName='CREATEBY' OR ColumnName='CREATEDATE'")

                            'p_GetDateTime(p_DateValue, p_TimeValue)
                            p_GetFullDateTime(p_DateValue_Hist, p_TimeValue)

                            For p_Count1 = 0 To p_RowArr.Length - 1
                                If p_RowArr(p_Count1).Item(1) = 40 Or p_RowArr(p_Count1).Item(1) = 61 Then  'Date
                                    p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count1).Item(0)
                                    p_Field_Value = p_Field_Value & ",'" & p_DateValue_Hist.ToString(g_Format_DateTime) & "'"
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
            p_CompileTrueDBGirdToSQLNew1111 = ex.Message.ToString
            ' p_FptModule = Nothing
            'p_Sysbatch = Nothing
        End Try
    End Function

    Public Function p_CompileTrueDBGirdToSQLNew(ByVal p_Form As Object, ByVal p_RecordHist As Boolean, _
                                            ByVal p_TrueDbGird As U_TextBox.TrueDBGrid, _
                                             ByVal p_GridViewIn As U_TextBox.GridView, _
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
        Dim p_DateTime As String = UCase("System.DateTime,System.Date")
        Dim p_Int As String = UCase("System.Int32,System.Int16,System.Decimal,System.Double,System.single")
        Dim p_DataType As String
        Dim p_FieldName As String
        Dim p_TableName As String
        Dim p_TblStructure As New System.Data.DataSet
        Dim p_Rows() As DataRow
        Dim p_RowArr() As DataRow
        Dim p_TimeValue As Integer
        Dim p_DateValue As Date
        Dim p_DateValue_Hist As DateTime


        Dim p_MerSelectField As String
        Dim p_MerInsrt As String
        Dim p_MerValue As String
        Dim p_MerUpd As String

        Dim p_Col1 As New DataColumn("Column0")
        Dim p_Row As DataRow

        Dim p_Desc As String

        Dim p_CellValue As String
        '  Dim p_ColumnKeyIns As Boolean

        Dim p_ColumnEnableUpdate As String = ""
        Dim p_ColumnVisibleUpdate As String = ""

        Dim p_ColumnKeyType As String
        Dim p_DataCheck As DataTable
        Dim p_Dt As DataTable

        Dim p_SQL As String
        Dim p_GridView As U_TextBox.GridView

        Dim p_Insert As Integer    'Danh dau loai cap nhat(1:Addnew    2: Update     0: khong lam gi)

        Dim p_Column As U_TextBox.GridColumn


        Dim p_ValueNumber As Double
        Dim p_ValueDate As Date
        'Dim p_ColumnInsert As Boolean
        'Dim p_ColumnUpdate As Boolean

        'Dim p_WherString As String = ""
        'Dim p_ColumnKeyWhere As U_TextBox.GridColumn
        Dim p_WhereNew As String = ""
        Dim p_Error As Boolean
        Dim p_AllowInsert As Boolean


        Dim p_Number As Double



        'Dim p_Source As New U_TextBox.U_BindingSource
        'Dim p_Tbl As New DataTable
        'p_Source = p_TrueDbGird.DataSource
        'p_Tbl = CType(p_Source.DataSource, DataTable)

        If p_GridViewIn.CheckUpd = False Then
            p_CompileTrueDBGirdToSQLNew = p_CompileTrueDBGirdToSQLNew1111(p_Form, p_RecordHist, _
                                             p_TrueDbGird, _
                                              p_GridViewIn, _
                                              p_DataTable, _
                                           p_GetB1,
                                         p_ColumnCHECKUPDate, _
                                          p_UserName)
            Exit Function
        End If



        Try
            p_Column = p_GridViewIn.Columns.Item(p_GridViewIn.ColumnKey.ToString.Trim)
        Catch ex As Exception
            p_Column = Nothing
        End Try
        If Not p_Column Is Nothing Then
            p_ColumnKeyType = p_Column.FieldType ' p_GridView.column
        End If
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

        p_CompileTrueDBGirdToSQLNew = "TRUE"

        p_TableName = UCase(p_GridViewIn.TableName)
        If p_TableName.ToString.Trim = "" Then Exit Function

        'anhqh
        '26/06/2014
        'Lay các giá trị de tìm kiém
        p_AllowInsert = p_GridViewIn.AllowInsert


        If p_RecordHist = True Then
            If g_DBTYPE = "ORACLE" Then
                'Dim p_OracleArr(0) As OracleClient.OracleParameter
                ''p_Dt = g_Service.SYS_GET_DATATABLE_oracle("select FPT_CheckFieldHist ('" & p_TableName & "') from dual")

                'p_OracleArr(0) = New OracleClient.OracleParameter
                'p_OracleArr(0).ParameterName = "p_TableName"
                'p_OracleArr(0).Value = p_TableName

                'p_OracleArr(0).OracleType = OracleClient.OracleType.NVarChar
                'p_OracleArr(0).Direction = ParameterDirection.Input


                'g_Service.ModCallFuntioncReturnCursorOralce("FPT_CheckFieldHist", p_Desc, p_OracleArr, p_Dt)
                p_SQL = "select COLUMN_NAME AS ColumnName, 0 AS user_type_id from dba_tab_cols WHERE Table_name='" & p_TableName & "'" & _
                        "AND   UPPER ( COLUMN_NAME) in (upper('CreateDate'),upper('CreateTime'),upper('UpdateDate'),upper('UpdateTime'),upper('CreateBy'),upper('UpdatedBy'))"
                p_Dt = g_Service.clsGetDataTableOracle(p_SQL, p_SQL)
                'FPT_CheckFieldHist
            ElseIf g_DBTYPE = "SQL" Then
                p_Dt = g_Service.mod_SYS_GET_DATATABLE("exec  FPT_CheckFieldHist '" & p_TableName & "'")
            End If

        End If

        p_Desc = ""
        Try



            If p_TableStructure(p_TableName, p_TblStructure, p_GetB1) = False Then
                Exit Function
            End If
            If p_TblStructure.Tables.Count <= 0 Then
                p_CompileTrueDBGirdToSQLNew = "Không tìm được cấu trúc bảng " & p_TableName
                Exit Function
            End If

            If p_TblStructure.Tables(0).Rows.Count <= 0 Then
                p_CompileTrueDBGirdToSQLNew = "Không tìm được cấu trúc bảng " & p_TableName
                Exit Function
            End If


            p_GridViewIn.RefreshData()

            p_GridView = p_GridViewIn

            'Dim p_Table001 As System.Data.DataTable
            'Dim p_Binding As New U_TextBox.U_BindingSource
            'p_Binding = p_TrueDbGird.DataSource
            'p_DataCheck = CType(p_Binding.DataSource, DataTable)


            If p_ColumnCHECKUPDate <> "" Then
                p_GridView.ActiveFilterString = p_ColumnCHECKUPDate & "='Y' Or " & p_ColumnCHECKUPDate & "='I' Or " & p_ColumnCHECKUPDate & "='R'"
            End If

            If p_CheckRequiredGridView(p_Form.Name,
                                                     p_TrueDbGird.Name,
                                                   p_GridView) = False Then
                p_CompileTrueDBGirdToSQLNew = "ERROR"

                ' MsgBox(p_SQL)
                Exit Function
            End If
            'p_GridView.EndUpdate()
            ' p_GridView.EndSelection
            p_GridView.MoveLast()
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
                    'p_CellValue = p_GridView.GetRowCellValue(p_Count, p_ColumnKey).ToString
                Catch ex As Exception
                    p_DataTable = Nothing
                    MsgBox(p_Desc)
                    Exit Function
                End Try
                p_WhereNew = get_Where_Config(p_TblStructure.Tables(0), p_GridView, p_Count, p_Error)

                If p_Error = True Then
                    p_DataTable = Nothing
                    Exit Function
                End If
                p_Insert = 1
                'If p_CellValue.ToString.Trim <> "" Then
                ' If p_GridView.ColumnKey.ToString.Trim <> "" Then
                If p_WhereNew <> "" Then
                    If g_DBTYPE = "ORACLE" Then
                        'If p_ColumnKeyType = "N" Then
                        '    p_SQL = "Select 1 from " & p_TableName & " nolock " & get_Where_Config(p_TblStructure.Tables(0), p_GridView)
                        'Else
                        p_SQL = "Select 1 from " & p_TableName & "  nolock " & p_WhereNew
                        'End If
                        p_DataCheck = g_Service.clsGetDataTableOracle(p_SQL, p_SQL)
                    ElseIf g_DBTYPE = "SQL" Then
                        'If p_ColumnKeyType = "N" Then
                        '    'p_RowsCheck = p_DataCheck.Select(p_ColumnKey & "=" & p_CellValue)
                        '    p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_TableName & " with (nolock) " & get_Where_Config(p_TblStructure.Tables(0), p_GridView)
                        'Else

                        'p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_TableName & "  with (nolock) " & p_WhereNew & "'"

                        p_SQL = "Select 1 from " & p_TableName & "  with (nolock) " & p_WhereNew
                        'End If
                        p_DataCheck = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
                    End If

                    If p_DataCheck.Rows.Count > 0 Then
                        p_Insert = 2
                        If p_GridView.GetRowCellValue(p_Count, "CHECKUPD").ToString.Trim = "I" Then
                            p_GridView.ClearColumnsFilter()
                            g_Module.ModErrExceptionNew("MS0001", "Bản ghi đã tồn tại")
                            p_DataTable = Nothing
                            Exit Function
                        End If
                        If p_GridView.GetRowCellValue(p_Count, "CHECKUPD").ToString.Trim = "R" Then
                            p_Insert = 1
                        End If
                    End If
                    'End If
                    'End If
                End If
                'If p_AllowInsert = False And p_Insert = 1 Then
                '    p_Insert = 2
                'End If
                If p_Insert = 1 Then
                    'INSERT
                    If p_AllowInsert = True Then
                        For p_Col = 0 To p_GridView.Columns.Count - 1

                            p_Column = p_GridView.Columns.Item(p_Col)
                            If p_Column.AllowInsert = True Then
                                p_DataType = p_Column.ColumnType.ToString               ' p_GridView.Columns(p_Col).ColumnType.ToString
                                p_FieldName = p_Column.FieldName.ToString            ' p_GridView.Columns(p_Col).FieldName.ToString
                                If p_FieldName <> "" Then
                                    p_Rows = p_TblStructure.Tables(0).Select("COLUMN_NAME='" & p_FieldName & "'")
                                    If p_Rows.Count > 0 Then
                                        Try

                                            'p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                            If p_Column.CopyFromItem.ToString.Trim <> "" Then
                                                'CopyFromItem
                                                p_CellValue = CopyFromItem(p_Form, p_Column.CopyFromItem.ToString.Trim)
                                            Else
                                                'p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                                If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                                    ' p_ValueNumber = p_GridView.GetRowCellValue(p_Count, p_FieldName)

                                                    Double.TryParse(p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString, p_ValueNumber)
                                                    p_CellValue = p_ValueNumber.ToString("#############.######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                    If p_CellValue = "" Then
                                                        p_CellValue = "0"
                                                    End If
                                                ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                                    If p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString <> "" Then
                                                        p_ValueDate = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                                        p_CellValue = p_ValueDate.ToString(g_Format_DateTime, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                    Else
                                                        p_CellValue = ""
                                                    End If

                                                Else
                                                    p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                                End If
                                            End If

                                           

                                            ''anhqh
                                            '20161220
                                            'Can luu y khi dung cho SQLServer vi truong key dung AutoNumber
                                            If UCase(g_DBTYPE) = "ORACLE" And p_Column.ColumnKey = True Then
                                                Dim p_SequenName As String = ""
                                                If Not p_Column.SequenceName Is Nothing Then
                                                    p_SequenName = p_Column.SequenceName.ToString.Trim
                                                End If
                                                If p_SequenName <> "" Then
                                                    p_SQL = "SELECT " & p_SequenName & ".nextval as Auto_ID from dual"
                                                    'End If
                                                    p_DataCheck = g_Service.clsGetDataTableOracle(p_SQL, p_SQL)
                                                    If Not p_DataCheck Is Nothing Then
                                                        If p_DataCheck.Rows.Count > 0 Then
                                                            p_CellValue = p_DataCheck.Rows(0).Item(0)
                                                        End If
                                                    End If
                                                End If
                                            End If

                                            If p_CellValue <> "" Then
                                                p_CellValue = Replace(p_CellValue, "''''", """", 1)
                                                p_CellValue = Replace(p_CellValue, "'''", """", 1)
                                                p_CellValue = Replace(p_CellValue, "''", """", 1)
                                                p_CellValue = Replace(p_CellValue, "'", """", 1)
                                            End If



                                            If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                                '20240410'Number
                                                'p_MerValue
                                                'Dim p_MerSelectField As String
                                                'Dim p_MerInsrt As String
                                                'Dim p_MerUpd As String

                                                p_MerInsrt = p_Field_Ins & ",s." & p_FieldName
                                                p_MerSelectField = p_Field_Value & "," & _
                                                           IIf(p_CellValue = "", 0, p_CellValue) & " as  " & p_FieldName
                                                '=======================


                                                p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                p_Field_Value = p_Field_Value & "," & _
                                                           IIf(p_CellValue = "", 0, p_CellValue)

                                            ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                                'String

                                                p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                p_Field_Value = p_Field_Value & ",N'" & _
                                                        p_CellValue & "'"

                                            ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                                If p_CellValue <> "" Then
                                                    If UCase(g_DBTYPE) = "ORACLE" Then
                                                        If p_Column.ShowDataTime = False Then
                                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                            p_Field_Value = p_Field_Value & "," & IIf(p_CellValue = "", "Null", "to_date('" & CDate(p_CellValue).ToString("yyyy/MM/dd") & "','YYYY/MM/DD')")
                                                        Else
                                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                            p_Field_Value = p_Field_Value & "," & IIf(p_CellValue = "", "Null", "to_date('" & p_CellValue & "', 'yyyy/mm/dd hh:mi:ss AM')")
                                                        End If

                                                    Else
                                                        If p_Column.ShowDataTime = False Then
                                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                            p_Field_Value = p_Field_Value & "," & _
                                                              IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                                                    p_CellValue & "')")
                                                        Else
                                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                            p_Field_Value = p_Field_Value & "," & _
                                                              IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                                                    p_CellValue & "')")
                                                        End If
                                                    End If
                                                Else

                                                    p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                                    p_Field_Value = p_Field_Value & ",null"
                                                End If

                                                

                                                
                                            End If

                                        Catch ex As Exception

                                        End Try
                                    End If
                                End If

                            Else
                                

                            End If
                        Next
                    End If
                ElseIf p_Insert = 2 Then
                    'Update
                    p_SQL_Upd = ""
                    p_Where = ""
                    For p_Col = 0 To p_GridView.Columns.Count - 1
                        p_Column = p_GridView.Columns.Item(p_Col)


                        If p_Column.AllowUpdate = True Or p_Column.ColumnKey = True Then
                            p_DataType = UCase(p_GridView.Columns(p_Col).ColumnType.ToString)
                            p_FieldName = p_GridView.Columns(p_Col).FieldName.ToString


                            'If p_FieldName = "NgayXuat" Then
                            '    MsgBox("asas")
                            'End If
                            p_Rows = p_TblStructure.Tables(0).Select("COLUMN_NAME='" & p_FieldName & "'")
                            If p_Rows.Count > 0 Then
                                If p_Column.CopyFromItem.ToString.Trim <> "" Then
                                    'CopyFromItem
                                    p_CellValue = CopyFromItem(p_Form, p_Column.CopyFromItem.ToString.Trim)
                                Else
                                    If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                        ' p_ValueNumber = p_GridView.GetRowCellValue(p_Count, p_FieldName)

                                        Double.TryParse(p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString, p_ValueNumber)
                                        p_CellValue = p_ValueNumber.ToString("#############.######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                    ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                        If p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString <> "" Then
                                            p_ValueDate = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                            p_CellValue = p_ValueDate.ToString(g_Format_DateTime, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                        Else
                                            p_CellValue = ""
                                        End If

                                    Else
                                        If p_GridView.GetRowCellValue(p_Count, p_Column) Is Nothing Then
                                            p_CellValue = ""
                                        Else
                                            p_CellValue = p_GridView.GetRowCellValue(p_Count, p_Column).ToString.Trim()
                                        End If
                                        'p_CellValue = IIf(p_GridView.GetRowCellValue(p_Count, p_Column) Is Nothing, "", p_GridView.GetRowCellValue(p_Count, p_Column).ToString.Trim)
                                    End If
                                    ' p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                End If

                                p_Number = 0

                                p_CellValue = Replace(p_CellValue, "''''", """", 1)
                                p_CellValue = Replace(p_CellValue, "'''", """", 1)
                                p_CellValue = Replace(p_CellValue, "''", """", 1)
                                p_CellValue = Replace(p_CellValue, "'", """", 1)
                                If p_CellValue Is Nothing Then
                                    p_CellValue = ""
                                End If
                                If Not p_CellValue Is Nothing Then
                                    If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                        'Number
                                        If p_Column.ColumnKey = False Then ' p_ColumnKey = p_FieldName Then
                                            '    p_Where = " WHERE " & p_ColumnKey & "=" & IIf(p_CellValue = "", 0, _
                                            '            p_CellValue)
                                            'Else
                                            p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                       IIf(p_CellValue = "", 0, p_CellValue)

                                        End If
                                    ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                        'String
                                        If p_Column.ColumnKey = False Then   ' p_ColumnKey = p_FieldName Then
                                            '    p_Where = " WHERE " & p_ColumnKey & "=N'" & p_CellValue & "'"
                                            'Else

                                            p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=N'" & _
                                                p_CellValue & "'"

                                        End If
                                    ElseIf InStr(p_DateTime, p_DataType, CompareMethod.Text) > 0 Then
                                        'DateTime                                   
                                        If p_Column.ColumnKey = False Then
                                            If p_Column.ShowDataTime = False Then
                                                If UCase(g_DBTYPE) = "ORACLE" Then
                                                    If p_CellValue <> "" Then
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                                 IIf(p_CellValue = "", "Null", "to_date('" & CDate(p_CellValue).ToString("yyyy/MM/dd") & "','YYYY/MM/DD')")
                                                    Else
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=null"
                                                    End If
                                                   
                                                Else
                                                    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                                  IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                                                        p_CellValue & "')")
                                                End If

                                                
                                            Else
                                                If UCase(g_DBTYPE) = "ORACLE" Then
                                                    If p_CellValue <> "" Then
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                                  IIf(p_CellValue = "", "Null", "to_date('" & p_CellValue & "', 'yyyy/mm/dd hh:mi:ss AM')")
                                                    Else
                                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=null"
                                                    End If
                                                    
                                                Else
                                                    p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                                      IIf(p_CellValue = "", "Null", "convert(DateTime,'" & _
                                                                            p_CellValue & "')")
                                                End If
                                            End If

                                        End If
                                        End If
                                End If
                            End If
                        End If
                    Next

                End If
                If p_Insert = 1 Or p_Insert = 2 Then
                    If p_SQL_Upd <> "" And p_WhereNew <> "" Then

                        If p_RecordHist = True And Not p_Dt Is Nothing Then

                            p_RowArr = p_Dt.Select("ColumnName='UPDATEDATE' or ColumnName='UPDATETIME' Or ColumnName='UPDATEDBY' OR ColumnName='CREATEBY' OR ColumnName='CREATEDATE'")

                            'p_GetDateTime(p_DateValue, p_TimeValue)
                            p_GetFullDateTime(p_DateValue_Hist, p_TimeValue)


                            'Dim dateformat As New System.Globalization.DateTimeFormatInfo()
                            'dateformat.ShortDatePattern = g_Format_DateTime
                            'dateformat.FullDateTimePattern = g_Format_DateTime
                            'p_DateValue_Hist = Date.Parse(p_DateValue_Hist.ToString, dateformat)



                            For p_Count1 = 0 To p_RowArr.Length - 1

                                'If g_DBTYPE = "ORACLE" Then
                                '    If p_RowArr(p_Count1).Item(1) = "DATE" Then  'Date

                                '        p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "='" & p_DateValue.ToString(g_Format_DateTime) & "'"
                                '    End If

                                '    If p_RowArr(p_Count1).Item(1) = "NUMBER" Then  'Time

                                '        p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "=" & p_TimeValue
                                '    End If

                                '    If p_RowArr(p_Count1).Item(1) = "NVARCHAR2" Or p_RowArr(p_Count1).Item(1) = "VARCHAR2" Then  'CreatedBy

                                '        p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "='" & p_UserName & "'"
                                '    End If
                                'End If
                                If g_DBTYPE = "SQL" Then
                                    If p_RowArr(p_Count1).Item(1) = 40 Or p_RowArr(p_Count1).Item(1) = 61 Then  'Date

                                        'p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "='" & p_DateValue_Hist.ToString(g_Format_DateTime) & "'"
                                        p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "='" & p_DateValue_Hist.ToString(g_Format_DateTime, System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) & "'"
                                    End If

                                    If p_RowArr(p_Count1).Item(1) = 52 Or p_RowArr(p_Count1).Item(1) = 56 Then  'Time

                                        p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "=" & p_TimeValue
                                    End If

                                    If p_RowArr(p_Count1).Item(1) = 231 Or p_RowArr(p_Count1).Item(1) = 175 Then  'CreatedBy

                                        p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "='" & p_UserName & "'"
                                    End If
                                End If
                            Next
                        End If

                        p_SQL_Upd = "UPDATE " & p_TableName & " SET " & Mid(p_SQL_Upd, 2) & p_WhereNew
                        p_Row = p_DataTable.NewRow

                        p_Row(0) = p_SQL_Upd
                        p_DataTable.Rows.Add(p_Row)

                        ' p_SQLExecute(p_Count) = p_SQL_Upd
                    ElseIf p_Field_Ins <> "" And p_Field_Value <> "" Then

                        If p_RecordHist = True And Not p_Dt Is Nothing Then
                            p_RowArr = p_Dt.Select("ColumnName='UPDATEDATE' or ColumnName='UPDATETIME' Or ColumnName='UPDATEDBY' OR ColumnName='CREATEBY' OR ColumnName='CREATEDATE'")

                            'p_GetDateTime(p_DateValue, p_TimeValue)
                            p_GetFullDateTime(p_DateValue_Hist, p_TimeValue)

                            For p_Count1 = 0 To p_RowArr.Length - 1
                                If p_RowArr(p_Count1).Item(1) = 40 Or p_RowArr(p_Count1).Item(1) = 61 Then  'Date
                                    p_Field_Ins = p_Field_Ins & "," & p_RowArr(p_Count1).Item(0)
                                    p_Field_Value = p_Field_Value & ",'" & p_DateValue_Hist.ToString(g_Format_DateTime, System.Globalization.CultureInfo.CreateSpecificCulture("en-US")) & "'"
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
            p_CompileTrueDBGirdToSQLNew = ex.Message.ToString
            ' p_FptModule = Nothing
            'p_Sysbatch = Nothing
        End Try
    End Function

    Function CopyFromItem(ByVal p_Form As Object, ByVal p_FromItem As String) As String
        Dim p_ControlArr() As Object
        Dim p_Value As String = ""
        Dim p_ItemName As String

        If InStr(p_FromItem, ":", CompareMethod.Text) > 0 Then
            p_ItemName = Replace(p_FromItem, ":", "", 1)
            p_ControlArr = p_Form.Controls.find(p_ItemName, True)
            If p_ControlArr.Length > 0 Then
                If Not p_ControlArr(0).editvalue Is Nothing Then
                    p_Value = p_ControlArr(0).editvalue.ToString.Trim
                End If
            End If
        Else
            p_Value = p_FromItem
        End If
        Return p_Value
    End Function
    'ANHQH
    '01/10/2012
    'Ham thuc hien chuyen di lieu tu Grid thanh SQL roi exec

    Public Function p_CompileTrueDBGirdToSQLNew(ByVal p_Form As Object, ByVal p_RecordHist As Boolean, _
                                             ByVal p_TrueDbGird As U_TextBox.U_TrueDBGrid, _
                                              ByVal p_GridViewIn As U_TextBox.GridView, _
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

        Dim p_Col1 As New DataColumn("Column0")
        Dim p_Row As DataRow

        Dim p_Desc As String

        Dim p_CellValue As String
        '  Dim p_ColumnKeyIns As Boolean

        Dim p_ColumnEnableUpdate As String = ""
        Dim p_ColumnVisibleUpdate As String = ""

        Dim p_ColumnKeyType As String
        Dim p_DataCheck As DataTable
        Dim p_Dt As DataTable

        Dim p_SQL As String
        Dim p_GridView As U_TextBox.GridView

        Dim p_Insert As Integer    'Danh dau loai cap nhat(1:Addnew    2: Update     0: khong lam gi)

        Dim p_Column As U_TextBox.GridColumn

        '  Dim p_ColumnInsert As Boolean
        ' Dim p_ColumnUpdate As Boolean
        Dim p_ParentControlName As String
        Dim p_ParentControl() As Object


        Try
            p_Column = p_GridViewIn.Columns.Item(p_GridViewIn.ColumnKey.ToString.Trim)
        Catch ex As Exception
            p_Column = Nothing
        End Try
        If Not p_Column Is Nothing Then
            p_ColumnKeyType = p_Column.FieldType ' p_GridView.column
        End If
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

        p_CompileTrueDBGirdToSQLNew = "TRUE"

        p_ColumnKey = p_GridViewIn.ColumnKey
        ' p_ColumnKeyIns = p_GridView.ColumnKeyIns
        p_TableName = UCase(p_GridViewIn.TableName)
        If p_TableName.ToString.Trim = "" Then Exit Function

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


            If p_ColumnKey = "" Then
                p_CompileTrueDBGirdToSQLNew = "ColumnKey chưa khai báo"
                Exit Function

            End If

            If p_TableStructure(p_TableName, p_TblStructure, p_GetB1) = False Then
                Exit Function
            End If
            If p_TblStructure.Tables.Count <= 0 Then
                p_CompileTrueDBGirdToSQLNew = "Không tìm được cấu trúc bảng " & p_TableName
                Exit Function
            End If

            If p_TblStructure.Tables(0).Rows.Count <= 0 Then
                p_CompileTrueDBGirdToSQLNew = "Không tìm được cấu trúc bảng " & p_TableName
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
                                                   p_GridView) = False Then
                p_CompileTrueDBGirdToSQLNew = "ERROR"

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
                        p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_TableName & " with (nolock) Where " & p_ColumnKey & "=" & p_CellValue & "'"
                    Else
                        p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_TableName & "  with (nolock) Where " & p_ColumnKey & "=''" & p_CellValue & "'''"
                    End If
                    p_DataCheck = g_Service.mod_SYS_GET_DATATABLE(p_SQL)
                    If p_DataCheck.Rows.Count > 0 Then
                        p_Insert = 2
                        If p_GridView.GetRowCellValue(p_Count, "CHECKUPD").ToString.Trim = "I" Then
                            p_GridView.ClearColumnsFilter()
                            g_Module.ModErrExceptionNew("MS0001", "Bản ghi đã tồn tại")
                            p_DataTable = Nothing
                            Exit Function
                        End If
                    End If

                End If
                If p_Insert = 1 Then
                    'INSERT
                    For p_Col = 0 To p_GridView.Columns.Count - 1

                        p_Column = p_GridView.Columns.Item(p_Col)
                        If p_Column.AllowInsert = True Then


                            p_DataType = p_Column.ColumnType.ToString               ' p_GridView.Columns(p_Col).ColumnType.ToString
                            p_FieldName = p_Column.FieldName.ToString            ' p_GridView.Columns(p_Col).FieldName.ToString
                            If p_FieldName <> "" Then
                                p_Rows = p_TblStructure.Tables(0).Select("COLUMN_NAME='" & p_FieldName & "'")
                                If p_Rows.Count > 0 Then
                                    Try
                                        p_CellValue = ""
                                        p_ParentControlName = p_Column.ParentControl.ToString.Trim
                                        If p_ParentControlName <> "" Then
                                            p_ParentControl = p_Form.controls.find(p_ParentControlName, True)
                                            If p_ParentControl.Length > 0 Then
                                                If Not p_ParentControl(0).EditValue Is Nothing Then
                                                    p_CellValue = p_ParentControl(0).EditValue.ToString.Trim
                                                End If
                                            End If
                                        End If
                                        If p_CellValue.ToString.Trim = "" Then
                                            p_CellValue = p_GridView.GetRowCellValue(p_Count, p_FieldName).ToString
                                            p_CellValue = Replace(p_CellValue, "''''", """", 1)
                                            p_CellValue = Replace(p_CellValue, "'''", """", 1)
                                            p_CellValue = Replace(p_CellValue, "''", """", 1)
                                            p_CellValue = Replace(p_CellValue, "'", """", 1)
                                        End If

                                        If InStr(p_Int, p_DataType, CompareMethod.Text) > 0 Then
                                            'Number

                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                            p_Field_Value = p_Field_Value & "," & _
                                                       IIf(p_CellValue = "", 0, p_CellValue)

                                        ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                            'String

                                            p_Field_Ins = p_Field_Ins & "," & p_FieldName
                                            p_Field_Value = p_Field_Value & ",N'" & _
                                                    p_CellValue & "'"

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
                        End If
                    Next
                ElseIf p_Insert = 2 Then
                    'Update
                    p_SQL_Upd = ""
                    p_Where = ""
                    For p_Col = 0 To p_GridView.Columns.Count - 1
                        p_Column = p_GridView.Columns.Item(p_Col)
                        If p_Column.AllowUpdate = True Or p_Column.ColumnKey = True Then
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
                                    If p_Column.ColumnKey = True Then ' p_ColumnKey = p_FieldName Then
                                        p_Where = " WHERE " & p_ColumnKey & "=" & IIf(p_CellValue = "", 0, _
                                                p_CellValue)
                                    Else
                                        p_SQL_Upd = p_SQL_Upd & "," & p_FieldName & "=" & _
                                                   IIf(p_CellValue = "", 0, p_CellValue)

                                    End If
                                ElseIf InStr(p_String, p_DataType, CompareMethod.Text) > 0 Then
                                    'String
                                    If p_Column.ColumnKey = True Then   ' p_ColumnKey = p_FieldName Then
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

                                    p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "='" & p_DateValue.ToString("yyyyMMdd") & "'"
                                End If

                                If p_RowArr(p_Count1).Item(1) = 52 Or p_RowArr(p_Count1).Item(1) = 56 Then  'Time

                                    p_SQL_Upd = p_SQL_Upd & "," & p_RowArr(p_Count1).Item(0) & "=" & p_TimeValue
                                End If

                                If p_RowArr(p_Count1).Item(1) = 231 Or p_RowArr(p_Count1).Item(1) = 175 Then  'CreatedBy

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
            p_CompileTrueDBGirdToSQLNew = ex.Message.ToString
            ' p_FptModule = Nothing
            'p_Sysbatch = Nothing
        End Try
    End Function

    'anhqh
    '30/06/2014
    'Dungf cho cac tabcontrol
    'ByVal p_BindingSource As Object, _
    'ByVal p_DBDataSet As DataSet, ByVal p_TableID As Integer, _
    Public Function p_CompileControlHeader_PageToSQLNew(
                                                     ByRef p_Form As Object, _
                                             ByVal p_Object As Object, _
                                    ByVal p_Table_Name As String, _
                                    ByVal p_Insert_Type As Boolean, _
                                     ByRef p_Field_Ins As String, _
                                            ByRef p_Field_Value As String, _
                                             ByRef p_SQL_Upd As String, _
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
        'Dim p_TrueDBGrid As U_TextBox.U_TrueDBGrid
        'Dim p_GridView As U_TextBox.GridView
        'Dim p_Object1 As DevExpress.XtraTab.XtraTabControl
        Dim p_AllowInsert As Boolean
        Dim p_AllowUpdate As Boolean

        Dim p_AutoKeyName As String
        Dim p_DocEntry11 As Double
        Dim p_AutoKeyFix As String
        Dim p_AutoKeyString As String
        Dim p_RowArr() As DataRow
        Dim p_ValueDate As Date
        Dim p_ValueNumber As Double

        p_CompileControlHeader_PageToSQLNew = True
        If InStr(UCase(p_Object.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
            Try
                For p_TabControl_Ind = p_Object.TabPages.Count - 1 To 0 Step -1
                    If p_Object.TabPages.Count > 1 Then
                        p_Object.SelectedTabPageIndex = p_TabControl_Ind
                    End If

                    p_Object_Tab = p_Object.TabPages(p_TabControl_Ind) ' p_Control

                    If InStr(UCase(p_Object_Tab.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                        If p_CompileControlHeader_PageToSQLNew(p_Form,
                                                     p_Object_Tab,
                                                       p_Table_Name,
                                                       p_Insert_Type,
                                                         p_Field_Ins,
                                                         p_Field_Value,
                                                          p_SQL_Upd,
                                                          p_Table,
                                                          p_UserName) = False Then
                            p_CompileControlHeader_PageToSQLNew = False
                            Exit Function
                        End If
                    Else
                        If InStr(UCase(p_Object_Tab.GetType.ToString), "XtraTabPage", CompareMethod.Text) > 0 Then
                            For Each p_Object_Tab_Item In p_Object_Tab.Controls
                                If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Tabpage, CompareMethod.Text) > 0 Then
                                    If p_CompileControlHeader_PageToSQLNew(p_Form,
                                                                 p_Object_Tab_Item,
                                                                   p_Table_Name,
                                                                   p_Insert_Type,
                                                                     p_Field_Ins,
                                                                     p_Field_Value,
                                                                      p_SQL_Upd,
                                                                     p_Table,
                                                          p_UserName) = False Then
                                        p_CompileControlHeader_PageToSQLNew = False
                                        Exit Function
                                    End If
                                Else

                                    If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                                        Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                                         Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                                     Or InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 Then
                                        If UCase(p_Object_Tab_Item.TableName.ToString) = UCase(p_Table_Name) And Not p_Object_Tab_Item.EditValue Is Nothing Then


                                            p_AllowInsert = p_Object_Tab_Item.AllowInsert
                                            p_AllowUpdate = p_Object_Tab_Item.AllowUpdate

                                            p_FieldType = UCase(p_Object_Tab_Item.FieldType)

                                            p_ItemName = UCase(p_Object_Tab_Item.FieldName)

                                            p_FieldType = UCase(p_Object_Tab_Item.FieldType)
                                            p_KeyInsert = UCase(p_Object_Tab_Item.KeyInsert)

                                            If p_Insert_Type = True Then
                                                If p_AllowInsert = True Then
                                                    If p_Object_Tab_Item.EditValue.ToString <> "" Then
                                                        p_ItemName = UCase(p_Object_Tab_Item.FieldName)




                                                        If p_Object_Tab_Item.primarykey.ToString.Trim = "Y" Then
                                                            ' If p_KeyInsert = "N" And p_Object_Tab_Item.PrimaryKey = "Y" Then
                                                            Try
                                                                p_AutoKeyName = p_Object_Tab_Item.AutoKeyName
                                                                p_AutoKeyFix = p_Object_Tab_Item.AutoKeyFix
                                                                If p_AutoKeyName.Trim <> "" Then
                                                                    'If Me.DocEntry.EditValue = 0 Then
                                                                    p_DocEntry11 = g_Service.SysGetPrimary(p_AutoKeyName.Trim)
                                                                    If p_AutoKeyFix.ToString.Trim <> "" And p_FieldType = "C" Then
                                                                        p_AutoKeyString = Left(p_AutoKeyFix, Len(p_AutoKeyFix) - Len(p_DocEntry11)) & p_DocEntry11
                                                                    Else
                                                                        p_Object_Tab_Item.EditValue = p_DocEntry11
                                                                    End If

                                                                Else
                                                                    Return False
                                                                End If
                                                            Catch ex As Exception

                                                            End Try
                                                        End If
                                                        p_Value = p_Object_Tab_Item.EditValue.ToString


                                                        Select Case p_FieldType
                                                            Case "D"
                                                                If p_Value <> "" Then
                                                                    p_ValueDate = p_Object_Tab_Item.EditValue.ToString
                                                                    p_Value = p_ValueDate.ToString(g_Format_DateTime, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                                Else
                                                                    p_Value = ""
                                                                End If
                                                            Case "N"
                                                                Double.TryParse(p_Object_Tab_Item.EditValue.ToString, p_ValueNumber)
                                                                p_Value = p_ValueNumber.ToString("#############.######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                                If p_Value = "" Then
                                                                    p_Value = "0"
                                                                End If
                                                            Case "F"
                                                                Double.TryParse(p_Object_Tab_Item.EditValue.ToString, p_ValueNumber)
                                                                p_Value = p_ValueNumber.ToString("#############.######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                                If p_Value = "" Then
                                                                    p_Value = "0"
                                                                End If
                                                            Case Else
                                                                p_Value = p_Object_Tab_Item.EditValue.ToString
                                                        End Select




                                                        p_Value = Replace(p_Value, "'", "")

                                                        If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                            If p_Object_Tab_Item.checked = False Then
                                                                p_Value = p_Object_Tab_Item.UnCheckValue.ToString.Trim

                                                            Else
                                                                p_Value = p_Object_Tab_Item.CheckValue.ToString.Trim
                                                            End If

                                                        End If


                                                        'Else
                                                        If p_FieldType = "D" Then
                                                            ' p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                            'p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                            If UCase(g_DBTYPE) = "ORACLE" Then
                                                                If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 Then
                                                                    If p_Object_Tab_Item.ShowDateTime = False Then
                                                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                        p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "to_date('" & CDate(p_Value).ToString("yyyy/MM/dd") & "','YYYY/MM/DD')")
                                                                    Else
                                                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                        p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "to_date('" & p_Value & "', 'yyyy/mm/dd hh:mi:ss AM')")
                                                                    End If
                                                                Else
                                                                    p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                    p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "to_date('" & CDate(p_Value).ToString("yyyy/MM/dd") & "','YYYY/MM/DD')")
                                                                End If
                                                            Else
                                                                If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 Then
                                                                    If p_Object_Tab_Item.ShowDateTime = False Then
                                                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                        p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                                    Else
                                                                        p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                        p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                                    End If
                                                                Else
                                                                    p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                    p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                                End If
                                                            End If
                                                        End If
                                                        If p_FieldType = "C" Then
                                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                            p_Field_Value = p_Field_Value & ",N'" & p_Value & "'"
                                                        End If
                                                        If p_FieldType = "N" Then 'Number
                                                            p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                            p_Field_Value = p_Field_Value & "," & p_Value & ""
                                                        End If
                                                        ' End If
                                                    End If
                                                End If
                                            Else
                                                'UPDATE
                                                'Kiem tra neu nhu co update cua Tbale thi moi thực hiện tiếp
                                                p_RowArr = p_Form.pv_TableEdit.Select("TableEdit='" & UCase(p_Table_Name) & "'")
                                                If p_RowArr.Length > 0 Then
                                                    If p_AllowUpdate = True Then
                                                        p_ItemName = UCase(p_Object_Tab_Item.FieldName)

                                                        p_FieldType = UCase(p_Object_Tab_Item.FieldType)
                                                        If p_Object_Tab_Item.EditValue Is Nothing Then
                                                            p_Value = ""
                                                        Else
                                                            ' p_Value = p_Object_Tab_Item.EditValue.ToString
                                                            Select Case p_FieldType
                                                                Case "D"
                                                                    If p_Object_Tab_Item.EditValue.ToString <> "" Then
                                                                        p_ValueDate = p_Object_Tab_Item.EditValue.ToString
                                                                        p_Value = p_ValueDate.ToString(g_Format_DateTime, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                                    Else
                                                                        p_Value = ""
                                                                    End If
                                                                Case "N"
                                                                    Double.TryParse(p_Object_Tab_Item.EditValue.ToString, p_ValueNumber)
                                                                    p_Value = p_ValueNumber.ToString("#############.######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                                    If p_Value = "" Then
                                                                        p_Value = "0"
                                                                    End If
                                                                Case "F"
                                                                    Double.TryParse(p_Object_Tab_Item.EditValue.ToString, p_ValueNumber)
                                                                    p_Value = p_ValueNumber.ToString("#############.######", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))
                                                                    If p_Value = "" Then
                                                                        p_Value = "0"
                                                                    End If
                                                                Case Else
                                                                    p_Value = p_Object_Tab_Item.EditValue.ToString
                                                            End Select
                                                        End If

                                                        p_Value = Replace(p_Value, "'", "")

                                                        If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                            If p_Object_Tab_Item.checked = False Then
                                                                p_Value = p_Object_Tab_Item.UnCheckValue.ToString.Trim
                                                                '   p_Value.Trim = p_Object_Tab_Item.CheckValue.ToString.Trim
                                                            Else
                                                                p_Value = p_Object_Tab_Item.CheckValue.ToString.Trim
                                                            End If

                                                        End If


                                                        If p_Object_Tab_Item.PrimaryKey = "Y" Then


                                                        Else
                                                            'If p_Object_Tab_Item.NoUpdate.trim <> "Y" Then
                                                            If p_FieldType = "D" Then  'Ngay thang
                                                                ' p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                                If UCase(g_DBTYPE) = "ORACLE" Then
                                                                    If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 Then
                                                                        If p_Value = "" Then
                                                                            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=null"
                                                                        Else
                                                                            If p_Object_Tab_Item.ShowDateTime = False Then
                                                                                p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", "to_date('" & CDate(p_Value).ToString("yyyy/MM/dd") & "','YYYY/MM/DD')")
                                                                            Else
                                                                                p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", "to_date('" & p_Value & "', 'yyyy/mm/dd hh:mi:ss AM')")
                                                                            End If

                                                                        End If

                                                                    Else
                                                                        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Convert_Date(p_Value) = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                                    End If
                                                                Else
                                                                    If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 Then
                                                                        If p_Value = "" Then
                                                                            '  If p_Object.ShowDateTime = False Then
                                                                            p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=null"
                                                                            'Else
                                                                            ' p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=null"
                                                                            ' End If
                                                                        Else
                                                                            If p_Object_Tab_Item.ShowDateTime = False Then
                                                                                p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Convert_Date(p_Value) = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                                            Else
                                                                                p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Convert_Date(p_Value) = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                                            End If

                                                                        End If

                                                                    Else
                                                                        p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Convert_Date(p_Value) = "", "Null", "convert(DateTime,'" & p_Value & "')")
                                                                    End If

                                                                End If
                                                            End If
                                                            If p_FieldType = "C" Then
                                                                If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 Then
                                                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Object_Tab_Item.Checked = True, "'" & p_Object_Tab_Item.CheckValue & "'", "'" & p_Object_Tab_Item.UnCheckValue & "'")
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
                                                            'End If
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
                p_CompileControlHeader_PageToSQLNew = False
                Exit Function
            End Try
        End If

    End Function



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
                    If p_Object.TabPages.Count > 1 Then
                        p_Object.SelectedTabPageIndex = p_TabControl_Ind
                    End If

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
                                                     p_GridView
                                                      ) = False Then
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

                                                            If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 Then
                                                                If p_Object_Tab_Item.ShowDateTime = False Then
                                                                    p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                    p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                                                Else
                                                                    p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                    p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_DateTime(p_Value) & "')")
                                                                End If
                                                            Else
                                                                p_Field_Ins = p_Field_Ins & "," & p_ItemName
                                                                p_Field_Value = p_Field_Value & "," & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                                            End If
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
                                                            If InStr(UCase(p_Object_Tab_Item.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 Then
                                                                If p_Object_Tab_Item.ShowDateTime = False Then
                                                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                                                Else
                                                                    p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_DateTime(p_Value) & "')")
                                                                End If
                                                            Else
                                                                p_SQL_Upd = p_SQL_Upd & "," & p_ItemName & "=" & IIf(p_Value = "", "Null", "convert(DateTime,'" & p_Convert_Date(p_Value) & "')")
                                                            End If
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

End Module
