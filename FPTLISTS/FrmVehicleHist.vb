Public Class FrmVehicleHist
    Private pv_SoPhuongTien As String = ""
    Public Property SoPhuongTien() As String
        Get
            Return pv_SoPhuongTien
        End Get
        Set(ByVal value As String)
            pv_SoPhuongTien = value
        End Set
    End Property

    Private Sub FrmVehicleHist_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.GridView1.Where = " MaPhuongTien ='" & pv_SoPhuongTien & "'"
        Me.GridView2.Where = " MaPhuongTien ='" & pv_SoPhuongTien & "'"
        Me.DefaultFormLoad = True
        Me.XtraForm1_Load()

    End Sub
End Class