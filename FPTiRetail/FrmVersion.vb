Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmVersion

    Private g_Service As Object

    Private g_GetHostName As String = ""
    Private g_IP_Address As String = ""

    Public g_UpdSourceTable As DataTable

    Private Sub FrmVersion_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmVersion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub FrmVersion_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Mod_IPAddress()


        Dim p_ColTypeButtonEdit As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        ListFiles()


        p_ColTypeButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        p_ColTypeButtonEdit = GridView1.Columns(4).ColumnEdit
        p_ColTypeButtonEdit.Name = "cmdDown"
        ' GridView1.Columns(10).ColumnEdit = p_ColTypeButtonEdit
        AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Gridview_Column_Click


    End Sub


    Private Sub Gridview_Column_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_Row As DataRow
        Dim p_Err As String = ""

        If g_Service Is Nothing Then
            Exit Sub
        End If
        p_Row = Me.GridView1.GetFocusedDataRow
        If Not p_Row Is Nothing Then
            If p_Row.Item("X") = "Y" Then
                If mdlGetFileDLL(p_Row.Item("FileName").ToString.Trim, p_Err) = False Then
                    MsgBox(p_Err)
                Else
                    p_Row.Item("X") = "N"
                    '  MessageBox.Show("Đã thực hiện xong")
                    GridView1.DeleteRow(GridView1.FocusedRowHandle)
                End If
            End If
        End If

    End Sub

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


    Private Function mdlGetFileDLL(p_FIleName As String, ByRef p_Err As String) As Boolean
        Dim p_File As String = ""
        Dim p_SQL As String = "SELECT [ID],[FileName],[FilePath],[FileMajor],[FileMinor],[FileBuild]" &
                                ",[FileRevision],[AutoUpdate] FROM [SYS_VERSION] where  isnull(AutoUpdate,'N')='N'  and isnull(Status,'N')='Y'  and   upper(FileName) =upper('" & p_FIleName & "')"
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
            mdlGetFileDLL = False

            ' g_ServicesUpd.
            Try
                p_DataSet = g_Service.mod_SYS_GET_DATASET(p_SQL)
            Catch ex As Exception

            End Try


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
                        ' If anm.Version.Major <> p_DataTable.Rows(p_Count).Item("FileMajor") Then
                        If p_GetFile(p_FromFile, p_toFilePath, p_Err) = False Then
                            mdlGetFileDLL = False
                            'If g_ServicesUpd.Sys_Execute(p_SQL, p_SQL) Then

                            'End If
                            Continue For
                        End If
                        If g_Service.Sys_Execute(p_SQL, p_SQL) Then

                        End If
                        Continue For
                    End If
                Next
            End If

            mdlGetFileDLL = True
        Catch ex As Exception
            p_Err = ex.Message
            mdlGetFileDLL = False
        End Try



    End Function

    Private Sub ListFiles()
        Dim p_FileName As String = ""
        Dim p_Ext As String = ""
        Dim folderPath As String = Application.StartupPath
        Dim p_ArrRow() As DataRow
        Dim p_DataTable As DataTable
        Dim p_Count As Integer
        Dim p_FileString = "select  isnull( ( select  distinct     stuff(( " & _
                                " select ',' + u.FileName  from SYS_VERSION u  " & _
                                " where  isnull(AutoUpdate,'N') ='N' and isnull(Status,'N') ='Y' order by u.FileName " & _
                                    " for xml path('') ),1,1,'')  as FileName ),'') as FileName"
        Try
            'Dim fileNames = My.Computer.FileSystem.GetFiles(folderPath, FileIO.SearchOption.SearchAllSubDirectories)
            'Dim p_String As String = ""
            'Dim p_ItemPlu As String = ""
            'Dim p_ItemCode As String = ""
            'Dim p_Table As New DataTable("Table001")
            'Dim p_Row As DataRow
            'Dim p_DataTablecheck As DataTable
            'Dim p_Check As Boolean = False
            'Dim anm As System.Reflection.AssemblyName
            'Dim p_Count2 As Integer
            '        '   Dim p_Error As String
            'Dim p_Error As String = ""
            'p_Table.Columns.Add("FileName")
            'p_Table.Columns.Add("Version")
            '        'p_Table.Columns.Add("Version")
            'p_Table.Columns.Add("cDate")
            'p_Table.Columns.Add("X")

            'p_DataTablecheck = g_Service.Sys_SYS_GET_DATATABLE_Des(p_FileString, p_FileString)
            'If Not p_DataTablecheck Is Nothing Then
            '    If p_DataTablecheck.Rows.Count > 0 Then
            '        p_String = p_DataTablecheck.Rows(0).Item(0).ToString.Trim
            '    End If
            'End If
            'If p_String <> "" Then
            '    p_String = UCase(p_String)
            '    For Each fileName As String In fileNames
            '        p_FileName = UCase(My.Computer.FileSystem.GetFileInfo(fileName).Name)
            '        If InStr(p_String, p_FileName) > 0 Then
            '            anm = System.Reflection.AssemblyName.GetAssemblyName(folderPath & "\" & p_FileName)
            '            p_Row = p_Table.NewRow
            '            p_Row.Item("FileName") = p_FileName
            '            p_Row.Item("cDate") = CDate(My.Computer.FileSystem.GetFileInfo(fileName).CreationTime).ToString("dd-MM-yyyy HH:mm:ss")
            '            p_Row.Item("Version") = anm.Version.ToString    '  anm.Version.Major.ToString & "." & anm.Version.Major & "." & anm.Version.Major & "."
            '            p_Row.Item("X") = "Y"
            '            p_Table.Rows.Add(p_Row)
            '            p_Check = True
            '        End If
            '        'p_Ext = My.Computer.FileSystem.GetFileInfo(fileName).Extension
            '        'If UCase(p_Ext) = UCase(".jpg") Or UCase(p_Ext) = UCase(".bmp") Or UCase(p_Ext) = UCase(".png") Or UCase(p_Ext) = UCase(".ico") Or UCase(p_Ext) = UCase(".gif") Then

            '        'End If

            '        'p_FileName=fileNam

            '    Next


            '    'If mdlGetUpdateDLL(p_DataTable, p_Error) = False Then
            '    '    MsgBox(p_Error)
            '    '    Me.Close()
            '    'End If

            '    'If Not p_DataTable Is Nothing Then
            '    '    For p_Count = 0 To p_DataTable.Rows.Count - 1

            '    '        For p_Count2 = 0 To p_Table.Rows.Count - 1
            '    '            If p_Table.Rows(p_Count2).Item("FileName") = p_DataTable.Rows(p_Count).Item("FileName") Then
            '    '                p_Check = True
            '    '                p_Table.Rows(p_Count2).Item("X") = "Y"
            '    '            End If
            '    '        Next
            '    '    Next
            '    'End If
            If Not g_UpdSourceTable Is Nothing Then
                Me.GridControl1.DataSource = g_UpdSourceTable
                If Me.GridView1.Columns.Count > 0 Then
                    Me.GridView1.Columns.Item(0).FieldName = g_UpdSourceTable.Columns.Item(0).ColumnName
                    Me.GridView1.Columns.Item(1).FieldName = g_UpdSourceTable.Columns.Item(1).ColumnName
                    Me.GridView1.Columns.Item(2).FieldName = g_UpdSourceTable.Columns.Item(2).ColumnName
                    Me.GridView1.Columns.Item(3).FieldName = g_UpdSourceTable.Columns.Item(3).ColumnName
                    Me.GridView1.Columns.Item(3).VisibleIndex = -1
                End If
            End If
           
            'For p_Count = Me.GridView1.RowCount - 1 To 0 Step -1
            '    'e.Row.BackColor = System.Drawing.Color.LightGreen;
            '    p_Row = GridView1.GetDataRow(p_Count)
            '    If Not p_Row Is Nothing Then
            '        If p_Row.Item("X").ToString.Trim = "Y" Then
            '            GridView1.ro
            '        End If
            '    End If
            'Next
            ' End If
            'If p_Check = False Then
            '    Me.Close()
            'End If
        Catch e As Exception
            MessageBox.Show("An error occured for this folder. Try another folder.")
        End Try

    End Sub


    Private Function mdlGetUpdateDLL(ByRef p_TableCheck As DataTable, ByRef p_Err As String) As Boolean
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
            mdlGetUpdateDLL = False

            If p_TableCheck Is Nothing Then
                p_TableCheck = New DataTable("Table001")
            End If
            p_TableCheck.Columns.Add("FileName")


            p_DataSet = g_Service.mod_SYS_GET_DATASET(p_SQL)
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

            mdlGetUpdateDLL = True
        Catch ex As Exception
            p_Err = ex.Message
            mdlGetUpdateDLL = False
        End Try



    End Function



    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        Dim p_Row As DataRow
        p_Row = Me.GridView1.GetDataRow(e.RowHandle)
        If Not p_Row Is Nothing Then
            If p_Row.Item("X") = "Y" Then
                e.Appearance.BackColor = Color.LightGreen
            End If
        End If
    End Sub
End Class