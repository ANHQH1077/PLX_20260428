Public Class Class1

    Public Sub New(ByVal p_WcfE5 As Boolean, ByVal p_Services As Object, ByRef p_flag As Integer(), ByRef p_lw_mess As String(), ByVal p_isGetAll As String, _
                 ByVal p_dt As DataTable, ByVal p_SapConnectionString As String, ByVal p_WareHouse As String, _
                 ByVal p_dtVariable As DataTable, ByVal p_Company_Code As String, ByVal p_ShPoint As String, Optional p_UserName As String = "")
        ' _TimeOut = p_TimeOut
        flag = p_flag
        lw_mess = p_lw_mess
        isGetAll = p_isGetAll
        g_dt = p_dt
        _SapConnectionString = p_SapConnectionString
        _WareHouse = p_WareHouse
        _dtVariable = p_dtVariable
        g_Company_Code = p_Company_Code
        _ShPoint = p_ShPoint
        g_Services = p_Services
        g_WcfE5 = p_WcfE5
        g_userName = p_UserName
    End Sub


    Public Sub clsHistStringSyn(ByVal p_Para As String, ByVal p_From As Boolean)
        HistStringSyn(p_Para, p_From)
    End Sub

    Public Function ClsSyncMaster_SyncCustomer(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, ByRef p_desc As String) As Boolean
        ClsSyncMaster_SyncCustomer = mdlSyncMaster_SyncCustomer(p_DataTablExe, i_getall, i_date, p_desc)
    End Function
    'hieptd4 add 20161027
    Public Function ClsSyncMaster_SyncPrice(ByRef p_DataTablExe As DataTable, ByVal i_date As String, ByRef p_desc As String) As Boolean
        ClsSyncMaster_SyncPrice = mdlSyncMaster_SyncPrice(p_DataTablExe, i_date, p_desc)
    End Function
    Public Function ClsSyncMaster_SyncPaymentTerm(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean
        ClsSyncMaster_SyncPaymentTerm = mdlSyncMaster_SyncPaymentTerm(p_DataTablExe, p_desc)
    End Function
    Public Function ClsSyncMaster_SyncDischard(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean
        ClsSyncMaster_SyncDischard = mdlSyncMaster_SyncDischard(p_DataTablExe, p_desc)
    End Function
    Public Function ClsSyncMaster_SyncRoute(ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean
        ClsSyncMaster_SyncRoute = mdlSyncMaster_SyncRoute(p_DataTablExe, p_desc)
    End Function
    Public Function ClsSyncMaster_SyncVendor(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, ByRef p_desc As String) As Boolean
        ClsSyncMaster_SyncVendor = mdlSyncMaster_SyncVendor(p_DataTablExe, i_getall, i_date, p_desc)
    End Function
    'end hieptd4 add 20161027
    Public Function ClsSyncMaster_SyncTransport(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByRef p_desc As String) As Boolean
        ClsSyncMaster_SyncTransport = mdlSyncMaster_SyncTransport(p_DataTablExe, i_getall, p_desc)

    End Function

    Public Function ClsSynNguonHang(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, ByRef p_desc As String) As Boolean
        ClsSynNguonHang = SynNguonHang(p_DataTablExe, i_getall, i_date, p_desc)
    End Function

    Public Function ClsSyncMaster_SyncMaterial(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, ByRef p_desc As String) As Boolean
        ClsSyncMaster_SyncMaterial = mdlSyncMaster_SyncMaterial(p_DataTablExe, i_getall, i_date, p_desc)
    End Function

    Public Function ClsSyncMaster_SyncVehicleDown(ByRef p_DataTablExe As DataTable, ByVal i_getAll As String, ByVal i_date As String, ByRef p_desc As String) As Boolean

        ClsSyncMaster_SyncVehicleDown = mdlSyncMaster_SyncVehicleDown(p_DataTablExe, i_getAll, i_date, p_desc)
    End Function

    Public Function ClsSyncMaster_SyncVehicleDownNew(ByVal i_vehicle As String, ByRef p_Count As Integer, ByRef p_Desc As String, g_User As String) As Boolean

        ClsSyncMaster_SyncVehicleDownNew = mdlSyncMaster_SyncVehicleDown1(i_vehicle, p_Count, p_Desc, g_User)
    End Function



    Public Function ClsSynPhuongThuc(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByRef p_desc As String) As Boolean
        ClsSynPhuongThuc = SynPhuongThuc(p_DataTablExe, i_getall, p_desc)
    End Function

    Public Function ClsSynDonViTinh(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByRef p_desc As String) As Boolean
        ClsSynDonViTinh = SynDonViTinh(p_DataTablExe, i_getall, p_desc)
    End Function

    Public Function ClsSyncMaster_SyncTank(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                           ByVal i_date As String, _
                                           ByVal i_plant As String, ByRef p_desc As String) As Boolean
        Dim i_Time As String = ""
        ClsSyncMaster_SyncTank = mdlSyncMaster_SyncTank_New(p_DataTablExe, i_getall, _
                                            i_date, _
                                            i_plant, p_desc, i_Time)
    End Function


    Public Function ClsSyncMaster_SyncTank_ATG(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                           ByVal i_date As String, _
                                           ByVal i_plant As String, ByRef p_desc As String, l_Time As String) As Boolean

        ClsSyncMaster_SyncTank_ATG = mdlSyncMaster_SyncTank_ATG(p_DataTablExe, i_getall, _
                                            i_date, _
                                            i_plant, p_desc, l_Time)
    End Function


    Public Function clsSyncMaster_SyncTank_Barem(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                         ByVal i_date As String, _
                                         ByVal i_plant As String, ByRef p_desc As String, l_Time As String, p_TankName As String) As Boolean
        clsSyncMaster_SyncTank_Barem = mdlSyncMaster_SyncTank_Barem(p_DataTablExe, i_getall, i_date, i_plant, p_desc, l_Time, p_TankName)
    End Function



    Public Function ClsSyncMaster_SyncPurpose_ATG(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, _
                                           ByVal i_date As String, _
                                           ByVal i_plant As String, ByRef p_desc As String, l_Time As String) As Boolean

        ClsSyncMaster_SyncPurpose_ATG = mdlSyncMaster_SyncPurpose_ATG(p_DataTablExe, i_getall, _
                                            i_date, _
                                            i_plant, p_desc, l_Time)
    End Function

    Public Function cldSyncMaster_SyncVehicleUp(ByVal i_number As String, ByVal i_tutype As String, ByVal i_dt_compartment As DataTable) As Boolean
        cldSyncMaster_SyncVehicleUp = mdlSyncMaster_SyncVehicleUp(i_number, i_tutype, i_dt_compartment)
    End Function

    Public Function clsGetDateLog(ByVal p_Para As String) As String
        clsGetDateLog = GetDateLog(p_Para)
    End Function

    Public Sub clsCapNhatLog(ByVal p_Para As String, ByVal p_Count As Integer)
        CapNhatLog(p_Para, p_Count)
    End Sub

    Public Function clsSynKho(ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, _
                                 ByRef p_Desc As String) As Boolean
        clsSynKho = SynKho(p_DataTablExe, i_getall, i_date, p_Desc)
    End Function



    Public Function clsSynHopDong(ByVal p_Company As String, ByRef p_DataTablExe As DataTable, ByVal i_getall As String, ByVal i_date As String, _
                                 ByRef p_Desc As String) As Boolean

        clsSynHopDong = SynHopDong(p_Company, p_DataTablExe, i_getall, i_date, p_Desc)
    End Function

    Public Function clsSyncHoaDonVAT(ByVal p_SoLenhIn As String, ByRef p_DataTablExe As DataTable, ByRef p_desc As String) As Boolean
        clsSyncHoaDonVAT = mdlSyncHoaDonVAT(p_SoLenhIn, p_DataTablExe, p_desc)
    End Function



    Public Function clsSynHopDong_Detail(ByVal p_Company As String, ByRef p_DataTablExe As DataTable, ByVal p_Vbeln As String, ByVal i_date As String, _
                                 ByRef p_Desc As String, ByVal p_MaPhuongThucBan As String) As Boolean
        clsSynHopDong_Detail = SynHopDong_Detail(p_Company, p_DataTablExe, p_Vbeln, i_date, p_Desc, p_MaPhuongThucBan)
    End Function

End Class
