Public Class FrmExtraE5
    Private p_SoLenh As String = ""
    Public Property SoLenh() As String
        Get
            Return p_SoLenh
        End Get
        Set(ByVal value As String)
            p_SoLenh = value
        End Set
    End Property

    Private p_TrangThaiLenh As String = ""
    Public Property TrangThaiLenh() As String
        Get
            Return p_TrangThaiLenh
        End Get
        Set(ByVal value As String)
            p_TrangThaiLenh = value
        End Set
    End Property


    Private Sub FrmExtraE5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Asc(e.KeyChar) = 19 Then
            If Me.FormStatus = True Then
                saverecord()
            End If
        End If
    End Sub

    Private Sub FrmExtraE5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.GridView1.Where = "SoLenh='" & p_SoLenh & "' and   exists (select 1 from tblHangHoaE5 b where b.MaHangHoa=FPT_tblLenhXuatChiTietE5_V.MaHangHoa  ) "
        'Me.DefaultFormLoad = True
        'Me.Form1_Load(sender, e)
        'Me.DefaultFormLoad = False
        LoadData()
       
        If p_TrangThaiLenh <> "31" And p_TrangThaiLenh <> "3" Then
            Me.GridView1.OptionsBehavior.ReadOnly = True
        Else
            Me.GridView1.OptionsBehavior.ReadOnly = False
        End If


      

        Me.TrueDBGrid1.UseEmbeddedNavigator = False
    End Sub

    Private Sub LoadData()
        Dim p_SQL As String
        Dim p_Binding As New U_TextBox.U_BindingSource
        Dim p_DataTabla As DataTable
        Dim p_ConfigTable As DataTable
        Dim p_ArrRow() As DataRow

        Dim p_Row As DataRow
        Dim p_Count As Integer
        Dim p_Column As U_TextBox.GridColumn
      

        ''p_Binding = Me.TrueDBGrid1.DataSource
        ''p_DataTabla = CType(p_Binding.DataSource, DataTable)

        '  If Not p_DataTabla Is Nothing Then
        'p_Binding.DataSource = p_DataTabla
        'Me.TrueDBGrid1.DataSource = p_Binding
        'TrueDBGrid1.RefreshDataSource()

        'For p_Count = Me.GridView1.Columns.Count - 1 To 0 Step -1
        '    'p_Column = Me.GridView1.Columns(p_Count)
        '    Me.GridView1.Columns.Remove(Me.GridView1.Columns(p_Count))
        'Next
        p_SQL = "SELECT  [vOrder],[FieldName],[Required] ,[sNote],[UnVisible] ,[Locked] FROM [tblLenhXuatChiTietE5_Info] order by vOrder"
        p_ConfigTable = GetDataTable(p_SQL, p_SQL)
        If Not p_ConfigTable Is Nothing Then
            For p_Count = 0 To p_ConfigTable.Rows.Count - 1
                p_Row = p_ConfigTable.Rows(p_Count)
                p_Column = New U_TextBox.GridColumn
                p_Column.Name = p_Row.Item("FieldName").ToString.Trim
                p_Column.FieldName = p_Row.Item("FieldName").ToString.Trim
                p_Column.FieldView = p_Row.Item("FieldName").ToString.Trim
                p_Column.BestFit()
                If UCase(p_Row.Item("FieldName").ToString.Trim) = "LINEID" _
                        Or UCase(p_Row.Item("FieldName").ToString.Trim) = "NGAYXUAT" _
                        Or UCase(p_Row.Item("FieldName").ToString.Trim) = "MALENH" _
                        Or UCase(p_Row.Item("FieldName").ToString.Trim) = "MANGAN" Then
                    p_Column.ColumnKey = True
                End If
                p_Column.Caption = p_Row.Item("sNote").ToString.Trim
                If p_Row.Item("UnVisible").ToString.Trim = "Y" Then
                    p_Column.Visible = False
                    p_Column.VisibleIndex = -1
                Else
                    p_Column.VisibleIndex = p_Count
                End If
                If p_Row.Item("Locked").ToString.Trim = "Y" Then
                    p_Column.OptionsColumn.AllowEdit = False
                Else
                    p_Column.OptionsColumn.AllowEdit = True
                End If
                ' p_Column.VisibleIndex = p_Count

                Me.GridView1.Columns.Add(p_Column)
            Next
            p_Column = New U_TextBox.GridColumn
            p_Column.Name = "CHECKUPD"
            p_Column.FieldName = "CHECKUPD"
            p_Column.FieldView = "CHECKUPD"
            p_Column.Caption = "CHECKUPD"
            p_Column.Visible = False
            p_Column.VisibleIndex = -1
            p_Column.OptionsColumn.AllowEdit = False
            Me.GridView1.Columns.Add(p_Column)
        End If

        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.DefaultFormLoad = True
        Me.XtraForm1_Load()
        Me.DefaultFormLoad = False


        For p_Count = 0 To Me.GridView1.Columns.Count - 1
            GridView1.Columns.Item(p_Count).BestFit()
        Next
        Dim item1 As DevExpress.XtraGrid.GridColumnSummaryItem

        item1 = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GV", "{0}")
        GridView1.Columns.Item("GV").Summary.Add(item1)

        item1 = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GST", "{0}")
        GridView1.Columns.Item("GST").Summary.Add(item1)

        item1 = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GV_BASE", "{0}")
        GridView1.Columns.Item("GV_BASE").Summary.Add(item1)

        item1 = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GST_BASE", "{0}")
        GridView1.Columns.Item("GST_BASE").Summary.Add(item1)

        item1 = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GV_E", "{0}")
        GridView1.Columns.Item("GV_E").Summary.Add(item1)

        item1 = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GST_E", "{0}")
        GridView1.Columns.Item("GST_E").Summary.Add(item1)



        p_SQL = "SELECT   dbo.FPT_ROUNDNUMBER(  sum(isnull(GST,0)) / sum(isnull(GV,0)) ,4) as VCF" & _
              "  FROM FPT_tblLenhXuatChiTietE5_V where SoLenh='" & p_SoLenh & "'  having sum(isnull(GV,0))>0"
        p_ConfigTable = GetDataTable(p_SQL, p_SQL)
        If Not p_ConfigTable Is Nothing Then
            If p_ConfigTable.Rows.Count > 0 Then
                Me.VCF.EditValue = p_ConfigTable.Rows(0).Item(0)
            End If

        End If
        '  Me.GridView1.RefreshData()
        '   End If
    End Sub

    'Private Sub LoadData()
    '    Dim p_SQL As String
    '    Dim p_Binding As New U_TextBox.U_BindingSource
    '    Dim p_DataTabla As DataTable
    '    Dim p_ConfigTable As DataTable
    '    Dim p_ArrRow() As DataRow

    '    Dim p_Row As DataRow
    '    Dim p_Count As Integer
    '    Dim p_Column As U_TextBox.GridColumn
    '    p_SQL = "SELECT * FROM FPT_tblLenhXuatChiTietE5_V a where SoLenh='" & p_SoLenh & "'" & _
    '            " and  exists (select 1 from tblHangHoaE5 b where b.MaHangHoa=a.MaHangHoa  ) "
    '    p_DataTabla = GetDataTable(p_SQL, p_SQL)
    '    If Not p_DataTabla Is Nothing Then
    '        p_Binding.DataSource = p_DataTabla
    '        Me.TrueDBGrid1.DataSource = p_Binding
    '        TrueDBGrid1.RefreshDataSource()

    '        For p_Count = Me.GridView1.Columns.Count - 1 To 0 Step -1
    '            'p_Column = Me.GridView1.Columns(p_Count)
    '            Me.GridView1.Columns.Remove(Me.GridView1.Columns(p_Count))
    '        Next
    '        p_SQL = "SELECT  [vOrder],[FieldName],[Required] ,[sNote],[UnVisible] ,[Locked] FROM [tblLenhXuatChiTietE5_Info] order by vOrder"
    '        p_ConfigTable = GetDataTable(p_SQL, p_SQL)
    '        If Not p_ConfigTable Is Nothing Then
    '            For p_Count = 0 To p_ConfigTable.Rows.Count - 1
    '                p_Row = p_ConfigTable.Rows(p_Count)
    '                p_Column = New U_TextBox.GridColumn
    '                p_Column.Name = p_Row.Item("FieldName").ToString.Trim
    '                p_Column.FieldName = p_Row.Item("FieldName").ToString.Trim
    '                If UCase(p_Row.Item("FieldName").ToString.Trim) = "LINEID" _
    '                        Or UCase(p_Row.Item("FieldName").ToString.Trim) = "NGAYXUAT" _
    '                        Or UCase(p_Row.Item("FieldName").ToString.Trim) = "MALENH" _
    '                        Or UCase(p_Row.Item("FieldName").ToString.Trim) = "MANGAN" Then
    '                    p_Column.ColumnKey = True
    '                End If
    '                p_Column.Caption = p_Row.Item("sNote").ToString.Trim
    '                If p_Row.Item("UnVisible").ToString.Trim = "Y" Then
    '                    p_Column.Visible = False
    '                    p_Column.VisibleIndex = -1
    '                Else
    '                    p_Column.VisibleIndex = p_Count
    '                End If
    '                If p_Row.Item("Locked").ToString.Trim = "Y" Then
    '                    p_Column.OptionsColumn.AllowEdit = False

    '                End If
    '                ' p_Column.VisibleIndex = p_Count
    '                Me.GridView1.Columns.Add(p_Column)
    '            Next
    '            p_Column = New U_TextBox.GridColumn
    '            p_Column.Name = "CHECKUPD"
    '            p_Column.FieldName = "CHECKUPD"
    '            p_Column.Caption = "CHECKUPD"
    '            p_Column.VisibleIndex = p_Count + 1
    '            p_Column.OptionsColumn.AllowEdit = False
    '            Me.GridView1.Columns.Add(p_Column)
    '        End If

    '        Me.GridView1.OptionsView.ColumnAutoWidth = False
    '    End If
    'End Sub


    Private Sub GridView1_ValidatingEditor(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GridView1.ValidatingEditor
        Dim p_dataRow As DataRow
        Dim p_Value As String = "Y"
        Dim p_GridName As String = Me.TrueDBGrid1.Name
        If pv_GridViewEdit.Columns.Count = 0 Then
            pv_GridViewEdit.Columns.Add("GridName")
        End If
        If pv_GridViewEdit.Rows.Count <= 0 Then
            p_dataRow = pv_GridViewEdit.NewRow
            p_dataRow.Item(0) = p_GridName
            pv_GridViewEdit.Rows.Add(p_dataRow)
        End If
        p_dataRow = Me.GridView1.GetFocusedDataRow
        If p_dataRow.Item("CHECKUPD").ToString.Trim <> "Y" Then
            Me.GridView1.SetFocusedRowCellValue("CHECKUPD", p_Value)
            Me.FormStatus = True
        End If

    End Sub


    Private Sub saverecord()
        Dim p_Column As U_TextBox.GridColumn
        Me.DefaultSave = True
        UpdateToDatabase(Me, Me.ButtonSave)
        Me.DefaultSave = False
        ' Me.GridView1.Columns.Item("CHEKUPD").FieldName = "CHECKUPD"
        'p_Column = New U_TextBox.GridColumn
        'p_Column.Name = "CHECKUPD"
        'p_Column.FieldName = "CHECKUPD"
        'p_Column.Caption = "CHECKUPD"
        'p_Column.VisibleIndex = Me.GridView1.Columns.Count
        'p_Column.OptionsColumn.AllowEdit = False
        'Me.GridView1.Columns.Add(p_Column)

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        saverecord()
    End Sub
End Class