Public Class FrmVehicleInfor 
    Public g_MaPhuongTien As String = ""

    Private Sub FrmVehicleInfor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            SaveRecord()
        End If
    End Sub

    Private Sub FrmVehicleInfor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_Col As U_TextBox.GridColumn

        If g_Company_Code = "6610" Then
            Me.GridView1.ViewName = "FPT_tblPhuongTien_Infor_V2"
            p_Col = Me.GridView1.Columns.Item(7)
            p_Col.FieldView = "UpdUser"
            p_Col = Me.GridView1.Columns.Item(8)
            p_Col.FieldView = "UpdDate"

            Me.GridView2.ViewName = "FPT_tblPhuongTien_LaiXe_V2"
            p_Col = Me.GridView2.Columns.Item(10)
            p_Col.FieldView = "UpdUser"
            p_Col = Me.GridView2.Columns.Item(11)
            p_Col.FieldView = "UpdDate"

        Else
            Me.GridView1.Columns.Item(7).Visible = False
            Me.GridView1.Columns.Item(8).Visible = False

            Me.GridView2.Columns.Item(10).Visible = False
            Me.GridView2.Columns.Item(11).Visible = False


        End If

        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False
        Me.txtPhuongTien.EditValue = g_MaPhuongTien
        If g_Company_Code = "6610" Then
            'Else
            Me.GridView1.Columns.Item("sType").Visible = False
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        SaveRecord()
    End Sub

    Private Sub SaveRecord()
        Me.DefaultSave = True
        Me.UpdateToDatabase(Me, Nothing)
        Me.DefaultSave = False
    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub

    Private Sub GridView1_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView1.ValidateRow
        If g_Company_Code = "6610" Then
            Dim p_Tbl As DataTable
            Dim p_SQL As String
            p_SQL = "select Getdate() as nDateTime"
            p_Tbl = GetDataTable(p_SQL, p_SQL)

            Me.GridView1.SetFocusedRowCellValue("UpdUser", g_UserName)
            If Not p_Tbl Is Nothing Then
                If p_Tbl.Rows.Count > 0 Then
                    Me.GridView1.SetFocusedRowCellValue("UpdDate", p_Tbl.Rows(0).Item(0))
                End If
            End If

        End If
    End Sub

    Private Sub GridView2_ValidateRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GridView2.ValidateRow
        If g_Company_Code = "6610" Then
            Dim p_Tbl As DataTable
            Dim p_SQL As String
            p_SQL = "select Getdate() as nDateTime"
            p_Tbl = GetDataTable(p_SQL, p_SQL)

            Me.GridView2.SetFocusedRowCellValue("UpdUser", g_UserName)
            If Not p_Tbl Is Nothing Then
                If p_Tbl.Rows.Count > 0 Then
                    Me.GridView2.SetFocusedRowCellValue("UpdDate", p_Tbl.Rows(0).Item(0))
                End If
            End If

        End If
    End Sub

End Class