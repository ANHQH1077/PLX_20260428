<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CreateDate = New U_TextBox.U_DateEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreateDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreateDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.Location = New System.Drawing.Point(128, 59)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(99, 23)
        Me.U_ButtonCus1.TabIndex = 493
        Me.U_ButtonCus1.Text = "Thực hiện"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 19)
        Me.Label2.TabIndex = 492
        Me.Label2.Text = "Ngày tháng"
        '
        'CreateDate
        '
        Me.CreateDate.AllowInsert = True
        Me.CreateDate.AllowUpdate = True
        Me.CreateDate.BindingSourceName = ""
        Me.CreateDate.ChangeFormStatus = True
        Me.CreateDate.CopyFromItem = ""
        Me.CreateDate.DefaultValue = ""
        Me.CreateDate.EditValue = Nothing
        Me.CreateDate.FieldName = ""
        Me.CreateDate.FieldType = "D"
        Me.CreateDate.KeyInsert = ""
        Me.CreateDate.LinkLabel = "Label2"
        Me.CreateDate.Location = New System.Drawing.Point(103, 18)
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.NoUpdate = ""
        Me.CreateDate.PrimaryKey = ""
        Me.CreateDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CreateDate.Properties.Appearance.Options.UseFont = True
        Me.CreateDate.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CreateDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.CreateDate.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CreateDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.CreateDate.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CreateDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.CreateDate.Properties.AutoHeight = False
        Me.CreateDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CreateDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.CreateDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CreateDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.CreateDate.Properties.ReadOnly = True
        Me.CreateDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.CreateDate.Required = "Y"
        Me.CreateDate.ShowDateTime = False
        Me.CreateDate.Size = New System.Drawing.Size(124, 26)
        Me.CreateDate.TabIndex = 491
        Me.CreateDate.TableName = ""
        Me.CreateDate.TabStop = False
        Me.CreateDate.UpdateIfNull = ""
        Me.CreateDate.UpdateWhenFormLock = False
        Me.CreateDate.ViewName = "ztblTankHeaderImp_v"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(242, 116)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CreateDate)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form2"
        Me.Controls.SetChildIndex(Me.CreateDate, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreateDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreateDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CreateDate As U_TextBox.U_DateEdit
End Class
