Module Module2
    Public p_SYS_MALENH_S As String = String.Empty

    Public g_SYS_CONFIG_RPT_PARA As DataTable
    Public g_SYS_CONFIG_RPT As DataTable
    Public g_SYS_CONFIG_RPT_FIELD As DataTable

    Public g_tblVCF As DataTable
    Public g_HOADON1 As String = ""
    Public g_HOADON2 As String = ""


    Public Sub p_GetCurrentDate(ByRef p_Date As DateTime)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        p_SQL = "select  getdate() as SysDate"
        ' p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SysDate")

            End If
        End If
        p_Datatable = Nothing
    End Sub

    Public Function FPT_GetMaLenh() As String
        Dim p_ValueTmp As String = "0000"
        Dim p_SQL As String = ""
        Dim p_Value As Integer = 0
        Dim p_DataTable As DataTable
        Try
            If p_SYS_MALENH_S.ToString.Trim = "" Then
                p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG where KEYCODE='SYS_MALENH_S'"
                p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        p_SYS_MALENH_S = p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim

                    End If
                End If
            End If

            p_DataTable = Nothing
            FPT_GetMaLenh = "0000"
            p_SQL = "exec FPT_Get_SYS_MALENH_S"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_Value = p_DataTable.Rows(0).Item(0)
                End If
            End If
            If p_Value > 0 Then
                If Len(p_Value.ToString.Trim) < 4 Then
                    FPT_GetMaLenh = Mid(p_ValueTmp, 1, Len(FPT_GetMaLenh.ToString.Trim) - Len(p_Value.ToString.Trim) - Len(p_SYS_MALENH_S)) & p_Value.ToString.Trim
                    If Len(FPT_GetMaLenh) = 3 Then
                        FPT_GetMaLenh = p_SYS_MALENH_S & FPT_GetMaLenh
                    End If
                Else
                    FPT_GetMaLenh = p_Value.ToString.Trim
                End If
            End If
        Catch ex As Exception
            FPT_GetMaLenh = "0000"
        End Try

    End Function

    Public Function CheckMaLenh(ByRef err As String, ByVal i_malenh As String, ByVal i_ngay As Date) As String

        Dim p_DataTable As DataTable
        Dim p_SQL As String
        Try
            CheckMaLenh = ""
            p_SQL = "select DBO.FPT_CheckMaLenh_E5('" & i_malenh & "','" & i_ngay & "') as MaLenh "
            '_c2SQL = New Connect2SQL.Connect2SQL(_SQLConnectionString)
            'Return _c2SQL.getDataValue("select DBO.fm_CheckMaLenh_KV2E5('" & i_malenh & "','" & i_ngay & "')")
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    CheckMaLenh = p_DataTable.Rows(0).Item("MaLenh").ToString.Trim
                End If
            End If
            ' Return _c2SQL.getDataValue("exec CheckMaLenh_KV2E5('" & i_malenh & "','" & i_ngay & "')")

        Catch ex As Exception
            Return "1"
            err = ex.Message
        End Try
    End Function


    Public Sub CreateFieldForm(ByVal p_Form As U_CusForm.XtraCusForm1)
        Dim p_SQL As String
        Dim p_Object As Object
        Dim p_Count As Integer

        Dim pv_Type_Date As String = ".U_DATEEDIT"

        Dim pv_Type_ChectBox As String = ".U_CHECKBOX"

        Dim pv_Type_TextBox As String = ".U_TEXTBOX"
        Dim pv_Type_MemoEdit As String = UCase(".U_MemmoEdit")
        Dim pv_Type_Num As String = ".U_NUMERICEDIT"
        Dim pv_Type_Combo As String = ".U_COMBOBOX"
        Dim pv_Type_Button As String = ".U_BUTTONEDIT"
        'PanelControl
        Dim pv_Type_MemoTextBox As String = ".U_MEMMOEDIT"
        Dim pv_Type_TrueDBGrid As String = ".U_TRUEDBGRID"
        Dim pv_Type_TrueDBGridNew As String = ".TRUEDBGRID"
        Dim pv_Type_Navigator As String = UCase(".Navigator")
        Dim p_Field As String
        p_SQL = ""

        For p_Count = 0 To p_Form.Controls.Count - 1
            p_Object = p_Form.Controls.Item(p_Count)

            If InStr(UCase(p_Object.GetType.ToString), pv_Type_Date, CompareMethod.Text) > 0 _
                       Or InStr(UCase(p_Object.GetType.ToString), pv_Type_TextBox, CompareMethod.Text) > 0 _
                       Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoEdit, CompareMethod.Text) > 0 _
                       Or InStr(UCase(p_Object.GetType.ToString), pv_Type_MemoTextBox, CompareMethod.Text) > 0 _
                       Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Combo, CompareMethod.Text) > 0 _
                       Or InStr(UCase(p_Object.GetType.ToString), pv_Type_ChectBox, CompareMethod.Text) > 0 _
                                   Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Num, CompareMethod.Text) > 0 _
                                   Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Button, CompareMethod.Text) > 0 _
                                   Or InStr(UCase(p_Object.GetType.ToString), pv_Type_Navigator, CompareMethod.Text) > 0 Then

                p_Field = p_Object.name
                Select Case p_Object.FieldType
                    Case "C"
                        p_SQL = p_SQL & " if  COL_LENGTH('tblChungTu','" & p_Field & "') is null " & _
                      "  begin alter table tblChungTu  add " & p_Field & " nvarchar(500) end;"
                    Case "N"
                        p_SQL = p_SQL & " if  COL_LENGTH('tblChungTu','" & p_Field & "') is null " & _
                      "  begin alter table tblChungTu  add " & p_Field & " Numeric(10,6) end;"
                    Case "F"
                        p_SQL = p_SQL & " if  COL_LENGTH('tblChungTu','" & p_Field & "') is null " & _
                      "  begin alter table tblChungTu  add " & p_Field & " Numeric(10,6) end;"
                    Case "D"
                        p_SQL = p_SQL & " if  COL_LENGTH('tblChungTu','" & p_Field & "') is null " & _
                      "  begin alter table tblChungTu  add " & p_Field & " DateTime end;"
                    Case Else
                        p_SQL = p_SQL
                End Select

            End If
        Next
        If p_SQL = "" Then
            Exit Sub
        End If
        If g_Services.Sys_Execute(p_SQL, _
                                        p_SQL) = False Then

        End If

    End Sub



    'Public Function ND_VCF_All(ByVal LTT As String, ByVal productID As String, ByVal unitID As String, ByVal dgvRow As Integer) As String

    '    '01/02/2013 QUEHV - Sua cac trinh tu thong tin theo don vi ban va hang hoa
    '    Dim Hed As String = String.Empty
    '    Dim ND As String = String.Empty
    '    Dim TX As String = String.Empty
    '    Dim D15 As String = String.Empty
    '    Dim VCF As String = String.Empty
    '    Dim L15 As String = String.Empty
    '    Dim KG As String = String.Empty
    '    Dim WCF As String = String.Empty
    '    Dim Full As String = String.Empty
    '    Dim p_TongDuXuat As String
    '    Dim p_ArrRow() As DataRow
    '    Dim p_DataRow As DataRow

    '    Try
    '        p_TongDuXuat = "0"
    '        p_ArrRow = g_SySConfig.Select("KEYCODE='TONGDUXUAT'")
    '        If p_ArrRow.Length > 0 Then
    '            If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
    '                p_TongDuXuat = p_ArrRow(0).Item("KEYVALUE").ToString.Trim
    '            End If
    '        End If

    '        p_DataRow = Me.GridView1.GetDataRow(dgvRow)
    '        ND = p_DataRow.Item("NhiệtĐộ").ToString()
    '        If ND.Contains(".") Then
    '            ND = ND.Replace(".", ",")
    '        End If

    '        Dim _D15 As Double = IIf(IsDBNull(p_DataRow.Item("TỷTrọng").ToString()), 0, p_DataRow.Item("TỷTrọng").ToString())
    '        D15 = Format(_D15, "0.0000").ToString
    '        If D15.Contains(".") Then
    '            D15 = D15.Replace(".", ",")
    '        End If

    '        Dim _VCF As Double = p_DataRow.Item("VCF").ToString()


    '        VCF = Format(_VCF, "0.0000").ToString
    '        If VCF.Contains(".") Then
    '            VCF = VCF.Replace(".", ",")
    '        End If

    '        Dim _WCF As Double = p_DataRow.Item("WCF").ToString()
    '        WCF = Format(_WCF, "0.0000").ToString
    '        If WCF.Contains(".") Then
    '            WCF = WCF.Replace(".", ",")
    '        End If

    '        KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
    '        L15 = Format(CInt(p_DataRow.Item("L15").ToString()), "n0").Replace(",", ".")

    '        'FES
    '        '20141027
    '        Select Case unitID.ToUpper
    '            Case "L"
    '                Select Case productID.ToUpper
    '                     If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then

    '                    End If
    '                    Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
    '                        Hed = "Nhiệt độ TT/KG/L15/D15/VCF/WCF: "

    '                        Full = Hed + ND + " / " + KG + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF

    '                    Case "0701001", "0701002", "0701003"
    '                        Hed = "Nhiệt độ TT/KG/D15/VCF/WCF: "

    '                        KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
    '                        Full = Hed + ND + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF

    '                End Select
    '            Case "L15"
    '                Select Case productID.ToUpper
    '                    Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
    '                        Hed = "Nhiệt độ TT/LTT/KG/D15/VCF/WCF: "
    '                        'p_TongDuXuat
    '                        'If g_dtPara.Rows(16).Item("Value_nd").ToString().Trim() = "1" Then
    '                        '    TX = dgvProduct.Rows(dgvRow).Cells("TổngXuất").Value.ToString()
    '                        'Else
    '                        '    TX = dgvProduct.Rows(dgvRow).Cells("TổngDựXuất").Value.ToString()
    '                        'End If
    '                        If p_TongDuXuat = "0" Or p_TongDuXuat = "" Then
    '                            TX = p_DataRow.Item("TổngXuất").ToString()
    '                        Else
    '                            TX = p_DataRow.Item("TổngDựXuất").ToString()
    '                        End If

    '                        Full = Hed + ND + " / " + TX + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
    '                End Select
    '            Case "KG"
    '                Select Case productID.ToUpper
    '                    Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
    '                        Hed = "Nhiệt độ TT/LTT/L15/D15/VCF/WCF: "

    '                        TX = p_DataRow.Item("TổngXuất").ToString()

    '                        Full = Hed + ND + " / " + TX + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF

    '                    Case "0701001", "0701002", "0701003"
    '                        Hed = "Nhiệt độ TT/LTT/D15/VCF/WCF: "

    '                        TX = p_DataRow.Item("TổngXuất").ToString()

    '                        Full = Hed + ND + " / " + TX + " / " + D15 + " / " + VCF + " / " + WCF

    '                End Select
    '        End Select

    '        Return Full
    '    Catch ex As Exception
    '        ShowStatusMessage(True, "", ex.Message, 5)
    '        Return Nothing
    '    End Try
    'End Function





    Private Function ND_VCF(ByVal LTT As String, ByVal productID As String, ByVal unitID As String, ByVal dgvRow As Integer,
                                ByVal p_DataRow As DataRow) As String

        '01/02/2013 QUEHV - Sua cac trinh tu thong tin theo don vi ban va hang hoa
        Dim Hed As String = String.Empty
        Dim ND As String = String.Empty
        Dim TX As String = String.Empty
        Dim D15 As String = String.Empty
        Dim VCF As String = String.Empty
        Dim L15 As String = String.Empty
        Dim KG As String = String.Empty
        Dim WCF As String = String.Empty
        Dim Full As String = String.Empty
        Dim p_TongDuXuat As String
        Dim p_ArrRow() As DataRow
        ' Dim p_DataRow As DataRow

        Try
            p_TongDuXuat = "0"
            p_ArrRow = g_SySConfig.Select("KEYCODE='TONGDUXUAT'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    p_TongDuXuat = p_ArrRow(0).Item("KEYVALUE").ToString.Trim
                End If
            End If

            '  p_DataRow = Me.GridView1.GetDataRow(dgvRow)
            ND = p_DataRow.Item("NhiệtĐộ").ToString()
            ND = Format(CInt(ND), "n2").ToString 'hieptd4 add
            If ND.Contains(".") Then
                ND = ND.Replace(".", ",")
            End If

            Dim _D15 As Double = IIf(IsDBNull(p_DataRow.Item("TỷTrọng").ToString()), 0, p_DataRow.Item("TỷTrọng").ToString())
            D15 = Format(_D15, "0.0000").ToString
            If D15.Contains(".") Then
                D15 = D15.Replace(".", ",")
            End If

            Dim _VCF As Double = p_DataRow.Item("VCF").ToString()


            VCF = Format(_VCF, "0.0000").ToString
            If VCF.Contains(".") Then
                VCF = VCF.Replace(".", ",")
            End If

            Dim _WCF As Double = p_DataRow.Item("WCF").ToString()
            WCF = Format(_WCF, "0.0000").ToString
            If WCF.Contains(".") Then
                WCF = WCF.Replace(".", ",")
            End If

            KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0") '.Replace(",", ".")
            L15 = Format(CInt(p_DataRow.Item("L15").ToString()), "n0") '.Replace(",", ".")

            'FES
            '20141027
            Select Case unitID.ToUpper
                Case "L"
                    Select Case productID.ToUpper
                        Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
                            'Hed = "Nhiệt độ TT/KG/L15/D15/VCF/WCF: "

                            'Full = Hed + ND + " / " + KG + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF

                            Hed = "Nhiệt độ L15/Kg/to/D15/VCF/WCF  " '+ vbCrLf
                            Full = Hed + L15 + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                        Case "0701001", "0701002", "0701003"
                            'Hed = "Nhiệt độ TT/KG/D15/VCF/WCF: "
                            Hed = "Kg/to/D15/VCF/WCF  " '+ vbCrLf

                            KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
                            'Full = Hed + ND + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
                            Full = Hed + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    End Select
                Case "L15"
                    Select Case productID.ToUpper
                        Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
                            'Hed = "Nhiệt độ TT/LTT/KG/D15/VCF/WCF: "
                            Hed = "LTT/Kg/to/D15/VCF/WCF  " '+ vbCrLf

                            'p_TongDuXuat
                            'If g_dtPara.Rows(16).Item("Value_nd").ToString().Trim() = "1" Then
                            '    TX = dgvProduct.Rows(dgvRow).Cells("TổngXuất").Value.ToString()
                            'Else
                            '    TX = dgvProduct.Rows(dgvRow).Cells("TổngDựXuất").Value.ToString()
                            'End If
                            If p_TongDuXuat = "0" Or p_TongDuXuat = "" Then
                                TX = p_DataRow.Item("TổngXuất").ToString()
                            Else
                                TX = p_DataRow.Item("TổngDựXuất").ToString()
                            End If

                            'Full = Hed + ND + " / " + TX + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
                            Full = Hed + TX + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF
                    End Select
                Case "KG"
                    Select Case productID.ToUpper
                        Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
                            'Hed = "Nhiệt độ TT/LTT/L15/D15/VCF/WCF: "
                            Hed = "LTT/L15/to/D15/VCF/WCF  " '+ vbCrLf

                            TX = p_DataRow.Item("TổngXuất").ToString()

                            'Full = Hed + ND + " / " + TX + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF
                            Full = Hed + TX + " / " + L15 + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                        Case "0701001", "0701002", "0701003"
                            'Hed = "Nhiệt độ TT/LTT/D15/VCF/WCF: "
                            Hed = "LTT/to/D15/VCF/WCF  " '+ vbCrLf

                            TX = p_DataRow.Item("TổngXuất").ToString()

                            'Full = Hed + ND + " / " + TX + " / " + D15 + " / " + VCF + " / " + WCF
                            Full = Hed + TX + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    End Select
            End Select






            Select Case unitID.ToUpper
                Case "L"
                  
                    If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
                        Hed = "Nhiệt độ L15/KG/TT/D15/VCF/WCF: " '+ vbCrLf

                        Full = Hed + ND + " / " + KG + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF

                        'Hed = "Nhiệt độ TT/L15/Kg/to/D15/VCF/WCF: " + vbCrLf
                        'Full = Hed + L15 + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    ElseIf InStr(g_HOADON2, productID.ToUpper, CompareMethod.Text) > 0 Then
                        Hed = "Nhiệt độ TT/KG/D15/VCF/WCF: " '+ vbCrLf
                        'Hed = "Kg/to/D15/VCF/WCF: " + vbCrLf

                        KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
                        Full = Hed + ND + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
                        'Full = Hed + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    End If
                Case "L15"
                    'Select Case productID.ToUpper
                    '    Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
                    '        Hed = "Nhiệt độ TT/LTT/KG/D15/VCF/WCF: " '+ vbCrLf

                    '        If p_TongDuXuat = "0" Or p_TongDuXuat = "" Then
                    '            TX = p_DataRow.Item("TổngXuất").ToString()
                    '        Else
                    '            TX = p_DataRow.Item("TổngDựXuất").ToString()
                    '        End If
                    '        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add


                    '        Full = Hed + ND + " / " + TX + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
                    '        'Full = Hed + TX + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF
                    'End Select

                    If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
                        Hed = "Nhiệt độ TT/LTT/KG/D15/VCF/WCF: " '+ vbCrLf

                        If p_TongDuXuat = "0" Or p_TongDuXuat = "" Then
                            TX = p_DataRow.Item("TổngXuất").ToString()
                        Else
                            TX = p_DataRow.Item("TổngDựXuất").ToString()
                        End If
                        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add


                        Full = Hed + ND + " / " + TX + " / " + KG + " / " + D15 + " / " + VCF + " / " + WCF
                        'Full = Hed + TX + " / " + KG + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF
                    End If
                Case "KG"
                    'Select Case productID.ToUpper
                    '    Case "0101001", "0201001", "0201002", "0201003", "0501001", "0601001", "0601002", "0201004"
                    '        Hed = "Nhiệt độ TT/LTT/L15/D15/VCF/WCF: " '+ vbCrLf
                    '        'Hed = "LTT/L15/to/D15/VCF/WCF: " + vbCrLf

                    '        TX = p_DataRow.Item("TổngXuất").ToString()
                    '        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add

                    '        Full = Hed + ND + " / " + TX + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF
                    '        'Full = Hed + TX + " / " + L15 + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    '    Case "0701001", "0701002", "0701003"
                    '        Hed = "Nhiệt độ TT/LTT/D15/VCF/WCF: " '+ vbCrLf
                    '        'Hed = "LTT/to/D15/VCF/WCF: " + vbCrLf

                    '        TX = p_DataRow.Item("TổngXuất").ToString()
                    '        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add

                    '        Full = Hed + ND + " / " + TX + " / " + D15 + " / " + VCF + " / " + WCF
                    '        'Full = Hed + TX + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    'End Select

                    If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
                        Hed = "Nhiệt độ TT/LTT/L15/D15/VCF/WCF: " '+ vbCrLf
                        'Hed = "LTT/L15/to/D15/VCF/WCF: " + vbCrLf

                        TX = p_DataRow.Item("TổngXuất").ToString()
                        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add

                        Full = Hed + ND + " / " + TX + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF
                        'Full = Hed + TX + " / " + L15 + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    ElseIf InStr(g_HOADON2, productID.ToUpper, CompareMethod.Text) > 0 Then
                        Hed = "Nhiệt độ TT/LTT/D15/VCF/WCF: " '+ vbCrLf
                        'Hed = "LTT/to/D15/VCF/WCF: " + vbCrLf

                        TX = p_DataRow.Item("TổngXuất").ToString()
                        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add

                        Full = Hed + ND + " / " + TX + " / " + D15 + " / " + VCF + " / " + WCF
                        'Full = Hed + TX + " / " + ND + " / " + D15 + " / " + VCF + " / " + WCF

                    End If

            End Select

            Return Full
        Catch ex As Exception
            '  ShowStatusMessage(True, "", ex.Message, 5)
            Return Nothing
        End Try
    End Function


End Module
