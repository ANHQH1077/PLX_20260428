Public Class FrCardAdd

    Public p_GridView As U_TextBox.GridView

    Private Sub CardData_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CardData.EditValueChanged

    End Sub

    Private Sub CardData_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CardData.KeyDown
        'SendKeys.Send("{TAB}")
        If e.KeyCode = Keys.Enter Then
            Me.CardSerial.Focus()
        End If

    End Sub

    Private Sub CardSerial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CardSerial.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim p_CardData As String = ""
            Dim p_CardSerial As String = ""
            Dim p_datarow As DataRow
            Dim p_fromDate As Date = Nothing
            Dim p_ToDate As Date = Nothing
            Dim p_Date1 As Boolean = False
            Dim p_Date2 As Boolean = False
            Dim p_Binding As U_TextBox.U_BindingSource
            Dim p_Table As DataTable
            Dim p_RowArr() As DataRow
            If Not Me.CardSerial.EditValue Is Nothing Then
                p_CardSerial = Me.CardSerial.EditValue.ToString.Trim
            End If

            If Not Me.CardData.EditValue Is Nothing Then
                p_CardData = Me.CardData.EditValue.ToString.Trim
            End If

            If p_CardData = "" Or p_CardSerial = "" Then
                Exit Sub
            End If

            If Not Me.FromDate.EditValue Is Nothing Then
                If Me.FromDate.EditValue.ToString.Trim <> "" Then
                    p_Date1 = True
                    p_fromDate = Me.FromDate.EditValue
                End If
            End If

            If Not Me.ToDate.EditValue Is Nothing Then
                If Me.ToDate.EditValue.ToString.Trim <> "" Then
                    p_ToDate = Me.ToDate.EditValue
                    p_Date2 = True
                End If
            End If

            p_Binding = p_GridView.DataSource
            p_Table = CType(p_Binding.DataSource, DataTable)
            p_RowArr = p_Table.Select("CardNum='" & p_CardSerial & "' or CardData ='" & p_CardData & "'")
            If p_RowArr.Length <= 0 Then
                p_GridView.AddNewRow()
                p_GridView.SetFocusedRowCellValue("CardData", p_CardData)
                p_GridView.SetFocusedRowCellValue("CardNum", p_CardSerial)
                p_GridView.SetFocusedRowCellValue("CHECKUPD", "I")
                If p_Date1 = True Then
                    p_GridView.SetFocusedRowCellValue("FromDate", CDate(p_fromDate).ToString("MM/dd/yyyy"))
                End If

                If p_Date2 = True Then
                    p_GridView.SetFocusedRowCellValue("ToDate", CDate(p_ToDate).ToString("MM/dd/yyyy"))
                End If
            Else
                ShowMessageBox("", "Card Data hoặc Card Serial đã tồn tại")
            End If
            Me.CardSerial.EditValue = ""
            Me.CardData.EditValue = ""
            Me.CardData.Focus()

        End If
    End Sub

    Private Sub FrCardAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CardData.Focus()
    End Sub
End Class