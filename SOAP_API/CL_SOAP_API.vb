Imports System.ServiceModel

Public Class CL_SOAP_API
    Public g_LinkServiceLMS As String = ""
    Public g_UserNameLMS As String = ""
    Public g_PassLMS As String = ""
    Public g_UserNameLMS_Cert As String = ""
    Public g_PassLMS_Cert As String = ""
    Public g_User As String = ""
    Dim p_TimeOut As Integer = 100000

    Public Sub New(ByVal p_User As String)
        Dim p_DataTable As DataTable
        Dim p_ArrRow As DataRow
        Dim p_Connect As New FPTBUSSINESS.Class1
        Dim p_SQL As String = "select * from SYS_CONFIG"
        Dim p_Int As Integer
        Dim p_Error As String
        g_User = p_User
        p_DataTable = p_Connect.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Error)

        For p_Int = 0 To p_DataTable.Rows.Count - 1
            p_ArrRow = p_DataTable.Rows.Item(p_Int)
            Select Case UCase(p_ArrRow.Item("KeyCode"))
                Case UCase("LMSLinkServices")
                    g_LinkServiceLMS = p_ArrRow.Item("KeyValue").ToString.Trim
                Case UCase("LMSUserName")
                    g_UserNameLMS = p_ArrRow.Item("KeyValue").ToString.Trim
                Case UCase("LMSPass")
                    g_PassLMS = p_ArrRow.Item("KeyValue").ToString.Trim
                Case UCase("LMSUserName_cert")
                    g_UserNameLMS_Cert = p_ArrRow.Item("KeyValue").ToString.Trim
                Case UCase("LMSPass_cert")
                    g_PassLMS_Cert = p_ArrRow.Item("KeyValue").ToString.Trim
            End Select
        Next
    End Sub



    Public Function GetDensity(ByVal TankCoce As String, ByVal Product As String) As String
        Dim p_EndPointAddress As String = g_LinkServiceLMS
        Dim remoteAddress = New EndpointAddress(New Uri(p_EndPointAddress))
        Dim p_Binding As BasicHttpBinding
        Dim p_Client As LMS_SOAP.LMSAPISoapClient
        Dim p_Table As DataTable
        Dim p_Rows() As DataRow
        Dim p_Density As Decimal


        If InStr(UCase(p_EndPointAddress), UCase("https"), CompareMethod.Text) > 0 Then
            p_Binding = New BasicHttpBinding(BasicHttpSecurityMode.Transport)
        Else
            p_Binding = New BasicHttpBinding()
        End If

        p_Binding.SendTimeout = New TimeSpan(0, 0, 0, 0, p_TimeOut)

        Try
            p_Client = New LMS_SOAP.LMSAPISoapClient(p_Binding, remoteAddress)
            p_Table = p_Client.GetDensityOfPipeHeadOrTankByDateTime(TankCoce, DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff"), g_UserNameLMS, g_PassLMS)
            If p_Table Is Nothing Then
                MsgBox(TankCoce + "-GetDensity: Lỗi API LMS", MsgBoxStyle.OkOnly, "Error")
                Return Nothing
            End If

            p_Rows = p_Table.Select()

            'If p_Rows.Length > 0 And Product = p_Rows(0)("productnameid") Then
            '    p_Density = p_Rows(0)("density2").ToString.Trim.Substring(0, 6)
            'End If

            If p_Rows.Length > 0 Then
                p_Density = p_Rows(0)("density2").ToString.Trim.Substring(0, 6)
            End If

            Return p_Density
        Catch ex As Exception
            MsgBox(TankCoce + "-GetDensity: Lỗi API LMS", MsgBoxStyle.OkOnly, "Error")
            Return Nothing
        End Try
    End Function



    Public Function GetValueFromVehicle(ByVal MaPhuongTien As String, ByVal NgayThang As String, ByVal p_SotichKe As String) As DataTable

        Dim p_EndPointAddress As String = g_LinkServiceLMS
        Dim remoteAddress = New EndpointAddress(New Uri(p_EndPointAddress))
        Dim p_Binding As BasicHttpBinding
        Dim p_Client As LMS_SOAP.LMSAPISoapClient
        Dim p_Table, p_Table01 As DataTable
        'Dim p_Rows() As DataRow
        Dim p_Rows As DataRow
        Dim p_Row_Add As DataRow
        Dim p_SQL As String
        Dim p_Density As Decimal
        Dim p_CertNo As String = ""
        Dim p_fptbusineee As New FPTBUSSINESS.Class1
        Dim p_Datatable As New DataTable("SQL_TXT")
        p_Datatable.Columns.Add("TXT_FIELD")
        ' p_TimeOut As Integer = 100000
        Dim p_int As Integer
        If InStr(UCase(p_EndPointAddress), UCase("https"), CompareMethod.Text) > 0 Then
            p_Binding = New BasicHttpBinding(BasicHttpSecurityMode.Transport)
        Else
            p_Binding = New BasicHttpBinding()
        End If

        p_Binding.SendTimeout = New TimeSpan(0, 0, 0, 0, p_TimeOut)

        Try
            p_Client = New LMS_SOAP.LMSAPISoapClient(p_Binding, remoteAddress)
            p_Table = p_Client.GetValueFromVehicle(MaPhuongTien, NgayThang, g_UserNameLMS_Cert, g_PassLMS_Cert)   'DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff")
            If p_Table Is Nothing Then
                MsgBox(MaPhuongTien + "-GetValueFromVehicle: Lỗi API LMS", MsgBoxStyle.OkOnly, "Error")
                Return Nothing
            End If
            For p_int = 0 To p_Table.Rows.Count - 1
                p_Rows = p_Table.Rows(p_int)
                p_SQL = "exec  dbo.[FPT_GetVehicleCertNum]  '" & g_User & "'"
                p_Table01 = p_fptbusineee.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If Not p_Table01 Is Nothing Then
                    If p_Table01.Rows.Count > 0 Then
                        p_CertNo = p_Table01.Rows(0).Item(0).ToString.Trim
                    End If
                End If
                p_SQL = "MERGE tblPhuongTien_Cert AS tgt " & _
                           " USING (SELECT  '" & p_CertNo & "' as CertNo, '" & MaPhuongTien.ToString.Trim & "' as MaPhuongTien,'" & p_SotichKe.ToString.Trim & "' as SoTichKe,'" & NgayThang & "' as [NgayXuat],'" & p_Rows.Item("FormRequestCode").ToString.Trim & "' as [FormRequestCode] " & _
                                   ",'" & p_Rows.Item("TiTrong").ToString.Trim & "' as [TiTrong],'" & p_Rows.Item("DoDanDien").ToString.Trim & "' as [DoDanDien] ,'" & p_Rows.Item("NhietDo").ToString.Trim & "' as [NhietDo],'" & p_Rows.Item("MauSacSayBolt").ToString.Trim & "' as [MauSacSayBolt]," & _
                                   " N'" & p_Rows.Item("KiemTraBeNgoai").ToString.Trim & "' as [KiemTraBenNgoai],'" & p_Rows.Item("KhoXuat").ToString.Trim & "' as [KhoXuat],'" & p_Rows.Item("FormRequestDate").ToString.Trim & "' as [FormRequestDate] " & _
                                   ",'" & p_Rows.Item("MaHangHoa").ToString.Trim & "' as [MaHangHoa],'" & p_Rows.Item("SoBon").ToString.Trim & "' as [SoBon],'" & p_Rows.Item("NiemGiao").ToString.Trim & "' as [NiemGiao],'" & p_Rows.Item("IsTankSplit").ToString.Trim & "' as [IsTankSplit]," & _
                                   " '" & p_Rows.Item("TiTrongTren").ToString.Trim & "' as [TiTrongTren],'" & p_Rows.Item("TiTrongGiua").ToString.Trim & "' as [TiTrongGiua],'" & p_Rows.Item("TiTrongDuoi").ToString.Trim & "' as [TiTrongDuoi] " & _
                                   ",'" & p_Rows.Item("FormRequestCodeSeperationLayer").ToString.Trim & "' as [FormRequestCodeSeperationLayer],'" & p_Rows.Item("FormRequestDateSeperationLayer").ToString.Trim & "' as [FormRequestDateSeperationLayer],'" & g_User & "' as  [CrUser] " & _
                          " ) AS src(CertNo, [MaPhuongTien],[SoTichKe],[NgayXuat],[FormRequestCode] " & _
                                   ",[TiTrong],[DoDanDien] ,[NhietDo],[MauSacSayBolt],[KiemTraBenNgoai],[KhoXuat],[FromRequestDate] " & _
                                   ",[MaHangHoa],[SoBon],[NiemGiao],[IsTankSplit],[TiTrongTren],[TiTrongGiua],[TiTrongDuoi] " & _
                                   ",[FormRequestCodeSeperationLayer],[FormRequestDateSeperationLayer],[CrUser]) " & _
                                    " ON (tgt.[MaPhuongTien] = src.[MaPhuongTien] and tgt.[FormRequestCode] = src.[FormRequestCode] ) " & _
                            "WHEN NOT MATCHED THEN " & _
                                   " INSERT (CertNo,[MaPhuongTien],[SoTichKe],[NgayXuat],[FormRequestCode] " & _
                                   ",[TiTrong],[DoDanDien] ,[NhietDo],[MauSacSayBolt],[KiemTraBenNgoai],[KhoXuat],[FromRequestDate] " & _
                                   ",[MaHangHoa],[SoBon],[NiemGiao],[IsTankSplit],[TiTrongTren],[TiTrongGiua],[TiTrongDuoi] " & _
                                   ",[FormRequestCodeSeperationLayer],[FormRequestDateSeperationLayer],[CrUser]) " & _
                                 "VALUES (src.CertNo, src.[MaPhuongTien],src.[SoTichKe],src.[NgayXuat],src.[FormRequestCode] " & _
                                   ",src.[TiTrong],src.[DoDanDien] ,src.[NhietDo],src.[MauSacSayBolt],src.[KiemTraBenNgoai],src.[KhoXuat],src.[FromRequestDate] " & _
                                   ",src.[MaHangHoa],src.[SoBon],src.[NiemGiao],src.[IsTankSplit],src.[TiTrongTren],src.[TiTrongGiua],src.[TiTrongDuoi] " & _
                                   ",src.[FormRequestCodeSeperationLayer],src.[FormRequestDateSeperationLayer],src.[CrUser]);"
                p_Row_Add = p_Datatable.NewRow
                p_Row_Add.Item(0) = p_SQL
                p_Datatable.Rows.Add(p_Row_Add)
            Next


            'If p_Rows.Length > 0 And Product = p_Rows(0)("productnameid") Then
            '    p_Density = p_Rows(0)("density2").ToString.Trim.Substring(0, 6)
            'End If

            'If p_Rows.Length > 0 Then
            '    p_Density = p_Rows(0)("density2").ToString.Trim.Substring(0, 6)
            'End If

            Return p_Datatable
        Catch ex As Exception
            MsgBox(MaPhuongTien + "-GetValueFromVehicle: " & ex.Message, MsgBoxStyle.OkOnly, "Error")
            Return p_Datatable
        End Try
    End Function


    Public Function GetValueFromTankCode(ByVal TankCoce As String, ByVal NgayThang As String, ByVal p_GioKTNhap As String, ByVal p_ThoiGianOnDinh As Integer, ByVal p_HovaTen As String, ByVal p_ChucDanh As String) As DataTable
        Dim p_EndPointAddress As String = g_LinkServiceLMS
        Dim remoteAddress = New EndpointAddress(New Uri(p_EndPointAddress))
        Dim p_Binding As BasicHttpBinding
        Dim p_Client As LMS_SOAP.LMSAPISoapClient
        Dim p_Table, p_Datatable As DataTable
        Dim p_Rows As DataRow
        Dim p_Density As Decimal
        Dim p_SQL As String
        Dim p_Row_Add As DataRow

        If InStr(UCase(p_EndPointAddress), UCase("https"), CompareMethod.Text) > 0 Then
            p_Binding = New BasicHttpBinding(BasicHttpSecurityMode.Transport)
        Else
            p_Binding = New BasicHttpBinding()
        End If

        p_Datatable = New DataTable("SQL_TXT")
        p_Datatable.Columns.Add("SQL_TXT")
        p_Binding.SendTimeout = New TimeSpan(0, 0, 0, 0, p_TimeOut)

        Try
            p_Client = New LMS_SOAP.LMSAPISoapClient(p_Binding, remoteAddress)
            p_Table = p_Client.GetValueFromTankCode(TankCoce, NgayThang & " " & p_GioKTNhap, g_UserNameLMS_Cert, g_PassLMS_Cert)   'DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff")
            If p_Table Is Nothing Then
                MsgBox("GetValueFromTankCode: Lỗi API LMS", MsgBoxStyle.OkOnly, "Error")
                Return Nothing
            End If

            For p_int = 0 To p_Table.Rows.Count - 1
                p_Rows = p_Table.Rows(p_int)
                p_SQL = "MERGE tblTank_Cert AS tgt " & _
                           " USING (SELECT '" & CDate(NgayThang & " " & p_GioKTNhap).ToString("yyyyMMdd HH:mm:ss") & "' as [NgayKTNhap],null as [GioKTNhap]," & p_ThoiGianOnDinh & " as [ThoiGianOnDinh],'" & p_HovaTen & "' as  [HovaTen],'" & p_ChucDanh & "' as [ChucDanh]," & _
                            " '" & p_Rows.Item("FormRequestCode").ToString.Trim & "' as  [FormRequestCode],'" & p_Rows.Item("titrong").ToString.Trim & "' as  [titrong],'" & p_Rows.Item("dodandien").ToString.Trim & "' as [dodandien] " & _
                                ",'" & p_Rows.Item("nhietdo").ToString.Trim & "' as [nhietdo], N'" & p_Rows.Item("mausacsaybolt").ToString.Trim & "' as [mausacsaybolt],N'" & p_Rows.Item("kiemtrabengoai").ToString.Trim & "' as [kiemtrabengoai]," & _
                                " '" & p_Rows.Item("khoxuat").ToString.Trim & "' as [khoxuat],'" & CDate(p_Rows.Item("FormRequestDate")).ToString("yyyyMMdd") & "' as [FormRequestDate],'" & p_Rows.Item("MaHangHoa").ToString.Trim & "' as  [MaHangHoa],'" & p_Rows.Item("TenHangHoa").ToString.Trim & "' as [TenHangHoa] " & _
                                ",'" & p_Rows.Item("SoBon").ToString.Trim & "' as [SoBon],'" & p_Rows.Item("NiemGiao").ToString.Trim & "' as [NiemGiao],'" & p_Rows.Item("titrongtren").ToString.Trim & "' as [titrongtren]," & _
                                " '" & p_Rows.Item("titronggiua").ToString.Trim & "' as  [titronggiua],'" & p_Rows.Item("titrongduoi").ToString.Trim & "' as  [titrongduoi],N'" & p_Rows.Item("ghichutachlop").ToString.Trim & "' as  [ghichutachlop],N'" & p_Rows.Item("issplit").ToString.Trim & "' as [issplit] " & _
                                ",'" & p_Rows.Item("FormRequestCodeSeparationLayer").ToString.Trim & "' as  [FormRequestCodeSeperationLayer] ,'" & CDate(p_Rows.Item("FormRequestDateSeparationLayer")).ToString("yyyyMMdd HH:mm:ss") & "'  as [FormRequestDateSeperationLayer] " & _
                                ",'" & g_User & "' as [CrUser] " & _
                          " ) AS src([NgayKTNhap],[GioKTNhap],[ThoiGianOnDinh],[HovaTen],[ChucDanh],[FormRequestCode],[titrong],[dodandien] " & _
                                  ",[nhietdo],[mausacsaybolt],[kiemtrabengoai],[khoxuat],[FormRequestDate],[MaHangHoa],[TenHangHoa] " & _
                                  ",[SoBon],[NiemGiao],[titrongtren],[titronggiua],[titrongduoi],[ghichutachlop],[issplit] " & _
                                  ",[FormRequestCodeSeperationLayer] ,[FormRequestDateSeperationLayer] " & _
                                  ",[CrUser]) " & _
                                    " ON (tgt.[SoBon] = src.[SoBon] and tgt.[FormRequestCode] = src.[FormRequestCode] ) " & _
                            "WHEN NOT MATCHED THEN " & _
                                   " INSERT ([NgayKTNhap],[GioKTNhap],[ThoiGianOnDinh],[HovaTen],[ChucDanh],[FormRequestCode],[titrong],[dodandien] " & _
                                                  ",[nhietdo],[mausacsaybolt],[kiemtrabengoai],[khoxuat],[FormRequestDate],[MaHangHoa],[TenHangHoa] " & _
                                                  ",[SoBon],[NiemGiao],[titrongtren],[titronggiua],[titrongduoi],[ghichutachlop],[issplit] " & _
                                                  ",[FormRequestCodeSeperationLayer] ,[FormRequestDateSeperationLayer] " & _
                                                  ",[CrUser]) " & _
                                 "VALUES (src.[NgayKTNhap],src.[GioKTNhap],src.[ThoiGianOnDinh],src.[HovaTen],src.[ChucDanh],src.[FormRequestCode],src.[titrong],src.[dodandien] " & _
                                  ",src.[nhietdo],src.[mausacsaybolt],src.[kiemtrabengoai],src.[khoxuat],src.[FormRequestDate],src.[MaHangHoa],src.[TenHangHoa] " & _
                                  ",src.[SoBon],src.[NiemGiao],src.[titrongtren],src.[titronggiua],src.[titrongduoi],src.[ghichutachlop],src.[issplit] " & _
                                  ",src.[FormRequestCodeSeperationLayer] ,src.[FormRequestDateSeperationLayer] " & _
                                  ",src.[CrUser]);"
                p_Row_Add = p_Datatable.NewRow
                p_Row_Add.Item(0) = p_SQL
                p_Datatable.Rows.Add(p_Row_Add)
            Next
            Return p_Datatable
        Catch ex As Exception
            MsgBox("GetValueFromTankCode: " & ex.Message, MsgBoxStyle.OkOnly, "Error")
            Return Nothing
        End Try
    End Function


End Class
