
Imports System.ServiceModel
Module Module6

    Public g_1EndPointAddress As String = ""
    Public g_2EndPointAddress As String = ""
    Public g_1EndPointUser As String = ""
    Public g_1EndPointUserWS As String = ""
    Public g_1EndPointPass As String = ""
    Public g_1EndPointPassWS As String = ""
    'Public g_publishservice As New publishservice.PublishServiceSoapClient
    ' Dim getres As New getAvailableHotelResponse()
    '  QLSearchXML = xmlData

    Public Sub checkXML()
        Dim p_Path As String
        Dim p_SQL As String = ""
        Dim p_Count As Integer
        p_Path = Application.StartupPath & "\TempHD.xml"
        Try
            Dim p_DataSet As New DataSet
            ''
            p_DataSet.ReadXml(p_Path)
            If Not p_DataSet Is Nothing Then
                p_Count = p_DataSet.Tables.Count
            End If
        Catch ex As Exception
            p_SQL = ex.Message
        End Try


    End Sub

    Sub GetInforLinkCompany()
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_RowArr() As DataRow
        ' Dim p_Link As 
        p_SQL = "Select upper(KeyCode) as KeyCode, KeyValue from SYS_CONFIG "    'where upper( KeyCode( =upper('EndpointAddress')"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_RowArr = p_Table.Select("KeyCode='" & UCase("1VATAddress") & "'")
                If p_RowArr.Length > 0 Then
                    g_1EndPointAddress = p_RowArr(0).Item("KeyValue").ToString.Trim
                End If

                p_RowArr = p_Table.Select("KeyCode='" & UCase("1VatUser") & "'")
                If p_RowArr.Length > 0 Then
                    g_1EndPointUser = p_RowArr(0).Item("KeyValue").ToString.Trim
                End If
                p_RowArr = p_Table.Select("KeyCode='" & UCase("1VatUserWS") & "'")
                If p_RowArr.Length > 0 Then
                    g_1EndPointUserWS = p_RowArr(0).Item("KeyValue").ToString.Trim
                End If
                p_RowArr = p_Table.Select("KeyCode='" & UCase("1VatPass") & "'")
                If p_RowArr.Length > 0 Then
                    g_1EndPointPass = p_RowArr(0).Item("KeyValue").ToString.Trim
                End If

                p_RowArr = p_Table.Select("KeyCode='" & UCase("1VatPassWS") & "'")
                If p_RowArr.Length > 0 Then
                    g_1EndPointPassWS = p_RowArr(0).Item("KeyValue").ToString.Trim
                End If

                p_RowArr = p_Table.Select("KeyCode='" & UCase("2VATAddress") & "'")
                If p_RowArr.Length > 0 Then
                    g_2EndPointAddress = p_RowArr(0).Item("KeyValue").ToString.Trim
                End If

                ' g_EndPointAddress = p_Table.Rows(0).Item("KeyValue").ToString.Trim
                'g_publishservice.Endpoint.Address = New EndpointAddress(g_EndPointAddress)
            End If
        End If
    End Sub

    Public Sub TaoHoaDon(p_User As String, p_SoLenh As String, p_MaTraCuu As String,
                            ByRef p_TableHD As DataTable)
        Dim p_SQL As String = ""
        Dim p_DatatableLine, p_DatatableHeader As DataTable
        Dim p_DataSet As DataSet
        If g_1EndPointAddress = "" Then
            GetInforLinkCompany()
        End If
        If g_1EndPointAddress = "" Or g_1EndPointUser = "" Or g_1EndPointPass = "" Or g_2EndPointAddress = "" Then
            ShowMessageBox("", "Thông tin kết nối không đúng")
            Exit Sub
        End If

        p_SQL = ""
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_DatatableHeader = p_DataSet.Tables(0)
                p_DatatableLine = p_DataSet.Tables(1)
            End If
        End If
        If p_MaTraCuu <> "" Then
            Dim p_SerVice As New publishservice.PublishServiceSoapClient
            Dim p_String = ""
            p_SerVice.Endpoint.Address = New EndpointAddress(g_1EndPointAddress)
            ' p_String = p_SerVice.ImportAndPublishInv(g_1EndPointUser, g_1EndPointPass,, g_1EndPointUserWS, g_1EndPointPassWS)


        End If
    End Sub

    Public Sub TaoMaTraCuu(p_User As String, p_SoLenh As String, ByRef p_MaTraCuu As String)
        Dim p_SQL As String = ""
        Dim p_Datatable As DataTable
        p_MaTraCuu = ""
        If g_1EndPointAddress = "" Then
            GetInforLinkCompany()
        End If
        If g_1EndPointAddress = "" Or g_1EndPointUser = "" Or g_1EndPointPass = "" Then
            ShowMessageBox("", "Thông tin kết nối không đúng")
            Exit Sub
        End If

        p_SQL = "exec TaoMaTraCuu '" & p_SoLenh & "','" & p_MaTraCuu & "'"
        p_Datatable = GetDataTable(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                If p_Datatable.Rows(0).Item("ErrorNum") = 0 Then
                    p_MaTraCuu = p_Datatable.Rows(0).Item("MaTraCuu").ToString.Trim
                Else
                    ShowMessageBox("", p_Datatable.Rows(0).Item("ErrorDesc").ToString.Trim)
                    Exit Sub
                End If
            End If
        End If
        If p_MaTraCuu <> "" Then
            Dim p_SerVice As New portalservice.PortalServiceSoapClient
            Dim p_String = ""
            p_SerVice.Endpoint.Address = New EndpointAddress(g_2EndPointAddress)
            p_String = p_SerVice.listInvByCusFkey(p_MaTraCuu, "", "", g_1EndPointUser, g_1EndPointPass)
        End If
    End Sub
End Module
