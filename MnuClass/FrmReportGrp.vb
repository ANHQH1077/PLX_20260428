Public Class FrmReportGrp

    Public g_RptGroup As String = ""

    Private Sub FrmReportGrp_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim p_String() As String
        Dim p_Count As Integer
        Dim p_Count2 As Integer
        Dim p_Row As DataRow
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        If g_RptGroup <> "" Then
            p_String = g_RptGroup.Split(",")
            For p_Count = 0 To p_String.Length - 1
                For p_Count2 = 0 To Me.GridView1.RowCount - 1
                    p_Row = Me.GridView1.GetDataRow(p_Count2)
                    If Not p_Row Is Nothing Then
                        If p_String(p_Count) = p_Row.Item("Code").ToString.Trim Then
                            GridView1.SetRowCellValue(p_Count2, "X", "Y")
                            Continue For
                        End If
                    End If
                    
                Next
            Next
        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dim p_String As String = ""
        Dim p_Count As Integer
        Dim p_Row As DataRow
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_Data As DataTable
        p_String = ""
        Me.GridView1.EndDataUpdate()
        p_Binding = Me.TrueDBGrid1.DataSource
        If GridView1.FocusedRowHandle = 0 Then
            GridView1.MoveLast()
        Else
            GridView1.MoveFirst()
        End If
        p_Data = CType(p_Binding.DataSource, DataTable)
        For p_Count = 0 To Me.GridView1.RowCount - 1

            p_Row = Me.GridView1.GetDataRow(p_Count)
            If Not p_Row Is Nothing Then
                If p_Row.Item(0).ToString.Trim = "Y" Then
                    p_String = p_String & "," & p_Row.Item("Code").ToString.Trim
                End If
            End If
        Next
        If p_String <> "" Then
            p_String = Mid(p_String, 2)
        End If
        g_RptGroup = p_String
        Me.Close()
    End Sub
End Class