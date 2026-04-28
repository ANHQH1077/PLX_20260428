Module Report
    Public Function Get_HoaDon_ChiTietNew(ByVal i_SoLenh As String) As DataTable
        Dim err As String = String.Empty
        Dim DtTable As DataTable
        Dim p_SQL As String
        Try
            p_SQL = "exec FPT_HoaDon_ChiTietE5 '" & i_SoLenh & "'"
            DtTable = GetDataTable(p_SQL, p_SQL)
            DtTable = Alter_table_HoaDon(DtTable)
            Return DtTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Alter_table_HoaDon(ByVal i_dtTable As DataTable) As DataTable

        '01/02/2013 QUEHV - Them moi column WCF,L15,KG
        Dim dtHoaDon As DataTable = i_dtTable
        Dim col As DataColumn
        Dim vcf As String = String.Empty
        Dim wcf As String = String.Empty
        Dim l15 As String = String.Empty
        Dim kg As String = String.Empty

        For Each r As DataRow In dtHoaDon.Rows
            vcf = String.Empty
            wcf = String.Empty
            vcf = mdlQCI_GetVCF_NS(IIf(IsDBNull(r.Item("NhiệtĐộ")), 0, r.Item("NhiệtĐộ")), IIf(IsDBNull(r.Item("TỷTrọng")), 0, r.Item("TỷTrọng")))
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


    'FES
    '20141006
    'Ham thuc hien keim tra neu la hang hoa day sang Scada2 thi tra ve Y neu khong tra ve N. Loi tra ve E
    Public Function CheckItemToScada2(ByVal p_Item As String) As String
        Dim p_DataRow() As DataRow
        CheckItemToScada2 = "N"
        Try
            If Not g_HangHoaToScada2 Is Nothing Then
                If g_HangHoaToScada2.Rows.Count > 0 Then
                    p_DataRow = g_HangHoaToScada2.Select("MaHangHoa='" & p_Item.ToString.Trim & "'")
                    If p_DataRow.Length > 0 Then
                        CheckItemToScada2 = "Y"
                    End If
                End If
            End If
        Catch ex As Exception
            CheckItemToScada2 = "E"
        End Try

    End Function


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

End Module
