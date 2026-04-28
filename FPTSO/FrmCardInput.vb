Public Class FrmCardInput
    Public StringSoLenh As String = ""
    Public StringReturn As String = ""

    Public StringCardData As String = ""

    Private Sub FrmCardInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CardNum.EditValue = StringReturn
    End Sub

    Private Sub SoLenh_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CardNum.EditValueChanged

    End Sub

    Private Sub SoLenh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CardNum.KeyDown
        Dim p_SQL As String = ""
        Dim p_Table As DataTable
        Dim p_Exit As Boolean = False

        If e.KeyCode = Keys.Enter Then
            StringReturn = ""
            If Not Me.CardNum.EditValue Is Nothing Then
                StringReturn = Me.CardNum.EditValue.ToString.Trim
            End If
            If StringReturn <> "" Then



                p_SQL = " select CardNum , CardData from zCardLists where (CardNum ='" & StringReturn & "' or CardData ='" & StringReturn & "' )  and isnull(Status ,'Y') <> 'N' " & _
                              " and convert(date,getdate()) > = convert(date, isnull(FromDate,getdate()-5))  " & _
                              " and convert(date,getdate()) < = convert(date, isnull(ToDate,getdate()+5)) "
                p_Table = GetDataTable(p_SQL, p_SQL)



                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        StringReturn = p_Table.Rows(0).Item("CardNum").ToString.Trim
                        StringCardData = p_Table.Rows(0).Item("CardData").ToString.Trim
                        p_Exit = True
                    End If
                End If

                If p_Exit = False Then
                    ShowMessageBox("", "Thẻ không hiệu lực")
                    Me.CardNum.EditValue = ""
                    Me.CardNum.Focus()
                    StringReturn = ""
                    Exit Sub
                End If

                'Kiem tra xem so the nay da duoc gan cho  lenh nao khong nằm trong danh sách lệnh ghép
                p_SQL = "select upper ( (SELECT   ',' + a.SoLenh  " & _
                            " FROM  tblLenhXuatE5 a  with (nolock)  where  ( CHARINDEX (',' + solenh +',','" & StringSoLenh & ",',1) =0 )  " & _
                                " and isnull( CardNum,'') ='" & StringReturn & "'  and Status  not in ('4','5')  " & _
                            " FOR XML PATH('')  )  )  as SoLenh "
                p_Table = GetDataTable(p_SQL, p_SQL)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        If p_Table.Rows(0).Item(0).ToString.Trim <> "" Then
                            ShowMessageBox("", "Thẻ đã được gắn cho lệnh (" & Mid(p_Table.Rows(0).Item(0).ToString.Trim, 2) & ")")
                            Me.CardNum.EditValue = ""
                            Me.CardNum.Focus()
                            StringReturn = ""
                            Exit Sub
                        End If


                    End If
                End If


                ''Kiem tra xem có lệnh nào không nằm trong danh sách lệnh ghep mà khác  số thẻ không

                p_SQL = "select upper ( (SELECT   ',' + a.SoLenh  " & _
                           " FROM  tblLenhXuatE5 a  with (nolock)  where  ( CHARINDEX (',' + solenh +',','" & StringSoLenh & ",',1) > 0 )  " & _
                               "  and isnull( CardNum,'') <> '" & StringReturn & "' and isnull( CardNum,'') <> '' " & _
                           " FOR XML PATH('')  )  )  as SoLenh "
                p_Table = GetDataTable(p_SQL, p_SQL)
                'p_SQL = "select SoLenh from tblLenhXuatE5  with (nolock)  where  ( CHARINDEX (',' + solenh +',','" & StringSoLenh & ",',1)>0  ) " & _
                '                " and isnull( CardNum,'') <> '" & StringReturn & "' and isnull( CardNum,'') <> '' "
                'p_Table = GetDataTable(p_SQL, p_SQL)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        If p_Table.Rows(0).Item(0).ToString.Trim <> "" Then
                            ShowMessageBox("", "Danh sách lệnh ghép (" & Mid(p_Table.Rows(0).Item(0).ToString.Trim, 2) & ") không cùng số thẻ")
                            Me.CardNum.EditValue = ""
                            Me.CardNum.Focus()
                            StringReturn = ""
                            Exit Sub
                        End If

                    End If
                End If

            End If
            Me.Close()
        End If
    End Sub
End Class