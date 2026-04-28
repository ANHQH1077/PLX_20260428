Public Class FrmMeterE5
    Dim p_DataTable As DataTable
    Dim p_ConnectScadar As String = ""
    Dim p_ConVert_Date As String
    Dim p_TblConfig As DataTable
    Sub save()
        Dim p_Count As Integer
        Dim p_From As Decimal = 0.0
        Dim p_To As Decimal = 0.0
        Dim p_SQL As String
        Dim p_Row As DataRow
        Dim p_ArrRow() As DataRow
        Dim p_DataTableExeE5 As System.Data.DataTable
        Dim p_Desc As String

        Dim p_abc As Decimal
        Dim p_Rate As Double = 0
        'If Asc(e.KeyChar) = 19 Then
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                For p_Count = Me.GridView1.RowCount - 1 To 0 Step -1
                    p_Row = Me.GridView1.GetDataRow(p_Count)
                    If p_Row Is Nothing Then
                        Continue For
                    End If
                    p_Rate = IIf(p_Row.Item("ERate").ToString.Trim = "", 0, p_Row.Item("ERate"))
                    p_From = 0
                    p_To = 0
                    If Not p_Row Is Nothing Then
                        p_ArrRow = p_DataTable.Select("MaHangHoa='" & p_Row.Item("ProductCode").ToString.Trim & "'")
                        If p_ArrRow.Length > 0 Then
                            p_From = IIf(p_ArrRow(0).Item("ERate_Start").ToString.Trim = "", 0, p_ArrRow(0).Item("ERate_Start"))
                            p_To = IIf(p_ArrRow(0).Item("ERate_End").ToString.Trim = "", 0, p_ArrRow(0).Item("ERate_End"))
                        Else
                            Continue For
                        End If
                        'If p_Row.Item("ERate_Start").ToString.Trim <> "" Then
                        '    p_From = CDbl(p_Row.Item("ERate_Start").ToString.Trim)
                        'End If
                        'If p_Row.Item("ERate_End").ToString.Trim <> "" Then
                        '    p_To = CDbl(p_Row.Item("ERate_End").ToString.Trim)
                        'End If
                    End If
                    If p_Rate >= p_From And p_Rate <= p_To Then
                        Continue For
                    Else
                        ShowMessageBox("", "Tỷ lệ pha chế phải trong khoảng " & p_From & " đến " & p_To)
                        Exit Sub
                    End If
                Next

            End If
        End If

        'If p_ConnectScadar <> "" Then
        If TankUpdateToE5(p_DataTableExeE5, p_Desc) = False Then
            ShowMessageBox("", p_Desc)
            Exit Sub
        End If


        If Not p_DataTableExeE5 Is Nothing Then
            If p_DataTableExeE5.Rows.Count > 0 Then

                If Not p_TblConfig Is Nothing Then
                    If p_TblConfig.Rows.Count > 0 Then

                        For p_Count = 0 To p_TblConfig.Rows.Count - 1
                            If g_Filter_Terminal = True Then
                                If Mid(p_TblConfig.Rows(p_Count).Item("Client").ToString.Trim, 1, 1) = g_Terminal Then
                                    p_ConnectScadar = "Provider=SQLOLEDB;Server=" & p_TblConfig.Rows(p_Count).Item("ServerScada").ToString.Trim & _
                                       ";Database=" & p_TblConfig.Rows(p_Count).Item("DatabaseScada").ToString.Trim & _
                                       ";User ID=" & p_TblConfig.Rows(p_Count).Item("UidScada").ToString.Trim & _
                                       ";Password=" & p_TblConfig.Rows(p_Count).Item("PwdScada").ToString.Trim & _
                                       ";Trusted_Connection=False"
                                    'If Not p_DataTableExeE5 Is Nothing Then
                                    '    If p_DataTableExeE5.Rows.Count > 0 Then
                                    If g_Services.Execute_DataTbl_With_Connection(p_ConnectScadar, p_DataTableExeE5, _
                                                                   p_Desc) = False Then
                                        ShowStatusMessage(True, "", "Lỗi khi cập nhật Tỷ trọng xăng nền và Ethanol xuống Tự động hóa", 10)
                                        ShowMessageBox("", p_Desc)
                                        Exit Sub
                                    End If
                                End If
                            Else
                                p_ConnectScadar = "Provider=SQLOLEDB;Server=" & p_TblConfig.Rows(p_Count).Item("ServerScada").ToString.Trim & _
                                        ";Database=" & p_TblConfig.Rows(p_Count).Item("DatabaseScada").ToString.Trim & _
                                        ";User ID=" & p_TblConfig.Rows(p_Count).Item("UidScada").ToString.Trim & _
                                        ";Password=" & p_TblConfig.Rows(p_Count).Item("PwdScada").ToString.Trim & _
                                        ";Trusted_Connection=False"
                                'If Not p_DataTableExeE5 Is Nothing Then
                                '    If p_DataTableExeE5.Rows.Count > 0 Then
                                If g_Services.Execute_DataTbl_With_Connection(p_ConnectScadar, p_DataTableExeE5, _
                                                               p_Desc) = False Then
                                    ShowStatusMessage(True, "", "Lỗi khi cập nhật Tỷ trọng xăng nền và Ethanol xuống Tự động hóa", 10)
                                    ShowMessageBox("", p_Desc)
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

        'If Not p_DataTableExeE5 Is Nothing Then
        '    If p_DataTableExeE5.Rows.Count > 0 Then
        '        If g_Services.Execute_DataTbl_With_Connection(p_ConnectScadar, p_DataTableExeE5, _
        '                                       p_Desc) = False Then
        '            ShowStatusMessage(True, "", "Lỗi khi cập nhật Tỷ trọng xăng nền và Ethanol xuống Tự động hóa", 10)
        '            ShowMessageBox("", p_Desc)
        '            Exit Sub
        '        End If
        '    End If
        'End If
        ' End If


        Me.DefaultSave = True
        Me.UpdateToDatabase(Me, "")
        Me.DefaultSave = False
        'End If
    End Sub

    'FES
    '20141104
    'Day sang bang Ty_TrongE5 cua TDH khi thay doi gia tri be xuat
