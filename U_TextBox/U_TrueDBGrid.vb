Public Class U_TrueDBGrid
    Private p_ViewName As String = ""
    Private p_TableName As String = ""
    Private p_Parent_Item As String = ""
    Private p_ColumnKey As String = ""
    Private p_ColumnKeyIns As String = "Y"
    Private p_OrderBy As String = ""
    Private p_Where As String = ""
    Private p_ColumnKeyType As String = ""
    Private p_RowID As Integer
    Private p_ColName As String
    Private p_SQL As String
    Private p_AllowInsert As String = "Y"
    Private p_ColumnAutoWidth As String = "Y"

    Private p_ColumnEnableUpdate As String = "A"
    Private p_ColumnVisibleUpdate As String = "A"

    Private p_ObjectChild As Boolean = False

    Private p_LastQuery As String

    Private p_LoadFromStored As Boolean = False

    Private p_DefaultRemove As Boolean = True

    Public Property DefaultRemove() As Boolean
        Get
            Return p_DefaultRemove
        End Get
        Set(ByVal value As Boolean)
            p_DefaultRemove = value
        End Set


    End Property

    Public Property LoadFromStored() As Boolean
        Get
            Return p_LoadFromStored
        End Get
        Set(ByVal value As Boolean)
            p_LoadFromStored = value
        End Set


    End Property
    Public Property LastQuery() As String
        Get
            Return p_LastQuery
        End Get
        Set(ByVal value As String)
            p_LastQuery = value
        End Set
    End Property

    Public Property ObjectChild() As Boolean
        Get
            Return p_ObjectChild
        End Get
        Set(ByVal value As Boolean)
            p_ObjectChild = value
        End Set
    End Property


    Public Property ColumnEnableUpdate() As String
        Get
            Return p_ColumnEnableUpdate
        End Get
        Set(ByVal value As String)
            p_ColumnEnableUpdate = value
        End Set
    End Property

    Public Property ColumnVisibleUpdate() As String
        Get
            Return p_ColumnVisibleUpdate
        End Get
        Set(ByVal value As String)
            p_ColumnVisibleUpdate = value
        End Set
    End Property


    Public Property ColumnAutoWidth() As String
        Get
            Return p_ColumnAutoWidth
        End Get
        Set(ByVal value As String)
            p_ColumnAutoWidth = value
        End Set
    End Property


    Public Property AllowInsert() As String
        Get
            Return p_AllowInsert
        End Get
        Set(ByVal value As String)
            p_AllowInsert = value
        End Set
    End Property

    Public Property ColumnKeyType() As String
        Get
            Return p_ColumnKeyType
        End Get
        Set(ByVal value As String)
            p_ColumnKeyType = value
        End Set
    End Property

    Public Property OrderBy() As String
        Get
            Return p_OrderBy
        End Get
        Set(ByVal value As String)
            p_OrderBy = value
        End Set
    End Property

    Public Property Where() As String
        Get
            Return p_Where
        End Get
        Set(ByVal value As String)
            p_Where = value
        End Set
    End Property


    Public Property ColumnKey() As String
        Get
            Return p_ColumnKey
        End Get
        Set(ByVal value As String)
            p_ColumnKey = value
        End Set
    End Property

    Public Property ColumnKeyIns() As String
        Get
            Return p_ColumnKeyIns
        End Get
        Set(ByVal value As String)
            p_ColumnKeyIns = value
        End Set
    End Property


    Public Property ParentItem() As String
        Get
            Return p_Parent_Item
        End Get
        Set(ByVal value As String)
            p_Parent_Item = value
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
    Public Property TableName() As String
        Get
            Return p_TableName
        End Get
        Set(ByVal value As String)
            p_TableName = value
        End Set
    End Property

    'Private Sub p_MouseMove(ByVal sender As Object, _
    '     ByVal e As System.Object) Handles MyClass.MouseMove
    '    'MsgBox("asdas")
    '    'S.p_Commit = True
    '    '  System.Boolean = True
    '    ' e.ToolTip = "dfgdg"
    '    Dim p_Table_Name As String = ""
    '    Dim p_Field_Name As String = ""
    '    Dim p_View_Name As String = ""
    '    Dim p_Form As Object 'System.Windows.Forms.Form
    '    p_Table_Name = Me.TableName
    '    'p_Field_Name = Me.FieldName
    '    p_View_Name = Me.ViewName
    '    p_Form = FindForm()

    '    Try
    '        If Not p_Form.p_XtraToolTripLabel Is Nothing Then
    '            ' Me.ToolTip = "NAME(" & Me.Name & ") VIEW(" & p_View_Name & ") TAB(" & p_Table_Name & ") FIELD (" & p_Field_Name & ")"
    '            ' Try
    '            p_Form.p_XtraToolTripLabel.Text = " Name(" & Me.Name & ") View(" & p_View_Name & ") Table(" & p_Table_Name & ")"
    '            '        Catch ex As Exception

    '            'End Try

    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub


   
    'Private Sub p_GridView1MouseMove(ByVal sender As Object, _
    '     ByVal e As System.Object) Handles GridView1.
    '    'MsgBox("asdas")
    '    'S.p_Commit = True
    '    '  System.Boolean = True
    '    ' e.ToolTip = "dfgdg"
    '    Dim p_Table_Name As String = ""
    '    Dim p_Field_Name As String = ""
    '    Dim p_View_Name As String = ""
    '    Dim p_Form As Object 'System.Windows.Forms.Form
    '    Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
    '    p_Table_Name = Me.TableName
    '    'p_Field_Name = Me.FieldName
    '    p_View_Name = Me.ViewName
    '    p_Form = FindForm()
    '    p_GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
    '    Try
    '        If Not p_Form.p_XtraToolTripLabel Is Nothing Then
    '            ' Me.ToolTip = "NAME(" & Me.Name & ") VIEW(" & p_View_Name & ") TAB(" & p_Table_Name & ") FIELD (" & p_Field_Name & ")"
    '            ' Try
    '            p_Form.p_XtraToolTripLabel.Text = " Name(" & Me.Name & ") View(" & p_View_Name & ") Table(" & p_Table_Name & ")"
    '            '        Catch ex As Exception

    '            'End Try

    '        End If
    '    Catch ex As Exception

    '    End Try

    'End Sub


    Public Sub New()

        '' This call is required by the designer.
        'Dim p_Count As Integer
        'Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
        'For p_Count = 0 To Me.Views.Count - 1
        '    p_GridView = Me.Views(p_Count)
        '    AddHandler p_GridView.CellValueChanged, AddressOf GridView1_CellValueChanged
        'Next

        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'Private Sub U_TrueDBGrid1_EmbeddedNavigator_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles U_TrueDBGrid.e

    'End Sub
    'Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

    'End Sub

    Public Sub GridNavigatorButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        ModGridNavigatorButtonClick(sender, e)
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
