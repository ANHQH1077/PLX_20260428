<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFunctionNew
    Inherits U_CusForm.XtraCusForm1  ' System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFunctionNew))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.FUNCTION_ID = New U_TextBox.GridColumn()
        Me.FORM_ID = New U_TextBox.GridColumn()
        Me.FORM_NAME = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.FUNCTION_NAME = New U_TextBox.GridColumn()
        Me.DESCRIPTION = New U_TextBox.GridColumn()
        Me.FROM_DATE = New U_TextBox.GridColumn()
        Me.TO_DATE = New U_TextBox.GridColumn()
        Me.PARVALUE = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.RepositoryItemGridLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.RepositoryItemGridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.BtnOk = New U_TextBox.U_ButtonCus(Me.components)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(2, 2)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemGridLookUpEdit1, Me.RepositoryItemLookUpEdit1, Me.RepositoryItemButtonEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(838, 417)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.DetailTip.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.Empty.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.EvenRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FilterPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FocusedRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.GroupButton.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.GroupFooter.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.GroupPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.HorzLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.OddRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.Preview.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.RowSeparator.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.SelectedRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.TopNewRow.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.VertLine.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.Appearance.ViewCaption.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = "FUNCTION_ID"
        Me.GridView1.ColumnKeyIns = False
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.FUNCTION_ID, Me.FORM_ID, Me.FORM_NAME, Me.FUNCTION_NAME, Me.DESCRIPTION, Me.FROM_DATE, Me.TO_DATE, Me.PARVALUE, Me.CHECKUPD})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OrderBy = "FUNCTION_NAME"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "SYS_FUNCTION"
        Me.GridView1.ViewName = "SYS_FUNCTION_V"
        Me.GridView1.Where = Nothing
        '
        'FUNCTION_ID
        '
        Me.FUNCTION_ID.AllowInsert = False
        Me.FUNCTION_ID.AllowUpdate = False
        Me.FUNCTION_ID.ButtonClick = True
        Me.FUNCTION_ID.Caption = "FUNCTION_ID"
        Me.FUNCTION_ID.CFLColumnHide = ""
        Me.FUNCTION_ID.CFLKeyField = ""
        Me.FUNCTION_ID.CFLPage = False
        Me.FUNCTION_ID.CFLReturn0 = ""
        Me.FUNCTION_ID.CFLReturn1 = ""
        Me.FUNCTION_ID.CFLReturn2 = ""
        Me.FUNCTION_ID.CFLReturn3 = ""
        Me.FUNCTION_ID.CFLReturn4 = ""
        Me.FUNCTION_ID.CFLReturn5 = ""
        Me.FUNCTION_ID.CFLReturn6 = ""
        Me.FUNCTION_ID.CFLReturn7 = ""
        Me.FUNCTION_ID.CFLShowLoad = False
        Me.FUNCTION_ID.ChangeFormStatus = True
        Me.FUNCTION_ID.ColumnKey = True
        Me.FUNCTION_ID.ComboLine = 5
        Me.FUNCTION_ID.CopyFromItem = ""
        Me.FUNCTION_ID.DefaultButtonClick = False
        Me.FUNCTION_ID.Digit = False
        Me.FUNCTION_ID.FieldType = "N"
        Me.FUNCTION_ID.FieldView = "FUNCTION_ID"
        Me.FUNCTION_ID.FormarNumber = True
        Me.FUNCTION_ID.FormList = False
        Me.FUNCTION_ID.KeyInsert = "N"
        Me.FUNCTION_ID.LocalDecimal = False
        Me.FUNCTION_ID.Name = "FUNCTION_ID"
        Me.FUNCTION_ID.NoUpdate = ""
        Me.FUNCTION_ID.NumberDecimal = 0
        Me.FUNCTION_ID.ParentControl = ""
        Me.FUNCTION_ID.RefreshSource = False
        Me.FUNCTION_ID.Required = False
        Me.FUNCTION_ID.SequenceName = ""
        Me.FUNCTION_ID.ShowCalc = True
        Me.FUNCTION_ID.ShowDataTime = False
        Me.FUNCTION_ID.ShowOnlyTime = False
        Me.FUNCTION_ID.SQLString = ""
        Me.FUNCTION_ID.UpdateIfNull = ""
        Me.FUNCTION_ID.UpdateWhenFormLock = False
        Me.FUNCTION_ID.ValidateValue = True
        Me.FUNCTION_ID.Visible = True
        '
        'FORM_ID
        '
        Me.FORM_ID.AllowInsert = True
        Me.FORM_ID.AllowUpdate = True
        Me.FORM_ID.ButtonClick = True
        Me.FORM_ID.Caption = "FORM_ID"
        Me.FORM_ID.CFLColumnHide = ""
        Me.FORM_ID.CFLKeyField = ""
        Me.FORM_ID.CFLPage = False
        Me.FORM_ID.CFLReturn0 = ""
        Me.FORM_ID.CFLReturn1 = ""
        Me.FORM_ID.CFLReturn2 = ""
        Me.FORM_ID.CFLReturn3 = ""
        Me.FORM_ID.CFLReturn4 = ""
        Me.FORM_ID.CFLReturn5 = ""
        Me.FORM_ID.CFLReturn6 = ""
        Me.FORM_ID.CFLReturn7 = ""
        Me.FORM_ID.CFLShowLoad = False
        Me.FORM_ID.ChangeFormStatus = True
        Me.FORM_ID.ColumnKey = False
        Me.FORM_ID.ComboLine = 5
        Me.FORM_ID.CopyFromItem = ""
        Me.FORM_ID.DefaultButtonClick = False
        Me.FORM_ID.Digit = False
        Me.FORM_ID.FieldType = "N"
        Me.FORM_ID.FieldView = "FORM_ID"
        Me.FORM_ID.FormarNumber = True
        Me.FORM_ID.FormList = False
        Me.FORM_ID.KeyInsert = ""
        Me.FORM_ID.LocalDecimal = False
        Me.FORM_ID.Name = "FORM_ID"
        Me.FORM_ID.NoUpdate = ""
        Me.FORM_ID.NumberDecimal = 0
        Me.FORM_ID.ParentControl = ""
        Me.FORM_ID.RefreshSource = False
        Me.FORM_ID.Required = False
        Me.FORM_ID.SequenceName = ""
        Me.FORM_ID.ShowCalc = True
        Me.FORM_ID.ShowDataTime = False
        Me.FORM_ID.ShowOnlyTime = False
        Me.FORM_ID.SQLString = ""
        Me.FORM_ID.UpdateIfNull = ""
        Me.FORM_ID.UpdateWhenFormLock = False
        Me.FORM_ID.ValidateValue = True
        Me.FORM_ID.Visible = True
        '
        'FORM_NAME
        '
        Me.FORM_NAME.AllowInsert = True
        Me.FORM_NAME.AllowUpdate = True
        Me.FORM_NAME.ButtonClick = True
        Me.FORM_NAME.Caption = "Tên form"
        Me.FORM_NAME.CFLColumnHide = ""
        Me.FORM_NAME.CFLKeyField = "FORM_ID"
        Me.FORM_NAME.CFLPage = False
        Me.FORM_NAME.CFLReturn0 = ""
        Me.FORM_NAME.CFLReturn1 = "FORM_ID"
        Me.FORM_NAME.CFLReturn2 = ""
        Me.FORM_NAME.CFLReturn3 = ""
        Me.FORM_NAME.CFLReturn4 = ""
        Me.FORM_NAME.CFLReturn5 = ""
        Me.FORM_NAME.CFLReturn6 = ""
        Me.FORM_NAME.CFLReturn7 = ""
        Me.FORM_NAME.CFLShowLoad = False
        Me.FORM_NAME.ChangeFormStatus = True
        Me.FORM_NAME.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.FORM_NAME.ColumnKey = False
        Me.FORM_NAME.ComboLine = 5
        Me.FORM_NAME.CopyFromItem = ""
        Me.FORM_NAME.DefaultButtonClick = False
        Me.FORM_NAME.Digit = False
        Me.FORM_NAME.FieldType = "C"
        Me.FORM_NAME.FieldView = "FORM_NAME"
        Me.FORM_NAME.FormarNumber = True
        Me.FORM_NAME.FormList = False
        Me.FORM_NAME.KeyInsert = ""
        Me.FORM_NAME.LocalDecimal = False
        Me.FORM_NAME.Name = "FORM_NAME"
        Me.FORM_NAME.NoUpdate = ""
        Me.FORM_NAME.NumberDecimal = 0
        Me.FORM_NAME.ParentControl = ""
        Me.FORM_NAME.RefreshSource = False
        Me.FORM_NAME.Required = False
        Me.FORM_NAME.SequenceName = ""
        Me.FORM_NAME.ShowCalc = True
        Me.FORM_NAME.ShowDataTime = False
        Me.FORM_NAME.ShowOnlyTime = False
        Me.FORM_NAME.SQLString = resources.GetString("FORM_NAME.SQLString")
        Me.FORM_NAME.UpdateIfNull = ""
        Me.FORM_NAME.UpdateWhenFormLock = False
        Me.FORM_NAME.ValidateValue = True
        Me.FORM_NAME.Visible = True
        Me.FORM_NAME.VisibleIndex = 0
        Me.FORM_NAME.Width = 117
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'FUNCTION_NAME
        '
        Me.FUNCTION_NAME.AllowInsert = True
        Me.FUNCTION_NAME.AllowUpdate = True
        Me.FUNCTION_NAME.ButtonClick = True
        Me.FUNCTION_NAME.Caption = "Tên chức năng"
        Me.FUNCTION_NAME.CFLColumnHide = ""
        Me.FUNCTION_NAME.CFLKeyField = ""
        Me.FUNCTION_NAME.CFLPage = False
        Me.FUNCTION_NAME.CFLReturn0 = ""
        Me.FUNCTION_NAME.CFLReturn1 = ""
        Me.FUNCTION_NAME.CFLReturn2 = ""
        Me.FUNCTION_NAME.CFLReturn3 = ""
        Me.FUNCTION_NAME.CFLReturn4 = ""
        Me.FUNCTION_NAME.CFLReturn5 = ""
        Me.FUNCTION_NAME.CFLReturn6 = ""
        Me.FUNCTION_NAME.CFLReturn7 = ""
        Me.FUNCTION_NAME.CFLShowLoad = False
        Me.FUNCTION_NAME.ChangeFormStatus = True
        Me.FUNCTION_NAME.ColumnKey = False
        Me.FUNCTION_NAME.ComboLine = 5
        Me.FUNCTION_NAME.CopyFromItem = ""
        Me.FUNCTION_NAME.DefaultButtonClick = False
        Me.FUNCTION_NAME.Digit = False
        Me.FUNCTION_NAME.FieldType = "C"
        Me.FUNCTION_NAME.FieldView = "FUNCTION_NAME"
        Me.FUNCTION_NAME.FormarNumber = True
        Me.FUNCTION_NAME.FormList = False
        Me.FUNCTION_NAME.KeyInsert = ""
        Me.FUNCTION_NAME.LocalDecimal = False
        Me.FUNCTION_NAME.Name = "FUNCTION_NAME"
        Me.FUNCTION_NAME.NoUpdate = ""
        Me.FUNCTION_NAME.NumberDecimal = 0
        Me.FUNCTION_NAME.ParentControl = ""
        Me.FUNCTION_NAME.RefreshSource = False
        Me.FUNCTION_NAME.Required = False
        Me.FUNCTION_NAME.SequenceName = ""
        Me.FUNCTION_NAME.ShowCalc = True
        Me.FUNCTION_NAME.ShowDataTime = False
        Me.FUNCTION_NAME.ShowOnlyTime = False
        Me.FUNCTION_NAME.SQLString = ""
        Me.FUNCTION_NAME.UpdateIfNull = ""
        Me.FUNCTION_NAME.UpdateWhenFormLock = False
        Me.FUNCTION_NAME.ValidateValue = True
        Me.FUNCTION_NAME.Visible = True
        Me.FUNCTION_NAME.VisibleIndex = 1
        Me.FUNCTION_NAME.Width = 117
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.AllowInsert = True
        Me.DESCRIPTION.AllowUpdate = True
        Me.DESCRIPTION.ButtonClick = True
        Me.DESCRIPTION.Caption = "Ghi chú"
        Me.DESCRIPTION.CFLColumnHide = ""
        Me.DESCRIPTION.CFLKeyField = ""
        Me.DESCRIPTION.CFLPage = False
        Me.DESCRIPTION.CFLReturn0 = ""
        Me.DESCRIPTION.CFLReturn1 = ""
        Me.DESCRIPTION.CFLReturn2 = ""
        Me.DESCRIPTION.CFLReturn3 = ""
        Me.DESCRIPTION.CFLReturn4 = ""
        Me.DESCRIPTION.CFLReturn5 = ""
        Me.DESCRIPTION.CFLReturn6 = ""
        Me.DESCRIPTION.CFLReturn7 = ""
        Me.DESCRIPTION.CFLShowLoad = False
        Me.DESCRIPTION.ChangeFormStatus = True
        Me.DESCRIPTION.ColumnKey = False
        Me.DESCRIPTION.ComboLine = 5
        Me.DESCRIPTION.CopyFromItem = ""
        Me.DESCRIPTION.DefaultButtonClick = False
        Me.DESCRIPTION.Digit = False
        Me.DESCRIPTION.FieldType = "C"
        Me.DESCRIPTION.FieldView = "DESCRIPTION"
        Me.DESCRIPTION.FormarNumber = True
        Me.DESCRIPTION.FormList = False
        Me.DESCRIPTION.KeyInsert = ""
        Me.DESCRIPTION.LocalDecimal = False
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.NoUpdate = ""
        Me.DESCRIPTION.NumberDecimal = 0
        Me.DESCRIPTION.ParentControl = ""
        Me.DESCRIPTION.RefreshSource = False
        Me.DESCRIPTION.Required = False
        Me.DESCRIPTION.SequenceName = ""
        Me.DESCRIPTION.ShowCalc = True
        Me.DESCRIPTION.ShowDataTime = False
        Me.DESCRIPTION.ShowOnlyTime = False
        Me.DESCRIPTION.SQLString = ""
        Me.DESCRIPTION.UpdateIfNull = ""
        Me.DESCRIPTION.UpdateWhenFormLock = False
        Me.DESCRIPTION.ValidateValue = True
        Me.DESCRIPTION.Visible = True
        Me.DESCRIPTION.VisibleIndex = 2
        Me.DESCRIPTION.Width = 117
        '
        'FROM_DATE
        '
        Me.FROM_DATE.AllowInsert = True
        Me.FROM_DATE.AllowUpdate = True
        Me.FROM_DATE.ButtonClick = True
        Me.FROM_DATE.Caption = "Ngày hiệu lực"
        Me.FROM_DATE.CFLColumnHide = ""
        Me.FROM_DATE.CFLKeyField = ""
        Me.FROM_DATE.CFLPage = False
        Me.FROM_DATE.CFLReturn0 = ""
        Me.FROM_DATE.CFLReturn1 = ""
        Me.FROM_DATE.CFLReturn2 = ""
        Me.FROM_DATE.CFLReturn3 = ""
        Me.FROM_DATE.CFLReturn4 = ""
        Me.FROM_DATE.CFLReturn5 = ""
        Me.FROM_DATE.CFLReturn6 = ""
        Me.FROM_DATE.CFLReturn7 = ""
        Me.FROM_DATE.CFLShowLoad = False
        Me.FROM_DATE.ChangeFormStatus = True
        Me.FROM_DATE.ColumnKey = False
        Me.FROM_DATE.ComboLine = 5
        Me.FROM_DATE.CopyFromItem = ""
        Me.FROM_DATE.DefaultButtonClick = False
        Me.FROM_DATE.Digit = False
        Me.FROM_DATE.FieldType = "D"
        Me.FROM_DATE.FieldView = "FROM_DATE"
        Me.FROM_DATE.FormarNumber = True
        Me.FROM_DATE.FormList = False
        Me.FROM_DATE.KeyInsert = ""
        Me.FROM_DATE.LocalDecimal = False
        Me.FROM_DATE.Name = "FROM_DATE"
        Me.FROM_DATE.NoUpdate = ""
        Me.FROM_DATE.NumberDecimal = 0
        Me.FROM_DATE.ParentControl = ""
        Me.FROM_DATE.RefreshSource = False
        Me.FROM_DATE.Required = False
        Me.FROM_DATE.SequenceName = ""
        Me.FROM_DATE.ShowCalc = True
        Me.FROM_DATE.ShowDataTime = False
        Me.FROM_DATE.ShowOnlyTime = False
        Me.FROM_DATE.SQLString = ""
        Me.FROM_DATE.UpdateIfNull = ""
        Me.FROM_DATE.UpdateWhenFormLock = False
        Me.FROM_DATE.ValidateValue = True
        Me.FROM_DATE.Visible = True
        Me.FROM_DATE.VisibleIndex = 3
        Me.FROM_DATE.Width = 117
        '
        'TO_DATE
        '
        Me.TO_DATE.AllowInsert = True
        Me.TO_DATE.AllowUpdate = True
        Me.TO_DATE.ButtonClick = True
        Me.TO_DATE.Caption = "Ngày hết hiệu lực"
        Me.TO_DATE.CFLColumnHide = ""
        Me.TO_DATE.CFLKeyField = ""
        Me.TO_DATE.CFLPage = False
        Me.TO_DATE.CFLReturn0 = ""
        Me.TO_DATE.CFLReturn1 = ""
        Me.TO_DATE.CFLReturn2 = ""
        Me.TO_DATE.CFLReturn3 = ""
        Me.TO_DATE.CFLReturn4 = ""
        Me.TO_DATE.CFLReturn5 = ""
        Me.TO_DATE.CFLReturn6 = ""
        Me.TO_DATE.CFLReturn7 = ""
        Me.TO_DATE.CFLShowLoad = False
        Me.TO_DATE.ChangeFormStatus = True
        Me.TO_DATE.ColumnKey = False
        Me.TO_DATE.ComboLine = 5
        Me.TO_DATE.CopyFromItem = ""
        Me.TO_DATE.DefaultButtonClick = False
        Me.TO_DATE.Digit = False
        Me.TO_DATE.FieldType = "D"
        Me.TO_DATE.FieldView = "TO_DATE"
        Me.TO_DATE.FormarNumber = True
        Me.TO_DATE.FormList = False
        Me.TO_DATE.KeyInsert = ""
        Me.TO_DATE.LocalDecimal = False
        Me.TO_DATE.Name = "TO_DATE"
        Me.TO_DATE.NoUpdate = ""
        Me.TO_DATE.NumberDecimal = 0
        Me.TO_DATE.ParentControl = ""
        Me.TO_DATE.RefreshSource = False
        Me.TO_DATE.Required = False
        Me.TO_DATE.SequenceName = ""
        Me.TO_DATE.ShowCalc = True
        Me.TO_DATE.ShowDataTime = False
        Me.TO_DATE.ShowOnlyTime = False
        Me.TO_DATE.SQLString = ""
        Me.TO_DATE.UpdateIfNull = ""
        Me.TO_DATE.UpdateWhenFormLock = False
        Me.TO_DATE.ValidateValue = True
        Me.TO_DATE.Visible = True
        Me.TO_DATE.VisibleIndex = 4
        Me.TO_DATE.Width = 117
        '
        'PARVALUE
        '
        Me.PARVALUE.AllowInsert = True
        Me.PARVALUE.AllowUpdate = True
        Me.PARVALUE.ButtonClick = True
        Me.PARVALUE.Caption = "Tham số"
        Me.PARVALUE.CFLColumnHide = ""
        Me.PARVALUE.CFLKeyField = ""
        Me.PARVALUE.CFLPage = False
        Me.PARVALUE.CFLReturn0 = ""
        Me.PARVALUE.CFLReturn1 = ""
        Me.PARVALUE.CFLReturn2 = ""
        Me.PARVALUE.CFLReturn3 = ""
        Me.PARVALUE.CFLReturn4 = ""
        Me.PARVALUE.CFLReturn5 = ""
        Me.PARVALUE.CFLReturn6 = ""
        Me.PARVALUE.CFLReturn7 = ""
        Me.PARVALUE.CFLShowLoad = False
        Me.PARVALUE.ChangeFormStatus = True
        Me.PARVALUE.ColumnKey = False
        Me.PARVALUE.ComboLine = 5
        Me.PARVALUE.CopyFromItem = ""
        Me.PARVALUE.DefaultButtonClick = False
        Me.PARVALUE.Digit = False
        Me.PARVALUE.FieldType = "C"
        Me.PARVALUE.FieldView = "PARVALUE"
        Me.PARVALUE.FormarNumber = True
        Me.PARVALUE.FormList = False
        Me.PARVALUE.KeyInsert = ""
        Me.PARVALUE.LocalDecimal = False
        Me.PARVALUE.Name = "PARVALUE"
        Me.PARVALUE.NoUpdate = ""
        Me.PARVALUE.NumberDecimal = 0
        Me.PARVALUE.ParentControl = ""
        Me.PARVALUE.RefreshSource = False
        Me.PARVALUE.Required = False
        Me.PARVALUE.SequenceName = ""
        Me.PARVALUE.ShowCalc = True
        Me.PARVALUE.ShowDataTime = False
        Me.PARVALUE.ShowOnlyTime = False
        Me.PARVALUE.SQLString = ""
        Me.PARVALUE.UpdateIfNull = ""
        Me.PARVALUE.UpdateWhenFormLock = False
        Me.PARVALUE.ValidateValue = True
        Me.PARVALUE.Visible = True
        Me.PARVALUE.VisibleIndex = 5
        Me.PARVALUE.Width = 250
        '
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
        Me.CHECKUPD.ButtonClick = True
        Me.CHECKUPD.Caption = "CHECKUPD"
        Me.CHECKUPD.CFLColumnHide = ""
        Me.CHECKUPD.CFLKeyField = ""
        Me.CHECKUPD.CFLPage = False
        Me.CHECKUPD.CFLReturn0 = ""
        Me.CHECKUPD.CFLReturn1 = ""
        Me.CHECKUPD.CFLReturn2 = ""
        Me.CHECKUPD.CFLReturn3 = ""
        Me.CHECKUPD.CFLReturn4 = ""
        Me.CHECKUPD.CFLReturn5 = ""
        Me.CHECKUPD.CFLReturn6 = ""
        Me.CHECKUPD.CFLReturn7 = ""
        Me.CHECKUPD.CFLShowLoad = False
        Me.CHECKUPD.ChangeFormStatus = True
        Me.CHECKUPD.ColumnKey = False
        Me.CHECKUPD.ComboLine = 5
        Me.CHECKUPD.CopyFromItem = ""
        Me.CHECKUPD.DefaultButtonClick = False
        Me.CHECKUPD.Digit = False
        Me.CHECKUPD.FieldType = "C"
        Me.CHECKUPD.FieldView = "CHECKUPD"
        Me.CHECKUPD.FormarNumber = True
        Me.CHECKUPD.FormList = False
        Me.CHECKUPD.KeyInsert = ""
        Me.CHECKUPD.LocalDecimal = False
        Me.CHECKUPD.Name = "CHECKUPD"
        Me.CHECKUPD.NoUpdate = ""
        Me.CHECKUPD.NumberDecimal = 0
        Me.CHECKUPD.ParentControl = ""
        Me.CHECKUPD.RefreshSource = False
        Me.CHECKUPD.Required = False
        Me.CHECKUPD.SequenceName = ""
        Me.CHECKUPD.ShowCalc = True
        Me.CHECKUPD.ShowDataTime = False
        Me.CHECKUPD.ShowOnlyTime = False
        Me.CHECKUPD.SQLString = ""
        Me.CHECKUPD.UpdateIfNull = ""
        Me.CHECKUPD.UpdateWhenFormLock = False
        Me.CHECKUPD.ValidateValue = True
        Me.CHECKUPD.Visible = True
        Me.CHECKUPD.VisibleIndex = 6
        Me.CHECKUPD.Width = 85
        '
        'RepositoryItemGridLookUpEdit1
        '
        Me.RepositoryItemGridLookUpEdit1.AutoHeight = False
        Me.RepositoryItemGridLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemGridLookUpEdit1.Name = "RepositoryItemGridLookUpEdit1"
        Me.RepositoryItemGridLookUpEdit1.View = Me.RepositoryItemGridLookUpEdit1View
        '
        'RepositoryItemGridLookUpEdit1View
        '
        Me.RepositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemGridLookUpEdit1View.Name = "RepositoryItemGridLookUpEdit1View"
        Me.RepositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        '
        'BtnOk
        '
        Me.BtnOk.DefaultUpdate = True
        Me.BtnOk.Location = New System.Drawing.Point(12, 425)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(94, 23)
        Me.BtnOk.TabIndex = 1
        Me.BtnOk.Text = "Ok"
        '
        'FrmFunctionNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionAdd = "Ok"
        Me.ClientSize = New System.Drawing.Size(842, 451)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Name = "FrmFunctionNew"
        Me.Text = "Danh sách chức năng"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.BtnOk, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents FUNCTION_ID As U_TextBox.GridColumn
    Friend WithEvents FORM_ID As U_TextBox.GridColumn
    Friend WithEvents FORM_NAME As U_TextBox.GridColumn
    Friend WithEvents FUNCTION_NAME As U_TextBox.GridColumn
    Friend WithEvents DESCRIPTION As U_TextBox.GridColumn
    Friend WithEvents FROM_DATE As U_TextBox.GridColumn
    Friend WithEvents TO_DATE As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemGridLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents RepositoryItemGridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents BtnOk As U_TextBox.U_ButtonCus
    Friend WithEvents PARVALUE As U_TextBox.GridColumn

End Class
