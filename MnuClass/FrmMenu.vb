Public Class FrmMenu 
    Public p_Addnew As Boolean = True
    Private Sub FrmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.p_Addnew = False Then
            Me.MENU_CODE.Properties.ReadOnly = True
        Else
            Me.MENU_CODE.Focus()
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        '  Dim p_Check As String = "Y"
        Dim p_Row As DataRow
        If e.Column.Name = "SubMenu" Then
            p_Row = Me.GridView1.GetDataRow(e.RowHandle)
            If Not p_Row Is Nothing Then
                If p_Row.Item("SubMenu").ToString.Trim = "" Then
                    Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, Me.GridView1.Columns.Item("SubMenuName"), "")
                End If
            End If
        End If
        If e.Column.Name <> "CHECKUPD" Then
            Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, Me.GridView1.Columns.Item("CHECKUPD"), "Y")

        End If

        Me.FormStatus = True
        Me.BtnOk.Text = CaptionUpd

    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If Me.FormStatus = False And Me.BtnOk.Text <> Me.CaptionUpd Then
            Me.MENU_CODE.Properties.ReadOnly = True
        End If
    End Sub
End Class