Imports System.Drawing.Printing

Public Class rptLietKeBienBanGiaoNhan

    'Imports System.Drawing.Printing
    ' ...

    Private detailRowCount As Integer = 0

    Private Sub Detail_BeforePrint(sender As Object, e As PrintEventArgs) Handles Detail.BeforePrint
        'If System.Threading.Interlocked.Increment(detailRowCount) > 5 Then
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub GroupHeader3_BeforePrint(ByVal sender As Object, ByVal e As PrintEventArgs) Handles GroupHeader3.BeforePrint
        detailRowCount = detailRowCount + 1
        Me.XrLabel4.Text = detailRowCount
    End Sub


    Private Sub GroupHeader1_BeforePrint(ByVal sender As Object, ByVal e As PrintEventArgs) Handles GroupHeader1.BeforePrint
        detailRowCount = 0
        'Me.XrLabel4.Text = detailRowCount
    End Sub

End Class