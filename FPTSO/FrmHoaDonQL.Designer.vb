<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHoaDonQL
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Status = New U_TextBox.U_Combobox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtToDate = New U_TextBox.U_DateEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LoaiHoaDon = New U_TextBox.U_Combobox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFromDate = New U_TextBox.U_DateEdit()
        Me.SimpleButton7 = New U_TextBox.U_ButtonCus(Me.components)
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.X = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colDocEntry = New U_TextBox.GridColumn()
        Me.TankHeaderCode = New U_TextBox.GridColumn()
        Me.colCreateDate = New U_TextBox.GridColumn()
        Me.FromDate = New U_TextBox.GridColumn()
        Me.ToDate = New U_TextBox.GridColumn()
        Me.colClient = New U_TextBox.GridColumn()
        Me.colsType = New U_TextBox.GridColumn()
        Me.PurposeCode = New U_TextBox.GridColumn()
        Me.Type = New U_TextBox.GridColumn()
        Me.CreateUser = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.SoLenh = New U_TextBox.U_TextBox()
        Me.SoHD = New U_TextBox.U_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.KyHieuHD = New U_TextBox.U_TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMaTraCuu = New U_TextBox.U_TextBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Status.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtToDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoaiHoaDon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFromDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoHD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KyHieuHD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaTraCuu.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(504, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 19)
        Me.Label5.TabIndex = 515
        Me.Label5.Text = "Trạng thái"
        '
        'Status
        '
        Me.Status.AllowInsert = True
        Me.Status.AllowUpdate = True
        Me.Status.BindingSourceName = ""
        Me.Status.ChangeFormStatus = False
        Me.Status.CopyFromItem = ""
        Me.Status.DefaultValue = ""
        Me.Status.DisplayField = "sName"
        Me.Status.DropDownRow = 10
        Me.Status.FieldName = ""
        Me.Status.FieldType = "C"
        Me.Status.ItemValue = ""
        Me.Status.KeyInsert = ""
        Me.Status.LinkLabel = ""
        Me.Status.Location = New System.Drawing.Point(596, 44)
        Me.Status.Name = "Status"
        Me.Status.NoUpdate = ""
        Me.Status.PrimaryKey = ""
        Me.Status.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Status.Properties.Appearance.Options.UseFont = True
        Me.Status.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Status.Properties.AppearanceDisabled.Options.UseFont = True
        Me.Status.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Status.Properties.AppearanceFocused.Options.UseFont = True
        Me.Status.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Status.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.Status.Properties.AutoHeight = False
        Me.Status.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Status.Properties.NullText = ""
        Me.Status.Properties.ShowHeader = False
        Me.Status.Required = ""
        Me.Status.ShowHeader = False
        Me.Status.Size = New System.Drawing.Size(155, 26)
        Me.Status.SQL_String = "select Code, sName from TrangThaiHoaDonQL_V"
        Me.Status.TabIndex = 4
        Me.Status.TableName = ""
        Me.Status.UpdateIfNull = ""
        Me.Status.UpdateWhenFormLock = False
        Me.Status.ValueField = "Code"
        Me.Status.ViewName = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(263, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 19)
        Me.Label3.TabIndex = 513
        Me.Label3.Text = "Đến ngày"
        '
        'txtToDate
        '
        Me.txtToDate.AllowInsert = True
        Me.txtToDate.AllowUpdate = True
        Me.txtToDate.BindingSourceName = ""
        Me.txtToDate.ChangeFormStatus = False
        Me.txtToDate.CopyFromItem = ""
        Me.txtToDate.DefaultValue = ""
        Me.txtToDate.EditValue = Nothing
        Me.txtToDate.FieldName = ""
        Me.txtToDate.FieldType = "D"
        Me.txtToDate.KeyInsert = ""
        Me.txtToDate.LinkLabel = "Label2"
        Me.txtToDate.Location = New System.Drawing.Point(358, 44)
        Me.txtToDate.Name = "txtToDate"
        Me.txtToDate.NoUpdate = ""
        Me.txtToDate.PrimaryKey = ""
        Me.txtToDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtToDate.Properties.Appearance.Options.UseFont = True
        Me.txtToDate.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtToDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtToDate.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtToDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtToDate.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtToDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtToDate.Properties.AutoHeight = False
        Me.txtToDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.txtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtToDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.txtToDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtToDate.Required = "Y"
        Me.txtToDate.ShowDateTime = False
        Me.txtToDate.Size = New System.Drawing.Size(124, 26)
        Me.txtToDate.TabIndex = 3
        Me.txtToDate.TableName = ""
        Me.txtToDate.TabStop = False
        Me.txtToDate.UpdateIfNull = ""
        Me.txtToDate.UpdateWhenFormLock = False
        Me.txtToDate.ViewName = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(263, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 19)
        Me.Label6.TabIndex = 512
        Me.Label6.Text = "Loại HĐ"
        '
        'LoaiHoaDon
        '
        Me.LoaiHoaDon.AllowInsert = False
        Me.LoaiHoaDon.AllowUpdate = False
        Me.LoaiHoaDon.BindingSourceName = ""
        Me.LoaiHoaDon.ChangeFormStatus = False
        Me.LoaiHoaDon.CopyFromItem = ""
        Me.LoaiHoaDon.DefaultValue = ""
        Me.LoaiHoaDon.DisplayField = "sName"
        Me.LoaiHoaDon.DropDownRow = 10
        Me.LoaiHoaDon.FieldName = ""
        Me.LoaiHoaDon.FieldType = "C"
        Me.LoaiHoaDon.ItemValue = ""
        Me.LoaiHoaDon.KeyInsert = ""
        Me.LoaiHoaDon.LinkLabel = ""
        Me.LoaiHoaDon.Location = New System.Drawing.Point(358, 12)
        Me.LoaiHoaDon.Name = "LoaiHoaDon"
        Me.LoaiHoaDon.NoUpdate = ""
        Me.LoaiHoaDon.PrimaryKey = ""
        Me.LoaiHoaDon.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LoaiHoaDon.Properties.Appearance.Options.UseFont = True
        Me.LoaiHoaDon.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LoaiHoaDon.Properties.AppearanceDisabled.Options.UseFont = True
        Me.LoaiHoaDon.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LoaiHoaDon.Properties.AppearanceFocused.Options.UseFont = True
        Me.LoaiHoaDon.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.LoaiHoaDon.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.LoaiHoaDon.Properties.AutoHeight = False
        Me.LoaiHoaDon.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LoaiHoaDon.Properties.NullText = ""
        Me.LoaiHoaDon.Properties.ShowHeader = False
        Me.LoaiHoaDon.Required = ""
        Me.LoaiHoaDon.ShowHeader = False
        Me.LoaiHoaDon.Size = New System.Drawing.Size(124, 26)
        Me.LoaiHoaDon.SQL_String = "Select Code, sName from LoaiHoaDon_V"
        Me.LoaiHoaDon.TabIndex = 1
        Me.LoaiHoaDon.TableName = ""
        Me.LoaiHoaDon.UpdateIfNull = ""
        Me.LoaiHoaDon.UpdateWhenFormLock = False
        Me.LoaiHoaDon.ValueField = "Code"
        Me.LoaiHoaDon.ViewName = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 19)
        Me.Label4.TabIndex = 511
        Me.Label4.Text = "Số lệnh"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 19)
        Me.Label2.TabIndex = 509
        Me.Label2.Text = "Từ ngày"
        '
        'txtFromDate
        '
        Me.txtFromDate.AllowInsert = True
        Me.txtFromDate.AllowUpdate = True
        Me.txtFromDate.BindingSourceName = ""
        Me.txtFromDate.ChangeFormStatus = False
        Me.txtFromDate.CopyFromItem = ""
        Me.txtFromDate.DefaultValue = ""
        Me.txtFromDate.EditValue = Nothing
        Me.txtFromDate.FieldName = ""
        Me.txtFromDate.FieldType = "D"
        Me.txtFromDate.KeyInsert = ""
        Me.txtFromDate.LinkLabel = "Label2"
        Me.txtFromDate.Location = New System.Drawing.Point(116, 43)
        Me.txtFromDate.Name = "txtFromDate"
        Me.txtFromDate.NoUpdate = ""
        Me.txtFromDate.PrimaryKey = ""
        Me.txtFromDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtFromDate.Properties.Appearance.Options.UseFont = True
        Me.txtFromDate.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtFromDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtFromDate.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtFromDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtFromDate.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtFromDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtFromDate.Properties.AutoHeight = False
        Me.txtFromDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.txtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtFromDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.txtFromDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtFromDate.Required = "Y"
        Me.txtFromDate.ShowDateTime = False
        Me.txtFromDate.Size = New System.Drawing.Size(120, 26)
        Me.txtFromDate.TabIndex = 2
        Me.txtFromDate.TableName = ""
        Me.txtFromDate.TabStop = False
        Me.txtFromDate.UpdateIfNull = ""
        Me.txtFromDate.UpdateWhenFormLock = False
        Me.txtFromDate.ViewName = ""
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.DefaultUpdate = True
        Me.SimpleButton7.EnableWhenFormLock = True
        Me.SimpleButton7.Location = New System.Drawing.Point(812, 70)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(99, 29)
        Me.SimpleButton7.TabIndex = 5
        Me.SimpleButton7.Text = "Tìm &kiếm"
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(0, 130)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemCheckEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(911, 336)
        Me.TrueDBGrid1.TabIndex = 6
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.X, Me.colDocEntry, Me.TankHeaderCode, Me.colCreateDate, Me.FromDate, Me.ToDate, Me.colClient, Me.colsType, Me.PurposeCode, Me.Type, Me.CreateUser})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "CreateDate desc, Docentry Desc"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "ztblTankHeaderImp_V"
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
        '
        'colDocEntry
        '
        Me.colDocEntry.AllowInsert = True
        Me.colDocEntry.AllowUpdate = True
        Me.colDocEntry.ButtonClick = True
        Me.colDocEntry.Caption = "Số GD"
        Me.colDocEntry.CFLColumnHide = ""
        Me.colDocEntry.CFLKeyField = ""
        Me.colDocEntry.CFLPage = False
        Me.colDocEntry.CFLReturn0 = ""
        Me.colDocEntry.CFLReturn1 = ""
        Me.colDocEntry.CFLReturn2 = ""
        Me.colDocEntry.CFLReturn3 = ""
        Me.colDocEntry.CFLReturn4 = ""
        Me.colDocEntry.CFLReturn5 = ""
        Me.colDocEntry.CFLReturn6 = ""
        Me.colDocEntry.CFLReturn7 = ""
        Me.colDocEntry.CFLShowLoad = False
        Me.colDocEntry.ChangeFormStatus = True
        Me.colDocEntry.ColumnKey = False
        Me.colDocEntry.ComboLine = 5
        Me.colDocEntry.CopyFromItem = ""
        Me.colDocEntry.DefaultButtonClick = False
        Me.colDocEntry.Digit = False
        Me.colDocEntry.FieldType = "N"
        Me.colDocEntry.FieldView = "DocEntry"
        Me.colDocEntry.FormarNumber = True
        Me.colDocEntry.FormList = False
        Me.colDocEntry.KeyInsert = ""
        Me.colDocEntry.LocalDecimal = False
        Me.colDocEntry.Name = "colDocEntry"
        Me.colDocEntry.NoUpdate = ""
        Me.colDocEntry.NumberDecimal = 0
        Me.colDocEntry.OptionsColumn.ReadOnly = True
        Me.colDocEntry.ParentControl = ""
        Me.colDocEntry.RefreshSource = False
        Me.colDocEntry.Required = False
        Me.colDocEntry.SequenceName = ""
        Me.colDocEntry.ShowCalc = True
        Me.colDocEntry.ShowDataTime = False
        Me.colDocEntry.ShowOnlyTime = False
        Me.colDocEntry.SQLString = ""
        Me.colDocEntry.UpdateIfNull = ""
        Me.colDocEntry.UpdateWhenFormLock = False
        Me.colDocEntry.UpperValue = False
        Me.colDocEntry.ValidateValue = True
        Me.colDocEntry.Visible = True
        Me.colDocEntry.VisibleIndex = 1
        '
        'TankHeaderCode
        '
        Me.TankHeaderCode.AllowInsert = True
        Me.TankHeaderCode.AllowUpdate = True
        Me.TankHeaderCode.ButtonClick = True
        Me.TankHeaderCode.Caption = "GridColumn1"
        Me.TankHeaderCode.CFLColumnHide = ""
        Me.TankHeaderCode.CFLKeyField = ""
        Me.TankHeaderCode.CFLPage = False
        Me.TankHeaderCode.CFLReturn0 = ""
        Me.TankHeaderCode.CFLReturn1 = ""
        Me.TankHeaderCode.CFLReturn2 = ""
        Me.TankHeaderCode.CFLReturn3 = ""
        Me.TankHeaderCode.CFLReturn4 = ""
        Me.TankHeaderCode.CFLReturn5 = ""
        Me.TankHeaderCode.CFLReturn6 = ""
        Me.TankHeaderCode.CFLReturn7 = ""
        Me.TankHeaderCode.CFLShowLoad = False
        Me.TankHeaderCode.ChangeFormStatus = True
        Me.TankHeaderCode.ColumnKey = False
        Me.TankHeaderCode.ComboLine = 5
        Me.TankHeaderCode.CopyFromItem = ""
        Me.TankHeaderCode.DefaultButtonClick = False
        Me.TankHeaderCode.Digit = False
        Me.TankHeaderCode.FieldType = "C"
        Me.TankHeaderCode.FieldView = "TankHeaderCode"
        Me.TankHeaderCode.FormarNumber = True
        Me.TankHeaderCode.FormList = False
        Me.TankHeaderCode.KeyInsert = ""
        Me.TankHeaderCode.LocalDecimal = False
        Me.TankHeaderCode.Name = "TankHeaderCode"
        Me.TankHeaderCode.NoUpdate = ""
        Me.TankHeaderCode.NumberDecimal = 0
        Me.TankHeaderCode.OptionsColumn.ReadOnly = True
        Me.TankHeaderCode.ParentControl = ""
        Me.TankHeaderCode.RefreshSource = False
        Me.TankHeaderCode.Required = False
        Me.TankHeaderCode.SequenceName = ""
        Me.TankHeaderCode.ShowCalc = True
        Me.TankHeaderCode.ShowDataTime = False
        Me.TankHeaderCode.ShowOnlyTime = False
        Me.TankHeaderCode.SQLString = ""
        Me.TankHeaderCode.UpdateIfNull = ""
        Me.TankHeaderCode.UpdateWhenFormLock = False
        Me.TankHeaderCode.UpperValue = False
        Me.TankHeaderCode.ValidateValue = True
        Me.TankHeaderCode.Visible = True
        '
        'colCreateDate
        '
        Me.colCreateDate.AllowInsert = True
        Me.colCreateDate.AllowUpdate = True
        Me.colCreateDate.ButtonClick = True
        Me.colCreateDate.Caption = "Ngày tháng"
        Me.colCreateDate.CFLColumnHide = ""
        Me.colCreateDate.CFLKeyField = ""
        Me.colCreateDate.CFLPage = False
        Me.colCreateDate.CFLReturn0 = ""
        Me.colCreateDate.CFLReturn1 = ""
        Me.colCreateDate.CFLReturn2 = ""
        Me.colCreateDate.CFLReturn3 = ""
        Me.colCreateDate.CFLReturn4 = ""
        Me.colCreateDate.CFLReturn5 = ""
        Me.colCreateDate.CFLReturn6 = ""
        Me.colCreateDate.CFLReturn7 = ""
        Me.colCreateDate.CFLShowLoad = False
        Me.colCreateDate.ChangeFormStatus = True
        Me.colCreateDate.ColumnKey = False
        Me.colCreateDate.ComboLine = 5
        Me.colCreateDate.CopyFromItem = ""
        Me.colCreateDate.DefaultButtonClick = False
        Me.colCreateDate.Digit = False
        Me.colCreateDate.FieldType = "D"
        Me.colCreateDate.FieldView = "CreateDate"
        Me.colCreateDate.FormarNumber = True
        Me.colCreateDate.FormList = False
        Me.colCreateDate.KeyInsert = ""
        Me.colCreateDate.LocalDecimal = False
        Me.colCreateDate.Name = "colCreateDate"
        Me.colCreateDate.NoUpdate = ""
        Me.colCreateDate.NumberDecimal = 0
        Me.colCreateDate.OptionsColumn.ReadOnly = True
        Me.colCreateDate.ParentControl = ""
        Me.colCreateDate.RefreshSource = False
        Me.colCreateDate.Required = False
        Me.colCreateDate.SequenceName = ""
        Me.colCreateDate.ShowCalc = True
        Me.colCreateDate.ShowDataTime = False
        Me.colCreateDate.ShowOnlyTime = False
        Me.colCreateDate.SQLString = ""
        Me.colCreateDate.UpdateIfNull = ""
        Me.colCreateDate.UpdateWhenFormLock = False
        Me.colCreateDate.UpperValue = False
        Me.colCreateDate.ValidateValue = True
        Me.colCreateDate.Visible = True
        Me.colCreateDate.VisibleIndex = 2
        Me.colCreateDate.Width = 120
        '
        'FromDate
        '
        Me.FromDate.AllowInsert = True
        Me.FromDate.AllowUpdate = True
        Me.FromDate.ButtonClick = True
        Me.FromDate.Caption = "Ngày giờ"
        Me.FromDate.CFLColumnHide = ""
        Me.FromDate.CFLKeyField = ""
        Me.FromDate.CFLPage = False
        Me.FromDate.CFLReturn0 = ""
        Me.FromDate.CFLReturn1 = ""
        Me.FromDate.CFLReturn2 = ""
        Me.FromDate.CFLReturn3 = ""
        Me.FromDate.CFLReturn4 = ""
        Me.FromDate.CFLReturn5 = ""
        Me.FromDate.CFLReturn6 = ""
        Me.FromDate.CFLReturn7 = ""
        Me.FromDate.CFLShowLoad = False
        Me.FromDate.ChangeFormStatus = True
        Me.FromDate.ColumnKey = False
        Me.FromDate.ComboLine = 5
        Me.FromDate.CopyFromItem = ""
        Me.FromDate.DefaultButtonClick = False
        Me.FromDate.Digit = False
        Me.FromDate.FieldType = "D"
        Me.FromDate.FieldView = "FromDate"
        Me.FromDate.FormarNumber = True
        Me.FromDate.FormList = False
        Me.FromDate.KeyInsert = ""
        Me.FromDate.LocalDecimal = False
        Me.FromDate.Name = "FromDate"
        Me.FromDate.NoUpdate = ""
        Me.FromDate.NumberDecimal = 0
        Me.FromDate.OptionsColumn.ReadOnly = True
        Me.FromDate.ParentControl = ""
        Me.FromDate.RefreshSource = False
        Me.FromDate.Required = False
        Me.FromDate.SequenceName = ""
        Me.FromDate.ShowCalc = True
        Me.FromDate.ShowDataTime = True
        Me.FromDate.ShowOnlyTime = False
        Me.FromDate.SQLString = ""
        Me.FromDate.UpdateIfNull = ""
        Me.FromDate.UpdateWhenFormLock = False
        Me.FromDate.UpperValue = False
        Me.FromDate.ValidateValue = True
        Me.FromDate.Visible = True
        Me.FromDate.VisibleIndex = 3
        Me.FromDate.Width = 220
        '
        'ToDate
        '
        Me.ToDate.AllowInsert = True
        Me.ToDate.AllowUpdate = True
        Me.ToDate.ButtonClick = True
        Me.ToDate.Caption = "GridColumn4"
        Me.ToDate.CFLColumnHide = ""
        Me.ToDate.CFLKeyField = ""
        Me.ToDate.CFLPage = False
        Me.ToDate.CFLReturn0 = ""
        Me.ToDate.CFLReturn1 = ""
        Me.ToDate.CFLReturn2 = ""
        Me.ToDate.CFLReturn3 = ""
        Me.ToDate.CFLReturn4 = ""
        Me.ToDate.CFLReturn5 = ""
        Me.ToDate.CFLReturn6 = ""
        Me.ToDate.CFLReturn7 = ""
        Me.ToDate.CFLShowLoad = False
        Me.ToDate.ChangeFormStatus = True
        Me.ToDate.ColumnKey = False
        Me.ToDate.ComboLine = 5
        Me.ToDate.CopyFromItem = ""
        Me.ToDate.DefaultButtonClick = False
        Me.ToDate.Digit = False
        Me.ToDate.FieldType = "C"
        Me.ToDate.FieldView = ""
        Me.ToDate.FormarNumber = True
        Me.ToDate.FormList = False
        Me.ToDate.KeyInsert = ""
        Me.ToDate.LocalDecimal = False
        Me.ToDate.Name = "ToDate"
        Me.ToDate.NoUpdate = ""
        Me.ToDate.NumberDecimal = 0
        Me.ToDate.OptionsColumn.ReadOnly = True
        Me.ToDate.ParentControl = ""
        Me.ToDate.RefreshSource = False
        Me.ToDate.Required = False
        Me.ToDate.SequenceName = ""
        Me.ToDate.ShowCalc = True
        Me.ToDate.ShowDataTime = False
        Me.ToDate.ShowOnlyTime = False
        Me.ToDate.SQLString = ""
        Me.ToDate.UpdateIfNull = ""
        Me.ToDate.UpdateWhenFormLock = False
        Me.ToDate.UpperValue = False
        Me.ToDate.ValidateValue = True
        Me.ToDate.Visible = True
        '
        'colClient
        '
        Me.colClient.AllowInsert = True
        Me.colClient.AllowUpdate = True
        Me.colClient.ButtonClick = True
        Me.colClient.Caption = "Kho"
        Me.colClient.CFLColumnHide = ""
        Me.colClient.CFLKeyField = ""
        Me.colClient.CFLPage = False
        Me.colClient.CFLReturn0 = ""
        Me.colClient.CFLReturn1 = ""
        Me.colClient.CFLReturn2 = ""
        Me.colClient.CFLReturn3 = ""
        Me.colClient.CFLReturn4 = ""
        Me.colClient.CFLReturn5 = ""
        Me.colClient.CFLReturn6 = ""
        Me.colClient.CFLReturn7 = ""
        Me.colClient.CFLShowLoad = False
        Me.colClient.ChangeFormStatus = True
        Me.colClient.ColumnKey = False
        Me.colClient.ComboLine = 5
        Me.colClient.CopyFromItem = ""
        Me.colClient.DefaultButtonClick = False
        Me.colClient.Digit = False
        Me.colClient.FieldType = "C"
        Me.colClient.FieldView = "Client"
        Me.colClient.FormarNumber = True
        Me.colClient.FormList = False
        Me.colClient.KeyInsert = ""
        Me.colClient.LocalDecimal = False
        Me.colClient.Name = "colClient"
        Me.colClient.NoUpdate = ""
        Me.colClient.NumberDecimal = 0
        Me.colClient.OptionsColumn.ReadOnly = True
        Me.colClient.ParentControl = ""
        Me.colClient.RefreshSource = False
        Me.colClient.Required = False
        Me.colClient.SequenceName = ""
        Me.colClient.ShowCalc = True
        Me.colClient.ShowDataTime = False
        Me.colClient.ShowOnlyTime = False
        Me.colClient.SQLString = ""
        Me.colClient.UpdateIfNull = ""
        Me.colClient.UpdateWhenFormLock = False
        Me.colClient.UpperValue = False
        Me.colClient.ValidateValue = True
        Me.colClient.Visible = True
        Me.colClient.VisibleIndex = 4
        Me.colClient.Width = 60
        '
        'colsType
        '
        Me.colsType.AllowInsert = True
        Me.colsType.AllowUpdate = True
        Me.colsType.ButtonClick = True
        Me.colsType.Caption = "Loại"
        Me.colsType.CFLColumnHide = ""
        Me.colsType.CFLKeyField = ""
        Me.colsType.CFLPage = False
        Me.colsType.CFLReturn0 = ""
        Me.colsType.CFLReturn1 = ""
        Me.colsType.CFLReturn2 = ""
        Me.colsType.CFLReturn3 = ""
        Me.colsType.CFLReturn4 = ""
        Me.colsType.CFLReturn5 = ""
        Me.colsType.CFLReturn6 = ""
        Me.colsType.CFLReturn7 = ""
        Me.colsType.CFLShowLoad = False
        Me.colsType.ChangeFormStatus = True
        Me.colsType.ColumnKey = False
        Me.colsType.ComboLine = 5
        Me.colsType.CopyFromItem = ""
        Me.colsType.DefaultButtonClick = False
        Me.colsType.Digit = False
        Me.colsType.FieldType = "C"
        Me.colsType.FieldView = "sTypeName"
        Me.colsType.FormarNumber = True
        Me.colsType.FormList = False
        Me.colsType.KeyInsert = ""
        Me.colsType.LocalDecimal = False
        Me.colsType.Name = "colsType"
        Me.colsType.NoUpdate = ""
        Me.colsType.NumberDecimal = 0
        Me.colsType.OptionsColumn.ReadOnly = True
        Me.colsType.ParentControl = ""
        Me.colsType.RefreshSource = False
        Me.colsType.Required = False
        Me.colsType.SequenceName = ""
        Me.colsType.ShowCalc = True
        Me.colsType.ShowDataTime = False
        Me.colsType.ShowOnlyTime = False
        Me.colsType.SQLString = "select 'A' as Code , N'Thông tin ATG' as Name Union select 'M' as Code , N'Nhập t" & _
            "ay' as Name"
        Me.colsType.UpdateIfNull = ""
        Me.colsType.UpdateWhenFormLock = False
        Me.colsType.UpperValue = False
        Me.colsType.ValidateValue = True
        Me.colsType.Visible = True
        Me.colsType.VisibleIndex = 5
        Me.colsType.Width = 100
        '
        'PurposeCode
        '
        Me.PurposeCode.AllowInsert = True
        Me.PurposeCode.AllowUpdate = True
        Me.PurposeCode.ButtonClick = True
        Me.PurposeCode.Caption = "Mục đích đo"
        Me.PurposeCode.CFLColumnHide = ""
        Me.PurposeCode.CFLKeyField = ""
        Me.PurposeCode.CFLPage = False
        Me.PurposeCode.CFLReturn0 = ""
        Me.PurposeCode.CFLReturn1 = ""
        Me.PurposeCode.CFLReturn2 = ""
        Me.PurposeCode.CFLReturn3 = ""
        Me.PurposeCode.CFLReturn4 = ""
        Me.PurposeCode.CFLReturn5 = ""
        Me.PurposeCode.CFLReturn6 = ""
        Me.PurposeCode.CFLReturn7 = ""
        Me.PurposeCode.CFLShowLoad = False
        Me.PurposeCode.ChangeFormStatus = True
        Me.PurposeCode.ColumnKey = False
        Me.PurposeCode.ComboLine = 5
        Me.PurposeCode.CopyFromItem = ""
        Me.PurposeCode.DefaultButtonClick = False
        Me.PurposeCode.Digit = False
        Me.PurposeCode.FieldType = "C"
        Me.PurposeCode.FieldView = "PurposeName"
        Me.PurposeCode.FormarNumber = True
        Me.PurposeCode.FormList = False
        Me.PurposeCode.KeyInsert = ""
        Me.PurposeCode.LocalDecimal = False
        Me.PurposeCode.Name = "PurposeCode"
        Me.PurposeCode.NoUpdate = ""
        Me.PurposeCode.NumberDecimal = 0
        Me.PurposeCode.OptionsColumn.ReadOnly = True
        Me.PurposeCode.ParentControl = ""
        Me.PurposeCode.RefreshSource = False
        Me.PurposeCode.Required = False
        Me.PurposeCode.SequenceName = ""
        Me.PurposeCode.ShowCalc = True
        Me.PurposeCode.ShowDataTime = False
        Me.PurposeCode.ShowOnlyTime = False
        Me.PurposeCode.SQLString = ""
        Me.PurposeCode.UpdateIfNull = ""
        Me.PurposeCode.UpdateWhenFormLock = False
        Me.PurposeCode.UpperValue = False
        Me.PurposeCode.ValidateValue = True
        Me.PurposeCode.Visible = True
        Me.PurposeCode.VisibleIndex = 6
        Me.PurposeCode.Width = 250
        '
        'Type
        '
        Me.Type.AllowInsert = True
        Me.Type.AllowUpdate = True
        Me.Type.ButtonClick = True
        Me.Type.Caption = "GridColumn1"
        Me.Type.CFLColumnHide = ""
        Me.Type.CFLKeyField = ""
        Me.Type.CFLPage = False
        Me.Type.CFLReturn0 = ""
        Me.Type.CFLReturn1 = ""
        Me.Type.CFLReturn2 = ""
        Me.Type.CFLReturn3 = ""
        Me.Type.CFLReturn4 = ""
        Me.Type.CFLReturn5 = ""
        Me.Type.CFLReturn6 = ""
        Me.Type.CFLReturn7 = ""
        Me.Type.CFLShowLoad = False
        Me.Type.ChangeFormStatus = True
        Me.Type.ColumnKey = False
        Me.Type.ComboLine = 5
        Me.Type.CopyFromItem = ""
        Me.Type.DefaultButtonClick = False
        Me.Type.Digit = False
        Me.Type.FieldType = "C"
        Me.Type.FieldView = "sType"
        Me.Type.FormarNumber = True
        Me.Type.FormList = False
        Me.Type.KeyInsert = ""
        Me.Type.LocalDecimal = False
        Me.Type.Name = "Type"
        Me.Type.NoUpdate = ""
        Me.Type.NumberDecimal = 0
        Me.Type.OptionsColumn.ReadOnly = True
        Me.Type.ParentControl = ""
        Me.Type.RefreshSource = False
        Me.Type.Required = False
        Me.Type.SequenceName = ""
        Me.Type.ShowCalc = True
        Me.Type.ShowDataTime = False
        Me.Type.ShowOnlyTime = False
        Me.Type.SQLString = ""
        Me.Type.UpdateIfNull = ""
        Me.Type.UpdateWhenFormLock = False
        Me.Type.UpperValue = False
        Me.Type.ValidateValue = True
        Me.Type.Visible = True
        '
        'CreateUser
        '
        Me.CreateUser.AllowInsert = True
        Me.CreateUser.AllowUpdate = True
        Me.CreateUser.ButtonClick = True
        Me.CreateUser.Caption = "User tạo"
        Me.CreateUser.CFLColumnHide = ""
        Me.CreateUser.CFLKeyField = ""
        Me.CreateUser.CFLPage = False
        Me.CreateUser.CFLReturn0 = ""
        Me.CreateUser.CFLReturn1 = ""
        Me.CreateUser.CFLReturn2 = ""
        Me.CreateUser.CFLReturn3 = ""
        Me.CreateUser.CFLReturn4 = ""
        Me.CreateUser.CFLReturn5 = ""
        Me.CreateUser.CFLReturn6 = ""
        Me.CreateUser.CFLReturn7 = ""
        Me.CreateUser.CFLShowLoad = False
        Me.CreateUser.ChangeFormStatus = True
        Me.CreateUser.ColumnKey = False
        Me.CreateUser.ComboLine = 5
        Me.CreateUser.CopyFromItem = ""
        Me.CreateUser.DefaultButtonClick = False
        Me.CreateUser.Digit = False
        Me.CreateUser.FieldType = "C"
        Me.CreateUser.FieldView = "CreateUser"
        Me.CreateUser.FormarNumber = True
        Me.CreateUser.FormList = False
        Me.CreateUser.KeyInsert = ""
        Me.CreateUser.LocalDecimal = False
        Me.CreateUser.Name = "CreateUser"
        Me.CreateUser.NoUpdate = ""
        Me.CreateUser.NumberDecimal = 0
        Me.CreateUser.OptionsColumn.ReadOnly = True
        Me.CreateUser.ParentControl = ""
        Me.CreateUser.RefreshSource = False
        Me.CreateUser.Required = False
        Me.CreateUser.SequenceName = ""
        Me.CreateUser.ShowCalc = True
        Me.CreateUser.ShowDataTime = False
        Me.CreateUser.ShowOnlyTime = False
        Me.CreateUser.SQLString = ""
        Me.CreateUser.UpdateIfNull = ""
        Me.CreateUser.UpdateWhenFormLock = False
        Me.CreateUser.UpperValue = False
        Me.CreateUser.ValidateValue = True
        Me.CreateUser.Visible = True
        Me.CreateUser.VisibleIndex = 7
        Me.CreateUser.Width = 100
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'SoLenh
        '
        Me.SoLenh.AllowInsert = True
        Me.SoLenh.AllowUpdate = True
        Me.SoLenh.AutoKeyFix = ""
        Me.SoLenh.AutoKeyName = ""
        Me.SoLenh.BindingSourceName = ""
        Me.SoLenh.ChangeFormStatus = True
        Me.SoLenh.CopyFromItem = ""
        Me.SoLenh.DefaultValue = ""
        Me.SoLenh.FieldName = ""
        Me.SoLenh.FieldType = "C"
        Me.SoLenh.KeyInsert = ""
        Me.SoLenh.LinkLabel = ""
        Me.SoLenh.Location = New System.Drawing.Point(116, 12)
        Me.SoLenh.Name = "SoLenh"
        Me.SoLenh.NoUpdate = "N"
        Me.SoLenh.PrimaryKey = ""
        Me.SoLenh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SoLenh.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh.Properties.AppearanceFocused.Options.UseFont = True
        Me.SoLenh.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SoLenh.Properties.AutoHeight = False
        Me.SoLenh.Required = ""
        Me.SoLenh.Size = New System.Drawing.Size(120, 26)
        Me.SoLenh.TabIndex = 0
        Me.SoLenh.TableName = ""
        Me.SoLenh.UpdateIfNull = ""
        Me.SoLenh.UpdateWhenFormLock = False
        Me.SoLenh.UpperValue = False
        Me.SoLenh.ViewName = ""
        '
        'SoHD
        '
        Me.SoHD.AllowInsert = True
        Me.SoHD.AllowUpdate = True
        Me.SoHD.AutoKeyFix = ""
        Me.SoHD.AutoKeyName = ""
        Me.SoHD.BindingSourceName = ""
        Me.SoHD.ChangeFormStatus = True
        Me.SoHD.CopyFromItem = ""
        Me.SoHD.DefaultValue = ""
        Me.SoHD.FieldName = ""
        Me.SoHD.FieldType = "C"
        Me.SoHD.KeyInsert = ""
        Me.SoHD.LinkLabel = ""
        Me.SoHD.Location = New System.Drawing.Point(116, 76)
        Me.SoHD.Name = "SoHD"
        Me.SoHD.NoUpdate = "N"
        Me.SoHD.PrimaryKey = ""
        Me.SoHD.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoHD.Properties.Appearance.Options.UseFont = True
        Me.SoHD.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoHD.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SoHD.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoHD.Properties.AppearanceFocused.Options.UseFont = True
        Me.SoHD.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoHD.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SoHD.Properties.AutoHeight = False
        Me.SoHD.Required = ""
        Me.SoHD.Size = New System.Drawing.Size(120, 26)
        Me.SoHD.TabIndex = 516
        Me.SoHD.TableName = ""
        Me.SoHD.UpdateIfNull = ""
        Me.SoHD.UpdateWhenFormLock = False
        Me.SoHD.UpperValue = False
        Me.SoHD.ViewName = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 19)
        Me.Label1.TabIndex = 517
        Me.Label1.Text = "Số HĐ"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(263, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 19)
        Me.Label7.TabIndex = 517
        Me.Label7.Text = "Ký hiệu HĐ"
        '
        'KyHieuHD
        '
        Me.KyHieuHD.AllowInsert = True
        Me.KyHieuHD.AllowUpdate = True
        Me.KyHieuHD.AutoKeyFix = ""
        Me.KyHieuHD.AutoKeyName = ""
        Me.KyHieuHD.BindingSourceName = ""
        Me.KyHieuHD.ChangeFormStatus = True
        Me.KyHieuHD.CopyFromItem = ""
        Me.KyHieuHD.DefaultValue = ""
        Me.KyHieuHD.FieldName = ""
        Me.KyHieuHD.FieldType = "C"
        Me.KyHieuHD.KeyInsert = ""
        Me.KyHieuHD.LinkLabel = ""
        Me.KyHieuHD.Location = New System.Drawing.Point(358, 76)
        Me.KyHieuHD.Name = "KyHieuHD"
        Me.KyHieuHD.NoUpdate = "N"
        Me.KyHieuHD.PrimaryKey = ""
        Me.KyHieuHD.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.KyHieuHD.Properties.Appearance.Options.UseFont = True
        Me.KyHieuHD.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.KyHieuHD.Properties.AppearanceDisabled.Options.UseFont = True
        Me.KyHieuHD.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.KyHieuHD.Properties.AppearanceFocused.Options.UseFont = True
        Me.KyHieuHD.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.KyHieuHD.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.KyHieuHD.Properties.AutoHeight = False
        Me.KyHieuHD.Required = ""
        Me.KyHieuHD.Size = New System.Drawing.Size(124, 26)
        Me.KyHieuHD.TabIndex = 516
        Me.KyHieuHD.TableName = ""
        Me.KyHieuHD.UpdateIfNull = ""
        Me.KyHieuHD.UpdateWhenFormLock = False
        Me.KyHieuHD.UpperValue = False
        Me.KyHieuHD.ViewName = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(504, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 19)
        Me.Label8.TabIndex = 517
        Me.Label8.Text = "Mã tra cứu"
        '
        'txtMaTraCuu
        '
        Me.txtMaTraCuu.AllowInsert = True
        Me.txtMaTraCuu.AllowUpdate = True
        Me.txtMaTraCuu.AutoKeyFix = ""
        Me.txtMaTraCuu.AutoKeyName = ""
        Me.txtMaTraCuu.BindingSourceName = ""
        Me.txtMaTraCuu.ChangeFormStatus = True
        Me.txtMaTraCuu.CopyFromItem = ""
        Me.txtMaTraCuu.DefaultValue = ""
        Me.txtMaTraCuu.FieldName = ""
        Me.txtMaTraCuu.FieldType = "C"
        Me.txtMaTraCuu.KeyInsert = ""
        Me.txtMaTraCuu.LinkLabel = ""
        Me.txtMaTraCuu.Location = New System.Drawing.Point(596, 76)
        Me.txtMaTraCuu.Name = "txtMaTraCuu"
        Me.txtMaTraCuu.NoUpdate = "N"
        Me.txtMaTraCuu.PrimaryKey = ""
        Me.txtMaTraCuu.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtMaTraCuu.Properties.Appearance.Options.UseFont = True
        Me.txtMaTraCuu.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtMaTraCuu.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtMaTraCuu.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtMaTraCuu.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtMaTraCuu.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtMaTraCuu.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtMaTraCuu.Properties.AutoHeight = False
        Me.txtMaTraCuu.Required = ""
        Me.txtMaTraCuu.Size = New System.Drawing.Size(155, 26)
        Me.txtMaTraCuu.TabIndex = 516
        Me.txtMaTraCuu.TableName = ""
        Me.txtMaTraCuu.UpdateIfNull = ""
        Me.txtMaTraCuu.UpdateWhenFormLock = False
        Me.txtMaTraCuu.UpperValue = False
        Me.txtMaTraCuu.ViewName = ""
        '
        'FrmHoaDonQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 466)
        Me.Controls.Add(Me.txtMaTraCuu)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.KyHieuHD)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.SoHD)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SoLenh)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtToDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LoaiHoaDon)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFromDate)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmHoaDonQL"
        Me.Text = "Thông tin Lệnh xuất hóa đơn"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton7, 0)
        Me.Controls.SetChildIndex(Me.txtFromDate, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.LoaiHoaDon, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtToDate, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Status, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.SoLenh, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.SoHD, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.KyHieuHD, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txtMaTraCuu, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Status.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtToDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoaiHoaDon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFromDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoHD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KyHieuHD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaTraCuu.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Status As U_TextBox.U_Combobox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtToDate As U_TextBox.U_DateEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LoaiHoaDon As U_TextBox.U_Combobox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFromDate As U_TextBox.U_DateEdit
    Friend WithEvents SimpleButton7 As U_TextBox.U_ButtonCus
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents X As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents colDocEntry As U_TextBox.GridColumn
    Friend WithEvents TankHeaderCode As U_TextBox.GridColumn
    Friend WithEvents colCreateDate As U_TextBox.GridColumn
    Friend WithEvents FromDate As U_TextBox.GridColumn
    Friend WithEvents ToDate As U_TextBox.GridColumn
    Friend WithEvents colClient As U_TextBox.GridColumn
    Friend WithEvents colsType As U_TextBox.GridColumn
    Friend WithEvents PurposeCode As U_TextBox.GridColumn
    Friend WithEvents Type As U_TextBox.GridColumn
    Friend WithEvents CreateUser As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents SoLenh As U_TextBox.U_TextBox
    Friend WithEvents SoHD As U_TextBox.U_TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents KyHieuHD As U_TextBox.U_TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMaTraCuu As U_TextBox.U_TextBox
End Class
