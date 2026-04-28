<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQuanLyHuyTK
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NgayXuat = New U_TextBox.U_DateEdit()
        Me.SimpleButton7 = New U_TextBox.U_ButtonCus(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SoTichKe = New U_TextBox.U_TextBox()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ColSoLenh = New U_TextBox.GridColumn()
        Me.MaPhuongTien = New U_TextBox.GridColumn()
        Me.MaNguon = New U_TextBox.GridColumn()
        Me.TenKhachHang = New U_TextBox.GridColumn()
        Me.Client = New U_TextBox.GridColumn()
        Me.MaVanChuyen = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoTichKe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 19)
        Me.Label2.TabIndex = 200
        Me.Label2.Text = "Ngày tháng"
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
        Me.NgayXuat.FieldName = ""
        Me.NgayXuat.FieldType = "D"
        Me.NgayXuat.KeyInsert = ""
        Me.NgayXuat.LinkLabel = ""
        Me.NgayXuat.Location = New System.Drawing.Point(120, 12)
        Me.NgayXuat.Name = "NgayXuat"
        Me.NgayXuat.NoUpdate = ""
        Me.NgayXuat.PrimaryKey = ""
        Me.NgayXuat.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.Appearance.Options.UseFont = True
        Me.NgayXuat.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.AppearanceDisabled.Options.UseFont = True
        Me.NgayXuat.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.AppearanceFocused.Options.UseFont = True
        Me.NgayXuat.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.NgayXuat.Properties.AutoHeight = False
        Me.NgayXuat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayXuat.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayXuat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayXuat.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayXuat.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayXuat.Required = ""
        Me.NgayXuat.ShowDateTime = False
        Me.NgayXuat.Size = New System.Drawing.Size(137, 26)
        Me.NgayXuat.TabIndex = 199
        Me.NgayXuat.TableName = ""
        Me.NgayXuat.TabStop = False
        Me.NgayXuat.UpdateIfNull = ""
        Me.NgayXuat.UpdateWhenFormLock = True
        Me.NgayXuat.ViewName = ""
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.DefaultUpdate = True
        Me.SimpleButton7.EnableWhenFormLock = True
        Me.SimpleButton7.Location = New System.Drawing.Point(507, 9)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(121, 29)
        Me.SimpleButton7.TabIndex = 201
        Me.SimpleButton7.Text = "&Tìm kiếm"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(296, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 19)
        Me.Label3.TabIndex = 205
        Me.Label3.Text = "Số tích kê"
        '
        'SoTichKe
        '
        Me.SoTichKe.AllowInsert = True
        Me.SoTichKe.AllowUpdate = True
        Me.SoTichKe.AutoKeyFix = ""
        Me.SoTichKe.AutoKeyName = ""
        Me.SoTichKe.BindingSourceName = ""
        Me.SoTichKe.ChangeFormStatus = False
        Me.SoTichKe.CopyFromItem = ""
        Me.SoTichKe.DefaultValue = ""
        Me.SoTichKe.FieldName = ""
        Me.SoTichKe.FieldType = ""
        Me.SoTichKe.KeyInsert = ""
        Me.SoTichKe.LinkLabel = ""
        Me.SoTichKe.Location = New System.Drawing.Point(380, 12)
        Me.SoTichKe.Name = "SoTichKe"
        Me.SoTichKe.NoUpdate = "N"
        Me.SoTichKe.PrimaryKey = ""
        Me.SoTichKe.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoTichKe.Properties.Appearance.Options.UseFont = True
        Me.SoTichKe.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoTichKe.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SoTichKe.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoTichKe.Properties.AppearanceFocused.Options.UseFont = True
        Me.SoTichKe.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoTichKe.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SoTichKe.Properties.AutoHeight = False
        Me.SoTichKe.Properties.MaxLength = 10
        Me.SoTichKe.Required = ""
        Me.SoTichKe.Size = New System.Drawing.Size(106, 26)
        Me.SoTichKe.TabIndex = 0
        Me.SoTichKe.TableName = ""
        Me.SoTichKe.UpdateIfNull = ""
        Me.SoTichKe.UpdateWhenFormLock = True
        Me.SoTichKe.UpperValue = False
        Me.SoTichKe.ViewName = ""
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(0, 50)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(792, 275)
        Me.TrueDBGrid1.TabIndex = 206
        Me.TrueDBGrid1.TabStop = False
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.DetailTip.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.Empty.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.EvenRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FilterPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FocusedRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.GroupButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.GroupFooter.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.GroupPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.HorzLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.OddRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.Preview.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.RowSeparator.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.SelectedRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.TopNewRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.VertLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.ViewCaption.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = True
        Me.GridView1.ColumnKey = "SoLenh"
        Me.GridView1.ColumnKeyIns = False
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColSoLenh, Me.MaPhuongTien, Me.MaNguon, Me.TenKhachHang, Me.Client, Me.MaVanChuyen})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = False
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "SoLenh"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "FPT_tblLenhXuatE5_V"
        Me.GridView1.Where = Nothing
        '
        'ColSoLenh
        '
        Me.ColSoLenh.AllowInsert = True
        Me.ColSoLenh.AllowUpdate = True
        Me.ColSoLenh.ButtonClick = True
        Me.ColSoLenh.Caption = "Số lệnh"
        Me.ColSoLenh.CFLColumnHide = ""
        Me.ColSoLenh.CFLKeyField = ""
        Me.ColSoLenh.CFLPage = False
        Me.ColSoLenh.CFLReturn0 = ""
        Me.ColSoLenh.CFLReturn1 = ""
        Me.ColSoLenh.CFLReturn2 = ""
        Me.ColSoLenh.CFLReturn3 = ""
        Me.ColSoLenh.CFLReturn4 = ""
        Me.ColSoLenh.CFLReturn5 = ""
        Me.ColSoLenh.CFLReturn6 = ""
        Me.ColSoLenh.CFLReturn7 = ""
        Me.ColSoLenh.CFLShowLoad = False
        Me.ColSoLenh.ChangeFormStatus = True
        Me.ColSoLenh.ColumnKey = False
        Me.ColSoLenh.ComboLine = 5
        Me.ColSoLenh.CopyFromItem = ""
        Me.ColSoLenh.DefaultButtonClick = False
        Me.ColSoLenh.Digit = False
        Me.ColSoLenh.FieldType = "C"
        Me.ColSoLenh.FieldView = "SoLenh"
        Me.ColSoLenh.FormarNumber = True
        Me.ColSoLenh.FormList = False
        Me.ColSoLenh.KeyInsert = ""
        Me.ColSoLenh.LocalDecimal = False
        Me.ColSoLenh.Name = "ColSoLenh"
        Me.ColSoLenh.NoUpdate = ""
        Me.ColSoLenh.NumberDecimal = 0
        Me.ColSoLenh.OptionsColumn.AllowEdit = False
        Me.ColSoLenh.OptionsColumn.ReadOnly = True
        Me.ColSoLenh.ParentControl = ""
        Me.ColSoLenh.RefreshSource = False
        Me.ColSoLenh.Required = False
        Me.ColSoLenh.SequenceName = ""
        Me.ColSoLenh.ShowCalc = True
        Me.ColSoLenh.ShowDataTime = False
        Me.ColSoLenh.ShowOnlyTime = False
        Me.ColSoLenh.SQLString = ""
        Me.ColSoLenh.UpdateIfNull = ""
        Me.ColSoLenh.UpdateWhenFormLock = False
        Me.ColSoLenh.UpperValue = False
        Me.ColSoLenh.ValidateValue = True
        Me.ColSoLenh.Visible = True
        Me.ColSoLenh.VisibleIndex = 0
        Me.ColSoLenh.Width = 120
        '
        'MaPhuongTien
        '
        Me.MaPhuongTien.AllowInsert = True
        Me.MaPhuongTien.AllowUpdate = True
        Me.MaPhuongTien.ButtonClick = True
        Me.MaPhuongTien.Caption = "Phương tiện"
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
        Me.MaPhuongTien.OptionsColumn.AllowEdit = False
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
        Me.MaPhuongTien.VisibleIndex = 1
        Me.MaPhuongTien.Width = 120
        '
        'MaNguon
        '
        Me.MaNguon.AllowInsert = True
        Me.MaNguon.AllowUpdate = True
        Me.MaNguon.ButtonClick = True
        Me.MaNguon.Caption = "Nguồn hàng"
        Me.MaNguon.CFLColumnHide = ""
        Me.MaNguon.CFLKeyField = ""
        Me.MaNguon.CFLPage = False
        Me.MaNguon.CFLReturn0 = ""
        Me.MaNguon.CFLReturn1 = ""
        Me.MaNguon.CFLReturn2 = ""
        Me.MaNguon.CFLReturn3 = ""
        Me.MaNguon.CFLReturn4 = ""
        Me.MaNguon.CFLReturn5 = ""
        Me.MaNguon.CFLReturn6 = ""
        Me.MaNguon.CFLReturn7 = ""
        Me.MaNguon.CFLShowLoad = False
        Me.MaNguon.ChangeFormStatus = True
        Me.MaNguon.ColumnKey = False
        Me.MaNguon.ComboLine = 5
        Me.MaNguon.CopyFromItem = ""
        Me.MaNguon.DefaultButtonClick = False
        Me.MaNguon.Digit = False
        Me.MaNguon.FieldType = "C"
        Me.MaNguon.FieldView = "MaNguon"
        Me.MaNguon.FormarNumber = True
        Me.MaNguon.FormList = False
        Me.MaNguon.KeyInsert = ""
        Me.MaNguon.LocalDecimal = False
        Me.MaNguon.Name = "MaNguon"
        Me.MaNguon.NoUpdate = ""
        Me.MaNguon.NumberDecimal = 0
        Me.MaNguon.OptionsColumn.ReadOnly = True
        Me.MaNguon.ParentControl = ""
        Me.MaNguon.RefreshSource = False
        Me.MaNguon.Required = False
        Me.MaNguon.SequenceName = ""
        Me.MaNguon.ShowCalc = True
        Me.MaNguon.ShowDataTime = False
        Me.MaNguon.ShowOnlyTime = False
        Me.MaNguon.SQLString = ""
        Me.MaNguon.UpdateIfNull = ""
        Me.MaNguon.UpdateWhenFormLock = False
        Me.MaNguon.UpperValue = False
        Me.MaNguon.ValidateValue = True
        Me.MaNguon.Visible = True
        Me.MaNguon.VisibleIndex = 2
        Me.MaNguon.Width = 120
        '
        'TenKhachHang
        '
        Me.TenKhachHang.AllowInsert = True
        Me.TenKhachHang.AllowUpdate = True
        Me.TenKhachHang.ButtonClick = True
        Me.TenKhachHang.Caption = "Khách hàng"
        Me.TenKhachHang.CFLColumnHide = ""
        Me.TenKhachHang.CFLKeyField = ""
        Me.TenKhachHang.CFLPage = False
        Me.TenKhachHang.CFLReturn0 = ""
        Me.TenKhachHang.CFLReturn1 = ""
        Me.TenKhachHang.CFLReturn2 = ""
        Me.TenKhachHang.CFLReturn3 = ""
        Me.TenKhachHang.CFLReturn4 = ""
        Me.TenKhachHang.CFLReturn5 = ""
        Me.TenKhachHang.CFLReturn6 = ""
        Me.TenKhachHang.CFLReturn7 = ""
        Me.TenKhachHang.CFLShowLoad = False
        Me.TenKhachHang.ChangeFormStatus = True
        Me.TenKhachHang.ColumnKey = False
        Me.TenKhachHang.ComboLine = 5
        Me.TenKhachHang.CopyFromItem = ""
        Me.TenKhachHang.DefaultButtonClick = False
        Me.TenKhachHang.Digit = False
        Me.TenKhachHang.FieldType = "C"
        Me.TenKhachHang.FieldView = "TenKhachHang"
        Me.TenKhachHang.FormarNumber = True
        Me.TenKhachHang.FormList = False
        Me.TenKhachHang.KeyInsert = ""
        Me.TenKhachHang.LocalDecimal = False
        Me.TenKhachHang.Name = "TenKhachHang"
        Me.TenKhachHang.NoUpdate = ""
        Me.TenKhachHang.NumberDecimal = 0
        Me.TenKhachHang.OptionsColumn.AllowEdit = False
        Me.TenKhachHang.OptionsColumn.ReadOnly = True
        Me.TenKhachHang.ParentControl = ""
        Me.TenKhachHang.RefreshSource = False
        Me.TenKhachHang.Required = False
        Me.TenKhachHang.SequenceName = ""
        Me.TenKhachHang.ShowCalc = True
        Me.TenKhachHang.ShowDataTime = False
        Me.TenKhachHang.ShowOnlyTime = False
        Me.TenKhachHang.SQLString = ""
        Me.TenKhachHang.UpdateIfNull = ""
        Me.TenKhachHang.UpdateWhenFormLock = False
        Me.TenKhachHang.UpperValue = False
        Me.TenKhachHang.ValidateValue = True
        Me.TenKhachHang.Visible = True
        Me.TenKhachHang.VisibleIndex = 3
        Me.TenKhachHang.Width = 380
        '
        'Client
        '
        Me.Client.AllowInsert = True
        Me.Client.AllowUpdate = True
        Me.Client.ButtonClick = True
        Me.Client.Caption = "Kho"
        Me.Client.CFLColumnHide = ""
        Me.Client.CFLKeyField = ""
        Me.Client.CFLPage = False
        Me.Client.CFLReturn0 = ""
        Me.Client.CFLReturn1 = ""
        Me.Client.CFLReturn2 = ""
        Me.Client.CFLReturn3 = ""
        Me.Client.CFLReturn4 = ""
        Me.Client.CFLReturn5 = ""
        Me.Client.CFLReturn6 = ""
        Me.Client.CFLReturn7 = ""
        Me.Client.CFLShowLoad = False
        Me.Client.ChangeFormStatus = True
        Me.Client.ColumnKey = False
        Me.Client.ComboLine = 5
        Me.Client.CopyFromItem = ""
        Me.Client.DefaultButtonClick = False
        Me.Client.Digit = False
        Me.Client.FieldType = "C"
        Me.Client.FieldView = "Client"
        Me.Client.FormarNumber = True
        Me.Client.FormList = False
        Me.Client.KeyInsert = ""
        Me.Client.LocalDecimal = False
        Me.Client.Name = "Client"
        Me.Client.NoUpdate = ""
        Me.Client.NumberDecimal = 0
        Me.Client.OptionsColumn.ReadOnly = True
        Me.Client.ParentControl = ""
        Me.Client.RefreshSource = False
        Me.Client.Required = False
        Me.Client.SequenceName = ""
        Me.Client.ShowCalc = True
        Me.Client.ShowDataTime = False
        Me.Client.ShowOnlyTime = False
        Me.Client.SQLString = ""
        Me.Client.UpdateIfNull = ""
        Me.Client.UpdateWhenFormLock = False
        Me.Client.UpperValue = False
        Me.Client.ValidateValue = True
        Me.Client.Visible = True
        Me.Client.VisibleIndex = 4
        Me.Client.Width = 100
        '
        'MaVanChuyen
        '
        Me.MaVanChuyen.AllowInsert = True
        Me.MaVanChuyen.AllowUpdate = True
        Me.MaVanChuyen.ButtonClick = True
        Me.MaVanChuyen.Caption = "LH Vận tải"
        Me.MaVanChuyen.CFLColumnHide = ""
        Me.MaVanChuyen.CFLKeyField = ""
        Me.MaVanChuyen.CFLPage = False
        Me.MaVanChuyen.CFLReturn0 = ""
        Me.MaVanChuyen.CFLReturn1 = ""
        Me.MaVanChuyen.CFLReturn2 = ""
        Me.MaVanChuyen.CFLReturn3 = ""
        Me.MaVanChuyen.CFLReturn4 = ""
        Me.MaVanChuyen.CFLReturn5 = ""
        Me.MaVanChuyen.CFLReturn6 = ""
        Me.MaVanChuyen.CFLReturn7 = ""
        Me.MaVanChuyen.CFLShowLoad = False
        Me.MaVanChuyen.ChangeFormStatus = True
        Me.MaVanChuyen.ColumnKey = False
        Me.MaVanChuyen.ComboLine = 5
        Me.MaVanChuyen.CopyFromItem = ""
        Me.MaVanChuyen.DefaultButtonClick = False
        Me.MaVanChuyen.Digit = False
        Me.MaVanChuyen.FieldType = "C"
        Me.MaVanChuyen.FieldView = "MaVanChuyen"
        Me.MaVanChuyen.FormarNumber = True
        Me.MaVanChuyen.FormList = False
        Me.MaVanChuyen.KeyInsert = ""
        Me.MaVanChuyen.LocalDecimal = False
        Me.MaVanChuyen.Name = "MaVanChuyen"
        Me.MaVanChuyen.NoUpdate = ""
        Me.MaVanChuyen.NumberDecimal = 0
        Me.MaVanChuyen.OptionsColumn.ReadOnly = True
        Me.MaVanChuyen.ParentControl = ""
        Me.MaVanChuyen.RefreshSource = False
        Me.MaVanChuyen.Required = False
        Me.MaVanChuyen.SequenceName = ""
        Me.MaVanChuyen.ShowCalc = True
        Me.MaVanChuyen.ShowDataTime = False
        Me.MaVanChuyen.ShowOnlyTime = False
        Me.MaVanChuyen.SQLString = ""
        Me.MaVanChuyen.UpdateIfNull = ""
        Me.MaVanChuyen.UpdateWhenFormLock = False
        Me.MaVanChuyen.UpperValue = False
        Me.MaVanChuyen.ValidateValue = True
        Me.MaVanChuyen.Visible = True
        Me.MaVanChuyen.VisibleIndex = 5
        Me.MaVanChuyen.Width = 120
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = True
        Me.U_ButtonCus1.Location = New System.Drawing.Point(12, 331)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(134, 29)
        Me.U_ButtonCus1.TabIndex = 207
        Me.U_ButtonCus1.Text = "&Hủy tích kê"
        '
        'FrmQuanLyHuyTK
        '
        Me.AcceptButton = Me.SimpleButton7
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 372)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SoTichKe)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NgayXuat)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmQuanLyHuyTK"
        Me.Text = "Thông tin Hủy tích kê"
        Me.Controls.SetChildIndex(Me.NgayXuat, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton7, 0)
        Me.Controls.SetChildIndex(Me.SoTichKe, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoTichKe.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NgayXuat As U_TextBox.U_DateEdit
    Friend WithEvents SimpleButton7 As U_TextBox.U_ButtonCus
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SoTichKe As U_TextBox.U_TextBox
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ColSoLenh As U_TextBox.GridColumn
    Friend WithEvents MaNguon As U_TextBox.GridColumn
    Friend WithEvents TenKhachHang As U_TextBox.GridColumn
    Friend WithEvents MaPhuongTien As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents Client As U_TextBox.GridColumn
    Friend WithEvents MaVanChuyen As U_TextBox.GridColumn
End Class
