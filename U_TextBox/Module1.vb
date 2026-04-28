Module Module1

    Private Sub SubEditValueChanging(ByRef p_Form As Object, _
                                     ByRef e As DevExpress.XtraEditors.Controls.ChangingEventArgs)
        Try
            If p_Form.FormStatus = True Then Exit Sub
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    

    Public Sub SubValidated(ByRef p_Form As Object, ByVal p_Control As Object)

        Dim p_Item() As System.Windows.Forms.Control
        Dim p_DataRow As DataRow
        Dim p_DataRowArr() As DataRow

        'Dim p_TableName  string 
        Try
            ' If p_Form.FormStatus = True Then Exit Sub
            If p_Form.g_FormLoad = True Then Exit Sub
            If p_Form.g_RecodeMove = True Then Exit Sub
        Catch ex As Exception
            Exit Sub
        End Try


        Try
            If p_Form.pv_TableEdit.Columns.Count <= 0 Then
                p_Form.pv_TableEdit.Columns.Add("TableEdit", GetType(String))
            End If
            If p_Control.tablename.ToString.Trim <> "" Then
                p_DataRowArr = p_Form.pv_TableEdit.select("TableEdit='" & UCase(p_Control.tablename.ToString.Trim) & "'")
                If p_DataRowArr.Length <= 0 Then
                    p_DataRow = p_Form.pv_TableEdit.newrow
                    p_DataRow.Item(0) = UCase(p_Control.tablename.ToString.Trim)
                    p_Form.pv_TableEdit.rows.add(p_DataRow)
                End If
                
            End If
            p_Item = p_Form.Controls.Find(p_Form.ButtonSave, True)
            If p_Item.Length > 0 Then
                p_Item(0).Text = p_Form.CaptionUpd


            End If
            p_Form.FormStatus = True
            'p_Form.SetmenuIcon(True)
        Catch ex As Exception

        End Try

    End Sub
End Module
