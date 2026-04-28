Public Class FrmCheckScadar

    Private p_TblConfig_In As DataTable
    Private p_TblConfig_Out As DataTable


    Private p_TblConfig_Line_In As DataTable
    Private p_TblConfig_Line_Out As DataTable



    Private p_tblScadar As DataTable = Nothing
    Private p_tblScadar_E5 As DataTable = Nothing


    Dim p_TablePara As DataTable

    Private p_Table_Sys_Config As DataTable
    Private p_MaTuDongHoa As String

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_TableSoLenh As DataTable

        Dim p_DataSet As DataSet
        Dim p_BinDing As New U_TextBox.U_BindingSource
        Dim p_Check As Boolean = False

        Dim p_Value As String
       


        p_Value = ""

        If Not Me.NgayXuat.EditValue Is Nothing Then
            p_Value = Me.NgayXuat.EditValue.ToString.Trim
        End If

        If p_Value = "" Then
            ' ShowMessageBox("", "Ngày xuất chưa nhập")
            'Exit Sub
            p_SQL = "Null"
        Else
            p_Check = True
            p_SQL = "'" & CDate(Me.NgayXuat.EditValue).ToString("yyyyMMdd") & "'"
        End If




        p_Value = ""

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_Value = Me.SoLenh.EditValue.ToString.Trim
        End If

        If p_Value = "" Then
            p_SQL = p_SQL & ",Null"
        Else
            p_SQL = p_SQL & ",'" & p_Value & "'"
            p_Check = True
        End If

        p_Value = ""
        If (Me.U_CheckBox1.Checked = True) Then
            p_Value = p_Value & ",3"
        End If

        ' p_Value = ""
        If (Me.U_CheckBox2.Checked = True) Then
            p_Value = p_Value & ",31"
        End If

        ' p_Value = ""
        If (Me.U_CheckBox3.Checked = True) Then
            p_Value = p_Value & ",4"
        End If

        'p_Value = ""
        If (Me.U_CheckBox4.Checked = True) Then
            p_Value = p_Value & ",5"
        End If

        If (Me.U_CheckBox5.Checked = True) Then
            p_Value = p_Value & ",1,2"
        End If

        p_Value = p_Value & ","
        'If Not Me.TrangThai.EditValue Is Nothing Then
        '    p_Value = Me.TrangThai.EditValue.ToString.Trim
        'End If

        If p_Value = "" Then
            p_SQL = p_SQL & ",Null"
        Else
            p_SQL = p_SQL & ",N'" & p_Value & "'"
            p_Check = True
        End If
        If p_Check = False Then
            ShowMessageBox("", "Giá trị tìm kiếm chưa nhập")
            Exit Sub
        End If
        p_SQL = "exec FPT_ThongTinLenhXuat " & p_SQL


        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If p_DataSet Is Nothing Then
            Exit Sub
        End If
        If p_DataSet.Tables.Count > 0 Then
            p_Table = p_DataSet.Tables(0)
            p_TableSoLenh = p_DataSet.Tables(1)
        End If
        If Not p_TableSoLenh Is Nothing Then
            GetScadar(p_TableSoLenh, p_Table)
        End If
        If Not p_Table Is Nothing Then
            p_BinDing.DataSource = p_Table
            Me.TrueDBGrid1.DataSource = p_BinDing
            ' Me.GridView1.RefreshData()

            Me.GridView1.OptionsView.ColumnAutoWidth = False


            Dim item1 As DevExpress.XtraGrid.GridGroupSummaryItem
            item1 = New DevExpress.XtraGrid.GridGroupSummaryItem
            item1.FieldName = "LenhHTTG"
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum

            item1.DisplayFormat = "{0:#,###}"
            '  item1.DisplayFormat = "#,###0."
            GridView1.Columns("LenhHTTG").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns("LenhHTTG").DisplayFormat.FormatString = "#,###0."

            item1.ShowInGroupColumnFooter = GridView1.Columns("LenhHTTG")
            GridView1.GroupSummary.Add(item1)


            item1 = New DevExpress.XtraGrid.GridGroupSummaryItem
            item1.FieldName = "LenhScadar"
            item1.SummaryType = DevExpress.Data.SummaryItemType.Sum


            item1.DisplayFormat = "{0:#,###}"
            '  item1.DisplayFormat = "#,###0."
            GridView1.Columns("LenhScadar").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            GridView1.Columns("LenhScadar").DisplayFormat.FormatString = "#,###0."

            item1.ShowInGroupColumnFooter = GridView1.Columns("LenhScadar")
            GridView1.GroupSummary.Add(item1)


            Dim p_ColDate As New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit


            ' p_ColDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
            p_ColDate.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
            p_ColDate.Buttons.Item(0).Visible = False
            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            p_ColDate.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss"
            ' p_ColDate.DisplayFormat.FormatString = "u"
            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            ' p_ColDate.DisplayFormat.

            ' p_ColDate.EditMask = "u"

            p_ColDate.EditFormat.FormatString = "dd-MM-yyyy HH:mm:ss"
            p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            'p_ColDate.Mask.EditMask = "u"
            p_ColDate.EditMask = "dd-MM-yyyy  HH:mm:ss"
            ' p_ColDate.FormatString = "G"
            ' p_ColDate.Mask.UseMaskAsDisplayFormat = True

            GridView1.Columns.Item("GioTao").ColumnEdit = p_ColDate
            GridView1.Columns.Item("GioTao").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridView1.Columns.Item("GioTao").DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss"



            Me.GridView1.Columns("NgayXuat").Group()
            Me.GridView1.ExpandAllGroups()
            Me.GridView1.BestFitColumns()
        End If
        Me.GridView1.OptionsBehavior.Editable = False
    End Sub



    Private Sub GetScadar(ByVal p_DataTableLenh As DataTable, ByRef p_TableHTTG As DataTable)
        Dim p_SQL As String
        Dim p_Tbl As DataTable
        Dim p_MaHangHoa As String
        Dim p_Client As String
        Dim p_Count As Integer
        Dim p_Count1 As Integer
        Dim p_CountSTT As Integer
        Dim p_Row As DataRow
        Dim p_Str As String
        Dim p_SoLenh As String
        Dim p_RowArr() As DataRow

        Dim p_SQL_Where As String
        Dim p_TableScadarTmp As DataTable
        Dim p_TableScadar_E5Tmp As DataTable

        Dim p_TableScadar As DataTable
        Dim p_TableScadar_E5 As DataTable
        Dim p_Terminal As String
        Dim p_LoaiHinhVanChuyen As String
        Dim p_Table As DataTable

        Dim p_TableID As String
        Dim p_NgayXuat As DateTime
        Dim p_TblMaLenh As DataTable
        Dim p_Value As String
        Dim p_STT As Integer
        Dim p_DataRow As DataRow
        Dim pCount_Row As Integer
        Dim pCount_Col As Integer
        For p_Count = 0 To p_DataTableLenh.Rows.Count - 1
            p_TableScadarTmp = Nothing
            p_TableScadar_E5 = Nothing
            p_Row = p_DataTableLenh.Rows(p_Count)
            p_SoLenh = p_Row.Item("SoLenh").ToString.Trim
            p_LoaiHinhVanChuyen = UCase(GetLoadingSite(p_Row.Item("MaVanChuyen").ToString.Trim))
            GetDataScadar(p_SoLenh, p_LoaiHinhVanChuyen, p_Row.Item("Client").ToString.Trim, p_TableScadarTmp, _
                                         p_TableScadar_E5Tmp, "out")

            If Not p_TableScadarTmp Is Nothing Then
                If p_TableScadar Is Nothing Then
                    p_TableScadar = p_TableScadarTmp.Clone
                End If
                For pCount_Row = 0 To p_TableScadarTmp.Rows.Count - 1
                    p_DataRow = p_TableScadar.NewRow
                    For pCount_Col = 0 To p_TableScadarTmp.Columns.Count - 1
                        p_DataRow.Item(p_TableScadarTmp.Columns(pCount_Col).ColumnName) = p_TableScadarTmp.Rows(pCount_Row).Item(p_TableScadarTmp.Columns(pCount_Col).ColumnName)
                    Next

                    p_TableScadar.Rows.Add(p_DataRow)
                Next
                '    p_TableScadar.Merge(p_TableScadarTmp)
            End If

            If Not p_TableScadar_E5Tmp Is Nothing Then
                If p_TableScadar_E5 Is Nothing Then
                    p_TableScadar_E5 = p_TableScadar_E5Tmp.Clone
                End If
                For pCount_Row = 0 To p_TableScadar_E5Tmp.Rows.Count - 1
                    p_DataRow = p_TableScadar_E5.NewRow
                    For pCount_Col = 0 To p_TableScadar_E5Tmp.Columns.Count - 1
                        p_DataRow.Item(p_TableScadar_E5Tmp.Columns(pCount_Col).ColumnName) = p_TableScadar_E5Tmp.Rows(pCount_Row).Item(p_TableScadar_E5Tmp.Columns(pCount_Col).ColumnName)
                    Next

                    p_TableScadar_E5.Rows.Add(p_DataRow)
                Next


                ' p_TableScadar_E5.Merge(p_TableScadar_E5Tmp)
            End If

            'p_SQL = "SELECT * FROM SYS_Map_cp_Line where STT IN ( select STT from tblMap_cp where Client ='" & _
            '        p_Row.Item("Client").ToString.Trim() & "' and  Status ='in') and sWhere  ='Y'"
            'p_Table = GetDataTable(p_SQL, p_SQL)
            'If p_Table Is Nothing Then
            '    Exit Sub
            'End If

        Next
        If Not p_TableScadar Is Nothing Then
            p_SQL = "SELECT * FROM SYS_Map_cp_Line where STT IN ( select STT from tblMap_cp where Client ='" & _
                   p_Row.Item("Client").ToString.Trim() & "' and  Status ='in') and sWhere  ='Y'"
            p_Table = GetDataTable(p_SQL, p_SQL)
            If p_Table Is Nothing Then
                GoTo LineTT1
            End If

            If p_Table.Rows.Count <= 0 Then
                GoTo LineTT1
            End If


            For p_Count1 = 0 To p_TableHTTG.Rows.Count - 1
                'p_TableID = p_TableHTTG.Rows(p_Count1).Item("TableID").ToString.Trim()
                'p_NgayXuat = p_TableHTTG.Rows(p_Count1).Item("NgayXuat")
                'p_Value = ""
                p_SQL_Where = ""
                For p_CountSTT = 0 To p_Table.Rows.Count - 1
                    'Select Case UCase(p_LoaiHinhVanChuyen)
                    ' Case "BO"
                    If UCase(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim) = "TABLEID" Then
                        p_TableID = p_TableHTTG.Rows(p_Count1).Item(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim).ToString.Trim()
                        If g_KV1 = True Then
                            p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_TableID & "','" & _
                                       p_TableHTTG.Rows(p_Count1).Item("MaNgan").ToString.Trim() & "','" & IIf(UCase(p_LoaiHinhVanChuyen) = "SAT", "ZR", "AB") & "'"
                        Else
                            p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                        p_TableHTTG.Rows(p_Count1).Item("MaNgan").ToString.Trim() & "'"
                        End If
                        p_TblMaLenh = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                        If Not p_TblMaLenh Is Nothing Then
                            If p_TblMaLenh.Rows.Count > 0 Then
                                p_Value = p_TblMaLenh.Rows(0).Item("MaLenh").ToString.Trim
                            End If
                        End If
                        If p_SQL_Where = "" Then
                            p_SQL_Where = " " & p_Table.Rows(p_CountSTT).Item(p_LoaiHinhVanChuyen).ToString.Trim & "=" & p_Value
                        Else
                            p_SQL_Where = p_SQL_Where & " and " & p_Table.Rows(p_CountSTT).Item(p_LoaiHinhVanChuyen).ToString.Trim & "=" & p_Value
                        End If

                        p_TableHTTG.Rows(p_Count1).Item("MaTDH") = p_Value
                    Else
                        If UCase(p_TableHTTG.Rows(p_Count1).Item(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim).GetType.Name) = "DATETIME" _
                                Or UCase(p_TableHTTG.Rows(p_Count1).Item(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim).GetType.Name) = "DATE" Then
                            If p_SQL_Where = "" Then
                                p_SQL_Where = " " & p_Table.Rows(p_CountSTT).Item(p_LoaiHinhVanChuyen).ToString.Trim & "='" & CDate(p_TableHTTG.Rows(p_Count1).Item(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim).ToString.Trim()) & "'"
                            Else
                                p_SQL_Where = p_SQL_Where & " and " & p_Table.Rows(p_CountSTT).Item(p_LoaiHinhVanChuyen).ToString.Trim & "='" & CDate(p_TableHTTG.Rows(p_Count1).Item(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim).ToString.Trim()) & "'"
                            End If
                        Else
                            If p_SQL_Where = "" Then
                                p_SQL_Where = " " & p_Table.Rows(p_CountSTT).Item(p_LoaiHinhVanChuyen).ToString.Trim & "=" & p_TableHTTG.Rows(p_Count1).Item(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim).ToString.Trim()
                            Else
                                p_SQL_Where = p_SQL_Where & " and " & p_Table.Rows(p_CountSTT).Item(p_LoaiHinhVanChuyen).ToString.Trim & "=" & p_TableHTTG.Rows(p_Count1).Item(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim).ToString.Trim()
                            End If
                        End If

                    End If


                    'Case "THUY"

                    ' Case Else

                    ' End Select

                Next

                If p_SQL_Where <> "" Then
                    'p_RowArr 
                    p_RowArr = p_TableScadar.Select(p_SQL_Where)
                    If p_RowArr.Length > 0 Then
                        p_TableHTTG.Rows(p_Count1).Item("LenhScadar") = 1

                    End If
                End If
            Next
        End If

