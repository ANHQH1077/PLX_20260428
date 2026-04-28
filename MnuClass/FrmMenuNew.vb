Public Class FrmMenuNew
    

    Private Sub FrmFormNew_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        'If e.KeyChar <> "" Or Asc(e.KeyChar) = 32 Then
        '    If p_Commit = True Then Exit Sub
        '    If p_Commit = False Then
        '        p_Commit = True
        '        pv_Header_Status = pv_UPD_KEY
        '        Me.BtnOk.Text = "Update"
        '    End If
        'End If
    End Sub
    Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        'If Me.MENU_CODE.EditValue.ToString = "" Then

        '    ' MsgBox("Mãme")
        'Else
        '    p_TrueGirdLineAdd(Me.GridView1.RowCount - 1) = True
        '    Me.GridView1.SetRowCellValue(e.RowHandle, "WORK_STATION", g_GetHostName)
        '    Me.GridView1.SetRowCellValue(e.RowHandle, "IP_ADDRESS", g_IP_Address)
        '    Me.GridView1.SetRowCellValue(e.RowHandle, "MENU_CODE", Me.MENU_CODE.EditValue.ToString)
        '    p_Commit = True
        '    'pv_Header_Status = pv_INS_KEY
        '    If pv_Header_Status = "" Then
        '        pv_Header_Status = pv_UPD_KEY
        '    End If
        '    Me.BtnOk.Text = "Update"
        'End If

    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        'Dim p_FormID As Integer
        'Dim p_Row() As DataRow
        'If e.Column.FieldName = "FUNCTION_NAME" Then
        '    p_Row = p_Form_List.Select("FUNCTION_NAME='" & Me.GridView1.GetRowCellValue(e.RowHandle, "FUNCTION_NAME").ToString & "'")
        '    If p_Row.Length > 0 Then
        '        p_FormID = p_Row(0).Item("FUNCTION_ID").ToString
        '        Me.GridView1.SetRowCellValue(e.RowHandle, "FUNCTION_ID", p_FormID)
        '    End If
        'End If
    End Sub


    Private Sub FrmMenuNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DefaultFormLoad = True
        Me.Form1_Load(sender, e)

        If g_FormAddnew = True Then
            Me.MENU_CODE.Focus()
        End If
        If UCase(g_UserName) <> "SYSADMIN" Then
            Me.FormEdit = False
            Me.GridView1.OptionsBehavior.ReadOnly = True
        End If
    End Sub


    

    Private Sub MENU_CODE_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MENU_CODE.EditValueChanged
        'Dim p_FptModule As New FPTModule.Class1(g_UserName, "", g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_User_Database)
        'If Not Me.MENU_CODE.EditValue Is Nothing Then
        '    If p_FptModule.p_Mod_Set_TrueGrid_Property(Me, p_DataSet_TrueGird, p_BindingSourceLine, _
        '                                            Me.U_TrueDBGrid1, Me.GridView1, False, True, "MENU_CODE='" & Me.MENU_CODE.EditValue.ToString & "'") = False Then
        '        'GoTo Line_Err
        '        MsgBox("Lỗi khi thực hiện")
        '    End If



        '    If pv_Header_Status = pv_INS_KEY Then
        '        If p_FptModule.p_ModControl_UpdateIfNull(Me, True) = False Then
        '            MsgBox("Lỗi khi thực hiện")
        '        End If
        '    Else
        '        If p_FptModule.p_ModControl_UpdateIfNull(Me, False) = False Then
        '            MsgBox("Lỗi khi thực hiện")
        '        End If
        '    End If

        '    p_FptModule = Nothing
        'End If

        'p_FptModule = Nothing
    End Sub



    Private Sub MENU_ID_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim p_FptModule As New FPTModule.Class1(g_UserName, "", g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_User_Database)
        'If p_FptModule.p_ModControl_UpdateIfNull(Me) = False Then
        '    MsgBox("Lỗi khi thực hiện")
        'End If
        'p_FptModule = Nothing
    End Sub

End Class