<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChangPass
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChangPass))
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.RePassWord = New U_TextBox.U_TextBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PassWord = New U_TextBox.U_TextBox()
        Me.USER_NAME = New U_TextBox.U_TextBox()
        Me.ENCRYPTED_USER_PASSWORD = New U_TextBox.U_TextBox()
        Me.USER_ID = New U_TextBox.U_TextBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RePassWord.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PassWord.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USER_NAME.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ENCRYPTED_USER_PASSWORD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USER_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(24, 100)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl6.TabIndex = 151
        Me.LabelControl6.Text = "Gõ lại mật khẩu"
        '
        'RePassWord
        '
        Me.RePassWord.AllowInsert = True
        Me.RePassWord.AllowUpdate = True
        Me.RePassWord.AutoKeyFix = ""
        Me.RePassWord.AutoKeyName = ""
        Me.RePassWord.BindingSourceName = ""
        Me.RePassWord.ChangeFormStatus = True
        Me.RePassWord.CopyFromItem = ""
        Me.RePassWord.DefaultValue = ""
        Me.RePassWord.FieldName = ""
        Me.RePassWord.FieldType = "C"
        Me.RePassWord.KeyInsert = ""
        Me.RePassWord.LinkLabel = ""
        Me.RePassWord.Location = New System.Drawing.Point(122, 97)
        Me.RePassWord.Name = "RePassWord"
        Me.RePassWord.NoUpdate = "N"
        Me.RePassWord.PrimaryKey = ""
        Me.RePassWord.Properties.AutoHeight = False
        Me.RePassWord.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.RePassWord.Required = ""
        Me.RePassWord.Size = New System.Drawing.Size(148, 26)
        Me.RePassWord.TabIndex = 148
        Me.RePassWord.TableName = ""
        Me.RePassWord.ToolTip = "NAME(U_TextBox) VIEW() TAB() FIELD ()"
        Me.RePassWord.UpdateIfNull = ""
        Me.RePassWord.UpdateWhenFormLock = False
        Me.RePassWord.UpperValue = False
        Me.RePassWord.ViewName = ""
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(24, 71)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl2.TabIndex = 150
        Me.LabelControl2.Text = "Mật khẩu"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(24, 43)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl1.TabIndex = 149
        Me.LabelControl1.Text = "Tên User"
        '
        'PassWord
        '
        Me.PassWord.AllowInsert = True
        Me.PassWord.AllowUpdate = True
        Me.PassWord.AutoKeyFix = ""
        Me.PassWord.AutoKeyName = ""
        Me.PassWord.BindingSourceName = ""
        Me.PassWord.ChangeFormStatus = True
        Me.PassWord.CopyFromItem = ""
        Me.PassWord.DefaultValue = ""
        Me.PassWord.FieldName = ""
        Me.PassWord.FieldType = "C"
        Me.PassWord.KeyInsert = ""
        Me.PassWord.LinkLabel = ""
        Me.PassWord.Location = New System.Drawing.Point(122, 68)
        Me.PassWord.Name = "PassWord"
        Me.PassWord.NoUpdate = "N"
        Me.PassWord.PrimaryKey = ""
        Me.PassWord.Properties.AutoHeight = False
        Me.PassWord.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PassWord.Required = ""
        Me.PassWord.Size = New System.Drawing.Size(148, 26)
        Me.PassWord.TabIndex = 147
        Me.PassWord.TableName = ""
        Me.PassWord.ToolTip = "NAME(U_TextBox) VIEW() TAB() FIELD ()"
        Me.PassWord.UpdateIfNull = ""
        Me.PassWord.UpdateWhenFormLock = False
        Me.PassWord.UpperValue = False
        Me.PassWord.ViewName = ""
        '
        'USER_NAME
        '
        Me.USER_NAME.AllowInsert = True
        Me.USER_NAME.AllowUpdate = True
        Me.USER_NAME.AutoKeyFix = ""
        Me.USER_NAME.AutoKeyName = ""
        Me.USER_NAME.BindingSourceName = ""
        Me.USER_NAME.ChangeFormStatus = True
        Me.USER_NAME.CopyFromItem = ""
        Me.USER_NAME.DefaultValue = ""
        Me.USER_NAME.FieldName = "USER_NAME"
        Me.USER_NAME.FieldType = "C"
        Me.USER_NAME.KeyInsert = "Y"
        Me.USER_NAME.LinkLabel = ""
        Me.USER_NAME.Location = New System.Drawing.Point(122, 40)
        Me.USER_NAME.Name = "USER_NAME"
        Me.USER_NAME.NoUpdate = "Y"
        Me.USER_NAME.PrimaryKey = "Y"
        Me.USER_NAME.Properties.AutoHeight = False
        Me.USER_NAME.Properties.ReadOnly = True
        Me.USER_NAME.Required = "Y"
        Me.USER_NAME.Size = New System.Drawing.Size(148, 26)
        Me.USER_NAME.TabIndex = 146
        Me.USER_NAME.TableName = "SYS_USER"
        Me.USER_NAME.ToolTip = "NAME(U_TextBox) VIEW(SYS_USER) TAB(SYS_USER) FIELD (USER_NAME)"
        Me.USER_NAME.UpdateIfNull = "Y"
        Me.USER_NAME.UpdateWhenFormLock = False
        Me.USER_NAME.UpperValue = False
        Me.USER_NAME.ViewName = "SYS_USER"
        '
        'ENCRYPTED_USER_PASSWORD
        '
        Me.ENCRYPTED_USER_PASSWORD.AllowInsert = True
        Me.ENCRYPTED_USER_PASSWORD.AllowUpdate = True
        Me.ENCRYPTED_USER_PASSWORD.AutoKeyFix = ""
        Me.ENCRYPTED_USER_PASSWORD.AutoKeyName = ""
        Me.ENCRYPTED_USER_PASSWORD.BindingSourceName = ""
        Me.ENCRYPTED_USER_PASSWORD.ChangeFormStatus = True
        Me.ENCRYPTED_USER_PASSWORD.CopyFromItem = ""
        Me.ENCRYPTED_USER_PASSWORD.DefaultValue = ""
        Me.ENCRYPTED_USER_PASSWORD.FieldName = "ENCRYPTED_USER_PASSWORD"
        Me.ENCRYPTED_USER_PASSWORD.FieldType = "C"
        Me.ENCRYPTED_USER_PASSWORD.KeyInsert = ""
        Me.ENCRYPTED_USER_PASSWORD.LinkLabel = ""
        Me.ENCRYPTED_USER_PASSWORD.Location = New System.Drawing.Point(315, 48)
        Me.ENCRYPTED_USER_PASSWORD.Name = "ENCRYPTED_USER_PASSWORD"
        Me.ENCRYPTED_USER_PASSWORD.NoUpdate = "N"
        Me.ENCRYPTED_USER_PASSWORD.PrimaryKey = ""
        Me.ENCRYPTED_USER_PASSWORD.Required = ""
        Me.ENCRYPTED_USER_PASSWORD.Size = New System.Drawing.Size(0, 20)
        Me.ENCRYPTED_USER_PASSWORD.TabIndex = 152
        Me.ENCRYPTED_USER_PASSWORD.TableName = "SYS_USER"
        Me.ENCRYPTED_USER_PASSWORD.TabStop = False
        Me.ENCRYPTED_USER_PASSWORD.ToolTip = "NAME(U_TextBox) VIEW(SYS_USER) TAB(SYS_USER) FIELD (ENCRYPTED_USER_PASSWORD)"
        Me.ENCRYPTED_USER_PASSWORD.UpdateIfNull = ""
        Me.ENCRYPTED_USER_PASSWORD.UpdateWhenFormLock = False
        Me.ENCRYPTED_USER_PASSWORD.UpperValue = False
        Me.ENCRYPTED_USER_PASSWORD.ViewName = "SYS_USER"
        '
        'USER_ID
        '
        Me.USER_ID.AllowInsert = True
        Me.USER_ID.AllowUpdate = False
        Me.USER_ID.AutoKeyFix = ""
        Me.USER_ID.AutoKeyName = "SYS_USER_S"
        Me.USER_ID.BindingSourceName = ""
        Me.USER_ID.ChangeFormStatus = True
        Me.USER_ID.CopyFromItem = ""
        Me.USER_ID.DefaultValue = ""
        Me.USER_ID.FieldName = "USER_ID"
        Me.USER_ID.FieldType = "N"
        Me.USER_ID.KeyInsert = "Y"
        Me.USER_ID.LinkLabel = ""
        Me.USER_ID.Location = New System.Drawing.Point(315, 12)
        Me.USER_ID.Name = "USER_ID"
        Me.USER_ID.NoUpdate = "Y"
        Me.USER_ID.PrimaryKey = "Y"
        Me.USER_ID.Required = ""
        Me.USER_ID.Size = New System.Drawing.Size(0, 20)
        Me.USER_ID.TabIndex = 161
        Me.USER_ID.TableName = "SYS_USER"
        Me.USER_ID.TabStop = False
        Me.USER_ID.ToolTip = "NAME(U_TextBox) VIEW(SYS_USER) TAB(SYS_USER) FIELD (USER_NAME)"
        Me.USER_ID.UpdateIfNull = "Y"
        Me.USER_ID.UpdateWhenFormLock = False
        Me.USER_ID.UpperValue = False
        Me.USER_ID.ViewName = "SYS_USER"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(296, 25)
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
        Me.ToolStripButton1.Text = "&2. Lưu"
        '
        'FrmChangPass
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 152)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.USER_ID)
        Me.Controls.Add(Me.ENCRYPTED_USER_PASSWORD)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.RePassWord)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PassWord)
        Me.Controls.Add(Me.USER_NAME)
        Me.DefaultSave = False
        Me.DefaultWhere = "USER_NAME=:GLOBAL.USERNAME"
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmChangPass"
        Me.ShowFormMessage = True
        Me.Text = "Đổi mật khẩu"
        Me.Controls.SetChildIndex(Me.USER_NAME, 0)
        Me.Controls.SetChildIndex(Me.PassWord, 0)
        Me.Controls.SetChildIndex(Me.LabelControl1, 0)
        Me.Controls.SetChildIndex(Me.LabelControl2, 0)
        Me.Controls.SetChildIndex(Me.RePassWord, 0)
        Me.Controls.SetChildIndex(Me.LabelControl6, 0)
        Me.Controls.SetChildIndex(Me.ENCRYPTED_USER_PASSWORD, 0)
        Me.Controls.SetChildIndex(Me.USER_ID, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RePassWord.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PassWord.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USER_NAME.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ENCRYPTED_USER_PASSWORD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USER_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RePassWord As U_TextBox.U_TextBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PassWord As U_TextBox.U_TextBox
    Friend WithEvents USER_NAME As U_TextBox.U_TextBox
    Friend WithEvents ENCRYPTED_USER_PASSWORD As U_TextBox.U_TextBox
    Friend WithEvents USER_ID As U_TextBox.U_TextBox
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
