Public Class Navigator
    Private p_ViewName As String = ""
    Private p_DefaultButton As Boolean = True
    

    Public Property DefaultButton() As Boolean
        Get
            Return p_DefaultButton
        End Get
        Set(ByVal value As Boolean)
            p_DefaultButton = value
        End Set

    End Property


    Public Property ViewName() As String
        Get
            Return p_ViewName
        End Get
        Set(ByVal value As String)
            p_ViewName = value
        End Set

    End Property

    

    Public Sub NavigatorButtonType_Last(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_Form As Object
        'Dim p_BtnSave As U_ButtonCus
        'Dim p_Object() As Object
        If Me.DefaultButton = False Then Exit Sub
        If Me.ViewName.ToString.Trim = "" Then Exit Sub

        p_Form = FindForm()
        If p_Form Is Nothing Then Exit Sub
        p_Form.g_RecodeMove = True
        Dim p_Cancel As Boolean
        If CheckStausForm(p_Form, p_Cancel) = True Then
            If p_Cancel = True Then
                ButtonClickCancelEdit(sender)
                p_Form.FormStatus = False
            Else
                e.Handled = True
            End If

            Exit Sub
        End If
    End Sub

    Public Sub NavigatorButtonType_First(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_Form As Object


        If Me.DefaultButton = False Then Exit Sub
        If Me.ViewName.ToString.Trim = "" Then Exit Sub

        p_Form = FindForm()
        If p_Form Is Nothing Then Exit Sub
        Dim p_Cancel As Boolean
        p_Form.g_RecodeMove = True
        If CheckStausForm(p_Form, p_Cancel) = True Then
            If p_Cancel = True Then
                ButtonClickCancelEdit(sender)
                p_Form.FormStatus = False
            Else
                e.Handled = True
            End If

            Exit Sub
        End If
    End Sub



    Public Sub NavigatorButtonType_CancelEdit(ByRef sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        ButtonClickCancelEdit(sender)
        SendToBack()
    End Sub

    Public Sub NavigatorButtonType_EndEdit()
        Dim p_Form As Object
        'Dim p_BtnSave As U_ButtonCus
        'Dim p_Object() As Object
        If Me.DefaultButton = False Then Exit Sub
        If Me.ViewName.ToString.Trim = "" Then Exit Sub

        p_Form = FindForm()
        If p_Form Is Nothing Then Exit Sub
        p_Form.UpdateToDatabase(p_Form, p_Form.ButtonSave)
    End Sub

    Public Sub NavigatorButtonType_Next(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_Form As Object
        'Dim p_Cancel As Boolean
        If Me.DefaultButton = False Then Exit Sub
        If Me.ViewName.ToString.Trim = "" Then Exit Sub

        p_Form = FindForm()
        If p_Form Is Nothing Then Exit Sub
        'p_Form.g_FormLoad = True
        Dim p_Cancel As Boolean
        p_Form.g_RecodeMove = True
        If CheckStausForm(p_Form, p_Cancel) = True Then
            If p_Cancel = True Then
                ButtonClickCancelEdit(sender)
                p_Form.FormStatus = False
            Else
                e.Handled = True
            End If
            'p_Form.g_RecodeMove = False
            Exit Sub
        End If
        '   RefreshData()
        'p_Form.Loading = True
        ' p_Form.g_RecodeMove = False
    End Sub

    Public Sub NavigatorButtonType_NextPage(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_Form As Object
        'Dim p_BtnSave As U_ButtonCus
        'Dim p_Object() As Object
        If Me.DefaultButton = False Then Exit Sub
        If Me.ViewName.ToString.Trim = "" Then Exit Sub

        p_Form = FindForm()
        If p_Form Is Nothing Then Exit Sub

        p_Form.g_RecodeMove = True
        Dim p_Cancel As Boolean
        If CheckStausForm(p_Form, p_Cancel) = True Then
            If p_Cancel = True Then
                ButtonClickCancelEdit(sender)
                p_Form.FormStatus = False
            Else
                e.Handled = True
            End If

            Exit Sub
        End If
    End Sub

    Public Sub NavigatorButtonType_Prev(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_Form As Object
        'Dim p_BtnSave As U_ButtonCus
        'Dim p_Object() As Object
        If Me.DefaultButton = False Then Exit Sub
        If Me.ViewName.ToString.Trim = "" Then Exit Sub

        p_Form = FindForm()
        If p_Form Is Nothing Then Exit Sub
        ' p_Form.g_FormLoad = True
        p_Form.g_RecodeMove = True
        Dim p_Cancel As Boolean
        p_Form.g_RecodeMove = True
        If CheckStausForm(p_Form, p_Cancel) = True Then
            If p_Cancel = True Then
                ButtonClickCancelEdit(sender)
                p_Form.FormStatus = False
            Else
                e.Handled = True
            End If
            'p_Form.g_FormLoad = False
            ' p_Form.g_RecodeMove = False
            Exit Sub
        End If
        'p_Form.g_FormLoad = False
        ' p_Form.g_RecodeMove = False
    End Sub

    Public Sub NavigatorButtonType_PrevPage(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_Form As Object
        'Dim p_BtnSave As U_ButtonCus
        'Dim p_Object() As Object
        If Me.DefaultButton = False Then Exit Sub
        If Me.ViewName.ToString.Trim = "" Then Exit Sub

        p_Form = FindForm()
        If p_Form Is Nothing Then Exit Sub
        p_Form.g_RecodeMove = True
        Dim p_Cancel As Boolean
        If CheckStausForm(p_Form, p_Cancel) = True Then
            If p_Cancel = True Then
                ButtonClickCancelEdit(sender)
                p_Form.FormStatus = False
            Else
                e.Handled = True
            End If

            Exit Sub
        End If
    End Sub

    Public Sub NavigatorButtonType_Remove(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_Form As Object
        'Dim p_BtnSave As U_ButtonCus
        'Dim p_Object() As Object
        If Me.DefaultButton = False Then Exit Sub
        If Me.ViewName.ToString.Trim = "" Then Exit Sub

        p_Form = FindForm()
        If p_Form Is Nothing Then Exit Sub
        If MsgBox("Bạn có chắc chắn muốn xóa không?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Chú ý") = MsgBoxResult.Yes Then
            p_Form.DeleteHeaderRecord(p_Form)
        Else
            e.Handled = True
        End If
        
    End Sub




    'DeleteHeaderRecord


    Private Sub Navigator1_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles Me.ButtonClick
        'Dim p_Form As Object
        ''Dim p_BtnSave As U_ButtonCus
        ''Dim p_Object() As Object
        'If Me.DefaultButton = False Then Exit Sub
        'If Me.ViewName.ToString.Trim = "" Then Exit Sub

        'p_Form = FindForm()
        'If p_Form Is Nothing Then Exit Sub
        Select Case e.Button.ButtonType
            Case DevExpress.XtraEditors.NavigatorButtonType.Append
                NavigatorButtonType_Append(sender, e)
                ' e.Handled = True
            Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit
                NavigatorButtonType_CancelEdit(sender, e)
            Case DevExpress.XtraEditors.NavigatorButtonType.EndEdit
                'p_Form.UpdateToDatabase(p_Form, p_Form.ButtonSave)
                NavigatorButtonType_EndEdit()
            Case DevExpress.XtraEditors.NavigatorButtonType.Remove
                NavigatorButtonType_Remove(sender, e)
            Case DevExpress.XtraEditors.NavigatorButtonType.First
                NavigatorButtonType_First(sender, e)
            Case DevExpress.XtraEditors.NavigatorButtonType.Last
                NavigatorButtonType_Last(sender, e)
            Case DevExpress.XtraEditors.NavigatorButtonType.Next
                NavigatorButtonType_Next(sender, e)
            Case DevExpress.XtraEditors.NavigatorButtonType.NextPage
                NavigatorButtonType_NextPage(sender, e)
            Case DevExpress.XtraEditors.NavigatorButtonType.Prev
                NavigatorButtonType_Prev(sender, e)
            Case DevExpress.XtraEditors.NavigatorButtonType.PrevPage
                NavigatorButtonType_PrevPage(sender, e)
        End Select

    End Sub

    Function CheckStausForm(ByRef p_Form As Object, ByRef p_Cancel As Boolean) As Boolean

        Dim p_Value As Integer
        p_Cancel = False
        CheckStausForm = False

        If p_Form.FormStatus = True Then

            p_Value = p_Form.p_XtraModuleObj.ShowMessage(Me,
                                       "",
                    "Thông tin chưa được lưu. Bạn có muốn lưu lại không?",
                    True,
                    "Có",
                    True,
                    "Không",
                     True,
                    "Hủy",
                   2)
            Select Case p_Value
                Case 2 'Cancel  
                    CheckStausForm = True
                    ' p_Form.FormStatus = False

                Case 7  'No  khong luu

                    CheckStausForm = True
                    p_Cancel = True

                    'g_LineRemove.Clear()
                    p_Form.pv_LineRemove.clear()
                    p_Form.pv_TableEdit.clear()

                Case 6    'Yes
                    p_Form.UpdateToDatabase(Me, p_Form.ButtonSave.ToString.Trim)
                    If p_Form.FormStatus = True Then
                        CheckStausForm = True
                    End If
            End Select
        End If


    End Function

    'p_BindingSourceCancelEdit


    Public Sub NavigatorButtonType_Append(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_Form As Object
        Dim p_BtnSave() As Object

        p_Form = FindForm()

        Dim p_Cancel As Boolean
        'If CheckStausForm(p_Form, p_Cancel) = True Then
        '    If p_Cancel = True Then
        '        ButtonClickCancelEdit(sender)
        '        p_Form.FormStatus = False
        '    Else
        '        e.Handled = True
        '    End If

        '    Exit Sub
        'End If
        If p_Form.FormStatus = False Then
            ' If p_Form.p_BindingSourceAddNewRow = True Then
            If p_Form.EnableControl = False Then
                p_Form.p_XtraModuleObj.ModErrExceptionNew("MS", "Lỗi khi Enable Control")
                Exit Sub
            End If
            ' p_Form.FormStatus = True
            p_Form.FormLock = False


            If p_Form.ButtonSave.ToString.Trim <> "" Then
                p_BtnSave = p_Form.Controls.Find(p_Form.ButtonSave.ToString.Trim, True)
                If p_BtnSave.Length > 0 Then
                    p_BtnSave(0).Text = p_Form.CaptionUpd
                End If
            End If

            ' Me.Text = p_Form.CaptionUpd
            '   Exit Sub
            'End If

        Else

        End If
        ' p_Form.DefaultFormLoad = True
        'p_Form.Form1_Load(sender, e)
        'p_Form.Clear()
        'p_Form.g_LineRemove.Clear()
        'p_Form.pv_LineRemove.Clear()
        'If Me.DefaultFormLoad = True Then
        ' p_Form.XtraForm1_Load()
        'End If

        'p_Form.DefaultFormLoad = False


        'p_UpdateToDatabase(p_Form)
        p_Form.UnlockObjectIsNull()
        p_Form.g_FormAddnew = True
        ' e.Handled = True
        ' End If
    End Sub

    Public Sub ButtonClickCancelEdit(ByRef sender As Object)
        Dim p_Form As Object
        p_Form = FindForm()
        If p_Form.FormStatus = True Then
            If p_Form.p_BindingSourceCancelEdit(sender) = False Then

            End If
            p_Form.g_FormAddnew = False
            sender.Refresh()
        End If
    End Sub

    Public Sub RefreshData()
        Dim p_Form As Object
        p_Form = FindForm()
        p_Form.SetTrueGridPropertyNew(p_Form, _
                                         True)
        p_Form.g_RecodeMove = False
    End Sub

    Private Sub Navigator_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PositionChanged
        RefreshData()
    End Sub
End Class
