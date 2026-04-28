<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVehicleAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVehicleAdd))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ColMaPhuongTien = New U_TextBox.GridColumn()
        Me.ColMaNgan = New U_TextBox.GridColumn()
        Me.SoLuongMax = New U_TextBox.GridColumn()
        Me.LTT_CM = New U_TextBox.GridColumn()
        Me.NHAP_MM = New U_TextBox.GridColumn()
        Me.DUONGSINH = New U_TextBox.GridColumn()
        Me.ColStatus = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.ID = New U_TextBox.GridColumn()
        Me.MaPhuongTien = New U_TextBox.U_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SoNgan = New U_TextBox.U_NumericEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TuType = New U_TextBox.U_Combobox()
        Me.NgayBatDau1 = New U_TextBox.U_DateEdit()
        Me.NgayHieuLuc1 = New U_TextBox.U_DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NgayBatDau = New U_TextBox.U_TextBox()
        Me.NgayHieuLuc = New U_TextBox.U_TextBox()
        Me.BtnOk = New U_TextBox.U_ButtonCus()
        Me.Navigator1 = New U_TextBox.Navigator()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.U_NumericEdit1 = New U_TextBox.U_NumericEdit()
        Me.cmdSave = New U_TextBox.U_ButtonCus()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NhaCungCap = New U_TextBox.U_ButtonEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.REG_NO = New U_TextBox.U_TextBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaPhuongTien.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoNgan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TuType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayBatDau1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayBatDau1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayHieuLuc1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayHieuLuc1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayBatDau.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayHieuLuc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_NumericEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.NhaCungCap.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REG_NO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(360, 40)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(629, 333)
        Me.TrueDBGrid1.TabIndex = 5
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = "ID"
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColMaPhuongTien, Me.ColMaNgan, Me.SoLuongMax, Me.LTT_CM, Me.NHAP_MM, Me.DUONGSINH, Me.ColStatus, Me.CHECKUPD, Me.ID})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "MaNgan"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblChiTietPhuongTien"
        Me.GridView1.ViewName = "FPT_tblChiTietPhuongTien_V1"
        Me.GridView1.Where = "MaPhuongTien=:MaPhuongTien"
        '
        'ColMaPhuongTien
        '
        Me.ColMaPhuongTien.AllowInsert = True
        Me.ColMaPhuongTien.AllowUpdate = True
        Me.ColMaPhuongTien.ButtonClick = True
        Me.ColMaPhuongTien.Caption = "MaPhuongTien"
        Me.ColMaPhuongTien.CFLColumnHide = ""
        Me.ColMaPhuongTien.CFLKeyField = ""
        Me.ColMaPhuongTien.CFLPage = False
        Me.ColMaPhuongTien.CFLReturn0 = ""
        Me.ColMaPhuongTien.CFLReturn1 = ""
        Me.ColMaPhuongTien.CFLReturn2 = ""
        Me.ColMaPhuongTien.CFLReturn3 = ""
        Me.ColMaPhuongTien.CFLReturn4 = ""
        Me.ColMaPhuongTien.CFLReturn5 = ""
        Me.ColMaPhuongTien.CFLReturn6 = ""
        Me.ColMaPhuongTien.CFLReturn7 = ""
        Me.ColMaPhuongTien.CFLShowLoad = False
        Me.ColMaPhuongTien.ChangeFormStatus = True
        Me.ColMaPhuongTien.ColumnKey = False
        Me.ColMaPhuongTien.ComboLine = 5
        Me.ColMaPhuongTien.CopyFromItem = ":MaPhuongTien"
        Me.ColMaPhuongTien.DefaultButtonClick = False
        Me.ColMaPhuongTien.Digit = False
        Me.ColMaPhuongTien.FieldType = "C"
        Me.ColMaPhuongTien.FieldView = "MaPhuongTien"
        Me.ColMaPhuongTien.FormarNumber = True
        Me.ColMaPhuongTien.FormList = False
        Me.ColMaPhuongTien.KeyInsert = ""
        Me.ColMaPhuongTien.LocalDecimal = False
        Me.ColMaPhuongTien.Name = "ColMaPhuongTien"
        Me.ColMaPhuongTien.NoUpdate = ""
        Me.ColMaPhuongTien.NumberDecimal = 0
        Me.ColMaPhuongTien.ParentControl = ""
        Me.ColMaPhuongTien.RefreshSource = False
        Me.ColMaPhuongTien.Required = False
        Me.ColMaPhuongTien.SequenceName = ""
        Me.ColMaPhuongTien.ShowCalc = True
        Me.ColMaPhuongTien.ShowDataTime = False
        Me.ColMaPhuongTien.ShowOnlyTime = False
        Me.ColMaPhuongTien.SQLString = ""
        Me.ColMaPhuongTien.UpdateIfNull = ""
        Me.ColMaPhuongTien.UpdateWhenFormLock = False
        Me.ColMaPhuongTien.UpperValue = False
        Me.ColMaPhuongTien.ValidateValue = True
        Me.ColMaPhuongTien.Visible = True
        '
        'ColMaNgan
        '
        Me.ColMaNgan.AllowInsert = True
        Me.ColMaNgan.AllowUpdate = True
        Me.ColMaNgan.ButtonClick = True
        Me.ColMaNgan.Caption = "Mã ngăn"
        Me.ColMaNgan.CFLColumnHide = ""
        Me.ColMaNgan.CFLKeyField = ""
        Me.ColMaNgan.CFLPage = False
        Me.ColMaNgan.CFLReturn0 = ""
        Me.ColMaNgan.CFLReturn1 = ""
        Me.ColMaNgan.CFLReturn2 = ""
        Me.ColMaNgan.CFLReturn3 = ""
        Me.ColMaNgan.CFLReturn4 = ""
        Me.ColMaNgan.CFLReturn5 = ""
        Me.ColMaNgan.CFLReturn6 = ""
        Me.ColMaNgan.CFLReturn7 = ""
        Me.ColMaNgan.CFLShowLoad = False
        Me.ColMaNgan.ChangeFormStatus = True
        Me.ColMaNgan.ColumnKey = False
        Me.ColMaNgan.ComboLine = 5
        Me.ColMaNgan.CopyFromItem = ""
        Me.ColMaNgan.DefaultButtonClick = False
        Me.ColMaNgan.Digit = False
        Me.ColMaNgan.FieldType = "C"
        Me.ColMaNgan.FieldView = "MaNgan"
        Me.ColMaNgan.FormarNumber = True
        Me.ColMaNgan.FormList = False
        Me.ColMaNgan.KeyInsert = ""
        Me.ColMaNgan.LocalDecimal = False
        Me.ColMaNgan.Name = "ColMaNgan"
        Me.ColMaNgan.NoUpdate = ""
        Me.ColMaNgan.NumberDecimal = 0
        Me.ColMaNgan.OptionsColumn.AllowEdit = False
        Me.ColMaNgan.ParentControl = ""
        Me.ColMaNgan.RefreshSource = False
        Me.ColMaNgan.Required = True
        Me.ColMaNgan.SequenceName = ""
        Me.ColMaNgan.ShowCalc = True
        Me.ColMaNgan.ShowDataTime = False
        Me.ColMaNgan.ShowOnlyTime = False
        Me.ColMaNgan.SQLString = ""
        Me.ColMaNgan.UpdateIfNull = ""
        Me.ColMaNgan.UpdateWhenFormLock = False
        Me.ColMaNgan.UpperValue = False
        Me.ColMaNgan.ValidateValue = True
        Me.ColMaNgan.Visible = True
        Me.ColMaNgan.VisibleIndex = 0
        Me.ColMaNgan.Width = 80
        '
        'SoLuongMax
        '
        Me.SoLuongMax.AllowInsert = True
        Me.SoLuongMax.AllowUpdate = True
        Me.SoLuongMax.ButtonClick = True
        Me.SoLuongMax.Caption = "SL tối đa"
        Me.SoLuongMax.CFLColumnHide = ""
        Me.SoLuongMax.CFLKeyField = ""
        Me.SoLuongMax.CFLPage = False
        Me.SoLuongMax.CFLReturn0 = ""
        Me.SoLuongMax.CFLReturn1 = ""
        Me.SoLuongMax.CFLReturn2 = ""
        Me.SoLuongMax.CFLReturn3 = ""
        Me.SoLuongMax.CFLReturn4 = ""
        Me.SoLuongMax.CFLReturn5 = ""
        Me.SoLuongMax.CFLReturn6 = ""
        Me.SoLuongMax.CFLReturn7 = ""
        Me.SoLuongMax.CFLShowLoad = False
        Me.SoLuongMax.ChangeFormStatus = True
        Me.SoLuongMax.ColumnKey = False
        Me.SoLuongMax.ComboLine = 5
        Me.SoLuongMax.CopyFromItem = ""
        Me.SoLuongMax.DefaultButtonClick = False
        Me.SoLuongMax.Digit = False
        Me.SoLuongMax.FieldType = "N"
        Me.SoLuongMax.FieldView = "SoLuongMax"
        Me.SoLuongMax.FormarNumber = True
        Me.SoLuongMax.FormList = False
        Me.SoLuongMax.KeyInsert = ""
        Me.SoLuongMax.LocalDecimal = False
        Me.SoLuongMax.Name = "SoLuongMax"
        Me.SoLuongMax.NoUpdate = ""
        Me.SoLuongMax.NumberDecimal = 0
        Me.SoLuongMax.ParentControl = ""
        Me.SoLuongMax.RefreshSource = False
        Me.SoLuongMax.Required = True
        Me.SoLuongMax.SequenceName = ""
        Me.SoLuongMax.ShowCalc = True
        Me.SoLuongMax.ShowDataTime = False
        Me.SoLuongMax.ShowOnlyTime = False
        Me.SoLuongMax.SQLString = ""
        Me.SoLuongMax.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoLuongMax", "")})
        Me.SoLuongMax.UpdateIfNull = ""
        Me.SoLuongMax.UpdateWhenFormLock = False
        Me.SoLuongMax.UpperValue = False
        Me.SoLuongMax.ValidateValue = True
        Me.SoLuongMax.Visible = True
        Me.SoLuongMax.VisibleIndex = 1
        Me.SoLuongMax.Width = 90
        '
        'LTT_CM
        '
        Me.LTT_CM.AllowInsert = True
        Me.LTT_CM.AllowUpdate = True
        Me.LTT_CM.ButtonClick = True
        Me.LTT_CM.Caption = "Barem cổ xitec"
        Me.LTT_CM.CFLColumnHide = ""
        Me.LTT_CM.CFLKeyField = ""
        Me.LTT_CM.CFLPage = False
        Me.LTT_CM.CFLReturn0 = ""
        Me.LTT_CM.CFLReturn1 = ""
        Me.LTT_CM.CFLReturn2 = ""
        Me.LTT_CM.CFLReturn3 = ""
        Me.LTT_CM.CFLReturn4 = ""
        Me.LTT_CM.CFLReturn5 = ""
        Me.LTT_CM.CFLReturn6 = ""
        Me.LTT_CM.CFLReturn7 = ""
        Me.LTT_CM.CFLShowLoad = False
        Me.LTT_CM.ChangeFormStatus = True
        Me.LTT_CM.ColumnKey = False
        Me.LTT_CM.ComboLine = 5
        Me.LTT_CM.CopyFromItem = ""
        Me.LTT_CM.DefaultButtonClick = False
        Me.LTT_CM.Digit = False
        Me.LTT_CM.FieldType = "N"
        Me.LTT_CM.FieldView = "LTT_CM"
        Me.LTT_CM.FormarNumber = False
        Me.LTT_CM.FormList = False
        Me.LTT_CM.KeyInsert = ""
        Me.LTT_CM.LocalDecimal = True
        Me.LTT_CM.Name = "LTT_CM"
        Me.LTT_CM.NoUpdate = ""
        Me.LTT_CM.NumberDecimal = 2
        Me.LTT_CM.ParentControl = ""
        Me.LTT_CM.RefreshSource = False
        Me.LTT_CM.Required = False
        Me.LTT_CM.SequenceName = ""
        Me.LTT_CM.ShowCalc = True
        Me.LTT_CM.ShowDataTime = False
        Me.LTT_CM.ShowOnlyTime = False
        Me.LTT_CM.SQLString = ""
        Me.LTT_CM.UpdateIfNull = ""
        Me.LTT_CM.UpdateWhenFormLock = False
        Me.LTT_CM.UpperValue = False
        Me.LTT_CM.ValidateValue = True
        Me.LTT_CM.Visible = True
        Me.LTT_CM.VisibleIndex = 2
        Me.LTT_CM.Width = 90
        '
        'NHAP_MM
        '
        Me.NHAP_MM.AllowInsert = True
        Me.NHAP_MM.AllowUpdate = True
        Me.NHAP_MM.ButtonClick = True
        Me.NHAP_MM.Caption = "K/C từ lỗ nhập-T.mức (mm)"
        Me.NHAP_MM.CFLColumnHide = ""
        Me.NHAP_MM.CFLKeyField = ""
        Me.NHAP_MM.CFLPage = False
        Me.NHAP_MM.CFLReturn0 = ""
        Me.NHAP_MM.CFLReturn1 = ""
        Me.NHAP_MM.CFLReturn2 = ""
        Me.NHAP_MM.CFLReturn3 = ""
        Me.NHAP_MM.CFLReturn4 = ""
        Me.NHAP_MM.CFLReturn5 = ""
        Me.NHAP_MM.CFLReturn6 = ""
        Me.NHAP_MM.CFLReturn7 = ""
        Me.NHAP_MM.CFLShowLoad = False
        Me.NHAP_MM.ChangeFormStatus = True
        Me.NHAP_MM.ColumnKey = False
        Me.NHAP_MM.ComboLine = 5
        Me.NHAP_MM.CopyFromItem = ""
        Me.NHAP_MM.DefaultButtonClick = False
        Me.NHAP_MM.Digit = False
        Me.NHAP_MM.FieldType = "N"
        Me.NHAP_MM.FieldView = "NHAP_MM"
        Me.NHAP_MM.FormarNumber = True
        Me.NHAP_MM.FormList = False
        Me.NHAP_MM.KeyInsert = ""
        Me.NHAP_MM.LocalDecimal = False
        Me.NHAP_MM.Name = "NHAP_MM"
        Me.NHAP_MM.NoUpdate = ""
        Me.NHAP_MM.NumberDecimal = 0
        Me.NHAP_MM.ParentControl = ""
        Me.NHAP_MM.RefreshSource = False
        Me.NHAP_MM.Required = False
        Me.NHAP_MM.SequenceName = ""
        Me.NHAP_MM.ShowCalc = True
        Me.NHAP_MM.ShowDataTime = False
        Me.NHAP_MM.ShowOnlyTime = False
        Me.NHAP_MM.SQLString = ""
        Me.NHAP_MM.UpdateIfNull = ""
        Me.NHAP_MM.UpdateWhenFormLock = False
        Me.NHAP_MM.UpperValue = False
        Me.NHAP_MM.ValidateValue = True
        Me.NHAP_MM.Visible = True
        Me.NHAP_MM.VisibleIndex = 3
        Me.NHAP_MM.Width = 127
        '
        'DUONGSINH
        '
        Me.DUONGSINH.AllowInsert = True
        Me.DUONGSINH.AllowUpdate = True
        Me.DUONGSINH.ButtonClick = True
        Me.DUONGSINH.Caption = "K/C từ lỗ nhập-Đ. sinh thấp nhất (mm)"
        Me.DUONGSINH.CFLColumnHide = ""
        Me.DUONGSINH.CFLKeyField = ""
        Me.DUONGSINH.CFLPage = False
        Me.DUONGSINH.CFLReturn0 = ""
        Me.DUONGSINH.CFLReturn1 = ""
        Me.DUONGSINH.CFLReturn2 = ""
        Me.DUONGSINH.CFLReturn3 = ""
        Me.DUONGSINH.CFLReturn4 = ""
        Me.DUONGSINH.CFLReturn5 = ""
        Me.DUONGSINH.CFLReturn6 = ""
        Me.DUONGSINH.CFLReturn7 = ""
        Me.DUONGSINH.CFLShowLoad = False
        Me.DUONGSINH.ChangeFormStatus = True
        Me.DUONGSINH.ColumnKey = False
        Me.DUONGSINH.ComboLine = 5
        Me.DUONGSINH.CopyFromItem = ""
        Me.DUONGSINH.DefaultButtonClick = False
        Me.DUONGSINH.Digit = False
        Me.DUONGSINH.FieldType = "N"
        Me.DUONGSINH.FieldView = "DUONGSINH"
        Me.DUONGSINH.FormarNumber = True
        Me.DUONGSINH.FormList = False
        Me.DUONGSINH.KeyInsert = ""
        Me.DUONGSINH.LocalDecimal = False
        Me.DUONGSINH.Name = "DUONGSINH"
        Me.DUONGSINH.NoUpdate = ""
        Me.DUONGSINH.NumberDecimal = 0
        Me.DUONGSINH.ParentControl = ""
        Me.DUONGSINH.RefreshSource = False
        Me.DUONGSINH.Required = False
        Me.DUONGSINH.SequenceName = ""
        Me.DUONGSINH.ShowCalc = True
        Me.DUONGSINH.ShowDataTime = False
        Me.DUONGSINH.ShowOnlyTime = False
        Me.DUONGSINH.SQLString = ""
        Me.DUONGSINH.UpdateIfNull = ""
        Me.DUONGSINH.UpdateWhenFormLock = False
        Me.DUONGSINH.UpperValue = False
        Me.DUONGSINH.ValidateValue = True
        Me.DUONGSINH.Visible = True
        Me.DUONGSINH.VisibleIndex = 4
        Me.DUONGSINH.Width = 132
        '
        'ColStatus
        '
        Me.ColStatus.AllowInsert = True
        Me.ColStatus.AllowUpdate = True
        Me.ColStatus.ButtonClick = True
        Me.ColStatus.Caption = "Status"
        Me.ColStatus.CFLColumnHide = ""
        Me.ColStatus.CFLKeyField = ""
        Me.ColStatus.CFLPage = False
        Me.ColStatus.CFLReturn0 = ""
        Me.ColStatus.CFLReturn1 = ""
        Me.ColStatus.CFLReturn2 = ""
        Me.ColStatus.CFLReturn3 = ""
        Me.ColStatus.CFLReturn4 = ""
        Me.ColStatus.CFLReturn5 = ""
        Me.ColStatus.CFLReturn6 = ""
        Me.ColStatus.CFLReturn7 = ""
        Me.ColStatus.CFLShowLoad = False
        Me.ColStatus.ChangeFormStatus = True
        Me.ColStatus.ColumnKey = False
        Me.ColStatus.ComboLine = 5
        Me.ColStatus.CopyFromItem = ""
        Me.ColStatus.DefaultButtonClick = False
        Me.ColStatus.Digit = False
        Me.ColStatus.FieldType = "C"
        Me.ColStatus.FieldView = "Status"
        Me.ColStatus.FormarNumber = True
        Me.ColStatus.FormList = False
        Me.ColStatus.KeyInsert = ""
        Me.ColStatus.LocalDecimal = False
        Me.ColStatus.Name = "ColStatus"
        Me.ColStatus.NoUpdate = ""
        Me.ColStatus.NumberDecimal = 0
        Me.ColStatus.ParentControl = ""
        Me.ColStatus.RefreshSource = False
        Me.ColStatus.Required = False
        Me.ColStatus.SequenceName = ""
        Me.ColStatus.ShowCalc = True
        Me.ColStatus.ShowDataTime = False
        Me.ColStatus.ShowOnlyTime = False
        Me.ColStatus.SQLString = ""
        Me.ColStatus.UpdateIfNull = ""
        Me.ColStatus.UpdateWhenFormLock = False
        Me.ColStatus.UpperValue = False
        Me.ColStatus.ValidateValue = True
        Me.ColStatus.Visible = True
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
        'ID
        '
        Me.ID.AllowInsert = False
        Me.ID.AllowUpdate = False
        Me.ID.ButtonClick = True
        Me.ID.Caption = "GridColumn1"
        Me.ID.CFLColumnHide = ""
        Me.ID.CFLKeyField = ""
        Me.ID.CFLPage = False
        Me.ID.CFLReturn0 = ""
        Me.ID.CFLReturn1 = ""
        Me.ID.CFLReturn2 = ""
        Me.ID.CFLReturn3 = ""
        Me.ID.CFLReturn4 = ""
        Me.ID.CFLReturn5 = ""
        Me.ID.CFLReturn6 = ""
        Me.ID.CFLReturn7 = ""
        Me.ID.CFLShowLoad = False
        Me.ID.ChangeFormStatus = True
        Me.ID.ColumnKey = True
        Me.ID.ComboLine = 5
        Me.ID.CopyFromItem = ""
        Me.ID.DefaultButtonClick = False
        Me.ID.Digit = False
        Me.ID.FieldType = "N"
        Me.ID.FieldView = "ID"
        Me.ID.FormarNumber = True
        Me.ID.FormList = False
        Me.ID.KeyInsert = ""
        Me.ID.LocalDecimal = False
        Me.ID.Name = "ID"
        Me.ID.NoUpdate = ""
        Me.ID.NumberDecimal = 0
        Me.ID.OptionsColumn.ReadOnly = True
        Me.ID.ParentControl = ""
        Me.ID.RefreshSource = False
        Me.ID.Required = False
        Me.ID.SequenceName = ""
        Me.ID.ShowCalc = True
        Me.ID.ShowDataTime = False
        Me.ID.ShowOnlyTime = False
        Me.ID.SQLString = ""
        Me.ID.UpdateIfNull = ""
        Me.ID.UpdateWhenFormLock = False
        Me.ID.UpperValue = False
        Me.ID.ValidateValue = True
        Me.ID.Visible = True
        '
        'MaPhuongTien
        '
        Me.MaPhuongTien.AllowInsert = True
        Me.MaPhuongTien.AllowUpdate = True
        Me.MaPhuongTien.AutoKeyFix = ""
        Me.MaPhuongTien.AutoKeyName = ""
        Me.MaPhuongTien.BindingSourceName = ""
        Me.MaPhuongTien.ChangeFormStatus = True
        Me.MaPhuongTien.CopyFromItem = ""
        Me.MaPhuongTien.DefaultValue = ""
        Me.MaPhuongTien.FieldName = "MaPhuongTien"
        Me.MaPhuongTien.FieldType = "C"
        Me.MaPhuongTien.KeyInsert = "Y"
        Me.MaPhuongTien.LinkLabel = ""
        Me.MaPhuongTien.Location = New System.Drawing.Point(156, 40)
        Me.MaPhuongTien.Name = "MaPhuongTien"
        Me.MaPhuongTien.NoUpdate = "N"
        Me.MaPhuongTien.PrimaryKey = "Y"
        Me.MaPhuongTien.Properties.AutoHeight = False
        Me.MaPhuongTien.Required = "Y"
        Me.MaPhuongTien.Size = New System.Drawing.Size(152, 26)
        Me.MaPhuongTien.TabIndex = 0
        Me.MaPhuongTien.TableName = "tblPhuongTien"
        Me.MaPhuongTien.UpdateIfNull = "Y"
        Me.MaPhuongTien.UpdateWhenFormLock = False
        Me.MaPhuongTien.UpperValue = False
        Me.MaPhuongTien.ViewName = "FPT_tblPhuongTien_V1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 19)
        Me.Label1.TabIndex = 421
        Me.Label1.Text = "Tên phương tiện"
        '
        'SoNgan
        '
        Me.SoNgan.AllowInsert = True
        Me.SoNgan.AllowUpdate = True
        Me.SoNgan.AutoKeyFix = ""
        Me.SoNgan.AutoKeyName = ""
        Me.SoNgan.BindingSourceName = ""
        Me.SoNgan.ChangeFormStatus = True
        Me.SoNgan.CopyFromItem = ""
        Me.SoNgan.DefaultValue = ""
        Me.SoNgan.Digit = True
        Me.SoNgan.FieldName = "SoNgan"
        Me.SoNgan.FieldType = "N"
        Me.SoNgan.KeyInsert = ""
        Me.SoNgan.LinkLabel = ""
        Me.SoNgan.LocalDecimal = False
        Me.SoNgan.Location = New System.Drawing.Point(156, 67)
        Me.SoNgan.Name = "SoNgan"
        Me.SoNgan.NoUpdate = ""
        Me.SoNgan.NumberDecimal = 0
        Me.SoNgan.PrimaryKey = ""
        Me.SoNgan.Properties.AutoHeight = False
        Me.SoNgan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SoNgan.Required = "Y"
        Me.SoNgan.ShowCalc = True
        Me.SoNgan.Size = New System.Drawing.Size(78, 26)
        Me.SoNgan.TabIndex = 1
        Me.SoNgan.TableName = "tblPhuongTien"
        Me.SoNgan.UpdateIfNull = ""
        Me.SoNgan.UpdateWhenFormLock = False
        Me.SoNgan.ViewName = "FPT_tblPhuongTien_V1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 19)
        Me.Label2.TabIndex = 423
        Me.Label2.Text = "Số ngăn"
        '
        'TuType
        '
        Me.TuType.AllowInsert = True
        Me.TuType.AllowUpdate = True
        Me.TuType.BindingSourceName = ""
        Me.TuType.ChangeFormStatus = True
        Me.TuType.CopyFromItem = ""
        Me.TuType.DefaultValue = ""
        Me.TuType.DisplayField = "TuText"
        Me.TuType.DropDownRow = 13
        Me.TuType.FieldName = "LaiXe"
        Me.TuType.FieldType = "C"
        Me.TuType.ItemValue = ""
        Me.TuType.KeyInsert = ""
        Me.TuType.LinkLabel = ""
        Me.TuType.Location = New System.Drawing.Point(156, 94)
        Me.TuType.Name = "TuType"
        Me.TuType.NoUpdate = ""
        Me.TuType.PrimaryKey = ""
        Me.TuType.Properties.AutoHeight = False
        Me.TuType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TuType.Properties.NullText = ""
        Me.TuType.Properties.ShowHeader = False
        Me.TuType.Required = "Y"
        Me.TuType.ShowHeader = False
        Me.TuType.Size = New System.Drawing.Size(199, 26)
        Me.TuType.SQL_String = "select TuType, TuText  from dbo.tblTu"
        Me.TuType.TabIndex = 2
        Me.TuType.TableName = "tblPhuongTien"
        Me.TuType.UpdateIfNull = ""
        Me.TuType.UpdateWhenFormLock = False
        Me.TuType.ValueField = "TuType"
        Me.TuType.ViewName = "FPT_tblPhuongTien_V1"
        '
        'NgayBatDau1
        '
        Me.NgayBatDau1.AllowInsert = False
        Me.NgayBatDau1.AllowUpdate = False
        Me.NgayBatDau1.BindingSourceName = ""
        Me.NgayBatDau1.ChangeFormStatus = True
        Me.NgayBatDau1.CopyFromItem = ""
        Me.NgayBatDau1.DefaultValue = ""
        Me.NgayBatDau1.EditValue = Nothing
        Me.NgayBatDau1.FieldName = "NgayBatDau1"
        Me.NgayBatDau1.FieldType = "D"
        Me.NgayBatDau1.KeyInsert = ""
        Me.NgayBatDau1.LinkLabel = ""
        Me.NgayBatDau1.Location = New System.Drawing.Point(156, 150)
        Me.NgayBatDau1.Name = "NgayBatDau1"
        Me.NgayBatDau1.NoUpdate = ""
        Me.NgayBatDau1.PrimaryKey = ""
        Me.NgayBatDau1.Properties.AutoHeight = False
        Me.NgayBatDau1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayBatDau1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayBatDau1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.NgayBatDau1.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.NgayBatDau1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.NgayBatDau1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayBatDau1.Properties.Mask.ShowPlaceHolders = False
        Me.NgayBatDau1.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NgayBatDau1.Properties.NullValuePromptShowForEmptyValue = True
        Me.NgayBatDau1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayBatDau1.Properties.VistaTimeProperties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayBatDau1.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.NgayBatDau1.Properties.VistaTimeProperties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayBatDau1.Required = ""
        Me.NgayBatDau1.ShowDateTime = False
        Me.NgayBatDau1.Size = New System.Drawing.Size(152, 26)
        Me.NgayBatDau1.TabIndex = 4
        Me.NgayBatDau1.TableName = "tblPhuongTien"
        Me.NgayBatDau1.UpdateIfNull = ""
        Me.NgayBatDau1.UpdateWhenFormLock = False
        Me.NgayBatDau1.ViewName = "FPT_tblPhuongTien_V1"
        '
        'NgayHieuLuc1
        '
        Me.NgayHieuLuc1.AllowInsert = False
        Me.NgayHieuLuc1.AllowUpdate = False
        Me.NgayHieuLuc1.BindingSourceName = ""
        Me.NgayHieuLuc1.ChangeFormStatus = True
        Me.NgayHieuLuc1.CopyFromItem = ""
        Me.NgayHieuLuc1.DefaultValue = ""
        Me.NgayHieuLuc1.EditValue = Nothing
        Me.NgayHieuLuc1.FieldName = "NgayHieuLuc1"
        Me.NgayHieuLuc1.FieldType = "D"
        Me.NgayHieuLuc1.KeyInsert = ""
        Me.NgayHieuLuc1.LinkLabel = ""
        Me.NgayHieuLuc1.Location = New System.Drawing.Point(156, 177)
        Me.NgayHieuLuc1.Name = "NgayHieuLuc1"
        Me.NgayHieuLuc1.NoUpdate = ""
        Me.NgayHieuLuc1.PrimaryKey = ""
        Me.NgayHieuLuc1.Properties.AutoHeight = False
        Me.NgayHieuLuc1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayHieuLuc1.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayHieuLuc1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.NgayHieuLuc1.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.NgayHieuLuc1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.NgayHieuLuc1.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayHieuLuc1.Properties.Mask.ShowPlaceHolders = False
        Me.NgayHieuLuc1.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.NgayHieuLuc1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayHieuLuc1.Properties.VistaTimeProperties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayHieuLuc1.Properties.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.NgayHieuLuc1.Properties.VistaTimeProperties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayHieuLuc1.Required = ""
        Me.NgayHieuLuc1.ShowDateTime = False
        Me.NgayHieuLuc1.Size = New System.Drawing.Size(152, 26)
        Me.NgayHieuLuc1.TabIndex = 5
        Me.NgayHieuLuc1.TableName = "tblPhuongTien"
        Me.NgayHieuLuc1.UpdateIfNull = ""
        Me.NgayHieuLuc1.UpdateWhenFormLock = False
        Me.NgayHieuLuc1.ViewName = "FPT_tblPhuongTien_V1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 19)
        Me.Label3.TabIndex = 427
        Me.Label3.Text = "Loại phương tiện"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 19)
        Me.Label4.TabIndex = 428
        Me.Label4.Text = "Ngày hiệu lực"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 19)
        Me.Label5.TabIndex = 429
        Me.Label5.Text = "Ngày hết hiệu lực"
        '
        'NgayBatDau
        '
        Me.NgayBatDau.AllowInsert = True
        Me.NgayBatDau.AllowUpdate = True
        Me.NgayBatDau.AutoKeyFix = ""
        Me.NgayBatDau.AutoKeyName = ""
        Me.NgayBatDau.BindingSourceName = ""
        Me.NgayBatDau.ChangeFormStatus = True
        Me.NgayBatDau.CopyFromItem = ""
        Me.NgayBatDau.DefaultValue = ""
        Me.NgayBatDau.FieldName = "NgayBatDau"
        Me.NgayBatDau.FieldType = "C"
        Me.NgayBatDau.KeyInsert = ""
        Me.NgayBatDau.LinkLabel = ""
        Me.NgayBatDau.Location = New System.Drawing.Point(156, 150)
        Me.NgayBatDau.Name = "NgayBatDau"
        Me.NgayBatDau.NoUpdate = "N"
        Me.NgayBatDau.PrimaryKey = ""
        Me.NgayBatDau.Required = ""
        Me.NgayBatDau.Size = New System.Drawing.Size(0, 20)
        Me.NgayBatDau.TabIndex = 430
        Me.NgayBatDau.TableName = "tblPhuongTien"
        Me.NgayBatDau.TabStop = False
        Me.NgayBatDau.UpdateIfNull = ""
        Me.NgayBatDau.UpdateWhenFormLock = False
        Me.NgayBatDau.UpperValue = False
        Me.NgayBatDau.ViewName = "FPT_tblPhuongTien_V"
        '
        'NgayHieuLuc
        '
        Me.NgayHieuLuc.AllowInsert = True
        Me.NgayHieuLuc.AllowUpdate = True
        Me.NgayHieuLuc.AutoKeyFix = ""
        Me.NgayHieuLuc.AutoKeyName = ""
        Me.NgayHieuLuc.BindingSourceName = ""
        Me.NgayHieuLuc.ChangeFormStatus = True
        Me.NgayHieuLuc.CopyFromItem = ""
        Me.NgayHieuLuc.DefaultValue = ""
        Me.NgayHieuLuc.FieldName = "NgayHieuLuc"
        Me.NgayHieuLuc.FieldType = "C"
        Me.NgayHieuLuc.KeyInsert = ""
        Me.NgayHieuLuc.LinkLabel = ""
        Me.NgayHieuLuc.Location = New System.Drawing.Point(156, 177)
        Me.NgayHieuLuc.Name = "NgayHieuLuc"
        Me.NgayHieuLuc.NoUpdate = "N"
        Me.NgayHieuLuc.PrimaryKey = ""
        Me.NgayHieuLuc.Required = ""
        Me.NgayHieuLuc.Size = New System.Drawing.Size(0, 20)
        Me.NgayHieuLuc.TabIndex = 431
        Me.NgayHieuLuc.TableName = "tblPhuongTien"
        Me.NgayHieuLuc.TabStop = False
        Me.NgayHieuLuc.UpdateIfNull = ""
        Me.NgayHieuLuc.UpdateWhenFormLock = False
        Me.NgayHieuLuc.UpperValue = False
        Me.NgayHieuLuc.ViewName = "FPT_tblPhuongTien_V"
        '
        'BtnOk
        '
        Me.BtnOk.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.Appearance.Options.UseFont = True
        Me.BtnOk.DefaultUpdate = False
        Me.BtnOk.EnableWhenFormLock = False
        Me.BtnOk.Location = New System.Drawing.Point(2, 294)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(107, 27)
        Me.BtnOk.TabIndex = 432
        Me.BtnOk.Text = "Ok"
        Me.BtnOk.Visible = False
        '
        'Navigator1
        '
        Me.Navigator1.DefaultButton = True
        Me.Navigator1.Location = New System.Drawing.Point(407, 173)
        Me.Navigator1.Name = "Navigator1"
        Me.Navigator1.Size = New System.Drawing.Size(172, 24)
        Me.Navigator1.TabIndex = 433
        Me.Navigator1.Text = "Navigator1"
        Me.Navigator1.ViewName = "FPT_tblPhuongTien_V1"
        Me.Navigator1.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 207)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 19)
        Me.Label6.TabIndex = 436
        Me.Label6.Text = "Tải trọng xe"
        Me.Label6.Visible = False
        '
        'U_NumericEdit1
        '
        Me.U_NumericEdit1.AllowInsert = True
        Me.U_NumericEdit1.AllowUpdate = True
        Me.U_NumericEdit1.AutoKeyFix = ""
        Me.U_NumericEdit1.AutoKeyName = ""
        Me.U_NumericEdit1.BindingSourceName = ""
        Me.U_NumericEdit1.ChangeFormStatus = True
        Me.U_NumericEdit1.CopyFromItem = ""
        Me.U_NumericEdit1.DefaultValue = ""
        Me.U_NumericEdit1.Digit = True
        Me.U_NumericEdit1.FieldName = "iweight"
        Me.U_NumericEdit1.FieldType = "N"
        Me.U_NumericEdit1.KeyInsert = ""
        Me.U_NumericEdit1.LinkLabel = ""
        Me.U_NumericEdit1.LocalDecimal = True
        Me.U_NumericEdit1.Location = New System.Drawing.Point(156, 204)
        Me.U_NumericEdit1.Name = "U_NumericEdit1"
        Me.U_NumericEdit1.NoUpdate = ""
        Me.U_NumericEdit1.NumberDecimal = 0
        Me.U_NumericEdit1.PrimaryKey = ""
        Me.U_NumericEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_NumericEdit1.Properties.Appearance.Options.UseFont = True
        Me.U_NumericEdit1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_NumericEdit1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_NumericEdit1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_NumericEdit1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_NumericEdit1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_NumericEdit1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_NumericEdit1.Properties.AutoHeight = False
        Me.U_NumericEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.U_NumericEdit1.Required = ""
        Me.U_NumericEdit1.ShowCalc = True
        Me.U_NumericEdit1.Size = New System.Drawing.Size(152, 30)
        Me.U_NumericEdit1.TabIndex = 6
        Me.U_NumericEdit1.TableName = "tblPhuongTien"
        Me.U_NumericEdit1.UpdateIfNull = ""
        Me.U_NumericEdit1.UpdateWhenFormLock = False
        Me.U_NumericEdit1.ViewName = "FPT_tblPhuongTien_V1"
        Me.U_NumericEdit1.Visible = False
        '
        'cmdSave
        '
        Me.cmdSave.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Appearance.Options.UseFont = True
        Me.cmdSave.DefaultUpdate = False
        Me.cmdSave.EnableWhenFormLock = False
        Me.cmdSave.Location = New System.Drawing.Point(156, 282)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(91, 27)
        Me.cmdSave.TabIndex = 438
        Me.cmdSave.TabStop = False
        Me.cmdSave.Text = "Lưu"
        Me.cmdSave.Visible = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(990, 28)
        Me.ToolStrip2.TabIndex = 473
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(166, 25)
        Me.ToolStripButton1.Text = "&1. Nhập tải trong xe"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(224, 25)
        Me.ToolStripButton2.Text = "2. Bổ sung thông tin quản lý"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(163, 25)
        Me.ToolStripButton3.Text = "&3. Đồng bộ lên SAP"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(203, 25)
        Me.ToolStripButton4.Text = "&9. Lịch sử thay đổi Barem"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 241)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 19)
        Me.Label8.TabIndex = 475
        Me.Label8.Text = "Nhà cung cấp"
        Me.Label8.Visible = False
        '
        'NhaCungCap
        '
        Me.NhaCungCap.AllowInsert = False
        Me.NhaCungCap.AllowUpdate = False
        Me.NhaCungCap.AutoWidth = False
        Me.NhaCungCap.BindingSourceName = ""
        Me.NhaCungCap.ChangeFormStatus = True
        Me.NhaCungCap.CopyFromItem = ""
        Me.NhaCungCap.DefaultButtonClick = True
        Me.NhaCungCap.DefaultValue = ""
        Me.NhaCungCap.Enabled = False
        Me.NhaCungCap.FieldName = ""
        Me.NhaCungCap.FieldType = "C"
        Me.NhaCungCap.FormList = False
        Me.NhaCungCap.ItemReturn1 = ""
        Me.NhaCungCap.ItemReturn2 = ""
        Me.NhaCungCap.ItemReturn3 = ""
        Me.NhaCungCap.KeyInsert = ""
        Me.NhaCungCap.LinkLabel = "Label8"
        Me.NhaCungCap.Location = New System.Drawing.Point(156, 236)
        Me.NhaCungCap.MultiSelect = False
        Me.NhaCungCap.Name = "NhaCungCap"
        Me.NhaCungCap.NoUpdate = "N"
        Me.NhaCungCap.OrderbyEx = ""
        Me.NhaCungCap.PrimaryKey = ""
        Me.NhaCungCap.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NhaCungCap.Properties.Appearance.Options.UseFont = True
        Me.NhaCungCap.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NhaCungCap.Properties.AppearanceDisabled.Options.UseFont = True
        Me.NhaCungCap.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NhaCungCap.Properties.AppearanceFocused.Options.UseFont = True
        Me.NhaCungCap.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NhaCungCap.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.NhaCungCap.Properties.AutoHeight = False
        Me.NhaCungCap.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NhaCungCap.Required = ""
        Me.NhaCungCap.ShowLoad = True
        Me.NhaCungCap.Size = New System.Drawing.Size(152, 26)
        Me.NhaCungCap.SqlFielKey = "MaNhaCungCap"
        Me.NhaCungCap.SqlString = "select MaNhaCungCap, TenNhaCungCap from tblNhaCungCap"
        Me.NhaCungCap.TabIndex = 7
        Me.NhaCungCap.TableName = ""
        Me.NhaCungCap.UpdateIfNull = "N"
        Me.NhaCungCap.UpdateWhenFormLock = False
        Me.NhaCungCap.UpperValue = False
        Me.NhaCungCap.ValidateValue = False
        Me.NhaCungCap.ViewName = "FPT_tblPhuongTien_V1"
        Me.NhaCungCap.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 125)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 19)
        Me.Label7.TabIndex = 477
        Me.Label7.Text = "Số đăng kiểm"
        '
        'REG_NO
        '
        Me.REG_NO.AllowInsert = True
        Me.REG_NO.AllowUpdate = True
        Me.REG_NO.AutoKeyFix = ""
        Me.REG_NO.AutoKeyName = ""
        Me.REG_NO.BindingSourceName = ""
        Me.REG_NO.ChangeFormStatus = True
        Me.REG_NO.CopyFromItem = ""
        Me.REG_NO.DefaultValue = ""
        Me.REG_NO.FieldName = "REG_NO"
        Me.REG_NO.FieldType = "C"
        Me.REG_NO.KeyInsert = "Y"
        Me.REG_NO.LinkLabel = ""
        Me.REG_NO.Location = New System.Drawing.Point(156, 122)
        Me.REG_NO.Name = "REG_NO"
        Me.REG_NO.NoUpdate = "N"
        Me.REG_NO.PrimaryKey = ""
        Me.REG_NO.Properties.AutoHeight = False
        Me.REG_NO.Required = "N"
        Me.REG_NO.Size = New System.Drawing.Size(152, 26)
        Me.REG_NO.TabIndex = 3
        Me.REG_NO.TableName = "tblPhuongTien"
        Me.REG_NO.UpdateIfNull = ""
        Me.REG_NO.UpdateWhenFormLock = False
        Me.REG_NO.UpperValue = False
        Me.REG_NO.ViewName = "FPT_tblPhuongTien_V1"
        '
        'FrmVehicleAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 402)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.REG_NO)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.NhaCungCap)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.U_NumericEdit1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Navigator1)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.NgayHieuLuc)
        Me.Controls.Add(Me.NgayBatDau)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NgayHieuLuc1)
        Me.Controls.Add(Me.NgayBatDau1)
        Me.Controls.Add(Me.TuType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SoNgan)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MaPhuongTien)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.HeaderSource = "tblPhuongTien"
        Me.MaximizeBox = False
        Me.Name = "FrmVehicleAdd"
        Me.SetSourceItem = True
        Me.ShowFormMessage = True
        Me.Text = "Thêm mới phương tiện"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.MaPhuongTien, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.SoNgan, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TuType, 0)
        Me.Controls.SetChildIndex(Me.NgayBatDau1, 0)
        Me.Controls.SetChildIndex(Me.NgayHieuLuc1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.NgayBatDau, 0)
        Me.Controls.SetChildIndex(Me.NgayHieuLuc, 0)
        Me.Controls.SetChildIndex(Me.BtnOk, 0)
        Me.Controls.SetChildIndex(Me.Navigator1, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.U_NumericEdit1, 0)
        Me.Controls.SetChildIndex(Me.cmdSave, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.NhaCungCap, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.REG_NO, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaPhuongTien.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoNgan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TuType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayBatDau1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayBatDau1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayHieuLuc1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayHieuLuc1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayBatDau.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayHieuLuc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_NumericEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.NhaCungCap.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REG_NO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents MaPhuongTien As U_TextBox.U_TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SoNgan As U_TextBox.U_NumericEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TuType As U_TextBox.U_Combobox
    Friend WithEvents NgayBatDau1 As U_TextBox.U_DateEdit
    Friend WithEvents NgayHieuLuc1 As U_TextBox.U_DateEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NgayBatDau As U_TextBox.U_TextBox
    Friend WithEvents NgayHieuLuc As U_TextBox.U_TextBox
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ColMaPhuongTien As U_TextBox.GridColumn
    Friend WithEvents ColMaNgan As U_TextBox.GridColumn
    Friend WithEvents SoLuongMax As U_TextBox.GridColumn
    Friend WithEvents ColStatus As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents BtnOk As U_TextBox.U_ButtonCus
    Friend WithEvents Navigator1 As U_TextBox.Navigator
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents U_NumericEdit1 As U_TextBox.U_NumericEdit
    Friend WithEvents cmdSave As U_TextBox.U_ButtonCus
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents NhaCungCap As U_TextBox.U_ButtonEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents REG_NO As U_TextBox.U_TextBox
    Friend WithEvents LTT_CM As U_TextBox.GridColumn
    Friend WithEvents NHAP_MM As U_TextBox.GridColumn
    Friend WithEvents DUONGSINH As U_TextBox.GridColumn
    Friend WithEvents ID As U_TextBox.GridColumn
End Class
