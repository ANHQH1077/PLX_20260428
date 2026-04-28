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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtcompanycode = New U_TextBox.U_TextBox()
        Me.asdfgh = New System.Windows.Forms.Label()
        Me.txtwarehouse = New U_TextBox.U_TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtshippingpoint = New U_TextBox.U_TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPlant_DB = New U_TextBox.U_TextBox()
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
        CType(Me.txtcompanycode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtwarehouse.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtshippingpoint.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlant_DB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.AHOST.Location = New System.Drawing.Point(139, 52)
        Me.AHOST.Name = "AHOST"
        Me.AHOST.NoUpdate = "N"
        Me.AHOST.PrimaryKey = ""
        Me.AHOST.Properties.AutoHeight = False
        Me.AHOST.Required = "Y"
        Me.AHOST.Size = New System.Drawing.Size(287, 26)
        Me.AHOST.TabIndex = 0
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
        Me.SYSNR.Location = New System.Drawing.Point(139, 80)
        Me.SYSNR.Name = "SYSNR"
        Me.SYSNR.NoUpdate = "N"
        Me.SYSNR.PrimaryKey = ""
        Me.SYSNR.Properties.AutoHeight = False
        Me.SYSNR.Required = "Y"
        Me.SYSNR.Size = New System.Drawing.Size(287, 26)
        Me.SYSNR.TabIndex = 1
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
        Me.Client.Location = New System.Drawing.Point(139, 108)
        Me.Client.Name = "Client"
        Me.Client.NoUpdate = "N"
        Me.Client.PrimaryKey = ""
        Me.Client.Properties.AutoHeight = False
        Me.Client.Required = "Y"
        Me.Client.Size = New System.Drawing.Size(287, 26)
        Me.Client.TabIndex = 2
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
        Me.User.Location = New System.Drawing.Point(139, 136)
        Me.User.Name = "User"
        Me.User.NoUpdate = "N"
        Me.User.PrimaryKey = ""
        Me.User.Properties.AutoHeight = False
        Me.User.Required = "Y"
        Me.User.Size = New System.Drawing.Size(287, 26)
        Me.User.TabIndex = 3
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
        Me.PassWD.Size = New System.Drawing.Size(0, 26)
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
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(270, 370)
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
        Me.ToolStrip2.Size = New System.Drawing.Size(438, 28)
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
        Me.PassWDTmp.Location = New System.Drawing.Point(139, 165)
        Me.PassWDTmp.Name = "PassWDTmp"
        Me.PassWDTmp.NoUpdate = "N"
        Me.PassWDTmp.PrimaryKey = ""
        Me.PassWDTmp.Properties.AutoHeight = False
        Me.PassWDTmp.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PassWDTmp.Required = "Y"
        Me.PassWDTmp.Size = New System.Drawing.Size(287, 26)
        Me.PassWDTmp.TabIndex = 4
        Me.PassWDTmp.TableName = ""
        Me.PassWDTmp.UpdateIfNull = ""
        Me.PassWDTmp.UpdateWhenFormLock = False
        Me.PassWDTmp.UpperValue = False
        Me.PassWDTmp.ViewName = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 19)
        Me.Label6.TabIndex = 475
        Me.Label6.Text = "Company Code"
        '
        'txtcompanycode
        '
        Me.txtcompanycode.AllowInsert = True
        Me.txtcompanycode.AllowUpdate = True
        Me.txtcompanycode.AutoKeyFix = ""
        Me.txtcompanycode.AutoKeyName = ""
        Me.txtcompanycode.BindingSourceName = ""
        Me.txtcompanycode.ChangeFormStatus = True
        Me.txtcompanycode.CopyFromItem = ""
        Me.txtcompanycode.DefaultValue = ""
        Me.txtcompanycode.FieldName = ""
        Me.txtcompanycode.FieldType = "C"
        Me.txtcompanycode.KeyInsert = "Y"
        Me.txtcompanycode.LinkLabel = ""
        Me.txtcompanycode.Location = New System.Drawing.Point(139, 193)
        Me.txtcompanycode.Name = "txtcompanycode"
        Me.txtcompanycode.NoUpdate = "N"
        Me.txtcompanycode.PrimaryKey = ""
        Me.txtcompanycode.Properties.AutoHeight = False
        Me.txtcompanycode.Required = "Y"
        Me.txtcompanycode.Size = New System.Drawing.Size(287, 26)
        Me.txtcompanycode.TabIndex = 5
        Me.txtcompanycode.TableName = ""
        Me.txtcompanycode.UpdateIfNull = ""
        Me.txtcompanycode.UpdateWhenFormLock = False
        Me.txtcompanycode.UpperValue = False
        Me.txtcompanycode.ViewName = ""
        '
        'asdfgh
        '
        Me.asdfgh.AutoSize = True
        Me.asdfgh.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.asdfgh.Location = New System.Drawing.Point(11, 224)
        Me.asdfgh.Name = "asdfgh"
        Me.asdfgh.Size = New System.Drawing.Size(87, 19)
        Me.asdfgh.TabIndex = 477
        Me.asdfgh.Text = "Warehouse"
        '
        'txtwarehouse
        '
        Me.txtwarehouse.AllowInsert = True
        Me.txtwarehouse.AllowUpdate = True
        Me.txtwarehouse.AutoKeyFix = ""
        Me.txtwarehouse.AutoKeyName = ""
        Me.txtwarehouse.BindingSourceName = ""
        Me.txtwarehouse.ChangeFormStatus = True
        Me.txtwarehouse.CopyFromItem = ""
        Me.txtwarehouse.DefaultValue = ""
        Me.txtwarehouse.FieldName = ""
        Me.txtwarehouse.FieldType = "C"
        Me.txtwarehouse.KeyInsert = "Y"
        Me.txtwarehouse.LinkLabel = ""
        Me.txtwarehouse.Location = New System.Drawing.Point(139, 221)
        Me.txtwarehouse.Name = "txtwarehouse"
        Me.txtwarehouse.NoUpdate = "N"
        Me.txtwarehouse.PrimaryKey = ""
        Me.txtwarehouse.Properties.AutoHeight = False
        Me.txtwarehouse.Required = "Y"
        Me.txtwarehouse.Size = New System.Drawing.Size(287, 26)
        Me.txtwarehouse.TabIndex = 6
        Me.txtwarehouse.TableName = ""
        Me.txtwarehouse.UpdateIfNull = ""
        Me.txtwarehouse.UpdateWhenFormLock = False
        Me.txtwarehouse.UpperValue = False
        Me.txtwarehouse.ViewName = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 252)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 19)
        Me.Label8.TabIndex = 479
        Me.Label8.Text = "Shipping point"
        Me.Label8.UseWaitCursor = True
        '
        'txtshippingpoint
        '
        Me.txtshippingpoint.AllowInsert = True
        Me.txtshippingpoint.AllowUpdate = True
        Me.txtshippingpoint.AutoKeyFix = ""
        Me.txtshippingpoint.AutoKeyName = ""
        Me.txtshippingpoint.BindingSourceName = ""
        Me.txtshippingpoint.ChangeFormStatus = True
        Me.txtshippingpoint.CopyFromItem = ""
        Me.txtshippingpoint.DefaultValue = ""
        Me.txtshippingpoint.FieldName = ""
        Me.txtshippingpoint.FieldType = "C"
        Me.txtshippingpoint.KeyInsert = "Y"
        Me.txtshippingpoint.LinkLabel = ""
        Me.txtshippingpoint.Location = New System.Drawing.Point(139, 249)
        Me.txtshippingpoint.Name = "txtshippingpoint"
        Me.txtshippingpoint.NoUpdate = "N"
        Me.txtshippingpoint.PrimaryKey = ""
        Me.txtshippingpoint.Properties.AutoHeight = False
        Me.txtshippingpoint.Required = "Y"
        Me.txtshippingpoint.Size = New System.Drawing.Size(287, 26)
        Me.txtshippingpoint.TabIndex = 7
        Me.txtshippingpoint.TableName = ""
        Me.txtshippingpoint.UpdateIfNull = ""
        Me.txtshippingpoint.UpdateWhenFormLock = False
        Me.txtshippingpoint.UpperValue = False
        Me.txtshippingpoint.ViewName = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 280)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 19)
        Me.Label9.TabIndex = 481
        Me.Label9.Text = "Plant"
        '
        'txtPlant_DB
        '
        Me.txtPlant_DB.AllowInsert = True
        Me.txtPlant_DB.AllowUpdate = True
        Me.txtPlant_DB.AutoKeyFix = ""
        Me.txtPlant_DB.AutoKeyName = ""
        Me.txtPlant_DB.BindingSourceName = ""
        Me.txtPlant_DB.ChangeFormStatus = True
        Me.txtPlant_DB.CopyFromItem = ""
        Me.txtPlant_DB.DefaultValue = ""
        Me.txtPlant_DB.FieldName = ""
        Me.txtPlant_DB.FieldType = "C"
        Me.txtPlant_DB.KeyInsert = "Y"
        Me.txtPlant_DB.LinkLabel = ""
        Me.txtPlant_DB.Location = New System.Drawing.Point(139, 277)
        Me.txtPlant_DB.Name = "txtPlant_DB"
        Me.txtPlant_DB.NoUpdate = "N"
        Me.txtPlant_DB.PrimaryKey = ""
        Me.txtPlant_DB.Properties.AutoHeight = False
        Me.txtPlant_DB.Required = "Y"
        Me.txtPlant_DB.Size = New System.Drawing.Size(287, 26)
        Me.txtPlant_DB.TabIndex = 8
        Me.txtPlant_DB.TableName = ""
        Me.txtPlant_DB.UpdateIfNull = ""
        Me.txtPlant_DB.UpdateWhenFormLock = False
        Me.txtPlant_DB.UpperValue = False
        Me.txtPlant_DB.ViewName = ""
        '
        'FrmConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(438, 426)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtPlant_DB)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtshippingpoint)
        Me.Controls.Add(Me.asdfgh)
        Me.Controls.Add(Me.txtwarehouse)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtcompanycode)
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
        Me.MaximizeBox = False
        Me.Name = "FrmConnect"
        Me.Text = "Cấu hình kết nối máy chủ SAP"
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
        Me.Controls.SetChildIndex(Me.txtcompanycode, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtwarehouse, 0)
        Me.Controls.SetChildIndex(Me.asdfgh, 0)
        Me.Controls.SetChildIndex(Me.txtshippingpoint, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txtPlant_DB, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
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
        CType(Me.txtcompanycode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtwarehouse.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtshippingpoint.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlant_DB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcompanycode As U_TextBox.U_TextBox
    Friend WithEvents asdfgh As System.Windows.Forms.Label
    Friend WithEvents txtwarehouse As U_TextBox.U_TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtshippingpoint As U_TextBox.U_TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPlant_DB As U_TextBox.U_TextBox
End Class
