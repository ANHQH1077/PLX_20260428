Imports SAP.Middleware.Connector

Module SAP_FM

    Public Function ZFM_CHECK_DO_CKG(ByVal p_SoLenh As String, ByRef o_err As String) As String
        Dim p_ECCDestConfig As IDestinationConfiguration
        Dim p_ECC As RfcDestination
        Dim p_Repository As RfcRepository
        Dim l_Func As IRfcFunction
        Dim l_Return As IRfcStructure
        Dim e_DataRow As DataRow
        Dim e_Message As String

        Try
            p_ECCDestConfig = New ECCDestinationConfig(p_ConnectString, p_Language, p_IdleTimeout, g_CompanyCode)

            Try
                p_ECC = RfcDestinationManager.GetDestination("DEV")
            Catch ex As Exception
                RfcDestinationManager.RegisterDestinationConfiguration(p_ECCDestConfig)
                p_ECC = RfcDestinationManager.GetDestination("DEV")
            End Try

            p_Repository = p_ECC.Repository
            l_Func = p_Repository.CreateFunction("ZFM_CHECK_DO_CKG")
            l_Func.SetValue("I_VBELN", p_SoLenh)
            l_Func.Invoke(p_ECC)

            l_Return = l_Func.GetStructure("E_RETURN")
            If l_Return.GetString("Type") = "E" Then
                e_Message = l_Return.GetString("Message")
            End If
            Return e_Message
        Catch ex As Exception
            o_err = ex.Message.ToString()
            Return Nothing
        End Try
    End Function
End Module
