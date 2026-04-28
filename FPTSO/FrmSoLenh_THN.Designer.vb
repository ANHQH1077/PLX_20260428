<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSoLenh_THN
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
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.SoLenh = New U_TextBox.GridColumn()
        Me.sDesc = New U_TextBox.GridColumn()
        Me.CreateDate = New U_TextBox.GridColumn()
        Me.NgayXuat = New U_TextBox.GridColumn()
        Me.TenKhachHang = New U_TextBox.GridColumn()
        Me.MaPhuongTien = New U_TextBox.GridColumn()
        Me.NguoiVanChuyen = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TuNgay = New U_TextBox.U_DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSoLenh = New U_TextBox.U_TextBox()
        Me.SimpleButton7 = New U_TextBox.U_ButtonCus(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DenNgay = New U_TextBox.U_DateEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TuNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TuNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSoLenh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DenNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DenNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 48)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemCheckEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(1007, 442)
        Me.TrueDBGrid1.TabIndex = 3
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.CheckUpd = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.SoLenh, Me.sDesc, Me.CreateDate, Me.NgayXuat, Me.TenKhachHang, Me.MaPhuongTien, Me.NguoiVanChuyen})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "SoLenh desc"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "tblLenhXuatE5_THN_HIST_V"
        Me.GridView1.Where = Nothing
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
        Me.SoLenh.VisibleIndex = 0
        Me.SoLenh.Width = 110
        '
        'sDesc
        '
        Me.sDesc.AllowInsert = True
        Me.sDesc.AllowUpdate = True
        Me.sDesc.ButtonClick = True
        Me.sDesc.Caption = "Nội dung"
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
        Me.sDesc.VisibleIndex = 1
        Me.sDesc.Width = 200
        '
        'CreateDate
        '
        Me.CreateDate.AllowInsert = True
        Me.CreateDate.AllowUpdate = True
        Me.CreateDate.ButtonClick = True
        Me.CreateDate.Caption = "Thời gian đồng bộ"
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
        Me.CreateDate.VisibleIndex = 2
        Me.CreateDate.Width = 150
        '
        'NgayXuat
        '
        Me.NgayXuat.AllowInsert = True
        Me.NgayXuat.AllowUpdate = True
        Me.NgayXuat.ButtonClick = True
        Me.NgayXuat.Caption = "Ngày xuất"
        Me.NgayXuat.CFLColumnHide = ""
        Me.NgayXuat.CFLKeyField = ""
        Me.NgayXuat.CFLPage = False
        Me.NgayXuat.CFLReturn0 = ""
        Me.NgayXuat.CFLReturn1 = ""
        Me.NgayXuat.CFLReturn2 = ""
        Me.NgayXuat.CFLReturn3 = ""
        Me.NgayXuat.CFLReturn4 = ""
        Me.NgayXuat.CFLReturn5 = ""
        Me.NgayXuat.CFLReturn6 = ""
        Me.NgayXuat.CFLReturn7 = ""
        Me.NgayXuat.CFLShowLoad = False
        Me.NgayXuat.ChangeFormStatus = True
        Me.NgayXuat.ColumnKey = False
        Me.NgayXuat.ComboLine = 5
        Me.NgayXuat.CopyFromItem = ""
        Me.NgayXuat.DefaultButtonClick = False
        Me.NgayXuat.Digit = False
        Me.NgayXuat.FieldType = "D"
        Me.NgayXuat.FieldView = "NgayXuat"
        Me.NgayXuat.FormarNumber = True
        Me.NgayXuat.FormList = False
        Me.NgayXuat.KeyInsert = ""
        Me.NgayXuat.LocalDecimal = False
        Me.NgayXuat.Name = "NgayXuat"
        Me.NgayXuat.NoUpdate = ""
        Me.NgayXuat.NumberDecimal = 0
        Me.NgayXuat.OptionsColumn.ReadOnly = True
        Me.NgayXuat.ParentControl = ""
        Me.NgayXuat.RefreshSource = False
        Me.NgayXuat.Required = False
        Me.NgayXuat.SequenceName = ""
        Me.NgayXuat.ShowCalc = True
        Me.NgayXuat.ShowDataTime = True
        Me.NgayXuat.ShowOnlyTime = False
        Me.NgayXuat.SQLString = ""
        Me.NgayXuat.UpdateIfNull = ""
        Me.NgayXuat.UpdateWhenFormLock = False
        Me.NgayXuat.UpperValue = False
        Me.NgayXuat.ValidateValue = True
        Me.NgayXuat.Visible = True
        Me.NgayXuat.VisibleIndex = 3
        '
        'TenKhachHang
        '
        Me.TenKhachHang.AllowInsert = True
        Me.TenKhachHang.AllowUpdate = True
        Me.TenKhachHang.ButtonClick = True
        Me.TenKhachHang.Caption = "Khách hàng"
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
        Me.TenKhachHang.VisibleIndex = 4
        Me.TenKhachHang.Width = 200
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
        Me.MaPhuongTien.VisibleIndex = 5
        Me.MaPhuongTien.Width = 100
        '
        'NguoiVanChuyen
        '
        Me.NguoiVanChuyen.AllowInsert = True
        Me.NguoiVanChuyen.AllowUpdate = True
        Me.NguoiVanChuyen.ButtonClick = True
        Me.NguoiVanChuyen.Caption = "Người vận chuyển"
        Me.NguoiVanChuyen.CFLColumnHide = ""
        Me.NguoiVanChuyen.CFLKeyField = ""
        Me.NguoiVanChuyen.CFLPage = False
        Me.NguoiVanChuyen.CFLReturn0 = ""
        Me.NguoiVanChuyen.CFLReturn1 = ""
        Me.NguoiVanChuyen.CFLReturn2 = ""
        Me.NguoiVanChuyen.CFLReturn3 = ""
        Me.NguoiVanChuyen.CFLReturn4 = ""
        Me.NguoiVanChuyen.CFLReturn5 = ""
        Me.NguoiVanChuyen.CFLReturn6 = ""
        Me.NguoiVanChuyen.CFLReturn7 = ""
        Me.NguoiVanChuyen.CFLShowLoad = False
        Me.NguoiVanChuyen.ChangeFormStatus = True
        Me.NguoiVanChuyen.ColumnKey = False
        Me.NguoiVanChuyen.ComboLine = 5
        Me.NguoiVanChuyen.CopyFromItem = ""
        Me.NguoiVanChuyen.DefaultButtonClick = False
        Me.NguoiVanChuyen.Digit = False
        Me.NguoiVanChuyen.FieldType = "C"
        Me.NguoiVanChuyen.FieldView = "NguoiVanChuyen"
        Me.NguoiVanChuyen.FormarNumber = True
        Me.NguoiVanChuyen.FormList = False
        Me.NguoiVanChuyen.KeyInsert = ""
        Me.NguoiVanChuyen.LocalDecimal = False
        Me.NguoiVanChuyen.Name = "NguoiVanChuyen"
        Me.NguoiVanChuyen.NoUpdate = ""
        Me.NguoiVanChuyen.NumberDecimal = 0
        Me.NguoiVanChuyen.OptionsColumn.ReadOnly = True
        Me.NguoiVanChuyen.ParentControl = ""
        Me.NguoiVanChuyen.RefreshSource = False
        Me.NguoiVanChuyen.Required = False
        Me.NguoiVanChuyen.SequenceName = ""
        Me.NguoiVanChuyen.ShowCalc = True
        Me.NguoiVanChuyen.ShowDataTime = False
        Me.NguoiVanChuyen.ShowOnlyTime = False
        Me.NguoiVanChuyen.SQLString = "select 'A' as Code , N'Thông tin ATG' as Name Union select 'M' as Code , N'Nhập t" & _
            "ay' as Name"
        Me.NguoiVanChuyen.UpdateIfNull = ""
        Me.NguoiVanChuyen.UpdateWhenFormLock = False
        Me.NguoiVanChuyen.UpperValue = False
        Me.NguoiVanChuyen.ValidateValue = True
        Me.NguoiVanChuyen.Visible = True
        Me.NguoiVanChuyen.VisibleIndex = 6
        Me.NguoiVanChuyen.Width = 150
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(238, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 19)
        Me.Label2.TabIndex = 202
        Me.Label2.Text = "Từ ngày"
        '
        'TuNgay
        '
        Me.TuNgay.AllowInsert = True
        Me.TuNgay.AllowUpdate = True
        Me.TuNgay.BindingSourceName = ""
        Me.TuNgay.ChangeFormStatus = False
        Me.TuNgay.CopyFromItem = ""
        Me.TuNgay.DefaultValue = ""
        Me.TuNgay.EditValue = Nothing
        Me.TuNgay.FieldName = ""
        Me.TuNgay.FieldType = "D"
        Me.TuNgay.KeyInsert = ""
        Me.TuNgay.LinkLabel = ""
        Me.TuNgay.Location = New System.Drawing.Point(324, 12)
        Me.TuNgay.Name = "TuNgay"
        Me.TuNgay.NoUpdate = ""
        Me.TuNgay.PrimaryKey = ""
        Me.TuNgay.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TuNgay.Properties.Appearance.Options.UseFont = True
        Me.TuNgay.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TuNgay.Properties.AppearanceDisabled.Options.UseFont = True
        Me.TuNgay.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TuNgay.Properties.AppearanceFocused.Options.UseFont = True
        Me.TuNgay.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TuNgay.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.TuNgay.Properties.AutoHeight = False
        Me.TuNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.TuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TuNgay.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.TuNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TuNgay.Required = ""
        Me.TuNgay.ShowDateTime = False
        Me.TuNgay.Size = New System.Drawing.Size(148, 26)
        Me.TuNgay.TabIndex = 200
        Me.TuNgay.TableName = ""
        Me.TuNgay.UpdateIfNull = ""
        Me.TuNgay.UpdateWhenFormLock = True
        Me.TuNgay.ViewName = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 19)
        Me.Label1.TabIndex = 201
        Me.Label1.Text = "Số lệnh"
        '
        'txtSoLenh
        '
        Me.txtSoLenh.AllowInsert = True
        Me.txtSoLenh.AllowUpdate = True
        Me.txtSoLenh.AutoKeyFix = ""
        Me.txtSoLenh.AutoKeyName = ""
        Me.txtSoLenh.BindingSourceName = ""
        Me.txtSoLenh.ChangeFormStatus = False
        Me.txtSoLenh.CopyFromItem = ""
        Me.txtSoLenh.DefaultValue = ""
        Me.txtSoLenh.FieldName = ""
        Me.txtSoLenh.FieldType = ""
        Me.txtSoLenh.KeyInsert = ""
        Me.txtSoLenh.LinkLabel = ""
        Me.txtSoLenh.Location = New System.Drawing.Point(95, 12)
        Me.txtSoLenh.Name = "txtSoLenh"
        Me.txtSoLenh.NoUpdate = "N"
        Me.txtSoLenh.PrimaryKey = ""
        Me.txtSoLenh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtSoLenh.Properties.Appearance.Options.UseFont = True
        Me.txtSoLenh.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtSoLenh.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtSoLenh.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtSoLenh.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtSoLenh.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtSoLenh.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtSoLenh.Properties.AutoHeight = False
        Me.txtSoLenh.Properties.MaxLength = 10
        Me.txtSoLenh.Required = ""
        Me.txtSoLenh.Size = New System.Drawing.Size(128, 26)
        Me.txtSoLenh.TabIndex = 199
        Me.txtSoLenh.TableName = ""
        Me.txtSoLenh.UpdateIfNull = ""
        Me.txtSoLenh.UpdateWhenFormLock = True
        Me.txtSoLenh.UpperValue = False
        Me.txtSoLenh.ViewName = ""
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.DefaultUpdate = True
        Me.SimpleButton7.EnableWhenFormLock = True
        Me.SimpleButton7.Location = New System.Drawing.Point(877, 9)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(103, 29)
        Me.SimpleButton7.TabIndex = 203
        Me.SimpleButton7.Text = "&Tìm kiếm"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(508, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 19)
        Me.Label3.TabIndex = 205
        Me.Label3.Text = "Đến ngày"
        '
        'DenNgay
        '
        Me.DenNgay.AllowInsert = True
        Me.DenNgay.AllowUpdate = True
        Me.DenNgay.BindingSourceName = ""
        Me.DenNgay.ChangeFormStatus = False
        Me.DenNgay.CopyFromItem = ""
        Me.DenNgay.DefaultValue = ""
        Me.DenNgay.EditValue = Nothing
        Me.DenNgay.FieldName = ""
        Me.DenNgay.FieldType = "D"
        Me.DenNgay.KeyInsert = ""
        Me.DenNgay.LinkLabel = ""
        Me.DenNgay.Location = New System.Drawing.Point(594, 12)
        Me.DenNgay.Name = "DenNgay"
        Me.DenNgay.NoUpdate = ""
        Me.DenNgay.PrimaryKey = ""
        Me.DenNgay.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.DenNgay.Properties.Appearance.Options.UseFont = True
        Me.DenNgay.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.DenNgay.Properties.AppearanceDisabled.Options.UseFont = True
        Me.DenNgay.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.DenNgay.Properties.AppearanceFocused.Options.UseFont = True
        Me.DenNgay.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.DenNgay.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.DenNgay.Properties.AutoHeight = False
        Me.DenNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.DenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DenNgay.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.DenNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DenNgay.Required = ""
        Me.DenNgay.ShowDateTime = False
        Me.DenNgay.Size = New System.Drawing.Size(148, 26)
        Me.DenNgay.TabIndex = 204
        Me.DenNgay.TableName = ""
        Me.DenNgay.UpdateIfNull = ""
        Me.DenNgay.UpdateWhenFormLock = True
        Me.DenNgay.ViewName = ""
        '
        'FrmSoLenh_THN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1010, 502)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DenNgay)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TuNgay)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSoLenh)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmSoLenh_THN"
        Me.Text = "FrmSoLenh_THN"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.txtSoLenh, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TuNgay, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton7, 0)
        Me.Controls.SetChildIndex(Me.DenNgay, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TuNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TuNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSoLenh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DenNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DenNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents SoLenh As U_TextBox.GridColumn
    Friend WithEvents sDesc As U_TextBox.GridColumn
    Friend WithEvents CreateDate As U_TextBox.GridColumn
    Friend WithEvents NgayXuat As U_TextBox.GridColumn
    Friend WithEvents TenKhachHang As U_TextBox.GridColumn
    Friend WithEvents MaPhuongTien As U_TextBox.GridColumn
    Friend WithEvents NguoiVanChuyen As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TuNgay As U_TextBox.U_DateEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSoLenh As U_TextBox.U_TextBox
    Friend WithEvents SimpleButton7 As U_TextBox.U_ButtonCus
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DenNgay As U_TextBox.U_DateEdit
End Class
