Imports System.Windows.Forms
Imports System.Reflection
'FPTLISTS
Public Class Class1

    Public Function ClsSyncDeliveries_SynSpecific(ByVal i_solenh As String, ByRef o_err As String) As Boolean
        ClsSyncDeliveries_SynSpecific = mdlSyncDeliveries_SynSpecific(i_solenh, o_err)
    End Function

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

    End Sub


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

            Case "HOADONGIUHO"
                Dim p_FormHDGiuHo As New frmImfor_HoaDonHangGiuHo(p_SoLenh)
                p_FormHDGiuHo.g_XtraServicesObj = g_Services
                p_FormHDGiuHo.p_XtraModuleObj = g_Module
                p_FormHDGiuHo.Show(p_Form)
            Case "LENHXUATKHO"
                If Not Print_LenhXuatKho(False, p_SoLenh, l_err) Then
                    ShowMessageBox("", l_err)
                End If
                'Case "TAIXUAT"
                '    Dim p_FormTaiXuat As New frmImfor_HoaDonTaiXuat(p_SoLenh)
                '    p_FormTaiXuat.g_XtraServicesObj = g_Services
                '    p_FormTaiXuat.p_XtraModuleObj = g_Module
                '    p_FormTaiXuat.Show(p_Form)
        End Select
    End Sub



    Public Function Print_LenhXuatKho(ByVal i_preview As Boolean, ByVal i_SoLenh As String, ByRef o_err As String) As Boolean
        Dim err As String = String.Empty
        Dim DtSet As New DataSet
        Dim DtTable As New DataTable
        Dim DtTable1 As New DataTable
        Dim rpt As New rptLenhXuatKho
        Dim frmView As New frmPrint
        Dim p_SQL As String
        Try
            'DtSet = l_bs_reports.Select_LenhXuatKho(_SQLConnectionString, err, i_SoLenh)
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

            DtTable = DtSet.Tables(0)
            If DtTable.Rows.Count <= 0 Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If

            DtTable1 = DtSet.Tables(1)

            For p_Count = 0 To DtTable1.Rows.Count - 1

                DtTable1.Rows(p_Count).Item("SoLuongThucXuat") = DtTable1.Rows(p_Count).Item("SoLuongDuXuat")
            Next


            rpt.SetDataSource(DtTable1)

            If Not i_preview Then
                If DtTable.Rows(0).Item("NgayHieuLuc").ToString = "" Then
                    DtTable.Rows(0).Item("NgayHieuLuc") = DtTable.Rows(0).Item("NgayXuat")
                End If
                rpt.SetParameterValue("P_SoLenh", DtTable.Rows(0).Item("SoLenh").ToString())
                rpt.SetParameterValue("P_TuNgay", Format(DtTable.Rows(0).Item("NgayXuat"), "dd/MM/yyyy"))
                rpt.SetParameterValue("P_DenNgay", DtTable.Rows(0).Item("NgayHieuLuc").ToString().Substring(6, 2) & "/" & _
                                                   DtTable.Rows(0).Item("NgayHieuLuc").ToString().Substring(4, 2) & "/" & _
                                                   DtTable.Rows(0).Item("NgayHieuLuc").ToString().Substring(0, 4))

                rpt.SetParameterValue("P_KhoXuat", DtTable.Rows(0).Item("KhoXuat").ToString)
                rpt.SetParameterValue("P_MaNguon", DtTable.Rows(0).Item("MaNguon").ToString)
                rpt.SetParameterValue("P_PhuongThucXuat", DtTable.Rows(0).Item("PhuongThucXuat").ToString)
                rpt.SetParameterValue("P_DVNhanHang", DtTable.Rows(0).Item("DVNhanHang").ToString)
                rpt.SetParameterValue("P_KhoXuat", DtTable.Rows(0).Item("KhoXuat").ToString)
                rpt.SetParameterValue("P_MaPhuongTien", DtTable.Rows(0).Item("MaPhuongTien").ToString)
                rpt.SetParameterValue("P_NguoiVanChuyen", DtTable.Rows(0).Item("NguoiVanChuyen").ToString())
                frmView.crViewer.ReportSource = rpt
                frmView.ShowDialog()

            Else
                If DtTable.Rows(0).Item("NgayHieuLuc").ToString = "" Then
                    DtTable.Rows(0).Item("NgayHieuLuc") = DtTable.Rows(0).Item("NgayXuat")
                End If
                rpt.SetParameterValue("P_SoLenh", DtTable.Rows(0).Item("SoLenh").ToString())
                rpt.SetParameterValue("P_TuNgay", Format(DtTable.Rows(0).Item("NgayXuat"), "dd/MM/yyyy"))
                rpt.SetParameterValue("P_DenNgay", DtTable.Rows(0).Item("NgayHieuLuc").ToString().Substring(6, 2) & "/" & _
                                                   DtTable.Rows(0).Item("NgayHieuLuc").ToString().Substring(4, 2) & "/" & _
                                                   DtTable.Rows(0).Item("NgayHieuLuc").ToString().Substring(0, 4))

                rpt.SetParameterValue("P_KhoXuat", DtTable.Rows(0).Item("KhoXuat").ToString)
                rpt.SetParameterValue("P_MaNguon", DtTable.Rows(0).Item("MaNguon").ToString)
                rpt.SetParameterValue("P_PhuongThucXuat", DtTable.Rows(0).Item("PhuongThucXuat").ToString)
                rpt.SetParameterValue("P_DVNhanHang", DtTable.Rows(0).Item("DVNhanHang").ToString)
                rpt.SetParameterValue("P_KhoXuat", DtTable.Rows(0).Item("KhoXuat").ToString)
                rpt.SetParameterValue("P_MaPhuongTien", DtTable.Rows(0).Item("MaPhuongTien").ToString)
                rpt.SetParameterValue("P_NguoiVanChuyen", DtTable.Rows(0).Item("NguoiVanChuyen").ToString())
                rpt.PrintOptions.PrinterName = g_DefaultPrint
                rpt.PrintToPrinter(1, False, 0, 0)
            End If

            o_err = "m028"
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
