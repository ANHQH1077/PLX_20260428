Imports RestSharp
Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json.Linq

Module InterfaceSMO
    Public g_CompanyCode As String = ""
    Public g_LinkServices As String = ""
    Public g_UserName As String = ""
    Public g_Pass As String = ""
    Public g_Token As String = ""
    Private Client As New System.Net.Http.HttpClient()
    Public Class User
        Public Property username As String = ""
        Public Property password As String = ""
    End Class

    Public Class getVehicleObject
        Public Property VEHICLE As String = ""
    End Class
    Public Class getVehicleTRansObject
        Public Property TRANSID As String = ""
    End Class

    Public Class UpdateStatus
        Public Property DO_NUMBER As String = ""
        Public Property STATUS As String = ""
        Public Property DATE_INFO As DateTime  '"2018-11-05T09:01:57.6453261+07:00"
    End Class

    Public Class KV2_LOGIN
        Public Property Username As String = ""
        Public Property Password As String = ""
    End Class

    Public Function getToken(ByVal LinkServices As String, ByVal p_UserName As String, ByVal p_Pass As String, ByRef p_Error As String) As String
        Dim url As String = ""
        Dim response As HttpResponseMessage
        Dim result As String = ""
        p_Error = ""
        Try
            getToken = ""
            ' Client = Nothing
            Try
                ' Client = New System.Net.Http.HttpClient()
            Catch ex As Exception

            End Try

            If Client.BaseAddress Is Nothing Then
                Client.BaseAddress = New Uri(LinkServices)
            End If


            If Client.BaseAddress.ToString = "" Then
                Client.BaseAddress = New Uri(LinkServices)
            End If

            Client.DefaultRequestHeaders.Accept.Clear()
            Client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

            url = String.Format("api/Authorize/Login?username={0}&password={1}", p_UserName, p_Pass)
            response = Client.GetAsync(url).Result
            If response.StatusCode = Net.HttpStatusCode.OK Then

                'Dim jo As JObject = New JObject()
                Dim jResults As JObject = JObject.Parse(response.Content.ReadAsStringAsync().Result)
                'Dim p_Value As String

                getToken = jResults.Item("DATA").ToString()

                'Return True
            Else

                p_Error = "B:" & response.ReasonPhrase.ToString.Trim & "(" & response.StatusCode & ")"
            End If


        Catch ex As Exception
            p_Error = "getToken:" & ex.ToString()
        End Try
    End Function


    Public Function getVehicleInfor(ByVal p_MaPtien As String,
                                    ByRef p_Table As DataTable) As Boolean
        Dim url As String = ""
        Dim jSon As String = ""
        Dim response ' As HttpResponseMessage
        Dim Buffer() As Byte
        Dim p_Error As String = ""
        Dim byteContent
        Dim test
        Dim p_Value As String = ""
        Dim p_Int As Integer
        Dim p_Row As DataRow
        Dim result
        Dim p_Token As String
        Dim p_DateTime As DateTime
        Dim p_Object As New getVehicleObject
        Try
            getVehicleInfor = False
            p_Token = getToken(g_LinkServices, g_UserName, g_Pass, p_Error)
            If p_Error <> "" Then
                MsgBox(p_Error)
                Exit Function
            End If
            p_Table = New DataTable
            p_Table.Columns.Add("MA_CHUYEN")
            p_Table.Columns.Add("DANH_SACH_LENH_XUAT")
            p_Table.Columns.Add("NGAY_DK_LAYHANG", GetType(DateTime))
            'Client.BaseAddress = New Uri(LinkServices)

            Client.DefaultRequestHeaders.Accept.Clear()
            Client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

            ' Gán token vào header để xác thực 
            Client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", p_Token)
            url = String.Format("api/PO/SoChuyen?vehicle=" & p_MaPtien) '("api/PO/InOutStore")

            response = Client.GetAsync(url).Result
            If response.StatusCode = Net.HttpStatusCode.OK Then

                'Dim jo As JObject = New JObject()
                Dim jResults As JObject = JObject.Parse(response.Content.ReadAsStringAsync().Result)
                Dim p_StringL2 As String = ""
                Dim jResultsL2 As JObject
                Dim p_Jtoken As JToken
                'Dim p_Value As String
                For p_Int = 0 To jResults.Item("DATA").Count - 1

                    '  jResults.Item("DATA").Item(p_Int).Item(0).Item 
                    p_Jtoken = jResults.Item("DATA").Item(p_Int)

                    p_Row = p_Table.NewRow
                    p_Row.Item("MA_CHUYEN") = p_Jtoken.SelectToken("MA_CHUYEN").ToString ' jResults.Item("MA_CHUYEN").ToString()
                    p_Row.Item("DANH_SACH_LENH_XUAT") = p_Jtoken.SelectToken("DS_LENH_XUAT").ToString 'jResults.Item("DS_LENH_XUAT").ToString()
                    p_DateTime = CDate(p_Jtoken.SelectToken("NGAY_LAY_HANG").ToString)
                    p_Row.Item("NGAY_DK_LAYHANG") = p_DateTime
                    p_Table.Rows.Add(p_Row)
                Next
                Return True
            Else
                p_Error = response.StatusCode
            End If


        Catch ex As Exception
            p_Error = ex.ToString()
        End Try


    End Function



    Public Function getVehicleTrans(ByVal p_SoChuyen As String,
                                    ByRef p_Table As DataTable) As Boolean
        Dim url As String = ""
        Dim jSon As String = ""
        Dim response ' As HttpResponseMessage
        Dim Buffer() As Byte
        Dim p_Error As String = ""
        Dim byteContent
        Dim test
        Dim p_Value As String = ""
        Dim p_Int As Integer
        Dim p_Row As DataRow
        Dim result
        Dim p_DateTime As DateTime
        Dim p_Token As String = ""
        Dim p_Object As New getVehicleObject
        Try
            getVehicleTrans = False
            p_Token = getToken(g_LinkServices, g_UserName, g_Pass, p_Error)
            If p_Error <> "" Then
                MsgBox(p_Error)
                Exit Function
            End If

            p_Table = New DataTable
            p_Table.Columns.Add("MA_CHUYEN")
            p_Table.Columns.Add("DANH_SACH_LENH_XUAT")
            p_Table.Columns.Add("NGAY_DK_LAYHANG", GetType(DateTime))

            'Client.BaseAddress = New Uri(LinkServices)

            Client.DefaultRequestHeaders.Accept.Clear()
            Client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))

            ' Gán token vào header để xác thực 
            Client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", p_Token)
            url = String.Format("api/PO/ThongTinChuyen?MA_CHUYEN=" & p_SoChuyen) '("api/PO/InOutStore")

            response = Client.GetAsync(url).Result
            If response.StatusCode = Net.HttpStatusCode.OK Then

                'Dim jo As JObject = New JObject()
                Dim jResults As JObject = JObject.Parse(response.Content.ReadAsStringAsync().Result)
                Dim p_StringL2 As String = ""
                Dim jResultsL2 As JObject
                Dim p_Jtoken As JToken
                'Dim p_Value As String
                p_Jtoken = jResults.Item("DATA")
                'jResultsL2 = JObject.Parse(p_Jtoken.ToString)

                p_Row = p_Table.NewRow
                p_Row.Item("MA_CHUYEN") = p_Jtoken.SelectToken("MA_CHUYEN").ToString ' jResults.Item("MA_CHUYEN").ToString()
                p_Row.Item("DANH_SACH_LENH_XUAT") = p_Jtoken.SelectToken("DS_LENH_XUAT").ToString 'jResults.Item("DS_LENH_XUAT").ToString()
                p_DateTime = CDate(p_Jtoken.SelectToken("NGAY_LAY_HANG").ToString)
                p_Row.Item("NGAY_DK_LAYHANG") = p_DateTime
                p_Table.Rows.Add(p_Row)

                Return True
            Else
                p_Error = response.StatusCode
            End If

        Catch ex As Exception
            p_Error = ex.ToString()
        End Try


    End Function


    Public Function UpdateStatusDO(ByVal p_DoNumber As String, ByVal p_Status As String, ByVal p_DateTime As DateTime) As Boolean
        Dim url As String = ""
        Dim jSon As String = ""
        Dim response ' As HttpResponseMessage
        Dim Buffer() As Byte
        Dim p_Error As String = ""
        Dim byteContent
        Dim test
        Dim p_Value As String = ""
        Dim p_Row As DataRow
        Dim result
        Dim p_Object() As UpdateStatus
        Dim p_Token As String = ""
        Try
            'p_Table = New DataTable
            'p_Table.Columns.Add("MA_CHUYEN")
            'p_Table.Columns.Add("SO_LENH_XUAT")
            'p_Table.Columns.Add("NGAY_DK_LAYHANG", GetType(Date))
            UpdateStatusDO = False

            p_Token = getToken(g_LinkServices, g_UserName, g_Pass, p_Error)
            If p_Error <> "" Then
                MsgBox("C:" & p_Error)
                Exit Function
            End If


            Client.DefaultRequestHeaders.Accept.Clear()
            Client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
            ' Gán token vào header để xác thực 
            Client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", p_Token)
            url = String.Format("/api/PO/UpdateStatus")

            ReDim p_Object(0)
            p_Object(0) = New UpdateStatus
            p_Object(0).DO_NUMBER = p_DoNumber
            p_Object(0).STATUS = p_Status
            p_Object(0).DATE_INFO = p_DateTime


            jSon = JsonConvert.SerializeObject(p_Object)

            Buffer = System.Text.Encoding.UTF8.GetBytes(jSon)
            byteContent = New ByteArrayContent(Buffer)
            byteContent.Headers.ContentType = New MediaTypeHeaderValue("application/json")
            response = Client.PostAsync(url, byteContent)

            test = response.Result.Content.ReadAsStringAsync().Result




            If test <> "" Then
                'Dim jo As JObject = New JObject()
                Dim jResults As JObject = JObject.Parse(test)
                If UCase(jResults.GetValue("STATUS").ToString) = UCase("TRUE") Then
                    Return True
                Else
                    p_Error = "A:" & jResults.GetValue("MESSAGE").ToString
                End If

            End If

        Catch ex As Exception
            
            p_Error = "UpdateStatusDO:" & ex.ToString() & vbCrLf & p_Error
            MsgBox(p_Error)
        End Try


    End Function



    Private Function KV2_GetDOInfor(ByVal p_DoNumber As String, ByVal p_PhuongTien As String, _
                                   ByVal p_Token As String, ByRef p_Error As String, ByRef p_TableExe As DataTable, _
                                   ByVal p_CheckDO As Boolean, ByRef p_PhuongTienSMO As String) As Boolean
        Dim url As String = ""
        Dim jSon As String = ""
        Dim response ' As HttpResponseMessage
        Dim Buffer() As Byte
        ' Dim p_Error As String = ""
        Dim byteContent
        Dim test
        Dim p_Value As String = ""
        Dim p_Row As DataRow
        Dim result
        Dim p_Object() As String
        Dim p_COunt As Integer
        Dim p_SQL As String
        ' Dim p_Row As DataRow
        Dim p_SoLenh As String
        Try
            KV2_GetDOInfor = False
            p_Error = ""
            p_Object = p_DoNumber.Split(",")
            If p_TableExe Is Nothing Then
                p_TableExe = New DataTable
            End If

            If p_TableExe.Columns.Count <= 0 Then
                p_TableExe.Columns.Add("SQLSTR")
            End If
            p_PhuongTienSMO = ""
            For p_COunt = 0 To p_Object.Length - 1
                p_SoLenh = p_Object(p_COunt)
                p_SoLenh = Replace(p_SoLenh, ",", "")
                If p_SoLenh = "" Then
                    Continue For
                End If
                Client.DefaultRequestHeaders.Accept.Clear()
                Client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
                ' Gán token vào header để xác thực 
                Client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", p_Token)

                '/po/TGBX_GetInfoDO_XuatThuy?doNumber=...

                If g_CompanyCode = "6610" Then
                    url = String.Format("/api/po/TGBX_GetInfoDO_XuatThuy?doNumber=" & p_SoLenh)
                Else
                    url = String.Format("/api/PO/TGBX_GetInfoDO?doNumber=" & p_SoLenh)
                End If

                ' byteContent.Headers.ContentType = New MediaTypeHeaderValue("application/json")
                response = Client.PostAsync(url, byteContent)
                test = response.Result.Content.ReadAsStringAsync().Result
                If test <> "" Then
                    'Dim jo As JObject = New JObject()
                    Dim jResults As JObject = JObject.Parse(test)
                    If UCase(jResults.GetValue("STATUS").ToString) = UCase("TRUE") Then
                        If jResults.Item("DATA").SelectToken("VEHICLE").ToString() = "" Then
                            ' If p_Error = "" Then
                            p_Error = "Phương tiện SMO chưa khai báo"
                            'End If
                            Return False
                        End If
                        If p_CheckDO = False Then
                            Dim p_Note_LX As String = ""
                            Try
                                p_Note_LX = jResults.Item("DATA").SelectToken("NOTE_LX").ToString()
                            Catch ex As Exception

                            End Try

                         

                            If p_PhuongTien <> jResults.Item("DATA").SelectToken("VEHICLE").ToString() Then

                                p_PhuongTienSMO = jResults.Item("DATA").SelectToken("VEHICLE").ToString()
                                'p_Error = "Phương tiện không đúng với SMO"
                                'p_SQL = "Update tblLenhXuatE5 set  NOTE_LX ='" & p_Note_LX & "', MaPhuongTien ='" & jResults.Item("DATA").SelectToken("VEHICLE").ToString() & "' where SoLenh ='" & p_SoLenh & "'"

                                'p_Row = p_TableExe.NewRow
                                'p_Row.Item(0) = p_SQL
                                'p_TableExe.Rows.Add(p_Row)

                            Else
                                'Return False
                                'p_SQL = "Update tblLenhXuatE5 set NOTE_LX ='" & p_Note_LX & "' where SoLenh ='" & p_SoLenh & "'"

                                'p_Row = p_TableExe.NewRow
                                'p_Row.Item(0) = p_SQL
                                'p_TableExe.Rows.Add(p_Row)
                            End If
                            If p_Note_LX.ToString.Trim <> "" Then
                                p_SQL = "Update tblLenhXuatE5 set NOTE_LX ='" & p_Note_LX & "' where SoLenh ='" & p_SoLenh & "'"
                                p_Row = p_TableExe.NewRow
                                p_Row.Item(0) = p_SQL
                                p_TableExe.Rows.Add(p_Row)
                            End If
                            
                            ' p_SQL = ""

                        End If
                        ' Return True
                        Return True
                    Else
                        p_Error = jResults.GetValue("DATA").ToString
                        If p_Error = "" Then
                            p_Error = jResults.GetValue("MESSAGE").ToString
                        End If
                        Return False
                    End If
                End If
            Next
        Catch ex As Exception
            p_Error = ex.ToString()
        End Try
    End Function




    Private Function VungTau_GetDOInfor(ByVal p_DoNumber As String, ByVal p_PhuongTien As String, _
                                   ByVal p_Token As String, ByRef p_Error As String, ByRef p_TableExe As DataTable, _
                                   ByVal p_CheckDO As Boolean, ByRef p_PhuongTienSMO As String) As Boolean
        Dim url As String = ""
        Dim jSon As String = ""
        Dim response ' As HttpResponseMessage
        Dim Buffer() As Byte
        ' Dim p_Error As String = ""
        Dim byteContent
        Dim test
        Dim p_Value As String = ""
        Dim p_Row As DataRow
        Dim result
        Dim p_Object() As String
        Dim p_COunt As Integer
        Dim p_SQL As String
        ' Dim p_Row As DataRow
        Dim p_SoLenh As String
        Try
            VungTau_GetDOInfor = False
            p_Error = ""
            p_Object = p_DoNumber.Split(",")
            If p_TableExe Is Nothing Then
                p_TableExe = New DataTable
            End If

            If p_TableExe.Columns.Count <= 0 Then
                p_TableExe.Columns.Add("SQLSTR")
            End If
            p_PhuongTienSMO = ""
            For p_COunt = 0 To p_Object.Length - 1
                p_SoLenh = p_Object(p_COunt)
                p_SoLenh = Replace(p_SoLenh, ",", "")
                If p_SoLenh = "" Then
                    Continue For
                End If
                Client.DefaultRequestHeaders.Accept.Clear()
                Client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
                ' Gán token vào header để xác thực 
                Client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", p_Token)

                '/po/TGBX_GetInfoDO_XuatThuy?doNumber=...
              
                url = String.Format("/api/PO/TGBX_GetInfoDO?doNumber=" & p_SoLenh)


                ' byteContent.Headers.ContentType = New MediaTypeHeaderValue("application/json")
                response = Client.PostAsync(url, byteContent)
                test = response.Result.Content.ReadAsStringAsync().Result
                If test <> "" Then
                    'Dim jo As JObject = New JObject()
                    Dim jResults As JObject = JObject.Parse(test)
                    If UCase(jResults.GetValue("STATUS").ToString) = UCase("TRUE") Then
                        If jResults.Item("DATA").SelectToken("VEHICLE").ToString() = "" Then
                            ' If p_Error = "" Then
                            p_Error = "Phương tiện SMO chưa khai báo"
                            'End If
                            Return False
                        End If
                        If p_CheckDO = False Then
                            Dim p_Note_LX As String = ""
                            Try
                                p_Note_LX = jResults.Item("DATA").SelectToken("NOTE_LX").ToString()
                            Catch ex As Exception

                            End Try

                            If p_PhuongTien <> jResults.Item("DATA").SelectToken("VEHICLE").ToString() Then

                                p_PhuongTienSMO = jResults.Item("DATA").SelectToken("VEHICLE").ToString()
                                'p_Error = "Phương tiện không đúng với SMO"
                                'p_SQL = "Update tblLenhXuatE5 set  NOTE_LX ='" & p_Note_LX & "', MaPhuongTien ='" & jResults.Item("DATA").SelectToken("VEHICLE").ToString() & "' where SoLenh ='" & p_SoLenh & "'"

                                'p_Row = p_TableExe.NewRow
                                'p_Row.Item(0) = p_SQL
                                'p_TableExe.Rows.Add(p_Row)

                            Else
                                'Return False
                                'p_SQL = "Update tblLenhXuatE5 set NOTE_LX ='" & p_Note_LX & "' where SoLenh ='" & p_SoLenh & "'"

                                'p_Row = p_TableExe.NewRow
                                'p_Row.Item(0) = p_SQL
                                'p_TableExe.Rows.Add(p_Row)
                            End If
                            If p_Note_LX.ToString.Trim <> "" Then
                                p_SQL = "Update tblLenhXuatE5 set NOTE_LX ='" & p_Note_LX & "' where SoLenh ='" & p_SoLenh & "'"
                                p_Row = p_TableExe.NewRow
                                p_Row.Item(0) = p_SQL
                                p_TableExe.Rows.Add(p_Row)
                            End If

                            ' p_SQL = ""

                        End If
                        ' Return True
                        Return True
                    Else
                        p_Error = jResults.GetValue("DATA").ToString
                        If p_Error = "" Then
                            p_Error = jResults.GetValue("MESSAGE").ToString
                        End If
                        Return False
                    End If
                End If
            Next
        Catch ex As Exception
            p_Error = ex.ToString()
        End Try
    End Function





    Public Function KV2_TGBX_GetInfoDO(ByVal p_SoLenh As String, ByRef p_Error As String, ByVal p_PhuongTien As String, ByRef p_TableExe As DataTable, _
                                       ByVal p_CheckDO As Boolean, ByRef p_PhuongTienSMO As String) As Boolean
        Dim url As String = ""
        Dim jSon As String = ""
        Dim response ' As HttpResponseMessage
        Dim Buffer() As Byte
        '  Dim p_Error As String = ""
        Dim byteContent
        Dim test
        Dim p_Value As String = ""
        Dim p_Int As Integer
        Dim p_Row As DataRow
        Dim result
        Dim p_Token As String
        Dim p_DateTime As DateTime
        Dim p_Object As New getVehicleObject
        Try
            KV2_TGBX_GetInfoDO = False
            p_Token = getToken(g_LinkServices, g_UserName, g_Pass, p_Error)
            If p_Error <> "" Then
                MsgBox(p_Error)
                Exit Function
            End If

            KV2_TGBX_GetInfoDO = KV2_GetDOInfor(p_SoLenh, p_PhuongTien, p_Token, p_Error, p_TableExe, p_CheckDO, p_PhuongTienSMO)

        Catch ex As Exception
            p_Error = ex.ToString()
        End Try


    End Function




    Public Function VungTau_TGBX_GetInfoDO(ByVal p_SoLenh As String, ByRef p_Error As String, ByVal p_PhuongTien As String, ByRef p_TableExe As DataTable, _
                                       ByVal p_CheckDO As Boolean, ByRef p_PhuongTienSMO As String) As Boolean
        Dim url As String = ""
        Dim jSon As String = ""
        Dim response ' As HttpResponseMessage
        Dim Buffer() As Byte
        '  Dim p_Error As String = ""
        Dim byteContent
        Dim test
        Dim p_Value As String = ""
        Dim p_Int As Integer
        Dim p_Row As DataRow
        Dim result
        Dim p_Token As String
        Dim p_DateTime As DateTime
        Dim p_Object As New getVehicleObject
        Try
            VungTau_TGBX_GetInfoDO = False
            p_Token = getToken(g_LinkServices, g_UserName, g_Pass, p_Error)
            If p_Error <> "" Then
                MsgBox(p_Error)
                Exit Function
            End If

            VungTau_TGBX_GetInfoDO = VungTau_GetDOInfor(p_SoLenh, p_PhuongTien, p_Token, p_Error, p_TableExe, p_CheckDO, p_PhuongTienSMO)

        Catch ex As Exception
            p_Error = ex.ToString()
        End Try


    End Function



    'Public Function KV2_LoginSMO(ByVal LinkServices As String, ByVal p_UserName As String, ByVal p_Pass As String, ByRef p_Error As String) As String
    '    Dim url As String = ""
    '    Dim response As HttpResponseMessage
    '    Dim result As String = ""
    '    Dim jSon As String = ""
    '    Dim p_Object As New KV2_LOGIN
    '    p_Error = ""
    '    Try
    '        KV2_LoginSMO = ""
    '        ' Client = Nothing
    '        p_Object.Username = p_UserName
    '        p_Object.Password = p_Pass

    '        If Client.BaseAddress Is Nothing Then
    '            Client.BaseAddress = New Uri(LinkServices)
    '        End If


    '        If Client.BaseAddress.ToString = "" Then
    '            Client.BaseAddress = New Uri(LinkServices)
    '        End If

    '        Client.DefaultRequestHeaders.Accept.Clear()
    '        Client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
    '        jSon = JsonConvert.SerializeObject(p_Object)

    '        url = "api/Authorize/Login/" & jSon
    '        response = Client.GetAsync(url).Result
    '        If response.StatusCode = Net.HttpStatusCode.OK Then

    '            'Dim jo As JObject = New JObject()
    '            Dim jResults As JObject = JObject.Parse(response.Content.ReadAsStringAsync().Result)
    '            'Dim p_Value As String

    '            KV2_LoginSMO = jResults.Item("DATA").ToString()

    '            'Return True
    '        Else

    '            p_Error = response.StatusCode
    '        End If


    '    Catch ex As Exception
    '        p_Error = ex.ToString()
    '    End Try
    'End Function
End Module
