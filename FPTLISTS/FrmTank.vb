Public Class FrmTank
    Private g_TankGroup As Boolean = False
    Private Sub FrmTank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            SaveRecord()
        End If
    End Sub
    Private Sub SaveRecord()
        'Dim p_DataTbl As DataTable
        'Dim p_Binding As New U_TextBox.U_BindingSource
        'Dim p_Count As Integer
        'p_Binding = Me.GridView1.DataSource

        'p_DataTbl = CType(p_Binding.DataSource, DataTable)
        'For p_Count = 0 To p_DataTbl.Rows.Count - 1
        '    If p_DataTbl.Rows(p_Count).RowState = DataRowState.Deleted Then

        '    End If
        'Next

        Me.U_TextBox1.Focus()
        Me.GridView1.RefreshData()
        Me.GridView1.Focus()
        '  GridView2.SetFocusedRowModified()
        'GridView2.UpdateCurrentRow()
        'GridView2.RefreshEditor(True)
        Me.Focus()

        
        'Kiem tra  hang hoa cua be xuat co khac trong bang ty trong khong
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_Table As DataTable
        Dim p_Table_exe As New DataTable("Table001")
        Dim p_TableCheck As DataTable
        Dim p_SQL As String
        Dim p_RowArr() As DataRow
        Dim p_DataRow As DataRow
        Dim p_Count As Integer
        p_Table_exe.Columns.Add("SQL_STR")
        Dim p_RowData As DataRow
        Me.GridView1.RefreshData()
        p_Binding = Me.TrueDBGrid1.DataSource
        p_Table = CType(p_Binding.DataSource, DataTable)
        ' p_RowArr = p_Table.Select("CHECKUPD like '%Y%'")
        For p_Count = 0 To p_Table.Rows.Count - 1
            If p_Table.Rows(p_Count).RowState = DataRowState.Deleted Then
                Continue For
            End If
            p_DataRow = p_Table.Rows(p_Count)
            If p_DataRow Is Nothing Then
                Continue For
            End If

            If p_DataRow.Item("CHECKUPD").ToString.Trim = "N" Then
                Continue For
            End If
            p_SQL = "select 1 as code from  FPT_tblTankActive_v where Date1=CONVERT(date,getdate()) and Name_nd='" & _
                    p_DataRow.Item("Name_nd").ToString.Trim & "' and Product_nd <>'" & p_DataRow.Item("Product_nd").ToString.Trim & "'"
            p_TableCheck = GetDataTable(p_SQL, p_SQL)
            If Not p_TableCheck Is Nothing Then
                If p_TableCheck.Rows.Count > 0 Then
                    ShowMessageBox("", "Bể xuất  " & p_DataRow.Item("Name_nd").ToString.Trim & "  đang trong danh sách xuất trong ngày. Đề nghị loại bỏ trước khi đổi mặt hàng")
                    Exit Sub
                End If
            End If
        Next



        Me.DefaultSave = True
        UpdateToDatabase(Me, "")
        Me.DefaultSave = False
        If Me.FormStatus = False Then
            p_SQL = "update  dbo.zTankListATG set Product= (select Product_nd from tbltank h " & _
                         " where h.Name_nd=zTankListATG.tankCode )  "
            If g_Services.Sys_Execute(p_SQL, _
                                      p_SQL) = False Then
                'ShowMessageBox("", p_SQLErr)
            End If
        End If

    End Sub

    Private Sub FrmTank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        Dim p_Table As DataTable
        ToolStripButton3.Visible = False
        Dim p_Col As U_TextBox.GridColumn
        Dim p_int As Integer
        p_SQL = "select KEYVALUE from SYS_CONFIG where upper(rtrim(ltrim(Keycode))) = UPPER ('TANK_GROUP') and upper(rtrim(ltrim(KEYVALUE))) ='Y'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                g_TankGroup = True
                Me.GridView1.ViewName = "FPT_tblTank_V2"
                ToolStripButton3.Visible = True

                'p_Col = Me.GridView1.Columns.Item(5) '  Me.GridView1.Columns.Item("TankGroup")
                'p_Col.Visible = True
                'p_Col.FieldView = "TankGroup"
                'p_Col.VisibleIndex = 6
                'p_Col = Me.GridView1.Columns.Item(6) ' Me.GridView1.Columns.Item("FromDate")
                'p_Col.Visible = True
                'p_Col.VisibleIndex = 7
                'p_Col.FieldView = "FromDate"
                'p_Col = Me.GridView1.Columns.Item(7) '  Me.GridView1.Columns.Item("ToDate")
                'p_Col.Visible = True
                'p_Col.VisibleIndex = 8
                'p_Col.FieldView = "ToDate"



            End If
        End If

        If g_TankGroup = False Then
            For p_int = 0 To Me.GridView1.Columns.Count - 1
                p_Col = Me.GridView1.Columns.Item(p_int)
                If p_Col.Name = "TankGroup" Or p_Col.Name = "FromDate" Or p_Col.Name = "ToDate" Then
                    p_Col.Visible = False
                    p_Col.FieldView = ""
                    ' p_Col.Width = 0
                End If
               
            Next

        End If

       

        p_XtraUserName = g_User_ID
        If g_Filter_Terminal = True Then
            If g_Terminal <> "" Then
                Me.GridView1.Where = "( left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "')"   '  or  Product_nd in (select MahangHoa from tblHangHoaE5 )  )"
            End If
        End If

        Me.DefaultFormLoad = True
        Me.Form1_Load(sender, e)
        Me.DefaultFormLoad = False

        'If g_TankGroup = True Then

        'End If

        AddHandler Me.TrueDBGrid1.EmbeddedNavigator.ButtonClick, AddressOf TrueDBGrid1_EmbeddedNavigator_ButtonClick


    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_BeforeLeaveRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles GridView1.BeforeLeaveRow

    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged

    End Sub

    Private Sub GridView1_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        Dim p_DataRow As DataRow
        Dim p_SQL As String
        Dim p_TableCheck As DataTable

        'If UCase(e.Column.FieldName.ToString.Trim) = UCase("Product_nd") Then
        '    p_DataRow = Me.GridView1.GetFocusedDataRow

        '    p_SQL = "select 1 as code from  FPT_tblTankActive_v where Date1=CONVERT(date,getdate()) and Name_nd='" & _
        '            p_DataRow.Item("Name_nd").ToString.Trim & "' and Product_nd <>'" & e.Value.ToString.Trim & "'"
        '    p_TableCheck = GetDataTable(p_SQL, p_SQL)
        '    If Not p_TableCheck Is Nothing Then
        '        If p_TableCheck.Rows.Count > 0 Then
        '            ShowMessageBox("", "Bể xuất đang trong danh sách xuất trong ngày, đề nghị loại bỏ trước khi đổi mặt hàng")
        '            ' e.Valid = False

        '            ' Me.GridView1.
        '            Exit Sub
        '        End If
        '    End If

        'End If
    End Sub

    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick

        Dim p_DataRow As DataRow
        If g_TankGroup = True Then
            If Me.GridView1.RowCount > 0 Then
                p_DataRow = Me.GridView1.GetFocusedDataRow
                If Not p_DataRow Is Nothing Then
                    'If p_DataRow.Item("Status").ToString.Trim = "3" Or p_DataRow.Item("Status").ToString.Trim = "31" _
                    '        Or p_DataRow.Item("Status").ToString.Trim = "4" Or p_DataRow.Item("Status").ToString.Trim = "5" Then
                    Dim FrmLenhXuatAdd As New FrmTankGroup
                    FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                    FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
                    'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
                    FrmLenhXuatAdd.g_FormAddnew = False
                    FrmLenhXuatAdd.FormStatus = False
                    FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
                    FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                    FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
                    FrmLenhXuatAdd.g_TankCode = p_DataRow.Item("Name_nd").ToString.Trim
                    FrmLenhXuatAdd.g_HHCode = p_DataRow.Item("Product_nd").ToString.Trim
                    FrmLenhXuatAdd.g_HHName = p_DataRow.Item("TenHangHoa").ToString.Trim
                    FrmLenhXuatAdd.DefaultWhere = " WHERE Name_nd='" & p_DataRow.Item("Name_nd").ToString.Trim & "'"
                    FrmLenhXuatAdd.ShowDialog(Me)

                    Me.DefaultFormLoad = True
                    Me.LoadDataToForm()
                    Me.DefaultFormLoad = False

                    '   End If

                    'End If
                End If
            End If
        End If
    End Sub

    Private Sub GridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If GridView1.OptionsBehavior.ReadOnly = True Or GridView1.OptionsBehavior.Editable = False Or Me.FormEdit = False Then
                Exit Sub
            End If
            Me.TrueDBGrid1.DefaultRemove = True
            Me.TrueDBGrid1.EmbeddedNavigator.Buttons.DoClick(Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove)
            Me.TrueDBGrid1.DefaultRemove = False
        End If
    End Sub

    Private Sub GridView1_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim p_Value As Double
        Dim p_String As String
        Dim p_Gridview As U_TextBox.GridView
        Dim p_DataRow As DataRow
        Dim p_Split() As String
        Dim p_TableCheck As DataTable
        Dim p_SQL As String
        Try
            p_Gridview = CType(sender, U_TextBox.GridView)
            '  p_DataRow = p_Gridview.GetFocusedDataRow
            p_Value = 0
            'p_String = p_DataRow.Item("Dens_nd").ToString.Trim
            'p_Column_Name=p_Gridview.get
            If UCase(p_Gridview.FocusedColumn.FieldName.ToString.Trim) = UCase("Dens_nd") Then
                p_String = e.Value.ToString.Trim
                p_Value = Val(p_String)
                If p_Value >= 2 Then
                    MsgBox("Giá trị không hợp lệ", MsgBoxStyle.Critical, "Thông báo")
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

            If UCase(p_Gridview.FocusedColumn.FieldName.ToString.Trim) = UCase("Name_nd") Then
                If g_Filter_Terminal = True Then
                    If g_Terminal <> "" Then
                        p_String = UCase(e.Value.ToString.Trim)
                        If Len(p_String) > 0 Then
                            If Mid(p_String, 1, 1) <> g_Terminal Then
                                MsgBox("Giá trị mã kho không hợp lệ", MsgBoxStyle.Critical, "Thông báo")
                                e.Valid = False
                            Else
                                e.Value = p_String
                            End If
                        End If
                    End If
                End If
            End If
          
            
        Catch ex As Exception
            MsgBox("Nhập sai định dạng số", MsgBoxStyle.Critical, "Thông báo")
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        SaveRecord()
    End Sub

    Private Sub TrueDBGrid1_EmbeddedNavigator_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_DataTbl As DataTable
        Dim p_SQL As String
        Dim p_Row As DataRow

        Dim p_Count As Integer

        Select Case e.Button.ButtonType
            Case DevExpress.XtraEditors.NavigatorButtonType.Remove
                p_Row = Me.GridView1.GetFocusedDataRow
                If Not p_Row Is Nothing Then
                    If p_Row.Item("Name_nd").ToString.Trim <> "" Then
                        p_SQL = "exec FPT_CheckTankRemoved '" & p_Row.Item("Name_nd").ToString.Trim & "'," & IIf(g_E5 = True, 1, 0) & ",0"
                        p_DataTbl = GetDataTable(p_SQL, p_SQL)
                        If Not p_DataTbl Is Nothing Then
                            If p_DataTbl.Rows.Count > 0 Then
                                For p_Count = 0 To p_DataTbl.Rows.Count - 1
                                    If p_DataTbl.Rows(p_Count).Item("Require") = 1 Then
                                        ShowMessageBox("", p_DataTbl.Rows(p_Count).Item("DescName").ToString)
                                        e.Handled = True
                                        Exit Sub
                                    Else
                                        ShowMessageBox("", p_DataTbl.Rows(p_Count).Item("DescName").ToString)
                                    End If
                                Next
                            End If
                        End If
                        Me.TrueDBGrid1.DefaultRemove = True
                        Me.TrueDBGrid1.GridNavigatorButtonClick(sender, e)
                        Me.TrueDBGrid1.DefaultRemove = False
                    End If
                End If
            Case Else
        End Select
    End Sub




    Private Sub TrueDBGrid1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TrueDBGrid1.Validating
       
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_SQL, p_ConnectSapString, p_Error, p_Plant_DB As String
        Dim p_Tbl, p_TabGroup, p_Table As DataTable

        If MsgBox("Bạn có chắc chắn muốn thực hiện không?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
            Exit Sub
        End If

        p_SQL = "select  sapconnectionstring, companycode , Plant_DB from tblconfig "
        p_Tbl = GetDataTable(p_SQL, p_SQL)
        If Not p_Tbl Is Nothing Then
            If p_Tbl.Rows.Count > 0 Then
                p_Error = ""
                p_ConnectSapString = p_Tbl.Rows(0).Item("sapconnectionstring").ToString.Trim
                p_Plant_DB = p_Tbl.Rows(0).Item("Plant_DB").ToString.Trim

                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", "25", g_Company_Code)
                p_TabGroup = p_ECCDestinationConfig.clsTankGroup_Infor(p_Error, g_UserName, p_Plant_DB, g_Terminal)
                If p_Error = "" Then
                    If Not p_TabGroup Is Nothing Then
                        If p_TabGroup.Rows.Count > 0 Then
                            p_SQL = ""
                            If g_Services.Sys_Execute_DataTableNew(p_TabGroup,  p_SQL) = False Then
                                'ShowMessageBox("", p_SQLErr)
                                ShowMessageBox("", p_SQL)
                                Exit Sub
                            End If


                        End If
                    End If

                    ShowMessageBox("", "Đã thực hiện xong", 1)
                    Me.DefaultFormLoad = True
                    Me.Form1_Load(sender, e)
                    Me.DefaultFormLoad = False

                    p_SQL = "CapNhatNhomBe_HangHoa null,null,'" & g_UserName & "'"

                    If g_Services.Sys_Execute(p_SQL, _
                                                  p_SQL) = False Then
                        'ShowMessageBox("", p_SQLErr)
                    End If

                    p_SQL = "KiemTraCongto_DongboNhomBe '" & g_Terminal & "'"
                    p_Table = GetDataTable(p_SQL, p_SQL)
                    If Not p_Table Is Nothing Then
                        If p_Table.Rows.Count > 0 Then
                            ShowMessageBox("", p_Table.Rows(0).Item(1).ToString.Trim)
                        End If
                    End If
                Else
                    ShowMessageBox("", p_Error)
                End If
            End If
        End If
        

    End Sub
End Class