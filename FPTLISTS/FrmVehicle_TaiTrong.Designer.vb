<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVehicle_TaiTrong
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVehicle_TaiTrong))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.txtMaPhuongTien = New U_TextBox.U_TextBox()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ID = New U_TextBox.GridColumn()
        Me.GridColumn3 = New U_TextBox.GridColumn()
        Me.TuNgay = New U_TextBox.GridColumn()
        Me.DenNgay = New U_TextBox.GridColumn()
        Me.TaiTrong = New U_TextBox.GridColumn()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.txtMaPhuongTien.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(409, 28)
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
        'txtMaPhuongTien
        '
        Me.txtMaPhuongTien.AllowInsert = True
        Me.txtMaPhuongTien.AllowUpdate = True
        Me.txtMaPhuongTien.AutoKeyFix = ""
        Me.txtMaPhuongTien.AutoKeyName = ""
        Me.txtMaPhuongTien.BindingSourceName = ""
        Me.txtMaPhuongTien.ChangeFormStatus = False
        Me.txtMaPhuongTien.CopyFromItem = ""
        Me.txtMaPhuongTien.DefaultValue = ""
        Me.txtMaPhuongTien.FieldName = ""
        Me.txtMaPhuongTien.FieldType = "C"
        Me.txtMaPhuongTien.KeyInsert = ""
        Me.txtMaPhuongTien.LinkLabel = ""
        Me.txtMaPhuongTien.Location = New System.Drawing.Point(189, 0)
        Me.txtMaPhuongTien.Name = "txtMaPhuongTien"
        Me.txtMaPhuongTien.NoUpdate = "N"
        Me.txtMaPhuongTien.PrimaryKey = ""
        Me.txtMaPhuongTien.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtMaPhuongTien.Properties.Appearance.Options.UseFont = True
        Me.txtMaPhuongTien.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtMaPhuongTien.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtMaPhuongTien.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtMaPhuongTien.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtMaPhuongTien.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtMaPhuongTien.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtMaPhuongTien.Properties.AutoHeight = False
        Me.txtMaPhuongTien.Required = ""
        Me.txtMaPhuongTien.Size = New System.Drawing.Size(0, 30)
        Me.txtMaPhuongTien.TabIndex = 473
        Me.txtMaPhuongTien.TableName = ""
        Me.txtMaPhuongTien.TabStop = False
        Me.txtMaPhuongTien.UpdateIfNull = ""
        Me.txtMaPhuongTien.UpdateWhenFormLock = False
        Me.txtMaPhuongTien.UpperValue = False
        Me.txtMaPhuongTien.ViewName = ""
        Me.txtMaPhuongTien.Visible = False
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(4, 31)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(400, 235)
        Me.TrueDBGrid1.TabIndex = 475
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ID, Me.GridColumn3, Me.TuNgay, Me.DenNgay, Me.TaiTrong})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "ID Desc"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblPhuongTien_TaiTrong"
        Me.GridView1.ViewName = "tblPhuongTien_TaiTrong"
        Me.GridView1.Where = "MaPhuongTien=:txtMaPhuongTien"
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
        Me.ID.FormList = False
        Me.ID.KeyInsert = ""
        Me.ID.LocalDecimal = False
        Me.ID.Name = "ID"
        Me.ID.NoUpdate = ""
        Me.ID.NumberDecimal = 0
        Me.ID.ParentControl = ""
        Me.ID.RefreshSource = False
        Me.ID.Required = False
        Me.ID.ShowCalc = True
        Me.ID.ShowDataTime = False
        Me.ID.ShowOnlyTime = False
        Me.ID.SQLString = ""
        Me.ID.UpdateIfNull = ""
        Me.ID.UpdateWhenFormLock = False
        Me.ID.ValidateValue = True
        Me.ID.Visible = True
        '
        'GridColumn3
        '
        Me.GridColumn3.AllowInsert = True
        Me.GridColumn3.AllowUpdate = False
        Me.GridColumn3.ButtonClick = True
        Me.GridColumn3.Caption = "MaPhuongTien"
        Me.GridColumn3.CFLColumnHide = ""
        Me.GridColumn3.CFLKeyField = ""
        Me.GridColumn3.CFLPage = False
        Me.GridColumn3.CFLReturn0 = ""
        Me.GridColumn3.CFLReturn1 = ""
        Me.GridColumn3.CFLReturn2 = ""
        Me.GridColumn3.CFLReturn3 = ""
        Me.GridColumn3.CFLReturn4 = ""
        Me.GridColumn3.CFLReturn5 = ""
        Me.GridColumn3.CFLReturn6 = ""
        Me.GridColumn3.CFLReturn7 = ""
        Me.GridColumn3.CFLShowLoad = False
        Me.GridColumn3.ChangeFormStatus = True
        Me.GridColumn3.ColumnKey = False
        Me.GridColumn3.ComboLine = 5
        Me.GridColumn3.CopyFromItem = ""
        Me.GridColumn3.DefaultButtonClick = False
        Me.GridColumn3.Digit = False
        Me.GridColumn3.FieldType = "C"
        Me.GridColumn3.FieldView = "MaPhuongTien"
        Me.GridColumn3.FormList = False
        Me.GridColumn3.KeyInsert = ""
        Me.GridColumn3.LocalDecimal = False
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.NoUpdate = ""
        Me.GridColumn3.NumberDecimal = 0
        Me.GridColumn3.ParentControl = ""
        Me.GridColumn3.RefreshSource = False
        Me.GridColumn3.Required = False
        Me.GridColumn3.ShowCalc = True
        Me.GridColumn3.ShowDataTime = False
        Me.GridColumn3.ShowOnlyTime = False
        Me.GridColumn3.SQLString = ""
        Me.GridColumn3.UpdateIfNull = ""
        Me.GridColumn3.UpdateWhenFormLock = False
        Me.GridColumn3.ValidateValue = True
        Me.GridColumn3.Visible = True
        '
        'TuNgay
        '
        Me.TuNgay.AllowInsert = True
        Me.TuNgay.AllowUpdate = True
        Me.TuNgay.ButtonClick = True
        Me.TuNgay.Caption = "Ngày hiệu lực"
        Me.TuNgay.CFLColumnHide = ""
        Me.TuNgay.CFLKeyField = ""
        Me.TuNgay.CFLPage = False
        Me.TuNgay.CFLReturn0 = ""
        Me.TuNgay.CFLReturn1 = ""
        Me.TuNgay.CFLReturn2 = ""
        Me.TuNgay.CFLReturn3 = ""
        Me.TuNgay.CFLReturn4 = ""
        Me.TuNgay.CFLReturn5 = ""
        Me.TuNgay.CFLReturn6 = ""
        Me.TuNgay.CFLReturn7 = ""
        Me.TuNgay.CFLShowLoad = False
        Me.TuNgay.ChangeFormStatus = True
        Me.TuNgay.ColumnKey = False
        Me.TuNgay.ComboLine = 5
        Me.TuNgay.CopyFromItem = ""
        Me.TuNgay.DefaultButtonClick = False
        Me.TuNgay.Digit = False
        Me.TuNgay.FieldType = "D"
        Me.TuNgay.FieldView = "TuNgay"
        Me.TuNgay.FormList = False
        Me.TuNgay.KeyInsert = ""
        Me.TuNgay.LocalDecimal = False
        Me.TuNgay.Name = "TuNgay"
        Me.TuNgay.NoUpdate = ""
        Me.TuNgay.NumberDecimal = 0
        Me.TuNgay.ParentControl = ""
        Me.TuNgay.RefreshSource = False
        Me.TuNgay.Required = False
        Me.TuNgay.ShowCalc = True
        Me.TuNgay.ShowDataTime = False
        Me.TuNgay.ShowOnlyTime = False
        Me.TuNgay.SQLString = ""
        Me.TuNgay.UpdateIfNull = ""
        Me.TuNgay.UpdateWhenFormLock = False
        Me.TuNgay.ValidateValue = True
        Me.TuNgay.Visible = True
        Me.TuNgay.VisibleIndex = 0
        '
        'DenNgay
        '
        Me.DenNgay.AllowInsert = True
        Me.DenNgay.AllowUpdate = True
        Me.DenNgay.ButtonClick = True
        Me.DenNgay.Caption = "Ngày hết hiệu lực"
        Me.DenNgay.CFLColumnHide = ""
        Me.DenNgay.CFLKeyField = ""
        Me.DenNgay.CFLPage = False
        Me.DenNgay.CFLReturn0 = ""
        Me.DenNgay.CFLReturn1 = ""
        Me.DenNgay.CFLReturn2 = ""
        Me.DenNgay.CFLReturn3 = ""
        Me.DenNgay.CFLReturn4 = ""
        Me.DenNgay.CFLReturn5 = ""
        Me.DenNgay.CFLReturn6 = ""
        Me.DenNgay.CFLReturn7 = ""
        Me.DenNgay.CFLShowLoad = False
        Me.DenNgay.ChangeFormStatus = True
        Me.DenNgay.ColumnKey = False
        Me.DenNgay.ComboLine = 5
        Me.DenNgay.CopyFromItem = ""
        Me.DenNgay.DefaultButtonClick = False
        Me.DenNgay.Digit = False
        Me.DenNgay.FieldType = "D"
        Me.DenNgay.FieldView = "DenNgay"
        Me.DenNgay.FormList = False
        Me.DenNgay.KeyInsert = ""
        Me.DenNgay.LocalDecimal = False
        Me.DenNgay.Name = "DenNgay"
        Me.DenNgay.NoUpdate = ""
        Me.DenNgay.NumberDecimal = 0
        Me.DenNgay.ParentControl = ""
        Me.DenNgay.RefreshSource = False
        Me.DenNgay.Required = False
        Me.DenNgay.ShowCalc = True
        Me.DenNgay.ShowDataTime = False
        Me.DenNgay.ShowOnlyTime = False
        Me.DenNgay.SQLString = ""
        Me.DenNgay.UpdateIfNull = ""
        Me.DenNgay.UpdateWhenFormLock = False
        Me.DenNgay.ValidateValue = True
        Me.DenNgay.Visible = True
        Me.DenNgay.VisibleIndex = 1
        '
        'TaiTrong
        '
        Me.TaiTrong.AllowInsert = True
        Me.TaiTrong.AllowUpdate = True
        Me.TaiTrong.ButtonClick = True
        Me.TaiTrong.Caption = "Tải trọng"
        Me.TaiTrong.CFLColumnHide = ""
        Me.TaiTrong.CFLKeyField = ""
        Me.TaiTrong.CFLPage = False
        Me.TaiTrong.CFLReturn0 = ""
        Me.TaiTrong.CFLReturn1 = ""
        Me.TaiTrong.CFLReturn2 = ""
        Me.TaiTrong.CFLReturn3 = ""
        Me.TaiTrong.CFLReturn4 = ""
        Me.TaiTrong.CFLReturn5 = ""
        Me.TaiTrong.CFLReturn6 = ""
        Me.TaiTrong.CFLReturn7 = ""
        Me.TaiTrong.CFLShowLoad = False
        Me.TaiTrong.ChangeFormStatus = True
        Me.TaiTrong.ColumnKey = False
        Me.TaiTrong.ComboLine = 5
        Me.TaiTrong.CopyFromItem = ""
        Me.TaiTrong.DefaultButtonClick = False
        Me.TaiTrong.Digit = True
        Me.TaiTrong.FieldType = "N"
        Me.TaiTrong.FieldView = "TaiTrong"
        Me.TaiTrong.FormList = False
        Me.TaiTrong.KeyInsert = ""
        Me.TaiTrong.LocalDecimal = False
        Me.TaiTrong.Name = "TaiTrong"
        Me.TaiTrong.NoUpdate = ""
        Me.TaiTrong.NumberDecimal = 0
        Me.TaiTrong.ParentControl = ""
        Me.TaiTrong.RefreshSource = False
        Me.TaiTrong.Required = False
        Me.TaiTrong.ShowCalc = True
        Me.TaiTrong.ShowDataTime = False
        Me.TaiTrong.ShowOnlyTime = False
        Me.TaiTrong.SQLString = ""
        Me.TaiTrong.UpdateIfNull = ""
        Me.TaiTrong.UpdateWhenFormLock = False
        Me.TaiTrong.ValidateValue = True
        Me.TaiTrong.Visible = True
        Me.TaiTrong.VisibleIndex = 2
        '
        'FrmVehicle_TaiTrong
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 295)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.txtMaPhuongTien)
        Me.Controls.Add(Me.ToolStrip2)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmVehicle_TaiTrong"
        Me.ShowFormMessage = True
        Me.Text = "Tải trọng xe"
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.txtMaPhuongTien, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.txtMaPhuongTien.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtMaPhuongTien As U_TextBox.U_TextBox
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents GridColumn3 As U_TextBox.GridColumn
    Friend WithEvents TuNgay As U_TextBox.GridColumn
    Friend WithEvents TaiTrong As U_TextBox.GridColumn
    Friend WithEvents DenNgay As U_TextBox.GridColumn
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
End Class
