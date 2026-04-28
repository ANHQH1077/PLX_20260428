Public Class Class1

    Public Sub clsGetTankATG_Search(ByVal p_datetime As DateTime, ByRef p_error As Boolean, ByRef p_DesError As String, _
                                 ByVal p_TankList As String, ByRef p_ProdLevel As Double, ByRef p_ProdTemp As Double, ByVal p_DateTimeATG As DateTime)
        GetTankATG_Search(p_datetime, p_error, p_DesError, p_TankList, p_ProdLevel, p_ProdTemp, p_DateTimeATG)
    End Sub



    Public Sub clsGetTankATG(ByVal p_PurposeCode As String, ByVal p_TankHeaderCode As String, ByVal p_Client As String, ByVal p_datetime As DateTime, ByRef p_error As Boolean, ByRef p_DesError As String, ByVal p_TankList As String)
        GetTankATG(p_PurposeCode, p_TankHeaderCode, p_Client, p_datetime, p_error, p_DesError, p_TankList)
    End Sub

    Public Function clsmdlSyncDeliveries_SynSpecificAuto(ByVal l_ztb As Connect2SAP.Str_PhieuXuatTable, ByVal p_Client As String, ByVal p_User_ID As Integer, _
                                                    ByVal p_Company_Code As String, ByVal i_solenh As String, ByRef o_err As String) As Boolean

        clsmdlSyncDeliveries_SynSpecificAuto = mdlSyncDeliveries_SynSpecificAuto(l_ztb, p_Client, p_User_ID, _
                                                         p_Company_Code, i_solenh, o_err)
    End Function


    Public Function clsFPT_GetMaLenh(ByVal p_SoLenh As String) As String
        clsFPT_GetMaLenh = FPT_GetMaLenh(p_SoLenh)
    End Function


    Public Function clsGetDiemTraHang(ByVal p_ChuyenVanTai As String, ByVal p_SapConnectionString As String,
                                       ByVal p_dtVariable As DataTable, ByVal p_TimeOut As TimeSpan) As String

        clsGetDiemTraHang = GetDiemTraHang(p_ChuyenVanTai, p_SapConnectionString, _
                                        p_dtVariable, p_TimeOut)
    End Function


    Public Sub New(ByVal p_User_ID As Integer, ByVal p_Company_Code As String, Optional ByVal p_Services As Object = Nothing)

        Dim p_SQL As String = "select * from sys_user where User_id=" & p_User_ID
        Dim p_DataTable As DataTable

        g_Services = p_Services
        g_User_ID = p_User_ID
        '   g_Module = p_Module
        g_Services = p_Services
        g_Company_Code = p_Company_Code
        p_DataTable = GetDataTable(p_SQL, p_SQL)


        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                g_UserName = p_DataTable.Rows(0).Item("USER_NAME").ToString.Trim
            End If
        End If

        p_SQL = "select * from tblHangHoa_SoLuongSAP"
        p_HangHoa_SoLuongSAP = GetDataTable(p_SQL, p_SQL)


    End Sub




    Public Function clsTestConnectSAP(ByVal p_Connect As Boolean, ByVal p_ASHOST As String, ByVal p_SYSNR As String, ByVal p_Client As String, _
                                    ByVal p_User As String, ByVal p_Pass As String, ByRef p_Desc As String) As Boolean
        clsTestConnectSAP = mdlTestConnectSAP(p_Connect, p_ASHOST, p_SYSNR, p_Client, p_User, p_Pass, p_Desc)
    End Function
    Public Function clsQCI_CalculateQCIThuy(ByVal i_plant As String, _
                                         ByVal i_batch As String, _
                                         ByRef i_dgv_QCI As System.Data.DataTable,
                                         ByRef p_Desc As String) As Boolean
        clsQCI_CalculateQCIThuy = mdlQCI_CalculateQCIThuy(i_plant, i_batch, i_dgv_QCI, p_Desc)
    End Function

    Public Function clsQCI_CalculateQCI_ATG(ByVal i_plant As String, _
                                         ByVal i_batch As String, _
                                         ByRef i_dgv_QCI As System.Data.DataTable,
                                         ByRef p_Desc As String) As Boolean
        clsQCI_CalculateQCI_ATG = mdlQCI_CalculateQCI_ATG(i_plant, i_batch, i_dgv_QCI, p_Desc)
    End Function


    Public Function clsLenhXuatAuto(ByVal p_Date As Date, ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_User_Name As String, ByVal p_Company_Code As String, _
                                        ByRef p_DataTable As System.Data.DataTable, ByRef p_Desc As String) As Boolean

        clsLenhXuatAuto = LenhXuatAuto(p_Date, p_Client, p_User_ID, p_User_Name, p_Company_Code, _
                                         p_DataTable, p_Desc)
    End Function

    'anhqh 20201201
    'Ham dung cho chuc nang dong bo hang loat tren httg
    Public Function clsLenhXuatAuto_HTTG(ByVal p_Date As Date, ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_User_Name As String, ByVal p_Company_Code As String, _
                                        ByRef p_DataTable As System.Data.DataTable, ByRef p_Desc As String, Optional ByVal p_Future As Boolean = False) As Boolean

        clsLenhXuatAuto_HTTG = LenhXuatAuto_HTTG(p_Date, p_Client, p_User_ID, p_User_Name, p_Company_Code, _
                                         p_DataTable, p_Desc, p_Future)
    End Function

    Public Function clsSyncDeliveries_SynSpecific(ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_Company_Code As String, _
                                                  ByVal p_SoLenh As String, ByRef p_Desc As String, ByVal p_Date As Date) As Boolean
        'Select Case p_Company_Code
        '    Case "6610"  'KV2
        '        Dim p_SAP_KV2 As New KV_2_Report.Class1(g_Config_XMLDatatable, _
        '                                                  g_Company_Code, _
        '                                                  g_WareHouse, g_Services, "", "", "", g_Company_Host, _
        '                                                  g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
        '                                                  g_DBPass, g_CompanyAPI)
        '        mdlSyncDeliveries_SynSpecificNew = p_SAP_KV2.ClsSyncDeliveries_SynSpecific(p_SoLenh, p_Desc)
        '        Exit Function
        'End Select
        clsSyncDeliveries_SynSpecific = mdlSyncDeliveries_SynSpecific(p_Client, p_User_ID, p_Company_Code, p_SoLenh, p_Desc, p_Date)
    End Function


    '20160920
    'anhqh
    'Them rieng cho KV1
    Public Function kv1clsSyncDeliveries_SynSpecific(ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_Company_Code As String, ByVal p_SoLenh As String, _
                                                        ByRef p_Desc As String, ByVal p_CrDate As Date, Optional ByVal p_LaiNgay As String = "") As Boolean
        'Select Case p_Company_Code
        '    Case "6610"  'KV2
        '        Dim p_SAP_KV2 As New KV_2_Report.Class1(g_Config_XMLDatatable, _
        '                                                  g_Company_Code, _
        '                                                  g_WareHouse, g_Services, "", "", "", g_Company_Host, _
        '                                                  g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
        '                                                  g_DBPass, g_CompanyAPI)
        '        mdlSyncDeliveries_SynSpecificNew = p_SAP_KV2.ClsSyncDeliveries_SynSpecific(p_SoLenh, p_Desc)
        '        Exit Function
        'End Select
        kv1clsSyncDeliveries_SynSpecific = KV1mdlSyncDeliveries_SynSpecific(p_Client, p_User_ID, p_Company_Code, p_SoLenh, p_Desc, p_CrDate, p_LaiNgay)
    End Function


    Public Function clsSyncDeliveries_DoList(ByVal i_SapConnectionstring As String, ByVal i_date As String, _
                                             ByVal _ShPoint As String, ByVal i_TimeOut As String, ByRef o_table As DataTable, _
                                             ByRef o_err As String) As Boolean

        clsSyncDeliveries_DoList = mdlSyncDeliveries_DoList(i_SapConnectionstring, i_date, _
                                               _ShPoint, i_TimeOut, o_table, o_err)
    End Function



    Public Function clsSyncDeliveries_DoListAuto(ByRef l_ztb As Connect2SapEx.Str_PhieuXuatTable, _
                                                 ByVal i_SapConnectionstring As String, ByVal i_date As String, ByVal i_dateTo As String, _
                                             ByVal _ShPoint As String, ByVal i_TimeOut As String, ByRef o_table As DataTable, _
                                             ByRef o_err As String) As Boolean

        clsSyncDeliveries_DoListAuto = mdlSyncDeliveries_DoListAuto(l_ztb, i_SapConnectionstring, i_date, i_dateTo, _
                                               _ShPoint, i_TimeOut, o_table, o_err)
    End Function



    Public Function clsHTTG_To_Scadar(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                   Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_InsertToScadar As Boolean = True,
                                   Optional ByVal p_E5 As Boolean = True) As String
        clsHTTG_To_Scadar = mdlHTTG_To_Scadar(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, _
                                     p_Terminal, _
                                     p_InsertToScadar, _
                                     p_E5)
    End Function

    Public Function ClsScadarToHTTG(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                 Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True, _
                                   Optional ByVal p_E5 As Boolean = True) As String
        ClsScadarToHTTG = ScadarToHTTG(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, _
                                 p_Terminal, _
                                   p_GetScadarToHTTG, _
                                   p_E5)
    End Function


    Public Function AutoClsScadarToHTTG(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                 Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True, _
                                   Optional ByVal p_E5 As Boolean = True) As String
        AutoClsScadarToHTTG = AutoCheckScadarToHTTG(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, _
                                 p_Terminal, _
                                   p_GetScadarToHTTG, _
                                   p_E5)
    End Function


    Public Function CheckClsScadarToHTTG(ByRef p_TableScadar As DataTable, _
                                        ByRef p_TableScadar_E5 As DataTable, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                 Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True, _
                                   Optional ByVal p_E5 As Boolean = True) As String
        CheckClsScadarToHTTG = CheckScadarToHTTG(p_TableScadar, _
                                         p_TableScadar_E5, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, _
                                 p_Terminal, _
                                   p_GetScadarToHTTG, _
                                   p_E5)
    End Function


    Public Function ClsSyncDeliveries_Httg2Sap(ByVal i_dt_Header As DataTable, ByVal i_dt_Material As DataTable, ByVal i_dt_Details As DataTable,
                                                ByRef p_Desc As String, Optional ByVal p_THN_SoLenh As Boolean = False) As Boolean
        ClsSyncDeliveries_Httg2Sap = mdlSyncDeliveries_Httg2Sap(i_dt_Header, i_dt_Material, i_dt_Details,
                                                 p_Desc, p_THN_SoLenh)
    End Function

    Public Function clsCheckSAPConnection(ByVal p_SapConnectionString As String, ByRef p_Desc As String) As Boolean
        clsCheckSAPConnection = CheckSAPConnection(p_SapConnectionString, p_Desc)
    End Function

    Public Function clsSyncDeliveries_SynSpecificServices(ByVal p_NgayHieuLuc As Boolean, ByVal p_KV1 As Boolean, ByVal p_Client As String, ByVal p_User_ID As Integer, _
                                                    ByVal p_Company_Code As String, ByVal i_solenh As String, ByRef o_err As String, _
                                                    ByVal p_Date As Date, ByVal p_LaiNgay As String, Optional ByVal p_Future As Boolean = False) As Boolean

        If p_NgayHieuLuc = True Then
            clsSyncDeliveries_SynSpecificServices = mdlSyncDeliveries_NgayHieuLuc(p_Client, p_User_ID, p_Company_Code, i_solenh, o_err, p_Date, p_Future)
        Else
            If p_KV1 = True Then
                clsSyncDeliveries_SynSpecificServices = KV1mdlSyncDeliveries_SynSpecific(p_Client, p_User_ID, p_Company_Code, i_solenh, o_err, p_Date, p_LaiNgay, p_Future)
            Else
                clsSyncDeliveries_SynSpecificServices = mdlSyncDeliveries_SynSpecific(p_Client, p_User_ID, p_Company_Code, i_solenh, o_err, p_Date, p_Future)
            End If
        End If


    End Function

    Public Function clsB12_ThongTinHamHang(ByVal p_Do As String) As DataTable
        clsB12_ThongTinHamHang = B12_ThongTinHamHang(p_Do)
    End Function

    Public Sub ClsGET_HTTG_GET_LX_STAGING_AUTO()
        GET_HTTG_GET_LX_STAGING_AUTO()
    End Sub

    Public Sub clsGetLenhXuat(ByVal l_solenh As String, ByVal l_ngayxuat As Date, ByRef p_desc As String)
        GetLenhXuat(l_solenh, l_ngayxuat, p_desc)

    End Sub
End Class
