Module TyTrongTT

    Public Function mdlQCI_GetDTT_NS(ByVal p_HangHoaE5 As Boolean, ByVal i_temp As String, _
                                         ByVal i_dens As String) As String
        Dim l_vcf_1 As String


        Dim l_dens As String
        Dim l_dens_1 As String
        Dim l_dens_2 As String
        Dim l_temp As String
        Dim p_DataTable As DataTable
        Dim p_SQL As String

        If i_dens.Length > 6 Then
            l_dens = i_dens.Substring(0, 6)
        Else
            l_dens = i_dens
        End If

        l_dens_1 = mdlQCI_ConvertDens_1E5(l_dens)
        l_dens_2 = mdlQCI_ConvertDens_2E5(l_dens)

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

            If l_dens_1 = l_dens_2 Then

                p_SQL = "select top 1 TyTrongTT from tblTyTrong15E5 with (Nolock) where NhietDoTT=" & l_temp & " and TyTrong15=" & l_dens_1
                p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        l_vcf_1 = p_DataTable.Rows(0).Item("TyTrongTT").ToString.Trim
                    End If
                End If
                'l_vcf_1 = l_c2sql.getDataValue("select top 1 TyTrong15 from tblTyTrong15E5 with (Nolock) where NhietDoTT=" & l_temp & " and TyTrongTT=" & l_dens_1)
                '
            Else
                l_vcf_1 = mdlQCI_GetVCFSub_NSE5(l_temp, i_dens, l_dens_1, l_dens_2)
            End If
            'FES
            '20141028
            If l_vcf_1 = "" Then l_vcf_1 = "1"
        Catch ex As Exception
            l_vcf_1 = "1"
        End Try

        Return l_vcf_1
    End Function




    Private Function mdlQCI_ConvertDens_1E5(ByVal i_dens As String) As String
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
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 = "0" Then
                Return l_dens_1
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối = 0 và áp chót lẻ   : 1.2350 
            '   Đầu ra là                           : 1.235 - 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 = "0" Then
                l_dens_1_int = l_dens_1_int - l_step_1
                Return l_dens_1_int.ToString()
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót chẵn: 1.2346
            '   Đầu ra là                           : 1.234
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 <> "0" Then
                Return l_dens_1
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót lẻ  : 1.2351
            '   Đầu ra là                           : 1.235 - 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 <> "0" Then
                l_dens_1_int = l_dens_1_int - l_step_1
                Return l_dens_1_int.ToString()
            End If

            Return i_dens
        Catch ex As Exception
            Return i_dens
        End Try
    End Function


    Private Function mdlQCI_ConvertDens_2E5(ByVal i_dens As String) As String
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
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 = "0" Then
                Return l_dens_1
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối = 0 và áp chót lẻ   : 1.2350 
            '   Đầu ra là                           : 1.235 + 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 = "0" Then
                l_dens_1_int = l_dens_1_int + l_step_1
                Return l_dens_1_int.ToString()
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót chẵn: 1.2346
            '   Đầu ra là                           : 1.234 + 0.002
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 1 And l_dens_2 <> "0" Then
                l_dens_1_int = l_dens_1_int + l_step_2
                Return l_dens_1_int.ToString()
            End If

            '----------------------------------------------------
            '   Nếu vị trí cuối != 0 và áp chót lẻ  : 1.2351
            '   Đầu ra là                           : 1.235 + 0.001
            '----------------------------------------------------
            If (Convert.ToInt32(l_dens_3) Mod 2) = 0 And l_dens_2 <> "0" Then
                l_dens_1_int = l_dens_1_int + l_step_1
                Return l_dens_1_int.ToString()
            End If

            Return i_dens
        Catch ex As Exception
            Return i_dens
        End Try
    End Function


    Private Function mdlQCI_GetVCFSub_NSE5(ByVal i_temp As String, _
                                    ByVal i_dens As String, _
                                    ByVal i_dens_1 As String, _
                                    ByVal i_dens_2 As String) As String
        Dim l_dens_in, _
            l_dens_1_dec, _
            l_dens_2_dec As Decimal
        Dim l_dt As DataTable = New DataTable
        Dim l_sql As String

        Try

            l_dens_in = Convert.ToDecimal(i_dens)
            l_dens_1_dec = Convert.ToDecimal(i_dens_1)
            l_dens_2_dec = Convert.ToDecimal(i_dens_2)

            'l_sql = "select * from tblVCF where [Temp] = '" & i_temp & _
            '        "' and [Dens] in ('" & l_dens_1_dec.ToString() & "' , '" & l_dens_2_dec.ToString() & "') order by vcf"

            l_sql = "select  TyTrongTT from tblTyTrong15E5 with (Nolock) where " & _
                "NhietDoTT=" & i_temp & " and TyTrong15 in (" & l_dens_1_dec.ToString() & " , " & l_dens_2_dec.ToString() & ") order by TyTrongTT"


            l_dt = g_Services.Sys_SYS_GET_DATATABLE_Des(l_sql, l_sql)

            If l_dt.Rows.Count <> 2 Then
                Return "0"
            End If

            Dim l_vcf_1, _
                l_vcf_2, _
                l_vcf _
                As Decimal

            l_vcf_1 = Convert.ToDecimal(l_dt.Rows(0).Item("TyTrongTT").ToString())
            l_vcf_2 = Convert.ToDecimal(l_dt.Rows(1).Item("TyTrongTT").ToString())

            l_vcf = Math.Abs(l_vcf_2 - l_vcf_1) / Math.Abs(l_dens_2_dec - l_dens_1_dec)
            l_vcf = l_vcf_1 + l_vcf * (l_dens_in - l_dens_1_dec)

            Return Math.Round(l_vcf, 4)
        Catch ex As Exception
            Return "0"
        End Try

    End Function


End Module
