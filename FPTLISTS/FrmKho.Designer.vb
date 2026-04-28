<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKho
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKho))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.MaKho = New U_TextBox.GridColumn()
        Me.TenKho = New U_TextBox.GridColumn()
        Me.MaDonVi = New U_TextBox.GridColumn()
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
        Me.TrueDBGrid1.Location = New System.Drawing.Point(5, 33)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(623, 389)
        Me.TrueDBGrid1.TabIndex = 2
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = "MaKho"
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "C"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MaKho, Me.TenKho, Me.MaDonVi})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OrderBy = "MaKho"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblKho"
        Me.GridView1.ViewName = "tblKho"
        Me.GridView1.Where = Nothing
        '
        'MaKho
        '
        Me.MaKho.AllowInsert = True
        Me.MaKho.AllowUpdate = True
        Me.MaKho.ButtonClick = True
        Me.MaKho.Caption = "Mã kho"
        Me.MaKho.CFLColumnHide = ""
        Me.MaKho.CFLKeyField = ""
        Me.MaKho.CFLPage = False
        Me.MaKho.CFLReturn0 = ""
        Me.MaKho.CFLReturn1 = ""
        Me.MaKho.CFLReturn2 = ""
        Me.MaKho.CFLReturn3 = ""
        Me.MaKho.CFLReturn4 = ""
        Me.MaKho.CFLReturn5 = ""
        Me.MaKho.CFLReturn6 = ""
        Me.MaKho.CFLReturn7 = ""
        Me.MaKho.CFLShowLoad = False
        Me.MaKho.ChangeFormStatus = True
        Me.MaKho.ColumnKey = True
        Me.MaKho.ComboLine = 5
        Me.MaKho.CopyFromItem = ""
        Me.MaKho.DefaultButtonClick = False
        Me.MaKho.Digit = False
        Me.MaKho.FieldType = "C"
        Me.MaKho.FieldView = "MaKho"
        Me.MaKho.FormarNumber = True
        Me.MaKho.FormList = False
        Me.MaKho.KeyInsert = ""
        Me.MaKho.LocalDecimal = False
        Me.MaKho.Name = "MaKho"
        Me.MaKho.NoUpdate = ""
        Me.MaKho.NumberDecimal = 0
        Me.MaKho.ParentControl = ""
        Me.MaKho.RefreshSource = False
        Me.MaKho.Required = False
        Me.MaKho.SequenceName = ""
        Me.MaKho.ShowCalc = True
        Me.MaKho.ShowDataTime = False
        Me.MaKho.ShowOnlyTime = False
        Me.MaKho.SQLString = ""
        Me.MaKho.UpdateIfNull = ""
        Me.MaKho.UpdateWhenFormLock = False
        Me.MaKho.ValidateValue = True
        Me.MaKho.Visible = True
        Me.MaKho.VisibleIndex = 0
        Me.MaKho.Width = 120
        '
        'TenKho
        '
        Me.TenKho.AllowInsert = True
        Me.TenKho.AllowUpdate = True
        Me.TenKho.ButtonClick = True
        Me.TenKho.Caption = "Tên kho"
        Me.TenKho.CFLColumnHide = ""
        Me.TenKho.CFLKeyField = ""
        Me.TenKho.CFLPage = False
        Me.TenKho.CFLReturn0 = ""
        Me.TenKho.CFLReturn1 = ""
        Me.TenKho.CFLReturn2 = ""
        Me.TenKho.CFLReturn3 = ""
        Me.TenKho.CFLReturn4 = ""
        Me.TenKho.CFLReturn5 = ""
        Me.TenKho.CFLReturn6 = ""
        Me.TenKho.CFLReturn7 = ""
        Me.TenKho.CFLShowLoad = False
        Me.TenKho.ChangeFormStatus = True
        Me.TenKho.ColumnKey = False
        Me.TenKho.ComboLine = 5
        Me.TenKho.CopyFromItem = ""
        Me.TenKho.DefaultButtonClick = False
        Me.TenKho.Digit = False
        Me.TenKho.FieldType = "C"
        Me.TenKho.FieldView = "TenKho"
        Me.TenKho.FormarNumber = True
        Me.TenKho.FormList = False
        Me.TenKho.KeyInsert = ""
        Me.TenKho.LocalDecimal = False
        Me.TenKho.Name = "TenKho"
        Me.TenKho.NoUpdate = ""
        Me.TenKho.NumberDecimal = 0
        Me.TenKho.ParentControl = ""
        Me.TenKho.RefreshSource = False
        Me.TenKho.Required = False
        Me.TenKho.SequenceName = ""
        Me.TenKho.ShowCalc = True
        Me.TenKho.ShowDataTime = False
        Me.TenKho.ShowOnlyTime = False
        Me.TenKho.SQLString = ""
        Me.TenKho.UpdateIfNull = ""
        Me.TenKho.UpdateWhenFormLock = False
        Me.TenKho.ValidateValue = True
        Me.TenKho.Visible = True
        Me.TenKho.VisibleIndex = 1
        Me.TenKho.Width = 450
        '
        'MaDonVi
        '
        Me.MaDonVi.AllowInsert = True
        Me.MaDonVi.AllowUpdate = True
        Me.MaDonVi.ButtonClick = True
        Me.MaDonVi.Caption = "GridColumn3"
        Me.MaDonVi.CFLColumnHide = ""
        Me.MaDonVi.CFLKeyField = ""
        Me.MaDonVi.CFLPage = False
        Me.MaDonVi.CFLReturn0 = ""
        Me.MaDonVi.CFLReturn1 = ""
        Me.MaDonVi.CFLReturn2 = ""
        Me.MaDonVi.CFLReturn3 = ""
        Me.MaDonVi.CFLReturn4 = ""
        Me.MaDonVi.CFLReturn5 = ""
        Me.MaDonVi.CFLReturn6 = ""
        Me.MaDonVi.CFLReturn7 = ""
        Me.MaDonVi.CFLShowLoad = False
        Me.MaDonVi.ChangeFormStatus = True
        Me.MaDonVi.ColumnKey = False
        Me.MaDonVi.ComboLine = 5
        Me.MaDonVi.CopyFromItem = ""
        Me.MaDonVi.DefaultButtonClick = False
        Me.MaDonVi.Digit = False
        Me.MaDonVi.FieldType = "C"
        Me.MaDonVi.FieldView = "MaDonVi"
        Me.MaDonVi.FormarNumber = True
        Me.MaDonVi.FormList = False
        Me.MaDonVi.KeyInsert = ""
        Me.MaDonVi.LocalDecimal = False
        Me.MaDonVi.Name = "MaDonVi"
        Me.MaDonVi.NoUpdate = ""
        Me.MaDonVi.NumberDecimal = 0
        Me.MaDonVi.ParentControl = ""
        Me.MaDonVi.RefreshSource = False
        Me.MaDonVi.Required = False
        Me.MaDonVi.SequenceName = ""
        Me.MaDonVi.ShowCalc = True
        Me.MaDonVi.ShowDataTime = False
        Me.MaDonVi.ShowOnlyTime = False
        Me.MaDonVi.SQLString = ""
        Me.MaDonVi.UpdateIfNull = ""
        Me.MaDonVi.UpdateWhenFormLock = False
        Me.MaDonVi.ValidateValue = True
        Me.MaDonVi.Visible = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(633, 28)
        Me.ToolStrip2.TabIndex = 469
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
        'FrmKho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 451)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.MaximizeBox = False
        Me.Name = "FrmKho"
        Me.ShowFormMessage = True
        Me.Text = "Danh sách kho Nhập"
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
    Friend WithEvents MaKho As U_TextBox.GridColumn
    Friend WithEvents TenKho As U_TextBox.GridColumn
    Friend WithEvents MaDonVi As U_TextBox.GridColumn
End Class
