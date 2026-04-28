Public Class FrmVehicleDetail
    Dim _dtVariable As DataTable ' = GetDataTable(p_SQL, p_SQL)
   
    Dim _SapConnectionString As String
    Dim _WareHouse As String
    Dim _ShPoint As String
        
    Private Sub U_ButtonCus1_Click(sender As System.Object, e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_SyncMaster As SynMaster.Class1
        Dim p_Count As Integer
        Dim p_Desc As String
        Dim flag As Integer()
        Dim lw_mess As String()
        Dim g_dt = New DataTable()
        Dim p_MaPTien As String = ""
        Dim p_SQL, p_PTienAo As String

        If Not Me.U_TextBox1.EditValue Is Nothing Then
            p_MaPTien = Me.U_TextBox1.EditValue.ToString.Trim
        End If

        If p_MaPTien = "" Then
            Exit Sub
        End If

        Dim p_Table As DataTable


        p_PTienAo = ""
        p_SQL = "select KeyValue from sys_config where keycode ='PTIEN_AO'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_PTienAo = p_Table.Rows(0).Item("KeyValue").ToString.Trim
            End If
        End If


        If InStr(p_PTienAo, p_MaPTien, CompareMethod.Text) > 0 Then
            ShowMessageBox("", "Phương tiện không hợp lệ")
            Exit Sub
        End If


        p_ValueMess = p_XtraModuleObj.ShowMessage(Me, "", _
                                                 "Bạn có muốn đồng bộ phương tiện này không? ", _
                                                    True, _
                                                     "Có", _
                                                    True, _
                                                    "Không", _
                                                    False, _
                                                    "", _
                                                     0)
        If p_ValueMess = Windows.Forms.DialogResult.Yes Then
            Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
            'Dim p_Table As DataTable
            Dim p_ConnectSapString, p_TimeOut As String
            Dim p_TableLine, p_TableHeader As DataTable
            p_SQL = "select * from tblConfig "
            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    p_ConnectSapString = p_Table.Rows(0).Item("SapConnectionString").ToString.Trim
                    Try
                        p_TimeOut = p_Table.Rows(0).Item("Timeout").ToString.Trim
                    Catch ex As Exception
                    End Try

                    If p_TimeOut = "" Then
                        p_TimeOut = "60"
                    End If
                End If
            End If
            p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)

            If p_ECCDestinationConfig.clsSyncVEHICLE("20090101", p_MaPTien, p_Desc, p_TableLine, p_TableHeader, "H") = True Then

                'p_SQL = "delete from tblChiTietPhuongTien"
                'If g_Services.Sys_Execute(p_SQL, _
                '                 p_SQL) = False Then
                '    ShowMessageBox("", p_SQL)
                'End If

                p_SQL = ""
                If DataTableRunExecBigData(p_TableHeader, p_SQL) = False Then
                    ShowMessageBox("", p_SQL, 3)
                    Exit Sub
                End If

                p_SQL = ""
                If DataTableRunExecBigData(p_TableLine, p_SQL) = False Then
                    ShowMessageBox(True, p_SQL, 3)
                    Exit Sub
                End If

                p_SQL = "update tblPhuongTien set SoNgan = 	(select Count(1) from tblChiTietPhuongTien  kk where kk.MaPhuongTien =tblPhuongTien.MaPhuongTien and isnull(MaNgan,'') <> ''  ) "
                If g_Services.Sys_Execute(p_SQL, _
                                 p_SQL) = False Then
                    ShowMessageBox("", p_SQL)
                End If


            End If
            ShowMessageBox("", "Đã thực hiện xong", 1)
            'Exit Sub
            'p_SyncMaster = New SynMaster.Class1(g_WCF, g_Services, flag, lw_mess, "H", _
            '                    g_dt, _SapConnectionString, _WareHouse, _dtVariable, g_Company_Code, _ShPoint)
            'If p_SyncMaster.ClsSyncMaster_SyncVehicleDownNew(p_MaPTien, p_Count, p_Desc, g_UserName) = False Then
            '    ShowMessageBox("", p_Desc)
            '    Exit Sub
            'End If
            'If p_Count = 0 Then
            '    ShowMessageBox("", "Không có phương tiện đồng bộ")

            '    Exit Sub

            'Else
            '    ShowMessageBox("", "Đã thực hiện xong", 1)

            '    Exit Sub
            'End If
        End If
    End Sub

    Private Sub FrmVehicleDetail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        p_SQL = "select * from tblConfig"
        _dtVariable = GetDataTable(p_SQL, p_SQL)
        If Not _dtVariable Is Nothing Then
            If _dtVariable.Rows.Count > 0 Then
                _SapConnectionString = _dtVariable.Rows(0).Item("sapconnectionstring").ToString.Trim
                _WareHouse = _dtVariable.Rows(0).Item("WareHouse").ToString.Trim
                _ShPoint = _dtVariable.Rows(0).Item("shippingpoint").ToString.Trim
            End If
        End If
    End Sub
End Class