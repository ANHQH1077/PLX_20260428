Public Class FrmPhatHanhTichKe_KV1
    Dim p_SYS_MALENH_S As String = ""
    Dim p_FunctionTableId As String = ""
    Dim p_DateCreate As Date
    Dim p_TimeCreate As Integer
    Dim p_TableConfig As DataTable
    Dim p_TablePara As DataTable
    Dim p_DataTableDVT As DataTable
    Dim p_CURRENTDATE As Boolean = True
    Dim p_MATUDONGHOA As Boolean = False
    Dim p_SHOW_CLIENT As String = "0"

    Dim p_Date_KV1 As Date

    Public g_SoLenh_Q As String = ""

    Private p_DataHeader As DataTable
    Private p_DataLine As DataTable

    Private p_TableClient As DataTable
    Private p_LenhGhep As Boolean = False

    Private p_InLaiTichKe As Boolean = False
    Private p_HuyTichKe As Boolean = False

    Private p_NhietDoNgay As Double = 30


    Private flag As Integer()
    Private lw_mess As String()

    Private isGetAll As String
    Private g_dt As DataTable
    Private _TimeOut = New TimeSpan()

    Private _SapConnectionString As String
    Private _WareHouse As String
    Private _dtVariable As DataTable
    Private _ShPoint As String

    Private p_DanhSachPTGhep As String = ""
    Private p_KHOA_PTIEN As String = "N"
    Private p_PTien1 As String = ""
    Private p_NVC1 As String = ""
    Private p_SHOW_QCI As Boolean = False
    Private p_TaiTrongChoPhep As Integer = 20

    Private p_PhuongTienAo As String = ""

    Private p_CONGTO_BO As String = ""
    Private p_KT_TAITRONG As Boolean = True


    Private Function GetClient(ByVal p_MaVanChuyen As String) As String
        Dim p_RowArr() As DataRow
        Dim p_MaVanChuyenTmp As String = ""
        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            p_MaVanChuyenTmp = Me.MaVanChuyen.EditValue.ToString.Trim
        End If
        Try
            GetClient = g_Terminal
            p_RowArr = p_TableConfig.Select("KEYCODE='" & p_MaVanChuyenTmp & "'")
            If p_RowArr.Length > 0 Then
                GetClient = p_RowArr(0).Item("KeyValue").ToString.Trim
            End If
        Catch ex As Exception

        End Try
    End Function


    Private Sub LenhGhep(ByVal p_SoLenh As String)
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_DtLine As DataTable
        Dim p_DtHeader As DataTable
        Dim p_ArrRow() As DataRow
        Dim p_Count As Integer
        If g_FormAddnew = True Then
            Exit Sub
        End If
        If Not p_DataHeader Is Nothing Then
            p_ArrRow = p_DataHeader.Select("SoLenh='" & p_SoLenh & "'")
            If p_ArrRow.Length > 0 Then
                GoTo line_TT
            End If
        End If

        p_Binding = New U_TextBox.U_BindingSource
        p_Binding = Me.GridView1.DataSource
        p_DtHeader = CType(p_Binding.DataSource, DataTable)
        If p_DataHeader Is Nothing Then
            p_DataHeader = New DataTable
            p_DataHeader = p_DtHeader
        Else
            p_DtHeader.Merge(p_DtHeader)
        End If
