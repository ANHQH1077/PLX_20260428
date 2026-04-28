Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim p_LinkServer As String = "http://smoapi.piacom.com.vn:5047"
        Dim p_String As String
        Dim p_Table, p_TAble01 As DataTable
        Dim p_Error As String = ""
        Dim p_DoNumber As String
        Dim p_Status As String
        Dim p_DateTime As DateTime
        p_String = getToken(p_LinkServer, "smoapi", "smoapi123", p_Error)
        If p_Error = "" Then
            'getVehicleInfor("29H1111", p_LinkServer, p_String, p_Table)
            'getVehicleTrans("C0000001", p_LinkServer, p_String, p_TAble01)
            'p_DoNumber = "2036842311"   ', 2036842312, 2036842313"
            'p_Status = "31"
            'p_DateTime = Now
            'UpdateStatusDO(p_DoNumber, p_Status, p_DateTime, p_LinkServer, p_String)

            'MsgBox(p_String)
        End If

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs)

    End Sub
End Class
