Imports System.ComponentModel
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
'Imports DevExpress.UserSkins
Imports DevExpress.XtraEditors
Imports System.Windows.Forms

Public Class FrmSearchLov

    'Private Fpt_SQLString As String = ""
    'Private Fpt_Object As Object
    'Private Fpt_B1Get As Boolean = False
    'Private Fpt_Row_ID As Integer = 0
    'Private Fpt_Column_ID As Integer = 0
    'Private p_FieldKey As String = ""
    'Private p_PageNum As Integer = 1
    'Private p_LineOfPage As Integer = 100
    'Private p_LoadPage As Boolean = True
    'Private Fpt_ItemPosition As Object  'Ten item cần treo Form
    'Private Fpt_TypePosition As String   'Kiẻu   L:Left  ,T: Top,   R: Right,   B: Bottom, C: Center
    'Fpt_ShowLoad  true: Form hien thi du lieu luon    Fasle: khong hien thi du lieu khi Load form

    Public p_OrderbyExt As String = ""

    Private p_SQLString As String = ""
    Public p_ObjSearchReturn(0 To 10) As String
    Public p_ChooseRecord As Object
    Public p_ColumnWidth(0 To 100) As Integer   'Danh sach do rong cua cac Column neu co

    Private Fpt_SQLString As String = ""  'SQL show
    Public Fpt_Object As Object   'Object gọi form Searchs
    Private Fpt_B1Get As Boolean = False   'Fpt_B1Get=true: lay tren B1,  Fpt_B1Get=False: lấy trên FPTCUSTOMIZE
    Private Fpt_Row_ID As Integer = 0   'Dòng thứ i mà gọi Form Search
    ' Private Fpt_Column_ID As Integer = 0  
    Private Fpt_FieldKey As String = ""   'Trường Key trên Form Search nếu có dùng thuộc tính Fpt_LoadPage=true
    Private Fpt_PageNum As Integer = 1  'Page cần lấy dữ liệu
    Private Fpt_LineOfPage As Integer = 100    'Số bản ghi trên 1 
    Private Fpt_LoadPage As Boolean = True

    Private Fpt_ItemPosition As Object   'Item để form Search treo vị trí
    Private Fpt_TypePosition As String    'Vị trí hiển thị của Form Search  L: left  , R: Right,  T: Top,   B: Bottom,  C: Center

    Private Fpt_ParentForm As Form   'Form chính gọi form Search

    Private p_BindingSourceLine As New System.Windows.Forms.BindingSource

    Private Fpt_ShowLoad As Boolean = False
    ' Private Fpt_
    Private g_TotalPage As Integer

    Private g_MultiCheck As Boolean = False

    Public p_CFLColumnHide As String = ""

    Private Sub HideColumn()
        Dim p_ColumnName As String
        Dim p_Count As Integer
        For p_Count = 0 To Me.GridView1.Columns.Count - 1
            p_ColumnName = "," & UCase(Me.GridView1.Columns.Item(p_Count).Name.ToString.Trim) & ","
            If InStr(p_CFLColumnHide, p_ColumnName, CompareMethod.Text) > 0 Then
                Me.GridView1.Columns.Item(p_Count).Visible = False
            End If
        Next
    End Sub


    Sub New()
        InitSkins()
        InitializeComponent()
        ' Me.InitGrid()

    End Sub
    Sub InitSkins()
        'DevExpress.Skins.SkinManager.EnableFormSkins()
        'DevExpress.UserSkins.OfficeSkins.Register()
        'DevExpress.UserSkins.BonusSkins.Register()
        'UserLookAndFeel.Default.SetSkinStyle("DevExpress Style")

    End Sub