#Region "Day sang bang Ty_TrongE5 cua TDH khi thay doi gia tri be xuat"
    Private Function TankUpdateToE5(ByRef p_DataTableExeE5 As System.Data.DataTable, ByRef p_Desc As String) As Boolean
        Dim p_DataTableSub As DataTable
        Dim p_DataTableSource As DataTable
        Dim p_BindingSource As U_TextBox.U_BindingSource

        Dim p_Count As Integer = 0
        Dim p_CountRow As Integer = 0
        Dim p_SQL As String = ""
        'Dim p_SQLConnectionString As String = ""
        Dim p_Row() As DataRow
        Dim p_RowAdd As DataRow
        'p_SQLConnectionString
        Dim p_Error As String = ""
        Dim p_TankID As String
        Dim p_Hong As String
        Dim p_Tytrong_Nen As Double
        Dim p_TyTrong_E As Double
        Dim p_TyLe As Double



        Dim p_DataRow As DataRow

        Try
            TankUpdateToE5 = True
            If p_DataTableExeE5 Is Nothing Then
                p_DataTableExeE5 = New DataTable("abc")
            End If
            If p_DataTableExeE5.Columns.Count <= 0 Then
                p_DataTableExeE5.Columns.Add("STR_SQL")
            End If
            Me.TrueDBGrid1.Update()
            p_BindingSource = Me.TrueDBGrid1.DataSource
            p_DataTableSource = CType(p_BindingSource.DataSource, DataTable)
            ' p_Row = p_DataTableSource.Select("trim(CHECKUPD)='Y'")
            For p_CountRow = 0 To p_DataTableSource.Rows.Count - 1
                p_DataRow = p_DataTableSource.Rows(p_CountRow)
                If p_DataRow.RowState = DataRowState.Deleted Then
                    Continue For
                End If
                If p_DataTableSource.Rows(p_CountRow).Item("CHECKUPD").ToString.Trim = "" Or p_DataTableSource.Rows(p_CountRow).Item("CHECKUPD").ToString.Trim = "N" Then
                    Continue For
                End If
                'p_SQL = "Select * from tblMap_cp where (TableName='Lenh_GH' or TableName='LENH_GH') and Client like '%E5%'"
                'p_DataTable = GetDataTable(p_SQL, p_SQL)


                'If p_DataTable Is Nothing Then Exit Sub
                'If p_DataTable.Rows.Count <= 0 Then Exit Sub
                'p_SQLConnectionString = p_DataTable.Rows(0).Item("SqlScadaConnectionString").ToString.Trim

                'p_c2sql = New Connect2SQL.Connect2SQL(_SQLConnectionString)
                p_TankID = p_DataTableSource.Rows(p_CountRow).Item("TankE5").ToString.Trim
                p_Hong = p_DataTableSource.Rows(p_CountRow).Item("MeterID").ToString.Trim
                p_SQL = "exec FPT_GetTankActiveUpdateToE5New '" & p_TankID & "', '" & p_Hong & _
                            "', '" & p_DataTableSource.Rows(p_CountRow).Item("TankID").ToString.Trim & "'" & _
                            ", '" & p_DataTableSource.Rows(p_CountRow).Item("TankProduct").ToString.Trim & "'" & _
                            ", '" & p_DataTableSource.Rows(p_CountRow).Item("TankE").ToString.Trim & "'" & _
                            ", '" & p_DataTableSource.Rows(p_CountRow).Item("TankEProduct").ToString.Trim & "'"
                p_DataTableSub = GetDataTable(p_SQL, p_Desc)
                If Not p_DataTableSub Is Nothing Then
                    If p_DataTableSub.Rows.Count > 0 Then
                        With p_DataTableSub
                            'For p_Count = 0 To p_DataTable.Rows.Count - 1

                            p_Tytrong_Nen = p_DataTableSub.Rows(0).Item("TyTrongNen").ToString.Trim
                            p_TyTrong_E = p_DataTableSub.Rows(0).Item("TyTrongE").ToString.Trim
                            p_Tyle = p_DataTableSource.Rows(p_CountRow).Item("ERate").ToString.Trim

                            If p_TyLe = 0 Or p_TyTrong_E = 0 Or p_Tytrong_Nen = 0 Then
                                ShowMessageBox("", "Thông tin Tỷ lệ phối trộn hoặc Tỷ trọng Nền hoặc Tỷ trọng Ethanol không xác định")
                                Continue For
                            End If

                            p_SQL = "INSERT INTO [TYTRONGE5]  ([Ma_hong] ,[Tyle],[Tytrong_Base],[Tytrong_E], Ma_Hhoa, Be_Base, Be_E)  "
                            p_SQL = p_SQL & " VALUES(" & _
                                                    p_DataTableSource.Rows(p_CountRow).Item("ArmNo").ToString.Trim & _
                                                    "," & p_DataTableSource.Rows(p_CountRow).Item("ERate").ToString.Trim & _
                                                    "," & p_DataTableSub.Rows(0).Item("TyTrongNen").ToString.Trim & _
                                                    "," & p_DataTableSub.Rows(0).Item("TyTrongE").ToString.Trim & _
                                                    ",'" & getHangHoaE5(p_DataTableSource.Rows(p_CountRow).Item("ProductCode").ToString.Trim) & "'" & _
                                                    ",'" & p_DataTableSource.Rows(p_CountRow).Item("TankID").ToString.Trim & "'" & _
                                                    ",'" & p_DataTableSource.Rows(p_CountRow).Item("TankE").ToString.Trim & "'" & _
                                                    ")"

                            p_RowAdd = p_DataTableExeE5.NewRow
                            p_RowAdd.Item(0) = p_SQL
                            p_DataTableExeE5.Rows.Add(p_RowAdd)
                            'Next
                        End With
                    End If
                End If
            Next
            'exec GetTankActiveUpdateToE5 @p_TankE5, @p_Date
        Catch ex As Exception
            p_Desc = ex.Message
            TankUpdateToE5 = False
        End Try
    End Function
