Module Module2
    Public p_SYS_MALENH_S As String = String.Empty

    Public g_SYS_CONFIG_RPT_PARA As DataTable
    Public g_SYS_CONFIG_RPT As DataTable
    Public g_SYS_CONFIG_RPT_FIELD As DataTable

    Public g_tblVCF As DataTable



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

    Public Function FPT_GetMaLenh() As String
        Dim p_ValueTmp As String = "0000"
        Dim p_SQL As String = ""
        Dim p_Value As Integer = 0
        Dim p_DataTable As DataTable
        Try
            If p_SYS_MALENH_S.ToString.Trim = "" Then
                p_SQL = "select KEYCODE, KEYVALUE  from SYS_CONFIG where KEYCODE='SYS_MALENH_S'"
                p_DataTable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        p_SYS_MALENH_S = p_DataTable.Rows(0).Item("KEYVALUE").ToString.Trim

                    End If
                End If
            End If

            p_DataTable = Nothing
            FPT_GetMaLenh = "0000"
            p_SQL = "exec FPT_Get_SYS_MALENH_S"
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    p_Value = p_DataTable.Rows(0).Item(0)
                End If
            End If
            If p_Value > 0 Then
                If Len(p_Value.ToString.Trim) < 4 Then
                    FPT_GetMaLenh = Mid(p_ValueTmp, 1, Len(FPT_GetMaLenh.ToString.Trim) - Len(p_Value.ToString.Trim) - Len(p_SYS_MALENH_S)) & p_Value.ToString.Trim
                    If Len(FPT_GetMaLenh) = 3 Then
                        FPT_GetMaLenh = p_SYS_MALENH_S & FPT_GetMaLenh
                    End If
                Else
                    FPT_GetMaLenh = p_Value.ToString.Trim
                End If
            End If
        Catch ex As Exception
            FPT_GetMaLenh = "0000"
        End Try

    End Function

    Public Function CheckMaLenh(ByRef err As String, ByVal i_malenh As String, ByVal i_ngay As Date) As String

        Dim p_DataTable As DataTable
        Dim p_SQL As String
        Try
            CheckMaLenh = ""
            p_SQL = "select DBO.FPT_CheckMaLenh_E5('" & i_malenh & "','" & i_ngay & "') as MaLenh "
            '_c2SQL = New Connect2SQL.Connect2SQL(_SQLConnectionString)
            'Return _c2SQL.getDataValue("select DBO.fm_CheckMaLenh_KV2E5('" & i_malenh & "','" & i_ngay & "')")
            p_DataTable = GetDataTable(p_SQL, p_SQL)
            If Not p_DataTable Is Nothing Then
                If p_DataTable.Rows.Count > 0 Then
                    CheckMaLenh = p_DataTable.Rows(0).Item("MaLenh").ToString.Trim
                End If
            End If
            ' Return _c2SQL.getDataValue("exec CheckMaLenh_KV2E5('" & i_malenh & "','" & i_ngay & "')")

        Catch ex As Exception
            Return "1"
            err = ex.Message
        End Try
    End Function
End Module
