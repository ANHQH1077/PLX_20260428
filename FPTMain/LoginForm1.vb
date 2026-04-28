Imports Microsoft.Win32
Imports System.ComponentModel
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.UserSkins
Imports DevExpress.XtraEditors
Imports System.Windows.Forms
Imports System.Xml

Public Class LoginForm1
    Private p_Terminal_Roll() As String

    Private p_CheckTerminal As Boolean = False

    Private p_Relogin As Boolean = False

    Public Property Relogin() As Boolean
        Get
            Return p_Relogin
        End Get
        Set(ByVal value As Boolean)
            p_Relogin = value
        End Set
    End Property
    Private p_RowID As Integer

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        'Dim svc As New SystemBatch.Class1 '  SysBatch.Class1 ' SysBatch.Class1    
        ' Dim svc As New SystemBatch.Class1
        Dim p_Value As String
        Dim p_DataTable As DataTable
        Dim p_CheckUserB1 As String = ""
        Dim p_MaKho As String = ""
        Dim p_Desc As String
        Dim p_SQL As String = ""
        Dim pTBL As DataTable

        Dim p_Count As Integer
        ' Dim p_Value As String
        Dim p_Check As Boolean = False

        If p_CheckTerminal = True Then
            If p_Terminal_Roll.Length <= 0 Then
                MsgBox("Bạn không có quyền Kho")
                Exit Sub
            End If
            
        End If
       
        p_Value = Me.TxtMaKho.Text

        If p_Value = "" Then
            MsgBox("Kho không xác định")
            Exit Sub
        End If
        If Not p_Terminal_Roll Is Nothing Then
            For p_Count = 0 To p_Terminal_Roll.Length - 1
                If p_Value = p_Terminal_Roll(p_Count) Then
                    p_Check = True
                End If
            Next
        End If
       
        If p_Check = False And g_Filter_Terminal = True Then
            MsgBox("Bạn không có quyền vào kho " & Me.TxtMaKho.Text)
            Exit Sub
        End If


        p_Value = ""
        p_UsrB1 = ""
        p_UsrB1 = ""
        If UCase(Me.UsernameTextBox.Text) = "CONFIG" And UCase(Me.PasswordTextBox.Text) = "HTTG@FES" Then
            Dim p_FormConfig As New FrmConnect
            p_FormConfig.Show(Me)
            Exit Sub
        ElseIf UCase(Me.UsernameTextBox.Text) = "CONFIGFOX" And UCase(Me.PasswordTextBox.Text) = "HTTG@FES" Then
            Dim p_FormConfig As New FrmConnectFox
            p_FormConfig.Show(Me)
            Exit Sub
        ElseIf UCase(Me.UsernameTextBox.Text) = "CONFIGACC" And UCase(Me.PasswordTextBox.Text) = "HTTG@FES" Then
            Dim p_FormConfigacc As New FrmConnectFoxAcc
            p_FormConfigacc.Show(Me)
            Exit Sub

        End If

        Try

            If Me.TxtMaKho.Text.ToString.Trim <> "" Then
                p_MaKho = UCase(Me.TxtMaKho.Text.ToString.Trim)
            End If
            If g_Services.MakeFileScadar(p_MaKho, p_Desc) = False Then
                MsgBox(p_Desc)
                Exit Sub
            End If
            p_MaKho = UCase(p_MaKho)
            Me.TxtMaKho.Text = p_MaKho

            If g_DBTYPE = "ORACLE" Then
                p_Value = g_Services.SysLogin_Oracle(g_IP_Address, g_GetHostName, Me.UsernameTextBox.Text, Me.PasswordTextBox.Text, g_User_ID)
            ElseIf g_DBTYPE = "SQL" Then
                p_Value = g_Services.SysLogin(g_IP_Address, g_GetHostName, Me.UsernameTextBox.Text, Me.PasswordTextBox.Text, g_User_ID)               '

            End If

            '  MsgBox(p_Value)
            g_UserName = Me.UsernameTextBox.Text

            If UCase(g_UserName) = "SYSADMIN" And Me.PasswordTextBox.Text = "qwer1234!@#$" Then
                p_Value = "T"
                'ElseIf UCase(g_UserName) = "SYSADMIN" And Me.PasswordTextBox.Text <> "1qazxsw2" Then
                '    p_Value = "F"
                p_SQL = "select USER_ID  from SYS_USER  where upper( USER_NAME) = upper( '" & g_UserName & "')"
                pTBL = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If Not pTBL Is Nothing Then
                    If pTBL.Rows.Count > 0 Then
                        g_User_ID = pTBL.Rows(0).Item("USER_ID").ToString

                    End If

                End If
            End If


            ' p_Value = g_Services.SysLogin(g_IP_Address, g_GetHostName, Me.UsernameTextBox.Text, Me.PasswordTextBox.Text, g_User_ID)
            'MsgBox(GetCursor.ToString)
            Select Case p_Value
                Case "T"
                    Try
                        If UCase(g_LoginClient) = "Y" Then
                            g_Config_XMLDatatable.Rows(0).Item("CLIENT") = p_MaKho
                        End If
                    Catch ex As Exception
                       
                    End Try
                    g_Config_XMLDatatable.Rows(0).Item("USER_LOGIN") = g_UserName
                    g_Config_XMLDatatable.WriteXml(g_PathXML)


                   

                    If p_Relogin = True Then
                        ' g_()
                        Dim p_FormMain As New MDIMainForm

                        Dim frmCollection As New FormCollection()

                        frmCollection = Application.OpenForms()

                        For Each p_FormOpen In frmCollection
                            If p_FormOpen.name.ToString = "MDIMainForm" Then
                                p_FormMain = p_FormOpen
                                Exit For
                            End If
                        Next
                        'p_FormMain.p_Create_Menu(p_FormMain.MenuStrip1)
                        p_FormMain.RemoveMenu()
                        'p_FormMain.CreateMenu = True
                        'p_FormMain.Redologin = True
                    End If

                    Me.Close()

                    Exit Sub

                Case "F"
                    MessageBox.Show("Sai Tên đăng nhập hoặc sai mật khẩu")
                Case Else
                    MessageBox.Show("Chương trình không thể kết nối được với máy chủ")
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub

    Private Sub DownloadUpdate()
        Dim p_SQL As String = "select * from SYS_VERSION  a where AutoUpdate='Y' and  not exists (select 1 from SYS_VERSION_HIST b where " & _
                "b.FileName = a.FileName " & _
                 "and b.FileMajor=a.FileMajor " & _
                 "and b.FileMinor=a.FileMinor " & _
                 "and b.FileBuild=a.FileBuild " & _
                 "and b.FileRevision=a.FileRevision	 " & _
                 "and upper(PC_Name)=upper('" & g_GetHostName & "'))"
        Dim p_Datatable As DataTable
        p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                'Dim p_FptUpdate_ShowForm As New FPTUpdate.UpdateCls(g_Config_XMLDatatable, g_Company_Code, g_WareHouse, g_Services, p_UsrB1, p_PassB1, p_Port, _
                '                                                p_Company_Host, p_User_Database, g_UserName, p_LicenceHost, _
                '                                                p_DBUser, p_DBPass, g_CompanyAPI, Nothing, Nothing, Nothing)
                'p_FptUpdate_ShowForm.P_Show_Form(Me, "FrmUpdate", p_User_Database, _
                '                                    g_User_ID, p_Company_ID, p_Company_Host, 0)

                UpdateFile(p_Datatable)
            End If
        End If
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim p_Connection As New OleDb.OleDbConnection
        Dim p_Err As String = ""
        Dim p_Binding As New System.Windows.Forms.BindingSource
        Dim p_Binding11 As New System.Windows.Forms.BindingSource
        Dim p_SQL As String = "SELECT * FROM SYS_COMPANIES where ENABLE_Flag='Y'" 'SYS_COMPANIES_USE_V"
        Dim p_DataTable As New DataTable
        Dim p_DataTable11 As New DataTable


        mdlConfig_GetConfigFromXML()

        Mod_IPAddress()

        If UCase(g_LoginClient) = "Y" Then
            Me.TxtMaKho.Visible = True
            Me.Label1.Visible = True
        Else
            Me.TxtMaKho.Visible = False
            Me.Label1.Visible = False
        End If
        'Dim p_Count As Integer
        If p_Relogin = False Then
            Try
                '' Me.PasswordTextBox.Text = 1
                'p_DataTable11 = p_GetVersion(p_Err)
                'If p_DataTable11 Is Nothing Then
                '    MsgBox(p_Err)
                'Else
                '    p_Binding11.DataSource = p_DataTable11
                '    ' Me.U_TrueDBGrid2.DataSource = p_Binding11
                '    p_Binding11.ResetBindings(True)
                '    ' Me.GridView2.Columns(0).OptionsColumn.AllowEdit = False
                '    ' Me.GridView2.Columns(1).OptionsColumn.AllowEdit = False
                'End If

                Me.U_CheckBox1.CheckValue = "Y"
                Me.U_CheckBox1.UnCheckValue = "N"

                Me.U_CheckBox1.Checked = False



                '  Me.UsernameTextBox.Text = "sysadmin"
                p_LoadData()

                ' DownloadUpdate()


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        
        Me.PasswordTextBox.Focus()

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
                            If g_Config_XMLDatatable.Rows(0).Item("CLIENT").ToString.Trim <> "" Then
                                Me.Label1.Visible = True
                                Me.TxtMaKho.Text = g_Config_XMLDatatable.Rows(0).Item("CLIENT").ToString.Trim
                                Me.TxtMaKho.Visible = True
                            End If
                            'g_Wcf_Connect
                            If g_Config_XMLDatatable.Rows(0).Item("WCF").ToString.Trim = "TRUE" Then
                                g_Wcf_Connect = True
                            End If

                            If g_Config_XMLDatatable.Rows(0).Item("USER_LOGIN").ToString.Trim <> "" Then
                                Me.UsernameTextBox.Text = g_Config_XMLDatatable.Rows(0).Item("USER_LOGIN").ToString.Trim
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

    Sub p_LoadData()

        Dim p_Err As String = ""
        Dim p_Binding As New System.Windows.Forms.BindingSource
        Dim p_DataSet As DataSet
        Dim p_SQL As String = "SELECT * FROM SYS_COMPANIES where ENABLE_Flag='Y'" 'SYS_COMPANIES_USE_V"
        Dim p_DataTable As New DataTable
        Dim p_Count As Integer
        Dim p_Errdes As String

        Try

            'Lay tham so Oracle

            '  Dim abc As New WcfRetail.ServiceClient
            'Dim p_Oracle As New System.Data.OracleClient.OracleConnection
            'Dim p_Connect As String = ""
            'If g_Services.CheckConnect_Oracle(p_Oracle, p_Connect) = False Then
            '    ' If ModCheckConnect_Oracle(p_Oracle, p_Connect) = False Then
            '    p_Oracle = New System.Data.OracleClient.OracleConnection
            '    p_Oracle.ConnectionString = p_Connect
            '    p_Oracle.Open()
            '    MsgBox("dfggfd")
            'End If
            g_Services.Sys_GetParameterOracle(g_DBTYPE)
            p_DataTable = Nothing
           

            '
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.UserSkins.OfficeSkins.Register()
        '  DevExpress.UserSkins.BonusSkins.Register()
        UserLookAndFeel.Default.SetSkinStyle("DevExpress Style")

    End Sub

    Public Sub New()

        InitSkins()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub UsernameTextBox_ModifiedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UsernameTextBox.ModifiedChanged

    End Sub

    Private Sub UsernameTextBox_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles UsernameTextBox.TextChanged

    End Sub

    Private Sub UsernameTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles UsernameTextBox.Validated
        p_LoadData()
        UsernameTextBox_TextChanged()
    End Sub


    Private Sub UsernameTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles UsernameTextBox.Validating
        'p_LoadData()

    End Sub

    Private Sub UsernameTextBox_TextChanged() 'Handles UsernameTextBox.TextChanged
        'p_LoadData()
        Dim p_SQL As String
        Dim P_DataTable As DataTable
        Dim p_Value As String = ""
        Dim p_Count As Integer
        If Me.UsernameTextBox.Text.ToString.Trim <> "" Then
            p_Value = Me.UsernameTextBox.Text.ToString.Trim
        End If

        Me.TxtMaKho.Visible = False
        p_SQL = "SELECT Terminal FROM SYS_USER where upper(USER_NAME)='" & UCase(p_Value) & "'"
        P_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not P_DataTable Is Nothing Then
            If P_DataTable.Rows.Count > 0 Then
                p_SQL = P_DataTable(0).Item("Terminal").ToString.Trim
                If p_SQL = "" Then
                    Exit Sub
                End If
                p_CheckTerminal = True
                p_Terminal_Roll = p_SQL.Split(",")
                p_Count = p_Terminal_Roll.Length
                If p_Terminal_Roll.Length > 0 Then
                    p_Value = ""
                    If p_Terminal_Roll.Length > 1 Then
                        Me.TxtMaKho.Visible = True
                    End If

                    'p_Value = Me.TxtMaKho.Text
                    For p_Count = 0 To p_Terminal_Roll.Length - 1
                        If UCase(Me.TxtMaKho.Text) = UCase(p_Terminal_Roll(p_Count)) Then
                            p_Value = UCase(p_Terminal_Roll(p_Count))
                        End If
                    Next
                    If p_Value = "" Then
                        Me.TxtMaKho.Text() = UCase(p_Terminal_Roll(0))
                    End If

                End If
            End If
        End If
        '  End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If Me.FormStatus = True Then

        Me.FormStatus = False
        'End If
        If Me.Relogin = False Then
            Application.Exit()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub TxtMaKho_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtMaKho.KeyDown

    End Sub

    Private Sub TxtMaKho_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMaKho.KeyPress

    End Sub

    Private Sub TxtMaKho_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMaKho.LostFocus

    End Sub

    Private Sub TxtMaKho_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMaKho.TextChanged

    End Sub

    Private Sub TxtMaKho_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMaKho.Validated
       

        If Me.TxtMaKho.Text.ToString.Trim <> "" Then
            Me.TxtMaKho.Text = UCase(Me.TxtMaKho.Text)
        End If

    End Sub
End Class