LineTT1:

        If Not p_TableScadar_E5 Is Nothing Then

            p_SQL = "SELECT * FROM SYS_Map_cp_Line where STT IN ( select STT from tblMap_cp where Client Like '%E5%'" & _
                   " and  Status ='in') and sWhere  ='Y'"
            p_Table = GetDataTable(p_SQL, p_SQL)
            If p_Table Is Nothing Then
                Exit Sub
            End If
            If p_Table.Rows.Count <= 0 Then
                Exit Sub
            End If


            For p_Count1 = 0 To p_TableHTTG.Rows.Count - 1
                'p_TableID = p_TableHTTG.Rows(p_Count1).Item("TableID").ToString.Trim()
                'p_NgayXuat = p_TableHTTG.Rows(p_Count1).Item("NgayXuat")
                'p_Value = ""
                p_SQL_Where = ""
                For p_CountSTT = 0 To p_Table.Rows.Count - 1
                    'Select Case UCase(p_LoaiHinhVanChuyen)
                    ' Case "BO"
                    If UCase(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim) = "TABLEID" Then
                        p_TableID = p_TableHTTG.Rows(p_Count1).Item(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim).ToString.Trim()
                        If g_KV1 = True Then
                            p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_TableID & "','" & _
                                       p_TableHTTG.Rows(p_Count1).Item("MaNgan").ToString.Trim() & "','" & IIf(UCase(p_LoaiHinhVanChuyen) = "SAT", "ZR", "AB") & "'"
                        Else
                            p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                        p_TableHTTG.Rows(p_Count1).Item("MaNgan").ToString.Trim() & "'"
                        End If
                        p_TblMaLenh = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                        If Not p_TblMaLenh Is Nothing Then
                            If p_TblMaLenh.Rows.Count > 0 Then
                                p_Value = p_TblMaLenh.Rows(0).Item("MaLenh").ToString.Trim
                            End If
                        End If
                        If p_SQL_Where = "" Then
                            p_SQL_Where = " " & p_Table.Rows(p_CountSTT).Item(p_LoaiHinhVanChuyen).ToString.Trim & "=" & p_Value
                        Else
                            p_SQL_Where = p_SQL_Where & " and " & p_Table.Rows(p_CountSTT).Item(p_LoaiHinhVanChuyen).ToString.Trim & "=" & p_Value
                        End If

                        p_TableHTTG.Rows(p_Count1).Item("MaTDH") = p_Value
                    Else
                        If UCase(p_TableHTTG.Rows(p_Count1).Item(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim).GetType.Name) = "DATETIME" _
                                Or UCase(p_TableHTTG.Rows(p_Count1).Item(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim).GetType.Name) = "DATE" Then
                            If p_SQL_Where = "" Then
                                p_SQL_Where = " " & p_Table.Rows(p_CountSTT).Item(p_LoaiHinhVanChuyen).ToString.Trim & "='" & p_TableHTTG.Rows(p_Count1).Item(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim).ToString.Trim() & "'"
                            Else
                                p_SQL_Where = p_SQL_Where & " and " & p_Table.Rows(p_CountSTT).Item(p_LoaiHinhVanChuyen).ToString.Trim & "='" & p_TableHTTG.Rows(p_Count1).Item(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim).ToString.Trim() & "'"
                            End If
                        Else
                            If p_SQL_Where = "" Then
                                p_SQL_Where = " " & p_Table.Rows(p_CountSTT).Item(p_LoaiHinhVanChuyen).ToString.Trim & "=" & p_TableHTTG.Rows(p_Count1).Item(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim).ToString.Trim()
                            Else
                                p_SQL_Where = p_SQL_Where & " and " & p_Table.Rows(p_CountSTT).Item(p_LoaiHinhVanChuyen).ToString.Trim & "=" & p_TableHTTG.Rows(p_Count1).Item(p_Table.Rows(p_CountSTT).Item("FromField").ToString.Trim).ToString.Trim()
                            End If
                        End If

                    End If


                    'Case "THUY"

                    ' Case Else

                    ' End Select

                Next

                If p_SQL_Where <> "" Then
                    p_RowArr = p_TableScadar_E5.Select(p_SQL_Where)
                    If p_RowArr.Length > 0 Then
                        p_TableHTTG.Rows(p_Count1).Item("LenhScadar") = 1

                    End If
                End If
            Next
        End If


        '   Next
    End Sub



    Function GetLoadingSite(ByVal p_LoaiVanChuyen As String) As String
        Dim p_Value As String
        Dim p_Count As Integer

        GetLoadingSite = "Sat"
        Try
            If Not p_TablePara Is Nothing Then
                For p_Count = 0 To p_TablePara.Rows.Count - 1
                    p_Value = p_TablePara.Rows(p_Count).Item("Value_nd").ToString.Trim
                    If InStr(p_Value, p_LoaiVanChuyen, CompareMethod.Text) > 0 Then
                        GetLoadingSite = p_TablePara.Rows(p_Count).Item("Para").ToString.Trim
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Function


    Private Sub GetDataScadar(ByVal p_SoLenh As String, ByVal g_LoaiHinhVanChuyen As String, ByVal p_Terminal As String, ByRef p_TableScadar As DataTable, _
                                        ByRef p_TableScadar_E5 As DataTable, ByVal p_Int As String)
        Dim p_RowData As DataRow
        Dim p_SQL As String
        Dim p_Tbl As DataTable
        Dim p_StrConnect As String
        Dim p_SQLErr As String


        If g_WCF = True Then
            p_SQLErr = g_Services.CheckClsScadarToHTTG(p_TableScadar, p_TableScadar_E5, p_Int, p_SoLenh, g_LoaiHinhVanChuyen, p_Terminal, True, g_E5)
        Else
            Dim p_SAP_Obj As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            p_SQLErr = p_SAP_Obj.CheckClsScadarToHTTG(p_TableScadar, p_TableScadar_E5, p_Int, p_SoLenh, g_LoaiHinhVanChuyen, p_Terminal, True, g_E5)
        End If




        'p_SQL = "select * from tblMap_cp where Client='" & p_Client & "' and status='in' "
        'p_Tbl = GetDataTable(p_SQL, p_SQL)
        'If p_Tbl Is Nothing Then
        '    Exit Sub
        'End If
        'If p_Tbl.Rows.Count <= 0 Then
        '    Exit Sub
        'End If

        'p_StrConnect = "Provider=SQLOLEDB;Server=" & p_Tbl.Rows(0).Item("ServerScada").ToString.Trim & _
        '                ";Database=" & p_Tbl.Rows(0).Item("DatabaseScada").ToString.Trim & _
        '                ";User ID=" & p_Tbl.Rows(0).Item("UidScada").ToString.Trim & _
        '                ";Password=" & p_Tbl.Rows(0).Item("PwdScada").ToString.Trim & _
        '                ";Trusted_Connection=False"
        'p_SQL = "Select * from "

        'If p_tblScadar Is Nothing Then

        'End If


    End Sub

    Private Sub FrmCheckScadar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        Dim p_ArrRow() As DataRow
        Dim p_DataSet As DataSet
        Dim p_Count As Integer
        Dim p_DataTable As DataTable
        Dim p_Binding As Windows.Forms.Binding
        p_SQL = "select Para, Value_nd  from tblPara  where Para in ('Bo','Thuy','Sat')"
        p_TablePara = GetDataTable(p_SQL, p_SQL)


        p_SQL = "select * from SYS_CONFIG"
        p_Table_Sys_Config = GetDataTable(p_SQL, p_SQL)

        p_ArrRow = p_Table_Sys_Config.Select("KEYCODE='MATUDONGHOA'")
        If p_ArrRow.Length > 0 Then
            p_MaTuDongHoa = IIf(p_ArrRow(0).Item("KEYVALUE").ToString.Trim = "", "N", p_ArrRow(0).Item("KEYVALUE").ToString.Trim)
        End If

        p_SQL = ""
        p_SQL = "select Para, Value_nd  from tblPara  where Para in ('Bo','Thuy','Sat', 'FO')"
        p_TablePara = GetDataTable(p_SQL, p_SQL)

        p_SQL = "Select * from tblMap_cp where    status='in';"
        p_SQL = p_SQL & "Select * from tblMap_cp where   status='out';  select Status ,Name  from FPT_TrangThaiLenh_V;"
        p_DataSet = GetDataSet(p_SQL, p_SQL)

        p_TblConfig_In = p_DataSet.Tables(0)
        p_TblConfig_Out = p_DataSet.Tables(1)

        ' p_SQL = "select Status ,Name  from FPT_TrangThaiLenh_V"
        p_DataTable = p_DataSet.Tables(2)

        'For p_Count = 0 To p_DataTable.Rows.Count - 1
        '    TrangThai.Properties.Items.Add(p_DataTable.Rows(p_Count).Item("Name").ToString.Trim)
        'Next

        'Me.TrangThai.Properties.ReadOnly = True
        'TrangThai.Properties.Items.Add("sdfsf")
        'TrangThai.Properties.Items.Add("5555")

        ' Me.U_ComboboxEdit1.DataSource = p_DataTable
        ' p_Binding.WriteValue( = p_DataTable
        'Me.TrangThai.Add("anhqh")
        'Me.TrangThai.Add("anhqh")
        'Me.TrangThai.ItemVal()

    End Sub

    Private Sub U_CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_CheckBox1.CheckedChanged

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim p_Error As String
        If p_XtraModuleObj.p_ModGridExportToExcelNew(TrueDBGrid1, _
                                                  p_Error) = True Then

        End If
    End Sub
End Class