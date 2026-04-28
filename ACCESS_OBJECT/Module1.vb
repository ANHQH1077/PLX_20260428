Module Module1
    Public g_KV1 As Boolean = False
    Public g_BATCHSLOG As Boolean = False


    Public g_Services As Object
    Public g_User_ID As Integer
    'Public g_Module As Object
    Public g_Company_Code As String

    Private p_SYS_MALENH_S As String = String.Empty

    Public p_QUYDOI_SAP As String = "N"


    Public Constant_P_Bo = "Bo"
    Public Constant_P_Thuy = "Thuy"
    Public Constant_P_eBo = "eBo"
    Public Constant_P_eThuy = "eThuy"
    Public Constant_P_HeSoCongTo = "HeSoCongTo"
    Public Constant_P_eTimeStop = "eTimeStop"
    Public Constant_P_eTimeFlagBo = "eTimeFlagBo"
    Public Constant_P_eTimeFlagThuy = "eTimeFlagThuy"
    Public Constant_P_eTimeDefault = "eTimeDefault"
    Public Constant_P_eMapMaHangHoa = "eMapMaHangHoa"
    Public Constant_P_CheckMetter = "CheckMetter"
    Public Constant_P_MaTuDongHoa = "MaTuDongHoa"
    Public Constant_P_Sat = "Sat"
    Public Constant_P_upThucXuat = "upThucXuat"
    Public Constant_P_eSat = "eSat"
    Public Constant_P_MeterDens = "MeterDens"
    Public Constant_P_FO = "FO"
    Public Constant_P_Password = "Password"
    Public g_Client_E5_Upper As String = ""
    Public g_Client_E5 As String = ""
    Dim i_dt_para As New DataTable

    Public g_UserName As String = ""

    'anhqh
    '20160810

    Public Sub GetClient_E5(ByVal p_Client As String)
        Dim p_SQL As String
        Dim p_DataTable As DataTable


        g_Client_E5_Upper = "E5 XITEC"
        g_Client_E5 = "E5 Xitec"

        p_SQL = "select KEYVALUE from SYS_CONFIG  where KEYCODE='FILTERKHO'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                If p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    g_Client_E5_Upper = p_Client & g_Client_E5_Upper
                    g_Client_E5 = p_Client & g_Client_E5
                End If
            End If
        End If
    End Sub



    Public Sub GetMaVanChuyen(ByVal p_maphuongtien As String, ByVal p_MaVanChuyen As String, ByRef l_mavanchuyen As String)
        Dim p_SQL As String = "select * from tblPara"
        Dim l_mavanchuyen_convert As String

        i_dt_para = GetDataTable(p_SQL, p_SQL)

        l_mavanchuyen = p_MaVanChuyen
        l_mavanchuyen_convert = mdlDelivery_CheckTransmot(l_mavanchuyen, i_dt_para)
        If l_mavanchuyen_convert = "Thuy" Then
            If mdlFunction_GetParaValue(Constant_P_eThuy) = "0" Then
                l_mavanchuyen = p_maphuongtien
            Else
                l_mavanchuyen = mdlFunction_GetParaValue(Constant_P_eThuy)
            End If
        ElseIf l_mavanchuyen_convert = "Bo" Then
            If mdlFunction_GetParaValue(Constant_P_eBo) = "0" Then
                l_mavanchuyen = p_maphuongtien
            Else
                l_mavanchuyen = mdlFunction_GetParaValue(Constant_P_eBo)
            End If
        ElseIf l_mavanchuyen_convert = "Sat" Then
            If mdlFunction_GetParaValue(Constant_P_eSat) = "0" Then
                l_mavanchuyen = p_maphuongtien
            Else
                l_mavanchuyen = mdlFunction_GetParaValue(Constant_P_eSat)
            End If
        End If


    End Sub


    Public Function mdlDelivery_CheckTransmot(ByVal i_mavanchuyen As String, ByVal i_dt_para As DataTable) As String
        Dim l_bo, _
            l_thuy, _
            l_sat As String()

        Try
            '----------------------------------------------------------------
            '   Para:
            '       Index 0: Bo
            '       Index 1: Thuy
            '----------------------------------------------------------------
            l_bo = i_dt_para.Rows(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            l_thuy = i_dt_para.Rows(1).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)

            'FES KV2
            '20141014
            '            l_sat = i_dt_para.Rows(12).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)

            For i As Integer = 0 To l_bo.Length - 1
                If l_bo(i).Trim() = i_mavanchuyen.Trim() Then
                    Return "Bo"
                End If
            Next

            For i As Integer = 0 To l_thuy.Length - 1
                If l_thuy(i).Trim() = i_mavanchuyen.Trim() Then
                    Return "Thuy"
                End If
            Next

            For i As Integer = 0 To l_sat.Length - 1
                If l_sat(i).Trim() = i_mavanchuyen.Trim() Then
                    Return "Sat"
                End If
            Next

            Return String.Empty

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Function mdlFunction_GetParaValue(ByVal i_paraname As String) As String
        Try
            Dim l_dr As DataRow()
            l_dr = i_dt_para.Select("Para = '" & i_paraname & "'")

            If l_dr.Length > 0 Then
                Return l_dr(0).Item("Value_nd").ToString().Trim()
            End If

            Return String.Empty
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function


    Public Function GetDataTable(ByVal p_SQL As String, ByVal p_Error As String) As DataTable
        Dim p_Datatable As DataTable
        Try
            p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message
            'ShowMessageBox(Err.Number, p_Error)
            Return Nothing
        End Try
        Return p_Datatable

    End Function



    Public Sub p_GetDateTime(ByRef p_Date As Date, ByRef p_Time As Integer)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        p_SQL = "select  convert(date, getdate()) as SysDate, replace(CONVERT(VARCHAR(5),DATEADD(MINUTE,0 ,GETDATE()),108),':','') as SysTime"
        p_Datatable = g_Services.mod_SYS_GET_DATATABLE(p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SysDate")
                p_Time = p_Datatable.Rows(0).Item("SysTime")
            End If
        End If
        p_Datatable = Nothing
    End Sub

    Public Function mdlQCI_ConvertTemp(ByVal i_temp As String) As String
        Try
            Dim l_temp As String()
            Dim l_dec0 As Integer
            Dim l_dec1 As Decimal
            Dim l_step_h As Decimal = 12.5

            l_temp = i_temp.Split(".")

            If l_temp.Length = 1 Then
                Return l_temp(0) & ".00"
            End If

            If l_temp.Length = 2 Then
                l_dec0 = l_temp(0)

                If l_temp(1).Length = 0 Then
                    l_temp(1) = "00"
                ElseIf l_temp(1).Length = 1 Then
                    l_temp(1) = l_temp(1) & "0"
                End If

                l_dec1 = l_temp(1)

                If (Convert.ToInt32(l_dec1) Mod 25) = 0 Then
                    Return i_temp
                End If

                l_dec1 = l_dec1 + 25

                If l_dec1 >= (100 + l_step_h) Then
                    l_temp(0) = (l_dec0 + 1).ToString()
                    l_temp(1) = "00"
                    Return l_temp(0) & "." & l_temp(1)
                End If

                If l_dec1 >= (75 + l_step_h) Then
                    Return l_temp(0) & ".75"
                End If

                If l_dec1 >= (50 + l_step_h) Then
                    Return l_temp(0) & ".50"
                End If

                If l_dec1 >= (25 + l_step_h) Then
                    Return l_temp(0) & ".25"
                End If

                Return l_temp(0) & ".00"
            End If

            Return i_temp

        Catch ex As Exception
            Return i_temp
        End Try
    End Function

    Public Function mdlCryptor_Decrypt(ByVal cipherText As String, ByVal Key As String) As String

        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""
        Try
            Dim hash(31) As Byte
            Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(Key))
            Array.Copy(temp, 0, hash, 0, 16)
            Array.Copy(temp, 0, hash, 15, 16)
            AES.Key = hash
            AES.Mode = System.Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(cipherText)
            decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return decrypted
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


    Public Function GetDataSet(ByVal p_SQL As String, ByVal p_Error As String) As DataSet
        Dim p_Datatable As DataSet
        Try
            p_Datatable = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message


            Return Nothing
        End Try
        Return p_Datatable

    End Function

End Module
