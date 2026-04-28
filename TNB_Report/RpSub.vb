Partial Class RpSub
    Partial Class HoaDonDataTable

        Private Sub HoaDonDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DonGiaColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
