Module Module2
    Public Sub p_UpdateToDatabase(ByVal p_Form As Object, Optional ByVal p_BtnSave As String = "")
        Dim p_DataTable As DataTable

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

        If p_Form.g_XtraServicesObj Is Nothing Then
            'MsgBox("g_XtraServicesObj Is Nothing")
            p_Form.p_XtraModuleObj.ModErrExceptionNew("", "g_XtraServicesObj Is Nothing")
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
        'If p_ItemKey Is Nothing Then
        '    MsgBox(p_Form.FormItemKey.ToString.Trim & "-Không tồn tại")
        '    Exit Sub
        'End If

        'p_DataTable = p_Form.CompileControlHeaderToSQL(p_Form.p_XtraDataSet_TrueGird, True, p_Form, p_Form.HeaderSource, p_ItemKey, p_Form.SequenceName, Nothing, p_Form.SequenceName, p_Form.p_XtraUserName)
        p_Error = False

        p_DataTable = p_Form.CompileControlHeaderToSQL(p_Error, True, p_Form, p_Form.HeaderSource, p_ItemKey, p_Form.SequenceName, Nothing, p_Form.SequenceName, p_Form.p_XtraUserName)
        If p_Error = True Then
            Exit Sub
        End If
        If p_DataTable Is Nothing Then
            Exit Sub
        End If

        If Not p_DataTable Is Nothing Then
            If Not p_Form.pv_LineRemove Is Nothing Then
                For p_Count = 0 To p_Form.pv_LineRemove.rows.count - 1
                    If p_Form.pv_LineRemove.rows(p_Count).item(0).ToString.Trim <> "" Then
                        p_DataRow = p_DataTable.NewRow
                        p_DataRow.Item(0) = p_Form.pv_LineRemove.rows(p_Count).item(0).ToString.Trim
                        p_DataTable.Rows.Add(p_DataRow)
                    End If
                Next
            End If
            If p_DataTable.Rows.Count > 0 Then

                If p_Form.g_XtraServicesObj.Sys_Execute_DataTbl(p_DataTable, p_SQL) = False Then
                    'MsgBox(p_SQL)
                    p_Form.p_XtraModuleObj.ModErrExceptionNew("", p_SQL)
                    Exit Sub
                End If
            Else
                'MsgBox("Không xác định được dữ liệu cần cập nhật")
                p_Form.p_XtraModuleObj.ModErrExceptionNew("MS0004", "Lỗi khi cập nhật")
                Exit Sub
            End If
        Else
            p_Form.p_XtraModuleObj.ModErrExceptionNew("MS0004", "Lỗi khi cập nhật")
            Exit Sub
        End If

        p_Form.FormStatus = False

        p_Form.SetValueType()

        Try
            p_Form.p_Addnew = False
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
        If p_Form.SetTrueGridPropertyNew(p_Form, True) = False Then
            p_Form.p_XtraModuleObj.ModErrExceptionNew("MS", "Lỗi khi Requery")
        End If

    End Sub

End Module
