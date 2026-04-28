<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCopy
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCopy))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SoLenhGoc = New U_TextBox.U_TextBox()
        Me.SoLuong = New U_TextBox.U_NumericEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SoLenh_TK = New U_TextBox.U_TextBox()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SoLenhGoc_TK = New U_TextBox.U_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NgayXuat = New U_TextBox.U_DateEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.SoLenhGoc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLuong.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.SoLenh_TK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLenhGoc_TK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(629, 28)
        Me.ToolStrip2.TabIndex = 469
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(113, 25)
        Me.ToolStripButton2.Text = "&1. Thực hiện"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 19)
        Me.Label1.TabIndex = 471
        Me.Label1.Text = "Số lệnh gốc"
        '
        'SoLenhGoc
        '
        Me.SoLenhGoc.AllowInsert = True
        Me.SoLenhGoc.AllowUpdate = True
        Me.SoLenhGoc.AutoKeyFix = ""
        Me.SoLenhGoc.AutoKeyName = ""
        Me.SoLenhGoc.BindingSourceName = ""
        Me.SoLenhGoc.ChangeFormStatus = True
        Me.SoLenhGoc.CopyFromItem = ""
        Me.SoLenhGoc.DefaultValue = ""
        Me.SoLenhGoc.FieldName = "SoLenh"
        Me.SoLenhGoc.FieldType = "C"
        Me.SoLenhGoc.KeyInsert = "Y"
        Me.SoLenhGoc.LinkLabel = ""
        Me.SoLenhGoc.Location = New System.Drawing.Point(155, 38)
        Me.SoLenhGoc.Name = "SoLenhGoc"
        Me.SoLenhGoc.NoUpdate = "N"
        Me.SoLenhGoc.PrimaryKey = "Y"
        Me.SoLenhGoc.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenhGoc.Properties.Appearance.Options.UseFont = True
        Me.SoLenhGoc.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenhGoc.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SoLenhGoc.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenhGoc.Properties.AppearanceFocused.Options.UseFont = True
        Me.SoLenhGoc.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenhGoc.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SoLenhGoc.Properties.AutoHeight = False
        Me.SoLenhGoc.Properties.ReadOnly = True
        Me.SoLenhGoc.Required = "Y"
        Me.SoLenhGoc.Size = New System.Drawing.Size(144, 26)
        Me.SoLenhGoc.TabIndex = 0
        Me.SoLenhGoc.TableName = "tblLenhXuatE5"
        Me.SoLenhGoc.TabStop = False
        Me.SoLenhGoc.UpdateIfNull = "Y"
        Me.SoLenhGoc.UpdateWhenFormLock = False
        Me.SoLenhGoc.UpperValue = False
        Me.SoLenhGoc.ViewName = "FPT_tblLenhXuatE5_New_V"
        '
        'SoLuong
        '
        Me.SoLuong.AllowInsert = True
        Me.SoLuong.AllowUpdate = True
        Me.SoLuong.AutoKeyFix = ""
        Me.SoLuong.AutoKeyName = ""
        Me.SoLuong.BindingSourceName = ""
        Me.SoLuong.ChangeFormStatus = True
        Me.SoLuong.CopyFromItem = ""
        Me.SoLuong.DefaultValue = ""
        Me.SoLuong.Digit = True
        Me.SoLuong.FieldName = ""
        Me.SoLuong.FieldType = "N"
        Me.SoLuong.KeyInsert = ""
        Me.SoLuong.LinkLabel = ""
        Me.SoLuong.LocalDecimal = False
        Me.SoLuong.Location = New System.Drawing.Point(155, 70)
        Me.SoLuong.Name = "SoLuong"
        Me.SoLuong.NoUpdate = ""
        Me.SoLuong.NumberDecimal = 0
        Me.SoLuong.PrimaryKey = ""
        Me.SoLuong.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLuong.Properties.Appearance.Options.UseFont = True
        Me.SoLuong.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLuong.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SoLuong.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLuong.Properties.AppearanceFocused.Options.UseFont = True
        Me.SoLuong.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLuong.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SoLuong.Properties.AutoHeight = False
        Me.SoLuong.Required = ""
        Me.SoLuong.ShowCalc = True
        Me.SoLuong.Size = New System.Drawing.Size(83, 26)
        Me.SoLuong.TabIndex = 1
        Me.SoLuong.TableName = ""
        Me.SoLuong.UpdateIfNull = ""
        Me.SoLuong.UpdateWhenFormLock = False
        Me.SoLuong.ViewName = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 19)
        Me.Label2.TabIndex = 473
        Me.Label2.Text = "Số lượng sao chép"
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(6, 109)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(439, 304)
        Me.TrueDBGrid1.TabIndex = 3
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.Name = "GridView1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.SoLenh_TK)
        Me.GroupBox1.Controls.Add(Me.U_ButtonCus1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.SoLenhGoc_TK)
        Me.GroupBox1.Location = New System.Drawing.Point(451, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 202)
        Me.GroupBox1.TabIndex = 477
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin Tìm kiếm"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 19)
        Me.Label4.TabIndex = 481
        Me.Label4.Text = "Số lệnh"
        '
        'SoLenh_TK
        '
        Me.SoLenh_TK.AllowInsert = True
        Me.SoLenh_TK.AllowUpdate = True
        Me.SoLenh_TK.AutoKeyFix = ""
        Me.SoLenh_TK.AutoKeyName = ""
        Me.SoLenh_TK.BindingSourceName = ""
        Me.SoLenh_TK.ChangeFormStatus = True
        Me.SoLenh_TK.CopyFromItem = ""
        Me.SoLenh_TK.DefaultValue = ""
        Me.SoLenh_TK.FieldName = "SoLenh"
        Me.SoLenh_TK.FieldType = "C"
        Me.SoLenh_TK.KeyInsert = "Y"
        Me.SoLenh_TK.LinkLabel = ""
        Me.SoLenh_TK.Location = New System.Drawing.Point(30, 120)
        Me.SoLenh_TK.Name = "SoLenh_TK"
        Me.SoLenh_TK.NoUpdate = "N"
        Me.SoLenh_TK.PrimaryKey = "Y"
        Me.SoLenh_TK.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh_TK.Properties.Appearance.Options.UseFont = True
        Me.SoLenh_TK.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh_TK.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SoLenh_TK.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh_TK.Properties.AppearanceFocused.Options.UseFont = True
        Me.SoLenh_TK.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenh_TK.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SoLenh_TK.Properties.AutoHeight = False
        Me.SoLenh_TK.Required = "Y"
        Me.SoLenh_TK.Size = New System.Drawing.Size(128, 26)
        Me.SoLenh_TK.TabIndex = 5
        Me.SoLenh_TK.TableName = "tblLenhXuatE5"
        Me.SoLenh_TK.UpdateIfNull = "Y"
        Me.SoLenh_TK.UpdateWhenFormLock = False
        Me.SoLenh_TK.UpperValue = False
        Me.SoLenh_TK.ViewName = "FPT_tblLenhXuatE5_New_V"
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(52, 155)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(75, 23)
        Me.U_ButtonCus1.TabIndex = 6
        Me.U_ButtonCus1.Text = "Tìm kiếm"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 19)
        Me.Label3.TabIndex = 478
        Me.Label3.Text = "Số lệnh gốc"
        '
        'SoLenhGoc_TK
        '
        Me.SoLenhGoc_TK.AllowInsert = True
        Me.SoLenhGoc_TK.AllowUpdate = True
        Me.SoLenhGoc_TK.AutoKeyFix = ""
        Me.SoLenhGoc_TK.AutoKeyName = ""
        Me.SoLenhGoc_TK.BindingSourceName = ""
        Me.SoLenhGoc_TK.ChangeFormStatus = True
        Me.SoLenhGoc_TK.CopyFromItem = ""
        Me.SoLenhGoc_TK.DefaultValue = ""
        Me.SoLenhGoc_TK.FieldName = "SoLenh"
        Me.SoLenhGoc_TK.FieldType = "C"
        Me.SoLenhGoc_TK.KeyInsert = "Y"
        Me.SoLenhGoc_TK.LinkLabel = ""
        Me.SoLenhGoc_TK.Location = New System.Drawing.Point(27, 54)
        Me.SoLenhGoc_TK.Name = "SoLenhGoc_TK"
        Me.SoLenhGoc_TK.NoUpdate = "N"
        Me.SoLenhGoc_TK.PrimaryKey = "Y"
        Me.SoLenhGoc_TK.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenhGoc_TK.Properties.Appearance.Options.UseFont = True
        Me.SoLenhGoc_TK.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenhGoc_TK.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SoLenhGoc_TK.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenhGoc_TK.Properties.AppearanceFocused.Options.UseFont = True
        Me.SoLenhGoc_TK.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoLenhGoc_TK.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SoLenhGoc_TK.Properties.AutoHeight = False
        Me.SoLenhGoc_TK.Required = "Y"
        Me.SoLenhGoc_TK.Size = New System.Drawing.Size(128, 26)
        Me.SoLenhGoc_TK.TabIndex = 4
        Me.SoLenhGoc_TK.TableName = "tblLenhXuatE5"
        Me.SoLenhGoc_TK.UpdateIfNull = "Y"
        Me.SoLenhGoc_TK.UpdateWhenFormLock = False
        Me.SoLenhGoc_TK.UpperValue = False
        Me.SoLenhGoc_TK.ViewName = "FPT_tblLenhXuatE5_New_V"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(310, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 19)
        Me.Label5.TabIndex = 479
        Me.Label5.Text = "Ngày xuất"
        '
        'NgayXuat
        '
        Me.NgayXuat.AllowInsert = True
        Me.NgayXuat.AllowUpdate = True
        Me.NgayXuat.BindingSourceName = ""
        Me.NgayXuat.ChangeFormStatus = True
        Me.NgayXuat.CopyFromItem = ""
        Me.NgayXuat.DefaultValue = ""
        Me.NgayXuat.EditValue = Nothing
        Me.NgayXuat.FieldName = ""
        Me.NgayXuat.FieldType = "D"
        Me.NgayXuat.KeyInsert = ""
        Me.NgayXuat.LinkLabel = ""
        Me.NgayXuat.Location = New System.Drawing.Point(396, 38)
        Me.NgayXuat.Name = "NgayXuat"
        Me.NgayXuat.NoUpdate = ""
        Me.NgayXuat.PrimaryKey = ""
        Me.NgayXuat.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.Appearance.Options.UseFont = True
        Me.NgayXuat.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.AppearanceDisabled.Options.UseFont = True
        Me.NgayXuat.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.AppearanceFocused.Options.UseFont = True
        Me.NgayXuat.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.NgayXuat.Properties.AutoHeight = False
        Me.NgayXuat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayXuat.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayXuat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayXuat.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayXuat.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayXuat.Required = ""
        Me.NgayXuat.ShowDateTime = False
        Me.NgayXuat.Size = New System.Drawing.Size(144, 26)
        Me.NgayXuat.TabIndex = 2
        Me.NgayXuat.TableName = ""
        Me.NgayXuat.UpdateIfNull = ""
        Me.NgayXuat.UpdateWhenFormLock = False
        Me.NgayXuat.ViewName = ""
        '
        'FrmCopy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 442)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NgayXuat)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SoLuong)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SoLenhGoc)
        Me.Controls.Add(Me.ToolStrip2)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmCopy"
        Me.Text = "Sao chép lệnh xuất"
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.SoLenhGoc, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.SoLuong, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.NgayXuat, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.SoLenhGoc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLuong.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SoLenh_TK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLenhGoc_TK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SoLenhGoc As U_TextBox.U_TextBox
    Friend WithEvents SoLuong As U_TextBox.U_NumericEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SoLenhGoc_TK As U_TextBox.U_TextBox
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SoLenh_TK As U_TextBox.U_TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NgayXuat As U_TextBox.U_DateEdit
End Class
