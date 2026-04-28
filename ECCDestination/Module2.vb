Imports SAP.Middleware.Connector
Module Module2

    Public Function GET_HTTG_GET_LX_STAGING(ByVal p_SoLenh As String,
                                            ByRef o_err As String) As System.Data.DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim T_DETAIL, T_DELIVERIES, T_DELIVERIES_CP, T_HEADER, T_HEADER_THN2, T_DETAIL_THN2, T_HEADER_THN3, T_DETAIL_THN3, T_ROUTE As IRfcTable

        'Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_Count As Integer
        Dim p_SQL, p_Desc As String
        Dim p_Row As DataRow
        Dim p_Table, p_ReturnTable As DataTable

        Try
            o_err = ""
            p_SQL = "select [ORDER_NO] from  [T_DELIVERIES_CP] where [ORDER_NO] ='" & p_SoLenh & "'  union all select solenh  from tbllenhxuate5 where solenh ='" & p_SoLenh & "'"
            p_Table = GetDataTableSQL(p_SQL, o_err)
            If o_err <> "" Then
                Exit Function
            End If
            If Not p_Table Is Nothing Then
                If p_Table.Rows.Count > 0 Then
                    Exit Function
                End If
            End If

            If p_ReturnTable Is Nothing Then
                p_ReturnTable = New DataTable("SQL_EXEC")
                p_ReturnTable.Columns.Add("STRSQL")
            End If

            'p_Table = GetDataTableSQL(p_SQL, p_SQL)
            'If Not p_Table Is Nothing Then
            '    If p_Table.Rows.Count > 0 Then
            '        p_ConnectString = p_Table.Rows(0).Item("SapConnectionString").ToString.Trim
            '        Try
            '            p_IdleTimeout = p_Table.Rows(0).Item("Timeout").ToString.Trim
            '        Catch ex As Exception

            '        End Try
            '        If p_IdleTimeout = "" Then
            '            p_IdleTimeout = "60"
            '        End If
            '    End If
            'End If


            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)

            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try
            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZFM_HTTG_GET_LX_STAGING")
            l_func.SetValue("I_ORDERNO", p_SoLenh)
            l_func.Invoke(_ecc)


            T_DELIVERIES_CP = l_func.GetTable("T_DELIVERIES_CP")
            T_HEADER = l_func.GetTable("T_HEADER")
            T_HEADER_THN2 = l_func.GetTable("T_HEADER_THN2")
            T_HEADER_THN3 = l_func.GetTable("T_HEADER_THN3")
            T_DETAIL = l_func.GetTable("T_DETAIL")
            T_DETAIL_THN3 = l_func.GetTable("T_DETAIL_THN3")
            T_DETAIL_THN2 = l_func.GetTable("T_DETAIL_THN2")
            T_DELIVERIES = l_func.GetTable("T_DELIVERIES")
            T_ROUTE = l_func.GetTable("T_ROUTE")

            o_err = ""
            For p_Count = 0 To T_DELIVERIES_CP.RowCount - 1
                p_SQL = "INSERT INTO [T_DELIVERIES_CP] ([MANDT],[ORDER_NO],[OUTBOUND],[LINEID],[ITEM_ND],[COMPARTMENT],[SALEORDER] " & _
                           ",[DATE_ND],[DATE_E_ND],[TIME_ND],[PLANT],[STORAGE],[BATCH_ND],[RESOURCE_ND],[METHOD_MT],[METHOD_DC] " & _
                           ",[CUSTOMER],[SALEQUANTITY],[TD_ACTION],[SHNUMBER],[SHPOINT],[TRANSMOT],[VEHICLE] " & _
                           ",[VEH_MODE],[DRIVERCODE],[MATERIAL],[UNIT] ,[QUANTITY] " & _
                           ",[NGAN_TEXT],[LUONG_TEXT],[NHIETDO_TEXT],[STATUS],[VENDORCODE],[SOTYPE] " & _
                           ",[PRSDT],[INCO1],[TANKGROUP_CT],[TANKGROUP_TT])"
                p_SQL = p_SQL & " VALUES (" & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("MANDT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("ORDER_NO"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("OUTBOUND"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("LINEID"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("ITEM_ND"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("COMPARTMENT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("SALEORDER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("DATE_ND"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("DATE_E_ND"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("TIME_ND"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("PLANT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("STORAGE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("BATCH_ND"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("RESOURCE_ND"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("METHOD_MT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("METHOD_DC"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("CUSTOMER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("SALEQUANTITY"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("TD_ACTION"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("SHNUMBER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("SHPOINT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("TRANSMOT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("VEHICLE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("VEH_MODE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("DRIVERCODE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("MATERIAL"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("UNIT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("QUANTITY"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("NGAN_TEXT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("LUONG_TEXT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("NHIETDO_TEXT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("STATUS"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("VENDORCODE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("SOTYPE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("PRSDT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("INCO1"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("TANKGROUP_CT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES_CP.Item(p_Count).GetValue("TANKGROUP_TT"), "'", "", 1) & "' " & _
                    ")"
                'If g_Services.Sys_Execute(p_SQL, _
                '                          o_err) = False Then

                'End If
                p_Row = p_ReturnTable.NewRow
                p_Row.Item(0) = p_SQL
                p_ReturnTable.Rows.Add(p_Row)
            Next

            For p_Count = 0 To T_HEADER.RowCount - 1
                p_SQL = "INSERT INTO [T_HEADER] ([VBELN],[CUSTOMER],[LONG_NAME] ,[ADRESS],[CONTRACT],[GUEBG],[WERKS],[NAME1],[KNOTA] " & _
                               ",[LOADING_POINT],[KNOTZ],[DISCHARG_POINT],[VAT],[UNIT],[ZLSCH],[TEXT1],[ZTERM],[VTEXT],[KURRF] " & _
                               ",[TK_NUMBER],[TKTX],[CARRIER],[LIFNR_NAME],[ROUTE] ,[WERKS_NHAP],[KHO_NHAP] " & _
                               ",[PHIEU_XUAT],[LDDATE],[BSART],[ERDAT],[ERZET],[KONDA])"
                p_SQL = p_SQL & " VALUES (" & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("VBELN"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("CUSTOMER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("LONG_NAME"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("ADRESS"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("CONTRACT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("GUEBG"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("WERKS"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("NAME1"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("KNOTA"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("LOADING_POINT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("KNOTZ"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("DISCHARG_POINT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("VAT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("UNIT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("ZLSCH"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("TEXT1"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("ZTERM"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("VTEXT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("KURRF"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("TK_NUMBER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("TKTX"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("CARRIER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("LIFNR_NAME"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("ROUTE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("WERKS_NHAP"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("KHO_NHAP"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("PHIEU_XUAT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("LDDATE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("BSART"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("ERDAT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("ERZET"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER.Item(p_Count).GetValue("KONDA"), "'", "", 1) & "' " & _
                    ")"
                p_Row = p_ReturnTable.NewRow
                p_Row.Item(0) = p_SQL
                p_ReturnTable.Rows.Add(p_Row)
            Next

            For p_Count = 0 To T_HEADER_THN2.RowCount - 1
                p_SQL = "INSERT INTO [T_HEADER_THN2] ([VBELN],[CUSTOMER],[LONG_NAME] ,[ADRESS],[CONTRACT],[GUEBG],[WERKS],[NAME1],[KNOTA] " & _
                               ",[LOADING_POINT],[KNOTZ],[DISCHARG_POINT],[VAT],[UNIT],[ZLSCH],[TEXT1],[ZTERM],[VTEXT],[KURRF] " & _
                               ",[TK_NUMBER],[TKTX],[CARRIER],[LIFNR_NAME],[ROUTE] ,[WERKS_NHAP],[KHO_NHAP] " & _
                               ",[PHIEU_XUAT],[LDDATE],[BSART],[ERDAT],[ERZET],[KONDA])"
                p_SQL = p_SQL & " VALUES (" & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("VBELN"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("CUSTOMER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("LONG_NAME"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("ADRESS"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("CONTRACT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("GUEBG"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("WERKS"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("NAME1"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("KNOTA"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("LOADING_POINT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("KNOTZ"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("DISCHARG_POINT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("VAT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("UNIT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("ZLSCH"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("TEXT1"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("ZTERM"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("VTEXT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("KURRF"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("TK_NUMBER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("TKTX"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("CARRIER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("LIFNR_NAME"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("ROUTE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("WERKS_NHAP"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("KHO_NHAP"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("PHIEU_XUAT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("LDDATE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("BSART"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("ERDAT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("ERZET"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN2.Item(p_Count).GetValue("KONDA"), "'", "", 1) & "' " & _
                    ")"
                p_Row = p_ReturnTable.NewRow
                p_Row.Item(0) = p_SQL
                p_ReturnTable.Rows.Add(p_Row)
            Next

            For p_Count = 0 To T_HEADER_THN3.RowCount - 1
                p_SQL = "INSERT INTO [T_HEADER_THN3] ([VBELN],[CUSTOMER],[LONG_NAME] ,[ADRESS],[CONTRACT],[GUEBG],[WERKS],[NAME1],[KNOTA] " & _
                               ",[LOADING_POINT],[KNOTZ],[DISCHARG_POINT],[VAT],[UNIT],[ZLSCH],[TEXT1],[ZTERM],[VTEXT],[KURRF] " & _
                               ",[TK_NUMBER],[TKTX],[CARRIER],[LIFNR_NAME],[ROUTE] ,[WERKS_NHAP],[KHO_NHAP] " & _
                               ",[PHIEU_XUAT],[LDDATE],[BSART],[ERDAT],[ERZET],[KONDA])"
                p_SQL = p_SQL & " VALUES (" & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("VBELN"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("CUSTOMER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("LONG_NAME"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("ADRESS"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("CONTRACT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("GUEBG"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("WERKS"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("NAME1"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("KNOTA"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("LOADING_POINT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("KNOTZ"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("DISCHARG_POINT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("VAT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("UNIT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("ZLSCH"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("TEXT1"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("ZTERM"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("VTEXT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("KURRF"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("TK_NUMBER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("TKTX"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("CARRIER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("LIFNR_NAME"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("ROUTE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("WERKS_NHAP"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("KHO_NHAP"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("PHIEU_XUAT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("LDDATE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("BSART"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("ERDAT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("ERZET"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_HEADER_THN3.Item(p_Count).GetValue("KONDA"), "'", "", 1) & "' " & _
                    ")"
                p_Row = p_ReturnTable.NewRow
                p_Row.Item(0) = p_SQL
                p_ReturnTable.Rows.Add(p_Row)
            Next

            For p_Count = 0 To T_DETAIL.RowCount - 1
                p_SQL = "INSERT INTO [dbo].[T_DETAIL]([VBELN],[POSNR],[KBETR],[KOEIN],[ZZ_KBETR],[CHIETKHAU],[CHARG])"
                p_SQL = p_SQL & " VALUES (" & _
                    "N'" & Replace(T_DETAIL.Item(p_Count).GetValue("VBELN"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL.Item(p_Count).GetValue("POSNR"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL.Item(p_Count).GetValue("KBETR"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL.Item(p_Count).GetValue("KOEIN"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL.Item(p_Count).GetValue("ZZ_KBETR"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL.Item(p_Count).GetValue("CHIETKHAU"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL.Item(p_Count).GetValue("CHARG"), "'", "", 1) & "' " & _
                    ")"
                p_Row = p_ReturnTable.NewRow
                p_Row.Item(0) = p_SQL
                p_ReturnTable.Rows.Add(p_Row)
            Next

            For p_Count = 0 To T_DETAIL_THN2.RowCount - 1
                p_SQL = "INSERT INTO [dbo].[T_DETAIL_THN2]([VBELN],[POSNR],[KBETR],[KOEIN],[ZZ_KBETR],[CHIETKHAU],[CHARG])"
                p_SQL = p_SQL & " VALUES (" & _
                    "N'" & Replace(T_DETAIL_THN2.Item(p_Count).GetValue("VBELN"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL_THN2.Item(p_Count).GetValue("POSNR"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL_THN2.Item(p_Count).GetValue("KBETR"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL_THN2.Item(p_Count).GetValue("KOEIN"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL_THN2.Item(p_Count).GetValue("ZZ_KBETR"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL_THN2.Item(p_Count).GetValue("CHIETKHAU"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL_THN2.Item(p_Count).GetValue("CHARG"), "'", "", 1) & "' " & _
                    ")"
                p_Row = p_ReturnTable.NewRow
                p_Row.Item(0) = p_SQL
                p_ReturnTable.Rows.Add(p_Row)
            Next

            For p_Count = 0 To T_DETAIL_THN3.RowCount - 1
                p_SQL = "INSERT INTO [dbo].[T_DETAIL_THN3]([VBELN],[POSNR],[KBETR],[KOEIN],[ZZ_KBETR],[CHIETKHAU],[BWTAR],[CHARG],[MATNR])"
                p_SQL = p_SQL & " VALUES (" & _
                    "N'" & Replace(T_DETAIL_THN3.Item(p_Count).GetValue("VBELN"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL_THN3.Item(p_Count).GetValue("POSNR"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL_THN3.Item(p_Count).GetValue("KBETR"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL_THN3.Item(p_Count).GetValue("KOEIN"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL_THN3.Item(p_Count).GetValue("ZZ_KBETR"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL_THN3.Item(p_Count).GetValue("CHIETKHAU"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL_THN3.Item(p_Count).GetValue("BWTAR"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL_THN3.Item(p_Count).GetValue("CHARG"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DETAIL_THN3.Item(p_Count).GetValue("MATNR"), "'", "", 1) & "' " & _
                    ")"
                p_Row = p_ReturnTable.NewRow
                p_Row.Item(0) = p_SQL
                p_ReturnTable.Rows.Add(p_Row)
            Next

            For p_Count = 0 To T_DELIVERIES.RowCount - 1
                p_SQL = "INSERT INTO [dbo].[T_DELIVERIES]([ORDER_NO] ,[OUTBOUND],[LINEID],[ITEM_ND],[COMPARTMENT],[SALEORDER],[DATE_ND] " & _
                       ",[DATE_E_ND],[TIME_ND],[PLANT] ,[STORAGE],[BATCH_ND],[RESOURCE_ND],[METHOD_MT],[METHOD_DC],[CUSTOMER] " & _
                       ",[SALEQUANTITY] ,[TD_ACTION],[SHNUMBER],[SHPOINT] ,[TRANSMOT],[VEHICLE],[VEH_MODE],[DRIVERCODE] " & _
                       ",[MATERIAL],[UNIT],[QUANTITY],[NGAN_TEXT],[LUONG_TEXT] ,[NHIETDO_TEXT] " & _
                       ",[STATUS],[VENDORCODE],[SOTYPE],[PRSDT],[INCO1],[TKTX_DATE],[ERDAT] " & _
                       ",[ERZET],[KONDA],[CHOTLO],[LOAI_KH] ,[SO_CHUYEN],[NOTE_SMO],[TKTX],[TANKGROUP] )"
                p_SQL = p_SQL & " VALUES (" & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("ORDER_NO"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("OUTBOUND"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("LINEID"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("ITEM_ND"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("COMPARTMENT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("SALEORDER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("DATE_ND"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("DATE_E_ND"), "'", "", 1) & "', " & _
                      "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("TIME_ND"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("PLANT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("STORAGE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("BATCH_ND"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("RESOURCE_ND"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("METHOD_MT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("METHOD_DC"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("CUSTOMER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("SALEQUANTITY"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("TD_ACTION"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("SHNUMBER"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("SHPOINT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("TRANSMOT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("VEHICLE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("VEH_MODE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("DRIVERCODE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("MATERIAL"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("UNIT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("QUANTITY"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("NGAN_TEXT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("LUONG_TEXT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("NHIETDO_TEXT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("STATUS"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("VENDORCODE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("SOTYPE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("PRSDT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("INCO1"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("TKTX_DATE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("ERDAT"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("ERZET"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("KONDA"), "'", "", 1) & "', " & _
                     "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("CHOTLO"), "'", "", 1) & "', " & _
                     "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("LOAI_KH"), "'", "", 1) & "', " & _
                     "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("SO_CHUYEN"), "'", "", 1) & "', " & _
                     "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("NOTE_SMO"), "'", "", 1) & "', " & _
                     "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("TKTX"), "'", "", 1) & "', " & _
                     "N'" & Replace(T_DELIVERIES.Item(p_Count).GetValue("TANKGROUP"), "'", "", 1) & "' " & _
                    ")"
                'If g_Services.Sys_Execute(p_SQL, _
                '                          o_err) = False Then

                'End If
                p_Row = p_ReturnTable.NewRow
                p_Row.Item(0) = p_SQL
                p_ReturnTable.Rows.Add(p_Row)
            Next
            'T_ROUTE
            For p_Count = 0 To T_ROUTE.RowCount - 1
                p_SQL = "INSERT INTO [dbo].[T_ROUTE]([VBELN],[ROUTECODE],[ROUTENAME])"
                p_SQL = p_SQL & " VALUES (" & _
                    "N'" & Replace(T_ROUTE.Item(p_Count).GetValue("VBELN"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_ROUTE.Item(p_Count).GetValue("ROUTECODE"), "'", "", 1) & "', " & _
                    "N'" & Replace(T_ROUTE.Item(p_Count).GetValue("ROUTENAME"), "'", "", 1) & "' " & _
                    ")"
                p_Row = p_ReturnTable.NewRow
                p_Row.Item(0) = p_SQL
                p_ReturnTable.Rows.Add(p_Row)
            Next
            Return p_ReturnTable
        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            o_err = ex.Message.ToString()
            Return Nothing
        End Try


    End Function


End Module
