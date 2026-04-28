<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConnect
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConnect))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AHOST = New U_TextBox.U_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SYSNR = New U_TextBox.U_TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Client = New U_TextBox.U_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.User = New U_TextBox.U_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PassWD = New U_TextBox.U_TextBox()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.PassWDTmp = New U_TextBox.U_TextBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AHOST.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SYSNR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.User.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PassWD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.PassWDTmp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 19)
        Me.Label1.TabIndex = 424
        Me.Label1.Text = "AHost"
        '
        'AHOST
        '
        Me.AHOST.AllowInsert = True
        Me.AHOST.AllowUpdate = True
        Me.AHOST.AutoKeyFix = ""
        Me.AHOST.AutoKeyName = ""
        Me.AHOST.BindingSourceName = ""
        Me.AHOST.ChangeFormStatus = True
        Me.AHOST.CopyFromItem = ""
        Me.AHOST.DefaultValue = ""
        Me.AHOST.FieldName = ""
        Me.AHOST.FieldType = "C"
        Me.AHOST.KeyInsert = "Y"
        Me.AHOST.LinkLabel = ""
        Me.AHOST.Location = New System.Drawing.Point(128, 52)
        Me.AHOST.Name = "AHOST"
        Me.AHOST.NoUpdate = "N"
        Me.AHOST.PrimaryKey = ""
        Me.AHOST.Properties.AutoHeight = False
        Me.AHOST.Required = "Y"
        Me.AHOST.Size = New System.Drawing.Size(287, 26)
        Me.AHOST.TabIndex = 423
        Me.AHOST.TableName = ""
        Me.AHOST.UpdateIfNull = ""
        Me.AHOST.UpdateWhenFormLock = False
        Me.AHOST.UpperValue = False
        Me.AHOST.ViewName = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 19)
        Me.Label2.TabIndex = 426
        Me.Label2.Text = "Sysnr"
        '
        'SYSNR
        '
        Me.SYSNR.AllowInsert = True
        Me.SYSNR.AllowUpdate = True
        Me.SYSNR.AutoKeyFix = ""
        Me.SYSNR.AutoKeyName = ""
        Me.SYSNR.BindingSourceName = ""
        Me.SYSNR.ChangeFormStatus = True
        Me.SYSNR.CopyFromItem = ""
        Me.SYSNR.DefaultValue = ""
        Me.SYSNR.FieldName = ""
        Me.SYSNR.FieldType = "C"
        Me.SYSNR.KeyInsert = "Y"
        Me.SYSNR.LinkLabel = ""
        Me.SYSNR.Location = New System.Drawing.Point(128, 80)
        Me.SYSNR.Name = "SYSNR"
        Me.SYSNR.NoUpdate = "N"
        Me.SYSNR.PrimaryKey = ""
        Me.SYSNR.Properties.AutoHeight = False
        Me.SYSNR.Required = "Y"
        Me.SYSNR.Size = New System.Drawing.Size(287, 26)
        Me.SYSNR.TabIndex = 425
        Me.SYSNR.TableName = ""
        Me.SYSNR.UpdateIfNull = ""
        Me.SYSNR.UpdateWhenFormLock = False
        Me.SYSNR.UpperValue = False
        Me.SYSNR.ViewName = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 19)
        Me.Label3.TabIndex = 428
        Me.Label3.Text = "Client"
        '
        'Client
        '
        Me.Client.AllowInsert = True
        Me.Client.AllowUpdate = True
        Me.Client.AutoKeyFix = ""
        Me.Client.AutoKeyName = ""
        Me.Client.BindingSourceName = ""
        Me.Client.ChangeFormStatus = True
        Me.Client.CopyFromItem = ""
        Me.Client.DefaultValue = ""
        Me.Client.FieldName = ""
        Me.Client.FieldType = "C"
        Me.Client.KeyInsert = "Y"
        Me.Client.LinkLabel = ""
        Me.Client.Location = New System.Drawing.Point(128, 108)
        Me.Client.Name = "Client"
        Me.Client.NoUpdate = "N"
        Me.Client.PrimaryKey = ""
        Me.Client.Properties.AutoHeight = False
        Me.Client.Required = "Y"
        Me.Client.Size = New System.Drawing.Size(287, 26)
        Me.Client.TabIndex = 427
        Me.Client.TableName = ""
        Me.Client.UpdateIfNull = ""
        Me.Client.UpdateWhenFormLock = False
        Me.Client.UpperValue = False
        Me.Client.ViewName = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 19)
        Me.Label4.TabIndex = 430
        Me.Label4.Text = "User"
        '
        'User
        '
        Me.User.AllowInsert = True
        Me.User.AllowUpdate = True
        Me.User.AutoKeyFix = ""
        Me.User.AutoKeyName = ""
        Me.User.BindingSourceName = ""
        Me.User.ChangeFormStatus = True
        Me.User.CopyFromItem = ""
        Me.User.DefaultValue = ""
        Me.User.FieldName = ""
        Me.User.FieldType = "C"
        Me.User.KeyInsert = "Y"
        Me.User.LinkLabel = ""
        Me.User.Location = New System.Drawing.Point(128, 136)
        Me.User.Name = "User"
        Me.User.NoUpdate = "N"
        Me.User.PrimaryKey = ""
        Me.User.Properties.AutoHeight = False
        Me.User.Required = "Y"
        Me.User.Size = New System.Drawing.Size(287, 26)
        Me.User.TabIndex = 429
        Me.User.TableName = ""
        Me.User.UpdateIfNull = ""
        Me.User.UpdateWhenFormLock = False
        Me.User.UpperValue = False
        Me.User.ViewName = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 167)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 19)
        Me.Label5.TabIndex = 432
        Me.Label5.Text = "Pass word"
        '
        'PassWD
        '
        Me.PassWD.AllowInsert = True
        Me.PassWD.AllowUpdate = True
        Me.PassWD.AutoKeyFix = ""
        Me.PassWD.AutoKeyName = ""
        Me.PassWD.BindingSourceName = ""
        Me.PassWD.ChangeFormStatus = True
        Me.PassWD.CopyFromItem = ""
        Me.PassWD.DefaultValue = ""
        Me.PassWD.FieldName = ""
        Me.PassWD.FieldType = "C"
        Me.PassWD.KeyInsert = "Y"
        Me.PassWD.LinkLabel = ""
        Me.PassWD.Location = New System.Drawing.Point(12, 201)
        Me.PassWD.Name = "PassWD"
        Me.PassWD.NoUpdate = "N"
        Me.PassWD.PrimaryKey = ""
        Me.PassWD.Properties.AutoHeight = False
        Me.PassWD.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PassWD.Required = "Y"
        Me.PassWD.Size = New System.Drawing.Size(131, 26)
        Me.PassWD.TabIndex = 431
        Me.PassWD.TableName = ""
        Me.PassWD.TabStop = False
        Me.PassWD.UpdateIfNull = ""
        Me.PassWD.UpdateWhenFormLock = False
        Me.PassWD.UpperValue = False
        Me.PassWD.ViewName = ""
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(270, 201)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(145, 26)
        Me.U_ButtonCus1.TabIndex = 433
        Me.U_ButtonCus1.Text = "Kiểm tra kết nối"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(428, 28)
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
        'PassWDTmp
        '
        Me.PassWDTmp.AllowInsert = True
        Me.PassWDTmp.AllowUpdate = True
        Me.PassWDTmp.AutoKeyFix = ""
        Me.PassWDTmp.AutoKeyName = ""
        Me.PassWDTmp.BindingSourceName = ""
        Me.PassWDTmp.ChangeFormStatus = True
        Me.PassWDTmp.CopyFromItem = ""
        Me.PassWDTmp.DefaultValue = ""
        Me.PassWDTmp.FieldName = ""
        Me.PassWDTmp.FieldType = "C"
        Me.PassWDTmp.KeyInsert = "Y"
        Me.PassWDTmp.LinkLabel = ""
        Me.PassWDTmp.Location = New System.Drawing.Point(128, 165)
        Me.PassWDTmp.Name = "PassWDTmp"
        Me.PassWDTmp.NoUpdate = "N"
        Me.PassWDTmp.PrimaryKey = ""
        Me.PassWDTmp.Properties.AutoHeight = False
        Me.PassWDTmp.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PassWDTmp.Required = "Y"
        Me.PassWDTmp.Size = New System.Drawing.Size(287, 26)
        Me.PassWDTmp.TabIndex = 473
        Me.PassWDTmp.TableName = ""
        Me.PassWDTmp.UpdateIfNull = ""
        Me.PassWDTmp.UpdateWhenFormLock = False
        Me.PassWDTmp.UpperValue = False
        Me.PassWDTmp.ViewName = ""
        '
        'FrmConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 256)
        Me.Controls.Add(Me.PassWDTmp)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PassWD)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.User)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Client)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SYSNR)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AHOST)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmConnect"
        Me.Text = "Cấu hình kế nối máy chủ SAP"
        Me.Controls.SetChildIndex(Me.AHOST, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.SYSNR, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Client, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.User, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.PassWD, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        Me.Controls.SetChildIndex(Me.PassWDTmp, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AHOST.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SYSNR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.User.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PassWD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.PassWDTmp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AHOST As U_TextBox.U_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SYSNR As U_TextBox.U_TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Client As U_TextBox.U_TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents User As U_TextBox.U_TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PassWD As U_TextBox.U_TextBox
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents PassWDTmp As U_TextBox.U_TextBox
End Class
