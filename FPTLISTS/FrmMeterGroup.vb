Imports DevExpress.XtraGrid.Menu
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils.Menu
Public Class FrmMeterGroup

    Private p_TYTRONG_PTANG As Boolean = False

    Public p_SQLWHere As String

    'Private Sub SaveRecord()
    '    Dim p_DataTable As DataTable
    '    Dim p_Binding As U_TextBox.U_BindingSource
    '    Dim p_ArrRow() As DataRow
    '    Dim p_DataRow As DataRow
    '    Dim p_Count As Integer
    '    Dim p_HangHoa As String = ""
    '    Dim p_BeXuat As String = ""
    '    Dim p_SQL As String

    '    Dim p_DateTime As DateTime = Now

    '    p_GetCurrentDate(p_DateTime)

    '    Dim p_IDLine As Integer
    '    Dim p_FDate, p_TDate, p_FDateNhomBe, p_TDateNhomBe As DateTime
    '    Dim p_MeterId, p_Tank, p_TankGroup As String

    '    Try

    '        Me.GridView1.MoveNext()
    '    Catch ex As Exception

    '    End Try
    '    For p_Count = Me.GridView1.RowCount - 1 To 0 Step -1
    '        p_DataRow = Me.GridView1.GetDataRow(p_Count)
    '        If Not p_DataRow Is Nothing Then
    '            If p_DataRow.Item("Meterid").ToString.Trim = "" Then
    '                Continue For
    '            End If
    '            p_MeterId = p_DataRow.Item("Meterid").ToString.Trim
    '            p_Tank = p_DataRow.Item("BeXuat").ToString.Trim
    '            p_TankGroup = p_DataRow.Item("TankGroup").ToString.Trim
    '            'Integer.TryParse(p_DataRow.Item("IDLINE").ToString.Trim, p_IDLine)


    '            DateTime.TryParse(p_DataRow.Item("Valid_from").ToString.Trim, p_FDate)
    '            DateTime.TryParse(p_DataRow.Item("Valid_to").ToString.Trim, p_TDate)
    '            DateTime.TryParse(p_DataRow.Item("TankValidfrom").ToString.Trim, p_FDateNhomBe)
    '            DateTime.TryParse(p_DataRow.Item("TankValid_to").ToString.Trim, p_TDateNhomBe)
    '            If (p_FDate) >= (p_FDateNhomBe) And (p_TDate) <= (p_TDateNhomBe) Then
    '                p_SQL = "CongTo_NhomBe_Kiemtra '" & p_MeterId & "','" & p_FDate & "','" & p_TDate & "','" & p_Tank & "','" & p_TankGroup & "','" & p_FDateNhomBe & "','" & p_TDateNhomBe & "'"
    '                p_DataTable = GetDataTable(p_SQL, p_SQL)
    '                If Not p_DataTable Is Nothing Then
    '                    If p_DataTable.Rows.Count > 0 Then
    '                        If p_DataTable.Rows(0).Item(0) > 0 Then
    '                            ShowMessageBox("", p_DataTable.Rows(0).Item(1).ToString)
    '                            '  e.ErrorText = "DSFSFS"
    '                            Exit Sub
    '                        Else

    '                            ShowMessageBox("", p_DataTable.Rows(0).Item(1).ToString)
    '                        End If
    '                    End If
    '                End If
    '            Else
    '                ShowMessageBox("", "Công tơ " & p_DataRow.Item("Meterid").ToString.Trim & " Ngày hiệu lực/Hết hiệu lực phải trong khoảng thời gian Hiệu lực/Hết hiệu lực nhóm bể")
    '                '  e.ErrorText = "DSFSFS"
    '                Exit Sub

    '            End If
    '        End If

    '    Next



    '    Me.DefaultSave = True
    '    Me.UpdateToDatabase(Me, "")
    '    Me.DefaultSave = False
    '    '   End If
    'End Sub


    Private Sub FrmMeter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress


        If Asc(e.KeyChar) = 19 Then
            ' SaveRecord()
        End If
    End Sub


    Private Sub FrmMeter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_Meter As String
        Dim p_WhereCol As String
        Dim p_Column As U_TextBox.GridColumn
        Dim p_DataRow() As DataRow
        Dim p_DataTable As DataTable




        Dim p_SQL As String = ""
        Dim p_sMeter As String = ""


        p_SQL = "select Name_nd as BeXuat  from tblTank where  1=0"

        p_sMeter = "select MeterId , ProductCode from tblMeter "
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

                    p_sMeter = p_sMeter & " where left(MeterId,LEN ('" & p_Meter & "')) like '" & p_Meter & "%'"

                    Me.GridView1.Where = "left(MeterId,LEN ('" & p_Meter & "')) like '" & p_Meter & "%'"
                End If
            End If
        Catch ex As Exception

        End Try


        Me.DefaultFormLoad = True
        Me.XtraForm1_Load()
        Me.DefaultFormLoad = True
        Me.GridView1.BestFitColumns()
        p_Column = Me.GridView1.Columns.Item("Bexuat")
        p_Column.SQLString = p_SQL

        p_Column = Me.GridView1.Columns.Item("MeterId")
        p_Column.SQLString = p_sMeter

        p_Column = Me.GridView1.Columns.Item("Bexuat")
        Dim p_ColTypeButtonEdit As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        p_ColTypeButtonEdit = p_Column.ColumnEdit
        AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click


        
    End Sub

    Public Sub Column_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_Column As New U_TextBox.GridColumn
        Dim p_WhereCol As String
        Dim p_ButtonEdit As New DevExpress.XtraEditors.ButtonEdit
        Dim p_SQL As String
     
        p_SQL = "select Name_nd as Bexuat,  TankGroup, Product_nd  as MaHangHoa , (select top 1 b1.TenHangHoa  from tblHangHoa  b1 where b1.MaHangHoa  = a.Product_nd ) TenHangHoa " & _
                ", a.FromDate  TankValidfrom,a.ToDate  TankValid_to from tblTankGroup a " & _
                " where getdate() >= isnull(a.FromDate ,getdate() -1)  and getdate() <= isnull(a.Todate,getdate()+1) " & _
                    " and Product_nd in (select ProductCode  from tblMeter   where MeterId  = :Column.MeterId )"
        If g_Filter_Terminal = True Then
            If g_Terminal <> "" Then
                p_WhereCol = " left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'"
                p_SQL = p_SQL & " and " & p_WhereCol
            End If
        End If
        p_Column = Me.GridView1.Columns.Item("Bexuat")
        p_Column.CFLReturn1 = "TankGroup"
        p_Column.CFLReturn2 = "MaHangHoa"
        p_Column.CFLReturn3 = "TenHangHoa"
        p_Column.CFLReturn4 = "TankValidfrom"
        p_Column.CFLReturn5 = "TankValid_to"
        p_Column.SQLString = p_SQL
        p_Column.ButtonClick = True
        Me.Gridview_Column_Button_Click(sender, e)
        p_Column.ButtonClick = False
    End Sub


    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim p_DataRow As DataRow
        'Dim p_HangHoa As String = ""
        'Dim p_BeXuat As String = ""
        'Dim p_SQL As String
        'Dim p_DataTable As DataTable
        'Dim p_String As String
        'Dim p_Column As U_TextBox.GridColumn
        'Dim p_DateTime As DateTime
        
        p_DataRow = Me.GridView1.GetFocusedDataRow
        If Not p_DataRow Is Nothing Then
            p_DataRow.Item("Push_TDH") = "N"
            p_DataRow.Item("Push_XTTD") = "N"


            p_DataRow.Item("User_Push_TDH") = ""
            p_DataRow.Item("User_Push_XTTD") = ""
        End If


       

        'p_Column = Me.GridView1.FocusedColumn


        '' p_GetCurrentDate(p_DateTime)
        ''  p_Column = e.Column
        'p_DataRow = GridView1.GetFocusedDataRow

        'If Not p_DataRow Is Nothing Then
        '    If UCase(p_Column.FieldView) <> UCase("FromDate") And GridView1.FocusedRowModified = True Then   'And (p_DataRow.RowState = DataRowState.Modified Or p_DataRow.RowState = DataRowState.Added) Then
        '        '   GridView1.FocusedColumn = Me.GridView1.Columns.Item("FromDate")
        '        p_GetCurrentDate(p_DateTime)
        '        p_DataRow.Item("FromDate") = p_DateTime
        '        'GridView1.UpdateCurrentRow()
        '        ' Me.GridView1.SetFocusedRowCellValue("FromDate", p_DateTime)
        '        'GridView1.FocusedColumn = p_Column
        '    End If
        'End If


        'Exit Sub

        'p_Column = e.Column
        'If UCase(p_Column.FieldView) = UCase("ProductCode") Or UCase(p_Column.FieldView) = UCase("Name_ND") Then


        '    p_DataRow = Me.GridView1.GetDataRow(e.RowHandle)
        '    If Not p_DataRow.Item("Name_ND") Is Nothing Then


        '        If p_DataRow.Item("Name_ND").ToString.Trim <> "" Then
        '            p_BeXuat = p_DataRow.Item("Name_ND").ToString.Trim
        '        End If
        '        If p_BeXuat = "" Then
        '            Exit Sub
        '        End If
        '        If p_DataRow.Item("ProductCode").ToString.Trim <> "" Then
        '            p_HangHoa = p_DataRow.Item("ProductCode").ToString.Trim
        '        End If
        '        p_SQL = "select 1 as Code_HH from tblTank where Name_nd='" & p_BeXuat & "' and  Product_nd='" & p_HangHoa & "'"
        '        p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        '        If p_DataTable Is Nothing Then
        '            ShowMessageBox("", "Hàng hóa và bể xuất không hợp lệ")
        '            '  e.Valid = False
        '            Me.GridView1.InvalidateRow(e.RowHandle)
        '            ''.RowHandle) = False

        '        ElseIf p_DataTable.Rows.Count <= 0 Then
        '            ShowMessageBox("", "Hàng hóa và bể xuất không hợp lệ")
        '            Me.GridView1.InvalidateRow(e.RowHandle)
        '            ''Me.GridView1.IsValidRowHandle(e.RowHandle) = False
        '            'e.Valid = False
        '        End If
        '    End If
        'ElseIf UCase(p_Column.FieldView) = UCase("MeterID") Then
        '    ' If UCase(GridView1.FocusedColumn.FieldName.ToString.Trim) = UCase("Name_nd") Then
        '    If g_Filter_Terminal = True Then
        '        If g_Terminal <> "" Then
        '            p_String = e.Value.ToString.Trim
        '            If Len(p_String) > 0 Then
        '                If Mid(p_String, 1, 1) <> g_Terminal Then
        '                    MsgBox("Giá trị mã kho không hợp lệ", MsgBoxStyle.Critical, "Thông báo")
        '                    Me.GridView1.InvalidateRow(e.RowHandle)
        '                    'e.Valid = False
        '                End If
        '            End If
        '        End If
        '    End If
        '    ' If
        'End If
    End Sub




    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        'SaveRecord()
    End Sub


    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging

    End Sub

    Private Sub GridView1_CustomColumnSort(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles GridView1.CustomColumnSort

    End Sub

    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
        Dim p_Grid As U_TextBox.GridView
        Dim p_Datarow As DataRow



        p_Grid = CType(sender, U_TextBox.GridView)

        p_Datarow = p_Grid.GetFocusedDataRow
    End Sub

   

    Private Sub GridView1_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor

        Dim p_DataRow As DataRow
        Dim p_FDate, p_TDate, p_FDateNhomBe, p_TDateNhomBe As DateTime

        Dim p_Grid As U_TextBox.GridView
        p_Grid = CType(sender, U_TextBox.GridView)

        If p_Grid.IsEditing = False Then
            Exit Sub

        End If
        If UCase(p_Grid.FocusedColumn.Name.ToString) = UCase("Valid_from") Or UCase(p_Grid.FocusedColumn.Name.ToString) = UCase("Valid_to") Then
            p_DataRow = Me.GridView1.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then
                If UCase(p_Grid.FocusedColumn.Name.ToString) = UCase("Valid_from") Then
                    p_FDate = e.Value
                Else
                    DateTime.TryParse(p_DataRow.Item("Valid_from").ToString.Trim, p_FDate)
                End If
                If UCase(p_Grid.FocusedColumn.Name.ToString) = UCase("Valid_to") Then
                    p_TDateNhomBe = e.Value
                Else
                    DateTime.TryParse(p_DataRow.Item("Valid_to").ToString.Trim, p_TDate)
                End If



                DateTime.TryParse(p_DataRow.Item("TankValidfrom").ToString.Trim, p_FDateNhomBe)
                DateTime.TryParse(p_DataRow.Item("TankValid_to").ToString.Trim, p_TDateNhomBe)

            
                'If p_FDate > p_TDate Then
                '    ShowMessageBox("", "Ngày hiệu lực phải nhỏ hơn Hết hiệu lực")

                '    e.Valid = False
                'End If
                If (p_FDate) >= (p_FDateNhomBe) And (p_TDate) <= (p_TDateNhomBe) Then

                Else
                    ShowMessageBox("", "Ngày hiệu lực/Hết hiệu lực phải trong khoảng thời gian Hiệu lực/Hết hiệu lực nhóm bể")

                    e.Valid = False

                End If
            End If

        End If
        
    End Sub

    Private Sub DayDuLieuTDH()
        Dim p_Count As Integer
        Dim p_Row, p_Row1 As DataRow
        Dim p_Id As Integer
        Dim p_SQL As String
        Dim p_Connecttion As String = ""
        Dim p_Table, p_DataTable1 As DataTable
        Dim p_Desc As String
        Dim p_Check As Boolean = False
        Dim p_TableName As String = "tblCongToNhomBe"

        p_DataTable1 = New DataTable
        p_DataTable1.Columns.Add("STR_SQL")
        p_SQL = "select ServerScada , UidScada , PwdScada , DatabaseScada  from tblmap_cp where  Client ='" & g_Terminal & "'  and upper( Status) =upper('out')"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                'p_Connecttion = p_Table.Rows(0).Item(0).ToString
                p_Connecttion = "Provider=SQLOLEDB;Data Source=" & p_Table.Rows(0).Item("ServerScada").ToString.Trim & ";Persist Security Info=True;User ID=" & _
                         p_Table.Rows(0).Item("UidScada").ToString.Trim & ";Password=" & p_Table.Rows(0).Item("PwdScada").ToString.Trim & _
                                ";Initial Catalog=" & p_Table.Rows(0).Item("DatabaseScada").ToString.Trim & ";Connect Timeout=300"
            End If
        End If
        If p_Connecttion = "" Then
            ShowStatusMessage(True, "", "Kết nối TĐH không xác định")
            Exit Sub
        End If
        If GridView1.IsLastRow = True Then
            Me.GridView1.MoveNext()
        End If
        GridView1.MoveLast()
        DayDuLieuTDH_XeTai(p_Connecttion)
        'Day du lieu xep tai
        DayDuLieu_XepTai()

        Me.DefaultFormLoad = True
        Me.XtraForm1_Load()
        Me.DefaultFormLoad = False

    End Sub

    Private Sub DayDuLieu_XepTai()
        Dim p_Count As Integer
        Dim p_Row, p_Row1 As DataRow
        Dim p_Id As Integer
        Dim p_SQL As String
        Dim p_Connecttion As String = ""
        Dim p_Table, p_DataTable1 As DataTable
        Dim p_Desc As String
        Dim p_Check As Boolean = False
        Dim p_TableName As String = "tblCongToNhomBe"
        Dim p_XEPTAI_DB, p_XEPTAI_IP, p_XEPTAI_PASS, p_XEPTAI_PORT, p_XEPTAI_USER As String

        p_XEPTAI_DB = ""
        p_XEPTAI_IP = ""
        p_XEPTAI_PASS = ""
        p_XEPTAI_PORT = ""
        p_XEPTAI_USER = ""

        p_DataTable1 = New DataTable
        p_DataTable1.Columns.Add("STR_SQL")
        p_SQL = "select keycode, keyvalue from sys_config  where keycode in ('XEPTAI_DB','XEPTAI_IP','XEPTAI_PASS','XEPTAI_PORT','XEPTAI_USER')"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                'p_Connecttion = p_Table.Rows(0).Item(0).ToString
                For p_Count = 0 To p_Table.Rows.Count - 1
                    If p_Table.Rows(p_Count).Item("keycode").ToString.Trim = "XEPTAI_DB" Then
                        p_XEPTAI_DB = p_Table.Rows(p_Count).Item("keyvalue").ToString.Trim
                    End If
                    If p_Table.Rows(p_Count).Item("keycode").ToString.Trim = "XEPTAI_IP" Then
                        p_XEPTAI_IP = p_Table.Rows(p_Count).Item("keyvalue").ToString.Trim
                    End If
                    If p_Table.Rows(p_Count).Item("keycode").ToString.Trim = "XEPTAI_PASS" Then
                        p_XEPTAI_PASS = p_Table.Rows(p_Count).Item("keyvalue").ToString.Trim
                    End If
                    If p_Table.Rows(p_Count).Item("keycode").ToString.Trim = "XEPTAI_PORT" Then
                        p_XEPTAI_PORT = p_Table.Rows(p_Count).Item("keyvalue").ToString.Trim
                    End If
                    If p_Table.Rows(p_Count).Item("keycode").ToString.Trim = "XEPTAI_USER" Then
                        p_XEPTAI_USER = p_Table.Rows(p_Count).Item("keyvalue").ToString.Trim
                    End If
                Next
            End If
        End If
        p_Connecttion = ""
        If p_XEPTAI_DB <> "" And p_XEPTAI_IP <> "" And p_XEPTAI_PASS <> "" And p_XEPTAI_PORT <> "" And p_XEPTAI_USER <> "" Then
            p_Connecttion = "Provider=SQLOLEDB;Data Source=" & p_XEPTAI_IP & ";Persist Security Info=True;User ID=" & _
                        p_XEPTAI_USER & ";Password=" & p_XEPTAI_PASS & _
                               ";Initial Catalog=" & p_XEPTAI_DB & ";Connect Timeout=300"
            
        End If
        If p_Connecttion = "" Then
            ShowStatusMessage(True, "", "Kết nối DB xếp tài không xác định")
            Exit Sub
        End If
        GridView1.MoveLast()
        DayDuLieuTDH_XeTai(p_Connecttion, True)
        ' Me.DefaultFormLoad = True
        'Me.XtraForm1_Load()
        ' Me.DefaultFormLoad = False

    End Sub


    Private Sub DayDuLieuTDH_XeTai(ByVal p_Connecttion As String, Optional ByVal p_XepTai As Boolean = False)
        Dim p_Count As Integer
        Dim p_Row, p_Row1 As DataRow
        Dim p_Id As Integer
        Dim p_SQL, p_SQLINS As String
        'Dim p_Connecttion As String = ""
        Dim p_Table, p_DataTable1 As DataTable
        Dim p_Desc As String
        Dim p_Check As Boolean = False


        Dim p_TableName As String = "tblCongToNhomBe"

        p_DataTable1 = New DataTable
        p_DataTable1.Columns.Add("STR_SQL")

        If p_Connecttion = "" Then
            ShowStatusMessage(True, "", "Kết nối TĐH không xác định")
            Exit Sub
        End If
        ' SendKeys.Send("{TAB}")
        ' GridView1.UpdateCurrentRow()
        'Me.TrueDBGrid1.Update()
        ' GridView1.MoveLast()
        For p_Count = Me.GridView1.RowCount - 1 To 0 Step -1
            p_Row = Me.GridView1.GetDataRow(p_Count)
            If Not p_Row Is Nothing Then
                If p_Row.Item("X").ToString.Trim = "Y" Then
                    p_Check = True
                    p_DataTable1.Clear()
                    Integer.TryParse(p_Row.Item("ID").ToString.Trim, p_Id)
                    If p_Id > 0 Then
                        p_SQLINS = ""
                        'If (p_Row.Item("Push_TDH").ToString.Trim <> "Y" And p_XepTai = False) Or (p_Row.Item("Push_XTTD").ToString.Trim <> "Y" And p_XepTai = True) Then
                        p_SQLINS = "MERGE tblCongToNhomBe T " & _
                                                "USING (SELECT '" & p_Row.Item("TankValidfrom").ToString.Trim & "' as TankValidfrom, '" & p_Row.Item("TankValid_to").ToString.Trim & "' as TankValid_to ," & p_Row.Item("ID") & _
                                                    " as  ID ,'" & p_Row.Item("MeterId").ToString.Trim & "' as MeterId,'" & p_Row.Item("Valid_from").ToString() & "' as Valid_from" & _
                                                ",'" & p_Row.Item("Valid_to").ToString() & "' as Valid_to ,'" & p_Row.Item("Bexuat").ToString & "' as Bexuat,'" & p_Row.Item("TankGroup").ToString.Trim & "' as TankGroup" & _
                                                ",'" & p_Row.Item("MaHangHoaTDH").ToString.Trim & "' as MaHangHoa,'" & p_Row.Item("TenHangHoa").ToString.Trim & "' as TenHangHoa,  " & _
                                            "getdate() CreateDate,getdate() UpdateDate  )  " & _
                                         "AS S (TankValidfrom, TankValid_to , ID ,MeterId,Valid_from,Valid_to ,Bexuat,TankGroup,MaHangHoa,TenHangHoa, CreateDate,UpdateDate) " & _
                                                   "ON (T.ID = S.ID ) " & _
                                            "WHEN MATCHED THEN " & _
                                                "UPDATE SET t.TankValidfrom =s.TankValidfrom, t.MeterId=s.MeterId,t.TankValid_to = s.TankValid_to, t.Valid_from=s.Valid_from " & _
                                            ",t.Valid_to=s.Valid_to ,t.Bexuat=s.Bexuat,t.TankGroup=s.TankGroup,t.MaHangHoa=s.MaHangHoa,t.TenHangHoa =s.TenHangHoa, t.UpdateDate =s.UpdateDate " & _
                                            "WHEN NOT MATCHED THEN " & _
                                                "INSERT(ID, MeterId, Valid_from, Valid_to, Bexuat, TankGroup, MaHangHoa, TenHangHoa, CreateDate, TankValidfrom,TankValid_to) " & _
                                                "VALUES (s.ID ,s.MeterId,s.Valid_from,s.Valid_to ,s.Bexuat,s.TankGroup,s.MaHangHoa,s.TenHangHoa, s.CreateDate, s.TankValidfrom, s.TankValid_to) ;"


                        p_Row1 = p_DataTable1.NewRow
                        p_Row1.Item(0) = p_SQLINS
                        p_DataTable1.Rows.Add(p_Row1)
                        If g_Services.Execute_DataTbl_With_Connection(p_Connecttion, p_DataTable1, p_Desc) = False Then
                            ShowStatusMessage(True, "", p_Desc, 5)
                            Exit Sub
                        Else
                            If p_XepTai = False Then
                                'p_SQLINS = "MERGE tblCongToNhomBe_TDH T " & _
                                '                "USING (SELECT '" & p_Row.Item("TankValidfrom").ToString.Trim & "' as TankValidfrom, '" & p_Row.Item("TankValid_to").ToString.Trim & "' as TankValid_to ," & p_Row.Item("IDLine") & _
                                '                    " as  IDLine ,'" & p_Row.Item("MeterId").ToString.Trim & "' as MeterId,'" & p_Row.Item("Valid_from").ToString() & "' as Valid_from" & _
                                '                ",'" & p_Row.Item("Valid_to").ToString() & "' as Valid_to ,'" & p_Row.Item("Bexuat").ToString & "' as Bexuat,'" & p_Row.Item("TankGroup").ToString.Trim & "' as TankGroup" & _
                                '                ",'" & p_Row.Item("MaHangHoaTDH").ToString.Trim & "' as MaHangHoa,'" & p_Row.Item("TenHangHoa").ToString.Trim & "' as TenHangHoa,  " & _
                                '            "getdate() CreateDate,getdate() UpdateDate  )  " & _
                                '         "AS S (TankValidfrom, TankValid_to , ID ,MeterId,Valid_from,Valid_to ,Bexuat,TankGroup,MaHangHoa,TenHangHoa, CreateDate,UpdateDate) " & _
                                '                   "ON (T.IDLine = S.IDLine ) " & _
                                '            "WHEN MATCHED THEN " & _
                                '                "UPDATE SET t.TankValidfrom =s.TankValidfrom, t.MeterId=s.MeterId,t.TankValid_to = s.TankValid_to, t.Valid_from=s.Valid_from " & _
                                '            ",t.Valid_to=s.Valid_to ,t.Bexuat=s.Bexuat,t.TankGroup=s.TankGroup,t.MaHangHoa=s.MaHangHoa,t.TenHangHoa =s.TenHangHoa, t.UpdateDate =s.UpdateDate ;" '& _
                                ''"WHEN NOT MATCHED THEN " & _
                                ''    "INSERT(ID, MeterId, Valid_from, Valid_to, Bexuat, TankGroup, MaHangHoa, TenHangHoa, CreateDate, TankValidfrom,TankValid_to, Push_TDH, User_Push_TDH ) " & _
                                ''    "VALUES (s.ID ,s.MeterId,s.Valid_from,s.Valid_to ,s.Bexuat,s.TankGroup,s.MaHangHoa,s.TenHangHoa, s.CreateDate, s.TankValidfrom, s.TankValid_to,'Y',  '" & g_UserName & "') ;"

                                'p_SQL = p_SQLINS
                                p_SQL = ""
                                p_SQL = p_SQL & "update [tblCongToNhomBe] set  Push_TDH ='Y', User_Push_TDH = '" & g_UserName & "', Date_Push_TDH =getdate() where ID = " & p_Id & ";"
                                '''''p_SQL = p_SQL & " exec FPT_FromDatToDateUpdate '" & p_Row.Item("MeterId").ToString.Trim & "','" & p_Row.Item("Valid_from").ToString.Trim & "','" & p_Row.Item("Valid_to").ToString.Trim & "';"

                                If g_Services.Sys_Execute(p_SQL, p_Desc) = False Then
                                    ShowStatusMessage(True, "CongToNhomBe TDH", p_Desc, 5)
                                End If
                            Else  'If p_XepTai = True And p_Row.Item("Push_XTTD").ToString.Trim <> "Y" Then
                                p_SQL = "update [tblCongToNhomBe] set  [Push_XTTD] ='Y', [User_Push_XTTD] = '" & g_UserName & "', [Date_Push_XTTD] =getdate() where ID = " & p_Id
                                If g_Services.Sys_Execute(p_SQL, p_Desc) = False Then
                                    ShowStatusMessage(True, "CongToNhomBe XTTD", p_Desc, 5)
                                End If
                            End If

                        End If
                        'End If
                    End If
                End If
            End If
        Next


        If p_Check = True Then
            ShowStatusMessage(False, "", "Đã thực hiện xong", 5)
        Else
            ShowStatusMessage(True, "", "Không có công tơ nào được chọn!", 5)
        End If



    End Sub



    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        'If Me.FormStatus = True Then
        'ShowStatusMessage(True, "", "Đề nghị lưu lại trước khi thực hiện", 5)
        ' Exit Sub
        ' End If

        If MsgBox("Bạn có chắc chắn muốn thực hiện không?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
            Exit Sub
        End If

        DayDuLieuTDH()

    End Sub

    'Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
    '    If MsgBox("Bạn có chắc chắn muốn thực hiện không?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
    '        Exit Sub
    '    End If

    '    DayDuLieu_XepTai()
    'End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim FrmVehicleTmp As New FrmMeterGroupHist
        FrmVehicleTmp.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmVehicleTmp.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
        FrmVehicleTmp.g_FormAddnew = False
        FrmVehicleTmp.FormStatus = False
        FrmVehicleTmp.p_XtraToolTripLabel = g_ToolStripStatus
        FrmVehicleTmp.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmVehicleTmp.p_XtraMessageStatusl = g_MessageStatus
        'FrmVehicleTmp.DefaultWhere = " WHERE MaPhuongTien=N'" & p_DataRow.Item(Me.GridView1.ColumnKey).ToString.Trim & "'"
        FrmVehicleTmp.ShowDialog(Me)
    End Sub

    Private Sub CmdSMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSMO.Click
        SelectALLRow("Y")
    End Sub

    Private Sub SelectALLRow(ByVal p_Type As String)
        Dim p_count As Integer
        Dim p_Row As DataRow

        For p_count = Me.GridView1.RowCount - 1 To 0 Step -1
            p_Row = Me.GridView1.GetDataRow(p_count)
            If Not p_Row Is Nothing Then
                If p_Row.Item("MeterId").ToString.Trim <> "" Then
                    p_Row.Item("X") = p_Type
                End If
            End If
        Next
    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        SelectALLRow("N")
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim FrmVehicleTmp As New FrmMeterGroupTDH
        FrmVehicleTmp.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmVehicleTmp.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
        FrmVehicleTmp.g_FormAddnew = False
        FrmVehicleTmp.FormStatus = False
        FrmVehicleTmp.p_XtraToolTripLabel = g_ToolStripStatus
        FrmVehicleTmp.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmVehicleTmp.p_XtraMessageStatusl = g_MessageStatus
        'FrmVehicleTmp.DefaultWhere = " WHERE MaPhuongTien=N'" & p_DataRow.Item(Me.GridView1.ColumnKey).ToString.Trim & "'"
        FrmVehicleTmp.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click

    End Sub
End Class