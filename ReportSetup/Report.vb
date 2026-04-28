Module Report



    'anhqh
    '20160704
    'Ham kiem tra truong hop Wagon cua KV1
    Public Function GetScadarWagonKV1() As Boolean
        Dim p_SQL As String = " exec FPT_GetScadarWagonKV1"
        Dim p_DataTable As DataTable
        Try
            GetScadarWagonKV1 = False
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    If p_DataTable.Rows(0).Item("Code").ToString.Trim = "Y" Then
                        GetScadarWagonKV1 = True
                    End If
                End If
            End If
        Catch ex As Exception
            GetScadarWagonKV1 = False
        End Try
    End Function




    Public Sub InTichKe(ByVal p_Preview As Boolean, ByVal p_SoLenh As String)
        Dim p_ErrNumber As String
        Dim p_ErrMessage As String
        Dim p_SQL As String
        Dim p_SoTichKe As String
        Dim l_dt_trans As DataTable
        Dim l_dt_transCheck As DataTable
        Dim p_DataTableCheckID As DataTable
        Dim p_Count As Integer
        Dim p_Value As String
        Dim p_MaHangHoa As String

        Dim p_TICHKE_A3 As Boolean = False
        Dim p_TableCheck As DataTable
        Dim p_RowArr() As DataRow

        
        p_SQL = "exec FPT_CheckLenhInTichKe '" & p_SoLenh & "'"
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


        'anhqh  
        '20160926
        'Kiem tra them tho trang thai lenh

        p_SQL = "exec  FPT_LenhXuat_TichKe_Check '" & p_SoLenh & "',0"
        l_dt_transCheck = GetDataTable(p_SQL, p_SQL)
        If Not l_dt_transCheck Is Nothing Then
            If l_dt_transCheck.Rows.Count > 0 Then
                ShowMessageBox("", "Lệnh xuất chưa được đẩy vào TĐH. Đề nghị làm lại", 3)
                Exit Sub
            End If
        End If

        p_TICHKE_A3 = False
        p_SQL = "select * from sys_config where keycode='TICHKE_A3'"
        l_dt_trans = GetDataTable(p_SQL, p_SQL)
        If Not l_dt_trans Is Nothing Then
            If l_dt_trans.Rows.Count > 0 Then
                If l_dt_trans.Rows(p_Count).Item("KeyValue").ToString.Trim = "Y" Then
                    p_TICHKE_A3 = True
                End If
            End If
        End If



        p_SQL = "exec  FPT_LenhXuat_TichKe '" & p_SoLenh & "',0"
        l_dt_trans = GetDataTable(p_SQL, p_SQL)

        'l_dt_trans.Rows(0).Item(26) = "XĂNG E5 RON 92 II"  hieptd4 test
        'l_dt_trans.Rows(0).Item(15) = 99999
        'l_dt_trans.Rows(0).Item(22) = 99.99

        If Not l_dt_trans Is Nothing Then
            If g_MaTuDongHoa = "N" Then
                'PR_KEY
                For p_Count = 0 To l_dt_trans.Rows.Count - 1
                    'p_MaHangHoa = l_dt_trans.Rows(p_Count).Item("MaHangHoa").ToString.Trim
                    'If CheckItemToScada2(p_MaHangHoa) = "N" Then
                    If GetScadarWagonKV1() = True Then
                        p_Value = l_dt_trans.Rows(p_Count).Item("PR_KEY").ToString.Trim
                        p_SQL = "exec FPT_GetMaTuDongHoa_KV1 '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                          l_dt_trans.Rows(p_Count).Item("MaNgan").ToString.Trim & "','" & l_dt_trans.Rows(p_Count).Item("MaVanChuyen").ToString.Trim & "'"
                    Else
                        p_Value = l_dt_trans.Rows(p_Count).Item("PR_KEY").ToString.Trim
                        p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                                          l_dt_trans.Rows(p_Count).Item("MaNgan").ToString.Trim & "'"

                    End If
                   
                    p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                    If Not p_DataTableCheckID Is Nothing Then
                        If p_DataTableCheckID.Rows.Count > 0 Then
                            p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                            l_dt_trans.Rows(p_Count).Item("PR_KEY") = p_Value
                        End If
                    End If
                    'Else
                    'p_Value = l_dt_trans.Rows(p_Count).Item("MaTuDongHoa").ToString.Trim
                    'l_dt_trans.Rows(p_Count).Item("PR_KEY") = p_Value
                    'End If

                Next
            Else
                For p_Count = 0 To l_dt_trans.Rows.Count - 1
                    p_MaHangHoa = l_dt_trans.Rows(p_Count).Item("MaHangHoa").ToString.Trim

                    'Tam thoi bo di  20170622
                    'Cac don vi dung MaTuDongHoa thi dung chung 1 kieu

                    'If CheckItemToScada2(p_MaHangHoa) = "Y" Then
                    '    p_Value = l_dt_trans.Rows(p_Count).Item("PR_KEY").ToString.Trim
                    '    p_SQL = "exec FPT_GetMaTuDongHoa '" & g_MaTuDongHoa & "','" & p_Value & "','" & _
                    '                      l_dt_trans.Rows(p_Count).Item("MaNgan").ToString.Trim & "'"
                    '    p_DataTableCheckID = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                    '    If Not p_DataTableCheckID Is Nothing Then
                    '        If p_DataTableCheckID.Rows.Count > 0 Then
                    '            p_Value = p_DataTableCheckID.Rows(0).Item("MaLenh").ToString.Trim
                    '            l_dt_trans.Rows(p_Count).Item("PR_KEY") = p_Value
                    '        End If
                    '    End If
                    'Else
                    p_Value = l_dt_trans.Rows(p_Count).Item("MaTuDongHoa").ToString.Trim
                    l_dt_trans.Rows(p_Count).Item("PR_KEY") = p_Value
                    '  End If

                Next
            End If

            If g_WareHouse = "668A" And g_Company_Code = "6610" Then
                Dim p_6410 As New K6410.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                If p_6410.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                        False, "") = False Then
                    ShowMessageBox(p_ErrNumber, p_ErrMessage)
                End If

                Exit Sub
            End If

            If g_WareHouse = "216B" And g_Company_Code = "2110" Then
                Dim p_2210 As New K2210.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                If p_2210.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                        False, "") = False Then
                    ShowMessageBox(p_ErrNumber, p_ErrMessage)
                End If
                Exit Sub
            End If

            

            Select Case g_Company_Code
                Case "6610"  'KV2
                    Dim p_TichKeKV2 As New KV_2_Report.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_TichKeKV2.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                        Exit Sub
                    End If


                 
                    Exit Sub

                Case "2110"  'KV1
                    Dim p_TichKeKV1 As New KV1_Report.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_TichKeKV1.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub
                Case "4510"  'KV5
                    Dim p_TichKeKV5 As New K4510.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_TichKeKV5.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub

                 
                Case "7310"  'TNB
                    Dim p_TichKeTNB As New K7310.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_TichKeTNB.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub
                Case "4110"  'Quang Binh
                    Dim p_QuangBinh As New QB_Report.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_QuangBinh.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub

                Case "1410"
                    Dim p_1410 As New K1410.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_1410.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub

                Case "1910"
                    Dim p_1910 As New K1910.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_1910.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub
                Case "2010"
                    Dim p_2010 As New K2010.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_2010.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub

                Case "2210"
                    Dim p_2210 As New K2210.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_2210.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub
                Case "2310"
                    Dim p_2310 As New K2310.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_2310.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub
                Case "6410"
                    Dim p_6410 As New K6410.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_6410.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub
                Case "7410"
                    Dim p_7410 As New K7410.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_7410.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub
                Case "2510"
                    Dim p_2510 As New K3610.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_2510.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub
                Case "2520"
                    Dim p_2520 As New K2520.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_2520.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub
                Case "3610"
                    Dim p_3610 As New K3610.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_3610.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub
                Case "2521"
                    Dim p_2521 As New K2520.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_2521.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub
                Case "2610"
                    Dim p_2610 As New K2610.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_2610.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub
                Case "2810"
                    Dim p_2810 As New K2810.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_2810.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub
                Case "4810"
                    Dim p_4810 As New K4810.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    If p_4810.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
                    Exit Sub
                Case Else
                    Dim p_AllTichKe As New ALL_REPORT.Class1(g_Config_XMLDatatable, _
                                                            g_Company_Code, _
                                                            g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                            g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                            g_DBPass, g_CompanyAPI)
                    If p_AllTichKe.InTichKe(p_ErrNumber, p_ErrMessage, l_dt_trans, p_Preview, p_SoLenh, _
                                            False, "") = False Then
                        ShowMessageBox(p_ErrNumber, p_ErrMessage)
                    End If
            End Select
        End If


    End Sub



    Public Sub InChungTu_ALL(ByVal p_Form As Object, ByVal p_Preview As Boolean, ByVal p_SoLenh As String, ByVal p_Type As String)
        If p_CHUNGTU_ALL = False Then
            Select Case g_Company_Code
                Case "6610"  'KV2
                    Dim p_TichKeKV2 As New KV_2_Report.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    p_TichKeKV2.InChungTuHoaDon_All(p_Form, p_Type, p_SoLenh)
                    Exit Sub
                Case "2110"  'KV1
                    Dim p_TichKeKV1 As New KV1_Report.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    p_TichKeKV1.InChungTuHoaDon(p_Form, p_Type, p_SoLenh)
                    Exit Sub
                    'Case "4510" 'KV5
                    '    Dim p_TichKeKV5 As New K4510.Class1(g_Config_XMLDatatable, _
                    '                                              g_Company_Code, _
                    '                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                    '                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                    '                                              g_DBPass, g_CompanyAPI)
                    '    p_TichKeKV5.InChungTuHoaDon(p_Form, p_Type, p_SoLenh)
                    '    Exit Sub

                Case "7310"  'TNB
                    Dim p_TichKeTNB As New K7310.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    p_TichKeTNB.InChungTuHoaDon(p_Form, p_Type, p_SoLenh)
                    Exit Sub

                Case Else
                    InChungTuHoaDon(p_Form, p_Type, p_SoLenh)
            End Select
        Else
            Dim p_AllReport As New ALL_REPORT.Class1(g_Config_XMLDatatable, _
                                                            g_Company_Code, _
                                                            g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                            g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                            g_DBPass, g_CompanyAPI)
            p_AllReport.InChungTuHoaDon(p_Form, p_Type, p_SoLenh)
            Exit Sub
        End If
    End Sub


    Public Sub InChungTu(ByVal p_Form As Object, ByVal p_Preview As Boolean, ByVal p_SoLenh As String, ByVal p_Type As String)
        If p_CHUNGTU_ALL = False Then


            If p_Type = "HOADONGIUHO" Then
                Dim p_AllReport As New ALL_REPORT.Class1(g_Config_XMLDatatable, _
                                                           g_Company_Code, _
                                                           g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                           g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                           g_DBPass, g_CompanyAPI)
                p_AllReport.InChungTuHoaDon(p_Form, p_Type, p_SoLenh)
                Exit Sub
            End If
            


            Select Case g_Company_Code
                Case "6610"  'KV2
                    Dim p_TichKeKV2 As New KV_2_Report.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    p_TichKeKV2.InChungTuHoaDon(p_Form, p_Type, p_SoLenh)
                    Exit Sub
                Case "2110"  'KV1
                    Dim p_TichKeKV1 As New KV1_Report.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    p_TichKeKV1.InChungTuHoaDon(p_Form, p_Type, p_SoLenh)
                    Exit Sub
                    'Case "4510" 'KV5
                    '    Dim p_TichKeKV5 As New K4510.Class1(g_Config_XMLDatatable, _
                    '                                              g_Company_Code, _
                    '                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                    '                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                    '                                              g_DBPass, g_CompanyAPI)
                    '    p_TichKeKV5.InChungTuHoaDon(p_Form, p_Type, p_SoLenh)
                    '    Exit Sub

                Case "7310"  'TNB
                    Dim p_TichKeTNB As New K7310.Class1(g_Config_XMLDatatable, _
                                                              g_Company_Code, _
                                                              g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                              g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                              g_DBPass, g_CompanyAPI)
                    p_TichKeTNB.InChungTuHoaDon(p_Form, p_Type, p_SoLenh)
                    Exit Sub

                Case Else
                    InChungTuHoaDon(p_Form, p_Type, p_SoLenh)
            End Select
        Else
            Dim p_AllReport As New ALL_REPORT.Class1(g_Config_XMLDatatable, _
                                                            g_Company_Code, _
                                                            g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                            g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                            g_DBPass, g_CompanyAPI)
            p_AllReport.InChungTuHoaDon(p_Form, p_Type, p_SoLenh)
            Exit Sub
        End If
    End Sub



    Public Sub InChungTuHoaDon(ByVal p_Form As Object, ByVal p_Type As String, ByVal p_SoLenh As String)
        Dim l_err As String
        Select Case p_Type
            Case "HOADON"
                Dim p_FormHD As New frmImfor_HoaDon(p_SoLenh)
                p_FormHD.g_XtraServicesObj = g_Services
                p_FormHD.p_XtraModuleObj = g_Module
                p_FormHD.Show(p_Form)
            Case "HOADONVCNB"
                Dim p_FormHDVCNB As New frmImfor_HoaDonVCNB(p_SoLenh)
                p_FormHDVCNB.g_XtraServicesObj = g_Services
                p_FormHDVCNB.p_XtraModuleObj = g_Module
                p_FormHDVCNB.Show(p_Form)
            Case "HOADONVCNB_NBN"
                Dim p_FormHDVCNB_NBN As New frmImfor_HoaDonVCNB_NBN(p_SoLenh)
                p_FormHDVCNB_NBN.g_XtraServicesObj = g_Services
                p_FormHDVCNB_NBN.p_XtraModuleObj = g_Module
                p_FormHDVCNB_NBN.Show(p_Form)
            Case "HOADONVCNB_CIF"
                Dim p_FormHDVCNB_CIF As New frmImfor_HoaDonVCNB_CIF(p_SoLenh)
                p_FormHDVCNB_CIF.g_XtraServicesObj = g_Services
                p_FormHDVCNB_CIF.p_XtraModuleObj = g_Module
                p_FormHDVCNB_CIF.Show(p_Form)

            Case "HOADONGIUHO"
                Dim p_FormHDGiuHo As New frmImfor_HoaDonHangGiuHo(p_SoLenh)
                p_FormHDGiuHo.g_XtraServicesObj = g_Services
                p_FormHDGiuHo.p_XtraModuleObj = g_Module
                p_FormHDGiuHo.Show(p_Form)
            Case "LENHXUATKHO"
                If Not Print_LenhXuatKho(False, p_SoLenh, l_err) Then
                    ShowMessageBox("", l_err)
                End If
            Case "LENHXKTHEOPHOI"
                If Not Print_LenhXKTheoPhoi(False, p_SoLenh, l_err) Then
                    ShowMessageBox("", l_err)
                End If
            Case "LENHXUATKHOKDD"
                If Not Print_LENHXUATKHOKDD(False, p_SoLenh, l_err) Then
                    ShowMessageBox("", l_err)
                End If
            Case "LENHXUATKHOKDDA4"
                If Not Print_LENHXUATKHOKDDA4(False, p_SoLenh, l_err) Then
                    ShowMessageBox("", l_err)
                End If

            Case "TAIXUAT"
                Dim p_FormTaiXuat As New frmImfor_HoaDonTaiXuat(p_SoLenh)
                p_FormTaiXuat.g_XtraServicesObj = g_Services
                p_FormTaiXuat.p_XtraModuleObj = g_Module
                p_FormTaiXuat.Show(p_Form)


            Case UCase("TaiXuatGTGT")
                Dim p_FormTaiXuatEN As New frmImfor_HoaDonTaiXuat_EN(p_SoLenh)
                p_FormTaiXuatEN.g_XtraServicesObj = g_Services
                p_FormTaiXuatEN.GTGT_EN = False
                p_FormTaiXuatEN.p_XtraModuleObj = g_Module
                p_FormTaiXuatEN.Show(p_Form)

            Case UCase("TaiXuatGTGT1")
                Dim p_FormTaiXuatEN1 As New frmImfor_HoaDonTaiXuat_EN(p_SoLenh)
                p_FormTaiXuatEN1.g_XtraServicesObj = g_Services
                p_FormTaiXuatEN1.p_XtraModuleObj = g_Module
                p_FormTaiXuatEN1.GTGT_EN = True
                p_FormTaiXuatEN1.Show(p_Form)
            Case UCase("BIENBANDOBE")
                Dim p_AllReport As New ALL_REPORT.Class1(g_Config_XMLDatatable, _
                                                           g_Company_Code, _
                                                           g_WareHouse, g_Services, "", "", "", g_Company_Host, _
                                                           g_Company_DBName, g_UserName, g_LicenceHost, g_DBUser, _
                                                           g_DBPass, g_CompanyAPI)

                If Not p_AllReport.clsPrint_BienBanDoBe(False, p_SoLenh, l_err) Then
                    ShowMessageBox("", l_err)
                End If

        End Select
    End Sub

    Public Function Print_LenhXKTheoPhoi(ByVal i_preview As Boolean, ByVal i_SoLenh As String, ByRef o_err As String) As Boolean
        Dim err As String = String.Empty
        Dim DtSet As New DataSet
        Dim DtTable As New DataTable
        Dim DtTable1 As New DataTable
        Dim DtTable2 As New DataTable
        Dim TongDuXuat As Double
        Dim TongThucXuat As Double
        'Dim rpt As New rptLenhXuatKho
        Dim p_KV1_LenhxuatKho As New KV2_LenhXKTheoPhoi
        Dim p_KV1_LenhxuatKho_Sub As New KV2_LenhXKTheoPhoi_Sub
        'Dim frmView As New frmPrint
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_DataTable As DataTable


        Try
            p_SQL = "FPT_reports_LenhXuatKhoE5 '" & i_SoLenh & "'"
            DtSet = GetDataSet(p_SQL, err)
            ' DtSet = l_bs_reports.Select_LenhXuatKho(_SQLConnectionString, err, i_SoLenh)
            If DtSet Is Nothing Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If

            If DtSet.Tables.Count < 2 Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If

            DtTable = DtSet.Tables(0)
            If DtTable.Rows.Count <= 0 Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If




            DtTable1 = DtSet.Tables(1)
            DtTable2 = DtSet.Tables(2)

            For p_Count = 0 To DtTable1.Rows.Count - 1
                DtTable1.Rows(p_Count).Item("SoLuongThucXuat") = DtTable1.Rows(p_Count).Item("TongThucXuat")
                'DtTable1.Rows(p_Count).Item("SoLuongThucXuat") = DtTable1.Rows(p_Count).Item("SoLuongThucXuat")
                'TongDuXuat += DtTable1.Rows(p_Count).Item("SoLuongDuXuat")
                'TongThucXuat += DtTable1.Rows(p_Count).Item("SoLuongThucXuat")
                TongDuXuat += IIf(DtTable1.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim = "", 0, DtTable1.Rows(p_Count).Item("SoLuongDuXuat"))
                TongThucXuat += IIf(DtTable1.Rows(p_Count).Item("SoLuongThucXuat").ToString.Trim = "", 0, DtTable1.Rows(p_Count).Item("SoLuongThucXuat"))
            Next
            'p_KV1_LenhxuatKho.DataSource = DtTable1
            p_KV1_LenhxuatKho_Sub.DataSource = DtTable1
            p_KV1_LenhxuatKho.XrSubreport1.ReportSource = p_KV1_LenhxuatKho_Sub

            'p_KV1_LenhxuatKho.Parameters.Item("NgayXuat").Value = DtTable.Rows(0).Item("NgayXuat")
            p_KV1_LenhxuatKho.Parameters.Item("FDay").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "dd")
            p_KV1_LenhxuatKho.Parameters.Item("FMonth").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "MM")
            p_KV1_LenhxuatKho.Parameters.Item("FYear").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "yyyy")
            If DtTable.Rows(0).Item("NgayHetHieuLuc").ToString.Trim <> "00000000" And DtTable.Rows(0).Item("NgayHetHieuLuc").ToString.Trim <> "" Then
                p_KV1_LenhxuatKho.Parameters.Item("TDay").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "dd")
                p_KV1_LenhxuatKho.Parameters.Item("TMonth").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "MM")
                p_KV1_LenhxuatKho.Parameters.Item("TYear").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "yyyy")
            End If

            'p_KV1_LenhxuatKho.Parameters.Item("FDay").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("FMonth").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("FYear").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TDay").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TMonth").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TYear").Visible = False

            p_KV1_LenhxuatKho.Parameters.Item("SoLenh").Value = DtTable.Rows(0).Item("SoLenh")

            p_KV1_LenhxuatKho.Parameters.Item("STO").Value = DtTable.Rows(0).Item("STO")
            p_KV1_LenhxuatKho.Parameters.Item("NguoiDaiDien").Value = DtTable.Rows(0).Item("NguoiDaiDien")
            p_KV1_LenhxuatKho.Parameters.Item("DonViCungCapVanTai").Value = DtTable.Rows(0).Item("DonViCungCapVanTai")
            p_KV1_LenhxuatKho.Parameters.Item("KhoXuat").Value = DtTable.Rows(0).Item("KhoXuat").ToString
            p_KV1_LenhxuatKho.Parameters.Item("MaNguon").Value = DtTable.Rows(0).Item("MaNguon").ToString
            p_KV1_LenhxuatKho.Parameters.Item("PhuongThucXuat").Value = DtTable.Rows(0).Item("PhuongThucXuat").ToString
            'p_KV1_LenhxuatKho.Parameters.Item("p_GhiChu").Value = "Anh hùng bàn phím ahihi" 'hieptd4 add for test
            'p_KV1_LenhxuatKho.Parameters.Item("p_NguoiLap").Value = g_UserName
            p_SQL = "select top 1 DESCRIPTION from SYS_USER with (Nolock) where USER_NAME='" & g_UserName & "'"
            p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_KV1_LenhxuatKho.Parameters.Item("p_NguoiLap").Value = p_DataTable.Rows(0).Item(0).ToString
                End If
            End If

            p_KV1_LenhxuatKho.Parameters.Item("DonViNhanHang").Value = DtTable.Rows(0).Item("DVNhanHang").ToString

            p_KV1_LenhxuatKho.Parameters.Item("PhuongThucVanTai").Value = DtTable.Rows(0).Item("PhuongThucVanTai").ToString

            p_KV1_LenhxuatKho.Parameters.Item("MaPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            p_KV1_LenhxuatKho.Parameters.Item("NguoiVanChuyen").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString()
            If DtTable2.Rows.Count > 0 Then
                'p_KV1_LenhxuatKho.Parameters.Item("Congty").Value = DtTable2.Rows(0).Item("TenDonVi").ToString()
            End If
            p_KV1_LenhxuatKho.Parameters.Item("p_TongDuXuat").Value = TongDuXuat
            p_KV1_LenhxuatKho.Parameters.Item("p_TongThucXuat").Value = TongThucXuat

            p_KV1_LenhxuatKho.RequestParameters = False
            p_KV1_LenhxuatKho.PrinterName = g_DefaultPrint
            If i_preview Then
                p_KV1_LenhxuatKho.Print()
            Else

                '  p_KV1_LenhxuatKho.sh()
                p_KV1_LenhxuatKho.ShowPreviewDialog()
            End If

            Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try
    End Function

    Public Function Print_LENHXUATKHOKDD(ByVal i_preview As Boolean, ByVal i_SoLenh As String, ByRef o_err As String) As Boolean
        Dim err As String = String.Empty
        Dim DtSet As New DataSet
        Dim DtTable As New DataTable
        Dim DtTable1 As New DataTable
        Dim DtTable2 As New DataTable
        'Dim rpt As New rptLenhXuatKho
        Dim p_KV1_LenhxuatKho As New KV2_LenhXuatKhoKDD
        Dim p_KV1_LenhxuatKho_Sub As New KV2_LenhXuatKhoKDD_Sub
        'Dim frmView As New frmPrint
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim TongDuXuat As Double
        Dim TongThucXuat As Double
        Dim p_DataTable As DataTable

        Try
            p_SQL = "FPT_reports_LenhXuatKhoE5 '" & i_SoLenh & "'"
            DtSet = GetDataSet(p_SQL, err)
            ' DtSet = l_bs_reports.Select_LenhXuatKho(_SQLConnectionString, err, i_SoLenh)
            If DtSet Is Nothing Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If

            If DtSet.Tables.Count < 2 Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If

            DtTable = DtSet.Tables(0)
            If DtTable.Rows.Count <= 0 Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If




            DtTable1 = DtSet.Tables(1)
            DtTable2 = DtSet.Tables(2)

            For p_Count = 0 To DtTable1.Rows.Count - 1
                DtTable1.Rows(p_Count).Item("SoLuongThucXuat") = DtTable1.Rows(p_Count).Item("TongThucXuat")
                'DtTable1.Rows(p_Count).Item("SoLuongThucXuat") = DtTable1.Rows(p_Count).Item("SoLuongThucXuat")
                TongDuXuat += IIf(DtTable1.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim = "", 0, DtTable1.Rows(p_Count).Item("SoLuongDuXuat"))
                TongThucXuat += IIf(DtTable1.Rows(p_Count).Item("SoLuongThucXuat").ToString.Trim = "", 0, DtTable1.Rows(p_Count).Item("SoLuongThucXuat"))
            Next
            'p_KV1_LenhxuatKho.DataSource = DtTable1
            p_KV1_LenhxuatKho_Sub.DataSource = DtTable1
            p_KV1_LenhxuatKho.XrSubreport1.ReportSource = p_KV1_LenhxuatKho_Sub


            'p_KV1_LenhxuatKho.Parameters.Item("NgayXuat").Value = DtTable.Rows(0).Item("NgayXuat")
            p_KV1_LenhxuatKho.Parameters.Item("FDay").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "dd")
            p_KV1_LenhxuatKho.Parameters.Item("FMonth").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "MM")
            p_KV1_LenhxuatKho.Parameters.Item("FYear").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "yyyy")
            If DtTable.Rows(0).Item("NgayHetHieuLuc").ToString.Trim <> "00000000" And DtTable.Rows(0).Item("NgayHetHieuLuc").ToString.Trim <> "" Then
                p_KV1_LenhxuatKho.Parameters.Item("TDay").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "dd")
                p_KV1_LenhxuatKho.Parameters.Item("TMonth").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "MM")
                p_KV1_LenhxuatKho.Parameters.Item("TYear").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "yyyy")
            End If

            'p_KV1_LenhxuatKho.Parameters.Item("FDay").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("FMonth").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("FYear").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TDay").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TMonth").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TYear").Visible = False

            p_KV1_LenhxuatKho.Parameters.Item("SoLenh").Value = DtTable.Rows(0).Item("SoLenh")

            p_KV1_LenhxuatKho.Parameters.Item("STO").Value = DtTable.Rows(0).Item("STO")
            p_KV1_LenhxuatKho.Parameters.Item("NguoiDaiDien").Value = DtTable.Rows(0).Item("NguoiDaiDien")
            p_KV1_LenhxuatKho.Parameters.Item("DonViCungCapVanTai").Value = DtTable.Rows(0).Item("DonViCungCapVanTai")
            
                p_KV1_LenhxuatKho.Parameters.Item("KhoNhap").Value = DtTable.Rows(0).Item("KhoNhap").ToString

            p_KV1_LenhxuatKho.Parameters.Item("KhoXuat").Value = DtTable.Rows(0).Item("KhoXuat").ToString
            'p_KV1_LenhxuatKho.Parameters.Item("KhoNhap").Value = "Kho 100 hieptd4" 'hieptd4 add for test
            'p_KV1_LenhxuatKho.Parameters.Item("p_GhiChu").Value = "Anh hùng bàn phím ahihi" 'hieptd4 add for test
            'p_KV1_LenhxuatKho.Parameters.Item("p_NguoiLap").Value = g_UserName
            p_SQL = "select top 1 DESCRIPTION from SYS_USER with (Nolock) where USER_NAME='" & g_UserName & "'"
            p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_KV1_LenhxuatKho.Parameters.Item("p_NguoiLap").Value = p_DataTable.Rows(0).Item(0).ToString
                End If
            End If
            p_KV1_LenhxuatKho.Parameters.Item("MaNguon").Value = DtTable.Rows(0).Item("MaNguon").ToString
            p_KV1_LenhxuatKho.Parameters.Item("PhuongThucXuat").Value = DtTable.Rows(0).Item("PhuongThucXuat").ToString

            Try
                p_KV1_LenhxuatKho.Parameters.Item("DonViNhanHang").Value = DtTable.Rows(0).Item("KhachHang2").ToString 'DtTable.Rows(0).Item("DVNhanHang").ToString

            Catch ex As Exception
                p_KV1_LenhxuatKho.Parameters.Item("DonViNhanHang").Value = DtTable.Rows(0).Item("DVNhanHang").ToString

            End Try
           
            p_KV1_LenhxuatKho.Parameters.Item("PhuongThucVanTai").Value = DtTable.Rows(0).Item("PhuongThucVanTai").ToString
            p_KV1_LenhxuatKho.Parameters.Item("SoChuyenVanTai").Value = DtTable.Rows(0).Item("SoChuyenVanTai").ToString
            p_KV1_LenhxuatKho.Parameters.Item("MaPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            p_KV1_LenhxuatKho.Parameters.Item("NguoiVanChuyen").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString()
            If DtTable2.Rows.Count > 0 Then
                'p_KV1_LenhxuatKho.Parameters.Item("Congty").Value = DtTable2.Rows(0).Item("TenDonVi").ToString()
            End If
            p_KV1_LenhxuatKho.Parameters.Item("p_TongDuXuat").Value = TongDuXuat
            p_KV1_LenhxuatKho.Parameters.Item("p_TongThucXuat").Value = TongThucXuat

            p_KV1_LenhxuatKho.RequestParameters = False
            p_KV1_LenhxuatKho.PrinterName = g_DefaultPrint
            If i_preview Then
                p_KV1_LenhxuatKho.Print()
            Else

                '  p_KV1_LenhxuatKho.sh()
                p_KV1_LenhxuatKho.ShowPreviewDialog()
            End If

            Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try
    End Function

    Public Function Print_LENHXUATKHOKDDA4(ByVal i_preview As Boolean, ByVal i_SoLenh As String, ByRef o_err As String) As Boolean
        Dim err As String = String.Empty
        Dim DtSet As New DataSet
        Dim DtTable As New DataTable
        Dim DtTable1 As New DataTable
        Dim DtTable2 As New DataTable
        'Dim rpt As New rptLenhXuatKho
        Dim p_KV1_LenhxuatKho As New KV2_LenhXuatKhoKDDA4
        'Dim p_KV1_LenhxuatKho_Sub As New KV2_LenhXuatKhoKDD_Sub
        'Dim frmView As New frmPrint
        Dim p_SQL As String
        'Dim p_Count As Integer
        'Dim TongDuXuat As Double
        'Dim TongThucXuat As Double
        Dim p_DataTable As DataTable

        Dim p_Date As DateTime
        '  p_GetCurrentDate(p_Date)
        p_Date = Get_ThoiGianDau(i_SoLenh)
        Try
            p_SQL = "FPT_reports_LenhXuatKhoE5 '" & i_SoLenh & "'"
            DtSet = GetDataSet(p_SQL, err)
            ' DtSet = l_bs_reports.Select_LenhXuatKho(_SQLConnectionString, err, i_SoLenh)
            If DtSet Is Nothing Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If

            If DtSet.Tables.Count < 2 Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If

            DtTable = DtSet.Tables(0)
            If DtTable.Rows.Count <= 0 Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If




            DtTable1 = DtSet.Tables(1)
            DtTable2 = DtSet.Tables(2)

            'For p_Count = 0 To DtTable1.Rows.Count - 1
            '    DtTable1.Rows(p_Count).Item("SoLuongThucXuat") = DtTable1.Rows(p_Count).Item("TongThucXuat")
            '    'DtTable1.Rows(p_Count).Item("SoLuongThucXuat") = DtTable1.Rows(p_Count).Item("SoLuongThucXuat")
            '    TongDuXuat += IIf(DtTable1.Rows(p_Count).Item("SoLuongDuXuat").ToString.Trim = "", 0, DtTable1.Rows(p_Count).Item("SoLuongDuXuat"))
            '    TongThucXuat += IIf(DtTable1.Rows(p_Count).Item("SoLuongThucXuat").ToString.Trim = "", 0, DtTable1.Rows(p_Count).Item("SoLuongThucXuat"))
            'Next
            p_KV1_LenhxuatKho.DataSource = DtTable1
            'p_KV1_LenhxuatKho_Sub.DataSource = DtTable1
            'p_KV1_LenhxuatKho.XrSubreport1.ReportSource = p_KV1_LenhxuatKho_Sub


            'p_KV1_LenhxuatKho.Parameters.Item("NgayXuat").Value = DtTable.Rows(0).Item("NgayXuat")
            p_KV1_LenhxuatKho.Parameters.Item("FDay").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "dd")
            p_KV1_LenhxuatKho.Parameters.Item("FMonth").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "MM")
            p_KV1_LenhxuatKho.Parameters.Item("FYear").Value = Format(DtTable.Rows(0).Item("NgayXuat"), "yyyy")
            If DtTable.Rows(0).Item("NgayHetHieuLuc").ToString.Trim <> "00000000" And DtTable.Rows(0).Item("NgayHetHieuLuc").ToString.Trim <> "" Then
                p_KV1_LenhxuatKho.Parameters.Item("TDay").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "dd")
                p_KV1_LenhxuatKho.Parameters.Item("TMonth").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "MM")
                p_KV1_LenhxuatKho.Parameters.Item("TYear").Value = Format(DtTable.Rows(0).Item("NgayHetHieuLuc"), "yyyy")
            End If

            'p_KV1_LenhxuatKho.Parameters.Item("FDay").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("FMonth").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("FYear").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TDay").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TMonth").Visible = False
            'p_KV1_LenhxuatKho.Parameters.Item("TYear").Visible = False

            p_KV1_LenhxuatKho.Parameters.Item("SoLenh").Value = DtTable.Rows(0).Item("SoLenh")

            p_KV1_LenhxuatKho.Parameters.Item("STO").Value = DtTable.Rows(0).Item("STO")
            p_KV1_LenhxuatKho.Parameters.Item("NguoiDaiDien").Value = DtTable.Rows(0).Item("NguoiDaiDien")
            p_KV1_LenhxuatKho.Parameters.Item("DonViCungCapVanTai").Value = DtTable.Rows(0).Item("DonViCungCapVanTai")
            p_KV1_LenhxuatKho.Parameters.Item("KhoXuat").Value = DtTable.Rows(0).Item("KhoXuat").ToString

            p_KV1_LenhxuatKho.Parameters.Item("KhoNhap").Value = DtTable.Rows(0).Item("KhoNhap").ToString



            'p_KV1_LenhxuatKho.Parameters.Item("KhoNhap").Value = "Kho 100 hieptd4" 'hieptd4 add for test
            'p_KV1_LenhxuatKho.Parameters.Item("p_GhiChu").Value = "Anh hùng bàn phím ahihi" 'hieptd4 add for test
            'p_KV1_LenhxuatKho.Parameters.Item("p_NguoiLap").Value = g_UserName
            p_SQL = "select top 1 DESCRIPTION from SYS_USER with (Nolock) where USER_NAME='" & g_UserName & "'"
            p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_KV1_LenhxuatKho.Parameters.Item("p_NguoiLap").Value = p_DataTable.Rows(0).Item(0).ToString
                End If
            End If
            p_KV1_LenhxuatKho.Parameters.Item("MaNguon").Value = DtTable.Rows(0).Item("MaNguon").ToString
            p_KV1_LenhxuatKho.Parameters.Item("PhuongThucXuat").Value = DtTable.Rows(0).Item("PhuongThucXuat").ToString

            Try
                p_KV1_LenhxuatKho.Parameters.Item("DonViNhanHang").Value = DtTable.Rows(0).Item("KhachHang2").ToString

            Catch ex As Exception
                ' p_KV1_LenhxuatKho.Parameters.Item("DonViNhanHang").Value = DtTable.Rows(0).Item("DVNhanHang").ToString
                p_KV1_LenhxuatKho.Parameters.Item("DonViNhanHang").Value = Mid(DtTable.Rows(0).Item("DVNhanHang").ToString, 3)
            End Try
            '  p_KV1_LenhxuatKho.Parameters.Item("DonViNhanHang").Value = DtTable.Rows(0).Item("DVNhanHang").ToString

            p_KV1_LenhxuatKho.Parameters.Item("PhuongThucVanTai").Value = DtTable.Rows(0).Item("PhuongThucVanTai").ToString

            'If DtTable.Rows(0).Item("SoChuyenVanTai").ToString = "V144" Then
            '    p_KV1_LenhxuatKho.Parameters.Item("SoChuyenVanTai").Value = ""
            'Else
            p_KV1_LenhxuatKho.Parameters.Item("SoChuyenVanTai").Value = DtTable.Rows(0).Item("SoChuyenVanTai").ToString
            ' End If

            p_KV1_LenhxuatKho.Parameters.Item("MaPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            p_KV1_LenhxuatKho.Parameters.Item("NguoiVanChuyen").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString()
            If DtTable2.Rows.Count > 0 Then
                p_KV1_LenhxuatKho.Parameters.Item("Congty").Value = DtTable2.Rows(0).Item("TenDonVi").ToString()
            End If
            'p_KV1_LenhxuatKho.Parameters.Item("p_TongDuXuat").Value = TongDuXuat
            'p_KV1_LenhxuatKho.Parameters.Item("p_TongThucXuat").Value = TongThucXuat
            p_KV1_LenhxuatKho.Parameters.Item("p_datetime").Value = "Ngày giờ in: " & String.Format("{0:dd.MM.yyyy}", p_Date) & "/" & p_Date.ToString("HH:mm:ss")  '" . " & p_Date.Hour.ToString + ":" + p_Date.Minute.ToString + ":" + p_Date.Second.ToString
            p_KV1_LenhxuatKho.Parameters.Item("p_date").Value = "Ngày " & Format(p_Date, "dd") & " tháng " & Format(p_Date, "MM") & " năm " & Format(p_Date, "yyyy")


            p_KV1_LenhxuatKho.RequestParameters = False
            p_KV1_LenhxuatKho.PrinterName = g_DefaultPrint
            If i_preview Then
                p_KV1_LenhxuatKho.Print()
            Else

                '  p_KV1_LenhxuatKho.sh()
                p_KV1_LenhxuatKho.ShowPreviewDialog()
            End If

            Return True
        Catch ex As Exception
            o_err = ex.Message
            Return False
        End Try
    End Function





    Public Function Print_LenhXuatKho(ByVal i_preview As Boolean, ByVal i_SoLenh As String, ByRef o_err As String) As Boolean
        Dim err As String = String.Empty
        Dim DtSet As New DataSet
        Dim DtTable As New DataTable
        Dim DtTable1 As New DataTable
        Dim DtTable2 As New DataTable
        'Dim rpt As New rptLenhXuatKho
        Dim p_KV1_LenhxuatKho As New KV2_LenhXuatKho
        'Dim frmView As New frmPrint
        Dim p_SQL As String
        Dim p_Count As Integer
        Try
            p_SQL = "FPT_reports_LenhXuatKhoE5 '" & i_SoLenh & "'"
            DtSet = GetDataSet(p_SQL, err)
            ' DtSet = l_bs_reports.Select_LenhXuatKho(_SQLConnectionString, err, i_SoLenh)
            If DtSet Is Nothing Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If

            If DtSet.Tables.Count < 2 Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If

            DtTable = DtSet.Tables(0)
            If DtTable.Rows.Count <= 0 Then
                o_err = "Không có dữ liệu của lệnh xuất"
                Return False
            End If




            DtTable1 = DtSet.Tables(1)
            DtTable2 = DtSet.Tables(2)

            For p_Count = 0 To DtTable1.Rows.Count - 1
                DtTable1.Rows(p_Count).Item("SoLuongThucXuat") = DtTable1.Rows(p_Count).Item("TongXuat")
                ' DtTable1.Rows(p_Count).Item("SoLuongThucXuat") = DtTable1.Rows(p_Count).Item("SoLuongThucXuat")
            Next
            p_KV1_LenhxuatKho.DataSource = DtTable1

            p_KV1_LenhxuatKho.Parameters.Item("NgayXuat").Value = DtTable.Rows(0).Item("NgayXuat")
            p_KV1_LenhxuatKho.Parameters.Item("SoLenh").Value = DtTable.Rows(0).Item("SoLenh")


            p_KV1_LenhxuatKho.Parameters.Item("KhoXuat").Value = DtTable.Rows(0).Item("KhoXuat").ToString
            p_KV1_LenhxuatKho.Parameters.Item("MaNguon").Value = DtTable.Rows(0).Item("MaNguon").ToString
            'p_KV1_LenhxuatKho.Parameters.Item("PhuongThuxXuat").Value = DtTable.Rows(0).Item("PhuongThucXuat").ToString
            p_KV1_LenhxuatKho.Parameters.Item("PhuongThucXuat").Value = DtTable.Rows(0).Item("PhuongThucXuat").ToString

            p_KV1_LenhxuatKho.Parameters.Item("DonViCungCapVanTai").Value = DtTable.Rows(0).Item("DonViCungCapVanTai").ToString

            p_KV1_LenhxuatKho.Parameters.Item("DonViNhanHang").Value = DtTable.Rows(0).Item("DVNhanHang").ToString

            p_KV1_LenhxuatKho.Parameters.Item("PhuongThucVanTai").Value = DtTable.Rows(0).Item("PhuongThucVanTai").ToString

            p_KV1_LenhxuatKho.Parameters.Item("MaPhuongTien").Value = DtTable.Rows(0).Item("MaPhuongTien").ToString
            p_KV1_LenhxuatKho.Parameters.Item("NguoiVanChuyen").Value = DtTable.Rows(0).Item("NguoiVanChuyen").ToString()
            If DtTable2.Rows.Count > 0 Then
                p_KV1_LenhxuatKho.Parameters.Item("Congty").Value = DtTable2.Rows(0).Item("TenDonVi").ToString()
            End If

            p_KV1_LenhxuatKho.RequestParameters = False
            p_KV1_LenhxuatKho.PrinterName = g_DefaultPrint
            If i_preview Then
                p_KV1_LenhxuatKho.Print()
            Else

                '  p_KV1_LenhxuatKho.sh()
                p_KV1_LenhxuatKho.ShowPreviewDialog()
            End If

            Return True
        Catch ex As Exception
            Return False
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

End Module
