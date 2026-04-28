<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBatchSlog
    Inherits U_CusForm.XtraCusForm1

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBatchSlog))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ID = New U_TextBox.GridColumn()
        Me.BatchCode = New U_TextBox.GridColumn()
        Me.SlogValue = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 31)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(320, 337)
        Me.TrueDBGrid1.TabIndex = 1
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = "ID"
        Me.GridView1.ColumnKeyIns = False
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ID, Me.BatchCode, Me.SlogValue, Me.CHECKUPD})
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
        Me.GridView1.TableName = "tblBatchSlog"
        Me.GridView1.ViewName = "FPT_tblBatchSlog_V"
        Me.GridView1.Where = Nothing
        '
        'ID
        '
        Me.ID.AllowInsert = False
        Me.ID.AllowUpdate = False
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
        'BatchCode
        '
        Me.BatchCode.AllowInsert = True
        Me.BatchCode.AllowUpdate = True
        Me.BatchCode.Caption = "Mã nguồn"
        Me.BatchCode.CFLColumnHide = ""
        Me.BatchCode.CFLKeyField = ""
        Me.BatchCode.CFLPage = False
        Me.BatchCode.CFLReturn0 = ""
        Me.BatchCode.CFLReturn1 = ""
        Me.BatchCode.CFLReturn2 = ""
        Me.BatchCode.CFLReturn3 = ""
        Me.BatchCode.CFLReturn4 = ""
        Me.BatchCode.CFLReturn5 = ""
        Me.BatchCode.CFLReturn6 = ""
        Me.BatchCode.CFLReturn7 = ""
        Me.BatchCode.CFLShowLoad = False
        Me.BatchCode.ChangeFormStatus = True
        Me.BatchCode.ColumnKey = False
        Me.BatchCode.ComboLine = 5
        Me.BatchCode.CopyFromItem = ""
        Me.BatchCode.DefaultButtonClick = False
        Me.BatchCode.Digit = False
        Me.BatchCode.FieldType = "C"
        Me.BatchCode.FieldView = "BatchCode"
        Me.BatchCode.FormList = False
        Me.BatchCode.KeyInsert = ""
        Me.BatchCode.LocalDecimal = False
        Me.BatchCode.Name = "BatchCode"
        Me.BatchCode.NoUpdate = ""
        Me.BatchCode.NumberDecimal = 0
        Me.BatchCode.ParentControl = ""
        Me.BatchCode.RefreshSource = False
        Me.BatchCode.Required = False
        Me.BatchCode.ShowDataTime = False
        Me.BatchCode.SQLString = ""
        Me.BatchCode.UpdateIfNull = ""
        Me.BatchCode.UpdateWhenFormLock = False
        Me.BatchCode.ValidateValue = True
        Me.BatchCode.Visible = True
        Me.BatchCode.VisibleIndex = 0
        Me.BatchCode.Width = 120
        '
        'SlogValue
        '
        Me.SlogValue.AllowInsert = True
        Me.SlogValue.AllowUpdate = True
        Me.SlogValue.Caption = "Slog"
        Me.SlogValue.CFLColumnHide = ""
        Me.SlogValue.CFLKeyField = ""
        Me.SlogValue.CFLPage = False
        Me.SlogValue.CFLReturn0 = ""
        Me.SlogValue.CFLReturn1 = ""
        Me.SlogValue.CFLReturn2 = ""
        Me.SlogValue.CFLReturn3 = ""
        Me.SlogValue.CFLReturn4 = ""
        Me.SlogValue.CFLReturn5 = ""
        Me.SlogValue.CFLReturn6 = ""
        Me.SlogValue.CFLReturn7 = ""
        Me.SlogValue.CFLShowLoad = False
        Me.SlogValue.ChangeFormStatus = True
        Me.SlogValue.ColumnKey = False
        Me.SlogValue.ComboLine = 5
        Me.SlogValue.CopyFromItem = ""
        Me.SlogValue.DefaultButtonClick = False
        Me.SlogValue.Digit = False
        Me.SlogValue.FieldType = "C"
        Me.SlogValue.FieldView = "SlogValue"
        Me.SlogValue.FormList = False
        Me.SlogValue.KeyInsert = ""
        Me.SlogValue.LocalDecimal = False
        Me.SlogValue.Name = "SlogValue"
        Me.SlogValue.NoUpdate = ""
        Me.SlogValue.NumberDecimal = 0
        Me.SlogValue.ParentControl = ""
        Me.SlogValue.RefreshSource = False
        Me.SlogValue.Required = False
        Me.SlogValue.ShowDataTime = False
        Me.SlogValue.SQLString = ""
        Me.SlogValue.UpdateIfNull = ""
        Me.SlogValue.UpdateWhenFormLock = False
        Me.SlogValue.ValidateValue = True
        Me.SlogValue.Visible = True
        Me.SlogValue.VisibleIndex = 1
        Me.SlogValue.Width = 150
        '
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
        Me.CHECKUPD.Caption = "GridColumn4"
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
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(329, 28)
        Me.ToolStrip2.TabIndex = 472
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
        'FrmBatchSlog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 397)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultSave = False
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmBatchSlog"
        Me.ShowFormMessage = True
        Me.Text = "Danh sách Slog theo Batch"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents BatchCode As U_TextBox.GridColumn
    Friend WithEvents SlogValue As U_TextBox.GridColumn
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
End Class
