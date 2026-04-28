Public Class FrmTankATG_AM
    Private g_NhomBeXuat As Boolean = False
    Private g_Edit As Boolean = False


    Private Sub FrmTankATG_M_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p_column1 As U_TextBox.GridColumn
        Dim p_Datatable As DataTable
        Dim p_String As String
        Dim p_int As Integer
        p_String = "select KEYVALUE from sys_config where KEYCODE='TANK_GROUP' "
        p_Datatable = GetDataTable(p_String, p_String)

        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                If p_Datatable.Rows(0).Item("KEYVALUE").ToString.Trim = "Y" Then
                    g_NhomBeXuat = True
                End If
            End If

        End If


        p_String = "select KEYVALUE from sys_config where KEYCODE='DB_ATG_M' "
        p_Datatable = GetDataTable(p_String, p_String)

        If Not p_Datatable Is Nothing Then
            If p_Datatable.Rows.Count > 0 Then
                If p_Datatable.Rows(0).Item("KEYVALUE").ToString.Trim <> "Y" Then
                    g_Edit = True
                End If
            End If

        End If



        Dim p_SQL = "select TankCode, Product from dbo.zTankListATG " & _
                 " where charindex(Client ,(select Terminal from sys_user  where upper(user_name ) =upper('" & g_UserName & "')),1)>0 "
        If g_NhomBeXuat = True Then
            p_SQL = "select TankCode, Product, NhomBeXuat from dbo.zTankListATG " & _
                 " where charindex(Client ,(select Terminal from sys_user  where upper(user_name ) =upper('" & g_UserName & "')),1)>0 "
        End If
        If g_Filter_Terminal = False Then
            p_SQL = "select TankCode, Product from dbo.zTankListATG "
            If g_NhomBeXuat = True Then
                p_SQL = "select TankCode, Product, NhomBeXuat from dbo.zTankListATG "
            End If
        End If

        If g_NhomBeXuat = False Then
            For p_int = 0 To Me.GridView1.Columns.Count - 1
                p_column1 = Me.GridView1.Columns.Item(p_int)
                If p_column1.Name = "NhomBeXuat" Then
                    p_column1.Visible = False
                    p_column1.FieldView = ""
                End If

            Next
        End If

        Me.DefaultFormLoad = True
        Me.LoadDataToForm()
        Me.DefaultFormLoad = False

        If g_Edit = False Then
            Me.GridView1.OptionsBehavior.ReadOnly = True
            cmdSave.Visible = False
        Else
            Me.GridView1.OptionsBehavior.ReadOnly = False
            cmdSave.Visible = True
        End If


        p_column1 = Me.GridView1.Columns.Item("TankCode")
        If g_NhomBeXuat = True Then
            p_column1.CFLReturn2 = "NhomBeXuat"
        End If
        p_column1.SQLString = p_SQL
        Dim p_ColTypeButtonEdit As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit

        p_ColTypeButtonEdit = p_column1.ColumnEdit
        AddHandler p_ColTypeButtonEdit.ButtonClick, AddressOf Column_Button_Click


    End Sub


    Public Sub Column_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_Column1 As New U_TextBox.GridColumn
        Dim p_SQL As String = ""
        Dim p_Client As String = ""



        p_Column1 = Me.GridView1.Columns.Item("TankCode")
        'p_Column1.SQLString = p_SQL
        p_Column1.ButtonClick = True
        Me.Gridview_Column_Button_Click(sender, e)
        p_Column1.ButtonClick = False
    End Sub



    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Me.DefaultSave = True
        Me.UpdateToDatabase(Me)
        Me.DefaultSave = False
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Dim FrmATG As New FrmTankListATG_AM_Hist
        FrmATG.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmATG.g_XtraServicesObj = g_XtraServicesObj
        'FrmATG.g_Approved = g_Approved
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim

        ' FrmLenhXuatAdd.READ_ONLY = Me.READ_ONLY

        FrmATG.p_XtraToolTripLabel = g_ToolStripStatus
        FrmATG.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmATG.g_NhomBeXuat = g_NhomBeXuat
        FrmATG.p_XtraMessageStatusl = g_MessageStatus
        FrmATG.g_Tank = "" ' p_DataRow.Item("TankCode").ToString.Trim

        FrmATG.ShowDialog(Me)

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim FrmLenhXuatAdd As New FrmTankATG_AM_List
        FrmLenhXuatAdd.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
        FrmLenhXuatAdd.g_XtraServicesObj = g_XtraServicesObj
        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim
        FrmLenhXuatAdd.g_FormAddnew = False
        FrmLenhXuatAdd.FormStatus = False
        FrmLenhXuatAdd.p_XtraToolTripLabel = g_ToolStripStatus
        FrmLenhXuatAdd.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
        FrmLenhXuatAdd.p_XtraMessageStatusl = g_MessageStatus
        FrmLenhXuatAdd.ShowDialog(Me)
    End Sub
End Class