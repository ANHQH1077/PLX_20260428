Public Class U_SearchLookEdit
    Private p_ViewName As String = ""
    Private p_TableName As String = ""
    Private p_FieldName As String = ""
    Private p_Required As String = ""
    Private p_UpdateIfNull As String = ""
    Private p_ItemValue As String = ""

    Private p_NoUpdate As String = ""
    Private p_FieldType As String = ""
    Public Shared p_Chang_Value As Boolean

    Private p_PrimaryKey As String = ""

    Private p_KeyInsert As String = ""

    Private p_SQLString As String = ""
    Private p_DisplayField As String = ""
    Private p_ValueField As String = ""

    Private p_AllowUpdate As Boolean = True
    Private p_AllowInsert As Boolean = True

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


    Private p_CopyFromItem As String = ""
    Private p_BindingSourceName As String = ""
    Public Property BindingSourceName() As String
        Get
            Return p_BindingSourceName
        End Get
        Set(ByVal value As String)
            p_BindingSourceName = value
        End Set

    End Property

    Public Property CopyFromItem() As String
        Get
            Return p_CopyFromItem
        End Get
        Set(ByVal value As String)
            p_CopyFromItem = value
        End Set

    End Property
    Private p_UpdateWhenFormLock As Boolean = False  'True: Neu FormEdit=false thi van cho cap nhat gia tri

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

    Public Property DisplayField() As String
        Get
            Return p_DisplayField
        End Get
        Set(ByVal value As String)
            p_DisplayField = value
        End Set

    End Property
    Public Property ValueField() As String
        Get
            Return p_ValueField
        End Get
        Set(ByVal value As String)
            p_ValueField = value
        End Set

    End Property


    Public Property SQL_String() As String
        Get
            Return p_SQLString
        End Get
        Set(ByVal value As String)
            p_SQLString = value
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



    Public Property PrimaryKey() As String
        Get
            Return p_PrimaryKey
        End Get
        Set(ByVal value As String)
            p_PrimaryKey = value
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

    Public Property ItemValue() As String
        Get
            Return p_ItemValue
        End Get
        Set(ByVal value As String)
            p_ItemValue = value
        End Set

    End Property

    'Public Event p_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles EditValueChanged 

    'Public Event p_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles EditValueChanged

    Private Sub p_EditValueChanged1(ByVal sender As Object, _
         ByVal e As System.Object) Handles MyClass.ButtonClick

    End Sub


    'Private Sub p_MouseMove(ByVal sender As Object, _
    '    ByVal e As System.Object) Handles MyClass.MouseMove
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
        p_Table_Name = Me.TableName
        p_Field_Name = Me.FieldName
        p_View_Name = Me.ViewName
        p_Form = FindForm()
        Dim p_Obj() As Object
        Try
            If p_Form.showInfor.ToString = "Y" Then
                If UCase(Me.Name) = UCase(p_Field_Name) Then
                    Me.ToolTip = p_View_Name & "." & p_Field_Name & ""
                Else
                    Me.ToolTip = p_View_Name & "." & Me.Name & "." & p_Field_Name & ""
                End If

                'p_Obj(0).Text = Me.Name & " - Field:" & p_Field_Name
            End If
            'If Not p_Form.p_XtraToolTripLabel Is Nothing Then
            '    ' Me.ToolTip = "NAME(" & Me.Name & ") VIEW(" & p_View_Name & ") TAB(" & p_Table_Name & ") FIELD (" & p_Field_Name & ")"
            '    'Try
            '    p_Form.p_XtraToolTripLabel.Text = " Name(" & Me.Name & ") View(" & p_View_Name & ") Table(" & p_Table_Name & ") Field(" & p_Field_Name & ")"
            '    '        Catch ex As Exception

            '    'End Try

            'End If
        Catch ex As Exception

        End Try
    End Sub
    'Private Sub p_Validated(ByVal sender As Object, _
    '             ByVal e As System.Object) Handles MyClass.Validated



    '    'Dim p_Form As Object

    '    If ChangeFormStatus = False Then Exit Sub
    '    'p_Form =
    '    SubValidated(FindForm())

    'End Sub
    Private Sub SubValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles MyClass.EditValueChanging
        Dim p_Form As Object
        Try
            p_Form = FindForm()
            If p_Form.g_FormLoad = True Then Exit Sub
            If p_Form.FormEdit = False Then
                If Me.p_UpdateWhenFormLock = False Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
            ' If p_Form.FormStatus = True Then Exit Sub

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
End Class
