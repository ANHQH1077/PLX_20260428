Public Class FrmTankCer_QL

    Private Sub U_ButtonCus2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus2.Click
        Dim p_FrmVehicleCerAdd As New FrmTankCerAdd("")
        p_FrmVehicleCerAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        p_FrmVehicleCerAdd.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim        
        p_FrmVehicleCerAdd.p_XtraToolTripLabel = g_ToolStripStatus
        p_FrmVehicleCerAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        p_FrmVehicleCerAdd.p_XtraMessageStatusl = g_MessageStatus
        'p_TrangThai = p_FrmXacNhanThucXuat.p_Status
        p_FrmVehicleCerAdd.ShowDialog(Me)
    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_Where As String = ""
        Dim p_Values As String = ""
        p_Values = "20000101"
        If Not Me.TuNgay.EditValue Is Nothing Then
            p_Values = CDate(Me.TuNgay.EditValue).ToString("yyyyMMdd HH:mm:ss")
        End If
        p_Where = "NgayKTNhap>='" & p_Values & "' "
        p_Values = "20400101"
        If Not Me.TuNgay.EditValue Is Nothing Then
            p_Values = CDate(Me.DenNgay.EditValue).ToString("yyyyMMdd HH:mm:ss")
        End If
        p_Where = p_Where & " and  NgayKTNhap<='" & p_Values & "' "

        p_Values = ""
        If Not Me.MaBe.EditValue Is Nothing Then
            If Me.MaBe.EditValue.ToString.Trim <> "" Then
                p_Values = Me.MaBe.EditValue.ToString.Trim
                p_Where = p_Where & " and  SoBon='" & p_Values & "' "

            End If
        End If
        Me.GridView2.Where = p_Where
        ''Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        ''Me.DefaultFormLoad = False


    End Sub

    Private Sub FrmVehicleCer_QL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_column As U_TextBox.GridColumn

        p_column = Me.GridView2.Columns.ColumnByName("GridColumn12")

        Dim p_ColTypeButtonEdit As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        p_ColTypeButtonEdit = p_column.ColumnEdit
        AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click

    End Sub

    Public Sub Column_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_DataRow As DataRow
        Dim p_maPhuongTien As String = ""
        Dim p_SoTichKe As String = ""
        Dim p_NgayXuat As String = ""
        Dim p_FormRequestCode As String
        p_DataRow = Me.GridView2.GetFocusedDataRow
        If Not p_DataRow Is Nothing Then
            p_maPhuongTien = p_DataRow.Item("MaPhuongTien").ToString.Trim
            p_SoTichKe = p_DataRow.Item("SoTichKe").ToString.Trim
            p_FormRequestCode = p_DataRow.Item("FormRequestCode").ToString.Trim
            p_NgayXuat = CDate(p_DataRow.Item("NgayXuat")).ToString("yyyyMMdd")
            ' ShowMessageBox("", "")
        End If

    End Sub
End Class