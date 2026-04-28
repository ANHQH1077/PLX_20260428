Imports SAP.Middleware.Connector
'Imports Newtonsoft.Json
'Imports System.Net.Http
'Imports System.Net.HttpWebRequest
''Imports System.Net.WebClient
'Imports System.Net.Http.Headers
'Imports Newtonsoft.Json.Linq
Module Driver

    Private _ecc As RfcDestination
    Dim g_rfcdest As IRfcFunction
    'Private Client As New System.Net.Http.HttpClient()
    Private LinkServices = "erp.petrolimex.com.vn:8001/dev/lims/plx/api/"
    Private p_UserNameAPI As String = "PLX_LIMS"
    Private p_PassAPI As String = "PLX_LIMS@!23"

    Public g_GetDestination = "LINHTINH" '"DEV"

    Public p_AppServerHost As String = "10.0.9.83"
    Public p_DevClient As String = System.Net.Dns.GetHostName & Now.ToString("yyMMdd HH:mm:ss")
    Public p_SystemNumber As String = "21"
    Public p_User As String = "duonglt5"
    Public p_Password As String = "duong1234"
    Public p_Client As String = "900"
    Public p_Language As String = "EN"
    Public p_IdleTimeout As String = "60"
    Public p_ConnectString As String = ""
    Public g_CompanyCode As String
    Public g_Services As New FPTBUSSINESS.Class1


    Public g_FuncNameApp As String = ""
    Public g_KeyApp As String = ""
    Public g_ClientApp As String = ""
    Public g_UserNameApp As String = ""

    'Sub subMain()
    '    Dim p_TEst As IDestinationConfiguration
    '    p_TEst = New ECCDestinationConfig


    '    Try
    '        RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
    '        _ecc = RfcDestinationManager.GetDestination(g_GetDestination)

    '        GetCompanyName()


    '    Catch ex As Exception
    '        System.Console.WriteLine(ex.Message)
    '        System.Console.ReadLine()
    '    End Try


    'End Sub

    Private Sub GetCompanyName()
        System.Console.WriteLine(String.Format("Successfully connected to System {0} Client {1}.", _ecc.SystemID, _ecc.Client))
        System.Console.WriteLine("Enter a company ID:")

        Dim companyID As String = System.Console.ReadLine()

        While Not String.IsNullOrEmpty(companyID.Trim)

            Dim companyAPI As IRfcFunction = _ecc.Repository.CreateFunction("BAPI_COMPANY_GETDETAIL")
            companyAPI.SetValue("COMPANYID", companyID)

            companyAPI.Invoke(_ecc)

            Dim companyName As String = companyAPI.GetStructure("COMPANY_DETAIL").GetString("NAME1")

            If String.IsNullOrEmpty(companyName.Trim) Then
                companyName = "Not found"
            End If

            System.Console.WriteLine(companyName)

            companyID = System.Console.ReadLine()

        End While
    End Sub



    Public Sub KV1_UpdateTrangThaiTichKe(ByVal p_SoLenh As String, ByRef o_err As String)

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_MaNGuon As String = ""
        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Row As DataRow
        Try

            p_TableReturn.Columns.Add("ParName")
            p_TableReturn.Columns.Add("ParValue")
            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try


            repository = _ecc.Repository

            p_SoLenh = Replace(p_SoLenh, ",", "")
            l_func = repository.CreateFunction("ZFM_HTTG_PUT_INTICKKE")
            l_func.SetValue("I_VBELN", p_SoLenh)
            l_func.Invoke(_ecc)


            l_tabl = l_func.GetTable(1)
            '   RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)


            o_err = ""
        Catch ex As Exception
            Try
                '  RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            o_err = ex.Message.ToString()

        End Try


    End Sub

    

    Public Function Get_DO1_Infor(p_SoLenh As String, ByRef o_err As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_MaNGuon As String = ""
        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Row As DataRow
        Try

            p_TableReturn.Columns.Add("ParName")
            p_TableReturn.Columns.Add("ParValue")

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode, g_ClientApp, g_UserNameApp)
            ''RfcDestinationManager.GetDestination("aaaa")
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)

            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try


            repository = _ecc.Repository

            Dim p_KeyApp As String = ""
            p_KeyApp = GetKey("Get_DO1_Infor")

            l_func = repository.CreateFunction("ZFM_HTTG_GET_INFO_DO")
            l_func.SetValue("I_DO", p_SoLenh)
            ''20250519 
            l_func.SetValue("I_UNAME", p_KeyApp)


            l_func.Invoke(_ecc)
            p_E_KUNNR = l_func.GetString("E_KUNNR")
            p_E_DO = l_func.GetString("E_DO")
            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParName") = "E_KUNNR"
            p_Row.Item("ParValue") = p_E_KUNNR
            p_TableReturn.Rows.Add(p_Row)

            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParName") = "E_DO"
            p_Row.Item("ParValue") = p_E_DO
            p_TableReturn.Rows.Add(p_Row)

            p_MaNGuon = l_func.GetString("E_BWTAR")
            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParName") = "E_BWTAR"
            p_Row.Item("ParValue") = p_MaNGuon
            p_TableReturn.Rows.Add(p_Row)
            'RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)

            Return p_TableReturn

        Catch ex As Exception
            Try
                'RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            o_err = "Get_DO1_Infor: " & ex.Message.ToString()

            Return Nothing
        End Try


    End Function


    'anhqh
    '20200409
    'Ham lay thong tin chiet khau
    Public Function Get_DO3_Infor(ByVal p_SoLenh As String, ByRef o_err As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl, l_Tabl2 As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_Count As Integer

        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Row As DataRow
        Try
            If Get_DO3_Infor Is Nothing Then
                Get_DO3_Infor = New DataTable("Table01")
                Get_DO3_Infor.Columns.Add("ParName")
                Get_DO3_Infor.Columns.Add("ParValue")
            End If
          

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode, g_ClientApp, g_UserNameApp)
            ''RfcDestinationManager.GetDestination("aaaa")
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try
            ''If RfcDestinationManager.tr Then

            ''End If
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try
            ' _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            repository = _ecc.Repository


            Dim p_KeyApp As String = ""
            p_KeyApp = GetKey("Get_DO3_Infor")

            l_func = repository.CreateFunction("ZBAPI_EXPORT_THN2")
            l_func.SetValue("I_DO", p_SoLenh)
            ''20250519 
            l_func.SetValue("I_UNAME", p_KeyApp)
            l_func.Invoke(_ecc)

            l_tabl = l_func.GetTable("T_DETAIL")
            l_Tabl2 = l_func.GetTable("T_HEADER")

            ' p_E_KUNNR = l_tabl.GetValue("POSNR")

            For p_Count = 0 To l_tabl.RowCount - 1
                p_Row = Get_DO3_Infor.NewRow
                p_Row.Item("ParName") = l_tabl.Item(p_Count).GetValue("POSNR")
                p_Row.Item("ParValue") = l_tabl.Item(p_Count).GetValue("CHIETKHAU")
                Get_DO3_Infor.Rows.Add(p_Row)
            Next
            'p_E_DO = l_tabl.GetValue("CHIETKHAU")
            'p_Row = Get_DO3_Infor.NewRow
            'p_Row.Item("ParName") = "CHIETKHAU"
            'p_Row.Item("ParValue") = p_E_DO
            'Get_DO3_Infor.Rows.Add(p_Row)

            '  RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)

            'Return p_TableReturn

        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            o_err = "Get_DO3_Infor: " & ex.Message.ToString()
            'Return Nothing
        End Try


    End Function

    Private Function GetDataTable(i_Table As IRfcTable) As DataTable

        Dim i As Integer
        Dim Data As New DataTable
        Dim metadata As RfcElementMetadata
        Dim row As IRfcStructure
        Dim rowAdd As DataRow
        ' //Create data table.
        For i = 0 To i_Table.ElementCount - 1
            metadata = i_Table.GetElementMetadata(i)
            Data.Columns.Add(metadata.Name)
        Next

        '//Transfer rows from rfcTable to .Net table.
        For Each row In i_Table
            rowAdd = Data.NewRow
            For i = 0 To i_Table.ElementCount - 1
                metadata = i_Table.GetElementMetadata(i)
                rowAdd(metadata.Name) = row.GetString(metadata.Name)
            Next
            Data.Rows.Add(rowAdd)
        Next

        Return Data

    End Function


    'anhqh
    'Bo sung theem 1 soos truong dung khi maats ket noi sap
    '20200318
    Public Function Get_DO2_Infor(ByVal p_SoLenh As String, ByRef o_err As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_CreateDate As String = ""

        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Row As DataRow
        Try
            ' System.Net.Dns.GetHostAddresses()
            p_TableReturn.Columns.Add("ParName")
            p_TableReturn.Columns.Add("ParValue")

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode, g_ClientApp, g_UserNameApp)
           
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try
            repository = _ecc.Repository


            Dim p_KeyApp As String = ""
            p_KeyApp = GetKey("Get_DO2_Infor")
            



            l_func = repository.CreateFunction("ZFM_INT_DELIVERIES_SPECIFIC_V1")
            l_func.SetValue("I_ORDERNO", p_SoLenh)
            l_func.SetValue("I_STATUS", "N")
            ''20250519 
            l_func.SetValue("I_UNAME", p_KeyApp)

            l_func.Invoke(_ecc)

            ' p_Table = l_func.Metadata.Item(3).ValueMetadataAsTableMetadata
            l_tabl = l_func.GetTable("T_DELIVERIES")

            ' l_func.SetValue  ("ZSM_THN"
            '  p_E_KUNNR = l_func.GetString("E_KUNNR")
            'p_E_DO = l_func.GetString("E_DO")
            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParName") = "SOTYPE"
            p_Row.Item("ParValue") = l_tabl.GetValue("SOTYPE").ToString
            p_TableReturn.Rows.Add(p_Row)

            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParName") = "PRSDT"
            p_E_DO = l_tabl.GetValue("PRSDT").ToString
            p_E_DO = Replace(p_E_DO, "-", "")
            p_Row.Item("ParValue") = p_E_DO
            p_TableReturn.Rows.Add(p_Row)

            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParName") = "INCO1"
            p_Row.Item("ParValue") = l_tabl.GetValue("INCO1").ToString
            p_TableReturn.Rows.Add(p_Row)

            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParName") = "TKTX_Date"
            p_E_DO = l_tabl.GetValue("TKTX_Date").ToString
            p_E_DO = Replace(p_E_DO, "-", "")
            p_Row.Item("ParValue") = p_E_DO
            p_TableReturn.Rows.Add(p_Row)

            '20241110 bo sung cho kv2
            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParName") = "TKTX"
            p_Row.Item("ParValue") = l_tabl.GetValue("TKTX").ToString
            p_TableReturn.Rows.Add(p_Row)

            '20241122 bo sung cho kv2
            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParName") = "NhomBeXuat"
            p_Row.Item("ParValue") = l_tabl.GetValue("Tankgroup").ToString
            p_TableReturn.Rows.Add(p_Row)


            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParName") = "KONDA"
            p_Row.Item("ParValue") = l_tabl.GetValue("KONDA").ToString
            p_TableReturn.Rows.Add(p_Row)
            '
            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParName") = "BATCH_ND"
            p_Row.Item("ParValue") = l_tabl.GetValue("BATCH_ND").ToString
            p_TableReturn.Rows.Add(p_Row)

            Try
                p_Row = p_TableReturn.NewRow
                p_Row.Item("ParName") = "CHOTLO"
                p_Row.Item("ParValue") = l_tabl.GetValue("CHOTLO").ToString
                p_TableReturn.Rows.Add(p_Row)
            Catch ex As Exception
            End Try

            Try
                p_Row = p_TableReturn.NewRow
                p_Row.Item("ParName") = "LOAI_KH"
                p_Row.Item("ParValue") = l_tabl.GetValue("LOAI_KH").ToString
                p_TableReturn.Rows.Add(p_Row)
            Catch ex As Exception
            End Try

            Try
                p_Row = p_TableReturn.NewRow
                p_Row.Item("ParName") = "SO_CHUYEN"
                p_Row.Item("ParValue") = l_tabl.GetValue("SO_CHUYEN").ToString
                p_TableReturn.Rows.Add(p_Row)
            Catch ex As Exception
            End Try

            Try
                p_Row = p_TableReturn.NewRow
                p_Row.Item("ParName") = "NOTE_SMO"
                p_Row.Item("ParValue") = l_tabl.GetValue("NOTE_SMO").ToString
                p_TableReturn.Rows.Add(p_Row)
            Catch ex As Exception
            End Try

            Try
                p_CreateDate = l_tabl.GetValue("ERDAT").ToString & " " & l_tabl.GetValue("ERZET").ToString
                p_CreateDate = CDate(p_CreateDate).ToString("yyyyMMdd HH:mm:ss")
                p_Row = p_TableReturn.NewRow
                p_Row.Item("ParName") = "CREATEDATE"
                p_Row.Item("ParValue") = p_CreateDate
                p_TableReturn.Rows.Add(p_Row)
            Catch ex As Exception
                p_CreateDate = ""
            End Try

            'RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)

            Return p_TableReturn

        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            o_err = "Get_DO2_Infor: " & ex.Message.ToString()
            Return Nothing
        End Try


    End Function



    Public Sub THN_DensToSap(ByVal p_TableHangHoa As System.Data.DataTable, ByRef p_Err As String)

        Dim l_func As IRfcFunction
        Dim l_tabl, l_tabl_Line, p_TableError As IRfcTable
        Dim l_tablR As IRfcTable
        Dim l_ret2, l_ret2Line As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_Col, p_RowID As Integer
        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Double As Decimal
        Dim p_Row As DataRow
        Dim p_Vaue As Int64
        Try

            'p_TableReturn.Columns.Add("ParName")
            'p_TableReturn.Columns.Add("ParValue")

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try

            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZFM_TANK_DENS_UPDATE")
            'l_tabl = l_func.GetTable("IT_THN_HDR") '     .SetValue("SoLenh", "123")
            'l_tabl_HangHoa = l_func.GetTable("IT_THN_DTL")
            l_tabl_Line = l_func.GetTable("IT_TANK_DENS_UPD")



            For p_RowID = 0 To p_TableHangHoa.Rows.Count - 1
                l_tabl_Line.Append()
                For p_Col = 0 To p_TableHangHoa.Columns.Count - 1
                    If p_TableHangHoa.Rows(p_RowID).Item(p_TableHangHoa.Columns(p_Col)).ToString.Trim <> "" Then
                        l_tabl_Line.SetValue(UCase(p_TableHangHoa.Columns(p_Col).ColumnName.ToString.Trim), p_TableHangHoa.Rows(p_RowID).Item(p_TableHangHoa.Columns(p_Col)))
                    End If

                Next
            Next


            l_func.Invoke(_ecc)

            ' l_ret2 = l_func.GetStructure("E_RETURN") '
            'p_TableError = l_func.GetTable("IT_THN_HDR")
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex2 As Exception
                p_Err = ex2.Message.ToString
            End Try


        Catch ex As Exception
            Try
                'RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            p_Err = ex.Message.ToString()

        End Try


    End Sub


    Public Function THN_LenhXuat_Infor(ByVal p_TableHeader As DataTable, ByVal p_TableHangHoa As DataTable, _
                                        ByVal p_TableChiTiet As DataTable, ByRef o_err As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl, l_tabl_Line, l_tabl_HangHoa, p_TableError As IRfcTable
        Dim l_tablR As IRfcTable
        Dim l_ret2, l_ret2Line As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_Col, p_RowID As Integer
        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Double As Decimal
        Dim p_Row As DataRow
        Dim p_Vaue As Int64
        Try

            p_TableReturn.Columns.Add("ParName")
            p_TableReturn.Columns.Add("ParValue")

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try

            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZFM_THN")
            l_tabl = l_func.GetTable("IT_THN_HDR") '     .SetValue("SoLenh", "123")
            l_tabl_HangHoa = l_func.GetTable("IT_THN_DTL")
            l_tabl_Line = l_func.GetTable("IT_THN_DTL_COM")
    
            For p_RowID = 0 To p_TableHeader.Rows.Count - 1
                l_tabl.Append()
                For p_Col = 0 To p_TableHeader.Columns.Count - 1
                    If p_TableHeader.Rows(p_RowID).Item(p_TableHeader.Columns(p_Col)).ToString.Trim <> "" Then
                        If UCase(p_TableHeader.Columns(p_Col).ColumnName.ToString.Trim) = UCase("NgayHieuLuc") And Mid(p_TableHeader.Rows(p_RowID).Item(p_TableHeader.Columns("SoLenh")).ToString.Trim, 1, 1) = "2" Then
                            p_RowID = p_RowID
                        Else
                            If UCase(p_TableHeader.Columns(p_Col).ColumnName.ToString.Trim) = "TYGIA" Or UCase(p_TableHeader.Columns(p_Col).ColumnName.ToString.Trim) = "DO1_KURSK" Then
                                Decimal.TryParse(p_TableHeader.Rows(p_RowID).Item(p_TableHeader.Columns(p_Col)).ToString.Trim, p_Double)
                                Try
                                    l_tabl.SetValue(UCase(p_TableHeader.Columns(p_Col).ColumnName.ToString.Trim), p_Double)
                                Catch ex As Exception

                                End Try

                            Else
                                l_tabl.SetValue(UCase(p_TableHeader.Columns(p_Col).ColumnName.ToString.Trim), p_TableHeader.Rows(p_RowID).Item(p_TableHeader.Columns(p_Col)))
                            End If
                        End If
                      

                    End If

                Next

            Next

            For p_RowID = 0 To p_TableHangHoa.Rows.Count - 1
                l_tabl_HangHoa.Append()
                For p_Col = 0 To p_TableHangHoa.Columns.Count - 1
                    If p_TableHangHoa.Rows(p_RowID).Item(p_TableHangHoa.Columns(p_Col)).ToString.Trim <> "" Then
                        l_tabl_HangHoa.SetValue(UCase(p_TableHangHoa.Columns(p_Col).ColumnName.ToString.Trim), p_TableHangHoa.Rows(p_RowID).Item(p_TableHangHoa.Columns(p_Col)))
                    End If

                Next
            Next



            For p_RowID = 0 To p_TableChiTiet.Rows.Count - 1
                l_tabl_Line.Append()
                For p_Col = 0 To p_TableChiTiet.Columns.Count - 1
                    If UCase(p_TableChiTiet.Columns(p_Col).ColumnName.ToString.Trim) = "SL_LLKEBD" Or UCase(p_TableChiTiet.Columns(p_Col).ColumnName.ToString.Trim) = "SL_LLKEKT" Then
                        Int64.TryParse(p_TableChiTiet.Rows(p_RowID).Item(p_TableChiTiet.Columns(p_Col)), p_Vaue)
                        l_tabl_Line.SetValue(UCase(p_TableChiTiet.Columns(p_Col).ColumnName.ToString.Trim), p_Vaue)
                    Else

                        If p_TableChiTiet.Rows(p_RowID).Item(p_TableChiTiet.Columns(p_Col)).ToString.Trim <> "" Then
                            '                 	,	SL_LLKEBD 		decimal(18, 0)
                            ',	SL_LLKEKT   	decimal(18, 0)
                            l_tabl_Line.SetValue(UCase(p_TableChiTiet.Columns(p_Col).ColumnName.ToString.Trim), p_TableChiTiet.Rows(p_RowID).Item(p_TableChiTiet.Columns(p_Col)))
                        End If
                    End If
                Next
            Next

           
            l_func.Invoke(_ecc)

            l_ret2 = l_func.GetStructure("E_RETURN") '
            p_TableError = l_func.GetTable("IT_THN_HDR")
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception

            End Try


            Return p_TableReturn

        Catch ex As Exception
            Try
                'RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            o_err = ex.Message.ToString()
            Return Nothing
        End Try


    End Function





    'anhqh
    '
    '20200405  Ham lay thông tin  ký hiệu hóa đơn trên SAP
    Public Function Get_HoaDon_Infor(ByRef o_err As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_SQL As String
        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Row As DataRow
        Dim p_ComCode As String = ""
        Try


            p_TableReturn.Columns.Add("ParValue")

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try
            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZFM_HTTG_GET_DHD")
            'l_func.SetValue("I_BUKRS", g_CompanyCode)
            l_func.Invoke(_ecc)
            l_tabl = l_func.GetTable("T_DATA")
            ' p_Table = l_func.GetTable(1).Metadata
            Dim p_DAI_HD As String = "" ': Mẫu số VAT Tái xuất
            Dim p_MAUSO_VAT As String = "" ': Mẫu số VAT nội địa
            Dim p_MAUSO_PXK As String = ""   ': Mẫu số PXK
            Dim p_KYHIEU_VATTX As String = ""   ': Ký hiệu VAT Tái xuất
            Dim p_KYHIEU_VAT As String = ""   ': Ký hiệu VAT nội địa
            Dim p_KYHIEU_PXK As String = ""   ': Ký hiệu PXK
            Dim p_KYHIEU_VAT_KLT As String = ""  ': Ký hiệu VAT nội địa ko liên tục

            ''anhqh  20200729   day bang LogHist
            p_SQL = HistStringSyn("HoaDon", True)
            p_Row = p_TableReturn.NewRow
            p_Row.Item(0) = p_SQL
            p_TableReturn.Rows.Add(p_Row)

            If Not l_tabl Is Nothing Then
                For p_Count = 0 To l_tabl.RowCount - 1
                    p_ComCode = l_tabl.Item(p_Count).Item("BUKRS").GetValue.ToString
                    If Left(p_ComCode, 2) <> Left(g_CompanyCode, 2) Then
                        Continue For
                    End If

                    p_DAI_HD = l_tabl.Item(p_Count).Item("DAI_HD").GetValue.ToString  ' l_tabl.GetValue("DAI_HD").ToString
                    p_MAUSO_VAT = l_tabl.Item(p_Count).Item("MAUSO_VAT").GetValue.ToString  '   l_tabl.GetValue("MAUSO_VAT").ToString
                    p_MAUSO_PXK = l_tabl.Item(p_Count).Item("MAUSO_PXK").GetValue.ToString  '   l_tabl.GetValue("MAUSO_PXK").ToString
                    p_KYHIEU_VATTX = l_tabl.Item(p_Count).Item("KYHIEU_VATTX").GetValue.ToString  '  l_tabl.GetValue("KYHIEU_VATTX").ToString
                    p_KYHIEU_VAT = l_tabl.Item(p_Count).Item("KYHIEU_VAT").GetValue.ToString  '   l_tabl.GetValue("KYHIEU_VAT").ToString
                    p_KYHIEU_PXK = l_tabl.Item(p_Count).Item("KYHIEU_PXK").GetValue.ToString  '  l_tabl.GetValue("KYHIEU_PXK").ToString
                    p_KYHIEU_VAT_KLT = l_tabl.Item(p_Count).Item("KYHIEU_VAT_KLT").GetValue.ToString  '   l_tabl.GetValue("KYHIEU_VAT_KLT").ToString

                    p_SQL = " MERGE tblKyHieuHoaDon AS target   USING (	"
                    p_SQL = p_SQL & " select '" & p_ComCode & "' as CompanyCode,  'GTGT' as LoaiHD, '" & p_MAUSO_VAT & "' as MauSo, '" & p_KYHIEU_VAT & "' as KyHieu, '" & p_KYHIEU_VAT_KLT & "' as KyHieuKLT " & _
                            " Union all select '" & p_ComCode & "' as CompanyCode,'HDTX_VN' as LoaiHD, '" & p_DAI_HD & "' as MauSo, '" & p_KYHIEU_VATTX & "' as KyHieu, null as KyHieuKLT " & _
                            " Union All select '" & p_ComCode & "' as CompanyCode,'GTGT_VCNB' as LoaiHD, '" & p_MAUSO_PXK & "' as MauSo, '" & p_KYHIEU_PXK & "' as KyHieu, null as KyHieuKLT "
                    p_SQL = p_SQL & " ) AS source (CompanyCode, LoaiHD, MauSo,KyHieu,KyHieuKLT )  " & _
                            " ON (target.LoaiHD = source.LoaiHD and target.CompanyCode=source.CompanyCode)   " & _
                            " WHEN MATCHED THEN " & _
                            " UPDATE SET MauSo = source.MauSo  ,KyHieu = source.KyHieu  ,KyHieuKLT = source.KyHieuKLT " & _
                            " WHEN NOT MATCHED THEN   " & _
                            " INSERT(CompanyCode, LoaiHD, MauSo, KyHieu, KyHieuKLT) " & _
                            " VALUES (source.CompanyCode, source.LoaiHD, source.MauSo,source.KyHieu,source.KyHieuKLT)  ;"
                    p_Row = p_TableReturn.NewRow
                    p_Row.Item("ParValue") = p_SQL
                    p_TableReturn.Rows.Add(p_Row)
                Next

                If p_TableReturn.Rows.Count > 0 Then
                    p_SQL = getStringSyn("HoaDon", p_TableReturn.Rows.Count, 1)
                    p_Row = p_TableReturn.NewRow
                    p_Row.Item(0) = p_SQL
                    p_TableReturn.Rows.Add(p_Row)

                  

                End If

                ''anhqh  20200729   day bang LogHist
                p_SQL = HistStringSyn("HoaDon", False)
                p_Row = p_TableReturn.NewRow
                p_Row.Item(0) = p_SQL
                p_TableReturn.Rows.Add(p_Row)
            End If
            'RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)

            Return p_TableReturn

        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            o_err = ex.Message.ToString()
            Return Nothing
        End Try


    End Function




    'anhqh
    '
    '20200505  Ham lay thông tin Cong ty, don vi
    Public Function Get_CongTy_Infor(ByRef o_err As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Row As DataRow
        Dim p_MST As String = ""
        Dim p_ComCode, p_ComName, p_House_UM, p_Street, p_City, p_Country As String
        Try


            p_TableReturn.Columns.Add("ParValue")

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try
            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZBAPI_FM_GETCOMPANY")

            '  l_func = repository.CreateFunction("ZBAPI_FM_GET_COMPANYCODE")
            ' l_func.SetValue("I_BUKRS", g_CompanyCode)
            l_func.Invoke(_ecc)

            'l_func.
            l_tabl = l_func.GetTable("T_COMPANY")
            If Not l_tabl Is Nothing Then
                For p_Count = 0 To l_tabl.RowCount - 1
                    p_ComCode = l_tabl.Item(p_Count).Item("CONGR").GetValue.ToString    ' l_tabl.Item(p_Count).GetValue("CONRG")
                    p_ComName = l_tabl.Item(p_Count).Item("TXTMI").GetValue.ToString  ' l_tabl.Item(p_Count).GetValue("TXTMI")
                    p_ComCode = Strings.Right(p_ComCode, 4)
                    p_SQL = " MERGE tblDonVi AS target   USING (	"
                    p_SQL = p_SQL & " select '" & p_ComCode & "' as MaDonVi, N'" & p_ComName & "' as TenDonVi "
                    p_SQL = p_SQL & " ) AS source (MaDonVi, TenDonVi )  " & _
                            " ON (target.MaDonVi = source.MaDonVi)   " & _
                            " WHEN MATCHED THEN " & _
                            " UPDATE SET TenDonVi = source.TenDonVi " & _
                            " WHEN NOT MATCHED THEN   " & _
                            " INSERT(MaDonVi, TenDonVi) " & _
                            " VALUES (source.MaDonVi, source.TenDonVi)  ;"
                    p_Row = p_TableReturn.NewRow
                    p_Row.Item("ParValue") = p_SQL
                    p_TableReturn.Rows.Add(p_Row)

                Next
            End If

            l_func = repository.CreateFunction("ZBAPI_FM_GET_COMPANYCODE")
            '  l_func = repository.CreateFunction("ZBAPI_FM_GET_COMPANYCODE")
            ' l_func.SetValue("I_BUKRS", g_CompanyCode)
            l_func.Invoke(_ecc)


            'l_func.
            l_tabl = l_func.GetTable("T_COMPANYCODE")
            If Not l_tabl Is Nothing Then
                For p_Count = 0 To l_tabl.RowCount - 1
                    p_ComCode = l_tabl.Item(p_Count).Item("BUKRS").GetValue.ToString    ' l_tabl.Item(p_Count).GetValue("CONRG")
                    p_ComName = l_tabl.Item(p_Count).Item("NAME").GetValue.ToString  ' l_tabl.Item(p_Count).GetValue("TXTMI")

                    p_House_UM = l_tabl.Item(p_Count).Item("HOUSE_UM").GetValue.ToString
                    p_Street = l_tabl.Item(p_Count).Item("STREET").GetValue.ToString
                    p_City = l_tabl.Item(p_Count).Item("CITY").GetValue.ToString
                    p_Country = l_tabl.Item(p_Count).Item("COUNTRY").GetValue.ToString
                    p_MST = l_tabl.Item(p_Count).Item("MST").GetValue.ToString
                    p_ComCode = Strings.Right(p_ComCode, 4)

                    p_SQL = " MERGE tblDonVi AS target   USING (	"
                    p_SQL = p_SQL & " select '" & p_ComCode & "' as MaDonVi, N'" & p_ComName & "' as TenDonVi" & _
                            ",N'" & p_House_UM & "' as HOUSE_UM, N'" & p_Street & "' as STREET" & _
                            ",N'" & p_City & "' as CITY, N'" & p_Country & "' as COUNTRY, '" & p_MST & "' as  MST "
                    p_SQL = p_SQL & " ) AS source (MaDonVi, TenDonVi, HOUSE_UM, STREET , CITY, COUNTRY, MST)  " & _
                            " ON (target.MaDonVi = source.MaDonVi)   " & _
                            " WHEN MATCHED THEN " & _
                            " UPDATE SET TenDonVi = source.TenDonVi , HOUSE_UM = source.HOUSE_UM  " & _
                                ", STREET = source.STREET , CITY = source.CITY, COUNTRY = source.COUNTRY , MaSoThue = source.MST" & _
                            " WHEN NOT MATCHED THEN   " & _
                            " INSERT(MaDonVi, TenDonVi, HOUSE_UM,STREET,CITY,  COUNTRY ,MaSoThue) " & _
                            " VALUES (source.MaDonVi, source.TenDonVi, source.HOUSE_UM, source.STREET, source.CITY, source.COUNTRY,  source.MST)  ;"
                    p_Row = p_TableReturn.NewRow
                    p_Row.Item("ParValue") = p_SQL
                    p_TableReturn.Rows.Add(p_Row)

                Next
            End If

            ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)

            Return p_TableReturn

        Catch ex As Exception
            Try
                'RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            o_err = ex.Message.ToString()
            Return Nothing
        End Try


    End Function




    'anhqh
    '
    '20200505  Ham lay thông tin cacbe Map cua SAP va HTTG
    Public Function Get_TankMapSAP_Infor(ByVal p_Plant As String, ByVal p_User As String, ByRef o_err As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Row As DataRow
        Dim p_MST As String = ""
        Dim p_TankSAP, p_TankHTTG, p_House_UM, p_Street, p_City, p_Country As String
        Try


            p_TableReturn.Columns.Add("ParValue")

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)

            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try

            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZFM_GET_TANK_CONVERT")

            l_func.SetValue("I_WERKS", p_Plant)
            l_func.Invoke(_ecc)

            'l_func.
            l_tabl = l_func.GetTable("T_TANK_CONVERT")
            If Not l_tabl Is Nothing Then
                For p_Count = 0 To l_tabl.RowCount - 1
                    p_TankSAP = l_tabl.Item(p_Count).Item("TANK").GetValue.ToString
                    p_TankHTTG = l_tabl.Item(p_Count).Item("TANK_HTTG").GetValue.ToString
                    If p_TankSAP = "" Then
                        Continue For
                    End If
                    'p_ComCode = Strings.Right(p_ComCode, 4)
                    p_SQL = " MERGE [tblTankMapSAP] AS target   USING (	"
                    p_SQL = p_SQL & " select '" & p_Plant & "' as Plant, N'" & p_TankSAP & "' as TankSAP, N'" & p_TankHTTG & "' as TankHTTG,  '" & p_User & "' as CreateUser "
                    p_SQL = p_SQL & " ) AS source (Plant, TankSAP, TankHTTG, CreateUser )  " & _
                            " ON (target.TankHTTG = source.TankHTTG)   " & _
                            " WHEN MATCHED THEN " & _
                            " UPDATE SET TankSAP = source.TankSAP , CreateUser = source.CreateUser " & _
                            " WHEN NOT MATCHED THEN   " & _
                            " INSERT(Plant, TankSAP, TankHTTG, CreateUser) " & _
                            " VALUES (source.Plant, source.TankSAP, source.TankHTTG, source.CreateUser)  ;"
                    p_Row = p_TableReturn.NewRow
                    p_Row.Item("ParValue") = p_SQL
                    p_TableReturn.Rows.Add(p_Row)

                Next
            End If



            '   RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)

            Return p_TableReturn

        Catch ex As Exception
            Try
                '   RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            o_err = ex.Message.ToString()
            Return Nothing
        End Try


    End Function




    'anhqh
    '
    '20200505  Ham lay thông tin cacbe Map cua SAP va HTTG
    Public Function Get_ToKhaiTaiXuat_Infor(ByVal p_CompanyCode As String, ByVal i_date As String, ByVal p_User As String, ByRef o_err As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Row As DataRow
        Dim p_MST As String = ""
        Dim p_TankSAP, p_TankHTTG, p_House_UM, p_Street, p_City, p_Country As String
        Try


            p_TableReturn.Columns.Add("ParValue")

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try
            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZFM_GET_TON_TOKHAI")

            l_func.SetValue("I_BUKRS", p_CompanyCode)
            l_func.Invoke(_ecc)

            'l_func.
            ''anhqh  20200729   day bang LogHist
            p_SQL = HistStringSyn("ToKhai", True)
            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParValue") = p_SQL
            p_TableReturn.Rows.Add(p_Row)

            l_tabl = l_func.GetTable("T_TONTK")
            If Not l_tabl Is Nothing Then
                For p_Count = 0 To l_tabl.RowCount - 1

                    p_SQL = " MERGE tblToKhaiTaiXuat AS target   USING (	"
                    p_SQL = p_SQL & " select '" & l_tabl.Item(p_Count).Item("BUKRS").GetValue.ToString & "' as BUKRS " & _
                                ", '" & l_tabl.Item(p_Count).Item("TK_NUMBER").GetValue.ToString & "' as TK_NUMBER " & _
                                ", '" & l_tabl.Item(p_Count).Item("R_KWMENG1").GetValue.ToString & "' as R_KWMENG1 " & _
                                ", '" & l_tabl.Item(p_Count).Item("R_KWMENG2").GetValue.ToString & "' as R_KWMENG2 " & _
                                ", '" & l_tabl.Item(p_Count).Item("USE_F_DATE").GetValue.ToString & "' as USER_F_DATE " & _
                                ", '" & l_tabl.Item(p_Count).Item("USE_T_DATE").GetValue.ToString & "' as USER_T_DATE " & _
                                 ", '" & l_tabl.Item(p_Count).Item("MEINS").GetValue.ToString & "' as MEINS " & _
                                 ", '" & Right(l_tabl.Item(p_Count).Item("MATNR").GetValue.ToString, 7) & "' as MaHangHoa " & _
                                "  "

                    p_SQL = p_SQL & " ) AS source (BUKRS ,TK_NUMBER,R_KWMENG1,R_KWMENG2,USER_F_DATE,USER_T_DATE ,MEINS, MaHangHoa )  " & _
                            " ON (target.TK_NUMBER =source.TK_NUMBER and target.BUKRS=source.BUKRS " & _
                                " )   " & _
                            " WHEN MATCHED THEN " & _
                            " UPDATE SET R_KWMENG1 = source.R_KWMENG1, R_KWMENG2=source.R_KWMENG2 , USER_F_DATE=source.USER_F_DATE " & _
                                ", USER_T_DATE=source.USER_T_DATE , MEINS=source.MEINS , SYNDATE =getdate(), SYNUSER ='" & p_User & "', MaHangHoa=source.MaHangHoa  " & _
                            " WHEN NOT MATCHED THEN   " & _
                            " INSERT(BUKRS ,TK_NUMBER,R_KWMENG1,R_KWMENG2,USER_F_DATE,USER_T_DATE ,MEINS,SYNDATE,SYNUSER, MaHangHoa ) " & _
                            " VALUES (source.BUKRS ,source.TK_NUMBER,source.R_KWMENG1,source.R_KWMENG2," & _
                            "   source.USER_F_DATE,source.USER_T_DATE ,source.MEINS, getdate(), '" & p_User & "', source.MaHangHoa)  ;"


                    p_Row = p_TableReturn.NewRow
                    p_Row.Item("ParValue") = p_SQL
                    p_TableReturn.Rows.Add(p_Row)

                Next
            End If
            If p_TableReturn.Rows.Count > 0 Then
                p_SQL = getStringSyn("ToKhai", p_TableReturn.Rows.Count, 1)
                p_Row = p_TableReturn.NewRow
                p_Row.Item("ParValue") = p_SQL
                p_TableReturn.Rows.Add(p_Row)

              
            End If
           
            ''anhqh  20200729   day bang LogHist
            p_SQL = HistStringSyn("ToKhai: " & p_TableReturn.Rows.Count, False)
            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParValue") = p_SQL
            p_TableReturn.Rows.Add(p_Row)
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception

            End Try


            Return p_TableReturn

        Catch ex As Exception
            Try
                '   RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            o_err = ex.Message.ToString()
            Return Nothing
        End Try


    End Function



    'anhqh
    '
    '20200505  Ham lay thông tin Cong ty, don vi
    Public Function Get_KHo_Infor(ByRef o_err As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Row As DataRow
        Dim p_ComCode, p_MaKho, p_TenKho As String
        Try


            p_TableReturn.Columns.Add("ParValue")

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)

            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try
            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZBAPI_FM_GETT001W_TD")

            '  l_func = repository.CreateFunction("ZBAPI_FM_GET_COMPANYCODE")
            ' l_func.SetValue("I_BUKRS", g_CompanyCode)
            l_func.Invoke(_ecc)

            'l_func.
            l_tabl = l_func.GetTable("T_PLANT")
            If Not l_tabl Is Nothing Then
                For p_Count = 0 To l_tabl.RowCount - 1
                    p_ComCode = l_tabl.Item(p_Count).Item("MaDonVi").GetValue.ToString    ' l_tabl.Item(p_Count).GetValue("CONRG")
                    p_TenKho = l_tabl.Item(p_Count).Item("TenKho").GetValue.ToString  ' l_tabl.Item(p_Count).GetValue("TXTMI")
                    p_MaKho = l_tabl.Item(p_Count).Item("MaKho").GetValue.ToString
                    p_SQL = " MERGE tblKho AS target   USING (	"
                    p_SQL = p_SQL & " select '" & p_ComCode & "' as MaDonVi, N'" & p_TenKho & "' as TenKho, '" & p_MaKho & "' as MaKho "
                    p_SQL = p_SQL & " ) AS source (MaDonVi, TenKho, MaKho )  " & _
                            " ON (target.MaKho = source.MaKho)   " & _
                            " WHEN MATCHED THEN " & _
                            " UPDATE SET TenKho = source.TenKho, MaDonVi=source.MaDonVi " & _
                            " WHEN NOT MATCHED THEN   " & _
                            " INSERT(MaDonVi, TenKho, MaKho) " & _
                            " VALUES (source.MaDonVi, source.TenKho, source.MaKho)  ;"
                    p_Row = p_TableReturn.NewRow
                    p_Row.Item("ParValue") = p_SQL
                    p_TableReturn.Rows.Add(p_Row)

                Next
            End If

          
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception

            End Try


            Return p_TableReturn

        Catch ex As Exception
            Try
                'RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            o_err = ex.Message.ToString()
            Return Nothing
        End Try


    End Function



    'anhqh
    '
    '20200505  Ham lay thông tin Nha cungCap
    Public Function Get_NhaCungCap_Infor(ByRef o_err As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Row As DataRow
        Dim p_ComCode, p_MaKho, p_TenKho As String
        Try


            p_TableReturn.Columns.Add("ParValue")

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try

            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZBAPI_FM_VENDOR_2_ND")
            '  g_Company_Code, i_date, i_getall
            '  l_func = repository.CreateFunction("ZBAPI_FM_GET_COMPANYCODE")
            l_func.SetValue("I_COMPANYCODE", g_CompanyCode)
            l_func.SetValue("I_FLAG", "A")
            l_func.Invoke(_ecc)

            'l_func.
            ''anhqh  20200729   day bang LogHist
            p_SQL = HistStringSyn("NhaCC", True)
            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParValue") = p_SQL
            p_TableReturn.Rows.Add(p_Row)
            l_tabl = l_func.GetTable("T_VENDOR")
            If Not l_tabl Is Nothing Then
                For p_Count = 0 To l_tabl.RowCount - 1
                    p_ComCode = l_tabl.Item(p_Count).Item("VENDORCODE").GetValue.ToString    ' l_tabl.Item(p_Count).GetValue("CONRG")
                    p_TenKho = l_tabl.Item(p_Count).Item("VENDORNAME").GetValue.ToString  ' l_tabl.Item(p_Count).GetValue("TXTMI")
                    p_MaKho = l_tabl.Item(p_Count).Item("VENDORVAT").GetValue.ToString
                    p_SQL = " MERGE tblNhaCungCap AS target   USING (	"
                    p_SQL = p_SQL & " select '" & p_ComCode & "' as MaNhaCungCap, N'" & p_TenKho & "' as TenNhaCungCap, '" & p_MaKho & "' as MaSoThue "
                    p_SQL = p_SQL & " ) AS source (MaNhaCungCap, TenNhaCungCap, MaSoThue )  " & _
                            " ON (target.MaNhaCungCap = source.MaNhaCungCap)   " & _
                            " WHEN MATCHED THEN " & _
                            " UPDATE SET TenNhaCungCap = source.TenNhaCungCap, MaSoThue=source.MaSoThue " & _
                            " WHEN NOT MATCHED THEN   " & _
                            " INSERT(MaNhaCungCap, TenNhaCungCap, MaSoThue) " & _
                            " VALUES (source.MaNhaCungCap, source.TenNhaCungCap, source.MaSoThue)  ;"
                    p_Row = p_TableReturn.NewRow
                    p_Row.Item("ParValue") = p_SQL
                    p_TableReturn.Rows.Add(p_Row)

                Next

                If p_TableReturn.Rows.Count > 0 Then
                    p_SQL = getStringSyn("NhaCC", p_TableReturn.Rows.Count, 1)
                    p_Row = p_TableReturn.NewRow
                    p_Row.Item("ParValue") = p_SQL
                    p_TableReturn.Rows.Add(p_Row)

                 

                End If


             
            End If

            ''anhqh  20200729   day bang LogHist
            p_SQL = HistStringSyn("NhaCC: " & p_TableReturn.Rows.Count, False)
            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParValue") = p_SQL
            p_TableReturn.Rows.Add(p_Row)
            Try
                '   RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception

            End Try


            Return p_TableReturn

        Catch ex As Exception
            Try
                '  RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            o_err = ex.Message.ToString()
            Return Nothing
        End Try


    End Function




    'anhqh
    '
    '20200505  Ham lay thông tin Nha cungCap
    Public Function Get_STO_Infor(ByRef o_err As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Row As DataRow
        Dim p_ComCode, p_MaKho, p_TenKho, p_BEDAT, p_EINDT As String
        Try
            Dim p_tblWhs As String = ""
            Dim p_tblDataTable As DataTable


            'p_SQL = " if  COL_LENGTH('tblSTO','BEDAT') is null " & _
            '       "  begin alter table  tblSTO add BEDAT DateTime, EINDT datetime " & _
            '           "  end;"

            'If g_Services.Sys_Execute(p_SQL, _
            '                          p_SQL) = False Then


            'End If

            p_TableReturn.Columns.Add("ParValue")


            p_SQL = "select warehouse from tblconfig "
            p_tblDataTable = GetDataTableSQL(p_SQL, p_SQL)
            If Not p_tblDataTable Is Nothing Then
                If p_tblDataTable.Rows.Count > 0 Then
                    p_tblWhs = p_tblDataTable.Rows(0).Item(0).ToString.Trim
                End If
            End If
            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try
            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZBAPI_FM_GET_STO")
            '  g_Company_Code, i_date, i_getall
            '  l_func = repository.CreateFunction("ZBAPI_FM_GET_COMPANYCODE")
            l_func.SetValue("I_PLANT", p_tblWhs)

            l_func.Invoke(_ecc)

            'l_func.
            l_tabl = l_func.GetTable("T_STO_HEADER")

            p_SQL = HistStringSyn("STO", True)
            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParValue") = p_SQL
            p_TableReturn.Rows.Add(p_Row)

            If Not l_tabl Is Nothing Then
                For p_Count = 0 To l_tabl.RowCount - 1
                    p_ComCode = l_tabl.Item(p_Count).Item("EBELN").GetValue.ToString    'So STO
                    p_TenKho = l_tabl.Item(p_Count).Item("BSART").GetValue.ToString  ' PO Type
                    p_MaKho = l_tabl.Item(p_Count).Item("WERKS").GetValue.ToString


                    If l_tabl.Item(p_Count).Item("BEDAT").GetValue.ToString <> "" Then
                        p_BEDAT = CDate(l_tabl.Item(p_Count).Item("BEDAT").GetValue).ToString("yyyyMMdd")
                        p_BEDAT = "'" & p_BEDAT & "'"
                    Else
                        p_BEDAT = "Null"
                    End If

                    If l_tabl.Item(p_Count).Item("EINDT").GetValue.ToString <> "" Then
                        p_EINDT = l_tabl.Item(p_Count).Item("EINDT").GetValue.ToString
                        p_EINDT = "'" & p_EINDT & "'"
                    Else
                        p_EINDT = "Null"
                    End If



                    p_SQL = " MERGE tblSTO AS target   USING (	"
                    p_SQL = p_SQL & " select '" & p_ComCode & "' as EBELN, N'" & p_TenKho & "' as BSART, '" & _
                                            p_MaKho & "' as WERKS, " & p_BEDAT & " as BEDAT ,  " & p_EINDT & " as EINDT "
                    p_SQL = p_SQL & " ) AS source (EBELN, BSART, WERKS, BEDAT ,EINDT)  " & _
                            " ON (target.EBELN = source.EBELN)   " & _
                            " WHEN MATCHED THEN " & _
                            " UPDATE SET BSART = source.BSART, WERKS=source.WERKS, BEDAT=source.BEDAT " & _
                            " WHEN NOT MATCHED THEN   " & _
                            " INSERT(EBELN, BSART, WERKS, BEDAT ) " & _
                            " VALUES (source.EBELN, source.BSART, source.WERKS,  source.BEDAT )  ;"
                    p_Row = p_TableReturn.NewRow
                    p_Row.Item("ParValue") = p_SQL
                    p_TableReturn.Rows.Add(p_Row)

                Next
            End If


            Try
                '  RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception

            End Try

            If p_TableReturn.Rows.Count > 0 Then
                p_SQL = "UPDATE tblSTO set EINDT =  convert(date,DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,isnull(BEDAT,getdate()))+1,0))) "
                p_Row = p_TableReturn.NewRow
                p_Row.Item("ParValue") = p_SQL
                p_TableReturn.Rows.Add(p_Row)


            End If


            If p_TableReturn.Rows.Count > 0 Then
                p_SQL = getStringSyn("STO", p_TableReturn.Rows.Count, 1)
                p_Row = p_TableReturn.NewRow
                p_Row.Item("ParValue") = p_SQL
                p_TableReturn.Rows.Add(p_Row)

              
            End If

            ''anhqh  20200729   day bang LogHist
            p_SQL = HistStringSyn("STO: " & p_TableReturn.Rows.Count, False)
            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParValue") = p_SQL
            p_TableReturn.Rows.Add(p_Row)
            Return p_TableReturn

        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            o_err = ex.Message.ToString()
            Return Nothing
        End Try


    End Function





    'anhqh
    '
    '20200505  Ham lay thông tin Nha cungCap
    Public Function Get_TyGia_Infor(ByVal p_DateIn As String, ByRef o_err As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Row As DataRow
        Dim p_ComCode, p_MaKho, p_TenKho As String
        Dim p_CurrenDate As String = ""
        Dim p_Date As String = ""
        Try
            Dim p_tblWhs As String = ""
            Dim p_tblDataTable As DataTable

            p_Date = p_DateIn
            p_TableReturn.Columns.Add("ParValue")


            p_SQL = "select warehouse,convert(date, getdate() -1) as dDate from tblconfig "
            p_tblDataTable = GetDataTableSQL(p_SQL, p_SQL)
            If Not p_tblDataTable Is Nothing Then
                If p_tblDataTable.Rows.Count > 0 Then
                    p_tblWhs = p_tblDataTable.Rows(0).Item(0).ToString.Trim
                    If p_Date = "" Then
                        p_Date = CDate(p_tblDataTable.Rows(0).Item(1)).ToString("yyyyMMdd")
                        p_CurrenDate = CDate(p_tblDataTable.Rows(0).Item(1)).ToString("yyyy.MM.dd")
                    End If

                End If
            End If
            p_Date = Replace(p_Date, ".", "")
            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try

            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZBAPI_FM_GET_EXC_RATE")
            '  g_Company_Code, i_date, i_getall
            '  l_func = repository.CreateFunction("ZBAPI_FM_GET_COMPANYCODE")
            ' l_func.SetValue("I_VKORD", g_CompanyCode)
            l_func.SetValue("I_DATE", p_Date)

            l_func.Invoke(_ecc)

            'l_func.
            ''anhqh  20200729   day bang LogHist
            p_SQL = HistStringSyn("TyGia", True)
            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParValue") = p_SQL
            p_TableReturn.Rows.Add(p_Row)
            l_tabl = l_func.GetTable("T_EXCHANGE_RATE")
            If Not l_tabl Is Nothing Then
                For p_Count = 0 To l_tabl.RowCount - 1

                    p_SQL = " MERGE tblTyGia AS target   USING (	"
                    p_SQL = p_SQL & " select '" & l_tabl.Item(p_Count).Item("MANDT").GetValue.ToString & "' as MANDT " & _
                                ", '" & l_tabl.Item(p_Count).Item("KURST").GetValue.ToString & "' as KURST_CURR " & _
                                ", '" & l_tabl.Item(p_Count).Item("FCURR").GetValue.ToString & "' as FCURR_CURR " & _
                                ", '" & l_tabl.Item(p_Count).Item("TCURR").GetValue.ToString & "' as TCURR_CURR " & _
                                ", '" & l_tabl.Item(p_Count).Item("GDATU").GetValue.ToString & "' as GDATU_INV " & _
                                ", " & l_tabl.Item(p_Count).Item("UKURS").GetValue.ToString & " as UKURS_CURR " & _
                                 ", " & l_tabl.Item(p_Count).Item("FFACT").GetValue.ToString & " as FFAC_CURR " & _
                                ", " & l_tabl.Item(p_Count).Item("TFACT").GetValue.ToString & " as TFACT_CURR "

                    p_SQL = p_SQL & " ) AS source (MANDT ,KURST_CURR,FCURR_CURR,TCURR_CURR,GDATU_INV,UKURS_CURR,FFAC_CURR,TFACT_CURR )  " & _
                            " ON (target.MANDT =source.MANDT and target.KURST_CURR=source.KURST_CURR " & _
                                " and target.FCURR_CURR=source.FCURR_CURR  and target.TCURR_CURR=source.TCURR_CURR  and  target.GDATU_INV = source.GDATU_INV)   " & _
                            " WHEN MATCHED THEN " & _
                            " UPDATE SET UKURS_CURR = source.UKURS_CURR, FFAC_CURR=source.FFAC_CURR , TFACT_CURR=source.TFACT_CURR, [UpdateDate] =getdate() " & _
                            " WHEN NOT MATCHED THEN   " & _
                            " INSERT([CreatDate], MANDT ,KURST_CURR,FCURR_CURR,TCURR_CURR,GDATU_INV,UKURS_CURR,FFAC_CURR,TFACT_CURR) " & _
                            " VALUES (getdate(), source.MANDT ,source.KURST_CURR,source.FCURR_CURR,source.TCURR_CURR,source.GDATU_INV,source.UKURS_CURR,source.FFAC_CURR,source.TFACT_CURR)  ;"
                    p_Row = p_TableReturn.NewRow
                    p_Row.Item("ParValue") = p_SQL
                    p_TableReturn.Rows.Add(p_Row)

                Next
            End If


            Try
                '  RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception

            End Try

            If p_TableReturn.Rows.Count > 0 Then
                p_SQL = getStringSyn("TyGia", p_TableReturn.Rows.Count, 1)
                p_Row = p_TableReturn.NewRow
                p_Row.Item("ParValue") = p_SQL
                p_TableReturn.Rows.Add(p_Row)

            

            End If

            ''anhqh  20200729   day bang LogHist
            p_SQL = HistStringSyn("TyGia: " & p_TableReturn.Rows.Count, False)
            p_Row = p_TableReturn.NewRow
            p_Row.Item("ParValue") = p_SQL
            p_TableReturn.Rows.Add(p_Row)


            Return p_TableReturn

        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            o_err = ex.Message.ToString()
            Return Nothing
        End Try




    End Function



    Private Function getStringSyn(ByVal p_Para As String, ByVal p_Count As Integer, Optional ByVal p_Int As Integer = 0) As String
        Dim p_SQL As String = ""
        Try
            p_SQL = "MERGE tblLogSyn AS target " & _
                       " USING (	SELECT 0 as [Stt] ,'" & p_Para & "' as [Para] ,convert(nvarchar(20),getdate()-" & p_Int & ",102) as [SynDate]  ," & p_Count & " as [SynCount]  " & _
                        " ) AS source ([Stt] ,[Para] ,[SynDate]  , [SynCount] ) on  (target.Para =Source.Para )  " & _
                        " WHEN MATCHED  THEN UPDATE SET SynDate =source.SynDate , dDate =Source.SynDate " & _
                        " WHEN NOT MATCHED THEN  " & _
                    " Insert([Stt], [Para], [SynDate], [SynCount], dDate) " & _
                        " VALUES ((select isnull( max(stt),0) +1 from tblLogSyn), Source.Para,source.SynDate, Source.SynCount, Source.SynDate) ;"
        Catch ex As Exception
            p_SQL = ""
        End Try
        Return p_SQL
    End Function



    Public Function HistStringSyn(ByVal p_Para As String, ByVal p_From As Boolean) As String
        Dim p_SQL As String = ""
        Try
            If p_From = True Then
                p_SQL = "INSERT INTO [dbo].[tblLogSyn_Hist]([Para],[dDate])  VALUES ('" & p_Para & "',getdate());"
            Else
                p_SQL = "INSERT INTO [dbo].[tblLogSyn_Hist]([Para],[ToDate])  VALUES ('" & p_Para & "',getdate());"
            End If

            'If g_Services.Sys_Execute(p_SQL, p_SQL) Then

            'End If
            Return p_SQL
        Catch ex As Exception
            p_SQL = ""
        End Try

    End Function


    Public Function GetDataTableSQL(ByVal p_SQL As String, ByRef p_Error As String) As DataTable
        Dim p_Datatable As DataTable
        Try
            p_Datatable = g_Services.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Error)
        Catch ex As Exception
            p_Error = ex.Message
            'ShowMessageBox(Err.Number, p_Error)
            Return Nothing
        End Try
        Return p_Datatable

    End Function




    Public Function DongBoATG(ByVal p_TankHeaderCode As String, ByVal p_Plant_DB As String, ByVal p_TableATG As DataTable, ByVal p1_User As String, ByRef o_err As String) As DataTable
        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository

        Dim l_tabl_ATG, p_TableError, p_tReturn As IRfcTable
        'Dim p_SQL As String

        Dim p_SapConnectionString As String
        Dim p_Code As String = ""
        Dim p_SQL As String

        Dim p_Tank As String
        '    Dim p_Plant_DB As String = ""
        Dim p_Status As String = ""
        '  Dim p_TankHeaderCode As String = ""
        Dim p_sType As String = ""
        Dim p_row As DataRow
        Dim p_MucDD As String = ""
        ' Dim p_SQL As String = ""
        Dim p_TableCheck As DataTable
        Dim p_Count As Integer = 0
        Dim p_Value As Double
        Dim p_DataReturn As New DataTable("Table001")
        Dim p_ChieuCaoNuoc As Double
        Dim p_Dbt As DataTable
        ' Dim p_sType As String = ""
        Try
            o_err = ""

            p_SQL = "select sType from [dbo].[ztblTankHeaderImp]  where TankHeaderCode ='" & p_TankHeaderCode & "'"
            p_Dbt = GetDataTableSQL(p_SQL, p_SQL)

            If Not p_Dbt Is Nothing Then
                If p_Dbt.Rows.Count > 0 Then
                    p_sType = p_Dbt.Rows(0).Item("sType").ToString.Trim
                End If
            End If
           

            p_DataReturn.Columns.Add("STR_SQL")

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try



            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try

            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZBAPI_FM_INT_DOBE_V1")

            l_tabl_ATG = l_func.GetTable("T_TANK_DIPS")


            For Each row As DataRow In p_TableATG.Rows
                If row.Item("X").ToString.Trim <> "Y" Then
                    Continue For
                End If

                If row.Item("Dens").ToString().ToString.Trim = "" Then
                    Continue For
                End If
                Try
                    If row.Item("Status").ToString().ToString.Trim = "E" Then
                        Continue For
                    End If
                Catch ex As Exception

                End Try
                p_SQL = "Select WaterHeight from ztblTankLineImp where Id=" & row.Item("ID").ToString.Trim
                p_Dbt = GetDataTableSQL(p_SQL, p_SQL)
                p_ChieuCaoNuoc = 0
                If Not p_Dbt Is Nothing Then
                    If p_Dbt.Rows.Count > 0 Then
                        Double.TryParse(p_Dbt.Rows(0).Item("WaterHeight").ToString.Trim, p_ChieuCaoNuoc)
                    End If
                End If

                l_tabl_ATG.Append()


                l_tabl_ATG.SetValue("PLANT", p_Plant_DB)
                l_tabl_ATG.SetValue("HTTG_ID", row.Item("ID").ToString.Trim)
                p_Tank = row.Item("TankMap").ToString.Trim
                If p_Tank = "" Then
                    p_Tank = row.Item("TankCode").ToString()
                End If
                l_tabl_ATG.SetValue("STGE_LOC", p_Tank)
                l_tabl_ATG.SetValue("SEQ_NO", p_Tank)

                l_tabl_ATG.SetValue("DIP_DATE", Format(row.Item("CrDate"), "yyyy-MM-dd").ToString())
                l_tabl_ATG.SetValue("DIP_TIME", Format(row.Item("CrDate"), "HH:mm:ss").ToString())
                l_tabl_ATG.SetValue("TOTALHEIGHT", Convert.ToDecimal(row.Item("TankHeight")))
                l_tabl_ATG.SetValue("TOTH_UOM", "MM")
                l_tabl_ATG.SetValue("MAT_TEMP_STR", String.Format("{0:0.00}", row.Item("TankTemp")))

                Try
                    l_tabl_ATG.SetValue("WATERHEIGHT", p_ChieuCaoNuoc)

                Catch ex3 As Exception
                    p_SQL = ex3.Message
                End Try
               

                Try
                    l_tabl_ATG.SetValue("TANKGROUP", row.Item("NhomBeXuat").ToString.Trim)

                Catch ex31 As Exception
                    p_SQL = ex31.Message
                End Try


                If row.Item("Dens").ToString.Trim <> "" Then
                    Double.TryParse(row.Item("Dens").ToString.Trim, p_Value)
                End If
                If p_Value = 0 Then
                    l_tabl_ATG.SetValue("TEST_DENS_STR", "")
                Else
                    l_tabl_ATG.SetValue("TEST_DENS_STR", row.Item("Dens").ToString())
                End If

                l_tabl_ATG.SetValue("SOC_EVENT_STR", "M1")
                Try
                    If row.Item("PurposeCode").ToString.Trim <> "" Then
                        l_tabl_ATG.SetValue("SOC_EVENT_STR", row.Item("PurposeCode").ToString.Trim)
                    End If
                Catch ex2 As Exception
                    p_SQL = ex2.Message
                End Try

                Try
                    If row.Item("BAREM_HEIGHT").ToString.Trim = "Y" Then
                        l_tabl_ATG.SetValue("FLG_BAREM_HEIGHT", "X")
                    End If
                Catch ex As Exception
                    p_SQL = ex.Message
                End Try
                Try
                    If row.Item("BAREM_WATER").ToString.Trim = "Y" Then
                        l_tabl_ATG.SetValue("FLG_BAREM_WATER", "X")
                    End If
                Catch ex1 As Exception
                    p_SQL = ex1.Message
                End Try

                Try
                    If p_sType = "A" Then
                        l_tabl_ATG.SetValue("STATUS_ATG", "X")
                    End If
                Catch ex1 As Exception
                    p_SQL = ex1.Message
                End Try



                '  l_tabl_ATG.SetValue("WATERHEIGHT", 0)
                l_tabl_ATG.SetValue("WATH_UOM", "MM")
                '   l_str_Tank.Wath_Uom = "MM"
                ' l_str_Tank.
                ' l_str_Tank.Stt = row.Item("ID").ToString.Trim
                l_tabl_ATG.SetValue("UNAME", p1_User)
            Next



            l_func.Invoke(_ecc)
            l_ret2 = l_func.GetStructure("RETURN") '
            p_TableError = l_func.GetTable("T_TANK_DIPS_RET")
            ' Dim p_Value As Integer
            'p_tReturn = l_func.GetTable("T_RETURN")

            Dim p_OK As Boolean = False

            For p_Count = 0 To p_TableError.RowCount - 1
                p_SQL = p_TableError.Item(p_Count).Item("STATUS_ND").GetValue.ToString ' 
                If p_SQL = "E" Then
                    p_row = p_DataReturn.NewRow
                    Double.TryParse(p_TableError.Item(p_Count).Item("HTTG_ID").GetValue.ToString, p_Value)
                    p_SQL = "Update    ztblTankLineImp    set   Description =N'Lỗi đồng bộ', Status ='E' where  ID =" & p_Value
                    p_row.Item(0) = p_SQL
                    p_DataReturn.Rows.Add(p_row)
                ElseIf p_SQL = "S" Then
                    p_row = p_DataReturn.NewRow
                    Double.TryParse(p_TableError.Item(p_Count).Item("HTTG_ID").GetValue.ToString, p_Value)
                    p_SQL = "Update    ztblTankLineImp    set   Description =N'Đồng bộ thành công', Status ='S' where  ID =" & p_Value
                    p_row.Item(0) = p_SQL
                    p_DataReturn.Rows.Add(p_row)
                    p_OK = True
                End If
            Next
            If p_OK = True Then
                p_row = p_DataReturn.NewRow
                ' Double.TryParse(p_TableError.Item(p_Count).Item("HTTG_ID").GetValue.ToString, p_Value)
                p_SQL = "Update ztblTankHeaderImp set Status ='S', SyncDate =getdate()  ,SyncUser  ='" & p1_User & "' where TankHeaderCode = '" & p_TankHeaderCode & "'"
                p_row.Item(0) = p_SQL
                p_DataReturn.Rows.Add(p_row)
            End If

            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception

            End Try

            Return p_DataReturn
        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            o_err = ex.Message.ToString()
            Return Nothing
        End Try
    End Function





    Public Function DongBoHopDong(ByVal p_Company As String, ByVal i_date As String, _
                                ByVal p1_User As String, ByRef o_err As String, Optional ByVal p_GetAll As Boolean = False) As DataTable
        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_tabl_detail As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository

        Dim p_SQL As String


        Dim p_row As DataRow

        ' Dim p_SQL As String = ""
        Dim p_TableCheck As DataTable
        Dim p_Count As Integer = 0
        Dim p_CountHeader As Integer = 0
        Dim p_Value As Double
        Dim p_PhuongThucBan As String = ""
        Dim p_DataReturn As New DataTable("Table001")
        Dim p_DataTable As DataTable
        Dim p_TableSoLenh As New DataTable("Table002")
        Dim p_RowSoLenh As DataRow
        Dim p_Int As Integer
        Dim p_All_Project As Boolean = False

        Dim p_CheckError As Boolean = False
        Try
            o_err = ""

            p_TableSoLenh.Columns.Add("SoLenh")

            'If p_GetAll = False Then
            '    p_SQL = "select KeyValue from sys_config  where upper(KeyCode) =upper('ALL_PROJECT')"

            '    p_DataTable = GetDataTableSQL(p_SQL, p_SQL)
            '    If Not p_DataTable Is Nothing Then
            '        If p_DataTable.Rows.Count > 0 Then
            '            If p_DataTable.Rows(0).Item(0).ToString.Trim = "Y" Then
            '                p_All_Project = True
            '            End If
            '        End If
            '    End If
            'Else
            '    p_All_Project = True
            'End If

            p_All_Project = p_GetAll

            If p_DataReturn Is Nothing Then
                p_DataReturn = New DataTable("Table001")
            End If
            p_DataReturn.Columns.Add("STR_SQL")

            'If p_DataTable Is Nothing Then
            '    Return Nothing
            'End If

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)

            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try
            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZBAPI_GET_CONTRACT_HTTG")
            l_func.SetValue("I_BUKRS", p_Company)
            If p_All_Project = True Then
                l_func.SetValue("I_MODE", "1")
            Else
                l_func.SetValue("I_MODE", "2")
            End If
            '  l_func.SetValue("I_DATE", i_date)
            'l_func.SetValue("I_DC", p_PhuongThucBan)
            '   l_func.SetValue("I_DIVISION", "00")
            l_func.Invoke(_ecc)
            l_tabl = l_func.GetTable("T_CONTRACT")
            l_tabl_detail = l_func.GetTable("T_CONTRACT_DTL")
            If Not l_tabl Is Nothing Then
                p_DataReturn.Clear()
                p_Int = l_tabl.RowCount
                p_Int = l_tabl_detail.RowCount
                For p_Count = 0 To l_tabl.RowCount - 1
                    'Vbeln

                    p_RowSoLenh = p_TableSoLenh.NewRow
                    p_RowSoLenh.Item(0) = Replace(l_tabl.Item(p_Count).Item("VBELN").GetValue.ToString, "'", "", 1)
                    If Replace(l_tabl.Item(p_Count).Item("VBELN").GetValue.ToString, "'", "", 1) = "0040043537" Then
                        p_Int = p_Int
                    End If
                    p_TableSoLenh.Rows.Add(p_RowSoLenh)

                    p_SQL = "MERGE tblProjects AS target " & _
                      " USING (SELECT N'" & Replace(l_tabl.Item(p_Count).Item("AUART").GetValue.ToString, "'", "", 1) & "' as Auart ," & _
                               "N'" & Replace(l_tabl.Item(p_Count).Item("GUEBG").GetValue.ToString, "'", "", 1) & "'  as Guebg," & _
                                "N'" & Replace(l_tabl.Item(p_Count).Item("GUEEN").GetValue.ToString, "'", "", 1) & "'  as Gueen," & _
                                 "N'" & Replace(l_tabl.Item(p_Count).Item("INCO1").GetValue.ToString, "'", "", 1) & "'  as Inco1," & _
                                  "N'" & Replace(l_tabl.Item(p_Count).Item("KUNNR").GetValue.ToString, "'", "", 1) & "'  as Kunnr," & _
                                   "N'" & Replace(l_tabl.Item(p_Count).Item("MATNR").GetValue.ToString, "'", "", 1) & "'  as Matnr," & _
                                    "N'" & Replace(l_tabl.Item(p_Count).Item("MEINS").GetValue.ToString, "'", "", 1) & "'  as Meins," & _
                                     "N'" & Replace(l_tabl.Item(p_Count).Item("POSNR").GetValue.ToString, "'", "", 1) & "'  as Posnr," & _
                                 "N'" & Replace(l_tabl.Item(p_Count).Item("SPART").GetValue.ToString, "'", "", 1) & "'  as Spart," & _
                                 "N'" & Replace(l_tabl.Item(p_Count).Item("VBELN").GetValue.ToString, "'", "", 1) & "'  as Vbeln," & _
                                 "N'" & Replace(l_tabl.Item(p_Count).Item("VBTYP").GetValue.ToString, "'", "", 1) & "'  as Vbtyp," & _
                                 "N'" & Replace(l_tabl.Item(p_Count).Item("VKORG").GetValue.ToString, "'", "", 1) & "'  as Vkorg," & _
                                  "N'" & Replace(l_tabl.Item(p_Count).Item("VTWEG").GetValue.ToString, "'", "", 1) & "'  as Vtweg," & _
                                     "N'" & Replace(l_tabl.Item(p_Count).Item("ZLSCH").GetValue.ToString, "'", "", 1) & "'  as ZLSCH," & _
                                 "N'" & Replace(l_tabl.Item(p_Count).Item("ZTERM").GetValue.ToString, "'", "", 1) & "'  as ZTERM," & _
                                  "N'" & Replace(l_tabl.Item(p_Count).Item("INCO2").GetValue.ToString, "'", "", 1) & "'  as INCO2," & _
                                   "N'" & Replace(l_tabl.Item(p_Count).Item("KONDA").GetValue.ToString, "'", "", 1) & "'  as PriceGroup" & _
                              ") AS source (Auart,Guebg,Gueen,Inco1,Kunnr,Matnr,Meins,Posnr,Spart,Vbeln,Vbtyp ,Vkorg,Vtweg,ZLSCH, ZTERM, INCO2, PriceGroup) " & _
                              " ON (target.Vbeln = source.Vbeln) " & _
                          " WHEN MATCHED  THEN UPDATE SET " & _
                                  "Auart=source.Auart,Guebg=source.Guebg,Gueen=source.Gueen,Inco1=source.Inco1," & _
                                   "Kunnr=source.Kunnr,Matnr=source.Matnr,Meins=source.Meins,Posnr=source.Posnr," & _
                                   "Spart=source.Spart,Vbtyp=source.Vbtyp ,Vkorg=source.Vkorg,Vtweg=source.Vtweg" & _
                                   ",ZLSCH=source.ZLSCH ,ZTERM=source.ZTERM,INCO2=source.INCO2, PriceGroup=source.PriceGroup  " & _
                       " WHEN NOT MATCHED THEN " & _
                          "INSERT  (Auart,Guebg,Gueen,Inco1,Kunnr,Matnr,Meins,Posnr,Spart,Vbeln,Vbtyp ,Vkorg,Vtweg ,ZLSCH, ZTERM, INCO2, PriceGroup ) " & _
                              "VALUES (source.Auart,source.Guebg,source.Gueen,source.Inco1,source.Kunnr,source.Matnr," & _
                              "source.Meins,source.Posnr,source.Spart,source.Vbeln,source.Vbtyp ,source.Vkorg,source.Vtweg,source.ZLSCH, source.ZTERM, source.INCO2, source.PriceGroup) ;"


                    p_row = p_DataReturn.NewRow
                    p_row.Item(0) = p_SQL
                    p_DataReturn.Rows.Add(p_row)

                Next
                o_err = ""
                If p_DataReturn.Rows.Count > 0 Then
                    If g_Services.Sys_Execute_DataTbl(p_DataReturn, o_err) = False Then
                        p_CheckError = True

                    End If

                End If
                p_DataReturn.Clear()
            End If

            'Hop dong chi tiet
            If Not l_tabl_detail Is Nothing Then
                p_DataReturn.Clear()
                For p_Count = 0 To l_tabl_detail.RowCount - 1
                    p_SQL = "MERGE tblProject_Details  AS target " & _
                   " USING (SELECT N'" & Replace(l_tabl_detail.Item(p_Count).Item("AUART").GetValue.ToString, "'", "", 1) & "' as Auart ," & _
                            "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Guebg").GetValue.ToString, "'", "", 1) & "'  as Guebg," & _
                             "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Gueen").GetValue.ToString, "'", "", 1) & "'  as Gueen," & _
                              "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Inco1").GetValue.ToString, "'", "", 1) & "'  as Inco1," & _
                               "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Kunnr").GetValue.ToString, "'", "", 1) & "'  as Kunnr," & _
                                "N'" & Strings.Right(Replace(l_tabl_detail.Item(p_Count).Item("Matnr").GetValue.ToString, "'", "", 1), 7) & "'  as Matnr," & _
                                 "N'" & Replace(l_tabl_detail.Item(p_Count).Item("ZIEME").GetValue.ToString, "'", "", 1) & "'  as Meins," & _
                                  "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Posnr").GetValue.ToString, "'", "", 1) & "'  as Posnr," & _
                              "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Spart").GetValue.ToString, "'", "", 1) & "'  as Spart," & _
                              "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Vbeln").GetValue.ToString, "'", "", 1) & "'  as Vbeln," & _
                              "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Vbtyp").GetValue.ToString, "'", "", 1) & "'  as Vbtyp," & _
                              "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Vkorg").GetValue.ToString, "'", "", 1) & "'  as Vkorg," & _
                               "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Vtweg").GetValue.ToString, "'", "", 1) & "'  as Vtweg" & _
                           ") AS source (Auart,Guebg,Gueen,Inco1,Kunnr,Matnr,Meins,Posnr,Spart,Vbeln,Vbtyp ,Vkorg,Vtweg) " & _
                           " ON (target.Vbeln = source.Vbeln   and   target.Matnr = source.Matnr ) " & _
                       " WHEN MATCHED  THEN UPDATE SET " & _
                               "Auart=source.Auart,Guebg=source.Guebg,Gueen=source.Gueen,Inco1=source.Inco1," & _
                                "Kunnr=source.Kunnr,Matnr=source.Matnr,Meins=source.Meins,Posnr=source.Posnr," & _
                                "Spart=source.Spart,Vbtyp=source.Vbtyp ,Vkorg=source.Vkorg,Vtweg=source.Vtweg" & _
                    " WHEN NOT MATCHED THEN " & _
                       "INSERT  (Auart,Guebg,Gueen,Inco1,Kunnr,Matnr,Meins,Posnr,Spart,Vbeln,Vbtyp ,Vkorg,Vtweg ) " & _
                           "VALUES (source.Auart,source.Guebg,source.Gueen,source.Inco1,source.Kunnr,source.Matnr," & _
                           "source.Meins,source.Posnr,source.Spart,source.Vbeln,source.Vbtyp ,source.Vkorg,source.Vtweg) ;"

                    p_row = p_DataReturn.NewRow
                    p_row.Item(0) = p_SQL
                    p_DataReturn.Rows.Add(p_row)
                Next

                o_err = ""
                If p_DataReturn.Rows.Count > 0 Then
                    If g_Services.Sys_Execute_DataTbl(p_DataReturn, o_err) = False Then
                        p_CheckError = True

                    End If

                End If

                p_DataReturn.Clear()

            End If
            '   Next
            If p_TableSoLenh.Rows.Count > 0 And p_CheckError = False Then

                Dim p_RowID As Integer
                l_func = repository.CreateFunction("ZBAPI_PUT_CONTRACT_HTTG")

                l_tabl = l_func.GetTable("T_CONTRACT") '   


                For p_RowID = 0 To p_TableSoLenh.Rows.Count - 1
                    If p_TableSoLenh.Rows(p_RowID).Item("SoLenh").ToString.Trim <> "" Then
                        l_tabl.Append()
                        l_tabl.SetValue("VBELN", p_TableSoLenh.Rows(p_RowID).Item("SoLenh"))
                    End If

                Next



                Try
                    l_func.Invoke(_ecc)
                Catch ex2 As Exception
                    '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
                    'Lỗi do chưa remote-enable trong tab Atribute của function module
                    o_err = "UpdStatus: " & ex2.Message.ToString()
                    Return Nothing
                End Try



            End If
            'p_SQL = getStringSyn("HopDong", p_DataReturn.Rows.Count, 1)
            'p_row = p_DataReturn.NewRow
            'p_row.Item(0) = p_SQL
            'p_DataReturn.Rows.Add(p_row)

            '' If l_tabl.RowCount > 0 Then
            '''anhqh  20200729   day bang LogHist
            'p_SQL = HistStringSyn("HopDong", False)
            'p_row = p_DataReturn.NewRow
            'p_row.Item(0) = p_SQL
            'p_DataReturn.Rows.Add(p_row)
            ''   End If


            Try
                'RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception

            End Try

            Return p_DataReturn

        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            o_err = ex.Message.ToString()
            Return Nothing
        End Try
    End Function



    'Public Function DongBoHopDong(ByVal p_Company As String, ByVal i_date As String, _
    '                            ByVal p1_User As String, ByRef o_err As String) As DataTable
    '    Dim l_func As IRfcFunction
    '    Dim l_tabl As IRfcTable
    '    Dim l_tabl_detail As IRfcTable
    '    Dim l_ret2 As IRfcStructure
    '    Dim _ecc As RfcDestination
    '    Dim p_TEst As IDestinationConfiguration
    '    Dim p_Table As RfcTableMetadata
    '    Dim repository As RfcRepository ' = _ecc.Repository

    '    Dim p_SQL As String


    '    Dim p_row As DataRow

    '    ' Dim p_SQL As String = ""
    '    Dim p_TableCheck As DataTable
    '    Dim p_Count As Integer = 0
    '    Dim p_CountHeader As Integer = 0
    '    Dim p_Value As Double
    '    Dim p_PhuongThucBan As String = ""
    '    Dim p_DataReturn As New DataTable("Table001")
    '    Dim p_DataTable As DataTable
    '    Dim p_TableSoLenh As New DataTable("Table002")
    '    Dim p_RowSoLenh As DataRow
    '    Dim p_Int As Integer
    '    Try
    '        o_err = ""

    '        p_TableSoLenh.Columns.Add("SoLenh")

    '        p_SQL = "select MaPhuongThucBan from tblPhuongThucBan"

    '        p_DataTable = GetDataTableSQL(p_SQL, p_SQL)

    '        If p_DataReturn Is Nothing Then
    '            p_DataReturn = New DataTable("Table001")
    '        End If
    '        p_DataReturn.Columns.Add("STR_SQL")

    '        If p_DataTable Is Nothing Then
    '            Return Nothing
    '        End If

    '        p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
    '        Try
    '            RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
    '        Catch ex As Exception

    '        End Try

    '        _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
    '        repository = _ecc.Repository


    '        ' For p_CountHeader = 0 To p_DataTable.Rows.Count - 1
    '        ' p_PhuongThucBan = p_DataTable.Rows(p_CountHeader).Item("MaPhuongThucBan").ToString.Trim

    '        l_func = repository.CreateFunction("ZBAPI_FM_CONTRACT_ND")
    '        l_func.SetValue("I_SALEORG", p_Company)
    '        l_func.SetValue("I_DATE", i_date)
    '        'l_func.SetValue("I_DC", p_PhuongThucBan)
    '        l_func.SetValue("I_DIVISION", "00")
    '        l_func.Invoke(_ecc)
    '        l_tabl = l_func.GetTable("T_CONTRACT")
    '        l_tabl_detail = l_func.GetTable("T_CONTRACT_DTL")
    '        If Not l_tabl Is Nothing Then
    '            p_DataReturn.Clear()
    '            p_Int = l_tabl.RowCount
    '            p_Int = l_tabl_detail.RowCount
    '            For p_Count = 0 To l_tabl.RowCount - 1
    '                'Vbeln

    '                p_RowSoLenh = p_TableSoLenh.NewRow
    '                p_RowSoLenh.Item(0) = Replace(l_tabl.Item(p_Count).Item("VBELN").GetValue.ToString, "'", "", 1)
    '                p_TableSoLenh.Rows.Add(p_RowSoLenh)

    '                p_SQL = "MERGE tblProjects AS target " & _
    '                  " USING (SELECT N'" & Replace(l_tabl.Item(p_Count).Item("AUART").GetValue.ToString, "'", "", 1) & "' as Auart ," & _
    '                           "N'" & Replace(l_tabl.Item(p_Count).Item("GUEBG").GetValue.ToString, "'", "", 1) & "'  as Guebg," & _
    '                            "N'" & Replace(l_tabl.Item(p_Count).Item("GUEEN").GetValue.ToString, "'", "", 1) & "'  as Gueen," & _
    '                             "N'" & Replace(l_tabl.Item(p_Count).Item("INCO1").GetValue.ToString, "'", "", 1) & "'  as Inco1," & _
    '                              "N'" & Replace(l_tabl.Item(p_Count).Item("KUNNR").GetValue.ToString, "'", "", 1) & "'  as Kunnr," & _
    '                               "N'" & Replace(l_tabl.Item(p_Count).Item("MATNR").GetValue.ToString, "'", "", 1) & "'  as Matnr," & _
    '                                "N'" & Replace(l_tabl.Item(p_Count).Item("MEINS").GetValue.ToString, "'", "", 1) & "'  as Meins," & _
    '                                 "N'" & Replace(l_tabl.Item(p_Count).Item("POSNR").GetValue.ToString, "'", "", 1) & "'  as Posnr," & _
    '                             "N'" & Replace(l_tabl.Item(p_Count).Item("SPART").GetValue.ToString, "'", "", 1) & "'  as Spart," & _
    '                             "N'" & Replace(l_tabl.Item(p_Count).Item("VBELN").GetValue.ToString, "'", "", 1) & "'  as Vbeln," & _
    '                             "N'" & Replace(l_tabl.Item(p_Count).Item("VBTYP").GetValue.ToString, "'", "", 1) & "'  as Vbtyp," & _
    '                             "N'" & Replace(l_tabl.Item(p_Count).Item("VKORG").GetValue.ToString, "'", "", 1) & "'  as Vkorg," & _
    '                              "N'" & Replace(l_tabl.Item(p_Count).Item("VTWEG").GetValue.ToString, "'", "", 1) & "'  as Vtweg," & _
    '                                 "N'" & Replace(l_tabl.Item(p_Count).Item("ZLSCH").GetValue.ToString, "'", "", 1) & "'  as ZLSCH," & _
    '                             "N'" & Replace(l_tabl.Item(p_Count).Item("ZTERM").GetValue.ToString, "'", "", 1) & "'  as ZTERM," & _
    '                              "N'" & Replace(l_tabl.Item(p_Count).Item("INCO2").GetValue.ToString, "'", "", 1) & "'  as INCO2," & _
    '                               "N'" & Replace(l_tabl.Item(p_Count).Item("KONDA").GetValue.ToString, "'", "", 1) & "'  as PriceGroup" & _
    '                          ") AS source (Auart,Guebg,Gueen,Inco1,Kunnr,Matnr,Meins,Posnr,Spart,Vbeln,Vbtyp ,Vkorg,Vtweg,ZLSCH, ZTERM, INCO2, PriceGroup) " & _
    '                          " ON (target.Vbeln = source.Vbeln) " & _
    '                      " WHEN MATCHED  THEN UPDATE SET " & _
    '                              "Auart=source.Auart,Guebg=source.Guebg,Gueen=source.Gueen,Inco1=source.Inco1," & _
    '                               "Kunnr=source.Kunnr,Matnr=source.Matnr,Meins=source.Meins,Posnr=source.Posnr," & _
    '                               "Spart=source.Spart,Vbtyp=source.Vbtyp ,Vkorg=source.Vkorg,Vtweg=source.Vtweg" & _
    '                               ",ZLSCH=source.ZLSCH ,ZTERM=source.ZTERM,INCO2=source.INCO2, PriceGroup=source.PriceGroup  " & _
    '                   " WHEN NOT MATCHED THEN " & _
    '                      "INSERT  (Auart,Guebg,Gueen,Inco1,Kunnr,Matnr,Meins,Posnr,Spart,Vbeln,Vbtyp ,Vkorg,Vtweg ,ZLSCH, ZTERM, INCO2, PriceGroup ) " & _
    '                          "VALUES (source.Auart,source.Guebg,source.Gueen,source.Inco1,source.Kunnr,source.Matnr," & _
    '                          "source.Meins,source.Posnr,source.Spart,source.Vbeln,source.Vbtyp ,source.Vkorg,source.Vtweg,source.ZLSCH, source.ZTERM, source.INCO2, source.PriceGroup) ;"


    '                p_row = p_DataReturn.NewRow
    '                p_row.Item(0) = p_SQL
    '                p_DataReturn.Rows.Add(p_row)

    '            Next
    '            o_err = ""
    '            If p_DataReturn.Rows.Count > 0 Then
    '                If g_Services.Sys_Execute_DataTbl(p_DataReturn, o_err) = False Then


    '                End If

    '            End If
    '            p_DataReturn.Clear()
    '        End If




    '        'Hop dong chi tiet
    '        If Not l_tabl_detail Is Nothing Then
    '            p_DataReturn.Clear()
    '            For p_Count = 0 To l_tabl_detail.RowCount - 1
    '                p_SQL = "MERGE tblProject_Details  AS target " & _
    '               " USING (SELECT N'" & Replace(l_tabl_detail.Item(p_Count).Item("AUART").GetValue.ToString, "'", "", 1) & "' as Auart ," & _
    '                        "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Guebg").GetValue.ToString, "'", "", 1) & "'  as Guebg," & _
    '                         "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Gueen").GetValue.ToString, "'", "", 1) & "'  as Gueen," & _
    '                          "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Inco1").GetValue.ToString, "'", "", 1) & "'  as Inco1," & _
    '                           "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Kunnr").GetValue.ToString, "'", "", 1) & "'  as Kunnr," & _
    '                            "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Matnr").GetValue.ToString, "'", "", 1) & "'  as Matnr," & _
    '                             "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Meins").GetValue.ToString, "'", "", 1) & "'  as Meins," & _
    '                              "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Posnr").GetValue.ToString, "'", "", 1) & "'  as Posnr," & _
    '                          "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Spart").GetValue.ToString, "'", "", 1) & "'  as Spart," & _
    '                          "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Vbeln").GetValue.ToString, "'", "", 1) & "'  as Vbeln," & _
    '                          "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Vbtyp").GetValue.ToString, "'", "", 1) & "'  as Vbtyp," & _
    '                          "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Vkorg").GetValue.ToString, "'", "", 1) & "'  as Vkorg," & _
    '                           "N'" & Replace(l_tabl_detail.Item(p_Count).Item("Vtweg").GetValue.ToString, "'", "", 1) & "'  as Vtweg" & _
    '                       ") AS source (Auart,Guebg,Gueen,Inco1,Kunnr,Matnr,Meins,Posnr,Spart,Vbeln,Vbtyp ,Vkorg,Vtweg) " & _
    '                       " ON (target.Vbeln = source.Vbeln   and   target.Matnr = source.Matnr ) " & _
    '                   " WHEN MATCHED  THEN UPDATE SET " & _
    '                           "Auart=source.Auart,Guebg=source.Guebg,Gueen=source.Gueen,Inco1=source.Inco1," & _
    '                            "Kunnr=source.Kunnr,Matnr=source.Matnr,Meins=source.Meins,Posnr=source.Posnr," & _
    '                            "Spart=source.Spart,Vbtyp=source.Vbtyp ,Vkorg=source.Vkorg,Vtweg=source.Vtweg" & _
    '                " WHEN NOT MATCHED THEN " & _
    '                   "INSERT  (Auart,Guebg,Gueen,Inco1,Kunnr,Matnr,Meins,Posnr,Spart,Vbeln,Vbtyp ,Vkorg,Vtweg ) " & _
    '                       "VALUES (source.Auart,source.Guebg,source.Gueen,source.Inco1,source.Kunnr,source.Matnr," & _
    '                       "source.Meins,source.Posnr,source.Spart,source.Vbeln,source.Vbtyp ,source.Vkorg,source.Vtweg) ;"

    '                p_row = p_DataReturn.NewRow
    '                p_row.Item(0) = p_SQL
    '                p_DataReturn.Rows.Add(p_row)
    '            Next

    '            o_err = ""
    '            If p_DataReturn.Rows.Count > 0 Then
    '                If g_Services.Sys_Execute_DataTbl(p_DataReturn, o_err) = False Then


    '                End If

    '            End If

    '            p_DataReturn.Clear()

    '        End If
    '        '   Next

    '        'p_SQL = getStringSyn("HopDong", p_DataReturn.Rows.Count, 1)
    '        'p_row = p_DataReturn.NewRow
    '        'p_row.Item(0) = p_SQL
    '        'p_DataReturn.Rows.Add(p_row)

    '        '' If l_tabl.RowCount > 0 Then
    '        '''anhqh  20200729   day bang LogHist
    '        'p_SQL = HistStringSyn("HopDong", False)
    '        'p_row = p_DataReturn.NewRow
    '        'p_row.Item(0) = p_SQL
    '        'p_DataReturn.Rows.Add(p_row)
    '        ''   End If

    '        Try
    '            RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
    '        Catch ex As Exception

    '        End Try

    '        Return p_DataReturn

    '    Catch ex As Exception
    '        Try
    '            RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
    '        Catch ex1 As Exception

    '        End Try
    '        '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
    '        'Lỗi do chưa remote-enable trong tab Atribute của function module
    '        o_err = ex.Message.ToString()
    '        Return Nothing
    '    End Try
    'End Function



    Public Function ThongTinLenhXuat_Services(ByRef o_err As String, ByVal p_Date As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        'Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        '  Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository
        ' Dim p_E_DO As String = ""
        'Dim p_E_KUNNR As String = ""
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_ArrRow() As DataRow
        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Row As DataRow
        ' Dim p_ComCode, p_MaKho, p_TenKho, p_BEDAT, p_EINDT As String
        Dim p_SOLenh As String = ""
        Dim p_Error As String = ""
        Dim p_NgayThang As String = ""
        Dim p_Status As String = "N"


        Try
            ' Dim p_tblWhs As String = ""
            Dim p_tblDataTable As DataTable
            Dim p_DateSys As Date = Now.Date
            Dim p_Int As Integer = 0

            p_SQL = "select convert(date, dateadd (day, (-1) * isnull(( select top 1 KeyValue  from sys_config " & _
                       " where upper(keyCode ) ='TIMEDAYAUTO'),0), getdate()  )) as DateSys"
            p_tblDataTable = GetDataTableSQL(p_SQL, p_SQL)

            If Not p_tblDataTable Is Nothing Then
                If p_tblDataTable.Rows.Count > 0 Then
                    p_DateSys = CDate(p_tblDataTable.Rows(0).Item(0))
                End If
            End If
            o_err = ""



            p_TableReturn.Columns.Add("X")
            p_TableReturn.Columns.Add("SoLenh")
            p_TableReturn.Columns.Add("NgayThang", GetType(System.DateTime))
            p_TableReturn.Columns.Add("NgayHieuLuc", GetType(System.DateTime))
            p_TableReturn.Columns.Add("sStatus")
            p_TableReturn.Columns.Add("sDesc")


            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try

            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZBAPI_DELIVERIES_DOLIST")
            '  g_Company_Code, i_date, i_getall
            '  l_func = repository.CreateFunction("ZBAPI_FM_GET_COMPANYCODE")
            l_func.SetValue("I_VKORG", g_CompanyCode)

            l_func.Invoke(_ecc)

            'l_func.
            l_tabl = l_func.GetTable("T_DELIVERIES")

            ' p_SQL = HistStringSyn("STO", True)
            'p_Row = p_TableReturn.NewRow
            'p_Row.Item("ParValue") = p_SQL
            'p_TableReturn.Rows.Add(p_Row)

            If Not l_tabl Is Nothing Then
                For p_Count = 0 To l_tabl.RowCount - 1

                    p_SOLenh = l_tabl.Item(p_Count).Item("ORDER_NO").GetValue.ToString
                    p_ArrRow = p_TableReturn.Select("SoLenh ='" & p_SOLenh & "'")
                    If p_ArrRow.Length > 0 Then
                        Continue For
                    End If
                    p_NgayThang = l_tabl.Item(p_Count).Item("DATE_ND").GetValue.ToString

                    If p_DateSys > CDate(p_NgayThang) Then
                        Continue For
                    End If

                    If Check_SoLenh(p_Error, p_SOLenh) = True Then
                        Continue For
                    End If
                    If Not IsDate(p_NgayThang) And p_Date = "" Then
                        Continue For
                    End If

                    p_Row = p_TableReturn.NewRow
                    p_Row.Item("X") = "Y"
                    p_Row.Item("SoLenh") = p_SOLenh
                    If p_Date = "" Then
                        p_Row.Item("NgayThang") = p_NgayThang
                    Else
                        p_Row.Item("NgayThang") = p_Date
                    End If

                    p_Row.Item("NgayHieuLuc") = p_NgayThang
                    p_Row.Item("sStatus") = p_Status

                    p_TableReturn.Rows.Add(p_Row)

                Next
            End If


            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception

            End Try

            'If p_TableReturn.Rows.Count > 0 Then
            '    p_SQL = getStringSyn("STO", p_TableReturn.Rows.Count, 1)
            '    p_Row = p_TableReturn.NewRow
            '    p_Row.Item("ParValue") = p_SQL
            '    p_TableReturn.Rows.Add(p_Row)

            'End If

            '''anhqh  20200729   day bang LogHist
            'p_SQL = HistStringSyn("STO: " & p_TableReturn.Rows.Count, False)
            'p_Row = p_TableReturn.NewRow
            'p_Row.Item("ParValue") = p_SQL
            'p_TableReturn.Rows.Add(p_Row)


            'p_TableReturn
            p_TableReturn.DefaultView.Sort = "NgayThang ASC"
            Return (p_TableReturn)

        Catch ex As Exception
            Try
                '  RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            o_err = ex.Message.ToString()
            Return Nothing
        End Try

    End Function


    Private Function Check_SoLenh(ByRef p_Err As String, ByVal i_SoLenh As String) As Boolean
        Dim p_DataTable As DataTable
        'Dim p_Err As String
        Check_SoLenh = False
        'Return g_c2SQL.ExeNonQuery("sp_Check_SoLenhE5", err, New SqlParameter("@SoLenh", i_SoLenh))
        p_Err = ""
        p_DataTable = GetDataTableSQL("exec sp_Check_SoLenhE5 '" & i_SoLenh & "'", p_Err)
        If p_Err <> "" Then
            Return True
        End If
        If Not p_DataTable Is Nothing Then
            If p_DataTable.Rows.Count > 0 Then
                Return True
            End If
        End If
    End Function




    Public Function Get_DO1_THN3(ByVal p_SoLenh As String, ByRef o_err As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_LineID As String = ""
        Dim p_MaHangHoa As String = ""
        Dim p_CurrencyKey As String = ""
        Dim p_DonGia As Double = 0

        Dim p_TableReturn As New DataTable("Table01")

        Dim p_Row As DataRow
        Try

            p_TableReturn.Columns.Add("LineID")
            p_TableReturn.Columns.Add("MaHangHoa")
            p_TableReturn.Columns.Add("CurrencyKey")
            p_TableReturn.Columns.Add("SoLenhDO1")
            p_TableReturn.Columns.Add("DonGia", GetType(System.Double))


            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'RfcDestinationManager.GetDestination("aaaa")
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)

            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try
            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZBAPI_EXPORT_THN3")
            l_func.SetValue("I_DO", p_SoLenh)
            l_func.Invoke(_ecc)

            l_tabl = l_func.GetTable("T_DETAIL")

            If Not l_tabl Is Nothing Then
                For p_Count = 0 To l_tabl.RowCount - 1
                    p_LineID = l_tabl.Item(p_Count).Item("POSNR").GetValue.ToString    ' l_tabl.Item(p_Count).GetValue("CONRG")
                    p_MaHangHoa = l_tabl.Item(p_Count).Item("MATNR").GetValue.ToString  ' l_tabl.Item(p_Count).GetValue("TXTMI")
                    p_CurrencyKey = l_tabl.Item(p_Count).Item("KOEIN").GetValue.ToString


                    p_MaHangHoa = Mid(p_MaHangHoa, Len(p_MaHangHoa) - 6) '
                    '   p_DonGia = l_tabl.Item(p_Count).Item("MaKho").GetValue.ToString
                    If p_CurrencyKey <> "VND" Then
                        'Zz_Kbetr
                        Double.TryParse(l_tabl.Item(p_Count).Item("Zz_Kbetr").GetValue.ToString, p_DonGia)
                    Else
                        'Kbetr
                        Double.TryParse(l_tabl.Item(p_Count).Item("Kbetr").GetValue.ToString, p_DonGia)
                    End If
                    ' Double.TryParse(l_tabl.Item(p_Count).Item("MaKho").GetValue.ToString, p_DonGia)
                    p_Row = p_TableReturn.NewRow

                    p_Row.Item("LineID") = p_LineID
                    p_Row.Item("MaHangHoa") = p_MaHangHoa
                    p_Row.Item("CurrencyKey") = p_CurrencyKey
                    p_Row.Item("DonGia") = p_DonGia
                    p_Row.Item("SoLenhDO1") = p_SoLenh
                    p_TableReturn.Rows.Add(p_Row)

                Next
            End If
            'p_E_KUNNR = l_func.GetString("E_KUNNR")
            'p_E_DO = l_func.GetString("E_DO")
            'p_Row = p_TableReturn.NewRow
            'p_Row.Item("ParName") = "E_KUNNR"
            'p_Row.Item("ParValue") = p_E_KUNNR
            'p_TableReturn.Rows.Add(p_Row)

            'p_Row = p_TableReturn.NewRow
            'p_Row.Item("ParName") = "E_DO"
            'p_Row.Item("ParValue") = p_E_DO
            'p_TableReturn.Rows.Add(p_Row)

            'p_MaNGuon = l_func.GetString("E_BWTAR")
            'p_Row = p_TableReturn.NewRow
            'p_Row.Item("ParName") = "E_BWTAR"
            'p_Row.Item("ParValue") = p_MaNGuon
            'p_TableReturn.Rows.Add(p_Row)
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception
                Return p_TableReturn
            End Try

            'p_TableReturn = l_tabl
            Return p_TableReturn

        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            o_err = ex.Message.ToString()
            Return Nothing
        End Try


    End Function




    Public Function Get_LenhXuatAuto(ByVal p_FromDate As String, ByVal p_ToDate As String, ByRef o_err As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_LineID As String = ""
        Dim p_MaHangHoa As String = ""
        Dim p_CurrencyKey As String = ""
        Dim p_DonGia As Double = 0

        Dim p_TableReturn As New DataTable("Table01")

        Dim p_Row As DataRow
        Try

            p_TableReturn.Columns.Add("Order_No")
            p_TableReturn.Columns.Add("Vehicle")
            p_TableReturn.Columns.Add("Resource_Nd")
            p_TableReturn.Columns.Add("Customer")
            p_TableReturn.Columns.Add("Date_ND")


            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'RfcDestinationManager.GetDestination("aaaa")
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try

            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZBAPI_DELIVERIES_DOLIST")
            l_func.SetValue("I_VKORG", g_CompanyCode)
            l_func.SetValue("I_FRDATE", p_FromDate)
            ' l_func.SetValue("I_TODATE", p_ToDate)
            ' l_func.
            l_func.Invoke(_ecc)
            l_tabl = l_func.GetTable("T_DELIVERIES")
            ' p_TableReturn = l_tabl.ToADODataTable()

            If Not l_tabl Is Nothing Then
                For p_Count = 0 To l_tabl.RowCount - 1
                    p_Row = p_TableReturn.NewRow
                    p_Row.Item("Order_No") = l_tabl.Item(p_Count).Item("ORDER_NO").GetValue.ToString
                    p_Row.Item("Date_ND") = l_tabl.Item(p_Count).Item("DATE_ND").GetValue.ToString
                    p_Row.Item("Vehicle") = l_tabl.Item(p_Count).Item("Vehicle").GetValue.ToString
                    p_Row.Item("Resource_Nd") = l_tabl.Item(p_Count).Item("Resource_Nd").GetValue.ToString
                    p_Row.Item("Customer") = l_tabl.Item(p_Count).Item("Customer").GetValue.ToString
                   
                    p_TableReturn.Rows.Add(p_Row)

                Next
            End If

            Try
                'RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception
                Return p_TableReturn
            End Try

            'p_TableReturn = l_tabl
            Return p_TableReturn

        Catch ex As Exception
            Try
                'RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            o_err = ex.Message.ToString()
            Return Nothing
        End Try


    End Function




    Public Sub Post_LenhXuatAuto(ByVal p_DataTable As DataTable, ByRef o_err As String)

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim repository As RfcRepository ' = _ecc.Repository      

      
        ' Dim p_Row As DataRow
        Try
            o_err = ""
         

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'RfcDestinationManager.GetDestination("aaaa")
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try

            repository = _ecc.Repository


         
            'l_tabl = l_func.GetTable("T_DELIVERIES")
            ' p_TableReturn = l_tabl.ToADODataTable()

            If Not p_DataTable Is Nothing Then
                l_func = repository.CreateFunction("ZBAPI_DELIVERIES_DOLIST_POST")

                l_tabl = l_func.GetTable("T_DELIVERIES")
                For p_Count = 0 To p_DataTable.Rows.Count - 1
                    l_tabl.Append()


                    l_tabl.SetValue("ORDER_NO", p_DataTable.Rows(p_Count).Item("SoLenh").ToString.Trim)
                    '  l_tabl.SetValue("DATE_ND", p_DataTable.Rows(p_Count).Item("").ToString.Trim)
                    ' l_tabl.SetValue("Vehicle", p_DataTable.Rows(p_Count).Item("").ToString.Trim)
                    ' l_tabl.SetValue("Resource_Nd", p_DataTable.Rows(p_Count).Item("").ToString.Trim)
                    ' l_tabl.SetValue("Customer", p_DataTable.Rows(p_Count).Item("").ToString.Trim)


                Next
                If p_DataTable.Rows.Count > 0 Then


                    ' l_func.
                    l_func.Invoke(_ecc)
                End If

            End If

           

            Try
                '  RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception
                ' o_err = ex.Message
            End Try

            'p_TableReturn = l_tabl
            ' Return p_TableReturn

        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            o_err = ex.Message.ToString()

        End Try


    End Sub




    Public Sub CapNhatTrangThaiAuto(ByVal p_FromDate As String, ByVal p_ToDate As String, ByVal p_SoLenh As String, ByRef o_err As String)

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_LineID As String = ""
        Dim p_MaHangHoa As String = ""
        Dim p_CurrencyKey As String = ""
        Dim p_DonGia As Double = 0


        Dim p_Row As DataRow
        Try



            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'RfcDestinationManager.GetDestination("aaaa")
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try

            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZBAPI_DELIVERIES_DOLIST_NULL")
            l_func.SetValue("I_VKORG", g_CompanyCode)
            l_func.SetValue("I_FRDATE", p_FromDate)
            l_func.SetValue("I_TODATE", p_ToDate)
            If p_SoLenh <> "" Then
                l_func.SetValue("I_ORDER_NO", p_SoLenh)
            End If
            ' l_func.
            l_func.Invoke(_ecc)


            'l_tabl = l_func.GetTable("T_DELIVERIES")
            '' p_TableReturn = l_tabl.ToADODataTable()

            'If Not l_tabl Is Nothing Then
            '    For p_Count = 0 To l_tabl.RowCount - 1
            '        p_Row = p_TableReturn.NewRow
            '        p_Row.Item("Order_No") = l_tabl.Item(p_Count).Item("ORDER_NO").GetValue.ToString
            '        p_Row.Item("Date_ND") = l_tabl.Item(p_Count).Item("DATE_ND").GetValue.ToString
            '        p_Row.Item("Vehicle") = l_tabl.Item(p_Count).Item("Vehicle").GetValue.ToString
            '        p_Row.Item("Resource_Nd") = l_tabl.Item(p_Count).Item("Resource_Nd").GetValue.ToString
            '        p_Row.Item("Customer") = l_tabl.Item(p_Count).Item("Customer").GetValue.ToString

            '        p_TableReturn.Rows.Add(p_Row)

            '    Next
            'End If

            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception
                ' Return p_TableReturn
            End Try

            'p_TableReturn = l_tabl
            ' Return p_TableReturn

        Catch ex As Exception
            Try
                '  RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            o_err = ex.Message.ToString()
            '  Return Nothing
        End Try


    End Sub

    ''20241031  Ham thuc cap cap nhat casc thong tin lenh xuat cho KV2
    'Public Sub Post_LenhXuatBoSung(ByVal p_DataTable As DataTable, ByRef o_err As String)

    '    Dim l_func As IRfcFunction
    '    Dim l_tabl As IRfcTable
    '    Dim l_ret2 As IRfcStructure
    '    Dim _ecc As RfcDestination
    '    Dim p_TEst As IDestinationConfiguration
    '    Dim repository As RfcRepository ' = _ecc.Repository      
    '    Dim p_Value As Long
    '    Dim p_Starttime As String = Now.ToString("yyyyMMdd HH:m:ss")
    '    ' Dim p_Row As DataRow
    '    Try
    '        o_err = ""

    '        ' WritetoTxt(p_Starttime & ":  start===================Post_LenhXuatBoSung ======================")

    '        p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)

    '        Try
    '            _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
    '        Catch ex As Exception
    '            RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
    '            _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
    '        End Try

    '        repository = _ecc.Repository

    '        'l_tabl = l_func.GetTable("T_DELIVERIES")
    '        ' p_TableReturn = l_tabl.ToADODataTable()

    '        If Not p_DataTable Is Nothing Then

    '            l_func = repository.CreateFunction("ZFM_HTTG_PUSH_LX_V1")

    '            l_tabl = l_func.GetTable("IT_DATA") '("ZST_HTTG_PUSH_LX")

    '            For p_Count = 0 To p_DataTable.Rows.Count - 1

    '                l_ret2 = l_tabl.Metadata.LineType.CreateStructure

    '                l_ret2.SetValue("ORDER_NO", p_DataTable.Rows(p_Count).Item("ORDER_NO").ToString.Trim)

    '                l_ret2.SetValue("OUTBOUND", p_DataTable.Rows(p_Count).Item("ORDER_NO").ToString.Trim)

    '                l_ret2.SetValue("ITEM_ND", p_DataTable.Rows(p_Count).Item("LINEID").ToString.Trim)

    '                l_ret2.SetValue("COMPARTMENT", p_DataTable.Rows(p_Count).Item("MaNgan").ToString.Trim)

    '                l_ret2.SetValue("ZZERDAT", p_DataTable.Rows(p_Count).Item("ZZERDAT").ToString.Trim)

    '                l_ret2.SetValue("ZZERTIM", p_DataTable.Rows(p_Count).Item("ZZERTIM").ToString.Trim)

    '                l_ret2.SetValue("ZZAEDAT", p_DataTable.Rows(p_Count).Item("ZZAEDAT").ToString.Trim)

    '                l_ret2.SetValue("ZZAETIM", p_DataTable.Rows(p_Count).Item("ZZAETIM").ToString.Trim)

    '                l_ret2.SetValue("USERNAME", p_DataTable.Rows(p_Count).Item("UsrName").ToString.Trim)

    '                l_ret2.SetValue("DATE_TIME", p_DataTable.Rows(p_Count).Item("Sysdate").ToString.Trim)



    '                Try

    '                    l_ret2.SetValue("FLG_HTTG", p_DataTable.Rows(p_Count).Item("FLG_HTTG").ToString.Trim)
    '                Catch ex As Exception

    '                End Try
    '                Try

    '                    l_ret2.SetValue("FLG_RUT_TDH", p_DataTable.Rows(p_Count).Item("FLG_RUT_TDH").ToString.Trim)
    '                Catch ex As Exception

    '                End Try
    '                Try

    '                    l_ret2.SetValue("NHIENDO_PT", p_DataTable.Rows(p_Count).Item("NhietDoXe").ToString.Trim)
    '                Catch ex As Exception

    '                End Try
    '                Try

    '                    l_ret2.SetValue("CHIEUCAO_HH", p_DataTable.Rows(p_Count).Item("MaEntry").ToString.Trim)
    '                Catch ex As Exception

    '                End Try
    '                Try

    '                    l_ret2.SetValue("BATCH_ND", p_DataTable.Rows(p_Count).Item("BATCH_ND").ToString.Trim)
    '                Catch ex As Exception

    '                End Try
    '                Try

    '                    l_ret2.SetValue("MATNR", p_DataTable.Rows(p_Count).Item("MATNR").ToString.Trim)
    '                Catch ex As Exception

    '                End Try
    '                Try

    '                    l_ret2.SetValue("CUSTOMER", p_DataTable.Rows(p_Count).Item("CUSTOMER").ToString.Trim)
    '                Catch ex As Exception

    '                End Try
    '                Try

    '                    l_ret2.SetValue("VEHICLE", p_DataTable.Rows(p_Count).Item("VEHICLE").ToString.Trim)
    '                Catch ex As Exception

    '                End Try

    '                Try

    '                    l_ret2.SetValue("METER_NO", p_DataTable.Rows(p_Count).Item("METER_NO").ToString.Trim)
    '                Catch ex As Exception

    '                End Try

    '                Try

    '                    l_ret2.SetValue("METER_START", p_DataTable.Rows(p_Count).Item("METER_START").ToString.Trim)
    '                Catch ex As Exception

    '                End Try
    '                Try

    '                    l_ret2.SetValue("METER_END", p_DataTable.Rows(p_Count).Item("METER_END").ToString.Trim)
    '                Catch ex As Exception

    '                End Try
    '                Try

    '                    l_ret2.SetValue("QUANTITY_CONFIRM", p_DataTable.Rows(p_Count).Item("QUANTITY_CONFIRM").ToString.Trim)
    '                Catch ex As Exception

    '                End Try
    '                Try

    '                    l_ret2.SetValue("TEMP_CONFIRM", p_DataTable.Rows(p_Count).Item("TEMP_CONFIRM").ToString.Trim)
    '                Catch ex As Exception

    '                End Try
    '                Try

    '                    l_ret2.SetValue("DENS_CONFIRM", p_DataTable.Rows(p_Count).Item("DENS_COMFIRM").ToString.Trim)
    '                Catch ex As Exception

    '                End Try
    '                Try

    '                    l_ret2.SetValue("NIEM_TEXT", p_DataTable.Rows(p_Count).Item("NIEM_TEXT").ToString.Trim)
    '                Catch ex As Exception

    '                End Try
    '                l_tabl.Append(l_ret2)

    '            Next
    '            If p_DataTable.Rows.Count > 0 Then
    '                ' l_func.

    '                l_func.Invoke(_ecc)
    '            End If

    '        End If




    '        'p_TableReturn = l_tabl
    '        ' Return p_TableReturn
    '        ' WritetoTxt(p_Starttime & ":  end==================Post_LenhXuatBoSung=======================")
    '    Catch ex As Exception
    '        Try
    '            ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
    '        Catch ex1 As Exception

    '        End Try
    '        ' WritetoTxt(p_Starttime & ":  End Error===========Post_LenhXuatBoSung======================")
    '        o_err = "Post_LenhXuatBoSung: " & ex.Message.ToString()

    '    End Try


    'End Sub



    Public Sub Post_LenhXuatBoSung_JSON(ByVal p_DataTable As DataTable, ByRef o_err As String)
        'Dim response As HttpResponseMessage
        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim repository As RfcRepository ' = _ecc.Repository      
        Dim p_Value As Long
        Dim p_Starttime As String = Now.ToString("yyyyMMdd HH:m:ss")
        Dim url As String
        ' Dim p_ObjIT_DATA1 As New JsonStructure.ObjIT_DATA1
        Dim p_SQL As String
        Dim p_ObjDetailArr As New List(Of JsonStructure.ObjDetail)
        Dim p_ObjDetail As JsonStructure.ObjDetail
        Dim p_ObjDATA As New JsonStructure.ObjDATA
        Try
            o_err = ""

            If Not p_DataTable Is Nothing Then
                For p_Count = 0 To p_DataTable.Rows.Count - 1
                    p_ObjDetail = New JsonStructure.ObjDetail()
                    p_ObjDetail.ORDER_NO = p_DataTable.Rows(p_Count).Item("ORDER_NO").ToString.Trim
                    p_ObjDetail.OUTBOUND = p_DataTable.Rows(p_Count).Item("ORDER_NO").ToString.Trim
                    p_ObjDetail.ITEM_ND = p_DataTable.Rows(p_Count).Item("LINEID").ToString.Trim
                    p_ObjDetail.COMPARTMENT = p_DataTable.Rows(p_Count).Item("MaNgan").ToString.Trim
                    p_ObjDetail.ZZERDAT = p_DataTable.Rows(p_Count).Item("ZZERDAT").ToString.Trim
                    p_ObjDetail.ZZERTIM = p_DataTable.Rows(p_Count).Item("ZZERTIM").ToString.Trim
                    p_ObjDetail.ZZAEDAT = p_DataTable.Rows(p_Count).Item("ZZAEDAT").ToString.Trim
                    p_ObjDetail.ZZAETIM = p_DataTable.Rows(p_Count).Item("ZZAETIM").ToString.Trim
                    p_ObjDetail.USERNAME = p_DataTable.Rows(p_Count).Item("UsrName").ToString.Trim
                    p_ObjDetail.DATE_TIME = p_DataTable.Rows(p_Count).Item("Sysdate").ToString.Trim
                    p_ObjDetail.FLG_HTTG = p_DataTable.Rows(p_Count).Item("FLG_HTTG").ToString.Trim
                    p_ObjDetail.FLG_RUT_TDH = p_DataTable.Rows(p_Count).Item("FLG_RUT_TDH").ToString.Trim
                    p_ObjDetail.NHIENDO_PT = p_DataTable.Rows(p_Count).Item("NhietDoXe").ToString.Trim
                    p_ObjDetail.CHIEUCAO_HH = p_DataTable.Rows(p_Count).Item("MaEntry").ToString.Trim
                    p_ObjDetail.BATCH_ND = p_DataTable.Rows(p_Count).Item("BATCH_ND").ToString.Trim
                    p_ObjDetail.MATNR = p_DataTable.Rows(p_Count).Item("MATNR").ToString.Trim
                    p_ObjDetail.CUSTOMER = p_DataTable.Rows(p_Count).Item("CUSTOMER").ToString.Trim
                    p_ObjDetail.VEHICLE = p_DataTable.Rows(p_Count).Item("VEHICLE").ToString.Trim
                    p_ObjDetail.METER_NO = p_DataTable.Rows(p_Count).Item("METER_NO").ToString.Trim
                    p_ObjDetail.METER_START = p_DataTable.Rows(p_Count).Item("METER_START").ToString.Trim
                    p_ObjDetail.METER_END = p_DataTable.Rows(p_Count).Item("METER_END").ToString.Trim
                    p_ObjDetail.QUANTITY_CONFIRM = p_DataTable.Rows(p_Count).Item("QUANTITY_CONFIRM").ToString.Trim
                    p_ObjDetail.TEMP_CONFIRM = p_DataTable.Rows(p_Count).Item("TEMP_CONFIRM").ToString.Trim
                    p_ObjDetail.DENS_CONFIRM = p_DataTable.Rows(p_Count).Item("DENS_COMFIRM").ToString.Trim
                    p_ObjDetail.NIEM_TEXT = p_DataTable.Rows(p_Count).Item("NIEM_TEXT").ToString.Trim
                    ' p_ObjDetailArr(p_Count) = New JsonStructure.ObjDetail()
                    ' p_ObjDetailArr.Add(p_ObjDetail)
                    ' p_SQL = JsonConvert.SerializeObject(p_ObjDetail, Formatting.Indented)
                    p_ObjDATA.DATA.IT_DATA.Add(p_ObjDetail)
                Next
                If p_DataTable.Rows.Count > 0 Then
                    ' p_ObjDATA.DATA.IT_DATA = p_ObjDetailArr
                    p_SQL = JsonConvert.SerializeObject(p_ObjDATA, Formatting.Indented)


                    'Dim client As HttpClient = New HttpClient()

                    'Dim content = New StringContent(p_SQL, System.Text.Encoding.UTF8, "application/json")
                    'client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Basic",
                    '     Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("{" & p_UserNameAPI & "}:{" & p_PassAPI & "}")))

                    'client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
                    'Dim result = client.PostAsync(LinkServices, content)
                    'Dim result_Json_string = result.Result.Content.ReadAsStringAsync()

                End If

            End If




            'p_TableReturn = l_tabl
            ' Return p_TableReturn
            ' WritetoTxt(p_Starttime & ":  end==================Post_LenhXuatBoSung=======================")
        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            ' WritetoTxt(p_Starttime & ":  End Error===========Post_LenhXuatBoSung======================")
            o_err = "Post_LenhXuatBoSung: " & ex.Message.ToString()

        End Try


    End Sub




    ''''20241031  Ham thuc cap cap nhat casc thong tin lenh xuat cho KV2
    '''Public Sub Post_LenhXuatBoSung(ByVal p_DataTable As DataTable, ByRef o_err As String)

    '''    Dim l_func As IRfcFunction
    '''    Dim l_tabl As IRfcTable
    '''    Dim l_ret2 As IRfcStructure
    '''    Dim _ecc As RfcDestination
    '''    Dim p_TEst As IDestinationConfiguration
    '''    Dim repository As RfcRepository ' = _ecc.Repository      
    '''    Dim p_Value As Long

    '''    ' Dim p_Row As DataRow
    '''    Try
    '''        o_err = ""


    '''        p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)



    '''        Try
    '''            _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
    '''        Catch ex As Exception
    '''            RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
    '''            _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
    '''        End Try

    '''        repository = _ecc.Repository



    '''        'l_tabl = l_func.GetTable("T_DELIVERIES")
    '''        ' p_TableReturn = l_tabl.ToADODataTable()

    '''        If Not p_DataTable Is Nothing Then
    '''            l_func = repository.CreateFunction("ZFM_HTTG_PUSH_LX")

    '''            l_tabl = l_func.GetTable("IT_DATA") '("ZST_HTTG_PUSH_LX")
    '''            For p_Count = 0 To p_DataTable.Rows.Count - 1
    '''                l_tabl.Append()


    '''                l_tabl.SetValue("ORDER_NO", p_DataTable.Rows(p_Count).Item("ORDER_NO").ToString.Trim)
    '''                l_tabl.SetValue("OUTBOUND", p_DataTable.Rows(p_Count).Item("ORDER_NO").ToString.Trim)
    '''                l_tabl.SetValue("ITEM_ND", p_DataTable.Rows(p_Count).Item("LINEID").ToString.Trim)
    '''                l_tabl.SetValue("COMPARTMENT", p_DataTable.Rows(p_Count).Item("MaNgan").ToString.Trim)
    '''                l_tabl.SetValue("ZZERDAT", p_DataTable.Rows(p_Count).Item("ZZERDAT").ToString.Trim)
    '''                l_tabl.SetValue("ZZERTIM", p_DataTable.Rows(p_Count).Item("ZZERTIM").ToString.Trim)
    '''                l_tabl.SetValue("ZZAEDAT", p_DataTable.Rows(p_Count).Item("ZZAEDAT").ToString.Trim)
    '''                l_tabl.SetValue("ZZAETIM", p_DataTable.Rows(p_Count).Item("ZZAETIM").ToString.Trim)
    '''                l_tabl.SetValue("USERNAME", p_DataTable.Rows(p_Count).Item("UsrName").ToString.Trim)
    '''                l_tabl.SetValue("DATE_TIME", p_DataTable.Rows(p_Count).Item("Sysdate").ToString.Trim)
    '''                Try

    '''                    l_tabl.SetValue("TANKGROUP", p_DataTable.Rows(p_Count).Item("NhomBeXuatTDH").ToString.Trim)
    '''                    l_tabl.SetValue("BEXUAT", p_DataTable.Rows(p_Count).Item("BeXuatTDH").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try

    '''                Try

    '''                    l_tabl.SetValue("FLG_HTTG", p_DataTable.Rows(p_Count).Item("FLG_HTTG").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try
    '''                Try
    '''                    l_tabl.SetValue("FLG_RUT_TDH", p_DataTable.Rows(p_Count).Item("FLG_RUT_TDH").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try
    '''                Try
    '''                    l_tabl.SetValue("NHIENDO_PT", p_DataTable.Rows(p_Count).Item("NhietDoXe").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try
    '''                Try
    '''                    l_tabl.SetValue("CHIEUCAO_HH", p_DataTable.Rows(p_Count).Item("MaEntry").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try
    '''                Try
    '''                    l_tabl.SetValue("BATCH_ND", p_DataTable.Rows(p_Count).Item("BATCH_ND").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try
    '''                Try
    '''                    l_tabl.SetValue("MATNR", p_DataTable.Rows(p_Count).Item("MATNR").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try
    '''                Try
    '''                    l_tabl.SetValue("CUSTOMER", p_DataTable.Rows(p_Count).Item("CUSTOMER").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try
    '''                Try
    '''                    l_tabl.SetValue("VEHICLE", p_DataTable.Rows(p_Count).Item("VEHICLE").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try

    '''                Try
    '''                    l_tabl.SetValue("METER_NO", p_DataTable.Rows(p_Count).Item("METER_NO").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try

    '''                Try

    '''                    l_tabl.SetValue("METER_START", p_DataTable.Rows(p_Count).Item("METER_START").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try
    '''                Try
    '''                    l_tabl.SetValue("METER_END", p_DataTable.Rows(p_Count).Item("METER_END").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try
    '''                Try
    '''                    l_tabl.SetValue("QUANTITY_CONFIRM", p_DataTable.Rows(p_Count).Item("QUANTITY_CONFIRM").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try
    '''                Try
    '''                    l_tabl.SetValue("TEMP_CONFIRM", p_DataTable.Rows(p_Count).Item("TEMP_CONFIRM").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try
    '''                Try
    '''                    l_tabl.SetValue("DENS_CONFIRM", p_DataTable.Rows(p_Count).Item("DENS_COMFIRM").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try
    '''                Try
    '''                    l_tabl.SetValue("NIEM_TEXT", p_DataTable.Rows(p_Count).Item("NIEM_TEXT").ToString.Trim)
    '''                Catch ex As Exception

    '''                End Try

    '''            Next
    '''            If p_DataTable.Rows.Count > 0 Then


    '''                ' l_func.
    '''                l_func.Invoke(_ecc)
    '''            End If

    '''        End If



    '''        Try
    '''            '  RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
    '''        Catch ex As Exception
    '''            ' o_err = ex.Message
    '''        End Try

    '''        'p_TableReturn = l_tabl
    '''        ' Return p_TableReturn

    '''    Catch ex As Exception
    '''        Try
    '''            ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
    '''        Catch ex1 As Exception

    '''        End Try
    '''        o_err = "Post_LenhXuatBoSung: " & ex.Message.ToString()

    '''    End Try


    '''End Sub




    'anhqh
    '
    '20241121  Ham lay thông tin nhóm bể xuất
    Public Function TankGroup_Infor(ByRef o_err As String, ByVal p_UserName As String, ByVal p_CompanyCode As String, ByVal p_Client As String) As DataTable

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim p_Table As RfcTableMetadata
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_E_DO As String = ""
        Dim p_E_KUNNR As String = ""
        Dim p_SQL As String
        Dim p_Count As Integer
        Dim p_TableReturn As New DataTable("Table01")
        Dim p_Row As DataRow
        Dim p_ComCode, p_MaKho, p_TenKho, p_ID_SAP As String
        Dim p_Tank, p_TankGroup, p_FromDate, p_ToDate As String
        Try


            p_TableReturn.Columns.Add("ParValue")

            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)

            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try
            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZFM_HTTG_MD_TANK_GROUP")

            '  l_func = repository.CreateFunction("ZBAPI_FM_GET_COMPANYCODE")
            l_func.SetValue("I_WERKS", p_CompanyCode)
            l_func.SetValue("I_KHO", p_Client)
            l_func.Invoke(_ecc)

            'l_func.
            l_tabl = l_func.GetTable("IT_DATA")
            If Not l_tabl Is Nothing Then
                For p_Count = 0 To l_tabl.RowCount - 1
                    If l_tabl.Item(p_Count).Item("TANKGROUP").GetValue.ToString <> "" Then

                        p_Tank = l_tabl.Item(p_Count).Item("BEXUAT").GetValue.ToString()
                        If p_Tank = "A113" Then
                            p_Tank = p_Tank

                        End If
                        p_TankGroup = l_tabl.Item(p_Count).Item("TANKGROUP").GetValue.ToString()
                        p_FromDate = l_tabl.Item(p_Count).Item("BEGDA").GetValue.ToString() & " " & l_tabl.Item(p_Count).Item("BEGTI").GetValue.ToString()
                        p_ToDate = l_tabl.Item(p_Count).Item("ENDDA").GetValue.ToString() & " " & l_tabl.Item(p_Count).Item("ENDTI").GetValue.ToString()
                        If Replace(l_tabl.Item(p_Count).Item("BEGDA").GetValue.ToString(), "-", "") = "00000000" Then
                            p_FromDate = "2025-01-01" & " " & l_tabl.Item(p_Count).Item("BEGTI").GetValue.ToString()
                        End If
                        If Replace(l_tabl.Item(p_Count).Item("ENDDA").GetValue.ToString(), "-", "") = "00000000" Then
                            p_ToDate = "2049-12-01" & " " & l_tabl.Item(p_Count).Item("ENDTI").GetValue.ToString()
                        End If
                        p_ID_SAP = l_tabl.Item(p_Count).Item("KEY_NO").GetValue.ToString()
                        ' p_Tank, p_TankGroup, p_FromDate, p_ToDate
                        ' (select top 1 Name_nd from tblTank where isnull(Name_nd,'') ='" & p_Tank & "' or isnull(Map_Sap1,'') ='" & p_Tank & "')
                        p_SQL = " MERGE tblTankGroup AS target   USING (	"
                        p_SQL = p_SQL & " select isnull( (select top 1 Name_nd from tblTank where isnull(Name_nd,'') ='" & p_Tank & "' or isnull(Map_Sap1,'') ='" & p_Tank & "'), '" & p_Tank & "')  as Name_nd, '" & p_TankGroup & "' as TankGroup, convert(datetime, '" & p_FromDate & "') as FromDate, " & _
                                "convert(datetime, '" & p_ToDate & "') as ToDate, '" & p_UserName & "' as  CreateUser , " & p_ID_SAP & " as  ID_SAP " & _
                                ", (select top 1 [Product_nd] from tblTank gg where ( gg.Name_nd ='" & p_Tank & "' or Map_Sap1 = '" & p_Tank & "' ) )  as [Product_nd] "
                        p_SQL = p_SQL & " ) AS source (Name_nd, TankGroup, FromDate, ToDate , CreateUser , ID_SAP, Product_nd)  " & _
                                " ON (isnull(target.ID_SAP, 0)  = isnull( source.ID_SAP,0))   " & _
                                " WHEN MATCHED THEN " & _
                                     " UPDATE SET TANKGROUP = source.TANKGROUP, FromDate = source.FromDate, ToDate=source.ToDate,  UpdateUser =source.CreateUser , TichHop ='Y' " & _
                                " WHEN NOT MATCHED THEN   " & _
                                " INSERT(Name_nd, TankGroup , FromDate, ToDate , CreateUser , UpdateUser, ID_SAP, Tichhop, Product_nd  ) " & _
                                " VALUES (source.Name_nd, source.TankGroup, source.FromDate, source.ToDate,  source.CreateUser, source.CreateUser,  source.ID_SAP, 'Y', source.Product_nd )  ;"
                        p_Row = p_TableReturn.NewRow
                        p_Row.Item("ParValue") = p_SQL
                        p_TableReturn.Rows.Add(p_Row)
                        If l_tabl.Item(p_Count).Item("FLG_DEL").GetValue.ToString() = "X" And p_ID_SAP <> "" Then
                            p_SQL = "delete from tblTankGroup where  ID_SAP = " & p_ID_SAP
                            p_Row = p_TableReturn.NewRow
                            p_Row.Item("ParValue") = p_SQL
                            p_TableReturn.Rows.Add(p_Row)
                        End If

                    End If
                Next
            End If


            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception

            End Try


            Return p_TableReturn

        Catch ex As Exception
            Try
                'RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            '"The function module "ZFM_INT_DELIVERIES_SPECIFIC_V1" cannot be used for 'remote' calls."  
            'Lỗi do chưa remote-enable trong tab Atribute của function module
            o_err = ex.Message.ToString()
            Return Nothing
        End Try


    End Function

    Public Sub Get_ATG_M_LIST(ByRef p_TableReturn As DataTable, ByVal p_Plan_DB As String, _
                                    ByVal p_TankMapSap1 As String, ByVal p_ToDate As String, ByRef o_err As String)

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_TEst As IDestinationConfiguration
        Dim repository As RfcRepository ' = _ecc.Repository
        Dim p_LineID As String = ""
        Dim p_MaHangHoa As String = ""
        Dim p_CurrencyKey As String = ""
        Dim p_DonGia As Double = 0

        '' Dim p_TableReturn As New DataTable("Table01")

        Dim p_Row As DataRow
        Try
            o_err = ""
            'p_TableReturn.Columns.Add("LGORT")
            'p_TableReturn.Columns.Add("DATE_F")
            'p_TableReturn.Columns.Add("DATE_T")


            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)
            'RfcDestinationManager.GetDestination("aaaa")
            'Try
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            'Catch ex As Exception

            'End Try

            '_ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try

            repository = _ecc.Repository


            l_func = repository.CreateFunction("ZFM_TTKB_HS_FILE")


            l_func.SetValue("IS_WERKS", p_Plan_DB)
            If p_TankMapSap1.ToString <> "" Then
                l_func.SetValue("IS_LGORT", p_TankMapSap1)
            End If
            ' l_func.SetValue("I_TODATE", p_ToDate)
            ' l_func.
            l_func.Invoke(_ecc)
            l_tabl = l_func.GetTable("IT_DATA")
            ' p_TableReturn = l_tabl.ToADODataTable()

            If Not l_tabl Is Nothing Then
                For p_Count = 0 To l_tabl.RowCount - 1
                    p_Row = p_TableReturn.NewRow
                    p_Row.Item("LGORT") = l_tabl.Item(p_Count).Item("LGORT").GetValue.ToString
                    p_Row.Item("DATE_F") = l_tabl.Item(p_Count).Item("DATE_F").GetValue.ToString & " " & l_tabl.Item(p_Count).Item("TIME_F").GetValue.ToString
                    p_Row.Item("DATE_T") = l_tabl.Item(p_Count).Item("DATE_T").GetValue.ToString & " " & l_tabl.Item(p_Count).Item("TIME_T").GetValue.ToString

                    p_TableReturn.Rows.Add(p_Row)

                Next
            End If

            Try
                'RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception
                ''Return p_TableReturn
            End Try

            'p_TableReturn = l_tabl
            '' Return p_TableReturn

        Catch ex As Exception
            Try
                'RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            o_err = ex.Message.ToString()
            ''Return Nothing
        End Try


    End Sub




    '20241031  Ham thuc cap cap nhat casc thong tin lenh xuat cho KV2
    Public Sub Post_PhuongTien(ByVal p_DataTable_H As DataTable, ByVal p_DataTable_Line As DataTable, ByRef o_err As String)

        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_tabl_Line As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_Int As Integer
        Dim p_TEst As IDestinationConfiguration
        Dim repository As RfcRepository ' = _ecc.Repository      
        Dim p_Count As Integer

        ' Dim p_Row As DataRow
        Try
            o_err = ""


            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)

            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try

            repository = _ecc.Repository



            'l_tabl = l_func.GetTable("T_DELIVERIES")
            ' p_TableReturn = l_tabl.ToADODataTable()

            If Not p_DataTable_H Is Nothing Then
                l_func = repository.CreateFunction("ZFM_EGAS_VEHICLE")

                l_tabl = l_func.GetTable("T_DATA_H")
                p_Count = 0
                l_tabl.Append()
                l_tabl.SetValue("VEHICLE", p_DataTable_H.Rows(p_Count).Item("MaPhuongTien").ToString.Trim)
                If p_DataTable_H.Rows(p_Count).Item("NgayBatDau").ToString.Trim <> "" Then
                    l_tabl.SetValue("DATE_F", p_DataTable_H.Rows(p_Count).Item("NgayBatDau").ToString.Trim)
                End If
                If p_DataTable_H.Rows(p_Count).Item("NgayHetHieuLuc").ToString.Trim <> "" Then
                    l_tabl.SetValue("DATE_T", p_DataTable_H.Rows(p_Count).Item("NgayHetHieuLuc").ToString.Trim)
                End If

                If p_DataTable_H.Rows(p_Count).Item("LaiXe").ToString.Trim <> "" Then
                    l_tabl.SetValue("VEHICLE_GROUP", p_DataTable_H.Rows(p_Count).Item("LaiXe").ToString.Trim)
                End If
                If p_DataTable_H.Rows(p_Count).Item("REG_NO").ToString.Trim <> "" Then
                    l_tabl.SetValue("REG_NO", p_DataTable_H.Rows(p_Count).Item("REG_NO").ToString.Trim)
                End If
                If p_DataTable_H.Rows(p_Count).Item("DIRVER").ToString.Trim <> "" Then
                    l_tabl.SetValue("DRIVE", p_DataTable_H.Rows(p_Count).Item("DIRVER").ToString.Trim)
                End If



             


                l_tabl_Line = l_func.GetTable("T_DATA_D")
                For p_Count = 0 To p_DataTable_Line.Rows.Count - 1
                    l_tabl_Line.Append()


                    l_tabl_Line.SetValue("VEHICLE", p_DataTable_Line.Rows(p_Count).Item("MaPhuongTien").ToString.Trim)
                    l_tabl_Line.SetValue("SEQ_NMBR", p_DataTable_Line.Rows(p_Count).Item("MaNgan").ToString.Trim)
                    l_tabl_Line.SetValue("SEQ_VOLUME", p_DataTable_Line.Rows(p_Count).Item("SoLuongMax").ToString.Trim)
                    Integer.TryParse(p_DataTable_Line.Rows(p_Count).Item("LTT_CM").ToString.Trim, p_Int)
                    If p_Int > 0 Then
                        l_tabl_Line.SetValue("LTT_CM", p_Int)
                    End If
                    Integer.TryParse(p_DataTable_Line.Rows(p_Count).Item("NHAP_MM").ToString.Trim, p_Int)
                    If p_Int > 0 Then
                        l_tabl_Line.SetValue("NHAP_MM", p_Int)
                    End If
                    Integer.TryParse(p_DataTable_Line.Rows(p_Count).Item("DUONGSINH").ToString.Trim, p_Int)
                    If p_Int > 0 Then
                        l_tabl_Line.SetValue("DUONGSINH", p_Int)
                    End If
                Next
                If p_DataTable_H.Rows.Count > 0 Then

                    ' l_func.
                    l_func.Invoke(_ecc)
                End If

            End If



            Try
                '  RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex As Exception
                ' o_err = ex.Message
            End Try

            'p_TableReturn = l_tabl
            ' Return p_TableReturn

        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            o_err = ex.Message.ToString()

        End Try


    End Sub


    Public Function SyncVEHICLE(ByVal p_date As String, ByVal p_VEHICLE As String, ByRef o_err As String, _
                                    ByRef p_TableLine As DataTable, ByRef p_TableHeader As DataTable, ByVal p_Type As String) As Boolean
        Dim l_func As IRfcFunction
        Dim l_tabl As IRfcTable
        Dim l_tabl_Line As IRfcTable
        Dim l_ret2 As IRfcStructure
        Dim _ecc As RfcDestination
        Dim p_Int As Integer
        Dim p_TEst As IDestinationConfiguration
        Dim repository As RfcRepository ' = _ecc.Repository      
        Dim p_Count As Integer
        Dim p_DateSync As String = Now.ToString("yyyyMMdd HH:mm:ss")

        Dim p_SQL As String
        Dim p_Row As DataRow
        Try
            o_err = ""
            SyncVEHICLE = False

            p_TableLine = New DataTable("tbl01")
            p_TableLine.Columns.Add("Str_SQL")
            p_TableHeader = New DataTable("tbl01")
            p_TableHeader.Columns.Add("Str_SQL")
            p_TEst = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode, g_ClientApp, g_UserNameApp)

            Try
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
                _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            End Try

            repository = _ecc.Repository

            'Try
            '    _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            'Catch ex As Exception
            '    RfcDestinationManager.RegisterDestinationConfiguration(p_TEst)
            '    _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            'End Try
            '' _ecc = RfcDestinationManager.GetDestination(g_GetDestination)
            'repository = _ecc.Repository

            Dim p_KeyApp As String = ""
            p_KeyApp = GetKey("SyncVEHICLE")

            l_func = repository.CreateFunction("ZAPI_EGAS_VEHICLE")

            l_func.SetValue("I_DATE", p_date)
            ''20250519 
            l_func.SetValue("I_UNAME", p_KeyApp)


            If p_VEHICLE <> "" Then
                l_func.SetValue("I_VEHICLE", p_VEHICLE)
            End If
            l_func.Invoke(_ecc)

            l_tabl = l_func.GetTable("ET_HEADER")
            l_tabl_Line = l_func.GetTable("ET_DETAIL")
            If p_Type <> "H" Then                'Dong bo All
                p_SQL = "DELETE FROM tblChiTietPhuongtien "
                p_Row = p_TableLine.NewRow
                p_Row.Item(0) = p_SQL
                p_TableLine.Rows.Add(p_Row)
            End If
            For p_Count = 0 To l_tabl_Line.RowCount - 1

                If p_Type = "H" Then                'Dong bo All
                    p_SQL = "DELETE FROM tblChiTietPhuongtien where MaPhuongTien='" & l_tabl_Line.Item(p_Count).GetValue("VEHICLE") & "' and MaNgan ='" & l_tabl_Line.Item(p_Count).GetValue("SEQ_NMBR") & "' "
                    p_Row = p_TableLine.NewRow
                    p_Row.Item(0) = p_SQL
                    p_TableLine.Rows.Add(p_Row)
                End If



                p_SQL = "INSERT INTO  tblChiTietPhuongtien (MaNgan, MaPhuongTien, SoLuongMax, Status, SyncDate, LTT_CM, NHAP_MM, DUONGSINH ) "
                p_SQL = p_SQL & " VALUES ('" & l_tabl_Line.Item(p_Count).GetValue("SEQ_NMBR") & "','" & l_tabl_Line.Item(p_Count).GetValue("VEHICLE") & "','" & l_tabl_Line.Item(p_Count).GetValue("SEQ_VOLUME") & "', 'S', '" & p_DateSync & "'" & _
                        "," & IIf(l_tabl_Line.Item(p_Count).GetValue("LTT_CM").ToString = "", 0, l_tabl_Line.Item(p_Count).GetValue("LTT_CM")) & " ," & _
                        IIf(l_tabl_Line.Item(p_Count).GetValue("NHAP_MM").ToString = "", 0, l_tabl_Line.Item(p_Count).GetValue("NHAP_MM")) & _
                        "," & IIf(l_tabl_Line.Item(p_Count).GetValue("DUONGSINH").ToString = "", 0, l_tabl_Line.Item(p_Count).GetValue("DUONGSINH")) & ")"
                p_Row = p_TableLine.NewRow
                p_Row.Item(0) = p_SQL
                p_TableLine.Rows.Add(p_Row)
            Next
            For p_Count = 0 To l_tabl.RowCount - 1
                p_SQL = "MERGE tblPhuongtien AS target " & _
                        " USING (SELECT N'" & l_tabl.Item(p_Count).GetValue("VEHICLE") & "' as MaPhuongTien ," & _
                                 "N'" & l_tabl.Item(p_Count).GetValue("VEHICLE_GROUP") & "'  as LaiXe," & _
                                 " (select Count(1) from tblChiTietPhuongTien  kk where kk.MaPhuongTien ='" & l_tabl.Item(p_Count).GetValue("VEHICLE") & "')  as SoNgan ," & _
                                 "'" & Replace(l_tabl.Item(p_Count).GetValue("DATE_F"), "-", "") & "'  as Ngaybatdau, " & _
                                 "'" & Replace(l_tabl.Item(p_Count).GetValue("DATE_T"), "-", "") & "'  as NgayHieuLuc, " & _
                                  "N'" & l_tabl.Item(p_Count).GetValue("REG_NO") & "'  as REG_NO, " & _
                                "'S' as Status) AS source (MaPhuongTien, LaiXe, SoNgan, Ngaybatdau, NgayHieuLuc, Status, REG_NO) " & _
                                " ON (target.MaPhuongTien = source.MaPhuongTien) " & _
                            " WHEN MATCHED  THEN UPDATE SET " & _
                                    " " & _
                                    "SoNgan=source.SoNgan " & _
                                    ",Ngaybatdau=source.Ngaybatdau " & _
                                    ",NgayHieuLuc=source.NgayHieuLuc " & _
                                    ", SyncDate= '" & p_DateSync & "',REG_NO=source.REG_NO " & _
                         " WHEN NOT MATCHED THEN " & _
                            "INSERT  (MaPhuongTien, LaiXe, SoNgan, Ngaybatdau, NgayHieuLuc, Status, SyncDate, REG_NO) " & _
                                "VALUES (source.MaPhuongTien,source.LaiXe,source.SoNgan,source.NgayHieuLuc,source.NgayHieuLuc,source.Status, '" & p_DateSync & "', source.REG_NO) ;"
                p_Row = p_TableHeader.NewRow
                p_Row.Item(0) = p_SQL
                p_TableHeader.Rows.Add(p_Row)
            Next

            SyncVEHICLE = True
        Catch ex As Exception
            Try
                ' RfcDestinationManager.UnregisterDestinationConfiguration(p_TEst)
            Catch ex1 As Exception

            End Try
            o_err = ex.Message.ToString()
            SyncVEHICLE = False
            'Return Nothing
        End Try


    End Function




    Public Function GetKey(ByVal p_FuncName As String) As String
        Dim p_SQL As String = ""
        Dim p_Key As String = ""
        Dim o_err As String = ""

        Try
            p_Key = g_CompanyCode & "_" & g_UserNameApp & "_" & Now.ToString

            p_SQL = "INSERT INTO [tblLogToSap]([CrDate],[FuncName],[UserCode],[CompanyCode],[KeySAP],[Client])"
            p_SQL = p_SQL & " VALUES (getdate(),'" & p_FuncName & "','" & g_UserNameApp & "','" & g_CompanyCode & "', '" & p_Key & "','" & g_ClientApp.ToString.Trim & "')"

            If g_Services.Sys_Execute(p_SQL, o_err) = False Then


            End If

            Return p_Key
        Catch ex As Exception
            p_SQL = ex.Message
            Return ""
        End Try
       

    End Function


End Module