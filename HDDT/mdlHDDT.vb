
Imports System.Windows.Forms
Imports System.Xml
Imports System.ServiceModel

Imports System.IO
Imports System.Drawing

Module mdlHDDT

    Public g_1EndPointAddress As String = "/publishservice.asmx"
    Public g_2EndPointAddress As String = "/petroservice.asmx" ' "/portalservice.asmx"
    Public g_3EndPointAddress As String = "/BusinessService.asmx"

    'DungchoDO1
    Public g_21EndPointAddress As String = "/publishservice.asmx"
    Public g_22EndPointAddress As String = "/petroservice.asmx"
    Public g_23EndPointAddress As String = "/BusinessService.asmx"

    Private Const g_1EndPointAddressValue As String = "/publishservice.asmx"
    Private Const g_2EndPointAddressValue As String = "/petroservice.asmx"
    Private Const g_3EndPointAddressValue As String = "/BusinessService.asmx"

    Public g_1EndPointUser As String = ""
    Public g_1EndPointUserWS As String = ""
    Public g_1EndPointPass As String = ""
    Public g_1EndPointPassWS As String = ""
    'DungchoDO1
    Public g_2EndPointUser As String = ""
    Public g_2EndPointUserWS As String = ""
    Public g_2EndPointPass As String = ""
    Public g_2EndPointPassWS As String = ""

    Public g_TaoMaTraCuu As Boolean = False
    Public g_PublicService As publishservice.PublishServiceSoapClient
    Public g_PortalService As portalservice.PetroServiceSoapClient
    Public g_BusinessService As BusinessService.BusinessServiceSoapClient

    Public g_2PublicService As publishservice.PublishServiceSoapClient
    Public g_2PortalService As portalservice.PetroServiceSoapClient
    Public g_2BusinessService As BusinessService.BusinessServiceSoapClient
    Private p_Error As Boolean = False



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

    Sub GetInforLinkCompany(ByVal p_DO1 As Boolean)
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_RowArr() As DataRow
        ' Dim p_Link As 
        p_SQL = "Select upper(KeyCode) as KeyCode, KeyValue from SYS_CONFIG "    'where upper( KeyCode( =upper('EndpointAddress')"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_DO1 = True Then
                    p_RowArr = p_Table.Select("KeyCode='" & UCase("2VATAddress") & "'")
                    If p_RowArr.Length > 0 Then
                        '    g_1EndPointAddress = p_RowArr(0).Item("KeyValue").ToString.Trim
                        g_1EndPointAddress = p_RowArr(0).Item("KeyValue").ToString.Trim & g_1EndPointAddressValue
                        g_2EndPointAddress = p_RowArr(0).Item("KeyValue").ToString.Trim & g_2EndPointAddressValue
                        g_3EndPointAddress = p_RowArr(0).Item("KeyValue").ToString.Trim & g_3EndPointAddressValue
                    End If
                    ' 
                    p_RowArr = p_Table.Select("KeyCode='" & UCase("2VatUser") & "'")
                    If p_RowArr.Length > 0 Then
                        g_1EndPointUser = p_RowArr(0).Item("KeyValue").ToString.Trim
                    End If
                    ' 
                    p_RowArr = p_Table.Select("KeyCode='" & UCase("2VatUserWS") & "'")
                    If p_RowArr.Length > 0 Then
                        g_1EndPointUserWS = p_RowArr(0).Item("KeyValue").ToString.Trim
                    End If
                    p_RowArr = p_Table.Select("KeyCode='" & UCase("2VatPass") & "'")
                    If p_RowArr.Length > 0 Then
                        g_1EndPointPass = p_RowArr(0).Item("KeyValue").ToString.Trim
                    End If

                    p_RowArr = p_Table.Select("KeyCode='" & UCase("2VatPassWS") & "'")
                    If p_RowArr.Length > 0 Then
                        g_1EndPointPassWS = p_RowArr(0).Item("KeyValue").ToString.Trim
                    End If

              
                Else
                    p_RowArr = p_Table.Select("KeyCode='" & UCase("1VATAddress") & "'")
                    If p_RowArr.Length > 0 Then
                        ' g_1EndPointAddress = p_RowArr(0).Item("KeyValue").ToString.Trim
                        g_1EndPointAddress = p_RowArr(0).Item("KeyValue").ToString.Trim & g_1EndPointAddressValue
                        g_2EndPointAddress = p_RowArr(0).Item("KeyValue").ToString.Trim & g_2EndPointAddressValue
                        g_3EndPointAddress = p_RowArr(0).Item("KeyValue").ToString.Trim & g_3EndPointAddressValue
                    End If
                    ' 
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

                    
                End If
               

              
                p_RowArr = p_Table.Select("KeyCode='" & UCase("1MaTraCuu") & "' or KeyCode='" & UCase("1MATRACUU") & "'")
                If p_RowArr.Length > 0 Then
                    If p_RowArr(0).Item("KeyValue").ToString.Trim = "Y" Then
                        g_TaoMaTraCuu = True
                    End If

                End If

                'p_RowArr = p_Table.Select("KeyCode='" & UCase("2VATAddress") & "'")
                'If p_RowArr.Length > 0 Then
                '    g_2EndPointAddress = p_RowArr(0).Item("KeyValue").ToString.Trim
                'End If


                'p_RowArr = p_Table.Select("KeyCode='" & UCase("3VATAddress") & "'")
                'If p_RowArr.Length > 0 Then
                '    g_3EndPointAddress = p_RowArr(0).Item("KeyValue").ToString.Trim
                'End If

                ' g_EndPointAddress = p_Table.Rows(0).Item("KeyValue").ToString.Trim
                'g_publishservice.Endpoint.Address = New EndpointAddress(g_EndPointAddress)

                CreateServicePublic(g_PublicService)
                CreateServicePortal(g_PortalService)
                'CreateServiceBusiness(g_BusinessService)

            End If
        End If
    End Sub





    Public Sub TaoHoaDon(ByVal p_XemHoaDon As Boolean, ByVal p_User As String, ByVal p_SoLenh As String, ByVal p_LoaiCT As String, ByRef p_Error As Boolean)
        Dim p_SQL As String = ""
        Dim p_Datatab0, p_Datatab1, p_Datatab2, p_Datatab3 As DataTable
        Dim p_DataSet As DataSet
        Dim p_Count As Integer
        Dim p_SoToChu As String = ""
        Dim p_Total, p_Vat, p_Amount As Double
        Dim p_MaTraCuu As String = ""
        Dim p_SoHD As String = ""
        Dim p_ChietKhau As Double
        Dim p_StringValue As String = ""
        Dim p_tbl As DataTable
        Dim p_DO1 As Boolean = False
        'If g_1EndPointAddress = "" Then
        '    GetInforLinkCompany()
        'End If
        p_SQL = "exec LenhXuatDO1 '" & p_SoLenh & "'"
        p_tbl = GetDataTable(p_SQL, p_SQL)
        If Not p_tbl Is Nothing Then
            If p_tbl.Rows.Count > 0 Then
                p_DO1 = True
            End If
        End If
        If p_LoaiCT = "GTGT" And p_DO1 = True Then
            GetInforLinkCompany(True)
            'CreateServicePublicDO1(g_PublicService)
            'CreateServicePortalDO1(g_PortalService)
            'CreateServiceBusinessDO1(g_BusinessService)
        Else
            GetInforLinkCompany(False)
            'CreateServicePublic(g_PublicService)
            'CreateServicePortal(g_PortalService)
            'CreateServiceBusiness(g_BusinessService)
        End If
        If g_1EndPointAddress = "" Or g_1EndPointUser = "" Or g_1EndPointPass = "" Or g_2EndPointAddress = "" Then
            ShowMessageBox("", "Thông tin kết nối không đúng")
            Exit Sub
        End If

        '  Cursor = Cursors.WaitCursor
        p_MaTraCuu = ""
        ' HTTP_Open(p_MaTraCuu)

        'ANHQH  20200118  Tao va kiem tra ton tai ma tra cuu
        If p_XemHoaDon = True Then
            p_SQL = "select MaTraCuu from tblChungTu where SoLenh ='" & p_SoLenh & "' and LoaiChungTu ='" & p_LoaiCT & "'"
            p_Datatab0 = GetDataTable(p_SQL, p_SQL)
            If Not p_Datatab0 Is Nothing Then
                If p_Datatab0.Rows.Count > 0 Then
                    p_MaTraCuu = p_Datatab0.Rows(0).Item("MaTraCuu").ToString.Trim
                End If
            End If


        Else
            TaoMaTraCuu(p_User, p_SoLenh, p_MaTraCuu, p_SoHD, p_LoaiCT)
        End If

       

        If p_MaTraCuu <> "" Then
            If g_TaoMaTraCuu = True Then   ''Chi tao Ma tra cuu
                p_StringValue = ""
                p_SQL = "update  tblChungTu set  MaTraCuu='" & p_MaTraCuu & "' where SoLenh ='" & p_SoLenh & "';"
                p_SQL = p_SQL & "update tblMaTraCuu set SyncStatus= 'Y', SyncDate =getdate()   where SoLenh ='" & p_SoLenh & "' and MaTraCuu ='" & p_MaTraCuu & "';"
                If SQL_Execute(p_SQL, p_StringValue) = False Then
                    ShowMessageBox("", p_StringValue)
                    p_Error = True
                End If
                Exit Sub
            End If
            '  Dim p_SerVice As New publishservice.PublishServiceSoapClient
            Dim p_String = ""
            If p_XemHoaDon = False Then
                p_SQL = "Exec  [sp_Reports_HoaDonDienTu]  '" & p_SoLenh & "', '" & p_User & "','" & p_MaTraCuu & "','" & p_LoaiCT & "',0"
            Else
                p_SQL = "Exec  [sp_Reports_HoaDonDienTu]  '" & p_SoLenh & "', '" & p_User & "','" & p_MaTraCuu & "','" & p_LoaiCT & "',1"
            End If

                p_DataSet = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSet Is Nothing Then
                    p_DataSet.DataSetName = "Invoices"
                    If p_DataSet.Tables.Count > 0 Then
                        p_DataSet.Tables(0).TableName = "Inv"
                        p_DataSet.Tables(1).TableName = "Invoice"
                        p_DataSet.Tables(2).TableName = "Products"
                        p_DataSet.Tables(3).TableName = "Product"
                        p_Datatab0 = p_DataSet.Tables(0)
                        p_Datatab1 = p_DataSet.Tables(1)


                        p_Total = 0
                        p_Vat = 0
                        p_Amount = 0
                        If p_Datatab1.Rows.Count > 0 Then
                            Double.TryParse(p_Datatab1.Rows(0).Item("Total").ToString.Trim, p_Total)
                            Double.TryParse(p_Datatab1.Rows(0).Item("VatAmount").ToString.Trim, p_Vat)
                            p_Amount = p_Total + p_Vat
                            p_Datatab1.Rows(0).Item("Amount") = p_Amount
                            If p_Amount > 0 Then
                                If p_Datatab1.Rows(0).Item("CurrencyUnit").ToString.Trim = "USD" Then
                                    p_SoToChu = Strings.Trim(mdlFunction.Number2Text_EN_VN(CDbl(p_Amount)))
                                    If Len(p_SoToChu) > 0 Then
                                        p_SoToChu = UCase(Strings.Left(p_SoToChu, 1)) & Mid(p_SoToChu, 2)
                                    End If
                                    p_Datatab1.Rows(0).Item("AmountInWords") = p_SoToChu  ' + " đồng chẵn"
                                Else
                                    p_Datatab1.Rows(0).Item("AmountInWords") = mdlFunction.Number2Text(CLng(p_Amount)) + " đồng chẵn"
                                End If

                            Else
                            p_Datatab1.Rows(0).Item("AmountInWords") = "Không đồng chẵn"
                            End If

                        End If

                        p_Datatab2 = p_DataSet.Tables(2)
                        p_Datatab3 = p_DataSet.Tables(3)
                    End If
                End If
                If Not p_Datatab1 Is Nothing And Not p_Datatab3 Is Nothing Then
                    If p_Datatab1.Rows.Count > 0 And p_Datatab3.Rows.Count > 0 Then
                        ' p_SerVice.Endpoint.Address = New EndpointAddress(g_1EndPointAddress)
                        ' p_String = p_SerVice.ImportAndPublishInv(g_1EndPointUser, g_1EndPointPass,, g_1EndPointUserWS, g_1EndPointPassWS)
                        ' Dim p_Error As Boolean = False
                        Dim p_ErrorString As String = ""

                        Dim p_DataTable As DataTable
                        Dim p_Pattern As String = ""
                        Dim p_Serial As String = ""
                        'p_SQL = "exec  MauSo_KyHieuHoaDon  'GTGT'"
                        p_DataTable = p_DataSet.Tables(4)  ' GetDataTable(p_SQL, p_SQL)

                        If Not p_DataTable Is Nothing Then
                            If p_DataTable.Rows.Count > 0 Then
                                p_Pattern = p_DataTable.Rows(0).Item("Pattern").ToString.Trim
                                p_Serial = p_DataTable.Rows(0).Item("Serial").ToString.Trim
                            End If


                        End If

                        If p_Pattern = "" Or p_Serial = "" Then
                            ShowMessageBox("", "Mẫu số hoặc Ký hiệu hóa đơn không đúng")
                            Exit Sub
                        End If


                        p_Error = False
                        If p_XemHoaDon = False Then   ''Tích hợp HĐ_ĐT
                        TESTTaoHoaDonDienTu(p_LoaiCT, p_User, p_SoLenh, p_DataSet, p_Error, p_ErrorString, p_StringValue, p_Pattern, p_Serial, p_MaTraCuu)
                            If p_Error = True Then
                                ShowMessageBox("", p_ErrorString)

                            Else

                            End If
                            Exit Sub
                        Else  '''''Xem mẫu hóa đơn trên HTTG
                        XemMauHoaDon(p_LoaiCT, p_User, p_SoLenh, p_DataSet, p_Error, p_ErrorString, p_StringValue, p_Pattern, p_Serial, p_MaTraCuu)
                            If p_Error = True Then
                                ShowMessageBox("", p_ErrorString)

                            Else

                            End If
                            Exit Sub
                        End If

                    End If

                End If

                ShowMessageBox("", "Lỗi: " & p_SQL)
            End If
    End Sub


    Private Sub XemMauHoaDon(ByVal p_LoaiChungTu As String, ByVal p_UserName As String, ByVal p_SoLenh As String, ByVal p_DataSet As DataSet, _
                                ByRef p_Error As Boolean, ByRef p_StringError As String, _
                                ByRef p_StringValue As String, ByVal p_Patten As String, ByVal p_Serial As String, ByVal p_MaTraCuu As String)
        Select Case p_LoaiChungTu
            Case "GTGT"
                XemMauHoaDon_GTGT(p_UserName, p_SoLenh, p_DataSet, _
                                 p_Error, p_StringError, _
                                 p_StringValue, p_Patten, p_Serial, p_MaTraCuu)
            Case "GTGT_VCNB"
                XemMauHoaDon_VCNB(p_UserName, p_SoLenh, p_DataSet, _
                                 p_Error, p_StringError, _
                                 p_StringValue, p_Patten, p_Serial, p_MaTraCuu)
            Case Else
                XemMauHoaDon_TaiXuat(p_UserName, p_SoLenh, p_DataSet, _
                                 p_Error, p_StringError, _
                                 p_StringValue, p_Patten, p_Serial, p_MaTraCuu)
        End Select
    End Sub



    Private Sub XemMauHoaDon_VCNB(ByVal p_UserName As String, ByVal p_SoLenh As String, ByVal p_DataSet As DataSet, _
                                ByRef p_Error As Boolean, ByRef p_StringError As String, _
                                ByRef p_StringValue As String, ByVal p_Patten As String, ByVal p_Serial As String, ByVal p_MaTraCuu As String)


        '  Dim p_Obj As Object
        Dim p_RpHoaDon As New KV2_HoaDon_VCNB
        Dim p_RpHoaDonSub As New KV2_HoaDon_SubNew
        Dim p_RpHoaDonSub2 As New KV2_HoaDon_SubNew2_VCNB
        Dim p_Table1, p_Table0, p_Table33, p_Table44 As DataTable
        Dim p_Total, p_VatAmount, p_Amount As Double
        Dim p_Count As Integer
        Dim p_String, p_String1, p_String2 As String
        p_Table0 = p_DataSet.Tables(0)
        p_Table1 = p_DataSet.Tables(4)
        p_Table44 = p_DataSet.Tables(5)
        ''p_Table5 = p_DataSet.Tables(5)


        If Not p_Table0 Is Nothing Then
            If p_Table0.Rows.Count > 0 Then
                p_RpHoaDon.Parameters.Item("p_MaTraCuu").Value = p_Table0.Rows(0).Item(0).ToString.Trim
            End If
        End If

        If Not p_Table1 Is Nothing Then
            If p_Table1.Rows.Count > 0 Then
                p_RpHoaDon.Parameters.Item("MauSoHD").Value = p_Table1.Rows(0).Item("Pattern").ToString.Trim
                p_RpHoaDon.Parameters.Item("KyHieuHD").Value = p_Table1.Rows(0).Item("Serial").ToString.Trim
                p_RpHoaDon.Parameters.Item("p_SoHoaDon").Value = p_Table1.Rows(0).Item("SoHoaDon").ToString.Trim
                p_RpHoaDon.Parameters.Item("P_MaSoThue_BH").Value = p_Table1.Rows(0).Item("MST").ToString.Trim
            End If
        End If

        If Not p_DataSet.Tables(1) Is Nothing Then
            p_DataSet.Tables(1).Columns.Add("sTotal")
            p_DataSet.Tables(1).Columns.Add("sVatAmount")
            p_DataSet.Tables(1).Columns.Add("sAmount")
            If p_DataSet.Tables(1).Rows.Count > 0 Then
                Double.TryParse(p_DataSet.Tables(1).Rows(0).Item("Total").ToString.Trim, p_Total)
                Double.TryParse(p_DataSet.Tables(1).Rows(0).Item("VatAmount").ToString.Trim, p_VatAmount)
                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_Total > 0 Then
                    p_String = Format(p_Total, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(1).Rows(0).Item("sTotal") = p_String
                End If

                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_VatAmount > 0 Then
                    p_String = Format(p_VatAmount, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(1).Rows(0).Item("sVatAmount") = p_String
                End If

                p_Amount = p_Total + p_VatAmount
                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_Amount > 0 Then
                    p_String = Format(p_Amount, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(1).Rows(0).Item("sAmount") = p_String
                End If

                If Not p_Table44 Is Nothing Then
                    If p_Table44.Rows.Count > 0 Then
                        p_RpHoaDon.Parameters.Item("CongTy").Value = p_Table44.Rows(0).Item("TenDonVi").ToString
                        p_RpHoaDon.Parameters.Item("P_DiaChi").Value = p_Table44.Rows(0).Item("DiaChiHD").ToString

                        p_RpHoaDon.XrLabel26.Text = p_Table44.Rows(0).Item("sGio").ToString
                        p_RpHoaDon.XrLabel26.Visible = True
                        'XrLabel26
                    End If
                End If

                'Format(p_Total,"#,###,###,##0.##")
                p_RpHoaDon.Parameters.Item("P_Ngay").Value = Mid(p_DataSet.Tables(1).Rows(0).Item("ArisingDate").ToString, 1, 2)
                p_RpHoaDon.Parameters.Item("P_Thang").Value = Mid(p_DataSet.Tables(1).Rows(0).Item("ArisingDate").ToString, 4, 2)
                p_RpHoaDon.Parameters.Item("P_Nam").Value = Mid(p_DataSet.Tables(1).Rows(0).Item("ArisingDate").ToString, 7, 4)
                'p_RpHoaDon.Parameters.Item("P_ThueGTGT").Value = p_DataSet.Tables(1).Rows(0).Item("VatRate")
                'p_RpHoaDon.Parameters.Item("P_TienThueGTGT").Value = p_DataSet.Tables(1).Rows(0).Item("VatAmount")
                'p_RpHoaDon.Parameters.Item("P_TongCong").Value = p_DataSet.Tables(1).Rows(0).Item("Total")
                'p_RpHoaDon.Parameters.Item("P_TongThanhToan").Value = p_DataSet.Tables(1).Rows(0).Item("Amount")

                p_RpHoaDon.Parameters.Item("NgayDD").Value = Mid(p_DataSet.Tables(1).Rows(0).Item("DieuDongNgay").ToString, 1, 2)
                p_RpHoaDon.Parameters.Item("ThangDD").Value = Mid(p_DataSet.Tables(1).Rows(0).Item("DieuDongNgay").ToString, 4, 2)
                p_RpHoaDon.Parameters.Item("NamDD").Value = Mid(p_DataSet.Tables(1).Rows(0).Item("DieuDongNgay").ToString, 7, 4)

                p_String = ""
                Try
                    p_String = p_DataSet.Tables(1).Rows(0).Item("VatRate").ToString.Trim & "%"
                Catch ex As Exception

                End Try
                p_RpHoaDonSub2.Parameters.Item("P_ThueGTGT").Value = p_String ' p_DataSet.Tables(1).Rows(0).Item("VatRate")
                p_RpHoaDonSub2.Parameters.Item("P_TienThueGTGT").Value = p_DataSet.Tables(1).Rows(0).Item("sVatAmount")
                p_RpHoaDonSub2.Parameters.Item("P_TongCong").Value = p_DataSet.Tables(1).Rows(0).Item("sTotal")
                p_RpHoaDonSub2.Parameters.Item("P_TongThanhToan").Value = p_DataSet.Tables(1).Rows(0).Item("sAmount")

            End If
        End If
        p_RpHoaDon.DataSource = p_DataSet.Tables(1)
        p_RpHoaDon.DataMember = p_DataSet.Tables(1).TableName
        p_Table33 = p_DataSet.Tables(3).Clone
        Dim p_Row As DataRow

        p_DataSet.Tables(3).Columns.Add("sProdQuantity")
        p_DataSet.Tables(3).Columns.Add("sProdPrice")
        p_DataSet.Tables(3).Columns.Add("sAmount")

        For p_Count = 0 To p_DataSet.Tables(3).Rows.Count - 1
            'Double.TryParse(p_DataSet.Tables(3).Rows(p_Count).Item("Amount").ToString.Trim, p_Total)
            ' If p_Total > 0 Then
            p_String = ""
            p_String1 = ""
            p_String2 = ""
            If p_Total > 0 Then
                p_String = Format(p_Total, "#,###,###,###,##0.##")
                p_String1 = p_String
                If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                    p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                End If
                p_String1 = Replace(p_String1, p_String2, "")
                p_String = Replace(p_String1, ",", ".")
                If p_String2.Length > 0 Then
                    p_String = p_String & "," & p_String2
                End If
                p_DataSet.Tables(3).Rows(p_Count).Item("sAmount") = p_String
            End If
            Double.TryParse(p_DataSet.Tables(3).Rows(p_Count).Item("ProdQuantity").ToString.Trim, p_Total)
            p_String = ""
            p_String1 = ""
            p_String2 = ""
            If p_Total > 0 Then
                p_String = Format(p_Total, "#,###,###,###,##0.##")
                p_String1 = p_String
                If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                    p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                End If
                p_String1 = Replace(p_String1, p_String2, "")
                p_String = Replace(p_String1, ",", ".")
                If p_String2.Length > 0 Then
                    p_String = p_String & "," & p_String2
                End If
                p_DataSet.Tables(3).Rows(p_Count).Item("sProdQuantity") = p_String
            End If
            Double.TryParse(p_DataSet.Tables(3).Rows(p_Count).Item("ProdPrice").ToString.Trim, p_Total)
            p_String = ""
            p_String1 = ""
            p_String2 = ""
            If p_Total > 0 Then
                p_String = Format(p_Total, "#,###,###,###,##0.##")
                p_String1 = p_String
                If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                    p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                End If
                p_String1 = Replace(p_String1, p_String2, "")
                p_String = Replace(p_String1, ",", ".")
                If p_String2.Length > 0 Then
                    p_String = p_String & "," & p_String2
                End If
                p_DataSet.Tables(3).Rows(p_Count).Item("sProdPrice") = p_String
            End If
            ' End If
        Next


        For p_Count = 7 To p_DataSet.Tables(3).Rows.Count Step -1
            p_Row = p_Table33.NewRow
            p_Table33.Rows.Add(p_Row)
        Next

        p_RpHoaDonSub.DataSource = p_DataSet.Tables(3)
        p_RpHoaDonSub.DataMember = p_DataSet.Tables(3).TableName
        'XrLabel71
        p_RpHoaDonSub.XrLabel71.Text = "Tên vật tư hàng hóa"
        p_RpHoaDonSub2.DataSource = p_Table33
        p_RpHoaDonSub2.DataMember = p_Table33.TableName
        p_RpHoaDon.XrSubreport1.ReportSource = p_RpHoaDonSub
        p_RpHoaDon.XrSubreport2.ReportSource = p_RpHoaDonSub2
        p_RpHoaDon.ShowPreviewDialog()
    End Sub


    Private Sub XemMauHoaDon_TaiXuat(ByVal p_UserName As String, ByVal p_SoLenh As String, ByVal p_DataSet As DataSet, _
                                ByRef p_Error As Boolean, ByRef p_StringError As String, _
                                ByRef p_StringValue As String, ByVal p_Patten As String, ByVal p_Serial As String, ByVal p_MaTraCuu As String)


        '  Dim p_Obj As Object
        Dim p_RpHoaDon As New KV2_HoaDon_TXVN
        Dim p_RpHoaDonSub As New KV2_HoaDon_SubNew
        Dim p_RpHoaDonSub2 As New KV2_HoaDon_SubNew2_VCNB
        Dim p_Table1, p_Table0, p_Table33 As DataTable
        Dim p_Total, p_VatAmount, p_Amount As Double
        Dim p_Count As Integer
        Dim p_String, p_String1, p_String2 As String
        p_Table0 = p_DataSet.Tables(0)
        p_Table1 = p_DataSet.Tables(4)


        If Not p_Table0 Is Nothing Then
            If p_Table0.Rows.Count > 0 Then
                p_RpHoaDon.Parameters.Item("p_MaTraCuu").Value = p_Table0.Rows(0).Item(0).ToString.Trim
            End If
        End If

        If Not p_Table1 Is Nothing Then
            If p_Table1.Rows.Count > 0 Then
                p_RpHoaDon.Parameters.Item("MauSoHD").Value = p_Table1.Rows(0).Item("Pattern").ToString.Trim
                p_RpHoaDon.Parameters.Item("KyHieuHD").Value = p_Table1.Rows(0).Item("Serial").ToString.Trim
                p_RpHoaDon.Parameters.Item("p_SoHoaDon").Value = p_Table1.Rows(0).Item("SoHoaDon").ToString.Trim
                p_RpHoaDon.Parameters.Item("P_MaSoThue_BH").Value = p_Table1.Rows(0).Item("MST").ToString.Trim
            End If
        End If

        If Not p_DataSet.Tables(1) Is Nothing Then
            p_DataSet.Tables(1).Columns.Add("sTotal")
            p_DataSet.Tables(1).Columns.Add("sVatAmount")
            p_DataSet.Tables(1).Columns.Add("sAmount")
            If p_DataSet.Tables(1).Rows.Count > 0 Then
                Double.TryParse(p_DataSet.Tables(1).Rows(0).Item("Total").ToString.Trim, p_Total)
                Double.TryParse(p_DataSet.Tables(1).Rows(0).Item("VatAmount").ToString.Trim, p_VatAmount)
                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_Total > 0 Then
                    p_String = Format(p_Total, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(1).Rows(0).Item("sTotal") = p_String
                End If

                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_VatAmount > 0 Then
                    p_String = Format(p_VatAmount, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(1).Rows(0).Item("sVatAmount") = p_String
                End If

                p_Amount = p_Total + p_VatAmount
                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_Amount > 0 Then
                    p_String = Format(p_Amount, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(1).Rows(0).Item("sAmount") = p_String
                End If



                'Format(p_Total,"#,###,###,##0.##")
                p_RpHoaDon.Parameters.Item("P_Ngay").Value = Mid(p_DataSet.Tables(1).Rows(0).Item("ArisingDate").ToString, 1, 2)
                p_RpHoaDon.Parameters.Item("P_Thang").Value = Mid(p_DataSet.Tables(1).Rows(0).Item("ArisingDate").ToString, 4, 2)
                p_RpHoaDon.Parameters.Item("P_Nam").Value = Mid(p_DataSet.Tables(1).Rows(0).Item("ArisingDate").ToString, 7, 4)
                'p_RpHoaDon.Parameters.Item("P_ThueGTGT").Value = p_DataSet.Tables(1).Rows(0).Item("VatRate")
                'p_RpHoaDon.Parameters.Item("P_TienThueGTGT").Value = p_DataSet.Tables(1).Rows(0).Item("VatAmount")
                'p_RpHoaDon.Parameters.Item("P_TongCong").Value = p_DataSet.Tables(1).Rows(0).Item("Total")
                'p_RpHoaDon.Parameters.Item("P_TongThanhToan").Value = p_DataSet.Tables(1).Rows(0).Item("Amount")

                p_String = ""
                Try
                    p_String = p_DataSet.Tables(1).Rows(0).Item("VatRate").ToString.Trim & "%"
                Catch ex As Exception

                End Try
                p_RpHoaDonSub2.Parameters.Item("P_ThueGTGT").Value = p_String ' p_DataSet.Tables(1).Rows(0).Item("VatRate")
                p_RpHoaDonSub2.Parameters.Item("P_TienThueGTGT").Value = p_DataSet.Tables(1).Rows(0).Item("sVatAmount")
                p_RpHoaDonSub2.Parameters.Item("P_TongCong").Value = p_DataSet.Tables(1).Rows(0).Item("sTotal")
                p_RpHoaDonSub2.Parameters.Item("P_TongThanhToan").Value = p_DataSet.Tables(1).Rows(0).Item("sAmount")

            End If
        End If
        p_RpHoaDon.DataSource = p_DataSet.Tables(1)
        p_RpHoaDon.DataMember = p_DataSet.Tables(1).TableName
        p_Table33 = p_DataSet.Tables(3).Clone
        Dim p_Row As DataRow

        p_DataSet.Tables(3).Columns.Add("sProdQuantity")
        p_DataSet.Tables(3).Columns.Add("sProdPrice")
        p_DataSet.Tables(3).Columns.Add("sAmount")

        For p_Count = 0 To p_DataSet.Tables(3).Rows.Count - 1
            Double.TryParse(p_DataSet.Tables(3).Rows(p_Count).Item("Amount").ToString.Trim, p_Total)
            If p_Total > 0 Then
                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_Total > 0 Then
                    p_String = Format(p_Total, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(3).Rows(p_Count).Item("sAmount") = p_String
                End If
                Double.TryParse(p_DataSet.Tables(3).Rows(p_Count).Item("ProdQuantity").ToString.Trim, p_Total)
                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_Total > 0 Then
                    p_String = Format(p_Total, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(3).Rows(p_Count).Item("sProdQuantity") = p_String
                End If
                Double.TryParse(p_DataSet.Tables(3).Rows(p_Count).Item("ProdPrice").ToString.Trim, p_Total)
                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_Total > 0 Then
                    p_String = Format(p_Total, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(3).Rows(p_Count).Item("sProdPrice") = p_String
                End If
            End If
        Next


        For p_Count = 8 To p_DataSet.Tables(3).Rows.Count Step -1
            p_Row = p_Table33.NewRow
            p_Table33.Rows.Add(p_Row)
        Next

        p_RpHoaDonSub.DataSource = p_DataSet.Tables(3)
        p_RpHoaDonSub.DataMember = p_DataSet.Tables(3).TableName

        p_RpHoaDonSub2.DataSource = p_Table33
        p_RpHoaDonSub2.DataMember = p_Table33.TableName
        p_RpHoaDon.XrSubreport1.ReportSource = p_RpHoaDonSub
        p_RpHoaDon.XrSubreport2.ReportSource = p_RpHoaDonSub2
        p_RpHoaDon.ShowPreviewDialog()
    End Sub


    Private Sub XemMauHoaDon_GTGT(ByVal p_UserName As String, ByVal p_SoLenh As String, ByVal p_DataSet As DataSet, _
                                ByRef p_Error As Boolean, ByRef p_StringError As String, _
                                ByRef p_StringValue As String, ByVal p_Patten As String, ByVal p_Serial As String, ByVal p_MaTraCuu As String)


        '  Dim p_Obj As Object
        Dim p_RpHoaDon As New KV2_HoaDon_New
        Dim p_RpHoaDonSub As New KV2_HoaDon_SubNew
        Dim p_RpHoaDonSub2 As New KV2_HoaDon_SubNew2
        Dim p_Table1, p_Table0, p_Table33 As DataTable
        Dim p_Total, p_VatAmount, p_Amount As Double
        Dim p_Table5 As DataTable
        Dim p_Count As Integer
        Dim p_String, p_String1, p_String2 As String
        p_Table0 = p_DataSet.Tables(0)
        p_Table1 = p_DataSet.Tables(4)
        p_Table5 = p_DataSet.Tables(5)


        If Not p_Table0 Is Nothing Then
            If p_Table0.Rows.Count > 0 Then
                p_RpHoaDon.Parameters.Item("p_MaTraCuu").Value = p_Table0.Rows(0).Item(0).ToString.Trim
            End If
        End If

        If Not p_Table1 Is Nothing Then
            If p_Table1.Rows.Count > 0 Then
                p_RpHoaDon.Parameters.Item("MauSoHD").Value = p_Table1.Rows(0).Item("Pattern").ToString.Trim
                p_RpHoaDon.Parameters.Item("KyHieuHD").Value = p_Table1.Rows(0).Item("Serial").ToString.Trim
                p_RpHoaDon.Parameters.Item("p_SoHoaDon").Value = p_Table1.Rows(0).Item("SoHoaDon").ToString.Trim
                p_RpHoaDon.Parameters.Item("P_MaSoThue_BH").Value = p_Table1.Rows(0).Item("MST").ToString.Trim
            End If
        End If

        If Not p_DataSet.Tables(1) Is Nothing Then
            p_DataSet.Tables(1).Columns.Add("sTotal")
            p_DataSet.Tables(1).Columns.Add("sVatAmount")
            p_DataSet.Tables(1).Columns.Add("sAmount")
            If p_DataSet.Tables(1).Rows.Count > 0 Then
                Double.TryParse(p_DataSet.Tables(1).Rows(0).Item("Total").ToString.Trim, p_Total)
                Double.TryParse(p_DataSet.Tables(1).Rows(0).Item("VatAmount").ToString.Trim, p_VatAmount)
                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_Total > 0 Then
                    p_String = Format(p_Total, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(1).Rows(0).Item("sTotal") = p_String
                End If

                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_VatAmount > 0 Then
                    p_String = Format(p_VatAmount, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(1).Rows(0).Item("sVatAmount") = p_String
                End If

                p_Amount = p_Total + p_VatAmount
                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_Amount > 0 Then
                    p_String = Format(p_Amount, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(1).Rows(0).Item("sAmount") = p_String
                End If


                If Not p_Table5 Is Nothing Then
                    If p_Table5.Rows.Count > 0 Then
                        p_RpHoaDon.Parameters.Item("CongTy").Value = p_Table5.Rows(0).Item("TenDonVi").ToString
                        p_RpHoaDon.XrLabel26.Text = p_Table5.Rows(0).Item("sGio").ToString
                        'XrLabel26
                    End If
                End If
                'Format(p_Total,"#,###,###,##0.##")
                p_RpHoaDon.Parameters.Item("P_Ngay").Value = Mid(p_DataSet.Tables(1).Rows(0).Item("ArisingDate").ToString, 1, 2)
                p_RpHoaDon.Parameters.Item("P_Thang").Value = Mid(p_DataSet.Tables(1).Rows(0).Item("ArisingDate").ToString, 4, 2)
                p_RpHoaDon.Parameters.Item("P_Nam").Value = Mid(p_DataSet.Tables(1).Rows(0).Item("ArisingDate").ToString, 7, 4)
                'p_RpHoaDon.Parameters.Item("P_ThueGTGT").Value = p_DataSet.Tables(1).Rows(0).Item("VatRate")
                'p_RpHoaDon.Parameters.Item("P_TienThueGTGT").Value = p_DataSet.Tables(1).Rows(0).Item("VatAmount")
                'p_RpHoaDon.Parameters.Item("P_TongCong").Value = p_DataSet.Tables(1).Rows(0).Item("Total")
                'p_RpHoaDon.Parameters.Item("P_TongThanhToan").Value = p_DataSet.Tables(1).Rows(0).Item("Amount")

                p_String = ""
                Try
                    p_String = p_DataSet.Tables(1).Rows(0).Item("VatRate").ToString.Trim & "%"
                Catch ex As Exception

                End Try
                p_RpHoaDonSub2.Parameters.Item("P_ThueGTGT").Value = p_String ' p_DataSet.Tables(1).Rows(0).Item("VatRate")
                p_RpHoaDonSub2.Parameters.Item("P_TienThueGTGT").Value = p_DataSet.Tables(1).Rows(0).Item("sVatAmount")
                p_RpHoaDonSub2.Parameters.Item("P_TongCong").Value = p_DataSet.Tables(1).Rows(0).Item("sTotal")
                p_RpHoaDonSub2.Parameters.Item("P_TongThanhToan").Value = p_DataSet.Tables(1).Rows(0).Item("sAmount")

            End If
        End If
        p_RpHoaDon.DataSource = p_DataSet.Tables(1)
        p_RpHoaDon.DataMember = p_DataSet.Tables(1).TableName
        p_Table33 = p_DataSet.Tables(3).Clone
        Dim p_Row As DataRow

        p_DataSet.Tables(3).Columns.Add("sProdQuantity")
        p_DataSet.Tables(3).Columns.Add("sProdPrice")
        p_DataSet.Tables(3).Columns.Add("sAmount")

        For p_Count = 0 To p_DataSet.Tables(3).Rows.Count - 1
            Double.TryParse(p_DataSet.Tables(3).Rows(p_Count).Item("Amount").ToString.Trim, p_Total)
            If p_Total > 0 Then
                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_Total > 0 Then
                    p_String = Format(p_Total, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(3).Rows(p_Count).Item("sAmount") = p_String
                End If
                Double.TryParse(p_DataSet.Tables(3).Rows(p_Count).Item("ProdQuantity").ToString.Trim, p_Total)
                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_Total > 0 Then
                    p_String = Format(p_Total, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(3).Rows(p_Count).Item("sProdQuantity") = p_String
                End If
                Double.TryParse(p_DataSet.Tables(3).Rows(p_Count).Item("ProdPrice").ToString.Trim, p_Total)
                p_String = ""
                p_String1 = ""
                p_String2 = ""
                If p_Total > 0 Then
                    p_String = Format(p_Total, "#,###,###,###,##0.##")
                    p_String1 = p_String
                    If InStr(p_String, ".", CompareMethod.Text) > 0 Then
                        p_String2 = Mid(p_String, InStr(p_String, ".", CompareMethod.Text) + 1)
                    End If
                    p_String1 = Replace(p_String1, p_String2, "")
                    p_String = Replace(p_String1, ",", ".")
                    If p_String2.Length > 0 Then
                        p_String = p_String & "," & p_String2
                    End If
                    p_DataSet.Tables(3).Rows(p_Count).Item("sProdPrice") = p_String
                End If
            End If
        Next


        For p_Count = 8 To p_DataSet.Tables(3).Rows.Count Step -1
            p_Row = p_Table33.NewRow
            p_Table33.Rows.Add(p_Row)
        Next

        p_RpHoaDonSub.DataSource = p_DataSet.Tables(3)
        p_RpHoaDonSub.DataMember = p_DataSet.Tables(3).TableName

        p_RpHoaDonSub2.DataSource = p_Table33
        p_RpHoaDonSub2.DataMember = p_Table33.TableName
        p_RpHoaDon.XrSubreport1.ReportSource = p_RpHoaDonSub
        p_RpHoaDon.XrSubreport2.ReportSource = p_RpHoaDonSub2
        p_RpHoaDon.ShowPreviewDialog()
    End Sub

    Public Sub TaoMaTraCuu(ByVal p_User As String, ByVal p_SoLenh As String, _
                           ByRef p_MaTraCuu As String, ByRef p_SoHD As String, _
                           ByVal p_LoaiChungTu As String)
        Dim p_SQL As String = ""
        Dim p_xml As XmlDocument
        Dim p_Datatable As DataTable
        p_MaTraCuu = ""
        'If g_1EndPointAddress = "" Then
        '    GetInforLinkCompany()
        'End If
        Dim p_DO1 As Boolean = False
        Dim p_tbl As DataTable
        'If g_1EndPointAddress = "" Then
        '    GetInforLinkCompany()
        'End If
        If g_1EndPointAddress = "" Then
            p_SQL = "exec LenhXuatDO1 '" & p_SoLenh & "'"
            p_tbl = GetDataTable(p_SQL, p_SQL)
            If Not p_tbl Is Nothing Then
                If p_tbl.Rows.Count > 0 Then
                    p_DO1 = True
                End If
            End If
            If p_LoaiChungTu = "GTGT" And p_DO1 = True Then
                GetInforLinkCompany(True)
            Else
                GetInforLinkCompany(False)
            End If
        End If
       
        If g_1EndPointAddress = "" Or g_1EndPointUser = "" Or g_1EndPointPass = "" Then
            ShowMessageBox("", "Thông tin kết nối không đúng")
            Exit Sub
        End If
Line_TT:

        p_SQL = "exec TaoMaTraCuu '" & p_SoLenh & "','" & g_UserName & "', '" & p_LoaiChungTu & "'"
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
            If g_TaoMaTraCuu = True Then
                Exit Sub
            End If
            Dim p_String = ""
            ' Dim remoteAddress = New System.ServiceModel.EndpointAddress(g_2EndPointAddress)
            Dim p_RowArr() As DataRow
            Try

                p_String = g_PortalService.listInvByCusFkey(p_MaTraCuu, "", "", g_1EndPointUserWS, g_1EndPointPassWS)
                If Not g_TableMessage Is Nothing Then
                    p_RowArr = g_TableMessage.Select("FunctionName = '" & g_LISTINVBYCUSFKEY & "'  and   Code ='" & p_String & "'")
                    If p_RowArr.Length > 0 Then
                        ShowMessageBox("", p_RowArr(0).Item("sDescription").ToString.Trim)
                        '  p_StringError = p_RowArr(0).Item("sDescription").ToString.Trim
                        p_MaTraCuu = ""
                        Exit Sub
                    ElseIf Strings.Left(p_String, 2) = "OK" Or UCase(p_String) = UCase("<Data></Data>") Then
                        Exit Sub
                    Else    ''Ma tra cuu ca gan cho HDDT

                        p_xml = New XmlDocument
                        p_SoHD = ""
                        p_xml.LoadXml(p_String)
                        Try
                            p_SoHD = p_xml.SelectNodes("Data").Item(0).SelectNodes("Item").Item(0).SelectNodes("invNum").Item(0).InnerText
                        Catch ex As Exception

                        End Try
                        'If p_SoHD <> "" Then
                        ' p_MaTraCuu = ""
                        Exit Sub
                        'End If
                        'p_MaTraCuu = ""
                        'GoTo Line_TT
                        ' Exit Sub
                    End If
                End If
            Catch ex As Exception
                p_SQL = ex.Message
            End Try


        End If
    End Sub



    Private Sub TaoHoaDonDienTu(ByVal p_UserName As String, ByVal p_SoLenh As String, ByVal p_DataSet As DataSet, _
                                ByVal p_LoatCT As String, ByRef p_Error As Boolean, ByRef p_StringError As String, _
                                ByRef p_StringValue As String, ByVal p_Patten As String, ByVal p_Serial As String)
        '  Dim remoteAddress = New System.ServiceModel.EndpointAddress(g_1EndPointAddress)
        ' Dim p_RowArr() As DataRow
        Dim p_String As String = ""
        Dim p_PathTem As String = ""
        Dim p_FileName As String = ""
        Dim p_RowArr() As DataRow
        Dim p_FileTemp As String
        p_StringError = ""
        p_Error = False
        Dim p_SQL As String = ""
        Dim p_tbl As DataTable
        Dim p_XMLString As String = ""
        Dim p_DO1 As Boolean = False
        p_FileTemp = Application.StartupPath & "\GTGTTEMP.xml"

        p_XMLString = ""
        CreateXMLHoaDonGTGT(p_DataSet, p_FileTemp, p_XMLString)


        Try
            ' Dim p_SerVice As New publishservice.PublishServiceSoapClient(New System.ServiceModel.BasicHttpBinding(), remoteAddress)
            'Dim p_SerVice As publishservice.PublishServiceSoapClient
            'CreateServicePublic(p_SerVice)
            p_StringValue = ""

            If p_XMLString <> "" Then
                ' p_XMLString = " <tem:xmlInvData>" & p_XMLString & "</tem:xmlInvData>"
              
                'If p_DO1 = False Then
                '    p_StringValue = g_PublicService.ImportAndPublishInv(g_1EndPointUser, g_1EndPointPass, p_XMLString, g_1EndPointUserWS, _
                '                                           g_1EndPointPassWS, p_Patten, p_Serial, 0)      '(p_MaTraCuu, "", "", g_1EndPointUserWS, g_1EndPointPassWS)
                'Else
                p_StringValue = g_PublicService.ImportAndPublishInv(g_1EndPointUser, g_1EndPointPass, p_XMLString, g_1EndPointUserWS, _
                                                           g_1EndPointPassWS, p_Patten, p_Serial, 0)      '(p_MaTraCuu, "", "", g_1EndPointUserWS, g_1EndPointPassWS)
                'End If
                'p_StringValue = g_PublicService.ImportAndPublishInv(g_1EndPointUser, g_1EndPointPass, p_XMLString, g_1EndPointUserWS, _
                '                                            g_1EndPointPassWS, p_Patten, p_Serial, 0)      '(p_MaTraCuu, "", "", g_1EndPointUserWS, g_1EndPointPassWS)
            End If

            If Not g_TableMessage Is Nothing Then
                p_RowArr = g_TableMessage.Select("FunctionName = '" & g_IMPORTANDPUBLISHINV & "'  and   Code ='" & p_StringValue & "'")
                If p_RowArr.Length > 0 Then
                    ShowMessageBox("", p_RowArr(0).Item("sDescription").ToString.Trim)
                    p_StringValue = ""
                    Exit Sub
                ElseIf Strings.Left(p_String, 2) = "OK" Or UCase(p_StringValue) = UCase("<Data></Data>") Then
                    Exit Sub
                Else
                    ShowMessageBox("", p_StringValue)
                    p_StringValue = ""
                    Exit Sub
                End If
            End If


        Catch ex As Exception
            p_Error = True
            p_StringError = ex.Message
        End Try
    End Sub

    Private Sub TESTTaoHoaDonDienTu(ByVal p_LoaiChungTu As String, ByVal p_UserName As String, ByVal p_SoLenh As String, ByVal p_DataSet As DataSet, _
                                ByRef p_Error As Boolean, ByRef p_StringError As String, _
                                ByRef p_StringValue As String, ByVal p_Patten As String, ByVal p_Serial As String, ByVal p_MaTraCuu As String)
        Dim remoteAddress = New System.ServiceModel.EndpointAddress(g_1EndPointAddress)
        ' Dim p_RowArr() As DataRow
        Dim p_String As String = ""
        Dim p_PathTem As String = ""
        Dim p_FileName As String = ""
        Dim p_RowArr() As DataRow
        Dim p_FileTemp As String
        p_StringError = ""
        p_Error = False
        Dim p_SQL As String
        Dim p_XMLString As String = ""

        p_FileTemp = Application.StartupPath & "\GTGTTEMP.xml"


        '  p_XMLString = p_DataSet.Tables(2).Rows(0).Item("XML2")

        p_XMLString = ""
        CreateXMLHoaDonGTGT(p_DataSet, p_FileTemp, p_XMLString)


        Try
            '  Dim p_SerVice As New TEST.PublishService
            'Dim p_Services22 As publishservice.PublishServiceSoapClient
            'CreateServicePublic(p_Services22)
            p_StringValue = String.Empty

            ' p_SerVice.Url = g_2EndPointAddress
            ' p_Services22.im()


            If p_XMLString <> "" Then
                ' p_XMLString = " <tem:xmlInvData>" & p_XMLString & "</tem:xmlInvData>"

                p_StringValue = g_PublicService.ImportAndPublishInv(g_1EndPointUser, g_1EndPointPass, p_XMLString, g_1EndPointUserWS, g_1EndPointPassWS, p_Patten, p_Serial, 0)
                '  p_StringValue = p_SerVice.ImportAndPublishInv(g_1EndPointUser, g_1EndPointPass, p_XMLString, g_1EndPointUserWS, g_1EndPointPassWS, p_Patten, p_Serial, 0) '(p_MaTraCuu, "", "", g_1EndPointUserWS, g_1EndPointPassWS)
            End If

            If Not g_TableMessage Is Nothing Then
                p_RowArr = g_TableMessage.Select("FunctionName = '" & g_IMPORTANDPUBLISHINV & "'  and   Code ='" & p_StringValue & "'")
                If p_RowArr.Length > 0 Then
                    ShowMessageBox("", p_RowArr(0).Item("sDescription").ToString.Trim)
                    p_StringError = p_RowArr(0).Item("sDescription").ToString.Trim
                    p_Error = True
                    p_StringValue = ""
                    Exit Sub
                ElseIf Strings.Left(p_StringValue, 3) = "OK:" Or UCase(p_StringValue) = UCase("<Data></Data>") Then
                    Dim p_SoHoaDon, p_KyHieuHoaDon, p_MauSoHoaDon As String
                    Dim p_Table As DataTable
                    p_SoHoaDon = ""
                    p_KyHieuHoaDon = ""
                    p_MauSoHoaDon = ""
                    ThongTinHoaDon(p_MaTraCuu, p_SoHoaDon, p_MauSoHoaDon, p_KyHieuHoaDon, p_Error, p_StringError)
                    If p_SoHoaDon = "" Then
                        ShowMessageBox("", "Số hóa đơn không xác định")
                        p_Error = True
                        Exit Sub
                    Else
                        p_StringError = ""
                        p_SQL = "update  tblChungTu set  MaTraCuu='" & p_MaTraCuu & "',KyHieuHoaDon = '" & p_KyHieuHoaDon & _
                                "', txtSoHoaDon ='" & p_SoHoaDon & "', MauSoHoaDon ='" & p_MauSoHoaDon & "'  where SoLenh ='" & _
                                        p_SoLenh & "' and LoaiChungTu ='" & p_LoaiChungTu & "' ;"
                        p_SQL = p_SQL & "update tblMaTraCuu set SyncStatus= 'Y', SyncDate =getdate() ,KyHieuHoaDon = '" & p_KyHieuHoaDon & _
                                "', SoHoaDon ='" & p_SoHoaDon & "', MauSoHoaDon ='" & p_MauSoHoaDon & _
                                    "'   where SoLenh ='" & p_SoLenh & "' and MaTraCuu ='" & p_MaTraCuu & "';"
                        If SQL_Execute(p_SQL, p_StringError) = False Then
                            p_Error = True
                            'Else
                            '    HTTP_Open(p_MaTraCuu)
                        End If
                        ' p_Table = GetDataTable(p_SQL, p_SQL)

                        Exit Sub
                    End If


                Else
                    ShowMessageBox("", p_StringValue)
                    p_StringValue = ""
                    Exit Sub
                End If
            End If


        Catch ex As Exception
            p_Error = True
            p_StringError = ex.Message
        End Try
    End Sub

    Public Sub HTTP_Open(ByVal p_MaTRaCuu As String)
        Dim p_String As String = "" 'System.Text.StringBuilder
        Dim p_Error As String = ""
        Dim p_Path, p_FileName As String
        Dim p_MaTRaCuuWeb As String
        Dim p_FileStrim As FileStream
        '   Dim p_File As IO.File
        '  Dim p_FileName As String
        Dim p_Stream As Stream

        ' Dim p_Brower As New System.Diagnostics.Process()
        ' Dim p_Path As String
        Dim p_WebBrowserEx1 = New DevExpress.ExpressApp.HtmlPropertyEditor.Win.WebBrowserEx()
        Try

            p_MaTRaCuuWeb = p_MaTRaCuu
            p_MaTRaCuu = Replace(p_MaTRaCuu, "*", "", 1)

            p_Path = Environment.GetFolderPath(Environment.SpecialFolder.Favorites) ' Path.GetTempPath
            If Right(p_Path, 1) = "\" Then
                p_FileName = p_Path & "A" & p_MaTRaCuu & ".html"
            Else
                p_FileName = p_Path & "\A" & p_MaTRaCuu & ".html"
            End If


            'p_FileStrim =File.w IO.File.Create(p_Path)
            '  p_String = ""
            ' If g_PortalService Is Nothing Then
            Dim p_tbl As DataTable
            Dim p_DO1 As Boolean = False
            Dim p_SoLenh As String = ""
            Dim p_SQL As String = ""
            Dim p_LoaiCT As String = ""

            'If g_1EndPointAddress = "" Then
            '    GetInforLinkCompany()
            'End If
            p_SQL = "select SoLenh, LoaiChungTu  from tblchungtu where matracuu ='" & p_MaTRaCuu & "'"

            p_tbl = GetDataTable(p_SQL, p_SQL)
            If Not p_tbl Is Nothing Then
                If p_tbl.Rows.Count > 0 Then
                    '  p_DO1 = True
                    p_SoLenh = p_tbl.Rows(0).Item("SoLenh").ToString.Trim
                    p_LoaiCT = p_tbl.Rows(0).Item("LoaiChungTu").ToString.Trim
                End If
            End If


            p_SQL = "exec LenhXuatDO1 '" & p_SoLenh & "'"
            p_tbl = GetDataTable(p_SQL, p_SQL)
            If Not p_tbl Is Nothing Then
                If p_tbl.Rows.Count > 0 Then
                    p_DO1 = True
                End If
            End If
            If p_LoaiCT = "GTGT" And p_DO1 = True Then
                GetInforLinkCompany(True)
                'CreateServicePublicDO1(g_PublicService)
                'CreateServicePortalDO1(g_PortalService)
                'CreateServiceBusinessDO1(g_BusinessService)
            Else
                GetInforLinkCompany(False)
                'CreateServicePublic(g_PublicService)
                'CreateServicePortal(g_PortalService)
                'CreateServiceBusiness(g_BusinessService)
            End If
            '  End If

            p_String = g_PortalService.getInvViewFkeyNoPay(p_MaTRaCuuWeb, g_1EndPointUserWS, g_1EndPointPassWS)  '"20A5P39N"

            If Left(p_String, 3) = "ERR" Then
                ShowMessageBox("", p_String)
                Exit Sub
            End If

            'Dim WebBrowser1 As New WebBrowser
            'WebBrowser1.DocumentText = p_String  '.Write(p_String)

            ''WebBrowser1.Url = p_URL   ' "C:\Users\VirtualPC\Favorites"
            'WebBrowser1.AllowNavigation = False
            '' WebBrowser1.Navigate(New Uri("C:\Users\VirtualPC\Favorites\A20MEGE2H.html"))
            '' WebBrowser1.SuspendLayout()
            '' WebBrowser1.ObjectForScripting
            'WebBrowser1.ScriptErrorsSuppressed = True
            'WebBrowser1.Document.Write(p_String)
            '' WebBrowser1.WebBrowserShortcutsEnabled = False
            'WebBrowser1.ShowPrintPreviewDialog()
            'WebBrowser1.Navigate(New Uri("C:\Users\VirtualPC\Favorites\A20HV4G0N.html"))
            'Exit Sub

            'Dim p_FormShow As New Form1
            ''p_FormShow.g_HoaDonValue2 = p_stream2
            'p_FormShow.g_HoaDonValue = p_String
            'p_FormShow.ShowDialog()

            'Exit Sub
            'Dim p_Wr As StreamWriter
            'p_Wr = New StreamWriter(p_FileName, False)
            'p_Wr.Write(True, p_String)

            File.WriteAllText(p_FileName, p_String)
            '  File.w(p_FileName, p_String)
            'p_FileStrim = IO.File.Create(p_Path)
            'p_FileStrim.Write(p_String)
            Dim p_abc As System.Diagnostics.Process
            p_abc = Process.Start(p_FileName)

            'p_abc.WaitForExit(60000)
            'WebBrowser1.ScriptErrorsSuppressed = True

            'File.Delete(p_FileName)

            Exit Sub



            ''Dim p_bytes() As Byte = System.Text.Encoding.UTF8.GetBytes(p_String)
            ''Dim p_stream2 As MemoryStream = New MemoryStream(p_bytes)




            ''p_Stream = readtostream(p_String)

            ''p_Webbrower.DocumentText = p_String   '.Write(p_String)
            ''p_Webbrower.ScriptErrorsSuppressed = True
            ''p_Webbrower.Dock = DockStyle.Fill
            ''p_Webbrower.AllowNavigation = True
            '''p_Webbrower.
            '''  p_String = ""
            ''' p_Webbrower.pr
            ''p_Webbrower.Height = Screen.PrimaryScreen.WorkingArea.Height
            ''p_Webbrower.Width = Screen.PrimaryScreen.WorkingArea.Width
            '''Dim p_Object As Object
            '''p_Object = p_Webbrower.ActiveXInstance
            '''p_Object.execwb(63, 0, 10, IntPtr.Zero)
            ''p_Webbrower.Document.Write(p_String)
            ''p_Webbrower.ShowPrintPreviewDialog()

            ''p_Webbrower.Height = Screen.PrimaryScreen.WorkingArea.Height
            ''p_Webbrower.Width = Screen.PrimaryScreen.WorkingArea.Width
            '''p_ObjFile.Close()
            '''  p_Brower.StartInfo.Arguments.
            ''' p_ObjFile.Flush()

            '''p_Brower.StartInfo = New System.Diagnostics.ProcessStartInfo("iexplore")
            '''p_Brower.StartInfo.Arguments = p_FileName

            '''p_Brower.Start()
            '''If p_Brower.WaitForInputIdle(6000000) = True Then

            '''Else

            '''End If

        Catch ex As Exception
            p_Error = ex.Message
        End Try
        If p_Error <> "" Then
            ShowMessageBox("", p_Error)
        End If

        ' Exit Sub


    End Sub

    Private Sub ThongTinHoaDon(ByVal p_MaTraCuu As String, ByRef p_SoHoaDon As String, ByRef p_MauSoHoaDon As String, ByRef p_KyHieuHoaDon As String, ByRef p_Error As Boolean, ByRef p_StringError As String)

        Dim p_String As String = ""
        Dim p_xml As XmlDocument
        Dim p_RowArr() As DataRow
        p_Error = False
        p_SoHoaDon = ""
        p_KyHieuHoaDon = ""
        p_MauSoHoaDon = ""
        p_String = g_PortalService.listInvByCusFkey(p_MaTraCuu, "", "", g_1EndPointUserWS, g_1EndPointPassWS)
        If Not g_TableMessage Is Nothing Then
            p_RowArr = g_TableMessage.Select("FunctionName = '" & g_LISTINVBYCUSFKEY & "'  and   Code ='" & p_String & "'")
            If p_RowArr.Length > 0 Then
                ShowMessageBox("", p_RowArr(0).Item("sDescription").ToString.Trim)
                '  p_StringError = p_RowArr(0).Item("sDescription").ToString.Trim
                'p_MaTraCuu = ""
                p_Error = True
                p_StringError = p_RowArr(0).Item("sDescription").ToString.Trim
                Exit Sub
            ElseIf Strings.Left(p_String, 2) = "OK" Or UCase(p_String) = UCase("<Data></Data>") Then
                Exit Sub
            Else    ''Ma tra cuu ca gan cho HDDT

                p_xml = New XmlDocument
                p_SoHoaDon = ""
                p_xml.LoadXml(p_String)
                Try
                    p_SoHoaDon = p_xml.SelectNodes("Data").Item(0).SelectNodes("Item").Item(0).SelectNodes("invNum").Item(0).InnerText
                    p_MauSoHoaDon = p_xml.SelectNodes("Data").Item(0).SelectNodes("Item").Item(0).SelectNodes("pattern").Item(0).InnerText
                    p_KyHieuHoaDon = p_xml.SelectNodes("Data").Item(0).SelectNodes("Item").Item(0).SelectNodes("serial").Item(0).InnerText
                Catch ex As Exception
                    p_StringError = ex.Message
                    p_Error = True

                End Try
                'If p_SoHD <> "" Then
                ' p_MaTraCuu = ""
                Exit Sub
                'End If
                'p_MaTraCuu = ""
                'GoTo Line_TT
                ' Exit Sub
            End If
        End If
    End Sub

    Private Sub GetHDDT_Infor22(ByVal p_MaTraCuu As String, ByRef p_Error As Boolean, ByRef p_StringError As String)

        Dim p_String As String
        '  ggsdgds()
        Try
            p_Error = False
            '  Dim remoteAddress = New System.ServiceModel.EndpointAddress(g_2EndPointAddress)
            'Dim p_SerVice As portalservice.PortalServiceSoapClient

            '  CreateServicePortal(p_SerVice)
            p_String = g_PortalService.getInvViewFkeyNoPay(p_MaTraCuu, g_1EndPointUserWS, g_1EndPointPassWS)
        Catch ex As Exception
            p_Error = True
            p_StringError = ex.Message
        End Try

    End Sub



    Public Sub HDDT_Cancel(ByVal p_LoaiChungTu As String, ByVal p_MaTraCuu As String, ByVal p_SoLenh As String, _
                           ByVal p_note As String, ByRef p_Error As Boolean, ByRef p_StringError As String)

        Dim p_String As String
        Dim p_RowArr() As DataRow
        Dim p_SQL As String = ""
        Dim p_Data As DataTable
        '  ggsdgds()
        Try
            p_SQL = "select 1 from tblLenhXuatE5 with (nolock) where SoLenh ='" & p_SoLenh & "'  and  isnull(Status,'') ='5' "
            p_Data = GetDataTable(p_SQL, p_SQL)
            If Not p_Data Is Nothing Then
                If p_Data.Rows.Count > 0 Then
                    p_Error = True
                    p_StringError = "Trạng thái lệnh xuất không đúng"
                    Exit Sub
                End If
            End If
            p_Error = False

            Dim p_tbl As DataTable
            Dim p_DO1 As Boolean = False
         
            Dim p_LoaiCT As String = ""

            'If g_1EndPointAddress = "" Then
            '    GetInforLinkCompany()
            'End If
            p_SQL = "select SoLenh, LoaiChungTu  from tblchungtu where matracuu ='" & p_MaTraCuu & "'"

            p_tbl = GetDataTable(p_SQL, p_SQL)
            If Not p_tbl Is Nothing Then
                If p_tbl.Rows.Count > 0 Then
                    '  p_DO1 = True
                    p_SoLenh = p_tbl.Rows(0).Item("SoLenh").ToString.Trim
                    p_LoaiCT = p_tbl.Rows(0).Item("LoaiChungTu").ToString.Trim
                End If
            End If


            p_SQL = "exec LenhXuatDO1 '" & p_SoLenh & "'"
            p_tbl = GetDataTable(p_SQL, p_SQL)
            If Not p_tbl Is Nothing Then
                If p_tbl.Rows.Count > 0 Then
                    p_DO1 = True
                End If
            End If
            If p_LoaiCT = "GTGT" And p_DO1 = True Then
                GetInforLinkCompany(True)
                'CreateServicePublicDO1(g_PublicService)
                'CreateServicePortalDO1(g_PortalService)
                'CreateServiceBusinessDO1(g_BusinessService)
            Else
                GetInforLinkCompany(False)
                'CreateServicePublic(g_PublicService)
                'CreateServicePortal(g_PortalService)
                'CreateServiceBusiness(g_BusinessService)
            End If

            p_String = g_BusinessService.cancelInv(g_1EndPointUser, g_1EndPointPass, p_MaTraCuu, g_1EndPointUserWS, g_1EndPointPassWS, p_note) ''.   ' .getInvViewFkeyNoPay(p_MaTraCuu, g_1EndPointUserWS, g_1EndPointPassWS)

            p_RowArr = g_TableMessage.Select("FunctionName = '" & g_cancelInv & "'  and   Code ='" & p_String & "'")
            If p_RowArr.Length > 0 Then
                ShowMessageBox("", p_RowArr(0).Item("sDescription").ToString.Trim)
                p_StringError = p_RowArr(0).Item("sDescription").ToString.Trim
                p_Error = True
                p_String = ""
                Exit Sub
            ElseIf Strings.Left(p_String, 3) = "OK:" Or UCase(p_String) = UCase("<Data></Data>") Then
                ' p_SQL = "update  tblChungTu set  MaTraCuu=null,KyHieuHoaDon =null, txtSoHoaDon =null, MauSoHoaDon =null  where SoLenh ='" & p_SoLenh & "';"
                'p_SQL = p_SQL & "update tblMaTraCuu set SyncStatus= 'Y', SyncDate =getdate() ,KyHieuHoaDon = '" & p_KyHieuHoaDon & _
                '        "', SoHoaDon ='" & p_SoHoaDon & "', MauSoHoaDon ='" & p_MauSoHoaDon & _
                '            "'   where SoLenh ='" & p_SoLenh & "' and MaTraCuu ='" & p_MaTraCuu & "';"
                p_SQL = "exec HuyHoaDon '" & p_SoLenh & "', '" & p_LoaiChungTu & "','" & g_UserName & "','" & p_note & "'"
                p_Data = GetDataTable(p_SQL, p_SQL)
                p_Error = True
                If Not p_Data Is Nothing Then
                    If p_Data.Rows.Count > 0 Then
                        If p_Data.Rows(0).Item(0) = 0 Then
                            p_Error = False
                        Else
                            p_StringError = p_Data.Rows(0).Item(0).ToString.Trim
                        End If
                    End If
                End If
                Exit Sub
            Else
                ShowMessageBox("", p_String)
                p_String = ""
                Exit Sub
            End If

        Catch ex As Exception
            p_Error = True
            p_StringError = ex.Message
        End Try

    End Sub




    Public Sub UpdateCustomer(ByVal comTaxCode As String, ByVal cusTaxCode As String _
                            , ByRef p_Error As Boolean, ByRef p_StringError As String)

        Dim p_String As String
        Dim p_RowArr() As DataRow
        Dim p_SQL As String = ""
        Dim p_Data As DataTable

        Dim p_XMLString As String = ""

        '  ggsdgds()
        Try
            p_Error = False
            If p_XMLString <> "" Then
                p_String = g_PublicService.UpdateCus(p_XMLString, g_1EndPointUser, g_1EndPointPass, 0)
            End If
            ' .getInvViewFkeyNoPay(p_MaTraCuu, g_1EndPointUserWS, g_1EndPointPassWS)

            p_RowArr = g_TableMessage.Select("FunctionName = '" & g_UpdateCustomer & "'  and   Code ='" & p_String & "'")
            If p_RowArr.Length > 0 Then
                ShowMessageBox("", p_RowArr(0).Item("sDescription").ToString.Trim)
                p_StringError = p_RowArr(0).Item("sDescription").ToString.Trim
                p_Error = True
                p_String = ""
                Exit Sub
            ElseIf Strings.Left(p_String, 3) = "OK:" Or UCase(p_String) = UCase("<Data></Data>") Then

                Exit Sub
            Else
                ShowMessageBox("", p_String)
                p_String = ""
                Exit Sub
            End If

        Catch ex As Exception
            p_Error = True
            p_StringError = ex.Message
        End Try

    End Sub



    Public Sub CreateServicePortal(ByRef p_SerVice As portalservice.PetroServiceSoapClient)
        Try
            ' var binding = new BasicHttpBinding();
            'binding.ProxyAddress = new Uri(string.Format("http://{0}:{1}", proxyAddress, proxyPort));
            'binding.UseDefaultWebProxy = false;
            'binding.Security.Mode = BasicHttpSecurityMode.Transport;
            'binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            'binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.Basic;

            'var endpoint = new EndpointAddress("serviceadress");

            'var authenticationClient = new WOKMWSAuthenticateClient(binding, endpoint);
            'authenticationClient.ClientCredentials.UserName.UserName = username;
            'authenticationClient.ClientCredentials.UserName.Password = password;
            'if you want to run it on your local you should this code.

            'ServicePointManager.Expect100Continue = false;

            Dim remoteAddress = New System.ServiceModel.EndpointAddress(g_2EndPointAddress)
            'Dim p_Binding As New System.ServiceModel.BasicHttpBinding(BasicHttpSecurityMode.Transport)
            Dim p_Binding As System.ServiceModel.BasicHttpBinding
            If InStr(UCase(g_1EndPointAddress), UCase("https"), CompareMethod.Text) > 0 Then
                p_Binding = New System.ServiceModel.BasicHttpBinding(BasicHttpSecurityMode.Transport)
            Else
                p_Binding = New System.ServiceModel.BasicHttpBinding()
            End If
            p_Binding.MaxReceivedMessageSize = 2147483647
            p_SerVice = New portalservice.PetroServiceSoapClient(p_Binding, remoteAddress)

        Catch ex As Exception

        End Try


    End Sub


    Public Sub CreateServicePortalDO1(ByRef p_SerVice As portalservice.PetroServiceSoapClient)
        Try

            ' var binding = new BasicHttpBinding();
            'binding.ProxyAddress = new Uri(string.Format("http://{0}:{1}", proxyAddress, proxyPort));
            'binding.UseDefaultWebProxy = false;
            'binding.Security.Mode = BasicHttpSecurityMode.Transport;
            'binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            'binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.Basic;

            'var endpoint = new EndpointAddress("serviceadress");

            'var authenticationClient = new WOKMWSAuthenticateClient(binding, endpoint);
            'authenticationClient.ClientCredentials.UserName.UserName = username;
            'authenticationClient.ClientCredentials.UserName.Password = password;
            'if you want to run it on your local you should this code.

            'ServicePointManager.Expect100Continue = false;


            Dim remoteAddress = New System.ServiceModel.EndpointAddress(g_22EndPointAddress)
            'Dim p_Binding As New System.ServiceModel.BasicHttpBinding()
            Dim p_Binding As System.ServiceModel.BasicHttpBinding
            If InStr(UCase(g_1EndPointAddress), UCase("https"), CompareMethod.Text) > 0 Then
                p_Binding = New System.ServiceModel.BasicHttpBinding(BasicHttpSecurityMode.Transport)
            Else
                p_Binding = New System.ServiceModel.BasicHttpBinding()
            End If
            p_Binding.MaxReceivedMessageSize = 2147483647
            p_SerVice = New portalservice.PetroServiceSoapClient(p_Binding, remoteAddress)

        Catch ex As Exception

        End Try


    End Sub


    Public Sub CreateServiceBusiness(ByRef p_SerVice As BusinessService.BusinessServiceSoapClient)
        Try
            ' var binding = new BasicHttpBinding();
            'binding.ProxyAddress = new Uri(string.Format("http://{0}:{1}", proxyAddress, proxyPort));
            'binding.UseDefaultWebProxy = false;
            'binding.Security.Mode = BasicHttpSecurityMode.Transport;
            'binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            'binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.Basic;

            'var endpoint = new EndpointAddress("serviceadress");

            'var authenticationClient = new WOKMWSAuthenticateClient(binding, endpoint);
            'authenticationClient.ClientCredentials.UserName.UserName = username;
            'authenticationClient.ClientCredentials.UserName.Password = password;
            'if you want to run it on your local you should this code.

            'ServicePointManager.Expect100Continue = false;
            Dim remoteAddress = New System.ServiceModel.EndpointAddress(g_3EndPointAddress)
            ' Dim p_Binding As New System.ServiceModel.BasicHttpBinding(BasicHttpSecurityMode.Transport)
            Dim p_Binding As System.ServiceModel.BasicHttpBinding
            If InStr(UCase(g_1EndPointAddress), UCase("https"), CompareMethod.Text) > 0 Then
                p_Binding = New System.ServiceModel.BasicHttpBinding(BasicHttpSecurityMode.Transport)
            Else
                p_Binding = New System.ServiceModel.BasicHttpBinding()
            End If

            p_Binding.MaxReceivedMessageSize = 2147483647
            ' p_Binding.Security =  .Transport
            '  p_Binding.
            p_SerVice = New BusinessService.BusinessServiceSoapClient(p_Binding, remoteAddress)


        Catch ex As Exception

        End Try

    End Sub


    Public Sub CreateServiceBusinessDO1(ByRef p_SerVice As BusinessService.BusinessServiceSoapClient)
        Try
            ' var binding = new BasicHttpBinding();
            'binding.ProxyAddress = new Uri(string.Format("http://{0}:{1}", proxyAddress, proxyPort));
            'binding.UseDefaultWebProxy = false;
            'binding.Security.Mode = BasicHttpSecurityMode.Transport;
            'binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            'binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.Basic;

            'var endpoint = new EndpointAddress("serviceadress");

            'var authenticationClient = new WOKMWSAuthenticateClient(binding, endpoint);
            'authenticationClient.ClientCredentials.UserName.UserName = username;
            'authenticationClient.ClientCredentials.UserName.Password = password;
            'if you want to run it on your local you should this code.

            'ServicePointManager.Expect100Continue = false;
            Dim remoteAddress = New System.ServiceModel.EndpointAddress(g_23EndPointAddress)
            'Dim p_Binding As New System.ServiceModel.BasicHttpBinding()
            Dim p_Binding As System.ServiceModel.BasicHttpBinding
            If InStr(UCase(g_1EndPointAddress), UCase("https"), CompareMethod.Text) > 0 Then
                p_Binding = New System.ServiceModel.BasicHttpBinding(BasicHttpSecurityMode.Transport)
            Else
                p_Binding = New System.ServiceModel.BasicHttpBinding()
            End If
            p_Binding.MaxReceivedMessageSize = 2147483647
            p_SerVice = New BusinessService.BusinessServiceSoapClient(p_Binding, remoteAddress)


        Catch ex As Exception

        End Try

    End Sub


    'Public Sub CreateServiceCheck(ByRef p_SerVice As ServiceCheck.GatewayServiceSoapClient)
    '    Try
    '        Dim remoteAddress = New System.ServiceModel.EndpointAddress("http://service-devhoadon.petrolimex.com.vn/GatewayService.asmx?WSDL") '"http://service-hoadon.petrolimex.com.vn/GatewayService.asmx?WSDL")
    '        p_SerVice = New ServiceCheck.GatewayServiceSoapClient(New System.ServiceModel.BasicHttpBinding(), remoteAddress)


    '    Catch ex As Exception

    '    End Try

    'End Sub



    Public Sub CreateServicePublic(ByRef p_SerVice As publishservice.PublishServiceSoapClient)
        Try
            ' var binding = new BasicHttpBinding();
            'binding.ProxyAddress = new Uri(string.Format("http://{0}:{1}", proxyAddress, proxyPort));
            'binding.UseDefaultWebProxy = false;
            'binding.Security.Mode = BasicHttpSecurityMode.Transport;
            'binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            'binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.Basic;

            'var endpoint = new EndpointAddress("serviceadress");

            'var authenticationClient = new WOKMWSAuthenticateClient(binding, endpoint);
            'authenticationClient.ClientCredentials.UserName.UserName = username;
            'authenticationClient.ClientCredentials.UserName.Password = password;
            'if you want to run it on your local you should this code.

            'ServicePointManager.Expect100Continue = false;

            Dim remoteAddress = New System.ServiceModel.EndpointAddress(g_1EndPointAddress)

            Dim p_Binding As System.ServiceModel.BasicHttpBinding
            If InStr(UCase(g_1EndPointAddress), UCase("https"), CompareMethod.Text) > 0 Then
                p_Binding = New System.ServiceModel.BasicHttpBinding(BasicHttpSecurityMode.Transport)
            Else
                p_Binding = New System.ServiceModel.BasicHttpBinding()
            End If
            p_Binding.MaxReceivedMessageSize = 2147483647
            p_SerVice = New publishservice.PublishServiceSoapClient(p_Binding, remoteAddress)

        Catch ex As Exception

        End Try


    End Sub





    Public Sub CreateServicePublicDO1(ByRef p_SerVice As publishservice.PublishServiceSoapClient)
        Try
            ' var binding = new BasicHttpBinding();
            'binding.ProxyAddress = new Uri(string.Format("http://{0}:{1}", proxyAddress, proxyPort));
            'binding.UseDefaultWebProxy = false;
            'binding.Security.Mode = BasicHttpSecurityMode.Transport;
            'binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            'binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.Basic;

            'var endpoint = new EndpointAddress("serviceadress");

            'var authenticationClient = new WOKMWSAuthenticateClient(binding, endpoint);
            'authenticationClient.ClientCredentials.UserName.UserName = username;
            'authenticationClient.ClientCredentials.UserName.Password = password;
            'if you want to run it on your local you should this code.

            'ServicePointManager.Expect100Continue = false;


            Dim remoteAddress = New System.ServiceModel.EndpointAddress(g_21EndPointAddress)
            'Dim p_Binding As New System.ServiceModel.BasicHttpBinding()
            Dim p_Binding As System.ServiceModel.BasicHttpBinding
            If InStr(UCase(g_1EndPointAddress), UCase("https"), CompareMethod.Text) > 0 Then
                p_Binding = New System.ServiceModel.BasicHttpBinding(BasicHttpSecurityMode.Transport)
            Else
                p_Binding = New System.ServiceModel.BasicHttpBinding()
            End If
            p_Binding.MaxReceivedMessageSize = 2147483647
            p_SerVice = New publishservice.PublishServiceSoapClient(p_Binding, remoteAddress)

        Catch ex As Exception

        End Try


    End Sub


    Private Sub CreateXML(ByVal p_DataSet As DataSet, ByVal p_FileTemp As String)

        Dim m_xmld As XmlDocument
        Dim m_nodeInvoiceslist As XmlNodeList
        Dim m_nodeInvoicelist As XmlNodeList
        Dim m_nodeInvlist As XmlNodeList
        Dim m_nodeProductslist As XmlNodeList
        Dim m_nodeProductlist As XmlNodeList
        Dim m_node As XmlNode
        Dim m_nodelist1 As XmlNode
        '  Dim m_node As XmlNode
        Dim m_nodeInv As XmlNode
        Dim m_nodeKey As XmlNode
        Dim m_nodeInvoice As XmlNode
        Dim p_RowInd As Integer
        Dim p_Count As Integer
        Dim p_Datatab0, p_Datatab1, p_Datatab2, p_Datatab3 As DataTable
        Dim p_SQL As String = ""
        m_xmld = New XmlDocument()
        m_xmld.Load(p_FileTemp)
        m_nodeInvoiceslist = m_xmld.SelectNodes("Invoices")    ' node  Invoices
        m_nodeInvlist = m_nodeInvoiceslist.Item(0).ChildNodes
        m_nodeKey = m_nodeInvlist.Item(0).ChildNodes.Item(0)      ' node  Key cua Inv
        m_nodeInv = m_nodeInvlist.Item(0).ChildNodes.Item(1)      ' node  Invoice cua Inv
        m_nodeInvoicelist = m_nodeInv.ChildNodes   ' node  Invoice
        For p_Count = 0 To m_nodeInvoicelist.Count - 1
            If UCase(m_nodeInvoicelist.Item(p_Count).Name) = "PRODUCTS" Then
                m_nodeProductslist = m_nodeInvoicelist.Item(p_Count).ChildNodes
                m_nodeProductlist = m_nodeProductslist.Item(0).ChildNodes
                Exit For
            End If
        Next
        If m_nodeProductlist.Count > 0 Then
            'p_DataSet.Tables(0).TableName = "Inv"
            'p_DataSet.Tables(1).TableName = "Invoice"
            'p_DataSet.Tables(2).TableName = "Products"
            'p_DataSet.Tables(3).TableName = "Product"
            p_Datatab0 = p_DataSet.Tables(0)
            p_Datatab1 = p_DataSet.Tables(1)
            p_Datatab2 = p_DataSet.Tables(2)
            p_Datatab3 = p_DataSet.Tables(3)
            For p_Count = 0 To p_Datatab3.Columns.Count - 1
                For p_RowInd = 0 To p_Datatab3.Rows.Count - 1
                    ' m_node = m_nodeProductlist.ite
                Next
            Next
        End If
        p_SQL = "adgf"
        'For Each m_node In m_nodelist


        '    Dim GameAttribute = m_node.Attributes.GetNamedItem("name").Value
        '    Dim name = m_node.ChildNodes.Item(0).InnerText
        '    Dim description = m_node.ChildNodes.Item(1).InnerText
        '    Dim manufacturer = m_node.ChildNodes.Item(2).InnerText
        '    Dim rotate = m_node.ChildNodes.Item(15).Attributes.GetNamedItem("rotate").Value
        '    Dim controles = m_node.ChildNodes.Item(17).ChildNodes.Item(0).Attributes.GetNamedItem("type").Value

        '    'MessageBox.Show("ROM: " & GameAttribute _
        '    '  & "-- Description: " & name & "-- Year: " _
        '    '  & description & "-- Manufacturer: " _
        '    '  & manufacturer & "-- Rotate: " _
        '    '  & rotate & "-- Control Type: " & controles)

        'Next

    End Sub

    Private Function GetFileTemp(ByVal p_Type As String) As String
        GetFileTemp = ""
        Select Case p_Type
            Case "HDGTGT"
                GetFileTemp = Application.StartupPath & "\GTGT_TEMP.xml"
            Case ""

        End Select
    End Function



    Private Sub CreateXMLHoaDonGTGT(ByVal p_DataSet As DataSet, ByVal p_FileTemp As String, ByRef p_StringXML As String)

        Dim m_xmld As XmlDocument

        Dim p_Count As Integer
        Dim p_Datatab0, p_Datatab1, p_Datatab2, p_Datatab3 As DataTable
        Dim p_SQL As String = ""
        Dim p_VerSion As String
        '   Dim p_StringAdd As String = "<![DATA["
        Dim p_Tmp As String
        m_xmld = New XmlDocument
        Dim p_RowId As Integer

        Dim p_PathFileTemp As String = Application.StartupPath & "\GTGT_TEMP.xml"
        Dim p_Ds As New DataSet
        Dim p_Row As DataRow
        Dim p_DsTmp As New DataSet
        ' p_Ds.ReadXml("C:\PLX\FPTRETAILS\FPTiRetail\bin\QuangVNtemp222222.xml")

        p_PathFileTemp = GetFileTemp("HDGTGT")
        If Dir(p_PathFileTemp) = "" Then
            ShowMessageBox("", "HDGTGT file temp không xác định")
            Exit Sub
        End If
        p_DsTmp.ReadXmlSchema(p_PathFileTemp)   ' p_Ds.Clone

        p_Tmp = ""
        p_Datatab0 = p_DataSet.Tables(0)
        p_Datatab1 = p_DataSet.Tables(1)
        p_Datatab2 = p_DataSet.Tables(2)
        p_VerSion = p_Datatab2.Rows(0).Item("VerXML").ToString.Trim
        p_Datatab3 = p_DataSet.Tables(3)
        '============================================================================================
        p_Row = p_DsTmp.Tables(0).NewRow
        p_Row.Item("Inv_Id") = 0
        p_Row.Item("Key") = p_Datatab0(0).Item("Key")
        p_DsTmp.Tables(0).Rows.Add(p_Row)

        p_Row = p_DsTmp.Tables(1).NewRow
        p_Row.Item("Inv_Id") = 0
        p_Row.Item("Invoice_Id") = 0
        For p_Count = 0 To p_Datatab1.Columns.Count - 1

            'If UCase(p_Datatab1.Columns(p_Count).ColumnName.Trim) = UCase("EInvoiceType") Then
            '    MsgBox("dsads")
            'End If
            If p_DsTmp.Tables(1).Columns.IndexOf(p_Datatab1.Columns(p_Count).ColumnName.Trim) >= 0 Then
                p_Row.Item(p_Datatab1.Columns(p_Count).ColumnName.Trim) = p_Datatab1.Rows(0).Item(p_Datatab1.Columns(p_Count).ColumnName.Trim).ToString.Trim
            End If
        Next
        p_DsTmp.Tables(1).Rows.Add(p_Row)

        p_Row = p_DsTmp.Tables(2).NewRow
        p_Row.Item("Invoice_Id") = 0
        p_Row.Item("Products_Id") = 0
        p_DsTmp.Tables(2).Rows.Add(p_Row)


        For p_RowId = 0 To p_Datatab3.Rows.Count - 1
            p_Row = p_DsTmp.Tables(3).NewRow
            p_Row.Item("Products_Id") = 0
            For p_Count = 0 To p_Datatab3.Columns.Count - 1
                If p_DsTmp.Tables(3).Columns.IndexOf(p_Datatab3.Columns(p_Count).ColumnName.Trim) >= 0 Then
                    If UCase(p_Datatab3.Columns(p_Count).ColumnName.Trim) = UCase("Remark") _
                            Or UCase(p_Datatab3.Columns(p_Count).ColumnName.Trim) = UCase("zzDesc") _
                            Or UCase(p_Datatab3.Columns(p_Count).ColumnName.Trim) = UCase("zzChietKhau") Then
                        p_Row.Item(p_Datatab3.Columns(p_Count).ColumnName.Trim) = ""
                        Continue For

                    End If
                    Try
                        p_Row.Item(p_Datatab3.Columns(p_Count).ColumnName.Trim) = p_Datatab3.Rows(p_RowId).Item(p_Datatab3.Columns(p_Count).ColumnName.Trim).ToString.Trim
                    Catch ex As Exception

                    End Try

                End If
            Next
            p_DsTmp.Tables(3).Rows.Add(p_Row)

            p_Row = p_DsTmp.Tables(3).NewRow
            p_Row.Item("Products_Id") = 0
            p_Row.Item("ProdName") = p_Datatab3.Rows(p_RowId).Item("Remark")
            p_Row.Item("Remark") = "1"
            For p_Count = 0 To p_Datatab3.Columns.Count - 1
                If p_DsTmp.Tables(3).Columns.IndexOf(p_Datatab3.Columns(p_Count).ColumnName.Trim) >= 0 Then
                    If UCase(p_Datatab3.Columns(p_Count).ColumnName.Trim) = UCase("Remark") _
                            Or UCase(p_Datatab3.Columns(p_Count).ColumnName.Trim) = UCase("ProdName") _
                            Or UCase(p_Datatab3.Columns(p_Count).ColumnName.Trim) = UCase("Products_Id") Then
                        Continue For

                    End If
                    Try
                        p_Row.Item(p_Datatab3.Columns(p_Count).ColumnName.Trim) = "" '' p_Datatab3.Rows(p_RowId).Item(p_Datatab3.Columns(p_Count).ColumnName.Trim).ToString.Trim
                    Catch ex As Exception

                    End Try

                End If
            Next

            p_DsTmp.Tables(3).Rows.Add(p_Row)

            If p_Datatab3.Rows(p_RowId).Item("zzChietKhau") <> 0 Then    ''Bo sung CHiet khau neu co

                p_Row = p_DsTmp.Tables(3).NewRow
                p_Row.Item("Products_Id") = 0
                p_Row.Item("ProdName") = p_Datatab3.Rows(p_RowId).Item("zzDesc")
                p_Row.Item("Amount") = p_Datatab3.Rows(p_RowId).Item("zzChietKhau")
                p_Row.Item("Remark") = "2"
                For p_Count = 0 To p_Datatab3.Columns.Count - 1
                    If p_DsTmp.Tables(3).Columns.IndexOf(p_Datatab3.Columns(p_Count).ColumnName.Trim) >= 0 Then
                        If UCase(p_Datatab3.Columns(p_Count).ColumnName.Trim) = UCase("Remark") _
                                Or UCase(p_Datatab3.Columns(p_Count).ColumnName.Trim) = UCase("ProdName") _
                                Or UCase(p_Datatab3.Columns(p_Count).ColumnName.Trim) = UCase("Products_Id") _
                                  Or UCase(p_Datatab3.Columns(p_Count).ColumnName.Trim) = UCase("Amount") Then
                            Continue For

                        End If
                        Try
                            p_Row.Item(p_Datatab3.Columns(p_Count).ColumnName.Trim) = "" '' p_Datatab3.Rows(p_RowId).Item(p_Datatab3.Columns(p_Count).ColumnName.Trim).ToString.Trim
                        Catch ex As Exception

                        End Try

                    End If
                Next

                p_DsTmp.Tables(3).Rows.Add(p_Row)
            End If
        Next
        p_DsTmp.AcceptChanges()
        p_StringXML = p_DsTmp.GetXml.ToString




    End Sub


    Private Sub CreateXMLHoaDonGTGT_20200131(ByVal p_DataSet As DataSet, ByVal p_FileTemp As String, ByRef p_StringXML As String)

        Dim m_xmld As XmlDocument
        Dim m_node As XmlNode
        Dim m_nodeInv As XmlNode
        Dim m_nodeKey As XmlNode
        Dim m_nodeInvoice As XmlNode
        Dim m_nodeInvoices As XmlNode
        Dim m_nodeProduct As XmlNode
        Dim m_nodeProducts As XmlNode
        Dim p_NodeName As String = ""
        Dim p_RowInd As Integer
        Dim p_Count As Integer
        Dim p_Datatab0, p_Datatab1, p_Datatab2, p_Datatab3 As DataTable
        Dim p_SQL As String = ""
        Dim p_VerSion As String
        Dim p_StringAdd As String = "<![DATA["
        Dim p_Tmp As String
        m_xmld = New XmlDocument
        Dim p_RowId As Integer

        Dim p_PathFileTemp As String = Application.StartupPath & "\GTGT_TEMP.xml"
        Dim p_Ds As New DataSet
        Dim p_Row As DataRow
        Dim p_DsTmp As New DataSet
        p_Ds.ReadXml("C:\PLX\FPTRETAILS\FPTiRetail\bin\QuangVNtemp222222.xml")
        p_DsTmp = p_Ds.Clone

        '  p_Ds.ReadXmlSchema(p_PathFileTemp)
        '  p_Ds.WriteXml("C:\PLX\FPTRETAILS\FPTiRetail\bin\QuangVNtemp222222.xml")
        'Exit Sub
        p_Tmp = ""
        p_Datatab0 = p_DataSet.Tables(0)
        p_Datatab1 = p_DataSet.Tables(1)
        p_Datatab2 = p_DataSet.Tables(2)
        p_VerSion = p_Datatab2.Rows(0).Item("VerXML").ToString.Trim
        p_Datatab3 = p_DataSet.Tables(3)
        '============================================================================================
        p_Row = p_DsTmp.Tables(0).NewRow
        p_Row.Item("Inv_Id") = 0
        p_Row.Item("Key") = p_Datatab0(0).Item("Key")
        p_DsTmp.Tables(0).Rows.Add(p_Row)

        p_Row = p_DsTmp.Tables(1).NewRow
        p_Row.Item("Inv_Id") = 0
        p_Row.Item("Invoice_Id") = 0
        For p_Count = 0 To p_Datatab1.Columns.Count - 1
            If p_DsTmp.Tables(1).Columns.IndexOf(p_Datatab1.Columns(p_Count).ColumnName.Trim) >= 0 Then
                p_Row.Item(p_Datatab1.Columns(p_Count).ColumnName.Trim) = p_Datatab1.Rows(0).Item(p_Datatab1.Columns(p_Count).ColumnName.Trim).ToString.Trim
            End If
        Next
        p_DsTmp.Tables(1).Rows.Add(p_Row)

        p_Row = p_DsTmp.Tables(2).NewRow
        p_Row.Item("Invoice_Id") = 0
        p_Row.Item("Products_Id") = 0
        p_DsTmp.Tables(2).Rows.Add(p_Row)


        For p_RowId = 0 To p_Datatab3.Rows.Count - 1
            p_Row = p_DsTmp.Tables(3).NewRow
            p_Row.Item("Products_Id") = 0
            For p_Count = 0 To p_Datatab3.Columns.Count - 1
                If p_DsTmp.Tables(3).Columns.IndexOf(p_Datatab3.Columns(p_Count).ColumnName.Trim) >= 0 Then
                    Try
                        p_Row.Item(p_Datatab3.Columns(p_Count).ColumnName.Trim) = p_Datatab3.Rows(p_RowId).Item(p_Datatab3.Columns(p_Count).ColumnName.Trim).ToString.Trim
                    Catch ex As Exception

                    End Try

                End If
            Next
            p_DsTmp.Tables(3).Rows.Add(p_Row)
        Next
        p_DsTmp.WriteXml("C:\PLX\FPTRETAILS\FPTiRetail\bin\QuangVNtemp333.xml")

        'Khoi tao XML
        m_node = m_xmld.CreateXmlDeclaration("1.0", "UTF-8", String.Empty)
        m_xmld.AppendChild(m_node)
        'Tao node Products
        m_nodeProducts = m_xmld.CreateNode(Xml.XmlNodeType.Element, "Products", "")
        For p_RowInd = 0 To p_Datatab3.Rows.Count - 1
            'Tao cac node Product
            m_nodeProduct = m_xmld.CreateNode(Xml.XmlNodeType.Element, "Product", "")
            For p_Count = 0 To p_Datatab3.Columns.Count - 1
                p_NodeName = p_Datatab3.Columns(p_Count).ColumnName.ToString.Trim

                m_node = m_xmld.CreateNode(Xml.XmlNodeType.Element, p_NodeName, "")
                'm_node = m_xmld.CreateNode(Xml.XmlNodeType.Element, p_NodeName, "")
                p_Tmp = p_Datatab3.Rows(p_RowInd).Item(p_NodeName).ToString.Trim
                If UCase(p_NodeName) = UCase("Remark") Then
                    p_Tmp = ""
                End If
                'm_node.InnerText = p_Tmp '
                m_node.AppendChild(m_xmld.CreateTextNode(p_Tmp))
                m_nodeProduct.AppendChild(m_node)
            Next
            m_nodeProducts.AppendChild(m_nodeProduct)
            'Chen dong 2
            m_nodeProduct = m_xmld.CreateNode(Xml.XmlNodeType.Element, "Product", "")
            For p_Count = 0 To p_Datatab3.Columns.Count - 1
                p_NodeName = p_Datatab3.Columns(p_Count).ColumnName.ToString.Trim
                m_node = m_xmld.CreateNode(Xml.XmlNodeType.Element, p_NodeName, "")
                p_Tmp = ""
                If UCase(p_NodeName) = UCase("Remark") Then
                    ' p_Tmp = p_Datatab3.Rows(p_RowInd).Item(p_NodeName).ToString.Trim
                    p_Tmp = "1"
                ElseIf UCase(p_NodeName) = UCase("ProdName") Then
                    p_Tmp = p_Datatab3.Rows(p_RowInd).Item("Remark").ToString.Trim
                Else

                End If


                '    m_node.InnerText = p_Tmp ' p_Datatab3.Rows(p_RowInd).Item(p_NodeName).ToString.Trim
                m_node.AppendChild(m_xmld.CreateTextNode(p_Tmp))
                m_nodeProduct.AppendChild(m_node)
            Next
            m_nodeProducts.AppendChild(m_nodeProduct)


        Next
        ' End If
        'Tao node Invocie
        m_nodeInvoice = m_xmld.CreateNode(Xml.XmlNodeType.Element, "Invocie", "")
        ' m_nodeInvoice.AppendChild(m_nodeProducts)
        For p_RowInd = 0 To p_Datatab1.Rows.Count - 1
            'Tao cac con cua Invoice

            For p_Count = 0 To p_Datatab1.Columns.Count - 1
                p_NodeName = p_Datatab1.Columns(p_Count).ColumnName.ToString.Trim
                m_node = m_xmld.CreateNode(Xml.XmlNodeType.Element, p_NodeName, "")

                p_Tmp = p_Datatab1.Rows(p_RowInd).Item(p_NodeName).ToString.Trim
                'If UCase(p_Datatab1.Columns(p_Count).DataType.Name.ToString.Trim) = "STRING" And p_Tmp <> "" Then
                '    p_Tmp = p_StringAdd & p_Tmp & "]]>"
                'End If

                ' m_node.InnerText = p_Tmp    ' p_Datatab1.Rows(p_RowInd).Item(p_NodeName).ToString.Trim
                m_node.AppendChild(m_xmld.CreateTextNode(p_Tmp))
                m_nodeInvoice.AppendChild(m_node)
                If UCase(p_NodeName) = UCase("CusBankNo") Then
                    m_nodeInvoice.AppendChild(m_nodeProducts)
                End If
            Next
        Next

        'Tao cac node Key
        m_nodeKey = m_xmld.CreateNode(Xml.XmlNodeType.Element, "Inv", "")
        For p_Count = 0 To p_Datatab0.Columns.Count - 1
            p_NodeName = p_Datatab0.Columns(p_Count).ColumnName.ToString.Trim
            m_node = m_xmld.CreateNode(Xml.XmlNodeType.Element, p_NodeName, "")
            '  m_node.InnerText = p_Datatab0.Rows(0).Item(p_NodeName).ToString.Trim
            m_node.AppendChild(m_xmld.CreateTextNode(p_Datatab0.Rows(0).Item(p_NodeName).ToString.Trim))
            m_nodeKey.AppendChild(m_node)
        Next
        m_nodeKey.AppendChild(m_nodeInvoice)
        'Tao Node Invocies
        m_nodeInvoices = m_xmld.CreateNode(Xml.XmlNodeType.Element, "Invoices", "")
        m_nodeInvoices.AppendChild(m_nodeKey)
        ' m_nodeInvoices.AppendChild(m_nodeInvoice)

        m_xmld.AppendChild(m_nodeInvoices)
        'm_nodeInvoices.
        '  m_xmld.Save(p_FileTemp)
        '   p_StringXML = "<![CDATA[" & m_xmld.InnerXml.ToString & "]]>"


        p_StringXML = m_xmld.OuterXml
        ' m_xmld.DocumentType.
        ' Exit Sub
        'Dim abc As New XmlDocument
        'abc.LoadXml(p_StringXML)
        'abc.Save(p_FileTemp)
        '   abc.
        Dim abc1 As New XmlDocument
        abc1.Load("C:\PLX\FPTRETAILS\FPTiRetail\bin\QuangVNtemp333.xml")
        p_StringXML = abc1.InnerXml.ToString


        'Dim abc2 As New XmlDocument
        'abc2.LoadXml(p_StringXML)
        'abc2.Save(p_FileTemp)

    End Sub

End Module
