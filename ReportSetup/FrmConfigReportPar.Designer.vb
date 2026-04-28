<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigReportPar
    Inherits U_CusForm.XtraCusForm1

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ReportCode = New U_TextBox.GridColumn()
        Me.STT = New U_TextBox.GridColumn()
        Me.ItemName = New U_TextBox.GridColumn()
        Me.ItemDesc = New U_TextBox.GridColumn()
        Me.ItemType = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.FieldName = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ItemValue = New U_TextBox.GridColumn()
        Me.ItemSql = New U_TextBox.GridColumn()
        Me.ToItemName = New U_TextBox.GridColumn()
        Me.ToItemSql = New U_TextBox.GridColumn()
        Me.Required = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.FieldKey = New U_TextBox.GridColumn()
        Me.ShowReport = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 4)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemComboBox1, Me.RepositoryItemComboBox2, Me.RepositoryItemCheckEdit1, Me.RepositoryItemCheckEdit2})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(718, 278)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.ColumnAutoWidth = True
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ReportCode, Me.STT, Me.ItemName, Me.ItemDesc, Me.ItemType, Me.FieldName, Me.ItemValue, Me.ItemSql, Me.ToItemName, Me.ToItemSql, Me.Required, Me.FieldKey, Me.ShowReport, Me.CHECKUPD})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = ""
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "SYS_CONFIG_RPT_PARA"
        Me.GridView1.ViewName = "SYS_CONFIG_RPT_PARA_V"
        Me.GridView1.Where = Nothing
        '
        'ReportCode
        '
        Me.ReportCode.AllowInsert = True
        Me.ReportCode.AllowUpdate = True
        Me.ReportCode.Caption = "GridColumn1"
        Me.ReportCode.CFLColumnHide = ""
        Me.ReportCode.CFLKeyField = ""
        Me.ReportCode.CFLPage = False
        Me.ReportCode.CFLReturn0 = ""
        Me.ReportCode.CFLReturn1 = ""
        Me.ReportCode.CFLReturn2 = ""
        Me.ReportCode.CFLReturn3 = ""
        Me.ReportCode.CFLReturn4 = ""
        Me.ReportCode.CFLShowLoad = False
        Me.ReportCode.ChangeFormStatus = True
        Me.ReportCode.ColumnKey = True
        Me.ReportCode.ComboLine = 5
        Me.ReportCode.CopyFromItem = ""
        Me.ReportCode.DefaultButtonClick = False
        Me.ReportCode.Digit = False
        Me.ReportCode.FieldType = "C"
        Me.ReportCode.FieldView = "ReportCode"
        Me.ReportCode.FormList = False
        Me.ReportCode.KeyInsert = ""
        Me.ReportCode.LocalDecimal = False
        Me.ReportCode.Name = "ReportCode"
        Me.ReportCode.NoUpdate = ""
        Me.ReportCode.NumberDecimal = 0
        Me.ReportCode.ParentControl = ""
        Me.ReportCode.RefreshSource = False
        Me.ReportCode.Required = False
        Me.ReportCode.ShowDataTime = False
        Me.ReportCode.SQLString = ""
        Me.ReportCode.UpdateIfNull = ""
        Me.ReportCode.UpdateWhenFormLock = False
        Me.ReportCode.ValidateValue = True
        '
        'STT
        '
        Me.STT.AllowInsert = True
        Me.STT.AllowUpdate = True
        Me.STT.Caption = "STT"
        Me.STT.CFLColumnHide = ""
        Me.STT.CFLKeyField = ""
        Me.STT.CFLPage = False
        Me.STT.CFLReturn0 = ""
        Me.STT.CFLReturn1 = ""
        Me.STT.CFLReturn2 = ""
        Me.STT.CFLReturn3 = ""
        Me.STT.CFLReturn4 = ""
        Me.STT.CFLShowLoad = False
        Me.STT.ChangeFormStatus = True
        Me.STT.ColumnKey = True
        Me.STT.ComboLine = 5
        Me.STT.CopyFromItem = ""
        Me.STT.DefaultButtonClick = False
        Me.STT.Digit = False
        Me.STT.FieldType = "N"
        Me.STT.FieldView = "STT"
        Me.STT.FormList = False
        Me.STT.KeyInsert = ""
        Me.STT.LocalDecimal = False
        Me.STT.Name = "STT"
        Me.STT.NoUpdate = ""
        Me.STT.NumberDecimal = 0
        Me.STT.ParentControl = ""
        Me.STT.RefreshSource = False
        Me.STT.Required = True
        Me.STT.ShowDataTime = False
        Me.STT.SQLString = ""
        Me.STT.UpdateIfNull = ""
        Me.STT.UpdateWhenFormLock = False
        Me.STT.ValidateValue = True
        Me.STT.Visible = True
        Me.STT.VisibleIndex = 0
        Me.STT.Width = 30
        '
        'ItemName
        '
        Me.ItemName.AllowInsert = True
        Me.ItemName.AllowUpdate = True
        Me.ItemName.Caption = "Item name"
        Me.ItemName.CFLColumnHide = ""
        Me.ItemName.CFLKeyField = ""
        Me.ItemName.CFLPage = False
        Me.ItemName.CFLReturn0 = ""
        Me.ItemName.CFLReturn1 = ""
        Me.ItemName.CFLReturn2 = ""
        Me.ItemName.CFLReturn3 = ""
        Me.ItemName.CFLReturn4 = ""
        Me.ItemName.CFLShowLoad = False
        Me.ItemName.ChangeFormStatus = True
        Me.ItemName.ColumnKey = False
        Me.ItemName.ComboLine = 5
        Me.ItemName.CopyFromItem = ""
        Me.ItemName.DefaultButtonClick = False
        Me.ItemName.Digit = False
        Me.ItemName.FieldType = "C"
        Me.ItemName.FieldView = "ItemName"
        Me.ItemName.FormList = False
        Me.ItemName.KeyInsert = ""
        Me.ItemName.LocalDecimal = False
        Me.ItemName.Name = "ItemName"
        Me.ItemName.NoUpdate = ""
        Me.ItemName.NumberDecimal = 0
        Me.ItemName.ParentControl = ""
        Me.ItemName.RefreshSource = False
        Me.ItemName.Required = True
        Me.ItemName.ShowDataTime = False
        Me.ItemName.SQLString = ""
        Me.ItemName.UpdateIfNull = ""
        Me.ItemName.UpdateWhenFormLock = False
        Me.ItemName.ValidateValue = True
        Me.ItemName.Visible = True
        Me.ItemName.VisibleIndex = 1
        '
        'ItemDesc
        '
        Me.ItemDesc.AllowInsert = True
        Me.ItemDesc.AllowUpdate = True
        Me.ItemDesc.Caption = "Item desc"
        Me.ItemDesc.CFLColumnHide = ""
        Me.ItemDesc.CFLKeyField = ""
        Me.ItemDesc.CFLPage = False
        Me.ItemDesc.CFLReturn0 = ""
        Me.ItemDesc.CFLReturn1 = ""
        Me.ItemDesc.CFLReturn2 = ""
        Me.ItemDesc.CFLReturn3 = ""
        Me.ItemDesc.CFLReturn4 = ""
        Me.ItemDesc.CFLShowLoad = False
        Me.ItemDesc.ChangeFormStatus = True
        Me.ItemDesc.ColumnKey = False
        Me.ItemDesc.ComboLine = 5
        Me.ItemDesc.CopyFromItem = ""
        Me.ItemDesc.DefaultButtonClick = False
        Me.ItemDesc.Digit = False
        Me.ItemDesc.FieldType = "C"
        Me.ItemDesc.FieldView = "ItemDesc"
        Me.ItemDesc.FormList = False
        Me.ItemDesc.KeyInsert = ""
        Me.ItemDesc.LocalDecimal = False
        Me.ItemDesc.Name = "ItemDesc"
        Me.ItemDesc.NoUpdate = ""
        Me.ItemDesc.NumberDecimal = 0
        Me.ItemDesc.ParentControl = ""
        Me.ItemDesc.RefreshSource = False
        Me.ItemDesc.Required = True
        Me.ItemDesc.ShowDataTime = False
        Me.ItemDesc.SQLString = ""
        Me.ItemDesc.UpdateIfNull = ""
        Me.ItemDesc.UpdateWhenFormLock = False
        Me.ItemDesc.ValidateValue = True
        Me.ItemDesc.Visible = True
        Me.ItemDesc.VisibleIndex = 2
        Me.ItemDesc.Width = 130
        '
        'ItemType
        '
        Me.ItemType.AllowInsert = True
        Me.ItemType.AllowUpdate = True
        Me.ItemType.Caption = "Item type"
        Me.ItemType.CFLColumnHide = ""
        Me.ItemType.CFLKeyField = ""
        Me.ItemType.CFLPage = False
        Me.ItemType.CFLReturn0 = ""
        Me.ItemType.CFLReturn1 = ""
        Me.ItemType.CFLReturn2 = ""
        Me.ItemType.CFLReturn3 = ""
        Me.ItemType.CFLReturn4 = ""
        Me.ItemType.CFLShowLoad = False
        Me.ItemType.ChangeFormStatus = True
        Me.ItemType.ColumnEdit = Me.RepositoryItemComboBox1
        Me.ItemType.ColumnKey = False
        Me.ItemType.ComboLine = 5
        Me.ItemType.CopyFromItem = ""
        Me.ItemType.DefaultButtonClick = False
        Me.ItemType.Digit = False
        Me.ItemType.FieldType = "C"
        Me.ItemType.FieldView = "ItemType"
        Me.ItemType.FormList = False
        Me.ItemType.KeyInsert = ""
        Me.ItemType.LocalDecimal = False
        Me.ItemType.Name = "ItemType"
        Me.ItemType.NoUpdate = ""
        Me.ItemType.NumberDecimal = 0
        Me.ItemType.ParentControl = ""
        Me.ItemType.RefreshSource = False
        Me.ItemType.Required = True
        Me.ItemType.ShowDataTime = False
        Me.ItemType.SQLString = "select 'TEXT' as ItemType union select 'COMBOX' as ItemType union select 'LIST' a" & _
            "s ItemType"
        Me.ItemType.UpdateIfNull = ""
        Me.ItemType.UpdateWhenFormLock = False
        Me.ItemType.ValidateValue = True
        Me.ItemType.Visible = True
        Me.ItemType.VisibleIndex = 3
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'FieldName
        '
        Me.FieldName.AllowInsert = True
        Me.FieldName.AllowUpdate = True
        Me.FieldName.Caption = "Column Name"
        Me.FieldName.CFLColumnHide = ""
        Me.FieldName.CFLKeyField = "name"
        Me.FieldName.CFLPage = False
        Me.FieldName.CFLReturn0 = "FieldName"
        Me.FieldName.CFLReturn1 = "ItemValue"
        Me.FieldName.CFLReturn2 = ""
        Me.FieldName.CFLReturn3 = ""
        Me.FieldName.CFLReturn4 = ""
        Me.FieldName.CFLShowLoad = False
        Me.FieldName.ChangeFormStatus = True
        Me.FieldName.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.FieldName.ColumnKey = False
        Me.FieldName.ComboLine = 5
        Me.FieldName.CopyFromItem = ""
        Me.FieldName.DefaultButtonClick = False
        Me.FieldName.Digit = False
        Me.FieldName.FieldType = "C"
        Me.FieldName.FieldView = "FieldName"
        Me.FieldName.FormList = False
        Me.FieldName.KeyInsert = ""
        Me.FieldName.LocalDecimal = False
        Me.FieldName.Name = "FieldName"
        Me.FieldName.NoUpdate = ""
        Me.FieldName.NumberDecimal = 0
        Me.FieldName.ParentControl = ""
        Me.FieldName.RefreshSource = False
        Me.FieldName.Required = True
        Me.FieldName.ShowDataTime = False
        Me.FieldName.SQLString = ""
        Me.FieldName.UpdateIfNull = ""
        Me.FieldName.UpdateWhenFormLock = False
        Me.FieldName.ValidateValue = False
        Me.FieldName.Visible = True
        Me.FieldName.VisibleIndex = 4
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'ItemValue
        '
        Me.ItemValue.AllowInsert = True
        Me.ItemValue.AllowUpdate = True
        Me.ItemValue.Caption = "Field Type"
        Me.ItemValue.CFLColumnHide = ""
        Me.ItemValue.CFLKeyField = ""
        Me.ItemValue.CFLPage = False
        Me.ItemValue.CFLReturn0 = ""
        Me.ItemValue.CFLReturn1 = ""
        Me.ItemValue.CFLReturn2 = ""
        Me.ItemValue.CFLReturn3 = ""
        Me.ItemValue.CFLReturn4 = ""
        Me.ItemValue.CFLShowLoad = False
        Me.ItemValue.ChangeFormStatus = True
        Me.ItemValue.ColumnKey = False
        Me.ItemValue.ComboLine = 5
        Me.ItemValue.CopyFromItem = ""
        Me.ItemValue.DefaultButtonClick = False
        Me.ItemValue.Digit = False
        Me.ItemValue.FieldType = "C"
        Me.ItemValue.FieldView = "ItemValue"
        Me.ItemValue.FormList = False
        Me.ItemValue.KeyInsert = ""
        Me.ItemValue.LocalDecimal = False
        Me.ItemValue.Name = "ItemValue"
        Me.ItemValue.NoUpdate = ""
        Me.ItemValue.NumberDecimal = 0
        Me.ItemValue.ParentControl = ""
        Me.ItemValue.RefreshSource = False
        Me.ItemValue.Required = False
        Me.ItemValue.ShowDataTime = False
        Me.ItemValue.SQLString = ""
        Me.ItemValue.UpdateIfNull = ""
        Me.ItemValue.UpdateWhenFormLock = False
        Me.ItemValue.ValidateValue = True
        Me.ItemValue.Visible = True
        Me.ItemValue.VisibleIndex = 5
        '
        'ItemSql
        '
        Me.ItemSql.AllowInsert = True
        Me.ItemSql.AllowUpdate = True
        Me.ItemSql.Caption = "Item SQL"
        Me.ItemSql.CFLColumnHide = ""
        Me.ItemSql.CFLKeyField = ""
        Me.ItemSql.CFLPage = False
        Me.ItemSql.CFLReturn0 = ""
        Me.ItemSql.CFLReturn1 = ""
        Me.ItemSql.CFLReturn2 = ""
        Me.ItemSql.CFLReturn3 = ""
        Me.ItemSql.CFLReturn4 = ""
        Me.ItemSql.CFLShowLoad = False
        Me.ItemSql.ChangeFormStatus = True
        Me.ItemSql.ColumnKey = False
        Me.ItemSql.ComboLine = 5
        Me.ItemSql.CopyFromItem = ""
        Me.ItemSql.DefaultButtonClick = False
        Me.ItemSql.Digit = False
        Me.ItemSql.FieldType = "C"
        Me.ItemSql.FieldView = "ItemSql"
        Me.ItemSql.FormList = False
        Me.ItemSql.KeyInsert = ""
        Me.ItemSql.LocalDecimal = False
        Me.ItemSql.Name = "ItemSql"
        Me.ItemSql.NoUpdate = ""
        Me.ItemSql.NumberDecimal = 0
        Me.ItemSql.ParentControl = ""
        Me.ItemSql.RefreshSource = False
        Me.ItemSql.Required = False
        Me.ItemSql.ShowDataTime = False
        Me.ItemSql.SQLString = ""
        Me.ItemSql.UpdateIfNull = ""
        Me.ItemSql.UpdateWhenFormLock = False
        Me.ItemSql.ValidateValue = True
        Me.ItemSql.Visible = True
        Me.ItemSql.VisibleIndex = 6
        Me.ItemSql.Width = 200
        '
        'ToItemName
        '
        Me.ToItemName.AllowInsert = True
        Me.ToItemName.AllowUpdate = True
        Me.ToItemName.Caption = "To item name"
        Me.ToItemName.CFLColumnHide = ""
        Me.ToItemName.CFLKeyField = ""
        Me.ToItemName.CFLPage = False
        Me.ToItemName.CFLReturn0 = ""
        Me.ToItemName.CFLReturn1 = ""
        Me.ToItemName.CFLReturn2 = ""
        Me.ToItemName.CFLReturn3 = ""
        Me.ToItemName.CFLReturn4 = ""
        Me.ToItemName.CFLShowLoad = False
        Me.ToItemName.ChangeFormStatus = True
        Me.ToItemName.ColumnKey = False
        Me.ToItemName.ComboLine = 5
        Me.ToItemName.CopyFromItem = ""
        Me.ToItemName.DefaultButtonClick = False
        Me.ToItemName.Digit = False
        Me.ToItemName.FieldType = "C"
        Me.ToItemName.FieldView = "ToItemName"
        Me.ToItemName.FormList = False
        Me.ToItemName.KeyInsert = ""
        Me.ToItemName.LocalDecimal = False
        Me.ToItemName.Name = "ToItemName"
        Me.ToItemName.NoUpdate = ""
        Me.ToItemName.NumberDecimal = 0
        Me.ToItemName.ParentControl = ""
        Me.ToItemName.RefreshSource = False
        Me.ToItemName.Required = False
        Me.ToItemName.ShowDataTime = False
        Me.ToItemName.SQLString = ""
        Me.ToItemName.UpdateIfNull = ""
        Me.ToItemName.UpdateWhenFormLock = False
        Me.ToItemName.ValidateValue = True
        Me.ToItemName.Visible = True
        Me.ToItemName.VisibleIndex = 7
        '
        'ToItemSql
        '
        Me.ToItemSql.AllowInsert = True
        Me.ToItemSql.AllowUpdate = True
        Me.ToItemSql.Caption = "To item SQL"
        Me.ToItemSql.CFLColumnHide = ""
        Me.ToItemSql.CFLKeyField = ""
        Me.ToItemSql.CFLPage = False
        Me.ToItemSql.CFLReturn0 = ""
        Me.ToItemSql.CFLReturn1 = ""
        Me.ToItemSql.CFLReturn2 = ""
        Me.ToItemSql.CFLReturn3 = ""
        Me.ToItemSql.CFLReturn4 = ""
        Me.ToItemSql.CFLShowLoad = False
        Me.ToItemSql.ChangeFormStatus = True
        Me.ToItemSql.ColumnKey = False
        Me.ToItemSql.ComboLine = 5
        Me.ToItemSql.CopyFromItem = ""
        Me.ToItemSql.DefaultButtonClick = False
        Me.ToItemSql.Digit = False
        Me.ToItemSql.FieldType = "C"
        Me.ToItemSql.FieldView = "ToItemSql"
        Me.ToItemSql.FormList = False
        Me.ToItemSql.KeyInsert = ""
        Me.ToItemSql.LocalDecimal = False
        Me.ToItemSql.Name = "ToItemSql"
        Me.ToItemSql.NoUpdate = ""
        Me.ToItemSql.NumberDecimal = 0
        Me.ToItemSql.ParentControl = ""
        Me.ToItemSql.RefreshSource = False
        Me.ToItemSql.Required = False
        Me.ToItemSql.ShowDataTime = False
        Me.ToItemSql.SQLString = ""
        Me.ToItemSql.UpdateIfNull = ""
        Me.ToItemSql.UpdateWhenFormLock = False
        Me.ToItemSql.ValidateValue = True
        Me.ToItemSql.Visible = True
        Me.ToItemSql.VisibleIndex = 8
        Me.ToItemSql.Width = 200
        '
        'Required
        '
        Me.Required.AllowInsert = True
        Me.Required.AllowUpdate = True
        Me.Required.Caption = "Required"
        Me.Required.CFLColumnHide = ""
        Me.Required.CFLKeyField = ""
        Me.Required.CFLPage = False
        Me.Required.CFLReturn0 = ""
        Me.Required.CFLReturn1 = ""
        Me.Required.CFLReturn2 = ""
        Me.Required.CFLReturn3 = ""
        Me.Required.CFLReturn4 = ""
        Me.Required.CFLShowLoad = False
        Me.Required.ChangeFormStatus = True
        Me.Required.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.Required.ColumnKey = False
        Me.Required.ComboLine = 5
        Me.Required.CopyFromItem = ""
        Me.Required.DefaultButtonClick = False
        Me.Required.Digit = False
        Me.Required.FieldType = "C"
        Me.Required.FieldView = "Required"
        Me.Required.FormList = False
        Me.Required.KeyInsert = ""
        Me.Required.LocalDecimal = False
        Me.Required.Name = "Required"
        Me.Required.NoUpdate = ""
        Me.Required.NumberDecimal = 0
        Me.Required.ParentControl = ""
        Me.Required.RefreshSource = False
        Me.Required.Required = False
        Me.Required.ShowDataTime = False
        Me.Required.SQLString = ""
        Me.Required.UpdateIfNull = ""
        Me.Required.UpdateWhenFormLock = False
        Me.Required.ValidateValue = True
        Me.Required.Visible = True
        Me.Required.VisibleIndex = 10
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'FieldKey
        '
        Me.FieldKey.AllowInsert = True
        Me.FieldKey.AllowUpdate = True
        Me.FieldKey.Caption = "FieldKey"
        Me.FieldKey.CFLColumnHide = ""
        Me.FieldKey.CFLKeyField = ""
        Me.FieldKey.CFLPage = False
        Me.FieldKey.CFLReturn0 = ""
        Me.FieldKey.CFLReturn1 = ""
        Me.FieldKey.CFLReturn2 = ""
        Me.FieldKey.CFLReturn3 = ""
        Me.FieldKey.CFLReturn4 = ""
        Me.FieldKey.CFLShowLoad = False
        Me.FieldKey.ChangeFormStatus = True
        Me.FieldKey.ColumnKey = False
        Me.FieldKey.ComboLine = 5
        Me.FieldKey.CopyFromItem = ""
        Me.FieldKey.DefaultButtonClick = False
        Me.FieldKey.Digit = False
        Me.FieldKey.FieldType = "C"
        Me.FieldKey.FieldView = "FieldKey"
        Me.FieldKey.FormList = False
        Me.FieldKey.KeyInsert = ""
        Me.FieldKey.LocalDecimal = False
        Me.FieldKey.Name = "FieldKey"
        Me.FieldKey.NoUpdate = ""
        Me.FieldKey.NumberDecimal = 0
        Me.FieldKey.ParentControl = ""
        Me.FieldKey.RefreshSource = False
        Me.FieldKey.Required = False
        Me.FieldKey.ShowDataTime = False
        Me.FieldKey.SQLString = ""
        Me.FieldKey.UpdateIfNull = ""
        Me.FieldKey.UpdateWhenFormLock = False
        Me.FieldKey.ValidateValue = True
        Me.FieldKey.Visible = True
        Me.FieldKey.VisibleIndex = 9
        '
        'ShowReport
        '
        Me.ShowReport.AllowInsert = True
        Me.ShowReport.AllowUpdate = True
        Me.ShowReport.Caption = "Show Report"
        Me.ShowReport.CFLColumnHide = ""
        Me.ShowReport.CFLKeyField = ""
        Me.ShowReport.CFLPage = False
        Me.ShowReport.CFLReturn0 = ""
        Me.ShowReport.CFLReturn1 = ""
        Me.ShowReport.CFLReturn2 = ""
        Me.ShowReport.CFLReturn3 = ""
        Me.ShowReport.CFLReturn4 = ""
        Me.ShowReport.CFLShowLoad = False
        Me.ShowReport.ChangeFormStatus = True
        Me.ShowReport.ColumnEdit = Me.RepositoryItemCheckEdit2
        Me.ShowReport.ColumnKey = False
        Me.ShowReport.ComboLine = 5
        Me.ShowReport.CopyFromItem = ""
        Me.ShowReport.DefaultButtonClick = False
        Me.ShowReport.Digit = False
        Me.ShowReport.FieldType = "C"
        Me.ShowReport.FieldView = "ShowReport"
        Me.ShowReport.FormList = False
        Me.ShowReport.KeyInsert = ""
        Me.ShowReport.LocalDecimal = False
        Me.ShowReport.Name = "ShowReport"
        Me.ShowReport.NoUpdate = ""
        Me.ShowReport.NumberDecimal = 0
        Me.ShowReport.ParentControl = ""
        Me.ShowReport.RefreshSource = False
        Me.ShowReport.Required = False
        Me.ShowReport.ShowDataTime = False
        Me.ShowReport.SQLString = ""
        Me.ShowReport.UpdateIfNull = ""
        Me.ShowReport.UpdateWhenFormLock = False
        Me.ShowReport.ValidateValue = True
        Me.ShowReport.Visible = True
        Me.ShowReport.VisibleIndex = 11
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        '
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
        Me.CHECKUPD.Caption = "CHECKUPD"
        Me.CHECKUPD.CFLColumnHide = ""
        Me.CHECKUPD.CFLKeyField = ""
        Me.CHECKUPD.CFLPage = False
        Me.CHECKUPD.CFLReturn0 = ""
        Me.CHECKUPD.CFLReturn1 = ""
        Me.CHECKUPD.CFLReturn2 = ""
        Me.CHECKUPD.CFLReturn3 = ""
        Me.CHECKUPD.CFLReturn4 = ""
        Me.CHECKUPD.CFLShowLoad = False
        Me.CHECKUPD.ChangeFormStatus = True
        Me.CHECKUPD.ColumnKey = False
        Me.CHECKUPD.ComboLine = 5
        Me.CHECKUPD.CopyFromItem = ""
        Me.CHECKUPD.DefaultButtonClick = False
        Me.CHECKUPD.Digit = False
        Me.CHECKUPD.FieldType = "C"
        Me.CHECKUPD.FieldView = "CHECKUPD"
        Me.CHECKUPD.FormList = False
        Me.CHECKUPD.KeyInsert = ""
        Me.CHECKUPD.LocalDecimal = False
        Me.CHECKUPD.Name = "CHECKUPD"
        Me.CHECKUPD.NoUpdate = ""
        Me.CHECKUPD.NumberDecimal = 0
        Me.CHECKUPD.ParentControl = ""
        Me.CHECKUPD.RefreshSource = False
        Me.CHECKUPD.Required = False
        Me.CHECKUPD.ShowDataTime = False
        Me.CHECKUPD.SQLString = ""
        Me.CHECKUPD.UpdateIfNull = ""
        Me.CHECKUPD.UpdateWhenFormLock = False
        Me.CHECKUPD.ValidateValue = True
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        '
        'FrmConfigReportPar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 289)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmConfigReportPar"
        Me.Text = "Tham số"
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ReportCode As U_TextBox.GridColumn
    Friend WithEvents STT As U_TextBox.GridColumn
    Friend WithEvents ItemName As U_TextBox.GridColumn
    Friend WithEvents ItemDesc As U_TextBox.GridColumn
    Friend WithEvents ItemType As U_TextBox.GridColumn
    Friend WithEvents FieldName As U_TextBox.GridColumn
    Friend WithEvents ItemValue As U_TextBox.GridColumn
    Friend WithEvents ItemSql As U_TextBox.GridColumn
    Friend WithEvents ToItemName As U_TextBox.GridColumn
    Friend WithEvents ToItemSql As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Required As U_TextBox.GridColumn
    Friend WithEvents FieldKey As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ShowReport As U_TextBox.GridColumn
End Class
