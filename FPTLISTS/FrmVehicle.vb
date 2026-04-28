Public Class FrmVehicle

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
        Dim p_DataRow As DataRow

        If Me.GridView1.RowCount > 0 Then
            p_DataRow = Me.GridView1.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then
                If p_DataRow.Item(Me.GridView1.ColumnKey).ToString.Trim <> "" Then
                    'Dim FrmMenu As New FrmORDR
                    Dim FrmVehicleTmp As New FrmVehicleAdd
                    FrmVehicleTmp.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                    FrmVehicleTmp.g_XtraServicesObj = g_XtraServicesObj
                    'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
                    FrmVehicleTmp.g_FormAddnew = False
                    FrmVehicleTmp.FormStatus = False
                    FrmVehicleTmp.p_XtraToolTripLabel = g_ToolStripStatus
                    FrmVehicleTmp.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                    FrmVehicleTmp.p_XtraMessageStatusl = g_MessageStatus
                    FrmVehicleTmp.DefaultWhere = " WHERE MaPhuongTien=N'" & p_DataRow.Item(Me.GridView1.ColumnKey).ToString.Trim & "'"
                    FrmVehicleTmp.ShowDialog(Me)
                End If
            End If
        End If
    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim FrmVehicleTmp As New FrmVehicleAdd
        FrmVehicleTmp.p_XtraModuleObj = p_XtraModuleObj
        FrmVehicleTmp.g_XtraServicesObj = g_XtraServicesObj
        FrmVehicleTmp.g_FormAddnew = True
        FrmVehicleTmp.FormStatus = False
        FrmVehicleTmp.p_XtraToolTripLabel = g_ToolStripStatus
        FrmVehicleTmp.p_XtraMessageStatusl = g_MessageStatus
        FrmVehicleTmp.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmVehicleTmp.DefaultWhere = " WHERE MaPhuongTien=N''"
        FrmVehicleTmp.ShowDialog(Me)
    End Sub

    Private Sub GridView1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridView1.KeyPress

    End Sub

    Private Sub FrmVehicle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        p_XtraUserName = g_User_ID
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_LaiNgay As Boolean
        Dim p_Col As U_TextBox.GridColumn

        If g_Company_Code = "6610" Then
            'NgayBatDau1
            'NgayHieuLuc1
            p_Col = Me.GridView1.Columns.Item(6)
            p_Col.FieldView = "NgayBatDau2"
            p_Col = Me.GridView1.Columns.Item(7)
            p_Col.FieldView = "NgayHieuLuc2"
        End If
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False

        p_SQL = "select * from SYS_USER where USER_ID=" & g_User_ID
       
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        

        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                If p_DataTable.Rows(0).Item("Vehicle_Add").ToString.Trim = "Y" Then
                    U_ButtonCus1.Visible = True
                End If
            End If

        End If

        p_SQL = "select * from SYS_CONFIG where KeyCode='LAINGAY'"

        p_DataTable = GetDataTable(p_SQL, p_SQL)


        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                If p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    U_ButtonCus2.Visible = True
                End If
            End If

        End If


    End Sub

    Private Sub U_ButtonCus2_Click(sender As System.Object, e As System.EventArgs) Handles U_ButtonCus2.Click
        Dim FrmVehicleTmp As New FrmLaiXe
        FrmVehicleTmp.p_XtraModuleObj = p_XtraModuleObj
        FrmVehicleTmp.g_XtraServicesObj = g_XtraServicesObj
        FrmVehicleTmp.g_FormAddnew = True
        FrmVehicleTmp.FormStatus = False
        FrmVehicleTmp.p_XtraToolTripLabel = g_ToolStripStatus
        FrmVehicleTmp.p_XtraMessageStatusl = g_MessageStatus
        FrmVehicleTmp.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        'FrmVehicleTmp.DefaultWhere = " WHERE MaPhuongTien=N''"
        FrmVehicleTmp.ShowDialog(Me)
    End Sub

    Private Sub U_ButtonCus3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus3.Click
        Dim FrmVehicleTmp As New FrmVehicleDetail

        FrmVehicleTmp.p_XtraModuleObj = p_XtraModuleObj
        FrmVehicleTmp.g_XtraServicesObj = g_XtraServicesObj
        FrmVehicleTmp.g_FormAddnew = True
        FrmVehicleTmp.FormStatus = False
        FrmVehicleTmp.p_XtraToolTripLabel = g_ToolStripStatus
        FrmVehicleTmp.p_XtraMessageStatusl = g_MessageStatus
        FrmVehicleTmp.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        'FrmVehicleTmp.DefaultWhere = " WHERE MaPhuongTien=N''"
        FrmVehicleTmp.ShowDialog(Me)
    End Sub
End Class