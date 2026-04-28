Public Class U_ButtonEdit
    ' Inherits C1.Win.C1Input.C1TextBox
    Private p_ViewName As String = ""



    Private p_TableName As String = ""
    Private p_FieldName As String = ""
    Private p_Required As String = ""
    Private p_UpdateIfNull As String = ""
    Private p_PrimaryKey As String = ""
    Private p_NoUpdate As String = "N"
    Private p_FieldType As String = ""

    Private p_KeyInsert As String = ""
    Private p_SqlString As String = ""
    Private p_SqlFielKey As String = ""
    Private p_ItemReturn1 As String = ""
    Private p_ItemReturn2 As String = ""
    Private p_ItemReturn3 As String = ""

    Private p_ShowLoad As Boolean = False

    Private p_UpdateWhenFormLock As Boolean = False  'True: Neu FormEdit=false thi van cho cap nhat gia tri

    Private p_DefaultButtonClick As Boolean = False
    Private p_ValueType As Integer = 0  '1: Gia tri duoc chon tu form Search, 2: Gia tri khi KeyPress, 

    Private p_MultiSelect As Boolean = False

    Private p_BindingSourceName As String = ""

    Private p_AllowUpdate As Boolean = True
    Private p_AllowInsert As Boolean = True

    Private p_LinkLabel As String = ""

    Private p_DefaultValue As String = ""

    Private p_UpperValue As Boolean = False

    Private p_FormList As Boolean = False

    Private p_ValidateValue As Boolean = True

    Private p_AutoWidth As Boolean = False

    'Private p_ShowCalculator As Boolean = True


    'Public Property ShowCalculator() As Boolean
    '    Get
    '        Return p_ShowCalculator
    '    End Get
    '    Set(ByVal value As Boolean)
    '        p_ShowCalculator = value
    '    End Set
    'End Property

    Private p_OrderbyExt As String = ""

    Public Property OrderbyEx() As String
        Get
            Return p_OrderbyExt
        End Get
        Set(ByVal value As String)
            p_OrderbyExt = value
        End Set
    End Property


    Public Property AutoWidth() As Boolean
        Get
            Return p_AutoWidth
        End Get
        Set(ByVal value As Boolean)
            p_AutoWidth = value
        End Set
    End Property


    Public Property ValidateValue() As Boolean
        Get
            Return p_ValidateValue
        End Get
        Set(ByVal value As Boolean)
            p_ValidateValue = value
        End Set
    End Property

    Public Property FormList() As Boolean
        Get
            Return p_FormList
        End Get
        Set(ByVal value As Boolean)
            p_FormList = value
        End Set
    End Property

    Public Property UpperValue() As Boolean
        Get
            Return p_UpperValue
        End Get
        Set(ByVal value As Boolean)
            p_UpperValue = value
        End Set
    End Property

    Public Property DefaultValue As String
        Get
            Return p_DefaultValue
        End Get
        Set(ByVal value As String)
            p_DefaultValue = value
        End Set
    End Property


    Public Property LinkLabel() As String
        Get
            Return p_LinkLabel
        End Get
        Set(ByVal value As String)
            p_LinkLabel = value
        End Set

    End Property

    Public Property AllowUpdate() As Boolean
        Get
            Return p_AllowUpdate
        End Get
        Set(ByVal value As Boolean)
            p_AllowUpdate = value
        End Set
    End Property

    Public Property AllowInsert() As Boolean
        Get
            Return p_AllowInsert
        End Get
        Set(ByVal value As Boolean)
            p_AllowInsert = value
        End Set
    End Property



    Public Property BindingSourceName() As String
        Get
            Return p_BindingSourceName
        End Get
        Set(ByVal value As String)
            p_BindingSourceName = value
        End Set

    End Property

    Public Property MultiSelect() As Boolean
        Get
            Return p_MultiSelect
        End Get
        Set(ByVal value As Boolean)
            p_MultiSelect = value
        End Set

    End Property


    Public Property DefaultButtonClick() As Boolean
        Get
            Return p_DefaultButtonClick
        End Get
        Set(ByVal value As Boolean)
            p_DefaultButtonClick = value
        End Set

    End Property



    Private p_CopyFromItem As String = ""
    Public Property CopyFromItem() As String
        Get
            Return p_CopyFromItem
        End Get
        Set(ByVal value As String)
            p_CopyFromItem = value
        End Set

    End Property

    Public Property UpdateWhenFormLock() As Boolean
        Get
            Return p_UpdateWhenFormLock
        End Get
        Set(ByVal value As Boolean)
            p_UpdateWhenFormLock = value
        End Set

    End Property

    Private p_ChangeFormStatus As Boolean = True

    Public Property ChangeFormStatus() As Boolean
        Get
            Return p_ChangeFormStatus
        End Get
        Set(ByVal value As Boolean)
            p_ChangeFormStatus = value
        End Set

    End Property


    Public Property SqlFielKey() As String
        Get
            Return p_SqlFielKey
        End Get
        Set(ByVal value As String)
            p_SqlFielKey = value
        End Set
    End Property



    Public Property ItemReturn1() As String
        Get
            Return p_ItemReturn1
        End Get
        Set(ByVal value As String)
            p_ItemReturn1 = value
        End Set
    End Property

    Public Property ItemReturn2() As String
        Get
            Return p_ItemReturn2
        End Get
        Set(ByVal value As String)
            p_ItemReturn2 = value
        End Set
    End Property

    Public Property ItemReturn3() As String
        Get
            Return p_ItemReturn3
        End Get
        Set(ByVal value As String)
            p_ItemReturn3 = value
        End Set
    End Property

    Public Property ShowLoad() As Boolean
        Get
            Return p_ShowLoad
        End Get
        Set(ByVal value As Boolean)
            p_ShowLoad = value
        End Set
    End Property



    Public Property SqlString() As String
        Get
            Return p_SqlString
        End Get
        Set(ByVal value As String)
            p_SqlString = value
        End Set
    End Property



    Public Property KeyInsert() As String
        Get
            Return p_KeyInsert
        End Get
        Set(ByVal value As String)
            p_KeyInsert = value
        End Set

    End Property

    Public Property FieldType() As String
        Get
            Return p_FieldType
        End Get
        Set(ByVal value As String)
            p_FieldType = value
        End Set

    End Property

    Public Property NoUpdate() As String
        Get
            Return p_NoUpdate
        End Get
        Set(ByVal value As String)
            p_NoUpdate = value
        End Set

    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.

        MyBase.New()

        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Property ViewName() As String
        Get
            Return p_ViewName
        End Get
        Set(ByVal value As String)
            p_ViewName = value
        End Set

    End Property
    Public Property TableName() As String
        Get
            Return p_TableName
        End Get
        Set(ByVal value As String)
            p_TableName = value
        End Set

    End Property

    Public Property Required() As String
        Get
            Return p_Required
        End Get
        Set(ByVal value As String)
            p_Required = value
        End Set

    End Property


    Public Property UpdateIfNull() As String
        Get
            Return p_UpdateIfNull
        End Get
        Set(ByVal value As String)
            p_UpdateIfNull = value
        End Set

    End Property

    Public Property FieldName() As String
        Get
            Return p_FieldName
        End Get
        Set(ByVal value As String)
            p_FieldName = value
        End Set

    End Property

    Public Property PrimaryKey() As String
        Get
            Return p_PrimaryKey
        End Get
        Set(ByVal value As String)
            p_PrimaryKey = value
        End Set

    End Property


    'Public Event p_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles EditValueChanged

    'Private Sub p_MouseMove(ByVal sender As Object, _
    '     ByVal e As System.Object) Handles MyClass.MouseMove
    '    'MsgBox("asdas")
    '    'S.p_Commit = True
    '    '  System.Boolean = True
    '    ' e.ToolTip = "dfgdg"
    '    Dim p_Table_Name As String = ""
    '    Dim p_Field_Name As String = ""
    '    Dim p_View_Name As String = ""
    '    p_Table_Name = Me.TableName
    '    p_Field_Name = Me.FieldName
    '    p_View_Name = Me.ViewName



    '    Me.ToolTip = "NAME(" & Me.Name & ") VIEW(" & p_View_Name & ") TAB(" & p_Table_Name & ") FIELD (" & p_Field_Name & ")"

    'End Sub
    Private Sub p_MouseMove(ByVal sender As Object, _
         ByVal e As System.Object) Handles MyClass.MouseMove
        'MsgBox("asdas")
        'S.p_Commit = True
        '  System.Boolean = True
        ' e.ToolTip = "dfgdg"
        Dim p_Table_Name As String = ""
        Dim p_Field_Name As String = ""
        Dim p_View_Name As String = ""
        Dim p_Form As Object 'System.Windows.Forms.Form
        Dim p_Obj() As Object
        p_Table_Name = Me.TableName
        p_Field_Name = Me.FieldName
        p_View_Name = Me.ViewName
        p_Form = FindForm()
        Try
            'p_Obj = p_Form.Controls.Find("cusStatusStrip1", True)
            'If p_Obj.Length > 0 Then
            '    If p_Obj(0).visible = True And p_Form.showInfor.ToString = "Y" Then
            '       p_Form.ShowStatusMessage(False, "", "ItmName:" & Me.Name & " - " & p_View_Name & ".FIELD (" & p_Field_Name & ")", 7)
            '        'p_Obj(0).Text = Me.Name & " - Field:" & p_Field_Name
            '    End If
            'End If

            If p_Form.showInfor.ToString = "Y" Then
                If UCase(Me.Name) = UCase(p_Field_Name) Then
                    Me.ToolTip = p_View_Name & "." & p_Field_Name & ""
                Else
                    Me.ToolTip = p_View_Name & "." & Me.Name & "." & p_Field_Name & ""
                End If

                'p_Obj(0).Text = Me.Name & " - Field:" & p_Field_Name
            End If

        Catch ex As Exception

        End Try

    End Sub

    ' Private Sub p_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyClass.Validated
    Private Sub U_ButtonEdit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating

        Dim p_Form As Object
        Dim p_ButtonEdit As U_ButtonEdit
        Dim p_OldValue As String = ""
        Dim p_NewValue As String = ""
        Dim p_DataTable As DataTable
        Dim p_SQL As String = ""
        Dim p_Field As String = ""
        Dim p_Exist As Boolean = False
        Dim p_ButtonArr() As Object
        Dim p_ButtonOK As Object = Nothing
        Dim p_ItemBtn As String = ""


        'Dim p_Form As Object
        If Me.MultiSelect = True Then Exit Sub
       
        Try
            If p_ValueType = 2 Or p_ValueType = 0 Then
                If Not sender.OldEditValue Is Nothing Then
                    p_OldValue = sender.OldEditValue.ToString.Trim
                End If
                If Not sender.EditValue Is Nothing Then
                    p_NewValue = sender.EditValue.ToString.Trim
                    If Me.UpperValue = True Then
                        p_NewValue = UCase(p_NewValue)
                        sender.EditValue = p_NewValue
                    End If
                End If
                ' p_ButtonEdit = CType(sender, U_ButtonEdit)

                If p_NewValue = "" Then
                    p_Form = FindForm()
                    p_ItemBtn = ""
                    If Not sender.ItemReturn1 Is Nothing Then
                        p_ItemBtn = sender.ItemReturn1.ToString.Trim
                    End If
                    If p_ItemBtn <> "" Then
                        p_ButtonArr = p_Form.Controls.Find(p_ItemBtn, True)
                        If p_ButtonArr.Length > 0 Then
                            p_ButtonArr(0).editvalue = Nothing
                        End If
                    End If
                    'Gan ItemReturn2
                    p_ItemBtn = ""
                    If Not sender.ItemReturn2 Is Nothing Then
                        p_ItemBtn = sender.ItemReturn2.ToString.Trim
                    End If
                    If p_ItemBtn <> "" Then
                        p_ButtonArr = p_Form.Controls.Find(p_ItemBtn, True)
                        If p_ButtonArr.Length > 0 Then
                            p_ButtonArr(0).editvalue = Nothing
                        End If
                    End If
                    'Gan ItemReturn3
                    p_ItemBtn = ""
                    If Not sender.ItemReturn3 Is Nothing Then
                        p_ItemBtn = sender.ItemReturn3.ToString.Trim
                    End If
                    If p_ItemBtn <> "" Then
                        p_ButtonArr = p_Form.Controls.Find(p_ItemBtn, True)
                        If p_ButtonArr.Length > 0 Then
                            p_ButtonArr(0).editvalue = Nothing
                        End If
                    End If
                    p_ValueType = 0
                    Exit Sub
                End If
                If p_OldValue = p_NewValue Then Exit Sub
                p_Form = FindForm()
                If p_Form.FormLock = True Or p_Form.g_FormLoad = True Then Exit Sub

                If p_Form.FormEdit = False Then
                    If Me.p_UpdateWhenFormLock = False Then
                        Exit Sub
                    End If
                End If
                ' p_ButtonEdit = CType(sender, DevExpress.XtraEditors.ButtonEdit)
                p_Field = sender.SqlFielKey.ToString.Trim
                p_SQL = sender.SqlString
                p_SQL = p_Form.p_XtraModuleObj.Parameter_Item(p_Form, p_SQL)

                'If UCase( Then

                'End If

                If sender.FieldType = "C" Then
                    p_SQL = "SELECT  * FROM  (" & p_SQL & ") ABC Where ABC." & p_Field & "=N'" & p_NewValue & "'"
                ElseIf sender.FieldType = "N" Then
                    p_SQL = "SELECT  * FROM  (" & p_SQL & ") ABC Where ABC." & p_Field & "=" & p_NewValue & ""
                Else
                    Exit Sub
                End If


                p_DataTable = p_Form.g_XtraServicesObj.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                'If p_SQL <> "" Then
                '    Exit Sub
                'End If
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        p_Exist = True
                    End If
                End If
                If p_Exist = False And Me.ValidateValue = True Then

                    'Me.ErrorText = "Giá tri không hợp lệ"
                    '  MsgBox("Giá tri không hợp lệ")
                    p_Form.ShowMessageBox("", "Giá trị không hợp lệ")

                    If Not Me.OldEditValue Is Nothing Then
                        Me.EditValue = Me.OldEditValue
                    Else
                        Me.EditValue = Nothing
                    End If
                    e.Cancel = True
                    'Me.CancelUpdate()

                    Exit Sub


                    Try
                        p_ItemBtn = p_Form.ButtonSave
                    Catch ex As Exception

                    End Try
                    If p_ItemBtn.ToString.Trim <> "" Then
                        p_ButtonArr = p_Form.Controls.Find(p_ItemBtn, True)
                        If p_ButtonArr.Length > 0 Then
                            p_ButtonOK = p_ButtonArr(0)
                        End If
                    End If

                    'Call p_Form.Edit_Button_Click(Me, p_Form, p_Form.FormStatus, p_ButtonOK, p_Form.CaptionUpd)
                    Try

                        Call p_Form.Edit_Button_Click(Me, p_Form, p_Form.FormStatus, p_ButtonOK, p_Form.CaptionUpd)
                        If p_Form.g_ChooseRecordFromSearch = False Then
                            e.Cancel = True
                            Exit Sub
                        End If
                        '  p_KeyPress = False
                    Catch ex As Exception

                    End Try

                    'p_KeyPress = False
                Else
                    If Me.ValidateValue = True Then

                        ' End If
                        'Gan ItemReturn1
                        p_ItemBtn = ""
                        If Not sender.ItemReturn1 Is Nothing Then
                            p_ItemBtn = sender.ItemReturn1.ToString.Trim
                        End If
                        If p_ItemBtn <> "" Then
                            p_ButtonArr = p_Form.Controls.Find(p_ItemBtn, True)
                            If p_ButtonArr.Length > 0 Then
                                p_ButtonArr(0).editvalue = p_DataTable.Rows(0).Item(1).ToString.Trim
                            End If
                        End If
                        'Gan ItemReturn2
                        p_ItemBtn = ""
                        If Not sender.ItemReturn2 Is Nothing Then
                            p_ItemBtn = sender.ItemReturn2.ToString.Trim
                        End If
                        If p_ItemBtn <> "" Then
                            p_ButtonArr = p_Form.Controls.Find(p_ItemBtn, True)
                            If p_ButtonArr.Length > 0 Then
                                p_ButtonArr(0).editvalue = p_DataTable.Rows(0).Item(2).ToString.Trim
                            End If
                        End If
                        'Gan ItemReturn3
                        p_ItemBtn = ""
                        If Not sender.ItemReturn3 Is Nothing Then
                            p_ItemBtn = sender.ItemReturn3.ToString.Trim
                        End If
                        If p_ItemBtn <> "" Then
                            p_ButtonArr = p_Form.Controls.Find(p_ItemBtn, True)
                            If p_ButtonArr.Length > 0 Then
                                p_ButtonArr(0).editvalue = p_DataTable.Rows(0).Item(3).ToString.Trim
                            End If
                        End If
                    End If
                End If
                p_ValueType = 0
            Else
                p_ValueType = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Private Sub SubValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles MyClass.EditValueChanging
        Dim p_Form As Object

        Try
            p_Form = FindForm()

            'If  p_KeyPress = False then exit
            If p_Form.g_FormLoad = True Then Exit Sub
            If p_Form.FormEdit = False Then
                If Me.p_UpdateWhenFormLock = False Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            '  If p_Form.FormStatus = True Then Exit Sub

            If ChangeFormStatus = False Then Exit Sub
            'p_Form =
            If Not e.OldValue Is Nothing Then
                If e.OldValue.ToString.Trim <> e.NewValue.ToString.Trim Then
                    SubValidated(p_Form, Me)
                End If
            Else
                SubValidated(p_Form, Me)
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub



    Private Sub Edit_Button_Click()
        Dim p_Form As Object
        Dim p_ButtonArr() As Object
        Dim p_ButtonOK As Object = Nothing
        Dim p_ItemBtn As String = ""
        Dim p_Item As U_ButtonEdit
        Dim p_OldValue As String = ""
        Dim p_NewValue As String = ""

        ' p_Item = CType(sender, U_ButtonEdit)
        If Me.DefaultButtonClick = False Then Exit Sub
        p_Form = FindForm()
        Try
            p_ItemBtn = p_Form.ButtonSave
        Catch ex As Exception

        End Try
        If p_ItemBtn.ToString.Trim <> "" Then
            p_ButtonArr = p_Form.Controls.Find(p_ItemBtn, True)
            If p_ButtonArr.Length > 0 Then
                p_ButtonOK = p_ButtonArr(0)
            End If
        End If

        If p_Form.g_FormLoad = True Then Exit Sub
        If p_Form.FormEdit = False Then
            If Me.p_UpdateWhenFormLock = False Then
                Exit Sub
            End If
        End If
        'If p_Form.FormStatus = True Then Exit Sub

        'If ChangeFormStatus = False Then Exit Sub


        If p_Form.FormLock = True Then Exit Sub
        If p_Form.FormEdit = False Then
            If Me.UpdateWhenFormLock = False Then
                'e.Cancel = True
                Exit Sub
            End If
        End If
        Try
            If Not Me.OldEditValue Is Nothing Then
                p_OldValue = Me.OldEditValue.ToString.Trim
            End If
            Call p_Form.Edit_Button_Click(Me, p_Form, p_Form.FormStatus, Nothing, p_Form.CaptionUpd, Me.FormList)
            If Not Me.EditValue Is Nothing Then
                p_NewValue = Me.EditValue.ToString.Trim
            End If
            If p_NewValue <> p_OldValue Then
                p_ValueType = 1
            End If
            '  p_KeyPress = False
        Catch ex As Exception

        End Try

        'Me.FormStatus = True
        'p_FptModule = Nothing
    End Sub

    Sub p_Edit_Button_Click(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles MyBase.ButtonClick
        If Me.Properties.ReadOnly = True Then
            Exit Sub
        End If
        Edit_Button_Click()
    
    End Sub

    Private Sub SubValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        p_ValueType = 2
        If Asc(e.KeyChar) = 12 Then
            Edit_Button_Click()
        End If
    End Sub

    ' Private Sub U_ButtonEdit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating

    'End Sub
End Class
