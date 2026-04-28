Public Class FrmSoLenhAutoDate

    Public g_NgayXuat As Date
    Public g_Done As Boolean = False
    Private Sub FrmSoLenhAutoDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String
        Dim p_Table, p_Table1 As DataTable
        Dim p_Int As Integer = 1
        Dim p_DataSet As DataSet


        
        p_SQL = " select KeyValue from sys_Config where upper(KeyCode) =upper('NgayXuatAdd')"
        p_Table1 = GetDataTable(p_SQL, p_SQL)
        If Not p_Table1 Is Nothing Then
            If p_Table1.Rows.Count > 0 Then
                Integer.TryParse(p_Table1.Rows(0).Item(0).ToString.Trim, p_Int)
            End If
        End If
        If p_Int = 0 Then
            p_Int = 1
        End If

        p_SQL = "select convert(date,getdate()  ) as dFromDate, convert(date,dateadd (day ," & p_Int & ",getdate() ) ) as dDate"
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                Me.NgayXuat.Properties.MaxValue = CDate(p_Table.Rows(0).Item(1))
                Me.NgayXuat.Properties.MinValue = CDate(p_Table.Rows(0).Item(0))
            End If
        End If

    End Sub


    Private Sub U_ButtonCus1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles U_ButtonCus1.Click

        Dim p_ValueMess As Windows.Forms.DialogResult
        If Not Me.NgayXuat.EditValue Is Nothing Then
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

            g_NgayXuat = CDate(Me.NgayXuat.EditValue)
            g_Done = True
            Me.Close()
        Else
            ShowMessageBox("", "Ngày xuất chưa nhập")
        End If

       
    End Sub
End Class