<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTankHeaderImp_QL
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
        Me.X = New U_TextBox.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.colDocEntry = New U_TextBox.GridColumn()
        Me.TankHeaderCode = New U_TextBox.GridColumn()
        Me.colCreateDate = New U_TextBox.GridColumn()
        Me.FromDate = New U_TextBox.GridColumn()
        Me.ToDate = New U_TextBox.GridColumn()
        Me.colClient = New U_TextBox.GridColumn()
        Me.colsType = New U_TextBox.GridColumn()
        Me.PurposeCode = New U_TextBox.GridColumn()
        Me.Type = New U_TextBox.GridColumn()
        Me.CreateUser = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.SimpleButton7 = New U_TextBox.U_ButtonCus()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.sType = New U_TextBox.U_Combobox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DocEntry = New U_TextBox.U_NumericEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Client = New U_TextBox.U_ButtonEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CreateDate = New U_TextBox.U_DateEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToCreateDate = New U_TextBox.U_DateEdit()
        Me.U_ButtonCus1 = New U_TextBox.U_ButtonCus()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Status = New U_TextBox.U_Combobox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocEntry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Client.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreateDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CreateDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToCreateDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToCreateDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Status.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 79)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemCheckEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(911, 349)
        Me.TrueDBGrid1.TabIndex = 2
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridView1.CheckUpd = False
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.X, Me.colDocEntry, Me.TankHeaderCode, Me.colCreateDate, Me.FromDate, Me.ToDate, Me.colClient, Me.colsType, Me.PurposeCode, Me.Type, Me.CreateUser})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "CreateDate desc, Docentry Desc"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "ztblTankHeaderImp_V"
        Me.GridView1.Where = Nothing
        '
        'X
        '
        Me.X.AllowInsert = True
        Me.X.AllowUpdate = True
        Me.X.ButtonClick = True
        Me.X.Caption = "X"
        Me.X.CFLColumnHide = ""
        Me.X.CFLKeyField = ""
        Me.X.CFLPage = False
        Me.X.CFLReturn0 = ""
        Me.X.CFLReturn1 = ""
        Me.X.CFLReturn2 = ""
        Me.X.CFLReturn3 = ""
        Me.X.CFLReturn4 = ""
        Me.X.CFLReturn5 = ""
        Me.X.CFLReturn6 = ""
        Me.X.CFLReturn7 = ""
        Me.X.CFLShowLoad = False
        Me.X.ChangeFormStatus = True
        Me.X.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.X.ColumnKey = False
        Me.X.ComboLine = 5
        Me.X.CopyFromItem = ""
        Me.X.DefaultButtonClick = False
        Me.X.Digit = False
        Me.X.FieldType = "C"
        Me.X.FieldView = "X"
        Me.X.FormarNumber = True
        Me.X.FormList = False
        Me.X.KeyInsert = ""
        Me.X.LocalDecimal = False
        Me.X.Name = "X"
        Me.X.NoUpdate = ""
        Me.X.NumberDecimal = 0
        Me.X.ParentControl = ""
        Me.X.RefreshSource = False
        Me.X.Required = False
        Me.X.SequenceName = ""
        Me.X.ShowCalc = True
        Me.X.ShowDataTime = False
        Me.X.ShowOnlyTime = False
        Me.X.SQLString = ""
        Me.X.UpdateIfNull = ""
        Me.X.UpdateWhenFormLock = False
        Me.X.UpperValue = False
        Me.X.ValidateValue = True
        Me.X.Visible = True
        Me.X.VisibleIndex = 0
        Me.X.Width = 35
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        '
        'colDocEntry
        '
        Me.colDocEntry.AllowInsert = True
        Me.colDocEntry.AllowUpdate = True
        Me.colDocEntry.ButtonClick = True
        Me.colDocEntry.Caption = "Số GD"
        Me.colDocEntry.CFLColumnHide = ""
        Me.colDocEntry.CFLKeyField = ""
        Me.colDocEntry.CFLPage = False
        Me.colDocEntry.CFLReturn0 = ""
        Me.colDocEntry.CFLReturn1 = ""
        Me.colDocEntry.CFLReturn2 = ""
        Me.colDocEntry.CFLReturn3 = ""
        Me.colDocEntry.CFLReturn4 = ""
        Me.colDocEntry.CFLReturn5 = ""
        Me.colDocEntry.CFLReturn6 = ""
        Me.colDocEntry.CFLReturn7 = ""
        Me.colDocEntry.CFLShowLoad = False
        Me.colDocEntry.ChangeFormStatus = True
        Me.colDocEntry.ColumnKey = False
        Me.colDocEntry.ComboLine = 5
        Me.colDocEntry.CopyFromItem = ""
        Me.colDocEntry.DefaultButtonClick = False
        Me.colDocEntry.Digit = False
        Me.colDocEntry.FieldType = "N"
        Me.colDocEntry.FieldView = "DocEntry"
        Me.colDocEntry.FormarNumber = True
        Me.colDocEntry.FormList = False
        Me.colDocEntry.KeyInsert = ""
        Me.colDocEntry.LocalDecimal = False
        Me.colDocEntry.Name = "colDocEntry"
        Me.colDocEntry.NoUpdate = ""
        Me.colDocEntry.NumberDecimal = 0
        Me.colDocEntry.OptionsColumn.ReadOnly = True
        Me.colDocEntry.ParentControl = ""
        Me.colDocEntry.RefreshSource = False
        Me.colDocEntry.Required = False
        Me.colDocEntry.SequenceName = ""
        Me.colDocEntry.ShowCalc = True
        Me.colDocEntry.ShowDataTime = False
        Me.colDocEntry.ShowOnlyTime = False
        Me.colDocEntry.SQLString = ""
        Me.colDocEntry.UpdateIfNull = ""
        Me.colDocEntry.UpdateWhenFormLock = False
        Me.colDocEntry.UpperValue = False
        Me.colDocEntry.ValidateValue = True
        Me.colDocEntry.Visible = True
        Me.colDocEntry.VisibleIndex = 1
        '
        'TankHeaderCode
        '
        Me.TankHeaderCode.AllowInsert = True
        Me.TankHeaderCode.AllowUpdate = True
        Me.TankHeaderCode.ButtonClick = True
        Me.TankHeaderCode.Caption = "GridColumn1"
        Me.TankHeaderCode.CFLColumnHide = ""
        Me.TankHeaderCode.CFLKeyField = ""
        Me.TankHeaderCode.CFLPage = False
        Me.TankHeaderCode.CFLReturn0 = ""
        Me.TankHeaderCode.CFLReturn1 = ""
        Me.TankHeaderCode.CFLReturn2 = ""
        Me.TankHeaderCode.CFLReturn3 = ""
        Me.TankHeaderCode.CFLReturn4 = ""
        Me.TankHeaderCode.CFLReturn5 = ""
        Me.TankHeaderCode.CFLReturn6 = ""
        Me.TankHeaderCode.CFLReturn7 = ""
        Me.TankHeaderCode.CFLShowLoad = False
        Me.TankHeaderCode.ChangeFormStatus = True
        Me.TankHeaderCode.ColumnKey = False
        Me.TankHeaderCode.ComboLine = 5
        Me.TankHeaderCode.CopyFromItem = ""
        Me.TankHeaderCode.DefaultButtonClick = False
        Me.TankHeaderCode.Digit = False
        Me.TankHeaderCode.FieldType = "C"
        Me.TankHeaderCode.FieldView = "TankHeaderCode"
        Me.TankHeaderCode.FormarNumber = True
        Me.TankHeaderCode.FormList = False
        Me.TankHeaderCode.KeyInsert = ""
        Me.TankHeaderCode.LocalDecimal = False
        Me.TankHeaderCode.Name = "TankHeaderCode"
        Me.TankHeaderCode.NoUpdate = ""
        Me.TankHeaderCode.NumberDecimal = 0
        Me.TankHeaderCode.OptionsColumn.ReadOnly = True
        Me.TankHeaderCode.ParentControl = ""
        Me.TankHeaderCode.RefreshSource = False
        Me.TankHeaderCode.Required = False
        Me.TankHeaderCode.SequenceName = ""
        Me.TankHeaderCode.ShowCalc = True
        Me.TankHeaderCode.ShowDataTime = False
        Me.TankHeaderCode.ShowOnlyTime = False
        Me.TankHeaderCode.SQLString = ""
        Me.TankHeaderCode.UpdateIfNull = ""
        Me.TankHeaderCode.UpdateWhenFormLock = False
        Me.TankHeaderCode.UpperValue = False
        Me.TankHeaderCode.ValidateValue = True
        Me.TankHeaderCode.Visible = True
        '
        'colCreateDate
        '
        Me.colCreateDate.AllowInsert = True
        Me.colCreateDate.AllowUpdate = True
        Me.colCreateDate.ButtonClick = True
        Me.colCreateDate.Caption = "Ngày tháng"
        Me.colCreateDate.CFLColumnHide = ""
        Me.colCreateDate.CFLKeyField = ""
        Me.colCreateDate.CFLPage = False
        Me.colCreateDate.CFLReturn0 = ""
        Me.colCreateDate.CFLReturn1 = ""
        Me.colCreateDate.CFLReturn2 = ""
        Me.colCreateDate.CFLReturn3 = ""
        Me.colCreateDate.CFLReturn4 = ""
        Me.colCreateDate.CFLReturn5 = ""
        Me.colCreateDate.CFLReturn6 = ""
        Me.colCreateDate.CFLReturn7 = ""
        Me.colCreateDate.CFLShowLoad = False
        Me.colCreateDate.ChangeFormStatus = True
        Me.colCreateDate.ColumnKey = False
        Me.colCreateDate.ComboLine = 5
        Me.colCreateDate.CopyFromItem = ""
        Me.colCreateDate.DefaultButtonClick = False
        Me.colCreateDate.Digit = False
        Me.colCreateDate.FieldType = "D"
        Me.colCreateDate.FieldView = "CreateDate"
        Me.colCreateDate.FormarNumber = True
        Me.colCreateDate.FormList = False
        Me.colCreateDate.KeyInsert = ""
        Me.colCreateDate.LocalDecimal = False
        Me.colCreateDate.Name = "colCreateDate"
        Me.colCreateDate.NoUpdate = ""
        Me.colCreateDate.NumberDecimal = 0
        Me.colCreateDate.OptionsColumn.ReadOnly = True
        Me.colCreateDate.ParentControl = ""
        Me.colCreateDate.RefreshSource = False
        Me.colCreateDate.Required = False
        Me.colCreateDate.SequenceName = ""
        Me.colCreateDate.ShowCalc = True
        Me.colCreateDate.ShowDataTime = False
        Me.colCreateDate.ShowOnlyTime = False
        Me.colCreateDate.SQLString = ""
        Me.colCreateDate.UpdateIfNull = ""
        Me.colCreateDate.UpdateWhenFormLock = False
        Me.colCreateDate.UpperValue = False
        Me.colCreateDate.ValidateValue = True
        Me.colCreateDate.Visible = True
        Me.colCreateDate.VisibleIndex = 2
        Me.colCreateDate.Width = 120
        '
        'FromDate
        '
        Me.FromDate.AllowInsert = True
        Me.FromDate.AllowUpdate = True
        Me.FromDate.ButtonClick = True
        Me.FromDate.Caption = "Ngày giờ"
        Me.FromDate.CFLColumnHide = ""
        Me.FromDate.CFLKeyField = ""
        Me.FromDate.CFLPage = False
        Me.FromDate.CFLReturn0 = ""
        Me.FromDate.CFLReturn1 = ""
        Me.FromDate.CFLReturn2 = ""
        Me.FromDate.CFLReturn3 = ""
        Me.FromDate.CFLReturn4 = ""
        Me.FromDate.CFLReturn5 = ""
        Me.FromDate.CFLReturn6 = ""
        Me.FromDate.CFLReturn7 = ""
        Me.FromDate.CFLShowLoad = False
        Me.FromDate.ChangeFormStatus = True
        Me.FromDate.ColumnKey = False
        Me.FromDate.ComboLine = 5
        Me.FromDate.CopyFromItem = ""
        Me.FromDate.DefaultButtonClick = False
        Me.FromDate.Digit = False
        Me.FromDate.FieldType = "D"
        Me.FromDate.FieldView = "FromDate"
        Me.FromDate.FormarNumber = True
        Me.FromDate.FormList = False
        Me.FromDate.KeyInsert = ""
        Me.FromDate.LocalDecimal = False
        Me.FromDate.Name = "FromDate"
        Me.FromDate.NoUpdate = ""
        Me.FromDate.NumberDecimal = 0
        Me.FromDate.OptionsColumn.ReadOnly = True
        Me.FromDate.ParentControl = ""
        Me.FromDate.RefreshSource = False
        Me.FromDate.Required = False
        Me.FromDate.SequenceName = ""
        Me.FromDate.ShowCalc = True
        Me.FromDate.ShowDataTime = True
        Me.FromDate.ShowOnlyTime = False
        Me.FromDate.SQLString = ""
        Me.FromDate.UpdateIfNull = ""
        Me.FromDate.UpdateWhenFormLock = False
        Me.FromDate.UpperValue = False
        Me.FromDate.ValidateValue = True
        Me.FromDate.Visible = True
        Me.FromDate.VisibleIndex = 3
        Me.FromDate.Width = 220
        '
        'ToDate
        '
        Me.ToDate.AllowInsert = True
        Me.ToDate.AllowUpdate = True
        Me.ToDate.ButtonClick = True
        Me.ToDate.Caption = "GridColumn4"
        Me.ToDate.CFLColumnHide = ""
        Me.ToDate.CFLKeyField = ""
        Me.ToDate.CFLPage = False
        Me.ToDate.CFLReturn0 = ""
        Me.ToDate.CFLReturn1 = ""
        Me.ToDate.CFLReturn2 = ""
        Me.ToDate.CFLReturn3 = ""
        Me.ToDate.CFLReturn4 = ""
        Me.ToDate.CFLReturn5 = ""
        Me.ToDate.CFLReturn6 = ""
        Me.ToDate.CFLReturn7 = ""
        Me.ToDate.CFLShowLoad = False
        Me.ToDate.ChangeFormStatus = True
        Me.ToDate.ColumnKey = False
        Me.ToDate.ComboLine = 5
        Me.ToDate.CopyFromItem = ""
        Me.ToDate.DefaultButtonClick = False
        Me.ToDate.Digit = False
        Me.ToDate.FieldType = "C"
        Me.ToDate.FieldView = ""
        Me.ToDate.FormarNumber = True
        Me.ToDate.FormList = False
        Me.ToDate.KeyInsert = ""
        Me.ToDate.LocalDecimal = False
        Me.ToDate.Name = "ToDate"
        Me.ToDate.NoUpdate = ""
        Me.ToDate.NumberDecimal = 0
        Me.ToDate.OptionsColumn.ReadOnly = True
        Me.ToDate.ParentControl = ""
        Me.ToDate.RefreshSource = False
        Me.ToDate.Required = False
        Me.ToDate.SequenceName = ""
        Me.ToDate.ShowCalc = True
        Me.ToDate.ShowDataTime = False
        Me.ToDate.ShowOnlyTime = False
        Me.ToDate.SQLString = ""
        Me.ToDate.UpdateIfNull = ""
        Me.ToDate.UpdateWhenFormLock = False
        Me.ToDate.UpperValue = False
        Me.ToDate.ValidateValue = True
        Me.ToDate.Visible = True
        '
        'colClient
        '
        Me.colClient.AllowInsert = True
        Me.colClient.AllowUpdate = True
        Me.colClient.ButtonClick = True
        Me.colClient.Caption = "Kho"
        Me.colClient.CFLColumnHide = ""
        Me.colClient.CFLKeyField = ""
        Me.colClient.CFLPage = False
        Me.colClient.CFLReturn0 = ""
        Me.colClient.CFLReturn1 = ""
        Me.colClient.CFLReturn2 = ""
        Me.colClient.CFLReturn3 = ""
        Me.colClient.CFLReturn4 = ""
        Me.colClient.CFLReturn5 = ""
        Me.colClient.CFLReturn6 = ""
        Me.colClient.CFLReturn7 = ""
        Me.colClient.CFLShowLoad = False
        Me.colClient.ChangeFormStatus = True
        Me.colClient.ColumnKey = False
        Me.colClient.ComboLine = 5
        Me.colClient.CopyFromItem = ""
        Me.colClient.DefaultButtonClick = False
        Me.colClient.Digit = False
        Me.colClient.FieldType = "C"
        Me.colClient.FieldView = "Client"
        Me.colClient.FormarNumber = True
        Me.colClient.FormList = False
        Me.colClient.KeyInsert = ""
        Me.colClient.LocalDecimal = False
        Me.colClient.Name = "colClient"
        Me.colClient.NoUpdate = ""
        Me.colClient.NumberDecimal = 0
        Me.colClient.OptionsColumn.ReadOnly = True
        Me.colClient.ParentControl = ""
        Me.colClient.RefreshSource = False
        Me.colClient.Required = False
        Me.colClient.SequenceName = ""
        Me.colClient.ShowCalc = True
        Me.colClient.ShowDataTime = False
        Me.colClient.ShowOnlyTime = False
        Me.colClient.SQLString = ""
        Me.colClient.UpdateIfNull = ""
        Me.colClient.UpdateWhenFormLock = False
        Me.colClient.UpperValue = False
        Me.colClient.ValidateValue = True
        Me.colClient.Visible = True
        Me.colClient.VisibleIndex = 4
        Me.colClient.Width = 60
        '
        'colsType
        '
        Me.colsType.AllowInsert = True
        Me.colsType.AllowUpdate = True
        Me.colsType.ButtonClick = True
        Me.colsType.Caption = "Loại"
        Me.colsType.CFLColumnHide = ""
        Me.colsType.CFLKeyField = ""
        Me.colsType.CFLPage = False
        Me.colsType.CFLReturn0 = ""
        Me.colsType.CFLReturn1 = ""
        Me.colsType.CFLReturn2 = ""
        Me.colsType.CFLReturn3 = ""
        Me.colsType.CFLReturn4 = ""
        Me.colsType.CFLReturn5 = ""
        Me.colsType.CFLReturn6 = ""
        Me.colsType.CFLReturn7 = ""
        Me.colsType.CFLShowLoad = False
        Me.colsType.ChangeFormStatus = True
        Me.colsType.ColumnKey = False
        Me.colsType.ComboLine = 5
        Me.colsType.CopyFromItem = ""
        Me.colsType.DefaultButtonClick = False
        Me.colsType.Digit = False
        Me.colsType.FieldType = "C"
        Me.colsType.FieldView = "sTypeName"
        Me.colsType.FormarNumber = True
        Me.colsType.FormList = False
        Me.colsType.KeyInsert = ""
        Me.colsType.LocalDecimal = False
        Me.colsType.Name = "colsType"
        Me.colsType.NoUpdate = ""
        Me.colsType.NumberDecimal = 0
        Me.colsType.OptionsColumn.ReadOnly = True
        Me.colsType.ParentControl = ""
        Me.colsType.RefreshSource = False
        Me.colsType.Required = False
        Me.colsType.SequenceName = ""
        Me.colsType.ShowCalc = True
        Me.colsType.ShowDataTime = False
        Me.colsType.ShowOnlyTime = False
        Me.colsType.SQLString = "select 'A' as Code , N'Thông tin ATG' as Name Union select 'M' as Code , N'Nhập t" & _
            "ay' as Name"
        Me.colsType.UpdateIfNull = ""
        Me.colsType.UpdateWhenFormLock = False
        Me.colsType.UpperValue = False
        Me.colsType.ValidateValue = True
        Me.colsType.Visible = True
        Me.colsType.VisibleIndex = 5
        Me.colsType.Width = 100
        '
        'PurposeCode
        '
        Me.PurposeCode.AllowInsert = True
        Me.PurposeCode.AllowUpdate = True
        Me.PurposeCode.ButtonClick = True
        Me.PurposeCode.Caption = "Mục đích đo"
        Me.PurposeCode.CFLColumnHide = ""
        Me.PurposeCode.CFLKeyField = ""
        Me.PurposeCode.CFLPage = False
        Me.PurposeCode.CFLReturn0 = ""
        Me.PurposeCode.CFLReturn1 = ""
        Me.PurposeCode.CFLReturn2 = ""
        Me.PurposeCode.CFLReturn3 = ""
        Me.PurposeCode.CFLReturn4 = ""
        Me.PurposeCode.CFLReturn5 = ""
        Me.PurposeCode.CFLReturn6 = ""
        Me.PurposeCode.CFLReturn7 = ""
        Me.PurposeCode.CFLShowLoad = False
        Me.PurposeCode.ChangeFormStatus = True
        Me.PurposeCode.ColumnKey = False
        Me.PurposeCode.ComboLine = 5
        Me.PurposeCode.CopyFromItem = ""
        Me.PurposeCode.DefaultButtonClick = False
        Me.PurposeCode.Digit = False
        Me.PurposeCode.FieldType = "C"
        Me.PurposeCode.FieldView = "PurposeName"
        Me.PurposeCode.FormarNumber = True
        Me.PurposeCode.FormList = False
        Me.PurposeCode.KeyInsert = ""
        Me.PurposeCode.LocalDecimal = False
        Me.PurposeCode.Name = "PurposeCode"
        Me.PurposeCode.NoUpdate = ""
        Me.PurposeCode.NumberDecimal = 0
        Me.PurposeCode.OptionsColumn.ReadOnly = True
        Me.PurposeCode.ParentControl = ""
        Me.PurposeCode.RefreshSource = False
        Me.PurposeCode.Required = False
        Me.PurposeCode.SequenceName = ""
        Me.PurposeCode.ShowCalc = True
        Me.PurposeCode.ShowDataTime = False
        Me.PurposeCode.ShowOnlyTime = False
        Me.PurposeCode.SQLString = ""
        Me.PurposeCode.UpdateIfNull = ""
        Me.PurposeCode.UpdateWhenFormLock = False
        Me.PurposeCode.UpperValue = False
        Me.PurposeCode.ValidateValue = True
        Me.PurposeCode.Visible = True
        Me.PurposeCode.VisibleIndex = 6
        Me.PurposeCode.Width = 250
        '
        'Type
        '
        Me.Type.AllowInsert = True
        Me.Type.AllowUpdate = True
        Me.Type.ButtonClick = True
        Me.Type.Caption = "GridColumn1"
        Me.Type.CFLColumnHide = ""
        Me.Type.CFLKeyField = ""
        Me.Type.CFLPage = False
        Me.Type.CFLReturn0 = ""
        Me.Type.CFLReturn1 = ""
        Me.Type.CFLReturn2 = ""
        Me.Type.CFLReturn3 = ""
        Me.Type.CFLReturn4 = ""
        Me.Type.CFLReturn5 = ""
        Me.Type.CFLReturn6 = ""
        Me.Type.CFLReturn7 = ""
        Me.Type.CFLShowLoad = False
        Me.Type.ChangeFormStatus = True
        Me.Type.ColumnKey = False
        Me.Type.ComboLine = 5
        Me.Type.CopyFromItem = ""
        Me.Type.DefaultButtonClick = False
        Me.Type.Digit = False
        Me.Type.FieldType = "C"
        Me.Type.FieldView = "sType"
        Me.Type.FormarNumber = True
        Me.Type.FormList = False
        Me.Type.KeyInsert = ""
        Me.Type.LocalDecimal = False
        Me.Type.Name = "Type"
        Me.Type.NoUpdate = ""
        Me.Type.NumberDecimal = 0
        Me.Type.OptionsColumn.ReadOnly = True
        Me.Type.ParentControl = ""
        Me.Type.RefreshSource = False
        Me.Type.Required = False
        Me.Type.SequenceName = ""
        Me.Type.ShowCalc = True
        Me.Type.ShowDataTime = False
        Me.Type.ShowOnlyTime = False
        Me.Type.SQLString = ""
        Me.Type.UpdateIfNull = ""
        Me.Type.UpdateWhenFormLock = False
        Me.Type.UpperValue = False
        Me.Type.ValidateValue = True
        Me.Type.Visible = True
        '
        'CreateUser
        '
        Me.CreateUser.AllowInsert = True
        Me.CreateUser.AllowUpdate = True
        Me.CreateUser.ButtonClick = True
        Me.CreateUser.Caption = "User tạo"
        Me.CreateUser.CFLColumnHide = ""
        Me.CreateUser.CFLKeyField = ""
        Me.CreateUser.CFLPage = False
        Me.CreateUser.CFLReturn0 = ""
        Me.CreateUser.CFLReturn1 = ""
        Me.CreateUser.CFLReturn2 = ""
        Me.CreateUser.CFLReturn3 = ""
        Me.CreateUser.CFLReturn4 = ""
        Me.CreateUser.CFLReturn5 = ""
        Me.CreateUser.CFLReturn6 = ""
        Me.CreateUser.CFLReturn7 = ""
        Me.CreateUser.CFLShowLoad = False
        Me.CreateUser.ChangeFormStatus = True
        Me.CreateUser.ColumnKey = False
        Me.CreateUser.ComboLine = 5
        Me.CreateUser.CopyFromItem = ""
        Me.CreateUser.DefaultButtonClick = False
        Me.CreateUser.Digit = False
        Me.CreateUser.FieldType = "C"
        Me.CreateUser.FieldView = "CreateUser"
        Me.CreateUser.FormarNumber = True
        Me.CreateUser.FormList = False
        Me.CreateUser.KeyInsert = ""
        Me.CreateUser.LocalDecimal = False
        Me.CreateUser.Name = "CreateUser"
        Me.CreateUser.NoUpdate = ""
        Me.CreateUser.NumberDecimal = 0
        Me.CreateUser.OptionsColumn.ReadOnly = True
        Me.CreateUser.ParentControl = ""
        Me.CreateUser.RefreshSource = False
        Me.CreateUser.Required = False
        Me.CreateUser.SequenceName = ""
        Me.CreateUser.ShowCalc = True
        Me.CreateUser.ShowDataTime = False
        Me.CreateUser.ShowOnlyTime = False
        Me.CreateUser.SQLString = ""
        Me.CreateUser.UpdateIfNull = ""
        Me.CreateUser.UpdateWhenFormLock = False
        Me.CreateUser.UpperValue = False
        Me.CreateUser.ValidateValue = True
        Me.CreateUser.Visible = True
        Me.CreateUser.VisibleIndex = 7
        Me.CreateUser.Width = 100
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.DefaultUpdate = True
        Me.SimpleButton7.EnableWhenFormLock = True
        Me.SimpleButton7.Location = New System.Drawing.Point(807, 9)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(99, 29)
        Me.SimpleButton7.TabIndex = 204
        Me.SimpleButton7.Text = "Tìm &kiếm"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(312, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 19)
        Me.Label6.TabIndex = 495
        Me.Label6.Text = "Loại"
        '
        'sType
        '
        Me.sType.AllowInsert = True
        Me.sType.AllowUpdate = True
        Me.sType.BindingSourceName = ""
        Me.sType.ChangeFormStatus = False
        Me.sType.CopyFromItem = ""
        Me.sType.DefaultValue = ""
        Me.sType.DisplayField = "Name"
        Me.sType.DropDownRow = 10
        Me.sType.FieldName = ""
        Me.sType.FieldType = "C"
        Me.sType.ItemValue = ""
        Me.sType.KeyInsert = ""
        Me.sType.LinkLabel = ""
        Me.sType.Location = New System.Drawing.Point(361, 5)
        Me.sType.Name = "sType"
        Me.sType.NoUpdate = ""
        Me.sType.PrimaryKey = ""
        Me.sType.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.sType.Properties.Appearance.Options.UseFont = True
        Me.sType.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.sType.Properties.AppearanceDisabled.Options.UseFont = True
        Me.sType.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.sType.Properties.AppearanceFocused.Options.UseFont = True
        Me.sType.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.sType.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.sType.Properties.AutoHeight = False
        Me.sType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.sType.Properties.NullText = ""
        Me.sType.Properties.ShowHeader = False
        Me.sType.Required = ""
        Me.sType.ShowHeader = False
        Me.sType.Size = New System.Drawing.Size(124, 26)
        Me.sType.SQL_String = "select 'A' as Code , N'Thông tin ATG' as Name Union select 'M' as Code , N'Nhập t" & _
            "ay' as Name"
        Me.sType.TabIndex = 1
        Me.sType.TableName = ""
        Me.sType.UpdateIfNull = ""
        Me.sType.UpdateWhenFormLock = False
        Me.sType.ValueField = "Code"
        Me.sType.ViewName = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 19)
        Me.Label4.TabIndex = 494
        Me.Label4.Text = "Số giao dịch"
        '
        'DocEntry
        '
        Me.DocEntry.AllowInsert = False
        Me.DocEntry.AllowUpdate = False
        Me.DocEntry.AutoKeyFix = ""
        Me.DocEntry.AutoKeyName = ""
        Me.DocEntry.BindingSourceName = ""
        Me.DocEntry.ChangeFormStatus = False
        Me.DocEntry.CopyFromItem = ""
        Me.DocEntry.DefaultValue = ""
        Me.DocEntry.Digit = True
        Me.DocEntry.FieldName = ""
        Me.DocEntry.FieldType = "N"
        Me.DocEntry.KeyInsert = ""
        Me.DocEntry.LinkLabel = "Label4"
        Me.DocEntry.LocalDecimal = False
        Me.DocEntry.Location = New System.Drawing.Point(143, 6)
        Me.DocEntry.Name = "DocEntry"
        Me.DocEntry.NoUpdate = ""
        Me.DocEntry.NumberDecimal = 0
        Me.DocEntry.PrimaryKey = ""
        Me.DocEntry.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.DocEntry.Properties.Appearance.Options.UseFont = True
        Me.DocEntry.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.DocEntry.Properties.AppearanceDisabled.Options.UseFont = True
        Me.DocEntry.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.DocEntry.Properties.AppearanceFocused.Options.UseFont = True
        Me.DocEntry.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.DocEntry.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.DocEntry.Properties.AutoHeight = False
        Me.DocEntry.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DocEntry.Required = ""
        Me.DocEntry.ShowCalc = True
        Me.DocEntry.Size = New System.Drawing.Size(120, 26)
        Me.DocEntry.TabIndex = 0
        Me.DocEntry.TableName = ""
        Me.DocEntry.TabStop = False
        Me.DocEntry.UpdateIfNull = ""
        Me.DocEntry.UpdateWhenFormLock = False
        Me.DocEntry.ViewName = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(530, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 19)
        Me.Label1.TabIndex = 493
        Me.Label1.Text = "Kho"
        '
        'Client
        '
        Me.Client.AllowInsert = True
        Me.Client.AllowUpdate = True
        Me.Client.AutoWidth = False
        Me.Client.BindingSourceName = ""
        Me.Client.ChangeFormStatus = False
        Me.Client.CopyFromItem = ""
        Me.Client.DefaultButtonClick = True
        Me.Client.DefaultValue = ""
        Me.Client.FieldName = ""
        Me.Client.FieldType = "C"
        Me.Client.FormList = True
        Me.Client.ItemReturn1 = ""
        Me.Client.ItemReturn2 = ""
        Me.Client.ItemReturn3 = ""
        Me.Client.KeyInsert = ""
        Me.Client.LinkLabel = ""
        Me.Client.Location = New System.Drawing.Point(583, 5)
        Me.Client.MultiSelect = False
        Me.Client.Name = "Client"
        Me.Client.NoUpdate = "N"
        Me.Client.OrderbyEx = ""
        Me.Client.PrimaryKey = ""
        Me.Client.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.Appearance.Options.UseFont = True
        Me.Client.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceDisabled.Options.UseFont = True
        Me.Client.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceFocused.Options.UseFont = True
        Me.Client.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Client.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.Client.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Client.Required = ""
        Me.Client.ShowLoad = True
        Me.Client.Size = New System.Drawing.Size(83, 26)
        Me.Client.SqlFielKey = "Client"
        Me.Client.SqlString = ""
        Me.Client.TabIndex = 2
        Me.Client.TableName = ""
        Me.Client.UpdateIfNull = ""
        Me.Client.UpdateWhenFormLock = False
        Me.Client.UpperValue = False
        Me.Client.ValidateValue = False
        Me.Client.ViewName = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 19)
        Me.Label2.TabIndex = 492
        Me.Label2.Text = "Từ ngày"
        '
        'CreateDate
        '
        Me.CreateDate.AllowInsert = True
        Me.CreateDate.AllowUpdate = True
        Me.CreateDate.BindingSourceName = ""
        Me.CreateDate.ChangeFormStatus = False
        Me.CreateDate.CopyFromItem = ""
        Me.CreateDate.DefaultValue = ""
        Me.CreateDate.EditValue = Nothing
        Me.CreateDate.FieldName = ""
        Me.CreateDate.FieldType = "D"
        Me.CreateDate.KeyInsert = ""
        Me.CreateDate.LinkLabel = "Label2"
        Me.CreateDate.Location = New System.Drawing.Point(143, 37)
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.NoUpdate = ""
        Me.CreateDate.PrimaryKey = ""
        Me.CreateDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CreateDate.Properties.Appearance.Options.UseFont = True
        Me.CreateDate.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CreateDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.CreateDate.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CreateDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.CreateDate.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CreateDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.CreateDate.Properties.AutoHeight = False
        Me.CreateDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CreateDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.CreateDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CreateDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.CreateDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.CreateDate.Required = "Y"
        Me.CreateDate.ShowDateTime = False
        Me.CreateDate.Size = New System.Drawing.Size(120, 26)
        Me.CreateDate.TabIndex = 3
        Me.CreateDate.TableName = ""
        Me.CreateDate.TabStop = False
        Me.CreateDate.UpdateIfNull = ""
        Me.CreateDate.UpdateWhenFormLock = False
        Me.CreateDate.ViewName = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(274, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 19)
        Me.Label3.TabIndex = 497
        Me.Label3.Text = "Đến ngày"
        '
        'ToCreateDate
        '
        Me.ToCreateDate.AllowInsert = True
        Me.ToCreateDate.AllowUpdate = True
        Me.ToCreateDate.BindingSourceName = ""
        Me.ToCreateDate.ChangeFormStatus = False
        Me.ToCreateDate.CopyFromItem = ""
        Me.ToCreateDate.DefaultValue = ""
        Me.ToCreateDate.EditValue = Nothing
        Me.ToCreateDate.FieldName = ""
        Me.ToCreateDate.FieldType = "D"
        Me.ToCreateDate.KeyInsert = ""
        Me.ToCreateDate.LinkLabel = "Label2"
        Me.ToCreateDate.Location = New System.Drawing.Point(361, 37)
        Me.ToCreateDate.Name = "ToCreateDate"
        Me.ToCreateDate.NoUpdate = ""
        Me.ToCreateDate.PrimaryKey = ""
        Me.ToCreateDate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToCreateDate.Properties.Appearance.Options.UseFont = True
        Me.ToCreateDate.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToCreateDate.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ToCreateDate.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToCreateDate.Properties.AppearanceFocused.Options.UseFont = True
        Me.ToCreateDate.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ToCreateDate.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.ToCreateDate.Properties.AutoHeight = False
        Me.ToCreateDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ToCreateDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.ToCreateDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ToCreateDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.ToCreateDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ToCreateDate.Required = "Y"
        Me.ToCreateDate.ShowDateTime = False
        Me.ToCreateDate.Size = New System.Drawing.Size(124, 26)
        Me.ToCreateDate.TabIndex = 4
        Me.ToCreateDate.TableName = ""
        Me.ToCreateDate.TabStop = False
        Me.ToCreateDate.UpdateIfNull = ""
        Me.ToCreateDate.UpdateWhenFormLock = False
        Me.ToCreateDate.ViewName = ""
        '
        'U_ButtonCus1
        '
        Me.U_ButtonCus1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.U_ButtonCus1.Appearance.Options.UseFont = True
        Me.U_ButtonCus1.DefaultUpdate = True
        Me.U_ButtonCus1.EnableWhenFormLock = True
        Me.U_ButtonCus1.Location = New System.Drawing.Point(807, 45)
        Me.U_ButtonCus1.Name = "U_ButtonCus1"
        Me.U_ButtonCus1.Size = New System.Drawing.Size(99, 29)
        Me.U_ButtonCus1.TabIndex = 498
        Me.U_ButtonCus1.Text = "In &biên bản"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(496, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 19)
        Me.Label5.TabIndex = 500
        Me.Label5.Text = "Trạng thái"
        '
        'Status
        '
        Me.Status.AllowInsert = True
        Me.Status.AllowUpdate = True
        Me.Status.BindingSourceName = ""
        Me.Status.ChangeFormStatus = False
        Me.Status.CopyFromItem = ""
        Me.Status.DefaultValue = ""
        Me.Status.DisplayField = "Name"
        Me.Status.DropDownRow = 10
        Me.Status.FieldName = ""
        Me.Status.FieldType = "C"
        Me.Status.ItemValue = ""
        Me.Status.KeyInsert = ""
        Me.Status.LinkLabel = ""
        Me.Status.Location = New System.Drawing.Point(583, 37)
        Me.Status.Name = "Status"
        Me.Status.NoUpdate = ""
        Me.Status.PrimaryKey = ""
        Me.Status.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Status.Properties.Appearance.Options.UseFont = True
        Me.Status.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Status.Properties.AppearanceDisabled.Options.UseFont = True
        Me.Status.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Status.Properties.AppearanceFocused.Options.UseFont = True
        Me.Status.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.Status.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.Status.Properties.AutoHeight = False
        Me.Status.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Status.Properties.NullText = ""
        Me.Status.Properties.ShowHeader = False
        Me.Status.Required = ""
        Me.Status.ShowHeader = False
        Me.Status.Size = New System.Drawing.Size(155, 26)
        Me.Status.SQL_String = "select '' Code, N'Tất cả' as Name Union all select 'N' Code, N'Chưa lên SAP' as N" & _
            "ame Union all select 'S' Code, N'Đưa lên SAP' as Name"
        Me.Status.TabIndex = 5
        Me.Status.TableName = ""
        Me.Status.UpdateIfNull = ""
        Me.Status.UpdateWhenFormLock = False
        Me.Status.ValueField = "Code"
        Me.Status.ViewName = ""
        '
        'FrmTankHeaderImp_QL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 428)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Status)
        Me.Controls.Add(Me.U_ButtonCus1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ToCreateDate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.sType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DocEntry)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Client)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CreateDate)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.MaximizeBox = False
        Me.Name = "FrmTankHeaderImp_QL"
        Me.Text = "Danh sách thông tin đo bể"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton7, 0)
        Me.Controls.SetChildIndex(Me.CreateDate, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Client, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.DocEntry, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.sType, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.ToCreateDate, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.U_ButtonCus1, 0)
        Me.Controls.SetChildIndex(Me.Status, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocEntry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Client.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreateDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CreateDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToCreateDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToCreateDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Status.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents SimpleButton7 As U_TextBox.U_ButtonCus
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents sType As U_TextBox.U_Combobox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DocEntry As U_TextBox.U_NumericEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Client As U_TextBox.U_ButtonEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CreateDate As U_TextBox.U_DateEdit
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents TankHeaderCode As U_TextBox.GridColumn
    Friend WithEvents colCreateDate As U_TextBox.GridColumn
    Friend WithEvents FromDate As U_TextBox.GridColumn
    Friend WithEvents ToDate As U_TextBox.GridColumn
    Friend WithEvents colClient As U_TextBox.GridColumn
    Friend WithEvents PurposeCode As U_TextBox.GridColumn
    Friend WithEvents colDocEntry As U_TextBox.GridColumn
    Friend WithEvents Type As U_TextBox.GridColumn
    Friend WithEvents colsType As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToCreateDate As U_TextBox.U_DateEdit
    Friend WithEvents CreateUser As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents X As U_TextBox.GridColumn
    Friend WithEvents U_ButtonCus1 As U_TextBox.U_ButtonCus
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Status As U_TextBox.U_Combobox
End Class
