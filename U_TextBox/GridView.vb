Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils
Imports System.Xml
Imports System.Windows.Forms
Public Class GridView
    Private p_ViewName As String = ""
    Private p_TableName As String = ""
    Private p_OrderBy As String = ""
    Private p_Where As String
    Private p_ColumnAutoWidth As Boolean = False
    Private p_ObjectChild As Boolean = False
    Private p_LastQuery As String = ""

    Private p_Parent_Item As String

    Private p_GetB1 As Boolean = False

    Private p_RowNumber As String = ""

    Private p_CompanyCode As String = ""
    Private p_AllowInsert As Boolean = False

    Private p_ColumnKey As String = ""

    Private p_ColumnKeyIns As Boolean = True
    Private p_ColumnKeyType As String = "N"

    Private p_DefaultRemove As Boolean = True


    'Protected Overloads Sub OnColumnAdded(ByVal column As GridColumn) 'Handles Me.
    '    Dim p_Column As New GridColumn
    '    p_Column.Name = column.Name & Me.Columns.Count + 1
    '    MyBase.OnColumnAdded(p_Column)
    '    'MyBase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {column})

    'End Sub

    'Protected Overloads Sub AddRange(ByVal column As GridColumn)
    '    MyBase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {column})
    'End Sub
    ''Protected Overloads Sub add
    '' Protected Overloads Sub oncolumn

    'Protected Overloads Sub OnColumnDeleted(ByVal column As GridColumn)
    '    MyBase.OnColumnDeleted(column)
    'End Sub



    Public Property ColumnKeyType() As String
        Get
            Return p_ColumnKeyType
        End Get
        Set(ByVal value As String)
            p_ColumnKeyType = value
        End Set
    End Property


    Public Property DefaultRemove() As Boolean
        Get
            Return p_DefaultRemove
        End Get
        Set(ByVal value As Boolean)
            p_DefaultRemove = value
        End Set
    End Property

    Private p_CheckUpd As Boolean = True
    Public Property CheckUpd() As Boolean
        Get
            Return p_CheckUpd
        End Get
        Set(ByVal value As Boolean)
            p_CheckUpd = value
        End Set
    End Property


    Public Property ColumnKeyIns() As Boolean
        Get
            Return p_ColumnKeyIns
        End Get
        Set(ByVal value As Boolean)
            p_ColumnKeyIns = value
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


    Public Property AllowInsert() As Boolean
        Get
            Return p_AllowInsert
        End Get
        Set(ByVal value As Boolean)
            p_AllowInsert = value
        End Set
    End Property


    Public Property CompanyCode() As String
        Get
            Return p_CompanyCode
        End Get
        Set(ByVal value As String)
            p_CompanyCode = value
        End Set
    End Property



    Public Property RowNumber() As String
        Get
            Return p_RowNumber
        End Get
        Set(ByVal value As String)
            p_RowNumber = value
        End Set
    End Property


    Public Property GetB1() As Boolean
        Get
            Return p_GetB1
        End Get
        Set(ByVal value As Boolean)
            p_GetB1 = value
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



    Public Property ColumnAutoWidth() As Boolean
        Get
            Return p_ColumnAutoWidth
        End Get
        Set(ByVal value As Boolean)
            p_ColumnAutoWidth = value
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


    Public Sub New()
        ' p_Column as Integer         
        ' This call is required by the designer.
        ' DGVHasTransparentBackground = True
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub GridView1_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles Me.PopupMenuShowing
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then
            Dim p_Column As GridColumn
            ' Dim p_GridView As U_TextBox.GridView
            Dim p_Item As DevExpress.Utils.Menu.DXMenuItem
            Dim p_TrueGrid As TrueDBGrid

            Dim p_Form As Object
            p_TrueGrid = Me.GridControl
            p_Form = p_TrueGrid.FindForm()



            p_Item = New DevExpress.Utils.Menu.DXMenuItem
            p_Item.Caption = "Lưu cấu trúc hiển thị"
            p_Item.Tag = p_Form.name & "." & p_TrueGrid.Name & "." & Me.Name

            AddHandler p_Item.Click, AddressOf SaveStructure_Cllick
            e.Menu.Items.Add(p_Item)

            p_Item = New DevExpress.Utils.Menu.DXMenuItem
            p_Item.Caption = "Khôi phục cấu trúc hiển thị"
            p_Item.Tag = p_Form.name & "." & p_TrueGrid.Name & "." & Me.Name

            AddHandler p_Item.Click, AddressOf ReloadStructure_Cllick
            e.Menu.Items.Add(p_Item)


            If p_Form.ShowInfor <> "Y" Then
                Exit Sub
            End If


            p_Item = New DevExpress.Utils.Menu.DXMenuItem
            p_Item.Caption = "View info"
            p_Item.Tag = p_TrueGrid.Name & "." & Me.Name
            AddHandler p_Item.Click, AddressOf ViewInfo_Cllick
            e.Menu.Items.Add(p_Item)



            'p_Item = New DevExpress.Utils.Menu.DXMenuItem
            'p_Item.Caption = "Column info"
            'p_Item.Tag = "ColumnName: " & p_Column.Name & " - FielName: " & p_Column.FieldView
            'p_Column.ToolTip = p_Item.Tag


            'AddHandler p_Item.Click, AddressOf ViewInfo_Cllick    'ColumnInfo_Cllick
            'e.Menu.Items.Add(p_Item)
        End If
    End Sub

    Private Sub SaveStructure_Cllick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim p_String As String = ""
        Dim p_Tag As String = ""
        Dim p_DataSet As New DataSet
        Dim p_TrueGrid As TrueDBGrid
        Dim p_PathFile As String = Application.StartupPath '& "\tesst2.xml"
        Dim p_User As String = ""
        Dim p_Form As Object
        Dim p_Item As DevExpress.Utils.Menu.DXMenuItem
        Dim p_FileName As String = ""
        Dim p_ItemStruct() As String
        On Error Resume Next

        p_TrueGrid = Me.GridControl
        p_Form = p_TrueGrid.FindForm()

        p_User = p_Form.p_XtraUserName.ToString

        p_Item = CType(sender, DevExpress.Utils.Menu.DXMenuItem)
        p_Tag = p_Item.Tag
        p_ItemStruct = p_Tag.Split(".")
        p_Tag = p_User & "." & p_Tag
        p_FileName = p_PathFile & "\" & p_User & "_StructView.xml"
        p_String = ""
        '  Me.GridView1.SaveLayoutToXml(Application.StartupPath & "\tesst2.xml")
        Me.SaveLayoutToXml(p_FileName)
        Dim xmldoc As New XmlDocument()
        xmldoc.Load(p_FileName)
        p_String = xmldoc.InnerXml.ToString
        Dim p_SQL As String = ""
        p_SQL = "delete from tblStructureView where  UserName ='" & p_User & "'; "
        p_SQL = p_SQL & "INSERT INTO [dbo].[tblStructureView] ([UserName],[FormName],[TrueGridName],[GridViewName],[CreateUser],[UpdateDate],GridXml)"
        p_SQL = p_SQL & " VALUES ('" & p_User & "','" & p_ItemStruct(0).ToString & "','" & p_ItemStruct(1).ToString & "','" & p_ItemStruct(2).ToString.Trim & _
                            "','" & p_User & "',getdate() ,'" & p_String & "' ) "
        p_Form.Run_Script(p_SQL)
        If Dir(p_FileName) <> "" Then
            IO.File.Delete(p_FileName)
        End If
    End Sub

    Private Sub ReloadStructure_Cllick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim p_SQL As String = ""
        Dim p_TrueGrid As TrueDBGrid
        Dim p_Form As Object
        Dim p_User As String = ""
        On Error Resume Next

        p_User = p_Form.p_XtraUserName.ToString
        p_TrueGrid = Me.GridControl
        p_Form = p_TrueGrid.FindForm()

        p_SQL = "delete from tblStructureView where  UserName ='" & p_User & "'; "

        p_Form.Run_Script(p_SQL)
    End Sub

    Private Sub ViewInfo_Cllick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim p_Item As DevExpress.Utils.Menu.DXMenuItem
        Dim p_Tag As String = ""
        'Dim p_GridView As GridView
        Dim p_Object() As Object
        Dim p_TrueGrid As TrueDBGrid
        Dim p_Name As String = ""
        Dim p_Column As GridColumn
        Dim p_Column22 As DevExpress.XtraGrid.Columns.GridColumn
        Dim p_Int As Integer
        ' If Me.ShowFormMessage = True Then

        Dim p_Form As Object
        p_TrueGrid = Me.GridControl
        p_Form = p_TrueGrid.FindForm()


        p_Item = CType(sender, DevExpress.Utils.Menu.DXMenuItem)
        p_Tag = p_Item.Tag
        p_Int = InStr(p_Tag, ".", CompareMethod.Text)
        If p_Int > 0 Then
            p_Name = Strings.Left(p_Tag, p_Int - 1)
            p_Object = p_Form.Controls.Find(p_Name, True)
            If p_Object.Length > 0 Then
                ' p_TrueGrid = CType(p_Object(0), U_TextBox.TrueDBGrid)
                ' p_GridView = p_TrueGrid.MainView
                For p_Int = 0 To Me.Columns.Count - 1

                    Try
                        Try
                            p_Column = Me.Columns(p_Int)
                            If UCase(p_Column.FieldView) = UCase(p_Column.Name) Then
                                p_Column.ToolTip = Me.ViewName & "." & p_Column.Name
                            Else
                                p_Column.ToolTip = Me.ViewName & "." & p_Column.Name & "." & p_Column.FieldView
                            End If
                        Catch ex As Exception
                            p_Column22 = Me.Columns(p_Int)
                            If UCase(p_Column22.FieldName) = UCase(p_Column22.Name) Then
                                p_Column22.ToolTip = Me.ViewName & "." & p_Column22.Name
                            Else
                                p_Column22.ToolTip = Me.ViewName & "." & p_Column22.Name & "." & p_Column22.FieldName
                            End If
                        End Try


                    Catch ex As Exception

                    End Try
                Next
                ' p_GridView 
            End If
        End If

        'ShowStatusMessage(False, "", p_Tag, 5)
        'Else
        'MsgBox(p_Tag)
        'End If

    End Sub


End Class
