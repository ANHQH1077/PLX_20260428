<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTankActiveNew
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTankActiveNew))
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.U_ButtonCus2 = New U_TextBox.U_ButtonCus(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.TrueDBGrid2 = New U_TextBox.TrueDBGrid()
        Me.GridView2 = New U_TextBox.GridView()
        Me.GridColumn1 = New U_TextBox.GridColumn()
        Me.GridColumn2 = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridColumn3 = New U_TextBox.GridColumn()
        Me.GridColumn4 = New U_TextBox.GridColumn()
        Me.GridColumn5 = New U_TextBox.GridColumn()
        Me.GridColumn6 = New U_TextBox.GridColumn()
        Me.GridColumn7 = New U_TextBox.GridColumn()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.Name_nd = New U_TextBox.GridColumn()
        Me.Dens_nd = New U_TextBox.GridColumn()
        Me.Product_nd = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.TenHangHoa = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.TrueDBGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.Image = CType(resources.GetObject("U_ButtonCus1.Image"), System.Drawing.Image)
        Me.U_ButtonCus1.Location = New System.Drawing.Point(408, 234)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(40, 33)
        Me.U_ButtonCus1.TabIndex = 2
        '
        'U_ButtonCus2
        '
        Me.U_ButtonCus2.DefaultUpdate = True
        Me.U_ButtonCus2.Image = CType(resources.GetObject("U_ButtonCus2.Image"), System.Drawing.Image)
        Me.U_ButtonCus2.Location = New System.Drawing.Point(408, 286)
        Me.U_ButtonCus2.Name = "U_ButtonCus2"
        Me.U_ButtonCus2.Size = New System.Drawing.Size(40, 33)
        Me.U_ButtonCus2.TabIndex = 3
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(963, 25)
        Me.ToolStrip2.TabIndex = 472
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton1.Text = "&2. Lưu"
        '
        'TrueDBGrid2
        '
        Me.TrueDBGrid2.DefaultRemove = True
        Me.TrueDBGrid2.Location = New System.Drawing.Point(454, 44)
        Me.TrueDBGrid2.MainView = Me.GridView2
        Me.TrueDBGrid2.Name = "TrueDBGrid2"
        Me.TrueDBGrid2.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit2})
        Me.TrueDBGrid2.Size = New System.Drawing.Size(505, 520)
        Me.TrueDBGrid2.TabIndex = 474
        Me.TrueDBGrid2.UseEmbeddedNavigator = True
        Me.TrueDBGrid2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.AllowInsert = True
        Me.GridView2.ColumnAutoWidth = False
        Me.GridView2.ColumnKey = ""
        Me.GridView2.ColumnKeyIns = True
        Me.GridView2.ColumnKeyType = "N"
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GridView2.CompanyCode = ""
        Me.GridView2.DefaultRemove = True
        Me.GridView2.GetB1 = False
        Me.GridView2.GridControl = Me.TrueDBGrid2
        Me.GridView2.LastQuery = ""
        Me.GridView2.Name = "GridView2"
        Me.GridView2.ObjectChild = False
        Me.GridView2.OptionsFind.AlwaysVisible = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        Me.GridView2.OrderBy = "Name_nd"
        Me.GridView2.ParentItem = Nothing
        Me.GridView2.RowNumber = ""
        Me.GridView2.TableName = "tblTankActive"
        Me.GridView2.ViewName = "FPT_tblTankActive_V"
        Me.GridView2.Where = Nothing
        '
        'GridColumn1
        '
        Me.GridColumn1.AllowInsert = True
        Me.GridColumn1.AllowUpdate = False
        Me.GridColumn1.Caption = "Date_nd"
        Me.GridColumn1.CFLColumnHide = ""
        Me.GridColumn1.CFLKeyField = ""
        Me.GridColumn1.CFLPage = False
        Me.GridColumn1.CFLReturn0 = ""
        Me.GridColumn1.CFLReturn1 = ""
        Me.GridColumn1.CFLReturn2 = ""
        Me.GridColumn1.CFLReturn3 = ""
        Me.GridColumn1.CFLReturn4 = ""
        Me.GridColumn1.CFLShowLoad = False
        Me.GridColumn1.ChangeFormStatus = True
        Me.GridColumn1.ColumnKey = False
        Me.GridColumn1.ComboLine = 5
        Me.GridColumn1.CopyFromItem = ""
        Me.GridColumn1.DefaultButtonClick = False
        Me.GridColumn1.Digit = False
        Me.GridColumn1.FieldType = "D"
        Me.GridColumn1.FieldView = "Date_nd"
        Me.GridColumn1.FormList = False
        Me.GridColumn1.KeyInsert = ""
        Me.GridColumn1.LocalDecimal = False
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.NoUpdate = ""
        Me.GridColumn1.NumberDecimal = 0
        Me.GridColumn1.ParentControl = ""
        Me.GridColumn1.RefreshSource = False
        Me.GridColumn1.Required = False
        Me.GridColumn1.ShowDataTime = False
        Me.GridColumn1.SQLString = ""
        Me.GridColumn1.UpdateIfNull = ""
        Me.GridColumn1.UpdateWhenFormLock = False
        Me.GridColumn1.ValidateValue = True
        Me.GridColumn1.Visible = True
        '
        'GridColumn2
        '
        Me.GridColumn2.AllowInsert = True
        Me.GridColumn2.AllowUpdate = True
        Me.GridColumn2.Caption = "Bể xuất"
        Me.GridColumn2.CFLColumnHide = ""
        Me.GridColumn2.CFLKeyField = "Name_nd"
        Me.GridColumn2.CFLPage = False
        Me.GridColumn2.CFLReturn0 = ""
        Me.GridColumn2.CFLReturn1 = "Dens_nd"
        Me.GridColumn2.CFLReturn2 = "Product_nd"
        Me.GridColumn2.CFLReturn3 = ""
        Me.GridColumn2.CFLReturn4 = ""
        Me.GridColumn2.CFLShowLoad = True
        Me.GridColumn2.ChangeFormStatus = True
        Me.GridColumn2.ColumnEdit = Me.RepositoryItemButtonEdit2
        Me.GridColumn2.ColumnKey = False
        Me.GridColumn2.ComboLine = 5
        Me.GridColumn2.CopyFromItem = ""
        Me.GridColumn2.DefaultButtonClick = False
        Me.GridColumn2.Digit = False
        Me.GridColumn2.FieldType = "C"
        Me.GridColumn2.FieldView = "Name_nd"
        Me.GridColumn2.FormList = False
        Me.GridColumn2.KeyInsert = ""
        Me.GridColumn2.LocalDecimal = False
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.NoUpdate = ""
        Me.GridColumn2.NumberDecimal = 0
        Me.GridColumn2.ParentControl = ""
        Me.GridColumn2.RefreshSource = False
        Me.GridColumn2.Required = False
        Me.GridColumn2.ShowDataTime = False
        Me.GridColumn2.SQLString = "select Name_nd , Dens_nd ,Product_nd  from tblTank"
        Me.GridColumn2.UpdateIfNull = ""
        Me.GridColumn2.UpdateWhenFormLock = False
        Me.GridColumn2.ValidateValue = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        '
        'GridColumn3
        '
        Me.GridColumn3.AllowInsert = True
        Me.GridColumn3.AllowUpdate = True
        Me.GridColumn3.Caption = "Tỷ trọng"
        Me.GridColumn3.CFLColumnHide = ""
        Me.GridColumn3.CFLKeyField = ""
        Me.GridColumn3.CFLPage = False
        Me.GridColumn3.CFLReturn0 = ""
        Me.GridColumn3.CFLReturn1 = ""
        Me.GridColumn3.CFLReturn2 = ""
        Me.GridColumn3.CFLReturn3 = ""
        Me.GridColumn3.CFLReturn4 = ""
        Me.GridColumn3.CFLShowLoad = False
        Me.GridColumn3.ChangeFormStatus = True
        Me.GridColumn3.ColumnKey = False
        Me.GridColumn3.ComboLine = 5
        Me.GridColumn3.CopyFromItem = ""
        Me.GridColumn3.DefaultButtonClick = False
        Me.GridColumn3.Digit = True
        Me.GridColumn3.FieldType = "N"
        Me.GridColumn3.FieldView = "Dens_nd"
        Me.GridColumn3.FormList = False
        Me.GridColumn3.KeyInsert = ""
        Me.GridColumn3.LocalDecimal = True
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.NoUpdate = ""
        Me.GridColumn3.NumberDecimal = 3
        Me.GridColumn3.ParentControl = ""
        Me.GridColumn3.RefreshSource = False
        Me.GridColumn3.Required = False
        Me.GridColumn3.ShowDataTime = False
        Me.GridColumn3.SQLString = ""
        Me.GridColumn3.UpdateIfNull = ""
        Me.GridColumn3.UpdateWhenFormLock = False
        Me.GridColumn3.ValidateValue = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.AllowInsert = True
        Me.GridColumn4.AllowUpdate = True
        Me.GridColumn4.Caption = "Mã hàng hóa"
        Me.GridColumn4.CFLColumnHide = ""
        Me.GridColumn4.CFLKeyField = ""
        Me.GridColumn4.CFLPage = False
        Me.GridColumn4.CFLReturn0 = ""
        Me.GridColumn4.CFLReturn1 = ""
        Me.GridColumn4.CFLReturn2 = ""
        Me.GridColumn4.CFLReturn3 = ""
        Me.GridColumn4.CFLReturn4 = ""
        Me.GridColumn4.CFLShowLoad = False
        Me.GridColumn4.ChangeFormStatus = True
        Me.GridColumn4.ColumnKey = False
        Me.GridColumn4.ComboLine = 5
        Me.GridColumn4.CopyFromItem = ""
        Me.GridColumn4.DefaultButtonClick = False
        Me.GridColumn4.Digit = False
        Me.GridColumn4.FieldType = "C"
        Me.GridColumn4.FieldView = "Product_nd"
        Me.GridColumn4.FormList = False
        Me.GridColumn4.KeyInsert = ""
        Me.GridColumn4.LocalDecimal = False
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.NoUpdate = ""
        Me.GridColumn4.NumberDecimal = 0
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.ParentControl = ""
        Me.GridColumn4.RefreshSource = False
        Me.GridColumn4.Required = False
        Me.GridColumn4.ShowDataTime = False
        Me.GridColumn4.SQLString = ""
        Me.GridColumn4.UpdateIfNull = ""
        Me.GridColumn4.UpdateWhenFormLock = False
        Me.GridColumn4.ValidateValue = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.AllowInsert = True
        Me.GridColumn5.AllowUpdate = True
        Me.GridColumn5.Caption = "Tên hàng hóa"
        Me.GridColumn5.CFLColumnHide = ""
        Me.GridColumn5.CFLKeyField = ""
        Me.GridColumn5.CFLPage = False
        Me.GridColumn5.CFLReturn0 = ""
        Me.GridColumn5.CFLReturn1 = ""
        Me.GridColumn5.CFLReturn2 = ""
        Me.GridColumn5.CFLReturn3 = ""
        Me.GridColumn5.CFLReturn4 = ""
        Me.GridColumn5.CFLShowLoad = False
        Me.GridColumn5.ChangeFormStatus = True
        Me.GridColumn5.ColumnKey = False
        Me.GridColumn5.ComboLine = 5
        Me.GridColumn5.CopyFromItem = ""
        Me.GridColumn5.DefaultButtonClick = False
        Me.GridColumn5.Digit = False
        Me.GridColumn5.FieldType = "C"
        Me.GridColumn5.FieldView = "TenHangHoa"
        Me.GridColumn5.FormList = False
        Me.GridColumn5.KeyInsert = ""
        Me.GridColumn5.LocalDecimal = False
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.NoUpdate = ""
        Me.GridColumn5.NumberDecimal = 0
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.ParentControl = ""
        Me.GridColumn5.RefreshSource = False
        Me.GridColumn5.Required = False
        Me.GridColumn5.ShowDataTime = False
        Me.GridColumn5.SQLString = ""
        Me.GridColumn5.UpdateIfNull = ""
        Me.GridColumn5.UpdateWhenFormLock = False
        Me.GridColumn5.ValidateValue = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GridColumn6
        '
        Me.GridColumn6.AllowInsert = True
        Me.GridColumn6.AllowUpdate = True
        Me.GridColumn6.Caption = "CHECKUPD"
        Me.GridColumn6.CFLColumnHide = ""
        Me.GridColumn6.CFLKeyField = ""
        Me.GridColumn6.CFLPage = False
        Me.GridColumn6.CFLReturn0 = ""
        Me.GridColumn6.CFLReturn1 = ""
        Me.GridColumn6.CFLReturn2 = ""
        Me.GridColumn6.CFLReturn3 = ""
        Me.GridColumn6.CFLReturn4 = ""
        Me.GridColumn6.CFLShowLoad = False
        Me.GridColumn6.ChangeFormStatus = True
        Me.GridColumn6.ColumnKey = False
        Me.GridColumn6.ComboLine = 5
        Me.GridColumn6.CopyFromItem = ""
        Me.GridColumn6.DefaultButtonClick = False
        Me.GridColumn6.Digit = False
        Me.GridColumn6.FieldType = "C"
        Me.GridColumn6.FieldView = "CHECKUPD"
        Me.GridColumn6.FormList = False
        Me.GridColumn6.KeyInsert = ""
        Me.GridColumn6.LocalDecimal = False
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.NoUpdate = ""
        Me.GridColumn6.NumberDecimal = 0
        Me.GridColumn6.ParentControl = ""
        Me.GridColumn6.RefreshSource = False
        Me.GridColumn6.Required = False
        Me.GridColumn6.ShowDataTime = False
        Me.GridColumn6.SQLString = ""
        Me.GridColumn6.UpdateIfNull = ""
        Me.GridColumn6.UpdateWhenFormLock = False
        Me.GridColumn6.ValidateValue = True
        Me.GridColumn6.Visible = True
        '
        'GridColumn7
        '
        Me.GridColumn7.AllowInsert = False
        Me.GridColumn7.AllowUpdate = False
        Me.GridColumn7.Caption = "ID"
        Me.GridColumn7.CFLColumnHide = ""
        Me.GridColumn7.CFLKeyField = ""
        Me.GridColumn7.CFLPage = False
        Me.GridColumn7.CFLReturn0 = ""
        Me.GridColumn7.CFLReturn1 = ""
        Me.GridColumn7.CFLReturn2 = ""
        Me.GridColumn7.CFLReturn3 = ""
        Me.GridColumn7.CFLReturn4 = ""
        Me.GridColumn7.CFLShowLoad = False
        Me.GridColumn7.ChangeFormStatus = True
        Me.GridColumn7.ColumnKey = True
        Me.GridColumn7.ComboLine = 5
        Me.GridColumn7.CopyFromItem = ""
        Me.GridColumn7.DefaultButtonClick = False
        Me.GridColumn7.Digit = False
        Me.GridColumn7.FieldType = "N"
        Me.GridColumn7.FieldView = "ID"
        Me.GridColumn7.FormList = False
        Me.GridColumn7.KeyInsert = ""
        Me.GridColumn7.LocalDecimal = False
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.NoUpdate = ""
        Me.GridColumn7.NumberDecimal = 0
        Me.GridColumn7.ParentControl = ""
        Me.GridColumn7.RefreshSource = False
        Me.GridColumn7.Required = False
        Me.GridColumn7.ShowDataTime = False
        Me.GridColumn7.SQLString = ""
        Me.GridColumn7.UpdateIfNull = ""
        Me.GridColumn7.UpdateWhenFormLock = False
        Me.GridColumn7.ValidateValue = True
        Me.GridColumn7.Visible = True
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 44)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit3, Me.RepositoryItemButtonEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(399, 520)
        Me.TrueDBGrid1.TabIndex = 475
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = False
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Name_nd, Me.Dens_nd, Me.Product_nd, Me.TenHangHoa, Me.CHECKUPD})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "Name_nd"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblTank"
        Me.GridView1.ViewName = "FPT_tblTank_V"
        Me.GridView1.Where = Nothing
        '
        'Name_nd
        '
        Me.Name_nd.AllowInsert = True
        Me.Name_nd.AllowUpdate = True
        Me.Name_nd.Caption = "Mã bể"
        Me.Name_nd.CFLColumnHide = ""
        Me.Name_nd.CFLKeyField = ""
        Me.Name_nd.CFLPage = False
        Me.Name_nd.CFLReturn0 = ""
        Me.Name_nd.CFLReturn1 = ""
        Me.Name_nd.CFLReturn2 = ""
        Me.Name_nd.CFLReturn3 = ""
        Me.Name_nd.CFLReturn4 = ""
        Me.Name_nd.CFLShowLoad = False
        Me.Name_nd.ChangeFormStatus = True
        Me.Name_nd.ColumnKey = True
        Me.Name_nd.ComboLine = 5
        Me.Name_nd.CopyFromItem = ""
        Me.Name_nd.DefaultButtonClick = False
        Me.Name_nd.Digit = False
        Me.Name_nd.FieldType = "C"
        Me.Name_nd.FieldView = "Name_nd"
        Me.Name_nd.FormList = False
        Me.Name_nd.KeyInsert = ""
        Me.Name_nd.LocalDecimal = False
        Me.Name_nd.Name = "Name_nd"
        Me.Name_nd.NoUpdate = ""
        Me.Name_nd.NumberDecimal = 0
        Me.Name_nd.ParentControl = ""
        Me.Name_nd.RefreshSource = False
        Me.Name_nd.Required = True
        Me.Name_nd.ShowDataTime = False
        Me.Name_nd.SQLString = ""
        Me.Name_nd.UpdateIfNull = ""
        Me.Name_nd.UpdateWhenFormLock = False
        Me.Name_nd.ValidateValue = True
        Me.Name_nd.Visible = True
        Me.Name_nd.VisibleIndex = 0
        '
        'Dens_nd
        '
        Me.Dens_nd.AllowInsert = True
        Me.Dens_nd.AllowUpdate = True
        Me.Dens_nd.Caption = "Tỷ trọng"
        Me.Dens_nd.CFLColumnHide = ""
        Me.Dens_nd.CFLKeyField = ""
        Me.Dens_nd.CFLPage = False
        Me.Dens_nd.CFLReturn0 = ""
        Me.Dens_nd.CFLReturn1 = ""
        Me.Dens_nd.CFLReturn2 = ""
        Me.Dens_nd.CFLReturn3 = ""
        Me.Dens_nd.CFLReturn4 = ""
        Me.Dens_nd.CFLShowLoad = False
        Me.Dens_nd.ChangeFormStatus = True
        Me.Dens_nd.ColumnKey = False
        Me.Dens_nd.ComboLine = 5
        Me.Dens_nd.CopyFromItem = ""
        Me.Dens_nd.DefaultButtonClick = False
        Me.Dens_nd.Digit = True
        Me.Dens_nd.FieldType = "N"
        Me.Dens_nd.FieldView = "Dens_nd"
        Me.Dens_nd.FormList = False
        Me.Dens_nd.KeyInsert = ""
        Me.Dens_nd.LocalDecimal = False
        Me.Dens_nd.Name = "Dens_nd"
        Me.Dens_nd.NoUpdate = ""
        Me.Dens_nd.NumberDecimal = 0
        Me.Dens_nd.ParentControl = ""
        Me.Dens_nd.RefreshSource = False
        Me.Dens_nd.Required = True
        Me.Dens_nd.ShowDataTime = False
        Me.Dens_nd.SQLString = ""
        Me.Dens_nd.UpdateIfNull = ""
        Me.Dens_nd.UpdateWhenFormLock = False
        Me.Dens_nd.ValidateValue = True
        Me.Dens_nd.Visible = True
        Me.Dens_nd.VisibleIndex = 1
        '
        'Product_nd
        '
        Me.Product_nd.AllowInsert = True
        Me.Product_nd.AllowUpdate = True
        Me.Product_nd.Caption = "Product_nd"
        Me.Product_nd.CFLColumnHide = ""
        Me.Product_nd.CFLKeyField = "MaHangHoa"
        Me.Product_nd.CFLPage = False
        Me.Product_nd.CFLReturn0 = ""
        Me.Product_nd.CFLReturn1 = "TenHangHoa"
        Me.Product_nd.CFLReturn2 = ""
        Me.Product_nd.CFLReturn3 = ""
        Me.Product_nd.CFLReturn4 = ""
        Me.Product_nd.CFLShowLoad = False
        Me.Product_nd.ChangeFormStatus = True
        Me.Product_nd.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.Product_nd.ColumnKey = False
        Me.Product_nd.ComboLine = 5
        Me.Product_nd.CopyFromItem = ""
        Me.Product_nd.DefaultButtonClick = False
        Me.Product_nd.Digit = False
        Me.Product_nd.FieldType = "C"
        Me.Product_nd.FieldView = "Product_nd"
        Me.Product_nd.FormList = False
        Me.Product_nd.KeyInsert = ""
        Me.Product_nd.LocalDecimal = False
        Me.Product_nd.Name = "Product_nd"
        Me.Product_nd.NoUpdate = ""
        Me.Product_nd.NumberDecimal = 0
        Me.Product_nd.ParentControl = ""
        Me.Product_nd.RefreshSource = False
        Me.Product_nd.Required = True
        Me.Product_nd.ShowDataTime = False
        Me.Product_nd.SQLString = "SELECT MaHangHoa,TenHangHoa FROM tblHangHoa  where dbo.FPT_MaHangHoaBomXuat(MaHan" & _
            "gHoa)=1"
        Me.Product_nd.UpdateIfNull = ""
        Me.Product_nd.UpdateWhenFormLock = False
        Me.Product_nd.ValidateValue = True
        Me.Product_nd.Visible = True
        Me.Product_nd.VisibleIndex = 2
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'TenHangHoa
        '
        Me.TenHangHoa.AllowInsert = True
        Me.TenHangHoa.AllowUpdate = True
        Me.TenHangHoa.Caption = "Hàng hóa"
        Me.TenHangHoa.CFLColumnHide = ""
        Me.TenHangHoa.CFLKeyField = ""
        Me.TenHangHoa.CFLPage = False
        Me.TenHangHoa.CFLReturn0 = ""
        Me.TenHangHoa.CFLReturn1 = ""
        Me.TenHangHoa.CFLReturn2 = ""
        Me.TenHangHoa.CFLReturn3 = ""
        Me.TenHangHoa.CFLReturn4 = ""
        Me.TenHangHoa.CFLShowLoad = False
        Me.TenHangHoa.ChangeFormStatus = True
        Me.TenHangHoa.ColumnEdit = Me.RepositoryItemButtonEdit3
        Me.TenHangHoa.ColumnKey = False
        Me.TenHangHoa.ComboLine = 5
        Me.TenHangHoa.CopyFromItem = ""
        Me.TenHangHoa.DefaultButtonClick = False
        Me.TenHangHoa.Digit = False
        Me.TenHangHoa.FieldType = "C"
        Me.TenHangHoa.FieldView = "TenHangHoa"
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
        Me.TenHangHoa.ShowDataTime = False
        Me.TenHangHoa.SQLString = ""
        Me.TenHangHoa.UpdateIfNull = ""
        Me.TenHangHoa.UpdateWhenFormLock = False
        Me.TenHangHoa.ValidateValue = True
        Me.TenHangHoa.Visible = True
        Me.TenHangHoa.VisibleIndex = 3
        '
        'RepositoryItemButtonEdit3
        '
        Me.RepositoryItemButtonEdit3.AutoHeight = False
        Me.RepositoryItemButtonEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit3.Name = "RepositoryItemButtonEdit3"
        '
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
        Me.CHECKUPD.Caption = "CHECKUPD"
        Me.CHECKUPD.CFLColumnHide = ""
        Me.CHECKUPD.CFLKeyField = ""
        Me.CHECKUPD.CFLPage = False
        Me.CHECKUPD.CFLReturn0 = ""
        Me.CHECKUPD.CFLReturn1 = ""
        Me.CHECKUPD.CFLReturn2 = ""
        Me.CHECKUPD.CFLReturn3 = ""
        Me.CHECKUPD.CFLReturn4 = ""
        Me.CHECKUPD.CFLShowLoad = False
        Me.CHECKUPD.ChangeFormStatus = True
        Me.CHECKUPD.ColumnKey = False
        Me.CHECKUPD.ComboLine = 5
        Me.CHECKUPD.CopyFromItem = ""
        Me.CHECKUPD.DefaultButtonClick = False
        Me.CHECKUPD.Digit = False
        Me.CHECKUPD.FieldType = "C"
        Me.CHECKUPD.FieldView = "CHECKUPD"
        Me.CHECKUPD.FormList = False
        Me.CHECKUPD.KeyInsert = ""
        Me.CHECKUPD.LocalDecimal = False
        Me.CHECKUPD.Name = "CHECKUPD"
        Me.CHECKUPD.NoUpdate = ""
        Me.CHECKUPD.NumberDecimal = 0
        Me.CHECKUPD.ParentControl = ""
        Me.CHECKUPD.RefreshSource = False
        Me.CHECKUPD.Required = False
        Me.CHECKUPD.ShowDataTime = False
        Me.CHECKUPD.SQLString = ""
        Me.CHECKUPD.UpdateIfNull = ""
        Me.CHECKUPD.UpdateWhenFormLock = False
        Me.CHECKUPD.ValidateValue = True
        Me.CHECKUPD.Visible = True
        '
        'FrmTankActiveNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 568)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.TrueDBGrid2)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.U_ButtonCus2)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmTankActiveNew"
        Me.Text = "Tỷ trọng bể theo ngày"
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.TrueDBGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents U_ButtonCus2 As U_TextBox.U_ButtonCus
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TrueDBGrid2 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView2 As U_TextBox.GridView
    Friend WithEvents GridColumn1 As U_TextBox.GridColumn
    Friend WithEvents GridColumn2 As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GridColumn3 As U_TextBox.GridColumn
    Friend WithEvents GridColumn4 As U_TextBox.GridColumn
    Friend WithEvents GridColumn5 As U_TextBox.GridColumn
    Friend WithEvents GridColumn6 As U_TextBox.GridColumn
    Friend WithEvents GridColumn7 As U_TextBox.GridColumn
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents Name_nd As U_TextBox.GridColumn
    Friend WithEvents Dens_nd As U_TextBox.GridColumn
    Friend WithEvents Product_nd As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents TenHangHoa As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
End Class
