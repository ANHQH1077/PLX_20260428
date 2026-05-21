Public Class BSThongTinHoaDon
    'Private _c2SQL As Connect2SQL.Connect2SQL

    Public Function Select_LenhXuatKho(ByVal sql As String, ByRef err As String) As DataTable
        Dim p_SQL As String
        Try

            If sql = "" Then
                Select_LenhXuatKho = GetDataTable("select * from tblThongTinHoaDon", p_SQL)
            Else
                Select_LenhXuatKho = GetDataTable(sql, p_SQL)
            End If
        Catch ex As Exception
            Select_LenhXuatKho = Nothing
            err = ex.Message
        End Try
    End Function

    Public Function Insert_TTHoaDon(ByRef err As String, ByVal i_SoLenh As String, ByVal i_LineID As String, ByVal i_NgayXuat As Date, _
                            ByVal i_DonGia As Double, ByVal i_ThueGTGT As Double, ByVal i_TienKhac As Double, ByVal i_PhuongThuc As String) As Boolean
        ' _c2SQL = New Connect2SQL.Connect2SQL(_SQLConnectionString)
        Dim p_SQL As String

        p_SQL = "exec sp_ThongTinHoaDon_Insert '" & i_SoLenh & "','" & i_LineID & "','" & i_NgayXuat.ToString("yyyyMMdd") & "'"
        p_SQL = p_SQL & "," & i_DonGia & "," & i_ThueGTGT & "," & i_TienKhac & ",'" & i_PhuongThuc & "'"
        Insert_TTHoaDon = SQL_Execute(p_SQL, p_SQL)
        'If  = True Then

        'End If
        'Insert_TTHoaDon = _c2SQL.ExeNonQuery("sp_ThongTinHoaDon_Insert", CommandType.StoredProcedure, err, _
        'New SqlParameter("@SoLenh", i_SoLenh), New SqlParameter("@LineID", i_LineID), New SqlParameter("@NgayXuat", i_NgayXuat), _
        'New SqlParameter("@DonGia", i_DonGia), New SqlParameter("@ThueGTGT", i_ThueGTGT), New SqlParameter("@TienKhac", i_TienKhac), New SqlParameter("@PhuongThuc", i_PhuongThuc))
    End Function

    Public Function Update_TTHoaDon(ByRef err As String, ByVal i_SoLenh As String, ByVal i_LineID As String, ByVal i_NgayXuat As Date, _
                                    ByVal i_DonGia As Double, ByVal i_ThueGTGT As Double, ByVal i_TienKhac As Double, ByVal i_PhuongThuc As String) As Boolean
        '_c2SQL = New Connect2SQL.Connect2SQL(_SQLConnectionString)
        'Update_TTHoaDon = _c2SQL.ExeNonQuery("sp_ThongTinHoaDon_Update", CommandType.StoredProcedure, err, _
        'New SqlParameter("@SoLenh", i_SoLenh), New SqlParameter("@LineID", i_LineID), New SqlParameter("@NgayXuat", i_NgayXuat), _
        'New SqlParameter("@DonGia", i_DonGia), New SqlParameter("@ThueGTGT", i_ThueGTGT), New SqlParameter("@TienKhac", i_TienKhac), New SqlParameter("@PhuongThuc", i_PhuongThuc))
        Dim p_SQL As String

        p_SQL = "exec sp_ThongTinHoaDon_Update '" & i_SoLenh & "','" & i_LineID & "','" & i_NgayXuat.ToString("yyyyMMdd") & "'"
        p_SQL = p_SQL & "," & i_DonGia & "," & i_ThueGTGT & "," & i_TienKhac & ",'" & i_PhuongThuc & "'"
        Update_TTHoaDon = SQL_Execute(p_SQL, p_SQL)
    End Function

    Public Function Select_LenhXuatKho_ByMa(ByVal i_connectionstring As String, ByRef err As String, ByVal i_SoLenh As String, ByVal I_LineID As String) As DataSet
        '_c2SQL = New Connect2SQL.Connect2SQL(_SQLConnectionString)
        'Return _c2SQL.getDataSet("sp_ThongTinHoaDon_Select_TheoMa", err, New SqlParameter("@SoLenh", i_SoLenh), New SqlParameter("@LineID", I_LineID))
        Dim p_SQL As String
        p_SQL = "exec sp_ThongTinHoaDon_Select_TheoMa  '" & i_SoLenh & "','" & I_LineID & "'"
        Select_LenhXuatKho_ByMa = GetDataSet(p_SQL, p_SQL)
    End Function

    Public Function Select_LenhXuatKho_BySoLenh(ByRef err As String, ByVal i_SoLenh As String) As DataSet
        ' Dim p_DataSet As DataSet
        Dim p_SQL As String
        p_SQL = "sp_ThongTinHoaDon_Select_TheoSoLenh '" & i_SoLenh & "'"
        ' Return _c2SQL.getDataSet("sp_ThongTinHoaDon_Select_TheoSoLenh", err, New SqlParameter("@SoLenh", i_SoLenh))
        Select_LenhXuatKho_BySoLenh = GetDataSet(p_SQL, p_SQL)
    End Function

    Public Function Insert_TTHoaDon1(ByRef err As String, ByVal i_SoLenh As String, ByVal i_LineID As String, ByVal i_NgayXuat As Date, _
                        ByVal i_DonGia As Double) As Boolean
        '_c2SQL = New Connect2SQL.Connect2SQL(_SQLConnectionString)
        'Insert_TTHoaDon1 = _c2SQL.ExeNonQuery("sp_ThongTinHoaDon_Insert1", CommandType.StoredProcedure, err, _
        'New SqlParameter("@SoLenh", i_SoLenh), New SqlParameter("@LineID", i_LineID), New SqlParameter("@NgayXuat", i_NgayXuat), _
        'New SqlParameter("@DonGia", i_DonGia))
        Dim p_SQL As String
        p_SQL = "exec sp_ThongTinHoaDon_Insert1 '" & i_SoLenh & "','" & i_LineID & "','" & i_NgayXuat.ToString("yyyyMMdd") & "'"
        p_SQL = p_SQL & "," & i_DonGia
        Insert_TTHoaDon1 = SQL_Execute(p_SQL, p_SQL)

    End Function

    Public Function Update_TTHoaDon1(ByRef err As String, ByVal i_SoLenh As String, ByVal i_LineID As String, ByVal i_NgayXuat As Date, _
                                    ByVal i_DonGia As Double) As Boolean
        '_c2SQL = New Connect2SQL.Connect2SQL(_SQLConnectionString)
        'Update_TTHoaDon1 = _c2SQL.ExeNonQuery("sp_ThongTinHoaDon_Update1", CommandType.StoredProcedure, err, _
        'New SqlParameter("@SoLenh", i_SoLenh), New SqlParameter("@LineID", i_LineID), New SqlParameter("@NgayXuat", i_NgayXuat), _
        'New SqlParameter("@DonGia", i_DonGia))

        Dim p_SQL As String
        p_SQL = "exec sp_ThongTinHoaDon_Update1 '" & i_SoLenh & "','" & i_LineID & "','" & i_NgayXuat.ToString("yyyyMMdd") & "'"
        p_SQL = p_SQL & "," & i_DonGia
        Update_TTHoaDon1 = SQL_Execute(p_SQL, p_SQL)

    End Function
End Class
