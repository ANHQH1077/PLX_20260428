Public Class FrmTankListATG_Hist
    Public g_Tank As String = ""
    Private Sub FrmTankListATG_Hist_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If g_Tank <> "" Then
            Me.GridView2.Where = "Tankcode ='" & g_Tank & "'"
        End If
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False
    End Sub
End Class