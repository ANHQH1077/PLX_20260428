Public Class FrmHangHoa_Map

    Private Sub FrmHangHoa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Me.DefaultSave = True
        Me.UpdateToDatabase(Me)
        Me.DefaultSave = False
    End Sub

    Private Sub U_ButtonCus2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus2.Click
        Dim FrmATG As New FrmHangHoaE5

        FrmATG.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmATG.g_XtraServicesObj = g_XtraServicesObj

        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim

        ' FrmLenhXuatAdd.READ_ONLY = Me.READ_ONLY

        FrmATG.p_XtraToolTripLabel = g_ToolStripStatus
        FrmATG.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmATG.p_XtraMessageStatusl = g_MessageStatus
        FrmATG.ShowDialog(Me)

    End Sub
End Class