<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKhachHang2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKhachHang2))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.MAKHACHHANG = New U_TextBox.GridColumn()
        Me.TENKHACHHANG = New U_TextBox.GridColumn()
        Me.TONGDUXUAT = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.TONGDUXUAT_THUY = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(5, 44)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit2})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(572, 324)
        Me.TrueDBGrid1.TabIndex = 2
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.DetailTip.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.Empty.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.EvenRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FilterPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FocusedRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.GroupButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.GroupFooter.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.GroupPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.HorzLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.OddRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.Preview.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.RowSeparator.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.SelectedRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.TopNewRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.VertLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.ViewCaption.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = "MAKHACHHANG"
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "C"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MAKHACHHANG, Me.TENKHACHHANG, Me.TONGDUXUAT, Me.TONGDUXUAT_THUY, Me.CHECKUPD})
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
        Me.GridView1.TableName = "tblKhachHang_SoLuongSAP"
        Me.GridView1.ViewName = "tblKhachHang_SoLuongSAP_V"
        Me.GridView1.Where = Nothing
        '
        'MAKHACHHANG
        '
        Me.MAKHACHHANG.AllowInsert = True
        Me.MAKHACHHANG.AllowUpdate = False
        Me.MAKHACHHANG.ButtonClick = True
        Me.MAKHACHHANG.Caption = "Mã khách hàng"
        Me.MAKHACHHANG.CFLColumnHide = ""
        Me.MAKHACHHANG.CFLKeyField = "MAKHACHHANG"
        Me.MAKHACHHANG.CFLPage = False
        Me.MAKHACHHANG.CFLReturn0 = ""
        Me.MAKHACHHANG.CFLReturn1 = "TENKHACHHANG"
        Me.MAKHACHHANG.CFLReturn2 = ""
        Me.MAKHACHHANG.CFLReturn3 = ""
        Me.MAKHACHHANG.CFLReturn4 = ""
        Me.MAKHACHHANG.CFLReturn5 = ""
        Me.MAKHACHHANG.CFLReturn6 = ""
        Me.MAKHACHHANG.CFLReturn7 = ""
        Me.MAKHACHHANG.CFLShowLoad = False
        Me.MAKHACHHANG.ChangeFormStatus = True
        Me.MAKHACHHANG.ColumnKey = True
        Me.MAKHACHHANG.ComboLine = 5
        Me.MAKHACHHANG.CopyFromItem = ""
        Me.MAKHACHHANG.DefaultButtonClick = False
        Me.MAKHACHHANG.Digit = False
        Me.MAKHACHHANG.FieldType = "C"
        Me.MAKHACHHANG.FieldView = "MAKHACHHANG"
        Me.MAKHACHHANG.FormarNumber = True
        Me.MAKHACHHANG.FormList = False
        Me.MAKHACHHANG.KeyInsert = ""
        Me.MAKHACHHANG.LocalDecimal = False
        Me.MAKHACHHANG.Name = "MAKHACHHANG"
        Me.MAKHACHHANG.NoUpdate = ""
        Me.MAKHACHHANG.NumberDecimal = 0
        Me.MAKHACHHANG.ParentControl = ""
        Me.MAKHACHHANG.RefreshSource = False
        Me.MAKHACHHANG.Required = False
        Me.MAKHACHHANG.SequenceName = ""
        Me.MAKHACHHANG.ShowCalc = True
        Me.MAKHACHHANG.ShowDataTime = False
        Me.MAKHACHHANG.ShowOnlyTime = False
        Me.MAKHACHHANG.SQLString = "select MAKHACHHANG, TENKHACHHANG from tblKhachHang"
        Me.MAKHACHHANG.UpdateIfNull = "Y"
        Me.MAKHACHHANG.UpdateWhenFormLock = False
        Me.MAKHACHHANG.ValidateValue = True
        Me.MAKHACHHANG.Visible = True
        Me.MAKHACHHANG.VisibleIndex = 0
        Me.MAKHACHHANG.Width = 120
        '
        'TENKHACHHANG
        '
        Me.TENKHACHHANG.AllowInsert = True
        Me.TENKHACHHANG.AllowUpdate = True
        Me.TENKHACHHANG.ButtonClick = True
        Me.TENKHACHHANG.Caption = "Tên khách hàng"
        Me.TENKHACHHANG.CFLColumnHide = ""
        Me.TENKHACHHANG.CFLKeyField = ""
        Me.TENKHACHHANG.CFLPage = False
        Me.TENKHACHHANG.CFLReturn0 = ""
        Me.TENKHACHHANG.CFLReturn1 = ""
        Me.TENKHACHHANG.CFLReturn2 = ""
        Me.TENKHACHHANG.CFLReturn3 = ""
        Me.TENKHACHHANG.CFLReturn4 = ""
        Me.TENKHACHHANG.CFLReturn5 = ""
        Me.TENKHACHHANG.CFLReturn6 = ""
        Me.TENKHACHHANG.CFLReturn7 = ""
        Me.TENKHACHHANG.CFLShowLoad = False
        Me.TENKHACHHANG.ChangeFormStatus = True
        Me.TENKHACHHANG.ColumnKey = False
        Me.TENKHACHHANG.ComboLine = 5
        Me.TENKHACHHANG.CopyFromItem = ""
        Me.TENKHACHHANG.DefaultButtonClick = False
        Me.TENKHACHHANG.Digit = False
        Me.TENKHACHHANG.FieldType = "C"
        Me.TENKHACHHANG.FieldView = "TENKHACHHANG"
        Me.TENKHACHHANG.FormarNumber = True
        Me.TENKHACHHANG.FormList = False
        Me.TENKHACHHANG.KeyInsert = ""
        Me.TENKHACHHANG.LocalDecimal = False
        Me.TENKHACHHANG.Name = "TENKHACHHANG"
        Me.TENKHACHHANG.NoUpdate = ""
        Me.TENKHACHHANG.NumberDecimal = 0
        Me.TENKHACHHANG.OptionsColumn.ReadOnly = True
        Me.TENKHACHHANG.ParentControl = ""
        Me.TENKHACHHANG.RefreshSource = False
        Me.TENKHACHHANG.Required = False
        Me.TENKHACHHANG.SequenceName = ""
        Me.TENKHACHHANG.ShowCalc = True
        Me.TENKHACHHANG.ShowDataTime = False
        Me.TENKHACHHANG.ShowOnlyTime = False
        Me.TENKHACHHANG.SQLString = ""
        Me.TENKHACHHANG.UpdateIfNull = ""
        Me.TENKHACHHANG.UpdateWhenFormLock = False
        Me.TENKHACHHANG.ValidateValue = True
        Me.TENKHACHHANG.Visible = True
        Me.TENKHACHHANG.VisibleIndex = 1
        Me.TENKHACHHANG.Width = 200
        '
        'TONGDUXUAT
        '
        Me.TONGDUXUAT.AllowInsert = True
        Me.TONGDUXUAT.AllowUpdate = True
        Me.TONGDUXUAT.ButtonClick = True
        Me.TONGDUXUAT.Caption = "Dự xuất Bộ"
        Me.TONGDUXUAT.CFLColumnHide = ""
        Me.TONGDUXUAT.CFLKeyField = ""
        Me.TONGDUXUAT.CFLPage = False
        Me.TONGDUXUAT.CFLReturn0 = ""
        Me.TONGDUXUAT.CFLReturn1 = ""
        Me.TONGDUXUAT.CFLReturn2 = ""
        Me.TONGDUXUAT.CFLReturn3 = ""
        Me.TONGDUXUAT.CFLReturn4 = ""
        Me.TONGDUXUAT.CFLReturn5 = ""
        Me.TONGDUXUAT.CFLReturn6 = ""
        Me.TONGDUXUAT.CFLReturn7 = ""
        Me.TONGDUXUAT.CFLShowLoad = False
        Me.TONGDUXUAT.ChangeFormStatus = True
        Me.TONGDUXUAT.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.TONGDUXUAT.ColumnKey = False
        Me.TONGDUXUAT.ComboLine = 5
        Me.TONGDUXUAT.CopyFromItem = ""
        Me.TONGDUXUAT.DefaultButtonClick = False
        Me.TONGDUXUAT.Digit = False
        Me.TONGDUXUAT.FieldType = "C"
        Me.TONGDUXUAT.FieldView = "TONGDUXUAT"
        Me.TONGDUXUAT.FormarNumber = True
        Me.TONGDUXUAT.FormList = False
        Me.TONGDUXUAT.KeyInsert = ""
        Me.TONGDUXUAT.LocalDecimal = False
        Me.TONGDUXUAT.Name = "TONGDUXUAT"
        Me.TONGDUXUAT.NoUpdate = ""
        Me.TONGDUXUAT.NumberDecimal = 0
        Me.TONGDUXUAT.ParentControl = ""
        Me.TONGDUXUAT.RefreshSource = False
        Me.TONGDUXUAT.Required = False
        Me.TONGDUXUAT.SequenceName = ""
        Me.TONGDUXUAT.ShowCalc = True
        Me.TONGDUXUAT.ShowDataTime = False
        Me.TONGDUXUAT.ShowOnlyTime = False
        Me.TONGDUXUAT.SQLString = ""
        Me.TONGDUXUAT.UpdateIfNull = ""
        Me.TONGDUXUAT.UpdateWhenFormLock = False
        Me.TONGDUXUAT.ValidateValue = True
        Me.TONGDUXUAT.Visible = True
        Me.TONGDUXUAT.VisibleIndex = 2
        Me.TONGDUXUAT.Width = 97
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'TONGDUXUAT_THUY
        '
        Me.TONGDUXUAT_THUY.AllowInsert = True
        Me.TONGDUXUAT_THUY.AllowUpdate = True
        Me.TONGDUXUAT_THUY.ButtonClick = True
        Me.TONGDUXUAT_THUY.Caption = "Dự xuất thủy"
        Me.TONGDUXUAT_THUY.CFLColumnHide = ""
        Me.TONGDUXUAT_THUY.CFLKeyField = ""
        Me.TONGDUXUAT_THUY.CFLPage = False
        Me.TONGDUXUAT_THUY.CFLReturn0 = ""
        Me.TONGDUXUAT_THUY.CFLReturn1 = ""
        Me.TONGDUXUAT_THUY.CFLReturn2 = ""
        Me.TONGDUXUAT_THUY.CFLReturn3 = ""
        Me.TONGDUXUAT_THUY.CFLReturn4 = ""
        Me.TONGDUXUAT_THUY.CFLReturn5 = ""
        Me.TONGDUXUAT_THUY.CFLReturn6 = ""
        Me.TONGDUXUAT_THUY.CFLReturn7 = ""
        Me.TONGDUXUAT_THUY.CFLShowLoad = False
        Me.TONGDUXUAT_THUY.ChangeFormStatus = True
        Me.TONGDUXUAT_THUY.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.TONGDUXUAT_THUY.ColumnKey = False
        Me.TONGDUXUAT_THUY.ComboLine = 5
        Me.TONGDUXUAT_THUY.CopyFromItem = ""
        Me.TONGDUXUAT_THUY.DefaultButtonClick = False
        Me.TONGDUXUAT_THUY.Digit = False
        Me.TONGDUXUAT_THUY.FieldType = "C"
        Me.TONGDUXUAT_THUY.FieldView = "TONGDUXUAT_THUY"
        Me.TONGDUXUAT_THUY.FormarNumber = True
        Me.TONGDUXUAT_THUY.FormList = False
        Me.TONGDUXUAT_THUY.KeyInsert = ""
        Me.TONGDUXUAT_THUY.LocalDecimal = False
        Me.TONGDUXUAT_THUY.Name = "TONGDUXUAT_THUY"
        Me.TONGDUXUAT_THUY.NoUpdate = ""
        Me.TONGDUXUAT_THUY.NumberDecimal = 0
        Me.TONGDUXUAT_THUY.ParentControl = ""
        Me.TONGDUXUAT_THUY.RefreshSource = False
        Me.TONGDUXUAT_THUY.Required = False
        Me.TONGDUXUAT_THUY.SequenceName = ""
        Me.TONGDUXUAT_THUY.ShowCalc = True
        Me.TONGDUXUAT_THUY.ShowDataTime = False
        Me.TONGDUXUAT_THUY.ShowOnlyTime = False
        Me.TONGDUXUAT_THUY.SQLString = ""
        Me.TONGDUXUAT_THUY.UpdateIfNull = ""
        Me.TONGDUXUAT_THUY.UpdateWhenFormLock = False
        Me.TONGDUXUAT_THUY.ValidateValue = True
        Me.TONGDUXUAT_THUY.Visible = True
        Me.TONGDUXUAT_THUY.VisibleIndex = 3
        Me.TONGDUXUAT_THUY.Width = 104
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
        Me.CHECKUPD.ButtonClick = True
        Me.CHECKUPD.Caption = "GridColumn5"
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
        Me.CHECKUPD.ValidateValue = True
        Me.CHECKUPD.Visible = True
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(580, 28)
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
        'FrmKhachHang2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 397)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmKhachHang2"
        Me.Text = "Thông tin Lượng xuất theo khách hàng"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents MAKHACHHANG As U_TextBox.GridColumn
    Friend WithEvents TENKHACHHANG As U_TextBox.GridColumn
    Friend WithEvents TONGDUXUAT As U_TextBox.GridColumn
    Friend WithEvents TONGDUXUAT_THUY As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
