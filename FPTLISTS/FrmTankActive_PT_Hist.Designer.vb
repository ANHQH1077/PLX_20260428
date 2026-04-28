<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTankActive_PT_Hist
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
        Me.MeterId = New U_TextBox.GridColumn()
        Me.LoadingSite = New U_TextBox.GridColumn()
        Me.ArmNo = New U_TextBox.GridColumn()
        Me.Name_ND = New U_TextBox.GridColumn()
        Me.ProductCode = New U_TextBox.GridColumn()
        Me.Dens_nd = New U_TextBox.GridColumn()
        Me.UserName = New U_TextBox.GridColumn()
        Me.CrdDate = New U_TextBox.GridColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NgayThang = New U_TextBox.U_DateEdit()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BeXuat = New U_TextBox.U_ButtonEdit()
        Me.cmdTimKiem = New U_TextBox.U_ButtonCus(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nArmNo = New U_TextBox.U_NumericEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cMeterId = New U_TextBox.U_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TuNgay = New U_TextBox.U_DateEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayThang.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayThang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BeXuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nArmNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cMeterId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TuNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TuNgay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(7, 50)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(904, 544)
        Me.TrueDBGrid1.TabIndex = 0
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MeterId, Me.LoadingSite, Me.ArmNo, Me.Name_ND, Me.ProductCode, Me.Dens_nd, Me.UserName, Me.CrdDate})
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
        Me.GridView1.OrderBy = "CrdDate desc"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "tblTankActive_Arm_Hist"
        Me.GridView1.Where = "Name_ND ='-99'"
        '
        'MeterId
        '
        Me.MeterId.AllowInsert = True
        Me.MeterId.AllowUpdate = True
        Me.MeterId.ButtonClick = True
        Me.MeterId.Caption = "Công tơ"
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
        Me.MeterId.ColumnKey = False
        Me.MeterId.ComboLine = 5
        Me.MeterId.CopyFromItem = ""
        Me.MeterId.DefaultButtonClick = False
        Me.MeterId.Digit = False
        Me.MeterId.FieldType = "C"
        Me.MeterId.FieldView = "MeterId"
        Me.MeterId.FormarNumber = True
        Me.MeterId.FormList = False
        Me.MeterId.KeyInsert = ""
        Me.MeterId.LocalDecimal = False
        Me.MeterId.Name = "MeterId"
        Me.MeterId.NoUpdate = ""
        Me.MeterId.NumberDecimal = 0
        Me.MeterId.ParentControl = ""
        Me.MeterId.RefreshSource = False
        Me.MeterId.Required = False
        Me.MeterId.ShowCalc = True
        Me.MeterId.ShowDataTime = False
        Me.MeterId.ShowOnlyTime = False
        Me.MeterId.SQLString = ""
        Me.MeterId.UpdateIfNull = ""
        Me.MeterId.UpdateWhenFormLock = False
        Me.MeterId.ValidateValue = True
        Me.MeterId.Visible = True
        Me.MeterId.VisibleIndex = 0
        '
        'LoadingSite
        '
        Me.LoadingSite.AllowInsert = True
        Me.LoadingSite.AllowUpdate = True
        Me.LoadingSite.ButtonClick = True
        Me.LoadingSite.Caption = "Loại"
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
        Me.LoadingSite.ShowCalc = True
        Me.LoadingSite.ShowDataTime = False
        Me.LoadingSite.ShowOnlyTime = False
        Me.LoadingSite.SQLString = ""
        Me.LoadingSite.UpdateIfNull = ""
        Me.LoadingSite.UpdateWhenFormLock = False
        Me.LoadingSite.ValidateValue = True
        Me.LoadingSite.Visible = True
        Me.LoadingSite.VisibleIndex = 1
        '
        'ArmNo
        '
        Me.ArmNo.AllowInsert = True
        Me.ArmNo.AllowUpdate = True
        Me.ArmNo.ButtonClick = True
        Me.ArmNo.Caption = "Họng "
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
        Me.ArmNo.ShowCalc = True
        Me.ArmNo.ShowDataTime = False
        Me.ArmNo.ShowOnlyTime = False
        Me.ArmNo.SQLString = ""
        Me.ArmNo.UpdateIfNull = ""
        Me.ArmNo.UpdateWhenFormLock = False
        Me.ArmNo.ValidateValue = True
        Me.ArmNo.Visible = True
        Me.ArmNo.VisibleIndex = 2
        '
        'Name_ND
        '
        Me.Name_ND.AllowInsert = True
        Me.Name_ND.AllowUpdate = True
        Me.Name_ND.ButtonClick = True
        Me.Name_ND.Caption = "Bể"
        Me.Name_ND.CFLColumnHide = ""
        Me.Name_ND.CFLKeyField = ""
        Me.Name_ND.CFLPage = False
        Me.Name_ND.CFLReturn0 = ""
        Me.Name_ND.CFLReturn1 = ""
        Me.Name_ND.CFLReturn2 = ""
        Me.Name_ND.CFLReturn3 = ""
        Me.Name_ND.CFLReturn4 = ""
        Me.Name_ND.CFLReturn5 = ""
        Me.Name_ND.CFLReturn6 = ""
        Me.Name_ND.CFLReturn7 = ""
        Me.Name_ND.CFLShowLoad = False
        Me.Name_ND.ChangeFormStatus = True
        Me.Name_ND.ColumnKey = False
        Me.Name_ND.ComboLine = 5
        Me.Name_ND.CopyFromItem = ""
        Me.Name_ND.DefaultButtonClick = False
        Me.Name_ND.Digit = False
        Me.Name_ND.FieldType = "C"
        Me.Name_ND.FieldView = "Name_nd"
        Me.Name_ND.FormarNumber = True
        Me.Name_ND.FormList = False
        Me.Name_ND.KeyInsert = ""
        Me.Name_ND.LocalDecimal = False
        Me.Name_ND.Name = "Name_ND"
        Me.Name_ND.NoUpdate = ""
        Me.Name_ND.NumberDecimal = 0
        Me.Name_ND.ParentControl = ""
        Me.Name_ND.RefreshSource = False
        Me.Name_ND.Required = False
        Me.Name_ND.ShowCalc = True
        Me.Name_ND.ShowDataTime = False
        Me.Name_ND.ShowOnlyTime = False
        Me.Name_ND.SQLString = ""
        Me.Name_ND.UpdateIfNull = ""
        Me.Name_ND.UpdateWhenFormLock = False
        Me.Name_ND.ValidateValue = True
        Me.Name_ND.Visible = True
        Me.Name_ND.VisibleIndex = 3
        '
        'ProductCode
        '
        Me.ProductCode.AllowInsert = True
        Me.ProductCode.AllowUpdate = True
        Me.ProductCode.ButtonClick = True
        Me.ProductCode.Caption = "Mã hàng"
        Me.ProductCode.CFLColumnHide = ""
        Me.ProductCode.CFLKeyField = ""
        Me.ProductCode.CFLPage = False
        Me.ProductCode.CFLReturn0 = ""
        Me.ProductCode.CFLReturn1 = ""
        Me.ProductCode.CFLReturn2 = ""
        Me.ProductCode.CFLReturn3 = ""
        Me.ProductCode.CFLReturn4 = ""
        Me.ProductCode.CFLReturn5 = ""
        Me.ProductCode.CFLReturn6 = ""
        Me.ProductCode.CFLReturn7 = ""
        Me.ProductCode.CFLShowLoad = False
        Me.ProductCode.ChangeFormStatus = True
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
        Me.ProductCode.ShowCalc = True
        Me.ProductCode.ShowDataTime = False
        Me.ProductCode.ShowOnlyTime = False
        Me.ProductCode.SQLString = ""
        Me.ProductCode.UpdateIfNull = ""
        Me.ProductCode.UpdateWhenFormLock = False
        Me.ProductCode.ValidateValue = True
        Me.ProductCode.Visible = True
        Me.ProductCode.VisibleIndex = 4
        '
        'Dens_nd
        '
        Me.Dens_nd.AllowInsert = True
        Me.Dens_nd.AllowUpdate = True
        Me.Dens_nd.ButtonClick = True
        Me.Dens_nd.Caption = "Tỷ trọng"
        Me.Dens_nd.CFLColumnHide = ""
        Me.Dens_nd.CFLKeyField = ""
        Me.Dens_nd.CFLPage = False
        Me.Dens_nd.CFLReturn0 = ""
        Me.Dens_nd.CFLReturn1 = ""
        Me.Dens_nd.CFLReturn2 = ""
        Me.Dens_nd.CFLReturn3 = ""
        Me.Dens_nd.CFLReturn4 = ""
        Me.Dens_nd.CFLReturn5 = ""
        Me.Dens_nd.CFLReturn6 = ""
        Me.Dens_nd.CFLReturn7 = ""
        Me.Dens_nd.CFLShowLoad = False
        Me.Dens_nd.ChangeFormStatus = True
        Me.Dens_nd.ColumnKey = False
        Me.Dens_nd.ComboLine = 5
        Me.Dens_nd.CopyFromItem = ""
        Me.Dens_nd.DefaultButtonClick = False
        Me.Dens_nd.Digit = True
        Me.Dens_nd.FieldType = "N"
        Me.Dens_nd.FieldView = "Dens"
        Me.Dens_nd.FormarNumber = True
        Me.Dens_nd.FormList = False
        Me.Dens_nd.KeyInsert = ""
        Me.Dens_nd.LocalDecimal = True
        Me.Dens_nd.Name = "Dens_nd"
        Me.Dens_nd.NoUpdate = ""
        Me.Dens_nd.NumberDecimal = 4
        Me.Dens_nd.ParentControl = ""
        Me.Dens_nd.RefreshSource = False
        Me.Dens_nd.Required = False
        Me.Dens_nd.ShowCalc = True
        Me.Dens_nd.ShowDataTime = False
        Me.Dens_nd.ShowOnlyTime = False
        Me.Dens_nd.SQLString = ""
        Me.Dens_nd.UpdateIfNull = ""
        Me.Dens_nd.UpdateWhenFormLock = False
        Me.Dens_nd.ValidateValue = True
        Me.Dens_nd.Visible = True
        Me.Dens_nd.VisibleIndex = 5
        '
        'UserName
        '
        Me.UserName.AllowInsert = True
        Me.UserName.AllowUpdate = True
        Me.UserName.ButtonClick = True
        Me.UserName.Caption = "Người thay đổi"
        Me.UserName.CFLColumnHide = ""
        Me.UserName.CFLKeyField = ""
        Me.UserName.CFLPage = False
        Me.UserName.CFLReturn0 = ""
        Me.UserName.CFLReturn1 = ""
        Me.UserName.CFLReturn2 = ""
        Me.UserName.CFLReturn3 = ""
        Me.UserName.CFLReturn4 = ""
        Me.UserName.CFLReturn5 = ""
        Me.UserName.CFLReturn6 = ""
        Me.UserName.CFLReturn7 = ""
        Me.UserName.CFLShowLoad = False
        Me.UserName.ChangeFormStatus = True
        Me.UserName.ColumnKey = False
        Me.UserName.ComboLine = 5
        Me.UserName.CopyFromItem = ""
        Me.UserName.DefaultButtonClick = False
        Me.UserName.Digit = False
        Me.UserName.FieldType = "C"
        Me.UserName.FieldView = "UserName"
        Me.UserName.FormarNumber = True
        Me.UserName.FormList = False
        Me.UserName.KeyInsert = ""
        Me.UserName.LocalDecimal = False
        Me.UserName.Name = "UserName"
        Me.UserName.NoUpdate = ""
        Me.UserName.NumberDecimal = 0
        Me.UserName.ParentControl = ""
        Me.UserName.RefreshSource = False
        Me.UserName.Required = False
        Me.UserName.ShowCalc = True
        Me.UserName.ShowDataTime = False
        Me.UserName.ShowOnlyTime = False
        Me.UserName.SQLString = ""
        Me.UserName.UpdateIfNull = ""
        Me.UserName.UpdateWhenFormLock = False
        Me.UserName.ValidateValue = True
        Me.UserName.Visible = True
        Me.UserName.VisibleIndex = 6
        Me.UserName.Width = 85
        '
        'CrdDate
        '
        Me.CrdDate.AllowInsert = True
        Me.CrdDate.AllowUpdate = True
        Me.CrdDate.ButtonClick = True
        Me.CrdDate.Caption = "Ngày thay đổi"
        Me.CrdDate.CFLColumnHide = ""
        Me.CrdDate.CFLKeyField = ""
        Me.CrdDate.CFLPage = False
        Me.CrdDate.CFLReturn0 = ""
        Me.CrdDate.CFLReturn1 = ""
        Me.CrdDate.CFLReturn2 = ""
        Me.CrdDate.CFLReturn3 = ""
        Me.CrdDate.CFLReturn4 = ""
        Me.CrdDate.CFLReturn5 = ""
        Me.CrdDate.CFLReturn6 = ""
        Me.CrdDate.CFLReturn7 = ""
        Me.CrdDate.CFLShowLoad = False
        Me.CrdDate.ChangeFormStatus = True
        Me.CrdDate.ColumnKey = False
        Me.CrdDate.ComboLine = 5
        Me.CrdDate.CopyFromItem = ""
        Me.CrdDate.DefaultButtonClick = False
        Me.CrdDate.Digit = False
        Me.CrdDate.FieldType = "D"
        Me.CrdDate.FieldView = "CrdDate"
        Me.CrdDate.FormarNumber = True
        Me.CrdDate.FormList = False
        Me.CrdDate.KeyInsert = ""
        Me.CrdDate.LocalDecimal = False
        Me.CrdDate.Name = "CrdDate"
        Me.CrdDate.NoUpdate = ""
        Me.CrdDate.NumberDecimal = 0
        Me.CrdDate.OptionsFilter.AllowAutoFilter = False
        Me.CrdDate.OptionsFilter.AllowFilter = False
        Me.CrdDate.ParentControl = ""
        Me.CrdDate.RefreshSource = False
        Me.CrdDate.Required = False
        Me.CrdDate.ShowCalc = True
        Me.CrdDate.ShowDataTime = True
        Me.CrdDate.ShowOnlyTime = False
        Me.CrdDate.SQLString = ""
        Me.CrdDate.UpdateIfNull = ""
        Me.CrdDate.UpdateWhenFormLock = False
        Me.CrdDate.ValidateValue = True
        Me.CrdDate.Visible = True
        Me.CrdDate.VisibleIndex = 7
        Me.CrdDate.Width = 130
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(207, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 425
        Me.Label2.Text = "Đến ngày"
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
        Me.NgayThang.Location = New System.Drawing.Point(276, 15)
        Me.NgayThang.Name = "NgayThang"
        Me.NgayThang.NoUpdate = ""
        Me.NgayThang.PrimaryKey = ""
        Me.NgayThang.Properties.AutoHeight = False
        Me.NgayThang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayThang.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayThang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayThang.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayThang.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayThang.Required = ""
        Me.NgayThang.ShowDateTime = False
        Me.NgayThang.Size = New System.Drawing.Size(126, 26)
        Me.NgayThang.TabIndex = 1
        Me.NgayThang.TableName = ""
        Me.NgayThang.UpdateIfNull = ""
        Me.NgayThang.UpdateWhenFormLock = False
        Me.NgayThang.ViewName = ""
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(420, 19)
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
        Me.BeXuat.Location = New System.Drawing.Point(471, 15)
        Me.BeXuat.MultiSelect = False
        Me.BeXuat.Name = "BeXuat"
        Me.BeXuat.NoUpdate = "N"
        Me.BeXuat.PrimaryKey = ""
        Me.BeXuat.Properties.AutoHeight = False
        Me.BeXuat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BeXuat.Required = ""
        Me.BeXuat.ShowLoad = True
        Me.BeXuat.Size = New System.Drawing.Size(95, 26)
        Me.BeXuat.SqlFielKey = "Name_ND"
        Me.BeXuat.SqlString = "select Name_ND from tblTank"
        Me.BeXuat.TabIndex = 2
        Me.BeXuat.TableName = ""
        Me.BeXuat.UpdateIfNull = ""
        Me.BeXuat.UpdateWhenFormLock = False
        Me.BeXuat.UpperValue = False
        Me.BeXuat.ValidateValue = True
        Me.BeXuat.ViewName = ""
        '
        'cmdTimKiem
        '
        Me.cmdTimKiem.DefaultUpdate = False
        Me.cmdTimKiem.Location = New System.Drawing.Point(831, 18)
        Me.cmdTimKiem.Name = "cmdTimKiem"
        Me.cmdTimKiem.Size = New System.Drawing.Size(75, 23)
        Me.cmdTimKiem.TabIndex = 5
        Me.cmdTimKiem.Text = "&Tìm kiếm"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(572, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 460
        Me.Label1.Text = "Họng xuất"
        '
        'nArmNo
        '
        Me.nArmNo.AllowInsert = True
        Me.nArmNo.AllowUpdate = True
        Me.nArmNo.AutoKeyFix = ""
        Me.nArmNo.AutoKeyName = ""
        Me.nArmNo.BindingSourceName = ""
        Me.nArmNo.ChangeFormStatus = True
        Me.nArmNo.CopyFromItem = ""
        Me.nArmNo.DefaultValue = ""
        Me.nArmNo.Digit = True
        Me.nArmNo.FieldName = ""
        Me.nArmNo.FieldType = "N"
        Me.nArmNo.KeyInsert = ""
        Me.nArmNo.LinkLabel = ""
        Me.nArmNo.LocalDecimal = False
        Me.nArmNo.Location = New System.Drawing.Point(635, 15)
        Me.nArmNo.Name = "nArmNo"
        Me.nArmNo.NoUpdate = ""
        Me.nArmNo.NumberDecimal = 0
        Me.nArmNo.PrimaryKey = ""
        Me.nArmNo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.nArmNo.Properties.Appearance.Options.UseFont = True
        Me.nArmNo.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.nArmNo.Properties.AppearanceDisabled.Options.UseFont = True
        Me.nArmNo.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.nArmNo.Properties.AppearanceFocused.Options.UseFont = True
        Me.nArmNo.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.nArmNo.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.nArmNo.Properties.AutoHeight = False
        Me.nArmNo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.nArmNo.Required = ""
        Me.nArmNo.ShowCalc = False
        Me.nArmNo.Size = New System.Drawing.Size(67, 26)
        Me.nArmNo.TabIndex = 3
        Me.nArmNo.TableName = ""
        Me.nArmNo.UpdateIfNull = ""
        Me.nArmNo.UpdateWhenFormLock = False
        Me.nArmNo.ViewName = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(708, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 462
        Me.Label3.Text = "Công tơ"
        '
        'cMeterId
        '
        Me.cMeterId.AllowInsert = True
        Me.cMeterId.AllowUpdate = True
        Me.cMeterId.AutoKeyFix = ""
        Me.cMeterId.AutoKeyName = ""
        Me.cMeterId.BindingSourceName = ""
        Me.cMeterId.ChangeFormStatus = True
        Me.cMeterId.CopyFromItem = ""
        Me.cMeterId.DefaultValue = ""
        Me.cMeterId.FieldName = ""
        Me.cMeterId.FieldType = "C"
        Me.cMeterId.KeyInsert = ""
        Me.cMeterId.LinkLabel = ""
        Me.cMeterId.Location = New System.Drawing.Point(759, 15)
        Me.cMeterId.Name = "cMeterId"
        Me.cMeterId.NoUpdate = "N"
        Me.cMeterId.PrimaryKey = ""
        Me.cMeterId.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.cMeterId.Properties.Appearance.Options.UseFont = True
        Me.cMeterId.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.cMeterId.Properties.AppearanceDisabled.Options.UseFont = True
        Me.cMeterId.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.cMeterId.Properties.AppearanceFocused.Options.UseFont = True
        Me.cMeterId.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.cMeterId.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.cMeterId.Properties.AutoHeight = False
        Me.cMeterId.Required = ""
        Me.cMeterId.Size = New System.Drawing.Size(61, 26)
        Me.cMeterId.TabIndex = 4
        Me.cMeterId.TableName = ""
        Me.cMeterId.UpdateIfNull = ""
        Me.cMeterId.UpdateWhenFormLock = False
        Me.cMeterId.UpperValue = False
        Me.cMeterId.ViewName = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 465
        Me.Label4.Text = "Từ ngày"
        '
        'TuNgay
        '
        Me.TuNgay.AllowInsert = False
        Me.TuNgay.AllowUpdate = False
        Me.TuNgay.BindingSourceName = ""
        Me.TuNgay.ChangeFormStatus = False
        Me.TuNgay.CopyFromItem = ""
        Me.TuNgay.DefaultValue = ""
        Me.TuNgay.EditValue = Nothing
        Me.TuNgay.FieldName = ""
        Me.TuNgay.FieldType = "D"
        Me.TuNgay.KeyInsert = ""
        Me.TuNgay.LinkLabel = ""
        Me.TuNgay.Location = New System.Drawing.Point(75, 15)
        Me.TuNgay.Name = "TuNgay"
        Me.TuNgay.NoUpdate = ""
        Me.TuNgay.PrimaryKey = ""
        Me.TuNgay.Properties.AutoHeight = False
        Me.TuNgay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.TuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TuNgay.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.TuNgay.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TuNgay.Required = ""
        Me.TuNgay.ShowDateTime = False
        Me.TuNgay.Size = New System.Drawing.Size(126, 26)
        Me.TuNgay.TabIndex = 0
        Me.TuNgay.TableName = ""
        Me.TuNgay.UpdateIfNull = ""
        Me.TuNgay.UpdateWhenFormLock = False
        Me.TuNgay.ViewName = ""
        '
        'FrmTankActive_PT_Hist
        '
        Me.AcceptButton = Me.cmdTimKiem
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 606)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TuNgay)
        Me.Controls.Add(Me.cMeterId)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nArmNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdTimKiem)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.BeXuat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NgayThang)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Name = "FrmTankActive_PT_Hist"
        Me.Text = "Lịch sử thay đổi tỷ trọng"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.NgayThang, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.BeXuat, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.cmdTimKiem, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.nArmNo, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cMeterId, 0)
        Me.Controls.SetChildIndex(Me.TuNgay, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayThang.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayThang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BeXuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nArmNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cMeterId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TuNgay.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TuNgay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NgayThang As U_TextBox.U_DateEdit
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BeXuat As U_TextBox.U_ButtonEdit
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ProductCode As U_TextBox.GridColumn
    Friend WithEvents Dens_nd As U_TextBox.GridColumn
    Friend WithEvents UserName As U_TextBox.GridColumn
    Friend WithEvents CrdDate As U_TextBox.GridColumn
    Friend WithEvents cmdTimKiem As U_TextBox.U_ButtonCus
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MeterId As U_TextBox.GridColumn
    Friend WithEvents LoadingSite As U_TextBox.GridColumn
    Friend WithEvents ArmNo As U_TextBox.GridColumn
    Friend WithEvents Name_ND As U_TextBox.GridColumn
    Friend WithEvents nArmNo As U_TextBox.U_NumericEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cMeterId As U_TextBox.U_TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TuNgay As U_TextBox.U_DateEdit
End Class
