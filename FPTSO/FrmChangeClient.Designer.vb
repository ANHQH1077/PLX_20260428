<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChangeClient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChangeClient))
        Me.TrueDBGrid1 = New U_TextBox.TrueDBGrid()
        Me.GridView1 = New U_TextBox.GridView()
        Me.ColSoLenh = New U_TextBox.GridColumn()
        Me.NgayXuat = New U_TextBox.GridColumn()
        Me.MaPhuongTien = New U_TextBox.GridColumn()
        Me.Client = New U_TextBox.GridColumn()
        Me.RepositoryItemGridLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.RepositoryItemGridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CHECKUPD = New U_TextBox.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.GridColumn6 = New U_TextBox.GridColumn()
        Me.GridColumn7 = New U_TextBox.GridColumn()
        Me.GridColumn8 = New U_TextBox.GridColumn()
        Me.GridColumn9 = New U_TextBox.GridColumn()
        Me.GridColumn10 = New U_TextBox.GridColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NgayThang = New U_TextBox.U_DateEdit()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SoLenh = New U_TextBox.U_TextBox()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayThang.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NgayThang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrueDBGrid1
        '
        Me.TrueDBGrid1.DefaultRemove = True
        Me.TrueDBGrid1.Location = New System.Drawing.Point(3, 82)
        Me.TrueDBGrid1.MainView = Me.GridView1
        Me.TrueDBGrid1.Name = "TrueDBGrid1"
        Me.TrueDBGrid1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemComboBox2, Me.RepositoryItemLookUpEdit1, Me.RepositoryItemGridLookUpEdit1})
        Me.TrueDBGrid1.Size = New System.Drawing.Size(615, 332)
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
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColSoLenh, Me.NgayXuat, Me.MaPhuongTien, Me.Client, Me.CHECKUPD})
        Me.GridView1.CompanyCode = ""
        Me.GridView1.DefaultRemove = True
        Me.GridView1.GetB1 = False
        Me.GridView1.GridControl = Me.TrueDBGrid1
        Me.GridView1.LastQuery = ""
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ObjectChild = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OrderBy = "SoLenh"
        Me.GridView1.ParentItem = Nothing
        Me.GridView1.RowNumber = ""
        Me.GridView1.TableName = "tblLenhXuatE5"
        Me.GridView1.ViewName = "FPT_tblLenhXuatE5_V"
        Me.GridView1.Where = "Status in  ('1','2')"
        '
        'ColSoLenh
        '
        Me.ColSoLenh.AllowInsert = True
        Me.ColSoLenh.AllowUpdate = True
        Me.ColSoLenh.ButtonClick = True
        Me.ColSoLenh.Caption = "Số lệnh"
        Me.ColSoLenh.CFLColumnHide = ""
        Me.ColSoLenh.CFLKeyField = ""
        Me.ColSoLenh.CFLPage = False
        Me.ColSoLenh.CFLReturn0 = ""
        Me.ColSoLenh.CFLReturn1 = ""
        Me.ColSoLenh.CFLReturn2 = ""
        Me.ColSoLenh.CFLReturn3 = ""
        Me.ColSoLenh.CFLReturn4 = ""
        Me.ColSoLenh.CFLReturn5 = ""
        Me.ColSoLenh.CFLReturn6 = ""
        Me.ColSoLenh.CFLReturn7 = ""
        Me.ColSoLenh.CFLShowLoad = False
        Me.ColSoLenh.ChangeFormStatus = True
        Me.ColSoLenh.ColumnKey = True
        Me.ColSoLenh.ComboLine = 5
        Me.ColSoLenh.CopyFromItem = ""
        Me.ColSoLenh.DefaultButtonClick = False
        Me.ColSoLenh.Digit = False
        Me.ColSoLenh.FieldType = "C"
        Me.ColSoLenh.FieldView = "SoLenh"
        Me.ColSoLenh.FormarNumber = True
        Me.ColSoLenh.FormList = False
        Me.ColSoLenh.KeyInsert = ""
        Me.ColSoLenh.LocalDecimal = False
        Me.ColSoLenh.Name = "ColSoLenh"
        Me.ColSoLenh.NoUpdate = ""
        Me.ColSoLenh.NumberDecimal = 0
        Me.ColSoLenh.OptionsColumn.ReadOnly = True
        Me.ColSoLenh.ParentControl = ""
        Me.ColSoLenh.RefreshSource = False
        Me.ColSoLenh.Required = False
        Me.ColSoLenh.SequenceName = ""
        Me.ColSoLenh.ShowCalc = True
        Me.ColSoLenh.ShowDataTime = False
        Me.ColSoLenh.ShowOnlyTime = False
        Me.ColSoLenh.SQLString = ""
        Me.ColSoLenh.UpdateIfNull = ""
        Me.ColSoLenh.UpdateWhenFormLock = False
        Me.ColSoLenh.UpperValue = False
        Me.ColSoLenh.ValidateValue = True
        Me.ColSoLenh.Visible = True
        Me.ColSoLenh.VisibleIndex = 0
        '
        'NgayXuat
        '
        Me.NgayXuat.AllowInsert = True
        Me.NgayXuat.AllowUpdate = True
        Me.NgayXuat.ButtonClick = True
        Me.NgayXuat.Caption = "Ngày xuất"
        Me.NgayXuat.CFLColumnHide = ""
        Me.NgayXuat.CFLKeyField = ""
        Me.NgayXuat.CFLPage = False
        Me.NgayXuat.CFLReturn0 = ""
        Me.NgayXuat.CFLReturn1 = ""
        Me.NgayXuat.CFLReturn2 = ""
        Me.NgayXuat.CFLReturn3 = ""
        Me.NgayXuat.CFLReturn4 = ""
        Me.NgayXuat.CFLReturn5 = ""
        Me.NgayXuat.CFLReturn6 = ""
        Me.NgayXuat.CFLReturn7 = ""
        Me.NgayXuat.CFLShowLoad = False
        Me.NgayXuat.ChangeFormStatus = True
        Me.NgayXuat.ColumnKey = False
        Me.NgayXuat.ComboLine = 5
        Me.NgayXuat.CopyFromItem = ""
        Me.NgayXuat.DefaultButtonClick = False
        Me.NgayXuat.Digit = False
        Me.NgayXuat.FieldType = "C"
        Me.NgayXuat.FieldView = "NgayXuat"
        Me.NgayXuat.FormarNumber = True
        Me.NgayXuat.FormList = False
        Me.NgayXuat.KeyInsert = ""
        Me.NgayXuat.LocalDecimal = False
        Me.NgayXuat.Name = "NgayXuat"
        Me.NgayXuat.NoUpdate = ""
        Me.NgayXuat.NumberDecimal = 0
        Me.NgayXuat.OptionsColumn.ReadOnly = True
        Me.NgayXuat.ParentControl = ""
        Me.NgayXuat.RefreshSource = False
        Me.NgayXuat.Required = False
        Me.NgayXuat.SequenceName = ""
        Me.NgayXuat.ShowCalc = True
        Me.NgayXuat.ShowDataTime = False
        Me.NgayXuat.ShowOnlyTime = False
        Me.NgayXuat.SQLString = ""
        Me.NgayXuat.UpdateIfNull = ""
        Me.NgayXuat.UpdateWhenFormLock = False
        Me.NgayXuat.UpperValue = False
        Me.NgayXuat.ValidateValue = True
        Me.NgayXuat.Visible = True
        Me.NgayXuat.VisibleIndex = 1
        '
        'MaPhuongTien
        '
        Me.MaPhuongTien.AllowInsert = True
        Me.MaPhuongTien.AllowUpdate = True
        Me.MaPhuongTien.ButtonClick = True
        Me.MaPhuongTien.Caption = "Phương tiện"
        Me.MaPhuongTien.CFLColumnHide = ""
        Me.MaPhuongTien.CFLKeyField = ""
        Me.MaPhuongTien.CFLPage = False
        Me.MaPhuongTien.CFLReturn0 = ""
        Me.MaPhuongTien.CFLReturn1 = ""
        Me.MaPhuongTien.CFLReturn2 = ""
        Me.MaPhuongTien.CFLReturn3 = ""
        Me.MaPhuongTien.CFLReturn4 = ""
        Me.MaPhuongTien.CFLReturn5 = ""
        Me.MaPhuongTien.CFLReturn6 = ""
        Me.MaPhuongTien.CFLReturn7 = ""
        Me.MaPhuongTien.CFLShowLoad = False
        Me.MaPhuongTien.ChangeFormStatus = True
        Me.MaPhuongTien.ColumnKey = False
        Me.MaPhuongTien.ComboLine = 5
        Me.MaPhuongTien.CopyFromItem = ""
        Me.MaPhuongTien.DefaultButtonClick = False
        Me.MaPhuongTien.Digit = False
        Me.MaPhuongTien.FieldType = "C"
        Me.MaPhuongTien.FieldView = "MaPhuongTien"
        Me.MaPhuongTien.FormarNumber = True
        Me.MaPhuongTien.FormList = False
        Me.MaPhuongTien.KeyInsert = ""
        Me.MaPhuongTien.LocalDecimal = False
        Me.MaPhuongTien.Name = "MaPhuongTien"
        Me.MaPhuongTien.NoUpdate = ""
        Me.MaPhuongTien.NumberDecimal = 0
        Me.MaPhuongTien.OptionsColumn.ReadOnly = True
        Me.MaPhuongTien.ParentControl = ""
        Me.MaPhuongTien.RefreshSource = False
        Me.MaPhuongTien.Required = False
        Me.MaPhuongTien.SequenceName = ""
        Me.MaPhuongTien.ShowCalc = True
        Me.MaPhuongTien.ShowDataTime = False
        Me.MaPhuongTien.ShowOnlyTime = False
        Me.MaPhuongTien.SQLString = ""
        Me.MaPhuongTien.UpdateIfNull = ""
        Me.MaPhuongTien.UpdateWhenFormLock = False
        Me.MaPhuongTien.UpperValue = False
        Me.MaPhuongTien.ValidateValue = True
        Me.MaPhuongTien.Visible = True
        Me.MaPhuongTien.VisibleIndex = 2
        '
        'Client
        '
        Me.Client.AllowInsert = True
        Me.Client.AllowUpdate = True
        Me.Client.ButtonClick = True
        Me.Client.Caption = "Kho"
        Me.Client.CFLColumnHide = ""
        Me.Client.CFLKeyField = ""
        Me.Client.CFLPage = False
        Me.Client.CFLReturn0 = ""
        Me.Client.CFLReturn1 = ""
        Me.Client.CFLReturn2 = ""
        Me.Client.CFLReturn3 = ""
        Me.Client.CFLReturn4 = ""
        Me.Client.CFLReturn5 = ""
        Me.Client.CFLReturn6 = ""
        Me.Client.CFLReturn7 = ""
        Me.Client.CFLShowLoad = False
        Me.Client.ChangeFormStatus = True
        Me.Client.ColumnEdit = Me.RepositoryItemGridLookUpEdit1
        Me.Client.ColumnKey = False
        Me.Client.ComboLine = 5
        Me.Client.CopyFromItem = ""
        Me.Client.DefaultButtonClick = False
        Me.Client.Digit = False
        Me.Client.FieldType = "C"
        Me.Client.FieldView = "Client"
        Me.Client.FormarNumber = True
        Me.Client.FormList = False
        Me.Client.KeyInsert = ""
        Me.Client.LocalDecimal = False
        Me.Client.Name = "Client"
        Me.Client.NoUpdate = ""
        Me.Client.NumberDecimal = 0
        Me.Client.ParentControl = ""
        Me.Client.RefreshSource = False
        Me.Client.Required = False
        Me.Client.SequenceName = ""
        Me.Client.ShowCalc = True
        Me.Client.ShowDataTime = False
        Me.Client.ShowOnlyTime = False
        Me.Client.SQLString = "select Client from FPT_Client_V"
        Me.Client.UpdateIfNull = ""
        Me.Client.UpdateWhenFormLock = False
        Me.Client.UpperValue = False
        Me.Client.ValidateValue = True
        Me.Client.Visible = True
        Me.Client.VisibleIndex = 3
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
        'CHECKUPD
        '
        Me.CHECKUPD.AllowInsert = True
        Me.CHECKUPD.AllowUpdate = True
        Me.CHECKUPD.ButtonClick = True
        Me.CHECKUPD.Caption = "GridColumn5"
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
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        '
        'GridColumn6
        '
        Me.GridColumn6.AllowInsert = True
        Me.GridColumn6.AllowUpdate = True
        Me.GridColumn6.ButtonClick = True
        Me.GridColumn6.Caption = "ctlColumn2"
        Me.GridColumn6.CFLColumnHide = ""
        Me.GridColumn6.CFLKeyField = ""
        Me.GridColumn6.CFLPage = False
        Me.GridColumn6.CFLReturn0 = ""
        Me.GridColumn6.CFLReturn1 = ""
        Me.GridColumn6.CFLReturn2 = ""
        Me.GridColumn6.CFLReturn3 = ""
        Me.GridColumn6.CFLReturn4 = ""
        Me.GridColumn6.CFLReturn5 = ""
        Me.GridColumn6.CFLReturn6 = ""
        Me.GridColumn6.CFLReturn7 = ""
        Me.GridColumn6.CFLShowLoad = False
        Me.GridColumn6.ChangeFormStatus = True
        Me.GridColumn6.ColumnKey = False
        Me.GridColumn6.ComboLine = 5
        Me.GridColumn6.CopyFromItem = ""
        Me.GridColumn6.DefaultButtonClick = False
        Me.GridColumn6.Digit = False
        Me.GridColumn6.FieldType = "C"
        Me.GridColumn6.FieldView = ""
        Me.GridColumn6.FormarNumber = True
        Me.GridColumn6.FormList = False
        Me.GridColumn6.KeyInsert = ""
        Me.GridColumn6.LocalDecimal = False
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.NoUpdate = ""
        Me.GridColumn6.NumberDecimal = 0
        Me.GridColumn6.ParentControl = ""
        Me.GridColumn6.RefreshSource = False
        Me.GridColumn6.Required = False
        Me.GridColumn6.SequenceName = ""
        Me.GridColumn6.ShowCalc = True
        Me.GridColumn6.ShowDataTime = False
        Me.GridColumn6.ShowOnlyTime = False
        Me.GridColumn6.SQLString = ""
        Me.GridColumn6.UpdateIfNull = ""
        Me.GridColumn6.UpdateWhenFormLock = False
        Me.GridColumn6.UpperValue = False
        Me.GridColumn6.ValidateValue = True
        Me.GridColumn6.Visible = True
        '
        'GridColumn7
        '
        Me.GridColumn7.AllowInsert = True
        Me.GridColumn7.AllowUpdate = True
        Me.GridColumn7.ButtonClick = True
        Me.GridColumn7.Caption = "ctlColumn3"
        Me.GridColumn7.CFLColumnHide = ""
        Me.GridColumn7.CFLKeyField = ""
        Me.GridColumn7.CFLPage = False
        Me.GridColumn7.CFLReturn0 = ""
        Me.GridColumn7.CFLReturn1 = ""
        Me.GridColumn7.CFLReturn2 = ""
        Me.GridColumn7.CFLReturn3 = ""
        Me.GridColumn7.CFLReturn4 = ""
        Me.GridColumn7.CFLReturn5 = ""
        Me.GridColumn7.CFLReturn6 = ""
        Me.GridColumn7.CFLReturn7 = ""
        Me.GridColumn7.CFLShowLoad = False
        Me.GridColumn7.ChangeFormStatus = True
        Me.GridColumn7.ColumnKey = False
        Me.GridColumn7.ComboLine = 5
        Me.GridColumn7.CopyFromItem = ""
        Me.GridColumn7.DefaultButtonClick = False
        Me.GridColumn7.Digit = False
        Me.GridColumn7.FieldType = "C"
        Me.GridColumn7.FieldView = ""
        Me.GridColumn7.FormarNumber = True
        Me.GridColumn7.FormList = False
        Me.GridColumn7.KeyInsert = ""
        Me.GridColumn7.LocalDecimal = False
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.NoUpdate = ""
        Me.GridColumn7.NumberDecimal = 0
        Me.GridColumn7.ParentControl = ""
        Me.GridColumn7.RefreshSource = False
        Me.GridColumn7.Required = False
        Me.GridColumn7.SequenceName = ""
        Me.GridColumn7.ShowCalc = True
        Me.GridColumn7.ShowDataTime = False
        Me.GridColumn7.ShowOnlyTime = False
        Me.GridColumn7.SQLString = ""
        Me.GridColumn7.UpdateIfNull = ""
        Me.GridColumn7.UpdateWhenFormLock = False
        Me.GridColumn7.UpperValue = False
        Me.GridColumn7.ValidateValue = True
        Me.GridColumn7.Visible = True
        '
        'GridColumn8
        '
        Me.GridColumn8.AllowInsert = True
        Me.GridColumn8.AllowUpdate = True
        Me.GridColumn8.ButtonClick = True
        Me.GridColumn8.Caption = "ctlColumn4"
        Me.GridColumn8.CFLColumnHide = ""
        Me.GridColumn8.CFLKeyField = ""
        Me.GridColumn8.CFLPage = False
        Me.GridColumn8.CFLReturn0 = ""
        Me.GridColumn8.CFLReturn1 = ""
        Me.GridColumn8.CFLReturn2 = ""
        Me.GridColumn8.CFLReturn3 = ""
        Me.GridColumn8.CFLReturn4 = ""
        Me.GridColumn8.CFLReturn5 = ""
        Me.GridColumn8.CFLReturn6 = ""
        Me.GridColumn8.CFLReturn7 = ""
        Me.GridColumn8.CFLShowLoad = False
        Me.GridColumn8.ChangeFormStatus = True
        Me.GridColumn8.ColumnKey = False
        Me.GridColumn8.ComboLine = 5
        Me.GridColumn8.CopyFromItem = ""
        Me.GridColumn8.DefaultButtonClick = False
        Me.GridColumn8.Digit = False
        Me.GridColumn8.FieldType = "C"
        Me.GridColumn8.FieldView = ""
        Me.GridColumn8.FormarNumber = True
        Me.GridColumn8.FormList = False
        Me.GridColumn8.KeyInsert = ""
        Me.GridColumn8.LocalDecimal = False
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.NoUpdate = ""
        Me.GridColumn8.NumberDecimal = 0
        Me.GridColumn8.ParentControl = ""
        Me.GridColumn8.RefreshSource = False
        Me.GridColumn8.Required = False
        Me.GridColumn8.SequenceName = ""
        Me.GridColumn8.ShowCalc = True
        Me.GridColumn8.ShowDataTime = False
        Me.GridColumn8.ShowOnlyTime = False
        Me.GridColumn8.SQLString = ""
        Me.GridColumn8.UpdateIfNull = ""
        Me.GridColumn8.UpdateWhenFormLock = False
        Me.GridColumn8.UpperValue = False
        Me.GridColumn8.ValidateValue = True
        Me.GridColumn8.Visible = True
        '
        'GridColumn9
        '
        Me.GridColumn9.AllowInsert = True
        Me.GridColumn9.AllowUpdate = True
        Me.GridColumn9.ButtonClick = True
        Me.GridColumn9.Caption = "ctlColumn5"
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
        '
        'GridColumn10
        '
        Me.GridColumn10.AllowInsert = True
        Me.GridColumn10.AllowUpdate = True
        Me.GridColumn10.ButtonClick = True
        Me.GridColumn10.Caption = "ctlColumn6"
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
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(223, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 19)
        Me.Label2.TabIndex = 203
        Me.Label2.Text = "Ngày xuất"
        '
        'NgayThang
        '
        Me.NgayThang.AllowInsert = True
        Me.NgayThang.AllowUpdate = True
        Me.NgayThang.BindingSourceName = ""
        Me.NgayThang.ChangeFormStatus = False
        Me.NgayThang.CopyFromItem = ""
        Me.NgayThang.DefaultValue = ""
        Me.NgayThang.EditValue = Nothing
        Me.NgayThang.FieldName = ""
        Me.NgayThang.FieldType = "D"
        Me.NgayThang.KeyInsert = ""
        Me.NgayThang.LinkLabel = ""
        Me.NgayThang.Location = New System.Drawing.Point(308, 39)
        Me.NgayThang.Name = "NgayThang"
        Me.NgayThang.NoUpdate = ""
        Me.NgayThang.PrimaryKey = ""
        Me.NgayThang.Properties.AutoHeight = False
        Me.NgayThang.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.NgayThang.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.NgayThang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.NgayThang.Properties.Mask.EditMask = "dd/MM/yyyy"
        Me.NgayThang.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.NgayThang.Required = ""
        Me.NgayThang.ShowDateTime = False
        Me.NgayThang.Size = New System.Drawing.Size(126, 26)
        Me.NgayThang.TabIndex = 202
        Me.NgayThang.TableName = ""
        Me.NgayThang.UpdateIfNull = ""
        Me.NgayThang.UpdateWhenFormLock = False
        Me.NgayThang.ViewName = ""
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton7.Appearance.Options.UseFont = True
        Me.SimpleButton7.Location = New System.Drawing.Point(446, 38)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(97, 26)
        Me.SimpleButton7.TabIndex = 200
        Me.SimpleButton7.Text = "&Tìm kiếm"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 19)
        Me.Label1.TabIndex = 201
        Me.Label1.Text = "Số lệnh"
        '
        'SoLenh
        '
        Me.SoLenh.AllowInsert = True
        Me.SoLenh.AllowUpdate = True
        Me.SoLenh.AutoKeyFix = ""
        Me.SoLenh.AutoKeyName = ""
        Me.SoLenh.BindingSourceName = ""
        Me.SoLenh.ChangeFormStatus = False
        Me.SoLenh.CopyFromItem = ""
        Me.SoLenh.DefaultValue = ""
        Me.SoLenh.FieldName = ""
        Me.SoLenh.FieldType = ""
        Me.SoLenh.KeyInsert = ""
        Me.SoLenh.LinkLabel = ""
        Me.SoLenh.Location = New System.Drawing.Point(84, 39)
        Me.SoLenh.Name = "SoLenh"
        Me.SoLenh.NoUpdate = "N"
        Me.SoLenh.PrimaryKey = ""
        Me.SoLenh.Properties.AutoHeight = False
        Me.SoLenh.Properties.MaxLength = 10
        Me.SoLenh.Required = ""
        Me.SoLenh.Size = New System.Drawing.Size(134, 26)
        Me.SoLenh.TabIndex = 199
        Me.SoLenh.TableName = ""
        Me.SoLenh.UpdateIfNull = ""
        Me.SoLenh.UpdateWhenFormLock = False
        Me.SoLenh.UpperValue = False
        Me.SoLenh.ViewName = ""
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(621, 28)
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
        'FrmChangeClient
        '
        Me.AcceptButton = Me.SimpleButton7
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 440)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NgayThang)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SoLenh)
        Me.Controls.Add(Me.TrueDBGrid1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.DefaultFormLoad = False
        Me.Name = "FrmChangeClient"
        Me.ShowFormMessage = True
        Me.Text = "Thay đổi Kho xuất"
        Me.Controls.SetChildIndex(Me.TrueDBGrid1, 0)
        Me.Controls.SetChildIndex(Me.SoLenh, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.SimpleButton7, 0)
        Me.Controls.SetChildIndex(Me.NgayThang, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.ToolStrip2, 0)
        CType(Me.pv_LineRemove, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_TableEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pv_GridViewEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrueDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayThang.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NgayThang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SoLenh.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TrueDBGrid1 As U_TextBox.TrueDBGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NgayThang As U_TextBox.U_DateEdit
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SoLenh As U_TextBox.U_TextBox
    Friend WithEvents GridColumn6 As U_TextBox.GridColumn
    Friend WithEvents GridColumn7 As U_TextBox.GridColumn
    Friend WithEvents GridColumn8 As U_TextBox.GridColumn
    Friend WithEvents GridColumn9 As U_TextBox.GridColumn
    Friend WithEvents GridColumn10 As U_TextBox.GridColumn
    Friend WithEvents GridView1 As U_TextBox.GridView
    Friend WithEvents ColSoLenh As U_TextBox.GridColumn
    Friend WithEvents NgayXuat As U_TextBox.GridColumn
    Friend WithEvents MaPhuongTien As U_TextBox.GridColumn
    Friend WithEvents Client As U_TextBox.GridColumn
    Friend WithEvents CHECKUPD As U_TextBox.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepositoryItemGridLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents RepositoryItemGridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
