<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportGrp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportGrp))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.X = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Code = New U_TextBox.GridColumn()
        Me.colName = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemButtonEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemButtonEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(2, 31)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemComboBox1, Me.RepositoryItemButtonEdit2, Me.RepositoryItemButtonEdit3, Me.RepositoryItemButtonEdit4, Me.RepositoryItemCheckEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(449, 319)
        Me.TrueDBGrid1.TabIndex = 4
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.CheckUpd = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = "Code"
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.X, Me.Code, Me.colName})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "Code"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "FPT_SYS_CONFIG_RPT_GROUP_V"
        Me.GridView1.Where = "isnull(Status,'N') ='Y'"
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
        Me.X.Width = 30
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Y"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "N"
        '
        'Code
        '
        Me.Code.AllowInsert = True
        Me.Code.AllowUpdate = True
        Me.Code.ButtonClick = True
        Me.Code.Caption = "Mã nhóm"
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
        Me.Code.ColumnKey = True
        Me.Code.ComboLine = 5
        Me.Code.CopyFromItem = ""
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
        Me.Code.VisibleIndex = 1
        '
        'colName
        '
        Me.colName.AllowInsert = True
        Me.colName.AllowUpdate = True
        Me.colName.ButtonClick = True
        Me.colName.Caption = "Tên nhóm"
        Me.colName.CFLColumnHide = ""
        Me.colName.CFLKeyField = ""
        Me.colName.CFLPage = False
        Me.colName.CFLReturn0 = ""
        Me.colName.CFLReturn1 = ""
        Me.colName.CFLReturn2 = ""
        Me.colName.CFLReturn3 = ""
        Me.colName.CFLReturn4 = ""
        Me.colName.CFLReturn5 = ""
        Me.colName.CFLReturn6 = ""
        Me.colName.CFLReturn7 = ""
        Me.colName.CFLShowLoad = False
        Me.colName.ChangeFormStatus = True
        Me.colName.ColumnKey = False
        Me.colName.ComboLine = 5
        Me.colName.CopyFromItem = ""
        Me.colName.DefaultButtonClick = False
        Me.colName.Digit = False
        Me.colName.FieldType = "C"
        Me.colName.FieldView = "Name"
        Me.colName.FormarNumber = True
        Me.colName.FormList = False
        Me.colName.KeyInsert = ""
        Me.colName.LocalDecimal = False
        Me.colName.Name = "colName"
        Me.colName.NoUpdate = ""
        Me.colName.NumberDecimal = 0
        Me.colName.OptionsColumn.ReadOnly = True
        Me.colName.ParentControl = ""
        Me.colName.RefreshSource = False
        Me.colName.Required = False
        Me.colName.SequenceName = ""
        Me.colName.ShowCalc = True
        Me.colName.ShowDataTime = False
        Me.colName.ShowOnlyTime = False
        Me.colName.SQLString = ""
        Me.colName.UpdateIfNull = ""
        Me.colName.UpdateWhenFormLock = False
        Me.colName.UpperValue = False
        Me.colName.ValidateValue = True
        Me.colName.Visible = True
        Me.colName.VisibleIndex = 2
        Me.colName.Width = 300
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
        'RepositoryItemButtonEdit4
        '
        Me.RepositoryItemButtonEdit4.AutoHeight = False
        Me.RepositoryItemButtonEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit4.Name = "RepositoryItemButtonEdit4"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(451, 28)
        Me.ToolStrip2.TabIndex = 471
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(97, 25)
        Me.ToolStripButton1.Text = "Thực hiện"
        '
        'FrmReportGrp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 350)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReportGrp"
        Me.Text = "Nhóm báo cáo"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents Code As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents colName As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemButtonEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents X As U_TextBox.GridColumn
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
