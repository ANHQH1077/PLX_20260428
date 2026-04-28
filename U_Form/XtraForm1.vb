Public Class XtraForm1 
    Public g_XtraServicesObj As Object = Nothing
    Public p_XtraModuleObj As Object = Nothing
    Public p_XtraUserName As String = ""
    'Public p_FptSericeObj As Object
    Public p_XtraDataSet_TrueGird As DataSet = Nothing
    Public p_XtraBindingSourceHeader As New System.Windows.Forms.BindingSource
    Public p_XtraPageNum As Integer
    Public g_XtraParameterArray(0 To 20) As String
    Public p_XtraToolTripLabel As New System.Windows.Forms.ToolStripStatusLabel
    Public p_XtraMessageStatusl As New System.Windows.Forms.ToolStripStatusLabel
    Public g_XtraFunctionID As Integer
    Public g_FormLoad As Boolean = False

    Public g_ChooseRecordFromSearch As Boolean = False

    Private g_ValueType As Integer = 0

    'Private p_TrueGirdLineAdd2(0 To 2000) As Boolean  'Dung mảng để lưu các line number trong TrueGrid khi thêm bản ghi
    'Private p_TrueGirdLineUpd2(0 To 2000) As Boolean  'Dung mảng để lưu các line number trong TrueGrid khi update bản ghi
    'Private p_TrueGirdLineDel2(0 To 2000) As String   'Dung mảng để lưu gia tri trong TrueGrid khi delete bản ghi
    '=====================================================

    Public g_ObjectUpdateIsNull(0 To 100) As String

    Public g_ObjectUpdateIsNullColor(0 To 100) As System.Drawing.Color

    Private p_GridViewUpdateValue As Boolean = False

    Public pv_Back_Color As System.Drawing.Color = System.Drawing.Color.White
    Public pv_Required_Back_Color As System.Drawing.Color = System.Drawing.Color.LightGoldenrodYellow
    Public pv_Locked_Back_Color As System.Drawing.Color = System.Drawing.Color.LightGray '   System.Drawing.Color.LightCyan

    Public pv_LineRemove As New DataTable("Table01")


    'Private Sub XtraForm1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '    If Me.FormStatus = True Then

    '    End If
    'End Sub

    Private Sub XtraForm1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.FormStatus = True Then
            'If MsgBox("Thông tin chưa được lưu. Bạn có muốn xem lại không?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1) = MsgBoxResult.Yes Then

            '    e.Cancel = True
            'End If
            If p_XtraModuleObj.ShowMessage(Me,
                                       "",
                    "Thông tin chưa được lưu. Bạn có muốn xem lại không?",
                    True,
                    "Có",
                    True,
                    "Không",
                     False,
                    "",
                   2) = Windows.Forms.DialogResult.Yes Then
                e.Cancel = True
            End If
        End If
        Try
            p_XtraToolTripLabel.Text = ""
        Catch ex As Exception

        End Try

    End Sub

    Public Sub Edit_Button_Click(ByVal p_Item As Object, _
                                        ByRef p_RptForm As Object, _
                                        ByRef p_Commit1 As Boolean, _
                                        ByRef p_ButtonOK As Object, _
                                        ByVal p_CaptionUpd As String)
        p_XtraModuleObj.p_Mod_Edit_Button_Click(p_Item, p_RptForm, p_Commit1, p_ButtonOK, p_CaptionUpd)
    End Sub


    Public Sub LoadDataToForm(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_Where As String = ""
        Dim p_Page_Total As Integer
        Dim P_Databale As DataTable
        Dim p_Desc As String
        Dim p_SQL As String
        Try
            ' If Me.DefaultFormLoad = True Then Exit Sub
            g_FormLoad = True
            If p_XtraModuleObj Is Nothing Then Exit Sub
            If p_XtraModuleObj.p_Mod_Set_BindSource_ForForm(p_XtraDataSet_TrueGird, SetSourceItem, Me, HeaderSource.ToString.Trim, p_XtraBindingSourceHeader, HeaderSource.ToString.Trim, "", p_Page_Total, GetB1, DefaultWhere, 1000, p_XtraPageNum) = False Then
                'MsgBox("Lỗi khi mở Form")
                p_XtraModuleObj.ModErrExceptionNew("", "Lỗi khi mở Form")
                g_FormLoad = False
                Exit Sub
            Else

            End If
            p_SQL = "select UserAdmin from  SYS_USER where  upper(USER_NAME)=upper(:GLOBAL.USERNAME)"
            p_SQL = p_XtraModuleObj.Parameter_Item(Me, p_SQL)
            P_Databale = p_XtraModuleObj.ModGET_DATATABLE_Des(p_SQL, p_Desc)
            If P_Databale Is Nothing Then
                g_FormLoad = False
                Exit Sub
            Else
                If P_Databale.Rows.Count <= 0 Then
                    g_FormLoad = False
                    Exit Sub
                Else
                    If P_Databale.Rows(0).Item(0).ToString.Trim = "Y" Then
                        Dim Contextual = New Windows.Forms.ContextMenuStrip
                        Dim MenuItemProperty = New Windows.Forms.ToolStripMenuItem("Item Property", Nothing, New EventHandler(AddressOf MyMenuItem))
                        MenuItemProperty.Name = "MnuItemProperty"
                        Contextual.Items.Add(MenuItemProperty)
                        'Contextual.Items.AddRange(MenuEdit)
                        ContextMenuStrip = Contextual

                    End If
                End If
            End If

            SetColunmEditForView()


            'UpdateTataBase()

            g_FormLoad = False '
        Catch ex As Exception
            ' MsgBox(ex.Message)
            p_XtraModuleObj.ModErrExceptionNew(Err.Number, ex.Message)
            g_FormLoad = False
        End Try


        'If p_FptModule.p_ModControl_UpdateIfNull(Me, False) = False Then
        '    MsgBox("Lỗi khi thực hiện")
        'End If



    End Sub

    Sub XtraForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_Col As New DataColumn

        p_Col.ColumnName = "SQL_STR"
        p_Col.DataType = GetType(String)
        p_Col.MaxLength = 4000
        pv_LineRemove.Columns.Add(p_Col)

        If DefaultFormLoad = True Then
            LoadDataToForm(sender, e)
        End If


    End Sub


    Private Sub SetColunmEditForView()
        Dim p_Count As Integer
        Dim p_RowArr() As DataRow
        Dim p_TrueGrid As U_TextBox.U_TrueDBGrid = Nothing
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        Dim p_TrueGridName As String = ""
        Dim p_Control() As Object
        Try
            If p_XtraDataSet_TrueGird Is Nothing Then Exit Sub
            If p_XtraDataSet_TrueGird.Tables.Count > 0 Then

                p_RowArr = p_XtraDataSet_TrueGird.Tables(0).Select("FORM_NAME='" & UCase(Me.Name) & _
                                                         "'  ", "GRID_NAME")
                'and DefaultButtonClick='Y' and CFL='Y'

                For p_Count = 0 To p_RowArr.Length - 1
                    If p_RowArr(p_Count).Item("GRID_NAME").ToString.Trim <> "" Then
                        If p_RowArr(p_Count).Item("GRID_NAME").ToString.Trim <> p_TrueGridName.Trim Then
                            p_TrueGridName = p_RowArr(p_Count).Item("GRID_NAME").ToString.Trim
                            p_Control = Me.Controls.Find(p_TrueGridName, True)
                            If Not p_Control Is Nothing Then
                                p_TrueGrid = CType(p_Control(0), U_TextBox.U_TrueDBGrid)
                                p_GridView = p_TrueGrid.Views(0)
                            Else
                                Continue For
                            End If
                        End If
                        If Not p_TrueGrid Is Nothing And Not p_GridView Is Nothing Then
                            AddHandler p_GridView.FocusedColumnChanged, AddressOf GridView1_FocusedColumnChanged
                            AddHandler p_GridView.ValidatingEditor, AddressOf GridView_ValidatingEditor
                            AddHandler p_GridView.InitNewRow, AddressOf GridView1_InitNewRow
                            AddHandler p_TrueGrid.EditorKeyPress, AddressOf GridView_KeyPress

                            AddHandler p_TrueGrid.EmbeddedNavigator.ButtonClick, AddressOf GridNavigatorButtonClick

                            'GridView1.InitNewRow
                            If p_RowArr(p_Count).Item("DefaultButtonClick").ToString.Trim = "Y" And p_RowArr(p_Count).Item("CFL").ToString.Trim = "Y" Then
                                p_AddColumnTypeButtonEditView1(p_TrueGrid, p_GridView, p_RowArr(p_Count).Item("COL_NAME").ToString.Trim)


                            End If



                        End If
                    End If
                Next


            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            p_XtraModuleObj.ModErrExceptionNew(Err.Number, ex.Message)
        End Try


    End Sub

    Public Sub GridNavigatorButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        Dim p_DesError As String = ""
        If e.Handled = True Then Exit Sub
        Dim p_Control As DevExpress.XtraGrid.GridControlNavigator
        Dim p_TrueGrid As U_TextBox.U_TrueDBGrid
        Dim p_SQL As String = ""
        Dim p_Table As String = ""
        Dim p_ColumnKey As String = ""
        Dim p_FieldType As String = ""
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim p_DataRow As DataRow
        Dim p_dataTbl As DataTable
        Dim p_BindingSource As System.Windows.Forms.BindingSource

        Dim p_Desc As String = ""
        'If e.Handled = False Then Exit Sub

        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            'e.Handled = True
            p_Control = sender
            p_TrueGrid = CType(p_Control.Parent, U_TextBox.U_TrueDBGrid)
            If p_TrueGrid.DefaultRemove = False Then Exit Sub
            If p_XtraModuleObj.ShowMessage(Me,
                                       "MS0002",
                    "Bạn có chắc chắn muốn thực hiện không?",
                    True,
                    "Có",
                    True,
                    "Không",
                     False,
                    "",
                   2) = Windows.Forms.DialogResult.No Then
                e.Handled = True
                Exit Sub
            End If
            Try

                p_Table = p_TrueGrid.TableName.ToString.Trim
                p_ColumnKey = p_TrueGrid.ColumnKey.ToString.Trim
                p_FieldType = p_TrueGrid.ColumnKeyType.ToString.Trim
                p_GridView = p_TrueGrid.Views(0)
                If p_GridView.FocusedRowHandle >= 0 Then

                    p_DataRow = p_GridView.GetDataRow(p_GridView.FocusedRowHandle)
                    If (p_FieldType = "N" Or p_FieldType = "C") And p_ColumnKey <> "" And p_Table <> "" Then

                        p_BindingSource = p_TrueGrid.DataSource
                        p_dataTbl = CType(p_BindingSource.DataSource, DataTable)
                        If p_DataRow.Item(p_ColumnKey).ToString.Trim <> "" Then
                            If p_FieldType = "N" Then
                                p_SQL = "DELETE FROM " & p_Table & " WHERE " & p_ColumnKey & "=" & p_DataRow.Item(p_ColumnKey)
                            Else
                                p_SQL = "DELETE FROM " & p_Table & " WHERE " & p_ColumnKey & "='" & p_DataRow.Item(p_ColumnKey) & "'"
                            End If
                            p_DataRow = Nothing

                            p_DataRow = pv_LineRemove.NewRow
                            p_DataRow.Item(0) = p_SQL
                            pv_LineRemove.Rows.Add(p_DataRow)
                            p_dataTbl.Rows.RemoveAt(p_GridView.FocusedRowHandle)
                        Else
                            p_dataTbl.Rows.RemoveAt(p_GridView.FocusedRowHandle)
                        End If

                        If Me.FormStatus = False Then
                            Dim p_ButtonSave() As Object
                            p_ButtonSave = Me.Controls.Find(Me.ButtonSave, True)
                            Me.FormStatus = True
                            If p_ButtonSave.Length > 0 Then
                                p_ButtonSave(0).text = Me.CaptionUpd
                            End If

                        End If

                        e.Handled = True
                        p_TrueGrid.Refresh()

                        'If g_XtraServicesObj.Sys_Execute(p_SQL, p_Desc) = False Then
                        '    p_XtraModuleObj.ModErrExceptionNew("", p_Desc)
                        '    e.Handled = True
                        '    Exit Sub
                        'End If
                    Else
                        p_XtraModuleObj.ModErrExceptionNew("MS0003", "")
                        e.Handled = True
                        Exit Sub
                    End If
                End If
            Catch ex As Exception
                p_XtraModuleObj.ModErrExceptionNew(Err.Number, ex.Message)
                e.Handled = True
                Exit Sub
            End Try

        End If

    End Sub


    Private Sub GridView_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 'Handles GridView1.KeyPress
        If e.Handled = False Then
            g_ValueType = 2
        End If
        'Try
        '    If 
        'Catch ex As Exception

        'End Try
    End Sub


    Private Sub p_AddColumnTypeButtonEditView1(ByRef p_TrueGird As U_TextBox.U_TrueDBGrid,
                                       ByRef p_GridView As DevExpress.XtraGrid.Views.Grid.GridView,
                                       ByVal p_ColumnIndex As String)
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        Dim p_DesError As String = ""
        Try
            p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
            p_TrueGird.RepositoryItems.Add(p_ColType)
            p_GridView.Columns(p_ColumnIndex).ColumnEdit = p_ColType
            AddHandler p_ColType.ButtonClick, AddressOf Gridview_Column_Button_Click
        Catch ex As Exception
            p_XtraModuleObj.ModErrExceptionNew(Err.Number, ex.Message)
        End Try
    End Sub

   
    Private Sub GridView_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) 'Handles GridView1.CellValueChanged
        'Not e.Column.ColumnEdit Is Nothing And 
        If (g_ValueType = 2) Then
            ' If Not e.Column.ColumnEdit Is Nothing Then
            Dim p_Form As Object
            ' Dim p_ButtonEdit As DevExpress.XtraEditors.ButtonEdit
            Dim p_OldValue As String = ""
            Dim p_NewValue As String = ""
            Dim p_DataTable As DataTable
            Dim p_SQL As String = ""
            Dim p_Field As String = ""
            Dim p_Exist As Boolean = False
            Dim p_ButtonArr() As Object
            Dim p_ButtonOK As Object = Nothing
            Dim p_ItemBtn As String = ""
            Dim p_TrueGrid As U_TextBox.U_TrueDBGrid
            Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
            Dim p_Count As Integer
            'Dim p_DataRow As DataRow
            Dim p_RowHandle As Integer
            Dim p_ColumnName As String = ""
            Dim p_DataArr() As DataRow

            Dim p_ColumnInt As Boolean = False
            Dim dt As New DataTable
            Dim p_BindingSourceTmp As New System.Windows.Forms.BindingSource
            Dim p_DataRow As DataRow
            Dim p_CellValue As String
            ' Dim p_DataCheck As DataTable
            Try
                If p_XtraDataSet_TrueGird Is Nothing Then Exit Sub
                If Me.FormLock = True Then Exit Sub
                If e.Valid = False Then Exit Sub
                p_GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
                p_TrueGrid = p_GridView.GridControl

                p_RowHandle = p_GridView.FocusedRowHandle
                p_ColumnName = p_GridView.FocusedColumn.Name
                p_RowHandle = p_GridView.FocusedRowHandle
                If UCase(p_ColumnName) = UCase(p_TrueGrid.ColumnKey) Then
                    ' p_FieldName = p_GridView.FocusedColumn.FieldName

                    p_DataRow = p_GridView.GetDataRow(p_RowHandle)
                    If p_TrueGrid.ColumnKey.ToString.Trim <> "" And p_DataRow.Item("CHECKUPD").ToString.Trim = "I" Then
                        Try
                            p_CellValue = e.Value   ' p_DataRow.Item(p_TrueGrid.ColumnKey).ToString
                        Catch ex As Exception
                            p_DataTable = Nothing
                            p_XtraModuleObj.ErrException(Err.Number, ex.Message)
                            Exit Sub
                        End Try

                        If p_CellValue.ToString.Trim <> "" Then
                            If p_TrueGrid.ColumnKeyType = "N" Then
                                'p_RowsCheck = p_DataCheck.Select(p_ColumnKey & "=" & p_CellValue)
                                p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_TrueGrid.TableName & " Where " & p_TrueGrid.ColumnKey & "=" & p_CellValue & "'"
                            Else
                                p_SQL = "Exec FPT_Execute_Select 'Select 1 from " & p_TrueGrid.TableName & " Where " & p_TrueGrid.ColumnKey & "=''" & p_CellValue & "'''"
                            End If
                            dt = g_XtraServicesObj.mod_SYS_GET_DATATABLE(p_SQL)
                            If dt.Rows.Count > 0 Then
                                'p_Insert = 2
                                ' If p_DataRow.Item("CHECKUPD").ToString.Trim = "I" Then
                                'e.Valid = False
                                'p_GridView.CancelUpdateCurrentRow()

                                p_GridView.ClearColumnsFilter()
                                'p_XtraModuleObj.ModErrException("MS0001", "Bản ghi đã tồn tại")
                                e.ErrorText = p_CellValue & "- Đã tồn tại trong hệ thống"
                                e.Valid = False
                                dt = Nothing
                                Exit Sub
                                'End If
                            End If
                        End If
                    End If
                End If
                If p_ColumnName <> "CHECKUPD" Then
                    Me.FormStatus = True

                    Try
                        p_ItemBtn = Me.ButtonSave
                    Catch ex As Exception

                    End Try
                    If p_ItemBtn.ToString.Trim <> "" Then
                        p_ButtonArr = Me.Controls.Find(p_ItemBtn, True)
                        If Not p_ButtonArr Is Nothing Then
                            p_ButtonOK = p_ButtonArr(0)
                            p_ButtonOK.Text = Me.CaptionUpd
                        End If
                    End If
                    p_DataRow = p_GridView.GetDataRow(p_RowHandle)
                    If Not p_DataRow Is Nothing Then
                        If Not p_DataRow.Item("CHECKUPD") Is Nothing Then
                            If p_DataRow.Item("CHECKUPD").ToString.Trim <> "I" And p_DataRow.Item("CHECKUPD").ToString.Trim <> "Y" Then
                                p_GridView.SetRowCellValue(p_RowHandle, "CHECKUPD", "Y")
                            End If
                        End If
                    End If



                End If

                If p_GridView.Columns(p_ColumnName).ColumnEdit Is Nothing Then Exit Sub
                Try
                    p_DataArr = p_XtraDataSet_TrueGird.Tables(0).Select("FORM_NAME='" & Me.Name & "' and GRID_NAME='" & p_TrueGrid.Name & "' and COL_NAME='" & p_ColumnName & "'")
                Catch ex As Exception
                    Exit Sub
                End Try

                If p_DataArr Is Nothing Then Exit Sub
                If p_DataArr.Length <= 0 Then Exit Sub


                If e.Value.ToString.Trim = "" Then

                    p_BindingSourceTmp = p_GridView.DataSource
                    dt = CType(p_BindingSourceTmp.DataSource, DataTable)


                    For p_Count = 1 To 4
                        p_ColumnName = p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                        If p_ColumnName <> "" Then
                            If UCase(dt.Columns.Item(p_ColumnName).DataType.Name) = "STRING" Then
                                dt.Rows(p_RowHandle).Item(p_ColumnName) = vbNullString
                            Else
                                dt.Rows(p_RowHandle).Item(p_ColumnName) = 0
                            End If
                        End If
                    Next
                End If
                p_SQL = p_DataArr(0).Item("CFLSQL").ToString.Trim

                If p_SQL = "" Then Exit Sub

                Dim p_ValueCheck As String


                p_ValueCheck = e.Value.ToString.Trim
                p_SQL = p_XtraModuleObj.Parameter_Item(Me, p_SQL)
                If p_ValueCheck = "" Then Exit Sub
                If UCase(p_GridView.Columns(p_ColumnName).ColumnType.Name.ToString.Trim) <> "STRING" Then
                    p_ColumnInt = True
                End If
                If p_ColumnInt = True Then
                    p_SQL = "SELECT * FROM (" & p_SQL & ") ABC WHERE " & p_DataArr(0).Item("CFLKeyField").ToString.Trim & "=" & p_ValueCheck
                Else
                    p_SQL = "SELECT * FROM (" & p_SQL & ") ABC WHERE " & p_DataArr(0).Item("CFLKeyField").ToString.Trim & "='" & p_ValueCheck & "'"
                End If

                p_DataTable = g_XtraServicesObj.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)



                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        p_Exist = True
                    End If
                End If

                If p_Exist = True Then   ''Da co trong he thong danh muc

                    p_BindingSourceTmp = p_GridView.DataSource
                    If p_RowHandle < 0 Then
                        p_GridView.UpdateCurrentRow()
                        p_RowHandle = p_GridView.FocusedRowHandle
                    End If
                    dt = CType(p_BindingSourceTmp.DataSource, DataTable)

                    If dt.Rows.Count > 0 Then
                        dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(0).ToString.Trim
                        For p_Count = 1 To 4
                            p_ColumnName = p_DataArr(0).Item("CFLReturn" & p_Count).ToString.Trim
                            If p_ColumnName <> "" Then
                                dt.Rows(p_RowHandle).Item(p_ColumnName) = p_DataTable.Rows(0).Item(p_Count).ToString.Trim
                            End If
                        Next

                    End If
                Else    'Chua co trong danh muc
                    ' MsgBox("Giá tri không hợp lệ")
                    e.ErrorText = "Giá tri không hợp lệ"
                    e.Valid = False
                    Exit Sub
                    'Try
                    '    p_ItemBtn = Me.ButtonSave
                    'Catch ex As Exception

                    'End Try
                    'If p_ItemBtn.ToString.Trim <> "" Then
                    '    p_ButtonArr = Me.Controls.Find(p_ItemBtn, True)
                    '    If Not p_ButtonArr Is Nothing Then
                    '        p_ButtonOK = p_ButtonArr(0)
                    '    End If
                    'End If

                    ''If p_GridView.FocusedRowHandle < 0 Then
                    ''    p_GridView.AddNewRow()
                    ''End If

                    'p_XtraModuleObj.p_ModGridview_Column_Button_Click(p_TrueGrid, _
                    '                                   p_GridView, _
                    '                                    Me, _
                    '                            Me.FormStatus, _
                    '                             p_ButtonOK, _
                    '                             p_ColumnName,
                    '                             p_XtraDataSet_TrueGird, "", False)
                    'If g_ChooseRecordFromSearch = False Then
                    '    ' p_SQL = e.Value.ToString.Trim
                    '    ' p_GridView.CancelUpdateCurrentRow()
                    '    e.Valid = False
                    '    ' e.Value = p_SQL
                    '    Exit Sub
                    'End If

                End If
                g_ValueType = 0
                '  Exit Sub


            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) ' Handles GridView1.InitNewRow
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
        Try
            p_GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            p_GridView.SetRowCellValue(p_GridView.FocusedRowHandle, "CHECKUPD", "I")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Gridview_Column_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Private Sub Gridview_Column_Button_Click(ByRef p_TrueGrid As Object, _
        '                                                  ByRef p_GridView As Object, _
        '                                           ByVal p_ColumnName As String, _
        '                                            Optional ByVal p_StrSQL As String = "")
        Dim p_TrueGrid As U_TextBox.U_TrueDBGrid
        Dim p_GridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim p_ButtonArr() As Object
        Dim p_ButtonOK As Object = Nothing
        Dim p_ItemBtn As String = ""
        Dim p_ColumnName As String
        Dim p_ButtonEdit As DevExpress.XtraEditors.ButtonEdit
        Dim p_StrSQL As String = ""
        Try
            p_ItemBtn = Me.ButtonSave
        Catch ex As Exception

        End Try
        If p_ItemBtn.ToString.Trim <> "" Then
            p_ButtonArr = Me.Controls.Find(p_ItemBtn, True)
            If Not p_ButtonArr Is Nothing Then
                p_ButtonOK = p_ButtonArr(0)
            End If
        End If
        p_ButtonEdit = CType(sender, DevExpress.XtraEditors.ButtonEdit)
        p_TrueGrid = CType(p_ButtonEdit.Parent, U_TextBox.U_TrueDBGrid)
        p_GridView = p_TrueGrid.Views(0)
        p_ColumnName = p_GridView.FocusedColumn.FieldName
        If p_GridView.Columns.Item(p_ColumnName).OptionsColumn.ReadOnly = True Then Exit Sub
        If p_GridView.FocusedRowHandle < 0 Then
            p_GridView.AddNewRow()
        End If
        p_XtraModuleObj.p_ModGridview_Column_Button_Click(p_TrueGrid, _
                                                       p_GridView, _
                                                        Me, _
                                                Me.FormStatus, _
                                                 p_ButtonOK, _
                                                 p_ColumnName,
                                                 p_XtraDataSet_TrueGird, p_StrSQL, False)
        If g_ChooseRecordFromSearch = True Then
            g_ValueType = 1
        End If

    End Sub


    ' Private Sub GridView_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) 'Handles GridView1.MouseMove
    Private Sub GridView1_FocusedColumnChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs)


        Dim p_Table_Name As String = ""
        Dim p_Field_Name As String = ""
        Dim p_View_Name As String = ""
        Dim p_Form As Object 'System.Windows.Forms.Form
        Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView
        Dim p_TrueGrid As U_TextBox.U_TrueDBGrid

        GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        p_TrueGrid = GridView.GridControl

        p_Table_Name = p_TrueGrid.TableName
        'p_Field_Name = Me.FieldName
        p_View_Name = p_TrueGrid.ViewName
        p_Form = FindForm()

        Try
            If Not p_Form.p_XtraToolTripLabel Is Nothing Then
                ' Me.ToolTip = "NAME(" & Me.Name & ") VIEW(" & p_View_Name & ") TAB(" & p_Table_Name & ") FIELD (" & p_Field_Name & ")"
                ' Try
                p_Form.p_XtraToolTripLabel.Text = " Name(" & p_TrueGrid.Name & ") View(" & p_View_Name & ") Table(" & p_Table_Name & ") Col (" & GridView.FocusedColumn.Name & ")"
                '        Catch ex As Exception

                'End Try

            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub UnlockObjectIsNull()
        Dim p_Count As Integer
        Dim p_ControlArr() As Object
        For p_Count = 0 To 100
            If Not g_ObjectUpdateIsNull(p_Count) Is Nothing Then
                If g_ObjectUpdateIsNull(p_Count).ToString.Trim <> "" Then
                    p_ControlArr = Me.Controls.Find(g_ObjectUpdateIsNull(p_Count).ToString.Trim, True)
                    If p_ControlArr.Length > 0 Then
                        p_ControlArr(0).BackColor = g_ObjectUpdateIsNullColor(p_Count)
                        p_ControlArr(0).Properties.ReadOnly = False
                    End If
                End If
            End If
        Next
    End Sub

    Public Sub LockObjectIsNull()
        Dim p_Count As Integer
        Dim p_ControlArr() As Object
        For p_Count = 0 To 100
            If Not g_ObjectUpdateIsNull(p_Count) Is Nothing Then
                If g_ObjectUpdateIsNull(p_Count).ToString.Trim <> "" Then
                    p_ControlArr = Me.Controls.Find(g_ObjectUpdateIsNull(p_Count).ToString.Trim, True)
                    If p_ControlArr.Length > 0 Then
                        p_ControlArr(0).BackColor = pv_Locked_Back_Color
                        p_ControlArr(0).Properties.ReadOnly = True
                    End If
                End If
            End If
        Next
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class