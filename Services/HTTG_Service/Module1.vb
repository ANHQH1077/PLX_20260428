Module Module1
    Sub main()
        Dim p_User As Integer = 1
        Dim p_CompanyCode As String
        Dim p_Service As New FPTBUSSINESS.Class1
        Dim p_SQL As String
        Dim p_Table As DataTable


        p_SQL = "select KeyValue from sys_config where upper(keycode) = 'SAPOFF'"
        p_Table = p_Service.mod_SYS_GET_DATATABLE(p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                If p_Table.Rows(0).Item("KeyValue").ToString.Trim = "Y" Then
                    Exit Sub
                End If
            End If
        End If


        p_SQL = "select * from tblConfig"
        p_Table = p_Service.mod_SYS_GET_DATATABLE(p_SQL)
        If Not p_Table Is Nothing Then
            If p_Table.Rows.Count > 0 Then
                p_CompanyCode = p_Table.Rows(0).Item("CompanyCode").ToString
            End If
        End If
        Dim p_HTTG_SAP As New THN_SAP_OBJECT.Class1(p_User, p_CompanyCode, p_Service)
        p_HTTG_SAP.ClsGET_HTTG_GET_LX_STAGING_AUTO()

        p_HTTG_SAP = Nothing
        End
    End Sub

End Module
