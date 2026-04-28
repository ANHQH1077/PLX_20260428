Public Class FrmConfigReport

    Private Sub FrmConfigReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim FrmDetail As New FrmConfigReportPar
        Dim p_RptCode As String
        Dim p_SQL As String
        Dim p_Column As New U_TextBox.GridColumn

        If Not ReportCode.EditValue Is Nothing Then
            p_RptCode = ReportCode.EditValue.ToString.Trim
        End If
        FrmDetail.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmDetail.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim        
        FrmDetail.p_XtraToolTripLabel = g_ToolStripStatus
        FrmDetail.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmDetail.p_XtraMessageStatusl = g_MessageStatus
        FrmDetail.RptCode = p_RptCode
        p_Column = Me.GridView1.Columns.Item("FieldName")
        p_SQL = p_Column.SQLString
        p_SQL = p_XtraModuleObj.Parameter_Item(Me, p_SQL)
        FrmDetail.SQL_ColumnName = p_SQL
        ' FrmVehicleTmp.DefaultWhere = " WHERE MaPhuongTien=N'" & p_DataRow.Item(Me.GridView1.ColumnKey).ToString.Trim & "'"
        FrmDetail.ShowDialog(Me)
    End Sub
End Class