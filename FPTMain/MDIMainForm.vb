Imports System.Windows.Forms
Imports System.Net
Imports System.Net.Dns
Imports System.Reflection
Imports System.IO
'Imports FTPREPORT
Imports System.Drawing

Public Class MDIMainForm

    Private p_CreateMenu As Boolean = True

    Private p_Relogin As Boolean = False

    Public Property Redologin() As Boolean
        Get
            Return p_Relogin
        End Get
        Set(ByVal value As Boolean)
            p_Relogin = value
        End Set
    End Property

    Public Property CreateMenu() As Boolean
        Get
            Return p_CreateMenu
        End Get
        Set(ByVal value As Boolean)
            p_CreateMenu = value
        End Set
    End Property

    Private p_Status As String
    Private Declare Function InternetCloseHandle Lib "wininet.dll" (ByVal HINet As Integer) As Integer
    Private Declare Function InternetOpen Lib "wininet.dll" Alias "InternetOpenA" (ByVal sAgent As String, ByVal lAccessType As Integer, ByVal sProxyName As String, ByVal sProxyBypass As String, ByVal lFlags As Integer) As Integer
    Private Declare Function InternetConnect Lib "wininet.dll" Alias "InternetConnectA" (ByVal hInternetSession As Integer, ByVal sServerName As String, ByVal nServerPort As Integer, ByVal sUsername As String, ByVal sPassword As String, ByVal lService As Integer, ByVal lFlags As Integer, ByVal lContext As Integer) As Integer
    Private Declare Function FtpGetFile Lib "wininet.dll" Alias "FtpGetFileA" (ByVal hFtpSession As Integer, ByVal lpszRemoteFile As String, ByVal lpszNewFile As String, ByVal fFailIfExists As Boolean, ByVal dwFlagsAndAttributes As Integer, ByVal dwFlags As Integer, ByVal dwContext As Integer) As Boolean
    Private Declare Function FtpPutFile Lib "wininet.dll" Alias "FtpPutFileA" (ByVal hFtpSession As Integer, ByVal lpszLocalFile As String, ByVal lpszRemoteFile As String, ByVal dwFlags As Integer, ByVal dwContext As Integer) As Boolean

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Public Sub New()
        'g_Services = p_Services
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub MDIMainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        System.Diagnostics.Process.GetCurrentProcess.CloseMainWindow()
        System.Diagnostics.Process.GetCurrentProcess.Close()
        System.Diagnostics.Process.GetCurrentProcess.Kill()
        Application.ExitThread()
    End Sub

 




    Private Sub MDIMainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim p_Err As String = ""
        ' Dim p_DataTable As DataTable


        'GetSource(Nothing)
        Me.ToolStripStatusLabel1.Text = ""
        Me.ToolStripStatusLabel2.Text = ""
        Me.ToolStripStatusLabel3.Text = ""

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        Dim p_LoginForm As New LoginForm1
        Dim p_DataSet As DataSet
        Dim p_DataTable As DataTable
        Dim p_DataTable1 As DataTable
        Dim p_DataTable3 As DataTable
        Dim p_ArrRow() As DataRow

        Dim p_SQL As String = ""

        Dim p_Login As Boolean = False
        'Tao file Scadar neu chua co

        Dim anm As System.Reflection.AssemblyName




        'Dim p_XML As String = Application.StartupPath & "\TempHD.xml"
        'Dim p_DtSet As New DataSet
        'p_DtSet.ReadXml(p_XML)

        'p_SQL = "select * from tblConfig"
        p_SQL = "select * from tblConfig; select * from FPT_Login_Client; select * from tblKho where  MaKho in (select WareHouse from tblConfig);" 

        ' MsgBox("aaaa")
        Try
            p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)
        Catch ex As Exception
            MsgBox("bbbb:" & ex.Message)
        End Try



        ' MsgBox("aaaa1111")
        If Not p_DataSet Is Nothing Then
            Try
                p_DataTable = p_DataSet.Tables(0)
                p_DataTable1 = p_DataSet.Tables(1)
                ' p_DataTable3 = p_DataSet.Tables(3)
            Catch ex As Exception
                MsgBox("tblConfig:" & ex.Message.ToString)
                Exit Sub
            End Try

        Else
            ' MsgBox("Lỗi khi lấy tham số tblConfig")

            If MsgBox("Không kết nối được máy chủ. Bạn có muốn thực hiện cấu hình kết nối không?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Chú ý") = MsgBoxResult.Yes Then
                p_LoginForm.ShowDialog(Me)
                p_Login = True
            Else
                Exit Sub
            End If

        End If
        'If Not p_DataTable3 Is Nothing Then
        '    If p_DataTable3.Rows.Count > 0 Then
        '        p_ArrRow = p_DataTable3.Select("KeyCode='FILTERKHO'")
        '        If p_ArrRow.Length > 0 Then
        '            If p_ArrRow(0).Item("KeyValue").ToString.Trim = "Y" Then
        '                g_Filter_Terminal = True
        '            End If
        '        End If
        '    End If
        'End If

        '  p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                g_Company_Code = p_DataTable.Rows(0).Item("companycode").ToString.Trim
                g_WareHouse = p_DataTable.Rows(0).Item("WareHouse").ToString.Trim

            End If
        End If
        If p_DataTable1.Rows.Count > 0 Then
            g_LoginClient = p_DataTable1.Rows(0).Item("CompanyCode").ToString.Trim
        End If
        If p_Login = False Then
            p_LoginForm.ShowDialog(Me)
        End If



        p_SQL = "exec FPT_CreateTanlActive"

        Try

            p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_SQL = "TRUE"
                Else
                    p_SQL = "FALSE"
                End If
            End If


            Mod_IPAddress()

            '20250520 bo đi vì đã treo menu để thực hiện
            ''CreateTable()

            'If CreateMenu = True Then
            p_Create_Menu()
            CreateField()
            ' End If
            'p_Create_Menu()
            'If p_LoginForm.Relogin = True Then
            '    RemoveMenu(Me.MenuStrip1)
            'End If

            'GetCurrencyList()

            'Me.Text = "" & g_Company_Code & "-" & p_Company_Name & " (" & p_User_Database & ") - " & g_UserName

            p_DataTable = p_DataSet.Tables(2)
            ' p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des("select * from tblKho where  MaKho='" & g_WareHouse & "'", p_Err) 'GetDataTable("select * from tblKho  MaKho='" & g_WareHouse & "'")
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    Me.ToolStripStatusLabel4.Text = UCase(p_DataTable.Rows(0).Item("TenKho").ToString.Trim)
                End If

            End If
            p_DataTable = Nothing
            p_DataTable1 = Nothing
            p_DataSet = Nothing
            
            p_SQL = "INSERT INTO [dbo].[SYS_USER_Login]([USER_NAME],[LAST_LOGON_DATE] " & _
                                ",[LOGIN_WORK_STATION] ,[LOGIN_IP_ADDRESS], Client)"
            p_SQL = p_SQL & " VALUES ('" & g_UserName & "',getdate(), '" & g_GetHostName & "','" & g_IP_Address & "','" & g_Config_XMLDatatable.Rows(0).Item("Client") & "') "

            If g_Services.Sys_Execute(p_SQL, _
                                         p_SQL) = False Then

            End If

            p_SQL = Application.StartupPath & "\HTTG.exe"

            If File.Exists(p_SQL) = True Then
                'p_SQL = CDate(File.GetCreationTime(p_SQL)).ToString("dd/MM/yyyy hh:mm:ss tt")
                p_SQL = CDate(File.GetLastWriteTime(p_SQL)).ToString("dd/MM/yyyy hh:mm:ss tt")
                Me.Text = Me.Text & " - Ngày cập nhập: " & p_SQL
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub p_ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_clickedMenuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        Dim p_Form_Name As String
        Dim p_Project_Code As String
        Dim p_Function_String As String = ""
        Dim p_Function_ID As Integer = 0
        'MessageBox.Show("You clicked the menu item tag: " & p_clickedMenuItem.Tag)
        p_Form_Name = p_clickedMenuItem.Tag
        If p_Form_Name.LastIndexOf(".") = -1 Then

        Else
            p_Function_String = Mid(p_Form_Name, p_Form_Name.LastIndexOf(";") + 2)
            Try
                Integer.TryParse(p_Function_String.ToString.Trim, p_Function_ID)
            Catch ex As Exception

            End Try
            p_Form_Name = Replace(p_Form_Name, ";" & p_Function_String, "", 1)
        End If

        p_Project_Code = p_Form_Name
        If p_Form_Name.LastIndexOf(".") = -1 Then
        Else
            p_Form_Name = Mid(p_Form_Name, p_Form_Name.LastIndexOf(".") + 2)
            p_Project_Code = Mid(p_Project_Code, 1, p_Project_Code.LastIndexOf("."))
        End If
        Call p_Show_FormHT(p_Project_Code, p_Form_Name, p_Function_ID)
    End Sub




    'ANHQH
    '29/11/2011
    'Ham thuc hien show form cho menu MnuSysTem
    Public Sub p_Show_FormHT(ByVal p_Project_Code As String, ByVal p_Form As String, ByVal p_Function_Id As Integer)

        ' Dim p_MnuReport_ShowForm As New MnuReport.Class1
        Select Case UCase(p_Project_Code)
            Case "MNUSYSTEM"
                Dim p_MnuSystem_ShowForm As New MnuSystem.Class1(g_Company_Code, g_Services, p_UsrB1, p_PassB1, p_Port, _
                                                                p_Company_Host, p_User_Database, g_UserName, p_LicenceHost, _
                                                                p_DBUser, p_DBPass, g_CompanyAPI, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel1)
                p_MnuSystem_ShowForm.P_Show_Form(Me, p_Form, p_User_Database, _
                                                    g_User_ID, p_Company_ID, p_Company_Host, p_Function_Id)
            Case "FPTLISTS"
                Dim p_FptLists_ShowForm As New FPTLISTS.Class1(g_Company_Code, g_Services, p_UsrB1, p_PassB1, p_Port, _
                                                                p_Company_Host, p_User_Database, g_UserName, p_LicenceHost, _
                                                                p_DBUser, p_DBPass, g_CompanyAPI, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel1)
                p_FptLists_ShowForm.P_Show_Form(Me, p_Form, p_User_Database, _
                                                    g_User_ID, p_Company_ID, p_Company_Host, p_Function_Id)
            Case "FPTSO"
                Dim p_FptSO_ShowForm As New FPTSO.Class1(g_Config_XMLDatatable, g_Company_Code, g_WareHouse, g_Services, p_UsrB1, p_PassB1, p_Port, _
                                                                p_Company_Host, p_User_Database, g_UserName, p_LicenceHost, _
                                                                p_DBUser, p_DBPass, g_CompanyAPI, Nothing, Me.ToolStripStatusLabel1, Me.ToolStrip1)
                p_FptSO_ShowForm.P_Show_Form(Me, p_Form, p_User_Database, _
                                                    g_User_ID, p_Company_ID, p_Company_Host, p_Function_Id)
            Case "FPTUPDATE"
                Dim p_FptUpdate_ShowForm As New FPTUpdate.UpdateCls(g_Config_XMLDatatable, g_Company_Code, g_WareHouse, g_Services, p_UsrB1, p_PassB1, p_Port, _
                                                                p_Company_Host, p_User_Database, g_UserName, p_LicenceHost, _
                                                                p_DBUser, p_DBPass, g_CompanyAPI, Nothing, Me.ToolStripStatusLabel1, Me.ToolStrip1)
                p_FptUpdate_ShowForm.P_Show_Form(Me, p_Form, p_User_Database, _
                                                    g_User_ID, p_Company_ID, p_Company_Host, p_Function_Id)
                'Case "FPTMRP"
                '    Dim p_FptMRP_ShowForm As New FPTMRP.Class1(g_Company_Code, g_Services, p_UsrB1, p_PassB1, p_Port, _
                '                                                    p_Company_Host, p_User_Database, g_UserName, p_LicenceHost, _
                '                                                    p_DBUser, p_DBPass, g_CompanyAPI, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel1)
                '    p_FptMRP_ShowForm.P_Show_Form(Me, p_Form, p_User_Database, _
                '                                        g_User_ID, p_Company_ID, p_Company_Host, p_Function_Id)
                'Case "FPTREBATE"
                '    Dim p_FptRebate_ShowForm As New FPTREBATE.RebateCls(g_Company_Code, g_Services, p_DBUser, p_DBPass, p_Port, p_Company_Host, p_User_Database, g_UserName)
                '    p_FptRebate_ShowForm.P_Show_Form(Me, p_Form, p_User_Database, _
                '                                        g_User_ID, p_Company_ID, p_Company_Host)
                'Case "FPTMRP"
                '    Dim p_FptMrp_ShowForm As New FPTMRP.MRPCls(g_Company_Code, g_Services, p_UsrB1, p_PassB1, p_Port, _
                '                                                    p_Company_Host, p_User_Database, g_UserName, p_LicenceHost, _
                '                                                    p_DBUser, p_DBPass, g_CompanyAPI)

                '    p_FptMrp_ShowForm.P_Show_Form(Me, p_Form, p_User_Database, _
                '                                        g_User_ID, p_Company_ID, p_Company_Host)

                'Case "FPTREPORT"
                '    Dim p_FptReport_ShowForm As New FPTReport.Class1(g_Company_Code, g_Services, p_UsrB1, p_PassB1, p_Port, _
                '                                                    p_Company_Host, p_User_Database, g_UserName, p_LicenceHost, _
                '                                                    p_DBUser, p_DBPass, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel1)
                '    p_FptReport_ShowForm.P_Show_Form(Me, p_Form, p_User_Database, _
                '                                        g_User_ID, p_Company_ID, p_Company_Host)
            Case UCase("ReportSetup")
                Dim p_Report_ShowForm As New ReportSetup.Class1(g_Config_XMLDatatable, g_Company_Code, g_WareHouse, g_Services, p_UsrB1, p_PassB1, p_Port, _
                                                                p_Company_Host, p_User_Database, g_UserName, p_LicenceHost, _
                                                                p_DBUser, p_DBPass, g_CompanyAPI, Nothing, Me.ToolStripStatusLabel1, Me.ToolStrip1)
                p_Report_ShowForm.P_Show_Form(Me, p_Form, p_User_Database, _
                                                    g_User_ID, p_Company_ID, p_Company_Host, p_Function_Id)
        End Select
    End Sub


    Public Sub p_End()
        Dim p_Value As Integer
        p_Value = p_Show_Mess("Bạn có chắc chắn thực hiện không?", True, "Có", True, "Không", "Thông báo")
        If p_Value = 1 Then

            System.Diagnostics.Process.GetCurrentProcess.CloseMainWindow()
            System.Diagnostics.Process.GetCurrentProcess.Close()
            System.Diagnostics.Process.GetCurrentProcess.Kill()
            Application.ExitThread()


            ' Application.Exit()
        End If
    End Sub



    Public Sub ReLogin()
        Dim p_Login As New LoginForm1
        p_Login.Relogin = True
        p_Login.ShowDialog(Me)
    End Sub

    Public Sub LenhXuat_THN()
        Dim p_FptSO_ShowForm As New FPTSO.Class1(g_Config_XMLDatatable, g_Company_Code, g_WareHouse, g_Services, p_UsrB1, p_PassB1, p_Port, _
                                                               p_Company_Host, p_User_Database, g_UserName, p_LicenceHost, _
                                                               p_DBUser, p_DBPass, g_CompanyAPI, Nothing, Me.ToolStripStatusLabel1, Me.ToolStrip1)
        p_FptSO_ShowForm.clsSoLenh_THN_Show()
    End Sub


    Public Sub DongBoChiTietPtien()
        Dim p_FptLists_ShowForm As New FPTLISTS.Class1(g_Company_Code, g_Services, p_UsrB1, p_PassB1, p_Port, _
                                                                p_Company_Host, p_User_Database, g_UserName, p_LicenceHost, _
                                                                p_DBUser, p_DBPass, g_CompanyAPI, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel1)
        p_FptLists_ShowForm.clsDongBoChiTietPT_Show()
    End Sub


    Public Sub KiemKe()
        Dim p_FptSO_ShowForm As New FPTSO.Class1(g_Config_XMLDatatable, g_Company_Code, g_WareHouse, g_Services, p_UsrB1, p_PassB1, p_Port, _
                                                               p_Company_Host, p_User_Database, g_UserName, p_LicenceHost, _
                                                               p_DBUser, p_DBPass, g_CompanyAPI, Nothing, Me.ToolStripStatusLabel1, Me.ToolStrip1)
        p_FptSO_ShowForm.clsKiemke_Show()
    End Sub


    Public Sub DBUpdate()
        CreateTable()
    End Sub



    'Private Sub HfghfgToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HfghfgToolStripMenuItem.Click

    'End Sub

    'Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    'End Sub

    

    Public Sub RemoveMenu()
        Dim p_Count As Integer
        Dim p_Object() As Object

        Dim p_FormOpen
        Try
            p_FormOpen = Application.OpenForms
            'Close form open
            For p_Count = p_FormOpen.Count - 1 To 0 Step -1
                If UCase(p_FormOpen(p_Count).Name) <> UCase(Me.Name) And UCase(p_FormOpen(p_Count).Name) <> UCase("LoginForm1") Then
                    p_FormOpen(p_Count).Close()
                End If
            Next
            


            p_Object = Me.Controls.Find("MenuStrip1", True)

            For p_Count = p_Object.Length - 1 To 0 Step -1
                'If p_Object.Length > 0 Then
                Me.Controls.Remove(p_Object(p_Count))
                ' End If
            Next
            '  p_Count = p_Menu.Items.Count
            'For Each p_Obj In Me.Controls
            '    p_Count = 1
            'Next

            'Try
            '    'Me.Controls.Remove("MenuStrip1")
            'Catch ex As Exception

            'End Try
            'Me.Controls.Remove(Me.MenuStrip1)
            'For p_Count = Me.MenuStrip1.Items.Count - 1 To 0 Step -1
            '    Me.MenuStrip1.Items.RemoveAt(p_Count)
            'Next
            'p_Menu.Refresh()
            Me.Refresh()

            p_Create_Menu()
        Catch ex As Exception

        End Try

    End Sub

    Public Sub p_Create_Menu()
        'Dim p_SysTem As New SystemBatch.Class1

        Dim p_Menu As New MenuStrip

        Dim p_DataSet As DataSet
        Dim p_DataTable As DataTable
        Dim p_DataTable1 As DataTable

        Dim p_Mod_Get_Gird As New DataTable
        Dim p_Menu_Dataset As New DataSet
        Dim p_SubMenu As New DataSet
        Dim p_Status As Boolean
        Dim p_Mnu_Index As Integer
        Dim p_mItem As ToolStripMenuItem

        Dim pAdd_FileMenuItem As New ToolStripMenuItem

        Dim p_Menu1 As New MenuStrip
        Dim p_Add_Separator As New ToolStripSeparator
        Dim p_SubMenuChild As New DataSet
        Dim p_DataTbl As New DataTable
        Dim p_Err As String = ""

        Dim p_Path As String = ""
        Dim p_Path_File As String
        Dim p_ParentIndex As Integer = 0

        Dim p_FptModule As New FPTModule.Class1(g_UserName, g_Company_Code, g_Services, p_UsrB1, p_PassB1, p_Port, p_Company_Host, p_User_Database, p_DataTbl, "VND")

        p_Path = Application.StartupPath & "\Images"

        If System.IO.Directory.Exists(p_Path) = False Then
            p_Path = Application.StartupPath & "\"
        End If


        Me.Controls.Add(p_Menu)
        p_Menu.Name = "MenuStrip1"

        'p_Menu.Font.Styl = New System.Drawing.Size(230, 30)
        p_Menu.Dock = DockStyle.Top
        Me.Refresh()
        p_Status = g_Services.Sys_Get_Menu_Submenu(g_User_ID, p_Menu_Dataset, p_SubMenu, p_Err, g_DBTYPE)
        ' p_Status = Sys_Get_Menu_Submenu(g_User_ID, p_Menu_Dataset, p_SubMenu)

        If p_Menu.Items.Count > 0 Then
            p_Menu.Items.Clear()
        End If
        If p_Status = True Then
            For p_Mnu_Index = 0 To p_Menu_Dataset.Tables(0).Rows.Count - 1

                p_Path_File = p_Path & p_Menu_Dataset.Tables(0).Rows(p_Mnu_Index).Item("Icon_File").ToString.Trim

                If System.IO.File.Exists(p_Path_File) = True Then
                    If p_Mnu_Index = 0 Then
                        'p_Menu.Items.Add("&" & p_Mnu_Index + 1 & ". " & p_Menu_Dataset.Tables(0).Rows(p_Mnu_Index).Item(2).ToString, Image.FromFile(p_Path_File))
                        p_Menu.Items.Add(p_Menu_Dataset.Tables(0).Rows(p_Mnu_Index).Item(2).ToString, Image.FromFile(p_Path_File))
                    Else
                        'p_Menu.Items.Add("&" & p_Mnu_Index + 1 & ". " & p_Menu_Dataset.Tables(0).Rows(p_Mnu_Index).Item(2).ToString, Image.FromFile(p_Path_File))
                        p_Menu.Items.Add(p_Menu_Dataset.Tables(0).Rows(p_Mnu_Index).Item(2).ToString, Image.FromFile(p_Path_File))
                    End If
                Else
                    If p_Mnu_Index = 0 Then
                        '                        p_Menu.Items.Add("&" & p_Mnu_Index + 1 & ". " & p_Menu_Dataset.Tables(0).Rows(p_Mnu_Index).Item(2).ToString)
                        p_Menu.Items.Add("&" & p_Mnu_Index + 1 & ". " & p_Menu_Dataset.Tables(0).Rows(p_Mnu_Index).Item(2).ToString)
                    Else
                        'p_Menu.Items.Add("&" & p_Mnu_Index + 1 & ". " & p_Menu_Dataset.Tables(0).Rows(p_Mnu_Index).Item(2).ToString)
                        p_Menu.Items.Add("&" & p_Mnu_Index + 1 & ". " & p_Menu_Dataset.Tables(0).Rows(p_Mnu_Index).Item(2).ToString)
                    End If

                End If

                
                p_ParentIndex = p_Mnu_Index + 1
                p_mItem = CType(p_Menu.Items.Item(p_Mnu_Index), ToolStripMenuItem)

                p_Status = p_FptModule.p_ModSys_Get_Menu_SubmenuChild(g_User_ID, p_Menu_Dataset.Tables(0).Rows(p_Mnu_Index).Item(3).ToString, p_SubMenuChild, g_DBTYPE)  'p_SubMenu)

                If Not p_SubMenuChild Is Nothing Then
                    If p_SubMenuChild.Tables(0).Rows.Count > 0 Then
                        '  Exit Sub


                        If p_SubMenuChild.Tables.Count > 0 Then


                            p_Sys_Create_Menu(p_Menu, p_Menu_Dataset.Tables(0).Rows(p_Mnu_Index).Item(3).ToString, p_mItem, p_ParentIndex)

                        End If
                        If p_Mnu_Index = 0 Then


                            p_mItem = CType(p_Menu.Items.Item(p_Mnu_Index), ToolStripMenuItem)

                            If Exists_Form("FrmSoLenh_THN") = False Then
                                If p_mItem.DropDownItems.Count > 0 Then
                                    p_Add_Separator = New ToolStripSeparator()
                                    p_mItem.DropDownItems.Add(p_Add_Separator)
                                End If
                                pAdd_FileMenuItem = New ToolStripMenuItem("Danh sách lệnh đồng bộ về HTTG", _
                                                                                         Nothing, _
                                                                                            New EventHandler(AddressOf LenhXuat_THN))
                                p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
                            End If

                            'FrmVehicleDetail

                            If Exists_Form("FrmKiemKe") = False Then
                                If p_mItem.DropDownItems.Count > 0 Then
                                    p_Add_Separator = New ToolStripSeparator()
                                    p_mItem.DropDownItems.Add(p_Add_Separator)
                                End If
                                pAdd_FileMenuItem = New ToolStripMenuItem("Danh sách thời gian kiểm kê", _
                                                                                         Nothing, _
                                                                                            New EventHandler(AddressOf KiemKe))
                                p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
                            End If

                            If Exists_Form("FrmVehicleDetail") = False Then
                                If p_mItem.DropDownItems.Count > 0 Then
                                    p_Add_Separator = New ToolStripSeparator()
                                    p_mItem.DropDownItems.Add(p_Add_Separator)
                                End If
                                pAdd_FileMenuItem = New ToolStripMenuItem("Đồng bộ chi tiết phương tiện", _
                                                                                         Nothing, _
                                                                                            New EventHandler(AddressOf DongBoChiTietPtien))
                                p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
                            End If



                            If p_mItem.DropDownItems.Count > 0 Then
                                p_Add_Separator = New ToolStripSeparator()
                                p_mItem.DropDownItems.Add(p_Add_Separator)
                            End If
                            p_Path_File = p_Path & "unlock.ico"
                            If System.IO.File.Exists(p_Path_File) = True Then
                                pAdd_FileMenuItem = New ToolStripMenuItem("Đăng nhập lại", _
                                                                                      Image.FromFile(p_Path_File), _
                                                                                        New EventHandler(AddressOf ReLogin))
                            Else

                                pAdd_FileMenuItem = New ToolStripMenuItem("Đăng nhập lại", _
                                                                                     Nothing, _
                                                                                        New EventHandler(AddressOf ReLogin))
                            End If
                            p_mItem.DropDownItems.Add(pAdd_FileMenuItem)

                            

                            'LenhXuat_THN
                            p_mItem = CType(p_Menu.Items.Item(p_Mnu_Index), ToolStripMenuItem)
                            If p_mItem.DropDownItems.Count > 0 Then
                                p_Add_Separator = New ToolStripSeparator()
                                p_mItem.DropDownItems.Add(p_Add_Separator)
                            End If
                            '20250520 Bo sung dung rieng cho cap nhat table, field.. dưới DB
                            pAdd_FileMenuItem = New ToolStripMenuItem("Cập nhật bổ sung Table, field..", _
                                                                                   Nothing, _
                                                                                      New EventHandler(AddressOf DBUpdate))
                            p_mItem.DropDownItems.Add(pAdd_FileMenuItem)


                            p_mItem = CType(p_Menu.Items.Item(p_Mnu_Index), ToolStripMenuItem)
                            If p_mItem.DropDownItems.Count > 0 Then
                                p_Add_Separator = New ToolStripSeparator()
                                p_mItem.DropDownItems.Add(p_Add_Separator)
                            End If

                            p_Path_File = p_Path & "cancel.ico"

                            If System.IO.File.Exists(p_Path_File) = True Then
                                pAdd_FileMenuItem = New ToolStripMenuItem("Thoát khỏi chương trình", _
                                                                                       Image.FromFile(p_Path_File), _
                                                                                        New EventHandler(AddressOf p_End))
                            Else
                                pAdd_FileMenuItem = New ToolStripMenuItem("Thoát khỏi chương trình", _
                                                                                      Nothing, _
                                                                                       New EventHandler(AddressOf p_End))
                            End If
                            p_mItem.DropDownItems.Add(pAdd_FileMenuItem)

                            ' Else

                        End If
                        End If
                    End If

            Next p_Mnu_Index



            'pAdd_FileMenuItem = New ToolStripMenuItem("&" & p_Mnu_Index + 1 & "." & "Cập nhật", _
            '                                                                     Nothing, _
            '                                                                       New EventHandler(AddressOf p_End))

        End If
        'p_Status =
        Me.ToolStripStatusLabel1.Text = "IP: " & g_IP_Address & "        Computer: " & g_GetHostName & "         User: " & g_UserName
        ' Me.ToolStripStatusLabel2.Text = ""
        'Me.ToolStripStatusLabel2.Visible = True
        'Me.ToolStripStatusLabel3.Text = ""
        'Me.ToolStripStatusLabel4.Text = ""
        
        Me.Timer1.Interval = 1000
        Me.Timer1.Enabled = True
        CreateMenu = False
        Redologin = False
    End Sub


    Private Sub CreateMenuUpdate(ByRef p_Menu As MenuStrip, ByVal p_Mnu_Index As Integer)
        Dim p_mItem As ToolStripMenuItem
        Dim p_Add_Separator As ToolStripSeparator
        Dim pAdd_FileMenuItem As ToolStripMenuItem

        Exit Sub
        p_Menu.Items.Add("&" & p_Mnu_Index + 1 & ". Cập nhật")

        p_mItem = CType(p_Menu.Items.Item(p_Mnu_Index), ToolStripMenuItem)
        If p_mItem.DropDownItems.Count > 0 Then
            p_Add_Separator = New ToolStripSeparator()
            p_mItem.DropDownItems.Add(p_Add_Separator)
        End If
        pAdd_FileMenuItem = New ToolStripMenuItem("Chuyển bản ghi sau", _
                                                              Nothing, _
                                                                New EventHandler(AddressOf p_End))
        ' pAdd_FileMenuItem.
        p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
        If p_mItem.DropDownItems.Count > 0 Then
            p_Add_Separator = New ToolStripSeparator()
            p_mItem.DropDownItems.Add(p_Add_Separator)
        End If
        pAdd_FileMenuItem = New ToolStripMenuItem("Chuyển bản ghi trước", _
                                                             Nothing, _
                                                               New EventHandler(AddressOf p_End))
        p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
        If p_mItem.DropDownItems.Count > 0 Then
            p_Add_Separator = New ToolStripSeparator()
            p_mItem.DropDownItems.Add(p_Add_Separator)
        End If
        pAdd_FileMenuItem = New ToolStripMenuItem("Chuyển trang sau", _
                                                             Nothing, _
                                                               New EventHandler(AddressOf p_End))
        p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
        If p_mItem.DropDownItems.Count > 0 Then
            p_Add_Separator = New ToolStripSeparator()
            p_mItem.DropDownItems.Add(p_Add_Separator)
        End If
        pAdd_FileMenuItem = New ToolStripMenuItem("Chuyển trang trước", _
                                                            Nothing, _
                                                              New EventHandler(AddressOf p_End))
        p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
        If p_mItem.DropDownItems.Count > 0 Then
            p_Add_Separator = New ToolStripSeparator()
            p_mItem.DropDownItems.Add(p_Add_Separator)
        End If
        pAdd_FileMenuItem = New ToolStripMenuItem("Thêm mới bản ghi", _
                                                            Nothing, _
                                                              New EventHandler(AddressOf p_End))
        p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
        If p_mItem.DropDownItems.Count > 0 Then
            p_Add_Separator = New ToolStripSeparator()
            p_mItem.DropDownItems.Add(p_Add_Separator)
        End If
        pAdd_FileMenuItem = New ToolStripMenuItem("Lưu bản ghi", _
                                                            Nothing, _
                                                              New EventHandler(AddressOf p_End))
        p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
        If p_mItem.DropDownItems.Count > 0 Then
            p_Add_Separator = New ToolStripSeparator()
            p_mItem.DropDownItems.Add(p_Add_Separator)
        End If
        pAdd_FileMenuItem = New ToolStripMenuItem("Hủy thay đổi", _
                                                            Nothing, _
                                                              New EventHandler(AddressOf p_End))
        p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
        If p_mItem.DropDownItems.Count > 0 Then
            p_Add_Separator = New ToolStripSeparator()
            p_mItem.DropDownItems.Add(p_Add_Separator)
        End If
        pAdd_FileMenuItem = New ToolStripMenuItem("Xóa bản ghi", _
                                                            Nothing, _
                                                              New EventHandler(AddressOf p_End))
        p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
    End Sub


    'Public Sub p_Sys_Create_Menu(ByRef p_Menu As MenuStrip, ByVal p_Menu_Name As String, _
    '                                 ByRef p_mItem As ToolStripMenuItem, _
    '                                  Optional ByVal p_ParentIndex As Integer = 0)
    '    Dim p_Mod_Get_Gird As New DataTable
    '    Dim p_Menu_Dataset As New DataSet
    '    Dim p_Mnu_Index As Integer

    '    Dim pAdd_FileMenuItem As New ToolStripMenuItem
    '    Dim p_Count As Integer
    '    Dim p_Datarow() As DataRow
    '    Dim p_DatarowChild() As DataRow

    '    Dim p_Menu1 As New MenuStrip
    '    Dim p_Add_Separator As New ToolStripSeparator
    '    Dim p_Abc As ToolStripMenuItem
    '    Dim p_SubMenuChild As New DataTable
    '    Dim p_DataTbl As New DataTable

    '    Dim p_Path As String
    '    Dim p_Path_File As String

    '    p_Path = Application.StartupPath & "\Images\"

    '    Dim p_FptModule As New FPTModule.Class1(g_UserName, g_Company_Code, g_Services, p_UsrB1, p_PassB1, p_Port, p_Company_Host, p_User_Database, p_DataTbl, "VND")



    '    p_SubMenuChild = p_FptModule.p_ModSys_Get_Menu_SubmenuChildNew(g_User_ID, g_DBTYPE)

    '    If p_SubMenuChild Is Nothing Then
    '        Exit Sub
    '    End If


    '    If p_SubMenuChild.Rows.Count > 0 Then

    '        p_Datarow = p_SubMenuChild.Select("SubMenu is not null and SubMenu<>'' and MENU_CODE='" & p_Menu_Name & "'")

    '        For p_Count = 0 To p_Datarow.Length - 1

    '            p_Abc = p_mItem.DropDownItems.Add(p_Datarow(p_Count).Item(5).ToString)
    '            p_Abc.Name = p_Datarow(p_Count).Item(5).ToString
    '            p_Abc.Text = p_Datarow(p_Count).Item(6).ToString

    '            p_DatarowChild = p_SubMenuChild.Select("MENU_CODE='" & p_Datarow(p_Count).Item(5).ToString & "'")

    '            For p_SubMnu_Index1 = 0 To p_DatarowChild.Length - 1
    '                If p_Datarow(p_Count).Item(5).ToString <> "" Then
    '                    p_Sys_Create_Menu(p_Menu, p_DatarowChild(p_SubMnu_Index1).Item(1).ToString, p_Abc)
    '                End If
    '                If p_Abc.DropDownItems.Count > 0 Then
    '                    p_Add_Separator = New ToolStripSeparator()
    '                    p_Abc.DropDownItems.Add(p_Add_Separator)
    '                End If
    '                Select Case Len(p_DatarowChild(p_SubMnu_Index1).Item(4).ToString) 'UCase(p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)
    '                    'Case "MNUSYSTEM", "FPTREPORT", "FPTLISTS", "FPTSO", "FPTUPDATE", "FPTMRP"
    '                    '    'pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
    '                    '    '                                          Nothing, _
    '                    '    '                                            New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '    'p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)


    '                    '    If p_Datarow(p_Count).Item("icon_file").ToString <> " " Then
    '                    '        p_Path_File = p_Path & p_Datarow(p_Count).Item("icon_file").ToString
    '                    '        Try
    '                    '            pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
    '                    '                                              Image.FromFile(p_Path_File), _
    '                    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '                            p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)

    '                    '        Catch ex As Exception
    '                    '            pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
    '                    '                                              Nothing, _
    '                    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '                            p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)

    '                    '        End Try
    '                    '    Else
    '                    '        pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
    '                    '                                              Nothing, _
    '                    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '            p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)

    '                    '    End If


    '                    '    'pAdd_FileMenuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
    '                    '    'pAdd_FileMenuItem.Image.
    '                    '    'Case ("FPTREPORT")
    '                    '    '    pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
    '                    '    '                                              Nothing, _
    '                    '    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '    '                                                p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)

    '                    '    'Case "FPTLISTS"
    '                    '    '    pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
    '                    '    '                                              Nothing, _
    '                    '    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '    '                                                p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)

    '                    '    'Case "FPTSO"
    '                    '    '    pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
    '                    '    '                                              Nothing, _
    '                    '    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '    '                                                p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)
    '                    '    '    'Case "FPTREBATE"
    '                    '    '    '    pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
    '                    '    '    '                                              Nothing, _
    '                    '    '    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '    '    '                                                p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)
    '                    '    'Case "FPTUPDATE"
    '                    '    '    pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
    '                    '    '                                              Nothing, _
    '                    '    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '    '                                                p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)

    '                    '    'Case "FPTMRP"
    '                    '    '    pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
    '                    '    '                                              Nothing, _
    '                    '    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '    '                                                p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)

    '                    Case 0
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString)
    '                    Case Else
    '                        If p_Datarow(p_Count).Item("icon_file").ToString <> " " Then
    '                            p_Path_File = p_Path & p_Datarow(p_Count).Item("icon_file").ToString
    '                            Try
    '                                pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
    '                                                                  Image.FromFile(p_Path_File), _
    '                                                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                                                p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)

    '                            Catch ex As Exception
    '                                pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                                                p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)

    '                            End Try
    '                        Else
    '                            pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                                p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)

    '                        End If
    '                End Select
    '                pAdd_FileMenuItem.Name = p_DatarowChild(p_SubMnu_Index1).Item(3).ToString & p_Mnu_Index.ToString

    '                pAdd_FileMenuItem.Tag = p_DatarowChild(p_SubMnu_Index1).Item(4).ToString & "." & p_DatarowChild(p_SubMnu_Index1).Item(3).ToString & ";" & p_Datarow(p_Count).Item("FUNCTION_ID").ToString.Trim
    '                p_Abc.DropDownItems.Add(pAdd_FileMenuItem)
    '            Next p_SubMnu_Index1
    '            ' End If
    '        Next

    '        p_Datarow = p_SubMenuChild.Select("( SubMenu is  null or SubMenu ='' ) and MENU_CODE='" & p_Menu_Name.Trim & "'")
    '        For p_Count = 0 To p_Datarow.Length - 1

    '            If UCase(p_Datarow(p_Count).Item(4).ToString) <> "" Then
    '                If p_mItem.DropDownItems.Count > 0 Then
    '                    p_Add_Separator = New ToolStripSeparator()
    '                    p_mItem.DropDownItems.Add(p_Add_Separator)
    '                End If
    '                Select Case Len(p_Datarow(p_Count).Item(4).ToString)  ' UCase(p_Datarow(p_Count).Item(4).ToString)


    '                    'Case "MNUSYSTEM", "FPTREPORT", "FPTLISTS", "FPTSO", "FPTUPDATE", "FPTMRP"

    '                    '    If p_Datarow(p_Count).Item("icon_file").ToString <> " " Then
    '                    '        p_Path_File = p_Path & p_Datarow(p_Count).Item("icon_file").ToString
    '                    '        Try
    '                    '            pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
    '                    '                                              Image.FromFile(p_Path_File), _
    '                    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '                                p_Datarow(p_Count).Item(4).ToString)
    '                    '        Catch ex As Exception
    '                    '            pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
    '                    '                                              Nothing, _
    '                    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '                                    p_Datarow(p_Count).Item(4).ToString)
    '                    '        End Try
    '                    '    Else
    '                    '        pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
    '                    '                                              Nothing, _
    '                    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '                                    p_Datarow(p_Count).Item(4).ToString)
    '                    '    End If
    '                    '    'pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
    '                    '    '                                          Image.FromFile(p_Path), _
    '                    '    '                                            New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '    'p_Datarow(p_Count).Item(4).ToString)
    '                    '    'pAdd_FileMenuItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText

    '                    '    'Case "FPTREPORT"
    '                    '    '    pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
    '                    '    '                                              Nothing, _
    '                    '    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '    '                                                p_Datarow(p_Count).Item(4).ToString)

    '                    '    'Case "FPTLISTS"
    '                    '    '    pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
    '                    '    '                                              Nothing, _
    '                    '    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '    '                                                p_Datarow(p_Count).Item(4).ToString)

    '                    '    'Case "FPTSO"
    '                    '    '    pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
    '                    '    '                                              Nothing, _
    '                    '    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '    '                                                p_Datarow(p_Count).Item(4).ToString)
    '                    '    '    'Case "FPTREBATE"
    '                    '    '    '    pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
    '                    '    '    '                                              Nothing, _
    '                    '    '    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '    '    '                                                p_Datarow(p_Count).Item(4).ToString)
    '                    '    'Case "FPTUPDATE"
    '                    '    '    pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
    '                    '    '                                              Nothing, _
    '                    '    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '    '                                                p_Datarow(p_Count).Item(4).ToString)

    '                    '    'Case "FPTMRP"
    '                    '    '    pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
    '                    '    '                                              Nothing, _
    '                    '    '                                                New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                    '    '                                                p_Datarow(p_Count).Item(4).ToString)

    '                    Case 0
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString)
    '                    Case Else
    '                        If p_Datarow(p_Count).Item("icon_file").ToString <> " " Then
    '                            p_Path_File = p_Path & p_Datarow(p_Count).Item("icon_file").ToString
    '                            Try
    '                                pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
    '                                                                  Image.FromFile(p_Path_File), _
    '                                                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                                                    p_Datarow(p_Count).Item(4).ToString)
    '                            Catch ex As Exception
    '                                pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                                                        p_Datarow(p_Count).Item(4).ToString)
    '                            End Try
    '                        Else
    '                            pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                                                        p_Datarow(p_Count).Item(4).ToString)
    '                        End If
    '                End Select


    '                pAdd_FileMenuItem.Name = p_Datarow(p_Count).Item(3).ToString & p_Mnu_Index.ToString


    '                pAdd_FileMenuItem.Tag = p_Datarow(p_Count).Item(4).ToString & "." & p_Datarow(p_Count).Item(3).ToString & ";" & p_Datarow(p_Count).Item("FUNCTION_ID").ToString.Trim
    '                ' pAdd_FileMenuItem.Image = ""
    '                p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
    '            End If

    '        Next

    '    End If
    '    Me.ToolStripStatusLabel1.Text = "IP: " & g_IP_Address & "        Computer: " & g_GetHostName & "         User: " & g_UserName
    'End Sub


    Public Sub p_Sys_Create_Menu(ByRef p_Menu As MenuStrip, ByVal p_Menu_Name As String, _
                                     ByRef p_mItem As ToolStripMenuItem, Optional ByVal p_ParentIndex As Integer = 0)
        Dim p_Mod_Get_Gird As New DataTable
        Dim p_Menu_Dataset As New DataSet
        Dim p_Mnu_Index As Integer

        Dim pAdd_FileMenuItem As New ToolStripMenuItem
        Dim p_Count As Integer
        Dim p_Datarow() As DataRow
        Dim p_DatarowChild() As DataRow

        Dim p_Menu1 As New MenuStrip
        Dim p_Add_Separator As New ToolStripSeparator
        Dim p_Abc As ToolStripMenuItem
        Dim p_SubMenuChild As New DataTable
        Dim p_DataTbl As New DataTable

        Dim p_Path As String
        Dim p_Path_File As String
        Dim p_DescMenu As String

        p_Path = Application.StartupPath & "\Images"

        If System.IO.Directory.Exists(p_Path) = False Then
            p_Path = Application.StartupPath & "\"
        End If
        Dim p_FptModule As New FPTModule.Class1(g_UserName, g_Company_Code, g_Services, p_UsrB1, p_PassB1, p_Port, p_Company_Host, p_User_Database, p_DataTbl, "VND")


        Dim p_DataTable As DataTable
        Dim p_SQL As String
        Dim p_PathSubMenu As String = ""


        p_SubMenuChild = p_FptModule.p_ModSys_Get_Menu_SubmenuChildNew(g_User_ID, g_DBTYPE)

        If p_SubMenuChild Is Nothing Then
            Exit Sub
        End If


        If p_SubMenuChild.Rows.Count > 0 Then

            p_Datarow = p_SubMenuChild.Select("SubMenu is not null and SubMenu<>'' and MENU_CODE='" & p_Menu_Name & "'")

            For p_Count = 0 To p_Datarow.Length - 1
                p_SQL = "SELECT * FROM SYS_MENU where Menu_Code='" & p_Datarow(p_Count).Item("SubMenu").ToString.Trim & "'"
                p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)


                p_PathSubMenu = Application.StartupPath & "\Images"

                If System.IO.Directory.Exists(p_PathSubMenu) = False Then
                    p_PathSubMenu = Application.StartupPath & "\"
                End If
                If p_DataTable.Rows.Count > 0 Then
                    p_PathSubMenu = p_PathSubMenu & p_DataTable.Rows(0).Item("Icon_File").ToString.Trim
                End If
                If System.IO.File.Exists(p_PathSubMenu) = True Then


                    p_Abc = p_mItem.DropDownItems.Add(p_Datarow(p_Count).Item(5).ToString, Image.FromFile(p_PathSubMenu))
                Else
                    p_Abc = p_mItem.DropDownItems.Add(p_Datarow(p_Count).Item(5).ToString)
                End If
                'p_Abc = p_mItem.DropDownItems.Add(p_Datarow(p_Count).Item(5).ToString)
                p_Abc.Name = p_Datarow(p_Count).Item(5).ToString
                p_Abc.Text = p_Datarow(p_Count).Item(6).ToString

                p_DatarowChild = p_SubMenuChild.Select("MENU_CODE='" & p_Datarow(p_Count).Item(5).ToString & "'")

                For p_SubMnu_Index1 = 0 To p_DatarowChild.Length - 1
                    If p_Datarow(p_Count).Item(5).ToString <> "" Then
                        p_Sys_Create_Menu(p_Menu, p_DatarowChild(p_SubMnu_Index1).Item(1).ToString, p_Abc)
                    End If
                    If p_Abc.DropDownItems.Count > 0 Then
                        p_Add_Separator = New ToolStripSeparator()
                        p_Abc.DropDownItems.Add(p_Add_Separator)
                    End If

                    p_DescMenu = p_DatarowChild(p_SubMnu_Index1).Item(2).ToString
                    'If p_ParentIndex > 0 Then
                    '    p_DescMenu = p_ParentIndex & "." & p_DescMenu
                    'End If
                    Select Case Len(p_DatarowChild(p_SubMnu_Index1).Item(4).ToString) 'UCase(p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)

                        Case 0
                            pAdd_FileMenuItem = New ToolStripMenuItem(p_DescMenu)  'p_DatarowChild(p_SubMnu_Index1).Item(2).ToString
                        Case Else
                            If p_DatarowChild(p_SubMnu_Index1).Item("icon_file").ToString <> " " Then
                                p_Path_File = p_Path & p_DatarowChild(p_SubMnu_Index1).Item("icon_file").ToString
                                Try
                                    'pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
                                    '                                  Image.FromFile(p_Path_File), _
                                    '                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
                                    '                p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)
                                    pAdd_FileMenuItem = New ToolStripMenuItem(p_DescMenu, _
                                                                      Image.FromFile(p_Path_File), _
                                                                        New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
                                                    p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)

                                Catch ex As Exception
                                    'pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
                                    '                                  Nothing, _
                                    '                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
                                    '                p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)
                                    pAdd_FileMenuItem = New ToolStripMenuItem(p_DescMenu, _
                                                                      Nothing, _
                                                                        New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
                                                    p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)
                                End Try
                            Else
                                'pAdd_FileMenuItem = New ToolStripMenuItem(p_DatarowChild(p_SubMnu_Index1).Item(2).ToString, _
                                '                                      Nothing, _
                                '                                        New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
                                '    p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)
                                pAdd_FileMenuItem = New ToolStripMenuItem(p_DescMenu, _
                                                                      Nothing, _
                                                                        New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
                                    p_DatarowChild(p_SubMnu_Index1).Item(4).ToString)
                            End If
                    End Select
                    pAdd_FileMenuItem.Name = p_DatarowChild(p_SubMnu_Index1).Item(3).ToString & p_Mnu_Index.ToString
                    'anhqh
                    '20170922
                    'ABC
                    pAdd_FileMenuItem.Tag = p_DatarowChild(p_SubMnu_Index1).Item(4).ToString & "." & p_DatarowChild(p_SubMnu_Index1).Item(3).ToString & ";" & p_DatarowChild(p_SubMnu_Index1).Item("FUNCTION_ID").ToString     'p_Datarow(p_Count).Item("FUNCTION_ID").ToString.Trim
                    p_Abc.DropDownItems.Add(pAdd_FileMenuItem)
                Next p_SubMnu_Index1
                ' End If
            Next

            p_Datarow = p_SubMenuChild.Select("( SubMenu is  null or SubMenu ='' ) and MENU_CODE='" & p_Menu_Name.Trim & "'")
            For p_Count = 0 To p_Datarow.Length - 1

                If UCase(p_Datarow(p_Count).Item(4).ToString) <> "" Then
                    If p_mItem.DropDownItems.Count > 0 Then
                        p_Add_Separator = New ToolStripSeparator()
                        p_mItem.DropDownItems.Add(p_Add_Separator)
                    End If

                    p_DescMenu = p_Datarow(p_Count).Item(2).ToString
                    'If p_ParentIndex > 0 Then
                    '    p_DescMenu = p_ParentIndex & "." & p_DescMenu
                    'End If


                    Select Case Len(p_Datarow(p_Count).Item(4).ToString)  ' UCase(p_Datarow(p_Count).Item(4).ToString)



                        Case 0
                            pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString)
                        Case Else
                            If p_Datarow(p_Count).Item("icon_file").ToString <> " " Then
                                p_Path_File = p_Path & p_Datarow(p_Count).Item("icon_file").ToString
                                Try
                                    'pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
                                    '                                  Image.FromFile(p_Path_File), _
                                    '                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
                                    '                    p_Datarow(p_Count).Item(4).ToString)
                                    pAdd_FileMenuItem = New ToolStripMenuItem(p_DescMenu, _
                                                                      Image.FromFile(p_Path_File), _
                                                                        New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
                                                        p_Datarow(p_Count).Item(4).ToString)
                                Catch ex As Exception
                                    'pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
                                    '                                  Nothing, _
                                    '                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
                                    '                        p_Datarow(p_Count).Item(4).ToString)
                                    pAdd_FileMenuItem = New ToolStripMenuItem(p_DescMenu, _
                                                                      Nothing, _
                                                                        New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
                                                            p_Datarow(p_Count).Item(4).ToString)
                                End Try
                            Else
                                'pAdd_FileMenuItem = New ToolStripMenuItem(p_Datarow(p_Count).Item(2).ToString, _
                                '                                      Nothing, _
                                '                                        New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
                                '                            p_Datarow(p_Count).Item(4).ToString)
                                pAdd_FileMenuItem = New ToolStripMenuItem(p_DescMenu, _
                                                                      Nothing, _
                                                                        New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
                                                            p_Datarow(p_Count).Item(4).ToString)
                            End If
                    End Select


                    pAdd_FileMenuItem.Name = p_Datarow(p_Count).Item(3).ToString & p_Mnu_Index.ToString


                    pAdd_FileMenuItem.Tag = p_Datarow(p_Count).Item(4).ToString & "." & p_Datarow(p_Count).Item(3).ToString & ";" & p_Datarow(p_Count).Item("FUNCTION_ID").ToString.Trim
                    ' pAdd_FileMenuItem.Image = ""
                    p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
                End If

            Next

        End If

    End Sub
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


    '    Dim p_Menu1 As New MenuStrip
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
    '                'pAdd_FileMenuItem = New ToolStripMenuItem("anhqh 123456", Nothing, Nothing, p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)
    '                'pAdd_FileMenuItem.Name = "anhqh123"
    '                'p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
    '                'Dim p_Abc As ToolStripMenuItem
    '                'p_Abc = pAdd_FileMenuItem.DropDownItems.Add("anhqh")
    '                'p_Abc.Name = "anhqh"
    '                'pAdd_FileMenuItem.DropDownItems.Item(0).Text = "anhqh 567"
    '                If p_SubMnu_Index > 0 Then
    '                    p_Add_Separator = New ToolStripSeparator()
    '                    p_mItem.DropDownItems.Add(p_Add_Separator)
    '                End If
    '                Select Case UCase(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)
    '                    Case "MNUSYSTEM"

    '                        'pAdd_FileMenuItem = New ToolStripMenuItem("anhqh", Nothing, Nothing, p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)

    '                        'pAdd_FileMenuItem = New ToolStripMenuItem(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(2).ToString, _
    '                        '                                          Nothing, _
    '                        '                                            New EventHandler(AddressOf p_ToolStripMenuItem_Click), "anhqh")
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                        p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)


    '                    Case "MNUREPORT"
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                                                                    p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)

    '                    Case "FPTLISTS"
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                                                                    p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)

    '                    Case "FPTSO"
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                                                                    p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)
    '                    Case "FPTREBATE"
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
    '                                                                    p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(4).ToString)
    '                    Case "FPTMRP"
    '                        pAdd_FileMenuItem = New ToolStripMenuItem(p_SubMenu.Tables(p_Mnu_Index).Rows(p_SubMnu_Index).Item(2).ToString, _
    '                                                                  Nothing, _
    '                                                                    New EventHandler(AddressOf p_ToolStripMenuItem_Click), _
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
    '                                                                        New EventHandler(AddressOf p_End))
    '                p_mItem.DropDownItems.Add(pAdd_FileMenuItem)
    '            End If
    '        Next p_Mnu_Index

    '    End If
    'End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub StatusStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.ToolStripStatusLabel1.ToolTipText <> "" Then
            If CInt(Me.ToolStripStatusLabel1.ToolTipText) > 0 Then
                Me.ToolStripStatusLabel1.ToolTipText = CInt(Me.ToolStripStatusLabel1.ToolTipText) - 1
                'Me.ToolStripStatusLabel1.Text = Now.Second.ToString
            Else
                ToolStripStatusLabel1.ForeColor = Drawing.Color.Black
                ToolStripStatusLabel1.Text = p_Status

            End If
        End If

    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub ToolStrip1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ToolStrip1.MouseMove
        Me.ToolStrip1.Focus()
    End Sub

    Function Exists_Form(ByVal p_Form As String) As Boolean
        Dim p_SQL As String
        Dim p_Datatable As DataTable
        Exists_Form = False
        Try
            p_SQL = "select 1 as nNumber from SYS_FORMS  where upper(Form_Name) = upper('" & p_Form & "')"
            p_Datatable =  g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_Datatable Is Nothing Then
                If p_Datatable.Rows.Count > 0 Then
                    Exists_Form = True
                End If
            End If
        Catch ex As Exception
            p_SQL = ex.Message
        End Try
        
    End Function

End Class
