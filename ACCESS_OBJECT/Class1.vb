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





    Public Function clsHTTG_To_ScadarAccess(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                   Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_InsertToScadar As Boolean = True,
                                   Optional ByVal p_E5 As Boolean = True) As String
        clsHTTG_To_ScadarAccess = mdlHTTG_To_Scadar(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, _
                                     p_Terminal, _
                                     p_InsertToScadar, _
                                     p_E5)
    End Function

    Public Function ClsScadarToHTTG_Access(ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
                                 Optional ByVal p_Terminal As String = "", _
                                   Optional ByVal p_GetScadarToHTTG As Boolean = True, _
                                   Optional ByVal p_E5 As Boolean = True) As String
        ClsScadarToHTTG_Access = ScadarToHTTG(p_TypeIn, p_SoLenh, g_LoaiVanChuyen, _
                                 p_Terminal, _
                                   p_GetScadarToHTTG, _
                                   p_E5)
    End Function


    'Public Function CheckClsScadarToHTTG(ByRef p_TableScadar As DataTable, _
    '                                    ByRef p_TableScadar_E5 As DataTable, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, _
    '                             Optional ByVal p_Terminal As String = "", _
    '                               Optional ByVal p_GetScadarToHTTG As Boolean = True, _
    '                               Optional ByVal p_E5 As Boolean = True) As String
    '    CheckClsScadarToHTTG = CheckScadarToHTTG(p_TableScadar, _
    '                                     p_TableScadar_E5, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, _
    '                             p_Terminal, _
    '                               p_GetScadarToHTTG, _
    '                               p_E5)
    'End Function


    Public Function clsScadar_HuyTichKe_Access(ByVal p_WareHouse As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "") As String
        clsScadar_HuyTichKe_Access = Scadar_HuyTichKe(p_WareHouse, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Terminal)
    End Function


    Public Function clsB12_UpdateScadar(ByVal p_WareHouse As String, ByVal p_TypeIn As String, ByVal p_SoLenh As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "") As String

        clsB12_UpdateScadar = B12_UpdateScadar(p_WareHouse, p_TypeIn, p_SoLenh, g_LoaiVanChuyen, p_Terminal)
    End Function
End Class
