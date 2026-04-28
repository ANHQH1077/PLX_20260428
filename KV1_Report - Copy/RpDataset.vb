Partial Class RpDataset

    Partial Class wwTransDataTable

        Private Sub wwTransDataTable_wwTransRowChanging(ByVal sender As System.Object, ByVal e As wwTransRowChangeEvent) Handles Me.wwTransRowChanging

        End Sub

        Private Sub wwTransDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.LoaiPhieuColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class


End Class
