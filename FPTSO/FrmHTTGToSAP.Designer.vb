<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHTTGToSAP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHTTGToSAP))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.X = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.SoLenh = New U_TextBox.GridColumn()
        Me.NgayXuat = New U_TextBox.GridColumn()
        Me.MaPhuongTien = New U_TextBox.GridColumn()
        Me.NguoiVanChuyen = New U_TextBox.GridColumn()
        Me.MaTuyenDuong = New U_TextBox.GridColumn()
        Me.DiemTraHang = New U_TextBox.GridColumn()
        Me.LoaiPhieu = New U_TextBox.GridColumn()
        Me.MaTraCuu = New U_TextBox.GridColumn()
        Me.MauSoHoaDon = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.SimpleButton7 = New U_TextBox.U_ButtonCus(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Client = New U_TextBox.U_ButtonEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CreateDate = New U_TextBox.U_DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToCreateDate = New U_TextBox.U_DateEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSoLenh = New U_TextBox.U_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.sType = New U_TextBox.U_Combobox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.U_CheckBox1 = New U_TextBox.U_CheckBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreateDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreateDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToCreateDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToCreateDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSoLenh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 94)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemCheckEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(1065, 392)
        Me.TrueDBGrid1.TabIndex = 2
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.CheckUpd = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.X, Me.SoLenh, Me.NgayXuat, Me.MaPhuongTien, Me.NguoiVanChuyen, Me.MaTuyenDuong, Me.DiemTraHang, Me.LoaiPhieu, Me.MaTraCuu, Me.MauSoHoaDon})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = ""
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowHeight = 30
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
        Me.X.ChangeFormStatus = True
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
        Me.X.Width = 35
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
        Me.SoLenh.Caption = "Số Lệnh"
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
        Me.NgayXuat.DisplayFormat.FormatString = "dd-mm-yyyy"
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
        Me.NgayXuat.ShowDataTime = False
        Me.NgayXuat.ShowOnlyTime = False
        Me.NgayXuat.SQLString = ""
        Me.NgayXuat.UpdateIfNull = ""
        Me.NgayXuat.UpdateWhenFormLock = False
        Me.NgayXuat.UpperValue = False
        Me.NgayXuat.ValidateValue = True
        Me.NgayXuat.Visible = True
        Me.NgayXuat.VisibleIndex = 2
        Me.NgayXuat.Width = 100
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
        Me.MaPhuongTien.ShowDataTime = True
        Me.MaPhuongTien.ShowOnlyTime = False
        Me.MaPhuongTien.SQLString = ""
        Me.MaPhuongTien.UpdateIfNull = ""
        Me.MaPhuongTien.UpdateWhenFormLock = False
        Me.MaPhuongTien.UpperValue = False
        Me.MaPhuongTien.ValidateValue = True
        Me.MaPhuongTien.Visible = True
        Me.MaPhuongTien.VisibleIndex = 3
        Me.MaPhuongTien.Width = 110
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
        Me.NguoiVanChuyen.SQLString = ""
        Me.NguoiVanChuyen.UpdateIfNull = ""
        Me.NguoiVanChuyen.UpdateWhenFormLock = False
        Me.NguoiVanChuyen.UpperValue = False
        Me.NguoiVanChuyen.ValidateValue = True
        Me.NguoiVanChuyen.Visible = True
        Me.NguoiVanChuyen.VisibleIndex = 4
        Me.NguoiVanChuyen.Width = 180
        '
        'MaTuyenDuong
        '
        Me.MaTuyenDuong.AllowInsert = True
        Me.MaTuyenDuong.AllowUpdate = True
        Me.MaTuyenDuong.ButtonClick = True
        Me.MaTuyenDuong.Caption = "Tuyến đường"
        Me.MaTuyenDuong.CFLColumnHide = ""
        Me.MaTuyenDuong.CFLKeyField = ""
        Me.MaTuyenDuong.CFLPage = False
        Me.MaTuyenDuong.CFLReturn0 = ""
        Me.MaTuyenDuong.CFLReturn1 = ""
        Me.MaTuyenDuong.CFLReturn2 = ""
        Me.MaTuyenDuong.CFLReturn3 = ""
        Me.MaTuyenDuong.CFLReturn4 = ""
        Me.MaTuyenDuong.CFLReturn5 = ""
        Me.MaTuyenDuong.CFLReturn6 = ""
        Me.MaTuyenDuong.CFLReturn7 = ""
        Me.MaTuyenDuong.CFLShowLoad = False
        Me.MaTuyenDuong.ChangeFormStatus = True
        Me.MaTuyenDuong.ColumnKey = False
        Me.MaTuyenDuong.ComboLine = 5
        Me.MaTuyenDuong.CopyFromItem = ""
        Me.MaTuyenDuong.DefaultButtonClick = False
        Me.MaTuyenDuong.Digit = False
        Me.MaTuyenDuong.FieldType = "C"
        Me.MaTuyenDuong.FieldView = "MaTuyenDuong"
        Me.MaTuyenDuong.FormarNumber = True
        Me.MaTuyenDuong.FormList = False
        Me.MaTuyenDuong.KeyInsert = ""
        Me.MaTuyenDuong.LocalDecimal = False
        Me.MaTuyenDuong.Name = "MaTuyenDuong"
        Me.MaTuyenDuong.NoUpdate = ""
        Me.MaTuyenDuong.NumberDecimal = 0
        Me.MaTuyenDuong.OptionsColumn.ReadOnly = True
        Me.MaTuyenDuong.ParentControl = ""
        Me.MaTuyenDuong.RefreshSource = False
        Me.MaTuyenDuong.Required = False
        Me.MaTuyenDuong.SequenceName = ""
        Me.MaTuyenDuong.ShowCalc = True
        Me.MaTuyenDuong.ShowDataTime = False
        Me.MaTuyenDuong.ShowOnlyTime = False
        Me.MaTuyenDuong.SQLString = ""
        Me.MaTuyenDuong.UpdateIfNull = ""
        Me.MaTuyenDuong.UpdateWhenFormLock = False
        Me.MaTuyenDuong.UpperValue = False
        Me.MaTuyenDuong.ValidateValue = True
        Me.MaTuyenDuong.Visible = True
        Me.MaTuyenDuong.VisibleIndex = 5
        Me.MaTuyenDuong.Width = 120
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
        Me.DiemTraHang.OptionsColumn.ReadOnly = True
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
        Me.DiemTraHang.VisibleIndex = 6
        Me.DiemTraHang.Width = 150
        '
        'LoaiPhieu
        '
        Me.LoaiPhieu.AllowInsert = True
        Me.LoaiPhieu.AllowUpdate = True
        Me.LoaiPhieu.ButtonClick = True
        Me.LoaiPhieu.Caption = "Chuyến VT"
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
        Me.LoaiPhieu.OptionsColumn.ReadOnly = True
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
        Me.LoaiPhieu.VisibleIndex = 7
        Me.LoaiPhieu.Width = 100
        '
        'MaTraCuu
        '
        Me.MaTraCuu.AllowInsert = True
        Me.MaTraCuu.AllowUpdate = True
        Me.MaTraCuu.ButtonClick = True
        Me.MaTraCuu.Caption = "Mã tra cứu"
        Me.MaTraCuu.CFLColumnHide = ""
        Me.MaTraCuu.CFLKeyField = ""
        Me.MaTraCuu.CFLPage = False
        Me.MaTraCuu.CFLReturn0 = ""
        Me.MaTraCuu.CFLReturn1 = ""
        Me.MaTraCuu.CFLReturn2 = ""
        Me.MaTraCuu.CFLReturn3 = ""
        Me.MaTraCuu.CFLReturn4 = ""
        Me.MaTraCuu.CFLReturn5 = ""
        Me.MaTraCuu.CFLReturn6 = ""
        Me.MaTraCuu.CFLReturn7 = ""
        Me.MaTraCuu.CFLShowLoad = False
        Me.MaTraCuu.ChangeFormStatus = True
        Me.MaTraCuu.ColumnKey = False
        Me.MaTraCuu.ComboLine = 5
        Me.MaTraCuu.CopyFromItem = ""
        Me.MaTraCuu.DefaultButtonClick = False
        Me.MaTraCuu.Digit = False
        Me.MaTraCuu.FieldType = "C"
        Me.MaTraCuu.FieldView = "MaTraCuu"
        Me.MaTraCuu.FormarNumber = True
        Me.MaTraCuu.FormList = False
        Me.MaTraCuu.KeyInsert = ""
        Me.MaTraCuu.LocalDecimal = False
        Me.MaTraCuu.Name = "MaTraCuu"
        Me.MaTraCuu.NoUpdate = ""
        Me.MaTraCuu.NumberDecimal = 0
        Me.MaTraCuu.OptionsColumn.ReadOnly = True
        Me.MaTraCuu.ParentControl = ""
        Me.MaTraCuu.RefreshSource = False
        Me.MaTraCuu.Required = False
        Me.MaTraCuu.SequenceName = ""
        Me.MaTraCuu.ShowCalc = True
        Me.MaTraCuu.ShowDataTime = False
        Me.MaTraCuu.ShowOnlyTime = False
        Me.MaTraCuu.SQLString = ""
        Me.MaTraCuu.UpdateIfNull = ""
        Me.MaTraCuu.UpdateWhenFormLock = False
        Me.MaTraCuu.UpperValue = False
        Me.MaTraCuu.ValidateValue = True
        Me.MaTraCuu.Visible = True
        Me.MaTraCuu.VisibleIndex = 8
        Me.MaTraCuu.Width = 110
        '
        'MauSoHoaDon
        '
        Me.MauSoHoaDon.AllowInsert = True
        Me.MauSoHoaDon.AllowUpdate = True
        Me.MauSoHoaDon.ButtonClick = True
        Me.MauSoHoaDon.Caption = "Mẫu số hóa đơn"
        Me.MauSoHoaDon.CFLColumnHide = ""
        Me.MauSoHoaDon.CFLKeyField = ""
        Me.MauSoHoaDon.CFLPage = False
        Me.MauSoHoaDon.CFLReturn0 = ""
        Me.MauSoHoaDon.CFLReturn1 = ""
        Me.MauSoHoaDon.CFLReturn2 = ""
        Me.MauSoHoaDon.CFLReturn3 = ""
        Me.MauSoHoaDon.CFLReturn4 = ""
        Me.MauSoHoaDon.CFLReturn5 = ""
        Me.MauSoHoaDon.CFLReturn6 = ""
        Me.MauSoHoaDon.CFLReturn7 = ""
        Me.MauSoHoaDon.CFLShowLoad = False
        Me.MauSoHoaDon.ChangeFormStatus = True
        Me.MauSoHoaDon.ColumnKey = False
        Me.MauSoHoaDon.ComboLine = 5
        Me.MauSoHoaDon.CopyFromItem = ""
        Me.MauSoHoaDon.DefaultButtonClick = False
        Me.MauSoHoaDon.Digit = False
        Me.MauSoHoaDon.FieldType = "C"
        Me.MauSoHoaDon.FieldView = "MauSoHoaDon"
        Me.MauSoHoaDon.FormarNumber = True
        Me.MauSoHoaDon.FormList = False
        Me.MauSoHoaDon.KeyInsert = ""
        Me.MauSoHoaDon.LocalDecimal = False
        Me.MauSoHoaDon.Name = "MauSoHoaDon"
        Me.MauSoHoaDon.NoUpdate = ""
        Me.MauSoHoaDon.NumberDecimal = 0
        Me.MauSoHoaDon.OptionsColumn.ReadOnly = True
        Me.MauSoHoaDon.ParentControl = ""
        Me.MauSoHoaDon.RefreshSource = False
        Me.MauSoHoaDon.Required = False
        Me.MauSoHoaDon.SequenceName = ""
        Me.MauSoHoaDon.ShowCalc = True
        Me.MauSoHoaDon.ShowDataTime = False
        Me.MauSoHoaDon.ShowOnlyTime = False
        Me.MauSoHoaDon.SQLString = ""
        Me.MauSoHoaDon.UpdateIfNull = ""
        Me.MauSoHoaDon.UpdateWhenFormLock = False
        Me.MauSoHoaDon.UpperValue = False
        Me.MauSoHoaDon.ValidateValue = True
        Me.MauSoHoaDon.Visible = True
        Me.MauSoHoaDon.VisibleIndex = 9
        Me.MauSoHoaDon.Width = 130
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.DefaultUpdate = True
        Me.SimpleButton7.EnableWhenFormLock = True
        Me.SimpleButton7.Location = New System.Drawing.Point(794, 30)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(99, 29)
        Me.SimpleButton7.TabIndex = 204
        Me.SimpleButton7.Text = "Tìm &kiếm"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(337, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 19)
        Me.Label1.TabIndex = 493
        Me.Label1.Text = "Kho"
        '
        'Client
        '
        Me.Client.AllowInsert = True
        Me.Client.AllowUpdate = True
        Me.Client.AutoWidth = False
        Me.Client.BindingSourceName = ""
        Me.Client.ChangeFormStatus = False
        Me.Client.CopyFromItem = ""
        Me.Client.DefaultButtonClick = True
        Me.Client.DefaultValue = ""
        Me.Client.FieldName = ""
        Me.Client.FieldType = "C"
        Me.Client.FormList = True
        Me.Client.ItemReturn1 = ""
        Me.Client.ItemReturn2 = ""
        Me.Client.ItemReturn3 = ""
        Me.Client.KeyInsert = ""
        Me.Client.LinkLabel = ""
        Me.Client.Location = New System.Drawing.Point(384, 30)
        Me.Client.MultiSelect = False
        Me.Client.Name = "Client"
        Me.Client.NoUpdate = "N"
        Me.Client.OrderbyEx = ""
        Me.Client.PrimaryKey = ""
        Me.Client.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.Appearance.Options.UseFont = True
        Me.Client.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceDisabled.Options.UseFont = True
        Me.Client.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceFocused.Options.UseFont = True
        Me.Client.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Client.Required = ""
        Me.Client.ShowLoad = True
        Me.Client.Size = New System.Drawing.Size(124, 26)
        Me.Client.SqlFielKey = "Client"
        Me.Client.SqlString = ""
        Me.Client.TabIndex = 2
        Me.Client.TableName = ""
        Me.Client.UpdateIfNull = ""
        Me.Client.UpdateWhenFormLock = False
        Me.Client.UpperValue = False
        Me.Client.ValidateValue = False
        Me.Client.ViewName = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(86, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 19)
        Me.Label2.TabIndex = 492
        Me.Label2.Text = "Từ ngày"
        '
        'CreateDate
        '
        Me.CreateDate.AllowInsert = True
        Me.CreateDate.AllowUpdate = True
        Me.CreateDate.BindingSourceName = ""
        Me.CreateDate.ChangeFormStatus = False
        Me.CreateDate.CopyFromItem = ""
        Me.CreateDate.DefaultValue = ""
        Me.CreateDate.EditValue = Nothing
        Me.CreateDate.FieldName = ""
        Me.CreateDate.FieldType = "D"
        Me.CreateDate.KeyInsert = ""
        Me.CreateDate.LinkLabel = "Label2"
        Me.CreateDate.Location = New System.Drawing.Point(166, 62)
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.NoUpdate = ""
        Me.CreateDate.PrimaryKey = ""
        Me.CreateDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CreateDate.Properties.Appearance.Options.UseFont = True
        Me.CreateDate.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CreateDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.CreateDate.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CreateDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.CreateDate.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CreateDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.CreateDate.Properties.AutoHeight = False
        Me.CreateDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CreateDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.CreateDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CreateDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.CreateDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.CreateDate.Required = "Y"
        Me.CreateDate.ShowDateTime = False
        Me.CreateDate.Size = New System.Drawing.Size(120, 26)
        Me.CreateDate.TabIndex = 3
        Me.CreateDate.TableName = ""
        Me.CreateDate.TabStop = False
        Me.CreateDate.UpdateIfNull = ""
        Me.CreateDate.UpdateWhenFormLock = False
        Me.CreateDate.ViewName = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(297, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 19)
        Me.Label3.TabIndex = 497
        Me.Label3.Text = "Đến ngày"
        '
        'ToCreateDate
        '
        Me.ToCreateDate.AllowInsert = True
        Me.ToCreateDate.AllowUpdate = True
        Me.ToCreateDate.BindingSourceName = ""
        Me.ToCreateDate.ChangeFormStatus = False
        Me.ToCreateDate.CopyFromItem = ""
        Me.ToCreateDate.DefaultValue = ""
        Me.ToCreateDate.EditValue = Nothing
        Me.ToCreateDate.FieldName = ""
        Me.ToCreateDate.FieldType = "D"
        Me.ToCreateDate.KeyInsert = ""
        Me.ToCreateDate.LinkLabel = "Label2"
        Me.ToCreateDate.Location = New System.Drawing.Point(384, 62)
        Me.ToCreateDate.Name = "ToCreateDate"
        Me.ToCreateDate.NoUpdate = ""
        Me.ToCreateDate.PrimaryKey = ""
        Me.ToCreateDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToCreateDate.Properties.Appearance.Options.UseFont = True
        Me.ToCreateDate.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToCreateDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ToCreateDate.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToCreateDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.ToCreateDate.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToCreateDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.ToCreateDate.Properties.AutoHeight = False
        Me.ToCreateDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ToCreateDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.ToCreateDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ToCreateDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.ToCreateDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ToCreateDate.Required = "Y"
        Me.ToCreateDate.ShowDateTime = False
        Me.ToCreateDate.Size = New System.Drawing.Size(124, 26)
        Me.ToCreateDate.TabIndex = 4
        Me.ToCreateDate.TableName = ""
        Me.ToCreateDate.TabStop = False
        Me.ToCreateDate.UpdateIfNull = ""
        Me.ToCreateDate.UpdateWhenFormLock = False
        Me.ToCreateDate.ViewName = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(92, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 19)
        Me.Label4.TabIndex = 502
        Me.Label4.Text = "Số lệnh"
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
        Me.txtSoLenh.Location = New System.Drawing.Point(166, 31)
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
        Me.txtSoLenh.Size = New System.Drawing.Size(120, 26)
        Me.txtSoLenh.TabIndex = 501
        Me.txtSoLenh.TableName = ""
        Me.txtSoLenh.UpdateIfNull = ""
        Me.txtSoLenh.UpdateWhenFormLock = True
        Me.txtSoLenh.UpperValue = False
        Me.txtSoLenh.ViewName = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(551, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 19)
        Me.Label6.TabIndex = 504
        Me.Label6.Text = "Loại"
        '
        'sType
        '
        Me.sType.AllowInsert = True
        Me.sType.AllowUpdate = True
        Me.sType.BindingSourceName = ""
        Me.sType.ChangeFormStatus = False
        Me.sType.CopyFromItem = ""
        Me.sType.DefaultValue = ""
        Me.sType.DisplayField = "Name"
        Me.sType.DropDownRow = 10
        Me.sType.FieldName = ""
        Me.sType.FieldType = "C"
        Me.sType.ItemValue = ""
        Me.sType.KeyInsert = ""
        Me.sType.LinkLabel = ""
        Me.sType.Location = New System.Drawing.Point(600, 30)
        Me.sType.Name = "sType"
        Me.sType.NoUpdate = ""
        Me.sType.PrimaryKey = ""
        Me.sType.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.sType.Properties.Appearance.Options.UseFont = True
        Me.sType.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.sType.Properties.AppearanceDisabled.Options.UseFont = True
        Me.sType.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.sType.Properties.AppearanceFocused.Options.UseFont = True
        Me.sType.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.sType.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.sType.Properties.AutoHeight = False
        Me.sType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sType.Properties.NullText = ""
        Me.sType.Properties.ShowHeader = False
        Me.sType.Required = ""
        Me.sType.ShowHeader = False
        Me.sType.Size = New System.Drawing.Size(172, 26)
        Me.sType.SQL_String = "select 'Y' as Code , N'Lệnh tạo trên HTTG' as Name Union select 'N' as Code , N'L" & _
            "ệnh đồng bộ SAP' as Name"
        Me.sType.TabIndex = 503
        Me.sType.TableName = ""
        Me.sType.UpdateIfNull = ""
        Me.sType.UpdateWhenFormLock = False
        Me.sType.ValueField = "Code"
        Me.sType.ViewName = ""
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1068, 28)
        Me.ToolStrip1.TabIndex = 505
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(131, 25)
        Me.ToolStripButton4.Text = "&3. Đưa lên SAP"
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
        Me.U_CheckBox1.Location = New System.Drawing.Point(30, 68)
        Me.U_CheckBox1.Name = "U_CheckBox1"
        Me.U_CheckBox1.NoUpdate = ""
        Me.U_CheckBox1.PrimaryKey = ""
        Me.U_CheckBox1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_CheckBox1.Properties.AutoHeight = False
        Me.U_CheckBox1.Properties.Caption = ""
        Me.U_CheckBox1.Required = ""
        Me.U_CheckBox1.Size = New System.Drawing.Size(20, 23)
        Me.U_CheckBox1.TabIndex = 506
        Me.U_CheckBox1.TableName = ""
        Me.U_CheckBox1.UnCheckValue = "N"
        Me.U_CheckBox1.UpdateIfNull = ""
        Me.U_CheckBox1.UpdateWhenFormLock = False
        Me.U_CheckBox1.ViewName = ""
        '
        'FrmHTTGToSAP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 490)
        Me.Controls.Add(Me.U_CheckBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.sType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSoLenh)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ToCreateDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Client)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CreateDate)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmHTTGToSAP"
        Me.Text = "Thông tin Lệnh xuất đưa lên SAP"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton7, 0)
        Me.Controls.SetChildIndex(Me.CreateDate, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Client, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.ToCreateDate, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtSoLenh, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.sType, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.U_CheckBox1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreateDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreateDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToCreateDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToCreateDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSoLenh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.U_CheckBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents SimpleButton7 As U_TextBox.U_ButtonCus
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Client As U_TextBox.U_ButtonEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CreateDate As U_TextBox.U_DateEdit
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents NgayXuat As U_TextBox.GridColumn
    Friend WithEvents MaPhuongTien As U_TextBox.GridColumn
    Friend WithEvents NguoiVanChuyen As U_TextBox.GridColumn
    Friend WithEvents MaTuyenDuong As U_TextBox.GridColumn
    Friend WithEvents LoaiPhieu As U_TextBox.GridColumn
    Friend WithEvents SoLenh As U_TextBox.GridColumn
    Friend WithEvents MaTraCuu As U_TextBox.GridColumn
    Friend WithEvents DiemTraHang As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToCreateDate As U_TextBox.U_DateEdit
    Friend WithEvents MauSoHoaDon As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents X As U_TextBox.GridColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSoLenh As U_TextBox.U_TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents sType As U_TextBox.U_Combobox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents U_CheckBox1 As U_TextBox.U_CheckBox
End Class
