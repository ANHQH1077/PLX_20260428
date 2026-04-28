Module mdlFunction



    Public Function ND_VCF_Xitec_Option(GridView1 As U_TextBox.GridView, p_SoLenh As String, ByVal LTT As String, ByVal productID As String, ByVal unitID As String, ByVal dgvRow As Integer) As String
        '01/02/2013 QUEHV - Sua cac trinh tu thong tin theo don vi ban va hang hoa
        Dim Hed As String = String.Empty
        Dim ND As String = "" 'String.Empty
        Dim TX As String = String.Empty
        Dim D15 As String = String.Empty
        Dim VCF As String = String.Empty
        Dim L15 As String = String.Empty
        Dim KG As String = String.Empty
        Dim WCF As String = String.Empty
        Dim Full As String = String.Empty
        Dim p_TongDuXuat As String
        Dim p_ArrRow() As DataRow
        Dim p_DataRow As DataRow
        ' Dim p_
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_Value As String = "N"

        Try

            'anhqh
            'kiem tra neu nooij dung theo XITEC_OPTION
            Try
                p_SQL = "select XITEC_OPTION from tbllenhxuate5 where solenh ='" & p_SoLenh & "'"
                p_Table = GetDataTable(p_SQL, p_SQL)

                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        If p_Table.Rows(0).Item("XITEC_OPTION").ToString.Trim = "Y" Then
                            p_Value = "Y"
                        End If
                    End If
                End If
            Catch ex As Exception

            End Try
            p_TongDuXuat = "0"
            p_ArrRow = g_SySConfig.Select("KEYCODE='TONGDUXUAT'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    p_TongDuXuat = p_ArrRow(0).Item("KEYVALUE").ToString.Trim
                End If
            End If

            If p_Value = "Y" Then
                If p_TongDuXuat = "0" Then
                    p_TongDuXuat = "1"
                Else
                    p_TongDuXuat = "0"
                End If
            End If


            p_DataRow = GridView1.GetDataRow(dgvRow)
            ND = CDbl(p_DataRow.Item("NhiệtĐộ").ToString())
            ' ND = Format(CInt(ND), "n2").ToString 'hieptd4 add

            'ND = Format(CInt(ND), "n2").ToString

            'If ND.Contains(".") Then
            '    ND = ND.Replace(".", ",")
            'End If

            If ND.Contains(".") Then
                If Len(Mid(ND, InStr(ND, ".") + 1, Len(ND) - InStr(ND, "."))) <= 1 Then
                    ND = ND.Replace(".", ",") & "0"
                Else
                    ND = ND.Replace(".", ",")
                End If

            Else
                ND = ND + ",00"
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

            KG = Format(CInt(p_DataRow.Item("KG").ToString()), "n0").Replace(",", ".")
            L15 = Format(CInt(p_DataRow.Item("L15").ToString()), "n0").Replace(",", ".")

            'FES
            '20141027
            Select Case unitID.ToUpper
                Case "L"

                    Hed = "Nhiệt độ TT/KG/L15/D15/VCF/WCF: " '+ vbCrLf

                    Full = Hed + ND + " / " + KG + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF




                Case "L15"

                    If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
                        Hed = "Nhiệt độ TT/KG/LTT/D15/VCF/WCF: " '+ vbCrLf

                        If p_TongDuXuat = "0" Or p_TongDuXuat = "" Then
                            TX = p_DataRow.Item("TổngXuất").ToString()
                        Else
                            TX = p_DataRow.Item("TổngDựXuất").ToString()
                        End If
                        TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add


                        Full = Hed + ND + " / " + KG + " / " + TX + " / " + D15 + " / " + VCF + " / " + WCF
                    End If


                Case "KG"

                    ' If InStr(g_HOADON1, productID.ToUpper, CompareMethod.Text) > 0 Then
                    Hed = "Nhiệt độ TT/LTT/L15/D15/VCF/WCF: " '+ vbCrLf
                    'Hed = "LTT/L15/to/D15/VCF/WCF: " + vbCrLf

                    TX = p_DataRow.Item("TổngXuất").ToString()
                    TX = Format(CInt(TX), "n0").Replace(",", ".") 'hieptd4 add

                    Full = Hed + ND + " / " + TX + " / " + L15 + " / " + D15 + " / " + VCF + " / " + WCF


            End Select

            Return Full
        Catch ex As Exception
            'ShowStatusMessage(True, "", ex.Message, 5)
            Return Nothing
        End Try
    End Function


    'FES ANNV 10/11 them ham xu ly trong hoa don tai xuat
    ' Converts a number from 10 to 99 into text. 
    Function GetTens(ByVal TensText As String) As String
        Dim Result As String
        Result = ""           ' Null out the temporary function value.
        If Val(Left(TensText, 1)) = 1 Then   ' If value between 10-19...
            Select Case Val(TensText)
                Case 10 : Result = "Ten"
                Case 11 : Result = "Eleven"
                Case 12 : Result = "Twelve"
                Case 13 : Result = "Thirteen"
                Case 14 : Result = "Fourteen"
                Case 15 : Result = "Fifteen"
                Case 16 : Result = "Sixteen"
                Case 17 : Result = "Seventeen"
                Case 18 : Result = "Eighteen"
                Case 19 : Result = "Nineteen"
                Case Else
            End Select
        Else                                 ' If value between 20-99...
            Select Case Val(Left(TensText, 1))
                Case 2 : Result = "Twenty "
                Case 3 : Result = "Thirty "
                Case 4 : Result = "Forty "
                Case 5 : Result = "Fifty "
                Case 6 : Result = "Sixty "
                Case 7 : Result = "Seventy "
                Case 8 : Result = "Eighty "
                Case 9 : Result = "Ninety "
                Case Else
            End Select
            Result = Result & GetDigit _
            (Right(TensText, 1))  ' Retrieve ones place.
        End If
        GetTens = Result
    End Function

    'FES ANNV 10/11 them ham xu ly trong hoa don tai xuat
    ' Converts a number from 1 to 9 into text. 
    Function GetDigit(ByVal Digit As String) As String
        Select Case Val(Digit)
            Case 1 : GetDigit = "One"
            Case 2 : GetDigit = "Two"
            Case 3 : GetDigit = "Three"
            Case 4 : GetDigit = "Four"
            Case 5 : GetDigit = "Five"
            Case 6 : GetDigit = "Six"
            Case 7 : GetDigit = "Seven"
            Case 8 : GetDigit = "Eight"
            Case 9 : GetDigit = "Nine"
            Case Else : GetDigit = ""
        End Select
    End Function

    'FES ANNV 10/11 them ham xu ly trong hoa don tai xuat
    ' Converts a number from 100-999 into text 
    Function GetHundreds(ByVal MyNumber As String) As String
        Dim Result As String = String.Empty
        If Val(MyNumber) = 0 Then : Return "" : Exit Function : End If
        MyNumber = Right("000" & MyNumber, 3)
        ' Convert the hundreds place.
        If Mid(MyNumber, 1, 1) <> "0" Then
            Result = GetDigit(Mid(MyNumber, 1, 1)) & " Hundred "
        End If
        ' Convert the tens and ones place.
        If Mid(MyNumber, 2, 1) <> "0" Then
            Result = Result & GetTens(Mid(MyNumber, 2))
        Else
            Result = Result & GetDigit(Mid(MyNumber, 3))
        End If
        GetHundreds = Result
    End Function

    'FES ANNV 10/11 them ham xu ly trong hoa don tai xuat
    Public Function Number2Text_EN(ByVal MyNumber As String) As String
        Dim Dollars As String = ""
        Dim Cents As String = ""
        Dim Temp As String = ""
        Dim DecimalPlace, Count As Integer
        Dim Place(9) As String
        Place(2) = " Thousand "
        Place(3) = " Million "
        Place(4) = " Billion "
        Place(5) = " Trillion "
        ' String representation of amount.
        'MyNumber = Trim(str(MyNumber))
        ' Position of decimal place 0 if none.
        DecimalPlace = InStr(MyNumber, ".")
        ' Convert cents and set MyNumber to dollar amount.
        If DecimalPlace > 0 Then
            Cents = GetTens(Left(Mid(MyNumber, DecimalPlace + 1) & _
            "00", 2))
            MyNumber = Trim(Left(MyNumber, DecimalPlace - 1))
        End If
        Count = 1
        Do While MyNumber <> ""
            Temp = GetHundreds(Right(MyNumber, 3))
            If Temp <> "" Then Dollars = Temp & Place(Count) & Dollars
            If Len(MyNumber) > 3 Then
                MyNumber = Left(MyNumber, Len(MyNumber) - 3)
            Else
                MyNumber = ""
            End If
            Count = Count + 1
        Loop
        Select Case Dollars
            Case ""
                Dollars = "No Dollars"
            Case "One"
                Dollars = "One Dollar"
            Case Else
                Dollars = Dollars & " Dollars"
        End Select
        Select Case Cents
            Case ""
                Cents = " and No Cents"
            Case "One"
                Cents = " and One Cent"
            Case Else
                Cents = " and " & Cents & " Cents"
        End Select
        Number2Text_EN = Dollars & Cents
    End Function

    Public Function Number2Text(ByVal sNumber As String) As String
        Dim mLen As Long
        Dim i As Long = 0
        Dim mDigit As Long
        Dim mTemp As String = ""
        Dim mNumText() As String

        mNumText = Split("không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín", ";")
        mLen = Len(sNumber)
        For i = 1 To mLen
            mDigit = Mid(sNumber, i, 1)
            mTemp = mTemp & " " & mNumText(mDigit)
            If (mLen = i) Then Exit For
            Select Case (mLen - i) Mod 9
                Case 0
                    mTemp = mTemp & " tỷ"
                    If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
                    If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
                    If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
                Case 6
                    mTemp = mTemp & " triệu"
                    If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
                    If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
                Case 3
                    mTemp = mTemp & " nghìn"
                    If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
                Case Else
                    Select Case (mLen - i) Mod 3
                        Case 2
                            mTemp = mTemp & " trăm"
                        Case 1
                            mTemp = mTemp & " mươi"
                    End Select
            End Select
        Next
        'Loại bỏ trường hợp x00
        mTemp = Replace(mTemp, "không mươi không", "")
        'Loại bỏ trường hợp 00x
        mTemp = Replace(mTemp, "không mươi ", "linh ")
        'Loại bỏ trường hợp x0, x>=2
        mTemp = Replace(mTemp, "mươi không", "mươi")
        'Fix trường hợp 10
        mTemp = Replace(mTemp, "một mươi", "mười")
        'Fix trường hợp x4, x>=2
        mTemp = Replace(mTemp, "mươi bốn", "mươi tư")
        'Fix trường hợp x04
        mTemp = Replace(mTemp, "linh bốn", "linh tư")
        'Fix trường hợp x5, x>=2
        mTemp = Replace(mTemp, "mươi năm", "mươi nhăm")
        'Fix trường hợp x1, x>=2
        mTemp = Replace(mTemp, "mươi một", "mươi mốt")
        'Fix trường hợp x15
        mTemp = Replace(mTemp, "mười năm", "mười lăm")
        'Bỏ ký tự space
        mTemp = Trim(mTemp)
        'Ucase ký tự đầu tiên
        Return (mTemp.ToUpper.Substring(0, 1) & mTemp.Substring(1, mTemp.Length - 1))

    End Function

End Module
