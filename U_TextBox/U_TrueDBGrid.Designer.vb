<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class U_TrueDBGrid
    'Inherits DevExpress.XtraGrid.Views.Grid.GridView
    'Inherits DevExpress.XtraGrid.GridControl   'XtraGrid.GridControl '   .XtraGrid.GridControl

    Inherits DevExpress.XtraGrid.GridControl
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

        Me.UseEmbeddedNavigator = True
        Me.GridView1 = New GridView
        AddHandler Me.EmbeddedNavigator.ButtonClick, AddressOf GridNavigatorButtonClick
        'Me.UseEmbeddedNavigator = False
        ' Me.View
    End Sub

    Friend WithEvents U_TrueDBGrid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As GridView
    'Friend WithEvents U_TrueDBGrid1 As DevExpress.XtraGrid.


    ' Friend WithEvents GirdButtonClick As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

End Class
