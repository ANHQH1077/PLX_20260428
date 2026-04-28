<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQciKg
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
        Me.NhietDo = New U_TextBox.U_NumericEdit()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NhietDo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NhietDo
        '
        Me.NhietDo.AllowInsert = True
        Me.NhietDo.AllowUpdate = True
        Me.NhietDo.AutoKeyFix = ""
        Me.NhietDo.AutoKeyName = ""
        Me.NhietDo.BindingSourceName = ""
        Me.NhietDo.ChangeFormStatus = False
        Me.NhietDo.CopyFromItem = ""
        Me.NhietDo.DefaultValue = ""
        Me.NhietDo.Digit = True
        Me.NhietDo.FieldName = ""
        Me.NhietDo.FieldType = "N"
        Me.NhietDo.KeyInsert = ""
        Me.NhietDo.LinkLabel = ""
        Me.NhietDo.LocalDecimal = True
        Me.NhietDo.Location = New System.Drawing.Point(12, 12)
        Me.NhietDo.Name = "NhietDo"
        Me.NhietDo.NoUpdate = ""
        Me.NhietDo.NumberDecimal = 2
        Me.NhietDo.PrimaryKey = ""
        Me.NhietDo.Properties.AutoHeight = False
        Me.NhietDo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NhietDo.Properties.DisplayFormat.FormatString = "#,###.##"
        Me.NhietDo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.NhietDo.Properties.EditFormat.FormatString = "#,###.##"
        Me.NhietDo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.NhietDo.Properties.Mask.EditMask = "#,###.##"
        Me.NhietDo.Required = ""
        Me.NhietDo.Size = New System.Drawing.Size(82, 31)
        Me.NhietDo.TabIndex = 1
        Me.NhietDo.TableName = ""
        Me.NhietDo.UpdateIfNull = ""
        Me.NhietDo.UpdateWhenFormLock = False
        Me.NhietDo.ViewName = ""
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.Location = New System.Drawing.Point(100, 12)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(94, 31)
        Me.U_ButtonCus1.TabIndex = 2
        Me.U_ButtonCus1.Text = "Thực &hiện"
        '
        'FrmQciKg
        '
        Me.AcceptButton = Me.U_ButtonCus1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(208, 61)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.NhietDo)
        Me.DefaultFormLoad = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmQciKg"
        Me.Text = "Nhiệt độ"
        Me.Controls.SetChildIndex(Me.NhietDo, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NhietDo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NhietDo As U_TextBox.U_NumericEdit
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
End Class
