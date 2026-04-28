<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCheckScadar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCheckScadar))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NgayXuat = New U_TextBox.U_DateEdit()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SoLenh = New U_TextBox.U_TextBox()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.U_CheckBox1 = New U_TextBox.U_CheckBox()
        Me.U_CheckBox2 = New U_TextBox.U_CheckBox()
        Me.U_CheckBox3 = New U_TextBox.U_CheckBox()
        Me.U_CheckBox4 = New U_TextBox.U_CheckBox()
        Me.U_CheckBox5 = New U_TextBox.U_CheckBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CheckBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CheckBox2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CheckBox3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CheckBox4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_CheckBox5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 19)
        Me.Label2.TabIndex = 425
        Me.Label2.Text = "Ngày xuất"
        '
        'NgayXuat
        '
        Me.NgayXuat.AllowInsert = False
        Me.NgayXuat.AllowUpdate = False
        Me.NgayXuat.BindingSourceName = ""
        Me.NgayXuat.ChangeFormStatus = False
        Me.NgayXuat.CopyFromItem = ""
        Me.NgayXuat.DefaultValue = ""
        Me.NgayXuat.EditValue = Nothing
        Me.NgayXuat.FieldName = ""
        Me.NgayXuat.FieldType = "D"
        Me.NgayXuat.KeyInsert = ""
        Me.NgayXuat.LinkLabel = ""
        Me.NgayXuat.Location = New System.Drawing.Point(122, 31)
        Me.NgayXuat.Name = "NgayXuat"
        Me.NgayXuat.NoUpdate = ""
        Me.NgayXuat.PrimaryKey = ""
        Me.NgayXuat.Properties.AutoHeight = False
        Me.NgayXuat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayXuat.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayXuat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayXuat.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayXuat.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayXuat.Required = "Y"
        Me.NgayXuat.ShowDateTime = False
        Me.NgayXuat.Size = New System.Drawing.Size(121, 26)
        Me.NgayXuat.TabIndex = 424
        Me.NgayXuat.TableName = ""
        Me.NgayXuat.UpdateIfNull = ""
        Me.NgayXuat.UpdateWhenFormLock = False
        Me.NgayXuat.ViewName = ""
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1256, 25)
        Me.ToolStrip1.TabIndex = 471
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "&1. Làm mới"
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.Location = New System.Drawing.Point(1149, 28)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(95, 29)
        Me.SimpleButton7.TabIndex = 472
        Me.SimpleButton7.Text = "&Tìm kiếm"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(252, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 19)
        Me.Label1.TabIndex = 475
        Me.Label1.Text = "Số lệnh SAP"
        '
        'SoLenh
        '
        Me.SoLenh.AllowInsert = False
        Me.SoLenh.AllowUpdate = False
        Me.SoLenh.AutoKeyFix = ""
        Me.SoLenh.AutoKeyName = ""
        Me.SoLenh.BindingSourceName = ""
        Me.SoLenh.ChangeFormStatus = False
        Me.SoLenh.CopyFromItem = ""
        Me.SoLenh.DefaultValue = ""
        Me.SoLenh.FieldName = ""
        Me.SoLenh.FieldType = "C"
        Me.SoLenh.KeyInsert = "Y"
        Me.SoLenh.LinkLabel = ""
        Me.SoLenh.Location = New System.Drawing.Point(354, 31)
        Me.SoLenh.Name = "SoLenh"
        Me.SoLenh.NoUpdate = "N"
        Me.SoLenh.PrimaryKey = ""
        Me.SoLenh.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SoLenh.Properties.Appearance.Options.UseFont = True
        Me.SoLenh.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SoLenh.Properties.AppearanceFocused.Options.UseFont = True
        Me.SoLenh.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SoLenh.Properties.AutoHeight = False
        Me.SoLenh.Properties.MaxLength = 10
        Me.SoLenh.Required = ""
        Me.SoLenh.Size = New System.Drawing.Size(137, 26)
        Me.SoLenh.TabIndex = 474
        Me.SoLenh.TableName = ""
        Me.SoLenh.UpdateIfNull = "N"
        Me.SoLenh.UpdateWhenFormLock = False
        Me.SoLenh.UpperValue = False
        Me.SoLenh.ViewName = ""
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(6, 89)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(1244, 489)
        Me.TrueDBGrid1.TabIndex = 478
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.Name = "GridView1"
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
        Me.U_CheckBox1.Location = New System.Drawing.Point(723, 27)
        Me.U_CheckBox1.Name = "U_CheckBox1"
        Me.U_CheckBox1.NoUpdate = ""
        Me.U_CheckBox1.PrimaryKey = ""
        Me.U_CheckBox1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.Appearance.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_CheckBox1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_CheckBox1.Properties.AutoHeight = False
        Me.U_CheckBox1.Properties.Caption = "Đã tạo tích kê"
        Me.U_CheckBox1.Required = ""
        Me.U_CheckBox1.Size = New System.Drawing.Size(147, 30)
        Me.U_CheckBox1.TabIndex = 479
        Me.U_CheckBox1.TableName = ""
        Me.U_CheckBox1.UnCheckValue = "N"
        Me.U_CheckBox1.UpdateIfNull = ""
        Me.U_CheckBox1.UpdateWhenFormLock = False
        Me.U_CheckBox1.ViewName = ""
        '
        'U_CheckBox2
        '
        Me.U_CheckBox2.AllowInsert = True
        Me.U_CheckBox2.AllowUpdate = True
        Me.U_CheckBox2.BindingSourceName = ""
        Me.U_CheckBox2.ChangeFormStatus = True
        Me.U_CheckBox2.CheckValue = "Y"
        Me.U_CheckBox2.CopyFromItem = ""
        Me.U_CheckBox2.DefaultValue = ""
        Me.U_CheckBox2.FieldName = ""
        Me.U_CheckBox2.FieldType = ""
        Me.U_CheckBox2.ItemValue = ""
        Me.U_CheckBox2.KeyInsert = ""
        Me.U_CheckBox2.LinkLabel = ""
        Me.U_CheckBox2.Location = New System.Drawing.Point(722, 58)
        Me.U_CheckBox2.Name = "U_CheckBox2"
        Me.U_CheckBox2.NoUpdate = ""
        Me.U_CheckBox2.PrimaryKey = ""
        Me.U_CheckBox2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox2.Properties.Appearance.Options.UseFont = True
        Me.U_CheckBox2.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox2.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_CheckBox2.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox2.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_CheckBox2.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox2.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_CheckBox2.Properties.AutoHeight = False
        Me.U_CheckBox2.Properties.Caption = "Đã nhận thực xuất"
        Me.U_CheckBox2.Required = ""
        Me.U_CheckBox2.Size = New System.Drawing.Size(164, 30)
        Me.U_CheckBox2.TabIndex = 480
        Me.U_CheckBox2.TableName = ""
        Me.U_CheckBox2.UnCheckValue = "N"
        Me.U_CheckBox2.UpdateIfNull = ""
        Me.U_CheckBox2.UpdateWhenFormLock = False
        Me.U_CheckBox2.ViewName = ""
        '
        'U_CheckBox3
        '
        Me.U_CheckBox3.AllowInsert = True
        Me.U_CheckBox3.AllowUpdate = True
        Me.U_CheckBox3.BindingSourceName = ""
        Me.U_CheckBox3.ChangeFormStatus = True
        Me.U_CheckBox3.CheckValue = "Y"
        Me.U_CheckBox3.CopyFromItem = ""
        Me.U_CheckBox3.DefaultValue = ""
        Me.U_CheckBox3.FieldName = ""
        Me.U_CheckBox3.FieldType = ""
        Me.U_CheckBox3.ItemValue = ""
        Me.U_CheckBox3.KeyInsert = ""
        Me.U_CheckBox3.LinkLabel = ""
        Me.U_CheckBox3.Location = New System.Drawing.Point(895, 27)
        Me.U_CheckBox3.Name = "U_CheckBox3"
        Me.U_CheckBox3.NoUpdate = ""
        Me.U_CheckBox3.PrimaryKey = ""
        Me.U_CheckBox3.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox3.Properties.Appearance.Options.UseFont = True
        Me.U_CheckBox3.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox3.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_CheckBox3.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox3.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_CheckBox3.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox3.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_CheckBox3.Properties.AutoHeight = False
        Me.U_CheckBox3.Properties.Caption = "Đã xác nhận"
        Me.U_CheckBox3.Required = ""
        Me.U_CheckBox3.Size = New System.Drawing.Size(122, 30)
        Me.U_CheckBox3.TabIndex = 481
        Me.U_CheckBox3.TableName = ""
        Me.U_CheckBox3.UnCheckValue = "N"
        Me.U_CheckBox3.UpdateIfNull = ""
        Me.U_CheckBox3.UpdateWhenFormLock = False
        Me.U_CheckBox3.ViewName = ""
        '
        'U_CheckBox4
        '
        Me.U_CheckBox4.AllowInsert = True
        Me.U_CheckBox4.AllowUpdate = True
        Me.U_CheckBox4.BindingSourceName = ""
        Me.U_CheckBox4.ChangeFormStatus = True
        Me.U_CheckBox4.CheckValue = "Y"
        Me.U_CheckBox4.CopyFromItem = ""
        Me.U_CheckBox4.DefaultValue = ""
        Me.U_CheckBox4.FieldName = ""
        Me.U_CheckBox4.FieldType = ""
        Me.U_CheckBox4.ItemValue = ""
        Me.U_CheckBox4.KeyInsert = ""
        Me.U_CheckBox4.LinkLabel = ""
        Me.U_CheckBox4.Location = New System.Drawing.Point(895, 58)
        Me.U_CheckBox4.Name = "U_CheckBox4"
        Me.U_CheckBox4.NoUpdate = ""
        Me.U_CheckBox4.PrimaryKey = ""
        Me.U_CheckBox4.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox4.Properties.Appearance.Options.UseFont = True
        Me.U_CheckBox4.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox4.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_CheckBox4.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox4.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_CheckBox4.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox4.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_CheckBox4.Properties.AutoHeight = False
        Me.U_CheckBox4.Properties.Caption = "Đã đồng bộ lên SAP"
        Me.U_CheckBox4.Required = ""
        Me.U_CheckBox4.Size = New System.Drawing.Size(164, 30)
        Me.U_CheckBox4.TabIndex = 482
        Me.U_CheckBox4.TableName = ""
        Me.U_CheckBox4.UnCheckValue = "N"
        Me.U_CheckBox4.UpdateIfNull = ""
        Me.U_CheckBox4.UpdateWhenFormLock = False
        Me.U_CheckBox4.ViewName = ""
        '
        'U_CheckBox5
        '
        Me.U_CheckBox5.AllowInsert = True
        Me.U_CheckBox5.AllowUpdate = True
        Me.U_CheckBox5.BindingSourceName = ""
        Me.U_CheckBox5.ChangeFormStatus = True
        Me.U_CheckBox5.CheckValue = "Y"
        Me.U_CheckBox5.CopyFromItem = ""
        Me.U_CheckBox5.DefaultValue = ""
        Me.U_CheckBox5.FieldName = ""
        Me.U_CheckBox5.FieldType = ""
        Me.U_CheckBox5.ItemValue = ""
        Me.U_CheckBox5.KeyInsert = ""
        Me.U_CheckBox5.LinkLabel = ""
        Me.U_CheckBox5.Location = New System.Drawing.Point(570, 27)
        Me.U_CheckBox5.Name = "U_CheckBox5"
        Me.U_CheckBox5.NoUpdate = ""
        Me.U_CheckBox5.PrimaryKey = ""
        Me.U_CheckBox5.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox5.Properties.Appearance.Options.UseFont = True
        Me.U_CheckBox5.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox5.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_CheckBox5.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox5.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_CheckBox5.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_CheckBox5.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_CheckBox5.Properties.AutoHeight = False
        Me.U_CheckBox5.Properties.Caption = "Lệnh mới"
        Me.U_CheckBox5.Required = ""
        Me.U_CheckBox5.Size = New System.Drawing.Size(147, 30)
        Me.U_CheckBox5.TabIndex = 483
        Me.U_CheckBox5.TableName = ""
        Me.U_CheckBox5.UnCheckValue = "N"
        Me.U_CheckBox5.UpdateIfNull = ""
        Me.U_CheckBox5.UpdateWhenFormLock = False
        Me.U_CheckBox5.ViewName = ""
        '
        'FrmCheckScadar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1256, 590)
        Me.Controls.Add(Me.U_CheckBox5)
        Me.Controls.Add(Me.U_CheckBox4)
        Me.Controls.Add(Me.U_CheckBox3)
        Me.Controls.Add(Me.U_CheckBox2)
        Me.Controls.Add(Me.U_CheckBox1)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SoLenh)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NgayXuat)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmCheckScadar"
        Me.Text = "Thông tin lệnh xuất và Tự động hóa"
        Me.Controls.SetChildIndex(Me.NgayXuat, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton7, 0)
        Me.Controls.SetChildIndex(Me.SoLenh, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.U_CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.U_CheckBox2, 0)
        Me.Controls.SetChildIndex(Me.U_CheckBox3, 0)
        Me.Controls.SetChildIndex(Me.U_CheckBox4, 0)
        Me.Controls.SetChildIndex(Me.U_CheckBox5, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CheckBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CheckBox2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CheckBox3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CheckBox4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_CheckBox5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NgayXuat As U_TextBox.U_DateEdit
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SoLenh As U_TextBox.U_TextBox
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents U_CheckBox1 As U_TextBox.U_CheckBox
    Friend WithEvents U_CheckBox2 As U_TextBox.U_CheckBox
    Friend WithEvents U_CheckBox3 As U_TextBox.U_CheckBox
    Friend WithEvents U_CheckBox4 As U_TextBox.U_CheckBox
    Friend WithEvents U_CheckBox5 As U_TextBox.U_CheckBox
End Class
