<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConnectFoxAcc
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DB_IPADDRESS = New U_TextBox.U_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DB_NAME = New U_TextBox.U_TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DB_USER = New U_TextBox.U_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DB_PASS = New U_TextBox.U_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DB_PORT = New U_TextBox.U_TextBox()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.U_ButtonCus2 = New U_TextBox.U_ButtonCus(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ACCTEMP = New U_TextBox.U_TextBox()
        Me.U_ButtonCus5 = New U_TextBox.U_ButtonCus(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ACCPASS = New U_TextBox.U_TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ACCUSER = New U_TextBox.U_TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DB_IPADDRESS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DB_NAME.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DB_USER.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DB_PASS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DB_PORT.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ACCTEMP.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ACCPASS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ACCUSER.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 424
        Me.Label1.Text = "IP máy chủ"
        '
        'DB_IPADDRESS
        '
        Me.DB_IPADDRESS.AllowInsert = True
        Me.DB_IPADDRESS.AllowUpdate = True
        Me.DB_IPADDRESS.AutoKeyFix = ""
        Me.DB_IPADDRESS.AutoKeyName = ""
        Me.DB_IPADDRESS.BindingSourceName = ""
        Me.DB_IPADDRESS.ChangeFormStatus = True
        Me.DB_IPADDRESS.CopyFromItem = ""
        Me.DB_IPADDRESS.DefaultValue = ""
        Me.DB_IPADDRESS.FieldName = ""
        Me.DB_IPADDRESS.FieldType = "C"
        Me.DB_IPADDRESS.KeyInsert = "Y"
        Me.DB_IPADDRESS.LinkLabel = ""
        Me.DB_IPADDRESS.Location = New System.Drawing.Point(128, 13)
        Me.DB_IPADDRESS.Name = "DB_IPADDRESS"
        Me.DB_IPADDRESS.NoUpdate = "N"
        Me.DB_IPADDRESS.PrimaryKey = ""
        Me.DB_IPADDRESS.Properties.AutoHeight = False
        Me.DB_IPADDRESS.Required = "Y"
        Me.DB_IPADDRESS.Size = New System.Drawing.Size(211, 26)
        Me.DB_IPADDRESS.TabIndex = 423
        Me.DB_IPADDRESS.TableName = ""
        Me.DB_IPADDRESS.UpdateIfNull = ""
        Me.DB_IPADDRESS.UpdateWhenFormLock = False
        Me.DB_IPADDRESS.UpperValue = False
        Me.DB_IPADDRESS.ViewName = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 426
        Me.Label2.Text = "Tên CSDL"
        '
        'DB_NAME
        '
        Me.DB_NAME.AllowInsert = True
        Me.DB_NAME.AllowUpdate = True
        Me.DB_NAME.AutoKeyFix = ""
        Me.DB_NAME.AutoKeyName = ""
        Me.DB_NAME.BindingSourceName = ""
        Me.DB_NAME.ChangeFormStatus = True
        Me.DB_NAME.CopyFromItem = ""
        Me.DB_NAME.DefaultValue = ""
        Me.DB_NAME.FieldName = ""
        Me.DB_NAME.FieldType = "C"
        Me.DB_NAME.KeyInsert = "Y"
        Me.DB_NAME.LinkLabel = ""
        Me.DB_NAME.Location = New System.Drawing.Point(128, 40)
        Me.DB_NAME.Name = "DB_NAME"
        Me.DB_NAME.NoUpdate = "N"
        Me.DB_NAME.PrimaryKey = ""
        Me.DB_NAME.Properties.AutoHeight = False
        Me.DB_NAME.Required = "Y"
        Me.DB_NAME.Size = New System.Drawing.Size(211, 26)
        Me.DB_NAME.TabIndex = 425
        Me.DB_NAME.TableName = ""
        Me.DB_NAME.UpdateIfNull = ""
        Me.DB_NAME.UpdateWhenFormLock = False
        Me.DB_NAME.UpperValue = False
        Me.DB_NAME.ViewName = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 428
        Me.Label3.Text = "Tên đăng nhập"
        '
        'DB_USER
        '
        Me.DB_USER.AllowInsert = True
        Me.DB_USER.AllowUpdate = True
        Me.DB_USER.AutoKeyFix = ""
        Me.DB_USER.AutoKeyName = ""
        Me.DB_USER.BindingSourceName = ""
        Me.DB_USER.ChangeFormStatus = True
        Me.DB_USER.CopyFromItem = ""
        Me.DB_USER.DefaultValue = ""
        Me.DB_USER.FieldName = ""
        Me.DB_USER.FieldType = "C"
        Me.DB_USER.KeyInsert = "Y"
        Me.DB_USER.LinkLabel = ""
        Me.DB_USER.Location = New System.Drawing.Point(128, 67)
        Me.DB_USER.Name = "DB_USER"
        Me.DB_USER.NoUpdate = "N"
        Me.DB_USER.PrimaryKey = ""
        Me.DB_USER.Properties.AutoHeight = False
        Me.DB_USER.Required = "Y"
        Me.DB_USER.Size = New System.Drawing.Size(211, 26)
        Me.DB_USER.TabIndex = 427
        Me.DB_USER.TableName = ""
        Me.DB_USER.UpdateIfNull = ""
        Me.DB_USER.UpdateWhenFormLock = False
        Me.DB_USER.UpperValue = False
        Me.DB_USER.ViewName = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 13)
        Me.Label4.TabIndex = 430
        Me.Label4.Text = "Mật khẩu đăng nhập"
        '
        'DB_PASS
        '
        Me.DB_PASS.AllowInsert = True
        Me.DB_PASS.AllowUpdate = True
        Me.DB_PASS.AutoKeyFix = ""
        Me.DB_PASS.AutoKeyName = ""
        Me.DB_PASS.BindingSourceName = ""
        Me.DB_PASS.ChangeFormStatus = True
        Me.DB_PASS.CopyFromItem = ""
        Me.DB_PASS.DefaultValue = ""
        Me.DB_PASS.FieldName = ""
        Me.DB_PASS.FieldType = "C"
        Me.DB_PASS.KeyInsert = "Y"
        Me.DB_PASS.LinkLabel = ""
        Me.DB_PASS.Location = New System.Drawing.Point(128, 94)
        Me.DB_PASS.Name = "DB_PASS"
        Me.DB_PASS.NoUpdate = "N"
        Me.DB_PASS.PrimaryKey = ""
        Me.DB_PASS.Properties.AutoHeight = False
        Me.DB_PASS.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.DB_PASS.Required = "Y"
        Me.DB_PASS.Size = New System.Drawing.Size(211, 26)
        Me.DB_PASS.TabIndex = 429
        Me.DB_PASS.TableName = ""
        Me.DB_PASS.UpdateIfNull = ""
        Me.DB_PASS.UpdateWhenFormLock = False
        Me.DB_PASS.UpperValue = False
        Me.DB_PASS.ViewName = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(383, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 432
        Me.Label5.Text = "Cổng"
        Me.Label5.Visible = False
        '
        'DB_PORT
        '
        Me.DB_PORT.AllowInsert = True
        Me.DB_PORT.AllowUpdate = True
        Me.DB_PORT.AutoKeyFix = ""
        Me.DB_PORT.AutoKeyName = ""
        Me.DB_PORT.BindingSourceName = ""
        Me.DB_PORT.ChangeFormStatus = True
        Me.DB_PORT.CopyFromItem = ""
        Me.DB_PORT.DefaultValue = ""
        Me.DB_PORT.FieldName = ""
        Me.DB_PORT.FieldType = "C"
        Me.DB_PORT.KeyInsert = "Y"
        Me.DB_PORT.LinkLabel = ""
        Me.DB_PORT.Location = New System.Drawing.Point(128, 122)
        Me.DB_PORT.Name = "DB_PORT"
        Me.DB_PORT.NoUpdate = "N"
        Me.DB_PORT.PrimaryKey = ""
        Me.DB_PORT.Required = "Y"
        Me.DB_PORT.Size = New System.Drawing.Size(0, 20)
        Me.DB_PORT.TabIndex = 431
        Me.DB_PORT.TableName = ""
        Me.DB_PORT.TabStop = False
        Me.DB_PORT.UpdateIfNull = ""
        Me.DB_PORT.UpdateWhenFormLock = False
        Me.DB_PORT.UpperValue = False
        Me.DB_PORT.ViewName = ""
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.DefaultUpdate = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(303, 284)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(112, 23)
        Me.U_ButtonCus1.TabIndex = 433
        Me.U_ButtonCus1.Text = "Kiểm tra kết nối"
        '
        'U_ButtonCus2
        '
        Me.U_ButtonCus2.DefaultUpdate = False
        Me.U_ButtonCus2.Location = New System.Drawing.Point(92, 284)
        Me.U_ButtonCus2.Name = "U_ButtonCus2"
        Me.U_ButtonCus2.Size = New System.Drawing.Size(74, 23)
        Me.U_ButtonCus2.TabIndex = 434
        Me.U_ButtonCus2.Text = "Thoát"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 142)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 13)
        Me.Label8.TabIndex = 440
        Me.Label8.Text = "Thông tin Scadar"
        '
        'ACCTEMP
        '
        Me.ACCTEMP.AllowInsert = True
        Me.ACCTEMP.AllowUpdate = True
        Me.ACCTEMP.AutoKeyFix = ""
        Me.ACCTEMP.AutoKeyName = ""
        Me.ACCTEMP.BindingSourceName = ""
        Me.ACCTEMP.ChangeFormStatus = True
        Me.ACCTEMP.CopyFromItem = ""
        Me.ACCTEMP.DefaultValue = ""
        Me.ACCTEMP.FieldName = ""
        Me.ACCTEMP.FieldType = "C"
        Me.ACCTEMP.KeyInsert = "Y"
        Me.ACCTEMP.LinkLabel = ""
        Me.ACCTEMP.Location = New System.Drawing.Point(128, 162)
        Me.ACCTEMP.Name = "ACCTEMP"
        Me.ACCTEMP.NoUpdate = "N"
        Me.ACCTEMP.PrimaryKey = ""
        Me.ACCTEMP.Properties.AutoHeight = False
        Me.ACCTEMP.Properties.ReadOnly = True
        Me.ACCTEMP.Required = "Y"
        Me.ACCTEMP.Size = New System.Drawing.Size(329, 26)
        Me.ACCTEMP.TabIndex = 439
        Me.ACCTEMP.TableName = ""
        Me.ACCTEMP.UpdateIfNull = ""
        Me.ACCTEMP.UpdateWhenFormLock = False
        Me.ACCTEMP.UpperValue = False
        Me.ACCTEMP.ViewName = ""
        '
        'U_ButtonCus5
        '
        Me.U_ButtonCus5.DefaultUpdate = False
        Me.U_ButtonCus5.Location = New System.Drawing.Point(463, 165)
        Me.U_ButtonCus5.Name = "U_ButtonCus5"
        Me.U_ButtonCus5.Size = New System.Drawing.Size(24, 23)
        Me.U_ButtonCus5.TabIndex = 443
        Me.U_ButtonCus5.TabStop = False
        Me.U_ButtonCus5.Text = "..."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 223)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 13)
        Me.Label6.TabIndex = 447
        Me.Label6.Text = "Mật khẩu đăng nhập"
        '
        'ACCPASS
        '
        Me.ACCPASS.AllowInsert = True
        Me.ACCPASS.AllowUpdate = True
        Me.ACCPASS.AutoKeyFix = ""
        Me.ACCPASS.AutoKeyName = ""
        Me.ACCPASS.BindingSourceName = ""
        Me.ACCPASS.ChangeFormStatus = True
        Me.ACCPASS.CopyFromItem = ""
        Me.ACCPASS.DefaultValue = ""
        Me.ACCPASS.FieldName = ""
        Me.ACCPASS.FieldType = "C"
        Me.ACCPASS.KeyInsert = "Y"
        Me.ACCPASS.LinkLabel = ""
        Me.ACCPASS.Location = New System.Drawing.Point(128, 217)
        Me.ACCPASS.Name = "ACCPASS"
        Me.ACCPASS.NoUpdate = "N"
        Me.ACCPASS.PrimaryKey = ""
        Me.ACCPASS.Properties.AutoHeight = False
        Me.ACCPASS.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ACCPASS.Required = "Y"
        Me.ACCPASS.Size = New System.Drawing.Size(211, 26)
        Me.ACCPASS.TabIndex = 446
        Me.ACCPASS.TableName = ""
        Me.ACCPASS.UpdateIfNull = ""
        Me.ACCPASS.UpdateWhenFormLock = False
        Me.ACCPASS.UpperValue = False
        Me.ACCPASS.ViewName = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 445
        Me.Label7.Text = "Tên đăng nhập"
        '
        'ACCUSER
        '
        Me.ACCUSER.AllowInsert = True
        Me.ACCUSER.AllowUpdate = True
        Me.ACCUSER.AutoKeyFix = ""
        Me.ACCUSER.AutoKeyName = ""
        Me.ACCUSER.BindingSourceName = ""
        Me.ACCUSER.ChangeFormStatus = True
        Me.ACCUSER.CopyFromItem = ""
        Me.ACCUSER.DefaultValue = ""
        Me.ACCUSER.FieldName = ""
        Me.ACCUSER.FieldType = "C"
        Me.ACCUSER.KeyInsert = "Y"
        Me.ACCUSER.LinkLabel = ""
        Me.ACCUSER.Location = New System.Drawing.Point(128, 190)
        Me.ACCUSER.Name = "ACCUSER"
        Me.ACCUSER.NoUpdate = "N"
        Me.ACCUSER.PrimaryKey = ""
        Me.ACCUSER.Properties.AutoHeight = False
        Me.ACCUSER.Required = "Y"
        Me.ACCUSER.Size = New System.Drawing.Size(211, 26)
        Me.ACCUSER.TabIndex = 444
        Me.ACCUSER.TableName = ""
        Me.ACCUSER.UpdateIfNull = ""
        Me.ACCUSER.UpdateWhenFormLock = False
        Me.ACCUSER.UpperValue = False
        Me.ACCUSER.ViewName = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 448
        Me.Label9.Text = "Đường dẫn file"
        '
        'FrmConnectFoxAcc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 320)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ACCPASS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ACCUSER)
        Me.Controls.Add(Me.U_ButtonCus5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ACCTEMP)
        Me.Controls.Add(Me.U_ButtonCus2)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DB_PORT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DB_PASS)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DB_USER)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DB_NAME)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DB_IPADDRESS)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConnectFoxAcc"
        Me.Text = "Cấu hình kế nối máy chủ"
        Me.Controls.SetChildIndex(Me.DB_IPADDRESS, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.DB_NAME, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.DB_USER, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.DB_PASS, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.DB_PORT, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus2, 0)
        Me.Controls.SetChildIndex(Me.ACCTEMP, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus5, 0)
        Me.Controls.SetChildIndex(Me.ACCUSER, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.ACCPASS, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DB_IPADDRESS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DB_NAME.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DB_USER.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DB_PASS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DB_PORT.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ACCTEMP.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ACCPASS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ACCUSER.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DB_IPADDRESS As U_TextBox.U_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DB_NAME As U_TextBox.U_TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DB_USER As U_TextBox.U_TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DB_PASS As U_TextBox.U_TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DB_PORT As U_TextBox.U_TextBox
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents U_ButtonCus2 As U_TextBox.U_ButtonCus
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ACCTEMP As U_TextBox.U_TextBox
    Friend WithEvents U_ButtonCus5 As U_TextBox.U_ButtonCus
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ACCPASS As U_TextBox.U_TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ACCUSER As U_TextBox.U_TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
