Public Class FrmVersion

    Private Sub FrmVersion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Dim p_DataTable As DataTable
        Dim p_Err As String
        Dim p_Binding As New U_TextBox.U_BindingSource
        'Dim p_Update As New FPTUpdate.UpdateCls(g_Services)
        p_DataTable = p_GetVersion(p_Err)
        p_Binding.DataSource = p_DataTable
        Me.TrueDBGrid1.DataSource = p_Binding
        Me.TrueDBGrid1.RefreshDataSource()
        Me.GridView1.OptionsBehavior.ReadOnly = True
    End Sub
End Class