Public Class FrmHangHoa_Map

    Private Sub FrmHangHoa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Me.DefaultSave = True
        Me.UpdateToDatabase(Me)
        Me.DefaultSave = False
    End Sub
End Class