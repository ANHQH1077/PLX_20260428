Imports System.Web
Public Class FrmScadarFox
    Dim p_Table_Sys_Config As DataTable


    Dim p_PathFileFoxOut As String
    Dim p_PathFileFoxIn As String

    Dim p_PathFileFoxOutThuy As String
    Dim p_PathFileFoxInThuy As String


    Dim p_PathFileFoxOutSat As String
    Dim p_PathFileFoxInSat As String

    Dim p_PathFileFoxBo As String
    Dim p_PathFileFoxThuy As String
    Dim p_PathFileFoxSat As String
    Dim p_StrConnectFox As String
    Dim p_LoaiVanChuyen As String

    Private Sub FrmScadarFox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            UpdateData()
        End If
    End Sub
    Private Sub FrmScadarFox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       

        Me.U_Optional1.EditValue = "BO"

        p_LoaiVanChuyen = ""
        If Not Me.U_Optional1.EditValue Is Nothing Then
            p_LoaiVanChuyen = U_Optional1.EditValue.ToString.Trim
        End If

        If StrGetConnectFox("out", p_LoaiVanChuyen, g_Terminal) = True Then

        End If
        loadData()

    End Sub

    Private Sub loadData()
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_DataTablw As DataTable
        Dim p_SQL As String
        Dim p_Type64 As String = "Y"
        
        'p_SQL = "select * from SYS_CONFIG where KeyCode='WEBSERVER64'"
        'p_DataTablw = GetDataTable(p_SQL, p_SQL)
        'If Not p_DataTablw Is Nothing Then
        '    If p_DataTablw.Rows.Count > 0 Then
        '        p_Type64 = p_DataTablw.Rows(0).Item("KeyValue").ToString.Trim
        '    End If
        'End If

        p_SQL = UCase("select * from " & p_PathFileFoxBo)
        '

        'Dim p_Path As String = ""
        'p_Path = g_Services.get_Path_Fox_Virtual_Directory

        'Try
        '    p_Path = HttpContext.Current.Server.MapPath("http://petrolimex_e5.com.vn:8998/TDH_KV3")
        'Catch ex11 As Exception
        '    p_Path = ex11.Message.ToString
        'End Try


        '  If p_Type64 = "Y" Then
        'p_DataTablw = p_SYS_GET_DATATABLE_With_Connect_Des(p_StrConnectFox, p_SQL, p_SQL)
        p_DataTablw = g_Services.GET_DATATABLE_With_Connect_Des(p_StrConnectFox, p_SQL, p_SQL)
        'Else
        ''p_DataTablw = g_Services.GET_DATATABLE_With_Connect_Des(p_StrConnectFox, p_SQL, p_SQL)
        'p_DataTablw = p_SYS_GET_DATATABLE_With_Connect_Des(p_StrConnectFox, p_SQL, p_SQL)
        'End If


        Try
            p_DataTablw.Columns.Add("CHECKUPD")
        Catch ex As Exception

        End Try
        p_Binding.DataSource = p_DataTablw
        Me.TrueDBGrid1.DataSource = p_Binding
        Me.TrueDBGrid1.RefreshDataSource()
        Me.GridView1.RefreshData()


        Try
            Me.GridView1.Columns.Item("ma_lenh").OptionsColumn.ReadOnly = True
            Me.GridView1.Columns.Item("ma_hhoa").OptionsColumn.ReadOnly = True
            Me.GridView1.Columns.Item("ngay_ctu").OptionsColumn.ReadOnly = True
            Me.GridView1.Columns.Item("ngan").OptionsColumn.ReadOnly = True
            Me.GridView1.Columns.Item("CHECKUPD").OptionsColumn.ReadOnly = True
            Me.GridView1.BestFitColumns()
        Catch ex As Exception

        End Try

        Me.GridView1.BestFitColumns()

    End Sub

    Private Function StrGetConnectFox(ByVal p_TypeIn As String, ByVal g_LoaiVanChuyen As String, Optional ByVal p_Terminal As String = "") As Boolean
        Dim p_SQL As String
        Dim p_DataArr() As DataRow
        Dim p_FileType As String = ""
        Dim p_FileName As String = ""
        Dim p_DataTable As DataTable

        Dim p_DataSet As DataSet
        Dim p_Path As String = ""
        Dim p_Map_cp As DataTable
        Dim p_FilePathOut, p_FilePathIn, p_FilePathTemp As String
        ' Dim p_Date As Date
        ' Dim p_Time As Integer
        StrGetConnectFox = True

        p_SQL = "SELECT * FROM SYS_CONFIG; SELECT * FROM tblMap_cp;"
        p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

        If p_DataSet Is Nothing Then
            Exit Function
        End If
        p_Table_Sys_Config = p_DataSet.Tables(0)
        p_Map_cp = p_DataSet.Tables(1)


        'p_Table_Sys_Config = g_Services.Sys_SYS_GET_DATATable_Des(p_SQL, p_SQL)
        If p_Table_Sys_Config.Rows.Count > 0 Then
            p_DataArr = p_Table_Sys_Config.Select("KEYCODE='TYPEFOXNAME'")
            If p_DataArr.Length > 0 Then
                p_FileType = p_DataArr(0).Item("KEYVALUE").ToString.Trim
            End If
        End If

        '' If Not p_Map_cp Is Nothing Then
        'p_SQL = "SELECT * FROM tblMap_cp"


        'p_Map_cp = g_Services.Sys_SYS_GET_DATATable_Des(p_SQL, p_SQL)
        ' End If

        If Not p_Map_cp Is Nothing Then
            If p_Map_cp.Rows.Count > 0 Then
                p_DataArr = p_Map_cp.Select("(Status='" & p_TypeIn & "' or Status='" & p_TypeIn & "') and Client='" & p_Terminal & "'")
                If p_DataArr.Length > 0 Then

                    If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
                        p_FileName = p_DataArr(0).Item("TableName").ToString.Trim
                    ElseIf UCase(g_LoaiVanChuyen) = "THUY" Then
                        p_FileName = p_DataArr(0).Item("TableName_Thuy").ToString.Trim
                    End If

                End If

            End If
        End If
        If p_FileName = "[SPACE]" Or p_FileName = "SPACE" Then
            p_FileName = ""
        End If
        If p_FileType.ToString.Trim = "" Then
            StrGetConnectFox = False
            Exit Function
        End If

        If g_WCF = True Then
            g_Services.GetPathFileFox_DB(p_FilePathOut, p_FilePathIn, p_FilePathTemp)
        End If


        If p_FilePathOut = "" Or p_FilePathIn = "" Or p_FilePathTemp = " Then" Then
            GetPathFileFox_XML(p_FilePathOut, p_FilePathIn, p_FilePathTemp, g_LoaiVanChuyen)
        End If

        p_SQL = "exec FPT_Get_FileName_Fox '" & UCase(p_FileType) & "'"
        p_DataTable = g_Services.Sys_SYS_GET_DATATable_Des(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                p_FileName = p_FileName & p_DataTable.Rows(0).Item(0).ToString.Trim & ".dbf"
            End If
        End If
        If UCase(g_LoaiVanChuyen) = "BO" Or UCase(g_LoaiVanChuyen) = "SAT" Then
            p_PathFileFoxBo = p_FileName
        Else
            p_PathFileFoxThuy = p_FileName
        End If




        'p_SQL = "select * from SYS_FOXCONFIG"
        'p_DataTable = g_Services.Sys_SYS_GET_DATATable_Des(p_SQL, p_SQL)
        'If Not p_DataTable Is Nothing Then
        '    If p_DataTable.Rows.Count > 0 Then


        If UCase(p_TypeIn) = "OUT" Then
            p_Path = p_FilePathOut

        End If
        If UCase(p_TypeIn) = "IN" Then
            p_Path = p_FilePathIn
        End If
        If p_Path = "" Then
            StrGetConnectFox = False
            Exit Function
        End If

        If Mid(p_Path, Len(p_Path) - 1) = "\" Then
            p_FileName = p_Path & p_FileName
        Else
            p_FileName = p_Path & "\" & p_FileName
        End If
        If UCase(p_TypeIn) = "OUT" Then
            p_PathFileFoxOut = p_FileName
        End If
        If UCase(p_TypeIn) = "IN" Then
            p_PathFileFoxIn = p_FileName
        End If
        p_SQL = ""
        If g_WCF = True Then

        Else
            If CheckFileName(True, p_FileName, p_SQL) = False Then
                StrGetConnectFox = False
                Exit Function
            End If
        End If
      
        ' p_StrConnectFox = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\10.65.50.9\piac\Piac\xuatbo\database\Lenh_gh;Extended Properties=dBase 5.0"
        'g_StrConnectFox = "Provider=vfpoledb;Collating Sequence=general;Data Source=" & p_Path
        'p_StrConnectFox = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & p_Path & "';Extended Properties=dBase 5.0"

        ' p_StrConnectFox = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & p_Path & ";Extended Properties=dBASE IV"   ';User ID=Admin;Password=;

        ' p_StrConnectFox = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & p_Path & ";sourcetype=DBF;exclusive=No;Collating Sequence=machine;"
        'p_StrConnectFox = "Provider=VFPOLEDB.1;Data Source=" & p_Path & ";Collating Sequence=MACHINE;Exclusive = no;Advantage Server Type=ADS_REMOTE_SERVER"
        'anhqh 
        'tam thoi bo di xem nhu the nao
        p_StrConnectFox = "Provider=vfpoledb;Collating Sequence=general;Data Source=" & p_Path


        ' p_StrConnectFox = "Provider=VFPOLEDB.1;Collating Sequence=general;Data Source=C:\Users\Administrator\AppData\Roaming\Microsoft\Windows\Network Shortcuts\Lenh_gh_bo"
        '    End If
        'End If

    End Function




    'Public Sub GetPathFileFox_DB(ByRef p_FoxOut As String, ByRef p_FoxIn As String, ByRef p_FoxTemp As String)
    '    Dim p_SQL As String
    '    Dim p_Table As DataTable
    '    Dim p_DataArr() As DataRow
    '    p_SQL = "SELECT * FROM SYS_CONFIG"
    '    p_Table = GetDataTable(p_SQL, p_SQL)
    '    p_FoxOut = ""
    '    p_FoxIn = ""
    '    p_FoxTemp = ""
    '    If Not p_Table Is Nothing Then
    '        If p_Table.Rows.Count > 0 Then
    '            p_DataArr = p_Table.Select("KEYCODE='FOX_IN'")
    '            If p_DataArr.Length > 0 Then
    '                p_FoxIn = p_DataArr(0).Item("KEYVALUE").ToString.Trim
    '            End If

    '            p_DataArr = p_Table.Select("KEYCODE='FOX_OUT'")
    '            If p_DataArr.Length > 0 Then
    '                p_FoxOut = p_DataArr(0).Item("KEYVALUE").ToString.Trim
    '            End If

    '            p_DataArr = p_Table.Select("KEYCODE='FOX_TEMP'")
    '            If p_DataArr.Length > 0 Then
    '                p_FoxTemp = p_DataArr(0).Item("KEYVALUE").ToString.Trim
    '            End If
    '        End If
    '    End If
    'End Sub


    Public Sub GetPathFileFox_XML(ByRef p_FoxOut As String, ByRef p_FoxIn As String, ByRef p_FoxTemp As String, ByVal g_LoaiVanChuyen As String)
        Dim p_SQL As String
        Dim p_Table As New DataTable
        Dim p_DAtaSet As New DataSet
        Dim p_DataArr() As DataRow
        Dim p_PathXML As String
        On Error Resume Next

        p_PathXML = Windows.Forms.Application.StartupPath & "\Config.xml"
        If Dir(p_PathXML) <> "" Then
            p_DAtaSet.ReadXml(p_PathXML)

            p_FoxOut = ""
            p_FoxIn = ""
            p_FoxTemp = ""
            If Not p_DAtaSet Is Nothing Then
                If p_DAtaSet.Tables.Count > 0 Then
                    p_Table = p_DAtaSet.Tables(0)
                End If
            End If
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then

                    Select Case UCase(g_LoaiVanChuyen)
                        Case "BO"
                            p_FoxIn = p_Table.Rows(0).Item("FOXIN").ToString.Trim


                            p_FoxOut = p_Table.Rows(0).Item("FOXOUT").ToString.Trim



                            p_FoxTemp = p_Table.Rows(0).Item("FOXTEMP").ToString.Trim
                        Case "THUY"
                            p_FoxIn = p_Table.Rows(0).Item("FOXIN_THUY").ToString.Trim


                            p_FoxOut = p_Table.Rows(0).Item("FOXOUT_THUY").ToString.Trim



                            p_FoxTemp = p_Table.Rows(0).Item("FOXTEMP_THUY").ToString.Trim
                        Case "SAT"
                            p_FoxIn = p_Table.Rows(0).Item("FOXIN_WAGON").ToString.Trim


                            p_FoxOut = p_Table.Rows(0).Item("FOXOUT_WAGON").ToString.Trim



                            p_FoxTemp = p_Table.Rows(0).Item("FOXTEMP_WAGON").ToString.Trim
                    End Select
                    

                End If
            End If
        End If
    End Sub



    Private Sub FrmScadarFox_MaximumSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MaximumSizeChanged

    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim p_DataRow As DataRow
        Dim p_Value As String = "Y"
        p_DataRow = Me.GridView1.GetFocusedDataRow
        If p_DataRow.Item("CHECKUPD").ToString.Trim <> "Y" Then
            Me.GridView1.SetFocusedRowCellValue("CHECKUPD", p_Value)
        End If
    End Sub

    Private Sub UpdateData()
        Dim p_FieldType As String
        Dim p_SQLValue As String
        Dim p_Count As Integer
        Dim p_CounField As Integer
        Dim p_Value As String
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_DataTable As DataTable

        Dim p_DataTableExe As New DataTable("Tbl01")

        Dim p_Where As String = ""
        Dim p_DataRow As DataRow

        Dim p_ArrDataRow() As DataRow

        Dim p_SQL As String = ""


        p_LoaiVanChuyen = ""
        If Not Me.U_Optional1.EditValue Is Nothing Then
            p_LoaiVanChuyen = U_Optional1.EditValue.ToString.Trim
        End If

        If StrGetConnectFox("out", p_LoaiVanChuyen, g_Terminal) = True Then

        End If

        Me.GridView1.UpdateCurrentRow()
        p_Binding = Me.GridView1.DataSource
        p_DataTable = CType(p_Binding.DataSource, DataTable)
        p_ArrDataRow = p_DataTable.Select("CHECKUPD='Y'")
        If p_ArrDataRow.Length <= 0 Then
            Exit Sub
        End If
        p_SQL = ""
        'p_DataTable = New DataTable
        p_DataTableExe.Columns.Add("SQL_STR")
        
        For p_Count = 0 To p_ArrDataRow.Length - 1
            For p_CounField = 0 To p_DataTable.Columns.Count - 1
                If UCase(p_DataTable.Columns.Item(p_CounField).ColumnName) <> "MA_LENH" And UCase(p_DataTable.Columns.Item(p_CounField).ColumnName) <> "MA_HHOA" _
                        And UCase(p_DataTable.Columns.Item(p_CounField).ColumnName) <> "NGAY_CTU" And UCase(p_DataTable.Columns.Item(p_CounField).ColumnName) <> "NGAN" _
                        And UCase(p_DataTable.Columns.Item(p_CounField).ColumnName) <> "CHECKUPD" Then
                    p_FieldType = p_DataTable.Columns.Item(p_CounField).DataType.Name
                    p_Value = p_ArrDataRow(p_Count).Item(p_CounField).ToString.Trim
                    Select Case UCase(p_FieldType)
                        Case UCase("Int32"), UCase("Single"), UCase("Double"), UCase("byte"), UCase("decimal")
                            If p_Value = "" Then
                                p_Value = "0"
                            End If
                            p_SQL = p_SQL & "," & p_DataTable.Columns.Item(p_CounField).ColumnName & "=" & CDec(p_Value)
                        Case UCase("DateTime"), UCase("Date")
                            If p_Value = "" Then
                                p_Value = Now.Date
                            End If
                            p_SQL = p_SQL & "," & p_DataTable.Columns.Item(p_CounField).ColumnName & "= {d'" & CDate(p_Value.ToString.Trim).ToString("yyyy-MM-dd") & "'}"
                            'p_SQL = p_SQL & "," & p_DataTable.Columns.Item(p_CounField).ColumnName & "= #" & CDate(p_Value).ToString("MM/dd/yyyy hh:mm:ss tt") & "#"
                        Case UCase("String")
                            p_SQL = p_SQL & "," & p_DataTable.Columns.Item(p_CounField).ColumnName & "='" & p_Value & "'"
                    End Select
                End If

                If UCase(p_DataTable.Columns.Item(p_CounField).ColumnName) = "MA_LENH" Or UCase(p_DataTable.Columns.Item(p_CounField).ColumnName) = "PR_KEY" Then
                    p_Value = p_ArrDataRow(p_Count).Item(p_CounField).ToString.Trim

                    If UCase(p_FieldType) = "STRING" Then
                        p_Where = " WHERE " & p_DataTable.Columns.Item(p_CounField).ColumnName & "='" & p_Value & "'"
                    Else
                        p_Where = " WHERE " & p_DataTable.Columns.Item(p_CounField).ColumnName & "=" & p_Value
                    End If

                End If
            Next

            If p_Where = "" Or p_SQL = "" Then
                Continue For
            End If

            p_SQL = Mid(p_SQL, 2)
            p_SQL = "UPDATE " & p_PathFileFoxBo & " set " & p_SQL & " " & p_Where
            ' p_DataTable = New DataTable
            'p_DataTableExe.Columns.Add("SQL_STR")
            p_DataRow = p_DataTableExe.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataTableExe.Rows.Add(p_DataRow)
            p_SQL = ""
            p_Where = ""
        Next
        
        'p_DataTable = New DataTable
        'p_DataTable.Columns.Add("SQL_STR")
        'p_DataRow = p_DataTable.NewRow
        'p_DataRow.Item(0) = p_SQL
        'p_DataTable.Rows.Add(p_DataRow)
        p_SQL = ""


        If Not p_DataTableExe Is Nothing Then
            If p_DataTableExe.Rows.Count > 0 Then
                'If g_WCF = True Then
                '    If g_Services.Execute_DataTbl_With_Connection(p_StrConnectFox, p_DataTableExe, p_SQL) = False Then
                '        ShowMessageBox("", p_SQL)
                '        Exit Sub

                '    End If
                'End If
                If Sys_Execute_DataTbl_With_Connection(p_StrConnectFox, p_DataTableExe, p_SQL) = False Then
                    ShowMessageBox("", p_SQL)
                    Exit Sub

                End If
            End If
            'Else
            '    Exit Sub
        End If
        
        loadData()
    End Sub

    Private Sub U_Optional1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_Optional1.SelectedIndexChanged
        p_LoaiVanChuyen = ""
        If Not Me.U_Optional1.EditValue Is Nothing Then
            p_LoaiVanChuyen = U_Optional1.EditValue.ToString.Trim
        End If
        Try

        Catch ex As Exception

        End Try

        If StrGetConnectFox("out", p_LoaiVanChuyen, g_Terminal) = True Then

        End If
        loadData()
    End Sub
End Class