#Region "Property"
    Public Property FptShowLoad() As Boolean
        Get
            Return Fpt_ShowLoad
        End Get
        Set(ByVal value As Boolean)
            Fpt_ShowLoad = value
        End Set
    End Property


    Public Property FptParentForm() As Form
        Get
            Return Fpt_ParentForm
        End Get
        Set(ByVal value As Form)
            Fpt_ParentForm = value
        End Set
    End Property

    Public Property FptItemPosition() As Object
        Get
            Return Fpt_ItemPosition
        End Get
        Set(ByVal value As Object)
            Fpt_ItemPosition = value
        End Set
    End Property

    Public Property FptTypePosition() As String
        Get
            Return Fpt_TypePosition
        End Get
        Set(ByVal value As String)
            Fpt_TypePosition = value
        End Set
    End Property

    Public Property FptLoadPage() As Boolean
        Get
            Return Fpt_LoadPage
        End Get
        Set(ByVal value As Boolean)
            Fpt_LoadPage = value
        End Set
    End Property


    Public Property FptLineOfPage() As Integer
        Get
            Return Fpt_LineOfPage
        End Get
        Set(ByVal value As Integer)
            Fpt_LineOfPage = value
        End Set
    End Property

    Public Property FptPageNum() As Integer
        Get
            Return Fpt_PageNum
        End Get
        Set(ByVal value As Integer)
            Fpt_PageNum = value
        End Set
    End Property

    Public Property FptFieldKey() As String
        Get
            Return Fpt_FieldKey
        End Get
        Set(ByVal value As String)
            Fpt_FieldKey = value
        End Set
    End Property


    Public Property FptRowID() As Integer
        Get
            Return Fpt_Row_ID
        End Get
        Set(ByVal value As Integer)
            Fpt_Row_ID = value
        End Set
    End Property

    'Public Property FptColumnID() As Integer
    '    Get
    '        Return Fpt_Column_ID
    '    End Get
    '    Set(ByVal value As Integer)
    '        Fpt_Column_ID = value
    '    End Set
    'End Property


    'Public Property FptObject() As Object
    '    Get
    '        Return Fpt_Object
    '    End Get
    '    Set(ByVal value As Object)
    '        Fpt_Object = value
    '    End Set
    'End Property

    Public Property FptB1Get() As Boolean
        Get
            Return Fpt_B1Get
        End Get
        Set(ByVal value As Boolean)
            Fpt_B1Get = value
        End Set
    End Property

    Public Property FptSQLString() As String
        Get
            Return Fpt_SQLString
        End Get
        Set(ByVal value As String)
            Fpt_SQLString = value
        End Set
    End Property
