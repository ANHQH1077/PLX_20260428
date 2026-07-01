Imports DevExpress.XtraGrid.Menu
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils.Menu
Public Class FrmHSGianNo


    Private Sub FrmMeter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.DefaultSave = True
        Me.UpdateToDatabase(Me)
        Me.DefaultSave = False
    End Sub
End Class