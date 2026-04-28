Public Class FrmConfigFile
    Private p_ExistRecord As Boolean = False
    Private Sub FrmConfigFile_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            'If Me.BtnOk.Text = Me.CaptionAdd And Me.FormStatus = False Then

            '    g_FormAddnew = True
            '    Me.FormStatus = True
            '    Me.Navigator1.Buttons.DoClick(Me.Navigator1.Buttons.Append)
            '    Me.SoLenh.Focus()
            '    Me.NgayXuat.EditValue = p_DateCreate
            '    Me.FormStatus = False

            'Else
            If Me.FormStatus = True Then
                SaveRecode()
            End If
        End If
    End Sub

    Private Sub SaveRecode()
        Dim p_Value As String
        Dim p_Dess As String

        p_Value = ""
        p_Dess = ""
        If Not Me.FilePathOut.EditValue Is Nothing Then
            p_Value = Me.FilePathOut.EditValue.ToString
            If CheckFileName(False, p_Value, p_Dess) = False Then
                'ShowMessageBox("", p_Dess)
                If p_Dess = "" Then
                    ShowMessageBox("", "Thư mục không xác định")
                Else
                    ShowMessageBox("", p_Dess)
                End If
                Me.FilePathOut.Focus()
                Exit Sub
            End If
        End If

        p_Value = ""
        p_Dess = ""
        If Not Me.FilePathIn.EditValue Is Nothing Then
            p_Value = Me.FilePathIn.EditValue.ToString
            If CheckFileName(False, p_Value, p_Dess) = False Then
                'ShowMessageBox("", p_Dess)
                If p_Dess = "" Then
                    ShowMessageBox("", "Thư mục không xác định")
                Else
                    ShowMessageBox("", p_Dess)
                End If
                Me.FilePathIn.Focus()
                Exit Sub
            End If
        End If

        p_Value = ""
        p_Dess = ""
        If Not Me.FilePathTemp.EditValue Is Nothing Then
            p_Value = Me.FilePathTemp.EditValue.ToString
            If CheckFileName(True, p_Value, p_Dess) = False Then
                If p_Dess = "" Then
                    ShowMessageBox("", "File không xác định")
                Else
                    ShowMessageBox("", p_Dess)
                End If

                Me.FilePathTemp.Focus()
                Exit Sub
            End If
        End If


        Me.DefaultSave = True
        UpdateToDatabase(Me, Me.ButtonSave)
        Me.DefaultSave = False
        p_ExistRecord = True
    End Sub

    Private Sub FrmConfigFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim p_Data As DataTable
        'Dim p_SQL As String

        p_XtraUserName = g_User_ID

        'p_SQL = "select * from SYS_FOXCONFIG"

        'p_Data = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)
        'If Not p_Data Is Nothing Then
        '    If p_Data.Rows.Count > 0 Then
        '        p_ExistRecord = True
        '        Me.FilePathOut.EditValue = p_Data.Rows(0).Item("FilePathOut").ToString.Trim
        '        Me.PassFileOut.EditValue = p_Data.Rows(0).Item("PassFileOut").ToString.Trim

        '        Me.FilePathIn.EditValue = p_Data.Rows(0).Item("FilePathIn").ToString.Trim
        '        Me.PassFileIn.EditValue = p_Data.Rows(0).Item("PassFileIn").ToString.Trim


        '        Me.FilePathTemp.EditValue = p_Data.Rows(0).Item("FilePathTemp").ToString.Trim
        '        Me.PassFileTemp.EditValue = p_Data.Rows(0).Item("PassFileTemp").ToString.Trim

        '    End If

        'End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SaveRecode()
    End Sub
End Class