Public Class FrmUserQLvb

    Private Sub FrmUserQLvb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String

        p_SQL = "USER_NAME not like 'SYSADMIN%' and USER_NAME not like 'sysadmin%'"
        If UCase(g_UserName) = "SYSADMIN" Then
            p_SQL = ""
        End If
        Me.GridView1.Where = p_SQL
        Me.DefaultFormLoad = True
        Me.Form1_Load(sender, e)

        Me.DefaultFormLoad = False
        Me.GridView1.BestFitColumns()
    End Sub

    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
        Dim p_DataRow As DataRow

        If Me.GridView1.RowCount > 0 Then
            p_DataRow = Me.GridView1.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then
                If p_DataRow.Item(Me.GridView1.ColumnKey).ToString.Trim <> "" Then
                    'Dim FrmMenu As New FrmORDR
                    Dim FrmMenu As New FrmUsers
                    FrmMenu.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                    FrmMenu.g_XtraServicesObj = g_XtraServicesObj
                    'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
                    FrmMenu.g_FormAddnew = False
                    FrmMenu.FormStatus = False
                    FrmMenu.p_XtraToolTripLabel = g_ToolStripStatus
                    FrmMenu.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                    FrmMenu.p_XtraMessageStatusl = g_MessageStatus
                    FrmMenu.DefaultWhere = "  USER_ID=" & p_DataRow.Item(Me.GridView1.ColumnKey).ToString.Trim
                    FrmMenu.ShowDialog(Me)
                End If
            End If
        End If

    End Sub

    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        'Dim FrmMenu As New FrmORDR
        Dim FrmMenu As New FrmUsers
        FrmMenu.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmMenu.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
        FrmMenu.g_FormAddnew = True
        FrmMenu.FormStatus = False
        FrmMenu.p_XtraToolTripLabel = g_ToolStripStatus
        FrmMenu.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmMenu.p_XtraMessageStatusl = g_MessageStatus
        FrmMenu.DefaultWhere = " WHERE USER_ID=-1"
        FrmMenu.p_FormQL = Me
        FrmMenu.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SaveRecord()
    End Sub
    Private Sub SaveRecord()
        '  If Asc(e.KeyChar) = 19 Then
        Me.DefaultSave = True
        Me.UpdateToDatabase(Me, "")
        Me.DefaultSave = False
        '   End If
    End Sub

    Private Sub TrueDBGrid1_Click(sender As System.Object, e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub
End Class