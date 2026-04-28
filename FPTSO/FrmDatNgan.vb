Public Class FrmDatNgan
    Private g_SoLenh As String
    Private g_PhuongTien As String
    Private i_dt_vehicle As DataTable
    Private i_dt_header As DataTable
    Private o_dt_compartment As DataTable
    Public g_dt_compartment As DataTable

    Private p_TableHangHoa As DataTable = Nothing


    Private g_TableLine As DataTable

    Public Property TableHangHoa() As DataTable  'True: Lock form 
        Get
            Return p_TableHangHoa
        End Get
        Set(ByVal value As DataTable)
            p_TableHangHoa = value
        End Set

    End Property

    Private g_LoaiXuat As String

    Public Property LoaiXuat() As String  'True: Lock form 
        Get
            Return g_LoaiXuat
        End Get
        Set(ByVal value As String)
            g_LoaiXuat = value
        End Set

    End Property



    '    Dim workCol As DataColumn = workTable.Columns.Add( _
    '    "CustID", Type.GetType("System.Int32"))
    'workCol.AllowDBNull = false
    'workCol.Unique = true

    'workTable.Columns.Add("CustLName", Type.GetType("System.String"))
    'workTable.Columns.Add("CustFName", Type.GetType("System.String"))
    'workTable.Columns.Add("Purchases", Type.GetType("System.Double"))

    Sub SetVehicle()
        Dim p_Count As Integer
        Dim p_Column As DevExpress.XtraGrid.Columns.GridColumn
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
        Dim p_DataTabe As New DataTable("Table001")
        Dim p_BindingSource As New U_TextBox.U_BindingSource
        Dim p_ColumnName As String
        Dim p_DataRow As DataRow
        For p_Count = 0 To i_dt_vehicle.Rows.Count - 1
            p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
            p_ColumnName = "Ngan" & i_dt_vehicle.Rows(p_Count).Item("MaNgan").ToString.Trim
            p_DataTabe.Columns.Add(p_ColumnName)
            p_Column = Me.GridView2.Columns.Item(p_Count)
            p_Column.FieldName = p_ColumnName
            p_Column.Visible = True
            p_ColType.ValueChecked = "Y"
            p_ColType.ValueUnchecked = "N"
            p_Column.ColumnEdit = p_ColType
            p_Column.Name = p_ColumnName
            p_Column.Caption = "N" & (p_Count + 1).ToString() & " - " & i_dt_vehicle.Rows(p_Count).Item("SoLuongMax").ToString.Trim  ' o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()
            'Me.GridView2.Columns.Add(p_Column)
        Next
        p_DataRow = p_DataTabe.NewRow
        For p_Count = 0 To p_DataTabe.Columns.Count - 1

            p_DataRow.Item(p_Count) = "Y"

            ' Me.GridView2.AddNewRow()
        Next
        p_DataTabe.Rows.Add(p_DataRow)
        p_BindingSource.DataSource = p_DataTabe
        Me.TrueDBGrid2.DataSource = p_BindingSource
        TrueDBGrid2.Refresh()
        ' GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        'For p_Count = 0 To Me.GridView2.Columns.Count - 1
        '    p_Column = Me.GridView2.Columns.Item(0)
        '    Me.GridView2.SetRowCellValue(GridView2.FocusedRowHandle, p_Column.Name, "Y")
        'Next

        ' Me.GridView2.RefreshEditor(True)
        ' Me.GridView2.re
        'i_dt_vehicle()
        'l_dgv_column = New DataGridViewCheckBoxColumn()
        'l_dgv_column.Name = "Ngan" & i.ToString()
        'l_dgv_column.HeaderText = "N" & (i + 1).ToString() & " - " & o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()
        'i_dgv_Vehicle.Columns.Add(l_dgv_column)
    End Sub

        


    Private Sub FrmDatNgan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        'Dim p_Binding As New U_TextBox.U_BindingSource
        'Dim p_Count As Integer
        'Dim p_RowArr() As DataRow
        'Dim p_DataRow As DataRow
        'Dim p_TableID As String
        'Dim p_DungTichNgan As Integer
        'Dim p_MaNgan As String
        'Dim p_Column As U_TextBox.GridColumn
        Dim p_Count As Integer
        Dim p_DataRow As DataRow
        Dim p_Column As Integer

        Try
           
            p_SQL = "select MaNgan, SoLuongMax, 'X' as [Select] from FPT_tblChiTietPhuongTien_V where MaPhuongTien ='" & g_PhuongTien & "' ORDER By MaNgan"
            i_dt_vehicle = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

            If i_dt_header Is Nothing Then
                i_dt_header = New DataTable
                i_dt_header.Columns.Add("SoLenh")
                i_dt_header.Columns.Add("LineID")
                i_dt_header.Columns.Add("TableID")
                i_dt_header.Columns.Add("TongDuXuat", Type.GetType("System.Int32"))
                i_dt_header.Columns.Add("TenHangHoa") 'i_dt_header.Columns.Add("MaHangHoa")
                i_dt_header.Columns.Add("MaLenh")
            ElseIf i_dt_header.Columns.Count = 0 Then
                i_dt_header.Columns.Add("SoLenh")
                i_dt_header.Columns.Add("LineID")
                i_dt_header.Columns.Add("TableID")
                i_dt_header.Columns.Add("TongDuXuat", Type.GetType("System.Int32"))
                i_dt_header.Columns.Add("TenHangHoa")   'i_dt_header.Columns.Add("MaHangHoa")
                i_dt_header.Columns.Add("MaLenh")
            End If
            If g_TableLine Is Nothing Then
                Exit Sub
            End If
            i_dt_header.Clear()
            For p_Count = 0 To g_TableLine.Rows.Count - 1
                p_DataRow = i_dt_header.NewRow
                p_DataRow.Item("SoLenh") = g_TableLine.Rows(p_Count).Item("SoLenh").ToString.Trim
                p_DataRow.Item("LineID") = g_TableLine.Rows(p_Count).Item("LineID").ToString.Trim
                p_DataRow.Item("TableID") = g_TableLine.Rows(p_Count).Item("TableID").ToString.Trim
                p_DataRow.Item("TongDuXuat") = IIf(g_TableLine.Rows(p_Count).Item("TongXuat").ToString.Trim = "", 0, g_TableLine.Rows(p_Count).Item("TongXuat"))
                p_DataRow.Item("TenHangHoa") = g_TableLine.Rows(p_Count).Item("TenHangHoa").ToString.Trim
                'p_DataRow.Item("MaHangHoa") = g_TableLine.Rows(p_Count).Item("MaHangHoa").ToString.Trim
                p_DataRow.Item("MaLenh") = g_TableLine.Rows(p_Count).Item("MaLenh").ToString.Trim

                i_dt_header.Rows.Add(p_DataRow)
            Next

            'p_SQL = "select SoLenh, LineID, TableID,case when isnull(TongXuat,0)>0 then TongXuat else TongDuXuat end TongDuXuat, MaHangHoa, " & _
            '        " MaLenh from tblLenhXuat_HangHoaE5 with (nolock) where CHARINDEX ( SoLenh, '" & g_SoLenh & "' ,1) >0 and  SoLenh <>'0' "
            'i_dt_header = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

            'o_dt_compartment = i_dt_header.Clone
            'o_dt_compartment.Clear()
            o_dt_compartment = New DataTable
            o_dt_compartment.Columns.Add("MaNgan")
            o_dt_compartment.Columns.Add("SoLenh")
            o_dt_compartment.Columns.Add("LineID")
            o_dt_compartment.Columns.Add("TableID")
            o_dt_compartment.Columns.Add("SoLuongDuXuat")
            o_dt_compartment.Columns.Add("TenHangHoa")
            o_dt_compartment.Columns.Add("DungTichNgan", Type.GetType("System.Int32"))
            o_dt_compartment.Columns.Add("MaLenh")
            'mdlCompartment_AutoCompartment(i_dt_vehicle, i_dt_header, o_dt_compartment)

            'For p_Count = 0 To o_dt_compartment.Rows.Count - 1
            '    p_DataRow = o_dt_compartment.Rows(p_Count)
            '    p_TableID = p_DataRow.Item("TableID").ToString.Trim
            '    p_RowArr = i_dt_header.Select("TableID='" & p_TableID & "'")
            '    If p_RowArr.Length > 0 Then
            '        o_dt_compartment.Rows(p_Count).Item("MaHangHoa") = p_RowArr(0).Item("MaHangHoa").ToString.Trim
            '    End If
            '    p_MaNgan = p_DataRow.Item("MaNgan").ToString.Trim
            '    p_RowArr = i_dt_vehicle.Select("MaNgan='" & p_MaNgan & "'")
            '    If p_RowArr.Length > 0 Then
            '        o_dt_compartment.Rows(p_Count).Item("DungTichNgan") = p_RowArr(0).Item("SoLuongMax").ToString.Trim
            '    End If

            'Next


            'p_Binding.DataSource = o_dt_compartment

            'Me.TrueDBGrid1.DataSource = p_Binding
            'p_Binding.ResetBindings(True)
            'TrueDBGrid1.Refresh()


            'For p_Count = 0 To Me.GridView1.Columns.Count - 1

            '    p_Column = Me.GridView1.Columns.Item(p_Count)
            '    p_Column.FieldName = p_Column.FieldView


            'Next
            TuDongChiaNgan()
            SetVehicle()

        Catch ex As Exception

        End Try
        '   Me.GridView1.RefreshEditor(True)
    End Sub


    Sub TuDongChiaNgan()
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_RowArr() As DataRow
        Dim p_DataRow As DataRow
        Dim p_MaNgan As String
        Dim p_TableID As String
        Dim p_Column As U_TextBox.GridColumn
        Dim p_Count As Integer
        Dim p_CurrentValue As String
        Dim p_CurrentName As String
        Dim o_dt_compartment_tmp As New DataTable
        Dim p_Count1 As Integer
        Dim p_Array() As DataRow
        'Dim p_Count As Integer

        '  Dim p_DataRow As DataRow


        o_dt_compartment.Clear()

        GridView2.MoveLast()

        If GridView2.RowCount > 0 Then
            p_DataRow = Me.GridView2.GetFocusedDataRow

            ' p_Column = CType(Me.GridView2.FocusedColumn, U_TextBox.GridColumn)
            p_CurrentValue = Me.GridView2.GetFocusedValue.ToString
            p_CurrentName = Me.GridView2.FocusedColumn.FieldName.ToString
            For p_Count = 0 To i_dt_vehicle.Rows.Count - 1
                If p_DataRow.Item(p_Count).ToString.Trim = "Y" Then
                    i_dt_vehicle.Rows(p_Count).Item("Select") = "X"
                Else
                    i_dt_vehicle.Rows(p_Count).Item("Select") = ""
                End If
            Next
            For p_Count = 0 To Me.GridView2.Columns.Count - 1
                If Me.GridView2.Columns.Item(p_Count).FieldName = p_CurrentName Then
                    If p_CurrentValue = "Y" Then
                        i_dt_vehicle.Rows(p_Count).Item("Select") = "X"
                    Else
                        i_dt_vehicle.Rows(p_Count).Item("Select") = ""
                    End If
                End If
            Next
            'GridView2.FocusedColumn.Name 
        End If

       
        mdlCompartment_AutoCompartment(i_dt_vehicle, i_dt_header, o_dt_compartment, g_LoaiXuat)
    
        For p_Count = 0 To o_dt_compartment.Rows.Count - 1
            p_DataRow = o_dt_compartment.Rows(p_Count)
            p_TableID = p_DataRow.Item("TableID").ToString.Trim
            p_RowArr = i_dt_header.Select("TableID='" & p_TableID & "'")
            If p_RowArr.Length > 0 Then
                o_dt_compartment.Rows(p_Count).Item("TenHangHoa") = p_RowArr(0).Item("TenHangHoa").ToString.Trim
                'o_dt_compartment.Rows(p_Count).Item("MaHangHoa") = p_RowArr(0).Item("MaHangHoa").ToString.Trim
            End If
            p_MaNgan = p_DataRow.Item("MaNgan").ToString.Trim
            o_dt_compartment.Rows(p_Count).Item("MaLenh") = p_RowArr(0).Item("MaLenh").ToString.Trim

            p_RowArr = i_dt_vehicle.Select("MaNgan='" & p_MaNgan & "'")
            If p_RowArr.Length > 0 Then
                o_dt_compartment.Rows(p_Count).Item("DungTichNgan") = p_RowArr(0).Item("SoLuongMax").ToString.Trim
            End If

        Next

        o_dt_compartment_tmp = o_dt_compartment.Clone
        If o_dt_compartment.Rows.Count > 0 Then
            For p_Count = 0 To i_dt_vehicle.Rows.Count - 1
                p_Array = o_dt_compartment.Select("MaNgan='" & i_dt_vehicle.Rows(p_Count).Item("MaNgan").ToString.Trim & "'")
                p_DataRow = o_dt_compartment_tmp.NewRow
                If p_Array.Length > 0 Then
                    For p_Count1 = 0 To o_dt_compartment.Columns.Count - 1
                        p_DataRow(p_Count1) = p_Array(0).Item(p_Count1)
                    Next
                Else
                    p_DataRow.Item("MaNgan") = i_dt_vehicle.Rows(p_Count).Item("MaNgan").ToString.Trim
                    p_DataRow.Item("DungTichNgan") = i_dt_vehicle.Rows(p_Count).Item("SoLuongMax").ToString.Trim
                End If
                o_dt_compartment_tmp.Rows.Add(p_DataRow)
            Next
        End If
        o_dt_compartment = o_dt_compartment_tmp
        p_Binding.DataSource = o_dt_compartment

        Me.TrueDBGrid1.DataSource = p_Binding
        p_Binding.ResetBindings(True)
        TrueDBGrid1.Refresh()


        For p_Count = 0 To Me.GridView1.Columns.Count - 1

            p_Column = Me.GridView1.Columns.Item(p_Count)
            p_Column.FieldName = p_Column.FieldView


        Next

        Dim riCombo As DevExpress.XtraEditors.Repository.RepositoryItemComboBox

        'riCombo = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        'riCombo.Items.Add("            ")
        riCombo = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        For p_Count = 0 To Me.i_dt_header.Rows.Count - 1

            riCombo.Items.Add(i_dt_header.Rows(p_Count).Item("TableID").ToString.Trim)
        Next
        ' Dim riCombo As DevExpress.XtraEditors.Repository.RepositoryItemComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        ' riCombo.Items.AddRange(New String() {"London", "Berlin", "Paris"})
        ' 'Add a repository item to the repository items of grid control

        'Now you can define the repository item as an inplace editor of columns
        riCombo.Items.Add(" ")
        riCombo.Appearance.Font = New Font("Tahoma", 12, FontStyle.Regular)
        riCombo.AppearanceDropDown.Font = New Font("Tahoma", 12, FontStyle.Regular)

        Me.GridView1.Columns.Item("TableID").ColumnEdit = riCombo

        Me.GridView1.OptionsBehavior.ReadOnly = False
        Me.TrueDBGrid1.UseEmbeddedNavigator = False
    End Sub


    




    Public Sub New(ByVal p_SoLenh As String, ByVal p_PhuongTien As String, ByVal p_TableLine As DataTable)
        g_SoLenh = p_SoLenh
        g_TableLine = p_TableLine
        g_PhuongTien = p_PhuongTien
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ToolRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolRefresh.Click
        Me.FormStatus = False
        Me.GridView2.RefreshData()
        g_dt_compartment = o_dt_compartment
        Me.Close()
    End Sub

    Private Sub ToolAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolAuto.Click
        Me.GridView2.RefreshData()
        TuDongChiaNgan()
    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim p_TongMax As Double
        Dim p_TongDuXuat As Double
        Dim p_DataRow() As DataRow

        Select Case UCase(e.Column.FieldName)
            Case "TABLEID"
                If e.Value.ToString.Trim <> "" Then
                    p_DataRow = i_dt_header.Select("TableID='" & e.Value & "'")
                    If p_DataRow.Length > 0 Then
                        Me.GridView1.SetFocusedRowCellValue("TenHangHoa", p_DataRow(0).Item("TenHangHoa").ToString.Trim)
                        Me.GridView1.SetFocusedRowCellValue("LineID", p_DataRow(0).Item("LineId").ToString.Trim)
                        Me.GridView1.SetFocusedRowCellValue("SoLenh", p_DataRow(0).Item("SoLenh").ToString.Trim)
                        Me.GridView1.SetFocusedRowCellValue("MaLenh", p_DataRow(0).Item("MaLenh").ToString.Trim)
                    End If
                    Double.TryParse(Me.GridView1.GetFocusedRowCellValue("DungTichNgan").ToString.Trim, p_TongMax)
                    Me.GridView1.SetFocusedRowCellValue("SoLuongDuXuat", p_TongMax)
                Else
                    Me.GridView1.SetFocusedRowCellValue("SoLuongDuXuat", 0)
                End If
            Case UCase("SoLuongDuXuat")
                If e.Value.ToString.Trim <> "" And UCase(g_LoaiXuat) <> "THUY" Then
                    Double.TryParse(e.Value.ToString.Trim, p_TongDuXuat)
                    Double.TryParse(Me.GridView1.GetFocusedRowCellValue("DungTichNgan").ToString.Trim, p_TongMax)
                    If p_TongDuXuat > 0 Then
                        If p_TongDuXuat <> p_TongMax Then
                            ShowMessageBox("", "Dung tích ngăn khác lượng dự xuất")
                        End If
                    End If
                End If
            Case Else

        End Select

    End Sub
End Class