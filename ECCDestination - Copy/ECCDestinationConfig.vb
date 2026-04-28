Imports SAP.Middleware.Connector

Public Class ECCDestinationConfig
    Implements IDestinationConfiguration


    


    Public Function clsTankGroup_Infor(ByRef o_err As String, ByVal p_User As String, ByVal p_CompanyCode As String, ByVal p_Client As String) As DataTable
        clsTankGroup_Infor = TankGroup_Infor(o_err, p_User, p_CompanyCode, p_Client)
    End Function

    Public Sub clsTHN_DensToSap(ByVal p_TableHangHoa As System.Data.DataTable, ByRef p_Err As String)
        THN_DensToSap(p_TableHangHoa, p_Err)
    End Sub
    Public Sub clsKV1_UpdateTrangThaiTichKe(ByVal p_SoLenh As String, ByRef o_err As String)
        KV1_UpdateTrangThaiTichKe(p_SoLenh, o_err)
    End Sub

    Public Sub clsCapNhatTrangThaiAuto(ByVal p_FromDate As String, ByVal p_ToDate As String, ByVal p_SoLenh As String, ByRef o_err As String)
        CapNhatTrangThaiAuto(p_FromDate, p_ToDate, p_SoLenh, o_err)
    End Sub

    Public Sub clsPost_LenhXuatAuto(ByVal p_DataTable As DataTable, ByRef o_err As String)

        Post_LenhXuatAuto(p_DataTable, o_err)
    End Sub

    Public Sub clsPost_LenhXuatBoSung(ByVal p_DataTable As DataTable, ByRef o_err As String)
        'Post_LenhXuatBoSung_JSON(p_DataTable, o_err)
        Post_LenhXuatBoSung(p_DataTable, o_err)
    End Sub


    Public Sub clsGet_ATG_M_LIST(ByRef p_TableReturn As DataTable, ByVal p_Plan_DB As String, ByVal p_TankMapSap1 As String, ByVal p_ToDate As String, ByRef o_err As String)
        Get_ATG_M_LIST(p_TableReturn, p_Plan_DB, p_TankMapSap1, p_ToDate, o_err)
    End Sub

    Public Function clsGet_LenhXuatAuto(ByVal p_FromDate As String, ByVal p_ToDate As String, ByRef o_err As String)
        clsGet_LenhXuatAuto = Get_LenhXuatAuto(p_FromDate, p_ToDate, o_err)
    End Function


    Public Function clsGet_DO1_THN3(ByVal p_SoLenh As String, ByRef o_err As String) As DataTable
        clsGet_DO1_THN3 = Get_DO1_THN3(p_SoLenh, o_err)
    End Function




    Public Sub New(ByVal pv_ConnectString As String, ByVal pv_Language As String, ByVal pv_IdleTimeout As String, ByVal p_CompanyCode As String,
                   Optional ByVal pv_ClientApp As String = "", Optional ByVal pv_UserNameApp As String = "")
        ', pv_AppServerHost As String, pv_SystemNumber As String,
        ' pv_User As String, pv_Password As String, pv_Client As String, pv_Language As String, pv_IdleTimeout As String)

        Dim p_String() As String
        Dim p_Stringtmp() As String
        Dim p_SQL As String = pv_ConnectString
        p_ConnectString = pv_ConnectString

        g_ClientApp = pv_ClientApp
        g_UserNameApp = pv_UserNameApp
        If p_SQL <> "" Then
            p_String = p_SQL.Split(";")
            If p_String.Length > 0 Then
                For p_Count = 0 To p_String.Length - 1
                    p_Stringtmp = p_String(p_Count).Split("=")
                    If p_Stringtmp.Length > 0 Then
                        Select Case UCase(p_Stringtmp(0))
                            Case "ASHOST"
                                p_AppServerHost = p_Stringtmp(1)
                            Case "SYSNR"
                                p_SystemNumber = p_Stringtmp(1)
                            Case "CLIENT"
                                p_Client = p_Stringtmp(1)
                            Case "USER"
                                p_User = p_Stringtmp(1)
                            Case "PASSWD"
                                p_Password = p_Stringtmp(1)
                            Case Else

                        End Select
                    End If
                Next
            End If
        End If
        p_Language = pv_Language
        p_IdleTimeout = pv_IdleTimeout
        g_CompanyCode = p_CompanyCode

        g_GetDestination = g_UserNameApp
    End Sub

    Public Event ConfigurationChanged(ByVal destinationName As String, ByVal args As RfcConfigurationEventArgs) Implements IDestinationConfiguration.ConfigurationChanged

    Public Function GetParameters(ByVal destinationName As String) As RfcConfigParameters Implements IDestinationConfiguration.GetParameters

        Dim parms As New RfcConfigParameters

        Select Case destinationName

            Case g_GetDestination

                parms.Add(RfcConfigParameters.AppServerHost, p_AppServerHost)
                parms.Add(RfcConfigParameters.SystemNumber, p_SystemNumber)
                ' parms.Add(RfcConfigParameters.SystemID, "ECD")
                parms.Add(RfcConfigParameters.User, p_User)
                parms.Add(RfcConfigParameters.Password, p_Password)
                parms.Add(RfcConfigParameters.Client, p_Client)
                parms.Add(RfcConfigParameters.Language, p_Language)
                'parms.Add(RfcConfigParameters.PoolSize, "5")
                'parms.Add(RfcConfigParameters.MaxPoolSize, "10")
                parms.Add(RfcConfigParameters.IdleTimeout, p_IdleTimeout)

            Case Else

        End Select

        Return parms

    End Function

    Public Function ChangeEventsSupported() As Boolean Implements IDestinationConfiguration.ChangeEventsSupported
        Return False
    End Function


    Public Function clsGet_ToKhaiTaiXuat_Infor(ByVal p_CompanyCode As String, ByVal i_date As String, ByVal p_User As String, ByRef o_err As String) As DataTable
        clsGet_ToKhaiTaiXuat_Infor = Get_ToKhaiTaiXuat_Infor(p_CompanyCode, i_date, p_User, o_err)
    End Function


    Public Function clsGet_TankMapSAP_Infor(ByVal p_Plant As String, ByVal p_User As String, ByRef o_err As String) As DataTable
        clsGet_TankMapSAP_Infor = Get_TankMapSAP_Infor(p_Plant, p_User, o_err)
    End Function

    Public Function clsGet_DO1_Infor(ByVal p_SoLenh As String, ByRef o_err As String) As DataTable
        clsGet_DO1_Infor = Get_DO1_Infor(p_SoLenh, o_err)
    End Function


    Public Function clsGet_DO3_Infor(ByVal p_SoLenh As String, ByRef o_err As String) As DataTable
        clsGet_DO3_Infor = Get_DO3_Infor(p_SoLenh, o_err)
    End Function

    Public Function clsGet_DO2_Infor(ByVal p_SoLenh As String, ByRef o_err As String) As DataTable
        clsGet_DO2_Infor = Get_DO2_Infor(p_SoLenh, o_err)
    End Function

    Public Function clsGet_HoaDon_Infor(ByRef o_err As String) As DataTable
        clsGet_HoaDon_Infor = Get_HoaDon_Infor(o_err)

    End Function

    Public Function clsGet_CongTy_Infor(ByRef o_err As String) As DataTable
        clsGet_CongTy_Infor = Get_CongTy_Infor(o_err)

    End Function


    Public Function clsTHN_LenhXuat_Infor(ByVal p_TableHeader As DataTable, ByVal p_TableHangHoa As DataTable, _
                                        ByVal p_TableChiTiet As DataTable, ByRef o_err As String) As DataTable
        clsTHN_LenhXuat_Infor = THN_LenhXuat_Infor(p_TableHeader, p_TableHangHoa, _
                                         p_TableChiTiet, o_err)
    End Function

    Public Function clsGet_Kho_Infor(ByRef o_err As String) As DataTable
        clsGet_Kho_Infor = Get_KHo_Infor(o_err)


    End Function


    Public Function clsGet_NhaCungCap_Infor(ByRef o_err As String) As DataTable
        clsGet_NhaCungCap_Infor = Get_NhaCungCap_Infor(o_err)


    End Function


    Public Function clsGet_STO_Infor(ByRef o_err As String) As DataTable
        clsGet_STO_Infor = Get_STO_Infor(o_err)


    End Function



    Public Function clsGet_TyGia_Infor(ByVal p_DateIn As String, ByRef o_err As String) As DataTable
        clsGet_TyGia_Infor = Get_TyGia_Infor(p_DateIn, o_err)


    End Function



    Public Function clsDongBoATG(ByVal p_TankHeaderCode As String, ByVal p_Plant_DB As String, ByVal p_TableATG As DataTable, ByVal p1_User As String, ByRef o_err As String) As DataTable
        clsDongBoATG = DongBoATG(p_TankHeaderCode, p_Plant_DB, p_TableATG, p1_User, o_err)
    End Function

    Public Function clsDongBoHopDong(ByVal p_Company As String, ByVal i_date As String, _
                                ByVal p1_User As String, ByRef o_err As String, Optional ByVal p_GetAll As Boolean = False) As DataTable
        clsDongBoHopDong = DongBoHopDong(p_Company, i_date, _
                                 p1_User, o_err, p_GetAll)
    End Function

    Public Function clsThongTinLenhXuat_Services(ByRef o_err As String, ByVal p_Date As String) As DataTable
        clsThongTinLenhXuat_Services = ThongTinLenhXuat_Services(o_err, p_Date)
    End Function

    Public Function clsZFM_CHECK_DO_CKG(ByVal p_SoLenh As String, ByRef o_err As String) As String
        clsZFM_CHECK_DO_CKG = ZFM_CHECK_DO_CKG(p_SoLenh, o_err)
    End Function

    Public Sub clsPost_PhuongTien(ByVal p_DataTable_H As DataTable, ByVal p_DataTable_Line As DataTable, ByRef o_err As String)

        Post_PhuongTien(p_DataTable_H, p_DataTable_Line, o_err)

    End Sub

    Public Function clsSyncVEHICLE(ByVal p_date As String, ByVal p_VEHICLE As String, ByRef p_Error As String, ByRef p_TableLine As DataTable, ByRef p_TableHeader As DataTable, ByVal p_Type As String) As Boolean
        clsSyncVEHICLE = SyncVEHICLE(p_date, p_VEHICLE, p_Error, p_TableLine, p_TableHeader, p_Type)
    End Function
End Class