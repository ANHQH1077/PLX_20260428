Public Class FrmTichKe 

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        Dim p_SoTichKe As String = ""
        Dim p_SQL As String = ""
        Dim p_Table As DataTable
        Dim p_NgayXuat As String = ""
        Dim p_SoLenh As String = ""
        Dim p_DataSet As DataSet
        Dim p_MATUDONGHOA As Boolean = False
        If Not Me.NgayXuat.EditValue Is Nothing Then
            p_NgayXuat = Me.NgayXuat.EditValue.ToString.Trim
        End If
        If Not Me.SoTichKe.EditValue Is Nothing Then
            p_SoTichKe = Me.SoTichKe.EditValue.ToString.Trim
        End If

        If p_SoTichKe = "" Or p_NgayXuat = "" Then
            ShowMessageBox("", "Thông tin chưa đầy đủ")
            Exit Sub
        End If

        p_SQL = "select (SELECT DISTINCT ',' + SoLenh " & _
                   " FROM tbltichke where NgayTichKe  ='" & p_NgayXuat & "' and SoTichKe = '" & p_SoTichKe & "' " & _
                  " FOR XML PATH('')  ) as Abc;"
        p_SQL = p_SQL & " select KeyValue from SYS_CONFIG  where upper(KeyCode) ='MATUDONGHOA'; "
        p_DataSet = GetDataSet(p_SQL, p_SQL)

        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_Table = p_DataSet.Tables(0)
                If p_Table.Rows.Count > 0 Then
                    p_SoLenh = p_Table.Rows(0).Item(0).ToString.Trim
                End If

                p_Table = p_DataSet.Tables(1)
                If p_Table.Rows.Count > 0 Then
                    If p_Table.Rows(0).Item(0).ToString.Trim = "Y" Then
                        p_MATUDONGHOA = True
                    End If
                End If

            End If
        End If
        'p_Table = GetDataTable(p_SQL, p_SQL)
        'If Not p_Table Is Nothing Then
        '    If p_Table.Rows.Count > 0 Then
        '        p_SoLenh = CDate(p_Table.Rows(0).Item(0))
        '    End If
        'End If

        If p_SoLenh <> "" Then
            _Report_Object.clsInTichKe(False, p_SoLenh, p_MATUDONGHOA)

        Else
            ShowMessageBox("", "Tích kê không hợp lệ")
        End If
    End Sub

    Private Sub FrmTichKe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String = ""
        Dim p_Table As DataTable

        Dim p_Dataset As DataSet

        p_SQL = "select InTichKe from sys_user  where upper(User_Name)='" & UCase(g_UserName) & "';"
        p_SQL = p_SQL & "select convert(date, getdate()) as dDate;"
        p_Dataset = GetDataSet(p_SQL, p_SQL)
        If Not p_Dataset Is Nothing Then
            If p_Dataset.Tables.Count > 0 Then
                p_Table = p_Dataset.Tables(0)
                If p_Table.Rows.Count > 0 Then
                    If p_Table.Rows(0).Item(0).ToString.Trim <> "Y" Then
                        Me.SimpleButton7.Visible = False
                    End If
                End If

                p_Table = p_Dataset.Tables(1)
                If p_Table.Rows.Count > 0 Then
                    Me.NgayXuat.EditValue = CDate(p_Table.Rows(0).Item(0))
                End If
            End If
        End If

    End Sub
End Class