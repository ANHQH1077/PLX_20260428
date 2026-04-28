'Don vi
Public Class BSQci


    Public Function getQci(ByVal sql As String, ByRef err As String) As DataTable
        '_c2SQL = New Connect2SQL.Connect2SQL(_SQLConnectionString)
        'Try
        '    If sql = "" Then
        '        getQci = _c2SQL.getTableValue("select * from tblQci")
        '    Else
        '        getQci = _c2SQL.getTableValue(sql)
        '    End If
        'Catch ex As Exception
        '    getQci = Nothing
        '    err = ex.Message
        'End Try
    End Function

    Public Function InsertQci(ByRef err As String, ByVal i_malenh As String, ByVal i_ngayxuat As Date, ByVal i_solenh As String, ByVal i_mangan As String, ByVal i_L As Decimal, ByVal i_L15 As Decimal, ByVal i_M15 As Decimal, ByVal i_KG As Decimal) As Boolean
        '_c2SQL = New Connect2SQL.Connect2SQL(_SQLConnectionString)
        'InsertQci = _c2SQL.ExeNonQuery("crud_tblQciInsert", CommandType.StoredProcedure, err, _
        'New SqlParameter("@MaLenh", i_malenh), _
        'New SqlParameter("@NgayXuat", i_ngayxuat), _
        'New SqlParameter("@SoLenh", i_solenh), _
        'New SqlParameter("@MaNgan", i_mangan), _
        'New SqlParameter("@L", i_L), _
        'New SqlParameter("@KG", i_KG), _
        'New SqlParameter("@L15", i_L15), _
        'New SqlParameter("@M15", i_M15))
    End Function


    Public Function UpdateQci(ByRef err As String, ByVal i_solenh As String, ByVal i_mangan As String, ByVal i_L As Decimal, ByVal i_L15 As Decimal, ByVal i_M15 As Decimal, ByVal i_KG As Decimal) As Boolean

        'Dim p_SQL As String = ""
        'p_SQL = "UPDATE [tblQci] SET  [L] = " & i_L & ", [KG] =" & i_KG & ",  [L15] = " & i_L15 & ", [M15] = " & i_M15 & " " & _
        '            " WHERE    [SoLenh]= @SoLenh and    [LineId]= @LineId and    [MaNgan]= @MaNgan"
        'If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then

        'End If

    End Function

    Public Function InsertQci(ByRef err As String, _
                              ByVal i_malenh As String, _
                              ByVal i_ngayxuat As Date, _
                              ByVal i_lineid As String, _
                              ByVal i_solenh As String, _
                              ByVal i_mangan As String, _
                              ByVal i_L As Decimal, _
                              ByVal i_L15 As Decimal, _
                              ByVal i_M15 As Decimal, _
                              ByVal i_KG As Decimal) As Boolean

        Dim p_SQL As String = ""
        p_SQL = "INSERT INTO [tblQci] ( [MaLenh], [NgayXuat],[LineId],[SoLenh],[MaNgan],[L],[KG],[L15],[M15]) "
        p_SQL = p_SQL & " VALUES('" & i_malenh & "','" & CDate(i_ngayxuat).ToString("yyyyMMdd") & "','" & i_lineid & "'" & _
                ",'" & i_solenh & "','" & i_mangan & "'," & i_L & "," & i_KG & "," & i_L15 & "," & i_M15 & ")"

        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function UpdateQci(ByRef err As String, _
                              ByVal i_solenh As String, _
                              ByVal i_mangan As String, _
                              ByVal i_lineid As String, _
                              ByVal i_L As Decimal, _
                              ByVal i_L15 As Decimal, _
                              ByVal i_M15 As Decimal, _
                              ByVal i_KG As Decimal) As Boolean
       Dim p_SQL As String = ""
        p_SQL = "UPDATE [tblQci] SET  [L] = " & i_L & ", [KG] =" & i_KG & ",  [L15] = " & i_L15 & ", [M15] = " & i_M15 & " " & _
                    " WHERE    [SoLenh]= '" & i_solenh & "' and    [LineId]='" & i_lineid & "' and    [MaNgan]= '" & i_mangan & "'"
        If g_Services.Sys_Execute(p_SQL, p_SQL) = False Then
            Return False
        Else
            Return True
        End If
    End Function

End Class
