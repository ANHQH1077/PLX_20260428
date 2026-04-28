<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMeterGroupHist
    Inherits U_CusForm.XtraCusForm1

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.MeterId = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.Valid_from = New U_TextBox.GridColumn()
        Me.Valid_to = New U_TextBox.GridColumn()
        Me.Bexuat = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.TankGroup = New U_TextBox.GridColumn()
        Me.TankValidfrom = New U_TextBox.GridColumn()
        Me.TankValid_to = New U_TextBox.GridColumn()
        Me.MaHangHoa = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.TenHangHoa = New U_TextBox.GridColumn()
        Me.Push_TDH = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Push_XTTD = New U_TextBox.GridColumn()
        Me.User_Push_TDH = New U_TextBox.GridColumn()
        Me.Date_Push_TDH = New U_TextBox.GridColumn()
        Me.User_Push_XTTD = New U_TextBox.GridColumn()
        Me.Date_Push_XTTD = New U_TextBox.GridColumn()
        Me.CreateUser = New U_TextBox.GridColumn()
        Me.CreateDate = New U_TextBox.GridColumn()
        Me.UpdateUser = New U_TextBox.GridColumn()
        Me.UpdateDate = New U_TextBox.GridColumn()
        Me.sType = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(2, 12)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemComboBox1, Me.RepositoryItemButtonEdit2, Me.RepositoryItemButtonEdit3, Me.RepositoryItemCheckEdit1, Me.RepositoryItemButtonEdit4, Me.RepositoryItemCheckEdit2})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(1025, 472)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.CheckUpd = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MeterId, Me.Valid_from, Me.Valid_to, Me.Bexuat, Me.TankGroup, Me.TankValidfrom, Me.TankValid_to, Me.MaHangHoa, Me.TenHangHoa, Me.Push_TDH, Me.Push_XTTD, Me.User_Push_TDH, Me.Date_Push_TDH, Me.User_Push_XTTD, Me.Date_Push_XTTD, Me.CreateUser, Me.CreateDate, Me.UpdateUser, Me.UpdateDate, Me.sType})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OrderBy = "MeterId, CreateDate, UpdateDate"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "tblCongToNhomBe_Hist"
        Me.GridView1.Where = Nothing
        '
        'MeterId
        '
        Me.MeterId.AllowInsert = True
        Me.MeterId.AllowUpdate = True
        Me.MeterId.ButtonClick = True
        Me.MeterId.Caption = "Mã công tơ"
        Me.MeterId.CFLColumnHide = ""
        Me.MeterId.CFLKeyField = "MeterId"
        Me.MeterId.CFLPage = False
        Me.MeterId.CFLReturn0 = ""
        Me.MeterId.CFLReturn1 = ""
        Me.MeterId.CFLReturn2 = ""
        Me.MeterId.CFLReturn3 = ""
        Me.MeterId.CFLReturn4 = ""
        Me.MeterId.CFLReturn5 = ""
        Me.MeterId.CFLReturn6 = ""
        Me.MeterId.CFLReturn7 = ""
        Me.MeterId.CFLShowLoad = True
        Me.MeterId.ChangeFormStatus = True
        Me.MeterId.ColumnEdit = Me.RepositoryItemButtonEdit4
        Me.MeterId.ColumnKey = True
        Me.MeterId.ComboLine = 5
        Me.MeterId.CopyFromItem = ""
        Me.MeterId.DefaultButtonClick = False
        Me.MeterId.Digit = False
        Me.MeterId.FieldType = "C"
        Me.MeterId.FieldView = "MeterId"
        Me.MeterId.FormarNumber = True
        Me.MeterId.FormList = False
        Me.MeterId.KeyInsert = "Y"
        Me.MeterId.LocalDecimal = False
        Me.MeterId.Name = "MeterId"
        Me.MeterId.NoUpdate = ""
        Me.MeterId.NumberDecimal = 0
        Me.MeterId.OptionsColumn.ReadOnly = True
        Me.MeterId.ParentControl = ""
        Me.MeterId.RefreshSource = False
        Me.MeterId.Required = False
        Me.MeterId.SequenceName = ""
        Me.MeterId.ShowCalc = True
        Me.MeterId.ShowDataTime = False
        Me.MeterId.ShowOnlyTime = False
        Me.MeterId.SQLString = ""
        Me.MeterId.UpdateIfNull = ""
        Me.MeterId.UpdateWhenFormLock = False
        Me.MeterId.UpperValue = False
        Me.MeterId.ValidateValue = True
        Me.MeterId.Visible = True
        Me.MeterId.VisibleIndex = 0
        '
        'RepositoryItemButtonEdit4
        '
        Me.RepositoryItemButtonEdit4.AutoHeight = False
        Me.RepositoryItemButtonEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit4.Name = "RepositoryItemButtonEdit4"
        '
        'Valid_from
        '
        Me.Valid_from.AllowInsert = True
        Me.Valid_from.AllowUpdate = True
        Me.Valid_from.ButtonClick = True
        Me.Valid_from.Caption = "Ngày hiệu lực"
        Me.Valid_from.CFLColumnHide = ""
        Me.Valid_from.CFLKeyField = ""
        Me.Valid_from.CFLPage = False
        Me.Valid_from.CFLReturn0 = ""
        Me.Valid_from.CFLReturn1 = ""
        Me.Valid_from.CFLReturn2 = ""
        Me.Valid_from.CFLReturn3 = ""
        Me.Valid_from.CFLReturn4 = ""
        Me.Valid_from.CFLReturn5 = ""
        Me.Valid_from.CFLReturn6 = ""
        Me.Valid_from.CFLReturn7 = ""
        Me.Valid_from.CFLShowLoad = False
        Me.Valid_from.ChangeFormStatus = True
        Me.Valid_from.ColumnKey = False
        Me.Valid_from.ComboLine = 5
        Me.Valid_from.CopyFromItem = ""
        Me.Valid_from.DefaultButtonClick = False
        Me.Valid_from.Digit = False
        Me.Valid_from.FieldType = "D"
        Me.Valid_from.FieldView = "Valid_from"
        Me.Valid_from.FormarNumber = True
        Me.Valid_from.FormList = False
        Me.Valid_from.KeyInsert = ""
        Me.Valid_from.LocalDecimal = False
        Me.Valid_from.Name = "Valid_from"
        Me.Valid_from.NoUpdate = ""
        Me.Valid_from.NumberDecimal = 0
        Me.Valid_from.OptionsColumn.ReadOnly = True
        Me.Valid_from.ParentControl = ""
        Me.Valid_from.RefreshSource = False
        Me.Valid_from.Required = False
        Me.Valid_from.SequenceName = ""
        Me.Valid_from.ShowCalc = True
        Me.Valid_from.ShowDataTime = True
        Me.Valid_from.ShowOnlyTime = False
        Me.Valid_from.SQLString = ""
        Me.Valid_from.UpdateIfNull = ""
        Me.Valid_from.UpdateWhenFormLock = False
        Me.Valid_from.UpperValue = False
        Me.Valid_from.ValidateValue = True
        Me.Valid_from.Visible = True
        Me.Valid_from.VisibleIndex = 1
        Me.Valid_from.Width = 110
        '
        'Valid_to
        '
        Me.Valid_to.AllowInsert = True
        Me.Valid_to.AllowUpdate = True
        Me.Valid_to.ButtonClick = True
        Me.Valid_to.Caption = "Hết hiệu lực"
        Me.Valid_to.CFLColumnHide = ""
        Me.Valid_to.CFLKeyField = ""
        Me.Valid_to.CFLPage = False
        Me.Valid_to.CFLReturn0 = ""
        Me.Valid_to.CFLReturn1 = ""
        Me.Valid_to.CFLReturn2 = ""
        Me.Valid_to.CFLReturn3 = ""
        Me.Valid_to.CFLReturn4 = ""
        Me.Valid_to.CFLReturn5 = ""
        Me.Valid_to.CFLReturn6 = ""
        Me.Valid_to.CFLReturn7 = ""
        Me.Valid_to.CFLShowLoad = False
        Me.Valid_to.ChangeFormStatus = True
        Me.Valid_to.ColumnKey = False
        Me.Valid_to.ComboLine = 5
        Me.Valid_to.CopyFromItem = ""
        Me.Valid_to.DefaultButtonClick = False
        Me.Valid_to.Digit = False
        Me.Valid_to.FieldType = "D"
        Me.Valid_to.FieldView = "Valid_to"
        Me.Valid_to.FormarNumber = True
        Me.Valid_to.FormList = False
        Me.Valid_to.KeyInsert = ""
        Me.Valid_to.LocalDecimal = False
        Me.Valid_to.Name = "Valid_to"
        Me.Valid_to.NoUpdate = ""
        Me.Valid_to.NumberDecimal = 0
        Me.Valid_to.OptionsColumn.ReadOnly = True
        Me.Valid_to.ParentControl = ""
        Me.Valid_to.RefreshSource = False
        Me.Valid_to.Required = False
        Me.Valid_to.SequenceName = ""
        Me.Valid_to.ShowCalc = True
        Me.Valid_to.ShowDataTime = True
        Me.Valid_to.ShowOnlyTime = False
        Me.Valid_to.SQLString = ""
        Me.Valid_to.UpdateIfNull = ""
        Me.Valid_to.UpdateWhenFormLock = False
        Me.Valid_to.UpperValue = False
        Me.Valid_to.ValidateValue = True
        Me.Valid_to.Visible = True
        Me.Valid_to.VisibleIndex = 2
        Me.Valid_to.Width = 110
        '
        'Bexuat
        '
        Me.Bexuat.AllowInsert = True
        Me.Bexuat.AllowUpdate = True
        Me.Bexuat.ButtonClick = False
        Me.Bexuat.Caption = "Mã bể"
        Me.Bexuat.CFLColumnHide = ""
        Me.Bexuat.CFLKeyField = "Bexuat"
        Me.Bexuat.CFLPage = False
        Me.Bexuat.CFLReturn0 = ""
        Me.Bexuat.CFLReturn1 = ""
        Me.Bexuat.CFLReturn2 = ""
        Me.Bexuat.CFLReturn3 = ""
        Me.Bexuat.CFLReturn4 = ""
        Me.Bexuat.CFLReturn5 = ""
        Me.Bexuat.CFLReturn6 = ""
        Me.Bexuat.CFLReturn7 = ""
        Me.Bexuat.CFLShowLoad = True
        Me.Bexuat.ChangeFormStatus = True
        Me.Bexuat.ColumnEdit = Me.RepositoryItemButtonEdit3
        Me.Bexuat.ColumnKey = False
        Me.Bexuat.ComboLine = 5
        Me.Bexuat.CopyFromItem = ""
        Me.Bexuat.DefaultButtonClick = False
        Me.Bexuat.Digit = False
        Me.Bexuat.FieldType = "C"
        Me.Bexuat.FieldView = "Bexuat"
        Me.Bexuat.FormarNumber = True
        Me.Bexuat.FormList = False
        Me.Bexuat.KeyInsert = ""
        Me.Bexuat.LocalDecimal = False
        Me.Bexuat.Name = "Bexuat"
        Me.Bexuat.NoUpdate = ""
        Me.Bexuat.NumberDecimal = 0
        Me.Bexuat.OptionsColumn.ReadOnly = True
        Me.Bexuat.ParentControl = ""
        Me.Bexuat.RefreshSource = False
        Me.Bexuat.Required = False
        Me.Bexuat.SequenceName = ""
        Me.Bexuat.ShowCalc = True
        Me.Bexuat.ShowDataTime = False
        Me.Bexuat.ShowOnlyTime = False
        Me.Bexuat.SQLString = ""
        Me.Bexuat.UpdateIfNull = ""
        Me.Bexuat.UpdateWhenFormLock = False
        Me.Bexuat.UpperValue = False
        Me.Bexuat.ValidateValue = True
        Me.Bexuat.Visible = True
        Me.Bexuat.VisibleIndex = 3
        '
        'RepositoryItemButtonEdit3
        '
        Me.RepositoryItemButtonEdit3.AutoHeight = False
        Me.RepositoryItemButtonEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit3.Name = "RepositoryItemButtonEdit3"
        '
        'TankGroup
        '
        Me.TankGroup.AllowInsert = True
        Me.TankGroup.AllowUpdate = True
        Me.TankGroup.ButtonClick = True
        Me.TankGroup.Caption = "Nhóm bể xuất"
        Me.TankGroup.CFLColumnHide = ""
        Me.TankGroup.CFLKeyField = ""
        Me.TankGroup.CFLPage = False
        Me.TankGroup.CFLReturn0 = ""
        Me.TankGroup.CFLReturn1 = ""
        Me.TankGroup.CFLReturn2 = ""
        Me.TankGroup.CFLReturn3 = ""
        Me.TankGroup.CFLReturn4 = ""
        Me.TankGroup.CFLReturn5 = ""
        Me.TankGroup.CFLReturn6 = ""
        Me.TankGroup.CFLReturn7 = ""
        Me.TankGroup.CFLShowLoad = False
        Me.TankGroup.ChangeFormStatus = True
        Me.TankGroup.ColumnKey = False
        Me.TankGroup.ComboLine = 5
        Me.TankGroup.CopyFromItem = ""
        Me.TankGroup.DefaultButtonClick = False
        Me.TankGroup.Digit = False
        Me.TankGroup.FieldType = "C"
        Me.TankGroup.FieldView = "TankGroup"
        Me.TankGroup.FormarNumber = True
        Me.TankGroup.FormList = False
        Me.TankGroup.KeyInsert = ""
        Me.TankGroup.LocalDecimal = False
        Me.TankGroup.Name = "TankGroup"
        Me.TankGroup.NoUpdate = ""
        Me.TankGroup.NumberDecimal = 0
        Me.TankGroup.OptionsColumn.ReadOnly = True
        Me.TankGroup.ParentControl = ""
        Me.TankGroup.RefreshSource = False
        Me.TankGroup.Required = False
        Me.TankGroup.SequenceName = ""
        Me.TankGroup.ShowCalc = True
        Me.TankGroup.ShowDataTime = False
        Me.TankGroup.ShowOnlyTime = False
        Me.TankGroup.SQLString = ""
        Me.TankGroup.UpdateIfNull = ""
        Me.TankGroup.UpdateWhenFormLock = False
        Me.TankGroup.UpperValue = False
        Me.TankGroup.ValidateValue = True
        Me.TankGroup.Visible = True
        Me.TankGroup.VisibleIndex = 4
        Me.TankGroup.Width = 110
        '
        'TankValidfrom
        '
        Me.TankValidfrom.AllowInsert = True
        Me.TankValidfrom.AllowUpdate = True
        Me.TankValidfrom.ButtonClick = True
        Me.TankValidfrom.Caption = "Hiệu lực nhóm bể"
        Me.TankValidfrom.CFLColumnHide = ""
        Me.TankValidfrom.CFLKeyField = ""
        Me.TankValidfrom.CFLPage = False
        Me.TankValidfrom.CFLReturn0 = ""
        Me.TankValidfrom.CFLReturn1 = ""
        Me.TankValidfrom.CFLReturn2 = ""
        Me.TankValidfrom.CFLReturn3 = ""
        Me.TankValidfrom.CFLReturn4 = ""
        Me.TankValidfrom.CFLReturn5 = ""
        Me.TankValidfrom.CFLReturn6 = ""
        Me.TankValidfrom.CFLReturn7 = ""
        Me.TankValidfrom.CFLShowLoad = False
        Me.TankValidfrom.ChangeFormStatus = True
        Me.TankValidfrom.ColumnKey = False
        Me.TankValidfrom.ComboLine = 5
        Me.TankValidfrom.CopyFromItem = ""
        Me.TankValidfrom.DefaultButtonClick = False
        Me.TankValidfrom.Digit = False
        Me.TankValidfrom.FieldType = "D"
        Me.TankValidfrom.FieldView = "TankValidfrom"
        Me.TankValidfrom.FormarNumber = True
        Me.TankValidfrom.FormList = False
        Me.TankValidfrom.KeyInsert = ""
        Me.TankValidfrom.LocalDecimal = False
        Me.TankValidfrom.Name = "TankValidfrom"
        Me.TankValidfrom.NoUpdate = ""
        Me.TankValidfrom.NumberDecimal = 0
        Me.TankValidfrom.OptionsColumn.ReadOnly = True
        Me.TankValidfrom.ParentControl = ""
        Me.TankValidfrom.RefreshSource = False
        Me.TankValidfrom.Required = False
        Me.TankValidfrom.SequenceName = ""
        Me.TankValidfrom.ShowCalc = True
        Me.TankValidfrom.ShowDataTime = True
        Me.TankValidfrom.ShowOnlyTime = False
        Me.TankValidfrom.SQLString = ""
        Me.TankValidfrom.UpdateIfNull = ""
        Me.TankValidfrom.UpdateWhenFormLock = False
        Me.TankValidfrom.UpperValue = False
        Me.TankValidfrom.ValidateValue = True
        Me.TankValidfrom.Visible = True
        Me.TankValidfrom.VisibleIndex = 5
        Me.TankValidfrom.Width = 110
        '
        'TankValid_to
        '
        Me.TankValid_to.AllowInsert = True
        Me.TankValid_to.AllowUpdate = True
        Me.TankValid_to.ButtonClick = True
        Me.TankValid_to.Caption = "Hết hiệu lực nhóm bể"
        Me.TankValid_to.CFLColumnHide = ""
        Me.TankValid_to.CFLKeyField = ""
        Me.TankValid_to.CFLPage = False
        Me.TankValid_to.CFLReturn0 = ""
        Me.TankValid_to.CFLReturn1 = ""
        Me.TankValid_to.CFLReturn2 = ""
        Me.TankValid_to.CFLReturn3 = ""
        Me.TankValid_to.CFLReturn4 = ""
        Me.TankValid_to.CFLReturn5 = ""
        Me.TankValid_to.CFLReturn6 = ""
        Me.TankValid_to.CFLReturn7 = ""
        Me.TankValid_to.CFLShowLoad = False
        Me.TankValid_to.ChangeFormStatus = True
        Me.TankValid_to.ColumnKey = False
        Me.TankValid_to.ComboLine = 5
        Me.TankValid_to.CopyFromItem = ""
        Me.TankValid_to.DefaultButtonClick = False
        Me.TankValid_to.Digit = False
        Me.TankValid_to.FieldType = "D"
        Me.TankValid_to.FieldView = "TankValid_to"
        Me.TankValid_to.FormarNumber = True
        Me.TankValid_to.FormList = False
        Me.TankValid_to.KeyInsert = ""
        Me.TankValid_to.LocalDecimal = False
        Me.TankValid_to.Name = "TankValid_to"
        Me.TankValid_to.NoUpdate = ""
        Me.TankValid_to.NumberDecimal = 0
        Me.TankValid_to.OptionsColumn.ReadOnly = True
        Me.TankValid_to.ParentControl = ""
        Me.TankValid_to.RefreshSource = False
        Me.TankValid_to.Required = False
        Me.TankValid_to.SequenceName = ""
        Me.TankValid_to.ShowCalc = True
        Me.TankValid_to.ShowDataTime = True
        Me.TankValid_to.ShowOnlyTime = False
        Me.TankValid_to.SQLString = ""
        Me.TankValid_to.UpdateIfNull = ""
        Me.TankValid_to.UpdateWhenFormLock = False
        Me.TankValid_to.UpperValue = False
        Me.TankValid_to.ValidateValue = True
        Me.TankValid_to.Visible = True
        Me.TankValid_to.VisibleIndex = 6
        Me.TankValid_to.Width = 110
        '
        'MaHangHoa
        '
        Me.MaHangHoa.AllowInsert = True
        Me.MaHangHoa.AllowUpdate = True
        Me.MaHangHoa.ButtonClick = True
        Me.MaHangHoa.Caption = "Mã hàng hóa"
        Me.MaHangHoa.CFLColumnHide = ""
        Me.MaHangHoa.CFLKeyField = "MaHangHoa"
        Me.MaHangHoa.CFLPage = False
        Me.MaHangHoa.CFLReturn0 = ""
        Me.MaHangHoa.CFLReturn1 = "TenHangHoa"
        Me.MaHangHoa.CFLReturn2 = ""
        Me.MaHangHoa.CFLReturn3 = ""
        Me.MaHangHoa.CFLReturn4 = ""
        Me.MaHangHoa.CFLReturn5 = ""
        Me.MaHangHoa.CFLReturn6 = ""
        Me.MaHangHoa.CFLReturn7 = ""
        Me.MaHangHoa.CFLShowLoad = True
        Me.MaHangHoa.ChangeFormStatus = True
        Me.MaHangHoa.ColumnEdit = Me.RepositoryItemButtonEdit2
        Me.MaHangHoa.ColumnKey = False
        Me.MaHangHoa.ComboLine = 5
        Me.MaHangHoa.CopyFromItem = ""
        Me.MaHangHoa.DefaultButtonClick = False
        Me.MaHangHoa.Digit = False
        Me.MaHangHoa.FieldType = "C"
        Me.MaHangHoa.FieldView = "MaHangHoa"
        Me.MaHangHoa.FormarNumber = True
        Me.MaHangHoa.FormList = False
        Me.MaHangHoa.KeyInsert = ""
        Me.MaHangHoa.LocalDecimal = False
        Me.MaHangHoa.Name = "MaHangHoa"
        Me.MaHangHoa.NoUpdate = ""
        Me.MaHangHoa.NumberDecimal = 0
        Me.MaHangHoa.OptionsColumn.ReadOnly = True
        Me.MaHangHoa.ParentControl = ""
        Me.MaHangHoa.RefreshSource = False
        Me.MaHangHoa.Required = False
        Me.MaHangHoa.SequenceName = ""
        Me.MaHangHoa.ShowCalc = True
        Me.MaHangHoa.ShowDataTime = False
        Me.MaHangHoa.ShowOnlyTime = False
        Me.MaHangHoa.SQLString = "SELECT MaHangHoa as MaHangHoa,TenHangHoa FROM tblHangHoa a where exists (select 1" & _
            " from tblTank b where a.MaHangHoa=b.Product_nd )  "
        Me.MaHangHoa.UpdateIfNull = ""
        Me.MaHangHoa.UpdateWhenFormLock = False
        Me.MaHangHoa.UpperValue = False
        Me.MaHangHoa.ValidateValue = True
        Me.MaHangHoa.Visible = True
        Me.MaHangHoa.VisibleIndex = 7
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        '
        'TenHangHoa
        '
        Me.TenHangHoa.AllowInsert = True
        Me.TenHangHoa.AllowUpdate = True
        Me.TenHangHoa.ButtonClick = True
        Me.TenHangHoa.Caption = "Tên hàng hóa"
        Me.TenHangHoa.CFLColumnHide = ""
        Me.TenHangHoa.CFLKeyField = ""
        Me.TenHangHoa.CFLPage = False
        Me.TenHangHoa.CFLReturn0 = ""
        Me.TenHangHoa.CFLReturn1 = ""
        Me.TenHangHoa.CFLReturn2 = ""
        Me.TenHangHoa.CFLReturn3 = ""
        Me.TenHangHoa.CFLReturn4 = ""
        Me.TenHangHoa.CFLReturn5 = ""
        Me.TenHangHoa.CFLReturn6 = ""
        Me.TenHangHoa.CFLReturn7 = ""
        Me.TenHangHoa.CFLShowLoad = False
        Me.TenHangHoa.ChangeFormStatus = True
        Me.TenHangHoa.ColumnKey = False
        Me.TenHangHoa.ComboLine = 5
        Me.TenHangHoa.CopyFromItem = ""
        Me.TenHangHoa.DefaultButtonClick = False
        Me.TenHangHoa.Digit = False
        Me.TenHangHoa.FieldType = "C"
        Me.TenHangHoa.FieldView = "TenHangHoa"
        Me.TenHangHoa.FormarNumber = True
        Me.TenHangHoa.FormList = False
        Me.TenHangHoa.KeyInsert = ""
        Me.TenHangHoa.LocalDecimal = False
        Me.TenHangHoa.Name = "TenHangHoa"
        Me.TenHangHoa.NoUpdate = ""
        Me.TenHangHoa.NumberDecimal = 0
        Me.TenHangHoa.OptionsColumn.ReadOnly = True
        Me.TenHangHoa.ParentControl = ""
        Me.TenHangHoa.RefreshSource = False
        Me.TenHangHoa.Required = False
        Me.TenHangHoa.SequenceName = ""
        Me.TenHangHoa.ShowCalc = True
        Me.TenHangHoa.ShowDataTime = False
        Me.TenHangHoa.ShowOnlyTime = False
        Me.TenHangHoa.SQLString = ""
        Me.TenHangHoa.UpdateIfNull = ""
        Me.TenHangHoa.UpdateWhenFormLock = False
        Me.TenHangHoa.UpperValue = False
        Me.TenHangHoa.ValidateValue = True
        Me.TenHangHoa.Visible = True
        Me.TenHangHoa.VisibleIndex = 8
        Me.TenHangHoa.Width = 110
        '
        'Push_TDH
        '
        Me.Push_TDH.AllowInsert = True
        Me.Push_TDH.AllowUpdate = True
        Me.Push_TDH.ButtonClick = True
        Me.Push_TDH.Caption = "Đẩy TĐH"
        Me.Push_TDH.CFLColumnHide = ""
        Me.Push_TDH.CFLKeyField = ""
        Me.Push_TDH.CFLPage = False
        Me.Push_TDH.CFLReturn0 = ""
        Me.Push_TDH.CFLReturn1 = ""
        Me.Push_TDH.CFLReturn2 = ""
        Me.Push_TDH.CFLReturn3 = ""
        Me.Push_TDH.CFLReturn4 = ""
        Me.Push_TDH.CFLReturn5 = ""
        Me.Push_TDH.CFLReturn6 = ""
        Me.Push_TDH.CFLReturn7 = ""
        Me.Push_TDH.CFLShowLoad = False
        Me.Push_TDH.ChangeFormStatus = True
        Me.Push_TDH.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.Push_TDH.ColumnKey = False
        Me.Push_TDH.ComboLine = 5
        Me.Push_TDH.CopyFromItem = ""
        Me.Push_TDH.DefaultButtonClick = False
        Me.Push_TDH.Digit = False
        Me.Push_TDH.FieldType = "C"
        Me.Push_TDH.FieldView = "Push_TDH"
        Me.Push_TDH.FormarNumber = True
        Me.Push_TDH.FormList = False
        Me.Push_TDH.KeyInsert = ""
        Me.Push_TDH.LocalDecimal = False
        Me.Push_TDH.Name = "Push_TDH"
        Me.Push_TDH.NoUpdate = ""
        Me.Push_TDH.NumberDecimal = 0
        Me.Push_TDH.OptionsColumn.ReadOnly = True
        Me.Push_TDH.ParentControl = ""
        Me.Push_TDH.RefreshSource = False
        Me.Push_TDH.Required = False
        Me.Push_TDH.SequenceName = ""
        Me.Push_TDH.ShowCalc = True
        Me.Push_TDH.ShowDataTime = False
        Me.Push_TDH.ShowOnlyTime = False
        Me.Push_TDH.SQLString = ""
        Me.Push_TDH.UpdateIfNull = ""
        Me.Push_TDH.UpdateWhenFormLock = False
        Me.Push_TDH.UpperValue = False
        Me.Push_TDH.ValidateValue = True
        Me.Push_TDH.Visible = True
        Me.Push_TDH.VisibleIndex = 9
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Y"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "N"
        '
        'Push_XTTD
        '
        Me.Push_XTTD.AllowInsert = True
        Me.Push_XTTD.AllowUpdate = True
        Me.Push_XTTD.ButtonClick = True
        Me.Push_XTTD.Caption = "Đẩy xếp tài"
        Me.Push_XTTD.CFLColumnHide = ""
        Me.Push_XTTD.CFLKeyField = ""
        Me.Push_XTTD.CFLPage = False
        Me.Push_XTTD.CFLReturn0 = ""
        Me.Push_XTTD.CFLReturn1 = ""
        Me.Push_XTTD.CFLReturn2 = ""
        Me.Push_XTTD.CFLReturn3 = ""
        Me.Push_XTTD.CFLReturn4 = ""
        Me.Push_XTTD.CFLReturn5 = ""
        Me.Push_XTTD.CFLReturn6 = ""
        Me.Push_XTTD.CFLReturn7 = ""
        Me.Push_XTTD.CFLShowLoad = False
        Me.Push_XTTD.ChangeFormStatus = True
        Me.Push_XTTD.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.Push_XTTD.ColumnKey = False
        Me.Push_XTTD.ComboLine = 5
        Me.Push_XTTD.CopyFromItem = ""
        Me.Push_XTTD.DefaultButtonClick = False
        Me.Push_XTTD.Digit = False
        Me.Push_XTTD.FieldType = "C"
        Me.Push_XTTD.FieldView = "Push_XTTD"
        Me.Push_XTTD.FormarNumber = True
        Me.Push_XTTD.FormList = False
        Me.Push_XTTD.KeyInsert = ""
        Me.Push_XTTD.LocalDecimal = False
        Me.Push_XTTD.Name = "Push_XTTD"
        Me.Push_XTTD.NoUpdate = ""
        Me.Push_XTTD.NumberDecimal = 0
        Me.Push_XTTD.OptionsColumn.ReadOnly = True
        Me.Push_XTTD.ParentControl = ""
        Me.Push_XTTD.RefreshSource = False
        Me.Push_XTTD.Required = False
        Me.Push_XTTD.SequenceName = ""
        Me.Push_XTTD.ShowCalc = True
        Me.Push_XTTD.ShowDataTime = False
        Me.Push_XTTD.ShowOnlyTime = False
        Me.Push_XTTD.SQLString = ""
        Me.Push_XTTD.UpdateIfNull = ""
        Me.Push_XTTD.UpdateWhenFormLock = False
        Me.Push_XTTD.UpperValue = False
        Me.Push_XTTD.ValidateValue = True
        Me.Push_XTTD.Visible = True
        Me.Push_XTTD.VisibleIndex = 10
        '
        'User_Push_TDH
        '
        Me.User_Push_TDH.AllowInsert = True
        Me.User_Push_TDH.AllowUpdate = True
        Me.User_Push_TDH.ButtonClick = True
        Me.User_Push_TDH.Caption = "User_đẩy TĐH"
        Me.User_Push_TDH.CFLColumnHide = ""
        Me.User_Push_TDH.CFLKeyField = ""
        Me.User_Push_TDH.CFLPage = False
        Me.User_Push_TDH.CFLReturn0 = ""
        Me.User_Push_TDH.CFLReturn1 = ""
        Me.User_Push_TDH.CFLReturn2 = ""
        Me.User_Push_TDH.CFLReturn3 = ""
        Me.User_Push_TDH.CFLReturn4 = ""
        Me.User_Push_TDH.CFLReturn5 = ""
        Me.User_Push_TDH.CFLReturn6 = ""
        Me.User_Push_TDH.CFLReturn7 = ""
        Me.User_Push_TDH.CFLShowLoad = False
        Me.User_Push_TDH.ChangeFormStatus = True
        Me.User_Push_TDH.ColumnKey = False
        Me.User_Push_TDH.ComboLine = 5
        Me.User_Push_TDH.CopyFromItem = ""
        Me.User_Push_TDH.DefaultButtonClick = False
        Me.User_Push_TDH.Digit = False
        Me.User_Push_TDH.FieldType = "C"
        Me.User_Push_TDH.FieldView = "User_Push_TDH"
        Me.User_Push_TDH.FormarNumber = True
        Me.User_Push_TDH.FormList = False
        Me.User_Push_TDH.KeyInsert = ""
        Me.User_Push_TDH.LocalDecimal = False
        Me.User_Push_TDH.Name = "User_Push_TDH"
        Me.User_Push_TDH.NoUpdate = ""
        Me.User_Push_TDH.NumberDecimal = 0
        Me.User_Push_TDH.OptionsColumn.ReadOnly = True
        Me.User_Push_TDH.ParentControl = ""
        Me.User_Push_TDH.RefreshSource = False
        Me.User_Push_TDH.Required = False
        Me.User_Push_TDH.SequenceName = ""
        Me.User_Push_TDH.ShowCalc = True
        Me.User_Push_TDH.ShowDataTime = False
        Me.User_Push_TDH.ShowOnlyTime = False
        Me.User_Push_TDH.SQLString = ""
        Me.User_Push_TDH.UpdateIfNull = ""
        Me.User_Push_TDH.UpdateWhenFormLock = False
        Me.User_Push_TDH.UpperValue = False
        Me.User_Push_TDH.ValidateValue = True
        Me.User_Push_TDH.Visible = True
        Me.User_Push_TDH.VisibleIndex = 11
        '
        'Date_Push_TDH
        '
        Me.Date_Push_TDH.AllowInsert = True
        Me.Date_Push_TDH.AllowUpdate = True
        Me.Date_Push_TDH.ButtonClick = True
        Me.Date_Push_TDH.Caption = "Ngày đẩy TĐH"
        Me.Date_Push_TDH.CFLColumnHide = ""
        Me.Date_Push_TDH.CFLKeyField = ""
        Me.Date_Push_TDH.CFLPage = False
        Me.Date_Push_TDH.CFLReturn0 = ""
        Me.Date_Push_TDH.CFLReturn1 = ""
        Me.Date_Push_TDH.CFLReturn2 = ""
        Me.Date_Push_TDH.CFLReturn3 = ""
        Me.Date_Push_TDH.CFLReturn4 = ""
        Me.Date_Push_TDH.CFLReturn5 = ""
        Me.Date_Push_TDH.CFLReturn6 = ""
        Me.Date_Push_TDH.CFLReturn7 = ""
        Me.Date_Push_TDH.CFLShowLoad = False
        Me.Date_Push_TDH.ChangeFormStatus = True
        Me.Date_Push_TDH.ColumnKey = False
        Me.Date_Push_TDH.ComboLine = 5
        Me.Date_Push_TDH.CopyFromItem = ""
        Me.Date_Push_TDH.DefaultButtonClick = False
        Me.Date_Push_TDH.Digit = False
        Me.Date_Push_TDH.FieldType = "D"
        Me.Date_Push_TDH.FieldView = "Date_Push_TDH"
        Me.Date_Push_TDH.FormarNumber = True
        Me.Date_Push_TDH.FormList = False
        Me.Date_Push_TDH.KeyInsert = ""
        Me.Date_Push_TDH.LocalDecimal = False
        Me.Date_Push_TDH.Name = "Date_Push_TDH"
        Me.Date_Push_TDH.NoUpdate = ""
        Me.Date_Push_TDH.NumberDecimal = 0
        Me.Date_Push_TDH.OptionsColumn.ReadOnly = True
        Me.Date_Push_TDH.ParentControl = ""
        Me.Date_Push_TDH.RefreshSource = False
        Me.Date_Push_TDH.Required = False
        Me.Date_Push_TDH.SequenceName = ""
        Me.Date_Push_TDH.ShowCalc = True
        Me.Date_Push_TDH.ShowDataTime = True
        Me.Date_Push_TDH.ShowOnlyTime = False
        Me.Date_Push_TDH.SQLString = ""
        Me.Date_Push_TDH.UpdateIfNull = ""
        Me.Date_Push_TDH.UpdateWhenFormLock = False
        Me.Date_Push_TDH.UpperValue = False
        Me.Date_Push_TDH.ValidateValue = True
        Me.Date_Push_TDH.Visible = True
        Me.Date_Push_TDH.VisibleIndex = 12
        Me.Date_Push_TDH.Width = 110
        '
        'User_Push_XTTD
        '
        Me.User_Push_XTTD.AllowInsert = True
        Me.User_Push_XTTD.AllowUpdate = True
        Me.User_Push_XTTD.ButtonClick = True
        Me.User_Push_XTTD.Caption = "User đẩy xếp tài"
        Me.User_Push_XTTD.CFLColumnHide = ""
        Me.User_Push_XTTD.CFLKeyField = ""
        Me.User_Push_XTTD.CFLPage = False
        Me.User_Push_XTTD.CFLReturn0 = ""
        Me.User_Push_XTTD.CFLReturn1 = ""
        Me.User_Push_XTTD.CFLReturn2 = ""
        Me.User_Push_XTTD.CFLReturn3 = ""
        Me.User_Push_XTTD.CFLReturn4 = ""
        Me.User_Push_XTTD.CFLReturn5 = ""
        Me.User_Push_XTTD.CFLReturn6 = ""
        Me.User_Push_XTTD.CFLReturn7 = ""
        Me.User_Push_XTTD.CFLShowLoad = False
        Me.User_Push_XTTD.ChangeFormStatus = True
        Me.User_Push_XTTD.ColumnKey = False
        Me.User_Push_XTTD.ComboLine = 5
        Me.User_Push_XTTD.CopyFromItem = ""
        Me.User_Push_XTTD.DefaultButtonClick = False
        Me.User_Push_XTTD.Digit = False
        Me.User_Push_XTTD.FieldType = "C"
        Me.User_Push_XTTD.FieldView = "User_Push_XTTD"
        Me.User_Push_XTTD.FormarNumber = True
        Me.User_Push_XTTD.FormList = False
        Me.User_Push_XTTD.KeyInsert = ""
        Me.User_Push_XTTD.LocalDecimal = False
        Me.User_Push_XTTD.Name = "User_Push_XTTD"
        Me.User_Push_XTTD.NoUpdate = ""
        Me.User_Push_XTTD.NumberDecimal = 0
        Me.User_Push_XTTD.OptionsColumn.ReadOnly = True
        Me.User_Push_XTTD.ParentControl = ""
        Me.User_Push_XTTD.RefreshSource = False
        Me.User_Push_XTTD.Required = False
        Me.User_Push_XTTD.SequenceName = ""
        Me.User_Push_XTTD.ShowCalc = True
        Me.User_Push_XTTD.ShowDataTime = False
        Me.User_Push_XTTD.ShowOnlyTime = False
        Me.User_Push_XTTD.SQLString = ""
        Me.User_Push_XTTD.UpdateIfNull = ""
        Me.User_Push_XTTD.UpdateWhenFormLock = False
        Me.User_Push_XTTD.UpperValue = False
        Me.User_Push_XTTD.ValidateValue = True
        Me.User_Push_XTTD.Visible = True
        Me.User_Push_XTTD.VisibleIndex = 13
        '
        'Date_Push_XTTD
        '
        Me.Date_Push_XTTD.AllowInsert = True
        Me.Date_Push_XTTD.AllowUpdate = True
        Me.Date_Push_XTTD.ButtonClick = True
        Me.Date_Push_XTTD.Caption = "Ngày đẩy xếp tài"
        Me.Date_Push_XTTD.CFLColumnHide = ""
        Me.Date_Push_XTTD.CFLKeyField = ""
        Me.Date_Push_XTTD.CFLPage = False
        Me.Date_Push_XTTD.CFLReturn0 = ""
        Me.Date_Push_XTTD.CFLReturn1 = ""
        Me.Date_Push_XTTD.CFLReturn2 = ""
        Me.Date_Push_XTTD.CFLReturn3 = ""
        Me.Date_Push_XTTD.CFLReturn4 = ""
        Me.Date_Push_XTTD.CFLReturn5 = ""
        Me.Date_Push_XTTD.CFLReturn6 = ""
        Me.Date_Push_XTTD.CFLReturn7 = ""
        Me.Date_Push_XTTD.CFLShowLoad = False
        Me.Date_Push_XTTD.ChangeFormStatus = True
        Me.Date_Push_XTTD.ColumnKey = False
        Me.Date_Push_XTTD.ComboLine = 5
        Me.Date_Push_XTTD.CopyFromItem = ""
        Me.Date_Push_XTTD.DefaultButtonClick = False
        Me.Date_Push_XTTD.Digit = False
        Me.Date_Push_XTTD.FieldType = "D"
        Me.Date_Push_XTTD.FieldView = "Date_Push_XTTD"
        Me.Date_Push_XTTD.FormarNumber = True
        Me.Date_Push_XTTD.FormList = False
        Me.Date_Push_XTTD.KeyInsert = ""
        Me.Date_Push_XTTD.LocalDecimal = False
        Me.Date_Push_XTTD.Name = "Date_Push_XTTD"
        Me.Date_Push_XTTD.NoUpdate = ""
        Me.Date_Push_XTTD.NumberDecimal = 0
        Me.Date_Push_XTTD.OptionsColumn.ReadOnly = True
        Me.Date_Push_XTTD.ParentControl = ""
        Me.Date_Push_XTTD.RefreshSource = False
        Me.Date_Push_XTTD.Required = False
        Me.Date_Push_XTTD.SequenceName = ""
        Me.Date_Push_XTTD.ShowCalc = True
        Me.Date_Push_XTTD.ShowDataTime = True
        Me.Date_Push_XTTD.ShowOnlyTime = False
        Me.Date_Push_XTTD.SQLString = ""
        Me.Date_Push_XTTD.UpdateIfNull = ""
        Me.Date_Push_XTTD.UpdateWhenFormLock = False
        Me.Date_Push_XTTD.UpperValue = False
        Me.Date_Push_XTTD.ValidateValue = True
        Me.Date_Push_XTTD.Visible = True
        Me.Date_Push_XTTD.VisibleIndex = 14
        '
        'CreateUser
        '
        Me.CreateUser.AllowInsert = True
        Me.CreateUser.AllowUpdate = True
        Me.CreateUser.ButtonClick = True
        Me.CreateUser.Caption = "Người tạo"
        Me.CreateUser.CFLColumnHide = ""
        Me.CreateUser.CFLKeyField = ""
        Me.CreateUser.CFLPage = False
        Me.CreateUser.CFLReturn0 = ""
        Me.CreateUser.CFLReturn1 = ""
        Me.CreateUser.CFLReturn2 = ""
        Me.CreateUser.CFLReturn3 = ""
        Me.CreateUser.CFLReturn4 = ""
        Me.CreateUser.CFLReturn5 = ""
        Me.CreateUser.CFLReturn6 = ""
        Me.CreateUser.CFLReturn7 = ""
        Me.CreateUser.CFLShowLoad = False
        Me.CreateUser.ChangeFormStatus = True
        Me.CreateUser.ColumnKey = False
        Me.CreateUser.ComboLine = 5
        Me.CreateUser.CopyFromItem = ""
        Me.CreateUser.DefaultButtonClick = False
        Me.CreateUser.Digit = False
        Me.CreateUser.FieldType = "C"
        Me.CreateUser.FieldView = "CreateUser"
        Me.CreateUser.FormarNumber = True
        Me.CreateUser.FormList = False
        Me.CreateUser.KeyInsert = ""
        Me.CreateUser.LocalDecimal = False
        Me.CreateUser.Name = "CreateUser"
        Me.CreateUser.NoUpdate = ""
        Me.CreateUser.NumberDecimal = 0
        Me.CreateUser.OptionsColumn.ReadOnly = True
        Me.CreateUser.ParentControl = ""
        Me.CreateUser.RefreshSource = False
        Me.CreateUser.Required = False
        Me.CreateUser.SequenceName = ""
        Me.CreateUser.ShowCalc = True
        Me.CreateUser.ShowDataTime = False
        Me.CreateUser.ShowOnlyTime = False
        Me.CreateUser.SQLString = ""
        Me.CreateUser.UpdateIfNull = ""
        Me.CreateUser.UpdateWhenFormLock = False
        Me.CreateUser.UpperValue = False
        Me.CreateUser.ValidateValue = True
        Me.CreateUser.Visible = True
        Me.CreateUser.VisibleIndex = 15
        '
        'CreateDate
        '
        Me.CreateDate.AllowInsert = True
        Me.CreateDate.AllowUpdate = True
        Me.CreateDate.ButtonClick = True
        Me.CreateDate.Caption = "Ngày tạo"
        Me.CreateDate.CFLColumnHide = ""
        Me.CreateDate.CFLKeyField = ""
        Me.CreateDate.CFLPage = False
        Me.CreateDate.CFLReturn0 = ""
        Me.CreateDate.CFLReturn1 = ""
        Me.CreateDate.CFLReturn2 = ""
        Me.CreateDate.CFLReturn3 = ""
        Me.CreateDate.CFLReturn4 = ""
        Me.CreateDate.CFLReturn5 = ""
        Me.CreateDate.CFLReturn6 = ""
        Me.CreateDate.CFLReturn7 = ""
        Me.CreateDate.CFLShowLoad = False
        Me.CreateDate.ChangeFormStatus = True
        Me.CreateDate.ColumnKey = False
        Me.CreateDate.ComboLine = 5
        Me.CreateDate.CopyFromItem = ""
        Me.CreateDate.DefaultButtonClick = False
        Me.CreateDate.Digit = False
        Me.CreateDate.FieldType = "D"
        Me.CreateDate.FieldView = "CreateDate"
        Me.CreateDate.FormarNumber = True
        Me.CreateDate.FormList = False
        Me.CreateDate.KeyInsert = ""
        Me.CreateDate.LocalDecimal = False
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.NoUpdate = ""
        Me.CreateDate.NumberDecimal = 0
        Me.CreateDate.OptionsColumn.ReadOnly = True
        Me.CreateDate.ParentControl = ""
        Me.CreateDate.RefreshSource = False
        Me.CreateDate.Required = False
        Me.CreateDate.SequenceName = ""
        Me.CreateDate.ShowCalc = True
        Me.CreateDate.ShowDataTime = True
        Me.CreateDate.ShowOnlyTime = False
        Me.CreateDate.SQLString = ""
        Me.CreateDate.UpdateIfNull = ""
        Me.CreateDate.UpdateWhenFormLock = False
        Me.CreateDate.UpperValue = False
        Me.CreateDate.ValidateValue = True
        Me.CreateDate.Visible = True
        Me.CreateDate.VisibleIndex = 16
        Me.CreateDate.Width = 110
        '
        'UpdateUser
        '
        Me.UpdateUser.AllowInsert = True
        Me.UpdateUser.AllowUpdate = True
        Me.UpdateUser.ButtonClick = True
        Me.UpdateUser.Caption = "Người sửa"
        Me.UpdateUser.CFLColumnHide = ""
        Me.UpdateUser.CFLKeyField = ""
        Me.UpdateUser.CFLPage = False
        Me.UpdateUser.CFLReturn0 = ""
        Me.UpdateUser.CFLReturn1 = ""
        Me.UpdateUser.CFLReturn2 = ""
        Me.UpdateUser.CFLReturn3 = ""
        Me.UpdateUser.CFLReturn4 = ""
        Me.UpdateUser.CFLReturn5 = ""
        Me.UpdateUser.CFLReturn6 = ""
        Me.UpdateUser.CFLReturn7 = ""
        Me.UpdateUser.CFLShowLoad = False
        Me.UpdateUser.ChangeFormStatus = True
        Me.UpdateUser.ColumnKey = False
        Me.UpdateUser.ComboLine = 5
        Me.UpdateUser.CopyFromItem = ""
        Me.UpdateUser.DefaultButtonClick = False
        Me.UpdateUser.Digit = False
        Me.UpdateUser.FieldType = "C"
        Me.UpdateUser.FieldView = "UpdateUser"
        Me.UpdateUser.FormarNumber = True
        Me.UpdateUser.FormList = False
        Me.UpdateUser.KeyInsert = ""
        Me.UpdateUser.LocalDecimal = False
        Me.UpdateUser.Name = "UpdateUser"
        Me.UpdateUser.NoUpdate = ""
        Me.UpdateUser.NumberDecimal = 0
        Me.UpdateUser.OptionsColumn.ReadOnly = True
        Me.UpdateUser.ParentControl = ""
        Me.UpdateUser.RefreshSource = False
        Me.UpdateUser.Required = False
        Me.UpdateUser.SequenceName = ""
        Me.UpdateUser.ShowCalc = True
        Me.UpdateUser.ShowDataTime = False
        Me.UpdateUser.ShowOnlyTime = False
        Me.UpdateUser.SQLString = ""
        Me.UpdateUser.UpdateIfNull = ""
        Me.UpdateUser.UpdateWhenFormLock = False
        Me.UpdateUser.UpperValue = False
        Me.UpdateUser.ValidateValue = True
        Me.UpdateUser.Visible = True
        Me.UpdateUser.VisibleIndex = 17
        '
        'UpdateDate
        '
        Me.UpdateDate.AllowInsert = True
        Me.UpdateDate.AllowUpdate = True
        Me.UpdateDate.ButtonClick = True
        Me.UpdateDate.Caption = "Ngày sửa"
        Me.UpdateDate.CFLColumnHide = ""
        Me.UpdateDate.CFLKeyField = ""
        Me.UpdateDate.CFLPage = False
        Me.UpdateDate.CFLReturn0 = ""
        Me.UpdateDate.CFLReturn1 = ""
        Me.UpdateDate.CFLReturn2 = ""
        Me.UpdateDate.CFLReturn3 = ""
        Me.UpdateDate.CFLReturn4 = ""
        Me.UpdateDate.CFLReturn5 = ""
        Me.UpdateDate.CFLReturn6 = ""
        Me.UpdateDate.CFLReturn7 = ""
        Me.UpdateDate.CFLShowLoad = False
        Me.UpdateDate.ChangeFormStatus = True
        Me.UpdateDate.ColumnKey = False
        Me.UpdateDate.ComboLine = 5
        Me.UpdateDate.CopyFromItem = ""
        Me.UpdateDate.DefaultButtonClick = False
        Me.UpdateDate.Digit = False
        Me.UpdateDate.FieldType = "D"
        Me.UpdateDate.FieldView = "UpdateDate"
        Me.UpdateDate.FormarNumber = True
        Me.UpdateDate.FormList = False
        Me.UpdateDate.KeyInsert = ""
        Me.UpdateDate.LocalDecimal = False
        Me.UpdateDate.Name = "UpdateDate"
        Me.UpdateDate.NoUpdate = ""
        Me.UpdateDate.NumberDecimal = 0
        Me.UpdateDate.OptionsColumn.ReadOnly = True
        Me.UpdateDate.ParentControl = ""
        Me.UpdateDate.RefreshSource = False
        Me.UpdateDate.Required = False
        Me.UpdateDate.SequenceName = ""
        Me.UpdateDate.ShowCalc = True
        Me.UpdateDate.ShowDataTime = True
        Me.UpdateDate.ShowOnlyTime = False
        Me.UpdateDate.SQLString = ""
        Me.UpdateDate.UpdateIfNull = ""
        Me.UpdateDate.UpdateWhenFormLock = False
        Me.UpdateDate.UpperValue = False
        Me.UpdateDate.ValidateValue = True
        Me.UpdateDate.Visible = True
        Me.UpdateDate.VisibleIndex = 18
        Me.UpdateDate.Width = 110
        '
        'sType
        '
        Me.sType.AllowInsert = True
        Me.sType.AllowUpdate = True
        Me.sType.ButtonClick = True
        Me.sType.Caption = "Loại"
        Me.sType.CFLColumnHide = ""
        Me.sType.CFLKeyField = ""
        Me.sType.CFLPage = False
        Me.sType.CFLReturn0 = ""
        Me.sType.CFLReturn1 = ""
        Me.sType.CFLReturn2 = ""
        Me.sType.CFLReturn3 = ""
        Me.sType.CFLReturn4 = ""
        Me.sType.CFLReturn5 = ""
        Me.sType.CFLReturn6 = ""
        Me.sType.CFLReturn7 = ""
        Me.sType.CFLShowLoad = False
        Me.sType.ChangeFormStatus = True
        Me.sType.ColumnKey = False
        Me.sType.ComboLine = 5
        Me.sType.CopyFromItem = ""
        Me.sType.DefaultButtonClick = False
        Me.sType.Digit = False
        Me.sType.FieldType = "C"
        Me.sType.FieldView = "sType"
        Me.sType.FormarNumber = True
        Me.sType.FormList = False
        Me.sType.KeyInsert = ""
        Me.sType.LocalDecimal = False
        Me.sType.Name = "sType"
        Me.sType.NoUpdate = ""
        Me.sType.NumberDecimal = 0
        Me.sType.OptionsColumn.ReadOnly = True
        Me.sType.ParentControl = ""
        Me.sType.RefreshSource = False
        Me.sType.Required = False
        Me.sType.SequenceName = ""
        Me.sType.ShowCalc = True
        Me.sType.ShowDataTime = False
        Me.sType.ShowOnlyTime = False
        Me.sType.SQLString = ""
        Me.sType.UpdateIfNull = ""
        Me.sType.UpdateWhenFormLock = False
        Me.sType.UpperValue = False
        Me.sType.ValidateValue = True
        Me.sType.Visible = True
        Me.sType.VisibleIndex = 19
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = "Y"
        Me.RepositoryItemCheckEdit2.ValueUnchecked = "N"
        '
        'FrmMeterGroupHist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1032, 508)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmMeterGroupHist"
        Me.ShowFormMessage = True
        Me.Text = "Lịch sử thay đổi thông tin công tơ-Nhóm bể"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents MeterId As U_TextBox.GridColumn
    Friend WithEvents MaHangHoa As U_TextBox.GridColumn
    Friend WithEvents TenHangHoa As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemButtonEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents Bexuat As U_TextBox.GridColumn
    Friend WithEvents Valid_from As U_TextBox.GridColumn
    Friend WithEvents Push_TDH As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Valid_to As U_TextBox.GridColumn
    Friend WithEvents Push_XTTD As U_TextBox.GridColumn
    Friend WithEvents User_Push_TDH As U_TextBox.GridColumn
    Friend WithEvents Date_Push_TDH As U_TextBox.GridColumn
    Friend WithEvents User_Push_XTTD As U_TextBox.GridColumn
    Friend WithEvents Date_Push_XTTD As U_TextBox.GridColumn
    Friend WithEvents TankGroup As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents TankValidfrom As U_TextBox.GridColumn
    Friend WithEvents TankValid_to As U_TextBox.GridColumn
    Friend WithEvents CreateUser As U_TextBox.GridColumn
    Friend WithEvents CreateDate As U_TextBox.GridColumn
    Friend WithEvents UpdateUser As U_TextBox.GridColumn
    Friend WithEvents UpdateDate As U_TextBox.GridColumn
    Friend WithEvents sType As U_TextBox.GridColumn
End Class
