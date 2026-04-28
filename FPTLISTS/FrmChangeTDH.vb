Public Class FrmChangeTDH

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub FrmChangeTDH_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String = "select max(NgayXuat) as NgayXuat from tbllenhxuate5"
        Dim p_Table As DataTable
        p_Table = GetDataTable(p_SQL, p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                Me.NgayXuat.EditValue = p_Table.Rows(0).Item(0)
            End If
        End If
    End Sub

    Private Sub U_ButtonCus1_Click(sender As System.Object, e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_Value As Integer = 0
        Dim p_SQL As String = ""
        Dim p_table As DataTable
        Dim p_NgayXuat As Date
        Dim p_Max As Integer = 0
        Try
            If Not Me.U_NumericEdit1.EditValue Is Nothing Then
                Integer.TryParse(Me.U_NumericEdit1.EditValue.ToString.Trim, p_Value)
            End If
        Catch ex As Exception

        End Try

        If Me.NgayXuat Is Nothing Then
            ShowMessageBox("", "Ngày tháng không hợp lệ")
            Exit Sub
        End If
        p_NgayXuat = Me.NgayXuat.EditValue

        If p_Value <= 0 Then
            ShowMessageBox("", "Giá trị không hợp lệ")
            Exit Sub
        End If
        p_SQL = "truncate table SYS_TABLEID; DBCC CHECKIDENT ('SYS_TABLEID', RESEED, " & p_Value & ")"
        p_table = GetDataTable(p_SQL, p_SQL)
        p_SQL = "INSERT INTO SYS_TABLEID  (CrdDate) VALUES ('" & CDate(p_NgayXuat).ToString("MM-dd-yyyy") & "') "
        p_table = GetDataTable(p_SQL, p_SQL)

        p_SQL = "SELECT Max( [ID])  from  [SYS_TABLEID_NEW_TMP] "
        p_table = GetDataTable(p_SQL, p_SQL)
        If Not p_table Is Nothing Then
            If p_table.Rows.Count > 0 Then
                Integer.TryParse(p_table.Rows(0).Item(0).ToString.Trim, p_Max)
            End If
        End If
        If p_Max = 0 Then
            p_Max = 2000
        End If
        p_Max = p_Max + 1
        p_SQL = "DBCC CHECKIDENT ('SYS_TABLEID_NEW', RESEED, " & p_Max & ");  insert into [SYS_TABLEID_NEW_TMP] (CrdDate , ID ) VALUES (convert(date,getdate()), " & p_Max & ")"
        p_table = GetDataTable(p_SQL, p_SQL)

        ShowMessageBox("", "Đã thực hiện xong", 1)

    End Sub
End Class