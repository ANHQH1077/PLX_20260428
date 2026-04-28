Public Class FrmLenhXuat_TaiXuatDO1
    Private p_SoDO2 As String = ""
    Public p_DataLineHH As DataTable
    Private p_MaVanChuyen As String = ""
    Public p_PhuongThucBan As String = ""
    Private p_Inco1 As String = ""


    Public g_LXPhieu As String = ""
    Public g_LXLoai As String = ""

    Public Property SoDO2 As String
        Get
            Return p_SoDO2
        End Get
        Set(ByVal value As String)
            If p_SoDO2 = value Then
                Return
            End If
            p_SoDO2 = value
        End Set
    End Property
    Private Sub FrmLenhXuat_NoiDiaDO1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String = ""
        Dim p_DataTable As DataTable
        Dim p_Exist As Boolean = False
        Dim p_SoLenh As String = ""
        Dim p_SoLenhTmp As String = ""
        Dim p_SoDO1 As String = ""
        Dim p_Row As DataRow
        Dim p_Count As Integer
        Dim p_DataTableLX As DataTable
        Dim p_KHoXuat As String = ""
        Dim p_NgayXuat As String = ""
        'p1_Company_Code
        Dim p_String As String = ""

        p_String = "Select PriceGroup, PriceGroupName from tblPriceGroup k1 " & _
                                "where PriceGroup  =case when isnull( :SoHopDong ,'') ='' then PriceGroup " & _
                                "else  (Select top 1 PriceGroup from tblProjects k with (nolock)  where  k.Vbeln =:SoHopDong  ) end "
        Me.PriceGroup.SqlString = p_String



        Me.MaKhoXuat.SqlString = "Select MaKho, TenKho from tblKho  where left(MaDonVi,2) ='" & Strings.Left(g_Company_Code, 2) & "'"

        '  Dim p_DataLine As DataTable
        'Dim p_Binding As U_TextBox.U_BindingSource

        p_SQL = "select Status, MakhachHang, TenKhachHang, SoHopDong, NgayHopDong, MaKho as MaKhoXuat, TenKho as TenKhoXuat " & _
                 ", MaKhoNhap, TenKhoNhap , NhaCungCap, TenNhaCungCap , PrcingDate, PaymentMethod, PhuongThucThanhToan as DesPaymentMethod " & _
                 ", Term,ThoiHanThanhToan as  DesTerm, PriceGroup, PriceGroupName, TyGia,  " & _
                 " So_TKTX as SoTKHQXuat, SoTKHQNhap,tax as VAT , MaVanChuyen, Inco1, MaPhuongThucBan  from FPT_tblLenhXuatE5_New_V  where SoLenh ='" & p_SoDO2 & "'"
        p_DataTableLX = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTableLX Is Nothing Then
            If p_DataTableLX.Rows.Count > 0 Then
                p_Exist = True
            End If
        End If

        If p_Exist = False Then
            ShowMessageBox("", "Số lệnh không đúng")
            Exit Sub
        End If
        If p_DataTableLX.Rows.Count > 0 Then
            If p_DataTableLX.Rows(0).Item("Status").ToString <> "2" Then
                Me.FormEdit = False
            End If

        End If
        Me.DefaultWhere = " WHERE SoLenh ='" & p_SoDO2 & "'"
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()


        If Not Me.SoLenh.EditValue Is Nothing Then
            p_SoLenh = Me.SoLenh.EditValue.ToString.Trim
        End If

        If p_SoLenh = "" Then
            p_SQL = "exec FPT_TaoMoiSoLenh_New"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_SoLenhTmp = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If


            'p_SQL = "select   Vbeln as SoHopDong, Kunnr as MaKhachHang, Inco1 from dbo.tblProjects with (nolock) where  Vkorg  in ('" & g_Company_Code & "')  and " & _
            '     "convert(date,getdate()) >= convert(date, case when isdate(Guebg) =1 then convert(date,Guebg)  else getdate() end ) " & _
            '     "and convert(date,getdate()) <= convert(date, case when isdate(Gueen) =1 then convert(date,Gueen)  else getdate() end) " & _
            '      "and Kunnr = :MaKhachHang and Vtweg = :MaPhuongThucBan"
            'Me.SoHopDong.SqlString = p_SQL

            p_SQL = "select   Vbeln as SoHopDong,  ZLSCH as PaymentMethod,ZTERM as Term, INCO2 as Inco2, Inco1, PriceGroup from dbo.tblProjects with (nolock) where  Vkorg  in ('" & g_Company_Code & "')  and " & _
                   "convert(date,getdate()) >= convert(date, case when isdate(Guebg) =1 then convert(date,Guebg)  else getdate() end ) " & _
              "and convert(date,getdate()) <= convert(date, case when isdate(Gueen) =1 then convert(date,Gueen)  else getdate() end) " & _
               "and Kunnr = :MaKhachHang and Vtweg = '" & p_PhuongThucBan & "'"
            Me.SoHopDong.SqlString = p_SQL

            p_SQL = ""


            If p_SoLenhTmp = "" Then
                p_SQL = "exec FPT_TaoMoiSoLenh"
                p_DataTable = GetDataTable(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        p_SoDO1 = p_DataTable.Rows(0).Item(0).ToString.Trim
                    End If
                End If
            Else
                p_SoDO1 = p_SoLenhTmp
            End If
            Me.SoDO1.EditValue = p_SoDO1

            Dim p_Binding As U_TextBox.U_BindingSource
            p_Binding = Me.TrueDBGrid1.DataSource
            p_DataTable = CType(p_Binding.DataSource, DataTable)
            Me.GridView1.AllowInsert = True
            If Not p_DataLineHH Is Nothing Then
                For p_Count = 0 To p_DataLineHH.Rows.Count - 1
                    Me.GridView1.AddNewRow()
                    Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, "MaHangHoa", p_DataLineHH.Rows(p_Count).Item("MaHangHoa").ToString.Trim)
                    Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, "TenHangHoa", p_DataLineHH.Rows(p_Count).Item("TenHangHoa").ToString.Trim)
                    Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, "LineID", p_DataLineHH.Rows(p_Count).Item("LineID").ToString.Trim)
                    Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, "SoLenh", p_DataLineHH.Rows(p_Count).Item("SoLenh").ToString.Trim)
                    Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, "CurrencyKey", p_DataLineHH.Rows(p_Count).Item("CurrencyKey").ToString.Trim)
                    Me.GridView1.SetRowCellValue(Me.GridView1.FocusedRowHandle, "DonViTinh", p_DataLineHH.Rows(p_Count).Item("DonViTinh").ToString.Trim)
                    '  p_Row = p_DataTable.NewRow
                    'p_Row.Item("MaHangHoa") = p_DataLineHH.Rows(p_Count).Item("MaHangHoa").ToString.Trim
                    'p_Row.Item("TenHangHoa") = p_DataLineHH.Rows(p_Count).Item("TenHangHoa").ToString.Trim
                    'p_Row.Item("LineID") = CInt(p_DataLineHH.Rows(p_Count).Item("LineID").ToString.Trim)
                    'p_Row.Item("SoLenh") = p_DataLineHH.Rows(p_Count).Item("SoLenh").ToString.Trim
                    'p_Row.Item("CurrencyKey") = p_DataLineHH.Rows(p_Count).Item("CurrencyKey").ToString.Trim
                    'p_Row.Item("CHECKUPD") = "Y"
                    ' p_DataTable.Rows.Add(p_Row)
                    GridView1.UpdateCurrentRow()
                Next

            End If
            Me.SoLenh.EditValue = p_SoDO2

            If p_DataTableLX.Rows.Count > 0 Then

                Me.SoHopDong.EditValue = p_DataTableLX.Rows(0).Item("SoHopDong").ToString
                If p_DataTableLX.Rows(0).Item("NgayHopDong").ToString <> "" Then
                    Me.NgayHopDong.EditValue = CDate(p_DataTableLX.Rows(0).Item("NgayHopDong").ToString)
                End If
              

                Me.MaKhoNhap.EditValue = p_DataTableLX.Rows(0).Item("MaKhoNhap").ToString
                Me.TenKhoNhap.EditValue = p_DataTableLX.Rows(0).Item("TenKhoNhap").ToString
                Me.MaNhaCungCap.EditValue = p_DataTableLX.Rows(0).Item("NhaCungCap").ToString
                Me.TenNhaCungCap.EditValue = p_DataTableLX.Rows(0).Item("TenNhaCungCap").ToString
                Me.PaymentMethod.EditValue = p_DataTableLX.Rows(0).Item("PaymentMethod").ToString
                Me.DesPaymentMethod.EditValue = p_DataTableLX.Rows(0).Item("DesPaymentMethod").ToString
                '               Status,MakhachHang , TenKhachHang,   
                Me.MaKhachHang.EditValue = p_DataTableLX.Rows(0).Item("MakhachHang").ToString
                Me.TenKhachHang.EditValue = p_DataTableLX.Rows(0).Item("TenKhachHang").ToString

                Me.Term.EditValue = p_DataTableLX.Rows(0).Item("Term").ToString
                Me.DesTerm.EditValue = p_DataTableLX.Rows(0).Item("DesTerm").ToString
                Me.PriceGroup.EditValue = p_DataTableLX.Rows(0).Item("PriceGroup").ToString
                Me.PriceGroupName.EditValue = p_DataTableLX.Rows(0).Item("PriceGroupName").ToString
                Me.SoTKHQXuat.EditValue = p_DataTableLX.Rows(0).Item("SoTKHQXuat").ToString
                Me.SoTKHQNhap.EditValue = p_DataTableLX.Rows(0).Item("SoTKHQNhap").ToString

                If p_DataTableLX.Rows(0).Item("TyGia").ToString <> "" Then
                    Me.TyGia.EditValue = p_DataTableLX.Rows(0).Item("TyGia").ToString
                End If


                If p_DataTableLX.Rows(0).Item("PrcingDate").ToString <> "" Then
                    Me.PrcingDate.EditValue = CDate(p_DataTableLX.Rows(0).Item("PrcingDate").ToString)
                    p_NgayXuat = CDate(PrcingDate.EditValue).ToString("yyyyMMdd")
                End If
                If p_DataTableLX.Rows(0).Item("VAT").ToString <> "" Then
                    Me.VAT.EditValue = p_DataTableLX.Rows(0).Item("VAT").ToString
                End If

                p_MaVanChuyen = p_DataTableLX.Rows(0).Item("MaVanChuyen").ToString
                p_PhuongThucBan = p_DataTableLX.Rows(0).Item("MaPhuongThucBan").ToString
                p_Inco1 = p_DataTableLX.Rows(0).Item("Inco1").ToString


                Me.MaKhoXuat.EditValue = p_DataTableLX.Rows(0).Item("MaKhoXuat").ToString
                'p_KHoXuat = p_DataTableLX.Rows(0).Item("MaKhoXuat").ToString
                Me.TenKhoXuat.EditValue = p_DataTableLX.Rows(0).Item("TenKhoXuat").ToString
                'If p_DataLineHH.Rows.Count > 0 Then
                '    If p_KHoXuat <> "" And p_NgayXuat <> "" Then
                '        ResetPrice()
                '    End If
                'End If
                ResetPrice()
                Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        saveRecord()
    End Sub

    Sub saveRecord()
        If Me.FormEdit = False Then
            Exit Sub
        End If
        If Me.FormStatus = True Then
            Me.DefaultSave = True
            Me.UpdateToDatabase(Me)
            Me.DefaultSave = False
            Me.GridView1.AllowInsert = False
            If Me.FormStatus = False Then
                Me.DefaultFormLoad = True
                Me.LoadDataToForm()

                Dim p_DO1 As String = ""
                Dim p_DO2 As String = ""
                Dim p_SQL As String = ""
                Dim p_PriceGroup As String = ""
                Dim p_DataTable As DataTable

                If Not Me.SoDO1.EditValue Is Nothing Then
                    p_DO1 = Me.SoDO1.EditValue.ToString.Trim
                End If
                If Not Me.SoLenh.EditValue Is Nothing Then
                    p_DO2 = Me.SoLenh.EditValue.ToString.Trim
                End If

                If Not Me.PriceGroup.EditValue Is Nothing Then
                    p_PriceGroup = Me.PriceGroup.EditValue.ToString.Trim
                End If

                If p_DO1 <> "" And p_DO2 <> "" Then
                    p_SQL = "select 1 from tblDO_Header k with (nolock) where SoLenh ='" & p_DO2 & "'"
                    p_DataTable = GetDataTable(p_SQL, p_SQL)
                    If Not p_DataTable Is Nothing Then
                        If p_DataTable.Rows.Count > 0 Then
                            p_SQL = "update tblLenhXuate5  set PriceGroupDO1 = '" & p_PriceGroup & "'  where  SoLenh  ='" & p_DO2 & "'  "
                            If g_Services.Sys_Execute(p_SQL, _
                                                 p_SQL) = False Then
                                'ShowMessageBox("", p_SQLErr)
                            End If
                        End If
                    End If
                End If

            End If
            Me.GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
        Else
            'Dim p_DO1 As String = ""
            'Dim p_DO2 As String = ""
            'Dim p_SQL As String = ""
            'Dim p_PriceGroup As String = ""
            'Dim p_DataTable As DataTable

            'If Not Me.SoDO1.EditValue Is Nothing Then
            '    p_DO1 = Me.SoDO1.EditValue.ToString.Trim
            'End If
            'If Not Me.SoLenh.EditValue Is Nothing Then
            '    p_DO2 = Me.SoLenh.EditValue.ToString.Trim
            'End If

            'If Not Me.PriceGroup.EditValue Is Nothing Then
            '    p_PriceGroup = Me.PriceGroup.EditValue.ToString.Trim
            'End If

            'If p_DO1 <> "" And p_DO2 <> "" Then
            '    p_SQL = "select 1 from tblDO_Header k with (nolock) where SoLenh ='" & p_DO2 & "'"
            '    p_DataTable = GetDataTable(p_SQL, p_SQL)
            '    If Not p_DataTable Is Nothing Then
            '        If p_DataTable.Rows.Count > 0 Then
            '            p_SQL = "update tblLenhXuate5  set PriceGroupDO1 = '" & p_PriceGroup & "'  where  SoLenh  ='" & p_DO2 & "'  "
            '            If g_Services.Sys_Execute(p_SQL, _
            '                                 p_SQL) = False Then
            '                'ShowMessageBox("", p_SQLErr)
            '            End If
            '        End If
            '    End If
            'End If

        End If

    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub



    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        'Dim p_Value As String = ""
        'Dim p_DuXuat As Double = 0
        'Dim p_Status As String = ""
        Dim p_Row As DataRow
        Dim p_SQL As String
        Dim p_MaPTB As String = ""
        Dim p_MaHH As String = ""
        Dim p_DVT As String = ""
        Dim p_MaKH As String = ""
        Dim p_Term As String = ""
        Dim p_PriceGroup As String = ""
        Dim p_Inco1 As String = ""
        Dim p_Inco2 As String = ""
        Dim p_NgayXuat As Date
        Dim p_DataTable As DataTable
        Dim p_DataTable22 As DataTable
        Dim p_DataTable33 As DataTable
        Dim p_SoHopDong As String
        Dim p_LoaiTien As String
        Dim p_RowCheck() As DataRow
        Dim p_DataSet As DataSet
        Dim p_MaTuyenDuong As String = ""
        Dim p_LHVT As String = ""
        Dim p_Value As Double
        Dim p_Count As Integer
        Dim p_TongDonGia As Double
        ' Dim 
        Dim p_ThueBVMT, p_PhiVT, p_GiaCty As Double

        Dim p_Nguon, p_PTBan As String
        'd()


        If UCase(e.Column.FieldName) = UCase("PhiVT") Or UCase(e.Column.FieldName) = UCase("TheBVMT") Or UCase(e.Column.FieldName) = UCase("GiaCty") Then
            If Not e.Value Is Nothing Then
                'p_Value = e.Value
                p_Row = Me.GridView1.GetFocusedDataRow
                If p_Row Is Nothing Then
                    Exit Sub
                End If

                If UCase(e.Column.FieldName) = UCase("PhiVT") Or UCase(e.Column.FieldName) = UCase("TheBVMT") Or UCase(e.Column.FieldName) = UCase("PhiVT") Or UCase(e.Column.FieldName) = UCase("GiaCty") Then
                    Double.TryParse(p_Row.Item("DonGia").ToString.Trim, p_Value)
                    p_TongDonGia = GetTongDonGia()
                    If p_TongDonGia = p_Value Then
                        Exit Sub
                    End If
                    TongDonGia()
                    Exit Sub
                End If

                'If UCase(e.Column.FieldName) = UCase("TheBVMT") Then
                '    Double.TryParse(p_Row.Item("DonGia").ToString.Trim, p_Value)
                '    p_TongDonGia = GetTongDonGia()
                'End If

                'If Not Me.MaPhuongThucBan.EditValue Is Nothing Then
                '    p_MaPTB = Me.MaPhuongThucBan.EditValue.ToString.Trim()
                'End If
                p_MaHH = p_Row.Item("MaHangHoa").ToString.Trim()
                p_DVT = p_Row.Item("DonViTinh").ToString.Trim()

                'p_SoHopDong = ""

                'If Not Me.SoHopDong.EditValue Is Nothing Then
                '    p_SoHopDong = Me.SoHopDong.EditValue.ToString.Trim
                'End If

                'If p_SoHopDong <> "" Then
                '    p_RowCheck = p_tblProject_Details.Select("Vbeln='" & p_SoHopDong & "' and  Matnr='" & p_MaHH & "'")
                '    If p_RowCheck.Length > 0 Then
                '        'For p_Count = 0 To p_RowCheck.Length - 1
                '        '    If p_MaHH.ToString.Trim <> "" Then
                '        '        If p_MaHH <> p_RowCheck(p_Count).Item("Matnr").ToString.Trim Then

                '        '        End If
                '        '    End If
                '        'Next


                '        If p_DVT.ToString.Trim <> "" Then
                '            p_DVT = p_RowCheck(0).Item("Meins").ToString.Trim
                '            p_Row.Item("DonViTinh") = p_DVT
                '            'If p_DVT <> p_RowCheck(0).Item("Meins").ToString.Trim Then
                '            '    ShowMessageBox("", "Đơn vị tính không khớp trong hợp đồng")

                '            '    Exit Sub
                '            'End If
                '        Else
                '            p_DVT = p_RowCheck(0).Item("Meins").ToString.Trim
                '            p_Row.Item("DonViTinh") = p_DVT
                '        End If
                '    Else
                '        ShowMessageBox("", "Mã hàng không khớp trong hợp đồng")
                '        Exit Sub
                '    End If
                'End If




                If Not Me.MaKhachHang.EditValue Is Nothing Then
                    p_MaKH = Me.MaKhachHang.EditValue.ToString.Trim()
                End If
                If Not Me.Term.EditValue Is Nothing Then
                    p_Term = Me.Term.EditValue.ToString.Trim()
                End If
                If Not Me.PriceGroup.EditValue Is Nothing Then
                    p_PriceGroup = Me.PriceGroup.EditValue.ToString.Trim()
                End If
                'If Not Me.Inco1.EditValue Is Nothing Then
                '    p_Inco1 = Me.Inco1.EditValue.ToString.Trim()
                'End If
                'If Not Me.Inco2.EditValue Is Nothing Then
                '    p_Inco2 = Me.Inco2.EditValue.ToString.Trim()
                'End If
                'If Not Me.NgayXuat.EditValue Is Nothing Then
                '    p_NgayXuat = Me.NgayXuat.EditValue.ToString.Trim()
                'End If


                'p_Nguon = ""
                'p_PTBan = ""
                'If Not Me.MaNguon.EditValue Is Nothing Then
                '    p_Nguon = Me.MaNguon.EditValue.ToString.Trim()
                'End If

                'If Not Me.MaPhuongThucBan.EditValue Is Nothing Then
                '    p_PTBan = Me.MaPhuongThucBan.EditValue.ToString.Trim()
                'End If



                '               FPT_LayGiaCongTy()
                '@p_SaleOrg nvarchar(50), --	Công ty-Client
                '@p_DistributionChanel nvarchar(50), --	Phương thức bán
                '@p_Customer nvarchar(50)    ,   --- Khach hang	
                '@p_Material nvarchar(50),   --	Mã mặt hàng
                '@p_SaleUnit nvarchar(50),  --	Đơn vị tính dự xuất	
                '@p_PaymentTerm nvarchar(50),  --	Phương thức thanh toán	
                '@p_NgayXuat datetime  --Ngay xuat tren lệnh

                p_LoaiTien = ""
                Select Case p_PTBan
                    Case "05", "06"
                        '  Me.GridView1.SetFocusedRowCellValue("CurrencyKey", "USD")
                        p_LoaiTien = "USD"
                    Case "07", "08", "09", "10"
                        ' Me.GridView1.SetFocusedRowCellValue("CurrencyKey", "VND")
                        p_LoaiTien = "VND"
                    Case Else
                        'If Not p_DataTable Is Nothing Then
                        '    If p_DataTable.Rows.Count > 0 Then
                        '        ' Me.GridView1.SetFocusedRowCellValue("DonGia", p_DataTable.Rows(0).Item("DonGia").ToString)
                        '        Me.GridView1.SetFocusedRowCellValue("CurrencyKey", p_DataTable.Rows(0).Item("WAERS").ToString)
                        '    End If
                        'End If
                        p_LoaiTien = "VND"
                End Select
                ' Me.GridView1.SetFocusedRowCellValue("CurrencyKey", p_LoaiTien)



                Dim p_DonViCCVT As String = ""
                If Not Me.PriceGroup.EditValue Is Nothing Then
                    p_PriceGroup = Me.PriceGroup.EditValue.ToString.Trim()
                End If


                p_SQL = "exec FPT_LayGiaCongTy_TaiXuat '" & g_Company_Code & "' " & _
                              ",'" & p_PTBan & "' " & _
                              ",'" & p_MaKH & "' " & _
                              ",'" & p_MaHH & "' " & _
                              ",'" & p_DVT & "' " & _
                              ",'" & p_Term & "' " & _
                              ",'" & p_NgayXuat.ToString("yyyyMMdd") & "' " & _
                              ",'" & p_LoaiTien & "' " & _
                                ",'" & p_MaTuyenDuong & "' " & _
                                  ",'" & p_LHVT & "' " & _
                                  ",'" & p_PriceGroup & "','" & p_Inco1 & "' " & _
                                  ",'" & p_DonViCCVT & "' " & _
                              ""

                'p_SQL = "exec FPT_GetPrice '" & p_MaPTB & "','" & p_MaHH & "','" & p_DVT & "','" & p_MaKH & "','" & p_Term & _
                '        "','" & p_PriceGroup & "','" & p_Inco1 & "','" & p_Inco2 & "','" & p_NgayXuat.ToString("yyyyMMdd") & "'"
                p_DataSet = g_Services.Sys_SYS_GET_DATASet_Des(p_SQL, p_SQL)
                If p_DataSet Is Nothing Then
                    Exit Sub
                End If
                If p_DataSet.Tables.Count <= 0 Then
                    Exit Sub
                End If
                p_DataTable = p_DataSet.Tables(0)
                If p_DataTable.Rows.Count <= 0 Then
                    p_DataTable = p_DataSet.Tables(1)
                End If

                p_DataTable22 = p_DataSet.Tables(2)
                p_DataTable33 = p_DataSet.Tables(3)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        ' p_Row = Me.GridView1.GetFocusedDataRow
                        p_Row.Item("CurrencyKey") = p_LoaiTien
                        p_ThueBVMT = 0
                        p_PhiVT = 0
                        p_GiaCty = 0
                        Double.TryParse(p_DataTable.Rows(0).Item("DonGia").ToString, p_GiaCty)



                        ' Me.GridView1.SetFocusedRowCellValue("CurrencyKey", )

                        p_Row.Item("GiaCty") = p_GiaCty ' p_DataTable.Rows(0).Item("DonGia").ToString
                        p_Row.Item("Z001_PER") = p_DataTable.Rows(0).Item("KPEIN").ToString

                        'Me.GridView1.SetFocusedRowCellValue("GiaCty", p_DataTable.Rows(0).Item("DonGia").ToString)
                        If p_DataTable22.Rows.Count > 0 Then

                            'Me.GridView1.set
                            p_Row.Item("TheBVMT") = p_DataTable22.Rows(0).Item("DonGia").ToString
                            Double.TryParse(p_DataTable22.Rows(0).Item("DonGia").ToString, p_ThueBVMT)
                            p_Row.Item("Z009_PER") = p_DataTable22.Rows(0).Item("KPEIN").ToString
                            'Me.GridView1.SetFocusedRowCellValue("TheBVMT", p_DataTable22.Rows(0).Item("DonGia").ToString)
                        End If

                        If p_DataTable33.Rows.Count > 0 Then
                            'Me.GridView1.set
                            p_Row.Item("PhiVT") = p_DataTable33.Rows(0).Item("KBETR").ToString
                            Double.TryParse(p_DataTable33.Rows(0).Item("KBETR").ToString, p_PhiVT)
                            p_Row.Item("Z003_PER") = p_DataTable33.Rows(0).Item("KPEIN").ToString

                            '  Me.GridView1.SetFocusedRowCellValue("PhiVT", p_DataTable33.Rows(0).Item("KBETR").ToString)
                        End If
                        p_GiaCty = p_GiaCty + p_ThueBVMT + p_PhiVT
                        p_Row.Item("DonGia") = p_GiaCty

                        ' Me.GridView1.SetFocusedRowCellValue("CurrencyKey", p_DataTable.Rows(0).Item("WAERS").ToString)
                    End If
                End If


            End If
        End If
    End Sub



    Private Sub TongDonGia()
        Dim p_Row As DataRow
        Dim p_GiaCongTy As Double
        Dim p_GiaVT As Double
        Dim p_ThueBVMT As Double
        Dim p_DonGia As Double
        Try
            p_Row = Me.GridView1.GetFocusedDataRow
            Double.TryParse(p_Row.Item("GiaCty").ToString.Trim, p_GiaCongTy)
            Double.TryParse(p_Row.Item("PhiVT").ToString.Trim, p_GiaVT)
            Double.TryParse(p_Row.Item("TheBVMT").ToString.Trim, p_ThueBVMT)
            p_DonGia = p_GiaCongTy + p_GiaVT + p_ThueBVMT
            Me.GridView1.SetFocusedRowCellValue("DonGia", p_DonGia)

        Catch ex As Exception

        End Try


    End Sub

    Function GetTongDonGia() As Double
        Dim p_Row As DataRow
        Dim p_GiaCongTy As Double
        Dim p_GiaVT As Double
        Dim p_ThueBVMT As Double
        Dim p_DonGia As Double
        Try
            p_Row = Me.GridView1.GetFocusedDataRow
            Double.TryParse(p_Row.Item("GiaCty").ToString.Trim, p_GiaCongTy)
            Double.TryParse(p_Row.Item("PhiVT").ToString.Trim, p_GiaVT)
            Double.TryParse(p_Row.Item("TheBVMT").ToString.Trim, p_ThueBVMT)
            GetTongDonGia = p_GiaCongTy + p_GiaVT + p_ThueBVMT
            '  Me.GridView1.SetFocusedRowCellValue("DonGia", p_DonGia)

        Catch ex As Exception
            GetTongDonGia = 0
        End Try

    End Function


    Private Sub PrcingDate_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrcingDate.EditValueChanged
        Dim p_Date As U_TextBox.U_DateEdit
        p_Date = CType(sender, U_TextBox.U_DateEdit)
        If p_Date.IsModified = True Then
            ResetPrice()
        End If
    End Sub




    Private Sub ResetPrice()
        Dim p_SQL As String = ""
        Dim p_DataSet As DataSet
        Dim p_DataTable, p_DataTable22, p_DataTable33 As DataTable
        Dim p_Row As DataRow
        Dim p_RowCheck() As DataRow
        Dim p_ThueBVMT, p_PhiVT, p_GiaCty As Decimal
        Dim p_Count As Integer
        Dim p_PTBan, p_MaKH, p_MaHH, p_DVT, p_Term, p_NgayXuat, p_LoaiTien, p_MaTuyenDuong, p_LHVT, p_Group, p_SoHopDong As String
        'Dim p_Object() As 
        If Not PriceGroup.EditValue Is Nothing Then
            p_Group = PriceGroup.EditValue.ToString.Trim
        End If
        Dim p1_Company_Code As String = ""
        Dim p_PricingDate As String = ""
        Dim p_KHoXuat As String = ""
        'If Not Me.MaKhoXuat.EditValue Is Nothing Then
        '    p_KHoXuat = Me.MaKhoXuat.EditValue.ToString.Trim
        'End If
        'p_SQL = "select top 1 MaDonVi from tblKho h where h.MaKHo ='" & p_KHoXuat & "'"
        'p_DataTable = GetDataTable(p_SQL, p_SQL)
        'If Not p_DataTable Is Nothing Then
        '    If p_DataTable.Rows.Count > 0 Then
        p1_Company_Code = g_Company_Code
        '    End If
        'End If

        'If p_KHoXuat = "" Then
        '    ShowMessageBox("", "Kho xuất chưa nhập")
        '    Exit Sub
        'End If
        'If p_Group = "" Then
        '    ShowMessageBox("", "Price Group không được trống")

        '    Exit Sub
        'End If


        p_PTBan = ""
        p_MaKH = ""
        p_MaHH = ""
        p_DVT = ""
        p_Term = ""
        p_NgayXuat = ""
        p_LoaiTien = ""
        p_MaTuyenDuong = ""
        p_LHVT = ""
        p_Group = ""
        p_SoHopDong = ""

        LayThongtinTyGia()

        If Not PrcingDate.EditValue Is Nothing Then
            p_NgayXuat = CDate(PrcingDate.EditValue).ToString("yyyyMMdd")
        End If

        p_SoHopDong = ""

        If Not SoHopDong.EditValue Is Nothing Then
            p_SoHopDong = SoHopDong.EditValue.ToString.Trim
        End If


        If Not MaKhachHang.EditValue Is Nothing Then
            p_MaKH = MaKhachHang.EditValue.ToString.Trim()
        End If
        If Not Term.EditValue Is Nothing Then
            p_Term = Term.EditValue.ToString.Trim()
        End If
        'If Not PriceGroup.EditValue Is Nothing Then
        '    p_PriceGroup = PriceGroup.EditValue.ToString.Trim()
        'End If

        'If Not PrcingDate.EditValue Is Nothing Then
        '    p_NgayXuat = PrcingDate.EditValue.ToString.Trim()
        'End If


        'If Not MaPhuongThucBan.EditValue Is Nothing Then
        '    p_PTBan = MaPhuongThucBan.EditValue.ToString.Trim()
        'End If



        '               FPT_LayGiaCongTy()
        '@p_SaleOrg nvarchar(50), --	Công ty-Client
        '@p_DistributionChanel nvarchar(50), --	Phương thức bán
        '@p_Customer nvarchar(50)    ,   --- Khach hang	
        '@p_Material nvarchar(50),   --	Mã mặt hàng
        '@p_SaleUnit nvarchar(50),  --	Đơn vị tính dự xuất	
        '@p_PaymentTerm nvarchar(50),  --	Phương thức thanh toán	
        '@p_NgayXuat datetime  --Ngay xuat tren lệnh

        p_LoaiTien = ""
        Select Case p_PhuongThucBan
            Case "05", "06"
                '  GridView1.SetFocusedRowCellValue("CurrencyKey", "USD")
                p_LoaiTien = "USD"
            Case "07", "08", "09", "10"
                ' GridView1.SetFocusedRowCellValue("CurrencyKey", "VND")
                p_LoaiTien = "VND"
            Case Else

                p_LoaiTien = "VND"
        End Select


        'If Not MaVanChuyen.EditValue Is Nothing Then
        '    p_LHVT = MaVanChuyen.EditValue.ToString.Trim
        'End If

        If Not U_ButtonEdit3.EditValue Is Nothing Then
            p_MaTuyenDuong = U_ButtonEdit3.EditValue.ToString.Trim
        End If



        For p_Count = 0 To GridView1.RowCount - 1
            'GridView1.SetFocusedRowCellValue("CurrencyKey", p_LoaiTien)
            p_Row = GridView1.GetDataRow(p_Count)
            If p_Row Is Nothing Then
                Continue For
            End If
            p_MaHH = p_Row.Item("MaHangHoa").ToString.Trim
            If p_MaHH = "" Then
                Continue For
            End If

            p_DVT = p_Row.Item("DonViTinh")
            'If p_SoHopDong <> "" Then
            '    p_RowCheck = p_tblProject_Details.Select("Vbeln='" & p_SoHopDong & "' and  Matnr='" & p_MaHH & "'")
            '    If p_RowCheck.Length > 0 Then
            '        If p_DVT.ToString.Trim <> "" Then
            '            p_DVT = p_RowCheck(0).Item("Meins").ToString.Trim
            '            p_Row.Item("DonViTinh") = p_DVT

            '        Else
            '            p_DVT = p_RowCheck(0).Item("Meins").ToString.Trim
            '            p_Row.Item("DonViTinh") = p_DVT
            '        End If
            '    Else
            '        ShowMessageBox("", "Mã hàng không khớp trong hợp đồng")
            '        Exit Sub
            '    End If
            'End If

            Dim p_PriceGroup As String = ""
            'Dim p_Inco1 As String = ""
            Dim p_DonViCCVT As String = ""
            If Not Me.PriceGroup.EditValue Is Nothing Then
                p_PriceGroup = Me.PriceGroup.EditValue.ToString.Trim()
            End If

            p_DonViCCVT = ""
            If Not Me.MaNhaCungCap.EditValue Is Nothing Then
                p_DonViCCVT = Me.MaNhaCungCap.EditValue.ToString.Trim()
            End If

            If Not Me.PrcingDate.EditValue Is Nothing Then
                p_PricingDate = CDate(Me.PrcingDate.EditValue).ToString("yyyyMMdd")
            End If

            p_SQL = "exec FPT_LayGiaCongTy_TaiXuat '" & p1_Company_Code & "' " & _
                          ",'" & p_PhuongThucBan & "' " & _
                          ",'" & p_MaKH & "' " & _
                          ",'" & p_MaHH & "' " & _
                          ",'" & p_DVT & "' " & _
                          ",'" & p_Term & "' " & _
                          ",'" & p_NgayXuat.ToString & "' " & _
                          ",'" & p_LoaiTien & "' " & _
                            ",'" & p_MaTuyenDuong & "' " & _
                              ",'" & p_MaVanChuyen & "' " & _
                              ",'" & p_PriceGroup & "','" & p_Inco1 & "' " & _
                              ",'" & p_DonViCCVT & "' " & _
                          ", " & IIf(p_PricingDate = "", "NULL", "'" & p_PricingDate & "'")
            p_DataSet = g_Services.Sys_SYS_GET_DATASet_Des(p_SQL, p_SQL)
            If p_DataSet Is Nothing Then
                Exit Sub
            End If
            If p_DataSet.Tables.Count <= 0 Then
                Exit Sub
            End If
            p_DataTable = p_DataSet.Tables(0)
            If p_DataTable.Rows.Count <= 0 Then
                p_DataTable = p_DataSet.Tables(1)
            End If

            p_Row.Item("GiaCty") = 0 ' p_DataTable.Rows(0).Item("DonGia").ToString
            p_Row.Item("Z001_PER") = 1
            p_Row.Item("TheBVMT") = 0
            p_Row.Item("Z009_PER") = 1
            p_Row.Item("PhiVT") = 0
            p_Row.Item("Z003_PER") = 1
            p_Row.Item("DonGia") = 0

            p_DataTable22 = p_DataSet.Tables(2)
            p_DataTable33 = p_DataSet.Tables(3)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then



                    '  p_MaHH = p_Row.Item("MaHangHoa").ToString.Trim()
                    ' p_DVT = p_Row.Item("DonViTinh").ToString.Trim()


                    p_Row.Item("CurrencyKey") = p_LoaiTien
                    p_ThueBVMT = 0
                    p_PhiVT = 0
                    p_GiaCty = 0
                    Double.TryParse(p_DataTable.Rows(0).Item("DonGia").ToString, p_GiaCty)



                    ' GridView1.SetFocusedRowCellValue("CurrencyKey", )

                    p_Row.Item("GiaCty") = p_GiaCty ' p_DataTable.Rows(0).Item("DonGia").ToString
                    p_Row.Item("Z001_PER") = p_DataTable.Rows(0).Item("KPEIN").ToString

                    'GridView1.SetFocusedRowCellValue("GiaCty", p_DataTable.Rows(0).Item("DonGia").ToString)
                    If p_DataTable22.Rows.Count > 0 Then

                        'GridView1.set
                        p_Row.Item("TheBVMT") = p_DataTable22.Rows(0).Item("DonGia").ToString
                        Double.TryParse(p_DataTable22.Rows(0).Item("DonGia").ToString, p_ThueBVMT)
                        p_Row.Item("Z009_PER") = p_DataTable22.Rows(0).Item("KPEIN").ToString
                        'GridView1.SetFocusedRowCellValue("TheBVMT", p_DataTable22.Rows(0).Item("DonGia").ToString)
                    End If

                    If p_DataTable33.Rows.Count > 0 Then
                        'GridView1.set
                        p_Row.Item("PhiVT") = p_DataTable33.Rows(0).Item("KBETR").ToString
                        Double.TryParse(p_DataTable33.Rows(0).Item("KBETR").ToString, p_PhiVT)
                        p_Row.Item("Z003_PER") = p_DataTable33.Rows(0).Item("KPEIN").ToString

                    End If
                    If p_Group = "06" Then
                        p_GiaCty = p_GiaCty + p_PhiVT
                    Else
                        p_GiaCty = p_GiaCty + p_ThueBVMT + p_PhiVT
                    End If

                    p_Row.Item("DonGia") = p_GiaCty

                End If
            End If

            'If Not p_DataSet.Tables(4) Is Nothing Then
            '    If p_DataSet.Tables(4).Rows.Count > 0 Then
            '        Me.TyGia.EditValue = p_DataSet.Tables(4).Rows(0).Item("UKURS_CURR")
            '    End If
            'End If

        Next
    End Sub


    Private Sub LayThongtinTyGia()
        Dim p_PTBan As String = ""
        Dim p_LoaiTien As String = ""
        Dim p_SQL As String = ""
        Dim p_Table As DataTable
        Dim p_PricingDate As String = ""
       
        If Not Me.PrcingDate.EditValue Is Nothing Then
            p_PricingDate = CDate(Me.PrcingDate.EditValue).ToString("yyyyMMdd")
        End If

        p_LoaiTien = ""
        Select Case p_PhuongThucBan
            Case "05", "06"
                '  GridView1.SetFocusedRowCellValue("CurrencyKey", "USD")
                p_LoaiTien = "USD"
            Case "07", "08", "09", "10"
                ' GridView1.SetFocusedRowCellValue("CurrencyKey", "VND")
                p_LoaiTien = "VND"
            Case Else

                p_LoaiTien = "VND"
        End Select
        p_SQL = "select dbo.ThongTinTyGia (" & IIf(p_PricingDate = "", "NULL", "'" & p_PricingDate & "'") & ", '" & p_LoaiTien & "') as UKURS_CURR"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                Me.TyGia.EditValue = p_Table.Rows(0).Item("UKURS_CURR")
            End If
        End If

    End Sub


    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim p_DO1 As String = ""
        Dim p_DO2 As String = ""
        Dim p_SQL As String = ""
        Dim p_DataTable As DataTable
        Dim p_ValueMess As Windows.Forms.DialogResult
        If Not Me.SoDO1.EditValue Is Nothing Then
            p_DO1 = Me.SoDO1.EditValue.ToString.Trim
        End If
        If Not Me.SoLenh.EditValue Is Nothing Then
            p_DO2 = Me.SoLenh.EditValue.ToString.Trim
        End If
        If p_DO1 <> "" And p_DO2 <> "" Then


            p_SQL = "select 1 from tblDO_Header k with (nolock) where SoLenh ='" & p_DO2 & "' " &
                    " and exists (select 1 from tblLenhXuate5 k1 where k.SoLenh =k1.SoLenh  and isnull(K1.Status,'') ='2')"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then

                    p_ValueMess = g_Module.ShowMessage(Me, "", _
                                  "Bạn có chắc chắn muốn hủy không? ", _
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

                    p_SQL = "delete from [tblDO_Header]   where  SoLenh  ='" & p_DO2 & "';" & _
                            "delete from [tblDO_Item_Material]   where  SoLenh  ='" & p_DO2 & "';" & _
                            "update tblLenhXuate5  set DO1_SoLenh=null, PriceGroupDO1 =null  where  SoLenh  ='" & p_DO2 & "';"
                    If g_Services.Sys_Execute(p_SQL, _
                                         p_SQL) = False Then
                        'ShowMessageBox("", p_SQLErr)
                    Else
                        Me.Close()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub MaKhoXuat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaKhoXuat.EditValueChanged
        Dim p_MaKhoXuat As U_TextBox.U_ButtonEdit
        p_MaKhoXuat = CType(sender, U_TextBox.U_ButtonEdit)
        If p_MaKhoXuat.IsModified = True Then
            ResetPrice()
        End If
    End Sub

    Private Sub PriceGroup_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PriceGroup.EditValueChanged

        Dim p_MaKhoXuat As U_TextBox.U_ButtonEdit
        p_MaKhoXuat = CType(sender, U_TextBox.U_ButtonEdit)
        If p_MaKhoXuat.IsModified = True Then
            ResetPrice()
        End If

    End Sub

    Private Sub MaNhaCungCap_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaNhaCungCap.EditValueChanged
        Dim p_MaKhoXuat As U_TextBox.U_ButtonEdit
        p_MaKhoXuat = CType(sender, U_TextBox.U_ButtonEdit)
        If p_MaKhoXuat.IsModified = True Then
            ResetPrice()
        End If
    End Sub

    Private Sub MaKhachHang_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaKhachHang.EditValueChanged

    End Sub

    Private Sub Term_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Term.EditValueChanged
        Dim p_MaKhoXuat As U_TextBox.U_ButtonEdit
        p_MaKhoXuat = CType(sender, U_TextBox.U_ButtonEdit)
        If p_MaKhoXuat.IsModified = True Then
            ResetPrice()
        End If
    End Sub

    Private Sub PrcingDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles PrcingDate.Validating
        Dim p_Date As U_TextBox.U_DateEdit
        p_Date = CType(sender, U_TextBox.U_DateEdit)
        If p_Date.IsModified = True Then
            ResetPrice()
        End If
    End Sub

    Private Sub SoHopDong_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoHopDong.EditValueChanged

    End Sub

    Private Sub SoHopDong_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SoHopDong.Validating
        Dim p_MaKhoXuat As U_TextBox.U_ButtonEdit
        Dim p_SQL As String = ""
        Dim p_Table As DataTable
        Dim p_Value As String = ""
        Dim p_Exit As Boolean = False
        'select  Vbeln as SoHopDong, Kunnr as MaKhachHang, Inco1 from dbo.tblProjects with (nolock) where convert(date,getdate()) >= convert(date,Guebg) 
        'and convert(date,getdate()) <= convert(date,Gueen) and Kunnr = :MaKhachHang and Vtweg = :MaPhuongThucBan

        p_MaKhoXuat = CType(sender, U_TextBox.U_ButtonEdit)
        If p_MaKhoXuat.IsModified = True Then

            p_SQL = p_MaKhoXuat.SqlString
            '"select   Vbeln as SoHopDong,  ZLSCH as PaymentMethod,ZTERM as Term, INCO2 as Inco2, Inco1 from dbo.tblProjects with (nolock) where  Vkorg  in ('" & g_KhoNhap & "')  and " & _
            '               "convert(date,getdate()) >= convert(date, case when isdate(Guebg) =1 then convert(date,Guebg)  else getdate() end ) " & _
            '          "and convert(date,getdate()) <= convert(date, case when isdate(Gueen) =1 then convert(date,Gueen)  else getdate() end) " & _
            '           "and Kunnr = :MaKhachHang and Vtweg = :MaPhuongThucBan" '" & p_PhuongThucBan & "'"
            '  Me.SoHopDong.SqlString = p_SQL
            p_Value = p_MaKhoXuat.EditValue
            p_SQL = Me.Parameter_Item(Me, p_SQL)
            p_SQL = p_SQL & " and Vbeln='" & p_Value & "'"

            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    p_Value = p_Table.Rows(0).Item("PaymentMethod").ToString.Trim
                    Me.PaymentMethod.EditValue = p_Value
                    p_Value = p_Table.Rows(0).Item("Term").ToString.Trim
                    Me.Term.EditValue = p_Value


                    Me.PriceGroup.EditValue = p_Table.Rows(0).Item("PriceGroup").ToString.Trim


                    p_Exit = True
                End If
            End If
            If p_Exit = False Then
                Me.Term.EditValue = ""
            End If
            ResetPrice()
        End If
    End Sub
End Class