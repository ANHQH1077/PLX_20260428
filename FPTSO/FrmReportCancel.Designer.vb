<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportCancel
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
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SoBBGN = New U_TextBox.U_ButtonEdit()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.SoLenh = New U_TextBox.GridColumn()
        Me.NgayXuat = New U_TextBox.GridColumn()
        Me.TenKhachHang = New U_TextBox.GridColumn()
        Me.MaphuongTien = New U_TextBox.GridColumn()
        Me.SoBienBan = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoBBGN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(4, 278)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(139, 41)
        Me.U_ButtonCus1.TabIndex = 474
        Me.U_ButtonCus1.TabStop = False
        Me.U_ButtonCus1.Text = "Hủy Biên bản"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(170, 19)
        Me.Label8.TabIndex = 476
        Me.Label8.Text = "Số Biên bản Giao nhận"
        '
        'SoBBGN
        '
        Me.SoBBGN.AllowInsert = False
        Me.SoBBGN.AllowUpdate = False
        Me.SoBBGN.AutoWidth = False
        Me.SoBBGN.BindingSourceName = ""
        Me.SoBBGN.ChangeFormStatus = False
        Me.SoBBGN.CopyFromItem = ""
        Me.SoBBGN.DefaultButtonClick = True
        Me.SoBBGN.DefaultValue = ""
        Me.SoBBGN.FieldName = ""
        Me.SoBBGN.FieldType = "C"
        Me.SoBBGN.FormList = False
        Me.SoBBGN.ItemReturn1 = ""
        Me.SoBBGN.ItemReturn2 = ""
        Me.SoBBGN.ItemReturn3 = ""
        Me.SoBBGN.KeyInsert = ""
        Me.SoBBGN.LinkLabel = "Label8"
        Me.SoBBGN.Location = New System.Drawing.Point(188, 12)
        Me.SoBBGN.MultiSelect = False
        Me.SoBBGN.Name = "SoBBGN"
        Me.SoBBGN.NoUpdate = "N"
        Me.SoBBGN.OrderbyEx = ""
        Me.SoBBGN.PrimaryKey = ""
        Me.SoBBGN.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoBBGN.Properties.Appearance.Options.UseFont = True
        Me.SoBBGN.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoBBGN.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SoBBGN.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoBBGN.Properties.AppearanceFocused.Options.UseFont = True
        Me.SoBBGN.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoBBGN.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SoBBGN.Properties.AutoHeight = False
        Me.SoBBGN.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.SoBBGN.Required = ""
        Me.SoBBGN.ShowLoad = False
        Me.SoBBGN.Size = New System.Drawing.Size(307, 26)
        Me.SoBBGN.SqlFielKey = "SoBienBan"
        Me.SoBBGN.SqlString = ""
        Me.SoBBGN.TabIndex = 475
        Me.SoBBGN.TableName = ""
        Me.SoBBGN.UpdateIfNull = "N"
        Me.SoBBGN.UpdateWhenFormLock = False
        Me.SoBBGN.UpperValue = False
        Me.SoBBGN.ValidateValue = True
        Me.SoBBGN.ViewName = ""
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(4, 44)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(685, 228)
        Me.TrueDBGrid1.TabIndex = 477
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.SoLenh, Me.NgayXuat, Me.TenKhachHang, Me.MaphuongTien, Me.SoBienBan})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = ""
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = ""
        Me.GridView1.Where = Nothing
        '
        'SoLenh
        '
        Me.SoLenh.AllowInsert = True
        Me.SoLenh.AllowUpdate = True
        Me.SoLenh.ButtonClick = True
        Me.SoLenh.Caption = "Số lệnh"
        Me.SoLenh.CFLColumnHide = ""
        Me.SoLenh.CFLKeyField = ""
        Me.SoLenh.CFLPage = False
        Me.SoLenh.CFLReturn0 = ""
        Me.SoLenh.CFLReturn1 = ""
        Me.SoLenh.CFLReturn2 = ""
        Me.SoLenh.CFLReturn3 = ""
        Me.SoLenh.CFLReturn4 = ""
        Me.SoLenh.CFLReturn5 = ""
        Me.SoLenh.CFLReturn6 = ""
        Me.SoLenh.CFLReturn7 = ""
        Me.SoLenh.CFLShowLoad = False
        Me.SoLenh.ChangeFormStatus = True
        Me.SoLenh.ColumnKey = False
        Me.SoLenh.ComboLine = 5
        Me.SoLenh.CopyFromItem = ""
        Me.SoLenh.DefaultButtonClick = False
        Me.SoLenh.Digit = False
        Me.SoLenh.FieldType = "C"
        Me.SoLenh.FieldView = ""
        Me.SoLenh.FormarNumber = True
        Me.SoLenh.FormList = False
        Me.SoLenh.KeyInsert = ""
        Me.SoLenh.LocalDecimal = False
        Me.SoLenh.Name = "SoLenh"
        Me.SoLenh.NoUpdate = ""
        Me.SoLenh.NumberDecimal = 0
        Me.SoLenh.ParentControl = ""
        Me.SoLenh.RefreshSource = False
        Me.SoLenh.Required = False
        Me.SoLenh.SequenceName = ""
        Me.SoLenh.ShowCalc = True
        Me.SoLenh.ShowDataTime = False
        Me.SoLenh.ShowOnlyTime = False
        Me.SoLenh.SQLString = ""
        Me.SoLenh.UpdateIfNull = ""
        Me.SoLenh.UpdateWhenFormLock = False
        Me.SoLenh.UpperValue = False
        Me.SoLenh.ValidateValue = True
        Me.SoLenh.Visible = True
        Me.SoLenh.VisibleIndex = 0
        '
        'NgayXuat
        '
        Me.NgayXuat.AllowInsert = True
        Me.NgayXuat.AllowUpdate = True
        Me.NgayXuat.ButtonClick = True
        Me.NgayXuat.Caption = "Ngày xuất"
        Me.NgayXuat.CFLColumnHide = ""
        Me.NgayXuat.CFLKeyField = ""
        Me.NgayXuat.CFLPage = False
        Me.NgayXuat.CFLReturn0 = ""
        Me.NgayXuat.CFLReturn1 = ""
        Me.NgayXuat.CFLReturn2 = ""
        Me.NgayXuat.CFLReturn3 = ""
        Me.NgayXuat.CFLReturn4 = ""
        Me.NgayXuat.CFLReturn5 = ""
        Me.NgayXuat.CFLReturn6 = ""
        Me.NgayXuat.CFLReturn7 = ""
        Me.NgayXuat.CFLShowLoad = False
        Me.NgayXuat.ChangeFormStatus = True
        Me.NgayXuat.ColumnKey = False
        Me.NgayXuat.ComboLine = 5
        Me.NgayXuat.CopyFromItem = ""
        Me.NgayXuat.DefaultButtonClick = False
        Me.NgayXuat.Digit = False
        Me.NgayXuat.FieldType = "C"
        Me.NgayXuat.FieldView = ""
        Me.NgayXuat.FormarNumber = True
        Me.NgayXuat.FormList = False
        Me.NgayXuat.KeyInsert = ""
        Me.NgayXuat.LocalDecimal = False
        Me.NgayXuat.Name = "NgayXuat"
        Me.NgayXuat.NoUpdate = ""
        Me.NgayXuat.NumberDecimal = 0
        Me.NgayXuat.ParentControl = ""
        Me.NgayXuat.RefreshSource = False
        Me.NgayXuat.Required = False
        Me.NgayXuat.SequenceName = ""
        Me.NgayXuat.ShowCalc = True
        Me.NgayXuat.ShowDataTime = False
        Me.NgayXuat.ShowOnlyTime = False
        Me.NgayXuat.SQLString = ""
        Me.NgayXuat.UpdateIfNull = ""
        Me.NgayXuat.UpdateWhenFormLock = False
        Me.NgayXuat.UpperValue = False
        Me.NgayXuat.ValidateValue = True
        Me.NgayXuat.Visible = True
        Me.NgayXuat.VisibleIndex = 1
        '
        'TenKhachHang
        '
        Me.TenKhachHang.AllowInsert = True
        Me.TenKhachHang.AllowUpdate = True
        Me.TenKhachHang.ButtonClick = True
        Me.TenKhachHang.Caption = "Tên khách hàng"
        Me.TenKhachHang.CFLColumnHide = ""
        Me.TenKhachHang.CFLKeyField = ""
        Me.TenKhachHang.CFLPage = False
        Me.TenKhachHang.CFLReturn0 = ""
        Me.TenKhachHang.CFLReturn1 = ""
        Me.TenKhachHang.CFLReturn2 = ""
        Me.TenKhachHang.CFLReturn3 = ""
        Me.TenKhachHang.CFLReturn4 = ""
        Me.TenKhachHang.CFLReturn5 = ""
        Me.TenKhachHang.CFLReturn6 = ""
        Me.TenKhachHang.CFLReturn7 = ""
        Me.TenKhachHang.CFLShowLoad = False
        Me.TenKhachHang.ChangeFormStatus = True
        Me.TenKhachHang.ColumnKey = False
        Me.TenKhachHang.ComboLine = 5
        Me.TenKhachHang.CopyFromItem = ""
        Me.TenKhachHang.DefaultButtonClick = False
        Me.TenKhachHang.Digit = False
        Me.TenKhachHang.FieldType = "C"
        Me.TenKhachHang.FieldView = ""
        Me.TenKhachHang.FormarNumber = True
        Me.TenKhachHang.FormList = False
        Me.TenKhachHang.KeyInsert = ""
        Me.TenKhachHang.LocalDecimal = False
        Me.TenKhachHang.Name = "TenKhachHang"
        Me.TenKhachHang.NoUpdate = ""
        Me.TenKhachHang.NumberDecimal = 0
        Me.TenKhachHang.ParentControl = ""
        Me.TenKhachHang.RefreshSource = False
        Me.TenKhachHang.Required = False
        Me.TenKhachHang.SequenceName = ""
        Me.TenKhachHang.ShowCalc = True
        Me.TenKhachHang.ShowDataTime = False
        Me.TenKhachHang.ShowOnlyTime = False
        Me.TenKhachHang.SQLString = ""
        Me.TenKhachHang.UpdateIfNull = ""
        Me.TenKhachHang.UpdateWhenFormLock = False
        Me.TenKhachHang.UpperValue = False
        Me.TenKhachHang.ValidateValue = True
        Me.TenKhachHang.Visible = True
        Me.TenKhachHang.VisibleIndex = 2
        '
        'MaphuongTien
        '
        Me.MaphuongTien.AllowInsert = True
        Me.MaphuongTien.AllowUpdate = True
        Me.MaphuongTien.ButtonClick = True
        Me.MaphuongTien.Caption = "Phương tiện"
        Me.MaphuongTien.CFLColumnHide = ""
        Me.MaphuongTien.CFLKeyField = ""
        Me.MaphuongTien.CFLPage = False
        Me.MaphuongTien.CFLReturn0 = ""
        Me.MaphuongTien.CFLReturn1 = ""
        Me.MaphuongTien.CFLReturn2 = ""
        Me.MaphuongTien.CFLReturn3 = ""
        Me.MaphuongTien.CFLReturn4 = ""
        Me.MaphuongTien.CFLReturn5 = ""
        Me.MaphuongTien.CFLReturn6 = ""
        Me.MaphuongTien.CFLReturn7 = ""
        Me.MaphuongTien.CFLShowLoad = False
        Me.MaphuongTien.ChangeFormStatus = True
        Me.MaphuongTien.ColumnKey = False
        Me.MaphuongTien.ComboLine = 5
        Me.MaphuongTien.CopyFromItem = ""
        Me.MaphuongTien.DefaultButtonClick = False
        Me.MaphuongTien.Digit = False
        Me.MaphuongTien.FieldType = "C"
        Me.MaphuongTien.FieldView = ""
        Me.MaphuongTien.FormarNumber = True
        Me.MaphuongTien.FormList = False
        Me.MaphuongTien.KeyInsert = ""
        Me.MaphuongTien.LocalDecimal = False
        Me.MaphuongTien.Name = "MaphuongTien"
        Me.MaphuongTien.NoUpdate = ""
        Me.MaphuongTien.NumberDecimal = 0
        Me.MaphuongTien.ParentControl = ""
        Me.MaphuongTien.RefreshSource = False
        Me.MaphuongTien.Required = False
        Me.MaphuongTien.SequenceName = ""
        Me.MaphuongTien.ShowCalc = True
        Me.MaphuongTien.ShowDataTime = False
        Me.MaphuongTien.ShowOnlyTime = False
        Me.MaphuongTien.SQLString = ""
        Me.MaphuongTien.UpdateIfNull = ""
        Me.MaphuongTien.UpdateWhenFormLock = False
        Me.MaphuongTien.UpperValue = False
        Me.MaphuongTien.ValidateValue = True
        Me.MaphuongTien.Visible = True
        Me.MaphuongTien.VisibleIndex = 3
        '
        'SoBienBan
        '
        Me.SoBienBan.Caption = "Số biên bản"
        Me.SoBienBan.Name = "SoBienBan"
        Me.SoBienBan.Visible = True
        Me.SoBienBan.VisibleIndex = 4
        '
        'FrmReportCancel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 323)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.SoBBGN)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReportCancel"
        Me.Text = "Hủy biên bản giao nhận"
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.SoBBGN, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoBBGN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents Label8 As Label
    Friend WithEvents SoBBGN As U_TextBox.U_ButtonEdit
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents SoLenh As U_TextBox.GridColumn
    Friend WithEvents NgayXuat As U_TextBox.GridColumn
    Friend WithEvents TenKhachHang As U_TextBox.GridColumn
    Friend WithEvents MaphuongTien As U_TextBox.GridColumn
    Friend WithEvents SoBienBan As DevExpress.XtraGrid.Columns.GridColumn
End Class
