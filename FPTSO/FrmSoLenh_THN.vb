Public Class FrmSoLenh_THN

    Private Sub FrmSoLenh_THN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TuNgay.EditValue = DateAdd(DateInterval.Day, -2, Now.Date)
    End Sub


    Private Sub LoadData()
        Dim p_DocEntry As Integer = 0
        Dim p_NgayThang As Date
        Dim p_FromDate As String = ""
        Dim p_ToDate As String = ""
        Dim p_SoLenh As String = ""
        'Dim p_sType As String = ""
        Dim p_Where As String = ""
        'Dim p_Status As String = ""
        
       
        If Not Me.txtSoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.txtSoLenh.EditValue.ToString.Trim
        End If
        If p_SoLenh <> "" Then
            p_Where = "SoLenh='" & p_SoLenh & "' "
        End If


        If Not Me.TuNgay.EditValue Is Nothing Then
            If Me.TuNgay.EditValue.ToString.Trim <> "" Then
                p_FromDate = CDate(Me.TuNgay.EditValue).ToString("yyyy-MM-dd")
            End If
        End If

        If p_FromDate <> "" Then
            If p_Where <> "" Then
                p_Where = p_Where & " and convert(date, CreateDate) >='" & p_FromDate & "' "

            Else
                p_Where = " convert(date,CreateDate) >='" & p_FromDate & "' "
            End If
        End If
        If Not Me.DenNgay.EditValue Is Nothing Then
            If Me.DenNgay.EditValue.ToString.Trim <> "" Then
                p_ToDate = CDate(Me.DenNgay.EditValue).ToString("yyyy-MM-dd")
            End If
        End If
        If p_ToDate <> "" Then
            If p_Where <> "" Then
                p_Where = p_Where & " and convert(date, CreateDate) <='" & p_ToDate & "' "

            Else
                p_Where = " convert(date, CreateDate) <='" & p_ToDate & "' "
            End If
        End If

        Me.GridView1.Where = p_Where
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False
    End Sub

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        LoadData()
    End Sub
End Class