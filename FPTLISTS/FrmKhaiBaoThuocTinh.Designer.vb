<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKhaiBaoThuocTinh
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKhaiBaoThuocTinh))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.FormName = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.DESCRIPTION = New U_TextBox.GridColumn()
        Me.FormType = New U_TextBox.GridColumn()
        Me.ItemName = New U_TextBox.GridColumn()
        Me.ColName = New U_TextBox.GridColumn()
        Me.sRequired = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.sLock = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ID = New U_TextBox.GridColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(0, 31)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit2, Me.RepositoryItemButtonEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(984, 460)
        Me.TrueDBGrid1.TabIndex = 2
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = False
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.FormName, Me.DESCRIPTION, Me.FormType, Me.ItemName, Me.ColName, Me.sRequired, Me.sLock, Me.ID})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OrderBy = "FormName, ID "
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblLenhXuatConfig"
        Me.GridView1.ViewName = "tblLenhXuatConfig_V"
        Me.GridView1.Where = Nothing
        '
        'FormName
        '
        Me.FormName.AllowInsert = True
        Me.FormName.AllowUpdate = True
        Me.FormName.ButtonClick = True
        Me.FormName.Caption = "Form Name"
        Me.FormName.CFLColumnHide = ""
        Me.FormName.CFLKeyField = "Form_Name"
        Me.FormName.CFLPage = False
        Me.FormName.CFLReturn0 = "FormName"
        Me.FormName.CFLReturn1 = "DESCRIPTION"
        Me.FormName.CFLReturn2 = ""
        Me.FormName.CFLReturn3 = ""
        Me.FormName.CFLReturn4 = ""
        Me.FormName.CFLReturn5 = ""
        Me.FormName.CFLReturn6 = ""
        Me.FormName.CFLReturn7 = ""
        Me.FormName.CFLShowLoad = False
        Me.FormName.ChangeFormStatus = True
        Me.FormName.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.FormName.ColumnKey = False
        Me.FormName.ComboLine = 5
        Me.FormName.CopyFromItem = ""
        Me.FormName.DefaultButtonClick = False
        Me.FormName.Digit = False
        Me.FormName.FieldType = "C"
        Me.FormName.FieldView = "FormName"
        Me.FormName.FormarNumber = True
        Me.FormName.FormList = False
        Me.FormName.KeyInsert = ""
        Me.FormName.LocalDecimal = False
        Me.FormName.Name = "FormName"
        Me.FormName.NoUpdate = ""
        Me.FormName.NumberDecimal = 0
        Me.FormName.ParentControl = ""
        Me.FormName.RefreshSource = False
        Me.FormName.Required = False
        Me.FormName.SequenceName = ""
        Me.FormName.ShowCalc = True
        Me.FormName.ShowDataTime = False
        Me.FormName.ShowOnlyTime = False
        Me.FormName.SQLString = resources.GetString("FormName.SQLString")
        Me.FormName.UpdateIfNull = ""
        Me.FormName.UpdateWhenFormLock = False
        Me.FormName.UpperValue = False
        Me.FormName.ValidateValue = True
        Me.FormName.Visible = True
        Me.FormName.VisibleIndex = 0
        Me.FormName.Width = 200
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
        Me.DESCRIPTION.ButtonClick = True
        Me.DESCRIPTION.Caption = "Note"
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
        Me.DESCRIPTION.FormarNumber = True
        Me.DESCRIPTION.FormList = False
        Me.DESCRIPTION.KeyInsert = ""
        Me.DESCRIPTION.LocalDecimal = False
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.NoUpdate = ""
        Me.DESCRIPTION.NumberDecimal = 0
        Me.DESCRIPTION.OptionsColumn.ReadOnly = True
        Me.DESCRIPTION.ParentControl = ""
        Me.DESCRIPTION.RefreshSource = False
        Me.DESCRIPTION.Required = False
        Me.DESCRIPTION.SequenceName = ""
        Me.DESCRIPTION.ShowCalc = True
        Me.DESCRIPTION.ShowDataTime = False
        Me.DESCRIPTION.ShowOnlyTime = False
        Me.DESCRIPTION.SQLString = ""
        Me.DESCRIPTION.UpdateIfNull = ""
        Me.DESCRIPTION.UpdateWhenFormLock = False
        Me.DESCRIPTION.UpperValue = False
        Me.DESCRIPTION.ValidateValue = True
        Me.DESCRIPTION.Visible = True
        Me.DESCRIPTION.VisibleIndex = 1
        Me.DESCRIPTION.Width = 200
        '
        'FormType
        '
        Me.FormType.AllowInsert = True
        Me.FormType.AllowUpdate = True
        Me.FormType.ButtonClick = True
        Me.FormType.Caption = "Form type"
        Me.FormType.CFLColumnHide = ""
        Me.FormType.CFLKeyField = ""
        Me.FormType.CFLPage = False
        Me.FormType.CFLReturn0 = ""
        Me.FormType.CFLReturn1 = ""
        Me.FormType.CFLReturn2 = ""
        Me.FormType.CFLReturn3 = ""
        Me.FormType.CFLReturn4 = ""
        Me.FormType.CFLReturn5 = ""
        Me.FormType.CFLReturn6 = ""
        Me.FormType.CFLReturn7 = ""
        Me.FormType.CFLShowLoad = False
        Me.FormType.ChangeFormStatus = True
        Me.FormType.ColumnKey = False
        Me.FormType.ComboLine = 5
        Me.FormType.CopyFromItem = ""
        Me.FormType.DefaultButtonClick = False
        Me.FormType.Digit = False
        Me.FormType.FieldType = "C"
        Me.FormType.FieldView = "FormType"
        Me.FormType.FormarNumber = True
        Me.FormType.FormList = False
        Me.FormType.KeyInsert = ""
        Me.FormType.LocalDecimal = False
        Me.FormType.Name = "FormType"
        Me.FormType.NoUpdate = ""
        Me.FormType.NumberDecimal = 0
        Me.FormType.ParentControl = ""
        Me.FormType.RefreshSource = False
        Me.FormType.Required = False
        Me.FormType.SequenceName = ""
        Me.FormType.ShowCalc = True
        Me.FormType.ShowDataTime = False
        Me.FormType.ShowOnlyTime = False
        Me.FormType.SQLString = ""
        Me.FormType.UpdateIfNull = ""
        Me.FormType.UpdateWhenFormLock = False
        Me.FormType.UpperValue = False
        Me.FormType.ValidateValue = True
        Me.FormType.Visible = True
        Me.FormType.VisibleIndex = 2
        '
        'ItemName
        '
        Me.ItemName.AllowInsert = True
        Me.ItemName.AllowUpdate = True
        Me.ItemName.ButtonClick = True
        Me.ItemName.Caption = "Item Name"
        Me.ItemName.CFLColumnHide = ""
        Me.ItemName.CFLKeyField = ""
        Me.ItemName.CFLPage = False
        Me.ItemName.CFLReturn0 = ""
        Me.ItemName.CFLReturn1 = ""
        Me.ItemName.CFLReturn2 = ""
        Me.ItemName.CFLReturn3 = ""
        Me.ItemName.CFLReturn4 = ""
        Me.ItemName.CFLReturn5 = ""
        Me.ItemName.CFLReturn6 = ""
        Me.ItemName.CFLReturn7 = ""
        Me.ItemName.CFLShowLoad = False
        Me.ItemName.ChangeFormStatus = True
        Me.ItemName.ColumnKey = False
        Me.ItemName.ComboLine = 5
        Me.ItemName.CopyFromItem = ""
        Me.ItemName.DefaultButtonClick = False
        Me.ItemName.Digit = False
        Me.ItemName.FieldType = "C"
        Me.ItemName.FieldView = "ItemName"
        Me.ItemName.FormarNumber = True
        Me.ItemName.FormList = False
        Me.ItemName.KeyInsert = ""
        Me.ItemName.LocalDecimal = False
        Me.ItemName.Name = "ItemName"
        Me.ItemName.NoUpdate = ""
        Me.ItemName.NumberDecimal = 0
        Me.ItemName.ParentControl = ""
        Me.ItemName.RefreshSource = False
        Me.ItemName.Required = False
        Me.ItemName.SequenceName = ""
        Me.ItemName.ShowCalc = True
        Me.ItemName.ShowDataTime = False
        Me.ItemName.ShowOnlyTime = False
        Me.ItemName.SQLString = ""
        Me.ItemName.UpdateIfNull = ""
        Me.ItemName.UpdateWhenFormLock = False
        Me.ItemName.UpperValue = False
        Me.ItemName.ValidateValue = True
        Me.ItemName.Visible = True
        Me.ItemName.VisibleIndex = 3
        Me.ItemName.Width = 150
        '
        'ColName
        '
        Me.ColName.AllowInsert = True
        Me.ColName.AllowUpdate = True
        Me.ColName.ButtonClick = True
        Me.ColName.Caption = "Column Name"
        Me.ColName.CFLColumnHide = ""
        Me.ColName.CFLKeyField = ""
        Me.ColName.CFLPage = False
        Me.ColName.CFLReturn0 = ""
        Me.ColName.CFLReturn1 = ""
        Me.ColName.CFLReturn2 = ""
        Me.ColName.CFLReturn3 = ""
        Me.ColName.CFLReturn4 = ""
        Me.ColName.CFLReturn5 = ""
        Me.ColName.CFLReturn6 = ""
        Me.ColName.CFLReturn7 = ""
        Me.ColName.CFLShowLoad = False
        Me.ColName.ChangeFormStatus = True
        Me.ColName.ColumnKey = False
        Me.ColName.ComboLine = 5
        Me.ColName.CopyFromItem = ""
        Me.ColName.DefaultButtonClick = False
        Me.ColName.Digit = False
        Me.ColName.FieldType = "C"
        Me.ColName.FieldView = "ColName"
        Me.ColName.FormarNumber = True
        Me.ColName.FormList = False
        Me.ColName.KeyInsert = ""
        Me.ColName.LocalDecimal = False
        Me.ColName.Name = "ColName"
        Me.ColName.NoUpdate = ""
        Me.ColName.NumberDecimal = 0
        Me.ColName.ParentControl = ""
        Me.ColName.RefreshSource = False
        Me.ColName.Required = False
        Me.ColName.SequenceName = ""
        Me.ColName.ShowCalc = True
        Me.ColName.ShowDataTime = False
        Me.ColName.ShowOnlyTime = False
        Me.ColName.SQLString = ""
        Me.ColName.UpdateIfNull = ""
        Me.ColName.UpdateWhenFormLock = False
        Me.ColName.UpperValue = False
        Me.ColName.ValidateValue = True
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 4
        Me.ColName.Width = 150
        '
        'sRequired
        '
        Me.sRequired.AllowInsert = True
        Me.sRequired.AllowUpdate = True
        Me.sRequired.ButtonClick = True
        Me.sRequired.Caption = "Required"
        Me.sRequired.CFLColumnHide = ""
        Me.sRequired.CFLKeyField = ""
        Me.sRequired.CFLPage = False
        Me.sRequired.CFLReturn0 = ""
        Me.sRequired.CFLReturn1 = ""
        Me.sRequired.CFLReturn2 = ""
        Me.sRequired.CFLReturn3 = ""
        Me.sRequired.CFLReturn4 = ""
        Me.sRequired.CFLReturn5 = ""
        Me.sRequired.CFLReturn6 = ""
        Me.sRequired.CFLReturn7 = ""
        Me.sRequired.CFLShowLoad = False
        Me.sRequired.ChangeFormStatus = True
        Me.sRequired.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.sRequired.ColumnKey = False
        Me.sRequired.ComboLine = 5
        Me.sRequired.CopyFromItem = ""
        Me.sRequired.DefaultButtonClick = False
        Me.sRequired.Digit = False
        Me.sRequired.FieldType = "C"
        Me.sRequired.FieldView = "sRequired"
        Me.sRequired.FormarNumber = True
        Me.sRequired.FormList = False
        Me.sRequired.KeyInsert = ""
        Me.sRequired.LocalDecimal = False
        Me.sRequired.Name = "sRequired"
        Me.sRequired.NoUpdate = ""
        Me.sRequired.NumberDecimal = 0
        Me.sRequired.ParentControl = ""
        Me.sRequired.RefreshSource = False
        Me.sRequired.Required = False
        Me.sRequired.SequenceName = ""
        Me.sRequired.ShowCalc = True
        Me.sRequired.ShowDataTime = False
        Me.sRequired.ShowOnlyTime = False
        Me.sRequired.SQLString = ""
        Me.sRequired.UpdateIfNull = ""
        Me.sRequired.UpdateWhenFormLock = False
        Me.sRequired.UpperValue = False
        Me.sRequired.ValidateValue = True
        Me.sRequired.Visible = True
        Me.sRequired.VisibleIndex = 5
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'sLock
        '
        Me.sLock.AllowInsert = True
        Me.sLock.AllowUpdate = True
        Me.sLock.ButtonClick = True
        Me.sLock.Caption = "Locked"
        Me.sLock.CFLColumnHide = ""
        Me.sLock.CFLKeyField = ""
        Me.sLock.CFLPage = False
        Me.sLock.CFLReturn0 = ""
        Me.sLock.CFLReturn1 = ""
        Me.sLock.CFLReturn2 = ""
        Me.sLock.CFLReturn3 = ""
        Me.sLock.CFLReturn4 = ""
        Me.sLock.CFLReturn5 = ""
        Me.sLock.CFLReturn6 = ""
        Me.sLock.CFLReturn7 = ""
        Me.sLock.CFLShowLoad = False
        Me.sLock.ChangeFormStatus = True
        Me.sLock.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.sLock.ColumnKey = False
        Me.sLock.ComboLine = 5
        Me.sLock.CopyFromItem = ""
        Me.sLock.DefaultButtonClick = False
        Me.sLock.Digit = False
        Me.sLock.FieldType = "C"
        Me.sLock.FieldView = "sLock"
        Me.sLock.FormarNumber = True
        Me.sLock.FormList = False
        Me.sLock.KeyInsert = ""
        Me.sLock.LocalDecimal = False
        Me.sLock.Name = "sLock"
        Me.sLock.NoUpdate = ""
        Me.sLock.NumberDecimal = 0
        Me.sLock.ParentControl = ""
        Me.sLock.RefreshSource = False
        Me.sLock.Required = False
        Me.sLock.SequenceName = ""
        Me.sLock.ShowCalc = True
        Me.sLock.ShowDataTime = False
        Me.sLock.ShowOnlyTime = False
        Me.sLock.SQLString = ""
        Me.sLock.UpdateIfNull = ""
        Me.sLock.UpdateWhenFormLock = False
        Me.sLock.UpperValue = False
        Me.sLock.ValidateValue = True
        Me.sLock.Visible = True
        Me.sLock.VisibleIndex = 6
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'ID
        '
        Me.ID.AllowInsert = False
        Me.ID.AllowUpdate = False
        Me.ID.ButtonClick = True
        Me.ID.Caption = "GridColumn6"
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
        Me.ID.Width = 20
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(984, 28)
        Me.ToolStrip2.TabIndex = 474
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
        'FrmKhaiBaoThuocTinh
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 516)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmKhaiBaoThuocTinh"
        Me.ShowFormMessage = True
        Me.Text = "Cấu hình item"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents FormName As U_TextBox.GridColumn
    Friend WithEvents DESCRIPTION As U_TextBox.GridColumn
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents FormType As U_TextBox.GridColumn
    Friend WithEvents ItemName As U_TextBox.GridColumn
    Friend WithEvents ColName As U_TextBox.GridColumn
    Friend WithEvents sRequired As U_TextBox.GridColumn
    Friend WithEvents sLock As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
