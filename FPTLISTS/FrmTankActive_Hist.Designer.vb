<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTankActive_Hist
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
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.Name_nd = New U_TextBox.GridColumn()
        Me.Product_nd = New U_TextBox.GridColumn()
        Me.TenHangHoa = New U_TextBox.GridColumn()
        Me.Dens_nd = New U_TextBox.GridColumn()
        Me.Createby = New U_TextBox.GridColumn()
        Me.CreateDate = New U_TextBox.GridColumn()
        Me.UpdatedBy = New U_TextBox.GridColumn()
        Me.UpdateDate = New U_TextBox.GridColumn()
        Me.Date_nd = New U_TextBox.GridColumn()
        Me.Status_Name = New U_TextBox.GridColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NgayThang = New U_TextBox.U_DateEdit()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BeXuat = New U_TextBox.U_ButtonEdit()
        Me.cmdTimKiem = New U_TextBox.U_ButtonCus()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayThang.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayThang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BeXuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(8, 44)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(904, 412)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Name_nd, Me.Product_nd, Me.TenHangHoa, Me.Dens_nd, Me.Createby, Me.CreateDate, Me.UpdatedBy, Me.UpdateDate, Me.Date_nd, Me.Status_Name})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OrderBy = "Date_nd"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "tblTankActive_Hist_v"
        Me.GridView1.Where = "Date_nd='-99'"
        '
        'Name_nd
        '
        Me.Name_nd.AllowInsert = True
        Me.Name_nd.AllowUpdate = True
        Me.Name_nd.Caption = "Mã bể"
        Me.Name_nd.CFLColumnHide = ""
        Me.Name_nd.CFLKeyField = ""
        Me.Name_nd.CFLPage = False
        Me.Name_nd.CFLReturn0 = ""
        Me.Name_nd.CFLReturn1 = ""
        Me.Name_nd.CFLReturn2 = ""
        Me.Name_nd.CFLReturn3 = ""
        Me.Name_nd.CFLReturn4 = ""
        Me.Name_nd.CFLShowLoad = False
        Me.Name_nd.ChangeFormStatus = True
        Me.Name_nd.ColumnKey = False
        Me.Name_nd.ComboLine = 5
        Me.Name_nd.CopyFromItem = ""
        Me.Name_nd.DefaultButtonClick = False
        Me.Name_nd.Digit = False
        Me.Name_nd.FieldType = "C"
        Me.Name_nd.FieldView = "Name_nd"
        Me.Name_nd.FormList = False
        Me.Name_nd.KeyInsert = ""
        Me.Name_nd.LocalDecimal = False
        Me.Name_nd.Name = "Name_nd"
        Me.Name_nd.NoUpdate = ""
        Me.Name_nd.NumberDecimal = 0
        Me.Name_nd.ParentControl = ""
        Me.Name_nd.RefreshSource = False
        Me.Name_nd.Required = False
        Me.Name_nd.ShowDataTime = False
        Me.Name_nd.SQLString = ""
        Me.Name_nd.UpdateIfNull = ""
        Me.Name_nd.UpdateWhenFormLock = False
        Me.Name_nd.Visible = True
        Me.Name_nd.VisibleIndex = 1
        '
        'Product_nd
        '
        Me.Product_nd.AllowInsert = True
        Me.Product_nd.AllowUpdate = True
        Me.Product_nd.Caption = "Mã hàng"
        Me.Product_nd.CFLColumnHide = ""
        Me.Product_nd.CFLKeyField = ""
        Me.Product_nd.CFLPage = False
        Me.Product_nd.CFLReturn0 = ""
        Me.Product_nd.CFLReturn1 = ""
        Me.Product_nd.CFLReturn2 = ""
        Me.Product_nd.CFLReturn3 = ""
        Me.Product_nd.CFLReturn4 = ""
        Me.Product_nd.CFLShowLoad = False
        Me.Product_nd.ChangeFormStatus = True
        Me.Product_nd.ColumnKey = False
        Me.Product_nd.ComboLine = 5
        Me.Product_nd.CopyFromItem = ""
        Me.Product_nd.DefaultButtonClick = False
        Me.Product_nd.Digit = False
        Me.Product_nd.FieldType = "C"
        Me.Product_nd.FieldView = "Product_nd"
        Me.Product_nd.FormList = False
        Me.Product_nd.KeyInsert = ""
        Me.Product_nd.LocalDecimal = False
        Me.Product_nd.Name = "Product_nd"
        Me.Product_nd.NoUpdate = ""
        Me.Product_nd.NumberDecimal = 0
        Me.Product_nd.ParentControl = ""
        Me.Product_nd.RefreshSource = False
        Me.Product_nd.Required = False
        Me.Product_nd.ShowDataTime = False
        Me.Product_nd.SQLString = ""
        Me.Product_nd.UpdateIfNull = ""
        Me.Product_nd.UpdateWhenFormLock = False
        Me.Product_nd.Visible = True
        Me.Product_nd.VisibleIndex = 2
        '
        'TenHangHoa
        '
        Me.TenHangHoa.AllowInsert = True
        Me.TenHangHoa.AllowUpdate = True
        Me.TenHangHoa.Caption = "Tên hàng"
        Me.TenHangHoa.CFLColumnHide = ""
        Me.TenHangHoa.CFLKeyField = ""
        Me.TenHangHoa.CFLPage = False
        Me.TenHangHoa.CFLReturn0 = ""
        Me.TenHangHoa.CFLReturn1 = ""
        Me.TenHangHoa.CFLReturn2 = ""
        Me.TenHangHoa.CFLReturn3 = ""
        Me.TenHangHoa.CFLReturn4 = ""
        Me.TenHangHoa.CFLShowLoad = False
        Me.TenHangHoa.ChangeFormStatus = True
        Me.TenHangHoa.ColumnKey = False
        Me.TenHangHoa.ComboLine = 5
        Me.TenHangHoa.CopyFromItem = ""
        Me.TenHangHoa.DefaultButtonClick = False
        Me.TenHangHoa.Digit = False
        Me.TenHangHoa.FieldType = "C"
        Me.TenHangHoa.FieldView = "TenHangHoa"
        Me.TenHangHoa.FormList = False
        Me.TenHangHoa.KeyInsert = ""
        Me.TenHangHoa.LocalDecimal = False
        Me.TenHangHoa.Name = "TenHangHoa"
        Me.TenHangHoa.NoUpdate = ""
        Me.TenHangHoa.NumberDecimal = 0
        Me.TenHangHoa.ParentControl = ""
        Me.TenHangHoa.RefreshSource = False
        Me.TenHangHoa.Required = False
        Me.TenHangHoa.ShowDataTime = False
        Me.TenHangHoa.SQLString = ""
        Me.TenHangHoa.UpdateIfNull = ""
        Me.TenHangHoa.UpdateWhenFormLock = False
        Me.TenHangHoa.Visible = True
        Me.TenHangHoa.VisibleIndex = 3
        Me.TenHangHoa.Width = 250
        '
        'Dens_nd
        '
        Me.Dens_nd.AllowInsert = True
        Me.Dens_nd.AllowUpdate = True
        Me.Dens_nd.Caption = "Tỷ trọng"
        Me.Dens_nd.CFLColumnHide = ""
        Me.Dens_nd.CFLKeyField = ""
        Me.Dens_nd.CFLPage = False
        Me.Dens_nd.CFLReturn0 = ""
        Me.Dens_nd.CFLReturn1 = ""
        Me.Dens_nd.CFLReturn2 = ""
        Me.Dens_nd.CFLReturn3 = ""
        Me.Dens_nd.CFLReturn4 = ""
        Me.Dens_nd.CFLShowLoad = False
        Me.Dens_nd.ChangeFormStatus = True
        Me.Dens_nd.ColumnKey = False
        Me.Dens_nd.ComboLine = 5
        Me.Dens_nd.CopyFromItem = ""
        Me.Dens_nd.DefaultButtonClick = False
        Me.Dens_nd.Digit = False
        Me.Dens_nd.FieldType = "C"
        Me.Dens_nd.FieldView = "Dens_nd"
        Me.Dens_nd.FormList = False
        Me.Dens_nd.KeyInsert = ""
        Me.Dens_nd.LocalDecimal = False
        Me.Dens_nd.Name = "Dens_nd"
        Me.Dens_nd.NoUpdate = ""
        Me.Dens_nd.NumberDecimal = 0
        Me.Dens_nd.ParentControl = ""
        Me.Dens_nd.RefreshSource = False
        Me.Dens_nd.Required = False
        Me.Dens_nd.ShowDataTime = False
        Me.Dens_nd.SQLString = ""
        Me.Dens_nd.UpdateIfNull = ""
        Me.Dens_nd.UpdateWhenFormLock = False
        Me.Dens_nd.Visible = True
        Me.Dens_nd.VisibleIndex = 4
        '
        'Createby
        '
        Me.Createby.AllowInsert = True
        Me.Createby.AllowUpdate = True
        Me.Createby.Caption = "Người tạo"
        Me.Createby.CFLColumnHide = ""
        Me.Createby.CFLKeyField = ""
        Me.Createby.CFLPage = False
        Me.Createby.CFLReturn0 = ""
        Me.Createby.CFLReturn1 = ""
        Me.Createby.CFLReturn2 = ""
        Me.Createby.CFLReturn3 = ""
        Me.Createby.CFLReturn4 = ""
        Me.Createby.CFLShowLoad = False
        Me.Createby.ChangeFormStatus = True
        Me.Createby.ColumnKey = False
        Me.Createby.ComboLine = 5
        Me.Createby.CopyFromItem = ""
        Me.Createby.DefaultButtonClick = False
        Me.Createby.Digit = False
        Me.Createby.FieldType = "C"
        Me.Createby.FieldView = "Createby"
        Me.Createby.FormList = False
        Me.Createby.KeyInsert = ""
        Me.Createby.LocalDecimal = False
        Me.Createby.Name = "Createby"
        Me.Createby.NoUpdate = ""
        Me.Createby.NumberDecimal = 0
        Me.Createby.ParentControl = ""
        Me.Createby.RefreshSource = False
        Me.Createby.Required = False
        Me.Createby.ShowDataTime = False
        Me.Createby.SQLString = ""
        Me.Createby.UpdateIfNull = ""
        Me.Createby.UpdateWhenFormLock = False
        Me.Createby.Visible = True
        Me.Createby.VisibleIndex = 5
        '
        'CreateDate
        '
        Me.CreateDate.AllowInsert = True
        Me.CreateDate.AllowUpdate = True
        Me.CreateDate.Caption = "Ngày tạo"
        Me.CreateDate.CFLColumnHide = ""
        Me.CreateDate.CFLKeyField = ""
        Me.CreateDate.CFLPage = False
        Me.CreateDate.CFLReturn0 = ""
        Me.CreateDate.CFLReturn1 = ""
        Me.CreateDate.CFLReturn2 = ""
        Me.CreateDate.CFLReturn3 = ""
        Me.CreateDate.CFLReturn4 = ""
        Me.CreateDate.CFLShowLoad = False
        Me.CreateDate.ChangeFormStatus = True
        Me.CreateDate.ColumnKey = False
        Me.CreateDate.ComboLine = 5
        Me.CreateDate.CopyFromItem = ""
        Me.CreateDate.DefaultButtonClick = False
        Me.CreateDate.Digit = False
        Me.CreateDate.FieldType = "D"
        Me.CreateDate.FieldView = "CreateDate"
        Me.CreateDate.FormList = False
        Me.CreateDate.KeyInsert = ""
        Me.CreateDate.LocalDecimal = False
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.NoUpdate = ""
        Me.CreateDate.NumberDecimal = 0
        Me.CreateDate.OptionsFilter.AllowAutoFilter = False
        Me.CreateDate.OptionsFilter.AllowFilter = False
        Me.CreateDate.ParentControl = ""
        Me.CreateDate.RefreshSource = False
        Me.CreateDate.Required = False
        Me.CreateDate.ShowDataTime = True
        Me.CreateDate.SQLString = ""
        Me.CreateDate.UpdateIfNull = ""
        Me.CreateDate.UpdateWhenFormLock = False
        Me.CreateDate.Visible = True
        Me.CreateDate.VisibleIndex = 6
        Me.CreateDate.Width = 130
        '
        'UpdatedBy
        '
        Me.UpdatedBy.AllowInsert = True
        Me.UpdatedBy.AllowUpdate = True
        Me.UpdatedBy.Caption = "Người thay đổi"
        Me.UpdatedBy.CFLColumnHide = ""
        Me.UpdatedBy.CFLKeyField = ""
        Me.UpdatedBy.CFLPage = False
        Me.UpdatedBy.CFLReturn0 = ""
        Me.UpdatedBy.CFLReturn1 = ""
        Me.UpdatedBy.CFLReturn2 = ""
        Me.UpdatedBy.CFLReturn3 = ""
        Me.UpdatedBy.CFLReturn4 = ""
        Me.UpdatedBy.CFLShowLoad = False
        Me.UpdatedBy.ChangeFormStatus = True
        Me.UpdatedBy.ColumnKey = False
        Me.UpdatedBy.ComboLine = 5
        Me.UpdatedBy.CopyFromItem = ""
        Me.UpdatedBy.DefaultButtonClick = False
        Me.UpdatedBy.Digit = False
        Me.UpdatedBy.FieldType = "C"
        Me.UpdatedBy.FieldView = "UpdatedBy"
        Me.UpdatedBy.FormList = False
        Me.UpdatedBy.KeyInsert = ""
        Me.UpdatedBy.LocalDecimal = False
        Me.UpdatedBy.Name = "UpdatedBy"
        Me.UpdatedBy.NoUpdate = ""
        Me.UpdatedBy.NumberDecimal = 0
        Me.UpdatedBy.ParentControl = ""
        Me.UpdatedBy.RefreshSource = False
        Me.UpdatedBy.Required = False
        Me.UpdatedBy.ShowDataTime = False
        Me.UpdatedBy.SQLString = ""
        Me.UpdatedBy.UpdateIfNull = ""
        Me.UpdatedBy.UpdateWhenFormLock = False
        Me.UpdatedBy.Visible = True
        Me.UpdatedBy.VisibleIndex = 7
        Me.UpdatedBy.Width = 85
        '
        'UpdateDate
        '
        Me.UpdateDate.AllowInsert = True
        Me.UpdateDate.AllowUpdate = True
        Me.UpdateDate.Caption = "Ngày thay đổi"
        Me.UpdateDate.CFLColumnHide = ""
        Me.UpdateDate.CFLKeyField = ""
        Me.UpdateDate.CFLPage = False
        Me.UpdateDate.CFLReturn0 = ""
        Me.UpdateDate.CFLReturn1 = ""
        Me.UpdateDate.CFLReturn2 = ""
        Me.UpdateDate.CFLReturn3 = ""
        Me.UpdateDate.CFLReturn4 = ""
        Me.UpdateDate.CFLShowLoad = False
        Me.UpdateDate.ChangeFormStatus = True
        Me.UpdateDate.ColumnKey = False
        Me.UpdateDate.ComboLine = 5
        Me.UpdateDate.CopyFromItem = ""
        Me.UpdateDate.DefaultButtonClick = False
        Me.UpdateDate.Digit = False
        Me.UpdateDate.FieldType = "D"
        Me.UpdateDate.FieldView = "UpdateDate"
        Me.UpdateDate.FormList = False
        Me.UpdateDate.KeyInsert = ""
        Me.UpdateDate.LocalDecimal = False
        Me.UpdateDate.Name = "UpdateDate"
        Me.UpdateDate.NoUpdate = ""
        Me.UpdateDate.NumberDecimal = 0
        Me.UpdateDate.OptionsFilter.AllowAutoFilter = False
        Me.UpdateDate.OptionsFilter.AllowFilter = False
        Me.UpdateDate.ParentControl = ""
        Me.UpdateDate.RefreshSource = False
        Me.UpdateDate.Required = False
        Me.UpdateDate.ShowDataTime = True
        Me.UpdateDate.SQLString = ""
        Me.UpdateDate.UpdateIfNull = ""
        Me.UpdateDate.UpdateWhenFormLock = False
        Me.UpdateDate.Visible = True
        Me.UpdateDate.VisibleIndex = 8
        Me.UpdateDate.Width = 130
        '
        'Date_nd
        '
        Me.Date_nd.AllowInsert = True
        Me.Date_nd.AllowUpdate = True
        Me.Date_nd.Caption = "Ngày tháng"
        Me.Date_nd.CFLColumnHide = ""
        Me.Date_nd.CFLKeyField = ""
        Me.Date_nd.CFLPage = False
        Me.Date_nd.CFLReturn0 = ""
        Me.Date_nd.CFLReturn1 = ""
        Me.Date_nd.CFLReturn2 = ""
        Me.Date_nd.CFLReturn3 = ""
        Me.Date_nd.CFLReturn4 = ""
        Me.Date_nd.CFLShowLoad = False
        Me.Date_nd.ChangeFormStatus = True
        Me.Date_nd.ColumnKey = False
        Me.Date_nd.ComboLine = 5
        Me.Date_nd.CopyFromItem = ""
        Me.Date_nd.DefaultButtonClick = False
        Me.Date_nd.Digit = False
        Me.Date_nd.FieldType = "C"
        Me.Date_nd.FieldView = "Date_nd"
        Me.Date_nd.FormList = False
        Me.Date_nd.KeyInsert = ""
        Me.Date_nd.LocalDecimal = False
        Me.Date_nd.Name = "Date_nd"
        Me.Date_nd.NoUpdate = ""
        Me.Date_nd.NumberDecimal = 0
        Me.Date_nd.ParentControl = ""
        Me.Date_nd.RefreshSource = False
        Me.Date_nd.Required = False
        Me.Date_nd.ShowDataTime = False
        Me.Date_nd.SQLString = ""
        Me.Date_nd.UpdateIfNull = ""
        Me.Date_nd.UpdateWhenFormLock = False
        Me.Date_nd.Visible = True
        Me.Date_nd.VisibleIndex = 0
        '
        'Status_Name
        '
        Me.Status_Name.AllowInsert = True
        Me.Status_Name.AllowUpdate = True
        Me.Status_Name.Caption = "Trạng thái"
        Me.Status_Name.CFLColumnHide = ""
        Me.Status_Name.CFLKeyField = ""
        Me.Status_Name.CFLPage = False
        Me.Status_Name.CFLReturn0 = ""
        Me.Status_Name.CFLReturn1 = ""
        Me.Status_Name.CFLReturn2 = ""
        Me.Status_Name.CFLReturn3 = ""
        Me.Status_Name.CFLReturn4 = ""
        Me.Status_Name.CFLShowLoad = False
        Me.Status_Name.ChangeFormStatus = True
        Me.Status_Name.ColumnKey = False
        Me.Status_Name.ComboLine = 5
        Me.Status_Name.CopyFromItem = ""
        Me.Status_Name.DefaultButtonClick = False
        Me.Status_Name.Digit = False
        Me.Status_Name.FieldType = "C"
        Me.Status_Name.FieldView = "Status_Name"
        Me.Status_Name.FormList = False
        Me.Status_Name.KeyInsert = ""
        Me.Status_Name.LocalDecimal = False
        Me.Status_Name.Name = "Status_Name"
        Me.Status_Name.NoUpdate = ""
        Me.Status_Name.NumberDecimal = 0
        Me.Status_Name.ParentControl = ""
        Me.Status_Name.RefreshSource = False
        Me.Status_Name.Required = False
        Me.Status_Name.ShowDataTime = False
        Me.Status_Name.SQLString = ""
        Me.Status_Name.UpdateIfNull = ""
        Me.Status_Name.UpdateWhenFormLock = False
        Me.Status_Name.Visible = True
        Me.Status_Name.VisibleIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 425
        Me.Label2.Text = "Ngày tháng"
        '
        'NgayThang
        '
        Me.NgayThang.AllowInsert = False
        Me.NgayThang.AllowUpdate = False
        Me.NgayThang.BindingSourceName = ""
        Me.NgayThang.ChangeFormStatus = False
        Me.NgayThang.CopyFromItem = ""
        Me.NgayThang.DefaultValue = ""
        Me.NgayThang.EditValue = Nothing
        Me.NgayThang.FieldName = ""
        Me.NgayThang.FieldType = "D"
        Me.NgayThang.KeyInsert = ""
        Me.NgayThang.LinkLabel = ""
        Me.NgayThang.Location = New System.Drawing.Point(91, 12)
        Me.NgayThang.Name = "NgayThang"
        Me.NgayThang.NoUpdate = ""
        Me.NgayThang.PrimaryKey = ""
        Me.NgayThang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayThang.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayThang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayThang.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayThang.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayThang.Required = ""
        Me.NgayThang.ShowDateTime = False
        Me.NgayThang.Size = New System.Drawing.Size(95, 20)
        Me.NgayThang.TabIndex = 424
        Me.NgayThang.TableName = ""
        Me.NgayThang.UpdateIfNull = ""
        Me.NgayThang.UpdateWhenFormLock = False
        Me.NgayThang.ViewName = ""
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(214, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 13)
        Me.Label14.TabIndex = 458
        Me.Label14.Text = "Bể xuất"
        '
        'BeXuat
        '
        Me.BeXuat.AllowInsert = False
        Me.BeXuat.AllowUpdate = False
        Me.BeXuat.BindingSourceName = ""
        Me.BeXuat.ChangeFormStatus = False
        Me.BeXuat.CopyFromItem = ""
        Me.BeXuat.DefaultButtonClick = True
        Me.BeXuat.DefaultValue = ""
        Me.BeXuat.FieldName = ""
        Me.BeXuat.FieldType = "C"
        Me.BeXuat.FormList = False
        Me.BeXuat.ItemReturn1 = ""
        Me.BeXuat.ItemReturn2 = ""
        Me.BeXuat.ItemReturn3 = ""
        Me.BeXuat.KeyInsert = ""
        Me.BeXuat.LinkLabel = ""
        Me.BeXuat.Location = New System.Drawing.Point(265, 12)
        Me.BeXuat.MultiSelect = False
        Me.BeXuat.Name = "BeXuat"
        Me.BeXuat.NoUpdate = "N"
        Me.BeXuat.PrimaryKey = ""
        Me.BeXuat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BeXuat.Required = ""
        Me.BeXuat.ShowLoad = True
        Me.BeXuat.Size = New System.Drawing.Size(95, 20)
        Me.BeXuat.SqlFielKey = "Name_ND"
        Me.BeXuat.SqlString = "select Name_ND from tblTank"
        Me.BeXuat.TabIndex = 457
        Me.BeXuat.TableName = ""
        Me.BeXuat.UpdateIfNull = ""
        Me.BeXuat.UpdateWhenFormLock = False
        Me.BeXuat.UpperValue = False
        Me.BeXuat.ViewName = ""
        '
        'cmdTimKiem
        '
        Me.cmdTimKiem.DefaultUpdate = False
        Me.cmdTimKiem.Location = New System.Drawing.Point(381, 12)
        Me.cmdTimKiem.Name = "cmdTimKiem"
        Me.cmdTimKiem.Size = New System.Drawing.Size(75, 23)
        Me.cmdTimKiem.TabIndex = 459
        Me.cmdTimKiem.Text = "&Tìm kiếm"
        '
        'FrmTankActive_Hist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 463)
        Me.Controls.Add(Me.cmdTimKiem)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.BeXuat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NgayThang)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.KeyPreview = True
        Me.Name = "FrmTankActive_Hist"
        Me.Text = "Lịch sử thay đổi tỷ trọng"
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayThang.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayThang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BeXuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NgayThang As U_TextBox.U_DateEdit
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BeXuat As U_TextBox.U_ButtonEdit
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents Name_nd As U_TextBox.GridColumn
    Friend WithEvents Product_nd As U_TextBox.GridColumn
    Friend WithEvents TenHangHoa As U_TextBox.GridColumn
    Friend WithEvents Dens_nd As U_TextBox.GridColumn
    Friend WithEvents Createby As U_TextBox.GridColumn
    Friend WithEvents CreateDate As U_TextBox.GridColumn
    Friend WithEvents UpdatedBy As U_TextBox.GridColumn
    Friend WithEvents UpdateDate As U_TextBox.GridColumn
    Friend WithEvents Date_nd As U_TextBox.GridColumn
    Friend WithEvents Status_Name As U_TextBox.GridColumn
    Friend WithEvents cmdTimKiem As U_TextBox.U_ButtonCus
End Class
