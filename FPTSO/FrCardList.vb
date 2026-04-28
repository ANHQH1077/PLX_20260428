Public Class FrCardList

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Me.DefaultSave = True

        Me.UpdateToDatabase(Me)
        Me.DefaultSave = False
        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim p_DataRow As DataRow
        If Me.FormStatus = True Then
            ShowMessageBox("", "Bản ghi chưa được l")
            Exit Sub
        End If
        If Me.GridView1.RowCount > 0 Then
            p_DataRow = Me.GridView1.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then
                If p_DataRow.Item("CardNum").ToString.Trim = "" Then
                    ShowMessageBox("", "Số thẻ không đúng")
                    Exit Sub
                End If
                Dim FrmATG As New FrCardList_Hist
                FrmATG.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                FrmATG.g_XtraServicesObj = g_XtraServicesObj
                FrmATG.p_XtraToolTripLabel = g_ToolStripStatus
                FrmATG.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                FrmATG.p_XtraMessageStatusl = g_MessageStatus
                FrmATG.StrNumber = p_DataRow.Item("CardNum").ToString.Trim
                FrmATG.ShowDialog(Me)
            End If

        End If
    End Sub

    Private Sub FrCardList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim FrmLenhXuatAdd As New FrCardAdd
        FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim        
        FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
        FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
        FrmLenhXuatAdd.p_GridView = Me.GridView1
        FrmLenhXuatAdd.ShowDialog(Me)
      
    End Sub
End Class