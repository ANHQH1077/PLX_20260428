Public Class FrmGiaoNhan
    Private p_GiaoNhanHH As Boolean = False
    Private Sub FrmGiaoNhan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String = ""
        Dim p_Table As DataTable
        p_SQL = "select * from SYS_CONFIG  where upper( KeyCode) =upper('GiaoNhanHH')"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("KeyValue").ToString.Trim = "Y" Then
                    p_GiaoNhanHH = True
                End If
            End If
        End If
    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
        Dim p_Row As DataRow
        Dim p_MaTuyenDuong As String = ""
        If p_GiaoNhanHH = False Then
            Exit Sub
        End If
        If Me.GridView1.RowCount > 0 Then
            p_Row = Me.GridView1.GetDataRow(Me.GridView1.FocusedRowHandle)
            If Not p_Row Is Nothing Then
                If p_Row.Item("MaTuyenDuong").ToString.Trim <> "" Then
                    p_MaTuyenDuong = p_Row.Item("MaTuyenDuong")
                End If
                
            End If
            If p_MaTuyenDuong <> "" Then
                Dim FrmATG As New FrmGiaoNhanHH
                FrmATG.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                FrmATG.g_XtraServicesObj = g_XtraServicesObj
               
                FrmATG.p_XtraToolTripLabel = g_ToolStripStatus
                FrmATG.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                FrmATG.p_XtraMessageStatusl = g_MessageStatus
                FrmATG.g_MaTuyenDuong = p_MaTuyenDuong
                FrmATG.ShowDialog(Me)
            End If
        End If

    End Sub
End Class