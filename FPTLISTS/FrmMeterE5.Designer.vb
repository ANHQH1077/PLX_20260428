<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMeterE5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMeterE5))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.MeterId = New U_TextBox.GridColumn()
        Me.LoadingSite = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.ArmNo = New U_TextBox.GridColumn()
        Me.ProductCode = New U_TextBox.GridColumn()
        Me.TankE5 = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.TankID = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.TankProduct = New U_TextBox.GridColumn()
        Me.TankE = New U_TextBox.GridColumn()
        Me.RepositoryItemButtonEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.TankEProduct = New U_TextBox.GridColumn()
        Me.ERate = New U_TextBox.GridColumn()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 28)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemButtonEdit1, Me.RepositoryItemButtonEdit2, Me.RepositoryItemButtonEdit3})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(989, 418)
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
        Me.GridView1.ColumnKeyIns = True
        Me.GridView1.ColumnKeyType = "N"
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MeterId, Me.LoadingSite, Me.ArmNo, Me.ProductCode, Me.TankE5, Me.TankID, Me.TankProduct, Me.TankE, Me.TankEProduct, Me.ERate, Me.CHECKUPD})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = ""
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblMeterE5"
        Me.GridView1.ViewName = "FPT_tblMeterE5_V"
        Me.GridView1.Where = Nothing
        '
        'MeterId
        '
        Me.MeterId.AllowInsert = True
        Me.MeterId.AllowUpdate = False
        Me.MeterId.ButtonClick = True
        Me.MeterId.Caption = "Mã công tơ"
        Me.MeterId.CFLColumnHide = ""
        Me.MeterId.CFLKeyField = ""
        Me.MeterId.CFLPage = False
        Me.MeterId.CFLReturn0 = ""
        Me.MeterId.CFLReturn1 = ""
        Me.MeterId.CFLReturn2 = ""
        Me.MeterId.CFLReturn3 = ""
        Me.MeterId.CFLReturn4 = ""
        Me.MeterId.CFLReturn5 = ""
        Me.MeterId.CFLReturn6 = ""
        Me.MeterId.CFLReturn7 = ""
        Me.MeterId.CFLShowLoad = False
        Me.MeterId.ChangeFormStatus = True
        Me.MeterId.ColumnKey = True
        Me.MeterId.ComboLine = 5
        Me.MeterId.CopyFromItem = ""
        Me.MeterId.DefaultButtonClick = False
        Me.MeterId.Digit = False
        Me.MeterId.FieldType = "C"
        Me.MeterId.FieldView = "MeterId"
        Me.MeterId.FormarNumber = True
        Me.MeterId.FormList = False
        Me.MeterId.KeyInsert = ""
        Me.MeterId.LocalDecimal = False
        Me.MeterId.Name = "MeterId"
        Me.MeterId.NoUpdate = ""
        Me.MeterId.NumberDecimal = 0
        Me.MeterId.ParentControl = ""
        Me.MeterId.RefreshSource = False
        Me.MeterId.Required = False
        Me.MeterId.SequenceName = ""
        Me.MeterId.ShowCalc = True
        Me.MeterId.ShowDataTime = False
        Me.MeterId.ShowOnlyTime = False
        Me.MeterId.SQLString = ""
        Me.MeterId.UpdateIfNull = "Y"
        Me.MeterId.UpdateWhenFormLock = False
        Me.MeterId.UpperValue = False
        Me.MeterId.ValidateValue = True
        Me.MeterId.Visible = True
        Me.MeterId.VisibleIndex = 0
        '
        'LoadingSite
        '
        Me.LoadingSite.AllowInsert = True
        Me.LoadingSite.AllowUpdate = True
        Me.LoadingSite.ButtonClick = True
        Me.LoadingSite.Caption = "Loại"
        Me.LoadingSite.CFLColumnHide = ""
        Me.LoadingSite.CFLKeyField = ""
        Me.LoadingSite.CFLPage = False
        Me.LoadingSite.CFLReturn0 = ""
        Me.LoadingSite.CFLReturn1 = ""
        Me.LoadingSite.CFLReturn2 = ""
        Me.LoadingSite.CFLReturn3 = ""
        Me.LoadingSite.CFLReturn4 = ""
        Me.LoadingSite.CFLReturn5 = ""
        Me.LoadingSite.CFLReturn6 = ""
        Me.LoadingSite.CFLReturn7 = ""
        Me.LoadingSite.CFLShowLoad = False
        Me.LoadingSite.ChangeFormStatus = True
        Me.LoadingSite.ColumnEdit = Me.RepositoryItemComboBox1
        Me.LoadingSite.ColumnKey = False
        Me.LoadingSite.ComboLine = 5
        Me.LoadingSite.CopyFromItem = ""
        Me.LoadingSite.DefaultButtonClick = False
        Me.LoadingSite.Digit = False
        Me.LoadingSite.FieldType = "C"
        Me.LoadingSite.FieldView = "LoadingSite"
        Me.LoadingSite.FormarNumber = True
        Me.LoadingSite.FormList = False
        Me.LoadingSite.KeyInsert = ""
        Me.LoadingSite.LocalDecimal = False
        Me.LoadingSite.Name = "LoadingSite"
        Me.LoadingSite.NoUpdate = ""
        Me.LoadingSite.NumberDecimal = 0
        Me.LoadingSite.ParentControl = ""
        Me.LoadingSite.RefreshSource = False
        Me.LoadingSite.Required = False
        Me.LoadingSite.SequenceName = ""
        Me.LoadingSite.ShowCalc = True
        Me.LoadingSite.ShowDataTime = False
        Me.LoadingSite.ShowOnlyTime = False
        Me.LoadingSite.SQLString = "select Code as LoadingSite from FPT_LoaiHinhVanChuyen_V"
        Me.LoadingSite.UpdateIfNull = ""
        Me.LoadingSite.UpdateWhenFormLock = False
        Me.LoadingSite.UpperValue = False
        Me.LoadingSite.ValidateValue = True
        Me.LoadingSite.Visible = True
        Me.LoadingSite.VisibleIndex = 1
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'ArmNo
        '
        Me.ArmNo.AllowInsert = True
        Me.ArmNo.AllowUpdate = True
        Me.ArmNo.ButtonClick = True
        Me.ArmNo.Caption = "Họng"
        Me.ArmNo.CFLColumnHide = ""
        Me.ArmNo.CFLKeyField = ""
        Me.ArmNo.CFLPage = False
        Me.ArmNo.CFLReturn0 = ""
        Me.ArmNo.CFLReturn1 = ""
        Me.ArmNo.CFLReturn2 = ""
        Me.ArmNo.CFLReturn3 = ""
        Me.ArmNo.CFLReturn4 = ""
        Me.ArmNo.CFLReturn5 = ""
        Me.ArmNo.CFLReturn6 = ""
        Me.ArmNo.CFLReturn7 = ""
        Me.ArmNo.CFLShowLoad = False
        Me.ArmNo.ChangeFormStatus = True
        Me.ArmNo.ColumnKey = False
        Me.ArmNo.ComboLine = 5
        Me.ArmNo.CopyFromItem = ""
        Me.ArmNo.DefaultButtonClick = False
        Me.ArmNo.Digit = False
        Me.ArmNo.FieldType = "N"
        Me.ArmNo.FieldView = "ArmNo"
        Me.ArmNo.FormarNumber = True
        Me.ArmNo.FormList = False
        Me.ArmNo.KeyInsert = ""
        Me.ArmNo.LocalDecimal = False
        Me.ArmNo.Name = "ArmNo"
        Me.ArmNo.NoUpdate = ""
        Me.ArmNo.NumberDecimal = 0
        Me.ArmNo.ParentControl = ""
        Me.ArmNo.RefreshSource = False
        Me.ArmNo.Required = False
        Me.ArmNo.SequenceName = ""
        Me.ArmNo.ShowCalc = True
        Me.ArmNo.ShowDataTime = False
        Me.ArmNo.ShowOnlyTime = False
        Me.ArmNo.SQLString = ""
        Me.ArmNo.UpdateIfNull = ""
        Me.ArmNo.UpdateWhenFormLock = False
        Me.ArmNo.UpperValue = False
        Me.ArmNo.ValidateValue = True
        Me.ArmNo.Visible = True
        Me.ArmNo.VisibleIndex = 2
        '
        'ProductCode
        '
        Me.ProductCode.AllowInsert = True
        Me.ProductCode.AllowUpdate = True
        Me.ProductCode.ButtonClick = True
        Me.ProductCode.Caption = "Hàng hóa"
        Me.ProductCode.CFLColumnHide = ""
        Me.ProductCode.CFLKeyField = ""
        Me.ProductCode.CFLPage = False
        Me.ProductCode.CFLReturn0 = ""
        Me.ProductCode.CFLReturn1 = ""
        Me.ProductCode.CFLReturn2 = ""
        Me.ProductCode.CFLReturn3 = ""
        Me.ProductCode.CFLReturn4 = ""
        Me.ProductCode.CFLReturn5 = ""
        Me.ProductCode.CFLReturn6 = ""
        Me.ProductCode.CFLReturn7 = ""
        Me.ProductCode.CFLShowLoad = False
        Me.ProductCode.ChangeFormStatus = True
        Me.ProductCode.ColumnKey = False
        Me.ProductCode.ComboLine = 5
        Me.ProductCode.CopyFromItem = ""
        Me.ProductCode.DefaultButtonClick = False
        Me.ProductCode.Digit = False
        Me.ProductCode.FieldType = "C"
        Me.ProductCode.FieldView = "ProductCode"
        Me.ProductCode.FormarNumber = True
        Me.ProductCode.FormList = False
        Me.ProductCode.KeyInsert = ""
        Me.ProductCode.LocalDecimal = False
        Me.ProductCode.Name = "ProductCode"
        Me.ProductCode.NoUpdate = ""
        Me.ProductCode.NumberDecimal = 0
        Me.ProductCode.OptionsColumn.ReadOnly = True
        Me.ProductCode.ParentControl = ""
        Me.ProductCode.RefreshSource = False
        Me.ProductCode.Required = False
        Me.ProductCode.SequenceName = ""
        Me.ProductCode.ShowCalc = True
        Me.ProductCode.ShowDataTime = False
        Me.ProductCode.ShowOnlyTime = False
        Me.ProductCode.SQLString = ""
        Me.ProductCode.UpdateIfNull = ""
        Me.ProductCode.UpdateWhenFormLock = False
        Me.ProductCode.UpperValue = False
        Me.ProductCode.ValidateValue = True
        Me.ProductCode.Visible = True
        Me.ProductCode.VisibleIndex = 3
        '
        'TankE5
        '
        Me.TankE5.AllowInsert = True
        Me.TankE5.AllowUpdate = True
        Me.TankE5.ButtonClick = True
        Me.TankE5.Caption = "Bể E5"
        Me.TankE5.CFLColumnHide = ""
        Me.TankE5.CFLKeyField = "TankE5"
        Me.TankE5.CFLPage = False
        Me.TankE5.CFLReturn0 = ""
        Me.TankE5.CFLReturn1 = "ProductCode"
        Me.TankE5.CFLReturn2 = ""
        Me.TankE5.CFLReturn3 = ""
        Me.TankE5.CFLReturn4 = ""
        Me.TankE5.CFLReturn5 = ""
        Me.TankE5.CFLReturn6 = ""
        Me.TankE5.CFLReturn7 = ""
        Me.TankE5.CFLShowLoad = True
        Me.TankE5.ChangeFormStatus = True
        Me.TankE5.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.TankE5.ColumnKey = False
        Me.TankE5.ComboLine = 5
        Me.TankE5.CopyFromItem = ""
        Me.TankE5.DefaultButtonClick = False
        Me.TankE5.Digit = False
        Me.TankE5.FieldType = "C"
        Me.TankE5.FieldView = "TankE5"
        Me.TankE5.FormarNumber = True
        Me.TankE5.FormList = False
        Me.TankE5.KeyInsert = ""
        Me.TankE5.LocalDecimal = False
        Me.TankE5.Name = "TankE5"
        Me.TankE5.NoUpdate = ""
        Me.TankE5.NumberDecimal = 0
        Me.TankE5.ParentControl = ""
        Me.TankE5.RefreshSource = False
        Me.TankE5.Required = False
        Me.TankE5.SequenceName = ""
        Me.TankE5.ShowCalc = True
        Me.TankE5.ShowDataTime = False
        Me.TankE5.ShowOnlyTime = False
        Me.TankE5.SQLString = resources.GetString("TankE5.SQLString")
        Me.TankE5.UpdateIfNull = ""
        Me.TankE5.UpdateWhenFormLock = False
        Me.TankE5.UpperValue = False
        Me.TankE5.ValidateValue = True
        Me.TankE5.Visible = True
        Me.TankE5.VisibleIndex = 4
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'TankID
        '
        Me.TankID.AllowInsert = True
        Me.TankID.AllowUpdate = True
        Me.TankID.ButtonClick = True
        Me.TankID.Caption = "Bể xăng chính"
        Me.TankID.CFLColumnHide = ""
        Me.TankID.CFLKeyField = "TankID"
        Me.TankID.CFLPage = False
        Me.TankID.CFLReturn0 = ""
        Me.TankID.CFLReturn1 = "TankProduct"
        Me.TankID.CFLReturn2 = ""
        Me.TankID.CFLReturn3 = ""
        Me.TankID.CFLReturn4 = ""
        Me.TankID.CFLReturn5 = ""
        Me.TankID.CFLReturn6 = ""
        Me.TankID.CFLReturn7 = ""
        Me.TankID.CFLShowLoad = True
        Me.TankID.ChangeFormStatus = True
        Me.TankID.ColumnEdit = Me.RepositoryItemButtonEdit2
        Me.TankID.ColumnKey = False
        Me.TankID.ComboLine = 5
        Me.TankID.CopyFromItem = ""
        Me.TankID.DefaultButtonClick = False
        Me.TankID.Digit = False
        Me.TankID.FieldType = "C"
        Me.TankID.FieldView = "TankID"
        Me.TankID.FormarNumber = True
        Me.TankID.FormList = False
        Me.TankID.KeyInsert = ""
        Me.TankID.LocalDecimal = False
        Me.TankID.Name = "TankID"
        Me.TankID.NoUpdate = ""
        Me.TankID.NumberDecimal = 0
        Me.TankID.ParentControl = ""
        Me.TankID.RefreshSource = False
        Me.TankID.Required = False
        Me.TankID.SequenceName = ""
        Me.TankID.ShowCalc = True
        Me.TankID.ShowDataTime = False
        Me.TankID.ShowOnlyTime = False
        Me.TankID.SQLString = "SELECT  Name_nd  as TankID ,[Product_nd] as TankProduct,[TenHangHoa]  FROM [FPT_t" & _
            "blTankActive_V]  where Date1 =CONVERT(date,getdate()) and  Product_nd in (select" & _
            " MaHangHoa from tblHangHoaE5)"
        Me.TankID.UpdateIfNull = ""
        Me.TankID.UpdateWhenFormLock = False
        Me.TankID.UpperValue = False
        Me.TankID.ValidateValue = True
        Me.TankID.Visible = True
        Me.TankID.VisibleIndex = 5
        '
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        '
        'TankProduct
        '
        Me.TankProduct.AllowInsert = True
        Me.TankProduct.AllowUpdate = True
        Me.TankProduct.ButtonClick = True
        Me.TankProduct.Caption = "Xăng chính"
        Me.TankProduct.CFLColumnHide = ""
        Me.TankProduct.CFLKeyField = ""
        Me.TankProduct.CFLPage = False
        Me.TankProduct.CFLReturn0 = ""
        Me.TankProduct.CFLReturn1 = ""
        Me.TankProduct.CFLReturn2 = ""
        Me.TankProduct.CFLReturn3 = ""
        Me.TankProduct.CFLReturn4 = ""
        Me.TankProduct.CFLReturn5 = ""
        Me.TankProduct.CFLReturn6 = ""
        Me.TankProduct.CFLReturn7 = ""
        Me.TankProduct.CFLShowLoad = False
        Me.TankProduct.ChangeFormStatus = True
        Me.TankProduct.ColumnKey = False
        Me.TankProduct.ComboLine = 5
        Me.TankProduct.CopyFromItem = ""
        Me.TankProduct.DefaultButtonClick = False
        Me.TankProduct.Digit = False
        Me.TankProduct.FieldType = "C"
        Me.TankProduct.FieldView = "TankProduct"
        Me.TankProduct.FormarNumber = True
        Me.TankProduct.FormList = False
        Me.TankProduct.KeyInsert = ""
        Me.TankProduct.LocalDecimal = False
        Me.TankProduct.Name = "TankProduct"
        Me.TankProduct.NoUpdate = ""
        Me.TankProduct.NumberDecimal = 0
        Me.TankProduct.OptionsColumn.ReadOnly = True
        Me.TankProduct.ParentControl = ""
        Me.TankProduct.RefreshSource = False
        Me.TankProduct.Required = False
        Me.TankProduct.SequenceName = ""
        Me.TankProduct.ShowCalc = True
        Me.TankProduct.ShowDataTime = False
        Me.TankProduct.ShowOnlyTime = False
        Me.TankProduct.SQLString = ""
        Me.TankProduct.UpdateIfNull = ""
        Me.TankProduct.UpdateWhenFormLock = False
        Me.TankProduct.UpperValue = False
        Me.TankProduct.ValidateValue = True
        Me.TankProduct.Visible = True
        Me.TankProduct.VisibleIndex = 6
        '
        'TankE
        '
        Me.TankE.AllowInsert = True
        Me.TankE.AllowUpdate = True
        Me.TankE.ButtonClick = True
        Me.TankE.Caption = "Bể Ethanol"
        Me.TankE.CFLColumnHide = ""
        Me.TankE.CFLKeyField = "TankE"
        Me.TankE.CFLPage = False
        Me.TankE.CFLReturn0 = ""
        Me.TankE.CFLReturn1 = "TankEProduct"
        Me.TankE.CFLReturn2 = ""
        Me.TankE.CFLReturn3 = ""
        Me.TankE.CFLReturn4 = ""
        Me.TankE.CFLReturn5 = ""
        Me.TankE.CFLReturn6 = ""
        Me.TankE.CFLReturn7 = ""
        Me.TankE.CFLShowLoad = True
        Me.TankE.ChangeFormStatus = True
        Me.TankE.ColumnEdit = Me.RepositoryItemButtonEdit3
        Me.TankE.ColumnKey = False
        Me.TankE.ComboLine = 5
        Me.TankE.CopyFromItem = ""
        Me.TankE.DefaultButtonClick = False
        Me.TankE.Digit = False
        Me.TankE.FieldType = "C"
        Me.TankE.FieldView = "TankE"
        Me.TankE.FormarNumber = True
        Me.TankE.FormList = False
        Me.TankE.KeyInsert = ""
        Me.TankE.LocalDecimal = False
        Me.TankE.Name = "TankE"
        Me.TankE.NoUpdate = ""
        Me.TankE.NumberDecimal = 0
        Me.TankE.ParentControl = ""
        Me.TankE.RefreshSource = False
        Me.TankE.Required = False
        Me.TankE.SequenceName = ""
        Me.TankE.ShowCalc = True
        Me.TankE.ShowDataTime = False
        Me.TankE.ShowOnlyTime = False
        Me.TankE.SQLString = "SELECT  Name_nd  as TankID ,[Product_nd] as TankProduct,[TenHangHoa]  FROM [FPT_t" & _
            "blTankActive_V]  where Date1 =CONVERT(date,getdate()) and  Product_nd like '0301" & _
            "%'"
        Me.TankE.UpdateIfNull = ""
        Me.TankE.UpdateWhenFormLock = False
        Me.TankE.UpperValue = False
        Me.TankE.ValidateValue = True
        Me.TankE.Visible = True
        Me.TankE.VisibleIndex = 7
        '
        'RepositoryItemButtonEdit3
        '
        Me.RepositoryItemButtonEdit3.AutoHeight = False
        Me.RepositoryItemButtonEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit3.Name = "RepositoryItemButtonEdit3"
        '
        'TankEProduct
        '
        Me.TankEProduct.AllowInsert = True
        Me.TankEProduct.AllowUpdate = True
        Me.TankEProduct.ButtonClick = True
        Me.TankEProduct.Caption = "Ethanol"
        Me.TankEProduct.CFLColumnHide = ""
        Me.TankEProduct.CFLKeyField = ""
        Me.TankEProduct.CFLPage = False
        Me.TankEProduct.CFLReturn0 = ""
        Me.TankEProduct.CFLReturn1 = ""
        Me.TankEProduct.CFLReturn2 = ""
        Me.TankEProduct.CFLReturn3 = ""
        Me.TankEProduct.CFLReturn4 = ""
        Me.TankEProduct.CFLReturn5 = ""
        Me.TankEProduct.CFLReturn6 = ""
        Me.TankEProduct.CFLReturn7 = ""
        Me.TankEProduct.CFLShowLoad = False
        Me.TankEProduct.ChangeFormStatus = True
        Me.TankEProduct.ColumnKey = False
        Me.TankEProduct.ComboLine = 5
        Me.TankEProduct.CopyFromItem = ""
        Me.TankEProduct.DefaultButtonClick = False
        Me.TankEProduct.Digit = False
        Me.TankEProduct.FieldType = "C"
        Me.TankEProduct.FieldView = "TankEProduct"
        Me.TankEProduct.FormarNumber = True
        Me.TankEProduct.FormList = False
        Me.TankEProduct.KeyInsert = ""
        Me.TankEProduct.LocalDecimal = False
        Me.TankEProduct.Name = "TankEProduct"
        Me.TankEProduct.NoUpdate = ""
        Me.TankEProduct.NumberDecimal = 0
        Me.TankEProduct.OptionsColumn.ReadOnly = True
        Me.TankEProduct.ParentControl = ""
        Me.TankEProduct.RefreshSource = False
        Me.TankEProduct.Required = False
        Me.TankEProduct.SequenceName = ""
        Me.TankEProduct.ShowCalc = True
        Me.TankEProduct.ShowDataTime = False
        Me.TankEProduct.ShowOnlyTime = False
        Me.TankEProduct.SQLString = ""
        Me.TankEProduct.UpdateIfNull = ""
        Me.TankEProduct.UpdateWhenFormLock = False
        Me.TankEProduct.UpperValue = False
        Me.TankEProduct.ValidateValue = True
        Me.TankEProduct.Visible = True
        Me.TankEProduct.VisibleIndex = 8
        '
        'ERate
        '
        Me.ERate.AllowInsert = True
        Me.ERate.AllowUpdate = True
        Me.ERate.ButtonClick = True
        Me.ERate.Caption = "Tỷ lệ pha chế"
        Me.ERate.CFLColumnHide = ""
        Me.ERate.CFLKeyField = ""
        Me.ERate.CFLPage = False
        Me.ERate.CFLReturn0 = ""
        Me.ERate.CFLReturn1 = ""
        Me.ERate.CFLReturn2 = ""
        Me.ERate.CFLReturn3 = ""
        Me.ERate.CFLReturn4 = ""
        Me.ERate.CFLReturn5 = ""
        Me.ERate.CFLReturn6 = ""
        Me.ERate.CFLReturn7 = ""
        Me.ERate.CFLShowLoad = False
        Me.ERate.ChangeFormStatus = True
        Me.ERate.ColumnKey = False
        Me.ERate.ComboLine = 5
        Me.ERate.CopyFromItem = ""
        Me.ERate.DefaultButtonClick = False
        Me.ERate.Digit = True
        Me.ERate.FieldType = "N"
        Me.ERate.FieldView = "ERate"
        Me.ERate.FormarNumber = True
        Me.ERate.FormList = False
        Me.ERate.KeyInsert = ""
        Me.ERate.LocalDecimal = True
        Me.ERate.Name = "ERate"
        Me.ERate.NoUpdate = ""
        Me.ERate.NumberDecimal = 2
        Me.ERate.ParentControl = ""
        Me.ERate.RefreshSource = False
        Me.ERate.Required = False
        Me.ERate.SequenceName = ""
        Me.ERate.ShowCalc = True
        Me.ERate.ShowDataTime = False
        Me.ERate.ShowOnlyTime = False
        Me.ERate.SQLString = ""
        Me.ERate.UpdateIfNull = ""
        Me.ERate.UpdateWhenFormLock = False
        Me.ERate.UpperValue = False
        Me.ERate.ValidateValue = True
        Me.ERate.Visible = True
        Me.ERate.VisibleIndex = 9
        '
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
        Me.CHECKUPD.ButtonClick = True
        Me.CHECKUPD.Caption = "GridColumn1"
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
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(996, 28)
        Me.ToolStrip2.TabIndex = 469
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(72, 25)
        Me.ToolStripButton1.Text = "&2. Lưu"
        '
        'FrmMeterE5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 469)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.DefaultFormLoad = False
        Me.DefaultSave = False
        Me.Name = "FrmMeterE5"
        Me.ShowFormMessage = True
        Me.Text = "Thông tin công tơ pha chế"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents MeterId As U_TextBox.GridColumn
    Friend WithEvents LoadingSite As U_TextBox.GridColumn
    Friend WithEvents ArmNo As U_TextBox.GridColumn
    Friend WithEvents ProductCode As U_TextBox.GridColumn
    Friend WithEvents TankE5 As U_TextBox.GridColumn
    Friend WithEvents TankID As U_TextBox.GridColumn
    Friend WithEvents TankProduct As U_TextBox.GridColumn
    Friend WithEvents TankE As U_TextBox.GridColumn
    Friend WithEvents TankEProduct As U_TextBox.GridColumn
    Friend WithEvents ERate As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemButtonEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
