Imports System.ComponentModel
Imports DevExpress.XtraEditors.Controls

Public Class FrmReportCancel1
    Private p_BindingSource As New U_TextBox.U_BindingSource
    Private p_DataTable As DataTable
    Private p_StrColumn As String = "select distinct  SoBienban , convert(nvarchar (10),CreateDate, 103) as CreateDate " &
                                " from tblBienBanGiaoNhan_Hist  h  with (Nolock) where sStatus ='I' " &
                                " And Convert( Date, CreateDate) >= Convert( Date, getdate() - 1) " &
                                " and not exists  (select 1 from ( " &
                                " Select SoBienban from tblBienBanGiaoNhan_Hist  h with (nolock) where sStatus ='C' " &
                                " And convert(date,cancelDate) >=convert(date,getdate() -1) ) aa  where h.SoBienban =aa.SoBienban ) " &
                                " and charindex(Client,(select Terminal from sys_user  where upper( User_Name ) =upper('" & g_UserName & "')	),1) >0 "

    Private Sub FrmReportCancel_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.SoBBGN.SqlString = p_StrColumn

        Getdata()

    End Sub

    Private Sub Getdata()
        Dim p_SQL As String = ""
        Dim p_SoBienBan As String = ""
        Dim tbl_Test As DataTable
        If Not Me.SoBBGN.EditValue Is Nothing Then
            p_SoBienBan = Me.SoBBGN.EditValue.ToString.Trim
        End If

        ' If p_SoBienBan = "" Then
        'p_SQL = "Select SoLenh, NgayXuat, TenKhachHang, MaPhuongTien ,'" & p_SoBienBan & "' as SoBienBan from fpt_tbllenhxuate5_v where 1=0 "
        'p_SQL = "Select SoLenh, NgayXuat, TenKhachHang, MaPhuongTien  ,'" & p_SoBienBan & "' as SoBienBan from fpt_tbllenhxuate5_v a " &
        '                " where SoLenh  In (Select SoLenh from tblTichKe u With (nolock) where a.SoLenh =u.SoLenh " &
        '                    " And SoBienBan = '" & p_SoBienBan & "') " &
        '                    " And Not exists(select 1   from tblBienBanGiaoNhan_Hist  h with (nolock) where h.sStatus ='C' and h.SoLenh =a.SoLenh)"
        p_SQL = "Select SoLenh, NgayXuat, TenKhachHang, MaPhuongTien  ,'" & p_SoBienBan & "' as SoBienBan from fpt_tbllenhxuate5_v a  " &
                    " where SoLenh  In (Select SoLenh from tblTichKe u With (nolock) where a.SoLenh =u.SoLenh    " &
                    " And SoBienBan = '" & p_SoBienBan & "')  " &
                    " And  Not exists (Select 1 from   (Select  hhh.SoLenh from tblBienBanGiaoNhan_Hist h , tblLenhXuatE5_BienBan hhh With(nolock)  " &
                    " where h.SoBienBan ='" & p_SoBienBan & "' and h.sStatus ='C'  and h.row_ID =hhh.BienBan_ID)   abc  " &
                    " where abc.SoLenh =a.SoLenh)"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            p_BindingSource.DataSource = p_DataTable
            Me.TrueDBGrid1.DataSource = p_BindingSource
            Me.GridView1.Columns.Item(0).FieldName = p_DataTable.Columns(0).ColumnName
            Me.GridView1.Columns.Item(1).FieldName = p_DataTable.Columns(1).ColumnName
            Me.GridView1.Columns.Item(2).FieldName = p_DataTable.Columns(2).ColumnName
            Me.GridView1.Columns.Item(3).FieldName = p_DataTable.Columns(3).ColumnName
            Me.GridView1.Columns.Item(4).FieldName = p_DataTable.Columns(4).ColumnName
            Me.TrueDBGrid1.RefreshDataSource()
        End If

    End Sub


    Private Sub SoBBGN_Modified(ByVal sender As Object, ByVal e As EventArgs) Handles SoBBGN.Modified
        Getdata()
    End Sub


    Private Sub SoBBGN_Validating(ByVal sender As Object, ByVal e As CancelEventArgs) Handles SoBBGN.Validating
        Dim p_Item As U_TextBox.U_ButtonEdit
        p_Item = CType(sender, U_TextBox.U_ButtonEdit)
        If p_Item.IsModified = True Then
            Getdata()
        End If
    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles U_ButtonCus1.Click
        If Me.GridView1.RowCount <= 0 Then
            ShowMessageBox("", "Số biên bản không đúng")
            Exit Sub
        End If
        Dim p_Row As DataRow
        Dim p_SoBienBan As String = ""
        Dim p_SoLenh As String = ""
        Dim p_ValueMess As DialogResult
        Dim p_SQL As String = ""
        Dim p_DataTable As DataTable


        p_Row = GridView1.GetDataRow(0)



        If Not p_Row Is Nothing Then
            Try
                p_SoBienBan = p_Row.Item("SoBienBan").ToString.Trim
                p_SoLenh = p_Row.Item("SoLenh").ToString.Trim
            Catch ex As Exception

            End Try
        End If

        If p_SoBienBan <> "" Then

            p_ValueMess = g_Module.ShowMessage(Me, "",
                      "Bạn có chắc chắn muốn hủy số Biên bản (" & p_SoBienBan & ") không? ",
                      True,
                       "Có",
                      True,
                      "Không",
                      False,
                      "",
                       0)
            If p_ValueMess = System.Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            p_SQL = "exec  BienBanGiaoNhan_Hist '" & p_SoBienBan & "','" & p_SoLenh & "','" & g_UserName & "', '','C','" & g_Terminal & "'"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    If p_DataTable.Rows(0).Item(0) > 0 Then
                        ShowMessageBox("", p_DataTable.Rows(0).Item(1).ToString.Trim)
                        Me.SoBBGN.EditValue = ""
                    Else

                        ShowMessageBox("", p_DataTable.Rows(0).Item(1).ToString.Trim, 1)
                        Getdata()
                    End If
                End If

            End If
        End If


    End Sub
End Class