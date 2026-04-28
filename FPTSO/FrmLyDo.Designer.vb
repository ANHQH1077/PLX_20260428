<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLyDo
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GhiChu = New U_TextBox.U_TextBox()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus(Me.components)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GhiChu.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 19)
        Me.Label3.TabIndex = 462
        Me.Label3.Text = "Lý do hủy"
        '
        'GhiChu
        '
        Me.GhiChu.AllowInsert = True
        Me.GhiChu.AllowUpdate = True
        Me.GhiChu.AutoKeyFix = ""
        Me.GhiChu.AutoKeyName = ""
        Me.GhiChu.BindingSourceName = ""
        Me.GhiChu.ChangeFormStatus = True
        Me.GhiChu.CopyFromItem = ""
        Me.GhiChu.DefaultValue = ""
        Me.GhiChu.FieldName = ""
        Me.GhiChu.FieldType = "C"
        Me.GhiChu.KeyInsert = ""
        Me.GhiChu.LinkLabel = ""
        Me.GhiChu.Location = New System.Drawing.Point(99, 12)
        Me.GhiChu.Name = "GhiChu"
        Me.GhiChu.NoUpdate = "N"
        Me.GhiChu.PrimaryKey = ""
        Me.GhiChu.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GhiChu.Properties.Appearance.Options.UseFont = True
        Me.GhiChu.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GhiChu.Properties.AppearanceDisabled.Options.UseFont = True
        Me.GhiChu.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GhiChu.Properties.AppearanceFocused.Options.UseFont = True
        Me.GhiChu.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GhiChu.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.GhiChu.Properties.AutoHeight = False
        Me.GhiChu.Required = "N"
        Me.GhiChu.Size = New System.Drawing.Size(337, 26)
        Me.GhiChu.TabIndex = 461
        Me.GhiChu.TableName = ""
        Me.GhiChu.UpdateIfNull = ""
        Me.GhiChu.UpdateWhenFormLock = True
        Me.GhiChu.UpperValue = False
        Me.GhiChu.ViewName = "FPT_tblLenhXuatE5_V"
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = False
        Me.U_ButtonCus1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.U_ButtonCus1.Location = New System.Drawing.Point(176, 61)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(96, 33)
        Me.U_ButtonCus1.TabIndex = 474
        Me.U_ButtonCus1.TabStop = False
        Me.U_ButtonCus1.Text = "OK"
        '
        'FrmLyDo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 123)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GhiChu)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmLyDo"
        Me.Text = "Lý do hủy"
        Me.Controls.SetChildIndex(Me.GhiChu, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GhiChu.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GhiChu As U_TextBox.U_TextBox
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
End Class
