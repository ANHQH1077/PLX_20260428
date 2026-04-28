Public Class FrmScadarSQL
    Private g_TypeConnet As String
    Private p_TblE5 As DataTable
    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        Dim p_SQL As String
        Dim p_TableLine, p_Tbl, p_ResultTbl As DataTable
        Dim p_Count As Integer
        Dim p_Value As String
        Dim p_StrConnect As String
        Dim p_DataSet As DataSet
        Dim p_ArrRow() As DataRow
        Dim p_Where As String = ""
        Dim p_NgayXuat As DateTime
        Dim p_MaVanTai As String = "BO"
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_FieldName As String
        Dim p_ColNumber As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        Dim p_ColDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit

        Me.TrueDBGrid1.Visible = False
        Me.TrueDBGrid2.Visible = False
        p_Value = ""
        If Not Me.Client.EditValue Is Nothing Then
            p_Value = Me.Client.EditValue.ToString.Trim

        End If
        p_SQL = "select * from tblMap_cp where Client='" & p_Value & "' and  Status='in';" &
                "select * from SYS_Map_cp_Line where sWhere='Y' and STT in (select STT from tblMap_cp where Client='" & p_Value & "' and  Status='in');"
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        If Not p_DataSet Is Nothing Then
            p_Tbl = p_DataSet.Tables(0)
            p_TableLine = p_DataSet.Tables(1)
        End If
        If p_Tbl Is Nothing Then
            Exit Sub
        End If
        If p_Tbl.Rows.Count <= 0 Then
            Exit Sub
        End If
        If Not Me.MaVanChuyen.EditValue Is Nothing Then
            If Me.MaVanChuyen.EditValue.ToString.Trim <> "" Then
                p_MaVanTai = Me.MaVanChuyen.EditValue.ToString.Trim
            End If
        End If

        If g_TypeConnet = "SQL" Then
            p_StrConnect = "Provider=SQLOLEDB;Server=" & p_Tbl.Rows(0).Item("ServerScada").ToString.Trim & _
                       ";Database=" & p_Tbl.Rows(0).Item("DatabaseScada").ToString.Trim & _
                       ";User ID=" & p_Tbl.Rows(0).Item("UidScada").ToString.Trim & _
                       ";Password=" & p_Tbl.Rows(0).Item("PwdScada").ToString.Trim & _
                       ";Trusted_Connection=False"

            p_Value = ""
            If Not Me.NgayXuat.EditValue Is Nothing Then
                If Me.NgayXuat.EditValue.ToString.Trim <> "" Then
                    p_Value = CDate(Me.NgayXuat.EditValue).ToString("yyyyMMdd")
                End If
                p_ArrRow = p_TableLine.Select("FromField='NgayXuat'")
                If p_ArrRow.Length > 0 Then
                    If p_Where = "" Then
                        p_Where = p_ArrRow(0).Item(p_MaVanTai).ToString.Trim & "='" & p_Value & "'"

                    Else
                        p_Where = p_Where & " and " & p_ArrRow(0).Item(p_MaVanTai).ToString.Trim & "='" & p_Value & "'"
                    End If
                End If
            End If


            If Not Me.TableID.EditValue Is Nothing Then
                If Me.TableID.EditValue.ToString.Trim <> "" Then
                    p_Value = Me.TableID.EditValue.ToString.Trim
                End If
                p_ArrRow = p_TableLine.Select("FromField='TableID'")
                If p_ArrRow.Length > 0 Then
                    If p_Where = "" Then
                        p_Where = p_ArrRow(0).Item(p_MaVanTai).ToString.Trim & "='" & p_Value & "'"

                    Else
                        p_Where = p_Where & " and " & p_ArrRow(0).Item(p_MaVanTai).ToString.Trim & "='" & p_Value & "'"
                    End If
                End If
            End If

            If p_Where <> "" Then
                p_Value = ""
                If Not Me.Client.EditValue Is Nothing Then
                    p_Value = Me.Client.EditValue.ToString.Trim

                End If

                If InStr(p_Value, "E5", CompareMethod.Text) > 0 Then
                    Me.TrueDBGrid1.Visible = True
                    Me.TrueDBGrid2.Visible = False
                    p_SQL = ""
                    For p_Count = 0 To p_TblE5.Rows.Count - 1
                        p_SQL = p_SQL & "," & p_TblE5.Rows(p_Count).Item("FieldName").ToString.Trim & " as [" & p_TblE5.Rows(p_Count).Item("sNote").ToString.Trim & "]"

                    Next
                    p_SQL = Mid(p_SQL, 2)
                    p_SQL = "select " & p_SQL & " from " & p_Tbl.Rows(0).Item("TableName").ToString.Trim & " Where " & p_Where
                    p_ResultTbl = g_Services.GET_DATATABLE_With_Connect_Des(p_StrConnect, p_SQL, _
                                                   p_SQL)
                    If Not p_ResultTbl Is Nothing Then
                        'p_ResultTbl.Columns(2).DataType = System.Single
                        p_Binding.DataSource = p_ResultTbl
                        Me.TrueDBGrid1.DataSource = p_Binding
                        TrueDBGrid1.RefreshDataSource()
                        For p_Count = 0 To Me.GridView1.Columns.Count - 1
                            If UCase(GridView1.Columns.Item(p_Count).ColumnType.Name.ToString) = UCase("Single") Then
                                p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
                                p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                                p_ColNumber.DisplayFormat.FormatString = "###############0.0000"
                                p_ColNumber.EditMask = "###############0.0000"
                                GridView1.Columns.Item(p_Count).ColumnEdit = p_ColNumber
                            ElseIf UCase(GridView1.Columns.Item(p_Count).ColumnType.Name.ToString) = UCase("DATETIME") Then
                                p_ColDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
                                p_ColDate.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never
                                p_ColDate.Buttons.Item(0).Visible = False
                                p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                                p_ColDate.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss"
                                ' p_ColDate.DisplayFormat.FormatString = "u"
                                p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                                ' p_ColDate.DisplayFormat.

                                ' p_ColDate.EditMask = "u"

                                p_ColDate.EditFormat.FormatString = "dd-MM-yyyy HH:mm:ss"
                                p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime

                                'p_ColDate.Mask.EditMask = "u"
                                p_ColDate.EditMask = "dd-MM-yyyy  HH:mm:ss"
                                ' p_ColDate.FormatString = "G"
                                ' p_ColDate.Mask.UseMaskAsDisplayFormat = True

                                GridView1.Columns.Item(p_Count).ColumnEdit = p_ColDate
                                GridView1.Columns.Item(p_Count).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                                GridView1.Columns.Item(p_Count).DisplayFormat.FormatString = "dd-MM-yyyy HH:mm:ss"
                            End If
                            GridView1.Columns.Item(p_Count).OptionsColumn.ReadOnly = True

                        Next

                        Me.GridView1.BestFitColumns()

                    End If
                Else

                    Me.TrueDBGrid1.Visible = False
                    Me.TrueDBGrid2.Visible = True


                    p_SQL = "select * from " & p_Tbl.Rows(0).Item("TableName").ToString.Trim & " Where " & p_Where
                    p_ResultTbl = g_Services.GET_DATATABLE_With_Connect_Des(p_StrConnect, p_SQL, _
                                                   p_SQL)
                    If Not p_ResultTbl Is Nothing Then
                        p_Binding.DataSource = p_ResultTbl
                        Me.TrueDBGrid2.DataSource = p_Binding
                        Me.TrueDBGrid2.RefreshDataSource()
                        'GridView1.RefreshEditor(True)
                        ' Me.GridView1.Dispose()
                        p_Binding.DataSource = p_ResultTbl
                        Me.TrueDBGrid2.DataSource = p_Binding
                        Me.TrueDBGrid2.RefreshDataSource()
                        'TrueDBGrid1.MainView = Me.GridView1
                        ' Me.TrueDBGrid1.RefreshDataSource(

                        '                        GridView1.DataSource
                        p_Value = ""
                        If Not Me.Client.EditValue Is Nothing Then
                            p_Value = Me.Client.EditValue.ToString.Trim

                        End If


                        Me.GridView2.BestFitColumns()
                    End If
                End If
            End If
        End If
        GridView1.ShowFindPanel()
        GridView2.ShowFindPanel()
    End Sub

    Private Sub FrmScadarSQL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        Dim p_Table As DataTable

        Dim p_Count As Integer
        p_SQL = "select Distinct Client from tblMap_cp order by Client desc"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            For p_Count = 0 To p_Table.Rows.Count - 1
                Me.Client.Properties.Items.Add(p_Table.Rows(p_Count).Item("Client").ToString.Trim)
            Next
        End If


        Me.MaVanChuyen.Properties.Items.Add("BO")
        Me.MaVanChuyen.Properties.Items.Add("THUY")
        Me.MaVanChuyen.Properties.Items.Add("SAT")



        p_SQL = "select * from tblconfig"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            For p_Count = 0 To p_Table.Rows.Count - 1
                g_TypeConnet = p_Table.Rows(p_Count).Item("optional").ToString.Trim
            Next
        End If
        p_SQL = "select upper([FieldName]  ) as FieldName ,[sNote] from  tblLenhXuatChiTietE5_Info where  isnull(HTTG,'') <> 'Y' order by vOrder"
        p_TblE5 = GetDataTable(p_SQL, p_SQL)
        

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim p_Error As String
        If p_XtraModuleObj.p_ModGridExportToExcelNew(TrueDBGrid1, _
                                                  p_Error) = True Then

        End If
    End Sub
End Class