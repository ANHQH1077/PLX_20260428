<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMeterGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMeterGroup))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.X = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
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
        Me.ID = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.MaHangHoaTDH = New U_TextBox.GridColumn()
        Me.IDLine = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton14 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton15 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton16 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton17 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton18 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.CmdSMO = New U_TextBox.U_ButtonCus()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(2, 28)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemComboBox1, Me.RepositoryItemButtonEdit2, Me.RepositoryItemButtonEdit3, Me.RepositoryItemCheckEdit1, Me.RepositoryItemButtonEdit4, Me.RepositoryItemCheckEdit2})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(1025, 418)
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.X, Me.MeterId, Me.Valid_from, Me.Valid_to, Me.Bexuat, Me.TankGroup, Me.TankValidfrom, Me.TankValid_to, Me.MaHangHoa, Me.TenHangHoa, Me.Push_TDH, Me.Push_XTTD, Me.User_Push_TDH, Me.Date_Push_TDH, Me.User_Push_XTTD, Me.Date_Push_XTTD, Me.ID, Me.CHECKUPD, Me.MaHangHoaTDH, Me.IDLine})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "MeterId"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblCongToNhomBe"
        Me.GridView1.ViewName = "tblCongToNhomBe_V"
        Me.GridView1.Where = Nothing
        '
        'X
        '
        Me.X.AllowInsert = False
        Me.X.AllowUpdate = False
        Me.X.ButtonClick = True
        Me.X.Caption = "X"
        Me.X.CFLColumnHide = ""
        Me.X.CFLKeyField = ""
        Me.X.CFLPage = False
        Me.X.CFLReturn0 = ""
        Me.X.CFLReturn1 = ""
        Me.X.CFLReturn2 = ""
        Me.X.CFLReturn3 = ""
        Me.X.CFLReturn4 = ""
        Me.X.CFLReturn5 = ""
        Me.X.CFLReturn6 = ""
        Me.X.CFLReturn7 = ""
        Me.X.CFLShowLoad = False
        Me.X.ChangeFormStatus = False
        Me.X.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.X.ColumnKey = False
        Me.X.ComboLine = 5
        Me.X.CopyFromItem = ""
        Me.X.DefaultButtonClick = False
        Me.X.Digit = False
        Me.X.FieldType = "C"
        Me.X.FieldView = "X"
        Me.X.FormarNumber = True
        Me.X.FormList = False
        Me.X.KeyInsert = ""
        Me.X.LocalDecimal = False
        Me.X.Name = "X"
        Me.X.NoUpdate = ""
        Me.X.NumberDecimal = 0
        Me.X.ParentControl = ""
        Me.X.RefreshSource = False
        Me.X.Required = False
        Me.X.SequenceName = ""
        Me.X.ShowCalc = True
        Me.X.ShowDataTime = False
        Me.X.ShowOnlyTime = False
        Me.X.SQLString = ""
        Me.X.UpdateIfNull = ""
        Me.X.UpdateWhenFormLock = False
        Me.X.UpperValue = False
        Me.X.ValidateValue = True
        Me.X.Visible = True
        Me.X.VisibleIndex = 0
        Me.X.Width = 30
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = "Y"
        Me.RepositoryItemCheckEdit2.ValueUnchecked = "N"
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
        Me.MeterId.VisibleIndex = 1
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
        Me.Valid_from.VisibleIndex = 2
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
        Me.Valid_to.VisibleIndex = 3
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
        Me.Bexuat.VisibleIndex = 4
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
        Me.TankGroup.VisibleIndex = 5
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
        Me.TankValidfrom.VisibleIndex = 6
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
        Me.TankValid_to.VisibleIndex = 7
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
        Me.MaHangHoa.VisibleIndex = 8
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
        Me.TenHangHoa.VisibleIndex = 9
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
        Me.Push_TDH.VisibleIndex = 10
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
        Me.Push_XTTD.VisibleIndex = 11
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
        Me.User_Push_TDH.VisibleIndex = 12
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
        Me.Date_Push_TDH.VisibleIndex = 13
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
        Me.User_Push_XTTD.VisibleIndex = 14
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
        Me.Date_Push_XTTD.VisibleIndex = 15
        '
        'ID
        '
        Me.ID.AllowInsert = False
        Me.ID.AllowUpdate = False
        Me.ID.ButtonClick = True
        Me.ID.Caption = "ID"
        Me.ID.CFLColumnHide = ""
        Me.ID.CFLKeyField = ""
        Me.ID.CFLPage = False
        Me.ID.CFLReturn0 = ""
        Me.ID.CFLReturn1 = ""
        Me.ID.CFLReturn2 = ""
        Me.ID.CFLReturn3 = ""
        Me.ID.CFLReturn4 = ""
        Me.ID.CFLReturn5 = ""
        Me.ID.CFLReturn6 = ""
        Me.ID.CFLReturn7 = ""
        Me.ID.CFLShowLoad = False
        Me.ID.ChangeFormStatus = True
        Me.ID.ColumnKey = False
        Me.ID.ComboLine = 5
        Me.ID.CopyFromItem = ""
        Me.ID.DefaultButtonClick = False
        Me.ID.Digit = False
        Me.ID.FieldType = "N"
        Me.ID.FieldView = "ID"
        Me.ID.FormarNumber = True
        Me.ID.FormList = False
        Me.ID.KeyInsert = ""
        Me.ID.LocalDecimal = False
        Me.ID.Name = "ID"
        Me.ID.NoUpdate = ""
        Me.ID.NumberDecimal = 0
        Me.ID.OptionsColumn.ReadOnly = True
        Me.ID.ParentControl = ""
        Me.ID.RefreshSource = False
        Me.ID.Required = False
        Me.ID.SequenceName = ""
        Me.ID.ShowCalc = True
        Me.ID.ShowDataTime = False
        Me.ID.ShowOnlyTime = False
        Me.ID.SQLString = ""
        Me.ID.UpdateIfNull = ""
        Me.ID.UpdateWhenFormLock = False
        Me.ID.UpperValue = False
        Me.ID.ValidateValue = True
        Me.ID.Visible = True
        '
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
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
        'MaHangHoaTDH
        '
        Me.MaHangHoaTDH.AllowInsert = True
        Me.MaHangHoaTDH.AllowUpdate = True
        Me.MaHangHoaTDH.ButtonClick = True
        Me.MaHangHoaTDH.Caption = "MaHangHoaTDH"
        Me.MaHangHoaTDH.CFLColumnHide = ""
        Me.MaHangHoaTDH.CFLKeyField = ""
        Me.MaHangHoaTDH.CFLPage = False
        Me.MaHangHoaTDH.CFLReturn0 = ""
        Me.MaHangHoaTDH.CFLReturn1 = ""
        Me.MaHangHoaTDH.CFLReturn2 = ""
        Me.MaHangHoaTDH.CFLReturn3 = ""
        Me.MaHangHoaTDH.CFLReturn4 = ""
        Me.MaHangHoaTDH.CFLReturn5 = ""
        Me.MaHangHoaTDH.CFLReturn6 = ""
        Me.MaHangHoaTDH.CFLReturn7 = ""
        Me.MaHangHoaTDH.CFLShowLoad = False
        Me.MaHangHoaTDH.ChangeFormStatus = True
        Me.MaHangHoaTDH.ColumnKey = False
        Me.MaHangHoaTDH.ComboLine = 5
        Me.MaHangHoaTDH.CopyFromItem = ""
        Me.MaHangHoaTDH.DefaultButtonClick = False
        Me.MaHangHoaTDH.Digit = False
        Me.MaHangHoaTDH.FieldType = "C"
        Me.MaHangHoaTDH.FieldView = "MaHangHoaTDH"
        Me.MaHangHoaTDH.FormarNumber = True
        Me.MaHangHoaTDH.FormList = False
        Me.MaHangHoaTDH.KeyInsert = ""
        Me.MaHangHoaTDH.LocalDecimal = False
        Me.MaHangHoaTDH.Name = "MaHangHoaTDH"
        Me.MaHangHoaTDH.NoUpdate = ""
        Me.MaHangHoaTDH.NumberDecimal = 0
        Me.MaHangHoaTDH.OptionsColumn.ReadOnly = True
        Me.MaHangHoaTDH.ParentControl = ""
        Me.MaHangHoaTDH.RefreshSource = False
        Me.MaHangHoaTDH.Required = False
        Me.MaHangHoaTDH.SequenceName = ""
        Me.MaHangHoaTDH.ShowCalc = True
        Me.MaHangHoaTDH.ShowDataTime = False
        Me.MaHangHoaTDH.ShowOnlyTime = False
        Me.MaHangHoaTDH.SQLString = ""
        Me.MaHangHoaTDH.UpdateIfNull = ""
        Me.MaHangHoaTDH.UpdateWhenFormLock = False
        Me.MaHangHoaTDH.UpperValue = False
        Me.MaHangHoaTDH.ValidateValue = True
        Me.MaHangHoaTDH.Visible = True
        '
        'IDLine
        '
        Me.IDLine.AllowInsert = True
        Me.IDLine.AllowUpdate = True
        Me.IDLine.ButtonClick = True
        Me.IDLine.Caption = "IDLine"
        Me.IDLine.CFLColumnHide = ""
        Me.IDLine.CFLKeyField = ""
        Me.IDLine.CFLPage = False
        Me.IDLine.CFLReturn0 = ""
        Me.IDLine.CFLReturn1 = ""
        Me.IDLine.CFLReturn2 = ""
        Me.IDLine.CFLReturn3 = ""
        Me.IDLine.CFLReturn4 = ""
        Me.IDLine.CFLReturn5 = ""
        Me.IDLine.CFLReturn6 = ""
        Me.IDLine.CFLReturn7 = ""
        Me.IDLine.CFLShowLoad = False
        Me.IDLine.ChangeFormStatus = True
        Me.IDLine.ColumnKey = False
        Me.IDLine.ComboLine = 5
        Me.IDLine.CopyFromItem = ""
        Me.IDLine.DefaultButtonClick = False
        Me.IDLine.Digit = False
        Me.IDLine.FieldType = "N"
        Me.IDLine.FieldView = "IDLine"
        Me.IDLine.FormarNumber = True
        Me.IDLine.FormList = False
        Me.IDLine.KeyInsert = ""
        Me.IDLine.LocalDecimal = False
        Me.IDLine.Name = "IDLine"
        Me.IDLine.NoUpdate = ""
        Me.IDLine.NumberDecimal = 0
        Me.IDLine.ParentControl = ""
        Me.IDLine.RefreshSource = False
        Me.IDLine.Required = False
        Me.IDLine.SequenceName = ""
        Me.IDLine.ShowCalc = True
        Me.IDLine.ShowDataTime = False
        Me.IDLine.ShowOnlyTime = False
        Me.IDLine.SQLString = ""
        Me.IDLine.UpdateIfNull = ""
        Me.IDLine.UpdateWhenFormLock = False
        Me.IDLine.UpperValue = False
        Me.IDLine.ValidateValue = True
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
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripButton7, Me.ToolStripButton8, Me.ToolStripButton9, Me.ToolStripButton10, Me.ToolStripButton11, Me.ToolStripButton12, Me.ToolStripButton13, Me.ToolStripButton14, Me.ToolStripButton15, Me.ToolStripButton16, Me.ToolStripButton17, Me.ToolStripButton18, Me.ToolStripButton3})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1032, 28)
        Me.ToolStrip2.TabIndex = 470
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
        Me.ToolStripButton1.Visible = False
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(195, 25)
        Me.ToolStripButton2.Text = "&3. Đồng bộ TĐH và Xếp tài"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(197, 25)
        Me.ToolStripButton4.Text = "&4. Lịch sử đồng bộ TĐH/XT"
        Me.ToolStripButton4.Visible = False
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 25)
        Me.ToolStripButton5.Text = "ToolStripButton5"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 25)
        Me.ToolStripButton6.Text = "ToolStripButton6"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 25)
        Me.ToolStripButton7.Text = "ToolStripButton7"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(23, 25)
        Me.ToolStripButton8.Text = "ToolStripButton8"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(23, 25)
        Me.ToolStripButton9.Text = "ToolStripButton9"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(23, 25)
        Me.ToolStripButton10.Text = "ToolStripButton10"
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
        Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Size = New System.Drawing.Size(23, 25)
        Me.ToolStripButton11.Text = "ToolStripButton11"
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
        Me.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.Size = New System.Drawing.Size(23, 25)
        Me.ToolStripButton12.Text = "ToolStripButton12"
        '
        'ToolStripButton13
        '
        Me.ToolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButton13.Image = CType(resources.GetObject("ToolStripButton13.Image"), System.Drawing.Image)
        Me.ToolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.Size = New System.Drawing.Size(23, 25)
        Me.ToolStripButton13.Text = "ToolStripButton13"
        '
        'ToolStripButton14
        '
        Me.ToolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButton14.Image = CType(resources.GetObject("ToolStripButton14.Image"), System.Drawing.Image)
        Me.ToolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton14.Name = "ToolStripButton14"
        Me.ToolStripButton14.Size = New System.Drawing.Size(23, 25)
        Me.ToolStripButton14.Text = "ToolStripButton14"
        '
        'ToolStripButton15
        '
        Me.ToolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButton15.Image = CType(resources.GetObject("ToolStripButton15.Image"), System.Drawing.Image)
        Me.ToolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton15.Name = "ToolStripButton15"
        Me.ToolStripButton15.Size = New System.Drawing.Size(23, 25)
        Me.ToolStripButton15.Text = "ToolStripButton15"
        '
        'ToolStripButton16
        '
        Me.ToolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButton16.Image = CType(resources.GetObject("ToolStripButton16.Image"), System.Drawing.Image)
        Me.ToolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton16.Name = "ToolStripButton16"
        Me.ToolStripButton16.Size = New System.Drawing.Size(23, 25)
        Me.ToolStripButton16.Text = "ToolStripButton16"
        '
        'ToolStripButton17
        '
        Me.ToolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButton17.Image = CType(resources.GetObject("ToolStripButton17.Image"), System.Drawing.Image)
        Me.ToolStripButton17.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton17.Name = "ToolStripButton17"
        Me.ToolStripButton17.Size = New System.Drawing.Size(23, 25)
        Me.ToolStripButton17.Text = "ToolStripButton17"
        '
        'ToolStripButton18
        '
        Me.ToolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.ToolStripButton18.Image = CType(resources.GetObject("ToolStripButton18.Image"), System.Drawing.Image)
        Me.ToolStripButton18.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton18.Name = "ToolStripButton18"
        Me.ToolStripButton18.Size = New System.Drawing.Size(23, 25)
        Me.ToolStripButton18.Text = "ToolStripButton18"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.Navy
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(138, 25)
        Me.ToolStripButton3.Text = "&5. Lịch sử thay đổi"
        Me.ToolStripButton3.Visible = False
        '
        'CmdSMO
        '
        Me.CmdSMO.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSMO.Appearance.Options.UseFont = True
        Me.CmdSMO.DefaultUpdate = True
        Me.CmdSMO.EnableWhenFormLock = False
        Me.CmdSMO.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.CmdSMO.Location = New System.Drawing.Point(12, 452)
        Me.CmdSMO.Name = "CmdSMO"
        Me.CmdSMO.Size = New System.Drawing.Size(101, 27)
        Me.CmdSMO.TabIndex = 541
        Me.CmdSMO.TabStop = False
        Me.CmdSMO.Text = "Chọn tất cả"
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.U_ButtonCus1.Location = New System.Drawing.Point(140, 452)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(101, 27)
        Me.U_ButtonCus1.TabIndex = 542
        Me.U_ButtonCus1.TabStop = False
        Me.U_ButtonCus1.Text = "Hủy chọn"
        '
        'FrmMeterGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1032, 508)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.CmdSMO)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmMeterGroup"
        Me.ShowFormMessage = True
        Me.Text = "Thông tin công tơ-Nhóm bể"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.CmdSMO, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemButtonEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents Bexuat As U_TextBox.GridColumn
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Valid_from As U_TextBox.GridColumn
    Friend WithEvents Push_TDH As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Valid_to As U_TextBox.GridColumn
    Friend WithEvents Push_XTTD As U_TextBox.GridColumn
    Friend WithEvents User_Push_TDH As U_TextBox.GridColumn
    Friend WithEvents Date_Push_TDH As U_TextBox.GridColumn
    Friend WithEvents User_Push_XTTD As U_TextBox.GridColumn
    Friend WithEvents Date_Push_XTTD As U_TextBox.GridColumn
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents TankGroup As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents X As U_TextBox.GridColumn
    Friend WithEvents MaHangHoaTDH As U_TextBox.GridColumn
    Friend WithEvents TankValidfrom As U_TextBox.GridColumn
    Friend WithEvents TankValid_to As U_TextBox.GridColumn
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents CmdSMO As U_TextBox.U_ButtonCus
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton13 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton14 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton15 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton16 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton17 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton18 As System.Windows.Forms.ToolStripButton
    Friend WithEvents IDLine As U_TextBox.GridColumn
End Class
