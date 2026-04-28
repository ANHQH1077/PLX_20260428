Public Class FrmBarem

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_NhietDoTT As Decimal = 0
        Dim p_TyTrong As Decimal = 0
        Dim p_ThucXuat As Decimal = 0
        Dim p_SQL As String
        Dim p_Datable As DataTable
        Dim p_ChieuCaoDau As Decimal = 0
        Dim p_Vcf As String
        Dim p_TankCode As String = ""
        If Not TankHeight.EditValue Is Nothing Then
            Decimal.TryParse(TankHeight.EditValue.ToString, p_ChieuCaoDau)
        End If

        'exec(FPT_GetBaremTankATG_QCI) 'B030','0.0','0',8575


        If Not Me.TankCode.EditValue Is Nothing Then
            p_TankCode = Me.TankCode.EditValue.ToString.Trim
        End If


        If Not NhietDo.EditValue Is Nothing Then
            Decimal.TryParse(NhietDo.EditValue.ToString, p_NhietDoTT)
        End If
        If Not TyTrong.EditValue Is Nothing Then
            Decimal.TryParse(TyTrong.EditValue.ToString, p_TyTrong)
        End If

        Me.VCF.EditValue = 0
        Me.L15.EditValue = 0
        Me.KG.EditValue = 0
        Me.ThucXuat.EditValue = 0

        p_SQL = "exec FPT_GetBaremTankATG_QCI '" & p_TankCode & "','" & Math.Round(p_NhietDoTT, 4) & "','" & Math.Round(p_TyTrong, 4) & "'," & p_ChieuCaoDau
        p_Datable = GetDataTable(p_SQL, p_SQL)
        If Not p_Datable Is Nothing Then
            Me.VCF.EditValue = p_Datable.Rows(0).Item("VCF")
            Me.L15.EditValue = p_Datable.Rows(0).Item("L15")
            Me.KG.EditValue = p_Datable.Rows(0).Item("Kg")
            Me.ThucXuat.EditValue = p_Datable.Rows(0).Item("Ltt")
        End If


        Exit Sub

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
End Class