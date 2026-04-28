<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChangeTDH
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.U_NumericEdit1 = New U_TextBox.U_NumericEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NgayXuat = New U_TextBox.U_DateEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.U_NumericEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(201, 106)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(100, 33)
        Me.U_ButtonCus1.TabIndex = 473
        Me.U_ButtonCus1.Text = "Thực hiện"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 19)
        Me.Label2.TabIndex = 475
        Me.Label2.Text = "Giá trị TĐH cần thay đổi"
        '
        'U_NumericEdit1
        '
        Me.U_NumericEdit1.AllowInsert = True
        Me.U_NumericEdit1.AllowUpdate = True
        Me.U_NumericEdit1.AutoKeyFix = ""
        Me.U_NumericEdit1.AutoKeyName = ""
        Me.U_NumericEdit1.BindingSourceName = ""
        Me.U_NumericEdit1.ChangeFormStatus = True
        Me.U_NumericEdit1.CopyFromItem = ""
        Me.U_NumericEdit1.DefaultValue = ""
        Me.U_NumericEdit1.Digit = True
        Me.U_NumericEdit1.FieldName = ""
        Me.U_NumericEdit1.FieldType = "N"
        Me.U_NumericEdit1.KeyInsert = ""
        Me.U_NumericEdit1.LinkLabel = ""
        Me.U_NumericEdit1.LocalDecimal = False
        Me.U_NumericEdit1.Location = New System.Drawing.Point(201, 53)
        Me.U_NumericEdit1.Name = "U_NumericEdit1"
        Me.U_NumericEdit1.NoUpdate = ""
        Me.U_NumericEdit1.NumberDecimal = 0
        Me.U_NumericEdit1.PrimaryKey = ""
        Me.U_NumericEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_NumericEdit1.Properties.Appearance.Options.UseFont = True
        Me.U_NumericEdit1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_NumericEdit1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.U_NumericEdit1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_NumericEdit1.Properties.AppearanceFocused.Options.UseFont = True
        Me.U_NumericEdit1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.U_NumericEdit1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.U_NumericEdit1.Properties.AutoHeight = False
        Me.U_NumericEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.U_NumericEdit1.Properties.Precision = 0
        Me.U_NumericEdit1.Required = "Y"
        Me.U_NumericEdit1.ShowCalc = False
        Me.U_NumericEdit1.Size = New System.Drawing.Size(71, 30)
        Me.U_NumericEdit1.TabIndex = 476
        Me.U_NumericEdit1.TableName = ""
        Me.U_NumericEdit1.UpdateIfNull = ""
        Me.U_NumericEdit1.UpdateWhenFormLock = False
        Me.U_NumericEdit1.ViewName = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 19)
        Me.Label1.TabIndex = 478
        Me.Label1.Text = "Ngày xuất"
        '
        'NgayXuat
        '
        Me.NgayXuat.AllowInsert = False
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
        Me.NgayXuat.Location = New System.Drawing.Point(135, 21)
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
        Me.NgayXuat.Properties.ReadOnly = True
        Me.NgayXuat.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayXuat.Required = "Y"
        Me.NgayXuat.ShowDateTime = False
        Me.NgayXuat.Size = New System.Drawing.Size(137, 26)
        Me.NgayXuat.TabIndex = 477
        Me.NgayXuat.TableName = ""
        Me.NgayXuat.UpdateIfNull = ""
        Me.NgayXuat.UpdateWhenFormLock = False
        Me.NgayXuat.ViewName = ""
        '
        'FrmChangeTDH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(313, 168)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NgayXuat)
        Me.Controls.Add(Me.U_NumericEdit1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmChangeTDH"
        Me.Text = "Cấu hình thay đổi giá trị mã TĐH"
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.U_NumericEdit1, 0)
        Me.Controls.SetChildIndex(Me.NgayXuat, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.U_NumericEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayXuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents U_NumericEdit1 As U_TextBox.U_NumericEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NgayXuat As U_TextBox.U_DateEdit
End Class
