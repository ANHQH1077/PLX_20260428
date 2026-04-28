Public Class FrmGiaoNhanHH
    Public g_MaTuyenDuong As String = ""
    Private Sub FrmGiaoNhanHH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub GetData()
        Me.GridView1.Where = "MaTuyenDuong ='" & g_MaTuyenDuong & "'"
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False
    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim p_Row As DataRow
        p_Row = Me.GridView1.GetDataRow(Me.GridView1.FocusedRowHandle)
        If Not p_Row Is Nothing Then
            If p_Row.Item("MaTuyenDuong").ToString.Trim = "" Then
                p_Row.Item("MaTuyenDuong") = g_MaTuyenDuong
            End If
            If p_Row.Item("Status").ToString.Trim = "" Then
                p_Row.Item("Status") = "Y"
            End If
        End If
    End Sub

    Private Sub GridView1_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        Dim p_Row As DataRow
        p_Row = Me.GridView1.GetDataRow(Me.GridView1.FocusedRowHandle)
        If Not p_Row Is Nothing Then
            If p_Row.Item("MaTuyenDuong").ToString.Trim = "" Then
                p_Row.Item("MaTuyenDuong") = g_MaTuyenDuong
            End If
            If p_Row.Item("Status").ToString.Trim = "" Then
                p_Row.Item("Status") = "Y"
            End If
        End If
    End Sub

    Private Sub GridView1_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridView1.ShowingEditor

    End Sub

    Private Sub GridView1_ShownEditor(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.ShownEditor

    End Sub

    Private Sub GridView1_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView1.ValidateRow

    End Sub

    Private Sub GridView1_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        'Dim p_Row As DataRow
        'p_Row = Me.GridView1.GetDataRow(Me.GridView1.FocusedRowHandle)
        'If Not p_Row Is Nothing Then
        '    If p_Row.Item("MaTuyenDuong").ToString.Trim = "" Then
        '        p_Row.Item("MaTuyenDuong") = g_MaTuyenDuong
        '    End If
        '    If p_Row.Item("Status").ToString.Trim = "" Then
        '        p_Row.Item("Status") = "Y"
        '    End If
        'End If
    End Sub

    Private Sub ToolStrip2_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If Me.FormStatus = True Then
            Me.DefaultSave = True
            Me.UpdateToDatabase(Me)
            Me.DefaultSave = True
        End If
    End Sub
End Class