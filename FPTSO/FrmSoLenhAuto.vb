Public Class FrmSoLenhAuto
    Dim p_SapConnectionString As String = ""
    Dim p_WareHouse As String = ""
    Dim p_ShPoint As String = ""
    Dim p_TimeOut As String = "0"
    Private l_ztb As Connect2SapEx.Str_PhieuXuatTable
    Private p_TableKhachHang As DataTable

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_Err As String
        Dim p_DataTable As DataTable
        Dim i_date As String = ""
        Dim i_dateTo As String = ""
        Dim p_Date As Date
        Dim p_Count As Integer
        Dim p_Datarow As DataRow
        Dim p_Bidnding As New U_TextBox.U_BindingSource
        Dim p_DataGrid As New DataTable("Table")
        Dim p_RowArr() As DataRow
        Dim p_Resource_Nd, p_Customer, p_TenKhachHang As String
        Dim p_Row() As DataRow

        If p_SapConnectionString = "" Then
            ShowMessageBox("", "Kết nối lên SAP chưa khai báo")
            Exit Sub
        End If

        If Not Me.NgayXuat.EditValue Is Nothing Then
            If Me.NgayXuat.EditValue.ToString.Trim <> "" Then
                p_Date = CDate(Me.NgayXuat.EditValue)
                i_date = p_Date.ToString("yyyy.MM.dd")
            End If
        End If
        p_Resource_Nd = ""
        p_Customer = ""

        If Not Me.MaKhachHang.EditValue Is Nothing Then
            p_Customer = Me.MaKhachHang.EditValue.ToString.Trim
        End If
        If Not Me.MaNguon.EditValue Is Nothing Then
            p_Resource_Nd = Me.MaNguon.EditValue.ToString.Trim
        End If

        If Not Me.NgayXuatTo.EditValue Is Nothing Then
            If Me.NgayXuatTo.EditValue.ToString.Trim <> "" Then
                p_Date = CDate(Me.NgayXuatTo.EditValue)
                i_dateTo = p_Date.ToString("yyyy.MM.dd")
            End If
        End If


        If i_date = "" Then
            ShowMessageBox("", "Ngày tháng chưa được nhập")
            Exit Sub
        End If

        If i_dateTo = "" Then
            i_dateTo = i_date
        End If

        Cursor = Cursors.WaitCursor

        If g_WCF = False Then

            p_Err = ""
            ' ThongTinLenhXuat_Services(p_Err)

            l_ztb = New Connect2SapEx.Str_PhieuXuatTable

            Dim p_SAP_Object As New THN_SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

            If p_SAP_Object.clsSyncDeliveries_DoListAuto(l_ztb, p_SapConnectionString, i_date, i_dateTo, _
                                              p_ShPoint, p_TimeOut, p_DataTable, _
                                              p_Err) = False Then
                'If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then

                If GridView1.RowCount > 0 Then
                    For p_Count = GridView1.RowCount - 1 To 0 Step -1
                        GridView1.DeleteRow(p_Count)
                    Next

                    ' GridView1.SelectRange(0, GridView1.RowCount - 1)
                    ' GridView1.DeleteSelectedRows()
                End If
                If p_Err <> "" Then
                    ShowMessageBox("", p_Err)

                End If


                GoTo Line_KT


            End If

        End If
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                p_Bidnding = Me.TrueDBGrid1.DataSource
                If p_Bidnding Is Nothing Then
                    p_Bidnding = New U_TextBox.U_BindingSource
                    If p_DataGrid.Columns.Count = 0 Then
                        p_DataGrid.Columns.Add("X")
                        p_DataGrid.Columns.Add("SoLenh")
                        p_DataGrid.Columns.Add("NgayThang", GetType(DateTime))
                        p_DataGrid.Columns.Add("sStatus")


                        p_DataGrid.Columns.Add("MaNguon")
                        p_DataGrid.Columns.Add("MaKhachHang")
                        p_DataGrid.Columns.Add("TenKhachHang")
                        p_DataGrid.Columns.Add("MaPhuongTien")
                        p_DataGrid.Columns.Add("sDesc")
                    End If
                Else
                    p_DataGrid = CType(p_Bidnding.DataSource, DataTable)
                End If

                p_DataGrid.Clear()
                For p_Count = 0 To p_DataTable.Rows.Count - 1

                    If Check_SoLenh(p_Err, p_DataTable.Rows(p_Count).Item("Order_No").ToString.Trim) = False Then
                        p_Row = p_DataGrid.Select("SoLenh='" & p_DataTable.Rows(p_Count).Item("Order_No").ToString.Trim & "'")
                        If p_Row.Length <= 0 Then
                            If p_Customer <> "" Then
                                If p_Customer <> p_DataTable.Rows(p_Count).Item("Customer").ToString.Trim Then
                                    Continue For
                                End If
                            End If

                            If p_Resource_Nd <> "" Then
                                If p_Resource_Nd <> p_DataTable.Rows(p_Count).Item("Resource_Nd").ToString.Trim Then
                                    Continue For
                                End If
                            End If


                            p_Datarow = p_DataGrid.NewRow
                            p_Datarow.Item("X") = "Y"
                            p_Datarow.Item("SoLenh") = p_DataTable.Rows(p_Count).Item("Order_No").ToString.Trim
                            p_Datarow.Item("MaPhuongTien") = p_DataTable.Rows(p_Count).Item("Vehicle").ToString.Trim
                            p_Datarow.Item("MaNguon") = p_DataTable.Rows(p_Count).Item("Resource_Nd").ToString.Trim
                            p_Datarow.Item("MaKhachHang") = p_DataTable.Rows(p_Count).Item("Customer").ToString.Trim

                            p_RowArr = p_TableKhachHang.Select("MaKhachHang ='" & p_DataTable.Rows(p_Count).Item("Customer").ToString.Trim & "'")
                            If p_RowArr.Length > 0 Then
                                p_Datarow.Item("TenKhachHang") = p_RowArr(0).Item("TenKhachHang").ToString.Trim
                            End If

                            If p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim <> "" Then
                                'i_date = Mid(p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim, 5, 2)
                                'i_date = i_date & "/" & Strings.Right(p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim, 2)
                                'i_date = i_date & "/" & Strings.Left(p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim, 4)
                                i_date = p_DataTable.Rows(p_Count).Item("Date_ND").ToString.Trim
                                Try
                                    p_Datarow.Item("NgayThang") = CDate(i_date).ToString("MM/dd/yyyy")
                                Catch ex As Exception

                                End Try

                            End If
                            ' p_Datarow.Item("NgayThang") = p_DataTable.Rows(p_Count).Item("Order_No").ToString.Trim
                            p_Datarow.Item("sStatus") = "N"
                            p_DataGrid.Rows.Add(p_Datarow)
                        End If

                    End If

                Next
                p_Bidnding.DataSource = p_DataGrid
                Me.TrueDBGrid1.DataSource = p_Bidnding
                For p_Count = 0 To p_DataGrid.Columns.Count - 1
                    Me.GridView1.Columns(p_Count).FieldName = p_DataGrid.Columns(p_Count).ColumnName
                Next
                'Me.GridView1.Columns("NgayThang").Visible = True
                'Me.GridView1.Columns("NgayThang").VisibleIndex = 2
                Me.GridView1.Columns("NgayThang").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                Me.GridView1.Columns("NgayThang").DisplayFormat.FormatString = "dd/MM/yyyy"

                Me.TrueDBGrid1.RefreshDataSource()
            End If
        End If
