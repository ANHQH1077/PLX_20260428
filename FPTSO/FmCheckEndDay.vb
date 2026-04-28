Imports System.Threading
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FmCheckEndDay

    Private p_Table As DataTable
    Private p_Table1 As DataTable
    Private p_Table2 As DataTable
    Private p_DataSet As DataSet

    Private Sub getdata()
        Dim p_SQL As String
        Cursor = Cursors.WaitCursor
        Dim p_Client As String = ""
        Dim p_Count As Integer = 0
        Try
            p_Count = Me.U_Combobox1.EditValue
        Catch ex As Exception

        End Try
        Try
            p_Client = Me.U_ComboboxClient.EditValue
        Catch ex As Exception

        End Try
      
        p_SQL = "exec    ThongTinLenhCuoiNgayNew '" & g_UserName & "','" & p_Client & "', " & p_Count
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_Table = p_DataSet.Tables(0)
                p_Table1 = p_DataSet.Tables(1)
                p_Table2 = p_DataSet.Tables(2)
            End If
        End If
        p_Count = 0
        If Not p_Table Is Nothing Then
            Me.TrueDBGrid1.DataSource = p_Table
            For p_Count = 0 To Me.GridView1.Columns.Count - 1
                GridView1.Columns.Item(p_Count).FieldName = GridView1.Columns.Item(p_Count).Name
            Next
        End If

        If Not p_Table1 Is Nothing Then
            'If p_Table1.Rows.Count > 0 Then

            'End If
            Me.U_Label1.Text = "Tổng số Phương tiện: " & p_Table1.Rows.Count
        End If
        If Not p_Table2 Is Nothing Then
            'If p_Table1.Rows.Count > 0 Then

            'End If
            Me.U_Label2.Text = "Tổng số Lệnh: " & p_Table2.Rows.Count
        End If
        Cursor = Cursors.Default
        Me.GridView1.ExpandAllGroups()
        'If Me.GridView1.Columns.Count > 0 Then
        '    Me.GridView1.Columns.Item(Me.GridView1.Columns.Count - 1).VisibleIndex = -1
        'End If
    End Sub
    Private Sub FmCheckEndDay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_ColNumber As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        Dim p_ColDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Dim p_Column As DevExpress.XtraGrid.Columns.GridColumn

        Dim p_SQL As String
        Dim p_Tbl As DataTable
        Dim p_TblClient As New DataTable("Table001")
        Dim p_ClientInt As Integer = 0
        Dim p_TblGet As DataTable
        Dim p_TableTmp As DataTable
        Dim p_Row As DataRow
        Dim p_String As String = """"
        Dim p_StrSplit() As String
        Dim p_RowArr() As DataRow
        Dim p_Count As Integer

        Me.Text = "Tích kê có lệnh xuất chưa xuất hàng/Xuất chưa xong"

        p_SQL = "select KeyValue from SYS_CONFIG where KeyCode='TIME_END'"
        p_TableTmp = GetDataTable(p_SQL, p_SQL)
        If Not p_TableTmp Is Nothing Then
            If p_TableTmp.Rows.Count > 0 Then
                Me.Text = Me.Text & " (" & p_TableTmp.Rows(0).Item(0).ToString.Trim & ")"
            End If
        End If
        p_SQL = "select 0 as Code, N'Hiệu lực trong ngày' as Name  Union all  select 1 as Code, N'Tất cả' as Name "
        p_Tbl = GetDataTable(p_SQL, p_SQL)
        Me.U_Combobox1.Properties.DataSource = p_Tbl
        Me.U_Combobox1.Properties.ValueMember = "Code"
        Me.U_Combobox1.Properties.DisplayMember = "Name"
        If p_Tbl.Rows.Count > 0 Then
            Me.U_Combobox1.EditValue = p_Tbl.Rows(0).Item(0)
        End If


        p_SQL = "select TerMinal from SYS_USER  where upper(User_Name) =upper('" & g_UserName & "') "
        p_TblGet = GetDataTable(p_SQL, p_SQL)
        If Not p_TblGet Is Nothing Then
            If p_TblGet.Rows.Count > 0 Then
                p_String = p_TblGet.Rows(0).Item(0).ToString.Trim
            End If
        End If
        p_TblClient.Columns.Add("Client")
        p_TblClient.Columns.Add("ClientName")

        p_Row = p_TblClient.NewRow
        p_Row.Item("ClientName") = "Tất cả"
        p_Row.Item("Client") = "ALL"
        p_TblClient.Rows.Add(p_Row)

        If p_String <> "" Then
            p_StrSplit = p_String.Split(",")
            For p_Count = 0 To p_StrSplit.Length - 1
                p_RowArr = p_TblClient.Select("Client='" & Trim(p_StrSplit(p_Count).ToString.Trim) & "'")
                If p_RowArr.Length <= 0 Then
                    p_Row = p_TblClient.NewRow
                    p_Row.Item("Client") = Trim(p_StrSplit(p_Count).ToString.Trim)
                    p_Row.Item("ClientName") = "Kho " & Trim(p_StrSplit(p_Count).ToString.Trim)
                    p_TblClient.Rows.Add(p_Row)
                End If
            Next
        End If
        ' If p_TblClient.Rows.Count >= 3 Then
       
        'End If

        Me.U_ComboboxClient.Properties.DataSource = p_TblClient
        Me.U_ComboboxClient.Properties.ValueMember = "Client"
        Me.U_ComboboxClient.Properties.DisplayMember = "ClientName"
        If p_TblClient.Rows.Count > 0 Then
            Me.U_ComboboxClient.EditValue = p_TblClient.Rows(0).Item(0)
        End If



        getdata()


        Me.ControlResize = True
        FindAllControls(Me)
        Me.WindowState = FormWindowState.Maximized


        p_Column = Me.GridView1.Columns.Item("NgayTichKe")
        p_ColDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy"
        p_ColDate.EditMask = "dd/MM/yyyy"

        p_Column.ColumnEdit = p_ColDate
        p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        p_Column.DisplayFormat.FormatString = "dd/MM/yyyy"
        'p_Column.

        ' GridView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GridView1.Columns("MaPhuongTien").Group()


        Dim p_Total As DevExpress.XtraGrid.GridColumnSummaryItem
        ' p_Total = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "U_Qutity", "{0}")
        '  Me.GridView1.Columns("U_Qutity").Summary.Add(p_Total)
        p_Total = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DungTich", "Tổng: {0:N0}")
        Me.GridView1.Columns("DungTich").Summary.Add(p_Total)


        p_Total = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoLuongDuXuat", "Tổng: {0:N0}")
        Me.GridView1.Columns("SoLuongDuXuat").Summary.Add(p_Total)
        Me.GridView1.ExpandAllGroups()

    End Sub

    Private Sub U_CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_CheckBox1.CheckedChanged
        Dim p_Count As Integer
        Dim p_Value As String = "N"
        If Me.U_CheckBox1.Checked = True Then
            p_Value = "Y"
        End If
        For p_Count = Me.GridView1.RowCount - 1 To 0 Step -1
            GridView1.SetRowCellValue(p_Count, "X", p_Value)
        Next
    End Sub

    'Private Sub GridView1_CustomDrawFooter(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GridView1.CustomDrawFooter
    '    Dim stringFormat As StringFormat = New StringFormat()
    '    stringFormat.Alignment = StringAlignment.Near
    '    stringFormat.LineAlignment = StringAlignment.Center
    '    Dim rect = e.Bounds
    '    rect.X += 10
    '     e.DefaultDraw()
    '    e.Cache.DrawString("Tổng số phương tiện: 0", e.Appearance.GetFont(), e.Appearance.GetForeBrush(e.Cache), rect, stringFormat)
    '    If Not p_Table1 Is Nothing Then
    '        If p_Table1.Rows.Count > 0 Then
    '            e.Cache.DrawString("Tổng số phương tiện: " & p_Table1.Rows.Count, e.Appearance.GetFont(), e.Appearance.GetForeBrush(e.Cache), rect, stringFormat)
    '        End If
    '    End If

    '    e.Handled = True
    'End Sub


    'Private Sub GridView1_CustomDrawHeader(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GridView1.CustomDrawhe
    '    Dim stringFormat As StringFormat = New StringFormat()
    '    stringFormat.Alignment = StringAlignment.Near
    '    stringFormat.LineAlignment = StringAlignment.Center
    '    Dim rect = e.Bounds
    '    rect.X += 10
    '    ' e.DefaultDraw()
    '    e.Cache.DrawString("Tổng số phương tiện: 0", e.Appearance.GetFont(), e.Appearance.GetForeBrush(e.Cache), rect, stringFormat)
    '    If Not p_Table1 Is Nothing Then
    '        If p_Table1.Rows.Count > 0 Then
    '            e.Cache.DrawString("Tổng số phương tiện: " & p_Table1.Rows.Count, e.Appearance.GetFont(), e.Appearance.GetForeBrush(e.Cache), rect, stringFormat)
    '        End If
    '    End If

    '    e.Handled = True
    'End Sub

    Private Sub HuyTichKeCuoiNgay()
        Dim p_SQL As String
        Dim p_SoLenh As String = ""
        Dim p_DataTable As DataTable
        Dim p_DataTableStatus As DataTable
        Dim p_DataTableHuyTK As DataTable
        Dim p_DataTableTK As DataTable
        Dim p_ValueMess As Windows.Forms.DialogResult
        '  Dim p_Desc As String = "Bạn có chắn chắn muốn thực hiện hủy tích kê?"
        '  Dim p_String As String = ""
        Dim p_DataSet As DataSet
        Dim p_Count As Integer
        Dim p_Error As Boolean = False
        Dim p_Message As String = ""
        '  Dim p_TableUser As DataTable
        Dim p_Row As DataRow
        Dim p_Check As Boolean = False
        Dim p_CountRow As Integer

        Dim p_DataTable22 As New DataTable("Table01")
        Dim p_Row22 As DataRow
        Dim p_RowArr() As DataRow
        Dim p_SMO_ID As Integer



        p_ValueMess = g_Module.ShowMessage(Me, "", _
                           "Bạn có chắn chắn muốn thực hiện hủy tích kê?", _
                           True, _
                            "Có", _
                           True, _
                           "Không", _
                           False, _
                           "", _
                            0)
        If p_ValueMess = Windows.Forms.DialogResult.No Or p_ValueMess = Windows.Forms.DialogResult.Cancel Then
            Cursor = Cursors.Default
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        p_DataTable22.Columns.Add("SoLenh")

        For p_CountRow = 0 To Me.GridView1.RowCount - 1

            p_Row = Me.GridView1.GetDataRow(p_CountRow)


            If p_Row Is Nothing Then
                Continue For
            End If

            If p_Row.Item("X").ToString.Trim <> "Y" Then
                Continue For
            End If
            p_SoLenh = ""
            Try
                p_SoLenh = p_Row.Item("SoLenh").ToString.ToString
            Catch ex As Exception

            End Try



            If p_SoLenh = "" Then

                Continue For

            End If

            p_RowArr = p_DataTable22.Select("SoLenh ='" & p_SoLenh & "'")

            If p_RowArr.Length > 0 Then
                Continue For
            End If

            p_Check = True


            p_SQL = "FPT_KiemTra_HuyTichKe '" & p_SoLenh & "','" & g_UserName & "'"
            p_DataSet = GetDataSet(p_SQL, p_SQL)
            If Not p_DataSet Is Nothing Then
                If p_DataSet.Tables.Count > 0 Then
                    p_DataTable = p_DataSet.Tables(0)
                    p_DataTableTK = p_DataSet.Tables(1)
                    p_DataTableStatus = p_DataSet.Tables(2)
                    p_DataTableHuyTK = p_DataSet.Tables(3)
                End If
            End If


            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    'p_Row.Item("GhiChu") = p_DataTable.Rows(0).Item("StrName").ToString.Trim

                    p_SQL = "Update tblLenhXuatE5 set GhiChu =N'" & p_DataTable.Rows(0).Item("StrName").ToString.Trim & "' where SoLenh ='" & p_SoLenh & "'"
                    If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                    End If


                    Continue For
                End If
            End If
            If Not p_DataTableStatus Is Nothing Then
                If p_DataTableStatus.Rows.Count > 0 Then
                    ' p_Row.Item("GhiChu") = "Tích kê đã có lệnh xuất được hoàn thiện"
                    p_SQL = "Update tblLenhXuatE5 set GhiChu =N'" & "Tích kê đã có lệnh xuất được hoàn thiện" & "' where SoLenh ='" & p_SoLenh & "'"
                    If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                    End If
                    Continue For
                End If
            End If

            If Not p_DataTableTK Is Nothing Then
                Dim p_int As Integer
                If p_DataTableTK.Rows.Count > 1 Then


                    For p_int = 0 To p_DataTableTK.Rows.Count - 1

                        p_Message = ""
                        p_Error = False
                        HuyTichKeKiemTra(p_Row.Item("Client").ToString.Trim, p_Row.Item("LoaiXuat").ToString.Trim, p_Error, p_Message, p_DataTableTK.Rows(p_int).Item("SoLenh").ToString.Trim)
                        If p_Error = True Then
                            p_SQL = "Update tblLenhXuatE5 set GhiChu =N'" & p_Message & "' where SoLenh ='" & p_DataTableTK.Rows(p_int).Item("SoLenh").ToString.Trim & "'"
                            If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                            End If
                            p_Row22 = p_DataTable22.NewRow
                            p_Row22.Item("SoLenh") = p_DataTableTK.Rows(p_int).Item("SoLenh").ToString.Trim
                            p_DataTable22.Rows.Add(p_Row22)
                        End If



                    Next
                End If
            End If


            p_RowArr = p_DataTable22.Select("SoLenh ='" & p_SoLenh & "'")

            If p_RowArr.Length > 0 Then
                Continue For
            End If


            p_Message = ""
            p_Error = False
            HuyTichKeKiemTra(p_Row.Item("Client").ToString.Trim, p_Row.Item("LoaiXuat").ToString.Trim, p_Error, p_Message, p_SoLenh)
            If p_Error = True Then
                p_SQL = "Update tblLenhXuatE5 set GhiChu =N'" & p_Message & "' where SoLenh ='" & p_SoLenh & "'"
                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                End If
            End If

            p_Row22 = p_DataTable22.NewRow
            p_Row22.Item("SoLenh") = p_SoLenh
            p_DataTable22.Rows.Add(p_Row22)


            p_SMO_ID = 0
            Try
                Integer.TryParse(p_Row.Item("SMO_ID").ToString.Trim, p_SMO_ID)
            Catch ex As Exception

            End Try

            HuyTichKe(p_Row.Item("Client").ToString.Trim, p_Row.Item("LoaiXuat").ToString.Trim, p_SoLenh, p_Message)
            If p_Message <> "" Then
                p_SQL = "Update tblLenhXuatE5 set GhiChu =N'" & p_Message & "' where SoLenh ='" & p_SoLenh & "'"
                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                End If
            Else
                If p_SMO_ID > 0 Then
                    p_SQL = "update  tblSMO_INT   set TrangThai_SMO =100 where ID= " & p_SMO_ID
                    If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                    End If
                End If
            End If

        Next
        'FPT_KiemTra_HuyTichKe'
        If p_Check = True Then
            getdata()
            Cursor = Cursors.Default
            ShowMessageBox("", "Đã thực hiện xong", 1)
        Else
            Cursor = Cursors.Default
            ShowMessageBox("", "Lệnh xuất chưa chọn")
        End If

    End Sub


    Private Sub HuyTichKeKiemTra(ByVal p_Terminal As String, ByVal p_LoaiHinhVanChuyen As String, ByRef p_Error As Boolean, ByRef p_Message As String, ByVal p_SoLenh As String)
        Dim p_SQL, p_Type As String
        Dim p_DataSet As DataSet
        Dim e As System.EventArgs
        Dim p_TableUser As DataTable
        Dim p_bHuyTichKe As Boolean = False

        p_SQL = "select * from SYS_CONFIG where KeyCode='WEBSERVER64';select * from tblconfig;" & _
                "select HuyLenh, HuyLenhEnd from SYS_USER where User_ID = " & g_User_ID & " and Getdate() <=HuyLenhEnd ;"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        p_SQL = "Y"
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then

                p_TableUser = p_DataSet.Tables(2)

                If Not p_TableUser Is Nothing Then
                    If p_TableUser.Rows.Count > 0 Then
                        If p_TableUser.Rows(0).Item("HuyLenh").ToString.Trim = "Y" Then
                            p_bHuyTichKe = True
                        End If

                    End If
                End If


                If p_DataSet.Tables(0).Rows.Count > 0 Then
                    p_SQL = p_DataSet.Tables(0).Rows(0).Item("KeyValue").ToString.Trim
                End If




                If p_DataSet.Tables(1).Rows.Count > 0 Then
                    p_Type = p_DataSet.Tables(1).Rows(0).Item("optional").ToString.Trim
                End If
            End If
        End If

        If p_Type = "FOX" Then
            ' Dim p_FOx_Obj As New FOX_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            'p_Message = p_FOx_Obj.clsScadar_HuyTichKe_fox(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        ElseIf p_Type = "ACC" Then
            ' Dim p_Acc_Obj As New ACCESS_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            ' p_Message = p_Acc_Obj.clsScadar_HuyTichKe_Access(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        Else

            p_Message = Scadar_HuyTichKeKiemtra(p_Error, g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)

            'End If

        End If


    End Sub

    Private Sub HuyTichKe(ByVal p_Terminal As String, ByVal p_LoaiHinhVanChuyen As String, ByVal p_SoLenh As String, ByRef p_Error As String)
        Dim p_Message, p_SQL, p_Type As String
        Dim p_DataSet As DataSet


        p_Error = ""
        p_SQL = "select * from SYS_CONFIG where KeyCode='WEBSERVER64';select * from tblconfig;" & _
                "select HuyLenh, HuyLenhEnd from SYS_USER where User_ID = " & g_User_ID & " and Getdate() <=HuyLenhEnd ;"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        p_SQL = "Y"
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then



                If p_DataSet.Tables(0).Rows.Count > 0 Then
                    p_SQL = p_DataSet.Tables(0).Rows(0).Item("KeyValue").ToString.Trim
                End If




                If p_DataSet.Tables(1).Rows.Count > 0 Then
                    p_Type = p_DataSet.Tables(1).Rows(0).Item("optional").ToString.Trim
                End If
            End If
        End If

        If p_Type = "FOX" Then
            Dim p_FOx_Obj As New FOX_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            p_Message = p_FOx_Obj.clsScadar_HuyTichKe_fox(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        ElseIf p_Type = "ACC" Then
            Dim p_Acc_Obj As New ACCESS_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            p_Message = p_Acc_Obj.clsScadar_HuyTichKe_Access(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        Else

            'If p_bHuyTichKe = True Then

            'Else
            p_Message = Scadar_HuyTichKe(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)

            'End If

        End If

        If p_Message.ToString.Trim <> "" Then
            p_Error = p_Message.ToString.Trim
        End If


    End Sub


    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        HuyTichKeCuoiNgay()
    End Sub

    Private Sub U_ButtonCus2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus2.Click
        getdata()
    End Sub

    Private Sub GridView1_CustomDrawGroupPanel(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs) Handles GridView1.CustomDrawGroupPanel

    End Sub

    Private Sub GridView1_CustomDrawGroupRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GridView1.CustomDrawGroupRow
        '' GridView view = sender as GridView;  
        'Dim p_info As GridGroupRowInfo
        'Dim p_Gridview As U_TextBox.GridView

        'p_info = e.Info 'as GridGroupRowInfo
        'Dim p_caption As String = ""
        'p_caption = p_info.Column.Caption
        'If p_info.Column.Caption = "" Then
        '    p_caption = p_info.Column.ToString()
        'End If


        'If e.RowHandle >= 0 Then
        '    p_info.GroupText = String.Format("{0} : {1} (count= {2})", p_caption, p_info.GroupValueText, p_Gridview.GetChildRowCount(e.RowHandle))

        'End If

       
    End Sub

    'Private Sub GridView1_CustomDrawRowFooter(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GridView1.CustomDrawRowFooter
    '    If (GridView1.GroupCount > 0) Then
    '        '   e.Graphics.
    '        e.Graphics.DrawString(GridView1.DataController.GroupRowCount.ToString(), e.Appearance.Font, System.Drawing.Brushes.Black, e.Bounds)
    '        e.Handled = True
    '    End If
    'End Sub
End Class