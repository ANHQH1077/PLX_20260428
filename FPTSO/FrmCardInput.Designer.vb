<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCardInput
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CardNum = New U_TextBox.U_TextBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardNum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 19)
        Me.Label1.TabIndex = 424
        Me.Label1.Text = "Số thẻ"
        '
        'CardNum
        '
        Me.CardNum.AllowInsert = False
        Me.CardNum.AllowUpdate = False
        Me.CardNum.AutoKeyFix = ""
        Me.CardNum.AutoKeyName = ""
        Me.CardNum.BindingSourceName = ""
        Me.CardNum.ChangeFormStatus = False
        Me.CardNum.CopyFromItem = ""
        Me.CardNum.DefaultValue = ""
        Me.CardNum.FieldName = ""
        Me.CardNum.FieldType = "C"
        Me.CardNum.KeyInsert = "Y"
        Me.CardNum.LinkLabel = ""
        Me.CardNum.Location = New System.Drawing.Point(70, 15)
        Me.CardNum.Name = "CardNum"
        Me.CardNum.NoUpdate = "N"
        Me.CardNum.PrimaryKey = ""
        Me.CardNum.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardNum.Properties.Appearance.Options.UseFont = True
        Me.CardNum.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardNum.Properties.AppearanceDisabled.Options.UseFont = True
        Me.CardNum.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardNum.Properties.AppearanceFocused.Options.UseFont = True
        Me.CardNum.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardNum.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.CardNum.Properties.AutoHeight = False
        Me.CardNum.Properties.MaxLength = 10
        Me.CardNum.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.CardNum.Required = ""
        Me.CardNum.Size = New System.Drawing.Size(133, 26)
        Me.CardNum.TabIndex = 0
        Me.CardNum.TableName = ""
        Me.CardNum.UpdateIfNull = "N"
        Me.CardNum.UpdateWhenFormLock = True
        Me.CardNum.UpperValue = False
        Me.CardNum.ViewName = ""
        '
        'FrmCardInput
        '
        Me.Appearance.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(213, 57)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CardNum)
        Me.LookAndFeel.SkinName = "Black"
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCardInput"
        Me.Text = "Số thẻ"
        Me.Controls.SetChildIndex(Me.CardNum, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardNum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CardNum As U_TextBox.U_TextBox
End Class
