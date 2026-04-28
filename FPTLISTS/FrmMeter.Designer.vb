<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMeter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMeter))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.MeterId = New U_TextBox.GridColumn()
        Me.LoadingSite = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.ArmNo = New U_TextBox.GridColumn()
        Me.ProductCode = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.TenHangHoa = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.Name_ND = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.FromDate = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(2, 28)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemComboBox1, Me.RepositoryItemButtonEdit2, Me.RepositoryItemButtonEdit3})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(852, 456)
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MeterId, Me.LoadingSite, Me.ArmNo, Me.ProductCode, Me.TenHangHoa, Me.CHECKUPD, Me.Name_ND, Me.FromDate})
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
        Me.GridView1.TableName = "tblMeter"
        Me.GridView1.ViewName = "FPT_tblMeter_v"
        Me.GridView1.Where = Nothing
        '
        'MeterId
        '
        Me.MeterId.AllowInsert = True
        Me.MeterId.AllowUpdate = True
        Me.MeterId.ButtonClick = True
        Me.MeterId.Caption = "Mã công tơ"
        Me.MeterId.CFLColumnHide = ""
        Me.MeterId.CFLKeyField = ""
        Me.MeterId.CFLPage = False
        Me.MeterId.CFLReturn0 = ""
        Me.MeterId.CFLReturn1 = ""
        Me.MeterId.CFLReturn2 = ""
        Me.MeterId.CFLReturn3 = ""
        Me.MeterId.CFLReturn4 = ""
        Me.MeterId.CFLReturn5 = ""
        Me.MeterId.CFLReturn6 = ""
        Me.MeterId.CFLReturn7 = ""
        Me.MeterId.CFLShowLoad = False
        Me.MeterId.ChangeFormStatus = True
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
        'LoadingSite
        '
        Me.LoadingSite.AllowInsert = True
        Me.LoadingSite.AllowUpdate = True
        Me.LoadingSite.ButtonClick = True
        Me.LoadingSite.Caption = "Loại"
        Me.LoadingSite.CFLColumnHide = ""
        Me.LoadingSite.CFLKeyField = ""
        Me.LoadingSite.CFLPage = False
        Me.LoadingSite.CFLReturn0 = ""
        Me.LoadingSite.CFLReturn1 = ""
        Me.LoadingSite.CFLReturn2 = ""
        Me.LoadingSite.CFLReturn3 = ""
        Me.LoadingSite.CFLReturn4 = ""
        Me.LoadingSite.CFLReturn5 = ""
        Me.LoadingSite.CFLReturn6 = ""
        Me.LoadingSite.CFLReturn7 = ""
        Me.LoadingSite.CFLShowLoad = False
        Me.LoadingSite.ChangeFormStatus = True
        Me.LoadingSite.ColumnEdit = Me.RepositoryItemComboBox1
        Me.LoadingSite.ColumnKey = False
        Me.LoadingSite.ComboLine = 5
        Me.LoadingSite.CopyFromItem = ""
        Me.LoadingSite.DefaultButtonClick = False
        Me.LoadingSite.Digit = False
        Me.LoadingSite.FieldType = "C"
        Me.LoadingSite.FieldView = "LoadingSite"
        Me.LoadingSite.FormarNumber = True
        Me.LoadingSite.FormList = False
        Me.LoadingSite.KeyInsert = ""
        Me.LoadingSite.LocalDecimal = False
        Me.LoadingSite.Name = "LoadingSite"
        Me.LoadingSite.NoUpdate = ""
        Me.LoadingSite.NumberDecimal = 0
        Me.LoadingSite.ParentControl = ""
        Me.LoadingSite.RefreshSource = False
        Me.LoadingSite.Required = False
        Me.LoadingSite.SequenceName = ""
        Me.LoadingSite.ShowCalc = True
        Me.LoadingSite.ShowDataTime = False
        Me.LoadingSite.ShowOnlyTime = False
        Me.LoadingSite.SQLString = "select Code as LoadingSite from FPT_LoaiHinhVanChuyen_V"
        Me.LoadingSite.UpdateIfNull = ""
        Me.LoadingSite.UpdateWhenFormLock = False
        Me.LoadingSite.UpperValue = False
        Me.LoadingSite.ValidateValue = True
        Me.LoadingSite.Visible = True
        Me.LoadingSite.VisibleIndex = 1
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'ArmNo
        '
        Me.ArmNo.AllowInsert = True
        Me.ArmNo.AllowUpdate = True
        Me.ArmNo.ButtonClick = True
        Me.ArmNo.Caption = "Họng"
        Me.ArmNo.CFLColumnHide = ""
        Me.ArmNo.CFLKeyField = ""
        Me.ArmNo.CFLPage = False
        Me.ArmNo.CFLReturn0 = ""
        Me.ArmNo.CFLReturn1 = ""
        Me.ArmNo.CFLReturn2 = ""
        Me.ArmNo.CFLReturn3 = ""
        Me.ArmNo.CFLReturn4 = ""
        Me.ArmNo.CFLReturn5 = ""
        Me.ArmNo.CFLReturn6 = ""
        Me.ArmNo.CFLReturn7 = ""
        Me.ArmNo.CFLShowLoad = False
        Me.ArmNo.ChangeFormStatus = True
        Me.ArmNo.ColumnKey = False
        Me.ArmNo.ComboLine = 5
        Me.ArmNo.CopyFromItem = ""
        Me.ArmNo.DefaultButtonClick = False
        Me.ArmNo.Digit = False
        Me.ArmNo.FieldType = "N"
        Me.ArmNo.FieldView = "ArmNo"
        Me.ArmNo.FormarNumber = True
        Me.ArmNo.FormList = False
        Me.ArmNo.KeyInsert = ""
        Me.ArmNo.LocalDecimal = False
        Me.ArmNo.Name = "ArmNo"
        Me.ArmNo.NoUpdate = ""
        Me.ArmNo.NumberDecimal = 0
        Me.ArmNo.ParentControl = ""
        Me.ArmNo.RefreshSource = False
        Me.ArmNo.Required = False
        Me.ArmNo.SequenceName = ""
        Me.ArmNo.ShowCalc = True
        Me.ArmNo.ShowDataTime = False
        Me.ArmNo.ShowOnlyTime = False
        Me.ArmNo.SQLString = ""
        Me.ArmNo.UpdateIfNull = ""
        Me.ArmNo.UpdateWhenFormLock = False
        Me.ArmNo.UpperValue = False
        Me.ArmNo.ValidateValue = True
        Me.ArmNo.Visible = True
        Me.ArmNo.VisibleIndex = 2
        '
        'ProductCode
        '
        Me.ProductCode.AllowInsert = True
        Me.ProductCode.AllowUpdate = True
        Me.ProductCode.ButtonClick = True
        Me.ProductCode.Caption = "Mã hàng hóa"
        Me.ProductCode.CFLColumnHide = ""
        Me.ProductCode.CFLKeyField = "ProductCode"
        Me.ProductCode.CFLPage = False
        Me.ProductCode.CFLReturn0 = ""
        Me.ProductCode.CFLReturn1 = "TenHangHoa"
        Me.ProductCode.CFLReturn2 = ""
        Me.ProductCode.CFLReturn3 = ""
        Me.ProductCode.CFLReturn4 = ""
        Me.ProductCode.CFLReturn5 = ""
        Me.ProductCode.CFLReturn6 = ""
        Me.ProductCode.CFLReturn7 = ""
        Me.ProductCode.CFLShowLoad = True
        Me.ProductCode.ChangeFormStatus = True
        Me.ProductCode.ColumnEdit = Me.RepositoryItemButtonEdit2
        Me.ProductCode.ColumnKey = False
        Me.ProductCode.ComboLine = 5
        Me.ProductCode.CopyFromItem = ""
        Me.ProductCode.DefaultButtonClick = False
        Me.ProductCode.Digit = False
        Me.ProductCode.FieldType = "C"
        Me.ProductCode.FieldView = "ProductCode"
        Me.ProductCode.FormarNumber = True
        Me.ProductCode.FormList = False
        Me.ProductCode.KeyInsert = ""
        Me.ProductCode.LocalDecimal = False
        Me.ProductCode.Name = "ProductCode"
        Me.ProductCode.NoUpdate = ""
        Me.ProductCode.NumberDecimal = 0
        Me.ProductCode.ParentControl = ""
        Me.ProductCode.RefreshSource = False
        Me.ProductCode.Required = False
        Me.ProductCode.SequenceName = ""
        Me.ProductCode.ShowCalc = True
        Me.ProductCode.ShowDataTime = False
        Me.ProductCode.ShowOnlyTime = False
        Me.ProductCode.SQLString = "SELECT MaHangHoa as ProductCode,TenHangHoa FROM tblHangHoa a where exists (select" & _
            " 1 from tblTank b where a.MaHangHoa=b.Product_nd )  "
        Me.ProductCode.UpdateIfNull = ""
        Me.ProductCode.UpdateWhenFormLock = False
        Me.ProductCode.UpperValue = False
        Me.ProductCode.ValidateValue = True
        Me.ProductCode.Visible = True
        Me.ProductCode.VisibleIndex = 3
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
        Me.TenHangHoa.VisibleIndex = 4
        Me.TenHangHoa.Width = 250
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
        'Name_ND
        '
        Me.Name_ND.AllowInsert = True
        Me.Name_ND.AllowUpdate = True
        Me.Name_ND.ButtonClick = True
        Me.Name_ND.Caption = "Mã bể"
        Me.Name_ND.CFLColumnHide = ""
        Me.Name_ND.CFLKeyField = "Name_ND"
        Me.Name_ND.CFLPage = False
        Me.Name_ND.CFLReturn0 = ""
        Me.Name_ND.CFLReturn1 = ""
        Me.Name_ND.CFLReturn2 = ""
        Me.Name_ND.CFLReturn3 = ""
        Me.Name_ND.CFLReturn4 = ""
        Me.Name_ND.CFLReturn5 = ""
        Me.Name_ND.CFLReturn6 = ""
        Me.Name_ND.CFLReturn7 = ""
        Me.Name_ND.CFLShowLoad = True
        Me.Name_ND.ChangeFormStatus = True
        Me.Name_ND.ColumnEdit = Me.RepositoryItemButtonEdit3
        Me.Name_ND.ColumnKey = False
        Me.Name_ND.ComboLine = 5
        Me.Name_ND.CopyFromItem = ""
        Me.Name_ND.DefaultButtonClick = False
        Me.Name_ND.Digit = False
        Me.Name_ND.FieldType = "C"
        Me.Name_ND.FieldView = "Name_ND"
        Me.Name_ND.FormarNumber = True
        Me.Name_ND.FormList = True
        Me.Name_ND.KeyInsert = ""
        Me.Name_ND.LocalDecimal = False
        Me.Name_ND.Name = "Name_ND"
        Me.Name_ND.NoUpdate = ""
        Me.Name_ND.NumberDecimal = 0
        Me.Name_ND.ParentControl = ""
        Me.Name_ND.RefreshSource = False
        Me.Name_ND.Required = False
        Me.Name_ND.SequenceName = ""
        Me.Name_ND.ShowCalc = True
        Me.Name_ND.ShowDataTime = False
        Me.Name_ND.ShowOnlyTime = False
        Me.Name_ND.SQLString = "select Name_nd  from tblTank where  Product_nd =:Column.ProductCode"
        Me.Name_ND.UpdateIfNull = ""
        Me.Name_ND.UpdateWhenFormLock = False
        Me.Name_ND.UpperValue = False
        Me.Name_ND.ValidateValue = True
        Me.Name_ND.Visible = True
        Me.Name_ND.VisibleIndex = 5
        '
        'RepositoryItemButtonEdit3
        '
        Me.RepositoryItemButtonEdit3.AutoHeight = False
        Me.RepositoryItemButtonEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit3.Name = "RepositoryItemButtonEdit3"
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
        Me.FromDate.VisibleIndex = 6
        Me.FromDate.Width = 150
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(858, 28)
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
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(247, 25)
        Me.ToolStripButton2.Text = "&3. Thông tin Công tơ- Nhóm bể"
        '
        'FrmMeter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 508)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmMeter"
        Me.ShowFormMessage = True
        Me.Text = "Thông tin công tơ"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LoadingSite As U_TextBox.GridColumn
    Friend WithEvents ArmNo As U_TextBox.GridColumn
    Friend WithEvents ProductCode As U_TextBox.GridColumn
    Friend WithEvents TenHangHoa As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemButtonEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents Name_ND As U_TextBox.GridColumn
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents FromDate As U_TextBox.GridColumn
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
End Class
