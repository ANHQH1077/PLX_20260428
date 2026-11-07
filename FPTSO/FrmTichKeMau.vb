Public Class FrmTichKeMau

    Private Sub U_ButtonCus2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus2.Click
        Dim cl_SOAP_API As New SOAP_API.CL_SOAP_API(g_UserName)
        Dim p_Value As String = ""
        Dim p_MaphuongTien As String = ""
        Dim p_Date As String = ""
        Dim p_SQL As String = ""
        Dim p_SoTichKe = ""
        Dim p_int As Integer
        Dim p_DataTable As DataTable
        Dim p_Table As DataTable
        Dim p_Check As Boolean = False
        Dim p_RptPhuongTienCert As New ReportSetup.Class1(g_Config_XMLDatatable, _
                                                                    g_Company_Code, _
                                                                    g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                                    g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                                    g_DBPass, g_CompanyAPI)
        If Not Me.SoTichKe.EditValue Is Nothing Then
            p_SoTichKe = Me.SoTichKe.EditValue.ToString.Trim
        End If
        If Not Me.NgayXuat.EditValue Is Nothing Then
            p_Date = CDate(Me.NgayXuat.EditValue).ToString("yyyy-MM-dd")
            p_RptPhuongTienCert.clsInlTichKeMau(p_SoTichKe, p_Date)
                
        End If
        

        
    End Sub
End Class