<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrCardAdd
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CardSerial = New U_TextBox.U_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FromDate = New U_TextBox.U_DateEdit()
        Me.CardData = New U_TextBox.U_TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToDate = New U_TextBox.U_DateEdit()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardSerial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FromDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CardData.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(18, 108)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 19)
        Me.Label11.TabIndex = 500
        Me.Label11.Text = "Card Serial"
        '
        'CardSerial
        '
        Me.CardSerial.AllowInsert = False
        Me.CardSerial.AllowUpdate = False
        Me.CardSerial.AutoKeyFix = ""
        Me.CardSerial.AutoKeyName = ""
        Me.CardSerial.BindingSourceName = ""
        Me.CardSerial.ChangeFormStatus = True
        Me.CardSerial.CopyFromItem = ""
        Me.CardSerial.DefaultValue = ""
        Me.CardSerial.FieldName = ""
        Me.CardSerial.FieldType = "C"
        Me.CardSerial.KeyInsert = "Y"
        Me.CardSerial.LinkLabel = ""
        Me.CardSerial.Location = New System.Drawing.Point(105, 104)
        Me.CardSerial.Name = "CardSerial"
        Me.CardSerial.NoUpdate = "N"
        Me.CardSerial.PrimaryKey = "N"
        Me.CardSerial.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardSerial.Properties.Appearance.Options.UseFont = True
        Me.CardSerial.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardSerial.Properties.AppearanceDisabled.Options.UseFont = True
        Me.CardSerial.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardSerial.Properties.AppearanceFocused.Options.UseFont = True
        Me.CardSerial.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardSerial.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.CardSerial.Properties.AutoHeight = False
        Me.CardSerial.Properties.MaxLength = 10
        Me.CardSerial.Required = "N"
        Me.CardSerial.Size = New System.Drawing.Size(122, 26)
        Me.CardSerial.TabIndex = 1
        Me.CardSerial.TableName = ""
        Me.CardSerial.TabStop = False
        Me.CardSerial.UpdateIfNull = "N"
        Me.CardSerial.UpdateWhenFormLock = False
        Me.CardSerial.UpperValue = False
        Me.CardSerial.ViewName = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 19)
        Me.Label2.TabIndex = 499
        Me.Label2.Text = "Hiệu lực"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 19)
        Me.Label1.TabIndex = 498
        Me.Label1.Text = "Card Data"
        '
        'FromDate
        '
        Me.FromDate.AllowInsert = False
        Me.FromDate.AllowUpdate = True
        Me.FromDate.BindingSourceName = ""
        Me.FromDate.ChangeFormStatus = True
        Me.FromDate.CopyFromItem = ""
        Me.FromDate.DefaultValue = ""
        Me.FromDate.EditValue = Nothing
        Me.FromDate.FieldName = ""
        Me.FromDate.FieldType = "D"
        Me.FromDate.KeyInsert = ""
        Me.FromDate.LinkLabel = ""
        Me.FromDate.Location = New System.Drawing.Point(105, 8)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.NoUpdate = ""
        Me.FromDate.PrimaryKey = ""
        Me.FromDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.FromDate.Properties.Appearance.Options.UseFont = True
        Me.FromDate.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.FromDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.FromDate.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.FromDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.FromDate.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.FromDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.FromDate.Properties.AutoHeight = False
        Me.FromDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.FromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FromDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.FromDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.FromDate.Required = "Y"
        Me.FromDate.ShowDateTime = False
        Me.FromDate.Size = New System.Drawing.Size(122, 26)
        Me.FromDate.TabIndex = 496
        Me.FromDate.TableName = "tblLenhXuatE5"
        Me.FromDate.TabStop = False
        Me.FromDate.UpdateIfNull = ""
        Me.FromDate.UpdateWhenFormLock = False
        Me.FromDate.ViewName = ""
        '
        'CardData
        '
        Me.CardData.AllowInsert = False
        Me.CardData.AllowUpdate = False
        Me.CardData.AutoKeyFix = ""
        Me.CardData.AutoKeyName = ""
        Me.CardData.BindingSourceName = ""
        Me.CardData.ChangeFormStatus = False
        Me.CardData.CopyFromItem = ""
        Me.CardData.DefaultValue = ""
        Me.CardData.FieldName = ""
        Me.CardData.FieldType = "C"
        Me.CardData.KeyInsert = "Y"
        Me.CardData.LinkLabel = ""
        Me.CardData.Location = New System.Drawing.Point(105, 77)
        Me.CardData.Name = "CardData"
        Me.CardData.NoUpdate = "N"
        Me.CardData.PrimaryKey = "Y"
        Me.CardData.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardData.Properties.Appearance.Options.UseFont = True
        Me.CardData.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardData.Properties.AppearanceDisabled.Options.UseFont = True
        Me.CardData.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardData.Properties.AppearanceFocused.Options.UseFont = True
        Me.CardData.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CardData.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.CardData.Properties.AutoHeight = False
        Me.CardData.Properties.MaxLength = 10
        Me.CardData.Required = "Y"
        Me.CardData.Size = New System.Drawing.Size(122, 26)
        Me.CardData.TabIndex = 0
        Me.CardData.TableName = ""
        Me.CardData.UpdateIfNull = "N"
        Me.CardData.UpdateWhenFormLock = True
        Me.CardData.UpperValue = False
        Me.CardData.ViewName = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 19)
        Me.Label3.TabIndex = 502
        Me.Label3.Text = "Hết hiệu lực"
        '
        'ToDate
        '
        Me.ToDate.AllowInsert = False
        Me.ToDate.AllowUpdate = True
        Me.ToDate.BindingSourceName = ""
        Me.ToDate.ChangeFormStatus = True
        Me.ToDate.CopyFromItem = ""
        Me.ToDate.DefaultValue = ""
        Me.ToDate.EditValue = Nothing
        Me.ToDate.FieldName = ""
        Me.ToDate.FieldType = "D"
        Me.ToDate.KeyInsert = ""
        Me.ToDate.LinkLabel = ""
        Me.ToDate.Location = New System.Drawing.Point(105, 36)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.NoUpdate = ""
        Me.ToDate.PrimaryKey = ""
        Me.ToDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToDate.Properties.Appearance.Options.UseFont = True
        Me.ToDate.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ToDate.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.ToDate.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.ToDate.Properties.AutoHeight = False
        Me.ToDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.ToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ToDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.ToDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ToDate.Required = "Y"
        Me.ToDate.ShowDateTime = False
        Me.ToDate.Size = New System.Drawing.Size(122, 26)
        Me.ToDate.TabIndex = 501
        Me.ToDate.TableName = "tblLenhXuatE5"
        Me.ToDate.TabStop = False
        Me.ToDate.UpdateIfNull = ""
        Me.ToDate.UpdateWhenFormLock = False
        Me.ToDate.ViewName = ""
        '
        'FrCardAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(257, 146)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.CardSerial)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.CardData)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrCardAdd"
        Me.Text = "Bổ sung thẻ"
        Me.Controls.SetChildIndex(Me.CardData, 0)
        Me.Controls.SetChildIndex(Me.FromDate, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.CardSerial, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.ToDate, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardSerial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FromDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CardData.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CardSerial As U_TextBox.U_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FromDate As U_TextBox.U_DateEdit
    Friend WithEvents CardData As U_TextBox.U_TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToDate As U_TextBox.U_DateEdit
End Class
