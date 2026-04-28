Imports System.Windows.Forms
Imports System.Reflection

Public Class Class1


    Public Sub clsInChungTu(ByVal p_Form As Object, ByVal p_Preview As Boolean, ByVal p_SoLenh As String, ByVal p_Type As String)
        InChungTuHoaDon(p_Form, p_Type, p_SoLenh)
    End Sub


    Public Sub New(ByVal p_Module As Object, ByVal p_Config_XMLDatatable As DataTable, ByVal p_Company_Code As String, ByVal p_WareHouse As String, ByVal p_Services As Object, ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                   Optional ByVal p_Company_Host As String = "", _
                    Optional ByVal p_Company_DB_Name As String = "", Optional ByVal p_UserName As String = "", _
                    Optional ByVal p_LicenceHost As String = "", Optional ByVal p_DBUser As String = "", _
                    Optional ByVal p_DBPass As String = "", Optional ByVal p_CompanyAPI As Object = Nothing)

        'Dim p_SQL As String = "select * from tblVCF"

        g_Services = p_Services

        Dim p_SQL As String
        Dim p_DataRow() As DataRow

        Dim p_DataSet As DataSet


        g_Company_Code = p_Company_Code


        p_SQL = "select * from tblVCF;"

        p_SQL = p_SQL & "select * from tblHangHoaE5; "

        p_SQL = p_SQL & "select * from tblPara; "


        p_SQL = p_SQL & "select * from SYS_CONFIG; "

        p_SQL = p_SQL & "SELECT  MaDonVi ,TenDonVi FROM [tblDonvi] where MaDonVi='" & g_Company_Code & "';"
        p_SQL = p_SQL & "SELECT [Code],[sDescription], upper(FunctionName) as [FunctionName]  FROM [tblHDDT_Messages]; "

        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            g_tblVCF = p_DataSet.Tables(0)


            g_HangHoaToScada2 = p_DataSet.Tables(1)


            g_dt_para = p_DataSet.Tables(2)

            g_SySConfig = p_DataSet.Tables(3)

            g_TableDonvi = p_DataSet.Tables(4)

            g_TableMessage = p_DataSet.Tables(5)
        End If


        ' p_SQL = "select * from tblVCF"
        'g_tblVCF = GetDataTable(p_SQL, p_SQL)

        Try
            g_Config_XMLDatatable = p_Config_XMLDatatable
            g_Terminal = g_Config_XMLDatatable.Rows(0).Item("CLIENT").ToString.Trim
        Catch ex As Exception

        End Try

        'Dim p_FptMod As New FPTModule.Class1(g_UserName, g_Company_Code, p_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName)
        g_Module = p_Module
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

        'p_SQL = "select * from tblHangHoaE5 "
        'g_HangHoaToScada2 = GetDataTable(p_SQL, p_SQL)

        'p_SQL = "select * from tblPara "
        'g_dt_para = GetDataTable(p_SQL, p_SQL)

        'p_SQL = "select * from SYS_CONFIG "
        'g_SySConfig = GetDataTable(p_SQL, p_SQL)


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



        'p_SQL = "SELECT  MaDonVi ,TenDonVi FROM [tblDonvi] where MaDonVi='" & g_Company_Code & "'"
        ' g_TableDonvi = GetDataTable(p_SQL, p_SQL)
        If Not g_TableDonvi Is Nothing Then
            If g_TableDonvi.Rows.Count > 0 Then
                g_TenDonVi = g_TableDonvi.Rows(0).Item("TenDonVi")
            End If
        End If
        ' GetInforLinkCompany()

        'CreateServicePublic(g_PublicService)
        'CreateServicePortal(g_PortalService)
        'CreateServiceBusiness(g_BusinessService)


        'CreateServicePublicDO1(g_2PublicService)
        'CreateServicePortalDO1(g_2PortalService)
        'CreateServiceBusinessDO1(g_2BusinessService)


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



    Public Sub InChungTuHoaDon(ByVal p_Form As Object, ByVal p_Type As String, ByVal p_SoLenh As String)
        Dim l_err As String

      

        Select Case p_Type
            Case "HOADON"
                Dim p_FormHD As New frmImfor_HoaDon(p_SoLenh)
                p_FormHD.g_XtraServicesObj = g_Services
                p_FormHD.p_XtraModuleObj = g_Module
                p_FormHD.Show(p_Form)
                'Case "HOADONCT"
                '    Dim p_FormHD As New frmImfor_HoaDonCT(p_SoLenh)
                '    p_FormHD.g_XtraServicesObj = g_Services
                '    p_FormHD.p_XtraModuleObj = g_Module
                '    p_FormHD.Show(p_Form)
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

                'Case "HOADONGIUHO"
                '    Dim p_FormHDGiuHo As New frmImfor_HoaDonHangGiuHo(p_SoLenh)
                '    p_FormHDGiuHo.g_XtraServicesObj = g_Services
                '    p_FormHDGiuHo.p_XtraModuleObj = g_Module
                '    p_FormHDGiuHo.Show(p_Form)
                'Case "LENHXUATKHO"
                '    If Not Print_LenhXuatKho(False, p_SoLenh, l_err) Then
                '        ShowMessageBox("", l_err)
                '    End If
                'Case "LENHXKTHEOPHOI"
                '    If Not Print_LenhXKTheoPhoi(False, p_SoLenh, l_err) Then
                '        ShowMessageBox("", l_err)
                '    End If
                'Case "LENHXUATKHOKDD"
                '    If Not Print_LENHXUATKHOKDD(False, p_SoLenh, l_err) Then
                '        ShowMessageBox("", l_err)
                '    End If
                'Case "LENHXUATKHOKDDA4"
                '    If Not Print_LENHXUATKHOKDDA4(False, p_SoLenh, l_err) Then
                '        ShowMessageBox("", l_err)
                '    End If

                'Case "TAIXUAT"
                '    Dim p_FormTaiXuat As New frmImfor_HoaDonTaiXuat(p_SoLenh)
                '    p_FormTaiXuat.g_XtraServicesObj = g_Services
                '    p_FormTaiXuat.p_XtraModuleObj = g_Module
                '    p_FormTaiXuat.Show(p_Form)


            Case UCase("TaiXuatGTGT")
                Dim p_FormTaiXuatEN As New frmImfor_HoaDonTaiXuat_EN(p_SoLenh)
                p_FormTaiXuatEN.g_XtraServicesObj = g_Services
                p_FormTaiXuatEN.GTGT_EN = False
                p_FormTaiXuatEN.p_XtraModuleObj = g_Module
                p_FormTaiXuatEN.Show(p_Form)

                'Case UCase("TaiXuatGTGT1")
                '    Dim p_FormTaiXuatEN1 As New frmImfor_HoaDonTaiXuat_EN(p_SoLenh)
                '    p_FormTaiXuatEN1.g_XtraServicesObj = g_Services
                '    p_FormTaiXuatEN1.p_XtraModuleObj = g_Module
                '    p_FormTaiXuatEN1.GTGT_EN = True
                '    p_FormTaiXuatEN1.Show(p_Form)
                'Case UCase("BIENBANDOBE")
                '    If Not Print_BienBanDoBe(False, p_SoLenh, l_err) Then
                '        ShowMessageBox("", l_err)
                '    End If

        End Select
    End Sub


End Class
