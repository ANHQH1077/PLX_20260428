Public Class FrmQCI
    Public p_Top As Integer = 0
    Public p_Left As Integer = 0
    Public p_Edit As U_TextBox.U_NumericEdit

    Private Sub FrmQCI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            p_Edit = Me.NhietDo
            Me.Close()
        End If
    End Sub

    Private Sub FrmQCI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If p_Column.FormList = True Then
        '    p_Top = g_Form.MousePosition.Y
        '    p_Left = g_Form.MousePosition.X
        'Else
        '    p_Top = p_RptForm.top + p_TrueGrid.Top
        '    p_Left = p_RptForm.left + p_TrueGrid.Left + (p_TrueGrid.Width / 2)
        'End If
        Me.Location = New System.Drawing.Point(p_Left, p_Top)

        Me.NhietDo.EditValue = 15.0
        Me.NhietDo.Focus()
        p_Edit = NhietDo
    End Sub

    Private Sub NhietDo_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class