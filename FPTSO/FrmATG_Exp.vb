Public Class FrmATG_Exp

    Private Sub U_ButtonCus1_Click(sender As System.Object, e As System.EventArgs) Handles U_ButtonCus1.Click
        Dim p_DocEntry As Integer = 0
        Dim p_FromDate As String = ""
        Dim p_ToDate As String = ""
        Dim p_PurposeCode As String = ""
        Dim p_Client As String = ""
        Dim p_SQL As String = ""
        Dim p_DataTable As DataTable
        Dim p_Binding As New U_TextBox.U_BindingSource

        If Not Me.DocEntry.EditValue Is Nothing Then
            Integer.TryParse(Me.DocEntry.EditValue.ToString.Trim, p_DocEntry)
        End If

        If Not Me.Client.EditValue Is Nothing Then
            p_Client = Me.Client.EditValue.ToString.Trim
        End If
        If p_Client = "" Then
            p_Client = "ALL"
        End If
        If Not Me.PurposeCode.EditValue Is Nothing Then
            p_PurposeCode = Me.PurposeCode.EditValue.ToString.Trim
        End If
        If Not Me.PurposeCode.EditValue Is Nothing Then
            p_PurposeCode = Me.PurposeCode.EditValue.ToString.Trim
        End If
        If Not Me.FromDate.EditValue Is Nothing Then
            If Me.FromDate.EditValue.ToString.Trim <> "" Then
                p_FromDate = CDate(Me.FromDate.EditValue).ToString("yyyyMMdd HH:mm:ss")
            End If
        End If
        If Not Me.ToDate.EditValue Is Nothing Then
            If Me.ToDate.EditValue.ToString.Trim <> "" Then
                p_ToDate = CDate(Me.ToDate.EditValue).ToString("yyyyMMdd HH:mm:ss")
            End If
        End If
        p_SQL = "exec FPT_DanhSachATG_SAP " & IIf(p_DocEntry = 0, "Null", p_DocEntry)
        p_SQL = p_SQL & ",'" & p_Client & "'"
        p_SQL = p_SQL & "," & IIf(p_PurposeCode = "", "Null", "'" & p_PurposeCode & "'")
        p_SQL = p_SQL & "," & IIf(p_FromDate = "", "Null", "'" & p_FromDate & "'")
        p_SQL = p_SQL & "," & IIf(p_ToDate = "", "Null", "'" & p_ToDate & "'") & ",'" & g_UserName & "'"
        p_DataTable = GetDataTable(p_SQL, p_SQL)
        p_Binding.DataSource = p_DataTable
        Me.TrueDBGrid1.DataSource = p_Binding

        Dim p_ColDate As New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        Dim p_Column As New DevExpress.XtraGrid.Columns.GridColumn
        p_Column = Me.GridView1.Columns.Item(3)
        '  p_Column.Caption = "Thời gian tạo giao dịch"
        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        ' p_ColDate.DisplayFormat.FormatString = "u"
        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.EditMask = "dd/MM/yyyy HH:mm:ss"
        p_Column.ColumnEdit = p_ColDate
        p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_Column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

        
        Dim p_ColNumber As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit

        'p_Column = New DevExpress.XtraGrid.Columns.GridColumn
        ''p_ColNumber.

        ''If p_Column.ShowCalc = False Then
        ''    p_ColNumber.Buttons(0).Visible = False
        ''End If
        p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        p_Column = Me.GridView1.Columns.Item(4)
        p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        p_ColNumber.DisplayFormat.FormatString = "#,###,###,###0."
        p_ColNumber.EditMask = "#,###,###,###0."
        p_Column.ColumnEdit = p_ColNumber

       
        'Nhiet do
        p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        p_Column = New DevExpress.XtraGrid.Columns.GridColumn
        p_Column = Me.GridView1.Columns.Item(5)
        p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        p_ColNumber.DisplayFormat.FormatString = "#,###0.#0"
        p_ColNumber.EditMask = "#,###,###,###0.#0"
        p_Column.ColumnEdit = p_ColNumber


        'Ltt
        p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        p_Column = New DevExpress.XtraGrid.Columns.GridColumn
        p_Column = Me.GridView1.Columns.Item(9)
        p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        p_ColNumber.DisplayFormat.FormatString = "#,###,###,###0."
        p_ColNumber.EditMask = "#,###,###,###0."
        p_Column.ColumnEdit = p_ColNumber

        'L15
        p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        p_Column = New DevExpress.XtraGrid.Columns.GridColumn
        p_Column = Me.GridView1.Columns.Item(11)
        p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        p_ColNumber.DisplayFormat.FormatString = "#,###,###,###0."
        p_ColNumber.EditMask = "#,###,###,###0."
        p_Column.ColumnEdit = p_ColNumber
        'KG
        p_ColNumber = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
        p_Column = New DevExpress.XtraGrid.Columns.GridColumn
        p_Column = Me.GridView1.Columns.Item(13)
        p_ColNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        p_ColNumber.DisplayFormat.FormatString = "#,###,###,###0."
        p_ColNumber.EditMask = "#,###,###,###0."
        p_Column.ColumnEdit = p_ColNumber
        ''p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        'p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        ''p_Column.DisplayFormat.FormatString = "c2"
        'p_Column.DisplayFormat.FormatString = "#,###0.#0"


        p_ColDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        p_Column = New DevExpress.XtraGrid.Columns.GridColumn
        p_Column = Me.GridView1.Columns.Item(16)
        '  p_Column.Caption = "Thời gian tạo giao dịch"
        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        ' p_ColDate.DisplayFormat.FormatString = "u"
        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.EditMask = "dd/MM/yyyy HH:mm:ss"
        p_Column.ColumnEdit = p_ColDate
        p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_Column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

        p_ColDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
        p_Column = New DevExpress.XtraGrid.Columns.GridColumn


        p_Column = Me.GridView1.Columns.Item(18)
        '  p_Column.Caption = "Thời gian tạo giao dịch"
        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        ' p_ColDate.DisplayFormat.FormatString = "u"
        p_ColDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.EditFormat.FormatString = "dd/MM/yyyy HH:mm:ss"
        p_ColDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_ColDate.EditMask = "dd/MM/yyyy HH:mm:ss"
        p_Column.ColumnEdit = p_ColDate
        p_Column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        p_Column.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss"

        Try
            Me.GridView1.Columns.Item(19).VisibleIndex = 2
        Catch ex As Exception

        End Try
        '  Me.GridView1.OptionsView.ColumnAutoWidth = True
        Me.ControlResize = True
        FindAllControls(Me)
        ' Me.GridView1.OptionsView.ColumnAutoWidth = True
    End Sub

    Private Sub FrmATG_Exp_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '  Me.GridView1.op
        Dim p_SQL As String = "select Terminal from sys_user  where user_name ='" & g_UserName & "'"
        Dim p_DAta As DataTable
        Dim p_Kho As String
        Dim p_Kho1 As Integer = 0
        Dim p_Kho2 As Integer = 0
        Dim p_Kho3 As Integer = 0
        p_DAta = GetDataTable(p_SQL, p_SQL)


        If Not p_DAta Is Nothing Then
            If p_DAta.Rows.Count > 0 Then
                p_Kho = p_DAta.Rows(0).Item("Terminal").ToString.Trim
            End If
        End If
        p_SQL = ""

        p_Kho1 = InStr(p_Kho, "A", CompareMethod.Text)
        If p_Kho1 > 0 Then
            p_SQL = "select 'A' as Kho"
        End If

        p_Kho2 = InStr(p_Kho, "B", CompareMethod.Text)
        If p_Kho2 > 0 Then
            If p_SQL <> "" Then
                p_SQL = p_SQL & " UNION ALL select 'B' as Kho"
            Else
                p_SQL = "select 'B'  as Kho "
            End If
        End If

        p_Kho3 = InStr(p_Kho, "C", CompareMethod.Text)
        '  p_Kho2 = InStr(p_Kho, "B", CompareMethod.Text)
        If p_Kho3 > 0 Then
            If p_SQL <> "" Then
                p_SQL = p_SQL & " UNION ALL select 'C' as Kho "
            Else
                p_SQL = "select 'C' as Kho"
            End If
        End If
        If p_Kho3 > 0 And p_Kho2 > 0 And p_Kho1 > 0 Then
            If p_SQL <> "" Then
                p_SQL = p_SQL & " UNION ALL select 'ALL' as Kho "
            Else
                p_SQL = "select 'ALL' as Kho"
            End If
        End If

        If p_SQL <> "" Then
            Me.Client.SqlString = p_SQL
        End If

    End Sub

    Private Sub U_ButtonCus2_Click(sender As System.Object, e As System.EventArgs) Handles U_ButtonCus2.Click
        Dim p_Error As String = ""
        If p_XtraModuleObj.p_ModGridExportToExcelNew(TrueDBGrid1, _
                                          p_Error) = True Then

        End If
    End Sub

    Private Sub TrueDBGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrueDBGrid1.Click

    End Sub



    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
        Dim p_DataRow As DataRow
        Dim p_SQL As String = ""
        Dim p_DataTable As DataTable
        Dim p_DocEntry As Integer = 0
        If Me.GridView1.RowCount > 0 Then
            p_DataRow = Me.GridView1.GetFocusedDataRow
            If Not p_DataRow Is Nothing Then


                Integer.TryParse(p_DataRow.Item(0).ToString.Trim, p_DocEntry)

                p_SQL = "select TankHeaderCode, sType  from [dbo].[ztblTankHeaderImp]  where DocEntry =" & p_DocEntry
                p_DataTable = GetDataTable(p_SQL, p_SQL)
                If Not p_DataTable Is Nothing Then
                    If p_DataTable.Rows.Count > 0 Then
                        Dim FrmATG As New FrmTankHeaderImp
                        FrmATG.p_XtraModuleObj = p_XtraModuleObj ' p_FptModule
                        FrmATG.g_XtraServicesObj = g_XtraServicesObj
                        FrmATG.g_Approved = False ' g_Approved
                        'FrmMenu.DefaultWhere = "DocEntry=" & p_DataRow.Item(Me.U_TrueDBGrid1.ColumnKey).ToString.Trim

                        ' FrmLenhXuatAdd.READ_ONLY = Me.READ_ONLY
                        FrmATG.ViewAdmin = False  ' Me.ViewAdmin
                        FrmATG.p_XtraToolTripLabel = g_ToolStripStatus
                        FrmATG.p_XtraDataSet_TrueGird = p_DataSet_TrueGird
                        FrmATG.p_XtraMessageStatusl = g_MessageStatus
                        FrmATG.g_TankHeaderCode = p_DataTable.Rows(0).Item("TankHeaderCode").ToString.Trim
                        If p_DataTable.Rows(0).Item("sType").ToString.Trim = "M" Then   'p_DataRow.Item("sType").ToString.Trim = "M" Then
                            FrmATG.g_Auto = False
                        End If
                        FrmATG.ShowDialog(Me)
                    End If
                End If
               
            End If

        End If
    End Sub

End Class