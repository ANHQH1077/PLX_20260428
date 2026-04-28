<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQuanLySoLenh
    'Inherits System.Windows.Forms.Form
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
        Me.SoLenh = New U_TextBox.U_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SimpleButton7 = New U_TextBox.U_ButtonCus(Me.components)
        Me.U_DateEdit1 = New U_TextBox.U_DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ColNgayXuat = New U_TextBox.GridColumn()
        Me.ColSoLenh = New U_TextBox.GridColumn()
        Me.TenHangHoa22 = New U_TextBox.GridColumn()
        Me.TenPhuongThucBan = New U_TextBox.GridColumn()
        Me.MaNguon = New U_TextBox.GridColumn()
        Me.TenKhachHang = New U_TextBox.GridColumn()
        Me.CreateDate = New U_TextBox.GridColumn()
        Me.TenMaVanChuyen = New U_TextBox.GridColumn()
        Me.MaPhuongTien = New U_TextBox.GridColumn()
        Me.Status = New U_TextBox.GridColumn()
        Me.User_Approve = New U_TextBox.GridColumn()
        Me.Date_Approve = New U_TextBox.GridColumn()
        Me.DiemTraHang = New U_TextBox.GridColumn()
        Me.LoaiPhieu = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.GridColumn1 = New U_TextBox.GridColumn()
        Me.GridColumn2 = New U_TextBox.GridColumn()
        Me.GridColumn3 = New U_TextBox.GridColumn()
        Me.GridColumn4 = New U_TextBox.GridColumn()
        Me.GridColumn5 = New U_TextBox.GridColumn()
        Me.GridColumn6 = New U_TextBox.GridColumn()
        Me.GridColumn7 = New U_TextBox.GridColumn()
        Me.GridColumn8 = New U_TextBox.GridColumn()
        Me.GridColumn9 = New U_TextBox.GridColumn()
        Me.U_ButtonEdit1 = New U_TextBox.U_ButtonEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdSoLenh = New U_TextBox.U_ButtonCus(Me.components)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_ButtonEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SoLenh
        '
        Me.SoLenh.AllowInsert = True
        Me.SoLenh.AllowUpdate = True
        Me.SoLenh.AutoKeyFix = ""
        Me.SoLenh.AutoKeyName = ""
        Me.SoLenh.BindingSourceName = ""
        Me.SoLenh.ChangeFormStatus = False
        Me.SoLenh.CopyFromItem = ""
        Me.SoLenh.DefaultValue = ""
        Me.SoLenh.FieldName = ""
        Me.SoLenh.FieldType = ""
        Me.SoLenh.KeyInsert = ""
        Me.SoLenh.LinkLabel = ""
        Me.SoLenh.Location = New System.Drawing.Point(86, 12)
        Me.SoLenh.Name = "SoLenh"
        Me.SoLenh.NoUpdate = "N"
        Me.SoLenh.PrimaryKey = ""
        Me.SoLenh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh.Properties.Appearance.Options.UseFont = True
        Me.SoLenh.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SoLenh.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh.Properties.AppearanceFocused.Options.UseFont = True
        Me.SoLenh.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SoLenh.Properties.AutoHeight = False
        Me.SoLenh.Properties.MaxLength = 10
        Me.SoLenh.Required = ""
        Me.SoLenh.Size = New System.Drawing.Size(128, 26)
        Me.SoLenh.TabIndex = 0
        Me.SoLenh.TableName = ""
        Me.SoLenh.UpdateIfNull = ""
        Me.SoLenh.UpdateWhenFormLock = True
        Me.SoLenh.UpperValue = False
        Me.SoLenh.ViewName = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 19)
        Me.Label1.TabIndex = 196
        Me.Label1.Text = "Số lệnh"
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.DefaultUpdate = True
        Me.SimpleButton7.EnableWhenFormLock = True
        Me.SimpleButton7.Location = New System.Drawing.Point(873, 9)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(103, 29)
        Me.SimpleButton7.TabIndex = 2
        Me.SimpleButton7.Text = "&Tìm kiếm"
        '
        'U_DateEdit1
        '
        Me.U_DateEdit1.AllowInsert = True
        Me.U_DateEdit1.AllowUpdate = True
        Me.U_DateEdit1.BindingSourceName = ""
        Me.U_DateEdit1.ChangeFormStatus = False
        Me.U_DateEdit1.CopyFromItem = ""
        Me.U_DateEdit1.DefaultValue = ""
        Me.U_DateEdit1.EditValue = Nothing
        Me.U_DateEdit1.FieldName = ""
        Me.U_DateEdit1.FieldType = "D"
        Me.U_DateEdit1.KeyInsert = ""
        Me.U_DateEdit1.LinkLabel = ""
        Me.U_DateEdit1.Location = New System.Drawing.Point(315, 12)
        Me.U_DateEdit1.Name = "U_DateEdit1"
        Me.U_DateEdit1.NoUpdate = ""
        Me.U_DateEdit1.PrimaryKey = ""
        Me.U_DateEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_DateEdit1.Properties.Appearance.Options.UseFont = True
        Me.U_DateEdit1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_DateEdit1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_DateEdit1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_DateEdit1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_DateEdit1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_DateEdit1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_DateEdit1.Properties.AutoHeight = False
        Me.U_DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_DateEdit1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.U_DateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.U_DateEdit1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.U_DateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_DateEdit1.Required = ""
        Me.U_DateEdit1.ShowDateTime = False
        Me.U_DateEdit1.Size = New System.Drawing.Size(148, 26)
        Me.U_DateEdit1.TabIndex = 1
        Me.U_DateEdit1.TableName = ""
        Me.U_DateEdit1.UpdateIfNull = ""
        Me.U_DateEdit1.UpdateWhenFormLock = True
        Me.U_DateEdit1.ViewName = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(229, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 19)
        Me.Label2.TabIndex = 198
        Me.Label2.Text = "Ngày xuất"
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(1, 51)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(1210, 513)
        Me.TrueDBGrid1.TabIndex = 0
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
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColNgayXuat, Me.ColSoLenh, Me.TenHangHoa22, Me.TenPhuongThucBan, Me.MaNguon, Me.TenKhachHang, Me.CreateDate, Me.TenMaVanChuyen, Me.MaPhuongTien, Me.Status, Me.User_Approve, Me.Date_Approve, Me.DiemTraHang, Me.LoaiPhieu})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = False
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OrderBy = "NgayXuat, SoLenh"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "FPT_tblLenhXuatE5_V"
        Me.GridView1.Where = Nothing
        '
        'ColNgayXuat
        '
        Me.ColNgayXuat.AllowInsert = True
        Me.ColNgayXuat.AllowUpdate = True
        Me.ColNgayXuat.ButtonClick = True
        Me.ColNgayXuat.Caption = "Ngày xuất"
        Me.ColNgayXuat.CFLColumnHide = ""
        Me.ColNgayXuat.CFLKeyField = ""
        Me.ColNgayXuat.CFLPage = False
        Me.ColNgayXuat.CFLReturn0 = ""
        Me.ColNgayXuat.CFLReturn1 = ""
        Me.ColNgayXuat.CFLReturn2 = ""
        Me.ColNgayXuat.CFLReturn3 = ""
        Me.ColNgayXuat.CFLReturn4 = ""
        Me.ColNgayXuat.CFLReturn5 = ""
        Me.ColNgayXuat.CFLReturn6 = ""
        Me.ColNgayXuat.CFLReturn7 = ""
        Me.ColNgayXuat.CFLShowLoad = False
        Me.ColNgayXuat.ChangeFormStatus = True
        Me.ColNgayXuat.ColumnKey = False
        Me.ColNgayXuat.ComboLine = 5
        Me.ColNgayXuat.CopyFromItem = ""
        Me.ColNgayXuat.DefaultButtonClick = False
        Me.ColNgayXuat.Digit = False
        Me.ColNgayXuat.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.ColNgayXuat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ColNgayXuat.FieldType = "D"
        Me.ColNgayXuat.FieldView = "NgayXuat"
        Me.ColNgayXuat.FormarNumber = True
        Me.ColNgayXuat.FormList = False
        Me.ColNgayXuat.GroupFormat.FormatString = "dd/MM/yyyy"
        Me.ColNgayXuat.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.ColNgayXuat.KeyInsert = ""
        Me.ColNgayXuat.LocalDecimal = False
        Me.ColNgayXuat.Name = "ColNgayXuat"
        Me.ColNgayXuat.NoUpdate = ""
        Me.ColNgayXuat.NumberDecimal = 0
        Me.ColNgayXuat.OptionsColumn.AllowEdit = False
        Me.ColNgayXuat.ParentControl = ""
        Me.ColNgayXuat.RefreshSource = False
        Me.ColNgayXuat.Required = False
        Me.ColNgayXuat.SequenceName = ""
        Me.ColNgayXuat.ShowCalc = True
        Me.ColNgayXuat.ShowDataTime = False
        Me.ColNgayXuat.ShowOnlyTime = False
        Me.ColNgayXuat.SQLString = ""
        Me.ColNgayXuat.UpdateIfNull = ""
        Me.ColNgayXuat.UpdateWhenFormLock = False
        Me.ColNgayXuat.UpperValue = False
        Me.ColNgayXuat.ValidateValue = True
        Me.ColNgayXuat.Visible = True
        Me.ColNgayXuat.VisibleIndex = 0
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
        Me.ColSoLenh.VisibleIndex = 1
        '
        'TenHangHoa22
        '
        Me.TenHangHoa22.AllowInsert = True
        Me.TenHangHoa22.AllowUpdate = True
        Me.TenHangHoa22.ButtonClick = True
        Me.TenHangHoa22.Caption = "Hàng hóa"
        Me.TenHangHoa22.CFLColumnHide = ""
        Me.TenHangHoa22.CFLKeyField = ""
        Me.TenHangHoa22.CFLPage = False
        Me.TenHangHoa22.CFLReturn0 = ""
        Me.TenHangHoa22.CFLReturn1 = ""
        Me.TenHangHoa22.CFLReturn2 = ""
        Me.TenHangHoa22.CFLReturn3 = ""
        Me.TenHangHoa22.CFLReturn4 = ""
        Me.TenHangHoa22.CFLReturn5 = ""
        Me.TenHangHoa22.CFLReturn6 = ""
        Me.TenHangHoa22.CFLReturn7 = ""
        Me.TenHangHoa22.CFLShowLoad = False
        Me.TenHangHoa22.ChangeFormStatus = True
        Me.TenHangHoa22.ColumnKey = False
        Me.TenHangHoa22.ComboLine = 5
        Me.TenHangHoa22.CopyFromItem = ""
        Me.TenHangHoa22.DefaultButtonClick = False
        Me.TenHangHoa22.Digit = False
        Me.TenHangHoa22.FieldType = "C"
        Me.TenHangHoa22.FieldView = ""
        Me.TenHangHoa22.FormarNumber = True
        Me.TenHangHoa22.FormList = False
        Me.TenHangHoa22.KeyInsert = ""
        Me.TenHangHoa22.LocalDecimal = False
        Me.TenHangHoa22.Name = "TenHangHoa22"
        Me.TenHangHoa22.NoUpdate = ""
        Me.TenHangHoa22.NumberDecimal = 0
        Me.TenHangHoa22.OptionsColumn.ReadOnly = True
        Me.TenHangHoa22.ParentControl = ""
        Me.TenHangHoa22.RefreshSource = False
        Me.TenHangHoa22.Required = False
        Me.TenHangHoa22.SequenceName = ""
        Me.TenHangHoa22.ShowCalc = True
        Me.TenHangHoa22.ShowDataTime = False
        Me.TenHangHoa22.ShowOnlyTime = False
        Me.TenHangHoa22.SQLString = ""
        Me.TenHangHoa22.UpdateIfNull = ""
        Me.TenHangHoa22.UpdateWhenFormLock = False
        Me.TenHangHoa22.UpperValue = False
        Me.TenHangHoa22.ValidateValue = True
        Me.TenHangHoa22.Visible = True
        Me.TenHangHoa22.VisibleIndex = 2
        Me.TenHangHoa22.Width = 300
        '
        'TenPhuongThucBan
        '
        Me.TenPhuongThucBan.AllowInsert = True
        Me.TenPhuongThucBan.AllowUpdate = True
        Me.TenPhuongThucBan.ButtonClick = True
        Me.TenPhuongThucBan.Caption = "Tên PTB"
        Me.TenPhuongThucBan.CFLColumnHide = ""
        Me.TenPhuongThucBan.CFLKeyField = ""
        Me.TenPhuongThucBan.CFLPage = False
        Me.TenPhuongThucBan.CFLReturn0 = ""
        Me.TenPhuongThucBan.CFLReturn1 = ""
        Me.TenPhuongThucBan.CFLReturn2 = ""
        Me.TenPhuongThucBan.CFLReturn3 = ""
        Me.TenPhuongThucBan.CFLReturn4 = ""
        Me.TenPhuongThucBan.CFLReturn5 = ""
        Me.TenPhuongThucBan.CFLReturn6 = ""
        Me.TenPhuongThucBan.CFLReturn7 = ""
        Me.TenPhuongThucBan.CFLShowLoad = False
        Me.TenPhuongThucBan.ChangeFormStatus = True
        Me.TenPhuongThucBan.ColumnKey = False
        Me.TenPhuongThucBan.ComboLine = 5
        Me.TenPhuongThucBan.CopyFromItem = ""
        Me.TenPhuongThucBan.DefaultButtonClick = False
        Me.TenPhuongThucBan.Digit = False
        Me.TenPhuongThucBan.FieldType = "C"
        Me.TenPhuongThucBan.FieldView = "TenPhuongThucBan"
        Me.TenPhuongThucBan.FormarNumber = True
        Me.TenPhuongThucBan.FormList = False
        Me.TenPhuongThucBan.KeyInsert = ""
        Me.TenPhuongThucBan.LocalDecimal = False
        Me.TenPhuongThucBan.Name = "TenPhuongThucBan"
        Me.TenPhuongThucBan.NoUpdate = ""
        Me.TenPhuongThucBan.NumberDecimal = 0
        Me.TenPhuongThucBan.OptionsColumn.AllowEdit = False
        Me.TenPhuongThucBan.ParentControl = ""
        Me.TenPhuongThucBan.RefreshSource = False
        Me.TenPhuongThucBan.Required = False
        Me.TenPhuongThucBan.SequenceName = ""
        Me.TenPhuongThucBan.ShowCalc = True
        Me.TenPhuongThucBan.ShowDataTime = False
        Me.TenPhuongThucBan.ShowOnlyTime = False
        Me.TenPhuongThucBan.SQLString = ""
        Me.TenPhuongThucBan.UpdateIfNull = ""
        Me.TenPhuongThucBan.UpdateWhenFormLock = False
        Me.TenPhuongThucBan.UpperValue = False
        Me.TenPhuongThucBan.ValidateValue = True
        Me.TenPhuongThucBan.Visible = True
        Me.TenPhuongThucBan.VisibleIndex = 3
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
        Me.MaNguon.VisibleIndex = 4
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
        Me.TenKhachHang.VisibleIndex = 5
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
        Me.CreateDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.CreateDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
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
        Me.CreateDate.VisibleIndex = 6
        Me.CreateDate.Width = 150
        '
        'TenMaVanChuyen
        '
        Me.TenMaVanChuyen.AllowInsert = True
        Me.TenMaVanChuyen.AllowUpdate = True
        Me.TenMaVanChuyen.ButtonClick = True
        Me.TenMaVanChuyen.Caption = "PT vận chuyển"
        Me.TenMaVanChuyen.CFLColumnHide = ""
        Me.TenMaVanChuyen.CFLKeyField = ""
        Me.TenMaVanChuyen.CFLPage = False
        Me.TenMaVanChuyen.CFLReturn0 = ""
        Me.TenMaVanChuyen.CFLReturn1 = ""
        Me.TenMaVanChuyen.CFLReturn2 = ""
        Me.TenMaVanChuyen.CFLReturn3 = ""
        Me.TenMaVanChuyen.CFLReturn4 = ""
        Me.TenMaVanChuyen.CFLReturn5 = ""
        Me.TenMaVanChuyen.CFLReturn6 = ""
        Me.TenMaVanChuyen.CFLReturn7 = ""
        Me.TenMaVanChuyen.CFLShowLoad = False
        Me.TenMaVanChuyen.ChangeFormStatus = True
        Me.TenMaVanChuyen.ColumnKey = False
        Me.TenMaVanChuyen.ComboLine = 5
        Me.TenMaVanChuyen.CopyFromItem = ""
        Me.TenMaVanChuyen.DefaultButtonClick = False
        Me.TenMaVanChuyen.Digit = False
        Me.TenMaVanChuyen.FieldType = "C"
        Me.TenMaVanChuyen.FieldView = "TenMaVanChuyen"
        Me.TenMaVanChuyen.FormarNumber = True
        Me.TenMaVanChuyen.FormList = False
        Me.TenMaVanChuyen.KeyInsert = ""
        Me.TenMaVanChuyen.LocalDecimal = False
        Me.TenMaVanChuyen.Name = "TenMaVanChuyen"
        Me.TenMaVanChuyen.NoUpdate = ""
        Me.TenMaVanChuyen.NumberDecimal = 0
        Me.TenMaVanChuyen.OptionsColumn.AllowEdit = False
        Me.TenMaVanChuyen.ParentControl = ""
        Me.TenMaVanChuyen.RefreshSource = False
        Me.TenMaVanChuyen.Required = False
        Me.TenMaVanChuyen.SequenceName = ""
        Me.TenMaVanChuyen.ShowCalc = True
        Me.TenMaVanChuyen.ShowDataTime = False
        Me.TenMaVanChuyen.ShowOnlyTime = False
        Me.TenMaVanChuyen.SQLString = ""
        Me.TenMaVanChuyen.UpdateIfNull = ""
        Me.TenMaVanChuyen.UpdateWhenFormLock = False
        Me.TenMaVanChuyen.UpperValue = False
        Me.TenMaVanChuyen.ValidateValue = True
        Me.TenMaVanChuyen.Visible = True
        Me.TenMaVanChuyen.VisibleIndex = 7
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
        Me.MaPhuongTien.VisibleIndex = 8
        '
        'Status
        '
        Me.Status.AllowInsert = True
        Me.Status.AllowUpdate = True
        Me.Status.ButtonClick = True
        Me.Status.Caption = "Trạng thái"
        Me.Status.CFLColumnHide = ""
        Me.Status.CFLKeyField = ""
        Me.Status.CFLPage = False
        Me.Status.CFLReturn0 = ""
        Me.Status.CFLReturn1 = ""
        Me.Status.CFLReturn2 = ""
        Me.Status.CFLReturn3 = ""
        Me.Status.CFLReturn4 = ""
        Me.Status.CFLReturn5 = ""
        Me.Status.CFLReturn6 = ""
        Me.Status.CFLReturn7 = ""
        Me.Status.CFLShowLoad = False
        Me.Status.ChangeFormStatus = True
        Me.Status.ColumnKey = False
        Me.Status.ComboLine = 5
        Me.Status.CopyFromItem = ""
        Me.Status.DefaultButtonClick = False
        Me.Status.Digit = False
        Me.Status.FieldType = "C"
        Me.Status.FieldView = "Status_Name"
        Me.Status.FormarNumber = True
        Me.Status.FormList = False
        Me.Status.KeyInsert = ""
        Me.Status.LocalDecimal = False
        Me.Status.Name = "Status"
        Me.Status.NoUpdate = ""
        Me.Status.NumberDecimal = 0
        Me.Status.ParentControl = ""
        Me.Status.RefreshSource = True
        Me.Status.Required = False
        Me.Status.SequenceName = ""
        Me.Status.ShowCalc = True
        Me.Status.ShowDataTime = False
        Me.Status.ShowOnlyTime = False
        Me.Status.SQLString = ""
        Me.Status.UpdateIfNull = ""
        Me.Status.UpdateWhenFormLock = False
        Me.Status.UpperValue = False
        Me.Status.ValidateValue = True
        Me.Status.Visible = True
        Me.Status.VisibleIndex = 9
        '
        'User_Approve
        '
        Me.User_Approve.AllowInsert = True
        Me.User_Approve.AllowUpdate = True
        Me.User_Approve.ButtonClick = True
        Me.User_Approve.Caption = "Người phê duyệt"
        Me.User_Approve.CFLColumnHide = ""
        Me.User_Approve.CFLKeyField = ""
        Me.User_Approve.CFLPage = False
        Me.User_Approve.CFLReturn0 = ""
        Me.User_Approve.CFLReturn1 = ""
        Me.User_Approve.CFLReturn2 = ""
        Me.User_Approve.CFLReturn3 = ""
        Me.User_Approve.CFLReturn4 = ""
        Me.User_Approve.CFLReturn5 = ""
        Me.User_Approve.CFLReturn6 = ""
        Me.User_Approve.CFLReturn7 = ""
        Me.User_Approve.CFLShowLoad = False
        Me.User_Approve.ChangeFormStatus = True
        Me.User_Approve.ColumnKey = False
        Me.User_Approve.ComboLine = 5
        Me.User_Approve.CopyFromItem = ""
        Me.User_Approve.DefaultButtonClick = False
        Me.User_Approve.Digit = False
        Me.User_Approve.FieldType = "C"
        Me.User_Approve.FieldView = "User_Approve"
        Me.User_Approve.FormarNumber = True
        Me.User_Approve.FormList = False
        Me.User_Approve.KeyInsert = ""
        Me.User_Approve.LocalDecimal = False
        Me.User_Approve.Name = "User_Approve"
        Me.User_Approve.NoUpdate = ""
        Me.User_Approve.NumberDecimal = 0
        Me.User_Approve.ParentControl = ""
        Me.User_Approve.RefreshSource = False
        Me.User_Approve.Required = False
        Me.User_Approve.SequenceName = ""
        Me.User_Approve.ShowCalc = True
        Me.User_Approve.ShowDataTime = False
        Me.User_Approve.ShowOnlyTime = False
        Me.User_Approve.SQLString = ""
        Me.User_Approve.UpdateIfNull = ""
        Me.User_Approve.UpdateWhenFormLock = False
        Me.User_Approve.UpperValue = False
        Me.User_Approve.ValidateValue = True
        Me.User_Approve.Visible = True
        Me.User_Approve.VisibleIndex = 10
        '
        'Date_Approve
        '
        Me.Date_Approve.AllowInsert = True
        Me.Date_Approve.AllowUpdate = True
        Me.Date_Approve.ButtonClick = True
        Me.Date_Approve.Caption = "Ngày phê duyệt"
        Me.Date_Approve.CFLColumnHide = ""
        Me.Date_Approve.CFLKeyField = ""
        Me.Date_Approve.CFLPage = False
        Me.Date_Approve.CFLReturn0 = ""
        Me.Date_Approve.CFLReturn1 = ""
        Me.Date_Approve.CFLReturn2 = ""
        Me.Date_Approve.CFLReturn3 = ""
        Me.Date_Approve.CFLReturn4 = ""
        Me.Date_Approve.CFLReturn5 = ""
        Me.Date_Approve.CFLReturn6 = ""
        Me.Date_Approve.CFLReturn7 = ""
        Me.Date_Approve.CFLShowLoad = False
        Me.Date_Approve.ChangeFormStatus = True
        Me.Date_Approve.ColumnKey = False
        Me.Date_Approve.ComboLine = 5
        Me.Date_Approve.CopyFromItem = ""
        Me.Date_Approve.DefaultButtonClick = False
        Me.Date_Approve.Digit = False
        Me.Date_Approve.FieldType = "D"
        Me.Date_Approve.FieldView = "Date_Approve"
        Me.Date_Approve.FormarNumber = True
        Me.Date_Approve.FormList = False
        Me.Date_Approve.KeyInsert = ""
        Me.Date_Approve.LocalDecimal = False
        Me.Date_Approve.Name = "Date_Approve"
        Me.Date_Approve.NoUpdate = ""
        Me.Date_Approve.NumberDecimal = 0
        Me.Date_Approve.ParentControl = ""
        Me.Date_Approve.RefreshSource = False
        Me.Date_Approve.Required = False
        Me.Date_Approve.SequenceName = ""
        Me.Date_Approve.ShowCalc = True
        Me.Date_Approve.ShowDataTime = True
        Me.Date_Approve.ShowOnlyTime = False
        Me.Date_Approve.SQLString = ""
        Me.Date_Approve.UpdateIfNull = ""
        Me.Date_Approve.UpdateWhenFormLock = False
        Me.Date_Approve.UpperValue = False
        Me.Date_Approve.ValidateValue = True
        Me.Date_Approve.Visible = True
        Me.Date_Approve.VisibleIndex = 11
        '
        'DiemTraHang
        '
        Me.DiemTraHang.AllowInsert = True
        Me.DiemTraHang.AllowUpdate = True
        Me.DiemTraHang.ButtonClick = True
        Me.DiemTraHang.Caption = "Điểm trả hàng"
        Me.DiemTraHang.CFLColumnHide = ""
        Me.DiemTraHang.CFLKeyField = ""
        Me.DiemTraHang.CFLPage = False
        Me.DiemTraHang.CFLReturn0 = ""
        Me.DiemTraHang.CFLReturn1 = ""
        Me.DiemTraHang.CFLReturn2 = ""
        Me.DiemTraHang.CFLReturn3 = ""
        Me.DiemTraHang.CFLReturn4 = ""
        Me.DiemTraHang.CFLReturn5 = ""
        Me.DiemTraHang.CFLReturn6 = ""
        Me.DiemTraHang.CFLReturn7 = ""
        Me.DiemTraHang.CFLShowLoad = False
        Me.DiemTraHang.ChangeFormStatus = True
        Me.DiemTraHang.ColumnKey = False
        Me.DiemTraHang.ComboLine = 5
        Me.DiemTraHang.CopyFromItem = ""
        Me.DiemTraHang.DefaultButtonClick = False
        Me.DiemTraHang.Digit = False
        Me.DiemTraHang.FieldType = "C"
        Me.DiemTraHang.FieldView = "DiemTraHang"
        Me.DiemTraHang.FormarNumber = True
        Me.DiemTraHang.FormList = False
        Me.DiemTraHang.KeyInsert = ""
        Me.DiemTraHang.LocalDecimal = False
        Me.DiemTraHang.Name = "DiemTraHang"
        Me.DiemTraHang.NoUpdate = ""
        Me.DiemTraHang.NumberDecimal = 0
        Me.DiemTraHang.ParentControl = ""
        Me.DiemTraHang.RefreshSource = False
        Me.DiemTraHang.Required = False
        Me.DiemTraHang.SequenceName = ""
        Me.DiemTraHang.ShowCalc = True
        Me.DiemTraHang.ShowDataTime = False
        Me.DiemTraHang.ShowOnlyTime = False
        Me.DiemTraHang.SQLString = ""
        Me.DiemTraHang.UpdateIfNull = ""
        Me.DiemTraHang.UpdateWhenFormLock = False
        Me.DiemTraHang.UpperValue = False
        Me.DiemTraHang.ValidateValue = True
        Me.DiemTraHang.Visible = True
        Me.DiemTraHang.VisibleIndex = 12
        '
        'LoaiPhieu
        '
        Me.LoaiPhieu.AllowInsert = True
        Me.LoaiPhieu.AllowUpdate = True
        Me.LoaiPhieu.ButtonClick = True
        Me.LoaiPhieu.Caption = "Chuyến vận tải"
        Me.LoaiPhieu.CFLColumnHide = ""
        Me.LoaiPhieu.CFLKeyField = ""
        Me.LoaiPhieu.CFLPage = False
        Me.LoaiPhieu.CFLReturn0 = ""
        Me.LoaiPhieu.CFLReturn1 = ""
        Me.LoaiPhieu.CFLReturn2 = ""
        Me.LoaiPhieu.CFLReturn3 = ""
        Me.LoaiPhieu.CFLReturn4 = ""
        Me.LoaiPhieu.CFLReturn5 = ""
        Me.LoaiPhieu.CFLReturn6 = ""
        Me.LoaiPhieu.CFLReturn7 = ""
        Me.LoaiPhieu.CFLShowLoad = False
        Me.LoaiPhieu.ChangeFormStatus = True
        Me.LoaiPhieu.ColumnKey = False
        Me.LoaiPhieu.ComboLine = 5
        Me.LoaiPhieu.CopyFromItem = ""
        Me.LoaiPhieu.DefaultButtonClick = False
        Me.LoaiPhieu.Digit = False
        Me.LoaiPhieu.FieldType = "C"
        Me.LoaiPhieu.FieldView = "LoaiPhieu"
        Me.LoaiPhieu.FormarNumber = True
        Me.LoaiPhieu.FormList = False
        Me.LoaiPhieu.KeyInsert = ""
        Me.LoaiPhieu.LocalDecimal = False
        Me.LoaiPhieu.Name = "LoaiPhieu"
        Me.LoaiPhieu.NoUpdate = ""
        Me.LoaiPhieu.NumberDecimal = 0
        Me.LoaiPhieu.ParentControl = ""
        Me.LoaiPhieu.RefreshSource = False
        Me.LoaiPhieu.Required = False
        Me.LoaiPhieu.SequenceName = ""
        Me.LoaiPhieu.ShowCalc = True
        Me.LoaiPhieu.ShowDataTime = False
        Me.LoaiPhieu.ShowOnlyTime = False
        Me.LoaiPhieu.SQLString = ""
        Me.LoaiPhieu.UpdateIfNull = ""
        Me.LoaiPhieu.UpdateWhenFormLock = False
        Me.LoaiPhieu.UpperValue = False
        Me.LoaiPhieu.ValidateValue = True
        Me.LoaiPhieu.Visible = True
        Me.LoaiPhieu.VisibleIndex = 13
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'GridColumn1
        '
        Me.GridColumn1.AllowInsert = True
        Me.GridColumn1.AllowUpdate = True
        Me.GridColumn1.ButtonClick = True
        Me.GridColumn1.Caption = "ctlColumn2"
        Me.GridColumn1.CFLColumnHide = ""
        Me.GridColumn1.CFLKeyField = ""
        Me.GridColumn1.CFLPage = False
        Me.GridColumn1.CFLReturn0 = ""
        Me.GridColumn1.CFLReturn1 = ""
        Me.GridColumn1.CFLReturn2 = ""
        Me.GridColumn1.CFLReturn3 = ""
        Me.GridColumn1.CFLReturn4 = ""
        Me.GridColumn1.CFLReturn5 = ""
        Me.GridColumn1.CFLReturn6 = ""
        Me.GridColumn1.CFLReturn7 = ""
        Me.GridColumn1.CFLShowLoad = False
        Me.GridColumn1.ChangeFormStatus = True
        Me.GridColumn1.ColumnKey = False
        Me.GridColumn1.ComboLine = 5
        Me.GridColumn1.CopyFromItem = ""
        Me.GridColumn1.DefaultButtonClick = False
        Me.GridColumn1.Digit = False
        Me.GridColumn1.FieldType = "C"
        Me.GridColumn1.FieldView = ""
        Me.GridColumn1.FormarNumber = True
        Me.GridColumn1.FormList = False
        Me.GridColumn1.KeyInsert = ""
        Me.GridColumn1.LocalDecimal = False
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.NoUpdate = ""
        Me.GridColumn1.NumberDecimal = 0
        Me.GridColumn1.ParentControl = ""
        Me.GridColumn1.RefreshSource = False
        Me.GridColumn1.Required = False
        Me.GridColumn1.SequenceName = ""
        Me.GridColumn1.ShowCalc = True
        Me.GridColumn1.ShowDataTime = False
        Me.GridColumn1.ShowOnlyTime = False
        Me.GridColumn1.SQLString = ""
        Me.GridColumn1.UpdateIfNull = ""
        Me.GridColumn1.UpdateWhenFormLock = False
        Me.GridColumn1.UpperValue = False
        Me.GridColumn1.ValidateValue = True
        Me.GridColumn1.Visible = True
        '
        'GridColumn2
        '
        Me.GridColumn2.AllowInsert = True
        Me.GridColumn2.AllowUpdate = True
        Me.GridColumn2.ButtonClick = True
        Me.GridColumn2.Caption = "ctlColumn3"
        Me.GridColumn2.CFLColumnHide = ""
        Me.GridColumn2.CFLKeyField = ""
        Me.GridColumn2.CFLPage = False
        Me.GridColumn2.CFLReturn0 = ""
        Me.GridColumn2.CFLReturn1 = ""
        Me.GridColumn2.CFLReturn2 = ""
        Me.GridColumn2.CFLReturn3 = ""
        Me.GridColumn2.CFLReturn4 = ""
        Me.GridColumn2.CFLReturn5 = ""
        Me.GridColumn2.CFLReturn6 = ""
        Me.GridColumn2.CFLReturn7 = ""
        Me.GridColumn2.CFLShowLoad = False
        Me.GridColumn2.ChangeFormStatus = True
        Me.GridColumn2.ColumnKey = False
        Me.GridColumn2.ComboLine = 5
        Me.GridColumn2.CopyFromItem = ""
        Me.GridColumn2.DefaultButtonClick = False
        Me.GridColumn2.Digit = False
        Me.GridColumn2.FieldType = "C"
        Me.GridColumn2.FieldView = ""
        Me.GridColumn2.FormarNumber = True
        Me.GridColumn2.FormList = False
        Me.GridColumn2.KeyInsert = ""
        Me.GridColumn2.LocalDecimal = False
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.NoUpdate = ""
        Me.GridColumn2.NumberDecimal = 0
        Me.GridColumn2.ParentControl = ""
        Me.GridColumn2.RefreshSource = False
        Me.GridColumn2.Required = False
        Me.GridColumn2.SequenceName = ""
        Me.GridColumn2.ShowCalc = True
        Me.GridColumn2.ShowDataTime = False
        Me.GridColumn2.ShowOnlyTime = False
        Me.GridColumn2.SQLString = ""
        Me.GridColumn2.UpdateIfNull = ""
        Me.GridColumn2.UpdateWhenFormLock = False
        Me.GridColumn2.UpperValue = False
        Me.GridColumn2.ValidateValue = True
        Me.GridColumn2.Visible = True
        '
        'GridColumn3
        '
        Me.GridColumn3.AllowInsert = True
        Me.GridColumn3.AllowUpdate = True
        Me.GridColumn3.ButtonClick = True
        Me.GridColumn3.Caption = "ctlColumn4"
        Me.GridColumn3.CFLColumnHide = ""
        Me.GridColumn3.CFLKeyField = ""
        Me.GridColumn3.CFLPage = False
        Me.GridColumn3.CFLReturn0 = ""
        Me.GridColumn3.CFLReturn1 = ""
        Me.GridColumn3.CFLReturn2 = ""
        Me.GridColumn3.CFLReturn3 = ""
        Me.GridColumn3.CFLReturn4 = ""
        Me.GridColumn3.CFLReturn5 = ""
        Me.GridColumn3.CFLReturn6 = ""
        Me.GridColumn3.CFLReturn7 = ""
        Me.GridColumn3.CFLShowLoad = False
        Me.GridColumn3.ChangeFormStatus = True
        Me.GridColumn3.ColumnKey = False
        Me.GridColumn3.ComboLine = 5
        Me.GridColumn3.CopyFromItem = ""
        Me.GridColumn3.DefaultButtonClick = False
        Me.GridColumn3.Digit = False
        Me.GridColumn3.FieldType = "C"
        Me.GridColumn3.FieldView = ""
        Me.GridColumn3.FormarNumber = True
        Me.GridColumn3.FormList = False
        Me.GridColumn3.KeyInsert = ""
        Me.GridColumn3.LocalDecimal = False
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.NoUpdate = ""
        Me.GridColumn3.NumberDecimal = 0
        Me.GridColumn3.ParentControl = ""
        Me.GridColumn3.RefreshSource = False
        Me.GridColumn3.Required = False
        Me.GridColumn3.SequenceName = ""
        Me.GridColumn3.ShowCalc = True
        Me.GridColumn3.ShowDataTime = False
        Me.GridColumn3.ShowOnlyTime = False
        Me.GridColumn3.SQLString = ""
        Me.GridColumn3.UpdateIfNull = ""
        Me.GridColumn3.UpdateWhenFormLock = False
        Me.GridColumn3.UpperValue = False
        Me.GridColumn3.ValidateValue = True
        Me.GridColumn3.Visible = True
        '
        'GridColumn4
        '
        Me.GridColumn4.AllowInsert = True
        Me.GridColumn4.AllowUpdate = True
        Me.GridColumn4.ButtonClick = True
        Me.GridColumn4.Caption = "ctlColumn5"
        Me.GridColumn4.CFLColumnHide = ""
        Me.GridColumn4.CFLKeyField = ""
        Me.GridColumn4.CFLPage = False
        Me.GridColumn4.CFLReturn0 = ""
        Me.GridColumn4.CFLReturn1 = ""
        Me.GridColumn4.CFLReturn2 = ""
        Me.GridColumn4.CFLReturn3 = ""
        Me.GridColumn4.CFLReturn4 = ""
        Me.GridColumn4.CFLReturn5 = ""
        Me.GridColumn4.CFLReturn6 = ""
        Me.GridColumn4.CFLReturn7 = ""
        Me.GridColumn4.CFLShowLoad = False
        Me.GridColumn4.ChangeFormStatus = True
        Me.GridColumn4.ColumnKey = False
        Me.GridColumn4.ComboLine = 5
        Me.GridColumn4.CopyFromItem = ""
        Me.GridColumn4.DefaultButtonClick = False
        Me.GridColumn4.Digit = False
        Me.GridColumn4.FieldType = "C"
        Me.GridColumn4.FieldView = ""
        Me.GridColumn4.FormarNumber = True
        Me.GridColumn4.FormList = False
        Me.GridColumn4.KeyInsert = ""
        Me.GridColumn4.LocalDecimal = False
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.NoUpdate = ""
        Me.GridColumn4.NumberDecimal = 0
        Me.GridColumn4.ParentControl = ""
        Me.GridColumn4.RefreshSource = False
        Me.GridColumn4.Required = False
        Me.GridColumn4.SequenceName = ""
        Me.GridColumn4.ShowCalc = True
        Me.GridColumn4.ShowDataTime = False
        Me.GridColumn4.ShowOnlyTime = False
        Me.GridColumn4.SQLString = ""
        Me.GridColumn4.UpdateIfNull = ""
        Me.GridColumn4.UpdateWhenFormLock = False
        Me.GridColumn4.UpperValue = False
        Me.GridColumn4.ValidateValue = True
        Me.GridColumn4.Visible = True
        '
        'GridColumn5
        '
        Me.GridColumn5.AllowInsert = True
        Me.GridColumn5.AllowUpdate = True
        Me.GridColumn5.ButtonClick = True
        Me.GridColumn5.Caption = "ctlColumn6"
        Me.GridColumn5.CFLColumnHide = ""
        Me.GridColumn5.CFLKeyField = ""
        Me.GridColumn5.CFLPage = False
        Me.GridColumn5.CFLReturn0 = ""
        Me.GridColumn5.CFLReturn1 = ""
        Me.GridColumn5.CFLReturn2 = ""
        Me.GridColumn5.CFLReturn3 = ""
        Me.GridColumn5.CFLReturn4 = ""
        Me.GridColumn5.CFLReturn5 = ""
        Me.GridColumn5.CFLReturn6 = ""
        Me.GridColumn5.CFLReturn7 = ""
        Me.GridColumn5.CFLShowLoad = False
        Me.GridColumn5.ChangeFormStatus = True
        Me.GridColumn5.ColumnKey = False
        Me.GridColumn5.ComboLine = 5
        Me.GridColumn5.CopyFromItem = ""
        Me.GridColumn5.DefaultButtonClick = False
        Me.GridColumn5.Digit = False
        Me.GridColumn5.FieldType = "C"
        Me.GridColumn5.FieldView = ""
        Me.GridColumn5.FormarNumber = True
        Me.GridColumn5.FormList = False
        Me.GridColumn5.KeyInsert = ""
        Me.GridColumn5.LocalDecimal = False
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.NoUpdate = ""
        Me.GridColumn5.NumberDecimal = 0
        Me.GridColumn5.ParentControl = ""
        Me.GridColumn5.RefreshSource = False
        Me.GridColumn5.Required = False
        Me.GridColumn5.SequenceName = ""
        Me.GridColumn5.ShowCalc = True
        Me.GridColumn5.ShowDataTime = False
        Me.GridColumn5.ShowOnlyTime = False
        Me.GridColumn5.SQLString = ""
        Me.GridColumn5.UpdateIfNull = ""
        Me.GridColumn5.UpdateWhenFormLock = False
        Me.GridColumn5.UpperValue = False
        Me.GridColumn5.ValidateValue = True
        Me.GridColumn5.Visible = True
        '
        'GridColumn6
        '
        Me.GridColumn6.AllowInsert = True
        Me.GridColumn6.AllowUpdate = True
        Me.GridColumn6.ButtonClick = True
        Me.GridColumn6.Caption = "ctlColumn7"
        Me.GridColumn6.CFLColumnHide = ""
        Me.GridColumn6.CFLKeyField = ""
        Me.GridColumn6.CFLPage = False
        Me.GridColumn6.CFLReturn0 = ""
        Me.GridColumn6.CFLReturn1 = ""
        Me.GridColumn6.CFLReturn2 = ""
        Me.GridColumn6.CFLReturn3 = ""
        Me.GridColumn6.CFLReturn4 = ""
        Me.GridColumn6.CFLReturn5 = ""
        Me.GridColumn6.CFLReturn6 = ""
        Me.GridColumn6.CFLReturn7 = ""
        Me.GridColumn6.CFLShowLoad = False
        Me.GridColumn6.ChangeFormStatus = True
        Me.GridColumn6.ColumnKey = False
        Me.GridColumn6.ComboLine = 5
        Me.GridColumn6.CopyFromItem = ""
        Me.GridColumn6.DefaultButtonClick = False
        Me.GridColumn6.Digit = False
        Me.GridColumn6.FieldType = "C"
        Me.GridColumn6.FieldView = ""
        Me.GridColumn6.FormarNumber = True
        Me.GridColumn6.FormList = False
        Me.GridColumn6.KeyInsert = ""
        Me.GridColumn6.LocalDecimal = False
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.NoUpdate = ""
        Me.GridColumn6.NumberDecimal = 0
        Me.GridColumn6.ParentControl = ""
        Me.GridColumn6.RefreshSource = False
        Me.GridColumn6.Required = False
        Me.GridColumn6.SequenceName = ""
        Me.GridColumn6.ShowCalc = True
        Me.GridColumn6.ShowDataTime = False
        Me.GridColumn6.ShowOnlyTime = False
        Me.GridColumn6.SQLString = ""
        Me.GridColumn6.UpdateIfNull = ""
        Me.GridColumn6.UpdateWhenFormLock = False
        Me.GridColumn6.UpperValue = False
        Me.GridColumn6.ValidateValue = True
        Me.GridColumn6.Visible = True
        '
        'GridColumn7
        '
        Me.GridColumn7.AllowInsert = True
        Me.GridColumn7.AllowUpdate = True
        Me.GridColumn7.ButtonClick = True
        Me.GridColumn7.Caption = "ctlColumn8"
        Me.GridColumn7.CFLColumnHide = ""
        Me.GridColumn7.CFLKeyField = ""
        Me.GridColumn7.CFLPage = False
        Me.GridColumn7.CFLReturn0 = ""
        Me.GridColumn7.CFLReturn1 = ""
        Me.GridColumn7.CFLReturn2 = ""
        Me.GridColumn7.CFLReturn3 = ""
        Me.GridColumn7.CFLReturn4 = ""
        Me.GridColumn7.CFLReturn5 = ""
        Me.GridColumn7.CFLReturn6 = ""
        Me.GridColumn7.CFLReturn7 = ""
        Me.GridColumn7.CFLShowLoad = False
        Me.GridColumn7.ChangeFormStatus = True
        Me.GridColumn7.ColumnKey = False
        Me.GridColumn7.ComboLine = 5
        Me.GridColumn7.CopyFromItem = ""
        Me.GridColumn7.DefaultButtonClick = False
        Me.GridColumn7.Digit = False
        Me.GridColumn7.FieldType = "C"
        Me.GridColumn7.FieldView = ""
        Me.GridColumn7.FormarNumber = True
        Me.GridColumn7.FormList = False
        Me.GridColumn7.KeyInsert = ""
        Me.GridColumn7.LocalDecimal = False
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.NoUpdate = ""
        Me.GridColumn7.NumberDecimal = 0
        Me.GridColumn7.ParentControl = ""
        Me.GridColumn7.RefreshSource = False
        Me.GridColumn7.Required = False
        Me.GridColumn7.SequenceName = ""
        Me.GridColumn7.ShowCalc = True
        Me.GridColumn7.ShowDataTime = False
        Me.GridColumn7.ShowOnlyTime = False
        Me.GridColumn7.SQLString = ""
        Me.GridColumn7.UpdateIfNull = ""
        Me.GridColumn7.UpdateWhenFormLock = False
        Me.GridColumn7.UpperValue = False
        Me.GridColumn7.ValidateValue = True
        Me.GridColumn7.Visible = True
        '
        'GridColumn8
        '
        Me.GridColumn8.AllowInsert = True
        Me.GridColumn8.AllowUpdate = True
        Me.GridColumn8.ButtonClick = True
        Me.GridColumn8.Caption = "ctlColumn9"
        Me.GridColumn8.CFLColumnHide = ""
        Me.GridColumn8.CFLKeyField = ""
        Me.GridColumn8.CFLPage = False
        Me.GridColumn8.CFLReturn0 = ""
        Me.GridColumn8.CFLReturn1 = ""
        Me.GridColumn8.CFLReturn2 = ""
        Me.GridColumn8.CFLReturn3 = ""
        Me.GridColumn8.CFLReturn4 = ""
        Me.GridColumn8.CFLReturn5 = ""
        Me.GridColumn8.CFLReturn6 = ""
        Me.GridColumn8.CFLReturn7 = ""
        Me.GridColumn8.CFLShowLoad = False
        Me.GridColumn8.ChangeFormStatus = True
        Me.GridColumn8.ColumnKey = False
        Me.GridColumn8.ComboLine = 5
        Me.GridColumn8.CopyFromItem = ""
        Me.GridColumn8.DefaultButtonClick = False
        Me.GridColumn8.Digit = False
        Me.GridColumn8.FieldType = "C"
        Me.GridColumn8.FieldView = ""
        Me.GridColumn8.FormarNumber = True
        Me.GridColumn8.FormList = False
        Me.GridColumn8.KeyInsert = ""
        Me.GridColumn8.LocalDecimal = False
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.NoUpdate = ""
        Me.GridColumn8.NumberDecimal = 0
        Me.GridColumn8.ParentControl = ""
        Me.GridColumn8.RefreshSource = False
        Me.GridColumn8.Required = False
        Me.GridColumn8.SequenceName = ""
        Me.GridColumn8.ShowCalc = True
        Me.GridColumn8.ShowDataTime = False
        Me.GridColumn8.ShowOnlyTime = False
        Me.GridColumn8.SQLString = ""
        Me.GridColumn8.UpdateIfNull = ""
        Me.GridColumn8.UpdateWhenFormLock = False
        Me.GridColumn8.UpperValue = False
        Me.GridColumn8.ValidateValue = True
        Me.GridColumn8.Visible = True
        '
        'GridColumn9
        '
        Me.GridColumn9.AllowInsert = True
        Me.GridColumn9.AllowUpdate = True
        Me.GridColumn9.ButtonClick = True
        Me.GridColumn9.Caption = "ctlColumn10"
        Me.GridColumn9.CFLColumnHide = ""
        Me.GridColumn9.CFLKeyField = ""
        Me.GridColumn9.CFLPage = False
        Me.GridColumn9.CFLReturn0 = ""
        Me.GridColumn9.CFLReturn1 = ""
        Me.GridColumn9.CFLReturn2 = ""
        Me.GridColumn9.CFLReturn3 = ""
        Me.GridColumn9.CFLReturn4 = ""
        Me.GridColumn9.CFLReturn5 = ""
        Me.GridColumn9.CFLReturn6 = ""
        Me.GridColumn9.CFLReturn7 = ""
        Me.GridColumn9.CFLShowLoad = False
        Me.GridColumn9.ChangeFormStatus = True
        Me.GridColumn9.ColumnKey = False
        Me.GridColumn9.ComboLine = 5
        Me.GridColumn9.CopyFromItem = ""
        Me.GridColumn9.DefaultButtonClick = False
        Me.GridColumn9.Digit = False
        Me.GridColumn9.FieldType = "C"
        Me.GridColumn9.FieldView = ""
        Me.GridColumn9.FormarNumber = True
        Me.GridColumn9.FormList = False
        Me.GridColumn9.KeyInsert = ""
        Me.GridColumn9.LocalDecimal = False
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.NoUpdate = ""
        Me.GridColumn9.NumberDecimal = 0
        Me.GridColumn9.ParentControl = ""
        Me.GridColumn9.RefreshSource = False
        Me.GridColumn9.Required = False
        Me.GridColumn9.SequenceName = ""
        Me.GridColumn9.ShowCalc = True
        Me.GridColumn9.ShowDataTime = False
        Me.GridColumn9.ShowOnlyTime = False
        Me.GridColumn9.SQLString = ""
        Me.GridColumn9.UpdateIfNull = ""
        Me.GridColumn9.UpdateWhenFormLock = False
        Me.GridColumn9.UpperValue = False
        Me.GridColumn9.ValidateValue = True
        Me.GridColumn9.Visible = True
        '
        'U_ButtonEdit1
        '
        Me.U_ButtonEdit1.AllowInsert = True
        Me.U_ButtonEdit1.AllowUpdate = True
        Me.U_ButtonEdit1.AutoWidth = False
        Me.U_ButtonEdit1.BindingSourceName = ""
        Me.U_ButtonEdit1.ChangeFormStatus = False
        Me.U_ButtonEdit1.CopyFromItem = ""
        Me.U_ButtonEdit1.DefaultButtonClick = True
        Me.U_ButtonEdit1.DefaultValue = ""
        Me.U_ButtonEdit1.FieldName = ""
        Me.U_ButtonEdit1.FieldType = ""
        Me.U_ButtonEdit1.FormList = False
        Me.U_ButtonEdit1.ItemReturn1 = ""
        Me.U_ButtonEdit1.ItemReturn2 = ""
        Me.U_ButtonEdit1.ItemReturn3 = ""
        Me.U_ButtonEdit1.KeyInsert = ""
        Me.U_ButtonEdit1.LinkLabel = ""
        Me.U_ButtonEdit1.Location = New System.Drawing.Point(594, 12)
        Me.U_ButtonEdit1.MultiSelect = False
        Me.U_ButtonEdit1.Name = "U_ButtonEdit1"
        Me.U_ButtonEdit1.NoUpdate = "N"
        Me.U_ButtonEdit1.OrderbyEx = ""
        Me.U_ButtonEdit1.PrimaryKey = ""
        Me.U_ButtonEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_ButtonEdit1.Properties.Appearance.Options.UseFont = True
        Me.U_ButtonEdit1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_ButtonEdit1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_ButtonEdit1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_ButtonEdit1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_ButtonEdit1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_ButtonEdit1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_ButtonEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.U_ButtonEdit1.Required = ""
        Me.U_ButtonEdit1.ShowLoad = False
        Me.U_ButtonEdit1.Size = New System.Drawing.Size(273, 26)
        Me.U_ButtonEdit1.SqlFielKey = "DiemTraHang"
        Me.U_ButtonEdit1.SqlString = "select  distinct DiemTraHang from FPT_tblLenhXuatE5_V  where DiemTraHang is not n" & _
            "ull and DiemTraHang <> ''"
        Me.U_ButtonEdit1.TabIndex = 2
        Me.U_ButtonEdit1.TableName = ""
        Me.U_ButtonEdit1.UpdateIfNull = ""
        Me.U_ButtonEdit1.UpdateWhenFormLock = False
        Me.U_ButtonEdit1.UpperValue = False
        Me.U_ButtonEdit1.ValidateValue = True
        Me.U_ButtonEdit1.ViewName = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(479, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 19)
        Me.Label3.TabIndex = 200
        Me.Label3.Text = "Điểm trả hàng"
        '
        'cmdSoLenh
        '
        Me.cmdSoLenh.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSoLenh.Appearance.Options.UseFont = True
        Me.cmdSoLenh.DefaultUpdate = True
        Me.cmdSoLenh.EnableWhenFormLock = True
        Me.cmdSoLenh.Location = New System.Drawing.Point(1004, 9)
        Me.cmdSoLenh.Name = "cmdSoLenh"
        Me.cmdSoLenh.Size = New System.Drawing.Size(195, 29)
        Me.cmdSoLenh.TabIndex = 201
        Me.cmdSoLenh.Text = "Rút lệnh xuất hàng loạt"
        Me.cmdSoLenh.Visible = False
        '
        'FrmQuanLySoLenh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1211, 566)
        Me.Controls.Add(Me.cmdSoLenh)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.U_ButtonEdit1)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.U_DateEdit1)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SoLenh)
        Me.DefaultFormLoad = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmQuanLySoLenh"
        Me.Text = "Quản lý lệnh xuất"
        Me.Controls.SetChildIndex(Me.SoLenh, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton7, 0)
        Me.Controls.SetChildIndex(Me.U_DateEdit1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonEdit1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cmdSoLenh, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_ButtonEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SoLenh As U_TextBox.U_TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents U_DateEdit1 As U_TextBox.U_DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ColNgayXuat As U_TextBox.GridColumn
    Friend WithEvents ColSoLenh As U_TextBox.GridColumn
    Friend WithEvents TenPhuongThucBan As U_TextBox.GridColumn
    Friend WithEvents TenKhachHang As U_TextBox.GridColumn
    Friend WithEvents TenMaVanChuyen As U_TextBox.GridColumn
    Friend WithEvents MaPhuongTien As U_TextBox.GridColumn
    Friend WithEvents Status As U_TextBox.GridColumn
    Friend WithEvents GridColumn1 As U_TextBox.GridColumn
    Friend WithEvents GridColumn2 As U_TextBox.GridColumn
    Friend WithEvents GridColumn3 As U_TextBox.GridColumn
    Friend WithEvents GridColumn4 As U_TextBox.GridColumn
    Friend WithEvents GridColumn5 As U_TextBox.GridColumn
    Friend WithEvents GridColumn6 As U_TextBox.GridColumn
    Friend WithEvents GridColumn7 As U_TextBox.GridColumn
    Friend WithEvents GridColumn8 As U_TextBox.GridColumn
    Friend WithEvents GridColumn9 As U_TextBox.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents User_Approve As U_TextBox.GridColumn
    Friend WithEvents Date_Approve As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents MaNguon As U_TextBox.GridColumn
    Friend WithEvents SimpleButton7 As U_TextBox.U_ButtonCus
    Friend WithEvents DiemTraHang As U_TextBox.GridColumn
    Friend WithEvents LoaiPhieu As U_TextBox.GridColumn
    Friend WithEvents U_ButtonEdit1 As U_TextBox.U_ButtonEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TenHangHoa22 As U_TextBox.GridColumn
    Friend WithEvents CreateDate As U_TextBox.GridColumn
    Friend WithEvents cmdSoLenh As U_TextBox.U_ButtonCus
End Class
