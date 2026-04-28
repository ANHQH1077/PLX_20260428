Public Class FrmTankGroupHist

    Public g_TankCode As String = ""
    Public g_HHCode As String = ""
    Public g_HHName As String = ""


    Private Sub FrmTank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        p_XtraUserName = g_User_ID
        If g_Filter_Terminal = True Then
            If g_Terminal <> "" Then
                Me.GridView1.Where = "( left(Name_nd,LEN ('" & g_Terminal & "'))='" & g_Terminal & "')"   '  or  Product_nd in (select MahangHoa from tblHangHoaE5 )  )"
            End If
        End If
        '' Me.GridView1.Where = "Name_nd='" & g_TankCode & "'"
        Me.DefaultFormLoad = True
        Me.Form1_Load(sender, e)
        Me.DefaultFormLoad = False

       

    End Sub

End Class