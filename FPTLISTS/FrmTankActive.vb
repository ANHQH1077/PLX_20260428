Public Class FrmTankActive
    Dim p_ConVert_Date As String
    Dim p_TblConfig As DataTable

    Private p_TYTRONG_PTANG As Boolean = False

    Private Sub FrmTankActiveNew_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            Save()
        End If
    End Sub
    Private Sub FrmTankActiveNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_DateValue As Date
        Dim p_TimeValue As Integer
        Dim p_DataTable, p_Table, p_Tbl As DataTable
        Dim p_SQL As String
        Dim p_DataRow() As DataRow
        Dim p_Col As U_TextBox.GridColumn

        p_Col = Me.GridView2.Columns.ColumnByName("HS_GianNo")
        p_Col.FieldView = ""
        p_Col.Visible = False
        p_SQL = "select name from SYS.all_objects  where upper(name) =upper('FPT_tblTankActiveE_V')"
        p_Tbl = GetDataTable(p_SQL, p_SQL)
        If Not p_Tbl Is Nothing Then
            If p_Tbl.Rows.Count > 0 Then
                Me.GridView2.ViewName = "FPT_tblTankActiveE_V"
                p_Col = Me.GridView2.Columns.ColumnByName("HS_GianNo")
                p_Col.FieldView = "HS_GianNo"
                p_Col.VisibleIndex = 6
            End If
        End If
        ' p_XtraUserName = g_User_ID
        p_GetDateTime(p_DateValue, p_TimeValue)
        p_ConVert_Date = p_DateValue.ToString("dd") & "/" & p_DateValue.ToString("MM") & "/" & p_DateValue.ToString("yyyy")

        If g_Filter_Terminal = True Then
            If g_Terminal <> "" Then
                Me.GridView2.Where = "Date_nd='" & p_ConVert_Date.ToString & "' and ( left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  ) "
                Me.GridView1.Where = "(left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "' )"
            End If
        Else
            Me.GridView2.Where = "Date_nd='" & p_ConVert_Date.ToString & "'"
        End If

        If g_Company_Code <> "6610" Then
            Me.TSB_SYNLMS.Visible = False
        End If

        p_SQL = "Select * from SYS_CONFIG "
        p_DataTable = GetDataTable(p_SQL, p_SQL)

        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                'If p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim = "N" Then
                '    Me.GridView1.Columns.Item("Name_ND").VisibleIndex = -1
                'End If

                'p_TYTRONG_PTANG
                p_TYTRONG_PTANG = False
                p_DataRow = p_DataTable.Select("KEYCODE='TYTRONG_PTANG'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_TYTRONG_PTANG = True
                        'U_TextBox
                    End If
                End If


                ToolStripButton3.Visible = False
                p_DataRow = p_DataTable.Select("KEYCODE='SAP_LMS'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        ToolStripButton3.Visible = True
                        'U_TextBox
                    End If
                End If

            End If
        End If

      



        p_XtraUserName = g_UserName
        'Me.DefaultFormLoad = True
        'Me.Form1_Load(e, sender)
        p_SQL = "Select * from tblMap_cp where  Client like '%E5%' and status='out'"
        p_TblConfig = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

        Me.DefaultFormLoad = True
        Me.Form1_Load(sender, e)
        Me.DefaultFormLoad = False

        Try
            Me.GridView2.Columns.Item("Tank_App").VisibleIndex = -1
        Catch ex As Exception

        End Try

        p_SQL = "select * from sys_config where upper(KeyCode)='" & UCase("TANKAPPROVED") & "'"
        ' p_SQL = "select isnull( Tank_App,'N') as Tank_App  from SYS_USER  where upper(USER_NAME )=upper('" & g_UserName & "')"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    'p_ShowApp3000 = True
                    ' Me.ReportGroup.Visible = True
                    ' Me.LabelControl7.Visible = True
                    Me.GridView2.Columns.Item("Tank_App").VisibleIndex = Me.GridView2.Columns.Count
                    Me.GridView2.Columns.Item("Tank_App").OptionsColumn.ReadOnly = True
                End If
            End If
        End If



        'p_SQL = "select * from sys_config where upper(KeyCode)='" & UCase("TANKAPPROVED") & "'"
        p_SQL = "select isnull( Tank_App,'N') as Tank_App  from SYS_USER  where upper(USER_NAME )=upper('" & g_UserName & "')"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("Tank_App").ToString.Trim = "Y" Then
                    'p_ShowApp3000 = True
                    ' Me.ReportGroup.Visible = True
                    ' Me.LabelControl7.Visible = True
                    ' Me.GridView2.Columns.Item("Tank_App").VisibleIndex = Me.GridView2.Columns.Count
                    Me.GridView2.Columns.Item("Tank_App").OptionsColumn.ReadOnly = False
                End If
            End If
        End If


        If p_TYTRONG_PTANG = False Then
            Me.GridView2.Columns.Item("FromDate").VisibleIndex = -1
        Else
            Me.GridView2.Columns.Item("FromDate").Width = 180
        End If


        Me.GridView2.BestFitColumns()
        Me.GridView1.BestFitColumns()
    End Sub

    Private Sub GridView2_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        Dim p_Row As DataRow
        Dim p_DateTime As DateTime
        Dim p_Column As U_TextBox.GridColumn

        p_Row = Me.GridView2.GetDataRow(e.RowHandle)
        If p_Row.Item("Date_nd").ToString.Trim = "" Then
            Me.GridView2.SetFocusedRowCellValue("Date_nd", p_ConVert_Date)
        End If

        
        p_Column = Me.GridView2.FocusedColumn


        '  p_GetCurrentDate(p_DateTime)
        '  p_Column = e.Column
        p_Row = GridView2.GetFocusedDataRow


        If Not p_Row Is Nothing Then
            If UCase(p_Column.FieldView) <> UCase("FromDate") And GridView2.FocusedRowModified = True Then   'And (p_DataRow.RowState = DataRowState.Modified Or p_DataRow.RowState = DataRowState.Added) Then

                p_GetCurrentDate(p_DateTime)
                p_Row.Item("FromDate") = p_DateTime
               
            End If
        End If


    End Sub


    Sub Save_KV2()
        Dim p_DataTable As DataTable
        Dim p_DataTable_Grid As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_ArrRow() As DataRow
        Dim p_CountH As Integer
        Dim p_Count As Integer
        Dim p_Connect As String
        Dim p_SQL As String

        ' Dim p_SQL
        Dim p_TableCheck As DataTable

        Dim p_TblExeHTTG As New DataTable("Table01")
        Dim p_TblExeScadar As New DataTable("Table02")
        'Server=10.0.1.20;Database=AAScada2_Test_KV2;User ID=sa;Password=123456;Trusted_Connection=False;
        p_TblExeHTTG.Columns.Add("STR_SQL")
        p_TblExeScadar.Columns.Add("STR_SQL")
        Dim p_RowAdd As DataRow

        Dim p_DateTime As DateTime = Now

        Dim p_TableCapNhatTyTrongE5 As New DataTable("Table002")
        Dim p_RowAdd22 As DataRow
        p_TableCapNhatTyTrongE5.Columns.Add("SQL_STR")

        p_GetCurrentDate(p_DateTime)


        Me.GridView1.Focus()
        Me.GridView2.RefreshData()

        Me.Focus()

        Dim p_Tytrong_Nen As Double
        Dim p_TyTrong_E As Double
        Dim p_TyLe As Double
        Dim p_HSGianNo As Double

        Dim p_BeXuat As String = ""

        'anhqh
        '20171225
        'Cap nhat ty trong len bang ty trong cua E5    ====================buoc 1
        Me.TrueDBGrid2.Update()
        p_Binding = Me.GridView2.DataSource
        p_DataTable_Grid = CType(p_Binding.DataSource, DataTable)
        p_DataTable_Grid.AcceptChanges()
        If Not p_DataTable_Grid Is Nothing Then
            For p_Count = 0 To p_DataTable_Grid.Rows.Count - 1
                If p_DataTable_Grid.Rows(p_Count).Item("CHECKUPD").ToString.Trim = "Y" Or p_DataTable_Grid.Rows(p_Count).Item("CHECKUPD").ToString.Trim = "I" Then
                    If p_DataTable_Grid.Rows(p_Count).Item("CHECKUPD").ToString.Trim = "I" Then
                        p_SQL = "select * from tblTankActive with (nolock) where Date_nd  = '" & p_DataTable_Grid.Rows(p_Count).Item("Date_nd").ToString.Trim & "' and Name_Nd='" & p_DataTable_Grid.Rows(p_Count).Item("Name_nd").ToString.Trim & "'"
                        p_TableCheck = GetDataTable(p_SQL, p_SQL)

                        If Not p_TableCheck Is Nothing Then
                            If p_TableCheck.Rows.Count > 0 Then
                                ShowMessageBox("", "Mã bể " & p_DataTable_Grid.Rows(p_Count).Item("Name_nd").ToString.Trim & " đã có trong hệ thống")
                                Exit Sub
                            End If
                        End If

                    End If
                    p_RowAdd22 = p_TableCapNhatTyTrongE5.NewRow
                    p_RowAdd22.Item(0) = p_DataTable_Grid.Rows(p_Count).Item("Name_nd").ToString.Trim
                    p_TableCapNhatTyTrongE5.Rows.Add(p_RowAdd22)
                End If
            Next
        End If

        For p_Count = 0 To Me.GridView2.RowCount - 1
            p_RowAdd = Me.GridView2.GetDataRow(p_Count)
            If Not p_RowAdd Is Nothing Then
                If p_RowAdd.Item("CHECKUPD").ToString.Trim = "Y" Or p_RowAdd.Item("CHECKUPD").ToString.Trim = "I" Then

                    If p_RowAdd.Item("FromDate").ToString.Trim = "" Then
                        p_RowAdd.Item("FromDate") = p_DateTime
                        GridView2.SetRowCellValue(p_Count, "FromDate", p_DateTime)
                    End If

                    CapNhatLichSuTaiTrongPhanTang(pv_LineRemove, _
                                                    0, _
                                                     "", _
                                                     "0", _
                                                     p_RowAdd.Item("Name_ND").ToString.Trim, _
                                                     CDbl(p_RowAdd.Item("Dens_nd").ToString.Trim), _
                                                     p_RowAdd.Item("LoadingSite").ToString.Trim, _
                                                     p_RowAdd.Item("Product_nd").ToString.Trim, _
                                                    g_UserName, p_RowAdd.Item("FromDate"))
                End If
            End If
        Next

        Me.DefaultSave = True
        Me.UpdateToDatabase(Me, "")
        Me.DefaultSave = False
        Me.GridView1.BestFitColumns()
        Me.GridView2.BestFitColumns()


        p_TblExeScadar.Clear()
        'anhqh
        '20171225
        'Cap nhat ty trong len bang ty trong cua E5    ====================buoc 2
        If Not p_TblConfig Is Nothing And Not p_TableCapNhatTyTrongE5 Is Nothing Then
            If p_TblConfig.Rows.Count > 0 Then
                p_Connect = "Provider=SQLOLEDB;Server=" & p_TblConfig.Rows(0).Item("ServerScada").ToString.Trim & _
                        ";Database=" & p_TblConfig.Rows(0).Item("DatabaseScada").ToString.Trim & _
                        ";User ID=" & p_TblConfig.Rows(0).Item("UidScada").ToString.Trim & _
                        ";Password=" & p_TblConfig.Rows(0).Item("PwdScada").ToString.Trim & _
                        ";Trusted_Connection=False"
                'Me.TrueDBGrid2.Update()
                'Me.GridView2.MoveFirst()
                'p_Binding = Me.TrueDBGrid2.DataSource
                'p_DataTable_Grid = CType(p_Binding.DataSource, DataTable)
                'p_ArrRow = p_DataTable_Grid.Select("CHECKUPD='Y'")

                For p_CountH = 0 To p_TableCapNhatTyTrongE5.Rows.Count - 1

                    p_SQL = "exec FPT_GetTankActiveUpdateToE5_E '" & p_TableCapNhatTyTrongE5.Rows(p_CountH).Item(0).ToString.Trim & "',0"   ' tblMeterE5"
                    p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                    'If p_DataTable Is Nothing Then
                    '    p_SQL = "exec FPT_GetTankActiveUpdateToE5 '" & p_TableCapNhatTyTrongE5.Rows(p_CountH).Item(0).ToString.Trim & "',0"   ' tblMeterE5"
                    '    p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                    'End If
                    'p_SQL = "exec FPT_GetTankActiveUpdateToE5 '" & p_TableCapNhatTyTrongE5.Rows(p_CountH).Item(0).ToString.Trim & "',0"   ' tblMeterE5"
                    'p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                    If Not p_DataTable Is Nothing Then
                        With p_DataTable
                            For p_Count = 0 To p_DataTable.Rows.Count - 1
                                p_SQL = "INSERT INTO [tblMeterE5History]  ([ArmNo] ,[ERate],[TyTrongNen],[TyTrongE], Ma_Hhoa, " & _
                                        "TankID, TankE, UserCode, CreateDate)  "
                                p_SQL = p_SQL & " VALUES(" & _
                                                        .Rows(p_Count).Item("ArmNo").ToString.Trim & _
                                                        "," & .Rows(p_Count).Item("ERate").ToString.Trim & _
                                                        "," & .Rows(p_Count).Item("TyTrongNen").ToString.Trim & _
                                                        "," & .Rows(p_Count).Item("TyTrongE").ToString.Trim & _
                                                        ",'" & .Rows(p_Count).Item("Ma_Hhoa").ToString.Trim & "'" & _
                                                        ",'" & .Rows(p_Count).Item("TankID").ToString.Trim & "'" & _
                                                        ",'" & .Rows(p_Count).Item("TankE").ToString.Trim & "'" & _
                                                        ",'" & g_UserName & "', getdate()" & _
                                                        ")"
                                p_RowAdd = p_TblExeHTTG.NewRow
                                p_RowAdd.Item(0) = p_SQL
                                p_TblExeHTTG.Rows.Add(p_RowAdd)

                                'Insert sang TyTrongE5 cua Scadar

                                Double.TryParse(.Rows(p_Count).Item("TyTrongNen").ToString.Trim, p_Tytrong_Nen)
                                Double.TryParse(.Rows(p_Count).Item("TyTrongE").ToString.Trim, p_TyTrong_E)
                                Double.TryParse(.Rows(p_Count).Item("ERate").ToString.Trim, p_TyLe)
                                Double.TryParse(.Rows(p_Count).Item("HS_GianNoE").ToString.Trim, p_HSGianNo)

                                
                                If p_TyLe = 0 Or p_TyTrong_E = 0 Or p_HSGianNo = 0 Or p_Tytrong_Nen = 0 Then
                                    ShowMessageBox("", "Thông tin Tỷ lệ phối trộn hoặc Tỷ trọng Nền hoặc Tỷ trọng (Hệ số giãn nở) Ethanol không xác định")
                                    Continue For
                                End If
                                p_SQL = "INSERT INTO [TYTRONGE5]  (Dateandtime, [Ma_hong] ,[Tyle],[Tytrong_Base],[Tytrong_E],HS_GianNo, Ma_Hhoa, Be_Base, Be_E)  "
                                p_SQL = p_SQL & " VALUES (getdate()," & _
                                                        .Rows(p_Count).Item("ArmNo").ToString.Trim & _
                                                        "," & .Rows(p_Count).Item("ERate").ToString.Trim & _
                                                         "," & p_Tytrong_Nen & _
                                                        "," & p_TyTrong_E & _
                                                        "," & p_HSGianNo & _
                                                        ",'" & getHangHoaE5(.Rows(p_Count).Item("Ma_Hhoa").ToString.Trim) & "'" & _
                                                        ",'" & .Rows(p_Count).Item("TankID").ToString.Trim & "'" & _
                                                        ",'" & .Rows(p_Count).Item("TankE").ToString.Trim & "'" & _
                                                        ")"

                                p_RowAdd = p_TblExeScadar.NewRow
                                p_RowAdd.Item(0) = p_SQL
                                p_TblExeScadar.Rows.Add(p_RowAdd)
                            Next
                        End With
                    End If
                Next

                If p_TblExeHTTG.Rows.Count > 0 Then
                    If g_Services.Sys_Execute_DataTbl(p_TblExeHTTG, p_SQL) = False Then
                        ShowMessageBox("", p_SQL)
                        Exit Sub
                    End If
                End If

                If Not p_TblExeScadar Is Nothing Then
                    If p_TblExeScadar.Rows.Count > 0 Then
                        If Not p_TblConfig Is Nothing Then
                            If p_TblConfig.Rows.Count > 0 Then

                                For p_Count = 0 To p_TblConfig.Rows.Count - 1
                                    If g_Filter_Terminal = True Then
                                        If Mid(p_TblConfig.Rows(p_Count).Item("Client").ToString.Trim, 1, 1) = g_Terminal Then
                                            p_Connect = "Provider=SQLOLEDB;Server=" & p_TblConfig.Rows(p_Count).Item("ServerScada").ToString.Trim & _
                                               ";Database=" & p_TblConfig.Rows(p_Count).Item("DatabaseScada").ToString.Trim & _
                                               ";User ID=" & p_TblConfig.Rows(p_Count).Item("UidScada").ToString.Trim & _
                                               ";Password=" & p_TblConfig.Rows(p_Count).Item("PwdScada").ToString.Trim & _
                                               ";Trusted_Connection=False"
                                            'If Not p_DataTableExeE5 Is Nothing Then
                                            '    If p_DataTableExeE5.Rows.Count > 0 Then
                                            If g_Services.Execute_DataTbl_With_Connection(p_Connect, p_TblExeScadar, _
                                                                           p_SQL) = False Then
                                                ShowStatusMessage(True, "", "Lỗi khi cập nhật Tỷ trọng xăng nền và Ethanol xuống Tự động hóa", 10)
                                                ShowMessageBox("", p_SQL)
                                                Exit Sub
                                            End If
                                        End If
                                    Else
                                        p_Connect = "Provider=SQLOLEDB;Server=" & p_TblConfig.Rows(p_Count).Item("ServerScada").ToString.Trim & _
                                                ";Database=" & p_TblConfig.Rows(p_Count).Item("DatabaseScada").ToString.Trim & _
                                                ";User ID=" & p_TblConfig.Rows(p_Count).Item("UidScada").ToString.Trim & _
                                                ";Password=" & p_TblConfig.Rows(p_Count).Item("PwdScada").ToString.Trim & _
                                                ";Trusted_Connection=False"
                                        'If Not p_DataTableExeE5 Is Nothing Then
                                        '    If p_DataTableExeE5.Rows.Count > 0 Then
                                        If g_Services.Execute_DataTbl_With_Connection(p_Connect, p_TblExeScadar, _
                                                                       p_SQL) = False Then
                                            ShowStatusMessage(True, "", "Lỗi khi cập nhật Tỷ trọng xăng nền và Ethanol xuống Tự động hóa", 10)
                                            ShowMessageBox("", p_SQL)
                                            Exit Sub
                                        End If
                                    End If

                                    ' End If
                                    ' End If
                                Next
                            End If
                        End If
                    End If
                End If
            End If
        End If



        ' End If
    End Sub



    Sub Save()
        Dim p_DataTable As DataTable
        Dim p_DataTable_Grid As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_ArrRow() As DataRow
        Dim p_CountH As Integer
        Dim p_Count As Integer
        Dim p_Connect As String
        Dim p_SQL As String

        ' Dim p_SQL
        Dim p_TableCheck As DataTable

        Dim p_TblExeHTTG As New DataTable("Table01")
        Dim p_TblExeScadar As New DataTable("Table02")
        'Server=10.0.1.20;Database=AAScada2_Test_KV2;User ID=sa;Password=123456;Trusted_Connection=False;
        p_TblExeHTTG.Columns.Add("STR_SQL")
        p_TblExeScadar.Columns.Add("STR_SQL")
        Dim p_RowAdd As DataRow

        Dim p_DateTime As DateTime = Now

        Dim p_TableCapNhatTyTrongE5 As New DataTable("Table002")
        Dim p_RowAdd22 As DataRow
        p_TableCapNhatTyTrongE5.Columns.Add("SQL_STR")

        p_GetCurrentDate(p_DateTime)


        Me.GridView1.Focus()
        Me.GridView2.RefreshData()
      
        Me.Focus()

        Dim p_Tytrong_Nen As Double
        Dim p_TyTrong_E As Double
        Dim p_TyLe As Double


        Dim p_BeXuat As String = ""

        'anhqh
        '20171225
        'Cap nhat ty trong len bang ty trong cua E5    ====================buoc 1
        Me.TrueDBGrid2.Update()
        p_Binding = Me.GridView2.DataSource
        p_DataTable_Grid = CType(p_Binding.DataSource, DataTable)
        p_DataTable_Grid.AcceptChanges()
        If Not p_DataTable_Grid Is Nothing Then
            For p_Count = 0 To p_DataTable_Grid.Rows.Count - 1
                If p_DataTable_Grid.Rows(p_Count).Item("CHECKUPD").ToString.Trim = "Y" Or p_DataTable_Grid.Rows(p_Count).Item("CHECKUPD").ToString.Trim = "I" Then
                    If p_DataTable_Grid.Rows(p_Count).Item("CHECKUPD").ToString.Trim = "I" Then
                        p_SQL = "select * from tblTankActive with (nolock) where Date_nd  = '" & p_DataTable_Grid.Rows(p_Count).Item("Date_nd").ToString.Trim & "' and Name_Nd='" & p_DataTable_Grid.Rows(p_Count).Item("Name_nd").ToString.Trim & "'"
                        p_TableCheck = GetDataTable(p_SQL, p_SQL)

                        If Not p_TableCheck Is Nothing Then
                            If p_TableCheck.Rows.Count > 0 Then
                                ShowMessageBox("", "Mã bể " & p_DataTable_Grid.Rows(p_Count).Item("Name_nd").ToString.Trim & " đã có trong hệ thống")
                                Exit Sub
                            End If
                        End If

                    End If
                    p_RowAdd22 = p_TableCapNhatTyTrongE5.NewRow
                    p_RowAdd22.Item(0) = p_DataTable_Grid.Rows(p_Count).Item("Name_nd").ToString.Trim
                    p_TableCapNhatTyTrongE5.Rows.Add(p_RowAdd22)
                End If
            Next
        End If

        For p_Count = 0 To Me.GridView2.RowCount - 1
            p_RowAdd = Me.GridView2.GetDataRow(p_Count)
            If Not p_RowAdd Is Nothing Then
                If p_RowAdd.Item("CHECKUPD").ToString.Trim = "Y" Or p_RowAdd.Item("CHECKUPD").ToString.Trim = "I" Then

                    If p_RowAdd.Item("FromDate").ToString.Trim = "" Then
                        p_RowAdd.Item("FromDate") = p_DateTime
                        GridView2.SetRowCellValue(p_Count, "FromDate", p_DateTime)
                    End If

                    CapNhatLichSuTaiTrongPhanTang(pv_LineRemove, _
                                                    0, _
                                                     "", _
                                                     "0", _
                                                     p_RowAdd.Item("Name_ND").ToString.Trim, _
                                                     CDbl(p_RowAdd.Item("Dens_nd").ToString.Trim), _
                                                     p_RowAdd.Item("LoadingSite").ToString.Trim, _
                                                     p_RowAdd.Item("Product_nd").ToString.Trim, _
                                                    g_UserName, p_RowAdd.Item("FromDate"))
                End If
            End If
        Next

        Me.DefaultSave = True
        Me.UpdateToDatabase(Me, "")
        Me.DefaultSave = False
        Me.GridView1.BestFitColumns()
        Me.GridView2.BestFitColumns()


        p_TblExeScadar.Clear()
        'anhqh
        '20171225
        'Cap nhat ty trong len bang ty trong cua E5    ====================buoc 2
        If Not p_TblConfig Is Nothing And Not p_TableCapNhatTyTrongE5 Is Nothing Then
            If p_TblConfig.Rows.Count > 0 Then
                p_Connect = "Provider=SQLOLEDB;Server=" & p_TblConfig.Rows(0).Item("ServerScada").ToString.Trim & _
                        ";Database=" & p_TblConfig.Rows(0).Item("DatabaseScada").ToString.Trim & _
                        ";User ID=" & p_TblConfig.Rows(0).Item("UidScada").ToString.Trim & _
                        ";Password=" & p_TblConfig.Rows(0).Item("PwdScada").ToString.Trim & _
                        ";Trusted_Connection=False"
                'Me.TrueDBGrid2.Update()
                'Me.GridView2.MoveFirst()
                'p_Binding = Me.TrueDBGrid2.DataSource
                'p_DataTable_Grid = CType(p_Binding.DataSource, DataTable)
                'p_ArrRow = p_DataTable_Grid.Select("CHECKUPD='Y'")

                For p_CountH = 0 To p_TableCapNhatTyTrongE5.Rows.Count - 1

                    p_SQL = "exec FPT_GetTankActiveUpdateToE5 '" & p_TableCapNhatTyTrongE5.Rows(p_CountH).Item(0).ToString.Trim & "',0"   ' tblMeterE5"
                    p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

                    'p_SQL = "exec FPT_GetTankActiveUpdateToE5 '" & p_TableCapNhatTyTrongE5.Rows(p_CountH).Item(0).ToString.Trim & "',0"   ' tblMeterE5"
                    'p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                    If Not p_DataTable Is Nothing Then
                        With p_DataTable
                            For p_Count = 0 To p_DataTable.Rows.Count - 1
                                p_SQL = "INSERT INTO [tblMeterE5History]  ([ArmNo] ,[ERate],[TyTrongNen],[TyTrongE], Ma_Hhoa, " & _
                                        "TankID, TankE, UserCode, CreateDate)  "
                                p_SQL = p_SQL & " VALUES(" & _
                                                        .Rows(p_Count).Item("ArmNo").ToString.Trim & _
                                                        "," & .Rows(p_Count).Item("ERate").ToString.Trim & _
                                                        "," & .Rows(p_Count).Item("TyTrongNen").ToString.Trim & _
                                                        "," & .Rows(p_Count).Item("TyTrongE").ToString.Trim & _
                                                        ",'" & .Rows(p_Count).Item("Ma_Hhoa").ToString.Trim & "'" & _
                                                        ",'" & .Rows(p_Count).Item("TankID").ToString.Trim & "'" & _
                                                        ",'" & .Rows(p_Count).Item("TankE").ToString.Trim & "'" & _
                                                        ",'" & g_UserName & "', getdate()" & _
                                                        ")"
                                p_RowAdd = p_TblExeHTTG.NewRow
                                p_RowAdd.Item(0) = p_SQL
                                p_TblExeHTTG.Rows.Add(p_RowAdd)

                                'Insert sang TyTrongE5 cua Scadar

                                Double.TryParse(.Rows(p_Count).Item("TyTrongNen").ToString.Trim, p_Tytrong_Nen)
                                Double.TryParse(.Rows(p_Count).Item("TyTrongE").ToString.Trim, p_TyTrong_E)
                                Double.TryParse(.Rows(p_Count).Item("ERate").ToString.Trim, p_TyLe)

                                If p_TyLe = 0 Or p_TyTrong_E = 0 Or p_Tytrong_Nen = 0 Then
                                    ShowMessageBox("", "Thông tin Tỷ lệ phối trộn hoặc Tỷ trọng Nền hoặc Tỷ trọng Ethanol không xác định")
                                    Continue For
                                End If
                                p_SQL = "INSERT INTO [TYTRONGE5]  (Dateandtime, [Ma_hong] ,[Tyle],[Tytrong_Base],[Tytrong_E], Ma_Hhoa, Be_Base, Be_E)  "
                                p_SQL = p_SQL & " VALUES (getdate()," & _
                                                        .Rows(p_Count).Item("ArmNo").ToString.Trim & _
                                                        "," & .Rows(p_Count).Item("ERate").ToString.Trim & _
                                                         "," & p_Tytrong_Nen & _
                                                        "," & p_TyTrong_E & _
                                                        ",'" & getHangHoaE5(.Rows(p_Count).Item("Ma_Hhoa").ToString.Trim) & "'" & _
                                                        ",'" & .Rows(p_Count).Item("TankID").ToString.Trim & "'" & _
                                                        ",'" & .Rows(p_Count).Item("TankE").ToString.Trim & "'" & _
                                                        ")"

                                p_RowAdd = p_TblExeScadar.NewRow
                                p_RowAdd.Item(0) = p_SQL
                                p_TblExeScadar.Rows.Add(p_RowAdd)
                            Next
                        End With
                    End If
                Next

                If p_TblExeHTTG.Rows.Count > 0 Then
                    If g_Services.Sys_Execute_DataTbl(p_TblExeHTTG, p_SQL) = False Then
                        ShowMessageBox("", p_SQL)
                        Exit Sub
                    End If
                End If

                If Not p_TblExeScadar Is Nothing Then
                    If p_TblExeScadar.Rows.Count > 0 Then
                        If Not p_TblConfig Is Nothing Then
                            If p_TblConfig.Rows.Count > 0 Then

                                For p_Count = 0 To p_TblConfig.Rows.Count - 1
                                    If g_Filter_Terminal = True Then
                                        If Mid(p_TblConfig.Rows(p_Count).Item("Client").ToString.Trim, 1, 1) = g_Terminal Then
                                            p_Connect = "Provider=SQLOLEDB;Server=" & p_TblConfig.Rows(p_Count).Item("ServerScada").ToString.Trim & _
                                               ";Database=" & p_TblConfig.Rows(p_Count).Item("DatabaseScada").ToString.Trim & _
                                               ";User ID=" & p_TblConfig.Rows(p_Count).Item("UidScada").ToString.Trim & _
                                               ";Password=" & p_TblConfig.Rows(p_Count).Item("PwdScada").ToString.Trim & _
                                               ";Trusted_Connection=False"
                                            'If Not p_DataTableExeE5 Is Nothing Then
                                            '    If p_DataTableExeE5.Rows.Count > 0 Then
                                            If g_Services.Execute_DataTbl_With_Connection(p_Connect, p_TblExeScadar, _
                                                                           p_SQL) = False Then
                                                ShowStatusMessage(True, "", "Lỗi khi cập nhật Tỷ trọng xăng nền và Ethanol xuống Tự động hóa", 10)
                                                ShowMessageBox("", p_SQL)
                                                Exit Sub
                                            End If
                                        End If
                                    Else
                                        p_Connect = "Provider=SQLOLEDB;Server=" & p_TblConfig.Rows(p_Count).Item("ServerScada").ToString.Trim & _
                                                ";Database=" & p_TblConfig.Rows(p_Count).Item("DatabaseScada").ToString.Trim & _
                                                ";User ID=" & p_TblConfig.Rows(p_Count).Item("UidScada").ToString.Trim & _
                                                ";Password=" & p_TblConfig.Rows(p_Count).Item("PwdScada").ToString.Trim & _
                                                ";Trusted_Connection=False"
                                        'If Not p_DataTableExeE5 Is Nothing Then
                                        '    If p_DataTableExeE5.Rows.Count > 0 Then
                                        If g_Services.Execute_DataTbl_With_Connection(p_Connect, p_TblExeScadar, _
                                                                       p_SQL) = False Then
                                            ShowStatusMessage(True, "", "Lỗi khi cập nhật Tỷ trọng xăng nền và Ethanol xuống Tự động hóa", 10)
                                            ShowMessageBox("", p_SQL)
                                            Exit Sub
                                        End If
                                    End If

                                    ' End If
                                    ' End If
                                Next
                            End If
                        End If
                    End If
                End If
            End If
        End If



        ' End If
    End Sub

    'Public Function getHangHoaE5(ByVal p_MaHangHoa As String) As String
    '    Dim p_SQL As String
    '    Dim p_Table As DataTable
    '    getHangHoaE5 = p_MaHangHoa
    '    Try
    '        p_SQL = "select MaHangHoa_Scada  from tblMap_MaHangHoa where MaHangHoa_Sap='" & p_MaHangHoa & "'"
    '        p_Table = GetDataTable(p_SQL, p_SQL)
    '        If Not p_Table Is Nothing Then
    '            If p_Table.Rows.Count > 0 Then
    '                getHangHoaE5 = p_Table.Rows(0).Item("MaHangHoa_Scada").ToString.Trim
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try


    'End Function

    Private Sub GridView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView2.KeyDown
        If e.KeyCode = Keys.Delete Then
            Me.TrueDBGrid2.DefaultRemove = True
            Me.GridView2.DefaultRemove = True
            TankActive_Removed()
            Me.TrueDBGrid2.DefaultRemove = False
            Me.GridView2.DefaultRemove = False
        End If
    End Sub



    Private Sub GridView2_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView2.ValidatingEditor
        Dim p_Value As Double
        Dim p_String As String
        Dim p_Gridview As U_TextBox.GridView
        Dim p_DataRow As DataRow
        Dim p_DateTime As DateTime
        Dim p_Column As U_TextBox.GridColumn
        Try

            p_Column = Me.GridView1.FocusedColumn
            p_Gridview = CType(sender, U_TextBox.GridView)
            '  p_DataRow = p_Gridview.GetFocusedDataRow
            p_Value = 0
            'p_String = p_DataRow.Item("Dens_nd").ToString.Trim
            'p_Column_Name=p_Gridview.get
            'p_GetCurrentDate(p_DateTime)
            ''  p_Column = e.Column
            'p_DataRow = GridView1.GetFocusedDataRow

            'If Not p_DataRow Is Nothing Then
            '    If UCase(p_Column.FieldView) <> UCase("FromDate") And (p_DataRow.RowState = DataRowState.Modified Or p_DataRow.RowState = DataRowState.Added) Then
            '        Me.GridView1.SetFocusedRowCellValue("FromDate", p_DateTime)
            '    End If
            'End If


            If UCase(p_Gridview.FocusedColumn.FieldName.ToString.Trim) = UCase("Dens_nd") Then
                p_String = e.Value.ToString.Trim
                p_Value = Val(p_String)
                If p_Value < 0.5 Or p_Value > 1.5 Then
                    MsgBox("Giá trị không hợp lệ - trong khoảng 0.5 -> 1.5", MsgBoxStyle.Critical, "Thông báo")
                    e.Valid = False
                    Exit Sub
                    ' p_Gridview.InvalidateRowCell(e.RowHandle, e.Column)
                ElseIf p_Value = 1 Or p_Value = 0 Then
                    MsgBox("Giá trị không hợp lệ", MsgBoxStyle.Critical, "Thông báo")
                    e.Valid = False
                    Exit Sub
                End If
                p_String = Format(p_Value, "#0.###0").ToString
                e.Value = p_String

            End If

        Catch ex As Exception
            MsgBox("Nhập sai định dạng số", MsgBoxStyle.Critical, "Thông báo")
        End Try
    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        TankActive_Insert()
    End Sub

    Private Sub TankActive_Insert()
        Dim p_DataRow As DataRow
        Dim p_DataRowArr() As Integer
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_DataTable As DataTable
        Dim p_Array() As DataRow
        Dim p_Count As Integer
        Dim cl_SOAP_API As New SOAP_API.CL_SOAP_API
        Dim Name_nd, Product_nd As String
        Dim cl_HTTG_COMMON As New HTTG_COMMON.CL_HTTG_COMMON
        cl_HTTG_COMMON.getSYS_CONFIG()

        If Me.GridView1.RowCount > 0 Then
            ' For p_Count = Me.GridView1.RowCount - 1 To 0 Step -1
            'If Me.GridView1.GetSelectedRow Then

            'End If
            p_DataRowArr = Me.GridView1.GetSelectedRows

            For p_Count = 0 To p_DataRowArr.Length - 1
                'p_DataRow = Me.GridView1.
                'If p_DataTable.Rows(p_DataTable.Rows.Count - 1).RowState = DataRowState.Deleted Then
                '    Continue For
                'End If
                p_DataRow = Me.GridView1.GetDataRow(p_DataRowArr(p_Count))
                If Not p_DataRow Is Nothing Then
                    Me.GridView2.RefreshData()
                    GridView2.MoveLast()
                    p_Binding = Me.TrueDBGrid2.DataSource
                    p_DataTable = CType(p_Binding.DataSource, DataTable)
                    If Not p_DataTable Is Nothing Then
                        p_Array = p_DataTable.Select("Name_nd='" & p_DataRow.Item("Name_nd").ToString.Trim & "'")
                        If p_Array.Length > 0 Then
                            ShowMessageBox("", "Bể xuất theo ngày đã tồn tại")
                            Exit Sub
                        End If
                    End If

                    If p_DataTable.Rows.Count >= 0 Then
                        Me.GridView2.AddNewRow()
                    Else
                        If p_DataTable.Rows(p_DataTable.Rows.Count - 1).RowState = DataRowState.Deleted Then
                            Me.GridView2.AddNewRow()
                        Else
                            If p_DataTable.Rows(p_DataTable.Rows.Count - 1).Item("Name_nd").ToString.Trim <> "" Then
                                Me.GridView2.AddNewRow()
                            End If
                        End If
                    End If

                    Name_nd = p_DataRow.Item("Name_nd").ToString.Trim
                    Product_nd = p_DataRow.Item("Product_nd").ToString.Trim

                    If cl_HTTG_COMMON.g_LMS = "Y" Then
                        p_DataRow.Item("Dens_nd") = cl_SOAP_API.GetDensity(Name_nd, Product_nd)
                    End If                    

                    Me.GridView2.SetFocusedRowCellValue("Name_nd", p_DataRow.Item("Name_nd").ToString.Trim)
                    Me.GridView2.SetFocusedRowCellValue("Dens_nd", p_DataRow.Item("Dens_nd").ToString.Trim)
                    Me.GridView2.SetFocusedRowCellValue("Product_nd", p_DataRow.Item("Product_nd").ToString.Trim)
                    Me.GridView2.SetFocusedRowCellValue("TenHangHoa", p_DataRow.Item("TenHangHoa").ToString.Trim)
                    Me.GridView2.SetFocusedRowCellValue("CHECKUPD", "I")
                End If
            Next
            Me.GridView1.DeleteSelectedRows()            
        End If
    End Sub

    Private Sub TankActive_Removed()
        Dim p_DataTbl As DataTable
        Dim p_DataTblCheck As DataTable
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_SQL As String
        Dim p_Row As DataRow

        Dim p_Count As Integer
        Dim p_Count1 As Integer
        Dim p_RowArray() As Integer


        Dim Name_nd, Dens_nd, Product_nd, TenHangHoa As String

        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_DataRow As DataRow
        If Me.GridView2.RowCount <= 0 Then
            Exit Sub
            'p_DataRow = Me.GridView2.GetFocusedDataRow
        End If

        p_RowArray = Me.GridView2.GetSelectedRows

        If p_RowArray.Length <= 0 Then
            Exit Sub
        End If

        p_ValueMess = p_XtraModuleObj.ShowMessage(Me, "", _
                      "Bạn có chắc chắn muốn thực hiện không? ", _
                      True, _
                       "Có", _
                      True, _
                      "Không", _
                      False, _
                      "", _
                       0)
        If p_ValueMess = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        'If p_DataRow Is Nothing Then
        '    Exit Sub
        'End If

        If p_RowArray.Length > 0 Then
            p_Binding = Me.TrueDBGrid1.DataSource
            p_DataTbl = CType(p_Binding.DataSource, DataTable)


            For p_Count1 = 0 To p_RowArray.Length - 1 ' To 0 Step -1
                Me.GridView2.SelectRow(p_RowArray(p_Count1))
                p_DataRow = Me.GridView2.GetDataRow(p_RowArray(p_Count1))
                Name_nd = p_DataRow.Item("Name_nd").ToString.Trim
                Dens_nd = p_DataRow.Item("Dens_nd").ToString.Trim
                Product_nd = p_DataRow.Item("Product_nd").ToString.Trim
                TenHangHoa = p_DataRow.Item("TenHangHoa").ToString.Trim

                p_SQL = "exec FPT_CheckTankRemoved '" & p_DataRow.Item("Name_nd").ToString.Trim & "'," & IIf(g_E5 = True, 1, 0) & ",1"
                p_DataTblCheck = GetDataTable(p_SQL, p_SQL)
                If Not p_DataTblCheck Is Nothing Then
                    If p_DataTblCheck.Rows.Count > 0 Then
                        For p_Count = 0 To p_DataTblCheck.Rows.Count - 1
                            If p_DataTblCheck.Rows(p_Count).Item("Require") = 1 Then
                                ShowMessageBox("", p_DataTblCheck.Rows(p_Count).Item("DescName").ToString)
                                Exit Sub
                            Else
                                ShowMessageBox("", p_DataTblCheck.Rows(p_Count).Item("DescName").ToString)
                            End If
                        Next
                    End If
                End If

                p_DataRow = p_DataTbl.NewRow
                p_DataRow.Item("Name_nd") = Name_nd
                p_DataRow.Item("Dens_nd") = Dens_nd
                p_DataRow.Item("Product_nd") = Product_nd
                p_DataRow.Item("TenHangHoa") = TenHangHoa
                p_DataTbl.Rows.Add(p_DataRow)

            Next
            Me.GridView2.DefaultRemove = True
            Me.TrueDBGrid2.EmbeddedNavigator.Buttons.DoClick(Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Remove)
            Me.GridView2.DefaultRemove = False
            p_Binding.DataSource = p_DataTbl
            Me.TrueDBGrid1.DataSource = p_Binding
            Me.TrueDBGrid1.RefreshDataSource()
        End If
        'Me.GridView1.AddNewRow()
        'GridView1.MoveLast()
        'Me.GridView1.SetFocusedRowCellValue("Name_nd", Name_nd)
        'Me.GridView1.SetFocusedRowCellValue("Dens_nd", Dens_nd)
        'Me.GridView1.SetFocusedRowCellValue("Product_nd", Product_nd)
        'Me.GridView1.SetFocusedRowCellValue("TenHangHoa", TenHangHoa)


    End Sub

    Private Sub U_ButtonCus2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus2.Click
        TankActive_Removed()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If g_Company_Code = "6610" Then
            Save_KV2()
        Else
            Save()
        End If

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim FrmVehicleTmp As New Form2
        FrmVehicleTmp.p_XtraModuleObj = p_XtraModuleObj
        FrmVehicleTmp.g_XtraServicesObj = g_XtraServicesObj
        ' FrmVehicleTmp.g_FormAddnew = True
        'FrmVehicleTmp.FormStatus = False
        FrmVehicleTmp.p_XtraToolTripLabel = g_ToolStripStatus
        FrmVehicleTmp.p_XtraMessageStatusl = g_MessageStatus
        'FrmVehicleTmp.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        ''FrmVehicleTmp.DefaultWhere = " WHERE MaPhuongTien=N''"
        FrmVehicleTmp.ShowDialog(Me)
    End Sub

    Private Sub TSB_SYNLMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_SYNLMS.Click        
        Dim p_Index As Integer
        Dim cl_SOAP_API As New SOAP_API.CL_SOAP_API
        Dim Name_nd, Product_nd As String
        Dim p_Dens As Double
        Dim p_DateTime As DateTime

        p_GetCurrentDate(p_DateTime)
        For p_Index = 0 To Me.GridView2.RowCount - 1
            Name_nd = Me.GridView2.GetFocusedRowCellValue("Name_nd")
            Product_nd = Me.GridView2.GetFocusedRowCellValue("Product_nd")
            p_Dens = cl_SOAP_API.GetDensity(Name_nd, Product_nd)

            If Name_nd Is Nothing Or Product_nd Is Nothing Then
                Continue For
            End If

            Me.GridView2.SetFocusedRowCellValue("Dens_nd", p_Dens)
            Me.GridView2.SetFocusedRowCellValue("FromDate", p_DateTime)
            Me.GridView2.MoveNext()
        Next

        Save()
        ShowStatusMessage(False, "", "Đồng bộ LMS hoàn thành", 10)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_SQL, p_TimeOut, p_ConnectSapString, p_Date As String
        Dim p_Table As DataTable
        Dim p_TableReturn As DataTable
        Dim p_Desc, p_Name_nd, p_Product_nd As String
        Dim p_Dens As String
        Dim p_Int As Integer
        Dim p_Rowid As Integer
        Dim p_WareHouse As String = ""
        p_SQL = "select *, convert(varchar(20),getdate(),112) as sysdate from tblConfig "
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_ConnectSapString = p_Table.Rows(0).Item("SapConnectionString").ToString.Trim
                p_Date = p_Table.Rows(0).Item("sysdate").ToString.Trim
                p_WareHouse = p_Table.Rows(0).Item("WareHouse").ToString.Trim
                Try
                    p_TimeOut = p_Table.Rows(0).Item("Timeout").ToString.Trim
                Catch ex As Exception
                End Try

                If p_TimeOut = "" Then
                    p_TimeOut = "60"
                End If
            End If
        End If

        'p_Date = "20251023"

        p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
        If p_ECCDestinationConfig.clsGetDensity(p_Date, p_TableReturn, p_Desc, p_WareHouse) = False Then
            ShowMessageBox("", p_Desc)
            Exit Sub
        End If

        If Not p_TableReturn Is Nothing Then
            If p_TableReturn.Rows.Count > 0 Then


                If MessageBox.Show("Bạn có chắc chắn muốn đồng bộ không?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then


                    For p_Int = 0 To p_TableReturn.Rows.Count - 1
                        For p_Index = Me.GridView2.RowCount - 1 To 0 Step -1
                            p_Name_nd = Me.GridView2.GetFocusedRowCellValue("Name_nd")
                            p_Product_nd = Me.GridView2.GetFocusedRowCellValue("Product_nd")



                            If Name_nd Is Nothing Or Product_nd Is Nothing Then
                                Me.GridView2.MoveNext()
                                Continue For
                            End If

                            If p_TableReturn.Rows(p_Int).Item("TANKCODE").ToString <> p_Name_nd Or p_TableReturn.Rows(p_Int).Item("MAHANGHOA").ToString <> p_Product_nd Then
                                Me.GridView2.MoveNext()
                                Continue For
                            End If
                            p_Dens = p_TableReturn.Rows(p_Int).Item("Density").ToString

                            Me.GridView2.SetFocusedRowCellValue("Dens_nd", p_Dens)
                            'Me.GridView2.SetFocusedRowCellValue("FromDate", p_DateTime)
                            Me.GridView2.MoveNext()
                        Next
                    Next
                    Me.GridView2.MoveFirst()
                    ShowStatusMessage(False, "Đã thực hiện xong, bạn cần lưu thông tin")
                    Exit Sub
                End If
            Else
                ShowStatusMessage(True, "Không có dữ liệu đồng bộ")
                Exit Sub
            End If
        End If


        ShowStatusMessage(True, "Không có dữ liệu đồng bộ")

    End Sub
End Class