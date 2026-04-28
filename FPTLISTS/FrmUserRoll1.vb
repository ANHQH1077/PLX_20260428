Public Class FrmUserRoll1

    Private Sub FrmUserRoll1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            save()
        End If
    End Sub

    Private Sub FrmUserRoll1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub save()
        Dim p_Datatable As DataTable
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_ArrRow As DataRow
        Dim p_Count As Integer
        Dim p_SQL As String
        Dim p_from As Decimal = 0
        Dim p_To As Decimal = 0.05

        Dim p_fromValue As Decimal = 0
        Dim p_ToValue As Decimal = 0

        p_Binding = Me.TrueDBGrid1.DataSource
        p_Datatable = CType(p_Binding.DataSource, DataTable)

        ' p_ArrRow = p_Datatable.Select("CHECKUPD='Y' or CHECKUPD='R' or CHECKUPD='I'")
        'p_ArrRow = p_Datatable.Select("CHECKUPD='Y'")

        For p_Count = 0 To p_Datatable.Rows.Count - 1
            p_ArrRow = p_Datatable.Rows(p_Count)
            If p_ArrRow.Item("CHECKUPD").ToString.Trim = "" Or p_ArrRow.Item("CHECKUPD").ToString.Trim = "N" Then
                Continue For
            End If
            If p_ArrRow.Item("FROM_RATE").ToString.Trim <> "" Then
                p_fromValue = p_ArrRow.Item("FROM_RATE").ToString.Trim
            End If
            If p_ArrRow.Item("TO_RATE").ToString.Trim <> "" Then
                p_ToValue = p_ArrRow.Item("TO_RATE").ToString.Trim
            End If


            If p_ToValue < p_fromValue Then
                ShowMessageBox("", "Giá trị sau phải lớn hơn giá trị trước")
                Exit Sub
            End If

            'If p_fromValue < p_from Then
            '    ShowMessageBox("", "Giá trị nằm trong khoảng " & p_from & " đến " & p_To)
            '    Exit Sub
            'End If

            'If p_ToValue > p_To Then
            '    ShowMessageBox("", "Giá trị nằm trong khoảng " & p_from & " đến " & p_To)
            '    Exit Sub
            'End If
        Next


        'For p_Count = 0 To p_ArrRow.Length - 1
        '    If p_ArrRow(p_Count).Item("FROM_RATE").ToString.Trim <> "" Then
        '        p_fromValue = p_ArrRow(p_Count).Item("FROM_RATE").ToString.Trim
        '    End If
        '    If p_ArrRow(p_Count).Item("TO_RATE").ToString.Trim <> "" Then
        '        p_ToValue = p_ArrRow(p_Count).Item("TO_RATE").ToString.Trim
        '    End If


        '    If p_ToValue < p_fromValue Then
        '        ShowMessageBox("", "Giá trị sau phải lớn hơn giá trị trước")
        '        Exit Sub
        '    End If

        '    If p_fromValue < p_from Then
        '        ShowMessageBox("", "Giá trị nằm trong khoảng " & p_from & " đến " & p_To)
        '        Exit Sub
        '    End If

        '    If p_ToValue > p_To Then
        '        ShowMessageBox("", "Giá trị nằm trong khoảng " & p_from & " đến " & p_To)
        '        Exit Sub
        '    End If
        'Next

        Me.DefaultSave = True
        Me.UpdateToDatabase(Me, "")
        Me.DefaultSave = False
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        save()
    End Sub
End Class