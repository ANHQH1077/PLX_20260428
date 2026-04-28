Public Class FrmUpdate

    Private Sub FrmUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        p_SQL = "not exists (select 1 from SYS_VERSION_HIST b where " & _
                "b.FileName = FPT_SYS_VERSION.FileName " & _
                 "and b.FileMajor=FPT_SYS_VERSION.FileMajor " & _
                 "and b.FileMinor=FPT_SYS_VERSION.FileMinor " & _
                 "and b.FileBuild=FPT_SYS_VERSION.FileBuild " & _
                 "and b.FileRevision=FPT_SYS_VERSION.FileRevision	 " & _
                 "and upper(PC_Name)=upper('" & g_GetHostName & "'))"
        Me.GridView1.Where = p_SQL
        Me.DefaultFormLoad = True
        Me.Form1_Load(sender, e)
        Me.DefaultFormLoad = False
        If Me.GridView1.RowCount <= 0 Then
            ' Me.Close()
        End If
    End Sub

    Private Sub UpdateFile()
        Dim p_DataTable As DataTable
        Dim p_Count As Integer
        Dim p_Row As DataRow
        Dim p_FromFile As String
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_Err As String
        Dim p_DtbExec As New DataTable("Table0")
        Dim p_Insert As String
        Dim p_Exists As Integer = 0
        p_DtbExec.Columns.Add("STR_SQL")

        Dim p_toFilePath As String   '= p_toDirectoryFilePath & "\" & p_DataTable.Rows(p_Count).Item("FileName").ToString.Trim
        Try
            Cursor = Cursors.WaitCursor

            Me.GridView1.UpdateCurrentRow()
            'Me.GridView1.MoveLast()
            ' Me.GridView1.MoveFirst()
            ' Me.GridView1.Columns.Item(0).

            p_Binding = Me.GridView1.DataSource
            p_toFilePath = Application.StartupPath

            p_DataTable = CType(p_Binding.DataSource, DataTable)
            For p_Count = 0 To Me.GridView1.RowCount - 1
                p_Row = Me.GridView1.GetDataRow(p_Count)
                If p_Row.Item("X").ToString.Trim = "Y" Then
                    p_Exists = p_Exists + 1
                    p_FromFile = p_Row.Item("FilePath").ToString.Trim
                    p_toFilePath = p_toFilePath & "\" & p_Row.Item("FileName").ToString.Trim
                    If p_GetFile(p_FromFile, p_toFilePath, p_Err) = False Then
                        Cursor = Cursors.Default
                        'ShowMessageBox("", p_Err)
                        MsgBox(p_Err)
                        Exit Sub
                    Else
                        p_Insert = "INSERT INTO [SYS_VERSION_HIST] ([FileName],[FilePath] ,[FileMajor] ,[FileMinor] ,[FileBuild] ," & _
                                "[FileRevision],[PC_Name],[PC_IP],[UpdData])"
                        p_Insert = p_Insert & " VALUES ('" & p_Row.Item("FileName").ToString.Trim & "'" & _
                                    ",'" & p_Row.Item("FilePath").ToString.Trim & "'" & _
                                    "," & p_Row.Item("FileMajor").ToString.Trim & "" & _
                                    "," & p_Row.Item("FileMinor").ToString.Trim & "" & _
                                    "," & p_Row.Item("FileBuild").ToString.Trim & "" & _
                                    "," & p_Row.Item("FileRevision").ToString.Trim & "" & _
                                    ",'" & UCase(g_GetHostName) & "','" & g_IP_Address & "' , getdate()" & _
                                    ")"

                        p_Row = p_DtbExec.NewRow
                        p_Row.Item(0) = p_Insert
                        p_DtbExec.Rows.Add(p_Row)
                    End If
                End If
            Next
            If p_Exists = 0 Then
                Cursor = Cursors.Default
                MsgBox("Chưa chọn file cập nhật")
                Exit Sub
            End If
            If p_DtbExec.Rows.Count > 0 Then
                If g_Services.Sys_Execute_DataTbl(p_DtbExec, p_Err) = False Then
                    'MsgBox(p_SQL)
                    Cursor = Cursors.Default
                    MsgBox(p_Err)
                    Exit Sub
                End If
            End If
            Cursor = Cursors.Default
            'Me.Close()
            MsgBox("Đã thực hiện xong", MsgBoxStyle.Information, "Thông báo")

        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox(ex.Message)

        End Try
        
    End Sub

    'p_FromFile = p_DataTable.Rows(p_Count).Item("FilePath").ToString.Trim
    '                p_toFilePath = p_toDirectoryFilePath & "\" & p_DataTable.Rows(p_Count).Item("FileName").ToString.Trim

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If g_WCF = True Then
            UpdateFile()
        End If

    End Sub
End Class