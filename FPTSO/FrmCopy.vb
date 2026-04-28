Public Class FrmCopy
    Public p_FrmSoLenh As String = ""
    Public p_LenhXuatLoai As String = ""
    Public p_LenhXuatPhieu As String = ""
    Dim p_Nguon As String = ""
    Public p_StringSoLenhReturn As String = ""

    Private Sub U_ButtonCus1_Click(sender As System.Object, e As System.EventArgs) Handles U_ButtonCus1.Click
        Requery("")
    End Sub

    Private Sub Requery(p_SoLenhTK As String)
        Dim p_SoLenhGoc As String = ""
        Dim p_SoLenh As String = ""
        Dim p_SQL As String = ""
        Dim p_Table As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource
       

        If p_SoLenhTK <> "" Then

            p_SQL = "select SoLenh as [Số lệnh], FromSoLenh as [Số lệnh gốc], NgayXuat as [Ngày xuất]," & _
                      " (select Description from sys_user where convert (nvarchar(20), User_ID) =lx.CreateBy)  " & _
                  " as [Người thực hiện], CreateDate as [Ngày thực hiện] " & _
                  " from  tblLenhXuatE5 lx 	where charindex (SoLenh,'" & p_SoLenhTK & "',1) >0   "   ' (SoLenhGoc='" & p_SoLenhTK & "') "
            'Else

            'If Not Me.SoLenhGoc_TK.EditValue Is Nothing Then
            '    p_SoLenhGoc = Me.SoLenhGoc_TK.EditValue.ToString.Trim
            'End If

            'If Not Me.SoLenh_TK.EditValue Is Nothing Then
            '    p_SoLenh = Me.SoLenh_TK.EditValue.ToString.Trim
            'End If

            'If p_SoLenh = "" And p_SoLenhGoc = "" Then
            '    ShowMessageBox("", "Tham số tìm kiếm chưa nhập")
            '    Exit Sub
            'End If


            'If p_SoLenh <> "" And p_SoLenhGoc <> "" Then
            '    p_SQL = "select SoLenh as [Số lệnh], SoLenhGoc as [Số lệnh gốc], NgayXuat as [Ngày xuất]," & _
            '          " (select Description from sys_user where convert (nvarchar(20), User_ID) =lx.CreateBy)  " & _
            '      " as [Người thực hiện], CreateDate as [Ngày thực hiện] " & _
            '      " from  tblLenhXuatE5 lx 	where (SoLenh ='" & p_SoLenh & "' and  SoLenhGoc='" & p_SoLenhGoc & "')  order by NgayXuat desc"
            'ElseIf p_SoLenh <> "" Then
            '    p_SQL = "select SoLenh as [Số lệnh], SoLenhGoc as [Số lệnh gốc], NgayXuat as [Ngày xuất]," & _
            '          " (select Description from sys_user where convert (nvarchar(20), User_ID) =lx.CreateBy)  " & _
            '      " as [Người thực hiện], CreateDate as [Ngày thực hiện] " & _
            '      " from  tblLenhXuatE5 lx 	where (SoLenh ='" & p_SoLenh & "' )  order by NgayXuat desc"
            'Else
            '    p_SQL = "select SoLenh as [Số lệnh], SoLenhGoc as [Số lệnh gốc], NgayXuat as [Ngày xuất]," & _
            '          " (select Description from sys_user where convert (nvarchar(20), User_ID) =lx.CreateBy)  " & _
            '      " as [Người thực hiện], CreateDate as [Ngày thực hiện] " & _
            '      " from  tblLenhXuatE5 lx 	where (SoLenhGoc='" & p_SoLenhGoc & "')  order by NgayXuat desc"
            'End If



            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                p_Binding.DataSource = p_Table
                Me.TrueDBGrid1.DataSource = p_Binding
                Me.TrueDBGrid1.RefreshDataSource()
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_ClickAAAA(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_SQL As String = ""
        Dim p_Table As DataTable
        Dim p_Exists As Boolean = False
        ' Dim p_SQL As String = ""
        Dim p_Row As DataRow
        Dim p_SoLenh As String = ""
        Dim p_SoLuong As Integer = 0
        Dim p_Count As Integer
        Dim p_Count2 As Integer

        Dim p_SoLenhMoi As String = ""
        Dim p_MaLenhMoi As String = ""
        Dim p_TableID As Integer = 0
        Dim p_SoLenhTmp As String = ""
        Dim p_TableHangHoa As DataTable
        Dim p_NgayXuat As Date = Nothing
        Dim p_MaVanChuyen As String = ""
        Dim p_TableExe As New DataTable("SQL")
        Dim p_FunctionTableId As String
        Dim p_mahanghoa As String = ""
        ' Dim p_Error As String = ""
        Dim p_date As Date
        Dim p_Time As Integer
        Dim p_ValueMess As Windows.Forms.DialogResult

        Dim p_MaNguon As String = ""

        p_GetDateTime(p_date, p_Time)


        If Not Me.SoLenhGoc.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenhGoc.EditValue.ToString.Trim
        End If

        If Not Me.NgayXuat.EditValue Is Nothing Then
            p_NgayXuat = Me.NgayXuat.EditValue
        End If


        If p_SoLenh = "" Then
            ShowMessageBox("", "Số lệnh gốc chưa nhập")
            Me.SoLenhGoc.Focus()
            Exit Sub
        End If

        p_SQL = "select SoLenh, MaVanChuyen, MaNguon from tblLenhxuate5 where solenh ='" & p_SoLenh & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_Exists = True
                p_MaVanChuyen = p_Table.Rows(0).Item("MaVanChuyen").ToString.Trim
                p_MaNguon = p_Table.Rows(0).Item("MaNguon").ToString.Trim
            End If
        End If

        If p_Exists = False Then
            ShowMessageBox("", "Số lệnh gốc không tồn tại")
            Me.SoLenhGoc.Focus()
            Exit Sub
        End If

        If InStr(p_Nguon, p_MaNguon, CompareMethod.Text) <= 0 Then
            ShowMessageBox("", "Chức năng sao chép chỉ thực hiện với nguồn (" & p_Nguon & ") ")
            ' Me.SoLuong.Focus()
            Exit Sub
        End If

        If Not Me.SoLuong.EditValue Is Nothing Then
            p_SoLuong = Me.SoLuong.EditValue
        End If

        If p_SoLuong <= 0 Then
            ShowMessageBox("", "Số lượng chưa nhập")
            Me.SoLuong.Focus()
            Exit Sub
        End If



        If Not IsDate(p_NgayXuat) Then
            ShowMessageBox("", "Ngày xuất chưa nhập")
            Me.NgayXuat.Focus()
            Exit Sub
        End If

        If p_NgayXuat < p_date Then
            ShowMessageBox("", "Ngày xuất phải >= Ngày hiện tại")
            Me.NgayXuat.Focus()
            Exit Sub
        ElseIf (g_KV1 = True) Then
            If p_NgayXuat > DateAdd(DateInterval.Day, 1, p_date) Then
                ShowMessageBox("", "Ngày xuất không được > Ngày hiện tại +1")
                Me.NgayXuat.Focus()
                Exit Sub

            End If
        Else
            If p_NgayXuat > p_date Then
                ShowMessageBox("", "Ngày xuất phải = Ngày hiện tại")
                Me.NgayXuat.Focus()
                Exit Sub

            End If

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
            Cursor = Cursors.Default
            Exit Sub
        End If





        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG where KEYCODE='TABLEID'"

        p_Table = GetDataTable(p_SQL, p_SQL)

        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_FunctionTableId = p_Table.Rows(0).Item("KEYVALUE").ToString.Trim
                'p_DataRow = p_TableConfig.Select("KEYCODE='SYS_MALENH_S'")
                'If p_DataRow.Length > 0 Then
                '    p_SYS_MALENH_S = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                'End If
                'p_DataRow = p_TableConfig.Select("KEYCODE='TABLEID'")
                'If p_DataRow.Length > 0 Then
                '    p_FunctionTableId = p_DataRow(0).Item("KEYVALUE").ToString.Trim
                'End If
            End If
        End If



        p_SQL = "select * from tbllenhxuat_hanghoae5 where SoLenh ='" & p_SoLenh & "'"
        p_TableHangHoa = GetDataTable(p_SQL, p_SQL)


        p_TableExe.Columns.Add("SQL_STR")

        Cursor = Cursors.WaitCursor
        Try
            For p_Count = 1 To p_SoLuong
                '  p_SoLenhMoi =
                p_SQL = "exec FPT_TaoMoiSoLenh_New"
                p_Table = GetDataTable(p_SQL, p_SQL)
                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        p_SoLenhTmp = p_Table.Rows(0).Item(0).ToString.Trim
                    End If
                End If

                If p_SoLenhTmp = "" Then
                    p_SQL = "exec FPT_TaoMoiSoLenh"
                    p_Table = GetDataTable(p_SQL, p_SQL)
                    If Not p_Table Is Nothing Then
                        If p_Table.Rows.Count > 0 Then
                            p_SoLenhMoi = p_Table.Rows(0).Item(0).ToString.Trim
                        End If
                    End If
                Else
                    p_SoLenhMoi = p_SoLenhTmp
                End If


                Dim p_SAP_Obj As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

                p_MaLenhMoi = p_SAP_Obj.clsFPT_GetMaLenh(p_SoLenhMoi)

                p_SQL = "INSERT INTO [tblLenhXuatE5]  ([MaLenh],[NgayXuat] ,[SoLenh] ,[MaDonVi],[MaNguon] ,[MaKho],[MaVanChuyen] " & _
                           ",[MaPhuongThucBan],[MaPhuongThucXuat] " & _
                           ",[MaKhachHang] ,[LoaiPhieu],[NgayHieuLuc],[Status],[Number] ,[Createby] ,[CreateDate] " & _
                           ",[Client],[HTTG] ,[NhaCungCap] ,[Slog],[NgayHetHieuLuc] ,[NguoiDaiDien],[DonViCungCapVanTai]  " & _
                           ",[DiemTraHang],[Tax] ,[PaymentMethod] ,[Term],[MaKhoNhap],[SoHopDong] ,[NgayHopDong] " & _
                           ",[TyGia],[SoTKHQNhap],[SoTKHQXuat],[SelfShipping],[PriceGroup] ,[Inco1],[Inco2] " & _
                           ",[SoPXK],[NgayPXK] ,[MaTuyenDuong] ,[XuatHangGui],[So_TKTN],[So_TKTX],[Ngay_TKTX] " & _
                           ",[PTXuat_ID],[DischargePoint] ,[DesDischargePoint] ,[BSART] ,[BWART],[VTWEG],[TenKhoNhap],[SoLenhGoc])"

                p_SQL = p_SQL & " SELECT  '" & p_MaLenhMoi & "' as  [MaLenh], '" & CDate(p_NgayXuat).ToString("yyyy-MM-dd") & "' as [NgayXuat] ," & _
                           "'" & p_SoLenhMoi & "' as [SoLenh] ,[MaDonVi],[MaNguon] ,[MaKho],[MaVanChuyen] " & _
                           ",[MaPhuongThucBan],[MaPhuongThucXuat] " & _
                           ",[MaKhachHang] ,[LoaiPhieu],[NgayHieuLuc],'2' as [Status],[Number] ," & g_User_ID & " as  [Createby] ,getdate() as [CreateDate] " & _
                           ",[Client],[HTTG] ,[NhaCungCap] ,[Slog],[NgayHetHieuLuc] ,[NguoiDaiDien],[DonViCungCapVanTai]  " & _
                           ",[DiemTraHang],[Tax] ,[PaymentMethod] ,[Term],[MaKhoNhap],[SoHopDong] ,[NgayHopDong] " & _
                           ",[TyGia],[SoTKHQNhap],[SoTKHQXuat],[SelfShipping],[PriceGroup] ,[Inco1],[Inco2] " & _
                           ",[SoPXK],[NgayPXK] ,[MaTuyenDuong] ,[XuatHangGui],[So_TKTN],[So_TKTX],[Ngay_TKTX] " & _
                           ",[PTXuat_ID],[DischargePoint] ,[DesDischargePoint] ,[BSART] ,[BWART],[VTWEG],[TenKhoNhap],'" & p_SoLenh & "' as [SoLenhGoc]  from [tblLenhXuatE5] " & _
                           " WHERE  SoLenh='" & p_SoLenh & "'"
                p_Row = p_TableExe.NewRow
                p_Row.Item(0) = p_SQL
                p_TableExe.Rows.Add(p_Row)
                If Not p_TableHangHoa Is Nothing Then
                    For p_Count2 = 0 To p_TableHangHoa.Rows.Count - 1
                        p_mahanghoa = p_TableHangHoa.Rows(p_Count2).Item("MaHangHoa").ToString.Trim
                        p_TableID = GetTableID(p_mahanghoa, p_MaVanChuyen, p_FunctionTableId)

                        p_SQL = "INSERT INTO [tblLenhXuat_HangHoaE5]([LineID],[MaLenh], [NgayXuat] , [SoLenh],[TongXuat] ,[TongDuXuat]" & _
                                    " ,[MaHangHoa],[DonViTinh],[TableID],[Createby],[CreateDate] " & _
                                    " ,[DonGia],[CurrencyKey],[GiaCty],[PhiVT],[TheBVMT]) "

                        p_SQL = p_SQL & " VALUES  ('" & p_TableHangHoa.Rows(p_Count2).Item("LineID").ToString.Trim & "' " & _
                                ", '" & p_MaLenhMoi & "' " & _
                                ",'" & CDate(p_NgayXuat).ToString("yyyy-MM-dd") & "' " & _
                                ",'" & p_SoLenhMoi & "' " & _
                                "," & p_TableHangHoa.Rows(p_Count2).Item("TongXuat").ToString.Trim & " " & _
                                 "," & p_TableHangHoa.Rows(p_Count2).Item("TongDuXuat").ToString.Trim & " " & _
                                  ",'" & p_mahanghoa & "' " & _
                                  ",'" & p_TableHangHoa.Rows(p_Count2).Item("DonViTinh").ToString.Trim & "' " & _
                                   ",'" & p_TableID & "' " & _
                                     ",'" & g_User_ID & "' , getdate () " & _
                                      "," & p_TableHangHoa.Rows(p_Count2).Item("DonGia").ToString.Trim & " " & _
                                       ",'" & p_TableHangHoa.Rows(p_Count2).Item("CurrencyKey").ToString.Trim & "' " & _
                                      "," & IIf(p_TableHangHoa.Rows(p_Count2).Item("GiaCty").ToString.Trim = "", 0, p_TableHangHoa.Rows(p_Count2).Item("GiaCty").ToString.Trim) & " " & _
                                 "," & IIf(p_TableHangHoa.Rows(p_Count2).Item("PhiVT").ToString.Trim = "", 0, p_TableHangHoa.Rows(p_Count2).Item("PhiVT").ToString.Trim) & " " & _
                                 "," & IIf(p_TableHangHoa.Rows(p_Count2).Item("TheBVMT").ToString.Trim = "", 0, p_TableHangHoa.Rows(p_Count2).Item("TheBVMT").ToString.Trim) & " " & _
                                " )"

                        p_Row = p_TableExe.NewRow
                        p_Row.Item(0) = p_SQL
                        p_TableExe.Rows.Add(p_Row)
                    Next
                End If

                If g_Services.Sys_Execute_DataTbl(p_TableExe, p_SQL) = False Then

                End If
                p_TableExe.Clear()


            Next

            'Me.SoLenhGoc_TK.EditValue = p_SoLenh
            Requery(p_SoLenh)
        Catch ex As Exception
            ShowMessageBox("", ex.Message)
            Cursor = Cursors.Default
        End Try

        Cursor = Cursors.Default

    End Sub




    '20200520  -- Ham copy lenh xuat
    Private Sub SaoChepLenhXuat()
        Dim p_DataRow As DataRow
        Dim p_SoLenh As String = ""
        Dim p_SQL As String = ""
        Dim p_SoLenhNew As String = ""
        Dim p_MaLenh As String = ""
        Dim p_DataTable As DataTable
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_SoLuong As Integer
        Dim p_NgayXuat As Date

        Dim p_Time As Integer
        Dim p_date As Date
        p_GetDateTime(p_date, p_Time)

        Dim p_Count As Integer

        If Not Me.SoLenhGoc.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenhGoc.EditValue.ToString.Trim
        End If

        If Not Me.NgayXuat.EditValue Is Nothing Then
            p_NgayXuat = Me.NgayXuat.EditValue
        End If


        If p_SoLenh = "" Then
            ShowMessageBox("", "Số lệnh gốc chưa nhập")
            Me.SoLenhGoc.Focus()
            Exit Sub
        End If

        'p_SQL = "select SoLenh, MaVanChuyen, MaNguon from tblLenhxuate5 where solenh ='" & p_SoLenh & "'"
        'p_Table = GetDataTable(p_SQL, p_SQL)
        'If Not p_Table Is Nothing Then
        '    If p_Table.Rows.Count > 0 Then
        '        p_Exists = True
        '        p_MaVanChuyen = p_Table.Rows(0).Item("MaVanChuyen").ToString.Trim
        '        p_MaNguon = p_Table.Rows(0).Item("MaNguon").ToString.Trim
        '    End If
        'End If

        'If p_Exists = False Then
        '    ShowMessageBox("", "Số lệnh gốc không tồn tại")
        '    Me.SoLenhGoc.Focus()
        '    Exit Sub
        'End If

        'If InStr(p_Nguon, p_MaNguon, CompareMethod.Text) <= 0 Then
        '    ShowMessageBox("", "Chức năng sao chép chỉ thực hiện với nguồn (" & p_Nguon & ") ")
        '    ' Me.SoLuong.Focus()
        '    Exit Sub
        'End If

        If Not Me.SoLuong.EditValue Is Nothing Then
            p_SoLuong = Me.SoLuong.EditValue
        End If

        If p_SoLuong <= 0 Then
            ShowMessageBox("", "Số lượng chưa nhập")
            Me.SoLuong.Focus()
            Exit Sub
        End If

        If Not IsDate(p_NgayXuat) Then
            ShowMessageBox("", "Ngày xuất chưa nhập")
            Me.NgayXuat.Focus()
            Exit Sub
        End If

        If p_NgayXuat < p_date Then
            ShowMessageBox("", "Ngày xuất phải >= Ngày hiện tại")
            Me.NgayXuat.Focus()
            Exit Sub
        ElseIf (g_KV1 = True) Then
            If p_NgayXuat > DateAdd(DateInterval.Day, 1, p_date) Then
                ShowMessageBox("", "Ngày xuất không được > Ngày hiện tại +1")
                Me.NgayXuat.Focus()
                Exit Sub

            End If
        Else
            If p_NgayXuat > p_date Then
                ShowMessageBox("", "Ngày xuất phải = Ngày hiện tại")
                Me.NgayXuat.Focus()
                Exit Sub

            End If

        End If



        p_ValueMess = g_Module.ShowMessage(Me, "", _
                                            "Bạn có chắc chắn muốn thực hiện không?", _
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

        For p_Count = 1 To p_SoLuong
            p_SoLenhNew = LaySoLenhMoi()
            If p_SoLenhNew = "" Then
                Continue For
                'Exit Sub
            End If
            p_MaLenh = FPT_GetMaLenh(p_SoLenh)
            If p_MaLenh = "0000" Then
                ShowMessageBox(True, "Mã lệnh đã có trong hệ thống", 3)
                Continue For
            End If

            p_SQL = "exec  SaoChepLenhXuat  '" & p_SoLenh & "','" & p_MaLenh & "','" & g_UserName & _
                            "','" & p_SoLenhNew & "','" & p_LenhXuatLoai & "','" & p_LenhXuatPhieu & "',0"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    If p_DataTable.Rows(0).Item(0) <> 0 Then
                        ShowMessageBox("", p_DataTable.Rows(0).Item(1), 3)
                    Else
                        'ShowMessageBox("", p_DataTable.Rows(0).Item(1) & "-" & p_DataTable.Rows(0).Item(2), 1)
                        'g_SoLenhCopy = p_SoLenhNew
                        '   Me.Close()
                        p_StringSoLenhReturn = p_StringSoLenhReturn & "," & p_SoLenhNew
                    End If
                End If

            Else
                ShowMessageBox("", "Lỗi khi thực hiện", 3)
            End If
        Next
    End Sub


    Function GetTableID(ByVal p_HangHoa As String, p_MaVanChuyen As String, p_FunctionTableId As String) As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        ' Dim p_FunctionTableId As String = ""
        Dim p_date As Date


        'anhqh   20160623  Dac thu rieng cua KV1
        If g_KV1 = True Then
            p_date = Me.NgayXuat.EditValue

            If p_MaVanChuyen = "ZR" Then
                p_SQL = " exec  FPT_GetTableID_KV1_NewNew '" & p_MaVanChuyen & "','" & p_date.ToString("yyyyMMdd") & "','" & p_HangHoa & "'"
            Else
                p_SQL = " exec  FPT_GetTableID_KV1_New '" & p_MaVanChuyen & "','" & p_date.ToString("yyyyMMdd") & "'"
            End If

        Else
            p_SQL = " exec " & p_FunctionTableId
        End If


        'p_SQL = " exec " & p_FunctionTableId
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



    Private Sub FrmCopy_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Dim p_FunctionTableId As String = ""
        Dim p_Table As DataTable
        Dim p_SQL As String
        Dim p_Date As Date
        Dim p_Time As Integer
        If p_FrmSoLenh = "" Then
            Me.SoLenhGoc.Properties.ReadOnly = False

        Else
            Me.SoLenhGoc.EditValue = p_FrmSoLenh
        End If

        p_GetDateTime(p_Date, p_Time)

        Me.NgayXuat.EditValue = p_Date
        Me.SoLuong.EditValue = 1

        'p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG where KEYCODE='NGUON'"

        'p_Table = GetDataTable(p_SQL, p_SQL)

        'If Not p_Table Is Nothing Then
        '    If p_Table.Rows.Count > 0 Then
        '        p_Nguon = p_Table.Rows(0).Item("KEYVALUE").ToString.Trim

        '    End If
        'End If

        'If p_Nguon.ToString.Trim = "" Then
        '    ShowMessageBox("", "Danh sách nguồn chưa được khai báo")
        '    Exit Sub
        'End If

        Requery("0000000099")
        Me.NgayXuat.EditValue = Now.Date
        Me.SoLuong.Focus()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        SaoChepLenhXuat()
        If p_StringSoLenhReturn <> "" Then
            p_StringSoLenhReturn = Mid(p_StringSoLenhReturn, 2)
            Requery(p_StringSoLenhReturn)
        End If
    End Sub
End Class