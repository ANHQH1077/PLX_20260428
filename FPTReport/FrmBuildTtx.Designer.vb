<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuildTtx
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BtnBuild = New U_TextBox.U_Button()
        Me.TxtProName = New U_TextBox.U_TextBox()
        Me.U_Label1 = New U_TextBox.U_Label()
        CType(Me.TxtProName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnBuild
        '
        Me.BtnBuild.DefaultUpdate = False
        Me.BtnBuild.Location = New System.Drawing.Point(446, 86)
        Me.BtnBuild.Name = "BtnBuild"
        Me.BtnBuild.Size = New System.Drawing.Size(75, 23)
        Me.BtnBuild.TabIndex = 0
        Me.BtnBuild.Text = "Build Ttx"
        '
        'TxtProName
        '
        Me.TxtProName.ChangeFormStatus = False
        Me.TxtProName.CopyFromItem = ""
        Me.TxtProName.FieldName = ""
        Me.TxtProName.FieldType = "C"
        Me.TxtProName.KeyInsert = ""
        Me.TxtProName.Location = New System.Drawing.Point(122, 31)
        Me.TxtProName.Name = "TxtProName"
        Me.TxtProName.NoUpdate = "N"
        Me.TxtProName.PrimaryKey = ""
        Me.TxtProName.Required = ""
        Me.TxtProName.Size = New System.Drawing.Size(399, 20)
        Me.TxtProName.TabIndex = 1
        Me.TxtProName.TableName = ""
        Me.TxtProName.UpdateIfNull = ""
        Me.TxtProName.UpdateWhenFormLock = False
        Me.TxtProName.ViewName = ""
        '
        'U_Label1
        '
        Me.U_Label1.Location = New System.Drawing.Point(32, 34)
        Me.U_Label1.Name = "U_Label1"
        Me.U_Label1.Size = New System.Drawing.Size(74, 13)
        Me.U_Label1.TabIndex = 2
        Me.U_Label1.Text = "Procedure Build"
        '
        'FrmBuildTtx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 128)
        Me.Controls.Add(Me.U_Label1)
        Me.Controls.Add(Me.TxtProName)
        Me.Controls.Add(Me.BtnBuild)
        Me.Name = "FrmBuildTtx"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrmBuildTtx"
        CType(Me.TxtProName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnBuild As U_TextBox.U_Button
    Friend WithEvents TxtProName As U_TextBox.U_TextBox
    Friend WithEvents U_Label1 As U_TextBox.U_Label
End Class
