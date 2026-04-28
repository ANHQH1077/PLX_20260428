Imports System.IO
Module UpdateMod
    'FPTLISTS
    Public g_SYS_COMPANY As DataTable

    Public g_Company_Code As String
    Public g_WareHouse As String
    Public g_WareHouseName As String

    'Public g_User_Database As String
    Public g_IP_Address As String
    Public g_GetHostName As String
    Public g_User_ID As Double

    Public p_Company_ID As Integer

    Public p_Company_Code As String
    Public p_Company_Name As String
    Public p_User_Database As String
    Public g_Company_Host As String
    Public g_Company_DBName As String

    Public g_UserName As String
    Public g_UsrB1 As String
    Public g_PassB1 As String
    Public g_Port As String

    Public g_DataApprove As New DataTable


    Public pv_Back_Color As System.Drawing.Color = Drawing.Color.White
    Public pv_Required_Back_Color As System.Drawing.Color = Drawing.Color.LightGoldenrodYellow
    Public pv_Locked_Back_Color As System.Drawing.Color = Drawing.Color.LightCyan
    Public g_Format_Date_Ora As String = "MM/DD/YYYY"
    Public g_Format_Date As String = "MM/dd/yyyy"

    Private pv_Type_Column_Char As String = "C"  'Kieu du lieu cua column
    Private pv_Type_Column_Date As String = "D"  'Kieu du lieu cua column
    Private pv_Type_Column_Number As String = "N"  'Kieu du lieu cua column


    Private pv_Type_Date As String = "DATEEDIT"
    Private pv_Type_TextBox As String = "C1TEXTBOX"
    Private pv_Type_Num As String = "C1NUMERICEDIT"
    Private pv_Type_Combo As String = "C1COMBO"

    Public pv_Message_Dataset As New DataSet

    Public p_Dataset_Binding As New DataSet
    Public p_DataSet_Combo_Source As New DataSet
    Public p_DataSet_TrueGird As New DataSet

    Public g_Services As Object
    Public g_Module As Object


    Public Const g_RowNum As Integer = 20
    Public g_CompanyAPI As New Object
    Public g_LicenceHost As String
    Public g_DBUser As String
    Public g_DBPass As String

    Public g_Currency As String = "VND"
    Public g_CurrencyDtl As New DataTable
    Public g_CurrencyDecima As Integer
    ' Public p_FptMod As FPTModule.Class1
    Public g_ApprovedList As DataTable

    Public g_WhsTypePromotions As String = "02"   'Lưu giá trị loại kho khuyến mại
    Public g_VatCodePromotions As String = "OP 0%" 'Lưu giá trị mã thuế VAT dành cho hàng khuyến mại

    Public Declare Function GlobalAlloc Lib "kernel32" (ByVal wFlags As Long, ByVal dwBytes As Long) As Long
    Public Declare Function GlobalFree Lib "kernel32" (ByVal hMem As Long) As Long

    'Copy from Memory?
    Public Declare Sub CopyMemoryPtrToBytes Lib "kernel32" Alias "RtlMoveMemory" ( _
                ByVal lpvDest As Byte, ByVal lpvSource As Long, ByVal cbCopy As Long)

    'Write to memory?
    Public Declare Sub CopyMemoryBytesToPtr Lib "kernel32" Alias "RtlMoveMemory" ( _
                ByVal lpvDest As Long, ByVal lpvSource As Byte, ByVal cbCopy As Long)
    Public g_ToolStripStatus As System.Windows.Forms.ToolStripStatusLabel
    Public g_MessageStatus As System.Windows.Forms.ToolStripStatusLabel
    Public g_MenuIcon As ToolStrip


    Public g_HamGetMaLenh As String = ""
    Public g_LoaiPhieu As String = "V144"

    Public g_Config_XMLDatatable As New System.Data.DataTable

    Public g_Terminal As String = ""
    Public g_HangHoaToScada2 As DataTable

    Public _getAllSyn As String = "A"
    Public _getHaftSyn As String = "H"
    Public g_WCF As Boolean = False

    Public Function p_GetUpdateDLL(ByRef p_Err As String) As Boolean
        Dim p_File As String = ""
        Dim p_SQL As String = "SELECT [ID],[FileName],[FilePath],[FileMajor],[FileMinor],[FileBuild]" & _
                                ",[FileRevision],[AutoUpdate] FROM [SYS_VERSION] where  isnull(AutoUpdate,'N')='Y'  and isnull(Status,'N')='Y'   Order by ID"
        Dim p_DataTable As New DataTable
        Dim p_Count As Integer
        Dim p_DataSet As New DataSet
        Dim anm As System.Reflection.AssemblyName
        Dim p_StrVer As String
        Dim p_FromFile As String
        Dim p_ToFile As String = ""
        Dim p_toFilePath As String = ""
        Dim p_toDirectoryFilePath As String = ""
        Dim p_Version As String
        Dim p_VersionFile As String
        Try
            p_GetUpdateDLL = True
            p_DataSet = g_Services.mod_SYS_GET_DATASET(p_SQL)
            p_toDirectoryFilePath = Application.StartupPath
            If Not p_DataSet Is Nothing Then
                p_DataTable = p_DataSet.Tables(0)
                For p_Count = 0 To p_DataTable.Rows.Count - 1



                    p_FromFile = p_DataTable.Rows(p_Count).Item("FilePath").ToString.Trim
                    p_toFilePath = p_toDirectoryFilePath & "\" & p_DataTable.Rows(p_Count).Item("FileName").ToString.Trim


                    If IO.File.Exists(p_toFilePath) = True Then
                        anm = System.Reflection.AssemblyName.GetAssemblyName(p_DataTable.Rows(p_Count).Item("FileName").ToString.Trim)
                        ' p_Version = p_DataTable.Rows(p_Count).Item("FileMajor") & p_DataTable.Rows(p_Count).Item("FileMinor") & _
                        'p_DataTable.Rows(p_Count).Item("FileBuild") & p_DataTable.Rows(p_Count).Item("FileRevision")
                        ' p_VersionFile = anm.VersionCompatibility.ToString
                        p_toFilePath = Replace(p_toFilePath, "\\", "\")
                        If anm.Version.Major < p_DataTable.Rows(p_Count).Item("FileMajor") Then
                            If p_GetFile(p_FromFile, p_toFilePath, p_Err) = False Then
                                p_GetUpdateDLL = True
                                Continue For
                            End If
                            Continue For
                        End If
                        If anm.Version.Minor < p_DataTable.Rows(p_Count).Item("FileMinor") Then
                            If p_GetFile(p_FromFile, p_toFilePath, p_Err) = False Then
                                p_GetUpdateDLL = True
                                Continue For
                            End If
                            Continue For
                        End If
                        If anm.Version.Build < p_DataTable.Rows(p_Count).Item("FileBuild") Then
                            If p_GetFile(p_FromFile, p_toFilePath, p_Err) = False Then
                                p_GetUpdateDLL = True
                                Continue For
                            End If
                            Continue For
                        End If
                        If anm.Version.Revision < p_DataTable.Rows(p_Count).Item("FileRevision") Then
                            If p_GetFile(p_FromFile, p_toFilePath, p_Err) = False Then
                                p_GetUpdateDLL = True
                                Continue For
                            End If
                            Continue For
                        End If
                    Else
                        If p_GetFile(p_FromFile, p_toFilePath, p_Err) = False Then
                            p_GetUpdateDLL = True
                            Continue For
                        End If
                        Continue For
                    End If
                Next
            End If


        Catch ex As Exception
            p_Err = ex.Message
            p_GetUpdateDLL = False
        End Try



    End Function


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
                    anm = System.Reflection.AssemblyName.GetAssemblyName(dra.Name)
                    p_DataRow = p_DataTable.NewRow
                    p_DataRow.Item(0) = dra.Name
                    p_DataRow.Item(1) = anm.Version
                    p_DataTable.Rows.Add(p_DataRow)
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



    Public Function p_GetFile(ByVal FromFile As String, ByVal ToSaveFile As String, ByRef p_Err As String) As Boolean
        Try
            Dim p_Count As Long = 10240

            p_GetFile = True

            Using FileStream As New FileStream(ToSaveFile, FileMode.Create, FileAccess.Write)

                Dim Position As New Long
                Dim Data() As Byte

                'Data = g_Service.ModReadFile("C:\FRT\FrtUpdate\web.config", Position, 102400, p_Err)
                Data = g_Services.ModReadFile(FromFile, Position, p_Count, p_Err)

                If p_Err = "" Then
                    While Data.LongLength > 0
                        FileStream.Write(Data, 0, Data.LongLength)
                        Position += Data.LongLength
                        Data = g_Services.ModReadFile(FromFile, Position, p_Count, p_Err)
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



End Module
