Public Class FrmQhuyDoi

    'Dim p_SAP_Obj As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
    'p_SQLErr = p_SAP_Obj.ClsScadarToHTTG("in", p_SoLenh, g_LoaiHinhVanChuyen, p_Terminal, True, g_E5)


    Private Sub ButtonCus1_Inline()
        Dim p_NhietDoTT As Decimal = 0
        Dim p_TyTrong As Decimal = 0
        Dim p_ThucXuat As Decimal = 0
        Dim p_SQL As String
        Dim p_Datable As DataTable
        Dim r_temp As String
        Dim r_dens_1 As String
        Dim r_dens_2 As String
        Dim r_dens As String

        Dim p_Dens As Decimal
        Dim p_SAP_Obj As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)


        Dim p_Vcf As String

        If Not NhietDo.EditValue Is Nothing Then
            Decimal.TryParse(NhietDo.EditValue.ToString, p_NhietDoTT)
        End If
        If Not TyTrong.EditValue Is Nothing Then
            Decimal.TryParse(TyTrong.EditValue.ToString, p_TyTrong)
        End If
        If Not ThucXuat.EditValue Is Nothing Then
            Decimal.TryParse(ThucXuat.EditValue.ToString, p_ThucXuat)
        End If

        p_SAP_Obj.clsQCI_GetD15_Inline(p_NhietDoTT, p_TyTrong, r_temp, r_dens_1, r_dens_2, r_dens)


        Double.TryParse(r_dens, p_Dens)

        Me.TyTrong15.EditValue = p_Dens
        Me.NhietDo1.EditValue = r_temp
        Me.TyTrong1.EditValue = r_dens_1
        Me.TyTrong2.EditValue = r_dens_2

        p_SQL = "select dbo.zzFPT_mdlQCI_GetVCF_NS ('" & Math.Round(p_NhietDoTT, 4) & "','" & Math.Round(p_Dens, 4) & "' ) as VCF"
        p_Datable = GetDataTable(p_SQL, p_SQL)

        Me.VCF.EditValue = 0
        If Not p_Datable Is Nothing Then
            If p_Datable.Rows.Count > 0 Then
                Me.VCF.EditValue = p_Datable.Rows(0).Item(0)
            End If
        End If


        p_SQL = "exec dbo.zzFPT_mdlQCI_CalculateQCI_NS_QC " & _
              p_ThucXuat & "," & _
              "'L'," & _
              p_NhietDoTT & "," & p_Dens & ",'','' "
        p_Datable = GetDataTable(p_SQL, p_SQL)
        ' p_Vcf = ""
        Me.L15.EditValue = 0
        If Not p_Datable Is Nothing Then
            If p_Datable.Rows.Count > 0 Then
                Me.L15.EditValue = p_Datable.Rows(0).Item(1)
                Me.KG.EditValue = p_Datable.Rows(0).Item(3)

            End If
        End If


    End Sub


    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_NhietDoTT As Decimal = 0
        Dim p_TyTrong As Decimal = 0
        Dim p_ThucXuat As Decimal = 0
        Dim p_SQL As String
        Dim p_Datable As DataTable

        Dim p_Vcf As String

        If Me.Approved.Checked = True Then
            ButtonCus1_Inline()
            Exit Sub
        End If

        If Not NhietDo.EditValue Is Nothing Then
            Decimal.TryParse(NhietDo.EditValue.ToString, p_NhietDoTT)
        End If
        If Not TyTrong.EditValue Is Nothing Then
            Decimal.TryParse(TyTrong.EditValue.ToString, p_TyTrong)
        End If
        If Not ThucXuat.EditValue Is Nothing Then
            Decimal.TryParse(ThucXuat.EditValue.ToString, p_ThucXuat)
        End If

        p_SQL = "select dbo.zzFPT_mdlQCI_GetVCF_NS ('" & Math.Round(p_NhietDoTT, 4) & "','" & Math.Round(p_TyTrong, 4) & "' ) as VCF"
        p_Datable = GetDataTable(p_SQL, p_SQL)

        Me.VCF.EditValue = 0
        If Not p_Datable Is Nothing Then
            If p_Datable.Rows.Count > 0 Then
                Me.VCF.EditValue = p_Datable.Rows(0).Item(0)
            End If
        End If


        p_SQL = "exec dbo.zzFPT_mdlQCI_CalculateQCI_NS_QC " & _
              p_ThucXuat & "," & _
              "'L'," & _
              p_NhietDoTT & "," & p_TyTrong & ",'','' "
        p_Datable = GetDataTable(p_SQL, p_SQL)
        ' p_Vcf = ""
        Me.L15.EditValue = 0
        If Not p_Datable Is Nothing Then
            If p_Datable.Rows.Count > 0 Then
                Me.L15.EditValue = p_Datable.Rows(0).Item(1)
                Me.KG.EditValue = p_Datable.Rows(0).Item(3)
                'p_Vcf = Mid(p_Datable.Rows(0).Item(0).ToString.Trim, 1, 6)
            End If
        End If


    End Sub

    Private Sub FrmQhuyDoi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Approved_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Approved.CheckedChanged
        If Me.Approved.Checked = True Then
            Me.NhietDo1.Visible = True
            Me.TyTrong1.Visible = True
            Me.TyTrong15.Visible = True
            Me.TyTrong2.Visible = True

            Me.L_NhietDo1.Visible = True
            Me.L_TyTrong1.Visible = True
            Me.L_TyTrong15.Visible = True
            Me.L_TyTrong2.Visible = True


        Else
            Me.NhietDo1.Visible = False
            Me.TyTrong1.Visible = False
            Me.TyTrong15.Visible = False
            Me.TyTrong2.Visible = False

            Me.L_NhietDo1.Visible = False
            Me.L_TyTrong1.Visible = False
            Me.L_TyTrong15.Visible = False
            Me.L_TyTrong2.Visible = False
        End If
    End Sub
End Class