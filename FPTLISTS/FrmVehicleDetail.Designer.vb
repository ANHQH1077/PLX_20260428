<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVehicleDetail
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
        Me.U_TextBox1 = New U_TextBox.U_TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_TextBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'U_TextBox1
        '
        Me.U_TextBox1.AllowInsert = False
        Me.U_TextBox1.AllowUpdate = False
        Me.U_TextBox1.AutoKeyFix = ""
        Me.U_TextBox1.AutoKeyName = ""
        Me.U_TextBox1.BindingSourceName = ""
        Me.U_TextBox1.ChangeFormStatus = False
        Me.U_TextBox1.CopyFromItem = ""
        Me.U_TextBox1.DefaultValue = ""
        Me.U_TextBox1.FieldName = ""
        Me.U_TextBox1.FieldType = "C"
        Me.U_TextBox1.KeyInsert = ""
        Me.U_TextBox1.LinkLabel = ""
        Me.U_TextBox1.Location = New System.Drawing.Point(151, 32)
        Me.U_TextBox1.Name = "U_TextBox1"
        Me.U_TextBox1.NoUpdate = "N"
        Me.U_TextBox1.PrimaryKey = ""
        Me.U_TextBox1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_TextBox1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_TextBox1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_TextBox1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_TextBox1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_TextBox1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_TextBox1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_TextBox1.Properties.AutoHeight = False
        Me.U_TextBox1.Required = ""
        Me.U_TextBox1.Size = New System.Drawing.Size(160, 30)
        Me.U_TextBox1.TabIndex = 2
        Me.U_TextBox1.TableName = ""
        Me.U_TextBox1.UpdateIfNull = ""
        Me.U_TextBox1.UpdateWhenFormLock = False
        Me.U_TextBox1.UpperValue = False
        Me.U_TextBox1.ViewName = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 19)
        Me.Label1.TabIndex = 423
        Me.Label1.Text = "Số phương tiện"
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(192, 79)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(119, 29)
        Me.U_ButtonCus1.TabIndex = 424
        Me.U_ButtonCus1.Text = "Thực hiện"
        '
        'FrmVehicleDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(325, 124)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.U_TextBox1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmVehicleDetail"
        Me.Text = "Đồng bộ chi tiết Phương tiện"
        Me.Controls.SetChildIndex(Me.U_TextBox1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_TextBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents U_TextBox1 As U_TextBox.U_TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
End Class
