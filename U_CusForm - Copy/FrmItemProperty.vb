Public Class FrmItemProperty 

    Private Sub ItemList_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemList.EditValueChanged
        If Not ItemList.EditValue Is Nothing Then
            p_GetPropertyItem(ItemList.EditValue.ToString.Trim)
        End If
    End Sub

    Private Sub LookUpEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LookUpEdit1.EditValueChanged
        Dim p_Value As String = ""
        If Me.LookUpEdit1.Text.ToString.Trim <> "" Then
            Dim p_Row() As DataRow
            p_Row = g_ItemProperty.Select("ItemProperty='" & Me.LookUpEdit1.Text.ToString.Trim & "'")
            If p_Row.Length > 0 Then
                p_Value = p_Row(0).Item("ValueProperty").ToString.Trim
            End If
        End If
        Me.MemoEdit1.EditValue = p_Value
    End Sub

    Private Sub FrmItemProperty_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        p_XtrFormProperty = Nothing
    End Sub

    Private Sub FrmItemProperty_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class