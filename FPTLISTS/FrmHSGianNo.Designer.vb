<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHSGianNo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmHSGianNo))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ID = New U_TextBox.GridColumn()
        Me.MaHangHoa = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.HeSo = New U_TextBox.GridColumn()
        Me.FromDate = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.To_Date = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemButtonEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RepositoryItemDateEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit3.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(2, 28)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemComboBox1, Me.RepositoryItemButtonEdit2, Me.RepositoryItemButtonEdit3, Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2, Me.RepositoryItemDateEdit3})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(389, 201)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = "ID"
        Me.GridView1.ColumnKeyIns = False
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ID, Me.MaHangHoa, Me.HeSo, Me.FromDate, Me.CHECKUPD, Me.To_Date})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "FromDate"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblHeSoGianNo"
        Me.GridView1.ViewName = "tblHeSoGianNo_V"
        Me.GridView1.Where = Nothing
        '
        'ID
        '
        Me.ID.AllowInsert = False
        Me.ID.AllowUpdate = False
        Me.ID.ButtonClick = True
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
        Me.ID.FormarNumber = False
        Me.ID.FormList = False
        Me.ID.KeyInsert = "N"
        Me.ID.LocalDecimal = True
        Me.ID.Name = "ID"
        Me.ID.NoUpdate = ""
        Me.ID.NumberDecimal = 0
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
        'MaHangHoa
        '
        Me.MaHangHoa.AllowInsert = True
        Me.MaHangHoa.AllowUpdate = True
        Me.MaHangHoa.ButtonClick = True
        Me.MaHangHoa.Caption = "Mã hàng hóa"
        Me.MaHangHoa.CFLColumnHide = ""
        Me.MaHangHoa.CFLKeyField = ""
        Me.MaHangHoa.CFLPage = False
        Me.MaHangHoa.CFLReturn0 = ""
        Me.MaHangHoa.CFLReturn1 = ""
        Me.MaHangHoa.CFLReturn2 = ""
        Me.MaHangHoa.CFLReturn3 = ""
        Me.MaHangHoa.CFLReturn4 = ""
        Me.MaHangHoa.CFLReturn5 = ""
        Me.MaHangHoa.CFLReturn6 = ""
        Me.MaHangHoa.CFLReturn7 = ""
        Me.MaHangHoa.CFLShowLoad = True
        Me.MaHangHoa.ChangeFormStatus = True
        Me.MaHangHoa.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.MaHangHoa.ColumnKey = False
        Me.MaHangHoa.ComboLine = 5
        Me.MaHangHoa.CopyFromItem = ""
        Me.MaHangHoa.DefaultButtonClick = False
        Me.MaHangHoa.Digit = False
        Me.MaHangHoa.FieldType = "C"
        Me.MaHangHoa.FieldView = "MaHangHoa"
        Me.MaHangHoa.FormarNumber = True
        Me.MaHangHoa.FormList = True
        Me.MaHangHoa.KeyInsert = ""
        Me.MaHangHoa.LocalDecimal = False
        Me.MaHangHoa.Name = "MaHangHoa"
        Me.MaHangHoa.NoUpdate = ""
        Me.MaHangHoa.NumberDecimal = 0
        Me.MaHangHoa.ParentControl = ""
        Me.MaHangHoa.RefreshSource = False
        Me.MaHangHoa.Required = False
        Me.MaHangHoa.SequenceName = ""
        Me.MaHangHoa.ShowCalc = True
        Me.MaHangHoa.ShowDataTime = False
        Me.MaHangHoa.ShowOnlyTime = False
        Me.MaHangHoa.SQLString = "select MaHangHoa, TenhangHoa from tblHangHoa  where MaHangHoa  in ('0301001','030" & _
            "1002')"
        Me.MaHangHoa.UpdateIfNull = ""
        Me.MaHangHoa.UpdateWhenFormLock = False
        Me.MaHangHoa.UpperValue = False
        Me.MaHangHoa.ValidateValue = True
        Me.MaHangHoa.Visible = True
        Me.MaHangHoa.VisibleIndex = 0
        Me.MaHangHoa.Width = 100
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'HeSo
        '
        Me.HeSo.AllowInsert = True
        Me.HeSo.AllowUpdate = True
        Me.HeSo.ButtonClick = True
        Me.HeSo.Caption = "Hệ số giãn nở"
        Me.HeSo.CFLColumnHide = ""
        Me.HeSo.CFLKeyField = ""
        Me.HeSo.CFLPage = False
        Me.HeSo.CFLReturn0 = ""
        Me.HeSo.CFLReturn1 = ""
        Me.HeSo.CFLReturn2 = ""
        Me.HeSo.CFLReturn3 = ""
        Me.HeSo.CFLReturn4 = ""
        Me.HeSo.CFLReturn5 = ""
        Me.HeSo.CFLReturn6 = ""
        Me.HeSo.CFLReturn7 = ""
        Me.HeSo.CFLShowLoad = False
        Me.HeSo.ChangeFormStatus = True
        Me.HeSo.ColumnKey = False
        Me.HeSo.ComboLine = 5
        Me.HeSo.CopyFromItem = ""
        Me.HeSo.DefaultButtonClick = False
        Me.HeSo.Digit = True
        Me.HeSo.FieldType = "N"
        Me.HeSo.FieldView = "HeSo"
        Me.HeSo.FormarNumber = False
        Me.HeSo.FormList = False
        Me.HeSo.KeyInsert = ""
        Me.HeSo.LocalDecimal = True
        Me.HeSo.Name = "HeSo"
        Me.HeSo.NoUpdate = ""
        Me.HeSo.NumberDecimal = 6
        Me.HeSo.ParentControl = ""
        Me.HeSo.RefreshSource = False
        Me.HeSo.Required = False
        Me.HeSo.SequenceName = ""
        Me.HeSo.ShowCalc = True
        Me.HeSo.ShowDataTime = False
        Me.HeSo.ShowOnlyTime = False
        Me.HeSo.SQLString = ""
        Me.HeSo.UpdateIfNull = ""
        Me.HeSo.UpdateWhenFormLock = False
        Me.HeSo.UpperValue = False
        Me.HeSo.ValidateValue = True
        Me.HeSo.Visible = True
        Me.HeSo.VisibleIndex = 1
        Me.HeSo.Width = 100
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
        Me.FromDate.FormarNumber = False
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
        Me.FromDate.VisibleIndex = 2
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
        'To_Date
        '
        Me.To_Date.AllowInsert = True
        Me.To_Date.AllowUpdate = True
        Me.To_Date.ButtonClick = True
        Me.To_Date.Caption = "Hết hiệu lực"
        Me.To_Date.CFLColumnHide = ""
        Me.To_Date.CFLKeyField = ""
        Me.To_Date.CFLPage = False
        Me.To_Date.CFLReturn0 = ""
        Me.To_Date.CFLReturn1 = ""
        Me.To_Date.CFLReturn2 = ""
        Me.To_Date.CFLReturn3 = ""
        Me.To_Date.CFLReturn4 = ""
        Me.To_Date.CFLReturn5 = ""
        Me.To_Date.CFLReturn6 = ""
        Me.To_Date.CFLReturn7 = ""
        Me.To_Date.CFLShowLoad = False
        Me.To_Date.ChangeFormStatus = True
        Me.To_Date.ColumnKey = False
        Me.To_Date.ComboLine = 5
        Me.To_Date.CopyFromItem = ""
        Me.To_Date.DefaultButtonClick = False
        Me.To_Date.Digit = False
        Me.To_Date.FieldType = "D"
        Me.To_Date.FieldView = "To_Date"
        Me.To_Date.FormarNumber = True
        Me.To_Date.FormList = False
        Me.To_Date.KeyInsert = ""
        Me.To_Date.LocalDecimal = False
        Me.To_Date.Name = "To_Date"
        Me.To_Date.NoUpdate = ""
        Me.To_Date.NumberDecimal = 0
        Me.To_Date.ParentControl = ""
        Me.To_Date.RefreshSource = False
        Me.To_Date.Required = False
        Me.To_Date.SequenceName = ""
        Me.To_Date.ShowCalc = True
        Me.To_Date.ShowDataTime = False
        Me.To_Date.ShowOnlyTime = False
        Me.To_Date.SQLString = ""
        Me.To_Date.UpdateIfNull = ""
        Me.To_Date.UpdateWhenFormLock = False
        Me.To_Date.UpperValue = False
        Me.To_Date.ValidateValue = True
        Me.To_Date.Visible = True
        Me.To_Date.VisibleIndex = 3
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        '
        'RepositoryItemButtonEdit3
        '
        Me.RepositoryItemButtonEdit3.AutoHeight = False
        Me.RepositoryItemButtonEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit3.Name = "RepositoryItemButtonEdit3"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        Me.RepositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'RepositoryItemDateEdit2
        '
        Me.RepositoryItemDateEdit2.AutoHeight = False
        Me.RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
        Me.RepositoryItemDateEdit2.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'RepositoryItemDateEdit3
        '
        Me.RepositoryItemDateEdit3.AutoHeight = False
        Me.RepositoryItemDateEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit3.Mask.EditMask = "dd-MM-yyyy"
        Me.RepositoryItemDateEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Custom
        Me.RepositoryItemDateEdit3.Name = "RepositoryItemDateEdit3"
        Me.RepositoryItemDateEdit3.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(396, 28)
        Me.ToolStrip2.TabIndex = 470
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
        'FrmHSGianNo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 247)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.Name = "FrmHSGianNo"
        Me.ShowFormMessage = True
        Me.Text = "Hệ số gian nở"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit3.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents HeSo As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemButtonEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FromDate As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemDateEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents To_Date As U_TextBox.GridColumn
    Friend WithEvents MaHangHoa As U_TextBox.GridColumn
End Class
