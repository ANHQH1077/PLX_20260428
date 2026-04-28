<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMeterGroupTDH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMeterGroupTDH))
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
        Me.CreateUser = New U_TextBox.GridColumn()
        Me.UpdateUser = New U_TextBox.GridColumn()
        Me.Date_Push_XTTD = New U_TextBox.GridColumn()
        Me.User_Push_XTTD = New U_TextBox.GridColumn()
        Me.Push_XTTD = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Push_TDH = New U_TextBox.GridColumn()
        Me.IDLINE = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
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
        Me.ToolStrip2.SuspendLayout()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(2, 31)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemComboBox1, Me.RepositoryItemButtonEdit2, Me.RepositoryItemButtonEdit3, Me.RepositoryItemCheckEdit1, Me.RepositoryItemButtonEdit4, Me.RepositoryItemCheckEdit2})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(1164, 453)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MeterId, Me.Valid_from, Me.Valid_to, Me.Bexuat, Me.TankGroup, Me.TankValidfrom, Me.TankValid_to, Me.MaHangHoa, Me.TenHangHoa, Me.CreateUser, Me.UpdateUser, Me.Date_Push_XTTD, Me.User_Push_XTTD, Me.Push_XTTD, Me.Push_TDH, Me.IDLINE, Me.CHECKUPD})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "MeterId, Valid_from desc"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblCongToNhomBe_TDH"
        Me.GridView1.ViewName = "tblCongToNhomBe_TDH_V"
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
        Me.MeterId.ColumnKey = False
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
        Me.TenHangHoa.Width = 130
        '
        'CreateUser
        '
        Me.CreateUser.AllowInsert = True
        Me.CreateUser.AllowUpdate = True
        Me.CreateUser.ButtonClick = True
        Me.CreateUser.Caption = "CreateUser"
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
        '
        'UpdateUser
        '
        Me.UpdateUser.AllowInsert = True
        Me.UpdateUser.AllowUpdate = True
        Me.UpdateUser.ButtonClick = True
        Me.UpdateUser.Caption = "UpdateUser"
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
        Me.UpdateUser.Width = 110
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
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Y"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "N"
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
        '
        'IDLINE
        '
        Me.IDLINE.AllowInsert = False
        Me.IDLINE.AllowUpdate = False
        Me.IDLINE.ButtonClick = True
        Me.IDLINE.Caption = "IDLINE"
        Me.IDLINE.CFLColumnHide = ""
        Me.IDLINE.CFLKeyField = ""
        Me.IDLINE.CFLPage = False
        Me.IDLINE.CFLReturn0 = ""
        Me.IDLINE.CFLReturn1 = ""
        Me.IDLINE.CFLReturn2 = ""
        Me.IDLINE.CFLReturn3 = ""
        Me.IDLINE.CFLReturn4 = ""
        Me.IDLINE.CFLReturn5 = ""
        Me.IDLINE.CFLReturn6 = ""
        Me.IDLINE.CFLReturn7 = ""
        Me.IDLINE.CFLShowLoad = False
        Me.IDLINE.ChangeFormStatus = True
        Me.IDLINE.ColumnKey = True
        Me.IDLINE.ComboLine = 5
        Me.IDLINE.CopyFromItem = ""
        Me.IDLINE.DefaultButtonClick = False
        Me.IDLINE.Digit = False
        Me.IDLINE.FieldType = "N"
        Me.IDLINE.FieldView = "IDLINE"
        Me.IDLINE.FormarNumber = True
        Me.IDLINE.FormList = False
        Me.IDLINE.KeyInsert = ""
        Me.IDLINE.LocalDecimal = False
        Me.IDLINE.Name = "IDLINE"
        Me.IDLINE.NoUpdate = ""
        Me.IDLINE.NumberDecimal = 0
        Me.IDLINE.OptionsColumn.ReadOnly = True
        Me.IDLINE.ParentControl = ""
        Me.IDLINE.RefreshSource = False
        Me.IDLINE.Required = False
        Me.IDLINE.SequenceName = ""
        Me.IDLINE.ShowCalc = True
        Me.IDLINE.ShowDataTime = True
        Me.IDLINE.ShowOnlyTime = False
        Me.IDLINE.SQLString = ""
        Me.IDLINE.UpdateIfNull = ""
        Me.IDLINE.UpdateWhenFormLock = False
        Me.IDLINE.UpperValue = False
        Me.IDLINE.ValidateValue = True
        Me.IDLINE.Visible = True
        Me.IDLINE.Width = 110
        '
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = False
        Me.CHECKUPD.AllowUpdate = False
        Me.CHECKUPD.ButtonClick = True
        Me.CHECKUPD.Caption = "CHECKUPD"
        Me.CHECKUPD.CFLColumnHide = ""
        Me.CHECKUPD.CFLKeyField = ""
        Me.CHECKUPD.CFLPage = False
        Me.CHECKUPD.CFLReturn0 = ""
        Me.CHECKUPD.CFLReturn1 = ""
        Me.CHECKUPD.CFLReturn2 = ""
        Me.CHECKUPD.CFLReturn3 = ""
        Me.CHECKUPD.CFLReturn4 = ""
        Me.CHECKUPD.CFLReturn5 = ""
        Me.CHECKUPD.CFLReturn6 = ""
        Me.CHECKUPD.CFLReturn7 = ""
        Me.CHECKUPD.CFLShowLoad = False
        Me.CHECKUPD.ChangeFormStatus = True
        Me.CHECKUPD.ColumnKey = False
        Me.CHECKUPD.ComboLine = 5
        Me.CHECKUPD.CopyFromItem = ""
        Me.CHECKUPD.DefaultButtonClick = False
        Me.CHECKUPD.Digit = False
        Me.CHECKUPD.FieldType = "C"
        Me.CHECKUPD.FieldView = "CHECKUPD"
        Me.CHECKUPD.FormarNumber = True
        Me.CHECKUPD.FormList = False
        Me.CHECKUPD.KeyInsert = ""
        Me.CHECKUPD.LocalDecimal = False
        Me.CHECKUPD.Name = "CHECKUPD"
        Me.CHECKUPD.NoUpdate = ""
        Me.CHECKUPD.NumberDecimal = 0
        Me.CHECKUPD.OptionsColumn.ReadOnly = True
        Me.CHECKUPD.ParentControl = ""
        Me.CHECKUPD.RefreshSource = False
        Me.CHECKUPD.Required = False
        Me.CHECKUPD.SequenceName = ""
        Me.CHECKUPD.ShowCalc = True
        Me.CHECKUPD.ShowDataTime = False
        Me.CHECKUPD.ShowOnlyTime = False
        Me.CHECKUPD.SQLString = ""
        Me.CHECKUPD.UpdateIfNull = ""
        Me.CHECKUPD.UpdateWhenFormLock = False
        Me.CHECKUPD.UpperValue = False
        Me.CHECKUPD.ValidateValue = True
        Me.CHECKUPD.Visible = True
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
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton3})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1169, 28)
        Me.ToolStrip2.TabIndex = 471
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(72, 25)
        Me.ToolStripButton1.Text = "&2. Lưu"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(195, 25)
        Me.ToolStripButton3.Text = "&3. Đồng bộ TĐH và Xếp tài"
        '
        'FrmMeterGroupTDH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 508)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmMeterGroupTDH"
        Me.ShowFormMessage = True
        Me.Text = "Lịch sử đồng bộ Công tơ-Nhóm bể"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
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
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
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
    Friend WithEvents UpdateUser As U_TextBox.GridColumn
    Friend WithEvents User_Push_XTTD As U_TextBox.GridColumn
    Friend WithEvents Date_Push_XTTD As U_TextBox.GridColumn
    Friend WithEvents TankGroup As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents TankValidfrom As U_TextBox.GridColumn
    Friend WithEvents TankValid_to As U_TextBox.GridColumn
    Friend WithEvents CreateUser As U_TextBox.GridColumn
    Friend WithEvents IDLINE As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
End Class
