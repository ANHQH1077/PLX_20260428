Imports System.ComponentModel
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraEditors
Imports System.Windows.Forms

Public Class FrmSearch

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

    Public p_ObjSearchReturn(0 To 10) As String
    Public p_ChooseRecord As Object
    Public p_ColumnWidth(0 To 200) As Integer
    Public p_ColumnHide(0 To 200) As String


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


    Sub New()
        InitSkins()
        InitializeComponent()
        ' Me.InitGrid()

    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        '   DevExpress.UserSkins.OfficeSkins.Register()
        'DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle("DevExpress Style")

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

    '==============================================================================

    Private Sub FrmSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            p_ChooseRecord.editvalue = "N"
        Catch ex As Exception

        End Try

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
        Dim p_SQLString As String = ""
        Dim p_where As String = ""
        Dim p_Count As Integer

        Try
            p_SQLString = "SELECT * FROM (" & UCase(Fpt_SQLString) & ") anhqh123 "
            If p_LoadForm = False Then

                For p_Count = 0 To Me.GridView1.Columns.Count - 1
                    If Me.GridView1.Columns.Item(p_Count).Visible = True Then
                        If p_where = "" Then
                            p_where = "  [" & Me.GridView1.Columns.Item(p_Count).FieldName & "] Like N'" & _
                                    Replace(Me.U_TextBox1.EditValue.ToString.Trim, "*", "%", 1) & "'"
                        Else
                            p_where = p_where & "  OR [" & Me.GridView1.Columns.Item(p_Count).FieldName & "] Like N'" & _
                                    Replace(Me.U_TextBox1.EditValue.ToString.Trim, "*", "%", 1) & "'"
                        End If
                    End If

                Next
                If p_where <> "" Then
                    p_where = " (" & p_where & ")"
                End If
                ' p_SQLString = UCase(Fpt_SQLString)
                'If InStr(p_SQLString, "WHERE", CompareMethod.Text) > 0 Then
                '    p_SQLString = p_SQLString & " AND " & p_where
                'Else
                p_SQLString = p_SQLString & " WHERE " & p_where
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
            Dim p_FptModule As New FPTModule.Class1(g_UserName, "", g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_User_Database)
            p_SQLString = p_FptModule.Parameter_Item(Fpt_ParentForm, p_SQLString)
            If p_FptModule.p_Mod_Set_TrueGrid_Property_Page(p_DesError, _
                                                    p_SQLString, _
                                                    Me, _
                                                    p_BindingSourceLine, _
                                                    Me.U_TrueDBGrid1, _
                                                    Me.GridView1, _
                                                    Fpt_FieldKey, _
                                                    Fpt_PageNum, _
                                                    Fpt_LineOfPage, _
                                                    Fpt_B1Get, _
                                                    Fpt_LoadPage) = False Then
                MsgBox(p_DesError)
            End If
            p_FptModule = Nothing

            Try
                Me.GridView1.Columns.Item("RowNum").Visible = False
            Catch ex As Exception

            End Try
            Me.GridView1.OptionsBehavior.AllowAddRows = False

            'Set Width  or Hide Column
            For p_Count = 0 To Me.GridView1.Columns.Count - 1
                If p_ColumnWidth(p_Count).ToString.Trim <> "" Then
                    If p_ColumnWidth(p_Count) > 0 Then
                        Me.GridView1.Columns.Item(p_Count).Width = p_ColumnWidth(p_Count)
                    End If

                End If
                If Not p_ColumnHide(p_Count) Is Nothing Then
                    If p_ColumnHide(p_Count).ToString.Trim = "Y" Then
                        'If p_ColumnHide(p_Count) > 0 Then
                        Me.GridView1.Columns.Item(p_Count).Visible = False
                        'End If

                    End If
                End If
            Next

            'p_ColumnHide
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '==============================================================================

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        If Not Me.U_TextBox1.EditValue Is Nothing Then
            If Me.U_TextBox1.EditValue.ToString <> "" Then
                Me.Cursor = Cursors.WaitCursor
                p_QuerySource(False)
                Me.Cursor = Cursors.Default
            Else
                MsgBox("Giá trị tìm kiếm không được trống")
            End If
        Else
            MsgBox("Giá trị tìm kiếm không được trống")
        End If
    End Sub



    Private Sub U_TrueDBGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
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
                            p_DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                            Try
                                Fpt_Object.SetRowCellValue(Fpt_Row_ID, p_ObjSearchReturn(p_Count).Trim, p_DataRow.Item(p_Count))
                            Catch ex As Exception

                            End Try

                            p_ChooseRecord.editvalue = "Y"
                        End If
                    End If
                Next
                Fpt_Object.RefreshEditor(True)
                ' Fpt_Object.refresh()
                'FptObject
            Else
                For p_Count = 0 To p_ObjSearchReturn.Length - 1   'Return cho item khong phai la Grid
                    If Not p_ObjSearchReturn(p_Count) Is Nothing Then
                        If p_ObjSearchReturn(p_Count).Trim <> "" Then

                            p_Control = Fpt_ParentForm.Controls.Find(p_ObjSearchReturn(p_Count).Trim, True)
                            If p_Control.Length > 0 Then
                                p_DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                                p_Control(0).Text = p_DataRow.Item(p_Count)
                                p_ChooseRecord.editvalue = "Y"
                                'End If
                            End If
                        End If
                    End If
                Next
            End If
        End If
        For p_Count = 0 To p_ObjSearchReturn.Length - 1
            p_ObjSearchReturn(p_Count) = Nothing
        Next
        Me.Close()

        'MsgBox(GridView1.FocusedRowHandle)

    End Sub

    
End Class