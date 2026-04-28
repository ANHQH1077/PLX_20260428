Module mdlQCI
    

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

    Public Function mdlQCI_GetVCFSub_NS(ByVal i_temp As String, _
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

    Public Function mdlQCI_GetVCF_NS(ByVal i_temp As String, _
                                     ByVal i_dens As String) As String
        Dim l_vcf_1 As String


        Dim l_dens As String
        Dim l_dens_1 As String
        Dim l_dens_2 As String
        Dim l_temp As String
        Dim l_dt As DataTable
        Dim l_vcf As String

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
                l_dt = GetDataTable("select VCF from tblVCF where [Dens] = '" & l_dens_1 & "' and [Temp] = '" & l_temp & "'", l_vcf)
                If Not l_dt Is Nothing Then
                    If l_dt.Rows.Count > 0 Then
                        l_vcf_1 = l_dt.Rows(0).Item("VCF").ToString.Trim
                    End If
                End If
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


    Private Function mdlQCI_GetDefaultTank(ByVal i_mahanghoa As String) As String()
        Dim l_result As String() = New String() {String.Empty, String.Empty}
        Try

            Dim l_dt As DataTable = New DataTable
            Dim p_SQL As String
            l_dt = GetDataTable("Select top 10 * from tblTankActive where Product_nd = '" & i_mahanghoa & "' Order by ID desc", p_SQL)

            If l_dt.Rows.Count > 0 Then
                l_result(0) = "30.00"
                l_result(1) = l_dt.Rows(0).Item("Dens_nd").ToString()
            Else
                l_result(0) = "30.00"
                l_result(1) = "0.658"
            End If
        Catch ex As Exception

        End Try

        Return l_result

    End Function


    Public Function mdlQCI_GetVCF(ByVal i_mahanghoa As String) As String
        Dim l_vcf As String
        Dim l_out As String()
        Try
            l_out = mdlQCI_GetDefaultTank(i_mahanghoa)
            l_vcf = mdlQCI_GetVCF(l_out(0), l_out(1))
            If l_vcf = String.Empty Then
                l_vcf = "1"
            End If
        Catch ex As Exception
            l_vcf = "1"
        End Try

        Return l_vcf
    End Function

    Public Function mdlQCI_GetDens15(ByVal i_mahanghoa As String) As String
        Dim l_dens15 As String
        'Dim l_c2sql As Connect2SQL.Connect2SQLd
        Dim l_vcf As String
        Dim l_now As String = Format(Now(), "dd/MM/yyyy")
        Dim l_dt As DataTable
        Try
            ' l_c2sql = New Connect2SQL.Connect2SQL(_SQLConnectionString)
            l_dens15 = "1"
            l_dt = GetDataTable("Select Dens_nd from tblDoBe where Name_Nd = '" & i_mahanghoa & _
                                            "' and Date_nd = '" & l_now & "'", l_vcf)
            If Not l_dt Is Nothing Then
                If l_dt.Rows.Count > 0 Then
                    l_dens15 = l_dt.Rows(0).Item("Dens_nd").ToString.Trim
                End If
            End If

            'l_dens15 = l_c2sql.getDataValue("Select Dens_nd from tblDoBe where Name_Nd = '" & i_mahanghoa & _
            '                                "' and Date_nd = '" & l_now & "'")
            If l_dens15 = String.Empty Then
                l_dens15 = "1"
            End If
        Catch ex As Exception
            l_dens15 = "0.658"
        End Try

        Return l_dens15
    End Function

    Public Function mdlQCI_GetWCF(ByVal i_dens15 As String) As String
        Dim l_wcf As Decimal
        Dim l_dens As Decimal = 0.0011

        l_wcf = Convert.ToDecimal(i_dens15)
        l_wcf = l_wcf - l_dens

        Return l_wcf.ToString()
    End Function

    '-----------------
    '0: L
    '1: L15
    '2: M15
    '3: Kg
    '-----------------

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

    Public Function mdlQCI_CalculateQCI_NS(ByVal i_quantity As Decimal, ByVal i_donvitinh As String, ByVal i_temp As Decimal, ByVal i_dens As Decimal) As Decimal()
        Dim l_result As Decimal() = New Decimal() {0, 0, 0, 0}
        Dim l_temp, l_dens, l_vcf, l_wcf As String
        Dim l_temp_str As String()

        l_temp = i_temp.ToString()
        l_dens = i_dens.ToString()

        l_temp_str = l_temp.ToString().Split(".")

        If l_temp_str.Length = 1 Then
            l_temp = l_temp_str(0) & ".00"
        End If

        l_vcf = mdlQCI_GetVCF_NS(l_temp, l_dens)
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
End Module
