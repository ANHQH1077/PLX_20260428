Public Class TrueDBGrid
    
    
    Private p_DefaultRemove As Boolean = True

    Public Property DefaultRemove() As Boolean
        Get
            Return p_DefaultRemove
        End Get
        Set(ByVal value As Boolean)
            p_DefaultRemove = value
        End Set


    End Property


    
    Private Sub JSDGridControl_ViewRegistered(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.ViewOperationEventArgs) Handles Me.ViewRegistered
        If Me.ViewCollection.Count > 0 Then

        End If

    End Sub

    Public Sub New()
        ' Dim GridView1 As New GridView
        '' This call is required by the designer.
        'Dim p_Count As Integer
        'Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
        'For p_Count = 0 To Me.Views.Count - 1
        '    p_GridView = Me.Views(p_Count)
        '    AddHandler p_GridView.CellValueChanged, AddressOf GridView1_CellValueChanged
        'Next

        'Public Sub New(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        ' MyBase.new(gridView)

        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'Private Sub U_TrueDBGrid1_EmbeddedNavigator_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles U_TrueDBGrid.e

    'End Sub
    'Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)

    'End Sub

    Public Sub GridNavigatorButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        ModGridNavigatorButtonClick(sender, e)
    End Sub



    Public Sub TrueDBGrid1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Dim p_SQL As String
        ' p_SQL = ""
    End Sub


    Private Sub TrueDBGrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim p_SQL As String
        Dim p_GridView As GridView

        Dim p_TrueGrid As TrueDBGrid

        Dim p_Form As New Object
        p_SQL = ""

        If e.KeyCode = Windows.Forms.Keys.Delete Then
            p_SQL = ""
            p_GridView = Me.Views(0)
            p_Form = Me.FindForm
            If p_GridView.OptionsBehavior.ReadOnly = True Or p_GridView.OptionsBehavior.Editable = False Or p_Form.FormEdit = False Or Me.DefaultRemove = False Then
                Exit Sub
            End If
            '' p_TrueGrid = CType(sender, TrueDBGrid)
            If Me.UseEmbeddedNavigator = True Then
                If Me.EmbeddedNavigator.Buttons.Remove.Enabled = True And Me.EmbeddedNavigator.Buttons.Remove.Visible = True Then
                    Call Me.EmbeddedNavigator.Buttons.DoClick(Me.EmbeddedNavigator.Buttons.Remove)
                End If
            End If
         


            ' ModGridNavigatorButtonRemove(Me)
            ' GridNavigatorButtonClick(sender, Me.EmbeddedNavigator.Buttons.)
        End If

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
