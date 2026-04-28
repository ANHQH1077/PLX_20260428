Module Module3


    Private p_SYS_MALENH_S As String = String.Empty



    Public Sub p_GetFullDateTime(ByRef p_Date As DateTime, ByRef p_Time As Integer)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable

        p_SQL = "select   getdate()  as SYS_DATE , replace(CONVERT(VARCHAR(5),DATEADD(MINUTE,0 ,GETDATE()),108),':','') as SysTime "
        p_Datatable = g_Services.mod_SYS_GET_DATATABLE(p_SQL)

        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SYS_DATE")
                p_Time = p_Datatable.Rows(0).Item("SysTime")
            End If
        End If
        p_Datatable = Nothing
    End Sub



    Public Function GetTankActive(ByVal p_MaHangHoa As String, ByVal p_Date As Date) As String
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_DateValue As String
        p_DateValue = p_Date.ToString("dd") & "/" & p_Date.ToString("MM") & "/" & p_Date.ToString("yyyy")
        GetTankActive = ""
        Try
            ' anhqh 20160610
            If g_Filter_Terminal = True Then
                p_SQL = "SELECT Name_nd FROM [FPT_tblTankActive_V] where [Date_nd]='" & p_DateValue & "' and   Product_nd ='" & p_MaHangHoa & "'" & _
                    " and left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'"
            Else
                p_SQL = "SELECT Name_nd FROM [FPT_tblTankActive_V] where [Date_nd]='" & p_DateValue & "' and   Product_nd ='" & p_MaHangHoa & "'"
            End If





            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    GetTankActive = p_DataTable.Rows(0).Item("Name_nd").ToString.Trim
                End If

            End If
        Catch ex As Exception
            GetTankActive = ""
        End Try
    End Function

    Public Function mdlTichke_CreateNumberNew(ByRef p_Date As Date, _
                                              ByRef o_err As String) As String
        Dim p_DataTable As DataTable
        Dim l_str As String
        Dim p_SQL As String

        p_Date = Now.Date
        p_SQL = "exec dbo.FPT_TaoSoTichKe"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                l_str = p_DataTable.Rows(0).Item(0).ToString.Trim
            End If
        End If
        If l_str = String.Empty Then
            l_str = "0001"
        Else
            For i As Integer = 0 To 3 - l_str.Length
                l_str = "0" & l_str
            Next
        End If

        p_SQL = "select * from SYS_TICHKEKEY where KeyValues=" & l_str
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                If p_DataTable.Rows(0).Item("CreateDate").ToString.Trim <> "" Then
                    p_Date = CDate(p_DataTable.Rows(0).Item("CreateDate").ToString.Trim)
                End If
            End If
        End If
        Return l_str
    End Function


    Public Function KV1mdlTichke_CreateNumberNew(ByRef p_Date As Date, _
                                             ByRef o_err As String) As String
        Dim p_DataTable As DataTable
        Dim l_str As String
        Dim p_SQL As String

        ' p_Date = Now.Date
        p_SQL = "exec dbo.KV1FPT_TaoSoTichKe '" & p_Date.ToString("yyyyMMdd") & "'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                l_str = p_DataTable.Rows(0).Item(0).ToString.Trim
            End If
        End If
        If l_str = String.Empty Then
            l_str = "0001"
        Else
            For i As Integer = 0 To 3 - l_str.Length
                l_str = "0" & l_str
            Next
        End If

        'p_SQL = "select * from SYS_TICHKEKEY where KeyValues=" & l_str
        'p_DataTable = GetDataTable(p_SQL, p_SQL)
        'If Not p_DataTable Is Nothing Then
        '    If p_DataTable.Rows.Count > 0 Then
        '        If p_DataTable.Rows(0).Item("CreateDate").ToString.Trim <> "" Then
        '            p_Date = CDate(p_DataTable.Rows(0).Item("CreateDate").ToString.Trim)
        '        End If
        '    End If
        'End If
        Return l_str
    End Function

    Function TaoSoTichKe(ByVal p_SoLenh As String) As Boolean
        Dim p_DataTable As DataTable
        Dim p_DataTableKey As DataTable
        Dim p_DataExec As New DataTable("Table01")
        Dim p_DataRow As DataRow

        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_Err As String
        Dim p_DataRowLine As DataRow
        Dim p_SoTichKe As String
        Dim p_NgayThang As String

        Dim p_NgayThangTichKe As Date

        Try
            TaoSoTichKe = False
            p_DataExec.Columns.Add("STR_SQL")
            ' If p_DataTichKe Is Nothing Then  'Khong phai la in tich ke ghep
            p_Err = ""
            p_SQL = "select a.SoLenh, a.NgayXuat, a.MaNgan, A.h_tableID  from FPT_tblLenhXuatChiTietE5_V a where " & _
                " a.solenh='" & p_SoLenh & "' " & _
                " and not exists ( select 1 from tblTichke b where b.SoLenh=a.SoLenh and b.MaNgan=a.MaNgan and b.TableId =a.H_TableID  ) "
            p_DataTable = GetDataTable(p_SQL, p_Err)
            If p_Err <> "" Or p_DataTable Is Nothing Then
                ShowMessageBox("", p_Err)
                TaoSoTichKe = True
            End If
            If g_KV1 = True Then
                If p_DataTable.Rows.Count > 0 Then
                    p_NgayThangTichKe = p_DataTable.Rows(0).Item("NgayXuat")
                    p_SoTichKe = KV1mdlTichke_CreateNumberNew(p_NgayThangTichKe, p_Err)
                    If p_Err <> "" Then
                        ShowMessageBox("", p_Err)
                        TaoSoTichKe = True
                    End If
                End If
            Else
                If p_DataTable.Rows.Count > 0 Then
                    p_SoTichKe = mdlTichke_CreateNumberNew(p_NgayThangTichKe, p_Err)
                    If p_Err <> "" Then
                        ShowMessageBox("", p_Err)
                        TaoSoTichKe = True
                    End If
                End If
            End If
            'If p_DataTable.Rows.Count > 0 Then
            '    p_SoTichKe = mdlTichke_CreateNumberNew(p_NgayThangTichKe, p_Err)
            '    If p_Err <> "" Then
            '        ShowMessageBox("", p_Err)
            '        TaoSoTichKe = True
            '    End If
            'End If

            'anhqh
            '20170215
            'tạm bo di di doi doan nay den cho khac
            For p_Count = 0 To p_DataTable.Rows.Count - 1
                p_DataRowLine = p_DataTable.Rows(p_Count)
                p_NgayThang = CDate(p_DataRowLine.Item("NgayXuat")).ToString("dd.MM.yyyy")
                'p_NgayThangTichKe = Now.Date

                p_SQL = "INSERT INTO tblTichke (SoTichKe, SoLenh,NgayXuat,MaNgan, TableID, NgayTichKe) " & _
                        "VALUES ('" & p_SoTichKe & "','" & p_SoLenh & "', '" & p_NgayThang & "','" & p_DataRowLine.Item("MaNgan").ToString.Trim & _
                                "','" & p_DataRowLine.Item("h_tableID").ToString.Trim & "',convert(date,'" & CDate(p_NgayThangTichKe).ToString("MM/dd/yyyy") & "'))"
                'p_DataRow = p_DataExec.NewRow
                'p_DataRow.Item(0) = p_SQL
                'p_DataExec.Rows.Add(p_DataRow)

                If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                End If
            Next
            'If p_DataExec.Rows.Count > 0 Then

            '    'p_SQL = "delete  from tblTichke where convert(date,RIGHT(NgayXuat,4) + SUBSTRING(NgayXuat,4,2)+ LEFT(NgayXuat,2))<=convert(date,getdate()-15)"

            '    'anhqh
            '    '20160714
            '    'p_SQL = "delete  from tblTichKe where convert(date,NgayTichKe )<=convert(date,getdate()-15)"

            '    'p_DataRow = p_DataExec.NewRow
            '    'p_DataRow.Item(0) = p_SQL
            '    'p_DataExec.Rows.Add(p_DataRow)





            '    p_SQL = ""
            '    If g_Services.Sys_Execute_DataTbl(p_DataExec, p_SQL) = False Then
            '        'MsgBox(p_SQL)
            '        ShowMessageBox("", p_SQL)
            '        TaoSoTichKe = True
            '        Exit Function
            '    End If
            'End If
            
        Catch ex As Exception
            TaoSoTichKe = True
        End Try
    End Function



    Function TaoSoTichKeLenhGhep(ByVal p_GridView As U_TextBox.GridView) As Boolean
        Dim p_DataTable As DataTable
        Dim p_DataTableKey As DataTable
        Dim p_DataExec As New DataTable("Table01")
        Dim p_DataRow As DataRow

        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_Err As String
        Dim p_DataRowLine As DataRow
        Dim p_SoTichKe As String = ""
        Dim p_NgayThang As String
        Dim p_SoLenhGhep As String
        Dim p_DataTableGhep As DataTable
        Dim p_CountGhep As Integer
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_NgayThangTichKe As Date
        Try
            TaoSoTichKeLenhGhep = False
            p_Binding = p_GridView.DataSource
            p_DataTableGhep = CType(p_Binding.DataSource, DataTable)
            p_DataExec.Columns.Add("STR_SQL")
            p_SoLenhGhep = ""
            For p_CountGhep = 0 To p_DataTableGhep.Rows.Count - 1
                If p_SoLenhGhep = p_DataTableGhep.Rows(p_CountGhep).Item("SoLenh").ToString.Trim Then
                    Continue For
                End If
                p_SoLenhGhep = p_DataTableGhep.Rows(p_CountGhep).Item("SoLenh").ToString.Trim
                '   If p_DataTichKe Is Nothing Then  'Khong phai la in tich ke ghep
                p_Err = ""
                p_SQL = "select a.SoLenh, a.NgayXuat, a.MaNgan, A.h_tableID  from FPT_tblLenhXuatChiTietE5_V a where " & _
                    " a.solenh='" & p_SoLenhGhep & "' " & _
                    " and not exists ( select 1 from tblTichke b where b.SoLenh=a.SoLenh and b.MaNgan=a.MaNgan and b.TableId =a.H_TableID  ) "
                p_DataTable = GetDataTable(p_SQL, p_Err)
                If p_Err <> "" Or p_DataTable Is Nothing Then
                    ShowMessageBox("", p_Err)
                    TaoSoTichKeLenhGhep = True
                End If
                If p_DataTable.Rows.Count > 0 Then
                    If p_SoTichKe = "" Then
                        p_SoTichKe = mdlTichke_CreateNumberNew(p_NgayThangTichKe, p_Err)
                        If p_Err <> "" Then
                            ShowMessageBox("", p_Err)
                            TaoSoTichKeLenhGhep = True
                        End If
                    End If

                End If
                For p_Count = 0 To p_DataTable.Rows.Count - 1
                    p_DataRowLine = p_DataTable.Rows(p_Count)
                    p_NgayThang = CDate(p_DataRowLine.Item("NgayXuat")).ToString("dd.MM.yyyy")
                    ' p_NgayThangTichKe = Now.Date
                    p_SQL = "INSERT INTO tblTichke (SoTichKe, SoLenh,NgayXuat,MaNgan, TableID, NgayTichKe) " & _
                            "VALUES ('" & p_SoTichKe & "','" & p_SoLenhGhep & "', '" & p_NgayThang & "','" & _
                                p_DataRowLine.Item("MaNgan").ToString.Trim & "','" & _
                                p_DataRowLine.Item("h_tableID").ToString.Trim & "',convert(date,'" & CDate(p_NgayThangTichKe).ToString("MM/dd/yyyy") & "'))"
                    'p_DataRow = p_DataExec.NewRow
                    'p_DataRow.Item(0) = p_SQL
                    'p_DataExec.Rows.Add(p_DataRow)

                    If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

                    End If
                Next
            Next



           
            'If p_DataExec.Rows.Count > 0 Then
            '    p_SQL = "delete  from tblTichke where convert(date,RIGHT(NgayXuat,4) + SUBSTRING(NgayXuat,4,2)+ LEFT(NgayXuat,2))<=convert(date,getdate()-60)"
            '    p_DataRow = p_DataExec.NewRow
            '    p_DataRow.Item(0) = p_SQL
            '    p_DataExec.Rows.Add(p_DataRow)

            '    p_SQL = ""
            '    If g_Services.Sys_Execute_DataTbl(p_DataExec, p_SQL) = False Then
            '        'MsgBox(p_SQL)
            '        ShowMessageBox("", p_SQL)
            '        TaoSoTichKeLenhGhep = True
            '        Exit Function
            '    End If
            'End If
            '  End If

        Catch ex As Exception
            TaoSoTichKeLenhGhep = True
        End Try
    End Function



    Public Function Check_SoLenh(ByRef err As String, ByVal i_SoLenh As String) As Boolean
        Dim p_DataTable As DataTable
        Dim p_Err As String
        Check_SoLenh = False
        'Return g_c2SQL.ExeNonQuery("sp_Check_SoLenhE5", err, New SqlParameter("@SoLenh", i_SoLenh))
        p_DataTable = GetDataTable("exec sp_Check_SoLenhE5 '" & i_SoLenh & "'", p_Err)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                '  err = p_DataTable.Rows(0).Item(1).ToString.Trim
                Check_SoLenh = True
            End If
        End If
    End Function

    Public Function FPT_KiemTraKhiHoaDon(ByRef err As String, ByVal i_SoLenh As String) As Boolean
        Dim p_DataTable As DataTable
        Dim p_Err As String
        FPT_KiemTraKhiHoaDon = False
       
        'Return g_c2SQL.ExeNonQuery("sp_Check_SoLenhE5", err, New SqlParameter("@SoLenh", i_SoLenh))
        p_DataTable = GetDataTable("exec FPT_KiemTraKhiHoaDon '" & i_SoLenh & "'", p_Err)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                err = p_DataTable.Rows(0).Item(1).ToString.Trim
                FPT_KiemTraKhiHoaDon = True
            End If
        End If
    End Function



    Public Function FPT_KiemTraKhiHoaDonDienTu(ByVal p_LoaiChungTu As String, ByRef err As String, ByVal i_SoLenh As String) As Boolean
        Dim p_DataTable As DataTable
        Dim p_Err As String
        FPT_KiemTraKhiHoaDonDienTu = False

        'Return g_c2SQL.ExeNonQuery("sp_Check_SoLenhE5", err, New SqlParameter("@SoLenh", i_SoLenh))
        p_DataTable = GetDataTable("exec FPT_KiemTraKhiHoaDonDienTu '" & i_SoLenh & "','" & p_LoaiChungTu & "'", p_Err)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                err = p_DataTable.Rows(0).Item(1).ToString.Trim
                FPT_KiemTraKhiHoaDonDienTu = True
            End If
        End If
    End Function



    Public Function mdlFunction_SplitDecimalString(ByVal i_decimal As Decimal) As String
        Dim l_dec_str As String
        Dim l_dec_str_arr As String()
        Dim l_dec_str_char As Char()

        Try

            l_dec_str = i_decimal.ToString()
            l_dec_str_arr = l_dec_str.Split(".")

            If l_dec_str_arr.Length = 0 Then
                Return l_dec_str
            End If

            l_dec_str_char = l_dec_str_arr(0).ToCharArray()

            Return l_dec_str_char
        Catch ex As Exception
            Return i_decimal.ToString()
        End Try
    End Function

    Public Function CheckItemToScada2(ByVal p_Item As String) As String
        Dim p_DataRow() As DataRow
        CheckItemToScada2 = "N"
        Try
            If Not g_HangHoaToScada2 Is Nothing Then
                If g_HangHoaToScada2.Rows.Count > 0 Then
                    p_DataRow = g_HangHoaToScada2.Select("MaHangHoa='" & p_Item.ToString.Trim & "'")
                    If p_DataRow.Length > 0 Then
                        CheckItemToScada2 = "Y"
                    End If
                End If
            End If
        Catch ex As Exception
            CheckItemToScada2 = "E"
        End Try

    End Function


    Public Function FPT_GetMaLenh(ByVal p_SoLenh As String) As String
        Dim p_ValueTmp As String = "0000"
        Dim p_SQL As String = ""
        Dim p_Value As Integer = 0
        Dim p_DataTable As DataTable
        Try
            If p_SYS_MALENH_S.ToString.Trim = "" Then
                p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG where KEYCODE='SYS_MALENH_S'"
                p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        p_SYS_MALENH_S = p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim

                    End If
                End If
            End If

            p_DataTable = Nothing
            FPT_GetMaLenh = "0000"
            p_SQL = "exec FPT_Get_SYS_MALENH '" & p_SoLenh & "'"
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

    Public Function CheckMaLenh(ByRef err As String, ByVal i_malenh As String, ByVal i_ngay As Date) As String

        Dim p_DataTable As DataTable
        Dim p_SQL As String
        Try
            CheckMaLenh = ""
            p_SQL = "select DBO.FPT_CheckMaLenh_E5('" & i_malenh & "','" & i_ngay & "') as MaLenh "
            '_c2SQL = New Connect2SQL.Connect2SQL(_SQLConnectionString)
            'Return _c2SQL.getDataValue("select DBO.fm_CheckMaLenh_KV2E5('" & i_malenh & "','" & i_ngay & "')")
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    CheckMaLenh = p_DataTable.Rows(0).Item("MaLenh").ToString.Trim
                End If
            End If
            ' Return _c2SQL.getDataValue("exec CheckMaLenh_KV2E5('" & i_malenh & "','" & i_ngay & "')")

        Catch ex As Exception
            Return "1"
            err = ex.Message
        End Try
    End Function
    Public Function SyncDeliveries_SynSpecificNew(ByVal p_User_ID As Integer, ByVal p_Company_Code As String, ByVal p_SoLenh As String, ByRef p_Desc As String) As Boolean
        'Select Case p_Company_Code
        '    Case "6610"  'KV2
        '        Dim p_SAP_KV2 As New KV_2_Report.Class1(g_Config_XMLDatatable, _
        '                                                  g_Company_Code, _
        '                                                  g_WareHouse, g_Services, "", "", "", g_Company_Host, _
        '                                                  g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
        '                                                  g_DBPass, g_CompanyAPI)
        '        mdlSyncDeliveries_SynSpecificNew = p_SAP_KV2.ClsSyncDeliveries_SynSpecific(p_SoLenh, p_Desc)
        '        Exit Function
        'End Select
        'SyncDeliveries_SynSpecificNew = mdlSyncDeliveries_SynSpecific(p_User_ID, p_Company_Code, p_SoLenh, p_Desc)
    End Function


    Public Function KiemTraThongTinLenh(ByVal p_SoLenh As String, ByRef p_Desc As String) As Boolean
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_RowDAta() As DataRow
        Dim p_Count As Integer
        KiemTraThongTinLenh = False
        Try
            p_SQL = "exec FPT_KiemTraKhiXacNhan '" & p_SoLenh & "'"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_RowDAta = p_DataTable.Select("Require=1")
                    If p_RowDAta.Length > 0 Then
                        p_Desc = p_RowDAta(0).Item(1).ToString.Trim
                        KiemTraThongTinLenh = True
                        Exit Function
                    End If
                    p_RowDAta = p_DataTable.Select("Require=0")
                    For p_Count = 0 To p_RowDAta.Length - 1
                        p_Desc = p_RowDAta(p_Count).Item(1).ToString.Trim
                        ShowMessageBox("", p_Desc)
                    Next
                    'If p_DataTable.Rows(0).Item("Require").ToString.Trim = "1" Then
                    '    p_Desc = p_DataTable.Rows(0).Item(1).ToString.Trim
                    '    KiemTraThongTinLenh = True
                    '    Exit Function

                    'Else
                    '    p_Desc = p_DataTable.Rows(0).Item(1).ToString.Trim
                    '    ShowMessageBox("", p_Desc)
                    'End If
                End If

            End If
        Catch ex As Exception
            p_Desc = ex.Message
            KiemTraThongTinLenh = True
        End Try

    End Function



    Public Function DataTableRunExecBigData(ByVal p_DataTable As DataTable, ByRef p_Desc As String) As Boolean
        Dim p_DataExec As DataTable
        Dim p_Count As Integer
        Dim p_Int As Integer = 0
        Dim p_Row As DataRow
        Dim p_Count1 As Integer = 0

        Try
            p_DataExec = New DataTable
        Catch ex As Exception
            p_Desc = ex.Message
        End Try

        p_DataExec = p_DataTable.Clone

        p_Desc = ""
        If p_DataTable.Rows.Count >= 50 Then

            For p_Count = 0 To p_DataTable.Rows.Count - 1
                p_Row = p_DataExec.NewRow
                p_Row(0) = p_DataTable.Rows(p_Count).Item(0)
                p_DataExec.Rows.Add(p_Row)
                p_Int = p_Int + 1
                'p_Count1 = p_Count1 + 1
                'If p_Count1 = 1330 Then
                '    MsgBox("sffsdfs")
                'End If
                If p_Int = 50 Then
                    DataTableRunExecBigData = g_Services.Sys_Execute_DataTbl(p_DataExec, p_Desc)
                    If DataTableRunExecBigData = False Then
                        p_DataExec.Clear()
                        Exit Function
                    End If
                    p_DataExec.Clear()
                    p_Int = 0
                    '   Else

                    'p_Row = p_DataExec.Copy.Rows(p_Count)
                End If

            Next
            If p_DataExec.Rows.Count > 0 Then
                DataTableRunExecBigData = g_Services.Sys_Execute_DataTbl(p_DataExec, p_Desc)
                If DataTableRunExecBigData = False Then
                    p_DataExec.Clear()
                    Exit Function
                End If
                p_DataExec.Clear()
            End If
        Else
            DataTableRunExecBigData = g_Services.Sys_Execute_DataTbl(p_DataTable, p_Desc)
            If DataTableRunExecBigData = False Then
                Exit Function
            End If
        End If
    End Function

End Module
