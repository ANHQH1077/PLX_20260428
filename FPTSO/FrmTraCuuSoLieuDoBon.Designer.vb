<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTraCuuSoLieuDoBon
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
        Me.SimpleButton7 = New U_TextBox.U_ButtonCus(Me.components)
        Me.TankList = New U_TextBox.U_ButtonEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtToDate = New U_TextBox.U_DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFromDate = New U_TextBox.U_DateEdit()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.TankCode = New U_TextBox.GridColumn()
        Me.btnMaBe = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.NhomBeXuat = New U_TextBox.GridColumn()
        Me.FromDate = New U_TextBox.GridColumn()
        Me.TankHeight = New U_TextBox.GridColumn()
        Me.TankTemp = New U_TextBox.GridColumn()
        Me.PurposeCode = New U_TextBox.GridColumn()
        Me.Purposename = New U_TextBox.GridColumn()
        Me.Dens = New U_TextBox.GridColumn()
        Me.Ltt = New U_TextBox.GridColumn()
        Me.VCF = New U_TextBox.GridColumn()
        Me.VolumnL15 = New U_TextBox.GridColumn()
        Me.WCF = New U_TextBox.GridColumn()
        Me.VolumnKG = New U_TextBox.GridColumn()
        Me.sType = New U_TextBox.GridColumn()
        Me.crDate = New U_TextBox.GridColumn()
        Me.SyncUser = New U_TextBox.GridColumn()
        Me.SyncDate = New U_TextBox.GridColumn()
        Me.TankHeaderCode = New U_TextBox.GridColumn()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TankList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtToDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFromDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMaBe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.DefaultUpdate = True
        Me.SimpleButton7.EnableWhenFormLock = True
        Me.SimpleButton7.Location = New System.Drawing.Point(733, 41)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(99, 29)
        Me.SimpleButton7.TabIndex = 3
        Me.SimpleButton7.Text = "Tìm &kiếm"
        '
        'TankList
        '
        Me.TankList.AllowInsert = False
        Me.TankList.AllowUpdate = False
        Me.TankList.AutoWidth = False
        Me.TankList.BindingSourceName = ""
        Me.TankList.ChangeFormStatus = True
        Me.TankList.CopyFromItem = ""
        Me.TankList.DefaultButtonClick = True
        Me.TankList.DefaultValue = ""
        Me.TankList.FieldName = ""
        Me.TankList.FieldType = "C"
        Me.TankList.FormList = False
        Me.TankList.ItemReturn1 = ""
        Me.TankList.ItemReturn2 = ""
        Me.TankList.ItemReturn3 = ""
        Me.TankList.KeyInsert = ""
        Me.TankList.LinkLabel = ""
        Me.TankList.Location = New System.Drawing.Point(120, 12)
        Me.TankList.MultiSelect = True
        Me.TankList.Name = "TankList"
        Me.TankList.NoUpdate = "N"
        Me.TankList.OrderbyEx = ""
        Me.TankList.PrimaryKey = ""
        Me.TankList.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankList.Properties.Appearance.Options.UseFont = True
        Me.TankList.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankList.Properties.AppearanceDisabled.Options.UseFont = True
        Me.TankList.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankList.Properties.AppearanceFocused.Options.UseFont = True
        Me.TankList.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankList.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.TankList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TankList.Required = ""
        Me.TankList.ShowLoad = True
        Me.TankList.Size = New System.Drawing.Size(253, 26)
        Me.TankList.SqlFielKey = "Name_nd"
        Me.TankList.SqlString = ""
        Me.TankList.TabIndex = 0
        Me.TankList.TableName = ""
        Me.TankList.UpdateIfNull = ""
        Me.TankList.UpdateWhenFormLock = False
        Me.TankList.UpperValue = True
        Me.TankList.ValidateValue = False
        Me.TankList.ViewName = "ztblTankHeaderImp_v"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(36, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 19)
        Me.Label9.TabIndex = 496
        Me.Label9.Text = "Mã bể"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(387, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 19)
        Me.Label5.TabIndex = 512
        Me.Label5.Text = "Đến ngày"
        '
        'txtToDate
        '
        Me.txtToDate.AllowInsert = True
        Me.txtToDate.AllowUpdate = True
        Me.txtToDate.BindingSourceName = ""
        Me.txtToDate.ChangeFormStatus = True
        Me.txtToDate.CopyFromItem = ""
        Me.txtToDate.DefaultValue = ""
        Me.txtToDate.EditValue = Nothing
        Me.txtToDate.FieldName = ""
        Me.txtToDate.FieldType = "D"
        Me.txtToDate.KeyInsert = ""
        Me.txtToDate.LinkLabel = "Label2"
        Me.txtToDate.Location = New System.Drawing.Point(488, 44)
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
        Me.txtToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.txtToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtToDate.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss"
        Me.txtToDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtToDate.Required = "N"
        Me.txtToDate.ShowDateTime = False
        Me.txtToDate.Size = New System.Drawing.Size(239, 26)
        Me.txtToDate.TabIndex = 511
        Me.txtToDate.TableName = ""
        Me.txtToDate.TabStop = False
        Me.txtToDate.UpdateIfNull = ""
        Me.txtToDate.UpdateWhenFormLock = False
        Me.txtToDate.ViewName = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 47)
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
        Me.txtFromDate.ChangeFormStatus = True
        Me.txtFromDate.CopyFromItem = ""
        Me.txtFromDate.DefaultValue = ""
        Me.txtFromDate.EditValue = Nothing
        Me.txtFromDate.FieldName = ""
        Me.txtFromDate.FieldType = "D"
        Me.txtFromDate.KeyInsert = ""
        Me.txtFromDate.LinkLabel = "Label2"
        Me.txtFromDate.Location = New System.Drawing.Point(120, 43)
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
        Me.txtFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.txtFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtFromDate.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss"
        Me.txtFromDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtFromDate.Required = "N"
        Me.txtFromDate.ShowDateTime = False
        Me.txtFromDate.Size = New System.Drawing.Size(253, 26)
        Me.txtFromDate.TabIndex = 508
        Me.txtFromDate.TableName = ""
        Me.txtFromDate.TabStop = False
        Me.txtFromDate.UpdateIfNull = ""
        Me.txtFromDate.UpdateWhenFormLock = False
        Me.txtFromDate.ViewName = ""
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(0, 76)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.btnMaBe})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(1093, 403)
        Me.TrueDBGrid1.TabIndex = 513
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.GridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.CheckUpd = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TankCode, Me.FromDate, Me.TankHeight, Me.TankTemp, Me.PurposeCode, Me.Purposename, Me.Dens, Me.Ltt, Me.VCF, Me.VolumnL15, Me.WCF, Me.VolumnKG, Me.sType, Me.crDate, Me.SyncUser, Me.SyncDate, Me.TankHeaderCode, Me.NhomBeXuat})
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
        'TankCode
        '
        Me.TankCode.AllowInsert = True
        Me.TankCode.AllowUpdate = True
        Me.TankCode.ButtonClick = True
        Me.TankCode.Caption = "Mã bể"
        Me.TankCode.CFLColumnHide = ""
        Me.TankCode.CFLKeyField = "MaBe"
        Me.TankCode.CFLPage = False
        Me.TankCode.CFLReturn0 = "TankCode"
        Me.TankCode.CFLReturn1 = ""
        Me.TankCode.CFLReturn2 = ""
        Me.TankCode.CFLReturn3 = ""
        Me.TankCode.CFLReturn4 = ""
        Me.TankCode.CFLReturn5 = ""
        Me.TankCode.CFLReturn6 = ""
        Me.TankCode.CFLReturn7 = ""
        Me.TankCode.CFLShowLoad = True
        Me.TankCode.ChangeFormStatus = True
        Me.TankCode.ColumnEdit = Me.btnMaBe
        Me.TankCode.ColumnKey = False
        Me.TankCode.ComboLine = 5
        Me.TankCode.CopyFromItem = ""
        Me.TankCode.DefaultButtonClick = False
        Me.TankCode.Digit = False
        Me.TankCode.FieldType = "C"
        Me.TankCode.FieldView = ""
        Me.TankCode.FormarNumber = True
        Me.TankCode.FormList = False
        Me.TankCode.KeyInsert = ""
        Me.TankCode.LocalDecimal = False
        Me.TankCode.Name = "TankCode"
        Me.TankCode.NoUpdate = ""
        Me.TankCode.NumberDecimal = 0
        Me.TankCode.ParentControl = ""
        Me.TankCode.RefreshSource = False
        Me.TankCode.Required = False
        Me.TankCode.SequenceName = ""
        Me.TankCode.ShowCalc = True
        Me.TankCode.ShowDataTime = False
        Me.TankCode.ShowOnlyTime = False
        Me.TankCode.SQLString = ""
        Me.TankCode.UpdateIfNull = ""
        Me.TankCode.UpdateWhenFormLock = False
        Me.TankCode.UpperValue = False
        Me.TankCode.ValidateValue = True
        Me.TankCode.Visible = True
        Me.TankCode.VisibleIndex = 0
        '
        'btnMaBe
        '
        Me.btnMaBe.AutoHeight = False
        Me.btnMaBe.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.btnMaBe.Name = "btnMaBe"
        '
        'NhomBeXuat
        '
        Me.NhomBeXuat.AllowInsert = True
        Me.NhomBeXuat.AllowUpdate = True
        Me.NhomBeXuat.ButtonClick = True
        Me.NhomBeXuat.Caption = "Nhóm bể"
        Me.NhomBeXuat.CFLColumnHide = ""
        Me.NhomBeXuat.CFLKeyField = ""
        Me.NhomBeXuat.CFLPage = False
        Me.NhomBeXuat.CFLReturn0 = ""
        Me.NhomBeXuat.CFLReturn1 = ""
        Me.NhomBeXuat.CFLReturn2 = ""
        Me.NhomBeXuat.CFLReturn3 = ""
        Me.NhomBeXuat.CFLReturn4 = ""
        Me.NhomBeXuat.CFLReturn5 = ""
        Me.NhomBeXuat.CFLReturn6 = ""
        Me.NhomBeXuat.CFLReturn7 = ""
        Me.NhomBeXuat.CFLShowLoad = False
        Me.NhomBeXuat.ChangeFormStatus = True
        Me.NhomBeXuat.ColumnKey = False
        Me.NhomBeXuat.ComboLine = 5
        Me.NhomBeXuat.CopyFromItem = ""
        Me.NhomBeXuat.DefaultButtonClick = False
        Me.NhomBeXuat.Digit = False
        Me.NhomBeXuat.FieldType = "C"
        Me.NhomBeXuat.FieldView = ""
        Me.NhomBeXuat.FormarNumber = True
        Me.NhomBeXuat.FormList = False
        Me.NhomBeXuat.KeyInsert = ""
        Me.NhomBeXuat.LocalDecimal = False
        Me.NhomBeXuat.Name = "NhomBeXuat"
        Me.NhomBeXuat.NoUpdate = ""
        Me.NhomBeXuat.NumberDecimal = 0
        Me.NhomBeXuat.OptionsColumn.ReadOnly = True
        Me.NhomBeXuat.ParentControl = ""
        Me.NhomBeXuat.RefreshSource = False
        Me.NhomBeXuat.Required = False
        Me.NhomBeXuat.SequenceName = ""
        Me.NhomBeXuat.ShowCalc = True
        Me.NhomBeXuat.ShowDataTime = False
        Me.NhomBeXuat.ShowOnlyTime = False
        Me.NhomBeXuat.SQLString = ""
        Me.NhomBeXuat.UpdateIfNull = ""
        Me.NhomBeXuat.UpdateWhenFormLock = False
        Me.NhomBeXuat.UpperValue = False
        Me.NhomBeXuat.ValidateValue = True
        Me.NhomBeXuat.Visible = True
        Me.NhomBeXuat.VisibleIndex = 16
        Me.NhomBeXuat.Width = 100
        '
        'FromDate
        '
        Me.FromDate.AllowInsert = True
        Me.FromDate.AllowUpdate = True
        Me.FromDate.ButtonClick = True
        Me.FromDate.Caption = "Thời gian đo bồn"
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
        Me.FromDate.FieldView = ""
        Me.FromDate.FormarNumber = True
        Me.FromDate.FormList = False
        Me.FromDate.KeyInsert = ""
        Me.FromDate.LocalDecimal = False
        Me.FromDate.Name = "FromDate"
        Me.FromDate.NoUpdate = ""
        Me.FromDate.NumberDecimal = 0
        Me.FromDate.ParentControl = ""
        Me.FromDate.RefreshSource = False
        Me.FromDate.Required = False
        Me.FromDate.SequenceName = ""
        Me.FromDate.ShowCalc = True
        Me.FromDate.ShowDataTime = False
        Me.FromDate.ShowOnlyTime = False
        Me.FromDate.SQLString = ""
        Me.FromDate.UpdateIfNull = ""
        Me.FromDate.UpdateWhenFormLock = False
        Me.FromDate.UpperValue = False
        Me.FromDate.ValidateValue = True
        Me.FromDate.Visible = True
        Me.FromDate.VisibleIndex = 1
        Me.FromDate.Width = 200
        '
        'TankHeight
        '
        Me.TankHeight.AllowInsert = True
        Me.TankHeight.AllowUpdate = True
        Me.TankHeight.ButtonClick = True
        Me.TankHeight.Caption = "Chiều cao dầu"
        Me.TankHeight.CFLColumnHide = ""
        Me.TankHeight.CFLKeyField = ""
        Me.TankHeight.CFLPage = False
        Me.TankHeight.CFLReturn0 = ""
        Me.TankHeight.CFLReturn1 = ""
        Me.TankHeight.CFLReturn2 = ""
        Me.TankHeight.CFLReturn3 = ""
        Me.TankHeight.CFLReturn4 = ""
        Me.TankHeight.CFLReturn5 = ""
        Me.TankHeight.CFLReturn6 = ""
        Me.TankHeight.CFLReturn7 = ""
        Me.TankHeight.CFLShowLoad = False
        Me.TankHeight.ChangeFormStatus = True
        Me.TankHeight.ColumnKey = False
        Me.TankHeight.ComboLine = 5
        Me.TankHeight.CopyFromItem = ""
        Me.TankHeight.DefaultButtonClick = False
        Me.TankHeight.Digit = False
        Me.TankHeight.FieldType = "C"
        Me.TankHeight.FieldView = ""
        Me.TankHeight.FormarNumber = True
        Me.TankHeight.FormList = False
        Me.TankHeight.KeyInsert = ""
        Me.TankHeight.LocalDecimal = False
        Me.TankHeight.Name = "TankHeight"
        Me.TankHeight.NoUpdate = ""
        Me.TankHeight.NumberDecimal = 0
        Me.TankHeight.ParentControl = ""
        Me.TankHeight.RefreshSource = False
        Me.TankHeight.Required = False
        Me.TankHeight.SequenceName = ""
        Me.TankHeight.ShowCalc = True
        Me.TankHeight.ShowDataTime = False
        Me.TankHeight.ShowOnlyTime = False
        Me.TankHeight.SQLString = ""
        Me.TankHeight.UpdateIfNull = ""
        Me.TankHeight.UpdateWhenFormLock = False
        Me.TankHeight.UpperValue = False
        Me.TankHeight.ValidateValue = True
        Me.TankHeight.Visible = True
        Me.TankHeight.VisibleIndex = 2
        Me.TankHeight.Width = 120
        '
        'TankTemp
        '
        Me.TankTemp.AllowInsert = True
        Me.TankTemp.AllowUpdate = True
        Me.TankTemp.ButtonClick = True
        Me.TankTemp.Caption = "Nhiệt độ"
        Me.TankTemp.CFLColumnHide = ""
        Me.TankTemp.CFLKeyField = ""
        Me.TankTemp.CFLPage = False
        Me.TankTemp.CFLReturn0 = ""
        Me.TankTemp.CFLReturn1 = ""
        Me.TankTemp.CFLReturn2 = ""
        Me.TankTemp.CFLReturn3 = ""
        Me.TankTemp.CFLReturn4 = ""
        Me.TankTemp.CFLReturn5 = ""
        Me.TankTemp.CFLReturn6 = ""
        Me.TankTemp.CFLReturn7 = ""
        Me.TankTemp.CFLShowLoad = False
        Me.TankTemp.ChangeFormStatus = True
        Me.TankTemp.ColumnKey = False
        Me.TankTemp.ComboLine = 5
        Me.TankTemp.CopyFromItem = ""
        Me.TankTemp.DefaultButtonClick = False
        Me.TankTemp.Digit = False
        Me.TankTemp.FieldType = "C"
        Me.TankTemp.FieldView = ""
        Me.TankTemp.FormarNumber = True
        Me.TankTemp.FormList = False
        Me.TankTemp.KeyInsert = ""
        Me.TankTemp.LocalDecimal = False
        Me.TankTemp.Name = "TankTemp"
        Me.TankTemp.NoUpdate = ""
        Me.TankTemp.NumberDecimal = 0
        Me.TankTemp.ParentControl = ""
        Me.TankTemp.RefreshSource = False
        Me.TankTemp.Required = False
        Me.TankTemp.SequenceName = ""
        Me.TankTemp.ShowCalc = True
        Me.TankTemp.ShowDataTime = False
        Me.TankTemp.ShowOnlyTime = False
        Me.TankTemp.SQLString = ""
        Me.TankTemp.UpdateIfNull = ""
        Me.TankTemp.UpdateWhenFormLock = False
        Me.TankTemp.UpperValue = False
        Me.TankTemp.ValidateValue = True
        Me.TankTemp.Visible = True
        Me.TankTemp.VisibleIndex = 3
        '
        'PurposeCode
        '
        Me.PurposeCode.AllowInsert = True
        Me.PurposeCode.AllowUpdate = True
        Me.PurposeCode.ButtonClick = True
        Me.PurposeCode.Caption = "Mã MDD"
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
        Me.PurposeCode.FieldView = ""
        Me.PurposeCode.FormarNumber = True
        Me.PurposeCode.FormList = False
        Me.PurposeCode.KeyInsert = ""
        Me.PurposeCode.LocalDecimal = False
        Me.PurposeCode.Name = "PurposeCode"
        Me.PurposeCode.NoUpdate = ""
        Me.PurposeCode.NumberDecimal = 0
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
        Me.PurposeCode.VisibleIndex = 4
        '
        'Purposename
        '
        Me.Purposename.AllowInsert = True
        Me.Purposename.AllowUpdate = True
        Me.Purposename.ButtonClick = True
        Me.Purposename.Caption = "Tên MDD"
        Me.Purposename.CFLColumnHide = ""
        Me.Purposename.CFLKeyField = ""
        Me.Purposename.CFLPage = False
        Me.Purposename.CFLReturn0 = ""
        Me.Purposename.CFLReturn1 = ""
        Me.Purposename.CFLReturn2 = ""
        Me.Purposename.CFLReturn3 = ""
        Me.Purposename.CFLReturn4 = ""
        Me.Purposename.CFLReturn5 = ""
        Me.Purposename.CFLReturn6 = ""
        Me.Purposename.CFLReturn7 = ""
        Me.Purposename.CFLShowLoad = False
        Me.Purposename.ChangeFormStatus = True
        Me.Purposename.ColumnKey = False
        Me.Purposename.ComboLine = 5
        Me.Purposename.CopyFromItem = ""
        Me.Purposename.DefaultButtonClick = False
        Me.Purposename.Digit = False
        Me.Purposename.FieldType = "C"
        Me.Purposename.FieldView = ""
        Me.Purposename.FormarNumber = True
        Me.Purposename.FormList = False
        Me.Purposename.KeyInsert = ""
        Me.Purposename.LocalDecimal = False
        Me.Purposename.Name = "Purposename"
        Me.Purposename.NoUpdate = ""
        Me.Purposename.NumberDecimal = 0
        Me.Purposename.ParentControl = ""
        Me.Purposename.RefreshSource = False
        Me.Purposename.Required = False
        Me.Purposename.SequenceName = ""
        Me.Purposename.ShowCalc = True
        Me.Purposename.ShowDataTime = False
        Me.Purposename.ShowOnlyTime = False
        Me.Purposename.SQLString = ""
        Me.Purposename.UpdateIfNull = ""
        Me.Purposename.UpdateWhenFormLock = False
        Me.Purposename.UpperValue = False
        Me.Purposename.ValidateValue = True
        Me.Purposename.Visible = True
        Me.Purposename.VisibleIndex = 5
        '
        'Dens
        '
        Me.Dens.AllowInsert = True
        Me.Dens.AllowUpdate = True
        Me.Dens.ButtonClick = True
        Me.Dens.Caption = "Tỷ trọng"
        Me.Dens.CFLColumnHide = ""
        Me.Dens.CFLKeyField = ""
        Me.Dens.CFLPage = False
        Me.Dens.CFLReturn0 = ""
        Me.Dens.CFLReturn1 = ""
        Me.Dens.CFLReturn2 = ""
        Me.Dens.CFLReturn3 = ""
        Me.Dens.CFLReturn4 = ""
        Me.Dens.CFLReturn5 = ""
        Me.Dens.CFLReturn6 = ""
        Me.Dens.CFLReturn7 = ""
        Me.Dens.CFLShowLoad = False
        Me.Dens.ChangeFormStatus = True
        Me.Dens.ColumnKey = False
        Me.Dens.ComboLine = 5
        Me.Dens.CopyFromItem = ""
        Me.Dens.DefaultButtonClick = False
        Me.Dens.Digit = False
        Me.Dens.FieldType = "C"
        Me.Dens.FieldView = ""
        Me.Dens.FormarNumber = True
        Me.Dens.FormList = False
        Me.Dens.KeyInsert = ""
        Me.Dens.LocalDecimal = False
        Me.Dens.Name = "Dens"
        Me.Dens.NoUpdate = ""
        Me.Dens.NumberDecimal = 0
        Me.Dens.ParentControl = ""
        Me.Dens.RefreshSource = False
        Me.Dens.Required = False
        Me.Dens.SequenceName = ""
        Me.Dens.ShowCalc = True
        Me.Dens.ShowDataTime = False
        Me.Dens.ShowOnlyTime = False
        Me.Dens.SQLString = ""
        Me.Dens.UpdateIfNull = ""
        Me.Dens.UpdateWhenFormLock = False
        Me.Dens.UpperValue = False
        Me.Dens.ValidateValue = True
        Me.Dens.Visible = True
        Me.Dens.VisibleIndex = 6
        '
        'Ltt
        '
        Me.Ltt.AllowInsert = True
        Me.Ltt.AllowUpdate = True
        Me.Ltt.ButtonClick = True
        Me.Ltt.Caption = "Ltt"
        Me.Ltt.CFLColumnHide = ""
        Me.Ltt.CFLKeyField = ""
        Me.Ltt.CFLPage = False
        Me.Ltt.CFLReturn0 = ""
        Me.Ltt.CFLReturn1 = ""
        Me.Ltt.CFLReturn2 = ""
        Me.Ltt.CFLReturn3 = ""
        Me.Ltt.CFLReturn4 = ""
        Me.Ltt.CFLReturn5 = ""
        Me.Ltt.CFLReturn6 = ""
        Me.Ltt.CFLReturn7 = ""
        Me.Ltt.CFLShowLoad = False
        Me.Ltt.ChangeFormStatus = True
        Me.Ltt.ColumnKey = False
        Me.Ltt.ComboLine = 5
        Me.Ltt.CopyFromItem = ""
        Me.Ltt.DefaultButtonClick = False
        Me.Ltt.Digit = False
        Me.Ltt.FieldType = "C"
        Me.Ltt.FieldView = ""
        Me.Ltt.FormarNumber = True
        Me.Ltt.FormList = False
        Me.Ltt.KeyInsert = ""
        Me.Ltt.LocalDecimal = False
        Me.Ltt.Name = "Ltt"
        Me.Ltt.NoUpdate = ""
        Me.Ltt.NumberDecimal = 0
        Me.Ltt.ParentControl = ""
        Me.Ltt.RefreshSource = False
        Me.Ltt.Required = False
        Me.Ltt.SequenceName = ""
        Me.Ltt.ShowCalc = True
        Me.Ltt.ShowDataTime = False
        Me.Ltt.ShowOnlyTime = False
        Me.Ltt.SQLString = ""
        Me.Ltt.UpdateIfNull = ""
        Me.Ltt.UpdateWhenFormLock = False
        Me.Ltt.UpperValue = False
        Me.Ltt.ValidateValue = True
        Me.Ltt.Visible = True
        Me.Ltt.VisibleIndex = 7
        Me.Ltt.Width = 90
        '
        'VCF
        '
        Me.VCF.AllowInsert = True
        Me.VCF.AllowUpdate = True
        Me.VCF.ButtonClick = True
        Me.VCF.Caption = "VCF"
        Me.VCF.CFLColumnHide = ""
        Me.VCF.CFLKeyField = ""
        Me.VCF.CFLPage = False
        Me.VCF.CFLReturn0 = ""
        Me.VCF.CFLReturn1 = ""
        Me.VCF.CFLReturn2 = ""
        Me.VCF.CFLReturn3 = ""
        Me.VCF.CFLReturn4 = ""
        Me.VCF.CFLReturn5 = ""
        Me.VCF.CFLReturn6 = ""
        Me.VCF.CFLReturn7 = ""
        Me.VCF.CFLShowLoad = False
        Me.VCF.ChangeFormStatus = True
        Me.VCF.ColumnKey = False
        Me.VCF.ComboLine = 5
        Me.VCF.CopyFromItem = ""
        Me.VCF.DefaultButtonClick = False
        Me.VCF.Digit = False
        Me.VCF.FieldType = "C"
        Me.VCF.FieldView = ""
        Me.VCF.FormarNumber = True
        Me.VCF.FormList = False
        Me.VCF.KeyInsert = ""
        Me.VCF.LocalDecimal = False
        Me.VCF.Name = "VCF"
        Me.VCF.NoUpdate = ""
        Me.VCF.NumberDecimal = 0
        Me.VCF.ParentControl = ""
        Me.VCF.RefreshSource = False
        Me.VCF.Required = False
        Me.VCF.SequenceName = ""
        Me.VCF.ShowCalc = True
        Me.VCF.ShowDataTime = False
        Me.VCF.ShowOnlyTime = False
        Me.VCF.SQLString = ""
        Me.VCF.UpdateIfNull = ""
        Me.VCF.UpdateWhenFormLock = False
        Me.VCF.UpperValue = False
        Me.VCF.ValidateValue = True
        Me.VCF.Visible = True
        Me.VCF.VisibleIndex = 8
        Me.VCF.Width = 60
        '
        'VolumnL15
        '
        Me.VolumnL15.AllowInsert = True
        Me.VolumnL15.AllowUpdate = True
        Me.VolumnL15.ButtonClick = True
        Me.VolumnL15.Caption = "L15"
        Me.VolumnL15.CFLColumnHide = ""
        Me.VolumnL15.CFLKeyField = ""
        Me.VolumnL15.CFLPage = False
        Me.VolumnL15.CFLReturn0 = ""
        Me.VolumnL15.CFLReturn1 = ""
        Me.VolumnL15.CFLReturn2 = ""
        Me.VolumnL15.CFLReturn3 = ""
        Me.VolumnL15.CFLReturn4 = ""
        Me.VolumnL15.CFLReturn5 = ""
        Me.VolumnL15.CFLReturn6 = ""
        Me.VolumnL15.CFLReturn7 = ""
        Me.VolumnL15.CFLShowLoad = False
        Me.VolumnL15.ChangeFormStatus = True
        Me.VolumnL15.ColumnKey = False
        Me.VolumnL15.ComboLine = 5
        Me.VolumnL15.CopyFromItem = ""
        Me.VolumnL15.DefaultButtonClick = False
        Me.VolumnL15.Digit = False
        Me.VolumnL15.FieldType = "C"
        Me.VolumnL15.FieldView = ""
        Me.VolumnL15.FormarNumber = True
        Me.VolumnL15.FormList = False
        Me.VolumnL15.KeyInsert = ""
        Me.VolumnL15.LocalDecimal = False
        Me.VolumnL15.Name = "VolumnL15"
        Me.VolumnL15.NoUpdate = ""
        Me.VolumnL15.NumberDecimal = 0
        Me.VolumnL15.ParentControl = ""
        Me.VolumnL15.RefreshSource = False
        Me.VolumnL15.Required = False
        Me.VolumnL15.SequenceName = ""
        Me.VolumnL15.ShowCalc = True
        Me.VolumnL15.ShowDataTime = False
        Me.VolumnL15.ShowOnlyTime = False
        Me.VolumnL15.SQLString = ""
        Me.VolumnL15.UpdateIfNull = ""
        Me.VolumnL15.UpdateWhenFormLock = False
        Me.VolumnL15.UpperValue = False
        Me.VolumnL15.ValidateValue = True
        Me.VolumnL15.Visible = True
        Me.VolumnL15.VisibleIndex = 9
        Me.VolumnL15.Width = 90
        '
        'WCF
        '
        Me.WCF.AllowInsert = True
        Me.WCF.AllowUpdate = True
        Me.WCF.ButtonClick = True
        Me.WCF.Caption = "WCF"
        Me.WCF.CFLColumnHide = ""
        Me.WCF.CFLKeyField = ""
        Me.WCF.CFLPage = False
        Me.WCF.CFLReturn0 = ""
        Me.WCF.CFLReturn1 = ""
        Me.WCF.CFLReturn2 = ""
        Me.WCF.CFLReturn3 = ""
        Me.WCF.CFLReturn4 = ""
        Me.WCF.CFLReturn5 = ""
        Me.WCF.CFLReturn6 = ""
        Me.WCF.CFLReturn7 = ""
        Me.WCF.CFLShowLoad = False
        Me.WCF.ChangeFormStatus = True
        Me.WCF.ColumnKey = False
        Me.WCF.ComboLine = 5
        Me.WCF.CopyFromItem = ""
        Me.WCF.DefaultButtonClick = False
        Me.WCF.Digit = False
        Me.WCF.FieldType = "C"
        Me.WCF.FieldView = ""
        Me.WCF.FormarNumber = True
        Me.WCF.FormList = False
        Me.WCF.KeyInsert = ""
        Me.WCF.LocalDecimal = False
        Me.WCF.Name = "WCF"
        Me.WCF.NoUpdate = ""
        Me.WCF.NumberDecimal = 0
        Me.WCF.ParentControl = ""
        Me.WCF.RefreshSource = False
        Me.WCF.Required = False
        Me.WCF.SequenceName = ""
        Me.WCF.ShowCalc = True
        Me.WCF.ShowDataTime = False
        Me.WCF.ShowOnlyTime = False
        Me.WCF.SQLString = ""
        Me.WCF.UpdateIfNull = ""
        Me.WCF.UpdateWhenFormLock = False
        Me.WCF.UpperValue = False
        Me.WCF.ValidateValue = True
        Me.WCF.Visible = True
        Me.WCF.VisibleIndex = 10
        Me.WCF.Width = 60
        '
        'VolumnKG
        '
        Me.VolumnKG.AllowInsert = True
        Me.VolumnKG.AllowUpdate = True
        Me.VolumnKG.ButtonClick = True
        Me.VolumnKG.Caption = "KG"
        Me.VolumnKG.CFLColumnHide = ""
        Me.VolumnKG.CFLKeyField = ""
        Me.VolumnKG.CFLPage = False
        Me.VolumnKG.CFLReturn0 = ""
        Me.VolumnKG.CFLReturn1 = ""
        Me.VolumnKG.CFLReturn2 = ""
        Me.VolumnKG.CFLReturn3 = ""
        Me.VolumnKG.CFLReturn4 = ""
        Me.VolumnKG.CFLReturn5 = ""
        Me.VolumnKG.CFLReturn6 = ""
        Me.VolumnKG.CFLReturn7 = ""
        Me.VolumnKG.CFLShowLoad = False
        Me.VolumnKG.ChangeFormStatus = True
        Me.VolumnKG.ColumnKey = False
        Me.VolumnKG.ComboLine = 5
        Me.VolumnKG.CopyFromItem = ""
        Me.VolumnKG.DefaultButtonClick = False
        Me.VolumnKG.Digit = False
        Me.VolumnKG.FieldType = "C"
        Me.VolumnKG.FieldView = ""
        Me.VolumnKG.FormarNumber = True
        Me.VolumnKG.FormList = False
        Me.VolumnKG.KeyInsert = ""
        Me.VolumnKG.LocalDecimal = False
        Me.VolumnKG.Name = "VolumnKG"
        Me.VolumnKG.NoUpdate = ""
        Me.VolumnKG.NumberDecimal = 0
        Me.VolumnKG.ParentControl = ""
        Me.VolumnKG.RefreshSource = False
        Me.VolumnKG.Required = False
        Me.VolumnKG.SequenceName = ""
        Me.VolumnKG.ShowCalc = True
        Me.VolumnKG.ShowDataTime = False
        Me.VolumnKG.ShowOnlyTime = False
        Me.VolumnKG.SQLString = ""
        Me.VolumnKG.UpdateIfNull = ""
        Me.VolumnKG.UpdateWhenFormLock = False
        Me.VolumnKG.UpperValue = False
        Me.VolumnKG.ValidateValue = True
        Me.VolumnKG.Visible = True
        Me.VolumnKG.VisibleIndex = 11
        Me.VolumnKG.Width = 90
        '
        'sType
        '
        Me.sType.AllowInsert = True
        Me.sType.AllowUpdate = True
        Me.sType.ButtonClick = True
        Me.sType.Caption = "Loại"
        Me.sType.CFLColumnHide = ""
        Me.sType.CFLKeyField = ""
        Me.sType.CFLPage = False
        Me.sType.CFLReturn0 = ""
        Me.sType.CFLReturn1 = ""
        Me.sType.CFLReturn2 = ""
        Me.sType.CFLReturn3 = ""
        Me.sType.CFLReturn4 = ""
        Me.sType.CFLReturn5 = ""
        Me.sType.CFLReturn6 = ""
        Me.sType.CFLReturn7 = ""
        Me.sType.CFLShowLoad = False
        Me.sType.ChangeFormStatus = True
        Me.sType.ColumnKey = False
        Me.sType.ComboLine = 5
        Me.sType.CopyFromItem = ""
        Me.sType.DefaultButtonClick = False
        Me.sType.Digit = False
        Me.sType.FieldType = "C"
        Me.sType.FieldView = ""
        Me.sType.FormarNumber = True
        Me.sType.FormList = False
        Me.sType.KeyInsert = ""
        Me.sType.LocalDecimal = False
        Me.sType.Name = "sType"
        Me.sType.NoUpdate = ""
        Me.sType.NumberDecimal = 0
        Me.sType.ParentControl = ""
        Me.sType.RefreshSource = False
        Me.sType.Required = False
        Me.sType.SequenceName = ""
        Me.sType.ShowCalc = True
        Me.sType.ShowDataTime = False
        Me.sType.ShowOnlyTime = False
        Me.sType.SQLString = ""
        Me.sType.UpdateIfNull = ""
        Me.sType.UpdateWhenFormLock = False
        Me.sType.UpperValue = False
        Me.sType.ValidateValue = True
        Me.sType.Visible = True
        Me.sType.VisibleIndex = 12
        '
        'crDate
        '
        Me.crDate.AllowInsert = True
        Me.crDate.AllowUpdate = True
        Me.crDate.ButtonClick = True
        Me.crDate.Caption = "Thời gian tạo giao dịch"
        Me.crDate.CFLColumnHide = ""
        Me.crDate.CFLKeyField = ""
        Me.crDate.CFLPage = False
        Me.crDate.CFLReturn0 = ""
        Me.crDate.CFLReturn1 = ""
        Me.crDate.CFLReturn2 = ""
        Me.crDate.CFLReturn3 = ""
        Me.crDate.CFLReturn4 = ""
        Me.crDate.CFLReturn5 = ""
        Me.crDate.CFLReturn6 = ""
        Me.crDate.CFLReturn7 = ""
        Me.crDate.CFLShowLoad = False
        Me.crDate.ChangeFormStatus = True
        Me.crDate.ColumnKey = False
        Me.crDate.ComboLine = 5
        Me.crDate.CopyFromItem = ""
        Me.crDate.DefaultButtonClick = False
        Me.crDate.Digit = False
        Me.crDate.FieldType = "C"
        Me.crDate.FieldView = ""
        Me.crDate.FormarNumber = True
        Me.crDate.FormList = False
        Me.crDate.KeyInsert = ""
        Me.crDate.LocalDecimal = False
        Me.crDate.Name = "crDate"
        Me.crDate.NoUpdate = ""
        Me.crDate.NumberDecimal = 0
        Me.crDate.ParentControl = ""
        Me.crDate.RefreshSource = False
        Me.crDate.Required = False
        Me.crDate.SequenceName = ""
        Me.crDate.ShowCalc = True
        Me.crDate.ShowDataTime = False
        Me.crDate.ShowOnlyTime = False
        Me.crDate.SQLString = ""
        Me.crDate.UpdateIfNull = ""
        Me.crDate.UpdateWhenFormLock = False
        Me.crDate.UpperValue = False
        Me.crDate.ValidateValue = True
        Me.crDate.Visible = True
        Me.crDate.VisibleIndex = 13
        '
        'SyncUser
        '
        Me.SyncUser.AllowInsert = True
        Me.SyncUser.AllowUpdate = True
        Me.SyncUser.ButtonClick = True
        Me.SyncUser.Caption = "User đồng bộ"
        Me.SyncUser.CFLColumnHide = ""
        Me.SyncUser.CFLKeyField = ""
        Me.SyncUser.CFLPage = False
        Me.SyncUser.CFLReturn0 = ""
        Me.SyncUser.CFLReturn1 = ""
        Me.SyncUser.CFLReturn2 = ""
        Me.SyncUser.CFLReturn3 = ""
        Me.SyncUser.CFLReturn4 = ""
        Me.SyncUser.CFLReturn5 = ""
        Me.SyncUser.CFLReturn6 = ""
        Me.SyncUser.CFLReturn7 = ""
        Me.SyncUser.CFLShowLoad = False
        Me.SyncUser.ChangeFormStatus = True
        Me.SyncUser.ColumnKey = False
        Me.SyncUser.ComboLine = 5
        Me.SyncUser.CopyFromItem = ""
        Me.SyncUser.DefaultButtonClick = False
        Me.SyncUser.Digit = False
        Me.SyncUser.FieldType = "C"
        Me.SyncUser.FieldView = ""
        Me.SyncUser.FormarNumber = True
        Me.SyncUser.FormList = False
        Me.SyncUser.KeyInsert = ""
        Me.SyncUser.LocalDecimal = False
        Me.SyncUser.Name = "SyncUser"
        Me.SyncUser.NoUpdate = ""
        Me.SyncUser.NumberDecimal = 0
        Me.SyncUser.ParentControl = ""
        Me.SyncUser.RefreshSource = False
        Me.SyncUser.Required = False
        Me.SyncUser.SequenceName = ""
        Me.SyncUser.ShowCalc = True
        Me.SyncUser.ShowDataTime = False
        Me.SyncUser.ShowOnlyTime = False
        Me.SyncUser.SQLString = ""
        Me.SyncUser.UpdateIfNull = ""
        Me.SyncUser.UpdateWhenFormLock = False
        Me.SyncUser.UpperValue = False
        Me.SyncUser.ValidateValue = True
        Me.SyncUser.Visible = True
        Me.SyncUser.VisibleIndex = 14
        '
        'SyncDate
        '
        Me.SyncDate.AllowInsert = True
        Me.SyncDate.AllowUpdate = True
        Me.SyncDate.ButtonClick = True
        Me.SyncDate.Caption = "Ngày đồng bộ SAP"
        Me.SyncDate.CFLColumnHide = ""
        Me.SyncDate.CFLKeyField = ""
        Me.SyncDate.CFLPage = False
        Me.SyncDate.CFLReturn0 = ""
        Me.SyncDate.CFLReturn1 = ""
        Me.SyncDate.CFLReturn2 = ""
        Me.SyncDate.CFLReturn3 = ""
        Me.SyncDate.CFLReturn4 = ""
        Me.SyncDate.CFLReturn5 = ""
        Me.SyncDate.CFLReturn6 = ""
        Me.SyncDate.CFLReturn7 = ""
        Me.SyncDate.CFLShowLoad = False
        Me.SyncDate.ChangeFormStatus = True
        Me.SyncDate.ColumnKey = False
        Me.SyncDate.ComboLine = 5
        Me.SyncDate.CopyFromItem = ""
        Me.SyncDate.DefaultButtonClick = False
        Me.SyncDate.Digit = False
        Me.SyncDate.FieldType = "C"
        Me.SyncDate.FieldView = ""
        Me.SyncDate.FormarNumber = True
        Me.SyncDate.FormList = False
        Me.SyncDate.KeyInsert = ""
        Me.SyncDate.LocalDecimal = False
        Me.SyncDate.Name = "SyncDate"
        Me.SyncDate.NoUpdate = ""
        Me.SyncDate.NumberDecimal = 0
        Me.SyncDate.ParentControl = ""
        Me.SyncDate.RefreshSource = False
        Me.SyncDate.Required = False
        Me.SyncDate.SequenceName = ""
        Me.SyncDate.ShowCalc = True
        Me.SyncDate.ShowDataTime = False
        Me.SyncDate.ShowOnlyTime = False
        Me.SyncDate.SQLString = ""
        Me.SyncDate.UpdateIfNull = ""
        Me.SyncDate.UpdateWhenFormLock = False
        Me.SyncDate.UpperValue = False
        Me.SyncDate.ValidateValue = True
        Me.SyncDate.Visible = True
        Me.SyncDate.VisibleIndex = 15
        '
        'TankHeaderCode
        '
        Me.TankHeaderCode.AllowInsert = True
        Me.TankHeaderCode.AllowUpdate = True
        Me.TankHeaderCode.ButtonClick = True
        Me.TankHeaderCode.Caption = "TankHeaderCode"
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
        Me.TankHeaderCode.FieldView = ""
        Me.TankHeaderCode.FormarNumber = True
        Me.TankHeaderCode.FormList = False
        Me.TankHeaderCode.KeyInsert = ""
        Me.TankHeaderCode.LocalDecimal = False
        Me.TankHeaderCode.Name = "TankHeaderCode"
        Me.TankHeaderCode.NoUpdate = ""
        Me.TankHeaderCode.NumberDecimal = 0
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
        Me.TankHeaderCode.VisibleIndex = 17
        '
        'FrmTraCuuSoLieuDoBon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1094, 479)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtToDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFromDate)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TankList)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FrmTraCuuSoLieuDoBon"
        Me.Text = "Tra cứu số liệu đo bồn bể"
        Me.Controls.SetChildIndex(Me.TankList, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton7, 0)
        Me.Controls.SetChildIndex(Me.txtFromDate, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtToDate, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TankList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtToDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFromDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMaBe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SimpleButton7 As U_TextBox.U_ButtonCus
    Friend WithEvents TankList As U_TextBox.U_ButtonEdit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtToDate As U_TextBox.U_DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFromDate As U_TextBox.U_DateEdit
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents TankCode As U_TextBox.GridColumn
    Friend WithEvents FromDate As U_TextBox.GridColumn
    Friend WithEvents TankHeight As U_TextBox.GridColumn
    Friend WithEvents TankTemp As U_TextBox.GridColumn
    Friend WithEvents PurposeCode As U_TextBox.GridColumn
    Friend WithEvents Purposename As U_TextBox.GridColumn
    Friend WithEvents Dens As U_TextBox.GridColumn
    Friend WithEvents Ltt As U_TextBox.GridColumn
    Friend WithEvents VCF As U_TextBox.GridColumn
    Friend WithEvents VolumnL15 As U_TextBox.GridColumn
    Friend WithEvents WCF As U_TextBox.GridColumn
    Friend WithEvents VolumnKG As U_TextBox.GridColumn
    Friend WithEvents sType As U_TextBox.GridColumn
    Friend WithEvents crDate As U_TextBox.GridColumn
    Friend WithEvents SyncUser As U_TextBox.GridColumn
    Friend WithEvents SyncDate As U_TextBox.GridColumn
    Friend WithEvents TankHeaderCode As U_TextBox.GridColumn
    Friend WithEvents btnMaBe As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents NhomBeXuat As U_TextBox.GridColumn
End Class
