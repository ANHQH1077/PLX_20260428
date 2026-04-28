Public Class FrmChangeClient

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        Dim p_SQL As String = "Status in  ('1','2')"
        Dim p_date As Date
        Dim p_SQL2 As String
        Dim p_Data As DataTable
        If Not Me.SoLenh.EditValue Is Nothing Then
            If Me.SoLenh.EditValue.ToString.Trim <> "" Then
                p_SQL2 = "Select top(1) SoLenh, Status from tblLenhXuatE5 where SoLenh = '" & Me.SoLenh.EditValue.ToString.Trim & "' "
                p_Data = GetDataTable(p_SQL2, p_SQL2)
                If Not p_Data Is Nothing Then
                    If p_Data.Rows.Count >= 1 Then
                        If (p_Data.Rows(0).Item("Status").ToString.Trim <> "1") And (p_Data.Rows(0).Item("Status").ToString.Trim <> "2") Then
                            ShowMessageBox("", "Lệnh xuất không hợp lệ")
                            Exit Sub
                        End If
                    End If
                End If
            End If
        End If
        If Not Me.SoLenh.EditValue Is Nothing Then
            If Me.SoLenh.EditValue.ToString.Trim <> "" Then
                p_SQL = p_SQL & " AND SoLenh='" & Me.SoLenh.EditValue.ToString.Trim & "'"
            End If
        End If
        If Not Me.NgayThang.EditValue Is Nothing Then
            If Me.NgayThang.EditValue.ToString.Trim <> "" Then
                p_date = CDate(Me.NgayThang.EditValue)
                If p_SQL = "" Then
                    p_SQL = " NgayXuat=convert(date,'" & p_date.ToString(g_Format_Date) & "')"
                Else
                    p_SQL = p_SQL & " and NgayXuat=convert(date,'" & p_date.ToString(g_Format_Date) & "')"
                End If
            End If
        End If
        Me.GridView1.Where = p_SQL
        Me.DefaultFormLoad = True
        XtraForm1_Load()
        Me.DefaultFormLoad = False
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        UpdateToDatabase(Me, "")
    End Sub

    Private Sub FrmChangeStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class