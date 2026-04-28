Public Class KV2_TichKe_Sat

    Public Sub New()


        ' This call is required by the designer.
        InitializeComponent()
        'Try
        '    Me.p_Day = RpDataset1.Tables("wwTrans").Rows(0).Item("NgayXuat")
        '    Me.p_Month = RpDataset1.Tables("wwTrans").Rows(0).Item("NgayXuat")
        '    Me.p_Year = RpDataset1.Tables("wwTrans").Rows(0).Item("NgayXuat")
        'Catch ex As Exception

        'End Try

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Overrides Sub Finalize()
        'Try
        '    Me.p_Day = RpDataset1.Tables("wwTrans").Rows(0).Item("NgayXuat")
        '    Me.p_Month = RpDataset1.Tables("wwTrans").Rows(0).Item("NgayXuat")
        '    Me.p_Year = RpDataset1.Tables("wwTrans").Rows(0).Item("NgayXuat")
        'Catch ex As Exception

        'End Try
        MyBase.Finalize()
    End Sub
End Class