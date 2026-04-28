<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigFile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConfigFile))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PassFileOut = New U_TextBox.U_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FilePathOut = New U_TextBox.U_TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PassFileIn = New U_TextBox.U_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FilePathIn = New U_TextBox.U_TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PassFileTemp = New U_TextBox.U_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FilePathTemp = New U_TextBox.U_TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.U_TextBox1 = New U_TextBox.U_TextBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.PassFileOut.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilePathOut.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PassFileIn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilePathIn.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PassFileTemp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FilePathTemp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TextBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(600, 25)
        Me.ToolStrip2.TabIndex = 469
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton1.Text = "&1. Lưu"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 481
        Me.Label2.Text = "Mật khẩu (nếu có)"
        '
        'PassFileOut
        '
        Me.PassFileOut.AllowInsert = True
        Me.PassFileOut.AllowUpdate = True
        Me.PassFileOut.AutoKeyFix = ""
        Me.PassFileOut.AutoKeyName = ""
        Me.PassFileOut.BindingSourceName = ""
        Me.PassFileOut.ChangeFormStatus = True
        Me.PassFileOut.CopyFromItem = ""
        Me.PassFileOut.DefaultValue = ""
        Me.PassFileOut.FieldName = "PassFileOut"
        Me.PassFileOut.FieldType = "C"
        Me.PassFileOut.KeyInsert = "N"
        Me.PassFileOut.LinkLabel = ""
        Me.PassFileOut.Location = New System.Drawing.Point(141, 91)
        Me.PassFileOut.Name = "PassFileOut"
        Me.PassFileOut.NoUpdate = "N"
        Me.PassFileOut.PrimaryKey = "N"
        Me.PassFileOut.Required = "N"
        Me.PassFileOut.Size = New System.Drawing.Size(203, 20)
        Me.PassFileOut.TabIndex = 480
        Me.PassFileOut.TableName = "SYS_FOXCONFIG"
        Me.PassFileOut.UpdateIfNull = ""
        Me.PassFileOut.UpdateWhenFormLock = False
        Me.PassFileOut.UpperValue = False
        Me.PassFileOut.ViewName = "SYS_FOXCONFIG"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 479
        Me.Label1.Text = "Đường dẫn file"
        '
        'FilePathOut
        '
        Me.FilePathOut.AllowInsert = True
        Me.FilePathOut.AllowUpdate = True
        Me.FilePathOut.AutoKeyFix = ""
        Me.FilePathOut.AutoKeyName = ""
        Me.FilePathOut.BindingSourceName = ""
        Me.FilePathOut.ChangeFormStatus = True
        Me.FilePathOut.CopyFromItem = ""
        Me.FilePathOut.DefaultValue = ""
        Me.FilePathOut.FieldName = "FilePathOut"
        Me.FilePathOut.FieldType = "C"
        Me.FilePathOut.KeyInsert = "N"
        Me.FilePathOut.LinkLabel = ""
        Me.FilePathOut.Location = New System.Drawing.Point(141, 65)
        Me.FilePathOut.Name = "FilePathOut"
        Me.FilePathOut.NoUpdate = "N"
        Me.FilePathOut.PrimaryKey = "N"
        Me.FilePathOut.Required = "Y"
        Me.FilePathOut.Size = New System.Drawing.Size(440, 20)
        Me.FilePathOut.TabIndex = 478
        Me.FilePathOut.TableName = "SYS_FOXCONFIG"
        Me.FilePathOut.UpdateIfNull = ""
        Me.FilePathOut.UpdateWhenFormLock = False
        Me.FilePathOut.UpperValue = False
        Me.FilePathOut.ViewName = "SYS_FOXCONFIG"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(16, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 13)
        Me.Label7.TabIndex = 482
        Me.Label7.Text = "HTTG - > Scadar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 183)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 486
        Me.Label3.Text = "Mật khẩu (nếu có)"
        '
        'PassFileIn
        '
        Me.PassFileIn.AllowInsert = True
        Me.PassFileIn.AllowUpdate = True
        Me.PassFileIn.AutoKeyFix = ""
        Me.PassFileIn.AutoKeyName = ""
        Me.PassFileIn.BindingSourceName = ""
        Me.PassFileIn.ChangeFormStatus = True
        Me.PassFileIn.CopyFromItem = ""
        Me.PassFileIn.DefaultValue = ""
        Me.PassFileIn.FieldName = "PassFileIn"
        Me.PassFileIn.FieldType = "C"
        Me.PassFileIn.KeyInsert = "N"
        Me.PassFileIn.LinkLabel = ""
        Me.PassFileIn.Location = New System.Drawing.Point(141, 180)
        Me.PassFileIn.Name = "PassFileIn"
        Me.PassFileIn.NoUpdate = "N"
        Me.PassFileIn.PrimaryKey = "N"
        Me.PassFileIn.Required = "N"
        Me.PassFileIn.Size = New System.Drawing.Size(203, 20)
        Me.PassFileIn.TabIndex = 485
        Me.PassFileIn.TableName = "SYS_FOXCONFIG"
        Me.PassFileIn.UpdateIfNull = ""
        Me.PassFileIn.UpdateWhenFormLock = False
        Me.PassFileIn.UpperValue = False
        Me.PassFileIn.ViewName = "SYS_FOXCONFIG"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(45, 157)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 484
        Me.Label4.Text = "Đường dẫn file"
        '
        'FilePathIn
        '
        Me.FilePathIn.AllowInsert = True
        Me.FilePathIn.AllowUpdate = True
        Me.FilePathIn.AutoKeyFix = ""
        Me.FilePathIn.AutoKeyName = ""
        Me.FilePathIn.BindingSourceName = ""
        Me.FilePathIn.ChangeFormStatus = True
        Me.FilePathIn.CopyFromItem = ""
        Me.FilePathIn.DefaultValue = ""
        Me.FilePathIn.FieldName = "FilePathIn"
        Me.FilePathIn.FieldType = "C"
        Me.FilePathIn.KeyInsert = "N"
        Me.FilePathIn.LinkLabel = ""
        Me.FilePathIn.Location = New System.Drawing.Point(141, 154)
        Me.FilePathIn.Name = "FilePathIn"
        Me.FilePathIn.NoUpdate = "N"
        Me.FilePathIn.PrimaryKey = "N"
        Me.FilePathIn.Required = "Y"
        Me.FilePathIn.Size = New System.Drawing.Size(440, 20)
        Me.FilePathIn.TabIndex = 483
        Me.FilePathIn.TableName = "SYS_FOXCONFIG"
        Me.FilePathIn.UpdateIfNull = ""
        Me.FilePathIn.UpdateWhenFormLock = False
        Me.FilePathIn.UpperValue = False
        Me.FilePathIn.ViewName = "SYS_FOXCONFIG"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(16, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 13)
        Me.Label8.TabIndex = 487
        Me.Label8.Text = "Scadar - > HTTG"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(45, 278)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 13)
        Me.Label5.TabIndex = 491
        Me.Label5.Text = "Mật khẩu (nếu có)"
        '
        'PassFileTemp
        '
        Me.PassFileTemp.AllowInsert = True
        Me.PassFileTemp.AllowUpdate = True
        Me.PassFileTemp.AutoKeyFix = ""
        Me.PassFileTemp.AutoKeyName = ""
        Me.PassFileTemp.BindingSourceName = ""
        Me.PassFileTemp.ChangeFormStatus = True
        Me.PassFileTemp.CopyFromItem = ""
        Me.PassFileTemp.DefaultValue = ""
        Me.PassFileTemp.FieldName = "PassFileTemp"
        Me.PassFileTemp.FieldType = "C"
        Me.PassFileTemp.KeyInsert = "N"
        Me.PassFileTemp.LinkLabel = ""
        Me.PassFileTemp.Location = New System.Drawing.Point(141, 275)
        Me.PassFileTemp.Name = "PassFileTemp"
        Me.PassFileTemp.NoUpdate = "N"
        Me.PassFileTemp.PrimaryKey = "N"
        Me.PassFileTemp.Required = "N"
        Me.PassFileTemp.Size = New System.Drawing.Size(203, 20)
        Me.PassFileTemp.TabIndex = 490
        Me.PassFileTemp.TableName = "SYS_FOXCONFIG"
        Me.PassFileTemp.UpdateIfNull = ""
        Me.PassFileTemp.UpdateWhenFormLock = False
        Me.PassFileTemp.UpperValue = False
        Me.PassFileTemp.ViewName = "SYS_FOXCONFIG"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(45, 252)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 489
        Me.Label6.Text = "Đường dẫn file"
        '
        'FilePathTemp
        '
        Me.FilePathTemp.AllowInsert = True
        Me.FilePathTemp.AllowUpdate = True
        Me.FilePathTemp.AutoKeyFix = ""
        Me.FilePathTemp.AutoKeyName = ""
        Me.FilePathTemp.BindingSourceName = ""
        Me.FilePathTemp.ChangeFormStatus = True
        Me.FilePathTemp.CopyFromItem = ""
        Me.FilePathTemp.DefaultValue = ""
        Me.FilePathTemp.FieldName = "FilePathTemp"
        Me.FilePathTemp.FieldType = "C"
        Me.FilePathTemp.KeyInsert = "N"
        Me.FilePathTemp.LinkLabel = ""
        Me.FilePathTemp.Location = New System.Drawing.Point(141, 249)
        Me.FilePathTemp.Name = "FilePathTemp"
        Me.FilePathTemp.NoUpdate = "N"
        Me.FilePathTemp.PrimaryKey = "N"
        Me.FilePathTemp.Required = "Y"
        Me.FilePathTemp.Size = New System.Drawing.Size(440, 20)
        Me.FilePathTemp.TabIndex = 488
        Me.FilePathTemp.TableName = "SYS_FOXCONFIG"
        Me.FilePathTemp.UpdateIfNull = ""
        Me.FilePathTemp.UpdateWhenFormLock = False
        Me.FilePathTemp.UpperValue = False
        Me.FilePathTemp.ViewName = "SYS_FOXCONFIG"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(16, 219)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 13)
        Me.Label9.TabIndex = 492
        Me.Label9.Text = "Đường dẫn file mẫu"
        '
        'U_TextBox1
        '
        Me.U_TextBox1.AllowInsert = True
        Me.U_TextBox1.AllowUpdate = True
        Me.U_TextBox1.AutoKeyFix = ""
        Me.U_TextBox1.AutoKeyName = ""
        Me.U_TextBox1.BindingSourceName = ""
        Me.U_TextBox1.ChangeFormStatus = True
        Me.U_TextBox1.CopyFromItem = ""
        Me.U_TextBox1.DefaultValue = ""
        Me.U_TextBox1.FieldName = "ID"
        Me.U_TextBox1.FieldType = "N"
        Me.U_TextBox1.KeyInsert = "N"
        Me.U_TextBox1.LinkLabel = ""
        Me.U_TextBox1.Location = New System.Drawing.Point(249, 121)
        Me.U_TextBox1.Name = "U_TextBox1"
        Me.U_TextBox1.NoUpdate = "N"
        Me.U_TextBox1.PrimaryKey = "Y"
        Me.U_TextBox1.Required = "N"
        Me.U_TextBox1.Size = New System.Drawing.Size(203, 20)
        Me.U_TextBox1.TabIndex = 493
        Me.U_TextBox1.TableName = "SYS_FOXCONFIG"
        Me.U_TextBox1.UpdateIfNull = ""
        Me.U_TextBox1.UpdateWhenFormLock = False
        Me.U_TextBox1.UpperValue = False
        Me.U_TextBox1.ViewName = "SYS_FOXCONFIG"
        '
        'FrmConfigFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 310)
        Me.Controls.Add(Me.U_TextBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PassFileTemp)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.FilePathTemp)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PassFileIn)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.FilePathIn)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PassFileOut)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FilePathOut)
        Me.Controls.Add(Me.ToolStrip2)
        Me.DefaultSave = False
        Me.HeaderSource = "SYS_FOXCONFIG"
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmConfigFile"
        Me.Text = "Cấu hình file Scadar"
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.PassFileOut.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilePathOut.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PassFileIn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilePathIn.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PassFileTemp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FilePathTemp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TextBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PassFileOut As U_TextBox.U_TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FilePathOut As U_TextBox.U_TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PassFileIn As U_TextBox.U_TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FilePathIn As U_TextBox.U_TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PassFileTemp As U_TextBox.U_TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents FilePathTemp As U_TextBox.U_TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents U_TextBox1 As U_TextBox.U_TextBox
End Class
