<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNoiDungHuy
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
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.U_MemmoEdit1 = New U_TextBox.U_MemmoEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_MemmoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(314, 102)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(102, 33)
        Me.U_ButtonCus1.TabIndex = 431
        Me.U_ButtonCus1.Text = "Thực hiện"
        '
        'U_MemmoEdit1
        '
        Me.U_MemmoEdit1.AllowInsert = True
        Me.U_MemmoEdit1.AllowUpdate = True
        Me.U_MemmoEdit1.AutoKeyFix = ""
        Me.U_MemmoEdit1.AutoKeyName = ""
        Me.U_MemmoEdit1.BindingSourceName = ""
        Me.U_MemmoEdit1.ChangeFormStatus = True
        Me.U_MemmoEdit1.CopyFromItem = ""
        Me.U_MemmoEdit1.DefaultValue = ""
        Me.U_MemmoEdit1.FieldName = ""
        Me.U_MemmoEdit1.FieldType = ""
        Me.U_MemmoEdit1.KeyInsert = ""
        Me.U_MemmoEdit1.LinkLabel = ""
        Me.U_MemmoEdit1.Location = New System.Drawing.Point(0, 3)
        Me.U_MemmoEdit1.Name = "U_MemmoEdit1"
        Me.U_MemmoEdit1.NoUpdate = "N"
        Me.U_MemmoEdit1.PrimaryKey = ""
        Me.U_MemmoEdit1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info
        Me.U_MemmoEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_MemmoEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.U_MemmoEdit1.Properties.Appearance.Options.UseFont = True
        Me.U_MemmoEdit1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_MemmoEdit1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_MemmoEdit1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_MemmoEdit1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_MemmoEdit1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_MemmoEdit1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_MemmoEdit1.Required = ""
        Me.U_MemmoEdit1.Size = New System.Drawing.Size(418, 97)
        Me.U_MemmoEdit1.TabIndex = 432
        Me.U_MemmoEdit1.TableName = ""
        Me.U_MemmoEdit1.UpdateIfNull = ""
        Me.U_MemmoEdit1.UpdateWhenFormLock = False
        Me.U_MemmoEdit1.ViewName = ""
        '
        'FrmNoiDungHuy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 135)
        Me.Controls.Add(Me.U_MemmoEdit1)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmNoiDungHuy"
        Me.Text = "Nội dung hủy hóa đơn"
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.U_MemmoEdit1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_MemmoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents U_MemmoEdit1 As U_TextBox.U_MemmoEdit
    'Friend WithEvents MemoEdit1 As DevExpress.XtraEditors.MemoEdit
    'Friend WithEvents txtMemoEdit1 As DevExpress.XtraEditors.MemoEdit
End Class
