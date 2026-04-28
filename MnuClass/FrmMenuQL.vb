Public Class FrmMenuQL

    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
        Dim p_DataRow As DataRow

        If Me.GridView1.RowCount > 0 Then
            p_DataRow = Me.GridView1.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then
                If p_DataRow.Item(Me.GridView1.ColumnKey).ToString.Trim <> "" Then
                    'Dim FrmMenu As New FrmORDR
                    Dim FrmMenu As New FrmMenuNew
                    FrmMenu.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                    FrmMenu.g_XtraServicesObj = g_XtraServicesObj
                    'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
                    FrmMenu.g_FormAddnew = False
                    FrmMenu.FormStatus = False
                    FrmMenu.p_XtraToolTripLabel = g_ToolStripStatus
                    FrmMenu.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                    FrmMenu.p_XtraMessageStatusl = g_MessageStatus
                    FrmMenu.DefaultWhere = " WHERE MENU_ID=" & p_DataRow.Item(Me.GridView1.ColumnKey).ToString.Trim
                    FrmMenu.ShowDialog(Me)
                End If
            End If
        End If

    End Sub

    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim FrmMenu As New FrmMenuNew
        FrmMenu.p_XtraModuleObj = p_XtraModuleObj
        FrmMenu.g_XtraServicesObj = g_XtraServicesObj
        FrmMenu.g_FormAddnew = True
        FrmMenu.FormStatus = False
        FrmMenu.p_XtraToolTripLabel = g_ToolStripStatus
        FrmMenu.p_XtraMessageStatusl = g_MessageStatus
        FrmMenu.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmMenu.DefaultWhere = " WHERE MENU_ID=0"
        FrmMenu.ShowDialog(Me)
    End Sub

    Private Sub FrmMenuQL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String = ""
        If UCase(g_UserName) <> "SYSADMIN" Then

            p_SQL = " upper(MENU_CODE)<>'MNUHT'"
            Me.GridView1.Where = p_SQL
            
        End If
        Me.DefaultFormLoad = True
        Me.XtraForm1_Load()
        Me.DefaultFormLoad = False
    End Sub

    

   
End Class