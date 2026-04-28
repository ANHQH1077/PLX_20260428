<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTime
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
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTime))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TimeDefault = New U_TextBox.U_DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FromTime = New U_TextBox.U_DateEdit()
        Me.ToTime = New U_TextBox.U_DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeDefault.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TimeDefault.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromTime.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToTime.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(31, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 425
        Me.Label2.Text = "Giờ cố định"
        '
        'TimeDefault
        '
        Me.TimeDefault.AllowInsert = False
        Me.TimeDefault.AllowUpdate = True
        Me.TimeDefault.BindingSourceName = ""
        Me.TimeDefault.ChangeFormStatus = True
        Me.TimeDefault.CopyFromItem = ""
        Me.TimeDefault.DefaultValue = ""
        Me.TimeDefault.EditValue = Nothing
        Me.TimeDefault.FieldName = ""
        Me.TimeDefault.FieldType = "D"
        Me.TimeDefault.KeyInsert = ""
        Me.TimeDefault.LinkLabel = ""
        Me.TimeDefault.Location = New System.Drawing.Point(124, 47)
        Me.TimeDefault.Name = "TimeDefault"
        Me.TimeDefault.NoUpdate = ""
        Me.TimeDefault.PrimaryKey = ""
        Me.TimeDefault.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.TimeDefault.Properties.Appearance.Options.UseFont = True
        Me.TimeDefault.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TimeDefault.Properties.AppearanceDisabled.Options.UseFont = True
        Me.TimeDefault.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TimeDefault.Properties.AppearanceFocused.Options.UseFont = True
        Me.TimeDefault.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TimeDefault.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.TimeDefault.Properties.AutoHeight = False
        Me.TimeDefault.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, True, False, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, True)})
        Me.TimeDefault.Properties.DisplayFormat.FormatString = "HH:mm:ss"
        Me.TimeDefault.Properties.EditFormat.FormatString = "HH:mm:ss"
        Me.TimeDefault.Properties.Mask.EditMask = "HH:mm:ss"
        Me.TimeDefault.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TimeDefault.Required = "Y"
        Me.TimeDefault.ShowDateTime = False
        Me.TimeDefault.Size = New System.Drawing.Size(131, 26)
        Me.TimeDefault.TabIndex = 0
        Me.TimeDefault.TableName = ""
        Me.TimeDefault.UpdateIfNull = ""
        Me.TimeDefault.UpdateWhenFormLock = False
        Me.TimeDefault.ViewName = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(18, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 17)
        Me.Label1.TabIndex = 427
        Me.Label1.Text = "Thời gian điều chỉnh"
        '
        'FromTime
        '
        Me.FromTime.AllowInsert = False
        Me.FromTime.AllowUpdate = True
        Me.FromTime.BindingSourceName = ""
        Me.FromTime.ChangeFormStatus = True
        Me.FromTime.CopyFromItem = ""
        Me.FromTime.DefaultValue = ""
        Me.FromTime.EditValue = Nothing
        Me.FromTime.FieldName = ""
        Me.FromTime.FieldType = "D"
        Me.FromTime.KeyInsert = ""
        Me.FromTime.LinkLabel = ""
        Me.FromTime.Location = New System.Drawing.Point(124, 126)
        Me.FromTime.Name = "FromTime"
        Me.FromTime.NoUpdate = ""
        Me.FromTime.PrimaryKey = ""
        Me.FromTime.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.FromTime.Properties.Appearance.Options.UseFont = True
        Me.FromTime.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.FromTime.Properties.AppearanceDisabled.Options.UseFont = True
        Me.FromTime.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.FromTime.Properties.AppearanceFocused.Options.UseFont = True
        Me.FromTime.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.FromTime.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.FromTime.Properties.AutoHeight = False
        Me.FromTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FromTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.FromTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FromTime.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.FromTime.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss"
        Me.FromTime.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.FromTime.Properties.VistaTimeProperties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.FromTime.Properties.VistaTimeProperties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.FromTime.Required = "Y"
        Me.FromTime.ShowDateTime = False
        Me.FromTime.Size = New System.Drawing.Size(210, 26)
        Me.FromTime.TabIndex = 1
        Me.FromTime.TableName = ""
        Me.FromTime.UpdateIfNull = ""
        Me.FromTime.UpdateWhenFormLock = False
        Me.FromTime.ViewName = ""
        '
        'ToTime
        '
        Me.ToTime.AllowInsert = False
        Me.ToTime.AllowUpdate = True
        Me.ToTime.BindingSourceName = ""
        Me.ToTime.ChangeFormStatus = True
        Me.ToTime.CopyFromItem = ""
        Me.ToTime.DefaultValue = ""
        Me.ToTime.EditValue = Nothing
        Me.ToTime.FieldName = ""
        Me.ToTime.FieldType = "D"
        Me.ToTime.KeyInsert = ""
        Me.ToTime.LinkLabel = ""
        Me.ToTime.Location = New System.Drawing.Point(124, 158)
        Me.ToTime.Name = "ToTime"
        Me.ToTime.NoUpdate = ""
        Me.ToTime.PrimaryKey = ""
        Me.ToTime.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.ToTime.Properties.Appearance.Options.UseFont = True
        Me.ToTime.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToTime.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ToTime.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToTime.Properties.AppearanceFocused.Options.UseFont = True
        Me.ToTime.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToTime.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.ToTime.Properties.AutoHeight = False
        Me.ToTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ToTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.ToTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ToTime.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        Me.ToTime.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm:ss"
        Me.ToTime.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ToTime.Required = "Y"
        Me.ToTime.ShowDateTime = False
        Me.ToTime.Size = New System.Drawing.Size(210, 26)
        Me.ToTime.TabIndex = 2
        Me.ToTime.TableName = ""
        Me.ToTime.UpdateIfNull = ""
        Me.ToTime.UpdateWhenFormLock = False
        Me.ToTime.ViewName = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(42, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 428
        Me.Label3.Text = "Hiệu lực"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(42, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 17)
        Me.Label4.TabIndex = 429
        Me.Label4.Text = "Hết hiệu lực"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(355, 28)
        Me.ToolStrip2.TabIndex = 473
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
        'FrmTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 209)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ToTime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FromTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TimeDefault)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmTime"
        Me.Text = "Thời gian in tích kê"
        Me.Controls.SetChildIndex(Me.TimeDefault, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.FromTime, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.ToTime, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeDefault.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TimeDefault.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromTime.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToTime.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TimeDefault As U_TextBox.U_DateEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FromTime As U_TextBox.U_DateEdit
    Friend WithEvents ToTime As U_TextBox.U_DateEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
