Public Class FrmE5Rate

    Private Sub FrmE5Rate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'Dim p_Count As Integer
        'Dim p_From As Double = 4
        'Dim p_To As Double = 0
        'Dim p_Row As DataRow
        If Asc(e.KeyChar) = 19 Then
            saverecord()
            'For p_Count = 0 To Me.GridView1.RowCount - 1
            '    p_Row = Me.GridView1.GetDataRow(p_Count)
            '    If Not p_Row Is Nothing Then
            '        If p_Row.Item("ERate_Start").ToString.Trim <> "" Then
            '            p_From = CDbl(p_Row.Item("ERate_Start").ToString.Trim)
            '        End If
            '        If p_Row.Item("ERate_End").ToString.Trim <> "" Then
            '            p_To = CDbl(p_Row.Item("ERate_End").ToString.Trim)
            '        End If
            '    End If
            'Next
            'If p_From > p_To Then
            '    ShowMessageBox("", "Giá trị không hợp lệ")
            '    Exit Sub
            'End If
            'Me.DefaultSave = True
            'Me.UpdateToDatabase(Me, "")
            'Me.DefaultSave = False
        End If
    End Sub

    Private Sub saverecord()
        Dim p_Count As Integer
        Dim p_From As Double = 4
        Dim p_To As Double = 0
        Dim p_Row As DataRow
        ' If Asc(e.KeyChar) = 19 Then
        For p_Count = 0 To Me.GridView1.RowCount - 1
            p_Row = Me.GridView1.GetDataRow(p_Count)
            If Not p_Row Is Nothing Then
                If p_Row.Item("ERate_Start").ToString.Trim <> "" Then
                    p_From = CDbl(p_Row.Item("ERate_Start").ToString.Trim)
                End If
                If p_Row.Item("ERate_End").ToString.Trim <> "" Then
                    p_To = CDbl(p_Row.Item("ERate_End").ToString.Trim)
                End If
            End If
        Next
        If p_From > p_To Then
            ShowMessageBox("", "Giá trị không hợp lệ")
            Exit Sub
        End If
        Me.DefaultSave = True
        Me.UpdateToDatabase(Me, "")
        Me.DefaultSave = False
        '  End If
    End Sub

    Private Sub FrmE5Rate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        p_XtraUserName = g_User_ID
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        saverecord()
    End Sub
End Class