line_TT:
        p_Binding = New U_TextBox.U_BindingSource
        p_Binding = Me.GridView2.DataSource
        p_DtLine = CType(p_Binding.DataSource, DataTable)
        If p_DataLine Is Nothing Then
            p_DataLine = New DataTable
            p_DataLine = p_DtLine
        Else
            p_DataLine.Merge(p_DtLine)
        End If

        p_Binding = New U_TextBox.U_BindingSource
        p_Binding.DataSource = p_DataHeader
        Me.TrueDBGrid1.DataSource = p_Binding
        Me.TrueDBGrid1.Refresh()

        p_Binding = New U_TextBox.U_BindingSource
        p_Binding.DataSource = p_DataLine
        Me.TrueDBGrid2.DataSource = p_Binding
        Me.TrueDBGrid2.Refresh()

    End Sub


    Function GetLoadingSite(ByVal p_LoaiVanChuyen As String) As String
        Dim p_Value As String
        Dim p_Count As Integer

        GetLoadingSite = "Sat"
        Try
            If Not p_TablePara Is Nothing Then
                For p_Count = 0 To p_TablePara.Rows.Count - 1
                    p_Value = p_TablePara.Rows(p_Count).Item("Value_nd").ToString.Trim
                    If InStr(p_Value, p_LoaiVanChuyen, CompareMethod.Text) > 0 Then
                        GetLoadingSite = p_TablePara.Rows(p_Count).Item("Para").ToString.Trim
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub FrmPhatHanhTichKe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim p_SQL As String

        p_SQL = ""
        If e.KeyCode.ToString.Trim = "F5" Then
            ToolStripButton2_Click(sender, e)
        End If
        If e.KeyCode.ToString.Trim = "F12" Then
            ToolStripButton4_Click(sender, e)
        End If
    End Sub

    Private Sub FrmPhatHanhTichKe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            'If Me.BtnOk.Text = Me.CaptionAdd And Me.FormStatus = False Then

            '    g_FormAddnew = True
            '    Me.FormStatus = True
            '    Me.Navigator1.Buttons.DoClick(Me.Navigator1.Buttons.Append)
            '    Me.SoLenh.Focus()
            '    Me.NgayXuat.EditValue = p_DateCreate
            '    Me.FormStatus = False

            'Else
            Me.SoTichKe.Focus()
            Me.GridView2.RefreshData()
            '  GridView2.SetFocusedRowModified()
            'GridView2.UpdateCurrentRow()
            'GridView2.RefreshEditor(True)
            Me.Focus()


            If Me.FormStatus = True Then
                SaveRecode()
            End If
        End If
    End Sub

    Private Function getClient(ByVal p_MaVanChuyen) As String
        Dim p_ArrRow() As DataRow
        Dim p_Datatable As DataTable
        Dim p_HangHoa07 As String = ""
        Dim p_Binding As New U_TextBox.U_BindingSource
        Try
            getClient = g_Terminal

            p_ArrRow = p_TablePara.Select("Para='FO'")
            If p_ArrRow.Length > 0 Then
                p_HangHoa07 = p_ArrRow(0).Item("Value_nd").ToString.Trim
            End If
            If p_HangHoa07 = "" Then
                Exit Function
            End If
            If g_Company_Code = "2110" Then  'Dung rieng cho KV1
                p_Binding = Me.GridView1.DataSource
                p_Datatable = CType(p_Binding.DataSource, DataTable)
                p_ArrRow = p_Datatable.Select("MaHangHoa like '" & p_HangHoa07 & "%'")
                If p_ArrRow.Length > 0 Then
                    p_ArrRow = p_TableClient.Select("Client1='FO'")
                    If p_ArrRow.Length > 0 Then
                        getClient = p_ArrRow(0).Item("Client").ToString.Trim
                    End If
                Else
                    Select Case UCase(p_MaVanChuyen)
                        Case "BO"
                            p_ArrRow = p_TableClient.Select("Client1='XITEC'")
                            If p_ArrRow.Length > 0 Then
                                getClient = p_ArrRow(0).Item("Client").ToString.Trim
                            End If
                        Case "SAT"
                            p_ArrRow = p_TableClient.Select("Client1='WAGON'")
                            getClient = p_ArrRow(0).Item("Client").ToString.Trim
                    End Select
                End If


            End If

        Catch ex As Exception

        End Try
    End Function


    Private Sub ComboTableid_Add()
        'p_Module.p_ModComboboxAddValue(Me.U_Status, "1", "Mở")
        'p_Module.p_ModComboboxAddValue(Me.U_Status, "2", "Hủy")
        'p_Module.p_ModComboboxAddValue(Me.U_Status, "3", "Đóng")
        'p_Module.p_ModComboboxAddValue(Me.U_Status, "4", "Đã đẩy API")
        'p_Module.p_ModComboboxAddValue(Me.U_Status, "5", "Đang thực hiện hoàn tất")
    End Sub
    Private Sub FrmTaoMoiLenhXuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim p_SQL As String
        Dim p_DataRow() As DataRow
        Dim p_DataSet As DataSet
        Dim p_MaVanChuyen As String
        Dim p_MacDinh As String = ""
        Dim p_Status As String = ""
        Dim p_column As U_TextBox.GridColumn
        Dim p_column1 As U_TextBox.GridColumn
        p_XtraUserName = g_User_ID
        Set_Grid_Property()
        p_GetDateTime(p_DateCreate, p_TimeCreate)

        p_Date_KV1 = p_DateCreate

        Me.ToolStripButton1.Visible = p_SHOW_QCI

        If g_KV1 = True Then
            Me.U_CheckBox1.Checked = True
        End If
        ResetChart()
        'Me.ChartControl2.Visible = False

        Dim p_Tbl As DataTable

        p_SQL = "select * from tblConfig"
        _dtVariable = GetDataTable(p_SQL, p_SQL)
        If Not _dtVariable Is Nothing Then
            If _dtVariable.Rows.Count > 0 Then
                _SapConnectionString = _dtVariable.Rows(0).Item("sapconnectionstring").ToString.Trim
                _WareHouse = _dtVariable.Rows(0).Item("WareHouse").ToString.Trim
                _ShPoint = _dtVariable.Rows(0).Item("shippingpoint").ToString.Trim
            End If
        End If



        'p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG"
        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG;" & _
                "select distinct client, UPPER(client) as Client1 from  tblMap_cp;" & _
                "select Para, Value_nd  from tblPara  where Para in ('Bo','Thuy','Sat', 'FO');" & _
                "SELECT [Code] FROM [FPT_DonViTinh_V];" & _
                "select  top 1 NhietDo from tblNhietDo with (Nolock) where  " & _
               " CONVERT(date,crDate)=(select MAX(crDate) from tblNhietDo with (Nolock) )	;"

        'p_SQL = "select Para, Value_nd  from tblPara  where Para in ('Bo','Thuy','Sat', 'FO')"

        'p_TablePara = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)

        'p_SQL = "SELECT [Code] FROM [FPT_DonViTinh_V]"

        'p_DataTableDVT = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)



        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_TableConfig = p_DataSet.Tables(0)
                p_TableClient = p_DataSet.Tables(1)

                p_TablePara = p_DataSet.Tables(2)
                p_DataTableDVT = p_DataSet.Tables(3)
                p_Tbl = p_DataSet.Tables(4)
            End If
        End If
        ' p_TableConfig = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_Tbl Is Nothing Then
            If p_Tbl.Rows.Count > 0 Then
                p_NhietDoNgay = p_Tbl.Rows(0).Item("NhietDo")
            End If
        End If
        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_DataRow = p_TableConfig.Select("KEYCODE='SYS_MALENH_S'")
                If p_DataRow.Length > 0 Then
                    p_SYS_MALENH_S = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                End If
                p_DataRow = p_TableConfig.Select("KEYCODE='TABLEID'")
                If p_DataRow.Length > 0 Then
                    p_FunctionTableId = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRow = p_TableConfig.Select("KEYCODE='SHOW_CLIENT'")
                If p_DataRow.Length > 0 Then
                    p_SHOW_CLIENT = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRow = p_TableConfig.Select("KEYCODE='MATUDONGHOA'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_MATUDONGHOA = True
                    End If
                End If

                p_DataRow = p_TableConfig.Select("KEYCODE='CURRENTDATE'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_CURRENTDATE = False
                    End If
                End If

                p_KHOA_PTIEN = "N"
                p_DataRow = p_TableConfig.Select("KEYCODE='KHOA_PTIEN'")
                If p_DataRow.Length > 0 Then
                    p_KHOA_PTIEN = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                    'If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "N" Then
                    '    p_CURRENTDATE = False
                    'End If
                End If

                'SHOW_QCI
                p_SHOW_QCI = False
                p_DataRow = p_TableConfig.Select("KEYCODE='SHOW_QCI'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_SHOW_QCI = True
                    End If
                End If

                'p_TaiTrongChoPhep
                p_DataRow = p_TableConfig.Select("KEYCODE='TAITRONGCHOPHEP'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        Try
                            p_TaiTrongChoPhep = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                        Catch ex As Exception

                        End Try
                    End If
                End If


                'CONGTO_BO


                p_CONGTO_BO = ""
                p_DataRow = p_TableConfig.Select("KEYCODE='CONGTO_BO'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        Try
                            p_CONGTO_BO = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                        Catch ex As Exception

                        End Try
                    End If
                End If


                p_PhuongTienAo = ""
                p_DataRow = p_TableConfig.Select("KEYCODE='PTIEN_AO'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        Try
                            p_PhuongTienAo = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                        Catch ex As Exception

                        End Try
                    End If
                End If


                p_KT_TAITRONG = True
                p_DataRow = p_TableConfig.Select("KEYCODE='KT_TAITRONG'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        Try
                            p_KT_TAITRONG = False
                        Catch ex As Exception

                        End Try
                    End If
                End If

            End If
        End If



        If g_SoLenh_Q = "" Then
            Me.SoLenh.EditValue = ""
            Me.g_FormAddnew = False
            Me.DefaultWhere = "SoLenh=''"
            Me.DefaultFormLoad = True
            Me.Form1_Load(sender, e)

            Me.Client.EditValue = g_Terminal
            ' Me.NgayXuat.EditValue = p_DateCreate
            'Me.BtnOk.Text = "Ok"
            Me.SoLenh.Focus()
            Me.g_FormAddnew = True
            Me.NgayXuat.EditValue = p_Date_KV1
        Else
            Me.DefaultFormLoad = True
            Me.Form1_Load(sender, e)
            'Me.FormEdit = False
            p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim




            Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)
            If Not Me.Status.EditValue Is Nothing Then
                If InStr(",3,31,4,5,", "," & Me.Status.EditValue.ToString.Trim & ",", CompareMethod.Text) > 0 Then
                    Me.ToolStripButton4.Enabled = p_InLaiTichKe
                    Me.FormEdit = False
                    Me.GridView2.OptionsBehavior.ReadOnly = True
                    Me.GridView1.OptionsBehavior.ReadOnly = True
                    Me.MaVanChuyen.Properties.ReadOnly = True

                    'anhqh  
                    '20160923
                    'anhqh
                    If g_KV1 = True Then
                        Me.NguoiVanChuyen.Properties.ReadOnly = False
                    Else
                        Me.NguoiVanChuyen.Properties.ReadOnly = True
                    End If

                    GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                Else
                    Me.ToolStripButton4.Enabled = True
                    Me.FormEdit = True
                    Me.GridView2.OptionsBehavior.ReadOnly = False
                    Me.GridView1.OptionsBehavior.ReadOnly = False
                    Me.MaVanChuyen.Properties.ReadOnly = False
                    Me.NguoiVanChuyen.Properties.ReadOnly = False
                    Me.GridView2.AllowInsert = True
                    If Me.Client.EditValue Is Nothing Then
                        p_MaVanChuyen = Me.LoaiXuat.EditValue
                        Me.Client.EditValue = GetClient(p_MaVanChuyen)  ' g_Terminal
                    Else
                        If Me.Client.EditValue.ToString.Trim = "" Then
                            Me.FormStatus = False
                            p_MaVanChuyen = Me.LoaiXuat.EditValue
                            Me.Client.EditValue = GetClient(p_MaVanChuyen)  ' g_Terminal
                            'Me.Client.EditValue = g_Terminal
                            GoTo Line_tt
                            '  Me.FormStatus = True
                        End If
                    End If
                    ' LenhGhep(p_Value)
                    GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
                End If
            End If
            If Me.Client.Text.ToString.Trim = "" Then
                Me.FormStatus = False
                ' Me.Client.EditValue = g_Terminal
                p_MaVanChuyen = Me.LoaiXuat.EditValue
                Me.Client.EditValue = GetClient(p_MaVanChuyen)
                '  GoTo Line_tt
                '  Me.FormStatus = True
            End If

            Me.FormStatus = False
Line_tt:
            p_LenhGhep = False
            GopTichKe()
            If p_SHOW_CLIENT = "0" Then
                Me.Client.Properties.ReadOnly = True
            End If

            If p_CURRENTDATE = True Then
                Me.NgayXuat.Enabled = False
            End If

            Me.GridView1.BestFitColumns()
            Me.GridView2.BestFitColumns()
            GanMaBeChoLenhXuat()
        End If

        If p_SHOW_CLIENT = "0" Then
            Me.Client.Properties.ReadOnly = True
        End If


        If p_CURRENTDATE = True Then
            Me.NgayXuat.Enabled = False
        End If

        LoadNewRow()
        If g_Filter_Terminal = True Then
            p_column = Me.GridView1.Columns.Item("BeXuat")

            p_SQL = "select Name_nd as [Bể xuất] from FPT_tblTankActive_V where Date1=:DateNgayXuat and Product_nd =:Column.MaHangHoa " & _
                  " and left(Name_nd,LEN ('" & g_Terminal & "')) like '" & g_Terminal & "%'  " & _
                    " and  (LoadingSite is null or LoadingSite ='' or upper(LoadingSite)=upper( :LoaiXuat ) )"
            p_column.SQLString = p_SQL



        End If

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If
        If p_Status.ToString.Trim = "1" Or p_Status.ToString.Trim = "2" Then
            Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Remove.Visible = True
        Else
            Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Remove.Visible = False
        End If

        If Me.U_ButtonCus1.Visible = True Then
            If p_Status.ToString.Trim <> "3" Then
                Me.U_ButtonCus1.Visible = False
            End If
        End If
        Try
            If p_MATUDONGHOA = True Then
                Me.GridView2.Columns.Item("MaTuDongHoa").VisibleIndex = 5
            Else
                Me.GridView2.Columns.Item("MaTuDongHoa").VisibleIndex = -1
            End If
        Catch ex As Exception

        End Try


        If g_TAITRONGKG = True Then
            Me.ToolStripButton11.Visible = True
            GridView1.OptionsView.ShowFooter = True
            Try
                GridView1.Columns.Item("QCI_KG").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

                GridView1.Columns.Item("QCI_KG").SummaryItem.FieldName = "QCI_KG"
                GridView1.Columns.Item("QCI_KG").SummaryItem.DisplayFormat = "{0:n0}"  ' GridView1.Columns.Item("QCI_KG").DisplayFormat.FormatString '   "{0:0}"
            Catch ex As Exception

            End Try

        Else
            Me.ToolStripButton11.Visible = False
            GridView1.Columns.Item("QCI_KG").VisibleIndex = -1
        End If

        Me.FormStatus = False

        '  Dim p_Column As U_TextBox.GridColumn
        p_column = Me.GridView1.Columns.Item("MeterId")

        Dim p_ColTypeButtonEdit As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        p_ColTypeButtonEdit = p_column.ColumnEdit
        AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click


        'p_column = Me.GridView2.Columns.Item("TableID")
        'p_ColTypeButtonEdit = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        'p_ColTypeButtonEdit = p_column.ColumnEdit
        'AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf GridView2_Column_Button_Click


        'p_column = Me.GridView2.Columns.Item("TableID")

        'Dim p_ColTypeComboBox As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox


        'AddHandler p_ColTypeComboBox.ButtonClick, AddressOf Column_Combobox_Click

        'p_column.ColumnEdit = p_ColTypeComboBox

        If g_KV1 = True Then
            p_SQL = "SELECT [MaPhuongTien], TuText as LoaiPhuongTien, SoNgan, LEFT(LaiXe,2) MaVanChuyen FROM fpt_tblPhuongTien_V where ( left([LaiXe],2)  = :MaVanChuyen or isnull( :MaVanChuyen ,'')='' )" & _
                    " and  CONVERT(date,getdate())>= CONVERT(date,ISNULL(NgayBatDau1,getdate())) 	and   CONVERT(date,getdate())<= CONVERT(date,ISNULL(NgayHieuLuc1,getdate())) "
            Me.MaPhuongTien.SqlString = p_SQL
            Me.MaPhuongTien.ItemReturn3 = "MaVanChuyen"
        End If
    End Sub


    Function CheckHangHoaE5(ByVal p_MaHangHoa As String) As Boolean
        '  Dim p_Count As Integer
        Dim p_DataRow() As DataRow

        CheckHangHoaE5 = False
        Try
            'If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
            '    Return True
            'End If
            p_DataRow = g_HangHoaToScada2.Select("MaHangHoa='" & p_MaHangHoa & "'")
            If p_DataRow.Length > 0 Then
                Return True
            End If
        Catch ex As Exception

        End Try

    End Function


    Private Function CongTo_Bo() As Boolean
        Dim p_Column2 As U_TextBox.GridColumn
        Dim p_MaVanChuyen As String = ""
        Dim p_MaHangHoa As String
        Dim p_RowArr() As DataRow
        p_Column2 = Me.GridView1.FocusedColumn

        If p_CONGTO_BO = "N" Then
            p_MaHangHoa = Me.GridView1.GetFocusedRowCellValue("MaHangHoa").ToString.Trim
            p_RowArr = g_HangHoaToScada2.Select("MaHangHoa='" & p_MaHangHoa & "'")
            If p_RowArr.Length > 0 Then
                Return False
            End If
            ' p_MaHangHoa = g_HangHoaToScada2.Rows(0).Item(0)
            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            p_MaVanChuyen = GetLoadingSite(p_MaVanChuyen)
            If UCase(p_MaVanChuyen) = "BO" Then
                If UCase(p_Column2.FieldView.ToString.Trim) = UCase("MeterId") Then
                    Return True
                End If
            End If

        End If
        Return False
    End Function

    Public Sub Column_Combobox_Click()
        Dim p_Column As New U_TextBox.GridColumn
        'Dim p_Column1 As New U_TextBox.GridColumn
        'Dim p_Column2 As New U_TextBox.GridColumn
        Dim p_DataTable As DataTable
        Dim p_Combobox As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
        Dim p_Count As Integer

        Dim p_Binding As New U_TextBox.U_BindingSource


        p_Column = Me.GridView2.Columns.Item("TableID")

        '  p_Combobox = p_Column.ColumnEdit

        'For p_Count=p_Combobox.It
        'Next

        '  If UCase(p_Column.FieldView) = "TABLEID" Then
        p_Binding = Me.GridView1.DataSource
        p_DataTable = CType(p_Binding.DataSource, DataTable)
        'ombobox.
        p_Combobox.Appearance.Font = New Font("Tahoma", 12, FontStyle.Regular)
        p_Combobox.AppearanceDropDown.Font = New Font("Tahoma", 12, FontStyle.Regular)


        For p_Count = 0 To p_DataTable.Rows.Count - 1
            If p_DataTable.Rows(p_Count).RowState = DataRowState.Deleted Or p_DataTable.Rows(p_Count).RowState = DataRowState.Detached Then
                Continue For
            End If
            Try
                p_Combobox.Items.Add(p_DataTable.Rows(p_Count).Item("TableID").ToString.Trim)
            Catch ex As Exception

            End Try

        Next
        'End If

        p_Combobox.Items.Add(" ")

        p_Column.ColumnEdit = p_Combobox
    End Sub


    Public Sub Column_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_Column As New U_TextBox.GridColumn
        Dim p_Column1 As New U_TextBox.GridColumn
        Dim p_Column2 As New U_TextBox.GridColumn

        Dim p_ButtonEdit As New DevExpress.XtraEditors.ButtonEdit

        Dim p_SQL As String
        Dim p_DataRow As DataRow
        Dim p_MaVanChuyen As String = ""
        Dim p_HangHoa As String = ""
        Dim p_HangHoaE5 As Boolean
        p_DataRow = Me.GridView1.GetFocusedDataRow
        p_HangHoa = p_DataRow.Item("MaHangHoa").ToString.Trim

        p_HangHoaE5 = False
        p_HangHoaE5 = CheckHangHoaE5(p_HangHoa)


        '  p_ButtonEdit = CType(sender, DevExpress.XtraEditors.ButtonEdit)

        'p_Column2 = Me.GridView1.FocusedColumn

        'If p_CONGTO_BO = "N" Then
        '    If Not Me.MaVanChuyen.EditValue Is Nothing Then
        '        p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
        '    End If
        '    p_MaVanChuyen = GetLoadingSite(p_MaVanChuyen)
        '    If UCase(p_MaVanChuyen) = "BO" Then
        '        If UCase(p_Column2.FieldView.ToString.Trim) = UCase("MeterId") Then
        '            Exit Sub
        '        End If
        '    End If

        'End If
        If CongTo_Bo() = True Then
            Exit Sub
        End If
        ' p_Column1 = Me.GridView1.Columns.Item("MeterId")
        If g_Filter_Terminal = True Then  'Rieng cho KV2  C1= kho A;  C2=Kho B; C3= Kho C
            Select Case g_Terminal
                Case "A"
                    p_SQL = "select MeterId  as [Công tơ] , TankE5 as 'Bể xuất' from FPT_MeterAll  where LoadingSite=:LoaiXuat " & IIf(p_HangHoaE5 = True, " and TankE5  =:Column.BeXuat ", " ") & "  and ProductCode=:Column.MaHangHoa " & _
                                  " and MeterId   like  'C1%' "
                    p_Column1 = Me.GridView1.Columns.Item("MeterId")
                    p_Column1.SQLString = p_SQL
                    p_Column1.CFLReturn1 = ""

                Case "B"
                    p_SQL = "select MeterId  as [Công tơ] , TankE5 as 'Bể xuất' from FPT_MeterAll  where LoadingSite=:LoaiXuat " & IIf(p_HangHoaE5 = True, " and TankE5  =:Column.BeXuat ", " ") & " and ProductCode=:Column.MaHangHoa " & _
                                  " and MeterId   like 'C2%' "
                    p_Column1 = Me.GridView1.Columns.Item("MeterId")
                    p_Column1.SQLString = p_SQL
                    p_Column1.CFLReturn1 = ""

                Case "C"
                    p_SQL = "select MeterId  as [Công tơ] , TankE5 as 'Bể xuất' from FPT_MeterAll  where LoadingSite=:LoaiXuat " & IIf(p_HangHoaE5 = True, " and TankE5  =:Column.BeXuat ", " ") & " and ProductCode=:Column.MaHangHoa " & _
                                  " and MeterId   like 'C3%' "
                    p_Column1 = Me.GridView1.Columns.Item("MeterId")
                    p_Column1.SQLString = p_SQL
                    p_Column1.CFLReturn1 = ""

                Case Else
                    p_SQL = "select MeterId  as [Công tơ] , TankE5 as 'Bể xuất' from FPT_MeterAll  where LoadingSite=:LoaiXuat and ProductCode=:Column.MaHangHoa " & _
                    " "
                    ' p_Column1 = Me.GridView1.Columns.Item("MeterId")
                    p_Column1.SQLString = p_SQL
                    p_Column1.CFLReturn1 = ""
            End Select

        ElseIf g_CONGTOBEXUAT = False Then
            p_SQL = "select MeterId  as [Công tơ] , TankE5 as 'Bể xuất' from FPT_MeterAll  where LoadingSite=:LoaiXuat and ProductCode=:Column.MaHangHoa " & _
                    " "
            p_Column1 = Me.GridView1.Columns.Item("MeterId")
            p_Column1.SQLString = p_SQL
            p_Column1.CFLReturn1 = ""
            'Else
            '    p_SQL = "select MeterId  as [Công tơ] , TankE5 as 'Bể xuất' from FPT_MeterAll  where LoadingSite=:LoaiXuat and ProductCode=:Column.MaHangHoa " & _
            '            " and TankE5  =:Column.BeXuat  and TankE5 is not null and TankE5 <>''"
            '    p_column1 = Me.GridView1.Columns.Item("MeterId")
            '    p_column1.SQLString = p_SQL
        Else
            p_Column1 = Me.GridView1.Columns.Item("MeterId")
        End If
        p_Column1.ButtonClick = True

        Me.Gridview_Column_Button_Click(sender, e)
        p_Column1.ButtonClick = False
    End Sub





    Public Sub GridView2_Column_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_Column As New U_TextBox.GridColumn
        Dim p_Column1 As New U_TextBox.GridColumn
        Dim p_Column2 As New U_TextBox.GridColumn

        Dim p_ButtonEdit As New DevExpress.XtraEditors.ButtonEdit

        Dim p_SQL As String
        Dim p_DataRow As DataRow
        Dim p_MaVanChuyen As String = ""
        Dim p_HangHoa As String = ""
        Dim p_HangHoaE5 As Boolean
        p_DataRow = Me.GridView2.GetFocusedDataRow
        p_HangHoa = p_DataRow.Item("MaHangHoa").ToString.Trim

        p_HangHoaE5 = False
        p_HangHoaE5 = CheckHangHoaE5(p_HangHoa)


        '  p_ButtonEdit = CType(sender, DevExpress.XtraEditors.ButtonEdit)

        'p_Column2 = Me.GridView1.FocusedColumn

        'If p_CONGTO_BO = "N" Then
        '    If Not Me.MaVanChuyen.EditValue Is Nothing Then
        '        p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
        '    End If
        '    p_MaVanChuyen = GetLoadingSite(p_MaVanChuyen)
        '    If UCase(p_MaVanChuyen) = "BO" Then
        '        If UCase(p_Column2.FieldView.ToString.Trim) = UCase("MeterId") Then
        '            Exit Sub
        '        End If
        '    End If

        'End If

        p_Column1.ButtonClick = True
        Me.Gridview_Column_Button_Click(sender, e)
        p_Column1.ButtonClick = False
    End Sub


    Private Sub GetTaiTrongKG(ByVal p_NhietDoN As Double, Optional ByVal p_TinhLaiTaiTrong As Boolean = False)

        Dim p_SQL As String = ""
        Dim p_DataTable As DataTable
        ' Dim p_DataTable1 As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_BeXuat As String = ""
        Dim p_Count As Integer
        Dim p_DataRow() As DataRow
        Dim p_Row As DataRow
        Dim p_SoLuong As Double

        Dim p_SoLenh As String = ""

        Dim l_quantity As Decimal() = New Decimal() {0, 0, 0, 0}
        Try
            p_SQL = ""
            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_SQL = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            p_SQL = GetLoadingSite(p_SQL)
            If UCase(p_SQL) <> "BO" Then
                Exit Sub
            End If
            p_Binding = Me.GridView1.DataSource
            p_DataTable = CType(p_Binding.DataSource, DataTable)

            For p_Count = 0 To p_DataTable.Rows.Count - 1
                If p_DataTable.Rows(p_Count).RowState = DataRowState.Deleted Then
                    Continue For
                End If
                If p_DataTable.Rows(p_Count).Item("BeXuat").ToString.Trim <> "" Then
                    p_BeXuat = p_BeXuat & "," & p_DataTable.Rows(p_Count).Item("BeXuat").ToString.Trim
                End If
            Next

            If p_BeXuat <> "" Then
                p_BeXuat = p_BeXuat & ","
            End If

            If p_TinhLaiTaiTrong = True Then
                For p_Count = 0 To Me.GridView1.RowCount - 1
                    Me.GridView1.SetRowCellValue(p_Count, "QCI_KG", 0)
                Next
            End If

            If Not Me.SoLenh.EditValue Is Nothing Then
                p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
            End If

            If p_BeXuat.ToString.Trim = "" And Mid(p_SoLenh, 1, Len(g_WareHouse)) <> g_WareHouse Then
                ShowMessageBox("", "Bể xuất chưa được chọn")
                Exit Sub
            End If
            p_SQL = " exec FPT_GetTaiTrongKG '" & p_BeXuat & "'," & p_NhietDoN & ",'" & g_UserName & "'"
            p_DataTable = GetDataTable(p_SQL, p_SQL)

            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    For p_Count = 0 To Me.GridView1.RowCount - 1
                        p_Row = GridView1.GetDataRow(p_Count)
                        If Not p_Row Is Nothing Then
                            If p_Row.Item("QCI_KG").ToString.Trim <> "" Then
                                If p_Row.Item("QCI_KG") > 0 Then
                                    Continue For
                                End If
                            End If
                            If p_Row.Item("BeXuat").ToString.Trim <> "" Then
                                p_DataRow = p_DataTable.Select("Name_nd='" & p_Row.Item("BeXuat").ToString.Trim & "'")
                                If p_DataRow.Length > 0 Then
                                    Double.TryParse(p_Row.Item("TongXuat").ToString.Trim, p_SoLuong)
                                    ' l_quantity = mdlQCI_CalculateQCI("", p_SoLuong, "L", p_NhietDoN, IIf(p_DataRow(0).Item("TyTrong").ToString.Trim = "", 0.688, p_DataRow(0).Item("TyTrong").ToString.Trim))


                                    l_quantity = mdlQCI_CalculateQCI_NS("", p_SoLuong, "L", p_NhietDoN, IIf(p_DataRow(0).Item("TyTrong").ToString.Trim = "", 0.688, p_DataRow(0).Item("TyTrong").ToString.Trim))

                                    Me.GridView1.SetRowCellValue(p_Count, "QCI_KG", l_quantity(3))

                                    Me.GridView1.SetRowCellValue(p_Count, "QCI_NhietDo", p_NhietDoN)
                                    Me.GridView1.SetRowCellValue(p_Count, "CHECKUPD", "Y")
                                    Me.GridView1.SetRowCellValue(p_Count, "QCI_TyTrong", IIf(p_DataRow(0).Item("TyTrong").ToString.Trim = "", 0.688, p_DataRow(0).Item("TyTrong").ToString.Trim))
                                End If
                            End If
                        End If
                    Next
                End If
            End If
            Me.GridView1.RefreshData()

        Catch ex As Exception
            ShowMessageBox("", ex.Message)
        End Try

        CallChartBar3D()
    End Sub




    Private Sub Set_Grid_Property()
        Dim p_SQL As String
        Dim p_DataTable As DataTable

        Try
            p_SQL = "select * from SYS_USER where User_ID=" & IIf(g_User_ID.ToString.Trim = "", 0, g_User_ID)
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    If p_DataTable.Rows(0).Item("InTichKe").ToString.Trim = "Y" Then
                        p_InLaiTichKe = True
                    Else
                        p_InLaiTichKe = False
                    End If

                    If p_DataTable.Rows(0).Item("HuyTichKe").ToString.Trim = "Y" Then
                        ' Me.GridView2.Columns.Item("NhietDo").OptionsColumn.ReadOnly = False
                        U_ButtonCus1.Visible = True
                        p_HuyTichKe = True
                    Else
                        U_ButtonCus1.Visible = False
                        p_HuyTichKe = False
                        'Me.GridView2.Columns.Item("NhietDo").OptionsColumn.ReadOnly = True
                    End If

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub SoLenh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SoLenh.KeyDown
        Dim p_ValueTmp As String = "0000000000"
        Dim p_Value As String
        Dim p_MaVanChuyen As String
        Dim p_DataTable As DataTable
        Dim p_SQL As String
        Dim p_PhuongTien As String
        Dim p_Status As String

        Dim p_Table As DataTable
        Dim p_Table1 As DataTable
        Dim p_Client As String

        If e.KeyCode = Keys.Enter Then
            p_Client = GetClient(p_MaVanChuyen)
            If g_KV1 = True Then
                If Not Me.NgayXuat.EditValue Is Nothing Then
                    If Me.NgayXuat.EditValue.ToString.Trim <> "" Then
                        p_Date_KV1 = Me.NgayXuat.EditValue
                    End If
                End If
            End If
            If Not Me.SoLenh.EditValue Is Nothing Then
                'Me.GridView2.AllowInsert = False
                If Me.SoLenh.EditValue.ToString.Trim <> "" Then
                    Cursor = Cursors.WaitCursor
                    p_Value = Me.SoLenh.EditValue.ToString.Trim

                    p_SQL = "select top 1 SoLenh from tblLenhXuatE5 with (Nolock) where SoLenh='" & p_Value & "'"
                    p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                    If Not p_DataTable Is Nothing Then
                        If p_DataTable.Rows.Count <= 0 Then

                            If g_WCF = False Then

                                Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
                                'If p_SAP_Object.clsCheckSAPConnection("", p_SQL) = False Then

                                'End If
                                If g_KV1 = True Then
                                    If p_SAP_Object.kv1clsSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_Value, p_SQL, p_Date_KV1) = False Then
                                        'If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                        'ShowStatusMessage(True, "", p_SQL, 10)
                                        ' Me.DefaultWhere = "SoLenh='00'"
                                        'MsgBox("Error:" & p_SQL)
                                        Cursor = Cursors.Default
                                        ShowMessageBox("", p_SQL)
                                        Exit Sub
                                    Else
                                        Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                        Me.DefaultFormLoad = True
                                        Me.Form1_Load(sender, e)
                                        Me.SoLenh.Properties.ReadOnly = False
                                        Me.SoLenh.BackColor = pv_Required_Back_Color

                                        GoTo Line_tt2
                                        ''MsgBox("bbb")
                                    End If
                                Else
                                    If p_SAP_Object.clsSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                        'If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                        'ShowStatusMessage(True, "", p_SQL, 10)
                                        ' Me.DefaultWhere = "SoLenh='00'"
                                        'MsgBox("Error:" & p_SQL)
                                        Cursor = Cursors.Default
                                        ShowMessageBox("", p_SQL)
                                        Exit Sub
                                    Else
                                        Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                        Me.DefaultFormLoad = True
                                        Me.Form1_Load(sender, e)
                                        Me.SoLenh.Properties.ReadOnly = False
                                        Me.SoLenh.BackColor = pv_Required_Back_Color

                                        GoTo Line_tt2
                                        ''MsgBox("bbb")
                                    End If
                                End If

                            Else
                                'If g_Services.clsCheckSAPConnection("", p_SQL) = False Then
                                '    MsgBox(p_SQL)
                                'End If
                                If g_KV1 = True Then
                                    If g_Services.kv1clsSyncDeliveries_SynSpecific(p_Client, g_User_ID, g_Company_Code, p_Value, p_SQL, p_Date_KV1) = False Then
                                        'If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                        ' ShowMessageBox("", p_SQL)
                                        ' Me.DefaultWhere = "SoLenh='00'"
                                        'MsgBox("Error:" & p_SQL)
                                        Cursor = Cursors.Default
                                        ShowMessageBox("", p_SQL)
                                        Exit Sub
                                    Else
                                        Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                        Me.DefaultFormLoad = True
                                        Me.Form1_Load(sender, e)
                                        Me.SoLenh.Properties.ReadOnly = False
                                        Me.SoLenh.BackColor = pv_Required_Back_Color

                                        'p_PhuongTien = ""
                                        'If Not Me.MaPhuongTien.EditValue Is Nothing Then
                                        '    p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.ToString
                                        'End If
                                        'If p_PhuongTien <> "" Then
                                        '    LoadDefault(p_PhuongTien)
                                        'End If
                                        GoTo Line_tt2
                                    End If
                                Else
                                    If g_Services.mdlSyncDeliveries_SynSpecific(p_Client, g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                        'If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                        ' ShowMessageBox("", p_SQL)
                                        ' Me.DefaultWhere = "SoLenh='00'"
                                        'MsgBox("Error:" & p_SQL)
                                        Cursor = Cursors.Default
                                        ShowMessageBox("", p_SQL)
                                        Exit Sub
                                    Else
                                        Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                        Me.DefaultFormLoad = True
                                        Me.Form1_Load(sender, e)
                                        Me.SoLenh.Properties.ReadOnly = False
                                        Me.SoLenh.BackColor = pv_Required_Back_Color

                                        'p_PhuongTien = ""
                                        'If Not Me.MaPhuongTien.EditValue Is Nothing Then
                                        '    p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.ToString
                                        'End If
                                        'If p_PhuongTien <> "" Then
                                        '    LoadDefault(p_PhuongTien)
                                        'End If
                                        GoTo Line_tt2
                                    End If
                                End If
                                'If g_Services.mdlSyncDeliveries_SynSpecific(p_Client, g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                '    'If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                '    ' ShowMessageBox("", p_SQL)
                                '    ' Me.DefaultWhere = "SoLenh='00'"
                                '    'MsgBox("Error:" & p_SQL)
                                '    Cursor = Cursors.Default
                                '    ShowMessageBox("", p_SQL)
                                '    Exit Sub
                                'Else
                                '    Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                '    Me.DefaultFormLoad = True
                                '    Me.Form1_Load(sender, e)
                                '    Me.SoLenh.Properties.ReadOnly = False
                                '    Me.SoLenh.BackColor = pv_Required_Back_Color

                                '    'p_PhuongTien = ""
                                '    'If Not Me.MaPhuongTien.EditValue Is Nothing Then
                                '    '    p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.ToString
                                '    'End If
                                '    'If p_PhuongTien <> "" Then
                                '    '    LoadDefault(p_PhuongTien)
                                '    'End If
                                '    GoTo Line_tt2
                                'End If
                            End If


                        End If
                    End If
Line_TT1:
                    If Not Me.Status.EditValue Is Nothing Then
                        If InStr(",31,4,5,", "," & Me.Status.EditValue.ToString.Trim & ",", CompareMethod.Text) > 0 Then
                            GridView1.AllowInsert = False
                            GridView2.AllowInsert = False
                        Else
                            GridView2.AllowInsert = True
                            Me.GridView2.OptionsBehavior.ReadOnly = False

                        End If
                    End If

                    Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                    Me.DefaultFormLoad = True
                    Me.Form1_Load(sender, e)

                    'If g_KV1 = True Then
                    '    If Me.Status.EditValue.ToString.Trim = "1" Or Me.Status.EditValue.ToString.Trim = "2" Or Me.Status.EditValue.ToString.Trim = "" Then
                    '        Try
                    '            If Me.NgayXuat.EditValue < p_Date_KV1 Then
                    '                Me.NgayXuat.EditValue = p_Date_KV1
                    '            End If
                    '            '  Me.NgayXuat.EditValue = p_Date_KV1
                    '            Me.DefaultSave = True
                    '            Me.UpdateToDatabase(Me, "")
                    '            Me.DefaultSave = True
                    '        Catch ex As Exception

                    '        End Try

                    '    End If
                    'End If
Line_TT2:

                    If g_KV1 = True Then
                        If Me.Status.EditValue.ToString.Trim = "1" Or Me.Status.EditValue.ToString.Trim = "2" Or Me.Status.EditValue.ToString.Trim = "" Then
                            Try
                                If Me.NgayXuat.EditValue < p_Date_KV1 Then
                                    Me.NgayXuat.EditValue = p_Date_KV1
                                End If
                                '  Me.NgayXuat.EditValue = p_Date_KV1
                                'Me.DefaultSave = True
                                'Me.UpdateToDatabase(Me, "")
                                'Me.DefaultSave = True
                            Catch ex As Exception

                            End Try

                        End If
                    End If

                    p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
                    Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)

                    ' LoadNewRow()
                    Me.MaPhuongTien.UpdateWhenFormLock = False

                    If Not Me.Status.EditValue Is Nothing Then
                        If InStr(",3,31,4,5,", "," & Me.Status.EditValue.ToString.Trim & ",", CompareMethod.Text) > 0 Then
                            Me.ToolStripButton4.Enabled = p_InLaiTichKe
                            Me.FormEdit = False
                            Me.GridView2.OptionsBehavior.ReadOnly = True
                            Me.GridView1.OptionsBehavior.ReadOnly = True
                            Me.MaVanChuyen.Properties.ReadOnly = True
                            'Me.NguoiVanChuyen.Properties.ReadOnly = True
                            If g_KV1 = True Then
                                Me.NguoiVanChuyen.Properties.ReadOnly = False
                            Else
                                Me.NguoiVanChuyen.Properties.ReadOnly = True
                            End If
                            GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                            If Me.Status.EditValue.ToString.Trim = "31" Or Me.Status.EditValue.ToString.Trim = "3" Then
                                ' Me.MaPhuongTien.Properties.ReadOnly = False
                                Me.MaPhuongTien.UpdateWhenFormLock = True
                            End If
                        Else
                            Me.ToolStripButton4.Enabled = True
                            Me.FormEdit = True
                            Me.GridView2.OptionsBehavior.ReadOnly = False
                            Me.GridView1.OptionsBehavior.ReadOnly = False
                            Me.MaVanChuyen.Properties.ReadOnly = False
                            Me.NguoiVanChuyen.Properties.ReadOnly = False
                            Me.GridView2.AllowInsert = True
                            If Me.Client.EditValue Is Nothing Then
                                '.Client.EditValue = g_Terminal
                                p_MaVanChuyen = Me.LoaiXuat.EditValue
                                Me.Client.EditValue = GetClient(p_MaVanChuyen)
                            Else
                                If Me.Client.EditValue.ToString.Trim = "" Then
                                    Me.FormStatus = False
                                    ' Me.Client.EditValue = g_Terminal
                                    p_MaVanChuyen = Me.LoaiXuat.EditValue
                                    Me.Client.EditValue = GetClient(p_MaVanChuyen)
                                    GoTo Line_tt
                                    '  Me.FormStatus = True
                                End If
                            End If
                            ' LenhGhep(p_Value)
                            GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
                        End If
                    Else
                        Me.ToolStripButton4.Enabled = True
                    End If
                    Me.FormStatus = False
Line_tt:
                    GopTichKe()

                    'GanMaBeChoLenhXuat()
                    '  GopTichKe()
                    Cursor = Cursors.Default
                    'Me.BtnOk.Text = "Ok"
                End If
            End If
            LoadNewRow()
            Me.U_ButtonCus1.Visible = p_HuyTichKe
            p_Status = ""

            If Not Me.Status.EditValue Is Nothing Then
                p_Status = Me.Status.EditValue.ToString.Trim
            End If

            If p_Status.ToString.Trim = "1" Or p_Status.ToString.Trim = "2" Then
                Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Remove.Visible = True
            Else
                Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Remove.Visible = False
            End If
            If Me.U_ButtonCus1.Visible = True Then

                If p_Status.ToString.Trim <> "3" Then

                    Me.U_ButtonCus1.Visible = False
                End If
            End If

            '  Setfocus("SOLENH")
            Me.FormStatus = False
            If p_SHOW_CLIENT = "0" Then
                Me.Client.Properties.ReadOnly = True
            End If

            Me.GridView1.BestFitColumns()
            Me.GridView2.BestFitColumns()
            Me.MaPhuongTien.Focus()

        End If
        'Me.MaPhuongTien.Focus()

        ' Me.U_CheckBox1.Properties.NullText = "N"
        'Me.U_CheckBox1.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
    End Sub


    Private Sub Setfocus(ByVal p_ItemName As String)
        Select Case UCase(p_ItemName)
            Case "SOLENH"
                Me.MaVanChuyen.Focus()
            Case "MAVANCHUYEN"
                Me.MaPhuongTien.Focus()
            Case "MAPHUONGTIEN"
                Me.NguoiVanChuyen.Focus()
            Case "NGUOIVANCHUYEN"
                Me.GridView2.Focus()
        End Select
    End Sub

    Sub LoadNewRow()
        Exit Sub

        Dim p_DataTable As DataTable
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_Count As Integer
        Dim p_dataRow As DataRow
        Dim p_FormStatus As Boolean
        p_Binding = Me.TrueDBGrid2.DataSource
        p_DataTable = CType(p_Binding.DataSource, DataTable)
        p_Count = p_DataTable.Rows.Count

        ' GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        p_FormStatus = Me.FormStatus
        While p_Count <= 20
            'p_dataRow = p_DataTable.NewRow

            'p_DataTable.Rows.Add(p_dataRow)
            Me.GridView2.AddNewRow()
            'Me.GridView2.SetFocusedRowCellValue("CHECKUPD", "")
            p_Count = p_Count + 1
        End While


        ' p_Binding.DataSource = p_DataTable
        ' Me.TrueDBGrid2.DataSource = p_Binding

        p_Binding = Me.TrueDBGrid2.DataSource
        p_DataTable = CType(p_Binding.DataSource, DataTable)

        For p_Count = 0 To p_DataTable.Rows.Count - 1
            If p_DataTable.Rows(p_Count).Item("MaNgan").ToString.Trim = "" Then
                p_DataTable.Rows(p_Count).Item("CHECKUPD") = ""
            End If

        Next

        p_Binding.DataSource = p_DataTable
        Me.TrueDBGrid2.DataSource = p_Binding

        '' Me.TrueDBGrid2.Refresh()
        'Me.GridView2.RefreshData()
        Me.GridView2.MoveFirst()
        Me.FormStatus = p_FormStatus

    End Sub

    Sub LoadDefault(ByVal p_PhuongTien As String)
        Dim p_TableLine As New DataTable
        Dim p_Binding As New BindingSource
        Dim p_Column As DataColumn
        Dim p_TableNgan As New DataTable
        Dim p_DataRow As DataRow
        Dim p_NgayXuat As Date
        Dim p_Count As Integer
        Dim p_SQL As String
        p_Binding = Me.TrueDBGrid1.DataSource
        p_TableLine = CType(p_Binding.DataSource, DataTable)
        Dim p_LoaiXuat As String = ""

        Dim p_DataTableOld As DataTable
        Dim p_ArrRow() As DataRow
        Dim p_BindingOld As U_TextBox.U_BindingSource
        Dim p_SoLenh As String = ""
        Dim p_MaPhuongTien As String = ""
        Dim p_NguiVanChuyen As String = ""
        p_LoaiXuat = ""

        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            p_LoaiXuat = Me.MaVanChuyen.EditValue.ToString.Trim
        End If
        p_LoaiXuat = GetLoadingSite(p_LoaiXuat)
        Load1(p_PhuongTien, p_TableLine, p_TableNgan, p_LoaiXuat)


        If Not p_TableNgan Is Nothing Then
            Cursor = Cursors.WaitCursor
            GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            p_Count = 0
            While Me.GridView2.RowCount - 1 >= 0 And p_Count < 100
                Try
                    p_Count = p_Count + 1
                    p_DataRow = GridView2.GetDataRow(Me.GridView2.RowCount - 1)
                    If p_DataRow.Item("Row_id").ToString.Trim <> "" Then
                        p_SQL = p_DataRow.Item("Row_id").ToString.Trim
                        p_SQL = "Delete from tblLenhXuatChiTietE5 where  Row_id=" & p_SQL
                        p_DataRow = Me.pv_LineRemove.NewRow
                        p_DataRow.Item(0) = p_SQL
                        Me.pv_LineRemove.Rows.Add(p_DataRow)
                    End If
                    GridView2.DeleteRow(Me.GridView2.RowCount - 1)
                Catch ex As Exception

                End Try
            End While
            p_Binding = Me.TrueDBGrid2.DataSource
            p_TableLine = CType(p_Binding.DataSource, DataTable)
            p_TableLine.Clear()
            For p_Count = 0 To p_TableNgan.Rows.Count - 1
                p_DataRow = p_TableLine.NewRow

                For p_Col = 0 To p_TableLine.Columns.Count - 1
                    p_Column = p_TableLine.Columns.Item(p_Col)

                    If UCase(p_Column.ColumnName.ToString.Trim) = "NGAYXUAT" Then
                        If Not Me.NgayXuat.EditValue Is Nothing Then
                            p_NgayXuat = Me.NgayXuat.EditValue
                            p_DataRow.Item(p_Column.ColumnName) = p_NgayXuat
                        End If
                    End If
                    Try
                        'GridView2.SetRowCellValue(GridView2.FocusedRowHandle, p_Column.FieldView, p_TableNgan.Rows(p_Count).Item(p_Column.FieldView).ToString.Trim)
                        p_DataRow.Item(p_Column.ColumnName) = p_TableNgan.Rows(p_Count).Item(p_Column.ColumnName).ToString.Trim
                    Catch ex As Exception

                    End Try

                Next
                p_DataRow.Item("CHECKUPD") = "R"
                p_TableLine.Rows.Add(p_DataRow)
            Next
            p_DataRow = p_TableLine.NewRow
            p_TableLine.Rows.Add(p_DataRow)
            p_Binding.DataSource = p_TableLine
            Me.TrueDBGrid2.DataSource = p_Binding
            'GridView2.RefreshData()
            GridView2.OptionsBehavior.Editable = True
            Me.FormStatus = True
            Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
            GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom



            If Not Me.SoLenh.EditValue Is Nothing Then
                p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
            End If

            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_MaPhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
            End If

            If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
                p_NguiVanChuyen = Me.NguoiVanChuyen.EditValue.ToString.Trim
            End If
            p_SQL = "select SoLenh, (select top 1 TenKhachHang  from tblKhachHang b with (nolock) where a.MaKhachHang =b.MaKhachHang ) TenKhachHang " & _
                        " from tblLenhXuatE5 a with (nolock)   where   SoLenh = '" & p_SoLenh & "'"


            p_BindingOld = Me.TrueDBGrid3.DataSource
            p_DataTableOld = CType(p_BindingOld.DataSource, DataTable)
            p_TableLine = GetDataTable(p_SQL, p_SQL)
            If Not p_TableLine Is Nothing Then
                For p_Count = 0 To p_DataTableOld.Rows.Count - 1
                    If Not p_DataTableOld.Rows(p_Count) Is Nothing Then
                        p_ArrRow = p_TableLine.Select("SoLenh='" & p_DataTableOld.Rows(p_Count).Item("SoLenh") & "'")
                        If p_ArrRow.Length > 0 Then
                            Try
                                p_DataTableOld.Rows(p_Count).Item("TenKhachHang") = p_ArrRow(0).Item("TenKhachHang")
                            Catch ex As Exception
                                p_DataTableOld.Columns.Add("TenKhachHang")
                                p_DataTableOld.Rows(p_Count).Item("TenKhachHang") = p_ArrRow(0).Item("TenKhachHang")
                            End Try
                            p_DataTableOld.Rows(p_Count).Item("MaPhuongTien") = p_MaPhuongTien
                            p_DataTableOld.Rows(p_Count).Item("NguoiVanChuyen") = p_NguiVanChuyen

                        End If
                    End If

                Next

            End If
            'If Me.GridView2.RowCount > 0 Then

            'End If

            For p_Count = 0 To Me.GridView2.RowCount - 1
                Try
                    Me.GridView2.SetRowCellValue(p_Count, "CHECKUPD", "Y")
                Catch ex As Exception

                End Try
            Next
            p_BindingOld.DataSource = p_DataTableOld
            Me.TrueDBGrid3.DataSource = p_BindingOld
            TrueDBGrid3.RefreshDataSource()
            Me.GridView3.Columns.Item(0).FieldName = "SoLenh"
            Me.GridView3.Columns.Item(1).FieldName = "NgayXuat"
            Me.GridView3.Columns.Item(2).FieldName = "MaPhuongTien"
            Me.GridView3.Columns.Item(3).FieldName = "TenKhachHang"  ''
            Me.GridView3.Columns.Item(4).FieldName = "NguoiVanChuyen"  ''

            Me.GridView3.Columns.Item(4).FieldName = "MaNgan"
            Me.GridView3.Columns.Item(5).FieldName = "SoLuongDuXuat"
            Me.GridView3.Columns.Item(6).FieldName = "Status"

            Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
            Me.GridView3.OptionsBehavior.ReadOnly = True
            Me.GridView3.Columns(0).Group()
            Me.GridView3.ExpandAllGroups()
            GridView3.BestFitColumns()

            GepNganTrong()
            Cursor = Cursors.Default
        End If

    End Sub

    Private Function KiemtraKhacPTien() As Boolean
        Dim p_DataTable As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_Count As Integer
        Dim p_Ptien As String = ""
        Try
            KiemtraKhacPTien = True

            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_Ptien = Me.MaPhuongTien.EditValue.ToString.Trim
            End If

            If p_Ptien = "" Then
                Exit Function
            End If

            p_Binding = Me.GridView3.DataSource
            p_DataTable = CType(p_Binding.DataSource, DataTable)


            If p_DataTable.Rows.Count = 1 Then
                Try
                    p_DataTable.Rows(0).Item("MaPhuongTien") = p_Ptien
                Catch ex As Exception

                End Try

            End If
            For p_Count = 0 To p_DataTable.Rows.Count - 1

                If p_DataTable.Rows(p_Count).Item("MaPhuongTien").ToString.Trim <> "" And KiemTraPhuongTienAo(p_DataTable.Rows(p_Count).Item("MaPhuongTien").ToString.Trim) = False Then
                    If p_Ptien <> p_DataTable.Rows(p_Count).Item("MaPhuongTien").ToString.Trim Then
                        KiemtraKhacPTien = False
                        ShowMessageBox("", "Lệnh ghép phải cùng Mã phương tiện")
                        Exit Function
                    End If
                End If
            Next
        Catch ex As Exception
            KiemtraKhacPTien = False
        End Try
    End Function



    Private Sub GopTichKe(Optional ByVal SaveGhep As Boolean = False, Optional ByVal p_HuyTichKe As Boolean = False)
        Dim p_DataTable As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource

        Dim p_DataTableOld As DataTable
        Dim p_BindingOld As New U_TextBox.U_BindingSource
        Dim p_MaVanChuyen As String = ""
        Dim p_NguoiVanChuyen As String = ""
        Dim p_Count As Integer
        Dim p_SoLenh As String = ""
        Dim p_Status As String = ""
        Dim p_ArrRow() As DataRow
        Dim p_SoLenhGhep As String
        Dim p_SQL As String
        Dim p_RowData As DataRow
        Dim p_Count1 As Integer

        Dim p_Tmp As Decimal

        If Not Me.MaPhuongTien.EditValue Is Nothing Then
            p_MaVanChuyen = Me.MaPhuongTien.EditValue.ToString.Trim
        End If

        If p_DanhSachPTGhep = "" Then
            p_DanhSachPTGhep = p_MaVanChuyen
        End If

        If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
            p_NguoiVanChuyen = Me.NguoiVanChuyen.EditValue.ToString.Trim
        End If

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If p_Status = "1" Or p_Status = "2" Or p_Status = "" Then
            If p_PTien1 = "" Then
                If KiemTraPhuongTienAo(p_DanhSachPTGhep) = False Then
                    p_PTien1 = p_MaVanChuyen
                    p_NVC1 = p_NguoiVanChuyen
                End If
            Else
                'If p_MaVanChuyen = "" Then
                If KiemTraPhuongTienAo(p_MaVanChuyen) = True Then
                    Me.MaPhuongTien.EditValue = p_PTien1
                    Me.NguoiVanChuyen.EditValue = p_NVC1
                End If

            End If

            If p_NguoiVanChuyen.ToString.Trim = "" And p_NVC1.ToString.Trim <> "" Then
                Me.NguoiVanChuyen.EditValue = p_NVC1
            End If
        End If


Line_Start:

        'Goi ham khoa itemphuong tien
        LockPTien()

        GanMaBeChoLenhXuat()

        Me.GridView3.ClearGrouping()
        If Me.GridView3.RowCount <= 0 Or SaveGhep = True Then
            p_Binding = Me.GridView2.DataSource
            p_DataTable = CType(p_Binding.DataSource, DataTable)

            Try
                p_DataTable.Columns.Add("MaPhuongTien")
                p_DataTable.Columns.Add("NguoiVanChuyen")
                p_DataTable.Columns.Add("Status")

                p_DataTable.Columns.Add("TenKhachHang")
            Catch ex As Exception

            End Try
            For p_Count = p_DataTable.Rows.Count - 1 To 0 Step -1
                If p_DataTable.Rows(p_Count).Item("MaNgan").ToString.Trim = "" Then
                    p_DataTable.Rows.RemoveAt(p_Count)
                End If
            Next
            If p_DataTable.Rows.Count <= 0 Then
                Try
                    p_Binding = Me.GridView1.DataSource
                    p_DataTable = CType(p_Binding.DataSource, DataTable)

                    Try
                        p_DataTable.Columns.Add("MaNgan")
                        p_DataTable.Columns.Add("MaPhuongTien")
                        p_DataTable.Columns.Add("NguoiVanChuyen")
                        p_DataTable.Columns.Add("Status")

                        p_DataTable.Columns.Add("TenKhachHang")

                    Catch ex As Exception

                    End Try

                    p_SoLenhGhep = ""
                    p_LenhGhep = False
                    For p_Count = p_DataTable.Rows.Count - 1 To 0 Step -1
                        If p_SoLenhGhep = "" Then
                            p_SoLenhGhep = p_DataTable.Rows(p_Count).Item("SoLenh").ToString.Trim
                        Else
                            If p_SoLenhGhep <> p_DataTable.Rows(p_Count).Item("SoLenh").ToString.Trim Then
                                p_SoLenhGhep = p_SoLenhGhep & "," & p_DataTable.Rows(p_Count).Item("SoLenh").ToString.Trim
                                p_LenhGhep = True
                            End If
                        End If
                        p_DataTable.Rows(p_Count).Item("MaPhuongTien") = p_MaVanChuyen
                        p_DataTable.Rows(p_Count).Item("NguoiVanChuyen") = p_NguoiVanChuyen
                        p_DataTable.Rows(p_Count).Item("Status") = p_Status
                    Next

                Catch ex As Exception

                End Try
            Else
                p_SoLenhGhep = ""
                p_LenhGhep = False
                For p_Count = p_DataTable.Rows.Count - 1 To 0 Step -1
                    If p_SoLenhGhep = "" Then
                        p_SoLenhGhep = p_DataTable.Rows(p_Count).Item("SoLenh").ToString.Trim
                    Else
                        If p_SoLenhGhep <> p_DataTable.Rows(p_Count).Item("SoLenh").ToString.Trim Then
                            p_SoLenhGhep = p_SoLenhGhep & "," & p_DataTable.Rows(p_Count).Item("SoLenh").ToString.Trim
                            p_LenhGhep = True
                        End If
                    End If
                    If p_DataTable.Rows(p_Count).Item("MaNgan").ToString.Trim = "" Then
                        p_DataTable.Rows.RemoveAt(p_Count)
                    Else
                        p_DataTable.Rows(p_Count).Item("MaPhuongTien") = p_MaVanChuyen
                        p_DataTable.Rows(p_Count).Item("NguoiVanChuyen") = p_NguoiVanChuyen
                        p_DataTable.Rows(p_Count).Item("Status") = p_Status
                    End If
                Next
            End If


        Else
            p_BindingOld = Me.GridView3.DataSource
            p_DataTableOld = CType(p_BindingOld.DataSource, DataTable)
            If Not p_DataTableOld Is Nothing Then
                For p_Count = 0 To p_DataTableOld.Rows.Count - 1

                    If p_DataTableOld.Rows(p_Count).Item("MaPhuongTien").ToString.Trim <> "" And p_MaVanChuyen <> "" _
                            And KiemTraPhuongTienAo(p_MaVanChuyen) = False _
                            And UCase(p_DataTableOld.Rows(p_Count).Item("MaPhuongTien").ToString.Trim) <> "" _
                            And KiemTraPhuongTienAo(p_DataTableOld.Rows(p_Count).Item("MaPhuongTien").ToString.Trim) = False Then
                        If (p_DataTableOld.Rows(p_Count).Item("MaPhuongTien").ToString.Trim <> p_MaVanChuyen _
                           ) And g_KIEMTRAGHEP_PT = True Then

                            'If (p_DataTableOld.Rows(p_Count).Item("MaPhuongTien").ToString.Trim <> p_MaVanChuyen _
                            '                           Or p_DataTableOld.Rows(p_Count).Item("NguoiVanChuyen").ToString.Trim <> p_NguoiVanChuyen) And g_KIEMTRAGHEP_PT = True Then

                            ShowMessageBox("", "Lệnh ghép phải cùng Mã phương tiện")
                            p_DataTableOld = Nothing
                            Exit Sub
                        End If
                    End If
                    'If p_DataTableOld.Rows(p_Count).Item("MaPhuongTien").ToString.Trim <> p_MaVanChuyen _
                    '        Or p_DataTableOld.Rows(p_Count).Item("NguoiVanChuyen").ToString.Trim <> p_NguoiVanChuyen Then
                    '    ShowMessageBox("", "Lệnh ghép phải cùng Mã phương tiện và Người vận chuyển")
                    '    p_DataTableOld = Nothing
                    'End If
                Next

            End If


            p_Binding = Me.GridView2.DataSource
            p_DataTable = CType(p_Binding.DataSource, DataTable)
            Try
                p_DataTable.Columns.Add("MaPhuongTien")
                p_DataTable.Columns.Add("NguoiVanChuyen")
                p_DataTable.Columns.Add("Status")
                p_DataTable.Columns.Add("TenKhachHang")
            Catch ex As Exception

            End Try

            For p_Count = p_DataTable.Rows.Count - 1 To 0 Step -1
                If p_DataTable.Rows(p_Count).Item("MaNgan").ToString.Trim = "" Then
                    p_DataTable.Rows.RemoveAt(p_Count)
                End If
            Next
            If p_DataTable.Rows.Count <= 0 Then
                p_Binding = Me.GridView1.DataSource
                p_DataTable = CType(p_Binding.DataSource, DataTable)

                Try
                    p_DataTable.Columns.Add("MaNgan")
                    p_DataTable.Columns.Add("MaPhuongTien")
                    p_DataTable.Columns.Add("NguoiVanChuyen")
                    p_DataTable.Columns.Add("Status")

                    p_DataTable.Columns.Add("TenKhachHang")

                    For p_Count = p_DataTable.Rows.Count - 1 To 0 Step -1
                        p_DataTable.Rows(p_Count).Item("MaPhuongTien") = p_MaVanChuyen
                        p_DataTable.Rows(p_Count).Item("NguoiVanChuyen") = p_NguoiVanChuyen
                        p_DataTable.Rows(p_Count).Item("Status") = p_Status

                    Next

                Catch ex As Exception

                End Try

            Else
                For p_Count = p_DataTable.Rows.Count - 1 To 0 Step -1
                    If p_DataTable.Rows(p_Count).Item("MaNgan").ToString.Trim = "" Then
                        p_DataTable.Rows.RemoveAt(p_Count)
                    Else
                        p_DataTable.Rows(p_Count).Item("MaPhuongTien") = p_MaVanChuyen
                        p_DataTable.Rows(p_Count).Item("NguoiVanChuyen") = p_NguoiVanChuyen
                        p_DataTable.Rows(p_Count).Item("Status") = p_Status
                    End If
                Next
            End If

            p_LenhGhep = True
        End If
        If p_HuyTichKe = True Then
            If Not p_DataTableOld Is Nothing Then
                p_DataTableOld.Clear()
            End If

        End If
        If Not p_DataTableOld Is Nothing Then
            p_ArrRow = p_DataTableOld.Select("Status='3' or Status='31' or Status='4' or Status='5'")
            If p_ArrRow.Length > 0 Then
                ShowMessageBox("", "Không ghép lệnh với lệnh xuất đã in tích kê")
                p_LenhGhep = False
                p_DataTableOld.Clear()
            End If
            'p_DataTableOld.Merge(p_DataTable)
            Dim p_Column As DataColumn
            '  If p_DataTableOld.Columns.Count > p_DataTable.Columns.Count Then
            For p_Count = 0 To p_DataTableOld.Columns.Count - 1
                If p_DataTable.Columns.IndexOf(p_DataTableOld.Columns.Item(p_Count).ColumnName.ToString.Trim) < 0 Then
                    p_Column = New DataColumn
                    p_Column = p_DataTableOld.Columns.Item(p_Count)
                    p_DataTable.Columns.Add(p_Column.ColumnName, p_Column.DataType)
                End If
            Next
            'Else
            For p_Count = 0 To p_DataTable.Columns.Count - 1
                If p_DataTableOld.Columns.IndexOf(p_DataTable.Columns.Item(p_Count).ColumnName.ToString.Trim) < 0 Then
                    p_Column = New DataColumn
                    p_Column = p_DataTable.Columns.Item(p_Count)
                    p_DataTableOld.Columns.Add(p_Column.ColumnName, p_Column.DataType)
                End If
            Next
            '  End If

            For p_Count = 0 To p_DataTable.Rows.Count - 1
                p_RowData = p_DataTableOld.NewRow
                For p_Count1 = 0 To p_DataTableOld.Columns.Count - 1
                    'If p_Count1 = 10 Then
                    '    MsgBox("dddd")
                    'End If
                    If p_DataTable.Rows(p_Count).Item(p_DataTableOld.Columns.Item(p_Count1).ColumnName.ToString).ToString.Trim <> "" Then
                        ' If p_DataTable.Columns.IndexOf(p_DataTableOld.Columns.Item(p_Count1).ColumnName.ToString) >= 0 Then
                        'If p_DataTableOld.Columns.Item(p_Count1).ColumnName.ToString = "SoLenh" Then
                        '    MsgBox("sdfsd")
                        'End If
                        ' Decimal.TryParse(p_DataTable.Rows(p_Count).Item(p_DataTableOld.Columns.Item(p_Count1).ColumnName.ToString).ToString.Trim, p_Tmp)
                        If p_DataTable.Rows(p_Count).Item(p_DataTableOld.Columns.Item(p_Count1).ColumnName.ToString).ToString.Trim <> "" Then

                            p_RowData.Item(p_DataTableOld.Columns.Item(p_Count1).ColumnName.ToString) = p_DataTable.Rows(p_Count).Item(p_DataTableOld.Columns.Item(p_Count1).ColumnName.ToString).ToString.Trim
                        End If
                        'If
                    End If
                    ' p_RowData.Item(p_Count1) = p_DataTable.Rows(p_Count).Item(p_Count1).ToString.Trim
                Next
                p_DataTableOld.Rows.Add(p_RowData)
            Next
        Else
            p_DataTableOld = p_DataTable.Clone
            For p_Count = 0 To p_DataTable.Rows.Count - 1
                p_RowData = p_DataTableOld.NewRow
                For p_Count1 = 0 To p_DataTableOld.Columns.Count - 1
                    'Select Case UCase(p_DataTableOld.Columns(p_Count1).DataType.Name.ToString.Trim)
                    '    Case "DECIMAL"
                    '        Decimal.TryParse(p_DataTable.Rows(p_Count).Item(p_Count1).ToString.Trim, p_RowData.Item(p_Count1))
                    '    Case "INT32"
                    '        Int32.TryParse(p_DataTable.Rows(p_Count).Item(p_Count1).ToString.Trim, p_RowData.Item(p_Count1))
                    '    Case "INT64"
                    '        Int64.TryParse(p_DataTable.Rows(p_Count).Item(p_Count1).ToString.Trim, p_RowData.Item(p_Count1))
                    '    Case "INTEGER"
                    '        Integer.TryParse(p_DataTable.Rows(p_Count).Item(p_Count1).ToString.Trim, p_RowData.Item(p_Count1))
                    '    Case "DOUBLE"
                    '        Double.TryParse(p_DataTable.Rows(p_Count).Item(p_Count1).ToString.Trim, p_RowData.Item(p_Count1))
                    '    Case "DATETIME"
                    '       p_DataTable.Rows(p_Count).Item(p_Count1).ToString.Trim, p_RowData.Item(p_Count1))
                    '    Case Else

                    'End Select
                    If p_DataTable.Rows(p_Count).Item(p_Count1).ToString.Trim <> "" Then
                        p_RowData.Item(p_Count1) = p_DataTable.Rows(p_Count).Item(p_Count1).ToString.Trim
                    End If

                Next
                p_DataTableOld.Rows.Add(p_RowData)
            Next
        End If

        Try
            Dim p_Column As U_TextBox.GridColumn
            Dim p_TblClient As DataTable
            p_Column = Me.GridView2.Columns("TableID")
            If p_LenhGhep = True Then
                p_SoLenhGhep = ""
                For p_Count = 0 To p_DataTableOld.Rows.Count - 1
                    If p_SoLenhGhep <> p_DataTableOld.Rows(p_Count).Item("SoLenh").ToString.Trim Then
                        p_SoLenhGhep = p_SoLenhGhep & "," & p_DataTableOld.Rows(p_Count).Item("SoLenh").ToString.Trim
                    End If
                Next
                If p_SoLenhGhep <> "" Then





                    'Kiem tra cung loai hinh phuong tien

                    p_SQL = "select distinct  MaVanChuyen from tbllenhxuatE5 with (Nolock) where CHARINDEX ( ',' + SoLenh + ',' , '" & p_SoLenhGhep & ",' ,1) >0 "

                    p_TblClient = GetDataTable(p_SQL, p_SQL)
                    If Not p_TblClient Is Nothing Then
                        If p_TblClient.Rows.Count > 1 Then

                            ShowMessageBox("", "Lệnh ghép khác Loại hình phương tiện")

                            ' p_SoLenhGhep = Replace(p_SoLenhGhep, p_SoLenh, "", 1)

                            Me.GridView3.ClearGrouping()
                            For p_Count = GridView3.RowCount - 1 To 0 Step -1
                                p_RowData = GridView3.GetDataRow(p_Count)
                                If Not p_RowData Is Nothing Then
                                    If p_SoLenh = p_RowData.Item("SoLenh").ToString.Trim Then
                                        GridView3.DeleteRow(p_Count)
                                    End If
                                End If

                            Next


                            'Exit Sub
                            p_LenhGhep = False
                            'p_SoLenhGhep = p_SoLenh
                            'Me.GridView3.ClearGrouping()
                            'For p_Count = GridView3.RowCount - 1 To 0 Step -1
                            '    GridView3.DeleteRow(p_Count)
                            'Next
                            'GoTo Line_Start
                            Exit Sub
                        End If
                    End If


                    p_SQL = "select client from tbllenhxuatE5 with (Nolock) where CHARINDEX ( ',' + SoLenh + ',' , '" & p_SoLenhGhep & ",' ,1) >0 " & _
                     "  and Client is not null and Client <>'' Group by Client"

                    p_TblClient = GetDataTable(p_SQL, p_SQL)
                    If Not p_TblClient Is Nothing Then
                        If p_TblClient.Rows.Count > 1 Then
                            ShowMessageBox("", "Lệnh xuất không cùng kho")
                            'Exit Sub
                            p_LenhGhep = False
                            p_SoLenhGhep = p_SoLenh
                            Me.GridView3.ClearGrouping()
                            For p_Count = GridView3.RowCount - 1 To 0 Step -1
                                GridView3.DeleteRow(p_Count)
                            Next
                            GoTo Line_Start
                        End If
                    End If


                    'Kiem tra tai trong
                    'anhqh
                    '20160817

                    'If KiemTraPhuongTienQuaTai(p_SoLenhGhep, "", _
                    '                                   False, _
                    '                                    p_LenhGhep) = True Then
                    '    Exit Sub
                    'End If

                    GetHangHoaGhep(p_SoLenhGhep)
                End If
                Me.GridView1.Columns.Item("SoLenh").Visible = True
                ' Me.GridView1.Columns.Item("SoLenh").VisibleIndex = 0

                'Me.GridView1.Columns.Item("TenHangHoa").Visible = False
                ' Me.GridView1.Columns.Item("TenHangHoa").VisibleIndex = -1

                'Me.MaPhuongTien.Properties.ReadOnly = True
                ' Me.NguoiVanChuyen.Properties.ReadOnly = True
                'p_SQL = "select TableID , TenHangHoa, MaLenh,NgayXuat, LineID, SoLenh   from FPT_tblLenhXuat_HangHoaE5_V " & _
                '    " where charindex( ',' +  SoLenh + ',','" & p_SoLenhGhep & ",')>0  union all select '' TableID , '' MaHangHoa, '' MaLenh,null NgayXuat, '' LineID , '' SoLenh  "
                p_SQL = ""
                For p_Count = 0 To Me.GridView1.RowCount - 1
                    p_RowData = GridView1.GetDataRow(p_Count)
                    If Not p_RowData Is Nothing Then
                        If p_RowData.Item("TableID").ToString.Trim <> "" Then
                            p_SQL = p_SQL & "," & p_RowData.Item("TableID").ToString.Trim
                        End If
                    End If
                Next
                If Mid(p_SQL, 1, 1) = "," Then
                    p_SQL = Mid(p_SQL, 2)
                End If
                If p_SQL = "" Then
                    p_SQL = "select TableID , TenHangHoa, MaLenh,NgayXuat, LineID, SoLenh   from FPT_tblLenhXuat_HangHoaE5_V " & _
                  " where charindex( ',' +  SoLenh + ',','" & p_SoLenhGhep & ",')>0  union all select '' TableID , '' MaHangHoa, '' MaLenh,null NgayXuat, '' LineID , '' SoLenh  "
                Else
                    p_SQL = "select TableID , TenHangHoa, MaLenh,NgayXuat, LineID, SoLenh   from FPT_tblLenhXuat_HangHoaE5_V " & _
                     " where TableID in (" & p_SQL & ")" & _
                      " union all select '' TableID , '' MaHangHoa, '' MaLenh,null NgayXuat, '' LineID , '' SoLenh  "

                End If


            Else
                Me.GridView1.Columns.Item("SoLenh").Visible = False
                p_SQL = "select TableID , TenHangHoa, MaLenh,NgayXuat, LineID  , SoLenh      from FPT_tblLenhXuat_HangHoaE5_V with(Nolock) where SoLenh=:SoLenh  " & _
                        "union all select '' TableID , '' MaHangHoa, '' MaLenh,null NgayXuat, '' LineID , '' SoLenh "
                ' Me.GridView1.Columns.Item("SoLenh").VisibleIndex = -1
                'Me.MaPhuongTien.Properties.ReadOnly = False
                'Me.NguoiVanChuyen.Properties.ReadOnly = False

                'Me.GridView1.Columns.Item("TenHangHoa").Visible = True
                'Me.GridView1.Columns.Item("TenHangHoa").VisibleIndex = 3

            End If
            p_Column.SQLString = p_SQL
        Catch ex As Exception

        End Try

        Me.GridView1.BestFitColumns()

        If p_LenhGhep = True Then
            p_SQL = "select SoLenh, (select top 1 TenKhachHang  from tblKhachHang b with (nolock) where a.MaKhachHang =b.MaKhachHang ) TenKhachHang " & _
                        " from tblLenhXuatE5 a with (nolock)   where   charindex( ',' +  SoLenh + ',','" & p_SoLenhGhep & ",')>0"
        Else
            p_SQL = "select SoLenh, (select top 1 TenKhachHang  from tblKhachHang b with (nolock) where a.MaKhachHang =b.MaKhachHang ) TenKhachHang " & _
                        " from tblLenhXuatE5 a with (nolock)   where   SoLenh = '" & p_SoLenh & "'"

        End If



        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            For p_Count = 0 To p_DataTableOld.Rows.Count - 1
                If Not p_DataTableOld.Rows(p_Count) Is Nothing Then
                    p_ArrRow = p_DataTable.Select("SoLenh='" & p_DataTableOld.Rows(p_Count).Item("SoLenh") & "'")
                    If p_ArrRow.Length > 0 Then
                        Try
                            p_DataTableOld.Rows(p_Count).Item("TenKhachHang") = p_ArrRow(0).Item("TenKhachHang")
                        Catch ex As Exception
                            p_DataTableOld.Columns.Add("TenKhachHang")
                            p_DataTableOld.Rows(p_Count).Item("TenKhachHang") = p_ArrRow(0).Item("TenKhachHang")
                        End Try

                    End If
                End If

            Next

        End If



        For p_Count = p_DataTableOld.Rows.Count - 1 To 0 Step -1
            If p_DataTableOld.Rows(p_Count).Item("SoLenh").ToString.Trim = "" Then
                p_DataTableOld.Rows.RemoveAt(p_Count)
            End If
        Next
        p_BindingOld.DataSource = p_DataTableOld
        Me.TrueDBGrid3.DataSource = p_BindingOld
        'TrueDBGrid3.RefreshDataSource()
        Me.GridView3.Columns.Item(0).FieldName = "SoLenh"
        Me.GridView3.Columns.Item(1).FieldName = "NgayXuat"
        Me.GridView3.Columns.Item(2).FieldName = "MaPhuongTien"
        Me.GridView3.Columns.Item(3).FieldName = "TenKhachHang"  ''
        'Me.GridView3.Columns.Item(4).FieldName = "NguoiVanChuyen"  ''

        Me.GridView3.Columns.Item(5).FieldName = "MaNgan"
        Me.GridView3.Columns.Item(6).FieldName = "SoLuongDuXuat"
        Me.GridView3.Columns.Item(7).FieldName = "Status"

        Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False

        Me.GridView3.OptionsBehavior.ReadOnly = True
        Me.GridView3.Columns(0).Group()
        Me.GridView3.ExpandAllGroups()
        GridView3.BestFitColumns()

        Me.GridView1.BestFitColumns()
        Me.GridView1.Columns.Item("TableID").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        GepNganTrong()

        Me.GridView3.ExpandAllGroups()
        GridView3.BestFitColumns()

        If p_LenhGhep = True Then
            If KiemTraPhuongTienQuaTai(p_SoLenhGhep, "", False, True) = True Then
                Dim p_Row1 As DataRow
                p_SoLenhGhep = Replace(p_SoLenhGhep, p_SoLenh, "", 1)
                For p_Count = Me.GridView1.RowCount - 1 To 0 Step -1
                    p_RowData = Me.GridView1.GetDataRow(p_Count)
                    If Not p_RowData Is Nothing Then
                        If p_RowData.Item("SoLenh").ToString.Trim = p_SoLenh.ToString.Trim Then
                            p_SQL = p_RowData.Item("TableID").ToString.Trim
                            For p_Count1 = Me.GridView2.RowCount - 1 To 0 Step -1
                                p_Row1 = Me.GridView2.GetDataRow(p_Count)
                                If Not p_Row1 Is Nothing Then
                                    'MsgBox(p_Row1.Item("TableID").ToString.Trim)
                                    If p_Row1.Item("TableID").ToString.Trim = p_SQL.ToString.Trim Then
                                        GridView2.DeleteRow(p_Count)
                                    End If
                                End If
                            Next

                            Me.GridView3.ClearGrouping()

                            For p_Count1 = Me.GridView3.RowCount - 1 To 0 Step -1
                                p_Row1 = Me.GridView3.GetDataRow(p_Count1)
                                If Not p_Row1 Is Nothing Then
                                    'MsgBox(p_Row1.Item("TableID").ToString.Trim)
                                    If p_Row1.Item("SoLenh").ToString.Trim = p_RowData.Item("SoLenh").ToString.Trim Then
                                        GridView3.DeleteRow(p_Count1)
                                    End If
                                End If
                            Next



                            GridView1.DeleteRow(p_Count)

                        End If

                    End If
                Next

            End If


        End If

        ' Column_Combobox_Click()


        If p_Status = "1" Or p_Status = "2" Or p_Status = "" Then
            GetTaiTrongKG(p_NhietDoNgay, False)
            If g_KV1 = True Then
                If p_LenhGhep = True Then
                    Me.aNumber.EditValue = Me.GridView1.RowCount
                Else
                    If Me.aNumber.EditValue Is Nothing Then
                        Me.aNumber.EditValue = Me.GridView1.RowCount
                    ElseIf Me.aNumber.EditValue.ToString.Trim = "" Then
                        Me.aNumber.EditValue = Me.GridView1.RowCount
                    ElseIf Me.aNumber.EditValue.ToString.Trim = "0" Then
                        Me.aNumber.EditValue = Me.GridView1.RowCount
                    End If
                End If
            End If

        End If


        Me.NguoiVanChuyen.Required = "Y"
        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            If Me.MaVanChuyen.EditValue.ToString.Trim = "ZR" Then
                Me.NguoiVanChuyen.Required = "N"
            End If
        End If

        CallChartBar3D()



    End Sub

    Private Sub GepNganTrong()
        Dim p_DataTable As DataTable
        Dim p_DataTableHH As DataTable
        Dim p_DataTableTmp As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_SQL As String = ""
        Dim p_Count As Integer
        Dim p_Count1 As Integer
        Dim p_DataRow As DataRow
        Dim p_RowArr() As DataRow
        Dim p_FormEdit As Boolean
        Dim p_FormStatus As Boolean
        Dim p_DuXuat As Double
        Dim p_DungTichNgan As Double
        Dim p_Count2 As Integer

        Dim p_LoaiXuat As String = ""
        ' Exit Sub
        Dim p_Status As String = ""

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If p_Status.ToString.Trim = "3" Or p_Status.ToString.Trim = "31" Or p_Status.ToString.Trim = "4" Or p_Status.ToString.Trim = "5" Then
            Exit Sub
        End If

        p_FormEdit = Me.FormEdit

        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            p_LoaiXuat = Me.MaVanChuyen.EditValue.ToString.Trim
        End If
        p_LoaiXuat = GetLoadingSite(p_LoaiXuat)

        p_FormStatus = Me.FormStatus
        Try
            'Me.FormStatus = True
            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_SQL = Me.MaPhuongTien.EditValue.ToString.Trim
                If p_SQL <> "" Then
                    p_SQL = "select * from tblChiTietPhuongTien where MaPhuongTien ='" & p_SQL & "' order by MaNgan"
                    p_DataTable = GetDataTable(p_SQL, p_SQL)
                    If Not p_DataTable Is Nothing Then

                        'Me.GridView2.RefreshEditor(False)
                        p_Binding = Me.TrueDBGrid2.DataSource
                        p_DataTableHH = CType(p_Binding.DataSource, DataTable)
                        p_DataTableTmp = p_DataTableHH.Clone

                        For p_Count = 0 To p_DataTableHH.Rows.Count - 1
                            p_DataRow = p_DataTableTmp.NewRow
                            For p_Count1 = 0 To p_DataTableHH.Columns.Count - 1
                                If p_DataTableHH.Rows(p_Count).Item(p_Count1).ToString.Trim <> "" Then
                                    Try
                                        p_DataRow.Item(p_Count1) = p_DataTableHH.Rows(p_Count).Item(p_Count1).ToString.Trim
                                    Catch ex As Exception

                                    End Try

                                End If
                            Next
                            p_DataTableTmp.Rows.Add(p_DataRow)
                        Next


                        Me.FormEdit = False
                        'For p_Count = Me.GridView2.RowCount - 1 To 0 Step -1
                        '    GridView2.DeleteRow(p_Count)
                        'Next
                        'p_Count = Me.GridView2.RowCount - 1
                        'While p_Count >= 0
                        '    GridView2.DeleteRow(p_Count)
                        '    p_Count = p_Count - 1

                        'End While

                        p_DataTableHH.Clear()
                        '  Me.GridView2.MoveLast()
                        For p_Count = 0 To p_DataTable.Rows.Count - 1
                            p_RowArr = p_DataTableTmp.Select("MaNgan='" & p_DataTable.Rows(p_Count).Item("MaNgan").ToString.Trim & "'")

                            ' Me.GridView2.AddNewRow()
                            If p_RowArr.Length > 1 Then
                                For p_Count2 = 0 To p_RowArr.Length - 1
                                    p_DataRow = p_DataTableHH.NewRow
                                    For p_Count1 = 0 To p_DataTableHH.Columns.Count - 1
                                        Try
                                            If p_RowArr(p_Count2).Item(p_Count1).ToString.Trim <> "" Then
                                                p_DataRow.Item(p_Count1) = p_RowArr(p_Count2).Item(p_Count1).ToString.Trim
                                            End If

                                            'Me.GridView2.SetFocusedRowCellValue(p_Count1, p_RowArr(0).Item(p_Count1).ToString.Trim)
                                        Catch ex As Exception

                                        End Try
                                        ' p_DataRow.Item(p_Count1) = p_RowArr(0).Item(p_Count1).ToString.Trim
                                    Next
                                    If UCase(p_LoaiXuat) = "THUY" Then

                                        Double.TryParse(p_RowArr(0).Item("DungTichNgan").ToString.Trim(), p_DungTichNgan)
                                        Double.TryParse(p_RowArr(0).Item("SoLuongDuXuat").ToString.Trim(), p_DuXuat)
                                        If p_DuXuat > p_DungTichNgan Then
                                            p_DataRow.Item("SoLuongDuXuat") = 0
                                        End If
                                    End If
                                    p_DataTableHH.Rows.Add(p_DataRow)
                                Next

                            Else
                                p_DataRow = p_DataTableHH.NewRow
                                If p_RowArr.Length > 0 Then
                                    For p_Count1 = 0 To p_DataTableHH.Columns.Count - 1
                                        Try
                                            If p_RowArr(0).Item(p_Count1).ToString.Trim <> "" Then
                                                p_DataRow.Item(p_Count1) = p_RowArr(0).Item(p_Count1).ToString.Trim
                                            End If

                                            'Me.GridView2.SetFocusedRowCellValue(p_Count1, p_RowArr(0).Item(p_Count1).ToString.Trim)
                                        Catch ex As Exception

                                        End Try
                                        ' p_DataRow.Item(p_Count1) = p_RowArr(0).Item(p_Count1).ToString.Trim
                                    Next
                                    If UCase(p_LoaiXuat) = "THUY" Then

                                        Double.TryParse(p_RowArr(0).Item("DungTichNgan").ToString.Trim(), p_DungTichNgan)
                                        Double.TryParse(p_RowArr(0).Item("SoLuongDuXuat").ToString.Trim(), p_DuXuat)
                                        If p_DuXuat > p_DungTichNgan Then
                                            p_DataRow.Item("SoLuongDuXuat") = 0
                                        End If
                                    End If

                                    ' Me.GridView2.SetFocusedRowCellValue("CHECKUPD", "N")
                                Else
                                    p_DataRow.Item("DungTichNgan") = p_DataTable.Rows(p_Count).Item("SoLuongMax").ToString.Trim
                                    p_DataRow.Item("TableID") = ""
                                    p_DataRow.Item("MaNgan") = p_DataTable.Rows(p_Count).Item("MaNgan").ToString.Trim
                                    p_DataRow.Item("CHECKUPD") = "N"

                                    '  Me.GridView2.MoveLast()
                                    'Me.GridView2.AddNewRow()

                                    'Me.GridView2.SetFocusedRowCellValue("DungTichNgan", p_DataTable.Rows(p_Count).Item("SoLuongMax").ToString.Trim)
                                    'Me.GridView2.SetFocusedRowCellValue("MaNgan", p_DataTable.Rows(p_Count).Item("MaNgan").ToString.Trim)
                                    'Me.GridView2.SetFocusedRowCellValue("CHECKUPD", "N")
                                End If
                                p_DataTableHH.Rows.Add(p_DataRow)
                            End If
                        Next


                        For p_Count = p_DataTableHH.Rows.Count - 1 To 0 Step -1
                            If p_DataTableHH.Rows(p_Count).Item("MaNgan").ToString.Trim = "" Then
                                p_DataTableHH.Rows.RemoveAt(p_Count)
                            End If
                        Next
                        p_Binding.DataSource = p_DataTableHH
                        Me.TrueDBGrid2.DataSource = p_Binding
                        'For p_Count = Me.GridView2.RowCount - 1 To p_DataTable.Rows.Count Step -1
                        '    GridView2.DeleteRow(p_Count)
                        'Next

                        Me.FormEdit = p_FormEdit
                        '  Me.FormStatus = p_FormStatus
                        ' Me.GridView2.Columns("MaNgan").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                        Me.GridView2.RefreshData()
                        GridView2.MoveFirst()

                        'For p_Count = 0 To p_DataTableTmp.Columns.Count - 1
                        '    GridView2.Columns(p_Count).FieldName = p_DataTableTmp.Columns(p_Count).ColumnName

                        'Next
                        ' Me.TrueDBGrid2.RefreshDataSource()
                    End If
                End If
            End If
            'Me.GridView3.ExpandAllGroups()
            'For p_Count = Me.GridView3.RowCount - 1 To 0 Step -1
            '    If GridView3.GetRowCellValue(p_Count, "SoLenh") Is Nothing Then
            '        GridView3.DeleteRow(p_Count)
            '    ElseIf GridView3.GetRowCellValue(p_Count, "SoLenh").ToString.Trim = "" Then
            '        GridView3.DeleteRow(p_Count)

            '    End If

            'Next
            'GridView3.RefreshData()
        Catch ex As Exception
            Me.FormEdit = p_FormEdit
            'Me.FormStatus = p_FormStatus
        End Try
    End Sub


    Private Sub GetHangHoaGhep(ByVal p_LenhGhep As String)
        Dim p_DataSet As DataSet
        Dim p_SQL As String
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_DataTable As DataTable

        '  ' Dim p_DataTableClient As DataTable
        '  GetHangHoaGhep = True
        p_SQL = "exec FPT_LenhXuatHangHoaE5_Ghep_V '," & p_LenhGhep & ",'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                'Grid LenhXuat_HangHoa
                p_DataTable = p_DataSet.Tables(0)
                p_Binding = New U_TextBox.U_BindingSource()
                p_Binding.DataSource = p_DataTable
                Me.TrueDBGrid1.DataSource = p_Binding
                Me.TrueDBGrid1.RefreshDataSource()
                Me.GridView1.RefreshData()

                'Grid LenhXuatChiTiet
                p_DataTable = p_DataSet.Tables(1)
                p_Binding = New U_TextBox.U_BindingSource()
                p_Binding.DataSource = p_DataTable
                Me.TrueDBGrid2.DataSource = p_Binding
                Me.TrueDBGrid2.RefreshDataSource()
                Me.GridView2.RefreshData()

            End If
            'If p_DataSet.Tables.Count >= 3 Then
            '    p_DataTableClient = p_DataSet.Tables(2)
            '    If p_DataTableClient.Rows.Count > 1 Then
            '        ShowMessageBox("", "Lệnh ghép không cùng kho")
            '        GetHangHoaGhep = False
            '    End If
            'End If
        End If

        GanMaBeChoLenhXuat()
        'p_Binding = Me.TrueDBGrid1.DataSource
        'p_DataTable = CType(p_Binding.DataSource, DataTable)
    End Sub

    Sub TinhQCI(ByVal p_NhietDo)
        Dim l_out As String()
        Dim l_quantity As Decimal() = New Decimal() {0, 0, 0, 0}
        Dim l_bs_qci As New BSQci
        Dim p_Count As Integer
        Dim g_err As String
        Dim g_itemid As String
        Dim g_mahanghoa As String
        Dim g_donvitinh As String
        Dim g_tongduxuat As Integer
        Dim p_DataRow As DataRow
        Dim p_Den_ns As String = "0.658"
        Dim p_BeXuat As String

        With Me.GridView1
            '.EndUpdate()
            For p_Count = 0 To .RowCount - 1
                'If .IsDataRow(p_Count) = True And .IsRowSelected(p_Count) = True Then
                p_DataRow = .GetDataRow(p_Count)
                If p_DataRow Is Nothing Then
                    Continue For
                End If
                g_itemid = "0"    'p_DataRow.Item("MaHangHoa").ToString.Trim
                g_mahanghoa = p_DataRow.Item("MaHangHoa").ToString.Trim
                g_donvitinh = p_DataRow.Item("DonViTinh").ToString.Trim
                g_tongduxuat = p_DataRow.Item("TongDuXuat").ToString.Trim
                p_BeXuat = p_DataRow.Item("BeXuat").ToString.Trim
                ' l_out = mdlQCI_GetDefaultTank(g_mahanghoa)


                Dim l_dt As DataTable = New DataTable
                Dim p_SQL As String
                p_Den_ns = "0.658"
                ' p_SQL = "Select top 10 * from tblTankActive where Product_nd = '" & g_mahanghoa & "' Order by ID desc"
                p_SQL = "Select top 1 Dens_nd from fpt_tblTankActive_v where Date1=CONVERT(date,getdate()) and Name_nd='" & _
                    p_BeXuat.Trim & "' and Product_nd = '" & g_mahanghoa & "'"
                l_dt = GetDataTable(p_SQL, p_SQL)
                If Not l_dt Is Nothing Then
                    If l_dt.Rows.Count > 0 Then
                        p_Den_ns = l_dt.Rows(0).Item("Dens_nd").ToString.Trim
                    End If

                End If

                l_quantity = mdlQCI_CalculateQCI_NS("", g_tongduxuat, g_donvitinh, p_NhietDo, p_Den_ns)
                If l_quantity(0).ToString.Trim <> "" Then

                    .SetRowCellValue(p_Count, "TongXuat", l_quantity(0).ToString)

                End If

                ' End If

            Next

        End With



    End Sub


    Function FPT_GetMaLenh() As String
        Dim p_ValueTmp As String = "0000"
        Dim p_SQL As String = ""
        Dim p_Value As Integer = 0
        Dim p_DataTable As DataTable
        Try
            FPT_GetMaLenh = "0000"
            p_SQL = "exec FPT_Get_SYS_MALENH_S"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_Value = p_DataTable.Rows(0).Item(0)
                End If
            End If
            If p_Value > 0 Then
                If Len(p_Value.ToString.Trim) < 4 Then
                    FPT_GetMaLenh = Mid(p_ValueTmp, 1, Len(FPT_GetMaLenh.ToString.Trim) - Len(p_Value.ToString.Trim) - Len(p_SYS_MALENH_S)) & p_Value.ToString.Trim
                    If Len(FPT_GetMaLenh) = 3 Then
                        FPT_GetMaLenh = p_SYS_MALENH_S & FPT_GetMaLenh
                    End If
                Else
                    FPT_GetMaLenh = p_Value.ToString.Trim
                End If
            End If
        Catch ex As Exception
            FPT_GetMaLenh = "0000"
        End Try

    End Function

    Function KiemTraThongTin(ByVal p_SoLenh As String, Optional ByVal p_IntichKe As Boolean = False) As Boolean
        Dim p_HDataTable As DataTable
        Dim p_LDataTable As DataTable

        Dim p_DataSet As DataSet

        Dim p_Count As Integer
        Dim p_LCount As Integer
        Dim p_Value As String
        Dim p_HDuXuat As Integer
        Dim p_LDuXuat As Integer
        Dim p_ArrRow() As DataRow
        Dim p_DanhSachNgan As DataTable
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_LDataTableTmp As DataTable
        Dim p_SQL As String
        Dim p_MaPhuongTien As String
        Dim p_DataRow As DataRow
        Dim p_Sattus As String = "1"
        KiemTraThongTin = False

        Dim p_Date As Date
        Dim p_DateHT As Date
        Dim p_Time As Integer
        Dim p_TableID As String = ""

        Dim p_DungTichNgan As Double
        Dim p_DuXuat As Double
        Dim p_LoaiXuat As String = ""
        Dim p_ValueMess As Windows.Forms.DialogResult
        Try
            p_SQL = ""

            If Not Me.Client.EditValue Is Nothing Then
                p_SQL = Me.Client.EditValue.ToString.Trim
            End If


            If g_Filter_Terminal = True Then
                'If Not Me.Client.EditValue Is Nothing Then
                '    p_SQL = Me.Client.EditValue.ToString.Trim
                'End If
                If p_SQL <> "" And p_SQL <> g_Terminal.ToString.Trim Then
                    ShowMessageBox("", "Không sửa được thông tin lệnh xuất của kho khác")
                    KiemTraThongTin = True
                    Exit Function
                End If
            End If
            If p_SQL = "" Then
                ShowMessageBox("", "Không xác định giá trị Client của Scadar")
                KiemTraThongTin = True
                Exit Function
            End If

            p_SQL = ""
            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_SQL = Me.MaPhuongTien.EditValue.ToString.Trim
            End If
            If p_SQL = "" Then
                ShowMessageBox("", "Số phương tiện chưa nhập")
                KiemTraThongTin = True
                Exit Function
            End If

            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_LoaiXuat = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            p_LoaiXuat = GetLoadingSite(p_LoaiXuat)


            p_MaPhuongTien = p_SQL
            p_Binding = Me.GridView1.DataSource
            p_HDataTable = CType(p_Binding.DataSource, DataTable)
            p_Binding = Me.GridView2.DataSource
            p_LDataTableTmp = CType(p_Binding.DataSource, DataTable)
            p_LDataTable = p_LDataTableTmp.Clone
            p_LDataTable.Clear()

            p_HDataTable.AcceptChanges()
            p_LDataTable.AcceptChanges()

            For p_Count = 0 To p_LDataTableTmp.Rows.Count - 1

                'If p_LDataTableTmp.Rows(p_Count).RowState <> DataRowState.Deleted Then
                If p_LDataTableTmp.Rows(p_Count).Item("MaNgan").ToString.Trim <> "" Then
                    p_DataRow = p_LDataTable.NewRow   'p_LDataTableTmp.Rows(p_Count)
                    For p_LCount = 0 To p_LDataTableTmp.Columns.Count - 1
                        Try
                            If p_LDataTableTmp.Rows(p_Count).Item("MaNgan").ToString.Trim <> "" And p_LDataTableTmp.Rows(p_Count).Item(p_LCount).ToString.Trim <> "" Then
                                p_DataRow.Item(p_LCount) = p_LDataTableTmp.Rows(p_Count).Item(p_LCount).ToString.Trim
                            End If

                        Catch ex As Exception
                            'MsgBox("")
                        End Try

                    Next
                    p_LDataTable.Rows.Add(p_DataRow)
                End If
                ' End If
            Next
            'p_LDataTable.RejectChanges

            ' p_HDataTable.AcceptChanges()

            For p_Count = 0 To p_HDataTable.Rows.Count - 1
                'p_HDataTable.Reset()
                'If p_HDataTable.Rows(p_Count).RowState <> DataRowState.Deleted Then
                '    Continue For
                'End If
                p_HDuXuat = IIf(p_HDataTable.Rows(p_Count).Item("TongXuat").ToString.Trim = "", 0, p_HDataTable.Rows(p_Count).Item("TongXuat"))
                p_ArrRow = p_LDataTable.Select("TableID='" & p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim & "'")
                'p_Value = p_HDataTable.Rows(p_Count).Item("").ToString.Trim
                p_LDuXuat = 0
                If p_HDataTable.Rows(p_Count).Item("BeXuat").ToString.Trim = "" Then
                    ShowMessageBox("", "Mã lệnh " & p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim & " chưa chọn bể xuất")
                    KiemTraThongTin = True
                    Exit Function
                End If
                If p_ArrRow.Length > 0 Then

                    p_DungTichNgan = 0
                    p_DuXuat = 0
                    For p_LCount = 0 To p_ArrRow.Length - 1
                        If p_ArrRow(p_LCount).Item("TenHangHoa").ToString.Trim <> p_HDataTable.Rows(p_Count).Item("TenHangHoa").ToString.Trim Then
                            ShowMessageBox("", "Mã lệnh " & p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim & " mã hàng hóa không đúng")
                            KiemTraThongTin = True
                            Exit Function
                        End If
                        p_DungTichNgan = IIf(p_ArrRow(p_LCount).Item("DungTIchNgan").ToString.Trim = "", 0, p_ArrRow(p_LCount).Item("DungTIchNgan"))
                        p_DuXuat = IIf(p_ArrRow(p_LCount).Item("SoLuongDuXuat").ToString.Trim = "", 0, p_ArrRow(p_LCount).Item("SoLuongDuXuat"))
                        'If p_DuXuat <> 0 And UCase(p_LoaiXuat) <> "THUY" Then

                        'If p_DungTichNgan <> p_DuXuat And p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim <> p_ArrRow(p_LCount).Item("TableID").ToString.Trim Then
                        '    ShowMessageBox("", "Mã ngăn " & p_ArrRow(p_LCount).Item("MaNgan").ToString.Trim & " Số dự xuất không đúng với dung tích ngăn")
                        '    KiemTraThongTin = True
                        '    Exit Function
                        'End If
                        'End If
                        p_LDuXuat = p_LDuXuat + IIf(p_ArrRow(p_LCount).Item("SoLuongDuXuat").ToString.Trim = "", 0, p_ArrRow(p_LCount).Item("SoLuongDuXuat"))
                    Next

                    If p_HDuXuat <> p_LDuXuat And UCase(p_LoaiXuat) <> "THUY" Then
                        ShowMessageBox("", "Mã lệnh " & p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim & " Tổng dự xuất không đúng")
                        KiemTraThongTin = True
                        Exit Function
                    Else
                        If p_HDuXuat < p_LDuXuat Then
                            ShowMessageBox("", "Mã lệnh " & p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim & " Tổng dự xuất không đúng")
                            KiemTraThongTin = True
                            Exit Function
                        End If
                    End If
                Else
                    'If p_IntichKe = True Then
                    ShowMessageBox("", "Mã lệnh " & p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim & " Chưa thực hiện chia ngăn")
                    KiemTraThongTin = True
                    Exit Function
                    ' If
                End If
            Next

            If Not Me.Status.EditValue Is Nothing Then
                p_Sattus = Me.Status.EditValue.ToString.Trim
            End If


            If UCase(p_LoaiXuat) <> "THUY" Then
                If p_Sattus = "" Or p_Sattus = "1" Or p_Sattus = "2" Then
                    p_SQL = "select MaNgan, SoLuongMax  from tblChiTietPhuongTien where MaPhuongTien='" & p_MaPhuongTien & "'"
                    p_HDataTable = GetDataTable(p_SQL, p_SQL)
                    If Not p_HDataTable Is Nothing Then
                        For p_LCount = 0 To p_HDataTable.Rows.Count - 1
                            p_HDuXuat = IIf(p_HDataTable.Rows(p_LCount).Item("SoLuongMax").ToString.Trim = "", 0, p_HDataTable.Rows(p_LCount).Item("SoLuongMax"))
                            p_LDuXuat = 0
                            'p_LDuXuat = p_LDuXuat.Rows(0).Item(0).ToString.Trim
                            p_ArrRow = p_LDataTable.Select("MaNgan='" & p_HDataTable.Rows(p_LCount).Item("MaNgan").ToString.Trim & "'")
                            p_TableID = ""
                            If p_ArrRow.Length > 0 Then
                                p_SQL = ""
                                '  If p_ArrRow(p_Count).Item("TableID").ToString.Trim <> "" Then


                                For p_Count = 0 To p_ArrRow.Length - 1

                                    'Kiem tra neu cung 1 ngan thi phai khac Hang Hoa
                                    If p_SQL = "" Then
                                        p_SQL = p_ArrRow(p_Count).Item("TenHangHoa").ToString.Trim
                                    End If


                                    If p_SQL <> p_ArrRow(p_Count).Item("TenHangHoa").ToString.Trim And p_ArrRow(p_Count).Item("TenHangHoa").ToString.Trim <> "" Then  'Kiem tra trong cung 1 ngan khong duoc khac ma lenh
                                        ShowMessageBox("", "Mã ngăn " & p_HDataTable.Rows(p_LCount).Item("MaNgan").ToString.Trim & " không cùng mặt hàng")
                                        KiemTraThongTin = True
                                        Exit Function

                                    End If


                                    'Kiem tra neu cung 1 ngan thi khong cung TableID

                                    If p_TableID = p_ArrRow(p_Count).Item("TableID").ToString.Trim And p_TableID <> "" Then
                                        ShowMessageBox("", "Mã ngăn " & p_HDataTable.Rows(p_LCount).Item("MaNgan").ToString.Trim & " không hợp lệ")
                                        KiemTraThongTin = True
                                        Exit Function
                                    End If

                                    p_TableID = p_ArrRow(p_Count).Item("TableID").ToString.Trim

                                    p_LDuXuat = p_LDuXuat + IIf(p_ArrRow(p_Count).Item("SoLuongDuXuat").ToString.Trim = "", 0, p_ArrRow(p_Count).Item("SoLuongDuXuat"))


                                Next
                                If p_HDuXuat <> p_LDuXuat And p_LDuXuat <> 0 Then
                                    ShowMessageBox("", "Mã ngăn " & p_HDataTable.Rows(p_LCount).Item("MaNgan").ToString.Trim & " Tổng số dự xuất không đúng với dung tích ngăn")
                                    KiemTraThongTin = True
                                    Exit Function
                                End If
                                'End If
                            End If
                        Next
                    End If
                End If
            Else
                For p_Count = 0 To Me.GridView1.RowCount - 1
                    p_DataRow = GridView1.GetDataRow(p_Count)
                    If Not p_DataRow Is Nothing Then
                        If p_DataRow.Item("TableID").ToString.Trim <> "" Then
                            If p_DataRow.Item("MeterID").ToString.Trim = "" Then
                                ShowMessageBox("", "Mã lệnh " & p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim & " chưa chọn công tơ")
                                KiemTraThongTin = True
                                Exit Function
                            End If
                        End If
                    End If
                Next
            End If
            'Kiem tra ngay het hạn kiem dinh
            p_SQL = "select * from fpt_tblPhuongTien_V where MaPhuongTien='" & p_MaPhuongTien & "';" & _
                "select 1 as sErr  from tbllenhXuat_HangHoaE5 A with(nolock),  " & _
                      "   (  select top 1 MaPhuongTien,  [TaiTrong] as iweight  " & _
                      " from tblPhuongTien_TaiTrong with (nolock) where MaPhuongTien='" & p_MaPhuongTien & "' " & _
                        " and convert(date,getdate())>=convert(date,isnull(TuNgay,getdate())) " & _
                        " and convert(date,getdate())<=convert(date,isnull(DenNgay,getdate())))  B , " & _
                     " tblLenhXuatE5 c with (nolock) where a.solenh='" & p_SoLenh & "'  and c.maphuongTien=b.MaPhuongTien and a.SoLenh=c.SoLenh " & _
                      " Group by b.iweight  having sum(a.QCI_KG)>ISNULL(b.iweight,0) ;" & _
                      " select COUNT(*) as iTotal from tblPhuongTien_TaiTrong where  MaPhuongTien='" & p_MaPhuongTien & "';"
            ' p_HDataTable = GetDataTable(p_SQL, p_SQL)
            p_DataSet = GetDataSet(p_SQL, p_SQL)

            If Not p_DataSet Is Nothing Then
                If p_DataSet.Tables.Count > 0 Then
                    p_HDataTable = p_DataSet.Tables(0)
                    If Not p_HDataTable Is Nothing Then
                        If p_HDataTable.Rows.Count > 0 Then
                            p_Date = IIf(p_HDataTable.Rows(0).Item("NgayHieuLuc1").ToString.Trim = "", DateAdd("d", 10, Now.Date), p_HDataTable.Rows(0).Item("NgayHieuLuc1").ToString.Trim)
                            p_GetDateTime(p_DateHT, p_Time)
                            If p_Date < p_DateHT Then
                                'ShowMessageBox("", "Mã ngăn " & p_HDataTable.Rows(p_LCount).Item("MaNgan").ToString.Trim & " Tổng số dự xuất không đúng với dung tích ngăn")
                                ShowMessageBox("PT01", "Phương tiện đã hết hạn kiểm định", 3)
                                KiemTraThongTin = True
                                Exit Function
                            End If


                            'If DateAdd("d", 5, p_DateHT.Date) >= p_Date Then
                            '    'ShowStatusMessage(False, "PT01", "Phương tiện sắp hết hạn kiểm định", 5)
                            '    ShowMessageBox("PT01", "Phương tiện sắp hết hạn kiểm định", 3)
                            'End If
                        End If
                    End If
                    If UCase(p_LoaiXuat) = "BO" And g_TAITRONGKG = True Then  'Chi cho xuat Bo
                        If p_KT_TAITRONG = True Then
                            If KiemTraPhuongTienQuaTai(p_SoLenh, p_MaPhuongTien) = True Then
                                KiemTraThongTin = True
                                Exit Function
                            End If
                        End If

                        'p_HDataTable = p_DataSet.Tables(1)
                        'If p_HDataTable.Rows.Count > 0 Then    'And p_IntichKe = True Then
                        '    p_ValueMess = g_Module.ShowMessage(Me, "", _
                        '                "Tổng lượng xuất vượt quá tải trọng phương tiện." & vbCrLf & "Bạn có muốn thực hiện tiếp không?", _
                        '                True, _
                        '                 "Có", _
                        '                True, _
                        '                "Không", _
                        '                False, _
                        '                "", _
                        '                 0)
                        '    If p_ValueMess = Windows.Forms.DialogResult.No Then
                        '        KiemTraThongTin = True
                        '        Exit Function
                        '    End If
                        'Else
                        '    If p_DataSet.Tables(2).Rows.Count <= 0 Then
                        '        p_ValueMess = g_Module.ShowMessage(Me, "", _
                        '                "Tổng lượng xuất vượt quá tải trọng phương tiện." & vbCrLf & "Bạn có muốn thực hiện tiếp không?", _
                        '                True, _
                        '                 "Có", _
                        '                True, _
                        '                "Không", _
                        '                False, _
                        '                "", _
                        '                 0)
                        '        If p_ValueMess = Windows.Forms.DialogResult.No Then
                        '            KiemTraThongTin = True
                        '            Exit Function
                        '        End If
                        '    End If

                        'End If
                    End If
                End If
            End If

        Catch ex As Exception
            ShowMessageBox("", ex.Message)
            KiemTraThongTin = True
        End Try
        'Dim p_HDataTable As DataTable
        'Dim p_LDataTable As DataTable
        'Dim p_Count As Integer
        'Dim p_LCount As Integer
        'Dim p_Value As String
        'Dim p_HDuXuat As Integer
        'Dim p_LDuXuat As Integer
        'Dim p_ArrRow() As DataRow
        'Dim p_DanhSachNgan As DataTable
        'Dim p_Binding As U_TextBox.U_BindingSource
        'Dim p_LDataTableTmp As DataTable
        'Dim p_SQL As String
        'Dim p_DataRow As DataRow

        'KiemTraThongTin = False
        'Try
        '    p_SQL = ""
        '    If Not Me.MaPhuongTien.EditValue Is Nothing Then
        '        p_SQL = Me.MaPhuongTien.EditValue.ToString.Trim
        '    End If
        '    If p_SQL = "" Then
        '        ShowMessageBox("", "Số phương tiện chưa nhập")
        '        KiemTraThongTin = True
        '        Exit Function
        '    End If
        '    p_Binding = Me.GridView1.DataSource
        '    p_HDataTable = CType(p_Binding.DataSource, DataTable)
        '    p_Binding = Me.GridView2.DataSource
        '    p_LDataTableTmp = CType(p_Binding.DataSource, DataTable)
        '    p_LDataTable = p_LDataTableTmp.Clone
        '    p_LDataTable.Clear()
        '    For p_Count = 0 To p_LDataTableTmp.Rows.Count - 1

        '        If p_LDataTableTmp.Rows(p_Count).RowState <> DataRowState.Deleted Then
        '            p_DataRow = p_LDataTable.NewRow   'p_LDataTableTmp.Rows(p_Count)
        '            For p_LCount = 0 To p_LDataTableTmp.Columns.Count - 1
        '                Try
        '                    p_DataRow.Item(p_LCount) = p_LDataTableTmp.Rows(p_Count).Item(p_LCount).ToString.Trim
        '                Catch ex As Exception

        '                End Try

        '            Next
        '            p_LDataTable.Rows.Add(p_DataRow)
        '        End If
        '    Next
        '    'p_LDataTable.RejectChanges
        '    For p_Count = 0 To p_HDataTable.Rows.Count - 1
        '        p_HDuXuat = IIf(p_HDataTable.Rows(p_Count).Item("TongXuat").ToString.Trim = "", 0, p_HDataTable.Rows(p_Count).Item("TongXuat"))
        '        p_ArrRow = p_LDataTable.Select("TableID='" & p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim & "'")
        '        'p_Value = p_HDataTable.Rows(p_Count).Item("").ToString.Trim
        '        p_LDuXuat = 0
        '        If p_ArrRow.Length > 0 Then
        '            For p_LCount = 0 To p_ArrRow.Length - 1
        '                If p_ArrRow(p_LCount).Item("MaHangHoa").ToString.Trim <> p_HDataTable.Rows(p_Count).Item("MaHangHoa").ToString.Trim Then
        '                    ShowMessageBox("", "Mã lệnh " & p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim & " mã hàng hóa không đúng")
        '                    KiemTraThongTin = True
        '                    Exit Function
        '                End If
        '                ' p_LDuXuat = p_LDuXuat + IIf(p_ArrRow(p_LCount).Item("SoLuongDuXuat").ToString.Trim = "", 0, p_ArrRow(p_LCount).Item("SoLuongDuXuat"))
        '            Next

        '            'If p_HDuXuat <> p_LDuXuat Then
        '            '    ShowMessageBox("", "Mã lệnh " & p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim & " Tổng dự xuất không đúng")
        '            '    KiemTraThongTin = True
        '            '    Exit Function
        '            'End If
        '        End If
        '    Next

        '    'Kiem tra neu cung tableId thi khong  co trung ma ngan
        '    p_SQL = "FPT_CheckBeforSave '" & p_SoLenh & "'"
        '    p_HDataTable = GetDataTable(p_SQL, p_SQL)
        '    If Not p_HDataTable Is Nothing Then
        '        If p_HDataTable.Rows.Count > 0 Then
        '            ShowMessageBox("", p_HDataTable.Rows(0).Item("StrDesc").ToString.Trim)
        '            KiemTraThongTin = True
        '            Exit Function
        '        End If
        '    End If

        '    'p_SQL = "select MaNgan, SoLuongMax  from tblChiTietPhuongTien where MaPhuongTien='" & p_SQL & "'"
        '    'p_HDataTable = GetDataTable(p_SQL, p_SQL)
        '    'If Not p_HDataTable Is Nothing Then
        '    '    For p_LCount = 0 To p_HDataTable.Rows.Count - 1
        '    '        p_HDuXuat = IIf(p_HDataTable.Rows(p_Count).Item("SoLuongMax").ToString.Trim = "", 0, p_HDataTable.Rows(p_LCount).Item("SoLuongMax"))
        '    '        p_LDuXuat = 0
        '    '        'p_LDuXuat = p_LDuXuat.Rows(0).Item(0).ToString.Trim
        '    '        p_ArrRow = p_LDataTable.Select("MaNgan='" & p_HDataTable.Rows(p_LCount).Item("MaNgan").ToString.Trim & "'")
        '    '        If p_ArrRow.Length > 0 Then
        '    '            For p_Count = 0 To p_ArrRow.Length - 1
        '    '                p_LDuXuat = p_LDuXuat + IIf(p_ArrRow(p_Count).Item("SoLuongDuXuat").ToString.Trim = "", 0, p_ArrRow(p_Count).Item("SoLuongDuXuat"))
        '    '            Next
        '    '            If p_HDuXuat <> p_LDuXuat Then
        '    '                ShowMessageBox("", "Mã ngăn " & p_HDataTable.Rows(p_LCount).Item("MaNgan").ToString.Trim & " Tổng số dự xuất không đúng")
        '    '                KiemTraThongTin = True
        '    '                Exit Function
        '    '            End If
        '    '        End If
        '    '    Next
        '    'End If
        'Catch ex As Exception
        '    KiemTraThongTin = True
        'End Try

    End Function


    Function KiemTraKhiLuuLenh(ByVal p_SoLenh As String) As Boolean
        Dim p_SQL As String
        Dim p_Row() As DataRow
        Dim p_Table As DataTable

        KiemTraKhiLuuLenh = True

        p_SQL = "exec "
        Try

        Catch ex As Exception
            ShowMessageBox("", ex.Message)
            KiemTraKhiLuuLenh = False
        End Try

    End Function

    Sub SaveRecode()
        Dim p_DataRow As DataRow
        ' Dim p_mahanghoa As String
        Dim p_Datatable As DataTable
        ' Dim p_Datatable1 As DataTable
        Dim p_SQL As String = ""
        'Dim p_LineIDTmp As String = "000000"
        'Dim p_LineID As String = ""
        'Dim p_Date As String

        'Dim p_MaLenh As String
        Dim p_SoLenh As String = ""
        Dim p_SoLenh_Line As String = ""
        'Dim p_MaBe As String
        'Dim p_TableID As String
        Dim p_Date As Date = Nothing
        Dim p_MaTDH As Integer
        'Dim p_DataSet As DataSet
        Dim p_Binding As New U_TextBox.U_BindingSource
        'Dim p_Binding1 As New U_TextBox.U_BindingSource
        'Dim p_Binding_Ghep As New U_TextBox.U_BindingSource

        Dim p_VanChuyen As String = ""
        Dim p_LoaiXuat As String = ""
        Dim p_PhuongTien As String = ""
        Dim p_Status As String = ""
        Dim p_Count As Integer
        Dim p_NguoiVanChuyen As String = ""


        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If p_SoLenh = "" Then
            ShowMessageBox(True, "Số lệnh xuất chưa nhập", 3)
            Me.SoLenh.Focus()
            Exit Sub
        End If



        Me.GridView2.RefreshData()

        Me.MaDonVi.EditValue = g_Company_Code

        If Me.NgayXuat.EditValue Is Nothing Then
            ShowMessageBox(True, "Ngày tháng chưa nhập", 3)
            '    Exit Sub
            Exit Sub
        End If
        If Not Me.MaPhuongTien.EditValue Is Nothing Then
            p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
        End If
        If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
            p_NguoiVanChuyen = Me.NguoiVanChuyen.EditValue.ToString.Trim
        End If
        If p_PhuongTien = "" Then
            If p_PTien1 <> "" Then
                p_PhuongTien = p_PTien1
                Me.MaPhuongTien.EditValue = p_PhuongTien
                ' Me.NguoiVanChuyen.EditValue = p_NVC1
            End If
        End If


        If p_NguoiVanChuyen = "" Then
            If p_NVC1 <> "" Then

                Me.NguoiVanChuyen.EditValue = p_NVC1
            End If
        End If

        'Me.GridView3.RefreshData()
        'Me.GridView2.RefreshData()
        'Me.GridView1.RefreshData()

        If KiemTraThongTin(p_SoLenh) = True Then
            Exit Sub
        End If

        If KiemTraKhiLuuLenh(p_SoLenh) = False Then
            Exit Sub
        End If

        p_Date = Me.NgayXuat.EditValue

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If KiemTraLineID_TableID() = False Then
            Exit Sub
        End If


        'Me.LoaiPhieu.EditValue = g_LoaiPhieu
        Try

            If p_Status = "31" Or p_Status = "3" Or p_Status = "4" Or p_Status = "5" Then
                GoTo Line_TT001
            End If


            With Me.GridView1
                '.EndUpdate()
                p_SoLenh_Line = ""
                For p_Count = 0 To .RowCount - 1
                    If .IsDataRow(p_Count) = True Then
                        p_DataRow = .GetDataRow(p_Count)
                        If p_DataRow Is Nothing Then
                            Continue For
                        End If
                        'p_SoLenh_Line
                        If p_DataRow.Item("SoLenh").ToString.Trim <> "" Then
                            If p_SoLenh_Line = "" Then
                                p_SoLenh_Line = p_DataRow.Item("SoLenh").ToString.Trim
                            Else
                                If p_SoLenh_Line <> p_DataRow.Item("SoLenh").ToString.Trim Then
                                    p_LenhGhep = True
                                    p_SoLenh_Line = p_SoLenh_Line & "," & p_DataRow.Item("SoLenh").ToString.Trim
                                End If
                            End If

                        End If
                        If p_DataRow.Item("TongXuat").ToString.Trim = "" Then
                            'ShowStatusMessage(True, "MS0051", "Chưa tính QCI", 10)
                            ShowMessageBox("MS0051", "Chưa tính QCI", 3)
                            Exit Sub
                        End If
                        Try
                            If .GetRowCellValue(p_Count, "NgayXuat").ToString.Trim = "" Then
                                .SetRowCellValue(p_Count, "NgayXuat", p_Date)
                                .SetRowCellValue(p_Count, "CHECKUPD", "Y")
                            ElseIf .GetRowCellValue(p_Count, "NgayXuat") <> p_Date Then
                                .SetRowCellValue(p_Count, "NgayXuat", p_Date)
                                .SetRowCellValue(p_Count, "CHECKUPD", "Y")
                            End If
                        Catch ex As Exception
                            .SetRowCellValue(p_Count, "NgayXuat", p_Date)
                            .SetRowCellValue(p_Count, "CHECKUPD", "Y")
                        End Try

                    End If
                Next
                ' .EndUpdate()
            End With
            Me.GridView2.MoveLast()

            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
            End If

            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_LoaiXuat = Me.MaVanChuyen.EditValue.ToString.Trim
            End If

            GetMaVanChuyen(p_PhuongTien, p_LoaiXuat, p_VanChuyen)

            Me.GridView2.MoveLast()
            For p_Count = Me.GridView2.RowCount - 1 To 0 Step -1
                If GridView2.IsDataRow(p_Count) = True Then
                    p_DataRow = Me.GridView2.GetDataRow(p_Count)
                    If Me.GridView2.GetRowCellValue(p_Count, "MaNgan").ToString.Trim = "" Or Me.GridView2.GetRowCellValue(p_Count, "TableID").ToString.Trim = "" Then
                        If Me.GridView2.IsRowSelected(p_Count) = True Then
                            ' Me.GridView2.DeleteRow(p_Count)
                            Me.TrueDBGrid2.EmbeddedNavigator.Buttons.DoClick(Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Remove)
                        End If

                        ' Me.GridView2.DeleteRow(p_Count)
                    Else
                        Try
                            If GridView2.GetRowCellValue(p_Count, "NgayXuat").ToString.Trim = "" Then
                                GridView2.SetRowCellValue(p_Count, "NgayXuat", p_Date)
                            ElseIf GridView2.GetRowCellValue(p_Count, "NgayXuat") <> p_Date Then
                                GridView2.SetRowCellValue(p_Count, "NgayXuat", p_Date)
                            End If
                        Catch ex As Exception
                            GridView2.SetRowCellValue(p_Count, "NgayXuat", p_Date)
                        End Try
                        'If p_DataRow.Item("MaTuDongHoa").ToString.Trim = "" Then
                        '    If p_MATUDONGHOA = True Then
                        '        p_MaTDH = GetMaTuDongHoa()
                        '        If p_MaTDH = 0 Then
                        '            ShowMessageBox("", "Lỗi khi tạo số tự động hóa")
                        '            Exit Sub
                        '        End If
                        '        GridView2.SetRowCellValue(p_Count, "MaTuDongHoa", p_MaTDH)
                        '    End If
                        'End If

                        GridView2.SetRowCellValue(p_Count, "CHECKUPD", "R")

                        GridView2.SetRowCellValue(p_Count, "PhuongTien", p_VanChuyen)

                        'Xoa line
                        If p_DataRow.Item("Row_ID").ToString.Trim <> "" Then
                            p_SQL = "delete from tblLenhXuatChiTietE5 where Row_ID=" & p_DataRow.Item("Row_ID").ToString.Trim
                            p_DataRow = Me.pv_LineRemove.NewRow
                            p_DataRow.Item(0) = p_SQL
                            Me.pv_LineRemove.Rows.Add(p_DataRow)
                        End If
                    End If
                    Me.GridView2.MovePrev()
                End If
            Next
            If p_MATUDONGHOA = True Then
                If Me.GridView2.RowCount > 0 Then
                    For p_Count = 0 To Me.GridView2.RowCount - 1
                        p_DataRow = GridView2.GetDataRow(p_Count)
                        If Not p_DataRow Is Nothing Then
                            If p_DataRow.Item("MaTuDongHoa").ToString.Trim = "" Then
                                ' p_MATUDONGHOA = True Then
                                p_MaTDH = GetMaTuDongHoa()
                                If p_MaTDH = 0 Then
                                    ShowMessageBox("", "Lỗi khi tạo số tự động hóa", 3)
                                    Exit Sub
                                End If
                                GridView2.SetRowCellValue(p_Count, "MaTuDongHoa", p_MaTDH)
                                'End If
                            End If
                        End If


                    Next
                End If
            End If
            'Me.GridView2.AllowInsert = True

            If g_KV1 = False Then
                If getNguoiVanChuyen(p_PhuongTien, p_NguoiVanChuyen, p_SQL, Me) = False Then
                    ' ShowMessageBox("", p_Desc)
                    'Me.MaPhuongTien.EditValue = ""
                    '  e.Cancel = True
                    Exit Sub
                End If

            End If

            If GridView2.RowCount <= 0 Then
                ShowMessageBox("", "Lệnh xuất chưa được đặt ngăn", 3)
                '    Exit Sub
                '  Exit Sub
            End If
            'p_DataRow = Me.pv_LineRemove.NewRow
            'p_SQL = "delete from tblLenhXuatChiTietE5 where exists  (" & _
            '            "select 1  from tblLenhXuat_HangHoaE5 a where SoLenh='" & p_SoLenh & "'" & _
            '            "and MaLenh=tblLenhXuatChiTietE5.MaLenh and NgayXuat=tblLenhXuatChiTietE5.NgayXuat " & _
            '            "and LineID=tblLenhXuatChiTietE5.LineID)"
            'p_DataRow.Item(0) = p_SQL
            'Me.pv_LineRemove.Rows.Add(p_DataRow)
            p_SQL = "select COUNT(*) as MaVanChuyen from  (" & _
                    " select MaVanChuyen, COUNT(MaVanChuyen) as MaVanChuyen1 from tblLenhXuatE5  " & _
                   "  where CHARINDEX (',' + SoLenh + ',','," & p_SoLenh_Line & ",',1)>0 " & _
                  "    group by MaVanChuyen) abc "
            p_Datatable = GetDataTable(p_SQL, p_SQL)


            If Not p_Datatable Is Nothing Then
                If p_Datatable.Rows(0).Item(0) > 1 Then
                    ShowMessageBox("", "Lệnh ghép khác Loại hình phương tiện")
                    Exit Sub
                End If
            End If
            If p_LenhGhep = True Then
                Me.RefreshAfterSave = False
            Else
                Me.RefreshAfterSave = True
            End If
            Me.TrueDBGrid2.Update()
            Me.GridView2.RefreshData()
            p_Binding = New U_TextBox.U_BindingSource
            p_Binding = Me.TrueDBGrid2.DataSource
            p_Datatable = CType(p_Binding.DataSource, DataTable)

            If Not p_Datatable Is Nothing Then
                ' p_Datatable1 = p_Datatable
                For p_Count = p_Datatable.Rows.Count - 1 To 0 Step -1
                    If Me.GridView2.IsDataRow(p_Count) = True Then
                        If p_Datatable.Rows(p_Count).RowState = DataRowState.Deleted Then

                        Else
                            If p_Datatable.Rows(p_Count).Item("TableID").ToString.Trim = "" Then
                                Try
                                    p_Datatable.Rows.RemoveAt(p_Count)
                                Catch ex As Exception

                                End Try

                            End If
                        End If

                    End If

                Next
            End If

            p_Binding.DataSource = p_Datatable
            Me.TrueDBGrid2.DataSource = p_Binding

Line_TT001:
            Me.DefaultSave = True
            If Not Me.Status.EditValue Is Nothing Then
                p_Status = Me.Status.EditValue
            End If
            If p_Status = "1" Or p_Status = "2" Or p_Status = "" Then
                'GetTaiTrongKG(p_NhietDoNgay, False)
                If g_KV1 = True Then
                    If p_LenhGhep = True Then
                        Me.aNumber.EditValue = Me.GridView1.RowCount
                    Else
                        If Me.aNumber.EditValue Is Nothing Then
                            Me.aNumber.EditValue = Me.GridView1.RowCount
                        ElseIf Me.aNumber.EditValue.ToString.Trim = "" Then
                            Me.aNumber.EditValue = Me.GridView1.RowCount
                        ElseIf Me.aNumber.EditValue.ToString.Trim = "0" Then
                            Me.aNumber.EditValue = Me.GridView1.RowCount
                        End If
                    End If
                End If

            End If

            If p_LenhGhep = True Then

                CapNhatPhuongTienGhep()

            End If
            UpdateToDatabase(Me, Me.ButtonSave)
            Me.DefaultSave = False



            If p_LenhGhep = True And Me.DefaultSave = False Then
                GridView3.ClearGrouping()
                p_PhuongTien = ""
                p_VanChuyen = ""
                If Not Me.MaPhuongTien.EditValue Is Nothing Then
                    p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
                End If
                If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
                    p_VanChuyen = Me.NguoiVanChuyen.EditValue.ToString.Trim
                End If
                ' CapNhatPhuongTienGhep()
                p_Binding = Me.GridView3.DataSource
                p_Datatable = CType(p_Binding.DataSource, DataTable)

                For p_Count = 0 To p_Datatable.Rows.Count - 1
                    p_Datatable.Rows(p_Count).Item("MaPhuongTien") = p_PhuongTien
                    p_Datatable.Rows(p_Count).Item("NguoiVanChuyen") = p_VanChuyen
                    ' Me.GridView3.SetRowCellValue(p_Count, "MaPhuongTien", p_PhuongTien)
                    ' Me.GridView3.SetRowCellValue(p_Count, "NguoiVanChuyen", p_VanChuyen)
                    'p_DataRow = GridView3.GetDataRow(p_Count)
                    'If Not p_DataRow Is Nothing Then
                    '    If Expression Then

                    '    End If
                    'End If
                Next
                p_Binding.DataSource = p_Datatable
                Me.TrueDBGrid3.DataSource = p_Binding
            End If


            'Me.pv_LineRemove 
            'Me.GridView2.AllowInsert = False
            'GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            If p_LenhGhep = False Then  'Neu la lenh ghep thi khong refresh lai du lieu
                If Me.ErrorSave = False Then

                    Me.DefaultFormLoad = True
                    XtraForm1_Load()
                    Me.DefaultFormLoad = False

                Else
                    Exit Sub
                End If
                GopTichKe(True)

            Else

                'p_SoLenh_Line
                'p_SQL = "exec  FPT_LenhXuatHangHoaE5_Ghep_V  '" & p_SoLenh_Line & "'"
                'p_DataSet = GetDataSet(p_SQL, p_SQL)
                'If p_DataSet.Tables.Count > 0 Then
                '    p_Datatable1 = p_DataSet.Tables(0)
                '    p_Binding1.DataSource = p_Datatable1
                '    Me.TrueDBGrid1.DataSource = p_Binding1
                '    TrueDBGrid1.RefreshDataSource()

                '    p_Datatable = p_DataSet.Tables(1)
                '    p_Binding.DataSource = p_Datatable
                '    Me.TrueDBGrid2.DataSource = p_Binding
                '    TrueDBGrid2.RefreshDataSource()
                'End If

                GopTichKe(True, False)
            End If


            Me.RefreshAfterSave = True


            ' Dim p_Count As Integer
            'p_Binding_Ghep = New U_TextBox.U_BindingSource

            'p_Binding_Ghep = Me.GridView3.DataSource
            'p_Datatable = p_Binding_Ghep.DataSource
            'p_Datatable.Clear()
            'p_Binding_Ghep.DataSource = p_Datatable
            'Me.TrueDBGrid3.DataSource = p_Binding
            'Me.TrueDBGrid3.RefreshDataSource()
            'Try
            '    For p_Count = Me.GridView3.RowCount - 1 To 0 Step -1
            '        Me.GridView3.DeleteRow(p_Count)
            '    Next
            'Catch ex As Exception

            'End Try

            ' GopTichKe(True)
        Catch ex As Exception
            p_XtraModuleObj.ModErrExceptionNew(Err.Number, ex.Message)
        End Try
    End Sub

    Sub CapNhatPhuongTienGhep()
        Dim p_SoLenhXuat As String = ""
        Dim p_PhuongTien As String = ""
        Dim p_NguoiVanChuyen As String = ""
        Dim p_Row As DataRow
        Dim p_SQL As String = ""
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_DataTable As DataTable
        Dim p_Count As Integer
        Dim p_StringLenh As String = ""
        Dim p_StrArr() As String
        Dim p_MaVanChuyen As String = ""



        If Not Me.MaPhuongTien.EditValue Is Nothing Then
            p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
        End If
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenhXuat = Me.SoLenh.EditValue.ToString.Trim
        End If
        If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
            p_NguoiVanChuyen = Me.NguoiVanChuyen.EditValue.ToString.Trim
        End If


        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
        End If


        If p_PhuongTien <> "" And p_SoLenhXuat <> "" And p_NguoiVanChuyen <> "" Then
            If pv_LineRemove Is Nothing Then
                pv_LineRemove.Columns.Add("STRSQL")
            End If
            p_Binding = Me.TrueDBGrid3.DataSource
            p_DataTable = CType(p_Binding.DataSource, DataTable)
        End If

        For p_Count = 0 To Me.GridView1.RowCount - 1
            p_Row = Me.GridView1.GetDataRow(p_Count)
            If Not p_Row Is Nothing Then
                If p_Row.Item("SoLenh").ToString.Trim <> "" Then
                    If InStr(p_StringLenh, p_Row.Item("SoLenh").ToString.Trim, CompareMethod.Text) <= 0 Then
                        p_StringLenh = p_StringLenh & "," & p_Row.Item("SoLenh").ToString.Trim
                    End If
                End If
            End If
        Next

        'For p_Count = 0 To Me.GridView3.RowCount - 1
        '    If Not Me.GridView3.GetGroupRowValue(p_Count) Is Nothing Then
        '        If InStr(p_StringLenh, Me.GridView3.GetGroupRowValue(p_Count).ToString.Trim, CompareMethod.Text) <= 0 And Me.GridView3.GetGroupRowValue(p_Count).ToString.Trim <> p_SoLenhXuat.ToString.Trim Then
        '            p_StringLenh = p_StringLenh & "," & Me.GridView3.GetGroupRowValue(p_Count).ToString.Trim
        '        End If

        '    End If

        'Next
        If Len(p_StringLenh) > 0 Then
            p_StringLenh = Mid(p_StringLenh, 2)
            p_StrArr = p_StringLenh.Split(",")
        End If
        If Not p_StrArr Is Nothing Then
            For p_Count = 0 To p_StrArr.Length - 1
                p_SQL = "UPDATE tblLenhXuatE5 set Client='" & g_Terminal & "', MaVanChuyen='" & p_MaVanChuyen & "', MaPhuongTien='" & p_PhuongTien & "', NguoiVanChuyen=N'" & _
                            p_NguoiVanChuyen & "' where SoLenh='" & p_StrArr(p_Count) & "' "
                p_Row = pv_LineRemove.NewRow
                p_Row.Item(0) = p_SQL
                pv_LineRemove.Rows.Add(p_Row)
            Next
        End If
        ' Dim pp_DataTable As String
    End Sub

    Function GetTableID() As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        p_SQL = " exec FPT_GetTableID"
        GetTableID = ""
        Try
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTableID = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
        Catch ex As Exception
            GetTableID = ""
        End Try

    End Function

    Function GetMaTuDongHoa() As Integer
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        p_SQL = " exec FPT_Key_TuDongHoa"
        GetMaTuDongHoa = 0
        Try
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetMaTuDongHoa = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
        Catch ex As Exception
            GetMaTuDongHoa = 0
        End Try
    End Function

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim p_FrmQCI As New FrmQCI
        Dim p_EditValue As Integer
        Dim p_SoLenh As String = ""
        Dim p_Status As String = ""
        Dim p_FormStatus As Boolean

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If
        If p_Status <> "1" And p_Status <> "2" Then
            ShowMessageBox("", "Lệnh xuất đã được đẩy vào hệ thống bơm xuất", 1)
            Exit Sub
        End If
        p_FrmQCI.p_Top = Me.MousePosition.Y
        p_FrmQCI.p_Left = Me.MousePosition.X
        '  p_FrmQCI.p_Edit = p_EditValue

        p_FormStatus = Me.FormStatus

        p_FrmQCI.ShowDialog(Me)
        'TinhQCI()
        If Not p_FrmQCI.p_Edit.EditValue Is Nothing Then
            p_EditValue = p_FrmQCI.p_Edit.EditValue
        Else
            p_EditValue = 15
        End If

        TinhQCI(p_EditValue)
        If p_Status <> "1" And p_Status <> "2" Then
            Me.FormStatus = False
        End If
    End Sub

    Private Sub SoLenh_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoLenh.EditValueChanged

    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim p_Value As String

        If UCase(e.Column.FieldName.ToString.Trim) = "BEXUAT" And g_TAITRONGKG = True Then
            p_Value = e.Value
            GetTaiTrongKG(p_NhietDoNgay, True)
        End If

        'If CongTo_Bo() = True Then

        'End If


    End Sub

    Private Sub GridView1_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanging
        '  e.
    End Sub

    Private Sub GridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyDown

    End Sub

    Private Sub GridView1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If CongTo_Bo() = True Then
            e.Handled = True
        End If

    End Sub

    Private Sub GridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
        If CongTo_Bo() = True Then
            e.Handled = True
        End If
    End Sub


    Private Sub GridView1_ShowingEditor(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GridView1.ShowingEditor
        'If CongTo_Bo() = True Then
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub GridView1_ShownEditor(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.ShownEditor
        'If CongTo_Bo() = True Then

        'End If
    End Sub

    Private Sub GridView1_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim p_Gridview As U_TextBox.GridView
        Dim p_Column As U_TextBox.GridColumn
        Dim p_DataRow() As DataRow
        p_Gridview = CType(sender, U_TextBox.GridView)
        p_Column = p_Gridview.FocusedColumn
        If UCase(p_Column.FieldView) = "DONVITINH" Then
            If e.Value.ToString.Trim <> "" Then
                p_DataRow = p_DataTableDVT.Select("Code='" & e.Value.ToString.Trim & "'")
                If p_DataRow.Length <= 0 Then
                    ' p_XtraModuleObj.ModErrExceptionNew("", "Đơn vị tính không đúng")
                    ShowMessageBox("", "Đơn vị tính không đúng", 3)
                    e.Valid = False
                    Exit Sub
                End If
            End If
        End If
        'e.Value

    End Sub

    'Private Sub GridView2_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView2.ValidatingEditor
    '    Dim p_Gridview As U_TextBox.GridView
    '    Dim p_Column As U_TextBox.GridColumn
    '    Dim p_DataRow() As DataRow
    '    p_Gridview = CType(sender, U_TextBox.GridView)
    '    p_Column = p_Gridview.FocusedColumn
    '    If UCase(p_Column.FieldView) = UCase("DungTichNgan") Then
    '        If e.Value.ToString.Trim <> "" Then
    '            Me.GridView2.SetFocusedRowCellValue("LColSoLuongDuXuat", e.Value)
    '            'p_DataRow = p_DataTableDVT.Select("Code='" & e.Value.ToString.Trim & "'")
    '            'If p_DataRow.Length <= 0 Then
    '            '    p_XtraModuleObj.ModErrExceptionNew("", "Đơn vị tính không đúng")
    '            '    e.Valid = False
    '            '    Exit Sub
    '            'End If
    '        End If
    '    End If
    '    'e.Value

    'End Sub


    Private Sub ToolAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolAuto.Click
        Dim p_SoLenh As String = ""
        Dim p_PhuongTien As String = ""
        Dim p_TableNgan As New DataTable
        Dim p_FormDatNgan As FrmDatNgan
        Dim p_Count As Integer
        Dim p_Col As Integer
        Dim p_TableLine As DataTable
        Dim p_DataRow As DataRow
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_Column As DataColumn
        Dim p_MaLenh As String
        Dim p_NgayXuat As Date
        'Dim p_DataRow As DataRow
        Dim p_SQL As String
        Dim p_Status As String = ""
        Dim p_LoaiXuat As String = ""

        Try

            If Not Me.SoLenh.EditValue Is Nothing Then
                p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
            End If
            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
            End If

            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_LoaiXuat = Me.MaVanChuyen.EditValue.ToString.Trim
            End If

            ' Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)

            ' If Not Me.LoaiXuat.EditValue Is Nothing Then
            p_LoaiXuat = GetLoadingSite(p_LoaiXuat)
            ' End If

            If Not Me.Status.EditValue Is Nothing Then
                p_Status = Me.Status.EditValue.ToString.Trim
            End If
            If p_Status <> "1" And p_Status <> "2" Then
                ShowMessageBox("", "Lệnh xuất đã được đẩy vào hệ thống bơm xuất", 1)
                Exit Sub
            End If
            'If Me.FormStatus = True Then
            '    SaveRecode()
            'End If

            p_Binding = Me.TrueDBGrid1.DataSource
            p_TableLine = CType(p_Binding.DataSource, DataTable)
            p_TableLine.AcceptChanges()
            p_SoLenh = ""
            For p_Count = 0 To p_TableLine.Rows.Count - 1
                If p_SoLenh <> p_TableLine.Rows(p_Count).Item("SoLenh").ToString.Trim Then
                    p_SoLenh = p_SoLenh & "," & p_TableLine.Rows(p_Count).Item("SoLenh").ToString.Trim
                End If
            Next


            ' Load1(p_PhuongTien, p_TableLine, p_TableNgan)


            p_FormDatNgan = New FrmDatNgan(p_SoLenh, p_PhuongTien, p_TableLine)
            p_FormDatNgan.LoaiXuat = p_LoaiXuat
            p_FormDatNgan.ShowDialog(Me)
            p_TableNgan = p_FormDatNgan.g_dt_compartment
            If Not p_TableNgan Is Nothing Then
                Cursor = Cursors.WaitCursor
                GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                p_Count = 0
                While Me.GridView2.RowCount - 1 >= 0 And p_Count < 100
                    Try
                        p_Count = p_Count + 1
                        p_DataRow = GridView2.GetDataRow(Me.GridView2.RowCount - 1)
                        If p_DataRow.Item("Row_id").ToString.Trim <> "" Then
                            p_SQL = p_DataRow.Item("Row_id").ToString.Trim
                            p_SQL = "Delete from tblLenhXuatChiTietE5 where  Row_id=" & p_SQL
                            p_DataRow = Me.pv_LineRemove.NewRow
                            p_DataRow.Item(0) = p_SQL
                            Me.pv_LineRemove.Rows.Add(p_DataRow)
                        End If
                        GridView2.DeleteRow(Me.GridView2.RowCount - 1)
                    Catch ex As Exception

                    End Try
                End While
                p_Binding = Me.TrueDBGrid2.DataSource
                p_TableLine = CType(p_Binding.DataSource, DataTable)
                p_TableLine.Clear()
                For p_Count = 0 To p_TableNgan.Rows.Count - 1
                    p_DataRow = p_TableLine.NewRow

                    For p_Col = 0 To p_TableLine.Columns.Count - 1
                        p_Column = p_TableLine.Columns.Item(p_Col)
                        'If UCase(p_Column.ColumnName.ToString.Trim) = "MALENH" Then
                        '    If Not Me.MaLenh.EditValue Is Nothing Then
                        '        p_MaLenh = Me.MaLenh.EditValue.ToString.Trim
                        '        p_DataRow.Item(p_Column.ColumnName) = p_MaLenh
                        '    End If
                        'End If


                        'p_NgayXuat = Now.Date
                        If UCase(p_Column.ColumnName.ToString.Trim) = "NGAYXUAT" Then
                            If Not Me.NgayXuat.EditValue Is Nothing Then
                                p_NgayXuat = Me.NgayXuat.EditValue
                                p_DataRow.Item(p_Column.ColumnName) = p_NgayXuat
                            End If
                        End If
                        Try
                            'GridView2.SetRowCellValue(GridView2.FocusedRowHandle, p_Column.FieldView, p_TableNgan.Rows(p_Count).Item(p_Column.FieldView).ToString.Trim)
                            p_DataRow.Item(p_Column.ColumnName) = p_TableNgan.Rows(p_Count).Item(p_Column.ColumnName).ToString.Trim
                        Catch ex As Exception

                        End Try

                    Next
                    If p_TableNgan.Rows(p_Count).Item("TableID").ToString.Trim <> "" Then
                        p_DataRow.Item("CHECKUPD") = "R"
                    End If

                    p_TableLine.Rows.Add(p_DataRow)
                Next
                p_DataRow = p_TableLine.NewRow
                p_TableLine.Rows.Add(p_DataRow)
                p_Binding.DataSource = p_TableLine
                Me.TrueDBGrid2.DataSource = p_Binding
                'TrueDBGrid2.Refresh()
                GridView2.RefreshData()
                GridView2.OptionsBehavior.Editable = True
                'Try
                '    p_Status = Me.Client.Text
                '    Me.Client.EditValue = p_Status
                'Catch ex As Exception

                'End Try
                ' GridView2.AddNewRow()
                'GridView2.EndUpdate()
                '  GridView2.AllowInsert = True
                'GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "CHECKUPD", "Y")
                '  GridView2.n()
                Me.FormStatus = True
                Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
                GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
                Cursor = Cursors.Default
            End If

            ' p_Binding.DataSource = p_TableLine

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        'Dim p_ValueTmp As String = "0000000000"
        Dim p_Value As String
        Dim p_MaVanChuyen As String
        Dim p_DataTable As DataTable
        Dim p_DataSet As New DataSet
        Dim p_DataTableDel As New DataTable("STR")
        Dim p_DataRow As DataRow
        Dim p_SQL As String
        Dim p_Status As String = "1"
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_PhuongTien As String
        Dim p_Client As String

        ShowStatusMessage(False, "", "")


        'If Me.FormStatus = True Then
        '    ShowMessageBox("", "Lệnh xuất chưa được lưu")
        '    Cursor = Cursors.Default
        '    Exit Sub
        'End If

        p_PTien1 = ""
        If Not Me.Status.EditValue Is Nothing Then
            If Me.Status.EditValue.ToString.Trim <> "" Then
                p_Status = Me.Status.EditValue.ToString.Trim
            End If
        End If
        If p_Status <> "1" Then
            ShowMessageBox("", "Trạng thái Lệnh xuất <>1 không hợp lệ", 3)
            Cursor = Cursors.Default
            Exit Sub
        End If
        If g_KV1 = True Then
            If Not Me.NgayXuat.EditValue Is Nothing Then
                If Me.NgayXuat.EditValue.ToString.Trim <> "" Then
                    p_Date_KV1 = Me.NgayXuat.EditValue
                End If
            End If
        End If

        If Not Me.SoLenh.EditValue Is Nothing Then
            'Me.GridView2.AllowInsert = False
            If Me.SoLenh.EditValue.ToString.Trim <> "" Then
                Cursor = Cursors.WaitCursor
                p_Value = Me.SoLenh.EditValue.ToString.Trim

                ''Kiem tra duoi DB cho chac
                p_SQL = "select Status from tblLenhXuatE5 with (Nolock) where SoLenh='" & p_Value & "';"
                p_SQL = p_SQL & "select top 1 SoLenh from tblLenhXuatE5 with (Nolock) where SoLenh='" & p_Value & "' and Status='1';"

                p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

                If Not p_DataSet Is Nothing Then
                    If p_DataSet.Tables.Count > 0 Then
                        p_DataTable = p_DataSet.Tables(0)
                        If p_DataTable.Rows.Count > 0 Then
                            If p_DataTable.Rows(0).Item("Status").ToString.Trim <> "1" And p_DataTable.Rows(0).Item("Status").ToString.Trim <> "" Then
                                ShowMessageBox("", "Trạng thái Lệnh xuất <>1 không hợp lệ", 3)
                                Cursor = Cursors.Default
                                Exit Sub
                            End If
                        End If

                    End If
                End If


                If Mid(p_Value, 1, Len(g_WareHouse)) = g_WareHouse Then
                    ShowMessageBox("", "Mã kho không hợp lệ", 3)
                    Cursor = Cursors.Default
                    Exit Sub
                End If

                If g_Filter_Terminal = True Then
                    p_SQL = ""
                    If Not Me.Client.EditValue Is Nothing Then
                        p_SQL = Me.Client.EditValue.ToString.Trim
                    End If
                    If p_SQL <> "" And p_SQL <> g_Terminal.ToString.Trim Then
                        ShowMessageBox("", "Không thực hiện được lệnh xuất của kho khác", 3)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If

                ' p_DataTable = p_DataSet.Tables(1)
                'p_SQL = "select top 1 SoLenh from tblLenhXuatE5 with (Nolock) where SoLenh='" & p_Value & "' and Status='1';"
                'p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        If p_DataTable.Rows(0).Item(0).ToString.Trim = "" Or p_DataTable.Rows(0).Item(0).ToString.Trim = "1" Then
                            'Dim p_ValueMess As Windows.Forms.DialogResult
                            p_ValueMess = g_Module.ShowMessage(Me, "", _
                                            "Bạn có chắn chắn muốn lấy lại lệnh từ SAP không?", _
                                            True, _
                                             "Có", _
                                            True, _
                                            "Không", _
                                            False, _
                                            "", _
                                             0)
                        Else
                            ShowMessageBox("", "Trạng thái lệnh xuất không hợp lệ", 3)
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End If
                    If p_ValueMess = Windows.Forms.DialogResult.No Then
                        Cursor = Cursors.Default
                        Exit Sub
                    Else
                        p_DataTableDel.Columns.Add("STRSQL")
                        p_DataRow = p_DataTableDel.NewRow
                        'anhqh 20160623
                        p_SQL = "delete from tblLenhXuatChiTietE5  where " & _
                            " exists (select 1 from tblLenhXuat_HangHoaE5  where tableid=  tblLenhXuatChiTietE5.tableid and NgayXuat=  tblLenhXuatChiTietE5.NgayXuat " & _
                                 " and SoLenh='" & p_Value & "')"
                        p_DataRow.Item(0) = p_SQL
                        p_DataTableDel.Rows.Add(p_DataRow)
                        p_DataRow = p_DataTableDel.NewRow
                        p_SQL = "delete from tblLenhXuat_HangHoaE5  where SoLenh='" & p_Value & "'"
                        p_DataRow.Item(0) = p_SQL
                        p_DataTableDel.Rows.Add(p_DataRow)
                        p_DataRow = p_DataTableDel.NewRow
                        p_SQL = "delete from tblLenhXuatE5  where SoLenh='" & p_Value & "'"
                        p_DataRow.Item(0) = p_SQL
                        p_DataTableDel.Rows.Add(p_DataRow)
                        If g_Services.Sys_Execute_DataTbl(p_DataTableDel, _
                                           p_SQL) = False Then
                            MsgBox("Error:" & p_SQL)
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                        p_SQL = ""
                        If g_WCF = False Then

                            Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

                            'If g_Services.Sys_Execute_DataTableNew(p_DataTableDel, _
                            '               p_SQL) = False Then
                            '    MsgBox("Error:" & p_SQL)
                            '    Cursor = Cursors.Default
                            '    Exit Sub
                            'End If
                            If g_KV1 = True Then
                                If p_SAP_Object.kv1clsSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_Value, p_SQL, p_Date_KV1) = False Then
                                    'If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                    'ShowStatusMessage(True, "", p_SQL, 10)
                                    ' Me.DefaultWhere = "SoLenh='00'"
                                    'MsgBox("Error:" & p_SQL)
                                    ShowMessageBox("", p_SQL)
                                    GoTo Line_tt
                                Else
                                    Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                    Me.DefaultFormLoad = True
                                    Me.Form1_Load(sender, e)
                                    Me.SoLenh.Properties.ReadOnly = False
                                    Me.SoLenh.BackColor = pv_Required_Back_Color
                                    p_PhuongTien = ""
                                    'If Not Me.MaPhuongTien.EditValue Is Nothing Then
                                    '    p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.ToString
                                    'End If
                                    'If p_PhuongTien <> "" Then
                                    '    LoadDefault(p_PhuongTien)
                                    'End If

                                    GoTo Linett2
                                    ''MsgBox("bbb")
                                End If
                            Else
                                If p_SAP_Object.clsSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                    'If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                    'ShowStatusMessage(True, "", p_SQL, 10)
                                    ' Me.DefaultWhere = "SoLenh='00'"
                                    'MsgBox("Error:" & p_SQL)
                                    ShowMessageBox("", p_SQL)
                                    GoTo Line_tt
                                Else
                                    Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                    Me.DefaultFormLoad = True
                                    Me.Form1_Load(sender, e)
                                    Me.SoLenh.Properties.ReadOnly = False
                                    Me.SoLenh.BackColor = pv_Required_Back_Color
                                    p_PhuongTien = ""
                                    'If Not Me.MaPhuongTien.EditValue Is Nothing Then
                                    '    p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.ToString
                                    'End If
                                    'If p_PhuongTien <> "" Then
                                    '    LoadDefault(p_PhuongTien)
                                    'End If

                                    GoTo Linett2
                                    ''MsgBox("bbb")
                                End If
                            End If


                        Else
                            If g_KV1 = True Then
                                If g_Services.kv1clsSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_Value, p_SQL, p_Date_KV1) = False Then
                                    'If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                    ShowStatusMessage(True, "", p_SQL, 10)
                                    ' Me.DefaultWhere = "SoLenh='00'"
                                    MsgBox("Error:" & p_SQL)
                                    GoTo Line_tt
                                Else
                                    Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                    Me.DefaultFormLoad = True
                                    Me.Form1_Load(sender, e)
                                    Me.SoLenh.Properties.ReadOnly = False
                                    Me.SoLenh.BackColor = pv_Required_Back_Color
                                    p_PhuongTien = ""
                                    'If Not Me.MaPhuongTien.EditValue Is Nothing Then
                                    '    p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.ToString
                                    'End If
                                    'If p_PhuongTien <> "" Then
                                    '    LoadDefault(p_PhuongTien)
                                    'End If
                                    GoTo LineTT2
                                    ''MsgBox("bbb")
                                End If
                            Else
                                If g_Services.mdlSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                    'If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                    ShowStatusMessage(True, "", p_SQL, 10)
                                    ' Me.DefaultWhere = "SoLenh='00'"
                                    MsgBox("Error:" & p_SQL)
                                    GoTo Line_tt
                                Else
                                    Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                    Me.DefaultFormLoad = True
                                    Me.Form1_Load(sender, e)
                                    Me.SoLenh.Properties.ReadOnly = False
                                    Me.SoLenh.BackColor = pv_Required_Back_Color
                                    p_PhuongTien = ""
                                    'If Not Me.MaPhuongTien.EditValue Is Nothing Then
                                    '    p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.ToString
                                    'End If
                                    'If p_PhuongTien <> "" Then
                                    '    LoadDefault(p_PhuongTien)
                                    'End If
                                    GoTo LineTT2
                                    ''MsgBox("bbb")
                                End If
                            End If

                        End If
                        'If SyncDeliveries_SynSpecificNew(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then

                        '    '       ShowStatusMessage(True, "", p_SQL, 7)

                        'End If
                    End If
                    'If p_DataTable.Rows.Count <= 0 Then

                    '    If SyncDeliveries_SynSpecificNew(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then

                    '        ShowStatusMessage(True, "", p_SQL, 7)

                    '    Else
                    '        Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                    '        Me.DefaultFormLoad = True
                    '        Me.Form1_Load(sender, e)
                    '        Me.SoLenh.Properties.ReadOnly = False
                    '        Me.SoLenh.BackColor = pv_Required_Back_Color
                    '    End If
                    '    Cursor = Cursors.Default
                    '    Exit Sub
                    'End If
                End If
                GridView2.AllowInsert = True
                Me.GridView2.OptionsBehavior.ReadOnly = False



                Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                Me.DefaultFormLoad = True
                Me.Form1_Load(sender, e)
                ' Me.FormStatus = True

                If g_KV1 = True Then
                    If Me.Status.EditValue.ToString.Trim = "1" Or Me.Status.EditValue.ToString.Trim = "2" Or Me.Status.EditValue.ToString.Trim = "" Then
                        Try
                            If Me.NgayXuat.EditValue < p_Date_KV1 Then
                                Me.NgayXuat.EditValue = p_Date_KV1
                            End If
                            '  Me.NgayXuat.EditValue = p_Date_KV1
                            'Me.DefaultSave = True
                            'Me.UpdateToDatabase(Me, "")
                            'Me.DefaultSave = True
                        Catch ex As Exception

                        End Try

                    End If
                End If

                p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
                Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)
LineTT2:

                LoadNewRow()

                Me.FormEdit = True
                Me.GridView2.OptionsBehavior.ReadOnly = False
                Me.GridView1.OptionsBehavior.ReadOnly = False
                Me.MaVanChuyen.Properties.ReadOnly = False
                Me.NguoiVanChuyen.Properties.ReadOnly = False
                Me.GridView2.AllowInsert = True
                If Me.Client.EditValue Is Nothing Then
                    '.Client.EditValue = g_Terminal
                    Me.Client.EditValue = GetClient(p_MaVanChuyen)
                Else
                    If Me.Client.EditValue.ToString.Trim = "" Then
                        Me.FormStatus = False
                        ' Me.Client.EditValue = g_Terminal
                        Me.Client.EditValue = GetClient(p_MaVanChuyen)
                        GoTo Line_tt
                        '  Me.FormStatus = True
                    End If
                End If
                ' LenhGhep(p_Value)
                GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
                Me.FormStatus = False
Line_tt:
                GopTichKe(True)
                Me.MaVanChuyen.Focus()
                Cursor = Cursors.Default

                p_DanhSachPTGhep = ""
                p_PTien1 = ""
                p_NVC1 = ""


                'Me.BtnOk.Text = "Ok"
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        ' If Me.BtnOk.Text = Me.CaptionAdd And Me.FormStatus = False Then
        Dim p_SoLenh = ""

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        Dim p_Date As Date
        'If g_KV1 = True Then

        'End If
        If Not Me.NgayXuat.EditValue Is Nothing Then
            If Me.NgayXuat.EditValue.ToString.Trim <> "" Then
                p_Date = Me.NgayXuat.EditValue
            End If
        End If
        If p_Date > p_Date_KV1 Then
            p_Date_KV1 = p_Date
        End If
        ShowStatusMessage(False, "", "")


        p_DanhSachPTGhep = ""
        p_PTien1 = ""
        p_NVC1 = ""

        'Me.ChartControl2.Visible = False
        Me.ChartControl2.PaletteName = "Palette 4"
        ResetChart()
        ' Me.g_FormLoad = True
        g_FormAddnew = True
        Dim p_Count As Integer
        p_LenhGhep = False
        Try
            For p_Count = Me.GridView3.RowCount - 1 To 0 Step -1
                Me.GridView3.DeleteRow(p_Count)
            Next
        Catch ex As Exception

        End Try
        Me.FormEdit = True
        Me.GridView2.OptionsBehavior.ReadOnly = False
        Me.GridView1.OptionsBehavior.ReadOnly = False
        Me.FormStatus = False
        Me.DefaultWhere = "1=0"
        Me.Navigator1.Buttons.DoClick(Me.Navigator1.Buttons.Append)
        ' FormStatus = True

        Me.FormStatus = True
        'Me.g_FormLoad = False
        g_FormAddnew = True
        Me.FormStatus = True

        If g_KV1 = True Then
            Me.NgayXuat.EditValue = p_Date_KV1
        Else
            Me.NgayXuat.EditValue = p_DateCreate
        End If

        Me.FormStatus = False
        Me.SoLenh.Enabled = True
        Me.SoLenh.Properties.ReadOnly = False


        Me.ToolStripButton4.Enabled = True

        Me.SoLenh.Focus()
        'If p_Value = "Y" Then
        Me.SoLenh.BackColor = pv_Required_Back_Color
        Me.Client.EditValue = g_Terminal

        If Not Me.pv_LineRemove Is Nothing Then   '.Rows.Add(p_DataRow) Then
            If Me.pv_LineRemove.Columns.Count > 0 Then
                Me.pv_LineRemove.Clear()
            End If
        End If

        Me.ToolStripButton4.Enabled = True
        Me.FormEdit = True
        Me.GridView2.OptionsBehavior.ReadOnly = False
        Me.GridView1.OptionsBehavior.ReadOnly = False
        Me.MaVanChuyen.Properties.ReadOnly = False
        Me.NguoiVanChuyen.Properties.ReadOnly = False
        Me.GridView2.AllowInsert = True

        ' LenhGhep(p_Value)
        GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom


        If p_SoLenh <> "" And g_KV1 = False Then
            Me.SoLenh.EditValue = p_SoLenh

            ' Me.SoLenh.SendKey()

        End If


        'End If
        'End If
    End Sub

    Function KiemTraNgayXuatHang(ByVal p_SoLenh As String, ByRef p_Desc As String) As Boolean
        Dim p_Date As Date
        Dim p_Time As Integer
        Dim p_SQL As String
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_Data As DataTable
        Dim p_NgayXuat As Date
        Dim p_Status As String = ""
        Try
            KiemTraNgayXuatHang = True
            p_GetDateTime(p_Date, p_Time)
            p_Date = p_Date.Date
            p_NgayXuat = p_Date

            If Not Me.Status.EditValue Is Nothing Then
                If Me.Status.EditValue.ToString.Trim <> "" Then
                    p_Status = Me.Status.EditValue.ToString.Trim
                End If
            End If
            If p_Status = "1" Or p_Status = "2" Or p_Status = "" Then

                If Not Me.NgayXuat.EditValue Is Nothing Then
                    p_NgayXuat = Me.NgayXuat.EditValue
                    p_NgayXuat = p_NgayXuat.Date
                End If

                If p_NgayXuat > p_Date Then
                    ShowMessageBox("", "Ngày xuất hàng không hợp lệ")
                    KiemTraNgayXuatHang = False
                    Exit Function
                End If
                p_NgayXuat = p_Date
                If Not Me.NgayHetHieuLuc.EditValue Is Nothing Then
                    If Me.NgayHetHieuLuc.EditValue.ToString.Trim <> "" Then
                        p_NgayXuat = Me.NgayHetHieuLuc.EditValue
                        p_NgayXuat = p_NgayXuat.Date
                    End If

                End If
                If p_NgayXuat < p_Date Then
                    ShowMessageBox("", "Lệnh xuất đã hết hiệu lực")
                    KiemTraNgayXuatHang = False
                    Exit Function
                End If

            End If
            p_SQL = "select 1 as STT  from tblLenhXuatE5 where CONVERT(date, ngayxuat)<CONVERT(date,'" & CDate(p_Date).ToString(g_Format_Date) & "') and CHARINDEX(',' + SoLenh  + ',','," & p_SoLenh & ",',1) >0"

            p_Data = GetDataTable(p_SQL, p_SQL)
            If Not p_Data Is Nothing Then
                If p_Data.Rows.Count = 1 Then
                    p_ValueMess = g_Module.ShowMessage(Me, "", _
                        "Ngày tháng của lệnh xuất khác ngày hệ thống. Bạn có chắc chắn muốn thực hiện không? ", _
                        True, _
                         "Có", _
                        True, _
                        "Không", _
                        False, _
                        "", _
                         0)
                    If p_ValueMess = Windows.Forms.DialogResult.Yes Then
                        KiemTraNgayXuatHang = True
                        Exit Function
                    Else
                        KiemTraNgayXuatHang = False
                        Exit Function
                    End If
                ElseIf p_Data.Rows.Count > 1 Then
                    p_ValueMess = g_Module.ShowMessage(Me, "", _
                        "Lệnh xuất ghép có số lệnh ngày tháng khác ngày hệ thống. Bạn có chắc chắn muốn thực hiện không? ", _
                        True, _
                         "Có", _
                        True, _
                        "Không", _
                        False, _
                        "", _
                         0)
                    If p_ValueMess = Windows.Forms.DialogResult.Yes Then
                        KiemTraNgayXuatHang = True
                        Exit Function
                    Else
                        KiemTraNgayXuatHang = False
                        Exit Function
                    End If
                End If
            End If
        Catch ex As Exception
            p_Desc = ex.Message
            KiemTraNgayXuatHang = False
        End Try
    End Function

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click

        Dim p_SoLenh As String = ""
        Dim g_LoaiHinhVanChuyen As String = ""
        Dim p_Message As String
        Dim p_Status As String = ""
        Dim p_ValueCheck As Boolean = False
        Dim p_DataSet As DataSet
        Dim p_SQL As String
        Dim p_Terminal As String
        Dim p_Type As String = ""
        Dim p_Count As Integer
        Dim p_Sum As Double = 0
        Dim p_DataRow As DataRow
        Dim p_RowArr() As DataRow
        Dim p_MaVanChuyen As String
        Dim p_StrSoLenh = ""

        Dim p_TableCheck As DataTable

        Dim p_MaPhuongTien As String = ""

        Dim p_NguoiVanChuyen As String = ""


        Dim p_Desc As String

        Dim p_Number As Double

        Dim p_PhuongTien As String = ""
        Dim p_LoaiXuat As String = ""
        Dim p_VanChuyen As String = ""

        'Dim p_Number As Integer = 0

        p_Terminal = ""

        If Not Me.Client.EditValue Is Nothing Then
            If Me.Client.EditValue.ToString.Trim <> "" Then
                p_Terminal = Me.Client.EditValue.ToString.Trim
            End If
        End If
        If p_Terminal = "" Then

            'p_Terminal = g_Terminal
            'Me.Client.EditValue = g_Terminal
            ShowMessageBox("", "Giá trị kho xuất chưa được chọn", 3)
            Exit Sub
        End If

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If
        If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
            p_StrSoLenh = Me.NguoiVanChuyen.EditValue.ToString.Trim
            p_NguoiVanChuyen = Me.NguoiVanChuyen.EditValue.ToString.Trim
        End If

        If Not Me.MaPhuongTien.EditValue Is Nothing Then
            p_MaPhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim

        End If
        If p_MaPhuongTien = "" Then
            ShowMessageBox("", "Thông tin Mã vận chuyển chưa nhập", 3)
            Exit Sub
        End If



        If p_StrSoLenh = "" And Me.NguoiVanChuyen.Required.ToString.Trim = "Y" Then
            ShowMessageBox("", "Thông tin người vận chuyển chưa nhập", 3)
            Exit Sub
        End If
        p_StrSoLenh = ""
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If Not Me.U_CheckBox1.EditValue Is Nothing Then
            If Me.U_CheckBox1.Checked = True Then
                p_ValueCheck = True
            End If
        End If
        If p_NguoiVanChuyen = "" Then
            If getNguoiVanChuyen(p_MaPhuongTien, p_NguoiVanChuyen, p_Desc, Me) = False Then

                Exit Sub
            End If
        End If

        If KiemTraLineID_TableID() = False Then
            Exit Sub
        End If

        'If g_KV1 = True Then
        '    If p_NguoiVanChuyen = "" Then
        '        If getNguoiVanChuyen(p_MaPhuongTien, p_NguoiVanChuyen, p_Desc, Me) = False Then

        '            Exit Sub
        '        End If
        '    End If

        'Else
        '    If getNguoiVanChuyen(p_MaPhuongTien, p_NguoiVanChuyen, p_Desc, Me) = False Then

        '        Exit Sub
        '    End If

        'End If
        If getNguoiVanChuyen(p_MaPhuongTien, p_NguoiVanChuyen, p_Desc, Me) = False Then
            ' ShowMessageBox("", p_Desc)
            'Me.MaPhuongTien.EditValue = ""
            '  e.Cancel = True
            Exit Sub
        End If


        If KiemTraThongTin(p_SoLenh, True) = True Then
            Exit Sub
        End If

        If GridView2.RowCount <= 0 Then
            ShowMessageBox("", "Lệnh xuất chưa được đặt ngăn", 3)
            '    Exit Sub
            Exit Sub
        End If

        For p_Count = 0 To Me.GridView2.RowCount - 1
            p_DataRow = GridView2.GetDataRow(p_Count)
            If Not p_DataRow Is Nothing Then
                Double.TryParse(p_DataRow.Item("SoLuongDuXuat").ToString.Trim, p_Number)
                p_Sum = p_Sum + p_Number
            End If
        Next
        If p_Sum <= 0 Then
            ShowMessageBox("", "Lệnh xuất chưa được đặt ngăn", 3)
            '    Exit Sub
            Exit Sub
        End If
        p_StrSoLenh = ""
        p_SoLenh = ""
        Me.GridView3.ClearGrouping()
        For p_Count = 0 To Me.GridView3.RowCount - 1
            '  If GridView3.IsGroupRow(p_Count) = False Then
            p_DataRow = Me.GridView3.GetDataRow(p_Count)
            If p_DataRow.Item("Status").ToString.Trim = "1" Or p_DataRow.Item("Status").ToString.Trim = "2" Or p_DataRow.Item("Status").ToString.Trim = "" Then
                If p_SoLenh <> p_DataRow.Item("SoLenh").ToString.Trim Then
                    p_SoLenh = p_DataRow.Item("SoLenh").ToString.Trim
                    p_StrSoLenh = p_StrSoLenh & "," & p_SoLenh

                End If
            End If
            ' End If

        Next
        Me.GridView3.Columns(0).Group()
        Me.GridView3.ExpandAllGroups()
        If p_CURRENTDATE = True Then
            If KiemTraNgayXuatHang(p_SoLenh, p_Desc) = False Then
                If p_Desc <> "" Then
                    ShowMessageBox("", p_Desc)
                    'Exit Sub
                End If
                Exit Sub
            End If
        End If

        If p_Status = "3" Or p_Status = "31" Or p_Status = "4" Or p_Status = "5" Then
            'ShowMessageBox("", "Trạng thái Lệnh xuất không hợp lệ")
            Me.GridView3.ClearGrouping()
            For p_Count = 0 To Me.GridView3.RowCount - 1
                '  If GridView3.IsGroupRow(p_Count) = False Then
                p_DataRow = Me.GridView3.GetDataRow(p_Count)
                If p_DataRow.Item("Status").ToString.Trim = "1" Or p_DataRow.Item("Status").ToString.Trim = "2" Or p_DataRow.Item("Status").ToString.Trim = "" Then
                    If p_SoLenh <> p_DataRow.Item("SoLenh").ToString.Trim Then
                        p_SoLenh = p_DataRow.Item("SoLenh").ToString.Trim
                        p_StrSoLenh = p_StrSoLenh & "," & p_SoLenh

                    End If
                End If
                ' End If

            Next
            Me.GridView3.Columns(0).Group()
            Me.GridView3.ExpandAllGroups()

            ' MsgBox("aaaaa")
            If p_LenhGhep = False Then
                If p_SoLenh = "" Then
                    If Not Me.SoLenh.EditValue Is Nothing Then
                        p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
                    End If
                End If
                ' MsgBox("bbbbb")

                _Report_Object.clsInTichKe(p_ValueCheck, p_SoLenh, p_MATUDONGHOA)
            Else
                _Report_Object.clsInTichKe(p_ValueCheck, p_StrSoLenh, p_MATUDONGHOA)
            End If
            Exit Sub
        End If

        If g_KV1 = True Then
            If Me.FormStatus = False Then
                Me.FormStatus = True
            End If
            'Me.DefaultSave = True
            'Me.UpdateToDatabase(Me, "")
            'Me.DefaultSave = False
            ToolStripButton6_Click(sender, e)
            If Me.FormStatus = True Then
                If KiemTraThongTin(p_SoLenh) = True Then
                    Exit Sub
                End If

                If KiemTraKhiLuuLenh(p_SoLenh) = False Then
                    Exit Sub
                End If

                'Exit Sub
                Me.DefaultSave = True
                Me.UpdateToDatabase(Me, "")
                Me.DefaultSave = False
            End If
            'End If
        Else

            If Me.FormStatus = True Then
                'SaveRecode()
                ShowMessageBox("", "Thông tin lệnh xuất chưa được lưu", 1)
                Exit Sub
            End If
        End If


        'If Me.FormStatus = True Then
        '    ShowStatusMessage(False, "", "Thông tin lệnh xuất chưa được lưu", 4)
        '    Exit Sub
        'End If

        p_SQL = "select COUNT(*) as MaVanChuyen from  (" & _
                   " select MaVanChuyen, COUNT(MaVanChuyen) as MaVanChuyen1 from tblLenhXuatE5  " & _
                  "  where CHARINDEX (',' + SoLenh + ',','," & p_StrSoLenh & ",',1)>0 " & _
                 "    group by MaVanChuyen) abc "
        p_TableCheck = GetDataTable(p_SQL, p_SQL)


        If Not p_TableCheck Is Nothing Then
            If p_TableCheck.Rows(0).Item(0) > 1 Then
                ShowMessageBox("", "Lệnh ghép khác Loại hình phương tiện")
                Exit Sub
            End If
        End If

        If Not Me.LoaiXuat.EditValue Is Nothing Then
            g_LoaiHinhVanChuyen = Me.LoaiXuat.EditValue.ToString.Trim
        End If

        'Tao So Tich Ke
        If p_LenhGhep = False Then
            If TaoSoTichKe(p_SoLenh) = True Then
                Exit Sub
            End If
        Else
            If TaoSoTichKeLenhGhep(Me.GridView3) = True Then
                Exit Sub
            End If
        End If

        'p_SQL = "select * from SYS_CONFIG where KeyCode='WEBSERVER64';select * from tblconfig;"
        'p_DataSet = GetDataSet(p_SQL, p_SQL)
        'p_SQL = "Y"
        'If Not p_DataSet Is Nothing Then
        '    If p_DataSet.Tables.Count > 0 Then
        '        If p_DataSet.Tables(0).Rows.Count > 0 Then
        '            p_SQL = p_DataSet.Tables(0).Rows(0).Item("KeyValue").ToString.Trim
        '        End If
        '        If p_DataSet.Tables(1).Rows.Count > 0 Then
        '            p_Type = p_DataSet.Tables(1).Rows(0).Item("optional").ToString.Trim
        '        End If
        '    End If
        'End If


        If p_StrSoLenh <> "" Then
            'If p_SQL = "N" Or UCase(p_Type) = "FOX" Then
            '    p_Message = HTTG_To_Scadar("out", p_StrSoLenh, g_LoaiHinhVanChuyen, p_Terminal, True)
            'Else
            '    p_Message = g_Services.SYS_HTTG_To_Scadar("out", p_StrSoLenh, g_LoaiHinhVanChuyen, p_Terminal, True)
            'End If

            p_SQL = "exec FPT_CheckLenhInTichKe '" & p_StrSoLenh & "'"
            p_TableCheck = GetDataTable(p_SQL, p_SQL)
            If Not p_TableCheck Is Nothing Then
                If p_TableCheck.Rows.Count > 0 Then
                    p_RowArr = p_TableCheck.Select("Err=1")
                    If p_RowArr.Length > 0 Then
                        ShowMessageBox("", p_RowArr(0).Item("sDesc"), 3)
                        Exit Sub
                    Else
                        For p_Count = 0 To p_RowArr.Length - 1
                            ShowMessageBox("", p_RowArr(p_Count).Item("sDesc"), 2)
                        Next
                    End If
                End If
            End If
            p_Number = 0
            If Not Me.aNumber.EditValue Is Nothing Then
                Double.TryParse(Me.aNumber.EditValue.ToString.Trim, p_Number)
            End If

            If p_NguoiVanChuyen = "" Then
                If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
                    p_NguoiVanChuyen = Me.NguoiVanChuyen.EditValue.ToString.Trim
                End If
            End If

            If p_LenhGhep = True Then
                If g_KV1 = True Then
                    p_SQL = "update  tblLenhXuatE5  set  number=" & p_Number & ", MaPhuongTien='" & p_MaPhuongTien & "', NguoiVanChuyen=N'" & _
                           p_NguoiVanChuyen & "' " & _
                       " where  ( CHARINDEX (',' + solenh +',','" & p_StrSoLenh & ",',1)>0  or SoLenh='" & p_SoLenh & "' ) and Status not in ('4','5')  "
                    If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                    End If
                Else

                    p_SQL = "update  tblLenhXuatE5  set  number=" & p_Number & ", Client='" & g_Terminal & "', MaPhuongTien='" & p_MaPhuongTien & "', NguoiVanChuyen=N'" & _
                           p_NguoiVanChuyen & "' " & _
                       " where ( CHARINDEX (',' + solenh +',','" & p_StrSoLenh & ",',1)>0  or SoLenh='" & p_SoLenh & "' ) and Status not in ('4','5')  "
                    If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                    End If
                End If

            Else
                p_SQL = "update  tblLenhXuatE5  set  number=" & p_Number & ", MaPhuongTien='" & p_MaPhuongTien & "', NguoiVanChuyen=N'" & _
                           p_NguoiVanChuyen & "' " & _
                       " where solenh ='" & p_SoLenh & "'  "
                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                End If
            End If

            p_MaVanChuyen = ""
            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
            End If

            GetMaVanChuyen(p_MaPhuongTien, p_MaVanChuyen, p_VanChuyen)

            For p_Count = 0 To Me.GridView2.RowCount - 1
                p_DataRow = Me.GridView2.GetDataRow(p_Count)
                If p_DataRow Is Nothing Then
                    Continue For
                End If
                If p_DataRow.Item("Row_id").ToString.Trim <> "" Then
                    p_SQL = "update  tblLenhXuatChiTietE5  set PhuongTien= '" & p_VanChuyen & "' where  Row_id=" & p_DataRow.Item("Row_id").ToString.Trim & _
                            " and  isnull(PhuongTien,'')='' "
                    If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                    End If
                End If
            Next

            If g_WCF = True Then
                p_Message = g_Services.SYS_HTTG_To_Scadar(g_UserName, "out", p_StrSoLenh, g_LoaiHinhVanChuyen, p_Terminal, True)
            Else
                Dim p_SAP_Obj As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
                p_Message = p_SAP_Obj.clsHTTG_To_Scadar("out", p_StrSoLenh, g_LoaiHinhVanChuyen, p_Terminal, True)
            End If

            If p_Message.ToString.Trim <> "" Then
                ShowMessageBox("", p_Message, 3)
                Exit Sub
            End If
            'If p_InLaiTichKe = False Then
            Me.ToolStripButton4.Enabled = p_InLaiTichKe

            'End If

            ShowStatusMessage(False, "MS003", "Lệnh xuất đã đẩy sang Scadar", 10)
            'In tich ke
            _Report_Object.clsInTichKe(p_ValueCheck, p_StrSoLenh, p_MATUDONGHOA)
            If p_LenhGhep = True Then
                GetHangHoaGhep(p_StrSoLenh)

                Me.Status.EditValue = "3"
                Me.DefaultFormLoad = False
                XtraForm1_Load()
                Me.DefaultFormLoad = False
            Else
                Me.DefaultFormLoad = True
                XtraForm1_Load()
                Me.DefaultFormLoad = False
            End If
            p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
            Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)
            If Not Me.Status.EditValue Is Nothing Then
                If InStr(",3,31,4,5,", "," & Me.Status.EditValue.ToString.Trim & ",", CompareMethod.Text) > 0 Then
                    Me.FormEdit = False
                    Me.GridView2.OptionsBehavior.ReadOnly = True
                    Me.GridView1.OptionsBehavior.ReadOnly = True
                    Me.MaVanChuyen.Properties.ReadOnly = True

                    'Me.NguoiVanChuyen.Properties.ReadOnly = True
                    If g_KV1 = True Then
                        Me.NguoiVanChuyen.Properties.ReadOnly = False
                    Else
                        Me.NguoiVanChuyen.Properties.ReadOnly = True
                    End If

                    GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                Else
                    Me.FormEdit = True
                    Me.GridView2.OptionsBehavior.ReadOnly = False
                    Me.GridView1.OptionsBehavior.ReadOnly = False
                    Me.MaVanChuyen.Properties.ReadOnly = False
                    Me.NguoiVanChuyen.Properties.ReadOnly = False
                    Me.GridView2.AllowInsert = True
                    If Me.Client.EditValue Is Nothing Then
                        Me.Client.EditValue = GetClient(p_MaVanChuyen)  ' g_Terminal
                    Else
                        If Me.Client.EditValue.ToString.Trim = "" Then
                            Me.FormStatus = False
                            Me.Client.EditValue = g_Terminal
                            GoTo Line_tt
                            '  Me.FormStatus = True
                        End If
                    End If
                    ' LenhGhep(p_Value)
                    GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
                End If
            End If
            Me.FormStatus = False
Line_tt:
        End If

        '  End If
    End Sub


    Private Sub p_CapNhatLoaiHinhXuat(ByVal p_SoLenh As String)
        Dim p_SQL As String
        Dim p_ArrSoLenh() As String
        Dim p_Count As Integer
        Dim p_DataTable As DataTable
        Dim p_Row As DataRow

    End Sub

    Function KiemTraLineID_TableID() As Boolean
        Dim p_BindHoangHoa As U_TextBox.U_BindingSource
        Dim p_BindChiTiet As U_TextBox.U_BindingSource
        Dim p_TblHangHoa As DataTable
        Dim p_TblChiTiet As DataTable
        Dim P_Count As Integer
        Dim p_Row As DataRow
        Dim p_Count2 As Integer
        Dim p_RowChiTiet As DataRow
        Dim p_Arr() As DataRow

        Try
            KiemTraLineID_TableID = True
            p_BindHoangHoa = Me.TrueDBGrid1.DataSource
            p_TblHangHoa = CType(p_BindHoangHoa.DataSource, DataTable)

            p_BindChiTiet = Me.TrueDBGrid2.DataSource
            p_TblChiTiet = CType(p_BindChiTiet.DataSource, DataTable)
            For P_Count = 0 To p_TblHangHoa.Rows.Count - 1
                p_Row = p_TblHangHoa.Rows(P_Count)
                If Not p_Row Is Nothing Then
                    For p_Count2 = 0 To p_TblChiTiet.Rows.Count - 1
                        p_RowChiTiet = p_TblChiTiet.Rows(p_Count2)
                        If Not p_RowChiTiet Is Nothing Then
                            If p_RowChiTiet.Item("TableID").ToString.Trim = p_Row.Item("TableID").ToString.Trim Then
                                If p_RowChiTiet.Item("LineID").ToString.Trim <> p_Row.Item("LineID").ToString.Trim Then
                                    ShowMessageBox("", "Mã lệnh " & p_Row.Item("TableID").ToString.Trim & " và Mã LineID không đồng nhất. Bạn hãy đặt lại ngăn hàng hóa")
                                    KiemTraLineID_TableID = False
                                    Exit Function
                                End If
                            End If
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            ShowMessageBox("", ex.Message)
            KiemTraLineID_TableID = False
        End Try

    End Function

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        If Me.FormStatus = True Then

            Me.SoTichKe.Focus()
            Me.GridView2.RefreshData()
            '  GridView2.SetFocusedRowModified()
            'GridView2.UpdateCurrentRow()
            'GridView2.RefreshEditor(True)
            Me.Focus()

            SaveRecode()
        End If
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Dim p_Count As Integer
        Dim p_CountEnd As Integer = 0
        Dim p_SQL As String
        Dim p_DataRow As DataRow
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_DataTable As DataTable
        Dim p_SoLenh As String = ""
        Dim p_Status As String = ""
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If
        If p_Status <> "1" And p_Status <> "2" Then
            ShowMessageBox("", "Lệnh xuất đã được đẩy vào hệ thống bơm xuất", 1)
            Exit Sub
        End If


        p_Binding = Me.GridView2.DataSource
        p_DataTable = CType(p_Binding.DataSource, DataTable)
        p_Count = Me.GridView2.RowCount - 1
        For p_Count = 0 To p_DataTable.Rows.Count - 1
            Try
                ' p_Count = p_Count + 1
                ' If GridView2.IsDataRow(Me.GridView2.RowCount - 1) Then
                p_DataRow = p_DataTable.Rows(p_Count)
                If p_DataRow.Item("Row_id").ToString.Trim <> "" Then
                    p_SQL = p_DataRow.Item("Row_id").ToString.Trim
                    p_SQL = "Delete from tblLenhXuatChiTietE5 where  Row_id=" & p_SQL
                    p_DataRow = Me.pv_LineRemove.NewRow
                    p_DataRow.Item(0) = p_SQL
                    Me.pv_LineRemove.Rows.Add(p_DataRow)
                End If
                'End If

                '  GridView2.DeleteRow(p_Count)
            Catch ex As Exception

            End Try
            '  p_Count = p_Count - 1
            ' p_CountEnd = p_CountEnd + 1
        Next
        p_DataTable.Clear()
        p_DataRow = p_DataTable.NewRow
        p_DataTable.Rows.Add(p_DataRow)
        p_Binding.DataSource = p_DataTable
        p_Binding.ResumeBinding()
        Me.TrueDBGrid2.DataSource = p_Binding
        TrueDBGrid2.RefreshDataSource()
        If Me.FormStatus = False Then
            Me.FormStatus = True
        End If
    End Sub

    Private Sub Client_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Client.EditValueChanged

    End Sub

    Private Sub TrueDBGrid2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid2.Click

    End Sub

    Private Sub U_ButtonCus1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_SQL As String
        Dim p_SoLenh As String = ""
        Dim p_DataTable As DataTable
        Dim p_DataTableStatus As DataTable
        Dim p_DataTableHuyTK As DataTable
        Dim p_DataTableTK As DataTable
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_Desc As String = "Bạn có chắn chắn muốn thực hiện hủy tích kê?"
        Dim p_String As String = ""
        Dim p_DataSet As DataSet
        Dim p_Count As Integer

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If p_SoLenh = "" Then
            Exit Sub

        End If



        p_SQL = "FPT_KiemTra_HuyTichKe '" & p_SoLenh & "','" & g_UserName & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_DataTable = p_DataSet.Tables(0)
                p_DataTableTK = p_DataSet.Tables(1)
                p_DataTableStatus = p_DataSet.Tables(2)
                p_DataTableHuyTK = p_DataSet.Tables(3)
            End If
        End If
        'p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                ShowMessageBox("", p_DataTable.Rows(0).Item("StrName").ToString.Trim)
                Exit Sub
            End If
        End If
        If Not p_DataTableStatus Is Nothing Then
            If p_DataTableStatus.Rows.Count > 0 Then
                ShowMessageBox("", "Tích kê đã có lệnh xuất được hoàn thiện", 3)
                Exit Sub
            End If
        End If
        p_SQL = g_Terminal
        If g_Filter_Terminal = True Then
            If Not Me.Client.EditValue Is Nothing Then
                p_SQL = Me.Client.EditValue.ToString.Trim
            End If
            If p_SQL <> g_Terminal Then
                ShowMessageBox("", "Không hủy được tích kê của kho khác", 3)
                Exit Sub
            End If
        End If

        If g_KV1 = False Then
            If p_DataTableHuyTK.Rows.Count > 0 Then
                p_ValueMess = g_Module.ShowMessage(Me, "", _
                          "Tích kê đã được tạo bởi User " & p_DataTableHuyTK.Rows(0).Item("UserTichKe").ToString.Trim & vbCrLf & vbNewLine & "  Bạn có chắc chắn muốn hủy tích kê không? ", _
                          True, _
                           "Có", _
                          True, _
                          "Không", _
                          False, _
                          "", _
                           0)
                If p_ValueMess = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If

        End If


        If Not p_DataTableTK Is Nothing Then
            If p_DataTableTK.Rows.Count > 1 Then  'Huy lenh gep
                For p_Count = 0 To p_DataTableTK.Rows.Count - 1
                    p_String = p_String & "," & p_DataTableTK.Rows(p_Count).Item(0).ToString.Trim
                Next
                If p_String <> "" Then
                    p_String = Mid(p_String, 2)
                End If
                p_ValueMess = g_Module.ShowMessage(Me, "", _
                        "Lệnh ghép (" & p_String & ") - Bạn có chắc chắn muốn hủy tích kê không? ", _
                        True, _
                         "Có", _
                        True, _
                        "Không", _
                        False, _
                        "", _
                         0)
                If p_ValueMess = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
                For p_Count = 0 To p_DataTableTK.Rows.Count - 1
                    p_SoLenh = p_DataTableTK.Rows(p_Count).Item(0).ToString.Trim
                    HuyTichKe(p_SoLenh)
                Next
            Else   'Huy lenh co 1 lenh xuat
                p_ValueMess = g_Module.ShowMessage(Me, "", _
                        "Bạn có chắn chắn muốn thực hiện hủy tích kê?", _
                        True, _
                         "Có", _
                        True, _
                        "Không", _
                        False, _
                        "", _
                         0)
                If p_ValueMess = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
                HuyTichKe(p_SoLenh)

                p_DanhSachPTGhep = ""
                p_PTien1 = ""
                p_NVC1 = ""

            End If
        End If


        'FPT_KiemTra_HuyTichKe'
    End Sub


    Private Sub HuyTichKe(ByVal p_SoLenh As String)
        Dim p_Message, p_SQL, p_Type, p_Terminal, p_LoaiHinhVanChuyen As String
        Dim p_DataSet As DataSet
        Dim e As System.EventArgs
        p_Terminal = g_Terminal
        If Not Me.Client.EditValue Is Nothing Then
            If Me.Client.EditValue.ToString.Trim <> "" Then
                p_Terminal = Me.Client.EditValue.ToString.Trim
            End If
        End If

        If Not Me.LoaiXuat.EditValue Is Nothing Then
            p_LoaiHinhVanChuyen = Me.LoaiXuat.EditValue.ToString.Trim
        End If

        p_SQL = "select * from SYS_CONFIG where KeyCode='WEBSERVER64';select * from tblconfig;"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        p_SQL = "Y"
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                If p_DataSet.Tables(0).Rows.Count > 0 Then
                    p_SQL = p_DataSet.Tables(0).Rows(0).Item("KeyValue").ToString.Trim
                End If
                If p_DataSet.Tables(1).Rows.Count > 0 Then
                    p_Type = p_DataSet.Tables(1).Rows(0).Item("optional").ToString.Trim
                End If
            End If
        End If
        p_Message = Scadar_HuyTichKe(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        'If p_SQL = "N" Or UCase(p_Type) = "FOX" Then
        '    p_Message = Scadar_HuyTichKe(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        'Else
        '    p_Message = g_Services.Scadar_HuyTichKe(g_WareHouse, "in", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        'End If
        If p_Message.ToString.Trim <> "" Then
            ShowMessageBox("", p_Message)
            Exit Sub
        Else
            'anhqh
            '20160705

            'Me.DefaultWhere = "SoLenh='" & p_SoLenh & "'"
            'Me.DefaultFormLoad = True
            'Me.Form1_Load(Nothing, e)
            '' Me.FormStatus = True

            '' Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)
            'If Not Me.Status.EditValue Is Nothing Then
            '    If InStr(",3,31,4,5,", "," & Me.Status.EditValue.ToString.Trim & ",", CompareMethod.Text) > 0 Then
            '        Me.FormEdit = False
            '        Me.GridView2.OptionsBehavior.ReadOnly = True
            '        Me.GridView1.OptionsBehavior.ReadOnly = True
            '        Me.MaVanChuyen.Properties.ReadOnly = True
            '        Me.NguoiVanChuyen.Properties.ReadOnly = True
            '        GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            '    Else
            '        Me.FormEdit = True
            '        Me.GridView2.OptionsBehavior.ReadOnly = False
            '        Me.GridView1.OptionsBehavior.ReadOnly = False
            '        Me.MaVanChuyen.Properties.ReadOnly = False
            '        Me.NguoiVanChuyen.Properties.ReadOnly = False
            '        Me.GridView2.AllowInsert = True
            '        ' LenhGhep(p_Value)
            '        GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            '    End If
            'End If
            Me.FormStatus = False
            Call ToolStripButton2_Click(Nothing, Nothing)
            ShowStatusMessage(False, "", "Tích kê đã được hủy", 8)
            Me.ToolStripButton4.Enabled = True
            ' GopTichKe(False, True)
            Cursor = Cursors.Default
        End If


    End Sub

    Private Sub MaPhuongTien_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaPhuongTien.EditValueChanged

    End Sub

    Private Sub MaPhuongTien_EditValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles MaPhuongTien.EditValueChanging

    End Sub

    Private Sub MaPhuongTien_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaPhuongTien.KeyDown
        If e.KeyCode = Keys.Enter Then
            Setfocus("MAPHUONGTIEN")
        End If
    End Sub


    Private Sub MaPhuongTien_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaPhuongTien.TextChanged

    End Sub

    Private Sub MaPhuongTien_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MaPhuongTien.Validated
        'Dim p_Value As String
        'Dim p_Sender As New U_TextBox.U_ButtonEdit
        'p_Sender = CType(sender, U_TextBox.U_ButtonEdit)
        'If p_Sender.OldEditValue Is Nothing Then
        '    p_Value = p_Sender.EditValue.ToString.Trim
        '    LoadDefault(p_Value)
        '    Exit Sub
        'End If
        ''  p_Sender = CType(sender, U_TextBox.U_ButtonEdit)
        'p_Value = p_Sender.EditValue
        'If p_Sender.OldEditValue <> p_Value Then
        '    LoadDefault(p_Value)
        'End If

        Exit Sub

        Dim p_Status As String = ""
        Dim p_abc As U_TextBox.U_ButtonEdit
        Dim p_SQL As String = ""
        Dim p_OldValue As String = ""
        Dim p_NewValue As String = ""
        Dim p_DataTable As DataTable
        Dim p_MaVanChuyen As String = ""
        Dim p_SoLenh As String = ""
        Dim p_MaPhuongTien As String = ""
        'Dim p_SQL As String = ""
        If Me.g_FormLoad = True Then
            Exit Sub
        End If


        '  Exit Sub
        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
            p_abc = CType(sender, U_TextBox.U_ButtonEdit)

            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            p_MaVanChuyen = GetLoadingSite(p_MaVanChuyen)
            If UCase(p_MaVanChuyen) = "THUY" Then
                Exit Sub
            End If

            If Not Me.SoLenh.EditValue Is Nothing Then
                p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
            End If

            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_MaPhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
            End If

            If p_Status = "31" Or p_Status = "3" Then                ' Else
                If sender.OldEditValue Is Nothing Then
                    Exit Sub
                End If

                If sender.EditValue Is Nothing Then
                    Exit Sub
                End If



                p_SQL = "select 1 as STT from ( " & _
                   "select SoLuongDuXuat, COUNT(MaNgan) as SLNgan  from FPT_tblLenhXuatChiTietE5_V where SoLenh='" & p_SoLenh & "' " & _
                       " group by SoLuongDuXuat ) abc " & _
                       " where not exists ( " & _
                       " select 1 from  (" & _
                       "select SoLuongMax , COUNT(MaNgan) as SLNgan from tblChiTietPhuongTien with (nolock) where MaPhuongTien ='" & p_MaPhuongTien & "' Group by SoLuongMax) def " & _
                    "where abc.SoLuongDuXuat =def.SoLuongMax  and abc.SLNgan <=def.SLNgan )"
                p_DataTable = GetDataTable(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        ShowMessageBox("", "Phương tiện có dung tích ngăn không đồng nhất")
                        sender.ValidateValue = False
                    End If
                End If
                'If sender.EditValue.ToString.Trim <> sender.OldEditValue.ToString.Trim Then
                '    '    sender.EditValue.ToString.Trim = p_abc.OldEditValue.ToString.Trim
                '    p_OldValue = p_abc.OldEditValue.ToString.Trim
                '    p_NewValue = p_abc.EditValue.ToString.Trim
                '    sender.ValidateValue = False
                'End If

            Else
                'sender.ValidateValue = False

            End If
            ' p_abc = CType(sender, U_TextBox.U_ButtonEdit)
        End If

    End Sub

    'Private Sub MaPhuongTien_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MaPhuongTien.Validating
    '    Dim p_Value As String
    '    Dim p_Sender As New U_TextBox.U_ButtonEdit
    '    p_Sender = CType(sender, U_TextBox.U_ButtonEdit)

    '    If p_Sender.OldEditValue Is Nothing Then
    '        p_Value = p_Sender.EditValue.ToString.Trim
    '        LoadDefault(p_Value)
    '        Exit Sub
    '    End If

    '    p_Value = p_Sender.EditValue
    '    If p_Sender.OldEditValue.ToString.Trim <> p_Value Then
    '        LoadDefault(p_Value)
    '    End If
    'End Sub

    Private Sub NguoiVanChuyen_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NguoiVanChuyen.EditValueChanged

    End Sub


    'Private Sub NguoiVanChuyen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NguoiVanChuyen.KeyDown
    '    Dim p_Value As String
    '    If e.KeyCode = Keys.Enter Then
    '        If Not Me.MaPhuongTien.EditValue Is Nothing Then
    '            p_Value = Me.MaPhuongTien.EditValue.ToString.Trim
    '            If p_Value <> "" Then
    '                LoadDefault(p_Value)
    '                'Me.TrueDBGrid2.Focus()
    '                Me.GridView2.Focus()
    '                ' If p_LenhGhep = True Then
    '                ' GopTichKe()
    '                'End If
    '            End If

    '        End If

    '    End If
    'End Sub

    Private Sub NguoiVanChuyen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NguoiVanChuyen.KeyPress
        Dim p_Value As String
        Dim p_Status As String = ""
        If Asc(e.KeyChar) = 13 Then
            If Not Me.Status.EditValue Is Nothing Then
                p_Status = Me.Status.EditValue.ToString.Trim

            End If
            If p_Status = "3" Or p_Status = "31" Or p_Status = "4" Or p_Status = "5" Then
                Exit Sub
            End If
            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_Value = Me.MaPhuongTien.EditValue.ToString.Trim
                If p_Value <> "" Then

                    LoadDefault(p_Value)
                    'Me.TrueDBGrid2.Focus()
                    Me.GridView2.Focus()
                    ' If p_LenhGhep = True Then
                    ' GopTichKe()
                    'End If
                End If

            End If

        End If
    End Sub

    Private Sub MaVanChuyen_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaVanChuyen.EditValueChanged

    End Sub

    Private Sub MaVanChuyen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MaVanChuyen.KeyDown
        If e.KeyCode = Keys.Enter Then
            Setfocus("MAVANCHUYEN")
        End If
    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_Status As String = ""
        Dim p_Row As DataRow
        Dim p_Count As Integer
        Dim p_SoLenh As String = ""
        Dim p_SQL As String
        Dim p_DataTable As New DataTable("Table01")
        If Me.FormStatus = True Then
            ShowMessageBox("", "Đề nghị lưu lại trước khi thực hiện")
            Exit Sub
        End If

        p_DanhSachPTGhep = ""
        p_PTien1 = ""
        p_NVC1 = ""


        p_SQL = g_Terminal
        If g_Filter_Terminal = True Then
            If Not Me.Client.EditValue Is Nothing Then
                p_SQL = Me.Client.EditValue.ToString.Trim
            End If
            If p_SQL <> g_Terminal Then
                ShowMessageBox("", "Không hủy được lệnh xuất của kho khác")
                Exit Sub
            End If
        End If


        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If


        If p_Status = "3" Or p_Status = "31" Or p_Status = "4" Or p_Status = "5" Then
            ShowMessageBox("", "Trạng thái lệnh xuất không hợp lệ để hủy")
            Exit Sub
        End If
        p_ValueMess = g_Module.ShowMessage(Me, "", _
                        "Bạn có chắc chắn muốn hủy lệnh xuất không? ", _
                        True, _
                         "Có", _
                        True, _
                        "Không", _
                        False, _
                        "", _
                         0)
        If p_ValueMess = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        p_DataTable.Columns.Add("STRSQL")
        p_Row = p_DataTable.NewRow
        'anhqh 20160623
        p_Row.Item(0) = "delete from tblLenhXuatChiTietE5  where exists (select 1 from tblLenhXuat_HangHoaE5 u " & _
                " where u.TableID =tblLenhXuatChiTietE5.TableID and  u.NgayXuat =tblLenhXuatChiTietE5.NgayXuat     and u.SoLenh='" & p_SoLenh & "')"
        p_DataTable.Rows.Add(p_Row)


        p_Row = p_DataTable.NewRow
        p_Row.Item(0) = "delete from tblLenhXuat_HangHoaE5  " & _
                " where  SoLenh='" & p_SoLenh & "'"
        p_DataTable.Rows.Add(p_Row)

        p_Row = p_DataTable.NewRow
        p_Row.Item(0) = "delete from tblLenhXuatE5  " & _
                " where  SoLenh='" & p_SoLenh & "'"
        p_DataTable.Rows.Add(p_Row)

        p_Status = ""
        If g_Services.Sys_Execute_DataTbl(p_DataTable, p_Status) = False Then
            ShowMessageBox("", "Lỗi khi hủy lệnh xuất: " & p_Status)
            Exit Sub
        End If

        ShowMessageBox("", "Hủy lệnh xuất thành công", 0)
        'Me.GridView3
        Me.GridView3.ClearGrouping()
        For p_Count = Me.GridView3.RowCount - 1 To 0 Step -1
            GridView3.DeleteRow(p_Count)
        Next

        '  GopTichKe(False, True)
        Me.SoLenh.EditValue = ""
        Me.MaVanChuyen.EditValue = ""
        Me.MaPhuongTien.EditValue = ""
        Me.NguoiVanChuyen.EditValue = ""
        Me.TenMaVanChuyen.EditValue = ""
        Me.NhaCungCap.EditValue = ""

        Me.GhiChu.EditValue = ""



        Me.DefaultFormLoad = True
        Me.Form1_Load(sender, e)
        Me.DefaultFormLoad = False

        Me.SoLenh.Focus()

        p_DanhSachPTGhep = ""
        p_PTien1 = ""
        p_NVC1 = ""


    End Sub

    Private Sub GridView2_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        Dim p_Value As String = ""
        Dim p_DuXuat As Double = 0
        If UCase(e.Column.FieldName) = UCase("tableid") Then
            If Not e.Value Is Nothing Then
                p_Value = e.Value
                If p_Value.ToString.Trim = "" Then
                    Me.GridView2.SetFocusedRowCellValue("SoLuongDuXuat", 0)
                    Me.GridView2.SetFocusedRowCellValue("TenHangHoa", "")
                    Me.GridView2.SetFocusedRowCellValue("SoLenh", "")
                Else
                    Try
                        p_DuXuat = Me.GridView2.GetFocusedRowCellValue("DungTichNgan")
                        Me.GridView2.SetFocusedRowCellValue("SoLuongDuXuat", 0)
                    Catch ex As Exception
                        Me.GridView2.SetFocusedRowCellValue("SoLuongDuXuat", 0)
                        Me.GridView2.SetFocusedRowCellValue("TenHangHoa", "")
                        Me.GridView2.SetFocusedRowCellValue("SoLenh", "")
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub GridView2_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanging

    End Sub

    Private Sub GridView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.GridView2.FocusedRowHandle = Me.GridView2.FocusedRowHandle + 1
        End If
    End Sub


    Private Function KiemTraPhuongTienQuaTai(ByVal p_SoLenh As String, ByVal p_MaPhuongTien1 As String, _
                                                    Optional ByVal p_OK As Boolean = False, _
                                                    Optional ByVal p_LenhGhep As Boolean = False) As Boolean

        Dim p_SQL As String = ""
        Dim p_DataTable As DataTable
        Dim p_DataTable1 As DataTable
        Dim p_DataSet As DataSet
        Dim p_MaPhuongTien As String = ""
        Dim p_Count As Integer
        Dim p_ValueMess As Windows.Forms.DialogResult

        Dim p_QCI_Kg As Double = 0

        Dim p_Binding As U_TextBox.U_BindingSource
        '  Dim p_DataTableNew As DataTable
        Try
            KiemTraPhuongTienQuaTai = False
            p_SQL = ""
            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_SQL = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            p_SQL = GetLoadingSite(p_SQL)

            If UCase(p_SQL) <> "BO" Then
                Exit Function
            End If

            If p_LenhGhep = False Then
                If Not Me.MaPhuongTien.EditValue Is Nothing Then
                    p_DanhSachPTGhep = Me.MaPhuongTien.EditValue.ToString.Trim
                End If
            Else
                If KiemTraPhuongTienAo(p_DanhSachPTGhep) = True Then
                    Exit Function
                End If
            End If

            If p_DanhSachPTGhep = "" Then
                Exit Function
            End If
            'If p_LenhGhep = True Then
            '    p_SQL = "select distinct MaPhuongTien From tblLenhXuatE5 where charindex (',' + SoLenh + ',', ',' +'" & p_SoLenh & "' + ',') >0 "
            '    p_DataTable = GetDataTable(p_SQL, p_SQL)
            '    If Not p_DataTable Is Nothing Then
            '        For p_Count = 0 To p_DataTable.Rows.Count - 1
            '            p_MaPhuongTien = p_MaPhuongTien & "," & p_DataTable.Rows(p_Count).Item("MaPhuongTien").ToString.Trim
            '        Next
            '    End If

            '    Else
            '        p_MaPhuongTien = p_MaPhuongTien1
            '    End If
            '    If p_MaPhuongTien = "" Then
            '        Exit Function
            '    End If

            GetTaiTrongKG(p_NhietDoNgay)

            Me.GridView1.RefreshData()


            If Me.FormStatus = False Then
                Exit Function
            End If
            p_Binding = Me.TrueDBGrid1.DataSource
            p_DataTable = CType(p_Binding.DataSource, DataTable)
            For p_Count = 0 To p_DataTable.Rows.Count - 1
                If p_DataTable.Rows(p_Count).Item("QCI_KG").ToString.Trim <> "" Then
                    p_QCI_Kg = p_QCI_Kg + p_DataTable.Rows(p_Count).Item("QCI_KG")
                End If
            Next

            p_SQL = "select MaPhuongTien, isnull(TaiTrong,0) TaiTrong  from tblPhuongTien_TaiTrong   " & _
                                "where MaPhuongTien='" & p_DanhSachPTGhep & "'  and CONVERT(date,getdate())>=CONVERT(date, ISNULL( TuNgay,getdate()))  " & _
                                    " and CONVERT(date,getdate())<=CONVERT(date, ISNULL( DenNgay,getdate())) order by id desc; " & _
                                    " select MaPhuongTien from  tblPhuongTien_TaiTrong  where MaPhuongTien='" & p_DanhSachPTGhep & "' "
            p_DataSet = GetDataSet(p_SQL, p_SQL)
            If Not p_DataSet Is Nothing Then
                p_DataTable = p_DataSet.Tables(0)
                p_DataTable1 = p_DataSet.Tables(1)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count <= 0 Then  'Trường hợp tải trọng chưa khai báo hoặc đã hết hạn đăng ký tải trọng
                        If Not p_DataTable1 Is Nothing Then
                            If p_DataTable1.Rows.Count <= 0 Then
                                If p_OK = True Then
                                    ShowMessageBox("", "Phương tiện chưa khai báo tải trọng")
                                    KiemTraPhuongTienQuaTai = True
                                    Exit Function
                                Else
                                    p_ValueMess = g_Module.ShowMessage(Me, "", _
                                                    "Phương tiện chưa khai báo tải trọng." & vbCrLf & "Bạn có muốn thực hiện tiếp không?", _
                                                    True, _
                                                     "Có", _
                                                    True, _
                                                    "Không", _
                                                    False, _
                                                    "", _
                                                     0)
                                    If p_ValueMess = Windows.Forms.DialogResult.No Then
                                        KiemTraPhuongTienQuaTai = True
                                        Exit Function
                                    End If
                                End If
                            Else
                                If p_OK = True Then
                                    ShowMessageBox("", "Phương tiện hết hạn kiểm định tải trọng")
                                    KiemTraPhuongTienQuaTai = True
                                    Exit Function
                                Else
                                    p_ValueMess = g_Module.ShowMessage(Me, "", _
                                                    "Phương tiện hết hạn kiểm định tải trọng." & vbCrLf & "Bạn có muốn thực hiện tiếp không?", _
                                                    True, _
                                                     "Có", _
                                                    True, _
                                                    "Không", _
                                                    False, _
                                                    "", _
                                                     0)
                                    If p_ValueMess = Windows.Forms.DialogResult.No Then
                                        KiemTraPhuongTienQuaTai = True
                                        Exit Function
                                    End If
                                End If
                            End If
                        Else
                            If p_OK = True Then
                                ShowMessageBox("", "Phương tiện chưa khai báo tải trọng")
                                KiemTraPhuongTienQuaTai = True
                                Exit Function
                            Else
                                p_ValueMess = g_Module.ShowMessage(Me, "", _
                                                "Phương tiện chưa khai báo tải trọng." & vbCrLf & "Bạn có muốn thực hiện tiếp không?", _
                                                True, _
                                                 "Có", _
                                                True, _
                                                "Không", _
                                                False, _
                                                "", _
                                                 0)
                                If p_ValueMess = Windows.Forms.DialogResult.No Then
                                    KiemTraPhuongTienQuaTai = True
                                    Exit Function
                                End If
                            End If
                        End If
                    Else
                        If p_QCI_Kg > p_DataTable.Rows(0).Item("TaiTrong") Then
                            If p_DataTable.Rows(0).Item("TaiTrong").ToString.Trim <> "" Then
                                If p_DataTable.Rows(0).Item("TaiTrong") > 0 Then
                                    If Math.Round(((p_QCI_Kg / p_DataTable.Rows(0).Item("TaiTrong")) * 100), 0) - 100 >= p_TaiTrongChoPhep Then



                                        ShowMessageBox("", "Tổng lượng xuất vượt quá tải trọng phương tiện " & Math.Round(((p_QCI_Kg / p_DataTable.Rows(0).Item("TaiTrong")) * 100), 0) - 100 & "%")
                                        KiemTraPhuongTienQuaTai = True
                                        Exit Function

                                    Else
                                        If Math.Round(((p_QCI_Kg / p_DataTable.Rows(0).Item("TaiTrong")) * 100), 0) - 100 >= 15 And Math.Round(((p_QCI_Kg / p_DataTable.Rows(0).Item("TaiTrong")) * 100), 0) - 100 < p_TaiTrongChoPhep Then
                                            p_ValueMess = g_Module.ShowMessage(Me, "", _
                                                "Tổng lượng xuất vượt quá tải trọng phương tiện " & Math.Round(((p_QCI_Kg / p_DataTable.Rows(0).Item("TaiTrong")) * 100), 0) - 100 & "%." & vbCrLf & "Bạn có muốn thực hiện tiếp không?", _
                                                True, _
                                                 "Có", _
                                                True, _
                                                "Không", _
                                                False, _
                                                "", _
                                                 0)
                                            If p_ValueMess = Windows.Forms.DialogResult.No Then
                                                KiemTraPhuongTienQuaTai = True
                                                Exit Function
                                            End If

                                            ' Else

                                        End If
                                        Exit Function
                                    End If
                                End If
                            End If

                            If p_OK = True Then
                                ShowMessageBox("", "Tổng lượng xuất vượt quá tải trọng phương tiện")
                                KiemTraPhuongTienQuaTai = True
                                Exit Function
                            Else
                                p_ValueMess = g_Module.ShowMessage(Me, "", _
                                                "Tổng lượng xuất vượt quá tải trọng phương tiện." & vbCrLf & "Bạn có muốn thực hiện tiếp không?", _
                                                True, _
                                                 "Có", _
                                                True, _
                                                "Không", _
                                                False, _
                                                "", _
                                                 0)
                                If p_ValueMess = Windows.Forms.DialogResult.No Then
                                    KiemTraPhuongTienQuaTai = True
                                    Exit Function
                                End If
                            End If
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            ShowMessageBox("", ex.Message)
            KiemTraPhuongTienQuaTai = True

        End Try


    End Function


    Private Sub MaPhuongTien_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MaPhuongTien.Validating
        Dim p_Status As String = ""
        Dim p_abc As U_TextBox.U_ButtonEdit
        Dim p_SQL As String = ""
        Dim p_OldValue As String = ""
        Dim p_NewValue As String = ""
        Dim p_DataTable As DataTable
        Dim p_MaVanChuyen As String = ""
        Dim p_SoLenh As String = ""
        Dim p_MaPhuongTien As String = ""
        Dim p_CheckPT As Boolean = False
        Dim p_New As Boolean = False
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_SyncMaster As SynMaster.Class1
        Dim p_Count As Integer
        Dim p_LoaiXuat As String
        Dim p_Desc As String
        'Dim p_SQL As String = Dim p_SyncMaster As New SynMaster.Class1
        If Me.g_FormLoad = True Then
            Exit Sub
        End If
        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        p_abc = CType(sender, U_TextBox.U_ButtonEdit)

        'CheckPhuongTien(p_abc.EditValue.ToString.Trim, p_CheckPT, p_SQL, p_New)
        p_SoLenh = ""
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If

        If p_abc.IsModified = False Then
            Exit Sub
        End If

        If Not p_abc.EditValue Is Nothing And (p_Status = "1" Or p_Status = "2" Or p_Status = "") Then
            ' If Not p_abc.OldEditValue Is Nothing Then



            If p_abc.EditValue.ToString.Trim <> "" Then
                If Not p_abc.OldEditValue Is Nothing Then
                    If p_abc.OldEditValue.ToString.Trim = "" Then
                        p_CheckPT = True
                    Else
                        If p_abc.OldEditValue <> p_abc.EditValue Then
                            p_CheckPT = True
                        End If
                    End If

                Else
                    p_CheckPT = True
                End If
                If p_CheckPT = True Then
                    p_CheckPT = False
                    CheckPhuongTien(p_abc.EditValue.ToString.Trim, p_CheckPT, p_SQL, p_New)
                    If p_CheckPT = True Then
                        If p_New = False Then
                            ShowMessageBox("", p_SQL)

                            e.Cancel = True
                            If Not p_abc.OldEditValue Is Nothing Then
                                Me.MaPhuongTien.EditValue = p_abc.OldEditValue
                            Else
                                Me.MaPhuongTien.EditValue = ""
                            End If
                            Exit Sub
                        Else

                            'anhqh
                            '20160725
                            'Dong bo phuong tien neu khong co trong Db
                            'ShowMessageBox("", p_SQL)
                            p_ValueMess = g_Module.ShowMessage(Me, "", _
                                                 "Bạn có muốn đồng bộ phương tiện này không? ", _
                                                    True, _
                                                     "Có", _
                                                    True, _
                                                    "Không", _
                                                    False, _
                                                    "", _
                                                     0)
                            If p_ValueMess = Windows.Forms.DialogResult.Yes Then
                                'Exit Sub
                                p_SyncMaster = New SynMaster.Class1(g_WCF, g_Services, flag, lw_mess, isGetAll, _
                                                    g_dt, _SapConnectionString, _WareHouse, _dtVariable, g_Company_Code, _ShPoint)
                                If p_SyncMaster.ClsSyncMaster_SyncVehicleDownNew(p_abc.EditValue.ToString, p_Count, p_Desc) = False Then
                                    ShowMessageBox("", p_Desc)
                                    Exit Sub
                                End If
                                If p_Count = 0 Then
                                    ShowMessageBox("", "Không có phương tiện đồng bộ")
                                    e.Cancel = True
                                    Exit Sub
                                End If
                            Else
                                e.Cancel = True
                                If Not p_abc.OldEditValue Is Nothing Then
                                    Me.MaPhuongTien.EditValue = p_abc.OldEditValue
                                Else
                                    Me.MaPhuongTien.EditValue = ""
                                End If
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
            p_CheckPT = False
            '  If p_abc.EditValue.ToString.Trim <> "" Then

            ' p_Sender As New U_TextBox.U_ButtonEdit
            '  p_Sender = CType(sender, U_TextBox.U_ButtonEdit)
            'If p_Sender.OldEditValue Is Nothing Then
            '    p_Value = p_Sender.EditValue.ToString.Trim
            '    LoadDefault(p_Value)
            '    Exit Sub
            'End If
            ''  p_Sender = CType(sender, U_TextBox.U_ButtonEdit)
            'p_Value = p_Sender.EditValue
            'If p_Sender.OldEditValue <> p_Value Then
            '    LoadDefault(p_Value)
            'End If


            'If Me.MaPhuongTien.IsModified = True Then

            '    p_CheckPT = True
            'End If
            If Me.MaPhuongTien.IsModified = True Then


                If KiemTraPhuongTienQuaTai(p_SoLenh, p_abc.EditValue.ToString.Trim) = True Then
                    e.Cancel = True
                    Exit Sub
                End If

                If KiemtraKhacPTien() = False Then
                    e.Cancel = True
                    Me.MaPhuongTien.EditValue = ""
                    Exit Sub
                End If
                If Not Me.MaPhuongTien.EditValue Is Nothing Then
                    p_MaVanChuyen = Me.MaPhuongTien.EditValue.ToString.Trim
                End If
                If p_PTien1 = "" Then
                    If KiemTraPhuongTienAo(p_MaVanChuyen) = False Then
                        p_PTien1 = p_abc.EditValue.ToString.Trim
                        If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
                            p_NVC1 = Me.NguoiVanChuyen.EditValue.ToString.Trim
                        End If

                    End If
                End If



            End If

            '   End If


            'End If


        End If

        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            p_LoaiXuat = Me.MaVanChuyen.EditValue.ToString.Trim
        End If
        p_CheckPT = False

        If Not p_abc.EditValue Is Nothing Then
            If p_abc.EditValue.ToString.Trim <> "" Then
                CheckPhuongTien_LoaiXuat(p_abc.EditValue.ToString.Trim, p_CheckPT, p_SQL, p_LoaiXuat)
            End If
        End If


        If p_CheckPT = True Then
            ShowMessageBox("", p_SQL)
            e.Cancel = True
            Exit Sub
        Else
            If g_KV1 = True Then
                p_SQL = ""
                If Not Me.MaVanChuyen.EditValue Is Nothing Then
                    p_SQL = Me.MaVanChuyen.EditValue.ToString.Trim
                End If
                If p_SQL = "" Then
                    Me.MaVanChuyen.EditValue = p_LoaiXuat
                End If
                p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
                Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)

            End If
        End If

        '  Exit Sub
        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim


            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            p_MaVanChuyen = GetLoadingSite(p_MaVanChuyen)
            If UCase(p_MaVanChuyen) = "THUY" Then
                Exit Sub
            End If

            If Not Me.SoLenh.EditValue Is Nothing Then
                p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
            End If

            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_MaPhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
            End If

            If p_Status = "1" Or p_Status = "2" Or p_Status = "" Then '===========================================================
                ''Truong hop lay Nguoi van chuyen theo yeu cau cua KV1
                Dim p_PhuongTien As String = ""
                Dim p_NguoiVanChuyen As String
                'Dim p_Desc As String

                If Me.MaPhuongTien.IsModified = False Then
                    Exit Sub
                End If



                If Not Me.Status.EditValue Is Nothing Then
                    p_Status = Me.Status.EditValue.ToString.Trim
                End If

                If Me.FormEdit = False Then
                    Exit Sub
                End If
                'If Not Me.MaPhuongTien.EditValue Is Nothing Then
                '    p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
                'End If
                p_PhuongTien = p_MaPhuongTien
                If p_PhuongTien = "" Then
                    ' If p_MaPhuongTien = "" Then
                    Me.ChartControl2.PaletteName = "Palette 4"
                    Exit Sub
                    ' End If
                    Exit Sub
                End If
                p_NguoiVanChuyen = ""
                If getNguoiVanChuyen(p_PhuongTien, p_NguoiVanChuyen, p_Desc, Me) = False Then
                    ' ShowMessageBox("", p_Desc)

                    Me.MaPhuongTien.EditValue = ""
                    e.Cancel = True
                    Exit Sub
                End If
                If p_NguoiVanChuyen <> "" Then
                    If Me.NguoiVanChuyen.EditValue Is Nothing Then
                        Me.NguoiVanChuyen.EditValue = p_NguoiVanChuyen
                    Else
                        If Me.NguoiVanChuyen.EditValue.ToString <> p_NguoiVanChuyen Then
                            Me.NguoiVanChuyen.EditValue = p_NguoiVanChuyen
                        End If
                    End If

                End If

            End If '===========================================================

            If p_Status = "31" Or p_Status = "3" Then                ' Else
                If sender.OldEditValue Is Nothing Then
                    Exit Sub
                End If

                If sender.EditValue Is Nothing Then
                    Exit Sub
                End If



                p_SQL = "select 1 as STT from ( " & _
                   "select SoLuongDuXuat, COUNT(MaNgan) as SLNgan  from FPT_tblLenhXuatChiTietE5_V where SoLenh='" & p_SoLenh & "' " & _
                       " group by SoLuongDuXuat ) abc " & _
                       " where not exists ( " & _
                       " select 1 from  (" & _
                       "select SoLuongMax , COUNT(MaNgan) as SLNgan from tblChiTietPhuongTien where MaPhuongTien ='" & p_MaPhuongTien & "' Group by SoLuongMax) def " & _
                    "where abc.SoLuongDuXuat =def.SoLuongMax  and abc.SLNgan <=def.SLNgan )"
                p_DataTable = GetDataTable(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        ShowMessageBox("", "Phương tiện có dung tích ngăn không đồng nhất")
                        e.Cancel = True
                    End If
                End If
                'If sender.EditValue.ToString.Trim <> sender.OldEditValue.ToString.Trim Then
                '    '    sender.EditValue.ToString.Trim = p_abc.OldEditValue.ToString.Trim
                '    p_OldValue = p_abc.OldEditValue.ToString.Trim
                '    p_NewValue = p_abc.EditValue.ToString.Trim
                '    sender.ValidateValue = False
                'End If

            Else
                'sender.ValidateValue = False

            End If
            ' p_abc = CType(sender, U_TextBox.U_ButtonEdit)
        End If


        If Not p_abc.EditValue Is Nothing Then
            If p_abc.EditValue.ToString.Trim <> "" Then
                CallChartBar3D()
            End If
        End If



    End Sub

    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        Dim p_Status As String = ""
        Dim p_NhietDoKG As Double = 0
        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If p_Status = "3" Or p_Status = "31" Or p_Status = "4" Or p_Status = "5" Then
            ShowMessageBox("", "Trạng thái lệnh xuất không hợp lệ")
            Exit Sub
        End If
        p_Status = ""
        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            p_Status = Me.MaVanChuyen.EditValue.ToString.Trim
        End If

        p_Status = GetLoadingSite(p_Status)
        If UCase(p_Status) <> "BO" Then
            ShowMessageBox("", "Chức năng chỉ dùng cho xuất bộ")
            Exit Sub
        End If

        Dim p_Form As New FrmQciKg
        p_Form.g_XtraServicesObj = g_XtraServicesObj
        p_Form.p_XtraModuleObj = p_XtraModuleObj
        p_Form.FrmQciKg_NhietDo = p_NhietDoNgay
        p_Form.ShowDialog(Me)

        p_NhietDoNgay = p_Form.FrmQciKg_NhietDo
        GetTaiTrongKG(p_NhietDoNgay, True)
    End Sub

    Private Sub NguoiVanChuyen_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles NguoiVanChuyen.Validating
        Dim p_PhuongTien As String = ""
        Dim p_NguoiVanChuyen As String
        Dim p_Desc As String
        Dim p_Status As String = "2"

        If Me.NguoiVanChuyen.IsModified = False Then
            Exit Sub
        End If

        'If p_PTien1 <> "" Then
        If p_NVC1 = "" Then
            If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
                p_NVC1 = Me.NguoiVanChuyen.EditValue.ToString.Trim
            End If
        End If
        ' End If

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If p_Status = "1" Or p_Status = "2" Or p_Status = "" Then
            If Me.FormEdit = False Then
                Exit Sub
            End If
            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
            End If
            If p_PhuongTien = "" Then
                Exit Sub
            End If

            p_NguoiVanChuyen = ""
            If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
                p_NguoiVanChuyen = Me.NguoiVanChuyen.EditValue.ToString.Trim
            End If
            If p_NguoiVanChuyen = "" Then
                Exit Sub
            End If

            If getNguoiVanChuyen(p_PhuongTien, p_NguoiVanChuyen, p_Desc, Me) = False Then
                ' ShowMessageBox("", p_Desc)
                e.Cancel = True
                Exit Sub
            End If
        End If
    End Sub



    Private Sub ResetChart()
        Dim series1 As New DevExpress.XtraCharts.Series
        Dim series2 As New DevExpress.XtraCharts.Series
        Dim series3 As New DevExpress.XtraCharts.Series
        Dim p_Row As DataRow
        series1 = Me.ChartControl2.Series.Item("Series1")

        series3 = Me.ChartControl2.Series.Item("Series3")

        series2 = Me.ChartControl2.Series.Item("Series2")

        Me.ChartControl2.PaletteName = "Palette 5"
        Dim p_DataTable As New DataTable("Tbale01")
        Dim p_DataTable1 As New DataTable("Tbale01")

        p_DataTable.Columns.Add("txt_Name")
        p_DataTable.Columns.Add("txt_Value", Type.GetType("System.Double"))

        p_Row = p_DataTable.NewRow
        p_Row.Item(0) = "A"
        p_Row.Item(1) = 0  '- -p_DuXuat
        p_DataTable.Rows.Add(p_Row)


        p_DataTable1 = p_DataTable.Clone
        p_Row = p_DataTable1.NewRow
        p_Row.Item(0) = "A"
        p_Row.Item(1) = 100  '- -p_DuXuat
        p_DataTable1.Rows.Add(p_Row)

        series1.DataSource = p_DataTable
        series1.ArgumentDataMember = "txt_Name"
        series1.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical
        series1.ValueDataMembers.AddRange({"txt_Value"})


        series2.DataSource = p_DataTable
        series2.ArgumentDataMember = "txt_Name"
        series2.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical
        series2.ValueDataMembers.AddRange({"txt_Value"})

        ' p_DataTable.Rows(0).Item(1) = 100
        series3.DataSource = p_DataTable1
        series3.ArgumentDataMember = "txt_Name"
        series3.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical
        series3.ValueDataMembers.AddRange({"txt_Value"})



        'series1.Points.Item(1).Values
        'series1.Points.Item(1).Values = 100
    End Sub
    Private Sub CallChartBar3D()
        Dim p_SQL As String

        ' Exit Sub

        Dim p_RowArr() As DataRow
        Dim p_ProcedureName As String
        Dim p_ObjectArr() As Object
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_Table As DataTable
        Dim p_Table1 As DataTable
        Dim p_Count As Integer
        ' Dim p_SQL As String = ""

        Dim p_TaiTrongXe As Double = 0
        Dim p_DuXuat As Double = 0

        Dim p_DataTable As New DataTable("Tbale01")
        Dim p_DataTable2 As New DataTable("Tbale02")

        Dim p_DataTable3 As New DataTable("Tbale03")


        Dim p_Row As DataRow

        Dim p_MaPhuongTien As String

        p_DataTable3.Columns.Add("txt_Name")
        p_DataTable3.Columns.Add("txt_Value", Type.GetType("System.Double"))

        '  Exit Sub

        p_Binding = Me.TrueDBGrid3.DataSource

        If Not p_Binding Is Nothing Then
            p_Table1 = CType(p_Binding.DataSource, DataTable)
        End If

        p_MaPhuongTien = ""
        If Not Me.MaPhuongTien.EditValue Is Nothing Then
            p_MaPhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
        End If
        If Not p_Table1 Is Nothing Then
            For p_Count = 0 To p_Table1.Rows.Count - 1
                If p_Table1.Rows(p_Count).Item("MaPhuongTien").ToString.Trim() <> "" _
                    And KiemTraPhuongTienAo(p_Table1.Rows(p_Count).Item("MaPhuongTien").ToString.Trim()) = False Then
                    If InStr(p_MaPhuongTien, p_Table1.Rows(p_Count).Item("MaPhuongTien").ToString.Trim(), CompareMethod.Text) <= 0 Then
                        p_MaPhuongTien = p_MaPhuongTien & "," & p_Table1.Rows(p_Count).Item("MaPhuongTien").ToString.Trim()
                    End If

                End If
            Next
        End If


        If p_MaPhuongTien = "" Then
            Me.ChartControl2.PaletteName = "Palette 4"
            Exit Sub
        End If

        p_SQL = "   select top 1 isnull([TaiTrong],0) as iweight   from tblPhuongTien_TaiTrong with (nolock) " & _
                    " where CHARINDEX (',' +   MaPhuongTien + ',','," & p_MaPhuongTien & ",',1)>0  " & _
                    " and convert(date,getdate())>=convert(date,isnull(TuNgay,getdate()))  " & _
                    " and convert(date,getdate())<=convert(date,isnull(DenNgay,getdate())) order by id desc "
        ' p_HDataTable = GetDataTable(p_SQL, p_SQL)
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_TaiTrongXe = p_Table.Rows(0).Item(0)
            End If

        End If
        p_DuXuat = 0

        p_Binding = Me.TrueDBGrid1.DataSource
        p_Table1 = CType(p_Binding.DataSource, DataTable)

        For p_Count = 0 To p_Table1.Rows.Count - 1
            If p_Table1.Rows(p_Count).RowState = DataRowState.Deleted Then
                Continue For
            End If
            If p_Table1.Rows(p_Count).Item("QCI_KG").ToString.Trim() <> "" Then
                p_DuXuat = p_DuXuat + p_Table1.Rows(p_Count).Item("QCI_KG").ToString.Trim
            End If
        Next
        p_DataTable.Columns.Add("txt_Name")
        p_DataTable.Columns.Add("txt_Value", Type.GetType("System.Double"))

        p_DataTable2.Columns.Add("txt_Name")
        p_DataTable2.Columns.Add("txt_Value", Type.GetType("System.Double"))





        '   Dim chart As New DevExpress.XtraCharts.ChartControl()
        ' Me.ChartControl2.Series.Item("Series2").Points(0).Argument.  
        Try
            Dim series1 As New DevExpress.XtraCharts.Series
            Dim series2 As New DevExpress.XtraCharts.Series
            Dim series3 As New DevExpress.XtraCharts.Series

            series1 = Me.ChartControl2.Series.Item("Series1")

            series3 = Me.ChartControl2.Series.Item("Series3")

            series2 = Me.ChartControl2.Series.Item("Series2")










            'Me.ChartControl2.PaletteName="Nature Colors"
            'Me.ChartControl2.PaletteName="Nature Colors"

            If p_TaiTrongXe <= 0 Then
                p_TaiTrongXe = p_DuXuat
            End If

            If p_TaiTrongXe < p_DuXuat Then

                p_Row = p_DataTable.NewRow
                p_Row.Item(0) = "A"
                p_Row.Item(1) = 0  '- -p_DuXuat
                p_DataTable.Rows.Add(p_Row)



                p_DataTable2 = p_DataTable.Clone
                p_Row = p_DataTable2.NewRow
                p_Row.Item(0) = "A"
                p_Row.Item(1) = 100
                p_DataTable2.Rows.Add(p_Row)

                p_DataTable3 = p_DataTable.Clone
                p_Row = p_DataTable3.NewRow
                p_Row.Item(0) = "A"
                p_Row.Item(1) = Math.Round(((p_DuXuat / p_TaiTrongXe) * 100), 0) - 100
                p_DataTable3.Rows.Add(p_Row)
                'If p_DuXuat > p_TaiTrongXe Then
                '    series2.
                'End If

                'Palette 2
                Me.ChartControl2.PaletteName = "Palette 1"
            Else
                p_Row = p_DataTable.NewRow
                p_Row.Item(0) = "A"
                p_Row.Item(1) = Math.Round((p_DuXuat / p_TaiTrongXe) * 100, 0)   '- -p_DuXuat
                p_DataTable.Rows.Add(p_Row)



                p_DataTable2 = p_DataTable.Clone
                p_Row = p_DataTable2.NewRow
                p_Row.Item(0) = "A"
                p_Row.Item(1) = 100 - Math.Round((p_DuXuat / p_TaiTrongXe) * 100, 0)
                p_DataTable2.Rows.Add(p_Row)

                p_DataTable3 = p_DataTable.Clone
                p_Row = p_DataTable3.NewRow
                p_Row.Item(0) = "A"
                p_Row.Item(1) = 0
                p_DataTable3.Rows.Add(p_Row)



                If 100 - Math.Round((p_DuXuat / p_TaiTrongXe) * 100, 0) <= 20 And 100 - Math.Round((p_DuXuat / p_TaiTrongXe) * 100, 0) > 11 Then 'And 100 - Math.Round((p_DuXuat / p_TaiTrongXe) * 100, 0) <= 0 Then
                    Me.ChartControl2.PaletteName = "Palette 2"
                ElseIf 100 - Math.Round((p_DuXuat / p_TaiTrongXe) * 100, 0) >= 0 And 100 - Math.Round((p_DuXuat / p_TaiTrongXe) * 100, 0) <= 10 Then
                    Me.ChartControl2.PaletteName = "Palette 3"
                Else

                    Me.ChartControl2.PaletteName = "Palette 5"
                End If


                'Me.ChartControl2.PaletteName = "Nature Colors"
            End If

            series1.DataSource = p_DataTable
            series1.ArgumentDataMember = "txt_Name"
            series1.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical
            series1.ValueDataMembers.AddRange({"txt_Value"})


            series2.DataSource = p_DataTable2
            series2.ArgumentDataMember = "txt_Name"
            series2.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical
            series2.ValueDataMembers.AddRange({"txt_Value"})

            series3.DataSource = p_DataTable3
            series3.ArgumentDataMember = "txt_Name"
            series3.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical
            series3.ValueDataMembers.AddRange({"txt_Value"})

            ' series3.PointOptions.PointView = DevExpress.XtraCharts.PointView.Undefined

            '  Me.ChartControl2.Visible = True
        Catch ex As Exception

        End Try
        ' Me.ChartControl2.AppearanceName = "Dark"

        'Me.ChartControl2.Visible = True
    End Sub


    Private Sub GanMaBeChoLenhXuat()
        Dim p_Count As Integer
        Dim p_SQL As String
        Dim lNewVariable As String = ""
        Dim p_SoLenh As String = lNewVariable
        Dim p_Datatable As DataTable
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_RowArr() As DataRow
        Dim p_TableID As String
        Dim p_Status As String = lNewVariable
        Dim p_BeXuat As String = lNewVariable

        Dim p_Date As Date
        Dim p_Time As Integer

        Dim p_LoaiXuat As String = lNewVariable

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            p_LoaiXuat = Me.MaVanChuyen.EditValue.ToString.Trim
        End If
        p_LoaiXuat = GetLoadingSite(p_LoaiXuat)
        If UCase(p_LoaiXuat) <> "BO" Then
            U_ButtonCus2.Visible = False
        End If



        If p_Status <> "2" And p_Status <> "1" And p_Status <> lNewVariable Then
            Exit Sub
        End If

        'If Not Me.SoLenh.EditValue Is Nothing Then
        '    p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        'End If
        p_SoLenh = ""
        p_Binding = Me.TrueDBGrid1.DataSource
        p_Datatable = CType(p_Binding.DataSource, DataTable)
        For p_Time = 0 To p_Datatable.Rows.Count - 1
            If p_Datatable.Rows(p_Time).Item("SoLenh").ToString.Trim <> "" Then
                p_SoLenh = p_SoLenh & "," & p_Datatable.Rows(p_Time).Item("SoLenh").ToString.Trim
            End If

        Next

        If Not Me.NgayTichKe.EditValue Is Nothing Then
            If Me.NgayTichKe.EditValue.ToString.Trim <> lNewVariable Then
                Me.DateNgayXuat.EditValue = Me.NgayTichKe.EditValue
            Else
                p_GetDateTime(p_Date, p_Time)
                Me.DateNgayXuat.EditValue = p_Date
            End If
        End If

        'Dim p_Binding As U_TextBox.U_BindingSource
        'p_Binding = Me.GridView1.DataSource
        'p_Datatable = CType(p_Binding.DataSource, DataTable)



        If g_Filter_Terminal = True Then
            p_SQL = "select TableID ,(select top 1 Name_nd from FPT_tblTankActive_V b  where (b.Product_nd = a.MaHangHoa) " & _
                 " and b.Date1= a.NgayTichKe 	and  (LoadingSite is null or LoadingSite ='' or upper(LoadingSite)=upper( :LoaiXuat ) ) " & _
              " and left(Name_nd,LEN ('" & g_Terminal & "')) like '" & g_Terminal & "%'  " & _
              " order by Name_nd ) as  BeXuat from fpt_tblLenhXuat_HangHoaE5_V1 A with (nolock) " & _
             "  where  CHARINDEX(',' + SoLenh + ',','," & p_SoLenh & ",',1) > 0"


            'where SoLenh='" & p_SoLenh & "'"

        Else
            p_SQL = "select TableID, (select top 1 Name_nd from FPT_tblTankActive_V b  where (b.Product_nd = a.MaHangHoa) " & _
                " and b.Date1=a.NgayTichKe 	and  (LoadingSite is null or LoadingSite ='' or upper(LoadingSite)=upper( :LoaiXuat ) ) " & _
              " order by Name_nd) as  BeXuat from fpt_tblLenhXuat_HangHoaE5_V1 A with (nolock) " & _
            "  where  CHARINDEX(',' + SoLenh + ',','," & p_SoLenh & ",',1) > 0"

            'where SoLenh='" & p_SoLenh & "'"
        End If


        p_SQL = p_XtraModuleObj.Parameter_Item(Me, p_SQL)


        p_Datatable = GetDataTable(p_SQL, p_SQL)

        'Dim p_Row As DataRow
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                For p_Count = 0 To Me.GridView1.RowCount - 1

                    p_TableID = Me.GridView1.GetRowCellValue(p_Count, "TableID").ToString.Trim
                    p_BeXuat = Me.GridView1.GetRowCellValue(p_Count, "BeXuat").ToString.Trim
                    p_RowArr = p_Datatable.Select("TableID='" & p_TableID & "'")
                    If p_RowArr.Length > 0 And p_BeXuat = "" Then
                        If p_RowArr(0).Item("BeXuat").ToString.Trim <> "" Then
                            Me.GridView1.SetRowCellValue(p_Count, "BeXuat", p_RowArr(0).Item("BeXuat"))
                            Me.GridView1.SetRowCellValue(p_Count, "CHECKUPD", "Y")
                        End If

                    End If

                    ' p_Row = GridView1.GetDataRow(p_Count)
                Next
            End If
        End If
        GridView1.RefreshData()
        ' GetTaiTrongKG(p_NhietDoNgay, True)
    End Sub

    Private Sub U_ButtonCus2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus2.Click
        Dim p_MaPhuongTien As String = ""
        Dim p_LoaiXuat As String = ""
        If Me.FormStatus = True Then
            ShowMessageBox("", "Đề nghị lưu lại trước khi thực hiện")
            Exit Sub
        End If

        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            p_LoaiXuat = Me.MaVanChuyen.EditValue.ToString.Trim
        End If
        p_LoaiXuat = GetLoadingSite(p_LoaiXuat)
        If UCase(p_LoaiXuat) <> "BO" Then
            ShowMessageBox("", "Chức năng chỉ dùng cho xuất bộ")
            Exit Sub
        End If
        If Not Me.MaPhuongTien.EditValue Is Nothing Then
            p_MaPhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
        End If
        If p_MaPhuongTien = "" Then
            ShowMessageBox("", "Không xác định mã phương tiện")
            Exit Sub
        End If
        Dim p_Form As New FrmVehicle_TaiTrong

        p_Form.p_MaPhuongTien = p_MaPhuongTien
        p_Form.p_XtraModuleObj = p_XtraModuleObj
        p_Form.g_XtraServicesObj = g_XtraServicesObj
        p_Form.ShowDialog(Me)
    End Sub

    Private Sub LockPTien()
        Dim p_Status As String = ""

        If p_KHOA_PTIEN = "Y" Then
            If Not Me.Status.EditValue Is Nothing Then
                p_Status = Me.Status.EditValue.ToString.Trim
            End If
            If p_Status = "3" Or p_Status = "31" Or p_Status = "4" Or p_Status = "5" Then
                Exit Sub
            End If
            p_Status = ""
            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_Status = Me.MaPhuongTien.EditValue.ToString.Trim
            End If
            If KiemTraPhuongTienAo(p_Status) = False Then
                Me.MaPhuongTien.Properties.ReadOnly = True
            Else
                Me.MaPhuongTien.Properties.ReadOnly = False
            End If
        End If
    End Sub

    Private Function KiemTraPhuongTienAo(ByVal p_PhuongTien As String) As Boolean
        Dim p_SQL As String
        KiemTraPhuongTienAo = False
        If p_PhuongTien.ToString.Trim = "" Then
            Return True
        End If

        If Mid(p_PhuongTien, 1, 4) = "XXXX" Or Mid(p_PhuongTien, 1, 4) = "YYYY" Then
            Return True
        End If

        If p_PhuongTienAo = "" Then
            Return False
        End If

        p_SQL = "," & p_PhuongTienAo & ","
        If InStr(p_SQL, "," & p_PhuongTien & ",", CompareMethod.Text) > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub TrueDBGrid1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

    End Sub

    Private Sub SoLenh_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles SoLenh.Layout

    End Sub
End Class