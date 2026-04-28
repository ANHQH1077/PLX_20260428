<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNhietDo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNhietDo))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ID = New U_TextBox.GridColumn()
        Me.CrDate = New U_TextBox.GridColumn()
        Me.NhietDo = New U_TextBox.GridColumn()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(5, 47)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(325, 321)
        Me.TrueDBGrid1.TabIndex = 1
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ID, Me.CrDate, Me.NhietDo, Me.CHECKUPD})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "CrDate Desc"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblNhietDo"
        Me.GridView1.ViewName = "FPT_tblNhietDo_V"
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
        'CrDate
        '
        Me.CrDate.AllowInsert = True
        Me.CrDate.AllowUpdate = True
        Me.CrDate.Caption = "Ngày tháng"
        Me.CrDate.CFLColumnHide = ""
        Me.CrDate.CFLKeyField = ""
        Me.CrDate.CFLPage = False
        Me.CrDate.CFLReturn0 = ""
        Me.CrDate.CFLReturn1 = ""
        Me.CrDate.CFLReturn2 = ""
        Me.CrDate.CFLReturn3 = ""
        Me.CrDate.CFLReturn4 = ""
        Me.CrDate.CFLReturn5 = ""
        Me.CrDate.CFLReturn6 = ""
        Me.CrDate.CFLReturn7 = ""
        Me.CrDate.CFLShowLoad = False
        Me.CrDate.ChangeFormStatus = True
        Me.CrDate.ColumnKey = False
        Me.CrDate.ComboLine = 5
        Me.CrDate.CopyFromItem = ""
        Me.CrDate.DefaultButtonClick = False
        Me.CrDate.Digit = False
        Me.CrDate.FieldType = "D"
        Me.CrDate.FieldView = "CrDate"
        Me.CrDate.FormList = False
        Me.CrDate.KeyInsert = ""
        Me.CrDate.LocalDecimal = False
        Me.CrDate.Name = "CrDate"
        Me.CrDate.NoUpdate = ""
        Me.CrDate.NumberDecimal = 0
        Me.CrDate.ParentControl = ""
        Me.CrDate.RefreshSource = False
        Me.CrDate.Required = False
        Me.CrDate.ShowDataTime = False
        Me.CrDate.SQLString = ""
        Me.CrDate.UpdateIfNull = ""
        Me.CrDate.UpdateWhenFormLock = False
        Me.CrDate.ValidateValue = True
        Me.CrDate.Visible = True
        Me.CrDate.VisibleIndex = 0
        '
        'NhietDo
        '
        Me.NhietDo.AllowInsert = True
        Me.NhietDo.AllowUpdate = True
        Me.NhietDo.Caption = "Nhiệt độ"
        Me.NhietDo.CFLColumnHide = ""
        Me.NhietDo.CFLKeyField = ""
        Me.NhietDo.CFLPage = False
        Me.NhietDo.CFLReturn0 = ""
        Me.NhietDo.CFLReturn1 = ""
        Me.NhietDo.CFLReturn2 = ""
        Me.NhietDo.CFLReturn3 = ""
        Me.NhietDo.CFLReturn4 = ""
        Me.NhietDo.CFLReturn5 = ""
        Me.NhietDo.CFLReturn6 = ""
        Me.NhietDo.CFLReturn7 = ""
        Me.NhietDo.CFLShowLoad = False
        Me.NhietDo.ChangeFormStatus = True
        Me.NhietDo.ColumnKey = False
        Me.NhietDo.ComboLine = 5
        Me.NhietDo.CopyFromItem = ""
        Me.NhietDo.DefaultButtonClick = False
        Me.NhietDo.Digit = True
        Me.NhietDo.FieldType = "N"
        Me.NhietDo.FieldView = "NhietDo"
        Me.NhietDo.FormList = False
        Me.NhietDo.KeyInsert = ""
        Me.NhietDo.LocalDecimal = True
        Me.NhietDo.Name = "NhietDo"
        Me.NhietDo.NoUpdate = ""
        Me.NhietDo.NumberDecimal = 2
        Me.NhietDo.ParentControl = ""
        Me.NhietDo.RefreshSource = False
        Me.NhietDo.Required = False
        Me.NhietDo.ShowDataTime = False
        Me.NhietDo.SQLString = ""
        Me.NhietDo.UpdateIfNull = ""
        Me.NhietDo.UpdateWhenFormLock = False
        Me.NhietDo.ValidateValue = True
        Me.NhietDo.Visible = True
        Me.NhietDo.VisibleIndex = 1
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
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(335, 28)
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
        'FrmNhietDo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 397)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultSave = False
        Me.KeyPreview = True
        Me.Name = "FrmNhietDo"
        Me.ShowFormMessage = True
        Me.Text = "Danh sách nhiệt độ ngày"
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
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents CrDate As U_TextBox.GridColumn
    Friend WithEvents NhietDo As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
End Class
