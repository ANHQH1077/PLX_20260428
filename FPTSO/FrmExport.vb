Public Class FrmExport

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        Dim p_SQL As String = ""
        Dim p_date As Date = CDate("01/01/2000")
        Dim p_Todate As Date = CDate("01/01/2222")
        Dim p_BidingSource As New U_TextBox.U_BindingSource
        Dim p_DataTable As DataTable
        If Not Me.SoLenh.EditValue Is Nothing Then
            If Me.SoLenh.EditValue.ToString.Trim <> "" Then
                p_SQL = "'" & Me.SoLenh.EditValue.ToString.Trim & "'"
            Else
                p_SQL = "Null"
            End If
        Else
            p_SQL = "Null"
        End If
        If Not Me.FromDate.EditValue Is Nothing Then
            If Me.FromDate.EditValue.ToString.Trim <> "" Then
                p_date = CDate(Me.FromDate.EditValue)
                'p_Todate = p_date
                'If p_SQL = "" Then
                '    p_SQL = " NgayXuat>=convert(date,'" & p_date.ToString(g_Format_Date) & "')"
                'Else
                '    p_SQL = p_SQL & " and NgayXuat=convert(date,'" & p_date.ToString(g_Format_Date) & "')"
                'End If
            End If
        End If

        p_SQL = p_SQL & ",'" & p_date.ToString(g_Format_Date) & "'"
        

        If Not Me.ToDate.EditValue Is Nothing Then
            If Me.ToDate.EditValue.ToString.Trim <> "" Then
                p_Todate = CDate(Me.ToDate.EditValue)
            End If
        End If

        p_SQL = p_SQL & ",'" & p_Todate.ToString(g_Format_Date) & "'"

        p_SQL = "exec FPT_LenhXuat_Export " & p_SQL

        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            p_BidingSource.DataSource = p_DataTable
            Me.TrueDBGrid1.DataSource = p_BidingSource
            Me.TrueDBGrid1.RefreshDataSource()
            Me.GridView1.OptionsView.ColumnAutoWidth = False
            Me.GridView1.BestFitColumns()
            Me.GridView1.OptionsBehavior.ReadOnly = True

            Dim p_ColDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
            p_ColDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            ' p_ColDate.DisplayFormat.FormatString = "u"
            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            p_ColDate.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            'p_ColDate.Mask.EditMask = "u"
            p_ColDate.EditMask = "dd/MM/yyyy HH:mm:ss"
            ' p_ColDate.FormatString = "G"
            ' p_ColDate.Mask.UseMaskAsDisplayFormat = True


            GridView1.Columns.Item("GioBD").ColumnEdit = p_ColDate


            p_ColDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            ' p_ColDate.DisplayFormat.FormatString = "u"
            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            p_ColDate.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            'p_ColDate.Mask.EditMask = "u"
            p_ColDate.EditMask = "dd/MM/yyyy HH:mm:ss"
            ' p_ColDate.FormatString = "G"
            ' p_ColDate.Mask.UseMaskAsDisplayFormat = True
            GridView1.Columns.Item("GioKT").ColumnEdit = p_ColDate


            p_ColDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            ' p_ColDate.DisplayFormat.FormatString = "u"
            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            p_ColDate.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            'p_ColDate.Mask.EditMask = "u"
            p_ColDate.EditMask = "dd/MM/yyyy HH:mm:ss"
            ' p_ColDate.FormatString = "G"
            ' p_ColDate.Mask.UseMaskAsDisplayFormat = True
            GridView1.Columns.Item("NgayHD").ColumnEdit = p_ColDate



            p_ColDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy"
            ' p_ColDate.DisplayFormat.FormatString = "u"
            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            p_ColDate.EditFormat.FormatString = "dd/MM/yyyy"
            p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            'p_ColDate.Mask.EditMask = "u"
            p_ColDate.EditMask = "dd/MM/yyyy"
            GridView1.Columns.Item("NgayXuat").ColumnEdit = p_ColDate


            GridView1.Columns.Item("GioKT").Caption = "Ngày Giờ kết thúc"
            GridView1.Columns.Item("GioBD").Caption = "Ngày Giờ bắt đầu"
            GridView1.Columns.Item("NgayXuat").Caption = "Ngày xuất"
            GridView1.Columns.Item("NgayHD").Caption = "Ngày giờ hóa đơn"



           

            p_ColDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            ' p_ColDate.DisplayFormat.FormatString = "u"
            p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            p_ColDate.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            'p_ColDate.Mask.EditMask = "u"
            p_ColDate.EditMask = "dd/MM/yyyy HH:mm:ss"
            GridView1.Columns.Item("NgayNhan").ColumnEdit = p_ColDate


            Me.GridView1.BestFitColumns()
            'p_Column.ColumnEdit = p_ColDate

            'GridView1.Columns.Item("GioBD").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            'GridView1.Columns.Item("GioBD").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            'GridView1.Columns.Item("GioKT").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
            'GridView1.Columns.Item("GioKT").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

        End If
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Dim p_Err As String
        If g_Module.p_ModGridExportToExcelNew(Me.TrueDBGrid1, _
                                                p_Err) = False Then
            ShowMessageBox("", p_Err)
        End If
    End Sub
End Class