#End Region

    Private Sub FrmMeterE5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            save()
        End If

    End Sub

    Private Sub FrmMeterE5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        Dim p_DataSet As DataSet
        Dim p_Col1_92 As New U_TextBox.GridColumn
        Dim p_Col1_E As New U_TextBox.GridColumn
        Dim p_Meter As String = ""
        ' Dim p_WhereCol As String = ""
        p_XtraUserName = g_User_ID
        p_SQL = "SELECT * from tblHangHoaE5;Select * from tblMap_cp where  Client like '%E5%' and status='out';"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            p_DataTable = p_DataSet.Tables(0)
            p_TblConfig = p_DataSet.Tables(1)
        End If

        'p_Col1_E = New U_TextBox.GridColumn
        'p_Col1_E = Me.GridView1.Columns.Item("TankE5")
        'p_Col1_E.SQLString = p_SQL




        '' p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

        'p_SQL = "SELECT  Name_nd  as TankID ,[Product_nd] as TankProduct,[TenHangHoa]  FROM [FPT_tblTankActive_V]  where Date1 =CONVERT(date,getdate()) and  Product_nd='0201001' " ' & _
        ''" and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "

        ''p_SQL = "SELECT  Name_nd  as TankID ,[Product_nd] as TankProduct,[TenHangHoa]  FROM [FPT_tblTank_V] where Product_nd='0201001' " & _
        ''        " and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "
        'p_Col1_92 = Me.GridView1.Columns.Item("TankID")
        'p_Col1_92.SQLString = p_SQL
        ''Me.GridView1.Where = "( left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  or  Product_nd in (select MahangHoa from tblHangHoaE5 )  )"


        'p_SQL = "SELECT  Name_nd  as TankID ,[Product_nd] as TankProduct,[TenHangHoa]  FROM [FPT_tblTankActive_V]  where Date1 =CONVERT(date,getdate()) and Product_nd like '0301%'	 "
        ''" and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "


        ''p_SQL = "SELECT  Name_nd  as TankE ,[Product_nd] as TankEProduct,[TenHangHoa]  FROM [FPT_tblTank_V] where Product_nd like '0301%'	 " & _
        ''        " and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "
        'p_Col1_E = Me.GridView1.Columns.Item("TankE")
        'p_Col1_E.SQLString = p_SQL



        'p_SQL = "SELECT  Name_nd  as TankID ,[Product_nd] as TankProduct,[TenHangHoa]  FROM [FPT_tblTankActive_V] a  where Date1 =CONVERT(date,getdate()) and  exists (select 1 from tblHangHoaE5  b where a.Product_nd=b.MaHangHoa)  "
        ''" and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "


        ''p_SQL = "SELECT  Name_nd  as TankE5 ,[Product_nd] as ProductCode,[TenHangHoa]  FROM [FPT_tblTank_V] a where  exists (select 1 from tblHangHoaE5  b where a.Product_nd=b.MaHangHoa) " & _
        ''        " and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "
       

        If g_Filter_Terminal = True Then
            If g_Terminal <> "" Then
                Me.GridView1.Where = "left(MeterId,LEN ('" & p_Meter & "'))  ='00999'"
                Me.DefaultFormLoad = True

                Me.XtraForm1_Load()
                Me.DefaultFormLoad = False


                p_SQL = "SELECT  Name_nd  as TankID ,[Product_nd] as TankProduct,[TenHangHoa]  FROM [FPT_tblTankActive_V]  where Date1 =CONVERT(date,getdate()) and  Product_nd like '0201%' " & _
                        " and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "

                'p_SQL = "SELECT  Name_nd  as TankID ,[Product_nd] as TankProduct,[TenHangHoa]  FROM [FPT_tblTank_V] where Product_nd='0201001' " & _
                '        " and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "
                p_Col1_92 = Me.GridView1.Columns.Item("TankID")
                p_Col1_92.SQLString = p_SQL
                'Me.GridView1.Where = "( left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  or  Product_nd in (select MahangHoa from tblHangHoaE5 )  )"


                p_SQL = "SELECT  Name_nd  as TankE ,[Product_nd] as TankEProduct,[TenHangHoa]  FROM [FPT_tblTankActive_V]  where Date1 =CONVERT(date,getdate()) and Product_nd like '0301%'	 " & _
                        " and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "


                'p_SQL = "SELECT  Name_nd  as TankE ,[Product_nd] as TankEProduct,[TenHangHoa]  FROM [FPT_tblTank_V] where Product_nd like '0301%'	 " & _
                '        " and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "
                p_Col1_E = Me.GridView1.Columns.Item("TankE")
                p_Col1_E.SQLString = p_SQL



                p_SQL = "SELECT  Name_nd  as TankE5 ,[Product_nd] as ProductCode,[TenHangHoa]  FROM [FPT_tblTankActive_V] a  where Date1 =CONVERT(date,getdate()) and  exists (select 1 from tblHangHoaE5  b where a.Product_nd=b.MaHangHoa)  " & _
                       " and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "


                'p_SQL = "SELECT  Name_nd  as TankE5 ,[Product_nd] as ProductCode,[TenHangHoa]  FROM [FPT_tblTank_V] a where  exists (select 1 from tblHangHoaE5  b where a.Product_nd=b.MaHangHoa) " & _
                '        " and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "
                p_Col1_E = New U_TextBox.GridColumn
                p_Col1_E = Me.GridView1.Columns.Item("TankE5")
                p_Col1_E.SQLString = p_SQL

                Select Case g_Terminal
                    Case "A"
                        p_Meter = "C1"
                    Case "B"
                        p_Meter = "C2"
                    Case Else
                        p_Meter = "C3"
                End Select
                'p_WhereCol = "left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'"
                'p_SQL = p_SQL & " and " & p_WhereCol

                Me.GridView1.Where = "left(MeterId,LEN ('" & p_Meter & "')) like '" & p_Meter & "%'"

            End If
            Me.DefaultFormLoad = True

            Me.XtraForm1_Load()
            Me.DefaultFormLoad = False
        Else
            'Me.GridView1.Where = "left(MeterId,LEN ('" & p_Meter & "'))  ='00999'"
            Me.DefaultFormLoad = True

            Me.XtraForm1_Load()
            Me.DefaultFormLoad = False

            p_SQL = "SELECT  Name_nd  as TankID ,[Product_nd] as TankProduct,[TenHangHoa]  FROM [FPT_tblTankActive_V]  where Date1 =CONVERT(date,getdate()) and  Product_nd like '0201%' " & _
                   " "

            'p_SQL = "SELECT  Name_nd  as TankID ,[Product_nd] as TankProduct,[TenHangHoa]  FROM [FPT_tblTank_V] where Product_nd='0201001' " & _
            '        " and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "
            p_Col1_92 = Me.GridView1.Columns.Item("TankID")
            p_Col1_92.SQLString = p_SQL
            'Me.GridView1.Where = "( left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  or  Product_nd in (select MahangHoa from tblHangHoaE5 )  )"


            p_SQL = "SELECT  Name_nd  as TankE ,[Product_nd] as TankEProduct,[TenHangHoa]  FROM [FPT_tblTankActive_V]  where Date1 =CONVERT(date,getdate()) and Product_nd like '0301%'	 " & _
                    " "


            'p_SQL = "SELECT  Name_nd  as TankE ,[Product_nd] as TankEProduct,[TenHangHoa]  FROM [FPT_tblTank_V] where Product_nd like '0301%'	 " & _
            '        " and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "
            p_Col1_E = Me.GridView1.Columns.Item("TankE")
            p_Col1_E.SQLString = p_SQL



            p_SQL = "SELECT  Name_nd  as TankE5 ,[Product_nd] as ProductCode,[TenHangHoa]  FROM [FPT_tblTankActive_V] a  where Date1 =CONVERT(date,getdate()) and  exists (select 1 from tblHangHoaE5  b where a.Product_nd=b.MaHangHoa)  " & _
                   " "


            'p_SQL = "SELECT  Name_nd  as TankE5 ,[Product_nd] as ProductCode,[TenHangHoa]  FROM [FPT_tblTank_V] a where  exists (select 1 from tblHangHoaE5  b where a.Product_nd=b.MaHangHoa) " & _
            '        " and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'  "
            p_Col1_E = New U_TextBox.GridColumn
            p_Col1_E = Me.GridView1.Columns.Item("TankE5")
            p_Col1_E.SQLString = p_SQL
        End If


        'If Not p_TblConfig Is Nothing Then
        '    If p_TblConfig.Rows.Count > 0 Then
        '        p_ConnectScadar = "Provider=SQLOLEDB;Server=" & p_TblConfig.Rows(0).Item("ServerScada").ToString.Trim & _
        '                    ";Database=" & p_TblConfig.Rows(0).Item("DatabaseScada").ToString.Trim & _
        '                    ";User ID=" & p_TblConfig.Rows(0).Item("UidScada").ToString.Trim & _
        '                    ";Password=" & p_TblConfig.Rows(0).Item("PwdScada").ToString.Trim & _
        '                    ";Trusted_Connection=False"
        '    End If
        'End If

       

        Me.GridView1.BestFitColumns()

    End Sub

    Private Sub GridView1_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim p_DataRow As DataRow
        Dim p_HangHoa As String = ""
        Dim p_BeXuat As String = ""
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_String As String
        Dim p_Column As U_TextBox.GridColumn
        p_Column = Me.GridView1.FocusedColumn
        If UCase(p_Column.FieldView) = UCase("MeterID") Then
            ' If UCase(GridView1.FocusedColumn.FieldName.ToString.Trim) = UCase("Name_nd") Then
            If g_Filter_Terminal = True Then
                If g_Terminal <> "" Then
                    p_String = e.Value.ToString.Trim
                    If Len(p_String) > 0 Then
                        Select Case g_Terminal
                            Case "A"
                                If Mid(p_String, 1, 2) <> "C1" Then
                                    MsgBox("Giá trị mã kho không hợp lệ", MsgBoxStyle.Critical, "Thông báo")
                                    ' Me.GridView1.InvalidateRow(e.RowHandle)
                                    e.Valid = False
                                End If
                            Case "B"
                                If Mid(p_String, 1, 2) <> "C2" Then
                                    MsgBox("Giá trị mã kho không hợp lệ", MsgBoxStyle.Critical, "Thông báo")
                                    ' Me.GridView1.InvalidateRow(e.RowHandle)
                                    e.Valid = False
                                End If
                            Case Else
                                If Mid(p_String, 1, 2) <> "C3" Then
                                    MsgBox("Giá trị mã kho không hợp lệ", MsgBoxStyle.Critical, "Thông báo")
                                    ' Me.GridView1.InvalidateRow(e.RowHandle)
                                    e.Valid = False
                                End If
                        End Select

                    End If
                End If
            End If
            ' If
        End If
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        save()
    End Sub


End Class