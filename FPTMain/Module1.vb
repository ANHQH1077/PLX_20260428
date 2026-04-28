Imports System
Imports System.Data
Imports System.Net
Imports System.Data.OleDb
Imports System.Windows.Forms


Module Module1

    Public g_Filter_Terminal As Boolean = False


    Public g_IP_Address As String
    Public g_GetHostName As String
    Public g_User_ID As Double

    Public g_UserName As String

    Public g_Company_Code As String
    Public g_WareHouse As String
    Public g_LoginClient As String = ""
    Public p_Company_ID As Integer
    Public p_Company_Code As String
    Public p_Company_Name As String
    Public p_Company_Host As String
    Public p_User_Database As String
    Public p_SysBatch01 As Object ' New SystemBatch.Class1
    Public p_UsrB1 As String
    Public p_PassB1 As String
    Public p_Port As String
    Public p_LicenceHost As String

    Public p_DBUser As String
    Public p_DBPass As String

    Public g_Services As Object    'WcfRetail.ServiceClient
    'Public g_Services As Object
    Public g_CompanyAPI As Object 'New SAPbobsCOM.Company

    Public g_Currency As String = "VND"
    Public g_CurrencyDtl As New System.Data.DataTable

    Public p_MenuDatatable As New System.Data.DataTable

    Public g_Config_XMLDatatable As New System.Data.DataTable

    Public g_PathXML As String = Application.StartupPath & "\Config.xml"
    Public g_Wcf_Connect As Boolean = False


    Public Function GetTypeConnectWCF() As Boolean
        ' Dim g_PathXML As String
        Dim p_DataSet As New DataSet
        Dim g_Config_XMLDatatable As DataTable

        Try
            GetTypeConnectWCF = False
            ' g_PathXML = Application.StartupPath & "\Config.xml"
            If Dir(g_PathXML) <> "" Then
                p_DataSet.ReadXml(g_PathXML)
                If Not p_DataSet Is Nothing Then
                    If p_DataSet.Tables.Count > 0 Then
                        g_Config_XMLDatatable = p_DataSet.Tables(0)
                        Try

                            'g_Wcf_Connect
                            If g_Config_XMLDatatable.Rows(0).Item("WCF").ToString.Trim = "TRUE" Then
                                GetTypeConnectWCF = True
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
            Return GetTypeConnectWCF
        Catch ex As Exception
            Return False
        End Try
    End Function
    'Public Sub GetSource(ByVal p_Services As Object)
    '    Dim p_ServicesCls As New getServices.Class1
    '    ' Dim p_Services As New Object

    '    Dim p_Object As New FPTBUSSINESS.Class1
    '    If GetTypeConnectWCF() = True Then
    '        '  p_Services = p_ServicesCls.getServices
    '        g_Services = p_ServicesCls.getServices
    '    Else
    '        g_Services = p_Object
    '    End If

    'End Sub


    Public Function p_GetVersion(ByRef p_Err As String) As DataTable
        Dim p_File As String = ""

        Dim p_DataTable As New DataTable
        Dim anm As System.Reflection.AssemblyName
        Dim p_ToFile As String = ""
        Dim p_toFilePath As String = ""
        Dim p_toDirectoryFilePath As String = ""
        Dim p_Col1 As DataColumn
        Dim p_DataRow As DataRow
        Try
            ' p_GetVersion = True
            p_Col1 = New DataColumn("FileName")
            p_Col1.DataType = GetType(String)
            p_DataTable.Columns.Add(p_Col1)
            p_Col1 = New DataColumn("Version")
            p_Col1.DataType = GetType(String)
            p_DataTable.Columns.Add(p_Col1)
            ' Dim p_Col1 As New DataColumn("Column0")
            p_toDirectoryFilePath = Application.StartupPath

            Dim di As New IO.DirectoryInfo(p_toDirectoryFilePath)
            Dim diar1 As IO.FileInfo() = di.GetFiles()
            Dim dra As IO.FileInfo

            'list the names of all files in the specified directory
            For Each dra In diar1
                ' ListBox1.Items.Add(dra
                'For p_Count = 0 To p_DataTable.Rows.Count - 1
                'vshost.exe
                If (UCase(Right(dra.Name.ToString.Trim, 3)) = "EXE" Or UCase(Right(dra.Name.ToString.Trim, 3)) = "DLL") _
                        And UCase(Right(dra.Name.ToString.Trim, 10)) <> UCase("vshost.exe") Then
                    If InStr(UCase(dra.Name), UCase("Crystal")) > 0 Or InStr(UCase(dra.Name), UCase("DevExpress")) > 0 Or UCase(dra.Name) = UCase("FPTiRetail.exe") Then

                    Else
                        anm = System.Reflection.AssemblyName.GetAssemblyName(dra.Name)
                        p_DataRow = p_DataTable.NewRow
                        p_DataRow.Item(0) = dra.Name
                        p_DataRow.Item(1) = anm.Version
                        p_DataTable.Rows.Add(p_DataRow)
                    End If


                End If
                'Next
            Next


            Return p_DataTable

        Catch ex As Exception
            p_Err = ex.Message
            Return Nothing
            ' p_GetUpdateDLL = False
        End Try



    End Function

    Public Sub p_GetMenudata()
        Dim p_SQL As String
        p_SQL = ""
    End Sub

    Public Sub GetCurrencyList()
        Dim p_SQL As String
        Try
            p_SQL = "select CurrCode , CurrName ,Decimals  from FPTOCRN where Locked='N'"
            g_CurrencyDtl = g_Services.mod_SYS_GET_DATATABLE(p_SQL)
        Catch ex As Exception

        End Try

    End Sub

    Public Function Sys_SQL_Connection(ByVal connectionString As String) As OleDbConnection
        Dim con As New OleDbConnection()
        'Dim connectionString As String
        ''connectionString = SysGetConnect()
        Try

            Sys_SQL_Connection = New OleDbConnection(connectionString)
            Sys_SQL_Connection.Open()
            'Sys_SQL_Connection = con
        Catch ex As Exception
            Sys_SQL_Connection = Nothing
        End Try
    End Function

    Sub Mod_Get_Gird(ByVal p_SQL As String, ByRef p_BindingSource1 As Windows.Forms.BindingSource, ByRef p_abc As Object)
        'Dim p_MnuSystem As New SystemBatch.Class1
        Dim p_Mod_Get_Gird As New DataTable
        'Dim p_Status As Boolean
        p_Mod_Get_Gird = g_Services.mod_SYS_GET_DATASET(p_SQL).Tables(0)
        p_BindingSource1.DataSource = p_Mod_Get_Gird
        For p_Index = 0 To p_Mod_Get_Gird.Columns.Count - 1
            p_abc.Columns(p_Index).DataField = p_Mod_Get_Gird.Columns(p_Index).ToString
        Next p_Index
        p_abc.Refresh()
        ' p_MnuSystem = Nothing
    End Sub

    Public Sub Mod_IPAddress()
        g_GetHostName = System.Net.Dns.GetHostName()
        Dim ipHostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        Dim ipAddress As System.Net.IPAddress
        Dim ipTmp As String = ""
        For Each ipAddress In ipHostInfo.AddressList
            'Only return IPv4 routable IPs
            If (ipAddress.AddressFamily = Sockets.AddressFamily.InterNetwork) Then
                ipTmp = ipAddress.ToString
                ' Exit For
            End If
        Next
        If String.IsNullOrEmpty(ipTmp) Then
            ipTmp = ipHostInfo.AddressList(0).ToString
        End If
        g_IP_Address = ipTmp
        'g_IP_Address = System.Net.Dns.GetHostAddresses(g_GetHostName).GetValue(1).ToString    ' .GetHostByName(strHostName).ToString ' AddressList(0).ToString()                  
    End Sub

    'ANHQH
    '29/11/2011
    'Ham tao Menu theo User
    'Public Sub p_Create_Menu(ByRef p_Menu As MenuStrip)
    '    'Dim p_SysTem As New SystemBatch.Class1
    '    Dim p_Mod_Get_Gird As New DataTable
    '    Dim p_Menu_Dataset As New DataSet
    '    Dim p_SubMenu As New DataSet
    '    Dim p_Status As Boolean
    '    Dim p_Mnu_Index As Integer
    '    Dim p_mItem As ToolStripMenuItem
    '    Dim pAdd_FileMenuItem As New ToolStripMenuItem
    '    Dim p_SubMnu_Index As Integer

    '    Dim p_Add_Separator As New ToolStripSeparator

    '    p_Status = g_Services.Sys_Get_Menu_Submenu(g_User_ID, p_Menu_Dataset, p_SubMenu)

    '    If p_Menu.Items.Count > 0 Then
    '        p_Menu.Items.Clear()
    '    End If
    '    If p_Status = True Then
    '        For p_Mnu_Index = 0 To p_Menu_Dataset.Tables(0).Rows.Count - 1
    '            p_Menu.Items.Add(p_Menu_Dataset.Tables(0).Rows(p_Mnu_Index).Item(2).ToString)
    '            p_mItem = CType(p_Menu.Items.Item(p_Mnu_Index), ToolStripMenuItem)
    '            For p_SubMnu_Index = 0 To p_SubMenu.Tables(p_Mnu_Index).Rows.Count - 1
    '                If p_SubMnu_Index > 0 Then
    '                    p_Add_Separator = New ToolStripSeparator()
    '                    p_mItem.DropDownItems.Add(p_Add_Separator)
    '                End If
    '                Select Case UCase(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)
    '                    Case "MNUSYSTEM"
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf MDIMainForm.p_ToolStripMenuItem_Click), _
    '                                                                    p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)
    '                    Case "MNUREPORT"
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf MDIMainForm.p_ToolStripMenuItem_Click), _
    '                                                                    p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)

    '                    Case "FPTLISTS"
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf MDIMainForm.p_ToolStripMenuItem_Click), _
    '                                                                    p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)

    '                    Case "FPTSO"
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf MDIMainForm.p_ToolStripMenuItem_Click), _
    '                                                                    p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)
    '                    Case "FPTREBATE"
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf MDIMainForm.p_ToolStripMenuItem_Click), _
    '                                                                    p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)
    '                    Case "FPTMRP"
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf MDIMainForm.p_ToolStripMenuItem_Click), _
    '                                                                    p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)

    '                    Case Else
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(2).ToString)
    '                End Select
    '                pAdd_FileMenuItem.Name = p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(3).ToString & p_Mnu_Index.ToString
    '                pAdd_FileMenuItem.Tag = p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString & "." & p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(3).ToString
    '                p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
    '            Next p_SubMnu_Index
    '            'ANHQ them Submenu Thoat  vao menu dau tien
    '            If p_Mnu_Index = 0 Then
    '                p_mItem = CType(p_Menu.Items.Item(p_Mnu_Index), ToolStripMenuItem)
    '                If p_SubMnu_Index > 0 Then
    '                    p_Add_Separator = New ToolStripSeparator()
    '                    p_mItem.DropDownItems.Add(p_Add_Separator)
    '                End If
    '                pAdd_FileMenuItem = New ToolStripMenuItem("Thoát khỏi chương trình", _
    '                                                                      Nothing, _
    '                                                                        New EventHandler(AddressOf MDIMainForm.p_End))
    '                p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
    '            End If
    '        Next p_Mnu_Index

    '    End If
    'End Sub

    Public Function p_Show_Mess(ByVal p_Message_String As String, _
                                  ByVal p_Show_OK_Button As Boolean, _
                                    ByVal p_OK_Button_Text As String, _
                                    ByVal p_Show_CanCel_Button As Boolean, _
                                    ByVal p_Cancel_Button_Text As String, _
                                    ByVal p_Window_Title As String) As Integer
        Dim p_Form As New FrmDialog1
        p_Form.p_Show_OK = p_Show_OK_Button
        p_Form.p_Show_Cancel = p_Show_CanCel_Button

        p_Form.p_Message_Text = p_Message_String
        p_Form.p_Show_OK_Text = p_OK_Button_Text
        p_Form.p_Show_Cancel_Text = p_Cancel_Button_Text
        p_Form.p_Window_Title = p_Window_Title
        p_Show_Mess = p_Form.ShowDialog
    End Function

    'ANHHQ
    '21/11/2011
    'Ham thuc hien select ma fill du lieu vao p_BindingSource1 
    Public Sub Mod_Get_BindingSource(ByVal p_SQL As String, ByRef p_BindingSource1 As Windows.Forms.BindingSource)
        Dim p_DataTable As New DataTable
        'Dim p_SysTem As New SystemBatch.Class1

        'Dim p_Status As Boolean
        p_DataTable = g_Services.mod_SYS_GET_DATASET(p_SQL).Tables(0)
        p_BindingSource1.DataSource = p_DataTable
        'p_abc.DataSource = p_BindingSource1
        p_BindingSource1.ResetBindings(True)
        'p_SysTem = Nothing
    End Sub


    Public Function SysCheckLoginB1(ByVal p_LicenseServer As String, ByVal p_CompanyHost As String, ByVal p_CompanyDB As String, _
                                         ByVal p_UsrB1 As String, ByVal p_PassB1 As String, ByVal p_Port As String, _
                                         ByVal B1_UserApp As String, ByVal B1PassApp As String, _
                                         ByRef p_UserID As Double) As String

        Dim p_APICom As New Object
        Dim p_Number As Integer
        Dim lErrCode As Integer
        Dim sErrMsg As String = ""


        Dim p_SQL As String
        Dim p_Datatabale As New DataTable
        p_UserID = 0


        Try
            SysCheckLoginB1 = ""
            'p_APICom.Server = p_CompanyHost.Trim 'p_APIServer.Trim
            'p_APICom.LicenseServer = p_LicenseServer.Trim '& ":30000"
            'p_APICom.language = SAPbobsCOM.BoSuppLangs.ln_English 'p_APILangue    'SAPbobsCOM.BoSuppLangs.ln_English ' change to your language
            'p_APICom.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2008 'p_APISrvType ' SAPbobsCOM.BoDataServerTypes.dst_MSSQL2008
            'p_APICom.UseTrusted = False
            'p_APICom.DbUserName = p_UsrB1.Trim   ' p_DbUserName 'p_APIUser '' "sa"
            'p_APICom.DbPassword = p_PassB1.Trim    ' p_DbPassword ' "123456"
            'p_APICom.
            p_APICom.CompanyDB = p_CompanyDB.Trim ' "ASC_TEST"
            p_APICom.UserName = B1_UserApp.Trim    ' p_APIUser
            p_APICom.Password = B1PassApp.Trim  ' p_APIPass

            p_Number = p_APICom.Connect()
            If p_Number <> 0 Then ' if the connection failed
                p_APICom.GetLastError(lErrCode, sErrMsg)
                SysCheckLoginB1 = "ERROR: " & sErrMsg
                p_APICom = Nothing
                p_UserID = 0
            Else
                p_SQL = "SELECT USER_ID FROM [SYS_USER] where  upper([USERCODEB1])=UPPER('" & B1_UserApp & "')"
                p_Datatabale = g_Services.mod_SYS_GET_DATATABLE(p_SQL)
                If Not p_Datatabale Is Nothing Then
                    If p_Datatabale.Rows.Count > 0 Then
                        If p_Datatabale.Rows(0).Item("USER_ID") > 0 Then
                            p_UserID = p_Datatabale.Rows(0).Item("USER_ID")
                        End If
                    End If
                End If
                g_CompanyAPI = p_APICom
                p_Datatabale = Nothing
                'p_APICom = Nothing
                SysCheckLoginB1 = "TRUE"
            End If

        Catch ex As Exception
            SysCheckLoginB1 = "ERROR"
            p_UserID = 0
            p_APICom = Nothing
        End Try

    End Function

    Public Sub p_CreateView()
        Dim p_SQL As String
        Dim p_Desc As String = ""
        Try
            p_SQL = "Exec FPT_CreateView"
            If g_Services.Sys_Execute_Com(p_Company_Host, p_User_Database, _
                                             p_DBUser, p_DBPass, p_Port, _
                                               p_SQL, _
                                                   p_Desc) = False Then
                MsgBox(p_Desc)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



End Module
