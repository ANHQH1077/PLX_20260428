Imports DevExpress.XtraGrid.Menu
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils.Menu
Public Class FrmMeter

    Private p_TYTRONG_PTANG As Boolean = False

    Private Sub SaveRecord()
        Dim p_DataTable As DataTable
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_ArrRow() As DataRow
        Dim p_DataRow As DataRow
        Dim p_Count As Integer
        Dim p_HangHoa As String = ""
        Dim p_BeXuat As String = ""
        Dim p_SQL As String

        Dim p_DateTime As DateTime = Now

        p_GetCurrentDate(p_DateTime)
        '  If Asc(e.KeyChar) = 19 Then

        If g_CONGTOBEXUAT = True Then
            p_Binding = Me.TrueDBGrid1.DataSource
            p_DataTable = CType(p_Binding.DataSource, DataTable)
            p_ArrRow = p_DataTable.Select("CHECKUPD='Y' Or CHECKUPD='I'")
            For p_Count = 0 To p_ArrRow.Length - 1
                p_DataRow = p_ArrRow(p_Count)
                If Not p_DataRow.Item("Name_ND") Is Nothing Then

                    If p_DataRow.Item("Name_ND").ToString.Trim <> "" Then
                        p_BeXuat = p_DataRow.Item("Name_ND").ToString.Trim
                    End If
                    If p_BeXuat = "" Then
                        'Exit Sub
                        ShowMessageBox("", "Mã công tơ " & p_DataRow.Item("MeterID").ToString.Trim & " Bể xuất không hợp lệ")
                        Exit Sub
                    End If
                    If p_DataRow.Item("ProductCode").ToString.Trim <> "" Then
                        p_HangHoa = p_DataRow.Item("ProductCode").ToString.Trim
                    End If
                    p_SQL = "select 1 as Code_HH from tblTank where Name_nd='" & p_BeXuat & "' and  Product_nd='" & p_HangHoa & "'"
                    p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                    If p_DataTable Is Nothing Then
                        ShowMessageBox("", "Mã công tơ " & p_DataRow.Item("MeterID").ToString.Trim & " :Hàng hóa và bể xuất không hợp lệ")
                        '  e.Valid = False
                        Exit Sub
                        ''.RowHandle) = False

                    ElseIf p_DataTable.Rows.Count <= 0 Then
                        ShowMessageBox("", "Mã công tơ " & p_DataRow.Item("MeterID").ToString.Trim & " :Hàng hóa và bể xuất không hợp lệ")
                        Exit Sub
                        ''Me.GridView1.IsValidRowHandle(e.RowHandle) = False
                        'e.Valid = False
                    End If
                End If
            Next
        End If

        For p_Count = 0 To Me.GridView1.RowCount - 1
            p_DataRow = Me.GridView1.GetDataRow(p_Count)
            If Not p_DataRow Is Nothing Then

                If p_DataRow.Item("CHECKUPD").ToString.Trim = "Y" Or p_DataRow.Item("CHECKUPD").ToString.Trim = "I" Then

                    If p_DataRow.Item("FromDate").ToString.Trim = "" Then
                        p_DataRow.Item("FromDate") = p_DateTime
                        GridView1.SetRowCellValue(p_Count, "FromDate", p_DateTime)
                    End If

                    CapNhatLichSuTaiTrongPhanTang(pv_LineRemove, _
                                                    1, _
                                                     p_DataRow.Item("MeterID").ToString.Trim, _
                                                     p_DataRow.Item("ArmNo").ToString.Trim, _
                                                     p_DataRow.Item("Name_ND").ToString.Trim, _
                                                     0, _
                                                     p_DataRow.Item("LoadingSite").ToString.Trim, _
                                                     p_DataRow.Item("ProductCode").ToString.Trim, _
                                                    g_UserName, _
                                                     p_DataRow.Item("FromDate").ToString.Trim)
                End If


            End If
        Next


        Me.DefaultSave = True
        Me.UpdateToDatabase(Me, "")
        Me.DefaultSave = False

        p_SQL = "CapNhatNhomBe_HangHoa null,null,'" & g_UserName & "', 'Y' "

        If g_Services.Sys_Execute(p_SQL, _
                                      p_SQL) = False Then
            'ShowMessageBox("", p_SQLErr)
        End If
        '   End If
    End Sub


    Private Sub FrmMeter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress


        If Asc(e.KeyChar) = 19 Then
            SaveRecord()
        End If
    End Sub


    Private Sub FrmMeter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_Meter As String
        Dim p_WhereCol As String
        Dim p_Column As U_TextBox.GridColumn
        Dim p_DataRow() As DataRow
        Dim p_DataTable As DataTable




        Dim p_SQL As String = ""

        

        p_SQL = "select Name_nd  from tblTank where  Product_nd =:Column.ProductCode"
        Try
            p_XtraUserName = g_User_ID
            If g_Filter_Terminal = True Then
                If g_Terminal <> "" Then
                    Select Case g_Terminal
                        Case "A"
                            p_Meter = "C1"
                        Case "B"
                            p_Meter = "C2"
                        Case Else
                            p_Meter = "C3"
                    End Select
                    p_WhereCol = "left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'"
                    p_SQL = p_SQL & " and " & p_WhereCol

                    Me.GridView1.Where = "left(MeterId,LEN ('" & p_Meter & "')) like '" & p_Meter & "%'"
                End If
            End If
        Catch ex As Exception

        End Try


        Me.DefaultFormLoad = True
        Me.XtraForm1_Load()
        Me.DefaultFormLoad = True
        Me.GridView1.BestFitColumns()
        p_Column = Me.GridView1.Columns.Item("Name_ND")
        p_Column.SQLString = p_SQL

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

                p_DataRow = p_DataTable.Select("KEYCODE='CONGTOBEXUAT'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        Me.GridView1.Columns.Item("Name_ND").VisibleIndex = -1
                    End If
                End If


            End If
        End If

        If p_TYTRONG_PTANG = False Then
            Me.GridView1.Columns.Item("FromDate").VisibleIndex = -1
        Else
            Me.GridView1.Columns.Item("FromDate").Width = 180
        End If


        ToolStripButton2.Visible = False
        p_SQL = "select KEYVALUE from SYS_CONFIG where upper(rtrim(ltrim(Keycode))) = UPPER ('TANK_GROUP') and upper(rtrim(ltrim(KEYVALUE))) ='Y'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                ToolStripButton2.Visible = True
            End If
        End If




        'Me.GridView1.ActiveFilterSt()
    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim p_DataRow As DataRow
        Dim p_HangHoa As String = ""
        Dim p_BeXuat As String = ""
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_String As String
        Dim p_Column As U_TextBox.GridColumn
        Dim p_DateTime As DateTime


        
        p_Column = Me.GridView1.FocusedColumn


        ' p_GetCurrentDate(p_DateTime)
        '  p_Column = e.Column
        p_DataRow = GridView1.GetFocusedDataRow

        If Not p_DataRow Is Nothing Then
            If UCase(p_Column.FieldView) <> UCase("FromDate") And GridView1.FocusedRowModified = True Then   'And (p_DataRow.RowState = DataRowState.Modified Or p_DataRow.RowState = DataRowState.Added) Then
                '   GridView1.FocusedColumn = Me.GridView1.Columns.Item("FromDate")
                p_GetCurrentDate(p_DateTime)
                p_DataRow.Item("FromDate") = p_DateTime
                'GridView1.UpdateCurrentRow()
                ' Me.GridView1.SetFocusedRowCellValue("FromDate", p_DateTime)
                'GridView1.FocusedColumn = p_Column
            End If
        End If


        Exit Sub

        p_Column = e.Column
        If UCase(p_Column.FieldView) = UCase("ProductCode") Or UCase(p_Column.FieldView) = UCase("Name_ND") Then


            p_DataRow = Me.GridView1.GetDataRow(e.RowHandle)
            If Not p_DataRow.Item("Name_ND") Is Nothing Then


                If p_DataRow.Item("Name_ND").ToString.Trim <> "" Then
                    p_BeXuat = p_DataRow.Item("Name_ND").ToString.Trim
                End If
                If p_BeXuat = "" Then
                    Exit Sub
                End If
                If p_DataRow.Item("ProductCode").ToString.Trim <> "" Then
                    p_HangHoa = p_DataRow.Item("ProductCode").ToString.Trim
                End If
                p_SQL = "select 1 as Code_HH from tblTank where Name_nd='" & p_BeXuat & "' and  Product_nd='" & p_HangHoa & "'"
                p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If p_DataTable Is Nothing Then
                    ShowMessageBox("", "Hàng hóa và bể xuất không hợp lệ")
                    '  e.Valid = False
                    Me.GridView1.InvalidateRow(e.RowHandle)
                    ''.RowHandle) = False

                ElseIf p_DataTable.Rows.Count <= 0 Then
                    ShowMessageBox("", "Hàng hóa và bể xuất không hợp lệ")
                    Me.GridView1.InvalidateRow(e.RowHandle)
                    ''Me.GridView1.IsValidRowHandle(e.RowHandle) = False
                    'e.Valid = False
                End If
            End If
        ElseIf UCase(p_Column.FieldView) = UCase("MeterID") Then
            ' If UCase(GridView1.FocusedColumn.FieldName.ToString.Trim) = UCase("Name_nd") Then
            If g_Filter_Terminal = True Then
                If g_Terminal <> "" Then
                    p_String = e.Value.ToString.Trim
                    If Len(p_String) > 0 Then
                        If Mid(p_String, 1, 1) <> g_Terminal Then
                            MsgBox("Giá trị mã kho không hợp lệ", MsgBoxStyle.Critical, "Thông báo")
                            Me.GridView1.InvalidateRow(e.RowHandle)
                            'e.Valid = False
                        End If
                    End If
                End If
            End If
            ' If
        End If
    End Sub

    Private Sub GridView1_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging


    End Sub

    Private Sub GridView1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged

    End Sub

    Private Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView1.RowUpdated

    End Sub





    Private Sub GridView1_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView1.ValidateRow
        Dim p_Column As U_TextBox.GridColumn
        Dim p_DateTime As DateTime
        Dim p_DataRow As DataRow

        p_Column = Me.GridView1.FocusedColumn


        ' p_GetCurrentDate(p_DateTime)
        '  p_Column = e.Column
        p_DataRow = GridView1.GetFocusedDataRow

        If Not p_DataRow Is Nothing Then
            If UCase(p_Column.FieldView) = UCase("Name_ND") And GridView1.FocusedRowModified = True Then   'And (p_DataRow.RowState = DataRowState.Modified Or p_DataRow.RowState = DataRowState.Added) Then
                '   GridView1.FocusedColumn = Me.GridView1.Columns.Item("FromDate")
                p_GetCurrentDate(p_DateTime)
                p_DataRow.Item("FromDate") = p_DateTime
                'GridView1.UpdateCurrentRow()
                ' Me.GridView1.SetFocusedRowCellValue("FromDate", p_DateTime)
                'GridView1.FocusedColumn = p_Column
            End If
        End If

        'Dim p_DataRow As DataRow
        'Dim p_HangHoa As String = ""
        'Dim p_BeXuat As String = ""
        'Dim p_SQL As String
        'Dim p_DataTable As DataTable
        'p_DataRow = Me.GridView1.GetDataRow(e.RowHandle)
        'If Not p_DataRow.Item("Name_ND") Is Nothing Then


        '    If p_DataRow.Item("Name_ND").ToString.Trim <> "" Then
        '        p_BeXuat = p_DataRow.Item("Name_ND").ToString.Trim
        '    End If
        '    If p_BeXuat = "" Then
        '        Exit Sub
        '    End If
        '    If p_DataRow.Item("ProductCode").ToString.Trim <> "" Then
        '        p_HangHoa = p_DataRow.Item("ProductCode").ToString.Trim
        '    End If
        '    p_SQL = "select 1 as Code_HH from tblTank where Name_nd='" & p_BeXuat & "' and  Product_nd='" & p_HangHoa & "'"
        '    p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        '    If p_DataTable Is Nothing Then
        '        ShowMessageBox("", "Hàng hóa và bể xuất không hợp lệ")
        '        e.Valid = False
        '    ElseIf p_DataTable.Rows.Count <= 0 Then
        '        ShowMessageBox("", "Hàng hóa và bể xuất không hợp lệ")
        '        e.Valid = False
        '    End If
        'End If
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SaveRecord()
    End Sub


    'Private Sub bandedGridView1_PopupMenuShowing(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GridView1.PopupMenuShowing
    '    'If e.MenuType = GridMenuType.Column Then
    '    Dim menu As GridViewColumnMenu = e.Menu
    '    menu.Items.Clear()
    '    If Not menu.Column Is Nothing Then
    '        menu.Items.Add(CreateCheckItem("Can Moved", menu.Column, Nothing))
    '    End If
    '    ' End If
    'End Sub

    '' Creates a menu item.
    'Function CreateCheckItem(ByVal caption As String, ByVal column As GridColumn, _
    '  ByVal image As Image) As DXMenuCheckItem
    '    Dim item As DXMenuCheckItem = New DXMenuCheckItem(caption, _
    '      column.OptionsColumn.AllowMove, image, _
    '      New EventHandler(AddressOf OnCanMovedItemClick))
    '    item.Tag = New MenuColumnInfo(column)
    '    Return item
    'End Function

    '' Menu item click handler.
    'Sub OnCanMovedItemClick(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim item As DXMenuCheckItem = sender
    '    Dim info As MenuColumnInfo = CType(item.Tag, MenuColumnInfo)
    '    If info Is Nothing Then Return
    '    info.Column.OptionsColumn.AllowMove = item.Checked
    'End Sub

    'Class MenuColumnInfo
    '    Public Sub New(ByVal column As GridColumn)
    '        Me.Column = column
    '    End Sub
    '    Public Column As GridColumn
    'End Class

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim p_DataRow As DataRow
        Dim p_HangHoa As String = ""
        Dim p_BeXuat As String = ""
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_String As String
        Dim p_DateTime As DateTime
        Dim p_Column As U_TextBox.GridColumn
        p_Column = Me.GridView1.FocusedColumn


        ' p_GetCurrentDate(p_DateTime)
        '  p_Column = e.Column
        ' p_DataRow = GridView1.GetFocusedDataRow

        'If Not p_DataRow Is Nothing Then
        '    If UCase(p_Column.FieldView) <> UCase("FromDate") And (p_DataRow.RowState = DataRowState.Modified Or p_DataRow.RowState = DataRowState.Added) Then
        '        If p_DataRow.Item("FromDate").ToString.Trim = "" Then
        '            p_DataRow.Item("FromDate") = p_DateTime
        '        End If
        '        'Me.GridView1.SetFocusedRowCellValue("FromDate", p_DateTime)
        '    End If
        'End If
      


        If UCase(p_Column.FieldView) = UCase("ProductCode") Or UCase(p_Column.FieldView) = UCase("Name_ND") Then


            p_DataRow = Me.GridView1.GetFocusedDataRow  'Me.GridView1.GetDataRow(Me.)
            If Not p_DataRow.Item("Name_ND") Is Nothing Then


                If p_DataRow.Item("Name_ND").ToString.Trim <> "" Then
                    p_BeXuat = p_DataRow.Item("Name_ND").ToString.Trim
                End If
                If p_BeXuat = "" Then
                    Exit Sub
                End If
                If p_DataRow.Item("ProductCode").ToString.Trim <> "" Then
                    p_HangHoa = p_DataRow.Item("ProductCode").ToString.Trim
                End If
                p_SQL = "select 1 as Code_HH from tblTank where Name_nd='" & p_BeXuat & "' and  Product_nd='" & p_HangHoa & "'"
                p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If p_DataTable Is Nothing Then
                    ShowMessageBox("", "Hàng hóa và bể xuất không hợp lệ")
                    e.Valid = False
                    ' Me.GridView1.InvalidateRow(e.RowHandle)
                    ''.RowHandle) = False

                ElseIf p_DataTable.Rows.Count <= 0 Then
                    ShowMessageBox("", "Hàng hóa và bể xuất không hợp lệ")
                    'Me.GridView1.InvalidateRow(e.RowHandle)
                    ''Me.GridView1.IsValidRowHandle(e.RowHandle) = False
                    e.Valid = False
                End If
            End If
        ElseIf UCase(p_Column.FieldView) = UCase("MeterID") Then
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

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim p_DataRow As DataRow
        Dim p_Meter As String
        'If g_TankGroup = True Then
        If Me.GridView1.RowCount > 0 Then
            p_DataRow = Me.GridView1.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then
                'If p_DataRow.Item("Status").ToString.Trim = "3" Or p_DataRow.Item("Status").ToString.Trim = "31" _
                '        Or p_DataRow.Item("Status").ToString.Trim = "4" Or p_DataRow.Item("Status").ToString.Trim = "5" Then
                Dim FrmLenhXuatAdd As New FrmMeterGroup

                FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
                'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
                FrmLenhXuatAdd.g_FormAddnew = False
                FrmLenhXuatAdd.FormStatus = False
                FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
                FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus

                FrmLenhXuatAdd.READ_ONLY = "Y"


                '' FrmLenhXuatAdd.p_SQLWHere = " left(MeterId,LEN ('" & p_Meter & "')) like '" & p_Meter & "%'"
                FrmLenhXuatAdd.ShowDialog(Me)

                Me.DefaultFormLoad = True
                Me.LoadDataToForm()
                Me.DefaultFormLoad = False

                '   End If

                'End If
            End If
        End If
        'End If
    End Sub
End Class