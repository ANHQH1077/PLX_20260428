<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVehicleCerAdd
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
        Me.SoTichKe = New U_TextBox.U_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NgayXuat = New U_TextBox.U_DateEdit()
        Me.U_ButtonCus2 = New U_TextBox.U_ButtonCus(Me.components)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoTichKe.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 19)
        Me.Label1.TabIndex = 424
        Me.Label1.Text = "Số tích kê"
        '
        'SoTichKe
        '
        Me.SoTichKe.AllowInsert = True
        Me.SoTichKe.AllowUpdate = True
        Me.SoTichKe.AutoKeyFix = ""
        Me.SoTichKe.AutoKeyName = ""
        Me.SoTichKe.BindingSourceName = ""
        Me.SoTichKe.ChangeFormStatus = True
        Me.SoTichKe.CopyFromItem = ""
        Me.SoTichKe.DefaultValue = ""
        Me.SoTichKe.FieldName = ""
        Me.SoTichKe.FieldType = "C"
        Me.SoTichKe.KeyInsert = "Y"
        Me.SoTichKe.LinkLabel = ""
        Me.SoTichKe.Location = New System.Drawing.Point(111, 49)
        Me.SoTichKe.Name = "SoTichKe"
        Me.SoTichKe.NoUpdate = "N"
        Me.SoTichKe.PrimaryKey = "Y"
        Me.SoTichKe.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoTichKe.Properties.Appearance.Options.UseFont = True
        Me.SoTichKe.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoTichKe.Properties.AppearanceDisabled.Options.UseFont = True
        Me.SoTichKe.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoTichKe.Properties.AppearanceFocused.Options.UseFont = True
        Me.SoTichKe.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.SoTichKe.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.SoTichKe.Properties.AutoHeight = False
        Me.SoTichKe.Required = "Y"
        Me.SoTichKe.Size = New System.Drawing.Size(118, 26)
        Me.SoTichKe.TabIndex = 0
        Me.SoTichKe.TableName = ""
        Me.SoTichKe.UpdateIfNull = "Y"
        Me.SoTichKe.UpdateWhenFormLock = False
        Me.SoTichKe.UpperValue = False
        Me.SoTichKe.ViewName = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 19)
        Me.Label2.TabIndex = 426
        Me.Label2.Text = "Ngày xuất"
        '
        'NgayXuat
        '
        Me.NgayXuat.AllowInsert = True
        Me.NgayXuat.AllowUpdate = True
        Me.NgayXuat.BindingSourceName = ""
        Me.NgayXuat.ChangeFormStatus = True
        Me.NgayXuat.CopyFromItem = ""
        Me.NgayXuat.DefaultValue = ""
        Me.NgayXuat.EditValue = Nothing
        Me.NgayXuat.FieldName = ""
        Me.NgayXuat.FieldType = "D"
        Me.NgayXuat.KeyInsert = ""
        Me.NgayXuat.LinkLabel = ""
        Me.NgayXuat.Location = New System.Drawing.Point(111, 12)
        Me.NgayXuat.Name = "NgayXuat"
        Me.NgayXuat.NoUpdate = ""
        Me.NgayXuat.PrimaryKey = ""
        Me.NgayXuat.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.Appearance.Options.UseFont = True
        Me.NgayXuat.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.AppearanceDisabled.Options.UseFont = True
        Me.NgayXuat.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.AppearanceFocused.Options.UseFont = True
        Me.NgayXuat.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.NgayXuat.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.NgayXuat.Properties.AutoHeight = False
        Me.NgayXuat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayXuat.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayXuat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayXuat.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayXuat.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayXuat.Required = "Y"
        Me.NgayXuat.ShowDateTime = False
        Me.NgayXuat.Size = New System.Drawing.Size(118, 26)
        Me.NgayXuat.TabIndex = 425
        Me.NgayXuat.TableName = ""
        Me.NgayXuat.TabStop = False
        Me.NgayXuat.UpdateIfNull = "Y"
        Me.NgayXuat.UpdateWhenFormLock = False
        Me.NgayXuat.ViewName = ""
        '
        'U_ButtonCus2
        '
        Me.U_ButtonCus2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus2.Appearance.Options.UseFont = True
        Me.U_ButtonCus2.DefaultUpdate = True
        Me.U_ButtonCus2.EnableWhenFormLock = False
        Me.U_ButtonCus2.Location = New System.Drawing.Point(12, 92)
        Me.U_ButtonCus2.Name = "U_ButtonCus2"
        Me.U_ButtonCus2.Size = New System.Drawing.Size(184, 36)
        Me.U_ButtonCus2.TabIndex = 1
        Me.U_ButtonCus2.Text = "In chứng chỉ"
        '
        'FrmVehicleCerAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 157)
        Me.Controls.Add(Me.U_ButtonCus2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NgayXuat)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SoTichKe)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmVehicleCerAdd"
        Me.Text = "Chứng chỉ phương tiện"
        Me.Controls.SetChildIndex(Me.SoTichKe, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.NgayXuat, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoTichKe.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SoTichKe As U_TextBox.U_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NgayXuat As U_TextBox.U_DateEdit
    Friend WithEvents U_ButtonCus2 As U_TextBox.U_ButtonCus
End Class
