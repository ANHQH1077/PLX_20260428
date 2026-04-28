<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQuanLySoLenh22
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
        Me.CardNum = New U_TextBox.GridColumn()
        Me.ColNgayXuat = New U_TextBox.GridColumn()
        Me.ColSoLenh = New U_TextBox.GridColumn()
        Me.TenPhuongThucBan = New U_TextBox.GridColumn()
        Me.MaNguon = New U_TextBox.GridColumn()
        Me.TenKhachHang = New U_TextBox.GridColumn()
        Me.TenMaVanChuyen = New U_TextBox.GridColumn()
        Me.MaPhuongTien = New U_TextBox.GridColumn()
        Me.Status = New U_TextBox.GridColumn()
        Me.User_Approve = New U_TextBox.GridColumn()
        Me.Date_Approve = New U_TextBox.GridColumn()
        Me.DiemTraHang = New U_TextBox.GridColumn()
        Me.LoaiPhieu = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CardCode = New U_TextBox.U_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.U_DateEdit1 = New U_TextBox.U_DateEdit()
        Me.SimpleButton7 = New U_TextBox.U_ButtonCus(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SoLenh = New U_TextBox.U_TextBox()
        Me.U_CheckBox1 = New U_TextBox.U_CheckBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CheckBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(1, 44)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(1092, 386)
        Me.TrueDBGrid1.TabIndex = 2
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
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.CardNum, Me.ColNgayXuat, Me.ColSoLenh, Me.TenPhuongThucBan, Me.MaNguon, Me.TenKhachHang, Me.TenMaVanChuyen, Me.MaPhuongTien, Me.Status, Me.User_Approve, Me.Date_Approve, Me.DiemTraHang, Me.LoaiPhieu})
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
        'CardNum
        '
        Me.CardNum.AllowInsert = True
        Me.CardNum.AllowUpdate = True
        Me.CardNum.ButtonClick = True
        Me.CardNum.Caption = "Số thẻ"
        Me.CardNum.CFLColumnHide = ""
        Me.CardNum.CFLKeyField = ""
        Me.CardNum.CFLPage = False
        Me.CardNum.CFLReturn0 = ""
        Me.CardNum.CFLReturn1 = ""
        Me.CardNum.CFLReturn2 = ""
        Me.CardNum.CFLReturn3 = ""
        Me.CardNum.CFLReturn4 = ""
        Me.CardNum.CFLReturn5 = ""
        Me.CardNum.CFLReturn6 = ""
        Me.CardNum.CFLReturn7 = ""
        Me.CardNum.CFLShowLoad = False
        Me.CardNum.ChangeFormStatus = True
        Me.CardNum.ColumnKey = False
        Me.CardNum.ComboLine = 5
        Me.CardNum.CopyFromItem = ""
        Me.CardNum.DefaultButtonClick = False
        Me.CardNum.Digit = False
        Me.CardNum.FieldType = "C"
        Me.CardNum.FieldView = "CardNum"
        Me.CardNum.FormarNumber = True
        Me.CardNum.FormList = False
        Me.CardNum.KeyInsert = ""
        Me.CardNum.LocalDecimal = False
        Me.CardNum.Name = "CardNum"
        Me.CardNum.NoUpdate = ""
        Me.CardNum.NumberDecimal = 0
        Me.CardNum.OptionsColumn.ReadOnly = True
        Me.CardNum.ParentControl = ""
        Me.CardNum.RefreshSource = False
        Me.CardNum.Required = False
        Me.CardNum.SequenceName = ""
        Me.CardNum.ShowCalc = True
        Me.CardNum.ShowDataTime = False
        Me.CardNum.ShowOnlyTime = False
        Me.CardNum.SQLString = ""
        Me.CardNum.UpdateIfNull = ""
        Me.CardNum.UpdateWhenFormLock = False
        Me.CardNum.UpperValue = False
        Me.CardNum.ValidateValue = True
        Me.CardNum.Visible = True
        Me.CardNum.VisibleIndex = 0
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
        Me.ColNgayXuat.VisibleIndex = 1
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
        Me.ColSoLenh.VisibleIndex = 2
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
        Me.TenMaVanChuyen.VisibleIndex = 6
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
        Me.MaPhuongTien.VisibleIndex = 7
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
        Me.Status.VisibleIndex = 8
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
        Me.User_Approve.VisibleIndex = 9
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
        Me.Date_Approve.VisibleIndex = 10
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
        Me.DiemTraHang.VisibleIndex = 11
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
        Me.LoaiPhieu.VisibleIndex = 12
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 19)
        Me.Label1.TabIndex = 198
        Me.Label1.Text = "Số thẻ"
        '
        'CardCode
        '
        Me.CardCode.AllowInsert = True
        Me.CardCode.AllowUpdate = True
        Me.CardCode.AutoKeyFix = ""
        Me.CardCode.AutoKeyName = ""
        Me.CardCode.BindingSourceName = ""
        Me.CardCode.ChangeFormStatus = False
        Me.CardCode.CopyFromItem = ""
        Me.CardCode.DefaultValue = ""
        Me.CardCode.FieldName = ""
        Me.CardCode.FieldType = ""
        Me.CardCode.KeyInsert = ""
        Me.CardCode.LinkLabel = ""
        Me.CardCode.Location = New System.Drawing.Point(86, 12)
        Me.CardCode.Name = "CardCode"
        Me.CardCode.NoUpdate = "N"
        Me.CardCode.PrimaryKey = ""
        Me.CardCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardCode.Properties.Appearance.Options.UseFont = True
        Me.CardCode.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardCode.Properties.AppearanceDisabled.Options.UseFont = True
        Me.CardCode.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardCode.Properties.AppearanceFocused.Options.UseFont = True
        Me.CardCode.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardCode.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.CardCode.Properties.AutoHeight = False
        Me.CardCode.Properties.MaxLength = 10
        Me.CardCode.Required = ""
        Me.CardCode.Size = New System.Drawing.Size(189, 26)
        Me.CardCode.TabIndex = 197
        Me.CardCode.TableName = ""
        Me.CardCode.UpdateIfNull = ""
        Me.CardCode.UpdateWhenFormLock = True
        Me.CardCode.UpperValue = False
        Me.CardCode.ViewName = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(801, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 19)
        Me.Label2.TabIndex = 200
        Me.Label2.Text = "Ngày xuất"
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
        Me.U_DateEdit1.Location = New System.Drawing.Point(887, 8)
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
        Me.U_DateEdit1.Size = New System.Drawing.Size(112, 26)
        Me.U_DateEdit1.TabIndex = 199
        Me.U_DateEdit1.TableName = ""
        Me.U_DateEdit1.TabStop = False
        Me.U_DateEdit1.UpdateIfNull = ""
        Me.U_DateEdit1.UpdateWhenFormLock = True
        Me.U_DateEdit1.ViewName = ""
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.DefaultUpdate = True
        Me.SimpleButton7.EnableWhenFormLock = True
        Me.SimpleButton7.Location = New System.Drawing.Point(1005, 5)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(79, 29)
        Me.SimpleButton7.TabIndex = 201
        Me.SimpleButton7.Text = "&Tìm kiếm"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(593, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 19)
        Me.Label3.TabIndex = 203
        Me.Label3.Text = "Số lệnh"
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
        Me.SoLenh.Location = New System.Drawing.Point(667, 8)
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
        Me.SoLenh.TabIndex = 202
        Me.SoLenh.TableName = ""
        Me.SoLenh.TabStop = False
        Me.SoLenh.UpdateIfNull = ""
        Me.SoLenh.UpdateWhenFormLock = True
        Me.SoLenh.UpperValue = False
        Me.SoLenh.ViewName = ""
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
        Me.U_CheckBox1.Location = New System.Drawing.Point(450, 5)
        Me.U_CheckBox1.Name = "U_CheckBox1"
        Me.U_CheckBox1.NoUpdate = ""
        Me.U_CheckBox1.PrimaryKey = ""
        Me.U_CheckBox1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.Appearance.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_CheckBox1.Properties.AutoHeight = False
        Me.U_CheckBox1.Properties.Caption = "Lệnh In tích kê"
        Me.U_CheckBox1.Required = ""
        Me.U_CheckBox1.Size = New System.Drawing.Size(137, 30)
        Me.U_CheckBox1.TabIndex = 204
        Me.U_CheckBox1.TableName = ""
        Me.U_CheckBox1.UnCheckValue = "N"
        Me.U_CheckBox1.UpdateIfNull = ""
        Me.U_CheckBox1.UpdateWhenFormLock = False
        Me.U_CheckBox1.ViewName = ""
        '
        'FrmQuanLySoLenh22
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1096, 430)
        Me.Controls.Add(Me.U_CheckBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SoLenh)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.U_DateEdit1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CardCode)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmQuanLySoLenh22"
        Me.Text = "Danh sách Lệnh xuất"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.CardCode, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.U_DateEdit1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton7, 0)
        Me.Controls.SetChildIndex(Me.SoLenh, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.U_CheckBox1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CheckBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ColNgayXuat As U_TextBox.GridColumn
    Friend WithEvents ColSoLenh As U_TextBox.GridColumn
    Friend WithEvents TenPhuongThucBan As U_TextBox.GridColumn
    Friend WithEvents MaNguon As U_TextBox.GridColumn
    Friend WithEvents TenKhachHang As U_TextBox.GridColumn
    Friend WithEvents TenMaVanChuyen As U_TextBox.GridColumn
    Friend WithEvents MaPhuongTien As U_TextBox.GridColumn
    Friend WithEvents Status As U_TextBox.GridColumn
    Friend WithEvents User_Approve As U_TextBox.GridColumn
    Friend WithEvents Date_Approve As U_TextBox.GridColumn
    Friend WithEvents DiemTraHang As U_TextBox.GridColumn
    Friend WithEvents LoaiPhieu As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CardCode As U_TextBox.U_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents U_DateEdit1 As U_TextBox.U_DateEdit
    Friend WithEvents SimpleButton7 As U_TextBox.U_ButtonCus
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SoLenh As U_TextBox.U_TextBox
    Friend WithEvents U_CheckBox1 As U_TextBox.U_CheckBox
    Friend WithEvents CardNum As U_TextBox.GridColumn
End Class
