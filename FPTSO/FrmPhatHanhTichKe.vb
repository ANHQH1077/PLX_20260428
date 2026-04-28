Public Class FrmPhatHanhTichKe
    Private p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
    Dim p_SYS_MALENH_S As String = ""
    Dim p_FunctionTableId As String = ""
    Dim p_DateCreate As Date
    Dim p_TimeCreate As Integer
    Dim p_TableConfig As DataTable
    Dim p_TablePara As DataTable
    Dim p_DataTableDVT As DataTable
    Dim p_DataTblConfig As DataTable
    Dim p_CURRENTDATE As Boolean = True
    Dim p_MATUDONGHOA As Boolean = False
    Dim p_SHOW_CLIENT As String = "0"
    Private p_SMO As Boolean = False
    Private g_WeightRate As Integer = 15
    Private g_WeightRateR As Integer = 15   'Dung cho Rơmooc
    Private p_WeightRate As Integer = 0
    Dim p_Date_KV1 As Date
    Private p_TANKAPPROVED As Boolean = False

    Private p_CardNum As Boolean = False
    Private p_CARDREQUIRED As Boolean = False

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
    Private g_TaiTrongChoPhep As Integer = 20

    Private g_TaiTrongRomooc As Integer = 0

    Private g_TaiTrongChoPhep_Thuy As Integer = 20

    Private p_PhuongTienAo As String = ""

    Private p_CONGTO_BO As String = ""
    Private p_KT_TAITRONG As Boolean = True
    Private p_HUYLENHXUAT As Boolean = True

    Private p_LENHNGAY As Boolean = False

    Private p_KEY_F12 As Boolean = False
    Private p_PT_HANKIEMDINH As Integer = 0
    Private p_LX_GIAYTO As Integer = 0

    Private p_DIEMTRAHANG As Boolean = False

    Private p_PT_THONGBAO As Boolean = False

    Private p_Scadar_Type As String = "SQL"
    Private p_MANGAN_SX As Boolean = False
    Private p_KT_CONGTO_THUY As Boolean = True

    Private p_DATNGAN_DX As Boolean = False
    Private p_REFRESH As Boolean = False
    Private p_GIAYTO_XE As Boolean = False
    Private p_GIAYTO_LX As Boolean = False
    Private p_BAREM_XE As Boolean = False

    Private p_THUY_QUA_BAREM As Boolean = False
    Private p_XITEC_OPTION As Boolean = False

    Private p_CONGTO_KiemTra As Boolean = False

    Private p_HONGXUAT As Boolean = False

    Private p_DATNGAN_THUCONG As Boolean = False
    Private p_CONGTOBEXUAT As Boolean = False

    Private p_INTANK_E5 As Boolean = False
    Private p_MatKetNoiSAP As Boolean = False
    Private p_LAINGAY As Boolean = False
    Private p_ThamSoNgay As Boolean = False

    Private p_GiaoNhanHH As Boolean = False

    Private p_SoChuyen As Boolean = False
    Private p_SMOAPI As Boolean = False


    Private p_SMO_BO As Boolean = False
    Private p_SMO_THUY As Boolean = False
    Private p_SMO_BO_R As Boolean = False
    Private p_SMO_THUY_R As Boolean = False


    Private p_LAIXE_BO As Boolean = False
    Private p_LAIXE_THUY As Boolean = False
    Private p_TICHKE_HUY As Boolean = False
    Private p_GHEPNGAN_KH As Boolean = False

    Private p_ThongTinNhomBe As Boolean = False

    Private p_METERID_NGAN As Boolean = False
    Private p_SOLENH_QR As Boolean = False


    Dim p_KIEMKE_N30 As Boolean = False

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
        Dim p_Status As String = ""
        p_SQL = ""
        If e.KeyCode.ToString.Trim = "F5" Then
            ToolStripButton2_Click(sender, e)
        End If
        If e.KeyCode.ToString.Trim = "F12" Then
            If g_KV1 = True Or p_KEY_F12 = True Then
                If Not Me.Status.EditValue Is Nothing Then
                    p_Status = Me.Status.EditValue.ToString.Trim
                End If
                If p_Status = "4" Or p_Status = "5" Then
                    ShowMessageBox("", "Lệnh đã Xác nhận thực xuất nên không thể in tích kê", 3)
                    Exit Sub
                End If
            End If
            ToolStripButton4_Click(sender, e)
        End If
        If e.KeyCode.ToString.Trim = "F2" Then
            If p_SMO = True Then
                Me.pTien.Focus()
            End If
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
        Dim p_TONGDUXUAT As Integer = 0
        Dim p_Datatable As DataTable




        If g_KV1 = True Then
            Me.DiemTraHang.FieldName = "DiemTraHang"
            Me.DiemTraHang.Visible = True
        End If

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
               " CONVERT(date,crDate)=(select MAX(crDate) from tblNhietDo with (Nolock) )	;" & _
               " select * from tblConfig;"

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


                p_DataTblConfig = p_DataSet.Tables(5)
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
                            g_TaiTrongChoPhep = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                            '''g_TaiTrongRomooc = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                        Catch ex As Exception

                        End Try
                    End If
                End If


                'p_TaiTrongChoPhep xuat thuy
                p_DataRow = p_TableConfig.Select("KEYCODE='TAITRONGCHOPHEP_THUY'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        Try
                            g_TaiTrongChoPhep_Thuy = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                        Catch ex As Exception

                        End Try
                    End If
                End If
                'p_TaiTrongChoPhep  Rơ mooc
                p_DataRow = p_TableConfig.Select("KEYCODE='TAITRONGROMOOC'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        Try
                            g_TaiTrongRomooc = p_DataRow(0).Item("KEYVALUE").ToString.Trim
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

                'HUYLENHXUAT
                p_HUYLENHXUAT = True
                p_DataRow = p_TableConfig.Select("KEYCODE='HUYLENHXUAT'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        Try
                            p_HUYLENHXUAT = False
                        Catch ex As Exception

                        End Try
                    End If
                End If


                p_LENHNGAY = False
                p_DataRow = p_TableConfig.Select("KEYCODE='LENHNGAY'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        Try
                            p_LENHNGAY = True
                        Catch ex As Exception

                        End Try
                    End If
                End If

                'KEY_F12
                p_KEY_F12 = False
                p_DataRow = p_TableConfig.Select("KEYCODE='KEY_F12'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        Try
                            p_KEY_F12 = True
                        Catch ex As Exception

                        End Try
                    End If
                End If
                'PT_HANKIEMDINH
                p_PT_HANKIEMDINH = 0
                p_DataRow = p_TableConfig.Select("KEYCODE='PT_HANKIEMDINH'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        Try
                            If IsNumeric(p_DataRow(0).Item("KEYVALUE").ToString.Trim) Then
                                p_PT_HANKIEMDINH = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                            End If

                        Catch ex As Exception

                        End Try
                    End If
                End If

                p_DIEMTRAHANG = False

                p_DataRow = p_TableConfig.Select("KEYCODE='DIEMTRAHANG'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        Try
                            p_DIEMTRAHANG = True
                        Catch ex As Exception

                        End Try
                    End If
                End If
                'LX_GIAYTO
                p_LX_GIAYTO = 0
                p_DataRow = p_TableConfig.Select("KEYCODE='LX_GIAYTO'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        Try
                            If IsNumeric(p_DataRow(0).Item("KEYVALUE").ToString.Trim) Then
                                p_LX_GIAYTO = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                            End If

                        Catch ex As Exception

                        End Try
                    End If
                End If

                'PT_THONGBAO
                p_PT_THONGBAO = False
                p_DataRow = p_TableConfig.Select("KEYCODE='PT_THONGBAO'")
                '   p_DataRow = p_TableConfig.Select("KEYCODE='DIEMTRAHANG'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        Try
                            p_PT_THONGBAO = True
                        Catch ex As Exception

                        End Try
                    End If
                End If

                'MANGAN_SX

                p_MANGAN_SX = False
                p_DataRow = p_TableConfig.Select("KEYCODE='MANGAN_SX'")
                '   p_DataRow = p_TableConfig.Select("KEYCODE='DIEMTRAHANG'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        Try
                            p_MANGAN_SX = True
                        Catch ex As Exception

                        End Try
                    End If
                End If

                'KT_CONGTO_THUY
                p_KT_CONGTO_THUY = True
                p_DataRow = p_TableConfig.Select("KEYCODE='KT_CONGTO_THUY'")
                '   p_DataRow = p_TableConfig.Select("KEYCODE='DIEMTRAHANG'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        Try
                            p_KT_CONGTO_THUY = False
                        Catch ex As Exception

                        End Try
                    End If
                End If

                'DATNGAN_DX
                p_DATNGAN_DX = False
                p_DataRow = p_TableConfig.Select("KEYCODE='DATNGAN_DX'")
                '   p_DataRow = p_TableConfig.Select("KEYCODE='DIEMTRAHANG'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        Try
                            p_DATNGAN_DX = True
                        Catch ex As Exception

                        End Try
                    End If
                End If
                'REFRESH

                p_REFRESH = True
                p_DataRow = p_TableConfig.Select("KEYCODE='REFRESH'")
                '   p_DataRow = p_TableConfig.Select("KEYCODE='DIEMTRAHANG'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        Try
                            p_REFRESH = False
                        Catch ex As Exception

                        End Try
                    End If
                End If



                p_GIAYTO_XE = False
                p_DataRow = p_TableConfig.Select("KEYCODE='GIAYTO_XE'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_GIAYTO_XE = True
                    End If
                End If


                p_GIAYTO_LX = False
                p_DataRow = p_TableConfig.Select("KEYCODE='GIAYTO_LX'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_GIAYTO_LX = True
                    End If
                End If

                p_BAREM_XE = False
                p_DataRow = p_TableConfig.Select("KEYCODE='BAREM_XE'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_BAREM_XE = True
                    End If
                End If


                'g_TICHKE_A3

                g_TICHKE_A3 = False
                p_DataRow = p_TableConfig.Select("KEYCODE='TICHKE_A3'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_TICHKE_A3 = True
                    End If
                End If


                'p_THUY_QUA_BAREM
                p_THUY_QUA_BAREM = False
                p_DataRow = p_TableConfig.Select("KEYCODE='THUY_QUA_BAREM'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_THUY_QUA_BAREM = True
                    End If
                End If


                '
                p_CONGTO_KiemTra = False
                p_DataRow = p_TableConfig.Select("KEYCODE='CONGTO'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_CONGTO_KiemTra = True
                    End If
                End If


                'HONGXUAT
                p_HONGXUAT = False
                p_DataRow = p_TableConfig.Select("KEYCODE='HONGXUAT'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_HONGXUAT = True
                    End If
                End If

                p_DATNGAN_THUCONG = False
                'DATNGAN_THUCONG
                p_DataRow = p_TableConfig.Select("KEYCODE='DATNGAN_THUCONG'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_DATNGAN_THUCONG = True
                    End If
                End If


                p_CONGTOBEXUAT = False
                'DATNGAN_THUCONG
                p_DataRow = p_TableConfig.Select("KEYCODE='CONGTOBEXUAT'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_CONGTOBEXUAT = True
                    End If
                End If


                p_INTANK_E5 = False
                p_DataRow = p_TableConfig.Select("KEYCODE='INTANK_E5'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_INTANK_E5 = True
                    End If
                End If


                p_LAINGAY = False
                p_DataRow = p_TableConfig.Select("KEYCODE='LAINGAY'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_LAINGAY = True
                    End If
                End If



                p_MatKetNoiSAP = False
                p_DataRow = p_TableConfig.Select("KEYCODE='SAPOFF'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_MatKetNoiSAP = True
                    End If
                End If


                p_ThamSoNgay = False
                p_DataRow = p_TableConfig.Select("KEYCODE='THAMSONGAY'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_ThamSoNgay = True
                    End If
                End If


                p_SMO = False
                p_DataRow = p_TableConfig.Select("KEYCODE='SMO'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_SMO = True
                    End If
                End If

                g_WeightRate = 18
                g_WeightRateR = 18
                p_DataRow = p_TableConfig.Select("KEYCODE='WEIGHTRATE'")
                If p_DataRow.Length > 0 Then
                    Integer.TryParse(p_DataRow(0).Item("KEYVALUE").ToString.Trim, g_WeightRate)
                    'If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    '    p_SMO = True
                    'End If
                End If
                If g_WeightRate <= 0 Then
                    g_WeightRate = 15
                End If

                p_DataRow = p_TableConfig.Select("KEYCODE='WEIGHTRATE_R'")
                If p_DataRow.Length > 0 Then
                    Integer.TryParse(p_DataRow(0).Item("KEYVALUE").ToString.Trim, g_WeightRateR)
                    'If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    '    p_SMO = True
                    'End If
                End If
                If g_WeightRateR <= 0 Then
                    g_WeightRateR = 18
                End If

                p_CardNum = False
                p_DataRow = p_TableConfig.Select("KEYCODE='" & g_Terminal & "CARDNUM'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_CardNum = True
                    End If
                End If

                p_CARDREQUIRED = False
                p_DataRow = p_TableConfig.Select("KEYCODE='" & g_Terminal & "CARDREQUIRED'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_CARDREQUIRED = True
                    End If
                End If



                p_GiaoNhanHH = False
                p_DataRow = p_TableConfig.Select("KEYCODE='GiaoNhanHH'  or  KEYCODE='" & UCase("GiaoNhanHH") & "' ")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_GiaoNhanHH = True
                    End If
                End If


                p_SoChuyen = False
                p_DataRow = p_TableConfig.Select("KEYCODE='SOCHUYEN'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_SoChuyen = True
                    End If
                End If


                p_SMOAPI = False
                p_DataRow = p_TableConfig.Select("KEYCODE='SMOAPI'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_SMOAPI = True
                    End If
                End If

                p_SMO_BO = False
                p_DataRow = p_TableConfig.Select("KEYCODE='SMO_BO'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_SMO_BO = True
                    End If
                End If

                p_SMO_THUY = False
                p_DataRow = p_TableConfig.Select("KEYCODE='SMO_THUY'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_SMO_THUY = True
                    End If
                End If
                p_SMO_BO_R = False
                p_DataRow = p_TableConfig.Select("KEYCODE='SMO_BO_R'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_SMO_BO_R = True
                    End If
                End If
                p_SMO_THUY_R = False
                p_DataRow = p_TableConfig.Select("KEYCODE='SMO_THUY_R'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_SMO_THUY_R = True
                    End If
                End If


                p_LAIXE_BO = False
                p_DataRow = p_TableConfig.Select("KEYCODE='LAIXE_BO'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_LAIXE_BO = True
                    End If
                End If

                p_LAIXE_THUY = False
                p_DataRow = p_TableConfig.Select("KEYCODE='LAIXE_THUY'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_LAIXE_THUY = True
                    End If
                End If

                p_TICHKE_HUY = False
                p_DataRow = p_TableConfig.Select("KEYCODE='TICHKE_HUY'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_TICHKE_HUY = True
                    End If
                End If

                p_GHEPNGAN_KH = False
                p_DataRow = p_TableConfig.Select("KEYCODE='GHEPNGAN_KH'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_GHEPNGAN_KH = True
                    End If
                End If


                p_ThongTinNhomBe = False
                p_DataRow = p_TableConfig.Select("KEYCODE='TANK_GROUP'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_ThongTinNhomBe = True
                    End If
                End If

                p_METERID_NGAN = False
                p_DataRow = p_TableConfig.Select("KEYCODE='METERID_NGAN'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_METERID_NGAN = True
                    End If
                End If

                p_KIEMKE_N30 = False
                p_DataRow = p_TableConfig.Select("KEYCODE='KIEMKE_N30'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_KIEMKE_N30 = True
                    End If
                End If

                p_SOLENH_QR = False
                p_DataRow = p_TableConfig.Select("KEYCODE='SOLENH_QR'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_SOLENH_QR = True
                    End If
                End If
            End If
        End If

        'If p_TICHKE_HUY = True Then
        '    U_ButtonCus1.Visible = True
        'End If

        If p_SMO = True Then
            Me.TrueDBGrid3.Height = 246
            Me.pTien.TabStop = True
            ' Me.sChuyen.TabStop = True
        Else
            Me.TrueDBGrid3.Height = 321
        End If


        If p_SOLENH_QR = True Then
            Me.SoLenh.Properties.MaxLength = 0
        End If

      
  

        If p_HONGXUAT = False Then
            Try
                Me.GridView2.Columns.Item(3).Visible = False
            Catch ex As Exception

            End Try

        End If
       

        If Not p_DataTblConfig Is Nothing Then
            If p_DataTblConfig.Rows.Count > 0 Then
                p_Scadar_Type = p_DataTblConfig.Rows(0).Item("optional").ToString.Trim
            End If
        End If


        If g_KV1 = True Or p_DIEMTRAHANG = True Then
            Me.DiemTraHang.FieldName = "DiemTraHang"
            Me.DiemTraHang.Visible = True
        End If


        If p_LAINGAY = True Then
            ' Me.Dem.Visible = True
            Me.LenhNgay.Visible = True
            Me.LenhNgay.Checked = True
            '  Me.Dem.FieldName = "Dem"
        End If



        Me.HNhomBeXuat.Width = 0
        If p_ThongTinNhomBe = False Then
            For p_int = 0 To Me.GridView2.Columns.Count - 1
                p_column = Me.GridView2.Columns.Item(p_int)
                If p_column.Name = "NhomBeXuat" Then
                    p_column.Visible = False
                    p_column.FieldView = ""
                End If

            Next
            ' NhomBeXuat.FieldView = ""
            For p_int = 0 To Me.GridView1.Columns.Count - 1
                p_column = Me.GridView1.Columns.Item(p_int)
                If p_column.Name = "NhomBeXuat" Then
                    p_column.Visible = False
                    p_column.FieldView = ""
                End If

            Next

            Me.HNhomBeXuat.FieldName = ""
        End If


        If p_HUYLENHXUAT = False Then
            Me.ToolStripButton10.Visible = False
        End If

        If p_MANGAN_SX = True Then
            Me.GridView2.OrderBy = "MaNgan"
        End If


        


        'Dim p_Count As Integer

        'For p_Count = 0 To Me.GridView1.Columns.Count - 1
        '    Me.GridView1.Columns.Item(p_Count).Tag = Me.GridView1.Columns.Item(p_Count).VisibleIndex

        'Next

        If g_SoLenh_Q = "" Then
            Me.SoLenh.EditValue = ""
            Me.g_FormAddnew = False
            Me.DefaultWhere = "SoLenh=''"
            Me.DefaultFormLoad = True
            Me.Form1_Load(sender, e)

            Me.Client.EditValue = g_Terminal
            ' Me.NgayXuat.EditValue = p_DateCreate
            'Me.BtnOk.Text = "Ok"

            Me.g_FormAddnew = True
            Me.NgayXuat.EditValue = p_Date_KV1


            Me.SoLenh.Focus()


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
                    'Me.NguoiVanChuyen.Properties.ReadOnly = True
                    If g_KV1 = True Then
                        Me.NguoiVanChuyen.Properties.ReadOnly = False
                    Else
                        Me.NguoiVanChuyen.Properties.ReadOnly = True
                    End If

                    GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                Else
                    '  Me.ToolStripButton4.Enabled = True
                    If UCase(Me.READ_ONLY) = "Y" Or UCase(READ_ONLY) = "TRUE" Then
                    Else
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
            Else
                ' Me.Client.Properties.ReadOnly = False
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
        Else
            ' Me.Client.Properties.ReadOnly = False
        End If


        If p_CURRENTDATE = True Then
            Me.NgayXuat.Enabled = False
        End If

        LoadNewRow()
        If g_Filter_Terminal = True Then



            p_column = Me.GridView1.Columns.Item("BeXuat")


            p_SQL = "select Name_nd as BeXuat from FPT_tblTankActive_V where Date1=:DateNgayXuat and Product_nd =:Column.MaHangHoa " & _
                  " and left(Name_nd,LEN ('" & g_Terminal & "')) like '" & g_Terminal & "%'  " & _
                    " and  (LoadingSite is null or LoadingSite ='' or upper(LoadingSite)=upper( :LoaiXuat ) ) "
            If p_ThongTinNhomBe = True Then
                'p_SQL = p_SQL & " and Name_nd in (select Name_nd from tblTankGroup  where getdate() >= isnull(FromDate,getdate() -1) and getdate() <= isnull(ToDate,getdate() +11) " & _
                '                " and TankGroup  = :HNhomBeXuat) "
                p_SQL = p_SQL & " and Name_nd in (select Name_nd from tblTankGroup  where getdate() >= isnull(FromDate,getdate() -1) and getdate() <= isnull(ToDate,getdate() +11) " & _
                                " and TankGroup  = :column.NhomBeXuat ) "
            End If
            p_column.SQLString = p_SQL


            'anhqh
            '20190808
            'Xử lý thêm yêu cầu cầu của KV2 về phê duyệt bể xuất mới lên tích kê
            Dim p_String As String
            Dim p_Table As DataTable

            p_SQL = "select * from sys_config where upper(KeyCode)='" & UCase("TANKAPPROVED") & "'"
            ' p_SQL = "select isnull( Tank_App,'N') as Tank_App  from SYS_USER  where upper(USER_NAME )=upper('" & g_UserName & "')"
            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    If p_Table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_TANKAPPROVED = True
                        p_column = Me.GridView1.Columns.Item("BeXuat")

                        p_SQL = "select Name_nd as BeXuat from FPT_tblTankActive_V where isnull(Tank_App,'N') ='Y' and Date1=:DateNgayXuat and Product_nd =:Column.MaHangHoa " & _
                              " and left(Name_nd,LEN ('" & g_Terminal & "')) like '" & g_Terminal & "%'  " & _
                                " and  (LoadingSite is null or LoadingSite ='' or upper(LoadingSite)=upper( :LoaiXuat ) ) "

                        If p_ThongTinNhomBe = True Then
                            p_SQL = p_SQL & " and Name_nd in (select Name_nd from tblTankGroup  where getdate() >= isnull(FromDate,getdate() -1) and getdate() <= isnull(ToDate,getdate() +11) " & _
                                            " and TankGroup  = :column.NhomBeXuat) "
                        End If

                        p_column.SQLString = p_SQL

                    End If
                End If
            End If




        End If


        If p_METERID_NGAN = True Then

            Me.GridView2.Columns.Item("MaLuuLuongKe").Visible = True
            p_column = Me.GridView2.Columns.Item("MaLuuLuongKe")
            p_SQL = "select MeterId  from tblMeter"
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
        If p_TICHKE_HUY = True Then
            Me.U_ButtonCus1.Visible = True
        Else
            If Me.U_ButtonCus1.Visible = True Then
                If p_Status.ToString.Trim <> "3" Then
                    Me.U_ButtonCus1.Visible = False
                End If
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


        p_SQL = "select * from SYS_USER where User_ID=" & IIf(g_User_ID.ToString.Trim = "", 0, g_User_ID)
        p_Datatable = GetDataTable(p_SQL, p_SQL)
        p_SQL = ""
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_SQL = p_Datatable.Rows(0).Item("HuyTichKe").ToString.Trim = "Y"
            End If
        End If

        If p_SQL <> "Y" Then
            U_ButtonCus1.Visible = False
        End If

        If g_KV1 = True Then
            p_SQL = "SELECT [MaPhuongTien], TuText as LoaiPhuongTien, SoNgan, LEFT(LaiXe,2) MaVanChuyen FROM fpt_tblPhuongTien_V where ( left([LaiXe],2)  = :MaVanChuyen or isnull( :MaVanChuyen ,'')='' )" & _
                    " and  CONVERT(date,getdate())>= CONVERT(date,ISNULL(NgayBatDau1,getdate())) 	and   CONVERT(date,getdate())<= CONVERT(date,ISNULL(NgayHieuLuc1,getdate())) "
            Me.MaPhuongTien.SqlString = p_SQL
            Me.MaPhuongTien.ItemReturn3 = "MaVanChuyen"
        End If

        ThongTinDiemTraHang()

        If p_SoChuyen = True And (p_Status = "" Or p_Status = "1" Or p_Status = "2") Then
            Me.aNumber.Properties.ReadOnly = False
        End If


        Me.NgayVaoKho.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss "
        NgayVaoKho.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss "
        NgayVaoKho.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        NgayVaoKho.Properties.EditMask = "dd/MM/yyyy HH:mm:ss "

        NgayVaoKho.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss "
        NgayVaoKho.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss "
        NgayVaoKho.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        NgayVaoKho.Properties.EditMask = "dd/MM/yyyy HH:mm:ss "

        NgayVaoKho.Properties.Mask.UseMaskAsDisplayFormat = True
        'Me.GridView1.Columns.Item("MaHangHoa").VisibleIndex = 2
        'Me.GridView1.Columns.Item("MeterId").VisibleIndex = Me.GridView1.Columns.Item("BeXuat").VisibleIndex - 1

        p_column = Me.GridView1.Columns.Item("BeXuat")

        Me.SoLenh.Focus()
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


        If CongTo_Bo() = True Then
            Exit Sub
        End If
        ' p_Column1 = Me.GridView1.Columns.Item("MeterId")
        If g_Filter_Terminal = True Then  'Rieng cho KV2  C1= kho A;  C2=Kho B; C3= Kho C

            If p_ThongTinNhomBe = True Then
                p_SQL = "select b.MeterId as  [Công tơ] , b.BeXuat,b.MaHangHoa, b.TankGroup as NhomBeXuat  from  tblCongToNhomBe b  where  getdate() >=  isnull(b.Valid_from ,getdate()-1)   and getdate() <=  isnull(b.Valid_to  ,getdate() + 1) " & _
                                "  and exists (select 1 from tbllenhxuate5 h with (nolock) where h.SoLenh  = :Column.SoLenh and h.NhomBeXuat  = b.TankGroup ) "

                p_SQL = p_SQL & " and b.MaHangHoa= :Column.MaHangHoa  and b.Bexuat in (select Name_nd from FPT_tblTankActive_V a11 where Date1=:DateNgayXuat and Product_nd =:Column.MaHangHoa " & _
                                            " and isnull(Tank_App,'N') ='Y'  and left(Name_nd,LEN ('" & g_Terminal & "')) like '" & g_Terminal & "%'  " & _
                                            " and  (LoadingSite is null or LoadingSite ='' or upper(LoadingSite)=upper( :LoaiXuat ) ) )"
                p_SQL = p_SQL & " and exists (select 1 from FPT_MeterAll a where LoadingSite= :LoaiXuat " & _
                                                        " and MeterId  = b.MeterId) "
                Select Case g_Terminal
                    Case "A"
                        p_SQL = p_SQL & "  and b.MeterId   like  'C1%'  "
                        p_Column1 = Me.GridView1.Columns.Item("MeterId")
                        p_Column1.SQLString = p_SQL
                        p_Column1.CFLReturn1 = "BeXuat"
                        p_Column1.CFLReturn3 = "NhomBeXuat"

                    Case "B"

                        p_SQL = p_SQL & "  and b.MeterId   like  'C2%'  "
                        p_Column1 = Me.GridView1.Columns.Item("MeterId")
                        p_Column1.SQLString = p_SQL
                        p_Column1.CFLReturn1 = "BeXuat"
                        p_Column1.CFLReturn3 = "NhomBeXuat"

                    Case "C"
                        p_SQL = p_SQL & "  and b.MeterId   like  'C3%'  "
                        p_Column1 = Me.GridView1.Columns.Item("MeterId")
                        p_Column1.SQLString = p_SQL
                        p_Column1.CFLReturn1 = "BeXuat"
                        p_Column1.CFLReturn3 = "NhomBeXuat"

                    Case Else
                        p_SQL = p_SQL & " and exists (select 1 from FPT_MeterAll a where LoadingSite=:LoaiXuat  and ProductCode=:Column.MaHangHoa " & _
                                                        " and MeterId   like  'C%' and MeterId  = b.MeterId) "
                        ' p_Column1 = Me.GridView1.Columns.Item("MeterId")
                        p_Column1.SQLString = p_SQL
                        p_Column1.CFLReturn1 = ""
                End Select
            Else

                Select Case g_Terminal
                    Case "A"

                        p_SQL = "select MeterId  as [Công tơ] , TankE5 as 'Bể xuất' from FPT_MeterAll a  where LoadingSite=:LoaiXuat  and ProductCode=:Column.MaHangHoa " & _
                                      " and MeterId   like  'C1%' "

                        p_Column1 = Me.GridView1.Columns.Item("MeterId")
                        p_Column1.SQLString = p_SQL
                        p_Column1.CFLReturn1 = ""

                    Case "B"

                        p_SQL = "select MeterId  as [Công tơ] , TankE5 as 'Bể xuất' from FPT_MeterAll a where LoadingSite=:LoaiXuat  and ProductCode=:Column.MaHangHoa " & _
                                      " and MeterId   like  'C2%' "
                        p_Column1 = Me.GridView1.Columns.Item("MeterId")
                        p_Column1.SQLString = p_SQL
                        p_Column1.CFLReturn1 = ""

                    Case "C"
                        p_SQL = "select MeterId  as [Công tơ] , TankE5 as 'Bể xuất' from FPT_MeterAll  where LoadingSite=:LoaiXuat  and ProductCode=:Column.MaHangHoa " & _
                                      " and MeterId   like  'C3%' "
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

            End If
            

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

            If p_KT_TAITRONG = False Then
                Exit Sub
            End If

            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_SQL = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            p_SQL = GetLoadingSite(p_SQL)
            If UCase(p_SQL) <> "BO" And UCase(p_SQL) <> "THUY" Then
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
        Dim p_PhuongTienSMO As String

        Dim p_DR_ZFM_CHECK_DO_CKG As DataRow

        If e.KeyCode = Keys.Enter Then
           

            p_Client = GetClient(p_MaVanChuyen)

            If KiemTraNgayThang() = False Then
                Exit Sub
            End If

            '  If g_KV1 = True Then
            If Not Me.NgayXuat.EditValue Is Nothing Then
                If Me.NgayXuat.EditValue.ToString.Trim <> "" Then
                    p_Date_KV1 = Me.NgayXuat.EditValue
                End If
            End If
            'End If
            If Not Me.SoLenh.EditValue Is Nothing Then

                If p_SOLENH_QR = True And Len(Not Me.SoLenh.EditValue.ToString.Trim) > 10 Then
                    GetSoLenh_QRCode(Me.SoLenh.EditValue.ToString.Trim)

                    Exit Sub
                End If




                'Me.GridView2.AllowInsert = False
                If Me.SoLenh.EditValue.ToString.Trim <> "" Then

                    Dim p_TableExe As DataTable
                    Dim g_LoaiHinhVanChuyen, p_MaPhuongTien As String
                    g_LoaiHinhVanChuyen = ""
                    p_MaPhuongTien = ""
                    Try
                        If Not Me.LoaiXuat.EditValue Is Nothing Then
                            g_LoaiHinhVanChuyen = UCase(Me.LoaiXuat.EditValue.ToString.Trim)
                        End If
                    Catch ex As Exception

                    End Try
                    Try
                        If Not Me.MaPhuongTien.EditValue Is Nothing Then
                            p_MaPhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
                        End If
                    Catch ex As Exception

                    End Try

                    If p_SMO_BO = False And p_SMO_THUY = False Then

                    Else

                        If CheckDO_Infor(Me.SoLenh.EditValue.ToString.Trim, g_LoaiHinhVanChuyen, p_SMO_BO, p_SMO_BO_R, _
                                         p_SMO_THUY, p_SMO_THUY_R, p_MaPhuongTien, p_TableExe, False, p_PhuongTienSMO) = False Then

                            Exit Sub
                        End If

                    End If

                    Cursor = Cursors.WaitCursor
                    p_Value = Me.SoLenh.EditValue.ToString.Trim

                    p_SQL = "select top 1 SoLenh from tblLenhXuatE5 with (Nolock) where SoLenh='" & p_Value & "'"
                    p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                    If Not p_DataTable Is Nothing Then
                        If p_DataTable.Rows.Count <= 0 Then

                            'If KiemTraSoLenhSapOff(p_Value) = True Then
                            '    Exit Sub
                            'End If

                            If p_KIEMKE_N30 = True Then
                                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(_SapConnectionString, "EN", 30, g_Company_Code, "", "")
                                If KiemTraThoiGianKiemKe_N30(p_ECCDestinationConfig, "T", Nothing, p_Value) = True Then
                                    Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If



                            If p_MatKetNoiSAP = True Then   'Neu mat ket noi SAP
                                If Mid(p_Value, 1, Len(g_WareHouse)) <> g_WareHouse Then  'Neu la lenh khong phai Lenh tao moi thi lay trong bang temp
                                    Dim p_THN_SAP_Object As New THN_SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

                                    p_SQL = ""
                                    p_THN_SAP_Object.clsGetLenhXuat(p_Value, p_Date_KV1, p_SQL)



                                    If p_SQL <> "" Then
                                        Cursor = Cursors.Default
                                        ShowMessageBox("", p_SQL)
                                        Exit Sub
                                    Else
                                        p_SQL = "FPT_UpdateDO '" & p_Value & "'"
                                        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                                        End If
                                        If g_KV1 = True Then
                                            Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                            Me.DefaultFormLoad = True
                                            Me.Form1_Load(sender, e)
                                            Me.SoLenh.Properties.ReadOnly = False
                                            Me.SoLenh.BackColor = pv_Required_Back_Color
                                            If KiemTraKhachHang_TuyenDuong(p_Value) = False Then
                                                ' Exit Sub
                                            End If
                                            GoTo Line_tt2
                                        Else

                                            Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                            Me.DefaultFormLoad = True
                                            Me.Form1_Load(sender, e)
                                            Me.SoLenh.Properties.ReadOnly = False
                                            Me.SoLenh.BackColor = pv_Required_Back_Color

                                            GoTo Line_tt2
                                        End If

                                    End If



                                    Exit Sub
                                End If
                            End If
                            ZFM_CHECK_DO_CKG(p_Value)
                            If g_WCF = False Then
                                Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
                                'If p_SAP_Object.clsCheckSAPConnection("", p_SQL) = False Then

                                If g_KV1 = True Then
                                    If p_SAP_Object.kv1clsSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_Value, p_SQL, p_Date_KV1, IIf(Me.LenhNgay.Checked = True, "Y", "N")) = False Then
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
                                        If KiemTraKhachHang_TuyenDuong(p_Value) = False Then
                                            ' Exit Sub
                                        End If
                                        GoTo Line_tt2
                                        ''MsgBox("bbb")
                                    End If
                                Else
                                    If p_SAP_Object.clsSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_Value, p_SQL, p_Date_KV1) = False Then
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
                                ''If g_Services.clsCheckSAPConnection("", p_SQL) = False Then
                                ''    MsgBox(p_SQL)
                                ''End If
                                'If g_KV1 = True Then
                                '    If g_Services.kv1clsSyncDeliveries_SynSpecific(p_Client, g_User_ID, g_Company_Code, p_Value, p_SQL, p_Date_KV1) = False Then
                                '        'If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                '        ' ShowMessageBox("", p_SQL)
                                '        ' Me.DefaultWhere = "SoLenh='00'"
                                '        'MsgBox("Error:" & p_SQL)
                                '        Cursor = Cursors.Default
                                '        ShowMessageBox("", p_SQL)
                                '        Exit Sub
                                '    Else
                                '        Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                '        Me.DefaultFormLoad = True
                                '        Me.Form1_Load(sender, e)
                                '        Me.SoLenh.Properties.ReadOnly = False
                                '        Me.SoLenh.BackColor = pv_Required_Back_Color

                                '        'p_PhuongTien = ""
                                '        'If Not Me.MaPhuongTien.EditValue Is Nothing Then
                                '        '    p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.ToString
                                '        'End If
                                '        'If p_PhuongTien <> "" Then
                                '        '    LoadDefault(p_PhuongTien)
                                '        'End If
                                '        GoTo Line_tt2
                                '    End If
                                'Else
                                '    If g_Services.mdlSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                '        'If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                '        ' ShowMessageBox("", p_SQL)
                                '        ' Me.DefaultWhere = "SoLenh='00'"
                                '        'MsgBox("Error:" & p_SQL)
                                '        Cursor = Cursors.Default
                                '        ShowMessageBox("", p_SQL)
                                '        Exit Sub
                                '    Else
                                '        Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                '        Me.DefaultFormLoad = True
                                '        Me.Form1_Load(sender, e)
                                '        Me.SoLenh.Properties.ReadOnly = False
                                '        Me.SoLenh.BackColor = pv_Required_Back_Color

                                '        'p_PhuongTien = ""
                                '        'If Not Me.MaPhuongTien.EditValue Is Nothing Then
                                '        '    p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.ToString
                                '        'End If
                                '        'If p_PhuongTien <> "" Then
                                '        '    LoadDefault(p_PhuongTien)
                                '        'End If
                                '        GoTo Line_tt2
                                '    End If
                                'End If
                                ''If g_Services.mdlSyncDeliveries_SynSpecific(p_Client, g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                ''    'If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_Value, p_SQL) = False Then
                                ''    ' ShowMessageBox("", p_SQL)
                                ''    ' Me.DefaultWhere = "SoLenh='00'"
                                ''    'MsgBox("Error:" & p_SQL)
                                ''    Cursor = Cursors.Default
                                ''    ShowMessageBox("", p_SQL)
                                ''    Exit Sub
                                ''Else
                                ''    Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                ''    Me.DefaultFormLoad = True
                                ''    Me.Form1_Load(sender, e)
                                ''    Me.SoLenh.Properties.ReadOnly = False
                                ''    Me.SoLenh.BackColor = pv_Required_Back_Color

                                ''    'p_PhuongTien = ""
                                ''    'If Not Me.MaPhuongTien.EditValue Is Nothing Then
                                ''    '    p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.ToString
                                ''    'End If
                                ''    'If p_PhuongTien <> "" Then
                                ''    '    LoadDefault(p_PhuongTien)
                                ''    'End If
                                ''    GoTo Line_tt2
                                ''End If
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

                    If g_Company_Code = "6610" Then
                        If Me.Status.EditValue.ToString.Trim = "1" Or Me.Status.EditValue.ToString.Trim = "2" Or Me.Status.EditValue.ToString.Trim = "" Then
                            ZFM_CHECK_DO_CKG(p_Value)
                        End If
                    End If

                    ' LoadNewRow()
                    Me.MaPhuongTien.UpdateWhenFormLock = False

                    If Not Me.Status.EditValue Is Nothing Then
                        If InStr(",3,31,4,5,", "," & Me.Status.EditValue.ToString.Trim & ",", CompareMethod.Text) > 0 Then

                            Me.ToolStripButton4.Enabled = p_InLaiTichKe
                            If g_KV1 = True And Me.Status.EditValue.ToString.Trim = 3 Then
                                Me.FormEdit = True
                            Else
                                Me.FormEdit = False
                            End If

                            Me.GridView2.OptionsBehavior.ReadOnly = True
                            Me.GridView1.OptionsBehavior.ReadOnly = True
                            Me.MaVanChuyen.Properties.ReadOnly = True
                            ' Me.NguoiVanChuyen.Properties.ReadOnly = True
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
                            GridView1.Columns.Item("MeterId").OptionsColumn.ReadOnly = False
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

                    If Not Me.Status.EditValue Is Nothing Then
                        If InStr(",3,31,4,5,", "," & Me.Status.EditValue.ToString.Trim & ",", CompareMethod.Text) > 0 Then
                            GoTo Line_TT22
                        End If
                    End If

                    If p_PhuongTienSMO <> "" Then
                        p_SQL = "Update tblLenhXuatE5 set MaPhuongTien ='" & p_PhuongTienSMO & "' where SoLenh ='" & p_Value & "'"
                        If g_Services.Sys_Execute(p_SQL, _
                                         p_SQL) = False Then
                            ShowMessageBox("", p_SQL)
                        End If


                        Me.MaPhuongTien.EditValue = p_PhuongTienSMO
                    End If
                    If Not p_TableExe Is Nothing Then
                        If p_TableExe.Rows.Count > 0 Then
                            p_SQL = p_TableExe.Rows(0).Item(0).ToString.Trim
                            If g_Services.Sys_Execute(p_SQL, _
                                             p_SQL) = False Then
                                ShowMessageBox("", p_SQL)
                            End If
                        End If
                    End If
Line_TT22:
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
                If p_TICHKE_HUY = False Then
                    If p_Status.ToString.Trim <> "3" Then

                        Me.U_ButtonCus1.Visible = False
                    End If
                End If

            End If

            '  Setfocus("SOLENH")

            ThongTinDiemTraHang()

            Me.FormStatus = False
            If p_SHOW_CLIENT = "0" Then
                Me.Client.Properties.ReadOnly = True
            End If
            Me.aNumber.Properties.ReadOnly = True
            If p_SoChuyen = True And (p_Status = "" Or p_Status = "1" Or p_Status = "2") Then
                Me.aNumber.Properties.ReadOnly = False
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

        Dim p_Datatable1 As DataTable

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


                        p_SQL = "select Row_ID  from FPT_tblLenhXuatChiTietE5_v  a where  Row_ID=" & p_DataRow.Item("Row_id").ToString.Trim & _
                                    " and exists (select 1 from tblLenhXuatE5 b with (nolock) where SoLenh=a.solenh and Status in ('3','31','4','5')) "
                        p_Datatable1 = GetDataTable(p_SQL, p_SQL)
                        If Not p_Datatable1 Is Nothing Then
                            If p_Datatable1.Rows.Count > 0 Then
                                Cursor = Cursors.Default
                                ShowMessageBox("", "Lệnh xuất có trạng thái không hợp lệ")
                                Exit Sub
                            End If
                        End If



                        p_SQL = p_DataRow.Item("Row_id").ToString.Trim


                        'p_SQL = "exec FPT_TRangThaiSoLenhGhep '" & p_SoLenh_Line & "'"
                        'p_Datatable1 = GetDataTable(p_SQL, p_SQL)
                        'If Not p_Datatable1 Is Nothing Then
                        '    For p_Count = 0 To p_Datatable1.Rows.Count - 1
                        '        If p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim = "3" Or p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim = "31" _
                        '                Or p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim = "4" Or p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim = "5" Then
                        '            ShowMessageBox("", "Lệnh " & p_Datatable1.Rows(p_Count).Item("SoLenh").ToString.Trim & " trạng thái không hợp lệ (" & p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim & ") ")
                        '            Exit Sub
                        '        End If
                        '    Next
                        'End If



                        p_SQL = "Delete from tblLenhXuatChiTietE5 where  Row_id=" & p_SQL
                        p_DataRow = Me.pv_LineRemove.NewRow
                        p_DataRow.Item(0) = p_SQL

                        p_DataRow.Item(1) = "tblLenhXuatChiTietE5"


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
            p_TableLine.AcceptChanges()
            p_Binding.DataSource = p_TableLine
            Me.TrueDBGrid2.DataSource = p_Binding
            'GridView2.RefreshData()
            GridView2.OptionsBehavior.Editable = True

            Me.FormStatus = True
            Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
            GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom

            GridView2.MoveLast()

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

            Dim p_TableNguon As DataTable
            Try
                p_DataTableOld.Columns.Add("MaNguon")
            Catch ex As Exception

            End Try
            p_SQL = "select SoLenh,MaNguon from tblLenhXuatE5 with (nolock) where charindex(SoLenh,'" & p_SoLenh & "',1) >0"
            p_TableNguon = GetDataTable(p_SQL, p_SQL)
            For p_Count = 0 To p_DataTableOld.Rows.Count - 1
                p_ArrRow = p_TableNguon.Select("SoLenh ='" & p_DataTableOld.Rows(p_Count).Item("SoLenh") & "'")
                If p_ArrRow.Length > 0 Then
                    p_DataTableOld.Rows(p_Count).Item("MaNguon") = p_ArrRow(0).Item("MaNguon").ToString.Trim

                End If
            Next

            p_BindingOld.DataSource = p_DataTableOld
            Me.TrueDBGrid3.DataSource = p_BindingOld
            TrueDBGrid3.RefreshDataSource()
            'Me.GridView3.Columns.Item(0).FieldName = "SoLenh"
            'Me.GridView3.Columns.Item(1).FieldName = "NgayXuat"
            'Me.GridView3.Columns.Item(2).FieldName = "MaPhuongTien"
            'Me.GridView3.Columns.Item(3).FieldName = "TenKhachHang"  ''
            'Me.GridView3.Columns.Item(4).FieldName = "NguoiVanChuyen"  ''

            'Me.GridView3.Columns.Item(5).FieldName = "MaNgan"
            'Me.GridView3.Columns.Item(6).FieldName = "SoLuongDuXuat"
            'Me.GridView3.Columns.Item(7).FieldName = "Status"

            Me.GridView3.Columns.Item(0).FieldName = "SoLenh"
            Me.GridView3.Columns.Item(1).FieldName = "MaNguon" '"NgayXuat"
            Me.GridView3.Columns.Item(2).FieldName = "MaPhuongTien"
            Me.GridView3.Columns.Item(2).VisibleIndex = -1
            Me.GridView3.Columns.Item(3).FieldName = "TenKhachHang"  ''
            Me.GridView3.Columns.Item(4).FieldName = "NguoiVanChuyen"  ''

            Me.GridView3.Columns.Item(5).FieldName = "MaNgan"
            Me.GridView3.Columns.Item(5).VisibleIndex = -1
            Me.GridView3.Columns.Item(6).FieldName = "SoLuongDuXuat"
            Me.GridView3.Columns.Item(7).FieldName = "Status"
            Me.GridView3.Columns.Item(7).VisibleIndex = -1

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
        Dim p_PtienGhep As String = ""
        Dim p_LenhGhep As Boolean

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


            p_LenhGhep = False

            If p_DataTable.Rows.Count = 1 Then
                Try
                    p_DataTable.Rows(0).Item("MaPhuongTien") = p_Ptien
                Catch ex As Exception

                End Try

            ElseIf p_DataTable.Rows.Count > 0 Then
                p_PtienGhep = p_DataTable.Rows(0).Item("MaPhuongTien").ToString.Trim

                For p_Count = 0 To p_DataTable.Rows.Count - 1

                    If p_DataTable.Rows(p_Count).Item("MaPhuongTien").ToString.Trim <> "" And KiemTraPhuongTienAo(p_DataTable.Rows(p_Count).Item("MaPhuongTien").ToString.Trim) = False Then
                        If p_PtienGhep <> p_DataTable.Rows(p_Count).Item("MaPhuongTien").ToString.Trim Then
                            p_LenhGhep = True
                        End If
                    End If
                Next


            End If
            If p_LenhGhep = True Then
                For p_Count = 0 To p_DataTable.Rows.Count - 1

                    If p_DataTable.Rows(p_Count).Item("MaPhuongTien").ToString.Trim <> "" And KiemTraPhuongTienAo(p_DataTable.Rows(p_Count).Item("MaPhuongTien").ToString.Trim) = False Then
                        If p_Ptien <> p_DataTable.Rows(p_Count).Item("MaPhuongTien").ToString.Trim Then
                            KiemtraKhacPTien = False
                            ShowMessageBox("", "Lệnh ghép phải cùng Mã phương tiện")
                            Exit Function
                        End If
                    End If
                Next
            End If

        Catch ex As Exception
            KiemtraKhacPTien = False
        End Try
    End Function



    Private Sub GopTichKe(Optional ByVal SaveGhep As Boolean = False, Optional ByVal p_HuyTichKe As Boolean = False)
        Dim p_DataTable As DataTable
        Dim p_DataTableCheck As DataTable
        Dim p_BindingCheck As New U_TextBox.U_BindingSource
        Dim p_CountCheck As Integer
        Dim p_DataTable_Del As DataTable
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

        Dim p_Count22 As Integer


        Dim p_Desc As String
        Dim p_Tmp As Decimal

        'anhqh
        '20180305
        'Them cot lau Row_ID de xoa nhung ngan thua di
        Dim p_RowDataDel As DataRow
        Dim p_DataTableDel As New DataTable("Table001")
        p_DataTableDel.Columns.Add("Row_ID")
        p_DataTableDel.Columns.Add("SoLenh")

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

                        'anhqh
                        '20180305
                        'Doan kiem tra neu da co ma ngan roi thi khong insert them vao nua
                        If UCase(p_DataTable.Columns.Item(p_Count1).ColumnName.ToString) = "MANGAN" Then
                            ' MsgBox("sdfsd")
                            p_ArrRow = p_DataTableOld.Select("MaNgan ='" & p_DataTable.Rows(p_Count).Item(p_DataTableOld.Columns.Item(p_Count1).ColumnName.ToString).ToString.Trim & "'")
                            If p_ArrRow.Length > 0 Then

                                For p_Count22 = p_DataTableOld.Rows.Count - 1 To 0 Step -1
                                    If p_DataTableOld.Rows(p_Count22).Item("MaNgan").ToString.Trim = p_DataTable.Rows(p_Count).Item("MaNgan").ToString.Trim Then
                                        p_RowDataDel = p_DataTableDel.NewRow
                                        p_RowDataDel.Item(0) = p_DataTableOld.Rows(p_Count22).Item("Row_ID").ToString.Trim
                                        p_RowDataDel.Item(1) = p_DataTableOld.Rows(p_Count22).Item("SoLenh").ToString.Trim
                                        p_DataTableDel.Rows.Add(p_RowDataDel)

                                        'anhqh
                                        '20190222
                                        'thu khong xoa nhung ban ghi co cung ngan xem ntn
                                        'DungNV test bi loi thi co 4 lenh trong do co 2 lenh xuat cung luong la 5000L va httg dang xep vao cung ngan 001
                                        'p_DataTableOld.Rows.RemoveAt(p_Count22)

                                        ' p_DataTableOld.AcceptChanges()
                                        Exit For
                                    End If
                                Next

                                ' GoTo LIne_Out
                            End If
                        End If


                        ' Decimal.TryParse(p_DataTable.Rows(p_Count).Item(p_DataTableOld.Columns.Item(p_Count1).ColumnName.ToString).ToString.Trim, p_Tmp)
                        If p_DataTable.Rows(p_Count).Item(p_DataTableOld.Columns.Item(p_Count1).ColumnName.ToString).ToString.Trim <> "" Then

                            p_RowData.Item(p_DataTableOld.Columns.Item(p_Count1).ColumnName.ToString) = p_DataTable.Rows(p_Count).Item(p_DataTableOld.Columns.Item(p_Count1).ColumnName.ToString).ToString.Trim
                        End If
                        'If
                    End If
                    ' p_RowData.Item(p_Count1) = p_DataTable.Rows(p_Count).Item(p_Count1).ToString.Trim
                Next
                p_DataTableOld.Rows.Add(p_RowData)
                p_DataTableOld.AcceptChanges()
LIne_Out:
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


                'anhqh
                '20180305
                'Them doan lay lenh xuat cho cac ngăn da xoa
                For p_Count = 0 To p_DataTableDel.Rows.Count - 1
                    '  If p_SoLenhGhep <> p_DataTableOld.Rows(p_Count).Item("SoLenh").ToString.Trim Then
                    p_SoLenhGhep = p_SoLenhGhep & "," & p_DataTableDel.Rows(p_Count).Item("SoLenh").ToString.Trim
                    '  End If
                Next


                ' /p_RowDataDel

                'anhqh  20190222
                ' them doan xu ly neu trong danh sach lenh khong co so lenh nao trong GridView1 thi add them
                '    dfd()
                'Try
                '    p_BindingCheck = Me.TrueDBGrid1.DataSource
                '    p_DataTableCheck = CType(p_BindingCheck.DataSource, DataTable)
                '    If Not p_DataTableCheck Is Nothing Then
                '        For p_CountCheck = 0 To p_DataTableCheck.Rows.Count - 1
                '            If p_DataTableCheck.Rows(p_CountCheck).Item("SoLenh").ToString.Trim <> "" Then
                '                If InStr(p_SoLenhGhep, p_DataTableCheck.Rows(p_CountCheck).Item("SoLenh").ToString.Trim, CompareMethod.Text) <= 0 Then
                '                    p_SoLenhGhep = p_SoLenhGhep & "," & p_DataTableCheck.Rows(p_CountCheck).Item("SoLenh").ToString.Trim
                '                End If
                '            End If
                '        Next

                '    End If
                'Catch ex As Exception

                'End Try

                If p_SoLenhGhep <> "" Then

                    'Try
                    '    p_SoLenhGhep = p_SoLenhGhep & "," & p_SoLenh
                    'Catch ex As Exception

                    'End Try



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



                    'anhqh
                    '20180305
                    '20180328  --tam bo di vi khi luu da xoa ngan roi
                    'Xoa nhung Ngan trung nhau
                    'For p_Count22 = 0 To p_DataTableDel.Rows.Count - 1
                    '    p_SQL = "exec FPT_XoaNganTrungNhau " & p_DataTableDel.Rows(p_Count22).Item(0)
                    '    p_DataTable_Del = GetDataTable(p_SQL, p_SQL)
                    'Next
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

        If p_LenhGhep = True Then
            p_SoLenh = p_SoLenhGhep

        End If

        Dim p_TableNguon As DataTable
        ' Dim p_RowData
        Try
            p_DataTableOld.Columns.Add("MaNguon")
        Catch ex As Exception

        End Try

        Try
            p_DataTableOld.Columns.Add("SCreateDate")
        Catch ex As Exception

        End Try

        p_SQL = "select CreateDate, SoLenh,MaNguon from tblLenhXuatE5 with (nolock) where charindex(SoLenh,'" & p_SoLenh & "',1) >0"
        p_TableNguon = GetDataTable(p_SQL, p_SQL)
        For p_Count = 0 To p_DataTableOld.Rows.Count - 1
            p_ArrRow = p_TableNguon.Select("SoLenh ='" & p_DataTableOld.Rows(p_Count).Item("SoLenh") & "'")
            If p_ArrRow.Length > 0 Then
                p_DataTableOld.Rows(p_Count).Item("MaNguon") = p_ArrRow(0).Item("MaNguon").ToString.Trim
                Try
                    p_DataTableOld.Rows(p_Count).Item("SCreateDate") = p_DataTableOld.Rows(p_Count).Item("SoLenh") & " - " & CDate(p_ArrRow(0).Item("CreateDate")).ToString("dd/MM/yyyy HH:mm:ss")
                Catch ex As Exception

                End Try

            End If
        Next
        p_BindingOld.DataSource = p_DataTableOld
        Me.TrueDBGrid3.DataSource = p_BindingOld
        'TrueDBGrid3.RefreshDataSource()
        Me.GridView3.Columns.Item(0).FieldName = "SoLenh"
        Me.GridView3.Columns.Item(1).FieldName = "MaNguon" '"NgayXuat"
        Me.GridView3.Columns.Item(2).FieldName = "MaPhuongTien"
        Me.GridView3.Columns.Item(2).VisibleIndex = -1
        Me.GridView3.Columns.Item(3).FieldName = "TenKhachHang"  ''
        Me.GridView3.Columns.Item(4).FieldName = "SCreateDate"  ''
        Me.GridView3.Columns.Item(4).Caption = "Thông tin lệnh xuất"
        Me.GridView3.Columns.Item(4).Visible = True
        Me.GridView3.Columns.Item(5).FieldName = "MaNgan"
        Me.GridView3.Columns.Item(5).VisibleIndex = -1
        Me.GridView3.Columns.Item(6).FieldName = "TongDuXuat"   ' "SoLuongDuXuat"
        Me.GridView3.Columns.Item(7).FieldName = "Status"
        Me.GridView3.Columns.Item(7).VisibleIndex = -1
        Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False

        Me.GridView3.OptionsBehavior.ReadOnly = True
        Me.GridView3.Columns.Item(0).VisibleIndex = -1
        Me.GridView3.Columns(4).Group()
        Me.GridView3.ExpandAllGroups()
        GridView3.BestFitColumns()

        Me.GridView1.BestFitColumns()
        Me.GridView1.Columns.Item("TableID").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        GepNganTrong()

        Me.GridView3.ExpandAllGroups()
        GridView3.BestFitColumns()

        If p_LenhGhep = True Then

            If p_CURRENTDATE = True Then
                If KiemTraNgayXuatHang(p_SoLenh, p_Desc) = False Then
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
                    Exit Sub
                End If
            End If



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
            GetTaiTrongKG(p_NhietDoNgay, False)   'Tinh tai trong phuong tien
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

        Dim p_NgayBatDau1 As Date
        Dim p_Date As Date
        Dim p_DateHT As Date
        Dim p_Time As Integer
        Dim p_TableID As String = ""

        Dim p_DungTichNgan As Double
        Dim p_DuXuat As Double
        Dim p_LoaiXuat As String = ""

        Dim p_DateLX As Date
        Dim p_TableIDTmp As String
        Dim p_TenLaiXe As String = ""

        Dim p_Count123 As Integer
        Dim p_Row123 As DataRow

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
            ' Me.GridView2.RefreshData()
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
                If p_LENHNGAY = True Then  ''Kiem tra ma lenh xuat theo ngay va ngay in tich ke
                    p_DateLX = Nothing
                    If Not Me.NgayXuat.EditValue Is Nothing Then
                        Try
                            p_DateLX = Me.NgayXuat.EditValue
                            If p_DateLX.ToString.Trim <> "" Then
                                If CDate(p_HDataTable.Rows(p_Count).Item("NgayXuat").ToString.Trim) <> CDate(p_DateLX) Then
                                    ShowMessageBox("", "Ngày xuất hàng của lệnh xuất: " & CDate(p_HDataTable.Rows(p_Count).Item("NgayXuat").ToString.Trim).ToString("dd/MM/yyyy") & _
                                                    "  Ngày in tích kê  " & p_DateLX.ToString("dd/MM/yyyy"), 3)
                                    KiemTraThongTin = True
                                    Exit Function
                                End If
                                'p_TableIDTmp = p_DateLX.ToString("MMdd")

                                'p_TableID = p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim
                                'If p_TableID <> "" Then
                                '    If p_TableIDTmp = Mid(p_TableID, 1, Len(p_TableIDTmp)) Then

                                '    End If
                                'End If
                            End If
                        Catch ex As Exception

                        End Try


                    End If
                End If
                If p_CONGTO_KiemTra = True Then
                    If p_HDataTable.Rows(p_Count).Item("MeterId").ToString.Trim = "" Then
                        'ShowStatusMessage(True, "MS0051", "Chưa tính QCI", 10)
                        ShowMessageBox("", "Công tơ chưa nhập", 3)
                        KiemTraThongTin = True
                        Exit Function
                    End If
                End If

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
                        If p_DATNGAN_THUCONG = False Then
                            ShowMessageBox("", "Mã lệnh " & p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim & " Tổng dự xuất không đúng")
                            KiemTraThongTin = True
                            Exit Function

                        Else

                            p_ValueMess = g_Module.ShowMessage(Me, "", _
                                                    "Mã lệnh " & p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim & " Tổng dự xuất không đúng" & _
                                                            vbCrLf & "Bạn có muốn thực hiện tiếp không?", _
                                                    True, _
                                                     "Có", _
                                                    True, _
                                                    "Không", _
                                                    False, _
                                                    "", _
                                                     0)
                            If p_ValueMess = Windows.Forms.DialogResult.Yes Then
                                For p_Count123 = 0 To Me.GridView1.RowCount - 1
                                    p_Row123 = Me.GridView1.GetDataRow(p_Count123)
                                    If Not p_Row123 Is Nothing Then
                                        If p_Row123.Item("LineID").ToString.Trim = p_HDataTable.Rows(p_Count).Item("LineID").ToString.Trim _
                                            And p_Row123.Item("TableID").ToString.Trim = p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim _
                                            And p_Row123.Item("SoLenh").ToString.Trim = p_HDataTable.Rows(p_Count).Item("SoLenh").ToString.Trim Then
                                            Me.GridView1.SetRowCellValue(p_Count123, "TongXuat", p_LDuXuat)
                                        End If
                                    End If
                                Next

                            Else
                                KiemTraThongTin = True
                                Exit Function
                            End If

                        End If

                    Else
                        If p_HDuXuat < p_LDuXuat Then
                            If p_THUY_QUA_BAREM = False Then
                                ShowMessageBox("", "Mã lệnh " & p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim & " Tổng dự xuất không đúng")
                                KiemTraThongTin = True
                                Exit Function
                            Else
                                If p_LDuXuat > p_DungTichNgan Then
                                    ShowMessageBox("", "Mã lệnh " & p_HDataTable.Rows(p_Count).Item("TableID").ToString.Trim & " Dự xuất quá dung tích ngăn")
                                    KiemTraThongTin = True
                                    Exit Function
                                End If
                            End If

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
                If p_KT_CONGTO_THUY = True Then
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
                            p_NgayBatDau1 = IIf(p_HDataTable.Rows(0).Item("NgayBatDau1").ToString.Trim = "", DateAdd("d", -10, Now.Date), p_HDataTable.Rows(0).Item("NgayBatDau1").ToString.Trim)
                            p_GetDateTime(p_DateHT, p_Time)
                            If p_DateHT > p_Date Or p_DateHT < p_NgayBatDau1 Then
                                'ShowMessageBox("", "Mã ngăn " & p_HDataTable.Rows(p_LCount).Item("MaNgan").ToString.Trim & " Tổng số dự xuất không đúng với dung tích ngăn")
                                ShowMessageBox("PT01", "Phương tiện đã hết hạn kiểm định", 3)
                                If p_PT_THONGBAO = False Then
                                    KiemTraThongTin = True
                                    Exit Function
                                End If

                            End If

                            ' gfsgss()
                            If p_PT_HANKIEMDINH > 0 And p_Date >= p_DateHT Then
                                If DateAdd("d", p_PT_HANKIEMDINH, p_DateHT.Date) >= p_Date Then
                                    'ShowStatusMessage(False, "PT01", "Phương tiện sắp hết hạn kiểm định", 5)
                                    ShowMessageBox("", "Phương tiện sắp hết hạn kiểm định", 3)
                                End If
                                'If DateAdd("d", 5, p_DateHT.Date) >= p_Date Then
                                '    'ShowStatusMessage(False, "PT01", "Phương tiện sắp hết hạn kiểm định", 5)
                                '    ShowMessageBox("PT01", "Phương tiện sắp hết hạn kiểm định", 3)
                                'End If
                            End If


                        End If
                    End If
                    If (UCase(p_LoaiXuat) = "BO" Or UCase(p_LoaiXuat) = "THUY") And g_TAITRONGKG = True Then  'Chi cho xuat Bo
                        If p_KT_TAITRONG = True Then
                            If KiemTraPhuongTienQuaTai(p_SoLenh, p_MaPhuongTien) = True Then
                                KiemTraThongTin = True
                                Exit Function
                            End If
                        End If


                    End If
                End If
            End If
            'Kiem tra các giấy tờ theo lái xe trước thời điểm hết hạn
            If p_LX_GIAYTO > 0 Then
                If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
                    p_TenLaiXe = Me.NguoiVanChuyen.EditValue.ToString.Trim
                End If
                If p_TenLaiXe <> "" Then
                    p_SQL = "select NoiDung from tblPhuongTien_LaiXe where MaPhuongTien ='" & p_MaPhuongTien & "' and upper(HoVaTen) =N'" & UCase(p_TenLaiXe) & "'" & _
                        " and    CONVERT (date, DATEADD (DAY," & p_LX_GIAYTO & ",getdate()))    >=  CONVERT (date, isnull(toDate,GETDATE()+50)) "
                    p_SQL = p_SQL & "Union all select NoiDung from tblPhuongTien_Infor where MaPhuongTien ='" & p_MaPhuongTien & "' " & _
                        " and    CONVERT (date, DATEADD (DAY," & p_LX_GIAYTO & ",getdate()))    >=  CONVERT (date, isnull(toDate,GETDATE()+50)) "
                    p_HDataTable = GetDataTable(p_SQL, p_SQL)
                    If Not p_HDataTable Is Nothing Then
                        For p_Count = 0 To p_HDataTable.Rows.Count - 1
                            ShowMessageBox("", p_HDataTable.Rows(p_Count).Item("NoiDung").ToString.Trim & " sắp hết hạn", 3)
                        Next
                    End If
                End If

            End If
        Catch ex As Exception
            ShowMessageBox("", ex.Message)
            KiemTraThongTin = True
        End Try

    End Function



    Sub SaveRecode()
        Dim p_DataRow As DataRow
        ' Dim p_mahanghoa As String
        Dim p_Datatable As DataTable
        Dim p_Datatable1 As DataTable
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
        Dim p_Error As Boolean
        Dim p_Client As String = ""


        Dim p_TableRemove As DataTable
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If p_SoLenh = "" Then
            ShowMessageBox(True, "Số lệnh xuất chưa nhập", 3)
            Me.SoLenh.Focus()
            Exit Sub
        End If


        If KiemTraTrangThaiLenhKhiXoaNgan() = False Then
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
        'If Not Me.Client.EditValue Is Nothing Then
        '    p_Client = Me.Client.EditValue.ToString.Trim

        'End If
        'If p_Client = "" Then
        '    If g_KV1 = False Then
        '        Me.Client.EditValue = g_Terminal
        '    End If
        'End If
        If KiemTraThongTin(p_SoLenh) = True Then
            Exit Sub
        End If


        p_Date = Me.NgayXuat.EditValue

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If KiemTraKhiLuuLenh(p_SoLenh, p_Status) = False Then
            Exit Sub
        End If


        If KiemTraLineID_TableID() = False Then
            Exit Sub
        End If



        'Me.LoaiPhieu.EditValue = g_LoaiPhieu
        Try

            If p_Status = "31" Or p_Status = "4" Or p_Status = "5" Or p_Status = "3" Then    'Sua loi cua KV1 khi sua TenLaixe sau khi hay bi xoa ngan

                pv_LineRemove.Clear()

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

                        If p_CONGTO_KiemTra = True Then
                            If p_DataRow.Item("MeterId").ToString.Trim = "" Then
                                'ShowStatusMessage(True, "MS0051", "Chưa tính QCI", 10)
                                ShowMessageBox("", "Công tơ chưa nhập", 3)
                                Exit Sub
                            End If
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

            If p_LenhGhep = True Then
                p_SQL = "exec FPT_TRangThaiSoLenhGhep '" & p_SoLenh_Line & "'"
                p_Datatable1 = GetDataTable(p_SQL, p_SQL)
                If Not p_Datatable1 Is Nothing Then
                    For p_Count = 0 To p_Datatable1.Rows.Count - 1
                        If p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim = "3" Or p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim = "31" _
                                Or p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim = "4" Or p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim = "5" Then
                            ShowMessageBox("", "Lệnh " & p_Datatable1.Rows(p_Count).Item("SoLenh").ToString.Trim & " trạng thái không hợp lệ (" & p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim & ") ")
                            Exit Sub
                        End If
                    Next
                End If

                If KiemTraKhiLuuLenh(p_SoLenh_Line, p_Status) = False Then
                    Exit Sub
                End If

                ''Kiem tra lệnh ghép , nếu tách ngăn mà khác nhóm thì không cho tách ngăn
                If p_ThongTinNhomBe = True Then
                    Me.GridView2.MoveNext()
                    Dim p_Source1, p_Source2 As U_TextBox.U_BindingSource
                    Dim p_Table1, p_Table2 As DataTable
                    Dim p_Arrrow(), p_Arrrow1() As DataRow
                    Dim p_Int As Integer
                    Dim p_DuXuat As Double
                    Dim p_NhomBe As String = ""
                    p_Source1 = Me.TrueDBGrid1.DataSource
                    p_Source2 = Me.TrueDBGrid2.DataSource
                    p_Table1 = CType(p_Source1.DataSource, DataTable)
                    p_Table2 = CType(p_Source2.DataSource, DataTable)
                    p_NhomBe = ""
                    For p_Count = 0 To p_Table2.Rows.Count - 1
                        Double.TryParse(p_Table2.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim, p_DuXuat)
                        If p_DuXuat > 0 Then
                            p_Arrrow = p_Table2.Select("MaNgan='" & p_Table2.Rows(p_Count).Item("MaNgan").ToString.Trim & "'")

                            If p_Arrrow.Length > 1 Then  '
                                p_NhomBe = ""
                                For p_Int = 0 To p_Arrrow.Length - 1
                                    If p_Arrrow(p_Int).Item("TableID").ToString.Trim = "" Then
                                        Continue For
                                    End If
                                    p_Arrrow1 = p_Table1.Select("TableID = '" & p_Arrrow(p_Int).Item("TableID").ToString.Trim & "'")
                                    If p_Arrrow1.Length > 0 Then
                                        If p_NhomBe = "" Then
                                            p_NhomBe = p_Arrrow1(0).Item("NhomBeXuat").ToString
                                            Continue For
                                        End If
                                    End If

                                    If p_NhomBe <> p_Arrrow1(0).Item("NhomBeXuat").ToString Then
                                        ShowMessageBox("", "Ngăn " & p_Arrrow(0).Item("MaNgan").ToString.Trim & " không có cùng nhóm bể")
                                        Exit Sub
                                    End If
                                Next



                            End If
                        End If

                    Next

                End If
            End If


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

                        ''Xoa line
                        'If p_DataRow.Item("Row_ID").ToString.Trim <> "" Then

                        '    'p_SQL = "delete from tblLenhXuatChiTietE5 where Row_ID=" & p_DataRow.Item("Row_ID").ToString.Trim
                        '    p_SQL = "delete from tblLenhXuatChiTietE5 where Row_ID=" & p_DataRow.Item("Row_ID").ToString.Trim & _
                        '         " and  exists ( select 1 from fpt_tbllenhxuatchitiete5_v hh, tbllenhxuate5 hh1 with (nolock)  where Row_ID=" & p_DataRow.Item("Row_ID").ToString.Trim & _
                        '            " and hh.solenh=hh1.solenh  and hh1.Status in ( '1','2','')  and tblLenhXuatChiTietE5.Row_ID =hh.Row_ID) "
                        '    p_DataRow = Me.pv_LineRemove.NewRow
                        '    p_DataRow.Item(0) = p_SQL
                        '    Try
                        '        p_DataRow.Item("TableName") = "tblLenhXuatChiTietE5"
                        '    Catch ex As Exception

                        '    End Try
                        '    Me.pv_LineRemove.Rows.Add(p_DataRow)

                        'Else        ' anhqh 20180316  them doan xu ly khi khong co rowid =null
                        '    p_SQL = "delete from tblLenhXuatChiTietE5 where " & _
                        '         " TableID='" & p_DataRow.Item("TableID").ToString.Trim & "'" & _
                        '         " and NgayXuat ='" & CDate(p_DataRow.Item("NgayXuat")).ToString("MM-dd-yyyy") & "' " & _
                        '         " and  MaNgan='" & p_DataRow.Item("MaNgan").ToString.Trim & "' " & _
                        '         " and  exists ( select 1 from fpt_tbllenhxuatchitiete5_v hh, tbllenhxuate5 hh1 with (nolock)  where  " & _
                        '             " hh.solenh=hh1.solenh  and hh1.Status in ( '1','2','')  and tblLenhXuatChiTietE5.Row_ID =hh.Row_ID " & _
                        '              " and hh1.ngayxuat =tblLenhXuatChiTietE5.ngayxuat ) "
                        '    p_DataRow = Me.pv_LineRemove.NewRow
                        '    p_DataRow.Item(0) = p_SQL
                        '    Try
                        '        p_DataRow.Item("TableName") = "tblLenhXuatChiTietE5"
                        '    Catch ex As Exception

                        '    End Try
                        '    Me.pv_LineRemove.Rows.Add(p_DataRow)
                        'End If

                        'else 
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

            If KiemTraBarem_GiayToLaiXe(Me, p_PhuongTien, p_GIAYTO_XE, p_GIAYTO_LX, p_BAREM_XE) = False Then
                Exit Sub
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

                    ' If g_KV1 = True Then
                    p_SQL = ""
                    If Not Me.MaPhuongTien.EditValue Is Nothing Then
                        p_SQL = Me.MaPhuongTien.EditValue.ToString.Trim
                    End If

                    If p_SQL <> "" Then
                        CheckPhuongTien_LoaiXuat(p_SQL, p_Error, p_SQL, p_LoaiXuat)

                        If Not Me.MaVanChuyen.EditValue Is Nothing Then
                            p_SQL = Me.MaVanChuyen.EditValue.ToString.Trim
                        End If
                        If p_SQL = "" Then
                            Me.MaVanChuyen.EditValue = p_LoaiXuat
                            p_SQL = Me.MaVanChuyen.EditValue.ToString.Trim
                            Me.LoaiXuat.EditValue = GetLoadingSite(p_SQL)
                        End If


                    End If

                    'End If

                    ' mdlGetDiemTraHang(ByVal p_ChuyenVanTai As String) As String
                End If

            End If

            If p_LenhGhep = True Then
                p_SQL = "exec FPT_TRangThaiSoLenhGhep '" & p_SoLenh_Line & "'"
                p_Datatable1 = GetDataTable(p_SQL, p_SQL)
                If Not p_Datatable1 Is Nothing Then
                    For p_Count = 0 To p_Datatable1.Rows.Count - 1
                        If p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim = "3" Or p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim = "31" _
                                Or p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim = "4" Or p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim = "5" Then
                            ShowMessageBox("", "Lệnh " & p_Datatable1.Rows(p_Count).Item("SoLenh").ToString.Trim & " trạng thái không hợp lệ (" & p_Datatable1.Rows(p_Count).Item("Status").ToString.Trim & ") ")
                            Exit Sub
                        End If
                    Next
                End If
                CapNhatPhuongTienGhep()

            End If


            'anhqh
            '20180328
            'Them don code truoc khi luu thi xoa gia tri cac ngan di theo Ngay thang va Tableid


            'p_SQL = "delete from tblLenhXuatChiTietE5 where " & _
            '                     " TableID='" & p_DataRow.Item("TableID").ToString.Trim & "'" & _
            '                     " and NgayXuat ='" & CDate(p_DataRow.Item("NgayXuat")).ToString("MM-dd-yyyy") & "' " & _
            '                     " and  MaNgan='" & p_DataRow.Item("MaNgan").ToString.Trim & "' " & _
            '                     " and  exists ( select 1 from fpt_tbllenhxuatchitiete5_v hh, tbllenhxuate5 hh1 with (nolock)  where  " & _
            '                         " hh.solenh=hh1.solenh  and hh1.Status in ( '1','2','')  and tblLenhXuatChiTietE5.Row_ID =hh.Row_ID " & _
            '                          " and hh1.ngayxuat =tblLenhXuatChiTietE5.ngayxuat ) "
            'p_DataRow = Me.pv_LineRemove.NewRow
            'p_DataRow.Item(0) = p_SQL

            p_TableRemove = pv_LineRemove.Clone
            p_TableRemove.Clear()
            With Me.GridView1
                For p_Count = 0 To .RowCount - 1
                    Try
                        If .IsDataRow(p_Count) = True Then
                            p_DataRow = .GetDataRow(p_Count)
                            If p_DataRow Is Nothing Then
                                Continue For
                            End If
                            'p_DataRow = p_TableRemove.NewRow
                            p_SQL = "delete from tblLenhXuatChiTietE5 where " & _
                                                 " TableID='" & p_DataRow.Item("TableID").ToString.Trim & "'" & _
                                                 " and NgayXuat ='" & CDate(p_DataRow.Item("NgayXuat")).ToString("MM-dd-yyyy") & "' " & _
                                                 " and  exists ( select 1 from  tbllenhxuate5 hh1 with (nolock)  where  " & _
                                                     "  hh1.Status in ( '1','2','') " & _
                                                     "  and hh1.solenh = '" & p_DataRow.Item("SoLenh").ToString.Trim & "' " & _
                                                      "  )"
                            p_DataRow = p_TableRemove.NewRow
                            p_DataRow.Item(0) = p_SQL
                            p_TableRemove.Rows.Add(p_DataRow)
                        End If
                    Catch ex As Exception

                    End Try
                Next

            End With

            Dim p_RowArr() As DataRow

            p_SQL = "exec FPT_CheckLenhInTichKe '" & p_SoLenh_Line & "'"
            p_Datatable1 = GetDataTable(p_SQL, p_SQL)
            If Not p_Datatable1 Is Nothing Then
                If p_Datatable1.Rows.Count > 0 Then
                    p_RowArr = p_Datatable1.Select("Err=1")
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


            If p_TableRemove.Rows.Count > 0 Then
                If g_Services.Sys_Execute_DataTbl(p_TableRemove, p_SQL) = False Then
                    ShowMessageBox("", p_SQL)
                    Exit Sub
                End If
            End If

            p_TableRemove.Clear()

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


        If p_NguoiVanChuyen = "" Then
            If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
                p_NguoiVanChuyen = Me.NguoiVanChuyen.EditValue.ToString.Trim
            End If
        End If


        If p_PhuongTien = "" Then
            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
            End If
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
        Dim p_Pro_TuDongHoa As String
        Dim p_ArrRow() As DataRow
        Dim p_Date As Date
        p_ArrRow = p_TableConfig.Select("KEYCODE='MATUDONGHOA_PROD'")
        If p_ArrRow.Length > 0 Then
            p_Pro_TuDongHoa = p_ArrRow(0).Item("KEYVALUE").ToString.Trim
        End If
        If p_ThamSoNgay = True Then
            p_Date = Me.NgayXuat.EditValue
            p_SQL = " exec " & p_Pro_TuDongHoa & " '" & p_Date.ToString("yyyyMMdd") & "' "
        Else
            p_SQL = " exec " & p_Pro_TuDongHoa
        End If

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
        Dim p_StatusTmp As String = ""

        Dim p_aaaDBSource As U_TextBox.U_BindingSource
        Dim p_aaatable As DataTable

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

            p_StatusTmp = TrangThaiLenhXuat()
            If p_StatusTmp <> "1" And p_StatusTmp <> "2" Then
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


            p_StatusTmp = TrangThaiLenhXuat()
            If p_StatusTmp <> "1" And p_StatusTmp <> "2" Then
                ShowMessageBox("", "Lệnh xuất đã được đẩy vào hệ thống bơm xuất", 1)
                Exit Sub
            End If


            If Not p_TableNgan Is Nothing Then

                'xu ly pv_LineRemove    GridView2.TableName.ToString.Trim
                If Not pv_LineRemove Is Nothing Then
                    If GridView2.TableName.ToString.Trim <> "" Then
                        For p_Count = pv_LineRemove.Rows.Count - 1 To 0 Step -1
                            If UCase(pv_LineRemove.Rows(p_Count).Item("TableName").ToString.Trim) = UCase(GridView2.TableName.ToString.Trim) Then
                                pv_LineRemove.Rows.RemoveAt(p_Count)
                            End If
                        Next
                    End If
                    pv_LineRemove.AcceptChanges()
                End If

                Cursor = Cursors.WaitCursor
                GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                p_Count = 0

                'p_StatusTmp = pv_LineRemove.Rows(0).Item(0).ToString.Trim


                p_aaaDBSource = Me.GridView2.DataSource
                p_aaatable = CType(p_aaaDBSource.DataSource, DataTable)



                While Me.GridView2.RowCount - 1 >= 0 And p_Count < 100
                    Try
                        p_Count = p_Count + 1
                        p_DataRow = GridView2.GetDataRow(Me.GridView2.RowCount - 1)

                        'anhqh
                        '20180328
                        'Bo di vi khi luu da xoa di roi
                        'If p_DataRow.Item("Row_id").ToString.Trim <> "" Then
                        '    p_SQL = p_DataRow.Item("Row_id").ToString.Trim
                        '    p_SQL = "Delete from tblLenhXuatChiTietE5 where  Row_id=" & p_SQL
                        '    p_DataRow = Me.pv_LineRemove.NewRow
                        '    p_DataRow.Item(0) = p_SQL
                        '    Try
                        '        p_DataRow.Item(1) = "tblLenhXuatChiTietE5"
                        '    Catch ex As Exception

                        '    End Try

                        '    Me.pv_LineRemove.Rows.Add(p_DataRow)
                        '    '  Me.pv_LineRemove.Rows.Add()

                        'Else
                        '    '       a.TableID = B_1.TableID And a.NgayXuat = B_1.NgayXuat And a.MaLenh = B_1.MaLenh And
                        '    'a.LineID = B_1.LineID
                        '    Try
                        '        If p_DataRow.Item("TableID").ToString.Trim <> "" Then
                        '            p_SQL = "Delete from tblLenhXuatChiTietE5 where  TableID = '" & p_DataRow.Item("TableID").ToString.Trim & "' " & _
                        '                " And NgayXuat = '" & CDate(p_DataRow.Item("NgayXuat")).ToString("yyyyMMdd") & "' " & _
                        '                 " And MaLenh = '" & p_DataRow.Item("MaLenh").ToString.Trim & "' " & _
                        '                 " And LineID = '" & p_DataRow.Item("LineID").ToString.Trim & "' "

                        '            p_DataRow = Me.pv_LineRemove.NewRow
                        '            p_DataRow.Item(0) = p_SQL

                        '            Try
                        '                p_DataRow.Item(1) = GridView2.TableName.ToString.Trim
                        '            Catch ex As Exception

                        '            End Try


                        '            Me.pv_LineRemove.Rows.Add(p_DataRow)
                        '            ' Me.pv_LineRemove.Rows.Add()


                        '        End If
                        '    Catch ex As Exception

                        '    End Try


                        'End If
                        GridView2.DeleteRow(Me.GridView2.RowCount - 1)
                    Catch ex As Exception

                    End Try
                End While


                p_aaaDBSource = Me.GridView2.DataSource
                p_aaatable = CType(p_aaaDBSource.DataSource, DataTable)


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


    Function KiemTraSoLenhSapOff(ByVal p_SoLenh As String) As Boolean
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        KiemTraSoLenhSapOff = False
        If p_MatKetNoiSAP = True Then   'Neu mat ket noi SAP
            If Mid(p_SoLenh, 1, Len(g_WareHouse)) <> g_WareHouse Then  'Neu la lenh khong phai Lenh tao moi thi khong tro len sap nua
                KiemTraSoLenhSapOff = True
                Cursor = Cursors.Default
                ShowMessageBox("", "HTTG không kết nối được SAP.", 3)
                Exit Function
            End If
        End If

    End Function

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
        Dim p_PhuongTienSMO As String


        ShowStatusMessage(False, "", "")

        If KiemTraNgayThang() = False Then
            Exit Sub
        End If



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




        '  If g_KV1 = True Then
        If Not Me.NgayXuat.EditValue Is Nothing Then
            If Me.NgayXuat.EditValue.ToString.Trim <> "" Then
                p_Date_KV1 = Me.NgayXuat.EditValue
            End If
        End If
        ' End If

        If Not Me.SoLenh.EditValue Is Nothing Then
            'Me.GridView2.AllowInsert = False
            If Me.SoLenh.EditValue.ToString.Trim <> "" Then


                Dim p_TableExe As DataTable
                Dim g_LoaiHinhVanChuyen, p_MaPhuongTien As String
                g_LoaiHinhVanChuyen = ""
                p_MaPhuongTien = ""
                Try
                    If Not Me.LoaiXuat.EditValue Is Nothing Then
                        g_LoaiHinhVanChuyen = UCase(Me.LoaiXuat.EditValue.ToString.Trim)
                    End If
                Catch ex As Exception

                End Try
                Try
                    If Not Me.MaPhuongTien.EditValue Is Nothing Then
                        p_MaPhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
                    End If
                Catch ex As Exception

                End Try

                If p_SMO_BO = False And p_SMO_THUY = False Then

                Else

                    If CheckDO_Infor(Me.SoLenh.EditValue.ToString.Trim, g_LoaiHinhVanChuyen, p_SMO_BO, p_SMO_BO_R, _
                                         p_SMO_THUY, p_SMO_THUY_R, "", p_TableExe, False, p_PhuongTienSMO) = False Then

                        Exit Sub
                    End If
                End If

                Cursor = Cursors.WaitCursor
                p_Value = Me.SoLenh.EditValue.ToString.Trim

                If KiemTraSoLenhSapOff(p_Value) = True Then
                    Exit Sub
                End If
                'p_SQL = "select Status  from tblLenhXuatE5 with (nolock) where solenh='" & p_Value & "' and  Status  in ('31','4','5')"
                'p_DataTable = GetDataTable(p_SQL, p_SQL)
                'If Not p_DataTable Is Nothing Then
                '    If p_DataTable.Rows.Count > 0 Then
                '        'If p_TableCheck.Rows(0).Item("Status").ToString.Trim = "4" Or p_TableCheck.Rows(0).Item("Status").ToString.Trim = "5" Then
                '        ShowMessageBox("", "Trạng thái lệnh xuất không hợp lệ", 3)
                '        Exit Sub
                '        'End If

                '    End If
                'End If


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

                        'anhqh
                        '20171114
                        'Tam thoi bo di

                        'If Not pv_LineRemove Is Nothing Then
                        '    If pv_LineRemove.Rows.Count > 0 Then
                        '        pv_LineRemove.Clear()
                        '    End If
                        'End If

                        Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                        Me.DefaultFormLoad = True
                        Me.Form1_Load(sender, e)


                        If Not p_DataTableDel Is Nothing Then
                            If p_DataTableDel.Columns.Count <= 0 Then
                                p_DataTableDel.Columns.Add("STRSQL")
                                p_DataTableDel.Columns.Add("TableName")
                            End If
                        End If

                        Try
                            Dim p_count As Integer
                            Dim p_Row As DataRow
                            For p_count = 0 To Me.GridView2.RowCount - 1
                                p_Row = Me.GridView2.GetDataRow(p_count)
                                If Not p_Row Is Nothing Then
                                    If p_Row.Item("Row_id").ToString.Trim <> "" Then
                                        p_DataRow = p_DataTableDel.NewRow
                                        p_SQL = "delete from tblLenhXuatChiTietE5 where  Row_id=" & p_Row.Item("Row_id").ToString.Trim
                                        p_DataRow.Item(0) = p_SQL

                                        Try
                                            p_DataRow.Item(1) = GridView2.TableName.ToString.Trim
                                        Catch ex As Exception

                                        End Try


                                        p_DataTableDel.Rows.Add(p_DataRow)
                                    End If
                                End If
                            Next
                        Catch ex As Exception

                            p_DataRow = p_DataTableDel.NewRow

                            p_SQL = "delete from tblLenhXuatChiTietE5  where " & _
                                " exists (select 1 from FPT_tblLenhXuatChiTietE5_V a  where " & _
                                          " a.SoLenh='" & p_Value & "'  and a.Row_id=tblLenhXuatChiTietE5.Row_id)"

                            p_DataRow.Item(0) = p_SQL
                            p_DataRow.Item(1) = "tblLenhXuatChiTietE5"

                            p_DataTableDel.Rows.Add(p_DataRow)
                        End Try


                        p_DataRow = p_DataTableDel.NewRow
                        p_SQL = "delete from tblLenhXuat_HangHoaE5  where SoLenh='" & p_Value & "'"
                        p_DataRow.Item(0) = p_SQL
                        p_DataRow.Item(1) = "tblLenhXuat_HangHoaE5"

                        p_DataTableDel.Rows.Add(p_DataRow)
                        p_DataRow = p_DataTableDel.NewRow
                        p_SQL = "delete from tblLenhXuatE5  where SoLenh='" & p_Value & "'"
                        p_DataRow.Item(0) = p_SQL
                        p_DataRow.Item(1) = "tblLenhXuatE5"
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

                            If p_KIEMKE_N30 = True Then
                                p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(_SapConnectionString, "EN", 30, g_Company_Code, "", "")
                                If KiemTraThoiGianKiemKe_N30(p_ECCDestinationConfig, "T", Nothing, p_Value) = True Then
                                    Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If
                            If g_KV1 = True Then
                                If p_SAP_Object.kv1clsSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_Value, p_SQL, p_Date_KV1, IIf(Me.LenhNgay.Checked = True, "Y", "N")) = False Then

                                    ShowMessageBox("", p_SQL)
                                    GoTo Line_tt
                                Else
                                    Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                                    Me.DefaultFormLoad = True
                                    Me.Form1_Load(sender, e)
                                    Me.SoLenh.Properties.ReadOnly = False
                                    Me.SoLenh.BackColor = pv_Required_Back_Color
                                    p_PhuongTien = ""
                                    If KiemTraKhachHang_TuyenDuong(p_Value) = False Then
                                        ' Exit Sub
                                    End If
                                    GoTo Linett2
                                    ''MsgBox("bbb")
                                End If
                            Else
                                If p_SAP_Object.clsSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_Value, p_SQL, p_Date_KV1) = False Then
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

                        End If

                    End If

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
                If p_PhuongTienSMO <> "" Then
                    p_SQL = "Update tblLenhXuatE5 set MaPhuongTien ='" & p_PhuongTienSMO & "' where SoLenh ='" & p_Value & "'"
                    If g_Services.Sys_Execute(p_SQL, _
                                     p_SQL) = False Then
                        ShowMessageBox("", p_SQL)
                    End If
                    Me.MaPhuongTien.EditValue = p_PhuongTienSMO
                End If

                If Not p_TableExe Is Nothing Then
                    If p_TableExe.Rows.Count > 0 Then
                        p_SQL = p_TableExe.Rows(0).Item(0).ToString.Trim
                        If g_Services.Sys_Execute(p_SQL, _
                                         p_SQL) = False Then
                            ShowMessageBox("", p_SQL)
                        End If
                    End If
                End If
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



    Public Sub RefreshButton()
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

        Me.GridView2.Columns.Item("MaNgan").OptionsColumn.ReadOnly = False
        Me.GridView2.Columns.Item("TableID").OptionsColumn.ReadOnly = False
        If p_METERID_NGAN = False Then
            Me.GridView2.Columns.Item("MaLuuLuongKe").OptionsColumn.ReadOnly = True
        Else
            Me.GridView2.Columns.Item("MaLuuLuongKe").Visible = True
            Me.GridView2.Columns.Item("MaLuuLuongKe").OptionsColumn.ReadOnly = False
        End If

        Me.GridView2.Columns.Item("SoLuongDuXuat").OptionsColumn.ReadOnly = False

        Me.GridView2.AllowInsert = True


        Me.GridView1.Columns.Item("MeterId").OptionsColumn.ReadOnly = False
        Me.GridView1.Columns.Item("BeXuat").OptionsColumn.ReadOnly = False


        ' LenhGhep(p_Value)
        GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom

        If (g_KV1 = True Or p_REFRESH = False) And p_SoLenh <> "" Then


        Else
            Me.SoLenh.EditValue = p_SoLenh
        End If
        'If p_SoLenh <> "" And (g_KV1 = False Or p_REFRESH = False) Then
        '    Me.SoLenh.EditValue = p_SoLenh

        '    ' Me.SoLenh.SendKey()

        'End If


        'End If
        'End If
    End Sub

    'Menu refresh
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        ' If Me.BtnOk.Text = Me.CaptionAdd And Me.FormStatus = False Then

        Dim p_ABC As String = ""
        '   THN_LenhXuat_Infor("asdfgh", p_ABC)

        RefreshButton()

        Exit Sub
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

        Me.GridView2.Columns.Item("MaNgan").OptionsColumn.ReadOnly = False
        Me.GridView2.Columns.Item("TableID").OptionsColumn.ReadOnly = False
        ' Me.GridView2.Columns.Item("MaLuuLuongKe").OptionsColumn.ReadOnly = False
        If p_METERID_NGAN = False Then
            Me.GridView2.Columns.Item("MaLuuLuongKe").OptionsColumn.ReadOnly = True
        Else
            Me.GridView2.Columns.Item("MaLuuLuongKe").OptionsColumn.ReadOnly = False
        End If
        Me.GridView2.Columns.Item("SoLuongDuXuat").OptionsColumn.ReadOnly = False

        Me.GridView2.AllowInsert = True


        Me.GridView1.Columns.Item("MeterId").OptionsColumn.ReadOnly = False
        Me.GridView1.Columns.Item("BeXuat").OptionsColumn.ReadOnly = False


        ' LenhGhep(p_Value)
        GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom

        If (g_KV1 = True Or p_REFRESH = False) And p_SoLenh <> "" Then


        Else
            Me.SoLenh.EditValue = p_SoLenh
        End If
        'If p_SoLenh <> "" And (g_KV1 = False Or p_REFRESH = False) Then
        '    Me.SoLenh.EditValue = p_SoLenh

        '    ' Me.SoLenh.SendKey()

        'End If


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
        Dim p_StrSoLenh As String = ""


        Dim p_Count As Integer
        Dim p_Row As DataRow


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
                    ShowMessageBox("", "Ngày tháng không hợp lệ")
                    KiemTraNgayXuatHang = False
                    Exit Function
                End If

                ''anhqh
                ''20161026
                'If p_NgayXuat < p_Date Then
                '    ShowMessageBox("", "Ngày tháng không hợp lệ")
                '    KiemTraNgayXuatHang = False
                '    Exit Function
                'End If

                If KiemTraNgayThangLenhXuat(p_Date) = False Then
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


    Function KiemTraNgayThangLenhXuat(ByVal p_Date As Date) As Boolean
        Dim p_StrSoLenh As String
        Dim p_Row As DataRow
        Dim p_SQL As String
        Dim p_Data As DataTable

        p_StrSoLenh = ""

        KiemTraNgayThangLenhXuat = True

        For p_Count = 0 To Me.GridView1.RowCount - 1
            p_Row = GridView1.GetDataRow(p_Count)
            If Not p_Row Is Nothing Then
                Try
                    p_StrSoLenh = p_StrSoLenh & "," & p_Row.Item("SoLenh").ToString.Trim
                Catch ex As Exception

                End Try
            End If

        Next
        If p_StrSoLenh <> "" Then
            p_StrSoLenh = p_StrSoLenh & ","
            p_SQL = " exec FPT_KiemTraNgayThang '" & p_StrSoLenh & "','" & p_Date.ToString("yyyMMdd") & "'"
            p_Data = GetDataTable(p_SQL, p_SQL)
            If Not p_Data Is Nothing Then
                If p_Data.Rows.Count > 0 Then
                    ShowMessageBox("", "Ngày tháng không hợp lệ")
                    KiemTraNgayThangLenhXuat = False
                    Exit Function
                End If
            End If
        End If


    End Function


    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim p_sCardNumber As String = ""
        Dim p_Table As DataTable
        Dim p_CardData As String = ""

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
        '  UpdateStatusDO(p_SMOAPI, "2023766215", "3")
        If KiemTraNgayThang() = False Then
            Exit Sub
        End If


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

        '  If g_KV1 = True Then
        p_SoLenh = ""
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If

        p_SQL = "select Status  from tblLenhXuatE5 with (nolock) where solenh='" & p_SoLenh & "' and  Status  in ('4','5')"
        p_TableCheck = GetDataTable(p_SQL, p_SQL)
        If Not p_TableCheck Is Nothing Then
            If p_TableCheck.Rows.Count > 0 Then
                'If p_TableCheck.Rows(0).Item("Status").ToString.Trim = "4" Or p_TableCheck.Rows(0).Item("Status").ToString.Trim = "5" Then
                ShowMessageBox("", "Lệnh đã Xác nhận thực xuất nên không thể in tích kê", 3)
                Exit Sub
                'End If

            End If
        End If

        ' End If

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

        If getNguoiVanChuyen(p_MaPhuongTien, p_NguoiVanChuyen, p_Desc, Me) = False Then
            ' ShowMessageBox("", p_Desc)
            'Me.MaPhuongTien.EditValue = ""
            '  e.Cancel = True
            Exit Sub
        End If

        If KiemTraBarem_GiayToLaiXe(Me, p_MaPhuongTien, p_GIAYTO_XE, p_GIAYTO_LX, p_BAREM_XE) = False Then
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
                If g_KV1 = True Or p_DIEMTRAHANG = True Then
                    mdlGetDiemTraHang(p_SoLenh)
                    Me.DefaultFormLoad = True
                    XtraForm1_Load()
                    Me.DefaultFormLoad = False
                End If
                'p_SQL = "exec FPT_CheckLenhInTichKe '" & p_SoLenh & "'"
                'p_TableCheck = GetDataTable(p_SQL, p_SQL)
                'If Not p_TableCheck Is Nothing Then
                '    If p_TableCheck.Rows.Count > 0 Then
                '        p_RowArr = p_TableCheck.Select("Err=1")
                '        If p_RowArr.Length > 0 Then
                '            ShowMessageBox("", p_RowArr(0).Item("sDesc"), 3)
                '            Exit Sub
                '        Else
                '            For p_Count = 0 To p_RowArr.Length - 1
                '                ShowMessageBox("", p_RowArr(p_Count).Item("sDesc"), 2)
                '            Next
                '        End If
                '    End If
                'End If

                'anhqh  20221007 da bo sung them doan kiem tra FPT_CheckLenhInTichKe  vao _Report_Object.clsInTichKe
                _Report_Object.clsInTichKe(p_ValueCheck, p_SoLenh, p_MATUDONGHOA)
            Else
                If g_KV1 = True Or p_DIEMTRAHANG = True Then
                    mdlGetDiemTraHang(p_StrSoLenh)
                    Me.DefaultFormLoad = True
                    XtraForm1_Load()
                    Me.DefaultFormLoad = False
                End If
                'p_SQL = "exec FPT_CheckLenhInTichKe '" & p_StrSoLenh & "'"
                'p_TableCheck = GetDataTable(p_SQL, p_SQL)
                'If Not p_TableCheck Is Nothing Then
                '    If p_TableCheck.Rows.Count > 0 Then
                '        p_RowArr = p_TableCheck.Select("Err=1")
                '        If p_RowArr.Length > 0 Then
                '            ShowMessageBox("", p_RowArr(0).Item("sDesc"), 3)
                '            Exit Sub
                '        Else
                '            For p_Count = 0 To p_RowArr.Length - 1
                '                ShowMessageBox("", p_RowArr(p_Count).Item("sDesc"), 2)
                '            Next
                '        End If
                '    End If
                'End If

                'anhqh  20221007 da bo sung them doan kiem tra FPT_CheckLenhInTichKe  vao _Report_Object.clsInTichKe
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

                'If KiemTraKhiLuuLenh(p_SoLenh) = False Then
                '    Exit Sub
                'End If

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
            Dim p_TableExe As DataTable
            Dim p_PhuongTienSMO As String = ""
            'If CheckDO_Infor(p_StrSoLenh, g_LoaiHinhVanChuyen, p_SMO_BO, p_SMO_BO_R, _
            '                     p_SMO_THUY, p_SMO_THUY_R, p_MaPhuongTien, p_TableExe, False, p_PhuongTienSMO) = False Then

            '    Exit Sub
            'End If

            If Not p_TableExe Is Nothing Then
                If p_TableExe.Rows.Count > 0 Then
                    If g_Services.Sys_Execute_DataTable(p_TableExe, _
                                           p_Desc) = False Then
                        ShowMessageBox("", p_Desc)
                        Exit Sub
                    End If
                End If
            End If
            'If p_SQL = "N" Or UCase(p_Type) = "FOX" Then
            '    p_Message = HTTG_To_Scadar("out", p_StrSoLenh, g_LoaiHinhVanChuyen, p_Terminal, True)
            'Else
            '    p_Message = g_Services.SYS_HTTG_To_Scadar("out", p_StrSoLenh, g_LoaiHinhVanChuyen, p_Terminal, True)
            'End If



            If p_TANKAPPROVED = True Then
                p_SQL = "select  1 as Err,N'Số lệnh (' + a.SoLenh +N') Mã bể ' + a.BeXuat + N'  chưa được phê duyệt theo ngày'  as  sDesc " & _
                        " from tblLenhXuat_hanghoaE5 a with(nolock)	" & _
                 " where   CHARINDEX (',' + solenh +',', '," & p_StrSoLenh & ",' ,1)>0 	" & _
                 " and not  exists (select 1 from  FPT_tblTankActive_v b where Date1=CONVERT(date,getdate ()) 	" & _
                 " and Name_nd=a.BeXuat and isnull(Tank_App,'N') ='Y'  )"
                p_TableCheck = GetDataTable(p_SQL, p_SQL)
                If Not p_TableCheck Is Nothing Then
                    If p_TableCheck.Rows.Count > 0 Then

                        ShowMessageBox("", p_TableCheck.Rows(0).Item("sDesc"))
                        Exit Sub

                    End If
                End If
            End If


            p_Number = 0
            If Not Me.aNumber.EditValue Is Nothing Then
                Double.TryParse(Me.aNumber.EditValue.ToString.Trim, p_Number)
            End If


            ' If p_NguoiVanChuyen = "" Then
            If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
                p_NguoiVanChuyen = Me.NguoiVanChuyen.EditValue.ToString.Trim
            End If
            'End If

            If p_MaPhuongTien = "" Then
                If Not Me.MaPhuongTien.EditValue Is Nothing Then
                    p_MaPhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
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

            If p_MaVanChuyen.ToString.Trim = "" Then
                ShowMessageBox("", "Loại hình vận tải không được trống")

                Exit Sub
            End If
            GetMaVanChuyen(p_MaPhuongTien, p_MaVanChuyen, p_VanChuyen)

            '  sfsffsdsfs()
            '  sfdsfs()
            If p_CardNum = True Then
                Dim p_Check As Boolean = False
                Dim p_TblCheck As DataTable
                ''''Lay thong tin khai bao hang hoa co quan ly The tu   20200810   anhqh sua theo yeu cau Tam kV2
                p_SQL = "exec  KiemTraTheTheoHangHoa '" & p_StrSoLenh & "'"
                p_TblCheck = GetDataTable(p_SQL, p_SQL)
                If Not p_TblCheck Is Nothing Then
                    If p_TblCheck.Rows.Count > 0 Then
                        ' ''Kiem tra xem có lệnh nào không nằm trong danh sách lệnh ghep mà khác  số thẻ không
                        'p_SQL = "select SoLenh from tblLenhXuatE5  with (nolock)  where  ( CHARINDEX (',' + solenh +',','" & p_StrSoLenh & ",',1)>0  or SoLenh='" & p_SoLenh & "' ) " & _
                        '                " and isnull( CardNum,'') <> '" & p_sCardNumber & "' and isnull( CardNum,'') <> '' "
                        'p_DataHeader = GetDataTable(p_SQL, p_SQL)
                        'If Not p_DataHeader Is Nothing Then
                        '    If p_DataHeader.Rows.Count > 0 Then
                        '        ShowMessageBox("", "Danh sách lệnh ghép không cùng số thẻ")
                        '        Exit Sub
                        '    End If
                        'End If
                        p_sCardNumber = ""
                        p_SQL = "select top 1 CardNum, CardData from tblLenhXuatE5  with (nolock)  where  ( CHARINDEX (',' + solenh +',','" & p_StrSoLenh & ",',1)>0  or SoLenh='" & p_SoLenh & "' ) " & _
                                        " and   isnull( CardNum,'') <> '' "
                        p_DataHeader = GetDataTable(p_SQL, p_SQL)
                        If Not p_DataHeader Is Nothing Then
                            If p_DataHeader.Rows.Count > 0 Then
                                p_sCardNumber = p_DataHeader.Rows(0).Item("CardNum").ToString.Trim
                                p_CardData = p_DataHeader.Rows(0).Item("CardData").ToString.Trim
                                'p_Check = True
                            End If
                        End If

                        ' If p_Check = False Then
                        Dim p_form As New FrmCardInput
                        p_form.StringReturn = p_sCardNumber
                        p_form.StringCardData = p_CardData
                        p_form.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                        p_form.g_XtraServicesObj = g_XtraServicesObj
                        p_form.p_XtraToolTripLabel = g_ToolStripStatus
                        p_form.p_XtraMessageStatusl = g_MessageStatus
                        p_form.StringSoLenh = p_SoLenh & "," & p_StrSoLenh
                        p_form.ShowDialog(Me)
                        p_sCardNumber = p_form.StringReturn
                        p_CardData = p_form.StringCardData
                        'End If

                        If p_sCardNumber = "" Then
                            Dim p_ValueMess As Windows.Forms.DialogResult

                            If p_CARDREQUIRED = True Then
                                ShowMessageBox("", "Số thẻ chưa được nhập")
                                Exit Sub
                            End If

                        End If
                    End If
                End If


            End If

            If p_CardNum = True And p_sCardNumber <> "" Then
                p_SQL = "update  tblLenhXuatE5  set  CardNum ='" & p_sCardNumber & "', CardData='" & p_CardData & "' where   ( CHARINDEX (',' + solenh +',','" & p_StrSoLenh & ",',1)>0  or SoLenh='" & p_SoLenh & "')"

                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                End If
            End If

            For p_Count = 0 To Me.GridView2.RowCount - 1
                p_DataRow = Me.GridView2.GetDataRow(p_Count)
                If p_DataRow Is Nothing Then
                    Continue For
                End If
                If p_CardNum = True And p_sCardNumber <> "" Then
                    If p_DataRow.Item("Row_id").ToString.Trim <> "" Then
                        p_SQL = "update  tblLenhXuatChiTietE5  set PhuongTien= '" & p_VanChuyen & "', CardNum ='" & p_sCardNumber & "', CardData='" & p_CardData & "'  where  Row_id=" & p_DataRow.Item("Row_id").ToString.Trim & _
                                " ;"
                        'p_SQL = "update  tblLenhXuatE5  set  CardNum ='" & p_sCardNumber & "' where  Row_id=" & p_DataRow.Item("Row_id").ToString.Trim & _
                        '        " ;"

                        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                        End If
                    End If




                Else
                    If p_DataRow.Item("Row_id").ToString.Trim <> "" Then
                        p_SQL = "update  tblLenhXuatChiTietE5  set PhuongTien= '" & p_VanChuyen & "' where  Row_id=" & p_DataRow.Item("Row_id").ToString.Trim & _
                                " and  isnull(PhuongTien,'')='' "
                        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                        End If
                    End If
                End If

            Next

            If UCase(g_LoaiHinhVanChuyen) = "BO" Or UCase(g_LoaiHinhVanChuyen) = "SAT" Then
                If KiemTraDungTich_DuXuat() = False Then
                    Exit Sub
                End If
            End If

            If p_GiaoNhanHH = True Then
                p_SQL = "exec KiemTraGiaoNhan_HH '" & p_StrSoLenh & "'"

                p_Table = GetDataTable(p_SQL, p_SQL)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        If p_Table.Rows(0).Item(0) = 0 Then
                            Dim p_ValueMess As Windows.Forms.DialogResult
                            p_ValueMess = g_Module.ShowMessage(Me, "", _
                                                                              p_Table.Rows(0).Item("sDesc").ToString.Trim & _
                                                                                       vbCrLf & "Bạn có muốn thực hiện tiếp không?", _
                                                                               True, _
                                                                                "Có", _
                                                                               True, _
                                                                               "Không", _
                                                                               False, _
                                                                               "", _
                                                                                0)
                            If p_ValueMess = Windows.Forms.DialogResult.No Then
                                Exit Sub
                            Else
                                ShowMessageBox("", p_Table.Rows(0).Item("sDesc").ToString.Trim)
                                Exit Sub
                            End If

                        End If
                    End If
                End If
            End If
            ' Dim p_Table As DataTable

            'p_SQL = "exec FPT_KiemTraKhachHang_TuyenDuong '" & p_SoLenh & "'"
            'p_Table = GetDataTable(p_SQL, p_SQL)
            'If Not p_Table Is Nothing Then
            '    If p_Table.Rows.Count > 0 Then
            '        If p_Table.Rows(0).Item(0) > 0 Then
            '            ShowMessageBox("", p_Table.Rows(0).Item(1).ToString.Trim)
            '            Exit Sub
            '        End If
            '    End If
            'End If

            If KiemTraKhachHang_TuyenDuong(p_SoLenh) = False Then
                Exit Sub
            End If

            If p_SoChuyen = True Then

            End If

            If KiemTraKhiLuuLenh(p_StrSoLenh, p_Status) = False Then
                Exit Sub
            End If
            If p_ThongTinNhomBe = True Then
                p_SQL = "exec FPT_CheckLenhInTichKe '" & p_StrSoLenh & "',1 "

            Else
                p_SQL = "exec FPT_CheckLenhInTichKe '" & p_StrSoLenh & "'"
            End If
            '' p_SQL = "exec FPT_CheckLenhInTichKe '" & p_StrSoLenh & "'"
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


            

            If p_KIEMKE_N30 = True Then
                'sddsfsfsd()
                Dim p_ECCDestinationConfig As New ECCDestination.ECCDestinationConfig(_SapConnectionString, "EN", 30, g_Company_Code, "", "")
                If p_LenhGhep = True Then
                    Dim p_Datatable_LG As New DataTable("TBL01")
                    Dim p_Row As DataRow
                    Dim p_SoLenhArr() As String
                    Dim p_int As Integer

                    'MaPhuongTien, SoLenh,NguoiLaiXe,NgayXuat'
                    p_Datatable_LG.Columns.Add("MaPhuongTien")
                    p_Datatable_LG.Columns.Add("SoLenh")
                    p_Datatable_LG.Columns.Add("NguoiLaiXe")
                    p_Datatable_LG.Columns.Add("NgayXuat", GetType(System.DateTime))

                    p_SoLenhArr = p_StrSoLenh.Split(",")
                    For p_int = 0 To p_SoLenhArr.Length - 1
                        If Len(p_SoLenhArr(p_int)) >= 8 Then
                            p_Row = p_Datatable_LG.NewRow
                            p_Row.Item("SoLenh") = p_SoLenhArr(p_int)
                            p_Datatable_LG.Rows.Add(p_Row)
                        End If
                        
                    Next
                    If KiemTraThoiGianKiemKe_N30(p_ECCDestinationConfig, "T", p_Datatable_LG, "") = True Then
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                Else
                    If KiemTraThoiGianKiemKe_N30(p_ECCDestinationConfig, "T", Nothing, p_SoLenh) = True Then
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If
                
            End If


            ''Kiem tra lệnh ghép , nếu tách ngăn mà khác nhóm thì không cho tách ngăn bo sung KV2
            If p_ThongTinNhomBe = True Then
                Me.GridView2.MoveNext()
                Dim p_Source1, p_Source2 As U_TextBox.U_BindingSource
                Dim p_Table1, p_Table2 As DataTable
                Dim p_Arrrow(), p_Arrrow1() As DataRow
                Dim p_Int As Integer
                Dim p_DuXuat As Double
                Dim p_NhomBe As String = ""
                p_Source1 = Me.TrueDBGrid1.DataSource
                p_Source2 = Me.TrueDBGrid2.DataSource
                p_Table1 = CType(p_Source1.DataSource, DataTable)
                p_Table2 = CType(p_Source2.DataSource, DataTable)
                p_NhomBe = ""
                For p_Count = 0 To p_Table2.Rows.Count - 1
                    Double.TryParse(p_Table2.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim, p_DuXuat)
                    If p_DuXuat > 0 Then
                        p_Arrrow = p_Table2.Select("MaNgan='" & p_Table2.Rows(p_Count).Item("MaNgan").ToString.Trim & "'")
                        If p_Arrrow.Length > 1 Then  '

                            p_NhomBe = ""

                            For p_Int = 0 To p_Arrrow.Length - 1
                                If p_Arrrow(p_Int).Item("TableID").ToString.Trim = "" Then
                                    Continue For
                                End If
                                p_Arrrow1 = p_Table1.Select("TableID = '" & p_Arrrow(p_Int).Item("TableID").ToString.Trim & "'")
                                If p_Arrrow1.Length > 0 Then
                                    If p_NhomBe = "" Then
                                        p_NhomBe = p_Arrrow1(0).Item("NhomBeXuat").ToString
                                        Continue For
                                    End If
                                End If

                                If p_NhomBe <> p_Arrrow1(0).Item("NhomBeXuat").ToString Then
                                    ShowMessageBox("", "Ngăn " & p_Arrrow(0).Item("MaNgan").ToString.Trim & " không có cùng nhóm bể.")
                                    Exit Sub
                                End If
                            Next



                        End If
                    End If

                Next

            End If

            If g_WCF = True Then
                If p_Scadar_Type = "FOX" Then
                    p_Message = g_Services.SYS_HTTG_To_ScadarFox(g_UserName, "out", p_StrSoLenh, g_LoaiHinhVanChuyen, p_Terminal, True)
                ElseIf p_Scadar_Type = "ACC" Then
                    p_Message = g_Services.clsHTTG_To_ScadarAccess(g_UserName, "out", p_StrSoLenh, g_LoaiHinhVanChuyen, p_Terminal, True, True)
                Else

                    p_Message = g_Services.SYS_HTTG_To_Scadar(g_UserName, "out", p_StrSoLenh, g_LoaiHinhVanChuyen, p_Terminal, g_E5)
                End If

            Else
                If p_Scadar_Type = "FOX" Then
                    Dim p_FoxSAP_Obj As New FOX_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
                    p_Message = p_FoxSAP_Obj.clsHTTG_To_ScadarFox("out", p_StrSoLenh, g_LoaiHinhVanChuyen, p_Terminal, True, g_E5)
                ElseIf p_Scadar_Type = "ACC" Then
                    Dim p_AccessSAP_Obj As New ACCESS_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
                    p_Message = p_AccessSAP_Obj.clsHTTG_To_ScadarAccess("out", p_StrSoLenh, g_LoaiHinhVanChuyen, p_Terminal, True, g_E5)
                Else
                    Dim p_SAP_Obj As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
                    p_Message = p_SAP_Obj.clsHTTG_To_Scadar("out", p_StrSoLenh, g_LoaiHinhVanChuyen, p_Terminal, True, g_E5)
                End If


            End If

            If p_Message.ToString.Trim <> "" Then
                ShowMessageBox("", p_Message, 3)
                Exit Sub
            End If
            'If p_InLaiTichKe = False Then

            'In tich ke

            If g_KV1 = True Or p_DIEMTRAHANG = True Then
                mdlGetDiemTraHang(p_StrSoLenh)
                Me.DefaultFormLoad = True
                XtraForm1_Load()
                Me.DefaultFormLoad = False
            End If

            UpdateStatusDO(p_SMOAPI, p_StrSoLenh, "3")
            If g_KV1 = True Then
                p_SQL = ""
                '20220315 Bo sung them cap nhat trang thai da in tich ke cho lenh tren SAP, chir dung cho KV1
                KV1CapNhatTrangThaiTichKe(p_StrSoLenh, p_SQL)
                If p_SQL <> "" Then
                    ShowStatusMessage(True, "MS113", p_SQL, 10)
                End If
            End If
            _Report_Object.clsInTichKe(p_ValueCheck, p_StrSoLenh, p_MATUDONGHOA)



            Me.ToolStripButton4.Enabled = p_InLaiTichKe

            'End If

            ShowStatusMessage(False, "MS003", "Lệnh xuất đã đẩy sang Scadar", 10)
            Try
                If Not Me.pv_LineRemove Is Nothing Then
                    For p_Count = Me.pv_LineRemove.Rows.Count - 1 To 0 Step -1
                        If UCase(Me.pv_LineRemove.Rows(p_Count).Item(1).ToString.Trim) = UCase("tblLenhXuatChiTietE5") Then
                            pv_LineRemove.Rows.RemoveAt(p_Count)
                        End If
                    Next
                End If
                pv_LineRemove.AcceptChanges()
                '_DataRow.Item(1) = "tblLenhXuatChiTietE5"
            Catch ex As Exception

            End Try

            pv_LineRemove.Clear()
            'Me.pv_LineRemove.Rows.Add(p_DataRow)



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


    Private Function KiemTraKhachHang_TuyenDuong(ByVal p_SoLenh As String) As Boolean
        Dim p_SQL As String = ""
        Dim p_Table As DataTable
        KiemTraKhachHang_TuyenDuong = True
        Try
            p_SQL = "exec FPT_KiemTraKhachHang_TuyenDuong '" & p_SoLenh & "'"
            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    If p_Table.Rows(0).Item(0) > 0 Then
                        ShowMessageBox("", p_Table.Rows(0).Item(1).ToString.Trim)
                        KiemTraKhachHang_TuyenDuong = False
                    End If
                End If
            End If
        Catch ex As Exception

        End Try


    End Function

    Private Function KiemTraDungTich_DuXuat() As Boolean

        Dim p_Binding As New U_TextBox.U_BindingSource()
        Dim p_Datatable As DataTable
        Dim p_Count As Integer
        Dim p_RowArr() As DataRow
        Dim p_DungTich As Double = 0
        Dim p_DuXuat As Double = 0
        Dim p_DuXuat_Tmp As Double = 0
        Dim p_Cout1 As Integer
        p_Binding = Me.TrueDBGrid2.DataSource
        p_Datatable = CType(p_Binding.DataSource, DataTable)


        KiemTraDungTich_DuXuat = True

        For p_Count = 0 To p_Datatable.Rows.Count - 1
            If p_Datatable.Rows(p_Count).Item("MaNgan").ToString.Trim <> "" Then
                p_RowArr = p_Datatable.Select("MaNgan='" & p_Datatable.Rows(p_Count).Item("MaNgan").ToString.Trim & "'")
                p_DuXuat = 0
                If p_RowArr.Length > 0 Then
                    Double.TryParse(p_RowArr(0).Item("DungTichNgan").ToString.Trim, p_DungTich)
                    For p_Cout1 = 0 To p_RowArr.Length - 1
                        Double.TryParse(p_RowArr(p_Cout1).Item("SoLuongDuXuat").ToString.Trim, p_DuXuat_Tmp)
                        p_DuXuat = p_DuXuat + p_DuXuat_Tmp
                    Next
                    If p_DungTich <> p_DuXuat And p_DuXuat > 0 Then
                        ShowMessageBox("", "Tổng dự xuất và dung tích ngăn không hợp lệ")
                        Return False
                    End If
                End If
            End If
        Next


    End Function

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
        Dim p_TblChiTiet, p_TblChiTietKH As DataTable
        Dim p_DataSet As DataSet
        Dim p_SQL As String = ""
        Dim p_TableCheck, p_TableCheck1 As DataTable
        Dim P_Count As Integer
        Dim p_Row As DataRow
        Dim p_Count2 As Integer
        Dim p_RowChiTiet As DataRow
        Dim p_Arr() As DataRow
        Dim p_SoLenhGhep As String = ""
        Try
            KiemTraLineID_TableID = True
            p_BindHoangHoa = Me.TrueDBGrid1.DataSource
            p_TblHangHoa = CType(p_BindHoangHoa.DataSource, DataTable)

            p_BindChiTiet = Me.TrueDBGrid2.DataSource
            p_TblChiTiet = CType(p_BindChiTiet.DataSource, DataTable)
            p_TblChiTietKH = p_TblChiTiet.Copy()
            For P_Count = 0 To p_TblHangHoa.Rows.Count - 1
                p_Row = p_TblHangHoa.Rows(P_Count)
                If Not p_Row Is Nothing Then
                    p_SoLenhGhep = Replace(p_SoLenhGhep, p_Row.Item("SoLenh").ToString.Trim, "", 1)
                    p_SoLenhGhep = p_SoLenhGhep & "," & p_Row.Item("SoLenh").ToString.Trim
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

            Try
                If p_SoLenhGhep <> "" Then
                    p_SQL = "exec  FPT_KhachHangTheoSoLenh '" & p_SoLenhGhep & "'"
                    p_DataSet = GetDataSet(p_SQL, p_SQL)
                    ' p_TableCheck = GetDataTable(p_SQL, p_SQL)
                    If Not p_DataSet Is Nothing Then
                        If p_DataSet.Tables.Count >= 1 Then
                            p_TableCheck = p_DataSet.Tables(0)
                            'p_TableCheck1 = p_DataSet.Tables(1)
                            If p_TableCheck.Rows.Count > 1 Then
                                For p_Count2 = 0 To p_TblChiTiet.Rows.Count - 1
                                    p_RowChiTiet = p_TblChiTiet.Rows(p_Count2)
                                    If Not p_RowChiTiet Is Nothing Then
                                        If p_RowChiTiet.Item("TableID").ToString.Trim <> "" Then
                                            p_Arr = p_TblChiTietKH.Select("MaNgan='" & p_RowChiTiet.Item("MaNgan").ToString.Trim & "'")
                                            p_SQL = ""
                                            If p_Arr.Length > 1 Then
                                                For P_Count = 0 To p_Arr.Length - 1
                                                    p_SQL = p_SQL & "," & p_Arr(P_Count).Item("TableId").ToString.Trim

                                                Next
                                                If p_SQL <> "" Then
                                                    p_SQL = "exec  FPT_KhachHangTheoSoLenh '" & p_SoLenhGhep & "','" & p_SQL & "'"
                                                    p_TableCheck1 = GetDataTable(p_SQL, p_SQL)
                                                    If Not p_TableCheck1 Is Nothing Then
                                                        If p_TableCheck1.Rows.Count > 1 Then
                                                            ShowMessageBox("", "Mã ngăn " & p_RowChiTiet.Item("MaNgan").ToString.Trim & " có mã lệnh ghép khác Khách hàng")
                                                            KiemTraLineID_TableID = False
                                                            Exit Function
                                                        End If
                                                    End If
                                                End If

                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    End If
                End If
            Catch ex1 As Exception

            End Try

        Catch ex As Exception
            ShowMessageBox("", ex.Message)
            KiemTraLineID_TableID = False
        End Try

    End Function

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        Dim p_Client As String = ""
        Dim p_SQL As String = ""
        Dim p_Datatable As DataTable
        Dim p_SoLenh As String = ""
        If Me.FormStatus = True Then
            If KiemTraNgayThang() = False Then
                Exit Sub
            End If

            Me.SoTichKe.Focus()
            Me.GridView2.RefreshData()

            Me.Focus()

            SaveRecode()
        Else

            If g_KV1 = False Then
                If Not Me.SoLenh.EditValue Is Nothing Then
                    p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
                End If
                If p_SoLenh <> "" Then
                    p_SQL = "Select isnull(Client,'') as Client from tblLenhXuatE5 witk (nolock)  where SoLenh ='" & p_SoLenh & "'"
                    p_Datatable = GetDataTable(p_SQL, p_SQL)
                    If Not p_Datatable Is Nothing Then
                        If p_Datatable.Rows.Count > 0 Then
                            If p_Datatable.Rows(0).Item(0).ToString.Trim = "" Then
                                Me.FormStatus = False
                                '  Me.Client.EditValue = g_Terminal
                                If KiemTraNgayThang() = False Then
                                    Exit Sub
                                End If

                                Me.SoTichKe.Focus()
                                Me.GridView2.RefreshData()
                                Me.Focus()
                                SaveRecode()
                            End If
                        End If
                    End If

                End If

            End If
        End If
        '  End If
    End Sub



    'anhqh
    '20171211
    'Ham kiem tra neu lenh da in tich ke roi thi khong chay dong xoa (Neu co)
    Private Function KiemTraTrangThaiLenhKhiXoaNgan() As Boolean
        Dim p_SoLenh As String = ""
        Dim p_Table As DataTable
        Dim p_TableKT As DataTable
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_MaNgan, p_MaLenh, p_NgayXuat, p_LineID As String

        Dim p_Row_id As Integer
        Try


            If Not Me.SoLenh.EditValue Is Nothing Then
                p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
            End If
            If p_SoLenh <> "" Then
                p_SQL = "select Status from tbllenhxuate5 where solenh='" & p_SoLenh & "'"
                p_Table = GetDataTable(p_SQL, p_SQL)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        If p_Table.Rows(0).Item("Status").ToString.Trim = "3" Or p_Table.Rows(0).Item("Status").ToString.Trim = "31" Or p_Table.Rows(0).Item("Status").ToString.Trim = "4" Or p_Table.Rows(0).Item("Status").ToString.Trim = "5" Then
                            'Kiem tra trang thai lenh neu da in tich ke thi k cho xu ly xoa line
                            If Not pv_LineRemove Is Nothing Then
                                For p_Count = pv_LineRemove.Rows.Count - 1 To 0 Step -1
                                    '20240424 - Kiem tra neu lenh da in tichs ke thi khong cho xoa ngan
                                    If UCase(pv_LineRemove.Rows(p_Count).Item("TableName").ToString.Trim = UCase("tbllenhxuatchitiete5")) Then
                                        pv_LineRemove.Rows.RemoveAt(p_Count)
                                    End If
                                Next
                                pv_LineRemove.AcceptChanges()
                            End If

                            For p_Count = 0 To Me.GridView2.RowCount - 1
                                Integer.TryParse(GridView2.GetRowCellValue(p_Count, "Row_id").ToString.Trim, p_Row_id)
                                If p_Row_id = 0 Then

                                    If p_MaNgan <> "" Then
                                        ShowMessageBox("", "Trạng thái lệnh xuất không hợp lệ, không thêm ngăn " & p_MaNgan)
                                        Return False

                                    End If



                                    p_MaNgan = GridView2.GetRowCellValue(p_Count, "MaNgan").ToString.Trim
                                    p_MaLenh = GridView2.GetRowCellValue(p_Count, "MaLenh").ToString.Trim
                                    p_NgayXuat = CDate(GridView2.GetRowCellValue(p_Count, "NgayXuat")).ToString("yyyyMMdd")
                                    p_LineID = GridView2.GetRowCellValue(p_Count, "LineID").ToString.Trim
                                    '20240424 - Kiem tra trung ma ngan thi k duoc insert them
                                    p_SQL = "select 1 as ExistsID from tbllenhxuatchitiete5 with (nolock) where " & _
                                        " mangan ='" & p_MaNgan & "' and malenh ='" & p_MaLenh & "' and ngayxuat ='" & p_NgayXuat & "'  and lineid = '" & p_LineID & "' "
                                    p_TableKT = GetDataTable(p_SQL, p_SQL)
                                    If Not p_TableKT Is Nothing Then
                                        If p_TableKT.Rows.Count > 0 Then
                                            If p_TableKT.Rows(0).Item(0) = 1 Then
                                                ShowMessageBox("", "Trạng thái lệnh xuất không hợp lệ, trùng mã ngăn " & p_MaNgan)
                                                Return False
                                            End If
                                        End If

                                    End If
                                End If
                            Next

                        End If


                    End If
                End If
            End If
            Return True
        Catch ex As Exception
            ShowMessageBox("", ex.Message)
            Return False
        End Try
    End Function

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Dim p_Count As Integer
        Dim p_CountEnd As Integer = 0
        Dim p_SQL As String
        Dim p_DataRow As DataRow
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_DataTable As DataTable
        Dim p_Datatable1 As DataTable

        Dim p_SoLenh As String = ""
        Dim p_Status As String = ""
        Dim p_StatusTmp As String = ""
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

        p_StatusTmp = TrangThaiLenhXuat()
        If p_StatusTmp <> "1" And p_StatusTmp <> "2" Then
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


                    p_SQL = "select Row_ID  from FPT_tblLenhXuatChiTietE5_v  a where  Row_ID=" & p_DataRow.Item("Row_id").ToString.Trim & _
                                 " and exists (select 1 from tblLenhXuatE5 b with (nolock) where SoLenh=a.solenh and Status in ('3','31','4','5')) "
                    p_Datatable1 = GetDataTable(p_SQL, p_SQL)
                    If Not p_Datatable1 Is Nothing Then
                        If p_Datatable1.Rows.Count > 0 Then
                            Cursor = Cursors.Default
                            ShowMessageBox("", "Lệnh xuất có trạng thái không hợp lệ")
                            Exit Sub
                        End If
                    End If



                    p_SQL = p_DataRow.Item("Row_id").ToString.Trim
                    p_SQL = "Delete from tblLenhXuatChiTietE5 where  Row_id=" & p_SQL
                    p_DataRow = Me.pv_LineRemove.NewRow
                    p_DataRow.Item(0) = p_SQL

                    Try
                        p_DataRow.Item(1) = "tblLenhXuatChiTietE5"
                    Catch ex As Exception

                    End Try

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


    Function TrangThaiLenhXuat() As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable

        Dim p_SoLenh As String = ""
        TrangThaiLenhXuat = "1"
        Try
            If Not Me.SoLenh.EditValue Is Nothing Then
                p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
            End If

            p_SQL = "select Status from tblLenhXuatE5 where SoLenh='" & p_SoLenh & "'"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    TrangThaiLenhXuat = IIf(p_DataTable.Rows(0).Item("Status").ToString.Trim = "", "1", p_DataTable.Rows(0).Item("Status").ToString.Trim)
                End If
            End If

        Catch ex As Exception

        End Try
    End Function


    Private Sub Client_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Client.EditValueChanged

    End Sub

    Private Sub TrueDBGrid2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid2.Click

    End Sub



    Private Sub CmdHuyTichKe_Click(ByRef p_SoLenh As String)
        Dim p_MainForm As Object
        Dim frmCollection As New FormCollection()
        frmCollection = Application.OpenForms()
        If Not frmCollection.Item("FrmHuyTichKe") Is Nothing Then
            If frmCollection.Item("FrmHuyTichKe").IsHandleCreated Then
                p_MainForm = frmCollection.Item("FrmHuyTichKe")
                p_MainForm.Focus()
                ' p_MainForm.
                p_SoLenh = p_MainForm.p_SoLenh
            Else

                Dim p_FOrm1 As New FrmHuyTichKe()
                p_FOrm1.ShowDialog()
                p_SoLenh = p_FOrm1.p_SoLenh
            End If
        Else
            Dim p_FOrm As New FrmHuyTichKe()
            p_FOrm.ShowDialog()
            p_SoLenh = p_FOrm.p_SoLenh
        End If




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
        Dim p_Error As Boolean = False
        Dim p_Message As String = ""
        Dim p_TableUser As DataTable
        Dim FrmLenhXuatAdd As New FrmLyDo
        Dim p_LyDo As String = ""

        If p_TICHKE_HUY = True Then
            ' CmdHuyTichKe_Click(p_SoLenh)
            'GoTo LineTT1
            ShowMessageBox("", "Chức năng không được sử dụng")
            Exit Sub
        End If
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If

