<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTankBatch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTankBatch))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.colID = New U_TextBox.GridColumn()
        Me.colTankCode = New U_TextBox.GridColumn()
        Me.Product_nd = New U_TextBox.GridColumn()
        Me.colBatchNum = New U_TextBox.GridColumn()
        Me.colAdd_Content = New U_TextBox.GridColumn()
        Me.colSDA_Amount = New U_TextBox.GridColumn()
        Me.colCrUser = New U_TextBox.GridColumn()
        Me.colCreateDate = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.GridColumn9 = New U_TextBox.GridColumn()
        Me.GridColumn10 = New U_TextBox.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TankCode = New U_TextBox.U_ButtonEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BatchNum = New U_TextBox.U_TextBox()
        Me.Add_Content = New U_TextBox.U_TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CrUser = New U_TextBox.U_TextBox()
        Me.ID = New U_TextBox.U_NumericEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SDA_Amount = New U_TextBox.U_TextBox()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.TankCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BatchNum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Add_Content.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CrUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SDA_Amount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.TrueDBGrid1.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 118)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.Size = New System.Drawing.Size(846, 371)
        Me.TrueDBGrid1.TabIndex = 0
        Me.TrueDBGrid1.UseEmbeddedNavigator = True
        Me.TrueDBGrid1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.AllowInsert = False
        Me.GridView1.CheckUpd = True
        Me.GridView1.ColumnAutoWidth = False
        Me.GridView1.ColumnKey = ""
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colTankCode, Me.Product_nd, Me.colBatchNum, Me.colAdd_Content, Me.colSDA_Amount, Me.colCrUser, Me.colCreateDate, Me.CHECKUPD, Me.GridColumn9, Me.GridColumn10})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsBehavior.ReadOnly = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "CreateDate desc,  TankCode"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = ""
        Me.GridView1.ViewName = "tblTankBatchs_v"
        Me.GridView1.Where = Nothing
        '
        'colID
        '
        Me.colID.AllowInsert = False
        Me.colID.AllowUpdate = False
        Me.colID.ButtonClick = True
        Me.colID.Caption = "ID"
        Me.colID.CFLColumnHide = ""
        Me.colID.CFLKeyField = ""
        Me.colID.CFLPage = False
        Me.colID.CFLReturn0 = ""
        Me.colID.CFLReturn1 = ""
        Me.colID.CFLReturn2 = ""
        Me.colID.CFLReturn3 = ""
        Me.colID.CFLReturn4 = ""
        Me.colID.CFLReturn5 = ""
        Me.colID.CFLReturn6 = ""
        Me.colID.CFLReturn7 = ""
        Me.colID.CFLShowLoad = False
        Me.colID.ChangeFormStatus = True
        Me.colID.ColumnKey = True
        Me.colID.ComboLine = 5
        Me.colID.CopyFromItem = ""
        Me.colID.DefaultButtonClick = False
        Me.colID.Digit = False
        Me.colID.FieldType = "N"
        Me.colID.FieldView = "ID"
        Me.colID.FormarNumber = True
        Me.colID.FormList = False
        Me.colID.KeyInsert = ""
        Me.colID.LocalDecimal = False
        Me.colID.Name = "colID"
        Me.colID.NoUpdate = ""
        Me.colID.NumberDecimal = 0
        Me.colID.ParentControl = ""
        Me.colID.RefreshSource = False
        Me.colID.Required = False
        Me.colID.SequenceName = ""
        Me.colID.ShowCalc = True
        Me.colID.ShowDataTime = False
        Me.colID.ShowOnlyTime = False
        Me.colID.SQLString = ""
        Me.colID.UpdateIfNull = ""
        Me.colID.UpdateWhenFormLock = False
        Me.colID.UpperValue = False
        Me.colID.ValidateValue = True
        Me.colID.Visible = True
        Me.colID.Width = 20
        '
        'colTankCode
        '
        Me.colTankCode.AllowInsert = True
        Me.colTankCode.AllowUpdate = True
        Me.colTankCode.ButtonClick = True
        Me.colTankCode.Caption = "Bể xuất"
        Me.colTankCode.CFLColumnHide = ""
        Me.colTankCode.CFLKeyField = ""
        Me.colTankCode.CFLPage = False
        Me.colTankCode.CFLReturn0 = ""
        Me.colTankCode.CFLReturn1 = ""
        Me.colTankCode.CFLReturn2 = ""
        Me.colTankCode.CFLReturn3 = ""
        Me.colTankCode.CFLReturn4 = ""
        Me.colTankCode.CFLReturn5 = ""
        Me.colTankCode.CFLReturn6 = ""
        Me.colTankCode.CFLReturn7 = ""
        Me.colTankCode.CFLShowLoad = False
        Me.colTankCode.ChangeFormStatus = True
        Me.colTankCode.ColumnKey = False
        Me.colTankCode.ComboLine = 5
        Me.colTankCode.CopyFromItem = ""
        Me.colTankCode.DefaultButtonClick = False
        Me.colTankCode.Digit = False
        Me.colTankCode.FieldType = "C"
        Me.colTankCode.FieldView = "TankCode"
        Me.colTankCode.FormarNumber = True
        Me.colTankCode.FormList = False
        Me.colTankCode.KeyInsert = ""
        Me.colTankCode.LocalDecimal = False
        Me.colTankCode.Name = "colTankCode"
        Me.colTankCode.NoUpdate = ""
        Me.colTankCode.NumberDecimal = 0
        Me.colTankCode.ParentControl = ""
        Me.colTankCode.RefreshSource = False
        Me.colTankCode.Required = False
        Me.colTankCode.SequenceName = ""
        Me.colTankCode.ShowCalc = True
        Me.colTankCode.ShowDataTime = False
        Me.colTankCode.ShowOnlyTime = False
        Me.colTankCode.SQLString = ""
        Me.colTankCode.UpdateIfNull = ""
        Me.colTankCode.UpdateWhenFormLock = False
        Me.colTankCode.UpperValue = False
        Me.colTankCode.ValidateValue = True
        Me.colTankCode.Visible = True
        Me.colTankCode.VisibleIndex = 0
        Me.colTankCode.Width = 80
        '
        'Product_nd
        '
        Me.Product_nd.AllowInsert = True
        Me.Product_nd.AllowUpdate = True
        Me.Product_nd.ButtonClick = True
        Me.Product_nd.Caption = "Hàng hóa"
        Me.Product_nd.CFLColumnHide = ""
        Me.Product_nd.CFLKeyField = ""
        Me.Product_nd.CFLPage = False
        Me.Product_nd.CFLReturn0 = ""
        Me.Product_nd.CFLReturn1 = ""
        Me.Product_nd.CFLReturn2 = ""
        Me.Product_nd.CFLReturn3 = ""
        Me.Product_nd.CFLReturn4 = ""
        Me.Product_nd.CFLReturn5 = ""
        Me.Product_nd.CFLReturn6 = ""
        Me.Product_nd.CFLReturn7 = ""
        Me.Product_nd.CFLShowLoad = False
        Me.Product_nd.ChangeFormStatus = True
        Me.Product_nd.ColumnKey = False
        Me.Product_nd.ComboLine = 5
        Me.Product_nd.CopyFromItem = ""
        Me.Product_nd.DefaultButtonClick = False
        Me.Product_nd.Digit = False
        Me.Product_nd.FieldType = "C"
        Me.Product_nd.FieldView = "Product_nd"
        Me.Product_nd.FormarNumber = True
        Me.Product_nd.FormList = False
        Me.Product_nd.KeyInsert = ""
        Me.Product_nd.LocalDecimal = False
        Me.Product_nd.Name = "Product_nd"
        Me.Product_nd.NoUpdate = ""
        Me.Product_nd.NumberDecimal = 0
        Me.Product_nd.ParentControl = ""
        Me.Product_nd.RefreshSource = False
        Me.Product_nd.Required = False
        Me.Product_nd.SequenceName = ""
        Me.Product_nd.ShowCalc = True
        Me.Product_nd.ShowDataTime = False
        Me.Product_nd.ShowOnlyTime = False
        Me.Product_nd.SQLString = ""
        Me.Product_nd.UpdateIfNull = ""
        Me.Product_nd.UpdateWhenFormLock = False
        Me.Product_nd.UpperValue = False
        Me.Product_nd.ValidateValue = True
        Me.Product_nd.Visible = True
        Me.Product_nd.VisibleIndex = 1
        Me.Product_nd.Width = 80
        '
        'colBatchNum
        '
        Me.colBatchNum.AllowInsert = True
        Me.colBatchNum.AllowUpdate = True
        Me.colBatchNum.ButtonClick = True
        Me.colBatchNum.Caption = "Số lô"
        Me.colBatchNum.CFLColumnHide = ""
        Me.colBatchNum.CFLKeyField = ""
        Me.colBatchNum.CFLPage = False
        Me.colBatchNum.CFLReturn0 = ""
        Me.colBatchNum.CFLReturn1 = ""
        Me.colBatchNum.CFLReturn2 = ""
        Me.colBatchNum.CFLReturn3 = ""
        Me.colBatchNum.CFLReturn4 = ""
        Me.colBatchNum.CFLReturn5 = ""
        Me.colBatchNum.CFLReturn6 = ""
        Me.colBatchNum.CFLReturn7 = ""
        Me.colBatchNum.CFLShowLoad = False
        Me.colBatchNum.ChangeFormStatus = True
        Me.colBatchNum.ColumnKey = False
        Me.colBatchNum.ComboLine = 5
        Me.colBatchNum.CopyFromItem = ""
        Me.colBatchNum.DefaultButtonClick = False
        Me.colBatchNum.Digit = False
        Me.colBatchNum.FieldType = "C"
        Me.colBatchNum.FieldView = "BatchNum"
        Me.colBatchNum.FormarNumber = True
        Me.colBatchNum.FormList = False
        Me.colBatchNum.KeyInsert = ""
        Me.colBatchNum.LocalDecimal = False
        Me.colBatchNum.Name = "colBatchNum"
        Me.colBatchNum.NoUpdate = ""
        Me.colBatchNum.NumberDecimal = 0
        Me.colBatchNum.ParentControl = ""
        Me.colBatchNum.RefreshSource = False
        Me.colBatchNum.Required = False
        Me.colBatchNum.SequenceName = ""
        Me.colBatchNum.ShowCalc = True
        Me.colBatchNum.ShowDataTime = False
        Me.colBatchNum.ShowOnlyTime = False
        Me.colBatchNum.SQLString = ""
        Me.colBatchNum.UpdateIfNull = ""
        Me.colBatchNum.UpdateWhenFormLock = False
        Me.colBatchNum.UpperValue = False
        Me.colBatchNum.ValidateValue = True
        Me.colBatchNum.Visible = True
        Me.colBatchNum.VisibleIndex = 2
        Me.colBatchNum.Width = 150
        '
        'colAdd_Content
        '
        Me.colAdd_Content.AllowInsert = True
        Me.colAdd_Content.AllowUpdate = True
        Me.colAdd_Content.ButtonClick = True
        Me.colAdd_Content.Caption = "Hàm lượng phụ gia"
        Me.colAdd_Content.CFLColumnHide = ""
        Me.colAdd_Content.CFLKeyField = ""
        Me.colAdd_Content.CFLPage = False
        Me.colAdd_Content.CFLReturn0 = ""
        Me.colAdd_Content.CFLReturn1 = ""
        Me.colAdd_Content.CFLReturn2 = ""
        Me.colAdd_Content.CFLReturn3 = ""
        Me.colAdd_Content.CFLReturn4 = ""
        Me.colAdd_Content.CFLReturn5 = ""
        Me.colAdd_Content.CFLReturn6 = ""
        Me.colAdd_Content.CFLReturn7 = ""
        Me.colAdd_Content.CFLShowLoad = False
        Me.colAdd_Content.ChangeFormStatus = True
        Me.colAdd_Content.ColumnKey = False
        Me.colAdd_Content.ComboLine = 5
        Me.colAdd_Content.CopyFromItem = ""
        Me.colAdd_Content.DefaultButtonClick = False
        Me.colAdd_Content.Digit = False
        Me.colAdd_Content.FieldType = "C"
        Me.colAdd_Content.FieldView = "Add_Content"
        Me.colAdd_Content.FormarNumber = True
        Me.colAdd_Content.FormList = False
        Me.colAdd_Content.KeyInsert = ""
        Me.colAdd_Content.LocalDecimal = False
        Me.colAdd_Content.Name = "colAdd_Content"
        Me.colAdd_Content.NoUpdate = ""
        Me.colAdd_Content.NumberDecimal = 0
        Me.colAdd_Content.ParentControl = ""
        Me.colAdd_Content.RefreshSource = False
        Me.colAdd_Content.Required = False
        Me.colAdd_Content.SequenceName = ""
        Me.colAdd_Content.ShowCalc = True
        Me.colAdd_Content.ShowDataTime = False
        Me.colAdd_Content.ShowOnlyTime = False
        Me.colAdd_Content.SQLString = ""
        Me.colAdd_Content.UpdateIfNull = ""
        Me.colAdd_Content.UpdateWhenFormLock = False
        Me.colAdd_Content.UpperValue = False
        Me.colAdd_Content.ValidateValue = True
        Me.colAdd_Content.Visible = True
        Me.colAdd_Content.VisibleIndex = 3
        Me.colAdd_Content.Width = 150
        '
        'colSDA_Amount
        '
        Me.colSDA_Amount.AllowInsert = True
        Me.colSDA_Amount.AllowUpdate = True
        Me.colSDA_Amount.ButtonClick = True
        Me.colSDA_Amount.Caption = "Hàm lượng SDA"
        Me.colSDA_Amount.CFLColumnHide = ""
        Me.colSDA_Amount.CFLKeyField = ""
        Me.colSDA_Amount.CFLPage = False
        Me.colSDA_Amount.CFLReturn0 = ""
        Me.colSDA_Amount.CFLReturn1 = ""
        Me.colSDA_Amount.CFLReturn2 = ""
        Me.colSDA_Amount.CFLReturn3 = ""
        Me.colSDA_Amount.CFLReturn4 = ""
        Me.colSDA_Amount.CFLReturn5 = ""
        Me.colSDA_Amount.CFLReturn6 = ""
        Me.colSDA_Amount.CFLReturn7 = ""
        Me.colSDA_Amount.CFLShowLoad = False
        Me.colSDA_Amount.ChangeFormStatus = True
        Me.colSDA_Amount.ColumnKey = False
        Me.colSDA_Amount.ComboLine = 5
        Me.colSDA_Amount.CopyFromItem = ""
        Me.colSDA_Amount.DefaultButtonClick = False
        Me.colSDA_Amount.Digit = False
        Me.colSDA_Amount.FieldType = "C"
        Me.colSDA_Amount.FieldView = "SDA_Amount"
        Me.colSDA_Amount.FormarNumber = True
        Me.colSDA_Amount.FormList = False
        Me.colSDA_Amount.KeyInsert = ""
        Me.colSDA_Amount.LocalDecimal = False
        Me.colSDA_Amount.Name = "colSDA_Amount"
        Me.colSDA_Amount.NoUpdate = ""
        Me.colSDA_Amount.NumberDecimal = 0
        Me.colSDA_Amount.ParentControl = ""
        Me.colSDA_Amount.RefreshSource = False
        Me.colSDA_Amount.Required = False
        Me.colSDA_Amount.SequenceName = ""
        Me.colSDA_Amount.ShowCalc = True
        Me.colSDA_Amount.ShowDataTime = False
        Me.colSDA_Amount.ShowOnlyTime = False
        Me.colSDA_Amount.SQLString = ""
        Me.colSDA_Amount.UpdateIfNull = ""
        Me.colSDA_Amount.UpdateWhenFormLock = False
        Me.colSDA_Amount.UpperValue = False
        Me.colSDA_Amount.ValidateValue = True
        Me.colSDA_Amount.Visible = True
        Me.colSDA_Amount.VisibleIndex = 4
        Me.colSDA_Amount.Width = 150
        '
        'colCrUser
        '
        Me.colCrUser.AllowInsert = True
        Me.colCrUser.AllowUpdate = True
        Me.colCrUser.ButtonClick = True
        Me.colCrUser.Caption = "User tạo"
        Me.colCrUser.CFLColumnHide = ""
        Me.colCrUser.CFLKeyField = ""
        Me.colCrUser.CFLPage = False
        Me.colCrUser.CFLReturn0 = ""
        Me.colCrUser.CFLReturn1 = ""
        Me.colCrUser.CFLReturn2 = ""
        Me.colCrUser.CFLReturn3 = ""
        Me.colCrUser.CFLReturn4 = ""
        Me.colCrUser.CFLReturn5 = ""
        Me.colCrUser.CFLReturn6 = ""
        Me.colCrUser.CFLReturn7 = ""
        Me.colCrUser.CFLShowLoad = False
        Me.colCrUser.ChangeFormStatus = True
        Me.colCrUser.ColumnKey = False
        Me.colCrUser.ComboLine = 5
        Me.colCrUser.CopyFromItem = ""
        Me.colCrUser.DefaultButtonClick = False
        Me.colCrUser.Digit = False
        Me.colCrUser.FieldType = "C"
        Me.colCrUser.FieldView = "CrUser"
        Me.colCrUser.FormarNumber = True
        Me.colCrUser.FormList = False
        Me.colCrUser.KeyInsert = ""
        Me.colCrUser.LocalDecimal = False
        Me.colCrUser.Name = "colCrUser"
        Me.colCrUser.NoUpdate = ""
        Me.colCrUser.NumberDecimal = 0
        Me.colCrUser.ParentControl = ""
        Me.colCrUser.RefreshSource = False
        Me.colCrUser.Required = False
        Me.colCrUser.SequenceName = ""
        Me.colCrUser.ShowCalc = True
        Me.colCrUser.ShowDataTime = False
        Me.colCrUser.ShowOnlyTime = False
        Me.colCrUser.SQLString = ""
        Me.colCrUser.UpdateIfNull = ""
        Me.colCrUser.UpdateWhenFormLock = False
        Me.colCrUser.UpperValue = False
        Me.colCrUser.ValidateValue = True
        Me.colCrUser.Visible = True
        Me.colCrUser.VisibleIndex = 5
        Me.colCrUser.Width = 90
        '
        'colCreateDate
        '
        Me.colCreateDate.AllowInsert = True
        Me.colCreateDate.AllowUpdate = True
        Me.colCreateDate.ButtonClick = True
        Me.colCreateDate.Caption = "Thời gian tạo"
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
        Me.colCreateDate.ParentControl = ""
        Me.colCreateDate.RefreshSource = False
        Me.colCreateDate.Required = False
        Me.colCreateDate.SequenceName = ""
        Me.colCreateDate.ShowCalc = True
        Me.colCreateDate.ShowDataTime = True
        Me.colCreateDate.ShowOnlyTime = False
        Me.colCreateDate.SQLString = ""
        Me.colCreateDate.UpdateIfNull = ""
        Me.colCreateDate.UpdateWhenFormLock = False
        Me.colCreateDate.UpperValue = False
        Me.colCreateDate.ValidateValue = True
        Me.colCreateDate.Visible = True
        Me.colCreateDate.VisibleIndex = 6
        Me.colCreateDate.Width = 200
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
        Me.CHECKUPD.UpperValue = False
        Me.CHECKUPD.ValidateValue = True
        Me.CHECKUPD.Visible = True
        Me.CHECKUPD.Width = 90
        '
        'GridColumn9
        '
        Me.GridColumn9.AllowInsert = True
        Me.GridColumn9.AllowUpdate = True
        Me.GridColumn9.ButtonClick = True
        Me.GridColumn9.Caption = "GridColumn9"
        Me.GridColumn9.CFLColumnHide = ""
        Me.GridColumn9.CFLKeyField = ""
        Me.GridColumn9.CFLPage = False
        Me.GridColumn9.CFLReturn0 = ""
        Me.GridColumn9.CFLReturn1 = ""
        Me.GridColumn9.CFLReturn2 = ""
        Me.GridColumn9.CFLReturn3 = ""
        Me.GridColumn9.CFLReturn4 = ""
        Me.GridColumn9.CFLReturn5 = ""
        Me.GridColumn9.CFLReturn6 = ""
        Me.GridColumn9.CFLReturn7 = ""
        Me.GridColumn9.CFLShowLoad = False
        Me.GridColumn9.ChangeFormStatus = True
        Me.GridColumn9.ColumnKey = False
        Me.GridColumn9.ComboLine = 5
        Me.GridColumn9.CopyFromItem = ""
        Me.GridColumn9.DefaultButtonClick = False
        Me.GridColumn9.Digit = False
        Me.GridColumn9.FieldType = "C"
        Me.GridColumn9.FieldView = ""
        Me.GridColumn9.FormarNumber = True
        Me.GridColumn9.FormList = False
        Me.GridColumn9.KeyInsert = ""
        Me.GridColumn9.LocalDecimal = False
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.NoUpdate = ""
        Me.GridColumn9.NumberDecimal = 0
        Me.GridColumn9.ParentControl = ""
        Me.GridColumn9.RefreshSource = False
        Me.GridColumn9.Required = False
        Me.GridColumn9.SequenceName = ""
        Me.GridColumn9.ShowCalc = True
        Me.GridColumn9.ShowDataTime = False
        Me.GridColumn9.ShowOnlyTime = False
        Me.GridColumn9.SQLString = ""
        Me.GridColumn9.UpdateIfNull = ""
        Me.GridColumn9.UpdateWhenFormLock = False
        Me.GridColumn9.UpperValue = False
        Me.GridColumn9.ValidateValue = True
        Me.GridColumn9.Visible = True
        Me.GridColumn9.Width = 90
        '
        'GridColumn10
        '
        Me.GridColumn10.AllowInsert = True
        Me.GridColumn10.AllowUpdate = True
        Me.GridColumn10.ButtonClick = True
        Me.GridColumn10.Caption = "GridColumn10"
        Me.GridColumn10.CFLColumnHide = ""
        Me.GridColumn10.CFLKeyField = ""
        Me.GridColumn10.CFLPage = False
        Me.GridColumn10.CFLReturn0 = ""
        Me.GridColumn10.CFLReturn1 = ""
        Me.GridColumn10.CFLReturn2 = ""
        Me.GridColumn10.CFLReturn3 = ""
        Me.GridColumn10.CFLReturn4 = ""
        Me.GridColumn10.CFLReturn5 = ""
        Me.GridColumn10.CFLReturn6 = ""
        Me.GridColumn10.CFLReturn7 = ""
        Me.GridColumn10.CFLShowLoad = False
        Me.GridColumn10.ChangeFormStatus = True
        Me.GridColumn10.ColumnKey = False
        Me.GridColumn10.ComboLine = 5
        Me.GridColumn10.CopyFromItem = ""
        Me.GridColumn10.DefaultButtonClick = False
        Me.GridColumn10.Digit = False
        Me.GridColumn10.FieldType = "C"
        Me.GridColumn10.FieldView = ""
        Me.GridColumn10.FormarNumber = True
        Me.GridColumn10.FormList = False
        Me.GridColumn10.KeyInsert = ""
        Me.GridColumn10.LocalDecimal = False
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.NoUpdate = ""
        Me.GridColumn10.NumberDecimal = 0
        Me.GridColumn10.ParentControl = ""
        Me.GridColumn10.RefreshSource = False
        Me.GridColumn10.Required = False
        Me.GridColumn10.SequenceName = ""
        Me.GridColumn10.ShowCalc = True
        Me.GridColumn10.ShowDataTime = False
        Me.GridColumn10.ShowOnlyTime = False
        Me.GridColumn10.SQLString = ""
        Me.GridColumn10.UpdateIfNull = ""
        Me.GridColumn10.UpdateWhenFormLock = False
        Me.GridColumn10.UpperValue = False
        Me.GridColumn10.ValidateValue = True
        Me.GridColumn10.Visible = True
        Me.GridColumn10.Width = 90
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(852, 28)
        Me.ToolStrip1.TabIndex = 468
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(108, 25)
        Me.ToolStripButton2.Text = "&1. Làm mới"
        Me.ToolStripButton2.Visible = False
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(72, 25)
        Me.ToolStripButton6.Text = "&4. Lưu"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 19)
        Me.Label7.TabIndex = 494
        Me.Label7.Text = "Bể xuất"
        '
        'TankCode
        '
        Me.TankCode.AllowInsert = True
        Me.TankCode.AllowUpdate = True
        Me.TankCode.AutoWidth = False
        Me.TankCode.BindingSourceName = ""
        Me.TankCode.ChangeFormStatus = True
        Me.TankCode.CopyFromItem = ""
        Me.TankCode.DefaultButtonClick = True
        Me.TankCode.DefaultValue = ""
        Me.TankCode.FieldName = "TankCode"
        Me.TankCode.FieldType = "C"
        Me.TankCode.FormList = False
        Me.TankCode.ItemReturn1 = ""
        Me.TankCode.ItemReturn2 = ""
        Me.TankCode.ItemReturn3 = ""
        Me.TankCode.KeyInsert = ""
        Me.TankCode.LinkLabel = ""
        Me.TankCode.Location = New System.Drawing.Point(83, 42)
        Me.TankCode.MultiSelect = False
        Me.TankCode.Name = "TankCode"
        Me.TankCode.NoUpdate = "N"
        Me.TankCode.OrderbyEx = ""
        Me.TankCode.PrimaryKey = ""
        Me.TankCode.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankCode.Properties.Appearance.Options.UseFont = True
        Me.TankCode.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankCode.Properties.AppearanceDisabled.Options.UseFont = True
        Me.TankCode.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankCode.Properties.AppearanceFocused.Options.UseFont = True
        Me.TankCode.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TankCode.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.TankCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TankCode.Required = ""
        Me.TankCode.ShowLoad = True
        Me.TankCode.Size = New System.Drawing.Size(95, 26)
        Me.TankCode.SqlFielKey = "TankCode"
        Me.TankCode.SqlString = ""
        Me.TankCode.TabIndex = 0
        Me.TankCode.TableName = "ztblTankBatchs"
        Me.TankCode.UpdateIfNull = ""
        Me.TankCode.UpdateWhenFormLock = False
        Me.TankCode.UpperValue = True
        Me.TankCode.ValidateValue = False
        Me.TankCode.ViewName = "ztblTankBatchs"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(189, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 19)
        Me.Label1.TabIndex = 496
        Me.Label1.Text = "Số lô"
        '
        'BatchNum
        '
        Me.BatchNum.AllowInsert = True
        Me.BatchNum.AllowUpdate = True
        Me.BatchNum.AutoKeyFix = ""
        Me.BatchNum.AutoKeyName = ""
        Me.BatchNum.BindingSourceName = ""
        Me.BatchNum.ChangeFormStatus = False
        Me.BatchNum.CopyFromItem = ""
        Me.BatchNum.DefaultValue = ""
        Me.BatchNum.FieldName = "BatchNum"
        Me.BatchNum.FieldType = "C"
        Me.BatchNum.KeyInsert = "N"
        Me.BatchNum.LinkLabel = ""
        Me.BatchNum.Location = New System.Drawing.Point(245, 44)
        Me.BatchNum.Name = "BatchNum"
        Me.BatchNum.NoUpdate = "N"
        Me.BatchNum.PrimaryKey = ""
        Me.BatchNum.Properties.AutoHeight = False
        Me.BatchNum.Required = ""
        Me.BatchNum.Size = New System.Drawing.Size(149, 26)
        Me.BatchNum.TabIndex = 1
        Me.BatchNum.TableName = "ztblTankBatchs"
        Me.BatchNum.UpdateIfNull = "N"
        Me.BatchNum.UpdateWhenFormLock = False
        Me.BatchNum.UpperValue = False
        Me.BatchNum.ViewName = "ztblTankBatchs"
        '
        'Add_Content
        '
        Me.Add_Content.AllowInsert = True
        Me.Add_Content.AllowUpdate = True
        Me.Add_Content.AutoKeyFix = ""
        Me.Add_Content.AutoKeyName = ""
        Me.Add_Content.BindingSourceName = ""
        Me.Add_Content.ChangeFormStatus = False
        Me.Add_Content.CopyFromItem = ""
        Me.Add_Content.DefaultValue = ""
        Me.Add_Content.FieldName = "Add_Content"
        Me.Add_Content.FieldType = "C"
        Me.Add_Content.KeyInsert = "N"
        Me.Add_Content.LinkLabel = ""
        Me.Add_Content.Location = New System.Drawing.Point(557, 44)
        Me.Add_Content.Name = "Add_Content"
        Me.Add_Content.NoUpdate = "N"
        Me.Add_Content.PrimaryKey = ""
        Me.Add_Content.Properties.AutoHeight = False
        Me.Add_Content.Properties.MaxLength = 10
        Me.Add_Content.Required = ""
        Me.Add_Content.Size = New System.Drawing.Size(201, 26)
        Me.Add_Content.TabIndex = 2
        Me.Add_Content.TableName = "ztblTankBatchs"
        Me.Add_Content.UpdateIfNull = "N"
        Me.Add_Content.UpdateWhenFormLock = False
        Me.Add_Content.UpperValue = False
        Me.Add_Content.ViewName = "ztblTankBatchs"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(405, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 19)
        Me.Label2.TabIndex = 496
        Me.Label2.Text = "Hàm lượng phụ gia"
        '
        'CrUser
        '
        Me.CrUser.AllowInsert = True
        Me.CrUser.AllowUpdate = True
        Me.CrUser.AutoKeyFix = ""
        Me.CrUser.AutoKeyName = ""
        Me.CrUser.BindingSourceName = ""
        Me.CrUser.ChangeFormStatus = False
        Me.CrUser.CopyFromItem = ""
        Me.CrUser.DefaultValue = ""
        Me.CrUser.FieldName = "CrUser"
        Me.CrUser.FieldType = "C"
        Me.CrUser.KeyInsert = "Y"
        Me.CrUser.LinkLabel = ""
        Me.CrUser.Location = New System.Drawing.Point(484, 18)
        Me.CrUser.Name = "CrUser"
        Me.CrUser.NoUpdate = "N"
        Me.CrUser.PrimaryKey = ""
        Me.CrUser.Properties.AutoHeight = False
        Me.CrUser.Properties.MaxLength = 10
        Me.CrUser.Required = ""
        Me.CrUser.Size = New System.Drawing.Size(0, 26)
        Me.CrUser.TabIndex = 497
        Me.CrUser.TableName = "ztblTankBatchs"
        Me.CrUser.TabStop = False
        Me.CrUser.UpdateIfNull = "N"
        Me.CrUser.UpdateWhenFormLock = False
        Me.CrUser.UpperValue = False
        Me.CrUser.ViewName = "tblTankBatchs_v"
        '
        'ID
        '
        Me.ID.AllowInsert = False
        Me.ID.AllowUpdate = False
        Me.ID.AutoKeyFix = ""
        Me.ID.AutoKeyName = ""
        Me.ID.BindingSourceName = ""
        Me.ID.ChangeFormStatus = True
        Me.ID.CopyFromItem = ""
        Me.ID.DefaultValue = ""
        Me.ID.Digit = True
        Me.ID.FieldName = "ID"
        Me.ID.FieldType = "N"
        Me.ID.KeyInsert = ""
        Me.ID.LinkLabel = ""
        Me.ID.LocalDecimal = False
        Me.ID.Location = New System.Drawing.Point(345, 13)
        Me.ID.Name = "ID"
        Me.ID.NoUpdate = ""
        Me.ID.NumberDecimal = 0
        Me.ID.PrimaryKey = "Y"
        Me.ID.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ID.Properties.Appearance.Options.UseFont = True
        Me.ID.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ID.Properties.AppearanceDisabled.Options.UseFont = True
        Me.ID.Properties.AppearanceFocused.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ID.Properties.AppearanceFocused.Options.UseFont = True
        Me.ID.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.ID.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.ID.Properties.AutoHeight = False
        Me.ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ID.Required = ""
        Me.ID.ShowCalc = True
        Me.ID.Size = New System.Drawing.Size(0, 30)
        Me.ID.TabIndex = 498
        Me.ID.TableName = "ztblTankBatchs"
        Me.ID.TabStop = False
        Me.ID.UpdateIfNull = ""
        Me.ID.UpdateWhenFormLock = False
        Me.ID.ViewName = "tblTankBatchs_v"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(405, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 19)
        Me.Label3.TabIndex = 500
        Me.Label3.Text = "Hàm lượng SDA"
        '
        'SDA_Amount
        '
        Me.SDA_Amount.AllowInsert = True
        Me.SDA_Amount.AllowUpdate = True
        Me.SDA_Amount.AutoKeyFix = ""
        Me.SDA_Amount.AutoKeyName = ""
        Me.SDA_Amount.BindingSourceName = ""
        Me.SDA_Amount.ChangeFormStatus = False
        Me.SDA_Amount.CopyFromItem = ""
        Me.SDA_Amount.DefaultValue = ""
        Me.SDA_Amount.FieldName = "SDA_Amount"
        Me.SDA_Amount.FieldType = "C"
        Me.SDA_Amount.KeyInsert = "N"
        Me.SDA_Amount.LinkLabel = ""
        Me.SDA_Amount.Location = New System.Drawing.Point(557, 76)
        Me.SDA_Amount.Name = "SDA_Amount"
        Me.SDA_Amount.NoUpdate = "N"
        Me.SDA_Amount.PrimaryKey = ""
        Me.SDA_Amount.Properties.AutoHeight = False
        Me.SDA_Amount.Properties.MaxLength = 10
        Me.SDA_Amount.Required = ""
        Me.SDA_Amount.Size = New System.Drawing.Size(201, 26)
        Me.SDA_Amount.TabIndex = 499
        Me.SDA_Amount.TableName = "ztblTankBatchs"
        Me.SDA_Amount.UpdateIfNull = "N"
        Me.SDA_Amount.UpdateWhenFormLock = False
        Me.SDA_Amount.UpperValue = False
        Me.SDA_Amount.ViewName = "ztblTankBatchs"
        '
        'FrmTankBatch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 493)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SDA_Amount)
        Me.Controls.Add(Me.ID)
        Me.Controls.Add(Me.CrUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Add_Content)
        Me.Controls.Add(Me.BatchNum)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TankCode)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultWhere = "where isnull(id,0) <0"
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.FormItemKey = "ID"
        Me.HeaderSource = "ztblTankBatchs"
        Me.Name = "FrmTankBatch"
        Me.Text = "Thông tin lô bể Jet A1"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip1, 0)
        Me.Controls.SetChildIndex(Me.TankCode, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.BatchNum, 0)
        Me.Controls.SetChildIndex(Me.Add_Content, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.CrUser, 0)
        Me.Controls.SetChildIndex(Me.ID, 0)
        Me.Controls.SetChildIndex(Me.SDA_Amount, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.TankCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BatchNum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Add_Content.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CrUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SDA_Amount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TankCode As U_TextBox.U_ButtonEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BatchNum As U_TextBox.U_TextBox
    Friend WithEvents Add_Content As U_TextBox.U_TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CrUser As U_TextBox.U_TextBox
    Friend WithEvents ID As U_TextBox.U_NumericEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID As U_TextBox.GridColumn
    Friend WithEvents colTankCode As U_TextBox.GridColumn
    Friend WithEvents Product_nd As U_TextBox.GridColumn
    Friend WithEvents colBatchNum As U_TextBox.GridColumn
    Friend WithEvents colAdd_Content As U_TextBox.GridColumn
    Friend WithEvents colCrUser As U_TextBox.GridColumn
    Friend WithEvents colCreateDate As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents GridColumn9 As U_TextBox.GridColumn
    Friend WithEvents GridColumn10 As U_TextBox.GridColumn
    Friend WithEvents colSDA_Amount As U_TextBox.GridColumn
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SDA_Amount As U_TextBox.U_TextBox
End Class
