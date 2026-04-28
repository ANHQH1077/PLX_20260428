Public Class CL_HTTG_COMMON
    Public g_LMS As String = ""
    Public g_SAP_LMS_GNTX As String = ""
    Public g_LMSLinkService As String = ""
    Public g_LMSUserName As String = ""
    Public g_LMSPass As String = ""

    Public Function getSYS_CONFIG()
        Dim p_DataTable As DataTable
        Dim p_ArrRow As DataRow
        Dim p_Connect As New FPTBUSSINESS.Class1
        Dim p_SQL As String = "select * from SYS_CONFIG"
        Dim p_Int As Integer
        Dim p_Err As String

        p_DataTable = p_Connect.Sys_SYS_GET_DATATABLE_Des(p_SQL, p_Err)

        For p_Int = 0 To p_DataTable.Rows.Count - 1
            p_ArrRow = p_DataTable.Rows.Item(p_Int)

            If p_ArrRow.Item("KeyCode") = "LMS" Then
                g_LMS = p_ArrRow.Item("KeyValue").ToString.Trim
            End If

            If p_ArrRow.Item("KeyCode") = "LMSLinkServices" Then
                g_LMSLinkService = p_ArrRow.Item("KeyValue").ToString.Trim
            End If

            If p_ArrRow.Item("KeyCode") = "LMSUserName" Then
                g_LMSUserName = p_ArrRow.Item("KeyValue").ToString.Trim
            End If

            If p_ArrRow.Item("KeyCode") = "LMSPass" Then
                g_LMSPass = p_ArrRow.Item("KeyValue").ToString.Trim
            End If

            If p_ArrRow.Item("KeyCode") = "SAP_LMS_GNTX" Then
                g_SAP_LMS_GNTX = p_ArrRow.Item("KeyValue").ToString.Trim
            End If

        Next
    End Function

    Public Sub New()

    End Sub
End Class
