Imports System.IO
Public Class FrmBuildTtx

    Private Sub BtnBuild_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuild.Click
        Dim p_SQL As String = ""
        Dim p_Count As Integer
        Dim p_Column As DataColumn
        Dim p_Str As String = "STRING"
        Dim p_Date As String = "DATE"
        ' Dim p_File As File
        Dim Value As String
        Dim p_StreemWriter As StreamWriter
        If Not Me.TxtProName.EditValue Is Nothing Then
            p_SQL = Me.TxtProName.EditValue.ToString.Trim
        End If
        If p_SQL = "" Then Exit Sub
        Dim p_DataTable As DataTable

        ' CreateFieldDefFile(rs, "c:\file.ttx", True) 'from a p2smon.dll

        Dim p_Form As New System.Windows.Forms.SaveFileDialog
        p_Form.ShowDialog()
        If p_Form.FileName.ToString.Trim <> "" Then
            p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If p_SQL <> "" Then
                MsgBox(p_SQL)
                Exit Sub
            End If
            If Not p_DataTable Is Nothing Then
                p_StreemWriter = File.CreateText(p_Form.FileName.ToString.Trim)
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
                MsgBox("Đã thực hiện xong")
            End If
        End If
    End Sub
End Class