Line_KT:
        ' Me.GridView1.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FrmSoLenhAuto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim p_TableConfig1 As DataTable
        Dim p_SQL As String
        Dim p_Date As Date
        Dim p_Time As Integer

        p_GetDateTime(p_Date, p_Time)

        Try

            p_SQL = "select * from tblKhachHang "
            p_TableKhachHang = GetDataTable(p_SQL, p_SQL)


            p_SQL = "select * from tblConfig;"
            p_TableConfig1 = GetDataTable(p_SQL, p_SQL)

            If Not p_TableConfig1 Is Nothing Then
                If p_TableConfig1.Rows.Count > 0 Then
                    p_SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                    p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                    p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
                    p_TimeOut = p_TableConfig1.Rows(0).Item("timeout").ToString.Trim
                End If

            End If

            Me.NgayXuat.EditValue = p_Date
            Me.NgayXuatTo.EditValue = p_Date
        Catch ex As Exception
            ShowMessageBox("", ex.Message)
        End Try

    End Sub



    'Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
    '    Dim p_DataTable As DataTable
    '    Dim p_DataAuto As DataTable
    '    Dim p_Data_l_ztb As DataTable
    '    Dim p_Row As DataRow
    '    Dim p_RowArr() As DataRow

    '    Dim p_date As Date
    '    Dim p_Binding As New U_TextBox.U_BindingSource
    '    Dim p_ValueMess As Windows.Forms.DialogResult
    '    Dim p_Count As Integer
    '    Dim p_SQL As String
    '    Dim p_l_ztb As Connect2SAP.Str_PhieuXuatTable

    '    Dim p1_l_ztb As Connect2SAP.Str_PhieuXuat

    '    Dim p_Countint As Integer
    '    If Me.GridView1.FocusedRowHandle = 0 Then
    '        GridView1.MoveNext()
    '        'GridView1.MoveFirst()
    '    End If
    '    Dim p_Error As String
    '    Dim p_ErrorCheck As Boolean

    '    Dim p_SoLenh As String
    '    Dim p_CountIn As Integer
    '    GridView1.MoveFirst()

    '    p_Binding = Me.TrueDBGrid1.DataSource
    '    If p_Binding Is Nothing Then
    '        Exit Sub
    '    End If
    '    p_DataTable = CType(p_Binding.DataSource, DataTable)
    '    If Not p_DataTable Is Nothing Then
    '        If p_DataTable.Rows.Count > 0 Then
    '            'p_RowArr = p_DataTable.Select("X='Y'")
    '            'If p_RowArr.Length = 0 Then
    '            '    ShowMessageBox("", "Không có lệnh nào được chọn")
    '            '    Exit Sub
    '            'End If
    '            p_DataAuto = p_DataTable.Clone
    '            For p_Count = 0 To p_DataTable.Rows.Count - 1
    '                If p_DataTable.Rows(p_Count).Item("X").ToString.Trim = "Y" Then
    '                    p_Row = p_DataAuto.NewRow
    '                    p_Row.Item("SoLenh") = p_DataTable.Rows(p_Count).Item("SoLenh").ToString.Trim
    '                    p_DataAuto.Rows.Add(p_Row)
    '                End If
    '            Next

    '            If p_DataAuto.Rows.Count <= 0 Then
    '                ShowMessageBox("", "Không có lệnh nào được chọn")
    '                Exit Sub
    '            End If
    '            'Dim p_ValueMess As Windows.Forms.DialogResult
    '            p_ValueMess = g_Module.ShowMessage(Me, "", _
    '                            "Bạn có chắn chắn muốn thực hiện không?", _
    '                            True, _
    '                             "Có", _
    '                            True, _
    '                            "Không", _
    '                            False, _
    '                            "", _
    '                             0)
    '            If p_ValueMess = Windows.Forms.DialogResult.No Then
    '                Exit Sub
    '            End If

    '            If Not Me.NgayXuat.EditValue Is Nothing Then
    '                p_date = Me.NgayXuat.EditValue
    '            Else
    '                Exit Sub
    '            End If


    '            '   l_ztb.
    '            Cursor = Cursors.WaitCursor
    '            If g_WCF = False Then



    '                '  p_DataAuto = p_DataTable.Clone
    '                '  For p_Count = 0 To p_DataAuto.Rows.Count - 1

    '                ' p_SoLenh = p_DataAuto.Rows(p_Count).Item("SoLenh").ToString.Trim
    '                For p_CountIn = l_ztb.Count - 1 To 0 Step -1
    '                    ' p_RowArr=
    '                    p_SoLenh = l_ztb(p_CountIn).Outbound.ToString.Trim
    '                    p_RowArr = p_DataAuto.Select("SoLenh='" & p_SoLenh & "'")
    '                    If p_RowArr.Length <= 0 Then
    '                        'p_l_ztb = New Connect2SapEx.Str_PhieuXuatTable
    '                        '  p_l_ztb = l_ztb(p_CountIn)
    '                        l_ztb.Remove(l_ztb(p_CountIn))

    '                        '  l_ztb.
    '                    End If

    '                    ' Exit For
    '                Next
    '                ' Next

    '                p_Data_l_ztb = l_ztb.ToADODataTable

    '                Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

    '                ' For p_Countint = 0 To l_ztb.Count - 1

    '                'p_Error = ""
    '                p_ErrorCheck = True

    '                p_l_ztb = New Connect2SAP.Str_PhieuXuatTable
    '                p_l_ztb.FromADODataTable(p_Data_l_ztb)
    '                If p_SAP_Object.clsmdlSyncDeliveries_SynSpecificAuto(p_l_ztb, g_WareHouse, g_User_ID, _
    '                                                g_Company_Code, "", p_Error) = False Then

    '                    p_ErrorCheck = False
    '                End If

    '                'Next
    '                p_Binding.DataSource = p_DataTable
    '                Me.TrueDBGrid1.RefreshDataSource()
    '                Me.GridView1.BestFitColumns()
    '                Cursor = Cursors.Default
    '                ShowStatusMessage(False, "", "Đã thực hiện xong", 7)
    '                Exit Sub
    '            End If
    '            Cursor = Cursors.Default
    '        End If
    '    End If
    'End Sub



    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim p_DataTable As DataTable
        Dim p_DataAuto, p_TablePost As DataTable
        Dim p_Row As DataRow
        Dim p_RowArr() As DataRow
        Dim p_RowArrPOst() As DataRow
        Dim p_date As Date
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_Count As Integer
        Dim p_SQL As String
        If Me.GridView1.FocusedRowHandle = 0 Then
            GridView1.MoveNext()
            'GridView1.MoveFirst()
        End If
        Dim p_NgayXuat As Date
        Dim p_Done As Boolean = False
        Dim p_Client As String = ""

        If g_Filter_Terminal = False Then
            p_Client = g_Terminal
        End If

        GridView1.MoveFirst()
        'If Me.GridView1.FocusedRowHandle = Me.GridView1.RowCount - 1 Then
        '    GridView1.MoveFirst()
        'End If

        ' Me.GridView1.RefreshData()
        p_Binding = Me.TrueDBGrid1.DataSource
        If p_Binding Is Nothing Then
            Exit Sub
        End If

        p_Done = False
        p_DataTable = CType(p_Binding.DataSource, DataTable)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                'p_RowArr = p_DataTable.Select("X='Y'")
                'If p_RowArr.Length = 0 Then
                '    ShowMessageBox("", "Không có lệnh nào được chọn")
                '    Exit Sub
                'End If
                p_DataAuto = p_DataTable.Clone
                For p_Count = 0 To p_DataTable.Rows.Count - 1
                    If p_DataTable.Rows(p_Count).Item("X").ToString.Trim = "Y" Then
                        p_Row = p_DataAuto.NewRow
                        p_Row.Item("SoLenh") = p_DataTable.Rows(p_Count).Item("SoLenh").ToString.Trim
                        p_Row.Item("NgayThang") = p_DataTable.Rows(p_Count).Item("NgayThang")
                        p_DataAuto.Rows.Add(p_Row)
                    End If

                Next

                If p_DataAuto.Rows.Count <= 0 Then
                    ShowMessageBox("", "Không có lệnh nào được chọn")
                    Exit Sub
                End If
                ''Dim p_ValueMess As Windows.Forms.DialogResult
                'p_ValueMess = g_Module.ShowMessage(Me, "", _
                '                "Bạn có chắn chắn muốn thực hiện không?", _
                '                True, _
                '                 "Có", _
                '                True, _
                '                "Không", _
                '                False, _
                '                "", _
                '                 0)
                'If p_ValueMess = Windows.Forms.DialogResult.No Then
                '    Exit Sub
                'End If

                'If Not Me.NgayXuat.EditValue Is Nothing Then
                '    p_date = Me.NgayXuat.EditValue
                'Else
                '    Exit Sub
                'End If

                Dim p_formDate As New FrmSoLenhAutoDate
                p_formDate.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                p_formDate.g_XtraServicesObj = g_XtraServicesObj
                p_formDate.p_XtraToolTripLabel = g_ToolStripStatus
                p_formDate.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                p_formDate.p_XtraMessageStatusl = g_MessageStatus


                p_formDate.ShowDialog(Me)
                p_Done = p_formDate.g_Done
                p_date = p_formDate.g_NgayXuat

            End If

            If p_Done = False Then
                Exit Sub
            End If


            Cursor = Cursors.WaitCursor
            'If g_WCF = False Then

            Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

            If p_SAP_Object.clsLenhXuatAuto_HTTG(p_date, p_Client, g_User_ID, g_UserName, g_Company_Code, _
                                 p_DataAuto, p_SQL, True) = False Then

                Cursor = Cursors.Default
                ShowMessageBox("", p_SQL)
                Exit Sub
            Else
                For p_Count = 0 To p_DataTable.Rows.Count - 1
                    If p_DataTable.Rows(p_Count).Item("X").ToString.Trim = "Y" Then
                        p_RowArr = p_DataAuto.Select("SoLenh='" & p_DataTable.Rows(p_Count).Item("SoLenh").ToString.Trim & "'")
                        If p_RowArr.Length > 0 Then
                            p_DataTable.Rows(p_Count).Item("sStatus") = p_RowArr(0).Item("sStatus").ToString.Trim
                            p_DataTable.Rows(p_Count).Item("sDesc") = p_RowArr(0).Item("sDesc").ToString.Trim
                        End If
                    End If

                Next
                p_SQL = ""


                For p_Count = p_DataAuto.Rows.Count - 1 To 0 Step -1
                    If p_DataAuto.Rows(p_Count).Item("sStatus").ToString.Trim <> "Y" Then
                        p_DataAuto.Rows.RemoveAt(p_Count)
                    End If
                Next
                p_DataAuto.AcceptChanges()
                Post_LenhXuatAuto(p_DataAuto, p_SQL)

                p_Binding.DataSource = p_DataTable
                Me.TrueDBGrid1.RefreshDataSource()
                Me.GridView1.BestFitColumns()
                Cursor = Cursors.Default
                ShowStatusMessage(False, "", "Đã thực hiện xong", 7)
                Exit Sub
            End If
            'Else
            '    If g_Services.clsLenhXuatAuto_HTTG(p_date, p_Client, g_User_ID, g_UserName, g_Company_Code, _
            '                         p_DataAuto, p_SQL) = False Then
            '        Cursor = Cursors.Default
            '        ShowMessageBox("", p_SQL)
            '        Exit Sub
            '    Else
            '        For p_Count = 0 To p_DataTable.Rows.Count - 1
            '            If p_DataTable.Rows(p_Count).Item("X").ToString.Trim = "Y" Then
            '                p_RowArr = p_DataAuto.Select("SoLenh='" & p_DataTable.Rows(p_Count).Item("SoLenh").ToString.Trim & "'")
            '                If p_RowArr.Length > 0 Then
            '                    p_DataTable.Rows(p_Count).Item("sStatus") = p_RowArr(0).Item("sStatus").ToString.Trim
            '                    p_DataTable.Rows(p_Count).Item("sDesc") = p_RowArr(0).Item("sDesc").ToString.Trim
            '                End If
            '            End If

            '        Next

            '        p_Binding.DataSource = p_DataTable
            '        Me.TrueDBGrid1.RefreshDataSource()
            '        Me.GridView1.BestFitColumns()
            '        Cursor = Cursors.Default
            '        ShowStatusMessage(False, "", "Đã thực hiện xong", 7)
            '        Exit Sub
            '    End If
            'End If
            Cursor = Cursors.Default
        End If
        ' End If
    End Sub

    Private Function Check_SoLenh(ByRef err As String, ByVal i_SoLenh As String) As Boolean
        Dim p_DataTable As DataTable
        Dim p_Err As String
        Check_SoLenh = False
        'Return g_c2SQL.ExeNonQuery("sp_Check_SoLenhE5", err, New SqlParameter("@SoLenh", i_SoLenh))
        p_DataTable = GetDataTable("exec sp_Check_SoLenhE5 '" & i_SoLenh & "'", p_Err)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Check_SoLenh = True
            End If
        End If
    End Function


    Sub GetSoLenh(ByVal p_DataSoLenh As DataTable)
        Dim p_Count As Integer
        Dim p_DataRow As DataRow
        Dim p_ArrRow() As DataRow
        Dim p_Desc As String
        Dim p_SoLenh As String
        Dim p_SQL As String
        Dim p_Date As Date
        If p_DataSoLenh Is Nothing Then
            Exit Sub
        End If
        '   p_ArrRow = p_DataSoLenh.Select("X='Y'")
        If Not p_ArrRow Is Nothing Then
            Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            For p_Count = 0 To p_DataSoLenh.Rows.Count - 1
                p_DataRow = p_DataSoLenh.Rows(p_Count)
                If p_DataRow.Item("X").ToString.Trim <> "Y" Then
                    Continue For
                End If
                If p_DataRow.Item("SoLenh").ToString.Trim = "" Then
                    Continue For
                End If
                p_SoLenh = p_DataRow.Item("SoLenh").ToString.Trim
                p_Date = Me.NgayXuat.EditValue

                If g_WCF = False Then
                    If p_SAP_Object.clsSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_SoLenh, p_Desc, p_Date) = False Then
                        p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ( [SoLenh],[NgayThang],[sDesc] ,[Createby] ,[CreateDate]  ,[StatusCode])"
                        p_SQL = p_SQL & "('" & p_SoLenh & "'," & _
                            " convert(date,'" & CDate(p_Date).ToString(g_Format_Date) & "')," & _
                            "'" & p_Desc & "','" & g_UserName & "', getdate(),'E')"
                    Else
                        p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ( [SoLenh],[NgayThang],[Createby] ,[CreateDate])"
                        p_SQL = p_SQL & "('" & p_SoLenh & "'," & _
                            " convert(date,'" & CDate(p_Date).ToString(g_Format_Date) & "')," & _
                            "'" & g_UserName & "', getdate())"
                    End If
                    If g_Services.Sys_Execute(p_SQL, p_SQL) = True Then

                    End If
                Else
                    If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_SoLenh, p_Desc) = False Then
                        p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ( [SoLenh],[NgayThang],[sDesc] ,[Createby] ,[CreateDate]  ,[StatusCode])"
                        p_SQL = p_SQL & "('" & p_SoLenh & "'," & _
                            " convert(date,'" & CDate(p_Date).ToString(g_Format_Date) & "')," & _
                            "'" & p_Desc & "','" & g_UserName & "', getdate(),'E')"
                    Else
                        p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ( [SoLenh],[NgayThang],[Createby] ,[CreateDate])"
                        p_SQL = p_SQL & "('" & p_SoLenh & "'," & _
                            " convert(date,'" & CDate(p_Date).ToString(g_Format_Date) & "')," & _
                            "'" & g_UserName & "', getdate())"
                    End If
                    If g_Services.Sys_Execute(p_SQL, p_SQL) = True Then

                    End If
                End If
            Next
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim p_form As New FrmSoLenhAuto_Hist
        p_form.g_XtraServicesObj = Me.g_XtraServicesObj
        p_form.p_XtraModuleObj = Me.p_XtraModuleObj
        p_form.ShowDialog(Me)
    End Sub

    Private Sub U_CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_CheckBox1.CheckedChanged
        Dim p_Count As Integer
        Dim p_Value As String = "N"
        If Me.U_CheckBox1.Checked = True Then
            p_Value = "Y"
        End If
        If Me.GridView1.RowCount > 0 Then
            Me.GridView1.MoveLast()
            While Not Me.GridView1.IsFirstRow
                Me.GridView1.SetFocusedRowCellValue("X", p_Value)
                Me.GridView1.MovePrev()
            End While
            If Me.GridView1.IsFirstRow Then
                Me.GridView1.SetFocusedRowCellValue("X", p_Value)
            End If
        End If
    End Sub

    Private Sub U_ButtonCus2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus2.Click

        Dim p_THN_SAP_Object As New THN_SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

        p_THN_SAP_Object.ClsGET_HTTG_GET_LX_STAGING_AUTO()
    End Sub
End Class