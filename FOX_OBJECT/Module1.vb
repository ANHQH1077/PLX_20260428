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


    Public g_Convert_Font As Boolean = False

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



    Function StringToString(pv_String As String, pv_Str1 As String, pv_Str2 As String) As String
        'Ham chuyen tu string 1 sang string2

        Dim letter As String
        Dim Text1 As String
        Dim Text2 As String
        Dim pv_VNT As String
        Dim pv_Unicode As String
        Dim i, Pos


        pv_VNT = "¸µ¶·¹¨¾»¼½Æ©ÊÇÈÉËÐÌÎÏÑªÕÒÓÔÖÝ×ØÜÞãßáâä«èåæçé¬íêëìîóïñòô­øõö÷ùýúûüþ®¸µ¶·¹¡¡¡¡¡¡¢¢¢¢¢¢ÐÌÎÏÑ££££££Ý×ØÜÞãßáâä¤¤¤¤¤¤¥¥¥¥¥¥óïñòô¦¦¦¦¦¦ýúûüþ§"
        pv_Unicode = "áà?ã?a?????â?????éè???ê?????íì?i?óò?õ?ô?????o?????úù?u?u?????ý????dÁÀ?Ã?A?????Â?????ÉÈ???Ê?????ÍÌ?I?ÓÒ?Õ?Ô?????O?????ÚÙ?U?U?????Ý????Ð"
        Text1 = pv_Str1
        For i = 1 To Len(Text1)
            letter = Mid(Text1, i, 1)
            If (letter = vbCr) Then
                Text2 = Text2 & vbCr
            ElseIf (letter = vbLf) Then
                Text2 = Text2 & vbLf
            Else
                Pos = InStr(pv_Str1, letter)
                If Pos <= 0 Then
                    Text2 = Text2 & letter
                Else
                    Text2 = Text2 & Mid(pv_Str2, Pos, 1)
                End If
            End If
        Next
        StringToString = Text2
    End Function





    Public Function StringConvertFontNew(pv_Str1 As String, Optional UnicodeToVN As Boolean = True) As String
        ' Dim i As Integer
        Dim p_String As String
        Dim i As Integer
        Dim p_count As Integer
        Dim p_Array() As String
        Dim p_Pos As Integer
        '  p_String = pv_Str1
       

        Dim tcvnchars() As String = {"µ", "¸", "¶", "·", "¹",
                                        "¨", "»", "¾", "¼", "½", "Æ",
                                        "©", "Ç", "Ê", "È", "É", "Ë",
                                        "®", "Ì", "Ð", "Î", "Ï", "Ñ",
                                        "ª", "Ò", "Õ", "Ó", "Ô", "Ö",
                                        "×", "Ý", "Ø", "Ü", "Þ",
                                        "ß", "ã", "á", "â", "ä",
                                        "«", "å", "è", "æ", "ç", "é",
                                        "¬", "ê", "í", "ë", "ì", "î",
                                        "ï", "ó", "ñ", "ò", "ô",
                                        "*", "õ", "ø", "ö", "÷", "ù",
                                        "ú", "ý", "û", "ü", "þ",
                                        "¡", "¢", "§", "£", "¤", "¥", "¦"}

        Dim unichars() As String = {"à", "á", "ả", "ã", "ạ",
                                        "ă", "ằ", "ắ", "ẳ", "ẵ", "ặ",
                                        "â", "ầ", "ấ", "ẩ", "ẫ", "ậ",
                                        "đ", "è", "é", "ẻ", "ẽ", "ẹ",
                                        "ê", "ề", "ế", "ể", "ễ", "ệ",
                                        "ì", "í", "ỉ", "ĩ", "ị",
                                        "ò", "ó", "ỏ", "õ", "ọ",
                                        "ô", "ồ", "ố", "ổ", "ỗ", "ộ",
                                        "ơ", "ờ", "ớ", "ở", "ỡ", "ợ",
                                        "ù", "ú", "ủ", "ũ", "ụ",
                                        "ư", "ừ", "ứ", "ử", "ữ", "ự",
                                        "ỳ", "ý", "ỷ", "ỹ", "ỵ",
                                        "Ă", "Â", "Đ", "Ê", "Ô", "Ơ", "Ư"}
       
        'p_String
        p_String = pv_Str1
        p_String = ""
        For i = 1 To Len(pv_Str1)
            If UnicodeToVN = True Then   'Chuyen tu Unicode sang VN3
                p_Pos = Array.IndexOf(unichars, Mid(pv_Str1, i, 1), 0)
                If p_Pos > 0 Then
                    p_String = p_String & tcvnchars(p_Pos)
                Else
                    p_String = p_String & Mid(pv_Str1, i, 1)
                End If
            Else   ' Chuyen tu VN3 sang Unicode

                p_Pos = Array.IndexOf(tcvnchars, Mid(pv_Str1, i, 1), 0)
                If p_Pos > 0 Then
                    p_String = p_String & unichars(p_Pos)
                Else
                    p_String = p_String & Mid(pv_Str1, i, 1)
                End If
            End If

        Next
        StringConvertFontNew = p_String
        
    End Function




    Public Function StringConvertFont(pv_Str1 As String, Optional UnicodeToVN As Boolean = True) As String
        'Ham chuyen tu string 1 sang string2

        Dim letter As String
        Dim Text1 As String
        Dim Text2 As String
        Dim pv_VNT As String
        Dim pv_Unicode As String
        Dim i, Pos

        StringConvertFont = ""
        pv_VNT = "¸µ¶·¹¨¾»¼½Æ©ÊÇÈÉËÐÌÎÏÑªÕÒÓÔÖÝ×ØÜÞãßáâä«èåæçé¬íêëìîóïñòô­øõö÷ùýúûüþ®¸µ¶·¹¡¡¡¡¡¡¢¢¢¢¢¢ÐÌÎÏÑ££££££Ý×ØÜÞãßáâä¤¤¤¤¤¤¥¥¥¥¥¥óïñòô¦¦¦¦¦¦ýúûüþ§"
        pv_Unicode = "áà?ã?a?????â?????éè???ê?????íì?i?óò?õ?ô?????o?????úù?u?u?????ý????dÁÀ?Ã?A?????Â?????ÉÈ???Ê?????ÍÌ?I?ÓÒ?Õ?Ô?????O?????ÚÙ?U?U?????Ý????Ð"

        If UnicodeToVN = True Then
            For i = 1 To Len(pv_Str1)
                Pos = InStr(pv_Str1, Mid(pv_Unicode, i, 1))
                If Pos > 0 Then
                    StringConvertFont = StringConvertFont & Mid(pv_VNT, Pos, 1)

                Else
                    StringConvertFont = StringConvertFont & Mid(pv_Str1, i, 1)
                End If


            Next


        Else
            For i = 1 To Len(pv_Str1)
                Pos = InStr(pv_Str1, Mid(pv_VNT, i, 1))
                If Pos > 0 Then
                    StringConvertFont = StringConvertFont & Mid(pv_Unicode, Pos, 1)
                Else
                    StringConvertFont = StringConvertFont & Mid(pv_Str1, i, 1)
                End If

            Next

        End If
        'Text1 = pv_Str1
        'For i = 1 To Len(Text1)
        '    letter = Mid(Text1, i, 1)
        '    If (letter = vbCr) Then
        '        Text2 = Text2 & vbCr
        '    ElseIf (letter = vbLf) Then
        '        Text2 = Text2 & vbLf
        '    Else
        '        Pos = InStr(pv_Str1, letter)
        '        If Pos <= 0 Then
        '            Text2 = Text2 & letter
        '        Else
        '            Text2 = Text2 & Mid(pv_Str2, Pos, 1)
        '        End If
        '    End If
        'Next
        'StringConvertFont = Text2
    End Function
End Module
