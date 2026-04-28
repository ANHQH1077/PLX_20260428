Public Class FrmGhiNhanThucXuat
    Private flag As Integer()
    Private lw_mess As String()

    Private isGetAll As String
    Private g_dt As DataTable
    Private _TimeOut = New TimeSpan()

    Private _SapConnectionString As String
    Private _WareHouse As String
    Dim _dtVariable As DataTable
    Private _ShPoint As String

    Private p_SyncMaster As  SynMaster.Class1

    Dim p_SYS_MALENH_S As String = ""
    Dim p_FunctionTableId As String = ""
    Dim p_DateCreate As Date
    Dim p_TimeCreate As Integer
    Dim p_TableConfig As DataTable
    Dim p_TablePara As DataTable
    Dim p_DataTableDVT As DataTable

    Private BienBanGiaoNhan As Boolean = False
    Dim p_DataTableRoll As DataTable


    Private p_CHANGE_TANKE5 As Boolean = False

    Dim p_CURRENTDATE As Boolean = True
    '  Dim g_Terminal As String = "A"
    Public g_SoLenh_Q As String = ""
    Private p_APPROVED_DETAIL As Boolean = False
    Dim p_MATUDONGHOA As Boolean = False



    Private p_DataHeader As DataTable
    Private p_DataLine As DataTable
    Private p_AppEditSAP As Boolean = False

    Dim p_FromRate As Double = 0
    Dim p_ToRate As Double = 0

    Private p_makho As String = ""

    Private p_MALUULUONGKE As Boolean = False
    Private p_TableUser As DataTable

    Private p_TANKACTIVE As Boolean = True


    Private p_KT_CONGTO As Boolean = True
    Private p_KT_THOIGIAN As Boolean = True

    Private p_TYTRONG_PTANG As Boolean = False
    Private p_HHH As Boolean = True
    Private p_KT_NIEM As Boolean = True

    Private p_TaiXuat As Boolean = False

    'anhqh
    '20161031
    'Cac bien lien quan den phe duyet 3000L cho phep chenh lech 3L
    'Hien chi cau hinh cho KV2
    Private p_App3000 As Boolean = False
    Private p_App3000_Value As Integer = 3000
    Private p_App3000_App As Integer = 3

    Private p_Scadar_Type As String = "SQL"


    Private p_REFRESH As Boolean = True

    Private p_XITEC_OPTION As Boolean = False

    Private p_CHENHLECH_LUU As Boolean = False

    Private p_TONGDUXUAT As String = "0"
    Private p_TONGDUXUATTHUY As String = "0"


    Private p_L15_RESET As Boolean = False
    Private p_BBGN_ALL As Boolean = False
    Private p_MatKetNoiSAP As Boolean = False

    Private p_SMO_TICHKE As Boolean = False

    Private p_SMOAPI As Boolean = False

    Private p_B12HH As Boolean = False   '20240716 La HH tren server B12

    Private p_THONGTIN_BBGN As Boolean = False  'THONGTIN_BBGN 
    Private p_ThongTinNhomBe As Boolean = False

    Private p_NhomBeYesNo As Boolean = False

    Private p_NHIETDO_XE As Boolean = False
    Private p_NHIETDO_TIME As Integer = 10

    Private p_KHONG_TDH As Boolean = False
    Private p_CHIEUCAO_MD As Boolean
    Private p_NHIETDOXE_CHXD As Boolean
    Dim p_KIEMKE_N30 As Boolean = False

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
                If KiemTraHamhang() = False Then
                    Exit Sub
                End If
                SaveRecode()
            End If
        End If
    End Sub

    Private Sub FrmTaoMoiLenhXuat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim p_SQL As String
        Dim p_DataRow() As DataRow
        Dim p_MaVanChuyen As String
        Dim p_SQL_ALL As String
        Dim p_DataSet As DataSet
        Dim p_column As U_TextBox.GridColumn
        Dim p_column1 As U_TextBox.GridColumn

        '        Dim p_TableUser As DataTable
        Dim p_Datatbl As DataTable
        Dim p_TableConfig1 As DataTable
        '  Dim p_TONGDUXUAT As Integer = 0
        p_GetDateTime(p_DateCreate, p_TimeCreate)


        Me.HNhomBeXuat.Width = 0

        p_SQL_ALL = "select KEYCODE, KEYVALUE  from SYS_CONFIG;select Para, Value_nd  from tblPara  where Para in ('Bo','Thuy','Sat');" & _
                    "SELECT [Code] FROM [FPT_DonViTinh_V] ;select * from SYS_USER where USER_ID=" & g_User_ID & ";"
        p_SQL_ALL = p_SQL_ALL & "select * from SYS_ROLL1 where USER_ID=" & g_User_ID & " and CONVERT(date,getdate())>=  CONVERT (date,ISNULL(from_date,getdate()))" & _
                "  and CONVERT(date,getdate())<=  CONVERT (date,ISNULL(To_date,getdate())); " & _
                "select * from tblconfig ;"

        p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL_ALL, p_SQL)

        If Not p_DataSet Is Nothing Then
            p_TableConfig = p_DataSet.Tables(0)
            p_TablePara = p_DataSet.Tables(1)
            p_DataTableDVT = p_DataSet.Tables(2)
            p_TableUser = p_DataSet.Tables(3)

            p_Datatbl = p_DataSet.Tables(4)

            p_DataTableRoll = p_DataSet.Tables(4)

            p_TableConfig1 = p_DataSet.Tables(5)
        End If
        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                If p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim <> "" Then
                    p_makho = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                End If
                p_Scadar_Type = p_TableConfig1.Rows(0).Item("optional").ToString.Trim
            End If
        End If

        p_MALUULUONGKE = False

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

                p_DataRow = p_TableConfig.Select("KEYCODE='MATUDONGHOA'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_MATUDONGHOA = True
                    End If
                End If
                p_DataRow = p_TableConfig.Select("KEYCODE='APPROVED_DETAIL'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_APPROVED_DETAIL = True
                    End If
                End If


                p_DataRow = p_TableConfig.Select("KEYCODE='MALUULUONGKE'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_MALUULUONGKE = True
                    Else
                        p_MALUULUONGKE = False
                    End If
                End If

                'p_TANKACTIVE
                p_DataRow = p_TableConfig.Select("KEYCODE='TANKACTIVE'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_TANKACTIVE = False
                    End If
                End If


                'KT_CONGTO'
                p_KT_CONGTO = True
                p_DataRow = p_TableConfig.Select("KEYCODE='KT_CONGTO'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_KT_CONGTO = False
                    End If
                End If

                p_KT_THOIGIAN = True
                p_DataRow = p_TableConfig.Select("KEYCODE='KT_THOIGIAN'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_KT_THOIGIAN = False
                    End If
                End If

                'p_TYTRONG_PTANG
                p_TYTRONG_PTANG = False
                p_DataRow = p_TableConfig.Select("KEYCODE='TYTRONG_PTANG'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_TYTRONG_PTANG = True
                    End If
                End If

                'HHH
                p_HHH = True
                p_DataRow = p_TableConfig.Select("KEYCODE='HHH'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_HHH = False
                    End If
                End If

                p_DataRow = p_TableConfig.Select("KEYCODE='APP3000_VALUE'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        If IsNumeric(p_DataRow(0).Item("KEYVALUE").ToString.Trim) Then
                            p_App3000_Value = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                        End If
                    End If
                End If

                p_DataRow = p_TableConfig.Select("KEYCODE='APP3000_APP'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        If IsNumeric(p_DataRow(0).Item("KEYVALUE").ToString.Trim) Then
                            p_App3000_App = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                        End If
                    End If
                End If

                p_KT_NIEM = True
                p_DataRow = p_TableConfig.Select("KEYCODE='KT_NIEM'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_KT_NIEM = False
                    End If
                End If

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

                p_XITEC_OPTION = False
                p_DataRow = p_TableConfig.Select("KEYCODE='XITEC_OPTION'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_XITEC_OPTION = True
                    End If
                End If

                p_TONGDUXUAT = 0
                p_DataRow = p_TableConfig.Select("KEYCODE='TONGDUXUAT'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "1" Then
                        p_TONGDUXUAT = 1
                    End If
                End If


                'p_CHENHLECH_LUU'
                p_CHENHLECH_LUU = False
                p_DataRow = p_TableConfig.Select("KEYCODE='CHENHLECH_LUU'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_CHENHLECH_LUU = True
                    End If
                End If




                'p_DataRow = p_TableConfig.Select("KEYCODE='TONGDUXUAT'")
                'If p_DataRow.Length > 0 Then
                '    p_TONGDUXUAT = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                'End If

                p_DataRow = p_TableConfig.Select("KEYCODE='TONGDUXUATTHUY'")
                If p_DataRow.Length > 0 Then
                    p_TONGDUXUATTHUY = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                End If


                g_INTANK_E5 = False

                p_DataRow = p_TableConfig.Select("KEYCODE='INTANK_E5'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_INTANK_E5 = True
                    End If
                End If


                p_L15_RESET = False

                p_DataRow = p_TableConfig.Select("KEYCODE='L15_RESET'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_L15_RESET = True
                    End If
                End If

                p_CHANGE_TANKE5 = False
                p_DataRow = p_TableConfig.Select("KEYCODE='CHANGE_TANKE5'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_CHANGE_TANKE5 = True
                    End If
                End If

                BienBanGiaoNhan = True
                p_DataRow = p_TableConfig.Select("KEYCODE='BB_GD'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        BienBanGiaoNhan = True
                    Else
                        BienBanGiaoNhan = False
                    End If
                End If

                p_MatKetNoiSAP = False
                p_DataRow = p_TableConfig.Select("KEYCODE='SAPOFF'")
                If p_DataRow.Length > 0 Then

                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_MatKetNoiSAP = True
                    End If
                End If



                p_BBGN_ALL = False
                p_DataRow = p_TableConfig.Select("KEYCODE='BB_GD_ALL'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_BBGN_ALL = True
                    End If
                End If



                p_TaiXuat = False
                p_DataRow = p_TableConfig.Select("KEYCODE='TAIXUAT'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_TaiXuat = True
                    End If
                End If

                p_SMO_TICHKE = False
                p_DataRow = p_TableConfig.Select("KEYCODE='SMO_TICHKE'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_SMO_TICHKE = True
                    End If
                End If


                p_SMOAPI = False
                p_DataRow = p_TableConfig.Select("KEYCODE='SMOAPI'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_SMOAPI = True
                    End If
                End If

                p_B12HH = False
                p_DataRow = p_TableConfig.Select("KEYCODE='TAMMUC'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_B12HH = True
                    End If
                End If
                'Dim p_THONGTIN_BBGN As Boolean  'THONGTIN_BBGN 

                p_THONGTIN_BBGN = False
                p_DataRow = p_TableConfig.Select("KEYCODE='THONGTIN_BBGN'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_THONGTIN_BBGN = True
                    End If
                End If

                p_ThongTinNhomBe = False
                p_DataRow = p_TableConfig.Select("KEYCODE='TANK_GROUP'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_ThongTinNhomBe = True
                    End If
                End If


                p_NHIETDO_XE = False
                p_DataRow = p_TableConfig.Select("KEYCODE='NHIETDO_XE'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_NHIETDO_XE = True
                    End If
                End If

                p_DataRow = p_TableConfig.Select("KEYCODE='NHIETDO_TIME'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        Integer.TryParse(p_DataRow(0).Item("KEYVALUE").ToString.Trim, p_NHIETDO_TIME)
                    End If
                End If

                '','',''
                p_KHONG_TDH = False
                p_DataRow = p_TableConfig.Select("KEYCODE='KHONG_TDH'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_KHONG_TDH = True
                    End If
                End If
                p_CHIEUCAO_MD = False
                p_DataRow = p_TableConfig.Select("KEYCODE='CHIEUCAO_MD'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_CHIEUCAO_MD = True
                    End If
                End If
                p_NHIETDOXE_CHXD = False
                p_DataRow = p_TableConfig.Select("KEYCODE='NHIETDOXE_CHXD'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_NHIETDOXE_CHXD = True
                    End If
                End If

                p_KIEMKE_N30 = False
                p_DataRow = p_TableConfig.Select("KEYCODE='KIEMKE_N30'")
                If p_DataRow.Length > 0 Then
                    If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_KIEMKE_N30 = True
                    End If
                End If


            End If
        End If
        'p_SQL = "select * from tblConfig"
        '_dtVariable = GetDataTable(p_SQL, p_SQL)


        If p_ThongTinNhomBe = True Then
            Dim p_Tbl As DataTable
            p_SQL = "select isnull(NhomBeApp,'N') as NhomBeApp from [dbo].[SYS_USER] where upper(User_Name) =upper('sysadmin')"
            p_Tbl = GetDataTable(p_SQL, p_SQL)
            If Not p_Tbl Is Nothing Then
                If p_Tbl.Rows.Count > 0 Then
                    If p_Tbl.Rows(0).Item("NhomBeApp").ToString.Trim = "Y" Then
                        Me.ToolStripNhomBe.Visible = True
                    End If
                End If
            End If

        End If

        Dim p_Data As DataTable
        p_SQL = "select VatCancel from  sys_User  where upper(User_name) =upper('" & g_UserName & "') and isnull(U_HOADON,'') ='Y'"
        p_Data = GetDataTable(p_SQL, p_SQL)
        If Not p_Data Is Nothing Then
            If p_Data.Rows.Count > 0 Then
                ' Me.ToolStripButton3.Visible = True
                Me.ToolStripButton9.Visible = True
            End If
        End If



        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                _SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                _WareHouse = p_TableConfig1.Rows(0).Item("WareHouse").ToString.Trim
                _ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
            End If
        End If

        p_SyncMaster = New SynMaster.Class1(g_WCF, g_Services, flag, lw_mess, isGetAll, _
             g_dt, _SapConnectionString, _WareHouse, p_TableConfig1, g_Company_Code, _ShPoint)



        If p_XITEC_OPTION = True Then
            Me.U_CheckBox1.Visible = True
            If p_TONGDUXUAT = 0 Then
                '1: Lấy số dự xuât, 0: Lấy số thưc xuất
                Me.U_CheckBox1.Text = "Lấy số dự xuât"
            Else
                Me.U_CheckBox1.Text = "Lấy số thưc xuất"

            End If
        Else

            Me.U_CheckBox1.FieldName = ""
            Me.U_CheckBox1.ViewName = ""
            Me.U_CheckBox1.TableName = ""
            Me.U_CheckBox1.AllowInsert = False
            Me.U_CheckBox1.AllowUpdate = False
            Me.U_CheckBox1.Visible = False
        End If

        If BienBanGiaoNhan = True Then
            Me.ToolStripButton12.Visible = True
        End If

        If p_SMO_TICHKE = True Then
            Me.CmdSMO.Visible = True
        End If
        If p_L15_RESET = False Then

        Else
            ' Me.GridView1.Columns("HNhietDo").Fiel
            Dim p_ColumnAdd As U_TextBox.GridColumn

            p_ColumnAdd = New U_TextBox.GridColumn
            p_ColumnAdd.Name = "HNhietDo"
            p_ColumnAdd.FieldView = "NhietDo_BQGQ"
            p_ColumnAdd.FieldType = "N"
            p_ColumnAdd.Digit = True
            p_ColumnAdd.LocalDecimal = True
            p_ColumnAdd.NumberDecimal = 2
            p_ColumnAdd.Caption = "N Độ"
            p_ColumnAdd.OptionsColumn.AllowEdit = False
            p_ColumnAdd.VisibleIndex = Me.GridView1.Columns.Count + 1
            Me.GridView1.Columns.Add(p_ColumnAdd)

            p_ColumnAdd = New U_TextBox.GridColumn
            p_ColumnAdd.Name = "HTyTrong"
            p_ColumnAdd.FieldView = "D15_BQGQ"
            p_ColumnAdd.FieldType = "N"
            p_ColumnAdd.Digit = True
            p_ColumnAdd.LocalDecimal = True
            p_ColumnAdd.NumberDecimal = 4
            p_ColumnAdd.Caption = "D15"
            p_ColumnAdd.OptionsColumn.AllowEdit = False
            p_ColumnAdd.VisibleIndex = Me.GridView1.Columns.Count + 1
            Me.GridView1.Columns.Add(p_ColumnAdd)

            p_ColumnAdd = New U_TextBox.GridColumn
            p_ColumnAdd.Name = "HVCF"
            p_ColumnAdd.FieldView = "VCF"
            p_ColumnAdd.FieldType = "N"
            p_ColumnAdd.Digit = True
            p_ColumnAdd.LocalDecimal = True
            p_ColumnAdd.NumberDecimal = 4
            p_ColumnAdd.Caption = "VCF"
            p_ColumnAdd.OptionsColumn.AllowEdit = False
            p_ColumnAdd.VisibleIndex = Me.GridView1.Columns.Count + 1
            Me.GridView1.Columns.Add(p_ColumnAdd)

            'p_ColumnAdd = New U_TextBox.GridColumn
            'p_ColumnAdd.Name = "HWCF"
            'p_ColumnAdd.FieldView = "WCF"
            'p_ColumnAdd.FieldType = "N"
            'p_ColumnAdd.Digit = True
            'p_ColumnAdd.LocalDecimal = True
            'p_ColumnAdd.NumberDecimal = 4
            'p_ColumnAdd.Caption = "WCF"
            'p_ColumnAdd.OptionsColumn.AllowEdit = False
            'p_ColumnAdd.VisibleIndex = Me.GridView1.Columns.Count + 1
            'Me.GridView1.Columns.Add(p_ColumnAdd)

            p_ColumnAdd = New U_TextBox.GridColumn
            p_ColumnAdd.Name = "HL15"
            p_ColumnAdd.FieldView = "L15"
            p_ColumnAdd.FieldType = "N"
            p_ColumnAdd.Digit = True
            p_ColumnAdd.LocalDecimal = True
            p_ColumnAdd.NumberDecimal = 0
            p_ColumnAdd.Caption = "L15"
            p_ColumnAdd.OptionsColumn.AllowEdit = False
            p_ColumnAdd.VisibleIndex = Me.GridView1.Columns.Count + 1
            Me.GridView1.Columns.Add(p_ColumnAdd)

            p_ColumnAdd = New U_TextBox.GridColumn
            p_ColumnAdd.Name = "HKG"
            p_ColumnAdd.FieldView = "KG"
            p_ColumnAdd.FieldType = "N"
            p_ColumnAdd.Digit = True
            p_ColumnAdd.LocalDecimal = True
            p_ColumnAdd.NumberDecimal = 0
            p_ColumnAdd.Caption = "KG"
            p_ColumnAdd.OptionsColumn.AllowEdit = False
            p_ColumnAdd.VisibleIndex = Me.GridView1.Columns.Count + 1
            Me.GridView1.Columns.Add(p_ColumnAdd)
        End If

        If Not p_TableUser Is Nothing Then
            If p_TableUser.Rows.Count > 0 Then
                g_App_Grid = IIf(p_TableUser.Rows(0).Item("APP_GRID").ToString.Trim = "Y", True, False)
                p_AppEditSAP = IIf(p_TableUser.Rows(0).Item("AppEditSAP").ToString.Trim = "Y", True, False)
                Try
                    'App3000
                    p_App3000 = IIf(p_TableUser.Rows(0).Item("App3000").ToString.Trim = "Y", True, False)
                Catch ex As Exception

                End Try

            End If
        End If
        'CURRENTDATE
        p_DataRow = p_TableConfig.Select("KEYCODE='CURRENTDATE'")
        If p_DataRow.Length > 0 Then
            If p_DataRow(0).Item("KEYVALUE").ToString.Trim = "N" Then
                p_CURRENTDATE = False
            End If
        End If

     

        If p_MatKetNoiSAP = True And p_TaiXuat = True Then
            Me.So_TKTX.Visible = True
            Me.Ngay_TKTX.Visible = True
            Me.Label38.Visible = True
            Me.Label40.Visible = True
        Else
            Me.So_TKTX.FieldName = ""
            Me.Ngay_TKTX.FieldName = ""
        End If

        p_XtraUserName = g_User_ID

        If p_CURRENTDATE = True Then
            Me.NgayXuat.Enabled = False
        End If

        
        Dim p_Col As U_TextBox.GridColumn
        Dim p_Col1 As U_TextBox.GridColumn
        Dim p_int As Integer
        '20241123 Bo sung nhom be

        Me.HNhomBeXuat.Width = 0
        If p_ThongTinNhomBe = False Then

            For p_int = 0 To Me.GridView2.Columns.Count - 1
                p_Col = Me.GridView2.Columns.Item(p_int)
                If p_Col.Name = "NhomBeXuatTDH" Or p_Col.Name = "BeXuatTDH" Then
                    p_Col.Visible = False
                    p_Col.FieldView = ""

                End If
               
            Next
            'p_Col = Me.GridView2.Columns.Item("NhomBeXuatTDH")
            'p_Col.Visible = True
            'p_Col.VisibleIndex = 15
            'p_Col1 = Me.GridView2.Columns.Item("BeXuatTDH")
            'p_Col1.Visible = True
            'p_Col1.VisibleIndex = 16
            'Else
            '    p_Col = Me.GridView2.Columns.Item("NhomBeXuatTDH")
            '    p_Col.FieldView = ""
            '    p_Col1 = Me.GridView2.Columns.Item("BeXuatTDH")
            '    p_Col1.FieldView = ""
            Me.HNhomBeXuat.FieldName = ""
        End If

        If g_SoLenh_Q = "" Then
            Me.SoLenh.EditValue = ""
            Me.g_FormAddnew = False
            Me.DefaultWhere = "SoLenh=''"
            Me.DefaultFormLoad = True
            Me.Form1_Load(sender, e)

            ' Me.NgayXuat.EditValue = p_DateCreate
            'Me.BtnOk.Text = "Ok"
            Me.SoLenh.Focus()
        Else
            Me.DefaultFormLoad = True
            Me.Form1_Load(sender, e)
            p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
            Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)
            If Not Me.Status.EditValue Is Nothing Then
                If InStr(",4,5,", "," & Me.Status.EditValue.ToString.Trim & ",", CompareMethod.Text) > 0 And p_AppEditSAP = False Then
                    Me.FormEdit = False
                    Me.GridView2.OptionsBehavior.ReadOnly = True
                    Me.GridView1.OptionsBehavior.ReadOnly = True
                Else
                    Me.FormEdit = True
                    Me.GridView2.OptionsBehavior.ReadOnly = False
                    Me.GridView1.OptionsBehavior.ReadOnly = False
                    If Me.Client.EditValue Is Nothing Then
                        Me.Client.EditValue = g_Terminal
                    Else
                        If Me.Client.EditValue.ToString.Trim = "" Then
                            Me.FormStatus = False
                            Me.Client.EditValue = g_Terminal
                            GoTo Line_tt
                            '  Me.FormStatus = True
                        End If
                    End If
                End If
            End If
            Me.FormStatus = False
Line_tt:

            Set_Grid_Property()
        End If
        '   Me.GridView2.BestFitColumns()


        Approved.Enabled = g_App_Grid

        AppDesc.Properties.ReadOnly = Not g_App_Grid

        
       

        Try
            If p_MATUDONGHOA = True Then
                Me.GridView2.Columns.Item("MaTuDongHoa").VisibleIndex = 13
            Else
                Me.GridView2.Columns.Item("MaTuDongHoa").VisibleIndex = -1
            End If
        Catch ex As Exception

        End Try
        If g_Filter_Terminal = True Then
            p_column = Me.GridView1.Columns.Item("BeXuat")

            p_SQL = "select Name_nd as [Bể xuất] from FPT_tblTankActive_V where isnull(Tank_App,'N') ='Y' and Date1=:NgayXuat and Product_nd =:Column.MaHangHoa " & _
                  " and left(Name_nd,LEN ('" & g_Terminal & "')) like '" & g_Terminal & "%'  " & _
                    " and  (LoadingSite is null or LoadingSite ='' or upper(LoadingSite)=upper( :LoaiXuat ) )"



            If p_ThongTinNhomBe = True Then
                p_SQL = p_SQL & " and Name_nd in (select Name_nd from tblTankGroup  where getdate() >= isnull(FromDate,getdate() -1) and getdate() <= isnull(ToDate,getdate() +11) " & _
                                " and TankGroup  = :HNhomBeXuat) "
            End If


            p_column.SQLString = p_SQL



        End If

        Me.Client.Enabled = False

        'Me.GridView2.BestFitColumns()

        GetAppN30()
        'g_Terminal = g_Terminal

        Me.GridView2.OptionsSelection.MultiSelect = True
        GridView1.OptionsView.ColumnAutoWidth = False
        GridView2.OptionsView.ColumnAutoWidth = False

        If p_CHIEUCAO_MD = True Then
            Me.GridView2.Columns.Item("MaEntry").Visible = False
        Else
            Me.GridView2.Columns.Item("MaLo").Visible = False
        End If


        Me.GridView2.Columns.Item("DungTichNgan").Width = Me.GridView2.Columns.Item("SoLuongDuXuat").Width

        'Me.GridView1.BestFitColumns()
        '  Me.GridView2.BestFitColumns()
        If g_Company_Code = "2610" Then
            Me.ToolStripButton11.Visible = True
            Me.ToolStripButton13.Visible = True
        End If
    End Sub


    Private Sub GetAppN30()
        Dim p_VanChuyen As String = ""
        Dim p_Status As String = "1"
        Dim p_MaNguon As String = ""

        'Me.ToolStripButton6.Visible = True
        If g_E5 = False Then
            ToolStripButton6.Visible = False
        Else
            ToolStripButton6.Visible = True
        End If

        ' Me.ToolStripButton7.Visible = True
        Me.ToolStripButton5.Visible = False

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            p_VanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
        End If


        p_VanChuyen = GetLoadingSite(p_VanChuyen)

        If UCase(p_VanChuyen) = "THUY" Then
            Me.GridView2.Columns.Item("MaEntry").Visible = False
        Else
            Me.GridView2.Columns.Item("MaEntry").Visible = True
        End If

        If p_Status <> "3" And p_Status <> "31" Then
            Exit Sub
        End If



        If Not Me.MaNguon.EditValue Is Nothing Then
            p_MaNguon = Me.MaNguon.EditValue.ToString.Trim
        End If


        If UCase(p_VanChuyen) = "THUY" And (p_MaNguon = "N30" Or p_MaNguon = "N35" Or p_MaNguon = "N40" Or p_MaNguon = "N45") Then
            If g_AppN30 = "Y" Then
                Me.ToolStripButton6.Visible = False
                ' Me.ToolStripButton7.Visible = False
                Me.ToolStripButton5.Visible = True
            End If
        End If
    End Sub

    Private Sub SoLenh_InvalidValue(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs) Handles SoLenh.InvalidValue

    End Sub

    Private Sub LoadSoLenh(ByRef p_Err As Boolean)
        Dim p_ValueTmp As String = "0000000000"
        Dim p_Value As String
        Dim p_MaVanChuyen As String
        Dim p_DataTable As DataTable
        Dim p_SQL As String

        p_Err = False
        If Not Me.SoLenh.EditValue Is Nothing Then
            'Me.GridView2.AllowInsert = False
            If Me.SoLenh.EditValue.ToString.Trim <> "" Then
                p_Value = Me.SoLenh.EditValue.ToString.Trim

                p_SQL = "select top 1 SoLenh from tblLenhXuatE5 with (Nolock) where SoLenh='" & p_Value & "'"
                p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count <= 0 Then
                        ' ShowStatusMessage(True, "MS90561", "Số lệnh không hợp lệ", 5)
                        ShowMessageBox("", "Số lệnh không hợp lệ")
                        'Me.DefaultWhere = "SoLenh='00'"
                        'Me.DefaultFormLoad = True
                        'XtraForm1_Load()
                        p_Err = True
                        Exit Sub
                    End If
                End If
                Me.DefaultWhere = "SoLenh='" & p_Value & "'"
                Me.DefaultFormLoad = True
                XtraForm1_Load()
                ' Me.FormStatus = True
                p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
                Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)
                If Not Me.Status.EditValue Is Nothing Then
                    If InStr(",4,5,", "," & Me.Status.EditValue.ToString.Trim & ",", CompareMethod.Text) > 0 And p_AppEditSAP = False Then
                        Me.FormEdit = False
                        Me.GridView2.OptionsBehavior.ReadOnly = True
                        'Me.GridView1.OptionsBehavior.ReadOnly = True
                    Else
                        Me.FormEdit = True
                        Me.GridView2.OptionsBehavior.ReadOnly = False
                        Me.GridView1.OptionsBehavior.ReadOnly = False
                        If Me.Client.EditValue Is Nothing Then
                            Me.Client.EditValue = g_Terminal
                        Else
                            If Me.Client.EditValue.ToString.Trim = "" Then
                                Me.FormStatus = False
                                Me.Client.EditValue = g_Terminal
                                GoTo Line_tt
                                '  Me.FormStatus = True
                            End If
                        End If
                    End If
                End If
                Me.FormStatus = False
Line_tt:
                Set_Grid_Property()

                'Me.BtnOk.Text = "Ok"
            End If
        End If

        '   Me.GridView2.BestFitColumns()
        ' End If
        Me.GridView1.BestFitColumns()
        GetAppN30()

        If InStr(",4,5,", "," & Me.Status.EditValue.ToString.Trim & ",", CompareMethod.Text) > 0 And p_AppEditSAP = False Then
            ' Me.GridView1.Columns.Item("BeXuat").ReadOnly = False

        Else


            p_SQL = ""
            If Not Me.Niem.EditValue Is Nothing Then
                p_SQL = Me.Niem.EditValue.ToString.Trim
            End If

            If p_SQL = "" Then
                p_SQL = "exec FPT_NiemMacDinh '" & p_Value & "'"
                p_DataTable = GetDataTable(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        p_SQL = p_DataTable.Rows(0).Item(0).ToString.Trim
                        Me.Niem.EditValue = p_SQL
                    End If
                End If
            End If

            Try
                Dim p_Bidingsource As U_TextBox.U_BindingSource
                Dim p_Table As DataTable
                'p_Bidingsource = Me.TrueDBGrid2.DataSource
                'p_Table = CType(p_Bidingsource.DataSource, DataTable)

                Me.GridView2.Columns.Item("HeSo_K").OptionsColumn.ReadOnly = False
            Catch ex As Exception

            End Try



        End If
        Try
            Me.NguoiVanChuyen.Required = "Y"
            p_MaVanChuyen = Me.MaVanChuyen.EditValue
            If p_MaVanChuyen = "ZR" Then
                Me.NguoiVanChuyen.Required = "N"
            End If
        Catch ex As Exception

        End Try


        ' Me.Niem.Focus()
        Me.NhietDoTaiTau.Focus()
        Me.GridView1.Columns.Item("BeXuat").OptionsColumn.ReadOnly = False

        If p_CHIEUCAO_MD = True Then
            Me.GridView2.Columns.Item("MaEntry").Visible = False
        Else
            Me.GridView2.Columns.Item("MaLo").Visible = False
        End If

        'If p_AppEditSAP = False Then
        '    Me.GridView2.OptionsBehavior.ReadOnly = False
        'Else
        '    Me.GridView2.OptionsBehavior.ReadOnly = False
        'End If
    End Sub

    Private Sub SoLenh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SoLenh.KeyDown

        If e.KeyCode = Keys.Enter Then
            ReloadSoLenh()
        End If
    End Sub

    Public Sub ReloadSoLenh()
        Dim p_Err As Boolean
        LoadSoLenh(p_Err)
        If p_Err = True Then
            Exit Sub
        End If
        '  SetFoCus(SoLenh.Name)

        Me.GridView1.BestFitColumns()
        'Me.GridView2.BestFitColumns()
    End Sub
    '    Private Sub LenhGhep(ByVal p_SoLenh As String)
    '        Dim p_Binding As U_TextBox.U_BindingSource
    '        Dim p_DtLine As DataTable
    '        Dim p_DtHeader As DataTable
    '        Dim p_ArrRow() As DataRow
    '        Dim p_Count As Integer

    '        If Not p_DataHeader Is Nothing Then
    '            p_ArrRow = p_DataHeader.Select("SoLenh='" & p_SoLenh & "'")
    '            If p_ArrRow.Length > 0 Then
    '                GoTo line_TT
    '            End If
    '        End If

    '        p_Binding = New U_TextBox.U_BindingSource
    '        p_Binding = Me.GridView1.DataSource
    '        p_DtHeader = CType(p_Binding.DataSource, DataTable)
    '        If p_DataHeader Is Nothing Then
    '            p_DataHeader = New DataTable
    '            p_DataHeader = p_DtHeader
    '        Else
    '            p_DtHeader.Merge(p_DtHeader)
    '        End If
    'line_TT:
    '        p_Binding = New U_TextBox.U_BindingSource
    '        p_Binding = Me.GridView2.DataSource
    '        p_DtLine = CType(p_Binding.DataSource, DataTable)
    '        If p_DataLine Is Nothing Then
    '            p_DataLine = New DataTable
    '            p_DataLine = p_DtLine
    '        Else
    '            p_DataLine.Merge(p_DtLine)
    '        End If

    '        p_Binding = New U_TextBox.U_BindingSource
    '        p_Binding.DataSource = p_DataHeader
    '        Me.TrueDBGrid1.DataSource = p_Binding
    '        Me.TrueDBGrid1.Refresh()

    '        p_Binding = New U_TextBox.U_BindingSource
    '        p_Binding.DataSource = p_DataLine
    '        Me.TrueDBGrid2.DataSource = p_Binding
    '        Me.TrueDBGrid2.Refresh()

    '    End Sub

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
                If .IsDataRow(p_Count) = True And .IsRowSelected(p_Count) = True Then
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

                End If

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

    Function KiemTraThongTin(ByVal p_SoLenh As String, Optional ByVal p_KiemTraChenhLenh As Boolean = False) As Boolean

        Dim p_HDataTable As DataTable
        Dim p_LDataTable As DataTable
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
        Dim p_DataRow As DataRow

        Dim p_Status As String = ""

        KiemTraThongTin = False
        Try
            p_SQL = ""
            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_SQL = Me.MaPhuongTien.EditValue.ToString.Trim
            End If
            If p_SQL = "" Then
                ShowMessageBox("", "Số phương tiện chưa nhập")
                KiemTraThongTin = True
                Exit Function
            End If
            p_Binding = Me.GridView1.DataSource
            p_HDataTable = CType(p_Binding.DataSource, DataTable)
            p_Binding = Me.GridView2.DataSource
            p_LDataTableTmp = CType(p_Binding.DataSource, DataTable)
            p_LDataTable = p_LDataTableTmp.Clone
            p_LDataTable.Clear()
            For p_Count = 0 To p_LDataTableTmp.Rows.Count - 1

                If p_LDataTableTmp.Rows(p_Count).RowState <> DataRowState.Deleted Then
                    p_DataRow = p_LDataTable.NewRow   'p_LDataTableTmp.Rows(p_Count)
                    For p_LCount = 0 To p_LDataTableTmp.Columns.Count - 1
                        Try
                            p_DataRow.Item(p_LCount) = p_LDataTableTmp.Rows(p_Count).Item(p_LCount).ToString.Trim
                        Catch ex As Exception

                        End Try

                    Next
                    p_LDataTable.Rows.Add(p_DataRow)
                End If
            Next
            If Me.Approved.Checked = False Then
                If Not Me.Status.EditValue Is Nothing Then
                    p_Status = Me.Status.EditValue.ToString.Trim
                End If
                If p_Status = "31" Or p_Status = "4" Then
                    KiemTraThongTin = KiemTraTyLeChenhLech(p_KiemTraChenhLenh)
                End If

            End If

        Catch ex As Exception
            KiemTraThongTin = True
        End Try

    End Function


    Private Sub SetColorRow(ByVal p_RowID As Integer, ByVal p_Type As String)
        'GridView1.SelectCell 
        'GridView1.


        Exit Sub
        ' GridView1.

        '   Exit Sub
        '     Me.GridView2.SelectAll()
        Select Case p_Type
            Case "R"
                Me.GridView2.SelectRow(1)



                'GridView2.Appearance.HideSelectionRow.BackColor = Color.Red
                'GridView2.Appearance.HideSelectionRow.BackColor2 = Color.Red
                'GridView2.Appearance.HideSelectionRow.ForeColor = Color.White

                '' GridView1.Appearance.SelectedRow.BackColor = Color.Red
                ''GridView1.Appearance.FocusedRow.BackColor = Color.Red
                ''GridView1.Appearance.FocusedRow.BackColor2 = Color.Red


                ''GridView1.PaintAppearance.FocusedRow.BackColor = Color.Red
                ''GridView1.PaintAppearance.FocusedRow.BackColor2 = Color.Red

                '' GridView2.se.BackColor = Color.Red

                '' GridView2.SelectRow(Me.GridView2.FocusedRowHandle)
                '' GridView2.de()
                ''
                '' GridView2.Appearance.
                'GridView2.SelectRow(2)
                'GridView2.Appearance.SelectedRow.BackColor = Color.Red
                'GridView2.Appearance.SelectedRow.BackColor2 = Color.Red

                ''GridView2.Appearance.FocusedRow.BackColor = Color.Red
                ''GridView2.Appearance.FocusedRow.BackColor2 = Color.Red
                ''GridView2.Appearance.FocusedRow.ForeColor = Color.White



                '  GridView1.ro()
                '                GridView1.Appearance.FocusedRow = Color.Red
            Case "B"
                GridView2.Appearance.HideSelectionRow.BackColor = Color.Cyan
                GridView2.Appearance.HideSelectionRow.BackColor2 = Color.Cyan
                GridView2.Appearance.HideSelectionRow.ForeColor = Color.Cyan

            Case Else
                GridView2.Appearance.SelectedRow.BackColor = Color.White
                GridView2.Appearance.HideSelectionRow.ForeColor = Color.Black
        End Select

        '  GridView1.RefreshRow(p_RowID)


    End Sub


    Private Sub SetColorRowHangHoa(ByVal MaHangHoa As String, ByVal p_Type As String)
        'GridView1.SelectRow(p_RowID)



        Select Case p_Type
            Case "R"
                GridView1.Appearance.SelectedRow.BackColor = Color.Red
            Case "B"
                GridView1.Appearance.SelectedRow.BackColor = Color.Cyan
            Case Else
                GridView1.Appearance.SelectedRow.BackColor = Color.White
        End Select

        ' Me.GridView1.PaintAppearance.


    End Sub


    'Private Sub GridView1_RowStyle(ByVal sender As Object, _
    '    ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GridView2.RowStyle
    '    Dim View As U_TextBox.GridView = sender
    '    If (e.RowHandle >= 0) Then
    '        Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Record_Status"))
    '        If category = "Y" Then
    '            e.Appearance.BackColor = Color.Salmon
    '            e.Appearance.BackColor2 = Color.SeaShell
    '        End If
    '    End If
    'End Sub


    Sub SaveRecode(Optional ByVal p_KiemTraChenhLenh As Boolean = False)
        Dim p_DataRow As DataRow
        Dim p_mahanghoa As String
        Dim p_Datatable As DataTable
        Dim p_SQL As String = ""
        Dim p_LineIDTmp As String = "000000"
        Dim p_LineID As String = ""
        'Dim p_Date As String


        Dim p_MaLenh As String
        Dim p_SoLenh As String = ""
        Dim p_SoLenh_Line As String = ""
        Dim p_MaBe As String
        Dim p_TableID As String
        Dim p_Date As Date = Nothing
        Dim p_DataSet As DataSet
        Dim p_Status As String = "1"

        Dim p_NumErr As Integer = 0
        Dim p_Count As Integer = 0

        Dim p_Edit As Boolean = False
        Dim p_StatusLine As String = ""

        If p_CHENHLECH_LUU = True Then
            If KiemTraTyLeChenhLech(True) = True Then
                Exit Sub
            End If

        End If



        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If p_SoLenh = "" Then
            ShowStatusMessage(True, "MS005", "Số lệnh xuất chưa nhập", 5)
            Me.SoLenh.Focus()
            Exit Sub
        End If

        If g_Filter_Terminal = True Then
            p_SQL = ""
            If Not Me.Client.EditValue Is Nothing Then
                p_SQL = Me.Client.EditValue.ToString.Trim
            End If
            If p_SQL <> "" And p_SQL <> g_Terminal.ToString.Trim Then
                ShowMessageBox("", "Không sửa được thông tin lệnh xuất của kho khác")
                Exit Sub
            End If
        End If

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If KiemTraKhiLuuLenh(p_SoLenh, p_Status) = False Then
            Exit Sub
        End If


        p_SQL = ""

        Me.MaDonVi.EditValue = g_Company_Code

        If Me.NgayXuat.EditValue Is Nothing Then
            ShowStatusMessage(True, "MS0021", "Ngày tháng chưa nhập", 5)
            '    Exit Sub
            Exit Sub
        End If

        If KiemTraThongTin(p_SoLenh, p_KiemTraChenhLenh) = True Then
            Exit Sub
        End If
        p_Date = Me.NgayXuat.EditValue
        'Me.LoaiPhieu.EditValue = g_LoaiPhieu
        Try


            With Me.GridView1
                '.EndUpdate()
                For p_Count = 0 To .RowCount - 1
                    If .IsDataRow(p_Count) = True Then
                        p_DataRow = .GetDataRow(p_Count)
                        If p_DataRow Is Nothing Then
                            Continue For
                        End If
                        If p_DataRow.Item("TongXuat").ToString.Trim = "" Then
                            'ShowStatusMessage(True, "MS0051", "Chưa tính QCI", 10)
                            ShowMessageBox("MS0051", "Chưa tính QCI")
                            Exit Sub
                        End If

                        'MaEntry
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
            For p_Count = Me.GridView2.RowCount - 1 To 0 Step -1
                If GridView2.IsDataRow(p_Count) = True Then
                    p_StatusLine = ""
                    If Me.GridView2.GetRowCellValue(p_Count, "MaNgan").ToString.Trim = "" And Me.GridView2.GetRowCellValue(p_Count, "TableID").ToString.Trim = "" Then
                        Me.GridView2.DeleteRow(p_Count)
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

                        If g_KV1 = True Then
                            Try
                                If GridView2.GetRowCellValue(p_Count, "MaEntry").ToString.Trim = "" Then
                                    GridView2.SetRowCellValue(p_Count, "MaEntry", 0)
                                    GridView2.SetRowCellValue(p_Count, "CHECKUPD", "Y")
                                End If
                            Catch ex As Exception

                            End Try
                        End If

                        Try
                            p_StatusLine = GridView2.GetRowCellValue(p_Count, "CHECKUPD").ToString.Trim
                        Catch ex As Exception
                            p_StatusLine = ""
                        End Try
                        If p_StatusLine <> "" Then
                            p_Edit = True
                        End If

                    End If

                End If
            Next




            'anhqh
            '20160820
            'Cap nhat Niem neu co

            p_MaLenh = ""
            If Not Me.Niem.EditValue Is Nothing Then
                p_MaLenh = Me.Niem.EditValue.ToString.Trim
            End If

            If p_MaLenh <> "" Then
                p_SQL = "FPT_KiemTra_HuyTichKe '" & p_SoLenh & "','" & g_UserName & "'"
                p_DataSet = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSet Is Nothing Then
                    If p_DataSet.Tables.Count > 0 Then
                        p_Datatable = p_DataSet.Tables(1)
                        If p_Datatable.Rows.Count > 0 Then
                            For p_Count = 0 To p_Datatable.Rows.Count - 1
                                p_SQL = p_Datatable.Rows(p_Count).Item("SoLenh").ToString.Trim
                                If p_SQL = p_SoLenh Then
                                    Continue For
                                End If
                                p_SQL = "Update tblLenhXuatE5 set Niem ='" & p_MaLenh & "' where SoLenh='" & p_SQL & "' and Status  ='31' "
                                p_DataRow = pv_LineRemove.NewRow
                                p_DataRow.Item(0) = p_SQL
                                pv_LineRemove.Rows.Add(p_DataRow)
                            Next
                        End If
                    End If

                End If
            End If
            Me.DefaultSave = True
            UpdateToDatabase(Me, Me.ButtonSave)
            Me.DefaultSave = False

            'anhqh
            '20171225
            'Tinh lai L15 cho intank nếu có thay đổi tỷ trọng
            If p_Edit = True Then
                p_SQL = "exec FPT_TinhL15_Intank '" & p_SoLenh & "'"
                If g_Services.Sys_Execute(p_SQL, _
                                              p_SQL) = False Then
                    'ShowMessageBox("", p_SQLErr)
                End If
            End If


            'If Me.FormStatus = False Then
            '    p_SQL = "update tblLenhXuatE5 set Status='4' where SoLenh='" & p_SoLenh & "' "
            '    If g_Services.Sys_Execute(p_SQL, _
            '                              p_SQL) = False Then

            '    End If
            'End If
            'Me.GridView2.AllowInsert = False
            'GridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

        Catch ex As Exception
            p_XtraModuleObj.ModErrExceptionNew(Err.Number, ex.Message)
        End Try
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

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



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
                                    ShowMessageBox("", "Mã lệnh " & p_Row.Item("TableID").ToString.Trim & " và Mã LineID của chi tiết hàng hóa không đồng nhất.")
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

    Function KiemTRaTaiXuat() As Boolean
        Dim p_SQL As String = ""
        Dim p_PTBan As String = ""

        KiemTRaTaiXuat = False

        If Not Me.MaPhuongThucBan.EditValue Is Nothing Then
            p_PTBan = Me.MaPhuongThucBan.EditValue.ToString.Trim

        End If
        If p_MatKetNoiSAP = True And p_TaiXuat = True And (p_PTBan = "06" Or p_PTBan = "05") Then
            p_SQL = ""
            If Not Me.Ngay_TKTX.EditValue Is Nothing Then
                p_SQL = Me.Ngay_TKTX.EditValue.ToString.Trim
            End If
            If p_SQL = "" Then
                ShowMessageBox("", "Ngày TKTX chưa nhập")
                Exit Function
            End If

            p_SQL = ""
            If Not Me.So_TKTX.EditValue Is Nothing Then
                p_SQL = Me.So_TKTX.EditValue.ToString.Trim
            End If
            If p_SQL = "" Then
                ShowMessageBox("", "Số TKTX chưa nhập")
                Exit Function
            End If
        End If
        KiemTRaTaiXuat = True
    End Function

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim p_SoLenh As String
        Dim p_Status As String = ""
        Dim p_TrangThai As Boolean = False
        Dim p_Niem As String = ""
        Dim p_Desc As String = ""
        Dim p_RowAr() As DataRow
        Dim p_Row As DataRow
        Dim p_SQL As String
        Dim p_Table, p_Table12 As DataTable
        Dim p_MaVanChuyen As String = ""
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_Binding As U_TextBox.U_BindingSource
        Dim p_DateTime, p_DateTimeHH As DateTime
        Dim p_Int As Integer
        Dim p_NhietdoPTien As Double
        Dim p_ValueTime As Integer
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If

        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
        End If
        p_MaVanChuyen = GetLoadingSite(p_MaVanChuyen)

        If p_KT_NIEM = True Then
            If Not Me.Niem.EditValue Is Nothing Then
                p_Niem = Me.Niem.EditValue.ToString.Trim
            End If

            If p_Niem = "" Then
                ShowMessageBox("", "Giá trị Niêm chưa nhập")
                Exit Sub
            End If

        End If

        If KiemTRaTaiXuat() = False Then
            Exit Sub
        End If

        If Me.FormStatus = True Then
            ShowMessageBox("", "Lệnh xuất chưa được lưu")
            Exit Sub
        End If

        If KiemTraTyLeChenhLech(True) = True Then
            Exit Sub
        End If

        If KiemTraThongTinLenhXacNhan(p_SoLenh, p_Desc) = True Then
            ShowMessageBox("", p_Desc)
            Exit Sub
        End If

        If KiemTraHamhang() = False Then
            Exit Sub
        End If

        If g_Filter_Terminal = True Then
            p_SQL = ""
            If Not Me.Client.EditValue Is Nothing Then
                p_SQL = Me.Client.EditValue.ToString.Trim
            End If
            If p_SQL <> "" And p_SQL <> g_Terminal.ToString.Trim Then
                ShowMessageBox("", "Không thực hiện được với Lệnh xuất của kho khác")
                Exit Sub
            End If
        End If



        If p_KIEMKE_N30 = True Then
            Dim p_ECCDestinationConfig As New ECCDestination.ECCDestinationConfig(_SapConnectionString, "EN", 30, g_Company_Code, "", "")
            If KiemTraThoiGianKiemKe_N30(p_ECCDestinationConfig, "R", Nothing, p_SoLenh) = True Then
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If


        p_SQL = ""

        If KiemTraLineID_TableID() = False Then
            Exit Sub
        End If
        p_Binding = Me.TrueDBGrid2.DataSource
        p_Table12 = CType(p_Binding.DataSource, DataTable)
        If p_NHIETDO_XE = True And p_NHIETDO_TIME > 0 Then
            p_SQL = "select getdate() as nDateTime "
            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    p_DateTime = p_Table.Rows(0).Item(0)
                    For p_Int = 0 To p_Table12.Rows.Count - 1
                        If p_Table12.Rows(p_Int).Item("ThoiGianCuoi").ToString = "" Then
                            Continue For
                        End If
                        Try
                            p_DateTimeHH = p_Table12.Rows(p_Int).Item("ThoiGianCuoi")
                            p_ValueTime = DateDiff(DateInterval.Minute, p_DateTimeHH, p_DateTime)
                            If p_ValueTime > p_NHIETDO_TIME Then
                                Double.TryParse(p_Table12.Rows(p_Int).Item("HeSo_K").ToString.Trim, p_NhietdoPTien)
                                If p_NhietdoPTien = 0.0 Then
                                    ShowMessageBox("", "Ngăn " & p_Table12.Rows(p_Int).Item("MaNgan").ToString.Trim & " cần nhập N.Độ xe khi Giờ kết thúc xuất >" & p_NHIETDO_TIME & " phút")
                                    Exit Sub
                                End If
                            End If
                        Catch ex As Exception

                        End Try
                        
                    Next

                    'DateDiff(DateInterval.Minute


                End If

            End If
           
        End If


        If p_ThongTinNhomBe = True Then
            p_SQL = "exec XacNhanHoanThien_NhomBe '" & p_SoLenh & "'"
            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    If p_Table.Rows(0).Item(0) = 1 Then
                        ShowMessageBox("", p_Table.Rows(0).Item(1).ToString.Trim)
                        Exit Sub
                    Else
                        p_ValueMess = g_Module.ShowMessage(Me, "", _
                                           p_Table.Rows(0).Item(1).ToString.Trim, _
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
                        '20241125 cap nhat thong tin nhom be
                        Dim p_Table11 As DataTable
                        p_SQL = "exec CapNhatThongTin_NhomBe '" & p_SoLenh & "'"
                        p_Table11 = GetDataTable(p_SQL, p_SQL)
                        If Not p_Table11 Is Nothing Then
                            If p_Table11.Rows.Count > 0 Then
                                ShowStatusMessage(True, "", p_Table11.Rows(0).Item(1).ToString.Trim)
                                Exit Sub
                            End If
                        End If
                    End If

                End If
            End If

            'Me.DefaultFormLoad = True
            'Me.Form1_Load(sender, e)
            'p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
            'Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)
            'If Not Me.Status.EditValue Is Nothing Then
            '    If InStr(",4,5,", "," & Me.Status.EditValue.ToString.Trim & ",", CompareMethod.Text) > 0 And p_AppEditSAP = False Then
            '        Me.FormEdit = False
            '        Me.GridView2.OptionsBehavior.ReadOnly = True
            '        Me.GridView1.OptionsBehavior.ReadOnly = True
            '    Else
            '        Me.FormEdit = True
            '        Me.GridView2.OptionsBehavior.ReadOnly = False
            '        Me.GridView1.OptionsBehavior.ReadOnly = False
            '        If Me.Client.EditValue Is Nothing Then
            '            Me.Client.EditValue = g_Terminal
            '        Else
            '            If Me.Client.EditValue.ToString.Trim = "" Then
            '                Me.FormStatus = False
            '                Me.Client.EditValue = g_Terminal

            '                '  Me.FormStatus = True
            '            End If
            '        End If
            '    End If
            'End If
            'Me.FormStatus = False
        End If


        Dim p_FrmXacNhanThucXuat As New FrmXacNhanThucXuat(p_SoLenh)
        p_FrmXacNhanThucXuat.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        p_FrmXacNhanThucXuat.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
        p_FrmXacNhanThucXuat.g_FormAddnew = False
        p_FrmXacNhanThucXuat.FormStatus = False
        p_FrmXacNhanThucXuat.g_mavanchuyen = p_MaVanChuyen

        p_FrmXacNhanThucXuat.p_XtraToolTripLabel = g_ToolStripStatus
        p_FrmXacNhanThucXuat.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        p_FrmXacNhanThucXuat.p_XtraMessageStatusl = g_MessageStatus
        'p_TrangThai = p_FrmXacNhanThucXuat.p_Status
        p_FrmXacNhanThucXuat.ShowDialog(Me)
        p_TrangThai = p_FrmXacNhanThucXuat.p_Status
        If p_TrangThai = True Then
            If Not Me.Status.EditValue Is Nothing Then
                p_Status = Me.Status.EditValue.ToString.Trim
            End If
            If p_Status <> 4 And p_Status <> 5 Then
                Me.FormStatus = True
                Me.Status.EditValue = 4


                If Me.pv_TableEdit.Rows.Count <= 0 Then
                    ' p_RowAr = pv_TableEdit.Select("TableEdit='tblLenhXuatE5' OR TableEdit='TBLLENHXUATE5'")
                    'If p_RowAr.Length <= 0 Then
                    p_Row = Me.pv_TableEdit.NewRow
                    p_Row.Item(0) = "TBLLENHXUATE5"
                    pv_TableEdit.Rows.Add(p_Row)
                    'If

                Else
                    p_RowAr = pv_TableEdit.Select("TableEdit='tblLenhXuatE5' OR TableEdit='TBLLENHXUATE5'")
                    If p_RowAr.Length <= 0 Then
                        p_Row = Me.pv_TableEdit.NewRow
                        p_Row.Item(0) = "TBLLENHXUATE5"
                        pv_TableEdit.Rows.Add(p_Row)
                    End If
                End If


                SaveRecode(False)
                UpdateStatusDO(p_SMOAPI, p_SoLenh, "4")

                If Not Me.Status.EditValue Is Nothing Then
                    If InStr(",4,5,", "," & Me.Status.EditValue.ToString.Trim & ",", CompareMethod.Text) > 0 Then
                        Me.FormEdit = False
                        Me.GridView2.OptionsBehavior.ReadOnly = True
                        ' Me.GridView1.OptionsBehavior.ReadOnly = True
                    Else
                        Me.FormEdit = True
                        Me.GridView2.OptionsBehavior.ReadOnly = False
                        'Me.GridView1.OptionsBehavior.ReadOnly = False
                    End If
                End If

                SeStatusSMO()
            End If

        End If
    End Sub

    Private Sub SoLenh_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoLenh.EditValueChanged

    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

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
                    p_XtraModuleObj.ModErrExceptionNew("", "Đơn vị tính không đúng")
                    e.Valid = False
                    Exit Sub
                End If
            End If
        End If
        'e.Value

    End Sub

    Private Sub ToolAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolAuto.Click
        Dim p_SoLenh As String = ""
        Dim g_LoaiHinhVanChuyen As String = ""
        Dim p_SQLErr As String
        Dim p_Status As String = ""
        Dim p_MaVanChuyen As String
        Dim p_Terminal As String
        Dim p_SQL As String
        Dim p_DataSet As DataSet
        Dim p_Type As String = "SQL"

        Dim p_Count As Integer
        Dim p_CountLine As Integer
        Dim p_ArrRow() As DataRow
        Dim p_TableID_Line As String

        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig

        Dim p_DataTable As DataTable
        Dim p_DataTableL15 As DataTable

        Dim p_DataRow As DataRow
        Dim cl_SOAP_API As New SOAP_API.CL_SOAP_API
        Dim p_Density As String
        Dim cl_HTTG_COMMON As New HTTG_COMMON.CL_HTTG_COMMON
        cl_HTTG_COMMON.getSYS_CONFIG()

        p_Terminal = g_Terminal
        If Not Me.Client.EditValue Is Nothing Then
            If Me.Client.EditValue.ToString.Trim <> "" Then
                p_Terminal = Me.Client.EditValue.ToString.Trim
            End If
        End If

        'If Me.FormStatus = True Then
        '    ShowStatusMessage(False, "", "Thông tin lệnh xuất chưa được lưu", 4)
        '    Exit Sub
        'End If
        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If p_Status = "4" Or p_Status = "5" Then
            'ShowStatusMessage(False, "", "Trạng thái lệnh xuất không hợp lệ", 4)
            ShowMessageBox("", "Trạng thái lệnh xuất không hợp lệ")
            Exit Sub
        End If

        If Me.Approved.Checked = True Then
            ShowMessageBox("", "Lệnh xuất đã được phê duyệt")
            Exit Sub
        End If




        If g_Filter_Terminal = True Then
            p_SQL = ""
            If Not Me.Client.EditValue Is Nothing Then
                p_SQL = Me.Client.EditValue.ToString.Trim
            End If
            If p_SQL <> "" And p_SQL <> g_Terminal.ToString.Trim Then
                ShowMessageBox("", "Không thực hiện được với Lệnh xuất của kho khác")
                Exit Sub
            End If
        End If

        p_SQL = ""


        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If Not Me.LoaiXuat.EditValue Is Nothing Then
            g_LoaiHinhVanChuyen = Me.LoaiXuat.EditValue.ToString.Trim
        End If


        'If KiemTraThongTin(p_SoLenh) = True Then
        '    Exit Sub
        'End If

        If p_Status = "31" Then
            If GetAppScadar() = False Then
                ShowMessageBox("", "Lệnh đã được lấy từ họng xuất")
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

        If p_TANKACTIVE = True Then
            For p_Count = 0 To Me.GridView1.RowCount - 1
                p_DataRow = GridView1.GetDataRow(p_Count)
                If Not p_DataRow Is Nothing Then
                    If p_DataRow.Item("TableID").ToString.Trim <> "" Then
                        ' If p_DataRow.Item("BeXuat").ToString.Trim = "" Then
                        p_SQL = "select 1 as STT from FPT_tblTankActive_V  where date1=convert(date,getdate()) and Name_nd='" & p_DataRow.Item("BeXuat").ToString.Trim & "'"
                        p_DataTableDVT = GetDataTable(p_SQL, p_SQL)
                        If p_DataTableDVT.Rows.Count <= 0 Then
                            ShowMessageBox("", "Mã lệnh " & p_DataRow.Item("TableID").ToString.Trim & " chưa có Bể xuất ngày")
                            'KiemTraThongTin = True
                            Exit Sub
                        End If

                        'End If
                    End If
                End If
            Next
        End If

        'If p_SQL = "Y" Or UCase(p_Type) <> "FOX" Then
        '    ''64 bit va SQL
        '    p_SQLErr = g_Services.SYS_ScadarToHTTG("in", p_SoLenh, g_LoaiHinhVanChuyen, p_Terminal, True)
        'Else
        '    p_SQLErr = ScadarToHTTG("in", p_SoLenh, g_LoaiHinhVanChuyen, p_Terminal, True)
        'End If

        '   If Me.FormStatus = True Then
        'anhqh
        '20160820
        'Bo di khi form dang la edit
        If Me.FormStatus = True Then

            SaveRecode()
        End If

        p_SQL = "select a.Row_ID, a.NhietDo, a.TyTrong_15,a.SoLuongThucXuat, a.SoLuongDuXuat from FPT_tblLenhXuatChiTietE5_V  a,tblLenhXuatChiTietE5 b " & _
                        " where  a.Row_ID=b.Row_ID and a.SoLenh='" & p_SoLenh & "' " & _
                          " and  a.MaHangHoa  in (select MaHangHoa from tblHangHoaE5) "


        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            For p_Count = 0 To p_DataTable.Rows.Count - 1
                p_SQL = "Update tblLenhXuatChiTietE5 set GST =0 where Row_ID = " & p_DataTable.Rows(p_Count).Item("Row_ID")
                If g_Services.Sys_Execute(p_SQL, _
                                        p_SQL) = False Then
                    'ShowMessageBox("", p_SQLErr)
                End If
            Next

        End If
        If g_WCF = True Then

            If p_Scadar_Type = "FOX" Then
                p_SQLErr = g_Services.ClsScadarToHTTG_Fox("in", p_SoLenh, g_LoaiHinhVanChuyen, p_Terminal, True, g_E5)
            ElseIf p_Scadar_Type = "ACC" Then
                p_SQLErr = g_Services.ClsScadarToHTTG_Access("in", p_SoLenh, g_LoaiHinhVanChuyen, p_Terminal, True, g_E5)
            Else
                p_SQLErr = g_Services.SYS_ScadarToHTTG("in", p_SoLenh, g_LoaiHinhVanChuyen, p_Terminal, True, g_E5)
            End If

        Else
            If p_Scadar_Type = "FOX" Then
                Dim p_FOx_Obj As New FOX_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

                p_SQLErr = p_FOx_Obj.ClsScadarToHTTG_Fox("in", p_SoLenh, g_LoaiHinhVanChuyen, p_Terminal, True, g_E5)

            ElseIf p_Scadar_Type = "ACC" Then
                Dim p_Acc_Obj As New ACCESS_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

                p_SQLErr = p_Acc_Obj.ClsScadarToHTTG_Access("in", p_SoLenh, g_LoaiHinhVanChuyen, p_Terminal, True, g_E5)
            Else
                Dim p_SAP_Obj As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
                p_SQLErr = p_SAP_Obj.ClsScadarToHTTG("in", p_SoLenh, g_LoaiHinhVanChuyen, p_Terminal, True, g_E5)
            End If


        End If




        If p_SQLErr.ToString.Trim <> "" Then
            ShowMessageBox("", p_SQLErr)
        Else
            'anhqh 20180913
            'Hien dang dung cho KV1 cap nhat lai be E5 khi ruts hong xuat
            If p_CHANGE_TANKE5 = True Then
                'p_SQLErr = "select LineID, ngayxuat, tableid, Maluuluongke, " & _
                '     "(select TankE5 from tblmetere5  where meterid=a.Maluuluongke or convert(nvarchar(10),armno) =a.Maluuluongke) as BeXuat " & _
                '        " from fpt_tbllenhxuatchitiete5_v  a where mahanghoa in (select Mahanghoa from tblHanghoae5) and isnull(SoLuongThucXuat,0) >0 and solenh ='" & p_SoLenh & "'"
                p_SQLErr = "select LineID, ngayxuat, tableid, Maluuluongke, isnull(FlagTankLine,0) as FlagTankLine " & _
                            ",(select TankE5 from tblmetere5  where meterid=a.Maluuluongke or convert(nvarchar(10),armno) =a.Maluuluongke " & _
                            "	and upper(LoadingSite)  = (select dbo.FPT_GetLoadingSite (MaVanChuyen)  from tbllenhxuate5 where solenh =a.solenh) ) as BeXuat  " & _
                            ",(select Name_ND from tblmeter  where (meterid=a.Maluuluongke or  convert(nvarchar(10),armno) =a.Maluuluongke)  and ProductCode=a.MaHangHoa  " & _
                            "	and upper(LoadingSite)  = (select dbo.FPT_GetLoadingSite (MaVanChuyen)  from tbllenhxuate5 where solenh =a.solenh)) as BeXuatIntank  " & _
                            ", (select MeterID from tblmetere5  where meterid=a.Maluuluongke or convert(nvarchar(10),armno) =a.Maluuluongke  " & _
                             " and upper(LoadingSite)  = (select dbo.FPT_GetLoadingSite (MaVanChuyen)  from tbllenhxuate5 where  " & _
                             " solenh =a.solenh) ) as MeteridE5 " & _
                             " ,(select MeterID from tblmeter  where (meterid=a.Maluuluongke or  convert(nvarchar(10),armno) =a.Maluuluongke) " & _
                            " and ProductCode=a.MaHangHoa   and upper(LoadingSite)  = (select dbo.FPT_GetLoadingSite (MaVanChuyen)  " & _
                            "  from tbllenhxuate5 where solenh =a.solenh)) as Meterid  " & _
                             " from fpt_tbllenhxuatchitiete5_v  a where mahanghoa in (select Mahanghoa from tblHanghoae5)  " & _
                                " and isnull(SoLuongThucXuat,0) >0 and solenh ='" & p_SoLenh & "'"
                p_DataTable = GetDataTable(p_SQLErr, p_SQLErr)
                If Not p_DataTable Is Nothing Then
                    For p_Count = 0 To p_DataTable.Rows.Count - 1

                        If p_DataTable.Rows(p_Count).Item("BeXuat").ToString.Trim <> "" Or p_DataTable.Rows(p_Count).Item("BeXuatIntank").ToString.Trim <> "" Then
                            If p_DataTable.Rows(p_Count).Item("FlagTankLine") = 1 Then  'Xuat Inline
                                If p_DataTable.Rows(p_Count).Item("BeXuat").ToString.Trim = "" Then
                                    ShowMessageBox("", "Công tơ-Họng xuất của xuất InLine chưa được gắn theo Bể xuất" & vbCrLf & _
                                                    "Đề nghị khai báo và thực hiện lại")
                                    Exit Sub
                                End If

                                p_SQLErr = "update tbllenhxuat_hanghoae5    set  BeXuat = '" & p_DataTable.Rows(p_Count).Item("BeXuat").ToString.Trim & "' " & _
                                    " , MeterId = '" & p_DataTable.Rows(p_Count).Item("MeteridE5").ToString.Trim & "' " & _
                                " where solenh='" & p_SoLenh & "' and bexuat <> '" & p_DataTable.Rows(p_Count).Item("BeXuat").ToString.Trim & "' " & _
                                    " and tableid ='" & p_DataTable.Rows(p_Count).Item("tableid").ToString.Trim & "' " & _
                                     " and LineID ='" & p_DataTable.Rows(p_Count).Item("LineID").ToString.Trim & "' " & _
                                     " and ngayxuat ='" & CDate(p_DataTable.Rows(p_Count).Item("ngayxuat")).ToString("yyyyMMdd") & "' " & _
                                    ""
                            Else
                                If p_DataTable.Rows(p_Count).Item("BeXuatIntank").ToString.Trim = "" Then
                                    ShowMessageBox("", "Công tơ-Họng xuất của xuất Intank chưa được gắn theo Bể xuất" & vbCrLf & _
                                                    "Đề nghị khai báo và thực hiện lại")
                                    Exit Sub
                                End If
                                p_SQLErr = "update tbllenhxuat_hanghoae5    set  BeXuat = '" & p_DataTable.Rows(p_Count).Item("BeXuatIntank").ToString.Trim & "' " & _
                                    " , MeterId = '" & p_DataTable.Rows(p_Count).Item("Meterid").ToString.Trim & "' " & _
                                " where solenh='" & p_SoLenh & "' and bexuat <> '" & p_DataTable.Rows(p_Count).Item("BeXuatIntank").ToString.Trim & "' " & _
                                    " and tableid ='" & p_DataTable.Rows(p_Count).Item("tableid").ToString.Trim & "' " & _
                                     " and LineID ='" & p_DataTable.Rows(p_Count).Item("LineID").ToString.Trim & "' " & _
                                     " and ngayxuat ='" & CDate(p_DataTable.Rows(p_Count).Item("ngayxuat")).ToString("yyyyMMdd") & "' " & _
                                    ""
                            End If
                        End If

                        'If p_DataTable.Rows(p_Count).Item("BeXuat").ToString.Trim <> "" Or p_DataTable.Rows(p_Count).Item("BeXuatIntank").ToString.Trim <> "" Then
                        '    If p_DataTable.Rows(p_Count).Item("BeXuat").ToString.Trim <> "" Then
                        '        p_SQLErr = "update tbllenhxuat_hanghoae5    set  BeXuat = '" & p_DataTable.Rows(p_Count).Item("BeXuat").ToString.Trim & "' " & _
                        '            " , MeterId = '" & p_DataTable.Rows(p_Count).Item("MeteridE5").ToString.Trim & "' " & _
                        '        " where solenh='" & p_SoLenh & "' and bexuat <> '" & p_DataTable.Rows(p_Count).Item("BeXuat").ToString.Trim & "' " & _
                        '            " and tableid ='" & p_DataTable.Rows(p_Count).Item("tableid").ToString.Trim & "' " & _
                        '             " and LineID ='" & p_DataTable.Rows(p_Count).Item("LineID").ToString.Trim & "' " & _
                        '             " and ngayxuat ='" & CDate(p_DataTable.Rows(p_Count).Item("ngayxuat")).ToString("yyyyMMdd") & "' " & _
                        '            ""
                        '    Else
                        '        p_SQLErr = "update tbllenhxuat_hanghoae5    set  BeXuat = '" & p_DataTable.Rows(p_Count).Item("BeXuatIntank").ToString.Trim & "' " & _
                        '        " where solenh='" & p_SoLenh & "' and bexuat <> '" & p_DataTable.Rows(p_Count).Item("BeXuatIntank").ToString.Trim & "' " & _
                        '            " , MeterId = '" & p_DataTable.Rows(p_Count).Item("Meterid").ToString.Trim & "' " & _
                        '            " and tableid ='" & p_DataTable.Rows(p_Count).Item("tableid").ToString.Trim & "' " & _
                        '             " and LineID ='" & p_DataTable.Rows(p_Count).Item("LineID").ToString.Trim & "' " & _
                        '             " and ngayxuat ='" & CDate(p_DataTable.Rows(p_Count).Item("ngayxuat")).ToString("yyyyMMdd") & "' " & _
                        '            ""
                        '    End If
                        'End If

                        If g_Services.Sys_Execute(p_SQLErr, _
                                           p_SQLErr) = False Then
                            ShowMessageBox("", p_SQLErr)
                        End If
                    Next
                End If
            End If
            'anhqh
            '20160828
            p_SQLErr = ""
            If p_MALUULUONGKE = True Then
                p_SQLErr = "exec FPT_CapNhatLenhXuat '" & p_SoLenh & "'"
                If g_Services.Sys_Execute(p_SQLErr, _
                                              p_SQLErr) = False Then
                    ShowMessageBox("", p_SQLErr)

                End If

            End If
            If g_KV1 = True Or p_TYTRONG_PTANG = True Then
                p_SQLErr = "update tblLenhXuatChiTietE5 set MaEntry=0 " & _
                        "where exists (select 1 from FPT_tblLenhXuat_HangHoaE5_V  " & _
               " where(FPT_tblLenhXuat_HangHoaE5_V.TableID = tblLenhXuatChiTietE5.TableID)  " & _
                      " and FPT_tblLenhXuat_HangHoaE5_V.NgayXuat = tblLenhXuatChiTietE5.NgayXuat  " & _
                      "	and FPT_tblLenhXuat_HangHoaE5_V.SoLenh='" & p_SoLenh & "')  " & _
                      "	and MaEntry is null"
                If g_Services.Sys_Execute(p_SQLErr, _
                                              p_SQLErr) = False Then
                    ShowMessageBox("", p_SQLErr)
                End If

                ''Cap Nhat Ty trong
                p_SQL = "exec FPT_LayTyTrongBe '" & p_SoLenh & "'"
                If g_Services.Sys_Execute(p_SQL, _
                                              p_SQL) = False Then
                    'ShowMessageBox("", p_SQLErr)
                End If
            End If


            'anhqh
            '20170705
            'Cap nhạt lai L15 cho nhữg mặt hàng pha chế Intank xuất họng E5
            Dim p_Row_ID As Integer
            Dim p_NhietDo, p_TyTrong_15, p_SoLuongThucXuat, p_SoLuongDuXuat, p_Lit15, p_SoLuongXuat As Double

            If g_INTANK_E5 = True And p_L15_RESET = False Then
                'p_SQL = "select a.Row_ID, a.NhietDo, a.TyTrong_15,a.SoLuongThucXuat, a.SoLuongDuXuat from FPT_tblLenhXuatChiTietE5_V  a,tblLenhXuatChiTietE5 b " & _
                '        " where  a.Row_ID=b.Row_ID and a.SoLenh='" & p_SoLenh & "' " & _
                '          " and  isnull(  b.FlagTankLine,0) =0 and   (   isnull(b.GST,0) <=0   )  and a.MaHangHoa  in (select MaHangHoa from tblHangHoaE5)"

                p_SQL = "select a.Row_ID, a.TyTrong_15,a.SoLuongThucXuat, a.SoLuongDuXuat, " & _
                        "dbo.FPT_ROUNDNUMBER(  (select sum(NhietDo)/sum(LuongXuat) as NhietDo from (select " & _
                            " isnull(NhietDo,0)  *  dbo.FPT_LaySoThucXuat ( (select top 1 mavanchuyen from tbllenhXuate5 where solenh=a.solenh)  " & _
                            " ,SoLuongThucXuat, SoLuongDuXuat,0)   as NhietDo " & _
                                                    " ,dbo.FPT_LaySoThucXuat ( (select top 1 mavanchuyen from tbllenhXuate5 where solenh=a.solenh)  " & _
                            " ,SoLuongThucXuat, SoLuongDuXuat,0) as LuongXuat	 " & _
                                                 " from fpt_tbllenhxuatchitiete5_v a11 where solenh='" & p_SoLenh & "' " & _
                                                 "  and Row_ID in (select a.row_id from FPT_tblLenhXuatChiTietE5_V  a,tblLenhXuatChiTietE5 b " & _
                                                " where  a.Row_ID=b.Row_ID and a.SoLenh='" & p_SoLenh & "' " & _
                                                     " and  isnull(  b.FlagTankLine,0) =0 and   (   isnull(b.GST,0) <=0  or  ('" & IIf(g_E5 = True, "TRUE", "FALSE") & "' ='FALSE' and isnull(b.GST,0) >=0  ))  and a.MaHangHoa  in (select MaHangHoa from tblHangHoaE5)) " & _
                                                    ") abc	 " & _
                                              " having sum(LuongXuat) <> 0 ),2)  as NhietDo  " & _
                    " from FPT_tblLenhXuatChiTietE5_V  a,tblLenhXuatChiTietE5 b " & _
                    " where  a.Row_ID=b.Row_ID and a.SoLenh='" & p_SoLenh & "' " & _
                         " and isnull( a.TyLe_TTe ,0) <=1 and  isnull(  b.FlagTankLine,0) =0 and   (   isnull(b.GST,0) <=0  or  ('" & IIf(g_E5 = True, "TRUE", "FALSE") & "' ='FALSE' and isnull(b.GST,0) >=0  ))  and a.MaHangHoa  in (select MaHangHoa from tblHangHoaE5)"
                p_DataTable = GetDataTable(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    For p_Count = 0 To p_DataTable.Rows.Count - 1
                        Integer.TryParse(p_DataTable.Rows(p_Count).Item("Row_ID").ToString.Trim, p_Row_ID)
                        Double.TryParse(p_DataTable.Rows(p_Count).Item("NhietDo").ToString.Trim, p_NhietDo)
                        Double.TryParse(p_DataTable.Rows(p_Count).Item("TyTrong_15").ToString.Trim, p_TyTrong_15)
                        Double.TryParse(p_DataTable.Rows(p_Count).Item("SoLuongThucXuat").ToString.Trim, p_SoLuongThucXuat)
                        Double.TryParse(p_DataTable.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim, p_SoLuongDuXuat)



                        If UCase(g_LoaiHinhVanChuyen) = "THUY" Then

                            If p_TONGDUXUATTHUY = "1" Then   'Lay theo du xuat
                                p_SoLuongXuat = p_SoLuongDuXuat
                            Else   'Lay theo thuc xuat

                                p_SoLuongXuat = p_SoLuongThucXuat
                            End If
                        Else

                            If p_TONGDUXUAT = "1" Then   'Lay theo du xuat

                                p_SoLuongXuat = p_SoLuongDuXuat
                            Else   'Lay theo thuc xuat

                                p_SoLuongXuat = p_SoLuongThucXuat
                            End If
                        End If
                        p_SQL = "exec dbo.zzFPT_mdlQCI_CalculateQCI_NS_QC " & _
                                      p_SoLuongXuat & "," & _
                                      "'L'," & _
                                      p_NhietDo & "," & p_TyTrong_15 & ",'','' "
                        p_DataTableL15 = GetDataTable(p_SQL, p_SQL)

                        ' p_Vcf = ""
                        p_Lit15 = 0

                        If Not p_DataTableL15 Is Nothing Then
                            If p_DataTableL15.Rows.Count > 0 Then
                                Double.TryParse(p_DataTableL15.Rows(0).Item(1).ToString.Trim, p_Lit15)

                            End If
                        End If
                        Try
                            p_Lit15 = NhietDoLamTron(p_Lit15, 0)
                        Catch ex As Exception

                        End Try

                        p_SQL = "update  tblLenhXuatChiTietE5 set    GST = " & p_Lit15 & " where Row_ID=" & p_Row_ID
                        If g_Services.Sys_Execute(p_SQL, _
                                              p_SQLErr) = False Then
                            ShowMessageBox("", p_SQLErr)
                        End If
                    Next
                End If


            End If


            If p_ThongTinNhomBe = True Then
                p_SQLErr = "update tblLenhXuatE5 set Status='31' , NhomBeAPP =null , NhomBeAPPD =null , NhomBeAPPU  =null, ThongTinTDH ='Y'   where solenh= '" & p_SoLenh & "'"
            Else
                p_SQLErr = "update tblLenhXuatE5 set Status='31', ThongTinTDH ='Y'   where solenh= '" & p_SoLenh & "'"
            End If
            'p_SQLErr = "update tblLenhXuatE5 set Status='31' where solenh= '" & p_SoLenh & "'"
            If g_Services.Sys_Execute(p_SQLErr, _
                                          p_SQLErr) = False Then
                ShowMessageBox("", p_SQLErr)
            Else
                UpdateStatusDO(p_SMOAPI, p_SoLenh, "31")
            End If

            p_SQL = "exec FPT_UPDATE_GVE '" & p_SoLenh & "'"
            If g_Services.Sys_Execute(p_SQL, _
                                          p_SQL) = False Then
                'ShowMessageBox("", p_SQLErr)
            End If



            p_SQL = "update tbllenhxuatchitiete5  set GST_TDH =GST, ThongTinTDH ='Y', TrangThai =null " & _
                 "  where row_ID in (select row_id from fpt_tbllenhxuatchitiete5_v where solenh ='" & p_SoLenh & "')"
            If g_Services.Sys_Execute(p_SQL, _
                                          p_SQL) = False Then
                'ShowMessageBox("", p_SQLErr)
            End If

            'Dim p_Binding As U_TextBox.U_BindingSource
            'Dim p_Table12, p_Table As DataTable
            'Dim p_DateTime, p_DateTimeHH As DateTime
            'Dim p_ValueTime As Integer
            'Dim p_NhietdoPTien As Double

            'p_Binding = Me.TrueDBGrid2.DataSource
            'p_Table12 = CType(p_Binding.DataSource, DataTable)
            'If p_NHIETDO_XE = True And p_NHIETDO_TIME > 0 Then
            '    p_SQL = "select getdate() as nDateTime "
            '    p_Table = GetDataTable(p_SQL, p_SQL)
            '    If Not p_Table Is Nothing Then
            '        If p_Table.Rows.Count > 0 Then
            '            p_DateTime = p_Table.Rows(0).Item(0)
            '            For p_Int = 0 To p_Table12.Rows.Count - 1
            '                If p_Table12.Rows(p_Int).Item("ThoiGianCuoi").ToString = "" Then
            '                    Continue For
            '                End If
            '                Try
            '                    p_DateTimeHH = p_Table12.Rows(p_Int).Item("ThoiGianCuoi")
            '                    p_ValueTime = DateDiff(DateInterval.Minute, p_DateTimeHH, p_DateTime)
            '                    If p_ValueTime <= p_NHIETDO_TIME Then
            '                        Double.TryParse(p_Table12.Rows(p_Int).Item("NhietDo").ToString.Trim, p_NhietdoPTien)

            '                    End If
            '                Catch ex As Exception

            '                End Try

            '            Next

            '            'DateDiff(DateInterval.Minute


            '        End If

            '    End If

            'End If


            'cap nhat mặc định nhiệt độ xe  =  nhiệt độ TDH khi <=30 phút
            If p_NHIETDO_XE = True Then
                p_SQL = "update c set c.HeSo_K =  case when DATEDIFF (minute, isnull( b.THoigiancuoi,getdate()),getdate()) <= " & p_NHIETDO_TIME & " then  c.NhietDo else null end   from tblLenhXuate5 a, FPT_tblLenhXuatChiTietE5_V b, tblLenhXuatChiTietE5 c  " & _
                         "  where  a.SoLenh =b.SoLenh  and b.Row_id =c.Row_id  and a.SoLenh  ='" & p_SoLenh & "'  "
                If g_Services.Sys_Execute(p_SQL, _
                                          p_SQL) = False Then
                    'ShowMessageBox("", p_SQLErr)
                End If
            End If

            If p_NHIETDOXE_CHXD = True Then
                ' Mặc định nhiệt độ xe  =  hiệt độ TDH với khác lệnh khoog phải di chuyển của hàng
                p_SQL = "update c set c.HeSo_K = c.NhietDo    from tblLenhXuate5 a, FPT_tblLenhXuatChiTietE5_V b, tblLenhXuatChiTietE5 c  where  (a.MaNguon <> 'N05' or a.LoaiPhieu ='V144' ) " & _
                     "  and a.SoLenh =b.SoLenh  and b.Row_id =c.Row_id  and a.SoLenh  ='" & p_SoLenh & "' and  isnull(c.HeSo_K ,0) =0 "
                If g_Services.Sys_Execute(p_SQL, _
                                          p_SQL) = False Then
                    'ShowMessageBox("", p_SQLErr)
                End If
            End If


            p_SQL = "exec FPT_TinhL15_Intank '" & p_SoLenh & "'"
            If g_Services.Sys_Execute(p_SQL, _
                                          p_SQL) = False Then
                'ShowMessageBox("", p_SQLErr)
            End If

            '20240716 - Cap nhat ham hang cho B12
            If p_B12HH = True Then
                Dim p_Tbl As DataTable
                Dim p_TblExe As New DataTable("TblExe")
                Dim p_dRow As DataRow
                Dim p_MaNgan, p_GTHH As String
                Dim p_SAPObj As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
                p_Tbl = p_SAPObj.clsB12_ThongTinHamHang(p_SoLenh)
                If Not p_Tbl Is Nothing Then
                    p_TblExe.Columns.Add("sSQL")
                    For p_Count = 0 To p_Tbl.Rows.Count - 1
                        p_MaNgan = ""
                        p_GTHH = "0"
                        p_MaNgan = p_Tbl.Rows(p_Count).Item(0).ToString.Trim
                        p_GTHH = p_Tbl.Rows(p_Count).Item(1).ToString.Trim
                        p_SQL = " update h set h.MaEntry = " & p_GTHH & " from tblLenhXuatChiTietE5  h where h.Row_id in " & _
                                "(select Row_id from FPT_tblLenhXuatChiTietE5_V where SoLenh = '" & p_SoLenh & "' and MaNgan  = '" & p_MaNgan & "')"
                        ' p_dRow = p_TblExe.NewRow
                        If g_Services.Sys_Execute(p_SQL, _
                                          p_SQL) = False Then
                            p_SQL = p_SQL
                        End If


                    Next
                    'If p_Tbl.Rows.Count > 0 Then
                    '    p_SQL = ""
                    '    If g_Services.Sys_Execute_DataTbl(p_Tbl, p_SQL) = False Then
                    '        g_Module.ModErrExceptionNew("", p_SQL)
                    '        Exit Sub
                    '    End If

                    'End If

                End If
            End If

            'Check LMS
            If cl_HTTG_COMMON.g_LMS = "Y" Then
                p_SQL = "select  * from FPT_tblLenhXuat_HangHoaE5_V where solenh ='" & p_SoLenh & "'"
                p_DataTable = GetDataTable(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    For p_Count = 0 To p_DataTable.Rows.Count - 1
                        p_DataRow = p_DataTable.Rows(p_Count)
                        p_Density = cl_SOAP_API.GetDensity(p_DataRow.Item("BeXuat"), p_DataRow.Item("MaHangHoa"))
                        If p_Density <> p_DataRow.Item("D15_BQGQ") Then
                            ShowMessageBox("", "Tỷ trọng hiện tại khác với tỷ trọng trên LMS:" & p_DataRow.Item("BeXuat") & ":" & p_DataRow.Item("MaHangHoa") & ":" & p_Density & "(LMS)")
                        End If
                    Next
                End If
            End If

            If cl_HTTG_COMMON.g_SAP_LMS_GNTX = "Y" And p_MatKetNoiSAP = True Then
                Dim p_TableReturn As DataTable
                Dim p_Date As String
                p_SQL = "select  * from FPT_tblLenhXuat_HangHoaE5_V where solenh ='" & p_SoLenh & "'"
                p_DataTable = GetDataTable(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    For p_Count = 0 To p_DataTable.Rows.Count - 1
                        p_DataRow = p_DataTable.Rows(p_Count)

                        p_Date = CDate(Me.NgayXuat.EditValue).ToString("yyyyMMdd")
                        p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(_SapConnectionString, "EN", "30", g_Company_Code)
                        If p_ECCDestinationConfig.clsGetDensity(p_Date, p_TableReturn, p_SQLErr, _WareHouse, p_DataRow.Item("BeXuat"), p_DataRow.Item("MaHangHoa")) = False Then
                            ShowMessageBox("", p_SQLErr)
                            Exit Sub
                        End If
                        p_Density = 0
                        If Not p_TableReturn Is Nothing Then
                            If p_TableReturn.Rows.Count > 0 Then
                                p_Density = p_TableReturn.Rows(0).Item("Density")
                            End If
                        End If
                        If p_Density <> p_DataRow.Item("D15_BQGQ") Then
                            ShowMessageBox("", "Tỷ trọng hiện tại khác với tỷ trọng trên LMS (SAP):" & p_DataRow.Item("BeXuat") & ":" & p_DataRow.Item("MaHangHoa") & ":" & p_Density & "(LMS)")

                            'Exit Sub

                        End If
                    Next
                End If
            End If


            Me.DefaultFormLoad = True
            Me.Form1_Load(sender, e)
            Me.DefaultFormLoad = False

            p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
            Me.LoaiXuat.EditValue = GetLoadingSite(p_MaVanChuyen)
            If Not Me.Status.EditValue Is Nothing Then
                If InStr(",4,5,", "," & Me.Status.EditValue.ToString.Trim & ",", CompareMethod.Text) > 0 Then
                    Me.FormEdit = False
                    Me.GridView2.OptionsBehavior.ReadOnly = True
                    Me.GridView1.OptionsBehavior.ReadOnly = True
                Else
                    Me.FormEdit = True
                    Me.GridView2.OptionsBehavior.ReadOnly = False
                    Me.GridView1.OptionsBehavior.ReadOnly = False
                    If Me.Client.EditValue Is Nothing Then
                        Me.Client.EditValue = g_Terminal
                    Else
                        If Me.Client.EditValue.ToString.Trim = "" Then
                            Me.FormStatus = False
                            Me.Client.EditValue = g_Terminal
                            GoTo Line_tt
                            '  Me.FormStatus = True
                        End If
                    End If
                End If
            End If
            Me.FormStatus = False

            ShowStatusMessage(False, "", "Rút họng xuất thành công", 10)
            'Me.GridView2.BestFitColumns()
Line_tt:
            Set_Grid_Property()

        End If
        Set_Grid_Property()

    End Sub

    Private Function GetAppScadar()
        Dim p_DataTable As DataTable
        Dim p_SQL As String

        GetAppScadar = False
        p_SQL = "select  App_Scadar from SYS_USER where user_id=" & g_User_ID
        p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                If p_DataTable.Rows(0).Item("App_Scadar").ToString.Trim = "Y" Then
                    GetAppScadar = True
                End If
            End If
        End If
        Return GetAppScadar
    End Function

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim p_Status As String = ""
        Dim p_SoLenh As String = ""
        Dim l_err As String = ""

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If

        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If
        If p_SoLenh = "" Then
            Exit Sub
        End If
        'If p_Status <> "4" And p_Status <> "5" Then
        '    ShowMessageBox("", "Lệnh xuất chưa được xác nhận")
        '    Exit Sub
        'End If

        l_err = "HOADON"

        Dim Err As String = ""
        If FPT_KiemTraKhiHoaDonDienTu(l_err, Err, p_SoLenh) = True Then
            ShowMessageBox("", Err)
            Return
        End If

        InChungTu(l_err)

        '  _Report_Object.clsInChungTu(Me, False, p_SoLenh, "HOADON")

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        ' If Me.BtnOk.Text = Me.CaptionAdd And Me.FormStatus = False Then

        Dim p_SoLenh = ""

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If


        ' Me.g_FormLoad = True
        g_FormAddnew = True
        Me.FormEdit = True
        Me.GridView2.OptionsBehavior.ReadOnly = False
        Me.GridView1.OptionsBehavior.ReadOnly = False
        Me.FormStatus = False
        Me.Navigator1.Buttons.DoClick(Me.Navigator1.Buttons.Append)
        ' FormStatus = True

        Me.FormStatus = True
        'Me.g_FormLoad = False
        g_FormAddnew = True
        Me.FormStatus = True
        Me.NgayXuat.EditValue = p_DateCreate
        Me.FormStatus = False
        Me.SoLenh.Enabled = True
        Me.SoLenh.Properties.ReadOnly = False


        ShowStatusMessage(False, "", "")


        Me.SoLenh.Focus()
        'If p_Value = "Y" Then
        Me.SoLenh.BackColor = pv_Required_Back_Color

        If g_KV1 = True Or p_REFRESH = False Then

        Else

            If p_SoLenh <> "" Then
                Me.SoLenh.EditValue = p_SoLenh
            End If
        End If

        'If p_SoLenh <> "" Then
        '    Me.SoLenh.EditValue = p_SoLenh
        'End If

        'End If
        'End If
    End Sub


    Public Sub KeyF5()
        ' If Me.BtnOk.Text = Me.CaptionAdd And Me.FormStatus = False Then

        Dim p_SoLenh = ""

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If


        ' Me.g_FormLoad = True
        g_FormAddnew = True
        Me.FormEdit = True
        Me.GridView2.OptionsBehavior.ReadOnly = False
        Me.GridView1.OptionsBehavior.ReadOnly = False
        Me.FormStatus = False
        Me.Navigator1.Buttons.DoClick(Me.Navigator1.Buttons.Append)
        ' FormStatus = True

        Me.FormStatus = True
        'Me.g_FormLoad = False
        g_FormAddnew = True
        Me.FormStatus = True
        Me.NgayXuat.EditValue = p_DateCreate
        Me.FormStatus = False
        Me.SoLenh.Enabled = True
        Me.SoLenh.Properties.ReadOnly = False


        ShowStatusMessage(False, "", "")


        Me.SoLenh.Focus()
        'If p_Value = "Y" Then
        Me.SoLenh.BackColor = pv_Required_Back_Color

        If g_KV1 = True Or p_REFRESH = False Then

        Else

            If p_SoLenh <> "" Then
                Me.SoLenh.EditValue = p_SoLenh
            End If
        End If

        'If p_SoLenh <> "" Then
        '    Me.SoLenh.EditValue = p_SoLenh
        'End If

        'End If
        'End If
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim p_SoLenh As String = ""
        Dim p_dt_Header, p_dt_Material, p_dt_Details, p_DBCheck As DataTable
        Dim p_DataSet As DataSet
        Dim p_SQL As String = ""
        Dim p_Status As String = ""

        Dim p_Error As Boolean
        Dim p_Desc As String = ""

        p_SQL = "select KeyValue from sys_config where upper(keycode) = 'SAPOFF'"
        p_DBCheck = GetDataTable(p_SQL, p_SQL)
        If Not p_DBCheck Is Nothing Then
            If p_DBCheck.Rows.Count > 0 Then
                If p_DBCheck.Rows(0).Item("KeyValue").ToString.Trim = "Y" Then
                    ShowStatusMessage(True, "", "Hệ thống đang được thiết lập không kết nối SAP", 20)
                    Exit Sub
                End If
            End If
        End If

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If p_SoLenh = "" Then
            Exit Sub
        End If
        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        Try
            p_SQL = "select isnull(Status,'1') as Status   from tbllenhxuate5 with (nolock) where SoLenh = '" & p_SoLenh.ToString.Trim & "' "
            p_DBCheck = GetDataTable(p_SQL, p_SQL)
            If Not p_DBCheck Is Nothing Then
                If p_DBCheck.Rows.Count > 0 Then
                    If p_DBCheck.Rows(0).Item("Status").ToString.Trim = "5" Then
                        Dim p_ECCDestinationConfig1 As ECCDestination.ECCDestinationConfig
                        Dim p_Table As DataTable
                        Dim p_Str As String = ""
                        p_ECCDestinationConfig1 = New ECCDestination.ECCDestinationConfig(_SapConnectionString, "EN", "60", g_Company_Code, g_Terminal, g_UserName)

                        p_SQL = "exec ThongTinBBGN_SAP_UPD '" & g_UserName & "' , '" & p_SoLenh & "' "
                        p_Table = GetDataTable(p_SQL, p_Str)
                        If Not p_Table Is Nothing Then
                            p_Str = ""
                            p_ECCDestinationConfig1.clsPost_LenhXuatBoSung(p_Table, p_Str)
                            If p_Str <> "" Then
                                ShowStatusMessage(True, "", p_Str, 20)

                            Else
                                ShowStatusMessage(False, "Đã đồng bộ thông tin bổ sung")
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try


        If KiemTraThongTinLenh(p_SoLenh, p_Desc) = True Then
            ShowMessageBox("", p_Desc)
            Exit Sub
        End If

        If Me.FormStatus = True Then
            ShowMessageBox("", "Đề nghị lưu lại trước khi thực hiện")
            Exit Sub
        End If

        If KiemTraTyLeChenhLech(True) = True Then
            Exit Sub
        End If


        If Mid(p_SoLenh, 1, Len(g_WareHouse)) = g_WareHouse Then
            ShowMessageBox("", "Lệnh được tạo ở Trung gian bơm xuất không thể đưa được lên SAP")
            Exit Sub
        End If

        p_SQL = "exec FPT_GetDataToSAP '" & p_SoLenh & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_dt_Header = p_DataSet.Tables(0)
                p_dt_Material = p_DataSet.Tables(1)
                p_dt_Details = p_DataSet.Tables(2)
                Try


                    Dim p_SAP_Obj As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

                    If p_SAP_Obj.ClsSyncDeliveries_Httg2Sap(p_dt_Header, p_dt_Material, p_dt_Details, p_SQL) Then

                        p_SQL = "Update tblLenhXuatE5 set Status='5' where SoLenh='" & p_SoLenh & "'"
                        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                        Else
                            UpdateStatusDO(p_SMOAPI, p_SoLenh, "5")
                            ShowStatusMessage(False, "", "Đồng bộ thực xuất lên SAP thành công!", 120)
                            '20241031 bo sung thong tin ngayf gio thuc hien Bowm xuaat len SAP
                            'If p_THONGTIN_BBGN = True Then
                            Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
                            Dim p_Table As DataTable
                            Dim p_Str As String = ""


                            p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(_SapConnectionString, "EN", "60", g_Company_Code, g_Terminal, g_UserName)


                            p_SQL = "exec ThongTinBBGN_SAP_UPD '" & g_UserName & "' , '" & p_SoLenh & "' "
                            p_Table = GetDataTable(p_SQL, p_Str)
                            If Not p_Table Is Nothing Then
                                p_Str = ""
                                p_ECCDestinationConfig.clsPost_LenhXuatBoSung(p_Table, p_Str)
                                If p_Str <> "" Then
                                    ShowStatusMessage(True, "", p_Str, 20)
                                End If
                            End If


                        End If


                        LoadSoLenh(p_Error)
                        SeStatusSMO()
                    Else
                        'mdlMessage_SendMessage(False, 114, lblMess)
                        ShowMessageBox("", p_SQL)
                    End If
                    'mdlSyncDeliveries_Httg2Sap
                    'Else


                    '    If g_Services.mdlSyncDeliveries_Httg2Sap(p_dt_Header, p_dt_Material, p_dt_Details, p_SQL) Then

                    '        'p_SQL = "Update tblLenhXuatE5 set Status='5' where SoLenh='" & p_SoLenh & "'"
                    '        'If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                    '        'Else
                    '        '    ShowStatusMessage(False, "", "Đồng bộ thực xuất lên SAP thành công!", 5)
                    '        'End If

                    '        LoadSoLenh(p_Error)
                    '        ShowStatusMessage(False, "", "Đồng bộ thực xuất lên SAP thành công!", 120)
                    '    Else
                    '        'mdlMessage_SendMessage(False, 114, lblMess)
                    '        ShowMessageBox("", p_SQL)
                    '    End If
                    'End If


                    ' End If




                Catch ex As Exception
                    ShowMessageBox(Err.Number.ToString, ex.Message)
                End Try
            End If
        End If

    End Sub



    Private Function KiemTraThongTinLenhXacNhan(ByVal p_SoLenh As String, ByRef p_Desc As String) As Boolean
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_LoaiXuat As String
        Dim p_Value As String
        KiemTraThongTinLenhXacNhan = False
        Dim p_Count As Integer
        Try

            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_LoaiXuat = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            p_LoaiXuat = GetLoadingSite(p_LoaiXuat)
            If UCase(p_LoaiXuat) = "THUY" Then
                p_Value = ""
                If Not Me.LuongGiamDinh.EditValue Is Nothing Then
                    p_Value = Me.LuongGiamDinh.EditValue.ToString.Trim
                End If
                If p_Value = "" Then
                    p_Desc = "Lượng giám định không được trống"
                    KiemTraThongTinLenhXacNhan = True
                    Exit Function
                End If


                p_Value = ""
                If Not Me.NhietDoTaiTau.EditValue Is Nothing Then
                    p_Value = Me.NhietDoTaiTau.EditValue.ToString.Trim
                End If

                If p_Value = "" Then
                    p_Desc = "Nhiệt độ tại tàu không được trống"
                    KiemTraThongTinLenhXacNhan = True
                    Exit Function
                End If



            End If

            p_SQL = "exec FPT_KiemTraKhiXacNhan '" & p_SoLenh & "'"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    For p_Count = 0 To p_DataTable.Rows.Count - 1

                        If p_DataTable.Rows(p_Count).Item(0).ToString.Trim = "1" Then
                            p_Desc = p_DataTable.Rows(0).Item(1).ToString.Trim
                            Try
                                If p_DataTable.Rows(p_Count).Item(2).ToString.Trim = "1" Then
                                    KiemTraThongTinLenhXacNhan = True
                                    Exit Function
                                Else
                                    ShowMessageBox("", p_Desc)
                                    Continue For
                                End If

                            Catch ex As Exception
                                KiemTraThongTinLenhXacNhan = True
                                Exit Function
                            End Try

                        End If
                    Next
                End If

            End If




        Catch ex As Exception
            p_Desc = ex.Message
            KiemTraThongTinLenhXacNhan = True
        End Try

    End Function


    Private Function KiemTraThongTinLenh(ByVal p_SoLenh As String, ByRef p_Desc As String) As Boolean
        Dim p_SQL As String
        Dim p_LoaiXuat As String = ""
        Dim p_Value As String = ""

        Dim p_DataTable As DataTable
        KiemTraThongTinLenh = False
        Try
            p_SQL = "exec FPT_KiemTraKhiLenSAP '" & p_SoLenh & "'"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    If p_DataTable.Rows(0).Item(0).ToString.Trim = "1" Then
                        p_Desc = p_DataTable.Rows(0).Item(1).ToString.Trim
                        KiemTraThongTinLenh = True
                        Exit Function
                    End If
                End If

            End If

            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_LoaiXuat = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            p_LoaiXuat = GetLoadingSite(p_LoaiXuat)
            If UCase(p_LoaiXuat) = "THUY" Then
                p_Value = ""
                If Not Me.LuongGiamDinh.EditValue Is Nothing Then
                    p_Value = Me.LuongGiamDinh.EditValue.ToString.Trim
                End If
                If p_Value = "" Then
                    p_Desc = "Lượng giám định không được trống"
                    KiemTraThongTinLenh = True
                    Exit Function
                End If


                p_Value = ""
                If Not Me.NhietDoTaiTau.EditValue Is Nothing Then
                    p_Value = Me.NhietDoTaiTau.EditValue.ToString.Trim
                End If

                If p_Value = "" Then
                    p_Desc = "Nhiệt độ tại tàu không được trống"
                    KiemTraThongTinLenh = True
                    Exit Function
                End If



            End If
        Catch ex As Exception
            p_Desc = ex.Message
            KiemTraThongTinLenh = True
        End Try

    End Function


    Private Sub Set_Grid_Property()
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_MaVanChuyen As String = ""
        Try
            ' p_SQL = "select * from SYS_USER where User_ID=" & IIf(g_User_ID.ToString.Trim = "", 0, g_User_ID)
            ' p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
            End If

           

            p_MaVanChuyen = GetLoadingSite(p_MaVanChuyen)
            p_DataTable = p_TableUser
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    If p_DataTable.Rows(0).Item("SoLuongThucXuat").ToString.Trim = "Y" Then
                        Me.GridView2.Columns.Item("SoLuongThucXuat").OptionsColumn.ReadOnly = False
                    Else
                        Me.GridView2.Columns.Item("SoLuongThucXuat").OptionsColumn.ReadOnly = True
                    End If
                    If p_DataTable.Rows(0).Item("NhietDo").ToString.Trim = "Y" Then
                        Me.GridView2.Columns.Item("NhietDo").OptionsColumn.ReadOnly = False
                    Else
                        Me.GridView2.Columns.Item("NhietDo").OptionsColumn.ReadOnly = True
                    End If

                    If p_DataTable.Rows(0).Item("TyTrong_15").ToString.Trim = "Y" Then
                        Me.GridView2.Columns.Item("TyTrong_15").OptionsColumn.ReadOnly = False
                    Else
                        Me.GridView2.Columns.Item("TyTrong_15").OptionsColumn.ReadOnly = True
                    End If

                    If p_DataTable.Rows(0).Item("ThoiGianDau").ToString.Trim = "Y" Then
                        Me.GridView2.Columns.Item("ThoiGianDau").OptionsColumn.ReadOnly = False
                    Else
                        Me.GridView2.Columns.Item("ThoiGianDau").OptionsColumn.ReadOnly = True
                    End If
                    If p_DataTable.Rows(0).Item("ThoiGianCuoi").ToString.Trim = "Y" Then
                        Me.GridView2.Columns.Item("ThoiGianCuoi").OptionsColumn.ReadOnly = False
                    Else
                        Me.GridView2.Columns.Item("ThoiGianCuoi").OptionsColumn.ReadOnly = True
                    End If
                    If p_DataTable.Rows(0).Item("MaLuuLuongKe").ToString.Trim = "Y" Then
                        Me.GridView2.Columns.Item("MaLuuLuongKe").OptionsColumn.ReadOnly = False
                    Else
                        Me.GridView2.Columns.Item("MaLuuLuongKe").OptionsColumn.ReadOnly = True
                    End If

                    If UCase(p_MaVanChuyen) = "THUY" Then

                        If p_DataTable.Rows(0).Item("Sl_llkebd_Thuy").ToString.Trim = "Y" Then
                            Me.GridView2.Columns.Item("Sl_llkebd").OptionsColumn.ReadOnly = False
                        Else
                            Me.GridView2.Columns.Item("Sl_llkebd").OptionsColumn.ReadOnly = True
                        End If

                        If p_DataTable.Rows(0).Item("Sl_llkekt_Thuy").ToString.Trim = "Y" Then
                            Me.GridView2.Columns.Item("Sl_llkekt").OptionsColumn.ReadOnly = False
                        Else
                            Me.GridView2.Columns.Item("Sl_llkekt").OptionsColumn.ReadOnly = True
                        End If
                    Else
                        If p_DataTable.Rows(0).Item("Sl_llkebd").ToString.Trim = "Y" Then
                            Me.GridView2.Columns.Item("Sl_llkebd").OptionsColumn.ReadOnly = False
                        Else
                            Me.GridView2.Columns.Item("Sl_llkebd").OptionsColumn.ReadOnly = True
                        End If

                        If p_DataTable.Rows(0).Item("Sl_llkekt").ToString.Trim = "Y" Then
                            Me.GridView2.Columns.Item("Sl_llkekt").OptionsColumn.ReadOnly = False
                        Else
                            Me.GridView2.Columns.Item("Sl_llkekt").OptionsColumn.ReadOnly = True
                        End If
                    End If
                    'If p_DataTable.Rows(0).Item("Sl_llkebd").ToString.Trim = "Y" Then
                    '    Me.GridView2.Columns.Item("Sl_llkebd").OptionsColumn.ReadOnly = False
                    'Else
                    '    Me.GridView2.Columns.Item("Sl_llkebd").OptionsColumn.ReadOnly = True
                    'End If

                    'If p_DataTable.Rows(0).Item("Sl_llkekt").ToString.Trim = "Y" Then
                    '    Me.GridView2.Columns.Item("Sl_llkekt").OptionsColumn.ReadOnly = False
                    'Else
                    '    Me.GridView2.Columns.Item("Sl_llkekt").OptionsColumn.ReadOnly = True
                    'End If

                    If p_DataTable.Rows(0).Item("MaEntry").ToString.Trim = "Y" Then
                        Me.GridView2.Columns.Item("MaEntry").OptionsColumn.ReadOnly = False
                    Else
                        Me.GridView2.Columns.Item("MaEntry").OptionsColumn.ReadOnly = True
                    End If

                    If p_ThongTinNhomBe = True Then
                        If p_DataTable.Rows(0).Item("NhomBeXuat").ToString.Trim = "Y" Then
                            Me.GridView2.Columns.Item("NhomBeXuatTDH").OptionsColumn.ReadOnly = False
                        Else
                            Me.GridView2.Columns.Item("NhomBeXuatTDH").OptionsColumn.ReadOnly = True
                        End If

                        If p_DataTable.Rows(0).Item("BeXuat").ToString.Trim = "Y" Then
                            Me.GridView2.Columns.Item("BeXuat").OptionsColumn.ReadOnly = False
                        Else
                            Me.GridView2.Columns.Item("BeXuat").OptionsColumn.ReadOnly = True
                        End If
                    End If

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TrueDBGrid2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid2.Click

    End Sub

    Private Function KiemTraTyLeChenhLech(Optional ByVal p_KiemTraChenhLenh As Boolean = False, Optional ByVal p_Approve_Checked As Boolean = False) As Boolean
        Dim p_ArrRow() As DataRow
        Dim p_DataRow As DataRow
        Dim p_Count As Integer
        Dim p_CountLine As Integer
        Dim p_SAISOCHOPHEP As Double = 0

        Dim p_SAISOCHOPHEPCTo As Double = 0

        Dim p_SAISOCHOPHEPTHEONGAN As String = ""
        Dim p_TongThucXuat As Double = 0
        Dim p_TongDuXuat As Double = 0
        Dim p_ThucXuat As Double = 0
        Dim p_DuXuat As Double

        Dim p_ThucXuat_BD As Double = 0
        Dim p_DuXuat_BD As Double = 0
        Dim p_ChenhLech As Double = 0

        Dim p_ChiSoDau As Double = 0
        Dim p_ChiSoCuoi As Double = 0
        Dim p_ChenhLechChiSo As Double

        Dim p_DataHangHoa As DataTable
        Dim p_Binding As U_TextBox.U_BindingSource

        Dim p_FromDate As DateTime = Now
        Dim p_ToDate As DateTime
        Dim p_Status As String = "1"
        Dim p_SAISOCHOPHEPTHEOCTO As String = ""

        Dim p_SAISOCHOPHEPTHEOCTO_Thuy As String = ""

        Dim p_TinhSaiSoChoPhep_Thuy As String = ""
        Dim p_SaiSo_Thuy As Double = 0

        Dim p_Approved As String = ""
        Dim p_LoaiXuat As String = "Bo"

        Dim p_TyLeChenhLech As Double
        Dim p_ChiSoMin As Double = 0
        Dim p_ChiSoMax As Double = 0
        Dim p_MaHangHoa As String
        ' Dim p_ChenhLech As Double = 0
        Dim p_DonViTinh As String = ""
        Try
            KiemTraTyLeChenhLech = False

            If Not Me.Status.EditValue Is Nothing Then
                p_Status = Me.Status.EditValue.ToString.Trim

            End If
            If p_Status = "31" Or p_Status = "4" Or p_Status = "5" Or p_Status = "3" Then
                If g_KV1 = False Then                    ' Continue For

                    For p_Count = 0 To Me.GridView2.RowCount - 1
                        p_FromDate = Now
                        p_ToDate = p_FromDate
                        p_DataRow = GridView2.GetDataRow(p_Count)
                        If p_DataRow.Item("ThoiGianDau").ToString.Trim <> "" Then
                            p_FromDate = p_DataRow.Item("ThoiGianDau").ToString.Trim
                            p_ToDate = p_FromDate
                        End If
                        If p_DataRow.Item("ThoiGianCuoi").ToString.Trim <> "" Then
                            p_ToDate = p_DataRow.Item("ThoiGianCuoi").ToString.Trim
                            'p_ToDate = p_FromDate
                        End If
                        If p_KT_THOIGIAN = True Then
                            If p_ToDate <= p_FromDate Then
                                ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Giờ sau xuất phải lớn hơn Giờ xuất")
                                SetColorRow(p_Count, "R")
                                'anhqh
                                '20160819
                                '23h
                                KiemTraTyLeChenhLech = True
                                Exit Function
                            End If

                        End If
                    Next

                End If

                'Kiem tra Ngay gio bat dau va ngay gio ket thuc
                'For p_Count = 0 To Me.GridView2.RowCount - 1
                '    p_FromDate = Now
                '    p_ToDate = p_FromDate
                '    p_DataRow = GridView2.GetDataRow(p_Count)
                '    If p_DataRow.Item("ThoiGianDau").ToString.Trim <> "" Then
                '        p_FromDate = p_DataRow.Item("ThoiGianDau").ToString.Trim
                '        p_ToDate = p_FromDate
                '    End If
                '    If p_DataRow.Item("ThoiGianCuoi").ToString.Trim <> "" Then
                '        p_ToDate = p_DataRow.Item("ThoiGianCuoi").ToString.Trim
                '        'p_ToDate = p_FromDate
                '    End If

                '    If p_ToDate <= p_FromDate Then

                '        ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Giờ sau xuất phải lớn hơn Giờ xuất")
                '        SetColorRow(p_Count, "R")
                '        'anhqh
                '        '20160819
                '        '23h
                '        KiemTraTyLeChenhLech = True
                '        Exit Function
                '    End If
                'Next
            End If


            If Not Me.Approved.EditValue Is Nothing Then
                p_Approved = Me.Approved.EditValue.ToString.Trim
            End If
            If p_KiemTraChenhLenh = False Then
                KiemTraTyLeChenhLech = False
                Exit Function
            End If
            If p_Approve_Checked = False Then
                If p_Approved = "Y" Then
                    KiemTraTyLeChenhLech = False
                    Exit Function
                End If
            End If


            p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEP'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    If IsNumeric(p_ArrRow(0).Item("KEYVALUE").ToString.Trim) Then
                        p_SAISOCHOPHEP = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                    End If
                End If
            End If

            p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEPTHEOCTO'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    '  If IsNumeric(p_ArrRow(0).Item("KEYVALUE").ToString.Trim) Then
                    p_SAISOCHOPHEPTHEOCTO = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                    ' End If
                End If
            End If





            p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEPTHEOCTO_THUY'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    '  If IsNumeric(p_ArrRow(0).Item("KEYVALUE").ToString.Trim) Then
                    p_SAISOCHOPHEPTHEOCTO_Thuy = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                    ' End If
                End If
            End If



            p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEP_CTO'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    If IsNumeric(p_ArrRow(0).Item("KEYVALUE").ToString.Trim) Then
                        p_SAISOCHOPHEPCTo = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                    End If
                End If
            End If


            p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEPTHEONGAN'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    p_SAISOCHOPHEPTHEONGAN = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                End If
            End If
            p_TinhSaiSoChoPhep_Thuy = ""
            p_ArrRow = p_TableConfig.Select("KEYCODE='TINHSAISOCHOPHEP_THUY'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    p_TinhSaiSoChoPhep_Thuy = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                End If
            End If
            p_SaiSo_Thuy = 0
            p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEP_THUY'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    If IsNumeric(p_ArrRow(0).Item("KEYVALUE").ToString.Trim) Then
                        p_SaiSo_Thuy = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                    End If
                End If
            End If

            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_LoaiXuat = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            p_LoaiXuat = GetLoadingSite(p_LoaiXuat)
            If UCase(p_LoaiXuat) = "THUY" Then
                If p_TinhSaiSoChoPhep_Thuy = "Y" Then
                    p_Binding = Me.TrueDBGrid2.DataSource
                    p_DataHangHoa = CType(p_Binding.DataSource, DataTable)
                    For p_Count = 0 To Me.GridView2.RowCount - 1
                        p_DataRow = GridView2.GetDataRow(p_Count)
                        p_ThucXuat = 0
                        p_DuXuat = 0
                        p_ThucXuat_BD = 0
                        p_DuXuat_BD = 0
                        p_ChenhLechChiSo = 0
                        p_ArrRow = p_DataHangHoa.Select("MaHangHoa='" & p_DataRow.Item("MaHangHoa").ToString.Trim & "'")
                        For p_CountLine = 0 To p_ArrRow.Length - 1
                            'Kiem tra duxuat va thuc xuat
                            '    p_DonViTinh =
                            p_ThucXuat = p_ThucXuat + IIf(p_ArrRow(p_CountLine).Item("SoLuongThucXuat").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("SoLuongThucXuat").ToString.Trim)
                            p_DuXuat = p_DuXuat + IIf(p_ArrRow(p_CountLine).Item("SoLuongDuXuat").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("SoLuongDuXuat").ToString.Trim)
                            p_ChiSoCuoi = IIf(p_ArrRow(p_CountLine).Item("Sl_llkekt").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("Sl_llkekt").ToString.Trim)
                            p_ChiSoDau = IIf(p_ArrRow(p_CountLine).Item("Sl_llkebd").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("Sl_llkebd").ToString.Trim)
                            p_ChenhLechChiSo = p_ChenhLechChiSo + (p_ChiSoCuoi - p_ChiSoDau)
                        Next
                        p_ThucXuat_BD = p_ThucXuat
                        p_DuXuat_BD = p_DuXuat



                        If p_ThucXuat > p_DuXuat Then

                            p_TyLeChenhLech = TinhTyLeChenhLech(p_ThucXuat, p_DuXuat, p_DuXuat)



                            'p_DuXuat = p_DuXuat + p_DuXuat * (p_SaiSo_Thuy / 100)

                            'p_DuXuat = Math.Round(CDbl(p_DuXuat), 0, MidpointRounding.AwayFromZero)
                            'p_ThucXuat = Math.Round(CDbl(p_ThucXuat), 0, MidpointRounding.AwayFromZero)


                            'If p_ThucXuat > p_DuXuat Then
                            If p_TyLeChenhLech > p_SaiSo_Thuy Then
                                ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Chênh lệnh giữa dự xuất và thực xuất không được vượt quá " & p_SaiSo_Thuy & "% lượng dự xuất")
                                KiemTraTyLeChenhLech = True
                                Exit Function
                            End If

                        End If


                        '   Continue For
                        p_ThucXuat = p_ThucXuat_BD
                        p_DuXuat = p_DuXuat_BD

                        If p_ThucXuat < p_DuXuat Then
                            'anhqh  20160509  Kiem tra chenh lech theo cau hinh
                            'p_DuXuat = p_DuXuat - p_DuXuat * (p_SaiSo_Thuy / 100)

                            'p_DuXuat = Math.Round(CDbl(p_DuXuat), 0, MidpointRounding.AwayFromZero)
                            'p_ThucXuat = Math.Round(CDbl(p_ThucXuat), 0, MidpointRounding.AwayFromZero)

                            p_TyLeChenhLech = TinhTyLeChenhLech(p_ThucXuat, p_DuXuat, p_DuXuat)



                            ' If p_ThucXuat < p_DuXuat Then
                            If p_TyLeChenhLech > p_SaiSo_Thuy Then
                                ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Chênh lệnh giữa dự xuất và thực xuất không được thấp quá " & p_SaiSo_Thuy & "% lượng dự xuất")
                                KiemTraTyLeChenhLech = True
                                Exit Function
                            End If

                        End If

                        'anhqh
                        '20160728
                        'Them chenh lech chi so cuoi - chi so dau voi thuc xuat
                        If p_SAISOCHOPHEPTHEOCTO_Thuy = "Y" Then
                            'Kiem tra Chi so dau va cho so sau
                            p_ChiSoCuoi = IIf(p_DataRow.Item("Sl_llkekt").ToString.Trim = "", 0, p_DataRow.Item("Sl_llkekt").ToString.Trim)
                            p_ChiSoDau = IIf(p_DataRow.Item("Sl_llkebd").ToString.Trim = "", 0, p_DataRow.Item("Sl_llkebd").ToString.Trim)
                            p_ChenhLechChiSo = p_ChiSoCuoi - p_ChiSoDau

                            p_ThucXuat = IIf(p_DataRow.Item("SoLuongThucXuat").ToString.Trim = "", 0, p_DataRow.Item("SoLuongThucXuat").ToString.Trim)

                            If p_ChenhLechChiSo > p_ThucXuat Then

                                p_TyLeChenhLech = TinhTyLeChenhLech(p_ChenhLechChiSo, p_ThucXuat, p_ThucXuat)

                                'p_ThucXuat = p_ThucXuat + p_ThucXuat * (p_SAISOCHOPHEPCTo / 100)

                                'p_ChenhLechChiSo = Math.Round(CDbl(p_ChenhLechChiSo), 0, MidpointRounding.AwayFromZero)
                                'p_ThucXuat = Math.Round(CDbl(p_ThucXuat), 0, MidpointRounding.AwayFromZero)

                                'If p_ChenhLechChiSo > p_ThucXuat Then
                                If p_TyLeChenhLech > p_SaiSo_Thuy Then
                                    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa số công tơ và thực xuất không được vượt quá " & p_SAISOCHOPHEPCTo & "%")
                                    KiemTraTyLeChenhLech = True
                                    Exit Function

                                End If

                            End If

                            If p_ChenhLechChiSo < p_ThucXuat Then

                                p_TyLeChenhLech = TinhTyLeChenhLech(p_ChenhLechChiSo, p_ThucXuat, p_ThucXuat)


                                'p_ThucXuat = p_ThucXuat - p_ThucXuat * (p_SAISOCHOPHEPCTo / 100)

                                'p_ChenhLechChiSo = Math.Round(CDbl(p_ChenhLechChiSo), 0, MidpointRounding.AwayFromZero)
                                'p_ThucXuat = Math.Round(CDbl(p_ThucXuat), 0, MidpointRounding.AwayFromZero)


                                ' If p_ChenhLechChiSo < p_ThucXuat Then
                                If p_TyLeChenhLech > p_SaiSo_Thuy Then
                                    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa số công tơ và thực xuất không được thấp quá " & p_SAISOCHOPHEPCTo & "%")
                                    KiemTraTyLeChenhLech = True
                                    Exit Function
                                End If



                            End If
                        End If

                    Next
                End If
            Else   'Xuat Bo va Sat
                If p_SAISOCHOPHEPTHEONGAN = "Y" Then  'Neu tinh chenh lech theo tung ngan
                    For p_Count = 0 To Me.GridView2.RowCount - 1
                        p_DataRow = GridView2.GetDataRow(p_Count)
                        'Kiem tra duxuat va thuc xuat
                        p_ThucXuat = IIf(p_DataRow.Item("SoLuongThucXuat").ToString.Trim = "", 0, p_DataRow.Item("SoLuongThucXuat").ToString.Trim)
                        p_DuXuat = IIf(p_DataRow.Item("SoLuongDuXuat").ToString.Trim = "", 0, p_DataRow.Item("SoLuongDuXuat").ToString.Trim)

                        p_ThucXuat_BD = p_ThucXuat
                        p_DuXuat_BD = p_DuXuat


                        'anhqh
                        '20160828
                        '   Me.GridView2.SetRowCellValue(p_Count, "Record_Status", "N")  'Record_Status

                        If p_ThucXuat > p_DuXuat Then

                            p_TyLeChenhLech = TinhTyLeChenhLech(p_ThucXuat, p_DuXuat, p_DuXuat)


                            'p_DuXuat = p_DuXuat + p_DuXuat * (p_SAISOCHOPHEP / 100)

                            'p_DuXuat = Math.Round(CDbl(p_DuXuat), 0, MidpointRounding.AwayFromZero)
                            'p_ThucXuat = Math.Round(CDbl(p_ThucXuat), 0, MidpointRounding.AwayFromZero)


                            ' If p_ThucXuat > p_DuXuat Then
                            If p_TyLeChenhLech > p_SAISOCHOPHEP Then
                                ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa dự xuất và thực xuất không được vượt quá " & p_SAISOCHOPHEP & "% lượng dự xuất")

                                'anhqh
                                '20160819
                                ''23
                                'SetColorRow(p_Count, "R")

                                'anhqh
                                '20160828
                                ' Me.GridView2.SetRowCellValue(p_Count, "Record_Status", "Y")  'Record_Status


                                KiemTraTyLeChenhLech = True
                                Exit Function
                            End If



                        End If

                        p_ThucXuat = p_ThucXuat_BD
                        p_DuXuat = p_DuXuat_BD

                        If p_ThucXuat < p_DuXuat Then

                            p_TyLeChenhLech = TinhTyLeChenhLech(p_ThucXuat, p_DuXuat, p_DuXuat)


                            'p_DuXuat = p_DuXuat - p_DuXuat * (p_SAISOCHOPHEP / 100)

                            'p_DuXuat = Math.Round(CDbl(p_DuXuat), 0, MidpointRounding.AwayFromZero)
                            'p_ThucXuat = Math.Round(CDbl(p_ThucXuat), 0, MidpointRounding.AwayFromZero)


                            'If p_ThucXuat < p_DuXuat Then
                            If p_TyLeChenhLech > p_SAISOCHOPHEP Then
                                ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa dự xuất và thực xuất không được thấp quá " & p_SAISOCHOPHEP & "% lượng dự xuất")
                                KiemTraTyLeChenhLech = True
                                'anhqh
                                '20160819
                                ''23
                                'SetColorRow(p_Count, "R")

                                'anhqh
                                '20160828
                                ' Me.GridView2.SetRowCellValue(p_Count, "Record_Status", "Y")  'Record_Status

                                Exit Function
                            End If

                        End If
                        If p_SAISOCHOPHEPTHEOCTO = "Y" Then
                            'Kiem tra Chi so dau va cho so sau
                            p_ChiSoCuoi = IIf(p_DataRow.Item("Sl_llkekt").ToString.Trim = "", 0, p_DataRow.Item("Sl_llkekt").ToString.Trim)
                            p_ChiSoDau = IIf(p_DataRow.Item("Sl_llkebd").ToString.Trim = "", 0, p_DataRow.Item("Sl_llkebd").ToString.Trim)
                            p_ChenhLechChiSo = p_ChiSoCuoi - p_ChiSoDau

                            p_ThucXuat = IIf(p_DataRow.Item("SoLuongThucXuat").ToString.Trim = "", 0, p_DataRow.Item("SoLuongThucXuat").ToString.Trim)

                            If p_ChenhLechChiSo > p_ThucXuat Then

                                p_TyLeChenhLech = TinhTyLeChenhLech(p_ChenhLechChiSo, p_ThucXuat, p_ThucXuat)


                                'p_ThucXuat = p_ThucXuat + p_ThucXuat * (p_SAISOCHOPHEPCTo / 100)

                                'p_ChenhLechChiSo = Math.Round(CDbl(p_ChenhLechChiSo), 0, MidpointRounding.AwayFromZero)
                                'p_ThucXuat = Math.Round(CDbl(p_ThucXuat), 0, MidpointRounding.AwayFromZero)


                                'If p_ChenhLechChiSo > p_ThucXuat Then
                                If p_TyLeChenhLech > p_SAISOCHOPHEP Then
                                    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa số công tơ và thực xuất không được vượt quá " & p_SAISOCHOPHEPCTo & "%")
                                    'anhqh
                                    '20160819
                                    ''23
                                    'SetColorRow(p_Count, "R")
                                    'anhqh
                                    '20160828
                                    '  Me.GridView2.SetRowCellValue(p_Count, "Record_Status", "Y")  'Record_Status

                                    KiemTraTyLeChenhLech = True
                                    Exit Function
                                End If

                            End If

                            If p_ChenhLechChiSo < p_ThucXuat Then

                                p_TyLeChenhLech = TinhTyLeChenhLech(p_ChenhLechChiSo, p_ThucXuat, p_ThucXuat)


                                'p_ThucXuat = p_ThucXuat - p_ThucXuat * (p_SAISOCHOPHEPCTo / 100)

                                'p_ChenhLechChiSo = Math.Round(CDbl(p_ChenhLechChiSo), 0, MidpointRounding.AwayFromZero)
                                'p_ThucXuat = Math.Round(CDbl(p_ThucXuat), 0, MidpointRounding.AwayFromZero)

                                ' If p_ChenhLechChiSo < p_ThucXuat Then
                                If p_TyLeChenhLech > p_SAISOCHOPHEP Then
                                    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa số công tơ và thực xuất không được thấp quá " & p_SAISOCHOPHEPCTo & "%")
                                    'anhqh
                                    '20160819
                                    ''23
                                    'SetColorRow(p_Count, "R")
                                    'anhqh
                                    '20160828
                                    '  Me.GridView2.SetRowCellValue(p_Count, "Record_Status", "Y")  'Record_Status

                                    KiemTraTyLeChenhLech = True
                                    Exit Function
                                End If



                            End If
                        End If


                    Next
                    Exit Function
                End If

                If p_SAISOCHOPHEPTHEONGAN = "N" Or p_SAISOCHOPHEPTHEONGAN = "" Then  'Neu tinh chenh lech theo tung hang hoa

                    '    p_Approved = ""
                    '  If Me.Approved.Checked = True Then
                    'For p_Count = 0 To Me.GridView2.RowCount - 1
                    '    p_DataRow = GridView2.GetDataRow(p_Count)
                    '    If Not p_DataRow Is Nothing Then
                    '        Me.GridView2.SetRowCellValue(p_Count, "Record_Status", "N")  'Record_Status
                    '    End If
                    'Next
                    '' If

                    p_Binding = Me.TrueDBGrid2.DataSource
                    p_DataHangHoa = CType(p_Binding.DataSource, DataTable)
                    For p_Count = 0 To Me.GridView2.RowCount - 1
                        p_DataRow = GridView2.GetDataRow(p_Count)
                        p_MaHangHoa = p_DataRow.Item("MaHangHoa").ToString.Trim
                        'If p_DataRow.Item("Record_Status").ToString.Trim = "Y" Then
                        '    Continue For
                        'End If
                        p_ThucXuat = 0
                        p_DuXuat = 0
                        p_ThucXuat_BD = 0
                        p_DuXuat_BD = 0
                        p_ChenhLechChiSo = 0
                        p_ArrRow = p_DataHangHoa.Select("MaHangHoa='" & p_DataRow.Item("MaHangHoa").ToString.Trim & "'")
                        If p_ArrRow.Length > 0 Then
                            p_CountLine = 0
                            p_ChiSoMax = IIf(p_ArrRow(p_CountLine).Item("Sl_llkekt").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("Sl_llkekt").ToString.Trim)
                            p_ChiSoMin = IIf(p_ArrRow(p_CountLine).Item("Sl_llkebd").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("Sl_llkebd").ToString.Trim)
                        End If
                        For p_CountLine = 0 To p_ArrRow.Length - 1
                            'Kiem tra duxuat va thuc xuat
                            p_ThucXuat = p_ThucXuat + IIf(p_ArrRow(p_CountLine).Item("SoLuongThucXuat").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("SoLuongThucXuat").ToString.Trim)
                            p_DuXuat = p_DuXuat + IIf(p_ArrRow(p_CountLine).Item("SoLuongDuXuat").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("SoLuongDuXuat").ToString.Trim)
                            p_ChiSoCuoi = IIf(p_ArrRow(p_CountLine).Item("Sl_llkekt").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("Sl_llkekt").ToString.Trim)
                            p_ChiSoDau = IIf(p_ArrRow(p_CountLine).Item("Sl_llkebd").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("Sl_llkebd").ToString.Trim)
                            If p_ChiSoDau < p_ChiSoMin Then
                                p_ChiSoMin = p_ChiSoDau
                            End If
                            If p_ChiSoCuoi > p_ChiSoMax Then
                                p_ChiSoMax = p_ChiSoCuoi
                            End If

                            '  p_ChenhLechChiSo = p_ChenhLechChiSo + (p_ChiSoCuoi - p_ChiSoDau)
                        Next

                        p_ChenhLechChiSo = (p_ChiSoMax - p_ChiSoMin)

                        p_ThucXuat_BD = p_ThucXuat
                        p_DuXuat_BD = p_DuXuat



                        If p_ThucXuat > p_DuXuat Then

                            p_TyLeChenhLech = TinhTyLeChenhLech(p_ThucXuat, p_DuXuat, p_ThucXuat)

                            p_DuXuat = p_DuXuat + p_DuXuat * (p_SAISOCHOPHEP / 100)

                            p_DuXuat = Math.Round(CDbl(p_DuXuat), 0, MidpointRounding.AwayFromZero)
                            p_ThucXuat = Math.Round(CDbl(p_ThucXuat), 0, MidpointRounding.AwayFromZero)


                            'If p_ThucXuat > p_DuXuat Then
                            If p_TyLeChenhLech > p_SAISOCHOPHEP Then
                                ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Chênh lệnh giữa dự xuất và thực xuất không được vượt quá " & p_SAISOCHOPHEP & "% lượng dự xuất")

                                '20160828
                                'anhqh
                                SetMarkItem(p_MaHangHoa)

                                '' Me.GridView2.Appearance.Row
                                'GridView1.SelectRow(1)
                                'GridView1.Appearance.Previe()
                                'GridView1.Appearance.SelectedRow.BackColor = Color.Red
                                'GridView1.Appearance.SelectedRow.BackColor2 = Color.Red
                                'GridView1.Appearance.SelectedRow.Options.UseBackColor = True
                                'GridView1.Appearance.SelectedRow.Options.UseForeColor = True
                                'GridView1.SelectRow(1)
                                'GridView1.Appearance.FocusedRow.BackColor = Color.AliceBlue



                                'GridView2.SelectRows(2, 3)

                                'For Each DataGridViewRow As DataRow In Me.GridView2.GetSelectedRow

                                '       DataGridViewRow.DefaultCellStyle.BackColor = Color.Blue;
                                'Next





                                KiemTraTyLeChenhLech = True
                                Exit Function
                            End If

                        End If

                        p_ThucXuat = p_ThucXuat_BD
                        p_DuXuat = p_DuXuat_BD

                        If p_ThucXuat < p_DuXuat Then
                            'anhqh  20160509  Kiem tra chenh lech theo cau hinh

                            p_TyLeChenhLech = TinhTyLeChenhLech(p_ThucXuat, p_DuXuat, p_ThucXuat)


                            p_DuXuat = p_DuXuat - p_DuXuat * (p_SAISOCHOPHEP / 100)

                            p_DuXuat = Math.Round(CDbl(p_DuXuat), 0, MidpointRounding.AwayFromZero)
                            p_ThucXuat = Math.Round(CDbl(p_ThucXuat), 0, MidpointRounding.AwayFromZero)


                            'If p_ThucXuat < p_DuXuat Then
                            If p_TyLeChenhLech > p_SAISOCHOPHEP Then
                                ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Chênh lệnh giữa dự xuất và thực xuất không được thấp quá " & p_SAISOCHOPHEP & "% lượng dự xuất")
                                KiemTraTyLeChenhLech = True
                                '20160828
                                'anhqh
                                SetMarkItem(p_MaHangHoa)

                                Exit Function
                            End If

                        End If


                        If p_SAISOCHOPHEPTHEOCTO = "Y" Then
                            If p_ChenhLechChiSo > p_ThucXuat Then


                                p_TyLeChenhLech = TinhTyLeChenhLech(p_ChenhLechChiSo, p_ThucXuat, p_ThucXuat)


                                p_ThucXuat = p_ThucXuat + p_ThucXuat * (p_SAISOCHOPHEPCTo / 100)

                                p_ChenhLechChiSo = Math.Round(CDbl(p_ChenhLechChiSo), 0, MidpointRounding.AwayFromZero)
                                p_ThucXuat = Math.Round(CDbl(p_ThucXuat), 0, MidpointRounding.AwayFromZero)

                                ' If p_ChenhLechChiSo > p_ThucXuat Then
                                If p_TyLeChenhLech > p_SAISOCHOPHEP Then
                                    '  End If
                                    ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Chênh lệnh giữa số công tơ và thực xuất không được vượt quá " & p_SAISOCHOPHEPCTo & "%")
                                    KiemTraTyLeChenhLech = True
                                    '20160828
                                    'anhqh
                                    SetMarkItem(p_MaHangHoa)
                                    Exit Function
                                End If

                            End If

                            If p_ChenhLechChiSo < p_ThucXuat Then

                                p_TyLeChenhLech = TinhTyLeChenhLech(p_ChenhLechChiSo, p_ThucXuat, p_ThucXuat)


                                p_ThucXuat = p_ThucXuat - p_ThucXuat * (p_SAISOCHOPHEPCTo / 100)

                                p_ChenhLechChiSo = Math.Round(CDbl(p_ChenhLechChiSo), 0, MidpointRounding.AwayFromZero)
                                p_ThucXuat = Math.Round(CDbl(p_ThucXuat), 0, MidpointRounding.AwayFromZero)


                                'If p_ChenhLechChiSo < p_ThucXuat Then
                                If p_TyLeChenhLech > p_SAISOCHOPHEP Then
                                    ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Chênh lệnh giữa số công tơ và thực xuất không được thấp quá " & p_SAISOCHOPHEPCTo & "%")
                                    KiemTraTyLeChenhLech = True
                                    '20160828
                                    'anhqh
                                    SetMarkItem(p_MaHangHoa)
                                    Exit Function
                                End If

                            End If
                        End If

                    Next
                End If
            End If


        Catch ex As Exception
            KiemTraTyLeChenhLech = True
        End Try
    End Function


    Private Sub SetMarkItem(ByVal p_MaHangHoa As String)
        Dim p_Count As Integer
        Dim p_Data As DataRow
        Exit Sub

        For p_Count = 0 To Me.GridView2.RowCount - 1
            p_Data = Me.GridView2.GetDataRow(p_Count)
            If Not p_Data Is Nothing Then
                If p_MaHangHoa.ToString.Trim = p_Data.Item("MaHangHoa").ToString.Trim Then
                    GridView2.SetRowCellValue(p_Count, "Record_Status", "Y")
                End If
            End If
        Next

        GridView2.MoveLast()
    End Sub

    Private Function TinhTyLeChenhLech(ByVal p_SoLon As Double, ByVal p_Sobe As Double, ByVal p_SoChia As Double) As Double
        Try
            If p_SoChia = 0 Then
                Return 0
            End If

            TinhTyLeChenhLech = Math.Abs((p_SoLon - p_Sobe) / p_SoChia) * 100
            TinhTyLeChenhLech = Math.Round(CDbl(TinhTyLeChenhLech), 2, MidpointRounding.AwayFromZero)
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        Dim p_SQL As String = ""
        If p_CHENHLECH_LUU = True Then
            If KiemTraTyLeChenhLech(True) = True Then
                Exit Sub
            End If

        End If

        If Me.FormStatus = True Then

            If KiemTRaTaiXuat() = False Then
                Exit Sub
            End If


            Me.SoTichKe.Focus()
            Me.GridView2.RefreshData()

            Me.Focus()

            If KiemTraHamhang() = False Then
                Exit Sub
            End If
            SaveRecode(False)
        End If
    End Sub

    Private Sub NhietDoTaiTau_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NhietDoTaiTau.EditValueChanged

    End Sub

    Private Sub LuongGiamDinh_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        Dim p_FrmExtraE5 As New FrmExtraE5
        Dim p_SoLenh As String = ""
        Dim p_Status = ""
        Dim p_SQL As String


        If Me.FormStatus = True Then
            ShowMessageBox("", "Lệnh xuất chưa được lưu")
            Exit Sub
        End If
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If p_SoLenh = "" Then
            Exit Sub
        End If

        p_SQL = ""
        If Not Me.Client.EditValue Is Nothing Then
            p_SQL = Me.Client.EditValue.ToString.Trim
        End If
        If p_SQL <> "" And p_SQL <> g_Terminal.ToString.Trim Then
            ShowMessageBox("", "Không thực hiện được với Lệnh xuất của kho khác")
            Exit Sub
        End If
        p_SQL = ""



        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If
        p_FrmExtraE5.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        p_FrmExtraE5.g_XtraServicesObj = g_XtraServicesObj
        'p_FrmExtraE5.DefaultWhere = "SoLenh='" & p_SoLenh & "'"
        p_FrmExtraE5.FormStatus = False
        p_FrmExtraE5.SoLenh = p_SoLenh
        p_FrmExtraE5.TrangThaiLenh = p_Status
        p_FrmExtraE5.p_XtraToolTripLabel = g_ToolStripStatus
        p_FrmExtraE5.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        p_FrmExtraE5.p_XtraMessageStatusl = g_MessageStatus
        p_FrmExtraE5.ShowDialog(Me)
    End Sub

    Private Sub Approved_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Approved.CheckedChanged
        Dim p_DateTime As DateTime
        Dim p_abc As U_TextBox.U_CheckBox

        ' p_abc = CType(sender, U_TextBox.U_CheckBox)
        Dim p_Value As String = "N"
        If Not Me.Approved.EditValue Is Nothing Then
            p_Value = Me.Approved.EditValue.ToString.Trim
        End If
        If p_Value = "Y" Then
            If p_APPROVED_DETAIL = True Then
                If p_CheckRollApproved() = True Then
                    Me.Approved.Checked = False
                    Exit Sub
                End If
            End If


            p_GetCurrentDate(p_DateTime)
            Me.Date_Approve.EditValue = p_DateTime
            'Me.Date_Approve.ShowDateTime 
            'Me.Date_Approve.Properties.DisplayFormat.FormatString
            'Me.Date_Approve.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
            'Me.Date_Approve.Properties.EditMask=

            Me.AppDesc.Properties.ReadOnly = False
            Me.User_Approve.EditValue = g_UserName
            Me.EditApprove.EditValue = "N"
        Else
            Me.Date_Approve.EditValue = Nothing
            Me.User_Approve.EditValue = Nothing
            Me.AppDesc.Properties.ReadOnly = True
            Me.AppDesc.EditValue = Nothing
        End If

    End Sub

    Private Sub GridView2_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged

    End Sub

    Private Sub GridView2_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanging
       
    End Sub

    Private Sub GridView2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.GridView2.FocusedRowHandle = Me.GridView2.FocusedRowHandle + 1
        End If
    End Sub


    Private Sub GridView2_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView2.ValidatingEditor
        Dim p_Approved As String = ""
        Dim p_Row As DataRow
        Dim p_Value As Double = 0
        Dim p_TyTrong As Double = 0
        Dim p_SQL As String
        Dim p_Table As DataTable
        Dim p_SoLenhSAP As String = ""
        Dim p_RowID As Integer = 0
        Dim p_Column As U_TextBox.GridColumn
        If Not Me.Approved.EditValue Is Nothing Then
            p_Approved = Me.Approved.EditValue.ToString.Trim
        End If
        If p_Approved.ToString.Trim = "Y" Then
            ShowMessageBox("", "Lệnh xuất đã được Phê duyệt")
            e.Valid = False
            Exit Sub
            'e.Value =s
        End If



        p_Column = Me.GridView2.FocusedColumn


        If p_KHONG_TDH = True Then

            If Not Me.SoLenh.EditValue Is Nothing Then
                p_SoLenhSAP = SoLenh.EditValue.ToString.Trim

            End If
            If (UCase(p_Column.FieldName) = "NHIETDO" Or UCase(p_Column.FieldName) = "SOLUONGTHUCXUAT") And p_SoLenhSAP <> "" Then
                Dim p_Grid As U_TextBox.GridView
                p_Grid = CType(sender, U_TextBox.GridView)
                p_Row = p_Grid.GetFocusedDataRow()
                Integer.TryParse(p_Row.Item("Row_id").ToString.Trim, p_RowID)
                p_SQL = "select  Dens_nd   from FPT_tblTankActive_V a where  exists (select 1 from  FPT_tblLenhXuatChiTietE5_V b where solenh='" & p_SoLenhSAP & "' and b.Row_id = " & p_RowID & " and a.Name_nd  = b.BeXuat and a.Date1 = b.NgayXuat )"
                p_Table = GetDataTable(p_SQL, p_SQL)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        Double.TryParse(p_Table.Rows(0).Item("Dens_nd").ToString.Trim, p_TyTrong)
                        p_Grid.SetFocusedRowCellValue("TyTrong_15", p_TyTrong)
                    End If
                End If
            End If
        End If

        

        If UCase(p_Column.FieldView.ToString) = "TYTRONG_15" Then
            If e.Value.ToString.Trim = "" Then
                Exit Sub
            End If
            p_Value = e.Value
            If p_Value > 1 Then
                '_Value = p_Value / 1000
                Select Case Len(p_Value.ToString.Trim)
                    Case 1
                        p_Value = p_Value / 10
                    Case 2
                        p_Value = p_Value / 100
                    Case 3
                        p_Value = p_Value / 1000
                    Case 4
                        p_Value = p_Value / 10000
                    Case Else
                        ShowMessageBox("", "Giá trị tỷ trọng không hợp lệ")
                        e.Valid = False
                        Exit Sub
                End Select

            End If
            p_Value = Math.Round(p_Value, 4)
            If p_Value > 0.5 And p_Value < 1 Then
                e.Value = p_Value
            Else
                ShowMessageBox("", "Giá trị tỷ trọng không hợp lệ")
                e.Valid = False
            End If

        End If

        If InStr(UCase("NhietDo,TyTrong_15,MaLuuLuongKe,Sl_llkebd,Sl_llkekt,GioBatDauBom,GioKetThucBom"), UCase(p_Column.FieldView.ToString), CompareMethod.Text) > 0 Then
            Me.GridView2.SetRowCellValue(Me.GridView2.FocusedRowHandle, "TrangThai", "U")
        End If

    End Sub
    Private Function p_CheckRollApproved() As Boolean
        Dim p_ArrRow() As DataRow
        Dim p_DataRow As DataRow
        Dim p_Count As Integer
        Dim p_CountLine As Integer
        Dim p_SAISOCHOPHEP As Double = 0

        Dim p_SAISOCHOPHEPCTo As Double = 0

        Dim p_SAISOCHOPHEPTHEONGAN As String = ""
        Dim p_TongThucXuat As Double = 0
        Dim p_TongDuXuat As Double = 0
        Dim p_ThucXuat As Double = 0
        Dim p_DuXuat As Double

        Dim p_ThucXuat_BD As Double = 0
        Dim p_DuXuat_BD As Double = 0
        Dim p_ChenhLech As Double = 0

        Dim p_ChiSoDau As Double = 0
        Dim p_ChiSoCuoi As Double = 0
        Dim p_ChenhLechChiSo As Double

        Dim p_DataHangHoa As DataTable
        Dim p_Binding As U_TextBox.U_BindingSource

        Dim p_FromDate As DateTime = Now
        Dim p_ToDate As DateTime
        Dim p_Status As String = "1"
        Dim p_SAISOCHOPHEPTHEOCTO As String = ""

        Dim p_SAISOCHOPHEPTHEOCTO_Thuy As String = ""
        Dim p_Approved As String = ""
        Dim p_LoaiXuat As String = "Bo"
        Dim p_TinhSaiSoChoPhep_Thuy As String
        Dim p_SaiSo_Thuy As Double

        Dim p_ChiSoMax As Double = 0
        Dim p_ChiSoMin As Double = 0

        Dim p_ArrRowRoll() As DataRow

        Try
            p_CheckRollApproved = False

            If Not Me.Status.EditValue Is Nothing Then
                p_Status = Me.Status.EditValue.ToString.Trim

            End If


            p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEP'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    If IsNumeric(p_ArrRow(0).Item("KEYVALUE").ToString.Trim) Then
                        p_SAISOCHOPHEP = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                    End If
                End If
            End If

            p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEPTHEOCTO'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    '  If IsNumeric(p_ArrRow(0).Item("KEYVALUE").ToString.Trim) Then
                    p_SAISOCHOPHEPTHEOCTO = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                    ' End If
                End If
            End If

            p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEPTHEOCTO_THUY'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    '  If IsNumeric(p_ArrRow(0).Item("KEYVALUE").ToString.Trim) Then
                    p_SAISOCHOPHEPTHEOCTO_Thuy = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                    ' End If
                End If
            End If



            p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEP_CTO'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    If IsNumeric(p_ArrRow(0).Item("KEYVALUE").ToString.Trim) Then
                        p_SAISOCHOPHEPCTo = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                    End If
                End If
            End If


            p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEPTHEONGAN'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    p_SAISOCHOPHEPTHEONGAN = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                End If
            End If

            p_TinhSaiSoChoPhep_Thuy = ""
            p_ArrRow = p_TableConfig.Select("KEYCODE='TINHSAISOCHOPHEP_THUY'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    p_TinhSaiSoChoPhep_Thuy = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                End If
            End If
            p_SaiSo_Thuy = 0
            p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEP_THUY'")
            If p_ArrRow.Length > 0 Then
                If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                    If IsNumeric(p_ArrRow(0).Item("KEYVALUE").ToString.Trim) Then
                        p_SaiSo_Thuy = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                    End If
                End If
            End If


            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_LoaiXuat = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            p_LoaiXuat = GetLoadingSite(p_LoaiXuat)
            If UCase(p_LoaiXuat) = "THUY" Then

                p_FromRate = 0
                p_ToRate = 0

                p_ToRate = p_SaiSo_Thuy

                If Not p_DataTableRoll Is Nothing Then
                    p_ArrRowRoll = p_DataTableRoll.Select("loadingSite='Thuy' or loadingSite='THUY' or loadingSite='' or loadingSite is null")


                    If p_ArrRowRoll.Length > 0 Then
                        Double.TryParse(p_ArrRowRoll(0).Item("FROM_RATE").ToString.Trim, p_FromRate)
                        Double.TryParse(p_ArrRowRoll(0).Item("TO_RATE").ToString.Trim, p_ToRate)
                    End If
                End If



                p_TinhSaiSoChoPhep_Thuy = ""
                p_ArrRow = p_TableConfig.Select("KEYCODE='TINHSAISOCHOPHEP_THUY'")
                If p_ArrRow.Length > 0 Then
                    If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        p_TinhSaiSoChoPhep_Thuy = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                    End If
                End If
                p_SaiSo_Thuy = 0
                p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEP_THUY'")
                If p_ArrRow.Length > 0 Then
                    If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        If IsNumeric(p_ArrRow(0).Item("KEYVALUE").ToString.Trim) Then
                            p_SaiSo_Thuy = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
                        End If
                    End If
                End If

                p_Binding = Me.TrueDBGrid2.DataSource
                p_DataHangHoa = CType(p_Binding.DataSource, DataTable)
                For p_Count = 0 To Me.GridView2.RowCount - 1
                    p_DataRow = GridView2.GetDataRow(p_Count)
                    p_ThucXuat = 0
                    p_DuXuat = 0
                    p_ThucXuat_BD = 0
                    p_DuXuat_BD = 0
                    p_ChenhLechChiSo = 0
                    p_ArrRow = p_DataHangHoa.Select("MaHangHoa='" & p_DataRow.Item("MaHangHoa").ToString.Trim & "'")
                    For p_CountLine = 0 To p_ArrRow.Length - 1
                        'Kiem tra duxuat va thuc xuat
                        p_ThucXuat = p_ThucXuat + IIf(p_ArrRow(p_CountLine).Item("SoLuongThucXuat").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("SoLuongThucXuat").ToString.Trim)
                        p_DuXuat = p_DuXuat + IIf(p_ArrRow(p_CountLine).Item("SoLuongDuXuat").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("SoLuongDuXuat").ToString.Trim)
                        p_ChiSoCuoi = IIf(p_ArrRow(p_CountLine).Item("Sl_llkekt").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("Sl_llkekt").ToString.Trim)
                        p_ChiSoDau = IIf(p_ArrRow(p_CountLine).Item("Sl_llkebd").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("Sl_llkebd").ToString.Trim)
                        p_ChenhLechChiSo = p_ChenhLechChiSo + (p_ChiSoCuoi - p_ChiSoDau)
                    Next
                    p_ThucXuat_BD = p_ThucXuat
                    p_DuXuat_BD = p_DuXuat



                    If p_ThucXuat <> p_DuXuat Then


                        p_ChenhLech = p_ThucXuat_BD - p_DuXuat_BD
                        p_ChenhLech = Math.Abs(Math.Round((p_ChenhLech / p_DuXuat_BD) * 100, 2))


                        'p_ChenhLech = TinhTyLeChenhLech(p_ThucXuat_BD, p_DuXuat_BD, p_DuXuat_BD)



                        If p_ChenhLech <= p_ToRate Then

                        Else
                            If p_ToRate = 0 Then
                                ShowMessageBox("", "Bạn không có quyền duyệt chênh lệch")
                            Else
                                ShowMessageBox("", "Bạn không có quyền duyệt chênh lệch vượt quá " & p_ToRate & "%")
                            End If

                            p_CheckRollApproved = True
                            Exit Function
                        End If
                        'If p_APPROVED_DETAIL = True Then
                        '    'anhqh  20160509  Kiem tra chenh lech theo cau hinh
                        '    p_ChenhLech = p_ThucXuat_BD - p_DuXuat_BD
                        '    p_ChenhLech = Math.Round((p_ChenhLech / p_DuXuat_BD) * 100, 2)

                        '    If p_ChenhLech >= p_FromRate And p_ChenhLech <= p_ToRate Then

                        '    Else
                        '        ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Chênh lệnh giữa dự xuất và thực xuất không được vượt quá " & p_ToRate & "% lượng dự xuất")
                        '        KiemTraTyLeChenhLech = True
                        '        Exit Function
                        '    End If
                        'End If
                        'Kiem tra theo roll phan quyen
                    End If


                    'anhqh
                    '20160728
                    'Phe duyet chenh lech cong to voi thuc xuat
                    If p_SAISOCHOPHEPTHEOCTO_Thuy = "Y" Then
                        'Kiem tra Chi so dau va cho so sau
                        p_ChiSoCuoi = IIf(p_DataRow.Item("Sl_llkekt").ToString.Trim = "", 0, p_DataRow.Item("Sl_llkekt").ToString.Trim)
                        p_ChiSoDau = IIf(p_DataRow.Item("Sl_llkebd").ToString.Trim = "", 0, p_DataRow.Item("Sl_llkebd").ToString.Trim)
                        p_ChenhLechChiSo = p_ChiSoCuoi - p_ChiSoDau

                        p_ThucXuat = IIf(p_DataRow.Item("SoLuongThucXuat").ToString.Trim = "", 0, p_DataRow.Item("SoLuongThucXuat").ToString.Trim)

                        If p_ChenhLechChiSo > p_ThucXuat Then
                            'p_ThucXuat = p_ThucXuat + p_ThucXuat * (p_SAISOCHOPHEPCTo / 100)
                            'If p_ChenhLechChiSo > p_ThucXuat Then
                            '    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa số công tơ và thực xuất không được vượt quá " & p_SAISOCHOPHEPCTo & "%")
                            '    p_CheckRollApproved = True
                            '    Exit Function
                            'End If

                            'anhqh  20160509  Kiem tra chenh lech theo cau hinh
                            p_ChenhLech = p_ChenhLechChiSo - p_ThucXuat_BD
                            p_ChenhLech = Math.Round((p_ChenhLech / p_ChenhLechChiSo) * 100, 2)

                            If p_ChenhLech <= p_ToRate Then

                            Else
                                If p_ToRate = 0 Then
                                    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch")
                                Else
                                    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch vượt quá " & p_ToRate & "%")
                                End If

                                p_CheckRollApproved = True
                                Exit Function
                            End If

                        End If

                        If p_ChenhLechChiSo < p_ThucXuat Then
                            'p_ThucXuat = p_ThucXuat - p_ThucXuat * (p_SAISOCHOPHEPCTo / 100)
                            'If p_ChenhLechChiSo < p_ThucXuat Then
                            '    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa số công tơ và thực xuất không được thấp quá " & p_SAISOCHOPHEPCTo & "%")
                            '    p_CheckRollApproved = True
                            '    Exit Function
                            'End If

                            'anhqh  20160509  Kiem tra chenh lech theo cau hinh
                            p_ChenhLech = p_ThucXuat_BD - p_ChenhLechChiSo
                            p_ChenhLech = Math.Round((p_ChenhLech / p_ChenhLechChiSo) * 100, 2)

                            If p_ChenhLech <= p_ToRate Then

                            Else
                                If p_ToRate = 0 Then
                                    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch")
                                Else

                                    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch  quá " & p_ToRate & "%")
                                End If

                                p_CheckRollApproved = True
                                Exit Function
                            End If


                        End If
                    End If
                Next
            Else   'Xuat Bo va Sat

                p_FromRate = 0
                p_ToRate = p_SAISOCHOPHEP    ' 0
                If Not p_DataTableRoll Is Nothing Then
                    p_ArrRowRoll = p_DataTableRoll.Select("loadingSite='Bo' or loadingSite='Bo' or loadingSite='Sat' or loadingSite='SAT'  or loadingSite='' or loadingSite is null")
                    If p_ArrRowRoll.Length > 0 Then
                        Double.TryParse(p_ArrRowRoll(0).Item("FROM_RATE").ToString.Trim, p_FromRate)
                        Double.TryParse(p_ArrRowRoll(0).Item("TO_RATE").ToString.Trim, p_ToRate)
                    End If
                End If


                If p_SAISOCHOPHEPTHEONGAN = "Y" Then  'Neu tinh chenh lech theo tung ngan
                    For p_Count = 0 To Me.GridView2.RowCount - 1
                        p_DataRow = GridView2.GetDataRow(p_Count)
                        'Kiem tra duxuat va thuc xuat
                        p_ThucXuat = IIf(p_DataRow.Item("SoLuongThucXuat").ToString.Trim = "", 0, p_DataRow.Item("SoLuongThucXuat").ToString.Trim)
                        p_DuXuat = IIf(p_DataRow.Item("SoLuongDuXuat").ToString.Trim = "", 0, p_DataRow.Item("SoLuongDuXuat").ToString.Trim)

                        p_ThucXuat_BD = p_ThucXuat
                        p_DuXuat_BD = p_DuXuat


                        If p_ThucXuat > p_DuXuat Then
                            'p_DuXuat = p_DuXuat + p_DuXuat * (p_SAISOCHOPHEP / 100)
                            'If p_ThucXuat > p_DuXuat Then
                            '    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa dự xuất và thực xuất không được vượt quá " & p_SAISOCHOPHEP & "% lượng dự xuất")
                            '    p_CheckRollApproved = True
                            '    Exit Function
                            'End If

                            'anhqh  20160509  Kiem tra chenh lech theo cau hinh
                            p_ChenhLech = p_ThucXuat_BD - p_DuXuat_BD
                            p_ChenhLech = Math.Round((p_ChenhLech / p_DuXuat_BD) * 100, 2, MidpointRounding.AwayFromZero)

                            If p_ChenhLech <= p_ToRate Then

                            Else
                                If p_ToRate = 0 Then
                                    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch")
                                Else

                                    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch vượt quá " & p_ToRate & "%")
                                End If

                                p_CheckRollApproved = True
                                Exit Function
                            End If


                        End If

                        If p_ThucXuat < p_DuXuat Then
                            'p_DuXuat = p_DuXuat - p_DuXuat * (p_SAISOCHOPHEP / 100)
                            'If p_ThucXuat < p_DuXuat Then
                            '    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa dự xuất và thực xuất không được thấp quá " & p_SAISOCHOPHEP & "% lượng dự xuất")
                            '    p_CheckRollApproved = True
                            '    Exit Function
                            'End If

                            'anhqh  20160509  Kiem tra chenh lech theo cau hinh
                            p_ChenhLech = p_DuXuat_BD - p_ThucXuat_BD
                            p_ChenhLech = Math.Round((p_ChenhLech / p_DuXuat_BD) * 100, 2, MidpointRounding.AwayFromZero)

                            If p_ChenhLech <= p_ToRate Then

                            Else
                                If p_ToRate = 0 Then
                                    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch")
                                Else

                                    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch thấp quá " & p_ToRate & "%")
                                End If

                                p_CheckRollApproved = True
                                Exit Function
                            End If

                        End If
                        If p_SAISOCHOPHEPTHEOCTO = "Y" Then
                            'Kiem tra Chi so dau va cho so sau
                            p_ChiSoCuoi = IIf(p_DataRow.Item("Sl_llkekt").ToString.Trim = "", 0, p_DataRow.Item("Sl_llkekt").ToString.Trim)
                            p_ChiSoDau = IIf(p_DataRow.Item("Sl_llkebd").ToString.Trim = "", 0, p_DataRow.Item("Sl_llkebd").ToString.Trim)
                            p_ChenhLechChiSo = p_ChiSoCuoi - p_ChiSoDau

                            p_ThucXuat = IIf(p_DataRow.Item("SoLuongThucXuat").ToString.Trim = "", 0, p_DataRow.Item("SoLuongThucXuat").ToString.Trim)

                            If p_ChenhLechChiSo > p_ThucXuat Then
                                'p_ThucXuat = p_ThucXuat + p_ThucXuat * (p_SAISOCHOPHEPCTo / 100)
                                'If p_ChenhLechChiSo > p_ThucXuat Then
                                '    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa số công tơ và thực xuất không được vượt quá " & p_SAISOCHOPHEPCTo & "%")
                                '    p_CheckRollApproved = True
                                '    Exit Function
                                'End If

                                'anhqh  20160509  Kiem tra chenh lech theo cau hinh
                                p_ChenhLech = p_ChenhLechChiSo - p_ThucXuat_BD
                                p_ChenhLech = Math.Round((p_ChenhLech / p_ChenhLechChiSo) * 100, 2, MidpointRounding.AwayFromZero)

                                If p_ChenhLech <= p_ToRate Then

                                Else
                                    If p_ToRate = 0 Then
                                        ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch")
                                    Else
                                        ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch vượt quá " & p_ToRate & "%")
                                    End If

                                    p_CheckRollApproved = True
                                    Exit Function
                                End If

                            End If

                            If p_ChenhLechChiSo < p_ThucXuat Then
                                'p_ThucXuat = p_ThucXuat - p_ThucXuat * (p_SAISOCHOPHEPCTo / 100)
                                'If p_ChenhLechChiSo < p_ThucXuat Then
                                '    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa số công tơ và thực xuất không được thấp quá " & p_SAISOCHOPHEPCTo & "%")
                                '    p_CheckRollApproved = True
                                '    Exit Function
                                'End If

                                'anhqh  20160509  Kiem tra chenh lech theo cau hinh
                                p_ChenhLech = p_ThucXuat_BD - p_ChenhLechChiSo
                                p_ChenhLech = Math.Round((p_ChenhLech / p_ChenhLechChiSo) * 100, 2, MidpointRounding.AwayFromZero)

                                If p_ChenhLech <= p_ToRate Then

                                Else
                                    If p_ToRate = 0 Then
                                        ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch")
                                    Else

                                        ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch  quá " & p_ToRate & "%")
                                    End If

                                    p_CheckRollApproved = True
                                    Exit Function
                                End If


                            End If
                        End If


                    Next
                    Exit Function
                End If

                If p_SAISOCHOPHEPTHEONGAN = "N" Or p_SAISOCHOPHEPTHEONGAN = "" Then  'Neu tinh chenh lech theo tung hang hoa
                    p_Binding = Me.TrueDBGrid2.DataSource
                    p_DataHangHoa = CType(p_Binding.DataSource, DataTable)
                    For p_Count = 0 To Me.GridView2.RowCount - 1
                        p_DataRow = GridView2.GetDataRow(p_Count)
                        p_ThucXuat = 0
                        p_DuXuat = 0
                        p_ThucXuat_BD = 0
                        p_DuXuat_BD = 0
                        p_ChenhLechChiSo = 0
                        p_ArrRow = p_DataHangHoa.Select("MaHangHoa='" & p_DataRow.Item("MaHangHoa").ToString.Trim & "'")

                        If p_ArrRow.Length > 0 Then
                            p_CountLine = 0
                            p_ChiSoMax = IIf(p_ArrRow(p_CountLine).Item("Sl_llkekt").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("Sl_llkekt").ToString.Trim)
                            p_ChiSoMin = IIf(p_ArrRow(p_CountLine).Item("Sl_llkebd").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("Sl_llkebd").ToString.Trim)
                        End If


                        For p_CountLine = 0 To p_ArrRow.Length - 1
                            'Kiem tra duxuat va thuc xuat
                            p_ThucXuat = p_ThucXuat + IIf(p_ArrRow(p_CountLine).Item("SoLuongThucXuat").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("SoLuongThucXuat").ToString.Trim)
                            p_DuXuat = p_DuXuat + IIf(p_ArrRow(p_CountLine).Item("SoLuongDuXuat").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("SoLuongDuXuat").ToString.Trim)
                            p_ChiSoCuoi = IIf(p_ArrRow(p_CountLine).Item("Sl_llkekt").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("Sl_llkekt").ToString.Trim)
                            p_ChiSoDau = IIf(p_ArrRow(p_CountLine).Item("Sl_llkebd").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("Sl_llkebd").ToString.Trim)
                            'p_ChenhLechChiSo = p_ChenhLechChiSo + (p_ChiSoCuoi - p_ChiSoDau)

                            If p_ChiSoDau < p_ChiSoMin Then
                                p_ChiSoMin = p_ChiSoDau
                            End If
                            If p_ChiSoCuoi > p_ChiSoMax Then
                                p_ChiSoMax = p_ChiSoCuoi
                            End If



                        Next

                        p_ChenhLechChiSo = (p_ChiSoMax - p_ChiSoMin)

                        p_ThucXuat_BD = p_ThucXuat
                        p_DuXuat_BD = p_DuXuat

                        If KiemTRaChenhLech3000L(p_DuXuat, p_ThucXuat, p_DuXuat) = False Then

                            'If KiemTraTyLeChenhLech(True, True) = False Then
                            '    Continue For
                            'End If


                            If p_ThucXuat > p_DuXuat Then


                                p_ChenhLech = p_ThucXuat_BD - p_DuXuat_BD
                                p_ChenhLech = Math.Round((p_ChenhLech / p_DuXuat_BD) * 100, 2, MidpointRounding.AwayFromZero)

                                If p_ChenhLech <= p_ToRate Then

                                    'If p_ChenhLech >= p_FromRate And p_ChenhLech <= p_ToRate Then
                                Else
                                    If p_ToRate = 0 Then
                                        ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch")
                                    Else
                                        ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch vượt quá " & p_ToRate & "%")
                                    End If

                                    p_CheckRollApproved = True
                                    Exit Function
                                End If
                                'Kiem tra theo roll phan quyen
                            End If

                            If p_ThucXuat < p_DuXuat Then

                                p_ChenhLech = p_DuXuat_BD - p_ThucXuat_BD
                                p_ChenhLech = Math.Round((p_ChenhLech / p_DuXuat_BD) * 100, 2, MidpointRounding.AwayFromZero)

                                If p_ChenhLech <= p_ToRate Then
                                    ' If p_ChenhLech >= p_FromRate And p_ChenhLech <= p_ToRate Then
                                Else
                                    If p_ToRate = 0 Then
                                        ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch")
                                    Else
                                        ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch thấp quá " & p_ToRate & "%")
                                    End If

                                    p_CheckRollApproved = True
                                    Exit Function
                                End If

                            End If

                        End If

                        'If p_ThucXuat > p_DuXuat Then


                        '    p_ChenhLech = p_ThucXuat_BD - p_DuXuat_BD
                        '    p_ChenhLech = Math.Round((p_ChenhLech / p_DuXuat_BD) * 100, 2, MidpointRounding.AwayFromZero)

                        '    If p_ChenhLech <= p_ToRate Then

                        '        'If p_ChenhLech >= p_FromRate And p_ChenhLech <= p_ToRate Then
                        '    Else
                        '        If p_ToRate = 0 Then
                        '            ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch")
                        '        Else
                        '            ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch vượt quá " & p_ToRate & "%")
                        '        End If

                        '        p_CheckRollApproved = True
                        '        Exit Function
                        '    End If
                        '    'Kiem tra theo roll phan quyen
                        'End If

                        'If p_ThucXuat < p_DuXuat Then

                        '    p_ChenhLech = p_DuXuat_BD - p_ThucXuat_BD
                        '    p_ChenhLech = Math.Round((p_ChenhLech / p_DuXuat_BD) * 100, 2, MidpointRounding.AwayFromZero)

                        '    If p_ChenhLech <= p_ToRate Then
                        '        ' If p_ChenhLech >= p_FromRate And p_ChenhLech <= p_ToRate Then
                        '    Else
                        '        If p_ToRate = 0 Then
                        '            ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch")
                        '        Else
                        '            ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch thấp quá " & p_ToRate & "%")
                        '        End If

                        '        p_CheckRollApproved = True
                        '        Exit Function
                        '    End If

                        'End If

                        If KiemTRaChenhLech3000L(p_DuXuat_BD, p_ChenhLechChiSo, p_ThucXuat_BD) = False Then

                            'If KiemTraTyLeChenhLech(True, True) = False Then
                            '    Continue For
                            'End If

                            If p_SAISOCHOPHEPTHEOCTO = "Y" Then
                                If p_ChenhLechChiSo > p_ThucXuat Then


                                    'anhqh  20160509  Kiem tra chenh lech theo cau hinh
                                    p_ChenhLech = p_ChenhLechChiSo - p_ThucXuat_BD
                                    p_ChenhLech = Math.Round((p_ChenhLech / p_ChenhLechChiSo) * 100, 2, MidpointRounding.AwayFromZero)

                                    If p_ChenhLech <= p_ToRate Then

                                    Else
                                        If p_ToRate = 0 Then
                                            ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch")
                                        Else
                                            ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch vượt quá " & p_ToRate & "%")
                                        End If

                                        p_CheckRollApproved = True
                                        Exit Function
                                    End If

                                End If

                                If p_ChenhLechChiSo < p_ThucXuat Then


                                    'anhqh  20160509  Kiem tra chenh lech theo cau hinh
                                    p_ChenhLech = p_ThucXuat_BD - p_ChenhLechChiSo
                                    p_ChenhLech = Math.Round((p_ChenhLech / p_ChenhLechChiSo) * 100, 2, MidpointRounding.AwayFromZero)

                                    If p_ChenhLech <= p_ToRate Then
                                        'If p_ChenhLech >= p_FromRate And p_ChenhLech <= p_ToRate Then

                                    Else
                                        If p_ToRate = 0 Then
                                            ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch")
                                        Else
                                            ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch  quá " & p_ToRate & "%")
                                        End If

                                        p_CheckRollApproved = True
                                        Exit Function
                                    End If


                                End If
                            End If
                        End If
                        'If p_SAISOCHOPHEPTHEOCTO = "Y" Then
                        '    If p_ChenhLechChiSo > p_ThucXuat Then


                        '        'anhqh  20160509  Kiem tra chenh lech theo cau hinh
                        '        p_ChenhLech = p_ChenhLechChiSo - p_ThucXuat_BD
                        '        p_ChenhLech = Math.Round((p_ChenhLech / p_ChenhLechChiSo) * 100, 2, MidpointRounding.AwayFromZero)

                        '        If p_ChenhLech <= p_ToRate Then

                        '        Else
                        '            If p_ToRate = 0 Then
                        '                ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch")
                        '            Else
                        '                ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch vượt quá " & p_ToRate & "%")
                        '            End If

                        '            p_CheckRollApproved = True
                        '            Exit Function
                        '        End If

                        '    End If

                        '    If p_ChenhLechChiSo < p_ThucXuat Then


                        '        'anhqh  20160509  Kiem tra chenh lech theo cau hinh
                        '        p_ChenhLech = p_ThucXuat_BD - p_ChenhLechChiSo
                        '        p_ChenhLech = Math.Round((p_ChenhLech / p_ChenhLechChiSo) * 100, 2, MidpointRounding.AwayFromZero)

                        '        If p_ChenhLech <= p_ToRate Then
                        '            'If p_ChenhLech >= p_FromRate And p_ChenhLech <= p_ToRate Then

                        '        Else
                        '            If p_ToRate = 0 Then
                        '                ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch")
                        '            Else
                        '                ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Bạn không có quyền duyệt chênh lệch  quá " & p_ToRate & "%")
                        '            End If

                        '            p_CheckRollApproved = True
                        '            Exit Function
                        '        End If


                        '    End If
                        'End If

                    Next
                End If
            End If

            'p_TongThucXuat = p_TongThucXuat + IIf(ToString.Trim = "SoLuongThucXuat", 0, p_DataRow.Item("SoLuongThucXuat").ToString.Trim)
            'p_TongDuXuat = p_TongDuXuat + IIf(ToString.Trim = "SoLuongDuXuat", 0, p_DataRow.Item("SoLuongDuXuat").ToString.Trim)

        Catch ex As Exception
            ShowMessageBox("", ex.Message)
            p_CheckRollApproved = True
        End Try
    End Function

    Private Sub LuongGiamDinh_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SetFoCus(LuongGiamDinh.Name)
        End If
    End Sub

    Function KiemTRaChenhLech3000L(ByVal p_Value1 As Double, ByVal p_Value2 As Double, ByVal p_SoThucXuat As Double) As Boolean

        Dim p_Value1Tmp As Double
        Dim p_Value2Tmp As Double
        Dim p_Value As Double

        p_Value1Tmp = Math.Round(p_Value1, 0, MidpointRounding.AwayFromZero)
        p_Value2Tmp = Math.Round(p_Value2, 0, MidpointRounding.AwayFromZero)

        KiemTRaChenhLech3000L = False
        If p_App3000 = False Then
            KiemTRaChenhLech3000L = False
            Exit Function
        End If

        If p_Value1 > p_App3000_Value Then
            KiemTRaChenhLech3000L = False
            Exit Function
        End If

        p_Value = Math.Abs(p_SoThucXuat - p_Value2)
        If p_Value <= p_App3000_App Then
            KiemTRaChenhLech3000L = True
            Exit Function
        End If
    End Function


    'Private Function KiemTraTyLeChenhLech(Optional ByVal p_KiemTraChenhLenh As Boolean = False) As Boolean
    '    Dim p_ArrRow() As DataRow
    '    Dim p_DataRow As DataRow
    '    Dim p_Count As Integer
    '    Dim p_CountLine As Integer
    '    Dim p_SAISOCHOPHEP As Double = 0

    '    Dim p_SAISOCHOPHEPCTo As Double = 0

    '    Dim p_SAISOCHOPHEPTHEONGAN As String = ""
    '    Dim p_TongThucXuat As Double = 0
    '    Dim p_TongDuXuat As Double = 0
    '    Dim p_ThucXuat As Double = 0
    '    Dim p_DuXuat As Double
    '    Dim p_ChiSoDau As Double = 0
    '    Dim p_ChiSoCuoi As Double = 0
    '    Dim p_ChenhLechChiSo As Double
    '    Dim p_DataHangHoa As DataTable
    '    Dim p_Binding As U_TextBox.U_BindingSource

    '    Dim p_FromDate As DateTime = Now
    '    Dim p_ToDate As DateTime
    '    Dim p_Status As String = "1"
    '    Dim p_SAISOCHOPHEPTHEOCTO As String = ""
    '    Dim p_Approved As String = ""
    '    Dim p_LoaiXuat As String = "Bo"
    '    Try
    '        KiemTraTyLeChenhLech = False

    '        If Not Me.Status.EditValue Is Nothing Then
    '            p_Status = Me.Status.EditValue.ToString.Trim

    '        End If
    '        If p_Status = "31" Or p_Status = "4" Or p_Status = "5" Then


    '            'Kiem tra Ngay gio bat dau va ngay gio ket thuc
    '            For p_Count = 0 To Me.GridView2.RowCount - 1
    '                p_FromDate = Now
    '                p_ToDate = p_FromDate
    '                p_DataRow = GridView2.GetDataRow(p_Count)
    '                If p_DataRow.Item("ThoiGianDau").ToString.Trim <> "" Then
    '                    p_FromDate = p_DataRow.Item("ThoiGianDau").ToString.Trim
    '                    p_ToDate = p_FromDate
    '                End If
    '                If p_DataRow.Item("ThoiGianCuoi").ToString.Trim <> "" Then
    '                    p_ToDate = p_DataRow.Item("ThoiGianCuoi").ToString.Trim
    '                    'p_ToDate = p_FromDate
    '                End If

    '                If p_ToDate <= p_FromDate Then
    '                    ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Giờ sau xuất phải lớn hơn Giờ xuất")
    '                    KiemTraTyLeChenhLech = True
    '                    Exit Function
    '                End If
    '            Next
    '        End If

    '        If Not Me.Approved.EditValue Is Nothing Then
    '            p_Approved = Me.Approved.EditValue.ToString.Trim
    '        End If
    '        If p_KiemTraChenhLenh = False Then
    '            KiemTraTyLeChenhLech = False
    '            Exit Function
    '        End If

    '        If p_Approved = "Y" Then
    '            KiemTraTyLeChenhLech = False
    '            Exit Function
    '        End If

    '        p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEP'")
    '        If p_ArrRow.Length > 0 Then
    '            If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
    '                If IsNumeric(p_ArrRow(0).Item("KEYVALUE").ToString.Trim) Then
    '                    p_SAISOCHOPHEP = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
    '                End If
    '            End If
    '        End If

    '        p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEPTHEOCTO'")
    '        If p_ArrRow.Length > 0 Then
    '            If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
    '                '  If IsNumeric(p_ArrRow(0).Item("KEYVALUE").ToString.Trim) Then
    '                p_SAISOCHOPHEPTHEOCTO = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
    '                ' End If
    '            End If
    '        End If

    '        p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEP_CTO'")
    '        If p_ArrRow.Length > 0 Then
    '            If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
    '                If IsNumeric(p_ArrRow(0).Item("KEYVALUE").ToString.Trim) Then
    '                    p_SAISOCHOPHEPCTo = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
    '                End If
    '            End If
    '        End If


    '        p_ArrRow = p_TableConfig.Select("KEYCODE='SAISOCHOPHEPTHEONGAN'")
    '        If p_ArrRow.Length > 0 Then
    '            If p_ArrRow(0).Item("KEYVALUE").ToString.Trim <> "" Then
    '                p_SAISOCHOPHEPTHEONGAN = p_ArrRow(0).Item("KEYVALUE").ToString.Trim()
    '            End If
    '        End If

    '        If Not Me.MaVanChuyen.EditValue Is Nothing Then
    '            p_LoaiXuat = Me.MaVanChuyen.EditValue.ToString.Trim
    '        End If
    '        p_LoaiXuat = GetLoadingSite(p_LoaiXuat)
    '        If UCase(p_LoaiXuat) = "THUY" Then

    '        Else   'Xuat Bo va Sat
    '            If p_SAISOCHOPHEPTHEONGAN = "Y" Then  'Neu tinh chenh lech theo tung ngan
    '                For p_Count = 0 To Me.GridView2.RowCount - 1
    '                    p_DataRow = GridView2.GetDataRow(p_Count)
    '                    'Kiem tra duxuat va thuc xuat
    '                    p_ThucXuat = IIf(p_DataRow.Item("SoLuongThucXuat").ToString.Trim = "", 0, p_DataRow.Item("SoLuongThucXuat").ToString.Trim)
    '                    p_DuXuat = IIf(p_DataRow.Item("SoLuongDuXuat").ToString.Trim = "", 0, p_DataRow.Item("SoLuongDuXuat").ToString.Trim)
    '                    If p_ThucXuat > p_DuXuat Then
    '                        p_DuXuat = p_DuXuat + p_DuXuat * (p_SAISOCHOPHEP / 100)
    '                        If p_ThucXuat > p_DuXuat Then
    '                            ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa dự xuất và thực xuất không được vượt quá " & p_SAISOCHOPHEP & "% lượng dự xuất")
    '                            KiemTraTyLeChenhLech = True
    '                            Exit Function
    '                        End If
    '                    End If

    '                    If p_ThucXuat < p_DuXuat Then
    '                        p_DuXuat = p_DuXuat - p_DuXuat * (p_SAISOCHOPHEP / 100)
    '                        If p_ThucXuat < p_DuXuat Then
    '                            ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa dự xuất và thực xuất không được thấp quá " & p_SAISOCHOPHEP & "% lượng dự xuất")
    '                            KiemTraTyLeChenhLech = True
    '                            Exit Function
    '                        End If
    '                    End If
    '                    If p_SAISOCHOPHEPTHEOCTO = "Y" Then
    '                        'Kiem tra Chi so dau va cho so sau
    '                        p_ChiSoCuoi = IIf(p_DataRow.Item("Sl_llkekt").ToString.Trim = "", 0, p_DataRow.Item("Sl_llkekt").ToString.Trim)
    '                        p_ChiSoDau = IIf(p_DataRow.Item("Sl_llkebd").ToString.Trim = "", 0, p_DataRow.Item("Sl_llkebd").ToString.Trim)
    '                        p_ChenhLechChiSo = p_ChiSoCuoi - p_ChiSoDau

    '                        p_ThucXuat = IIf(p_DataRow.Item("SoLuongThucXuat").ToString.Trim = "", 0, p_DataRow.Item("SoLuongThucXuat").ToString.Trim)

    '                        If p_ChenhLechChiSo > p_ThucXuat Then
    '                            p_ThucXuat = p_ThucXuat + p_ThucXuat * (p_SAISOCHOPHEPCTo / 100)
    '                            If p_ChenhLechChiSo > p_ThucXuat Then
    '                                ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa số công tơ và thực xuất không được vượt quá " & p_SAISOCHOPHEPCTo & "%")
    '                                KiemTraTyLeChenhLech = True
    '                                Exit Function
    '                            End If
    '                        End If

    '                        If p_ChenhLechChiSo < p_ThucXuat Then
    '                            p_ThucXuat = p_ThucXuat - p_ThucXuat * (p_SAISOCHOPHEPCTo / 100)
    '                            If p_ChenhLechChiSo < p_ThucXuat Then
    '                                ShowMessageBox("", "Ngăn " & p_DataRow.Item("MaNgan").ToString.Trim & ": Chênh lệnh giữa số công tơ và thực xuất không được thấp quá " & p_SAISOCHOPHEPCTo & "%")
    '                                KiemTraTyLeChenhLech = True
    '                                Exit Function
    '                            End If
    '                        End If
    '                    End If


    '                Next
    '                Exit Function
    '            End If

    '            If p_SAISOCHOPHEPTHEONGAN = "N" Or p_SAISOCHOPHEPTHEONGAN = "" Then  'Neu tinh chenh lech theo tung hang hoa
    '                p_Binding = Me.TrueDBGrid2.DataSource
    '                p_DataHangHoa = CType(p_Binding.DataSource, DataTable)
    '                For p_Count = 0 To Me.GridView2.RowCount - 1
    '                    p_DataRow = GridView2.GetDataRow(p_Count)
    '                    p_ThucXuat = 0
    '                    p_DuXuat = 0
    '                    p_ChenhLechChiSo = 0
    '                    p_ArrRow = p_DataHangHoa.Select("MaHangHoa='" & p_DataRow.Item("MaHangHoa").ToString.Trim & "'")
    '                    For p_CountLine = 0 To p_ArrRow.Length - 1
    '                        'Kiem tra duxuat va thuc xuat
    '                        p_ThucXuat = p_ThucXuat + IIf(p_ArrRow(p_CountLine).Item("SoLuongThucXuat").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("SoLuongThucXuat").ToString.Trim)
    '                        p_DuXuat = p_DuXuat + IIf(p_ArrRow(p_CountLine).Item("SoLuongDuXuat").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("SoLuongDuXuat").ToString.Trim)
    '                        p_ChiSoCuoi = IIf(p_ArrRow(p_CountLine).Item("Sl_llkekt").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("Sl_llkekt").ToString.Trim)
    '                        p_ChiSoDau = IIf(p_ArrRow(p_CountLine).Item("Sl_llkebd").ToString.Trim = "", 0, p_ArrRow(p_CountLine).Item("Sl_llkebd").ToString.Trim)
    '                        p_ChenhLechChiSo = p_ChenhLechChiSo + (p_ChiSoCuoi - p_ChiSoDau)
    '                    Next
    '                    If p_ThucXuat > p_DuXuat Then
    '                        p_DuXuat = p_DuXuat + p_DuXuat * (p_SAISOCHOPHEP / 100)
    '                        If p_ThucXuat > p_DuXuat Then
    '                            ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Chênh lệnh giữa dự xuất và thực xuất không được vượt quá " & p_SAISOCHOPHEP & "% lượng dự xuất")
    '                            KiemTraTyLeChenhLech = True
    '                            Exit Function
    '                        End If
    '                    End If

    '                    If p_ThucXuat < p_DuXuat Then
    '                        p_DuXuat = p_DuXuat - p_DuXuat * (p_SAISOCHOPHEP / 100)
    '                        If p_ThucXuat < p_DuXuat Then
    '                            ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Chênh lệnh giữa dự xuất và thực xuất không được thấp quá " & p_SAISOCHOPHEP & "% lượng dự xuất")
    '                            KiemTraTyLeChenhLech = True
    '                            Exit Function
    '                        End If
    '                    End If
    '                    If p_SAISOCHOPHEPTHEOCTO = "Y" Then
    '                        If p_ChenhLechChiSo > p_ThucXuat Then
    '                            p_ThucXuat = p_ThucXuat + p_ThucXuat * (p_SAISOCHOPHEPCTo / 100)
    '                            If p_ChenhLechChiSo > p_ThucXuat Then
    '                                ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Chênh lệnh giữa số công tơ và thực xuất không được vượt quá " & p_SAISOCHOPHEPCTo & "%")
    '                                KiemTraTyLeChenhLech = True
    '                                Exit Function
    '                            End If
    '                        End If

    '                        If p_ChenhLechChiSo < p_ThucXuat Then
    '                            p_ThucXuat = p_ThucXuat - p_ThucXuat * (p_SAISOCHOPHEPCTo / 100)
    '                            If p_ChenhLechChiSo < p_ThucXuat Then
    '                                ShowMessageBox("", "Mã hàng " & p_DataHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & ": Chênh lệnh giữa số công tơ và thực xuất không được thấp quá " & p_SAISOCHOPHEPCTo & "%")
    '                                KiemTraTyLeChenhLech = True
    '                                Exit Function
    '                            End If
    '                        End If
    '                    End If

    '                Next
    '            End If
    '        End If

    '        'p_TongThucXuat = p_TongThucXuat + IIf(ToString.Trim = "SoLuongThucXuat", 0, p_DataRow.Item("SoLuongThucXuat").ToString.Trim)
    '        'p_TongDuXuat = p_TongDuXuat + IIf(ToString.Trim = "SoLuongDuXuat", 0, p_DataRow.Item("SoLuongDuXuat").ToString.Trim)

    '    Catch ex As Exception
    '        KiemTraTyLeChenhLech = True
    '    End Try
    'End Function

    Private Sub LuongGiamDinh_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim p_Value As Double
        Dim p_LoaiXuat As String = ""
        Dim p_Int As Integer

        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            p_LoaiXuat = Me.MaVanChuyen.EditValue.ToString.Trim
            p_LoaiXuat = GetLoadingSite(p_LoaiXuat)
            If UCase(p_LoaiXuat) = "THUY" Then
                If Not Me.LuongGiamDinh.EditValue Is Nothing Then
                    If Me.LuongGiamDinh.EditValue.ToString.Trim <> "" Then
                        Try
                            p_Value = Me.LuongGiamDinh.EditValue
                            p_Int = p_Value
                            If InStr(Trim(Str(p_Value)), ".", CompareMethod.Text) > 0 Then
                                ShowMessageBox("", "Lượng giám định chỉ nhập số nguyên")
                                e.Cancel = True
                            End If
                        Catch ex As Exception
                            ShowMessageBox("", "Bạn đã nhập sai kiểu số")
                            e.Cancel = True
                        End Try
                    End If

                End If
            End If
        End If

    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        'Dim p_makho As String = ""
        Dim p_manguon As String = ""
        Dim p_MaVanChuyen As String = ""
        If Me.GridView2.RowCount <= 0 Then
            ShowMessageBox("", "Không xác định hàng hóa")
            Exit Sub
        End If
        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
        End If

        If Not Me.MaNguon.EditValue Is Nothing Then
            p_manguon = Me.MaNguon.EditValue.ToString.Trim
        End If
        p_MaVanChuyen = GetLoadingSite(p_MaVanChuyen)
        If UCase(p_MaVanChuyen) <> "THUY" Then
            ShowMessageBox("", "Chức năng chỉ dùng cho xuất thủy")
            Exit Sub
        End If
        Dim l_frm As FrmQCIThuy
        l_frm = New FrmQCIThuy(GridView1, Me.GridView2, p_makho, p_manguon)
        '   l_frm.Left = Me.Left + 362
        ' l_frm.Top = Me.Top + 340
        l_frm.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_SQL As String = ""
        Dim p_Status As String = "1"
        Dim p_SoLenh As String = ""



        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        If p_Status <> "3" And p_Status <> "31" Then
            ShowMessageBox("", "Trạng thái lệnh xuất không hợp lệ")
            Exit Sub
        End If


        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If p_SoLenh = "" Then
            ShowMessageBox("", "Số lệnh xuất không hợp lệ")
            Exit Sub
        End If

        p_ValueMess = g_Module.ShowMessage(Me, "", _
                                           "Bạn có chắn chắn muốn thực hiện không?", _
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
        p_SQL = "Update tblLenhXuatE5 set AppN30='Y', AppN30Date=getdate(), AppN30User='" & g_UserName & "' where SoLenh='" & p_SoLenh & "'"

        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then
            ShowMessageBox("", p_SQL)
        Else
            ShowStatusMessage(False, "", "Đã thực hiện xong", 7)
        End If

    End Sub



    Private Sub SetFoCus(ByVal p_Item As String)
        If UCase(p_Item) = "SOLENH" Or UCase(p_Item) = UCase("LuongGiamDinh") _
                Or UCase(p_Item) = UCase("NhietDoTaiTau") Or UCase(p_Item) = UCase("Niem") Or UCase(p_Item) = UCase("ghichu") Then
            Select Case UCase(p_Item)
                Case UCase("SoLenh")
                    Me.LuongGiamDinh.Focus()
                Case UCase("LuongGiamDinh")
                    Me.NhietDoTaiTau.Focus()
                Case UCase("NhietDoTaiTau")
                    Me.Niem.Focus()
                Case UCase("Niem")
                    Me.GhiChu.Focus()
                Case Else
                    Me.GridView1.Focus()
            End Select
        End If
    End Sub

    Private Sub SoLenh_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles SoLenh.KeyPress

    End Sub

    Private Sub NhietDoTaiTau_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NhietDoTaiTau.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    SetFoCus(NhietDoTaiTau.Name)
        'End If
    End Sub

    Private Sub Niem_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Niem.EditValueChanged

    End Sub

    Private Sub Niem_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Niem.KeyDown
        'If e.KeyCode = Keys.Enter Then

        '    SetFoCus(Niem.Name)
        'End If
    End Sub

    Private Sub GhiChu_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GhiChu.EditValueChanged

    End Sub

    Private Sub GhiChu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GhiChu.KeyDown
        'If e.KeyCode = Keys.Enter Then

        '    SetFoCus(GhiChu.Name)
        'End If
    End Sub

    Private Sub LuongGiamDinh_Validating1(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles LuongGiamDinh.Validating
        Dim p_Value As Double = 0.0
        If Not Me.LuongGiamDinh.EditValue Is Nothing Then
            If Me.LuongGiamDinh.EditValue.ToString.Trim <> "" Then
                p_Value = Me.LuongGiamDinh.EditValue
                p_Value = p_Value Mod 1
                If p_Value > 0 Then
                    ShowMessageBox("", "Lượng giám định chỉ nhập giá trị nguyên")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub


    Private Sub LuongGiamDinh_EditValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LuongGiamDinh.EditValueChanged

    End Sub

    Private Sub FrmGhiNhanThucXuat_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub FrmGhiNhanThucXuat_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate

    End Sub

    Private Function KiemTraHamhang() As Boolean
        Dim p_DataRow As DataRow
        Dim p_MaVanChuyen As String = ""
        Dim p_NumErr As Integer

        Try
            If p_CHIEUCAO_MD = True Then

                If KiemTraMucDau() = False Then
                    Return False
                    Exit Function
                End If
                Return True
            End If



            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            p_MaVanChuyen = GetLoadingSite(p_MaVanChuyen)
            If UCase(p_MaVanChuyen) <> "BO" Then
                Return True
            End If
            'GridView2.Appearance.SelectedRow.BackColor = Color.Red
            'GridView2.Appearance.SelectedRow.BackColor2 = Color.Red
            'GridView2.Appearance.SelectedRow.Options.UseBackColor = True
            'GridView2.Appearance.SelectedRow.Options.UseForeColor = True

            ' Me.GridView2.BaseInf

            GridView2.MoveFirst()
            For p_Count = 0 To Me.GridView2.RowCount - 1
                p_DataRow = Me.GridView2.GetDataRow(p_Count)
                If p_DataRow.Item("MaEntry").ToString.Trim = "" Then
                    If p_HHH = False Then
                        Me.GridView2.SetRowCellValue(p_Count, "MaEntry", 0)
                    Else

                        'SetColorRow(p_Count, "R")
                        p_NumErr = p_NumErr + 1
                    End If


                End If
                ' GridView2.SetFocusedRowModified()
                GridView2.MoveNext()

            Next

            If p_NumErr > 0 Then
                ShowMessageBox("", "Chiều cao hầm hàng chưa được nhập")
                Return False
            End If

            Return True
        Catch ex As Exception
            ShowMessageBox("", ex.Message)
            Return False
        End Try
    End Function



    Private Function KiemTraMucDau() As Boolean
        Dim p_DataRow As DataRow
        Dim p_MaVanChuyen As String = ""
        Dim p_NumErr As Integer

        Try

            If Not Me.MaVanChuyen.EditValue Is Nothing Then
                p_MaVanChuyen = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
            p_MaVanChuyen = GetLoadingSite(p_MaVanChuyen)
            If UCase(p_MaVanChuyen) <> "BO" Then
                Return True
            End If
            'GridView2.Appearance.SelectedRow.BackColor = Color.Red
            'GridView2.Appearance.SelectedRow.BackColor2 = Color.Red
            'GridView2.Appearance.SelectedRow.Options.UseBackColor = True
            'GridView2.Appearance.SelectedRow.Options.UseForeColor = True

            ' Me.GridView2.BaseInf

            GridView2.MoveFirst()
            For p_Count = 0 To Me.GridView2.RowCount - 1
                p_DataRow = Me.GridView2.GetDataRow(p_Count)
                If p_DataRow.Item("MaLo").ToString.Trim = "" Then
                    'If p_HHH = False Then
                    '    Me.GridView2.SetRowCellValue(p_Count, "MaLo", 0)
                    'Else

                    ''SetColorRow(p_Count, "R")
                    p_NumErr = p_NumErr + 1
                    'End If


                End If
                ' GridView2.SetFocusedRowModified()
                GridView2.MoveNext()

            Next

            If p_NumErr > 0 Then
                ShowMessageBox("", "Chiều cao mức dầu chưa được nhập")
                Return False
            End If

            Return True
        Catch ex As Exception
            ShowMessageBox("", ex.Message)
            Return False
        End Try
    End Function




    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        'Dim l_err As String
        '' If Me.rdoPXK.Checked = True Then
        'l_err = "HOADONVCNB"
        'Dim p_SoLenh As String = ""
        'If Not Me.SoLenh.EditValue Is Nothing Then
        '    p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        'End If
        'Dim Err As String = ""
        'If FPT_KiemTraKhiHoaDonDienTu(l_err, Err, p_SoLenh) = True Then
        '    ShowMessageBox("", Err)
        '    Return
        'End If

        'InChungTu(l_err)
        ''End If

        Dim p_SoLenhHDDT As String = ""
        Dim p_MaNguon As String = ""
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenhHDDT = Me.SoLenh.EditValue.ToString.Trim
        End If
        If Not Me.MaNguon.EditValue Is Nothing Then
            p_MaNguon = Me.MaNguon.EditValue.ToString.Trim
        End If

        Dim FrmLenhXuatAdd As New FrmInChungTu_HDDT
        FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj
        FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
        FrmLenhXuatAdd.g_FormAddnew = False
        FrmLenhXuatAdd.FormStatus = False
        FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
        FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
        FrmLenhXuatAdd.SoLenhHDDT = p_SoLenhHDDT
        FrmLenhXuatAdd.MaNguon = p_MaNguon
        FrmLenhXuatAdd.ShowDialog(Me)

        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False

          

    End Sub

    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        Dim l_err As String
        l_err = "HOADONGIUHO"
        InChungTu(l_err)
    End Sub


    Sub InChungTu(ByVal l_err As String)
        Dim Err As String = ""
        Dim p_SoLenh As String = ""
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If l_err.ToString.Trim <> "" And p_SoLenh <> "" Then

            If FPT_KiemTraKhiHoaDonDienTu(l_err, Err, p_SoLenh) = True Then
                ShowMessageBox("", Err)
                Return
            End If

            _Report_Object.clsInChungTu(Me.Owner, False, p_SoLenh, l_err)
            '  _HDDT_Object.clsInChungTu(Me, False, p_SoLenh, l_err)
        End If
    End Sub


    Private Sub ToolStripButton11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        Dim p_SQLErr As String
        Dim p_SoLenh As String = ""
        Dim g_LoaiHinhVanChuyen As String = ""
        Dim p_Table As DataTable
        Dim p_SQL As String



        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If p_SoLenh <> "" Then

            If Not Me.LoaiXuat.EditValue Is Nothing Then
                g_LoaiHinhVanChuyen = Me.LoaiXuat.EditValue.ToString.Trim
            End If

            p_SQL = "select Status from tbllenhxuate5 where solenh ='" & p_SoLenh & "'"
            p_Table = GetDataTable(p_SQL, p_SQLErr)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    If p_Table.Rows(0).Item(0).ToString.Trim <> "4" And p_Table.Rows(0).Item(0).ToString.Trim <> "5" Then
                        ShowMessageBox("", "Trạng thái lệnh xuất không hợp lệ")
                        Exit Sub
                    End If
                End If
            End If

            p_SQLErr = ""
            If p_Scadar_Type = "FOX" Then
                Dim p_FOx_Obj As New FOX_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

                p_SQLErr = p_FOx_Obj.clsB12_UpdateScadar(g_WareHouse, "out", p_SoLenh, g_LoaiHinhVanChuyen, g_Terminal)
                If p_SQLErr <> "" Then
                    ShowMessageBox("", p_SQLErr)
                    Exit Sub
                Else
                    Me.ShowStatusMessage(False, "MS908", "Cập nhật lên TĐH thành công")
                End If
            ElseIf p_Scadar_Type = "ACC" Then
                Dim p_Acc_Obj As New ACCESS_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

                p_SQLErr = p_Acc_Obj.clsB12_UpdateScadar(g_WareHouse, "out", p_SoLenh, g_LoaiHinhVanChuyen, g_Terminal)
                If p_SQLErr <> "" Then
                    ShowMessageBox("", p_SQLErr)
                    Exit Sub
                Else
                    Me.ShowStatusMessage(False, "MS908", "Cập nhật lên TĐH thành công")
                End If
            Else
                'Dim p_SAP_Obj As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
                'p_SQLErr = p_SAP_Obj.ClsScadarToHTTG("in", p_SoLenh, g_LoaiHinhVanChuyen, g_Terminal, True, g_E5)
                p_SQLErr = ""
                p_SQLErr = B12_UpdateScadar(g_WareHouse, "out", p_SoLenh, g_LoaiHinhVanChuyen, g_Terminal)
                If p_SQLErr <> "" Then
                    ShowMessageBox("", p_SQLErr)
                    Exit Sub
                Else
                    Me.ShowStatusMessage(False, "MS908", "Cập nhật lên TĐH thành công")
                End If
            End If

        End If

    End Sub

    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click
        Dim p_SoLenh As String = ""
        Dim p_Datatable As DataTable
        Dim p_Error As String = ""
        Dim p_Status As String = ""


        If p_BBGN_ALL = False And g_Company_Code = "6610" Then
            If p_MatKetNoiSAP = False Then
                ShowMessageBox("", "Chức năng chỉ sử dụng khi mất kết nối SAP")
                Exit Sub
            End If
        End If
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If Not Me.Status.EditValue Is Nothing Then
            p_Status = Me.Status.EditValue.ToString.Trim
        End If

        'Thuc hien lay so hoa don dien tu neu co
        If p_SoLenh = "" Then
            Exit Sub
        End If

        If p_BBGN_ALL = False Then
            If p_Status <> "4" Then
                ShowMessageBox("", "Trạng thái lệnh xuất không đúng")
                Exit Sub
            End If
        Else
            If p_Status <> "4" And p_Status <> "5" Then
                ShowMessageBox("", "Trạng thái lệnh xuất không đúng")
                Exit Sub
            End If
        End If
        'If p_MatKetNoiSAP = False Then  'Co ket noi SAP thi moi thuc hien 
        '    If p_SyncMaster.clsSyncHoaDonVAT(p_SoLenh, p_Datatable, p_Error) = False Then
        '        ShowMessageBox("", p_Error)
        '        Exit Sub
        '    End If
        'End If

        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then

                If g_Services.Sys_Execute_DataTbl(p_Datatable, p_Error) = False Then
                    'MsgBox(p_SQL)
                    ShowMessageBox("", p_Error)
                    Exit Sub
                    ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
                End If
            End If
        End If
        ' If l_err.ToString.Trim <> "" And p_SoLenh <> "" Then
        _Report_Object.clsInBienBanGiaoNhan(p_SoLenh)
        ' End If
        'Dim p_SoLenh As String = ""
        'Dim p_Datatable As DataTable
        'Dim p_Error As String = ""
        'If Not Me.SoLenh.EditValue Is Nothing Then
        '    p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        'End If
        ''Thuc hien lay so hoa don dien tu neu co
        'If p_SoLenh = "" Then
        '    Exit Sub
        'End If
        'If p_SyncMaster.clsSyncHoaDonVAT(p_SoLenh, p_Datatable, p_Error) = False Then
        '    ShowMessageBox("", p_Error)
        '    Exit Sub
        'End If
        'If Not p_Datatable Is Nothing Then
        '    If p_Datatable.Rows.Count > 0 Then

        '        If g_Services.Sys_Execute_DataTbl(p_Datatable, p_Error) = False Then
        '            'MsgBox(p_SQL)
        '            ShowMessageBox("", p_Error)
        '            Exit Sub
        '            ' g_Module.ModErrExceptionNew("MS003", "Đã cập nhật xong")
        '        End If
        '    End If
        'End If
        '' If l_err.ToString.Trim <> "" And p_SoLenh <> "" Then
        '_Report_Object.clsInBienBanGiaoNhan(p_SoLenh)
        '' End If
    End Sub

    Private Sub CmdSMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdSMO.Click
        Dim p_MainForm As Object
        Dim frmCollection As New FormCollection()

        frmCollection = Application.OpenForms()
        If Not frmCollection.Item("FrmSMOLenh") Is Nothing Then
            If frmCollection.Item("FrmSMOLenh").IsHandleCreated Then
                p_MainForm = frmCollection.Item("FrmSMOLenh")
                p_MainForm.Focus()
            Else
                Dim p_Form1 As New FrmSMOLenh(Me.Top, Me.Left, Me.Height, Me.Width)
                p_Form1.Show(Me)
            End If
        Else
            Dim p_Form1 As New FrmSMOLenh(Me.Top, Me.Left, Me.Height, Me.Width)
            p_Form1.Show(Me)
        End If      
    End Sub


    Private Sub SeStatusSMO()
        Dim p_MainForm As Object
        Dim p_SoLenh As String = ""
        If p_SMO_TICHKE = False Then
            Exit Sub
        End If
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
            If p_SoLenh <> "" Then
                Dim frmCollection As New FormCollection()
                frmCollection = Application.OpenForms()
                If Not frmCollection.Item("FrmSMOLenh") Is Nothing Then
                    If frmCollection.Item("FrmSMOLenh").IsHandleCreated Then
                        p_MainForm = frmCollection.Item("FrmSMOLenh")
                        p_MainForm.LoadData()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ToolStripButton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton13.Click
        Dim FrmLenhXuatAdd As New FrmGhiNhanThucXuatExt
        Dim p_SoLenh As String = ""

        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If
        If p_SoLenh = "" Then
            Exit Sub
        End If
        FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
        ' FrmLenhXuatAdd.g_FormAddnew = False
        FrmLenhXuatAdd.READ_ONLY = Me.READ_ONLY
        FrmLenhXuatAdd.FormStatus = False
        FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
        FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
        FrmLenhXuatAdd.pv_SoLenh = p_SoLenh
        FrmLenhXuatAdd.DefaultWhere = " WHERE SoLenh ='" & p_SoLenh & "'"
        FrmLenhXuatAdd.ShowDialog(Me)
    End Sub

    Private Sub ToolStripNhomBe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripNhomBe.Click

        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_SQL As String = ""
        Dim p_SoLenh As String = ""

        Try
            If Not Me.SoLenh.EditValue Is Nothing Then
                p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
            End If
        Catch ex As Exception

        End Try

        If p_SoLenh = "" Then
            ShowStatusMessage(True, "", "Lệnh xuất không xác định", 5)
            Exit Sub
        End If
        p_ValueMess = g_Module.ShowMessage(Me, "", _
                                                  "Bạn có chắc chắn muốn duyệt thông tin Nhóm bể/bể xuất không?", _
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

        p_SQL = "update  tbllenhxuate5 set  NhomBeAPP ='Y' , NhomBeAPPD =getdate(), NhomBeAPPU ='" & g_UserName & "' where SoLenh ='" & p_SoLenh & "'"
        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then
            ShowMessageBox("", p_SQL)
        Else
            ShowMessageBox("", "Đã thực hiện xong", 1)
            'ShowStatusMessage(False, "", "Đã thực hiện xong", 7)
        End If

    End Sub

    Private Sub NguoiVanChuyen_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NguoiVanChuyen.EditValueChanged

    End Sub
End Class