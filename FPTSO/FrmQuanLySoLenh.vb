Imports System.ComponentModel
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraEditors
Imports System.Windows.Forms

Public Class FrmQuanLySoLenh

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

    Private p_RollTerminal As String
    Private p_RutLenhXuat As Boolean = False



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
    Private Sub GridView1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        If Me.GridView1.FocusedRowHandle > 0 Then
            Me.TrueDBGrid1.EmbeddedNavigator.TextStringFormat = "Record " & Me.GridView1.FocusedRowHandle + 1 & "/" & Me.GridView1.RowCount & " - page " & Fpt_PageNum & "/" & g_TotalPage
        Else
            Me.TrueDBGrid1.EmbeddedNavigator.TextStringFormat = "Record 0/0"
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
        Dim p_SQL As String
        Dim p_Col As U_TextBox.GridColumn

        Dim p_Databale As DataTable

        p_SQL = "select KeyValue from sys_config where upper( keycode) =upper('RutLenhXuat')"

        p_Databale = GetDataTable(p_SQL, p_SQL)
       
        If Not p_Databale Is Nothing Then
            If p_Databale.Rows.Count > 0 Then
                If Trim(p_Databale.Rows(0).Item("KeyValue").ToString.Trim) = "Y" Then
                    p_RutLenhXuat = True
                End If
            End If
        End If


        If g_Company_Code = "6610" Then
            Me.GridView1.ViewName = "FPT_tblLenhXuatE5_QV"
            p_Col = Me.GridView1.Columns.Item(2)
            p_Col.FieldView = "TenHangHoa22"
        Else
            Me.GridView1.Columns.Item(2).Visible = False
        End If
        'Me.GridView1.Columns.Item(2).Visible = False

        p_SQL = "select * from sys_user where user_id=" & g_User_ID
        p_Databale = GetDataTable(p_SQL, p_SQL)
        p_RollTerminal = ""

        If Not p_Databale Is Nothing Then
            If p_Databale.Rows.Count > 0 Then
                p_RollTerminal = p_Databale.Rows(0).Item("Terminal").ToString.Trim
            End If
        End If

        Try

            If Not p_ObjSearchReturn(0) Is Nothing Then
                If p_ObjSearchReturn(0).Trim <> "" Then
                    p_Control = Fpt_ParentForm.Controls.Find(p_ObjSearchReturn(0).Trim, True)
                    If p_Control.Length > 0 Then
                        p_ButtonEdit = CType(p_Control(0), U_TextBox.U_ButtonEdit)
                        g_MultiCheck = p_ButtonEdit.MultiSelect
                    End If
                End If

            End If
            Me.U_DateEdit1.EditValue = Now.Date
            Fpt_LineOfPage = 1000
            Me.GridView1.OptionsBehavior.AllowAddRows = False


            If p_RutLenhXuat = True Then
                Me.cmdSoLenh.Visible = True
            End If
            'p_ChooseRecord.editvalue = "N"

            p_QuerySource(True)
            AddHandler TrueDBGrid1.EmbeddedNavigator.ButtonClick, AddressOf Grid_EmbeddedNavigator_ButtonClick
            GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.GridView1.Columns.Item("Status").Visible = True
        Catch ex As Exception

        End Try
    End Sub


    '==============================================================================
    Private Sub p_QuerySource(ByVal p_LoadForm As Boolean)
        Dim p_DesError As String = ""
        'Dim p_SQLString As String = ""
        Dim p_where As String = ""
        Dim p_where2 As String = ""
        Dim p_Count As Integer
        Dim p_SoLenh As String
        Dim p_Date As Date
        Dim p_ColumnKey As String
        Dim p_View As String

        Try
            ' If g_MultiCheck = True Then

            p_View = Me.GridView1.ViewName.ToString.Trim
            p_ColumnKey = Me.GridView1.ColumnKey.ToString.Trim


            p_SQLString = "SELECT * from  " & p_View
            'Else
            '  p_SQLString = "SELECT *  FROM (" & UCase(Fpt_SQLString) & ") anhqh123 "
            ' End If

            If p_LoadForm = False Then
                If Not Me.SoLenh.EditValue Is Nothing Then
                    If Me.SoLenh.EditValue.ToString.Trim <> "" Then
                        p_where = "SoLenh='" & Me.SoLenh.EditValue.ToString.Trim & "'"
                        p_where2 = "SoLenh='" & Me.SoLenh.EditValue.ToString.Trim & "'"
                    End If
                End If
                If Not Me.U_DateEdit1.EditValue Is Nothing Then
                    If Me.U_DateEdit1.EditValue.ToString.Trim <> "" Then
                        p_Date = Me.U_DateEdit1.EditValue
                        If p_where = "" Then
                            p_where = "NgayXuat='" & CDate(p_Date).ToString("yyyyMMdd") & "'"
                            p_where2 = "NgayXuat='" & CDate(p_Date).ToString("yyyyMMdd") & "'"
                        Else
                            p_where = p_where & " and NgayXuat='" & CDate(p_Date).ToString("yyyyMMdd") & "'"
                            p_where2 = p_where2 & " and NgayXuat='" & CDate(p_Date).ToString("yyyyMMdd") & "'"
                        End If
                    End If
                End If
                '  p_RollTerminal = "," & p_RollTerminal & ","

                If Not Me.U_ButtonEdit1.EditValue Is Nothing Then
                    If Me.U_ButtonEdit1.EditValue.ToString.Trim <> "" Then

                        If p_where = "" Then
                            p_where = "DiemTraHang=N'" & U_ButtonEdit1.EditValue.ToString.Trim & "'"
                            p_where2 = "DiemTraHang=N'" & U_ButtonEdit1.EditValue.ToString.Trim & "'"
                        Else
                            p_where = p_where & " and DiemTraHang=N'" & U_ButtonEdit1.EditValue.ToString.Trim & "'"
                            p_where2 = p_where & " and DiemTraHang=N'" & U_ButtonEdit1.EditValue.ToString.Trim & "'"
                        End If
                    End If
                End If

                If g_Filter_Terminal = True Then
                    If p_RollTerminal.ToString.Trim <> "" And g_Company_Code <> "6610" Then
                        If p_where <> "" Then
                            p_where = p_where & " AND CHARINDEX (  ',' + Client + ',','," & p_RollTerminal & ",',1)>0 "
                        Else
                            p_where = " CHARINDEX (  ',' + Client + ',','," & p_RollTerminal & ",',1)>0 "
                        End If
                    Else
                        If p_where <> "" Then
                            p_where = p_where & " AND Client ='" & g_Terminal & "' "
                        Else
                            p_where = "  Client ='" & g_Terminal & "' "
                        End If
                    End If
                End If
                If p_where <> "" Then
                    p_where = " (" & p_where & ")"
                    p_where2 = " (" & p_where2 & "  and left(SoLenh,len('" & g_WareHouse & "')) ='" & g_WareHouse & "' and isnull(client,'') ='' )"
                    p_SQLString = p_SQLString & " WHERE " & p_where & " or " & p_where2
                End If
                    ' p_SQLString = UCase(Fpt_SQLString)
                    'If InStr(p_SQLString, "WHERE", CompareMethod.Text) > 0 Then
                    '    p_SQLString = p_SQLString & " AND " & p_where
                    'Else
                    'If p_where <> "" Then

                    'End If

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
            p_SQLString = g_Module.Parameter_Item(Fpt_ParentForm, p_SQLString)
            If g_Module.p_Mod_Set_TrueGrid_Property_LoadPageNew(p_DesError, _
                                                    p_SQLString, _
                                                    Me, _
                                                    p_BindingSourceLine, _
                                                    Me.TrueDBGrid1, _
                                                    Me.GridView1, _
                                                    p_ColumnKey, _
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
                Me.TrueDBGrid1.EmbeddedNavigator.TextStringFormat = "Record " & Me.GridView1.FocusedRowHandle + 1 & "/" & Me.GridView1.RowCount & " - page " & FptPageNum & "/" & g_TotalPage
            Else
                Me.TrueDBGrid1.EmbeddedNavigator.TextStringFormat = "Record 0/0 - page 1/1"
            End If
            'Me.GridView1.SortedColumns 

         
               
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
            If g_Module.p_Mod_Set_TrueGrid_Property_LoadPageNew(p_DesError, _
                                                    p_SQLString, _
                                                    Me, _
                                                    p_BindingSourceLine, _
                                                    Me.TrueDBGrid1, _
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
                Me.TrueDBGrid1.EmbeddedNavigator.TextStringFormat = "Record " & Me.GridView1.FocusedRowHandle + 1 & "/" & Me.GridView1.RowCount & " - page " & FptPageNum & "/" & g_TotalPage
            Else
                Me.TrueDBGrid1.EmbeddedNavigator.TextStringFormat = "Record 0/0 - page 1/1"
            End If
            e.Handled = True

        End If

    End Sub


    '===========================================================
    Sub p_Search()
        'If Not Me.SoLenh.EditValue Is Nothing Then
        '    If Me.SoLenh.EditValue.ToString <> "" Or Me.GridView1.RowCount > 0 Then
        '        Me.Cursor = Cursors.WaitCursor
        '        p_QuerySource(False)
        '        Me.Cursor = Cursors.Default
        '    Else
        '        MsgBox("Giá trị tìm kiếm không được trống")
        '    End If
        'Else
        '    MsgBox("Giá trị tìm kiếm không được trống")
        'End If

        Me.Cursor = Cursors.WaitCursor
        p_QuerySource(False)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        Fpt_PageNum = 1

        p_Search()
        Me.GridView1.BestFitColumns()
    End Sub

    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
        Dim p_DataRow As DataRow

        If Me.GridView1.RowCount > 0 Then
            p_DataRow = Me.GridView1.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then
                ' If p_DataRow.Item(Me.GridView1.ColumnKey).ToString.Trim <> "" Then
                'Dim FrmMenu As New FrmORDR
                If p_DataRow.Item("Status").ToString.Trim = "1" Or p_DataRow.Item("Status").ToString.Trim = "2" Then
                    Dim FrmLenhXuatAdd As New FrmPhatHanhTichKe
                    FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                    FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
                    'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
                    FrmLenhXuatAdd.g_FormAddnew = False
                    FrmLenhXuatAdd.READ_ONLY = Me.READ_ONLY
                    FrmLenhXuatAdd.FormStatus = False
                    FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
                    FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                    FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
                    FrmLenhXuatAdd.g_SoLenh_Q = p_DataRow.Item("SoLenh").ToString.Trim
                    FrmLenhXuatAdd.DefaultWhere = " WHERE SoLenh='" & p_DataRow.Item("SoLenh").ToString.Trim & "'"
                    FrmLenhXuatAdd.ShowDialog(Me)
                End If

                If p_DataRow.Item("Status").ToString.Trim = "3" Or p_DataRow.Item("Status").ToString.Trim = "31" _
                        Or p_DataRow.Item("Status").ToString.Trim = "4" Or p_DataRow.Item("Status").ToString.Trim = "5" Then
                    Dim FrmLenhXuatAdd As New FrmGhiNhanThucXuat
                    FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                    FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
                    'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
                    FrmLenhXuatAdd.g_FormAddnew = False
                    FrmLenhXuatAdd.FormStatus = False
                    FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
                    FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                    FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
                    FrmLenhXuatAdd.g_SoLenh_Q = p_DataRow.Item("SoLenh").ToString.Trim
                    FrmLenhXuatAdd.DefaultWhere = " WHERE SoLenh='" & p_DataRow.Item("SoLenh").ToString.Trim & "'"
                    FrmLenhXuatAdd.ShowDialog(Me)
                End If

                'End If
            End If
        End If
    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub cmdSoLenh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSoLenh.Click
        Dim FrmLenhXuatAdd As New FrmSoLenhAuto
        FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
        'FrmLenhXuatAdd.g_FormAddnew = False
        'FrmLenhXuatAdd.READ_ONLY = Me.READ_ONLY
        FrmLenhXuatAdd.FormStatus = False
        FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
        FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
        FrmLenhXuatAdd.ShowDialog(Me)
    End Sub
End Class