Module Module2

    Public Function SoToChu(ByVal fv_Number As String) As String
        Dim fv_Tram As String = ""
        Dim fv_Nghin As String = ""
        Dim fv_Trieu As String = ""
        Dim fv_Tmp As String = ""
        Dim fv_Ty As String = ""
        Dim fv_NghinTy As String = ""

        Dim fv_Ketqua As String = ""

        fv_Ketqua = ""
        fv_Tmp = fv_Number
        fv_Tmp = Replace(fv_Tmp, ",", "")
        fv_Tmp = Replace(fv_Tmp, " ", "")
        fv_Tmp = Replace(fv_Tmp, ".", "")
        If fv_Tmp = "" Then GoTo TT
        If Len(fv_Tmp) < 3 Then
            fv_Tram = fv_Tach_Tram(fv_Tmp)
            fv_Tmp = ""
        Else
            fv_Tram = fv_Tach_Tram(Right(fv_Tmp, 3))
            fv_Tmp = Left(fv_Tmp, Len(fv_Tmp) - 3)
        End If
        fv_Tram = fv_Tram & " đồng. "
        If fv_Tmp = "" Then GoTo TT
        If Len(fv_Tmp) < 3 Then
            fv_Nghin = fv_Tach_Tram(fv_Tmp, " nghìn ")
            fv_Tmp = ""
        Else
            fv_Nghin = fv_Tach_Tram(Right(fv_Tmp, 3), " nghìn ")
            fv_Tmp = Left(fv_Tmp, Len(fv_Tmp) - 3)
        End If
        If fv_Tmp = "" Then GoTo TT
        If Len(fv_Tmp) < 3 Then
            fv_Trieu = fv_Tach_Tram(fv_Tmp, " triệu ")
            fv_Tmp = ""
        Else
            fv_Trieu = fv_Tach_Tram(Right(fv_Tmp, 3), " triệu ")
            fv_Tmp = Left(fv_Tmp, Len(fv_Tmp) - 3)
        End If
        If fv_Tmp = "" Then GoTo TT
        If Len(fv_Tmp) < 3 Then
            fv_Ty = fv_Tach_Tram(fv_Tmp, " tỷ ")
            fv_Tmp = ""
        Else
            fv_Ty = fv_Tach_Tram(Right(fv_Tmp, 3), " tỷ ")
            fv_Tmp = Left(fv_Tmp, Len(fv_Tmp) - 3)
        End If
        If fv_Tmp = "" Then GoTo TT
        If Len(fv_Tmp) < 3 Then
            fv_NghinTy = fv_Tach_Tram(fv_Tmp, " nghìn ")
            fv_Tmp = ""
        Else
            fv_NghinTy = fv_Tach_Tram(Right(fv_Tmp, 3), " nghìn ")
            fv_Tmp = Left(fv_Tmp, Len(fv_Tmp) - 3)
        End If

