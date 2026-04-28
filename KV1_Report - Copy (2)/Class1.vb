Imports System.Windows.Forms
Imports System.Reflection

'Imports IDAutomation.Windows.Forms.PDF417Barcode
'FPTLISTS
Public Class Class1

    'Public Function ClsSyncDeliveries_SynSpecific(ByVal i_solenh As String, ByRef o_err As String) As Boolean
    '    ClsSyncDeliveries_SynSpecific = mdlSyncDeliveries_SynSpecific(i_solenh, o_err)
    'End Function


    Public Sub InBaoCaoNew(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)

        Dim p_SQL As String = "select * from tblVCF"

        g_tblVCF = GetDataTable(p_SQL, p_SQL)

        Select Case p_ReportCode
            Case "BM_01_32"
                mdlRptBM_01_32(p_Form, p_datatable, p_ReportCode)

            Case "BM_05_04"
                mdlRptBM_05_04(p_Form, p_datatable, p_ReportCode)

                'Case "BM_14_03"
                '    mdlRptBM_14_03(p_Form, p_datatable, p_ReportCode)

                'Case "RptCongTo_Bo"
                '    mdlRptCongTo_Bo(p_Form, p_datatable, p_ReportCode)

                'Case "RptCongTo_Thuy"
                '    mdlRptCongTo_Thuy(p_Form, p_datatable, p_ReportCode)

            Case "BM_01_26"
                mdlRptBM_01_26(p_Form, p_datatable, p_ReportCode)
                'Case "BM_02_03"
                '    mdlRptBM_02_03(p_Form, p_datatable, p_ReportCode)

            Case "XeBonTH"
                mdlXeBonTH(p_Form, p_datatable, p_ReportCode)
                'Case "XaLanTH"
                '    mdlXaLanTH(p_Form, p_datatable, p_ReportCode)

            Case "TTLX"
                mdlRptTTLenhXuat(p_Form, p_datatable, p_ReportCode)

            Case "TTHX"
                mdlRptTTHongXuat(p_Form, p_datatable, p_ReportCode)

            Case "TTBX"
                mdlRptTTBeXuat(p_Form, p_datatable, p_ReportCode)

            Case "TTHH"
                mdlRptTTHangHoa(p_Form, p_datatable, p_ReportCode)
            Case "KSTT"
                mdlRptBM_KSTT(p_Form, p_datatable, p_ReportCode)
            Case Else

        End Select


    End Sub

    Public Sub clsInBaoCaoNew(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String,
        ByVal p_SYS_CONFIG_RPT_PARA As DataTable, _
        ByVal p_SYS_CONFIG_RPT As DataTable, _
            ByVal p_SYS_CONFIG_RPT_FIELD As DataTable)

        g_SYS_CONFIG_RPT_PARA = p_SYS_CONFIG_RPT_PARA
        g_SYS_CONFIG_RPT = p_SYS_CONFIG_RPT
        Dim g_SYS_CONFIG_RPT_FIELD = p_SYS_CONFIG_RPT_FIELD

        InBaoCaoNew(p_Form, p_datatable, p_ReportCode)
    End Sub


    Private Function mdlConfig_GetConfigFromXML() As Boolean
        ' Dim p_PathXML As String
        Dim p_DataSet As New DataSet


        Try

            If Dir(g_PathXML) <> "" Then
                p_DataSet.ReadXml(g_PathXML)
                If Not p_DataSet Is Nothing Then
                    If p_DataSet.Tables.Count > 0 Then
                        g_Config_XMLDatatable = p_DataSet.Tables(0)
                        Try
                            'If g_Config_XMLDatatable.Rows(0).Item("CLIENT").ToString.Trim <> "" Then
                            '    Me.Label1.Visible = True
                            '    Me.TxtMaKho.Text = g_Config_XMLDatatable.Rows(0).Item("CLIENT").ToString.Trim
                            '    Me.TxtMaKho.Visible = True
                            'End If
                            If g_Config_XMLDatatable.Rows(0).Item("PRINTER").ToString.Trim <> "" Then
                                g_DefaultPrint = g_Config_XMLDatatable.Rows(0).Item("PRINTER").ToString.Trim
                            Else
                                g_DefaultPrint = ""
                            End If
                            If g_Config_XMLDatatable.Rows(0).Item("PRINTERVAT").ToString.Trim <> "" Then
                                g_DefaultPrintVAT = g_Config_XMLDatatable.Rows(0).Item("PRINTERVAT").ToString.Trim
                            Else
                                g_DefaultPrintVAT = ""
                            End If
                        Catch ex As Exception

                        End Try
                        ' g_Config_XMLDatatable.WriteXml(p_PathXML)
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
                '
            Else
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Sub New(ByVal p_Config_XMLDatatable As DataTable, ByVal p_Company_Code As String, ByVal p_WareHouse As String, ByVal p_Services As Object, ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                   Optional ByVal p_Company_Host As String = "", _
                    Optional ByVal p_Company_DB_Name As String = "", Optional ByVal p_UserName As String = "", _
                    Optional ByVal p_LicenceHost As String = "", Optional ByVal p_DBUser As String = "", _
                    Optional ByVal p_DBPass As String = "", Optional ByVal p_CompanyAPI As Object = Nothing)
        Dim p_DataRow() As DataRow
        g_Services = p_Services

        Dim p_SQL As String

        p_SQL = "select * from tblVCF"
        g_tblVCF = GetDataTable(p_SQL, p_SQL)

        Try
            g_Config_XMLDatatable = p_Config_XMLDatatable
            g_Terminal = g_Config_XMLDatatable.Rows(0).Item("CLIENT").ToString.Trim
        Catch ex As Exception

        End Try

        Dim p_FptMod As New FPTModule.Class1(g_UserName, g_Company_Code, p_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName)
        g_Module = p_FptMod
        g_Company_Host = p_Company_Host
        g_GetHostName = p_Company_DB_Name
        g_Company_DBName = p_Company_DB_Name
        g_Services = p_Services



        g_UserName = p_UserName
        g_CompanyAPI = p_CompanyAPI


        g_UsrB1 = p_UsrB1
        g_PassB1 = p_PassB1
        g_Port = p_Port
        g_Company_Code = p_Company_Code
        g_WareHouse = p_WareHouse
        g_UserName = p_UserName
        g_LicenceHost = p_LicenceHost

        g_DBUser = p_DBUser
        g_DBPass = p_DBPass

        mdlConfig_GetConfigFromXML()

        p_SQL = "select * from tblHangHoaE5 "
        g_HangHoaToScada2 = GetDataTable(p_SQL, p_SQL)

        p_SQL = "select * from tblPara "
        g_dt_para = GetDataTable(p_SQL, p_SQL)

        p_SQL = "select * from SYS_CONFIG "
        g_SySConfig = GetDataTable(p_SQL, p_SQL)

        If Not g_SySConfig Is Nothing Then
            p_DataRow = g_SySConfig.Select("KEYCODE='HD_NOIDUNG1'")
            If p_DataRow.Length > 0 Then
                ' If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                g_HOADON1 = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                'End If
            End If

        End If

        If Not g_SySConfig Is Nothing Then
            p_DataRow = g_SySConfig.Select("KEYCODE='HD_NOIDUNG2'")
            If p_DataRow.Length > 0 Then
                ' If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                g_HOADON2 = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                'End If
            End If

        End If


        p_SQL = "SELECT  MaDonVi ,TenDonVi FROM [tblDonvi] where MaDonVi='" & g_Company_Code & "'"
        g_TableDonvi = GetDataTable(p_SQL, p_SQL)
        If Not g_TableDonvi Is Nothing Then
            If g_TableDonvi.Rows.Count > 0 Then
                g_TenDonVi = g_TableDonvi.Rows(0).Item("TenDonVi")
            End If
        End If
    End Sub


    Public Function InTichKe(ByRef p_ErrNumber As String, ByRef p_Message As String, _
                                ByVal l_dt_trans As DataTable, _
                                ByVal p_Preview As Boolean, _
                                ByVal p_SoLenh As String, _
                                ByVal p_LenhGhep As Boolean, ByVal p_SoTichKe As String) As Boolean

        Dim l_dt_sub As DataTable

        'Dim l_pdf1 As PDF417Lib.PDF



        Dim l_barcode As String
        Dim l_makho As String
        Dim p_Count As Integer
        Dim l_tableid As String
        Dim l_ngayxuat As String
        Dim p_Date As Date

        '  Dim NewBarcode As PDF417Barcode '= New PDF417Barcode()

        'Dim l_pdf As PDF417Lib.PDF
        '' Dim l_barcode As String
        '' l_pdf = CreateObject("PDF417Lib")
        'l_pdf = New PDF417Lib.PDF()

        For p_Count = 0 To l_dt_trans.Rows.Count - 1
            'l_pdf = CreateObject("PDF417Lib")
            ' NewBarcode = New PDF417Barcode

           
            ' l_pdf1 = New PDF417Lib.PDF


            l_makho = String.Empty
            l_barcode = String.Empty
            p_Date = l_dt_trans.Rows(p_Count).Item("NgayXuat")
            l_ngayxuat = p_Date.ToString("dd") & "/" & p_Date.ToString("MM") & "/" & p_Date.ToString("yyyy")
            l_tableid = l_dt_trans.Rows(p_Count).Item("TableID").ToString.Trim
            l_barcode = l_tableid & ":" & _
                        l_ngayxuat.Substring(0, 2) & _
                        l_ngayxuat.Substring(3, 2) & _
                        l_ngayxuat.Substring(6, 4)
           
            ' l_makho = g_Services.BuildBarcode147(l_barcode)
          
            l_dt_trans.Rows(p_Count).Item("MaKho") = l_barcode

            ' l_dt_trans.Rows(p_Count).Item("SoLuongThucXuat") = l_dt_trans.Rows(p_Count).Item("SoLuongDuXuat")

            'l_pdf1.FontEncode(l_barcode, 0, 0, 0, 0, 0, 0, l_makho)
            'l_makho = NewBarcode.FontEncoder(l_barcode.ToString, 0, 0, 0, False, PDF417Barcode.PDF417Modes.Text, True)
        Next
        ' MsgBox("cccccc")

        If mdlTichke_PrintTrans_new(p_Preview, l_dt_trans, l_dt_sub, p_Message) Then
            Return True
        Else
            p_ErrNumber = ""
            'ShowMessageBox(g_err, lblMess)
            Return False
        End If

    End Function

    'Public Function BuildBarcode147(ByVal p_String As String) As String
    '    Try
    '        Dim l_pdf As PDF417Lib.PDF
    '        BuildBarcode147 = p_String
    '        If p_String = "" Then
    '            Exit Function
    '        End If
    '        l_pdf = New PDF417Lib.PDF()
    '        l_pdf.FontEncode(p_String, 0, 0, 0, 0, 0, 0, BuildBarcode147)
    '    Catch ex As Exception
    '        BuildBarcode147 = p_String
    '    End Try

    'End Function

    Private Function Azalea_Code_128_A(ByVal yourData As String) As String
        ' C128Tools 29may12 jwhiting
        ' Copyright 2012 Azalea Software, Inc. All rights reserved. www.azalea.com

        ' Creating a Code 128 code set A barcode using C128Tools.
        ' Your input, yourData, is a string to be encoded as a Code 128 code set A symbol.
        ' yourData must be the Code 128 code set A character set. Input error checking is your responsibility.

        Dim temp As String                 ' a temporary placeholder
        Dim chunk As String                ' loop chunk
        Dim i As Integer                   ' our loop counter
        Dim checkDigitSubtotal As Integer  ' a check digit throwaway
        Dim e As Integer                   ' a placeholder variable

        ' seed the variables
        temp = Chr(181)                   ' code set A start glyph
        checkDigitSubtotal = 103                ' code set A start checkdigit value

        ' map the input string into the C128Tools character set
        For i = 1 To Len(yourData) Step 1
            chunk = Mid(yourData, i, 1)
            Select Case Asc(chunk)
                ' map from above ASCII 182 placeholders to the font's character assignments
                Case Is > 95
                    temp = temp & Chr(Asc(chunk) - 66)
                Case Is = 32 ' move the space character
                    temp = temp & Chr(206)
                Case Else
                    temp = temp & chunk
            End Select
        Next i

        ' Calculate the Code 128 mod 103 check digit
        For i = 1 To Len(yourData)
            e = Asc(Mid(yourData, i, 1)) - 32
            If e <> 142 Then
                checkDigitSubtotal = checkDigitSubtotal + (e * i)
            End If
        Next i
        checkDigitSubtotal = checkDigitSubtotal Mod 103

        ' Put together the final output string
        ' code set A start bar, the encoded string, check digit, stop bar
        Select Case checkDigitSubtotal
            Case 0
                Azalea_Code_128_A = temp & Chr(206) & Chr(196)
            Case 1 To 93
                Azalea_Code_128_A = temp & Chr(checkDigitSubtotal + 32) & Chr(196)
            Case Is > 93
                Azalea_Code_128_A = temp & Chr(checkDigitSubtotal + 103) & Chr(196)
        End Select

    End Function


    Public Function code128(ByVal Values As String) As String
        'This function is governed by the GNU Lesser General Public License (GNU LGPL)
        'V 2.0.0
        'Parameters : a string
        'Return : * a string which give the bar code when it is dispayed with CODE128.TTF font
        '         * an empty string if the supplied parameter is no good
        Dim i, checksum, mini, dummy As Integer

        Dim tableB As Boolean
        code128 = ""
        If Len(Values) > 0 Then
            'Check for valid characters
            For i = 1 To Len(Values)
                Select Case Asc(Mid$(Values, i, 1))
                    Case 32 To 126, 203
                    Case Else
                        i = 0
                        Exit For
                End Select
            Next
            'Calculation of the code string with optimized use of tables B and C
            code128 = ""
            tableB = True
            If i > 0 Then
                i = 1 'i% devient l'index sur la chaine / i% become the string index
                Do While i <= Len(Values)
                    If tableB Then
                        'See if interesting to switch to table C
                        'yes for 4 digits at start or end, else if 6 digits
                        mini = IIf(i = 1 Or i + 3 = Len(Values), 4, 6)
                        'GoTo testnum
                        SubMini(mini, i, Values)
                        If mini < 0 Then 'Choice of table C
                            If i = 1 Then 'Starting with table C
                                code128 = Chr(205)
                            Else 'Switch to table C
                                code128 = code128 & Chr(199)
                            End If
                            tableB = False
                        Else
                            If i = 1 Then code128 = Chr(204) 'Starting with table B
                        End If
                    End If
                    If Not tableB Then
                        'We are on table C, try to process 2 digits
                        mini = 2
                        'GoTo testnum
                        SubMini(mini, i, Values)
                        If mini < 0 Then 'OK for 2 digits, process it
                            dummy = Val(Mid$(Values, i, 2))
                            dummy = IIf(dummy < 95, dummy + 32, dummy + 100)
                            code128 = code128 & Chr(dummy)
                            i = i + 2
                        Else 'We haven't 2 digits, switch to table B
                            code128 = code128 & Chr(200)
                            tableB = True
                        End If
                    End If
                    If tableB Then
                        'Process 1 digit with table B
                        code128 = code128 & Mid$(Values, i, 1)
                        i = i + 1
                    End If
                Loop
                'Calculation of the checksum
                For i = 1 To Len(code128)
                    dummy = Asc(Mid$(code128, i, 1))
                    dummy = IIf(dummy < 127, dummy - 32, dummy - 100)
                    If i = 1 Then checksum = dummy
                    checksum = (checksum + (i - 1) * dummy) Mod 103
                Next
                'Calculation of the checksum ASCII code
                checksum = IIf(checksum < 95, checksum + 32, checksum + 100)
                'Add the checksum and the STOP
                code128 = code128 & Chr(checksum) & Chr(206)
            End If
        End If
        Exit Function
        'testnum:
        '        'if the mini% characters from i% are numeric, then mini%=0
        '        mini = mini - 1
        '        If i + mini <= Len(Values) Then
        '            Do While mini >= 0
        '                If Asc(Mid$(Values, i + mini, 1)) < 48 Or Asc(Mid(Values, i + mini, 1)) > 57 Then Exit Do
        '                mini = mini - 1
        '            Loop
        '        End If
        '  Return
    End Function

    Sub SubMini(ByRef p_mini As Integer, ByRef p_i As Integer, ByVal p_String As String)
        p_mini = p_mini - 1
        If p_i + p_mini <= Len(p_String) Then
            Do While p_mini >= 0
                If Asc(Mid$(p_String, p_i + p_mini, 1)) < 48 Or Asc(Mid(p_String, p_i + p_mini, 1)) > 57 Then Exit Do
                p_mini = p_mini - 1
            Loop
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Public Sub InChungTuHoaDon(ByVal p_Form As Object, ByVal p_Type As String, ByVal p_SoLenh As String)
        Dim l_err As String
        Select Case p_Type
            Case "HOADON"
                Dim p_FormHD As New frmImfor_HoaDon(p_SoLenh)
                p_FormHD.g_XtraServicesObj = g_Services
                p_FormHD.p_XtraModuleObj = g_Module
                p_FormHD.Show(p_Form)
            Case "HOADONVCNB"
                Dim p_FormHDVCNB As New frmImfor_HoaDonVCNB(p_SoLenh)
                p_FormHDVCNB.g_XtraServicesObj = g_Services
                p_FormHDVCNB.p_XtraModuleObj = g_Module
                p_FormHDVCNB.Show(p_Form)

            Case "HOADONGIUHO"
                Dim p_FormHDGiuHo As New frmImfor_HoaDonHangGiuHo(p_SoLenh)
                p_FormHDGiuHo.g_XtraServicesObj = g_Services
                p_FormHDGiuHo.p_XtraModuleObj = g_Module
                p_FormHDGiuHo.Show(p_Form)
            Case "LENHXUATKHO"

                If Not Print_LenhXuatKho(False, p_SoLenh, l_err) Then
                    ShowMessageBox("", l_err)
                End If
        End Select
    End Sub



    Private Function Print_LenhXuatKho(ByVal i_preview As Boolean, ByVal i_SoLenh As String, ByRef o_err As String) As Boolean
        Dim err As String = String.Empty
        Dim DtSet As New DataSet
        Dim DtTable As New DataTable
        Dim DtTable1 As New DataTable
        Dim DtTable2 As New DataTable
        'Dim rpt As New rptLenhXuatKho
        Dim p_KV1_LenhxuatKho As New KV1_LenhXuatKho
        'Dim frmView As New frmPrint
        Dim p_SQL As String
        Dim p_Count As Integer
        Try
            p_SQL = "FPT_reports_LenhXuatKhoE5 '" & i_SoLenh & "'"
            DtSet = GetDataSet(p_SQL, err)
            ' DtSet = l_bs_reports.Select_LenhXuatKho(_SQLConnectionString, err, i_SoLenh)
            If DtSet Is Nothing Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If

            If DtSet.Tables.Count < 2 Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If

            DtTable = DtSet.Tables(0)
            If DtTable.Rows.Count <= 0 Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If

          


            DtTable1 = DtSet.Tables(1)
            DtTable2 = DtSet.Tables(2)

            For p_Count = 0 To DtTable1.Rows.Count - 1
                DtTable1.Rows(p_Count).Item("SoLuongThucXuat") = DtTable1.Rows(p_Count).Item("TongThucXuat")
            Next
            p_KV1_LenhxuatKho.DataSource = DtTable1

            p_KV1_LenhxuatKho.Parameters.Item("NgayXuat").Value = DtTable.Rows(0).Item("NgayXuat")
            p_KV1_LenhxuatKho.Parameters.Item("SoLenh").Value = DtTable.Rows(0).Item("SoLenh")


            p_KV1_LenhxuatKho.Parameters.Item("KhoXuat").Value = DtTable.Rows(0).Item("KhoXuat").ToString
            p_KV1_LenhxuatKho.Parameters.Item("MaNguon").Value = DtTable.Rows(0).Item("MaNguon").ToString
            p_KV1_LenhxuatKho.Parameters.Item("PhuongThuxXuat").Value = DtTable.Rows(0).Item("PhuongThucXuat").ToString

            p_KV1_LenhxuatKho.Parameters.Item("DonViNhanHang").Value = DtTable.Rows(0).Item("DVNhanHang").ToString


            p_KV1_LenhxuatKho.Parameters.Item("MaPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            p_KV1_LenhxuatKho.Parameters.Item("NguoiVanChuyen").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString()
            If DtTable2.Rows.Count > 0 Then
                p_KV1_LenhxuatKho.Parameters.Item("Congty").Value = DtTable2.Rows(0).Item("TenDonVi").ToString()
            End If

            p_KV1_LenhxuatKho.RequestParameters = False
            p_KV1_LenhxuatKho.PrinterName = g_DefaultPrint
            If i_preview Then
                p_KV1_LenhxuatKho.Print()
            Else

                '  p_KV1_LenhxuatKho.sh()
                p_KV1_LenhxuatKho.ShowPreviewDialog()
            End If


            Return True


            'rpt.SetDataSource(DtTable1)

            'If Not i_preview Then
            '    If DtTable.Rows(0).Item("NgayHieuLuc").ToString = "" Then
            '        DtTable.Rows(0).Item("NgayHieuLuc") = DtTable.Rows(0).Item("NgayXuat")
            '    End If
            '    rpt.SetParameterValue("P_SoLenh", DtTable.Rows(0).Item("SoLenh").ToString())
            '    rpt.SetParameterValue("P_TuNgay", Format(DtTable.Rows(0).Item("NgayXuat"), "dd/MM/yyyy"))
            '    rpt.SetParameterValue("P_DenNgay", DtTable.Rows(0).Item("NgayHieuLuc").ToString().Substring(6, 2) & "/" & _
            '                                       DtTable.Rows(0).Item("NgayHieuLuc").ToString().Substring(4, 2) & "/" & _
            '                                       DtTable.Rows(0).Item("NgayHieuLuc").ToString().Substring(0, 4))

            '    rpt.SetParameterValue("P_KhoXuat", DtTable.Rows(0).Item("KhoXuat").ToString)
            '    rpt.SetParameterValue("P_MaNguon", DtTable.Rows(0).Item("MaNguon").ToString)
            '    rpt.SetParameterValue("P_PhuongThucXuat", DtTable.Rows(0).Item("PhuongThucXuat").ToString)
            '    rpt.SetParameterValue("P_DVNhanHang", DtTable.Rows(0).Item("DVNhanHang").ToString)
            '    rpt.SetParameterValue("P_KhoXuat", DtTable.Rows(0).Item("KhoXuat").ToString)
            '    rpt.SetParameterValue("P_MaPhuongTien", DtTable.Rows(0).Item("MaPhuongTien").ToString)
            '    rpt.SetParameterValue("P_NguoiVanChuyen", DtTable.Rows(0).Item("NguoiVanChuyen").ToString())
            '    frmView.crViewer.ReportSource = rpt
            '    frmView.ShowDialog()

            'Else
            '    If DtTable.Rows(0).Item("NgayHieuLuc").ToString = "" Then
            '        DtTable.Rows(0).Item("NgayHieuLuc") = DtTable.Rows(0).Item("NgayXuat")
            '    End If
            '    rpt.SetParameterValue("P_SoLenh", DtTable.Rows(0).Item("SoLenh").ToString())
            '    rpt.SetParameterValue("P_TuNgay", Format(DtTable.Rows(0).Item("NgayXuat"), "dd/MM/yyyy"))
            '    rpt.SetParameterValue("P_DenNgay", DtTable.Rows(0).Item("NgayHieuLuc").ToString().Substring(6, 2) & "/" & _
            '                                       DtTable.Rows(0).Item("NgayHieuLuc").ToString().Substring(4, 2) & "/" & _
            '                                       DtTable.Rows(0).Item("NgayHieuLuc").ToString().Substring(0, 4))

            '    rpt.SetParameterValue("P_KhoXuat", DtTable.Rows(0).Item("KhoXuat").ToString)
            '    rpt.SetParameterValue("P_MaNguon", DtTable.Rows(0).Item("MaNguon").ToString)
            '    rpt.SetParameterValue("P_PhuongThucXuat", DtTable.Rows(0).Item("PhuongThucXuat").ToString)
            '    rpt.SetParameterValue("P_DVNhanHang", DtTable.Rows(0).Item("DVNhanHang").ToString)
            '    rpt.SetParameterValue("P_KhoXuat", DtTable.Rows(0).Item("KhoXuat").ToString)
            '    rpt.SetParameterValue("P_MaPhuongTien", DtTable.Rows(0).Item("MaPhuongTien").ToString)
            '    rpt.SetParameterValue("P_NguoiVanChuyen", DtTable.Rows(0).Item("NguoiVanChuyen").ToString())
            '    rpt.PrintOptions.PrinterName = g_DefaultPrint
            '    rpt.PrintToPrinter(1, False, 0, 0)
            'End If

            ''  o_err = "m028"
            'Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try
    End Function


End Class
