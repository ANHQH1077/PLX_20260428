Public Class FrmTankListATG_M_Hist
    Public g_Tank As String = ""
    Public g_NhomBeXuat As Boolean = False

    Private Sub FrmTankListATG_Hist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_column1 As U_TextBox.GridColumn
        If g_Tank <> "" Then
            Me.GridView2.Where = "Tankcode ='" & g_Tank & "'"
        End If

        If g_NhomBeXuat = False Then
            For p_int = 0 To Me.GridView2.Columns.Count - 1
                p_column1 = Me.GridView2.Columns.Item(p_int)
                If p_column1.Name = "NhomBeXuat" Then
                    p_column1.Visible = False
                    p_column1.FieldView = ""
                End If

            Next
        End If



        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False
    End Sub
End Class