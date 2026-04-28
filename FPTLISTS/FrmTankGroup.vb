Public Class FrmTankGroup

    Public g_TankCode As String = ""
    Public g_HHCode As String = ""
    Public g_HHName As String = ""

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
            'p_SQL = "select 1 as code from  FPT_tblTankActive_v where Date1=CONVERT(date,getdate()) and Name_nd='" & _
            '        p_DataRow.Item("Name_nd").ToString.Trim & "' and Product_nd <>'" & p_DataRow.Item("Product_nd").ToString.Trim & "'"
            'p_TableCheck = GetDataTable(p_SQL, p_SQL)
            'If Not p_TableCheck Is Nothing Then
            '    If p_TableCheck.Rows.Count > 0 Then
            '        ShowMessageBox("", "Bể xuất  " & p_DataRow.Item("Name_nd").ToString.Trim & "  đang trong danh sách xuất trong ngày. Đề nghị loại bỏ trước khi đổi mặt hàng")
            '        Exit Sub
            '    End If
            'End If
        Next



        Me.DefaultSave = True
        UpdateToDatabase(Me, "")
        Me.DefaultSave = False
        'If Me.FormStatus = False Then
        '    p_SQL = "update  dbo.zTankListATG set Product= (select Product_nd from tbltank h " & _
        '                 " where h.Name_nd=zTankListATG.tankCode )  "
        '    If g_Services.Sys_Execute(p_SQL, _
        '                              p_SQL) = False Then
        '        'ShowMessageBox("", p_SQLErr)
        '    End If
        'End If

    End Sub

    Private Sub FrmTank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        p_XtraUserName = g_User_ID
        'If g_Filter_Terminal = True Then
        '    If g_Terminal <> "" Then
        '        Me.GridView1.Where = "( left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "')"   '  or  Product_nd in (select MahangHoa from tblHangHoaE5 )  )"
        '    End If
        'End If
        Me.GridView1.Where = "Name_nd='" & g_TankCode & "'"
        Me.DefaultFormLoad = True
        Me.Form1_Load(sender, e)
        Me.DefaultFormLoad = False

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
        Dim p_ID As Integer = 0
        Try
            p_Gridview = CType(sender, U_TextBox.GridView)
            p_DataRow = p_Gridview.GetFocusedDataRow
            p_Value = 0
            If Not p_DataRow Is Nothing Then
                p_String = p_DataRow.Item("Name_nd").ToString.Trim
                If p_String = "" Then
                    p_DataRow.Item("Name_nd") = g_TankCode
                    p_DataRow.Item("Product_nd") = g_HHCode
                    p_DataRow.Item("TenHangHoa") = g_HHName
                End If

                Integer.TryParse(p_DataRow.Item("ID").ToString.Trim, p_ID)
                If p_ID = 0 Then
                    p_DataRow.Item("CreateUser") = g_UserName
                    p_DataRow.Item("UpdateUser") = g_UserName
                Else
                    p_DataRow.Item("UpdateUser") = g_UserName
                End If
                p_DataRow.Item("TichHop") = "N"
            End If
            'p_String = p_DataRow.Item("Dens_nd").ToString.Trim
            'p_Column_Name=p_Gridview.get
            'If UCase(p_Gridview.FocusedColumn.FieldName.ToString.Trim) = UCase("Dens_nd") Then
            '    p_String = e.Value.ToString.Trim
            '    p_Value = Val(p_String)
            '    If p_Value >= 2 Then
            '        MsgBox("Giá trị không hợp lệ", MsgBoxStyle.Critical, "Thông báo")
            '        e.Valid = False
            '        Exit Sub
            '        ' p_Gridview.InvalidateRowCell(e.RowHandle, e.Column)
            '    ElseIf p_Value = 1 Or p_Value = 0 Then
            '        MsgBox("Giá trị không hợp lệ", MsgBoxStyle.Critical, "Thông báo")
            '        e.Valid = False
            '        Exit Sub
            '    End If
            '    p_String = Format(p_Value, "#0.###0").ToString
            '    e.Value = p_String
            'End If

            'If UCase(p_Gridview.FocusedColumn.FieldName.ToString.Trim) = UCase("Name_nd") Then
            '    If g_Filter_Terminal = True Then
            '        If g_Terminal <> "" Then
            '            p_String = UCase(e.Value.ToString.Trim)
            '            If Len(p_String) > 0 Then
            '                If Mid(p_String, 1, 1) <> g_Terminal Then
            '                    MsgBox("Giá trị mã kho không hợp lệ", MsgBoxStyle.Critical, "Thông báo")
            '                    e.Valid = False
            '                Else
            '                    e.Value = p_String
            '                End If
            '            End If
            '        End If
            '    End If
            'End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Thông báo")
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

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim FrmVehicleTmp As New FrmTankGroupHist
        'FrmVehicleTmp.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        'FrmVehicleTmp.g_XtraServicesObj = g_XtraServicesObj
        ''FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
        'FrmVehicleTmp.g_FormAddnew = False
        'FrmVehicleTmp.FormStatus = False
        'FrmVehicleTmp.p_XtraToolTripLabel = g_ToolStripStatus
        'FrmVehicleTmp.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        'FrmVehicleTmp.p_XtraMessageStatusl = g_MessageStatus
        ''FrmVehicleTmp.DefaultWhere = " WHERE MaPhuongTien=N'" & p_DataRow.Item(Me.GridView1.ColumnKey).ToString.Trim & "'"
        'FrmVehicleTmp.ShowDialog(Me)
    End Sub
End Class