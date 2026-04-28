Public Class U_Button
    Private p_DefaultUpdate As Boolean = True

    Public Property DefaultUpdate() As Boolean
        Get
            Return p_DefaultUpdate
        End Get
        Set(ByVal value As Boolean)
            p_DefaultUpdate = value
        End Set

    End Property


    Sub U_Button1_Click(ByVal sender As System.Object, _
                   ByVal e As System.EventArgs) Handles MyClass.Click
        
        If Me.DefaultUpdate = False Then Exit Sub
        ModUpdate(sender, e)
    End Sub

    'Sub U_Button11_Click(ByVal sender As System.Object, _
    '               ByVal e As System.EventArgs) Handles MyBase.Click

    '    If Me.DefaultUpdate = False Then Exit Sub
    '    If UCase(Me.Name) = "BTNOK" Then
    '        p_UpdateToDatabase()
    '    End If
    '    'Me.OnClick(e)
    'End Sub


    Public Sub ModUpdate(ByVal sender As System.Object, _
                   ByVal e As System.EventArgs)
        'p_UpdateToDatabase()
        Dim p_Form As Object
        Dim p_ButtonSave As String = ""
        p_Form = FindForm()
        Try
            p_ButtonSave = p_Form.ButtonSave
        Catch ex As Exception
            Exit Sub
        End Try
        If UCase(Me.Name) = UCase(p_ButtonSave) Then
            p_UpdateToDatabase(p_Form)
            p_Form.LockObjectIsNull()
        End If
    End Sub


    Private Sub p_UpdateToDatabase(ByVal p_Form As Object)
        Dim p_DataTable As DataTable

        Dim p_SQL As String = ""
        Dim p_DataRow As DataRow
        'Dim p_Form As Object
        Dim p_ControlArr() As Object
        Dim p_ItemKey As Object = Nothing
        Dim p_ItemBtn As String = ""
        Dim p_Count As Integer

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

        p_DataTable = p_Form.p_XtraModuleObj.p_ModCompileControlHeaderToSQL(p_Form.p_XtraDataSet_TrueGird, True, p_Form, p_Form.HeaderSource, p_ItemKey, p_Form.SequenceName, Nothing, p_Form.SequenceName, p_Form.p_XtraUserName)
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
        Try
            p_Form.p_Addnew = False
        Catch ex As Exception

        End Try

        Me.Text = p_Form.CaptionAdd

        If p_Form.p_XtraModuleObj.ModSetTrueGridPropertyNew(p_Form.p_XtraDataSet_TrueGird, p_Form, True) Then

        End If

    End Sub


End Class
