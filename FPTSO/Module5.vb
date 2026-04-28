Module Module5
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
    Dim i_dt_para As New DataTable

    Public g_FunctionTableId As String



    'Public Sub NhomBeXuat_Combobox(ByRef p_Combo As U_TextBox.U_Combobox)
    '    Dim p_SQL As String = "SELECT [Code] ,[GrpName] FROM .[tblTankGroupList_V]"
    '    Dim p_Tale As DataTable
    '    If g_NhomBeXuat = False Then
    '        p_SQL = p_SQL & "  WHERE  Code = 'TD'"
    '    End If
    '    p_Tale = GetDataTable(p_SQL, p_SQL)
    '    If Not p_Tale Is Nothing Then
    '        p_Combo.DataBindings.Add(
    '    End If
    'End Sub

    'anhqh
    '10/10/2012
    'Ham thuc hien replace cac string khai bao trong SQL thanh cac gia tri theo cac
    'Item tren form

    Public Function p_Parameter_Item(ByVal p_Form As Form, _
                                      ByVal p_SQL As String) As String
        Dim p_SQL_Tmp As String
        Dim p_Pos As Integer
        Dim p_SQL_Tmp1 As String
        Dim p_Parent_Item As String = ""
        Dim p_Parent_Obj As Object
        Dim p_SValue As String = ""
        Dim p_NValue As Integer = 0

        p_Parameter_Item = ""

        p_SQL_Tmp = p_SQL
        While InStr(p_SQL_Tmp, ":", CompareMethod.Text) > 0


            p_Pos = InStr(p_SQL_Tmp, ":", CompareMethod.Text)
            If p_Pos > 0 Then

                If InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) = 0 Then
                    p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos)
                Else
                    If InStr(1, Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) - p_Pos), "=", CompareMethod.Text) > 0 Then
                        p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, "=", CompareMethod.Text) - p_Pos)
                    Else
                        p_SQL_Tmp1 = Mid(p_SQL_Tmp, p_Pos, InStr(p_Pos, p_SQL_Tmp, " ", CompareMethod.Text) - p_Pos)
                    End If

                End If
                ' End If

                p_SQL_Tmp1 = Replace(p_SQL_Tmp1, ")", "", 1)
                p_SQL_Tmp1 = Replace(p_SQL_Tmp1, "(", "", 1)
                If p_SQL_Tmp1.Length > 0 Then
                    If UCase(p_SQL_Tmp1) = UCase(":GLOBAL.COMCODE") Or UCase(p_SQL_Tmp1) = UCase(":GLOBAL.USERNAME") Then
                        p_Parent_Item = p_SQL_Tmp1
                    Else
                        If InStr(p_SQL_Tmp1, ",", CompareMethod.Text) > 0 Then
                            p_Parent_Item = Mid(p_SQL_Tmp1, 2, InStr(p_SQL_Tmp1, ",", CompareMethod.Text) - 2)
                        Else
                            p_Parent_Item = Mid(p_SQL_Tmp1, 2)
                        End If
                    End If



                End If
                If UCase(p_Parent_Item) = UCase(":GLOBAL.COMCODE") Then
                    p_SValue = g_Company_Code
                    p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                ElseIf UCase(p_Parent_Item) = UCase(":GLOBAL.USERNAME") Then
                    p_SValue = g_UserName
                    p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                Else
                    p_Parent_Obj = p_Form.Controls.Find(p_Parent_Item, True)
                    If Not p_Parent_Obj Is Nothing Then
                        ' If p_Parent_Obj.length > 0 Then
                        If Not p_Parent_Obj(0).editvalue Is Nothing Then
                            'If p_Parent_Obj(0).editvalue.ToString.Trim <> "" Then
                            Select Case p_Parent_Obj(0).FieldType
                                Case "C"
                                    p_SValue = p_Parent_Obj(0).editvalue.ToString.Trim
                                    p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                                Case "N"
                                    If p_Parent_Obj(0).text = "" Then
                                        p_NValue = 0
                                    Else
                                        p_NValue = p_Parent_Obj(0).editvalue.ToString.Trim
                                    End If
                                    ' p_NValue = p_Parent_Obj(0).text
                                    p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, p_NValue, 1)
                                Case "D"
                                    p_SValue = p_Parent_Obj(0).editvalue.ToString.Trim
                                    p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                                Case Else
                                    Exit Function

                            End Select

                            ' End If

                        Else
                            p_SQL = Replace(p_SQL_Tmp, p_SQL_Tmp1, "'" & p_SValue & "'", 1)
                        End If
                        'End If

                End If
                End If



            End If
            p_SQL_Tmp = p_SQL
        End While
        p_Parameter_Item = p_SQL
    End Function




    Public Function NhietDoLamTron(p_Value As Double, Optional p_Digits As Integer = 0) As Decimal

        Dim p_NhietDo As Decimal

        Dim p_NhietDo1 As Decimal

        Dim p_Table As DataTable
        Dim p_SQL As String


        Decimal.TryParse(p_Value.ToString.Trim, p_NhietDo)
        ' NhietDoLamTron = Math.Round(p_NhietDo, p_Digits, MidpointRounding.AwayFromZero)

        Double.TryParse(p_Value.ToString.Trim, p_NhietDo1)

        NhietDoLamTron = 0

        p_SQL = "select dbo.FPT_ROUNDNUMBER (" & p_NhietDo1 & "," & p_Digits & ") as nValue"
        p_Table = GetDataTable(p_SQL, p_SQL)
        Try
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    ' NhietDoLamTron = p_Table.Rows(0).Item(0)
                    Double.TryParse(p_Table.Rows(0).Item(0).ToString.Trim, NhietDoLamTron)

                End If
            End If
        Catch ex As Exception

        End Try

        If NhietDoLamTron <= 0 Then
            NhietDoLamTron = Math.Round(p_NhietDo1, p_Digits, MidpointRounding.AwayFromZero)
        End If

    End Function

    'anhqh
    '20170503
    'Ham thuc hien kiem tra trang thai lenh tren form voi trang thai lenh duoi DB
    Public Function KiemTraKhiLuuLenh(ByVal p_SoLenh As String, ByVal p_TRangThai As String) As Boolean
        Dim p_SQL As String
        Dim p_Row() As DataRow
        Dim p_Table As DataTable
        Dim p_Count As Integer
        KiemTraKhiLuuLenh = True
        Try
            p_SQL = "exec FPT_KiemTratrangThai '" & p_SoLenh & "','" & p_TRangThai & "'"

            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                For p_Count = 0 To p_Table.Rows.Count - 1
                    ShowMessageBox("", p_Table.Rows(p_Count).Item("sNote").ToString.Trim)
                    If p_Table.Rows(p_Count).Item("Err").ToString.Trim = "1" Then
                        Return False
                    End If
                Next
            End If

            
        Catch ex As Exception
            ShowMessageBox("", ex.Message)
            KiemTraKhiLuuLenh = False
        End Try

    End Function


    Public Sub CheckPhuongTien_LoaiXuat(ByVal p_MaPhuongTien As String, ByRef p_Error As Boolean, ByRef p_Desc As String, ByRef p_LoaiXuat As String)
        Dim p_SQL As String
        Dim p_DataTable As DataTable


        If p_MaPhuongTien = "" Then
            Exit Sub
        End If

        If g_KV1 = True Then
            If p_LoaiXuat = "" Then
                p_SQL = "select a.*, LEFT(LaiXe,2) as LoaihinhVT from tblPhuongTien a where MaPhuongTien= '" & p_MaPhuongTien & "'"
                p_DataTable = GetDataTable(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count <= 0 Then
                        p_Error = True
                        p_Desc = "Phương tiện không hợp lệ"
                    Else
                        p_LoaiXuat = p_DataTable.Rows(0).Item("LoaihinhVT").ToString.Trim
                    End If
                Else
                    p_Error = True
                    p_Desc = "Phương tiện không hợp lệ"

                End If
            End If
        Else
            p_SQL = "select * from tblPhuongTien where MaPhuongTien= '" & p_MaPhuongTien & "' and LEFT(LaiXe,2)='" & p_LoaiXuat & "'"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count <= 0 Then
                    p_Error = True
                    p_Desc = "Phương tiện không hợp lệ"

                End If
            Else
                p_Error = True
                p_Desc = "Phương tiện không hợp lệ"

            End If
        End If

    End Sub


    Public Sub CheckPhuongTien(ByVal p_MaPhuongTien As String, ByRef p_Error As Boolean, ByRef p_Desc As String, ByRef p_New As Boolean)
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_Count As Integer
        p_SQL = "Exec FPT_KiemTraPhuongTien '" & p_MaPhuongTien & "'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                For p_Count = 0 To p_DataTable.Rows.Count - 1
                    If p_DataTable.Rows(p_Count).Item("sNew").ToString.Trim = "0" Then
                        p_Error = True
                        p_Desc = p_DataTable.Rows(p_Count).Item("sDesc").ToString.Trim
                        p_New = False
                    Else
                        p_Error = True
                        p_Desc = p_DataTable.Rows(p_Count).Item("sDesc").ToString.Trim
                        p_New = True
                        Exit For
                    End If
                Next

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


    Private Function mdlDelivery_CheckTransmot(ByVal i_mavanchuyen As String, ByVal i_dt_para As DataTable) As String
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

    Private Function mdlFunction_GetParaValue(ByVal i_paraname As String) As String
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


    Public Function getNguoiVanChuyen(ByVal p_MaPhuongTien As String, ByRef p_NguoiVanChuyen As String, ByRef p_Desc As String, ByVal p_form As Object, _
                                        Optional p_LAINGAY As String = "") As Boolean
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_TableInfor As DataTable

        Dim p_TableInfor2 As DataTable

        Dim p_DataSet As DataSet
        Dim p_Date As Date
        Dim p_Time As Integer
        Dim p_FromDate As Date
        Dim p_ToDate As Date
        Dim p_Arr() As DataRow
        Dim p_Count As Integer

        Dim p_ValueMess As Windows.Forms.DialogResult


        getNguoiVanChuyen = True
        p_GetDateTime(p_Date, p_Time)
        p_NguoiVanChuyen = ""
        p_FromDate = DateAdd(DateInterval.Day, -5, p_Date)
        p_ToDate = DateAdd(DateInterval.Day, 5, p_Date)

        Try

            If p_LAINGAY = "" Then
                p_SQL = "   select [MaPhuongTien],[HoVaTen],[NoiDung] ,CONVERT(date,isnull(FromDate,GETDATE()-5)) as [FromDate]," & _
                   " CONVERT(date,isnull(ToDate,GETDATE()+5 )) as [ToDate],[sType] ,[sDefault] from tblPhuongTien_LaiXe where upper( MaPhuongTien) ='" & p_MaPhuongTien & "';"
                p_SQL = p_SQL & " SELECT  [ID],[MaPhuongTien],[NoiDung] ,CONVERT(date,isnull(FromDate,GETDATE()-5)) as [FromDate], " & _
                     "CONVERT(date,isnull(ToDate,GETDATE()+5 )) as [ToDate],[sType] FROM [tblPhuongTien_Infor] " & _
                        " where upper( MaPhuongTien) ='" & p_MaPhuongTien & "'   and ( CONVERT(date,getdate())<  CONVERT(date,isnull(FromDate,GETDATE()-5))	" & _
                                 "or  CONVERT(date,getdate())> CONVERT(date,isnull(ToDate,GETDATE()+5 )))"
            Else
                If p_LAINGAY = "Y" Then
                    p_SQL = "   select [MaPhuongTien],[HoVaTen],[NoiDung] ,CONVERT(date,isnull(FromDate,GETDATE()-5)) as [FromDate]," & _
                           " CONVERT(date,isnull(ToDate,GETDATE()+5 )) as [ToDate],[sType] ,[sDefault] from tblPhuongTien_LaiXe where upper( MaPhuongTien) ='" & p_MaPhuongTien & "' and isnull(Dem,'N') <>'Y' ;"
                    p_SQL = p_SQL & " SELECT  [ID],[MaPhuongTien],[NoiDung] ,CONVERT(date,isnull(FromDate,GETDATE()-5)) as [FromDate], " & _
                         "CONVERT(date,isnull(ToDate,GETDATE()+5 )) as [ToDate],[sType] FROM [tblPhuongTien_Infor] " & _
                            " where upper( MaPhuongTien) ='" & p_MaPhuongTien & "'   and ( CONVERT(date,getdate())<  CONVERT(date,isnull(FromDate,GETDATE()-5))	" & _
                                     "or  CONVERT(date,getdate())> CONVERT(date,isnull(ToDate,GETDATE()+5 )))"
                Else
                    p_SQL = "   select [MaPhuongTien],[HoVaTen],[NoiDung] ,CONVERT(date,isnull(FromDate,GETDATE()-5)) as [FromDate]," & _
                   " CONVERT(date,isnull(ToDate,GETDATE()+5 )) as [ToDate],[sType] ,[sDefault] from tblPhuongTien_LaiXe where upper( MaPhuongTien) ='" & p_MaPhuongTien & "' and isnull(Dem,'N') ='Y' ;"
                    p_SQL = p_SQL & " SELECT  [ID],[MaPhuongTien],[NoiDung] ,CONVERT(date,isnull(FromDate,GETDATE()-5)) as [FromDate], " & _
                         "CONVERT(date,isnull(ToDate,GETDATE()+5 )) as [ToDate],[sType] FROM [tblPhuongTien_Infor] " & _
                            " where upper( MaPhuongTien) ='" & p_MaPhuongTien & "'   and ( CONVERT(date,getdate())<  CONVERT(date,isnull(FromDate,GETDATE()-5))	" & _
                                     "or  CONVERT(date,getdate())> CONVERT(date,isnull(ToDate,GETDATE()+5 )))"
                End If
                
            End If
          
            p_DataSet = GetDataSet(p_SQL, p_SQL)

            If Not p_DataSet Is Nothing Then
                If p_DataSet.Tables.Count > 0 Then
                    p_Table = p_DataSet.Tables(0)
                    p_TableInfor = p_DataSet.Tables(1)
                    'p_TableInfor2 = p_DataSet.Tables(2)
                    If p_Table.Rows.Count > 0 Then
                        p_Arr = p_Table.Select("sDefault='Y'")
                        If p_Arr.Length > 0 Then
                            If p_Arr(0).Item("FromDate").ToString.Trim <> "" Then
                                p_FromDate = p_Arr(0).Item("FromDate")
                            End If

                            If p_Arr(0).Item("ToDate").ToString.Trim <> "" Then
                                p_ToDate = p_Arr(0).Item("ToDate")
                            End If

                            If p_Date >= p_FromDate And p_Date <= p_ToDate Then
                                p_NguoiVanChuyen = p_Arr(0).Item("HoVaTen").ToString.Trim
                            Else
                                p_Desc = p_Arr(0).Item("NoiDung").ToString.Trim & " - Đã hết hạn"



                                If p_Arr(0).Item("sType").ToString.Trim <> "Y" Then
                                    ShowMessageBox("", p_Desc)
                                    getNguoiVanChuyen = False
                                    Exit Function

                                Else
                                    p_ValueMess = g_Module.ShowMessage(p_form, "", _
                                               p_Desc & vbCrLf & "Bạn có muốn tiếp tục không? ", _
                                                  True, _
                                                   "Có", _
                                                  True, _
                                                  "Không", _
                                                  False, _
                                                  "", _
                                                   0)
                                    If p_ValueMess = Windows.Forms.DialogResult.No Then
                                        getNguoiVanChuyen = False
                                        Exit Function
                                    End If
                                    p_NguoiVanChuyen = p_Arr(0).Item("HoVaTen").ToString.Trim
                                End If

                            End If

                        Else
                            If p_Table.Rows(0).Item("FromDate").ToString.Trim <> "" Then
                                p_FromDate = p_Table.Rows(0).Item("FromDate")
                            End If

                            If p_Table.Rows(0).Item("ToDate").ToString.Trim <> "" Then
                                p_ToDate = p_Table.Rows(0).Item("ToDate")
                            End If
                            If p_Date >= p_FromDate And p_Date <= p_ToDate Then
                                p_NguoiVanChuyen = p_Table.Rows(0).Item("HoVaTen").ToString.Trim
                            Else
                                p_Desc = p_Table.Rows(0).Item("NoiDung").ToString.Trim & " - Đã hết hạn"
                                ' ShowMessageBox("", p_Desc)
                                'getNguoiVanChuyen = False
                                'Exit Function
                                If p_Table.Rows(0).Item("sType").ToString.Trim <> "Y" Then
                                    ShowMessageBox("", p_Desc)
                                    getNguoiVanChuyen = False
                                    Exit Function
                                Else
                                    p_ValueMess = g_Module.ShowMessage(p_form, "", _
                                               p_Desc & vbCrLf & "Bạn có muốn tiếp tục không? ", _
                                                  True, _
                                                   "Có", _
                                                  True, _
                                                  "Không", _
                                                  False, _
                                                  "", _
                                                   0)
                                    If p_ValueMess = Windows.Forms.DialogResult.No Then
                                        getNguoiVanChuyen = False
                                        Exit Function
                                    End If
                                    p_NguoiVanChuyen = p_Table.Rows(0).Item("HoVaTen").ToString.Trim
                                End If
                            End If


                        End If
                    End If
                    If p_TableInfor.Rows.Count > 0 Then
                        For p_Count = 0 To p_TableInfor.Rows.Count - 1
                            p_Desc = p_TableInfor.Rows(p_Count).Item("NoiDung").ToString.Trim & " - Đã hết hạn"
                            ' ShowMessageBox("", p_Desc)
                            'getNguoiVanChuyen = False
                            'Exit Function
                            If p_TableInfor.Rows(0).Item("sType").ToString.Trim <> "Y" Then
                                ShowMessageBox("", p_Desc)
                                getNguoiVanChuyen = False
                                Exit Function
                            Else
                                p_ValueMess = g_Module.ShowMessage(p_form, "", _
                                               p_Desc & vbCrLf & "Bạn có muốn tiếp tục không? ", _
                                                  True, _
                                                   "Có", _
                                                  True, _
                                                  "Không", _
                                                  False, _
                                                  "", _
                                                   0)
                                If p_ValueMess = Windows.Forms.DialogResult.No Then
                                    getNguoiVanChuyen = False
                                    Exit Function
                                End If
                            End If
                        Next
                    End If



                End If
            End If


            'If p_NguoiVanChuyen <> "" Then
            '    p_SQL = " select * from tblPhuongTien_LaiXe where MaPhuongTien='" & p_MaPhuongTien & "'" & _
            '         " and ( CONVERT(date,getdate())<  CONVERT(date,isnull(FromDate,GETDATE()-5))	" & _
            '             " OR  CONVERT(date,getdate())>  CONVERT(date,isnull(ToDate,GETDATE()+5 ))  )   and  HoVaTen='" & p_NguoiVanChuyen & "'"
            '    p_Table = GetDataTable(p_SQL, p_SQL)
            '    If p_Table.Rows.Count > 0 Then
            '        For p_Count = 0 To p_Table.Rows.Count - 1
            '            p_Desc = p_Table.Rows(p_Count).Item("NoiDung").ToString.Trim & " - Đã hết hạn"


            '            'getNguoiVanChuyen = False
            '            'Exit Function
            '            If p_Table.Rows(0).Item("sType").ToString.Trim <> "Y" Then
            '                ShowMessageBox("", p_Desc)
            '                getNguoiVanChuyen = False
            '                Exit Function
            '            Else
            '                p_ValueMess = g_Module.ShowMessage(p_form, "", _
            '                                   p_Desc & vbCrLf & "Bạn có muốn tiếp tục không? ", _
            '                                      True, _
            '                                       "Có", _
            '                                      True, _
            '                                      "Không", _
            '                                      False, _
            '                                      "", _
            '                                       0)
            '                If p_ValueMess = Windows.Forms.DialogResult.No Then
            '                    getNguoiVanChuyen = False
            '                    Exit Function
            '                End If
            '            End If
            '        Next
            '    End If
            'End If
        Catch ex As Exception
            p_Desc = ex.Message
            ShowMessageBox("", p_Desc)
            getNguoiVanChuyen = False
        End Try

    End Function




    'anhqh 20160920
    Public Function GetTableIDKV1(ByVal p_MaVanChuyen As String, ByVal p_date As Date) As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_Int As Integer
        p_SQL = " exec  FPT_GetTableID_KV1_New '" & p_MaVanChuyen & "','" & p_date.ToString("yyyyMMdd") & "'"

        GetTableIDKV1 = ""
        Try
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTableIDKV1 = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
        Catch ex As Exception
            GetTableIDKV1 = ""
        End Try

    End Function


    Private Function GetTableID() As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable


        'Dim p_FunctionTableId As 
        'p_DataRowArr = p_DataTable.Select("KEYCODE='TABLEID'")
        'If p_DataRowArr.Length > 0 Then
        '    p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
        'End If


        p_SQL = " exec " & g_FunctionTableId
        GetTableID = ""
        Try
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTableID = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
        Catch ex As Exception
            GetTableID = ""
        End Try

    End Function


    Public Sub mdlGetDiemTraHang(ByVal p_SoLenhArr As String)
        Dim p_TimeOut = New TimeSpan()
        Dim p_TblConfig As DataTable
        Dim p_TblLenhXuat As DataTable
        Dim p_SQL As String
        Dim p_DiemTraHang As String = ""
        Dim p_SapConnectionString As String
        Dim p_ChuyenVanTai As String
        Dim p_Dataset As DataSet
        Dim p_DiemTraHangOld As String = ""
        Dim p_Count As Integer
        ' Dim p_ChuyenVanTai As String
        Dim p_SoLenh As String = ""

        p_SQL = "select * from tblconfig; select * from tbllenhxuatE5 where  CHARINDEX ( SoLenh, '" & p_SoLenhArr & "',1) >0 and SoLenh<>'0'"
        p_Dataset = GetDataSet(p_SQL, p_SQL)
        If p_Dataset Is Nothing Then
            Exit Sub
        End If
        p_TblConfig = p_Dataset.Tables(0)
        p_TblLenhXuat = p_Dataset.Tables(1)


        If Not p_TblConfig Is Nothing Then
            If p_TblConfig.Rows.Count > 0 Then
                p_SapConnectionString = p_TblConfig.Rows(0).Item("sapconnectionstring").ToString.Trim
                For p_Count = 0 To p_TblLenhXuat.Rows.Count - 1
                    p_ChuyenVanTai = p_TblLenhXuat.Rows(p_Count).Item("LoaiPhieu").ToString.Trim
                    If p_ChuyenVanTai = "V144" Then
                        Continue For
                    End If
                    p_DiemTraHangOld = p_TblLenhXuat.Rows(p_Count).Item("DiemTraHang").ToString.Trim
                    p_SoLenh = p_TblLenhXuat.Rows(p_Count).Item("SoLenh").ToString.Trim
                    If g_WCF = True Then
                        p_DiemTraHang = g_Services.clsGetDiemTraHang(p_ChuyenVanTai, p_SapConnectionString,
                                            p_TblConfig, p_TimeOut)
                    Else
                        Dim p_SAP_Obj As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
                        p_DiemTraHang = p_SAP_Obj.clsGetDiemTraHang(p_ChuyenVanTai, p_SapConnectionString,
                                            p_TblConfig, p_TimeOut)
                    End If
                    If p_DiemTraHang <> "" Then
                        If p_DiemTraHang <> p_DiemTraHangOld Then
                            p_SQL = "Update tbllenhxuatE5 set DiemtraHang=N'" & p_DiemTraHang & "' where solenh='" & p_SoLenh & "'"
                            If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                            End If
                        End If
                    End If
                Next
            End If
        End If

    End Sub



    Public Function KiemTraBarem_GiayToLaiXe(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_MaPhuongTien As String, ByVal p_GIAYTO_XE As Boolean, _
                                                ByVal p_GIAYTO_LX As Boolean, ByVal p_BAREM_XE As Boolean) As Boolean
        Dim p_SQL As String = ""
        Dim p_datatable As DataTable

        Dim p_Count As Integer
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_Obj() As Object
        Dim p_MaVanChuyen As String = ""
        Dim p_LX As String = ""
        On Error Resume Next
        KiemTraBarem_GiayToLaiXe = True
        p_Obj = p_Form.Controls.Find("MaVanChuyen", True)
        If Not p_Obj Is Nothing Then
            If p_Obj.Length > 0 Then
                If Not p_Obj(0).editvalue Is Nothing Then
                    p_MaVanChuyen = p_Obj(0).editvalue.ToString.Trim

                End If
            End If
        End If


        p_Obj = p_Form.Controls.Find("NguoiVanChuyen", True)
        If Not p_Obj Is Nothing Then
            If p_Obj.Length > 0 Then
                If Not p_Obj(0).editvalue Is Nothing Then
                    p_LX = p_Obj(0).editvalue.ToString.Trim

                End If
            End If
        End If
        If p_MaVanChuyen = "ZR" Then
            Exit Function
        End If
        If p_GIAYTO_XE = True Then
            p_SQL = p_SQL & "select COUNT(*) as STT , N'Giấy phép chưa được nhập cho Phương tiện' as sDes from tblPhuongTien_Infor where Maphuongtien='" & p_MaPhuongTien & "' " & _
                    " and  CONVERT(date,GETDATE()) >=  CONVERT(date,ISNULL(FromDate,GETDATE())) and  CONVERT(date,GETDATE()) <=  CONVERT(date,ISNULL(ToDate,GETDATE()))"
        End If


        If p_GIAYTO_LX = True Then
            If p_SQL <> "" Then
                p_SQL = p_SQL & " Union all "
            End If
            If p_LX = "" Then
                p_SQL = p_SQL & "select COUNT(*) as STT , N'Giấy phép chưa được nhập cho Lái xe' as sDes from tblPhuongTien_LaiXe where  Maphuongtien='" & p_MaPhuongTien & "' " &
                 " and  CONVERT(date,GETDATE()) >=  CONVERT(date,ISNULL(FromDate,GETDATE())) and  CONVERT(date,GETDATE()) <=  CONVERT(date,ISNULL(ToDate,GETDATE()))"
            Else
                p_SQL = p_SQL & "select COUNT(*) as STT , N'Giấy phép chưa được nhập cho Lái xe' as sDes from tblPhuongTien_LaiXe where  " & _
                    " upper(replace (HoVaTen,' ','') )  =  upper(replace (N'" & Replace(p_LX, " ", "") & "',' ','')) and ToDate is not null  and  ( isnull(NoiDung,'') <>''  )   and  Maphuongtien='" & p_MaPhuongTien & "' " &
                 " and  CONVERT(date,GETDATE()) >=  CONVERT(date,ISNULL(FromDate,GETDATE())) and  CONVERT(date,GETDATE()) <=  CONVERT(date,ISNULL(ToDate,GETDATE()))"
            End If

        End If

        'If p_BAREM_XE = True Then
        '    If p_SQL <> "" Then
        '        p_SQL = p_SQL & " ;"
        '    End If
        '    p_SQL = p_SQL & "select COUNT(*) as STT , N'Hạn kiểm định chưa được nhập cho Phương tiện' as sDes from tblPhuongTien where Maphuongtien='" & p_MaPhuongTien & "' and ( NgayBatDau='00000000' and NgayHieuLuc='00000000');"
        'End If
        If p_SQL = "" Then
            Exit Function
        End If
        p_datatable = GetDataTable(p_SQL, p_SQL)
        If Not p_datatable Is Nothing Then
            For p_Count = 0 To p_datatable.Rows.Count - 1
                p_SQL = p_datatable.Rows(p_Count).Item(1).ToString.Trim
                If p_datatable.Rows(p_Count).Item(0) <= 0 Then
                    p_ValueMess = g_Module.ShowMessage(p_Form, "", _
                                             p_SQL & vbCrLf & "Bạn có muốn tiếp tục không? ", _
                                                True, _
                                                 "Có", _
                                                True, _
                                                "Không", _
                                                False, _
                                                "", _
                                                 0)
                    If p_ValueMess = Windows.Forms.DialogResult.No Then
                        KiemTraBarem_GiayToLaiXe = False
                        Exit Function
                    End If
                End If
            Next
        End If

        If p_BAREM_XE = True Then
            p_SQL = "select COUNT(*) as STT , N'Hạn kiểm định chưa được nhập cho Phương tiện' as sDes from tblPhuongTien where Maphuongtien='" & p_MaPhuongTien & "' and ( NgayBatDau='00000000' and NgayHieuLuc='00000000')"
        End If

        p_datatable = GetDataTable(p_SQL, p_SQL)
        If Not p_datatable Is Nothing Then
            For p_Count = 0 To p_datatable.Rows.Count - 1
                p_SQL = p_datatable.Rows(p_Count).Item(1).ToString.Trim
                If p_datatable.Rows(p_Count).Item(0) > 0 Then
                    p_ValueMess = g_Module.ShowMessage(p_Form, "", _
                                             p_SQL & vbCrLf & "Bạn có muốn tiếp tục không? ", _
                                                True, _
                                                 "Có", _
                                                True, _
                                                "Không", _
                                                False, _
                                                "", _
                                                 0)
                    If p_ValueMess = Windows.Forms.DialogResult.No Then
                        KiemTraBarem_GiayToLaiXe = False
                        Exit Function
                    End If
                End If
            Next
        End If

        '      select COUNT(*) as STT , N'Giấy phép chưa được nhập cho Phương tiện' as sDes from tblPhuongTien_Infor where Maphuongtien='';
        'select COUNT(*) as STT , N'Giấy phép chưa được nhập cho Lái xe' as sDes from tblPhuongTien_LaiXe where Maphuongtien='';
        'select COUNT(*) as STT , N'Hạn kiểm định chưa được nhập cho Phương tiện' as sDes from tblPhuongTien where Maphuongtien='' and NgayBatDau='00000000' and NgayHieuLuc='00000000';
    End Function


    Public Sub SetItemPropertyLocal(ByRef p_Form As U_CusForm.XtraCusForm1, ByVal p_FormName As String, ByVal p_Type As String)
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_datatable As DataTable
        Dim p_Object() As Object
        Dim p_Text As U_TextBox.U_TextBox
        Dim p_Combo As U_TextBox.U_Combobox
        Dim p_ButtonEdit As U_TextBox.U_ButtonEdit
        Dim p_Number As U_TextBox.U_NumericEdit
        Dim p_TypeItem As String
        Dim p_Date As U_TextBox.U_DateEdit
        Dim p_CheckBox As U_TextBox.U_CheckBox
        Dim p_Row As DataRow
        p_SQL = "SELECT [FormName],[FormType] ,[ItemType],ItemName, [ColName],[sRequired] ,[sLock] " & _
                    ",[sStatus] ,[sDesc] FROM [tblLenhXuatConfig]  " & _
                    " where upper(FormName) =upper('" & p_FormName & "') and upper (FormType) =upper('" & p_Type & "')   and  isnull(sStatus,'') <> 'N' "
        p_datatable = GetDataTable(p_SQL, p_SQL)
        If Not p_datatable Is Nothing Then
            For p_Count = 0 To p_datatable.Rows.Count - 1
                p_Row = p_datatable.Rows(p_Count)
                If Not p_Row Is Nothing Then
                    If p_Row.Item("ColName").ToString.Trim <> "" Then  'column

                    ElseIf p_Row.Item("ItemName").ToString.Trim <> "" Then
                        'Theo item
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            p_TypeItem = p_Row.Item("ItemType").ToString.Trim
                            Select Case UCase(p_TypeItem)
                                Case UCase("EDITTEXT")    'EditText
                                    p_Text = CType(p_Object(0), U_TextBox.U_TextBox)
                                    p_Text.Required = p_Row.Item("sRequired").ToString.Trim
                                    If p_Row.Item("sLock").ToString.Trim = "Y" Then
                                        p_Text.Properties.ReadOnly = True
                                    Else
                                        p_Text.Properties.ReadOnly = False
                                    End If
                                Case UCase("DATEEDIT")   'DateEdit
                                    p_Date = CType(p_Object(0), U_TextBox.U_DateEdit)
                                    p_Date.Required = p_Row.Item("sRequired").ToString.Trim
                                    If p_Row.Item("sLock").ToString.Trim = "Y" Then
                                        p_Date.Properties.ReadOnly = True
                                    Else
                                        p_Date.Properties.ReadOnly = False
                                    End If
                                Case UCase("NumericEdit")  'Number
                                    p_Number = CType(p_Object(0), U_TextBox.U_NumericEdit)
                                    p_Number.Required = p_Row.Item("sRequired").ToString.Trim
                                    If p_Row.Item("sLock").ToString.Trim = "Y" Then
                                        p_Number.Properties.ReadOnly = True
                                    Else
                                        p_Number.Properties.ReadOnly = False
                                    End If
                                Case UCase("BUTTONEDIT")  'ButtonEdit
                                    p_ButtonEdit = CType(p_Object(0), U_TextBox.U_ButtonEdit)
                                    p_ButtonEdit.Required = p_Row.Item("sRequired").ToString.Trim
                                    If p_Row.Item("sLock").ToString.Trim = "Y" Then
                                        p_ButtonEdit.Properties.ReadOnly = True
                                    Else
                                        p_ButtonEdit.Properties.ReadOnly = False
                                    End If
                                Case UCase("CHECKBOX")  'ButtonEdit
                                    p_CheckBox = CType(p_Object(0), U_TextBox.U_CheckBox)
                                    p_CheckBox.Required = p_Row.Item("sRequired").ToString.Trim
                                    If p_Row.Item("sLock").ToString.Trim = "Y" Then
                                        p_CheckBox.Properties.ReadOnly = True
                                    Else
                                        p_CheckBox.Properties.ReadOnly = False
                                    End If
                                Case Else

                            End Select
                        End If

                    Else

                    End If
                End If
            Next
        End If
    End Sub

    Public Function KiemTraTaoMoiLenhXuat22(ByVal p_SoLenh As String, ByVal p_LXLoai As String, ByVal p_LXPhieu As String) As Boolean
        Dim p_SQL As String = ""
        Dim p_DataTable As DataTable
        KiemTraTaoMoiLenhXuat22 = False
        p_SQL = "select1 from tblLenhXuatE5 o with (Nolock) where SoLenh ='" & p_SoLenh & "'  and isnull(LXLoai,'') ='" & _
                        p_LXLoai & "' and isnull(LXPhieu,'') ='" & p_LXPhieu & "'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                KiemTraTaoMoiLenhXuat22 = True
            End If
        End If
    End Function

    Public Function LaySoLenhMoi() As String
        Dim p_SQL As String
        Dim p_SoLenhTmp As String = ""
        Dim p_SoLenh As String = ""
        Dim p_Datatable As DataTable
        Try
            p_SQL = "exec FPT_TaoMoiSoLenh_New"
            p_Datatable = GetDataTable(p_SQL, p_SQL)
            If Not p_Datatable Is Nothing Then
                If p_Datatable.Rows.Count > 0 Then
                    p_SoLenhTmp = p_Datatable.Rows(0).Item(0).ToString.Trim
                End If
            End If

            If p_SoLenhTmp = "" Then
                p_SQL = "exec FPT_TaoMoiSoLenh"
                p_Datatable = GetDataTable(p_SQL, p_SQL)
                If Not p_Datatable Is Nothing Then
                    If p_Datatable.Rows.Count > 0 Then
                        p_SoLenh = p_Datatable.Rows(0).Item(0).ToString.Trim
                    End If
                End If
            Else
                p_SoLenh = p_SoLenhTmp
            End If
            Return p_SoLenh
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Sub THN_LenhXuat_Infor(ByVal p_TableHeader As DataTable, ByVal p_TableHangHoa As DataTable, _
                                        ByVal p_TableChiTiet As DataTable, ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)
                p_Table = p_ECCDestinationConfig.clsTHN_LenhXuat_Infor(p_TableHeader, p_TableHangHoa, p_TableChiTiet, o_err)
            End If
        End If



    End Sub


    Public Sub KV1CapNhatTrangThaiTichKe(ByVal p_SoLenh As String, ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)
                p_ECCDestinationConfig.clsKV1_UpdateTrangThaiTichKe(p_SoLenh, o_err)
            End If
        End If



    End Sub



    Public Sub CapNhatTrangThaiDongBo(ByVal p_FromDate As String, ByVal p_ToDate As String, ByVal p_SoLenh As String, ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)
                p_ECCDestinationConfig.clsCapNhatTrangThaiAuto(p_FromDate, p_ToDate, p_SoLenh, o_err)
            End If
        End If



    End Sub


    Public Sub Post_LenhXuatAuto( p_TableChiTiet As DataTable, ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)
                p_ECCDestinationConfig.clsPost_LenhXuatAuto(p_TableChiTiet, o_err)
            End If
        End If



    End Sub




    Public Sub THN_Hoa_Infor( ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)
                p_Table = p_ECCDestinationConfig.clsGet_HoaDon_Infor(o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""

                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then
                            ' Return False
                            'Exit Sub
                        End If
                    End If
                    'If g_Services.Then Then

                    'End If
                    '    If g_Services.Sys_Execute(p_SQL, o_err) = False Then


                    '    End If
                    'End If
                End If
            End If
        End If



    End Sub



    Public Sub THN_CongTy_Infor(ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)
                p_Table = p_ECCDestinationConfig.clsGet_CongTy_Infor(o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""
                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        End If
                    End If
                End If
            End If
        End If



    End Sub




    Public Sub THN_HopDong_Infor(ByVal p_SyncMaster As Object, ByVal p_CompanyCode As String, ByVal i_date As String, ByRef o_err As String, Optional ByVal p_isGetAll As String = "H")
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_Table3 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_Desc As String = ""
        Dim p_Count As Integer
        Dim p_MaPhuongThucBan As String
        Dim p_Vbeln As String = ""
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, p_CompanyCode, g_Terminal, g_UserName)
                If p_isGetAll = "A" Then
                    p_Table = p_ECCDestinationConfig.clsDongBoHopDong(p_CompanyCode, i_date, g_UserName, o_err, True)
                Else
                    p_Table = p_ECCDestinationConfig.clsDongBoHopDong(p_CompanyCode, i_date, g_UserName, o_err, False)
                End If

                'If Not p_Table Is Nothing Then
                '    If p_Table.Rows.Count > 0 Then
                '        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                '        o_err = ""
                '        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                '        End If


                '        ''''dang chuyen ham lat ci tiet hop dong theo ham tren
                '        'p_SQL = "select Vtweg, vbeln, Vkorg   from tblProjects  with ( nolock )  where Vkorg='" & p_CompanyCode & "'  order by Vtweg, vbeln"
                '        'p_Table3 = GetDataTable(p_SQL, p_SQL)
                '        'p_Table.Clear()
                '        'If Not p_Table3 Is Nothing Then
                '        '    For p_Count = 0 To p_Table3.Rows.Count - 1

                '        '        p_Vbeln = p_Table3.Rows(p_Count).Item("vbeln").ToString.Trim
                '        '        p_MaPhuongThucBan = p_Table3.Rows(p_Count).Item("Vtweg").ToString.Trim
                '        '        If p_SyncMaster.clsSynHopDong_Detail(p_CompanyCode, p_Table, p_Vbeln, i_date, _
                '        '          p_Desc, p_MaPhuongThucBan) Then
                '        '        End If

                '        '    Next
                '        '    If Not p_Table Is Nothing Then
                '        '        If p_Table.Rows.Count > 0 Then
                '        '            o_err = ""
                '        '            If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                '        '            End If
                '        '        End If
                '        '    End If

                '        'End If

                '    End If
                'End If
            End If
        End If



    End Sub




    Public Sub Get_TankMapSAP_Infor(ByVal p_CompanyCode As String, ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_Table3 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_Desc As String = ""
        Dim p_Count As Integer
        Dim p_MaPhuongThucBan As String
        Dim p_Vbeln As String = ""
        Dim p_Plant As String = ""
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                '   p_Plant = p_Table2.Rows(0).Item("Plant_DB").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, p_CompanyCode, g_Terminal, g_UserName)
                p_Table = p_ECCDestinationConfig.clsGet_TankMapSAP_Infor(g_WareHouse, g_UserName, o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""
                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        End If
                    End If
                End If


            End If
        End If



    End Sub


    Public Sub THN_Kho_Infor(ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)
                p_Table = p_ECCDestinationConfig.clsGet_Kho_Infor(o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""

                        ' p_SQL = "delete from tblKHo  "
                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        End If
                    End If
                End If
            End If
        End If



    End Sub


    '

    Public Sub ToKhaiTaiXuat_Infor(ByVal i_date As String, ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        Dim p_Check As Boolean = False
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)
                p_Table = p_ECCDestinationConfig.clsGet_ToKhaiTaiXuat_Infor(g_Company_Code, i_date, g_UserName, o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""
                        p_Check = True
                        ' p_SQL = "delete from tblKHo  "
                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        End If
                    End If
                End If

                If p_Check = False Then
                    ShowMessageBox("", o_err)
                End If
            End If
        End If



    End Sub

    Public Sub THN_NhaCungCap_Infor(ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)
                p_Table = p_ECCDestinationConfig.clsGet_NhaCungCap_Infor(o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""

                        ' p_SQL = "delete from tblKHo  "
                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        End If
                    End If
                End If
            End If
        End If



    End Sub





    Public Sub THN_STO_Infor(ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)
                p_Table = p_ECCDestinationConfig.clsGet_STO_Infor(o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""

                        ' p_SQL = "delete from tblKHo  "
                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        End If
                    End If
                End If
            End If
        End If



    End Sub



    Public Sub THN_SO_PO_Type_Infor(ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)
                p_Table = p_ECCDestinationConfig.clsGet_SO_PO_Type_Infor(o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""

                        ' p_SQL = "delete from tblKHo  "
                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        End If
                    End If
                End If
            End If
        End If



    End Sub



    Public Sub THN_TyGia_Infor(ByVal p_DateIn As String, ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select * from tblconfig"
        p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)
                p_Table = p_ECCDestinationConfig.clsGet_TyGia_Infor(p_DateIn, o_err)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""

                        ' p_SQL = "delete from tblKHo  "
                        If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        End If
                    End If
                End If
            End If
        End If



    End Sub



    Public Sub ThongTinLenhXuat_Services(ByRef o_err As String)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_Table As DataTable
        Dim p_Table2 As DataTable
        Dim p_Table3 As DataTable
        Dim p_Date As String = ""
        Dim p_DataSet As DataSet
        Dim p_ConnectSapString, p_TimeOut As String
        Dim p_SQL As String = "select *, convert(nvarchar(10),getdate() ,111) as Sys_Date from tblconfig; select KeyValue from sys_config  where upper( KEYCODE) ='NGAYHIEULUC'"

        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            p_Table2 = p_DataSet.Tables(0)
            p_Table3 = p_DataSet.Tables(1)
        End If
        ' p_Table2 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table2 Is Nothing Then
            If p_Table2.Rows.Count > 0 Then

                p_Date = p_Table2.Rows(0).Item("Sys_Date").ToString.Trim
                If Not p_Table3 Is Nothing Then
                    If p_Table3.Rows.Count > 0 Then
                        If p_Table3.Rows(0).Item("KeyValue") = "Y" Then
                            p_Date = ""
                        End If
                    End If
                End If
                p_ConnectSapString = p_Table2.Rows(0).Item("SapConnectionstring").ToString.Trim
                p_TimeOut = p_Table2.Rows(0).Item("Timeout").ToString.Trim
                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code, g_Terminal, g_UserName)
                p_Table = p_ECCDestinationConfig.clsThongTinLenhXuat_Services(o_err, p_Date)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        '  p_SQL = p_Table.Rows(0).Item(0).ToString.Trim
                        o_err = ""
                        'If g_Services.Sys_Execute_DataTbl(p_Table, o_err) = False Then


                        'End If
                    End If
                End If
            End If
        End If



    End Sub



    Public Function KiemTraThoiGianKiemKe_N30(ByVal p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig, ByVal p_LoaiPhieu As String, ByVal p_Table_SoLenh As DataTable, Optional ByVal p_SoLenh As String = "" _
                               ) As Boolean
        Dim p_Count As Integer
        Dim p_TableCheck, p_TableCheck22, p_TableCheck33 As DataTable
        Dim p_SQL As String
        Dim p_SAP_SoLenh As String
        Dim p_Error As String = ""
        Dim p_DataRowArr() As DataRow
        Dim p_Batch_ND As String = ""
        Dim p_CreateDate As String

        Try
            KiemTraThoiGianKiemKe_N30 = False
            If p_SoLenh <> "" Then
                p_SAP_SoLenh = p_SoLenh
                'p_SQL = "select SoLenh, convert(varchar(30), getdate(),110) + ' ' + convert(varchar(30), getdate(),108)  CrDate from tblLenhXuatE5 where  CHARINDEX(solenh,'" & p_SAP_SoLenh & "',1) >0  and MaNguon = 'N30'"
                p_SQL = "select SoLenh, CreateDate CrDate from tblLenhXuatE5 where  CHARINDEX(solenh,'" & p_SAP_SoLenh & "',1) >0  and MaNguon = 'N30'"
                p_TableCheck33 = GetDataTable(p_SQL, p_SQL)

                If Not p_TableCheck33 Is Nothing Then
                    If p_TableCheck33.Rows.Count > 0 Then
                        p_Batch_ND = "N30"
                        p_CreateDate = p_TableCheck33.Rows(0).Item("CrDate").ToString
                    Else
                        p_TableCheck = p_ECCDestinationConfig.clsGet_DO2_Infor(p_SAP_SoLenh, p_Error)
                        If p_Error <> "" Then
                            ShowMessageBox("", p_Error)
                            Return True
                        End If

                        If p_TableCheck.Rows.Count > 0 Then
                            p_DataRowArr = p_TableCheck.Select("ParName='CREATEDATE'")
                            If p_DataRowArr.Length > 0 Then
                                p_CreateDate = p_DataRowArr(0).Item("ParValue").ToString.Trim
                            End If

                            p_DataRowArr = p_TableCheck.Select("ParName='BATCH_ND'")
                            If p_DataRowArr.Length > 0 Then
                                p_Batch_ND = p_DataRowArr(0).Item("ParValue").ToString.Trim
                            End If
                        End If

                    End If
                End If
                If p_Batch_ND = "N30" Then
                    p_SQL = "exec KiemTraThoiGianKiemKe '" & p_SAP_SoLenh & "' ,'" & p_LoaiPhieu & "','" & p_CreateDate & "'"
                    p_TableCheck22 = GetDataTable(p_SQL, p_SQL)
                    If Not p_TableCheck22 Is Nothing Then
                        If p_TableCheck22.Rows.Count > 0 Then
                            If p_TableCheck22.Rows(0).Item("sDesc").ToString.Trim <> "" Then
                                ShowMessageBox("", p_TableCheck22.Rows(0).Item("sDesc").ToString.Trim)
                                If p_TableCheck22.Rows(0).Item("MESS").ToString.Trim = "N" Then
                                    Return True
                                End If

                            End If
                        End If
                    End If
                End If

            Else
                'If p_Table_SoLenh.Rows.Count > 0 Then
                If Not p_Table_SoLenh Is Nothing Then
                    For p_Count = 0 To p_Table_SoLenh.Rows.Count - 1
                        p_Error = ""
                        p_SAP_SoLenh = p_Table_SoLenh.Rows(p_Count).Item("SoLenh").ToString.Trim

                        p_SQL = "select SoLenh, convert(varchar(30), getdate(),110) + ' ' + convert(varchar(30), getdate(),108)  CrDate from tblLenhXuatE5 where  CHARINDEX(solenh,'" & p_SAP_SoLenh & "',1) >0  and MaNguon = 'N30'"
                        p_TableCheck33 = GetDataTable(p_SQL, p_SQL)

                        If Not p_TableCheck33 Is Nothing Then
                            If p_TableCheck33.Rows.Count > 0 Then
                                p_Batch_ND = "N30"
                                p_CreateDate = p_TableCheck33.Rows(0).Item("CrDate").ToString
                            Else
                                p_TableCheck = p_ECCDestinationConfig.clsGet_DO2_Infor(p_SAP_SoLenh, p_Error)
                                If p_Error <> "" Then
                                    ShowMessageBox("", p_Error)
                                    Return True
                                End If

                                If p_TableCheck.Rows.Count > 0 Then
                                    p_DataRowArr = p_TableCheck.Select("ParName='CREATEDATE'")
                                    If p_DataRowArr.Length > 0 Then
                                        p_CreateDate = p_DataRowArr(0).Item("ParValue").ToString.Trim
                                    End If

                                    p_DataRowArr = p_TableCheck.Select("ParName='BATCH_ND'")
                                    If p_DataRowArr.Length > 0 Then
                                        p_Batch_ND = p_DataRowArr(0).Item("ParValue").ToString.Trim
                                    End If
                                End If

                            End If
                        End If
                        If p_Batch_ND = "N30" Then

                            p_SQL = "exec KiemTraThoiGianKiemKe null ,'" & p_LoaiPhieu & "','" & p_CreateDate & "'"
                            p_TableCheck22 = GetDataTable(p_SQL, p_SQL)
                            If Not p_TableCheck22 Is Nothing Then
                                If p_TableCheck22.Rows.Count > 0 Then
                                    If p_TableCheck22.Rows(0).Item("sDesc").ToString.Trim <> "" Then
                                        ShowMessageBox(p_SAP_SoLenh, p_TableCheck22.Rows(0).Item("sDesc").ToString.Trim)
                                        If p_TableCheck22.Rows(0).Item("MESS").ToString.Trim = "N" Then
                                            Return True
                                        End If

                                    End If
                                End If
                            End If
                        End If


                    Next
                End If

            End If

            ' End If
        Catch ex As Exception

        End Try
    End Function

End Module
