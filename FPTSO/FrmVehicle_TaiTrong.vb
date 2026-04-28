Public Class FrmVehicle_TaiTrong

    Public p_MaPhuongTien As String = ""

    Private Sub FrmVehicle_TaiTrong_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            SaveRecord()
        End If
    End Sub

    Private Sub FrmVehicle_TaiTrong_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txtMaPhuongTien.EditValue = p_MaPhuongTien

        Me.DefaultFormLoad = True
        Me.XtraForm1_Load()
        Me.DefaultFormLoad = False
        ' Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom

    End Sub


    Private Sub SaveRecord()
        Dim p_Count As Integer
        Dim p_Row As DataRow
        GridView1.RefreshData()

        For p_Count = 0 To Me.GridView1.RowCount - 1
            p_Row = Me.GridView1.GetDataRow(p_Count)
            If Not p_Row Is Nothing Then
                Me.GridView1.SetRowCellValue(p_Count, "MaPhuongTien", p_MaPhuongTien)
            End If
        Next
        Me.DefaultSave = True
        Me.UpdateToDatabase(Me, Nothing)
        Me.DefaultSave = False

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SaveRecord()
    End Sub
End Class