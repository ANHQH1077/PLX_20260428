Public Class Class1

    Public Sub New(ByVal p_Services As Object)
        g_Services = p_Services
    End Sub

    Public Sub clsLoadDefault(ByVal p_dt_vehicle As System.Data.DataTable, ByVal p_PhuongTien As String, ByVal p_TableHangHoa As System.Data.DataTable, _
                            ByRef p_TableReturn As System.Data.DataTable, ByVal p_LoaiXuat As String)
        LoadDefault(p_dt_vehicle, p_PhuongTien, p_TableHangHoa, p_TableReturn, p_LoaiXuat)
    End Sub
End Class
