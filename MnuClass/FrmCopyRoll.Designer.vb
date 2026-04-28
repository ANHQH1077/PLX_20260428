<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCopyRoll
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
        Me.USER_NAME = New U_TextBox.U_ButtonEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CmdThucHien = New U_TextBox.U_ButtonCus(Me.components)
        Me.UserCopy = New U_TextBox.U_TextBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USER_NAME.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserCopy.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'USER_NAME
        '
        Me.USER_NAME.AllowInsert = True
        Me.USER_NAME.AllowUpdate = True
        Me.USER_NAME.BindingSourceName = ""
        Me.USER_NAME.ChangeFormStatus = False
        Me.USER_NAME.CopyFromItem = ""
        Me.USER_NAME.DefaultButtonClick = True
        Me.USER_NAME.DefaultValue = ""
        Me.USER_NAME.FieldName = ""
        Me.USER_NAME.FieldType = ""
        Me.USER_NAME.FormList = True
        Me.USER_NAME.ItemReturn1 = ""
        Me.USER_NAME.ItemReturn2 = ""
        Me.USER_NAME.ItemReturn3 = ""
        Me.USER_NAME.KeyInsert = ""
        Me.USER_NAME.LinkLabel = ""
        Me.USER_NAME.Location = New System.Drawing.Point(82, 12)
        Me.USER_NAME.MultiSelect = False
        Me.USER_NAME.Name = "USER_NAME"
        Me.USER_NAME.NoUpdate = "N"
        Me.USER_NAME.PrimaryKey = ""
        Me.USER_NAME.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.USER_NAME.Properties.Appearance.Options.UseFont = True
        Me.USER_NAME.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.USER_NAME.Properties.AppearanceDisabled.Options.UseFont = True
        Me.USER_NAME.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.USER_NAME.Properties.AppearanceFocused.Options.UseFont = True
        Me.USER_NAME.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.USER_NAME.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.USER_NAME.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.USER_NAME.Required = "Y"
        Me.USER_NAME.ShowLoad = True
        Me.USER_NAME.Size = New System.Drawing.Size(149, 26)
        Me.USER_NAME.SqlFielKey = "USER_NAME"
        Me.USER_NAME.SqlString = "select USER_NAME from SYS_USER Where upper(USER_NAME) <>upper( :UserCopy )"
        Me.USER_NAME.TabIndex = 1
        Me.USER_NAME.TableName = ""
        Me.USER_NAME.UpdateIfNull = ""
        Me.USER_NAME.UpdateWhenFormLock = False
        Me.USER_NAME.UpperValue = False
        Me.USER_NAME.ValidateValue = True
        Me.USER_NAME.ViewName = ""
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(64, 19)
        Me.LabelControl1.TabIndex = 140
        Me.LabelControl1.Text = "Tên User"
        '
        'CmdThucHien
        '
        Me.CmdThucHien.DefaultUpdate = True
        Me.CmdThucHien.Location = New System.Drawing.Point(136, 55)
        Me.CmdThucHien.Name = "CmdThucHien"
        Me.CmdThucHien.Size = New System.Drawing.Size(95, 23)
        Me.CmdThucHien.TabIndex = 141
        Me.CmdThucHien.Text = "Thực &hiện"
        '
        'UserCopy
        '
        Me.UserCopy.AllowInsert = True
        Me.UserCopy.AllowUpdate = True
        Me.UserCopy.AutoKeyFix = ""
        Me.UserCopy.AutoKeyName = ""
        Me.UserCopy.BindingSourceName = ""
        Me.UserCopy.ChangeFormStatus = False
        Me.UserCopy.CopyFromItem = ""
        Me.UserCopy.DefaultValue = ""
        Me.UserCopy.FieldName = ""
        Me.UserCopy.FieldType = "C"
        Me.UserCopy.KeyInsert = ""
        Me.UserCopy.LinkLabel = ""
        Me.UserCopy.Location = New System.Drawing.Point(17, 45)
        Me.UserCopy.Name = "UserCopy"
        Me.UserCopy.NoUpdate = "N"
        Me.UserCopy.PrimaryKey = ""
        Me.UserCopy.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.UserCopy.Properties.Appearance.Options.UseFont = True
        Me.UserCopy.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.UserCopy.Properties.AppearanceDisabled.Options.UseFont = True
        Me.UserCopy.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.UserCopy.Properties.AppearanceFocused.Options.UseFont = True
        Me.UserCopy.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.UserCopy.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.UserCopy.Properties.AutoHeight = False
        Me.UserCopy.Required = ""
        Me.UserCopy.Size = New System.Drawing.Size(0, 30)
        Me.UserCopy.TabIndex = 142
        Me.UserCopy.TableName = ""
        Me.UserCopy.TabStop = False
        Me.UserCopy.UpdateIfNull = ""
        Me.UserCopy.UpdateWhenFormLock = False
        Me.UserCopy.UpperValue = False
        Me.UserCopy.ViewName = ""
        '
        'FrmCopyRoll
        '
        Me.AcceptButton = Me.CmdThucHien
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(249, 85)
        Me.Controls.Add(Me.UserCopy)
        Me.Controls.Add(Me.CmdThucHien)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.USER_NAME)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCopyRoll"
        Me.Text = "User"
        Me.Controls.SetChildIndex(Me.USER_NAME, 0)
        Me.Controls.SetChildIndex(Me.LabelControl1, 0)
        Me.Controls.SetChildIndex(Me.CmdThucHien, 0)
        Me.Controls.SetChildIndex(Me.UserCopy, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USER_NAME.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserCopy.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents USER_NAME As U_TextBox.U_ButtonEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CmdThucHien As U_TextBox.U_ButtonCus
    Friend WithEvents UserCopy As U_TextBox.U_TextBox
End Class
