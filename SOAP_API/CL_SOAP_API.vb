Imports System.ServiceModel

Public Class CL_SOAP_API
    Public g_LinkServiceLMS As String = ""
    Public g_UserNameLMS As String = ""
    Public g_PassLMS As String = ""

    Public Sub New()
        Dim p_DataTable As DataTable
        Dim p_ArrRow As DataRow
        Dim p_Connect As New FPTBUSSINESS.Class1
        Dim p_SQL As String = "select * from SYS_CONFIG"
        Dim p_Int As Integer
        Dim p_Error As String

        p_DataTable = p_Connect.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Error)

        For p_Int = 0 To p_DataTable.Rows.Count - 1
            p_ArrRow = p_DataTable.Rows.Item(p_Int)
            If p_ArrRow.Item("KeyCode") = "LMSLinkServices" Then
                g_LinkServiceLMS = p_ArrRow.Item("KeyValue").ToString.Trim
            End If

            If p_ArrRow.Item("KeyCode") = "LMSUserName" Then
                g_UserNameLMS = p_ArrRow.Item("KeyValue").ToString.Trim
            End If

            If p_ArrRow.Item("KeyCode") = "LMSPass" Then
                g_PassLMS = p_ArrRow.Item("KeyValue").ToString.Trim
            End If
        Next
    End Sub

    Public Function GetDensity(ByVal TankCoce As String, ByVal Product As String) As String
        Dim p_EndPointAddress As String = g_LinkServiceLMS
        Dim remoteAddress = New EndpointAddress(New Uri(p_EndPointAddress))
        Dim p_Binding As BasicHttpBinding
        Dim p_Client As LMS_SOAP.LMSAPISoapClient
        Dim p_Table As DataTable
        Dim p_Rows() As DataRow
        Dim p_Density As Decimal
        Dim p_TimeOut As Integer = 10000

        If InStr(UCase(p_EndPointAddress), UCase("https"), CompareMethod.Text) > 0 Then
            p_Binding = New BasicHttpBinding(BasicHttpSecurityMode.Transport)
        Else
            p_Binding = New BasicHttpBinding()
        End If

        p_Binding.SendTimeout = New TimeSpan(0, 0, 0, 0, p_TimeOut)

        Try
            p_Client = New LMS_SOAP.LMSAPISoapClient(p_Binding, remoteAddress)
            p_Table = p_Client.GetDensityOfPipeHeadOrTankByDateTime(TankCoce, DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff"), g_UserNameLMS, g_PassLMS)
            If p_Table Is Nothing Then
                MsgBox(TankCoce + ": Lỗi API LMS", MsgBoxStyle.OkOnly, "Error")
                Return Nothing
            End If

            p_Rows = p_Table.Select()

            'If p_Rows.Length > 0 And Product = p_Rows(0)("productnameid") Then
            '    p_Density = p_Rows(0)("density2").ToString.Trim.Substring(0, 6)
            'End If

            If p_Rows.Length > 0 Then
                p_Density = p_Rows(0)("density2").ToString.Trim.Substring(0, 6)
            End If

            Return p_Density
        Catch ex As Exception
            MsgBox(TankCoce + ": Lỗi API LMS", MsgBoxStyle.OkOnly, "Error")
            Return Nothing
        End Try
    End Function
End Class
