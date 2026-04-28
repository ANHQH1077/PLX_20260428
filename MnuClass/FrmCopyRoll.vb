Public Class FrmCopyRoll


    Public p_UseName As String = ""
    Public p_USerID As Integer = 0





    Private Sub USER_NAME_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USER_NAME.EditValueChanged

    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdThucHien.Click
        Dim p_String = ""
        Dim p_DataTable As DataTable

        If Not Me.USER_NAME.EditValue Is Nothing Then
            p_String = Me.USER_NAME.EditValue.ToString.Trim
        End If

        If p_String = "" Then
            ShowMessageBox("", "Tên User không được trống")
            Exit Sub
        End If
        p_String = "select USER_ID   from SYS_USER Where upper(USER_NAME) = upper('" & p_String & "')"
        p_DataTable = GetDataTable(p_String, p_String)
        If p_DataTable.Rows.Count > 0 Then
            p_USerID = p_DataTable.Rows(0).Item("USER_ID").ToString.Trim
            Me.Close()
        End If
    End Sub

    Private Sub FrmCopyRoll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.UserCopy.EditValue = p_UseName
    End Sub
End Class