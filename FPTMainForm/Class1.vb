Public Class Class1
    Public Sub New(ByVal p_Company_Code As String, ByVal p_Services As Object, ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                  Optional ByVal p_Company_Host As String = "", _
                   Optional ByVal p_Company_DB_Name As String = "", Optional ByVal p_UserName As String = "", _
                   Optional ByVal p_LicenceHost As String = "", Optional ByVal p_DBUser As String = "", _
                   Optional ByVal p_DBPass As String = "", Optional ByVal p_CompanyAPI As SAPbobsCOM.Company = Nothing)

        g_Company_Host = p_Company_Host
        g_GetHostName = p_Company_DB_Name
        g_Company_DBName = p_Company_DB_Name
        g_Services = p_Services


        g_CompanyAPI = p_CompanyAPI



        g_UsrB1 = p_UsrB1
        g_PassB1 = p_PassB1
        g_Port = p_Port
        g_Company_Code = p_Company_Code
        g_UserName = p_UserName
        g_LicenceHost = p_LicenceHost

        g_DBUser = p_DBUser
        g_DBPass = p_DBPass


        Dim p_FptMod As New FPTModule.Class1(g_Services, p_UsrB1, p_PassB1, p_Port, g_Company_Host, g_GetHostName)
        p_Get_Message()

        If p_DataSet_Combo_Source.Tables.Count <= 0 Then
            If p_FptMod.p_Mod_Get_Combobox_Source("FPTMRP", p_DataSet_Combo_Source) = False Then
            End If
        End If

        p_FptMod = Nothing
    End Sub
End Class
