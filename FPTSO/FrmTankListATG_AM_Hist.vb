Public Class FrmTankListATG_AM_Hist
    Public g_Tank As String = ""
    Public g_NhomBeXuat As Boolean = False
    Private Sub FrmTankListATG_Hist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_column1 As U_TextBox.GridColumn
        If g_Tank <> "" Then
            Me.GridView2.Where = "Tankcode ='" & g_Tank & "'"
        End If
        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False

        If g_NhomBeXuat = False Then
            p_column1 = Me.GridView2.Columns.Item("NhomBeXuat")
            p_column1.FieldView = ""
            p_column1.Visible = False
        End If


    End Sub
End Class