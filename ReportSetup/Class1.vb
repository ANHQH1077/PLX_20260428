Imports System.Windows.Forms
Imports System.Reflection
'FPTLISTS
Public Class Class1


    Public Sub clsInBienBanGiaoNhan(ByVal p_SoLenh As String)

        If p_CHUNGTU_ALL = False Then
            Select Case g_Company_Code
                Case "6610"  'KV2
                    Dim p_TichKeKV2 As New KV_2_Report.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    p_TichKeKV2.clsInBienBanGiaoNhan(p_SoLenh)
                    Exit Sub
                    'Case "2110"  'KV1
                    '    Dim p_TichKeKV1 As New KV1_Report.Class1(g_Config_XMLDatatable, _
                    '                                              g_Company_Code, _
                    '                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                    '                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                    '                                              g_DBPass, g_CompanyAPI)

                    '    Exit Sub
                    '    'Case "4510" 'KV5
                    '    '    Dim p_TichKeKV5 As New K4510.Class1(g_Config_XMLDatatable, _
                    '    '                                              g_Company_Code, _
                    '    '                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                    '    '                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                    '    '                                              g_DBPass, g_CompanyAPI)
                    '    '    p_TichKeKV5.InChungTuHoaDon(p_Form, p_Type, p_SoLenh)
                    '    '    Exit Sub

                    'Case "7310"  'TNB
                    '    Dim p_TichKeTNB As New K7310.Class1(g_Config_XMLDatatable, _
                    '                                              g_Company_Code, _
                    '                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                    '                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                    '                                              g_DBPass, g_CompanyAPI)

                    '    Exit Sub

                Case Else
                    Dim p_AllReport As New ALL_REPORT.Class1(g_Config_XMLDatatable, _
                                                            g_Company_Code, _
                                                            g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                            g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                            g_DBPass, g_CompanyAPI)
                    p_AllReport.clsInBienBanGiaoNhan(p_SoLenh)

            End Select
        Else
            Dim p_AllReport As New ALL_REPORT.Class1(g_Config_XMLDatatable, _
                                                            g_Company_Code, _
                                                            g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                            g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                            g_DBPass, g_CompanyAPI)

            Exit Sub
        End If
    End Sub

    Public Sub clsInTichKe(ByVal p_Preview As Boolean, ByVal p_SoLenh As String, Optional ByVal p_MATUDONGHOA As Boolean = False)
        If p_MATUDONGHOA = True Then
            g_MaTuDongHoa = "Y"
        End If
        InTichKe(p_Preview, p_SoLenh)
    End Sub

    Public Sub clsInChungTu(ByVal p_Form As Object, ByVal p_Preview As Boolean, ByVal p_SoLenh As String, ByVal p_Type As String)
        InChungTu(p_Form, p_Preview, p_SoLenh, p_Type)
    End Sub

   

    Public Sub clsInChungTu_ALL(ByVal p_Form As Object, ByVal p_Preview As Boolean, ByVal p_SoLenh As String, ByVal p_Type As String)
        InChungTu_ALL(p_Form, p_Preview, p_SoLenh, p_Type)
    End Sub

    Public Sub P_Show_Form(ByVal p_MDIFORM As Object, ByVal p_Form_Name As String, _
                            ByVal p_User_Database1 As String, _
                            ByVal p_User_ID1 As Double, _
                                ByVal p_Company_ID1 As Integer, _
                                ByVal p_Company_Host As String,
                                ByVal p_FunctionID As Integer)
        Dim p_Frm As Object = p_CreateForm(p_Form_Name)
        Dim p_FptMod As New FPTModule.Class1(g_UserName, g_Company_Code, g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName)
        p_User_Database = p_User_Database1
        Dim p_FrmObj As Object
        g_Company_DBName = p_User_Database1
        g_User_ID = p_User_ID1
        p_Company_ID = p_Company_ID1

        g_Company_Host = p_Company_Host

        Mod_IPAddress()


        p_Get_Message()

        If p_Dataset_Binding Is Nothing Then
            p_Dataset_Binding = g_Services.SysGetBidingSource("FPTSO")
        Else
            If p_Dataset_Binding.Tables.Count <= 0 Then
                p_Dataset_Binding = g_Services.SysGetBidingSource("FPTSO")
            End If
        End If

        'If p_DataSet_TrueGird Is Nothing Then
        '    p_DataSet_TrueGird = g_Services.SysGetTrueGridSource("FPTSO")
        'Else
        '    If p_DataSet_TrueGird.Tables.Count <= 0 Then
        '        p_DataSet_TrueGird = g_Services.SysGetTrueGridSource("FPTSO")
        '    End If
        'End If
        If p_DataSet_TrueGird Is Nothing Then
            p_DataSet_TrueGird = g_Services.SysGetTrueGridSource("FPTSO")
        Else
            If p_DataSet_TrueGird.Tables.Count <= 0 Then
                p_DataSet_TrueGird = g_Services.SysGetTrueGridSource("FPTSO")
            End If
        End If

        If p_DataSet_Combo_Source Is Nothing Then
            'If p_DataSet_Combo_Source.Tables.Count <= 0 Then
            If p_FptMod.p_Mod_Get_Combobox_Source("FPTSO", p_DataSet_Combo_Source) = False Then
            End If
            'End If
        Else
            If p_DataSet_Combo_Source.Tables.Count <= 0 Then
                If p_FptMod.p_Mod_Get_Combobox_Source("FPTSO", p_DataSet_Combo_Source) = False Then
                End If
            End If
        End If
        If p_Frm Is Nothing Then
        Else
            Try
                p_Frm.p_XtraModuleObj = p_FptMod
                p_Frm.g_XtraServicesObj = g_Services
                p_Frm.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                p_Frm.p_XtraToolTripLabel = g_ToolStripStatus
                p_Frm.p_XtraMessageStatusl = g_MessageStatus
                p_Frm.g_XtraFunctionID = p_FunctionID
                p_Frm.p_XtraUserName = g_UserName
                p_Frm.p_XtraMenuIcon = g_MenuIcon
                FillParameterToForm(p_Frm, p_FunctionID)
                '  p_Frm.p_UserName = g_UserName
            Catch ex As Exception

            End Try
            'If p_Frm.StartPosition = FormStartPosition.Manual Then

            'End If
            'p_Frm.StartPosition = FormStartPosition.Manual
            p_FrmObj = CheckFormOpen(p_Form_Name)
            If p_FrmObj Is Nothing Then
                If Not p_MDIFORM Is Nothing Then
                    p_Frm.Show(p_MDIFORM)
                Else
                    p_Frm.Show()
                End If
            Else
                p_FrmObj.focus()
            End If
        End If
    End Sub



    Private Sub FillParameterToForm(ByRef p_Form As Object, ByVal p_Function_ID As Integer)
        Dim p_Count As Integer
        Dim p_DataTable As DataTable
        Dim p_DataRow() As DataRow
        Dim p_SQL As String
        Dim p_Desc As String = ""
        Dim p_ParName As String = ""
        Try
            p_SQL = "SELECT upper([PAR_NAME]) as PAR_NAME ,[SQL_VALUE]    " & _
                            " FROM [SYS_FUNCTION_PAR] where FUNCTION_ID=" & p_Function_ID

            p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Desc)
            If p_DataTable Is Nothing Then Exit Sub
            If p_DataTable.Rows.Count <= 0 Then Exit Sub

            If p_Desc.ToString.Trim = "" Then
                For p_Count = 0 To 19
                    p_ParName = "PARAMETER" & p_Count
                    p_DataRow = p_DataTable.Select("PAR_NAME='" & p_ParName & "'")
                    If p_DataRow.Length > 0 Then
                        p_Form.g_XtraParameterArray(p_Count) = p_DataRow(0).Item("SQL_VALUE").ToString.Trim
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Function p_CreateObjectInstance(ByVal objectName As String) As Object ' Creates and returns an instance of any object in the assembly by its type name. 
        Dim p_obj As Object
        Try
            If objectName.LastIndexOf(".") = -1 Then 'Appends the root namespace if not specified.
                objectName = [Assembly].GetCallingAssembly.GetName.Name & "." & objectName '"MnuSystem." & objectName '[Assembly].GetEntryAssembly.GetName.Name & "." & objectName
            End If
            p_obj = [Assembly].GetCallingAssembly.CreateInstance(objectName)
        Catch ex As Exception

            p_obj = Nothing

        End Try

        Return p_obj
    End Function
    Public Shared Function p_CreateForm(ByVal formName As String) As Form ' Return the instance of the form by specifying its name. 
        Return DirectCast(p_CreateObjectInstance(formName), Form)
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
                    Optional ByVal p_DBPass As String = "", Optional ByVal p_CompanyAPI As Object = Nothing, _
                    Optional ByVal p_ToolStripStatus As System.Windows.Forms.ToolStripStatusLabel = Nothing, _
                    Optional ByVal p_MessageStatus As System.Windows.Forms.ToolStripStatusLabel = Nothing, _
                    Optional ByRef p_MenuIcon As ToolStrip = Nothing)

        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_DataTableSys As DataTable
        Dim p_DataSet As DataSet
        Dim p_DataRow() As DataRow

        Try
            g_Config_XMLDatatable = p_Config_XMLDatatable
            g_Terminal = g_Config_XMLDatatable.Rows(0).Item("CLIENT").ToString.Trim
        Catch ex As Exception

        End Try
        g_Services = p_Services

        g_Company_Host = p_Company_Host
        g_GetHostName = p_Company_DB_Name
        g_Company_DBName = p_Company_DB_Name

        g_MessageStatus = p_MessageStatus
        g_ToolStripStatus = p_ToolStripStatus

        g_UserName = p_UserName
        g_CompanyAPI = p_CompanyAPI

        g_MenuIcon = p_MenuIcon

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

        p_SQL = "select * from tblVCF; select * from tblHangHoaE5; select * from tblPara"
        ' p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)


        'p_SQL = "select * from tblVCF"
        'g_tblVCF = GetDataTable(p_SQL, p_SQL)


        'p_SQL = "select * from tblHangHoaE5 "
        'g_HangHoaToScada2 = GetDataTable(p_SQL, p_SQL)

        'p_SQL = "select * from tblPara "
        'g_dt_para = GetDataTable(p_SQL, p_SQL)



        p_SQL = "select TenKho from tblKho where MaKho ='" & g_WareHouse & "';" & _
                "select * from SYS_CONFIG;" & p_SQL

        'p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)


        p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then

            p_DataTable = p_DataSet.Tables(0)
            p_DataTableSys = p_DataSet.Tables(1)
            g_SySConfig = p_DataSet.Tables(1)
            g_tblVCF = p_DataSet.Tables(2)
            g_HangHoaToScada2 = p_DataSet.Tables(3)
            g_dt_para = p_DataSet.Tables(4)
        End If

        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                g_WareHouseName = p_DataTable.Rows(0).Item(0).ToString.Trim
            End If
        End If

        p_Report_All = False
        If Not p_DataTableSys Is Nothing Then
            p_DataRow = p_DataTableSys.Select("KEYCODE='REPORT_ALL'")
            If p_DataRow.Length > 0 Then
                If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    p_Report_All = True
                End If
            End If

        End If

        p_CHUNGTU_ALL = False
        If Not p_DataTableSys Is Nothing Then
            p_DataRow = p_DataTableSys.Select("KEYCODE='CHUNGTU_ALL'")
            If p_DataRow.Length > 0 Then
                If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    p_CHUNGTU_ALL = True
                End If
            End If

        End If

        If Not p_DataTableSys Is Nothing Then
            p_DataRow = p_DataTableSys.Select("KEYCODE='HD_NOIDUNG1'")
            If p_DataRow.Length > 0 Then
                ' If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                g_HOADON1 = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                'End If
            End If

        End If

        If Not p_DataTableSys Is Nothing Then
            p_DataRow = p_DataTableSys.Select("KEYCODE='HD_NOIDUNG2'")
            If p_DataRow.Length > 0 Then
                ' If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                g_HOADON2 = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                'End If
            End If

        End If



        p_SQL = ""
        Dim p_FptMod As New FPTModule.Class1(g_UserName, g_Company_Code, g_Services, p_UsrB1, p_PassB1, p_Port, g_Company_Host, g_GetHostName)
        'p_FptMod = New FPTModule.Class1(g_Services, p_UsrB1, p_PassB1, p_Port, g_Company_Host, g_GetHostName)
        p_Get_Message()


        If p_DataSet_Combo_Source Is Nothing Then
            ' If p_DataSet_Combo_Source.Tables.Count <= 0 Then
            If p_FptMod.p_Mod_Get_Combobox_Source("FPTSO", p_DataSet_Combo_Source) = False Then
            End If
            'End If
        Else
            If p_DataSet_Combo_Source.Tables.Count <= 0 Then
                If p_FptMod.p_Mod_Get_Combobox_Source("FPTSO", p_DataSet_Combo_Source) = False Then
                End If
            End If
        End If

        p_SQL = "select * from  tblHangHoaE5 "   ' tblMeterE5"
        g_HangHoaToScada2 = GetDataTable(p_SQL, p_SQL)

        GetCurrencyList()
        GetApprovedList("FPTSO")
        g_Module = p_FptMod




        '   g_SYS_COMPANY = g_Services.Sys_SYS_GET_DATATABLE_Des("Select * from SYS_COMPANIES where Company_Code='" & g_Company_Code & "'", p_SQL)
        ' p_GetApproved()
        ' p_FptMod = Nothing
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Public Sub GetCurrencyList()
        Dim p_SQL As String
        Dim p_DataTbl As New DataTable

        Exit Sub

        Try
            p_SQL = "select CurrCode , CurrName ,Decimals  from FPTOCRN where Locked='N'"
            g_CurrencyDtl = g_Services.mod_SYS_GET_DATATABLE(p_SQL)
        Catch ex As Exception

        End Try
        p_SQL = "select  Currency   from SYS_COMPANIES   where Company_Code='" & g_Company_Code & "'"
        p_DataTbl = g_Services.mod_SYS_GET_DATATABLE(p_SQL)
        g_Currency = "VND"
        If Not p_DataTbl Is Nothing Then
            If p_DataTbl.Rows.Count > 0 Then
                g_Currency = p_DataTbl.Rows(0).Item(0).ToString.Trim
            End If
        End If
    End Sub


    Public Sub kv2_BienBanDoBe_All(p_TableReturn As DataTable)
        Dim p_KV2 As New KV_2_Report.Class1(g_Config_XMLDatatable, _
                                                                           g_Company_Code, _
                                                                           g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                                           g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                                           g_DBPass, g_CompanyAPI)
        p_KV2.clsInBaoCaoNew(Nothing, p_TableReturn, "BM_01_14_BB", Nothing, Nothing, Nothing, Nothing)

    End Sub
End Class