Public Class FrmKhachHang

    Private Sub FrmKhachHang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.GridView1.BestFitColumns()
    End Sub



    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
        Dim p_DataRow As DataRow
        Dim p_MaKhachHang As String = ""
        If Me.GridView1.RowCount > 0 Then
            p_DataRow = Me.GridView1.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then
                If p_DataRow.Item("MaKhachHang").ToString.Trim <> "" Then
                    'Dim FrmMenu As New FrmORDR
                    Dim FrmVehicleTmp As New FrmKhachHang_TD
                    p_MaKhachHang = p_DataRow.Item("MaKhachHang").ToString.Trim
                    If p_MaKhachHang <> "" Then
                        FrmVehicleTmp.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                        FrmVehicleTmp.g_XtraServicesObj = g_XtraServicesObj
                        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
                        FrmVehicleTmp.g_FormAddnew = False
                        FrmVehicleTmp.FormStatus = False
                        FrmVehicleTmp.p_XtraToolTripLabel = g_ToolStripStatus
                        FrmVehicleTmp.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                        FrmVehicleTmp.p_XtraMessageStatusl = g_MessageStatus
                        FrmVehicleTmp.P_MaKhachHangProperty = p_MaKhachHang
                        FrmVehicleTmp.ShowDialog(Me)
                    End If

                End If
            End If
        End If
    End Sub

End Class