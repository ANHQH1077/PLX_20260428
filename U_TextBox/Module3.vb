Module Module3
    Public g_Format_Date As String = "MM/dd/yyyy"
    Function p_Convert_Date(ByVal p_Str_Date As String) As String
        'If p_Connect_Type = "SQL" Then
        '    p_Convert_Date = Format(Convert.ToDateTime(p_Str_Date))
        'Else
        'If p_Str_Date = "" Then Return ""
        'If g_DBTYPE = "ORACLE" Then
        '    'p_DateValue.ToString("dd-MMMM-yyyy")
        '    p_Convert_Date = Format(Convert.ToDateTime(p_Str_Date), "dd-MMMM-yyyy")
        'ElseIf g_DBTYPE = "SQL" Then
        p_Convert_Date = Format(Convert.ToDateTime(p_Str_Date), g_Format_Date)
        'End If

        'End If
    End Function
    'anhqh
    '20150706
    'Doan code lay where theo config

    Function get_Where_Config(ByVal p_Table As DataTable, ByVal p_GridView As GridView, _
                                ByVal p_RowID As Integer) As String
        Dim p_ReturnValue As String = ""
        Dim p_ColumnKey As GridColumn
        Dim p_Value As String
        Dim p_DataRow() As DataRow
        Dim p_Count As Integer
        Dim p_FielName As String
        Dim p_DataType As String
        Dim p_String As String = UCase("System.String")
        Dim p_DateTime As String = UCase("System.DateTime")
        Dim p_Int As String = UCase("System.Int32,System.Int16,System.Decimal,System.Double")
        Try
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
                        'anhqh  20160315 -Lay theo FieldView
                        'p_Value = p_GridView.GetRowCellValue(p_RowID, p_ColumnKey.Name).ToString
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
                                    p_ReturnValue = " " & p_ColumnKey.FieldView & "='" & IIf(p_Value = "", "Null", "convert(DateTime,'" & _
                                        p_Convert_Date(p_Value) & "')") & "'"
                                Else
                                    p_ReturnValue = p_ReturnValue & " AND " & p_ColumnKey.FieldView & "='" & IIf(p_Value = "", "Null", "convert(DateTime,'" & _
                                        p_Convert_Date(p_Value) & "')") & "'"
                                End If
                            End If
                        End If
                        'End If

                    End If
                Next
            End With
        Catch ex As Exception
            p_ReturnValue = ""
        End Try
        If p_ReturnValue <> "" Then
            p_ReturnValue = " WHERE " & p_ReturnValue
        End If
        Return p_ReturnValue
    End Function
    Public Sub ModGridNavigatorButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_DesError As String = ""
        If e.Handled = True Then Exit Sub
        Dim p_Control As DevExpress.XtraGrid.GridControlNavigator
        Dim p_TrueGrid As TrueDBGrid
        Dim p_SQL As String = ""
        Dim p_Table As String = ""
        '   Dim p_ColumnKey As String = ""
        ' Dim p_FieldType As String = ""
        Dim p_GridView As GridView
        ' Dim p_Column As GridColumn
        Dim p_DataRow As DataRow
        Dim p_ArrRow() As DataRow

        '  Dim p_dataTbl As DataTable
        ' Dim p_BindingSource As System.Windows.Forms.BindingSource
        Dim p_Count As Integer
        '  Dim p_Desc As String = ""
        Dim p_WhereNew As String

        Dim p_RowArr() As Integer
        Dim p_Form As New Object

        'If e.Handled = False Then Exit Sub

        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            'ModGridNavigatorButtonRemove(sender)

            '  Exit Sub

            'e.Handled = True
            p_Control = sender
            p_TrueGrid = CType(p_Control.Parent, TrueDBGrid)
            If p_TrueGrid.DefaultRemove = False Then Exit Sub
            g_Form = p_TrueGrid.FindForm
            g_Module = g_Form.p_XtraModuleObj
            pv_LineRemove = g_Form.pv_LineRemove.Clone
            'If g_Module.ShowMessage(g_Form,
            '                           "MS0002",
            '        "Bạn có chắc chắn muốn thực hiện không?",
            '        True,
            '        "Có",
            '        True,
            '        "Không",
            '         False,
            '        "",
            '       2) = Windows.Forms.DialogResult.No Then
            '    e.Handled = True
            '    Exit Sub
            'End If
            Try
                p_GridView = p_TrueGrid.Views(0)
                p_Table = p_GridView.TableName.ToString.Trim
                'p_ColumnKey = p_GridView.ColumnKey.ToString.Trim
                'Try
                '    p_Column = p_GridView.Columns.Item(p_ColumnKey)
                '    p_FieldType = p_Column.FieldType
                'Catch ex As Exception
                '    e.Handled = True
                '    Exit Sub
                'End Try

                ' p_GridView = p_TrueGrid.Views(0)
                If p_GridView.FocusedRowHandle >= 0 Then
                    p_RowArr = p_GridView.GetSelectedRows
                    If p_GridView.DefaultRemove = False Then
                        Exit Sub
                    End If
                    If p_RowArr.Length > 0 Then



                        ''anhqh
                        ''20160704
                        ''Them vao bang dung khi luu
                        'p_Form = p_TrueGrid.FindForm
                        'If p_Form.pv_GridViewEdit.columns.count <= 0 Then
                        '    p_Form.pv_GridViewEdit.columns.add("STR_SQL")
                        'End If

                        'If p_Form.pv_GridViewEdit.rows.count <= 0 Then
                        '    p_DataRow = p_Form.pv_GridViewEdit.newrow
                        '    p_DataRow.Item(0) = UCase(p_TrueGrid.Name)
                        '    p_Form.pv_GridViewEdit.Rows.Add(p_DataRow)
                        'Else
                        '    p_ArrRow = p_Form.pv_GridViewEdit.select("STR_SQL='" & UCase(p_TrueGrid.Name) & "' ")
                        '    If p_ArrRow.Length = 0 Then
                        '        p_DataRow = p_Form.pv_GridViewEdit.newrow
                        '        p_DataRow.Item(0) = UCase(p_TrueGrid.Name)
                        '        p_Form.pv_GridViewEdit.Rows.Add(p_DataRow)
                        '    End If
                        'End If
                        ' p_ArrRow()


                        For p_Count = 0 To p_RowArr.Length - 1

                            If p_Table <> "" Then

                                If p_GridView.IsValidRowHandle(p_RowArr(p_Count)) Then

                                    p_WhereNew = get_Where_Config(Nothing, p_GridView, p_RowArr(p_Count))
                                    If p_WhereNew <> "" Then
                                        If pv_LineRemove.Columns.Count <= 0 Then
                                            pv_LineRemove.Columns.Add("STR_SQL")
                                        End If
                                        p_SQL = "DELETE FROM " & p_Table & p_WhereNew
                                        p_DataRow = pv_LineRemove.NewRow
                                        p_DataRow.Item(0) = p_SQL
                                        Try
                                            p_DataRow.Item(1) = p_Table
                                        Catch ex As Exception

                                        End Try
                                        pv_LineRemove.Rows.Add(p_DataRow)
                                    End If

                                    p_DataRow = Nothing


                                Else
                                    ' p_dataTbl.Rows.RemoveAt(p_GridView.FocusedRowHandle)
                                End If


                            Else
                                g_Module.ModErrExceptionNew("", "Không xác định kiểu dữ liệu của column key")
                                e.Handled = True
                                Exit Sub
                            End If
                        Next
                        If g_Form.FormStatus = False Then
                            Dim p_ButtonSave() As Object
                            p_ButtonSave = g_Form.Controls.Find(g_Form.ButtonSave, True)
                            g_Form.FormStatus = True
                            If p_ButtonSave.Length > 0 Then
                                p_ButtonSave(0).text = g_Form.CaptionUpd
                            End If

                        End If

                        'e.Handled = True
                        p_TrueGrid.Refresh()
                        g_Form.pv_LineRemove.Merge(pv_LineRemove)
                        pv_LineRemove.Clear()
                    End If
                End If
            Catch ex As Exception
                g_Module.ModErrExceptionNew(Err.Number, ex.Message)
                e.Handled = True
                Exit Sub
            End Try

        End If

    End Sub





    Public Sub ModGridNavigatorButtonRemove(ByVal sender As System.Object)
        Dim p_DesError As String = ""
        'If e.Handled = True Then Exit Sub
        Dim p_Control As DevExpress.XtraGrid.GridControlNavigator
        Dim p_TrueGrid As TrueDBGrid
        Dim p_SQL As String = ""
        Dim p_Table As String = ""
        Dim p_ColumnKey As String = ""
        Dim p_FieldType As String = ""
        Dim p_GridView As GridView
        Dim p_Column As GridColumn
        Dim p_DataRow As DataRow
        Dim p_dataTbl As DataTable
        Dim p_BindingSource As System.Windows.Forms.BindingSource

        Dim p_Desc As String = ""
        Dim p_WhereNew As String


        'If e.Handled = False Then Exit Sub

        ' If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
        'e.Handled = True
        p_Control = sender
        p_TrueGrid = CType(p_Control.Parent, TrueDBGrid)
        If p_TrueGrid.DefaultRemove = False Then Exit Sub
        g_Form = p_TrueGrid.FindForm
        g_Module = g_Form.p_XtraModuleObj
        pv_LineRemove = g_Form.pv_LineRemove.Clone
        'If g_Module.ShowMessage(g_Form,
        '                           "MS0002",
        '        "Bạn có chắc chắn muốn thực hiện không?",
        '        True,
        '        "Có",
        '        True,
        '        "Không",
        '         False,
        '        "",
        '       2) = Windows.Forms.DialogResult.No Then
        '    e.Handled = True
        '    Exit Sub
        'End If
        Try
            p_GridView = p_TrueGrid.Views(0)
            p_Table = p_GridView.TableName.ToString.Trim
            'p_ColumnKey = p_GridView.ColumnKey.ToString.Trim
            'Try
            '    p_Column = p_GridView.Columns.Item(p_ColumnKey)
            '    p_FieldType = p_Column.FieldType
            'Catch ex As Exception
            '    e.Handled = True
            '    Exit Sub
            'End Try

            ' p_GridView = p_TrueGrid.Views(0)
            If p_GridView.FocusedRowHandle >= 0 Then
                If p_GridView.DefaultRemove = False Then
                    Exit Sub
                End If
                p_DataRow = p_GridView.GetDataRow(p_GridView.FocusedRowHandle)
                If p_Table <> "" Then

                    'p_BindingSource = p_TrueGrid.DataSource
                    'p_dataTbl = CType(p_BindingSource.DataSource, DataTable)
                    If p_GridView.IsValidRowHandle(p_GridView.FocusedRowHandle) Then
                        ' p_GridView.SetRowCellValue(p_GridView.FocusedRowHandle, "CHECKUPD", "D")
                        'p_GridView.IsValidRowHandle()
                        ' p_GridView.HideEditor()


                        p_WhereNew = get_Where_Config(Nothing, p_GridView, p_GridView.FocusedRowHandle)

                        If p_WhereNew <> "" Then
                            p_SQL = "DELETE FROM " & p_Table & p_WhereNew
                            p_DataRow = pv_LineRemove.NewRow
                            p_DataRow.Item(0) = p_SQL
                            pv_LineRemove.Rows.Add(p_DataRow)
                        End If
                        'If p_FieldType = "N" Then
                        '    p_SQL = "DELETE FROM " & p_Table & " WHERE " & p_ColumnKey & "=" & p_DataRow.Item(p_ColumnKey)
                        'Else
                        '    p_SQL = "DELETE FROM " & p_Table & " WHERE " & p_ColumnKey & "='" & p_DataRow.Item(p_ColumnKey) & "'"
                        'End If
                        p_DataRow = Nothing


                        'p_dataTbl.Rows.RemoveAt(p_GridView.FocusedRowHandle)
                    Else
                        ' p_dataTbl.Rows.RemoveAt(p_GridView.FocusedRowHandle)
                    End If

                    If g_Form.FormStatus = False Then
                        Dim p_ButtonSave() As Object
                        p_ButtonSave = g_Form.Controls.Find(g_Form.ButtonSave, True)
                        g_Form.FormStatus = True
                        If p_ButtonSave.Length > 0 Then
                            p_ButtonSave(0).text = g_Form.CaptionUpd
                        End If

                    End If

                    'e.Handled = True
                    p_TrueGrid.Refresh()
                    g_Form.pv_LineRemove.Merge(pv_LineRemove)
                    pv_LineRemove.Clear()
                Else
                    g_Module.ModErrExceptionNew("MS0003", "Không xác định kiểu dữ liệu của column key")
                    '   e.Handled = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            g_Module.ModErrExceptionNew(Err.Number, ex.Message)
            ' e.Handled = True
            Exit Sub
        End Try

        ' End If

    End Sub

End Module
