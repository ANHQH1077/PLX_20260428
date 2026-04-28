Imports System.Windows.Forms
Imports System.Reflection
'FPTLISTS
Public Class Class1


    Public Sub clsDongBoChiTietPT_Show()
        DongBoChiTietPT_Show()
    End Sub


    Public Sub P_Show_Form(ByVal p_MDIFORM As Object, ByVal p_Form_Name As String, _
                            ByVal p_User_Database1 As String, _
                            ByVal p_User_ID1 As Double, _
                                ByVal p_Company_ID1 As Integer, _
                                ByVal p_Company_Host As String, _
                                ByVal p_FunctionID As Integer)
        'Dim p_Frm As Form = p_CreateForm(p_Form_Name)
        'p_User_Database = p_User_Database1
        'g_User_ID = p_User_ID1
        'p_Company_ID = p_Company_ID1

        'g_Company_Host = p_Company_Host

        'Mod_IPAddress()
        'If p_Frm Is Nothing Then
        'Else
        '    p_Frm.StartPosition = FormStartPosition.CenterScreen
        '    p_Frm.Show(p_MDIFORM)
        'End If
        Dim p_Frm As Object = p_CreateForm(p_Form_Name)
        Dim p_FptMod As New FPTModule.Class1(g_UserName, g_Company_Code, g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName)
        p_User_Database = p_User_Database1
        Dim p_FrmObj As Object

        g_Company_DBName = p_User_Database1
        g_User_ID = p_User_ID1
        p_Company_ID = p_Company_ID1

        g_Company_Host = p_Company_Host

        Mod_IPAddress()

        g_WCF = GetTypeConnectWCF()

        p_Get_Message()

        If p_Dataset_Binding Is Nothing Then
            p_Dataset_Binding = g_Services.SysGetBidingSource("FPTLISTS")
        Else
            If p_Dataset_Binding.Tables.Count <= 0 Then
                p_Dataset_Binding = g_Services.SysGetBidingSource("FPTLISTS")
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
            p_DataSet_TrueGird = g_Services.SysGetTrueGridSource("FPTLISTS")
        Else
            If p_DataSet_TrueGird.Tables.Count <= 0 Then
                p_DataSet_TrueGird = g_Services.SysGetTrueGridSource("FPTLISTS")
            End If
        End If

        If p_DataSet_Combo_Source Is Nothing Then
            'If p_DataSet_Combo_Source.Tables.Count <= 0 Then
            If p_FptMod.p_Mod_Get_Combobox_Source("FPTLISTS", p_DataSet_Combo_Source) = False Then
            End If
            'End If
        Else
            If p_DataSet_Combo_Source.Tables.Count <= 0 Then
                If p_FptMod.p_Mod_Get_Combobox_Source("FPTLISTS", p_DataSet_Combo_Source) = False Then
                End If
            End If
        End If
        If p_Frm Is Nothing Then
        Else
            Try
                'p_Frm.p_XtraModuleObj = p_FptMod
                'p_Frm.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                p_Frm.p_XtraModuleObj = p_FptMod
                p_Frm.g_XtraServicesObj = g_Services
                p_Frm.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                p_Frm.p_XtraToolTripLabel = g_ToolStripStatus
                p_Frm.g_XtraFunctionID = p_FunctionID
                p_Frm.p_XtraUserName = g_UserName
                p_Frm.p_XtraMessageStatusl = g_MessageStatus
                FillParameterToForm(p_Frm, p_FunctionID)
                g_Services.Sys_GetParameterOracle(g_DBTYPE)

            Catch ex As Exception

            End Try
            'hieptd4 comment
            'p_Frm.StartPosition = FormStartPosition.CenterScreen
            'p_Frm.Show(p_MDIFORM)

            'hieptd4 add 20160718
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

    Public Sub New(ByVal p_Company_Code As String, ByVal p_Services As Object, ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                   Optional ByVal p_Company_Host As String = "", _
                    Optional ByVal p_Company_DB_Name As String = "", Optional ByVal p_UserName As String = "", _
                    Optional ByVal p_LicenceHost As String = "", Optional ByVal p_DBUser As String = "", _
                    Optional ByVal p_DBPass As String = "", Optional ByVal p_CompanyAPI As Object = Nothing, _
                    Optional ByVal p_ToolStripStatus As System.Windows.Forms.ToolStripStatusLabel = Nothing, _
                    Optional ByRef p_MessageStatus As System.Windows.Forms.ToolStripStatusLabel = Nothing)
        Dim p_SQL As String
        Dim p_Datatable As DataTable
        Dim p_ArrRow() As DataRow

        g_Company_Host = p_Company_Host
        g_GetHostName = p_Company_DB_Name
        g_Company_DBName = p_Company_DB_Name
        g_Services = p_Services
        g_MessageStatus = p_MessageStatus
        g_ToolStripStatus = p_ToolStripStatus


        g_CompanyAPI = p_CompanyAPI



        g_UsrB1 = p_UsrB1
        g_PassB1 = p_PassB1
        g_Port = p_Port
        g_Company_Code = p_Company_Code
        g_UserName = p_UserName
        g_LicenceHost = p_LicenceHost

        g_DBUser = p_DBUser
        g_DBPass = p_DBPass


        'GetConfigPrintFromXML()
        'If g_DataPrintList Is Nothing Then
        '    g_DataPrintList = New DataTable
        '    g_DataPrintList.Columns.Add("PRINTER")
        '    g_DataPrintList.Columns.Add("PRINTERVAT")
        'End If

        mdlConfig_GetConfigFromXML()

        'Dim p_SysBatch As New SystemBatch.Class1(g_Company_Host, g_GetHostName)
        Dim p_FptMod As New FPTModule.Class1(g_UserName, g_Company_Code, g_Services, p_UsrB1, p_PassB1, p_Port, g_Company_Host, g_GetHostName)
        p_Get_Message()
        ' g_FptModule = p_FptMod

        'If p_Dataset_Binding.Tables.Count <= 0 Then
        '    p_Dataset_Binding = g_Services.SysGetBidingSource("FPTLISTS")
        'End If

        'If p_DataSet_TrueGird.Tables.Count <= 0 Then
        '    p_DataSet_TrueGird = g_Services.SysGetTrueGridSource("FPTLISTS")
        'End If
        'If p_DataSet_Combo_Source.Tables.Count <= 0 Then
        '    If p_FptMod.p_Mod_Get_Combobox_Source("FPTLISTS", p_DataSet_Combo_Source) = False Then
        '    End If
        'End If

        g_Module = p_FptMod

        p_SQL = "select * from sys_config" 'where KeyCode='FILTERKHO'"

        p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then

                p_ArrRow = p_Datatable.Select("KeyCode='FILTERKHO'")
                If p_ArrRow.Length > 0 Then
                    If p_ArrRow(0).Item("KeyValue").ToString.Trim = "Y" Then
                        g_Filter_Terminal = True
                    Else
                        g_Filter_Terminal = False
                    End If

                End If

                p_ArrRow = p_Datatable.Select("KeyCode='E5'")
                If p_ArrRow.Length > 0 Then
                    If p_ArrRow(0).Item("KeyValue").ToString.Trim = "Y" Then
                        g_E5 = True
                    Else
                        g_E5 = False
                    End If
                End If


                g_CONGTOBEXUAT = True
                p_ArrRow = p_Datatable.Select("KeyCode='CONGTOBEXUAT'")
                If p_ArrRow.Length > 0 Then
                    If p_ArrRow(0).Item("KeyValue").ToString.Trim = "Y" Then
                        g_CONGTOBEXUAT = True
                    Else
                        g_CONGTOBEXUAT = False
                    End If
                End If


                p_ArrRow = p_Datatable.Select("KEYCODE='KV1'")
                If p_ArrRow.Length > 0 Then
                    If p_ArrRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_KV1 = True
                    Else
                        g_KV1 = False
                    End If
                End If


                p_TYTRONG_PTANG = False
                p_ArrRow = p_Datatable.Select("KEYCODE='TYTRONG_PTANG'")
                If p_ArrRow.Length > 0 Then
                    If p_ArrRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_TYTRONG_PTANG = True
                    End If
                End If



            End If
            'If p_Datatable.Rows(0).Item("KeyValue").ToString.Trim = "Y" Then
            '    g_Filter_Terminal = True
            'End If
            ' End If
        End If

        If p_DataSet_Combo_Source Is Nothing Then
            ' If p_DataSet_Combo_Source.Tables.Count <= 0 Then
            If p_FptMod.p_Mod_Get_Combobox_Source("FPTLISTS", p_DataSet_Combo_Source) = False Then
            End If
            'End If
        Else
            If p_DataSet_Combo_Source.Tables.Count <= 0 Then
                If p_FptMod.p_Mod_Get_Combobox_Source("FPTLISTS", p_DataSet_Combo_Source) = False Then
                End If
            End If
        End If
        'GetCurrencyList()
        ' p_SysBatch = Nothing
        'p_FptMod = Nothing
    End Sub

    Public Sub GetCurrencyList()
        Dim p_SQL As String
        Dim p_DataTbl As New DataTable
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
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class