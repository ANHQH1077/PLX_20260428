<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuNew))
        Me.MENU_CODE = New U_TextBox.U_TextBox()
        Me.MENU_NAME = New U_TextBox.U_TextBox()
        Me.DESCRIPTION = New U_TextBox.U_TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.FROM_DATE = New U_TextBox.U_DateEdit()
        Me.TO_DATE = New U_TextBox.U_DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.RESPONSIBILITY_MENU_ID = New U_TextBox.GridColumn()
        Me.ORDER_NUM = New U_TextBox.GridColumn()
        Me.ColMENU_CODE = New U_TextBox.GridColumn()
        Me.FUNCTION_ID = New U_TextBox.GridColumn()
        Me.FUNCTION_NAME = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ColDESCRIPTION = New U_TextBox.GridColumn()
        Me.ColFROM_DATE = New U_TextBox.GridColumn()
        Me.ColTO_DATE = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.SubMenu = New U_TextBox.GridColumn()
        Me.SubMenuName = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.Icon_File = New U_TextBox.U_TextBox()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENU_CODE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENU_NAME.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DESCRIPTION.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FROM_DATE.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FROM_DATE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TO_DATE.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TO_DATE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Icon_File.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MENU_CODE
        '
        Me.MENU_CODE.AllowInsert = True
        Me.MENU_CODE.AllowUpdate = True
        Me.MENU_CODE.AutoKeyFix = ""
        Me.MENU_CODE.AutoKeyName = ""
        Me.MENU_CODE.BindingSourceName = ""
        Me.MENU_CODE.ChangeFormStatus = True
        Me.MENU_CODE.CopyFromItem = ""
        Me.MENU_CODE.DefaultValue = ""
        Me.MENU_CODE.FieldName = "MENU_CODE"
        Me.MENU_CODE.FieldType = "C"
        Me.MENU_CODE.KeyInsert = "Y"
        Me.MENU_CODE.LinkLabel = ""
        Me.MENU_CODE.Location = New System.Drawing.Point(110, 26)
        Me.MENU_CODE.Name = "MENU_CODE"
        Me.MENU_CODE.NoUpdate = "Y"
        Me.MENU_CODE.PrimaryKey = "Y"
        Me.MENU_CODE.Properties.AutoHeight = False
        Me.MENU_CODE.Required = "Y"
        Me.MENU_CODE.Size = New System.Drawing.Size(151, 26)
        Me.MENU_CODE.TabIndex = 0
        Me.MENU_CODE.TableName = "SYS_MENU"
        Me.MENU_CODE.ToolTip = "NAME(U_TextBox) VIEW(SYS_MENU) TAB(SYS_MENU) FIELD (MENU_CODE)"
        Me.MENU_CODE.UpdateIfNull = "Y"
        Me.MENU_CODE.UpdateWhenFormLock = False
        Me.MENU_CODE.UpperValue = False
        Me.MENU_CODE.ViewName = "SYS_MENU"
        '
        'MENU_NAME
        '
        Me.MENU_NAME.AllowInsert = True
        Me.MENU_NAME.AllowUpdate = True
        Me.MENU_NAME.AutoKeyFix = ""
        Me.MENU_NAME.AutoKeyName = ""
        Me.MENU_NAME.BindingSourceName = ""
        Me.MENU_NAME.ChangeFormStatus = True
        Me.MENU_NAME.CopyFromItem = ""
        Me.MENU_NAME.DefaultValue = ""
        Me.MENU_NAME.FieldName = "MENU_NAME"
        Me.MENU_NAME.FieldType = "C"
        Me.MENU_NAME.KeyInsert = ""
        Me.MENU_NAME.LinkLabel = ""
        Me.MENU_NAME.Location = New System.Drawing.Point(110, 53)
        Me.MENU_NAME.Name = "MENU_NAME"
        Me.MENU_NAME.NoUpdate = "N"
        Me.MENU_NAME.PrimaryKey = ""
        Me.MENU_NAME.Properties.AutoHeight = False
        Me.MENU_NAME.Required = ""
        Me.MENU_NAME.Size = New System.Drawing.Size(509, 26)
        Me.MENU_NAME.TabIndex = 2
        Me.MENU_NAME.TableName = "SYS_MENU"
        Me.MENU_NAME.ToolTip = "NAME(U_TextBox) VIEW(SYS_MENU) TAB(SYS_MENU) FIELD (MENU_NAME)"
        Me.MENU_NAME.UpdateIfNull = ""
        Me.MENU_NAME.UpdateWhenFormLock = False
        Me.MENU_NAME.UpperValue = False
        Me.MENU_NAME.ViewName = "SYS_MENU"
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.AllowInsert = True
        Me.DESCRIPTION.AllowUpdate = True
        Me.DESCRIPTION.AutoKeyFix = ""
        Me.DESCRIPTION.AutoKeyName = ""
        Me.DESCRIPTION.BindingSourceName = ""
        Me.DESCRIPTION.ChangeFormStatus = True
        Me.DESCRIPTION.CopyFromItem = ""
        Me.DESCRIPTION.DefaultValue = ""
        Me.DESCRIPTION.FieldName = "DESCRIPTION"
        Me.DESCRIPTION.FieldType = "C"
        Me.DESCRIPTION.KeyInsert = ""
        Me.DESCRIPTION.LinkLabel = ""
        Me.DESCRIPTION.Location = New System.Drawing.Point(110, 80)
        Me.DESCRIPTION.Name = "DESCRIPTION"
        Me.DESCRIPTION.NoUpdate = "N"
        Me.DESCRIPTION.PrimaryKey = ""
        Me.DESCRIPTION.Properties.AutoHeight = False
        Me.DESCRIPTION.Required = ""
        Me.DESCRIPTION.Size = New System.Drawing.Size(509, 26)
        Me.DESCRIPTION.TabIndex = 3
        Me.DESCRIPTION.TableName = "SYS_MENU"
        Me.DESCRIPTION.ToolTip = "NAME(U_TextBox) VIEW(SYS_MENU) TAB(SYS_MENU) FIELD (DESCRIPTION)"
        Me.DESCRIPTION.UpdateIfNull = ""
        Me.DESCRIPTION.UpdateWhenFormLock = False
        Me.DESCRIPTION.UpperValue = False
        Me.DESCRIPTION.ViewName = "SYS_MENU"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 29)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl1.TabIndex = 5
        Me.LabelControl1.Text = "Mã Menu"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 56)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Tên Menu"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 83)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Ghi chú"
        '
        'FROM_DATE
        '
        Me.FROM_DATE.AllowInsert = True
        Me.FROM_DATE.AllowUpdate = True
        Me.FROM_DATE.BindingSourceName = ""
        Me.FROM_DATE.ChangeFormStatus = True
        Me.FROM_DATE.CopyFromItem = ""
        Me.FROM_DATE.DefaultValue = ""
        Me.FROM_DATE.EditValue = Nothing
        Me.FROM_DATE.FieldName = "FROM_DATE"
        Me.FROM_DATE.FieldType = "D"
        Me.FROM_DATE.KeyInsert = ""
        Me.FROM_DATE.LinkLabel = ""
        Me.FROM_DATE.Location = New System.Drawing.Point(110, 107)
        Me.FROM_DATE.Name = "FROM_DATE"
        Me.FROM_DATE.NoUpdate = ""
        Me.FROM_DATE.PrimaryKey = ""
        Me.FROM_DATE.Properties.AutoHeight = False
        Me.FROM_DATE.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.FROM_DATE.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.FROM_DATE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.FROM_DATE.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.FROM_DATE.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.FROM_DATE.Required = ""
        Me.FROM_DATE.ShowDateTime = False
        Me.FROM_DATE.Size = New System.Drawing.Size(151, 26)
        Me.FROM_DATE.TabIndex = 8
        Me.FROM_DATE.TableName = "SYS_MENU"
        Me.FROM_DATE.ToolTip = "NAME(U_DateEdit1) VIEW(SYS_MENU) TAB(SYS_MENU) FIELD (FROM_DATE)"
        Me.FROM_DATE.UpdateIfNull = ""
        Me.FROM_DATE.UpdateWhenFormLock = False
        Me.FROM_DATE.ViewName = "SYS_MENU"
        '
        'TO_DATE
        '
        Me.TO_DATE.AllowInsert = True
        Me.TO_DATE.AllowUpdate = True
        Me.TO_DATE.BindingSourceName = ""
        Me.TO_DATE.ChangeFormStatus = True
        Me.TO_DATE.CopyFromItem = ""
        Me.TO_DATE.DefaultValue = ""
        Me.TO_DATE.EditValue = Nothing
        Me.TO_DATE.FieldName = "TO_DATE"
        Me.TO_DATE.FieldType = "D"
        Me.TO_DATE.KeyInsert = ""
        Me.TO_DATE.LinkLabel = ""
        Me.TO_DATE.Location = New System.Drawing.Point(110, 134)
        Me.TO_DATE.Name = "TO_DATE"
        Me.TO_DATE.NoUpdate = ""
        Me.TO_DATE.PrimaryKey = ""
        Me.TO_DATE.Properties.AutoHeight = False
        Me.TO_DATE.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TO_DATE.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.TO_DATE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TO_DATE.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.TO_DATE.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TO_DATE.Required = ""
        Me.TO_DATE.ShowDateTime = False
        Me.TO_DATE.Size = New System.Drawing.Size(151, 26)
        Me.TO_DATE.TabIndex = 9
        Me.TO_DATE.TableName = "SYS_MENU"
        Me.TO_DATE.ToolTip = "NAME(U_DateEdit2) VIEW(SYS_MENU) TAB(SYS_MENU) FIELD (TO_DATE)"
        Me.TO_DATE.UpdateIfNull = ""
        Me.TO_DATE.UpdateWhenFormLock = False
        Me.TO_DATE.ViewName = "SYS_MENU"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 110)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(65, 13)
        Me.LabelControl4.TabIndex = 10
        Me.LabelControl4.Text = "Ngày hiệu lực"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 137)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl5.TabIndex = 11
        Me.LabelControl5.Text = "Ngày hết hiệu lực"
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(5, 169)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemButtonEdit2})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(749, 291)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = True
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = False
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.RESPONSIBILITY_MENU_ID, Me.ORDER_NUM, Me.ColMENU_CODE, Me.FUNCTION_ID, Me.FUNCTION_NAME, Me.ColDESCRIPTION, Me.ColFROM_DATE, Me.ColTO_DATE, Me.CHECKUPD, Me.SubMenu, Me.SubMenuName})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OrderBy = "ORDER_NUM"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "SYS_RESPONSIBILITY_MENU"
        Me.GridView1.ViewName = "SYS_RESPONSIBILITY_MENU_V"
        Me.GridView1.Where = "MENU_CODE=:MENU_CODE"
        '
        'RESPONSIBILITY_MENU_ID
        '
        Me.RESPONSIBILITY_MENU_ID.AllowInsert = False
        Me.RESPONSIBILITY_MENU_ID.AllowUpdate = False
        Me.RESPONSIBILITY_MENU_ID.Caption = "RESPONSIBILITY_MENU_ID"
        Me.RESPONSIBILITY_MENU_ID.CFLColumnHide = ""
        Me.RESPONSIBILITY_MENU_ID.CFLKeyField = "FUNCTION_ID"
        Me.RESPONSIBILITY_MENU_ID.CFLPage = False
        Me.RESPONSIBILITY_MENU_ID.CFLReturn0 = ""
        Me.RESPONSIBILITY_MENU_ID.CFLReturn1 = ""
        Me.RESPONSIBILITY_MENU_ID.CFLReturn2 = ""
        Me.RESPONSIBILITY_MENU_ID.CFLReturn3 = ""
        Me.RESPONSIBILITY_MENU_ID.CFLReturn4 = ""
        Me.RESPONSIBILITY_MENU_ID.CFLReturn5 = ""
        Me.RESPONSIBILITY_MENU_ID.CFLReturn6 = ""
        Me.RESPONSIBILITY_MENU_ID.CFLReturn7 = ""
        Me.RESPONSIBILITY_MENU_ID.CFLShowLoad = False
        Me.RESPONSIBILITY_MENU_ID.ChangeFormStatus = True
        Me.RESPONSIBILITY_MENU_ID.ColumnKey = True
        Me.RESPONSIBILITY_MENU_ID.ComboLine = 5
        Me.RESPONSIBILITY_MENU_ID.CopyFromItem = ""
        Me.RESPONSIBILITY_MENU_ID.DefaultButtonClick = False
        Me.RESPONSIBILITY_MENU_ID.Digit = False
        Me.RESPONSIBILITY_MENU_ID.FieldType = "N"
        Me.RESPONSIBILITY_MENU_ID.FieldView = "RESPONSIBILITY_MENU_ID"
        Me.RESPONSIBILITY_MENU_ID.FormList = False
        Me.RESPONSIBILITY_MENU_ID.KeyInsert = ""
        Me.RESPONSIBILITY_MENU_ID.LocalDecimal = False
        Me.RESPONSIBILITY_MENU_ID.Name = "RESPONSIBILITY_MENU_ID"
        Me.RESPONSIBILITY_MENU_ID.NoUpdate = ""
        Me.RESPONSIBILITY_MENU_ID.NumberDecimal = 0
        Me.RESPONSIBILITY_MENU_ID.ParentControl = ""
        Me.RESPONSIBILITY_MENU_ID.RefreshSource = False
        Me.RESPONSIBILITY_MENU_ID.Required = False
        Me.RESPONSIBILITY_MENU_ID.ShowCalc = True
        Me.RESPONSIBILITY_MENU_ID.ShowDataTime = False
        Me.RESPONSIBILITY_MENU_ID.SQLString = ""
        Me.RESPONSIBILITY_MENU_ID.UpdateIfNull = ""
        Me.RESPONSIBILITY_MENU_ID.UpdateWhenFormLock = False
        Me.RESPONSIBILITY_MENU_ID.ValidateValue = True
        Me.RESPONSIBILITY_MENU_ID.Visible = True
        '
        'ORDER_NUM
        '
        Me.ORDER_NUM.AllowInsert = True
        Me.ORDER_NUM.AllowUpdate = True
        Me.ORDER_NUM.Caption = "STT"
        Me.ORDER_NUM.CFLColumnHide = ""
        Me.ORDER_NUM.CFLKeyField = ""
        Me.ORDER_NUM.CFLPage = False
        Me.ORDER_NUM.CFLReturn0 = ""
        Me.ORDER_NUM.CFLReturn1 = ""
        Me.ORDER_NUM.CFLReturn2 = ""
        Me.ORDER_NUM.CFLReturn3 = ""
        Me.ORDER_NUM.CFLReturn4 = ""
        Me.ORDER_NUM.CFLReturn5 = ""
        Me.ORDER_NUM.CFLReturn6 = ""
        Me.ORDER_NUM.CFLReturn7 = ""
        Me.ORDER_NUM.CFLShowLoad = False
        Me.ORDER_NUM.ChangeFormStatus = True
        Me.ORDER_NUM.ColumnKey = False
        Me.ORDER_NUM.ComboLine = 5
        Me.ORDER_NUM.CopyFromItem = ""
        Me.ORDER_NUM.DefaultButtonClick = False
        Me.ORDER_NUM.Digit = False
        Me.ORDER_NUM.FieldType = "N"
        Me.ORDER_NUM.FieldView = "ORDER_NUM"
        Me.ORDER_NUM.FormList = False
        Me.ORDER_NUM.KeyInsert = ""
        Me.ORDER_NUM.LocalDecimal = False
        Me.ORDER_NUM.Name = "ORDER_NUM"
        Me.ORDER_NUM.NoUpdate = ""
        Me.ORDER_NUM.NumberDecimal = 0
        Me.ORDER_NUM.ParentControl = ""
        Me.ORDER_NUM.RefreshSource = False
        Me.ORDER_NUM.Required = False
        Me.ORDER_NUM.ShowCalc = True
        Me.ORDER_NUM.ShowDataTime = False
        Me.ORDER_NUM.SQLString = ""
        Me.ORDER_NUM.UpdateIfNull = ""
        Me.ORDER_NUM.UpdateWhenFormLock = False
        Me.ORDER_NUM.ValidateValue = True
        Me.ORDER_NUM.Visible = True
        Me.ORDER_NUM.VisibleIndex = 0
        '
        'ColMENU_CODE
        '
        Me.ColMENU_CODE.AllowInsert = True
        Me.ColMENU_CODE.AllowUpdate = True
        Me.ColMENU_CODE.Caption = "MENU_CODE"
        Me.ColMENU_CODE.CFLColumnHide = ""
        Me.ColMENU_CODE.CFLKeyField = ""
        Me.ColMENU_CODE.CFLPage = False
        Me.ColMENU_CODE.CFLReturn0 = ""
        Me.ColMENU_CODE.CFLReturn1 = ""
        Me.ColMENU_CODE.CFLReturn2 = ""
        Me.ColMENU_CODE.CFLReturn3 = ""
        Me.ColMENU_CODE.CFLReturn4 = ""
        Me.ColMENU_CODE.CFLReturn5 = ""
        Me.ColMENU_CODE.CFLReturn6 = ""
        Me.ColMENU_CODE.CFLReturn7 = ""
        Me.ColMENU_CODE.CFLShowLoad = False
        Me.ColMENU_CODE.ChangeFormStatus = True
        Me.ColMENU_CODE.ColumnKey = False
        Me.ColMENU_CODE.ComboLine = 5
        Me.ColMENU_CODE.CopyFromItem = ":MENU_CODE"
        Me.ColMENU_CODE.DefaultButtonClick = False
        Me.ColMENU_CODE.Digit = False
        Me.ColMENU_CODE.FieldType = "C"
        Me.ColMENU_CODE.FieldView = "MENU_CODE"
        Me.ColMENU_CODE.FormList = False
        Me.ColMENU_CODE.KeyInsert = ""
        Me.ColMENU_CODE.LocalDecimal = False
        Me.ColMENU_CODE.Name = "ColMENU_CODE"
        Me.ColMENU_CODE.NoUpdate = ""
        Me.ColMENU_CODE.NumberDecimal = 0
        Me.ColMENU_CODE.ParentControl = ""
        Me.ColMENU_CODE.RefreshSource = False
        Me.ColMENU_CODE.Required = False
        Me.ColMENU_CODE.ShowCalc = True
        Me.ColMENU_CODE.ShowDataTime = False
        Me.ColMENU_CODE.SQLString = ""
        Me.ColMENU_CODE.UpdateIfNull = ""
        Me.ColMENU_CODE.UpdateWhenFormLock = False
        Me.ColMENU_CODE.ValidateValue = True
        Me.ColMENU_CODE.Visible = True
        '
        'FUNCTION_ID
        '
        Me.FUNCTION_ID.AllowInsert = True
        Me.FUNCTION_ID.AllowUpdate = True
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
        Me.FUNCTION_ID.ColumnKey = False
        Me.FUNCTION_ID.ComboLine = 5
        Me.FUNCTION_ID.CopyFromItem = ""
        Me.FUNCTION_ID.DefaultButtonClick = False
        Me.FUNCTION_ID.Digit = False
        Me.FUNCTION_ID.FieldType = "N"
        Me.FUNCTION_ID.FieldView = "FUNCTION_ID"
        Me.FUNCTION_ID.FormList = False
        Me.FUNCTION_ID.KeyInsert = ""
        Me.FUNCTION_ID.LocalDecimal = False
        Me.FUNCTION_ID.Name = "FUNCTION_ID"
        Me.FUNCTION_ID.NoUpdate = ""
        Me.FUNCTION_ID.NumberDecimal = 0
        Me.FUNCTION_ID.ParentControl = ""
        Me.FUNCTION_ID.RefreshSource = False
        Me.FUNCTION_ID.Required = False
        Me.FUNCTION_ID.ShowCalc = True
        Me.FUNCTION_ID.ShowDataTime = False
        Me.FUNCTION_ID.SQLString = ""
        Me.FUNCTION_ID.UpdateIfNull = ""
        Me.FUNCTION_ID.UpdateWhenFormLock = False
        Me.FUNCTION_ID.ValidateValue = True
        Me.FUNCTION_ID.Visible = True
        '
        'FUNCTION_NAME
        '
        Me.FUNCTION_NAME.AllowInsert = True
        Me.FUNCTION_NAME.AllowUpdate = True
        Me.FUNCTION_NAME.Caption = "Tên chức năng"
        Me.FUNCTION_NAME.CFLColumnHide = ""
        Me.FUNCTION_NAME.CFLKeyField = "FUNCTION_ID"
        Me.FUNCTION_NAME.CFLPage = False
        Me.FUNCTION_NAME.CFLReturn0 = ""
        Me.FUNCTION_NAME.CFLReturn1 = ""
        Me.FUNCTION_NAME.CFLReturn2 = "FUNCTION_ID"
        Me.FUNCTION_NAME.CFLReturn3 = ""
        Me.FUNCTION_NAME.CFLReturn4 = ""
        Me.FUNCTION_NAME.CFLReturn5 = ""
        Me.FUNCTION_NAME.CFLReturn6 = ""
        Me.FUNCTION_NAME.CFLReturn7 = ""
        Me.FUNCTION_NAME.CFLShowLoad = True
        Me.FUNCTION_NAME.ChangeFormStatus = True
        Me.FUNCTION_NAME.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.FUNCTION_NAME.ColumnKey = False
        Me.FUNCTION_NAME.ComboLine = 5
        Me.FUNCTION_NAME.CopyFromItem = ""
        Me.FUNCTION_NAME.DefaultButtonClick = False
        Me.FUNCTION_NAME.Digit = False
        Me.FUNCTION_NAME.FieldType = "C"
        Me.FUNCTION_NAME.FieldView = "FUNCTION_NAME"
        Me.FUNCTION_NAME.FormList = False
        Me.FUNCTION_NAME.KeyInsert = ""
        Me.FUNCTION_NAME.LocalDecimal = False
        Me.FUNCTION_NAME.Name = "FUNCTION_NAME"
        Me.FUNCTION_NAME.NoUpdate = ""
        Me.FUNCTION_NAME.NumberDecimal = 0
        Me.FUNCTION_NAME.ParentControl = ""
        Me.FUNCTION_NAME.RefreshSource = False
        Me.FUNCTION_NAME.Required = False
        Me.FUNCTION_NAME.ShowCalc = True
        Me.FUNCTION_NAME.ShowDataTime = False
        Me.FUNCTION_NAME.SQLString = resources.GetString("FUNCTION_NAME.SQLString")
        Me.FUNCTION_NAME.UpdateIfNull = ""
        Me.FUNCTION_NAME.UpdateWhenFormLock = False
        Me.FUNCTION_NAME.ValidateValue = True
        Me.FUNCTION_NAME.Visible = True
        Me.FUNCTION_NAME.VisibleIndex = 1
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'ColDESCRIPTION
        '
        Me.ColDESCRIPTION.AllowInsert = True
        Me.ColDESCRIPTION.AllowUpdate = True
        Me.ColDESCRIPTION.Caption = "Ghi chú"
        Me.ColDESCRIPTION.CFLColumnHide = ""
        Me.ColDESCRIPTION.CFLKeyField = ""
        Me.ColDESCRIPTION.CFLPage = False
        Me.ColDESCRIPTION.CFLReturn0 = ""
        Me.ColDESCRIPTION.CFLReturn1 = ""
        Me.ColDESCRIPTION.CFLReturn2 = ""
        Me.ColDESCRIPTION.CFLReturn3 = ""
        Me.ColDESCRIPTION.CFLReturn4 = ""
        Me.ColDESCRIPTION.CFLReturn5 = ""
        Me.ColDESCRIPTION.CFLReturn6 = ""
        Me.ColDESCRIPTION.CFLReturn7 = ""
        Me.ColDESCRIPTION.CFLShowLoad = False
        Me.ColDESCRIPTION.ChangeFormStatus = True
        Me.ColDESCRIPTION.ColumnKey = False
        Me.ColDESCRIPTION.ComboLine = 5
        Me.ColDESCRIPTION.CopyFromItem = ""
        Me.ColDESCRIPTION.DefaultButtonClick = False
        Me.ColDESCRIPTION.Digit = False
        Me.ColDESCRIPTION.FieldType = "C"
        Me.ColDESCRIPTION.FieldView = "DESCRIPTION"
        Me.ColDESCRIPTION.FormList = False
        Me.ColDESCRIPTION.KeyInsert = ""
        Me.ColDESCRIPTION.LocalDecimal = False
        Me.ColDESCRIPTION.Name = "ColDESCRIPTION"
        Me.ColDESCRIPTION.NoUpdate = ""
        Me.ColDESCRIPTION.NumberDecimal = 0
        Me.ColDESCRIPTION.ParentControl = ""
        Me.ColDESCRIPTION.RefreshSource = False
        Me.ColDESCRIPTION.Required = False
        Me.ColDESCRIPTION.ShowCalc = True
        Me.ColDESCRIPTION.ShowDataTime = False
        Me.ColDESCRIPTION.SQLString = ""
        Me.ColDESCRIPTION.UpdateIfNull = ""
        Me.ColDESCRIPTION.UpdateWhenFormLock = False
        Me.ColDESCRIPTION.ValidateValue = True
        Me.ColDESCRIPTION.Visible = True
        Me.ColDESCRIPTION.VisibleIndex = 2
        '
        'ColFROM_DATE
        '
        Me.ColFROM_DATE.AllowInsert = True
        Me.ColFROM_DATE.AllowUpdate = True
        Me.ColFROM_DATE.Caption = "Ngày hiệu lực"
        Me.ColFROM_DATE.CFLColumnHide = ""
        Me.ColFROM_DATE.CFLKeyField = ""
        Me.ColFROM_DATE.CFLPage = False
        Me.ColFROM_DATE.CFLReturn0 = ""
        Me.ColFROM_DATE.CFLReturn1 = ""
        Me.ColFROM_DATE.CFLReturn2 = ""
        Me.ColFROM_DATE.CFLReturn3 = ""
        Me.ColFROM_DATE.CFLReturn4 = ""
        Me.ColFROM_DATE.CFLReturn5 = ""
        Me.ColFROM_DATE.CFLReturn6 = ""
        Me.ColFROM_DATE.CFLReturn7 = ""
        Me.ColFROM_DATE.CFLShowLoad = False
        Me.ColFROM_DATE.ChangeFormStatus = True
        Me.ColFROM_DATE.ColumnKey = False
        Me.ColFROM_DATE.ComboLine = 5
        Me.ColFROM_DATE.CopyFromItem = ""
        Me.ColFROM_DATE.DefaultButtonClick = False
        Me.ColFROM_DATE.Digit = False
        Me.ColFROM_DATE.FieldType = "D"
        Me.ColFROM_DATE.FieldView = "FROM_DATE"
        Me.ColFROM_DATE.FormList = False
        Me.ColFROM_DATE.KeyInsert = ""
        Me.ColFROM_DATE.LocalDecimal = False
        Me.ColFROM_DATE.Name = "ColFROM_DATE"
        Me.ColFROM_DATE.NoUpdate = ""
        Me.ColFROM_DATE.NumberDecimal = 0
        Me.ColFROM_DATE.ParentControl = ""
        Me.ColFROM_DATE.RefreshSource = False
        Me.ColFROM_DATE.Required = False
        Me.ColFROM_DATE.ShowCalc = True
        Me.ColFROM_DATE.ShowDataTime = False
        Me.ColFROM_DATE.SQLString = ""
        Me.ColFROM_DATE.UpdateIfNull = ""
        Me.ColFROM_DATE.UpdateWhenFormLock = False
        Me.ColFROM_DATE.ValidateValue = True
        Me.ColFROM_DATE.Visible = True
        Me.ColFROM_DATE.VisibleIndex = 3
        '
        'ColTO_DATE
        '
        Me.ColTO_DATE.AllowInsert = True
        Me.ColTO_DATE.AllowUpdate = True
        Me.ColTO_DATE.Caption = "Ngày hết hiệu lực"
        Me.ColTO_DATE.CFLColumnHide = ""
        Me.ColTO_DATE.CFLKeyField = ""
        Me.ColTO_DATE.CFLPage = False
        Me.ColTO_DATE.CFLReturn0 = ""
        Me.ColTO_DATE.CFLReturn1 = ""
        Me.ColTO_DATE.CFLReturn2 = ""
        Me.ColTO_DATE.CFLReturn3 = ""
        Me.ColTO_DATE.CFLReturn4 = ""
        Me.ColTO_DATE.CFLReturn5 = ""
        Me.ColTO_DATE.CFLReturn6 = ""
        Me.ColTO_DATE.CFLReturn7 = ""
        Me.ColTO_DATE.CFLShowLoad = False
        Me.ColTO_DATE.ChangeFormStatus = True
        Me.ColTO_DATE.ColumnKey = False
        Me.ColTO_DATE.ComboLine = 5
        Me.ColTO_DATE.CopyFromItem = ""
        Me.ColTO_DATE.DefaultButtonClick = False
        Me.ColTO_DATE.Digit = False
        Me.ColTO_DATE.FieldType = "D"
        Me.ColTO_DATE.FieldView = "TO_DATE"
        Me.ColTO_DATE.FormList = False
        Me.ColTO_DATE.KeyInsert = ""
        Me.ColTO_DATE.LocalDecimal = False
        Me.ColTO_DATE.Name = "ColTO_DATE"
        Me.ColTO_DATE.NoUpdate = ""
        Me.ColTO_DATE.NumberDecimal = 0
        Me.ColTO_DATE.ParentControl = ""
        Me.ColTO_DATE.RefreshSource = False
        Me.ColTO_DATE.Required = False
        Me.ColTO_DATE.ShowCalc = True
        Me.ColTO_DATE.ShowDataTime = False
        Me.ColTO_DATE.SQLString = ""
        Me.ColTO_DATE.UpdateIfNull = ""
        Me.ColTO_DATE.UpdateWhenFormLock = False
        Me.ColTO_DATE.ValidateValue = True
        Me.ColTO_DATE.Visible = True
        Me.ColTO_DATE.VisibleIndex = 4
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
        Me.CHECKUPD.FormList = False
        Me.CHECKUPD.KeyInsert = ""
        Me.CHECKUPD.LocalDecimal = False
        Me.CHECKUPD.Name = "CHECKUPD"
        Me.CHECKUPD.NoUpdate = ""
        Me.CHECKUPD.NumberDecimal = 0
        Me.CHECKUPD.ParentControl = ""
        Me.CHECKUPD.RefreshSource = False
        Me.CHECKUPD.Required = False
        Me.CHECKUPD.ShowCalc = True
        Me.CHECKUPD.ShowDataTime = False
        Me.CHECKUPD.SQLString = ""
        Me.CHECKUPD.UpdateIfNull = ""
        Me.CHECKUPD.UpdateWhenFormLock = False
        Me.CHECKUPD.ValidateValue = True
        Me.CHECKUPD.Visible = True
        '
        'SubMenu
        '
        Me.SubMenu.AllowInsert = True
        Me.SubMenu.AllowUpdate = True
        Me.SubMenu.Caption = "SubMenu"
        Me.SubMenu.CFLColumnHide = ""
        Me.SubMenu.CFLKeyField = ""
        Me.SubMenu.CFLPage = False
        Me.SubMenu.CFLReturn0 = ""
        Me.SubMenu.CFLReturn1 = ""
        Me.SubMenu.CFLReturn2 = ""
        Me.SubMenu.CFLReturn3 = ""
        Me.SubMenu.CFLReturn4 = ""
        Me.SubMenu.CFLReturn5 = ""
        Me.SubMenu.CFLReturn6 = ""
        Me.SubMenu.CFLReturn7 = ""
        Me.SubMenu.CFLShowLoad = False
        Me.SubMenu.ChangeFormStatus = True
        Me.SubMenu.ColumnKey = False
        Me.SubMenu.ComboLine = 5
        Me.SubMenu.CopyFromItem = ""
        Me.SubMenu.DefaultButtonClick = False
        Me.SubMenu.Digit = False
        Me.SubMenu.FieldType = "C"
        Me.SubMenu.FieldView = "SubMenu"
        Me.SubMenu.FormList = False
        Me.SubMenu.KeyInsert = ""
        Me.SubMenu.LocalDecimal = False
        Me.SubMenu.Name = "SubMenu"
        Me.SubMenu.NoUpdate = ""
        Me.SubMenu.NumberDecimal = 0
        Me.SubMenu.ParentControl = ""
        Me.SubMenu.RefreshSource = False
        Me.SubMenu.Required = False
        Me.SubMenu.ShowCalc = True
        Me.SubMenu.ShowDataTime = False
        Me.SubMenu.SQLString = ""
        Me.SubMenu.UpdateIfNull = ""
        Me.SubMenu.UpdateWhenFormLock = False
        Me.SubMenu.ValidateValue = True
        Me.SubMenu.Visible = True
        Me.SubMenu.VisibleIndex = 6
        '
        'SubMenuName
        '
        Me.SubMenuName.AllowInsert = True
        Me.SubMenuName.AllowUpdate = True
        Me.SubMenuName.Caption = "Menu con"
        Me.SubMenuName.CFLColumnHide = ""
        Me.SubMenuName.CFLKeyField = "MENU_CODE"
        Me.SubMenuName.CFLPage = False
        Me.SubMenuName.CFLReturn0 = ""
        Me.SubMenuName.CFLReturn1 = "SubMenu"
        Me.SubMenuName.CFLReturn2 = ""
        Me.SubMenuName.CFLReturn3 = ""
        Me.SubMenuName.CFLReturn4 = ""
        Me.SubMenuName.CFLReturn5 = ""
        Me.SubMenuName.CFLReturn6 = ""
        Me.SubMenuName.CFLReturn7 = ""
        Me.SubMenuName.CFLShowLoad = True
        Me.SubMenuName.ChangeFormStatus = True
        Me.SubMenuName.ColumnEdit = Me.RepositoryItemButtonEdit2
        Me.SubMenuName.ColumnKey = False
        Me.SubMenuName.ComboLine = 5
        Me.SubMenuName.CopyFromItem = ""
        Me.SubMenuName.DefaultButtonClick = False
        Me.SubMenuName.Digit = False
        Me.SubMenuName.FieldType = "C"
        Me.SubMenuName.FieldView = "SubMenuName"
        Me.SubMenuName.FormList = False
        Me.SubMenuName.KeyInsert = ""
        Me.SubMenuName.LocalDecimal = False
        Me.SubMenuName.Name = "SubMenuName"
        Me.SubMenuName.NoUpdate = ""
        Me.SubMenuName.NumberDecimal = 0
        Me.SubMenuName.ParentControl = ""
        Me.SubMenuName.RefreshSource = False
        Me.SubMenuName.Required = False
        Me.SubMenuName.ShowCalc = True
        Me.SubMenuName.ShowDataTime = False
        Me.SubMenuName.SQLString = "SELECT MENU_NAME, MENU_CODE FROM SYS_MENU where  CONVERT(date,GETDATE())>= CONVER" & _
            "T(date,isnull(FROM_DATE,GetDate())) AND CONVERT(date,GETDATE())<= CONVERT(date,i" & _
            "snull(TO_DATE,GetDate()))"
        Me.SubMenuName.UpdateIfNull = ""
        Me.SubMenuName.UpdateWhenFormLock = False
        Me.SubMenuName.ValidateValue = True
        Me.SubMenuName.Visible = True
        Me.SubMenuName.VisibleIndex = 5
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        '
        'Icon_File
        '
        Me.Icon_File.AllowInsert = True
        Me.Icon_File.AllowUpdate = True
        Me.Icon_File.AutoKeyFix = ""
        Me.Icon_File.AutoKeyName = ""
        Me.Icon_File.BindingSourceName = ""
        Me.Icon_File.ChangeFormStatus = True
        Me.Icon_File.CopyFromItem = ""
        Me.Icon_File.DefaultValue = ""
        Me.Icon_File.FieldName = "Icon_File"
        Me.Icon_File.FieldType = "C"
        Me.Icon_File.KeyInsert = ""
        Me.Icon_File.LinkLabel = ""
        Me.Icon_File.Location = New System.Drawing.Point(367, 107)
        Me.Icon_File.Name = "Icon_File"
        Me.Icon_File.NoUpdate = "N"
        Me.Icon_File.PrimaryKey = ""
        Me.Icon_File.Properties.AutoHeight = False
        Me.Icon_File.Required = ""
        Me.Icon_File.Size = New System.Drawing.Size(252, 26)
        Me.Icon_File.TabIndex = 12
        Me.Icon_File.TableName = "SYS_MENU"
        Me.Icon_File.ToolTip = "NAME(U_TextBox) VIEW(SYS_MENU) TAB(SYS_MENU) FIELD (DESCRIPTION)"
        Me.Icon_File.UpdateIfNull = ""
        Me.Icon_File.UpdateWhenFormLock = False
        Me.Icon_File.UpperValue = False
        Me.Icon_File.ViewName = "SYS_MENU"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(324, 110)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl6.TabIndex = 13
        Me.LabelControl6.Text = "File ảnh"
        '
        'FrmMenuNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 463)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.Icon_File)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.TO_DATE)
        Me.Controls.Add(Me.FROM_DATE)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.DESCRIPTION)
        Me.Controls.Add(Me.MENU_NAME)
        Me.Controls.Add(Me.MENU_CODE)
        Me.DefaultFormLoad = False
        Me.FormItemKey = "MENU_CODE"
        Me.HeaderSource = "SYS_MENU"
        Me.KeyPreview = True
        Me.Name = "FrmMenuNew"
        Me.SequenceName = ""
        Me.SetSourceItem = True
        Me.Text = "Menu"
        Me.Controls.SetChildIndex(Me.MENU_CODE, 0)
        Me.Controls.SetChildIndex(Me.MENU_NAME, 0)
        Me.Controls.SetChildIndex(Me.DESCRIPTION, 0)
        Me.Controls.SetChildIndex(Me.LabelControl1, 0)
        Me.Controls.SetChildIndex(Me.LabelControl2, 0)
        Me.Controls.SetChildIndex(Me.LabelControl3, 0)
        Me.Controls.SetChildIndex(Me.FROM_DATE, 0)
        Me.Controls.SetChildIndex(Me.TO_DATE, 0)
        Me.Controls.SetChildIndex(Me.LabelControl4, 0)
        Me.Controls.SetChildIndex(Me.LabelControl5, 0)
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.Icon_File, 0)
        Me.Controls.SetChildIndex(Me.LabelControl6, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENU_CODE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENU_NAME.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DESCRIPTION.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FROM_DATE.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FROM_DATE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TO_DATE.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TO_DATE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Icon_File.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MENU_CODE As U_TextBox.U_TextBox
    Friend WithEvents MENU_NAME As U_TextBox.U_TextBox
    Friend WithEvents DESCRIPTION As U_TextBox.U_TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents FROM_DATE As U_TextBox.U_DateEdit
    Friend WithEvents TO_DATE As U_TextBox.U_DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents RESPONSIBILITY_MENU_ID As U_TextBox.GridColumn
    Friend WithEvents ORDER_NUM As U_TextBox.GridColumn
    Friend WithEvents ColMENU_CODE As U_TextBox.GridColumn
    Friend WithEvents FUNCTION_ID As U_TextBox.GridColumn
    Friend WithEvents FUNCTION_NAME As U_TextBox.GridColumn
    Friend WithEvents ColDESCRIPTION As U_TextBox.GridColumn
    Friend WithEvents ColFROM_DATE As U_TextBox.GridColumn
    Friend WithEvents ColTO_DATE As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents SubMenu As U_TextBox.GridColumn
    Friend WithEvents SubMenuName As U_TextBox.GridColumn
    Friend WithEvents Icon_File As U_TextBox.U_TextBox
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
End Class
