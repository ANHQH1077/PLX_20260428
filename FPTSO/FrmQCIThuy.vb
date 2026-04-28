Public Class FrmQCIThuy

    Private g_dgv_header As U_TextBox.GridView
    Private g_dgv_detail As U_TextBox.GridView
    Private g_plant As String
    Private g_batch As String

    Private Sub FrmQCIThuy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_desc As String = ""
        Dim p_DataTbl As New DataTable("Table01")
        Dim p_DataTblDetail As New DataTable
        Dim p_DataTblHeader As New DataTable
        Dim p_CountHeader As Integer
        Dim p_CountDetail As Integer

        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_BindingDetail As New U_TextBox.U_BindingSource
        Dim p_BindingHeader As New U_TextBox.U_BindingSource

        Dim p_Column As U_TextBox.GridColumn
        Dim p_count As Integer
        p_DataTbl.Columns.Add("MaNgan")
        p_DataTbl.Columns.Add("MaHangHoa")
        p_DataTbl.Columns.Add("TenHangHoa")
        p_DataTbl.Columns.Add("SoLuong", GetType(Double))
        p_DataTbl.Columns.Add("DVT")
        p_DataTbl.Columns.Add("NhietDo", GetType(Double))
        p_DataTbl.Columns.Add("TyTrong", GetType(Double))
        p_DataTbl.Columns.Add("Ltt", GetType(Double))
        p_DataTbl.Columns.Add("L15", GetType(Double))
        p_DataTbl.Columns.Add("M15", GetType(Double))
        p_DataTbl.Columns.Add("Kg", GetType(Double))
        p_DataTbl.Columns.Add("TableID")

        p_BindingDetail = g_dgv_detail.DataSource
        p_DataTblDetail = CType(p_BindingDetail.DataSource, DataTable)

        p_BindingHeader = g_dgv_header.DataSource
        p_DataTblHeader = CType(p_BindingHeader.DataSource, DataTable)

        'Try
        '    p_DataTblDetail.Columns.Add("DonViTinh")
        'Catch ex As Exception

        'End Try

      
        If Not mdlQCI_LoadGridQCI(p_DataTblDetail, p_DataTbl, p_desc) Then
            ShowMessageBox("", p_desc)
            Return
        End If

        For p_CountHeader = 0 To p_DataTblHeader.Rows.Count - 1
            For p_CountDetail = 0 To p_DataTbl.Rows.Count - 1
                If p_DataTbl.Rows(p_CountDetail).Item("TableID") = p_DataTblHeader.Rows(p_CountHeader).Item("TableID") Then
                    p_DataTbl.Rows(p_CountDetail).Item("TenHangHoa") = p_DataTblHeader.Rows(p_CountHeader).Item("TenHangHoa")
                    p_DataTbl.Rows(p_CountDetail).Item("DVT") = p_DataTblHeader.Rows(p_CountHeader).Item("DonViTinh")
                End If
            Next
        Next



        For p_count = 0 To Me.GridView1.Columns.Count - 1
            p_Column = Me.GridView1.Columns(p_count)
            Me.GridView1.Columns(p_count).FieldName = p_Column.FieldView
        Next
        p_Binding.DataSource = p_DataTbl
        Me.TrueDBGrid1.DataSource = p_Binding
        Me.TrueDBGrid1.RefreshDataSource()
        Me.GridView1.BestFitColumns()

        GetQCI()

    End Sub

    Public Sub New(ByVal i_dgv_header As U_TextBox.GridView, ByVal i_dgv_detail As U_TextBox.GridView, ByVal i_plant As String, ByVal i_batch As String)

        ' This call is required by the designer.
        InitializeComponent()
        g_dgv_header = i_dgv_header
        g_dgv_detail = i_dgv_detail
        g_plant = i_plant
        g_batch = i_batch
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Function mdlQCI_LoadGridQCI(ByVal i_dgv_detail As DataTable, ByRef i_dgv_qci As DataTable, ByRef p_Desc As String) As Boolean
        Dim l_mangan, _
            l_mahanghoa, _
            l_thucxuat, _
            l_donvitinh, _
            l_nhietdo, _
            l_tytrong _
            As String
        Dim p_Datarow As DataRow
        Dim p_TblDatarow As DataRow
        If i_dgv_detail Is Nothing Then
            p_Desc = "Không xác định được ngăn hàng hóa"
            Return False
        End If

        Try

            For i As Integer = 0 To i_dgv_detail.Rows.Count - 1
                p_Datarow = i_dgv_detail.Rows(i)
                If p_Datarow Is Nothing Then
                    Continue For
                End If
                l_mangan = p_Datarow.Item("MaNgan").ToString.Trim
                l_mahanghoa = p_Datarow.Item("MaHangHoa").ToString.ToString
                l_thucxuat = p_Datarow.Item("SoLuongThucXuat").ToString.Trim
                ' l_donvitinh = p_Datarow.Item("DonViTinh").ToString()
                l_nhietdo = p_Datarow.Item("NhietDo").ToString
                l_tytrong = p_Datarow.Item("TyTrong_15").ToString()

                p_TblDatarow = i_dgv_qci.NewRow

               

                p_TblDatarow.Item("MaNgan") = l_mangan
                p_TblDatarow.Item("MaHangHoa") = l_mahanghoa
                If l_thucxuat.ToString.Trim <> "" Then
                    p_TblDatarow.Item("SoLuong") = l_thucxuat
                End If

                ' Double.TryParse(l_thucxuat.ToString.Trim, p_TblDatarow.Item("ThucXuat"))
                '   p_TblDatarow.Item("DonViTinh") = l_donvitinh
                p_TblDatarow.Item("NhietDo") = l_nhietdo
                p_TblDatarow.Item("TyTrong") = l_tytrong
                p_TblDatarow.Item("TableID") = p_Datarow.Item("TableID").ToString.Trim

                i_dgv_qci.Rows.Add(p_TblDatarow)

                'i_dgv_qci.Rows.Add(l_mangan, _
                '                   l_mahanghoa, _
                '                   l_thucxuat, _
                '                   l_donvitinh, _
                '                   l_nhietdo, _
                '                   l_tytrong, _
                '                   String.Empty, _
                '                   String.Empty, _
                '                   String.Empty, _
                '                   String.Empty)
            Next

            Return True
        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try
    End Function
    Private Sub GetQCI()
        Dim p_SQL As String = ""
        Dim p_Desc As String = ""

        Dim p_Datatable As DataTable
        Dim p_Binding As U_TextBox.U_BindingSource
       

        p_Binding = Me.TrueDBGrid1.DataSource
        p_Datatable = CType(p_Binding.DataSource, DataTable)
        If g_WCF = False Then

            Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            'If p_SAP_Object.clsCheckSAPConnection("", p_SQL) = False Then

            'End If
            If p_SAP_Object.clsQCI_CalculateQCIThuy(g_plant, g_batch, p_Datatable, p_Desc) = False Then

                ShowMessageBox("", p_SQL)
                Exit Sub

            End If
            
        Else


            If g_Services.clsQCI_CalculateQCIThuy(g_plant, g_batch, p_Datatable, p_Desc) = False Then
                ShowMessageBox("", p_SQL)
                Exit Sub

            End If
        End If
        p_Binding.DataSource = p_Datatable
        Me.TrueDBGrid1.DataSource = p_Binding
        Me.TrueDBGrid1.RefreshDataSource()
        Me.GridView1.BestFitColumns()
    End Sub


    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        GetQCI()
    End Sub
End Class