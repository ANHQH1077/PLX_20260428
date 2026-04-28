Imports System.IO
Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim p_SQL As String = ""
        Dim p_Count As Integer
        Dim p_Column As DataColumn
        Dim p_Str As String = "STRING"
        Dim p_Date As String = "DATE"
        ' Dim p_File As File
        Dim Value As String
        Dim p_StreemWriter As StreamWriter
        If U_Proc.Text <> "" Then
            p_SQL = U_Proc.Text.ToString.Trim
        End If
        If p_SQL = "" Then Exit Sub
        Dim p_DataTable As DataTable
        Dim p_DataSet As New DataSet
        Dim p_ConnectStr As String
        Dim Olecon As New OleDb.OleDbConnection
        Dim OlemyCommand As OleDb.OleDbCommand
        Dim p_OleAdapter As OleDb.OleDbDataAdapter
        Dim p_Int As Integer
        Dim p_FileName As String
        ' CreateFieldDefFile(rs, "c:\file.ttx", True) 'from a p2smon.dll
        Dim p_CountTbl As Integer
        Dim p_Form As New System.Windows.Forms.SaveFileDialog
        p_Form.ShowDialog()
        If p_Form.FileName.ToString.Trim <> "" Then
            'p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

            p_ConnectStr = SysGetConnect()
            Olecon.ConnectionString = p_ConnectStr
            Try

            
            Olecon.Open()
            If Olecon.State.ToString() = "Open" Then
                OlemyCommand = New OleDb.OleDbCommand(p_SQL, Olecon)

                OlemyCommand.CommandTimeout = 300
                p_OleAdapter = New OleDb.OleDbDataAdapter(OlemyCommand)
                Try
                    p_Int = p_OleAdapter.Fill(p_DataSet)
                Catch ex As Exception
                    MsgBox("Error exec")
                    Exit Sub
                End Try

            Else
                ' p_Status = False
                MsgBox("Error")
                Exit Sub
            End If
            Olecon.Close()
            Olecon = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
            If Not p_DataSet Is Nothing Then

            End If
            For p_CountTbl = 0 To p_DataSet.Tables.Count - 1
                p_DataTable = p_DataSet.Tables(p_CountTbl)
                If Not p_DataTable Is Nothing Then
                    p_FileName = p_Form.FileName.ToString.Trim
                    If p_CountTbl > 0 Then
                        p_FileName = UCase(p_FileName)
                        p_FileName = Replace(p_FileName, ".TTX", "_" & p_CountTbl & ".TTX", 1)
                    End If

                    p_StreemWriter = File.CreateText(p_FileName)
                    p_StreemWriter.WriteLine()
                    For p_Count = 0 To p_DataTable.Columns.Count - 1
                        p_Column = p_DataTable.Columns(p_Count)
                        If InStr(UCase(p_Column.DataType.Name), p_Str) > 0 Then
                            'MsgBox(p_Column.DataType.Name)
                            Value = p_Column.ColumnName & vbTab & "String" & vbTab & 255
                        ElseIf InStr(UCase(p_Column.DataType.Name), p_Date) > 0 Then
                            Value = p_Column.ColumnName & vbTab & "Datetime"
                        Else
                            'MsgBox(p_Column.DataType.Name)
                            Value = p_Column.ColumnName & vbTab & "Number" & vbTab & 0
                        End If
                        p_StreemWriter.WriteLine(Value)
                    Next
                    p_StreemWriter.Flush()
                    p_StreemWriter.Close()
                    p_StreemWriter.Dispose()

                End If
            Next
            MsgBox("Đã thực hiện xong")
            'If p_SQL <> "" Then
            '    MsgBox(p_SQL)
            '    Exit Sub
            'End If

        End If
    End Sub

    Private Function SysGetConnect() As String
        Dim p_ConStr As String
        '  SysGetStrConnect()
        p_ConStr = ""
        If Me.U_Db.Text <> "" Then
            ' If g_DBPortInstance.ToString.Trim = "" Then
            p_ConStr = "Provider=SQLOLEDB;Data Source=" & U_IP.Text.ToString.Trim & ":1433;Persist Security Info=True;User ID=" & _
                U_User.Text.ToString.Trim & ";Password=" & U_Pass.Text.ToString.Trim & ";Initial Catalog=" & U_Db.Text.ToString.Trim & ";Connect Timeout=300"
            'Else
            'p_ConStr = "Provider=SQLOLEDB;Server=" & g_Server & "," & g_DBPortInstance & ";" & _
            '        "Database=" & g_DB_Name & ";User ID=" & g_UserName & ";Password=" & g_Password & ";" & _
            '        "Trusted_Connection=False;Connect Timeout=300"
            'End If

        End If

        SysGetConnect = p_ConStr
    End Function

End Class
