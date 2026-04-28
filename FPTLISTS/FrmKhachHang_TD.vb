Public Class FrmKhachHang_TD
    Private p_MaKhachHang As String = ""
    Public Property P_MaKhachHangProperty As String
        Get
            Return p_MaKhachHang
        End Get
        Set(ByVal value As String)
            If p_MaKhachHang = Value Then
                Return
            End If
            p_MaKhachHang = Value
        End Set
    End Property
    Private Sub FrmKhachHang_TD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        Dim p_Table As DataTable
        p_SQL = "select CHECK_TD from tblKhachHang where MaKhachHang='" & p_MaKhachHang & "'"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("CHECK_TD").ToString.Trim = "Y" Then
                    Me.U_CheckBox1.Checked = True
                End If
            End If
        End If
        Me.txtMaKhachHang.EditValue = p_MaKhachHang
        Me.Text = p_MaKhachHang
        Me.GridView1.Where = "MaKhachHang='" & p_MaKhachHang & "'"
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim p_SQL As String
        If Me.U_CheckBox1.Checked = True Then
            p_SQL = "update tblKhachHang set Check_TD ='Y' where MaKhachHang ='" & p_MaKhachHang & "'"
        Else
            p_SQL = "update tblKhachHang set Check_TD ='N' where MaKhachHang ='" & p_MaKhachHang & "'"

        End If
        If g_Services.Sys_Execute(p_SQL, _
                                             p_SQL) = False Then
            ShowMessageBox("", p_SQL)

        End If
        If Me.FormStatus = True Then
            Me.DefaultSave = True
            Me.UpdateToDatabase(Me)
        End If
    End Sub




End Class