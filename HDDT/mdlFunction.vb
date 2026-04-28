Module mdlFunction

    'FES ANNV 10/11 them ham xu ly trong hoa don tai xuat
    ' Converts a number from 10 to 99 into text. 
    Function GetTens(ByVal TensText As String) As String
        Dim Result As String
        Result = ""           ' Null out the temporary function value.
        If Val(Left(TensText, 1)) = 1 Then   ' If value between 10-19...
            Select Case Val(TensText)
                Case 10 : Result = "mười"
                Case 11 : Result = "mười một"
                Case 12 : Result = "mười hai"
                Case 13 : Result = "mười ba"
                Case 14 : Result = "mười bốn"
                Case 15 : Result = "mười năm"
                Case 16 : Result = "mười sáu"
                Case 17 : Result = "mười bảy"
                Case 18 : Result = "mười tám"
                Case 19 : Result = "mười chín"
                Case Else
            End Select
        Else                                 ' If value between 20-99...
            Select Case Val(Left(TensText, 1))
                Case 2 : Result = "hai mươi "
                Case 3 : Result = "ba mươi "
                Case 4 : Result = "bốn mươi "
                Case 5 : Result = "năm mươi "
                Case 6 : Result = "sáu mươi "
                Case 7 : Result = "bảy mươi "
                Case 8 : Result = "tám mươi "
                Case 9 : Result = "chín mươi "
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
            Case 1 : GetDigit = "một"
            Case 2 : GetDigit = "hai"
            Case 3 : GetDigit = "ba"
            Case 4 : GetDigit = "bốn"
            Case 5 : GetDigit = "năm"
            Case 6 : GetDigit = "sáu"
            Case 7 : GetDigit = "bảy"
            Case 8 : GetDigit = "tám"
            Case 9 : GetDigit = "chín"
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
            Result = GetDigit(Mid(MyNumber, 1, 1)) & " trăm "
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



    'FES ANNV 10/11 them ham xu ly trong hoa don tai xuat
    Public Function Number2Text_EN_VN(ByVal MyNumber As String) As String
        Dim Dollars As String = ""
        Dim Cents As String = ""
        Dim Temp As String = ""
        Dim DecimalPlace, Count As Integer
        Dim Place(9) As String
        Place(2) = " nghìn " '" Thousand "
        Place(3) = " triệu "
        Place(4) = " tỷ "
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
                Dollars = "không Đô la Mỹ"
            Case "One"
                Dollars = "một Đô la Mỹ"
            Case Else
                Dollars = Dollars & "  Đô la Mỹ"
        End Select
        Select Case Cents
            Case ""
                'Cents = " và không xu"
            Case "One"
                Cents = " và một xu"
            Case Else
                Cents = " và " & Cents & " xu"
        End Select
        Number2Text_EN_VN = Dollars & Cents & " chẵn"
    End Function



    Public Function Number2Text(ByVal sNumber As String) As String
        Dim mLen As Long
        Dim i As Long = 0
        Dim mDigit As Long
        Dim mTemp As String = ""
        Dim mNumText() As String
        Dim p_String As String = "mốt"
        Dim p_String2 As String = "mươi"
        Dim p_String3 As String = "một mươi"
        Dim p_String4 As String = "không mươi"
        mNumText = Split("không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín", ";")
        mLen = Len(sNumber)
        For i = 1 To mLen
            mDigit = Mid(sNumber, i, 1)

            If Strings.Right(Strings.Trim(mTemp), Len(p_String2)) = p_String2 _
                   And Strings.Right(Strings.Trim(mTemp), Len(p_String3)) <> p_String3 _
                   And Strings.Right(Strings.Trim(mTemp), Len(p_String4)) <> p_String4 And mDigit = "1" Then
                mTemp = mTemp & " " & p_String
            Else
                mTemp = mTemp & " " & mNumText(mDigit)
            End If
            '   mTemp = mTemp & " " & mNumText(mDigit)
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
        '   mTemp = Replace(mTemp, "không mươi ", "linh ")
        mTemp = Replace(mTemp, "không mươi ", "lẻ ")
        'Loại bỏ trường hợp x0, x>=2
        mTemp = Replace(mTemp, "mươi không", "mươi")
        'Fix trường hợp 10
        mTemp = Replace(mTemp, "một mươi", "mười")
        'Fix trường hợp x4, x>=2
        ' mTemp = Replace(mTemp, "mươi bốn", "mươi tư")
        'Fix trường hợp x04
        'mTemp = Replace(mTemp, "linh bốn", "linh tư")
        'Fix trường hợp x5, x>=2
        'mTemp = Replace(mTemp, "mươi năm", "mươi nhăm")
        'Fix trường hợp x1, x>=2
        ' mTemp = Replace(mTemp, "mươi một", "mươi mốt")
        'Fix trường hợp x15
        ' mTemp = Replace(mTemp, "mười năm", "mười lăm")

        mTemp = Replace(mTemp, "mươi năm", "mươi lăm")

        'Bỏ ký tự space
        mTemp = Trim(mTemp)
        'Ucase ký tự đầu tiên
        Return (mTemp.ToUpper.Substring(0, 1) & mTemp.Substring(1, mTemp.Length - 1))

    End Function





    'Public Function Number2Text(ByVal sNumber As String) As String
    '    Dim mLen As Long
    '    Dim i As Long = 0
    '    Dim mDigit As Long
    '    Dim mTemp As String = ""
    '    Dim mNumText() As String

    '    mNumText = Split("không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín", ";")
    '    mLen = Len(sNumber)
    '    For i = 1 To mLen
    '        mDigit = Mid(sNumber, i, 1)
    '        mTemp = mTemp & " " & mNumText(mDigit)
    '        If (mLen = i) Then Exit For
    '        Select Case (mLen - i) Mod 9
    '            Case 0
    '                mTemp = mTemp & " tỷ"
    '                If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
    '                If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
    '                If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
    '            Case 6
    '                mTemp = mTemp & " triệu"
    '                If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
    '                If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
    '            Case 3
    '                mTemp = mTemp & " nghìn"
    '                If Mid(sNumber, i + 1, 3) = "000" Then i = i + 3
    '            Case Else
    '                Select Case (mLen - i) Mod 3
    '                    Case 2
    '                        mTemp = mTemp & " trăm"
    '                    Case 1
    '                        mTemp = mTemp & " mươi"
    '                End Select
    '        End Select
    '    Next
    '    'Loại bỏ trường hợp x00
    '    mTemp = Replace(mTemp, "không mươi không", "")
    '    'Loại bỏ trường hợp 00x
    '    mTemp = Replace(mTemp, "không mươi ", "linh ")
    '    'Loại bỏ trường hợp x0, x>=2
    '    mTemp = Replace(mTemp, "mươi không", "mươi")
    '    'Fix trường hợp 10
    '    mTemp = Replace(mTemp, "một mươi", "mười")
    '    'Fix trường hợp x4, x>=2
    '    mTemp = Replace(mTemp, "mươi bốn", "mươi tư")
    '    'Fix trường hợp x04
    '    mTemp = Replace(mTemp, "linh bốn", "linh tư")
    '    'Fix trường hợp x5, x>=2
    '    mTemp = Replace(mTemp, "mươi năm", "mươi nhăm")
    '    'Fix trường hợp x1, x>=2
    '    mTemp = Replace(mTemp, "mươi một", "mươi mốt")
    '    'Fix trường hợp x15
    '    mTemp = Replace(mTemp, "mười năm", "mười lăm")
    '    'Bỏ ký tự space
    '    mTemp = Trim(mTemp)
    '    'Ucase ký tự đầu tiên
    '    Return (mTemp.ToUpper.Substring(0, 1) & mTemp.Substring(1, mTemp.Length - 1))

    'End Function


End Module
