Public Class FrmVehicleAdd
    Private flag As Integer()
    Private lw_mess As String()

    Private isGetAll As String
    Private g_dt As DataTable
    Private _TimeOut = New TimeSpan()

    Private _SapConnectionString As String
    Private _WareHouse As String
    Dim _dtVariable As DataTable
    Private _ShPoint As String

    Private Vehicle_Upd As String = "N"
    Private Vehicle_Add As String = "N"
    Private Vehicle_Sap As String = "N"


    Function CheckMaNgan() As Boolean
        Dim p_SoNgan As Integer = 0
        Dim p_Count As Integer
        Dim p_Total As Integer = 0
        Dim p_DataRow As DataRow
        Try
            CheckMaNgan = False
            If Not Me.SoNgan.EditValue Is Nothing Then
                p_SoNgan = Me.SoNgan.EditValue
            End If
        Catch ex As Exception
            CheckMaNgan = True
        End Try
        With GridView1
            For p_Count = 0 To .RowCount - 1
                If .IsDataRow(p_Count) = True Then
                    p_DataRow = Me.GridView1.GetDataRow(p_Count)
                    If Not p_DataRow Is Nothing Then
                        If p_DataRow.Item("MaNgan").ToString.Trim <> "" Then
                            p_Total = p_Total + 1
                        End If
                    End If
                End If
            Next
        End With

        If p_SoNgan <> p_Total Then
            CheckMaNgan = True
        End If
    End Function

    Sub SaveRecode()
        Dim p_SQL As String
        Dim p_MaPhuongTien As String = ""
        Dim p_DataTable As DataTable
        p_SQL = ""
        Try
            If Me.MaPhuongTien.EditValue Is Nothing Then
                ShowMessageBox("", "Mã phương tiện không được trống")
                Exit Sub
            End If
            p_MaPhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
            If p_MaPhuongTien.ToString.Trim = "" Then
                ShowMessageBox("", "Mã phương tiện không được trống")
                Exit Sub
            End If
            'If Asc(e.KeyChar) = 19 Then
            '  MsgBox(Asc(e.KeyChar))
            Me.Update()
            Me.GridView1.UpdateCurrentRow()
            'If CheckMaNgan() = True Then
            '    p_XtraModuleObj.ModErrExceptionNew("MS0085", "Số lượng ngăn không hợp lệ")
            '    Exit Sub
            'End If

            If Me.NgayBatDau1.EditValue Is Nothing Then
                Me.NgayBatDau.EditValue = "00000000"
            ElseIf Me.NgayBatDau1.EditValue.ToString.Trim <> "" Then
                Me.NgayBatDau.EditValue = CDate(Me.NgayBatDau1.EditValue).ToString("yyyyMMdd")
            Else
                Me.NgayBatDau.EditValue = "00000000"
            End If

            If Me.NgayHieuLuc1.EditValue Is Nothing Then
                Me.NgayHieuLuc.EditValue = "00000000"
            ElseIf Me.NgayHieuLuc1.EditValue.ToString.Trim <> "" Then
                Me.NgayHieuLuc.EditValue = CDate(Me.NgayHieuLuc1.EditValue).ToString("yyyyMMdd")
            Else
                Me.NgayHieuLuc.EditValue = "00000000"
            End If

            If g_FormAddnew = True Then
                'Kiem tra trung phuong tien khong
                p_SQL = "select 1 as PT from tblPhuongTien where UPPER( MaPhuongTien) =upper('" & p_MaPhuongTien.ToString.Trim & "')"
                p_DataTable = g_Services.Sys_SYS_GET_DATATable_Des(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        ShowMessageBox("", "Mã phương tiện đã có trong hệ thống")
                        Exit Sub
                    End If

                End If
            End If

            InsertHistory()

            Me.DefaultSave = True
            UpdateToDatabase(Me, Me.ButtonSave)
            Me.DefaultSave = False
            'e.Handled = True

            'End If


        Catch ex As Exception
            p_XtraModuleObj.ModErrExceptionNew(Err.Number, ex.Message)
        End Try
    End Sub


    Private Sub InsertHistory()

        Dim p_bind As New U_TextBox.U_BindingSource
        Dim p_Table As DataTable
        Dim p_Row As DataRow
        ' Dim p_Row_Arr() As DataRow
        Dim p_SQL As String
        Dim p_FromDate As String = "00000000"
        Dim p_ToDate As String = "00000000"
        Dim p_MaPhuongTien As String = ""
        Dim p_LaiXe As String = ""
        Dim p_RegNo As String = ""
        Dim p_SoNgan As String = "0"
        Dim p_TaiTrong As String = "0"
        Dim p_LTT_CM As Integer
        Dim p_NHAP_MM As Integer
        Dim p_DUONGSINH As Integer
        Dim p_Count As Integer
        If Not pv_LineRemove Is Nothing Then
            For p_Count = pv_LineRemove.Rows.Count - 1 To 0 Step -1
                If pv_LineRemove.Rows(p_Count).Item(1).ToString.Trim = "AAA" Then
                    pv_LineRemove.Rows.RemoveAt(p_Count)
                End If
            Next
            pv_LineRemove.AcceptChanges()
            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_MaPhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
            End If

            If Not Me.SoNgan.EditValue Is Nothing Then
                p_SoNgan = Me.SoNgan.EditValue.ToString.Trim
            End If

            If Not Me.TuType.EditValue Is Nothing Then
                p_LaiXe = Me.TuType.EditValue.ToString.Trim
            End If


            If Not Me.NgayBatDau1.EditValue Is Nothing Then
                If Me.NgayBatDau1.EditValue.ToString.Trim <> "" Then
                    p_FromDate = CDate(Me.NgayBatDau1.EditValue).ToString("yyyyMMdd")
                End If

            End If

            If Not Me.NgayHieuLuc1.EditValue Is Nothing Then
                If Me.NgayHieuLuc1.EditValue.ToString.Trim <> "" Then
                    p_ToDate = CDate(Me.NgayHieuLuc1.EditValue).ToString("yyyyMMdd")
                End If

            End If

            If Not Me.U_NumericEdit1.EditValue Is Nothing Then
                p_TaiTrong = Me.U_NumericEdit1.EditValue.ToString
            End If


            If Not Me.REG_NO.EditValue Is Nothing Then
                p_RegNo = Me.REG_NO.EditValue.ToString
            End If

         

            p_SQL = "INSERT INTO [tblPhuongTien_Hist] ([MaPhuongTien],[LaiXe]" & _
                           " ,[SoNgan],[NgayBatDau],[NgayHieuLuc] ,[Status],[SyncDate] " & _
                           " ,[Createby] ,[UpdatedBy] ,[CreateDate],[UpdateDate],[UpdStatus], iweight, REG_NO)"

            p_SQL = p_SQL & " SELECT N'" & Replace(p_MaPhuongTien, "'", "", 1) & "' as MaPhuongTien," & _
                                    "N'" & Replace(p_LaiXe, "'", "", 1) & "' as LaiXe, " & _
                                    "" & Convert.ToInt32(p_SoNgan) & " as SoNgan," & _
                                     "'" & Replace(p_FromDate, "'", "", 1) & "' as NgayBatDau , " & _
                                     "'" & Replace(p_ToDate, "'", "", 1) & "' as NgayHieuLuc , " & _
                                     "'S' as Status, getdate() as SyncDate," & _
                                       "'" & g_UserName & "' as Createby, '" & g_UserName & _
                                       "' as UpdatedBy,getdate() as CreateDate, getdate() as UpdateDate,'U' as UpdStatus ," & p_TaiTrong & " as iweight,'" & p_RegNo & "' as REG_NO " & _
                             " where  exists (select 1 from  tblPhuongTien where  MaPhuongTien ='" & Replace(p_MaPhuongTien, "'", "", 1) & "' )"

            p_Row = pv_LineRemove.NewRow
            p_Row.Item(0) = p_SQL
            p_Row.Item(1) = "AAA"
            pv_LineRemove.Rows.Add(p_Row)

            p_SQL = "INSERT INTO [tblPhuongTien_Hist] ([MaPhuongTien],[LaiXe]" & _
                            " ,[SoNgan],[NgayBatDau],[NgayHieuLuc] ,[Status],[SyncDate] " & _
                            " ,[Createby] ,[UpdatedBy] ,[CreateDate],[UpdateDate],[UpdStatus], iweight, REG_NO)"

            p_SQL = p_SQL & " SELECT N'" & Replace(p_MaPhuongTien, "'", "", 1) & "' as MaPhuongTien," & _
                                    "N'" & Replace(p_LaiXe, "'", "", 1) & "' as LaiXe, " & _
                                    "" & Convert.ToInt32(p_SoNgan) & " as SoNgan," & _
                                     "'" & Replace(p_FromDate, "'", "", 1) & "' as NgayBatDau , " & _
                                     "'" & Replace(p_ToDate, "'", "", 1) & "' as NgayHieuLuc , " & _
                                     "'S' as Status, getdate() as SyncDate," & _
                                       "'" & g_UserName & "' as Createby, '" & g_UserName & _
                                       "' as UpdatedBy,getdate() as CreateDate, getdate() as UpdateDate,'I' as UpdStatus ," & p_TaiTrong & " as iweight,'" & p_RegNo & "' as REG_NO  " & _
                             " where not exists (select 1 from  tblPhuongTien where  MaPhuongTien ='" & Replace(p_MaPhuongTien, "'", "", 1) & "' )"

            p_Row = pv_LineRemove.NewRow
            p_Row.Item(0) = p_SQL
            p_Row.Item(1) = "AAA"
            pv_LineRemove.Rows.Add(p_Row)

            'End If
            p_bind = Me.TrueDBGrid1.DataSource
            p_Table = CType(p_bind.DataSource, DataTable)
            For p_Count = 0 To p_Table.Rows.Count - 1
                If p_Table.Rows(p_Count).Item("CHECKUPD").ToString.Trim = "Y" Or p_Table.Rows(p_Count).Item("CHECKUPD").ToString.Trim = "I" Then

                  
                    Integer.TryParse(p_Table.Rows(p_Count).Item("LTT_CM").ToString.Trim, p_LTT_CM)
                    Integer.TryParse(p_Table.Rows(p_Count).Item("NHAP_MM").ToString.Trim, p_NHAP_MM)
                    Integer.TryParse(p_Table.Rows(p_Count).Item("DUONGSINH").ToString.Trim, p_DUONGSINH)

                    p_SQL = "INSERT INTO [tblChiTietPhuongTien_Hist]([MaNgan],[MaPhuongTien],[SoLuongMax] " & _
                           " ,[Createby],[UpdatedBy],[CreateDate],[UpdateDate],[Status],[SyncDate],[UpdStatus],[LTT_CM],[NHAP_MM] ,[DUONGSINH])"
                    p_SQL = p_SQL & " Select   '" & Replace(p_Table.Rows(p_Count).Item("MaNgan").ToString.Trim, "'", "", 1) & "' as MaNgan ," & _
                                                    "'" & Replace(p_Table.Rows(p_Count).Item("MaPhuongTien").ToString.Trim, "'", "", 1) & "' as MaPhuongTien ," & _
                                                    "" & Convert.ToDecimal(p_Table.Rows(p_Count).Item("SoLuongMax").ToString.Trim) & " as SoLuongMax," & _
                                                    "'" & g_UserName & "' as Createby, '" & g_UserName & _
                                                    "' as UpdatedBy,getdate() as CreateDate, getdate() as UpdateDate,'S' as Status, getdate() as SyncDate, 'U' as UpdStatus," & _
                                                    p_LTT_CM & " as LTT_CM, " & p_NHAP_MM & " as NHAP_MM,  " & p_DUONGSINH & " as DUONGSINH " & _
                                                    " where  exists (select 1 from  tblChiTietPhuongTien where  MaPhuongTien ='" & Replace(Replace(p_Table.Rows(p_Count).Item("MaPhuongTien").ToString.Trim, "'", "", 1), "'", "", 1) & "'" & _
                                                    "  and MaNgan='" & Replace(p_Table.Rows(p_Count).Item("MaNgan").ToString.Trim, "'", "", 1) & "')"


                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = pv_LineRemove.NewRow
                    p_Row.Item(0) = p_SQL
                    p_Row.Item(1) = "AAA"
                    pv_LineRemove.Rows.Add(p_Row)

                    p_SQL = "INSERT INTO [tblChiTietPhuongTien_Hist]([MaNgan],[MaPhuongTien],[SoLuongMax] " & _
                          " ,[Createby],[UpdatedBy],[CreateDate],[UpdateDate],[Status],[SyncDate],[UpdStatus],[LTT_CM],[NHAP_MM] ,[DUONGSINH])"
                    p_SQL = p_SQL & " Select   '" & Replace(p_Table.Rows(p_Count).Item("MaNgan").ToString.Trim, "'", "", 1) & "' as MaNgan ," & _
                                                    "'" & Replace(p_Table.Rows(p_Count).Item("MaPhuongTien").ToString.Trim, "'", "", 1) & "' as MaPhuongTien ," & _
                                                    "" & Convert.ToDecimal(p_Table.Rows(p_Count).Item("SoLuongMax").ToString.Trim) & " as SoLuongMax," & _
                                                    "'" & g_UserName & "' as Createby, '" & g_UserName & _
                                                    "' as UpdatedBy,getdate() as CreateDate, getdate() as UpdateDate,'S' as Status, getdate() as SyncDate, 'I' as UpdStatus, " & _
                                                    p_LTT_CM & " as LTT_CM, " & p_NHAP_MM & " as NHAP_MM,  " & p_DUONGSINH & " as DUONGSINH " & _
                                                    " where not exists (select 1 from  tblChiTietPhuongTien where  MaPhuongTien ='" & Replace(Replace(p_Table.Rows(p_Count).Item("MaPhuongTien").ToString.Trim, "'", "", 1), "'", "", 1) & "'" & _
                                                    "  and MaNgan='" & Replace(p_Table.Rows(p_Count).Item("MaNgan").ToString.Trim, "'", "", 1) & "')"


                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Row = pv_LineRemove.NewRow
                    p_Row.Item(0) = p_SQL
                    p_Row.Item(1) = "AAA"
                    pv_LineRemove.Rows.Add(p_Row)



                End If
            Next
        End If
    End Sub

    Private Sub FrmVehicleAdd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            SaveRecode()
        End If
        
    End Sub

    Private Sub FrmVehicleAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        Dim p_DataSet As DataSet
        Dim p_DataTable As DataTable
        Me.DefaultFormLoad = True

        If g_Company_Code = "6610" Then
            Me.NgayBatDau1.FieldName = "NgayBatDau2"
            Me.NgayHieuLuc1.FieldName = "NgayHieuLuc2"
        End If
        p_SQL = "select column_id from sys.all_columns a where exists (select 1 from sys.all_objects b where upper(name)= upper('FPT_tblPhuongTien_V1') " & _
               " and a.Object_id=b.object_id) and upper(a.name)= upper('nhacungcap') "
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Me.Label8.Visible = True
                Me.NhaCungCap.Visible = True
                Me.NhaCungCap.AllowInsert = True
                Me.NhaCungCap.AllowUpdate = True
                NhaCungCap.FieldName = "NhaCungCap"
                NhaCungCap.TableName = "tblPhuongTien"
                NhaCungCap.ViewName = "FPT_tblPhuongTien_V1"
                NhaCungCap.Enabled = True
            End If
        End If

        p_DataTable = Nothing
        p_XtraUserName = g_User_ID
        Me.Form1_Load(sender, e)

        If g_FormAddnew = True Then
            Me.BtnOk.Text = Me.CaptionUpd
            Me.MaPhuongTien.Focus()
        Else
            Me.BtnOk.Text = Me.CaptionAdd
        End If
        p_SQL = "select * from tblConfig;select * from SYS_USER where USER_ID=" & g_User_ID
        p_DataSet = GetDataSet(p_SQL, p_SQL)
        '_dtVariable = GetDataTable(p_SQL, p_SQL)
        _dtVariable = p_DataSet.Tables(0)
        p_DataTable = p_DataSet.Tables(1)
        If Not _dtVariable Is Nothing Then
            If _dtVariable.Rows.Count > 0 Then
                _SapConnectionString = _dtVariable.Rows(0).Item("sapconnectionstring").ToString.Trim
                _WareHouse = _dtVariable.Rows(0).Item("WareHouse").ToString.Trim
                _ShPoint = _dtVariable.Rows(0).Item("shippingpoint").ToString.Trim
            End If
        End If

        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Vehicle_Upd = p_DataTable.Rows(0).Item("Vehicle_Upd").ToString.Trim()
                Vehicle_Add = p_DataTable.Rows(0).Item("Vehicle_Add").ToString.Trim()
                Vehicle_Sap = p_DataTable.Rows(0).Item("Vehicle_Sap").ToString.Trim

                If Vehicle_Upd = "Y" Then
                    Me.GridView1.OptionsBehavior.ReadOnly = False
                    Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True
                    Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
                    Me.FormEdit = True
                Else
                    'Me.GridView1.OptionsBehavior.AllowAddRows
                    Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False
                    Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                    Me.GridView1.OptionsBehavior.ReadOnly = True
                    Me.FormEdit = False
                End If
                If Vehicle_Add = "Y" Then
                    Me.BtnOk.Visible = True
                    'Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False
                    Me.FormEdit = True
                    Me.cmdSave.Visible = False
                Else
                    Me.BtnOk.Visible = False
                    If Vehicle_Upd = "Y" Then
                        Me.cmdSave.Visible = True
                        Me.cmdSave.Top = Me.BtnOk.Top
                        Me.cmdSave.Left = Me.BtnOk.Left
                    End If
                End If

                If Vehicle_Sap = "Y" Then
                    Me.ToolStripButton3.Visible = True
                Else
                    Me.ToolStripButton3.Visible = False
                End If
            End If

        End If
      
    End Sub


    Private Sub GridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Dim p_Row As DataRow
        Dim p_Value As String = ""
        If UCase(e.Column.Name.ToString.Trim) <> UCase("ColStatus") Then
            p_Row = Me.GridView1.GetDataRow(e.RowHandle)
            If Not p_Row Is Nothing Then

                'Else
                If p_Row.Item("CHECKUPD").ToString.Trim <> "N" Then
                    Me.GridView1.SetFocusedRowCellValue("Status", p_Value)
                End If
            End If
            
        End If
    End Sub


    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click

        If Me.BtnOk.Text = Me.CaptionAdd And Me.FormStatus = False Then
            'Me.Navigator1.NavigatorButtonType_Append(Me.Navigator1, Me.Navigator1.)
            Me.Navigator1.Buttons.DoClick(Me.Navigator1.Buttons.Append)
            Me.MaPhuongTien.Focus()
            'Me.DefaultWhere = " WHERE MaPhuongTien=N''"
            'Me.DefaultFormLoad = True
            'XtraForm1_Load()
            Me.FormStatus = False
            'Me.BtnOk.Text = Me.CaptionUpd
            'Me.MaPhuongTien.Focus()
            g_FormAddnew = True
        ElseIf Me.BtnOk.Text = Me.CaptionUpd And Me.FormStatus = True Then
            SaveRecode()
            If Vehicle_Add = "Y" Then
            Else
                Me.BtnOk.Visible = False
                Me.BtnOk.Text = "Ok"
            End If
        End If

        
       

        

    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Function GetDetail() As Boolean
        Dim p_SoNgan As Integer = 0
        Dim p_Datarow As DataRow
        Dim p_Datarow1 As DataRow

        Dim p_RowArr() As DataRow
        Dim p_Count As Integer
        Dim p_Col As Integer
        Dim p_SQL As String = ""
        Dim p_Ngan As String
        Dim p_MaPhuongTien As String = ""
        Dim p_DataBinding As U_TextBox.U_BindingSource
        Dim p_DataTable As DataTable
        Dim p_DataTableOld As New DataTable
        '     pv_LineRemove()
        Dim p_Table As DataTable
        Dim p_Value As Integer
        ' Dim p_RowArr() As DataRow

        Try
            If Not Me.MaPhuongTien.EditValue Is Nothing Then
                p_MaPhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
            End If
            If Not Me.SoNgan.EditValue Is Nothing Then
                p_SoNgan = Me.SoNgan.EditValue
            End If
            ' Me.GridView1.EndUpdate()
            Me.TrueDBGrid1.Update()
            p_DataBinding = Me.TrueDBGrid1.DataSource
            p_DataTable = CType(p_DataBinding.DataSource, DataTable)

            For p_Count = p_DataTable.Rows.Count - 1 To 0 Step -1
                p_DataTable.Rows.RemoveAt(p_Count)
            Next

            p_DataTable.Clear()

            p_DataTable.AcceptChanges()

            p_SQL = "select * from tblChiTietPhuongTien where MaPhuongTien ='" & p_MaPhuongTien & "'"
            p_Table = GetDataTable(p_SQL, p_SQL)
            Me.GridView1.MoveFirst()
            For p_Count = 0 To p_SoNgan - 1
                If p_Count + 1 < 10 Then
                    p_Ngan = "00" & p_Count + 1
                Else
                    p_Ngan = "0" & p_Count + 1
                End If

                Me.GridView1.AddNewRow()
                Me.GridView1.SetFocusedRowCellValue("MaPhuongTien", p_MaPhuongTien)
                Me.GridView1.SetFocusedRowCellValue("SoLuongMax", 1000 * (p_Count + 1))
                Me.GridView1.SetFocusedRowCellValue("MaNgan", p_Ngan)
                'p_RowArr = p_DataTableOld.Select("MaPhuongTien='" & p_MaPhuongTien & "' and MaNgan='" & p_Ngan & "'")
                'If p_RowArr.Length > 0 Then
                '    Me.GridView1.SetFocusedRowCellValue("CHECKUPD", "")
                'Else
                Me.GridView1.SetFocusedRowCellValue("CHECKUPD", "I")
                ' End If
                Me.GridView1.SetFocusedRowCellValue("Status", "S")

                ' Me.GridView1.MoveNext()
            Next

            pv_LineRemove.Clear()


            p_Datarow1 = pv_LineRemove.NewRow
            p_Datarow1.Item(0) = "DELETE FROM tblChiTietPhuongTien where MaPhuongTien ='" & p_MaPhuongTien & "' "

            pv_LineRemove.Rows.Add(p_Datarow1)





            Exit Function
            p_DataTableOld = p_DataTable.Clone
            For p_Count = 0 To p_DataTable.Rows.Count - 1
                p_Datarow = p_DataTableOld.NewRow
                For p_Col = 0 To p_DataTable.Columns.Count - 1
                    p_Datarow.Item(p_Col) = p_DataTable.Rows(p_Count).Item(p_Col)
                Next
                p_DataTableOld.Rows.Add(p_Datarow)
            Next

            If p_SoNgan < p_DataTableOld.Rows.Count Then
                For p_Count = p_DataTable.Rows.Count - 1 To p_SoNgan Step -1
                    If p_Count + 1 < 10 Then
                        p_Ngan = "00" & p_Count + 1
                    Else
                        p_Ngan = "0" & p_Count + 1
                    End If

                    p_SQL = "DELETE FROM tblChiTietPhuongTien where MaPhuongTien ='" & p_MaPhuongTien & "'  and   MaNgan='" & p_Ngan.ToString.Trim & "'"
                    p_Datarow1 = pv_LineRemove.NewRow
                    p_Datarow1.Item(0) = p_SQL
                    pv_LineRemove.Rows.Add(p_Datarow1)

                    p_SQL = "INSERT INTO [tblChiTietPhuongTien_Hist]([MaNgan],[MaPhuongTien],[SoLuongMax] " & _
                          " ,[Createby],[UpdatedBy],[CreateDate],[UpdateDate],[Status],[SyncDate],[UpdStatus])"
                    p_SQL = p_SQL & "  VALUES ('" & Replace(p_DataTable.Rows(p_Count).Item("MaNgan").ToString.Trim, "'", "", 1) & "' ," & _
                                                    "'" & Replace(p_DataTable.Rows(p_Count).Item("MaPhuongTien").ToString.Trim, "'", "", 1) & "'  ," & _
                                                    "" & Convert.ToDecimal(p_DataTable.Rows(p_Count).Item("SoLuongMax").ToString.Trim) & "," & _
                                                    "'" & g_UserName & "' , '" & g_UserName & _
                                                    "' ,getdate() , getdate() ,'S' , getdate() , 'D'" & _
                                                    " )"


                    ' p_SQL = Replace(p_SQL, "''", "'", 1)
                    p_Datarow1 = pv_LineRemove.NewRow
                    p_Datarow1.Item(0) = p_SQL
                    'p_Datarow1.Item(1) = "AAA"
                    pv_LineRemove.Rows.Add(p_Datarow1)

                    p_DataTable.Rows.RemoveAt(p_Count)

                Next
            End If
            p_DataBinding.DataSource = p_DataTable
            Me.TrueDBGrid1.DataSource = p_DataBinding
            Me.TrueDBGrid1.RefreshDataSource()


            'If p_SoNgan < p_DataTableOld.Rows.Count Then
            '    ' For p_Count = p_SoNgan To p_DataTableOld.Rows.Count - 1
            '    p_SQL = "DELETE FROM tblChiTietPhuongTien where MaPhuongTien ='" & p_MaPhuongTien & "'"  ' and   MaNgan='" & p_DataTableOld.Rows(p_Count).Item("MaNgan").ToString.Trim & "'"
            '    p_Datarow1 = pv_LineRemove.NewRow
            '    p_Datarow1.Item(0) = p_SQL
            '    pv_LineRemove.Rows.Add(p_Datarow1)
            '    ' Next
            '    'For p_Count = 0 To p_SoNgan - 1
            '    '    If p_Count + 1 < 10 Then
            '    '        p_Ngan = "00" & p_Count + 1
            '    '    Else
            '    '        p_Ngan = "0" & p_Count + 1
            '    '    End If
            '    '    Me.GridView1.AddNewRow()
            '    '    Me.GridView1.SetFocusedRowCellValue("MaPhuongTien", p_MaPhuongTien)
            '    '    Me.GridView1.SetFocusedRowCellValue("SoLuongMax", 1000 * (p_Count + 1))
            '    '    Me.GridView1.SetFocusedRowCellValue("MaNgan", p_Ngan)
            '    '    'p_RowArr = p_DataTableOld.Select("MaPhuongTien='" & p_MaPhuongTien & "' and MaNgan='" & p_Ngan & "'")
            '    '    'If p_RowArr.Length > 0 Then
            '    '    '    Me.GridView1.SetFocusedRowCellValue("CHECKUPD", "")
            '    '    'Else
            '    '    Me.GridView1.SetFocusedRowCellValue("CHECKUPD", "R")
            '    '    ' End If
            '    '    ' Me.GridView1.SetFocusedRowCellValue("Status", "S")

            '    'Next

            '    'GoTo Line_KT
            'End If

            'For p_Count = p_SoNgan To p_DataTableOld.Rows.Count - 1
            '    p_SQL = "DELETE FROM tblChiTietPhuongTien where MaPhuongTien ='" & p_DataTableOld.Rows(p_Count).Item("MaPhuongTien").ToString.Trim & "' and   MaNgan='" & p_DataTableOld.Rows(p_Count).Item("MaNgan").ToString.Trim & "'"
            '    p_Datarow1 = pv_LineRemove.NewRow
            '    p_Datarow1.Item(0) = p_SQL
            '    pv_LineRemove.Rows.Add(p_Datarow1)
            'Next
            'LineTT:

            p_SQL = "select * from tblChiTietPhuongTien where MaPhuongTien ='" & p_MaPhuongTien & "'"
            p_Table = GetDataTable(p_SQL, p_SQL)
            Me.GridView1.MoveFirst()
            For p_Count = 0 To p_SoNgan - 1
                If p_Count + 1 < 10 Then
                    p_Ngan = "00" & p_Count + 1
                Else
                    p_Ngan = "0" & p_Count + 1
                End If
                p_RowArr = p_Table.Select("MaPhuongTien ='" & p_MaPhuongTien & _
                                                "' and   MaNgan='" & p_Ngan & "'")
                If p_RowArr.Length <= 0 Then
                    Me.GridView1.AddNewRow()
                    Me.GridView1.SetFocusedRowCellValue("MaPhuongTien", p_MaPhuongTien)
                    Me.GridView1.SetFocusedRowCellValue("SoLuongMax", 1000 * (p_Count + 1))
                    Me.GridView1.SetFocusedRowCellValue("MaNgan", p_Ngan)
                    'p_RowArr = p_DataTableOld.Select("MaPhuongTien='" & p_MaPhuongTien & "' and MaNgan='" & p_Ngan & "'")
                    'If p_RowArr.Length > 0 Then
                    '    Me.GridView1.SetFocusedRowCellValue("CHECKUPD", "")
                    'Else
                    Me.GridView1.SetFocusedRowCellValue("CHECKUPD", "I")
                    ' End If
                    Me.GridView1.SetFocusedRowCellValue("Status", "S")

                Else
                    p_Value = 0
                    Try
                        Integer.TryParse(Me.GridView1.GetRowCellValue(p_Count, "SoLuongMax").ToString.Trim, p_Value)
                    Catch ex As Exception

                    End Try

                    If p_Value <> p_RowArr(0).Item("SoLuongMax") Then

                        Me.GridView1.SetFocusedRowCellValue("CHECKUPD", "R")
                    End If

                End If

                ' Me.GridView1.MoveNext()
            Next

Line_KT:
            Me.GridView1.MoveFirst()
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub SoNgan_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoNgan.EditValueChanged

    End Sub

    Private Sub SoNgan_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SoNgan.Validating
        GetDetail()
    End Sub

    Private Sub CmdSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'tsbSave_Click(Nothing, Nothing)

        Dim l_dt_vehicle As New DataTable("Table01")
        Dim p_Table As DataTable
        Dim l_dr_vehicle As DataRow
        Dim p_DataRow As DataRow
        Dim l_number, l_type As String
        Dim p_SQL As String = ""
        Dim p_SyncMaster As New SynMaster.Class1(g_WCF, g_Services, flag, lw_mess, isGetAll, _
                 g_dt, _SapConnectionString, _WareHouse, _dtVariable, g_Company_Code, _ShPoint)


        If Me.FormStatus = True Then
            ShowMessageBox("", "Bản ghi chưa được lưu")
            Exit Sub
        End If
        l_number = Me.MaPhuongTien.EditValue.ToString.Trim

        p_SQL = "select 1 as STT from tblphuongtien where Maphuongtien='" & l_number & "' and ISNULL(Status,'N')='S'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                ShowMessageBox("", "Phương tiện này đã được đồng bộ lên SAP")
                Exit Sub
            End If
        End If
        If MsgBox("Bạn có chắc chắn muốn đồng bộ lên SAP không?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Chú ý") = MsgBoxResult.No Then
            Exit Sub
        End If

        l_dt_vehicle.Columns.Add("MaNgan")
        l_dt_vehicle.Columns.Add("SoLuongMax")

        For i As Integer = 0 To Me.GridView1.RowCount - 1
            p_DataRow = Me.GridView1.GetDataRow(i)
            If Not p_DataRow Is Nothing Then
                If p_DataRow.Item("SoLuongMax").ToString.Trim <> "" Then
                    l_dr_vehicle = l_dt_vehicle.NewRow()
                    l_dr_vehicle.Item(0) = p_DataRow.Item("MaNgan").ToString.Trim
                    l_dr_vehicle.Item(1) = p_DataRow.Item("SoLuongMax").ToString.Trim
                    l_dt_vehicle.Rows.Add(l_dr_vehicle)
                End If

            End If

        Next

        If l_dt_vehicle.Rows.Count > 0 Then


            l_type = Me.TuType.EditValue.ToString.Trim
            If p_SyncMaster.cldSyncMaster_SyncVehicleUp(l_number, l_type, l_dt_vehicle) Then
                'mdlMessage_SendMessage(True, "m037", Nothing)
                'mdlVehicle_UpdateStatus(l_number.ToUpper(), "S")
                ' g_err = String.Empty
                ShowMessageBox("", "Đồng bộ thành công", 0)
                Me.DefaultFormLoad = True
                XtraForm1_Load()
                Me.DefaultFormLoad = False
            Else
                ShowMessageBox("", "Lỗi khi đồng bộ phương tiện lên SAP")
            End If
        End If

    End Sub

    Sub DongBoLenSapNew()

        'tsbSave_Click(Nothing, Nothing)
        Dim p_ECCDestinationConfig As ECCDestination.ECCDestinationConfig

        Dim l_dt_vehicle As New DataTable("Table01")
        Dim p_Table_H, p_Table_L As DataTable
        Dim l_dr_vehicle As DataRow
        Dim p_DataRow As DataRow
        Dim p_Dataset As DataSet
        Dim l_number, l_type, p_Error As String
        Dim p_SQL As String = ""
        Dim p_SyncMaster As New SynMaster.Class1(g_WCF, g_Services, flag, lw_mess, isGetAll, _
                 g_dt, _SapConnectionString, _WareHouse, _dtVariable, g_Company_Code, _ShPoint)


        If Me.FormStatus = True Then
            ShowMessageBox("", "Bản ghi chưa được lưu")
            Exit Sub
        End If
        l_number = Me.MaPhuongTien.EditValue.ToString.Trim

        
        If MsgBox("Bạn có chắc chắn muốn đồng bộ lên SAP không?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Chú ý") = MsgBoxResult.No Then
            Exit Sub
        End If

        If g_Company_Code = "6610" Then
            p_SQL = "SELECT  [MaPhuongTien],substring([LaiXe],1,2) as LaiXe ,[TuText] ,[SoNgan]," & _
                     "convert(nvarchar(20), [NgayBatDau2] ,112)  as [NgayBatDau] , convert(nvarchar(20), [NgayHieuLuc2] ,112)   as NgayHetHieuLuc" & _
                      ",[CHECKUPD],[iweight],[REG_NO]" & _
                      ", (select top 1 HoVaTen from tblPhuongTien_LaiXe abc where MaPhuongTien  =aa.[MaPhuongTien] " & _
                     " and convert(date,getdate())  > =  convert(date,isnull(FromDate,getdate()-1)) and " & _
                     " convert(date,getdate())  < =  convert(date,isnull(ToDate ,getdate()+1))) as DIRVER " & _
                  " FROM [dbo].[FPT_tblPhuongTien_V1] aa where MaPhuongTien ='" & l_number & "';"

        Else
            p_SQL = "SELECT  [MaPhuongTien],substring([LaiXe],1,2) as LaiXe ,[TuText] ,[SoNgan] ," & _
                        "convert(nvarchar(20), [NgayBatDau1] ,112)  as [NgayBatDau] , convert(nvarchar(20), [NgayHieuLuc1] ,112)   as NgayHetHieuLuc" & _
                          ",[CHECKUPD],[iweight] ,[REG_NO]" & _
                          ", (select top 1 HoVaTen from tblPhuongTien_LaiXe abc where MaPhuongTien  =aa.[MaPhuongTien] " & _
                     " and convert(date,getdate())  > =  convert(date,isnull(FromDate,getdate()-1)) and " & _
                     " convert(date,getdate())  < =  convert(date,isnull(ToDate ,getdate()+1))) as DIRVER " & _
                      "FROM [dbo].[FPT_tblPhuongTien_V1] aa where MaPhuongTien ='" & l_number & "';"
        End If
        p_SQL = p_SQL & "SELECT [MaNgan]  ,[MaPhuongTien],[SoLuongMax],[Status] ,[SyncDate], convert(decimal(13,4) ,[LTT_CM]) as LTT_CM " & _
            ",convert(int,[NHAP_MM]) as NHAP_MM, convert(int,[DUONGSINH]) as DUONGSINH  FROM [dbo].[tblChiTietPhuongTien] where MaPhuongTien ='" & l_number & "';"

        p_Dataset = GetDataSet(p_SQL, p_SQL)
        If Not p_Dataset Is Nothing Then
            If p_Dataset.Tables.Count > 0 Then
                p_Table_H = p_Dataset.Tables(0)
                p_Table_L = p_Dataset.Tables(1)
                If p_Table_H.Rows.Count > 0 And p_Table_L.Rows.Count > 0 Then
                    p_ECCDestinationConfig = New ECCDestination.ECCDestinationConfig(_SapConnectionString, "EN", "60", g_Company_Code)
                    p_Error = ""
                    p_ECCDestinationConfig.clsPost_PhuongTien(p_Table_H, p_Table_L, p_Error)
                    If p_Error <> "" Then
                        ShowMessageBox("", "Lỗi khi đồng bộ phương tiện lên SAP: " & p_Error)
                    Else
                        ShowMessageBox("", "Đồng bộ thành công", 0)
                    End If
                    Exit Sub
                Else
                    ShowMessageBox("", "Lỗi khi đồng bộ phương tiện lên SAP")
                End If
            End If

        End If
        'If l_dt_vehicle.Rows.Count > 0 Then


        '    l_type = Me.TuType.EditValue.ToString.Trim
        '    If p_SyncMaster.cldSyncMaster_SyncVehicleUp(l_number, l_type, l_dt_vehicle) Then
        '        'mdlMessage_SendMessage(True, "m037", Nothing)
        '        'mdlVehicle_UpdateStatus(l_number.ToUpper(), "S")
        '        ' g_err = String.Empty
        '        ShowMessageBox("", "Đồng bộ thành công", 0)
        '        Me.DefaultFormLoad = True
        '        XtraForm1_Load()
        '        Me.DefaultFormLoad = False
        '    Else
        '        ShowMessageBox("", "Lỗi khi đồng bộ phương tiện lên SAP")
        '    End If
        'End If

    End Sub


    'Sub DongBoLenSap()

    '    'tsbSave_Click(Nothing, Nothing)

    '    Dim l_dt_vehicle As New DataTable("Table01")
    '    Dim p_Table As DataTable
    '    Dim l_dr_vehicle As DataRow
    '    Dim p_DataRow As DataRow
    '    Dim l_number, l_type As String
    '    Dim p_SQL As String = ""
    '    Dim p_SyncMaster As New SynMaster.Class1(g_WCF, g_Services, flag, lw_mess, isGetAll, _
    '             g_dt, _SapConnectionString, _WareHouse, _dtVariable, g_Company_Code, _ShPoint)


    '    If Me.FormStatus = True Then
    '        ShowMessageBox("", "Bản ghi chưa được lưu")
    '        Exit Sub
    '    End If
    '    l_number = Me.MaPhuongTien.EditValue.ToString.Trim

    '    p_SQL = "select 1 as STT from tblphuongtien where Maphuongtien='" & l_number & "' and ISNULL(Status,'N')='S'"
    '    p_Table = GetDataTable(p_SQL, p_SQL)
    '    If Not p_Table Is Nothing Then
    '        If p_Table.Rows.Count > 0 Then
    '            ShowMessageBox("", "Phương tiện này đã được đồng bộ lên SAP")
    '            Exit Sub
    '        End If
    '    End If
    '    If MsgBox("Bạn có chắc chắn muốn đồng bộ lên SAP không?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Chú ý") = MsgBoxResult.No Then
    '        Exit Sub
    '    End If

    '    l_dt_vehicle.Columns.Add("MaNgan")
    '    l_dt_vehicle.Columns.Add("SoLuongMax")

    '    For i As Integer = 0 To Me.GridView1.RowCount - 1
    '        p_DataRow = Me.GridView1.GetDataRow(i)
    '        If Not p_DataRow Is Nothing Then
    '            If p_DataRow.Item("SoLuongMax").ToString.Trim <> "" Then
    '                l_dr_vehicle = l_dt_vehicle.NewRow()
    '                l_dr_vehicle.Item(0) = p_DataRow.Item("MaNgan").ToString.Trim
    '                l_dr_vehicle.Item(1) = p_DataRow.Item("SoLuongMax").ToString.Trim
    '                l_dt_vehicle.Rows.Add(l_dr_vehicle)
    '            End If

    '        End If

    '    Next

    '    If l_dt_vehicle.Rows.Count > 0 Then


    '        l_type = Me.TuType.EditValue.ToString.Trim
    '        If p_SyncMaster.cldSyncMaster_SyncVehicleUp(l_number, l_type, l_dt_vehicle) Then
    '            'mdlMessage_SendMessage(True, "m037", Nothing)
    '            'mdlVehicle_UpdateStatus(l_number.ToUpper(), "S")
    '            ' g_err = String.Empty
    '            ShowMessageBox("", "Đồng bộ thành công", 0)
    '            Me.DefaultFormLoad = True
    '            XtraForm1_Load()
    '            Me.DefaultFormLoad = False
    '        Else
    '            ShowMessageBox("", "Lỗi khi đồng bộ phương tiện lên SAP")
    '        End If
    '    End If

    'End Sub
    Private Sub MaPhuongTien_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaPhuongTien.EditValueChanged

    End Sub

    Private Sub MaPhuongTien_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MaPhuongTien.KeyPress
        If Asc(e.KeyChar) = 32 Then
            e.Handled = True
        End If
    End Sub

    


    Sub BoSungThongTin()
        If Me.FormStatus = True Then
            ShowMessageBox("", "Đề nghị lưu lại trước khi thực hiện")
            Exit Sub
        End If


        ' Dim p_DataRow As DataRow
        Dim p_PhuongTien As String = ""
        If Not Me.MaPhuongTien.EditValue Is Nothing Then
            p_PhuongTien = Me.MaPhuongTien.EditValue.ToString
        End If
        'If Me.GridView1.RowCount > 0 Then
        '    p_DataRow = Me.GridView1.GetFocusedDataRow
        '    If Not p_DataRow Is Nothing Then
        '        If p_DataRow.Item(Me.GridView1.ColumnKey).ToString.Trim <> "" Then
        'Dim FrmMenu As New FrmORDR
        Dim FrmVehicleTmp As New FrmVehicleInfor
        FrmVehicleTmp.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmVehicleTmp.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
        ' FrmVehicleTmp.g_FormAddnew = False
        FrmVehicleTmp.FormStatus = False
        FrmVehicleTmp.p_XtraToolTripLabel = g_ToolStripStatus
        FrmVehicleTmp.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmVehicleTmp.p_XtraMessageStatusl = g_MessageStatus
        FrmVehicleTmp.g_MaPhuongTien = p_PhuongTien
        FrmVehicleTmp.GridView1.Where = "  MaPhuongTien=N'" & p_PhuongTien & "'"
        FrmVehicleTmp.GridView2.Where = "  MaPhuongTien=N'" & p_PhuongTien & "'"
        FrmVehicleTmp.ShowDialog(Me)
        '        End If
        '    End If
        'End If
    End Sub
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SaveRecode()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        BoSungThongTin()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        DongBoLenSapNew()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim p_MaPhuongTien As String = ""
        Dim p_LoaiXuat As String = ""
        If Me.FormStatus = True Then
            ShowMessageBox("", "Đề nghị lưu lại trước khi thực hiện")
            Exit Sub
        End If

        If Not Me.MaPhuongTien.EditValue Is Nothing Then
            p_MaPhuongTien = Me.MaPhuongTien.EditValue.ToString.Trim
        End If
        If p_MaPhuongTien = "" Then
            ShowMessageBox("", "Không xác định Mã phương tiện")
            Exit Sub
        End If

        If Not Me.TuType.EditValue Is Nothing Then
            p_LoaiXuat = Me.TuType.EditValue.ToString.Trim
            p_LoaiXuat = Mid(p_LoaiXuat, 1, 2)
        End If
        'p_LoaiXuat = loa
        Dim p_Form As New FrmVehicle_TaiTrong

        p_Form.p_MaPhuongTien = p_MaPhuongTien
        p_Form.p_XtraModuleObj = p_XtraModuleObj
        p_Form.g_XtraServicesObj = g_XtraServicesObj
        p_Form.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        Dim p_PTien As String = ""
        Dim p_Form As New FrmVehicleHist

        If Me.FormStatus = True Then
            ShowMessageBox("", "Phương tiện chưa được Lưu")
            Exit Sub
        End If
        If Not Me.MaPhuongTien.EditValue Is Nothing Then
            p_PTien = Me.MaPhuongTien.EditValue.ToString.Trim
        End If
        p_Form.g_XtraServicesObj = g_XtraServicesObj
        p_Form.p_XtraModuleObj = p_XtraModuleObj
        p_Form.SoPhuongTien = p_PTien
        p_Form.ShowDialog()
    End Sub
End Class