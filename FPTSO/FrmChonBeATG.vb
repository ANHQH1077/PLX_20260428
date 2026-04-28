Public Class FrmChonBeATG
    Public g_StringTank As String = ""
    Public g_Tank As String = ""
    Public g_Status As String = ""
    Public g_Date As String = ""
    Public g_TankATG_AM_List As Boolean = False

    Private Sub FrmChonBeATG_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim p_SQL As String = ""   'where charindex(left(TankCode,1),(select Terminal  from sys_USeR where upper(USER_NAME) =UPPER('" & g_UserName & "')),1)>0"
        Dim p_Count As Integer
        Dim p_Count2 As Integer
        Dim p_StrSplit() As String
        Dim p_Datatable As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_ColType As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

        If g_TankATG_AM_List = False Then
            p_SQL = "SELECT 'N' as X, [TankCode],[Product]  FROM [zTankListATG_v] b "
            If g_Tank = "ALL" Then
                p_SQL = p_SQL & "  where 1=1 "
            ElseIf g_Tank = "C" Then
                p_SQL = p_SQL & " where (left(TankCode,1) ='C' or  left(TankCode,1) ='D')"
            Else
                p_SQL = p_SQL & " where (left(TankCode,1) ='" & g_Tank & "')  "
            End If

            If g_Date <> "" Then
                p_SQL = p_SQL & " and  not exists (select 1  from dbo.zTankListATG_AM  h  where  '" & g_Date & "' >=   isnull(FROMDATE,getdate()-5) " & _
                                 " and '" & g_Date & "'  <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.TankCode ) "

                p_SQL = p_SQL & " and  not exists (select 1  from dbo.zTankListATG_M  h  where  '" & g_Date & "' >=   isnull(FROMDATE,getdate()-5) " & _
                              " and '" & g_Date & "'  <= isnull(ToDATE,getdate()+5)  and h.TankCode =b.TankCode ) "
            End If
        Else
            p_SQL = "SELECT 'N' as X, [TankCode],[Product]  FROM [zTankListATG_v] b "
            If g_Tank = "ALL" Then
                p_SQL = p_SQL & "  where 1=1 "
            ElseIf g_Tank = "C" Then
                p_SQL = p_SQL & " where (left(TankCode,1) ='C' or  left(TankCode,1) ='D')"
            Else
                p_SQL = p_SQL & " where (left(TankCode,1) ='" & g_Tank & "')  "
            End If
          
        End If
       
        




        p_SQL = p_SQL & " order by TankCode"
        p_Datatable = GetDataTable(p_SQL, p_SQL)

        If Not p_Datatable Is Nothing Then
            If g_StringTank <> "" Then
                p_StrSplit = g_StringTank.Split(",")
                For p_Count = 0 To p_StrSplit.Length - 1
                    For p_Count1 = 0 To p_Datatable.Rows.Count - 1
                        If p_Datatable.Rows(p_Count1).Item("TankCode").ToString.Trim = p_StrSplit(p_Count).ToString.Trim Then
                            p_Datatable.Rows(p_Count1).Item("X") = "Y"
                        End If
                    Next
                Next
            End If
            p_Binding.DataSource = p_Datatable
            Me.TrueDBGrid1.DataSource = p_Binding
            If g_Status = "S" Then
                Me.GridView1.OptionsBehavior.ReadOnly = True
            End If
            GridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
            p_ColType = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
            p_ColType.ValueChecked = "Y"
            p_ColType.ValueUnchecked = "N"
            GridView1.Columns.Item(0).ColumnEdit = p_ColType

        End If
      
    End Sub

    Private Sub U_ButtonCus1_Click(sender As System.Object, e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_Datatable As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_Count As Integer
        p_Binding = Me.TrueDBGrid1.DataSource
        p_Datatable = CType(p_Binding.DataSource, DataTable)
        g_StringTank = ""
        For p_Count = 0 To p_Datatable.Rows.Count - 1
            If p_Datatable.Rows(p_Count).Item("X").ToString.Trim = "Y" Then
                g_StringTank = g_StringTank & "," & p_Datatable.Rows(p_Count).Item("TankCode").ToString.Trim
            End If
        Next
        If g_StringTank <> "" Then
            g_StringTank = Mid(g_StringTank, 2)
        End If
        Me.Close()
    End Sub

   

    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick

    End Sub
End Class