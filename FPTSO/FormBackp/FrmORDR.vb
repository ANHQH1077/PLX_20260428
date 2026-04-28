Public Class FrmORDR
    Private p_BindingSourceHeader As New System.Windows.Forms.BindingSource
    Private p_BindingSourceLine As New System.Windows.Forms.BindingSource  'Line 
    Private p_BindingSourceLine1 As New System.Windows.Forms.BindingSource  'Line shop
    Private p_ComboboxObj(0 To 30) As String   ''Array Object chua cac Item la ComboBox
    Private p_ComboboxValue(0 To 30) As String  'Array Object chua cac itemma Combobox lay Value

    Private p_CheckBoxObj(0 To 30) As String   ''Array Object chua cac Item la CheckBox
    Private p_CheckBoxValue(0 To 30) As String  'Array Object chua cac itemma CheckBox lay Value
    'Private p_BindingSource() As System.Windows.Forms.BindingSource
    Private p_DBDataSet As New DataSet
    Private p_TableLine As String
    Public pv_Header_Status As String
    Private p_Next As String = "NEXT"
    Private p_Prev As String = "PREV"
    Private p_First As String = "FIRST"
    Private p_Last As String = "LAST"
    Private p_Commit As Boolean

    ' Private p_CaptionUpd As String = "&Lưu"
    ' Private p_CaptionAdd As String = "&Thêm mới"

    Private pv_DEL_KEY As String = "DELETE"
    Private pv_INS_KEY As String = "INSERT"
    Private pv_UPD_KEY As String = "UPDATE"
    Private pv_Save_KEY As String = "SAVE"
    'Private p_Commit As Boolean
    Private p_BindingNavigator_ID As Integer

    'Private p_TrueGirdLineAdd(0 To 2000) As Boolean  'Dung mảng để lưu các line number trong TrueGrid khi thêm bản ghi
    'Private p_TrueGirdLineUpd(0 To 2000) As Boolean  'Dung mảng để lưu các line number trong TrueGrid khi update bản ghi
    'Private p_TrueGirdLineDel(0 To 2000) As String   'Dung mảng để lưu gia tri trong TrueGrid khi delete bản ghi


    'Private p_TrueGirdLineAdd2(0 To 2000) As Boolean  'Dung mảng để lưu các line number trong TrueGrid khi thêm bản ghi
    'Private p_TrueGirdLineUpd2(0 To 2000) As Boolean  'Dung mảng để lưu các line number trong TrueGrid khi update bản ghi
    'Private p_TrueGirdLineDel2(0 To 2000) As String   'Dung mảng để lưu gia tri trong TrueGrid khi delete bản ghi
    '=====================================================

    Private p_PageNum As Integer = 1  'Dung rieng cho form nay
    Private p_SQLWHere As String = "" 'Dung rieng cho form nay
    Private p_LineOfPage As Integer = 500 'Dung rieng cho form nay

    Private p_PageTotal As Integer = 1



    Public p_DocEntry As Integer = 0
    Public p_Addnew As Boolean = False

    Private p_GridViewUpdateValue As Boolean = False

    'Private Sub FrmORDR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    'End Sub
    'Private p_FormEdit As Boolean
    'Public Property FormEdit() As Boolean
    '    Get
    '        Return p_FormEdit
    '    End Get
    '    Set(ByVal value As Boolean)
    '        p_FormEdit = value
    '    End Set

    'End Property



    Private Sub FrmORDR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        ' Dim ctrl As Control = Me.GetChildAtPoint(Me.Cursor.HotSpot) '.Name  ' New Point(Me.Cursor.Position.X, Me.Cursor.Position.Y))
        'If e.KeyChar = Convert.ToChar(13) Then Exit Sub
        'If Not Me.U_Status.EditValue Is Nothing Then
        '    If Me.U_Status.EditValue.ToString.Trim <> "" Then
        '        If Me.U_Status.EditValue <> 1 Then
        '            e.Handled = True
        '            Exit Sub
        '        End If
        '    End If
        'End If


        ' p_ChangFormStatus()

        ' End If
    End Sub





    Sub p_ChangFormStatus()
        If pv_Header_Status <> pv_INS_KEY Then
            pv_Header_Status = pv_UPD_KEY
            p_Commit = True
            Me.btnOK.Text = p_CaptionUpd
        End If
    End Sub

    Private Sub FrmORDR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_Where As String
        Dim p_Page_Total As Integer
        Dim p_FptModule As New FPTModule.Class1(g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName, g_CurrencyDtl, g_Currency)
        Dim p_Count As Integer
        'Dim p_ChekcForm As U_TextBox.Class1
        '  Me.Controls
        Me.ButtonSave = Me.btnOK.Name.Trim  'Gan ten cua button luu thong tin vao bien



        Me.U_UserLogin.EditValue = g_User_ID
        Me.ComCodeKey.EditValue = g_Company_Code

        If p_DocEntry > 0 Then
            p_Where = " WHERE  DocEntry=" & p_DocEntry
            p_Addnew = False
        Else
            p_Where = " WHERE 1=0"
            p_Addnew = True
        End If


        p_PageNum = 1
        'If p_Addnew = True Then



        ' End If
        Try
            If p_FptModule.p_Mod_Set_BindSource_ForForm(p_DataSet_TrueGird, True, Me, "[FPTORDR]", p_BindingSourceHeader, "[FPTORDR]", "DocNum", p_Page_Total, False, p_Where, 1000, p_PageNum) = False Then
                MsgBox("Lỗi khi mở đơn hàng")
            Else
                'Line
                'If p_FptModule.p_Mod_Set_TrueGrid_Property(Me, p_DataSet_TrueGird, p_BindingSourceLine, _
                '                                            Me.U_TrueDBGrid1, Me.GridView1, False, False, "") = False Then
                '    'GoTo Line_Err
                '    MsgBox("Lỗi khi thực hiện")
                'Else
                SetColunmEditForView()
                'End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        p_ComboboxAddValue_Fix(p_FptModule, p_Addnew)
        
        
        If p_Addnew = True Then
            p_GetDefaultFormValue()

        End If

        'Active control in tabpage
        For p_Count = Me.XtraTabControl1.TabPages.Count - 1 To 0 Step -1
            Me.XtraTabControl1.SelectedTabPageIndex = p_Count
        Next
        If p_DocEntry > 0 Then
            If p_FptModule.ModSetTrueGridEditColumn(False, Me.U_TrueDBGrid1, Me.GridView1, p_DataSet_TrueGird, Me.Name.Trim, False) = False Then
                Me.btnOK.Enabled = False
            End If
        End If
        AddHandler U_TrueDBGrid1.EmbeddedNavigator.ButtonClick, AddressOf TrueDBGrid1_DataNavigator1_ButtonClick


        'If p_FptModule.p_ModControl_UpdateIfNull(Me, False) = False Then
        '    MsgBox("Lỗi khi thực hiện")
        'End If


        p_FptModule = Nothing
    End Sub


    Sub TrueDBGrid1_DataNavigator1_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs)
        If e.Button.ButtonType = DevExpress.XtraEditors.NavigatorButtonType.Remove Then
            'If MsgBox("Bạn có chắc chắn muốn xóa không?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
            '    e.Handled = True
            'End If
        End If
    End Sub

    'Private Sub p_FillCurrency()

    'End Sub

    Private Sub p_GetDefaultFormValue()
        Dim p_SysDate As Date
        Dim p_SysTime As Integer
        On Error Resume Next


        Me.U_ShpCod.ItemIndex = 0

        Me.U_BusLin.ItemIndex = 0
        p_GetDateTime(p_SysDate, p_SysTime)

        Me.U_AcDate.EditValue = p_SysDate
        Me.U_DateDe.EditValue = p_SysDate
        Me.U_CrDate.EditValue = p_SysDate
        Me.U_DocTime.EditValue = p_SysTime

        Me.U_SOType.ItemIndex = 0
        Me.U_BusLin.ItemIndex = 0
        Me.U_Status.ItemIndex = 0

        'Me.U_ReveRe.Checked = False
        'Me.U_StsRet.Checked = False
        'Me.U_Inv3rd.Checked = False
    End Sub


    Private Sub p_ComboboxAddValue_Fix(ByVal p_Module As Object, Optional ByVal p_Default As Boolean = False)
        On Error Resume Next

        Dim p_Count As Integer
        'For p_Count = 0 To g_CurrencyDtl.Rows.Count - 1
        '    p_Module.p_ModComboboxAddValue(Me.U_DocCur, g_CurrencyDtl.Rows(p_Count).Item(0), g_CurrencyDtl.Rows(p_Count).Item(0))
        'Next
        If p_Default = True Then
            Me.U_DocCur.EditValue = g_Currency
        End If

        'U_Status
        p_Module.p_ModComboboxAddValue(Me.U_Status, "1", "Mở")
        p_Module.p_ModComboboxAddValue(Me.U_Status, "2", "Hủy")
        p_Module.p_ModComboboxAddValue(Me.U_Status, "3", "Đóng")
        p_Module.p_ModComboboxAddValue(Me.U_Status, "4", "Đã đẩy API")
        p_Module.p_ModComboboxAddValue(Me.U_Status, "5", "Đang thực hiện hoàn tất")
        If p_Default = True Then
            Me.U_Status.ItemIndex = 0
        End If
        'U_ItmOut1
        p_Module.p_ModComboboxAddValue(Me.U_ItmOut1, "Y", "Xuất hàng")
        p_Module.p_ModComboboxAddValue(Me.U_ItmOut1, "N", "Chưa xuất hàng")
        If p_Default = True Then
            Me.U_ItmOut1.ItemIndex = 0
        End If
        'U_Cmoney
        'p_Module.p_ModComboboxAddValue(Me.U_Cmoney, "N", "Chưa thu tiền")
        'p_Module.p_ModComboboxAddValue(Me.U_Cmoney, "Y", "Đã thu tiền")
        'If p_Default = True Then
        '    Me.U_Cmoney.ItemIndex = 0
        'End If
        ''U_DMoney
        'p_Module.p_ModComboboxAddValue(Me.U_DMoney, "N", "Không đặt cọc")
        'p_Module.p_ModComboboxAddValue(Me.U_DMoney, "Y", "Có đặt cọc")
        'If p_Default = True Then
        '    Me.U_DMoney.ItemIndex = 0
        'End If
        'U_SOType
        p_Module.p_ModComboboxAddValue(Me.U_SOType, "1", "Thu tiền ngay")
        p_Module.p_ModComboboxAddValue(Me.U_SOType, "2", "Bán nợ")
        p_Module.p_ModComboboxAddValue(Me.U_SOType, "3", "Đặtcọc")
        p_Module.p_ModComboboxAddValue(Me.U_SOType, "4", "Đặt hàng")
        p_Module.p_ModComboboxAddValue(Me.U_SOType, "99", "Xuất nội bộ")
        If p_Default = True Then
            Me.U_SOType.ItemIndex = 0
        End If
    End Sub

    Private Sub U_ShpCod_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles U_ShpCod.EditValueChanged
        Dim p_FptModule As New FPTModule.Class1(g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName)
        If Me.U_ShpCod.EditValue.ToString.Trim = "" Then
            Me.U_ShpCod.ItemIndex = 0
        End If
        If p_FptModule.p_ModFilComboboxParent(Me, Me.U_ShpCod, False) = False Then

        End If

        Me.U_SlpTmp.EditValue = ""
        p_FptModule = Nothing
    End Sub






    'Private Sub U_CrdCod_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
    '    p_Edit_Button_Click(Me.Code, Me, p_Commit, pv_Header_Status, Me.btnOK, pv_UPD_KEY)
    'End Sub



    Private Sub U_CrdCod_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SimpleButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton13.Click
        Dim p_Form As New FrmBP
        p_Form.p_Code = Me.Code
        p_Form.p_CardName = Me.U_CrdName
        p_Form.ShowDialog(Me)
        'p_Form.Show(Me)
    End Sub



    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim p_Desc As String

       
        If Me.FormStatus = False Then
            Dim p_FptMod As New FPTModule.Class1(g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName, g_CurrencyDtl, g_Currency)
            p_BindingSourceHeader.AddNew()

            If p_FptMod.p_Mod_Set_TrueGrid_Property(Me, p_DataSet_TrueGird, p_BindingSourceLine, _
                                                            Me.U_TrueDBGrid1, Me.GridView1, False, True, "") = False Then

                MsgBox("Lỗi khi thực hiện")


            End If

            p_GetDefaultFormValue()

            Me.btnOK.Text = p_CaptionUpd

            Me.Code.Focus()
            p_FptMod = Nothing
            Exit Sub
        End If

        If CheckApprovedData(Me, p_Desc) Then
            MsgBox(p_Desc)
            Exit Sub
        End If
        p_UpdateToDatabase()

        'Dim p_Err As String = ""
        'If p_FptModule.p_ModGirdViewCheckRequiredBeforUpdate(p_DataSet_TrueGird, Me.Name, Me.U_TrueDBGrid1, Me.GridView1, p_Err) = False Then
        '    MsgBox(p_Err)
        'End If
        'p_FptModule = Nothing
    End Sub



    Sub p_UpdateToDatabase()
        Dim p_DataTable As DataTable
        Dim p_Header_Ins As Boolean
        Dim p_FptMod As New FPTModule.Class1(g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName, g_CurrencyDtl, g_Currency)
        Dim p_SQL As String = ""

        p_Header_Ins = False
        If Me.FormStatus = True Then
            If g_Company_Code.ToString.Trim <> "" Then
                Me.U_ComCode.EditValue = g_Company_Code
            End If

            p_DataTable = p_FptMod.p_ModCompileControlHeaderToSQL(p_DataSet_TrueGird, True, Me, "FPTORDR", Me.DocEntry, "FPTORDR_S", Me.DocNum, "FPTORDR_S", g_UserName)
            If p_DataTable Is Nothing Then
                Exit Sub
            End If

            'p_SQL = p_FptMod.p_ModCompileTrueDBGirdLineToSQL(True, Me.U_TrueDBGrid1,
            '                              Me.GridView1,
            '                              Me.DocEntry,
            '                              p_DataTable,
            '                              False, g_UserName)

            'If p_SQL <> "TRUE" Then
            '    MsgBox(p_SQL)
            '    Exit Sub
            'End If
            'Exit Sub

            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    If g_Services.Sys_Execute_DataTbl(p_DataTable, p_SQL) = False Then
                        MsgBox(p_SQL)
                        Exit Sub
                    End If
                Else
                    MsgBox("Không xác định được dữ liệu cần cập nhật")
                    Exit Sub
                End If
            Else
                MsgBox("Không xác định được dữ liệu cần cập nhật")
                Exit Sub
            End If


            'If p_FptMod.SetTrueGridPropertyNew(ByVal p_DataSet_TrueGird As DataSet, ByRef p_Form As Form) (p_DataSet_TrueGird, True, Me, "[FPTORDR]", p_BindingSourceHeader, "[FPTORDR]", "DocNum", 1, False, "", 1000, p_PageNum) = False Then

            'End If
            pv_Header_Status = ""
            'p_Commit = False
            Me.FormStatus = False
            Me.btnOK.Text = p_CaptionAdd

            If p_FptMod.ModSetTrueGridPropertyNew(p_DataSet_TrueGird, Me, True) Then

            End If
            p_FptMod = Nothing
        End If
    End Sub




    Private Sub U_DocCur_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.U_DocCur.EditValue = g_Currency Then
                Me.U_DocRat.Enabled = False
                Me.U_DocRat.EditValue = 1
            Else
                Me.U_DocRat.Enabled = True
                Me.U_DocRat.EditValue = p_GetExchangeRate(Me.U_AcDate.EditValue, Me.U_DocCur.EditValue)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim p_PriceList As Integer = 0
        Dim p_Date As Date = CDate("1980/01/01")
        Dim p_TIme As Integer = 0
        Dim p_ShpCode As String = ""

        'Dim p_DataTable As DataTable
        Try
            ' Me.
            'Dim p_Binding As BindingSource
            'p_Binding = Me.U_TrueDBGrid1.DataSource
            'p_DataTable = CType(p_Binding.DataSource, DataTable)
            If e.Column.FieldName <> "CheckUpd" Then
                Me.GridView1.SetRowCellValue(e.RowHandle, "CheckUpd", "Y")
            End If
            If (e.Column.FieldName = "U_ItmCod" Or e.Column.FieldName = "U_WhsCod" Or e.Column.FieldName = "U_Qutity" Or e.Column.FieldName = "U_Imei") And p_GridViewUpdateValue = False Then
                p_GridViewUpdateValue = True
                'If e.RowHandle < 0 Then
                '    Me.GridView1.UpdateCurrentRow()

                'End If
                If Not Me.U_ShpCod.EditValue Is Nothing Then
                    p_ShpCode = Me.U_ShpCod.EditValue
                End If



                If Not Me.U_PriLis.EditValue Is Nothing Then
                    p_PriceList = Me.U_PriLis.EditValue
                End If

                'If Me.U_CrDate.EditValue Is Nothing Then
                '    Me.XtraTabControl1.TabPages(1).Select()
                'End If
                If Not Me.U_CrDate.EditValue Is Nothing Then
                    p_Date = Me.U_CrDate.EditValue
                End If

                If Not Me.U_DocTime.EditValue Is Nothing Then
                    p_TIme = Me.U_DocTime.EditValue
                End If

                SetDefaultLine(e.RowHandle, p_ShpCode, p_PriceList, p_Date, p_TIme)
                p_GridViewUpdateValue = False
            End If
            If (e.Column.FieldName = "U_DisOther" Or e.Column.FieldName = "U_DisAmo" Or e.Column.FieldName = "U_AmountO") And p_GridViewUpdateValue = False Then
                p_GridViewUpdateValue = True
                SetTotalLineBeforTax(e.RowHandle)
                p_GridViewUpdateValue = False
            End If

        Catch ex As Exception
            p_GridViewUpdateValue = False
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub GridView1_InitNewRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GridView1.InitNewRow

    End Sub



    Private Sub GridView1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GridView1.KeyPress
        p_ChangFormStatus()
    End Sub


    Private Sub GridView1_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridView1.ShowingEditor

    End Sub

    Private Sub GridView1_ShownEditor(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.ShownEditor
        'Dim p_FptModule As New FPTModule.Class1(g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName, g_CurrencyDtl, g_Currency)
        'Dim p_Err As String = ""
        'If p_FptModule.p_ModGirdViewCheckRequiredBeforUpdate(p_DataSet_TrueGird, Me.Name, Me.U_TrueDBGrid1, Me.GridView1, p_Err, False) = False Then
        '    MsgBox(p_Err)
        'End If
        'p_FptModule = Nothing
    End Sub

    Private Sub AccReToTal_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles AccReToTal.ButtonClick
        p_Edit_Button_Click(Me.AccReToTal, Me, p_Commit, pv_Header_Status, Me.btnOK, pv_UPD_KEY)
    End Sub



    Private Sub AccDownPay_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles AccDownPay.ButtonClick
        p_Edit_Button_Click(Me.AccDownPay, Me, p_Commit, pv_Header_Status, Me.btnOK, pv_UPD_KEY)
    End Sub



    Private Sub U_DownAcTran_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles U_DownAcTran.ButtonClick
        p_Edit_Button_Click(Me.U_DownAcTran, Me, p_Commit, pv_Header_Status, Me.btnOK, pv_UPD_KEY)
    End Sub



    Private Sub U_ReAcTran_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles U_ReAcTran.ButtonClick
        p_Edit_Button_Click(Me.U_ReAcTran, Me, p_Commit, pv_Header_Status, Me.btnOK, pv_UPD_KEY)
    End Sub





    Private Sub SetColunmEditForView()
        Dim p_Count As Integer
        Dim p_RowArr() As DataRow

        Try
            If p_DataSet_TrueGird.Tables.Count > 0 Then
                p_RowArr = p_DataSet_TrueGird.Tables(0).Select("FORM_NAME='" & UCase(Me.Name) & _
                                                         "' AND GRID_NAME='" & Me.U_TrueDBGrid1.Name & "' and CFL='Y' ")
                For p_Count = 0 To p_RowArr.Length - 1
                    p_AddColumnTypeButtonEditView1(U_TrueDBGrid1, Me.GridView1, p_RowArr(p_Count).Item("COL_NAME").ToString.Trim)
                Next

                p_RowArr = p_DataSet_TrueGird.Tables(0).Select("FORM_NAME='" & UCase(Me.Name) & _
                                                         "' AND GRID_NAME='" & Me.U_TrueDBGrid2.Name & "' and CFL='Y' ")
                For p_Count = 0 To p_RowArr.Length - 1
                    p_AddColumnTypeButtonEditView1(U_TrueDBGrid2, Me.GridView2, p_RowArr(p_Count).Item("COL_NAME").ToString.Trim)
                Next

                p_RowArr = p_DataSet_TrueGird.Tables(0).Select("FORM_NAME='" & UCase(Me.Name) & _
                                                         "' AND GRID_NAME='" & Me.U_TrueDBGrid3.Name & "' and CFL='Y' ")
                For p_Count = 0 To p_RowArr.Length - 1
                    p_AddColumnTypeButtonEditView1(U_TrueDBGrid3, Me.GridView3, p_RowArr(p_Count).Item("COL_NAME").ToString.Trim)
                Next

                p_RowArr = p_DataSet_TrueGird.Tables(0).Select("FORM_NAME='" & UCase(Me.Name) & _
                                                         "' AND GRID_NAME='" & Me.U_TrueDBGrid4.Name & "' and CFL='Y' ")
                For p_Count = 0 To p_RowArr.Length - 1
                    p_AddColumnTypeButtonEditView1(U_TrueDBGrid4, Me.GridView4, p_RowArr(p_Count).Item("COL_NAME").ToString.Trim)
                Next

                p_RowArr = p_DataSet_TrueGird.Tables(0).Select("FORM_NAME='" & UCase(Me.Name) & _
                                                         "' AND GRID_NAME='" & Me.U_TrueDBGrid5.Name & "' and CFL='Y' ")
                For p_Count = 0 To p_RowArr.Length - 1
                    p_AddColumnTypeButtonEditView1(U_TrueDBGrid5, Me.GridView5, p_RowArr(p_Count).Item("COL_NAME").ToString.Trim)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


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
            Select Case UCase(p_TrueGird.Name)
                Case UCase("U_TrueDBGrid1")
                    AddHandler p_ColType.ButtonClick, AddressOf Gridview1_Column_Button_Click
                Case ""
                Case ""
                Case ""
            End Select


            ' p_GridView.Columns("").
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Gridview1_Column_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_ColumnName As String
        Dim p_datarow As DataRow
        Dim p_FptModule As New FPTModule.Class1(g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName)
        Try
            p_ColumnName = Me.GridView1.FocusedColumn.FieldName
            If Me.GridView1.Columns.Item(p_ColumnName).OptionsColumn.ReadOnly = True Then
                If UCase(p_ColumnName.ToString.Trim) <> UCase("U_Imei") Then Exit Sub
            End If
            If UCase(p_ColumnName.ToString.Trim) = UCase("U_Imei") Then
                Dim p_Form As New FrmORDRSerial
                p_datarow = GridView1.GetFocusedDataRow

                If Not p_datarow Is Nothing Then
                    If p_datarow.Item("ID").ToString.Trim <> "" Then
                        p_Form.SOLineID = p_datarow.Item("ID")
                        Double.TryParse(p_datarow.Item("DocEntry").ToString.Trim, p_Form.SODocEntry)

                        p_Form.SOShopCode = Me.U_ShpCod.EditValue
                        p_Form.SOItemCode = p_datarow.Item("U_ItmCod").ToString.Trim
                        p_Form.SOIWhsCode = p_datarow.Item("U_WhsCod").ToString.Trim
                        Integer.TryParse(p_datarow.Item("U_Qutity").ToString.Trim, p_Form.SOQuantity)


                        p_Form.ShowDialog(Me)
                    Else
                        MsgBox("Không xác định được sản phẩm")
                        Exit Sub
                    End If
                End If
            Else
                p_FptModule.p_ModGridview_Column_Button_Click(U_TrueDBGrid1, _
                                                   GridView1, _
                                                    Me, _
                                            p_Commit, _
                                             pv_Header_Status, _
                                             Me.btnOK, _
                                             pv_UPD_KEY, _
                                             p_ColumnName,
                                             p_DataSet_TrueGird)
            End If


            p_FptModule = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        
    End Sub

    Sub p_Edit_Button_Click(ByVal p_Item As U_TextBox.U_ButtonEdit, _
                                        ByRef p_RptForm As System.Windows.Forms.Form, _
                                        ByRef p_Commit1 As Boolean, _
                                        ByRef pv_Header_Status1 As String, _
                                        ByRef p_ButtonOK As Object, _
                                        ByVal pv_UPD_KEY1 As String)
        Dim p_FptModule As New FPTModule.Class1(g_Services, g_UsrB1, g_PassB1, g_Port, g_Company_Host, g_Company_DBName)
        p_FptModule.p_Mod_Edit_Button_Click(p_Item, p_RptForm, p_Commit1, pv_Header_Status1, p_ButtonOK, pv_UPD_KEY1, p_CaptionUpd)
        p_FptModule = Nothing
    End Sub



    Private Sub Code_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles Code.ButtonClick
        p_Edit_Button_Click(Me.Code, Me, p_Commit, pv_Header_Status, Me.btnOK, pv_UPD_KEY)
    End Sub


    Private Sub U_SlpTmp_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_SlpTmp.EditValueChanged

    End Sub

    Private Sub U_SlpTmp_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles U_SlpTmp.EditValueChanging

    End Sub

    Private Sub U_SlpTmp_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles U_SlpTmp.Validated

    End Sub

    Private Sub U_SlpTmp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles U_SlpTmp.Validating
        If Not Me.U_SlpTmp.EditValue Is Nothing Then
            If Me.U_SlpTmp.EditValue.ToString.Trim <> "" Then
                Try
                    Me.U_EplCod.EditValue = Me.U_SlpTmp.EditValue.ToString.Trim
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub





    'Private Sub FrmORDR_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    '    Dim ctrl As Control = Me.GetChildAtPoint(New Point(e.X + 1, e.Y + 1))



    '    Dim p_Str As String
    '    Dim p_Control As Object
    '    On Error Resume Next
    '    p_Control = ctrl


    '    ' g_ToolStripStatus.Text = "X=" & e.X & "; Y=" & e.Y
    '    If Not p_Control Is Nothing Then
    '        If Not g_ToolStripStatus Is Nothing Then
    '            'g_ToolStripStatus.Text = ctrl.Name
    '            p_Str = "Name:" & ctrl.Name

    '            If InStr(UCase(p_Control.GetType.ToString), UCase("U_TextBox."), CompareMethod.Text) > 0 Then
    '                p_Str = p_Str & " Table:" & p_Control.ViewName
    '                p_Str = p_Str & " Field:" & p_Control.FieldName
    '                p_Str = p_Str & " Value:" & p_Control.editValue.ToString.Trim
    '            End If
    '            g_ToolStripStatus.Text = p_Str
    '        End If
    '    End If
    '    'If TypeOf ctrl Is U_TextBox.U_TextBox Then
    '    '    'CType(ctrl, TextBox).Text = "Coordinates X: " & e.X & " Y: " & e.Y
    '    '    'MsgBox(ctrl.Name)

    '    'End If
    'End Sub


    Private Sub SetDefaultLine(ByVal p_RowHandle As Integer, ByVal p_ShpCode As String, ByVal p_PriceList As Integer, ByVal p_Date As Date, ByVal p_Time As Integer)
        Try
            Dim p_SQL As String
            Dim p_dataRow As DataRow
            Dim p_DataTable As DataTable
            Dim p_Des As String
            Dim p_Quantity As Double
            Dim p_QuantityDoc As Double = 0
            Dim p_Serial As String = ""

            Dim dt As New DataTable
            Dim p_BindingSourceTmp As New BindingSource
            p_BindingSourceTmp = GridView1.DataSource
            If p_RowHandle < 0 Then
                GridView1.UpdateCurrentRow()
                p_RowHandle = Me.GridView1.FocusedRowHandle
            End If
            dt = CType(p_BindingSourceTmp.DataSource, DataTable)

            If dt.Rows.Count <= 0 Then Exit Sub
            ' p_dataRow = Me.GridView1.GetDataRow(p_RowHandle)
            '
            Double.TryParse(dt.Rows(p_RowHandle).Item("U_Qutity").ToString.Trim, p_QuantityDoc)
           

            'If Not p_dataRow Is Nothing Then
            'p_SQL = "exec FPT_GetDefaultLine '" & p_ShpCode.Trim & "','" & p_dataRow.Item("U_ItmCod").ToString.Trim & "'," & p_PriceList & _
            '            ",'" & p_dataRow.Item("U_WhsCod").ToString.Trim & "' ,'" & p_Date.ToString("yyyyMMdd") & "'," & p_Time

            p_SQL = "exec FPT_GetDefaultLine '" & p_ShpCode.Trim & "','" & dt.Rows(p_RowHandle).Item("U_ItmCod").ToString.Trim & "'" & _
                ",'" & dt.Rows(p_RowHandle).Item("U_Imei").ToString.Trim & "'," & p_QuantityDoc & "," & p_PriceList & _
                       ",'" & dt.Rows(p_RowHandle).Item("U_WhsCod").ToString.Trim & "' ,'" & p_Date.ToString("yyyyMMdd") & "'," & p_Time

            p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Des)
            If p_Des <> "" Then
                MsgBox(p_Des)
                Exit Sub
            End If
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    If p_DataTable.Rows(0).Item("Note").ToString.Trim <> "" Then
                        MsgBox(p_DataTable.Rows(0).Item("Note").ToString.Trim)
                        'Exit Sub
                    End If
                    'select ItemCode, ItemName, VatGourpSa, 0 as  ItemPrice, ISNULL(@WhsCode,@DefaultWhs) as WhsCode, 0 as Onhand

                    'If p_RowHandle < 0 Then
                    '    dt.Rows(dt.Rows.Count - 1).Item("U_ItmName") = p_DataTable.Rows(0).Item("ItemName").ToString.Trim
                    '    dt.Rows(dt.Rows.Count - 1).Item("U_Tax") = p_DataTable.Rows(0).Item("VatGourpSa").ToString.Trim
                    '    dt.Rows(dt.Rows.Count - 1).Item("U_TaxRate") = p_DataTable.Rows(0).Item("VatRate").ToString.Trim
                    '    dt.Rows(dt.Rows.Count - 1).Item("U_Price") = p_DataTable.Rows(0).Item("ItemPrice").ToString.Trim
                    '    dt.Rows(dt.Rows.Count - 1).Item("U_ItemPri") = p_DataTable.Rows(0).Item("ItemPrice").ToString.Trim
                    '    dt.Rows(dt.Rows.Count - 1).Item("U_WhsCod") = p_DataTable.Rows(0).Item("WhsCode").ToString.Trim

                    '    Double.TryParse(p_DataTable.Rows(0).Item("Onhand").ToString.Trim, p_Quantity)

                    '    dt.Rows(dt.Rows.Count - 1).Item("U_OnHand") = p_Quantity
                    '    dt.Rows(dt.Rows.Count - 1).Item("U_Qutity") = p_DataTable.Rows(0).Item("Quantity").ToString.Trim
                    'Else
                    dt.Rows(p_RowHandle).Item("U_ItmName") = p_DataTable.Rows(0).Item("ItemName").ToString.Trim
                    dt.Rows(p_RowHandle).Item("U_Tax") = p_DataTable.Rows(0).Item("VatGourpSa").ToString.Trim
                    dt.Rows(p_RowHandle).Item("U_TaxRate") = p_DataTable.Rows(0).Item("VatRate").ToString.Trim
                    dt.Rows(p_RowHandle).Item("U_Price") = p_DataTable.Rows(0).Item("ItemPrice").ToString.Trim
                    dt.Rows(p_RowHandle).Item("U_ItemPri") = p_DataTable.Rows(0).Item("ItemPrice").ToString.Trim
                    dt.Rows(p_RowHandle).Item("U_WhsCod") = p_DataTable.Rows(0).Item("WhsCode").ToString.Trim
                    dt.Rows(p_RowHandle).Item("U_DateWarr") = p_DataTable.Rows(0).Item("U_TGBH").ToString.Trim
                    '
                    Double.TryParse(p_DataTable.Rows(0).Item("Onhand").ToString.Trim, p_Quantity)

                    dt.Rows(p_RowHandle).Item("U_OnHand") = p_Quantity
                    dt.Rows(p_RowHandle).Item("U_Qutity") = p_DataTable.Rows(0).Item("Quantity").ToString.Trim

                    ' End If

                    SetTotalLineBeforTaxDefaultLine(p_RowHandle, dt)

                    p_BindingSourceTmp.DataSource = dt
                    Me.U_TrueDBGrid1.DataSource = p_BindingSourceTmp
                    p_BindingSourceTmp.ResetBindings(True)
                    U_TrueDBGrid1.Refresh()

                    'Me.GridView1.SetRowCellValue(p_RowHandle, "U_ItmName", p_DataTable.Rows(0).Item("ItemName").ToString.Trim)
                    'Me.GridView1.SetRowCellValue(p_RowHandle, "U_Tax", p_DataTable.Rows(0).Item("VatGourpSa").ToString.Trim)
                    'Me.GridView1.SetRowCellValue(p_RowHandle, "U_TaxRate", p_DataTable.Rows(0).Item("VatRate").ToString.Trim)
                    'Me.GridView1.SetRowCellValue(p_RowHandle, "U_Price", p_DataTable.Rows(0).Item("ItemPrice").ToString.Trim)
                    'Me.GridView1.SetRowCellValue(p_RowHandle, "U_ItemPri", p_DataTable.Rows(0).Item("ItemPrice").ToString.Trim)
                    'Me.GridView1.SetRowCellValue(p_RowHandle, "U_WhsCod", p_DataTable.Rows(0).Item("WhsCode").ToString.Trim)
                    'Double.TryParse(p_DataTable.Rows(0).Item("Onhand").ToString.Trim, p_Quantity)
                    'Me.GridView1.SetRowCellValue(p_RowHandle, "U_OnHand", p_Quantity)
                    'Me.GridView1.SetRowCellValue(p_RowHandle, "U_Qutity", p_DataTable.Rows(0).Item("Quantity").ToString.Trim)
                    ''
                    'SetTotalLineBeforTax(p_RowHandle)
                End If
            End If
            'End If

            'Dim item As DevExpress.XtraGrid.GridColumnSummaryItem

            'item.FieldName = "U_TMoney"
            SetTotalDocument()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub SetTotalLineBeforTaxDefaultLine(ByVal p_RowHandle As Integer, ByRef p_DataTable As DataTable)
        Dim p_dataRow As DataRow
        Dim p_TotalBefore As Double = 0   'Tong tien chua thua sau khi tru chiet khau
        Dim p_Total As Double = 0  '=SL*Don gia
        Dim p_TaxAmount As Double = 0
        Dim p_DisProAmount As Double = 0
        Dim p_DisOAmount As Double = 0
        Dim p_Quantity As Double = 0
        Dim p_Price As Integer = 0
        Dim p_Count As Integer
        Try

            p_dataRow = p_DataTable.Rows(p_RowHandle) 'Me.GridView1.GetDataRow(p_RowHandle)
            If Not p_dataRow Is Nothing Then
                If p_dataRow.Item("U_Qutity").ToString <> "" Then
                    p_Quantity = p_dataRow.Item("U_Qutity").ToString
                End If

                If p_dataRow.Item("U_Price").ToString <> "" Then
                    p_Price = p_dataRow.Item("U_Price").ToString
                End If
                p_Total = p_Quantity * CDbl(p_Price)


                If p_dataRow.Item("U_DisPro").ToString <> "" Then  'Chiet khau KM
                    p_DisProAmount = p_dataRow.Item("U_DisPro").ToString
                    p_DisProAmount = (p_DisProAmount / 100) * p_Total
                End If

                If p_dataRow.Item("U_DisAmo").ToString <> "" Then   'Giam gia KM
                    p_DisProAmount = p_DisProAmount + p_dataRow.Item("U_DisAmo").ToString
                End If

                If p_dataRow.Item("U_DisOther").ToString <> "" Then  'Chiet khau Khac
                    p_DisOAmount = p_dataRow.Item("U_DisOther").ToString
                    p_DisOAmount = (p_DisOAmount / 100) * p_Total
                End If
                If p_dataRow.Item("U_AmountO").ToString <> "" Then  'giam gia khac
                    p_DisOAmount = p_DisOAmount + p_dataRow.Item("U_AmountO").ToString
                End If


                p_TotalBefore = p_Total - (p_DisProAmount + p_DisOAmount) 'Tong tien truoc thue sau khi tru di chiet khau

                If p_dataRow.Item("U_TaxRate").ToString <> "" Then
                    p_TaxAmount = p_TotalBefore * p_dataRow.Item("U_TaxRate").ToString
                Else
                    p_TaxAmount = p_TotalBefore
                End If
                '
                p_DataTable.Rows(p_RowHandle).Item("U_TTLine") = p_TotalBefore 'Tong tien truoc thue sau khi tru di chiet khau
                p_DataTable.Rows(p_RowHandle).Item("U_TaxAmL") = p_Total 'SL*don gia
                p_DataTable.Rows(p_RowHandle).Item("U_TaxAmo") = p_TaxAmount 'Tien thue
                p_DataTable.Rows(p_RowHandle).Item("U_TMoney") = p_TaxAmount + p_TotalBefore 'Tien sau thue
                'Me.GridView1.SetRowCellValue(p_RowHandle, "U_TTLine", p_TotalBefore)    'Tong tien truoc thue sau khi tru di chiet khau
                'Me.GridView1.SetRowCellValue(p_RowHandle, "U_TaxAmL", p_Total)    'SL*don gia
                'Me.GridView1.SetRowCellValue(p_RowHandle, "U_TaxAmo", p_TaxAmount)  'Tien thue
                'Me.GridView1.SetRowCellValue(p_RowHandle, "U_TMoney", p_TaxAmount + p_TotalBefore)  'Tien sau thue
                'Me.GridView1.UpdateCurrentRow()
                'Me.GridView1.RefreshData()
                'GridView1.UpdateTotalSummary()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub SetTotalLineBeforTax(ByVal p_RowHandle As Integer)
        Dim p_dataRow As DataRow
        Dim p_TotalBefore As Double = 0   'Tong tien chua thua sau khi tru chiet khau
        Dim p_Total As Double = 0  '=SL*Don gia
        Dim p_TaxAmount As Double = 0
        Dim p_DisProAmount As Double = 0
        Dim p_DisOAmount As Double = 0
        Dim p_Quantity As Double = 0
        Dim p_Price As Integer = 0
        Dim p_Count As Integer
        Try

            p_dataRow = Me.GridView1.GetDataRow(p_RowHandle)
            If Not p_dataRow Is Nothing Then
                If p_dataRow.Item("U_Qutity").ToString <> "" Then
                    p_Quantity = p_dataRow.Item("U_Qutity").ToString
                End If

                If p_dataRow.Item("U_Price").ToString <> "" Then
                    p_Price = p_dataRow.Item("U_Price").ToString
                End If
                p_Total = p_Quantity * CDbl(p_Price)


                If p_dataRow.Item("U_DisPro").ToString <> "" Then  'Chiet khau KM
                    p_DisProAmount = p_dataRow.Item("U_DisPro").ToString
                    p_DisProAmount = (p_DisProAmount / 100) * p_Total
                End If

                If p_dataRow.Item("U_DisAmo").ToString <> "" Then   'Giam gia KM
                    p_DisProAmount = p_DisProAmount + p_dataRow.Item("U_DisAmo").ToString
                End If

                If p_dataRow.Item("U_DisOther").ToString <> "" Then  'Chiet khau Khac
                    p_DisOAmount = p_dataRow.Item("U_DisOther").ToString
                    p_DisOAmount = (p_DisOAmount / 100) * p_Total
                End If
                If p_dataRow.Item("U_AmountO").ToString <> "" Then  'giam gia khac
                    p_DisOAmount = p_DisOAmount + p_dataRow.Item("U_AmountO").ToString
                End If


                p_TotalBefore = p_Total - (p_DisProAmount + p_DisOAmount) 'Tong tien truoc thue sau khi tru di chiet khau

                If p_dataRow.Item("U_TaxRate").ToString <> "" Then
                    p_TaxAmount = p_TotalBefore * p_dataRow.Item("U_TaxRate").ToString
                Else
                    p_TaxAmount = p_TotalBefore
                End If
                '
                Me.GridView1.SetRowCellValue(p_RowHandle, "U_TTLine", p_TotalBefore)    'Tong tien truoc thue sau khi tru di chiet khau
                Me.GridView1.SetRowCellValue(p_RowHandle, "U_TaxAmL", p_Total)    'SL*don gia
                Me.GridView1.SetRowCellValue(p_RowHandle, "U_TaxAmo", p_TaxAmount)  'Tien thue
                Me.GridView1.SetRowCellValue(p_RowHandle, "U_TMoney", p_TaxAmount + p_TotalBefore)  'Tien sau thue
                Me.GridView1.UpdateCurrentRow()
                Me.GridView1.RefreshData()
                GridView1.UpdateTotalSummary()

            End If
            SetTotalDocument()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SetTotalDocument()
        Dim p_TotalBefore As Double = 0   'Tong tien chua thua sau khi tru chiet khau
        ' Dim p_Total As Double = 0  '=SL*Don gia
        Dim p_TaxAmount As Double = 0
        Dim p_DisOAmount As Double = 0
        Dim p_Count As Integer
        Dim p_DownPay As Double = 0

        'Dim p_TotalCol As DevExpress.XtraGrid.Columns.GridColumn = Me.GridView1.Columns.Item("U_TaxAmL")   'DonGias*SL
        Dim p_TotalBeforeCol As DevExpress.XtraGrid.Columns.GridColumn = Me.GridView1.Columns.Item("U_TTLine")   ''Tong tien truoc thue sau khi tru di chiet khau
        Dim p_TaxAmountCol As DevExpress.XtraGrid.Columns.GridColumn = Me.GridView1.Columns.Item("U_TaxAmo")   ''Tien thue

        For p_Count = 0 To Me.GridView1.RowCount
            If Me.GridView1.IsDataRow(p_Count) Then
                'p_Total = p_Total + Me.GridView1.GetRowCellValue(p_Count, p_TotalCol).ToString

                If Me.GridView1.GetRowCellValue(p_Count, p_TotalBeforeCol).ToString <> "" Then
                    p_TotalBefore = p_TotalBefore + Me.GridView1.GetRowCellValue(p_Count, p_TotalBeforeCol).ToString
                End If
                If Me.GridView1.GetRowCellValue(p_Count, p_TaxAmountCol).ToString <> "" Then
                    p_TaxAmount = p_TaxAmount + Me.GridView1.GetRowCellValue(p_Count, p_TaxAmountCol).ToString
                End If


            End If
        Next
        If Not Me.U_DownPay.EditValue Is Nothing Then
            Double.TryParse(Me.U_DownPay.EditValue.ToString, p_DownPay)
        End If
        Me.U_TMonPr.EditValue = p_TotalBefore
        Me.U_TMonTX.EditValue = p_TaxAmount
        Me.U_TmonBi.EditValue = (p_TotalBefore + p_TaxAmount) - p_DownPay
    End Sub

    'Cap nhat tong so tien tra truoc
    Private Function GetTotalDownPayment() As Boolean
        Dim p_DownAmount As Double = 0
        Dim p_DownAmountTmp As Double = 0
        Dim p_Count As Integer
        Dim p_DataRow As DataRow
        GetTotalDownPayment = True
        Try
            If Not Me.MDownPay.EditValue Is Nothing Then
                Double.TryParse(Me.MDownPay.EditValue.ToString.Trim, p_DownAmountTmp)
                p_DownAmount = p_DownAmount + p_DownAmountTmp
            End If

            If Not Me.U_DownMoTran.EditValue Is Nothing Then
                Double.TryParse(Me.U_DownMoTran.EditValue.ToString.Trim, p_DownAmountTmp)
                p_DownAmount = p_DownAmount + p_DownAmountTmp
            End If

            ''Voucher
            With GridView3
                For p_Count = 0 To .RowCount - 1
                    If .IsDataRow(p_Count) Then
                        p_DataRow = .GetDataRow(p_Count)
                        If Not p_DataRow Is Nothing Then
                            Double.TryParse(p_DataRow.Item("U_MonPay").ToString.Trim, p_DownAmountTmp)
                            p_DownAmount = p_DownAmount + p_DownAmountTmp
                        End If
                    End If
                Next
            End With

            ''Credit
            With GridView2
                For p_Count = 0 To .RowCount - 1
                    If .IsDataRow(p_Count) Then
                        p_DataRow = .GetDataRow(p_Count)
                        If Not p_DataRow Is Nothing Then
                            Double.TryParse(p_DataRow.Item("U_Money").ToString.Trim, p_DownAmountTmp)
                            p_DownAmount = p_DownAmount + p_DownAmountTmp
                        End If
                    End If
                Next
            End With

            Me.U_DownPay.EditValue = p_DownAmount
            SetTotalDocument()
        Catch ex As Exception
            MsgBox(ex.Message)
            GetTotalDownPayment = False
        End Try
    End Function


    'Kiem tra so tien thanh toan voi gia tri don hang
    Private Function CheckTotalPayment() As Boolean
        Dim p_DownAmount As Double = 0
        Dim p_DownAmountTmp As Double = 0
        Dim p_Count As Integer
        Dim p_DataRow As DataRow
        CheckTotalPayment = True
        Try
            If Not Me.MReToTal.EditValue Is Nothing Then
                Double.TryParse(Me.MReToTal.EditValue.ToString.Trim, p_DownAmountTmp)
                p_DownAmount = p_DownAmount + p_DownAmountTmp
            End If

            If Not Me.U_ReMoTran.EditValue Is Nothing Then
                Double.TryParse(Me.U_ReMoTran.EditValue.ToString.Trim, p_DownAmountTmp)
                p_DownAmount = p_DownAmount + p_DownAmountTmp
            End If

            ''Voucher
            With GridView4
                For p_Count = 0 To .RowCount - 1
                    If .IsDataRow(p_Count) Then
                        p_DataRow = .GetDataRow(p_Count)
                        If Not p_DataRow Is Nothing Then
                            Double.TryParse(p_DataRow.Item("U_MonPay").ToString.Trim, p_DownAmountTmp)
                            p_DownAmount = p_DownAmount + p_DownAmountTmp
                        End If
                    End If
                Next
            End With

            ''Credit
            With GridView5
                For p_Count = 0 To .RowCount - 1
                    If .IsDataRow(p_Count) Then
                        p_DataRow = .GetDataRow(p_Count)
                        If Not p_DataRow Is Nothing Then
                            Double.TryParse(p_DataRow.Item("U_Money").ToString.Trim, p_DownAmountTmp)
                            p_DownAmount = p_DownAmount + p_DownAmountTmp
                        End If
                    End If
                Next
            End With

            p_DownAmountTmp = 0
            If Not Me.U_TmonBi.EditValue Is Nothing Then
                p_DownAmountTmp = Me.U_TmonBi.EditValue
            End If
            If p_DownAmountTmp < p_DownAmount Then
                MsgBox("Số tiền thanh toán phải nhỏ hơn hoặc bằng Tổng tiền đơn hàng")
                CheckTotalPayment = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            CheckTotalPayment = False
        End Try
    End Function

    Private Sub MDownPay_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles MDownPay.EditValueChanging
        'GetTotalDownPayment()
    End Sub

    Private Sub U_DownMoTran_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles U_DownMoTran.EditValueChanging

    End Sub

    Private Sub MDownPay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MDownPay.Validating
        GetTotalDownPayment()
    End Sub

    Private Sub U_DownMoTran_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles U_DownMoTran.Validating
        GetTotalDownPayment()
    End Sub

    Private Sub GridView3_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView3.CellValueChanged
        If e.Column.FieldName <> "CheckUpd" Then
            Me.GridView1.SetRowCellValue(e.RowHandle, "CheckUpd", "Y")
        End If
        If UCase(e.Column.FieldName) = UCase("U_MonPay") Then
            Me.GridView3.UpdateCurrentRow()
            GetTotalDownPayment()
        End If
    End Sub

    Private Sub GridView2_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        If e.Column.FieldName <> "CheckUpd" Then
            Me.GridView1.SetRowCellValue(e.RowHandle, "CheckUpd", "Y")
        End If
        If UCase(e.Column.FieldName) = UCase("U_Money") Then
            Me.GridView2.UpdateCurrentRow()
            GetTotalDownPayment()
        End If
    End Sub

    Private Sub MDownPay_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MDownPay.EditValueChanged

    End Sub

    Private Sub MReToTal_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MReToTal.EditValueChanged

    End Sub

    Private Sub MReToTal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MReToTal.Validating
        CheckTotalPayment()
    End Sub
    Private Sub U_ReMoTran_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles U_ReMoTran.Validating
        CheckTotalPayment()
    End Sub

    Private Sub GridView4_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView4.CellValueChanged
        If e.Column.FieldName <> "CheckUpd" Then
            Me.GridView1.SetRowCellValue(e.RowHandle, "CheckUpd", "Y")
        End If
        If UCase(e.Column.FieldName) = UCase("U_MonPay") Then
            Me.GridView4.UpdateCurrentRow()
            CheckTotalPayment()
        End If
    End Sub

    Private Sub GridView5_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView5.CellValueChanged
        If e.Column.FieldName <> "CheckUpd" Then
            Me.GridView1.SetRowCellValue(e.RowHandle, "CheckUpd", "Y")
        End If
        If UCase(e.Column.FieldName) = UCase("U_Money") Then
            Me.GridView5.UpdateCurrentRow()
            CheckTotalPayment()
        End If
    End Sub

    Private Sub FrmORDR_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        If CheckTotalPayment() = False Then
            Exit Sub
        End If
        If Not Me.U_Status.EditValue Is Nothing Then
            If Me.U_Status.EditValue = 1 Or Me.U_Status.EditValue.ToString.Trim = "" Then
                Me.U_Status.EditValue = 5
            End If
            If Me.U_Status.EditValue = 2 Then
                MsgBox("Đơn hàng đã bị hủy")
                Exit Sub
            End If
        Else
            Me.U_Status.EditValue = 5
        End If

    End Sub



    Private Sub U_Inv3rd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_Inv3rd.CheckedChanged

    End Sub

    Private Sub U_Inv3rd_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles U_Inv3rd.Validated

    End Sub

   
End Class