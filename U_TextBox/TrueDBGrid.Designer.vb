<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrueDBGrid
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
        Dim GridView1 As GridView
        'Dim p_GridView1 As GridView
        'Dim p_Count As Integer
        'Dim p_DefaultView As DevExpress.XtraGrid.Views.Grid.GridView
        'Dim p_Coumn As New GridColumn

        ' components = New System.ComponentModel.Container()
        Me.UseEmbeddedNavigator = True
        AddHandler Me.EmbeddedNavigator.ButtonClick, AddressOf GridNavigatorButtonClick

        AddHandler Me.KeyPress, AddressOf TrueDBGrid1_KeyPress
        AddHandler Me.KeyDown, AddressOf TrueDBGrid1_KeyDown


        ' Me.Appearance.font = New Font("Courier New", 10)

        'Me.AppereanceCell.Font = Font("Arial",12,FontStyle.Bold);

        'GridView1 = New GridView
        'GridView1.Name = "ctlGridView"
        ' ''p_GridView1.BaseInfo

        'CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        'CType(GridView1, System.ComponentModel.ISupportInitialize).BeginInit()

        ' '' p_GridView1.Columns.Add(New GridColumn)
        ' '' Dim p_GridView As GridView

        ''Me.DefaultRemove = True
        ''Me.Location = New System.Drawing.Point(3, 3)
        ' ''Me.MainView = Me.GridView1


        ''Me.Name = "TrueDBGrid1"
        ''Me.Size = New System.Drawing.Size(400, 200)
        ''Me.TabIndex = 0
        ''Me.UseEmbeddedNavigator = True

        ' ''If Me.ViewCollection.Count > 0 Then
        ' ''    p_DefaultView = Me.MainView
        ' ''    Me.ViewCollection.Remove(p_DefaultView)
        ' ''End If




        ' ''p_Coumn.Name = "Column0"
        ' ''p_Coumn.Caption = "Column0"
        ' ''p_GridView1.Columns.Add(p_Coumn)
        ' '' p_GridView1.Name = "ctlGridView1"


        ' '' Me.ViewCollection.Add(p_GridView1)



        'GridView1.GridControl = Me


        'Me.MainView = GridView1
        ' '' p_GridView1.GridControl = Me
        ' ''  p_GridView1.Name = "GridView11"


        'CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        'CType(GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        ' ''
        ''  Me.ViewRepository.Grid.CreateView("ctlGridView")


        '
        ' ''Me.UseEmbeddedNavigator = False
        ' '' Me.View

        ''Me.GridView1 = New GridView()



        ''  CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        ''  CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        '' Me.SuspendLayout()
        ''
        ''U_TrueDBGrid1
        ''

        ''GridView1
        ''
        ''Me.GridView1.GridControl = Me
        ''Me.GridView1.Name = "GridView1"


        '' Me.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {GridView1})
        ''
        'Me.ViewRepository.Views.Add(GridView1)
        'Me.ViewCollection.Add(GridView1)
        ''
        ''Form1
        ''

        ''   Me.ClientSize = New System.Drawing.Size(860, 338)

        ''  CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        ''   ' CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        ''  Me.ResumeLayout()


        ''Friend WithEvents U_TrueDBGrid1 As U_TextBox.U_TrueDBGrid

    End Sub



    Protected Overrides Sub OnControlAdded(ByVal e As System.Windows.Forms.ControlEventArgs)
        MyBase.OnControlAdded(e)
    End Sub

    Protected Overrides Sub OnBindingContextChanged(ByVal e As System.EventArgs)
        MyBase.OnBindingContextChanged(e)
    End Sub

    

    'Protected Overloads Function CreateDefaultView() As GridView  ' DevExpress.XtraGrid.Views.Base.BaseView
    '    Dim p_View As New GridView
    '    p_View.Name = "GridView" & Me.Views.Count + 1
    '    Return p_View
    'End Function

    Friend WithEvents TrueDBGrid As DevExpress.XtraGrid.GridControl
    ' Protected WithEvents GridView1 As GridView
    ' Friend WithEvents GridColumn As GridColumn
    ' Friend WithEvents U_TrueDBGrid1 As DevExpress.XtraGrid.
    'Protected Overrides GridView1 As GridView

    ' Friend WithEvents p_GridView1 As GridView
    ' Friend WithEvents GridView1 As GridView
    Friend WithEvents GirdButtonClick As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

    'Protected Overrides Sub RegisterView(ByVal gv As DevExpress.XtraGrid.Views.Base.BaseView)
    '    MyBase.RegisterView(gv)
    'End Sub
End Class
