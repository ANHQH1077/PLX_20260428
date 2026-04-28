Imports System.Security.Cryptography
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraEditors
Public Class FrmChangPass

    Private Sub save()
        Dim p_Value As Boolean = False
        Dim p_Mess_Done As String = ""
        Dim p_Mess_Err As String = ""
        Dim p_Des As String = ""
        Dim p_Header_Ins As Boolean
        Dim p_Done As String

        Dim encoder As New System.Text.UTF8Encoding()
        Dim p_PassStr_Arr As Byte()
        Dim p_PassStr As String
        Dim md5Hasher As New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim p_ENCRYPTED_USER_PASSWORD As String

        Dim p_Pass As String = ""
        Dim p_Repass As String = ""

        Dim p_Row As DataRow

        
        p_ENCRYPTED_USER_PASSWORD = ""
        If Not Me.PassWord.EditValue Is Nothing Then
            p_Pass = Me.PassWord.EditValue
        End If

        If Not Me.RePassWord.EditValue Is Nothing Then
            p_Repass = Me.RePassWord.EditValue
        End If
        If Not Me.ENCRYPTED_USER_PASSWORD.EditValue Is Nothing Then
            p_ENCRYPTED_USER_PASSWORD = Me.ENCRYPTED_USER_PASSWORD.Text.ToString
        End If
        '
        'If Me.PassWord.EditValue Is Nothing Or Me.RePassWord.EditValue Is Nothing Then
        'Else
        If p_Pass <> "" Or p_Repass <> "" Then
            ' If pv_Passchange = True Then
            Try
                If p_Pass.Trim <> p_Repass.Trim Then
                    'MsgBox("Mật khẩu không hợp lệ hoặc không giống nhau", MsgBoxStyle.Critical)
                    ShowStatusMessage(True, "", "Mật khẩu không hợp lệ hoặc không giống nhau", 10)
                    Exit Sub
                Else
                    'ENCRYPTED_USER_PASSWORD
                    Using myRijndael = Rijndael.Create()
                        p_PassStr_Arr = md5Hasher.ComputeHash(encoder.GetBytes(p_Pass))
                        p_PassStr = Convert.ToBase64String(p_PassStr_Arr)
                        p_ENCRYPTED_USER_PASSWORD = p_PassStr
                        Me.ENCRYPTED_USER_PASSWORD.EditValue = p_ENCRYPTED_USER_PASSWORD
                    End Using
                End If
            Catch ex As Exception
                'MsgBox("Mật khẩu không hợp lệ hoặc không giống nhau", MsgBoxStyle.Critical)
                ShowStatusMessage(True, "", "Mật khẩu không hợp lệ hoặc không giống nhau", 10)
                Exit Sub
            End Try
        End If
        ' End If
        If p_ENCRYPTED_USER_PASSWORD = "" And p_Pass = "" Then
            'MsgBox("Bạn chưa nhập mật khẩu")
            ShowStatusMessage(True, "", "Bạn chưa nhập mật khẩu", 10)
            Exit Sub
        End If

        Me.DefaultSave = True
        Me.Update()
        If Me.pv_TableEdit.Rows.Count <= 0 Then
            p_Row = Me.pv_TableEdit.NewRow
            p_Row.Item(0) = "SYS_USER"
            pv_TableEdit.Rows.Add(p_Row)
        End If
        UpdateToDatabase(Me, Me.ButtonSave)
        Me.DefaultSave = False
        ' e.Handled = True
        Me.PassWord.Text = ""
        Me.RePassWord.Text = ""
        Me.FormStatus = False
        ' MsgBox("Đã thực hiện xong", MsgBoxStyle.Information, "Chú ý")
        ShowStatusMessage(False, "", "Đã thực hiên xong", 10)
    End Sub
    Private Sub FrmChangPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            save()
        End If
    End Sub

    Private Sub FrmChangPass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        save()
    End Sub

    Private Sub USER_NAME_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USER_NAME.EditValueChanged

    End Sub

    Private Sub PassWord_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PassWord.EditValueChanged

    End Sub
End Class