Imports System.Windows.Forms
Imports System.Reflection
'FPTLISTS
Public Class Class1

    'Public Function ClsSyncDeliveries_SynSpecific(ByVal i_solenh As String, ByRef o_err As String) As Boolean
    '    ClsSyncDeliveries_SynSpecific = mdlSyncDeliveries_SynSpecific(i_solenh, o_err)
    'End Function

    Public Sub clsInBaoCao(ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        InBaoCao(p_datatable, p_ReportCode)
    End Sub


    Public Sub InBaoCaoNew(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)

        Dim p_SQL As String = "select * from tblVCF"

        g_tblVCF = GetDataTable(p_SQL, p_SQL)

        Select Case p_ReportCode
            Case "BM_01_32"
                mdlRptBM_01_32(p_Form, p_datatable, p_ReportCode)
            Case "BM_05_04"
                mdlRptBM_05_04(p_Form, p_datatable, p_ReportCode)
            Case "BM_14_03"
                mdlRptBM_14_03(p_Form, p_datatable, p_ReportCode)
            Case "RptCongTo_Bo"
                mdlRptCongTo_Bo(p_Form, p_datatable, p_ReportCode)
            Case "RptCongTo_Thuy"
                mdlRptCongTo_Thuy(p_Form, p_datatable, p_ReportCode)
            Case "BM_01_26"
                mdlRptBM_01_26(p_Form, p_datatable, p_ReportCode)
            Case "BM_02_03"
                mdlRptBM_02_03(p_Form, p_datatable, p_ReportCode)
            Case "XeBonTH"
                mdlXeBonTH(p_Form, p_datatable, p_ReportCode)
            Case "XaLanTH"
                mdlXaLanTH(p_Form, p_datatable, p_ReportCode)

            Case "TTLX"
                mdlRptTTLenhXuat(p_Form, p_datatable, p_ReportCode)
            Case "TTHX"
                mdlRptTTHongXuat(p_Form, p_datatable, p_ReportCode)
            Case "TTBX"
                mdlRptTTBeXuat(p_Form, p_datatable, p_ReportCode)
            Case "TTHH"
                mdlRptTTHangHoa(p_Form, p_datatable, p_ReportCode)

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

        Dim p_SQL As String

        g_Services = p_Services


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

        p_SQL = "SELECT  MaDonVi ,TenDonVi FROM [tblDonvi] where MaDonVi='" & g_Company_Code & "'"
        g_TableDonvi = GetDataTable(p_SQL, p_SQL)
        If Not g_TableDonvi Is Nothing Then
            If g_TableDonvi.Rows.Count > 0 Then
                g_TenDonVi = g_TableDonvi.Rows(0).Item("TenDonVi")
            End If
        End If

    End Sub


    Public Function clsInMauHoaNghiem(ByVal i_Preview As Boolean, ByVal i_dt_trans As DataTable, ByRef o_err As String) As Boolean
        clsInMauHoaNghiem = InMauHoaNghiem(i_Preview, i_dt_trans, o_err)
    End Function

    Public Function InTichKe(ByRef p_ErrNumber As String, ByRef p_Message As String, _
                                ByVal l_dt_trans As DataTable, _
                                ByVal p_Preview As Boolean, _
                                ByVal p_SoLenh As String, _
                                ByVal p_LenhGhep As Boolean, ByVal p_SoTichKe As String) As Boolean

        Dim l_dt_sub As DataTable
        If mdlTichke_PrintTrans_new(p_Preview, l_dt_trans, l_dt_sub, p_Message) Then
            Return True
        Else
            p_ErrNumber = ""
            'ShowMessageBox(g_err, lblMess)
            Return False
        End If

    End Function

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
            Case "HOADONVCNB_NBN"
                Dim p_FormHDVCNB_NBN As New frmImfor_HoaDonVCNB_NBN(p_SoLenh)
                p_FormHDVCNB_NBN.g_XtraServicesObj = g_Services
                p_FormHDVCNB_NBN.p_XtraModuleObj = g_Module
                p_FormHDVCNB_NBN.Show(p_Form)
            Case "HOADONVCNB_CIF"
                Dim p_FormHDVCNB_CIF As New frmImfor_HoaDonVCNB_CIF(p_SoLenh)
                p_FormHDVCNB_CIF.g_XtraServicesObj = g_Services
                p_FormHDVCNB_CIF.p_XtraModuleObj = g_Module
                p_FormHDVCNB_CIF.Show(p_Form)

            Case "HOADONGIUHO"
                Dim p_FormHDGiuHo As New frmImfor_HoaDonHangGiuHo(p_SoLenh)
                p_FormHDGiuHo.g_XtraServicesObj = g_Services
                p_FormHDGiuHo.p_XtraModuleObj = g_Module
                p_FormHDGiuHo.Show(p_Form)
            Case "LENHXUATKHO"
                If Not Print_LenhXuatKho(False, p_SoLenh, l_err) Then
                    ShowMessageBox("", l_err)
                End If
            Case "LENHXKTHEOPHOI"
                If Not Print_LenhXKTheoPhoi(False, p_SoLenh, l_err) Then
                    ShowMessageBox("", l_err)
                End If
            Case "LENHXUATKHOKDD"
                If Not Print_LENHXUATKHOKDD(False, p_SoLenh, l_err) Then
                    ShowMessageBox("", l_err)
                End If

            Case "TAIXUAT"
                Dim p_FormTaiXuat As New frmImfor_HoaDonTaiXuat(p_SoLenh)
                p_FormTaiXuat.g_XtraServicesObj = g_Services
                p_FormTaiXuat.p_XtraModuleObj = g_Module
                p_FormTaiXuat.Show(p_Form)


            Case UCase("TaiXuatGTGT")
                Dim p_FormTaiXuatEN As New frmImfor_HoaDonTaiXuat_EN(p_SoLenh)
                p_FormTaiXuatEN.g_XtraServicesObj = g_Services
                p_FormTaiXuatEN.GTGT_EN = False
                p_FormTaiXuatEN.p_XtraModuleObj = g_Module
                p_FormTaiXuatEN.Show(p_Form)

            Case UCase("TaiXuatGTGT1")
                Dim p_FormTaiXuatEN1 As New frmImfor_HoaDonTaiXuat_EN(p_SoLenh)
                p_FormTaiXuatEN1.g_XtraServicesObj = g_Services
                p_FormTaiXuatEN1.p_XtraModuleObj = g_Module
                p_FormTaiXuatEN1.GTGT_EN = True
                p_FormTaiXuatEN1.Show(p_Form)
        End Select
    End Sub



    Public Function Print_LenhXuatKho(ByVal i_preview As Boolean, ByVal i_SoLenh As String, ByRef o_err As String) As Boolean
        Dim err As String = String.Empty
        Dim DtSet As New DataSet
        Dim DtTable As New DataTable
        Dim DtTable1 As New DataTable
        Dim DtTable2 As New DataTable
        'Dim rpt As New rptLenhXuatKho
        Dim p_KV1_LenhxuatKho As New KV2_LenhXuatKho
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
                DtTable1.Rows(p_Count).Item("SoLuongThucXuat") = DtTable1.Rows(p_Count).Item("TongXuat")
                ' DtTable1.Rows(p_Count).Item("SoLuongThucXuat") = DtTable1.Rows(p_Count).Item("SoLuongThucXuat")
            Next
            p_KV1_LenhxuatKho.DataSource = DtTable1

            p_KV1_LenhxuatKho.Parameters.Item("NgayXuat").Value = DtTable.Rows(0).Item("NgayXuat")
            p_KV1_LenhxuatKho.Parameters.Item("SoLenh").Value = DtTable.Rows(0).Item("SoLenh")


            p_KV1_LenhxuatKho.Parameters.Item("KhoXuat").Value = DtTable.Rows(0).Item("KhoXuat").ToString
            p_KV1_LenhxuatKho.Parameters.Item("MaNguon").Value = DtTable.Rows(0).Item("MaNguon").ToString
            'p_KV1_LenhxuatKho.Parameters.Item("PhuongThuxXuat").Value = DtTable.Rows(0).Item("PhuongThucXuat").ToString
            p_KV1_LenhxuatKho.Parameters.Item("PhuongThucXuat").Value = DtTable.Rows(0).Item("PhuongThucXuat").ToString

            p_KV1_LenhxuatKho.Parameters.Item("DonViNhanHang").Value = DtTable.Rows(0).Item("DVNhanHang").ToString

            p_KV1_LenhxuatKho.Parameters.Item("PhuongThucVanTai").Value = DtTable.Rows(0).Item("PhuongThucVanTai").ToString

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
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Print_LenhXKTheoPhoi(ByVal i_preview As Boolean, ByVal i_SoLenh As String, ByRef o_err As String) As Boolean
        Dim err As String = String.Empty
        Dim DtSet As New DataSet
        Dim DtTable As New DataTable
        Dim DtTable1 As New DataTable
        Dim DtTable2 As New DataTable
        Dim TongDuXuat As Double
        Dim TongThucXuat As Double
        'Dim rpt As New rptLenhXuatKho
        Dim p_KV1_LenhxuatKho As New KV2_LenhXKTheoPhoi
        Dim p_KV1_LenhxuatKho_Sub As New KV2_LenhXKTheoPhoi_Sub
        'Dim frmView As New frmPrint
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_DataTable As DataTable


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
                'DtTable1.Rows(p_Count).Item("SoLuongThucXuat") = DtTable1.Rows(p_Count).Item("SoLuongThucXuat")
                'TongDuXuat += DtTable1.Rows(p_Count).Item("SoLuongDuXuat")
                'TongThucXuat += DtTable1.Rows(p_Count).Item("SoLuongThucXuat")
                TongDuXuat += IIf(DtTable1.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim = "", 0, DtTable1.Rows(p_Count).Item("SoLuongDuXuat"))
                TongThucXuat += IIf(DtTable1.Rows(p_Count).Item("SoLuongThucXuat").ToString.Trim = "", 0, DtTable1.Rows(p_Count).Item("SoLuongThucXuat"))
            Next
            'p_KV1_LenhxuatKho.DataSource = DtTable1
            p_KV1_LenhxuatKho_Sub.DataSource = DtTable1
            p_KV1_LenhxuatKho.XrSubreport1.ReportSource = p_KV1_LenhxuatKho_Sub

            'p_KV1_LenhxuatKho.Parameters.Item("NgayXuat").Value = DtTable.Rows(0).Item("NgayXuat")
            p_KV1_LenhxuatKho.Parameters.Item("FDay").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "dd")
            p_KV1_LenhxuatKho.Parameters.Item("FMonth").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "MM")
            p_KV1_LenhxuatKho.Parameters.Item("FYear").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "yyyy")
            If DtTable.Rows(0).Item("NgayHetHieuLuc").ToString.Trim <> "00000000" And DtTable.Rows(0).Item("NgayHetHieuLuc").ToString.Trim <> "" Then
                p_KV1_LenhxuatKho.Parameters.Item("TDay").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "dd")
                p_KV1_LenhxuatKho.Parameters.Item("TMonth").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "MM")
                p_KV1_LenhxuatKho.Parameters.Item("TYear").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "yyyy")
            End If

            'p_KV1_LenhxuatKho.Parameters.Item("FDay").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("FMonth").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("FYear").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TDay").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TMonth").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TYear").Visible = False

            p_KV1_LenhxuatKho.Parameters.Item("SoLenh").Value = DtTable.Rows(0).Item("SoLenh")

            p_KV1_LenhxuatKho.Parameters.Item("STO").Value = DtTable.Rows(0).Item("STO")
            p_KV1_LenhxuatKho.Parameters.Item("NguoiDaiDien").Value = DtTable.Rows(0).Item("NguoiDaiDien")
            p_KV1_LenhxuatKho.Parameters.Item("DonViCungCapVanTai").Value = DtTable.Rows(0).Item("DonViCungCapVanTai")
            p_KV1_LenhxuatKho.Parameters.Item("KhoXuat").Value = DtTable.Rows(0).Item("KhoXuat").ToString
            p_KV1_LenhxuatKho.Parameters.Item("MaNguon").Value = DtTable.Rows(0).Item("MaNguon").ToString
            p_KV1_LenhxuatKho.Parameters.Item("PhuongThucXuat").Value = DtTable.Rows(0).Item("PhuongThucXuat").ToString
            'p_KV1_LenhxuatKho.Parameters.Item("p_GhiChu").Value = "Anh hùng bàn phím ahihi" 'hieptd4 add for test
            'p_KV1_LenhxuatKho.Parameters.Item("p_NguoiLap").Value = g_UserName
            p_SQL = "select top 1 DESCRIPTION from SYS_USER with (Nolock) where USER_NAME='" & g_UserName & "'"
            p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_KV1_LenhxuatKho.Parameters.Item("p_NguoiLap").Value = p_DataTable.Rows(0).Item(0).ToString
                End If
            End If

            p_KV1_LenhxuatKho.Parameters.Item("DonViNhanHang").Value = DtTable.Rows(0).Item("DVNhanHang").ToString

            p_KV1_LenhxuatKho.Parameters.Item("PhuongThucVanTai").Value = DtTable.Rows(0).Item("PhuongThucVanTai").ToString

            p_KV1_LenhxuatKho.Parameters.Item("MaPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            p_KV1_LenhxuatKho.Parameters.Item("NguoiVanChuyen").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString()
            If DtTable2.Rows.Count > 0 Then
                'p_KV1_LenhxuatKho.Parameters.Item("Congty").Value = DtTable2.Rows(0).Item("TenDonVi").ToString()
            End If
            p_KV1_LenhxuatKho.Parameters.Item("p_TongDuXuat").Value = TongDuXuat
            p_KV1_LenhxuatKho.Parameters.Item("p_TongThucXuat").Value = TongThucXuat

            p_KV1_LenhxuatKho.RequestParameters = False
            p_KV1_LenhxuatKho.PrinterName = g_DefaultPrint
            If i_preview Then
                p_KV1_LenhxuatKho.Print()
            Else

                '  p_KV1_LenhxuatKho.sh()
                p_KV1_LenhxuatKho.ShowPreviewDialog()
            End If

            Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try
    End Function

    Public Function Print_LENHXUATKHOKDD(ByVal i_preview As Boolean, ByVal i_SoLenh As String, ByRef o_err As String) As Boolean
        Dim err As String = String.Empty
        Dim DtSet As New DataSet
        Dim DtTable As New DataTable
        Dim DtTable1 As New DataTable
        Dim DtTable2 As New DataTable
        'Dim rpt As New rptLenhXuatKho
        Dim p_KV1_LenhxuatKho As New KV2_LenhXuatKhoKDD
        Dim p_KV1_LenhxuatKho_Sub As New KV2_LenhXuatKhoKDD_Sub
        'Dim frmView As New frmPrint
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim TongDuXuat As Double
        Dim TongThucXuat As Double
        Dim p_DataTable As DataTable

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
                'DtTable1.Rows(p_Count).Item("SoLuongThucXuat") = DtTable1.Rows(p_Count).Item("SoLuongThucXuat")
                TongDuXuat += IIf(DtTable1.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim = "", 0, DtTable1.Rows(p_Count).Item("SoLuongDuXuat"))
                TongThucXuat += IIf(DtTable1.Rows(p_Count).Item("SoLuongThucXuat").ToString.Trim = "", 0, DtTable1.Rows(p_Count).Item("SoLuongThucXuat"))
            Next
            'p_KV1_LenhxuatKho.DataSource = DtTable1
            p_KV1_LenhxuatKho_Sub.DataSource = DtTable1
            p_KV1_LenhxuatKho.XrSubreport1.ReportSource = p_KV1_LenhxuatKho_Sub


            'p_KV1_LenhxuatKho.Parameters.Item("NgayXuat").Value = DtTable.Rows(0).Item("NgayXuat")
            p_KV1_LenhxuatKho.Parameters.Item("FDay").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "dd")
            p_KV1_LenhxuatKho.Parameters.Item("FMonth").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "MM")
            p_KV1_LenhxuatKho.Parameters.Item("FYear").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "yyyy")
            If DtTable.Rows(0).Item("NgayHetHieuLuc").ToString.Trim <> "00000000" And DtTable.Rows(0).Item("NgayHetHieuLuc").ToString.Trim <> "" Then
                p_KV1_LenhxuatKho.Parameters.Item("TDay").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "dd")
                p_KV1_LenhxuatKho.Parameters.Item("TMonth").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "MM")
                p_KV1_LenhxuatKho.Parameters.Item("TYear").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "yyyy")
            End If

            'p_KV1_LenhxuatKho.Parameters.Item("FDay").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("FMonth").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("FYear").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TDay").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TMonth").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TYear").Visible = False

            p_KV1_LenhxuatKho.Parameters.Item("SoLenh").Value = DtTable.Rows(0).Item("SoLenh")

            p_KV1_LenhxuatKho.Parameters.Item("STO").Value = DtTable.Rows(0).Item("STO")
            p_KV1_LenhxuatKho.Parameters.Item("NguoiDaiDien").Value = DtTable.Rows(0).Item("NguoiDaiDien")
            p_KV1_LenhxuatKho.Parameters.Item("DonViCungCapVanTai").Value = DtTable.Rows(0).Item("DonViCungCapVanTai")
            p_KV1_LenhxuatKho.Parameters.Item("KhoXuat").Value = DtTable.Rows(0).Item("KhoXuat").ToString
            'p_KV1_LenhxuatKho.Parameters.Item("KhoNhap").Value = "Kho 100 hieptd4" 'hieptd4 add for test
            'p_KV1_LenhxuatKho.Parameters.Item("p_GhiChu").Value = "Anh hùng bàn phím ahihi" 'hieptd4 add for test
            'p_KV1_LenhxuatKho.Parameters.Item("p_NguoiLap").Value = g_UserName
            p_SQL = "select top 1 DESCRIPTION from SYS_USER with (Nolock) where USER_NAME='" & g_UserName & "'"
            p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_KV1_LenhxuatKho.Parameters.Item("p_NguoiLap").Value = p_DataTable.Rows(0).Item(0).ToString
                End If
            End If
            p_KV1_LenhxuatKho.Parameters.Item("MaNguon").Value = DtTable.Rows(0).Item("MaNguon").ToString
            p_KV1_LenhxuatKho.Parameters.Item("PhuongThucXuat").Value = DtTable.Rows(0).Item("PhuongThucXuat").ToString

            p_KV1_LenhxuatKho.Parameters.Item("DonViNhanHang").Value = DtTable.Rows(0).Item("DVNhanHang").ToString

            p_KV1_LenhxuatKho.Parameters.Item("PhuongThucVanTai").Value = DtTable.Rows(0).Item("PhuongThucVanTai").ToString
            p_KV1_LenhxuatKho.Parameters.Item("SoChuyenVanTai").Value = DtTable.Rows(0).Item("SoChuyenVanTai").ToString
            p_KV1_LenhxuatKho.Parameters.Item("MaPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            p_KV1_LenhxuatKho.Parameters.Item("NguoiVanChuyen").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString()
            If DtTable2.Rows.Count > 0 Then
                'p_KV1_LenhxuatKho.Parameters.Item("Congty").Value = DtTable2.Rows(0).Item("TenDonVi").ToString()
            End If
            p_KV1_LenhxuatKho.Parameters.Item("p_TongDuXuat").Value = TongDuXuat
            p_KV1_LenhxuatKho.Parameters.Item("p_TongThucXuat").Value = TongThucXuat

            p_KV1_LenhxuatKho.RequestParameters = False
            p_KV1_LenhxuatKho.PrinterName = g_DefaultPrint
            If i_preview Then
                p_KV1_LenhxuatKho.Print()
            Else

                '  p_KV1_LenhxuatKho.sh()
                p_KV1_LenhxuatKho.ShowPreviewDialog()
            End If

            Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try
    End Function

End Class
