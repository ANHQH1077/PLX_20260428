<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class U_TextBox
    ' Inherits System.Windows.Forms.UserControl
    Inherits DevExpress.XtraEditors.TextEdit


    'UserControl overrides dispose to clean up the component list.
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
        Me.SuspendLayout()
        '
        'U_TextBox
        '
        Me.Properties.AutoHeight = False
        Me.Name = "U_TextBox"
        Me.Size = New System.Drawing.Size(230, 30)
        Me.ResumeLayout(True)
        Me.Width = 160
        Me.ToolTip = ""
        Me.Font = New Font("Tahoma", 12, FontStyle.Regular)
        Me.Properties.Appearance.Options.UseFont = False
        Me.Properties.Appearance.Font = Me.Font
        Me.Properties.AppearanceDisabled.Options.UseFont = False
        Me.Properties.AppearanceDisabled.Font = Me.Font
        Me.Properties.AppearanceFocused.Options.UseFont = False
        Me.Properties.AppearanceFocused.Font = Me.Font
        Me.Properties.AppearanceReadOnly.Options.UseFont = False
        Me.Properties.AppearanceReadOnly.Font = Me.Font
        ' Me.StyleController.Appearance.Font = New Font("Tahoma", 12, FontStyle.Regular)
        '   Me.Font = New Font("Tahoma", 12)

    End Sub

End Class
