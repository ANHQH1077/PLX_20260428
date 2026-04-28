Module Module2

    'Sys_Execute
    Public g_PathXML As String = ""
    Public g_SySConfig As DataTable

    Public g_HamGetMaLenh As String = ""
    Public g_LoaiPhieu As String = "V144"

    '  Public g_Config_XMLDatatable As New System.Data.DataTable

    Public g_DefaultPrint As String
    Public g_DefaultPrintVAT As String
    '  Public g_Terminal As String = ""
    Public g_tblVCF As DataTable

    Public g_dt_para As DataTable

    Public Function SQL_Execute(ByVal p_SQL As String, ByRef p_Error As String) As Boolean
        Dim pStatus As Boolean
        Try
            pStatus = False
            pStatus = g_Services.Sys_Execute(p_SQL, p_Error)
        Catch ex As Exception
            pStatus = True
        End Try
        Return pStatus

    End Function


    'Public Sub p_GetDateTime(ByRef p_Date As Date, ByRef p_Time As Integer)
    '    Dim p_SQL As String
    '    Dim p_Datatable As New DataTable
    '    p_SQL = "select  convert(date, getdate()) as SysDate, replace(CONVERT(VARCHAR(5),DATEADD(MINUTE,0 ,GETDATE()),108),':','') as SysTime"
    '    p_Datatable = g_Services.mod_SYS_GET_DATATABLE(p_SQL)
    '    If Not p_Datatable Is Nothing Then
    '        If p_Datatable.Rows.Count > 0 Then
    '            p_Date = p_Datatable.Rows(0).Item("SysDate")
    '            p_Time = p_Datatable.Rows(0).Item("SysTime")
    '        End If
    '    End If
    '    p_Datatable = Nothing
    'End Sub


    Public Function Get_HoaDon_ChiTietNew(ByVal i_SoLenh As String) As DataTable
        Dim err As String = String.Empty
        Dim DtTable As DataTable
        Dim p_SQL As String
        

        Try
            p_SQL = "exec FPT_HoaDon_ChiTietE5 '" & i_SoLenh & "'"
            DtTable = GetDataTable(p_SQL, p_SQL)

            CauHinhThucXuat(DtTable, i_SoLenh)

            DtTable = Alter_table_HoaDon(DtTable)
            Return DtTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    'anhqh
    '20170925
    'ham thuc hien tinh chuyen thuc xuat theo cau hinh du xuat hoac thuc xuaat
    Private Sub CauHinhThucXuat(ByRef DtTable As DataTable, p_SoLenh As String)
        Dim p_Count As Integer
        Dim p_Row() As DataRow
        Dim p_ThucXuat As String = "0"
        Dim ThucXuatThuy As String = "0"

        Dim p_DataTable As DataTable
        Dim p_SQL As String
        ' Dim p_XITEC_OPTION As Boolean
        Dim p_XITEC_Check As String = ""
        Dim p_LVC As String = ""
        Try



            ' Return


            If DtTable Is Nothing Then
                Exit Sub
            End If
            If DtTable.Rows.Count <= 0 Then
                Exit Sub
            End If
            
            If Not g_SySConfig Is Nothing Then

                p_XITEC_Check = "N"
                p_Row = g_SySConfig.Select("KEYCODE='XITEC_OPTION'")
                If p_Row.Length > 0 Then
                    If p_Row(0).Item("KeyValue").ToString.Trim = "Y" Then
                        p_XITEC_Check = p_Row(0).Item("KeyValue").ToString.Trim
                    End If
                    'p_ThucXuat = p_Row(0).Item("KeyValue").ToString.Trim
                End If

                p_Row = g_SySConfig.Select("KEYCODE='TONGDUXUAT'")
                If p_Row.Length > 0 Then
                    p_ThucXuat = p_Row(0).Item("KeyValue").ToString.Trim
                End If

                p_Row = g_SySConfig.Select("KEYCODE='TONGDUXUATTHUY'")
                If p_Row.Length > 0 Then
                    ThucXuatThuy = p_Row(0).Item("KeyValue").ToString.Trim
                End If


                'p_XITEC_OPTION = False
                'p_Row = g_SySConfig.Select("KEYCODE='XITEC_OPTION '")
                'If p_Row.Length > 0 Then

                '    If p_Row(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                '        p_XITEC_OPTION = True
                '    End If
                'End If

            End If

            If p_XITEC_Check = "N" Then
                Return
            End If

            p_XITEC_Check = ""

            '  If p_XITEC_OPTION = True Then
            p_SQL = "select XITEC_OPTION, dbo.FPT_GetLoadingSite(MaVanChuyen) as LVC  from tbllenhxuate5  with (nolock) where solenh='" & p_SoLenh & "'"
            p_DataTable = GetDataTable(p_SQL, p_SQL)

            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_XITEC_Check = p_DataTable.Rows(0).Item("XITEC_OPTION").ToString.Trim
                    p_LVC = p_DataTable.Rows(0).Item("LVC").ToString.Trim
                End If
            End If
            '   End If

            For p_Count = 0 To DtTable.Rows.Count - 1
                If UCase(p_LVC) = "THUY" Then
                    If ThucXuatThuy = "1" Then    'Theo du xuat
                        If p_XITEC_Check = "Y" Then   'Theo thuc xuat theo so lenh

                        Else
                            DtTable.Rows(p_Count).Item(7) = DtTable.Rows(p_Count).Item(6)
                        End If
                    Else    'Thuc xuat
                        If p_XITEC_Check = "Y" Then  ''Theo du xuat theo so lenh
                            DtTable.Rows(p_Count).Item(7) = DtTable.Rows(p_Count).Item(6)
                        End If
                    End If
                Else
                    If p_ThucXuat = "1" Then    'Theo du xuat
                        If p_XITEC_Check = "Y" Then   'Theo thuc xuat theo so lenh

                        Else
                            DtTable.Rows(p_Count).Item(7) = DtTable.Rows(p_Count).Item(6)
                        End If
                    Else    'Thuc xuat
                        If p_XITEC_Check = "Y" Then  ''Theo du xuat theo so lenh
                            DtTable.Rows(p_Count).Item(7) = DtTable.Rows(p_Count).Item(6)
                        End If
                    End If

                End If
            Next

        Catch ex As Exception

        End Try

    End Sub

    Public Function Alter_table_HoaDon(ByVal i_dtTable As DataTable) As DataTable

        '01/02/2013 QUEHV - Them moi column WCF,L15,KG
        Dim dtHoaDon As DataTable = i_dtTable
        Dim col As DataColumn
        Dim vcf As String = String.Empty
        Dim wcf As String = String.Empty
        Dim l15 As String = String.Empty
        Dim kg As String = String.Empty

        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_L15 As Decimal

        Dim p_Vcf As Decimal

        Dim p_TongXuat As Decimal



        For Each r As DataRow In dtHoaDon.Rows
            vcf = String.Empty
            wcf = String.Empty
            vcf = mdlQCI_GetVCF_NS(IIf(IsDBNull(r.Item("NhiệtĐộ")), 0, r.Item("NhiệtĐộ")), IIf(IsDBNull(r.Item("TỷTrọng")), 0, r.Item("TỷTrọng")))

            Decimal.TryParse(r.Item("L15").ToString.Trim, p_L15)
            Decimal.TryParse(r.Item("TổngXuất").ToString.Trim, p_TongXuat)
            ' p_TongXuat = Convert.ToDecimal(r.Item("TổngXuất").ToString())
            If CheckItemToScada2(r.Item("MãHàngHóa")) = "Y" And p_L15 > 0 Then

                If p_TongXuat > 0 Then
                    p_SQL = "select  dbo.FPT_ROUNDNUMBER( dbo.FPT_ROUNDNUMBER (" & p_L15 & ",0) /  dbo.FPT_ROUNDNUMBER(" & p_TongXuat & ",0) ,4)  as VCF  "

                    p_DataTable = GetDataTable(p_SQL, p_SQL)
                    If Not p_DataTable Is Nothing Then
                        If p_DataTable.Rows.Count > 0 Then
                            If p_DataTable.Rows(0).Item("VCF").ToString.Trim <> "" Then
                                vcf = Left(p_DataTable.Rows(0).Item("VCF").ToString.Trim, 6)
                            End If
                        End If
                    End If
                End If

                'r.Item("L15") = l15
            End If



            wcf = mdlQCI_GetWCF(IIf(IsDBNull(r.Item("TỷTrọng")), 0, r.Item("TỷTrọng")))

            'If _dtPara.Rows(16).Item("Value_nd").ToString().Trim() = "1" Then
            Dim _L15 As Decimal() = mdlQCI_CalculateQCI_NS(Decimal.Parse(IIf(IsDBNull(r.Item("TổngXuất")), 0, r.Item("TổngXuất").ToString)), "L", Decimal.Parse(IIf(IsDBNull(r.Item("NhiệtĐộ")), 0, r.Item("NhiệtĐộ").ToString)), r.Item("TỷTrọng").ToString)
            l15 = _L15(1).ToString
            kg = _L15(3).ToString
            'Else
            '    Dim _L15 As Decimal() = mdlQCI_CalculateQCI(_SQLConnectionString, Decimal.Parse(IIf(IsDBNull(r.Item("TổngDựXuất")), 0, r.Item("TổngDựXuất").ToString)), r.Item("ĐơnVịTính").ToString, Decimal.Parse(IIf(IsDBNull(r.Item("NhiệtĐộ")), 0, r.Item("NhiệtĐộ").ToString)), r.Item("TỷTrọng").ToString)
            '    l15 = _L15(1).ToString
            '    kg = _L15(3).ToString
            'End If
            r.Item("VCF") = vcf
            r.Item("WCF") = wcf
            ' r.Item("L15") = l15
            'FES
            '20141027
            If CheckItemToScada2(r.Item("MãHàngHóa")) <> "Y" Then
                r.Item("L15") = l15
            End If
            r.Item("KG") = kg
        Next
        Return dtHoaDon
    End Function





    'Public Sub p_GetDateTime(ByRef p_Date As Date, ByRef p_Time As Integer)
    '    Dim p_SQL As String
    '    Dim p_Datatable As New DataTable
    '    p_SQL = "select  convert(date, getdate()) as SysDate, replace(CONVERT(VARCHAR(5),DATEADD(MINUTE,0 ,GETDATE()),108),':','') as SysTime"
    '    p_Datatable = g_Services.mod_SYS_GET_DATATABLE(p_SQL)
    '    If Not p_Datatable Is Nothing Then
    '        If p_Datatable.Rows.Count > 0 Then
    '            p_Date = p_Datatable.Rows(0).Item("SysDate")
    '            p_Time = p_Datatable.Rows(0).Item("SysTime")
    '        End If
    '    End If
    '    p_Datatable = Nothing
    'End Sub



    Public Function mdlDelivery_CheckTransmot(ByVal i_mavanchuyen As String, ByVal i_dt_para As DataTable) As String
        Dim l_bo, _
            l_thuy, _
            l_sat As String()
        Dim p_ArrRow() As DataRow
        Try
            '----------------------------------------------------------------
            '   Para:
            '       Index 0: Bo
            '       Index 1: Thuy
            '----------------------------------------------------------------
            p_ArrRow = i_dt_para.Select("Para='Bo' or Para='BO'")
            If p_ArrRow.Length > 0 Then
                l_bo = p_ArrRow(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            End If
            p_ArrRow = i_dt_para.Select("Para='Thuy' or Para='THUY'")
            If p_ArrRow.Length > 0 Then
                l_thuy = p_ArrRow(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            End If

            'l_bo = i_dt_para.Rows(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            'l_thuy = i_dt_para.Rows(1).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)

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

    Public Function mdlQCI_GetVCF_NS(ByVal i_temp As String, _
                                      ByVal i_dens As String) As String
        Dim l_vcf_1 As String


        Dim l_dens As String
        Dim l_dens_1 As String
        Dim l_dens_2 As String
        Dim l_temp As String
        Dim l_dt As DataTable
        Dim l_vcf As String

        Dim p_ArrRow() As DataRow


        If i_dens.Length > 6 Then
            l_dens = i_dens.Substring(0, 6)
        Else
            l_dens = i_dens
        End If

        l_dens_1 = mdlQCI_ConvertDens_1(l_dens)
        l_dens_2 = mdlQCI_ConvertDens_2(l_dens)

        If i_temp.Length > 5 Then
            l_temp = i_temp.Substring(0, 5)
        Else
            l_temp = i_temp
            If l_temp.Length = 2 Then
                l_temp = l_temp & ".00"
            Else

                If i_temp.Length < 5 Then
                    For i As Integer = 1 To 5 - i_temp.Length
                        l_temp = l_temp & "0"
                    Next
                End If
            End If
        End If

        l_temp = mdlQCI_ConvertTemp(l_temp)

        Try
            ' l_c2sql = New Connect2SQL.Connect2SQL(i_connectionstring)

            If l_dens_1 = l_dens_2 Then
                'l_vcf_1 = l_c2sql.getDataValue("select VCF from tblVCF where [Dens] = '" & l_dens_1 & "' and [Temp] = '" & l_temp & "'")
                l_vcf_1 = "1"
                p_ArrRow = g_tblVCF.Select("[Dens] = '" & l_dens_1 & "' and [Temp] = '" & l_temp & "'")
                If p_ArrRow.Length > 0 Then
                    l_vcf_1 = p_ArrRow(0).Item("VCF").ToString.Trim

                End If

                'l_dt = GetDataTable("select VCF from tblVCF where [Dens] = '" & l_dens_1 & "' and [Temp] = '" & l_temp & "'", l_vcf)
                'If Not l_dt Is Nothing Then
                '    If l_dt.Rows.Count > 0 Then
                '        l_vcf_1 = l_dt.Rows(0).Item("VCF").ToString.Trim
                '    End If
                'End If
            Else
                l_vcf_1 = mdlQCI_GetVCFSub_NS(l_temp, i_dens, l_dens_1, l_dens_2)
            End If
            'FES
            '20141028
            If l_vcf_1 = "" Then l_vcf_1 = "1"
        Catch ex As Exception
            l_vcf_1 = "1"
        End Try

        Return l_vcf_1
    End Function


    Public Function mdlQCI_GetVCFSub_NS(ByVal i_temp As String, _
                                    ByVal i_dens As String, _
                                    ByVal i_dens_1 As String, _
                                    ByVal i_dens_2 As String) As String
        Dim l_dens_in, _
            l_dens_1_dec, _
            l_dens_2_dec As Decimal


        Dim l_dt As DataTable = New DataTable
        Dim l_sql As String
        Dim p_ArrRow() As DataRow
        Dim p_SQL As String
        Try

            l_dens_in = Convert.ToDecimal(i_dens)
            l_dens_1_dec = Convert.ToDecimal(i_dens_1)
            l_dens_2_dec = Convert.ToDecimal(i_dens_2)


            p_ArrRow = g_tblVCF.Select("[Temp] = '" & i_temp & _
                    "' and [Dens] in ('" & l_dens_1_dec.ToString() & "' , '" & l_dens_2_dec.ToString() & "')", "vcf")

            If p_ArrRow.Length <> 2 Then
                Return "0"
            End If
            'l_sql = "select * from tblVCF where [Temp] = '" & i_temp & _
            '        "' and [Dens] in ('" & l_dens_1_dec.ToString() & "' , '" & l_dens_2_dec.ToString() & "') order by vcf"


            'l_dt = GetDataTable(l_sql, l_sql)

            'If l_dt.Rows.Count <> 2 Then
            '    Return "0"
            'End If

            Dim l_vcf_1, _
                l_vcf_2, _
                l_vcf _
                As Decimal

            l_vcf_1 = Convert.ToDecimal(p_ArrRow(0).Item("VCF").ToString()) '   Convert.ToDecimal(l_dt.Rows(0).Item("VCF").ToString())
            l_vcf_2 = Convert.ToDecimal(p_ArrRow(1).Item("VCF").ToString())   'Convert.ToDecimal(l_dt.Rows(1).Item("VCF").ToString())

            l_vcf = Math.Abs(l_vcf_2 - l_vcf_1) / Math.Abs(l_dens_2_dec - l_dens_1_dec)
            l_vcf = l_vcf_1 + l_vcf * (l_dens_in - l_dens_1_dec)

            p_SQL = "select  dbo.FPT_ROUNDNUMBER (" & l_vcf & ",4)  as VCF  "

            l_dt = GetDataTable(p_SQL, p_SQL)
            If Not l_dt Is Nothing Then
                If l_dt.Rows.Count > 0 Then
                    If l_dt.Rows(0).Item("VCF").ToString.Trim <> "" Then
                        l_vcf = Left(l_dt.Rows(0).Item("VCF").ToString.Trim, 6)
                    End If
                End If
            End If


            'Return Math.Round(l_vcf, 4)
            Return Math.Round(l_vcf, 4, MidpointRounding.AwayFromZero)
        Catch ex As Exception
            Return "0"
        End Try

    End Function

    Public Function mdlQCI_GetVCF(ByVal i_temp As String, ByVal i_dens As String) As String
        Dim l_vcf As String
        Dim l_dt As DataTable = New DataTable

        Try
            l_vcf = "1"
            l_dt = GetDataTable("select VCF from tblVCF where [Dens] = '" & i_dens & "' and [Temp] = '" & i_temp & "'", l_vcf)
            If Not l_dt Is Nothing Then
                If l_dt.Rows.Count > 0 Then
                    l_vcf = l_dt.Rows(0).Item("VCF").ToString.Trim
                End If
            End If
            If l_vcf = String.Empty Then
                l_vcf = "1"
            End If
        Catch ex As Exception
            l_vcf = "1"
        End Try

        Return l_vcf
    End Function

    Public Function mdlQCI_GetVCF_cp(ByVal i_connectionstring As String, _
                                     ByVal i_temp As String, _
                                     ByVal i_dens As String) As String
        Dim l_vcf As String

        Dim l_dens As String
        Dim l_temp As String
        Dim l_dt As DataTable

        If i_dens.Length > 6 Then
            l_dens = i_dens.Substring(0, 6)
        Else
            l_dens = i_dens
            If i_dens.Length < 6 Then
                For i As Integer = 1 To 6 - i_dens.Length
                    l_dens = l_dens & "0"
                Next
            End If
        End If

        l_dens = mdlQCI_ConvertDens(l_dens)

        If i_temp.Length > 5 Then
            l_temp = i_temp.Substring(0, 5)
        Else
            l_temp = i_temp
            If l_temp.Length = 2 Then
                l_temp = l_temp & ".00"
            Else

                If i_temp.Length < 5 Then
                    For i As Integer = 1 To 5 - i_temp.Length
                        l_temp = l_temp & "0"
                    Next
                End If
            End If
        End If

        l_temp = mdlQCI_ConvertTemp(l_temp)

        Try


            l_vcf = "1"
            l_dt = GetDataTable("select VCF from tblVCF where [Dens] = '" & l_dens & "' and [Temp] = '" & l_temp & "'", l_vcf)
            If Not l_dt Is Nothing Then
                If l_dt.Rows.Count > 0 Then
                    l_vcf = l_dt.Rows(0).Item("VCF").ToString.Trim
                End If
            End If

            If l_vcf = String.Empty Then
                l_vcf = mdlQCI_GetVCFSub(i_connectionstring, l_temp, l_dens)
            End If
        Catch ex As Exception
            l_vcf = "1"
        End Try

        Return l_vcf
    End Function


    Public Function mdlQCI_GetWCF(ByVal i_dens15 As String) As String
        Dim l_wcf As Decimal
        Dim l_dens As Decimal = 0.0011

        l_wcf = Convert.ToDecimal(i_dens15)
        l_wcf = l_wcf - l_dens

        Return l_wcf.ToString()
    End Function


    Public Function mdlQCI_CalculateQCI(ByVal i_quantity As Decimal, ByVal i_donvitinh As String, ByVal i_temp As Decimal, ByVal i_dens As Decimal) As Decimal()
        Dim l_result As Decimal() = New Decimal() {0, 0, 0, 0}
        Dim l_temp, l_dens, l_vcf, l_wcf As String
        l_temp = i_temp.ToString()
        l_dens = i_dens.ToString()
        l_vcf = mdlQCI_GetVCF(i_temp, i_dens)
        l_wcf = mdlQCI_GetWCF(l_dens)

        Select Case i_donvitinh
            Case "L"
                l_result(0) = i_quantity
                l_result(1) = l_result(0) * Convert.ToDecimal(l_vcf)
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "L15"
                l_result(0) = i_quantity / Convert.ToDecimal(l_vcf)
                l_result(1) = i_quantity
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "M15"
                l_result(1) = i_quantity * 1000
                l_result(2) = i_quantity
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "KG"
                l_result(3) = i_quantity
                l_result(1) = l_result(3) / Convert.ToDecimal(l_wcf)
                l_result(2) = l_result(1) / 1000
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)

        End Select

        For i As Integer = 0 To l_result.Length - 1
            l_result(i) = Math.Round(l_result(i), 0)
        Next

        Return l_result
    End Function

    Public Function mdlQCI_CalculateQCI(ByVal i_quantity As Decimal, ByVal i_donvitinh As String, ByVal i_vcf As Decimal) As Decimal()
        Dim l_result As Decimal() = New Decimal() {0, 0, 0, 0}
        Dim l_vcf, l_wcf As String
        l_vcf = i_vcf
        l_wcf = mdlQCI_GetWCF(l_vcf)

        Select Case i_donvitinh
            Case "L"
                l_result(0) = i_quantity
                l_result(1) = l_result(0) * Convert.ToDecimal(l_vcf)
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "L15"
                l_result(0) = i_quantity / Convert.ToDecimal(l_vcf)
                l_result(1) = i_quantity
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "M15"
                l_result(1) = i_quantity * 1000
                l_result(2) = i_quantity
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "KG"
                l_result(3) = i_quantity
                l_result(1) = l_result(3) / Convert.ToDecimal(l_wcf)
                l_result(2) = l_result(1) / 1000
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)

        End Select
        For i As Integer = 0 To l_result.Length - 1
            l_result(i) = Math.Round(l_result(i), 0)
        Next
        Return l_result
    End Function


    Public Function mdlQCI_CalculateQCI(ByVal i_connectionstring As String, ByVal i_quantity As Decimal, ByVal i_donvitinh As String, ByVal i_temp As Decimal, ByVal i_dens As Decimal) As Decimal()
        Dim l_result As Decimal() = New Decimal() {0, 0, 0, 0}
        Dim l_temp, l_dens, l_vcf, l_wcf As String
        Dim l_temp_str As String()

        l_temp = i_temp.ToString()
        l_dens = i_dens.ToString()

        l_temp_str = l_temp.ToString().Split(".")

        If l_temp_str.Length = 1 Then
            l_temp = l_temp_str(0) & ".00"
        End If

        l_vcf = mdlQCI_GetVCF_cp(i_connectionstring, l_temp, l_dens)
        l_wcf = mdlQCI_GetWCF(l_dens)

        Select Case i_donvitinh
            Case "L"
                l_result(0) = i_quantity
                l_result(1) = l_result(0) * Convert.ToDecimal(l_vcf)
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "L15"
                l_result(0) = i_quantity / Convert.ToDecimal(l_vcf)
                l_result(1) = i_quantity
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "M15"
                l_result(1) = i_quantity * 1000
                l_result(2) = i_quantity
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "KG"
                l_result(3) = i_quantity
                l_result(1) = l_result(3) / Convert.ToDecimal(l_wcf)
                l_result(2) = l_result(1) / 1000
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)

        End Select

        For i As Integer = 0 To l_result.Length - 1
            l_result(i) = Math.Round(l_result(i), 0)
        Next

        Return l_result
    End Function


    Public Function mdlQCI_CalculateQCI_NS(ByVal i_quantity As Decimal, ByVal i_donvitinh As String, ByVal i_temp As Decimal, ByVal i_dens As Decimal, _
                                            Optional ByVal p_Vcf_In As String = "") As Decimal()
        Dim l_result As Decimal() = New Decimal() {0, 0, 0, 0}
        Dim l_temp, l_dens, l_vcf, l_wcf As String
        Dim l_temp_str As String()



        l_temp = i_temp.ToString()
        l_dens = i_dens.ToString()

        l_temp_str = l_temp.ToString().Split(".")

        If l_temp_str.Length = 1 Then
            l_temp = l_temp_str(0) & ".00"
        End If
        If p_Vcf_In = "" Then
            l_vcf = mdlQCI_GetVCF_NS(l_temp, l_dens)
        Else
            l_vcf = p_Vcf_In
        End If

        l_wcf = mdlQCI_GetWCF(l_dens)

        Select Case i_donvitinh
            Case "L"
                l_result(0) = i_quantity
                l_result(1) = l_result(0) * Convert.ToDecimal(l_vcf)
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "L15"
                l_result(0) = i_quantity / Convert.ToDecimal(l_vcf)
                l_result(1) = i_quantity
                l_result(2) = l_result(1) / 1000
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "M15"
                l_result(1) = i_quantity * 1000
                l_result(2) = i_quantity
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)
                l_result(3) = l_result(1) * Convert.ToDecimal(l_wcf)

            Case "KG"
                l_result(3) = i_quantity
                l_result(1) = l_result(3) / Convert.ToDecimal(l_wcf)
                l_result(2) = l_result(1) / 1000
                l_result(0) = l_result(1) / Convert.ToDecimal(l_vcf)

        End Select

        For i As Integer = 0 To l_result.Length - 1
            l_result(i) = Math.Round(l_result(i), 0, MidpointRounding.AwayFromZero)
        Next

        Return l_result
    End Function


    Public Function mdlQCI_ConvertDens_1(ByVal i_dens As String) As String
        Try
            Dim l_dens_0 As String
            Dim l_dens_1 As String
            Dim l_dens_2 As String
            Dim l_dens_3 As String

            Dim l_dens_1_int As Decimal
            Dim l_step_1 As Decimal = 0.001

            l_dens_0 = i_dens

            If l_dens_0.Length < 6 Then
                For i As Integer = 1 To 6 - i_dens.Length
                    l_dens_0 = l_dens_0 & "0"
                Next
            End If

            '------------------------
            '   5 ký tự đầu
            '------------------------
            l_dens_1 = l_dens_0.Substring(0, 5)
            l_dens_1_int = l_dens_1
            '------------------------
            '   1 ký tự cuối
            '------------------------
            l_dens_2 = l_dens_0.Substring(5, 1)

            '------------------------
            '   1 ký tự áp chót
            '------------------------
            l_dens_3 = l_dens_0.Substring(4, 1)

            '----------------------------------------------------
            '   Nếu vị trí cuối = 0 và áp chót chẵn : 1.2340
            '   Đầu ra là                           : 1.234
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 = "0" Then
                Return l_dens_1
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối = 0 và áp chót lẻ   : 1.2350 
            '   Đầu ra là                           : 1.235 - 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 = "0" Then
                l_dens_1_int = l_dens_1_int - l_step_1
                Return l_dens_1_int.ToString()
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót chẵn: 1.2346
            '   Đầu ra là                           : 1.234
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 <> "0" Then
                Return l_dens_1
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót lẻ  : 1.2351
            '   Đầu ra là                           : 1.235 - 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 <> "0" Then
                l_dens_1_int = l_dens_1_int - l_step_1
                Return l_dens_1_int.ToString()
            End If

            Return i_dens
        Catch ex As Exception
            Return i_dens
        End Try
    End Function

    Public Function mdlQCI_ConvertDens_2(ByVal i_dens As String) As String
        Try
            Dim l_dens_0 As String
            Dim l_dens_1 As String
            Dim l_dens_2 As String
            Dim l_dens_3 As String

            Dim l_dens_1_int As Decimal
            Dim l_step_1 As Decimal = 0.001
            Dim l_step_2 As Decimal = 0.002

            l_dens_0 = i_dens

            If l_dens_0.Length < 6 Then
                For i As Integer = 1 To 6 - i_dens.Length
                    l_dens_0 = l_dens_0 & "0"
                Next
            End If

            '------------------------
            '   5 ký tự đầu
            '------------------------
            l_dens_1 = l_dens_0.Substring(0, 5)
            l_dens_1_int = l_dens_1
            '------------------------
            '   1 ký tự cuối
            '------------------------
            l_dens_2 = l_dens_0.Substring(5, 1)

            '------------------------
            '   1 ký tự áp chót
            '------------------------
            l_dens_3 = l_dens_0.Substring(4, 1)

            '----------------------------------------------------
            '   Nếu vị trí cuối = 0 và áp chót chẵn : 1.2340
            '   Đầu ra là                           : 1.234
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 = "0" Then
                Return l_dens_1
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối = 0 và áp chót lẻ   : 1.2350 
            '   Đầu ra là                           : 1.235 + 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 = "0" Then
                l_dens_1_int = l_dens_1_int + l_step_1
                Return l_dens_1_int.ToString()
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót chẵn: 1.2346
            '   Đầu ra là                           : 1.234 + 0.002
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 <> "0" Then
                l_dens_1_int = l_dens_1_int + l_step_2
                Return l_dens_1_int.ToString()
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót lẻ  : 1.2351
            '   Đầu ra là                           : 1.235 + 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 <> "0" Then
                l_dens_1_int = l_dens_1_int + l_step_1
                Return l_dens_1_int.ToString()
            End If

            Return i_dens
        Catch ex As Exception
            Return i_dens
        End Try
    End Function


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


    '----------------------------------
    '   Đầu vào luôn là 6 ký tự: 1.3456
    '   Đầu ra  luôn là 5 ký tự: 1.345
    '----------------------------------
    Public Function mdlQCI_ConvertDens(ByVal i_dens As String) As String
        Try
            Dim l_dens_0 As String
            Dim l_dens_11 As String
            Dim l_dens_12 As String
            Dim l_dens_1 As String
            Dim l_dens_2 As String
            Dim l_dens_3 As String

            l_dens_0 = i_dens

            If l_dens_0.Length < 6 Then
                For i As Integer = 1 To 6 - i_dens.Length
                    l_dens_0 = l_dens_0 & "0"
                Next
            End If

            '------------------------
            '   3 ký tự đầu
            '------------------------
            l_dens_11 = l_dens_0.Substring(0, 3)

            '------------------------
            '   Ký tự thứ 4
            '------------------------
            l_dens_12 = l_dens_0.Substring(3, 1)

            '------------------------
            '   4 ký tự đầu
            '------------------------
            l_dens_1 = l_dens_0.Substring(0, 4)

            '------------------------
            '   1 ký tự cuối
            '------------------------
            l_dens_2 = l_dens_0.Substring(5, 1)

            '------------------------
            '   1 ký tự áp chót
            '------------------------
            l_dens_3 = l_dens_0.Substring(4, 1)

            '----------------------------------------------------
            '   Nếu vị trí áp chót chẵn
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 Then
                Return l_dens_1 & l_dens_3
            End If

            '----------------------------------------------------
            '   Ngược lại: Nếu vị trí cuối >= 0
            '----------------------------------------------------
            If Convert.ToInt32(l_dens_2) >= 0 Then
                l_dens_3 = (Convert.ToInt32(l_dens_3) + 1).ToString()

                If Convert.ToInt32(l_dens_3) >= 10 Then
                    l_dens_3 = "0"
                    l_dens_12 = (Convert.ToInt32(l_dens_12) + 1).ToString()

                    If Convert.ToInt32(l_dens_12) >= 10 Then
                        l_dens_12 = "0"
                        l_dens_11 = Math.Round((Convert.ToDecimal(l_dens_11) + 0.1), 2).ToString()
                        Return l_dens_11 & l_dens_12 & l_dens_3
                    Else
                        Return l_dens_11 & l_dens_12 & l_dens_3
                    End If

                    Return l_dens_11 & l_dens_3
                End If

                Return l_dens_1 & l_dens_3
            End If

            Return i_dens

        Catch ex As Exception
            Return i_dens
        End Try
    End Function


    Public Function mdlQCI_GetVCFSub(ByVal i_connectionstring As String, _
                                     ByVal i_temp As String, _
                                     ByVal i_dens As String) As String
        Dim l_dens As Decimal
        Dim l_dens_in As Decimal

        Dim l_dens_arr As String()
        Dim l_dens_1, _
            l_dens_2 As Integer
        Dim l_dens_1_dec, _
            l_dens_2_dec As Decimal


        Dim l_dt As DataTable = New DataTable
        Dim l_sql As String
        Try

            l_dens_in = Convert.ToDecimal(i_dens)
            l_dens = Math.Round(l_dens_in, 3)
            l_dens_arr = l_dens.ToString().Split(".")
            l_dens_1 = Convert.ToInt32(l_dens_arr(1))

            l_dens_1 = l_dens_1 - 1
            l_dens_2 = l_dens_1 + 2

            l_dens_1_dec = Convert.ToDecimal(l_dens_arr(0) & "." & l_dens_1.ToString())
            If l_dens_2.ToString().Length > l_dens_1.ToString().Length Then
                l_dens_2 = Convert.ToInt32(l_dens_arr(0)) + 1
                l_dens_2_dec = Convert.ToDecimal(l_dens_2)
            Else
                l_dens_2_dec = Convert.ToDecimal(l_dens_arr(0) & "." & l_dens_2.ToString())
            End If

            l_sql = "select * from tblVCF where [Temp] = '" & i_temp & _
                    "' and [Dens] in ('" & l_dens_1_dec.ToString() & "' , '" & l_dens_2_dec.ToString() & "') order by vcf"


            l_dt = GetDataTable(l_sql, l_sql)

            If l_dt.Rows.Count <> 2 Then
                Return "0"
            End If

            Dim l_vcf_1, _
                l_vcf_2, _
                l_vcf _
                As Decimal

            l_vcf_1 = Convert.ToDecimal(l_dt.Rows(0).Item("VCF").ToString())
            l_vcf_2 = Convert.ToDecimal(l_dt.Rows(1).Item("VCF").ToString())

            l_vcf = Math.Abs(l_vcf_2 - l_vcf_1) / Math.Abs(l_dens_2_dec - l_dens_1_dec)
            l_vcf = l_vcf_1 + l_vcf * (l_dens_in - l_dens_1_dec)

            Return Math.Round(l_vcf, 4)
        Catch ex As Exception
            Return "0"
        End Try


    End Function

End Module
