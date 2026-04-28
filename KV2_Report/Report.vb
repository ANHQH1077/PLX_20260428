Imports DevExpress.XtraPrinting



Module Report


    Public Sub InLietKeBienBanGiaoNhan(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_Dataset As DataSet, ByVal p_ReportCode As String)

        Dim PhieuThanhToan As New rptLietKeBienBanGiaoNhan

        Dim SubPhieuThanhToan As New rptLietKeBienBanGiaoNhan3_1

        Dim p_TongSoLenh As Integer

        Dim p_Arr() As DataRow
        Dim labelDetail As DevExpress.XtraReports.UI.XRLabel
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object As Object
        Dim p_Top_Title As Integer = 113
        Dim p_SQL As String = ""
        Dim p_Datatable As DataTable

        Dim p_Title As String = ""

        ' p_SQL = "select * from fpt_tblLenhXuate5_v where NgayXuat>='20190801' and Status ='5'"
        '    p_Datatable = p_Dataset.Tables(0)

        p_Top_Title = PhieuThanhToan.Title.TopF + PhieuThanhToan.Title.HeightF



        p_SQL = "select * from SYS_CONFIG_RPT   where reportCode ='" & p_ReportCode & "'"
        p_Datatable = GetDataTable(p_SQL, p_SQL)


        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Title = p_Datatable.Rows(0).Item("ReportName").ToString.Trim
            End If
        End If
        If p_Title <> "" Then
            PhieuThanhToan.Title.Text = p_Title
        End If
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

                If StrParameter <> "" And Trim(StrParameter) <> Trim(p_Row.Item("ItemDesc").ToString.Trim & ": ") Then
                    labelDetail = New DevExpress.XtraReports.UI.XRLabel
                    'labelDetail.WidthF = .PageSize.Width - 30
                    labelDetail.WidthF = PhieuThanhToan.PageSize.Width - 100
                    labelDetail.LeftF = 15
                    labelDetail.Text = StrParameter
                    labelDetail.TopF = p_Top_Title
                    labelDetail.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular)
                    labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    labelDetail.HeightF = labelDetail.HeightF
                    labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                    p_Top_Title = p_Top_Title + labelDetail.HeightF
                    PhieuThanhToan.ReportHeader.Controls.Add(labelDetail)
                    ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                End If

                If UCase(p_Row.Item("ItemName").ToString.Trim) = UCase("Client") Then
                    'labelDetail.WidthF = .PageSize.Width - 30
                    Dim p_Text As String = ""
                    labelDetail = New DevExpress.XtraReports.UI.XRLabel
                    labelDetail.WidthF = PhieuThanhToan.PageSize.Width - 100
                    labelDetail.LeftF = 15
                    p_Text = "" ''StrParameter & " Tất cả"
                    If Not p_Object(0).editvalue Is Nothing Then
                        If p_Object(0).editvalue.ToString.Trim <> "" Then
                            p_Text = StrParameter & " " & p_Object(0).editvalue.ToString.Trim
                        End If
                    End If
                    If p_Text <> "" Then
                        Continue For
                    End If
                    labelDetail.Text = StrParameter & " Tất cả"
                    labelDetail.TopF = p_Top_Title
                    labelDetail.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular)
                    labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    labelDetail.HeightF = labelDetail.HeightF
                    labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                    p_Top_Title = p_Top_Title + labelDetail.HeightF
                    PhieuThanhToan.ReportHeader.Controls.Add(labelDetail)
                End If
            Next
        End If

        '' If p_Dataset.Tables.Count > 0 Then
        'PhieuThanhToan.DtLietKeBienBanGiaoNhan1.Tables(0).
        PhieuThanhToan.DataSource = p_Dataset
        PhieuThanhToan.DataMember = p_Dataset.Tables(0).TableName.ToString
        '  PhieuThanhToan.DetailReport.DataSource = p_Dataset.Tables(0)
        '  PhieuThanhToan.ShowPreview

        SubPhieuThanhToan.DataSource = p_Dataset.Tables(2)  ' p_Dataset
        SubPhieuThanhToan.DataMember = p_Dataset.Tables(2).TableName.ToString

        SubPhieuThanhToan.PrintDate.Text = "Ngày giờ in: " & CDate(p_Dataset.Tables(1).Rows(0).Item("PrintDate")).ToString("dd/MM/yyyy HH:mm:ss")
        Integer.TryParse(p_Dataset.Tables(1).Rows(0).Item("TongSoLenh").ToString.Trim, p_TongSoLenh)

        SubPhieuThanhToan.TongSoLenh.Text = p_TongSoLenh.ToString



        PhieuThanhToan.XrSubreport1.ReportSource = SubPhieuThanhToan
        ' ShowReportNew(PhieuThanhToan, False)
        ShowReport(PhieuThanhToan)
    End Sub


    Public Sub InBienBanGiaoNhan(ByVal p_SoLenh As String)
        Dim p_SQL As String = ""
        Dim p_DataSet As DataSet
        Dim p_Report As New RptBienBanGiaoNhan
        Dim p_ReportSub1 As New RptBienBanGiaoNhan_Sub1
        Dim p_ReportSub2 As New RptBienBanGiaoNhan_Sub22_1
        Dim p_ReportSub3 As New RptBienBanGiaoNhan_Sub3
        Dim p_Table0, p_Table1, p_Table2, p_Table3, p_Table4 As DataTable
        Dim p_Row As DataRow
        Dim p_Count As Integer
        Dim p_Value As Double
        ' Dim p_NHietDo As Decimal(10,2)
        Dim p_sValue As String = ""
        p_SQL = "exec dtBienBanGiaoNhan '" & p_SoLenh & "','" & g_UserName & "', '" & g_Terminal & "'"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            If p_DataSet.Tables.Count > 0 Then
                p_Table0 = p_DataSet.Tables(0)
                p_Table1 = p_DataSet.Tables(1)
                If Not p_Table1 Is Nothing Then
                    For p_Count = 0 To p_Table1.Rows.Count - 1
                        Double.TryParse(p_Table1.Rows(p_Count).Item("Ltt").ToString.Trim, p_Value)
                        If p_Value > 0 Then
                            p_sValue = Format(p_Value, "#,###,###,###").Replace(",", ".")
                            p_Table1.Rows(p_Count).Item("sLtt") = p_sValue
                        End If
                        Double.TryParse(p_Table1.Rows(p_Count).Item("L15").ToString.Trim, p_Value)
                        If p_Value > 0 Then
                            p_sValue = Format(p_Value, "#,###,###,###").Replace(",", ".")
                            p_Table1.Rows(p_Count).Item("sL15") = p_sValue
                        End If
                        Double.TryParse(p_Table1.Rows(p_Count).Item("KG").ToString.Trim, p_Value)
                        If p_Value > 0 Then
                            p_sValue = Format(p_Value, "#,###,###,###").Replace(",", ".")
                            p_Table1.Rows(p_Count).Item("sKG") = p_sValue
                        End If

                        p_sValue = p_Table1.Rows(p_Count).Item("D15_BQGQ").ToString.Trim
                        If p_sValue <> "" Then
                            p_sValue = p_sValue.Replace(".", ",")
                            p_Table1.Rows(p_Count).Item("sD15_BQGQ") = p_sValue
                        End If
                        p_sValue = p_Table1.Rows(p_Count).Item("VCF").ToString.Trim
                        If p_sValue <> "" Then
                            p_sValue = p_sValue.Replace(".", ",")
                            p_Table1.Rows(p_Count).Item("sVCF") = p_sValue
                        End If
                        p_sValue = p_Table1.Rows(p_Count).Item("WCF").ToString.Trim
                        If p_sValue <> "" Then
                            p_sValue = p_sValue.Replace(".", ",")
                            p_Table1.Rows(p_Count).Item("sWCF") = p_sValue
                        End If
                        Double.TryParse(p_Table1.Rows(p_Count).Item("NhietDo_BQGQ").ToString, p_Value)
                        If p_Value > 0 Then
                            'p_Value = Math.Round(p_Table1.Rows(p_Count).Item("NhietDo_BQGQ"), 2)
                            p_sValue = Math.Round(p_Table1.Rows(p_Count).Item("NhietDo_BQGQ"), 2).ToString.Trim
                            If p_sValue <> "" Then
                                p_sValue = p_sValue.Replace(".", ",")
                                p_Table1.Rows(p_Count).Item("sNhietDo_BQGQ") = p_sValue
                            End If
                        End If
                    Next
                End If
                p_Table2 = p_DataSet.Tables(2)

                p_Table3 = p_DataSet.Tables(3)
                p_Table4 = p_DataSet.Tables(4)
                If Not p_Table2 Is Nothing Then
                    For p_Count = 0 To p_Table2.Rows.Count - 1
                        'p_sValue = p_Table2.Rows(p_Count).Item("DungTich").ToString.Trim
                        'If p_sValue <> "" Then
                        '    p_sValue = p_sValue.Replace(".", ",")
                        '    p_Table2.Rows(p_Count).Item("sDungTich") = p_sValue
                        'End If

                        Double.TryParse(p_Table2.Rows(p_Count).Item("DungTich").ToString.Trim, p_Value)
                        If p_Value > 0 Then
                            p_sValue = Format(p_Value, "#,###,###,###").Replace(",", ".")
                            p_Table2.Rows(p_Count).Item("sDungTich") = p_sValue
                        End If

                    Next
                End If

                If Not p_Table3 Is Nothing Then
                    For p_Count = 0 To p_Table3.Rows.Count - 1
                        Double.TryParse(p_Table3.Rows(p_Count).Item("Ltt").ToString.Trim, p_Value)
                        If p_Value > 0 Then
                            p_sValue = Format(p_Value, "#,###,###,###").Replace(",", ".")
                            p_Table3.Rows(p_Count).Item("sLtt") = p_sValue
                        End If
                    Next
                End If


                If Not p_Table4 Is Nothing Then
                    If p_Table4.Rows.Count > 0 Then
                        If p_Table4.Rows(0).Item(0) <> 0 Then
                            ShowMessageBox("", p_Table4.Rows(0).Item(1).ToString.Trim)
                            Exit Sub

                        End If
                    End If
                End If
                If p_Table0.Rows.Count > 0 Then
                    p_Report.txtSoBienBan.Text = p_Table0.Rows(0).Item("SoBienBan").ToString.Trim
                    p_Report.SoBienBan.Text = p_Table0.Rows(0).Item("SoBienBanMau").ToString.Trim
                    If p_Table0.Rows(0).Item("SoBienBanMau").ToString.Trim <> "" Then
                        p_Report.XrCheckBox2.Checked = True
                    Else
                        p_Report.XrCheckBox1.Checked = True
                    End If
                    p_Report.txtTimePrint.Text = CDate(p_Table0.Rows(0).Item("TimePrint")).ToString("dd-MM-yyyy HH:mm:ss")

                    p_Report.txtKhoXuat.Text = p_Table0.Rows(0).Item("TenDonVi").ToString.Trim
                    p_Report.txtAddress.Text = p_Table0.Rows(0).Item("DiaChiFull").ToString.Trim
                    p_Report.SoTKTX.Text = p_Table0.Rows(0).Item("So_TKTX").ToString.Trim

                    If p_Table0.Rows(0).Item("So_TKTX").ToString.Trim = "" Then
                        p_Report.XrLabel5.Visible = False
                    End If
                    'So_TKTX
                End If
                'For p_Count = p_Table1.Rows.Count + 1 To 5
                '    p_Row = p_Table1.NewRow

                '    p_Table1.Rows.Add(p_Row)
                'Next

                'For p_Count = p_Table2.Rows.Count + 1 To 8
                '    p_Row = p_Table2.NewRow

                '    p_Table2.Rows.Add(p_Row)
                'Next




                p_Report.DataSource = p_Table0
                p_ReportSub1.DataSource = p_Table1
                ' p_ReportSub1.DataMember = p_Table1.TableName

                p_ReportSub2.DataSource = p_Table2
                p_ReportSub2.DataMember = p_Table2.TableName


                p_ReportSub3.DataSource = p_Table3
                'p_ReportSub3.DataMember = p_Table3.TableName

                p_Report.XrSubreport1.ReportSource = p_ReportSub1
                p_Report.XrSubreport2.ReportSource = p_ReportSub2
                p_Report.XrSubreport3.ReportSource = p_ReportSub3

                'p_ReportSub2.XrLabel15.AutoWidth = True
                '   p_ReportSub2.XrLabel15.WordWrap = False
                '  p_ReportSub2.XrLabel15.ProcessDuplicates = 2
                ' p_ReportSub2.XrLabel15.ProcessNullValues = 2

                'Dim printTool As New DevExpress.XtraReports.UI.ReportPrintTool(p_Report)
                'printTool()
                'printTool.PrintingSystem.PageSettings.
                'p_Report.c()
                ' p_Report.ShowPreviewDialog()
                'printTool.ShowPreviewDialog()
                '' dfgdgdgdgd

                'ShowReportNew(p_Report, False)

                '  p_Report.ShowPreviewDialog

                ShowReport(p_Report)
            End If


        End If
    End Sub
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
            p_Top_Title = p_Report.XrLabel22.TopF + p_Report.XrLabel22.HeightF  '
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

        'p_Report.ExportOptions.PrintPreview.ShowOptionsBeforeExport = False
        'p_Report.ShowPreviewDialog()
        ShowReport(p_Report)

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
            p_Top_Title = p_Report.XrLabel22.TopF + p_Report.XrLabel22.HeightF  '
            'Lay ra cac tham so co the treo len bao cao
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select(String.Format("ReportCode='{0}' and ShowReport='Y'", p_ReportCode), "STT")
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

        'p_Report.ExportOptions.PrintPreview.ShowOptionsBeforeExport = False
        'p_Report.ShowPreviewDialog()

        ShowReport(p_Report)
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
            p_Top_Title = p_Report.XrLabel22.TopF + p_Report.XrLabel22.HeightF  '
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

        'p_Report.ExportOptions.PrintPreview.ShowOptionsBeforeExport = False
        'p_Report.ShowPreviewDialog()

        ShowReport(p_Report)
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
            p_Top_Title = p_Report.XrLabel22.TopF + p_Report.XrLabel22.HeightF  '
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

        'p_Report.ExportOptions.PrintPreview.ShowOptionsBeforeExport = False
        'p_Report.ShowPreviewDialog()
        ShowReport(p_Report)

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
                        'labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular)
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

        'p_Report.ExportOptions.PrintPreview.ShowOptionsBeforeExport = False

        'p_Report.ShowPreviewDialog()

        ShowReport(p_Report)
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

            ' p_Top_Title = 110
            p_Top_Title = p_Report.XrLabel22.TopF + p_Report.XrLabel22.HeightF  '
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
                        labelDetail.WidthF = .XrLabel22.WidthF  ' .PageSize.Width ' - 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        'labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        ' labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
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

        'p_Report.ExportOptions.PrintPreview.ShowOptionsBeforeExport = False

        'p_Report.ShowPreviewDialog()

        ShowReport(p_Report)
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
            p_Top_Title = p_Report.XrLabel22.TopF + p_Report.XrLabel22.HeightF  '
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

        'p_Report.ExportOptions.PrintPreview.ShowOptionsBeforeExport = False
        'p_Report.ShowPreviewDialog()

        ShowReport(p_Report)
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
            p_Top_Title = p_Report.XrLabel22.TopF + p_Report.XrLabel22.HeightF  '
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

        'p_Report.ExportOptions.PrintPreview.ShowOptionsBeforeExport = False
        'p_Report.ShowPreviewDialog()

        ShowReport(p_Report)
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
            p_Top_Title = p_Report.XrLabel22.TopF + p_Report.XrLabel22.HeightF  '   110
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
                        labelDetail.WidthF = .PageSize.Width '300
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None
                        labelDetail.Visible = True
                        labelDetail.LocationF = New PointF(10.0F, 114.58F)

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

        'p_Report.ExportOptions.PrintPreview.ShowOptionsBeforeExport = False

        'p_Report.ShowPreviewDialog()

        ShowReport(p_Report)
    End Sub



    Public Sub mdlRptBM_05_04_01_HH(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_Dataset As DataSet, ByVal p_ReportCode As String)
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
        Dim p_Report As New rptBM_05_04_01_HH

        Dim p_ReportSub1 As New rpt_BM_05_04_01_HH1
        Dim p_ReportSub2 As New rpt_BM_05_04_01_HH2

        Dim p_Row As DataRow
        Dim p_Row02 As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object

        Dim p_Object02() As Object

        Dim vcf As String = String.Empty
        Dim slQC As String = String.Empty


        p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
        If p_Arr.Length > 0 Then
            'For p_Count = 0 To p_Arr.Length - 1
            If p_Arr.Length = 2 Then


                p_Row = p_Arr(0)
                p_Row02 = p_Arr(1)
                StrParameter = ""
                If p_Row.Item("ItemName").ToString.Trim <> "" Then
                    p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                    p_Object02 = p_Form.Controls.Find(p_Row02.Item("ItemName").ToString.Trim, True)
                    If p_Object.Length > 0 Then

                        StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
                        If Not p_Object(0).editvalue Is Nothing Then
                            If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy") & " " & CDate(p_Object02(0).editvalue).ToString("HH:mm:ss")
                            Else
                                StrParameter = StrParameter & " " & p_Object(0).editvalue
                            End If
                        End If

                    End If
                    If p_Row.Item("ToItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
                        p_Object02 = p_Form.Controls.Find(p_Row02.Item("ToItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
                            If Not p_Object(0).editvalue Is Nothing Then
                                If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
                                    StrParameter = StrParameter & "         Đến ngày:   " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy") & " " & CDate(p_Object02(0).editvalue).ToString("HH:mm:ss")
                                Else
                                    StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
                                End If

                            End If
                        End If
                    End If


                End If
            Else
                p_Row = p_Arr(0)

                StrParameter = ""
                If p_Row.Item("ItemName").ToString.Trim <> "" Then
                    p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                    p_Object02 = p_Form.Controls.Find(p_Row02.Item("ItemName").ToString.Trim, True)
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
            End If
            p_Report.XrLabel2.Text = StrParameter
            'If StrParameter <> "" And Trim(StrParameter) <> Trim(p_Row.Item("ItemDesc").ToString.Trim & ": ") Then
            '    labelDetail = New DevExpress.XtraReports.UI.XRLabel
            '    'labelDetail.WidthF = .PageSize.Width - 30
            '    labelDetail.WidthF = PhieuThanhToan.PageSize.Width - 100
            '    labelDetail.LeftF = 15
            '    labelDetail.Text = StrParameter
            '    labelDetail.TopF = p_Top_Title
            '    labelDetail.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular)
            '    labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '    labelDetail.HeightF = labelDetail.HeightF
            '    labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

            '    p_Top_Title = p_Top_Title + labelDetail.HeightF
            '    PhieuThanhToan.ReportHeader.Controls.Add(labelDetail)
            '    ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
            'End If


            'Next
        End If


        p_ReportSub1.DataSource = p_Dataset.Tables(0)
        p_ReportSub2.DataSource = p_Dataset.Tables(1)
        p_Report.XrSubreportHH1.ReportSource = p_ReportSub1
        p_Report.XrSubreporHH2.ReportSource = p_ReportSub2

        ShowReport(p_Report)

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
            ' p_Top_Title = 110
            p_Top_Title = p_Report.XrLabel22.TopF + p_Report.XrLabel22.HeightF  '
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
                        labelDetail.WidthF = .XrLabel22.WidthF  ' .PageSize.Width
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        ' labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
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

            '  .XrLabel1.
        End With


        'Dim ps As PrintingSystemBase = p_Report.PrintingSystem

        ''   Hide the Watermark toolbar button, and also the Watermark menu item.
        '' If ps.GetCommandVisibility(PrintingSystemCommand.ExportCsv) <> CommandVisibility.None Then
        'ps.SetCommandVisibility(PrintingSystemCommand.ExportCsv, CommandVisibility.None)
        'ps.SetCommandVisibility(PrintingSystemCommand.ExportFile, CommandVisibility.None)
        'ps.SetCommandVisibility(PrintingSystemCommand.ExportGraphic, CommandVisibility.None)
        'ps.SetCommandVisibility(PrintingSystemCommand.ExportHtm, CommandVisibility.None)
        'ps.SetCommandVisibility(PrintingSystemCommand.ExportPdf, CommandVisibility.None)
        'ps.SetCommandVisibility(PrintingSystemCommand.ExportTxt, CommandVisibility.None)



        'ps.SetCommandVisibility(PrintingSystemCommand.ExportXls, CommandVisibility.None)
        'ps.SetCommandVisibility(PrintingSystemCommand.ExportXlsx, CommandVisibility.None)
        'ps.SetCommandVisibility(PrintingSystemCommand.ExportXps, CommandVisibility.None)

        ' End If

        'p_Report.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportPdf, CommandVisibility.None)
        'p_Report.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportFile, CommandVisibility.None)
        'p_Report.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportTxt, CommandVisibility.None)
        'p_Report.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportXlsx, CommandVisibility.None)

        ''p_Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = "" 'System.IO.Path.GetTempPath()
        'p_Report.PrintingSystem.ExportOptions.PrintPreview.ShowOptionsBeforeExport = False
        ''p_Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = Sav
        'p_Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = ActionAfterExport.None



        'Dim ps As PrintingSystemBase = p_Report.PrintingSystem

        '' Hide the Watermark toolbar button and menu item.
        'If ps.GetCommandVisibility(PrintingSystemCommand.Watermark) <> CommandVisibility.None Then
        '    ps.SetCommandVisibility(PrintingSystemCommand.Watermark, CommandVisibility.None)
        'End If

        '' Show the Document Map toolbar button and menu item.
        'ps.SetCommandVisibility(PrintingSystemCommand.DocumentMap, CommandVisibility.None)

        '' Show the "Export to Csv" and "Export to Txt" commands.
        'ps.SetCommandVisibility(New PrintingSystemCommand() {PrintingSystemCommand.ExportPdf, _
        '    PrintingSystemCommand.ExportTxt}, CommandVisibility.Toolbar)



        'p_Report.PrintingSystem.ExportOptions.PrintPreview.DefaultExportFormat.ExportPd= PrintingSystemCommand.ClosePreview
        'p_Report.PrintingSystem.ExportOptions.Pdf.NeverEmbeddedFonts = PrintingSystemCommand.ClosePreview
        'p_Report.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportPdf, CommandVisibility.None)


        'p_Report.s()
        '  p_Report.e()

        '   p_Report.Report.

        '   p_Report.PrintingSystem.ExportDefault = PrintingSystemCommand.None
        'p_Report.ExportOptions.Pdf = False
        ' p_Report.ShowPreview()
        'p_Report.ShowPreviewDialog()

        ' Dim report As New XtraReport1()
        'Dim printTool As New DevExpress.XtraReports.UI.ReportPrintTool(p_Report)

        '' Show the report's preview for the first time.
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportPdf, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportPdf, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportCsv, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportFile, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportGraphic, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportHtm, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportPdf, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportTxt, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportXls, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportXlsx, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportXps, CommandVisibility.None)

        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendPdf, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendPdf, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendCsv, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendFile, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendGraphic, CommandVisibility.None)
        ''printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Sendh, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendPdf, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendTxt, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendXls, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendXlsx, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendXps, CommandVisibility.None)

        'printTool.ShowPreviewDialog()

        ' Change the report's contents.
        '   CType(printTool.Report, p_Report).xrLabel1.BackColor = Color.Blue

        ' Create the report's document.
        ' printTool.Report.CreateDocument()

        ' Show the report's preview for the second time.
        'printTool.ShowPreviewDialog()


        'p_Report.ExportOptions.PrintPreview.ShowOptionsBeforeExport = False

        ShowReport(p_Report)

    End Sub

    Public Sub mdlRptBM_01_14(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
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
        Dim p_Report As New rptSoDoBe
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable
        Dim vcf As String = String.Empty
        Dim slQC As String = String.Empty




        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)

        'If Not p_TableCompany Is Nothing Then
        '    If p_TableCompany.Rows.Count > 0 Then
        '        p_SQL = "SELECT [TenKho]  FROM   [tblKho] where  [MaKho]='" & p_TableCompany.Rows(0).Item("warehouse").ToString.Trim & "'; "
        '        p_SQL = p_SQL & "select * from tblDonvi where MaDonVi ='" & p_TableCompany.Rows(0).Item("CompanyCode").ToString.Trim & "'; "
        '        p_DataSetCompany = GetDataSet(p_SQL, p_SQL)
        '        If Not p_DataSetCompany Is Nothing Then
        '            If p_DataSetCompany.Tables(0).Rows.Count > 0 Then
        '                p_CompanyName = UCase(p_DataSetCompany.Tables(0).Rows(0).Item("TenKho").ToString.Trim)
        '            End If

        '            If p_DataSetCompany.Tables(1).Rows.Count > 0 Then
        '                p_ParentCompanyName = UCase(p_DataSetCompany.Tables(1).Rows(0).Item("TenDonVi").ToString.Trim)
        '            End If

        '        End If
        '    End If

        'End If

        'p_Arr = g_SYS_CONFIG_RPT.Select("ReportCode='" & p_ReportCode & "'")
        'If p_Arr.Length > 0 Then
        '    If p_Arr(0).Item("ShowCompany").ToString.Trim = "Y" Then
        '        p_ShowCompany = True
        '    End If
        '    If p_Arr(0).Item("ShowParentCompany").ToString.Trim = "Y" Then
        '        p_ShowParent = True
        '    End If
        '    p_Title = p_Arr(0).Item("ReportName").ToString.Trim
        'End If

        p_Report.DataSource = p_datatable

        'p_SQL = "select * from SYS_CONFIG_RPT_FOOTER where ReportCode='" & p_ReportCode & "' ORDER BY  ISNULL(RowNum,0)"
        'p_DataTable1 = GetDataTable(p_SQL, p_SQL)

        'With p_Report

        'p_Top_Title = 110
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
                p_Report.XrLabel2.Text = StrParameter
                'If StrParameter <> "" Then
                '    labelDetail = New DevExpress.XtraReports.UI.XRLabel
                '    'labelDetail.WidthF = .PageSize.Width - 30
                '    labelDetail.WidthF = .PageSize.Width - 100
                '    labelDetail.LeftF = 15
                '    labelDetail.Text = StrParameter
                '    labelDetail.TopF = p_Top_Title
                '    labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                '    labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                '    labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                '    labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None

                '    p_Top_Title = p_Top_Title + labelDetail.HeightF
                '    .ReportHeader.Controls.Add(labelDetail)
                '    ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                'End If
            Next
        End If

        '    p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ItemName='Client'", "STT")
        '    If p_Arr.Length > 0 Then
        '        For p_Count = 0 To p_Arr.Length - 1
        '            p_Row = p_Arr(p_Count)
        '            If p_Row.Item("ItemName").ToString.Trim <> "" Then
        '                p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
        '                If p_Object.Length > 0 Then
        '                    If UCase(p_Object(0).name.ToString) = "CLIENT" Then
        '                        If Not p_Object(0).editvalue Is Nothing Then
        '                            .Parameters.Item("DoiGiaoNhan").Value = UCase(p_Object(0).editvalue.ToString)
        '                        End If
        '                    End If
        '                End If
        '            End If
        '        Next
        '    End If
        '    .Parameters.Item("DoiGiaoNhan").Visible = False
        'End With
        StrParameter = ""
        p_SQL = "select getdate() as dDate "
        p_TableCompany = GetDataTable(p_SQL, p_SQL)
        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                StrParameter = CDate(p_TableCompany.Rows(0).Item(0)).ToString("dd.MM.yyyy hh:mm:ss tt")
            End If
        End If
        p_Report.XrLabel33.Text = "Ngày giờ in: " & StrParameter

        ShowReport(p_Report)

    End Sub

    Public Sub mdlRptBM_00_01(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
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
        Dim p_Report As New rptTonKhoBe
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable
        Dim vcf As String = String.Empty
        Dim slQC As String = String.Empty




        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)



        p_Report.DataSource = p_datatable

        'p_Top_Title = 110
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
                p_Report.XrLabel2.Text = StrParameter

            Next
        End If


        StrParameter = ""
        p_SQL = "select getdate() as dDate "
        p_TableCompany = GetDataTable(p_SQL, p_SQL)
        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                ' StrParameter = CDate(p_TableCompany.Rows(0).Item(0)).ToString("dd.MM.yyyy HH:mm:ss ")
                StrParameter = "Ngày " & CDate(p_TableCompany.Rows(0).Item(0)).ToString("dd") & " tháng " & CDate(p_TableCompany.Rows(0).Item(0)).ToString("MM") & _
                                " năm " & CDate(p_TableCompany.Rows(0).Item(0)).ToString("yyyy") ' CDate(p_TableCompany.Rows(0).Item(0)).ToString("dd.MM.yyyy HH:mm:ss ")
            End If
        End If
        '  p_Report.XrLabel33.Text = "Ngày giờ in: " & StrParameter
        p_Report.XrLabel37.Text = StrParameter
        ShowReport(p_Report)

    End Sub

    Public Sub mdlRptBM_01_14_BienBan(ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
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
        Dim p_Report As New rptBienBanDoBe_ALL
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable
        Dim vcf As String = String.Empty
        Dim slQC As String = String.Empty




        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)



        p_Report.DataSource = p_datatable

        ''p_Top_Title = 110
        ''Lay ra cac tham so co the treo len bao cao
        'p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
        'If p_Arr.Length > 0 Then
        '    For p_Count = 0 To p_Arr.Length - 1
        '        p_Row = p_Arr(p_Count)
        '        StrParameter = ""
        '        If p_Row.Item("ItemName").ToString.Trim <> "" Then
        '            p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
        '            If p_Object.Length > 0 Then

        '                StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
        '                If Not p_Object(0).editvalue Is Nothing Then
        '                    If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
        '                        StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
        '                    Else
        '                        StrParameter = StrParameter & " " & p_Object(0).editvalue
        '                    End If
        '                End If

        '            End If
        '            If p_Row.Item("ToItemName").ToString.Trim <> "" Then
        '                p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
        '                If p_Object.Length > 0 Then
        '                    'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
        '                    If Not p_Object(0).editvalue Is Nothing Then
        '                        If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
        '                            StrParameter = StrParameter & "         Đến ngày:   " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
        '                        Else
        '                            StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
        '                        End If

        '                    End If
        '                End If
        '            End If


        '        End If
        '        p_Report.XrLabel31.Text = StrParameter

        '    Next
        'End If


        StrParameter = ""
        p_SQL = "select getdate() as dDate "
        p_TableCompany = GetDataTable(p_SQL, p_SQL)
        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                StrParameter = CDate(p_TableCompany.Rows(0).Item(0)).ToString("dd.MM.yyyy HH:mm:ss ")
                'StrParameter = "Ngày " & CDate(p_TableCompany.Rows(0).Item(0)).ToString("dd") & " tháng " & CDate(p_TableCompany.Rows(0).Item(0)).ToString("MM") & _
                '                " năm " & CDate(p_TableCompany.Rows(0).Item(0)).ToString("yyyy") ' CDate(p_TableCompany.Rows(0).Item(0)).ToString("dd.MM.yyyy HH:mm:ss ")
            End If
        End If
        p_Report.XrLabel30.Text = "Ngày giờ in: " & StrParameter
        'p_Report.XrLabel37.Text = StrParameter
        ShowReport(p_Report)

    End Sub

    Public Sub mdlRptBM_01_14_BienBan_BK(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
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
        Dim p_Report As New rptBienBanDoBe_ALL
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        'Dim dtTable As DataTable = p_datatable
        Dim vcf As String = String.Empty
        Dim slQC As String = String.Empty




        p_TableCompany = GetDataTable("select * from tblConfig", p_SQL)



        p_Report.DataSource = p_datatable

        'p_Top_Title = 110
        'Lay ra cac tham so co the treo len bao cao
        'p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ShowReport='Y'", "STT")
        'If p_Arr.Length > 0 Then
        '    For p_Count = 0 To p_Arr.Length - 1
        '        p_Row = p_Arr(p_Count)
        '        StrParameter = ""
        '        If p_Row.Item("ItemName").ToString.Trim <> "" Then
        '            p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
        '            If p_Object.Length > 0 Then

        '                StrParameter = StrParameter & " " & p_Row.Item("ItemDesc").ToString.Trim & ": "
        '                If Not p_Object(0).editvalue Is Nothing Then
        '                    If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
        '                        StrParameter = StrParameter & " " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
        '                    Else
        '                        StrParameter = StrParameter & " " & p_Object(0).editvalue
        '                    End If
        '                End If

        '            End If
        '            If p_Row.Item("ToItemName").ToString.Trim <> "" Then
        '                p_Object = p_Form.Controls.Find(p_Row.Item("ToItemName").ToString.Trim, True)
        '                If p_Object.Length > 0 Then
        '                    'StrParameter = StrParameter & " đến " & p_Object(0).editvalue
        '                    If Not p_Object(0).editvalue Is Nothing Then
        '                        If UCase(p_Object(0).GetType.Name.ToString.Trim) = UCase("U_DateEdit") Then
        '                            StrParameter = StrParameter & "         Đến ngày:   " & CDate(p_Object(0).editvalue).ToString("dd/MM/yyyy")
        '                        Else
        '                            StrParameter = StrParameter & "   đến   " & p_Object(0).editvalue
        '                        End If

        '                    End If
        '                End If
        '            End If


        '        End If
        '        p_Report.XrLabel31.Text = StrParameter

        '    Next
        'End If


        StrParameter = ""
        p_SQL = "select getdate() as dDate "
        p_TableCompany = GetDataTable(p_SQL, p_SQL)
        If Not p_TableCompany Is Nothing Then
            If p_TableCompany.Rows.Count > 0 Then
                StrParameter = CDate(p_TableCompany.Rows(0).Item(0)).ToString("dd.MM.yyyy HH:mm:ss ")
                'StrParameter = "Ngày " & CDate(p_TableCompany.Rows(0).Item(0)).ToString("dd") & " tháng " & CDate(p_TableCompany.Rows(0).Item(0)).ToString("MM") & _
                '                " năm " & CDate(p_TableCompany.Rows(0).Item(0)).ToString("yyyy") ' CDate(p_TableCompany.Rows(0).Item(0)).ToString("dd.MM.yyyy HH:mm:ss ")
            End If
        End If
        p_Report.XrLabel30.Text = "Ngày giờ in: " & StrParameter
        'p_Report.XrLabel37.Text = StrParameter
        ShowReport(p_Report)

    End Sub


    Public Sub mdlRptBM_06_01(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
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
        Dim p_Report As New RptBM_06_01
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable
        Dim vcf As String = String.Empty
        Dim slQC As String = String.Empty




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

            p_Top_Title = p_Report.XrLabel14.TopF + p_Report.XrLabel14.HeightF  '
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
                        labelDetail.WidthF = .PageSize.Width '- 100
                        labelDetail.LeftF = 15
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        labelDetail.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular)
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
            .XrLabel22.Text = p_Title
        End With


        ShowReport(p_Report)

    End Sub



    Public Sub mdlRptBM_06_02(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
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
        Dim p_Report As New RptBM_06_02
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable
        Dim vcf As String = String.Empty
        Dim slQC As String = String.Empty




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

            'p_Top_Title = 110
            p_Top_Title = p_Report.XrLabel22.TopF + p_Report.XrLabel22.HeightF  '
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
                        labelDetail.WidthF = .XrLabel22.Width  '- 100
                        labelDetail.LeftF = .XrLabel22.LeftF  '100
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        'labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        'labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None
                        labelDetail.Visible = True
                        'labelDetail.LocationF = New PointF(100.0F, 120.0F)

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If

            .XrLabel22.Text = UCase(p_Title)
        End With


        ShowReport(p_Report)

    End Sub



    Public Sub mdlRptBM_06_031(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
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
        Dim p_Report As New RptBM_06_03
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable
        Dim vcf As String = String.Empty
        Dim slQC As String = String.Empty




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

            p_Top_Title = p_Report.XrLabel22.TopF + p_Report.XrLabel22.HeightF  '
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
                        labelDetail.LeftF = 100
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

            .XrLabel22.Text = p_Title
        End With


        ShowReport(p_Report)

    End Sub


    Public Sub mdlRptBM_06_03(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
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
        Dim p_Report As New RptBM_06_03
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable
        Dim vcf As String = String.Empty
        Dim slQC As String = String.Empty




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

            'p_Top_Title = 110
            p_Top_Title = p_Report.XrLabel22.TopF + p_Report.XrLabel22.HeightF  '
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
                        labelDetail.WidthF = .XrLabel22.Width '- 100
                        labelDetail.LeftF = .XrLabel22.LeftF
                        labelDetail.Text = StrParameter
                        labelDetail.TopF = p_Top_Title
                        'labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular)
                        labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)

                        labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None
                        labelDetail.Visible = True
                        'labelDetail.LocationF = New PointF(100.0F, 120.0F)

                        p_Top_Title = p_Top_Title + labelDetail.HeightF
                        .ReportHeader.Controls.Add(labelDetail)
                        ' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                    End If
                Next
            End If

            .XrLabel22.Text = UCase(p_Title)
        End With


        ShowReport(p_Report)

    End Sub



    Public Sub mdlRptBM_05_04_01(ByVal p_Form As U_CusForm.XtraCusForm1, ByVal p_datatable As DataTable, ByVal p_ReportCode As String)
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
        Dim p_Report As New RptBM_05_04_01_01
        Dim p_Row As DataRow
        Dim StrParameter As String = ""
        Dim p_Object() As Object
        Dim dtTable As DataTable = p_datatable
        Dim vcf As String = String.Empty
        Dim slQC As String = String.Empty




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
            .Parameters.Item("CONGTY").Value = p_ParentCompanyName
            .Parameters.Item("KHOXUAT").Value = p_CompanyName

            .Parameters.Item("OrderNo").Description = "Order No"
            .Parameters.Item("TuyenDuong").Description = "Tuyến đường"
            .Parameters.Item("SoToKhai").Description = "Số tờ khai"
            '.Parameters.Item("OrderNo").Value = "123"
            '.Parameters.Item("TuyenDuong").Value = "anhqh"
            '.Parameters.Item("SoToKhai").Value = "anhqh123"

            .Parameters.Item("CONGTY").Visible = False
            .Parameters.Item("KHOXUAT").Visible = False
            '.Parameters.Item("OrderNo").Visible = False
            '.Parameters.Item("TuyenDuong").Visible = False
            '.Parameters.Item("SoToKhai").Visible = False

        End With



        ShowReport(p_Report)

    End Sub

    Private Sub ShowReport(ByRef p_Report As Object)
        Dim printTool As New DevExpress.XtraReports.UI.ReportPrintTool(p_Report)
        Dim p_SQL As String = ""
        Dim p_Rs As DataTable

        'p_data
        ' g_UserName 
        ' Show the report's preview for the first time.
        If g_ExcelRepot = False Then


            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportPdf, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportPdf, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportCsv, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportFile, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportGraphic, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportHtm, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportPdf, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportTxt, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportXls, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportXlsx, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportXps, CommandVisibility.None)

            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendPdf, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendPdf, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendCsv, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendFile, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendGraphic, CommandVisibility.None)
            'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Sendh, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendPdf, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendTxt, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendXls, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendXlsx, CommandVisibility.None)
            printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendXps, CommandVisibility.None)
        End If
        '  printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand., CommandVisibility.None)
        printTool.ShowPreviewDialog()
    End Sub



    Private Sub ShowReport22(ByRef p_Report As Object)
        Dim printTool As New DevExpress.XtraReports.UI.ReportPrintTool(p_Report)

        ' Show the report's preview for the first time.
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportPdf, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportPdf, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportCsv, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportFile, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportGraphic, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportHtm, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportPdf, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportTxt, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportXls, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportXlsx, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ExportXps, CommandVisibility.None)

        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendPdf, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendPdf, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendCsv, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendFile, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendGraphic, CommandVisibility.None)
        'printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.Sendh, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendPdf, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendTxt, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendXls, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendXlsx, CommandVisibility.None)
        printTool.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.SendXps, CommandVisibility.None)

        printTool.ShowPreviewDialog()
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
                        'labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        ''labelDetail.WidthF = .PageSize.Width - 30
                        'labelDetail.WidthF = .PageSize.Width - 100
                        'labelDetail.LeftF = 15
                        'labelDetail.Text = StrParameter
                        'labelDetail.TopF = p_Top_Title
                        ''labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        'labelDetail.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular)
                        'labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        'labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None


                        'p_Top_Title = p_Top_Title + labelDetail.HeightF
                        '.ReportHeader.Controls.Add(labelDetail)
                        '' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF


                        '' p_Report.XrLabel53.Text = StrParameter

                        .XrLabel4.Text = StrParameter
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

            '20250103====Bổ sung
            p_SQL = ""
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ItemName='TankGroup'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            'If UCase(p_Object(0).name.ToString) = "CLIENT" Then
                            If Not p_Object(0).editvalue Is Nothing Then
                                ' .Parameters.Item("XrLabel5").Value = UCase(p_Object(0).editvalue.ToString)
                                p_SQL = p_Object(0).editvalue.ToString
                            End If
                            If p_SQL <> "" Then
                                If p_SQL = "TD" Then
                                    p_SQL = "Nhóm bể: Tập đoàn"
                                Else
                                    p_SQL = "Nhóm bể: khách hàng"
                                End If
                            Else
                                p_SQL = "Nhóm bể: All"
                            End If
                            'End If
                            .XrLabel5.Text = p_SQL
                        End If
                    End If
                Next
            End If


            .Parameters.Item("DoiGiaoNhan").Visible = False
        End With

        'p_Report.ExportOptions.PrintPreview.ShowOptionsBeforeExport = False

        'p_Report.ShowPreviewDialog()
        'p_Report.Detail1.Visible = True
        ShowReport(p_Report)
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
            p_Top_Title = p_Report.XrLabel22.TopF + p_Report.XrLabel22.HeightF  '
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
                        'labelDetail = New DevExpress.XtraReports.UI.XRLabel
                        ''labelDetail.WidthF = .PageSize.Width - 30
                        'labelDetail.WidthF = .PageSize.Width - 100
                        'labelDetail.LeftF = 15
                        'labelDetail.Text = StrParameter
                        'labelDetail.TopF = p_Top_Title
                        'labelDetail.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular)
                        'labelDetail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        'labelDetail.HeightF = labelDetail.HeightF + (labelDetail.HeightF * 0.5)
                        'labelDetail.Borders = DevExpress.XtraPrinting.BorderSide.None
                        'labelDetail.Visible = True
                        'labelDetail.LocationF = New PointF(13.0F, 114.58F)

                        'p_Top_Title = p_Top_Title + labelDetail.HeightF
                        '.ReportHeader.Controls.Add(labelDetail)
                        '' .ReportHeader1.HeightF = .ReportHeader1.HeightF + labelDetail.HeightF
                        .XrLabel4.Text = StrParameter
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
            p_SQL = ""
            p_Arr = g_SYS_CONFIG_RPT_PARA.Select("ReportCode='" & p_ReportCode & "' and ItemName='TankGroup'", "STT")
            If p_Arr.Length > 0 Then
                For p_Count = 0 To p_Arr.Length - 1
                    p_Row = p_Arr(p_Count)
                    If p_Row.Item("ItemName").ToString.Trim <> "" Then
                        p_Object = p_Form.Controls.Find(p_Row.Item("ItemName").ToString.Trim, True)
                        If p_Object.Length > 0 Then
                            'If UCase(p_Object(0).name.ToString) = "CLIENT" Then
                            If Not p_Object(0).editvalue Is Nothing Then
                                ' .Parameters.Item("XrLabel5").Value = UCase(p_Object(0).editvalue.ToString)
                                p_SQL = p_Object(0).editvalue.ToString
                            End If
                            If p_SQL <> "" Then
                                If p_SQL = "TD" Then
                                    p_SQL = "Nhóm bể: Tập đoàn"
                                Else
                                    p_SQL = "Nhóm bể: khách hàng"
                                End If
                            Else
                                p_SQL = "Nhóm bể: All"
                            End If
                            'End If
                            .XrLabel3.Text = p_SQL
                        End If
                    End If
                Next
            End If

            .Parameters.Item("DoiGiaoNhan").Visible = False
        End With

        'p_Report.ExportOptions.PrintPreview.ShowOptionsBeforeExport = False
        'p_Report.ShowPreviewDialog()

        ShowReport(p_Report)
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
            'p_Top_Title = 110
            p_Top_Title = p_Report.XrLabel22.TopF + p_Report.XrLabel22.HeightF  '
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
                        'labelDetail.Font = New Font("Tahoma", 9.0F, FontStyle.Regular)
                        labelDetail.Font = New Font("Times New Roman", 9.75F, FontStyle.Regular)
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
        'p_Report.ExportOptions.PrintPreview.ShowOptionsBeforeExport = False
        'p_Report.ShowPreviewDialog()

        ShowReport(p_Report)
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



            'anhqh
            '20180110
            'Bo di vi dưới Procedure đã tính rôi
            ' DtTable = Alter_table_HoaDon(DtTable)
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
        Dim p_SQL As String
        Dim p_DataTable As DataTable
        Dim p_L15 As Decimal

        Dim p_Vcf As Decimal

        Dim p_TongXuat As Decimal

        For Each r As DataRow In dtHoaDon.Rows
            vcf = String.Empty
            wcf = String.Empty
            vcf = mdlQCI_GetVCF_NS(IIf(IsDBNull(r.Item("NhiệtĐộ")), 0, r.Item("NhiệtĐộ")), IIf(IsDBNull(r.Item("TỷTrọng")), 0, r.Item("TỷTrọng")))

            Decimal.TryParse(r.Item("L15").ToString.Trim, p_L15)
            Decimal.TryParse(r.Item("TổngXuất").ToString.Trim, p_TongXuat)
            ' p_TongXuat = Convert.ToDecimal(r.Item("TổngXuất").ToString())
            If CheckItemToScada2(r.Item("MãHàngHóa")) = "Y" And p_L15 > 0 Then

                If p_TongXuat > 0 Then
                    p_SQL = "select  dbo.FPT_ROUNDNUMBER( dbo.FPT_ROUNDNUMBER (" & p_L15 & ",0) /  dbo.FPT_ROUNDNUMBER(" & p_TongXuat & ",0) ,4)  as VCF  "

                    p_DataTable = GetDataTable(p_SQL, p_SQL)
                    If Not p_DataTable Is Nothing Then
                        If p_DataTable.Rows.Count > 0 Then
                            If p_DataTable.Rows(0).Item("VCF").ToString.Trim <> "" Then
                                vcf = Left(p_DataTable.Rows(0).Item("VCF").ToString.Trim, 6)
                            End If
                        End If
                    End If
                End If

                'r.Item("L15") = l15
            End If

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
            If CheckItemToScada2(r.Item("MãHàngHóa")) <> "Y" Or r.Item("L15") = "0" Then
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

End Module
