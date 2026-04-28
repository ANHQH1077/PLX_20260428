Public Class FrmMapcpLine

    Private Sub FrmMapcpLine_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            If Me.FormStatus = True Then
                SaveRecode()
            End If
        End If
    End Sub

    Sub SaveRecode()
        Dim p_IP As String = ""
        Dim p_DB As String = ""
        Dim p_User As String = ""
        Dim p_Pass As String = ""
        Dim p_STT As Integer = 0
        Dim p_ValueBo As String
        Dim p_ValueThuy As String
        Try
            p_STT = Me.STT.EditValue.ToString.Trim

            If Not Me.ServerScada.EditValue Is Nothing Then
                p_IP = Me.ServerScada.EditValue.ToString.Trim
            End If
            If Not Me.DatabaseScada.EditValue Is Nothing Then
                p_DB = Me.DatabaseScada.EditValue.ToString.Trim
            End If

            If Not Me.UidScada.EditValue Is Nothing Then
                p_User = Me.UidScada.EditValue.ToString.Trim
            End If

            If Not Me.PwdScada.EditValue Is Nothing Then
                p_Pass = Me.PwdScada.EditValue.ToString.Trim
            End If



            If p_IP = "" Or p_DB = "" Or p_User = "" Or p_Pass = "" Then
                ShowMessageBox("", "Thông tin kết nối chưa đầy đủ")
                Exit Sub

            End If
            p_IP = "Server=" & p_IP & ";Database=" & p_DB & ";User ID=" & p_User & ";Password=" & p_Pass & ";Trusted_Connection=False;"
            Me.SqlScadaConnectionString.EditValue = p_IP

            p_ValueBo = ""
            If Not Me.FlagBo.EditValue Is Nothing Then
                p_ValueBo = Me.FlagBo.EditValue
            End If
            p_ValueThuy = ""
            If Not Me.FlagThuy.EditValue Is Nothing Then
                p_ValueThuy = Me.FlagThuy.EditValue
            End If
            Me.Flag.EditValue = p_ValueBo & "." & p_ValueThuy

            p_ValueBo = ""
            If Not Me.FlagFinishBo.EditValue Is Nothing Then
                p_ValueBo = Me.FlagFinishBo.EditValue
            End If
            p_ValueThuy = ""
            If Not Me.FlagFinishThuy.EditValue Is Nothing Then
                p_ValueThuy = Me.FlagFinishThuy.EditValue
            End If
            Me.FlagFinish.EditValue = p_ValueBo & "." & p_ValueThuy


            'Me.DefaultWhere = "STT=" & p_STT
            Me.DefaultSave = True
            UpdateToDatabase(Me, Me.ButtonSave)
            Me.DefaultSave = False
            'Me.DefaultWhere = ""

        Catch ex As Exception
            p_XtraModuleObj.ModErrExceptionNew(Err.Number, ex.Message)
        End Try
    End Sub

    Private Sub FrmMapcpLine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        p_XtraUserName = g_User_ID
    End Sub

    Private Sub TableName_Thuy_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableName_Thuy.EditValueChanged

    End Sub

    Private Sub STT_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STT.EditValueChanged
        Dim p_Value As String
        Dim p_ValueThuy As String
        Dim p_Tmp As String
        Dim p_ArrValue(2) As String
        p_Value = ""
        p_ValueThuy = ""
        p_Tmp = ""
        If Not Me.Flag.EditValue Is Nothing Then
            p_Tmp = Me.Flag.EditValue
            If p_Tmp.ToString.Trim <> "" Then
                p_ArrValue = p_Tmp.Split(".")
                p_Value = p_ArrValue(0)
                p_ValueThuy = p_ArrValue(1)
            End If
        End If
        Me.FlagBo.EditValue = p_Value
        Me.FlagThuy.EditValue = p_ValueThuy

        p_Value = ""
        p_ValueThuy = ""
        p_Tmp = ""
        If Not Me.FlagFinish.EditValue Is Nothing Then
            p_Tmp = Me.FlagFinish.EditValue
            If p_Tmp.ToString.Trim <> "" Then
                p_ArrValue = p_Tmp.Split(".")
                p_Value = p_ArrValue(0)
                p_ValueThuy = p_ArrValue(1)
            End If
        End If
        Me.FlagFinishBo.EditValue = p_Value
        Me.FlagFinishThuy.EditValue = p_ValueThuy
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        SaveRecode()
    End Sub

    Private Sub FlagFinishThuy_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlagFinishThuy.EditValueChanged

    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        'Dim FrmMenu As New FrmORDR
        Dim FrmVehicleTmp As New FrmHangHoa_Map
        FrmVehicleTmp.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmVehicleTmp.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
        FrmVehicleTmp.g_FormAddnew = False
        FrmVehicleTmp.FormStatus = False
        FrmVehicleTmp.p_XtraToolTripLabel = g_ToolStripStatus
        FrmVehicleTmp.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmVehicleTmp.p_XtraMessageStatusl = g_MessageStatus
        ' FrmVehicleTmp.DefaultWhere = " WHERE MaPhuongTien=N'" & p_DataRow.Item(Me.GridView1.ColumnKey).ToString.Trim & "'"
        FrmVehicleTmp.ShowDialog(Me)

    End Sub
End Class