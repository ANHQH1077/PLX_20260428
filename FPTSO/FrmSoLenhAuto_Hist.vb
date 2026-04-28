Public Class FrmSoLenhAuto_Hist
    Dim p_SapConnectionString As String = ""
    Dim p_WareHouse As String = ""
    Dim p_ShPoint As String = ""
    Dim p_TimeOut As String = "0"

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_where As String = ""

        If Not Me.SoLenh.EditValue Is Nothing Then
            If Me.SoLenh.EditValue.ToString.Trim <> "" Then
                p_where = " SoLenh='" & Me.SoLenh.EditValue.ToString.Trim & "'"
            End If
        End If

        If Not Me.NgayXuat.EditValue Is Nothing Then
            If Me.NgayXuat.EditValue.ToString.Trim <> "" Then
                If p_where <> "" Then
                    p_where = p_where & " and  NgayThang='" & Format(Me.NgayXuat.EditValue, g_Format_Date) & "'"
                Else
                    p_where = " NgayThang='" & Format(Me.NgayXuat.EditValue, g_Format_Date) & "'"
                End If

            End If
        End If


        Me.GridView1.Where = p_where
        Me.DefaultFormLoad = True
        Me.XtraForm1_Load()
        Me.DefaultFormLoad = True
    End Sub

    Private Sub FrmSoLenhAuto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim p_TableConfig1 As DataTable
        Dim p_SQL As String
        Try

            p_SQL = "select * from tblConfig;"
            p_TableConfig1 = GetDataTable(p_SQL, p_SQL)

            If Not p_TableConfig1 Is Nothing Then
                If p_TableConfig1.Rows.Count > 0 Then
                    p_SapConnectionString = p_TableConfig1.Rows(0).Item("sapconnectionstring").ToString.Trim
                    p_WareHouse = p_TableConfig1.Rows(0).Item("warehouse").ToString.Trim
                    p_ShPoint = p_TableConfig1.Rows(0).Item("shippingpoint").ToString.Trim
                    p_TimeOut = p_TableConfig1.Rows(0).Item("timeout").ToString.Trim
                End If

            End If

        Catch ex As Exception
            ShowMessageBox("", ex.Message)
        End Try

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_DataTable As DataTable
        Dim p_DataAuto As DataTable
        Dim p_Row As DataRow
        Dim p_RowArr() As DataRow

        Dim p_date As Date
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_ValueMess As Windows.Forms.DialogResult
        Dim p_Count As Integer
        Dim p_SQL As String
        If Me.GridView1.FocusedRowHandle = 0 Then
            GridView1.MoveNext()
            'GridView1.MoveFirst()
        End If
        GridView1.MoveFirst()
        'If Me.GridView1.FocusedRowHandle = Me.GridView1.RowCount - 1 Then
        '    GridView1.MoveFirst()
        'End If

        ' Me.GridView1.RefreshData()
        p_Binding = Me.TrueDBGrid1.DataSource
        If p_Binding Is Nothing Then
            Exit Sub
        End If
        p_DataTable = CType(p_Binding.DataSource, DataTable)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                p_RowArr = p_DataTable.Select("X='Y'")
                If p_RowArr.Length = 0 Then
                    ShowMessageBox("", "Không có lệnh nào được chọn")
                    Exit Sub
                End If
                p_DataAuto = p_DataTable.Clone
                For p_Count = 0 To p_RowArr.Length - 1
                    p_Row = p_DataAuto.NewRow
                    p_Row.Item("SoLenh") = p_RowArr(p_Count).Item("SoLenh").ToString.Trim

                    p_DataAuto.Rows.Add(p_Row)
                Next


                'Dim p_ValueMess As Windows.Forms.DialogResult
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

                If Not Me.NgayXuat.EditValue Is Nothing Then
                    p_date = Me.NgayXuat.EditValue
                Else
                    Exit Sub
                End If

                If g_WCF = False Then

                    Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)

                    If p_SAP_Object.clsLenhXuatAuto(p_date, g_Terminal, g_User_ID, g_UserName, g_Company_Code, _
                                         p_DataAuto, p_SQL) = False Then

                        ShowMessageBox("", p_SQL)
                        Exit Sub
                    Else
                        For p_Count = 0 To p_DataTable.Rows.Count - 1
                            If p_DataTable.Rows(p_Count).Item("X").ToString.Trim = "Y" Then
                                p_RowArr = p_DataAuto.Select("SoLenh='" & p_DataTable.Rows(p_Count).Item("SoLenh").ToString.Trim & "'")
                                If p_RowArr.Length > 0 Then
                                    p_DataTable.Rows(p_Count).Item("sStatus") = p_RowArr(0).Item("sStatus").ToString.Trim
                                    p_DataTable.Rows(p_Count).Item("sDesc") = p_RowArr(0).Item("sDesc").ToString.Trim
                                End If
                            End If

                        Next

                        p_Binding.DataSource = p_DataTable
                        Me.TrueDBGrid1.RefreshDataSource()
                        Me.GridView1.BestFitColumns()
                        ShowStatusMessage(False, "", "Đã thực hiện xong", 7)
                        Exit Sub
                    End If
                Else

                End If

            End If
        End If
    End Sub


    Sub GetSoLenh(ByVal p_DataSoLenh As DataTable)
        Dim p_Count As Integer
        Dim p_DataRow As DataRow
        Dim p_ArrRow() As DataRow
        Dim p_Desc As String
        Dim p_SoLenh As String
        Dim p_SQL As String
        Dim p_Date As Date
        If p_DataSoLenh Is Nothing Then
            Exit Sub
        End If
        '   p_ArrRow = p_DataSoLenh.Select("X='Y'")
        If Not p_ArrRow Is Nothing Then
            Dim p_SAP_Object As New SAP_OBJECT.Class1(g_User_ID, g_Company_Code, g_Services)
            For p_Count = 0 To p_DataSoLenh.Rows.Count - 1
                p_DataRow = p_DataSoLenh.Rows(p_Count)
                If p_DataRow.Item("X").ToString.Trim <> "Y" Then
                    Continue For
                End If
                If p_DataRow.Item("SoLenh").ToString.Trim = "" Then
                    Continue For
                End If
                p_SoLenh = p_DataRow.Item("SoLenh").ToString.Trim
                p_Date = Me.NgayXuat.EditValue

                If g_WCF = False Then
                    If p_SAP_Object.clsSyncDeliveries_SynSpecific(g_Terminal, g_User_ID, g_Company_Code, p_SoLenh, p_Desc, p_Date) = False Then
                        p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ( [SoLenh],[NgayThang],[sDesc] ,[Createby] ,[CreateDate]  ,[StatusCode])"
                        p_SQL = p_SQL & "('" & p_SoLenh & "'," & _
                            " convert(date,'" & CDate(p_Date).ToString(g_Format_Date) & "')," & _
                            "'" & p_Desc & "','" & g_UserName & "', getdate(),'E')"
                    Else
                        p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ( [SoLenh],[NgayThang],[Createby] ,[CreateDate])"
                        p_SQL = p_SQL & "('" & p_SoLenh & "'," & _
                            " convert(date,'" & CDate(p_Date).ToString(g_Format_Date) & "')," & _
                            "'" & g_UserName & "', getdate())"
                    End If
                    If g_Services.Sys_Execute(p_SQL, p_SQL) = True Then

                    End If
                Else
                    If g_Services.mdlSyncDeliveries_SynSpecific(g_User_ID, g_Company_Code, p_SoLenh, p_Desc) = False Then
                        p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ( [SoLenh],[NgayThang],[sDesc] ,[Createby] ,[CreateDate]  ,[StatusCode])"
                        p_SQL = p_SQL & "('" & p_SoLenh & "'," & _
                            " convert(date,'" & CDate(p_Date).ToString(g_Format_Date) & "')," & _
                            "'" & p_Desc & "','" & g_UserName & "', getdate(),'E')"
                    Else
                        p_SQL = "INSERT INTO [FPT_SoLenh_Auto_HIST] ( [SoLenh],[NgayThang],[Createby] ,[CreateDate])"
                        p_SQL = p_SQL & "('" & p_SoLenh & "'," & _
                            " convert(date,'" & CDate(p_Date).ToString(g_Format_Date) & "')," & _
                            "'" & g_UserName & "', getdate())"
                    End If
                    If g_Services.Sys_Execute(p_SQL, p_SQL) = True Then

                    End If
                End If
            Next
        End If
    End Sub

End Class