Public Class FrmTankActive_Hist

    Private Sub cmdTimKiem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimKiem.Click
        Dim p_SQL As String = ""
        Dim p_Value As String
        Dim p_date As Date
        p_Value = ""
        If Not Me.NgayThang.EditValue Is Nothing Then
            If Me.NgayThang.EditValue.ToString.Trim <> "" Then
                p_date = CDate(Me.NgayThang.EditValue)
                p_Value = p_date.ToString("dd") & "/" & p_date.ToString("MM") & "/" & p_date.ToString("yyyy")
            End If

        End If
        If p_Value <> "" Then
            p_SQL = "Date_nd='" & p_Value & "'"
        End If

        p_Value = ""
        If Not Me.BeXuat.EditValue Is Nothing Then
            If Me.BeXuat.EditValue.ToString.Trim <> "" Then
                p_Value = BeXuat.EditValue.ToString.Trim
            End If
        End If

        If p_Value <> "" Then
            If p_SQL = "" Then
                p_SQL = "Name_nd='" & p_Value & "'"
            Else
                p_SQL = p_SQL & " and Name_nd='" & p_Value & "'"
            End If
        End If

        If p_SQL = "" Then
            ShowMessageBox("", "Giá trị tìm kiếm chưa nhập")
            Exit Sub
        End If
        Me.GridView1.Where = p_SQL
        Me.XtraForm1_Load()
    End Sub

    Private Sub FrmTankActive_Hist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        p_XtraUserName = g_User_ID
    End Sub
End Class