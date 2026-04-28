<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserRoll1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUserRoll1))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.USER_ID = New U_TextBox.GridColumn()
        Me.USER_NAME = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.DESCRIPTION = New U_TextBox.GridColumn()
        Me.FROM_RATE = New U_TextBox.GridColumn()
        Me.TO_RATE = New U_TextBox.GridColumn()
        Me.FROM_DATE = New U_TextBox.GridColumn()
        Me.TO_DATE = New U_TextBox.GridColumn()
        Me.ID = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.LoadingSite = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(5, 34)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemComboBox1, Me.RepositoryItemButtonEdit2})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(711, 334)
        Me.TrueDBGrid1.TabIndex = 1
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = True
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = False
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.USER_ID, Me.USER_NAME, Me.DESCRIPTION, Me.FROM_RATE, Me.TO_RATE, Me.FROM_DATE, Me.TO_DATE, Me.ID, Me.CHECKUPD, Me.LoadingSite})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = False
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OrderBy = ""
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "SYS_ROLL1"
        Me.GridView1.ViewName = "SYS_ROLL1_V"
        Me.GridView1.Where = Nothing
        '
        'USER_ID
        '
        Me.USER_ID.AllowInsert = True
        Me.USER_ID.AllowUpdate = True
        Me.USER_ID.Caption = "USER_ID"
        Me.USER_ID.CFLColumnHide = ""
        Me.USER_ID.CFLKeyField = ""
        Me.USER_ID.CFLPage = False
        Me.USER_ID.CFLReturn0 = ""
        Me.USER_ID.CFLReturn1 = ""
        Me.USER_ID.CFLReturn2 = ""
        Me.USER_ID.CFLReturn3 = ""
        Me.USER_ID.CFLReturn4 = ""
        Me.USER_ID.CFLReturn5 = ""
        Me.USER_ID.CFLReturn6 = ""
        Me.USER_ID.CFLReturn7 = ""
        Me.USER_ID.CFLShowLoad = False
        Me.USER_ID.ChangeFormStatus = True
        Me.USER_ID.ColumnKey = False
        Me.USER_ID.ComboLine = 5
        Me.USER_ID.CopyFromItem = ""
        Me.USER_ID.DefaultButtonClick = False
        Me.USER_ID.Digit = False
        Me.USER_ID.FieldType = "N"
        Me.USER_ID.FieldView = "USER_ID"
        Me.USER_ID.FormList = False
        Me.USER_ID.KeyInsert = ""
        Me.USER_ID.LocalDecimal = False
        Me.USER_ID.Name = "USER_ID"
        Me.USER_ID.NoUpdate = ""
        Me.USER_ID.NumberDecimal = 0
        Me.USER_ID.ParentControl = ""
        Me.USER_ID.RefreshSource = False
        Me.USER_ID.Required = False
        Me.USER_ID.ShowDataTime = False
        Me.USER_ID.SQLString = ""
        Me.USER_ID.UpdateIfNull = ""
        Me.USER_ID.UpdateWhenFormLock = False
        Me.USER_ID.ValidateValue = True
        Me.USER_ID.Visible = True
        '
        'USER_NAME
        '
        Me.USER_NAME.AllowInsert = True
        Me.USER_NAME.AllowUpdate = True
        Me.USER_NAME.Caption = "Tên đăng nhập"
        Me.USER_NAME.CFLColumnHide = ""
        Me.USER_NAME.CFLKeyField = "USER_ID"
        Me.USER_NAME.CFLPage = False
        Me.USER_NAME.CFLReturn0 = ""
        Me.USER_NAME.CFLReturn1 = "USER_ID"
        Me.USER_NAME.CFLReturn2 = ""
        Me.USER_NAME.CFLReturn3 = ""
        Me.USER_NAME.CFLReturn4 = ""
        Me.USER_NAME.CFLReturn5 = ""
        Me.USER_NAME.CFLReturn6 = ""
        Me.USER_NAME.CFLReturn7 = ""
        Me.USER_NAME.CFLShowLoad = True
        Me.USER_NAME.ChangeFormStatus = True
        Me.USER_NAME.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.USER_NAME.ColumnKey = False
        Me.USER_NAME.ComboLine = 5
        Me.USER_NAME.CopyFromItem = ""
        Me.USER_NAME.DefaultButtonClick = False
        Me.USER_NAME.Digit = False
        Me.USER_NAME.FieldType = "C"
        Me.USER_NAME.FieldView = "USER_NAME"
        Me.USER_NAME.FormList = False
        Me.USER_NAME.KeyInsert = ""
        Me.USER_NAME.LocalDecimal = False
        Me.USER_NAME.Name = "USER_NAME"
        Me.USER_NAME.NoUpdate = ""
        Me.USER_NAME.NumberDecimal = 0
        Me.USER_NAME.ParentControl = ""
        Me.USER_NAME.RefreshSource = False
        Me.USER_NAME.Required = False
        Me.USER_NAME.ShowDataTime = False
        Me.USER_NAME.SQLString = resources.GetString("USER_NAME.SQLString")
        Me.USER_NAME.UpdateIfNull = ""
        Me.USER_NAME.UpdateWhenFormLock = False
        Me.USER_NAME.ValidateValue = True
        Me.USER_NAME.Visible = True
        Me.USER_NAME.VisibleIndex = 0
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.AllowInsert = True
        Me.DESCRIPTION.AllowUpdate = True
        Me.DESCRIPTION.Caption = "DESCRIPTION"
        Me.DESCRIPTION.CFLColumnHide = ""
        Me.DESCRIPTION.CFLKeyField = ""
        Me.DESCRIPTION.CFLPage = False
        Me.DESCRIPTION.CFLReturn0 = ""
        Me.DESCRIPTION.CFLReturn1 = ""
        Me.DESCRIPTION.CFLReturn2 = ""
        Me.DESCRIPTION.CFLReturn3 = ""
        Me.DESCRIPTION.CFLReturn4 = ""
        Me.DESCRIPTION.CFLReturn5 = ""
        Me.DESCRIPTION.CFLReturn6 = ""
        Me.DESCRIPTION.CFLReturn7 = ""
        Me.DESCRIPTION.CFLShowLoad = False
        Me.DESCRIPTION.ChangeFormStatus = True
        Me.DESCRIPTION.ColumnKey = False
        Me.DESCRIPTION.ComboLine = 5
        Me.DESCRIPTION.CopyFromItem = ""
        Me.DESCRIPTION.DefaultButtonClick = False
        Me.DESCRIPTION.Digit = False
        Me.DESCRIPTION.FieldType = "C"
        Me.DESCRIPTION.FieldView = "DESCRIPTION"
        Me.DESCRIPTION.FormList = False
        Me.DESCRIPTION.KeyInsert = ""
        Me.DESCRIPTION.LocalDecimal = False
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.NoUpdate = ""
        Me.DESCRIPTION.NumberDecimal = 0
        Me.DESCRIPTION.ParentControl = ""
        Me.DESCRIPTION.RefreshSource = False
        Me.DESCRIPTION.Required = False
        Me.DESCRIPTION.ShowDataTime = False
        Me.DESCRIPTION.SQLString = ""
        Me.DESCRIPTION.UpdateIfNull = ""
        Me.DESCRIPTION.UpdateWhenFormLock = False
        Me.DESCRIPTION.ValidateValue = True
        Me.DESCRIPTION.Visible = True
        '
        'FROM_RATE
        '
        Me.FROM_RATE.AllowInsert = True
        Me.FROM_RATE.AllowUpdate = True
        Me.FROM_RATE.Caption = "Từ tỷ lệ %"
        Me.FROM_RATE.CFLColumnHide = ""
        Me.FROM_RATE.CFLKeyField = ""
        Me.FROM_RATE.CFLPage = False
        Me.FROM_RATE.CFLReturn0 = ""
        Me.FROM_RATE.CFLReturn1 = ""
        Me.FROM_RATE.CFLReturn2 = ""
        Me.FROM_RATE.CFLReturn3 = ""
        Me.FROM_RATE.CFLReturn4 = ""
        Me.FROM_RATE.CFLReturn5 = ""
        Me.FROM_RATE.CFLReturn6 = ""
        Me.FROM_RATE.CFLReturn7 = ""
        Me.FROM_RATE.CFLShowLoad = False
        Me.FROM_RATE.ChangeFormStatus = True
        Me.FROM_RATE.ColumnKey = False
        Me.FROM_RATE.ComboLine = 5
        Me.FROM_RATE.CopyFromItem = ""
        Me.FROM_RATE.DefaultButtonClick = False
        Me.FROM_RATE.Digit = True
        Me.FROM_RATE.FieldType = "N"
        Me.FROM_RATE.FieldView = "FROM_RATE"
        Me.FROM_RATE.FormList = False
        Me.FROM_RATE.KeyInsert = ""
        Me.FROM_RATE.LocalDecimal = True
        Me.FROM_RATE.Name = "FROM_RATE"
        Me.FROM_RATE.NoUpdate = ""
        Me.FROM_RATE.NumberDecimal = 3
        Me.FROM_RATE.ParentControl = ""
        Me.FROM_RATE.RefreshSource = False
        Me.FROM_RATE.Required = False
        Me.FROM_RATE.ShowDataTime = False
        Me.FROM_RATE.SQLString = ""
        Me.FROM_RATE.UpdateIfNull = ""
        Me.FROM_RATE.UpdateWhenFormLock = False
        Me.FROM_RATE.ValidateValue = True
        Me.FROM_RATE.Visible = True
        Me.FROM_RATE.VisibleIndex = 1
        '
        'TO_RATE
        '
        Me.TO_RATE.AllowInsert = True
        Me.TO_RATE.AllowUpdate = True
        Me.TO_RATE.Caption = "Đến tỷ lệ %"
        Me.TO_RATE.CFLColumnHide = ""
        Me.TO_RATE.CFLKeyField = ""
        Me.TO_RATE.CFLPage = False
        Me.TO_RATE.CFLReturn0 = ""
        Me.TO_RATE.CFLReturn1 = ""
        Me.TO_RATE.CFLReturn2 = ""
        Me.TO_RATE.CFLReturn3 = ""
        Me.TO_RATE.CFLReturn4 = ""
        Me.TO_RATE.CFLReturn5 = ""
        Me.TO_RATE.CFLReturn6 = ""
        Me.TO_RATE.CFLReturn7 = ""
        Me.TO_RATE.CFLShowLoad = False
        Me.TO_RATE.ChangeFormStatus = True
        Me.TO_RATE.ColumnKey = False
        Me.TO_RATE.ComboLine = 5
        Me.TO_RATE.CopyFromItem = ""
        Me.TO_RATE.DefaultButtonClick = False
        Me.TO_RATE.Digit = True
        Me.TO_RATE.FieldType = "N"
        Me.TO_RATE.FieldView = "TO_RATE"
        Me.TO_RATE.FormList = False
        Me.TO_RATE.KeyInsert = ""
        Me.TO_RATE.LocalDecimal = True
        Me.TO_RATE.Name = "TO_RATE"
        Me.TO_RATE.NoUpdate = ""
        Me.TO_RATE.NumberDecimal = 3
        Me.TO_RATE.ParentControl = ""
        Me.TO_RATE.RefreshSource = False
        Me.TO_RATE.Required = False
        Me.TO_RATE.ShowDataTime = False
        Me.TO_RATE.SQLString = ""
        Me.TO_RATE.UpdateIfNull = ""
        Me.TO_RATE.UpdateWhenFormLock = False
        Me.TO_RATE.ValidateValue = True
        Me.TO_RATE.Visible = True
        Me.TO_RATE.VisibleIndex = 2
        '
        'FROM_DATE
        '
        Me.FROM_DATE.AllowInsert = True
        Me.FROM_DATE.AllowUpdate = True
        Me.FROM_DATE.Caption = "Ngày hiệu lực"
        Me.FROM_DATE.CFLColumnHide = ""
        Me.FROM_DATE.CFLKeyField = ""
        Me.FROM_DATE.CFLPage = False
        Me.FROM_DATE.CFLReturn0 = ""
        Me.FROM_DATE.CFLReturn1 = ""
        Me.FROM_DATE.CFLReturn2 = ""
        Me.FROM_DATE.CFLReturn3 = ""
        Me.FROM_DATE.CFLReturn4 = ""
        Me.FROM_DATE.CFLReturn5 = ""
        Me.FROM_DATE.CFLReturn6 = ""
        Me.FROM_DATE.CFLReturn7 = ""
        Me.FROM_DATE.CFLShowLoad = False
        Me.FROM_DATE.ChangeFormStatus = True
        Me.FROM_DATE.ColumnKey = False
        Me.FROM_DATE.ComboLine = 5
        Me.FROM_DATE.CopyFromItem = ""
        Me.FROM_DATE.DefaultButtonClick = False
        Me.FROM_DATE.Digit = False
        Me.FROM_DATE.FieldType = "D"
        Me.FROM_DATE.FieldView = "FROM_DATE"
        Me.FROM_DATE.FormList = False
        Me.FROM_DATE.KeyInsert = ""
        Me.FROM_DATE.LocalDecimal = False
        Me.FROM_DATE.Name = "FROM_DATE"
        Me.FROM_DATE.NoUpdate = ""
        Me.FROM_DATE.NumberDecimal = 0
        Me.FROM_DATE.ParentControl = ""
        Me.FROM_DATE.RefreshSource = False
        Me.FROM_DATE.Required = False
        Me.FROM_DATE.ShowDataTime = False
        Me.FROM_DATE.SQLString = ""
        Me.FROM_DATE.UpdateIfNull = ""
        Me.FROM_DATE.UpdateWhenFormLock = False
        Me.FROM_DATE.ValidateValue = True
        Me.FROM_DATE.Visible = True
        Me.FROM_DATE.VisibleIndex = 3
        '
        'TO_DATE
        '
        Me.TO_DATE.AllowInsert = True
        Me.TO_DATE.AllowUpdate = True
        Me.TO_DATE.Caption = "Ngày hết hiệu lực"
        Me.TO_DATE.CFLColumnHide = ""
        Me.TO_DATE.CFLKeyField = ""
        Me.TO_DATE.CFLPage = False
        Me.TO_DATE.CFLReturn0 = ""
        Me.TO_DATE.CFLReturn1 = ""
        Me.TO_DATE.CFLReturn2 = ""
        Me.TO_DATE.CFLReturn3 = ""
        Me.TO_DATE.CFLReturn4 = ""
        Me.TO_DATE.CFLReturn5 = ""
        Me.TO_DATE.CFLReturn6 = ""
        Me.TO_DATE.CFLReturn7 = ""
        Me.TO_DATE.CFLShowLoad = False
        Me.TO_DATE.ChangeFormStatus = True
        Me.TO_DATE.ColumnKey = False
        Me.TO_DATE.ComboLine = 5
        Me.TO_DATE.CopyFromItem = ""
        Me.TO_DATE.DefaultButtonClick = False
        Me.TO_DATE.Digit = False
        Me.TO_DATE.FieldType = "D"
        Me.TO_DATE.FieldView = "TO_DATE"
        Me.TO_DATE.FormList = False
        Me.TO_DATE.KeyInsert = ""
        Me.TO_DATE.LocalDecimal = False
        Me.TO_DATE.Name = "TO_DATE"
        Me.TO_DATE.NoUpdate = ""
        Me.TO_DATE.NumberDecimal = 0
        Me.TO_DATE.ParentControl = ""
        Me.TO_DATE.RefreshSource = False
        Me.TO_DATE.Required = False
        Me.TO_DATE.ShowDataTime = False
        Me.TO_DATE.SQLString = ""
        Me.TO_DATE.UpdateIfNull = ""
        Me.TO_DATE.UpdateWhenFormLock = False
        Me.TO_DATE.ValidateValue = True
        Me.TO_DATE.Visible = True
        Me.TO_DATE.VisibleIndex = 4
        '
        'ID
        '
        Me.ID.AllowInsert = False
        Me.ID.AllowUpdate = False
        Me.ID.Caption = "ID"
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
        Me.ID.FormList = False
        Me.ID.KeyInsert = ""
        Me.ID.LocalDecimal = False
        Me.ID.Name = "ID"
        Me.ID.NoUpdate = ""
        Me.ID.NumberDecimal = 0
        Me.ID.ParentControl = ""
        Me.ID.RefreshSource = False
        Me.ID.Required = False
        Me.ID.ShowDataTime = False
        Me.ID.SQLString = ""
        Me.ID.UpdateIfNull = ""
        Me.ID.UpdateWhenFormLock = False
        Me.ID.ValidateValue = True
        Me.ID.Visible = True
        '
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
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
        Me.CHECKUPD.FormList = False
        Me.CHECKUPD.KeyInsert = ""
        Me.CHECKUPD.LocalDecimal = False
        Me.CHECKUPD.Name = "CHECKUPD"
        Me.CHECKUPD.NoUpdate = ""
        Me.CHECKUPD.NumberDecimal = 0
        Me.CHECKUPD.ParentControl = ""
        Me.CHECKUPD.RefreshSource = False
        Me.CHECKUPD.Required = False
        Me.CHECKUPD.ShowDataTime = False
        Me.CHECKUPD.SQLString = ""
        Me.CHECKUPD.UpdateIfNull = ""
        Me.CHECKUPD.UpdateWhenFormLock = False
        Me.CHECKUPD.ValidateValue = True
        Me.CHECKUPD.Visible = True
        '
        'LoadingSite
        '
        Me.LoadingSite.AllowInsert = True
        Me.LoadingSite.AllowUpdate = True
        Me.LoadingSite.Caption = "Loại"
        Me.LoadingSite.CFLColumnHide = ""
        Me.LoadingSite.CFLKeyField = "Code"
        Me.LoadingSite.CFLPage = False
        Me.LoadingSite.CFLReturn0 = ""
        Me.LoadingSite.CFLReturn1 = ""
        Me.LoadingSite.CFLReturn2 = ""
        Me.LoadingSite.CFLReturn3 = ""
        Me.LoadingSite.CFLReturn4 = ""
        Me.LoadingSite.CFLReturn5 = ""
        Me.LoadingSite.CFLReturn6 = ""
        Me.LoadingSite.CFLReturn7 = ""
        Me.LoadingSite.CFLShowLoad = True
        Me.LoadingSite.ChangeFormStatus = True
        Me.LoadingSite.ColumnEdit = Me.RepositoryItemButtonEdit2
        Me.LoadingSite.ColumnKey = False
        Me.LoadingSite.ComboLine = 5
        Me.LoadingSite.CopyFromItem = ""
        Me.LoadingSite.DefaultButtonClick = False
        Me.LoadingSite.Digit = False
        Me.LoadingSite.FieldType = "C"
        Me.LoadingSite.FieldView = "LoadingSite"
        Me.LoadingSite.FormList = True
        Me.LoadingSite.KeyInsert = ""
        Me.LoadingSite.LocalDecimal = False
        Me.LoadingSite.Name = "LoadingSite"
        Me.LoadingSite.NoUpdate = ""
        Me.LoadingSite.NumberDecimal = 0
        Me.LoadingSite.ParentControl = ""
        Me.LoadingSite.RefreshSource = False
        Me.LoadingSite.Required = False
        Me.LoadingSite.ShowDataTime = False
        Me.LoadingSite.SQLString = "SELECT Code   FROM [FPT_LoaiHinhVanChuyen_V]"
        Me.LoadingSite.UpdateIfNull = ""
        Me.LoadingSite.UpdateWhenFormLock = False
        Me.LoadingSite.ValidateValue = True
        Me.LoadingSite.Visible = True
        Me.LoadingSite.VisibleIndex = 5
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(720, 28)
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
        'FrmUserRoll1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 397)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultSave = False
        Me.KeyPreview = True
        Me.Name = "FrmUserRoll1"
        Me.Text = "Quyền phê duyệt chênh lệch"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents USER_ID As U_TextBox.GridColumn
    Friend WithEvents USER_NAME As U_TextBox.GridColumn
    Friend WithEvents DESCRIPTION As U_TextBox.GridColumn
    Friend WithEvents FROM_RATE As U_TextBox.GridColumn
    Friend WithEvents TO_RATE As U_TextBox.GridColumn
    Friend WithEvents FROM_DATE As U_TextBox.GridColumn
    Friend WithEvents TO_DATE As U_TextBox.GridColumn
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents LoadingSite As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
