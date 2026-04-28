Imports System.Windows.Forms
Imports System.Reflection
'FPTLISTS
Public Class Class1

    Public Sub clsSoLenh_THN_Show()
        SoLenh_THN_Show()
    End Sub

    Public Sub clsKiemke_Show()
        KiemKe_Show()
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
        ' Dim p_Table As DataTable
        Dim p_SQL As String
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
                p_Frm.p_XtraUserName = g_User_ID
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
                p_FrmObj.WindowState = FormWindowState.Normal
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
        Dim p_DataTable1 As DataTable
        Dim p_DataTable2 As DataTable
        Dim p_DataSet As DataSet
        Dim p_ArrRow() As DataRow
        Try
            g_Config_XMLDatatable = p_Config_XMLDatatable
            g_Terminal = g_Config_XMLDatatable.Rows(0).Item("CLIENT").ToString.Trim
            g_DefaultPrint = g_Config_XMLDatatable.Rows(0).Item("PRINTER").ToString.Trim
        Catch ex As Exception

        End Try


        Try
            If UCase(g_Config_XMLDatatable.Rows(0).Item("WCF").ToString.Trim) = "TRUE" Then
                g_WCF = True
            End If
        Catch ex As Exception

        End Try

        'Try
        '    If UCase(g_Config_XMLDatatable.Rows(0).Item("E5").ToString.Trim) = "TRUE" Then
        '        g_E5 = True
        '    End If
        'Catch ex As Exception

        'End Try

        


        g_Company_Host = p_Company_Host
        g_GetHostName = p_Company_DB_Name
        g_Company_DBName = p_Company_DB_Name
        g_Services = p_Services
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

        GetFieldExtra()

        p_SQL = "select TenKho from tblKho where MaKho ='" & g_WareHouse.ToString.Trim & "';" & _
                "select * from SYS_USER where upper(USER_NAME)='" & UCase(g_UserName) & "';" & _
                "select * from sys_config;" & _
                " select * from  tblHangHoaE5;"  ' select * from tblPhuongThucXuat where  sDefault='Y'"
        p_SQL = p_SQL & " SELECT  Ma_map + '-' + BWART + '-'+  TenPhuongThucXuat  AS [TenPhuongThucXuat] " & _
                        " ,[Status],[Ma_Map],[BWART],[VTWEG] ,[MaPhuongThucXuat] ,[BSART],[sDefault] " & _
                            " FROM  [tblPhuongThucXuat]  where  sDefault='Y'"
        'p_SQL = "FPT_PhuongThucXuat_Default '" & p_PTBan & "','" & p_MaNguon & "','" & p_MaKhachHang & "'"
        'p_Table = GetDataTable(p_SQL, p_SQL)
        p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_DataTable = p_DataSet.Tables(0)
                p_DataTable1 = p_DataSet.Tables(1)
                p_DataTable2 = p_DataSet.Tables(2)
                g_HangHoaToScada2 = p_DataSet.Tables(3)
                g_PhuongThucXuat = p_DataSet.Tables(4)
            End If

        End If
        ' p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

        If Not p_DataTable1 Is Nothing Then
            If p_DataTable1.Rows.Count > 0 Then
                '  g_WareHouseName = p_DataTable.Rows(0).Item(0).ToString.Trim
                If p_DataTable1.Rows(0).Item("App_Grid").ToString.Trim = "Y" Then
                    g_App_Grid = True
                End If
                If p_DataTable1.Rows(0).Item("App_Scadar").ToString.Trim = "Y" Then
                    g_App_Scadar = True
                End If

                If p_DataTable1.Rows(0).Item("AppN30").ToString.Trim = "Y" Then
                    g_AppN30 = "Y"
                Else
                    g_AppN30 = "N"
                End If

                ' g_App_Grid = p_DataTable1.Rows(0).Item("App_Grid").ToString.Trim
                '  g_App_Scadar = p_DataTable1.Rows(0).Item("App_Scadar").ToString.Trim
            End If
        End If
        If Not p_DataTable2 Is Nothing Then
            If p_DataTable2.Rows.Count > 0 Then

                p_ArrRow = p_DataTable2.Select("KeyCode='FILTERKHO'")
                If p_ArrRow.Length > 0 Then
                    If p_ArrRow(0).Item("KeyValue").ToString.Trim = "Y" Then
                        g_Filter_Terminal = True
                    End If
                End If

                p_ArrRow = p_DataTable2.Select("KeyCode='E5'")
                If p_ArrRow.Length > 0 Then
                    If p_ArrRow(0).Item("KeyValue").ToString.Trim = "Y" Then
                        g_E5 = True
                    Else
                        g_E5 = False
                    End If
                End If

                'KIEMTRAGHEP_PT
                p_ArrRow = p_DataTable2.Select("KeyCode='KIEMTRAGHEP_PT'")
                If p_ArrRow.Length > 0 Then
                    If p_ArrRow(0).Item("KeyValue").ToString.Trim = "Y" Then
                        g_KIEMTRAGHEP_PT = True
                    Else
                        g_KIEMTRAGHEP_PT = False
                    End If
                End If

                'TaitrongKG
                p_ArrRow = p_DataTable2.Select("KeyCode='TAITRONGKG'")
                If p_ArrRow.Length > 0 Then
                    If p_ArrRow(0).Item("KeyValue").ToString.Trim = "Y" Then
                        g_TAITRONGKG = True
                    Else
                        g_TAITRONGKG = False
                    End If
                End If
                ''Rang buoc cong tơ và bể xuất


                g_CONGTOBEXUAT = True
                p_ArrRow = p_DataTable2.Select("KeyCode='CONGTOBEXUAT'")
                If p_ArrRow.Length > 0 Then
                    If p_ArrRow(0).Item("KeyValue").ToString.Trim = "Y" Then
                        g_CONGTOBEXUAT = True
                    Else
                        g_CONGTOBEXUAT = False
                    End If
                End If

                g_KV1 = False
                p_ArrRow = p_DataTable2.Select("KeyCode='KV1'")
                If p_ArrRow.Length > 0 Then
                    If p_ArrRow(0).Item("KeyValue").ToString.Trim = "Y" Then
                        g_KV1 = True
                    Else
                        g_KV1 = False
                    End If
                End If

                p_ArrRow = p_DataTable2.Select("KeyCode='SMOLinkServices'")
                If p_ArrRow.Length > 0 Then
                    g_LinkServicesSMO = p_ArrRow(0).Item("KeyValue").ToString.Trim

                End If
                p_ArrRow = p_DataTable2.Select("KeyCode='SMOUserName'")
                If p_ArrRow.Length > 0 Then
                    g_UserNameSMO = p_ArrRow(0).Item("KeyValue").ToString.Trim

                End If
                p_ArrRow = p_DataTable2.Select("KeyCode='SMOPass'")
                If p_ArrRow.Length > 0 Then
                    g_PassSMO = p_ArrRow(0).Item("KeyValue").ToString.Trim

                End If
                'Public g_LinkServicesSMO As String = ""
                'Public g_UserNameSMO As String = ""
                'Public g_PassSMO As String = ""

                g_NhomBeXuat = False
                p_ArrRow = p_DataTable2.Select("KeyCode='TANK_GROUP'")
                If p_ArrRow.Length > 0 Then
                    If p_ArrRow(0).Item("KeyValue").ToString.Trim = "Y" Then
                        g_NhomBeXuat = True
                    Else
                        g_NhomBeXuat = False
                    End If
                End If

            End If
        End If




        p_SQL = ""
        Dim p_FptMod As New FPTModule.Class1(g_UserName, g_Company_Code, g_Services, p_UsrB1, p_PassB1, p_Port, g_Company_Host, g_GetHostName)
        'p_FptMod = New FPTModule.Class1(g_Services, p_UsrB1, p_PassB1, p_Port, g_Company_Host, g_GetHostName)
        p_Get_Message()

        'Dim p_FptMod As New FPTModule.Class1(g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName)
        'If p_Dataset_Binding.Tables.Count <= 0 Then
        '    p_Dataset_Binding = g_Services.SysGetBidingSource("FPTLISTS")
        'End If

        'If p_DataSet_TrueGird.Tables.Count <= 0 Then
        '    p_DataSet_TrueGird = g_Services.SysGetTrueGridSource("FPTLISTS")
        'End If
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

        'p_SQL = "select * from  tblHangHoaE5 "   ' tblMeterE5"
        'g_HangHoaToScada2 = GetDataTable(p_SQL, p_SQL)

        GetCurrencyList()
        GetApprovedList("FPTSO")
        g_Module = p_FptMod
        ' g_SYS_COMPANY = g_Services.Sys_SYS_GET_DATATABLE_Des("Select * from SYS_COMPANIES where Company_Code='" & g_Company_Code & "'", p_SQL)
        ' p_GetApproved()
        ' p_FptMod = Nothing

        _Report_Object = New ReportSetup.Class1(g_Config_XMLDatatable, g_Company_Code, g_WareHouse, g_Services, g_UsrB1, g_PassB1, g_Port, _
                                                                       g_Company_Host, p_User_Database, g_UserName, g_LicenceHost, _
                                                                       g_DBUser, g_DBPass, g_CompanyAPI, g_ToolStripStatus, g_MessageStatus, p_MenuIcon)

        _HDDT_Object = New HDDT.Class1(g_Module, g_Config_XMLDatatable, _
                                                                             g_Company_Code, _
                                                                             g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                                             g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                                             g_DBPass, g_CompanyAPI)


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


    Private Sub GetFieldExtra()
        Dim l_str As String

        Dim p_Count As Integer
        Dim p_FileStr As String = ""
        Try


            l_str = "select * from  tblLenhXuatChiTietE5_Info order by  vOrder"   ' tblMeterE5"
            g_FieldExtra = g_Services.Sys_SYS_GET_DATATABLE_Des(l_str, l_str)
            If g_FieldExtra Is Nothing Then Exit Sub
            For p_Count = 0 To g_FieldExtra.Rows.Count - 1
                If g_FieldExtra.Rows(p_Count).Item("FieldName").ToString.Trim <> "" Then
                    p_FileStr = p_FileStr & "," & g_FieldExtra.Rows(p_Count).Item("FieldName").ToString.Trim
                End If
            Next
            If p_FileStr <> "" Then
                p_FileStr = Mid(p_FileStr, 2)
                p_FileStr = " SELECT " & p_FileStr & " FROM  tblLenhXuatChiTietE5 "
            End If
            g_StrFieldExtra = p_FileStr
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class