#End Region
    Private Sub GridView1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If Me.GridView1.FocusedRowHandle > 0 Then
            Me.U_TrueDBGrid1.EmbeddedNavigator.TextStringFormat = "Record " & Me.GridView1.FocusedRowHandle + 1 & "/" & Me.GridView1.RowCount & " - page " & Fpt_PageNum & "/" & g_TotalPage
        Else
            Me.U_TrueDBGrid1.EmbeddedNavigator.TextStringFormat = "Record 0/0"
        End If

    End Sub

    Private Sub FrmSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            p_Search()
        End If
    End Sub

    Private Sub FrmSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        ' MsgBox(e.KeyChar)
        If Asc(e.KeyChar) = 27 Then
            Me.Close()
        End If
    End Sub

    '==============================================================================

    Private Sub FrmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_ButtonEdit As U_TextBox.U_ButtonEdit = Nothing
        Dim p_Control() As Object
        If Not p_ObjSearchReturn(0) Is Nothing Then
            If p_ObjSearchReturn(0).Trim <> "" Then
                p_Control = Fpt_ParentForm.Controls.Find(p_ObjSearchReturn(0).Trim, True)
                If p_Control.Length > 0 Then
                    p_ButtonEdit = CType(p_Control(0), U_TextBox.U_ButtonEdit)
                    g_MultiCheck = p_ButtonEdit.MultiSelect
                End If
            End If

        End If

        If g_MultiCheck = True Then
            Me.Height = 470
            Me.BtnMultiCheck.Visible = True
        Else
            Me.Height = 224
            Me.BtnMultiCheck.Visible = False
        End If

        'p_SetPosition
        Fpt_LineOfPage = 100
        Me.GridView1.OptionsBehavior.AllowAddRows = False
        AddHandler U_TrueDBGrid1.EmbeddedNavigator.ButtonClick, AddressOf Grid_EmbeddedNavigator_ButtonClick
        GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        p_ChooseRecord.editvalue = "N"
        p_SetPosition()
        p_QuerySource(True)
    End Sub


    Private Sub p_SetPosition()
        Try

            Dim p_Left As Integer = Fpt_ParentForm.Left
            Dim p_Top As Integer = Fpt_ParentForm.Top
            If Not Fpt_ItemPosition Is Nothing Then
                Select Case UCase(Fpt_TypePosition)
                    Case "L"  'Left
                        p_Left = p_Left + Fpt_ItemPosition.Left - Me.Width
                        p_Top = p_Top + 27 + Fpt_ItemPosition.Top + Fpt_ItemPosition.Height
                    Case "R"  'Right
                        p_Left = p_Left + p_Left + Fpt_ItemPosition.Left + Fpt_ItemPosition.Width
                        p_Top = p_Top + 27 + Fpt_ItemPosition.Top + Fpt_ItemPosition.Height
                    Case "B"  'Bottom
                        p_Left = p_Left + Fpt_ItemPosition.Left
                        p_Top = p_Top + 27 + Fpt_ItemPosition.Top + Fpt_ItemPosition.Height
                    Case "T"   'TOP
                        p_Left = p_Left + Fpt_ItemPosition.Left
                        p_Top = p_Top + 27 + Fpt_ItemPosition.Top - Me.Height
                    Case "C"
                        p_Left = p_Left + Fpt_ParentForm.Width / 2 - Me.Width / 2
                        p_Top = p_Top + Fpt_ParentForm.Height / 2 - Me.Height / 2
                End Select

                Me.Left = p_Left
                Me.Top = p_Top
            End If

        Catch ex As Exception

        End Try
    End Sub
    '==============================================================================
    Private Sub p_QuerySource(ByVal p_LoadForm As Boolean)
        Dim p_DesError As String = ""
        'Dim p_SQLString As String = ""
        Dim p_where As String = ""
        Dim p_Count As Integer

        Try
            If g_MultiCheck = True Then
                p_SQLString = "SELECT *, 'N' as X FROM (" & UCase(Fpt_SQLString) & ") anhqh123 "
            Else
                p_SQLString = "SELECT *  FROM (" & UCase(Fpt_SQLString) & ") anhqh123 "
            End If

            If p_LoadForm = False Then

                For p_Count = 0 To Me.GridView1.Columns.Count - 1
                    If Me.GridView1.Columns.Item(p_Count).Visible = True Then
                        If g_MultiCheck = True Then
                            If Me.GridView1.Columns.Item(p_Count).FieldName = "X" Then
                                Continue For
                            End If
                        End If
                        'If p_where = "" Then
                        '    p_where = "  [" & Me.GridView1.Columns.Item(p_Count).FieldName & "] Like N'" & _
                        '            Replace(Me.U_TextBox1.EditValue.ToString.Trim, "*", "%", 1) & "'"
                        'Else
                        '    p_where = p_where & "  OR [" & Me.GridView1.Columns.Item(p_Count).FieldName & "] Like N'" & _
                        '            Replace(Me.U_TextBox1.EditValue.ToString.Trim, "*", "%", 1) & "'"
                        'End If
                        'End If

                    End If

                Next
                'If p_where <> "" Then
                '    p_where = " (" & p_where & ")"
                'End If
                ' p_SQLString = UCase(Fpt_SQLString)
                'If InStr(p_SQLString, "WHERE", CompareMethod.Text) > 0 Then
                '    p_SQLString = p_SQLString & " AND " & p_where
                'Else
                p_SQLString = p_SQLString '& " WHERE " & p_where
                'End If
            Else
                If Fpt_ShowLoad = False Then
                    'If InStr(p_SQLString, "WHERE", CompareMethod.Text) > 0 Then
                    '    p_SQLString = p_SQLString & " AND 1=0"
                    'Else
                    p_SQLString = p_SQLString & " WHERE 1=0"
                    'End If
                End If
            End If
            'Dim p_FptModule As New FPTModule.Class1(g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName)
            p_SQLString = p_Parameter_Item(Fpt_ParentForm, p_SQLString)
            If p_Set_TrueGrid_Property_LoadPage(p_DesError, _
                                                    p_SQLString, _
                                                    Me, _
                                                    p_BindingSourceLine, _
                                                    Me.U_TrueDBGrid1, _
                                                    Me.GridView1, _
                                                    Fpt_FieldKey, _
                                                    Fpt_PageNum, _
                                                    Fpt_LineOfPage, _
                                                    g_TotalPage, _
                                                    Fpt_B1Get, _
                                                    Fpt_LoadPage) = False Then
                MsgBox(p_DesError)
            End If
            ' p_FptModule = Nothing

            Try
                Me.GridView1.Columns.Item("RowNum").Visible = False
            Catch ex As Exception

            End Try
            Me.GridView1.OptionsBehavior.AllowAddRows = False
            For p_Count = 0 To Me.GridView1.Columns.Count - 1
                If p_ColumnWidth(p_Count).ToString.Trim <> "" Then
                    If p_ColumnWidth(p_Count) > 0 Then
                        Me.GridView1.Columns.Item(p_Count).Width = p_ColumnWidth(p_Count)
                    End If

                End If
            Next
            If g_MultiCheck = True Then
                'Dim p_Column As New DevExpress.XtraGrid.Columns.GridColumn
                Dim p_ColType As New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                p_ColType.ValueChecked = "Y"
                p_ColType.ValueUnchecked = "N"


                Me.GridView1.Columns.Item("X").ColumnEdit = p_ColType
                Me.GridView1.Columns.Item("X").Width = 10
                Me.GridView1.OptionsBehavior.Editable = True
                For p_Count = 0 To Me.GridView1.Columns.Count - 1
                    If Me.GridView1.Columns.Item(p_Count).FieldName = "X" Then
                        Me.GridView1.Columns.Item(p_Count).OptionsColumn.AllowEdit = True
                    Else
                        Me.GridView1.Columns.Item(p_Count).OptionsColumn.AllowEdit = False
                    End If


                Next
                'Me.GridView1.Columns.Item("X").OptionsColumn.AllowEdit = True

            End If
            'Me.GridView1.OptionsBehavior.AllowAddRows = False
            Me.GridView1.OptionsBehavior.AllowAddRows = False
            GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            If Me.GridView1.FocusedRowHandle >= 0 Then
                Me.U_TrueDBGrid1.EmbeddedNavigator.TextStringFormat = "Record " & Me.GridView1.FocusedRowHandle + 1 & "/" & Me.GridView1.RowCount & " - page " & FptPageNum & "/" & g_TotalPage
            Else
                Me.U_TrueDBGrid1.EmbeddedNavigator.TextStringFormat = "Record 0/0 - page 1/1"
            End If
            HideColumn()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '===================

    Sub Grid_EmbeddedNavigator_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_DesError As String = ""
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.NextPage _
               Or e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.PrevPage _
               Or e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.First _
               Or e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Last Then
            'e.Handled = True

            'Dim a As DevExpress.XtraEditors.NavigatorButtonBase



            Select Case e.Button.ButtonType
                Case DevExpress.XtraEditors.NavigatorButtonType.NextPage
                    If Fpt_PageNum < g_TotalPage Then
                        Fpt_PageNum = Fpt_PageNum + 1
                    End If
                Case DevExpress.XtraEditors.NavigatorButtonType.PrevPage
                    If Fpt_PageNum > 1 Then
                        Fpt_PageNum = Fpt_PageNum - 1
                    End If
                Case DevExpress.XtraEditors.NavigatorButtonType.First
                    Fpt_PageNum = 1
                Case DevExpress.XtraEditors.NavigatorButtonType.Last
                    Fpt_PageNum = g_TotalPage
            End Select

            'If p_PageNum < p_PageTotal Then
            '    p_PageNum = p_PageNum + 1
            If p_Set_TrueGrid_Property_LoadPage(p_DesError, _
                                                    p_SQLString, _
                                                    Me, _
                                                    p_BindingSourceLine, _
                                                    Me.U_TrueDBGrid1, _
                                                    Me.GridView1, _
                                                    Fpt_FieldKey, _
                                                    Fpt_PageNum, _
                                                    Fpt_LineOfPage, _
                                                    g_TotalPage, _
                                                    Fpt_B1Get, _
                                                    Fpt_LoadPage) = False Then
                MsgBox(p_DesError)
            End If
            ' p_FptModule = Nothing

            Try
                Me.GridView1.Columns.Item("RowNum").Visible = False
            Catch ex As Exception

            End Try
            Me.GridView1.OptionsBehavior.AllowAddRows = False
            For p_Count = 0 To Me.GridView1.Columns.Count - 1
                If p_ColumnWidth(p_Count).ToString.Trim <> "" Then
                    If p_ColumnWidth(p_Count) > 0 Then
                        Me.GridView1.Columns.Item(p_Count).Width = p_ColumnWidth(p_Count)
                    End If

                End If
            Next
            'Me.GridView1.OptionsBehavior.AllowAddRows = False
            Me.GridView1.OptionsBehavior.AllowAddRows = False
            GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            If Me.GridView1.FocusedRowHandle >= 0 Then
                Me.U_TrueDBGrid1.EmbeddedNavigator.TextStringFormat = "Record " & Me.GridView1.FocusedRowHandle + 1 & "/" & Me.GridView1.RowCount & " - page " & FptPageNum & "/" & g_TotalPage
            Else
                Me.U_TrueDBGrid1.EmbeddedNavigator.TextStringFormat = "Record 0/0 - page 1/1"
            End If
            e.Handled = True

        End If

    End Sub


    '===========================================================
    Sub p_Search()
        'If Not Me.U_TextBox1.EditValue Is Nothing Then
        '    If Me.U_TextBox1.EditValue.ToString <> "" Or Me.GridView1.RowCount > 0 Then
        '        Me.Cursor = Cursors.WaitCursor
        '        p_QuerySource(False)
        '        Me.Cursor = Cursors.Default
        '    Else
        '        MsgBox("Giá trị tìm kiếm không được trống")
        '    End If
        'Else
        '    MsgBox("Giá trị tìm kiếm không được trống")
        'End If
    End Sub

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Fpt_PageNum = 1
        p_Search()
    End Sub

    Sub p_ChooseDoubleClick()
        '' System.EventArgs) Handles U_TrueDBGrid1.DoubleClick
        ''p_ObjSearchReturn
        ''Dim p_Count As Integer
        Dim p_DataRow As DataRow
        Dim p_Control() As Control
        ''e.
        If GridView1.FocusedRowHandle >= 0 Then
            If InStr(UCase(Fpt_Object.ToString), "VIEWS.GRID", CompareMethod.Text) > 0 Then   'Return cho Grid
                For p_Count = 0 To p_ObjSearchReturn.Length - 1   'Return cho item khong phai la Grid
                    If Not p_ObjSearchReturn(p_Count) Is Nothing Then
                        If p_ObjSearchReturn(p_Count).Trim <> "" Then
                            Try
                                p_DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                                Fpt_Object.SetRowCellValue(Fpt_Row_ID, p_ObjSearchReturn(p_Count).Trim, p_DataRow.Item(p_Count))
                                p_ChooseRecord.editvalue = "Y"
                            Catch ex As Exception
                                'If Fpt_Object.FocusedRowHandle < 0 Then
                                '    Fpt_Object.AddNewRow()
                                '    p_DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                                '    Fpt_Object.SetRowCellValue(Fpt_Row_ID, p_ObjSearchReturn(p_Count).Trim, p_DataRow.Item(p_Count))
                                '    p_ChooseRecord.editvalue = "Y"
                                'End If

                            End Try


                            'If p_GridView.FocusedRowHandle < 0 Then
                            '    p_GridView.AddNewRow()
                            'End If
                        End If
                    End If
                Next
                Fpt_Object.RefreshEditor(True)
                ' Fpt_Object.refresh()
                'FptObject
            Else
                'Dim p_ButtonEdit As U_TextBox.U_ButtonEdit = Nothing
                'If Not p_ObjSearchReturn(0) Is Nothing Then
                '    If p_ObjSearchReturn(0).Trim <> "" Then
                '        p_Control = Fpt_ParentForm.Controls.Find(p_ObjSearchReturn(0).Trim, True)
                '        If p_Control.Length > 0 Then
                '            p_ButtonEdit = CType(p_Control(0), U_TextBox.U_ButtonEdit)
                '        End If
                '    End If
                'Else
                '    Exit Sub
                'End If
                'If p_ButtonEdit Is Nothing Then Exit Sub
                'If p_ButtonEdit.MultiSelect = False Then
                p_DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                For p_Count = 0 To p_ObjSearchReturn.Length - 1   'Return cho item khong phai la Grid
                    If Not p_ObjSearchReturn(p_Count) Is Nothing Then
                        If p_ObjSearchReturn(p_Count).Trim <> "" Then

                            p_Control = Fpt_ParentForm.Controls.Find(p_ObjSearchReturn(p_Count).Trim, True)
                            If p_Control.Length > 0 Then

                                p_Control(0).Text = p_DataRow.Item(p_Count).ToString.Trim
                                p_ChooseRecord.editvalue = "Y"
                                'End If
                            End If
                        End If
                    End If
                Next
                'End If
            End If
        End If
        Me.Close()

        'MsgBox(GridView1.FocusedRowHandle)

    End Sub

    Private Sub U_TrueDBGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
        p_ChooseDoubleClick()
    End Sub

    Private Sub U_TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            p_ChooseDoubleClick()
        End If
    End Sub

    Private Sub GridView1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridView1.KeyPress
        'p_ChooseDoubleClick()
    End Sub

    Private Sub BtnMultiCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMultiCheck.Click
        If g_MultiCheck = False Then
            p_ChooseDoubleClick()
            Exit Sub
        End If

        Try
            Dim p_Count As Integer
            Dim p_String As String = ""
            Dim p_CellValue As String
            Dim p_Control() As Object
            ' Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
            ' p_GridView = Me.GridView1
            ' p_GridView.OptionsFilter.
            GridView1.ActiveFilterString = "X='Y'"

            For p_Count = 0 To Me.GridView1.RowCount - 1
                p_CellValue = GridView1.GetRowCellValue(p_Count, "X").ToString
                If p_CellValue = "Y" Then
                    p_CellValue = GridView1.GetRowCellValue(p_Count, GridView1.Columns(0).FieldName.ToString).ToString
                    p_String = p_String & "," & p_CellValue
                End If
            Next
            If p_String <> "" Then
                p_String = Mid(p_String, 2)
            End If

            p_Control = Fpt_ParentForm.Controls.Find(p_ObjSearchReturn(0).Trim, True)
            If p_Control.Length > 0 Then

                p_Control(0).Text = p_String
                p_ChooseRecord.editvalue = "Y"
                'End If
            End If
            Me.Close()
            ' GridView1.ClearColumnsFilter()
        Catch ex As Exception
            GridView1.ClearColumnsFilter()
        End Try
    End Sub
End Class