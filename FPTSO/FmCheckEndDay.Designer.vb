<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FmCheckEndDay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FmCheckEndDay))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.X = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Client = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NgayTichKe = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SoTichKe = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MaPhuongTien = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GioTichKe = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GioVaoKho = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SoLenh = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NgayHieuLuc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NgayHetHieuLuc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MaNgan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DungTich = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MaHangHoa = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SoLuongDuXuat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GhiChu = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LoaiXuat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SMO_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.U_CheckBox1 = New U_TextBox.U_CheckBox()
        Me.U_ButtonCus2 = New U_TextBox.U_ButtonCus(Me.components)
        Me.U_Label1 = New U_TextBox.U_Label()
        Me.U_Label2 = New U_TextBox.U_Label()
        Me.U_Combobox1 = New U_TextBox.U_Combobox()
        Me.U_ComboboxClient = New U_TextBox.U_Combobox()
        Me.U_Label3 = New U_TextBox.U_Label()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CheckBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_Combobox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ComboboxClient.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(0, 39)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(906, 436)
        Me.TrueDBGrid1.TabIndex = 2
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.FooterPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.X, Me.Client, Me.NgayTichKe, Me.SoTichKe, Me.MaPhuongTien, Me.GioTichKe, Me.GioVaoKho, Me.SoLenh, Me.NgayHieuLuc, Me.NgayHetHieuLuc, Me.MaNgan, Me.DungTich, Me.MaHangHoa, Me.SoLuongDuXuat, Me.GhiChu, Me.LoaiXuat, Me.SMO_ID})
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        '
        'X
        '
        Me.X.Caption = "X"
        Me.X.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.X.Name = "X"
        Me.X.Visible = True
        Me.X.VisibleIndex = 0
        Me.X.Width = 20
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Y"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "N"
        '
        'Client
        '
        Me.Client.Caption = "Kho"
        Me.Client.Name = "Client"
        Me.Client.OptionsColumn.ReadOnly = True
        Me.Client.Visible = True
        Me.Client.VisibleIndex = 1
        Me.Client.Width = 50
        '
        'NgayTichKe
        '
        Me.NgayTichKe.Caption = "Ngày tích kê"
        Me.NgayTichKe.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayTichKe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.NgayTichKe.FieldName = "NgayTichKe"
        Me.NgayTichKe.Name = "NgayTichKe"
        Me.NgayTichKe.OptionsColumn.ReadOnly = True
        Me.NgayTichKe.UnboundType = DevExpress.Data.UnboundColumnType.DateTime
        Me.NgayTichKe.Visible = True
        Me.NgayTichKe.VisibleIndex = 2
        Me.NgayTichKe.Width = 100
        '
        'SoTichKe
        '
        Me.SoTichKe.Caption = "Số tích kê"
        Me.SoTichKe.Name = "SoTichKe"
        Me.SoTichKe.OptionsColumn.ReadOnly = True
        Me.SoTichKe.Visible = True
        Me.SoTichKe.VisibleIndex = 3
        '
        'MaPhuongTien
        '
        Me.MaPhuongTien.Caption = "Phương tiện"
        Me.MaPhuongTien.Name = "MaPhuongTien"
        Me.MaPhuongTien.OptionsColumn.ReadOnly = True
        Me.MaPhuongTien.Visible = True
        Me.MaPhuongTien.VisibleIndex = 4
        Me.MaPhuongTien.Width = 100
        '
        'GioTichKe
        '
        Me.GioTichKe.Caption = "Giờ tích kê"
        Me.GioTichKe.Name = "GioTichKe"
        Me.GioTichKe.OptionsColumn.ReadOnly = True
        Me.GioTichKe.Visible = True
        Me.GioTichKe.VisibleIndex = 5
        Me.GioTichKe.Width = 90
        '
        'GioVaoKho
        '
        Me.GioVaoKho.Caption = "Giờ vào kho"
        Me.GioVaoKho.Name = "GioVaoKho"
        Me.GioVaoKho.OptionsColumn.ReadOnly = True
        Me.GioVaoKho.Visible = True
        Me.GioVaoKho.VisibleIndex = 6
        Me.GioVaoKho.Width = 90
        '
        'SoLenh
        '
        Me.SoLenh.Caption = "Lệnh Xuất"
        Me.SoLenh.Name = "SoLenh"
        Me.SoLenh.OptionsColumn.ReadOnly = True
        Me.SoLenh.Visible = True
        Me.SoLenh.VisibleIndex = 7
        Me.SoLenh.Width = 90
        '
        'NgayHieuLuc
        '
        Me.NgayHieuLuc.Caption = "Ngày hiệu lực"
        Me.NgayHieuLuc.Name = "NgayHieuLuc"
        Me.NgayHieuLuc.OptionsColumn.ReadOnly = True
        Me.NgayHieuLuc.Visible = True
        Me.NgayHieuLuc.VisibleIndex = 8
        Me.NgayHieuLuc.Width = 110
        '
        'NgayHetHieuLuc
        '
        Me.NgayHetHieuLuc.Caption = "Ngày hết hiệu lực"
        Me.NgayHetHieuLuc.Name = "NgayHetHieuLuc"
        Me.NgayHetHieuLuc.OptionsColumn.ReadOnly = True
        Me.NgayHetHieuLuc.Visible = True
        Me.NgayHetHieuLuc.VisibleIndex = 9
        Me.NgayHetHieuLuc.Width = 140
        '
        'MaNgan
        '
        Me.MaNgan.Caption = "Mã ngăn"
        Me.MaNgan.Name = "MaNgan"
        Me.MaNgan.OptionsColumn.ReadOnly = True
        Me.MaNgan.Visible = True
        Me.MaNgan.VisibleIndex = 10
        '
        'DungTich
        '
        Me.DungTich.Caption = "Dung tích"
        Me.DungTich.DisplayFormat.FormatString = "###,###,###,###"
        Me.DungTich.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.DungTich.Name = "DungTich"
        Me.DungTich.OptionsColumn.ReadOnly = True
        Me.DungTich.Visible = True
        Me.DungTich.VisibleIndex = 11
        Me.DungTich.Width = 120
        '
        'MaHangHoa
        '
        Me.MaHangHoa.Caption = "Mã hàng"
        Me.MaHangHoa.Name = "MaHangHoa"
        Me.MaHangHoa.OptionsColumn.ReadOnly = True
        Me.MaHangHoa.Visible = True
        Me.MaHangHoa.VisibleIndex = 12
        '
        'SoLuongDuXuat
        '
        Me.SoLuongDuXuat.Caption = "Số dự xuất"
        Me.SoLuongDuXuat.DisplayFormat.FormatString = "###,###,###,###"
        Me.SoLuongDuXuat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SoLuongDuXuat.Name = "SoLuongDuXuat"
        Me.SoLuongDuXuat.OptionsColumn.ReadOnly = True
        Me.SoLuongDuXuat.Visible = True
        Me.SoLuongDuXuat.VisibleIndex = 13
        Me.SoLuongDuXuat.Width = 120
        '
        'GhiChu
        '
        Me.GhiChu.Caption = "Ghi chú"
        Me.GhiChu.Name = "GhiChu"
        Me.GhiChu.OptionsColumn.ReadOnly = True
        Me.GhiChu.Visible = True
        Me.GhiChu.VisibleIndex = 14
        Me.GhiChu.Width = 230
        '
        'LoaiXuat
        '
        Me.LoaiXuat.Caption = "Loại"
        Me.LoaiXuat.Name = "LoaiXuat"
        Me.LoaiXuat.OptionsColumn.ReadOnly = True
        Me.LoaiXuat.Visible = True
        Me.LoaiXuat.VisibleIndex = 15
        '
        'SMO_ID
        '
        Me.SMO_ID.Caption = "SMO ID"
        Me.SMO_ID.Name = "SMO_ID"
        Me.SMO_ID.OptionsColumn.ReadOnly = True
        Me.SMO_ID.Visible = True
        Me.SMO_ID.VisibleIndex = 16
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Image = CType(resources.GetObject("U_ButtonCus1.Image"), System.Drawing.Image)
        Me.U_ButtonCus1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.U_ButtonCus1.Location = New System.Drawing.Point(769, 3)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(137, 30)
        Me.U_ButtonCus1.TabIndex = 474
        Me.U_ButtonCus1.TabStop = False
        Me.U_ButtonCus1.Text = "Hủy tích kê"
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
        Me.U_CheckBox1.Location = New System.Drawing.Point(12, 12)
        Me.U_CheckBox1.Name = "U_CheckBox1"
        Me.U_CheckBox1.NoUpdate = ""
        Me.U_CheckBox1.PrimaryKey = ""
        Me.U_CheckBox1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_CheckBox1.Properties.Appearance.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_CheckBox1.Properties.AutoHeight = False
        Me.U_CheckBox1.Properties.Caption = "Chọn tất cả"
        Me.U_CheckBox1.Properties.ValueChecked = "Y"
        Me.U_CheckBox1.Properties.ValueUnchecked = "N"
        Me.U_CheckBox1.Required = ""
        Me.U_CheckBox1.Size = New System.Drawing.Size(133, 21)
        Me.U_CheckBox1.TabIndex = 475
        Me.U_CheckBox1.TableName = ""
        Me.U_CheckBox1.UnCheckValue = "N"
        Me.U_CheckBox1.UpdateIfNull = ""
        Me.U_CheckBox1.UpdateWhenFormLock = False
        Me.U_CheckBox1.ViewName = ""
        '
        'U_ButtonCus2
        '
        Me.U_ButtonCus2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus2.Appearance.Options.UseFont = True
        Me.U_ButtonCus2.DefaultUpdate = True
        Me.U_ButtonCus2.EnableWhenFormLock = False
        Me.U_ButtonCus2.Image = CType(resources.GetObject("U_ButtonCus2.Image"), System.Drawing.Image)
        Me.U_ButtonCus2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.U_ButtonCus2.Location = New System.Drawing.Point(469, 3)
        Me.U_ButtonCus2.Name = "U_ButtonCus2"
        Me.U_ButtonCus2.Size = New System.Drawing.Size(137, 30)
        Me.U_ButtonCus2.TabIndex = 476
        Me.U_ButtonCus2.TabStop = False
        Me.U_ButtonCus2.Text = "Load số lệnh"
        '
        'U_Label1
        '
        Me.U_Label1.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_Label1.Location = New System.Drawing.Point(12, 484)
        Me.U_Label1.Name = "U_Label1"
        Me.U_Label1.Size = New System.Drawing.Size(154, 18)
        Me.U_Label1.TabIndex = 477
        Me.U_Label1.Text = "Tổng số Phương tiện: 0"
        '
        'U_Label2
        '
        Me.U_Label2.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_Label2.Location = New System.Drawing.Point(220, 484)
        Me.U_Label2.Name = "U_Label2"
        Me.U_Label2.Size = New System.Drawing.Size(108, 18)
        Me.U_Label2.TabIndex = 477
        Me.U_Label2.Text = "Tổng số Lệnh: 0"
        '
        'U_Combobox1
        '
        Me.U_Combobox1.AllowInsert = True
        Me.U_Combobox1.AllowUpdate = True
        Me.U_Combobox1.BindingSourceName = ""
        Me.U_Combobox1.ChangeFormStatus = True
        Me.U_Combobox1.CopyFromItem = ""
        Me.U_Combobox1.DefaultValue = ""
        Me.U_Combobox1.DisplayField = ""
        Me.U_Combobox1.DropDownRow = 10
        Me.U_Combobox1.FieldName = ""
        Me.U_Combobox1.FieldType = "C"
        Me.U_Combobox1.ItemValue = ""
        Me.U_Combobox1.KeyInsert = ""
        Me.U_Combobox1.LinkLabel = ""
        Me.U_Combobox1.Location = New System.Drawing.Point(151, 3)
        Me.U_Combobox1.Name = "U_Combobox1"
        Me.U_Combobox1.NoUpdate = ""
        Me.U_Combobox1.PrimaryKey = ""
        Me.U_Combobox1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_Combobox1.Properties.Appearance.Options.UseFont = True
        Me.U_Combobox1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_Combobox1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_Combobox1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_Combobox1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_Combobox1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_Combobox1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_Combobox1.Properties.AutoHeight = False
        Me.U_Combobox1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_Combobox1.Properties.NullText = ""
        Me.U_Combobox1.Properties.ShowHeader = False
        Me.U_Combobox1.Required = ""
        Me.U_Combobox1.ShowHeader = False
        Me.U_Combobox1.Size = New System.Drawing.Size(162, 30)
        Me.U_Combobox1.SQL_String = ""
        Me.U_Combobox1.TabIndex = 478
        Me.U_Combobox1.TableName = ""
        Me.U_Combobox1.UpdateIfNull = ""
        Me.U_Combobox1.UpdateWhenFormLock = False
        Me.U_Combobox1.ValueField = ""
        Me.U_Combobox1.ViewName = ""
        '
        'U_ComboboxClient
        '
        Me.U_ComboboxClient.AllowInsert = True
        Me.U_ComboboxClient.AllowUpdate = True
        Me.U_ComboboxClient.BindingSourceName = ""
        Me.U_ComboboxClient.ChangeFormStatus = True
        Me.U_ComboboxClient.CopyFromItem = ""
        Me.U_ComboboxClient.DefaultValue = ""
        Me.U_ComboboxClient.DisplayField = ""
        Me.U_ComboboxClient.DropDownRow = 10
        Me.U_ComboboxClient.FieldName = ""
        Me.U_ComboboxClient.FieldType = "C"
        Me.U_ComboboxClient.ItemValue = ""
        Me.U_ComboboxClient.KeyInsert = ""
        Me.U_ComboboxClient.LinkLabel = ""
        Me.U_ComboboxClient.Location = New System.Drawing.Point(369, 3)
        Me.U_ComboboxClient.Name = "U_ComboboxClient"
        Me.U_ComboboxClient.NoUpdate = ""
        Me.U_ComboboxClient.PrimaryKey = ""
        Me.U_ComboboxClient.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_ComboboxClient.Properties.Appearance.Options.UseFont = True
        Me.U_ComboboxClient.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_ComboboxClient.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_ComboboxClient.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_ComboboxClient.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_ComboboxClient.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_ComboboxClient.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_ComboboxClient.Properties.AutoHeight = False
        Me.U_ComboboxClient.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_ComboboxClient.Properties.NullText = ""
        Me.U_ComboboxClient.Properties.ShowHeader = False
        Me.U_ComboboxClient.Required = ""
        Me.U_ComboboxClient.ShowHeader = False
        Me.U_ComboboxClient.Size = New System.Drawing.Size(85, 30)
        Me.U_ComboboxClient.SQL_String = ""
        Me.U_ComboboxClient.TabIndex = 479
        Me.U_ComboboxClient.TableName = ""
        Me.U_ComboboxClient.UpdateIfNull = ""
        Me.U_ComboboxClient.UpdateWhenFormLock = False
        Me.U_ComboboxClient.ValueField = ""
        Me.U_ComboboxClient.ViewName = ""
        '
        'U_Label3
        '
        Me.U_Label3.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_Label3.Location = New System.Drawing.Point(338, 8)
        Me.U_Label3.Name = "U_Label3"
        Me.U_Label3.Size = New System.Drawing.Size(25, 18)
        Me.U_Label3.TabIndex = 480
        Me.U_Label3.Text = "Kho"
        '
        'FmCheckEndDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 507)
        Me.Controls.Add(Me.U_Label3)
        Me.Controls.Add(Me.U_ComboboxClient)
        Me.Controls.Add(Me.U_Combobox1)
        Me.Controls.Add(Me.U_Label2)
        Me.Controls.Add(Me.U_Label1)
        Me.Controls.Add(Me.U_ButtonCus2)
        Me.Controls.Add(Me.U_CheckBox1)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FmCheckEndDay"
        Me.Text = "Lệnh cuối ngày"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.U_CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus2, 0)
        Me.Controls.SetChildIndex(Me.U_Label1, 0)
        Me.Controls.SetChildIndex(Me.U_Label2, 0)
        Me.Controls.SetChildIndex(Me.U_Combobox1, 0)
        Me.Controls.SetChildIndex(Me.U_ComboboxClient, 0)
        Me.Controls.SetChildIndex(Me.U_Label3, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CheckBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_Combobox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ComboboxClient.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents X As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Client As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NgayTichKe As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SoTichKe As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MaPhuongTien As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GioTichKe As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GioVaoKho As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SoLenh As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NgayHieuLuc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NgayHetHieuLuc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MaNgan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DungTich As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MaHangHoa As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SoLuongDuXuat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GhiChu As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents U_CheckBox1 As U_TextBox.U_CheckBox
    Friend WithEvents LoaiXuat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SMO_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents U_ButtonCus2 As U_TextBox.U_ButtonCus
    Friend WithEvents U_Label1 As U_TextBox.U_Label
    Friend WithEvents U_Label2 As U_TextBox.U_Label
    Friend WithEvents U_Combobox1 As U_TextBox.U_Combobox
    Friend WithEvents U_ComboboxClient As U_TextBox.U_Combobox
    Friend WithEvents U_Label3 As U_TextBox.U_Label
End Class
