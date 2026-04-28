Public Class Form2

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CreateDate.EditValue = Now.Date
    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_SQL As String
        Dim p_data As DataTable
        Dim p_Date As String
        Dim p_DataSet As DataSet
        p_Date = CDate(Me.CreateDate.EditValue).ToString("yyyyMMdd")
        p_SQL = "FPT_DensToSap '" & p_Date & "','" & g_UserName & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables(1).Rows(0).Item(0) = 0 Then
                'g_()
                p_SQL = ""
                THN_DendsToSAP(p_DataSet.Tables(0), p_SQL)
                If p_SQL = "" Then
                    ShowMessageBox("", "Đã thực hiện xong", 1)
                Else
                    ShowMessageBox("", p_SQL)
                End If
            Else
                ShowMessageBox("", p_DataSet.Tables(1).Rows(0).Item(1))
            End If
        End If
    End Sub
End Class