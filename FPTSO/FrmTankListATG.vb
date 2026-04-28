Public Class FrmTankListATG
    Private p_TableDelete As New DataTable("Table001")
    Private g_NhomBeXuat As Boolean = False

    Private Sub FrmTankATG_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String = ""
        Dim p_datatable As DataTable
        Dim p_Tmp As String = ""
        Dim p_column1 As U_TextBox.GridColumn
        Dim p_Table As DataTable
        Dim p_int As Integer
        Dim p_String As String

        p_String = "select KEYVALUE from sys_config where KEYCODE='TANK_GROUP' "
        p_Table = GetDataTable(p_String, p_String)

        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    g_NhomBeXuat = True
                End If
            End If

        End If



        p_TableDelete.Columns.Add("STR_SQL")
        If g_Company_Code = "6610" Then
            p_SQL = "select Terminal from sys_user  where upper(user_name ) =upper('" & g_UserName & "')"
            p_datatable = GetDataTable(p_SQL, p_SQL)
            If Not p_datatable Is Nothing Then
                If p_datatable.Rows.Count > 0 Then
                    p_Tmp = p_datatable.Rows(0).Item("Terminal").ToString.Trim
                End If
            End If
            If InStr(p_Tmp, "C", CompareMethod.Text) > 0 Then
                p_SQL = " (charindex(Client,(select Terminal from sys_user  where upper(user_name ) =upper('" & g_UserName & "')),1) >0 or left(Client,1) ='D' ) "
            Else
                p_SQL = " charindex(Client,(select Terminal from sys_user  where upper(user_name ) =upper('" & g_UserName & "')),1) >0"
            End If
            ' p_SQL = " charindex(Client,(select Terminal from sys_user  where upper(user_name ) =upper('" & g_UserName & "')),1) >0"
            Me.GridView1.Where = p_SQL
            Me.GridView2.Where = p_SQL
        End If

        If g_NhomBeXuat = False Then
            For p_int = 0 To Me.GridView1.Columns.Count - 1
                p_column1 = Me.GridView1.Columns.Item(p_int)
                If p_column1.Name = "NhomBeXuat" Then
                    p_column1.Visible = False
                    p_column1.FieldView = ""
                End If

            Next

            For p_int = 0 To Me.GridView2.Columns.Count - 1
                p_column1 = Me.GridView2.Columns.Item(p_int)
                If p_column1.Name = "NhomBeXuat" Then
                    p_column1.Visible = False
                    p_column1.FieldView = ""
                End If

            Next


        End If


        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False
        Me.GridView2.OptionsBehavior.ReadOnly = True
        p_TableDelete.Clear()

    End Sub


    Private Sub TankActive_Insert()
        Dim p_DataRow As DataRow
        Dim p_DataRowArr() As Integer
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_DataTable As DataTable
        Dim p_Array() As DataRow
        Dim p_Count As Integer

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
                        p_Array = p_DataTable.Select("TankCode='" & p_DataRow.Item("Name_nd").ToString.Trim & "'")
                        If p_Array.Length > 0 Then
                            ShowMessageBox("", "Bể xuất đã tồn tại")
                            Exit Sub
                        End If
                    End If
                    If p_DataTable.Rows.Count >= 0 Then
                        Me.GridView2.AddNewRow()

                    Else
                        If p_DataTable.Rows(p_DataTable.Rows.Count - 1).RowState = DataRowState.Deleted Then
                            Me.GridView2.AddNewRow()
                        Else
                            If p_DataTable.Rows(p_DataTable.Rows.Count - 1).Item("TankCode").ToString.Trim <> "" Then
                                Me.GridView2.AddNewRow()
                            End If
                        End If
                    End If

                    Me.GridView2.SetFocusedRowCellValue("TankCode", p_DataRow.Item("Name_nd").ToString.Trim)
                    'Me.GridView2.SetFocusedRowCellValue("Dens_nd", p_DataRow.Item("Dens_nd").ToString.Trim)
                    Me.GridView2.SetFocusedRowCellValue("Product", p_DataRow.Item("Product_nd").ToString.Trim)
                    Me.GridView2.SetFocusedRowCellValue("TenHangHoa", p_DataRow.Item("TenHangHoa").ToString.Trim)
                    If g_NhomBeXuat = True Then
                        Me.GridView2.SetFocusedRowCellValue("NhomBeXuat", p_DataRow.Item("NhomBeXuat").ToString.Trim)
                    End If

                    Me.GridView2.SetFocusedRowCellValue("CHECKUPD", "I")
                    Me.GridView2.SetFocusedRowCellValue("Client", p_DataRow.Item("Client").ToString.Trim)
                    'CrUser
                    Me.GridView2.SetFocusedRowCellValue("CrUser", g_UserName)
                End If
            Next
            Me.GridView1.DeleteSelectedRows()
            '  Next
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
        Dim p_RowDel As DataRow

        Dim Name_nd, Dens_nd, Product_nd, TenHangHoa, p_NhomBe As String

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
                Name_nd = p_DataRow.Item("TankCode").ToString.Trim
                '  Dens_nd = p_DataRow.Item("Dens_nd").ToString.Trim
                Product_nd = p_DataRow.Item("Product").ToString.Trim
                TenHangHoa = p_DataRow.Item("TenHangHoa").ToString.Trim
                If g_NhomBeXuat = True Then
                    p_NhomBe = p_DataRow.Item("NhomBeXuat").ToString.Trim
                End If


                p_DataRow = p_DataTbl.NewRow

                p_DataRow.Item("Name_nd") = Name_nd
                ' p_DataRow.Item("Dens_nd") = Dens_nd
                p_DataRow.Item("Product_nd") = Product_nd
                p_DataRow.Item("TenHangHoa") = TenHangHoa
                p_DataTbl.Rows.Add(p_DataRow)
                p_SQL = ""
                If g_NhomBeXuat = True Then
                    p_SQL = "INSERT INTO [zTankListATG_Hist] ([TankCode] ,[Product],[CrUser],[Status],[DateHist], NhomBeXuat) " & _
                        " VALUES ('" & Name_nd & "', '" & Product_nd & "','" & g_UserName & "','D', getdate(),'" & p_NhomBe & "') "
                Else
                    p_SQL = "INSERT INTO [zTankListATG_Hist] ([TankCode] ,[Product],[CrUser],[Status],[DateHist]) " & _
                        " VALUES ('" & Name_nd & "', '" & Product_nd & "','" & g_UserName & "','D', getdate()) "
                End If
                
                p_RowDel = p_TableDelete.NewRow
                p_RowDel.Item(0) = p_SQL
                p_TableDelete.Rows.Add(p_RowDel)

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
    'Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs)
    '    Dim p_ValueMess As Windows.Forms.DialogResult

    '    p_ValueMess = g_Module.ShowMessage(Me, "", _
    '                                "Bạn có chắn chắn muốn lấy lại lệnh từ SAP không?", _
    '                                True, _
    '                                    "Có", _
    '                                True, _
    '                                "Không", _
    '                                False, _
    '                                "", _
    '                                    0)

    '    If p_ValueMess = Windows.Forms.DialogResult.No Then
    '        ' Cursor = Cursors.Default
    '        Exit Sub
    '    End If
    'End Sub

    Private Sub U_ButtonCus1_Click(sender As System.Object, e As System.EventArgs) Handles U_ButtonCus1.Click
        TankActive_Insert()
    End Sub

    Private Sub U_ButtonCus2_Click(sender As System.Object, e As System.EventArgs) Handles U_ButtonCus2.Click
        TankActive_Removed()
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dim p_SQL As String = ""
        Me.DefaultSave = True
        Me.GridView2.AllowInsert = True
        Me.UpdateToDatabase(Me, "")
        Me.DefaultSave = False
        Me.GridView1.BestFitColumns()
        Me.GridView2.BestFitColumns()
        Me.GridView2.AllowInsert = False
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False
        If Me.FormStatus = False Then
            If g_Services.Sys_Execute_DataTbl(p_TableDelete, p_SQL) = False Then
                ShowMessageBox("", p_SQL)
                Exit Sub
            End If
            p_TableDelete.Clear()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
     

        Dim FrmATG As New FrmTankListATG_Hist
        FrmATG.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmATG.g_XtraServicesObj = g_XtraServicesObj
        'FrmATG.g_Approved = g_Approved
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim

        ' FrmLenhXuatAdd.READ_ONLY = Me.READ_ONLY

        FrmATG.p_XtraToolTripLabel = g_ToolStripStatus
        FrmATG.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmATG.p_XtraMessageStatusl = g_MessageStatus
        FrmATG.g_Tank = "" ' p_DataRow.Item("TankCode").ToString.Trim

        FrmATG.ShowDialog(Me)

    End Sub

    Private Sub TrueDBGrid2_Click(sender As System.Object, e As System.EventArgs) Handles TrueDBGrid2.Click

    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As System.EventArgs) Handles GridView2.DoubleClick
        Dim p_DataRow As DataRow

        If Me.GridView2.RowCount > 0 Then
            p_DataRow = Me.GridView2.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then

                Dim FrmATG As New FrmTankListATG_AM_Hist
                FrmATG.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                FrmATG.g_XtraServicesObj = g_XtraServicesObj
                'FrmATG.g_Approved = g_Approved
                'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim

                ' FrmLenhXuatAdd.READ_ONLY = Me.READ_ONLY

                FrmATG.p_XtraToolTripLabel = g_ToolStripStatus
                FrmATG.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                FrmATG.p_XtraMessageStatusl = g_MessageStatus
                FrmATG.g_Tank = p_DataRow.Item("TankCode").ToString.Trim

                FrmATG.ShowDialog(Me)
            End If

        End If
    End Sub
End Class