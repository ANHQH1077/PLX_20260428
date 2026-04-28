Public Class Class1


    Public Sub New(ByVal p_User_ID As Integer, ByVal p_Company_Code As String, Optional ByVal p_Services As Object = Nothing)

        Dim p_SQL As String = "select * from sys_user where User_id=" & p_User_ID
        Dim p_DataTable As DataTable

        g_Services = p_Services
        g_User_ID = p_User_ID
        '   g_Module = p_Module
        g_Services = p_Services

        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                g_UserName = p_DataTable.Rows(0).Item("USER_NAME").ToString.Trim
            End If
        End If

    End Sub





    'Public Function clsGetDiemTraHang(ByVal p_ChuyenVanTai As String, ByVal p_SapConnectionString As String,
    '                                   ByVal p_dtVariable As DataTable, ByVal p_TimeOut As TimeSpan) As String

    '    clsGetDiemTraHang = GetDiemTraHang(p_ChuyenVanTai, p_SapConnectionString, _
    '                                    p_dtVariable, p_TimeOut)
    'End Function


    'Public Sub New(ByVal p_User_ID As Integer, ByVal p_Company_Code As String, Optional ByVal p_Services As Object = Nothing)

    '    Dim p_SQL As String = "select * from sys_user where User_id=" & p_User_ID
    '    Dim p_DataTable As DataTable

    '    g_Services = p_Services
    '    g_User_ID = p_User_ID
    '    '   g_Module = p_Module
    '    g_Services = p_Services

    '    p_DataTable = GetDataTable(p_SQL, p_SQL)
    '    If Not p_DataTable Is Nothing Then
    '        If p_DataTable.Rows.Count > 0 Then
    '            g_UserName = p_DataTable.Rows(0).Item("USER_NAME").ToString.Trim
    '        End If
    '    End If

    'End Sub




    'Public Function clsTestConnectSAP(ByVal p_Connect As Boolean, ByVal p_ASHOST As String, ByVal p_SYSNR As String, ByVal p_Client As String, _
    '                                ByVal p_User As String, ByVal p_Pass As String, ByRef p_Desc As String) As Boolean
    '    clsTestConnectSAP = mdlTestConnectSAP(p_Connect, p_ASHOST, p_SYSNR, p_Client, p_User, p_Pass, p_Desc)
    'End Function
    'Public Function clsQCI_CalculateQCIThuy(ByVal i_plant As String, _
    '                                     ByVal i_batch As String, _
    '                                     ByRef i_dgv_QCI As System.Data.DataTable,
    '                                     ByRef p_Desc As String) As Boolean
    '    clsQCI_CalculateQCIThuy = mdlQCI_CalculateQCIThuy(i_plant, i_batch, i_dgv_QCI, p_Desc)
    'End Function

    'Public Function clsLenhXuatAuto(ByVal p_Date As Date, ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_User_Name As String, ByVal p_Company_Code As String, _
    '                                    ByRef p_DataTable As System.Data.DataTable, ByVal p_Desc As String) As Boolean

    '    clsLenhXuatAuto = LenhXuatAuto(p_Date, p_Client, p_User_ID, p_User_Name, p_Company_Code, _
    '                                     p_DataTable, p_Desc)
    'End Function


    'Public Function clsSyncDeliveries_SynSpecific(ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_Company_Code As String, ByVal p_SoLenh As String, ByRef p_Desc As String) As Boolean

    '    clsSyncDeliveries_SynSpecific = mdlSyncDeliveries_SynSpecific(p_Client, p_User_ID, p_Company_Code, p_SoLenh, p_Desc)
    'End Function


    ''20160920
    ''anhqh
    ''Them rieng cho KV1
    'Public Function kv1clsSyncDeliveries_SynSpecific(ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_Company_Code As String, ByVal p_SoLenh As String, _
    '                                                    ByRef p_Desc As String, ByVal p_CrDate As Date) As Boolean

    '    kv1clsSyncDeliveries_SynSpecific = KV1mdlSyncDeliveries_SynSpecific(p_Client, p_User_ID, p_Company_Code, p_SoLenh, p_Desc, p_CrDate)
    'End Function


    'Public Function clsSyncDeliveries_DoList(ByVal i_SapConnectionstring As String, ByVal i_date As String, _
    '                                         ByVal _ShPoint As String, ByVal i_TimeOut As String, ByRef o_table As DataTable, _
    '                                         ByRef o_err As String) As Boolean

    '    clsSyncDeliveries_DoList = mdlSyncDeliveries_DoList(i_SapConnectionstring, i_date, _
    '                                           _ShPoint, i_TimeOut, o_table, o_err)
    'End Function


    Public Function clsHTTG_To_ScadarFox(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                   Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_InsertToScadar As Boolean = True,
                                   Optional ByVal p_E5 As Boolean = True) As String
        clsHTTG_To_ScadarFox = mdlHTTG_To_Scadar(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, _
                                     p_Terminal, _
                                     p_InsertToScadar, _
                                     p_E5)
    End Function

    Public Function ClsScadarToHTTG_Fox(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                 Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True, _
                                   Optional ByVal p_E5 As Boolean = True) As String
        ClsScadarToHTTG_Fox = ScadarToHTTG(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, _
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


    'Public Function ClsSyncDeliveries_Httg2Sap(ByVal i_dt_Header As DataTable, ByVal i_dt_Material As DataTable, ByVal i_dt_Details As DataTable,
    '                                            ByRef p_Desc As String) As Boolean
    '    ClsSyncDeliveries_Httg2Sap = mdlSyncDeliveries_Httg2Sap(i_dt_Header, i_dt_Material, i_dt_Details,
    '                                             p_Desc)
    'End Function

    'Public Function clsCheckSAPConnection(ByVal p_SapConnectionString As String, ByRef p_Desc As String) As Boolean
    '    clsCheckSAPConnection = CheckSAPConnection(p_SapConnectionString, p_Desc)
    'End Function

    Public Function clsScadar_HuyTichKe_fox(ByVal p_WareHouse As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "") As String
        clsScadar_HuyTichKe_fox = Scadar_HuyTichKe(p_WareHouse, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Terminal)
    End Function



    Public Function clsB12_UpdateScadar(ByVal p_WareHouse As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "") As String

        clsB12_UpdateScadar = B12_UpdateScadar(p_WareHouse, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Terminal)
    End Function

End Class
