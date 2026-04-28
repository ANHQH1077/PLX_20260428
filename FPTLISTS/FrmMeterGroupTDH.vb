Imports DevExpress.XtraGrid.Menu
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils.Menu
Public Class FrmMeterGroupTDH

    Private p_TYTRONG_PTANG As Boolean = False

    Public p_SQLWHere As String




    Private Sub FrmMeter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_Meter As String
        Dim p_WhereCol As String
        Dim p_Column As U_TextBox.GridColumn
        Dim p_DataRow() As DataRow
        Dim p_DataTable As DataTable




        Dim p_SQL As String = ""
        Dim p_sMeter As String = ""


        p_SQL = "select Name_nd as BeXuat  from tblTank where  1=0"

        p_sMeter = "select MeterId  from tblMeter "
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

        ' Me.GridView1.OptionsView.ShowGroupPanel = True




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


    Private Sub SaveRecord()
        Dim p_DataTable, p_DataTableCheck As DataTable
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_ArrRow() As DataRow
        Dim p_DataRow As DataRow
        Dim p_Count As Integer
        Dim p_HangHoa As String = ""
        Dim p_BeXuat As String = ""
        Dim p_SQL As String
        Dim p_Table As DataTable
        'Dim p_dataSet As DataSet

        Dim p_RowArr() As DataRow
        Dim p_DateTime As DateTime = Now
        Dim p_Source As U_TextBox.U_BindingSource
        p_GetCurrentDate(p_DateTime)

        Dim p_IDLine As Integer
        Dim p_FDate, p_TDate, p_FDateNhomBe, p_TDateNhomBe As DateTime
        Dim p_MeterId, p_Tank, p_TankGroup As String

        Try

            Me.GridView1.MoveNext()
        Catch ex As Exception

        End Try

        p_Source = Me.TrueDBGrid1.DataSource

        p_DataTable = p_Source.DataSource
        Me.GridView1.MoveFirst()
        While Not Me.GridView1.IsLastRow
            p_DataRow = Me.GridView1.GetFocusedDataRow

            If Not p_DataRow Is Nothing Then
                If p_DataRow.Item("Meterid").ToString.Trim <> "" Then
                    p_MeterId = p_DataRow.Item("Meterid").ToString.Trim
                    p_Tank = p_DataRow.Item("BeXuat").ToString.Trim
                    p_TankGroup = p_DataRow.Item("TankGroup").ToString.Trim
                    Integer.TryParse(p_DataRow.Item("IDLINE").ToString.Trim, p_IDLine)
                    DateTime.TryParse(p_DataRow.Item("Valid_from").ToString.Trim, p_FDate)
                    DateTime.TryParse(p_DataRow.Item("Valid_to").ToString.Trim, p_TDate)


                    ' Kiểm tra hieu lực với nhóm bể
                    If (p_FDate < p_DataRow.Item("TankValidfrom").ToString.Trim Or p_TDate > p_DataRow.Item("TankValid_to").ToString.Trim) Then
                        ShowMessageBox("", "Công tơ " & p_DataRow.Item("Meterid").ToString.Trim & ": Ngày hiệu lực phải nằm trong khoảng hiệu lực nhóm bể.")

                        Exit Sub
                    Else

                    End If


                    p_ArrRow = p_DataTable.Select("MeterId = '" & p_MeterId & "' and IDLine <>  " & p_IDLine , "Valid_from")
                    If Not p_ArrRow Is Nothing Then
                        For p_Count = 0 To p_ArrRow.Length - 1
                            If (p_FDate >= p_ArrRow(p_Count).Item("Valid_from") And p_FDate <= p_ArrRow(p_Count).Item("Valid_to")) Or (p_TDate >= p_ArrRow(p_Count).Item("Valid_from") And p_TDate <= p_ArrRow(p_Count).Item("Valid_to")) Then
                                ShowMessageBox("", "Công tơ " & p_DataRow.Item("Meterid").ToString.Trim & ": Ngày hiệu lực phải nằm ngoài hết hiệu lực với bể trước.")

                                Exit Sub
                            Else

                            End If

                            '' Kiểm tra hieu lực với nhóm bể
                            'If (p_FDate < p_ArrRow(p_Count).Item("TankValidfrom") Or p_TDate >= p_ArrRow(p_Count).Item("TankValid_to")) Then
                            '    ShowMessageBox("", "Công tơ " & p_DataRow.Item("Meterid").ToString.Trim & ": Ngày hiệu lực phải nằm trong khoảng hiệu lực nhóm bể.")

                            '    Exit Sub
                            'Else

                            'End If

                        Next
                    End If
                    
                    DateTime.TryParse(p_DataRow.Item("Valid_from").ToString.Trim, p_FDate)
                    DateTime.TryParse(p_DataRow.Item("Valid_to").ToString.Trim, p_TDate)
                    DateTime.TryParse(p_DataRow.Item("TankValidfrom").ToString.Trim, p_FDateNhomBe)
                    DateTime.TryParse(p_DataRow.Item("TankValid_to").ToString.Trim, p_TDateNhomBe)
                    'If (p_FDate) >= (p_FDateNhomBe) And (p_TDate) <= (p_TDateNhomBe) Then
                    p_SQL = "CongTo_NhomBe_Kiemtra '" & p_MeterId & "','" & p_FDate & "','" & p_TDate & "','" & p_Tank & "','" & p_TankGroup & "','" & p_FDateNhomBe & "','" & p_TDateNhomBe & "'," & p_IDLine
                    p_DataTableCheck = GetDataTable(p_SQL, p_SQL)
                    If Not p_DataTableCheck Is Nothing Then
                        If p_DataTableCheck.Rows.Count > 0 Then
                            If p_DataTableCheck.Rows(0).Item(0) > 0 Then
                                ShowMessageBox("", p_DataTableCheck.Rows(0).Item(1).ToString)
                                '  e.ErrorText = "DSFSFS"
                                Me.GridView1.SetFocusedRowModified()
                                Exit Sub
                            Else

                                ShowMessageBox("", p_DataTableCheck.Rows(0).Item(1).ToString)
                            End If
                        End If
                    End If
                End If
            End If
            Me.GridView1.MoveNext()
        End While

       


        Me.DefaultSave = True
        Me.UpdateToDatabase(Me, "")
        Me.DefaultSave = False
        '   End If


        p_SQL = "exec CotoNhomBe_CapNhatCurrent  '" & g_Terminal & "'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                ShowMessageBox("", "Lỗi khi cập nhật - " & p_DataTable.Rows(0).Item(1).ToString)
            End If
        End If

    End Sub



    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        SaveRecord()
    End Sub

    Private Sub GridView1_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor

        Dim p_DataRow As DataRow
        Dim p_FDate, p_TDate, p_FDateNhomBe, p_TDateNhomBe As DateTime
        Dim p_IDLine As Integer

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
                    p_TDate = e.Value
                Else
                    DateTime.TryParse(p_DataRow.Item("Valid_to").ToString.Trim, p_TDate)
                End If



                DateTime.TryParse(p_DataRow.Item("TankValidfrom").ToString.Trim, p_FDateNhomBe)
                DateTime.TryParse(p_DataRow.Item("TankValid_to").ToString.Trim, p_TDateNhomBe)


                If (p_FDate) >= (p_FDateNhomBe) And (p_TDate) <= (p_TDateNhomBe) Then

                Else
                    ShowMessageBox("", "Ngày hiệu lực/Hết hiệu lực phải trong khoảng thời gian Hiệu lực/Hết hiệu lực nhóm bể")

                    e.Valid = False

                End If

                Integer.TryParse(p_DataRow.Item("IDLINE").ToString.Trim, p_IDLine)
                If p_IDLine > 0 Then
                    p_DataRow.Item("UpdateUser") = g_UserName
                Else
                    p_DataRow.Item("CreateUser") = g_UserName
                End If

            End If

        End If


    End Sub



    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim FrmVehicleTmp As New FrmMeterGroup
        FrmVehicleTmp.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmVehicleTmp.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
        FrmVehicleTmp.g_FormAddnew = False
        FrmVehicleTmp.FormStatus = False
        FrmVehicleTmp.p_XtraToolTripLabel = g_ToolStripStatus
        FrmVehicleTmp.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmVehicleTmp.p_XtraMessageStatusl = g_MessageStatus
        FrmVehicleTmp.READ_ONLY = Me.READ_ONLY
        'FrmVehicleTmp.DefaultWhere = " WHERE MaPhuongTien=N'" & p_DataRow.Item(Me.GridView1.ColumnKey).ToString.Trim & "'"
        FrmVehicleTmp.ShowDialog(Me)
    End Sub
End Class