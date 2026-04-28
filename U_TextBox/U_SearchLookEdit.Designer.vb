<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class U_SearchLookEdit
    'Inherits DevExpress.Data.
    Inherits DevExpress.XtraEditors.SearchLookUpEdit
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
        components = New System.ComponentModel.Container()
        ' Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Properties.AutoHeight = False
        Me.Size = New System.Drawing.Size(230, 30)
        Me.Font = New Font("Tahoma", 12, FontStyle.Regular)
        Me.Properties.Appearance.Options.UseFont = False
        Me.Properties.Appearance.Font = Me.Font
        Me.Properties.AppearanceDisabled.Options.UseFont = False
        Me.Properties.AppearanceDisabled.Font = Me.Font
        Me.Properties.AppearanceFocused.Options.UseFont = False
        Me.Properties.AppearanceFocused.Font = Me.Font
        Me.Properties.AppearanceReadOnly.Options.UseFont = False
        Me.Properties.AppearanceReadOnly.Font = Me.Font

    End Sub

    Private Sub p_ButtonPressed(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles MyBase.ButtonPressed
        'MsgBox("asdas")
        'S.p_Commit = True
        '  System.Boolean = True
        ' e.ToolTip = "dfgdg"
        MsgBox(e.Button.Caption)


    End Sub


    Friend WithEvents SearchLookUpEdit1 As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView

End Class
