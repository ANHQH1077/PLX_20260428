<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKhachHang_TD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKhachHang_TD))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ID = New U_TextBox.GridColumn()
        Me.MaKhachHang = New U_TextBox.GridColumn()
        Me.MaTuyenDuong = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.txtMaKhachHang = New U_TextBox.U_TextBox()
        Me.U_CheckBox1 = New U_TextBox.U_CheckBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaKhachHang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CheckBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(218, 28)
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
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.First.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Last.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(2, 38)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(212, 227)
        Me.TrueDBGrid1.TabIndex = 474
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ID, Me.MaKhachHang, Me.MaTuyenDuong, Me.CHECKUPD})
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
        Me.GridView1.TableName = "tblKhachHang_TD"
        Me.GridView1.ViewName = "FPT_tblKhachHang_TD_v"
        Me.GridView1.Where = Nothing
        '
        'ID
        '
        Me.ID.AllowInsert = False
        Me.ID.AllowUpdate = False
        Me.ID.ButtonClick = True
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
        '
        'MaKhachHang
        '
        Me.MaKhachHang.AllowInsert = True
        Me.MaKhachHang.AllowUpdate = True
        Me.MaKhachHang.ButtonClick = True
        Me.MaKhachHang.Caption = "Mã khách hang"
        Me.MaKhachHang.CFLColumnHide = ""
        Me.MaKhachHang.CFLKeyField = ""
        Me.MaKhachHang.CFLPage = False
        Me.MaKhachHang.CFLReturn0 = ""
        Me.MaKhachHang.CFLReturn1 = ""
        Me.MaKhachHang.CFLReturn2 = ""
        Me.MaKhachHang.CFLReturn3 = ""
        Me.MaKhachHang.CFLReturn4 = ""
        Me.MaKhachHang.CFLReturn5 = ""
        Me.MaKhachHang.CFLReturn6 = ""
        Me.MaKhachHang.CFLReturn7 = ""
        Me.MaKhachHang.CFLShowLoad = False
        Me.MaKhachHang.ChangeFormStatus = True
        Me.MaKhachHang.ColumnKey = False
        Me.MaKhachHang.ComboLine = 5
        Me.MaKhachHang.CopyFromItem = ":TxtMaKhachHang"
        Me.MaKhachHang.DefaultButtonClick = False
        Me.MaKhachHang.Digit = False
        Me.MaKhachHang.FieldType = "C"
        Me.MaKhachHang.FieldView = "MaKhachHang"
        Me.MaKhachHang.FormarNumber = True
        Me.MaKhachHang.FormList = False
        Me.MaKhachHang.KeyInsert = ""
        Me.MaKhachHang.LocalDecimal = False
        Me.MaKhachHang.Name = "MaKhachHang"
        Me.MaKhachHang.NoUpdate = ""
        Me.MaKhachHang.NumberDecimal = 0
        Me.MaKhachHang.ParentControl = ""
        Me.MaKhachHang.RefreshSource = False
        Me.MaKhachHang.Required = False
        Me.MaKhachHang.SequenceName = ""
        Me.MaKhachHang.ShowCalc = True
        Me.MaKhachHang.ShowDataTime = False
        Me.MaKhachHang.ShowOnlyTime = False
        Me.MaKhachHang.SQLString = ""
        Me.MaKhachHang.UpdateIfNull = ""
        Me.MaKhachHang.UpdateWhenFormLock = False
        Me.MaKhachHang.UpperValue = False
        Me.MaKhachHang.ValidateValue = True
        Me.MaKhachHang.Visible = True
        Me.MaKhachHang.Width = 120
        '
        'MaTuyenDuong
        '
        Me.MaTuyenDuong.AllowInsert = True
        Me.MaTuyenDuong.AllowUpdate = True
        Me.MaTuyenDuong.ButtonClick = True
        Me.MaTuyenDuong.Caption = "MaTuyenDuong"
        Me.MaTuyenDuong.CFLColumnHide = ""
        Me.MaTuyenDuong.CFLKeyField = "MaTuyenDuong"
        Me.MaTuyenDuong.CFLPage = False
        Me.MaTuyenDuong.CFLReturn0 = ""
        Me.MaTuyenDuong.CFLReturn1 = ""
        Me.MaTuyenDuong.CFLReturn2 = ""
        Me.MaTuyenDuong.CFLReturn3 = ""
        Me.MaTuyenDuong.CFLReturn4 = ""
        Me.MaTuyenDuong.CFLReturn5 = ""
        Me.MaTuyenDuong.CFLReturn6 = ""
        Me.MaTuyenDuong.CFLReturn7 = ""
        Me.MaTuyenDuong.CFLShowLoad = False
        Me.MaTuyenDuong.ChangeFormStatus = True
        Me.MaTuyenDuong.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.MaTuyenDuong.ColumnKey = False
        Me.MaTuyenDuong.ComboLine = 5
        Me.MaTuyenDuong.CopyFromItem = ""
        Me.MaTuyenDuong.DefaultButtonClick = False
        Me.MaTuyenDuong.Digit = False
        Me.MaTuyenDuong.FieldType = "C"
        Me.MaTuyenDuong.FieldView = "MaTuyenDuong"
        Me.MaTuyenDuong.FormarNumber = True
        Me.MaTuyenDuong.FormList = False
        Me.MaTuyenDuong.KeyInsert = ""
        Me.MaTuyenDuong.LocalDecimal = False
        Me.MaTuyenDuong.Name = "MaTuyenDuong"
        Me.MaTuyenDuong.NoUpdate = ""
        Me.MaTuyenDuong.NumberDecimal = 0
        Me.MaTuyenDuong.ParentControl = ""
        Me.MaTuyenDuong.RefreshSource = False
        Me.MaTuyenDuong.Required = True
        Me.MaTuyenDuong.SequenceName = ""
        Me.MaTuyenDuong.ShowCalc = True
        Me.MaTuyenDuong.ShowDataTime = False
        Me.MaTuyenDuong.ShowOnlyTime = False
        Me.MaTuyenDuong.SQLString = "  select MaTuyenDuong , DiemKhoiHanh, DiemDen, DGTuyenDuong, DGDiemDen from tblGi" & _
            "aoNhan"
        Me.MaTuyenDuong.UpdateIfNull = ""
        Me.MaTuyenDuong.UpdateWhenFormLock = False
        Me.MaTuyenDuong.UpperValue = False
        Me.MaTuyenDuong.ValidateValue = True
        Me.MaTuyenDuong.Visible = True
        Me.MaTuyenDuong.VisibleIndex = 0
        Me.MaTuyenDuong.Width = 150
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
        Me.CHECKUPD.ButtonClick = True
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
        'txtMaKhachHang
        '
        Me.txtMaKhachHang.AllowInsert = False
        Me.txtMaKhachHang.AllowUpdate = False
        Me.txtMaKhachHang.AutoKeyFix = ""
        Me.txtMaKhachHang.AutoKeyName = ""
        Me.txtMaKhachHang.BindingSourceName = ""
        Me.txtMaKhachHang.ChangeFormStatus = False
        Me.txtMaKhachHang.CopyFromItem = ""
        Me.txtMaKhachHang.DefaultValue = ""
        Me.txtMaKhachHang.FieldName = ""
        Me.txtMaKhachHang.FieldType = "C"
        Me.txtMaKhachHang.KeyInsert = ""
        Me.txtMaKhachHang.LinkLabel = ""
        Me.txtMaKhachHang.Location = New System.Drawing.Point(289, 89)
        Me.txtMaKhachHang.Name = "txtMaKhachHang"
        Me.txtMaKhachHang.NoUpdate = "N"
        Me.txtMaKhachHang.PrimaryKey = ""
        Me.txtMaKhachHang.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtMaKhachHang.Properties.Appearance.Options.UseFont = True
        Me.txtMaKhachHang.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtMaKhachHang.Properties.AppearanceDisabled.Options.UseFont = True
        Me.txtMaKhachHang.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtMaKhachHang.Properties.AppearanceFocused.Options.UseFont = True
        Me.txtMaKhachHang.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtMaKhachHang.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.txtMaKhachHang.Properties.AutoHeight = False
        Me.txtMaKhachHang.Properties.ReadOnly = True
        Me.txtMaKhachHang.Required = ""
        Me.txtMaKhachHang.Size = New System.Drawing.Size(76, 26)
        Me.txtMaKhachHang.TabIndex = 477
        Me.txtMaKhachHang.TableName = ""
        Me.txtMaKhachHang.TabStop = False
        Me.txtMaKhachHang.UpdateIfNull = ""
        Me.txtMaKhachHang.UpdateWhenFormLock = False
        Me.txtMaKhachHang.UpperValue = False
        Me.txtMaKhachHang.ViewName = ""
        '
        'U_CheckBox1
        '
        Me.U_CheckBox1.AllowInsert = True
        Me.U_CheckBox1.AllowUpdate = True
        Me.U_CheckBox1.BindingSourceName = ""
        Me.U_CheckBox1.ChangeFormStatus = True
        Me.U_CheckBox1.CheckValue = "Y"
        Me.U_CheckBox1.CopyFromItem = ""
        Me.U_CheckBox1.DefaultValue = ""
        Me.U_CheckBox1.FieldName = ""
        Me.U_CheckBox1.FieldType = ""
        Me.U_CheckBox1.ItemValue = ""
        Me.U_CheckBox1.KeyInsert = ""
        Me.U_CheckBox1.LinkLabel = ""
        Me.U_CheckBox1.Location = New System.Drawing.Point(43, 277)
        Me.U_CheckBox1.Name = "U_CheckBox1"
        Me.U_CheckBox1.NoUpdate = ""
        Me.U_CheckBox1.PrimaryKey = ""
        Me.U_CheckBox1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.U_CheckBox1.Properties.Appearance.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_CheckBox1.Properties.AutoHeight = False
        Me.U_CheckBox1.Properties.Caption = "Kiểm tra gán TD"
        Me.U_CheckBox1.Required = ""
        Me.U_CheckBox1.Size = New System.Drawing.Size(169, 30)
        Me.U_CheckBox1.TabIndex = 478
        Me.U_CheckBox1.TableName = ""
        Me.U_CheckBox1.UnCheckValue = "N"
        Me.U_CheckBox1.UpdateIfNull = ""
        Me.U_CheckBox1.UpdateWhenFormLock = False
        Me.U_CheckBox1.ViewName = ""
        '
        'FrmKhachHang_TD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(218, 327)
        Me.Controls.Add(Me.U_CheckBox1)
        Me.Controls.Add(Me.txtMaKhachHang)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmKhachHang_TD"
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.txtMaKhachHang, 0)
        Me.Controls.SetChildIndex(Me.U_CheckBox1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaKhachHang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CheckBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ID As U_TextBox.GridColumn
    Friend WithEvents MaKhachHang As U_TextBox.GridColumn
    Friend WithEvents MaTuyenDuong As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents txtMaKhachHang As U_TextBox.U_TextBox
    Friend WithEvents U_CheckBox1 As U_TextBox.U_CheckBox
End Class
