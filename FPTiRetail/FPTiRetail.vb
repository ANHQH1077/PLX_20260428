Imports System.IO
Imports System.Threading.Tasks
Imports System.Net

Module FPTiRetail

    Private g_GetHostName, g_IP_Address As String
    Private g_ServicesUpd As Object



    Public Function p_GetFile(ByVal FromFile As String, ByVal ToSaveFile As String, ByRef p_Err As String) As Boolean
        Try
            Dim p_Count As Long = 10240

            p_GetFile = True

            If g_ServicesUpd Is Nothing Then
                Exit Function
            End If
            Using FileStream As New FileStream(ToSaveFile, FileMode.Create, FileAccess.Write)

                Dim Position As New Long
                Dim Data() As Byte

                'Data = g_Service.ModReadFile("C:\FRT\FrtUpdate\web.config", Position, 102400, p_Err)
                g_ServicesUpd.ModReadFile(FromFile, Position, p_Count, p_Err, Data)

                If p_Err = "" Then
                    While Data.LongLength > 0
                        FileStream.Write(Data, 0, Data.LongLength)
                        Position += Data.LongLength
                        g_ServicesUpd.ModReadFile(FromFile, Position, p_Count, p_Err, Data)
                    End While


                Else
                    p_GetFile = False
                    Exit Function

                End If
            End Using

            If p_Err = String.Empty Then
                'MessageBox.Show("Update successful", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            p_GetFile = False
            p_Err = ex.Message
            'MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function




    Sub Main()



        '    'Application.EnableVisualStyles()
        '    'Application.SetCompatibleTextRenderingDefault(False)
        ' Dim p_Services As Object = New FPTMain.WcfRetail.ServiceClient

        'Dim psdfsfdf(1) As String

        'psdfsfdf(0) = "sadadsa"
        'psdfsfdf(1) = "sada"

        'Dim p_frmMain As New Windows.Forms.Form

        'Dim p_UpdServices As New WcfUpdate.ServiceClient
        'Dim p_FptUpdate As New FPTUpdate.UpdateCls(p_UpdServices)
        'Dim p_Err As String = ""

        'If p_FptUpdate.ModGetUpdateDLL(p_Err) = False Then
        '    MsgBox(p_Err)

        'End If
        '  Dim p_abc As New gvObject.modSoToChu
        ' MessageBox.Show(p_abc.SoToChu("286665473"))
        ShowMainForm()


        'Application.Run(p_frmMain)
    End Sub





    Public Function B12_ThongTinHamHang(ByVal p_Do As String) As DataTable
        Dim requestUrl As String = "http://www.b12petroleum.com.vn/TDHKhoBeAPI/api/DuongAmTamMuc?do_sap=2055500198"
        Dim p_SQL As String
        '  Dim jResults As JObject
        Dim p_Array1 As String()
        Dim p_Array2 As String()
        Dim p_Int, pInt1 As Integer
        Dim p_Table As New DataTable("HH")
        Dim p_Row As DataRow

        Dim p_tbl As DataTable
        Try
           
            Dim http As HttpWebRequest = CType(HttpWebRequest.Create(requestUrl), HttpWebRequest)
            ' h() 'ttp.Referer = referrer
            Dim response As HttpWebResponse = CType(http.GetResponse(), HttpWebResponse)
            p_Table.Columns.Add("MaNgan")
            p_Table.Columns.Add("HH")
            Using sr As StreamReader = New StreamReader(response.GetResponseStream())
                Dim responseJson As String = sr.ReadToEnd()
                ' Dim jResults As JObject = JObject.Parse(responseJson)
                'jResults = JObject.Parse(responseJson)
                '' jResults = JArray.Parse(responseJson)
                'If jResults.Count > 0 Then
                '    If jResults.Item("hh").ToString <> "" Then

                '        'p_SQL = jResults.Item("hh").Value
                '        p_Array1 = Split(jResults.Item("hh").ToString, ";")
                '        For p_Int = 0 To p_Array1.Length - 1
                '            p_Array2 = Split(p_Array1(p_Int).ToString, ":")
                '            If p_Array2.ToString <> "" Then
                '                Try
                '                    p_Row = p_Table.NewRow
                '                    p_Row.Item(0) = Mid(p_Array2(0).ToString, 2).Trim
                '                    p_Row.Item(1) = p_Array2(1).ToString.Trim
                '                    p_Table.Rows.Add(p_Row)
                '                Catch ex As Exception

                '                End Try

                '            End If
                '        Next
                '    End If

                'End If





            End Using
            Return p_Table
        Catch ex As Exception
            'Return String.Empty
            p_SQL = ex.Message

            Return Nothing

        End Try
    End Function


    Sub ShowMainForm()

        ' p_ServicesCls.getServices
        'Dim p_abc As ServiceReference1.GatewayServiceSoapClient
        'Dim p_String = ""
        'Dim p_Binding As New System.ServiceModel.BasicHttpBinding()

        'Dim remoteAddress = New System.ServiceModel.EndpointAddress("http://service-devhoadon.petrolimex.com.vn/GatewayService.asmx?WSDL")
        'p_Binding.MaxReceivedMessageSize = 2147483647
        'p_abc = New ServiceReference1.GatewayServiceSoapClient(p_Binding, remoteAddress)
        'p_String = p_abc.getInvViewFkeyNoPay("20MEGE2H", "sap0300555450ws", "Petro@2018")

        Dim p_Object As New FPTBUSSINESS.Class1

        ' Dim p_dataTable As New System.Data.DataTable
        Dim p_SQL As String = "SELECT * FROM SYS_USER"


        Mod_IPAddress()

        Dim p_TableUpdate As DataTable

        If ListFilesDown(p_TableUpdate) = True Then
            Dim p_Form As New FrmVersion
            p_Form.g_UpdSourceTable = p_TableUpdate
            p_Form.ShowDialog()
        End If
        'If mdlGetUpdateDLL(p_SQL) = True Then

        'End If



        If GetTypeConnectWCF() = True Then
            'p_Services = p_ServicesCls.getServices
            'Dim p_Services As WcfE5.ServiceClient
            'p_Services = New WcfE5.ServiceClient
            Dim p_MainClass As New FPTMain.MainClass(Nothing)

            p_MainClass.ShowMainForm()
        Else
            Dim p_MainClassObj As New FPTMain.MainClass(p_Object)

            p_MainClassObj.ShowMainForm()
        End If
        'Dim p_MainClassObj As New FPTMain.MainClass(Nothing)
        'p_MainClassObj.ShowMainForm()
    End Sub


    Public Function mdlGetUpdateDLL(ByRef p_Err As String) As Boolean
        Dim p_File As String = ""
        Dim p_SQL As String = "SELECT [ID],[FileName],[FilePath],[FileMajor],[FileMinor],[FileBuild]" &
                                ",[FileRevision],[AutoUpdate] FROM [SYS_VERSION] where  isnull(AutoUpdate,'N')='Y'  and isnull(Status,'N')='Y'   Order by ID"
        Dim p_DataTable As New DataTable
        Dim p_Count As Integer
        Dim p_DataSet As New DataSet
        Dim anm As System.Reflection.AssemblyName
        Dim p_StrVer As String = ""
        Dim p_FromFile As String
        Dim p_ToFile As String = ""
        Dim p_toFilePath As String = ""
        Dim p_toDirectoryFilePath As String = ""
        Dim p_Version As String
        Dim p_VersionFile As String
        Try
            mdlGetUpdateDLL = False
            If g_ServicesUpd Is Nothing Then
                Exit Function
            End If
            ' g_ServicesUpd.
            p_DataSet = g_ServicesUpd.mod_SYS_GET_DATASET(p_SQL)
            p_toDirectoryFilePath = Application.StartupPath
            If Not p_DataSet Is Nothing Then
                p_DataTable = p_DataSet.Tables(0)
                For p_Count = 0 To p_DataTable.Rows.Count - 1



                    p_FromFile = p_DataTable.Rows(p_Count).Item("FilePath").ToString.Trim
                    p_toFilePath = p_toDirectoryFilePath & "\" & p_DataTable.Rows(p_Count).Item("FileName").ToString.Trim

                    p_SQL = "INSERT INTO [dbo].[SYS_VERSION_HIST] ([FileName],[FilePath],[FileMajor],[FileMinor]" &
                                ",[FileBuild],[FileRevision],[PC_Name],[PC_IP],[UpdData]) "
                    p_SQL = p_SQL & " VALUES ('" & p_DataTable.Rows(p_Count).Item("FileName").ToString.Trim & "'" &
                                    ",'" & p_DataTable.Rows(p_Count).Item("FilePath").ToString.Trim & "'" &
                                    "," & p_DataTable.Rows(p_Count).Item("FileMajor").ToString.Trim & "" &
                                    "," & p_DataTable.Rows(p_Count).Item("FileMinor").ToString.Trim & "" &
                                    "," & p_DataTable.Rows(p_Count).Item("FileBuild").ToString.Trim & "" &
                                    "," & p_DataTable.Rows(p_Count).Item("FileRevision").ToString.Trim & "" &
                                     ",'" & g_GetHostName & "'" &
                                      ",'" & g_IP_Address & "'" &
                                      ",getdate() " &
                                    ") "
                    If IO.File.Exists(p_toFilePath) = True Then
                        anm = System.Reflection.AssemblyName.GetAssemblyName(p_DataTable.Rows(p_Count).Item("FileName").ToString.Trim)
                        ' p_Version = p_DataTable.Rows(p_Count).Item("FileMajor") & p_DataTable.Rows(p_Count).Item("FileMinor") & _
                        'p_DataTable.Rows(p_Count).Item("FileBuild") & p_DataTable.Rows(p_Count).Item("FileRevision")
                        ' p_VersionFile = anm.VersionCompatibility.ToString
                        p_toFilePath = Replace(p_toFilePath, "\\", "\")
                        If anm.Version.Major <> p_DataTable.Rows(p_Count).Item("FileMajor") Then
                            If p_GetFile(p_FromFile, p_toFilePath, p_Err) = False Then
                                mdlGetUpdateDLL = True
                                'If g_ServicesUpd.Sys_Execute(p_SQL, p_SQL) Then

                                'End If
                                Continue For
                            End If
                            If g_ServicesUpd.Sys_Execute(p_SQL, p_SQL) Then

                            End If
                            Continue For
                        End If
                        If anm.Version.Minor <> p_DataTable.Rows(p_Count).Item("FileMinor") Then
                            If p_GetFile(p_FromFile, p_toFilePath, p_Err) = False Then
                                mdlGetUpdateDLL = True
                                'If g_ServicesUpd.Sys_Execute(p_SQL, p_SQL) Then

                                'End If
                                Continue For
                            End If
                            If g_ServicesUpd.Sys_Execute(p_SQL, p_SQL) Then

                            End If
                            Continue For
                        End If
                        If anm.Version.Build <> p_DataTable.Rows(p_Count).Item("FileBuild") Then
                            If p_GetFile(p_FromFile, p_toFilePath, p_Err) = False Then
                                mdlGetUpdateDLL = True
                                'If g_ServicesUpd.Sys_Execute(p_SQL, p_SQL) Then

                                'End If
                                Continue For
                            End If
                            If g_ServicesUpd.Sys_Execute(p_SQL, p_SQL) Then

                            End If
                            Continue For
                        End If
                        If anm.Version.Revision <> p_DataTable.Rows(p_Count).Item("FileRevision") Then
                            If p_GetFile(p_FromFile, p_toFilePath, p_Err) = False Then
                                mdlGetUpdateDLL = True

                                Continue For
                            End If

                            If g_ServicesUpd.Sys_Execute(p_SQL, p_SQL) Then

                            End If
                            Continue For
                        End If
                    Else
                        If p_GetFile(p_FromFile, p_toFilePath, p_Err) = False Then
                            mdlGetUpdateDLL = True

                            Continue For
                        End If
                        If g_ServicesUpd.Sys_Execute(p_SQL, p_SQL) Then

                        End If
                        Continue For
                    End If
                Next
            End If


        Catch ex As Exception
            p_Err = ex.Message
            mdlGetUpdateDLL = False
        End Try



    End Function



    Public Function ListFilesDown(ByRef p_Table As DataTable) As Boolean
        Dim p_FileName As String = ""
        Dim p_Ext As String = ""
        Dim folderPath As String = Application.StartupPath
        Dim p_ArrRow() As DataRow
        Dim p_Count As Integer
        ' Dim p_FileString = "U_TextBox.dll,U_CusForm.dll, HDDT.dll, FPTSO.dll,FPTModule.dll,FPTModule.dll,FPTLISTS.dll,FPTBUSSINESS.dll,DataLogic.dll,ReportSetup.dll"
        Dim p_FileString = "select  isnull( ( select  distinct     stuff(( " & _
                                " select ',' + u.FileName  from SYS_VERSION u  " & _
                                " where  isnull(AutoUpdate,'N') ='N' and isnull(Status,'N') ='N' order by u.FileName " & _
                                    " for xml path('') ),1,1,'')  as FileName ),'') as FileName"
        Try
            Dim fileNames = My.Computer.FileSystem.GetFiles(folderPath, FileIO.SearchOption.SearchAllSubDirectories)

            p_FileString = " select FileName, convert(nvarchar(10),FileMajor) +  convert(nvarchar(10),FileMInor) + " & _
                           " convert(nvarchar(10),FileBuild) +  convert(nvarchar(10),FileRevision )  as sVersion " & _
                           ",convert(nvarchar(10),FileMajor) + '.' +  convert(nvarchar(10),FileMInor) +  '.' + " & _
                           " convert(nvarchar(10),FileBuild) +   '.' + convert(nvarchar(10),FileRevision )  as sVersion22 " & _
                                 " from SYS_VERSION   u where  isnull(AutoUpdate,'N') ='N' and isnull(Status,'N') ='Y' order by u.FileName"
            Dim p_ItemPlu As String = ""
            Dim p_ItemCode As String = ""
            'Dim p_Table As New DataTable("Table001")
            Dim p_Row As DataRow
            Dim p_DataTable As DataTable
            Dim p_String As String = ""
            Dim p_DataTablecheck As DataTable
            Dim p_Check As Boolean = False
            Dim anm As System.Reflection.AssemblyName
            Dim p_Count2 As Integer
            '   Dim p_Error As String
            Dim p_Error As String = ""
            Dim p_Version, p_Version2 As Double
            Dim p_StringTmp As String = ""
            Dim p_StringTmp2 As String = ""

            p_Table = New DataTable("Table001")


            p_Table.Columns.Add("FileName")
            p_Table.Columns.Add("Version")
            'p_Table.Columns.Add("Version")
            p_Table.Columns.Add("cDate")
            p_Table.Columns.Add("X")

            If g_ServicesUpd Is Nothing Then
                Exit Function
            End If
            Try
                p_DataTablecheck = g_ServicesUpd.Sys_SYS_GET_DATATABLE_Des(p_FileString, p_FileString)
            Catch ex As Exception

            End Try

            If Not p_DataTablecheck Is Nothing Then
                For p_Count = 0 To p_DataTablecheck.Rows.Count - 1
                    p_String = UCase(p_DataTablecheck.Rows(p_Count).Item("FileName").ToString.Trim)
                    Double.TryParse(p_DataTablecheck.Rows(p_Count).Item("sVersion").ToString.Trim, p_Version)
                    p_StringTmp2 = p_DataTablecheck.Rows(p_Count).Item("sVersion22").ToString.Trim
                    For Each fileName As String In fileNames
                        p_FileName = UCase(My.Computer.FileSystem.GetFileInfo(fileName).Name)
                        If InStr(p_String, p_FileName) > 0 Then
                            anm = System.Reflection.AssemblyName.GetAssemblyName(folderPath & "\" & p_FileName)
                            p_StringTmp = Replace(anm.Version.ToString, ".", "")
                            Double.TryParse(p_StringTmp, p_Version2)
                            If p_Version > p_Version2 Then
                                p_Row = p_Table.NewRow
                                p_Row.Item("FileName") = p_FileName
                                '   p_Row.Item("cDate") = CDate(My.Computer.FileSystem.GetFileInfo(fileName).CreationTime).ToString("dd-MM-yyyy HH:mm:ss")
                                p_Row.Item("Version") = p_StringTmp2 'anm.Version.ToString    '  anm.Version.Major.ToString & "." & anm.Version.Major & "." & anm.Version.Major & "."
                                p_Row.Item("X") = "Y"
                                p_Table.Rows.Add(p_Row)
                            End If

                        End If
                        'p_Ext = My.Computer.FileSystem.GetFileInfo(fileName).Extension
                        'If UCase(p_Ext) = UCase(".jpg") Or UCase(p_Ext) = UCase(".bmp") Or UCase(p_Ext) = UCase(".png") Or UCase(p_Ext) = UCase(".ico") Or UCase(p_Ext) = UCase(".gif") Then

                        'End If

                        'p_FileName=fileNam
                    Next
                Next
            End If

            ' If p_String <> "" Then



            'If mdlGetUpdateDLL22(p_DataTable, p_Error) = False Then

            'End If
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    Return True
                End If
            End If
            'If Not p_DataTable Is Nothing Then
            '    For p_Count = 0 To p_DataTable.Rows.Count - 1

            '        For p_Count2 = 0 To p_Table.Rows.Count - 1
            '            If UCase(p_Table.Rows(p_Count2).Item("FileName")) = UCase(p_DataTable.Rows(p_Count).Item("FileName")) Then
            '                '   p_Check = True
            '                ' p_Table.Rows(p_Count2).Item("X") = "Y"
            '                Return True
            '            End If
            '        Next
            '    Next
            'End If
            ' End If
            Return False
        Catch e As Exception
            MessageBox.Show(e.Message)
            Return False
        End Try

    End Function




    Private Function mdlGetUpdateDLL22(ByRef p_TableCheck As DataTable, ByRef p_Err As String) As Boolean
        Dim p_File As String = ""
        Dim p_SQL As String = "SELECT [ID],[FileName],[FilePath],[FileMajor],[FileMinor],[FileBuild]" &
                                ",[FileRevision],[AutoUpdate] FROM [SYS_VERSION] where  isnull(AutoUpdate,'N')='N'  and isnull(Status,'N')='Y'   Order by ID"
        Dim p_DataTable As New DataTable
        Dim p_Count As Integer
        Dim p_DataSet As New DataSet
        Dim anm As System.Reflection.AssemblyName
        Dim p_StrVer As String = ""
        Dim p_FromFile As String
        Dim p_ToFile As String = ""
        Dim p_toFilePath As String = ""
        Dim p_toDirectoryFilePath As String = ""
        Dim p_Version As String
        Dim p_VersionFile As String


        Dim p_Row As DataRow
        Try
            mdlGetUpdateDLL22 = False

            If p_TableCheck Is Nothing Then
                p_TableCheck = New DataTable("Table001")
            End If
            p_TableCheck.Columns.Add("FileName")


            p_DataSet = g_ServicesUpd.mod_SYS_GET_DATASET(p_SQL)
            p_toDirectoryFilePath = Application.StartupPath
            If Not p_DataSet Is Nothing Then
                p_DataTable = p_DataSet.Tables(0)
                For p_Count = 0 To p_DataTable.Rows.Count - 1
                    p_FromFile = p_DataTable.Rows(p_Count).Item("FilePath").ToString.Trim
                    p_toFilePath = p_toDirectoryFilePath & "\" & p_DataTable.Rows(p_Count).Item("FileName").ToString.Trim

                    If IO.File.Exists(p_toFilePath) = True Then
                        anm = System.Reflection.AssemblyName.GetAssemblyName(p_DataTable.Rows(p_Count).Item("FileName").ToString.Trim)

                        p_toFilePath = Replace(p_toFilePath, "\\", "\")
                        If anm.Version.Major <> p_DataTable.Rows(p_Count).Item("FileMajor") Then
                            p_Row = p_TableCheck.NewRow
                            p_Row.Item("FileName") = p_DataTable.Rows(p_Count).Item("FileName").ToString.Trim
                            p_TableCheck.Rows.Add(p_Row)
                            Continue For
                        End If
                        If anm.Version.Minor <> p_DataTable.Rows(p_Count).Item("FileMinor") Then
                            p_Row = p_TableCheck.NewRow
                            p_Row.Item("FileName") = p_DataTable.Rows(p_Count).Item("FileName").ToString.Trim
                            p_TableCheck.Rows.Add(p_Row)

                            Continue For
                        End If
                        If anm.Version.Build <> p_DataTable.Rows(p_Count).Item("FileBuild") Then
                            p_Row = p_TableCheck.NewRow
                            p_Row.Item("FileName") = p_DataTable.Rows(p_Count).Item("FileName").ToString.Trim
                            p_TableCheck.Rows.Add(p_Row)

                            Continue For
                        End If
                        If anm.Version.Revision <> p_DataTable.Rows(p_Count).Item("FileRevision") Then
                            p_Row = p_TableCheck.NewRow
                            p_Row.Item("FileName") = p_DataTable.Rows(p_Count).Item("FileName").ToString.Trim
                            p_TableCheck.Rows.Add(p_Row)

                            Continue For
                        End If

                    End If
                Next
            End If

            mdlGetUpdateDLL22 = True
        Catch ex As Exception
            p_Err = ex.Message
            mdlGetUpdateDLL22 = False
        End Try



    End Function


    Private Function GetTypeConnectWCF() As Boolean
        Dim g_PathXML As String
        Dim p_DataSet As New DataSet
        Dim g_Config_XMLDatatable As DataTable

        Try
            GetTypeConnectWCF = False
            g_PathXML = Application.StartupPath & "\Config.xml"
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

    'Sub WriteToRam()
    '    Dim TableToWrite As New DataTable

    '    TableToWrite = g_Services.mod_SYS_GET_DATATABLE("select * from SYS_FORMS")
    '    TableToWrite.WriteXml("aaa.xml")

    '    Dim str111 As String

    '    Dim reader1 = System.Xml.XmlReader.Create("aaa.xml")
    '    reader1.MoveToContent()
    '    Dim inputXml = XDocument.ReadFrom(reader1)
    '    str111 = inputXml.ToString
    '    reader1.Close()

    '    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile("aaa.xml")

    '    Dim ms As New MemoryStream()

    '    Dim sw = New StreamWriter(ms)
    '    sw.WriteLine(str111)

    '    sw.Flush()
    '    ms.Position = 0


    '    Dim reader As New StreamReader(ms)
    '    Dim str = reader.ReadLine()
    '    MsgBox(str)
    '    ms.Position = 0



    'End Sub


    Public Sub Mod_IPAddress()
        g_GetHostName = System.Net.Dns.GetHostName()
        Dim ipHostInfo As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
        Dim ipAddress As System.Net.IPAddress
        Dim ipTmp As String = ""
        For Each ipAddress In ipHostInfo.AddressList
            'Only return IPv4 routable IPs
            If (ipAddress.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork) Then
                ipTmp = ipAddress.ToString
                Exit For
            End If
        Next
        If String.IsNullOrEmpty(ipTmp) Then
            ipTmp = ipHostInfo.AddressList(0).ToString
        End If
        g_IP_Address = ipTmp
        'g_GetHostName
        'g_IP_Address = System.Net.Dns.GetHostAddresses(g_GetHostName).GetValue(0).ToString    ' .GetHostByName(strHostName).ToString ' AddressList(0).ToString()                  

        'If g_IP_Address.LastIndexOf(".") <= 0 Then
        '    g_IP_Address = System.Net.Dns.GetHostAddresses(g_GetHostName).GetValue(1).ToString
        'End If
    End Sub

    Private Function requestUrl() As String
        Throw New NotImplementedException
    End Function


End Module

