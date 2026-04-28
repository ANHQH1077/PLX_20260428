<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSoLenhAuto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSoLenhAuto))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NgayXuat = New U_TextBox.U_DateEdit()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.X = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.SoLenh = New U_TextBox.GridColumn()
        Me.NgayThang = New U_TextBox.GridColumn()
        Me.sStatus = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colMaNguon = New U_TextBox.GridColumn()
        Me.colMaKhachHang = New U_TextBox.GridColumn()
        Me.colTenKhachHang = New U_TextBox.GridColumn()
        Me.MaPhuongTien = New U_TextBox.GridColumn()
        Me.sDesc = New U_TextBox.GridColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NgayXuatTo = New U_TextBox.U_DateEdit()
        Me.U_CheckBox1 = New U_TextBox.U_CheckBox()
        Me.TenKhachHang = New U_TextBox.U_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MaKhachHang = New U_TextBox.U_ButtonEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.MaNguon = New U_TextBox.U_ButtonEdit()
        Me.U_ButtonCus2 = New U_TextBox.U_ButtonCus(Me.components)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuatTo.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuatTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CheckBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TenKhachHang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaKhachHang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaNguon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1130, 28)
        Me.ToolStrip2.TabIndex = 469
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(204, 25)
        Me.ToolStripButton2.Text = "&1. Thực hiện rút lệnh xuất"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(144, 25)
        Me.ToolStripButton1.Text = "&2. Tra cứu lịch sử"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(117, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 19)
        Me.Label2.TabIndex = 471
        Me.Label2.Text = "Từ ngày"
        '
        'NgayXuat
        '
        Me.NgayXuat.AllowInsert = True
        Me.NgayXuat.AllowUpdate = True
        Me.NgayXuat.BindingSourceName = ""
        Me.NgayXuat.ChangeFormStatus = False
        Me.NgayXuat.CopyFromItem = ""
        Me.NgayXuat.DefaultValue = ""
        Me.NgayXuat.EditValue = Nothing
        Me.NgayXuat.FieldName = "NgayXuat"
        Me.NgayXuat.FieldType = "D"
        Me.NgayXuat.KeyInsert = ""
        Me.NgayXuat.LinkLabel = ""
        Me.NgayXuat.Location = New System.Drawing.Point(219, 38)
        Me.NgayXuat.Name = "NgayXuat"
        Me.NgayXuat.NoUpdate = ""
        Me.NgayXuat.PrimaryKey = ""
        Me.NgayXuat.Properties.AutoHeight = False
        Me.NgayXuat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayXuat.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayXuat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayXuat.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayXuat.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayXuat.Required = "Y"
        Me.NgayXuat.ShowDateTime = False
        Me.NgayXuat.Size = New System.Drawing.Size(150, 26)
        Me.NgayXuat.TabIndex = 470
        Me.NgayXuat.TableName = ""
        Me.NgayXuat.UpdateIfNull = ""
        Me.NgayXuat.UpdateWhenFormLock = False
        Me.NgayXuat.ViewName = ""
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(963, 38)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(164, 33)
        Me.U_ButtonCus1.TabIndex = 472
        Me.U_ButtonCus1.Text = "&9. Kiểm tra lệnh xuất"
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 105)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit2})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(1124, 514)
        Me.TrueDBGrid1.TabIndex = 473
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.X, Me.SoLenh, Me.NgayThang, Me.sStatus, Me.colMaNguon, Me.colMaKhachHang, Me.colTenKhachHang, Me.MaPhuongTien, Me.sDesc})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = ""
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = ""
        Me.GridView1.Where = Nothing
        '
        'X
        '
        Me.X.AllowInsert = True
        Me.X.AllowUpdate = True
        Me.X.ButtonClick = True
        Me.X.Caption = "Chọn"
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
        Me.X.ColumnEdit = Me.RepositoryItemCheckEdit1
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
        Me.X.Width = 80
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Y"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "N"
        '
        'SoLenh
        '
        Me.SoLenh.AllowInsert = True
        Me.SoLenh.AllowUpdate = True
        Me.SoLenh.ButtonClick = True
        Me.SoLenh.Caption = "Số lệnh"
        Me.SoLenh.CFLColumnHide = ""
        Me.SoLenh.CFLKeyField = ""
        Me.SoLenh.CFLPage = False
        Me.SoLenh.CFLReturn0 = ""
        Me.SoLenh.CFLReturn1 = ""
        Me.SoLenh.CFLReturn2 = ""
        Me.SoLenh.CFLReturn3 = ""
        Me.SoLenh.CFLReturn4 = ""
        Me.SoLenh.CFLReturn5 = ""
        Me.SoLenh.CFLReturn6 = ""
        Me.SoLenh.CFLReturn7 = ""
        Me.SoLenh.CFLShowLoad = False
        Me.SoLenh.ChangeFormStatus = True
        Me.SoLenh.ColumnKey = False
        Me.SoLenh.ComboLine = 5
        Me.SoLenh.CopyFromItem = ""
        Me.SoLenh.DefaultButtonClick = False
        Me.SoLenh.Digit = False
        Me.SoLenh.FieldType = "C"
        Me.SoLenh.FieldView = "SoLenh"
        Me.SoLenh.FormarNumber = True
        Me.SoLenh.FormList = False
        Me.SoLenh.KeyInsert = ""
        Me.SoLenh.LocalDecimal = False
        Me.SoLenh.Name = "SoLenh"
        Me.SoLenh.NoUpdate = ""
        Me.SoLenh.NumberDecimal = 0
        Me.SoLenh.OptionsColumn.ReadOnly = True
        Me.SoLenh.ParentControl = ""
        Me.SoLenh.RefreshSource = False
        Me.SoLenh.Required = False
        Me.SoLenh.SequenceName = ""
        Me.SoLenh.ShowCalc = True
        Me.SoLenh.ShowDataTime = False
        Me.SoLenh.ShowOnlyTime = False
        Me.SoLenh.SQLString = ""
        Me.SoLenh.UpdateIfNull = ""
        Me.SoLenh.UpdateWhenFormLock = False
        Me.SoLenh.UpperValue = False
        Me.SoLenh.ValidateValue = True
        Me.SoLenh.Visible = True
        Me.SoLenh.VisibleIndex = 1
        Me.SoLenh.Width = 100
        '
        'NgayThang
        '
        Me.NgayThang.AllowInsert = True
        Me.NgayThang.AllowUpdate = True
        Me.NgayThang.ButtonClick = True
        Me.NgayThang.Caption = "Ngày hiệu lực"
        Me.NgayThang.CFLColumnHide = ""
        Me.NgayThang.CFLKeyField = ""
        Me.NgayThang.CFLPage = False
        Me.NgayThang.CFLReturn0 = ""
        Me.NgayThang.CFLReturn1 = ""
        Me.NgayThang.CFLReturn2 = ""
        Me.NgayThang.CFLReturn3 = ""
        Me.NgayThang.CFLReturn4 = ""
        Me.NgayThang.CFLReturn5 = ""
        Me.NgayThang.CFLReturn6 = ""
        Me.NgayThang.CFLReturn7 = ""
        Me.NgayThang.CFLShowLoad = False
        Me.NgayThang.ChangeFormStatus = True
        Me.NgayThang.ColumnKey = False
        Me.NgayThang.ComboLine = 5
        Me.NgayThang.CopyFromItem = ""
        Me.NgayThang.DefaultButtonClick = False
        Me.NgayThang.Digit = False
        Me.NgayThang.FieldType = "D"
        Me.NgayThang.FieldView = "NgayThang"
        Me.NgayThang.FormarNumber = True
        Me.NgayThang.FormList = False
        Me.NgayThang.KeyInsert = ""
        Me.NgayThang.LocalDecimal = False
        Me.NgayThang.Name = "NgayThang"
        Me.NgayThang.NoUpdate = ""
        Me.NgayThang.NumberDecimal = 0
        Me.NgayThang.OptionsColumn.ReadOnly = True
        Me.NgayThang.ParentControl = ""
        Me.NgayThang.RefreshSource = False
        Me.NgayThang.Required = False
        Me.NgayThang.SequenceName = ""
        Me.NgayThang.ShowCalc = True
        Me.NgayThang.ShowDataTime = True
        Me.NgayThang.ShowOnlyTime = False
        Me.NgayThang.SQLString = ""
        Me.NgayThang.UpdateIfNull = ""
        Me.NgayThang.UpdateWhenFormLock = False
        Me.NgayThang.UpperValue = False
        Me.NgayThang.ValidateValue = True
        Me.NgayThang.Visible = True
        Me.NgayThang.VisibleIndex = 2
        Me.NgayThang.Width = 80
        '
        'sStatus
        '
        Me.sStatus.AllowInsert = True
        Me.sStatus.AllowUpdate = True
        Me.sStatus.ButtonClick = True
        Me.sStatus.Caption = "Trạng thái"
        Me.sStatus.CFLColumnHide = ""
        Me.sStatus.CFLKeyField = ""
        Me.sStatus.CFLPage = False
        Me.sStatus.CFLReturn0 = ""
        Me.sStatus.CFLReturn1 = ""
        Me.sStatus.CFLReturn2 = ""
        Me.sStatus.CFLReturn3 = ""
        Me.sStatus.CFLReturn4 = ""
        Me.sStatus.CFLReturn5 = ""
        Me.sStatus.CFLReturn6 = ""
        Me.sStatus.CFLReturn7 = ""
        Me.sStatus.CFLShowLoad = False
        Me.sStatus.ChangeFormStatus = True
        Me.sStatus.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.sStatus.ColumnKey = False
        Me.sStatus.ComboLine = 5
        Me.sStatus.CopyFromItem = ""
        Me.sStatus.DefaultButtonClick = False
        Me.sStatus.Digit = False
        Me.sStatus.FieldType = "C"
        Me.sStatus.FieldView = ""
        Me.sStatus.FormarNumber = True
        Me.sStatus.FormList = False
        Me.sStatus.KeyInsert = ""
        Me.sStatus.LocalDecimal = False
        Me.sStatus.Name = "sStatus"
        Me.sStatus.NoUpdate = ""
        Me.sStatus.NumberDecimal = 0
        Me.sStatus.OptionsColumn.ReadOnly = True
        Me.sStatus.ParentControl = ""
        Me.sStatus.RefreshSource = False
        Me.sStatus.Required = False
        Me.sStatus.SequenceName = ""
        Me.sStatus.ShowCalc = True
        Me.sStatus.ShowDataTime = False
        Me.sStatus.ShowOnlyTime = False
        Me.sStatus.SQLString = ""
        Me.sStatus.UpdateIfNull = ""
        Me.sStatus.UpdateWhenFormLock = False
        Me.sStatus.UpperValue = False
        Me.sStatus.ValidateValue = True
        Me.sStatus.Visible = True
        Me.sStatus.VisibleIndex = 3
        Me.sStatus.Width = 70
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'colMaNguon
        '
        Me.colMaNguon.AllowInsert = True
        Me.colMaNguon.AllowUpdate = True
        Me.colMaNguon.ButtonClick = True
        Me.colMaNguon.Caption = "Nguồn"
        Me.colMaNguon.CFLColumnHide = ""
        Me.colMaNguon.CFLKeyField = ""
        Me.colMaNguon.CFLPage = False
        Me.colMaNguon.CFLReturn0 = ""
        Me.colMaNguon.CFLReturn1 = ""
        Me.colMaNguon.CFLReturn2 = ""
        Me.colMaNguon.CFLReturn3 = ""
        Me.colMaNguon.CFLReturn4 = ""
        Me.colMaNguon.CFLReturn5 = ""
        Me.colMaNguon.CFLReturn6 = ""
        Me.colMaNguon.CFLReturn7 = ""
        Me.colMaNguon.CFLShowLoad = False
        Me.colMaNguon.ChangeFormStatus = True
        Me.colMaNguon.ColumnKey = False
        Me.colMaNguon.ComboLine = 5
        Me.colMaNguon.CopyFromItem = ""
        Me.colMaNguon.DefaultButtonClick = False
        Me.colMaNguon.Digit = False
        Me.colMaNguon.FieldType = "C"
        Me.colMaNguon.FieldView = "MaNguon"
        Me.colMaNguon.FormarNumber = True
        Me.colMaNguon.FormList = False
        Me.colMaNguon.KeyInsert = ""
        Me.colMaNguon.LocalDecimal = False
        Me.colMaNguon.Name = "colMaNguon"
        Me.colMaNguon.NoUpdate = ""
        Me.colMaNguon.NumberDecimal = 0
        Me.colMaNguon.OptionsColumn.ReadOnly = True
        Me.colMaNguon.ParentControl = ""
        Me.colMaNguon.RefreshSource = False
        Me.colMaNguon.Required = False
        Me.colMaNguon.SequenceName = ""
        Me.colMaNguon.ShowCalc = True
        Me.colMaNguon.ShowDataTime = False
        Me.colMaNguon.ShowOnlyTime = False
        Me.colMaNguon.SQLString = ""
        Me.colMaNguon.UpdateIfNull = ""
        Me.colMaNguon.UpdateWhenFormLock = False
        Me.colMaNguon.UpperValue = False
        Me.colMaNguon.ValidateValue = True
        Me.colMaNguon.Visible = True
        Me.colMaNguon.VisibleIndex = 4
        Me.colMaNguon.Width = 50
        '
        'colMaKhachHang
        '
        Me.colMaKhachHang.AllowInsert = True
        Me.colMaKhachHang.AllowUpdate = True
        Me.colMaKhachHang.ButtonClick = True
        Me.colMaKhachHang.Caption = "Mã khách"
        Me.colMaKhachHang.CFLColumnHide = ""
        Me.colMaKhachHang.CFLKeyField = ""
        Me.colMaKhachHang.CFLPage = False
        Me.colMaKhachHang.CFLReturn0 = ""
        Me.colMaKhachHang.CFLReturn1 = ""
        Me.colMaKhachHang.CFLReturn2 = ""
        Me.colMaKhachHang.CFLReturn3 = ""
        Me.colMaKhachHang.CFLReturn4 = ""
        Me.colMaKhachHang.CFLReturn5 = ""
        Me.colMaKhachHang.CFLReturn6 = ""
        Me.colMaKhachHang.CFLReturn7 = ""
        Me.colMaKhachHang.CFLShowLoad = False
        Me.colMaKhachHang.ChangeFormStatus = True
        Me.colMaKhachHang.ColumnKey = False
        Me.colMaKhachHang.ComboLine = 5
        Me.colMaKhachHang.CopyFromItem = ""
        Me.colMaKhachHang.DefaultButtonClick = False
        Me.colMaKhachHang.Digit = False
        Me.colMaKhachHang.FieldType = "C"
        Me.colMaKhachHang.FieldView = "MaKhachHang"
        Me.colMaKhachHang.FormarNumber = True
        Me.colMaKhachHang.FormList = False
        Me.colMaKhachHang.KeyInsert = ""
        Me.colMaKhachHang.LocalDecimal = False
        Me.colMaKhachHang.Name = "colMaKhachHang"
        Me.colMaKhachHang.NoUpdate = ""
        Me.colMaKhachHang.NumberDecimal = 0
        Me.colMaKhachHang.OptionsColumn.ReadOnly = True
        Me.colMaKhachHang.ParentControl = ""
        Me.colMaKhachHang.RefreshSource = False
        Me.colMaKhachHang.Required = False
        Me.colMaKhachHang.SequenceName = ""
        Me.colMaKhachHang.ShowCalc = True
        Me.colMaKhachHang.ShowDataTime = False
        Me.colMaKhachHang.ShowOnlyTime = False
        Me.colMaKhachHang.SQLString = ""
        Me.colMaKhachHang.UpdateIfNull = ""
        Me.colMaKhachHang.UpdateWhenFormLock = False
        Me.colMaKhachHang.UpperValue = False
        Me.colMaKhachHang.ValidateValue = True
        Me.colMaKhachHang.Visible = True
        Me.colMaKhachHang.VisibleIndex = 5
        Me.colMaKhachHang.Width = 100
        '
        'colTenKhachHang
        '
        Me.colTenKhachHang.AllowInsert = True
        Me.colTenKhachHang.AllowUpdate = True
        Me.colTenKhachHang.ButtonClick = True
        Me.colTenKhachHang.Caption = "Tên khách"
        Me.colTenKhachHang.CFLColumnHide = ""
        Me.colTenKhachHang.CFLKeyField = ""
        Me.colTenKhachHang.CFLPage = False
        Me.colTenKhachHang.CFLReturn0 = ""
        Me.colTenKhachHang.CFLReturn1 = ""
        Me.colTenKhachHang.CFLReturn2 = ""
        Me.colTenKhachHang.CFLReturn3 = ""
        Me.colTenKhachHang.CFLReturn4 = ""
        Me.colTenKhachHang.CFLReturn5 = ""
        Me.colTenKhachHang.CFLReturn6 = ""
        Me.colTenKhachHang.CFLReturn7 = ""
        Me.colTenKhachHang.CFLShowLoad = False
        Me.colTenKhachHang.ChangeFormStatus = True
        Me.colTenKhachHang.ColumnKey = False
        Me.colTenKhachHang.ComboLine = 5
        Me.colTenKhachHang.CopyFromItem = ""
        Me.colTenKhachHang.DefaultButtonClick = False
        Me.colTenKhachHang.Digit = False
        Me.colTenKhachHang.FieldType = "C"
        Me.colTenKhachHang.FieldView = "TenKhachHang"
        Me.colTenKhachHang.FormarNumber = True
        Me.colTenKhachHang.FormList = False
        Me.colTenKhachHang.KeyInsert = ""
        Me.colTenKhachHang.LocalDecimal = False
        Me.colTenKhachHang.Name = "colTenKhachHang"
        Me.colTenKhachHang.NoUpdate = ""
        Me.colTenKhachHang.NumberDecimal = 0
        Me.colTenKhachHang.OptionsColumn.ReadOnly = True
        Me.colTenKhachHang.ParentControl = ""
        Me.colTenKhachHang.RefreshSource = False
        Me.colTenKhachHang.Required = False
        Me.colTenKhachHang.SequenceName = ""
        Me.colTenKhachHang.ShowCalc = True
        Me.colTenKhachHang.ShowDataTime = False
        Me.colTenKhachHang.ShowOnlyTime = False
        Me.colTenKhachHang.SQLString = ""
        Me.colTenKhachHang.UpdateIfNull = ""
        Me.colTenKhachHang.UpdateWhenFormLock = False
        Me.colTenKhachHang.UpperValue = False
        Me.colTenKhachHang.ValidateValue = True
        Me.colTenKhachHang.Visible = True
        Me.colTenKhachHang.VisibleIndex = 6
        Me.colTenKhachHang.Width = 400
        '
        'MaPhuongTien
        '
        Me.MaPhuongTien.AllowInsert = True
        Me.MaPhuongTien.AllowUpdate = True
        Me.MaPhuongTien.ButtonClick = True
        Me.MaPhuongTien.Caption = "Phương tiện"
        Me.MaPhuongTien.CFLColumnHide = ""
        Me.MaPhuongTien.CFLKeyField = ""
        Me.MaPhuongTien.CFLPage = False
        Me.MaPhuongTien.CFLReturn0 = ""
        Me.MaPhuongTien.CFLReturn1 = ""
        Me.MaPhuongTien.CFLReturn2 = ""
        Me.MaPhuongTien.CFLReturn3 = ""
        Me.MaPhuongTien.CFLReturn4 = ""
        Me.MaPhuongTien.CFLReturn5 = ""
        Me.MaPhuongTien.CFLReturn6 = ""
        Me.MaPhuongTien.CFLReturn7 = ""
        Me.MaPhuongTien.CFLShowLoad = False
        Me.MaPhuongTien.ChangeFormStatus = True
        Me.MaPhuongTien.ColumnKey = False
        Me.MaPhuongTien.ComboLine = 5
        Me.MaPhuongTien.CopyFromItem = ""
        Me.MaPhuongTien.DefaultButtonClick = False
        Me.MaPhuongTien.Digit = False
        Me.MaPhuongTien.FieldType = "C"
        Me.MaPhuongTien.FieldView = "MaPhuongTien"
        Me.MaPhuongTien.FormarNumber = True
        Me.MaPhuongTien.FormList = False
        Me.MaPhuongTien.KeyInsert = ""
        Me.MaPhuongTien.LocalDecimal = False
        Me.MaPhuongTien.Name = "MaPhuongTien"
        Me.MaPhuongTien.NoUpdate = ""
        Me.MaPhuongTien.NumberDecimal = 0
        Me.MaPhuongTien.OptionsColumn.ReadOnly = True
        Me.MaPhuongTien.ParentControl = ""
        Me.MaPhuongTien.RefreshSource = False
        Me.MaPhuongTien.Required = False
        Me.MaPhuongTien.SequenceName = ""
        Me.MaPhuongTien.ShowCalc = True
        Me.MaPhuongTien.ShowDataTime = False
        Me.MaPhuongTien.ShowOnlyTime = False
        Me.MaPhuongTien.SQLString = ""
        Me.MaPhuongTien.UpdateIfNull = ""
        Me.MaPhuongTien.UpdateWhenFormLock = False
        Me.MaPhuongTien.UpperValue = False
        Me.MaPhuongTien.ValidateValue = True
        Me.MaPhuongTien.Visible = True
        Me.MaPhuongTien.VisibleIndex = 7
        Me.MaPhuongTien.Width = 100
        '
        'sDesc
        '
        Me.sDesc.AllowInsert = True
        Me.sDesc.AllowUpdate = True
        Me.sDesc.ButtonClick = True
        Me.sDesc.Caption = "Ghi chú"
        Me.sDesc.CFLColumnHide = ""
        Me.sDesc.CFLKeyField = ""
        Me.sDesc.CFLPage = False
        Me.sDesc.CFLReturn0 = ""
        Me.sDesc.CFLReturn1 = ""
        Me.sDesc.CFLReturn2 = ""
        Me.sDesc.CFLReturn3 = ""
        Me.sDesc.CFLReturn4 = ""
        Me.sDesc.CFLReturn5 = ""
        Me.sDesc.CFLReturn6 = ""
        Me.sDesc.CFLReturn7 = ""
        Me.sDesc.CFLShowLoad = False
        Me.sDesc.ChangeFormStatus = True
        Me.sDesc.ColumnKey = False
        Me.sDesc.ComboLine = 5
        Me.sDesc.CopyFromItem = ""
        Me.sDesc.DefaultButtonClick = False
        Me.sDesc.Digit = False
        Me.sDesc.FieldType = "C"
        Me.sDesc.FieldView = "sDesc"
        Me.sDesc.FormarNumber = True
        Me.sDesc.FormList = False
        Me.sDesc.KeyInsert = ""
        Me.sDesc.LocalDecimal = False
        Me.sDesc.Name = "sDesc"
        Me.sDesc.NoUpdate = ""
        Me.sDesc.NumberDecimal = 0
        Me.sDesc.OptionsColumn.ReadOnly = True
        Me.sDesc.ParentControl = ""
        Me.sDesc.RefreshSource = False
        Me.sDesc.Required = False
        Me.sDesc.SequenceName = ""
        Me.sDesc.ShowCalc = True
        Me.sDesc.ShowDataTime = False
        Me.sDesc.ShowOnlyTime = False
        Me.sDesc.SQLString = ""
        Me.sDesc.UpdateIfNull = ""
        Me.sDesc.UpdateWhenFormLock = False
        Me.sDesc.UpperValue = False
        Me.sDesc.ValidateValue = True
        Me.sDesc.Visible = True
        Me.sDesc.VisibleIndex = 8
        Me.sDesc.Width = 350
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(117, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 19)
        Me.Label1.TabIndex = 475
        Me.Label1.Text = "Đến ngày"
        Me.Label1.Visible = False
        '
        'NgayXuatTo
        '
        Me.NgayXuatTo.AllowInsert = True
        Me.NgayXuatTo.AllowUpdate = True
        Me.NgayXuatTo.BindingSourceName = ""
        Me.NgayXuatTo.ChangeFormStatus = False
        Me.NgayXuatTo.CopyFromItem = ""
        Me.NgayXuatTo.DefaultValue = ""
        Me.NgayXuatTo.EditValue = Nothing
        Me.NgayXuatTo.FieldName = "NgayXuat"
        Me.NgayXuatTo.FieldType = "D"
        Me.NgayXuatTo.KeyInsert = ""
        Me.NgayXuatTo.LinkLabel = ""
        Me.NgayXuatTo.Location = New System.Drawing.Point(219, 70)
        Me.NgayXuatTo.Name = "NgayXuatTo"
        Me.NgayXuatTo.NoUpdate = ""
        Me.NgayXuatTo.PrimaryKey = ""
        Me.NgayXuatTo.Properties.AutoHeight = False
        Me.NgayXuatTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayXuatTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayXuatTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayXuatTo.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayXuatTo.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayXuatTo.Required = "Y"
        Me.NgayXuatTo.ShowDateTime = False
        Me.NgayXuatTo.Size = New System.Drawing.Size(150, 26)
        Me.NgayXuatTo.TabIndex = 474
        Me.NgayXuatTo.TableName = ""
        Me.NgayXuatTo.UpdateIfNull = ""
        Me.NgayXuatTo.UpdateWhenFormLock = False
        Me.NgayXuatTo.ViewName = ""
        Me.NgayXuatTo.Visible = False
        '
        'U_CheckBox1
        '
        Me.U_CheckBox1.AllowInsert = True
        Me.U_CheckBox1.AllowUpdate = True
        Me.U_CheckBox1.BindingSourceName = ""
        Me.U_CheckBox1.ChangeFormStatus = True
        Me.U_CheckBox1.CheckValue = "Y"
        Me.U_CheckBox1.CopyFromItem = ""
        Me.U_CheckBox1.DefaultValue = ""
        Me.U_CheckBox1.FieldName = ""
        Me.U_CheckBox1.FieldType = ""
        Me.U_CheckBox1.ItemValue = ""
        Me.U_CheckBox1.KeyInsert = ""
        Me.U_CheckBox1.LinkLabel = ""
        Me.U_CheckBox1.Location = New System.Drawing.Point(10, 65)
        Me.U_CheckBox1.Name = "U_CheckBox1"
        Me.U_CheckBox1.NoUpdate = ""
        Me.U_CheckBox1.PrimaryKey = ""
        Me.U_CheckBox1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.U_CheckBox1.Properties.Appearance.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.U_CheckBox1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_CheckBox1.Properties.AutoHeight = False
        Me.U_CheckBox1.Properties.Caption = "Chọn tất cả"
        Me.U_CheckBox1.Required = ""
        Me.U_CheckBox1.Size = New System.Drawing.Size(98, 30)
        Me.U_CheckBox1.TabIndex = 476
        Me.U_CheckBox1.TableName = ""
        Me.U_CheckBox1.UnCheckValue = "N"
        Me.U_CheckBox1.UpdateIfNull = ""
        Me.U_CheckBox1.UpdateWhenFormLock = False
        Me.U_CheckBox1.ViewName = ""
        '
        'TenKhachHang
        '
        Me.TenKhachHang.AllowInsert = False
        Me.TenKhachHang.AllowUpdate = False
        Me.TenKhachHang.AutoKeyFix = ""
        Me.TenKhachHang.AutoKeyName = ""
        Me.TenKhachHang.BindingSourceName = ""
        Me.TenKhachHang.ChangeFormStatus = True
        Me.TenKhachHang.CopyFromItem = ""
        Me.TenKhachHang.DefaultValue = ""
        Me.TenKhachHang.FieldName = "TenKhachHang"
        Me.TenKhachHang.FieldType = "C"
        Me.TenKhachHang.KeyInsert = ""
        Me.TenKhachHang.LinkLabel = ""
        Me.TenKhachHang.Location = New System.Drawing.Point(622, 41)
        Me.TenKhachHang.Name = "TenKhachHang"
        Me.TenKhachHang.NoUpdate = "N"
        Me.TenKhachHang.PrimaryKey = ""
        Me.TenKhachHang.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TenKhachHang.Properties.Appearance.Options.UseFont = True
        Me.TenKhachHang.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TenKhachHang.Properties.AppearanceDisabled.Options.UseFont = True
        Me.TenKhachHang.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TenKhachHang.Properties.AppearanceFocused.Options.UseFont = True
        Me.TenKhachHang.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TenKhachHang.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.TenKhachHang.Properties.AutoHeight = False
        Me.TenKhachHang.Properties.ReadOnly = True
        Me.TenKhachHang.Required = ""
        Me.TenKhachHang.Size = New System.Drawing.Size(335, 26)
        Me.TenKhachHang.TabIndex = 479
        Me.TenKhachHang.TableName = ""
        Me.TenKhachHang.UpdateIfNull = ""
        Me.TenKhachHang.UpdateWhenFormLock = False
        Me.TenKhachHang.UpperValue = False
        Me.TenKhachHang.ViewName = "FPT_tblLenhXuatE5_New_V"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(380, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 19)
        Me.Label6.TabIndex = 478
        Me.Label6.Text = "Khách hàng"
        '
        'MaKhachHang
        '
        Me.MaKhachHang.AllowInsert = True
        Me.MaKhachHang.AllowUpdate = True
        Me.MaKhachHang.AutoWidth = False
        Me.MaKhachHang.BindingSourceName = ""
        Me.MaKhachHang.ChangeFormStatus = True
        Me.MaKhachHang.CopyFromItem = ""
        Me.MaKhachHang.DefaultButtonClick = True
        Me.MaKhachHang.DefaultValue = ""
        Me.MaKhachHang.FieldName = "MaKhachHang"
        Me.MaKhachHang.FieldType = "C"
        Me.MaKhachHang.FormList = False
        Me.MaKhachHang.ItemReturn1 = "TenKhachHang"
        Me.MaKhachHang.ItemReturn2 = ""
        Me.MaKhachHang.ItemReturn3 = ""
        Me.MaKhachHang.KeyInsert = ""
        Me.MaKhachHang.LinkLabel = "Label6"
        Me.MaKhachHang.Location = New System.Drawing.Point(477, 41)
        Me.MaKhachHang.MultiSelect = False
        Me.MaKhachHang.Name = "MaKhachHang"
        Me.MaKhachHang.NoUpdate = "N"
        Me.MaKhachHang.OrderbyEx = ""
        Me.MaKhachHang.PrimaryKey = ""
        Me.MaKhachHang.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaKhachHang.Properties.Appearance.Options.UseFont = True
        Me.MaKhachHang.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaKhachHang.Properties.AppearanceDisabled.Options.UseFont = True
        Me.MaKhachHang.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaKhachHang.Properties.AppearanceFocused.Options.UseFont = True
        Me.MaKhachHang.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaKhachHang.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.MaKhachHang.Properties.AutoHeight = False
        Me.MaKhachHang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.MaKhachHang.Required = "Y"
        Me.MaKhachHang.ShowLoad = True
        Me.MaKhachHang.Size = New System.Drawing.Size(144, 26)
        Me.MaKhachHang.SqlFielKey = "MaKhachHang"
        Me.MaKhachHang.SqlString = "select MaKhachHang ,TenKhachHang  from tblKhachHang where Status='X'"
        Me.MaKhachHang.TabIndex = 477
        Me.MaKhachHang.TableName = "tblLenhXuatE5"
        Me.MaKhachHang.UpdateIfNull = ""
        Me.MaKhachHang.UpdateWhenFormLock = False
        Me.MaKhachHang.UpperValue = False
        Me.MaKhachHang.ValidateValue = True
        Me.MaKhachHang.ViewName = "FPT_tblLenhXuatE5_New_V"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(375, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 19)
        Me.Label9.TabIndex = 481
        Me.Label9.Text = "Nguồn hàng"
        '
        'MaNguon
        '
        Me.MaNguon.AllowInsert = True
        Me.MaNguon.AllowUpdate = True
        Me.MaNguon.AutoWidth = False
        Me.MaNguon.BindingSourceName = ""
        Me.MaNguon.ChangeFormStatus = True
        Me.MaNguon.CopyFromItem = ""
        Me.MaNguon.DefaultButtonClick = True
        Me.MaNguon.DefaultValue = ""
        Me.MaNguon.FieldName = "MaNguon"
        Me.MaNguon.FieldType = "C"
        Me.MaNguon.FormList = False
        Me.MaNguon.ItemReturn1 = "TenNguon"
        Me.MaNguon.ItemReturn2 = ""
        Me.MaNguon.ItemReturn3 = ""
        Me.MaNguon.KeyInsert = ""
        Me.MaNguon.LinkLabel = "Label9"
        Me.MaNguon.Location = New System.Drawing.Point(477, 73)
        Me.MaNguon.MultiSelect = False
        Me.MaNguon.Name = "MaNguon"
        Me.MaNguon.NoUpdate = "N"
        Me.MaNguon.OrderbyEx = ""
        Me.MaNguon.PrimaryKey = ""
        Me.MaNguon.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaNguon.Properties.Appearance.Options.UseFont = True
        Me.MaNguon.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaNguon.Properties.AppearanceDisabled.Options.UseFont = True
        Me.MaNguon.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaNguon.Properties.AppearanceFocused.Options.UseFont = True
        Me.MaNguon.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.MaNguon.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.MaNguon.Properties.AutoHeight = False
        Me.MaNguon.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.MaNguon.Required = "Y"
        Me.MaNguon.ShowLoad = True
        Me.MaNguon.Size = New System.Drawing.Size(144, 26)
        Me.MaNguon.SqlFielKey = "MaNguon"
        Me.MaNguon.SqlString = "SELECT MaNguon, TenNguon FROM tblNguon where Status='X'"
        Me.MaNguon.TabIndex = 480
        Me.MaNguon.TableName = "tblLenhXuatE5"
        Me.MaNguon.UpdateIfNull = ""
        Me.MaNguon.UpdateWhenFormLock = False
        Me.MaNguon.UpperValue = True
        Me.MaNguon.ValidateValue = True
        Me.MaNguon.ViewName = "FPT_tblLenhXuatE5_New_V"
        '
        'U_ButtonCus2
        '
        Me.U_ButtonCus2.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.U_ButtonCus2.Appearance.Options.UseFont = True
        Me.U_ButtonCus2.DefaultUpdate = True
        Me.U_ButtonCus2.EnableWhenFormLock = False
        Me.U_ButtonCus2.Location = New System.Drawing.Point(742, 70)
        Me.U_ButtonCus2.Name = "U_ButtonCus2"
        Me.U_ButtonCus2.Size = New System.Drawing.Size(164, 33)
        Me.U_ButtonCus2.TabIndex = 482
        Me.U_ButtonCus2.Text = "Test tích hợp ngược"
        '
        'FrmSoLenhAuto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1130, 631)
        Me.Controls.Add(Me.U_ButtonCus2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.MaNguon)
        Me.Controls.Add(Me.TenKhachHang)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.MaKhachHang)
        Me.Controls.Add(Me.U_CheckBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NgayXuatTo)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NgayXuat)
        Me.Controls.Add(Me.ToolStrip2)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmSoLenhAuto"
        Me.ShowFormMessage = True
        Me.Text = "Rút lệnh xuất hàng loạt"
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.NgayXuat, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.NgayXuatTo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.U_CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.MaKhachHang, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.TenKhachHang, 0)
        Me.Controls.SetChildIndex(Me.MaNguon, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuatTo.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuatTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CheckBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TenKhachHang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaKhachHang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaNguon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NgayXuat As U_TextBox.U_DateEdit
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents X As U_TextBox.GridColumn
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents SoLenh As U_TextBox.GridColumn
    Friend WithEvents NgayThang As U_TextBox.GridColumn
    Friend WithEvents sDesc As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents sStatus As U_TextBox.GridColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NgayXuatTo As U_TextBox.U_DateEdit
    Friend WithEvents U_CheckBox1 As U_TextBox.U_CheckBox
    Friend WithEvents TenKhachHang As U_TextBox.U_TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MaKhachHang As U_TextBox.U_ButtonEdit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents MaNguon As U_TextBox.U_ButtonEdit
    Friend WithEvents colMaNguon As U_TextBox.GridColumn
    Friend WithEvents colMaKhachHang As U_TextBox.GridColumn
    Friend WithEvents colTenKhachHang As U_TextBox.GridColumn
    Friend WithEvents MaPhuongTien As U_TextBox.GridColumn
    Friend WithEvents U_ButtonCus2 As U_TextBox.U_ButtonCus
End Class
