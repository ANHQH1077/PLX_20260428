Imports System.Data.OleDb
Imports System.IO
Module THN_SAP_HTTG
    Private p_FunctionTableId As String
    Private p_MATUDONGHOA_PROD As String = ""

    Public p_KiemTraHanMuc As Boolean = True
    Public p_KIEMTRA_TD As Boolean = True
    Public p_ThongTinNhomBe As Boolean = False

    Public p_CONGTO_BEXUAT As Boolean = False
    Private p_ThamSoNgay As Boolean = False
    Private l_ztb As Connect2SapEx.Str_PhieuXuatTable
    Public p_LaiNgayDem As Boolean = False
    Private g_NhomBeXuat As String = ""

    Public g_Terminal As String = ""

    Public Function mdlQCI_CalculateQCI_ATG(
                                         ByVal i_plant As String, _
                                         ByVal i_batch As String, _
                                         ByRef i_dgv_QCI As System.Data.DataTable,
                                         ByRef p_Desc As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_str As Connect2SAP.Str_PhieuXuat
        Dim l_ztb_addqty As Connect2SAP.Str_AddqtyTable
        Dim l_ret2 As Connect2SAP.BAPIRET2Table
        Dim p_SQL As String
        Dim p_DataRow As System.Data.DataRow
        Dim i_connectionstring As String = ""
        Dim p_TableConfig1 As DataTable


        p_SQL = "select * from tblConfig;"
        p_TableConfig1 = GetDataTable(p_SQL, p_SQL)



        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                i_connectionstring = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                ' p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                'p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If

        l_c2sap = New Connect2SAP.Connect2SAP(i_connectionstring)
        l_str = New Connect2SAP.Str_PhieuXuat




        If i_connectionstring = "" Then
            p_Desc = "Lỗi kết nối SAP"
            Return False
            'mdlSyncDeliveries_SynSpecific = True
            'MsgBox("Loi ket noi")
            'Exit Function
        End If

        '  mdlQCI_CalculateQCI = True

        l_str.Plant = i_plant
        l_str.Batch_Nd = i_batch
        l_str.Resource_Nd = i_batch

        For i As Integer = 0 To i_dgv_QCI.Rows.Count - 1
            Try
                p_DataRow = i_dgv_QCI.Rows(i)

                l_str.Material = p_DataRow.Item("ProductCode").ToString.Trim
                For j As Integer = 1 To 18 - p_DataRow.Item("ProductCode").ToString().Trim.Length
                    l_str.Material = "0" & l_str.Material
                Next
                If p_DataRow.Item("Dens").ToString.Trim = "" Then
                    Continue For
                End If
                l_str.Quantity = p_DataRow.Item("TankHeight").ToString.Trim
                l_str.Unit = "L"  ' p_DataRow.Item("DVT").ToString()
                l_str.Temp_Confirm = p_DataRow.Item("TankTemp").ToString()
                l_str.Dens_Confirm = p_DataRow.Item("Dens").ToString()

                l_ret2 = New Connect2SAP.BAPIRET2Table()
                l_ztb_addqty = New Connect2SAP.Str_AddqtyTable()

                l_c2sap.Fm_Qci(l_str, l_ztb_addqty, l_ret2)
                'If l_ret2.Count <> 0 Then
                '    i_dgv_QCI.Rows(i).DefaultCellStyle.BackColor = Color.Red
                '    Continue For
                'End If
                'Dim l_ref22 As Connect2SAP.BAPIRET2
                'Dim l_str22 As Connect2SAP.Str_VCFTable
                'l_ref22 = New Connect2SAP.BAPIRET2

                'l_c2sap.  .GetVCF(l_str22, l_ref22)


                For j As Integer = 0 To l_ztb_addqty.Count - 1

                    Select Case l_ztb_addqty.Item(j).Msehi.Trim()
                        Case "L"
                            ' i_dgv_QCI.Rows(i).Item("Ltt") = Convert.ToInt32(l_ztb_addqty.Item(j).Adqnt)

                        Case "L15"
                            i_dgv_QCI.Rows(i).Item("VolumnL15") = Convert.ToInt32(l_ztb_addqty.Item(j).Adqnt)

                        Case "M15"
                            'i_dgv_QCI.Rows(i).Item("M15") = Convert.ToInt32(l_ztb_addqty.Item(j).Adqnt)

                        Case "KG"
                            i_dgv_QCI.Rows(i).Item("VolumnKG") = Convert.ToInt32(l_ztb_addqty.Item(j).Adqnt)

                        Case Else

                    End Select

                Next

                ' i_dgv_QCI.Rows(i).DefaultCellStyle.BackColor = Color.White

            Catch ex As Exception
                p_Desc = ex.Message
                Return False
            End Try
        Next

        Return True
    End Function


    Public Function mdlQCI_CalculateQCIThuy(
                                         ByVal i_plant As String, _
                                         ByVal i_batch As String, _
                                         ByRef i_dgv_QCI As System.Data.DataTable,
                                         ByRef p_Desc As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_str As Connect2SAP.Str_PhieuXuat
        Dim l_ztb_addqty As Connect2SAP.Str_AddqtyTable
        Dim l_ret2 As Connect2SAP.BAPIRET2Table
        Dim p_SQL As String
        Dim p_DataRow As System.Data.DataRow
        Dim i_connectionstring As String = ""
        Dim p_TableConfig1 As DataTable


        p_SQL = "select * from tblConfig;"
        p_TableConfig1 = GetDataTable(p_SQL, p_SQL)



        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                i_connectionstring = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                ' p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                'p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If

        l_c2sap = New Connect2SAP.Connect2SAP(i_connectionstring)
        l_str = New Connect2SAP.Str_PhieuXuat




        If i_connectionstring = "" Then
            p_Desc = "Lỗi kết nối SAP"
            Return False
            'mdlSyncDeliveries_SynSpecific = True
            'MsgBox("Loi ket noi")
            'Exit Function
        End If

        '  mdlQCI_CalculateQCI = True

        l_str.Plant = i_plant
        l_str.Batch_Nd = i_batch
        l_str.Resource_Nd = i_batch

        For i As Integer = 0 To i_dgv_QCI.Rows.Count - 1
            Try
                p_DataRow = i_dgv_QCI.Rows(i)

                l_str.Material = p_DataRow.Item("MaHangHoa").ToString.Trim
                For j As Integer = 1 To 18 - p_DataRow.Item("MaHangHoa").ToString().Trim.Length
                    l_str.Material = "0" & l_str.Material
                Next
                l_str.Quantity = p_DataRow.Item("SoLuong").ToString.Trim
                l_str.Unit = "L"  ' p_DataRow.Item("DVT").ToString()
                l_str.Temp_Confirm = p_DataRow.Item("Nhietdo").ToString()
                l_str.Dens_Confirm = p_DataRow.Item("TyTrong").ToString()

                l_ret2 = New Connect2SAP.BAPIRET2Table()
                l_ztb_addqty = New Connect2SAP.Str_AddqtyTable()




                l_c2sap.Fm_Qci(l_str, l_ztb_addqty, l_ret2)
                'If l_ret2.Count <> 0 Then
                '    i_dgv_QCI.Rows(i).DefaultCellStyle.BackColor = Color.Red
                '    Continue For
                'End If

                For j As Integer = 0 To l_ztb_addqty.Count - 1

                    Select Case l_ztb_addqty.Item(j).Msehi.Trim()
                        Case "L"
                            i_dgv_QCI.Rows(i).Item("Ltt") = Convert.ToInt32(l_ztb_addqty.Item(j).Adqnt)

                        Case "L15"
                            i_dgv_QCI.Rows(i).Item("L15") = Convert.ToInt32(l_ztb_addqty.Item(j).Adqnt)

                        Case "M15"
                            i_dgv_QCI.Rows(i).Item("M15") = Convert.ToInt32(l_ztb_addqty.Item(j).Adqnt)

                        Case "KG"
                            i_dgv_QCI.Rows(i).Item("KG") = Convert.ToInt32(l_ztb_addqty.Item(j).Adqnt)

                        Case Else

                    End Select

                Next

                ' i_dgv_QCI.Rows(i).DefaultCellStyle.BackColor = Color.White

            Catch ex As Exception
                p_Desc = ex.Message
                Return False
            End Try
        Next

        Return True
    End Function



    Public Function LenhXuatAuto(ByVal p_Date As Date, ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_User_Name As String, ByVal p_Company_Code As String, _
                                        ByRef p_DataTable As System.Data.DataTable, ByRef p_Desc As String) As Boolean
        Dim p_DataRow, p_Row As System.Data.DataRow
        Dim p_Count As Integer
        Dim p_TblExe As New System.Data.DataTable("Table01")
        Dim p_SQL As String = ""
        Dim p_Error As String
        Dim p_Desc_OK As String = "Lệnh đã có trên hệ thống"
        Dim p_DateCrd As DateTime
        Dim p_Date_ND As Boolean = False
        Dim p_DataTableTmp As DataTable
        Dim p_NgayHieuLuc As String

        Try
            LenhXuatAuto = True


            p_SQL = "select KeyValue from sys_config where upper(KeyCode ) =upper('NgayHieuLuc')"
            p_DataTableTmp = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTableTmp Is Nothing Then
                If p_DataTableTmp.Rows.Count > 0 Then
                    If p_DataTableTmp.Rows(0).Item(0).ToString.Trim = "Y" Then
                        p_Date_ND = True
                    End If
                End If
            End If
            'p_Error = "4"
            ' Return True
            p_TblExe.Columns.Add("SQL_STR")
            For p_Count = 0 To p_DataTable.Rows.Count - 1
                p_DataRow = p_DataTable.Rows(p_Count)
                'If p_DataRow.Item("X") = "Y" Then
                If Not p_DataRow Is Nothing Then
                    ' p_Error = "3"
                    If Check_SoLenh(p_Error, p_DataRow.Item("SoLenh").ToString.Trim) = True Then
                        p_SQL = ""
                        'p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ([SoLenh],[NgayThang],[TrangThai],[Createby],[CreateDate],[sDesc],[StatusCode])" & _
                        '            " VALUES('" & p_DataRow.Item("SoLenh").ToString.Trim & "'" & _
                        '                    ",'" & Format(p_Date, "MM/dd/yyyy") & "','Y','" & p_User_Name & "', getdate(),'" & p_Desc_OK & "','Y')"
                        'p_Row = p_TblExe.NewRow
                        'p_Row.Item(0) = p_SQL
                        'p_TblExe.Rows.Add(p_Row)

                        p_DataTable.Rows(p_Count).Item("sDesc") = p_Desc_OK
                        p_DataTable.Rows(p_Count).Item("sStatus") = "Y"
                    Else
                        If p_Date_ND = False Then  'không lấy ngày tháng mặc định của lệnh xuất theo ngày hiệu lưcj
                            '  p_Error = "1"
                            If mdlSyncDeliveries_SynSpecific(p_Client, p_User_ID, p_Company_Code, p_DataRow.Item("SoLenh").ToString.Trim, p_Error, p_Date) = False Then
                                p_SQL = ""
                                '  LenhXuatAuto = False
                                p_DataTable.Rows(p_Count).Item("sDesc") = p_Error
                            Else
                                p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ([SoLenh],[NgayThang],[TrangThai],[Createby],[CreateDate],[sDesc],[StatusCode])" & _
                                        " VALUES('" & p_DataRow.Item("SoLenh").ToString.Trim & "'" & _
                                                ",'" & Format(p_Date, "MM/dd/yyyy") & "','Y','" & p_User_Name & "', getdate(),N'" & p_Error & "','Y')"


                                p_Row = p_TblExe.NewRow
                                p_Row.Item(0) = p_SQL
                                p_TblExe.Rows.Add(p_Row)

                                p_DataTable.Rows(p_Count).Item("sDesc") = p_Error
                                p_DataTable.Rows(p_Count).Item("sStatus") = "Y"
                            End If
                        Else
                            'Ngay xuat lay theo Ngày hiệu lực của Lệnh xuất

                            ' p_Desc = p_DataRow.Item("NgayThang").ToString
                            '  Return True


                            If p_DataRow.Item("NgayThang").ToString.Trim <> "" Then
                                p_NgayHieuLuc = CDate(p_DataRow.Item("NgayThang")).ToString("yyyy/MM/dd")
                            Else
                                p_NgayHieuLuc = CDate(p_Date).ToString("yyyy/MM/dd")
                            End If

                            If mdlSyncDeliveries_NgayHieuLuc(p_Client, p_User_ID, p_Company_Code, p_DataRow.Item("SoLenh").ToString.Trim, p_Error, p_NgayHieuLuc) = False Then
                                p_SQL = ""
                                '  LenhXuatAuto = False
                                p_DataTable.Rows(p_Count).Item("sDesc") = p_Error
                            Else
                                p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ([SoLenh],[NgayThang],[TrangThai],[Createby],[CreateDate],[sDesc],[StatusCode])" & _
                                        " VALUES('" & p_DataRow.Item("SoLenh").ToString.Trim & "'" & _
                                                ",'" & p_NgayHieuLuc & "','Y','" & p_User_Name & "', getdate(),N'" & p_Error & "','Y')"


                                p_Row = p_TblExe.NewRow
                                p_Row.Item(0) = p_SQL
                                p_TblExe.Rows.Add(p_Row)

                                p_DataTable.Rows(p_Count).Item("sDesc") = p_Error
                                p_DataTable.Rows(p_Count).Item("sStatus") = "Y"
                            End If
                        End If

                    End If
                End If
                'End If
            Next

        Catch ex As Exception
            p_Desc = ex.Message
            LenhXuatAuto = False
        End Try

        If p_TblExe.Rows.Count > 0 Then
            If g_Services.Sys_Execute_DataTbl(p_TblExe, _
                                           p_Desc) = False Then

            End If
        End If

        LenhXuatAuto = True


    End Function



    Public Function LenhXuatAuto_HTTG(ByVal p_Date As Date, ByVal p_Client As String, ByVal p_User_ID As Integer, ByVal p_User_Name As String, ByVal p_Company_Code As String, _
                                        ByRef p_DataTable As System.Data.DataTable, ByRef p_Desc As String, Optional ByVal p_Future As Boolean = False) As Boolean
        Dim p_DataRow, p_Row As System.Data.DataRow
        Dim p_Count As Integer
        Dim p_TblExe As New System.Data.DataTable("Table01")
        Dim p_SQL As String = ""
        Dim p_Error As String
        Dim p_Desc_OK As String = "Lệnh đã có trên hệ thống"
        Dim p_DateCrd As DateTime
        Dim p_Date_ND As Boolean = False
        Dim p_DataTableTmp As DataTable
        Dim p_NgayHieuLuc As String

        Try
            LenhXuatAuto_HTTG = True


            p_SQL = "select KeyValue from sys_config where upper(KeyCode ) =upper('NgayHieuLuc')"
            p_DataTableTmp = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTableTmp Is Nothing Then
                If p_DataTableTmp.Rows.Count > 0 Then
                    If p_DataTableTmp.Rows(0).Item(0).ToString.Trim = "Y" Then
                        p_Date_ND = True
                    End If
                End If
            End If
            'p_Error = "4"
            ' Return True
            p_TblExe.Columns.Add("SQL_STR")
            For p_Count = 0 To p_DataTable.Rows.Count - 1
                p_DataRow = p_DataTable.Rows(p_Count)
                'If p_DataRow.Item("X") = "Y" Then
                If Not p_DataRow Is Nothing Then
                    ' p_Error = "3"
                    If Check_SoLenh(p_Error, p_DataRow.Item("SoLenh").ToString.Trim) = True Then
                        p_SQL = ""
                        'p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ([SoLenh],[NgayThang],[TrangThai],[Createby],[CreateDate],[sDesc],[StatusCode])" & _
                        '            " VALUES('" & p_DataRow.Item("SoLenh").ToString.Trim & "'" & _
                        '                    ",'" & Format(p_Date, "MM/dd/yyyy") & "','Y','" & p_User_Name & "', getdate(),'" & p_Desc_OK & "','Y')"
                        'p_Row = p_TblExe.NewRow
                        'p_Row.Item(0) = p_SQL
                        'p_TblExe.Rows.Add(p_Row)

                        p_DataTable.Rows(p_Count).Item("sDesc") = p_Desc_OK
                        p_DataTable.Rows(p_Count).Item("sStatus") = "Y"
                    Else
                        ' If p_Date_ND = False Then  'không lấy ngày tháng mặc định của lệnh xuất theo ngày hiệu lưcj
                        '  p_Error = "1"
                        If mdlSyncDeliveries_SynSpecific_Auto(p_Client, p_User_ID, p_Company_Code, p_DataRow.Item("SoLenh").ToString.Trim, p_Error, p_Date, p_Future) = False Then
                            p_SQL = ""
                            '  LenhXuatAuto = False
                            p_DataTable.Rows(p_Count).Item("sDesc") = p_Error
                        Else
                            p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ([SoLenh],[NgayThang],[TrangThai],[Createby],[CreateDate],[sDesc],[StatusCode])" & _
                                    " VALUES('" & p_DataRow.Item("SoLenh").ToString.Trim & "'" & _
                                            ",'" & Format(p_Date, "MM/dd/yyyy") & "','Y','" & p_User_Name & "', getdate(),N'" & p_Error & "','Y')"


                            p_Row = p_TblExe.NewRow
                            p_Row.Item(0) = p_SQL
                            p_TblExe.Rows.Add(p_Row)

                            p_DataTable.Rows(p_Count).Item("sDesc") = p_Error
                            p_DataTable.Rows(p_Count).Item("sStatus") = "Y"
                        End If
                        ' Else


                        'If mdlSyncDeliveries_NgayHieuLuc(p_Client, p_User_ID, p_Company_Code, p_DataRow.Item("SoLenh").ToString.Trim, p_Error, p_NgayHieuLuc) = False Then
                        '    p_SQL = ""
                        '    '  LenhXuatAuto = False
                        '    p_DataTable.Rows(p_Count).Item("sDesc") = p_Error
                        'Else
                        '    p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ([SoLenh],[NgayThang],[TrangThai],[Createby],[CreateDate],[sDesc],[StatusCode])" & _
                        '            " VALUES('" & p_DataRow.Item("SoLenh").ToString.Trim & "'" & _
                        '                    ",'" & p_NgayHieuLuc & "','Y','" & p_User_Name & "', getdate(),N'" & p_Error & "','Y')"


                        '    p_Row = p_TblExe.NewRow
                        '    p_Row.Item(0) = p_SQL
                        '    p_TblExe.Rows.Add(p_Row)

                        '    p_DataTable.Rows(p_Count).Item("sDesc") = p_Error
                        '    p_DataTable.Rows(p_Count).Item("sStatus") = "Y"
                        'End If
                    End If

                End If
                '  End If
                'End If
            Next

        Catch ex As Exception
            p_Desc = ex.Message
            LenhXuatAuto_HTTG = False
        End Try

        If p_TblExe.Rows.Count > 0 Then
            If g_Services.Sys_Execute_DataTbl(p_TblExe, _
                                           p_Desc) = False Then

            End If
        End If

        LenhXuatAuto_HTTG = True


    End Function


    'Private 


    Public Function mdlSyncDeliveries_SynSpecific(ByVal p_Client As String, ByVal p_User_ID As Integer, _
                                                    ByVal p_Company_Code As String, ByVal i_solenh As String, _
                                                    ByRef o_err As String, ByVal p_Date As Date, Optional ByVal p_Future As Boolean = False) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP

        ' Dim l_c2sap111 As Connect2SAP.


        'Dim l_c2sapex As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SAP.Str_PhieuXuatTable
        ' Dim l_ztb As Connect2SapEx.LIPSO2Table
        Dim l_ret2 As Connect2SAP.BAPIRET2
        ' Dim l_ret2ex As Connect2SapEx.BAPIRET2
        Dim l_err As String
        Dim l_f As Boolean = False

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String
        Dim p_TableConfig As DataTable
        Dim p_TableConfig1 As DataTable
        Dim p_SapConnectionString As String = ""
        Dim p_TimeOut = New TimeSpan()
        Dim p_WareHouse As String = ""
        Dim p_ShPoint As String = ""
        Dim p_DataRowArr() As DataRow
        ' Dim p_Table As DataTable
        Dim p_DataSet As New DataSet
        Dim p_Batch As String
        Dim p_Slog As String
        Dim p_MaKhachHang As String
        Dim p_StringTmp As String = "0000000000"
        Dim p_SoLenh As String
        Dim p_Table As DataTable
        Dim p_DiemTraHang As String
        Dim p_XepTai_Thuy As Boolean

        Dim p_Count As Integer

        g_Company_Code = p_Company_Code

        mdlSyncDeliveries_SynSpecific = False
        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG; select * from tblConfig;"
        p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

        g_KV1 = False

        g_User_ID = p_User_ID


        g_BATCHSLOG = False

        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_TableConfig = p_DataSet.Tables(0)
                p_TableConfig1 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_DataRowArr = p_TableConfig.Select("KEYCODE='TABLEID'")
                If p_DataRowArr.Length > 0 Then
                    p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='QUYDOI_SAP'")
                If p_DataRowArr.Length > 0 Then
                    p_QUYDOI_SAP = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KV1'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_KV1 = True
                    Else
                        g_KV1 = False
                    End If
                End If

                '20241121
                p_DataRowArr = p_TableConfig.Select("KEYCODE='TANK_GROUP'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_ThongTinNhomBe = True
                    Else
                        p_ThongTinNhomBe = False
                    End If
                End If


                p_ThamSoNgay = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='THAMSONGAY'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_ThamSoNgay = True
                    Else
                        p_ThamSoNgay = False
                    End If
                End If



                p_DataRowArr = p_TableConfig.Select("KEYCODE='BATCHSLOG'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_BATCHSLOG = True
                    Else
                        g_BATCHSLOG = False
                    End If
                End If

                'MATUDONGHOA_PROD
                'anhqh
                '20161115
                p_DataRowArr = p_TableConfig.Select("KEYCODE='MATUDONGHOA_PROD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        p_MATUDONGHOA_PROD = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                    End If
                End If


                'anhqh
                '20170414
                'Tham so kiem tra han muc
                p_KiemTraHanMuc = True

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KIEMTRAHANMUC'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_KiemTraHanMuc = False
                    End If
                End If

                'anhqh
                '20170419
                'Tham so kiem tra TD co duoc gan tren SAP khoong
                p_KIEMTRA_TD = True
                p_DataRowArr = p_TableConfig.Select("KEYCODE='KIEMTRA_TD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_KIEMTRA_TD = False
                    End If
                End If


                'CONGTO_BEXUAT
                p_CONGTO_BEXUAT = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='CONGTO_BEXUAT'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_CONGTO_BEXUAT = True
                    End If
                End If


                p_KiemTraDiChuyen_TD = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='KT_DICHUYEN_TD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_KiemTraDiChuyen_TD = True
                    End If
                End If

                p_XepTai_Thuy = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='SMO_XEPTAI_THUY'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_XepTai_Thuy = True
                    End If
                End If
            End If
        End If


        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                p_SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If
        If p_SapConnectionString = "" Then
            mdlSyncDeliveries_SynSpecific = True
            MsgBox("Loi ket noi")
            Exit Function
        End If


        Try
            l_c2sap = New Connect2SAP.Connect2SAP(p_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_PhieuXuatTable()
            ' l_ztb As Connect2SapEx.LIPSO2Table
            l_err = String.Empty



            If p_TableConfig1.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
                l_c2sap.GetPhieuXuat_Specific(i_solenh, l_ztb, l_ret2)

            Else
                l_async = l_c2sap.BeginGetPhieuXuat_Specific(i_solenh, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetPhieuXuat_Specific(l_async, l_ztb, l_ret2)
                End If
            End If


            If l_ztb.Count > 0 Then
                If p_KiemTraDiChuyen_TD = True Then
                    'anhqh
                    '20200813
                    'Kiem tra lenh di chuyen khong TD
                    p_SQL = "exec FPT_KiemTraDiChuyenKhongGanTD '" & l_ztb(0).Batch_Nd.ToString.Trim & "','" & l_ztb(0).Shnumber.ToString.Trim & "','" & l_ztb(0).Saleorder.ToString.Trim & "'"
                    p_Table = GetDataTable(p_SQL, p_SQL)
                    If Not p_Table Is Nothing Then
                        If p_Table.Rows.Count > 0 Then
                            If p_Table.Rows(0).Item(0).ToString.Trim = "1" Then
                                o_err = "Lệnh xuất chưa được gán TD!"
                                Return False
                            End If
                        End If
                    End If
                End If

                If p_ThamSoNgay = True Then
                    ' Dim p_table As DataTable
                    'l_ztb(0).Date_Nd .ToString.Trim 
                    For p_Count = 0 To l_ztb.Count - 1
                        If l_ztb(p_Count).Date_Nd <> p_Date.ToString("yyyyMMdd") Then
                            l_ztb(p_Count).Date_Nd = p_Date.ToString("yyyyMMdd")
                        End If

                    Next
                    p_SQL = "select convert(date,getdate()+1)  as dSysDate, convert(date,'" & l_ztb(0).Date_Nd.ToString.Trim & "') as dDate "
                    p_Table = GetDataTable(p_SQL, p_SQL)
                    If Not p_Table Is Nothing Then
                        If CDate(p_Table.Rows(0).Item(1)) > CDate(p_Table.Rows(0).Item(0)) Then
                            o_err = "Ngày tháng lệnh xuất không hợp lệ!"
                            Return False
                        End If
                    End If
                Else
                    If p_Future = False Then  ' 20210517 Bo sung them cho phep lay lenhngay hieu luc >sysdte
                        If Not mdlSyncDeliveries_CheckStartTime(l_ztb.Item(0).Date_Nd) Then
                            o_err = "Lệnh xuất chưa được phép xuất hàng!"
                            Return False
                        End If
                    End If
                    'If Not mdlSyncDeliveries_CheckStartTime(l_ztb.Item(0).Date_Nd) Then
                    '    o_err = "Lệnh xuất chưa được phép xuất hàng!"
                    '    Return False
                    'End If
                End If

                '------------------------------------------------------------------------------
                '   Kiểm tra thời hạn hiệu lực của hóa đơn
                '------------------------------------------------------------------------------
                'FES44
                '20141113


                If Not mdlSyncDeliveries_CheckEndTime(l_ztb.Item(0).Date_E_Nd) Then
                    o_err = "Lệnh xuất đã hết hạn!"
                    Return False
                End If

                If p_XepTai_Thuy = True And (l_ztb(0).Transmot.ToString.Trim() = "ZB" Or l_ztb(0).Transmot.ToString.Trim() = "ZM") Then
                    p_SQL = "exec FPT_KiemTraXepTaiXuatThuy '" & i_solenh & "'"
                    p_Table = GetDataTable(p_SQL, p_SQL)

                    If Not p_Table Is Nothing Then
                        If p_Table.Rows.Count > 0 Then
                            o_err = p_Table.Rows(0).Item("ErrMess")
                            Return False
                        End If
                    End If
                End If

                If l_ztb.Item(0).Plant <> p_WareHouse Then
                    o_err = "Kiểm tra thông tin Kho xuất hàng ghi trên lệnh xuất!"
                    Return False
                End If
                p_DiemTraHang = GetDiemTraHang(l_ztb(0).Shnumber.ToString.Trim, p_SapConnectionString,
                                       p_TableConfig1, p_TimeOut)


                If g_BATCHSLOG = True Then

                    For p_Count = 0 To l_ztb.Count - 1
                        'If l_ztb.Item(0).Resource_Nd = "N40" Or l_ztb.Item(0).Resource_Nd = "N45" Then
                        p_Batch = l_ztb.Item(p_Count).Batch_Nd
                        p_Slog = l_ztb.Item(p_Count).Storage
                        p_SoLenh = l_ztb.Item(p_Count).Order_No

                        p_MaKhachHang = Mid(p_Batch, 4)
                        p_MaKhachHang = Left(p_StringTmp, 10 - (Len(p_MaKhachHang))) & p_MaKhachHang

                        p_SQL = "exec FPT_CheckBatch '" & l_ztb.Item(p_Count).Order_No.ToString & "','" & l_ztb.Item(p_Count).Resource_Nd.ToString & _
                            "','" & p_Slog & "','" & l_ztb.Item(p_Count).Customer.ToString & "','" & p_MaKhachHang & "'"
                        p_Table = GetDataTable(p_SQL, p_SQL)
                        If Not p_Table Is Nothing Then
                            If p_Table.Rows.Count > 0 Then
                                o_err = p_Table.Rows(0).Item("Desc_Err").ToString.Trim
                                Return False
                            End If
                        End If
                    Next
                    ' If

                End If

                If l_ztb.Item(0).Shpoint = p_ShPoint Then
                    If l_ztb.Item(0).Storage <> String.Empty Then
                        If l_ztb.Item(0).Batch_Nd <> String.Empty Then

                            If mdlSyncDeliveries_SubModifyFromTable_new(p_Client, p_SapConnectionString, l_ztb, o_err, p_DiemTraHang) = False Then
                                l_c2sap.Connection.Close()
                                l_c2sap.Dispose()
                                Return False
                            End If

                            'hieptd4 add 20161102 
                            mdlSyncDeliveries_SynSpecific = mdlSyncDeliveries_SynSpecific_Ex(p_Client, p_User_ID, _
                                                                          p_Company_Code, i_solenh, o_err)

                            o_err = "Đồng bộ dữ liệu thành công!"

                            Return True
                        Else
                            o_err = "Lệnh xuất chưa được phép xuất hàng!"
                        End If
                    Else
                        o_err = "Chưa có Storage Location nên không thể đồng bộ lệnh xuất này!"
                    End If
                Else
                    o_err = "Lệnh xuất khác Shipping Point nên không thể xuất hàng!"
                End If
            Else
                o_err = "Lệnh xuất không hợp lệ để thực hiện xuất hàng." & vbCrLf & "Đề nghị kiểm tra ngày tháng hoặc trạng thái lệnh)!"
            End If
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            'Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try


    End Function

    'anhqh 20201201
    'Ham dung cho chuc nang dong bo hang loat
    Public Function mdlSyncDeliveries_SynSpecific_Auto(ByVal p_Client As String, ByVal p_User_ID As Integer, _
                                                    ByVal p_Company_Code As String, ByVal i_solenh As String, ByRef o_err As String, ByVal p_Date As Date, _
                                                     Optional ByVal p_Future As Boolean = False) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP

        ' Dim l_c2sap111 As Connect2SAP.


        'Dim l_c2sapex As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SAP.Str_PhieuXuatTable
        ' Dim l_ztb As Connect2SapEx.LIPSO2Table
        Dim l_ret2 As Connect2SAP.BAPIRET2
        ' Dim l_ret2ex As Connect2SapEx.BAPIRET2
        Dim l_err As String
        Dim l_f As Boolean = False

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String
        Dim p_TableConfig As DataTable
        Dim p_TableConfig1 As DataTable
        Dim p_SapConnectionString As String = ""
        Dim p_TimeOut = New TimeSpan()
        Dim p_WareHouse As String = ""
        Dim p_ShPoint As String = ""
        Dim p_DataRowArr() As DataRow
        ' Dim p_Table As DataTable
        Dim p_DataSet As New DataSet
        Dim p_Batch As String
        Dim p_Slog As String
        Dim p_MaKhachHang As String
        Dim p_StringTmp As String = "0000000000"
        Dim p_SoLenh As String
        Dim p_Table As DataTable
        Dim p_DiemTraHang As String

        Dim p_Count As Integer

        g_Company_Code = p_Company_Code

        mdlSyncDeliveries_SynSpecific_Auto = False
        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG; select * from tblConfig;"
        p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

        g_KV1 = False

        g_User_ID = p_User_ID


        g_BATCHSLOG = False

        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_TableConfig = p_DataSet.Tables(0)
                p_TableConfig1 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_DataRowArr = p_TableConfig.Select("KEYCODE='TABLEID'")
                If p_DataRowArr.Length > 0 Then
                    p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='QUYDOI_SAP'")
                If p_DataRowArr.Length > 0 Then
                    p_QUYDOI_SAP = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KV1'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_KV1 = True
                    Else
                        g_KV1 = False
                    End If
                End If


                p_ThamSoNgay = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='THAMSONGAY'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_ThamSoNgay = True
                    Else
                        p_ThamSoNgay = False
                    End If
                End If



                p_DataRowArr = p_TableConfig.Select("KEYCODE='BATCHSLOG'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_BATCHSLOG = True
                    Else
                        g_BATCHSLOG = False
                    End If
                End If

                'MATUDONGHOA_PROD
                'anhqh
                '20161115
                p_DataRowArr = p_TableConfig.Select("KEYCODE='MATUDONGHOA_PROD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        p_MATUDONGHOA_PROD = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                    End If
                End If


                'anhqh
                '20170414
                'Tham so kiem tra han muc
                p_KiemTraHanMuc = True

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KIEMTRAHANMUC'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_KiemTraHanMuc = False
                    End If
                End If

                'anhqh
                '20170419
                'Tham so kiem tra TD co duoc gan tren SAP khoong
                p_KIEMTRA_TD = True
                p_DataRowArr = p_TableConfig.Select("KEYCODE='KIEMTRA_TD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_KIEMTRA_TD = False
                    End If
                End If


                'CONGTO_BEXUAT
                p_CONGTO_BEXUAT = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='CONGTO_BEXUAT'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_CONGTO_BEXUAT = True
                    End If
                End If


                p_KiemTraDiChuyen_TD = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='KT_DICHUYEN_TD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_KiemTraDiChuyen_TD = True
                    End If
                End If

            End If
        End If



        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                p_SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If
        If p_SapConnectionString = "" Then
            mdlSyncDeliveries_SynSpecific_Auto = True
            MsgBox("Loi ket noi")
            Exit Function
        End If



        Try
            l_c2sap = New Connect2SAP.Connect2SAP(p_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_PhieuXuatTable()
            ' l_ztb As Connect2SapEx.LIPSO2Table
            l_err = String.Empty



            If p_TableConfig1.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
                l_c2sap.GetPhieuXuat_Specific(i_solenh, l_ztb, l_ret2)

            Else
                l_async = l_c2sap.BeginGetPhieuXuat_Specific(i_solenh, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetPhieuXuat_Specific(l_async, l_ztb, l_ret2)
                End If
            End If



            If l_ztb.Count > 0 Then
                If p_KiemTraDiChuyen_TD = True Then
                    'anhqh
                    '20200813
                    'Kiem tra lenh di chuyen khong TD
                    p_SQL = "exec FPT_KiemTraDiChuyenKhongGanTD '" & l_ztb(0).Batch_Nd.ToString.Trim & "','" & l_ztb(0).Shnumber.ToString.Trim & "','" & l_ztb(0).Saleorder.ToString.Trim & "'"
                    p_Table = GetDataTable(p_SQL, p_SQL)
                    If Not p_Table Is Nothing Then
                        If p_Table.Rows.Count > 0 Then
                            If p_Table.Rows(0).Item(0).ToString.Trim = "1" Then
                                o_err = "Lệnh xuất chưa được gán TD!"
                                Return False
                            End If
                        End If
                    End If
                End If

                If p_ThamSoNgay = True Then
                    ' Dim p_table As DataTable
                    'l_ztb(0).Date_Nd .ToString.Trim 
                    For p_Count = 0 To l_ztb.Count - 1
                        If l_ztb(p_Count).Date_Nd <> p_Date.ToString("yyyyMMdd") Then
                            l_ztb(p_Count).Date_Nd = p_Date.ToString("yyyyMMdd")
                        End If

                    Next
                    p_SQL = "select convert(date,getdate()+1)  as dSysDate, convert(date,'" & l_ztb(0).Date_Nd.ToString.Trim & "') as dDate "
                    p_Table = GetDataTable(p_SQL, p_SQL)
                    If Not p_Table Is Nothing Then
                        If CDate(p_Table.Rows(0).Item(1)) > CDate(p_Table.Rows(0).Item(0)) Then
                            o_err = "Ngày tháng lệnh xuất không hợp lệ!"
                            Return False
                        End If
                    End If
                Else
                    If p_Future = False Then
                        If Not mdlSyncDeliveries_CheckStartTime(l_ztb.Item(0).Date_Nd) Then
                            o_err = "Lệnh xuất chưa được phép xuất hàng!"
                            Return False
                        End If
                    End If

                End If

                '------------------------------------------------------------------------------
                '   Kiểm tra thời hạn hiệu lực của hóa đơn
                '------------------------------------------------------------------------------
                'FES44
                '20141113


                If Not mdlSyncDeliveries_CheckEndTime(l_ztb.Item(0).Date_E_Nd) Then
                    o_err = "Lệnh xuất đã hết hạn!"
                    Return False
                End If

                If l_ztb.Item(0).Plant <> p_WareHouse Then
                    o_err = "Kiểm tra thông tin Kho xuất hàng ghi trên lệnh xuất!"
                    Return False
                End If
                p_DiemTraHang = GetDiemTraHang(l_ztb(0).Shnumber.ToString.Trim, p_SapConnectionString,
                                       p_TableConfig1, p_TimeOut)


                If g_BATCHSLOG = True Then

                    For p_Count = 0 To l_ztb.Count - 1
                        'If l_ztb.Item(0).Resource_Nd = "N40" Or l_ztb.Item(0).Resource_Nd = "N45" Then
                        p_Batch = l_ztb.Item(p_Count).Batch_Nd
                        p_Slog = l_ztb.Item(p_Count).Storage
                        p_SoLenh = l_ztb.Item(p_Count).Order_No

                        p_MaKhachHang = Mid(p_Batch, 4)
                        p_MaKhachHang = Left(p_StringTmp, 10 - (Len(p_MaKhachHang))) & p_MaKhachHang

                        p_SQL = "exec FPT_CheckBatch '" & l_ztb.Item(p_Count).Order_No.ToString & "','" & l_ztb.Item(p_Count).Resource_Nd.ToString & _
                            "','" & p_Slog & "','" & l_ztb.Item(p_Count).Customer.ToString & "','" & p_MaKhachHang & "'"
                        p_Table = GetDataTable(p_SQL, p_SQL)
                        If Not p_Table Is Nothing Then
                            If p_Table.Rows.Count > 0 Then
                                o_err = p_Table.Rows(0).Item("Desc_Err").ToString.Trim
                                Return False
                            End If
                        End If
                    Next
                    ' If

                End If


                If l_ztb.Item(0).Shpoint = p_ShPoint Then
                    If l_ztb.Item(0).Storage <> String.Empty Then
                        If l_ztb.Item(0).Batch_Nd <> String.Empty Then

                            If mdlSyncDeliveries_SubModifyFromTable_Auto(p_Client, p_SapConnectionString, l_ztb, o_err, p_DiemTraHang, p_Date) = False Then
                                l_c2sap.Connection.Close()
                                l_c2sap.Dispose()
                                Return False
                            End If

                            'hieptd4 add 20161102 
                            mdlSyncDeliveries_SynSpecific_Auto = mdlSyncDeliveries_SynSpecific_Ex(p_Client, p_User_ID, _
                                                                          p_Company_Code, i_solenh, o_err)

                            o_err = "Đồng bộ dữ liệu thành công!"

                            Return True
                        Else
                            o_err = "Lệnh xuất chưa được phép xuất hàng!"
                        End If
                    Else
                        o_err = "Chưa có Storage Location nên không thể đồng bộ lệnh xuất này!"
                    End If
                Else
                    o_err = "Lệnh xuất khác Shipping Point nên không thể xuất hàng!"
                End If
            Else
                o_err = "Lệnh xuất không hợp lệ để thực hiện xuất hàng." & vbCrLf & "Đề nghị kiểm tra ngày tháng hoặc trạng thái lệnh)!"
            End If
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            'Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try


    End Function



    Public Function mdlSyncDeliveries_NgayHieuLuc(ByVal p_Client As String, ByVal p_User_ID As Integer, _
                                                    ByVal p_Company_Code As String, ByVal i_solenh As String, ByRef o_err As String, _
                                                    ByVal p_Date As String, Optional ByVal p_Future As Boolean = False) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP

        ' Dim l_c2sap111 As Connect2SAP.


        'Dim l_c2sapex As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SAP.Str_PhieuXuatTable
        ' Dim l_ztb As Connect2SapEx.LIPSO2Table
        Dim l_ret2 As Connect2SAP.BAPIRET2
        ' Dim l_ret2ex As Connect2SapEx.BAPIRET2
        Dim l_err As String
        Dim l_f As Boolean = False

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String
        Dim p_TableConfig As DataTable
        Dim p_TableConfig1 As DataTable
        Dim p_SapConnectionString As String = ""
        Dim p_TimeOut = New TimeSpan()
        Dim p_WareHouse As String = ""
        Dim p_ShPoint As String = ""
        Dim p_DataRowArr() As DataRow
        ' Dim p_Table As DataTable
        Dim p_DataSet As New DataSet
        Dim p_Batch As String
        Dim p_Slog As String
        Dim p_MaKhachHang As String
        Dim p_StringTmp As String = "0000000000"
        Dim p_SoLenh As String
        Dim p_Table As DataTable
        Dim p_DiemTraHang As String

        Dim p_Count As Integer

        g_Company_Code = p_Company_Code

        mdlSyncDeliveries_NgayHieuLuc = False
        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG; select * from tblConfig;"
        p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

        g_KV1 = False

        g_User_ID = p_User_ID


        g_BATCHSLOG = False

        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_TableConfig = p_DataSet.Tables(0)
                p_TableConfig1 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_DataRowArr = p_TableConfig.Select("KEYCODE='TABLEID'")
                If p_DataRowArr.Length > 0 Then
                    p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='QUYDOI_SAP'")
                If p_DataRowArr.Length > 0 Then
                    p_QUYDOI_SAP = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KV1'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_KV1 = True
                    Else
                        g_KV1 = False
                    End If
                End If


                p_ThamSoNgay = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='THAMSONGAY'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_ThamSoNgay = True
                    Else
                        p_ThamSoNgay = False
                    End If
                End If



                p_DataRowArr = p_TableConfig.Select("KEYCODE='BATCHSLOG'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_BATCHSLOG = True
                    Else
                        g_BATCHSLOG = False
                    End If
                End If

                'MATUDONGHOA_PROD
                'anhqh
                '20161115
                p_DataRowArr = p_TableConfig.Select("KEYCODE='MATUDONGHOA_PROD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        p_MATUDONGHOA_PROD = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                    End If
                End If


                'anhqh
                '20170414
                'Tham so kiem tra han muc
                p_KiemTraHanMuc = True

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KIEMTRAHANMUC'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_KiemTraHanMuc = False
                    End If
                End If

                'anhqh
                '20170419
                'Tham so kiem tra TD co duoc gan tren SAP khoong
                p_KIEMTRA_TD = True
                p_DataRowArr = p_TableConfig.Select("KEYCODE='KIEMTRA_TD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_KIEMTRA_TD = False
                    End If
                End If


                'CONGTO_BEXUAT
                p_CONGTO_BEXUAT = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='CONGTO_BEXUAT'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_CONGTO_BEXUAT = True
                    End If
                End If


                p_KiemTraDiChuyen_TD = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='KT_DICHUYEN_TD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_KiemTraDiChuyen_TD = True
                    End If
                End If

            End If
        End If



        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                p_SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If
        If p_SapConnectionString = "" Then
            mdlSyncDeliveries_NgayHieuLuc = True
            MsgBox("Loi ket noi")
            Exit Function
        End If



        Try
            l_c2sap = New Connect2SAP.Connect2SAP(p_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_PhieuXuatTable()
            ' l_ztb As Connect2SapEx.LIPSO2Table
            l_err = String.Empty



            If p_TableConfig1.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
                l_c2sap.GetPhieuXuat_Specific(i_solenh, l_ztb, l_ret2)

            Else
                l_async = l_c2sap.BeginGetPhieuXuat_Specific(i_solenh, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetPhieuXuat_Specific(l_async, l_ztb, l_ret2)
                End If
            End If



            If l_ztb.Count > 0 Then
                If p_KiemTraDiChuyen_TD = True Then
                    'anhqh
                    '20200813
                    'Kiem tra lenh di chuyen khong TD
                    p_SQL = "exec FPT_KiemTraDiChuyenKhongGanTD '" & l_ztb(0).Batch_Nd.ToString.Trim & "','" & l_ztb(0).Shnumber.ToString.Trim & "','" & l_ztb(0).Saleorder.ToString.Trim & "'"
                    p_Table = GetDataTable(p_SQL, p_SQL)
                    If Not p_Table Is Nothing Then
                        If p_Table.Rows.Count > 0 Then
                            If p_Table.Rows(0).Item(0).ToString.Trim = "1" Then
                                o_err = "Lệnh xuất chưa được gán TD!"
                                Return False
                            End If
                        End If
                    End If
                End If

                '   If p_ThamSoNgay = True Then

                For p_Count = 0 To l_ztb.Count - 1
                    If l_ztb(p_Count).Date_Nd.ToString = "" Then
                        l_ztb(p_Count).Date_Nd = p_Date
                    End If

                Next
                p_SQL = "select convert(date,getdate()+1)  as dSysDate, convert(date,'" & l_ztb(0).Date_Nd.ToString.Trim & "') as dDate "
                p_Table = GetDataTable(p_SQL, p_SQL)
                If Not p_Table Is Nothing Then
                    If CDate(p_Table.Rows(0).Item(1)) > CDate(p_Table.Rows(0).Item(0)) Then
                        o_err = "Ngày tháng lệnh xuất không hợp lệ!"
                        Return False
                    End If
                End If
                'Else
                '    If Not mdlSyncDeliveries_CheckStartTime(l_ztb.Item(0).Date_Nd) Then
                '        o_err = "Lệnh xuất chưa được phép xuất hàng!"
                '        Return False
                '    End If
                'End If

                '------------------------------------------------------------------------------
                '   Kiểm tra thời hạn hiệu lực của hóa đơn
                '------------------------------------------------------------------------------
                'FES44
                '20141113


                If Not mdlSyncDeliveries_CheckEndTime(l_ztb.Item(0).Date_E_Nd) Then
                    o_err = "Lệnh xuất đã hết hạn!"
                    Return False
                End If

                If l_ztb.Item(0).Plant <> p_WareHouse Then
                    o_err = "Kiểm tra thông tin Kho xuất hàng ghi trên lệnh xuất!"
                    Return False
                End If
                p_DiemTraHang = GetDiemTraHang(l_ztb(0).Shnumber.ToString.Trim, p_SapConnectionString,
                                       p_TableConfig1, p_TimeOut)


                If g_BATCHSLOG = True Then

                    For p_Count = 0 To l_ztb.Count - 1
                        'If l_ztb.Item(0).Resource_Nd = "N40" Or l_ztb.Item(0).Resource_Nd = "N45" Then
                        p_Batch = l_ztb.Item(p_Count).Batch_Nd
                        p_Slog = l_ztb.Item(p_Count).Storage
                        p_SoLenh = l_ztb.Item(p_Count).Order_No

                        p_MaKhachHang = Mid(p_Batch, 4)
                        p_MaKhachHang = Left(p_StringTmp, 10 - (Len(p_MaKhachHang))) & p_MaKhachHang

                        p_SQL = "exec FPT_CheckBatch '" & l_ztb.Item(p_Count).Order_No.ToString & "','" & l_ztb.Item(p_Count).Resource_Nd.ToString & _
                            "','" & p_Slog & "','" & l_ztb.Item(p_Count).Customer.ToString & "','" & p_MaKhachHang & "'"
                        p_Table = GetDataTable(p_SQL, p_SQL)
                        If Not p_Table Is Nothing Then
                            If p_Table.Rows.Count > 0 Then
                                o_err = p_Table.Rows(0).Item("Desc_Err").ToString.Trim
                                Return False
                            End If
                        End If
                    Next
                    ' If

                End If

                'o_err = "anhqh"

                If l_ztb.Item(0).Shpoint = p_ShPoint Then
                    If l_ztb.Item(0).Storage <> String.Empty Then
                        If l_ztb.Item(0).Batch_Nd <> String.Empty Then

                            If mdlSyncDeliveries_SubModifyFromTable_new(p_Client, p_SapConnectionString, l_ztb, o_err, p_DiemTraHang, True) = False Then
                                l_c2sap.Connection.Close()
                                l_c2sap.Dispose()
                                Return False
                            End If

                            'hieptd4 add 20161102 
                            mdlSyncDeliveries_NgayHieuLuc = mdlSyncDeliveries_SynSpecific_Ex(p_Client, p_User_ID, _
                                                                          p_Company_Code, i_solenh, o_err)

                            o_err = "Đồng bộ dữ liệu thành công!"

                            Return True
                        Else
                            o_err = "Lệnh xuất chưa được phép xuất hàng!"
                        End If
                    Else
                        o_err = "Chưa có Storage Location nên không thể đồng bộ lệnh xuất này!"
                    End If
                Else
                    o_err = "Lệnh xuất khác Shipping Point nên không thể xuất hàng!"
                End If
            Else
                o_err = "Lệnh xuất không hợp lệ để thực hiện xuất hàng." & vbCrLf & "Đề nghị kiểm tra ngày tháng hoặc trạng thái lệnh)!"
            End If
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            'Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try


    End Function

    Public Function mdlSyncDeliveries_SynSpecificAuto(ByVal l_ztb As Connect2SAP.Str_PhieuXuatTable, ByVal p_Client As String, ByVal p_User_ID As Integer, _
                                                    ByVal p_Company_Code As String, ByVal i_solenh As String, ByRef o_err As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP

        ' Dim l_c2sap111 As Connect2SAP.


        'Dim l_c2sapex As Connect2SapEx.Connect2Sap
        'Dim l_ztb As Connect2SAP.Str_PhieuXuatTable
        ' Dim l_ztb As Connect2SapEx.LIPSO2Table
        Dim l_ret2 As Connect2SAP.BAPIRET2
        ' Dim l_ret2ex As Connect2SapEx.BAPIRET2
        Dim l_err As String
        Dim l_f As Boolean = False

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String
        Dim p_TableConfig As DataTable
        Dim p_TableConfig1 As DataTable
        Dim p_SapConnectionString As String = ""
        Dim p_TimeOut = New TimeSpan()
        Dim p_WareHouse As String = ""
        Dim p_ShPoint As String = ""
        Dim p_DataRowArr() As DataRow

        Dim p_DataSet As New DataSet
        Dim p_Batch As String
        Dim p_Slog As String
        Dim p_MaKhachHang As String
        Dim p_StringTmp As String = "0000000000"
        Dim p_SoLenh As String
        Dim p_Table As DataTable
        Dim p_DiemTraHang As String


        ''Dim l_ztb = New Connect2SAP.Str_PhieuXuatTable


        Dim p_Count As Integer

        g_Company_Code = p_Company_Code

        g_Terminal = p_Client

        mdlSyncDeliveries_SynSpecificAuto = False
        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG; select * from tblConfig;"
        p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

        g_KV1 = False

        g_User_ID = p_User_ID


        g_BATCHSLOG = False

        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_TableConfig = p_DataSet.Tables(0)
                p_TableConfig1 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_DataRowArr = p_TableConfig.Select("KEYCODE='TABLEID'")
                If p_DataRowArr.Length > 0 Then
                    p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='QUYDOI_SAP'")
                If p_DataRowArr.Length > 0 Then
                    p_QUYDOI_SAP = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KV1'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_KV1 = True
                    Else
                        g_KV1 = False
                    End If
                End If


                p_DataRowArr = p_TableConfig.Select("KEYCODE='BATCHSLOG'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_BATCHSLOG = True
                    Else
                        g_BATCHSLOG = False
                    End If
                End If

                'MATUDONGHOA_PROD
                'anhqh
                '20161115
                p_DataRowArr = p_TableConfig.Select("KEYCODE='MATUDONGHOA_PROD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim <> "" Then
                        p_MATUDONGHOA_PROD = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                    End If
                End If


                'anhqh
                '20170414
                'Tham so kiem tra han muc
                p_KiemTraHanMuc = True

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KIEMTRAHANMUC'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_KiemTraHanMuc = False
                    End If
                End If

                'anhqh
                '20170419
                'Tham so kiem tra TD co duoc gan tren SAP khoong
                p_KIEMTRA_TD = True
                p_DataRowArr = p_TableConfig.Select("KEYCODE='KIEMTRA_TD'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "N" Then
                        p_KIEMTRA_TD = False
                    End If
                End If


                'CONGTO_BEXUAT
                p_CONGTO_BEXUAT = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='CONGTO_BEXUAT'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_CONGTO_BEXUAT = True
                    End If
                End If

            End If
        End If



        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                p_SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If
        If p_SapConnectionString = "" Then
            mdlSyncDeliveries_SynSpecificAuto = True
            MsgBox("Loi ket noi")
            Exit Function
        End If



        Try

            l_err = String.Empty


            ' For p_Count = 0 To p1_l_ztb.Count - 1



            If l_ztb.Count > 0 Then

                '------------------------------------------------------------------------------
                '   Kiểm tra thời hạn hiệu lực của hóa đơn
                '------------------------------------------------------------------------------
                'FES44
                '20141113
                If Not mdlSyncDeliveries_CheckStartTime(l_ztb.Item(0).Date_Nd) Then
                    o_err = "Lệnh xuất chưa được phép xuất hàng!"
                    Return False
                End If

                If Not mdlSyncDeliveries_CheckEndTime(l_ztb.Item(0).Date_E_Nd) Then
                    o_err = "Lệnh xuất đã hết hạn!"
                    Return False
                End If

                If l_ztb.Item(0).Plant <> p_WareHouse Then
                    o_err = "Kiểm tra thông tin Kho xuất hàng ghi trên lệnh xuất!"
                    Return False
                End If
                p_DiemTraHang = GetDiemTraHang(l_ztb(0).Shnumber.ToString.Trim, p_SapConnectionString,
                                       p_TableConfig1, p_TimeOut)


                If g_BATCHSLOG = True Then

                    For p_Count = 0 To l_ztb.Count - 1
                        'If l_ztb.Item(0).Resource_Nd = "N40" Or l_ztb.Item(0).Resource_Nd = "N45" Then
                        p_Batch = l_ztb.Item(p_Count).Batch_Nd
                        p_Slog = l_ztb.Item(p_Count).Storage
                        p_SoLenh = l_ztb.Item(p_Count).Order_No

                        p_MaKhachHang = Mid(p_Batch, 4)
                        p_MaKhachHang = Left(p_StringTmp, 10 - (Len(p_MaKhachHang))) & p_MaKhachHang

                        p_SQL = "exec FPT_CheckBatch '" & l_ztb.Item(p_Count).Order_No.ToString & "','" & l_ztb.Item(p_Count).Resource_Nd.ToString & _
                            "','" & p_Slog & "','" & l_ztb.Item(p_Count).Customer.ToString & "','" & p_MaKhachHang & "'"
                        p_Table = GetDataTable(p_SQL, p_SQL)
                        If Not p_Table Is Nothing Then
                            If p_Table.Rows.Count > 0 Then
                                o_err = p_Table.Rows(0).Item("Desc_Err").ToString.Trim
                                Return False
                            End If
                        End If
                    Next
                    ' If

                End If


                If l_ztb.Item(0).Shpoint = p_ShPoint Then
                    If l_ztb.Item(0).Storage <> String.Empty Then
                        If l_ztb.Item(0).Batch_Nd <> String.Empty Then

                            If mdlSyncDeliveries_SubModifyFromTable_new(p_Client, p_SapConnectionString, l_ztb, o_err, p_DiemTraHang) = False Then
                                l_c2sap.Connection.Close()
                                l_c2sap.Dispose()
                                Return False
                            End If

                            ''hieptd4 add 20161102 
                            'mdlSyncDeliveries_SynSpecificAuto = mdlSyncDeliveries_SynSpecific_Ex(p_Client, p_User_ID, _
                            '                                              p_Company_Code, i_solenh, o_err)

                            o_err = "Đồng bộ dữ liệu thành công!"

                            Return True
                        Else
                            o_err = "Lệnh xuất chưa được phép xuất hàng!"
                        End If
                    Else
                        o_err = "Chưa có Storage Location nên không thể đồng bộ lệnh xuất này!"
                    End If
                Else
                    o_err = "Lệnh xuất khác Shipping Point nên không thể xuất hàng!"
                End If
            Else
                o_err = "Lệnh xuất không hợp lệ để thực hiện xuất hàng." & vbCrLf & "Đề nghị kiểm tra ngày tháng hoặc trạng thái lệnh)!"
            End If
            'Next
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            'Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try


    End Function



    Public Function KV1mdlSyncDeliveries_SynSpecific(ByVal p_Client As String, ByVal p_User_ID As Integer, _
                                                    ByVal p_Company_Code As String, ByVal i_solenh As String, ByRef o_err As String, _
                                                    ByVal p_crdDate As Date, Optional ByVal p_LaiNgay As String = "", Optional ByVal p_Future As Boolean = False) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP

        ' Dim l_c2sap111 As Connect2SAP.
        Dim p_MaPhuongTien As String = ""

        'Dim l_c2sapex As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SAP.Str_PhieuXuatTable
        ' Dim l_ztb As Connect2SapEx.LIPSO2Table
        Dim l_ret2 As Connect2SAP.BAPIRET2
        ' Dim l_ret2ex As Connect2SapEx.BAPIRET2
        Dim l_err As String
        Dim l_f As Boolean = False

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String
        Dim p_TableConfig As DataTable
        Dim p_TableConfig1 As DataTable
        Dim p_SapConnectionString As String = ""
        Dim p_TimeOut = New TimeSpan()
        Dim p_WareHouse As String = ""
        Dim p_ShPoint As String = ""
        Dim p_DataRowArr() As DataRow

        Dim p_DataSet As New DataSet
        Dim p_Batch As String
        Dim p_Slog As String
        Dim p_MaKhachHang As String
        Dim p_StringTmp As String = "0000000000"
        Dim p_SoLenh As String
        Dim p_Table As DataTable
        Dim p_DiemTraHang As String
        'Dim p_LaiNgayDem As Boolean = False
        Dim p_Count As Integer

        g_Company_Code = p_Company_Code

        KV1mdlSyncDeliveries_SynSpecific = False
        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG; select * from tblConfig;"
        p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

        g_KV1 = False

        g_User_ID = p_User_ID


        g_BATCHSLOG = False

        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_TableConfig = p_DataSet.Tables(0)
                p_TableConfig1 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_DataRowArr = p_TableConfig.Select("KEYCODE='TABLEID'")
                If p_DataRowArr.Length > 0 Then
                    p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='QUYDOI_SAP'")
                If p_DataRowArr.Length > 0 Then
                    p_QUYDOI_SAP = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KV1'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_KV1 = True
                    Else
                        g_KV1 = False
                    End If
                End If


                p_DataRowArr = p_TableConfig.Select("KEYCODE='BATCHSLOG'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_BATCHSLOG = True
                    Else
                        g_BATCHSLOG = False
                    End If
                End If

                p_LaiNgayDem = False
                p_DataRowArr = p_TableConfig.Select("KEYCODE='LAINGAY'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_LaiNgayDem = True
                    Else
                        p_LaiNgayDem = False
                    End If
                End If
            End If
        End If



        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                p_SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If
        If p_SapConnectionString = "" Then
            KV1mdlSyncDeliveries_SynSpecific = True
            MsgBox("Loi ket noi")
            Exit Function
        End If


        Try
            l_c2sap = New Connect2SAP.Connect2SAP(p_SapConnectionString)
            l_ret2 = New Connect2SAP.BAPIRET2()
            l_ztb = New Connect2SAP.Str_PhieuXuatTable()
            ' l_ztb As Connect2SapEx.LIPSO2Table
            l_err = String.Empty



            If p_TableConfig1.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
                l_c2sap.GetPhieuXuat_Specific(i_solenh, l_ztb, l_ret2)

            Else
                l_async = l_c2sap.BeginGetPhieuXuat_Specific(i_solenh, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetPhieuXuat_Specific(l_async, l_ztb, l_ret2)
                End If
            End If



            If l_ztb.Count > 0 Then
                'anhqh
                '20161020
                'Kiem tra lenh di chuyen khong TD
                If g_KV1 = True Then
                    p_SQL = "exec FPT_KiemTraDiChuyenKhongGanTD '" & l_ztb(0).Batch_Nd.ToString.Trim & "','" & _
                                     l_ztb(0).Shnumber.ToString.Trim & "','" & l_ztb(0).Saleorder.ToString.Trim & "','" & l_ztb(0).Customer.ToString.Trim & "'"
                Else
                    p_SQL = "exec FPT_KiemTraDiChuyenKhongGanTD '" & l_ztb(0).Batch_Nd.ToString.Trim & "','" & _
                                     l_ztb(0).Shnumber.ToString.Trim & "','" & l_ztb(0).Saleorder.ToString.Trim & "'"
                End If

                p_Table = GetDataTable(p_SQL, p_SQL)

                If Not p_Table Is Nothing Then
                    If p_Table.Rows.Count > 0 Then
                        If p_Table.Rows(0).Item(0).ToString.Trim = "1" Then
                            o_err = "Lệnh xuất chưa được gán TD!"
                            Return False
                        End If
                    End If
                End If
                'If g_KV1 = True Then
                For p_Count = 0 To l_ztb.Count - 1
                    l_ztb(p_Count).Date_Nd = p_crdDate.ToString("yyyyMMdd")
                Next
                'End If
                '------------------------------------------------------------------------------
                '   Kiểm tra thời hạn hiệu lực của hóa đơn
                '------------------------------------------------------------------------------
                'FES44
                '20141113
                If g_KV1 = False Then
                    If Not mdlSyncDeliveries_CheckStartTime(l_ztb.Item(0).Date_Nd) Then
                        o_err = "Lệnh xuất chưa được phép xuất hàng!"
                        Return False
                    End If
                End If


                If Not mdlSyncDeliveries_CheckEndTime(l_ztb.Item(0).Date_E_Nd) Then
                    o_err = "Lệnh xuất đã hết hạn!"
                    Return False
                End If

                If l_ztb.Item(0).Plant <> p_WareHouse Then
                    o_err = "Kiểm tra thông tin Kho xuất hàng ghi trên lệnh xuất!"
                    Return False
                End If
                p_DiemTraHang = GetDiemTraHang(l_ztb(0).Shnumber.ToString.Trim, p_SapConnectionString,
                                       p_TableConfig1, p_TimeOut)


                If g_BATCHSLOG = True Then
                    For p_Count = 0 To l_ztb.Count - 1
                        If l_ztb.Item(p_Count).Resource_Nd.ToString = "" Then
                            o_err = "Lệnh xuất có mặt hàng chưa nhập thông tin Batch!"
                            Exit Function
                        End If


                        p_Batch = l_ztb.Item(p_Count).Batch_Nd
                        p_Slog = l_ztb.Item(p_Count).Storage
                        p_SoLenh = l_ztb.Item(p_Count).Order_No

                        p_MaKhachHang = Mid(p_Batch, 4)
                        p_MaKhachHang = Left(p_StringTmp, 10 - (Len(p_MaKhachHang))) & p_MaKhachHang


                        ''''''anhqh  20200617  check theo line
                        p_SQL = "exec FPT_CheckBatch '" & l_ztb.Item(p_Count).Order_No.ToString & "','" & l_ztb.Item(p_Count).Resource_Nd.ToString & _
                            "','" & p_Slog & "','" & l_ztb.Item(p_Count).Customer.ToString & "','" & p_MaKhachHang & "'"
                        p_Table = GetDataTable(p_SQL, p_SQL)
                        If Not p_Table Is Nothing Then
                            If p_Table.Rows.Count > 0 Then
                                o_err = p_Table.Rows(0).Item("Desc_Err").ToString.Trim
                                Return False
                            End If
                        End If


                    Next
                    'If l_ztb.Item(0).Resource_Nd = "N40" Or l_ztb.Item(0).Resource_Nd = "N45" Then
                    'p_Batch = l_ztb.Item(0).Batch_Nd
                    'p_Slog = l_ztb.Item(0).Storage
                    'p_SoLenh = l_ztb.Item(0).Order_No

                    'p_MaKhachHang = Mid(p_Batch, 4)
                    'p_MaKhachHang = Left(p_StringTmp, 10 - (Len(p_MaKhachHang))) & p_MaKhachHang


                    ''''''anhqh  20200617 chuyen doan nay vao for check theo line
                    'p_SQL = "exec FPT_CheckBatch '" & l_ztb.Item(0).Order_No.ToString & "','" & l_ztb.Item(0).Resource_Nd.ToString & _
                    '    "','" & p_Slog & "','" & l_ztb.Item(0).Customer.ToString & "','" & p_MaKhachHang & "'"
                    'p_Table = GetDataTable(p_SQL, p_SQL)
                    'If Not p_Table Is Nothing Then
                    '    If p_Table.Rows.Count > 0 Then
                    '        o_err = p_Table.Rows(0).Item("Desc_Err").ToString.Trim
                    '        Return False
                    '    End If
                    'End If

                    ' If

                End If


                If l_ztb.Item(0).Shpoint = p_ShPoint Then
                    If l_ztb.Item(0).Storage <> String.Empty Then
                        If l_ztb.Item(0).Batch_Nd <> String.Empty Then

                            If mdlSyncDeliveries_SubModifyFromTable_new(p_Client, p_SapConnectionString, l_ztb, o_err, p_DiemTraHang) = False Then
                                l_c2sap.Connection.Close()
                                l_c2sap.Dispose()
                                Return False
                            End If

                            'hieptd4 add 20161102 
                            KV1mdlSyncDeliveries_SynSpecific = mdlSyncDeliveries_SynSpecific_Ex(p_Client, p_User_ID, _
                                                                          p_Company_Code, i_solenh, o_err)


                            '20181010
                            'anhqh them cap nhat lai xe ngay hoac dem
                            If p_LaiNgayDem = True Then
                                p_MaPhuongTien = l_ztb.Item(0).Vehicle.ToString
                                If p_LaiNgay = "Y" Then
                                    p_SQL = "   select top 1  [MaPhuongTien],[HoVaTen],[NoiDung] ,CONVERT(date,isnull(FromDate,GETDATE()-5)) as [FromDate]," & _
                                           " CONVERT(date,isnull(ToDate,GETDATE()+5 )) as [ToDate],[sType] ,[sDefault] from tblPhuongTien_LaiXe where upper( MaPhuongTien) ='" & p_MaPhuongTien & "' and isnull(Dem,'N') <>'Y' order by len(isnull(sDefault,'')) desc ;"
                                    p_SQL = p_SQL & " SELECT  [ID],[MaPhuongTien],[NoiDung] ,CONVERT(date,isnull(FromDate,GETDATE()-5)) as [FromDate], " & _
                                         "CONVERT(date,isnull(ToDate,GETDATE()+5 )) as [ToDate],[sType] FROM [tblPhuongTien_Infor] " & _
                                            " where upper( MaPhuongTien) ='" & p_MaPhuongTien & "'   and ( CONVERT(date,getdate())<=  CONVERT(date,isnull(FromDate,GETDATE()-5))	" & _
                                                     "or  CONVERT(date,getdate())>= CONVERT(date,isnull(ToDate,GETDATE()+5 )))"
                                Else
                                    p_SQL = "   select [MaPhuongTien],[HoVaTen],[NoiDung] ,CONVERT(date,isnull(FromDate,GETDATE()-5)) as [FromDate]," & _
                                   " CONVERT(date,isnull(ToDate,GETDATE()+5 )) as [ToDate],[sType] ,[sDefault] from tblPhuongTien_LaiXe where upper( MaPhuongTien) ='" & p_MaPhuongTien & "' and isnull(Dem,'N') ='Y' ;"
                                    p_SQL = p_SQL & " SELECT  [ID],[MaPhuongTien],[NoiDung] ,CONVERT(date,isnull(FromDate,GETDATE()-5)) as [FromDate], " & _
                                         "CONVERT(date,isnull(ToDate,GETDATE()+5 )) as [ToDate],[sType] FROM [tblPhuongTien_Infor] " & _
                                            " where upper( MaPhuongTien) ='" & p_MaPhuongTien & "'   and ( CONVERT(date,getdate())<=  CONVERT(date,isnull(FromDate,GETDATE()-5))	" & _
                                                     "or  CONVERT(date,getdate())>= CONVERT(date,isnull(ToDate,GETDATE()+5 )))"
                                End If
                            End If
                            p_Table = GetDataTable(p_SQL, p_SQL)
                            If Not p_Table Is Nothing Then
                                If p_Table.Rows.Count > 0 Then
                                    If p_Table.Rows(0).Item("HoVaTen").ToString.Trim <> "" Then
                                        p_SQL = "UPDATE tbllenhxuate5 set  NguoiVanChuyen =N'" & p_Table.Rows(0).Item("HoVaTen").ToString.Trim & _
                                                    "'  where solenh='" & p_SoLenh & "' and len(isnull(NguoiVanChuyen,'')) =0"

                                        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                                        End If
                                    End If

                                End If
                            End If
                            o_err = "Đồng bộ dữ liệu thành công!"
                            Return True
                        Else
                            o_err = "Lệnh xuất chưa được phép xuất hàng!"
                        End If
                    Else
                        o_err = "Chưa có Storage Location nên không thể đồng bộ lệnh xuất này!"
                    End If
                Else
                    o_err = "Lệnh xuất khác Shipping Point nên không thể xuất hàng!"
                End If
            Else
                o_err = "Lệnh xuất không hợp lệ để thực hiện xuất hàng!"
            End If
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            'Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try


    End Function


    Private Function mdlSyncDeliveries_SynSpecific_QCI(ByRef p_NCC As String, _
                                                        ByRef l_ztb222 As Connect2SapEx.LIPSO2Table, _
                                                        ByVal p_SapConnectionString As String,
                                                        ByVal p_User_ID As Integer, ByVal p_Company_Code As String, _
                                                      ByVal i_solenh As String, ByRef o_err As String, ByVal p_Time As String) As Boolean
        '  Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_c2sapex As Connect2SapEx.Connect2Sap
        ' Dim l_ztb As Connect2SapEx.Str_PhieuXuatTable
        '  Dim l_ztb2 As Connect2SapEx.LIPSO2Table
        Dim l_ret2 As Connect2SapEx.BAPIRET2


        Dim l_err As String
        Dim l_f As Boolean = False

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        Dim p_TimeOut = New TimeSpan()




        Try

            mdlSyncDeliveries_SynSpecific_QCI = True
            l_c2sapex = New Connect2SapEx.Connect2Sap(p_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            ' l_ztb = New Connect2SapEx.Str_PhieuXuatTable()

            '            l_ztb2 = New Connect2SapEx.LIPSO2Table

            ' l_ztb As Connect2SapEx.LIPSO2Table
            l_err = String.Empty




            'anhqh
            '20160927
            'Them doan check tin dung
            '    Try
            Dim l_check As String
            l_check = String.Empty
            If p_Time = "25" Then
                l_c2sapex.CheckCredit(i_solenh, l_check, l_ret2)
            Else
                l_async = l_c2sapex.BeginCheckCredit(i_solenh, Nothing, l_c2sapex)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_Time, False)
                If l_isCompleted Then
                    l_c2sapex.EndCheckCredit(l_async, l_check, l_ret2)
                End If
            End If
            'Select Case l_check.Trim.ToUpper()
            '    Case "E"
            '        ' = "m117"
            '        'Return False
            '    Case "C"
            '        If p_KiemTraHanMuc = True Then
            '            o_err = "Lệnh xuất đã vượt quá hạn mức tín dụng"
            '            'o_err = "m220"
            '            Return False
            '        End If

            '    Case "B"
            '        If p_KiemTraHanMuc = True Then
            '            'o_err = "m220"
            '            o_err = "Lệnh xuất đã vượt quá hạn mức tín dụng"
            '            Return False
            '        End If
            '    Case "Q"
            '        'o_err = "m219"
            '        'Return False
            '        o_err = "Lệnh xuất chưa được gán TD!"
            '        Return False

            '    Case Else
            'End Select


            Select Case l_check.Trim.ToUpper()
                Case "E"
                    ' = "m117"
                    'Return False
                Case "C"
                    If p_KiemTraHanMuc = True Then
                        o_err = "Lệnh xuất đã vượt quá hạn mức tín dụng"
                        'o_err = "m220"
                        Return False
                    End If

                Case "B"
                    If p_KiemTraHanMuc = True Then
                        o_err = "Lệnh xuất đã vượt quá hạn mức tín dụng"
                        Return False
                    End If
                    'o_err = "m220"

                Case "Q"
                    'o_err = "m219"
                    'Return False
                    If p_KIEMTRA_TD = True Then
                        o_err = "Lệnh xuất chưa được gán TD hoặc DischargePoint!"
                        Return False
                    End If

                Case Else
            End Select

            If p_Time = "25" Then
                ' l_c2sapex.(i_solenh, l_ztb, l_ret2)
                l_c2sapex.Select_LXQCI(i_solenh, p_NCC, l_ztb222, l_ret2)
            Else
                'l_async = l_c2sap.BeginGetPhieuXuat_Specific(i_solenh, l_ztb, Nothing, l_c2sap)
                l_async = l_c2sapex.BeginSelect_LXQCI(i_solenh, l_ztb222, Nothing, l_c2sapex)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    '=============================Hoi lai VinhND cho nay
                    l_c2sapex.EndSelect_LXQCI(l_async, p_NCC, l_ztb222, l_ret2)
                End If
            End If
            'Catch ex As Exception
            '    o_err = ex.Message
            '    Return False
            'End Try


        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try


    End Function


    'FES KV2
    '20141016
    Private Function mdlSyncDeliveries_CheckStartTime(ByVal i_date As String) As Boolean
        Dim l_date_start As Date
        Dim l_date_now As Date
        Dim p_Time As Integer
        Dim l_date, _
            l_month, _
            l_year As String

        If i_date = String.Empty Then
            Return True
        End If

        Try
            l_date_now = Date.Now

            p_GetDateTime(l_date_now, p_Time)

            l_date = i_date.Substring(i_date.Length - 2, 2)
            l_month = i_date.Substring(i_date.Length - 4, 2)
            l_year = i_date.Substring(0, 4)

            If Convert.ToInt32(l_date) = 0 Or _
               Convert.ToInt32(l_month) = 0 Or _
               Convert.ToInt32(l_year) = 0 Then
                Return True
                'Return False
            End If

            l_date_start = New Date(l_year, l_month, l_date)

            If l_date_start.Date > l_date_now.Date Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function mdlSyncDeliveries_CheckEndTime(ByVal i_date As String) As Boolean
        Dim l_date_end As Date
        Dim l_date_now As Date
        Dim p_Time As Integer

        Dim l_date, _
            l_month, _
            l_year As String

        If i_date = String.Empty Then
            Return True
        End If

        Try
            l_date_now = Date.Now

            p_GetDateTime(l_date_now, p_Time)

            l_date = i_date.Substring(i_date.Length - 2, 2)
            l_month = i_date.Substring(i_date.Length - 4, 2)
            l_year = i_date.Substring(0, 4)

            If Convert.ToInt32(l_date) = 0 Or _
               Convert.ToInt32(l_month) = 0 Or _
               Convert.ToInt32(l_year) = 0 Then
                Return True
                'Return False
            End If

            l_date_end = New Date(l_year, l_month, l_date)

            If l_date_end.Date < l_date_now.Date Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Sub SetHangHoaComParment(ByVal i_lt_temp As Connect2SAP.Str_PhieuXuatTable, ByRef p_TblHangHoa As DataTable)
        Dim p_Count As Integer
        Dim p_Count1 As Integer
        Dim p_Row As DataRow
        Dim p_Total As Double

        If p_TblHangHoa Is Nothing Then
            Exit Sub
        End If

        If p_TblHangHoa.Rows.Count <= 0 Then
            Exit Sub
        End If


        'anhqh
        '20161010
        If p_QUYDOI_SAP = "Y" Then
            Exit Sub
        End If


        For p_Count = 0 To p_TblHangHoa.Rows.Count - 1
            p_Row = p_TblHangHoa.Rows(p_Count)
            p_Total = 0
            If p_Row.Item("LineID").ToString.Trim <> "" Then
                For p_Count1 = 0 To i_lt_temp.Count - 1
                    If p_Row.Item("LineID").ToString.Trim = i_lt_temp(p_Count1).Item_Nd Then
                        p_Total = p_Total + i_lt_temp(p_Count1).Quantity
                    End If
                Next
            End If
            If p_Total > 0 Then
                p_TblHangHoa.Rows(p_Count).Item("TongXuat") = p_Total
                p_TblHangHoa.Rows(p_Count).Item("TongDuXuat") = p_Total
            End If
        Next

    End Sub


    Public Function GetDiemTraHang(ByVal p_ChuyenVanTai As String, ByVal p_SapConnectionString As String,
                                        ByVal p_dtVariable As DataTable, ByVal p_TimeOut As TimeSpan) As String
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb As Connect2SapEx.STR_DischardTable
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        Dim l_err As String = String.Empty
        Dim l_dem As Integer = 0

        ' Dim p_TimeOut = New TimeSpan()


        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy điểm trả hàng
            '----------------------------------------------------------------------------------------------
            l_c2sap = New Connect2SapEx.Connect2Sap(p_SapConnectionString)
            l_ztb = New Connect2SapEx.STR_DischardTable()
            l_ret2 = New Connect2SapEx.BAPIRET2()

            l_c2sap.Connection.Open()

            If p_dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetDischard(p_ChuyenVanTai, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetDischard(p_ChuyenVanTai, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetDischard(l_async, l_ztb, l_ret2)
                End If
            End If
            '----------------------------------------------------------------------------------------------
            '   Đóng kết nối với SAP
            '----------------------------------------------------------------------------------------------
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            '----------------------------------------------------------------------------------------------
            '   Kiểm tra dữ liệu đầu ra
            '----------------------------------------------------------------------------------------------

            If l_ztb.Count <= 0 Then
                Return ""
            End If

            '----------------------------------------------------------------------------------------------
            '   Phân tích điểm trả hàng
            '----------------------------------------------------------------------------------------------
            Dim l_routename As String
            Dim p_Tmp As String = ""
            Dim l_dischard As String()
            l_routename = l_ztb.Item(0).Routename.ToString()
            l_dischard = l_routename.Split("-")


            'If l_dischard Is Nothing Then
            '    Return String.Empty
            'End If
            'If g_KV1 = True Then
            '    Return l_dischard(l_dischard.Length - 1).Trim()
            'Else
            If l_dischard.Length > 1 Then
                p_Tmp = Replace(l_routename, l_dischard(0).Trim(), "") ' l_dischard(1).Trim()
                If Strings.Left(p_Tmp, 1) = "-" Then
                    p_Tmp = Mid(p_Tmp, 2)
                End If
                Return p_Tmp
            End If
            'End If

            'Return l_dischard(l_dischard.Length - 1).Trim()
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function



    'anhqh
    '20170725
    'Dong bo rieng phuong tien
    Public Function mdlSyncMaster_SyncVehicleDown1(ByVal i_vehicle As String, ByRef p_Count As Integer, ByRef p_Desc As String) As Boolean
        Dim l_c2sap As Connect2SAP.Connect2SAP
        Dim l_ztb As Connect2SAP.Str_ChiTietPhuongTienTable
        Dim l_ret2 As Connect2SAP.BAPIRET2
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String

        Dim p_Row As DataRow
        Dim p_DataTablExe As New System.Data.DataTable("Table0")

        Dim l_err As String = String.Empty
        Dim l_dem As Integer
        Dim p_dtVariable As DataTable
        Dim p_SapConnectionString As String
        Dim p_TimeOut As New TimeSpan()

        Try
            '----------------------------------------------------------------------------------------------
            '   Lấy các dữ liệu phương tiện từ SAP
            ''----------------------------------------------------------------------------------------------
            'If g_WcfE5 = True Then

            '    mdlSyncMaster_SyncVehicleDown1 = g_Services.ClsSyncMaster_SyncVehicleDownNew(_SapConnectionString, _
            '                                     _dtVariable, _
            '                                     _ShPoint, _
            '                                         _WareHouse, _
            '                                         _TimeOut, _
            '                                         i_vehicle, p_Count, p_Desc)

            '    Exit Function
            'End If


            p_SQL = "Select * from tblconfig"
            p_dtVariable = GetDataTable(p_SQL, p_SQL)

            p_SapConnectionString = p_dtVariable.Rows(0).Item("sapconnectionstring").ToString.Trim

            p_DataTablExe.Columns.Add("STR_SQL")
            l_c2sap = New Connect2SAP.Connect2SAP(p_SapConnectionString)
            l_ztb = New Connect2SAP.Str_ChiTietPhuongTienTable()
            l_ret2 = New Connect2SAP.BAPIRET2()

            l_c2sap.Connection.Open()





            If p_dtVariable.Rows(0).Item("TimeOut").ToString() = "25" Then
                l_c2sap.GetChiTietPhuongTien(String.Empty, String.Empty, i_vehicle.ToUpper(), l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetChiTietPhuongTien(i_vehicle.ToUpper(), String.Empty, String.Empty, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetChiTietPhuongTien(l_async, l_ztb, l_ret2)
                End If
            End If

            p_Count = 0
            '----------------------------------------------------------------------------------------------
            '   Đưa dữ liệu vào hệ thống SQL
            '----------------------------------------------------------------------------------------------
            l_dem = 0
            l_dem = l_ztb.Count
            p_Count = l_ztb.Count
            If l_ztb.Count > 0 Then
                'l_bs_details = New BSVehicleDetail()

                ' For i As Integer = 0 To l_ztb.Count - 1
                p_SQL = "MERGE tblPhuongtien AS target " & _
                    " USING (SELECT N'" & Replace(l_ztb.Item(0).Mapt.ToString(), "'", "", 1) & "' as MaPhuongTien ," & _
                             "N'" & Replace(l_ztb.Item(0).Loaipt.ToString(), "'", "", 1) & "'  as LaiXe," & _
                             "" & Convert.ToInt32(l_dem) & "  as SoNgan ," & _
                             "'" & Replace(l_ztb.Item(0).Ngaybatdau.ToString(), "'", "", 1) & "'  as Ngaybatdau, " & _
                             "'" & Replace(l_ztb.Item(0).Ngayketthuc.ToString(), "'", "", 1) & "'  as NgayHieuLuc, " & _
                            "'S' as Status) AS source (MaPhuongTien, LaiXe, SoNgan, Ngaybatdau, NgayHieuLuc, Status) " & _
                            " ON (target.MaPhuongTien = source.MaPhuongTien) " & _
                        " WHEN MATCHED  THEN UPDATE SET " & _
                                "LaiXe=source.LaiXe " & _
                                ",SoNgan=source.SoNgan " & _
                                ",Ngaybatdau=source.Ngaybatdau " & _
                                ",NgayHieuLuc=source.NgayHieuLuc " & _
                                ",Status=source.Status " & _
                     " WHEN NOT MATCHED THEN " & _
                        "INSERT  (MaPhuongTien, LaiXe, SoNgan, Ngaybatdau, NgayHieuLuc, Status) " & _
                            "VALUES (source.MaPhuongTien,source.LaiXe,source.SoNgan,source.NgayHieuLuc,source.NgayHieuLuc,source.Status ) ;"
                'p_SQL = Replace(p_SQL, "''", "'", 1)
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)


                p_SQL = "DELETE FROM tblChiTietPhuongtien where MaPhuongTien='" & Replace(l_ztb.Item(0).Mapt.ToString(), "'", "", 1) & "'"
                p_Row = p_DataTablExe.NewRow
                p_Row.Item(0) = p_SQL
                p_DataTablExe.Rows.Add(p_Row)
                'l_dem = l_dem + 1

                For i As Integer = 0 To l_ztb.Count - 1
                    ' l_bs = New BSVehicleDetail()
                    l_err = String.Empty
                    ' l_mahh = String.Empty
                    p_SQL = "MERGE tblChiTietPhuongtien AS target " & _
                                           " USING (SELECT '" & Replace(l_ztb.Item(i).Mangan.ToString(), "'", "", 1) & "' as MaNgan," & _
                                                    "'" & Replace(l_ztb.Item(i).Mapt.ToString(), "'", "", 1) & "' as MaPhuongTien," & _
                                                    "" & Convert.ToDecimal(l_ztb.Item(i).Max_Nd.ToString()) & " as SoLuongMax," & _
                                                   "'S' as Status) AS source (MaNgan, MaPhuongTien, SoLuongMax, Status) " & _
                                                   " ON (target.MaPhuongTien = source.MaPhuongTien and target.MaNgan = source.MaNgan) " & _
                                               " WHEN MATCHED  THEN UPDATE SET " & _
                                                       "SoLuongMax=source.SoLuongMax " & _
                                                       ",Status=source.Status " & _
                                            " WHEN NOT MATCHED THEN " & _
                                               "INSERT  (MaNgan, MaPhuongTien, SoLuongMax, Status) " & _
                                                   "VALUES (source.MaNgan,source.MaPhuongTien,source.SoLuongMax,source.Status );"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next

                ' Next

                If p_DataTablExe.Rows.Count > 0 Then
                    If g_Services.Sys_Execute_DataTableNew(p_DataTablExe, _
                                          p_SQL) = False Then
                        p_Desc = p_SQL
                        Return False
                    End If
                End If
            End If

            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True
        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try
    End Function


    'anhqh
    '20161012
    'Ham kiem tra luong dat va dung tich ngan va Ngan cos khớp không, nếu không thì reser lại theo ngăn
    Private Sub mdlKiemTraNganVaLuongDat(ByRef i_lt_temp As Connect2SAP.Str_PhieuXuatTable, _
                                            ByVal p_MaPhuongTien As String, _
                                            ByRef p_TableHangHoa As DataTable, _
                                            ByRef p_Change As Boolean, ByRef p_Error As Boolean, ByRef p_DEsc As String)
        Dim p_Count As Integer
        Dim p_HangHoa As String
        Dim p_DungTichNgan As Integer
        Dim p_TblPhuongTien As DataTable
        Dim p_ArrRow() As DataRow
        Dim p_SQL As String
        '  Dim p_Desc As String
        Dim p_STT As Integer
        Dim p_NganHH As String = ""
        Dim p_STT1 As Integer = 0
        Dim p_Tmp As Integer

        Dim p_FO As String = ""
        Dim p_QuanFO, p_DungTichFO As Integer

        Dim p_SaleQuantity As Integer
        '  Dim p_DungTichNgan As Integer
        Dim p_Reload As Boolean = False

        If i_lt_temp.Count <= 0 Then
            Exit Sub
        End If
        p_Change = False

        p_Error = False

        'i_lt_temp(p_Count).Quantity   Lượng theo ngăn phương tiện
        'i_lt_temp(p_Count).Salequantity   Lượng theo DO

        p_SQL = "select * from tblChiTietPhuongTien where MaPhuongTien='" & p_MaPhuongTien & "'"
        p_TblPhuongTien = GetDataTable(p_SQL, p_SQL)
        If p_TblPhuongTien Is Nothing Then
            Exit Sub
        End If
        For p_Count = 0 To i_lt_temp.Count - 1
            p_SaleQuantity = 0
            'p_SaleQuantity = i_lt_temp(p_Count).Salequantity
            p_SaleQuantity = i_lt_temp(p_Count).Quantity
            p_NganHH = i_lt_temp(p_Count).Compartment

            p_ArrRow = p_TblPhuongTien.Select("MaNgan='" & p_NganHH & "' AND SoLuongMax=" & p_SaleQuantity)
            If p_ArrRow.Length <= 0 Then
                p_Reload = True
                Exit For

            End If

        Next

        If p_Reload = True Then
            If mdlSyncMaster_SyncVehicleDown1(p_MaPhuongTien, p_STT, p_DEsc) = False Then
            End If
            If p_STT = 0 Then
                ' Continue For
            End If
        End If

        p_SQL = "select * from tblChiTietPhuongTien where MaPhuongTien='" & p_MaPhuongTien & "'"
        p_TblPhuongTien = GetDataTable(p_SQL, p_SQL)
        If p_TblPhuongTien Is Nothing Then
            Exit Sub
        End If
        p_SaleQuantity = 0

        p_QuanFO = 0
        p_DungTichFO = 0


        'Kiem tra tong luong theo ngan phai <= luong dat trong DO
        For p_Count = 0 To i_lt_temp.Count - 1
            p_NganHH = i_lt_temp(p_Count).Compartment
            'p_SaleQuantity = i_lt_temp(p_Count).Salequantity


            p_SaleQuantity = p_SaleQuantity + i_lt_temp(p_Count).Quantity

            p_ArrRow = p_TblPhuongTien.Select("MaNgan='" & p_NganHH & "'")
            If Left(Right(i_lt_temp(p_Count).Material, 7), 2) = "07" Then
                p_QuanFO = p_QuanFO + i_lt_temp(p_Count).Quantity
                p_FO = "07"
            End If

            'p_SaleQuantity=
            If p_ArrRow.Length > 0 Then
                Integer.TryParse(p_ArrRow(0).Item("SoLuongMax").ToString.Trim, p_Tmp)

                If Left(Right(i_lt_temp(p_Count).Material, 7), 2) = "07" Then
                    p_DungTichFO = p_DungTichFO + p_Tmp

                End If
                p_DungTichNgan = p_DungTichNgan + p_Tmp
            Else
                If p_TblPhuongTien.Rows.Count = 1 Then
                    Integer.TryParse(p_TblPhuongTien.Rows(0).Item("SoLuongMax").ToString.Trim, p_Tmp)

                    If Left(Right(i_lt_temp(p_Count).Material, 7), 2) = "07" Then
                        p_DungTichFO = p_DungTichFO + p_Tmp

                    End If
                    p_DungTichNgan = p_DungTichNgan + p_Tmp
                End If
            End If
        Next
        If p_FO.ToString.Trim = "07" Then
            If p_DungTichFO <> p_QuanFO Then
                p_DEsc = "Lượng đặt hàng FO khác dung tích ngăn của phương tiện"
                p_Error = True
                Exit Sub
            End If
        End If
        If p_SaleQuantity < p_DungTichNgan Then
            p_DEsc = "Lượng đặt hàng nhỏ hơn dung tích ngăn của phương tiện"
            p_Error = True
            Exit Sub
        End If

        For p_Count = 0 To i_lt_temp.Count - 1
            p_NganHH = i_lt_temp(p_Count).Compartment
            p_SaleQuantity = i_lt_temp(p_Count).Quantity
            p_ArrRow = p_TblPhuongTien.Select("MaNgan='" & p_NganHH & "'")
            'p_SaleQuantity=
            If p_ArrRow.Length > 0 Then
                Integer.TryParse(p_ArrRow(0).Item("SoLuongMax").ToString.Trim, p_DungTichNgan)
                '  If p_DungTichNgan <= p_SaleQuantity Or p_LoaiVanChuyen.ToString.Trim <> "BO" Then

                i_lt_temp(p_Count).Quantity = p_DungTichNgan
                'End If
            End If
        Next

    End Sub

    Private Function mdlSyncDeliveries_SubModifyFromTable_new(ByVal p_Client As String, _
                                                                ByVal p_SapConnectionString As String, ByVal i_lt_temp As Connect2SAP.Str_PhieuXuatTable,
                                                              ByRef p_desc As String, ByVal p_DiemTraHang As String, _
                                                              Optional ByVal p_Ngay_ND As Boolean = False) As Boolean

        '-----------------------------------------------------------------
        'Các Bussiness
        '-----------------------------------------------------------------
        ' Dim l_bs_Header As BSTransaction_new
        'Dim l_bs_Detail As BSTransactionDetail_new

        '-----------------------------------------------------------------
        'Work Area
        '-----------------------------------------------------------------
        Dim l_wa As Connect2SAP.Str_PhieuXuat = New Connect2SAP.Str_PhieuXuat()

        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat        
        '-----------------------------------------------------------------
        Dim l_malenh, _
            l_solenh, _
            l_loaiphieu, _
            l_status _
            As String

        Dim l_ngayxuat _
            As String

        Dim l_sql, _
            l_err As String

        Dim l_dt_transaction As DataTable
        Dim p_Date As Date
        Dim p_Time As Integer

        Dim p_MaLoaiHinh As String
        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat_HangHoa
        '   Key:
        '       MaLenh
        '       NgayXuat
        '       SoLenh      - phục vụ tìm kiếm nhanh
        '-----------------------------------------------------------------
        Dim l_lineid _
            As String

        Dim l_tongxuat, _
            l_tongduxuat _
            As Decimal

        Dim l_date, _
            l_month, _
            l_year _
            As Integer
        Dim p_DateTime As String
        Dim l_count As Integer = 0



        Dim p_DataExec As New DataTable("Table001")
        p_DataExec.Columns.Add("STR_SQL")

        Dim p_DataExecLine As New DataTable("Table002")
        p_DataExecLine.Columns.Add("STR_SQL")

        Dim p_DataRow As DataRow
        Dim p_Count As Integer
        Dim l_ztb2 As Connect2SapEx.LIPSO2Table = New Connect2SapEx.LIPSO2Table()
        Dim p_NCC As String = ""
        Dim p_MaVanChuyen As String = ""

        Dim p_TuDongHoa As Boolean = False
        Dim p_table As DataTable
        Dim p_MaTDH As Integer
        Dim p_SQL As String
        Dim p_DUXUAT_TD As Boolean = False
        Dim p_LOAIHINH_VT As Boolean = False
        Dim p_ChietKhau As Decimal
        Dim p_TabChietKhau As DataTable
        Dim p_RowArr2() As DataRow

        Dim p_Array() As DataRow

        g_Terminal = p_Client

        l_sql = "select KEYCODE, KEYVALUE from SYS_CONFIG "
        p_table = GetDataTable(l_sql, l_err)
        If Not p_table Is Nothing Then
            If p_table.Rows.Count > 0 Then
                'If p_table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                '    p_TuDongHoa = True
                'End If
                p_TuDongHoa = False
                p_Array = p_table.Select("KEYCODE='MATUDONGHOA'")
                If p_Array.Length > 0 Then
                    If p_Array(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_TuDongHoa = True
                    End If
                End If

                p_DUXUAT_TD = False
                p_Array = p_table.Select("KEYCODE='DUXUAT_TD'")
                If p_Array.Length > 0 Then
                    If p_Array(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_DUXUAT_TD = True
                    End If
                End If

                p_LOAIHINH_VT = False
                p_Array = p_table.Select("KEYCODE='LOAIHINH_VT'")
                If p_Array.Length > 0 Then
                    If p_Array(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_LOAIHINH_VT = True
                    End If
                End If


                p_ThamSoNgay = False
                p_Array = p_table.Select("KEYCODE='THAMSONGAY'")
                If p_Array.Length > 0 Then
                    If p_Array(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_ThamSoNgay = True
                    End If
                End If

            End If
        End If

        If p_ThamSoNgay = True Or p_Ngay_ND = True Then
            ' p_Date = i_lt_temp.Item(0).Date_Nd.ToString()
            l_date = i_lt_temp.Item(0).Date_Nd.ToString().Substring(6, 2)
            l_month = i_lt_temp.Item(0).Date_Nd.ToString().Substring(4, 2)
            l_year = i_lt_temp.Item(0).Date_Nd.ToString().Substring(0, 4)
            p_Date = CDate(l_month & "/" & l_date & "/" & l_year)
        Else
            p_GetDateTime(p_Date, p_Time)
        End If


        p_DateTime = CDate(p_Date).ToString("dd/MM/yyyy")
        '-----------------------------------------------------------------
        '   Kiểm tra số lệnh đã tồn tại trong hệ thống hay chưa?
        '   Kiểm tra trạng thái của lệnh đó
        '-----------------------------------------------------------------
        '   l_bs_Header = New BSTransaction_new()
        l_sql = "select Solenh, Status from tblLenhXuatE5 with (Nolock)   where SoLenh = '" & i_lt_temp.Item(0).Outbound.ToString() & "'"
        l_err = String.Empty
        l_status = String.Empty
        l_dt_transaction = GetDataTable(l_sql, l_err)
        If l_dt_transaction IsNot Nothing Then
            If l_dt_transaction.Rows.Count > 0 Then
                l_status = l_dt_transaction.Rows(0).Item("Status").ToString()
            End If
        Else
            l_status = String.Empty
        End If

        Select Case l_status.Trim()
            Case String.Empty
            Case "1"
            Case "2"
                'Case "3"
                'Case "31"
                'Case "4"
                'Case "5"
                'Case "X"
            Case Else
                Return False
        End Select
        '-----------------------------------------------------------------

        '-----------------------------------------------------------------
        'Đặt mã mới theo ngày                        
        '-----------------------------------------------------------------
        l_solenh = i_lt_temp.Item(0).Outbound.ToString()

        l_date = p_DateTime.Substring(0, 2)
        l_month = p_DateTime.Substring(3, 2)
        l_year = p_DateTime.Substring(6, 4)

        'anhqh
        '20160920
        If g_KV1 = True Then
            'i_lt_temp(0).Date_Nd
            l_date = i_lt_temp(0).Date_Nd.Substring(6, 2)
            l_month = i_lt_temp(0).Date_Nd.Substring(4, 2)
            l_year = i_lt_temp(0).Date_Nd.Substring(0, 4)
            l_ngayxuat = New DateTime(l_year, l_month, l_date)
        Else
            l_ngayxuat = New DateTime(l_year, l_month, l_date)
        End If

        l_loaiphieu = i_lt_temp.Item(0).Shnumber.ToString()
        If l_loaiphieu = String.Empty Then
            l_loaiphieu = "V144"
        End If


        l_status = i_lt_temp.Item(0).Status.ToString()
        'l_malenh = l_bs_Header.SelectMaLenh(l_err, l_ngayxuat)

        Dim p_Dem As Integer = 0
TaoMaLenh:

        If g_KV1 = True Then
            l_malenh = KV1_FPT_GetMaLenh(l_solenh, l_ngayxuat)
        Else
            l_malenh = FPT_GetMaLenh(l_solenh)
        End If
        ' l_malenh = FPT_GetMaLenh(l_solenh)


        '-----------------------------------------------------------------
        '   Kiểm tra mã lệnh sau khi tính toán
        '-----------------------------------------------------------------


        'anhqh
        '20160715
        'Sua lai nếu trùng mã lệnh  thì xóa trong bảng SYS_MALENH_S roi tạo lai
        If Not mdlSyncDeliveries_CheckMaLenh(l_malenh, l_ngayxuat) Then

            If p_Dem >= 3 Then
                p_desc = "Trùng Mã Lệnh=" & l_malenh
                Return False
            End If


            p_SQL = ""

            p_SQL = "delete  from SYS_MALENH_S where  SoLenh='" & l_solenh & "'"

            If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

            End If

            p_Dem = p_Dem + 1

            GoTo taomalenh
        End If
        '-----------------------------------hXuat------------------------------

        '-----------------------------------------------------------------
        '   1. Nếu (2) thành công thì Insert dữ liệu vào bảng tblLenhXuat
        '
        '   2. Insert dữ liệu vào bảng tblLenhXuatChiTiet (có TR)                       
        '
        '   3. Insert dữ liệu vào tblLenhXuat_HangHoa
        '
        '-----------------------------------------------------------------
        '-----------------------------------------------------------------
        '   1. Insert dữ liệu vào bảng tblLenhXuat
        '-----------------------------------------------------------------
        'anhqh
        '20160918
        'Them lay loai hinh van tai theo ptien
        Dim p_MaPhuongTien As String
        If p_LOAIHINH_VT = True Then

            Try
                If i_lt_temp(p_Count).Transmot.ToString.Trim = "" Then
                    ' i_lt_temp(p_Count).Transmot
                    'anhqh
                    '20190606
                    'them neu SAP k xasc dinh laoi hinh van tai thi kiem tra va tu dong gan
                    i_lt_temp(p_Count).Transmot = "ZT"
                    For p_Count = 0 To i_lt_temp.Count - 1
                        If i_lt_temp(p_Count).Transmot.ToString.Trim = "" Then
                            p_MaPhuongTien = i_lt_temp(p_Count).Vehicle.ToString.Trim
                            p_SQL = "select LEFT(LaiXe,2) as LaiXe from tblPhuongTien with (nolock)  where   upper(MaPhuongTien)='" & UCase(p_MaPhuongTien) & "'"
                            p_table = GetDataTable(p_SQL, p_SQL)
                            If Not p_table Is Nothing Then
                                If p_table.Rows.Count > 0 Then
                                    p_SQL = ""
                                    p_SQL = p_table.Rows(0).Item(0).ToString.Trim
                                    i_lt_temp(p_Count).Transmot = p_SQL
                                End If
                            End If
                        End If
                    Next
                End If
            Catch ex As Exception

            End Try

        End If




        l_wa = i_lt_temp.Item(0)
        ' l_bs_Header = New BSTransaction_new()

        If Not mdlSyncDeliveries_SubModifyFromWorkArea(p_Client, p_DataExec, l_wa, l_malenh, l_ngayxuat, g_Company_Code, p_desc, p_DiemTraHang) Then
            Return False
        End If
        If p_DataExec.Rows.Count > 0 Then
            p_DataRow = p_DataExec.NewRow
            p_DataRow.Item(0) = "DELETE FROM tblLenhXuat_HangHoaE5 where SoLenh='" & l_wa.Outbound.ToString() & "'"
            p_DataExec.Rows.Add(p_DataRow)
        End If


        ''Lay QCI 20160326 va kiem tra lay so dat hang hay so quy doi

        If mdlSyncDeliveries_SynSpecific_QCI(p_NCC, l_ztb2, p_SapConnectionString, g_User_ID, g_Company_Code, _
                                   l_wa.Outbound.ToString(), p_desc, 25) = False Then
            p_desc = p_desc
            Return False
        End If

        'NhaCungCap

        If p_DataExec.Rows.Count > 0 Then
            p_DataRow = p_DataExec.NewRow
            p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set NhaCungCap='" & p_NCC & "' where SoLenh='" & l_wa.Outbound.ToString() & "'"
            p_DataExec.Rows.Add(p_DataRow)
        End If


        '-----------------------------------------------------------------
        '   3. Insert dữ liệu vào tblLenhXuat_HangHoa
        '-----------------------------------------------------------------
        l_count = 0
        l_wa = i_lt_temp.Item(0)
        l_lineid = i_lt_temp.Item(0).Item_Nd.ToString()


        Dim p_TableHangHoa As New DataTable
        Dim p_TableChiaNgan As New DataTable
        ' Dim p_SQL As String
        Dim p_dt_vehicle As DataTable

        p_SQL = "select MaNgan, SoLuongMax, 'X' as [Select] from FPT_tblChiTietPhuongTien_V where MaPhuongTien ='" & l_wa.Vehicle & "' ORDER By MaNgan"
        p_dt_vehicle = GetDataTable(p_SQL, p_SQL)

        'Dim p_Row As System.Data.DataRow
        p_SQL = "select TableID, MaHangHoa, TenHangHoa,DonViTinh,TongDuXuat,TongXuat, MeterID, BeXuat, SoLenh,MaLenh," & _
               "NgayXuat,LineID  from FPT_tblLenhXuat_hanghoaE5_v where solenh='" & l_wa.Order_No & "'"
        p_TableHangHoa = GetDataTable(p_SQL, p_SQL)
        p_TableHangHoa.Columns.Add("NhietDo")
        p_TableHangHoa.Columns.Add("TaiTrong")
        p_TableHangHoa.Columns.Add("TyTrong")
        ' p_TableHangHoa.Columns.Add("ChietKhau", GetType(Decimal))

        p_TableHangHoa.Clear()
        Dim p_LibCustom As New LibCustom.Class1(g_Services)
        Dim p_PhuongTien As String = ""
        p_PhuongTien = l_wa.Vehicle
        ' p_LibCustom.clsLoadDefault(p_PhuongTien, p_TableHangHoa, p_TableChiaNgan)

        'anhqh
        '20200409
        'Ham lay thong tin Chiet khau

        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_ConnectSapString As String = ""
        Dim p_TimeOut As String = ""
        'anhqh
        '20191101
        'Lay thong tin DO1 neu co
        p_SQL = "select * from tblConfig "
        'SapConnectionString, Timeout
        p_table = GetDataTable(p_SQL, p_SQL)
        If Not p_table Is Nothing Then
            If p_table.Rows.Count > 0 Then
                p_ConnectSapString = p_table.Rows(0).Item("SapConnectionString").ToString.Trim
                Try
                    p_TimeOut = p_table.Rows(0).Item("Timeout").ToString.Trim
                Catch ex As Exception

                End Try
                If p_TimeOut = "" Then
                    p_TimeOut = "60"
                End If
            End If
        End If

        p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
        p_TabChietKhau = p_ECCDestinationConfig.clsGet_DO3_Infor(l_solenh, p_SQL)

        p_SQL = ""
        If g_KV1 = False Then


            For i As Integer = 0 To i_lt_temp.Count - 1


                If l_wa.Item_Nd.ToString() <> i_lt_temp.Item(i).Item_Nd.ToString() Then
                    l_tongxuat = 0
                    l_tongduxuat = 0
                    'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
                    p_DataExecLine.Clear()

                    p_ChietKhau = 0
                    If Not p_TabChietKhau Is Nothing Then
                        If p_TabChietKhau.Rows.Count > 0 Then
                            p_RowArr2 = p_TabChietKhau.Select("ParName='" & l_wa.Item_Nd.ToString() & "'")
                            If p_RowArr2.Length > 0 Then
                                'p_ChietKhau =
                                Decimal.TryParse(p_RowArr2(0).Item(1).ToString.Trim, p_ChietKhau)
                                p_ChietKhau = Math.Abs(p_ChietKhau)
                            End If
                        End If
                    End If

                    'anhqh 20160530================================
                    If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, _
                                                                            l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa, p_ChietKhau) Then
                        l_count = l_count + 1
                    End If


                    l_wa = i_lt_temp.Item(i)
                    If p_DataExecLine.Rows.Count > 0 Then
                        p_DataExec.Merge(p_DataExecLine)
                    End If
                End If

                If i = i_lt_temp.Count - 1 Then
                    l_tongxuat = 0
                    l_tongduxuat = 0
                    'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
                    p_DataExecLine.Clear()
                    'If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine(p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty) Then
                    '    l_count = l_count + 1
                    'End If
                    p_ChietKhau = 0
                    If Not p_TabChietKhau Is Nothing Then
                        If p_TabChietKhau.Rows.Count > 0 Then
                            p_RowArr2 = p_TabChietKhau.Select("ParName='" & l_wa.Item_Nd.ToString() & "'")
                            If p_RowArr2.Length > 0 Then
                                'p_ChietKhau =
                                Decimal.TryParse(p_RowArr2(0).Item(1).ToString.Trim, p_ChietKhau)
                                p_ChietKhau = Math.Abs(p_ChietKhau)
                            End If
                        End If
                    End If

                    'anhqh 20160530================================================
                    If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa, p_ChietKhau) Then
                        l_count = l_count + 1
                    End If
                    If p_DataExecLine.Rows.Count > 0 Then
                        p_DataExec.Merge(p_DataExecLine)
                    End If
                End If

            Next
        Else
            For i As Integer = 0 To i_lt_temp.Count - 1

                If l_wa.Item_Nd.ToString() <> i_lt_temp.Item(i).Item_Nd.ToString() Then
                    l_tongxuat = 0
                    l_tongduxuat = 0
                    'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
                    p_DataExecLine.Clear()


                    'If g_KV1 = True Then
                    '    'anhqh 20160530================================
                    '    If Not KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, _
                    '                                                            l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa) Then
                    '        l_count = l_count + 1
                    '    End If

                    '    KV1_GenScriptfromTbl(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, _
                    '                                                   l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa)
                    'Else
                    'anhqh 20160530================================
                    If Not KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, _
                                                                            l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa) Then
                        l_count = l_count + 1
                    End If

                    '   End If


                    'If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine(p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty) Then
                    '    l_count = l_count + 1
                    'End If
                    l_wa = i_lt_temp.Item(i)
                    If p_DataExecLine.Rows.Count > 0 Then
                        p_DataExec.Merge(p_DataExecLine)
                    End If
                End If

                If i = i_lt_temp.Count - 1 Then
                    l_tongxuat = 0
                    l_tongduxuat = 0
                    'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
                    p_DataExecLine.Clear()
                    'If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine(p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty) Then
                    '    l_count = l_count + 1
                    'End If

                    'anhqh 20160530================================================
                    If Not KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa) Then
                        l_count = l_count + 1
                    End If
                    If p_DataExecLine.Rows.Count > 0 Then
                        p_DataExec.Merge(p_DataExecLine)
                    End If
                End If

            Next

            KV1_GenScriptfromTbl(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa)
            If p_DataExecLine.Rows.Count > 0 Then
                p_DataExec.Merge(p_DataExecLine)
            End If


        End If
        l_ztb2 = Nothing
        If l_count <> 0 Then
            l_err = String.Empty
            '  l_bs_Header.DeleteTransaction(l_err, l_solenh, l_ngayxuat)
            ' mdlSyncDeliveries_DeleteAllDetails_new(l_solenh)
            Return False
        End If
        If Not p_TableHangHoa Is Nothing Then
            If p_TableHangHoa.Rows.Count > 0 Then
                p_MaVanChuyen = l_wa.Transmot.ToString.Trim

                p_MaVanChuyen = GetLoadingSite(p_MaVanChuyen)
                ''Goi ham lay  Loai xuat

                If p_DUXUAT_TD = True And UCase(p_MaVanChuyen) <> "THUY" Then ' And UCase(p_MaVanChuyen) = "BO" Then
                    Dim p_Change As Boolean
                    Dim p_Error As Integer
                    'Dim p_Desc As String

                    If p_QUYDOI_SAP = "N" Then

                        mdlKiemTraNganVaLuongDat(i_lt_temp, l_wa.Vehicle, p_TableHangHoa, p_Change, p_Error, p_desc)
                        If p_Error = True Then
                            Return False
                        End If
                    End If


                    '  If p_Change = False Then
                    SetHangHoaComParment(i_lt_temp, p_TableHangHoa)

                    p_SQL = "select MaNgan, SoLuongMax, 'X' as [Select] from FPT_tblChiTietPhuongTien_V where MaPhuongTien ='" & l_wa.Vehicle & "' ORDER By MaNgan"
                    p_dt_vehicle = GetDataTable(p_SQL, p_SQL)

                    'End If
                    'SetHangHoaComParment(i_lt_temp, p_TableHangHoa)
                End If


                p_LibCustom.clsLoadDefault(p_dt_vehicle, p_PhuongTien, p_TableHangHoa, p_TableChiaNgan, p_MaVanChuyen)
                If Not p_TableChiaNgan Is Nothing Then
                    If l_loaiphieu <> "V144" Then
                        If p_TableChiaNgan.Rows.Count > 0 Then
                            If SetComparment(p_TableHangHoa, p_dt_vehicle, i_lt_temp, p_TableChiaNgan) = False Then

                            End If

                        End If
                    End If

                    For p_Count = 0 To p_TableChiaNgan.Rows.Count - 1
                        p_DataRow = p_DataExec.NewRow
                        If p_TuDongHoa = True Then
                            If p_ThamSoNgay = True Then
                                p_MaTDH = GetMaTuDongHoa_ND(i_lt_temp.Item(0).Date_Nd.ToString())
                            Else
                                p_MaTDH = GetMaTuDongHoa()
                            End If

                            If p_MaTDH = 0 Then
                                p_desc = "Lỗi khi lấy mã tự đông hóa"
                                Return False
                            End If
                        Else
                            p_MaTDH = 0
                        End If

                        ' GetMaVanChuyen("", p_MaVanChuyen, p_MaVanChuyen)


                        p_SQL = "INSERT INTO tblLenhXuatChiTietE5 (DungTichNgan,MaNgan , MaLenh ,NgayXuat , LineID , SoLuongDuXuat , TableID , MaTuDongHoa )"
                        p_SQL = p_SQL & " VALUES (" & p_TableChiaNgan.Rows(p_Count).Item("DungTichNgan").ToString.Trim & _
                                ",'" & p_TableChiaNgan.Rows(p_Count).Item("MaNgan").ToString.Trim & "'" & _
                                 ",'" & p_TableChiaNgan.Rows(p_Count).Item("MaLenh").ToString.Trim & "'" & _
                                 ",convert(date,'" & CDate(l_ngayxuat).ToString("yyyyMMdd") & "')" & _
                                 ",'" & p_TableChiaNgan.Rows(p_Count).Item("LineID").ToString.Trim & "'" & _
                                 "," & IIf(p_TableChiaNgan.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim = "", 0, p_TableChiaNgan.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim) & "" & _
                                 ",'" & p_TableChiaNgan.Rows(p_Count).Item("TableID").ToString.Trim & "'" & _
                                 ",'" & p_MaTDH & "'" & _
                                ")"
                        p_DataRow.Item(0) = p_SQL
                        p_DataExec.Rows.Add(p_DataRow)

                    Next

                End If
            End If
        End If


        'Dim p_PathXml As String = Application.StartupPath & "\" & l_solenh & ".xml"

        If Not p_DataExec Is Nothing Then
            ' p_DataExec.WriteXml(p_PathXml)

            If g_Services.Sys_Execute_DataTbl(p_DataExec, p_desc) = False Then
                'MsgBox(p_SQL)
                ' g_Module.ModErrExceptionNew("", p_desc)
                Return False
            End If
        End If

        If l_loaiphieu <> "V144" And p_DUXUAT_TD = True Then
            p_DataExec.Clear()
            If p_TableHangHoa.Rows.Count > 0 Then
                For p_Count = 0 To p_TableHangHoa.Rows.Count - 1
                    p_DataRow = p_DataExec.NewRow
                    p_DataRow.Item(0) = "update  tblLenhXuat_HangHoaE5  set TongXuat  =" & IIf(p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim = "", 0, p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim) & ",  " & _
                            " TongDuXuat  =" & IIf(p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim = "", 0, p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim) & " " & _
                            " where TableID='" & p_TableHangHoa.Rows(p_Count).Item("TableID").ToString.Trim & "' " & _
                            " and SoLenh='" & p_TableHangHoa.Rows(p_Count).Item("SoLenh").ToString.Trim & "' "
                    p_DataExec.Rows.Add(p_DataRow)
                Next
            End If
            If p_DataExec.Rows.Count > 0 Then
                If g_Services.Sys_Execute_DataTbl(p_DataExec, p_desc) = False Then
                    'MsgBox(p_SQL)
                    ' g_Module.ModErrExceptionNew("", p_desc)
                    Return False
                End If
            End If
        End If
        Return True
    End Function


    'anhqh 20201202
    'Ham dung cho chuc nang dong bo hang loat tren httg
    Private Function mdlSyncDeliveries_SubModifyFromTable_Auto(ByVal p_Client As String, _
                                                                ByVal p_SapConnectionString As String, ByVal i_lt_temp As Connect2SAP.Str_PhieuXuatTable,
                                                              ByRef p_desc As String, ByVal p_DiemTraHang As String, _
                                                              ByVal p_Date As Date
                                                              ) As Boolean

        '-----------------------------------------------------------------
        'Các Bussiness
        '-----------------------------------------------------------------
        ' Dim l_bs_Header As BSTransaction_new
        'Dim l_bs_Detail As BSTransactionDetail_new

        '-----------------------------------------------------------------
        'Work Area
        '-----------------------------------------------------------------
        Dim l_wa As Connect2SAP.Str_PhieuXuat = New Connect2SAP.Str_PhieuXuat()

        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat        
        '-----------------------------------------------------------------
        Dim l_malenh, _
            l_solenh, _
            l_loaiphieu, _
            l_status _
            As String

        Dim l_ngayxuat _
            As String

        Dim l_sql, _
            l_err As String

        Dim l_dt_transaction As DataTable
        ' Dim p_Date As Date
        Dim p_Time As Integer

        Dim p_MaLoaiHinh As String
        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat_HangHoa
        '   Key:
        '       MaLenh
        '       NgayXuat
        '       SoLenh      - phục vụ tìm kiếm nhanh
        '-----------------------------------------------------------------
        Dim l_lineid _
            As String

        Dim l_tongxuat, _
            l_tongduxuat _
            As Decimal

        Dim l_date, _
            l_month, _
            l_year _
            As Integer
        Dim p_DateTime As String
        Dim l_count As Integer = 0



        Dim p_DataExec As New DataTable("Table001")
        p_DataExec.Columns.Add("STR_SQL")

        Dim p_DataExecLine As New DataTable("Table002")
        p_DataExecLine.Columns.Add("STR_SQL")

        Dim p_DataRow As DataRow
        Dim p_Count As Integer
        Dim l_ztb2 As Connect2SapEx.LIPSO2Table = New Connect2SapEx.LIPSO2Table()
        Dim p_NCC As String = ""
        Dim p_MaVanChuyen As String = ""

        Dim p_TuDongHoa As Boolean = False
        Dim p_table As DataTable
        Dim p_MaTDH As Integer
        Dim p_SQL As String
        Dim p_DUXUAT_TD As Boolean = False
        Dim p_LOAIHINH_VT As Boolean = False
        Dim p_ChietKhau As Decimal
        Dim p_TabChietKhau As DataTable
        Dim p_RowArr2() As DataRow

        Dim p_Array() As DataRow

        g_Terminal = p_Client


        l_sql = "select KEYCODE, KEYVALUE from SYS_CONFIG "
        p_table = GetDataTable(l_sql, l_err)
        If Not p_table Is Nothing Then
            If p_table.Rows.Count > 0 Then
                'If p_table.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                '    p_TuDongHoa = True
                'End If
                p_TuDongHoa = False
                p_Array = p_table.Select("KEYCODE='MATUDONGHOA'")
                If p_Array.Length > 0 Then
                    If p_Array(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_TuDongHoa = True
                    End If
                End If

                p_DUXUAT_TD = False
                p_Array = p_table.Select("KEYCODE='DUXUAT_TD'")
                If p_Array.Length > 0 Then
                    If p_Array(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_DUXUAT_TD = True
                    End If
                End If

                p_LOAIHINH_VT = False
                p_Array = p_table.Select("KEYCODE='LOAIHINH_VT'")
                If p_Array.Length > 0 Then
                    If p_Array(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_LOAIHINH_VT = True
                    End If
                End If


                p_ThamSoNgay = False
                p_Array = p_table.Select("KEYCODE='THAMSONGAY'")
                If p_Array.Length > 0 Then
                    If p_Array(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        p_ThamSoNgay = True
                    End If
                End If

            End If
        End If

        'If p_ThamSoNgay = True Or p_Ngay_ND = True Then
        '    ' p_Date = i_lt_temp.Item(0).Date_Nd.ToString()
        '    l_date = i_lt_temp.Item(0).Date_Nd.ToString().Substring(6, 2)
        '    l_month = i_lt_temp.Item(0).Date_Nd.ToString().Substring(4, 2)
        '    l_year = i_lt_temp.Item(0).Date_Nd.ToString().Substring(0, 4)
        '    p_Date = CDate(l_month & "/" & l_date & "/" & l_year)
        'Else
        '    p_GetDateTime(p_Date, p_Time)
        'End If


        p_DateTime = CDate(p_Date).ToString("dd/MM/yyyy")
        '-----------------------------------------------------------------
        '   Kiểm tra số lệnh đã tồn tại trong hệ thống hay chưa?
        '   Kiểm tra trạng thái của lệnh đó
        '-----------------------------------------------------------------
        '   l_bs_Header = New BSTransaction_new()
        l_sql = "select Solenh, Status from tblLenhXuatE5 with (Nolock)   where SoLenh = '" & i_lt_temp.Item(0).Outbound.ToString() & "'"
        l_err = String.Empty
        l_status = String.Empty
        l_dt_transaction = GetDataTable(l_sql, l_err)
        If l_dt_transaction IsNot Nothing Then
            If l_dt_transaction.Rows.Count > 0 Then
                l_status = l_dt_transaction.Rows(0).Item("Status").ToString()
            End If
        Else
            l_status = String.Empty
        End If

        Select Case l_status.Trim()
            Case String.Empty
            Case "1"
            Case "2"
                'Case "3"
                'Case "31"
                'Case "4"
                'Case "5"
                'Case "X"
            Case Else
                Return False
        End Select
        '-----------------------------------------------------------------

        '-----------------------------------------------------------------
        'Đặt mã mới theo ngày                        
        '-----------------------------------------------------------------
        l_solenh = i_lt_temp.Item(0).Outbound.ToString()

        l_date = p_DateTime.Substring(0, 2)
        l_month = p_DateTime.Substring(3, 2)
        l_year = p_DateTime.Substring(6, 4)

        'anhqh
        '20160920
        If g_KV1 = True Then
            'i_lt_temp(0).Date_Nd
            l_date = i_lt_temp(0).Date_Nd.Substring(6, 2)
            l_month = i_lt_temp(0).Date_Nd.Substring(4, 2)
            l_year = i_lt_temp(0).Date_Nd.Substring(0, 4)
            l_ngayxuat = New DateTime(l_year, l_month, l_date)
        Else
            l_ngayxuat = New DateTime(l_year, l_month, l_date)
        End If

        l_loaiphieu = i_lt_temp.Item(0).Shnumber.ToString()
        If l_loaiphieu = String.Empty Then
            l_loaiphieu = "V144"
        End If


        l_status = i_lt_temp.Item(0).Status.ToString()
        'l_malenh = l_bs_Header.SelectMaLenh(l_err, l_ngayxuat)

        Dim p_Dem As Integer = 0
TaoMaLenh:

        If g_KV1 = True Then
            l_malenh = KV1_FPT_GetMaLenh(l_solenh, l_ngayxuat)
        Else
            l_malenh = FPT_GetMaLenh(l_solenh)
        End If
        ' l_malenh = FPT_GetMaLenh(l_solenh)


        '-----------------------------------------------------------------
        '   Kiểm tra mã lệnh sau khi tính toán
        '-----------------------------------------------------------------


        'anhqh
        '20160715
        'Sua lai nếu trùng mã lệnh  thì xóa trong bảng SYS_MALENH_S roi tạo lai
        If Not mdlSyncDeliveries_CheckMaLenh(l_malenh, l_ngayxuat) Then

            If p_Dem >= 3 Then
                p_desc = "Trùng Mã Lệnh=" & l_malenh
                Return False
            End If


            p_SQL = ""

            p_SQL = "delete  from SYS_MALENH_S where  SoLenh='" & l_solenh & "'"

            If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

            End If

            p_Dem = p_Dem + 1

            GoTo taomalenh
        End If
        '-----------------------------------hXuat------------------------------

        '-----------------------------------------------------------------
        '   1. Nếu (2) thành công thì Insert dữ liệu vào bảng tblLenhXuat
        '
        '   2. Insert dữ liệu vào bảng tblLenhXuatChiTiet (có TR)                       
        '
        '   3. Insert dữ liệu vào tblLenhXuat_HangHoa
        '
        '-----------------------------------------------------------------
        '-----------------------------------------------------------------
        '   1. Insert dữ liệu vào bảng tblLenhXuat
        '-----------------------------------------------------------------
        'anhqh
        '20160918
        'Them lay loai hinh van tai theo ptien
        Dim p_MaPhuongTien As String
        If p_LOAIHINH_VT = True Then

            Try
                If i_lt_temp(p_Count).Transmot.ToString.Trim = "" Then
                    ' i_lt_temp(p_Count).Transmot
                    'anhqh
                    '20190606
                    'them neu SAP k xasc dinh laoi hinh van tai thi kiem tra va tu dong gan
                    i_lt_temp(p_Count).Transmot = "ZT"
                    For p_Count = 0 To i_lt_temp.Count - 1
                        If i_lt_temp(p_Count).Transmot.ToString.Trim = "" Then
                            p_MaPhuongTien = i_lt_temp(p_Count).Vehicle.ToString.Trim
                            p_SQL = "select LEFT(LaiXe,2) as LaiXe from tblPhuongTien with (nolock)  where   upper(MaPhuongTien)='" & UCase(p_MaPhuongTien) & "'"
                            p_table = GetDataTable(p_SQL, p_SQL)
                            If Not p_table Is Nothing Then
                                If p_table.Rows.Count > 0 Then
                                    p_SQL = ""
                                    p_SQL = p_table.Rows(0).Item(0).ToString.Trim
                                    i_lt_temp(p_Count).Transmot = p_SQL
                                End If
                            End If
                        End If
                    Next
                End If
            Catch ex As Exception

            End Try

        End If




        l_wa = i_lt_temp.Item(0)
        ' l_bs_Header = New BSTransaction_new()

        If Not mdlSyncDeliveries_SubModifyFromWorkArea(p_Client, p_DataExec, l_wa, l_malenh, l_ngayxuat, g_Company_Code, p_desc, p_DiemTraHang) Then
            Return False
        End If
        If p_DataExec.Rows.Count > 0 Then
            p_DataRow = p_DataExec.NewRow
            p_DataRow.Item(0) = "DELETE FROM tblLenhXuat_HangHoaE5 where SoLenh='" & l_wa.Outbound.ToString() & "'"
            p_DataExec.Rows.Add(p_DataRow)
        End If


        ''Lay QCI 20160326 va kiem tra lay so dat hang hay so quy doi

        If mdlSyncDeliveries_SynSpecific_QCI(p_NCC, l_ztb2, p_SapConnectionString, g_User_ID, g_Company_Code, _
                                   l_wa.Outbound.ToString(), p_desc, 25) = False Then
            p_desc = p_desc
            Return False
        End If

        'NhaCungCap

        If p_DataExec.Rows.Count > 0 Then
            p_DataRow = p_DataExec.NewRow
            p_DataRow.Item(0) = "UPDATE tblLenhXuatE5 set NhaCungCap='" & p_NCC & "' where SoLenh='" & l_wa.Outbound.ToString() & "'"
            p_DataExec.Rows.Add(p_DataRow)
        End If


        '-----------------------------------------------------------------
        '   3. Insert dữ liệu vào tblLenhXuat_HangHoa
        '-----------------------------------------------------------------
        l_count = 0
        l_wa = i_lt_temp.Item(0)
        l_lineid = i_lt_temp.Item(0).Item_Nd.ToString()


        Dim p_TableHangHoa As New DataTable
        Dim p_TableChiaNgan As New DataTable
        ' Dim p_SQL As String
        Dim p_dt_vehicle As DataTable

        p_SQL = "select MaNgan, SoLuongMax, 'X' as [Select] from FPT_tblChiTietPhuongTien_V where MaPhuongTien ='" & l_wa.Vehicle & "' ORDER By MaNgan"
        p_dt_vehicle = GetDataTable(p_SQL, p_SQL)

        'Dim p_Row As System.Data.DataRow
        p_SQL = "select TableID, MaHangHoa, TenHangHoa,DonViTinh,TongDuXuat,TongXuat, MeterID, BeXuat, SoLenh,MaLenh," & _
               "NgayXuat,LineID  from FPT_tblLenhXuat_hanghoaE5_v where solenh='" & l_wa.Order_No & "'"
        p_TableHangHoa = GetDataTable(p_SQL, p_SQL)
        p_TableHangHoa.Columns.Add("NhietDo")
        p_TableHangHoa.Columns.Add("TaiTrong")
        p_TableHangHoa.Columns.Add("TyTrong")
        ' p_TableHangHoa.Columns.Add("ChietKhau", GetType(Decimal))

        p_TableHangHoa.Clear()
        Dim p_LibCustom As New LibCustom.Class1(g_Services)
        Dim p_PhuongTien As String = ""
        p_PhuongTien = l_wa.Vehicle
        ' p_LibCustom.clsLoadDefault(p_PhuongTien, p_TableHangHoa, p_TableChiaNgan)

        'anhqh
        '20200409
        'Ham lay thong tin Chiet khau

        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_ConnectSapString As String = ""
        Dim p_TimeOut As String = ""
        'anhqh
        '20191101
        'Lay thong tin DO1 neu co
        p_SQL = "select * from tblConfig "
        'SapConnectionString, Timeout
        p_table = GetDataTable(p_SQL, p_SQL)
        If Not p_table Is Nothing Then
            If p_table.Rows.Count > 0 Then
                p_ConnectSapString = p_table.Rows(0).Item("SapConnectionString").ToString.Trim
                Try
                    p_TimeOut = p_table.Rows(0).Item("Timeout").ToString.Trim
                Catch ex As Exception

                End Try
                If p_TimeOut = "" Then
                    p_TimeOut = "60"
                End If
            End If
        End If
        p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
        p_TabChietKhau = p_ECCDestinationConfig.clsGet_DO3_Infor(l_solenh, p_SQL)


        If g_KV1 = False Then


            For i As Integer = 0 To i_lt_temp.Count - 1


                If l_wa.Item_Nd.ToString() <> i_lt_temp.Item(i).Item_Nd.ToString() Then
                    l_tongxuat = 0
                    l_tongduxuat = 0
                    'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
                    p_DataExecLine.Clear()

                    p_ChietKhau = 0
                    If Not p_TabChietKhau Is Nothing Then
                        If p_TabChietKhau.Rows.Count > 0 Then
                            p_RowArr2 = p_TabChietKhau.Select("ParName='" & l_wa.Item_Nd.ToString() & "'")
                            If p_RowArr2.Length > 0 Then
                                'p_ChietKhau =
                                Decimal.TryParse(p_RowArr2(0).Item(1).ToString.Trim, p_ChietKhau)
                                p_ChietKhau = Math.Abs(p_ChietKhau)
                            End If
                        End If
                    End If

                    'anhqh 20160530================================
                    If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, _
                                                                            l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa, p_ChietKhau) Then
                        l_count = l_count + 1
                    End If


                    l_wa = i_lt_temp.Item(i)
                    If p_DataExecLine.Rows.Count > 0 Then
                        p_DataExec.Merge(p_DataExecLine)
                    End If
                End If

                If i = i_lt_temp.Count - 1 Then
                    l_tongxuat = 0
                    l_tongduxuat = 0
                    'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
                    p_DataExecLine.Clear()
                    'If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine(p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty) Then
                    '    l_count = l_count + 1
                    'End If
                    p_ChietKhau = 0
                    If Not p_TabChietKhau Is Nothing Then
                        If p_TabChietKhau.Rows.Count > 0 Then
                            p_RowArr2 = p_TabChietKhau.Select("ParName='" & l_wa.Item_Nd.ToString() & "'")
                            If p_RowArr2.Length > 0 Then
                                'p_ChietKhau =
                                Decimal.TryParse(p_RowArr2(0).Item(1).ToString.Trim, p_ChietKhau)
                                p_ChietKhau = Math.Abs(p_ChietKhau)
                            End If
                        End If
                    End If

                    'anhqh 20160530================================================
                    If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa, p_ChietKhau) Then
                        l_count = l_count + 1
                    End If
                    If p_DataExecLine.Rows.Count > 0 Then
                        p_DataExec.Merge(p_DataExecLine)
                    End If
                End If

            Next
        Else
            For i As Integer = 0 To i_lt_temp.Count - 1

                If l_wa.Item_Nd.ToString() <> i_lt_temp.Item(i).Item_Nd.ToString() Then
                    l_tongxuat = 0
                    l_tongduxuat = 0
                    'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
                    p_DataExecLine.Clear()


                    'If g_KV1 = True Then
                    '    'anhqh 20160530================================
                    '    If Not KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, _
                    '                                                            l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa) Then
                    '        l_count = l_count + 1
                    '    End If

                    '    KV1_GenScriptfromTbl(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, _
                    '                                                   l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa)
                    'Else
                    'anhqh 20160530================================
                    If Not KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, _
                                                                            l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa) Then
                        l_count = l_count + 1
                    End If

                    '   End If


                    'If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine(p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty) Then
                    '    l_count = l_count + 1
                    'End If
                    l_wa = i_lt_temp.Item(i)
                    If p_DataExecLine.Rows.Count > 0 Then
                        p_DataExec.Merge(p_DataExecLine)
                    End If
                End If

                If i = i_lt_temp.Count - 1 Then
                    l_tongxuat = 0
                    l_tongduxuat = 0
                    'l_tongduxuat = l_tongxuat_arr(Convert.ToInt32(l_wa.Item_Nd.ToString()))
                    p_DataExecLine.Clear()
                    'If Not mdlSyncDeliveries_SubModifyFromWorkAreaLine(p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty) Then
                    '    l_count = l_count + 1
                    'End If

                    'anhqh 20160530================================================
                    If Not KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa) Then
                        l_count = l_count + 1
                    End If
                    If p_DataExecLine.Rows.Count > 0 Then
                        p_DataExec.Merge(p_DataExecLine)
                    End If
                End If

            Next

            KV1_GenScriptfromTbl(p_Client, l_ztb2, p_DataExecLine, l_wa, l_malenh, l_ngayxuat, l_solenh, l_tongxuat, l_tongduxuat, l_loaiphieu, String.Empty, p_TableHangHoa)
            If p_DataExecLine.Rows.Count > 0 Then
                p_DataExec.Merge(p_DataExecLine)
            End If


        End If
        l_ztb2 = Nothing
        If l_count <> 0 Then
            l_err = String.Empty
            '  l_bs_Header.DeleteTransaction(l_err, l_solenh, l_ngayxuat)
            ' mdlSyncDeliveries_DeleteAllDetails_new(l_solenh)
            Return False
        End If
        If Not p_TableHangHoa Is Nothing Then
            If p_TableHangHoa.Rows.Count > 0 Then
                p_MaVanChuyen = l_wa.Transmot.ToString.Trim

                p_MaVanChuyen = GetLoadingSite(p_MaVanChuyen)
                ''Goi ham lay  Loai xuat

                If p_DUXUAT_TD = True And UCase(p_MaVanChuyen) <> "THUY" Then ' And UCase(p_MaVanChuyen) = "BO" Then
                    Dim p_Change As Boolean
                    Dim p_Error As Integer
                    'Dim p_Desc As String

                    If p_QUYDOI_SAP = "N" Then

                        mdlKiemTraNganVaLuongDat(i_lt_temp, l_wa.Vehicle, p_TableHangHoa, p_Change, p_Error, p_desc)
                        If p_Error = True Then
                            Return False
                        End If
                    End If


                    '  If p_Change = False Then
                    SetHangHoaComParment(i_lt_temp, p_TableHangHoa)

                    p_SQL = "select MaNgan, SoLuongMax, 'X' as [Select] from FPT_tblChiTietPhuongTien_V where MaPhuongTien ='" & l_wa.Vehicle & "' ORDER By MaNgan"
                    p_dt_vehicle = GetDataTable(p_SQL, p_SQL)

                    'End If
                    'SetHangHoaComParment(i_lt_temp, p_TableHangHoa)
                End If


                p_LibCustom.clsLoadDefault(p_dt_vehicle, p_PhuongTien, p_TableHangHoa, p_TableChiaNgan, p_MaVanChuyen)
                If Not p_TableChiaNgan Is Nothing Then
                    If l_loaiphieu <> "V144" Then
                        If p_TableChiaNgan.Rows.Count > 0 Then
                            If SetComparment(p_TableHangHoa, p_dt_vehicle, i_lt_temp, p_TableChiaNgan) = False Then

                            End If

                        End If
                    End If

                    For p_Count = 0 To p_TableChiaNgan.Rows.Count - 1
                        p_DataRow = p_DataExec.NewRow
                        If p_TuDongHoa = True Then
                            If p_ThamSoNgay = True Then
                                p_MaTDH = GetMaTuDongHoa_ND(i_lt_temp.Item(0).Date_Nd.ToString())
                            Else
                                p_MaTDH = GetMaTuDongHoa()
                            End If

                            If p_MaTDH = 0 Then
                                p_desc = "Lỗi khi lấy mã tự đông hóa"
                                Return False
                            End If
                        Else
                            p_MaTDH = 0
                        End If

                        ' GetMaVanChuyen("", p_MaVanChuyen, p_MaVanChuyen)


                        p_SQL = "INSERT INTO tblLenhXuatChiTietE5 (DungTichNgan,MaNgan , MaLenh ,NgayXuat , LineID , SoLuongDuXuat , TableID , MaTuDongHoa )"
                        p_SQL = p_SQL & " VALUES (" & p_TableChiaNgan.Rows(p_Count).Item("DungTichNgan").ToString.Trim & _
                                ",'" & p_TableChiaNgan.Rows(p_Count).Item("MaNgan").ToString.Trim & "'" & _
                                 ",'" & p_TableChiaNgan.Rows(p_Count).Item("MaLenh").ToString.Trim & "'" & _
                                 ",convert(date,'" & CDate(l_ngayxuat).ToString("yyyyMMdd") & "')" & _
                                 ",'" & p_TableChiaNgan.Rows(p_Count).Item("LineID").ToString.Trim & "'" & _
                                 "," & IIf(p_TableChiaNgan.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim = "", 0, p_TableChiaNgan.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim) & "" & _
                                 ",'" & p_TableChiaNgan.Rows(p_Count).Item("TableID").ToString.Trim & "'" & _
                                 ",'" & p_MaTDH & "'" & _
                                ")"
                        p_DataRow.Item(0) = p_SQL
                        p_DataExec.Rows.Add(p_DataRow)

                    Next

                End If
            End If
        End If


        'Dim p_PathXml As String = Application.StartupPath & "\" & l_solenh & ".xml"

        If Not p_DataExec Is Nothing Then
            ' p_DataExec.WriteXml(p_PathXml)

            If g_Services.Sys_Execute_DataTbl(p_DataExec, p_desc) = False Then
                'MsgBox(p_SQL)
                ' g_Module.ModErrExceptionNew("", p_desc)
                Return False
            End If
        End If

        If l_loaiphieu <> "V144" And p_DUXUAT_TD = True Then
            p_DataExec.Clear()
            If p_TableHangHoa.Rows.Count > 0 Then
                For p_Count = 0 To p_TableHangHoa.Rows.Count - 1
                    p_DataRow = p_DataExec.NewRow
                    p_DataRow.Item(0) = "update  tblLenhXuat_HangHoaE5  set TongXuat  =" & IIf(p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim = "", 0, p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim) & ",  " & _
                            " TongDuXuat  =" & IIf(p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim = "", 0, p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim) & " " & _
                            " where TableID='" & p_TableHangHoa.Rows(p_Count).Item("TableID").ToString.Trim & "' " & _
                            " and SoLenh='" & p_TableHangHoa.Rows(p_Count).Item("SoLenh").ToString.Trim & "' "
                    p_DataExec.Rows.Add(p_DataRow)
                Next
            End If
            If p_DataExec.Rows.Count > 0 Then
                If g_Services.Sys_Execute_DataTbl(p_DataExec, p_desc) = False Then
                    'MsgBox(p_SQL)
                    ' g_Module.ModErrExceptionNew("", p_desc)
                    Return False
                End If
            End If
        End If
        Return True
    End Function



    Private Function SetComparment(ByVal p_TableHangHoa As DataTable, ByVal p_dt_vehicle As DataTable, ByVal i_lt_temp As Connect2SAP.Str_PhieuXuatTable, ByRef p_Table As System.Data.DataTable) As Boolean
        Dim p_Count As Integer
        Dim p_RowArr() As DataRow
        Dim p_Row As DataRow
        Dim p_CountHH As Integer
        Dim p_TableTmp As DataTable
        Dim l_wa As Connect2SAP.Str_PhieuXuat = New Connect2SAP.Str_PhieuXuat()
        Dim p_Count1 As Integer
        SetComparment = True

        p_TableTmp = p_Table.Clone


        Try
            For p_CountHH = 0 To p_TableHangHoa.Rows.Count - 1
                For p_Count = 0 To i_lt_temp.Count - 1
                    l_wa = i_lt_temp(p_Count)
                    If l_wa.Item_Nd.ToString.Trim = p_TableHangHoa.Rows(p_CountHH).Item("LineID").ToString.Trim Then
                        p_RowArr = p_dt_vehicle.Select("MaNgan='" & l_wa.Compartment.ToString.Trim & "' and  SoLuongMax=" & l_wa.Quantity)
                        If p_RowArr.Length > 0 Then
                            p_Row = p_TableTmp.NewRow
                            p_Row.Item("MaNgan") = l_wa.Compartment.ToString.Trim
                            p_Row.Item("SoLenh") = p_TableHangHoa.Rows(p_CountHH).Item("SoLenh").ToString.Trim
                            p_Row.Item("LineID") = p_TableHangHoa.Rows(p_CountHH).Item("LineID").ToString.Trim
                            p_Row.Item("TableID") = p_TableHangHoa.Rows(p_CountHH).Item("TableID").ToString.Trim
                            p_Row.Item("SoLuongDuXuat") = l_wa.Quantity
                            p_Row.Item("MaHangHoa") = p_TableHangHoa.Rows(p_CountHH).Item("MaHangHoa").ToString.Trim
                            p_Row.Item("MaLenh") = p_TableHangHoa.Rows(p_CountHH).Item("MaLenh").ToString.Trim
                            p_Row.Item("DungTichNgan") = p_RowArr(0).Item("SoLuongMax").ToString.Trim
                            p_TableTmp.Rows.Add(p_Row)
                        End If
                    End If

                Next
            Next

            If p_TableTmp.Rows.Count > 0 Then
                p_Table.Clear()
                p_Table.Merge(p_TableTmp)
            End If
        Catch ex As Exception
            SetComparment = False
        End Try
    End Function

    'Private Function GetMaTuDongHoa() As Integer
    '    Dim p_SQL As String
    '    Dim p_DataTable As DataTable
    '    p_SQL = " exec FPT_Key_TuDongHoa"
    '    GetMaTuDongHoa = 0
    '    Try
    '        p_DataTable = GetDataTable(p_SQL, p_SQL)
    '        If Not p_DataTable Is Nothing Then
    '            If p_DataTable.Rows.Count > 0 Then
    '                GetMaTuDongHoa = p_DataTable.Rows(0).Item(0).ToString.Trim
    '            End If
    '        End If
    '    Catch ex As Exception
    '        GetMaTuDongHoa = 0
    '    End Try
    'End Function

    Function GetMaTuDongHoa() As Integer
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_Pro_TuDongHoa As String
        Dim p_ArrRow() As DataRow
        'p_ArrRow = p_TableConfig.Select("KEYCODE='MATUDONGHOA_PROD'")
        'If p_ArrRow.Length > 0 Then
        '    p_Pro_TuDongHoa = p_ArrRow(0).Item("KEYVALUE").ToString.Trim
        'End If
        'If p_ThamSoNgay = True Then
        '    p_Pro_TuDongHoa = p_MATUDONGHOA_PROD & " "
        'Else
        p_Pro_TuDongHoa = p_MATUDONGHOA_PROD
        ' End If

        p_SQL = " exec " & p_Pro_TuDongHoa
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
    Function GetMaTuDongHoa_ND(ByVal p_DateND As String) As Integer
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_Pro_TuDongHoa As String
        Dim p_ArrRow() As DataRow
        'p_ArrRow = p_TableConfig.Select("KEYCODE='MATUDONGHOA_PROD'")
        'If p_ArrRow.Length > 0 Then
        '    p_Pro_TuDongHoa = p_ArrRow(0).Item("KEYVALUE").ToString.Trim
        'End If
        'If p_ThamSoNgay = True Then
        p_Pro_TuDongHoa = p_MATUDONGHOA_PROD & " '" & p_DateND & "' "
        'Else
        'p_Pro_TuDongHoa = p_MATUDONGHOA_PROD
        ' End If

        p_SQL = " exec " & p_Pro_TuDongHoa
        GetMaTuDongHoa_ND = 0
        Try
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetMaTuDongHoa_ND = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
        Catch ex As Exception
            GetMaTuDongHoa_ND = 0
        End Try
    End Function


    Private Function GetLoadingSite(ByVal p_MaVanChuyen As String) As String
        Dim p_SQL As String
        Dim p_DAtaTable As DataTable
        Try
            p_SQL = "select * from tblPara where CHARINDEX ('" & p_MaVanChuyen & "',Value_nd,1)>0"
            p_DAtaTable = GetDataTable(p_SQL, p_SQL)
            If p_DAtaTable.Rows.Count <= 0 Then
                Return "BO"
            End If
            Return p_DAtaTable.Rows(0).Item("Para").ToString.Trim
        Catch ex As Exception
            Return "BO"
        End Try


    End Function

    Private Function mdlSyncDeliveries_SubModifyFromWorkAreaLine(ByRef p_DataExec As DataTable, ByVal i_wa As Connect2SAP.Str_PhieuXuat, _
                                                           ByVal i_malenh As String, _
                                                           ByVal i_ngayxuat As String, _
                                                           ByVal i_solenh As String, _
                                                           ByVal i_tongxuat As Decimal, _
                                                           ByVal i_tongduxuat As Decimal, _
                                                           ByVal i_loaiphieu As String, _
                                                           ByVal i_tableid As String) As Boolean
        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat_HangHoa
        '   Key:
        '       MaLenh
        '       NgayXuat
        '       SoLenh      - phục vụ tìm kiếm nhanh
        '-----------------------------------------------------------------
        Dim l_mahanghoa, _
            l_donvitinh _
            As String

        '-----------------------------------------------------------------
        'Các biến Tính QCI
        '   l_out:      
        '   l_quantity: Tính lượng QCI trả ra
        '-----------------------------------------------------------------
        'Dim l_out As String()
        Dim l_quantity As Decimal() = New Decimal() {0, 0, 0, 0}
        Dim l_err As String
        Dim p_SQL As String
        'Dim p_DataTable As New DataTable("Table002")
        Dim p_DataTableCheck As DataTable
        Dim p_DataRow As DataRow
        Dim p_TBLTABLEID_ZT As Boolean = False
        Dim p_TableID As String
        Dim p_BeXuat As String

        p_SQL = "select Name from sys.all_objects where upper(Name)='TBLTABLEID_ZT'"
        p_DataTableCheck = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTableCheck Is Nothing Then
            If p_DataTableCheck.Rows.Count > 0 Then
                p_TBLTABLEID_ZT = True
            End If
        End If
        'p_DataTable.Columns.Add("STR_LINE")
        'p_SQL = "DELETE FROM tblLenhXuat_HangHoaE5 where SoLenh='" & i_solenh & "'"
        'p_DataRow = p_DataTable.NewRow
        'p_DataRow.Item(0) = p_SQL
        'p_DataTable.Rows.Add(p_DataRow)

        l_donvitinh = i_wa.Unit.ToString()
        mdlSyncDeliveries_SubModifyFromWorkAreaLine = True
        i_tongxuat = 0
        i_tongduxuat = Convert.ToDecimal(i_wa.Salequantity.ToString())

        '-----------------------------------------------------------------
        'Tính QCI
        '-----------------------------------------------------------------

        Try


            If i_wa.Material.Length > 7 Then
                l_mahanghoa = i_wa.Material.Substring(i_wa.Material.Length - 7, 7)
            Else
                l_mahanghoa = i_wa.Material.Substring(0, i_wa.Material.Length)
            End If

            l_err = String.Empty

            l_quantity = mdlQCI_CalculateQCI(i_tongduxuat, i_wa.Unit, 15, 0.688)
            If InsertQci(l_err, i_malenh, i_ngayxuat, i_wa.Item_Nd.ToString(), i_solenh, i_wa.Compartment.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3)) Then
                UpdateQci(l_err, i_solenh, i_wa.Compartment.ToString(), i_wa.Item_Nd.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3))
            End If
            p_BeXuat = ""
            p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat))
            '-----------------------------------------------------------------
            p_TableID = GetTableID()
            p_SQL = "INSERT INTO [tblLenhXuat_HangHoaE5] (LineID, MaLenh,NgayXuat, SoLenh,TongXuat, " & _
                "TongDuXuat, MaHangHoa, DonViTinh,BeXuat,TableID ,Createby,CreateDate) "
            p_SQL = p_SQL & " VALUES ('" & i_wa.Item_Nd.ToString() & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & i_solenh & "'" & _
                    "," & l_quantity(1) & "," & i_tongduxuat & ",'" & l_mahanghoa & "','" & l_donvitinh & "','" & p_BeXuat & "','" & p_TableID & "'," & g_User_ID & ",getdate())"

            p_DataRow = p_DataExec.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataExec.Rows.Add(p_DataRow)

            If p_TBLTABLEID_ZT = True Then
                p_SQL = "INSERT INTO [TBLTABLEID_ZT](NgayXuat,TableID) VALUES ('" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & p_TableID & "')"
                p_DataRow = p_DataExec.NewRow
                p_DataRow.Item(0) = p_SQL
                p_DataExec.Rows.Add(p_DataRow)
            End If

        Catch ex As Exception
            mdlSyncDeliveries_SubModifyFromWorkAreaLine = False
        End Try
    End Function


    Private Function mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(ByVal p_Client As String, ByVal l_ztb2 As Connect2SapEx.LIPSO2Table, _
                                                           ByRef p_DataExec As DataTable, _
                                                           ByVal i_wa As Connect2SAP.Str_PhieuXuat, _
                                                           ByVal i_malenh As String, _
                                                           ByVal i_ngayxuat As String, _
                                                           ByVal i_solenh As String, _
                                                           ByVal i_tongxuat As Decimal, _
                                                           ByVal i_tongduxuat As Decimal, _
                                                           ByVal i_loaiphieu As String, _
                                                           ByVal i_tableid As String, _
                                                           ByRef p_TableHangHoa As System.Data.DataTable, Optional ByVal p_ChietKhau As Decimal = 0) As Boolean
        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat_HangHoa
        '   Key:
        '       MaLenh
        '       NgayXuat
        '       SoLenh      - phục vụ tìm kiếm nhanh
        '-----------------------------------------------------------------
        Dim l_mahanghoa, _
            l_donvitinh _
            As String

        '-----------------------------------------------------------------
        'Các biến Tính QCI
        '   l_out:      
        '   l_quantity: Tính lượng QCI trả ra
        '-----------------------------------------------------------------
        'Dim l_out As String()
        Dim l_quantity As Decimal() = New Decimal() {0, 0, 0, 0}

        Dim l_quantity2 As Decimal() = New Decimal() {0, 0, 0, 0}

        Dim p_NhietDoTemp As Double = 30
        Dim p_TyTrongBe As Double = 0.688

        Dim l_err As String
        Dim p_SQL As String
        'Dim p_DataTable As New DataTable("Table002")
        Dim p_DataTableCheck As DataTable
        Dim p_DataRow As DataRow
        Dim p_TBLTABLEID_ZT As Boolean = False
        Dim p_TableID As String
        Dim p_BeXuat As String

        Dim p_CountQCI As Integer
        Dim p_TongXuat As Decimal

        Dim p_TaiTrongKg As Decimal


        Dim p_LoaiVanChuyen As String = ""

        Dim p_RowHangHoa As System.Data.DataRow

        Dim p_Tank As String

        Dim p_Sum As Double
        Dim p_Count As Integer
        Dim p_CrdDate As Date
        Dim p_Batch_ND As String = ""

        Dim p_MaVanChuyen As String = ""

        Dim p_MeterId As String = ""
        '   For  p_Count = 0 To 

        mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI = True





        p_SQL = "select Name from sys.all_objects where upper(Name)='TBLTABLEID_ZT'"
        p_DataTableCheck = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTableCheck Is Nothing Then
            If p_DataTableCheck.Rows.Count > 0 Then
                p_TBLTABLEID_ZT = True
            End If
        End If

        l_donvitinh = i_wa.Unit.ToString()

        i_tongxuat = 0
        i_tongduxuat = Convert.ToDecimal(i_wa.Salequantity.ToString())

        '-----------------------------------------------------------------
        'Tính QCI
        '-----------------------------------------------------------------

        Try


            If i_wa.Material.Length > 7 Then
                l_mahanghoa = i_wa.Material.Substring(i_wa.Material.Length - 7, 7)
            Else
                l_mahanghoa = i_wa.Material.Substring(0, i_wa.Material.Length)
            End If

            p_Batch_ND = ""
            Try
                p_Batch_ND = i_wa.Batch_Nd.ToString.Trim
            Catch ex As Exception

            End Try

            l_err = String.Empty
            l_quantity(0) = 0
            l_quantity(1) = 0
            l_quantity(2) = 0
            l_quantity(3) = 0


            If p_QUYDOI_SAP = "Y" Then
                For p_CountQCI = 0 To l_ztb2.Count - 1
                    'p_QUYDOI_SAP

                    If l_ztb2(p_CountQCI).Posnr.ToString.Trim = i_wa.Item_Nd.ToString.Trim Then

                        Select Case UCase(l_ztb2(p_CountQCI).Msehi.ToString.Trim)
                            Case "L"
                                l_quantity(0) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(0), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                ' p_TongXuat = l_quantity(0)
                            Case "L15"
                                l_quantity(1) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(1), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                '  p_TongXuat = l_quantity(1)
                            Case "KG"
                                l_quantity(3) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(3), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                'p_TongXuat = l_quantity(2)
                            Case Else
                                l_quantity(2) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(2), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                '  p_TongXuat = l_quantity(3)
                        End Select
                    End If
                Next

                'p_TongXuat = l_quantity(1)
                Select Case l_donvitinh
                    Case "L"
                        p_TongXuat = i_tongduxuat 'l_quantity(0)
                    Case "L15"
                        p_TongXuat = l_quantity(0)
                    Case "KG"
                        p_TongXuat = l_quantity(0)
                    Case Else
                        p_TongXuat = l_quantity(0)

                End Select

            Else
                l_quantity = mdlQCI_CalculateQCI(i_tongduxuat, i_wa.Unit, 15, 0.688)
                p_TongXuat = i_tongduxuat
            End If


            'Select Case l_donvitinh
            '    Case "L"
            '        p_TongXuat = l_quantity(0)
            '    Case "L15"
            '        p_TongXuat = l_quantity(1)
            '    Case "KG"
            '        p_TongXuat = l_quantity(3)
            '    Case Else
            '        p_TongXuat = l_quantity(2)

            'End Select

            If InsertQci(l_err, i_malenh, i_ngayxuat, i_wa.Item_Nd.ToString(), i_solenh, i_wa.Compartment.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3)) Then
                UpdateQci(l_err, i_solenh, i_wa.Compartment.ToString(), i_wa.Item_Nd.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3))
            End If
            p_BeXuat = ""
            p_Tank = ""

            'anhqh
            '20160628
            p_LoaiVanChuyen = UCase(GetLoadingSite(i_wa.Transmot))

            '20241120
            Dim p_NhomBeHTTG As String = ""

            If p_ThongTinNhomBe = True Then
                Dim p_Table01 As DataTable


                p_SQL = "exec  GetTankGroupHTTG '" & p_BeXuat & "','" & g_NhomBeXuat & "','" & l_mahanghoa & "','" & g_Terminal & "','" & p_LoaiVanChuyen & "'"
                p_Table01 = GetDataTable(p_SQL, p_SQL)
                If Not p_Table01 Is Nothing Then
                    If p_Table01.Rows.Count > 0 Then
                        p_NhomBeHTTG = p_Table01.Rows(0).Item(0).ToString.Trim
                        p_BeXuat = p_Table01.Rows(0).Item(1).ToString.Trim
                    End If
                End If

                If p_NhomBeHTTG = "" Then
                    p_BeXuat = ""
                    p_NhomBeHTTG = g_NhomBeXuat
                    'If CheckHangHoaE5(l_mahanghoa) = True Then
                    '    p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat), p_Client, p_LoaiVanChuyen)
                    '    p_Tank = GetTankActiveE5(p_BeXuat, CDate(i_ngayxuat))
                    'Else
                    '    p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat), p_Client, p_LoaiVanChuyen)
                    '    p_Tank = p_BeXuat
                    'End If
                Else
                    If CheckHangHoaE5(l_mahanghoa) = True Then
                        p_Tank = GetTankActiveE5(p_BeXuat, CDate(i_ngayxuat))
                    Else
                        p_Tank = p_BeXuat
                    End If
                End If

            Else

                If CheckHangHoaE5(l_mahanghoa) = True Then
                    p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat), p_Client, p_LoaiVanChuyen)
                    p_Tank = GetTankActiveE5(p_BeXuat, CDate(i_ngayxuat))
                Else
                    p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat), p_Client, p_LoaiVanChuyen)
                    p_Tank = p_BeXuat
                End If
            End If

            ''anhqh  20160530
            'If CheckHangHoaE5(l_mahanghoa) = True Then
            '    p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat), p_Client, p_LoaiVanChuyen)
            '    p_Tank = GetTankActiveE5(p_BeXuat, CDate(i_ngayxuat))
            'Else
            '    p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat), p_Client, p_LoaiVanChuyen)
            '    p_Tank = p_BeXuat
            'End If

            '-----------------------------------------------------------------

            'anhqh   20160623
            'Ghep dac thu rieng cua KV1
            ' If g_Company_Code = "2110" Then
            If g_KV1 = True Then
                p_CrdDate = CDate(i_ngayxuat)
                p_TableID = GetTableIDKV1(i_wa.Transmot.ToString(), p_CrdDate, l_mahanghoa)
            Else
                p_TableID = GetTableID()
            End If
            'p_TableID = GetTableID()


            'Tinh so KG tai trong  =========================================================================
            p_SQL = "select ISNULL((select NhietDo from tblNhietDo with (Nolock) where  " & _
                "CONVERT(date,crDate)=(select MAX(crDate) from tblNhietDo with (Nolock) )),30) as NhietDo," & _
                 "ISNULL((select top 1 Dens_nd from FPT_tblTankActive_V where Date1 =CONVERT(date,getdate()) " & _
                 "and Name_nd ='" & p_Tank & "'),0.688) as TyTrong"
            p_DataTableCheck = GetDataTable(p_SQL, p_SQL)


            l_quantity2(0) = 0
            l_quantity2(1) = 0
            l_quantity2(2) = 0
            l_quantity2(3) = 0

            If Not p_DataTableCheck Is Nothing Then
                If p_DataTableCheck.Rows.Count > 0 Then
                    p_NhietDoTemp = p_DataTableCheck.Rows(0).Item("NhietDo")
                    p_TyTrongBe = p_DataTableCheck.Rows(0).Item("TyTrong")

                End If
            End If


            'anhqh
            '20161020
            'Kiem tra tai trong ca xuat thuy va bo
            If p_BeXuat.ToString.Trim <> "" And (p_LoaiVanChuyen = "BO" Or p_LoaiVanChuyen = "THUY") Then
                ' mdlQCI_CalculateQCI_NS("", p_SoLuong, "L", p_NhietDoN, IIf(p_DataRow(0).Item("TyTrong").ToString.Trim = "", 0.688, p_DataRow(0).Item("TyTrong").ToString.Trim))
                l_quantity2 = mdlQCI_CalculateQCI("", p_TongXuat, "L", p_NhietDoTemp, p_TyTrongBe)
            End If
            p_MeterId = ""


            p_TaiTrongKg = 0 ' l_quantity2(3)
            'Tinh so KG tai trong  =========================================================================

            'Dim p_NhomBeHTTG As String = ""

            'If p_ThongTinNhomBe = True Then
            '    Dim p_Table01 As DataTable
            '    p_SQL = "exec  GetTankGroupHTTG '" & p_BeXuat & "','" & g_NhomBeXuat & "' "
            '    p_Table01 = GetDataTable(p_SQL, p_SQL)
            '    If Not p_Table01 Is Nothing Then
            '        If p_Table01.Rows.Count > 0 Then
            '            p_NhomBeHTTG = p_Table01.Rows(0).Item(0).ToString.Trim

            '        End If
            '    End If

            '    'If p_NhomBeHTTG = "" Then
            '    '    p_BeXuat = ""
            '    'End If

            'End If

            If p_CONGTO_BEXUAT = True And p_BeXuat.ToString.Trim <> "" Then
                p_SQL = "select top 1 MeterID from dbo.vwMeterAll  where TankE5 ='" & p_BeXuat.ToString.Trim & "'"
                p_DataTableCheck = GetDataTable(p_SQL, p_SQL)
                If Not p_DataTableCheck Is Nothing Then
                    If p_DataTableCheck.Rows.Count > 0 Then
                        p_MeterId = p_DataTableCheck.Rows(0).Item(0).ToString.Trim
                    End If
                End If

                p_SQL = "INSERT INTO [tblLenhXuat_HangHoaE5] (NhomBeXuat,BatchNum, ChietKhau, MeterId, LineID, MaLenh,NgayXuat, SoLenh,TongXuat, " & _
                    "TongDuXuat, MaHangHoa, DonViTinh,BeXuat,TableID ,Createby,CreateDate, QCI_KG, QCI_NhietDo, QCI_TyTrong) "
                p_SQL = p_SQL & " VALUES ('" & p_NhomBeHTTG & "', '" & p_Batch_ND & "'," & p_ChietKhau & ",'" & p_MeterId & "','" & i_wa.Item_Nd.ToString() & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & i_solenh & "'" & _
                        "," & p_TongXuat & "," & i_tongduxuat & ",'" & l_mahanghoa & "','" & l_donvitinh & "','" & p_BeXuat & "','" & p_TableID & "'," & g_User_ID & ",getdate()" & _
                        "," & p_TaiTrongKg & "," & p_NhietDoTemp & "," & p_TyTrongBe & ")"
            Else
                p_SQL = "INSERT INTO [tblLenhXuat_HangHoaE5] (NhomBeXuat, BatchNum,ChietKhau, LineID, MaLenh,NgayXuat, SoLenh,TongXuat, " & _
                     "TongDuXuat, MaHangHoa, DonViTinh,BeXuat,TableID ,Createby,CreateDate, QCI_KG, QCI_NhietDo, QCI_TyTrong) "
                p_SQL = p_SQL & " VALUES ('" & p_NhomBeHTTG & "','" & p_Batch_ND & "'," & p_ChietKhau & ",'" & i_wa.Item_Nd.ToString() & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & i_solenh & "'" & _
                        "," & p_TongXuat & "," & i_tongduxuat & ",'" & l_mahanghoa & "','" & l_donvitinh & "','" & p_BeXuat & "','" & p_TableID & "'," & g_User_ID & ",getdate()" & _
                        "," & p_TaiTrongKg & "," & p_NhietDoTemp & "," & p_TyTrongBe & ")"
            End If

            'p_SQL = "INSERT INTO [tblLenhXuat_HangHoaE5] (LineID, MaLenh,NgayXuat, SoLenh,TongXuat, " & _
            '    "TongDuXuat, MaHangHoa, DonViTinh,BeXuat,TableID ,Createby,CreateDate, QCI_KG, QCI_NhietDo, QCI_TyTrong) "
            'p_SQL = p_SQL & " VALUES ('" & i_wa.Item_Nd.ToString() & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & i_solenh & "'" & _
            '        "," & p_TongXuat & "," & i_tongduxuat & ",'" & l_mahanghoa & "','" & l_donvitinh & "','" & p_BeXuat & "','" & p_TableID & "'," & g_User_ID & ",getdate()" & _
            '        "," & p_TaiTrongKg & "," & p_NhietDoTemp & "," & p_TyTrongBe & ")"

            p_DataRow = p_DataExec.NewRow
            p_DataRow.Item(0) = p_SQL
            p_DataExec.Rows.Add(p_DataRow)

            p_RowHangHoa = p_TableHangHoa.NewRow
            p_RowHangHoa.Item("TableID") = p_TableID
            p_RowHangHoa.Item("MaHangHoa") = l_mahanghoa
            p_RowHangHoa.Item("DonViTinh") = l_donvitinh
            p_RowHangHoa.Item("TongDuXuat") = i_tongduxuat
            p_RowHangHoa.Item("TongXuat") = p_TongXuat
            p_RowHangHoa.Item("BeXuat") = p_BeXuat
            p_RowHangHoa.Item("SoLenh") = i_solenh
            p_RowHangHoa.Item("MaLenh") = i_malenh
            p_RowHangHoa.Item("NgayXuat") = CDate(i_ngayxuat).ToString("yyyy/MM/dd")
            p_RowHangHoa.Item("LineID") = i_wa.Item_Nd.ToString()
            p_TableHangHoa.Rows.Add(p_RowHangHoa)

            If p_TBLTABLEID_ZT = True Then
                p_SQL = "INSERT INTO [TBLTABLEID_ZT](NgayXuat,TableID) VALUES ('" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & p_TableID & "')"
                p_DataRow = p_DataExec.NewRow
                p_DataRow.Item(0) = p_SQL
                p_DataExec.Rows.Add(p_DataRow)
            End If

        Catch ex As Exception
            mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI = False
        End Try
    End Function



    Private Function KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI(ByVal p_Client As String, ByVal l_ztb2 As Connect2SapEx.LIPSO2Table, _
                                                           ByRef p_DataExec As DataTable, _
                                                           ByVal i_wa As Connect2SAP.Str_PhieuXuat, _
                                                           ByVal i_malenh As String, _
                                                           ByVal i_ngayxuat As String, _
                                                           ByVal i_solenh As String, _
                                                           ByVal i_tongxuat As Decimal, _
                                                           ByVal i_tongduxuat As Decimal, _
                                                           ByVal i_loaiphieu As String, _
                                                           ByVal i_tableid As String, _
                                                           ByRef p_TableHangHoa As System.Data.DataTable, _
                                                            Optional ByVal p_ChietKhau As Decimal = 0) As Boolean
        '-----------------------------------------------------------------
        'Các biến cho vào bảng tblLenhXuat_HangHoa
        '   Key:
        '       MaLenh
        '       NgayXuat
        '       SoLenh      - phục vụ tìm kiếm nhanh
        '-----------------------------------------------------------------
        Dim l_mahanghoa, _
            l_donvitinh _
            As String

        '-----------------------------------------------------------------
        'Các biến Tính QCI
        '   l_out:      
        '   l_quantity: Tính lượng QCI trả ra
        '-----------------------------------------------------------------
        'Dim l_out As String()
        Dim l_quantity As Decimal() = New Decimal() {0, 0, 0, 0}

        Dim l_quantity2 As Decimal() = New Decimal() {0, 0, 0, 0}

        Dim p_NhietDoTemp As Double = 30
        Dim p_TyTrongBe As Double = 0.688

        Dim l_err As String
        Dim p_SQL As String
        'Dim p_DataTable As New DataTable("Table002")
        Dim p_DataTableCheck As DataTable
        Dim p_DataRow As DataRow
        Dim p_TBLTABLEID_ZT As Boolean = False
        Dim p_TableID As String
        Dim p_BeXuat As String

        Dim p_CountQCI As Integer
        Dim p_TongXuat As Decimal

        Dim p_TaiTrongKg As Decimal


        Dim p_LoaiVanChuyen As String = ""

        Dim p_RowHangHoa As System.Data.DataRow

        Dim p_Tank As String

        Dim p_Sum As Double
        Dim p_Count As Integer
        Dim p_CrdDate As Date

        '   For  p_Count = 0 To 

        KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI = True





        p_SQL = "select Name from sys.all_objects where upper(Name)='TBLTABLEID_ZT'"
        p_DataTableCheck = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTableCheck Is Nothing Then
            If p_DataTableCheck.Rows.Count > 0 Then
                p_TBLTABLEID_ZT = True
            End If
        End If

        l_donvitinh = i_wa.Unit.ToString()

        i_tongxuat = 0
        i_tongduxuat = Convert.ToDecimal(i_wa.Salequantity.ToString())

        '-----------------------------------------------------------------
        'Tính QCI
        '-----------------------------------------------------------------

        Try


            If i_wa.Material.Length > 7 Then
                l_mahanghoa = i_wa.Material.Substring(i_wa.Material.Length - 7, 7)
            Else
                l_mahanghoa = i_wa.Material.Substring(0, i_wa.Material.Length)
            End If

            l_err = String.Empty
            l_quantity(0) = 0
            l_quantity(1) = 0
            l_quantity(2) = 0
            l_quantity(3) = 0


            If p_QUYDOI_SAP = "Y" Then
                For p_CountQCI = 0 To l_ztb2.Count - 1
                    'p_QUYDOI_SAP

                    If l_ztb2(p_CountQCI).Posnr.ToString.Trim = i_wa.Item_Nd.ToString.Trim Then

                        Select Case UCase(l_ztb2(p_CountQCI).Msehi.ToString.Trim)
                            Case "L"
                                l_quantity(0) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(0), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                ' p_TongXuat = l_quantity(0)
                            Case "L15"
                                l_quantity(1) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(1), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                '  p_TongXuat = l_quantity(1)
                            Case "KG"
                                l_quantity(3) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(3), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                'p_TongXuat = l_quantity(2)
                            Case Else
                                l_quantity(2) = IIf(l_ztb2(p_CountQCI).Adqnt.ToString.Trim = "", l_quantity(2), l_ztb2(p_CountQCI).Adqntp.ToString.Trim)
                                '  p_TongXuat = l_quantity(3)
                        End Select
                    End If
                Next

                'p_TongXuat = l_quantity(1)
                Select Case l_donvitinh
                    Case "L"
                        p_TongXuat = i_tongduxuat 'l_quantity(0)
                    Case "L15"
                        p_TongXuat = l_quantity(0)
                    Case "KG"
                        p_TongXuat = l_quantity(0)
                    Case Else
                        p_TongXuat = l_quantity(0)

                End Select

            Else
                l_quantity = mdlQCI_CalculateQCI(i_tongduxuat, i_wa.Unit, 15, 0.688)
                p_TongXuat = i_tongduxuat
            End If


            'Select Case l_donvitinh
            '    Case "L"
            '        p_TongXuat = l_quantity(0)
            '    Case "L15"
            '        p_TongXuat = l_quantity(1)
            '    Case "KG"
            '        p_TongXuat = l_quantity(3)
            '    Case Else
            '        p_TongXuat = l_quantity(2)

            'End Select

            If InsertQci(l_err, i_malenh, i_ngayxuat, i_wa.Item_Nd.ToString(), i_solenh, i_wa.Compartment.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3)) Then
                UpdateQci(l_err, i_solenh, i_wa.Compartment.ToString(), i_wa.Item_Nd.ToString(), l_quantity(0), l_quantity(1), l_quantity(2), l_quantity(3))
            End If
            p_BeXuat = ""
            p_Tank = ""

            'anhqh
            '20160628
            p_LoaiVanChuyen = UCase(GetLoadingSite(i_wa.Transmot))

            'anhqh  20160530
            If CheckHangHoaE5(l_mahanghoa) = True Then
                p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat), p_Client, p_LoaiVanChuyen)
                p_Tank = GetTankActiveE5(p_BeXuat, CDate(i_ngayxuat))
            Else
                p_BeXuat = GetTankActive(l_mahanghoa, CDate(i_ngayxuat), p_Client, p_LoaiVanChuyen)
                p_Tank = p_BeXuat
            End If

            '-----------------------------------------------------------------

            'anhqh   20160623
            'Ghep dac thu rieng cua KV1
            ' If g_Company_Code = "2110" Then

            ' p_TableID = GetTableIDKV1()
            ' End If
            'p_TableID = GetTableID()

            If g_KV1 = True Then
                p_CrdDate = CDate(i_ngayxuat)
                p_TableID = GetTableIDKV1(i_wa.Transmot.ToString(), p_CrdDate, l_mahanghoa)
            Else
                p_TableID = GetTableID()
            End If


            'Tinh so KG tai trong  =========================================================================
            p_SQL = "select ISNULL((select NhietDo from tblNhietDo with (Nolock) where  " & _
                "CONVERT(date,crDate)=(select MAX(crDate) from tblNhietDo with (Nolock) )),30) as NhietDo," & _
                 "ISNULL((select top 1 Dens_nd from FPT_tblTankActive_V where Date1 =CONVERT(date,getdate()) " & _
                 "and Name_nd ='" & p_Tank & "'),0.688) as TyTrong"
            p_DataTableCheck = GetDataTable(p_SQL, p_SQL)


            l_quantity2(0) = 0
            l_quantity2(1) = 0
            l_quantity2(2) = 0
            l_quantity2(3) = 0

            If Not p_DataTableCheck Is Nothing Then
                If p_DataTableCheck.Rows.Count > 0 Then
                    p_NhietDoTemp = p_DataTableCheck.Rows(0).Item("NhietDo")
                    p_TyTrongBe = p_DataTableCheck.Rows(0).Item("TyTrong")

                End If
            End If




            If p_BeXuat.ToString.Trim <> "" And p_LoaiVanChuyen = "BO" Then
                ' mdlQCI_CalculateQCI_NS("", p_SoLuong, "L", p_NhietDoN, IIf(p_DataRow(0).Item("TyTrong").ToString.Trim = "", 0.688, p_DataRow(0).Item("TyTrong").ToString.Trim))
                l_quantity2 = mdlQCI_CalculateQCI("", p_TongXuat, "L", p_NhietDoTemp, p_TyTrongBe)
            End If


            p_TaiTrongKg = 0 ' l_quantity2(3)
            'Tinh so KG tai trong  =========================================================================


            'p_SQL = "INSERT INTO [tblLenhXuat_HangHoaE5] (LineID, MaLenh,NgayXuat, SoLenh,TongXuat, " & _
            '    "TongDuXuat, MaHangHoa, DonViTinh,BeXuat,TableID ,Createby,CreateDate, QCI_KG, QCI_NhietDo, QCI_TyTrong) "
            'p_SQL = p_SQL & " VALUES ('" & i_wa.Item_Nd.ToString() & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & i_solenh & "'" & _
            '        "," & p_TongXuat & "," & i_tongduxuat & ",'" & l_mahanghoa & "','" & l_donvitinh & "','" & p_BeXuat & "','" & p_TableID & "'," & g_User_ID & ",getdate()" & _
            '        "," & p_TaiTrongKg & "," & p_NhietDoTemp & "," & p_TyTrongBe & ")"

            'p_DataRow = p_DataExec.NewRow
            'p_DataRow.Item(0) = p_SQL
            'p_DataExec.Rows.Add(p_DataRow)

            p_RowHangHoa = p_TableHangHoa.NewRow
            p_RowHangHoa.Item("TableID") = p_TableID
            p_RowHangHoa.Item("MaHangHoa") = l_mahanghoa
            p_RowHangHoa.Item("DonViTinh") = l_donvitinh
            p_RowHangHoa.Item("TongDuXuat") = i_tongduxuat
            p_RowHangHoa.Item("TongXuat") = p_TongXuat
            p_RowHangHoa.Item("BeXuat") = p_BeXuat
            p_RowHangHoa.Item("SoLenh") = i_solenh
            p_RowHangHoa.Item("MaLenh") = i_malenh
            p_RowHangHoa.Item("NgayXuat") = CDate(i_ngayxuat).ToString("yyyy/MM/dd")
            p_RowHangHoa.Item("LineID") = i_wa.Item_Nd.ToString()

            p_RowHangHoa.Item("NhietDo") = p_NhietDoTemp
            p_RowHangHoa.Item("TaiTrong") = p_TaiTrongKg
            p_RowHangHoa.Item("TyTrong") = p_TyTrongBe
            p_TableHangHoa.Rows.Add(p_RowHangHoa)

            'If p_TBLTABLEID_ZT = True Then
            '    p_SQL = "INSERT INTO [TBLTABLEID_ZT](NgayXuat,TableID) VALUES ('" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & p_TableID & "')"
            '    p_DataRow = p_DataExec.NewRow
            '    p_DataRow.Item(0) = p_SQL
            '    p_DataExec.Rows.Add(p_DataRow)
            'End If

        Catch ex As Exception
            KV1mdlSyncDeliveries_SubModifyFromWorkAreaLine_QCI = False
        End Try
    End Function


    Private Sub KV1_GenScriptfromTbl(ByVal p_Client As String, ByVal l_ztb2 As Connect2SapEx.LIPSO2Table, _
                                                           ByRef p_DataExec As DataTable, _
                                                           ByVal i_wa As Connect2SAP.Str_PhieuXuat, _
                                                           ByVal i_malenh As String, _
                                                           ByVal i_ngayxuat As String, _
                                                           ByVal i_solenh As String, _
                                                           ByVal i_tongxuat As Decimal, _
                                                           ByVal i_tongduxuat As Decimal, _
                                                           ByVal i_loaiphieu As String, _
                                                           ByVal i_tableid As String, _
                                                           ByRef p_TableHangHoa As System.Data.DataTable, _
                                                            Optional ByVal p_ChietKhau As Decimal = 0)
        Dim p_DataRow As DataRow
        Dim p_Count As Integer
        Dim p_SQL As String
        Dim p_TBLTABLEID_ZT As Boolean = False
        Dim p_TableID As String
        Dim p_BeXuat As String

        Dim p_CountQCI As Integer
        Dim p_TongXuat As Decimal

        Dim p_TaiTrongKg As Decimal
        Dim l_mahanghoa, l_donvitinh, p_NhietDoTemp, p_TyTrongBe As String

        Dim p_LoaiVanChuyen As String = ""

        Dim p_RowHangHoa As System.Data.DataRow

        Dim p_Tank As String

        Dim p_TableID_number As Integer

        If p_TableHangHoa.Rows.Count > 0 Then
            Integer.TryParse(p_TableHangHoa.Rows(0).Item("TableID").ToString.Trim, p_TableID_number)
            If p_TableID_number > 0 Then


                For p_Count = 0 To p_TableHangHoa.Rows.Count - 1
                    p_TableID_number = p_TableID_number + 1
                    p_TableID = p_TableID_number.ToString.Trim
                    If Len(p_TableID) = 7 Then
                        p_TableID = "0" & p_TableID
                    End If

                    '    p_TableHangHoa.Rows(p_Count).Item("TableID") = p_TableID
                    p_SQL = "INSERT INTO [tblLenhXuat_HangHoaE5] (ChietKhau, LineID, MaLenh,NgayXuat, SoLenh,TongXuat, " & _
                        "TongDuXuat, MaHangHoa, DonViTinh,BeXuat,TableID ,Createby,CreateDate, QCI_KG, QCI_NhietDo, QCI_TyTrong) "
                    p_SQL = p_SQL & " VALUES (" & p_ChietKhau & ",'" & p_TableHangHoa.Rows(p_Count).Item("LineID").ToString.Trim & "','" & _
                                p_TableHangHoa.Rows(p_Count).Item("MaLenh").ToString.Trim & "','" & _
                                CDate(p_TableHangHoa.Rows(p_Count).Item("NgayXuat").ToString.Trim).ToString("yyyyMMdd") & "','" & _
                                p_TableHangHoa.Rows(p_Count).Item("SoLenh").ToString.Trim & "'" & _
                            "," & p_TableHangHoa.Rows(p_Count).Item("TongXuat").ToString.Trim & "," & p_TableHangHoa.Rows(p_Count).Item("TongDuXuat").ToString.Trim & ",'" & _
                                p_TableHangHoa.Rows(p_Count).Item("MaHangHoa").ToString.Trim & "','" & _
                                p_TableHangHoa.Rows(p_Count).Item("DonViTinh").ToString.Trim & "','" & _
                                p_TableHangHoa.Rows(p_Count).Item("BeXuat").ToString.Trim & "','" & p_TableHangHoa.Rows(p_Count).Item("TableId").ToString.Trim & "'," & g_User_ID & ",getdate()" & _
                            "," & p_TableHangHoa.Rows(p_Count).Item("TaiTrong").ToString.Trim & "," & _
                            p_TableHangHoa.Rows(p_Count).Item("NhietDo").ToString.Trim & "," & p_TableHangHoa.Rows(p_Count).Item("TyTrong").ToString.Trim & ")"

                    p_DataRow = p_DataExec.NewRow
                    p_DataRow.Item(0) = p_SQL
                    p_DataExec.Rows.Add(p_DataRow)
                Next
            End If

        End If

    End Sub

    Function CheckHangHoaE5(ByVal p_MaHangHoa As String) As Boolean
        '  Dim p_Count As Integer
        ' Dim p_DataRow() As DataRow
        Dim p_SQL As String = "SELECT MaHangHoa  FROM [tblHangHoaE5]	where MaHangHoa='" & p_MaHangHoa & "'"
        Dim p_Table As DataTable
        CheckHangHoaE5 = False
        Try
            'If p_MaHangHoa = "0201001" Or p_MaHangHoa = "020202" Then
            '    Return True
            'End If
            p_Table = GetDataTable(p_SQL, p_SQL)

            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    Return True
                End If
            End If
            'p_DataRow = g_TableMaHangHoaE5.Select("MaHangHoa_Sap='" & p_MaHangHoa & "'")
            'If p_DataRow.Length > 0 Then
            '    Return True
            'End If
        Catch ex As Exception
            Return False
        End Try

    End Function


    Private Function UpdateQci(ByRef err As String, ByVal i_solenh As String, ByVal i_mangan As String, ByVal i_lineid As String, _
                                        ByVal i_L As Decimal, ByVal i_L15 As Decimal, ByVal i_M15 As Decimal, ByVal i_KG As Decimal) As Boolean

        Dim p_SQL As String = ""
        p_SQL = "UPDATE [tblQci] SET  [L] = " & i_L & ", [KG] =" & i_KG & ",  [L15] = " & i_L15 & ", [M15] = " & i_M15 & " " & _
                    " WHERE    [SoLenh]= '" & i_solenh & "' and    [LineId]= '" & i_lineid & "' and    [MaNgan]= '" & i_mangan & "'"
        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

        End If

    End Function

    Private Function InsertQci(ByRef err As String, _
                              ByVal i_malenh As String, _
                              ByVal i_ngayxuat As Date, _
                              ByVal i_lineid As String, _
                              ByVal i_solenh As String, _
                              ByVal i_mangan As String, _
                              ByVal i_L As Decimal, _
                              ByVal i_L15 As Decimal, _
                              ByVal i_M15 As Decimal, _
                              ByVal i_KG As Decimal) As Boolean

        Dim p_SQL As String = ""
        p_SQL = "INSERT INTO [tblQci] ( [MaLenh], [NgayXuat],[LineId],[SoLenh],[MaNgan],[L],[KG],[L15],[M15]) "
        p_SQL = p_SQL & " VALUES('" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & i_lineid & "'" & _
                ",'" & i_solenh & "','" & i_mangan & "'," & i_L & "," & i_KG & "," & i_L15 & "," & i_M15 & ")"

        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

        End If
    End Function


    Private Function GetTableID() As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable


        p_SQL = " exec " & p_FunctionTableId
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


    'anhqh 20160920
    Private Function GetTableIDKV1(ByVal p_MaVanChuyen As String, ByVal p_date As Date, ByVal p_HangHoa As String) As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_Int As Integer

        If p_MaVanChuyen = "ZR" Then
            p_SQL = " exec  FPT_GetTableID_KV1_NewNew '" & p_MaVanChuyen & "','" & p_date.ToString("yyyyMMdd") & "','" & p_HangHoa & "'"
        Else
            p_SQL = " exec  FPT_GetTableID_KV1_New '" & p_MaVanChuyen & "','" & p_date.ToString("yyyyMMdd") & "'"
        End If


        GetTableIDKV1 = ""
        Try
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTableIDKV1 = p_DataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
        Catch ex As Exception
            GetTableIDKV1 = ""
        End Try

    End Function

    'Private Function GetTableIDKV1(ByVal p_MaVanChuyen As String ) As String
    '    Dim p_SQL As String
    '    Dim p_DataTable As DataTable

    '    p_SQL = " exec  FPT_GetTableID_KV1 '" & p_MaVanChuyen & "'"

    '    GetTableIDKV1 = ""
    '    Try
    '        p_DataTable = GetDataTable(p_SQL, p_SQL)
    '        If Not p_DataTable Is Nothing Then
    '            If p_DataTable.Rows.Count > 0 Then
    '                GetTableIDKV1 = p_DataTable.Rows(0).Item(0).ToString.Trim
    '            End If
    '        End If
    '    Catch ex As Exception
    '        GetTableIDKV1 = ""
    '    End Try

    'End Function


    Private Function mdlSyncDeliveries_CheckMaLenh(ByVal i_malenh As String, ByVal i_ngayxuat As String) As Boolean
        '-----------------------------------------------------------------
        '   Kiểm tra mã lệnh sau khi tính toán
        '-----------------------------------------------------------------
        Dim l_malenh As String
        Dim l_malenh_check As Char()
        Dim l_check As String
        Dim l_err As String = String.Empty

        l_malenh = i_malenh

        If l_malenh = String.Empty Then
            Return False
        End If

        Try
            Convert.ToInt32(l_malenh)

            l_malenh_check = l_malenh.ToCharArray()
            For i As Integer = 0 To l_malenh_check.Length - 1

                If l_malenh_check(i).ToString().Trim() = "." Then
                    Return False
                End If
            Next
            '-----------------------------------------------------------------
            '   Kiểm tra có trong db chưa
            '-----------------------------------------------------------------
            'Dim l_bs As BSTransaction_new
            'l_bs = New BSTransaction_new

            l_check = CheckMaLenh(l_err, i_malenh, i_ngayxuat)

            If l_check.Trim = "1" Then
                Return False
            End If

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function

    '20200319
    'anhqh  sua them thong tin cap nhat vao bang LenhXuatE5
    Private Function mdlSyncDeliveries_SubModifyFromWorkArea(ByVal p_Client As String, ByRef p_DataExec As DataTable, ByVal i_wa As Connect2SAP.Str_PhieuXuat, _
                                                            ByVal i_malenh As String, _
                                                            ByVal i_ngayxuat As String, ByVal p_CompanyCode As String, ByRef p_Desc As String, ByVal p_DiemTraHang As String) As Boolean

        Dim l_solenh, _
            l_madonvi, _
            l_manguon, _
            l_makho, _
            l_mavanchuyen, _
            l_maphuongtien, _
            l_nguoivanchuyen, _
            l_maphuongthucban, _
            l_maphuongthucxuat, _
            l_makhachhang, _
            l_loaiphieu, _
            l_ngayhieuluc, _
            l_status, _
            l_STO _
            As String
        Dim l_number As Integer
        Dim p_Count As Integer
        Dim l_err As String
        Dim p_SQL As String
        Dim p_DataRow As DataRow
        ' Dim p_SQL As String
        Dim p_Table As System.Data.DataTable

        Dim p_Slog As String = ""
        Dim p_MaHangHoa As String = ""

        Dim NgayHetHieuLuc As Date

        Dim p_SoLenh_Do1 As String = ""
        Dim p_MaKhachDo1 As String = ""
        Dim p_MaNguonDo1 As String = ""
        Dim p_Batch_ND As String = ""
        Dim p_ConnectSapString = ""

        Dim p_TimeOut As String = "60"

        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_DataRowArr() As DataRow

        l_err = String.Empty

        Try

            ' i_wa
            ' i_wa.

            l_STO = i_wa.Saleorder.ToString.Trim()



            l_solenh = i_wa.Outbound.ToString()
            l_madonvi = p_CompanyCode
            'l_manguon = i_wa.Batch_Nd.ToString()
            l_manguon = i_wa.Resource_Nd.ToString()
            l_makho = i_wa.Plant.ToString()
            'l_mavanchuyen = i_wa.Veh_Mode.ToString()
            l_mavanchuyen = i_wa.Transmot.ToString()
            l_maphuongtien = i_wa.Vehicle.ToString()
            l_nguoivanchuyen = i_wa.Drivercode.ToString()
            l_maphuongthucban = i_wa.Method_Dc.ToString()
            l_maphuongthucxuat = i_wa.Method_Mt.ToString()
            l_makhachhang = i_wa.Customer.ToString()
            l_loaiphieu = i_wa.Shnumber.ToString()
            p_Slog = i_wa.Storage.ToString
            'anhqh
            '20160628
            p_MaHangHoa = Right(i_wa.Material.ToString(), 7)

            If l_loaiphieu = String.Empty Then
                l_loaiphieu = "V144"
                l_mavanchuyen = i_wa.Transmot.ToString()
            End If


            If g_KV1 = True Then
                If Mid(p_MaHangHoa, 1, 2) = "07" Then
                    'anhqh
                    '20160628
                    p_Client = "FO"
                End If
            End If


            'anhqh
            '20191101
            'Lay thong tin DO1 neu co
            p_SQL = "select * from tblConfig "
            'SapConnectionString, Timeout
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


            '20200319
            'SOType:     SOtype()
            'PRSDT: pricing date
            'INCO1:      Incoterm()
            'TKTX_Date: Ngày tờ khai tái xuất
            p_SQL = ""
            p_Table = p_ECCDestinationConfig.clsGet_DO2_Infor(l_solenh, p_SQL)
            Dim p_SOType, p_PRSDT, p_INCO1, p_TKTX_Date, p_KONDA, p_CreateDate, p_ChotLo, p_LOAI_KH, p_SO_CHUYEN, p_NOTE_SMO, p_SoTKTX As String
            If p_SQL <> "" Then

            End If
            p_SQL = ""
            p_SOType = ""
            p_PRSDT = ""
            p_INCO1 = ""
            p_TKTX_Date = ""
            p_KONDA = ""
            p_CreateDate = ""
            p_Batch_ND = ""
            p_ChotLo = ""
            p_LOAI_KH = ""
            p_SO_CHUYEN = ""
            p_NOTE_SMO = ""
            p_SoTKTX = ""
            g_NhomBeXuat = ""

            If p_Table Is Nothing Then
                If p_SQL <> "" Then
                    'p_Desc = p_SQL
                    '  Return False
                End If
            Else
                If p_Table.Rows.Count > 0 Then
                    p_DataRowArr = p_Table.Select("ParName='SOType'")
                    If p_DataRowArr.Length > 0 Then
                        p_SOType = p_DataRowArr(0).Item("ParValue").ToString.Trim
                    End If
                    p_DataRowArr = p_Table.Select("ParName='PRSDT'")
                    If p_DataRowArr.Length > 0 Then
                        p_PRSDT = p_DataRowArr(0).Item("ParValue").ToString.Trim
                        If p_PRSDT = "00000000" Then
                            p_PRSDT = ""
                        End If
                    End If
                    p_DataRowArr = p_Table.Select("ParName='INCO1'")
                    If p_DataRowArr.Length > 0 Then
                        p_INCO1 = p_DataRowArr(0).Item("ParValue").ToString.Trim
                    End If
                    p_DataRowArr = p_Table.Select("ParName='TKTX_Date'")
                    If p_DataRowArr.Length > 0 Then
                        p_TKTX_Date = p_DataRowArr(0).Item("ParValue").ToString.Trim
                        If p_TKTX_Date = "00000000" Then
                            p_TKTX_Date = ""
                        End If
                    End If
                    '20241110 bo sung cho kv2
                    p_DataRowArr = p_Table.Select("ParName='TKTX'")
                    If p_DataRowArr.Length > 0 Then
                        p_SoTKTX = p_DataRowArr(0).Item("ParValue").ToString.Trim
                    End If


                    '20241122 bo sung cho kv2                 
                    p_DataRowArr = p_Table.Select("ParName='NhomBeXuat'")
                    If p_DataRowArr.Length > 0 Then
                        g_NhomBeXuat = p_DataRowArr(0).Item("ParValue").ToString.Trim
                    End If



                    p_DataRowArr = p_Table.Select("ParName='KONDA'")
                    If p_DataRowArr.Length > 0 Then
                        p_KONDA = p_DataRowArr(0).Item("ParValue").ToString.Trim
                    End If

                    p_DataRowArr = p_Table.Select("ParName='CREATEDATE'")
                    If p_DataRowArr.Length > 0 Then
                        p_CreateDate = p_DataRowArr(0).Item("ParValue").ToString.Trim
                    End If


                    p_DataRowArr = p_Table.Select("ParName='BATCH_ND'")
                    If p_DataRowArr.Length > 0 Then
                        p_Batch_ND = p_DataRowArr(0).Item("ParValue").ToString.Trim
                    End If

                    p_DataRowArr = p_Table.Select("ParName='CHOTLO'")
                    If p_DataRowArr.Length > 0 Then
                        p_ChotLo = p_DataRowArr(0).Item("ParValue").ToString.Trim
                    End If

                    p_DataRowArr = p_Table.Select("ParName='LOAI_KH'")
                    If p_DataRowArr.Length > 0 Then
                        p_LOAI_KH = p_DataRowArr(0).Item("ParValue").ToString.Trim
                    End If

                    p_DataRowArr = p_Table.Select("ParName='SO_CHUYEN'")
                    If p_DataRowArr.Length > 0 Then
                        p_SO_CHUYEN = p_DataRowArr(0).Item("ParValue").ToString.Trim
                    End If

                    p_DataRowArr = p_Table.Select("ParName='NOTE_SMO'")
                    If p_DataRowArr.Length > 0 Then
                        p_NOTE_SMO = p_DataRowArr(0).Item("ParValue").ToString.Trim
                    End If

                End If
            End If

            If l_manguon = "N45" And p_ChotLo = "X" Then
                p_Desc = "Không phát hành tích kê với lệnh chốt lô nguồn N45"
                Return False
            End If

            If p_CreateDate = "" Then
                p_CreateDate = "getdate()"
            Else
                p_CreateDate = "'" & p_CreateDate & "'"
            End If

            p_SQL = ""
            p_Table = p_ECCDestinationConfig.clsGet_DO1_Infor(l_solenh, p_SQL)
            If p_Table Is Nothing Then
                If p_SQL <> "" Then
                    'p_Desc = p_SQL
                    ' Return False
                End If
            End If

            p_SQL = ""

            Try
                If p_Table.Rows.Count > 0 Then
                    'E_KUNNR
                    p_DataRowArr = p_Table.Select("ParName='E_KUNNR'")
                    If p_DataRowArr.Length > 0 Then
                        p_MaKhachDo1 = p_DataRowArr(0).Item("ParValue").ToString.Trim
                    End If
                    'E_DO
                    p_DataRowArr = p_Table.Select("ParName='E_DO'")
                    If p_DataRowArr.Length > 0 Then
                        p_SoLenh_Do1 = p_DataRowArr(0).Item("ParValue").ToString.Trim
                    End If
                    'E_BWTAR
                    p_DataRowArr = p_Table.Select("ParName='E_BWTAR'")
                    If p_DataRowArr.Length > 0 Then
                        p_MaNguonDo1 = p_DataRowArr(0).Item("ParValue").ToString.Trim
                    End If
                End If
            Catch ex As Exception

            End Try

            'anhqh  20160609
            'Them truong hop cau hinh cho KV1
            p_SQL = "SELECT * FROM SYS_CONFIG WHERE KEYCODE='" & l_mavanchuyen.ToString.Trim & "'"

            p_Table = GetDataTable(p_SQL, p_SQL)
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    p_Client = p_Table.Rows(0).Item("KEYVALUE").ToString.Trim
                End If

            End If

            'anhqh
            '20160630
            NgayHetHieuLuc = CDate("01/01/1900")

            l_ngayhieuluc = i_wa.Date_E_Nd
            ' l_ngayhieuluc = i_wa.Date_Nd

            If l_ngayhieuluc.ToString.Trim <> "00000000" And l_ngayhieuluc <> "" Then
                Try
                    NgayHetHieuLuc = CDate(Mid(l_ngayhieuluc, 5, 2) & "/" & Right(l_ngayhieuluc, 2) & "/" & Left(l_ngayhieuluc, 4))
                Catch ex As Exception

                End Try

            End If


            l_ngayhieuluc = i_wa.Date_Nd
            If l_ngayhieuluc.ToString.Trim <> "00000000" And l_ngayhieuluc <> "" Then
                Try
                    l_ngayhieuluc = Mid(l_ngayhieuluc, 5, 2) & "/" & Right(l_ngayhieuluc, 2) & "/" & Left(l_ngayhieuluc, 4)
                Catch ex As Exception

                End Try

            End If

            l_status = i_wa.Status.ToString()

            l_status = "1"
            l_number = 0
            p_SQL = ""

            'anhqh
            '20181017
            'lay lai ngay dem
            If p_LaiNgayDem = False Then
                If l_nguoivanchuyen = "" Then
                    p_SQL = "select HoVaTen , sDefault  from dbo.tblPhuongTien_LaiXe where Maphuongtien='" & l_maphuongtien & "'"
                    p_Table = GetDataTable(p_SQL, p_SQL)
                    If Not p_Table Is Nothing Then
                        If p_Table.Rows.Count > 0 Then
                            For p_Count = 0 To p_Table.Rows.Count - 1
                                If p_Table.Rows(p_Count).Item("sDefault").ToString.Trim = "Y" Then
                                    l_nguoivanchuyen = p_Table.Rows(p_Count).Item("HoVaTen").ToString.Trim
                                    Exit For
                                End If
                            Next
                            If l_nguoivanchuyen = "" Then
                                l_nguoivanchuyen = p_Table.Rows(0).Item("HoVaTen").ToString.Trim
                            End If
                        End If
                    End If
                End If
            End If



            If Check_SoLenh(l_err, l_solenh) = False Then   'Chua ton tai so lenh
                If NgayHetHieuLuc <> CDate("01/01/1900") Then
                    p_SQL = "INSERT INTO [tblLenhXuatE5] (NhomBeXuat,so_tktx, NOTE_SMO, SO_CHUYEN, LOAI_KH, BatchNum, DO1_MaNguon,CreateDate, PriceGroupDO1, SOType, PrcingDate, Inco1, Ngay_TKTX , DO1_SoLenh, DO1_MaKhach,STO, DiemTraHang, NgayHetHieuLuc, Slog, Client, SoLenhSAP,[MaLenh],[NgayXuat],[SoLenh],[MaDonVi],[MaNguon],[MaKho]," &
                    "[MaVanChuyen],[MaPhuongTien],[NguoiVanChuyen],[MaPhuongThucBan],[MaPhuongThucXuat]," &
                    "[MaKhachHang],[LoaiPhieu],[Niem],[LuongGiamDinh],[NhietDoTaiTau],[GhiChu],[NgayHieuLuc],[Status],[Number] ,Createby) "
                    p_SQL = p_SQL & " VALUES ('" & g_NhomBeXuat & "','" & p_SoTKTX & "',N'" & p_NOTE_SMO & "', '" & p_SO_CHUYEN & "', '" & p_LOAI_KH & "', '" & p_Batch_ND & "', '" & p_MaNguonDo1 & "'," & p_CreateDate & ",'" & p_KONDA & "','" & p_SOType & "'," & IIf(p_PRSDT <> "", "'" & p_PRSDT & "'", "NULL") & ", '" & p_INCO1 & _
                                "'," & IIf(p_TKTX_Date <> "", "'" & p_TKTX_Date & "'", "NULL") & ",  '" & p_SoLenh_Do1 & "','" & p_MaKhachDo1 & "','" & l_STO & "', N'" & p_DiemTraHang & "','" & CDate(NgayHetHieuLuc).ToString("yyyyMMdd") & "','" & p_Slog & "','" & p_Client & "','" & l_solenh & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & l_solenh & "','" & l_madonvi & "','" & l_manguon & "'" &
                            ",'" & l_makho & "','" & l_mavanchuyen & "','" & l_maphuongtien & "',N'" & l_nguoivanchuyen & "','" & l_maphuongthucban & "','" & l_maphuongthucxuat & "'" &
                            ",'" & l_makhachhang & "','" & l_loaiphieu & "','','','','','" & l_ngayhieuluc.ToString.Trim & "','" & l_status & "'," & l_number &
                            "," & g_User_ID & ")"
                Else
                    p_SQL = "INSERT INTO [tblLenhXuatE5] (NhomBeXuat, so_tktx, NOTE_SMO, SO_CHUYEN, LOAI_KH, BatchNum, DO1_MaNguon, CreateDate,PriceGroupDO1,SOType, PrcingDate, Inco1, Ngay_TKTX ,DO1_SoLenh, DO1_MaKhach,STO, DiemTraHang, NgayHetHieuLuc, Slog, Client, SoLenhSAP,[MaLenh],[NgayXuat],[SoLenh],[MaDonVi],[MaNguon],[MaKho]," &
                        "[MaVanChuyen],[MaPhuongTien],[NguoiVanChuyen],[MaPhuongThucBan],[MaPhuongThucXuat]," &
                        "[MaKhachHang],[LoaiPhieu],[Niem],[LuongGiamDinh],[NhietDoTaiTau],[GhiChu],[NgayHieuLuc],[Status],[Number] ,Createby) "
                    p_SQL = p_SQL & " VALUES ('" & g_NhomBeXuat & "','" & p_SoTKTX & "', 'N" & p_NOTE_SMO & "', '" & p_SO_CHUYEN & "', '" & p_LOAI_KH & "', '" & p_Batch_ND & "','" & p_MaNguonDo1 & "'," & p_CreateDate & ",'" & p_KONDA & "','" & p_SOType & "'," & IIf(p_PRSDT <> "", "'" & p_PRSDT & "'", "NULL") & ", '" & p_INCO1 & _
                            "', " & IIf(p_TKTX_Date <> "", "'" & p_TKTX_Date & "'", "NULL") & ", '" & p_SoLenh_Do1 & "','" & p_MaKhachDo1 & "','" & l_STO & "',N'" & p_DiemTraHang & "',null,'" & p_Slog & "','" & p_Client & "','" & l_solenh & "','" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & l_solenh & "','" & l_madonvi & "','" & l_manguon & "'" &
                            ",'" & l_makho & "','" & l_mavanchuyen & "','" & l_maphuongtien & "',N'" & l_nguoivanchuyen & "','" & l_maphuongthucban & "','" & l_maphuongthucxuat & "'" &
                            ",'" & l_makhachhang & "','" & l_loaiphieu & "','','','','','" & l_ngayhieuluc.ToString.Trim & "','" & l_status & "'," & l_number &
                            "," & g_User_ID & ")"
                End If

            Else  ''Da ton tai so lenh
                p_SQL = "UPDATE [dbo].[tblLenhXuatE5] SET  NhomBeXuat= '" & g_NhomBeXuat & "', so_tktx = '" & p_SoTKTX & "', DO1_MaNguon='" & p_MaNguonDo1 & "', PriceGroupDO1='" & p_KONDA & "', DO1_SoLenh ='" & p_SoLenh_Do1 & "', DO1_MaKhach ='" & p_MaKhachDo1 & "', STO='" & l_STO & "', DiemTraHang =N'" & p_DiemTraHang & "', NgayHetHieuLuc='" & CDate(NgayHetHieuLuc).ToString("yyyyMMdd") & "', Slog='" & p_Slog & "', Client='" & p_Client & "',MaDonVi = '" & l_madonvi & "',MaNguon = '" & l_manguon & "', MaKho ='" & l_makho & "'" &
                            ",MaVanChuyen = '" & l_mavanchuyen & "',MaPhuongTien='" & l_maphuongtien & "',NguoiVanChuyen=N'" & l_nguoivanchuyen & "',MaPhuongThucBan'" & l_maphuongthucban & "'" &
                            ",MaPhuongThucXuat='" & l_maphuongthucxuat & "',MaKhachHang='" & l_makhachhang & "',LoaiPhieu='" & l_loaiphieu & "'" &
                            ",NgayHieuLuc='" & l_ngayhieuluc.ToString.Trim & "',Status='" & l_status & "',Number=" & l_number & ", UpdatedBy=" & g_User_ID & ",UpdateDate=getdate() " &
                            " , SOType='" & p_SOType & "', PrcingDate =" & IIf(p_PRSDT <> "", "'" & p_PRSDT & "'", "NULL") & _
                                ", Inco1='" & p_INCO1 & "', Ngay_TKTX = " & IIf(p_TKTX_Date <> "", "'" & p_TKTX_Date & "'", "NULL") & " " & _
                            " WHERE SoLenh ='" & l_solenh & "'"
            End If


            If p_SQL <> "" Then
                p_DataRow = p_DataExec.NewRow
                p_DataRow.Item(0) = p_SQL
                p_DataExec.Rows.Add(p_DataRow)
            End If
            Return True
        Catch ex As Exception
            p_Desc = ex.Message
            Return False
        End Try
    End Function


    Private Function Check_SoLenh(ByRef err As String, ByVal i_SoLenh As String) As Boolean
        Dim p_DataTable As DataTable
        Dim p_Err As String
        Check_SoLenh = False
        'Return g_c2SQL.ExeNonQuery("sp_Check_SoLenhE5", err, New SqlParameter("@SoLenh", i_SoLenh))
        p_DataTable = GetDataTable("exec sp_Check_SoLenhE5 '" & i_SoLenh & "'", p_Err)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Check_SoLenh = True
            End If
        End If
    End Function



    Public Function mdlSyncDeliveries_DoListAuto(ByRef l_ztb As Connect2SapEx.Str_PhieuXuatTable, _
                                            ByVal i_SapConnectionstring As String, ByVal i_date As String, ByVal i_dateTo As String, _
                                             ByVal _ShPoint As String, ByVal i_TimeOut As String, ByRef o_table As DataTable, _
                                             ByRef o_err As String) As Boolean
        Dim l_c2sap As Connect2SapEx.Connect2Sap

        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_lasttime As Connect2SapEx.ZTB_INT_TIME '  Str_Time
        Dim l_now As Connect2SapEx.ZTB_INT_TIME   '   .Str_Time
        Dim l_err As String
        Dim l_f As Boolean = False
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_Row() As DataRow

        Dim p_Row1 As DataRow


        Dim p_Error As String
        Dim p_Count As Integer
        Dim pTable As DataTable


        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
        Dim p_ConnectSapString As String = ""
        Dim p_TimeOut As String = ""
        Dim p_SQL As String
        Dim p_table As DataTable

        'anhqh
        '20191101
        'Lay thong tin DO1 neu co
        p_SQL = "select * from tblConfig "
        'SapConnectionString, Timeout
        p_table = GetDataTable(p_SQL, p_SQL)
        If Not p_table Is Nothing Then
            If p_table.Rows.Count > 0 Then
                p_ConnectSapString = p_table.Rows(0).Item("SapConnectionString").ToString.Trim
                Try
                    p_TimeOut = p_table.Rows(0).Item("Timeout").ToString.Trim
                Catch ex As Exception

                End Try
                If p_TimeOut = "" Then
                    p_TimeOut = "60"
                End If
            End If
        End If
        p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_ConnectSapString, "EN", p_TimeOut, g_Company_Code)
        i_date = Replace(i_date, ".", "")
        i_dateTo = Replace(i_dateTo, ".", "")
        o_err = ""
        o_table = p_ECCDestinationConfig.clsGet_LenhXuatAuto(i_date, i_dateTo, o_err)

        If o_err = "" Then
            Return True
        Else
            Return False
        End If

        Exit Function


        l_ret2 = New Connect2SapEx.BAPIRET2()
        l_c2sap = New Connect2SapEx.Connect2Sap(i_SapConnectionstring)  '(_SAPConnectionString_bxtd)
        If l_ztb Is Nothing Then
            l_ztb = New Connect2SapEx.Str_PhieuXuatTable
            Exit Function
        End If
        'l_ztb = New Connect2SapEx.Str_PhieuXuatTable()
        l_err = String.Empty
        '-----------------------------------------------------------------
        'Kiểm tra kết nối với SAP xem có lấy đc dữ liệu ko
        '-----------------------------------------------------------------
        Try
            l_c2sap.Connection.Open()
        Catch ex As Exception
            l_c2sap.Dispose()
            o_err = ex.Message
            Return False
        End Try
        '-----------------------------------------------------------------
        '   Nếu dữ liệu lấy ra mà không có => Không hợp lệ
        '   Nếu dữ liệu lấy ra mà khác Shipping Point => Không hợp lệ
        '-----------------------------------------------------------------
        Try
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_lasttime = New Connect2SapEx.ZTB_INT_TIME
            l_now = New Connect2SapEx.ZTB_INT_TIME
            l_lasttime.Lastdate = i_date
            l_lasttime.Lasttime = "00:00:00"
            'l_now.
            l_now.Lastdate = i_dateTo
            l_now.Lasttime = "23:59:59"
            If i_TimeOut = "25" Then
                ' l_c2sap.GetDoList(l_lasttime, l_now, _ShPoint, l_ztb, l_ret2)
                l_c2sap.GetDoList(l_lasttime, l_now, g_Company_Code, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetDoList(l_lasttime, l_now, _ShPoint, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(i_TimeOut, False)
                If l_isCompleted Then
                    l_c2sap.EndGetDoList(l_async, l_ztb, l_ret2)
                End If
            End If
            If l_ztb.Count > 0 Then
                o_table = l_ztb.ToADODataTable()
                '    o_table.Clear()
                '  pTable = l_ztb.ToADODataTable()
                '  For p_Count = pTable.Rows.Count - 1 To 0 Step -1

                If Check_SoLenh(p_Error, o_table.Rows(p_Count).Item("Order_No").ToString.Trim) = True Then
                    o_table.Rows.RemoveAt(p_Count)
                    'Else
                    '    p_Row1 = o_table.NewRow
                    '    p_Row1 = pTable.Rows(p_Count)
                    '    o_table.Rows.Add(p_Row1)
                End If
                'Next
                Return True
            Else
                ' o_err = "Không có lệnh xuất"
                o_err = ""
                Return False
            End If
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()
            Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try
    End Function


    Public Function mdlSyncDeliveries_DoList(ByVal i_SapConnectionstring As String, ByVal i_date As String, _
                                             ByVal _ShPoint As String, ByVal i_TimeOut As String, ByRef o_table As DataTable, _
                                             ByRef o_err As String) As Boolean
        Dim l_c2sap As Connect2SapEx.Connect2Sap

        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_lasttime As Connect2SapEx.ZTB_INT_TIME '  Str_Time
        Dim l_now As Connect2SapEx.ZTB_INT_TIME   '   .Str_Time
        Dim l_err As String
        Dim l_f As Boolean = False
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean

        Dim p_Error As String
        Dim p_Count As Integer

        l_ret2 = New Connect2SapEx.BAPIRET2()
        l_c2sap = New Connect2SapEx.Connect2Sap(i_SapConnectionstring)  '(_SAPConnectionString_bxtd)
        l_ztb = New Connect2SapEx.Str_PhieuXuatTable()
        l_err = String.Empty
        '-----------------------------------------------------------------
        'Kiểm tra kết nối với SAP xem có lấy đc dữ liệu ko
        '-----------------------------------------------------------------
        Try
            l_c2sap.Connection.Open()
        Catch ex As Exception
            l_c2sap.Dispose()
            o_err = "m038"
            Return False
        End Try
        '-----------------------------------------------------------------
        '   Nếu dữ liệu lấy ra mà không có => Không hợp lệ
        '   Nếu dữ liệu lấy ra mà khác Shipping Point => Không hợp lệ
        '-----------------------------------------------------------------
        Try
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_lasttime = New Connect2SapEx.ZTB_INT_TIME
            l_now = New Connect2SapEx.ZTB_INT_TIME
            l_lasttime.Lastdate = i_date
            l_lasttime.Lasttime = "00:00:00"
            'l_now.
            l_now.Lastdate = i_date
            l_now.Lasttime = "23:59:59"
            If i_TimeOut = "25" Then
                ' l_c2sap.GetDoList(l_lasttime, l_now, _ShPoint, l_ztb, l_ret2)
                l_c2sap.GetDoList(l_lasttime, l_now, g_Company_Code, l_ztb, l_ret2)
            Else
                l_async = l_c2sap.BeginGetDoList(l_lasttime, l_now, _ShPoint, l_ztb, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(i_TimeOut, False)
                If l_isCompleted Then
                    l_c2sap.EndGetDoList(l_async, l_ztb, l_ret2)
                End If
            End If
            If l_ztb.Count > 0 Then
                o_table = l_ztb.ToADODataTable()

                For p_Count = o_table.Rows.Count - 1 To 0 Step -1
                    If Check_SoLenh(p_Error, o_table.Rows(p_Count).Item("Order_No").ToString.Trim) = True Then
                        o_table.Rows.RemoveAt(p_Count)
                    End If
                Next
                Return True
            Else
                o_err = "Không có lệnh xuất"
                Return False
            End If
            l_c2sap.Connection.Close()
            l_c2sap.Dispose()
            Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try
    End Function


    Public Function mdlTestConnectSAP(ByVal p_Connect As Boolean, ByVal p_ASHOST As String, ByVal p_SYSNR As String, ByVal p_Client As String, _
                                    ByVal p_User As String, ByVal p_Pass As String, ByRef p_Desc As String) As Boolean
        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim i_SapConnectionstring As String
        Dim p_SQL As String
        i_SapConnectionstring = "ASHOST=" & p_ASHOST & ";SYSNR=" & p_SYSNR & _
                            ";CLIENT=" & p_Client & ";USER=" & p_User & ";PASSWD=" & p_Pass

        If p_Connect = True Then
            l_c2sap = New Connect2SapEx.Connect2Sap(i_SapConnectionstring)  '(_SAPConnectionString_bxtd)
            '-----------------------------------------------------------------
            'Kiểm tra kết nối với SAP xem có lấy đc dữ liệu ko
            '-----------------------------------------------------------------
            Try
                l_c2sap.Connection.Open()
                l_c2sap.Connection.Close()
            Catch ex As Exception
                p_Desc = ex.Message
                l_c2sap.Dispose()
                Return False
            End Try
        Else
            p_SQL = "update tblConfig set sapconnectionstring='" & i_SapConnectionstring & "'"
            If g_Services.Sys_Execute(p_SQL, _
                                          p_Desc) = False Then
                Return False
            End If
        End If

        Return True
    End Function


    'Private 
    'hieptd4 add 20161102
    Public Function mdlSyncDeliveries_SynSpecific_Ex(ByVal p_Client As String, ByVal p_User_ID As Integer, _
                                                    ByVal p_Company_Code As String, ByVal i_solenh As String, ByRef o_err As String) As Boolean

        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb_hd As Connect2SapEx.STR_HEADER_THNTable
        Dim l_ztb_it As Connect2SapEx.STR_ITEM_THNTable
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_err As String
        Dim l_f As Boolean = False

        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String
        Dim p_TableConfig As DataTable
        Dim p_TableConfig1 As DataTable
        Dim p_SapConnectionString As String = ""
        Dim p_TimeOut = New TimeSpan()
        Dim p_WareHouse As String = ""
        Dim p_ShPoint As String = ""
        Dim p_DataRowArr() As DataRow

        Dim p_DataSet As New DataSet
        Dim p_Batch As String
        Dim p_Slog As String
        Dim p_MaKhachHang As String
        Dim p_StringTmp As String = "0000000000"
        Dim p_SoLenh As String
        Dim p_Table As DataTable
        Dim p_DiemTraHang As String

        Dim p_Count As Integer
        Dim l_dem As Integer = 0
        Dim p_DataTablExe As New DataTable("Table001")
        Dim p_Row As DataRow

        'anhqh
        '20170822
        'them rieng phan nay lay theo interface moi cua VinhND
        'hien them vao neu không lôi khi chưa chuyển Interface lên Prod của SAP


        If mdlSyncDeliveries_SynSpecific_ExNew(p_Client, p_User_ID, p_Company_Code, i_solenh, o_err) = True Then
            Return True
        End If

        g_Company_Code = p_Company_Code

        'If p_DataTablExe Is Nothing Then
        p_DataTablExe = New DataTable("Table001")
        p_DataTablExe.Columns.Add("STR_SQL")
        'End If

        mdlSyncDeliveries_SynSpecific_Ex = False
        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG; select * from tblConfig;"
        p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

        g_KV1 = False

        g_User_ID = p_User_ID


        g_BATCHSLOG = False

        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_TableConfig = p_DataSet.Tables(0)
                p_TableConfig1 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_DataRowArr = p_TableConfig.Select("KEYCODE='TABLEID'")
                If p_DataRowArr.Length > 0 Then
                    p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='QUYDOI_SAP'")
                If p_DataRowArr.Length > 0 Then
                    p_QUYDOI_SAP = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KV1'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_KV1 = True
                    Else
                        g_KV1 = False
                    End If
                End If


                p_DataRowArr = p_TableConfig.Select("KEYCODE='BATCHSLOG'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_BATCHSLOG = True
                    Else
                        g_BATCHSLOG = False
                    End If
                End If



            End If
        End If



        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                p_SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If
        If p_SapConnectionString = "" Then
            mdlSyncDeliveries_SynSpecific_Ex = True
            MsgBox("Loi ket noi")
            Exit Function
        End If



        Try
            l_c2sap = New Connect2SapEx.Connect2Sap(p_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_ztb_hd = New Connect2SapEx.STR_HEADER_THNTable()
            l_ztb_it = New Connect2SapEx.STR_ITEM_THNTable()

            ' l_ztb As Connect2SapEx.LIPSO2Table
            l_err = String.Empty



            If p_TableConfig1.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
                l_c2sap.GetDO_THN(i_solenh, l_ztb_hd, l_ztb_it, l_ret2)

            Else
                l_async = l_c2sap.BeginGetDO_THN(i_solenh, l_ztb_hd, l_ztb_it, Nothing, l_c2sap)
                l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                If l_isCompleted Then
                    l_c2sap.EndGetDO_THN(l_async, l_ztb_hd, l_ztb_it, l_ret2)
                End If
            End If


            l_dem = 0
            If l_ztb_hd.Count > 0 Then
                For i As Integer = 0 To l_ztb_hd.Count - 1
                    If l_ztb_hd.Item(i).Guebg.ToString() = "00000000" Then
                        l_ztb_hd.Item(i).Guebg = ""
                    End If
                    If l_ztb_hd.Item(i).Lddate.ToString() = "00000000" Then
                        l_ztb_hd.Item(i).Lddate = ""
                    End If
                    If l_ztb_hd.Item(i).Kurrf <> 0 Then
                        'l_ztb_hd.Item(i).Kurrf = 21.23
                        l_ztb_hd.Item(i).Kurrf = l_ztb_hd.Item(i).Kurrf * 1000
                    End If
                    p_SQL = "MERGE tblDO_Header AS target " & _
                        " USING (SELECT '" & Replace(l_ztb_hd.Item(i).Vbeln.ToString(), "'", "", 1) & "' as SoLenh ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Customer.ToString(), "'", "", 1) & "'  as MaKhachHang ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Long_Name.ToString(), "'", "", 1) & "'  as TenKhachHang ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Adress.ToString(), "'", "", 1) & "'  as DiaChiKH ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Contract.ToString(), "'", "", 1) & "'  as SoHopDong ," & _
                            IIf(l_ztb_hd.Item(i).Guebg.ToString.Trim = "", "null", "'" & l_ztb_hd.Item(i).Guebg.ToString() & "'") & "  as NgayHopDong ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Werks.ToString(), "'", "", 1) & "'  as MaKhoXuat ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Name1.ToString(), "'", "", 1) & "'  as TenKhoXuat ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Knota.ToString(), "'", "", 1) & "'  as LoadingPoint ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Loading_Point.ToString(), "'", "", 1) & "'  as DesLoadingPoint ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Knotz.ToString(), "'", "", 1) & "'  as DischargePoint ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Discharg_Point.ToString(), "'", "", 1) & "'  as DesDischargePoint ," & _
                                  Replace(l_ztb_hd.Item(i).Vat.ToString(), "'", "", 1) & "  as VAT ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Unit.ToString(), "'", "", 1) & "'  as DVT ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Zlsch.ToString(), "'", "", 1) & "'  as PaymentMethod ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Text1.ToString(), "'", "", 1) & "'  as DesPaymentMethod ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Zterm.ToString(), "'", "", 1) & "'  as Term ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Vtext.ToString(), "'", "", 1) & "'  as DesTerm ," & _
                                  Replace(l_ztb_hd.Item(i).Kurrf.ToString(), "'", "", 1) & "  as TyGia ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Tk_Number.ToString(), "'", "", 1) & "'  as SoTKHQNhap ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Tktx.ToString(), "'", "", 1) & "'  as SoTKHQXuat ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Carrier.ToString(), "'", "", 1) & "'  as MaNhaCungCap ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Lifnr_Name.ToString(), "'", "", 1) & "'  as TenNhaCungCap ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Route.ToString(), "'", "", 1) & "'  as MaTuyenDuong ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Werks_Nhap.ToString(), "'", "", 1) & "'  as MaKhoNhap ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Kho_Nhap.ToString(), "'", "", 1) & "'  as TenKhoNhap ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Phieu_Xuat.ToString(), "'", "", 1) & "'  as SoPXK ," & _
                        IIf(l_ztb_hd.Item(i).Lddate.ToString.Trim = "", "null", "'" & l_ztb_hd.Item(i).Lddate.ToString() & "'") & "  as NgayPXK " & _
                                " ) AS source (SoLenh,MaKhachHang,TenKhachHang,DiaChiKH,SoHopDong,NgayHopDong,MaKhoXuat,TenKhoXuat,LoadingPoint,DesLoadingPoint,DischargePoint," & _
                                "DesDischargePoint,VAT,DVT,PaymentMethod,DesPaymentMethod,Term,DesTerm,TyGia,SoTKHQNhap,SoTKHQXuat,MaNhaCungCap,TenNhaCungCap,MaTuyenDuong,MaKhoNhap,TenKhoNhap,SoPXK,NgayPXK ) " & _
                                " ON (target.SoLenh = source.SoLenh)" & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "MaKhachHang=source.MaKhachHang , " & _
                                    "TenKhachHang=source.TenKhachHang ," & _
                                    "DiaChiKH=source.DiaChiKH ," & _
                                    "SoHopDong=source.SoHopDong ," & _
                                    "NgayHopDong=source.NgayHopDong ," & _
                                    "MaKhoXuat=source.MaKhoXuat ," & _
                                    "TenKhoXuat=source.TenKhoXuat ," & _
                                    "LoadingPoint=source.LoadingPoint ," & _
                                    "DesLoadingPoint=source.DesLoadingPoint ," & _
                                    "DischargePoint=source.DischargePoint ," & _
                                    "DesDischargePoint=source.DesDischargePoint ," & _
                                    "VAT=source.VAT ," & _
                                    "DVT=source.DVT ," & _
                                    "PaymentMethod=source.PaymentMethod ," & _
                                    "DesPaymentMethod=source.DesPaymentMethod ," & _
                                    "Term=source.Term ," & _
                                    "DesTerm=source.DesTerm ," & _
                                    "TyGia=source.TyGia ," & _
                                    "SoTKHQNhap=source.SoTKHQNhap ," & _
                                    "SoTKHQXuat=source.SoTKHQXuat ," & _
                                    "MaNhaCungCap=source.MaNhaCungCap ," & _
                                    "TenNhaCungCap=source.TenNhaCungCap ," & _
                                    "MaTuyenDuong=source.MaTuyenDuong ," & _
                                    "MaKhoNhap=source.MaKhoNhap ," & _
                                    "TenKhoNhap=source.TenKhoNhap ," & _
                                    "SoPXK=source.SoPXK ," & _
                                    "NgayPXK=source.NgayPXK " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (SoLenh,MaKhachHang,TenKhachHang,DiaChiKH,SoHopDong,NgayHopDong,MaKhoXuat,TenKhoXuat,LoadingPoint,DesLoadingPoint,DischargePoint,DesDischargePoint,VAT,DVT,PaymentMethod,DesPaymentMethod,Term,DesTerm,TyGia,SoTKHQNhap,SoTKHQXuat,MaNhaCungCap,TenNhaCungCap,MaTuyenDuong,MaKhoNhap,TenKhoNhap,SoPXK,NgayPXK ) " & _
                            "VALUES (source.SoLenh,source.MaKhachHang,source.TenKhachHang,source.DiaChiKH,source.SoHopDong,source.NgayHopDong,source.MaKhoXuat,source.TenKhoXuat,source.LoadingPoint,source.DesLoadingPoint,source.DischargePoint,source.DesDischargePoint,source.VAT,source.DVT,source.PaymentMethod,source.DesPaymentMethod,source.Term,source.DesTerm,source.TyGia,source.SoTKHQNhap,source.SoTKHQXuat,source.MaNhaCungCap,source.TenNhaCungCap,source.MaTuyenDuong,source.MaKhoNhap,source.TenKhoNhap,source.SoPXK,source.NgayPXK ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If
            'If p_DataTablExe.Rows.Count > 0 Then
            '    If g_Services.Sys_Execute_DataTbl(p_DataTablExe, p_SQL) = False Then
            '        Exit Function
            '    End If
            'End If
            'p_DataTablExe.Clear()

            l_dem = 0
            If l_ztb_it.Count > 0 Then
                For i As Integer = 0 To l_ztb_it.Count - 1
                    'If l_ztb_it.Item(i).Koein.ToString() = "VND" Then  'da xu ly tren SAP
                    '    l_ztb_it.Item(i).Kbetr = l_ztb_it.Item(i).Kbetr * 100
                    'End If
                    'Replace(l_ztb_it.Item(i).Kbetr.ToString(), "'", "", 1) & "  as DonGia ," & _

                    p_SQL = "MERGE tblDO_Item_Material AS target " & _
                        " USING (SELECT '" & Replace(l_ztb_it.Item(i).Vbeln.ToString(), "'", "", 1) & "' as SoLenh ," & _
                                  Replace(l_ztb_it.Item(i).Posnr.ToString(), "'", "", 1) & "  as LineID ," & _
                    IIf(l_ztb_it.Item(i).Koein.ToString.Trim() <> "VND", Replace(l_ztb_it.Item(i).Zz_Kbetr.ToString(), "'", "", 1), Replace(l_ztb_it.Item(i).Kbetr.ToString(), "'", "", 1)) & "  as DonGia ," & _
                                  "'" & Replace(l_ztb_it.Item(i).Koein.ToString(), "'", "", 1) & "'  as CurrencyKey " & _
                                " ) AS source (SoLenh, LineID, DonGia, CurrencyKey ) " & _
                                " ON (target.SoLenh = source.SoLenh and " & _
                                    " target.LineID = source.LineID ) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "DonGia=source.DonGia , " & _
                                    "CurrencyKey=source.CurrencyKey " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (SoLenh, LineID, DonGia, CurrencyKey) " & _
                            "VALUES (source.SoLenh, source.LineID, source.DonGia, source.CurrencyKey ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If


            p_SQL = "exec FPT_UpdateDO '" & i_solenh & "'"
            p_Row = p_DataTablExe.NewRow
            p_Row.Item(0) = p_SQL
            p_DataTablExe.Rows.Add(p_Row)

            If p_DataTablExe.Rows.Count > 0 Then
                If g_Services.Sys_Execute_DataTbl(p_DataTablExe, p_SQL) = False Then
                    Return False
                    Exit Function
                End If
            End If
            p_DataTablExe.Clear()

            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True

        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try


    End Function




    'Private 
    'anhqh
    '20170822
    'Ham bo sung mới theo Interface mới VinhND gửi ngày 22-08-2017
    Public Function mdlSyncDeliveries_SynSpecific_ExNew(ByVal p_Client As String, ByVal p_User_ID As Integer, _
                                                    ByVal p_Company_Code As String, ByVal i_solenh As String, ByRef o_err As String) As Boolean

        Dim l_c2sap As Connect2SapEx.Connect2Sap
        Dim l_ztb_hd As Connect2SapEx.STR_HEADER_THN2Table
        Dim l_ztb_it As Connect2SapEx.STR_ITEM_THNTable
        Dim l_ret2 As Connect2SapEx.BAPIRET2
        Dim l_err As String
        Dim l_f As Boolean = False
        ' Dim p_Table As DataTable
        Dim l_async As IAsyncResult
        Dim l_isCompleted As Boolean
        Dim p_SQL As String
        Dim p_TableConfig As DataTable
        Dim p_TableConfig1 As DataTable
        Dim p_SapConnectionString As String = ""
        Dim p_TimeOut = New TimeSpan()
        Dim p_WareHouse As String = ""
        Dim p_ShPoint As String = ""
        Dim p_DataRowArr() As DataRow

        Dim p_DataSet As New DataSet
        Dim p_Batch As String
        Dim p_Slog As String
        Dim p_MaKhachHang As String
        Dim p_StringTmp As String = "0000000000"
        Dim p_SoLenh As String
        Dim p_Table As DataTable
        Dim p_DiemTraHang As String

        Dim p_Count As Integer
        Dim l_dem As Integer = 0
        Dim p_DataTablExe As New DataTable("Table001")
        Dim p_Row As DataRow


        Dim p_SoLenh_DO1 As String = ""

        g_Company_Code = p_Company_Code

        p_SQL = "select DO1_SoLenh from tblLenhXuatE5 where SoLenh ='" & i_solenh & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_SoLenh_DO1 = p_Table.Rows(0).Item(0).ToString.Trim
            End If
        End If

        If p_SoLenh_DO1 = "" Then
            p_SoLenh_DO1 = i_solenh
        End If
        'If p_DataTablExe Is Nothing Then
        p_DataTablExe = New DataTable("Table001")
        p_DataTablExe.Columns.Add("STR_SQL")
        'End If

        mdlSyncDeliveries_SynSpecific_ExNew = False
        p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG; select * from tblConfig;"
        p_DataSet = g_Services.Sys_SYS_GET_DATASET_Des(p_SQL, p_SQL)

        g_KV1 = False

        g_User_ID = p_User_ID


        g_BATCHSLOG = False

        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_TableConfig = p_DataSet.Tables(0)
                p_TableConfig1 = p_DataSet.Tables(1)
            End If
        End If
        If Not p_TableConfig Is Nothing Then
            If p_TableConfig.Rows.Count > 0 Then
                p_DataRowArr = p_TableConfig.Select("KEYCODE='TABLEID'")
                If p_DataRowArr.Length > 0 Then
                    p_FunctionTableId = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='QUYDOI_SAP'")
                If p_DataRowArr.Length > 0 Then
                    p_QUYDOI_SAP = p_DataRowArr(0).Item("KEYVALUE").ToString.Trim
                End If

                p_DataRowArr = p_TableConfig.Select("KEYCODE='KV1'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_KV1 = True
                    Else
                        g_KV1 = False
                    End If
                End If


                p_DataRowArr = p_TableConfig.Select("KEYCODE='BATCHSLOG'")
                If p_DataRowArr.Length > 0 Then
                    If p_DataRowArr(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                        g_BATCHSLOG = True
                    Else
                        g_BATCHSLOG = False
                    End If
                End If



            End If
        End If



        If Not p_TableConfig1 Is Nothing Then
            If p_TableConfig1.Rows.Count > 0 Then
                p_SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
            End If

        End If
        If p_SapConnectionString = "" Then
            mdlSyncDeliveries_SynSpecific_ExNew = True
            MsgBox("Loi ket noi")
            Exit Function
        End If



        Try
            l_c2sap = New Connect2SapEx.Connect2Sap(p_SapConnectionString)
            l_ret2 = New Connect2SapEx.BAPIRET2()
            l_ztb_hd = New Connect2SapEx.STR_HEADER_THN2Table
            l_ztb_it = New Connect2SapEx.STR_ITEM_THNTable()

            ' l_ztb As Connect2SapEx.LIPSO2Table
            l_err = String.Empty

            Try
                If p_TableConfig1.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
                    ' l_c2sap.GetDO_THN2(p_SoLenh_DO1, l_ztb_hd, l_ztb_it, l_ret2)
                    l_c2sap.GetDO_THN2(i_solenh, l_ztb_hd, l_ztb_it, l_ret2)
                Else
                    l_async = l_c2sap.BeginGetDO_THN2(i_solenh, l_ztb_hd, l_ztb_it, Nothing, l_c2sap)
                    l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

                    If l_isCompleted Then
                        l_c2sap.EndGetDO_THN2(l_async, l_ztb_hd, l_ztb_it, l_ret2)
                    End If
                End If
            Catch ex1 As Exception
                o_err = ex1.Message
                Return False
            End Try

            'If p_TableConfig1.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
            '    l_c2sap.GetDO_THN(i_solenh, l_ztb_hd, l_ztb_it, l_ret2)

            'Else
            '    l_async = l_c2sap.BeginGetDO_THN(i_solenh, l_ztb_hd, l_ztb_it, Nothing, l_c2sap)
            '    l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

            '    If l_isCompleted Then
            '        l_c2sap.EndGetDO_THN(l_async, l_ztb_hd, l_ztb_it, l_ret2)
            '    End If
            'End If

            '  l_ztb_hd(0).Tktx
            'l_ztb_hd(0).Tk_Number
            'l_ztb_hd(0).

            l_dem = 0
            If l_ztb_hd.Count > 0 Then
                For i As Integer = 0 To l_ztb_hd.Count - 1
                    If l_ztb_hd.Item(i).Guebg.ToString() = "00000000" Then
                        l_ztb_hd.Item(i).Guebg = ""
                    End If
                    If l_ztb_hd.Item(i).Lddate.ToString() = "00000000" Then
                        l_ztb_hd.Item(i).Lddate = ""
                    End If
                    If l_ztb_hd.Item(i).Kurrf <> 0 Then
                        'l_ztb_hd.Item(i).Kurrf = 21.23
                        l_ztb_hd.Item(i).Kurrf = l_ztb_hd.Item(i).Kurrf * 1000
                    End If

                    'anhqh 20210111 thay truong  Replace(l_ztb_hd.Item(i).Vbeln.ToString(), "'", "", 1)  thanh bien i_solenh
                    p_SQL = "MERGE tblDO_Header AS target " & _
                        " USING (SELECT  '" & Replace(l_ztb_hd.Item(i).Bsart.ToString(), "'", "", 1) & "' as BSART, " & _
                                "'" & i_solenh & "' as SoLenh ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Customer.ToString(), "'", "", 1) & "'  as MaKhachHang ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Long_Name.ToString(), "'", "", 1) & "'  as TenKhachHang ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Adress.ToString(), "'", "", 1) & "'  as DiaChiKH ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Contract.ToString(), "'", "", 1) & "'  as SoHopDong ," & _
                            IIf(l_ztb_hd.Item(i).Guebg.ToString.Trim = "", "null", "'" & l_ztb_hd.Item(i).Guebg.ToString() & "'") & "  as NgayHopDong ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Werks.ToString(), "'", "", 1) & "'  as MaKhoXuat ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Name1.ToString(), "'", "", 1) & "'  as TenKhoXuat ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Knota.ToString(), "'", "", 1) & "'  as LoadingPoint ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Loading_Point.ToString(), "'", "", 1) & "'  as DesLoadingPoint ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Knotz.ToString(), "'", "", 1) & "'  as DischargePoint ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Discharg_Point.ToString(), "'", "", 1) & "'  as DesDischargePoint ," & _
                                  Replace(l_ztb_hd.Item(i).Vat.ToString(), "'", "", 1) & "  as VAT ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Unit.ToString(), "'", "", 1) & "'  as DVT ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Zlsch.ToString(), "'", "", 1) & "'  as PaymentMethod ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Text1.ToString(), "'", "", 1) & "'  as DesPaymentMethod ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Zterm.ToString(), "'", "", 1) & "'  as Term ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Vtext.ToString(), "'", "", 1) & "'  as DesTerm ," & _
                                  Replace(l_ztb_hd.Item(i).Kurrf.ToString(), "'", "", 1) & "  as TyGia ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Tk_Number.ToString(), "'", "", 1) & "'  as SoTKHQNhap ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Tktx.ToString(), "'", "", 1) & "'  as SoTKHQXuat ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Carrier.ToString(), "'", "", 1) & "'  as MaNhaCungCap ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Lifnr_Name.ToString(), "'", "", 1) & "'  as TenNhaCungCap ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Route.ToString(), "'", "", 1) & "'  as MaTuyenDuong ," & _
                                  "'" & Replace(l_ztb_hd.Item(i).Werks_Nhap.ToString(), "'", "", 1) & "'  as MaKhoNhap ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Kho_Nhap.ToString(), "'", "", 1) & "'  as TenKhoNhap ," & _
                                  "N'" & Replace(l_ztb_hd.Item(i).Phieu_Xuat.ToString(), "'", "", 1) & "'  as SoPXK ," & _
                        IIf(l_ztb_hd.Item(i).Lddate.ToString.Trim = "", "null", "'" & l_ztb_hd.Item(i).Lddate.ToString() & "'") & "  as NgayPXK " & _
                                " ) AS source (BSART, SoLenh,MaKhachHang,TenKhachHang,DiaChiKH,SoHopDong,NgayHopDong,MaKhoXuat,TenKhoXuat,LoadingPoint,DesLoadingPoint,DischargePoint,DesDischargePoint,VAT,DVT,PaymentMethod,DesPaymentMethod,Term,DesTerm,TyGia,SoTKHQNhap,SoTKHQXuat,MaNhaCungCap,TenNhaCungCap,MaTuyenDuong,MaKhoNhap,TenKhoNhap,SoPXK,NgayPXK ) " & _
                                " ON (target.SoLenh = source.SoLenh)" & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "BSART=source.BSART , " & _
                                    "MaKhachHang=source.MaKhachHang , " & _
                                    "TenKhachHang=source.TenKhachHang ," & _
                                    "DiaChiKH=source.DiaChiKH ," & _
                                    "SoHopDong=source.SoHopDong ," & _
                                    "NgayHopDong=source.NgayHopDong ," & _
                                    "MaKhoXuat=source.MaKhoXuat ," & _
                                    "TenKhoXuat=source.TenKhoXuat ," & _
                                    "LoadingPoint=source.LoadingPoint ," & _
                                    "DesLoadingPoint=source.DesLoadingPoint ," & _
                                    "DischargePoint=source.DischargePoint ," & _
                                    "DesDischargePoint=source.DesDischargePoint ," & _
                                    "VAT=source.VAT ," & _
                                    "DVT=source.DVT ," & _
                                    "PaymentMethod=source.PaymentMethod ," & _
                                    "DesPaymentMethod=source.DesPaymentMethod ," & _
                                    "Term=source.Term ," & _
                                    "DesTerm=source.DesTerm ," & _
                                    "TyGia=source.TyGia ," & _
                                    "SoTKHQNhap=source.SoTKHQNhap ," & _
                                    "SoTKHQXuat=source.SoTKHQXuat ," & _
                                    "MaNhaCungCap=source.MaNhaCungCap ," & _
                                    "TenNhaCungCap=source.TenNhaCungCap ," & _
                                    "MaTuyenDuong=source.MaTuyenDuong ," & _
                                    "MaKhoNhap=source.MaKhoNhap ," & _
                                    "TenKhoNhap=source.TenKhoNhap ," & _
                                    "SoPXK=source.SoPXK ," & _
                                    "NgayPXK=source.NgayPXK " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (BSART, SoLenh,MaKhachHang,TenKhachHang,DiaChiKH,SoHopDong,NgayHopDong,MaKhoXuat,TenKhoXuat,LoadingPoint,DesLoadingPoint,DischargePoint,DesDischargePoint,VAT,DVT,PaymentMethod,DesPaymentMethod,Term,DesTerm,TyGia,SoTKHQNhap,SoTKHQXuat,MaNhaCungCap,TenNhaCungCap,MaTuyenDuong,MaKhoNhap,TenKhoNhap,SoPXK,NgayPXK ) " & _
                            "VALUES (source.BSART, source.SoLenh,source.MaKhachHang,source.TenKhachHang,source.DiaChiKH,source.SoHopDong,source.NgayHopDong,source.MaKhoXuat,source.TenKhoXuat,source.LoadingPoint,source.DesLoadingPoint,source.DischargePoint,source.DesDischargePoint,source.VAT,source.DVT,source.PaymentMethod,source.DesPaymentMethod,source.Term,source.DesTerm,source.TyGia,source.SoTKHQNhap,source.SoTKHQXuat,source.MaNhaCungCap,source.TenNhaCungCap,source.MaTuyenDuong,source.MaKhoNhap,source.TenKhoNhap,source.SoPXK,source.NgayPXK ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If

            'anhqh
            '20210112
            'Goi ham khac de lay them thong tin MaHangHoa
            ' SoLenh DO1
            Dim p_DataTable As DataTable
            Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig
            p_SQL = ""
            p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(p_SapConnectionString, "EN", 25, g_Company_Code)
            p_DataTable = p_ECCDestinationConfig.clsGet_DO1_THN3(p_SoLenh_DO1, p_SQL)

            If p_SQL <> "" Then
                ' MessageBox.Show(p_SQL, "Loi")

                ' Exit Function
            End If
            If Not p_DataTable Is Nothing Then
                For i As Integer = 0 To p_DataTable.Rows.Count - 1

                    'anhqh 20210111 thay truong  Replace(l_ztb_it.Item(i).Vbeln.ToString() thanh bien i_solenh
                    p_SQL = "MERGE tblDO_Item_Material AS target " & _
                        " USING (SELECT '" & i_solenh & "' as SoLenh ," & _
                                  Replace(p_DataTable.Rows(i).Item("LineID").ToString(), "'", "", 1) & "  as LineID ," & _
                                            p_DataTable.Rows(i).Item("DonGia").ToString() & "  as DonGia ,'" & _
                                            p_DataTable.Rows(i).Item("MaHangHoa").ToString() & "'  as MaHangHoa ," & _
                                  "'" & Replace(p_DataTable.Rows(i).Item("CurrencyKey").ToString(), "'", "", 1) & "'  as CurrencyKey " & _
                                " ) AS source (SoLenh, LineID, DonGia,MaHangHoa, CurrencyKey ) " & _
                                " ON (target.SoLenh = source.SoLenh and " & _
                                    " target.LineID = source.LineID ) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    "DonGia=source.DonGia , " & _
                                    "CurrencyKey=source.CurrencyKey " & _
                                     ",MaHangHoa=source.MaHangHoa " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (SoLenh, LineID, DonGia, CurrencyKey, MaHangHoa) " & _
                            "VALUES (source.SoLenh, source.LineID, source.DonGia, source.CurrencyKey, MaHangHoa ) ;"
                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = p_DataTablExe.NewRow
                    p_Row.Item(0) = p_SQL
                    p_DataTablExe.Rows.Add(p_Row)

                    l_dem = l_dem + 1
                Next
            End If

            '===============20210112 Bo di khong dung
            'l_err = String.Empty
            'l_ztb_hd.Clear()
            'l_ztb_it.Clear()
            '' LIne cuar DO1 truyen so DO1
            'Try
            '    If p_TableConfig1.Rows(0).Item("TimeOut").ToString.Trim = "25" Then
            '        l_c2sap.GetDO_THN2(p_SoLenh_DO1, l_ztb_hd, l_ztb_it, l_ret2)
            '        ' l_c2sap.GetDO_THN2(i_solenh, l_ztb_hd, l_ztb_it, l_ret2)
            '    Else
            '        l_async = l_c2sap.BeginGetDO_THN2(i_solenh, l_ztb_hd, l_ztb_it, Nothing, l_c2sap)
            '        l_isCompleted = l_async.AsyncWaitHandle.WaitOne(p_TimeOut, False)

            '        If l_isCompleted Then
            '            l_c2sap.EndGetDO_THN2(l_async, l_ztb_hd, l_ztb_it, l_ret2)
            '        End If
            '    End If
            'Catch ex1 As Exception
            '    o_err = ex1.Message
            '    Return False
            'End Try

            'l_dem = 0
            'If l_ztb_it.Count > 0 Then
            '    For i As Integer = 0 To l_ztb_it.Count - 1

            '        'anhqh 20210111 thay truong  Replace(l_ztb_it.Item(i).Vbeln.ToString() thanh bien i_solenh
            '        p_SQL = "MERGE tblDO_Item_Material AS target " & _
            '            " USING (SELECT '" & i_solenh & "' as SoLenh ," & _
            '                      Replace(l_ztb_it.Item(i).Posnr.ToString(), "'", "", 1) & "  as LineID ," & _
            '        IIf(l_ztb_it.Item(i).Koein.ToString.Trim() <> "VND", Replace(l_ztb_it.Item(i).Zz_Kbetr.ToString(), "'", "", 1), Replace(l_ztb_it.Item(i).Kbetr.ToString(), "'", "", 1)) & "  as DonGia ," & _
            '                      "'" & Replace(l_ztb_it.Item(i).Koein.ToString(), "'", "", 1) & "'  as CurrencyKey " & _
            '                    " ) AS source (SoLenh, LineID, DonGia, CurrencyKey ) " & _
            '                    " ON (target.SoLenh = source.SoLenh and " & _
            '                        " target.LineID = source.LineID ) " & _
            '                " WHEN MATCHED  THEN UPDATE SET " & _
            '                        "DonGia=source.DonGia , " & _
            '                        "CurrencyKey=source.CurrencyKey " & _
            '             " WHEN NOT MATCHED THEN " & _
            '                "INSERT  (SoLenh, LineID, DonGia, CurrencyKey) " & _
            '                "VALUES (source.SoLenh, source.LineID, source.DonGia, source.CurrencyKey ) ;"
            '        ' p_SQL = Replace(p_SQL, "''", "'", 1)
            '        p_Row = p_DataTablExe.NewRow
            '        p_Row.Item(0) = p_SQL
            '        p_DataTablExe.Rows.Add(p_Row)

            '        l_dem = l_dem + 1
            '    Next
            'End If
            '===============20210112 Bo di khong dung


            p_SQL = "update   tblDO_Item_Material  set  LineID  = (select top 1 LineID from tbllenhxuat_HangHOae5  k " & _
                            " where (K.SoLenh = tblDO_Item_Material.SoLenh) " & _
                   " and k.MaHangHoa =tblDO_Item_Material.MaHangHoa)  where solenh='" & i_solenh & "' and isnull(MaHangHoa,'') <> '' "

            p_Row = p_DataTablExe.NewRow
            p_Row.Item(0) = p_SQL
            p_DataTablExe.Rows.Add(p_Row)

            p_SQL = "exec FPT_UpdateDO '" & i_solenh & "'"
            p_Row = p_DataTablExe.NewRow
            p_Row.Item(0) = p_SQL
            p_DataTablExe.Rows.Add(p_Row)





            If p_DataTablExe.Rows.Count > 0 Then
                If g_Services.Sys_Execute_DataTbl(p_DataTablExe, p_SQL) = False Then
                    Return False
                    Exit Function
                End If
            End If



            p_DataTablExe.Clear()

            l_c2sap.Connection.Close()
            l_c2sap.Dispose()

            Return True

        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try


    End Function


End Module