LineTT1:
        If p_SoLenh = "" Then
            Exit Sub
        End If

        'If Me.GhiChu.EditValue = "" Then
        '    ShowMessageBox("", "Nhập lý do vào trường Ghi Chú", 3)
        'End If

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

        ' If g_KV1 = False Then    '20230828 dung cho ca KV1
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

        'End If


        If Not p_DataTableTK Is Nothing Then
            If p_DataTableTK.Rows.Count > 1 Then  'Huy lenh gep
                For p_Count = 0 To p_DataTableTK.Rows.Count - 1
                    p_String = p_String & "," & p_DataTableTK.Rows(p_Count).Item(0).ToString.Trim
                Next
                If p_String <> "" Then
                    p_String = Mid(p_String, 2)
                End If

                '==============================20180510  Kiem tra bat ky lenh nao cua danh sach lenh ghep da xuat hang chua
                Dim p_bHuyTichKe As Boolean = False

                p_SQL = "select HuyLenh, HuyLenhEnd from SYS_USER where User_ID =" & g_User_ID & " and Getdate() <= isnull(HuyLenhEnd,getdate());"
                p_TableUser = GetDataTable(p_SQL, p_SQL)  ' p_DataSet.Tables(2)

                If Not p_TableUser Is Nothing Then
                    If p_TableUser.Rows.Count > 0 Then
                        If p_TableUser.Rows(0).Item("HuyLenh").ToString.Trim = "Y" Then
                            p_bHuyTichKe = True
                        End If
                    End If
                End If
                If p_bHuyTichKe = True Then
                    For p_Count = 0 To p_DataTableTK.Rows.Count - 1
                        p_SoLenh = p_DataTableTK.Rows(p_Count).Item(0).ToString.Trim
                        ''HuyTichKe(p_SoLenh)
                        p_Error = False
                        HuyTichKeKiemTra(p_Error, p_Message, p_SoLenh)
                        If p_Error = True Then
                            ShowMessageBox("", p_SoLenh & ": " & p_Message)
                            Exit Sub
                        End If
                    Next
                End If
                'Bo sung man hinh  ly do huy
                If g_Company_Code = "2110" Then
                    FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                    FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
                    'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim               
                    FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
                    FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                    FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
                    FrmLenhXuatAdd.ShowDialog(Me)
                    p_LyDo = FrmLenhXuatAdd.g_LyDoHuy
                    If p_LyDo = "" Then
                        Exit Sub
                    End If
                End If
                '==============================

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

                'Bo sung man hinh  ly do huy
                If g_Company_Code = "2110" Then
                    FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                    FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
                    'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim               
                    FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
                    FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                    FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
                    FrmLenhXuatAdd.ShowDialog(Me)
                    p_LyDo = FrmLenhXuatAdd.g_LyDoHuy
                    If p_LyDo = "" Then
                        Exit Sub
                    End If
                End If

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
                HuyTichKe(p_SoLenh, p_LyDo)
                p_DanhSachPTGhep = ""
                p_PTien1 = ""
                p_NVC1 = ""

            End If
        End If


        'FPT_KiemTra_HuyTichKe'
    End Sub



    Private Sub HuyTichKeKiemTra(ByRef p_Error As Boolean, ByRef p_Message As String, ByVal p_SoLenh As String)
        Dim p_SQL, p_Type, p_Terminal, p_LoaiHinhVanChuyen As String
        Dim p_DataSet As DataSet
        Dim e As System.EventArgs
        Dim p_TableUser As DataTable
        Dim p_bHuyTichKe As Boolean = False

        p_Terminal = g_Terminal
        If Not Me.Client.EditValue Is Nothing Then
            If Me.Client.EditValue.ToString.Trim <> "" Then
                p_Terminal = Me.Client.EditValue.ToString.Trim
            End If
        End If

        If Not Me.LoaiXuat.EditValue Is Nothing Then
            p_LoaiHinhVanChuyen = Me.LoaiXuat.EditValue.ToString.Trim
        End If

        p_SQL = "select * from SYS_CONFIG where KeyCode='WEBSERVER64';select * from tblconfig;" & _
                "select HuyLenh, HuyLenhEnd from SYS_USER where User_ID = " & g_User_ID & " and Getdate() <=HuyLenhEnd ;"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        p_SQL = "Y"
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then

                p_TableUser = p_DataSet.Tables(2)

                If Not p_TableUser Is Nothing Then
                    If p_TableUser.Rows.Count > 0 Then
                        If p_TableUser.Rows(0).Item("HuyLenh").ToString.Trim = "Y" Then
                            p_bHuyTichKe = True
                        End If

                    End If
                End If


                If p_DataSet.Tables(0).Rows.Count > 0 Then
                    p_SQL = p_DataSet.Tables(0).Rows(0).Item("KeyValue").ToString.Trim
                End If




                If p_DataSet.Tables(1).Rows.Count > 0 Then
                    p_Type = p_DataSet.Tables(1).Rows(0).Item("optional").ToString.Trim
                End If
            End If
        End If

        If p_Type = "FOX" Then
            ' Dim p_FOx_Obj As New FOX_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            'p_Message = p_FOx_Obj.clsScadar_HuyTichKe_fox(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        ElseIf p_Type = "ACC" Then
            ' Dim p_Acc_Obj As New ACCESS_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            ' p_Message = p_Acc_Obj.clsScadar_HuyTichKe_Access(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        Else

            p_Message = Scadar_HuyTichKeKiemtra(p_Error, g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)

            'End If

        End If


    End Sub

    Private Sub HuyTichKe(ByVal p_SoLenh As String, Optional ByVal p_LyDo As String = "")
        Dim p_Message, p_SQL, p_Type, p_Terminal, p_LoaiHinhVanChuyen As String
        Dim p_DataSet As DataSet
        Dim e As System.EventArgs
        Dim p_TableUser As DataTable


        p_Terminal = g_Terminal
        If Not Me.Client.EditValue Is Nothing Then
            If Me.Client.EditValue.ToString.Trim <> "" Then
                p_Terminal = Me.Client.EditValue.ToString.Trim
            End If
        End If

        If Not Me.LoaiXuat.EditValue Is Nothing Then
            p_LoaiHinhVanChuyen = Me.LoaiXuat.EditValue.ToString.Trim
        End If

        p_SQL = "select * from SYS_CONFIG where KeyCode='WEBSERVER64';select * from tblconfig;" & _
                "select HuyLenh, HuyLenhEnd from SYS_USER where User_ID = " & g_User_ID & " and Getdate() <=HuyLenhEnd ;"
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
        'If g_WCF = True Then
        '    'p_Message = Scadar_HuyTichKe(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        '    If p_Type = "FOX" Then
        '        ' Dim p_FOx_Obj As New FOX_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
        '        p_Message = g_Services.clsScadar_HuyTichKe_fox(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        '    ElseIf p_Type = "ACC" Then
        '        ' Dim p_Acc_Obj As New ACCESS_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
        '        'p_Message = p_Acc_Obj.clsScadar_HuyTichKe_Access(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        '    Else
        '        p_Message = Scadar_HuyTichKe(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        '    End If
        'Else
        If p_Type = "FOX" Then
            Dim p_FOx_Obj As New FOX_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            p_Message = p_FOx_Obj.clsScadar_HuyTichKe_fox(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        ElseIf p_Type = "ACC" Then
            Dim p_Acc_Obj As New ACCESS_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            p_Message = p_Acc_Obj.clsScadar_HuyTichKe_Access(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)
        Else

            'If p_bHuyTichKe = True Then

            'Else
            p_Message = Scadar_HuyTichKe(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal, p_LyDo)

            'End If

        End If
        'End If



        'p_Message = Scadar_HuyTichKe(g_WareHouse, "out", p_SoLenh, p_LoaiHinhVanChuyen, p_Terminal)

        If p_Message.ToString.Trim <> "" Then
            ShowMessageBox("", p_Message)
            Exit Sub
        Else

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

    Private Sub NguoiVanChuyen_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

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

    'Private Sub NguoiVanChuyen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Dim p_Value As String
    '    Dim p_Status As String = ""
    '    If Asc(e.KeyChar) = 13 Then
    '        If Not Me.Status.EditValue Is Nothing Then
    '            p_Status = Me.Status.EditValue.ToString.Trim

    '        End If
    '        If p_Status = "3" Or p_Status = "31" Or p_Status = "4" Or p_Status = "5" Then
    '            Exit Sub
    '        End If
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

        'If Me.GhiChu.EditValue Is Nothing Then
        '    ShowMessageBox("", "Ghi chú không được trống")
        '    Exit Sub
        'End If

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

        'p_DataTable.Columns.Add("STRSQL")
        'p_DataTable.Columns.Add("TableName")
        'p_Row = p_DataTable.NewRow
        'p_Row.Item(0) = "UPDATE tblLenhXuatE5 set UpdatedBy='" & g_UserName & "' where SoLenh='" & p_SoLenh & "'"
        'p_DataTable.Rows.Add(p_Row)
        'p_Status = ""
        'If g_Services.Sys_Execute_DataTbl(p_DataTable, p_Status) = False Then
        '    ShowMessageBox("", "Lỗi khi hủy lệnh xuất: " & p_Status)
        '    Exit Sub
        'End If

        p_DataTable.Clear()
        p_DataTable.Columns.Add("STRSQL")
        p_DataTable.Columns.Add("TableName")
        p_Row = p_DataTable.NewRow
        'anhqh 20160623
        p_Row.Item(0) = "delete from tblLenhXuatChiTietE5  where exists (select 1 from tblLenhXuat_HangHoaE5 u " & _
                " where u.LineID =tblLenhXuatChiTietE5.LineID and u.TableID =tblLenhXuatChiTietE5.TableID and  u.NgayXuat =tblLenhXuatChiTietE5.NgayXuat     and u.SoLenh='" & p_SoLenh & "')"

        Try
            p_Row.Item(1) = "tblLenhXuatChiTietE5"
        Catch ex As Exception

        End Try
        p_DataTable.Rows.Add(p_Row)


        p_Row = p_DataTable.NewRow
        p_Row.Item(0) = "delete from tblLenhXuat_HangHoaE5  " & _
                " where  SoLenh='" & p_SoLenh & "'"

        p_Row.Item(1) = "tblLenhXuat_HangHoaE5"
        p_DataTable.Rows.Add(p_Row)

        p_Row = p_DataTable.NewRow
        p_Row.Item(0) = "delete from tblLenhXuatE5  " & _
                " where  SoLenh='" & p_SoLenh & "'"
        p_Row.Item(1) = "tblLenhXuatE5"


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
        Dim p_Status As String = ""
        If UCase(e.Column.FieldName) = UCase("tableid") Then
            If Not e.Value Is Nothing Then
                p_Value = e.Value

                If p_DATNGAN_DX = True Then
                    If p_Value.ToString.Trim = "" Then
                        Me.GridView2.SetFocusedRowCellValue("SoLuongDuXuat", 0)
                        Me.GridView2.SetFocusedRowCellValue("TenHangHoa", "")
                        Me.GridView2.SetFocusedRowCellValue("SoLenh", "")
                    Else
                        Try
                            p_DuXuat = Me.GridView2.GetFocusedRowCellValue("DungTichNgan")
                            Me.GridView2.SetFocusedRowCellValue("SoLuongDuXuat", p_DuXuat)
                        Catch ex As Exception
                            Me.GridView2.SetFocusedRowCellValue("SoLuongDuXuat", 0)
                            Me.GridView2.SetFocusedRowCellValue("TenHangHoa", "")
                            Me.GridView2.SetFocusedRowCellValue("SoLenh", "")
                        End Try
                    End If
                Else
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
        End If
    End Sub



    Private Sub GridView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView2.KeyDown
        If g_Company_Code = "6610" Or g_Company_Code = "6620" Then
            If e.KeyCode = Keys.Enter Then
                Me.GridView2.FocusedRowHandle = Me.GridView2.FocusedRowHandle + 1
            End If
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


        Dim p_TaiTrongChoPhep As Integer

        '  Dim p_DataTableNew As DataTable
        Try
            KiemTraPhuongTienQuaTai = False
            p_SQL = ""
            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_SQL = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            p_SQL = GetLoadingSite(p_SQL)

            If UCase(p_SQL) <> "BO" And UCase(p_SQL) <> "THUY" Then
                Exit Function
            End If

            p_WeightRate = g_WeightRate
            p_TaiTrongChoPhep = g_TaiTrongChoPhep
            If UCase(p_SQL) = "THUY" Then
                p_TaiTrongChoPhep = g_TaiTrongChoPhep_Thuy
                p_WeightRate = 20
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
            'Kiem tra Tai trong Ptien la Romooc neu duoc khai bao tai trong
            If g_TaiTrongRomooc > 0 And InStr(p_DanhSachPTGhep, "R", CompareMethod.Text) > 0 And UCase(p_SQL) = "BO" Then
                p_TaiTrongChoPhep = g_TaiTrongRomooc
                p_WeightRate = g_WeightRateR
            End If
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
                                    'If Math.Round(((p_QCI_Kg / p_DataTable.Rows(0).Item("TaiTrong")) * 100), 0) - 100 >= p_TaiTrongChoPhep Then
                                    If Math.Round(((p_QCI_Kg * 100.0) / p_DataTable.Rows(0).Item("TaiTrong")), 4) - 100 >= p_TaiTrongChoPhep Then

                                        ShowMessageBox("", "Tổng lượng xuất vượt quá tải trọng phương tiện " & p_TaiTrongChoPhep & "%")
                                        KiemTraPhuongTienQuaTai = True
                                        Exit Function

                                    Else
                                        If Math.Round(((p_QCI_Kg / p_DataTable.Rows(0).Item("TaiTrong")) * 100), 2) - 100 >= p_WeightRate And Math.Round(((p_QCI_Kg / p_DataTable.Rows(0).Item("TaiTrong")) * 100), 0) - 100 < p_TaiTrongChoPhep Then
                                            p_ValueMess = g_Module.ShowMessage(Me, "", _
                                                "Tổng lượng xuất vượt quá tải trọng phương tiện " & Math.Round(((p_QCI_Kg / p_DataTable.Rows(0).Item("TaiTrong")) * 100), 2) - 100 & "%." & vbCrLf & "Bạn có muốn thực hiện tiếp không?", _
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

                                Try
                                    Dim p_Table As DataTable
                                    Dim p_PTienAo As String

                                    p_PTienAo = ""
                                    p_SQL = "select KeyValue from sys_config where keycode ='PTIEN_AO'"
                                    p_Table = GetDataTable(p_SQL, p_SQL)
                                    If Not p_Table Is Nothing Then
                                        If p_Table.Rows.Count > 0 Then
                                            p_PTienAo = p_Table.Rows(0).Item("KeyValue").ToString.Trim
                                        End If
                                    End If

                                    If InStr(p_PTienAo, p_abc.EditValue.ToString, CompareMethod.Text) > 0 Then
                                        ShowMessageBox("", "Phương tiện không hợp lệ")
                                        Exit Sub
                                    End If


                                Catch ex As Exception

                                End Try




                                p_SyncMaster = New SynMaster.Class1(g_WCF, g_Services, flag, lw_mess, isGetAll, _
                                                    g_dt, _SapConnectionString, _WareHouse, _dtVariable, g_Company_Code, _ShPoint)
                                If p_SyncMaster.ClsSyncMaster_SyncVehicleDownNew(p_abc.EditValue.ToString, p_Count, p_Desc, g_UserName) = False Then
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

                'anhqh
                '20161017
                If p_KT_TAITRONG = True Then
                    If KiemTraPhuongTienQuaTai(p_SoLenh, p_abc.EditValue.ToString.Trim) = True Then
                        e.Cancel = True
                        Exit Sub
                    End If
                End If

                'If KiemTraPhuongTienQuaTai(p_SoLenh, p_abc.EditValue.ToString.Trim) = True Then
                '    e.Cancel = True
                '    Exit Sub
                'End If

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
            'If g_KV1 = True Then
            '    p_SQL = ""
            '    If Not Me.MaVanChuyen.EditValue Is Nothing Then
            '        p_SQL = Me.MaVanChuyen.EditValue.ToString.Trim
            '    End If
            '    If p_SQL = "" Then
            '        Me.MaVanChuyen.EditValue = p_LoaiXuat
            '    End If
            '    p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
            '    Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)

            'End If
        End If

        'anhqh
        '20161005
        If g_KV1 = True Then
            p_SQL = ""
            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_SQL = Me.MaPhuongTien.EditValue.ToString.Trim
            End If
            CheckPhuongTien_LoaiXuat(p_SQL, p_CheckPT, p_SQL, p_LoaiXuat)

            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_SQL = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            If p_SQL = "" Then
                If Not p_LoaiXuat Is Nothing Then
                    Me.MaVanChuyen.EditValue = p_LoaiXuat

                    p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
                    Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)
                End If

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
                Dim p_LaiXeNgayDem As String = ""
                If p_LAINGAY = True Then
                    If Me.LenhNgay.Checked = True Then
                        p_LaiXeNgayDem = "Y"
                    Else
                        p_LaiXeNgayDem = "N"
                    End If
                End If

                If getNguoiVanChuyen(p_PhuongTien, p_NguoiVanChuyen, p_Desc, Me, p_LaiXeNgayDem) = False Then
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

                If KiemTraBarem_GiayToLaiXe(Me, p_MaPhuongTien, p_GIAYTO_XE, p_GIAYTO_LX, p_BAREM_XE) = False Then
                    Exit Sub
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


    'Private Sub NguoiVanChuyen_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    Dim p_PhuongTien As String = ""
    '    Dim p_NguoiVanChuyen As String
    '    Dim p_Desc As String
    '    Dim p_Status As String = "2"


    '    If Me.NguoiVanChuyen.IsModified = False Then
    '        Exit Sub
    '    End If

    '    'If p_PTien1 <> "" Then
    '    If p_NVC1 = "" Then
    '        If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
    '            p_NVC1 = Me.NguoiVanChuyen.EditValue.ToString.Trim
    '        End If
    '    End If
    '    ' End If


    '    If Not Me.Status.EditValue Is Nothing Then
    '        p_Status = Me.Status.EditValue.ToString.Trim
    '    End If

    '    If p_Status = "1" Or p_Status = "2" Or p_Status = "" Then
    '        If Me.FormEdit = False Then
    '            Exit Sub
    '        End If
    '        If Not Me.MaPhuongTien.EditValue Is Nothing Then
    '            p_PhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
    '        End If
    '        If p_PhuongTien = "" Then
    '            Exit Sub
    '        End If

    '        p_NguoiVanChuyen = ""
    '        If Not Me.NguoiVanChuyen.EditValue Is Nothing Then
    '            p_NguoiVanChuyen = Me.NguoiVanChuyen.EditValue.ToString.Trim
    '        End If
    '        If p_NguoiVanChuyen = "" Then
    '            Exit Sub
    '        End If

    '        If getNguoiVanChuyen(p_PhuongTien, p_NguoiVanChuyen, p_Desc, Me) = False Then
    '            ' ShowMessageBox("", p_Desc)
    '            e.Cancel = True
    '            Exit Sub
    '        End If
    '    End If
    'End Sub



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
            Try
                For p_Count = 0 To p_Table1.Rows.Count - 1
                    If p_Table1.Rows(p_Count).Item("MaPhuongTien").ToString.Trim() <> "" _
                        And KiemTraPhuongTienAo(p_Table1.Rows(p_Count).Item("MaPhuongTien").ToString.Trim()) = False Then
                        If InStr(p_MaPhuongTien, p_Table1.Rows(p_Count).Item("MaPhuongTien").ToString.Trim(), CompareMethod.Text) <= 0 Then
                            p_MaPhuongTien = p_MaPhuongTien & "," & p_Table1.Rows(p_Count).Item("MaPhuongTien").ToString.Trim()
                        End If

                    End If
                Next
            Catch ex As Exception

            End Try

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
                p_Row.Item(1) = Math.Round(((p_DuXuat / p_TaiTrongXe) * 100), 2) - 100
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
            If p_TANKAPPROVED = True Then
                p_SQL = "select TableID ,(select top 1 Name_nd from FPT_tblTankActive_V b  where  isnull(Tank_App,'N') ='Y' and (b.Product_nd = a.MaHangHoa) " & _
                          " and b.Date1= a.NgayTichKe 	and  (LoadingSite is null or LoadingSite ='' or upper(LoadingSite)=upper( :LoaiXuat ) ) " & _
                               " and left(Name_nd,LEN ('" & g_Terminal & "')) like '" & g_Terminal & "%'  " & _
                               " order by Name_nd ) as  BeXuat from fpt_tblLenhXuat_HangHoaE5_V1 A with (nolock) " & _
                              "  where  CHARINDEX(',' + SoLenh + ',','," & p_SoLenh & ",',1) > 0"
            Else
                p_SQL = "select TableID ,(select top 1 Name_nd from FPT_tblTankActive_V b  where    (b.Product_nd = a.MaHangHoa) " & _
                          " and b.Date1= a.NgayTichKe 	and  (LoadingSite is null or LoadingSite ='' or upper(LoadingSite)=upper( :LoaiXuat ) ) " & _
                       " and left(Name_nd,LEN ('" & g_Terminal & "')) like '" & g_Terminal & "%'  " & _
                       " order by Name_nd ) as  BeXuat from fpt_tblLenhXuat_HangHoaE5_V1 A with (nolock) " & _
                      "  where  CHARINDEX(',' + SoLenh + ',','," & p_SoLenh & ",',1) > 0"
            End If



            'where SoLenh='" & p_SoLenh & "'"

        Else
            p_SQL = "select TableID, (select top 1 Name_nd from FPT_tblTankActive_V b  where (b.Product_nd = a.MaHangHoa) " & _
                " and b.Date1=a.NgayTichKe 	and  (LoadingSite is null or LoadingSite ='' or upper(LoadingSite)=upper( :LoaiXuat ) ) " & _
              " order by Name_nd) as  BeXuat from fpt_tblLenhXuat_HangHoaE5_V1 A with (nolock) " & _
            "  where  CHARINDEX(',' + SoLenh + ',','," & p_SoLenh & ",',1) > 0"

            'where SoLenh='" & p_SoLenh & "'"
        End If

        If p_ThongTinNhomBe = False Then


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

    Private Sub NguoiVanChuyen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NguoiVanChuyen.GotFocus
        Dim p_Status As String = ""
        Dim p_MaVanChuyen As String = ""

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If p_Status = "" Or p_Status = "1" Or p_Status = "2" Then
            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
                If p_MaVanChuyen = "ZT" Then
                    If p_LAIXE_BO = True Then
                        Me.NguoiVanChuyen.Properties.ReadOnly = True
                    Else
                        Me.NguoiVanChuyen.Properties.ReadOnly = False
                    End If
                Else
                    If p_LAIXE_THUY = True Then
                        Me.NguoiVanChuyen.Properties.ReadOnly = True
                    Else
                        Me.NguoiVanChuyen.Properties.ReadOnly = False
                    End If
                End If
            End If
        End If

    End Sub

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

            If KiemTraBarem_GiayToLaiXe(Me, p_PhuongTien, p_GIAYTO_XE, p_GIAYTO_LX, p_BAREM_XE) = False Then
                e.Cancel = True
                Exit Sub
            End If

            If getNguoiVanChuyen(p_PhuongTien, p_NguoiVanChuyen, p_Desc, Me) = False Then
                ' ShowMessageBox("", p_Desc)
                e.Cancel = True
                Exit Sub
            End If


        End If
    End Sub

    Private Sub NguoiVanChuyen_EditValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NguoiVanChuyen.EditValueChanged

    End Sub

    Private Sub NguoiVanChuyen_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles NguoiVanChuyen.SizeChanged

    End Sub


    Private Sub ThongTinDiemTraHang()
        Dim p_DiemTRaHang As String = ""
        Dim p_DiemTRaHangOld As String = ""
        Dim p_ChuyenVanTai As String = ""
        Dim p_TimeOut = New TimeSpan()
        Dim p_SapConnectionString As String = ""
        Dim p_Status As String = ""
        Try
            If Not Me.Status.EditValue Is Nothing Then
                p_Status = Me.Status.EditValue.ToString.Trim
            End If
            If p_Status = "4" Or p_Status = "5" Then
                Exit Sub
            End If

            If Not Me.LoaiPhieu.EditValue Is Nothing Then
                p_ChuyenVanTai = Me.LoaiPhieu.EditValue.ToString.Trim
            End If

            If p_ChuyenVanTai = "" Or p_ChuyenVanTai = "V144" Then
                Exit Sub
            End If
            p_SapConnectionString = _dtVariable(0).Item("sapconnectionstring").ToString.Trim

            If g_WCF = True Then
                p_DiemTRaHang = g_Services.clsGetDiemTraHang(p_ChuyenVanTai, p_SapConnectionString,
                                         _dtVariable, p_TimeOut)
            Else
                Dim p_SAP_Obj As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
                p_DiemTRaHang = p_SAP_Obj.clsGetDiemTraHang(p_ChuyenVanTai, p_SapConnectionString,
                                         _dtVariable, p_TimeOut)
            End If

            If Not Me.DiemTraHang.EditValue Is Nothing Then
                p_DiemTRaHangOld = Me.DiemTraHang.EditValue.ToString.Trim
            End If
            If p_DiemTRaHang <> "" And p_DiemTRaHang <> p_DiemTRaHangOld Then
                Me.DiemTraHang.EditValue = p_DiemTRaHang
            End If
        Catch ex As Exception

        End Try


    End Sub

    Function KiemTraNgayThang() As Boolean
        Dim p_NgayThang As Date = Now.Date
        Dim p_CurentDate As Date
        Dim p_Time As Integer
        Try
            KiemTraNgayThang = True
            p_GetDateTime(p_CurentDate, p_Time)
            If Not Me.NgayXuat.EditValue Is Nothing Then
                p_NgayThang = Me.NgayXuat.EditValue
            End If

            If DateAdd(DateInterval.Day, 1, p_CurentDate) < p_NgayThang Then
                KiemTraNgayThang = False
                ShowMessageBox("", "Ngày tháng không hợp lệ")
            End If
            'If p_CurentDate Then

            'End If

        Catch ex As Exception
            KiemTraNgayThang = False
        End Try
    End Function



    Private Sub NgayXuat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NgayXuat.EditValueChanged

    End Sub

    Private Sub NgayXuat_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles NgayXuat.Validating
        If KiemTraNgayThang() = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub LenhNgay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LenhNgay.CheckedChanged
        'Dim p_Status As String = ""
        'If Not Me.Status.EditValue Is Nothing Then
        '    p_Status = Me.Status.EditValue.ToString.Trim
        'End If
        'If p_Status = "3" Or p_Status = "31" Or p_Status = "4" Or p_Status = "5" Then
        If Me.LenhNgay.Checked = True Then
            Me.LenhNgay.Text = "Lệnh ngày"
            ' Me.Dem.EditValue = "Y"
        Else
            Me.LenhNgay.Text = "Lệnh đêm"
            ' Me.Dem.EditValue = "N"
        End If
        'Else
        '    If Me.LenhNgay.Checked = True Then
        '        Me.LenhNgay.Text = "Lệnh ngày"
        '        Me.Dem.EditValue = "Y"
        '    Else
        '        Me.LenhNgay.Text = "Lệnh đêm"
        '        Me.Dem.EditValue = "N"
        '    End If
        'End If

    End Sub

    Private Sub CreateSMO()
        Dim p_MaPTien As String = ""
        Dim p_SoChuyen As Integer = 0
        Dim p_SQL As String = ""
        Dim p_Datatable As DataTable
        Dim p_Count As Integer
        Dim p_Exists As Boolean = False
        Dim p_NguoiVanTai As String = ""
        Dim p_ID As Integer = 0
        Dim p_NgayVaoKho As DateTime
        If Not Me.pTien.EditValue Is Nothing Then
            p_MaPTien = Me.pTien.EditValue.ToString.Trim
        End If

        If p_MaPTien = "" Then
            ShowMessageBox("", "Phương tiện chưa nhập")
            Me.pTien.Focus()
            Exit Sub
        End If

        p_SQL = "select Distinct top 1 MaPhuongTien, isnull(SoChuyen,0) as SoChuyen from dbo.tblSMO_INT a with (nolock)  " & _
                " where " & _
                 "   isnull(TrangThai_SMO,'') ='1' 	and MaPhuongTien ='" & p_MaPTien & "'"

        p_Datatable = GetDataTable(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Exists = True
            End If
        End If
        If p_Exists = False Then
            ShowMessageBox("", "Không xác định phương tiện")
            Me.pTien.Focus()
            Exit Sub
        End If


        If Me.NgayVaoKho.EditValue Is Nothing Then
            ShowMessageBox("", "Ngày vào kho không xác định")
            Exit Sub
        End If
        If Me.NgayVaoKho.EditValue.ToString.Trim = "" Then
            ShowMessageBox("", "Ngày vào kho không xác định")
            Exit Sub
        End If

        If Not Me.ID.EditValue Is Nothing Then
            Integer.TryParse(Me.ID.EditValue.ToString.Trim, p_ID)
        End If
        'If Not Me.sChuyen.EditValue Is Nothing Then
        '    Try
        '        Integer.TryParse(Me.sChuyen.EditValue.ToString.Trim, p_SoChuyen)
        '    Catch ex As Exception

        '    End Try

        'End If


        Dim p_dataset As DataSet
        If p_ID = 0 Then
            '   If p_Datatable.Rows.Count > 1 Then
            ShowMessageBox("", "Phương tiện không xác định")
            Me.pTien.Focus()
            Exit Sub
            'End If
            'p_SQL = "select  MaPhuongTien, SoLenh, NguoiLaiXe, Convert(date,NgayVaoKho) as NgayXuat from dbo.tblSMO_INT a with (nolock)  " & _
            '            " where Convert(date,NgayVaoKho)=convert(date, getdate()) " & _
            '         " and not exists (select 1 from tbllenhxuate5 b  with (nolock)  where a.SoLenh =b.SoLenh) and MaPhuongTien ='" & p_MaPTien & "' "

        Else
            'p_SQL = "select  MaPhuongTien, SoLenh, NguoiLaiXe, Convert(date,NgayVaoKho) as NgayXuat from dbo.tblSMO_INT a with (nolock)  " & _
            '            " where Convert(date,NgayVaoKho)=convert(date, getdate()) " & _
            '         " and not exists (select 1 from tbllenhxuate5 b  with (nolock)  where a.SoLenh =b.SoLenh) and MaPhuongTien ='" & p_MaPTien & "' " & _
            '        " and SoChuyen = " & p_SoChuyen

            If p_SoChuyen = 0 Then
                Integer.TryParse(p_Datatable.Rows(0).Item("SoChuyen").ToString.Trim, p_SoChuyen)
            End If
            p_SQL = "exec FPT_CheckDataSMO '" & p_MaPTien & "',0,'" & g_UserName & "'," & p_ID
            p_dataset = GetDataSet(p_SQL, p_SQL)
            If Not p_dataset Is Nothing Then
                If p_dataset.Tables.Count > 0 Then
                    If p_dataset.Tables(0).Rows(0).Item("Error") = 1 Then
                        If p_dataset.Tables(0).Rows(0).Item("sQuesion") = 1 Then
                            Dim p_ValueMess As Windows.Forms.DialogResult
                            p_ValueMess = p_XtraModuleObj.ShowMessage(Me, "", _
                                       p_dataset.Tables(0).Rows(0).Item("sError").ToString.Trim, _
                                       True, _
                                        "Có", _
                                       True, _
                                       "Không", _
                                       False, _
                                       "", _
                                        0)

                            If p_ValueMess = Windows.Forms.DialogResult.No Then
                                Cursor = Cursors.Default
                                Exit Sub
                            End If

                            p_SQL = "exec FPT_CheckDataSMO '" & p_MaPTien & "', 1,'" & g_UserName & "'," & p_ID
                            p_dataset = GetDataSet(p_SQL, p_SQL)
                        Else
                            ShowMessageBox("", p_dataset.Tables(0).Rows(0).Item("sError").ToString.Trim)
                            Exit Sub
                        End If
                    End If
                End If
            End If
        End If

        If Not p_dataset Is Nothing Then
            If p_dataset.Tables.Count > 0 Then
                p_Datatable = p_dataset.Tables(1)
            End If
        End If


        ' p_Datatable = GetDataTable(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            'TaoMoi()
            Cursor = Cursors.WaitCursor
            If p_MatKetNoiSAP = False Then

                If p_KIEMKE_N30 = True Then
                    p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(_SapConnectionString, "EN", 30, g_Company_Code, "", "")
                    If KiemTraThoiGianKiemKe_N30(p_ECCDestinationConfig, "T", p_Datatable, "") = True Then
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If

                Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

                For p_Count = 0 To p_Datatable.Rows.Count - 1
                    'Me.SoLenh.SendKey(System.Windows.Forms.KeyEventArgs 
                    ' Me.SoLenh.Focus()
                    'Me.SoLenh.EditValue = p_Datatable.Rows(p_Count).Item("SoLenh").ToString.Trim

                    If p_SAP_Object.clsSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_Datatable.Rows(p_Count).Item("SoLenh").ToString.Trim, p_SQL, p_Date_KV1) = False Then
                        Cursor = Cursors.Default
                        ShowMessageBox("", p_SQL)
                        Exit Sub
                    End If
                    p_SQL = "Update tblLenhXuatE5 set  PTIEN='" & p_Datatable.Rows(p_Count).Item("MaPhuongTien").ToString.Trim & "' " & _
                                ", NgayVaoKho='" & CDate(Me.NgayVaoKho.EditValue).ToString("MM-dd-yyyy HH:mm:ss") & "',  SMO_ID  =" & p_ID & " , MaPhuongTien='" & p_Datatable.Rows(p_Count).Item("MaPhuongTien").ToString.Trim & "' " & _
                                " , NguoiVanChuyen =N'" & p_Datatable.Rows(p_Count).Item("NguoiLaiXe").ToString.Trim & "' where SoLenh ='" & p_Datatable.Rows(p_Count).Item("SoLenh").ToString.Trim & "'"
                    '  SendKeys.SendWait("{ENTER}")
                    'SendKeys.Send("{ENTER}")

                    If g_Services.Sys_Execute(p_SQL, _
                                                 p_SQL) = False Then
                        'ShowMessageBox("", p_SQLErr)
                    Else
                        p_SQL = "Update tblSMO_INT set  TrangThai_SMO ='99'  where   SoLenh ='" & p_Datatable.Rows(p_Count).Item("SoLenh").ToString.Trim & "' and TrangThai_SMO ='1' "
                        '  SendKeys.SendWait("{ENTER}")
                        'SendKeys.Send("{ENTER}")

                        If g_Services.Sys_Execute(p_SQL, _
                                                     p_SQL) = False Then
                            'ShowMessageBox("", p_SQLErr)
                        End If
                    End If


                Next
            End If
            TaoMoi()
            For p_Count = 0 To p_Datatable.Rows.Count - 1
                ' Me.SoLenh.Focus()
                ' Me.SoLenh.EditValue = p_Datatable.Rows(p_Count).Item("SoLenh").ToString.Trim
                ' SendKeys.SendWait("{ENTER}")
                LoadSoLenhSMO(p_Datatable.Rows(p_Count).Item("SoLenh").ToString.Trim)
            Next
            Cursor = Cursors.Default
        End If

        Me.pTien.EditValue = ""
        Me.NgayVaoKho.EditValue = Nothing
        Me.ID.EditValue = 0
        '  Me.sChuyen.EditValue = 0
    End Sub



    Private Sub TaoMoi()
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

        Me.GridView2.Columns.Item("MaNgan").OptionsColumn.ReadOnly = False
        Me.GridView2.Columns.Item("TableID").OptionsColumn.ReadOnly = False
        ' Me.GridView2.Columns.Item("MaLuuLuongKe").OptionsColumn.ReadOnly = False
        If p_METERID_NGAN = False Then
            Me.GridView2.Columns.Item("MaLuuLuongKe").OptionsColumn.ReadOnly = True
        Else
            Me.GridView2.Columns.Item("MaLuuLuongKe").OptionsColumn.ReadOnly = False
        End If
        Me.GridView2.Columns.Item("SoLuongDuXuat").OptionsColumn.ReadOnly = False

        Me.GridView2.AllowInsert = True


        Me.GridView1.Columns.Item("MeterId").OptionsColumn.ReadOnly = False
        Me.GridView1.Columns.Item("BeXuat").OptionsColumn.ReadOnly = False


        ' LenhGhep(p_Value)
        GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom

        If (g_KV1 = True Or p_REFRESH = False) And p_SoLenh <> "" Then


        Else
            Me.SoLenh.EditValue = p_SoLenh
        End If

    End Sub

    Private Sub U_ButtonCus3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus3.Click
        CreateSMO()
    End Sub

    Private Sub pTien_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pTien.EditValueChanged

    End Sub

    Private Sub pTien_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles pTien.KeyDown
        Dim p_SQL As String = ""
        Dim p_Datatable As DataTable
        If e.KeyCode = Keys.Enter Then

            If e.KeyCode = Keys.Enter Then
                ' Your code here
                SendKeys.Send("{TAB}")
                'e.Handled = True
            End If
            'If Not Me.pTien.EditValue Is Nothing Then
            '    p_SQL = "SELECT *   FROM [tblSMO_INT] where  MaPhuongTien ='" & Me.pTien.EditValue.ToString.Trim & "' and isnull(TrangThai_SMO,'1') ='1'"
            '    p_Datatable = GetDataTable(p_SQL, p_SQL)
            '    If Not p_Datatable Is Nothing Then
            '        If p_Datatable.Rows.Count >= 1 Then
            '            If Not Me.NgayVaoKho.EditValue Is Nothing Then
            '                If Me.NgayVaoKho.EditValue.ToString.Trim <> "" Then
            '                    CreateSMO()
            '                End If
            '            End If
            '        End If
            '    End If
            '    'CreateSMO()
            'End If

            '  Me.sChuyen.Focus()
        End If
    End Sub

    'Private Sub sChuyen_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles sChuyen.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        'Me.sChuyen.Focus()
    '        Dim p_Ptien As String = ""
    '        Dim p_sChuyen As Integer = 0
    '        If Not Me.pTien.EditValue Is Nothing Then
    '            p_Ptien = Me.pTien.EditValue.ToString.Trim
    '        End If

    '        If Not Me.sChuyen.EditValue Is Nothing Then
    '            Integer.TryParse(Me.sChuyen.EditValue.ToString.Trim, p_sChuyen)
    '        End If
    '        If p_Ptien <> "" And p_sChuyen > 0 Then
    '            CreateSMO()
    '        End If
    '    End If
    'End Sub

    Private Sub U_ButtonCus4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus4.Click
        Dim FrmATG As New frmHuyChuyen
        FrmATG.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmATG.g_XtraServicesObj = g_XtraServicesObj
        FrmATG.g_FormTK = Me
        FrmATG.p_XtraToolTripLabel = g_ToolStripStatus
        FrmATG.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmATG.p_XtraMessageStatusl = g_MessageStatus
        FrmATG.ShowDialog(Me)

    End Sub

    Private Sub LoadSoLenhSMO(ByVal p_SoLenh As String)
        'If p_SoLenh <> "" Then
        Dim p_Value As String = ""
        Dim p_Status As String = ""
        Dim p_MaVanChuyen As String = ""
        'Me.GridView2.AllowInsert = False
        ' If Me.SoLenh.EditValue.ToString.Trim <> "" Then
        'Cursor = Cursors.WaitCursor
        p_Value = p_SoLenh



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
        'Me.Form1_Load(sender, e)
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()

Line_TT2:


        p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
        Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)

        ' LoadNewRow()
        Me.MaPhuongTien.UpdateWhenFormLock = False

        ' If Not Me.Status.EditValue Is Nothing Then
        'If InStr(",3,31,4,5,", "," & Me.Status.EditValue.ToString.Trim & ",", CompareMethod.Text) > 0 Then

        '    Me.ToolStripButton4.Enabled = p_InLaiTichKe
        '    If g_KV1 = True And Me.Status.EditValue.ToString.Trim = 3 Then
        '        Me.FormEdit = True
        '    Else
        '        Me.FormEdit = False
        '    End If

        '    Me.GridView2.OptionsBehavior.ReadOnly = True
        '    Me.GridView1.OptionsBehavior.ReadOnly = True
        '    Me.MaVanChuyen.Properties.ReadOnly = True
        '    ' Me.NguoiVanChuyen.Properties.ReadOnly = True
        '    If g_KV1 = True Then
        '        Me.NguoiVanChuyen.Properties.ReadOnly = False
        '    Else
        '        Me.NguoiVanChuyen.Properties.ReadOnly = True
        '    End If

        '    GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        '    If Me.Status.EditValue.ToString.Trim = "31" Or Me.Status.EditValue.ToString.Trim = "3" Then
        '        ' Me.MaPhuongTien.Properties.ReadOnly = False
        '        Me.MaPhuongTien.UpdateWhenFormLock = True
        '    End If
        'Else
        ' Me.ToolStripButton4.Enabled = True
        Me.FormEdit = True
        Me.GridView2.OptionsBehavior.ReadOnly = False
        Me.GridView1.OptionsBehavior.ReadOnly = False
        GridView1.Columns.Item("MeterId").OptionsColumn.ReadOnly = False
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
        ' End If
        ' Else
        Me.ToolStripButton4.Enabled = True
        '  End If
        Me.FormStatus = False
Line_tt:
        GopTichKe()

        'GanMaBeChoLenhXuat()
        '  GopTichKe()
        ' Cursor = Cursors.Default
        'Me.BtnOk.Text = "Ok"
        '  End If
        '   End If
        LoadNewRow()
        Me.U_ButtonCus1.Visible = p_HuyTichKe
        p_Status = ""

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If


        Me.TrueDBGrid2.EmbeddedNavigator.Buttons.Remove.Visible = True

        If Me.U_ButtonCus1.Visible = True Then

            If p_Status.ToString.Trim <> "3" Then

                Me.U_ButtonCus1.Visible = False
            End If
        End If

        '  Setfocus("SOLENH")

        ThongTinDiemTraHang()

        Me.FormStatus = False
        If p_SHOW_CLIENT = "0" Then
            Me.Client.Properties.ReadOnly = True
        End If

        Me.GridView1.BestFitColumns()
        Me.GridView2.BestFitColumns()
        Me.SoLenh.EditValue = p_SoLenh
        Me.MaPhuongTien.Focus()

    End Sub

    Private Sub aNumber_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aNumber.EditValueChanged

    End Sub

    Private Sub aNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles aNumber.Validating

    End Sub


    Private Function KiemTraGhepNganTheoKhachHang()

    End Function

    Private Function ZFM_CHECK_DO_CKG(ByVal p_SoLenh As String)
        Dim p_SQL As String
        Dim p_Table As System.Data.DataTable
        Dim p_ConnectSapString As String
        Dim p_TimeOut As String
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim o_err As String
        Dim e_Message As String

        p_SQL = "select * from tblConfig "
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_ConnectSapString = p_Table.Rows(0).Item("SapConnectionString").ToString.Trim
                Try
                    p_TimeOut = p_Table.Rows(0).Item("Timeout").ToString.Trim
                Catch ex As Exception
                End Try

                If p_TimeOut = "" Then
                    p_TimeOut = "60"
                End If
            End If
        End If

        p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
        e_Message = p_ECCDestinationConfig.clsZFM_CHECK_DO_CKG(p_SoLenh, o_err)
        If Not e_Message Is Nothing Then
            ' ShowMessageBox("", e_Message, 3)
        End If
    End Function

    Private Function ZFM_CHECK_XEPTAI_THUY(ByVal p_SoLenh As String, ByVal p_MaVanChuyen As String) As Boolean
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_Dataset As DataSet
        Dim p_Xeptai_Thuy As String

        ZFM_CHECK_XEPTAI_THUY = False

        If p_MaVanChuyen = "ZB" Or p_MaVanChuyen = "ZM" Then
        Else
            Exit Function
        End If

        p_SQL = "select * from SYS_CONFIG where KEYCODE = 'SMO_XEPTAI_THUY'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        Try
            p_Xeptai_Thuy = p_Table.Rows(0).Item("KEYVALUE").ToString.Trim
        Catch ex As Exception
        End Try

        If p_Xeptai_Thuy <> "Y" Then
            Exit Function
        End If

        p_SQL = String.Format("exec [FPT_KiemTraXepTaiXuatThuy] '{0}'", p_SoLenh)
        p_Dataset = GetDataSet(p_SQL, p_SQL)

        If Not p_Dataset Is Nothing Then
            If p_Dataset.Tables.Count > 0 Then
                ZFM_CHECK_XEPTAI_THUY = True
                ShowMessageBox("", p_Dataset.Tables(0).Rows(0).Item("ErrMess"), 3)
            End If
        End If
    End Function

    'Dung cho đơn vị có cấu hình lấy số lệnh theo chuỗi QRCode   SOLENH_QR= Y

    Private Sub GetSoLenh_QRCode(ByVal p_StringQR As String)
        Dim p_MaPTien As String = ""
        Dim p_SoChuyen As Integer = 0
        Dim p_SQL As String = ""
        Dim p_Datatable As New DataTable("TblLenhXuat")
        Dim p_DataTableDel As New DataTable("TblLenhXuat")
        Dim p_Count As Integer
        Dim p_Exists As Boolean = False
        Dim p_NguoiVanTai As String = ""
        Dim p_ID As Integer = 0
        Dim p_NgayVaoKho As DateTime
        Dim p_Row, p_DataRow As DataRow
        Dim p_Int As Integer
        Dim p_SoLenhArr() As String
        Dim p_Value As String
        p_Datatable.Columns.Add("SoLenh")

        p_DataTableDel.Columns.Add("STRSQL")

        p_DataTableDel.Columns.Add("TABLENAME")

        If Mid(p_StringQR, 1, 2) = "GC" Then
            p_SoLenhArr = p_StringQR.Split("|")
            For p_Int = 0 To p_SoLenhArr.Length - 1
                If Len(p_SoLenhArr(p_Int).ToString.Trim) = 10 Then
                    p_Row = p_Datatable.NewRow
                    p_Row.Item(0) = p_SoLenhArr(p_Int).ToString.Trim
                    p_Datatable.Rows.Add(p_Row)
                End If

            Next
        Else
            p_SoLenhArr = p_StringQR.Split(";")
            If p_SoLenhArr.Length > 0 Then
                p_Row = p_Datatable.NewRow
                p_Row.Item(0) = p_SoLenhArr(0).ToString.Trim
                p_Datatable.Rows.Add(p_Row)
            End If
        End If

        ' p_Datatable = GetDataTable(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count = 0 Then
                p_SQL = "Số lệnh không xác định"
                Cursor = Cursors.Default
                ShowMessageBox("", p_SQL)
                Exit Sub
            End If

            ''Xử lý các lệnh đã kéo về và trạng thái là 1''
            For p_Count = 0 To p_Datatable.Rows.Count - 1
                p_DataRow = p_DataTableDel.NewRow
                p_Value = p_Datatable.Rows(p_Count).Item("SoLenh").ToString.Trim
                p_SQL = "delete from tblLenhXuatChiTietE5  where " & _
                    " exists (select 1 from FPT_tblLenhXuatChiTietE5_V a  where a.SoLenh in (select SoLenh from tbllenhxuate5 where SoLenh = '" & p_Value & "' and isnull(status,'1')='1') and " & _
                              " a.SoLenh='" & p_Value & "'  and a.Row_id=tblLenhXuatChiTietE5.Row_id)"

                p_DataRow.Item(0) = p_SQL
                p_DataRow.Item(1) = "tblLenhXuatChiTietE5"

                p_DataTableDel.Rows.Add(p_DataRow)

                p_DataRow = p_DataTableDel.NewRow
                p_SQL = "delete from tblLenhXuat_HangHoaE5  where SoLenh='" & p_Value & "' and SoLenh in (select SoLenh from tbllenhxuate5 where SoLenh = '" & p_Value & "' and isnull(status,'1')='1')  "
                p_DataRow.Item(0) = p_SQL
                p_DataRow.Item(1) = "tblLenhXuat_HangHoaE5"

                p_DataTableDel.Rows.Add(p_DataRow)
                p_DataRow = p_DataTableDel.NewRow
                p_SQL = "delete from tblLenhXuatE5  where SoLenh='" & p_Value & "' and isnull(status,'1')='1'"
                p_DataRow.Item(0) = p_SQL
                p_DataRow.Item(1) = "tblLenhXuatE5"
                p_DataTableDel.Rows.Add(p_DataRow)
                If g_Services.Sys_Execute_DataTbl(p_DataTableDel, _
                                   p_SQL) = False Then
                    MsgBox("Error:" & p_SQL)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            Next


            p_SQL = ""







            p_SQL = ""
            Cursor = Cursors.WaitCursor
            If p_MatKetNoiSAP = False Then


                Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

                For p_Count = 0 To p_Datatable.Rows.Count - 1

                    If p_SAP_Object.clsSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_Datatable.Rows(p_Count).Item("SoLenh").ToString.Trim, p_SQL, p_Date_KV1) = False Then
                        Cursor = Cursors.Default
                        ShowMessageBox("", p_SQL)
                        Exit Sub
                    End If


                Next
                p_SAP_Object = Nothing

            End If
            TaoMoi()
            For p_Count = 0 To p_Datatable.Rows.Count - 1
                ' Me.SoLenh.Focus()
                ' Me.SoLenh.EditValue = p_Datatable.Rows(p_Count).Item("SoLenh").ToString.Trim
                ' SendKeys.SendWait("{ENTER}")
                LoadSoLenhSMO(p_Datatable.Rows(p_Count).Item("SoLenh").ToString.Trim)
            Next
            Cursor = Cursors.Default
        End If

        Me.pTien.EditValue = ""
        Me.NgayVaoKho.EditValue = Nothing
        Me.ID.EditValue = 0
        '  Me.sChuyen.EditValue = 0
    End Sub




    Private Sub SoLenh_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoLenh.EditValueChanged

    End Sub
End Class