Public Class FrmTankChange

    Private Sub SimpleButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton7.Click
        Dim p_SoLenh As String = ""
        Dim p_SQL As String
        If Me.SoLenh.EditValue Is Nothing Then
            ShowMessageBox("", "Số lệnh không được trống")
            Exit Sub
        End If
        If Me.SoLenh.EditValue.ToString.Trim = "" Then
            ShowMessageBox("", "Số lệnh không được trống")
            Exit Sub
        End If
        p_SoLenh = Me.SoLenh.EditValue.ToString.Trim

        'hieptd4 add 20160729


        Me.SoLenh.EditValue = UCase(p_SoLenh)
        Me.DefaultFormLoad = True
        XtraForm1_Load()
        Me.DefaultFormLoad = False
        Me.FormStatus = False

        Me.GridView1.BestFitColumns()

    End Sub

    Private Sub FrmTankChange_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            If Me.FormStatus = True Then
                Save()
            End If
        End If
    End Sub

    Private Sub FrmTankChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_Column As U_TextBox.GridColumn
        Dim p_SQL As String

        Dim p_Date As Date
        Dim p_Time As Integer

        p_GetCurrentDate(p_Date)
        Me.CreateDate.EditValue = p_Date

        If g_Filter_Terminal = True Then
            If g_Terminal <> "" Then
               
                'select Name_nd as [Bể xuất] from FPT_tblTankActive_V where Date1=:Column.NgayXuat and Product_nd =:Column.MaHangHoa
                ' Me.GridView1.Where = "left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "'"

                p_SQL = " select Name_nd,TenHangHoa  from fpt_tblTankActive_v a where Date1=convert(date,getdate()) and Tank_App ='Y' " & _
                                         "  and  left(Name_nd,LEN ('" & g_Terminal & "')) like   '" & g_Terminal & "%'  "
                Me.TankOld.SqlString = p_SQL

                'p_SQL = " select Name_nd,TenHangHoa  from fpt_tblTankActive_v a where Date1=convert(date,getdate()) and Tank_App ='Y' " & _
                '"  and  left(Name_nd,LEN ('" & g_Terminal & "')) like   '" & g_Terminal & "%'  "
                p_SQL = "select Name_nd , (select top 1 TenHangHoa from tblHangHoa aa2 where aa2.MaHangHoa  = kk1.Product_nd ) as TenHangHoa, kk1.TankGroup from tblTankGroup  kk1 " & _
                                   " where(isnull(kk1.FromDate, Getdate() - 1) <= Getdate() And isnull(kk1.ToDate, getdate() + 1) >= getdate()) " & _
                          " and exists (select 1 from fpt_tblTankActive_v aa3 where  Date1=convert(date,getdate()) and Tank_App ='Y'  " & _
                                                " and aa3.Name_nd = kk1.Name_nd and aa3.Product_nd =kk1.Product_nd " & _
                                                " and  left(aa3.Name_nd,LEN ('" & g_Terminal & "')) like   '" & g_Terminal & "%' "
                p_SQL = p_SQL & " and aa3.Product_nd  = (select Product_nd  from tblTank aa1 where aa1.Name_nd =  :TankOld )	)"
                Me.TankNew.SqlString = p_SQL

                p_Column = Me.GridView1.Columns.Item(7)
                p_SQL = "select Name_nd as [Bể xuất] from FPT_tblTankActive_V  a where Date1=:Column.NgayTichKe and Product_nd =:Column.MaHangHoa" & _
                        " and exists (select 1 from tblTankGroup  kk1 where kk1.Name_nd = a.Name_nd  and kk1.Product_nd = a.Product_nd " & _
                         " and isnull( kk1.FromDate,Getdate()-1 ) <=Getdate() and isnull(kk1.ToDate,getdate()+1)  >= getdate()	) " & _
                        "  and  left(Name_nd,LEN ('" & g_Terminal & "')) like   '" & g_Terminal & "%'  and ( LoadingSite ='' or LoadingSite  is null  or  LoadingSite =dbo.FPT_GetLoadingSite( :Column.MaVanChuyen ) )"
                p_SQL = p_SQL & " and Name_nd  in (select Name_nd  from tblTankGroup  kk1 " & _
                                   " where kk1.TankGroup = :Column.NhomBeXuat  and (isnull(kk1.FromDate, Getdate() - 1) <= Getdate() And isnull(kk1.ToDate, getdate() + 1) >= getdate()) )"

                p_Column.SQLString = p_SQL
            End If
        End If
    End Sub

    Private Sub Save()
        Dim p_Row As DataRow
        Dim p_ArrRow() As DataRow
        Me.GridView1.RefreshData()
        Dim p_Datatable As DataTable
        Dim p_Count As Integer
        Dim p_SQL As String
        Dim p_Binding As U_TextBox.U_BindingSource
        Me.GridView1.RefreshData()
        p_Binding = Me.TrueDBGrid1.DataSource
        p_Datatable = CType(p_Binding.DataSource, DataTable)
        p_ArrRow = p_Datatable.Select("CHECKUPD='Y'")
        For p_Count = 0 To p_ArrRow.Length - 1
            p_SQL = "update  tblLenhXuatChiTietE5 set UpdatedBy ='" & g_UserName & "', UpdateDate=getdate(), TyTrong_15 = " & _
                    " (select top 1 dens_nd from FPT_tblTankActive_V  where Date1=CONVERT(date,getdate()) and Name_nd='" & p_ArrRow(p_Count).Item("BeXuat").ToString.Trim & "')  " & _
                    " where TableID IN (select TableID from tblLenhXuat_HangHoaE5 a  with  (nolock), tblLenhXuatE5 b with (Nolock) where a.SoLenh=b.SoLenh " & _
                    " and not exists (select 1 from tblHangHoaE5 where MaHangHoa=a.MaHangHoa) " & _
                        " and Status not in  ('4','5') and a.SoLenh='" & p_ArrRow(p_Count).Item("SoLenh").ToString.Trim & "') "
            p_Row = pv_LineRemove.NewRow
            p_Row.Item(0) = p_SQL
            pv_LineRemove.Rows.Add(p_Row)

        Next
        Me.DefaultSave = True
        UpdateToDatabase(Me, Me.ButtonSave)
        Me.DefaultSave = False
        Me.SoLenh.Focus()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Save()
    End Sub


    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click

        Dim p_Datatable As DataTable
        Dim p_SQL As String
        Dim p_TankOld, p_TankNew, p_NgayThang, p_NHomBe As String
      

        Dim p_ValueMess As Windows.Forms.DialogResult

        p_TankOld = ""
        p_TankNew = ""
        p_NgayThang = ""
        If Not Me.TankNew.EditValue Is Nothing Then
            p_TankNew = Me.TankNew.EditValue.ToString.Trim
        End If

        If Not Me.TankOld.EditValue Is Nothing Then
            p_TankOld = Me.TankOld.EditValue.ToString.Trim
        End If


        If Not Me.CreateDate.EditValue Is Nothing Then
            p_NgayThang = CDate(Me.CreateDate.EditValue).ToString("yyyyMMdd")
        End If

        p_NHomBe = ""
        If Not Me.NhomBe.EditValue Is Nothing Then
            p_NHomBe = Me.NhomBe.EditValue.ToString.Trim
        End If

        If p_NHomBe = "" Then
            ShowStatusMessage(True, "", "Nhóm bể không xác định", 5)
        End If

       

        If p_NHomBe = "" Then
            ShowStatusMessage(True, "", "Nhóm bể không xác định", 5)
        End If
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
            Cursor = Cursors.Default
            Exit Sub
        End If

        p_SQL = "exec  FPT_UpdateTankBatch '" & p_NgayThang & "','" & p_TankOld & "','" & p_TankNew & "','" & g_UserName & "','" & p_NHomBe & "'"
        p_Datatable = GetDataTable(p_SQL, p_SQL)

        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                If p_Datatable.Rows(0).Item(0) > 0 Then
                    ShowMessageBox("", p_Datatable.Rows(0).Item("sDesc").ToString.Trim)
                Else
                    ShowMessageBox("", p_Datatable.Rows(0).Item("sDesc").ToString.Trim, 1)

                End If

            End If
        End If
    End Sub
End Class