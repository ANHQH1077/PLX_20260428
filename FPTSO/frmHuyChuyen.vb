Public Class frmHuyChuyen
    Public g_FormTK As Object
    Private Sub U_ButtonCus1_Click(sender As System.Object, e As System.EventArgs) Handles U_ButtonCus1.Click
        Me.Close()
    End Sub

    Private Sub U_ButtonCus3_Click(sender As System.Object, e As System.EventArgs) Handles U_ButtonCus3.Click
        Dim p_SQL As String = "exec FPT_DeleteDataSMO "
        Dim p_Phuongtien As String = ""
        Dim p_SoChuyen As String
        Dim p_Datatable As DataTable
        Dim p_Message As String = ""
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_SoLenh, p_LoaiHinhVanChuyen As String
        If Not Me.pTien.EditValue Is Nothing Then
            p_Phuongtien = Me.pTien.EditValue.ToString.Trim
        End If
        If Not Me.ID.EditValue Is Nothing Then
            p_SoChuyen = Me.ID.EditValue.ToString.Trim
        End If
        If p_Phuongtien = "" Or p_SoChuyen = "" Then
            ShowMessageBox("", "Phương tiện không hợp lệ")
            Exit Sub
        End If


        'Dim p_ValueMess As Windows.Forms.DialogResult
        p_ValueMess = g_Module.ShowMessage(Me, "", _
                        "Bạn có chắn chắn muốn hủy không?", _
                        True, _
                         "Có", _
                        True, _
                        "Không", _
                        False, _
                        "", _
                         0)
                    
        If p_ValueMess = Windows.Forms.DialogResult.No Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        'p_SQL = " select  SoLenh from tbllenhxuate5 where isnull(SMO_ID,0) = " & p_SoChuyen
        'p_Datatable = GetDataTable(p_SQL, p_SQL)
        'p_SoLenh = ""
        'p_LoaiHinhVanChuyen = ""
        'If Not p_Datatable Is Nothing Then

        '    If p_Datatable.Rows.Count > 0 Then
        '        Dim p_TableExec As New DataTable("EXE01")
        '        Dim p_DataRow As DataRow
        '        Dim p_Count As Integer
        '        p_TableExec.Columns.Add("STR_SQL")
        '        For p_Count = 0 To 

        '            p_SoLenh = p_Datatable.Rows(0).Item("SoLenh").ToString.Trim
        '            '  p_LoaiHinhVanChuyen = p_Datatable.Rows(0).Item("MaVanChuyen").ToString.Trim
        '            p_DataRow = p_TableExec.NewRow
        '            p_SQL = "delete from tblLenhXuatChiTietE5  where " & _
        '                " exists (select 1 from tblLenhXuat_HangHoaE5  where tableid=  tblLenhXuatChiTietE5.tableid " & _
        '                     " and SoLenh='" & p_SoLenh & "')"
        '            p_DataRow.Item(0) = p_SQL
        '            p_TableExec.Rows.Add(p_DataRow)
        '            p_DataRow = p_TableExec.NewRow
        '            p_SQL = "delete from tblLenhXuat_HangHoaE5  where SoLenh='" & p_SoLenh & "'"
        '            p_DataRow.Item(0) = p_SQL
        '            p_TableExec.Rows.Add(p_DataRow)
        '            p_DataRow = p_TableExec.NewRow
        '            p_SQL = "delete from tblLenhXuatE5  where SoLenh='" & p_SoLenh & "'"
        '            p_DataRow.Item(0) = p_SQL
        '            p_TableExec.Rows.Add(p_DataRow)

        '    End If
        'End If
        'If p_SoLenh <> "" Then
        '    p_Message = Scadar_HuyTichKe(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, g_Terminal)
        '    If p_Message.ToString.Trim <> "" Then
        '        ShowMessageBox("", p_Message)
        '        Exit Sub
        '    End If
        'End If
        'ShowStatusMessage(False, "", "Đã thực hiện xong")
        'g_FormTK.RefreshButton()


        'Exit Sub


        p_SQL = "exec FPT_DeleteDataSMO  '" & p_Phuongtien & "','" & g_UserName & "'," & p_SoChuyen
        p_Datatable = GetDataTable(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                If p_Datatable.Rows(0).Item("Error") = 0 Then
                    ShowStatusMessage(False, "", "Đã thực hiện xong")
                    g_FormTK.RefreshButton()
                Else
                    ShowStatusMessage(True, "", p_Datatable.Rows(0).Item("sError"))
                End If
            End If

        End If
    End Sub

    Private Sub frmHuyChuyen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.NgayVaoKho.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss "
        NgayVaoKho.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss "
        NgayVaoKho.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        NgayVaoKho.Properties.EditMask = "dd/MM/yyyy HH:mm:ss "

        NgayVaoKho.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss "
        NgayVaoKho.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss "
        NgayVaoKho.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        NgayVaoKho.Properties.EditMask = "dd/MM/yyyy HH:mm:ss "

        NgayVaoKho.Properties.Mask.UseMaskAsDisplayFormat = True

        '      Me.Left = g_FormTK.left
        '      Me.Top = g_FormTK.top + g_FormTK.Height - Me.Height
    End Sub
End Class