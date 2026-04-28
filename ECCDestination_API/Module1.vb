Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports Newtonsoft.Json.Linq
Module Module1

    'Public p_LinkServices = "http://erp.petrolimex.com.vn:8001/dev/lims/plx/api/"
    'Public p_UserNameAPI As String = "PLX_LIMS"
    'Public p_PassAPI As String = "PLX_LIMS@!23"

    Public Sub Post_LenhXuatBoSung_JSON(ByVal p_DataTable As DataTable, ByRef o_err As String, ByVal p_Link As String, ByVal p_UserAPI As String, ByVal p_PassAPI As String)
        'Dim response As HttpResponseMessage

        Dim p_Value As Long
        Dim p_Starttime As String = Now.ToString("yyyyMMdd HH:m:ss")
        Dim url As String
        ' Dim p_ObjIT_DATA1 As New JsonStructure.ObjIT_DATA1
        Dim p_SQL As String
        Dim p_ObjDetailArr As New List(Of JsonStructure.ObjDetail)
        Dim p_ObjDetail As JsonStructure.ObjDetail
        Dim p_ObjDATA As New JsonStructure.ObjDATA
        Try
            o_err = ""

            If Not p_DataTable Is Nothing Then
                For p_Count = 0 To p_DataTable.Rows.Count - 1
                    p_ObjDetail = New JsonStructure.ObjDetail()
                    p_ObjDetail.ORDER_NO = p_DataTable.Rows(p_Count).Item("ORDER_NO").ToString.Trim
                    p_ObjDetail.OUTBOUND = p_DataTable.Rows(p_Count).Item("ORDER_NO").ToString.Trim
                    p_ObjDetail.ITEM_ND = p_DataTable.Rows(p_Count).Item("LINEID").ToString.Trim
                    p_ObjDetail.COMPARTMENT = p_DataTable.Rows(p_Count).Item("MaNgan").ToString.Trim
                    p_ObjDetail.ZZERDAT = p_DataTable.Rows(p_Count).Item("ZZERDAT").ToString.Trim
                    p_ObjDetail.ZZERTIM = p_DataTable.Rows(p_Count).Item("ZZERTIM").ToString.Trim
                    p_ObjDetail.ZZAEDAT = p_DataTable.Rows(p_Count).Item("ZZAEDAT").ToString.Trim
                    p_ObjDetail.ZZAETIM = p_DataTable.Rows(p_Count).Item("ZZAETIM").ToString.Trim
                    p_ObjDetail.USERNAME = p_DataTable.Rows(p_Count).Item("UsrName").ToString.Trim
                    p_ObjDetail.DATE_TIME = p_DataTable.Rows(p_Count).Item("Sysdate").ToString.Trim
                    p_ObjDetail.FLG_HTTG = p_DataTable.Rows(p_Count).Item("FLG_HTTG").ToString.Trim
                    p_ObjDetail.FLG_RUT_TDH = p_DataTable.Rows(p_Count).Item("FLG_RUT_TDH").ToString.Trim
                    p_ObjDetail.NHIENDO_PT = p_DataTable.Rows(p_Count).Item("NhietDoXe").ToString.Trim
                    p_ObjDetail.CHIEUCAO_HH = p_DataTable.Rows(p_Count).Item("MaEntry").ToString.Trim
                    p_ObjDetail.BATCH_ND = p_DataTable.Rows(p_Count).Item("BATCH_ND").ToString.Trim
                    p_ObjDetail.MATNR = p_DataTable.Rows(p_Count).Item("MATNR").ToString.Trim
                    p_ObjDetail.CUSTOMER = p_DataTable.Rows(p_Count).Item("CUSTOMER").ToString.Trim
                    p_ObjDetail.VEHICLE = p_DataTable.Rows(p_Count).Item("VEHICLE").ToString.Trim
                    p_ObjDetail.METER_NO = p_DataTable.Rows(p_Count).Item("METER_NO").ToString.Trim
                    p_ObjDetail.METER_START = p_DataTable.Rows(p_Count).Item("METER_START").ToString.Trim
                    p_ObjDetail.METER_END = p_DataTable.Rows(p_Count).Item("METER_END").ToString.Trim
                    p_ObjDetail.QUANTITY_CONFIRM = p_DataTable.Rows(p_Count).Item("QUANTITY_CONFIRM").ToString.Trim
                    p_ObjDetail.TEMP_CONFIRM = p_DataTable.Rows(p_Count).Item("TEMP_CONFIRM").ToString.Trim
                    p_ObjDetail.DENS_CONFIRM = p_DataTable.Rows(p_Count).Item("DENS_COMFIRM").ToString.Trim
                    p_ObjDetail.NIEM_TEXT = p_DataTable.Rows(p_Count).Item("NIEM_TEXT").ToString.Trim

                    p_ObjDATA.DATA.IT_DATA.Add(p_ObjDetail)
                Next
                If p_DataTable.Rows.Count > 0 Then
                    ' p_ObjDATA.DATA.IT_DATA = p_ObjDetailArr
                    p_SQL = JsonConvert.SerializeObject(p_ObjDATA, Formatting.Indented)



                    Dim p_String = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(p_UserAPI & ":" & p_PassAPI))    'UExYX0xJTVM6UExYX0xJTVNAITIz

                    
                    Using client = New HttpClient()
                        Dim p_requestMsg = New HttpRequestMessage With {
                                           .Method = HttpMethod.Post,
                                           .RequestUri = New Uri(p_Link),
                                               .Content = New StringContent(p_SQL, System.Text.Encoding.UTF8, "application/json")
                                       }
                        client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Basic", p_String)

                        Dim response = client.SendAsync(p_requestMsg).Result
                        If Not response.IsSuccessStatusCode Then
                            o_err = "API: " & response.ToString
                        End If
                        ' Dim responseBody = response.Content.ReadAsStringAsync().Result

                    End Using


                End If

            End If




            'p_TableReturn = l_tabl
            ' Return p_TableReturn
            ' WritetoTxt(p_Starttime & ":  end==================Post_LenhXuatBoSung=======================")
        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            ' WritetoTxt(p_Starttime & ":  End Error===========Post_LenhXuatBoSung======================")
            o_err = "Post_LenhXuatBoSung: " & ex.Message.ToString()

        End Try


    End Sub




    Public Sub UpdateTrangThaiTichKe_JSON(ByVal p_SoLenh As String, ByRef o_err As String, ByVal p_Link As String, ByVal p_UserAPI As String, ByVal p_PassAPI As String)
        'Dim response As HttpResponseMessage

        Dim p_Value As Long
        Dim p_Starttime As String = Now.ToString("yyyyMMdd HH:m:ss")
        Dim url As String
        ' Dim p_ObjIT_DATA1 As New JsonStructure.ObjIT_DATA1
        Dim p_SQL As String
        ' Dim p_ObjDetailArr As New List(Of JsonStructure.ObjDetail)
        ' Dim p_ObjDetail As New JsonStructure.ObjDetail1
        Dim p_ObjDATA As New JsonStructure.ObjDATAInTickKe
        Try
            o_err = ""
            p_SoLenh = Replace(p_SoLenh, ",", "")
            ' p_ObjDetail.I_VBELN = p_SoLenh
            p_ObjDATA.DATA.I_VBELN = p_SoLenh
            p_SQL = JsonConvert.SerializeObject(p_ObjDATA, Formatting.Indented)

            Dim p_String = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(p_UserAPI & ":" & p_PassAPI))    'UExYX0xJTVM6UExYX0xJTVNAITIz


            Using client = New HttpClient()
                Dim p_requestMsg = New HttpRequestMessage With {
                                   .Method = HttpMethod.Post,
                                   .RequestUri = New Uri(p_Link),
                                       .Content = New StringContent(p_SQL, System.Text.Encoding.UTF8, "application/json")
                               }
                client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Basic", p_String)

                Dim response = client.SendAsync(p_requestMsg).Result
                If Not response.IsSuccessStatusCode Then
                    o_err = "API: " & response.ToString
                End If


            End Using



        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            ' WritetoTxt(p_Starttime & ":  End Error===========Post_LenhXuatBoSung======================")
            o_err = "UpdateTrangThaiTichKe_JSON: " & ex.Message.ToString()

        End Try


    End Sub

End Module
