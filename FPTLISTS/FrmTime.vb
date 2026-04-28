Public Class FrmTime

    Private Sub FrmTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        Dim p_datatable As DataTable
        p_SQL = "select * from tblTime"
        p_datatable = GetDataTable(p_SQL, p_SQL)
        If Not p_datatable Is Nothing Then
            If p_datatable.Rows.Count > 0 Then
                If p_datatable.Rows(0).Item("TimeDefault").ToString.Trim <> "" Then
                    Me.TimeDefault.EditValue = p_datatable.Rows(0).Item("TimeDefault")
                End If

                If p_datatable.Rows(0).Item("FromTime").ToString.Trim <> "" Then
                    Me.FromTime.EditValue = p_datatable.Rows(0).Item("FromTime")
                End If
                If p_datatable.Rows(0).Item("ToTime").ToString.Trim <> "" Then
                    Me.ToTime.EditValue = p_datatable.Rows(0).Item("ToTime")
                End If
            End If

        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim p_SQL, p_Time, p_FromTime, p_ToTime As String
        p_Time = "NUll"
        p_FromTime = "Null"
        p_ToTime = "Null"
        If Not Me.TimeDefault.EditValue Is Nothing Then
            If Me.TimeDefault.EditValue.ToString.Trim <> "" Then
                p_Time = CDate(Me.TimeDefault.EditValue).ToString("HH:mm:ss") ' Me.TimeDefault.EditValue.ToString.Trim
            End If
        End If
        If Not Me.FromTime.EditValue Is Nothing Then
            If Me.FromTime.EditValue.ToString.Trim <> "" Then
                p_FromTime = CDate(Me.FromTime.EditValue).ToString("yyyyMMdd HH:mm:ss") '  Me.FromTime.EditValue.ToString.Trim
            End If
        End If
        If Not Me.ToTime.EditValue Is Nothing Then
            If Me.ToTime.EditValue.ToString.Trim <> "" Then
                p_ToTime = CDate(Me.ToTime.EditValue).ToString("yyyyMMdd HH:mm:ss")
            End If
        End If
        p_SQL = "delete from  tblTime"

        If g_Services.Sys_Execute(p_SQL, _
                                       p_SQL) = False Then
            'ShowMessageBox("", p_SQLErr)
        End If
        p_SQL = "insert into  tblTime (TimeDefault, FromTime,ToTime,Createdate,CreateUser)" &
            " VALUES ('" & p_Time & "','" & p_FromTime & "', '" & p_ToTime & "',getdate(), '" & g_UserName & "') "

        If g_Services.Sys_Execute(p_SQL, _
                                       p_SQL) = False Then
            'ShowMessageBox("", p_SQLErr)
        End If

        ShowStatusMessage(False, "", "Lưu thành công")
    End Sub
End Class