TT:
        If fv_Tram <> "" Then fv_Ketqua = fv_Tram
        If fv_Nghin <> "" Then fv_Ketqua = fv_Nghin & fv_Ketqua
        If fv_Trieu <> "" Then fv_Ketqua = fv_Trieu & fv_Ketqua
        If fv_Ty <> "" Then fv_Ketqua = fv_Ty & fv_Ketqua
        If fv_NghinTy <> "" Then fv_Ketqua = fv_NghinTy & fv_Ketqua

        While InStr(1, fv_Ketqua, "  ") > 0
            fv_Ketqua = Trim(Replace(fv_Ketqua, "  ", " "))
        End While
        fv_Tmp = Trim(fv_Tmp)
        'SoToChu = fv_Ketqua

        Dim array() As Char = fv_Ketqua.ToCharArray

        ' Uppercase first character.
        array(0) = Char.ToUpper(array(0))

        ' Return new string.
        Return New String(array)
    End Function



    Private Function fv_Tach_Tram(ByVal fv_Number As String, Optional ByVal fv_Loai As String = "") As String
        Dim fv_Number_Arr() As String = {"không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín", "mười", "mốt"}
        Dim fv_Tram As String
        Dim fv_Le As String
        Dim fv_Str As String
        Dim fv_Space As String
        Dim fv_Muoi As String

        fv_Space = " "
        fv_Le = "lẻ"
        fv_Tram = "trăm"
        fv_Muoi = "mươi"

        fv_Tach_Tram = ""
        fv_Str = fv_Number
        If fv_Number = "" Then Exit Function
        'fv_Number_Arr = Array("kh«ng", "mét", "hai", "ba", "bèn", "n¨m", "s¸u", "b¶y", "t¸m", "chÝn", "m­êi", "mèt")
        If fv_Str <> "000" Then
            While Len(fv_Str) >= 1
                Select Case Len(fv_Str)
                    Case 3
                        fv_Tach_Tram = fv_Tach_Tram & (fv_Number_Arr(Left(fv_Str, 1))) & fv_Space & fv_Tram & fv_Space
                    Case 2

                        If Val(fv_Str) > 10 Then
                            If Left(fv_Str, 1) <> "1" Then
                                fv_Tach_Tram = fv_Tach_Tram & (fv_Number_Arr(Left(fv_Str, 1))) & fv_Space & fv_Muoi
                            Else
                                fv_Tach_Tram = fv_Tach_Tram & (fv_Number_Arr(10)) & fv_Space
                            End If
                        Else
                            If Val(fv_Str) = 10 Then
                                fv_Tach_Tram = fv_Tach_Tram & (fv_Number_Arr(10)) & fv_Space
                            Else
                                If Val(fv_Str) > 0 Then
                                    fv_Tach_Tram = fv_Tach_Tram & fv_Space & fv_Le
                                End If
                            End If
                        End If
                    Case 1
                        If Val(fv_Str) > 0 Then
                            If InStr(1, fv_Tach_Tram, fv_Muoi) > 0 And Val(fv_Str) = 1 Then
                                '  If Val(fv_Str) = 1 Then
                                fv_Tach_Tram = fv_Tach_Tram & fv_Space & fv_Number_Arr(11)
                                '  Else

                                '  End If
                            Else
                                fv_Tach_Tram = fv_Tach_Tram & fv_Space & fv_Number_Arr(Left(fv_Str, 1))
                                '  fv_Tach_Tram = fv_Tach_Tram & fv_Space & fv_Number_Arr(1)
                            End If
                        End If
                End Select
                fv_Str = Right(fv_Str, Len(fv_Str) - 1)
            End While
        End If
        If fv_Tach_Tram <> "" Then
            fv_Tach_Tram = fv_Tach_Tram & fv_Loai
        End If
    End Function

    Public Function CheckDO_Infor(ByVal p_SoLenh As String, ByVal p_LoaiHinhVanChuyen As String, ByVal p_SMO_BO As Boolean, ByVal p_SMO_BO_R As Boolean, _
                                  ByVal p_SMO_THUY As Boolean, ByVal p_SMO_THUY_R As Boolean, ByVal p_PhuongTien As String, _
                                  ByRef p_TableExe As DataTable, ByVal p_CheckDO As Boolean, ByRef p_PhuongTienSMO As String) As Boolean
        Dim p_InterfaceSMO As New SMOInterface.Class1(g_LinkServicesSMO, g_UserNameSMO, g_PassSMO, g_Company_Code)
        Dim p_Error As String = ""
        Dim p_SQL As String = ""
        Dim p_Table As DataTable
        Try
            CheckDO_Infor = False
            If p_SMO_BO = False And p_SMO_THUY = False Then
                Return True
            End If

            If g_Company_Code = "6610" Or g_Company_Code = "6680" Then
                If g_WareHouse = "6681" Then
                    If p_InterfaceSMO.clsVungtau_DO_Infor(p_SoLenh, p_Error, p_PhuongTien, p_TableExe, p_CheckDO, p_PhuongTienSMO) = False Then
                        ShowMessageBox("", p_Error)
                        Return False
                    End If
                    If p_PhuongTienSMO <> "" Then
                        p_SQL = "select KEYVALUE from sys_config where keyCode ='PTIEN_AO'  and CHARINDEX ('," & p_PhuongTienSMO & ",',',' + KEYVALUE +',' ,1)  >0 "
                        p_Table = GetDataTable(p_SQL, p_SQL)
                        If Not p_Table Is Nothing Then
                            If p_Table.Rows.Count > 0 Then
                                p_Error = "Phương tiện SMO chưa khai báo"
                                ShowMessageBox("", p_Error)
                                Return False
                            End If
                        End If
                    End If
                    Return True
                Else

                    If p_InterfaceSMO.clsKV2_DO_Infor(p_SoLenh, p_Error, p_PhuongTien, p_TableExe, p_CheckDO, p_PhuongTienSMO) = False Then
                        ShowMessageBox("", p_Error)
                        Return False
                    End If

                    Return True
                End If
            End If

                Select Case UCase(p_LoaiHinhVanChuyen)
                    Case "BO"
                        If p_SMO_BO = True Then
                            If p_InterfaceSMO.clsKV2_DO_Infor(p_SoLenh, p_Error, p_PhuongTien, p_TableExe, p_CheckDO, p_PhuongTienSMO) = False Then
                                ShowMessageBox("", p_Error)
                                Return False
                            End If
                        End If
                    Case "THUY"
                        If p_SMO_THUY = True Then
                            If p_InterfaceSMO.clsKV2_DO_Infor(p_SoLenh, p_Error, p_PhuongTien, p_TableExe, p_CheckDO, p_PhuongTienSMO) = False Then
                                ShowMessageBox("", p_Error)
                                Return False
                            End If
                        End If
                    Case Else

                End Select
                'End If

                CheckDO_Infor = True
        Catch ex As Exception

        End Try
    End Function

    Public Sub UpdateStatusDO(ByVal p_InterSMO As Boolean, ByVal p_DoNumberIN As String, ByVal p_Status As String)
        If p_InterSMO = True Then
            Dim p_DateTime As DateTime
            Dim p_Time As Integer
            Dim p_SoLenh() As String
            Dim p_Int As Integer
            Dim p_DoNumber As String = ""

            Try

                Dim p_InterfaceSMO As New SMOInterface.Class1(g_LinkServicesSMO, g_UserNameSMO, g_PassSMO, g_Company_Code)
                p_DoNumber = p_DoNumberIN
                If Left(p_DoNumber, 1) = "," Then
                    p_DoNumber = Mid(p_DoNumber, 2)
                End If
                If p_DoNumber <> "" Then
                    p_SoLenh = Trim(p_DoNumber).Split(",")
                    p_GetFullDateTime(p_DateTime, p_Time)

                    If p_SoLenh.Length > 0 Then
                        For p_Int = 0 To p_SoLenh.Length - 1
                            p_DoNumber = p_SoLenh(p_Int).ToString.Trim
                            If p_InterfaceSMO.clsUpdateStatusDO(p_DoNumber, p_Status, p_DateTime) = True Then

                            End If
                        Next
                    Else
                        If p_InterfaceSMO.clsUpdateStatusDO(p_DoNumber, p_Status, p_DateTime) = True Then

                        End If
                    End If
                End If

            Catch ex As Exception
                ShowMessageBox("", "Module UpdateStatusDO:" & ex.Message)

            End Try
        End If


    End Sub

End Module
