Module Module2
    'Ham thuc hien keim tra neu la hang hoa day sang Scada2 thi tra ve Y neu khong tra ve N. Loi tra ve E
    Public Function CheckItemToScada2(ByVal p_Item As String) As String
        Dim p_DataRow() As DataRow
        CheckItemToScada2 = "N"
        Try
            If Not g_HangHoaToScada2 Is Nothing Then
                If g_HangHoaToScada2.Rows.Count > 0 Then
                    p_DataRow = g_HangHoaToScada2.Select("MaHangHoa='" & p_Item.ToString.Trim & "'")
                    If p_DataRow.Length > 0 Then
                        CheckItemToScada2 = "Y"
                    End If
                End If
            End If
        Catch ex As Exception
            CheckItemToScada2 = "E"
        End Try

    End Function



    Public Function Get_HoaDon_ChiTietNew(ByVal i_SoLenh As String) As DataTable
        Dim err As String = String.Empty
        Dim DtTable As DataTable
        Dim p_SQL As String
        Try
            p_SQL = "exec FPT_HoaDon_ChiTietE5 '" & i_SoLenh & "'"
            DtTable = GetDataTable(p_SQL, p_SQL)



            'anhqh
            '20180110
            'Bo di vi dưới Procedure đã tính rôi
            ' DtTable = Alter_table_HoaDon(DtTable)
            Return DtTable
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function Get_ThoiGianDau(ByVal p_SoLenh As String) As DateTime
        Get_ThoiGianDau = Now
        Dim p_DataTable As DataTable
        Dim p_SQL As String
        p_SQL = "select min(isnull( ThoiGianDau,getdate())) as ThoiGianDau from fpt_tbllenhxuatchitiete5_v where solenh='" & p_SoLenh & "'"

        p_DataTable = GetDataTable(p_SQL, p_SQL)
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Try
                    Get_ThoiGianDau = p_DataTable.Rows(0).Item(0)
                Catch ex As Exception
                    ' Get_ThoiGianDau = p_DataTable.Rows(0).Item(0)
                End Try

            End If
        End If
    End Function


    Public Sub p_GetCurrentDate(ByRef p_Date As DateTime)
        Dim p_SQL As String
        Dim p_Datatable As New DataTable
        p_SQL = "select  getdate() as SysDate"
        ' p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                p_Date = p_Datatable.Rows(0).Item("SysDate")

            End If
        End If
        p_Datatable = Nothing
    End Sub

End Module
