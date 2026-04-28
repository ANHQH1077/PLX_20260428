<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportGroup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportGroup))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ReportCode = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ReportName = New U_TextBox.GridColumn()
        Me.FromDate = New U_TextBox.GridColumn()
        Me.ToDate = New U_TextBox.GridColumn()
        Me.sDesc = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.Code = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.Row_ID = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemButtonEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCode = New U_TextBox.U_TextBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtName = New U_TextBox.U_TextBox()
        Me.txtStatus = New U_TextBox.U_Combobox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.Navigator1 = New U_TextBox.Navigator()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(613, 28)
        Me.ToolStrip2.TabIndex = 473
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(72, 25)
        Me.ToolStripButton1.Text = "&2. Lưu"
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(1, 136)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemComboBox1, Me.RepositoryItemButtonEdit2, Me.RepositoryItemButtonEdit3, Me.RepositoryItemButtonEdit4})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(612, 238)
        Me.TrueDBGrid1.TabIndex = 3
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = "Row_ID"
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ReportCode, Me.ReportName, Me.FromDate, Me.ToDate, Me.sDesc, Me.Code, Me.CHECKUPD, Me.Row_ID})
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
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "SYS_CONFIG_RPT_GROUP1"
        Me.GridView1.ViewName = "FPT_SYS_CONFIG_RPT_GROUP1_V"
        Me.GridView1.Where = "Code = :txtCode"
        '
        'ReportCode
        '
        Me.ReportCode.AllowInsert = True
        Me.ReportCode.AllowUpdate = True
        Me.ReportCode.ButtonClick = True
        Me.ReportCode.Caption = "Mã báo cáo"
        Me.ReportCode.CFLColumnHide = ""
        Me.ReportCode.CFLKeyField = "ReportCode"
        Me.ReportCode.CFLPage = False
        Me.ReportCode.CFLReturn0 = "ReportCode"
        Me.ReportCode.CFLReturn1 = "ReportName"
        Me.ReportCode.CFLReturn2 = ""
        Me.ReportCode.CFLReturn3 = ""
        Me.ReportCode.CFLReturn4 = ""
        Me.ReportCode.CFLReturn5 = ""
        Me.ReportCode.CFLReturn6 = ""
        Me.ReportCode.CFLReturn7 = ""
        Me.ReportCode.CFLShowLoad = False
        Me.ReportCode.ChangeFormStatus = True
        Me.ReportCode.ColumnEdit = Me.RepositoryItemButtonEdit4
        Me.ReportCode.ColumnKey = True
        Me.ReportCode.ComboLine = 5
        Me.ReportCode.CopyFromItem = ""
        Me.ReportCode.DefaultButtonClick = False
        Me.ReportCode.Digit = False
        Me.ReportCode.FieldType = "C"
        Me.ReportCode.FieldView = "ReportCode"
        Me.ReportCode.FormarNumber = True
        Me.ReportCode.FormList = False
        Me.ReportCode.KeyInsert = "Y"
        Me.ReportCode.LocalDecimal = False
        Me.ReportCode.Name = "ReportCode"
        Me.ReportCode.NoUpdate = ""
        Me.ReportCode.NumberDecimal = 0
        Me.ReportCode.ParentControl = ""
        Me.ReportCode.RefreshSource = False
        Me.ReportCode.Required = False
        Me.ReportCode.SequenceName = ""
        Me.ReportCode.ShowCalc = True
        Me.ReportCode.ShowDataTime = False
        Me.ReportCode.ShowOnlyTime = False
        Me.ReportCode.SQLString = "select ReportCode, ReportName from dbo.SYS_CONFIG_RPT"
        Me.ReportCode.UpdateIfNull = ""
        Me.ReportCode.UpdateWhenFormLock = False
        Me.ReportCode.UpperValue = False
        Me.ReportCode.ValidateValue = True
        Me.ReportCode.Visible = True
        Me.ReportCode.VisibleIndex = 0
        '
        'RepositoryItemButtonEdit4
        '
        Me.RepositoryItemButtonEdit4.AutoHeight = False
        Me.RepositoryItemButtonEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit4.Name = "RepositoryItemButtonEdit4"
        '
        'ReportName
        '
        Me.ReportName.AllowInsert = True
        Me.ReportName.AllowUpdate = True
        Me.ReportName.ButtonClick = True
        Me.ReportName.Caption = "Tên báo cáo"
        Me.ReportName.CFLColumnHide = ""
        Me.ReportName.CFLKeyField = ""
        Me.ReportName.CFLPage = False
        Me.ReportName.CFLReturn0 = ""
        Me.ReportName.CFLReturn1 = ""
        Me.ReportName.CFLReturn2 = ""
        Me.ReportName.CFLReturn3 = ""
        Me.ReportName.CFLReturn4 = ""
        Me.ReportName.CFLReturn5 = ""
        Me.ReportName.CFLReturn6 = ""
        Me.ReportName.CFLReturn7 = ""
        Me.ReportName.CFLShowLoad = False
        Me.ReportName.ChangeFormStatus = True
        Me.ReportName.ColumnKey = False
        Me.ReportName.ComboLine = 5
        Me.ReportName.CopyFromItem = ""
        Me.ReportName.DefaultButtonClick = False
        Me.ReportName.Digit = False
        Me.ReportName.FieldType = "C"
        Me.ReportName.FieldView = "ReportName"
        Me.ReportName.FormarNumber = True
        Me.ReportName.FormList = False
        Me.ReportName.KeyInsert = ""
        Me.ReportName.LocalDecimal = False
        Me.ReportName.Name = "ReportName"
        Me.ReportName.NoUpdate = ""
        Me.ReportName.NumberDecimal = 0
        Me.ReportName.ParentControl = ""
        Me.ReportName.RefreshSource = False
        Me.ReportName.Required = False
        Me.ReportName.SequenceName = ""
        Me.ReportName.ShowCalc = True
        Me.ReportName.ShowDataTime = False
        Me.ReportName.ShowOnlyTime = False
        Me.ReportName.SQLString = "select Code as LoadingSite from FPT_LoaiHinhVanChuyen_V"
        Me.ReportName.UpdateIfNull = ""
        Me.ReportName.UpdateWhenFormLock = False
        Me.ReportName.UpperValue = False
        Me.ReportName.ValidateValue = True
        Me.ReportName.Visible = True
        Me.ReportName.VisibleIndex = 1
        Me.ReportName.Width = 200
        '
        'FromDate
        '
        Me.FromDate.AllowInsert = True
        Me.FromDate.AllowUpdate = True
        Me.FromDate.ButtonClick = True
        Me.FromDate.Caption = "Hiệu lực"
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
        Me.FromDate.VisibleIndex = 2
        Me.FromDate.Width = 100
        '
        'ToDate
        '
        Me.ToDate.AllowInsert = True
        Me.ToDate.AllowUpdate = True
        Me.ToDate.ButtonClick = True
        Me.ToDate.Caption = "Hết hiệu lực"
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
        Me.ToDate.FieldType = "D"
        Me.ToDate.FieldView = "ToDate"
        Me.ToDate.FormarNumber = True
        Me.ToDate.FormList = False
        Me.ToDate.KeyInsert = ""
        Me.ToDate.LocalDecimal = False
        Me.ToDate.Name = "ToDate"
        Me.ToDate.NoUpdate = ""
        Me.ToDate.NumberDecimal = 0
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
        Me.ToDate.VisibleIndex = 3
        Me.ToDate.Width = 100
        '
        'sDesc
        '
        Me.sDesc.AllowInsert = True
        Me.sDesc.AllowUpdate = True
        Me.sDesc.ButtonClick = True
        Me.sDesc.Caption = "Ghi chú"
        Me.sDesc.CFLColumnHide = ""
        Me.sDesc.CFLKeyField = "ProductCode"
        Me.sDesc.CFLPage = False
        Me.sDesc.CFLReturn0 = ""
        Me.sDesc.CFLReturn1 = "TenHangHoa"
        Me.sDesc.CFLReturn2 = ""
        Me.sDesc.CFLReturn3 = ""
        Me.sDesc.CFLReturn4 = ""
        Me.sDesc.CFLReturn5 = ""
        Me.sDesc.CFLReturn6 = ""
        Me.sDesc.CFLReturn7 = ""
        Me.sDesc.CFLShowLoad = True
        Me.sDesc.ChangeFormStatus = True
        Me.sDesc.ColumnEdit = Me.RepositoryItemButtonEdit2
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
        Me.sDesc.VisibleIndex = 4
        Me.sDesc.Width = 200
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        '
        'Code
        '
        Me.Code.AllowInsert = True
        Me.Code.AllowUpdate = True
        Me.Code.ButtonClick = True
        Me.Code.Caption = "Tên hàng hóa"
        Me.Code.CFLColumnHide = ""
        Me.Code.CFLKeyField = ""
        Me.Code.CFLPage = False
        Me.Code.CFLReturn0 = ""
        Me.Code.CFLReturn1 = ""
        Me.Code.CFLReturn2 = ""
        Me.Code.CFLReturn3 = ""
        Me.Code.CFLReturn4 = ""
        Me.Code.CFLReturn5 = ""
        Me.Code.CFLReturn6 = ""
        Me.Code.CFLReturn7 = ""
        Me.Code.CFLShowLoad = False
        Me.Code.ChangeFormStatus = True
        Me.Code.ColumnKey = False
        Me.Code.ComboLine = 5
        Me.Code.CopyFromItem = ":txtCode"
        Me.Code.DefaultButtonClick = False
        Me.Code.Digit = False
        Me.Code.FieldType = "C"
        Me.Code.FieldView = "Code"
        Me.Code.FormarNumber = True
        Me.Code.FormList = False
        Me.Code.KeyInsert = ""
        Me.Code.LocalDecimal = False
        Me.Code.Name = "Code"
        Me.Code.NoUpdate = ""
        Me.Code.NumberDecimal = 0
        Me.Code.OptionsColumn.ReadOnly = True
        Me.Code.ParentControl = ""
        Me.Code.RefreshSource = False
        Me.Code.Required = False
        Me.Code.SequenceName = ""
        Me.Code.ShowCalc = True
        Me.Code.ShowDataTime = False
        Me.Code.ShowOnlyTime = False
        Me.Code.SQLString = ""
        Me.Code.UpdateIfNull = ""
        Me.Code.UpdateWhenFormLock = False
        Me.Code.UpperValue = False
        Me.Code.ValidateValue = True
        Me.Code.Visible = True
        Me.Code.Width = 50
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
        'Row_ID
        '
        Me.Row_ID.AllowInsert = False
        Me.Row_ID.AllowUpdate = False
        Me.Row_ID.ButtonClick = True
        Me.Row_ID.Caption = "Row_ID"
        Me.Row_ID.CFLColumnHide = ""
        Me.Row_ID.CFLKeyField = ""
        Me.Row_ID.CFLPage = False
        Me.Row_ID.CFLReturn0 = ""
        Me.Row_ID.CFLReturn1 = ""
        Me.Row_ID.CFLReturn2 = ""
        Me.Row_ID.CFLReturn3 = ""
        Me.Row_ID.CFLReturn4 = ""
        Me.Row_ID.CFLReturn5 = ""
        Me.Row_ID.CFLReturn6 = ""
        Me.Row_ID.CFLReturn7 = ""
        Me.Row_ID.CFLShowLoad = True
        Me.Row_ID.ChangeFormStatus = True
        Me.Row_ID.ColumnKey = True
        Me.Row_ID.ComboLine = 5
        Me.Row_ID.CopyFromItem = ""
        Me.Row_ID.DefaultButtonClick = False
        Me.Row_ID.Digit = False
        Me.Row_ID.FieldType = "N"
        Me.Row_ID.FieldView = "Row_ID"
        Me.Row_ID.FormarNumber = True
        Me.Row_ID.FormList = True
        Me.Row_ID.KeyInsert = ""
        Me.Row_ID.LocalDecimal = False
        Me.Row_ID.Name = "Row_ID"
        Me.Row_ID.NoUpdate = ""
        Me.Row_ID.NumberDecimal = 0
        Me.Row_ID.ParentControl = ""
        Me.Row_ID.RefreshSource = False
        Me.Row_ID.Required = False
        Me.Row_ID.SequenceName = ""
        Me.Row_ID.ShowCalc = True
        Me.Row_ID.ShowDataTime = False
        Me.Row_ID.ShowOnlyTime = False
        Me.Row_ID.SQLString = ""
        Me.Row_ID.UpdateIfNull = ""
        Me.Row_ID.UpdateWhenFormLock = False
        Me.Row_ID.UpperValue = False
        Me.Row_ID.ValidateValue = True
        Me.Row_ID.Visible = True
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'RepositoryItemButtonEdit3
        '
        Me.RepositoryItemButtonEdit3.AutoHeight = False
        Me.RepositoryItemButtonEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit3.Name = "RepositoryItemButtonEdit3"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(30, 40)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(66, 19)
        Me.LabelControl1.TabIndex = 476
        Me.LabelControl1.Text = "Mã nhóm"
        '
        'txtCode
        '
        Me.txtCode.AllowInsert = True
        Me.txtCode.AllowUpdate = False
        Me.txtCode.AutoKeyFix = ""
        Me.txtCode.AutoKeyName = ""
        Me.txtCode.BindingSourceName = ""
        Me.txtCode.ChangeFormStatus = True
        Me.txtCode.CopyFromItem = ""
        Me.txtCode.DefaultValue = ""
        Me.txtCode.FieldName = "Code"
        Me.txtCode.FieldType = "C"
        Me.txtCode.KeyInsert = "Y"
        Me.txtCode.LinkLabel = "LabelControl1"
        Me.txtCode.Location = New System.Drawing.Point(110, 39)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.NoUpdate = "Y"
        Me.txtCode.PrimaryKey = "Y"
        Me.txtCode.Properties.AutoHeight = False
        Me.txtCode.Required = "Y"
        Me.txtCode.Size = New System.Drawing.Size(119, 26)
        Me.txtCode.TabIndex = 0
        Me.txtCode.TableName = "SYS_CONFIG_RPT_GROUP"
        Me.txtCode.ToolTip = "NAME(U_TextBox) VIEW(SYS_USER) TAB(SYS_USER) FIELD (USER_NAME)"
        Me.txtCode.UpdateIfNull = "Y"
        Me.txtCode.UpdateWhenFormLock = False
        Me.txtCode.UpperValue = False
        Me.txtCode.ViewName = "SYS_CONFIG_RPT_GROUP"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(30, 70)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(73, 19)
        Me.LabelControl2.TabIndex = 478
        Me.LabelControl2.Text = "Tên nhóm"
        '
        'txtName
        '
        Me.txtName.AllowInsert = True
        Me.txtName.AllowUpdate = True
        Me.txtName.AutoKeyFix = ""
        Me.txtName.AutoKeyName = ""
        Me.txtName.BindingSourceName = ""
        Me.txtName.ChangeFormStatus = True
        Me.txtName.CopyFromItem = ""
        Me.txtName.DefaultValue = ""
        Me.txtName.FieldName = "Name"
        Me.txtName.FieldType = "C"
        Me.txtName.KeyInsert = "Y"
        Me.txtName.LinkLabel = "LabelControl2"
        Me.txtName.Location = New System.Drawing.Point(110, 67)
        Me.txtName.Name = "txtName"
        Me.txtName.NoUpdate = ""
        Me.txtName.PrimaryKey = "N"
        Me.txtName.Properties.AutoHeight = False
        Me.txtName.Required = "Y"
        Me.txtName.Size = New System.Drawing.Size(491, 26)
        Me.txtName.TabIndex = 1
        Me.txtName.TableName = "SYS_CONFIG_RPT_GROUP"
        Me.txtName.ToolTip = "NAME(U_TextBox) VIEW(SYS_USER) TAB(SYS_USER) FIELD (USER_NAME)"
        Me.txtName.UpdateIfNull = ""
        Me.txtName.UpdateWhenFormLock = False
        Me.txtName.UpperValue = False
        Me.txtName.ViewName = "SYS_CONFIG_RPT_GROUP"
        '
        'txtStatus
        '
        Me.txtStatus.AllowInsert = True
        Me.txtStatus.AllowUpdate = True
        Me.txtStatus.BindingSourceName = ""
        Me.txtStatus.ChangeFormStatus = True
        Me.txtStatus.CopyFromItem = ""
        Me.txtStatus.DefaultValue = ""
        Me.txtStatus.DisplayField = "Name"
        Me.txtStatus.DropDownRow = 10
        Me.txtStatus.FieldName = "Status"
        Me.txtStatus.FieldType = "C"
        Me.txtStatus.ItemValue = ""
        Me.txtStatus.KeyInsert = ""
        Me.txtStatus.LinkLabel = ""
        Me.txtStatus.Location = New System.Drawing.Point(110, 96)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.NoUpdate = ""
        Me.txtStatus.PrimaryKey = ""
        Me.txtStatus.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtStatus.Properties.Appearance.Options.UseFont = True
        Me.txtStatus.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtStatus.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtStatus.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtStatus.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtStatus.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtStatus.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtStatus.Properties.AutoHeight = False
        Me.txtStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtStatus.Properties.NullText = ""
        Me.txtStatus.Properties.ShowHeader = False
        Me.txtStatus.Required = "Y"
        Me.txtStatus.ShowHeader = False
        Me.txtStatus.Size = New System.Drawing.Size(190, 30)
        Me.txtStatus.SQL_String = "select 'Y' as Code, N'Sử dụng' as Name union all  select 'N' as Code, N'Không sử " & _
    "dụng' as Name"
        Me.txtStatus.TabIndex = 2
        Me.txtStatus.TableName = "SYS_CONFIG_RPT_GROUP"
        Me.txtStatus.UpdateIfNull = ""
        Me.txtStatus.UpdateWhenFormLock = False
        Me.txtStatus.ValueField = "Code"
        Me.txtStatus.ViewName = "SYS_CONFIG_RPT_GROUP"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(30, 101)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(73, 19)
        Me.LabelControl3.TabIndex = 480
        Me.LabelControl3.Text = "Trạng thái"
        '
        'Navigator1
        '
        Me.Navigator1.Buttons.First.Visible = False
        Me.Navigator1.Buttons.Last.Visible = False
        Me.Navigator1.Buttons.NextPage.Visible = False
        Me.Navigator1.Buttons.PrevPage.Visible = False
        Me.Navigator1.Buttons.Remove.Visible = False
        Me.Navigator1.DefaultButton = True
        Me.Navigator1.Location = New System.Drawing.Point(364, 0)
        Me.Navigator1.Name = "Navigator1"
        Me.Navigator1.Size = New System.Drawing.Size(249, 28)
        Me.Navigator1.TabIndex = 481
        Me.Navigator1.Text = "Navigator1"
        Me.Navigator1.ViewName = "SYS_CONFIG_RPT_GROUP"
        '
        'FrmReportGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 378)
        Me.Controls.Add(Me.Navigator1)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.txtStatus)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.DefaultSave = False
        Me.FormItemKey = "Code"
        Me.HeaderSource = "SYS_CONFIG_RPT_GROUP"
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReportGroup"
        Me.Text = "Nhóm báo cáo"
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.txtCode, 0)
        Me.Controls.SetChildIndex(Me.LabelControl1, 0)
        Me.Controls.SetChildIndex(Me.txtName, 0)
        Me.Controls.SetChildIndex(Me.LabelControl2, 0)
        Me.Controls.SetChildIndex(Me.txtStatus, 0)
        Me.Controls.SetChildIndex(Me.LabelControl3, 0)
        Me.Controls.SetChildIndex(Me.Navigator1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ReportCode As U_TextBox.GridColumn
    Friend WithEvents ReportName As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents ToDate As U_TextBox.GridColumn
    Friend WithEvents sDesc As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents Code As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents Row_ID As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents FromDate As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCode As U_TextBox.U_TextBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtName As U_TextBox.U_TextBox
    Friend WithEvents txtStatus As U_TextBox.U_Combobox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Navigator1 As U_TextBox.Navigator
    Friend WithEvents RepositoryItemButtonEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
