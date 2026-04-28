<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTank
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTank))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.Name_nd = New U_TextBox.GridColumn()
        Me.Dens_nd = New U_TextBox.GridColumn()
        Me.Product_nd = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.TenHangHoa = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.TankGroup = New U_TextBox.GridColumn()
        Me.FromDate = New U_TextBox.GridColumn()
        Me.ToDate = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus()
        Me.U_ButtonCus2 = New U_TextBox.U_ButtonCus()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.U_TextBox1 = New U_TextBox.U_TextBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.U_TextBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = False
        Me.TrueDBGrid1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 28)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemButtonEdit2})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(900, 454)
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
        Me.GridView1.ColumnKeyIns = False
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Name_nd, Me.Dens_nd, Me.Product_nd, Me.TenHangHoa, Me.CHECKUPD, Me.TankGroup, Me.FromDate, Me.ToDate})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
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
        Me.Name_nd.ButtonClick = True
        Me.Name_nd.Caption = "Mã bể"
        Me.Name_nd.CFLColumnHide = ""
        Me.Name_nd.CFLKeyField = ""
        Me.Name_nd.CFLPage = False
        Me.Name_nd.CFLReturn0 = ""
        Me.Name_nd.CFLReturn1 = ""
        Me.Name_nd.CFLReturn2 = ""
        Me.Name_nd.CFLReturn3 = ""
        Me.Name_nd.CFLReturn4 = ""
        Me.Name_nd.CFLReturn5 = ""
        Me.Name_nd.CFLReturn6 = ""
        Me.Name_nd.CFLReturn7 = ""
        Me.Name_nd.CFLShowLoad = False
        Me.Name_nd.ChangeFormStatus = True
        Me.Name_nd.ColumnKey = True
        Me.Name_nd.ComboLine = 5
        Me.Name_nd.CopyFromItem = ""
        Me.Name_nd.DefaultButtonClick = False
        Me.Name_nd.Digit = False
        Me.Name_nd.FieldType = "C"
        Me.Name_nd.FieldView = "Name_nd"
        Me.Name_nd.FormarNumber = True
        Me.Name_nd.FormList = False
        Me.Name_nd.KeyInsert = ""
        Me.Name_nd.LocalDecimal = False
        Me.Name_nd.Name = "Name_nd"
        Me.Name_nd.NoUpdate = ""
        Me.Name_nd.NumberDecimal = 0
        Me.Name_nd.ParentControl = ""
        Me.Name_nd.RefreshSource = False
        Me.Name_nd.Required = True
        Me.Name_nd.SequenceName = ""
        Me.Name_nd.ShowCalc = True
        Me.Name_nd.ShowDataTime = False
        Me.Name_nd.ShowOnlyTime = False
        Me.Name_nd.SQLString = ""
        Me.Name_nd.UpdateIfNull = ""
        Me.Name_nd.UpdateWhenFormLock = False
        Me.Name_nd.UpperValue = False
        Me.Name_nd.ValidateValue = True
        Me.Name_nd.Visible = True
        Me.Name_nd.VisibleIndex = 0
        Me.Name_nd.Width = 128
        '
        'Dens_nd
        '
        Me.Dens_nd.AllowInsert = True
        Me.Dens_nd.AllowUpdate = True
        Me.Dens_nd.ButtonClick = True
        Me.Dens_nd.Caption = "Tỷ trọng"
        Me.Dens_nd.CFLColumnHide = ""
        Me.Dens_nd.CFLKeyField = ""
        Me.Dens_nd.CFLPage = False
        Me.Dens_nd.CFLReturn0 = ""
        Me.Dens_nd.CFLReturn1 = ""
        Me.Dens_nd.CFLReturn2 = ""
        Me.Dens_nd.CFLReturn3 = ""
        Me.Dens_nd.CFLReturn4 = ""
        Me.Dens_nd.CFLReturn5 = ""
        Me.Dens_nd.CFLReturn6 = ""
        Me.Dens_nd.CFLReturn7 = ""
        Me.Dens_nd.CFLShowLoad = False
        Me.Dens_nd.ChangeFormStatus = True
        Me.Dens_nd.ColumnKey = False
        Me.Dens_nd.ComboLine = 5
        Me.Dens_nd.CopyFromItem = ""
        Me.Dens_nd.DefaultButtonClick = False
        Me.Dens_nd.Digit = True
        Me.Dens_nd.FieldType = "N"
        Me.Dens_nd.FieldView = "Dens_nd"
        Me.Dens_nd.FormarNumber = True
        Me.Dens_nd.FormList = False
        Me.Dens_nd.KeyInsert = ""
        Me.Dens_nd.LocalDecimal = True
        Me.Dens_nd.Name = "Dens_nd"
        Me.Dens_nd.NoUpdate = ""
        Me.Dens_nd.NumberDecimal = 4
        Me.Dens_nd.ParentControl = ""
        Me.Dens_nd.RefreshSource = False
        Me.Dens_nd.Required = True
        Me.Dens_nd.SequenceName = ""
        Me.Dens_nd.ShowCalc = False
        Me.Dens_nd.ShowDataTime = False
        Me.Dens_nd.ShowOnlyTime = False
        Me.Dens_nd.SQLString = ""
        Me.Dens_nd.UpdateIfNull = ""
        Me.Dens_nd.UpdateWhenFormLock = False
        Me.Dens_nd.UpperValue = False
        Me.Dens_nd.ValidateValue = True
        Me.Dens_nd.Visible = True
        Me.Dens_nd.VisibleIndex = 1
        Me.Dens_nd.Width = 128
        '
        'Product_nd
        '
        Me.Product_nd.AllowInsert = True
        Me.Product_nd.AllowUpdate = True
        Me.Product_nd.ButtonClick = True
        Me.Product_nd.Caption = "Mã hàng hóa"
        Me.Product_nd.CFLColumnHide = ""
        Me.Product_nd.CFLKeyField = "MaHangHoa"
        Me.Product_nd.CFLPage = False
        Me.Product_nd.CFLReturn0 = ""
        Me.Product_nd.CFLReturn1 = "TenHangHoa"
        Me.Product_nd.CFLReturn2 = ""
        Me.Product_nd.CFLReturn3 = ""
        Me.Product_nd.CFLReturn4 = ""
        Me.Product_nd.CFLReturn5 = ""
        Me.Product_nd.CFLReturn6 = ""
        Me.Product_nd.CFLReturn7 = ""
        Me.Product_nd.CFLShowLoad = True
        Me.Product_nd.ChangeFormStatus = True
        Me.Product_nd.ColumnEdit = Me.RepositoryItemButtonEdit2
        Me.Product_nd.ColumnKey = False
        Me.Product_nd.ComboLine = 5
        Me.Product_nd.CopyFromItem = ""
        Me.Product_nd.DefaultButtonClick = False
        Me.Product_nd.Digit = False
        Me.Product_nd.FieldType = "C"
        Me.Product_nd.FieldView = "Product_nd"
        Me.Product_nd.FormarNumber = True
        Me.Product_nd.FormList = False
        Me.Product_nd.KeyInsert = ""
        Me.Product_nd.LocalDecimal = False
        Me.Product_nd.Name = "Product_nd"
        Me.Product_nd.NoUpdate = ""
        Me.Product_nd.NumberDecimal = 0
        Me.Product_nd.ParentControl = ""
        Me.Product_nd.RefreshSource = False
        Me.Product_nd.Required = True
        Me.Product_nd.SequenceName = ""
        Me.Product_nd.ShowCalc = True
        Me.Product_nd.ShowDataTime = False
        Me.Product_nd.ShowOnlyTime = False
        Me.Product_nd.SQLString = "SELECT MaHangHoa,TenHangHoa FROM tblHangHoa  where dbo.FPT_MaHangHoaBomXuat(MaHan" & _
            "gHoa)=1"
        Me.Product_nd.UpdateIfNull = ""
        Me.Product_nd.UpdateWhenFormLock = False
        Me.Product_nd.UpperValue = False
        Me.Product_nd.ValidateValue = True
        Me.Product_nd.Visible = True
        Me.Product_nd.VisibleIndex = 2
        Me.Product_nd.Width = 128
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
        Me.TenHangHoa.Caption = "Hàng hóa"
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
        Me.TenHangHoa.VisibleIndex = 3
        Me.TenHangHoa.Width = 128
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
        'FromDate
        '
        Me.FromDate.AllowInsert = True
        Me.FromDate.AllowUpdate = True
        Me.FromDate.ButtonClick = True
        Me.FromDate.Caption = "Ngày hiệu lực"
        Me.FromDate.CFLColumnHide = ""
        Me.FromDate.CFLKeyField = ""
        Me.FromDate.CFLPage = False
        Me.FromDate.CFLReturn0 = ""
        Me.FromDate.CFLReturn1 = ""
        Me.FromDate.CFLReturn2 = ""
        Me.FromDate.CFLReturn3 = ""
        Me.FromDate.CFLReturn4 = ""
        Me.FromDate.CFLReturn5 = ""
        Me.FromDate.CFLReturn6 = ""
        Me.FromDate.CFLReturn7 = ""
        Me.FromDate.CFLShowLoad = False
        Me.FromDate.ChangeFormStatus = True
        Me.FromDate.ColumnKey = False
        Me.FromDate.ComboLine = 5
        Me.FromDate.CopyFromItem = ""
        Me.FromDate.DefaultButtonClick = False
        Me.FromDate.Digit = False
        Me.FromDate.FieldType = "D"
        Me.FromDate.FieldView = "FromDate"
        Me.FromDate.FormarNumber = True
        Me.FromDate.FormList = False
        Me.FromDate.KeyInsert = ""
        Me.FromDate.LocalDecimal = False
        Me.FromDate.Name = "FromDate"
        Me.FromDate.NoUpdate = ""
        Me.FromDate.NumberDecimal = 0
        Me.FromDate.ParentControl = ""
        Me.FromDate.RefreshSource = False
        Me.FromDate.Required = False
        Me.FromDate.SequenceName = ""
        Me.FromDate.ShowCalc = True
        Me.FromDate.ShowDataTime = True
        Me.FromDate.ShowOnlyTime = False
        Me.FromDate.SQLString = ""
        Me.FromDate.UpdateIfNull = ""
        Me.FromDate.UpdateWhenFormLock = False
        Me.FromDate.UpperValue = False
        Me.FromDate.ValidateValue = True
        Me.FromDate.Visible = True
        Me.FromDate.VisibleIndex = 5
        Me.FromDate.Width = 110
        '
        'ToDate
        '
        Me.ToDate.AllowInsert = True
        Me.ToDate.AllowUpdate = True
        Me.ToDate.ButtonClick = True
        Me.ToDate.Caption = "Ngày hết hiệu lực"
        Me.ToDate.CFLColumnHide = ""
        Me.ToDate.CFLKeyField = ""
        Me.ToDate.CFLPage = False
        Me.ToDate.CFLReturn0 = ""
        Me.ToDate.CFLReturn1 = ""
        Me.ToDate.CFLReturn2 = ""
        Me.ToDate.CFLReturn3 = ""
        Me.ToDate.CFLReturn4 = ""
        Me.ToDate.CFLReturn5 = ""
        Me.ToDate.CFLReturn6 = ""
        Me.ToDate.CFLReturn7 = ""
        Me.ToDate.CFLShowLoad = False
        Me.ToDate.ChangeFormStatus = True
        Me.ToDate.ColumnKey = False
        Me.ToDate.ComboLine = 5
        Me.ToDate.CopyFromItem = ""
        Me.ToDate.DefaultButtonClick = False
        Me.ToDate.Digit = False
        Me.ToDate.FieldType = "D"
        Me.ToDate.FieldView = "ToDate"
        Me.ToDate.FormarNumber = True
        Me.ToDate.FormList = False
        Me.ToDate.KeyInsert = ""
        Me.ToDate.LocalDecimal = False
        Me.ToDate.Name = "ToDate"
        Me.ToDate.NoUpdate = ""
        Me.ToDate.NumberDecimal = 0
        Me.ToDate.ParentControl = ""
        Me.ToDate.RefreshSource = False
        Me.ToDate.Required = False
        Me.ToDate.SequenceName = ""
        Me.ToDate.ShowCalc = True
        Me.ToDate.ShowDataTime = True
        Me.ToDate.ShowOnlyTime = False
        Me.ToDate.SQLString = ""
        Me.ToDate.UpdateIfNull = ""
        Me.ToDate.UpdateWhenFormLock = False
        Me.ToDate.UpperValue = False
        Me.ToDate.ValidateValue = True
        Me.ToDate.Visible = True
        Me.ToDate.VisibleIndex = 6
        Me.ToDate.Width = 132
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(77, 357)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(121, 23)
        Me.U_ButtonCus1.TabIndex = 1
        Me.U_ButtonCus1.Text = "Đồng bộ từ SAP"
        Me.U_ButtonCus1.Visible = False
        '
        'U_ButtonCus2
        '
        Me.U_ButtonCus2.DefaultUpdate = True
        Me.U_ButtonCus2.EnableWhenFormLock = False
        Me.U_ButtonCus2.Location = New System.Drawing.Point(205, 231)
        Me.U_ButtonCus2.Name = "U_ButtonCus2"
        Me.U_ButtonCus2.Size = New System.Drawing.Size(191, 23)
        Me.U_ButtonCus2.TabIndex = 2
        Me.U_ButtonCus2.Text = "Nhập tỷ trọng bể theo ngày"
        Me.U_ButtonCus2.Visible = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton3})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(907, 28)
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
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(222, 25)
        Me.ToolStripButton3.Text = "&3. Đồng bộ nhóm bể từ SAP"
        '
        'U_TextBox1
        '
        Me.U_TextBox1.AllowInsert = True
        Me.U_TextBox1.AllowUpdate = True
        Me.U_TextBox1.AutoKeyFix = ""
        Me.U_TextBox1.AutoKeyName = ""
        Me.U_TextBox1.BindingSourceName = ""
        Me.U_TextBox1.ChangeFormStatus = True
        Me.U_TextBox1.CopyFromItem = ""
        Me.U_TextBox1.DefaultValue = ""
        Me.U_TextBox1.FieldName = ""
        Me.U_TextBox1.FieldType = "C"
        Me.U_TextBox1.KeyInsert = ""
        Me.U_TextBox1.LinkLabel = ""
        Me.U_TextBox1.Location = New System.Drawing.Point(428, -2)
        Me.U_TextBox1.Name = "U_TextBox1"
        Me.U_TextBox1.NoUpdate = "N"
        Me.U_TextBox1.PrimaryKey = ""
        Me.U_TextBox1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_TextBox1.Properties.Appearance.Options.UseFont = True
        Me.U_TextBox1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_TextBox1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_TextBox1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_TextBox1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_TextBox1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_TextBox1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_TextBox1.Properties.AutoHeight = False
        Me.U_TextBox1.Required = ""
        Me.U_TextBox1.Size = New System.Drawing.Size(0, 30)
        Me.U_TextBox1.TabIndex = 472
        Me.U_TextBox1.TableName = ""
        Me.U_TextBox1.TabStop = False
        Me.U_TextBox1.UpdateIfNull = ""
        Me.U_TextBox1.UpdateWhenFormLock = False
        Me.U_TextBox1.UpperValue = False
        Me.U_TextBox1.ViewName = ""
        '
        'FrmTank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(907, 506)
        Me.Controls.Add(Me.U_TextBox1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.U_ButtonCus2)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmTank"
        Me.ShowFormMessage = True
        Me.Text = "Thông tin bể xuất"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus2, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.U_TextBox1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.U_TextBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents Name_nd As U_TextBox.GridColumn
    Friend WithEvents Dens_nd As U_TextBox.GridColumn
    Friend WithEvents Product_nd As U_TextBox.GridColumn
    Friend WithEvents TenHangHoa As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents U_ButtonCus2 As U_TextBox.U_ButtonCus
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents U_TextBox1 As U_TextBox.U_TextBox
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TankGroup As U_TextBox.GridColumn
    Friend WithEvents FromDate As U_TextBox.GridColumn
    Friend WithEvents ToDate As U_TextBox.GridColumn
End Class
