Module Report

    Public Sub mdlRptThongKeXuatHang(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        Dim p_ShowParent As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_Title As String = ""
        Dim p_Arr() As DataRow
        Dim p_SQL As String
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet
        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_count1 As Integer
        Dim p_DataTable1 As DataTable
        Dim p_Width As Integer
        Dim p_Left_Title As Integer
        Dim p_Top_Title As Integer
        Dim p_Report As New rptTKXH
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object


        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSetCompany Is Nothing Then
                    If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                        p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                    End If

                    If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                        p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                    End If

                End If
            End If

        End If

        p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        If p_Arr.Length > 0 Then
            If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                p_ShowCompany = True
            End If
            If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                p_ShowParent = True
            End If
            p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        End If

        p_Report.DataSource = p_datatable
        p_Report.Parameters.Item("ngay").Value = Now.Date.ToString("dd")
        p_Report.Parameters.Item("thang").Value = Now.Date.ToString("MM")
        p_Report.Parameters.Item("nam").Value = Now.Date.ToString("yyyy")
        p_Report.ShowPreviewDialog()


    End Sub

    Public Sub mdlRptTTHongXuat(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        Dim p_ShowParent As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_Title As String = ""
        Dim p_Arr() As DataRow
        Dim p_SQL As String
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet
        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_count1 As Integer
        Dim p_DataTable1 As DataTable
        Dim p_Width As Integer
        Dim p_Left_Title As Integer
        Dim p_Top_Title As Integer
        Dim p_Report As New RptTTHX
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object


        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSetCompany Is Nothing Then
                    If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                        p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                    End If

                    If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                        p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                    End If

                End If
            End If

        End If

        p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        If p_Arr.Length > 0 Then
            If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                p_ShowCompany = True
            End If
            If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                p_ShowParent = True
            End If
            p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        End If


        'p_Report.lbTitle.Text = p_Title
        'p_Report.lbCompany.Text = p_CompanyName
        'p_Report.lbParent.Text = p_ParentCompanyName
        p_Report.DataSource = p_datatable

        p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
        p_DataTable1 = GetDataTable(p_SQL, p_SQL)

        'labelDetail = New DevExpress.XtraReports.UI.XRLabel
        'p_Width = tableWidth - 20
        'labelDetail.HeightF = 1
        'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
        'labelDetail.WidthF = p_Width
        'labelDetail.LeftF = 10
        '.ReportFooter.Controls.Add(labelDetail)
        With p_Report
            'If Not p_DataTable1 Is Nothing Then
            '    p_count1 = p_DataTable1.Rows.Count
            '    If p_count1 > 0 Then
            '        p_Width = p_Report.PageSize.Width / p_count1
            '        p_Left_Title = 0
            '        p_Top_Title = 100
            '        For p_Count = 0 To p_count1 - 1
            '            labelDetail = New DevExpress.XtraReports.UI.XRLabel
            '            labelDetail.WidthF = p_Width
            '            labelDetail.LeftF = p_Left_Title
            '            labelDetail.Text = p_DataTable1.Rows(p_Count).Item("SDesc").ToString.Trim
            '            labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '            labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
            '            labelDetail.TopF = p_Top_Title
            '            ' p_Report.ReportFooter1.Controls.Add(labelDetail)
            '            p_Left_Title = p_Left_Title + labelDetail.WidthF
            '        Next
            '    End If

            'End If
            '   p_Top_Title = .XrLabel1.TopF + .XrLabel1.HeightF
            '  p_Left_Title = .XrLabel1.LeftF
            p_Top_Title = 110
            'Lay ra cac tham so co the treo len bao cao
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If

                        p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & "         Đến ngày:   " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
                                End If

                            End If
                        End If

                    End If

                    If StrParameter <> "" Then
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        'labelDetail.WidthF = .PageSize.Width - 30
                        labelDetail.WidthF = .PageSize.Width - 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If


            'p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ItemName='TuNgay'", "STT")
            'If p_Arr.Length > 0 Then
            '    For p_Count = 0 To p_Arr.Length - 1
            '        p_Row = p_Arr(p_Count)
            '        If p_Row.Item("ItemName").ToString.Trim <> "" Then
            '            p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
            '            If p_Object.Length > 0 Then
            '                If UCase(p_Object(0).name.ToString) = "TUNGAY" Then
            '                    '.Parameters.Item("Thang_Nam").Value = "Tháng  " & CDate(p_Object(0).editvalue).Month.ToString & "   năm  " & CDate(p_Object(0).editvalue).Year.ToString
            '                    .Parameters.Item("Thang_Nam").Value = "Tháng  " & CDate(p_Object(0).editvalue).ToString("MM") & "   năm  " & CDate(p_Object(0).editvalue).ToString("yyyy")
            '                End If
            '            End If
            '        End If
            '    Next
            'End If


            .Parameters.Item("NgayBaoCao").Value = "Ngày báo cáo: " & Now.Date.ToString("dd/MM/yyyy")

        End With
        p_Report.ShowPreviewDialog()


    End Sub

    Public Sub mdlRptTTBeXuat(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        Dim p_ShowParent As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_Title As String = ""
        Dim p_Arr() As DataRow
        Dim p_SQL As String
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet
        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_count1 As Integer
        Dim p_DataTable1 As DataTable
        Dim p_Width As Integer
        Dim p_Left_Title As Integer
        Dim p_Top_Title As Integer
        Dim p_Report As New RptTTBX
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object


        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSetCompany Is Nothing Then
                    If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                        p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                    End If

                    If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                        p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                    End If

                End If
            End If

        End If

        p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        If p_Arr.Length > 0 Then
            If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                p_ShowCompany = True
            End If
            If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                p_ShowParent = True
            End If
            p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        End If


        'p_Report.lbTitle.Text = p_Title
        'p_Report.lbCompany.Text = p_CompanyName
        'p_Report.lbParent.Text = p_ParentCompanyName
        p_Report.DataSource = p_datatable

        p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
        p_DataTable1 = GetDataTable(p_SQL, p_SQL)

        'labelDetail = New DevExpress.XtraReports.UI.XRLabel
        'p_Width = tableWidth - 20
        'labelDetail.HeightF = 1
        'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
        'labelDetail.WidthF = p_Width
        'labelDetail.LeftF = 10
        '.ReportFooter.Controls.Add(labelDetail)
        With p_Report
            'If Not p_DataTable1 Is Nothing Then
            '    p_count1 = p_DataTable1.Rows.Count
            '    If p_count1 > 0 Then
            '        p_Width = p_Report.PageSize.Width / p_count1
            '        p_Left_Title = 0
            '        p_Top_Title = 100
            '        For p_Count = 0 To p_count1 - 1
            '            labelDetail = New DevExpress.XtraReports.UI.XRLabel
            '            labelDetail.WidthF = p_Width
            '            labelDetail.LeftF = p_Left_Title
            '            labelDetail.Text = p_DataTable1.Rows(p_Count).Item("SDesc").ToString.Trim
            '            labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '            labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
            '            labelDetail.TopF = p_Top_Title
            '            ' p_Report.ReportFooter1.Controls.Add(labelDetail)
            '            p_Left_Title = p_Left_Title + labelDetail.WidthF
            '        Next
            '    End If

            'End If
            '   p_Top_Title = .XrLabel1.TopF + .XrLabel1.HeightF
            '  p_Left_Title = .XrLabel1.LeftF
            p_Top_Title = 110
            'Lay ra cac tham so co the treo len bao cao
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If

                        p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & "         Đến ngày:   " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
                                End If

                            End If
                        End If

                    End If

                    If StrParameter <> "" Then
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        'labelDetail.WidthF = .PageSize.Width - 30
                        labelDetail.WidthF = .PageSize.Width - 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If


            'p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ItemName='TuNgay'", "STT")
            'If p_Arr.Length > 0 Then
            '    For p_Count = 0 To p_Arr.Length - 1
            '        p_Row = p_Arr(p_Count)
            '        If p_Row.Item("ItemName").ToString.Trim <> "" Then
            '            p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
            '            If p_Object.Length > 0 Then
            '                If UCase(p_Object(0).name.ToString) = "TUNGAY" Then
            '                    '.Parameters.Item("Thang_Nam").Value = "Tháng  " & CDate(p_Object(0).editvalue).Month.ToString & "   năm  " & CDate(p_Object(0).editvalue).Year.ToString
            '                    .Parameters.Item("Thang_Nam").Value = "Tháng  " & CDate(p_Object(0).editvalue).ToString("MM") & "   năm  " & CDate(p_Object(0).editvalue).ToString("yyyy")
            '                End If
            '            End If
            '        End If
            '    Next
            'End If


            .Parameters.Item("NgayBaoCao").Value = "Ngày báo cáo: " & Now.Date.ToString("dd/MM/yyyy")

        End With
        p_Report.ShowPreviewDialog()


    End Sub

    Public Sub mdlRptTTLenhXuat(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        Dim p_ShowParent As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_Title As String = ""
        Dim p_Arr() As DataRow
        Dim p_SQL As String
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet
        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_count1 As Integer
        Dim p_DataTable1 As DataTable
        Dim p_Width As Integer
        Dim p_Left_Title As Integer
        Dim p_Top_Title As Integer
        Dim p_Report As New RptTTLX
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object


        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSetCompany Is Nothing Then
                    If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                        p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                    End If

                    If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                        p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                    End If

                End If
            End If

        End If

        p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        If p_Arr.Length > 0 Then
            If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                p_ShowCompany = True
            End If
            If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                p_ShowParent = True
            End If
            p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        End If


        'p_Report.lbTitle.Text = p_Title
        'p_Report.lbCompany.Text = p_CompanyName
        'p_Report.lbParent.Text = p_ParentCompanyName
        p_Report.DataSource = p_datatable

        p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
        p_DataTable1 = GetDataTable(p_SQL, p_SQL)

        'labelDetail = New DevExpress.XtraReports.UI.XRLabel
        'p_Width = tableWidth - 20
        'labelDetail.HeightF = 1
        'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
        'labelDetail.WidthF = p_Width
        'labelDetail.LeftF = 10
        '.ReportFooter.Controls.Add(labelDetail)
        With p_Report
            'If Not p_DataTable1 Is Nothing Then
            '    p_count1 = p_DataTable1.Rows.Count
            '    If p_count1 > 0 Then
            '        p_Width = p_Report.PageSize.Width / p_count1
            '        p_Left_Title = 0
            '        p_Top_Title = 100
            '        For p_Count = 0 To p_count1 - 1
            '            labelDetail = New DevExpress.XtraReports.UI.XRLabel
            '            labelDetail.WidthF = p_Width
            '            labelDetail.LeftF = p_Left_Title
            '            labelDetail.Text = p_DataTable1.Rows(p_Count).Item("SDesc").ToString.Trim
            '            labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '            labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
            '            labelDetail.TopF = p_Top_Title
            '            ' p_Report.ReportFooter1.Controls.Add(labelDetail)
            '            p_Left_Title = p_Left_Title + labelDetail.WidthF
            '        Next
            '    End If

            'End If
            '   p_Top_Title = .XrLabel1.TopF + .XrLabel1.HeightF
            '  p_Left_Title = .XrLabel1.LeftF
            p_Top_Title = 110
            'Lay ra cac tham so co the treo len bao cao
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If

                        p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & "         Đến ngày:   " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
                                End If

                            End If
                        End If

                    End If

                    If StrParameter <> "" Then
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        'labelDetail.WidthF = .PageSize.Width - 30
                        labelDetail.WidthF = .PageSize.Width - 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If


            'p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ItemName='TuNgay'", "STT")
            'If p_Arr.Length > 0 Then
            '    For p_Count = 0 To p_Arr.Length - 1
            '        p_Row = p_Arr(p_Count)
            '        If p_Row.Item("ItemName").ToString.Trim <> "" Then
            '            p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
            '            If p_Object.Length > 0 Then
            '                If UCase(p_Object(0).name.ToString) = "TUNGAY" Then
            '                    '.Parameters.Item("Thang_Nam").Value = "Tháng  " & CDate(p_Object(0).editvalue).Month.ToString & "   năm  " & CDate(p_Object(0).editvalue).Year.ToString
            '                    .Parameters.Item("Thang_Nam").Value = "Tháng  " & CDate(p_Object(0).editvalue).ToString("MM") & "   năm  " & CDate(p_Object(0).editvalue).ToString("yyyy")
            '                End If
            '            End If
            '        End If
            '    Next
            'End If


            .Parameters.Item("NgayBaoCao").Value = "Ngày báo cáo: " & Now.Date.ToString("dd/MM/yyyy")

        End With
        p_Report.ShowPreviewDialog()


    End Sub

    Public Sub mdlRptBM_01_26(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        Dim p_ShowParent As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_Title As String = ""
        Dim p_Arr() As DataRow
        Dim p_SQL As String
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet
        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_count1 As Integer
        Dim p_DataTable1 As DataTable
        Dim p_Width As Integer
        Dim p_Left_Title As Integer
        Dim p_Top_Title As Integer
        Dim p_Report As New RptBM_01_26
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable

        'For Each r As DataRow In dtTable.Rows
        '    If r.Item("LoaiXuat") <> "ZT" Then
        '        r.Delete()
        '        'dtTable.Rows.Remove(r)
        '    End If
        'Next
        'dtTable.AcceptChanges()
        'Dim query = From row In dtTable.Rows
        '               Order By row.DoiGiaoNhan, row.LoaiXuat, row.MaHangHoa, row.TenHangHoa, row.SoCongTo
        '               Group row By GroupKey = New With {
        '                        Key .DoiGiaoNhan = row.DoiGiaoNhan,
        '                        Key .LoaiXuat = row.LoaiXuat,
        '                        Key .MaHangHoa = row.MaHangHoa,
        '                        Key .TenHangHoa = row.TenHangHoa,
        '                        Key .SoCongTo = row.SoCongTo
        '               } Into NameGroup = Group
        '               Select New With {
        '                   .DoiGiaoNhan = GroupKey.DoiGiaoNhan,
        '                   .LoaiXuat = GroupKey.LoaiXuat,
        '                   .MaHangHoa = GroupKey.MaHangHoa,
        '                   .TenHangHoa = GroupKey.TenHangHoa,
        '                   .SoCongTo = GroupKey.SoCongTo,
        '                   .SluongCto = NameGroup.Sum(Function(r) r.SluongCto),
        '                   .SoLanXuat = NameGroup.Sum(Function(r) r.SoLanXuat),
        '                   .CCHH = NameGroup.Sum(Function(r) r.CCHH),
        '                   .SluongPtien = NameGroup.Sum(Function(r) r.SluongPtien),
        '                   .ClechSluong = NameGroup.Sum(Function(r) r.ClechSluong),
        '                   .ClechTyLe = NameGroup.Sum(Function(r) r.ClechTyLe)
        '                }
        'dtTable.Clear()
        'For Each row In query

        '    dtTable.Rows.Add(row)
        '    'Console.WriteLine(row.CCHH)
        'Next

        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSetCompany Is Nothing Then
                    If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                        p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                    End If

                    If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                        p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                    End If

                End If
            End If

        End If

        p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        If p_Arr.Length > 0 Then
            If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                p_ShowCompany = True
            End If
            If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                p_ShowParent = True
            End If
            p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        End If


        'p_Report.lbTitle.Text = p_Title
        'p_Report.lbCompany.Text = p_CompanyName
        'p_Report.lbParent.Text = p_ParentCompanyName
        p_Report.DataSource = p_datatable

        p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
        p_DataTable1 = GetDataTable(p_SQL, p_SQL)

        'labelDetail = New DevExpress.XtraReports.UI.XRLabel
        'p_Width = tableWidth - 20
        'labelDetail.HeightF = 1
        'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
        'labelDetail.WidthF = p_Width
        'labelDetail.LeftF = 10
        '.ReportFooter.Controls.Add(labelDetail)
        With p_Report
            'If Not p_DataTable1 Is Nothing Then
            '    p_count1 = p_DataTable1.Rows.Count
            '    If p_count1 > 0 Then
            '        p_Width = p_Report.PageSize.Width / p_count1
            '        p_Left_Title = 0
            '        p_Top_Title = 100
            '        For p_Count = 0 To p_count1 - 1
            '            labelDetail = New DevExpress.XtraReports.UI.XRLabel
            '            labelDetail.WidthF = p_Width
            '            labelDetail.LeftF = p_Left_Title
            '            labelDetail.Text = p_DataTable1.Rows(p_Count).Item("SDesc").ToString.Trim
            '            labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '            labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
            '            labelDetail.TopF = p_Top_Title
            '            ' p_Report.ReportFooter1.Controls.Add(labelDetail)
            '            p_Left_Title = p_Left_Title + labelDetail.WidthF
            '        Next
            '    End If

            'End If
            '   p_Top_Title = .XrLabel1.TopF + .XrLabel1.HeightF
            '  p_Left_Title = .XrLabel1.LeftF
            p_Top_Title = 110
            'Lay ra cac tham so co the treo len bao cao
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If
                        If p_Row.Item("ToItemName").ToString.Trim <> "" Then
                            p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                            If p_Object.Length > 0 Then
                                'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                                If Not p_Object(0).editvalue Is Nothing Then
                                    If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                        StrParameter = StrParameter & "             Đến ngày: " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                    Else
                                        StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
                                    End If

                                End If
                            End If
                        End If


                    End If

                    If StrParameter <> "" Then
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        'labelDetail.WidthF = .PageSize.Width - 30
                        labelDetail.WidthF = .PageSize.Width - 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If

            .Parameters.Item("NgayBaoCao").Value = "Ngày báo cáo: " & Now.Date.ToString("dd/MM/yyyy")
            .Parameters.Item("NgayBaoCao").Visible = False

            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ItemName='Client'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            If UCase(p_Object(0).name.ToString) = "CLIENT" Then
                                If Not p_Object(0).editvalue Is Nothing Then
                                    'If UCase(p_Object(0).editvalue.ToString) <> "ALL" Then
                                    .Parameters.Item("DoiGiaoNhan").Value = UCase(p_Object(0).editvalue.ToString)
                                    'End If
                                End If
                            End If
                        End If
                    End If
                Next
            End If
            .Parameters.Item("DoiGiaoNhan").Visible = False
        End With
        p_Report.ShowPreviewDialog()


    End Sub

    Public Sub mdlRptBM_02_03(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        Dim p_ShowParent As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_Title As String = ""
        Dim p_Arr() As DataRow
        Dim p_SQL As String
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet
        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_count1 As Integer
        Dim p_DataTable1 As DataTable
        Dim p_Width As Integer
        Dim p_Left_Title As Integer
        Dim p_Top_Title As Integer
        Dim p_Report As New RptBM_02_03
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable



        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSetCompany Is Nothing Then
                    If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                        p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                    End If

                    If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                        p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                    End If

                End If
            End If

        End If

        p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        If p_Arr.Length > 0 Then
            If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                p_ShowCompany = True
            End If
            If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                p_ShowParent = True
            End If
            p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        End If


        p_Report.DataSource = p_datatable

        p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
        p_DataTable1 = GetDataTable(p_SQL, p_SQL)

        With p_Report

            p_Top_Title = 110
            'Lay ra cac tham so co the treo len bao cao
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If
                        If p_Row.Item("ToItemName").ToString.Trim <> "" Then
                            p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                            If p_Object.Length > 0 Then
                                'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                                If Not p_Object(0).editvalue Is Nothing Then
                                    If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                        StrParameter = StrParameter & "             Đến ngày: " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                    Else
                                        StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
                                    End If

                                End If
                            End If
                        End If


                    End If

                    If StrParameter <> "" Then
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        'labelDetail.WidthF = .PageSize.Width - 30
                        labelDetail.WidthF = .PageSize.Width - 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If

            .Parameters.Item("NgayBaoCao").Value = "Ngày báo cáo: " & Now.Date.ToString("dd/MM/yyyy")
            .Parameters.Item("NgayBaoCao").Visible = False

            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ItemName='Client'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            If UCase(p_Object(0).name.ToString) = "CLIENT" Then
                                If Not p_Object(0).editvalue Is Nothing Then
                                    .Parameters.Item("DoiGiaoNhan").Value = UCase(p_Object(0).editvalue.ToString)
                                End If
                            End If
                        End If
                    End If
                Next
            End If
            .Parameters.Item("DoiGiaoNhan").Visible = False
        End With
        p_Report.ShowPreviewDialog()


    End Sub

    Public Sub mdlRptCongTo_Thuy(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        Dim p_ShowParent As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_Title As String = ""
        Dim p_Arr() As DataRow
        Dim p_SQL As String
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet
        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_count1 As Integer
        Dim p_DataTable1 As DataTable
        Dim p_Width As Integer
        Dim p_Left_Title As Integer
        Dim p_Top_Title As Integer
        Dim p_Report As New RptCongTo_Thuy
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable

        'For Each r As DataRow In dtTable.Rows
        '    If r.Item("LoaiXuat") <> "ZT" Then
        '        r.Delete()
        '        'dtTable.Rows.Remove(r)
        '    End If
        'Next
        'dtTable.AcceptChanges()
        'Dim query = From row In dtTable.Rows
        '               Order By row.DoiGiaoNhan, row.LoaiXuat, row.MaHangHoa, row.TenHangHoa, row.SoCongTo
        '               Group row By GroupKey = New With {
        '                        Key .DoiGiaoNhan = row.DoiGiaoNhan,
        '                        Key .LoaiXuat = row.LoaiXuat,
        '                        Key .MaHangHoa = row.MaHangHoa,
        '                        Key .TenHangHoa = row.TenHangHoa,
        '                        Key .SoCongTo = row.SoCongTo
        '               } Into NameGroup = Group
        '               Select New With {
        '                   .DoiGiaoNhan = GroupKey.DoiGiaoNhan,
        '                   .LoaiXuat = GroupKey.LoaiXuat,
        '                   .MaHangHoa = GroupKey.MaHangHoa,
        '                   .TenHangHoa = GroupKey.TenHangHoa,
        '                   .SoCongTo = GroupKey.SoCongTo,
        '                   .SluongCto = NameGroup.Sum(Function(r) r.SluongCto),
        '                   .SoLanXuat = NameGroup.Sum(Function(r) r.SoLanXuat),
        '                   .CCHH = NameGroup.Sum(Function(r) r.CCHH),
        '                   .SluongPtien = NameGroup.Sum(Function(r) r.SluongPtien),
        '                   .ClechSluong = NameGroup.Sum(Function(r) r.ClechSluong),
        '                   .ClechTyLe = NameGroup.Sum(Function(r) r.ClechTyLe)
        '                }
        'dtTable.Clear()
        'For Each row In query

        '    dtTable.Rows.Add(row)
        '    'Console.WriteLine(row.CCHH)
        'Next

        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSetCompany Is Nothing Then
                    If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                        p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                    End If

                    If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                        p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                    End If

                End If
            End If

        End If

        p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        If p_Arr.Length > 0 Then
            If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                p_ShowCompany = True
            End If
            If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                p_ShowParent = True
            End If
            p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        End If


        'p_Report.lbTitle.Text = p_Title
        'p_Report.lbCompany.Text = p_CompanyName
        'p_Report.lbParent.Text = p_ParentCompanyName
        p_Report.DataSource = p_datatable

        p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
        p_DataTable1 = GetDataTable(p_SQL, p_SQL)

        'labelDetail = New DevExpress.XtraReports.UI.XRLabel
        'p_Width = tableWidth - 20
        'labelDetail.HeightF = 1
        'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
        'labelDetail.WidthF = p_Width
        'labelDetail.LeftF = 10
        '.ReportFooter.Controls.Add(labelDetail)
        With p_Report
            'If Not p_DataTable1 Is Nothing Then
            '    p_count1 = p_DataTable1.Rows.Count
            '    If p_count1 > 0 Then
            '        p_Width = p_Report.PageSize.Width / p_count1
            '        p_Left_Title = 0
            '        p_Top_Title = 100
            '        For p_Count = 0 To p_count1 - 1
            '            labelDetail = New DevExpress.XtraReports.UI.XRLabel
            '            labelDetail.WidthF = p_Width
            '            labelDetail.LeftF = p_Left_Title
            '            labelDetail.Text = p_DataTable1.Rows(p_Count).Item("SDesc").ToString.Trim
            '            labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '            labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
            '            labelDetail.TopF = p_Top_Title
            '            ' p_Report.ReportFooter1.Controls.Add(labelDetail)
            '            p_Left_Title = p_Left_Title + labelDetail.WidthF
            '        Next
            '    End If

            'End If
            '   p_Top_Title = .XrLabel1.TopF + .XrLabel1.HeightF
            '  p_Left_Title = .XrLabel1.LeftF
            p_Top_Title = 110
            'Lay ra cac tham so co the treo len bao cao
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If
                        If p_Row.Item("ToItemName").ToString.Trim <> "" Then
                            p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                            If p_Object.Length > 0 Then
                                'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                                If Not p_Object(0).editvalue Is Nothing Then
                                    If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                        StrParameter = StrParameter & "   đến   " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                    Else
                                        StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
                                    End If

                                End If
                            End If
                        End If


                    End If

                    If StrParameter <> "" Then
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        'labelDetail.WidthF = .PageSize.Width - 30
                        labelDetail.WidthF = .PageSize.Width - 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If

            .Parameters.Item("RptDay").Value = Now.Date.ToString("dd")
            .Parameters.Item("RptThang").Value = Now.Date.ToString("MM")
            .Parameters.Item("RptNam").Value = Now.Date.ToString("yyyy")
            .Parameters.Item("RptDay").Visible = False
            .Parameters.Item("RptThang").Visible = False
            .Parameters.Item("RptNam").Visible = False
        End With
        p_Report.ShowPreviewDialog()


    End Sub

    Public Sub mdlRptCongTo_Bo(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        Dim p_ShowParent As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_Title As String = ""
        Dim p_Arr() As DataRow
        Dim p_SQL As String
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet
        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_count1 As Integer
        Dim p_DataTable1 As DataTable
        Dim p_Width As Integer
        Dim p_Left_Title As Integer
        Dim p_Top_Title As Integer
        Dim p_Report As New RptCongTo_Bo
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable

        'For Each r As DataRow In dtTable.Rows
        '    If r.Item("LoaiXuat") <> "ZT" Then
        '        r.Delete()
        '        'dtTable.Rows.Remove(r)
        '    End If
        'Next
        'dtTable.AcceptChanges()
        'Dim query = From row In dtTable.Rows
        '               Order By row.DoiGiaoNhan, row.LoaiXuat, row.MaHangHoa, row.TenHangHoa, row.SoCongTo
        '               Group row By GroupKey = New With {
        '                        Key .DoiGiaoNhan = row.DoiGiaoNhan,
        '                        Key .LoaiXuat = row.LoaiXuat,
        '                        Key .MaHangHoa = row.MaHangHoa,
        '                        Key .TenHangHoa = row.TenHangHoa,
        '                        Key .SoCongTo = row.SoCongTo
        '               } Into NameGroup = Group
        '               Select New With {
        '                   .DoiGiaoNhan = GroupKey.DoiGiaoNhan,
        '                   .LoaiXuat = GroupKey.LoaiXuat,
        '                   .MaHangHoa = GroupKey.MaHangHoa,
        '                   .TenHangHoa = GroupKey.TenHangHoa,
        '                   .SoCongTo = GroupKey.SoCongTo,
        '                   .SluongCto = NameGroup.Sum(Function(r) r.SluongCto),
        '                   .SoLanXuat = NameGroup.Sum(Function(r) r.SoLanXuat),
        '                   .CCHH = NameGroup.Sum(Function(r) r.CCHH),
        '                   .SluongPtien = NameGroup.Sum(Function(r) r.SluongPtien),
        '                   .ClechSluong = NameGroup.Sum(Function(r) r.ClechSluong),
        '                   .ClechTyLe = NameGroup.Sum(Function(r) r.ClechTyLe)
        '                }
        'dtTable.Clear()
        'For Each row In query

        '    dtTable.Rows.Add(row)
        '    'Console.WriteLine(row.CCHH)
        'Next

        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSetCompany Is Nothing Then
                    If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                        p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                    End If

                    If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                        p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                    End If

                End If
            End If

        End If

        p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        If p_Arr.Length > 0 Then
            If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                p_ShowCompany = True
            End If
            If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                p_ShowParent = True
            End If
            p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        End If


        'p_Report.lbTitle.Text = p_Title
        'p_Report.lbCompany.Text = p_CompanyName
        'p_Report.lbParent.Text = p_ParentCompanyName
        p_Report.DataSource = p_datatable

        p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
        p_DataTable1 = GetDataTable(p_SQL, p_SQL)

        'labelDetail = New DevExpress.XtraReports.UI.XRLabel
        'p_Width = tableWidth - 20
        'labelDetail.HeightF = 1
        'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
        'labelDetail.WidthF = p_Width
        'labelDetail.LeftF = 10
        '.ReportFooter.Controls.Add(labelDetail)
        With p_Report
            'If Not p_DataTable1 Is Nothing Then
            '    p_count1 = p_DataTable1.Rows.Count
            '    If p_count1 > 0 Then
            '        p_Width = p_Report.PageSize.Width / p_count1
            '        p_Left_Title = 0
            '        p_Top_Title = 100
            '        For p_Count = 0 To p_count1 - 1
            '            labelDetail = New DevExpress.XtraReports.UI.XRLabel
            '            labelDetail.WidthF = p_Width
            '            labelDetail.LeftF = p_Left_Title
            '            labelDetail.Text = p_DataTable1.Rows(p_Count).Item("SDesc").ToString.Trim
            '            labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '            labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
            '            labelDetail.TopF = p_Top_Title
            '            ' p_Report.ReportFooter1.Controls.Add(labelDetail)
            '            p_Left_Title = p_Left_Title + labelDetail.WidthF
            '        Next
            '    End If

            'End If
            '   p_Top_Title = .XrLabel1.TopF + .XrLabel1.HeightF
            '  p_Left_Title = .XrLabel1.LeftF
            p_Top_Title = 110
            'Lay ra cac tham so co the treo len bao cao
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If
                        If p_Row.Item("ToItemName").ToString.Trim <> "" Then
                            p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                            If p_Object.Length > 0 Then
                                'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                                If Not p_Object(0).editvalue Is Nothing Then
                                    If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                        StrParameter = StrParameter & "   đến   " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                    Else
                                        StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
                                    End If

                                End If
                            End If
                        End If


                    End If

                    If StrParameter <> "" Then
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        'labelDetail.WidthF = .PageSize.Width - 30
                        labelDetail.WidthF = .PageSize.Width - 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If

            .Parameters.Item("RptDay").Value = Now.Date.ToString("dd")
            .Parameters.Item("RptThang").Value = Now.Date.ToString("MM")
            .Parameters.Item("RptNam").Value = Now.Date.ToString("yyyy")
            .Parameters.Item("RptDay").Visible = False
            .Parameters.Item("RptThang").Visible = False
            .Parameters.Item("RptNam").Visible = False
        End With
        p_Report.ShowPreviewDialog()


    End Sub

    Public Sub mdlRptBM_14_03(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        Dim p_ShowParent As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_Title As String = ""
        Dim p_Arr() As DataRow
        Dim p_SQL As String
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet
        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_count1 As Integer
        Dim p_DataTable1 As DataTable
        Dim p_Width As Integer
        Dim p_Left_Title As Integer
        Dim p_Top_Title As Integer
        Dim p_Report As New RptBM_14_03
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable
        Dim vcf As String = String.Empty
        Dim slQC As String = String.Empty
        ' dtTable.Columns.Add("DVT")
        'Tính VCF, SluongQC
        'For Each r As DataRow In dtTable.Rows
        '    vcf = String.Empty

        '    If r.Item("Status").ToString.Trim = "3" Then
        '        Continue For
        '    End If

        '    'If r.Item("SoLenh").trim = "2015917787" Then
        '    '    MsgBox("fdsff")
        '    'End If

        '    vcf = mdlQCI_GetVCF_NS(IIf(IsDBNull(r.Item("NhietDo")), 0, r.Item("NhietDo")), IIf(IsDBNull(r.Item("TyTrong")), 0, r.Item("TyTrong")))

        '    'Dim _L15 As Decimal() = mdlQCI_CalculateQCI_NS(Decimal.Parse(IIf(IsDBNull(r.Item("SluongThucXuat")), 0, r.Item("SluongThucXuat").ToString)), "L", Decimal.Parse(IIf(IsDBNull(r.Item("NhietDo")), 0, r.Item("NhietDo").ToString)), r.Item("TyTrong").ToString)
        '    Dim _L15 As Decimal() = mdlQCI_CalculateQCI_NS(Decimal.Parse(IIf(IsDBNull(r.Item("SluongThucXuat_QCI")), 0, r.Item("SluongThucXuat_QCI").ToString)), "L", Decimal.Parse(IIf(IsDBNull(r.Item("NhietDo")), 0, r.Item("NhietDo").ToString)), Decimal.Parse(IIf(IsDBNull(r.Item("TyTrong")), 0, r.Item("TyTrong").ToString)))
        '    'slQC = _L15(1).ToString
        '    'r.Item("VCF") = vcf
        '    'r.Item("SluongQC") = slQC
        '    If Mid(r.Item("MaHangHoa").ToString.Trim, 1, 2) = "07" Then
        '        slQC = _L15(3).ToString
        '        r.Item("DVT") = "KG"
        '    Else
        '        slQC = _L15(1).ToString
        '        r.Item("DVT") = "L15"
        '    End If

        '    If vcf <> "" Then
        '        r.Item("VCF") = vcf
        '    End If

        '    r.Item("SluongQC") = slQC

        'Next

        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSetCompany Is Nothing Then
                    If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                        p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                    End If

                    If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                        p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                    End If

                End If
            End If

        End If

        p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        If p_Arr.Length > 0 Then
            If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                p_ShowCompany = True
            End If
            If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                p_ShowParent = True
            End If
            p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        End If


        'p_Report.lbTitle.Text = p_Title
        'p_Report.lbCompany.Text = p_CompanyName
        'p_Report.lbParent.Text = p_ParentCompanyName
        p_Report.DataSource = p_datatable

        p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
        p_DataTable1 = GetDataTable(p_SQL, p_SQL)

        'labelDetail = New DevExpress.XtraReports.UI.XRLabel
        'p_Width = tableWidth - 20
        'labelDetail.HeightF = 1
        'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
        'labelDetail.WidthF = p_Width
        'labelDetail.LeftF = 10
        '.ReportFooter.Controls.Add(labelDetail)
        With p_Report
            'If Not p_DataTable1 Is Nothing Then
            '    p_count1 = p_DataTable1.Rows.Count
            '    If p_count1 > 0 Then
            '        p_Width = p_Report.PageSize.Width / p_count1
            '        p_Left_Title = 0
            '        p_Top_Title = 100
            '        For p_Count = 0 To p_count1 - 1
            '            labelDetail = New DevExpress.XtraReports.UI.XRLabel
            '            labelDetail.WidthF = p_Width
            '            labelDetail.LeftF = p_Left_Title
            '            labelDetail.Text = p_DataTable1.Rows(p_Count).Item("SDesc").ToString.Trim
            '            labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '            labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
            '            labelDetail.TopF = p_Top_Title
            '            ' p_Report.ReportFooter1.Controls.Add(labelDetail)
            '            p_Left_Title = p_Left_Title + labelDetail.WidthF
            '        Next
            '    End If

            'End If
            '   p_Top_Title = .XrLabel1.TopF + .XrLabel1.HeightF
            '  p_Left_Title = .XrLabel1.LeftF
            p_Top_Title = 110
            'Lay ra cac tham so co the treo len bao cao
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If

                        If p_Row.Item("ToItemName").ToString.Trim <> "" Then
                            p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                            If p_Object.Length > 0 Then
                                'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                                If Not p_Object(0).editvalue Is Nothing Then
                                    If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                        StrParameter = StrParameter & "         Đến ngày:  " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                    Else
                                        StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
                                    End If

                                End If
                            End If
                        End If

                    End If

                    If StrParameter <> "" Then
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        'labelDetail.WidthF = .PageSize.Width - 30
                        labelDetail.WidthF = .PageSize.Width - 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If

            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ItemName='Client'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            If UCase(p_Object(0).name.ToString) = "CLIENT" Then
                                If Not p_Object(0).editvalue Is Nothing Then

                                    .Parameters.Item("DoiGiaoNhan").Value = UCase(p_Object(0).editvalue.ToString)
                                End If
                            End If
                        End If
                    End If
                Next
            End If
            .Parameters.Item("DoiGiaoNhan").Visible = False
        End With
        p_Report.ShowPreviewDialog()


    End Sub

    Public Sub mdlRptBM_05_04(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        Dim p_ShowParent As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_Title As String = ""
        Dim p_Arr() As DataRow
        Dim p_SQL As String
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet
        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_count1 As Integer
        Dim p_DataTable1 As DataTable
        Dim p_Width As Integer
        Dim p_Left_Title As Integer
        Dim p_Top_Title As Integer
        Dim p_Report As New RptBM_05_04
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable
        Dim vcf As String = String.Empty
        Dim slQC As String = String.Empty

        '    dtTable.Columns.Add("DVT")
        'Tính VCF, SluongQC
        'For Each r As DataRow In dtTable.Rows
        '    vcf = mdlQCI_GetVCF_NS("35.44", "0.8449")

        'Next
        '    vcf = String.Empty
        '    If r.Item("Status").ToString.Trim = "3" Then
        '        Continue For
        '    End If
        '    'If r.Item("SoLenh").ToString = "2013351295" Then
        '    '    MsgBox("sdfds")
        '    'End If

        '    If Not IsDBNull(r.Item("SoCongTo")) Then
        '        vcf = mdlQCI_GetVCF_NS(IIf(IsDBNull(r.Item("NhietDo")), 0, r.Item("NhietDo")), IIf(IsDBNull(r.Item("TyTrong")), 0, r.Item("TyTrong")))
        '    End If
        '    '=======>>>>>>> .theirs
        '    vcf = mdlQCI_GetVCF_NS(IIf(IsDBNull(r.Item("NhietDo")), 0, r.Item("NhietDo")), IIf(IsDBNull(r.Item("TyTrong")), 0, r.Item("TyTrong")))

        '    'Dim _L15 As Decimal() = mdlQCI_CalculateQCI_NS(Decimal.Parse(IIf(IsDBNull(r.Item("SluongThucXuat")), 0, r.Item("SluongThucXuat").ToString)), "L", Decimal.Parse(IIf(IsDBNull(r.Item("NhietDo")), 0, r.Item("NhietDo").ToString)), r.Item("TyTrong").ToString)
        '    Dim _L15 As Decimal() = mdlQCI_CalculateQCI_NS(Decimal.Parse(IIf(IsDBNull(r.Item("SluongThucXuat")), 0, r.Item("SluongThucXuat").ToString)), _
        '                                                    "L", Decimal.Parse(IIf(IsDBNull(r.Item("NhietDo")), 0, r.Item("NhietDo").ToString)), _
        '                                                    Decimal.Parse(IIf(IsDBNull(r.Item("TyTrong")), 0, r.Item("TyTrong").ToString)), vcf.ToString)
        '    If Mid(r.Item("MaHangHoa").ToString.Trim, 1, 2) = "07" Then
        '        slQC = _L15(3).ToString
        '        r.Item("DVT") = "KG"
        '    Else
        '        slQC = _L15(1).ToString
        '        r.Item("DVT") = "L15"
        '    End If

        '    If vcf <> "" Then
        '        r.Item("VCF") = vcf
        '    End If

        '    r.Item("SluongQC") = slQC

        'Next


        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSetCompany Is Nothing Then
                    If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                        p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                    End If

                    If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                        p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                    End If

                End If
            End If

        End If

        p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        If p_Arr.Length > 0 Then
            If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                p_ShowCompany = True
            End If
            If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                p_ShowParent = True
            End If
            p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        End If


        'p_Report.lbTitle.Text = p_Title
        'p_Report.lbCompany.Text = p_CompanyName
        'p_Report.lbParent.Text = p_ParentCompanyName
        p_Report.DataSource = p_datatable

        p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
        p_DataTable1 = GetDataTable(p_SQL, p_SQL)

        'labelDetail = New DevExpress.XtraReports.UI.XRLabel
        'p_Width = tableWidth - 20
        'labelDetail.HeightF = 1
        'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
        'labelDetail.WidthF = p_Width
        'labelDetail.LeftF = 10
        '.ReportFooter.Controls.Add(labelDetail)
        With p_Report
            'If Not p_DataTable1 Is Nothing Then
            '    p_count1 = p_DataTable1.Rows.Count
            '    If p_count1 > 0 Then
            '        p_Width = p_Report.PageSize.Width / p_count1
            '        p_Left_Title = 0
            '        p_Top_Title = 100
            '        For p_Count = 0 To p_count1 - 1
            '            labelDetail = New DevExpress.XtraReports.UI.XRLabel
            '            labelDetail.WidthF = p_Width
            '            labelDetail.LeftF = p_Left_Title
            '            labelDetail.Text = p_DataTable1.Rows(p_Count).Item("SDesc").ToString.Trim
            '            labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '            labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
            '            labelDetail.TopF = p_Top_Title
            '            ' p_Report.ReportFooter1.Controls.Add(labelDetail)
            '            p_Left_Title = p_Left_Title + labelDetail.WidthF
            '        Next
            '    End If

            'End If
            '   p_Top_Title = .XrLabel1.TopF + .XrLabel1.HeightF
            '  p_Left_Title = .XrLabel1.LeftF
            p_Top_Title = 110
            'Lay ra cac tham so co the treo len bao cao
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then

                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If
                        If p_Row.Item("ToItemName").ToString.Trim <> "" Then
                            p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                            If p_Object.Length > 0 Then
                                'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                                If Not p_Object(0).editvalue Is Nothing Then
                                    If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                        StrParameter = StrParameter & "         Đến ngày:   " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                    Else
                                        StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
                                    End If

                                End If
                            End If
                        End If


                    End If

                    If StrParameter <> "" Then
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        'labelDetail.WidthF = .PageSize.Width - 30
                        labelDetail.WidthF = .PageSize.Width - 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If

            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ItemName='Client'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            If UCase(p_Object(0).name.ToString) = "CLIENT" Then
                                If Not p_Object(0).editvalue Is Nothing Then
                                    .Parameters.Item("DoiGiaoNhan").Value = UCase(p_Object(0).editvalue.ToString)
                                End If
                            End If
                        End If
                    End If
                Next
            End If
            .Parameters.Item("DoiGiaoNhan").Visible = False
        End With

        p_Report.ShowPreviewDialog()


    End Sub

    Public Sub mdlXeBonTH(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        Dim p_ShowParent As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_Title As String = ""
        Dim p_Arr() As DataRow
        Dim p_SQL As String
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet
        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_count1 As Integer
        Dim p_DataTable1 As DataTable
        Dim p_Width As Integer
        Dim p_Left_Title As Integer
        Dim p_Top_Title As Integer
        Dim p_Report As New RptXeBonTH
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable
        Dim vcf As String = String.Empty
        Dim slQC As String = String.Empty

        '    dtTable.Columns.Add("DVT")
        'Tính VCF, SluongQC
        'For Each r As DataRow In dtTable.Rows
        '    vcf = mdlQCI_GetVCF_NS("35.44", "0.8449")

        'Next
        '    vcf = String.Empty
        '    If r.Item("Status").ToString.Trim = "3" Then
        '        Continue For
        '    End If
        '    'If r.Item("SoLenh").ToString = "2013351295" Then
        '    '    MsgBox("sdfds")
        '    'End If

        '    If Not IsDBNull(r.Item("SoCongTo")) Then
        '        vcf = mdlQCI_GetVCF_NS(IIf(IsDBNull(r.Item("NhietDo")), 0, r.Item("NhietDo")), IIf(IsDBNull(r.Item("TyTrong")), 0, r.Item("TyTrong")))
        '    End If
        '    '=======>>>>>>> .theirs
        '    vcf = mdlQCI_GetVCF_NS(IIf(IsDBNull(r.Item("NhietDo")), 0, r.Item("NhietDo")), IIf(IsDBNull(r.Item("TyTrong")), 0, r.Item("TyTrong")))

        '    'Dim _L15 As Decimal() = mdlQCI_CalculateQCI_NS(Decimal.Parse(IIf(IsDBNull(r.Item("SluongThucXuat")), 0, r.Item("SluongThucXuat").ToString)), "L", Decimal.Parse(IIf(IsDBNull(r.Item("NhietDo")), 0, r.Item("NhietDo").ToString)), r.Item("TyTrong").ToString)
        '    Dim _L15 As Decimal() = mdlQCI_CalculateQCI_NS(Decimal.Parse(IIf(IsDBNull(r.Item("SluongThucXuat")), 0, r.Item("SluongThucXuat").ToString)), _
        '                                                    "L", Decimal.Parse(IIf(IsDBNull(r.Item("NhietDo")), 0, r.Item("NhietDo").ToString)), _
        '                                                    Decimal.Parse(IIf(IsDBNull(r.Item("TyTrong")), 0, r.Item("TyTrong").ToString)), vcf.ToString)
        '    If Mid(r.Item("MaHangHoa").ToString.Trim, 1, 2) = "07" Then
        '        slQC = _L15(3).ToString
        '        r.Item("DVT") = "KG"
        '    Else
        '        slQC = _L15(1).ToString
        '        r.Item("DVT") = "L15"
        '    End If

        '    If vcf <> "" Then
        '        r.Item("VCF") = vcf
        '    End If

        '    r.Item("SluongQC") = slQC

        'Next


        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSetCompany Is Nothing Then
                    If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                        p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                    End If

                    If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                        p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                    End If

                End If
            End If

        End If

        p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        If p_Arr.Length > 0 Then
            If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                p_ShowCompany = True
            End If
            If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                p_ShowParent = True
            End If
            p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        End If


        'p_Report.lbTitle.Text = p_Title
        'p_Report.lbCompany.Text = p_CompanyName
        'p_Report.lbParent.Text = p_ParentCompanyName
        p_Report.DataSource = p_datatable

        p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
        p_DataTable1 = GetDataTable(p_SQL, p_SQL)

        'labelDetail = New DevExpress.XtraReports.UI.XRLabel
        'p_Width = tableWidth - 20
        'labelDetail.HeightF = 1
        'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
        'labelDetail.WidthF = p_Width
        'labelDetail.LeftF = 10
        '.ReportFooter.Controls.Add(labelDetail)
        With p_Report
            'If Not p_DataTable1 Is Nothing Then
            '    p_count1 = p_DataTable1.Rows.Count
            '    If p_count1 > 0 Then
            '        p_Width = p_Report.PageSize.Width / p_count1
            '        p_Left_Title = 0
            '        p_Top_Title = 100
            '        For p_Count = 0 To p_count1 - 1
            '            labelDetail = New DevExpress.XtraReports.UI.XRLabel
            '            labelDetail.WidthF = p_Width
            '            labelDetail.LeftF = p_Left_Title
            '            labelDetail.Text = p_DataTable1.Rows(p_Count).Item("SDesc").ToString.Trim
            '            labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '            labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
            '            labelDetail.TopF = p_Top_Title
            '            ' p_Report.ReportFooter1.Controls.Add(labelDetail)
            '            p_Left_Title = p_Left_Title + labelDetail.WidthF
            '        Next
            '    End If

            'End If
            '   p_Top_Title = .XrLabel1.TopF + .XrLabel1.HeightF
            '  p_Left_Title = .XrLabel1.LeftF
            p_Top_Title = 110
            'Lay ra cac tham so co the treo len bao cao
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then

                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If
                        If p_Row.Item("ToItemName").ToString.Trim <> "" Then
                            p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                            If p_Object.Length > 0 Then
                                'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                                If Not p_Object(0).editvalue Is Nothing Then
                                    If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                        StrParameter = StrParameter & "         Đến ngày:   " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                    Else
                                        StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
                                    End If

                                End If
                            End If
                        End If


                    End If

                    If StrParameter <> "" Then
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        'labelDetail.WidthF = .PageSize.Width - 30
                        labelDetail.WidthF = .PageSize.Width - 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If

            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ItemName='Client'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            If UCase(p_Object(0).name.ToString) = "CLIENT" Then
                                If Not p_Object(0).editvalue Is Nothing Then
                                    .Parameters.Item("DoiGiaoNhan").Value = UCase(p_Object(0).editvalue.ToString)
                                End If
                            End If
                        End If
                    End If
                Next
            End If
            .Parameters.Item("DoiGiaoNhan").Visible = False
        End With

        p_Report.ShowPreviewDialog()


    End Sub
    Public Sub mdlXaLanTH(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        Dim p_ShowParent As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_Title As String = ""
        Dim p_Arr() As DataRow
        Dim p_SQL As String
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet
        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_count1 As Integer
        Dim p_DataTable1 As DataTable
        Dim p_Width As Integer
        Dim p_Left_Title As Integer
        Dim p_Top_Title As Integer
        Dim p_Report As New RptXaLanTH
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable
        Dim vcf As String = String.Empty
        Dim slQC As String = String.Empty
        ' dtTable.Columns.Add("DVT")
        'Tính VCF, SluongQC
        'For Each r As DataRow In dtTable.Rows
        '    vcf = String.Empty

        '    If r.Item("Status").ToString.Trim = "3" Then
        '        Continue For
        '    End If

        '    'If r.Item("SoLenh").trim = "2015917787" Then
        '    '    MsgBox("fdsff")
        '    'End If

        '    vcf = mdlQCI_GetVCF_NS(IIf(IsDBNull(r.Item("NhietDo")), 0, r.Item("NhietDo")), IIf(IsDBNull(r.Item("TyTrong")), 0, r.Item("TyTrong")))

        '    'Dim _L15 As Decimal() = mdlQCI_CalculateQCI_NS(Decimal.Parse(IIf(IsDBNull(r.Item("SluongThucXuat")), 0, r.Item("SluongThucXuat").ToString)), "L", Decimal.Parse(IIf(IsDBNull(r.Item("NhietDo")), 0, r.Item("NhietDo").ToString)), r.Item("TyTrong").ToString)
        '    Dim _L15 As Decimal() = mdlQCI_CalculateQCI_NS(Decimal.Parse(IIf(IsDBNull(r.Item("SluongThucXuat_QCI")), 0, r.Item("SluongThucXuat_QCI").ToString)), "L", Decimal.Parse(IIf(IsDBNull(r.Item("NhietDo")), 0, r.Item("NhietDo").ToString)), Decimal.Parse(IIf(IsDBNull(r.Item("TyTrong")), 0, r.Item("TyTrong").ToString)))
        '    'slQC = _L15(1).ToString
        '    'r.Item("VCF") = vcf
        '    'r.Item("SluongQC") = slQC
        '    If Mid(r.Item("MaHangHoa").ToString.Trim, 1, 2) = "07" Then
        '        slQC = _L15(3).ToString
        '        r.Item("DVT") = "KG"
        '    Else
        '        slQC = _L15(1).ToString
        '        r.Item("DVT") = "L15"
        '    End If

        '    If vcf <> "" Then
        '        r.Item("VCF") = vcf
        '    End If

        '    r.Item("SluongQC") = slQC

        'Next

        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSetCompany Is Nothing Then
                    If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                        p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                    End If

                    If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                        p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                    End If

                End If
            End If

        End If

        p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        If p_Arr.Length > 0 Then
            If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                p_ShowCompany = True
            End If
            If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                p_ShowParent = True
            End If
            p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        End If


        'p_Report.lbTitle.Text = p_Title
        'p_Report.lbCompany.Text = p_CompanyName
        'p_Report.lbParent.Text = p_ParentCompanyName
        p_Report.DataSource = p_datatable

        p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
        p_DataTable1 = GetDataTable(p_SQL, p_SQL)

        'labelDetail = New DevExpress.XtraReports.UI.XRLabel
        'p_Width = tableWidth - 20
        'labelDetail.HeightF = 1
        'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
        'labelDetail.WidthF = p_Width
        'labelDetail.LeftF = 10
        '.ReportFooter.Controls.Add(labelDetail)
        With p_Report
            'If Not p_DataTable1 Is Nothing Then
            '    p_count1 = p_DataTable1.Rows.Count
            '    If p_count1 > 0 Then
            '        p_Width = p_Report.PageSize.Width / p_count1
            '        p_Left_Title = 0
            '        p_Top_Title = 100
            '        For p_Count = 0 To p_count1 - 1
            '            labelDetail = New DevExpress.XtraReports.UI.XRLabel
            '            labelDetail.WidthF = p_Width
            '            labelDetail.LeftF = p_Left_Title
            '            labelDetail.Text = p_DataTable1.Rows(p_Count).Item("SDesc").ToString.Trim
            '            labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '            labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
            '            labelDetail.TopF = p_Top_Title
            '            ' p_Report.ReportFooter1.Controls.Add(labelDetail)
            '            p_Left_Title = p_Left_Title + labelDetail.WidthF
            '        Next
            '    End If

            'End If
            '   p_Top_Title = .XrLabel1.TopF + .XrLabel1.HeightF
            '  p_Left_Title = .XrLabel1.LeftF
            p_Top_Title = 110
            'Lay ra cac tham so co the treo len bao cao
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If

                        If p_Row.Item("ToItemName").ToString.Trim <> "" Then
                            p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                            If p_Object.Length > 0 Then
                                'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                                If Not p_Object(0).editvalue Is Nothing Then
                                    If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                        StrParameter = StrParameter & "         Đến ngày:  " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                    Else
                                        StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
                                    End If

                                End If
                            End If
                        End If

                    End If

                    If StrParameter <> "" Then
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        'labelDetail.WidthF = .PageSize.Width - 30
                        labelDetail.WidthF = .PageSize.Width - 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If

            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ItemName='Client'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            If UCase(p_Object(0).name.ToString) = "CLIENT" Then
                                If Not p_Object(0).editvalue Is Nothing Then

                                    .Parameters.Item("DoiGiaoNhan").Value = UCase(p_Object(0).editvalue.ToString)
                                End If
                            End If
                        End If
                    End If
                Next
            End If
            .Parameters.Item("DoiGiaoNhan").Visible = False
        End With
        p_Report.ShowPreviewDialog()


    End Sub

    Public Sub mdlRptBM_01_32(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        Dim p_ShowParent As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_Title As String = ""
        Dim p_Arr() As DataRow
        Dim p_SQL As String
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet
        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_count1 As Integer
        Dim p_DataTable1 As DataTable
        Dim p_Width As Integer
        Dim p_Left_Title As Integer
        Dim p_Top_Title As Integer
        Dim p_Report As New RptBM_01_32
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object


        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSetCompany Is Nothing Then
                    If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                        p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                    End If

                    If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                        p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                    End If

                End If
            End If

        End If

        p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        If p_Arr.Length > 0 Then
            If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                p_ShowCompany = True
            End If
            If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                p_ShowParent = True
            End If
            p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        End If


        'p_Report.lbTitle.Text = p_Title
        'p_Report.lbCompany.Text = p_CompanyName
        'p_Report.lbParent.Text = p_ParentCompanyName
        p_Report.DataSource = p_datatable

        p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
        p_DataTable1 = GetDataTable(p_SQL, p_SQL)

        'labelDetail = New DevExpress.XtraReports.UI.XRLabel
        'p_Width = tableWidth - 20
        'labelDetail.HeightF = 1
        'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
        'labelDetail.WidthF = p_Width
        'labelDetail.LeftF = 10
        '.ReportFooter.Controls.Add(labelDetail)
        With p_Report
            'If Not p_DataTable1 Is Nothing Then
            '    p_count1 = p_DataTable1.Rows.Count
            '    If p_count1 > 0 Then
            '        p_Width = p_Report.PageSize.Width / p_count1
            '        p_Left_Title = 0
            '        p_Top_Title = 100
            '        For p_Count = 0 To p_count1 - 1
            '            labelDetail = New DevExpress.XtraReports.UI.XRLabel
            '            labelDetail.WidthF = p_Width
            '            labelDetail.LeftF = p_Left_Title
            '            labelDetail.Text = p_DataTable1.Rows(p_Count).Item("SDesc").ToString.Trim
            '            labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '            labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
            '            labelDetail.TopF = p_Top_Title
            '            ' p_Report.ReportFooter1.Controls.Add(labelDetail)
            '            p_Left_Title = p_Left_Title + labelDetail.WidthF
            '        Next
            '    End If

            'End If
            '   p_Top_Title = .XrLabel1.TopF + .XrLabel1.HeightF
            '  p_Left_Title = .XrLabel1.LeftF
            p_Top_Title = 110
            'Lay ra cac tham so co the treo len bao cao
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If

                        p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & "         Đến ngày:   " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
                                End If

                            End If
                        End If

                    End If

                    If StrParameter <> "" Then
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        'labelDetail.WidthF = .PageSize.Width - 30
                        labelDetail.WidthF = .PageSize.Width - 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If


            'p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ItemName='TuNgay'", "STT")
            'If p_Arr.Length > 0 Then
            '    For p_Count = 0 To p_Arr.Length - 1
            '        p_Row = p_Arr(p_Count)
            '        If p_Row.Item("ItemName").ToString.Trim <> "" Then
            '            p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
            '            If p_Object.Length > 0 Then
            '                If UCase(p_Object(0).name.ToString) = "TUNGAY" Then
            '                    '.Parameters.Item("Thang_Nam").Value = "Tháng  " & CDate(p_Object(0).editvalue).Month.ToString & "   năm  " & CDate(p_Object(0).editvalue).Year.ToString
            '                    .Parameters.Item("Thang_Nam").Value = "Tháng  " & CDate(p_Object(0).editvalue).ToString("MM") & "   năm  " & CDate(p_Object(0).editvalue).ToString("yyyy")
            '                End If
            '            End If
            '        End If
            '    Next
            'End If


            .Parameters.Item("NgayBaoCao").Value = "Ngày báo cáo: " & Now.Date.ToString("dd/MM/yyyy")

        End With
        p_Report.ShowPreviewDialog()


    End Sub

    Public Sub InBaoCao(ByVal p_datatable As DataTable, ByVal p_ReportCode As String)

        Select Case p_ReportCode
            Case "BM_01_32"
                Dim p_Report As New RptBM_01_32

                p_Report.DataSource = p_datatable
                p_Report.ShowPreviewDialog()

            Case Else

        End Select


    End Sub


    Public Function Get_HoaDon_ChiTietNew(ByVal i_SoLenh As String) As DataTable
        Dim err As String = String.Empty
        Dim DtTable As DataTable
        Dim p_SQL As String
        Try
            p_SQL = "exec FPT_HoaDon_ChiTietE5 '" & i_SoLenh & "'"
            DtTable = GetDataTable(p_SQL, p_SQL)
            DtTable = Alter_table_HoaDon(DtTable)
            Return DtTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Alter_table_HoaDon(ByVal i_dtTable As DataTable) As DataTable

        '01/02/2013 QUEHV - Them moi column WCF,L15,KG
        Dim dtHoaDon As DataTable = i_dtTable
        Dim col As DataColumn
        Dim vcf As String = String.Empty
        Dim wcf As String = String.Empty
        Dim l15 As String = String.Empty
        Dim kg As String = String.Empty

        For Each r As DataRow In dtHoaDon.Rows
            vcf = String.Empty
            wcf = String.Empty
            vcf = mdlQCI_GetVCF_NS(IIf(IsDBNull(r.Item("NhiệtĐộ")), 0, r.Item("NhiệtĐộ")), IIf(IsDBNull(r.Item("TỷTrọng")), 0, r.Item("TỷTrọng")))
            wcf = mdlQCI_GetWCF(IIf(IsDBNull(r.Item("TỷTrọng")), 0, r.Item("TỷTrọng")))

            'If _dtPara.Rows(16).Item("Value_nd").ToString().Trim() = "1" Then
            Dim _L15 As Decimal() = mdlQCI_CalculateQCI_NS(Decimal.Parse(IIf(IsDBNull(r.Item("TổngXuất")), 0, r.Item("TổngXuất").ToString)), "L", Decimal.Parse(IIf(IsDBNull(r.Item("NhiệtĐộ")), 0, r.Item("NhiệtĐộ").ToString)), r.Item("TỷTrọng").ToString)
            l15 = _L15(1).ToString
            kg = _L15(3).ToString
            'Else
            '    Dim _L15 As Decimal() = mdlQCI_CalculateQCI(_SQLConnectionString, Decimal.Parse(IIf(IsDBNull(r.Item("TổngDựXuất")), 0, r.Item("TổngDựXuất").ToString)), r.Item("ĐơnVịTính").ToString, Decimal.Parse(IIf(IsDBNull(r.Item("NhiệtĐộ")), 0, r.Item("NhiệtĐộ").ToString)), r.Item("TỷTrọng").ToString)
            '    l15 = _L15(1).ToString
            '    kg = _L15(3).ToString
            'End If
            r.Item("VCF") = vcf
            r.Item("WCF") = wcf
            ' r.Item("L15") = l15
            'FES
            '20141027
            If CheckItemToScada2(r.Item("MãHàngHóa")) <> "Y" Then
                r.Item("L15") = l15
            End If
            r.Item("KG") = kg
        Next
        Return dtHoaDon
    End Function


    'FES
    '20141006
    'Ham thuc hien keim tra neu la hang hoa day sang Scada2 thi tra ve Y neu khong tra ve N. Loi tra ve E
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


    Public Function mdlDelivery_CheckTransmot(ByVal i_mavanchuyen As String, ByVal i_dt_para As DataTable) As String
        Dim l_bo, _
            l_thuy, _
            l_sat As String()
        Dim p_ArrRow() As DataRow
        Try
            '----------------------------------------------------------------
            '   Para:
            '       Index 0: Bo
            '       Index 1: Thuy
            '----------------------------------------------------------------
            p_ArrRow = i_dt_para.Select("Para='Bo' or Para='BO'")
            If p_ArrRow.Length > 0 Then
                l_bo = p_ArrRow(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            End If
            p_ArrRow = i_dt_para.Select("Para='Thuy' or Para='THUY'")
            If p_ArrRow.Length > 0 Then
                l_thuy = p_ArrRow(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            End If

            'l_bo = i_dt_para.Rows(0).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)
            'l_thuy = i_dt_para.Rows(1).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)

            'FES KV2
            '20141014
            '            l_sat = i_dt_para.Rows(12).Item("Value_nd").ToString().Split(New String() {"."}, StringSplitOptions.RemoveEmptyEntries)

            For i As Integer = 0 To l_bo.Length - 1
                If l_bo(i).Trim() = i_mavanchuyen.Trim() Then
                    Return "Bo"
                End If
            Next

            For i As Integer = 0 To l_thuy.Length - 1
                If l_thuy(i).Trim() = i_mavanchuyen.Trim() Then
                    Return "Thuy"
                End If
            Next

            For i As Integer = 0 To l_sat.Length - 1
                If l_sat(i).Trim() = i_mavanchuyen.Trim() Then
                    Return "Sat"
                End If
            Next

            Return String.Empty

        Catch ex As Exception
            Return String.Empty
        End Try

    End Function

    Public Sub mdlRptTTHangHoa(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
        Dim p_ShowParent As Boolean = False
        Dim p_ShowCompany As Boolean = False
        Dim p_Title As String = ""
        Dim p_Arr() As DataRow
        Dim p_SQL As String
        Dim p_TableCompany As DataTable
        Dim p_DataSetCompany As DataSet
        Dim p_CompanyName As String = ""
        Dim p_ParentCompanyName As String = ""
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_count1 As Integer
        Dim p_DataTable1 As DataTable
        Dim p_Width As Integer
        Dim p_Left_Title As Integer
        Dim p_Top_Title As Integer
        Dim p_Report As New RptTTHH
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object


        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
                p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
                p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
                If Not p_DataSetCompany Is Nothing Then
                    If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
                        p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
                    End If

                    If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
                        p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
                    End If

                End If
            End If

        End If

        p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        If p_Arr.Length > 0 Then
            If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
                p_ShowCompany = True
            End If
            If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
                p_ShowParent = True
            End If
            p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        End If


        'p_Report.lbTitle.Text = p_Title
        'p_Report.lbCompany.Text = p_CompanyName
        'p_Report.lbParent.Text = p_ParentCompanyName
        p_Report.DataSource = p_datatable

        p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
        p_DataTable1 = GetDataTable(p_SQL, p_SQL)

        'labelDetail = New DevExpress.XtraReports.UI.XRLabel
        'p_Width = tableWidth - 20
        'labelDetail.HeightF = 1
        'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.All
        'labelDetail.WidthF = p_Width
        'labelDetail.LeftF = 10
        '.ReportFooter.Controls.Add(labelDetail)
        With p_Report
            'If Not p_DataTable1 Is Nothing Then
            '    p_count1 = p_DataTable1.Rows.Count
            '    If p_count1 > 0 Then
            '        p_Width = p_Report.PageSize.Width / p_count1
            '        p_Left_Title = 0
            '        p_Top_Title = 100
            '        For p_Count = 0 To p_count1 - 1
            '            labelDetail = New DevExpress.XtraReports.UI.XRLabel
            '            labelDetail.WidthF = p_Width
            '            labelDetail.LeftF = p_Left_Title
            '            labelDetail.Text = p_DataTable1.Rows(p_Count).Item("SDesc").ToString.Trim
            '            labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '            labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Bold)
            '            labelDetail.TopF = p_Top_Title
            '            ' p_Report.ReportFooter1.Controls.Add(labelDetail)
            '            p_Left_Title = p_Left_Title + labelDetail.WidthF
            '        Next
            '    End If

            'End If
            '   p_Top_Title = .XrLabel1.TopF + .XrLabel1.HeightF
            '  p_Left_Title = .XrLabel1.LeftF
            p_Top_Title = 110
            'Lay ra cac tham so co the treo len bao cao
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    StrParameter = ""
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & " " & p_Object(0).editvalue
                                End If
                            End If

                        End If

                        p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & "         Đến ngày:   " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
                                Else
                                    StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
                                End If

                            End If
                        End If

                    End If

                    If StrParameter <> "" Then
                        labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        'labelDetail.WidthF = .PageSize.Width - 30
                        labelDetail.WidthF = .PageSize.Width - 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If


            'p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ItemName='TuNgay'", "STT")
            'If p_Arr.Length > 0 Then
            '    For p_Count = 0 To p_Arr.Length - 1
            '        p_Row = p_Arr(p_Count)
            '        If p_Row.Item("ItemName").ToString.Trim <> "" Then
            '            p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
            '            If p_Object.Length > 0 Then
            '                If UCase(p_Object(0).name.ToString) = "TUNGAY" Then
            '                    '.Parameters.Item("Thang_Nam").Value = "Tháng  " & CDate(p_Object(0).editvalue).Month.ToString & "   năm  " & CDate(p_Object(0).editvalue).Year.ToString
            '                    .Parameters.Item("Thang_Nam").Value = "Tháng  " & CDate(p_Object(0).editvalue).ToString("MM") & "   năm  " & CDate(p_Object(0).editvalue).ToString("yyyy")
            '                End If
            '            End If
            '        End If
            '    Next
            'End If


            .Parameters.Item("NgayBaoCao").Value = "Ngày báo cáo: " & Now.Date.ToString("dd/MM/yyyy")

        End With
        p_Report.ShowPreviewDialog()


    End Sub

End Module
