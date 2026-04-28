Public Class Class1

    Public Sub New(ByVal LinkServices As String, ByVal p_UserName As String, ByVal p_Pass As String, ByVal p_CompanyCode As String)
        Dim p_Error As String = ""
        g_LinkServices = LinkServices
        g_UserName = p_UserName
        g_Pass = p_Pass
        g_CompanyCode = p_CompanyCode
    End Sub




    Public Function clsVungtau_DO_Infor(ByVal p_SoLenh As String, ByRef p_Error As String, ByVal p_PhuongTien As String, ByRef p_TableExe As DataTable, _
                                    ByVal p_CheckDO As Boolean, ByRef p_PhuongTienSMO As String) As Boolean
        clsVungtau_DO_Infor = VungTau_TGBX_GetInfoDO(p_SoLenh, p_Error, p_PhuongTien, p_TableExe, p_CheckDO, p_PhuongTienSMO)

    End Function


    Public Function clsKV2_DO_Infor(ByVal p_SoLenh As String, ByRef p_Error As String, ByVal p_PhuongTien As String, ByRef p_TableExe As DataTable, _
                                    ByVal p_CheckDO As Boolean, ByRef p_PhuongTienSMO As String) As Boolean
        clsKV2_DO_Infor = KV2_TGBX_GetInfoDO(p_SoLenh, p_Error, p_PhuongTien, p_TableExe, p_CheckDO, p_PhuongTienSMO)

    End Function
    Public Function clsgetVehicleInfor(ByVal p_MaPtien As String,
                                    ByRef p_Table As DataTable) As Boolean

        clsgetVehicleInfor = getVehicleInfor(p_MaPtien, p_Table)
    End Function


    Public Function clsgetVehicleTrans(ByVal p_SoChuyen As String,
                                    ByRef p_Table As DataTable) As Boolean

        clsgetVehicleTrans = getVehicleTrans(p_SoChuyen, p_Table)

    End Function
    Public Function clsUpdateStatusDO(ByVal p_DoNumber As String, ByVal p_Status As String, ByVal p_DateTime As DateTime) As Boolean
        clsUpdateStatusDO = UpdateStatusDO(p_DoNumber, p_Status, p_DateTime)
    End Function
End Class
