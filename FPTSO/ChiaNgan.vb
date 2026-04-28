Module ChiaNgan
    Private g_SoLenh As String
    Private g_PhuongTien As String
    Private i_dt_vehicle As DataTable
    Private i_dt_header As DataTable
    Private o_dt_compartment As DataTable
    Private g_dt_compartment As DataTable

    Private p_TableHangHoa As DataTable = Nothing
    Private g_TableLine As DataTable

    Sub Load1(ByVal p_PhuongTien As String, ByVal p_TableLine As DataTable, ByRef p_dt_compartment As DataTable, Optional ByVal p_LoaiXuat As String = "BO")
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
        g_PhuongTien = p_PhuongTien
        g_TableLine = p_TableLine
        Try
            p_SQL = "select MaNgan, SoLuongMax, 'X' as [Select] from FPT_tblChiTietPhuongTien_V where MaPhuongTien ='" & g_PhuongTien & "' ORDER By MaNgan"
            i_dt_vehicle = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

            If i_dt_header Is Nothing Then
                i_dt_header = New DataTable
                i_dt_header.Columns.Add("SoLenh")
                i_dt_header.Columns.Add("LineID")
                i_dt_header.Columns.Add("TableID")
                i_dt_header.Columns.Add("TongDuXuat", Type.GetType("System.Int32"))
                i_dt_header.Columns.Add("TenHangHoa")   'i_dt_header.Columns.Add("MaHangHoa")
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
                p_DataRow.Item("TenHangHoa") = g_TableLine.Rows(p_Count).Item("TenHangHoa").ToString.Trim   'g_TableLine.Rows(p_Count).Item("MaHangHoa").ToString.Trim
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

            TuDongChiaNgan(p_LoaiXuat)
            p_dt_compartment = g_dt_compartment
            'SetVehicle()

        Catch ex As Exception

        End Try
    End Sub


    'Sub SetVehicle()
    '    Dim p_Count As Integer
    '    Dim p_Column As DevExpress.XtraGrid.Columns.GridColumn
    '    Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    '    Dim p_DataTabe As New DataTable("Table001")
    '    Dim p_BindingSource As New U_TextBox.U_BindingSource
    '    Dim p_ColumnName As String
    '    Dim p_DataRow As DataRow
    '    For p_Count = 0 To i_dt_vehicle.Rows.Count - 1
    '        p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    '        p_ColumnName = "Ngan" & i_dt_vehicle.Rows(p_Count).Item("MaNgan").ToString.Trim
    '        p_DataTabe.Columns.Add(p_ColumnName)
    '        p_Column = Me.GridView2.Columns.Item(p_Count)
    '        p_Column.FieldName = p_ColumnName
    '        p_Column.Visible = True
    '        p_ColType.ValueChecked = "Y"
    '        p_ColType.ValueUnchecked = "N"
    '        p_Column.ColumnEdit = p_ColType
    '        p_Column.Name = p_ColumnName
    '        p_Column.Caption = "N" & (p_Count + 1).ToString() & " - " & i_dt_vehicle.Rows(p_Count).Item("SoLuongMax").ToString.Trim  ' o_dt_vehicle.Rows(i).Item("SoLuongMax").ToString()
    '        'Me.GridView2.Columns.Add(p_Column)
    '    Next
    '    p_DataRow = p_DataTabe.NewRow
    '    For p_Count = 0 To p_DataTabe.Columns.Count - 1

    '        p_DataRow.Item(p_Count) = "Y"

    '        ' Me.GridView2.AddNewRow()
    '    Next
    '    p_DataTabe.Rows.Add(p_DataRow)

    'End Sub

    Sub TuDongChiaNgan(ByVal p_LoaiXuat As String)
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_RowArr() As DataRow
        Dim p_DataRow As DataRow
        Dim p_MaNgan As String
        Dim p_TableID As String
        Dim p_Column As U_TextBox.GridColumn
        Dim p_Count As Integer
        Dim p_CurrentValue As String
        Dim p_CurrentName As String

        Dim p_DungTich As Double
        Dim p_DuXuat As Double
        o_dt_compartment.Clear()


        mdlCompartment_AutoCompartment(i_dt_vehicle, i_dt_header, o_dt_compartment, p_LoaiXuat)

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

            If UCase(p_LoaiXuat) = "THUY" Then
                Double.TryParse(o_dt_compartment.Rows(p_Count).Item("DungTichNgan").ToString.Trim, p_DungTich)
                Double.TryParse(o_dt_compartment.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim, p_DuXuat)

                If p_DuXuat > p_DungTich Then
                    o_dt_compartment.Rows(p_Count).Item("SoLuongDuXuat") = 0
                End If
            End If
            
        Next

        g_dt_compartment = o_dt_compartment
    End Sub

End Module
