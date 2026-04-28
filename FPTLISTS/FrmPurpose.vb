Public Class FrmPurpose

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        Dim p_DataExec As New DataTable("tbl001")
        Dim flag() As Integer
        Dim g_dt As DataTable
        Dim p_Table As DataTable
        Dim lw_mess() As String
        Dim _SapConnectionString As String
        Dim _WareHouse As String
        Dim _dtVariable As DataTable
        Dim _ShPoint As String
        Dim p_SQL As String
        Dim l_date As String = ""
        Dim p_Desc As String
        Dim l_Time As String = ""
        p_SQL = "select getdate()  from tblConfig"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                l_date = CDate(p_Table.Rows(0).Item(0)).ToString("yyyy.MM.dd")
                l_Time = CDate(p_Table.Rows(0).Item(0)).ToString("hh:mm:ss")
            End If
        End If
        p_SQL = "select * from tblConfig"
        _dtVariable = GetDataTable(p_SQL, p_SQL)
        If Not _dtVariable Is Nothing Then
            If _dtVariable.Rows.Count > 0 Then
                _SapConnectionString = _dtVariable.Rows(0).Item("sapconnectionstring").ToString.Trim
                _WareHouse = _dtVariable.Rows(0).Item("WareHouse").ToString.Trim
                _ShPoint = _dtVariable.Rows(0).Item("shippingpoint").ToString.Trim
            End If
        End If


        p_DataExec.Columns.Add("Str_SQL")
        Dim p_SyncMaster As New SynMaster.Class1(g_WCF, g_Services, flag, lw_mess, "H", _
                  g_dt, _SapConnectionString, _WareHouse, _dtVariable, g_Company_Code, _ShPoint, g_UserName)
        If p_SyncMaster.ClsSyncMaster_SyncPurpose_ATG(p_DataExec, "A", l_date, _WareHouse, p_Desc, l_Time) = True Then
            If Not p_DataExec Is Nothing Then
                If p_DataExec.Rows.Count > 0 Then
                    p_SQL = ""
                    If DataTableRunExecBigData(p_DataExec, p_SQL) = False Then
                        ShowMessageBox("", p_SQL)
                        Exit Sub
                    End If
                    Me.DefaultFormLoad = True
                    Me.LoadDataToForm()
                    Me.DefaultFormLoad = False
                    ShowMessageBox("", "Đã thực hiện xong", 1)
                End If
            End If
        End If

    End Sub
End Class