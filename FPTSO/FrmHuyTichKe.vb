Public Class FrmHuyTichKe 

    Public p_SoLenh As String = ""
    Private Sub FrmHuyTichKe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        ' Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_DataTable As DataTable
      
        Me.SoTichKe.Focus()
        p_SQL = "select Convert(date,Getdate()) as dDate "
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Me.NgayXuat.EditValue = CDate(p_DataTable.Rows(0).Item(0))
            End If
        End If
    End Sub

    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_SQL As String = ""
        Dim p_TichKe As String = ""
        Dim p_NgayThang As String = ""
        Dim p_Datatable As DataTable
        If Not Me.SoTichKe.EditValue Is Nothing Then
            p_TichKe = Me.SoTichKe.EditValue.ToString.Trim
        End If
        If Not Me.NgayXuat.EditValue Is Nothing Then
            p_NgayThang = CDate(Me.NgayXuat.EditValue).ToString("yyyyMMdd")
        End If
        If p_TichKe = "" Or p_NgayThang = "" Then
            ' ShowMessageBox("", "Bạn chưa nhập đủ thông tin")
            MsgBox("Bạn chưa nhập đủ thông tin")
            Exit Sub
        End If
        p_SoLenh = ""
        p_SQL = "Select SoLenh from tblTichKe where NgayTichKe='" & p_NgayThang & "' and SoTichKe ='" & p_TichKe & "'"
        p_Datatable = GetDataTable(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_SoLenh = p_Datatable.Rows(0).Item(0).ToString.Trim
            End If
        End If
        If p_SoLenh = "" Then
            MsgBox("Lệnh xuất không xác định")
            Exit Sub
        End If
        Me.Close()
    End Sub
End Class