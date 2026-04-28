<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSendAppr
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.AppUser = New U_TextBox.U_TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Desc = New U_TextBox.U_TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FieldValue = New U_TextBox.U_TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FormTitle = New U_TextBox.U_TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.APPUSERID = New U_TextBox.U_TextBox()
        Me.USER_ID = New U_TextBox.U_TextBox()
        Me.USER_NAME = New U_TextBox.U_TextBox()
        Me.CompanyCode = New U_TextBox.U_TextBox()
        Me.CompanyName = New U_TextBox.U_TextBox()
        Me.ShopCode = New U_TextBox.U_TextBox()
        Me.ShopName = New U_TextBox.U_TextBox()
        Me.Module1 = New U_TextBox.U_TextBox()
        Me.ColumnName = New U_TextBox.U_TextBox()
        Me.ItemNameApp = New U_TextBox.U_TextBox()
        Me.ColumnNameApp = New U_TextBox.U_TextBox()
        Me.CrDoc = New U_TextBox.U_TextBox()
        Me.CrUser = New U_TextBox.U_TextBox()
        Me.CrDate = New U_TextBox.U_TextBox()
        Me.FieldDoc = New U_TextBox.U_TextBox()
        Me.SendUser = New U_TextBox.U_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ValueApp = New U_TextBox.U_NumericEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.AppSendMail = New U_TextBox.U_CheckBox()
        Me.AppMail = New U_TextBox.U_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.TableName = New U_TextBox.U_TextBox()
        Me.ItemName = New U_TextBox.U_TextBox()
        CType(Me.AppUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Desc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldValue.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FormTitle.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APPUSERID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USER_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USER_NAME.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShopCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShopName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Module1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColumnName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemNameApp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColumnNameApp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrDoc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FieldDoc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SendUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ValueApp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppSendMail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppMail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TableName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AppUser
        '
        Me.AppUser.FieldName = "AppUser"
        Me.AppUser.FieldType = "C"
        Me.AppUser.KeyInsert = ""
        Me.AppUser.Location = New System.Drawing.Point(126, 134)
        Me.AppUser.Name = "AppUser"
        Me.AppUser.NoUpdate = "N"
        Me.AppUser.PrimaryKey = "Y"
        Me.AppUser.Required = ""
        Me.AppUser.Size = New System.Drawing.Size(278, 20)
        Me.AppUser.TabIndex = 357
        Me.AppUser.TableName = "FPTAPPUSER"
        Me.AppUser.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (AppUser)"
        Me.AppUser.UpdateIfNull = ""
        Me.AppUser.ViewName = "FPTAPPUSER"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(28, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 13)
        Me.Label9.TabIndex = 356
        Me.Label9.Text = "User phê duyệt"
        '
        'Desc
        '
        Me.Desc.Enabled = False
        Me.Desc.FieldName = "Desc"
        Me.Desc.FieldType = "C"
        Me.Desc.KeyInsert = ""
        Me.Desc.Location = New System.Drawing.Point(126, 91)
        Me.Desc.Name = "Desc"
        Me.Desc.NoUpdate = "N"
        Me.Desc.PrimaryKey = ""
        Me.Desc.Required = ""
        Me.Desc.Size = New System.Drawing.Size(278, 20)
        Me.Desc.TabIndex = 354
        Me.Desc.TableName = "FPTAPPUSER"
        Me.Desc.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (Desc)"
        Me.Desc.UpdateIfNull = ""
        Me.Desc.ViewName = "FPTAPPUSER"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 353
        Me.Label6.Text = "Ghi chú"
        '
        'FieldValue
        '
        Me.FieldValue.Enabled = False
        Me.FieldValue.FieldName = "FieldValue"
        Me.FieldValue.FieldType = "C"
        Me.FieldValue.KeyInsert = ""
        Me.FieldValue.Location = New System.Drawing.Point(126, 49)
        Me.FieldValue.Name = "FieldValue"
        Me.FieldValue.NoUpdate = "N"
        Me.FieldValue.PrimaryKey = ""
        Me.FieldValue.Required = "Y"
        Me.FieldValue.Size = New System.Drawing.Size(129, 20)
        Me.FieldValue.TabIndex = 352
        Me.FieldValue.TableName = "FPTAPPUSER"
        Me.FieldValue.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (FieldValue)"
        Me.FieldValue.UpdateIfNull = ""
        Me.FieldValue.ViewName = "FPTAPPUSER"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 351
        Me.Label5.Text = "Số giao dịch"
        '
        'FormTitle
        '
        Me.FormTitle.Enabled = False
        Me.FormTitle.FieldName = "FormTitle"
        Me.FormTitle.FieldType = "C"
        Me.FormTitle.KeyInsert = ""
        Me.FormTitle.Location = New System.Drawing.Point(126, 28)
        Me.FormTitle.Name = "FormTitle"
        Me.FormTitle.NoUpdate = "N"
        Me.FormTitle.PrimaryKey = "N"
        Me.FormTitle.Required = ""
        Me.FormTitle.Size = New System.Drawing.Size(278, 20)
        Me.FormTitle.TabIndex = 350
        Me.FormTitle.TableName = "FPTAPPUSER"
        Me.FormTitle.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (FormTitle)"
        Me.FormTitle.UpdateIfNull = ""
        Me.FormTitle.ViewName = "FPTAPPUSER"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 349
        Me.Label4.Text = "Chức năng"
        '
        'APPUSERID
        '
        Me.APPUSERID.FieldName = "APPUSERID"
        Me.APPUSERID.FieldType = "N"
        Me.APPUSERID.KeyInsert = "N"
        Me.APPUSERID.Location = New System.Drawing.Point(712, 3)
        Me.APPUSERID.Name = "APPUSERID"
        Me.APPUSERID.NoUpdate = "N"
        Me.APPUSERID.PrimaryKey = "Y"
        Me.APPUSERID.Required = ""
        Me.APPUSERID.Size = New System.Drawing.Size(101, 20)
        Me.APPUSERID.TabIndex = 358
        Me.APPUSERID.TableName = "FPTAPPUSER"
        Me.APPUSERID.TabStop = False
        Me.APPUSERID.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (APPUSERID)"
        Me.APPUSERID.UpdateIfNull = ""
        Me.APPUSERID.ViewName = "FPTAPPUSER"
        '
        'USER_ID
        '
        Me.USER_ID.FieldName = "USER_ID"
        Me.USER_ID.FieldType = "N"
        Me.USER_ID.KeyInsert = ""
        Me.USER_ID.Location = New System.Drawing.Point(712, 24)
        Me.USER_ID.Name = "USER_ID"
        Me.USER_ID.NoUpdate = "N"
        Me.USER_ID.PrimaryKey = "N"
        Me.USER_ID.Required = ""
        Me.USER_ID.Size = New System.Drawing.Size(101, 20)
        Me.USER_ID.TabIndex = 359
        Me.USER_ID.TableName = "FPTAPPUSER"
        Me.USER_ID.TabStop = False
        Me.USER_ID.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (USER_ID)"
        Me.USER_ID.UpdateIfNull = ""
        Me.USER_ID.ViewName = "FPTAPPUSER"
        '
        'USER_NAME
        '
        Me.USER_NAME.FieldName = "USER_NAME"
        Me.USER_NAME.FieldType = "C"
        Me.USER_NAME.KeyInsert = ""
        Me.USER_NAME.Location = New System.Drawing.Point(712, 49)
        Me.USER_NAME.Name = "USER_NAME"
        Me.USER_NAME.NoUpdate = "N"
        Me.USER_NAME.PrimaryKey = "N"
        Me.USER_NAME.Required = ""
        Me.USER_NAME.Size = New System.Drawing.Size(101, 20)
        Me.USER_NAME.TabIndex = 360
        Me.USER_NAME.TableName = "FPTAPPUSER"
        Me.USER_NAME.TabStop = False
        Me.USER_NAME.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (USER_NAME)"
        Me.USER_NAME.UpdateIfNull = ""
        Me.USER_NAME.ViewName = "FPTAPPUSER"
        '
        'CompanyCode
        '
        Me.CompanyCode.FieldName = "CompanyCode"
        Me.CompanyCode.FieldType = "C"
        Me.CompanyCode.KeyInsert = ""
        Me.CompanyCode.Location = New System.Drawing.Point(703, 75)
        Me.CompanyCode.Name = "CompanyCode"
        Me.CompanyCode.NoUpdate = "N"
        Me.CompanyCode.PrimaryKey = "N"
        Me.CompanyCode.Required = ""
        Me.CompanyCode.Size = New System.Drawing.Size(101, 20)
        Me.CompanyCode.TabIndex = 361
        Me.CompanyCode.TableName = "FPTAPPUSER"
        Me.CompanyCode.TabStop = False
        Me.CompanyCode.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (CompanyCode)"
        Me.CompanyCode.UpdateIfNull = ""
        Me.CompanyCode.ViewName = "FPTAPPUSER"
        '
        'CompanyName
        '
        Me.CompanyName.FieldName = "CompanyName"
        Me.CompanyName.FieldType = "C"
        Me.CompanyName.KeyInsert = ""
        Me.CompanyName.Location = New System.Drawing.Point(703, 113)
        Me.CompanyName.Name = "CompanyName"
        Me.CompanyName.NoUpdate = "N"
        Me.CompanyName.PrimaryKey = "N"
        Me.CompanyName.Required = ""
        Me.CompanyName.Size = New System.Drawing.Size(101, 20)
        Me.CompanyName.TabIndex = 362
        Me.CompanyName.TableName = "FPTAPPUSER"
        Me.CompanyName.TabStop = False
        Me.CompanyName.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (CompanyName)"
        Me.CompanyName.UpdateIfNull = ""
        Me.CompanyName.ViewName = "FPTAPPUSER"
        '
        'ShopCode
        '
        Me.ShopCode.FieldName = "ShopCode"
        Me.ShopCode.FieldType = "C"
        Me.ShopCode.KeyInsert = ""
        Me.ShopCode.Location = New System.Drawing.Point(689, 139)
        Me.ShopCode.Name = "ShopCode"
        Me.ShopCode.NoUpdate = "N"
        Me.ShopCode.PrimaryKey = "N"
        Me.ShopCode.Required = ""
        Me.ShopCode.Size = New System.Drawing.Size(101, 20)
        Me.ShopCode.TabIndex = 363
        Me.ShopCode.TableName = "FPTAPPUSER"
        Me.ShopCode.TabStop = False
        Me.ShopCode.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (ShopCode)"
        Me.ShopCode.UpdateIfNull = ""
        Me.ShopCode.ViewName = "FPTAPPUSER"
        '
        'ShopName
        '
        Me.ShopName.FieldName = "ShopName"
        Me.ShopName.FieldType = "C"
        Me.ShopName.KeyInsert = ""
        Me.ShopName.Location = New System.Drawing.Point(703, 165)
        Me.ShopName.Name = "ShopName"
        Me.ShopName.NoUpdate = "N"
        Me.ShopName.PrimaryKey = "N"
        Me.ShopName.Required = ""
        Me.ShopName.Size = New System.Drawing.Size(101, 20)
        Me.ShopName.TabIndex = 364
        Me.ShopName.TableName = "FPTAPPUSER"
        Me.ShopName.TabStop = False
        Me.ShopName.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (ShopName)"
        Me.ShopName.UpdateIfNull = ""
        Me.ShopName.ViewName = "FPTAPPUSER"
        '
        'Module1
        '
        Me.Module1.FieldName = "Module"
        Me.Module1.FieldType = "C"
        Me.Module1.KeyInsert = ""
        Me.Module1.Location = New System.Drawing.Point(703, 191)
        Me.Module1.Name = "Module1"
        Me.Module1.NoUpdate = "N"
        Me.Module1.PrimaryKey = "N"
        Me.Module1.Required = ""
        Me.Module1.Size = New System.Drawing.Size(101, 20)
        Me.Module1.TabIndex = 365
        Me.Module1.TableName = "FPTAPPUSER"
        Me.Module1.TabStop = False
        Me.Module1.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (Module)"
        Me.Module1.UpdateIfNull = ""
        Me.Module1.ViewName = "FPTAPPUSER"
        '
        'ColumnName
        '
        Me.ColumnName.FieldName = "ColumnName"
        Me.ColumnName.FieldType = "C"
        Me.ColumnName.KeyInsert = ""
        Me.ColumnName.Location = New System.Drawing.Point(703, 217)
        Me.ColumnName.Name = "ColumnName"
        Me.ColumnName.NoUpdate = "N"
        Me.ColumnName.PrimaryKey = "N"
        Me.ColumnName.Required = ""
        Me.ColumnName.Size = New System.Drawing.Size(101, 20)
        Me.ColumnName.TabIndex = 366
        Me.ColumnName.TableName = "FPTAPPUSER"
        Me.ColumnName.TabStop = False
        Me.ColumnName.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (ColumnName)"
        Me.ColumnName.UpdateIfNull = ""
        Me.ColumnName.ViewName = "FPTAPPUSER"
        '
        'ItemNameApp
        '
        Me.ItemNameApp.FieldName = "ItemNameApp"
        Me.ItemNameApp.FieldType = "C"
        Me.ItemNameApp.KeyInsert = ""
        Me.ItemNameApp.Location = New System.Drawing.Point(689, 243)
        Me.ItemNameApp.Name = "ItemNameApp"
        Me.ItemNameApp.NoUpdate = "N"
        Me.ItemNameApp.PrimaryKey = "N"
        Me.ItemNameApp.Required = ""
        Me.ItemNameApp.Size = New System.Drawing.Size(101, 20)
        Me.ItemNameApp.TabIndex = 367
        Me.ItemNameApp.TableName = "FPTAPPUSER"
        Me.ItemNameApp.TabStop = False
        Me.ItemNameApp.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (ItemNameApp)"
        Me.ItemNameApp.UpdateIfNull = ""
        Me.ItemNameApp.ViewName = "FPTAPPUSER"
        '
        'ColumnNameApp
        '
        Me.ColumnNameApp.FieldName = "ColumnNameApp"
        Me.ColumnNameApp.FieldType = "C"
        Me.ColumnNameApp.KeyInsert = ""
        Me.ColumnNameApp.Location = New System.Drawing.Point(712, 347)
        Me.ColumnNameApp.Name = "ColumnNameApp"
        Me.ColumnNameApp.NoUpdate = "N"
        Me.ColumnNameApp.PrimaryKey = "N"
        Me.ColumnNameApp.Required = ""
        Me.ColumnNameApp.Size = New System.Drawing.Size(101, 20)
        Me.ColumnNameApp.TabIndex = 368
        Me.ColumnNameApp.TableName = "FPTAPPUSER"
        Me.ColumnNameApp.TabStop = False
        Me.ColumnNameApp.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (ColumnNameApp)"
        Me.ColumnNameApp.UpdateIfNull = ""
        Me.ColumnNameApp.ViewName = "FPTAPPUSER"
        '
        'CrDoc
        '
        Me.CrDoc.FieldName = "CrDoc"
        Me.CrDoc.FieldType = "C"
        Me.CrDoc.KeyInsert = ""
        Me.CrDoc.Location = New System.Drawing.Point(689, 269)
        Me.CrDoc.Name = "CrDoc"
        Me.CrDoc.NoUpdate = "N"
        Me.CrDoc.PrimaryKey = "N"
        Me.CrDoc.Required = ""
        Me.CrDoc.Size = New System.Drawing.Size(101, 20)
        Me.CrDoc.TabIndex = 370
        Me.CrDoc.TableName = "FPTAPPUSER"
        Me.CrDoc.TabStop = False
        Me.CrDoc.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (CrDoc)"
        Me.CrDoc.UpdateIfNull = ""
        Me.CrDoc.ViewName = "FPTAPPUSER"
        '
        'CrUser
        '
        Me.CrUser.FieldName = "CrUser"
        Me.CrUser.FieldType = "C"
        Me.CrUser.KeyInsert = ""
        Me.CrUser.Location = New System.Drawing.Point(671, 295)
        Me.CrUser.Name = "CrUser"
        Me.CrUser.NoUpdate = "N"
        Me.CrUser.PrimaryKey = "N"
        Me.CrUser.Required = ""
        Me.CrUser.Size = New System.Drawing.Size(101, 20)
        Me.CrUser.TabIndex = 371
        Me.CrUser.TableName = "FPTAPPUSER"
        Me.CrUser.TabStop = False
        Me.CrUser.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (CrUser)"
        Me.CrUser.UpdateIfNull = ""
        Me.CrUser.ViewName = "FPTAPPUSER"
        '
        'CrDate
        '
        Me.CrDate.FieldName = "CrDate"
        Me.CrDate.FieldType = "D"
        Me.CrDate.KeyInsert = ""
        Me.CrDate.Location = New System.Drawing.Point(671, 321)
        Me.CrDate.Name = "CrDate"
        Me.CrDate.NoUpdate = "N"
        Me.CrDate.PrimaryKey = "N"
        Me.CrDate.Required = ""
        Me.CrDate.Size = New System.Drawing.Size(101, 20)
        Me.CrDate.TabIndex = 372
        Me.CrDate.TableName = "FPTAPPUSER"
        Me.CrDate.TabStop = False
        Me.CrDate.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (CrDate)"
        Me.CrDate.UpdateIfNull = ""
        Me.CrDate.ViewName = "FPTAPPUSER"
        '
        'FieldDoc
        '
        Me.FieldDoc.FieldName = "FieldDoc"
        Me.FieldDoc.FieldType = "C"
        Me.FieldDoc.KeyInsert = ""
        Me.FieldDoc.Location = New System.Drawing.Point(573, 269)
        Me.FieldDoc.Name = "FieldDoc"
        Me.FieldDoc.NoUpdate = "N"
        Me.FieldDoc.PrimaryKey = "N"
        Me.FieldDoc.Required = ""
        Me.FieldDoc.Size = New System.Drawing.Size(101, 20)
        Me.FieldDoc.TabIndex = 373
        Me.FieldDoc.TableName = "FPTAPPUSER"
        Me.FieldDoc.TabStop = False
        Me.FieldDoc.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (FieldDoc)"
        Me.FieldDoc.UpdateIfNull = ""
        Me.FieldDoc.ViewName = "FPTAPPUSER"
        '
        'SendUser
        '
        Me.SendUser.FieldName = "SendUser"
        Me.SendUser.FieldType = "C"
        Me.SendUser.KeyInsert = ""
        Me.SendUser.Location = New System.Drawing.Point(573, 226)
        Me.SendUser.Name = "SendUser"
        Me.SendUser.NoUpdate = "N"
        Me.SendUser.PrimaryKey = "N"
        Me.SendUser.Required = ""
        Me.SendUser.Size = New System.Drawing.Size(101, 20)
        Me.SendUser.TabIndex = 374
        Me.SendUser.TableName = "FPTAPPUSER"
        Me.SendUser.TabStop = False
        Me.SendUser.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (SendUser)"
        Me.SendUser.UpdateIfNull = ""
        Me.SendUser.ViewName = "FPTAPPUSER"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 375
        Me.Label2.Text = "Giá trị"
        '
        'ValueApp
        '
        Me.ValueApp.Digit = True
        Me.ValueApp.Enabled = False
        Me.ValueApp.FieldName = "ValueApp"
        Me.ValueApp.FieldType = "F"
        Me.ValueApp.KeyInsert = ""
        Me.ValueApp.LocalDecimal = False
        Me.ValueApp.Location = New System.Drawing.Point(126, 70)
        Me.ValueApp.Name = "ValueApp"
        Me.ValueApp.NoUpdate = "N"
        Me.ValueApp.NumberDecimal = 0
        Me.ValueApp.PrimaryKey = ""
        Me.ValueApp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)})
        Me.ValueApp.Required = ""
        Me.ValueApp.Size = New System.Drawing.Size(129, 20)
        Me.ValueApp.TabIndex = 376
        Me.ValueApp.TableName = "FPTAPPUSER"
        Me.ValueApp.ToolTip = "NAME(ValueApp) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (ValueApp)"
        Me.ValueApp.UpdateIfNull = ""
        Me.ValueApp.ViewName = "FPTAPPUSER"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 13)
        Me.Label3.TabIndex = 377
        Me.Label3.Text = "Thông tin gửi phê duyệt"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 13)
        Me.Label7.TabIndex = 378
        Me.Label7.Text = "Thông tin phê duyệt"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(28, 162)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(44, 13)
        Me.Label58.TabIndex = 380
        Me.Label58.Text = "Gửi mail"
        '
        'AppSendMail
        '
        Me.AppSendMail.CheckValue = "Y"
        Me.AppSendMail.Enabled = False
        Me.AppSendMail.FieldName = "U_ShMent"
        Me.AppSendMail.FieldType = "C"
        Me.AppSendMail.ItemValue = ""
        Me.AppSendMail.KeyInsert = ""
        Me.AppSendMail.Location = New System.Drawing.Point(124, 160)
        Me.AppSendMail.Name = "AppSendMail"
        Me.AppSendMail.NoUpdate = ""
        Me.AppSendMail.PrimaryKey = ""
        Me.AppSendMail.Properties.Caption = ""
        Me.AppSendMail.Required = ""
        Me.AppSendMail.Size = New System.Drawing.Size(21, 19)
        Me.AppSendMail.TabIndex = 379
        Me.AppSendMail.TableName = "FPTORDR"
        Me.AppSendMail.ToolTip = "NAME(AppSendMail) VIEW(FPTORDR) TAB(FPTORDR) FIELD (U_ShMent) VALUE(False)"
        Me.AppSendMail.UnCheckValue = "N"
        Me.AppSendMail.UpdateIfNull = ""
        Me.AppSendMail.ViewName = "FPTORDR"
        '
        'AppMail
        '
        Me.AppMail.FieldName = "AppMail"
        Me.AppMail.FieldType = "C"
        Me.AppMail.KeyInsert = ""
        Me.AppMail.Location = New System.Drawing.Point(126, 185)
        Me.AppMail.Name = "AppMail"
        Me.AppMail.NoUpdate = "N"
        Me.AppMail.PrimaryKey = ""
        Me.AppMail.Required = ""
        Me.AppMail.Size = New System.Drawing.Size(278, 20)
        Me.AppMail.TabIndex = 382
        Me.AppMail.TableName = "FPTAPPUSER"
        Me.AppMail.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (AppMail)"
        Me.AppMail.UpdateIfNull = ""
        Me.AppMail.ViewName = "FPTAPPUSER"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 188)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 381
        Me.Label1.Text = "Email"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(3, 241)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(102, 23)
        Me.btnOK.TabIndex = 383
        Me.btnOK.Text = "&Gửi phê duyệt"
        '
        'TableName
        '
        Me.TableName.FieldName = "TableName"
        Me.TableName.FieldType = "C"
        Me.TableName.KeyInsert = ""
        Me.TableName.Location = New System.Drawing.Point(442, 284)
        Me.TableName.Name = "TableName"
        Me.TableName.NoUpdate = "N"
        Me.TableName.PrimaryKey = "N"
        Me.TableName.Required = ""
        Me.TableName.Size = New System.Drawing.Size(101, 20)
        Me.TableName.TabIndex = 384
        Me.TableName.TableName = "FPTAPPUSER"
        Me.TableName.TabStop = False
        Me.TableName.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (TableName)"
        Me.TableName.UpdateIfNull = ""
        Me.TableName.ViewName = "FPTAPPUSER"
        '
        'ItemName
        '
        Me.ItemName.FieldName = "ItemName"
        Me.ItemName.FieldType = "C"
        Me.ItemName.KeyInsert = ""
        Me.ItemName.Location = New System.Drawing.Point(517, 321)
        Me.ItemName.Name = "ItemName"
        Me.ItemName.NoUpdate = "N"
        Me.ItemName.PrimaryKey = "N"
        Me.ItemName.Required = ""
        Me.ItemName.Size = New System.Drawing.Size(101, 20)
        Me.ItemName.TabIndex = 385
        Me.ItemName.TableName = "FPTAPPUSER"
        Me.ItemName.TabStop = False
        Me.ItemName.ToolTip = "NAME(U_TextBox) VIEW(FPTAPPUSER) TAB(FPTAPPUSER) FIELD (ItemName)"
        Me.ItemName.UpdateIfNull = ""
        Me.ItemName.ViewName = "FPTAPPUSER"
        '
        'FrmSendAppr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 267)
        Me.Controls.Add(Me.ItemName)
        Me.Controls.Add(Me.TableName)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.AppMail)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.AppSendMail)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ValueApp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.SendUser)
        Me.Controls.Add(Me.FieldDoc)
        Me.Controls.Add(Me.CrDate)
        Me.Controls.Add(Me.CrUser)
        Me.Controls.Add(Me.CrDoc)
        Me.Controls.Add(Me.ColumnNameApp)
        Me.Controls.Add(Me.ItemNameApp)
        Me.Controls.Add(Me.ColumnName)
        Me.Controls.Add(Me.Module1)
        Me.Controls.Add(Me.ShopName)
        Me.Controls.Add(Me.ShopCode)
        Me.Controls.Add(Me.CompanyName)
        Me.Controls.Add(Me.CompanyCode)
        Me.Controls.Add(Me.USER_NAME)
        Me.Controls.Add(Me.USER_ID)
        Me.Controls.Add(Me.APPUSERID)
        Me.Controls.Add(Me.AppUser)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Desc)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.FieldValue)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.FormTitle)
        Me.Controls.Add(Me.Label4)
        Me.Name = "FrmSendAppr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gửi yêu cầu phê duyệt"
        CType(Me.AppUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Desc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldValue.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FormTitle.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APPUSERID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USER_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USER_NAME.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShopCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShopName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Module1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColumnName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemNameApp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColumnNameApp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrDoc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FieldDoc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SendUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ValueApp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppSendMail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppMail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TableName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AppUser As U_TextBox.U_TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Desc As U_TextBox.U_TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents FieldValue As U_TextBox.U_TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents FormTitle As U_TextBox.U_TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents APPUSERID As U_TextBox.U_TextBox
    Friend WithEvents USER_ID As U_TextBox.U_TextBox
    Friend WithEvents USER_NAME As U_TextBox.U_TextBox
    Friend WithEvents CompanyCode As U_TextBox.U_TextBox
    Friend WithEvents CompanyName As U_TextBox.U_TextBox
    Friend WithEvents ShopCode As U_TextBox.U_TextBox
    Friend WithEvents ShopName As U_TextBox.U_TextBox
    Friend WithEvents Module1 As U_TextBox.U_TextBox
    Friend WithEvents ColumnName As U_TextBox.U_TextBox
    Friend WithEvents ItemNameApp As U_TextBox.U_TextBox
    Friend WithEvents ColumnNameApp As U_TextBox.U_TextBox
    Friend WithEvents CrDoc As U_TextBox.U_TextBox
    Friend WithEvents CrUser As U_TextBox.U_TextBox
    Friend WithEvents CrDate As U_TextBox.U_TextBox
    Friend WithEvents FieldDoc As U_TextBox.U_TextBox
    Friend WithEvents SendUser As U_TextBox.U_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ValueApp As U_TextBox.U_NumericEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents AppSendMail As U_TextBox.U_CheckBox
    Friend WithEvents AppMail As U_TextBox.U_TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TableName As U_TextBox.U_TextBox
    Friend WithEvents ItemName As U_TextBox.U_TextBox
End Class
