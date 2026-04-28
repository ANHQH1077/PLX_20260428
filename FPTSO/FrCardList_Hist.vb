Public Class FrCardList_Hist

    Public StrNumber As String = ""
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.UpdateToDatabase(Me)
    End Sub

    Private Sub FrCardList_Hist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Lịch sử thay đổi - " & StrNumber
        Me.GridView1.Where = "CardNum ='" & StrNumber & "'"
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False

    End Sub
End Class